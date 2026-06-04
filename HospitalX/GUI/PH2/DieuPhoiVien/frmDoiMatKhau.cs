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

        private Image imgEyeOpen;
        private Image imgEyeClose;
        private Image imgEyeCloseDim;

        public frmDoiMatKhau()
        {
            InitializeComponent();
            DoubleBuffered = true;
            this.StartPosition = FormStartPosition.CenterParent;
            LoadEyeIcons();
        }

        private void frmDoiMatKhau_Load(object sender, EventArgs e)
        {
            SetupStyles();
        }

        private void LoadEyeIcons()
        {
            try
            {
                imgEyeOpen = DpvAssets.Load("eye_open.png");
                imgEyeClose = DpvAssets.Load("eye_close.png");
                imgEyeCloseDim = GetOpacityImage(imgEyeClose, 0.4f);
            }
            catch
            {
                // Fallback
            }
        }

        private Image GetOpacityImage(Image source, float opacity)
        {
            Bitmap bmp = new Bitmap(source.Width, source.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                System.Drawing.Imaging.ColorMatrix matrix = new System.Drawing.Imaging.ColorMatrix();
                matrix.Matrix33 = opacity;
                System.Drawing.Imaging.ImageAttributes attributes = new System.Drawing.Imaging.ImageAttributes();
                attributes.SetColorMatrix(matrix, System.Drawing.Imaging.ColorMatrixFlag.Default, System.Drawing.Imaging.ColorAdjustType.Bitmap);
                g.DrawImage(source, new Rectangle(0, 0, bmp.Width, bmp.Height), 0, 0, source.Width, source.Height, GraphicsUnit.Pixel, attributes);
            }
            return bmp;
        }

        private void SetupStyles()
        {
            // Panel top border styling
            pnlHeader.FillColor = ThemeGreen;
            lblTitle.BackColor = Color.Transparent;
            lblTitle.ForeColor = Color.White;
            lblTitle.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);

            // Confirm button
            btnConfirm.FillColor = ThemeGreen;
            btnConfirm.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnConfirm.ForeColor = Color.White;
            btnConfirm.HoverState.FillColor = Color.FromArgb(10, 82, 64);
            btnConfirm.Cursor = Cursors.Hand;
            btnConfirm.Enabled = false;

            // Textboxes
            foreach (var txt in new[] { txtOldPass, txtNewPass, txtConfirmPass })
            {
                txt.PasswordChar = '•';
                txt.BorderRadius = 8;
                txt.BorderColor = BorderGray;
                txt.FocusedState.BorderColor = ThemeGreen;
                txt.Font = new Font("Segoe UI", 9.5F);
                txt.ForeColor = TextDark;
                txt.TextChanged += UpdateConfirmButtonState;
                txt.IconRightOffset = new Point(8, 0);

                // Configure password eye visibility icon with initial dim state
                if (imgEyeCloseDim != null)
                {
                    txt.IconRight = imgEyeCloseDim;
                }
                else
                {
                    txt.IconRight = DpvAssets.Load("eye_close.png");
                }
                txt.IconRightCursor = Cursors.Hand;
                txt.IconRightSize = new Size(18, 18);
                txt.IconRightClick += txtPassword_IconRightClick;
            }
        }

        private void txtPassword_IconRightClick(object sender, EventArgs e)
        {
            if (sender is Guna2TextBox txt)
            {
                if (txt.PasswordChar == '•')
                {
                    txt.PasswordChar = '\0';
                    if (imgEyeOpen != null)
                    {
                        txt.IconRight = imgEyeOpen;
                    }
                    else
                    {
                        txt.IconRight = DpvAssets.Load("eye_open.png");
                    }
                }
                else
                {
                    txt.PasswordChar = '•';
                    if (imgEyeCloseDim != null)
                    {
                        txt.IconRight = imgEyeCloseDim;
                    }
                    else
                    {
                        txt.IconRight = DpvAssets.Load("eye_close.png");
                    }
                }
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

        private void UpdateConfirmButtonState(object sender, EventArgs e)
        {
            btnConfirm.Enabled = !string.IsNullOrWhiteSpace(txtOldPass.Text) &&
                                  !string.IsNullOrWhiteSpace(txtNewPass.Text) &&
                                  !string.IsNullOrWhiteSpace(txtConfirmPass.Text);
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
                using (var msgDialog = new Guna2MessageDialog())
                {
                    msgDialog.Parent = this;
                    msgDialog.Icon = icon;
                    msgDialog.Buttons = MessageDialogButtons.OK;
                    msgDialog.Caption = title;
                    msgDialog.Style = MessageDialogStyle.Light;
                    msgDialog.Show(message);
                }
            }
        }
    }
}
