using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace HospitalX.DAO
{
    public class AuditLogDAO
    {
        public static DataTable GetAuditLogs()
        {
            string procName = "ADMINHOS.SP_XEM_AUDIT_LOG";
            OracleParameter[] parameters = new OracleParameter[]
            {
                new OracleParameter("p_cursor", OracleDbType.RefCursor) { Direction = ParameterDirection.Output }
            };
            return DataProvider.Instance.ExecuteQuery(procName, parameters, true);
        }

        // ------------------------------------------------------------------
        // KHÔI PHỤC DỮ LIỆU DỰA VÀO NHẬT KÝ KIỂM TOÁN (FGA) - YÊU CẦU 4
        // ------------------------------------------------------------------

        // Danh sách sự cố bất hợp pháp được FGA phát hiện (HSBA / HSBA_DV / DONTHUOC).
        public static DataTable GetIncidentsFromAudit()
        {
            string procName = "ADMINHOS.SP_GET_SUCO_FROM_AUDIT";
            OracleParameter[] parameters = new OracleParameter[]
            {
                new OracleParameter("p_cursor", OracleDbType.RefCursor) { Direction = ParameterDirection.Output }
            };
            return DataProvider.Instance.ExecuteQuery(procName, parameters, true);
        }

        // Lịch sử các lần khôi phục đã chạy.
        public static DataTable GetRecoveryHistory()
        {
            string procName = "ADMINHOS.SP_GET_RECOVERY_HISTORY";
            OracleParameter[] parameters = new OracleParameter[]
            {
                new OracleParameter("p_cursor", OracleDbType.RefCursor) { Direction = ParameterDirection.Output }
            };
            return DataProvider.Instance.ExecuteQuery(procName, parameters, true);
        }

        // Khôi phục tự động toàn bộ dựa vào nhật ký kiểm toán FGA.
        // Trả về status/message qua tham số out; hàm trả về true nếu không lỗi.
        public static bool RunAutoRecoveryFromAudit(out string logId, out string status, out string message)
        {
            string procName = "ADMINHOS.SP_KHOIPHUC_TUDONG_THEO_AUDIT";

            OracleParameter pLogId = new OracleParameter("p_log_id", OracleDbType.Varchar2, 50)
            {
                Direction = ParameterDirection.Output
            };
            OracleParameter pStatus = new OracleParameter("p_status", OracleDbType.Varchar2, 20)
            {
                Direction = ParameterDirection.Output
            };
            OracleParameter pMessage = new OracleParameter("p_message", OracleDbType.Varchar2, 1000)
            {
                Direction = ParameterDirection.Output
            };

            OracleParameter[] parameters = new OracleParameter[] { pLogId, pStatus, pMessage };
            DataProvider.Instance.ExecuteNonQuery(procName, parameters, true);

            logId = pLogId.Value != null ? pLogId.Value.ToString() : "";
            status = pStatus.Value != null ? pStatus.Value.ToString() : "";
            message = pMessage.Value != null ? pMessage.Value.ToString() : "";

            return !string.Equals(status, "FAILED", StringComparison.OrdinalIgnoreCase);
        }
    }
}
