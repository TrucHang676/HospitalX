using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace HospitalX.DAO
{
    public class HsbaDAO
    {
        public static string GetNextHsbaId()
        {
            string sql = @"
                SELECT NVL(MAX(TO_NUMBER(SUBSTR(MAHSBA, 5))), 0) + 1
                FROM ADMINHOS.HSBA
                WHERE MAHSBA LIKE 'HSBA%'
            ";

            DataTable dt = DataProvider.Instance.ExecuteQuery(sql, null, false);

            long nextNum = Convert.ToInt64(dt.Rows[0][0]);

            return "HSBA" + nextNum.ToString("D5");
        }

        public static bool InsertHsba(
            string maHsba, string maBn, DateTime ngay, string chanDoan,
            string dieuTri, string maBs, string maKhoa, string ketLuan)
        {
            string sql = @"
                INSERT INTO ADMINHOS.HSBA (
                    MAHSBA, MABN, NGAY, CHANDOAN, DIEUTRI, MABS, MAKHOA, KETLUAN
                ) VALUES (
                    :maHsba, :maBn, :ngay, :chanDoan, :dieuTri, :maBs, :maKhoa, :ketLuan
                )
            ";

            OracleParameter[] parameters = new OracleParameter[]
            {
                new OracleParameter(":maHsba", OracleDbType.Varchar2) { Value = maHsba.Trim() },
                new OracleParameter(":maBn", OracleDbType.Varchar2) { Value = maBn.Trim() },
                new OracleParameter(":ngay", OracleDbType.Date) { Value = ngay },
                new OracleParameter(":chanDoan", OracleDbType.NVarchar2) { Value = string.IsNullOrWhiteSpace(chanDoan) ? (object)DBNull.Value : chanDoan.Trim() },
                new OracleParameter(":dieuTri", OracleDbType.NVarchar2) { Value = string.IsNullOrWhiteSpace(dieuTri) ? (object)DBNull.Value : dieuTri.Trim() },
                new OracleParameter(":maBs", OracleDbType.Varchar2) { Value = string.IsNullOrWhiteSpace(maBs) ? (object)DBNull.Value : maBs.Trim() },
                new OracleParameter(":maKhoa", OracleDbType.Varchar2) { Value = string.IsNullOrWhiteSpace(maKhoa) ? (object)DBNull.Value : maKhoa.Trim() },
                new OracleParameter(":ketLuan", OracleDbType.NVarchar2) { Value = string.IsNullOrWhiteSpace(ketLuan) ? (object)DBNull.Value : ketLuan.Trim() }
            };

            int result = DataProvider.Instance.ExecuteNonQuery(sql, parameters, false);
            return result > 0;
        }

        public static DataTable GetDoctorsForTaoHSBA(string specialty)
        {
            string sql = @"
                SELECT MANV, HOTEN, CHUYENKHOA
                FROM ADMINHOS.VW_NHANVIEN_DIEUPHOI
                WHERE VAITRO = N'Bác sĩ/Y sĩ'
                  AND CHUYENKHOA = :specialty
                ORDER BY MANV ASC
            ";
            OracleParameter[] parameters = new OracleParameter[]
            {
                new OracleParameter(":specialty", OracleDbType.NVarchar2) { Value = specialty.Trim() }
            };
            return DataProvider.Instance.ExecuteQuery(sql, parameters, false);
        }

        public static DataTable GetDepartments()
        {
            string sql = @"
                SELECT DISTINCT CHUYENKHOA 
                FROM ADMINHOS.VW_NHANVIEN_DIEUPHOI 
                WHERE CHUYENKHOA IS NOT NULL 
                  AND VAITRO = N'Bác sĩ/Y sĩ'
                ORDER BY CHUYENKHOA ASC
            ";
            return DataProvider.Instance.ExecuteQuery(sql, null, false);
        }

        public static DataTable GetHsbaForDieuPhoi()
        {
            string sql = @"
                SELECT 
                    HS.MAHSBA,
                    HS.MABN,
                    BN.TENBN AS TEN_BENH_NHAN,
                    HS.NGAY,
                    HS.CHANDOAN,
                    HS.DIEUTRI,
                    HS.MABS,
                    HS.MAKHOA,
                    BS.HOTEN AS TEN_BACSI,
                    BS.CHUYENKHOA AS CHUYENKHOA_BACSI,
                    HS.KETLUAN
                FROM ADMINHOS.HSBA HS
                LEFT JOIN ADMINHOS.BENHNHAN BN
                    ON HS.MABN = BN.MABN
                LEFT JOIN ADMINHOS.VW_NHANVIEN_DIEUPHOI BS
                    ON HS.MABS = BS.MANV
                   AND TRIM(BS.VAITRO) = N'Bác sĩ/Y sĩ'
                WHERE HS.MABS IS NULL
                   OR BS.MANV IS NOT NULL
                ORDER BY HS.MAHSBA
            ";
            return DataProvider.Instance.ExecuteQuery(sql, null, false);
        }

        public static bool UpdateHsbaDepartmentAndDoctor(string maHsba, string maKhoa, string maBs)
        {
            string sql = @"
                UPDATE ADMINHOS.HSBA
                SET MAKHOA = :maKhoa,
                    MABS = :maBs
                WHERE MAHSBA = :maHsba
            ";

            OracleParameter[] parameters = new OracleParameter[]
            {
                new OracleParameter(":maKhoa", OracleDbType.Varchar2) { Value = string.IsNullOrEmpty(maKhoa) ? (object)DBNull.Value : maKhoa.Trim() },
                new OracleParameter(":maBs", OracleDbType.Varchar2) { Value = string.IsNullOrEmpty(maBs) ? (object)DBNull.Value : maBs.Trim() },
                new OracleParameter(":maHsba", OracleDbType.Varchar2) { Value = maHsba.Trim() }
            };

            int result = DataProvider.Instance.ExecuteNonQuery(sql, parameters, false);
            return result > 0;
        }
    }
}
