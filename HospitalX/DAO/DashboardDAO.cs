using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace HospitalX.DAO
{
    public class DashboardDAO
    {
        // Dashboard Điều phối viên: số bệnh nhân, số HSBA hôm nay, số dịch vụ kỹ thuật
        public static DataTable GetDashboardDPV()
        {
            string sql = @"
                SELECT 
                    (SELECT COUNT(DISTINCT MAKTV) 
                     FROM ADMINHOS.HSBA_DV 
                     WHERE TRUNC(NGAYDV) = TRUNC(SYSDATE) AND MAKTV IS NOT NULL) AS ACTIVE_KTVS,

                    (SELECT COUNT(*) 
                     FROM ADMINHOS.HSBA_DV 
                     WHERE MAKTV IS NULL) AS PENDING_KTV,

                    (SELECT COUNT(*) 
                     FROM ADMINHOS.HSBA_DV 
                     WHERE KETQUA IS NOT NULL AND TRUNC(NGAYDV) = TRUNC(SYSDATE)) AS COMPLETED_SERVICES,

                    (SELECT COUNT(*) 
                     FROM ADMINHOS.VW_THONGBAO_APP
                     WHERE TRUNC(NGAYGIO) = TRUNC(SYSDATE)) AS TODAY_NOTICES
                FROM DUAL
            ";

            return DataProvider.Instance.ExecuteQuery(sql, null, false);
        }

        // Lấy danh sách bệnh nhân/dịch vụ cần phân công
        public static DataTable GetPatientsNeedAssignment()
        {
            string sql = @"
                SELECT 
                    DV.MAHSBA,
                    BN.TENBN AS TEN_BENH_NHAN,

                    COALESCE(
                        NV.CHUYENKHOA,
                        CASE HS.MAKHOA
                            WHEN 'KTH' THEN N'Khoa tiêu hóa'
                            WHEN 'KTK' THEN N'Khoa thần kinh'
                            WHEN 'KTM' THEN N'Khoa tim mạch'
                            ELSE N'Chưa xác định'
                        END
                    ) AS KHOA,

                    DV.LOAIDV AS DICH_VU_CAN

                FROM ADMINHOS.HSBA_DV DV
                JOIN ADMINHOS.HSBA HS 
                    ON DV.MAHSBA = HS.MAHSBA
                JOIN ADMINHOS.BENHNHAN BN 
                    ON HS.MABN = BN.MABN
                LEFT JOIN ADMINHOS.VW_NHANVIEN_DIEUPHOI NV 
                    ON HS.MABS = NV.MANV
                AND NV.VAITRO = N'Bác sĩ/Y sĩ'

                WHERE DV.MAKTV IS NULL
            ";

            return DataProvider.Instance.ExecuteQuery(sql, null, false);
        }

        // Dashboard Bác sĩ: hồ sơ bệnh án đang phụ trách, đang đợi phân KTV, đang chờ kết quả xét nghiệm, số thông báo hôm nay
        public static DataTable GetDashboardBS()
        {
            string sql = @"
                SELECT
                    (SELECT COUNT(*) FROM ADMINHOS.HSBA WHERE MABS = SYS_CONTEXT('USERENV', 'SESSION_USER')) AS MANAGED_HSBAS,
                    (SELECT COUNT(DISTINCT DV.MAHSBA)
                     FROM ADMINHOS.HSBA_DV DV
                     JOIN ADMINHOS.HSBA HS ON DV.MAHSBA = HS.MAHSBA
                     WHERE HS.MABS = SYS_CONTEXT('USERENV', 'SESSION_USER')
                       AND DV.MAKTV IS NULL) AS PENDING_KTV,
                    (SELECT COUNT(DISTINCT DV.MAHSBA)
                     FROM ADMINHOS.HSBA_DV DV
                     JOIN ADMINHOS.HSBA HS ON DV.MAHSBA = HS.MAHSBA
                     WHERE HS.MABS = SYS_CONTEXT('USERENV', 'SESSION_USER')
                       AND DV.MAKTV IS NOT NULL
                       AND (DV.KETQUA IS NULL OR DV.KETQUA = N'Chưa có kết quả')) AS PENDING_RESULTS,
                    (SELECT COUNT(*)
                     FROM ADMINHOS.VW_THONGBAO_APP
                     WHERE TRUNC(NGAYGIO) = TRUNC(SYSDATE)) AS TODAY_NOTICES
                FROM DUAL
            ";

            return DataProvider.Instance.ExecuteQuery(sql, null, false);
        }

        // Lấy danh sách hồ sơ bệnh án được lập trong tháng này của bác sĩ đăng nhập
        public static DataTable GetRecentHsbaThisMonth()
        {
            string sql = @"
                SELECT 
                    HS.MAHSBA,
                    BN.TENBN,
                    BN.MABN,
                    BN.PHAI,
                    FLOOR(MONTHS_BETWEEN(SYSDATE, BN.NGAYSINH) / 12) AS TUOI,
                    HS.NGAY,
                    HS.CHANDOAN
                FROM ADMINHOS.HSBA HS
                JOIN ADMINHOS.BENHNHAN BN ON HS.MABN = BN.MABN
                WHERE HS.MABS = SYS_CONTEXT('USERENV', 'SESSION_USER')
                  AND TRUNC(HS.NGAY, 'MM') = TRUNC(SYSDATE, 'MM')
                ORDER BY HS.NGAY DESC, HS.MAHSBA DESC
            ";

            return DataProvider.Instance.ExecuteQuery(sql, null, false);
        }

        // Lấy thông tin tổng quan của QTV: số tài khoản hoạt động, tổng số audit event, alert bất thường
        public static DataTable GetDashboardQTV()
        {
            string sql = @"
                SELECT
                    (SELECT COUNT(*) FROM ADMINHOS.NHANVIEN) + (SELECT COUNT(*) FROM ADMINHOS.BENHNHAN) AS ACTIVE_USERS,
                    
                    (SELECT COUNT(*) FROM DBA_AUDIT_TRAIL WHERE OWNER = 'ADMINHOS'
                     AND OBJ_NAME IN ('HSBA', 'DONTHUOC', 'HSBA_DV', 'VW_NHANVIEN_SELF', 'VW_BENHNHAN_SELF', 'SP_CAPNHAT_KETLUAN_HSBA', 'FN_DEM_DONTHUOC')) +
                    (SELECT COUNT(*) FROM DBA_FGA_AUDIT_TRAIL WHERE OBJECT_SCHEMA = 'ADMINHOS'
                     AND POLICY_NAME IN ('FGA_DONTHUOC_UPDATE', 'FGA_HSBA_UPDATE_HOPPHAP', 'FGA_HSBA_UPDATE_BATHOPPHAP', 'FGA_HSBA_DV_INSERT_BATHOPPHAP', 'FGA_HSBA_DV_UPD_DEL_BATHOPPHAP')) AS TOTAL_AUDIT,
                     
                    (SELECT COUNT(*) FROM DBA_AUDIT_TRAIL WHERE OWNER = 'ADMINHOS' AND RETURNCODE != 0
                     AND OBJ_NAME IN ('HSBA', 'DONTHUOC', 'HSBA_DV', 'VW_NHANVIEN_SELF', 'VW_BENHNHAN_SELF', 'SP_CAPNHAT_KETLUAN_HSBA', 'FN_DEM_DONTHUOC')) +
                    (SELECT COUNT(*) FROM DBA_FGA_AUDIT_TRAIL WHERE OBJECT_SCHEMA = 'ADMINHOS' AND POLICY_NAME LIKE '%BATHOPPHAP%') AS ABNORMAL_ALERTS
                FROM DUAL
            ";
            return DataProvider.Instance.ExecuteQuery(sql, null, false);
        }
    }
}