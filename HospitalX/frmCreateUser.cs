using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace HospitalX
{
    public partial class frmCreateUser : Form
    {
        public frmCreateUser()
        {
            InitializeComponent();
            // Common Label Style
            var labels = new[] { lblUserLabel, lblRoleLabel, lblFullNameLabel, lblPassLabel, lblConfirmPassLabel, lblTablespaceLabel };
            foreach (var l in labels)
            {
                l.Font = new Font("Segoe UI Semibold", 9F);
                l.ForeColor = Color.FromArgb(100, 110, 120);
                l.Margin = new Padding(0, 5, 0, 0);
                l.AutoSize = true;
            }

            // Fix centering
            this.msgDialog.Parent = this;
            this.msgDialog.Caption = "Thông báo";

            // Add mock roles
            cmbRole.Items.AddRange(new string[] { "ROLE_BACSI", "ROLE_DPV", "ROLE_KTV", "ROLE_BN" });
            cmbRole.StartIndex = 0;

            // Add mock tablespaces
            cmbTablespace.Items.AddRange(new string[] { "USERS", "SYSTEM", "SYSAUX", "TEMP" });
            cmbTablespace.StartIndex = 0;

            // Simple close behavior
            btnCancel.Click += (s, e) => this.Close();

            btnCreate.Click += (s, e) =>
            {
                // 1. Kiểm tra Username
                if (string.IsNullOrWhiteSpace(txtUsername.Text))
                {
                    msgDialog.Icon = MessageDialogIcon.Warning;
                    msgDialog.Show("Vui lòng nhập Username!", "Thiếu thông tin");
                    txtUsername.Focus();
                    return;
                }

                // 2. Kiểm tra Vai trò
                if (cmbRole.SelectedIndex < 0)
                {
                    msgDialog.Icon = MessageDialogIcon.Warning;
                    msgDialog.Show("Vui lòng chọn Vai trò!", "Thiếu thông tin");
                    return;
                }

                // 3. Kiểm tra Họ tên
                if (string.IsNullOrWhiteSpace(txtFullName.Text))
                {
                    msgDialog.Icon = MessageDialogIcon.Warning;
                    msgDialog.Show("Vui lòng nhập Họ tên nhân viên!", "Thiếu thông tin");
                    txtFullName.Focus();
                    return;
                }

                // 4. Kiểm tra Mật khẩu
                if (string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    msgDialog.Icon = MessageDialogIcon.Warning;
                    msgDialog.Show("Vui lòng nhập Mật khẩu!", "Thiếu thông tin");
                    txtPassword.Focus();
                    return;
                }

                // 5. Kiểm tra Xác nhận mật khẩu
                if (string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
                {
                    msgDialog.Icon = MessageDialogIcon.Warning;
                    msgDialog.Show("Vui lòng nhập Xác nhận mật khẩu!", "Thiếu thông tin");
                    txtConfirmPassword.Focus();
                    return;
                }

                // 6. Kiểm tra khớp mật khẩu
                if (txtPassword.Text != txtConfirmPassword.Text)
                {
                    msgDialog.Icon = MessageDialogIcon.Error;
                    msgDialog.Show("Mật khẩu xác nhận không khớp!", "Lỗi bảo mật");
                    return;
                }

                // Hiển thị thông báo thành công
                msgDialog.Icon = MessageDialogIcon.Information;
                msgDialog.Show($"Đã tạo thành công người dùng: {txtUsername.Text}", "Thành công");

                this.DialogResult = DialogResult.OK;
                this.Close();
            };
        }

        // Trick to move the borderless form
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                this.Capture = false;
                Message msg = Message.Create(this.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
                this.WndProc(ref msg);
            }
        }
    }
}
