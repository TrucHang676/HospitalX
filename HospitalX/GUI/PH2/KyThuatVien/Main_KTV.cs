using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using HospitalX.GUI.PH2.KyThuatVien;

namespace HospitalX.GUI.PH2
{
    public partial class Main_KTV : Form
    {
        public Main_KTV()
        {
            InitializeComponent();

            // Gọi cấu hình các nút tại đây
            SetupNavButton(this.btnDashboard, "TỔNG QUAN", 176);
            SetupNavButton(this.btnDichVu, "DỊCH VỤ PHÂN CÔNG   7", 230);
            SetupNavButton(this.btnKetQua, "CẬP NHẬT KẾT QUẢ   3", 284);
            SetupNavButton(this.btnHoSo, "HỒ SƠ CÁ NHÂN", 356);
            SetupNavButton(this.btnThongBao, "THÔNG BÁO   5", 410);

            WireNavigation();
            LoadPage(new ucKtvDashboard(), "Trang chủ", "Xin chào, bạn có 7 dịch vụ được phân công hôm nay");
            btnDashboard.Checked = true;
        }

        private void WireNavigation()
        {
            btnDashboard.Click += (s, e) => LoadPage(new ucKtvDashboard(), "Trang chủ", "Xin chào, bạn có 7 dịch vụ được phân công hôm nay");
            btnDichVu.Click += (s, e) => LoadPage(new ucKtvDichVu(), "Dịch vụ được phân công", "Danh sách HSBA_DV của kỹ thuật viên");
            btnKetQua.Click += (s, e) => LoadPage(new ucKtvKetQua(), "Cập nhật kết quả dịch vụ", "3 kết quả đang chờ cập nhật");
            btnHoSo.Click += (s, e) => LoadPage(new ucKtvHoSo(), "Hồ sơ cá nhân", "Quản lý thông tin cá nhân và tài khoản");
            btnThongBao.Click += (s, e) => LoadPage(new ucKtvThongBao(), "Thông báo", "Trung tâm thông báo nghiệp vụ");
        }

        private void LoadPage(UserControl control, string title, string subtitle)
        {
            pnlContent.Controls.Clear();
            control.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(control);
            lblPageTitle.Text = title;
            lblSubtitle.Text = subtitle;
        }
        private void SetupNavButton(Guna2Button button, string text, int top)
        {
            button.BorderRadius = 6;
            button.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            button.CheckedState.CustomBorderColor = KtvTheme.Accent;
            button.CheckedState.FillColor = KtvTheme.TealMid;
            button.CheckedState.ForeColor = Color.White;
            button.Cursor = Cursors.Hand;
            button.CustomBorderThickness = new Padding(6, 0, 0, 0);
            button.FillColor = Color.Transparent;
            button.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button.ForeColor = Color.FromArgb(220, 230, 226);
            button.HoverState.FillColor = Color.FromArgb(35, 99, 80);
            button.HoverState.ForeColor = Color.White;
            button.Location = new Point(10, top);
            button.Size = new Size(208, 42);
            button.Text = text;
            button.TextAlign = HorizontalAlignment.Left;
            button.TextOffset = new Point(10, 0);
        }

        private void lblLogoPlus_Click(object sender, System.EventArgs e)
        {

        }
    }
}
