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
