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
            string sql = @"
                SELECT 
                    DV.MAHSBA,
                    BN.MABN AS MA_BENH_NHAN,
                    BN.TENBN AS TEN_BENH_NHAN,
                    DV.LOAIDV AS DICH_VU_CAN,
                    DV.NGAYDV AS NGAY_DICH_VU,
                    DV.KETQUA AS KET_QUA,
                    DV.MAKTV AS MA_KTV,
                    CASE 
                        WHEN DV.MAKTV IS NULL THEN N'Chưa phân công'
                        ELSE NV.HOTEN
                        END AS KTV_PHU_TRACH,
                    CASE 
                        WHEN DV.MAKTV IS NULL THEN N'Chờ phân công'
                        WHEN DV.KETQUA = N'Chưa có kết quả' THEN N'Đã phân công'
                        ELSE N'Hoàn thành'
                    END AS TRANG_THAI
                FROM ADMINHOS.HSBA_DV DV
                JOIN ADMINHOS.HSBA HS ON DV.MAHSBA = HS.MAHSBA
                JOIN ADMINHOS.BENHNHAN BN ON HS.MABN = BN.MABN
                LEFT JOIN ADMINHOS.VW_NHANVIEN_DIEUPHOI NV 
                    ON DV.MAKTV = NV.MANV 
                    AND NV.VAITRO = N'Kỹ thuật viên'
                ORDER BY DV.NGAYDV DESC, DV.MAHSBA DESC
            ";

            return DataProvider.Instance.ExecuteQuery(sql, null, false);
        }

        // Fetch technicians and compute workload count
        public static DataTable GetAllTechnicians()
        {
            string sql = @"
                SELECT 
                    NV.MANV,
                    NV.HOTEN,
                    NV.CHUYENKHOA
                FROM ADMINHOS.VW_NHANVIEN_DIEUPHOI NV
                WHERE NV.VAITRO = N'Kỹ thuật viên'
                ORDER BY NV.MANV ASC
            ";

            return DataProvider.Instance.ExecuteQuery(sql, null, false);
        }

        // Update technician assignment for a specific HSBA and service type
        public static bool AssignTechnician(string maHsba, string loaiDv, string maKtv)
        {
            string sql = @"
                UPDATE ADMINHOS.HSBA_DV 
                SET MAKTV = :maKtv 
                WHERE MAHSBA = :maHsba AND LOAIDV = :loaiDv
            ";

            OracleParameter[] parameters = new OracleParameter[]
            {
                new OracleParameter(":maKtv", OracleDbType.Varchar2) { Value = string.IsNullOrEmpty(maKtv) ? (object)DBNull.Value : maKtv },
                new OracleParameter(":maHsba", OracleDbType.Varchar2) { Value = maHsba },
                new OracleParameter(":loaiDv", OracleDbType.NVarchar2) { Value = loaiDv }
            };

            int result = DataProvider.Instance.ExecuteNonQuery(sql, parameters, false);
            return result > 0;
        }
    }
}
