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
                     FROM ADMINHOS.HSBA 
                     WHERE TRUNC(NGAY) = TRUNC(SYSDATE)) AS SO_HSBA_HOM_NAY
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
    }
}