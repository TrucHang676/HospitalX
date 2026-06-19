using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace HospitalX.DAO
{
    public class PrescriptionDAO
    {
        public static DataTable GetPrescriptionsForDoctor()
        {
            string procName = "ADMINHOS.SP_GET_PRESCRIPTIONS_FOR_DOCTOR";
            OracleParameter[] parameters = new OracleParameter[]
            {
                new OracleParameter("p_cursor", OracleDbType.RefCursor) { Direction = ParameterDirection.Output }
            };
            return DataProvider.Instance.ExecuteQuery(procName, parameters, true);
        }

        public static bool InsertDrug(string maHsba, DateTime ngayDt, string tenThuoc, string lieuDung)
        {
            string procName = "ADMINHOS.SP_INSERT_DRUG";
            OracleParameter[] parameters = new OracleParameter[]
            {
                new OracleParameter("p_mahsba", OracleDbType.Varchar2) { Value = maHsba.Trim() },
                new OracleParameter("p_ngaydt", OracleDbType.Date) { Value = ngayDt },
                new OracleParameter("p_tenthuoc", OracleDbType.NVarchar2) { Value = tenThuoc.Trim() },
                new OracleParameter("p_lieudung", OracleDbType.NVarchar2) { Value = string.IsNullOrWhiteSpace(lieuDung) ? (object)DBNull.Value : lieuDung.Trim() }
            };
            return DataProvider.Instance.ExecuteNonQuery(procName, parameters, true) > 0;
        }

        public static bool UpdateDrug(string maHsba, DateTime ngayDt, string oldTenThuoc, string newTenThuoc, string newLieuDung)
        {
            string procName = "ADMINHOS.SP_UPDATE_DRUG";
            OracleParameter[] parameters = new OracleParameter[]
            {
                new OracleParameter("p_mahsba", OracleDbType.Varchar2) { Value = maHsba.Trim() },
                new OracleParameter("p_ngaydt", OracleDbType.Date) { Value = ngayDt },
                new OracleParameter("p_old_tenthuoc", OracleDbType.NVarchar2) { Value = oldTenThuoc.Trim() },
                new OracleParameter("p_new_tenthuoc", OracleDbType.NVarchar2) { Value = newTenThuoc.Trim() },
                new OracleParameter("p_new_lieudung", OracleDbType.NVarchar2) { Value = string.IsNullOrWhiteSpace(newLieuDung) ? (object)DBNull.Value : newLieuDung.Trim() }
            };
            return DataProvider.Instance.ExecuteNonQuery(procName, parameters, true) > 0;
        }

        public static bool DeleteDrug(string maHsba, DateTime ngayDt, string tenThuoc)
        {
            string procName = "ADMINHOS.SP_DELETE_DRUG";
            OracleParameter[] parameters = new OracleParameter[]
            {
                new OracleParameter("p_mahsba", OracleDbType.Varchar2) { Value = maHsba.Trim() },
                new OracleParameter("p_ngaydt", OracleDbType.Date) { Value = ngayDt },
                new OracleParameter("p_tenthuoc", OracleDbType.NVarchar2) { Value = tenThuoc.Trim() }
            };
            return DataProvider.Instance.ExecuteNonQuery(procName, parameters, true) > 0;
        }

        public static int GetPrescriptionCount(string maHsba)
        {
            string sql = "SELECT ADMINHOS.FN_DEM_DONTHUOC(:maHsba) FROM DUAL";
            OracleParameter[] parameters = new OracleParameter[]
            {
                new OracleParameter(":maHsba", OracleDbType.Varchar2) { Value = maHsba.Trim() }
            };
            DataTable dt = DataProvider.Instance.ExecuteQuery(sql, parameters, false);
            if (dt != null && dt.Rows.Count > 0)
            {
                return Convert.ToInt32(dt.Rows[0][0]);
            }
            return 0;
        }
    }
}
