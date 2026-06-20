using System;
using System.Drawing;
using System.Windows.Forms;

namespace HospitalX.GUI
{
    public partial class RoleSelection : Form
    {
        private System.Collections.Generic.List<Action> _resetHoverActions = new System.Collections.Generic.List<Action>();

        public RoleSelection()
        {
            InitializeComponent();
            this.FormClosed += RoleSelection_FormClosed;
            SetupBrandingAndIcons();
            WireRoleButtons();
        }

        private void SetupBrandingAndIcons()
        {
            // Load and display main logo
            var logoImg = LoadImageSafely("logoHX4-Photoroom.png");
            if (logoImg != null)
            {
                picLeftLogo.Image = logoImg;
            }
            else
            {
                // Fallback logo drawing (white cross inside rounded gradient blue-green circle)
                picLeftLogo.Paint += (s, e) => {
                    e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    using (var brush = new System.Drawing.Drawing2D.LinearGradientBrush(
                        new Point(0, 0),
                        new Point(picLeftLogo.Width, picLeftLogo.Height),
                        Ph1Color,
                        Ph2Color))
                    {
                        e.Graphics.FillEllipse(brush, 2, 2, picLeftLogo.Width - 4, picLeftLogo.Height - 4);
                    }
                    using (var pen = new Pen(Color.White, 3))
                    {
                        int cx = picLeftLogo.Width / 2;
                        int cy = picLeftLogo.Height / 2;
                        e.Graphics.DrawLine(pen, cx - 8, cy, cx + 8, cy);
                        e.Graphics.DrawLine(pen, cx, cy - 8, cx, cy + 8);
                    }
                };
            }

            // Setup title color (premium slate-900 near-black)
            lblRightTitle.ForeColor = Color.FromArgb(15, 23, 42);
        }

        private void pnlLeft_Paint(object sender, PaintEventArgs e)
        {
            if (picLeftLogo != null && picLeftLogo.Visible)
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                int padding = 6;
                int circleX = picLeftLogo.Location.X - padding;
                int circleY = picLeftLogo.Location.Y - padding;
                int circleSize = picLeftLogo.Width + 2 * padding;

                // Perfect anti-aliased white circle
                using (var whiteBrush = new SolidBrush(Color.White))
                {
                    e.Graphics.FillEllipse(whiteBrush, circleX, circleY, circleSize, circleSize);
                }

                // Subtle light border around the circle
                using (var borderPen = new Pen(Color.FromArgb(220, 230, 240), 1f))
                {
                    e.Graphics.DrawEllipse(borderPen, circleX, circleY, circleSize - 1, circleSize - 1);
                }
            }
        }

        // Setup icons: We will draw flat vector icons dynamically inside paint handlers
        private void DrawVectorIcon(Graphics g, int w, int h, string roleKey, Color color)
        {
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            using (var pen = new Pen(color, 2))
            {
                if (roleKey == "Ph1Dba")
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
                else if (roleKey == "Ph2Dba")
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
                else if (roleKey == "Coordinator")
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
                else if (roleKey == "Doctor")
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
                else if (roleKey == "Technician")
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
                else if (roleKey == "Patient")
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

        private void MakePanelInteractive(
            Guna.UI2.WinForms.Guna2Panel panel, 
            Color defaultBorder, 
            Color hoverBorder, 
            Color defaultFill, 
            Color hoverFill, 
            Color themeColor,
            string roleKey,
            Guna.UI2.WinForms.Guna2Panel iconBg,
            Guna.UI2.WinForms.Guna2PictureBox iconPic,
            Guna.UI2.WinForms.Guna2PictureBox chevronPic,
            Action onClick)
        {
            panel.Cursor = Cursors.Hand;
            Point originalLoc = panel.Location;
            bool isHovered = false;

            // Dynamically locate the accent vertical line panel
            Guna.UI2.WinForms.Guna2Panel accent = null;
            foreach (Control ctrl in panel.Controls)
            {
                if (ctrl is Guna.UI2.WinForms.Guna2Panel && ctrl.Name.StartsWith("accent", StringComparison.OrdinalIgnoreCase))
                {
                    accent = (Guna.UI2.WinForms.Guna2Panel)ctrl;
                    break;
                }
            }

            if (chevronPic != null)
            {
                chevronPic.BackColor = defaultFill;
                chevronPic.FillColor = defaultFill;
                chevronPic.Paint += (s, e) =>
                {
                    Color chevColor = isHovered ? themeColor : Color.FromArgb(101, 130, 164);
                    using (var pen = new Pen(chevColor, 2))
                    {
                        pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
                        pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
                        pen.LineJoin = System.Drawing.Drawing2D.LineJoin.Round;
                        e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                        e.Graphics.DrawLine(pen, 8, 6, 14, 12);
                        e.Graphics.DrawLine(pen, 14, 12, 8, 18);
                    }
                };
            }

            if (iconPic != null)
            {
                Color defaultIconBg = (themeColor == Ph1Color) 
                    ? Color.FromArgb(240, 244, 248) 
                    : Color.FromArgb(230, 243, 239);
                iconPic.BackColor = defaultIconBg;
                iconPic.FillColor = defaultIconBg;
                iconPic.Image = null; // Bypass physical file loading to use dynamic vector shapes
                iconPic.Paint += (s, e) =>
                {
                    Color iconColor = isHovered ? Color.White : themeColor;
                    DrawVectorIcon(e.Graphics, iconPic.Width, iconPic.Height, roleKey, iconColor);
                };
            }

            Action updateState = () =>
            {
                Color currentPanelBg = isHovered ? hoverFill : defaultFill;
                Color currentIconBg = isHovered ? themeColor : ((themeColor == Ph1Color) 
                    ? Color.FromArgb(240, 244, 248) 
                    : Color.FromArgb(230, 243, 239));

                if (isHovered)
                {
                    panel.BorderColor = hoverBorder;
                    panel.FillColor = hoverFill;
                    panel.Location = new Point(originalLoc.X, originalLoc.Y - 4);
                    panel.ShadowDecoration.Depth = 12;
                    panel.ShadowDecoration.Color = Color.FromArgb(40, themeColor);
                    
                    if (accent != null)
                    {
                        accent.Width = 10;
                    }
                    if (iconBg != null)
                    {
                        iconBg.FillColor = themeColor;
                    }
                }
                else
                {
                    panel.BorderColor = defaultBorder;
                    panel.FillColor = defaultFill;
                    panel.Location = originalLoc;
                    panel.ShadowDecoration.Depth = 6;
                    panel.ShadowDecoration.Color = Color.FromArgb(160, 180, 200);
                    
                    if (accent != null)
                    {
                        accent.Width = 6;
                    }
                    if (iconBg != null)
                    {
                        iconBg.FillColor = (themeColor == Ph1Color) 
                            ? Color.FromArgb(240, 244, 248) 
                            : Color.FromArgb(230, 243, 239);
                    }
                }

                if (chevronPic != null)
                {
                    chevronPic.BackColor = currentPanelBg;
                    chevronPic.FillColor = currentPanelBg;
                    chevronPic.Invalidate();
                }

                if (iconPic != null)
                {
                    iconPic.BackColor = currentIconBg;
                    iconPic.FillColor = currentIconBg;
                    iconPic.Invalidate();
                }
            };

            EventHandler onMouseEnter = (s, e) =>
            {
                if (!isHovered)
                {
                    isHovered = true;
                    updateState();
                }
            };

            EventHandler onMouseLeave = (s, e) =>
            {
                Point clientMouse = panel.PointToClient(Cursor.Position);
                if (!panel.ClientRectangle.Contains(clientMouse))
                {
                    isHovered = false;
                    updateState();
                }
            };

            panel.MouseEnter += onMouseEnter;
            panel.MouseLeave += onMouseLeave;
            panel.Click += (s, e) => onClick();

            // Apply recursively to all child controls inside panel
            AttachHoverRecursively(panel, onMouseEnter, onMouseLeave, onClick);

            // Register reset hover action for form activation/back navigation
            _resetHoverActions.Add(() => {
                isHovered = false;
                updateState();
            });
        }

        private void AttachHoverRecursively(Control parent, EventHandler onMouseEnter, EventHandler onMouseLeave, Action onClick)
        {
            foreach (Control child in parent.Controls)
            {
                child.Cursor = Cursors.Hand;
                child.MouseEnter += onMouseEnter;
                child.MouseLeave += onMouseLeave;
                child.Click += (s, e) => onClick();
                if (child.HasChildren)
                {
                    AttachHoverRecursively(child, onMouseEnter, onMouseLeave, onClick);
                }
            }
        }

        private void WireRoleButtons()
        {
            // DBA Ph1 (Blue Themed)
            MakePanelInteractive(btnPh1Dba, 
                                 Color.FromArgb(220, 228, 238), 
                                 Color.FromArgb(37, 74, 132),   
                                 Color.White,                    
                                 Color.FromArgb(235, 242, 253), 
                                 Ph1Color,
                                 "Ph1Dba",
                                 pnlPh1DbaIconBg,
                                 picPh1DbaIcon,
                                 picPh1DbaChevron,
                                 () => OpenRoleLogin(CreateRole("PH1_DBA", "Phân hệ 1", "DBA", "Quản trị viên CSDL Oracle", LoginModule.Ph1, Ph1Color)));

            // Phân hệ 2 (Green Themed)
            Color defBorder = Color.FromArgb(215, 230, 226);
            Color hovBorder = Color.FromArgb(15, 110, 86);
            Color defFill = Color.White;
            Color hovFill = Color.FromArgb(230, 244, 240);
            Color ph2ThemeColor = Color.FromArgb(15, 110, 86);

            MakePanelInteractive(btnPh2Dba, defBorder, hovBorder, defFill, hovFill, ph2ThemeColor, "Ph2Dba", pnlPh2DbaIconBg, picPh2DbaIcon, null, () => OpenRoleLogin(CreateRole("PH2_DBA", "Phân hệ 2", "DBA", "Quản trị hệ thống y tế", LoginModule.Ph2, Ph2Color)));
            MakePanelInteractive(btnPh2Coordinator, defBorder, hovBorder, defFill, hovFill, ph2ThemeColor, "Coordinator", pnlPh2CoordIconBg, picPh2CoordIcon, null, () => OpenRoleLogin(CreateRole("PH2_COORDINATOR", "Phân hệ 2", "Điều phối viên", "Tiếp nhận bệnh nhân", LoginModule.Ph2, Ph2Color)));
            MakePanelInteractive(btnPh2Doctor, defBorder, hovBorder, defFill, hovFill, ph2ThemeColor, "Doctor", pnlPh2DocIconBg, picPh2DocIcon, null, () => OpenRoleLogin(CreateRole("PH2_DOCTOR", "Phân hệ 2", "Bác sĩ / Y sĩ", "Chẩn đoán và điều trị", LoginModule.Ph2, Ph2Color)));
            MakePanelInteractive(btnPh2Technician, defBorder, hovBorder, defFill, hovFill, ph2ThemeColor, "Technician", pnlPh2TechIconBg, picPh2TechIcon, null, () => OpenRoleLogin(CreateRole("PH2_TECHNICIAN", "Phân hệ 2", "Kỹ thuật viên", "Dịch vụ chẩn đoán", LoginModule.Ph2, Ph2Color)));
            MakePanelInteractive(btnPh2Patient, defBorder, hovBorder, defFill, hovFill, ph2ThemeColor, "Patient", pnlPh2PatIconBg, picPh2PatIcon, null, () => OpenRoleLogin(CreateRole("PH2_PATIENT", "Phân hệ 2", "Bệnh nhân", "Xem hồ sơ", LoginModule.Ph2, Ph2Color)));
        }

        private static Color Ph1Color
        {
            get { return Color.FromArgb(59, 130, 246); }
        }

        private static Color Ph2Color
        {
            get { return Color.FromArgb(20, 116, 91); }
        }

        private LoginRoleOption CreateRole(string key, string moduleName, string title, string description, LoginModule module, Color themeColor)
        {
            return new LoginRoleOption(key, moduleName, title, description, module, themeColor);
        }

        private void OpenRoleLogin(LoginRoleOption role)
        {
            Hide();
            using (var login = new RoleLogin(role))
            {
                login.ShowDialog(this);
            }

            if (!IsDisposed)
            {
                // Reset all hover states to default to prevent stuck hover styles when returning
                foreach (var resetAction in _resetHoverActions)
                {
                    resetAction();
                }
                Show();
            }
        }

        private Image LoadImageSafely(string filename)
        {
            try
            {
                string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                string imgPath = System.IO.Path.GetFullPath(System.IO.Path.Combine(baseDir, @"..\..\..\image\"));
                if (!System.IO.Directory.Exists(imgPath))
                    imgPath = System.IO.Path.GetFullPath(System.IO.Path.Combine(baseDir, @"image\"));
                string filePath = System.IO.Path.Combine(imgPath, filename);
                if (System.IO.File.Exists(filePath))
                {
                    return Image.FromFile(filePath);
                }
            }
            catch { }
            return null;
        }

        private void RoleSelection_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
            Environment.Exit(0);
        }
    }

    public enum LoginModule
    {
        Ph1,
        Ph2
    }

    public sealed class LoginRoleOption
    {
        public LoginRoleOption(string key, string moduleName, string title, string description, LoginModule module, Color themeColor)
        {
            Key = key;
            ModuleName = moduleName;
            Title = title;
            Description = description;
            Module = module;
            ThemeColor = themeColor;
        }

        public string Key { get; private set; }
        public string ModuleName { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public LoginModule Module { get; private set; }
        public Color ThemeColor { get; private set; }
    }
}
