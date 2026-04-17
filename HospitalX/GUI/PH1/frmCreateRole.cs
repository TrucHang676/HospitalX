using System;
using System.Drawing;
using System.Windows.Forms;

namespace HospitalX.GUI.PH1
{
    public partial class frmCreateRole : Form
    {
        public string RoleName { get; private set; }
        public string AuthType { get; private set; }
        public string Password { get; private set; }

        public frmCreateRole()
        {
            InitializeComponent();
            
            // Link dialog to this form for centering
            this.msgDialog.Parent = this;
            this.msgDialog.Caption = "Thông báo";

            // Wire events
            this.cmbAuthType.SelectedIndexChanged += CmbAuthType_SelectedIndexChanged;
            this.btnCancel.Click += BtnCancel_Click;
            this.btnCreate.Click += BtnCreate_Click;
        }

        private void CmbAuthType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAuthType.SelectedItem.ToString() == "BY PASSWORD")
            {
                txtPassword.Enabled = true;
            }
            else
            {
                txtPassword.Enabled = false;
                txtPassword.Text = "";
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra Tên Role
            if (string.IsNullOrWhiteSpace(txtRoleName.Text))
            {
                msgDialog.Icon = Guna.UI2.WinForms.MessageDialogIcon.Warning;
                msgDialog.Show("Vui lòng nhập tên Role!", "Thiếu thông tin");
                txtRoleName.Focus();
                return;
            }

            // 2. Kiểm tra Kiểu xác thực
            if (cmbAuthType.SelectedIndex < 0)
            {
                msgDialog.Icon = Guna.UI2.WinForms.MessageDialogIcon.Warning;
                msgDialog.Show("Vui lòng chọn kiểu xác thực!", "Thiếu thông tin");
                return;
            }

            // 3. Kiểm tra Mật khẩu nếu chọn BY PASSWORD
            if (cmbAuthType.SelectedItem.ToString() == "BY PASSWORD" && string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                msgDialog.Icon = Guna.UI2.WinForms.MessageDialogIcon.Warning;
                msgDialog.Show("Vui lòng nhập mật khẩu xác thực cho Role!", "Thiếu thông tin");
                txtPassword.Focus();
                return;
            }

            // Lưu dữ liệu vào properties
            RoleName = txtRoleName.Text.Trim().ToUpper();
            AuthType = cmbAuthType.SelectedItem.ToString();
            Password = txtPassword.Text;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
