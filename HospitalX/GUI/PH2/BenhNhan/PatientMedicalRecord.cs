using System;
using System.Collections.Generic;

namespace HospitalX.GUI.PH2.BenhNhan
{
    public class PatientMedicalRecord
    {
        public string Id { get; set; }
        public string PatientId { get; set; }
        public string PatientName { get; set; }
        public DateTime Date { get; set; }
        public string Diagnosis { get; set; }
        public string Treatment { get; set; }
        public string DoctorId { get; set; }
        public string DoctorName { get; set; }
        public string DoctorRole { get; set; }
        public string DoctorGender { get; set; }
        public string DoctorPhone { get; set; }
        public string Department { get; set; }
        public string Conclusion { get; set; }
        public List<RecordService> Services { get; set; } = new List<RecordService>();
        public List<RecordPrescription> Prescriptions { get; set; } = new List<RecordPrescription>();

        private static string GetRowString(System.Data.DataRow row, params string[] colNames)
        {
            foreach (var name in colNames)
            {
                if (row.Table.Columns.Contains(name))
                {
                    return row[name] != DBNull.Value ? row[name].ToString().Trim() : "";
                }
            }
            return "";
        }

        private static DateTime GetRowDate(System.Data.DataRow row, string[] colNames, DateTime fallback)
        {
            foreach (var name in colNames)
            {
                if (row.Table.Columns.Contains(name))
                {
                    return row[name] != DBNull.Value ? Convert.ToDateTime(row[name]) : fallback;
                }
            }
            return fallback;
        }

        public static List<PatientMedicalRecord> LoadFromDB()
        {
            var records = new List<PatientMedicalRecord>();
            try
            {
                string procHsba = "ADMINHOS.SP_GET_HSBA_FOR_PATIENT";
                Oracle.ManagedDataAccess.Client.OracleParameter[] hsbaParams = new Oracle.ManagedDataAccess.Client.OracleParameter[]
                {
                    new Oracle.ManagedDataAccess.Client.OracleParameter("p_mabn", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2) { Value = HospitalX.DAO.DataProvider.Instance.CurrentUser },
                    new Oracle.ManagedDataAccess.Client.OracleParameter("p_cursor", Oracle.ManagedDataAccess.Client.OracleDbType.RefCursor) { Direction = System.Data.ParameterDirection.Output }
                };
                System.Data.DataTable dtHsba = HospitalX.DAO.DataProvider.Instance.ExecuteQuery(procHsba, hsbaParams, true);
                if (dtHsba != null)
                {
                    foreach (System.Data.DataRow row in dtHsba.Rows)
                    {
                        var pmr = new PatientMedicalRecord();
                        pmr.Id = GetRowString(row, "MAHSBA");
                        pmr.PatientId = GetRowString(row, "MABN");
                        pmr.PatientName = GetRowString(row, "TENBN", "TEN_BENH_NHAN");
                        pmr.Date = GetRowDate(row, new[] { "NGAY", "NGAYTAO" }, DateTime.Today);
                        pmr.Diagnosis = GetRowString(row, "CHANDOAN");
                        pmr.Treatment = GetRowString(row, "DIEUTRI");
                        pmr.Conclusion = GetRowString(row, "KETLUAN");
                        pmr.DoctorId = GetRowString(row, "MABS", "MA_BACSI");
                        pmr.DoctorName = GetRowString(row, "TENBS", "TEN_BACSI");
                        if (string.IsNullOrEmpty(pmr.DoctorName)) pmr.DoctorName = "Bác sĩ điều trị";
                        pmr.DoctorRole = "Bác sĩ";
                        pmr.Department = GetRowString(row, "TENKHOA", "MAKHOA", "CHUYENKHOA");
                        if (string.IsNullOrEmpty(pmr.Department)) pmr.Department = "Khoa điều trị";

                        // Load dịch vụ đi kèm với HSBA này
                        string procDv = "ADMINHOS.SP_GET_SERVICES_FOR_HSBA";
                        Oracle.ManagedDataAccess.Client.OracleParameter[] dvParams = new Oracle.ManagedDataAccess.Client.OracleParameter[]
                        {
                            new Oracle.ManagedDataAccess.Client.OracleParameter("p_mahsba", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2) { Value = pmr.Id },
                            new Oracle.ManagedDataAccess.Client.OracleParameter("p_cursor", Oracle.ManagedDataAccess.Client.OracleDbType.RefCursor) { Direction = System.Data.ParameterDirection.Output }
                        };
                        System.Data.DataTable dtDv = HospitalX.DAO.DataProvider.Instance.ExecuteQuery(procDv, dvParams, true);
                        if (dtDv != null)
                        {
                            foreach (System.Data.DataRow dRow in dtDv.Rows)
                            {
                                string tendv = GetRowString(dRow, "LOAIDV", "TENDV", "LOAI_DICHVU");
                                DateTime ngayy = GetRowDate(dRow, new[] { "NGAYDV", "NGAYYEUCAU" }, pmr.Date);
                                string maktv = GetRowString(dRow, "MAKTV", "MA_KTV");
                                if (string.IsNullOrEmpty(maktv)) maktv = "Chưa phân công";
                                string ketqua = GetRowString(dRow, "KETQUA", "KET_QUA");
                                if (string.IsNullOrEmpty(ketqua)) ketqua = "Chờ thực hiện";
                                pmr.Services.Add(new RecordService(tendv, ngayy, maktv, ketqua));
                            }
                        }

                        // Load đơn thuốc đi kèm với HSBA này
                        string procDt = "ADMINHOS.SP_GET_PRESCRIPTIONS_FOR_HSBA";
                        Oracle.ManagedDataAccess.Client.OracleParameter[] dtParams = new Oracle.ManagedDataAccess.Client.OracleParameter[]
                        {
                            new Oracle.ManagedDataAccess.Client.OracleParameter("p_mahsba", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2) { Value = pmr.Id },
                            new Oracle.ManagedDataAccess.Client.OracleParameter("p_cursor", Oracle.ManagedDataAccess.Client.OracleDbType.RefCursor) { Direction = System.Data.ParameterDirection.Output }
                        };
                        System.Data.DataTable dtPres = HospitalX.DAO.DataProvider.Instance.ExecuteQuery(procDt, dtParams, true);
                        if (dtPres != null)
                        {
                            foreach (System.Data.DataRow pRow in dtPres.Rows)
                            {
                                string thuoc = GetRowString(pRow, "TENTHUOC");
                                string lieudung = GetRowString(pRow, "LIEUDUNG", "CACHDUNG", "CACH_DUNG");
                                pmr.Prescriptions.Add(new RecordPrescription(pmr.Date, thuoc, lieudung));
                            }
                        }

                        records.Add(pmr);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Warning: Lỗi load bệnh án từ database: " + ex.Message);
            }
            return records;
        }

        public static List<PatientMedicalRecord> CreateSampleData()
        {
            return new List<PatientMedicalRecord>
            {
                new PatientMedicalRecord
                {
                    Id = "HSBA-0821",
                    PatientId = "BN-00341",
                    PatientName = "Nguyễn Văn An",
                    Date = new DateTime(2026, 5, 21),
                    Diagnosis = "Tăng huyết áp độ II, rối loạn nhịp tim",
                    Treatment = "Amlodipine 5mg, Bisoprolol 2.5mg, theo dõi huyết áp",
                    DoctorId = "BS-001",
                    DoctorName = "Trúc Hằng",
                    DoctorRole = "Bác sĩ",
                    DoctorGender = "Nữ",
                    DoctorPhone = "0901234567",
                    Department = "Khoa Tim Mạch",
                    Conclusion = "Theo dõi huyết áp định kỳ, tái khám sau 4 tuần",
                    Services = new List<RecordService>
                    {
                        new RecordService("Xét nghiệm máu", new DateTime(2026, 5, 21), "KTV-004", "Các chỉ số trong giới hạn cho phép"),
                        new RecordService("Điện tim", new DateTime(2026, 5, 21), "KTV-011", "Rối loạn nhịp nhẹ"),
                        new RecordService("Siêu âm tim", new DateTime(2026, 5, 20), "KTV-007", "Chức năng thất trái bảo tồn")
                    },
                    Prescriptions = new List<RecordPrescription>
                    {
                        new RecordPrescription(new DateTime(2026, 5, 21), "Amlodipine 5mg", "1 viên/ngày, uống sau khi ăn"),
                        new RecordPrescription(new DateTime(2026, 5, 21), "Bisoprolol 2.5mg", "1 viên/ngày, uống vào buổi sáng"),
                        new RecordPrescription(new DateTime(2026, 5, 21), "Aspirin 81mg", "1 viên/ngày, uống sau khi ăn")
                    }
                },
                new PatientMedicalRecord
                {
                    Id = "HSBA-0794",
                    PatientId = "BN-00341",
                    PatientName = "Nguyễn Văn An",
                    Date = new DateTime(2026, 3, 3),
                    Diagnosis = "Theo dõi huyết áp định kỳ",
                    Treatment = "Điều chỉnh liều dùng và tư vấn ăn nhạt",
                    DoctorId = "YS-012",
                    DoctorName = "Minh Khang",
                    DoctorRole = "Y sĩ",
                    DoctorGender = "Nam",
                    DoctorPhone = "0902223344",
                    Department = "Khoa Tim Mạch",
                    Conclusion = "Huyết áp ổn định hơn, tiếp tục theo dõi tại nhà",
                    Services = new List<RecordService>
                    {
                        new RecordService("Đo huyết áp", new DateTime(2026, 3, 3), "KTV-002", "140/88 mmHg"),
                        new RecordService("Xét nghiệm chức năng thận", new DateTime(2026, 3, 3), "KTV-004", "Không phát hiện bất thường")
                    },
                    Prescriptions = new List<RecordPrescription>
                    {
                        new RecordPrescription(new DateTime(2026, 3, 3), "Amlodipine 5mg", "1 viên/ngày"),
                        new RecordPrescription(new DateTime(2026, 3, 3), "Losartan 50mg", "1 viên/ngày")
                    }
                },
                new PatientMedicalRecord
                {
                    Id = "HSBA-0741",
                    PatientId = "BN-00341",
                    PatientName = "Nguyễn Văn An",
                    Date = new DateTime(2026, 1, 12),
                    Diagnosis = "Khám tim mạch tổng quát",
                    Treatment = "Khám lâm sàng, điện tim, xét nghiệm máu",
                    DoctorId = "BS-008",
                    DoctorName = "Hoàng Minh",
                    DoctorRole = "Bác sĩ",
                    DoctorGender = "Nam",
                    DoctorPhone = "0912345678",
                    Department = "Khoa Tim Mạch",
                    Conclusion = "Tình trạng ổn định, duy trì thuốc hiện tại",
                    Services = new List<RecordService>
                    {
                        new RecordService("Điện tim", new DateTime(2026, 1, 12), "KTV-011", "Nhịp xoang"),
                        new RecordService("Xét nghiệm máu", new DateTime(2026, 1, 12), "KTV-004", "Cholesterol hơi cao")
                    },
                    Prescriptions = new List<RecordPrescription>
                    {
                        new RecordPrescription(new DateTime(2026, 1, 12), "Amlodipine 5mg", "1 viên/ngày")
                    }
                }
            };
        }
    }

    public class RecordService
    {
        public RecordService(string type, DateTime date, string technicianId, string result)
        {
            Type = type;
            Date = date;
            TechnicianId = technicianId;
            Result = result;
        }

        public string Type { get; }
        public DateTime Date { get; }
        public string TechnicianId { get; }
        public string Result { get; }
    }

    public class RecordPrescription
    {
        public RecordPrescription(DateTime date, string medicineName, string dose)
        {
            Date = date;
            MedicineName = medicineName;
            Dose = dose;
        }

        public DateTime Date { get; }
        public string MedicineName { get; }
        public string Dose { get; }
    }
}
