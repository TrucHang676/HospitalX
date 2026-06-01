using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace HospitalX.GUI.PH2.DieuPhoiVien
{
    public partial class frmDoiMatKhau : Form
    {
        private static readonly Color ThemeGreen = Color.FromArgb(15, 110, 86); // #0F6E56
        private static readonly Color BorderGray = Color.FromArgb(218, 232, 226); // #DAE8E2
        private static readonly Color TextDark = Color.FromArgb(24, 48, 42); // #18302A

        public frmDoiMatKhau()
        {
            InitializeComponent();
            DoubleBuffered = true;
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void frmDoiMatKhau_Load(object sender, EventArgs e)
        {
            SetupStyles();
        }

        private void SetupStyles()
        {
            // Panel top border styling
            pnlHeader.FillColor = ThemeGreen;
            lblTitle.BackColor = Color.Transparent;
            lblTitle.ForeColor = Color.White;
            lblTitle.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);

            // Cancel button
            btnCancel.BorderColor = ThemeGreen;
            btnCancel.BorderThickness = 1;
            btnCancel.FillColor = Color.Transparent;
            btnCancel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnCancel.ForeColor = ThemeGreen;
            btnCancel.HoverState.FillColor = Color.FromArgb(230, 244, 240);
            btnCancel.Cursor = Cursors.Hand;

            // Confirm button
            btnConfirm.FillColor = ThemeGreen;
            btnConfirm.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnConfirm.ForeColor = Color.White;
            btnConfirm.HoverState.FillColor = Color.FromArgb(10, 82, 64);
            btnConfirm.Cursor = Cursors.Hand;

            // Textboxes
            foreach (var txt in new[] { txtOldPass, txtNewPass, txtConfirmPass })
            {
                txt.PasswordChar = '•';
                txt.BorderRadius = 8;
                txt.BorderColor = BorderGray;
                txt.FocusedState.BorderColor = ThemeGreen;
                txt.Font = new Font("Segoe UI", 9.5F);
                txt.ForeColor = TextDark;
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string oldPass = txtOldPass.Text.Trim();
            string newPass = txtNewPass.Text.Trim();
            string confirmPass = txtConfirmPass.Text.Trim();

            if (string.IsNullOrEmpty(oldPass))
            {
                ShowMessage("Mật khẩu hiện tại không được bỏ trống.", "Lỗi nhập liệu", MessageDialogIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(newPass))
            {
                ShowMessage("Mật khẩu mới không được bỏ trống.", "Lỗi nhập liệu", MessageDialogIcon.Warning);
                return;
            }

            if (newPass.Length < 6)
            {
                ShowMessage("Mật khẩu mới phải có độ dài từ 6 ký tự trở lên.", "Lỗi nhập liệu", MessageDialogIcon.Warning);
                return;
            }

            if (confirmPass != newPass)
            {
                ShowMessage("Mật khẩu nhập lại không khớp với mật khẩu mới.", "Lỗi nhập liệu", MessageDialogIcon.Warning);
                return;
            }

            // Simulate change success
            ShowMessage("Đổi mật khẩu thành công!", "Thông báo", MessageDialogIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void ShowMessage(string message, string title, MessageDialogIcon icon)
        {
            if (Owner is Main_DPV mainDpv)
            {
                mainDpv.ShowMessage(message, title, icon);
            }
            else if (Form.ActiveForm is Main_DPV activeMainDpv)
            {
                activeMainDpv.ShowMessage(message, title, icon);
            }
            else
            {
                MessageBox.Show(message, title, MessageBoxButtons.OK, icon == MessageDialogIcon.Information ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
            }
        }
    }
}
