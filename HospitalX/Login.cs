using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace HospitalX
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
                new Point(420, 0),
                new Point(340, 540),
                new Point(0, 540)
            };
            using (var brush = new SolidBrush(ColorTranslator.FromHtml("#E2EEF7")))
                g.FillPolygon(brush, leftShape);

            Point[] accentLine = {
                new Point(418, 0),
                new Point(426, 0),
                new Point(346, 540),
                new Point(338, 540)
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

            // 1. Kiểm tra rỗng
            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
            {
                msgDialog.Icon = MessageDialogIcon.Warning;
                msgDialog.Buttons = MessageDialogButtons.OK;
                msgDialog.Caption = "Thông báo";
                msgDialog.Text = "Vui lòng nhập đầy đủ tài khoản và mật khẩu!";
                msgDialog.Show();
                return;
            }

            // 2. Logic "Tượng trưng" (Mock Logic)
            if (user == "admin" && pass == "admin")
            {
                string mockConnStr = "Data Source=MockServer;User Id=Admin;Password=admin;";

                msgDialog.Icon = MessageDialogIcon.Information;
                msgDialog.Buttons = MessageDialogButtons.OK;
                msgDialog.Caption = "Thành công";
                msgDialog.Text = "Đăng nhập thành công! Hệ thống đã sẵn sàng.";
                msgDialog.Show();

                // 3. Chuyển màn hình
                this.Hide();
                Main_PhanHe1 mainForm = new Main_PhanHe1(mockConnStr);
                mainForm.ShowDialog();
                this.Close();
            }
            else
            {
                msgDialog.Icon = MessageDialogIcon.Error;
                msgDialog.Buttons = MessageDialogButtons.OK;
                msgDialog.Caption = "Lỗi đăng nhập";
                msgDialog.Text = "Tên đăng nhập hoặc mật khẩu không chính xác!";
                msgDialog.Show();
            }
        }
    }
}