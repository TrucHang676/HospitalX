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
        private bool _isLoggingOut = false;

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

            FormClosed += Main_KTV_FormClosed;
            WireNavigation();
            LoadPage(new ucKtvDashboard(), "Trang chủ", "Xin chào, bạn có 7 dịch vụ được phân công hôm nay");
            btnDashboard.Checked = true;
            LoadKtvInfo();
        }

        private void Main_KTV_FormClosed(object sender, FormClosedEventArgs e)
        {
            DisposeCurrentPage();
            if (ReferenceEquals(Instance, this))
            {
                Instance = null;
            }
            if (!_isLoggingOut)
            {
                Application.Exit();
                Environment.Exit(0);
            }
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
                confirmDialog.Style = Guna.UI2.WinForms.MessageDialogStyle.Light;
                confirmDialog.Icon = MessageDialogIcon.Question;
                confirmDialog.Buttons = MessageDialogButtons.YesNo;
                confirmDialog.Caption = "Xác nhận đăng xuất";
                confirmDialog.Text = "Bạn có chắc chắn muốn đăng xuất không?";

                if (confirmDialog.Show() == DialogResult.Yes)
                {
                    _isLoggingOut = true;
                    this.Close();
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

        public void NavigateToDichVu()
        {
            SwitchToTab(btnDichVu, new UcKtvDichVu(), "Dịch vụ được phân công", "Danh sách HSBA_DV của kỹ thuật viên");
        }

        public void NavigateToKetQua()
        {
            SwitchToTab(btnKetQua, new ucKtvKetQua(), "Cập nhật kết quả dịch vụ", "3 kết quả đang chờ cập nhật");
        }

        public void NavigateToHoSo()
        {
            SwitchToTab(btnHoSo, new ucKtvHoSo(), "Hồ sơ cá nhân", "Quản lý thông tin cá nhân và tài khoản");
        }

        public void NavigateToThongBao()
        {
            SwitchToTab(btnThongBao, new ucKtvThongBao(), "Thông báo", "Trung tâm thông báo nghiệp vụ");
        }

        private void LoadPage(UserControl control, string title, string subtitle)
        {
            DisposeCurrentPage();
            control.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(control);
            lblPageTitle.Text = title;
        }

        private void DisposeCurrentPage()
        {
            while (pnlContent.Controls.Count > 0)
            {
                Control oldControl = pnlContent.Controls[0];
                pnlContent.Controls.RemoveAt(0);
                oldControl.Dispose();
            }
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
            lblPageTitle.Location = new Point(18, 20);
            lblPageTitle.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold);

            btnExit.Size = new Size(33, 33);
            btnExit.Location = new Point(pnlTopbar.Width - 50, 19);
            btnExit.CustomIconSize = 18F;

            pnlLogo.Size = new Size(61, 57);
            pnlLogo.BorderRadius = 25;
            pnlLogo.BorderThickness = 1;
            pnlLogo.BorderColor = Color.Green;
            pnlLogo.FillColor = Color.White;
            pnlLogo.Location = new Point(11, 7);
            ptbChuThap.Location = new Point(13, 12);
            ptbChuThap.Size = new Size(35, 33);
            lblLogoPlus.Visible = false;

            lblBrand.Text = "HOSPITAL SYSTEM";
            lblBrand.Font = new Font("Segoe UI", 6.75F, FontStyle.Bold);
            lblBrand.ForeColor = Color.Lime;
            lblBrand.Location = new Point(88, 26);

            lblBrandSub.Text = "Bệnh viện X";
            lblBrandSub.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblBrandSub.ForeColor = Color.White;
            lblBrandSub.Location = new Point(87, 44);

            pnlAvatar.Location = new Point(24, 104);
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
            lblRole.Location = new Point(84, 101);

            lblTenKtv.Text = "Nguyễn Thị Thu";
            lblTenKtv.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTenKtv.ForeColor = Color.White;
            lblTenKtv.Location = new Point(81, 120);

            AddOrUpdateSidebarSeparator("ktvHeaderLine", 80);
            AddOrUpdateSidebarSeparator("ktvProfileLine", 166);

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
            btnLogout.Size = new Size(260, 45);
            btnLogout.Location = new Point(13, ClientSize.Height - 65);
            btnLogout.ImageAlign = HorizontalAlignment.Center;
            btnLogout.ImageOffset = new Point(0, 0);
            btnLogout.TextAlign = HorizontalAlignment.Center;
            btnLogout.TextOffset = new Point(0, 0);
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

        public void LoadKtvInfo()
        {
            try
            {
                System.Data.DataTable dt = HospitalX.DAO.ProfileDAO.Instance.GetProfile();
                if (dt != null && dt.Rows.Count > 0)
                {
                    System.Data.DataRow row = dt.Rows[0];
                    string hoten = row["HOTEN"]?.ToString();
                    if (!string.IsNullOrEmpty(hoten))
                    {
                        lblTenKtv.Text = hoten;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error loading KTV name in sidebar: " + ex.Message);
            }
        }

    }
}
