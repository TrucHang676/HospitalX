using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace HospitalX.DAO
{
    public class PatientDAO
    {
        public static DataTable GetAllPatients()
        {
            string procName = "ADMINHOS.SP_GET_ALL_PATIENTS";
            OracleParameter[] parameters = new OracleParameter[]
            {
                new OracleParameter("p_cursor", OracleDbType.RefCursor) { Direction = ParameterDirection.Output }
            };
            return DataProvider.Instance.ExecuteQuery(procName, parameters, true);
        }

        public static DataTable SearchPatient(string query)
        {
            string procName = "ADMINHOS.SP_SEARCH_PATIENT";
            OracleParameter[] parameters = new OracleParameter[]
            {
                new OracleParameter("p_query", OracleDbType.Varchar2) { Value = query.Trim() },
                new OracleParameter("p_cursor", OracleDbType.RefCursor) { Direction = ParameterDirection.Output }
            };
            return DataProvider.Instance.ExecuteQuery(procName, parameters, true);
        }

        public static string GetNextPatientId()
        {
            // Gọi hàm Oracle trực tiếp qua SQL (hàm đã có sẵn trong schema ADMINHOS)
            string sql = "SELECT ADMINHOS.FN_GET_NEXT_PATIENT_ID() FROM DUAL";
            DataTable dt = DataProvider.Instance.ExecuteQuery(sql, null, false);
            if (dt != null && dt.Rows.Count > 0)
                return dt.Rows[0][0]?.ToString()?.Trim() ?? "";
            return "";
        }

        public static bool InsertPatient(
            string maBn, string tenBn, string phai, DateTime ngaySinh, string cccd,
            string soNha, string tenDuong, string quanHuyen, string tinhTp,
            string tienSuBenh, string tienSuBenhGd, string diUngThuoc)
        {
            string procName = "ADMINHOS.SP_INSERT_PATIENT";
            OracleParameter[] parameters = new OracleParameter[]
            {
                new OracleParameter("p_mabn", OracleDbType.Varchar2) { Value = maBn.Trim() },
                new OracleParameter("p_tenbn", OracleDbType.NVarchar2) { Value = tenBn.Trim() },
                new OracleParameter("p_phai", OracleDbType.NVarchar2) { Value = phai.Trim() },
                new OracleParameter("p_ngaysinh", OracleDbType.Date) { Value = ngaySinh },
                new OracleParameter("p_cccd", OracleDbType.Varchar2) { Value = string.IsNullOrWhiteSpace(cccd) ? (object)DBNull.Value : cccd.Trim() },
                new OracleParameter("p_sonha", OracleDbType.NVarchar2) { Value = string.IsNullOrWhiteSpace(soNha) ? (object)DBNull.Value : soNha.Trim() },
                new OracleParameter("p_tenduong", OracleDbType.NVarchar2) { Value = string.IsNullOrWhiteSpace(tenDuong) ? (object)DBNull.Value : tenDuong.Trim() },
                new OracleParameter("p_quanhuyen", OracleDbType.NVarchar2) { Value = string.IsNullOrWhiteSpace(quanHuyen) ? (object)DBNull.Value : quanHuyen.Trim() },
                new OracleParameter("p_tinhtp", OracleDbType.NVarchar2) { Value = string.IsNullOrWhiteSpace(tinhTp) ? (object)DBNull.Value : tinhTp.Trim() },
                new OracleParameter("p_tiensubenh", OracleDbType.NVarchar2) { Value = string.IsNullOrWhiteSpace(tienSuBenh) ? (object)DBNull.Value : tienSuBenh.Trim() },
                new OracleParameter("p_tiensubenhgd", OracleDbType.NVarchar2) { Value = string.IsNullOrWhiteSpace(tienSuBenhGd) ? (object)DBNull.Value : tienSuBenhGd.Trim() },
                new OracleParameter("p_diungthuoc", OracleDbType.NVarchar2) { Value = string.IsNullOrWhiteSpace(diUngThuoc) ? (object)DBNull.Value : diUngThuoc.Trim() }
            };
            return DataProvider.Instance.ExecuteNonQuery(procName, parameters, true) > 0;
        }

        public static bool UpdatePatient(
            string maBn, string tenBn, string phai, DateTime ngaySinh, string cccd,
            string soNha, string tenDuong, string quanHuyen, string tinhTp,
            string tienSuBenh, string tienSuBenhGd, string diUngThuoc)
        {
            string procName = "ADMINHOS.SP_UPDATE_PATIENT";
            OracleParameter[] parameters = new OracleParameter[]
            {
                new OracleParameter("p_mabn", OracleDbType.Varchar2) { Value = maBn.Trim() },
                new OracleParameter("p_tenbn", OracleDbType.NVarchar2) { Value = tenBn.Trim() },
                new OracleParameter("p_phai", OracleDbType.NVarchar2) { Value = phai.Trim() },
                new OracleParameter("p_ngaysinh", OracleDbType.Date) { Value = ngaySinh },
                new OracleParameter("p_cccd", OracleDbType.Varchar2) { Value = string.IsNullOrWhiteSpace(cccd) ? (object)DBNull.Value : cccd.Trim() },
                new OracleParameter("p_sonha", OracleDbType.NVarchar2) { Value = string.IsNullOrWhiteSpace(soNha) ? (object)DBNull.Value : soNha.Trim() },
                new OracleParameter("p_tenduong", OracleDbType.NVarchar2) { Value = string.IsNullOrWhiteSpace(tenDuong) ? (object)DBNull.Value : tenDuong.Trim() },
                new OracleParameter("p_quanhuyen", OracleDbType.NVarchar2) { Value = string.IsNullOrWhiteSpace(quanHuyen) ? (object)DBNull.Value : quanHuyen.Trim() },
                new OracleParameter("p_tinhtp", OracleDbType.NVarchar2) { Value = string.IsNullOrWhiteSpace(tinhTp) ? (object)DBNull.Value : tinhTp.Trim() },
                new OracleParameter("p_tiensubenh", OracleDbType.NVarchar2) { Value = string.IsNullOrWhiteSpace(tienSuBenh) ? (object)DBNull.Value : tienSuBenh.Trim() },
                new OracleParameter("p_tiensubenhgd", OracleDbType.NVarchar2) { Value = string.IsNullOrWhiteSpace(tienSuBenhGd) ? (object)DBNull.Value : tienSuBenhGd.Trim() },
                new OracleParameter("p_diungthuoc", OracleDbType.NVarchar2) { Value = string.IsNullOrWhiteSpace(diUngThuoc) ? (object)DBNull.Value : diUngThuoc.Trim() }
            };
            return DataProvider.Instance.ExecuteNonQuery(procName, parameters, true) > 0;
        }

        public static DataTable GetPatientsForDoctor()
        {
            string procName = "ADMINHOS.SP_GET_PATIENTS_FOR_DOCTOR";
            OracleParameter[] parameters = new OracleParameter[]
            {
                new OracleParameter("p_cursor", OracleDbType.RefCursor) { Direction = ParameterDirection.Output }
            };
            return DataProvider.Instance.ExecuteQuery(procName, parameters, true);
        }

        public static bool UpdatePatientHistory(string maBn, string allergy, string medicalHistory, string familyHistory)
        {
            string procName = "ADMINHOS.SP_UPDATE_PATIENT_HISTORY";
            OracleParameter[] parameters = new OracleParameter[]
            {
                new OracleParameter("p_mabn", OracleDbType.Varchar2) { Value = maBn.Trim() },
                new OracleParameter("p_allergy", OracleDbType.NVarchar2) { Value = string.IsNullOrWhiteSpace(allergy) ? (object)DBNull.Value : allergy.Trim() },
                new OracleParameter("p_medical_history", OracleDbType.NVarchar2) { Value = string.IsNullOrWhiteSpace(medicalHistory) ? (object)DBNull.Value : medicalHistory.Trim() },
                new OracleParameter("p_family_history", OracleDbType.NVarchar2) { Value = string.IsNullOrWhiteSpace(familyHistory) ? (object)DBNull.Value : familyHistory.Trim() }
            };
            return DataProvider.Instance.ExecuteNonQuery(procName, parameters, true) > 0;
        }
    }
}
