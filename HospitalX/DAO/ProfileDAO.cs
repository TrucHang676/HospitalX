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
            string query = "SELECT MANV, HOTEN, PHAI, NGAYSINH, CMND, QUEQUAN, SODT, VAITRO, CHUYENKHOA, COSO FROM ADMINHOS.VW_NHANVIEN_SELF";
            return DataProvider.Instance.ExecuteQuery(query, null, false);
        }

        public DataTable GetProfileStats()
        {
            string query = @"
                SELECT 
                    (SELECT COUNT(*) FROM ADMINHOS.HSBA) AS SO_HSBA,
                    (
                        SELECT COUNT(*) 
                        FROM ADMINHOS.HSBA_DV DV
                        JOIN ADMINHOS.HSBA HS ON DV.MAHSBA = HS.MAHSBA
                    ) AS SO_PHAN_CONG,
                    (SELECT COUNT(DISTINCT MABN) FROM ADMINHOS.HSBA) AS SO_BENH_NHAN
                FROM DUAL
            ";
            return DataProvider.Instance.ExecuteQuery(query, null, false);
        }


        public bool UpdateProfile(string phone, string address, string manv)
        {
            string query = "UPDATE ADMINHOS.VW_NHANVIEN_SELF SET SODT = :sodt , QUEQUAN = :quequan WHERE MANV = :manv";
            OracleParameter[] parameters = new OracleParameter[]
            {
                new OracleParameter("sodt", phone),
                new OracleParameter("quequan", address),
                new OracleParameter("manv", manv)
            };
            int result = DataProvider.Instance.ExecuteNonQuery(query, parameters, false);
            return result > 0;
        }
    }
}
