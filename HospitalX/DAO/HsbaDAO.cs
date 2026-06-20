using System;
using System.Data;
using System.Collections.Generic;
using Oracle.ManagedDataAccess.Client;
using HospitalX.GUI.PH2.BacSi;

namespace HospitalX.DAO
{
    public class HsbaDAO
    {
        public static string GetNextHsbaId()
        {
            string sql = "SELECT ADMINHOS.PKG_VPD_YC1C3.FN_GET_NEXT_HSBA_ID() FROM DUAL";
            DataTable dt = DataProvider.Instance.ExecuteQuery(sql, null, false);
            return dt.Rows[0][0].ToString().Trim();
        }

        public static bool InsertHsba(
            string maHsba, string maBn, DateTime ngay, string chanDoan,
            string dieuTri, string maBs, string maKhoa, string ketLuan)
        {
            string procName = "ADMINHOS.SP_INSERT_HSBA";
            OracleParameter[] parameters = new OracleParameter[]
            {
                new OracleParameter("p_mahsba", OracleDbType.Varchar2) { Value = maHsba.Trim() },
                new OracleParameter("p_mabn", OracleDbType.Varchar2) { Value = maBn.Trim() },
                new OracleParameter("p_ngay", OracleDbType.Date) { Value = ngay },
                new OracleParameter("p_chandoan", OracleDbType.NVarchar2) { Value = string.IsNullOrWhiteSpace(chanDoan) ? (object)DBNull.Value : chanDoan.Trim() },
                new OracleParameter("p_dieutri", OracleDbType.NVarchar2) { Value = string.IsNullOrWhiteSpace(dieuTri) ? (object)DBNull.Value : dieuTri.Trim() },
                new OracleParameter("p_mabs", OracleDbType.Varchar2) { Value = string.IsNullOrWhiteSpace(maBs) ? (object)DBNull.Value : maBs.Trim() },
                new OracleParameter("p_makhoa", OracleDbType.Varchar2) { Value = string.IsNullOrWhiteSpace(maKhoa) ? (object)DBNull.Value : maKhoa.Trim() },
                new OracleParameter("p_ketluan", OracleDbType.NVarchar2) { Value = string.IsNullOrWhiteSpace(ketLuan) ? (object)DBNull.Value : ketLuan.Trim() }
            };

            int result = DataProvider.Instance.ExecuteNonQuery(procName, parameters, true);
            return result > 0;
        }

        public static DataTable GetDoctorsForTaoHSBA(string specialty)
        {
            string procName = "ADMINHOS.SP_GET_DOCTORS_FOR_TAOHSBA";
            OracleParameter[] parameters = new OracleParameter[]
            {
                new OracleParameter("p_specialty", OracleDbType.NVarchar2) { Value = specialty.Trim() },
                new OracleParameter("p_cursor", OracleDbType.RefCursor) { Direction = ParameterDirection.Output }
            };
            return DataProvider.Instance.ExecuteQuery(procName, parameters, true);
        }

        public static DataTable GetDepartments()
        {
            string procName = "ADMINHOS.SP_GET_DEPARTMENTS";
            OracleParameter[] parameters = new OracleParameter[]
            {
                new OracleParameter("p_cursor", OracleDbType.RefCursor) { Direction = ParameterDirection.Output }
            };
            return DataProvider.Instance.ExecuteQuery(procName, parameters, true);
        }

        public static DataTable GetHsbaForDieuPhoi()
        {
            string procName = "ADMINHOS.SP_GET_HSBA_FOR_DIEUPHOI";
            OracleParameter[] parameters = new OracleParameter[]
            {
                new OracleParameter("p_cursor", OracleDbType.RefCursor) { Direction = ParameterDirection.Output }
            };
            return DataProvider.Instance.ExecuteQuery(procName, parameters, true);
        }

        public static bool UpdateHsbaDepartmentAndDoctor(string maHsba, string maKhoa, string maBs)
        {
            string procName = "ADMINHOS.SP_UPDATE_HSBA_DEPT_DOC";
            OracleParameter[] parameters = new OracleParameter[]
            {
                new OracleParameter("p_mahsba", OracleDbType.Varchar2) { Value = maHsba.Trim() },
                new OracleParameter("p_makhoa", OracleDbType.Varchar2) { Value = string.IsNullOrEmpty(maKhoa) ? (object)DBNull.Value : maKhoa.Trim() },
                new OracleParameter("p_mabs", OracleDbType.Varchar2) { Value = string.IsNullOrEmpty(maBs) ? (object)DBNull.Value : maBs.Trim() }
            };

            int result = DataProvider.Instance.ExecuteNonQuery(procName, parameters, true);
            return result > 0;
        }

        public static DataTable GetHsbaForDoctor()
        {
            string procName = "ADMINHOS.SP_GET_HSBA_FOR_DOCTOR";
            OracleParameter[] parameters = new OracleParameter[]
            {
                new OracleParameter("p_cursor", OracleDbType.RefCursor) { Direction = ParameterDirection.Output }
            };
            return DataProvider.Instance.ExecuteQuery(procName, parameters, true);
        }

        public static DataTable GetServicesForHsba(string maHsba)
        {
            string procName = "ADMINHOS.SP_GET_SERVICES_FOR_HSBA";
            OracleParameter[] parameters = new OracleParameter[]
            {
                new OracleParameter("p_mahsba", OracleDbType.Varchar2) { Value = maHsba.Trim() },
                new OracleParameter("p_cursor", OracleDbType.RefCursor) { Direction = ParameterDirection.Output }
            };
            return DataProvider.Instance.ExecuteQuery(procName, parameters, true);
        }

        public static bool DeleteHsbaService(string maHsba, string loaiDv, DateTime ngayDv)
        {
            string procName = "ADMINHOS.SP_DELETE_HSBA_SERVICE";
            OracleParameter[] parameters = new OracleParameter[]
            {
                new OracleParameter("p_mahsba", OracleDbType.Varchar2) { Value = maHsba.Trim() },
                new OracleParameter("p_loaidv", OracleDbType.NVarchar2) { Value = loaiDv.Trim() },
                new OracleParameter("p_ngaydv", OracleDbType.Date) { Value = ngayDv }
            };
            int result = DataProvider.Instance.ExecuteNonQuery(procName, parameters, true);
            return result > 0;
        }

        public static DataTable GetPrescriptionsForHsba(string maHsba)
        {
            string procName = "ADMINHOS.SP_GET_PRESCRIPTIONS_FOR_HSBA";
            OracleParameter[] parameters = new OracleParameter[]
            {
                new OracleParameter("p_mahsba", OracleDbType.Varchar2) { Value = maHsba.Trim() },
                new OracleParameter("p_cursor", OracleDbType.RefCursor) { Direction = ParameterDirection.Output }
            };
            return DataProvider.Instance.ExecuteQuery(procName, parameters, true);
        }

        public static bool UpdateHsbaDetails(string maHsba, string chanDoan, string dieuTri, string ketLuan)
        {
            string procName = "ADMINHOS.SP_UPDATE_HSBA_DETAILS";
            OracleParameter[] parameters = new OracleParameter[]
            {
                new OracleParameter("p_mahsba", OracleDbType.Varchar2) { Value = maHsba.Trim() },
                new OracleParameter("p_chandoan", OracleDbType.NVarchar2) { Value = string.IsNullOrWhiteSpace(chanDoan) ? (object)DBNull.Value : chanDoan.Trim() },
                new OracleParameter("p_dieutri", OracleDbType.NVarchar2) { Value = string.IsNullOrWhiteSpace(dieuTri) ? (object)DBNull.Value : dieuTri.Trim() },
                new OracleParameter("p_ketluan", OracleDbType.NVarchar2) { Value = string.IsNullOrWhiteSpace(ketLuan) ? (object)DBNull.Value : ketLuan.Trim() }
            };
            int result = DataProvider.Instance.ExecuteNonQuery(procName, parameters, true);
            return result > 0;
        }

        public static bool InsertHsbaService(string maHsba, string loaiDv, string ketQua)
        {
            string procName = "ADMINHOS.SP_INSERT_HSBA_SERVICE";
            OracleParameter[] parameters = new OracleParameter[]
            {
                new OracleParameter("p_mahsba", OracleDbType.Varchar2) { Value = maHsba.Trim() },
                new OracleParameter("p_loaidv", OracleDbType.NVarchar2) { Value = loaiDv.Trim() }
            };
            int result = DataProvider.Instance.ExecuteNonQuery(procName, parameters, true);
            return result > 0;
        }

        public static bool InsertDonThuoc(string maHsba, string tenThuoc, string lieuDung)
        {
            string procName = "ADMINHOS.SP_INSERT_DONTHUOC";
            OracleParameter[] parameters = new OracleParameter[]
            {
                new OracleParameter("p_mahsba", OracleDbType.Varchar2) { Value = maHsba.Trim() },
                new OracleParameter("p_tenthuoc", OracleDbType.NVarchar2) { Value = tenThuoc.Trim() },
                new OracleParameter("p_lieudung", OracleDbType.NVarchar2) { Value = string.IsNullOrWhiteSpace(lieuDung) ? (object)DBNull.Value : lieuDung.Trim() }
            };
            int result = DataProvider.Instance.ExecuteNonQuery(procName, parameters, true);
            return result > 0;
        }

        public static DataTable GetHsbaForPatient(string maBn)
        {
            string procName = "ADMINHOS.SP_GET_HSBA_FOR_PATIENT";
            OracleParameter[] parameters = new OracleParameter[]
            {
                new OracleParameter("p_mabn", OracleDbType.Varchar2) { Value = maBn.Trim() },
                new OracleParameter("p_cursor", OracleDbType.RefCursor) { Direction = ParameterDirection.Output }
            };
            return DataProvider.Instance.ExecuteQuery(procName, parameters, true);
        }

        public static ucHSBA.HsbaRecord GetHsbaDetailsById(string maHsba)
        {
            string procName = "ADMINHOS.SP_GET_HSBA_DETAILS_BY_ID";
            OracleParameter[] parameters = new OracleParameter[]
            {
                new OracleParameter("p_mahsba", OracleDbType.Varchar2) { Value = maHsba.Trim() },
                new OracleParameter("p_cursor", OracleDbType.RefCursor) { Direction = ParameterDirection.Output }
            };
            DataTable dt = DataProvider.Instance.ExecuteQuery(procName, parameters, true);
            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                var rec = new ucHSBA.HsbaRecord
                {
                    Id = row["MAHSBA"].ToString().Trim(),
                    PatientCode = row["MABN"].ToString().Trim(),
                    PatientName = row["TEN_BENH_NHAN"].ToString().Trim(),
                    Gender = row["GIOI_TINH"].ToString().Trim(),
                    BirthDate = row["NGAYSINH"] != DBNull.Value ? Convert.ToDateTime(row["NGAYSINH"]).ToString("dd/MM/yyyy") : "",
                    CreatedDate = row["NGAY"] != DBNull.Value ? Convert.ToDateTime(row["NGAY"]) : DateTime.Today,
                    CitizenId = row["CCCD"] != DBNull.Value ? row["CCCD"].ToString().Trim() : "",
                    Address = (row["SONHA"] != DBNull.Value ? row["SONHA"].ToString().Trim() + " " : "") +
                              (row["TENDUONG"] != DBNull.Value ? row["TENDUONG"].ToString().Trim() + ", " : "") +
                              (row["QUANHUYEN"] != DBNull.Value ? row["QUANHUYEN"].ToString().Trim() + ", " : "") +
                              (row["TINHTP"] != DBNull.Value ? row["TINHTP"].ToString().Trim() : ""),
                    Allergy = row["DIUNGTHUOC"] != DBNull.Value ? row["DIUNGTHUOC"].ToString().Trim() : "",
                    MedicalHistory = row["TIENSUBENH"] != DBNull.Value ? row["TIENSUBENH"].ToString().Trim() : "",
                    Diagnosis = row["CHANDOAN"] != DBNull.Value ? row["CHANDOAN"].ToString().Trim() : "",
                    Treatment = row["DIEUTRI"] != DBNull.Value ? row["DIEUTRI"].ToString().Trim() : "",
                    Conclusion = row["KETLUAN"] != DBNull.Value ? row["KETLUAN"].ToString().Trim() : "",
                    Department = row["MAKHOA"] != DBNull.Value ? row["MAKHOA"].ToString().Trim() : "",
                    Services = new List<string>(),
                    Prescriptions = new List<string>()
                };

                if (row["NGAYSINH"] != DBNull.Value)
                {
                    DateTime dob = Convert.ToDateTime(row["NGAYSINH"]);
                    rec.Age = DateTime.Today.Year - dob.Year;
                }

                DataTable dtServices = GetServicesForHsba(rec.Id);
                if (dtServices != null)
                {
                    foreach (DataRow sRow in dtServices.Rows)
                    {
                        string loai = sRow["LOAIDV"].ToString().Trim();
                        string kq = sRow["KETQUA"] != DBNull.Value ? sRow["KETQUA"].ToString().Trim() : "";
                        rec.Services.Add(loai + (!string.IsNullOrEmpty(kq) ? " - " + kq : ""));
                    }
                }

                DataTable dtRx = GetPrescriptionsForHsba(rec.Id);
                if (dtRx != null)
                {
                    foreach (DataRow rRow in dtRx.Rows)
                    {
                        string thuoc = rRow["TENTHUOC"].ToString().Trim();
                        string lieu = rRow["LIEUDUNG"] != DBNull.Value ? rRow["LIEUDUNG"].ToString().Trim() : "";
                        rec.Prescriptions.Add(thuoc + (!string.IsNullOrEmpty(lieu) ? " - " + lieu : ""));
                    }
                }

                return rec;
            }
            return null;
        }
    }
}
