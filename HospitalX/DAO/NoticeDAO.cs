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
            string query = "SELECT MATB, NOIDUNG, NGAYGIO, DIADIEM, NHAN_OLS FROM ADMINHOS.VW_THONGBAO_APP ORDER BY NGAYGIO DESC";
            return DataProvider.Instance.ExecuteQuery(query, null, false);
        }
    }
}
