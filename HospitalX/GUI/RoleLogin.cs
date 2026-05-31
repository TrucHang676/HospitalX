using Guna.UI2.WinForms;
using HospitalX.DAO;
using HospitalX.GUI.PH1;
using HospitalX.GUI.PH2;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace HospitalX.GUI
{
    public partial class RoleLogin : Form
    {
        private LoginRoleOption _role;

        public RoleLogin()
            : this(CreateDesignerRole())
        {
        }

        public RoleLogin(LoginRoleOption role)
        {
            _role = role ?? CreateDesignerRole();
            InitializeComponent();
            ApplyRoleTheme();
        }

        private static LoginRoleOption CreateDesignerRole()
        {
            return new LoginRoleOption("PH2_DOCTOR", "Phân hệ 2", "Bác sĩ / Y sĩ", "Chẩn đoán & điều trị", LoginModule.Ph2, Color.FromArgb(48, 121, 88));
        }

        private void ApplyRoleTheme()
        {
            Color theme = _role.ThemeColor;
            bool isPh1 = _role.Module == LoginModule.Ph1;

            Text = "HospitalX - Đăng nhập " + _role.Title;
            pnlHeader.FillColor = theme;
            btnLogin.FillColor = theme;
            btnLogin.HoverState.FillColor = ControlPaint.Light(theme, 0.12F);
            btnBack.ForeColor = theme;
            btnBack.FillColor = isPh1 ? Color.FromArgb(230, 239, 250) : Color.FromArgb(224, 243, 236);
            btnBack.HoverState.FillColor = isPh1 ? Color.FromArgb(215, 230, 248) : Color.FromArgb(209, 236, 226);
            txtUsername.FocusedState.BorderColor = theme;
            txtUsername.HoverState.BorderColor = theme;
            txtPassword.FocusedState.BorderColor = theme;
            txtPassword.HoverState.BorderColor = theme;
            lblModuleSubtitle.Text = isPh1 ? "Quản trị CSDL Oracle" : "Quản lý dữ liệu y tế";
            lblRoleBadge.Text = "  " + _role.Title;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                ShowMessage("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu.", "Thiếu thông tin", MessageDialogIcon.Warning);
                return;
            }

            string connStr = BuildConnectionString(username, password);

            try
            {
                using (var conn = new OracleConnection(connStr))
                {
                    conn.Open();

                    if (_role.Key == "PH1_DBA" && !CurrentUserIsDba(conn))
                    {
                        ShowMessage("Tài khoản này không có quyền DBA để đăng nhập Phân hệ 1.", "Từ chối truy cập", MessageDialogIcon.Error);
                        return;
                    }
                }

                DataProvider.Instance.SetConnectionString(connStr);
                DataProvider.Instance.CurrentUser = username;
                OpenMainForm(connStr);
            }
            catch (OracleException ex)
            {
                ShowMessage("Kết nối Oracle thất bại: " + ex.Message, "Lỗi đăng nhập", MessageDialogIcon.Error);
            }
            catch (Exception ex)
            {
                ShowMessage("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageDialogIcon.Error);
            }
        }

        private string BuildConnectionString(string username, string password)
        {
            return "User Id=" + username + ";Password=" + password + ";Data Source=localhost:1521/PDBHOSX;";
        }

        private bool CurrentUserIsDba(OracleConnection conn)
        {
            using (var cmd = new OracleCommand("SELECT COUNT(*) FROM USER_ROLE_PRIVS WHERE GRANTED_ROLE = 'DBA'", conn))
            {
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

        private void OpenMainForm(string connStr)
        {
            Form mainForm = null;

            if (_role.Module == LoginModule.Ph1)
            {
                mainForm = new Main_PhanHe1(connStr);
            }
            else if (_role.Key == "PH2_COORDINATOR")
            {
                mainForm = new Main_DPV();
            }
            else if (_role.Key == "PH2_DOCTOR")
            {
                mainForm = new Main_BS();
            }
            else
            {
                ShowMessage("Giao diện cho vai trò \"" + _role.Title + "\" chưa được triển khai.", "Thông báo", MessageDialogIcon.Information);
                return;
            }

            Hide();
            using (mainForm)
            {
                mainForm.ShowDialog();
            }
            Close();
        }

        private void ShowMessage(string message, string caption, MessageDialogIcon icon)
        {
            msgDialog.Parent = this;
            msgDialog.Buttons = MessageDialogButtons.OK;
            msgDialog.Icon = icon;
            msgDialog.Caption = caption;
            msgDialog.Text = message;
            msgDialog.Show();
        }

    }
}
