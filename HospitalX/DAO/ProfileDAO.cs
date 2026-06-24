using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace HospitalX.DAO
{
    public class ProfileDAO
    {
        private static ProfileDAO instance;
        public static ProfileDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ProfileDAO();
                }
                return instance;
            }
            private set => instance = value;
        }

        private ProfileDAO() { }

        public DataTable GetProfile()
        {
            string procName = "ADMINHOS.SP_GET_PROFILE";
            OracleParameter[] parameters = new OracleParameter[]
            {
                new OracleParameter("p_cursor", OracleDbType.RefCursor) { Direction = ParameterDirection.Output }
            };
            return DataProvider.Instance.ExecuteQuery(procName, parameters, true);
        }

        public DataTable GetProfileStats()
        {
            string procName = "ADMINHOS.SP_GET_PROFILE_STATS";
            OracleParameter[] parameters = new OracleParameter[]
            {
                new OracleParameter("p_cursor", OracleDbType.RefCursor) { Direction = ParameterDirection.Output }
            };
            return DataProvider.Instance.ExecuteQuery(procName, parameters, true);
        }


        public bool UpdateProfile(string phone, string address, string manv,
            string hoten, string phai, DateTime? ngaysinh, string cmnd, string vaitro, string chuyenkhoa, string coso)
        {
            string procName = "ADMINHOS.SP_UPDATE_PROFILE";
            OracleParameter[] parameters = new OracleParameter[]
            {
                new OracleParameter("p_sodt", OracleDbType.Varchar2) { Value = phone },
                new OracleParameter("p_quequan", OracleDbType.NVarchar2) { Value = address },
                new OracleParameter("p_manv", OracleDbType.Varchar2) { Value = manv },
                new OracleParameter("p_hoten", OracleDbType.NVarchar2) { Value = hoten },
                new OracleParameter("p_phai", OracleDbType.NVarchar2) { Value = phai },
                new OracleParameter("p_ngaysinh", OracleDbType.Date) { Value = (object)ngaysinh ?? DBNull.Value },
                new OracleParameter("p_cmnd", OracleDbType.Varchar2) { Value = cmnd },
                new OracleParameter("p_vaitro", OracleDbType.NVarchar2) { Value = vaitro },
                new OracleParameter("p_chuyenkhoa", OracleDbType.NVarchar2) { Value = string.IsNullOrEmpty(chuyenkhoa) ? (object)DBNull.Value : chuyenkhoa },
                new OracleParameter("p_coso", OracleDbType.NVarchar2) { Value = string.IsNullOrEmpty(coso) ? (object)DBNull.Value : coso }
            };
            int result = DataProvider.Instance.ExecuteNonQuery(procName, parameters, true);
            return result > 0;
        }
    }
}
