using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace HospitalX.DAO
{
    public class NoticeDAO
    {
        private static NoticeDAO instance;
        public static NoticeDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new NoticeDAO();
                }
                return instance;
            }
            private set => instance = value;
        }

        private NoticeDAO() { }

        public DataTable GetNotifications()
        {
            string procName = "ADMINHOS.SP_GET_NOTIFICATIONS";
            OracleParameter[] parameters = new OracleParameter[]
            {
                new OracleParameter("p_cursor", OracleDbType.RefCursor) { Direction = ParameterDirection.Output }
            };
            return DataProvider.Instance.ExecuteQuery(procName, parameters, true);
        }
    }
}
