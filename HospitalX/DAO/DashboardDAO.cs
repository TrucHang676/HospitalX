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
            string procName = "ADMINHOS.SP_GET_DASHBOARD_DPV";
            OracleParameter[] parameters = new OracleParameter[]
            {
                new OracleParameter("p_cursor", OracleDbType.RefCursor) { Direction = ParameterDirection.Output }
            };
            return DataProvider.Instance.ExecuteQuery(procName, parameters, true);
        }

        // Lấy danh sách bệnh nhân/dịch vụ cần phân công
        public static DataTable GetPatientsNeedAssignment()
        {
            string procName = "ADMINHOS.SP_GET_PATIENTS_NEED_ASSIGNMENT";
            OracleParameter[] parameters = new OracleParameter[]
            {
                new OracleParameter("p_cursor", OracleDbType.RefCursor) { Direction = ParameterDirection.Output }
            };
            return DataProvider.Instance.ExecuteQuery(procName, parameters, true);
        }

        // Dashboard Bác sĩ: hồ sơ bệnh án đang phụ trách, đang đợi phân KTV, đang chờ kết quả xét nghiệm, số thông báo hôm nay
        public static DataTable GetDashboardBS()
        {
            string procName = "ADMINHOS.SP_GET_DASHBOARD_BS";
            OracleParameter[] parameters = new OracleParameter[]
            {
                new OracleParameter("p_cursor", OracleDbType.RefCursor) { Direction = ParameterDirection.Output }
            };
            return DataProvider.Instance.ExecuteQuery(procName, parameters, true);
        }

        // Lấy danh sách hồ sơ bệnh án được lập trong tháng này của bác sĩ đăng nhập
        public static DataTable GetRecentHsbaThisMonth()
        {
            string procName = "ADMINHOS.SP_GET_RECENT_HSBA_THIS_MONTH";
            OracleParameter[] parameters = new OracleParameter[]
            {
                new OracleParameter("p_cursor", OracleDbType.RefCursor) { Direction = ParameterDirection.Output }
            };
            return DataProvider.Instance.ExecuteQuery(procName, parameters, true);
        }

        // Lấy thông tin tổng quan của QTV: số tài khoản hoạt động, tổng số audit event, alert bất thường
        public static DataTable GetDashboardQTV()
        {
            string procName = "ADMINHOS.SP_GET_DASHBOARD_QTV";
            OracleParameter[] parameters = new OracleParameter[]
            {
                new OracleParameter("p_cursor", OracleDbType.RefCursor) { Direction = ParameterDirection.Output }
            };
            return DataProvider.Instance.ExecuteQuery(procName, parameters, true);
        }
    }
}