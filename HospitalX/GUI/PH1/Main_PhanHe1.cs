using System;
using System.Windows.Forms;

namespace HospitalX.GUI.PH1
{
    public partial class Main_PhanHe1 : Form
    {
        private string _connStr;
        private bool _isLoggingOut = false;

        public Main_PhanHe1(string connStr = "")
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            _connStr = connStr;
            this.FormClosed += Main_PhanHe1_FormClosed;
            // Wire thủ công để chắc chắn, không phụ thuộc designer
            this.Load += Main_PhanHe1_Load;
            this.btnMenuDashboard.Click += btnMenuDashboard_Click;
            this.btnUser.Click += btnUser_Click;
            this.btnRole.Click += btnRole_Click;
            this.btnGrantRevoke.Click += btnGrantRevoke_Click;
            this.btnViewPrivilege.Click += btnViewPrivilege_Click;
        }

        // 1. Hàm Load UserControl vào vùng nội dung chính (pnlContent)
        private void LoadPanel(UserControl uc)
        {
            // Lấy control cũ ra trước, sau đó mới xóa — tránh lỗi index thay đổi
            var old = pnlContent.Controls.Count > 0
                      ? pnlContent.Controls[0]
                      : null;

            pnlContent.Controls.Clear();
            old?.Dispose(); // Dispose sau khi đã clear, không trước

            uc.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(uc);
            uc.BringToFront();
        }

        // 2. Sự kiện Load Form: Mặc định mở trang Dashboard đầu tiên
        private void Main_PhanHe1_Load(object sender, EventArgs e)
        {
            // Ép trạng thái "Đã chọn" cho nút (để hiện highlight màu xanh/đậm)
            btnMenuDashboard.Checked = true;
            // Tự động kích hoạt nút Dashboard khi vừa vào app 
            btnMenuDashboard_Click(btnMenuDashboard, EventArgs.Empty);
        }

        // 3. Xử lý các nút Menu trên Sidebar

        // Nút DASHBOARD 
        private void btnMenuDashboard_Click(object sender, EventArgs e)
        {
            lblPageTitle.Text = "Dashboard tổng quan";
            LoadPanel(new ucDashboard(_connStr));
        }

        // Nút QUẢN LÍ USER 
        private void btnUser_Click(object sender, EventArgs e)
        {
            lblPageTitle.Text = "Quản lý người dùng hệ thống";
            LoadPanel(new ucUser(_connStr));
        }

        // Nút QUẢN LÍ ROLE 
        private void btnRole_Click(object sender, EventArgs e)
        {
            lblPageTitle.Text = "Quản lý Role";
            LoadPanel(new ucRole(_connStr));
        }

        // Nút PHÂN QUYỀN 
        private void btnGrantRevoke_Click(object sender, EventArgs e)
        {
            lblPageTitle.Text = "Cấp và Thu hồi quyền hạn";
            LoadPanel(new ucGrantRevoke(_connStr));
        }

        // Nút XEM QUYỀN 
        private void btnViewPrivilege_Click(object sender, EventArgs e)
        {
            lblPageTitle.Text = "Kiểm tra thông tin quyền hạn";
            LoadPanel(new ucViewPrivilege(_connStr));
        }

        // Nút ĐĂNG XUẤT
        private void btnLogout_Click(object sender, EventArgs e)
        {
            msgLogout.Text = "Bạn có chắc chắn muốn đăng xuất không?";
            if (msgLogout.Show() == DialogResult.Yes)
            {
                _isLoggingOut = true;
                this.Close();
            }
        }

        private void Main_PhanHe1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!_isLoggingOut)
            {
                Application.Exit();
                Environment.Exit(0);
            }
        }

    }
}
