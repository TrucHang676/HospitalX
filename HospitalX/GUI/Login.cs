using Guna.UI2.WinForms;
using HospitalX.DAO;
using HospitalX.GUI.PH1;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace HospitalX.GUI
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        // --- phần OnPaint và IconRightClick ---
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            Point[] leftShape = {
                new Point(0, 0),
                new Point(600, 0),
                new Point(450, 800),
                new Point(0, 800)
            };
            using (var brush = new SolidBrush(ColorTranslator.FromHtml("#E2EEF7")))
                g.FillPolygon(brush, leftShape);

            Point[] accentLine = {
                new Point(585, 0),
                new Point(605, 0),
                new Point(445, 800),
                new Point(435, 800)
            };
            using (var brush = new SolidBrush(ColorTranslator.FromHtml("#C8DAE8")))
                g.FillPolygon(brush, accentLine);
        }

        private void txtPassword_IconRightClick(object sender, System.EventArgs e)
        {
            if (txtPassword.UseSystemPasswordChar)
            {
                txtPassword.UseSystemPasswordChar = false;
                txtPassword.IconRight = Properties.Resources.eye_open;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
                txtPassword.IconRight = Properties.Resources.eye_close;
            }
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUsername.Text.Trim();
            string pass = txtPassword.Text.Trim();
            // Host and port are optional in UI; use defaults
            string host = "localhost";
            string port = "1521";
            string service = txtService.Text.Trim();

            // 1. Kiểm tra rỗng
            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass) || string.IsNullOrEmpty(service))
            {
                msgDialog.Icon = MessageDialogIcon.Warning;
                msgDialog.Buttons = MessageDialogButtons.OK;
                msgDialog.Caption = "Thông báo";
                msgDialog.Text = "Vui lòng nhập đầy đủ tài khoản, mật khẩu và service id!";
                msgDialog.Show();
                return;
            }

            // Clear connection pools to ensure we authenticate physically against the DB,
            // preventing ADO.NET from reusing an existing session from the pool with an old password.
            OracleConnection.ClearAllPools();

            string connStr = $"User Id={user};Password={pass};Data Source={host}:{port}/{service};";

            try
            {
                // Thử mở kết nối để kiểm tra thông tin đăng nhập
                using (var conn = new Oracle.ManagedDataAccess.Client.OracleConnection(connStr))
                {
                    conn.Open();

                    // Kiểm tra xem tài khoản có phải là DBA hay không, chỉ DBA mới được phép vào hệ thống này
                    string checkDbaSql = "SELECT COUNT(*) FROM USER_ROLE_PRIVS WHERE GRANTED_ROLE = 'DBA'";
                    using (var cmd = new OracleCommand(checkDbaSql, conn))
                    {
                        int isDba = Convert.ToInt32(cmd.ExecuteScalar());
                        if (isDba <= 0)
                        {
                            // Nếu không phải DBA, báo lỗi và "tiễn khách" ngay
                            msgDialog.Icon = MessageDialogIcon.Error;
                            msgDialog.Caption = "Từ chối truy cập";
                            msgDialog.Text = "Tài khoản của bạn không có quyền Quản trị (DBA) để vào hệ thống này!";
                            msgDialog.Show();
                            return; // Ngắt hàm login tại đây luôn
                        }
                    }

                    // Nếu mở được => hợp lệ
                    DataProvider.Instance.SetConnectionString(connStr);

                    msgDialog.Icon = MessageDialogIcon.Information;
                    msgDialog.Buttons = MessageDialogButtons.OK;
                    msgDialog.Caption = "Thành công";
                    msgDialog.Text = "Đăng nhập thành công! Kết nối tới Oracle đã được thiết lập.";
                    msgDialog.Show();

                    // Chuyển màn hình
                    this.Hide();
                    Main_PhanHe1 mainForm = new Main_PhanHe1(connStr);
                    mainForm.ShowDialog();
                    this.Close();
                }
            }
            catch (Oracle.ManagedDataAccess.Client.OracleException ex)
            {
                msgDialog.Icon = MessageDialogIcon.Error;
                msgDialog.Buttons = MessageDialogButtons.OK;
                msgDialog.Caption = "Lỗi kết nối";
                msgDialog.Text = "Kết nối thất bại: " + ex.Message;
                msgDialog.Show();
            }
            catch (Exception ex)
            {
                msgDialog.Icon = MessageDialogIcon.Error;
                msgDialog.Buttons = MessageDialogButtons.OK;
                msgDialog.Caption = "Lỗi";
                msgDialog.Text = "Đã xảy ra lỗi: " + ex.Message;
                msgDialog.Show();
            }
        }
    }
}