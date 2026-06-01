using HospitalX.GUI.PH2.BacSi;
using HospitalX.GUI.PH2.DieuPhoiVien;
using Guna.UI2.WinForms;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace HospitalX.GUI.PH2
{
    public partial class Main_DPV : Form
    {
        public Main_DPV()
        {
            InitializeComponent();
            ApplySharedBranding();
            ApplyBacSiStyle();
            ApplySidebarIcons();
            WireNavigationEvents();
            Load += Main_DPV_Load;

            // Set minimum size to prevent squishing dashboard layout
            this.MinimumSize = new Size(1300, 720);
        }

        private void Main_DPV_Load(object sender, EventArgs e)
        {
            NavigateToDashboard();
            RefreshHeaderLayout();
        }

        private void ApplySharedBranding()
        {
            var rm = new ComponentResourceManager(typeof(Main_BN));
            ptbChuThap.Image = (Image)rm.GetObject("ptbChuThap.Image");
            btnLogout.Image = (Image)rm.GetObject("btnLogout.Image");
        }

        private void ApplyBacSiStyle()
        {
            pnlTopbar.FillColor = Color.White;

            lblPageTitle.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold);
            lblPageTitle.ForeColor = Color.FromArgb(10, 42, 64);

            lblTenDPV.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblRole.Font = new Font("Segoe UI", 6.75F, FontStyle.Bold);
            lblRole.ForeColor = Color.WhiteSmoke;

            btnExit.BackColor = Color.Transparent;
            btnExit.BorderRadius = 6;
            btnExit.CustomIconSize = 20F;
            btnExit.FillColor = Color.Transparent;
            btnExit.ForeColor = Color.Black;
            btnExit.HoverState.FillColor = Color.DarkSeaGreen;
            btnExit.IconColor = Color.DarkGreen;
            btnExit.Size = new Size(33, 32);

            pnlTopbar.Height = 65;
            pnlContent.Top = 65;

            ApplyHeaderStyle();

            btnLogout.BorderColor = Color.FromArgb(255, 110, 110);
            btnLogout.BorderRadius = 10;
            btnLogout.BorderThickness = 1;
            btnLogout.FillColor = Color.Transparent;
            btnLogout.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnLogout.ForeColor = Color.FromArgb(255, 128, 128);
            btnLogout.HoverState.BorderColor = Color.FromArgb(255, 80, 80);
            btnLogout.HoverState.FillColor = Color.Maroon;
            btnLogout.HoverState.ForeColor = Color.White;

            StyleNavButton(btnDashboard);
            StyleNavButton(btnDanhSachBN);
            StyleNavButton(btnThemSuaBN);
            StyleNavButton(btnTaoHSBA);
            StyleNavButton(btnDieuPhoiKTV);
            StyleNavButton(btnThongBaoNoiBo);
            StyleNavButton(btnHoSoCaNhan);



            StyleAvatarAndVpdBadge();



            AddTopbarControls();
        }

        private void ApplyHeaderStyle()
        {
            lblPageTitle.AutoSize = true;
            lblPageTitle.Location = new Point(24, 10);

            lblBreadcrumb.AutoSize = true;
            lblBreadcrumb.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            lblBreadcrumb.ForeColor = Color.FromArgb(122, 149, 137);
        }

        private void RefreshHeaderLayout()
        {
            using (Graphics g = lblPageTitle.CreateGraphics())
            {
                SizeF titleSize = g.MeasureString(lblPageTitle.Text, lblPageTitle.Font);
                lblBreadcrumb.Location = new Point(
                    lblPageTitle.Left + (int)Math.Ceiling(titleSize.Width) + 8,
                    lblPageTitle.Top + 12);
            }
        }

        private static void StyleNavButton(Guna2Button btn)
        {
            btn.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btn.ForeColor = Color.Silver;
            btn.BorderRadius = 8;
            btn.CustomBorderThickness = new Padding(8, 0, 0, 0);
            btn.IndicateFocus = true;
            btn.CheckedState.CustomBorderColor = Color.White;
            btn.CheckedState.FillColor = Color.FromArgb(27, 148, 112);
            btn.CheckedState.ForeColor = Color.White;
            btn.HoverState.CustomBorderColor = Color.White;
            btn.HoverState.FillColor = Color.FromArgb(63, 114, 99);
        }

        private void ApplySidebarIcons()
        {
            const int iconSize = 24;
            SetButtonIcons(btnDashboard, "house.png", "house (1).png", iconSize);
            SetButtonIcons(btnDanhSachBN, "dpv_2_black.png", "dpv_2.png", iconSize);
            SetButtonIcons(btnThemSuaBN, "pencil.png", "pencil (1).png", iconSize);
            SetButtonIcons(btnTaoHSBA, "medical-record (1).png", "medical-record.png", iconSize);
            SetButtonIcons(btnDieuPhoiKTV, "setting.png", "setting (1).png", iconSize);
            SetButtonIcons(btnThongBaoNoiBo, "notification.png", "notification (1).png", iconSize);
            SetButtonIcons(btnHoSoCaNhan, "user (1).png", "user (2).png", iconSize);
        }

        private void SetButtonIcons(Guna2Button button, string normalIcon, string checkedIcon, int size)
        {
            button.Image = DpvAssets.Load(normalIcon);
            button.CheckedState.Image = DpvAssets.Load(checkedIcon);
            button.ImageSize = new Size(size, size);
            button.ImageOffset = new Point(8, 0);
            button.TextOffset = new Point(15, 0);
        }

        private void WireNavigationEvents()
        {
            btnDashboard.Click += (s, e) => NavigateToDashboard();
            btnDanhSachBN.Click += (s, e) => NavigateToDanhSachBN();
            btnThemSuaBN.Click += (s, e) => NavigateToThemSuaBN();
            btnTaoHSBA.Click += (s, e) => NavigateToTaoHSBA();
            btnDieuPhoiKTV.Click += (s, e) => NavigateToDieuPhoiKTV();
            btnThongBaoNoiBo.Click += (s, e) => ShowComingSoon(btnThongBaoNoiBo, "Thông báo nội bộ");
            btnHoSoCaNhan.Click += (s, e) => ShowComingSoon(btnHoSoCaNhan, "Hồ sơ cá nhân");
            btnLogout.Click += BtnLogout_Click;
        }

        private void NavigateToDashboard()
        {
            LoadPage(new ucTrangChu(), "Trang chủ", "/ Dashboard");
            btnDashboard.Checked = true;
        }

        public void NavigateToDanhSachBN()
        {
            LoadPage(new ucDanhSachBN(), "Danh sách bệnh nhân", "/ BỆNH NHÂN");
            btnDanhSachBN.Checked = true;
        }

        /// <summary>Navigate to "Thêm / Sửa bệnh nhân" tab. Called from child user controls.</summary>
        public void NavigateToThemSuaBN(string patientId = null)
        {
            var uc = new ucThemSuaBN();
            if (!string.IsNullOrEmpty(patientId))
            {
                uc.PreloadPatient(patientId);
            }
            LoadPage(uc, "Thêm bệnh nhân mới", "/ BỆNH NHÂN");
            btnThemSuaBN.Checked = true;
        }

        /// <summary>Navigate to "Tạo hồ sơ bệnh án" tab. Called from child user controls.</summary>
        public void NavigateToTaoHSBA()
        {
            LoadPage(new ucTaoHSBA(), "Tạo hồ sơ bệnh án", "/ HSBA");
            btnTaoHSBA.Checked = true;
        }

        public void NavigateToDieuPhoiKTV()
        {
            LoadPage(new ucDieuPhoiKTV(), "Điều phối kỹ thuật viên", "/ HSBA_DV");
            btnDieuPhoiKTV.Checked = true;
        }

        private void LoadPage(UserControl control, string title, string breadcrumb)
        {
            var old = pnlContent.Controls.Count > 0 ? pnlContent.Controls[0] : null;
            pnlContent.Controls.Clear();
            old?.Dispose();
            control.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(control);
            lblPageTitle.Text = title;
            lblBreadcrumb.Text = breadcrumb;
            RefreshHeaderLayout();

            // Hide action buttons on the Patient List page (ucDanhSachBN)
            if (btnThemBN != null) btnThemBN.Visible = false;
            if (btnNotif != null) btnNotif.Visible = false;
            if (btnProfile != null) btnProfile.Visible = false;
        }

        private void ShowComingSoon(Guna2Button activeMenu, string feature)
        {
            activeMenu.Checked = true;

            guna2MessageDialog1.Parent = this;
            guna2MessageDialog1.Icon = MessageDialogIcon.Information;
            guna2MessageDialog1.Buttons = MessageDialogButtons.OK;
            guna2MessageDialog1.Caption = "Bệnh viện X";
            guna2MessageDialog1.Show($"Chức năng \"{feature}\" đang được phát triển.", "Thông báo");

            LoadPage(new ucTrangChu(), "Trang chủ", "/ Dashboard");
            activeMenu.Checked = true;
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            guna2MessageDialog1.Parent = this;
            guna2MessageDialog1.Icon = MessageDialogIcon.Question;
            guna2MessageDialog1.Buttons = MessageDialogButtons.YesNo;
            guna2MessageDialog1.Caption = "Xác nhận đăng xuất";
            guna2MessageDialog1.Text = "Bạn có chắc chắn muốn đăng xuất không?";
            if (guna2MessageDialog1.Show() == DialogResult.Yes)
            {
                Application.Restart();
            }
        }

        public void ShowMessage(string message, string caption, MessageDialogIcon icon = MessageDialogIcon.Information)
        {
            guna2MessageDialog1.Parent = this;
            guna2MessageDialog1.Icon = icon;
            guna2MessageDialog1.Buttons = MessageDialogButtons.OK;
            guna2MessageDialog1.Caption = caption;
            guna2MessageDialog1.Show(message, caption);
        }

        private void StyleAvatarAndVpdBadge()
        {
            // Set BackColor to Transparent to prevent default square background drawing
            lblAvatarIni.BackColor = Color.Transparent;
            lblVpdBadge.BackColor = Color.Transparent;

            // Căn chỉnh vị trí nhãn VPD sát với chữ "Điều phối viên"
            using (Graphics g = lblRole.CreateGraphics())
            {
                SizeF size = g.MeasureString(lblRole.Text, lblRole.Font);
                int roleTextWidth = (int)Math.Ceiling(size.Width);
                lblVpdBadge.Location = new Point(lblRole.Left + roleTextWidth + 6, lblRole.Top - 3);
            }

            // Vẽ bo tròn và đổi màu cho ô LH
            lblAvatarIni.Paint += (s, e) =>
            {
                var lbl = (Label)s;
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                using (var bgBrush = new SolidBrush(pnlSidebar.BackColor))
                {
                    e.Graphics.FillRectangle(bgBrush, lbl.ClientRectangle);
                }

                Color avatarColor = Color.FromArgb(20, 115, 93); // Teal đậm đẹp
                using (var path = GetRoundedPath(lbl.ClientRectangle, 10))
                using (var brush = new SolidBrush(avatarColor))
                {
                    e.Graphics.FillPath(brush, path);
                }

                TextRenderer.DrawText(e.Graphics, lbl.Text, lbl.Font, lbl.ClientRectangle, lbl.ForeColor,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            };

            // Vẽ bo tròn và đổi màu cho ô VPD
            lblVpdBadge.Paint += (s, e) =>
            {
                var lbl = (Label)s;
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                using (var bgBrush = new SolidBrush(pnlSidebar.BackColor))
                {
                    e.Graphics.FillRectangle(bgBrush, lbl.ClientRectangle);
                }

                Color badgeColor = Color.FromArgb(254, 203, 70); // Vàng ấm tươi đẹp
                Color textColor = Color.FromArgb(26, 26, 26);     // Chữ đen xám tối
                using (var path = GetRoundedPath(lbl.ClientRectangle, 5)) // Bo nhẹ
                using (var brush = new SolidBrush(badgeColor))
                {
                    e.Graphics.FillPath(brush, path);
                }

                TextRenderer.DrawText(e.Graphics, lbl.Text, lbl.Font, lbl.ClientRectangle, textColor,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            };
        }

        private Guna2Button btnThemBN;
        private Guna2Button btnNotif;
        private Guna2Button btnProfile;

        private void AddTopbarControls()
        {
            // Profile button
            btnProfile = new Guna2Button();
            btnProfile.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnProfile.Size = new Size(38, 38);
            btnProfile.Location = new Point(btnExit.Left - 10 - 38, (pnlTopbar.Height - 38) / 2);
            btnProfile.BorderRadius = 8;
            btnProfile.BorderColor = Color.FromArgb(216, 232, 227); // #D8E8E3
            btnProfile.BorderThickness = 1;
            btnProfile.FillColor = Color.Transparent;
            btnProfile.Image = DpvAssets.Load("user.png");
            btnProfile.ImageSize = new Size(18, 18);
            btnProfile.HoverState.FillColor = Color.FromArgb(230, 244, 240);
            btnProfile.Cursor = Cursors.Hand;
            btnProfile.Click += (s, e) => ShowComingSoon(btnHoSoCaNhan, "Hồ sơ cá nhân");

            // Notification button
            btnNotif = new Guna2Button();
            btnNotif.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNotif.Size = new Size(38, 38);
            btnNotif.Location = new Point(btnProfile.Left - 10 - 38, (pnlTopbar.Height - 38) / 2);
            btnNotif.BorderRadius = 8;
            btnNotif.BorderColor = Color.FromArgb(216, 232, 227);
            btnNotif.BorderThickness = 1;
            btnNotif.FillColor = Color.Transparent;
            btnNotif.Image = DpvAssets.Load("notification.png");
            btnNotif.ImageSize = new Size(18, 18);
            btnNotif.HoverState.FillColor = Color.FromArgb(230, 244, 240);
            btnNotif.Cursor = Cursors.Hand;
            btnNotif.Click += (s, e) => ShowComingSoon(btnThongBaoNoiBo, "Thông báo nội bộ");

            // Paint red notification dot on btnNotif
            btnNotif.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                Color dotColor = Color.FromArgb(224, 92, 58); // #E05C3A
                using (var brush = new SolidBrush(dotColor))
                {
                    e.Graphics.FillEllipse(brush, btnNotif.Width - 12, 6, 6, 6);
                }
            };

            // Add patient button
            btnThemBN = new Guna2Button();
            btnThemBN.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnThemBN.Size = new Size(160, 38);
            btnThemBN.Location = new Point(btnNotif.Left - 12 - 160, (pnlTopbar.Height - 38) / 2);
            btnThemBN.BorderRadius = 8;
            btnThemBN.FillColor = Color.FromArgb(15, 110, 86); // var(--teal)
            btnThemBN.HoverState.FillColor = Color.FromArgb(10, 82, 64);
            btnThemBN.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnThemBN.ForeColor = Color.White;
            btnThemBN.Text = "+ Thêm bệnh nhân";
            btnThemBN.Cursor = Cursors.Hand;
            btnThemBN.Click += (s, e) => ShowComingSoon(btnThemSuaBN, "Thêm / Sửa bệnh nhân");

            pnlTopbar.Controls.Add(btnProfile);
            pnlTopbar.Controls.Add(btnNotif);
            pnlTopbar.Controls.Add(btnThemBN);
        }

        private static System.Drawing.Drawing2D.GraphicsPath GetRoundedPath(Rectangle rect, int radius)
        {
            var path = new System.Drawing.Drawing2D.GraphicsPath();
            int diameter = radius * 2;
            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();
            return path;
        }

        private void pnlSidebar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnDanhSachBN_Click(object sender, EventArgs e)
        {

        }
    }
}
