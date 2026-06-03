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
            SetupBrandingAndIcons();
            ApplyRoleTheme();
        }

        private static LoginRoleOption CreateDesignerRole()
        {
            return new LoginRoleOption("PH2_DOCTOR", "Phân hệ 2", "Bác sĩ / Y sĩ", "Chẩn đoán và điều trị", LoginModule.Ph2, Color.FromArgb(20, 116, 91));
        }

        private void SetupBrandingAndIcons()
        {
            this.DoubleBuffered = true;

            // Load main hospital logo
            var logoImg = LoadImageSafely("logoHX.png");
            if (logoImg != null)
            {
                ptbChuThap.Image = logoImg;
            }
            else
            {
                // Fallback circular cross drawing
                ptbChuThap.Paint += (s, e) => {
                    e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    Color theme = _role?.ThemeColor ?? Color.FromArgb(20, 116, 91);
                    using (var brush = new SolidBrush(theme))
                    {
                        e.Graphics.FillEllipse(brush, 2, 2, ptbChuThap.Width - 4, ptbChuThap.Height - 4);
                    }
                    using (var pen = new Pen(Color.White, 3))
                    {
                        int cx = ptbChuThap.Width / 2;
                        int cy = ptbChuThap.Height / 2;
                        e.Graphics.DrawLine(pen, cx - 8, cy, cx + 8, cy);
                        e.Graphics.DrawLine(pen, cx, cy - 8, cx, cy + 8);
                    }
                };
            }

            // Load user and padlock icons safely
            var userImg = LoadImageSafely("user.png");
            if (userImg != null) ptbIconTDN.Image = userImg;

            var passImg = LoadImageSafely("padlock.png");
            if (passImg != null) ptbIconPass.Image = passImg;

            // Setup dynamic vector icon for the role info card
            ptbRoleIcon.Paint += (s, e) => {
                Color theme = _role?.ThemeColor ?? Color.FromArgb(20, 116, 91);
                DrawVectorIcon(e.Graphics, ptbRoleIcon.Width, ptbRoleIcon.Height, _role.Key, theme);
            };
        }

        private void ApplyRoleTheme()
        {
            Color theme = _role.ThemeColor;
            bool isPh1 = _role.Module == LoginModule.Ph1;

            Text = "HospitalX - Đăng nhập " + _role.Title;

            // Setup dynamic text labels
            lblFormTitle.Text = "ĐĂNG NHẬP";
            lblRoleName.Text = _role.Title;
            lblRoleDesc.Text = _role.Description;
            lblQTCSDLBV.Text = isPh1 ? "Quản trị CSDL Bệnh viện X" : "Hệ thống Nghiệp vụ Y tế";

            // Update separator gradient (glowing modern capsule bar)
            if (isPh1)
            {
                Line.FillColor = Color.FromArgb(56, 189, 248);   // #38BDF8 (Vibrant light blue)
                Line.FillColor2 = theme;                         // #254A84 (Theme blue)
            }
            else
            {
                Line.FillColor = Color.FromArgb(52, 211, 153);   // #34D399 (Vibrant mint green)
                Line.FillColor2 = theme;                         // #14745B (Theme green)
            }
            Line.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;

            // Hospital brand label colors matching module theme
            lblHospital.ForeColor = isPh1 
                ? Color.FromArgb(147, 197, 253) // light blue (#93C5FD)
                : Color.FromArgb(167, 243, 208); // light green (#A7F3D0)
            lblQTCSDLBV.ForeColor = Color.White;
            lblRoleName.ForeColor = theme;

            // frosted-glass panel transparency
            pnlRightCard.FillColor = Color.FromArgb(242, 255, 255, 255); // 95% white opacity
            pnlRightCard.ShadowDecoration.Color = theme;

            // Load context-specific input icons
            if (isPh1)
            {
                var userImg = LoadImageSafely("user.png");
                if (userImg != null) ptbIconTDN.Image = userImg;

                var passImg = LoadImageSafely("padlock.png");
                if (passImg != null) ptbIconPass.Image = passImg;
            }
            else
            {
                var userImg = LoadImageSafely("userloginPH2.png");
                if (userImg != null) ptbIconTDN.Image = userImg;

                var passImg = LoadImageSafely("padlockPH2.png");
                if (passImg != null) ptbIconPass.Image = passImg;
            }

            // Input field focus/hover styles
            txtUsername.FocusedState.BorderColor = theme;
            txtUsername.HoverState.BorderColor = theme;
            txtPassword.FocusedState.BorderColor = theme;
            txtPassword.HoverState.BorderColor = theme;

            // Login Button styling
            btnLogin.FillColor = theme;
            btnLogin.HoverState.FillColor = ControlPaint.Light(theme, 0.15F);
            btnLogin.PressedColor = ControlPaint.Dark(theme, 0.10F);
            btnLogin.ShadowDecoration.Color = theme;

            // Back Button styling
            btnBack.ForeColor = theme;
            btnBack.BorderColor = theme;
            btnBack.HoverState.FillColor = isPh1 
                ? Color.FromArgb(30, 37, 74, 132)   // semi-transparent blue
                : Color.FromArgb(30, 20, 116, 91);  // semi-transparent green

            // Force repaint to draw the dynamic color-blended slanted background
            Invalidate();
        }

        private Color MixWithWhite(Color color, float percent)
        {
            int r = (int)(color.R + (255 - color.R) * percent);
            int g = (int)(color.G + (255 - color.G) * percent);
            int b = (int)(color.B + (255 - color.B) * percent);
            return Color.FromArgb(r, g, b);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Calculate gradient colors for left panel background
            Color theme = _role?.ThemeColor ?? Color.FromArgb(20, 116, 91);
            bool isPh1 = _role?.Module == LoginModule.Ph1;
            
            Color color1, color2, accentColor;
            if (isPh1)
            {
                color1 = Color.FromArgb(43, 85, 150);      // #2B5596 (Vibrant medium blue)
                color2 = Color.FromArgb(20, 42, 77);       // #142A4D (Dark blue)
                accentColor = Color.FromArgb(200, 56, 189, 248); // #38BDF8 (Vibrant sky blue) with 200 alpha
            }
            else
            {
                color1 = Color.FromArgb(21, 126, 99);      // #157E63 (Vibrant forest green)
                color2 = Color.FromArgb(10, 54, 42);       // #0A362A (Dark forest green)
                accentColor = Color.FromArgb(200, 52, 211, 153); // #34D399 (Vibrant mint green) with 200 alpha
            }

            Point[] leftShape = {
                new Point(0, 0),
                new Point(600, 0),
                new Point(450, ClientRectangle.Height),
                new Point(0, ClientRectangle.Height)
            };

            using (var brush = new System.Drawing.Drawing2D.LinearGradientBrush(
                new Point(0, 0),
                new Point(500, ClientRectangle.Height),
                color1,
                color2))
            {
                g.FillPolygon(brush, leftShape);
            }

            // Accent dividing line
            Point[] accentLine = {
                new Point(585, 0),
                new Point(605, 0),
                new Point(445, ClientRectangle.Height),
                new Point(435, ClientRectangle.Height)
            };
            using (var brush = new SolidBrush(accentColor))
                g.FillPolygon(brush, accentLine);

            // Draw modern geometric outline circles for dynamic depth (matching RoleSelection style)
            using (var pen = new Pen(Color.FromArgb(15, 255, 255, 255), 1.5f))
            {
                g.DrawEllipse(pen, -150, 100, 480, 480);
                g.DrawEllipse(pen, -100, 150, 380, 380);
                g.DrawEllipse(pen, 200, 350, 250, 250);
                g.DrawEllipse(pen, -50, 50, 580, 580);
            }
        }

        private void DrawVectorIcon(Graphics g, int w, int h, string roleKey, Color color)
        {
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            using (var pen = new Pen(color, 2))
            {
                string normalKey = "";
                if (roleKey.Equals("PH1_DBA", StringComparison.OrdinalIgnoreCase)) normalKey = "Ph1Dba";
                else if (roleKey.Equals("PH2_DBA", StringComparison.OrdinalIgnoreCase)) normalKey = "Ph2Dba";
                else if (roleKey.Equals("PH2_COORDINATOR", StringComparison.OrdinalIgnoreCase)) normalKey = "Coordinator";
                else if (roleKey.Equals("PH2_DOCTOR", StringComparison.OrdinalIgnoreCase)) normalKey = "Doctor";
                else if (roleKey.Equals("PH2_TECHNICIAN", StringComparison.OrdinalIgnoreCase)) normalKey = "Technician";
                else if (roleKey.Equals("PH2_PATIENT", StringComparison.OrdinalIgnoreCase)) normalKey = "Patient";

                if (normalKey == "Ph1Dba")
                {
                    // Cylinder Stack (Database)
                    int cx = w / 2;
                    int cy = h / 2;
                    g.DrawEllipse(pen, cx - 8, cy - 7, 16, 5);
                    g.DrawArc(pen, cx - 8, cy - 3, 16, 5, 0, 180);
                    g.DrawArc(pen, cx - 8, cy + 1, 16, 5, 0, 180);
                    g.DrawArc(pen, cx - 8, cy + 5, 16, 5, 0, 180);
                    g.DrawLine(pen, cx - 8, cy - 4.5f, cx - 8, cy + 7.5f);
                    g.DrawLine(pen, cx + 8, cy - 4.5f, cx + 8, cy + 7.5f);
                }
                else if (normalKey == "Ph2Dba")
                {
                    // Cogwheel (System Settings)
                    int cx = w / 2;
                    int cy = h / 2;
                    g.DrawEllipse(pen, cx - 4, cy - 4, 8, 8);
                    for (int i = 0; i < 8; i++)
                    {
                        double angle = i * Math.PI / 4;
                        float x1 = (float)(cx + Math.Cos(angle) * 4);
                        float y1 = (float)(cy + Math.Sin(angle) * 4);
                        float x2 = (float)(cx + Math.Cos(angle) * 8);
                        float y2 = (float)(cy + Math.Sin(angle) * 8);
                        g.DrawLine(pen, x1, y1, x2, y2);
                    }
                }
                else if (normalKey == "Coordinator")
                {
                    // Checklist / Clipboard
                    int x = (w - 12) / 2;
                    int y = (h - 16) / 2;
                    g.DrawRectangle(pen, x, y + 2, 12, 14);
                    g.DrawRectangle(pen, x + 3, y, 6, 3);
                    using (var thinPen = new Pen(color, 1.5f))
                    {
                        g.DrawLine(thinPen, x + 3, y + 6, x + 9, y + 6);
                        g.DrawLine(thinPen, x + 3, y + 10, x + 9, y + 10);
                        g.DrawLine(thinPen, x + 3, y + 13, x + 9, y + 13);
                    }
                }
                else if (normalKey == "Doctor")
                {
                    // Medical Cross
                    int cx = w / 2;
                    int cy = h / 2;
                    var path = new System.Drawing.Drawing2D.GraphicsPath();
                    path.AddPolygon(new PointF[] {
                        new PointF(cx - 2, cy - 7),
                        new PointF(cx + 2, cy - 7),
                        new PointF(cx + 2, cy - 2),
                        new PointF(cx + 7, cy - 2),
                        new PointF(cx + 7, cy + 2),
                        new PointF(cx + 2, cy + 2),
                        new PointF(cx + 2, cy + 7),
                        new PointF(cx - 2, cy + 7),
                        new PointF(cx - 2, cy + 2),
                        new PointF(cx - 7, cy + 2),
                        new PointF(cx - 7, cy - 2),
                        new PointF(cx - 2, cy - 2)
                    });
                    g.DrawPath(pen, path);
                }
                else if (normalKey == "Technician")
                {
                    // Science Beaker (Flask)
                    int cx = w / 2;
                    int cy = h / 2;
                    g.DrawLine(pen, cx - 3, cy - 7, cx + 3, cy - 7);
                    g.DrawLine(pen, cx - 2, cy - 7, cx - 2, cy - 3);
                    g.DrawLine(pen, cx + 2, cy - 7, cx + 2, cy - 3);
                    g.DrawLine(pen, cx - 2, cy - 3, cx - 7, cy + 5);
                    g.DrawLine(pen, cx + 2, cy - 3, cx + 7, cy + 5);
                    g.DrawLine(pen, cx - 7, cy + 5, cx + 7, cy + 5);
                    using (var thinPen = new Pen(color, 1.5f))
                    {
                        g.DrawLine(thinPen, cx - 5, cy + 2, cx + 5, cy + 2);
                    }
                }
                else if (normalKey == "Patient")
                {
                    // User silhouette
                    int cx = w / 2;
                    int cy = h / 2;
                    g.DrawEllipse(pen, cx - 4, cy - 7, 8, 8);
                    g.DrawArc(pen, cx - 8, cy + 2, 16, 10, 180, 180);
                    g.DrawLine(pen, cx - 8, cy + 7, cx + 8, cy + 7);
                }
            }
        }

        private void txtPassword_IconRightClick(object sender, EventArgs e)
        {
            if (txtPassword.UseSystemPasswordChar)
            {
                txtPassword.UseSystemPasswordChar = false;
                txtPassword.IconRight = global::HospitalX.Properties.Resources.eye_open;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
                txtPassword.IconRight = global::HospitalX.Properties.Resources.eye_close;
            }
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
            else if (_role.Key == "PH2_PATIENT")
            {
                mainForm = new Main_BN();
            }
            else if (_role.Key == "PH2_TECHNICIAN")
            {
                mainForm = new Main_KTV();
            }
            else if (_role.Key == "PH2_DBA")
            {
                mainForm = new Main_QTV();
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

        private Image LoadImageSafely(string filename)
        {
            try
            {
                string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                
                // Traverse up to find the "image" folder dynamically (portable support)
                string currentDir = baseDir;
                for (int i = 0; i < 5; i++)
                {
                    if (string.IsNullOrEmpty(currentDir)) break;
                    string checkPath = System.IO.Path.Combine(currentDir, "image");
                    if (System.IO.Directory.Exists(checkPath))
                    {
                        string filePath = System.IO.Path.Combine(checkPath, filename);
                        if (System.IO.File.Exists(filePath))
                        {
                            return Image.FromFile(filePath);
                        }
                    }
                    currentDir = System.IO.Path.GetDirectoryName(currentDir);
                }
            }
            catch { }
            return null;
        }
    }
}
