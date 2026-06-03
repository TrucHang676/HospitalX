using Guna.UI2.WinForms;
using HospitalX.GUI.PH2.KyThuatVien;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace HospitalX.GUI.PH2
{
    public partial class Main_KTV : Form
    {
        public static Main_KTV Instance { get; private set; }

        public Main_KTV()
        {
            InitializeComponent();
            Instance = this;

            SetButtonImages(this.btnDashboard, KtvIcons.SidebarDashboardNormal, KtvIcons.SidebarDashboardActive);
            SetButtonImages(this.btnDichVu, KtvIcons.SidebarDichVuNormal, KtvIcons.SidebarDichVuActive);
            SetButtonImages(this.btnKetQua, KtvIcons.SidebarKetQuaNormal, KtvIcons.SidebarKetQuaActive);
            SetButtonImages(this.btnHoSo, KtvIcons.SidebarHoSoNormal, KtvIcons.SidebarHoSoActive);
            SetButtonImages(this.btnThongBao, KtvIcons.SidebarThongBaoNormal, KtvIcons.SidebarThongBaoActive);
            ApplyDoctorSidebarLayout();

            WireNavigation();
            LoadPage(new ucKtvDashboard(), "Trang chủ", "Xin chào, bạn có 7 dịch vụ được phân công hôm nay");
            btnDashboard.Checked = true;
        }

        private void WireNavigation()
        {
            btnDashboard.Click += (s, e) => SwitchToTab(btnDashboard, new ucKtvDashboard(), "Trang chủ", "Xin chào, bạn có 7 dịch vụ được phân công hôm nay");
            btnDichVu.Click += (s, e) => SwitchToTab(btnDichVu, new UcKtvDichVu(), "Dịch vụ được phân công", "Danh sách HSBA_DV của kỹ thuật viên");
            btnKetQua.Click += (s, e) => SwitchToTab(btnKetQua, new ucKtvKetQua(), "Cập nhật kết quả dịch vụ", "3 kết quả đang chờ cập nhật");
            btnHoSo.Click += (s, e) => SwitchToTab(btnHoSo, new ucKtvHoSo(), "Hồ sơ cá nhân", "Quản lý thông tin cá nhân và tài khoản");
            btnThongBao.Click += (s, e) => SwitchToTab(btnThongBao, new ucKtvThongBao(), "Thông báo", "Trung tâm thông báo nghiệp vụ");
            btnLogout.Click += BtnLogout_Click;
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            using (var confirmDialog = new Guna2MessageDialog())
            {
                confirmDialog.Parent = this;
                confirmDialog.Icon = MessageDialogIcon.Question;
                confirmDialog.Buttons = MessageDialogButtons.YesNo;
                confirmDialog.Caption = "Xác nhận đăng xuất";
                confirmDialog.Text = "Bạn có chắc chắn muốn đăng xuất không?";

                if (confirmDialog.Show() == DialogResult.Yes)
                {
                    Application.Exit();
                }
            }
        }

        public void SwitchToTab(Guna2Button targetButton, UserControl control, string title, string subtitle)
        {
            // Thiết lập trạng thái Checked thủ công cho tất cả các nút để tránh lỗi đồng bộ của Guna2
            btnDashboard.Checked = (targetButton == btnDashboard);
            btnDichVu.Checked = (targetButton == btnDichVu);
            btnKetQua.Checked = (targetButton == btnKetQua);
            btnHoSo.Checked = (targetButton == btnHoSo);
            btnThongBao.Checked = (targetButton == btnThongBao);

            LoadPage(control, title, subtitle);
        }

        public void SwitchToKetQua(string recordId = null)
        {
            SwitchToTab(btnKetQua, new ucKtvKetQua(), "Cập nhật kết quả dịch vụ", "3 kết quả đang chờ cập nhật");
        }

        private void LoadPage(UserControl control, string title, string subtitle)
        {
            pnlContent.Controls.Clear();
            control.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(control);
            lblPageTitle.Text = title;
            lblSubtitle.Text = subtitle;
        }

        private void ApplyDoctorSidebarLayout()
        {
            pnlSidebar.Width = 285;
            pnlTopbar.Left = pnlSidebar.Width;
            pnlTopbar.Width = ClientSize.Width - pnlSidebar.Width;
            pnlContent.Left = pnlSidebar.Width;
            pnlContent.Top = 72;
            pnlContent.Width = ClientSize.Width - pnlSidebar.Width;
            pnlContent.Height = ClientSize.Height - pnlContent.Top;

            pnlTopbar.Height = 72;
            lblPageTitle.Location = new Point(18, 10);
            lblPageTitle.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold);
            lblSubtitle.Location = new Point(20, 46);
            btnExit.Size = new Size(33, 32);
            btnExit.Location = new Point(pnlTopbar.Width - 50, 20);

            pnlLogo.Size = new Size(46, 46);
            pnlLogo.BorderRadius = 8;
            pnlLogo.Location = new Point(8, 6);
            ptbChuThap.Location = new Point(10, 10);
            ptbChuThap.Size = new Size(26, 27);
            lblLogoPlus.Visible = false;

            lblBrand.Text = "HOSPITAL SYSTEM";
            lblBrand.Font = new Font("Segoe UI", 6.75F, FontStyle.Bold);
            lblBrand.ForeColor = Color.Lime;
            lblBrand.Location = new Point(66, 21);

            lblBrandSub.Text = "Kỹ thuật viên";
            lblBrandSub.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblBrandSub.ForeColor = Color.White;
            lblBrandSub.Location = new Point(65, 36);

            pnlAvatar.Location = new Point(18, 85);
            pnlAvatar.Size = new Size(36, 36);
            pnlAvatar.BorderRadius = 8;
            pnlAvatar.FillColor = Color.Transparent;
            ptbAdmin.MinimumSize = Size.Empty;
            ptbAdmin.Location = new Point(0, 0);
            ptbAdmin.Size = new Size(36, 36);
            lblAvatarText.Visible = false;

            lblRole.Text = "KTV xét nghiệm";
            lblRole.Font = new Font("Segoe UI", 6.75F, FontStyle.Bold);
            lblRole.ForeColor = Color.WhiteSmoke;
            lblRole.Location = new Point(63, 89);

            lblTenKtv.Text = "Nguyễn Thị Thu";
            lblTenKtv.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTenKtv.ForeColor = Color.White;
            lblTenKtv.Location = new Point(61, 108);

            AddOrUpdateSidebarSeparator("ktvHeaderLine", 65);
            AddOrUpdateSidebarSeparator("ktvProfileLine", 135);

            ConfigureSidebarButton(btnDashboard, "TỔNG QUAN", 186);
            ConfigureSidebarButton(btnDichVu, "DỊCH VỤ PHÂN CÔNG", 246);
            ConfigureSidebarButton(btnKetQua, "CẬP NHẬT KẾT QUẢ", 306);
            ConfigureSidebarButton(btnHoSo, "HỒ SƠ CÁ NHÂN", 366);
            ConfigureSidebarButton(btnThongBao, "THÔNG BÁO", 426);

            btnLogout.BorderColor = Color.FromArgb(255, 110, 110);
            btnLogout.BorderRadius = 10;
            btnLogout.BorderThickness = 1;
            btnLogout.FillColor = Color.Transparent;
            btnLogout.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnLogout.ForeColor = Color.FromArgb(255, 128, 128);
            btnLogout.HoverState.BorderColor = Color.FromArgb(255, 80, 80);
            btnLogout.HoverState.FillColor = Color.Maroon;
            btnLogout.HoverState.ForeColor = Color.White;
            btnLogout.Image = HospitalX.GUI.PH2.DieuPhoiVien.DpvAssets.Load("logout.png");
            btnLogout.ImageSize = new Size(24, 24);
            btnLogout.Size = new Size(200, 38);
            btnLogout.Location = new Point((pnlSidebar.Width - btnLogout.Width) / 2, ClientSize.Height - 62);
        }

        private void ConfigureSidebarButton(Guna2Button button, string text, int top)
        {
            button.BorderRadius = 8;
            button.CustomBorderThickness = new Padding(8, 0, 0, 0);
            button.CheckedState.CustomBorderColor = Color.White;
            button.CheckedState.FillColor = Color.FromArgb(27, 148, 112);
            button.CheckedState.ForeColor = Color.White;
            button.FillColor = Color.Transparent;
            button.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            button.ForeColor = Color.Silver;
            button.HoverState.CustomBorderColor = Color.White;
            button.HoverState.FillColor = Color.FromArgb(63, 114, 99);
            button.HoverState.ForeColor = Color.White;
            button.ImageAlign = HorizontalAlignment.Left;
            button.ImageOffset = new Point(8, 0);
            button.ImageSize = new Size(24, 24);
            button.Location = new Point(13, top);
            button.Size = new Size(260, 45);
            button.Text = text;
            button.TextAlign = HorizontalAlignment.Left;
            button.TextOffset = new Point(10, 0);
        }

        private void AddOrUpdateSidebarSeparator(string name, int top)
        {
            Control existing = pnlSidebar.Controls[name];
            Guna2Separator separator = existing as Guna2Separator;

            if (separator == null)
            {
                separator = new Guna2Separator();
                separator.Name = name;
                pnlSidebar.Controls.Add(separator);
                separator.BringToFront();
            }

            separator.FillColor = Color.FromArgb(192, 255, 192);
            separator.FillThickness = 1;
            separator.Location = new Point(0, top);
            separator.Size = new Size(pnlSidebar.Width, 1);
        }

        private void SetButtonImages(Guna2Button button, Image normalImage, Image activeImage)
        {
            try
            {
                if (normalImage == null || activeImage == null)
                {
                    throw new System.InvalidOperationException("Missing KTV sidebar icon resource.");
                }

                button.Image = normalImage;
                button.CheckedState.Image = activeImage;
            }
            catch (System.Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error loading button images: " + ex.Message);
            }
        }

    }
}
