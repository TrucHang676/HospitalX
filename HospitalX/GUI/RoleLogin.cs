using Guna.UI2.WinForms;
using HospitalX.DAO;
using HospitalX.GUI.PH1;
using HospitalX.GUI.PH2;
using Oracle.ManagedDataAccess.Client;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace HospitalX.GUI
{
    public partial class RoleLogin : Form
    {
        private LoginRoleOption _role;
        private bool _isGoingBack = false;

        public RoleLogin()
            : this(CreateDesignerRole())
        {
        }

        public RoleLogin(LoginRoleOption role)
        {
            _role = role ?? CreateDesignerRole();
            InitializeComponent();
            this.FormClosed += RoleLogin_FormClosed;
            SetupBrandingAndIcons();
            ApplyRoleTheme();
            ApplyTestCredential();
        }

        private static LoginRoleOption CreateDesignerRole()
        {
            return new LoginRoleOption("PH2_DOCTOR", "Phân hệ 2", "Bác sĩ / Y sĩ", "Chẩn đoán và điều trị", LoginModule.Ph2, Color.FromArgb(20, 116, 91));
        }

        private void SetupBrandingAndIcons()
        {
            this.DoubleBuffered = true;

            // Load main hospital logo
            var logoImg = LoadImageSafely("logoHX4-Photoroom.png");
            if (logoImg != null)
            {
                ptbChuThap.Image = logoImg;
            }
            else
            {
                // Fallback circular cross drawing
                ptbChuThap.Paint += (s, e) =>
                {
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
            ptbRoleIcon.Paint += (s, e) =>
            {
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
            lblFormTitle.Text = "Đăng nhập";
            lblRoleName.Text = _role.Title;
            lblRoleDesc.Text = _role.Description;
            lblQTCSDLBV.Text = isPh1 ? "Quản trị CSDL Bệnh viện X" : "Hệ thống Nghiệp vụ Y tế";

            // Solid color separator bar – clean, no flashy gradient
            Color barColor = isPh1
                ? Color.FromArgb(100, 160, 220)   // Soft steel blue
                : Color.FromArgb(80, 180, 150);   // Soft sage green
            Line.FillColor = barColor;
            Line.FillColor2 = barColor;

            // Hospital brand label colors – clean white tones on dark background
            lblHospital.ForeColor = Color.FromArgb(200, 215, 230); // Soft light gray-blue
            lblQTCSDLBV.ForeColor = Color.White;
            lblRoleName.ForeColor = theme;

            // Solid white card – no frosted-glass transparency
            pnlRightCard.FillColor = Color.White;
            pnlRightCard.ShadowDecoration.Color = Color.FromArgb(160, 180, 200); // Neutral gray shadow

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
            btnLogin.ShadowDecoration.Color = Color.FromArgb(140, 160, 180); // Neutral subtle shadow

            // Back Button styling
            btnBack.ForeColor = theme;
            btnBack.BorderColor = theme;
            btnBack.HoverState.FillColor = isPh1
                ? Color.FromArgb(30, 37, 74, 132)   // semi-transparent blue
                : Color.FromArgb(30, 20, 116, 91);  // semi-transparent green

            // Center branding elements horizontally on the left panel
            ptbChuThap.Location = new Point((pnlLeft.Width - ptbChuThap.Width) / 2, ptbChuThap.Location.Y);
            lblHospital.Location = new Point((pnlLeft.Width - lblHospital.Width) / 2, lblHospital.Location.Y);
            lblQTCSDLBV.Location = new Point((pnlLeft.Width - lblQTCSDLBV.Width) / 2, lblQTCSDLBV.Location.Y);
            Line.Location = new Point((pnlLeft.Width - Line.Width) / 2, Line.Location.Y);

            // Force repaint
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

            Color theme = _role?.ThemeColor ?? Color.FromArgb(20, 116, 91);
            bool isPh1 = _role?.Module == LoginModule.Ph1;

            // Richer gradient with more visual depth
            Color color1, color2;
            if (isPh1)
            {
                color1 = Color.FromArgb(55, 115, 195);     // Lighter navy blue (top)
                color2 = Color.FromArgb(30, 70, 125);     // Soft deep blue (bottom)
            }
            else
            {
                color1 = Color.FromArgb(20, 108, 84);      // Forest green (top)
                color2 = Color.FromArgb(10, 58, 44);       // Deep forest (bottom)
            }

            // Clean rectangular background
            int separatorX = pnlRight != null ? pnlRight.Location.X : 390;
            Rectangle leftRect = new Rectangle(0, 0, separatorX, ClientRectangle.Height);
            using (var brush = new System.Drawing.Drawing2D.LinearGradientBrush(
                new Point(0, 0),
                new Point(leftRect.Width / 3, leftRect.Height),
                color1,
                color2))
            {
                g.FillRectangle(brush, leftRect);
            }

            // Subtle radial glow behind branding area for warmth & depth
            int glowW = (int)(leftRect.Width * 0.8f);
            int glowH = (int)(leftRect.Height * 0.45f);
            int glowX = (leftRect.Width - glowW) / 2;
            int glowY = (leftRect.Height - glowH) / 2;
            var glowRect = new Rectangle(glowX, glowY, glowW, glowH);
            using (var path = new System.Drawing.Drawing2D.GraphicsPath())
            {
                path.AddEllipse(glowRect);
                using (var glowBrush = new System.Drawing.Drawing2D.PathGradientBrush(path))
                {
                    glowBrush.CenterColor = Color.FromArgb(15, 255, 255, 255);
                    glowBrush.SurroundColors = new[] { Color.FromArgb(0, 255, 255, 255) };
                    g.FillPath(glowBrush, path);
                }
            }

            // Subtle right-edge separator
            using (var pen = new Pen(Color.FromArgb(25, 255, 255, 255), 1f))
            {
                g.DrawLine(pen, separatorX - 1, 0, separatorX - 1, ClientRectangle.Height);
            }
        }

        private void pnlLeft_Paint(object sender, PaintEventArgs e)
        {
            if (ptbChuThap != null && ptbChuThap.Visible)
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                // Calculate size and offsets dynamically based on scaled ptbChuThap.Width to preserve perfect proportions under High DPI scaling
                int circleSize = (int)Math.Round(ptbChuThap.Width * (76f / 56f));
                int padding = (circleSize - ptbChuThap.Width) / 2;
                int yOffset = (int)Math.Round(ptbChuThap.Width * (5f / 56f)); // Shift circle up slightly to compensate for logo's transparent bottom margin

                int circleX = ptbChuThap.Location.X - padding - 2;
                int circleY = ptbChuThap.Location.Y - padding - yOffset;

                // Perfect anti-aliased white circle
                using (var whiteBrush = new SolidBrush(Color.White))
                {
                    e.Graphics.FillEllipse(whiteBrush, circleX, circleY, circleSize, circleSize);
                }

                // Subtle light gray border around the circle
                using (var borderPen = new Pen(Color.FromArgb(220, 230, 240), 1f))
                {
                    e.Graphics.DrawEllipse(borderPen, circleX, circleY, circleSize - 1, circleSize - 1);
                }
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

                string u = txtUsername.Text.Trim().ToUpper();
                if ((u.StartsWith("DP") || u.StartsWith("BS") || u.StartsWith("KTV") || u.StartsWith("BN")) && txtPassword.Text == "123")
                {
                    txtPassword.Text = "Hos@123456";
                }
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
                txtPassword.IconRight = global::HospitalX.Properties.Resources.eye_close;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            _isGoingBack = true;
            Close();
        }

        private void ApplyTestCredential()
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
            {
                return;
            }

            string username;
            string password;
            if (!TryGetTestCredential(out username, out password))
            {
                return;
            }

            txtUsername.Text = username;
            txtPassword.Text = password;
        }

        private bool TryGetTestCredential(out string username, out string password)
        {
            username = null;
            password = "123";

            string key = _role?.Key;
            if (string.IsNullOrEmpty(key))
            {
                return false;
            }

            if (key == "PH1_DBA") username = "adminhos";
            else if (key == "PH2_DBA") username = "admin_ph2";
            else if (key == "PH2_COORDINATOR") username = "DP0001";
            else if (key == "PH2_DOCTOR") username = "BS0001";
            else if (key == "PH2_TECHNICIAN") username = "KTV001";
            else if (key == "PH2_PATIENT") username = "BN000001";

            if (username != null && (username.StartsWith("DP") || username.StartsWith("BS") || username.StartsWith("KTV") || username.StartsWith("BN")))
            {
                password = "Hos@123456";
            }

            return !string.IsNullOrEmpty(username);
        }

        private bool IsMockCredential(string username, string password, out string expectedUser)
        {
            expectedUser = null;

            string expectedPassword;
            if (!TryGetTestCredential(out expectedUser, out expectedPassword))
            {
                return false;
            }

            if (username.Equals(expectedUser, StringComparison.OrdinalIgnoreCase))
            {
                if (password == expectedPassword)
                {
                    return true;
                }
                if (expectedPassword == "Hos@123456" && password == "123")
                {
                    return true;
                }
            }
            return false;
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

            // Clear connection pools to ensure we authenticate physically against the DB,
            // preventing ADO.NET from reusing an existing session from the pool with an old password.
            OracleConnection.ClearAllPools();

            // Proceed with real Oracle database connection
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

                    if (_role.Key == "PH2_DBA" && !CurrentUserIsDba(conn))
                    {
                        ShowMessage("Tài khoản này không có quyền DBA để đăng nhập Phân hệ 2.", "Từ chối truy cập", MessageDialogIcon.Error);
                        return;
                    }

                    if (_role.Key == "PH2_PATIENT" && !CurrentUserHasRole(conn, "ROLE_BENHNHAN"))
                    {
                        ShowMessage("Tài khoản này không có vai trò Bệnh nhân trong hệ thống.", "Từ chối truy cập", MessageDialogIcon.Error);
                        return;
                    }

                    if (_role.Key == "PH2_TECHNICIAN" && !CurrentUserHasRole(conn, "ROLE_KYTHUATVIEN"))
                    {
                        ShowMessage("Tài khoản này không có vai trò Kỹ thuật viên trong hệ thống.", "Từ chối truy cập", MessageDialogIcon.Error);
                        return;
                    }

                    if (_role.Key == "PH2_DOCTOR")
                    {
                        string staffRole = GetCurrentUserStaffRole(conn);
                        if (staffRole != "Bác sĩ/Y sĩ")
                        {
                            ShowMessage("Tài khoản này không có vai trò Bác sĩ/Y sĩ trong hệ thống (Vai trò thực tế: " + (string.IsNullOrEmpty(staffRole) ? "Không xác định" : staffRole) + ").", "Từ chối truy cập", MessageDialogIcon.Error);
                            return;
                        }
                    }

                    if (_role.Key == "PH2_COORDINATOR")
                    {
                        string staffRole = GetCurrentUserStaffRole(conn);
                        if (staffRole != "Điều phối viên")
                        {
                            ShowMessage("Tài khoản này không có vai trò Điều phối viên trong hệ thống (Vai trò thực tế: " + (string.IsNullOrEmpty(staffRole) ? "Không xác định" : staffRole) + ").", "Từ chối truy cập", MessageDialogIcon.Error);
                            return;
                        }
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

        private void UpdateDatabaseProcedures(OracleConnection conn)
        {
            try
            {
                string sql = @"
CREATE OR REPLACE PROCEDURE SP_INSERT_PATIENT (
    p_mabn IN VARCHAR2,
    p_tenbn IN NVARCHAR2,
    p_phai IN NVARCHAR2,
    p_ngaysinh IN DATE,
    p_cccd IN VARCHAR2,
    p_sonha IN NVARCHAR2,
    p_tenduong IN NVARCHAR2,
    p_quanhuyen IN NVARCHAR2,
    p_tinhtp IN NVARCHAR2,
    p_tiensubenh IN NVARCHAR2,
    p_tiensubenhgd IN NVARCHAR2,
    p_diungthuoc IN NVARCHAR2
)
AUTHID DEFINER
AS
    v_count NUMBER;
    v_sql   VARCHAR2(1000);
BEGIN
    INSERT INTO ADMINHOS.BENHNHAN (
        MABN, TENBN, PHAI, NGAYSINH, CCCD, 
        SONHA, TENDUONG, QUANHUYEN, TINHTP, 
        TIENSUBENH, TIENSUBENHGD, DIUNGTHUOC
    ) VALUES (
        p_mabn, p_tenbn, p_phai, p_ngaysinh, p_cccd, 
        p_sonha, p_tenduong, p_quanhuyen, p_tinhtp, 
        p_tiensubenh, p_tiensubenhgd, p_diungthuoc
    );

    SELECT COUNT(*)
    INTO v_count
    FROM DBA_USERS
    WHERE USERNAME = UPPER(TRIM(p_mabn));

    IF v_count = 0 THEN
        v_sql := 'CREATE USER ' || UPPER(TRIM(p_mabn)) || ' IDENTIFIED BY ""123"" ACCOUNT UNLOCK';
        EXECUTE IMMEDIATE v_sql;
        v_sql := 'GRANT CREATE SESSION TO ' || UPPER(TRIM(p_mabn));
        EXECUTE IMMEDIATE v_sql;
        v_sql := 'GRANT ROLE_BENHNHAN TO ' || UPPER(TRIM(p_mabn));
        EXECUTE IMMEDIATE v_sql;
    END IF;

    COMMIT;
END;";
                using (var cmd = new OracleCommand(sql, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                // Cấp quyền thực thi stored procedure cho Bệnh nhân và Kỹ thuật viên
                string[] grantSqls = new string[]
                {
                    "GRANT EXECUTE ON ADMINHOS.SP_GET_HSBA_FOR_PATIENT TO ROLE_BENHNHAN",
                    "GRANT EXECUTE ON ADMINHOS.SP_GET_HSBA_DETAILS_BY_ID TO ROLE_BENHNHAN",
                    "GRANT EXECUTE ON ADMINHOS.SP_GET_SERVICES_FOR_HSBA TO ROLE_BENHNHAN",
                    "GRANT EXECUTE ON ADMINHOS.SP_GET_PRESCRIPTIONS_FOR_HSBA TO ROLE_BENHNHAN",
                    "GRANT EXECUTE ON ADMINHOS.SP_GET_NOTIFICATIONS TO ROLE_BENHNHAN",
                    "GRANT EXECUTE ON ADMINHOS.SP_GET_NOTIFICATIONS TO ROLE_KYTHUATVIEN",
                    "GRANT EXECUTE ON ADMINHOS.SP_GET_PROFILE TO ROLE_KYTHUATVIEN",
                    "GRANT EXECUTE ON ADMINHOS.SP_GET_PROFILE_STATS TO ROLE_KYTHUATVIEN",
                    "GRANT EXECUTE ON ADMINHOS.SP_UPDATE_PROFILE TO ROLE_KYTHUATVIEN"
                };
                foreach (var gSql in grantSqls)
                {
                    try
                    {
                        using (var cmd = new OracleCommand(gSql, conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Warning: Cannot execute grant: " + gSql + " - " + ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating database procedures and grants: " + ex.Message);
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

        private bool CurrentUserHasRole(OracleConnection conn, string roleName)
        {
            try
            {
                using (var cmd = new OracleCommand("SELECT COUNT(*) FROM USER_ROLE_PRIVS WHERE GRANTED_ROLE = :role", conn))
                {
                    cmd.Parameters.Add("role", OracleDbType.Varchar2).Value = roleName.ToUpper();
                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
            catch
            {
                return false;
            }
        }

        private string GetCurrentUserStaffRole(OracleConnection conn)
        {
            try
            {
                using (var cmd = new OracleCommand("SELECT VAITRO FROM ADMINHOS.VW_NHANVIEN_SELF", conn))
                {
                    object val = cmd.ExecuteScalar();
                    return val != null ? val.ToString().Trim() : "";
                }
            }
            catch
            {
                try
                {
                    using (var cmd = new OracleCommand("SELECT VAITRO FROM ADMINHOS.NHANVIEN WHERE MANV = SYS_CONTEXT('USERENV', 'SESSION_USER')", conn))
                    {
                        object val = cmd.ExecuteScalar();
                        return val != null ? val.ToString().Trim() : "";
                    }
                }
                catch
                {
                    return "";
                }
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
            _isGoingBack = true;
            Close();
        }

        private void RoleLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!_isGoingBack)
            {
                Application.Exit();
                Environment.Exit(0);
            }
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
