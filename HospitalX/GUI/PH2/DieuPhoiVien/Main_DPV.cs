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
        }

        private void Main_DPV_Load(object sender, EventArgs e)
        {
            NavigateToDashboard();
            RefreshHeaderLayout();
        }

        private void ApplySharedBranding()
        {
            var rm = new ComponentResourceManager(typeof(Main_BS));
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

            // Thu hẹp khoảng cách giữa "Thông báo nội bộ" và "Hồ sơ cá nhân" (khoảng cách 7px)
            btnHoSoCaNhan.Location = new Point(btnHoSoCaNhan.Left, btnThongBaoNoiBo.Bottom + 7);

            StyleAvatarAndVpdBadge();
        }

        private void ApplyHeaderStyle()
        {
            lblPageTitle.AutoSize = false;
            lblPageTitle.Size = new Size(220, 44);
            lblPageTitle.Location = new Point(24, 10);
            lblPageTitle.TextAlign = ContentAlignment.MiddleLeft;

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
            btn.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
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
            const int iconSize = 32;
            DpvAssets.ApplyButtonImage(btnDashboard, 1, iconSize);
            DpvAssets.ApplyButtonImage(btnDanhSachBN, 2, iconSize);
            DpvAssets.ApplyButtonImage(btnThemSuaBN, 3, iconSize);
            DpvAssets.ApplyButtonImage(btnTaoHSBA, 4, iconSize);
            DpvAssets.ApplyButtonImage(btnDieuPhoiKTV, 5, iconSize);
            DpvAssets.ApplyButtonImage(btnThongBaoNoiBo, 6, iconSize);
            DpvAssets.ApplyButtonImage(btnHoSoCaNhan, 7, iconSize);
        }

        private void WireNavigationEvents()
        {
            btnDashboard.Click += (s, e) => NavigateToDashboard();
            btnDanhSachBN.Click += (s, e) => ShowComingSoon(btnDanhSachBN, "Danh sách bệnh nhân");
            btnThemSuaBN.Click += (s, e) => ShowComingSoon(btnThemSuaBN, "Thêm / Sửa bệnh nhân");
            btnTaoHSBA.Click += (s, e) => ShowComingSoon(btnTaoHSBA, "Tạo hồ sơ bệnh án");
            btnDieuPhoiKTV.Click += (s, e) => ShowComingSoon(btnDieuPhoiKTV, "Điều phối kỹ thuật viên");
            btnThongBaoNoiBo.Click += (s, e) => ShowComingSoon(btnThongBaoNoiBo, "Thông báo nội bộ");
            btnHoSoCaNhan.Click += (s, e) => ShowComingSoon(btnHoSoCaNhan, "Hồ sơ cá nhân");
            btnLogout.Click += BtnLogout_Click;
        }

        private void NavigateToDashboard()
        {
            LoadPage(new ucTrangChu(), "Trang chủ", "/ Dashboard");
            btnDashboard.Checked = true;
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
        }

        private void ShowComingSoon(Guna2Button activeMenu, string feature)
        {
            activeMenu.Checked = true;

            guna2MessageDialog1.Parent = this;
            guna2MessageDialog1.Icon = MessageDialogIcon.Information;
            guna2MessageDialog1.Buttons = MessageDialogButtons.OK;
            guna2MessageDialog1.Caption = "MedSys HIS";
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
            lblBadgeNotif.BackColor = Color.Transparent;

            // Căn chỉnh vị trí nhãn VPD sát với chữ "Điều phối viên"
            using (Graphics g = lblRole.CreateGraphics())
            {
                SizeF size = g.MeasureString(lblRole.Text, lblRole.Font);
                int roleTextWidth = (int)Math.Ceiling(size.Width);
                lblVpdBadge.Location = new Point(lblRole.Left + roleTextWidth + 6, lblRole.Top - 3);
            }

            // Chuyển lblBadgeNotif thành control con của btnThongBaoNoiBo để tránh lỗi đường viền cắt của WinForms khi hover
            pnlSidebar.Controls.Remove(lblBadgeNotif);
            btnThongBaoNoiBo.Controls.Add(lblBadgeNotif);

            lblBadgeNotif.Size = new Size(20, 20); // Thu nhỏ lại thành hình tròn 20x20
            lblBadgeNotif.Location = new Point(btnThongBaoNoiBo.Width - 36, (btnThongBaoNoiBo.Height - 20) / 2);
            lblBadgeNotif.BringToFront();

            lblBadgeNotif.Paint += (s, e) =>
            {
                var lbl = (Label)s;
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                Color badgeColor = Color.FromArgb(221, 82, 53); // Màu đỏ cam cam dịu mắt
                using (var brush = new SolidBrush(badgeColor))
                {
                    e.Graphics.FillEllipse(brush, 0, 0, lbl.Width, lbl.Height);
                }

                // Vẽ số 4 chính xác ở tâm hình tròn
                using (var font = new Font("Segoe UI", 7.5F, FontStyle.Bold))
                using (var sf = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                })
                {
                    e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
                    e.Graphics.DrawString(lbl.Text, font, Brushes.White, lbl.ClientRectangle, sf);
                }
            };

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
    }
}
