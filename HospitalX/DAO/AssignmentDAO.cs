using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace HospitalX.DAO
{
    public class AssignmentDAO
    {
        // Fetch all service requests with details
        public static DataTable GetAllServiceRequests()
        {
            string procName = "ADMINHOS.SP_GET_ALL_SERVICE_REQUESTS";
            OracleParameter[] parameters = new OracleParameter[]
            {
                new OracleParameter("p_cursor", OracleDbType.RefCursor) { Direction = ParameterDirection.Output }
            };

            return DataProvider.Instance.ExecuteQuery(procName, parameters, true);
        }

        // Fetch technicians and compute workload count
        public static DataTable GetAllTechnicians()
        {
            string procName = "ADMINHOS.SP_GET_ALL_TECHNICIANS";
            OracleParameter[] parameters = new OracleParameter[]
            {
                new OracleParameter("p_cursor", OracleDbType.RefCursor) { Direction = ParameterDirection.Output }
            };

            return DataProvider.Instance.ExecuteQuery(procName, parameters, true);
        }

        // Update technician assignment for a specific HSBA and service type
        public static bool AssignTechnician(string maHsba, string loaiDv, string maKtv)
        {
            string procName = "ADMINHOS.SP_ASSIGN_TECHNICIAN";
            OracleParameter[] parameters = new OracleParameter[]
            {
                new OracleParameter("p_mahsba", OracleDbType.Varchar2) { Value = maHsba.Trim() },
                new OracleParameter("p_loaidv", OracleDbType.NVarchar2) { Value = loaiDv.Trim() },
                new OracleParameter("p_maktv", OracleDbType.Varchar2) { Value = string.IsNullOrEmpty(maKtv) ? (object)DBNull.Value : maKtv.Trim() }
            };

            int result = DataProvider.Instance.ExecuteNonQuery(procName, parameters, true);
            return result > 0;
        }
    }
}
