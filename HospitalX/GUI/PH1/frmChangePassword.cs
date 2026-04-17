using System;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace HospitalX.GUI.PH1
{
    public partial class frmChangePassword : Form
    {
        public string NewPassword { get; private set; }
        public string Username { get; private set; }

        private Image imgEyeOpen;
        private Image imgEyeClose;
        private Image imgEyeOpenDim;
        private Image imgEyeCloseDim;

        public frmChangePassword(string username)
        {
            InitializeComponent();
            
            // Fix centering
            this.msgDialog.Parent = this;
            
            this.Username = username;
            this.lblUsernameDisplay.Text = username;

            // Load icons & Init dimmed versions (Relative path support)
            try {
                // Thử tìm trong thư mục image song song với thư mục dự án
                string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                // Đi lên từ bin/Debug/ hoặc bin/Release/ để ra ngoài
                string imgPath = System.IO.Path.GetFullPath(System.IO.Path.Combine(baseDir, @"..\..\..\image\"));
                
                // Nếu chạy từ root hoặc thư mục khác, có thể thử thêm các đường dẫn dự phòng
                if (!System.IO.Directory.Exists(imgPath))
                    imgPath = System.IO.Path.GetFullPath(System.IO.Path.Combine(baseDir, @"image\"));

                imgEyeOpen = Image.FromFile(System.IO.Path.Combine(imgPath, "eye_open.png"));
                imgEyeClose = Image.FromFile(System.IO.Path.Combine(imgPath, "eye_close.png"));
                
                imgEyeOpenDim = GetOpacityImage(imgEyeOpen, 0.4f);
                imgEyeCloseDim = GetOpacityImage(imgEyeClose, 0.4f);

                txtNewPassword.IconRight = imgEyeCloseDim;
                txtConfirmPassword.IconRight = imgEyeCloseDim;
            } catch { }

            // Wire events
            this.btnCancel.Click += (s, e) => this.Close();
            this.btnConfirm.Click += BtnConfirm_Click;
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

        private void UpdateIcon(Guna2TextBox txt, bool isHover)
        {
            bool isVisible = (txt.PasswordChar == '\0');
            if (isVisible)
                txt.IconRight = isHover ? imgEyeOpen : imgEyeOpenDim;
            else
                txt.IconRight = isHover ? imgEyeClose : imgEyeCloseDim;
        }

        private void txtNewPassword_IconRightClick(object sender, EventArgs e)
        {
            txtNewPassword.PasswordChar = (txtNewPassword.PasswordChar == '●') ? '\0' : '●';
            UpdateIcon(txtNewPassword, true);
        }

        private void txtNewPassword_MouseMove(object sender, MouseEventArgs e)
        {
            // Check if mouse is over the icon area (Right side)
            bool isOverIcon = (e.X >= txtNewPassword.Width - 40); // 40 is safe margin for 20px icon + 10px offset
            UpdateIcon(txtNewPassword, isOverIcon);
        }

        private void txtNewPassword_MouseLeave(object sender, EventArgs e)
        {
            UpdateIcon(txtNewPassword, false);
        }

        private void txtConfirmPassword_IconRightClick(object sender, EventArgs e)
        {
            txtConfirmPassword.PasswordChar = (txtConfirmPassword.PasswordChar == '●') ? '\0' : '●';
            UpdateIcon(txtConfirmPassword, true);
        }

        private void txtConfirmPassword_MouseMove(object sender, MouseEventArgs e)
        {
            bool isOverIcon = (e.X >= txtConfirmPassword.Width - 40);
            UpdateIcon(txtConfirmPassword, isOverIcon);
        }

        private void txtConfirmPassword_MouseLeave(object sender, EventArgs e)
        {
            UpdateIcon(txtConfirmPassword, false);
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra mật khẩu mới
            if (string.IsNullOrWhiteSpace(txtNewPassword.Text))
            {
                msgDialog.Icon = MessageDialogIcon.Warning;
                msgDialog.Show("Vui lòng nhập mật khẩu mới!", "Thiếu thông tin");
                txtNewPassword.Focus();
                return;
            }

            // 2. Kiểm tra xác nhận mật khẩu
            if (string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
            {
                msgDialog.Icon = MessageDialogIcon.Warning;
                msgDialog.Show("Vui lòng nhập xác nhận mật khẩu!", "Thiếu thông tin");
                txtConfirmPassword.Focus();
                return;
            }

            // 3. Kiểm tra khớp mật khẩu
            if (txtNewPassword.Text != txtConfirmPassword.Text)
            {
                msgDialog.Icon = MessageDialogIcon.Error;
                msgDialog.Show("Mật khẩu xác nhận không khớp!", "Lỗi bảo mật");
                return;
            }

            // 4. Lưu dữ liệu
            NewPassword = txtNewPassword.Text;

            // 5. Xử lý đổi mật khẩu trong database
            try
            {
                var parameters = new Oracle.ManagedDataAccess.Client.OracleParameter[] {
                    new Oracle.ManagedDataAccess.Client.OracleParameter("p_username", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2, Username, System.Data.ParameterDirection.Input),
                    new Oracle.ManagedDataAccess.Client.OracleParameter("p_new_password", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2, NewPassword, System.Data.ParameterDirection.Input)
                };

                HospitalX.DAO.DataProvider.Instance.ExecuteNonQuery("sp_ChangeUserPassword", parameters);

                msgDialog.Icon = MessageDialogIcon.Information;
                msgDialog.Show($"Đã đổi mật khẩu cho người dùng {Username} thành công!", "Thành công");

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Oracle.ManagedDataAccess.Client.OracleException ex)
            {
                msgDialog.Icon = MessageDialogIcon.Error;
                msgDialog.Show("Lỗi khi đổi mật khẩu: " + ex.Message, "Lỗi");
            }
            catch (Exception ex)
            {
                msgDialog.Icon = MessageDialogIcon.Error;
                msgDialog.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi");
            }
        }

    }
}
