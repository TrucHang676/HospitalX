using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace HospitalX.DAO
{
    public class AuditLogDAO
    {
        public static DataTable GetAuditLogs()
        {
            string sql = @"
            SELECT *
            FROM (
                SELECT
                    CAST('STANDARD' AS VARCHAR2(20)) AS LOAI_AUDIT,
                    CAST(USERNAME AS VARCHAR2(128)) AS USER_NAME,
                    CAST(OWNER AS VARCHAR2(128)) AS OWNER,
                    CAST(OBJ_NAME AS VARCHAR2(128)) AS DOI_TUONG,
                    CAST(ACTION_NAME AS VARCHAR2(50)) AS HANH_VI,
                    CAST(NULL AS VARCHAR2(128)) AS POLICY_NAME,
                    RETURNCODE AS MA_LOI,
                    CAST(
                        CASE
                            WHEN RETURNCODE = 0 THEN 'Thanh cong'
                            ELSE 'That bai'
                        END AS VARCHAR2(50)
                    ) AS KET_QUA,
                    TIMESTAMP AS THOI_GIAN,
                    CAST(NULL AS VARCHAR2(4000)) AS SQL_TEXT,
                    CAST(ACTION_NAME || ' ON ' || OBJ_NAME AS VARCHAR2(4000)) AS CHI_TIET,
                    CAST(TERMINAL AS VARCHAR2(128)) AS TERMINAL
                FROM DBA_AUDIT_TRAIL
                WHERE OWNER = 'ADMINHOS'
                AND OBJ_NAME IN (
                    'HSBA',
                    'DONTHUOC',
                    'HSBA_DV',
                    'VW_NHANVIEN_SELF',
                    'VW_BENHNHAN_SELF',
                    'SP_CAPNHAT_KETLUAN_HSBA',
                    'FN_DEM_DONTHUOC'
                )

                UNION ALL

                SELECT
                    CAST('FGA' AS VARCHAR2(20)) AS LOAI_AUDIT,
                    CAST(DB_USER AS VARCHAR2(128)) AS USER_NAME,
                    CAST(OBJECT_SCHEMA AS VARCHAR2(128)) AS OWNER,
                    CAST(OBJECT_NAME AS VARCHAR2(128)) AS DOI_TUONG,
                    CAST(STATEMENT_TYPE AS VARCHAR2(50)) AS HANH_VI,
                    CAST(POLICY_NAME AS VARCHAR2(128)) AS POLICY_NAME,
                    0 AS MA_LOI,
                    CAST(
                        CASE
                            WHEN POLICY_NAME LIKE '%BATHOPPHAP%' THEN 'Canh bao'
                            ELSE 'Ghi nhan FGA'
                        END AS VARCHAR2(50)
                    ) AS KET_QUA,
                    CAST(EXTENDED_TIMESTAMP AS DATE) AS THOI_GIAN,
                    CAST(SUBSTR(SQL_TEXT, 1, 4000) AS VARCHAR2(4000)) AS SQL_TEXT,
                    CAST(SUBSTR(SQL_TEXT, 1, 4000) AS VARCHAR2(4000)) AS CHI_TIET,
                    CAST(USERHOST AS VARCHAR2(128)) AS TERMINAL
                FROM DBA_FGA_AUDIT_TRAIL
                WHERE OBJECT_SCHEMA = 'ADMINHOS'
                AND POLICY_NAME IN (
                    'FGA_DONTHUOC_UPDATE',
                    'FGA_HSBA_UPDATE_HOPPHAP',
                    'FGA_HSBA_UPDATE_BATHOPPHAP',
                    'FGA_HSBA_DV_INSERT_BATHOPPHAP',
                    'FGA_HSBA_DV_UPD_DEL_BATHOPPHAP'
                )
            )
            ORDER BY THOI_GIAN DESC
            ";
            return DataProvider.Instance.ExecuteQuery(sql, null, false);
        }
    }
}
