using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace HospitalX.DAO
{
    public class DataProvider
    {
        // Chuỗi kết nối đến PDBHOSX
        private string connectionString = "User Id=ADMINHOS;Password=123;Data Source=localhost:1521/PDBHOSX;";

        // Lưu username hiện tại đang đăng nhập
        private string currentUser = "";
        public string CurrentUser
        {
            get { return currentUser; }
            set { currentUser = value; }
        }

        public string ConnectionString
        {
            get { return connectionString; }
        }

        private static DataProvider instance;
        public static DataProvider Instance
        {
            get { if (instance == null) instance = new DataProvider(); return instance; }
            private set => instance = value;
        }

        private DataProvider() { }

        // Cho phép gán chuỗi kết nối động từ mã (ví dụ từ form Login)
        public void SetConnectionString(string connStr)
        {
            if (!string.IsNullOrEmpty(connStr))
                connectionString = connStr;
        }

        // Hàm để lấy dữ liệu (Dùng cho USP_LIST_USERS, USP_LIST_ROLES...)
        public DataTable ExecuteQuery(string query, OracleParameter[] parameters = null, bool isStoredProc = true)
        {
            DataTable data = new DataTable();
            string connStr = connectionString;
            using (OracleConnection connection = new OracleConnection(connStr))
            {
                connection.Open();
                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    command.CommandType = isStoredProc ? CommandType.StoredProcedure : CommandType.Text;
                    command.BindByName = true;

                    if (parameters != null)
                        command.Parameters.AddRange(parameters);

                    using (OracleDataAdapter adapter = new OracleDataAdapter(command))
                    {
                        adapter.Fill(data);
                    }
                }
            }
            return data;
        }

        // Hàm để thực thi các lệnh Thêm/Xóa/Sửa (Dùng cho sp_CreateUser, SP_GRANT_PRIVILEGE...)
        public int ExecuteNonQuery(string query, OracleParameter[] parameters = null, bool isStoredProc = true)
        {
            int data = 0;
            string connStr = connectionString;
            using (OracleConnection connection = new OracleConnection(connStr))
            {
                connection.Open();
                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    command.CommandType = isStoredProc ? CommandType.StoredProcedure : CommandType.Text;
                    command.BindByName = true;

                    if (parameters != null)
                        command.Parameters.AddRange(parameters);

                    data = command.ExecuteNonQuery();
                    if (isStoredProc && data == -1)
                    {
                        data = 1; // Map -1 to 1 to represent successful execution of stored procedure for DAO success checks (result > 0)
                    }
                }
            }
            return data;
        }
    }
}
