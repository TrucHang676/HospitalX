using HospitalX.GUI.PH2.BacSi;
using System;
using System.Windows.Forms;

namespace HospitalX.GUI.PH2
{
    public partial class Main_BS : Form
    {
        public Main_BS()
        {
            InitializeComponent();
            WireNavigationEvents();
            LoadPage(new ucTongQuan(), "Bảng điều khiển");
            btnTongQuan.Checked = true;
        }

        // Gắn sự kiện điều hướng cho các nút sidebar.
        private void WireNavigationEvents()
        {
            btnTongQuan.Click += BtnTongQuan_Click;
            btnHSBA.Click += BtnHSBA_Click;
            btnBN.Click += (s, e) => SetPageTitle("Bệnh nhân của tôi");
            btnDT.Click += (s, e) => SetPageTitle("Đơn thuốc");
            btnThongBao.Click += (s, e) => SetPageTitle("Thông báo");
            btnHSCN.Click += BtnHSCN_Click;
        }

        private void BtnTongQuan_Click(object sender, EventArgs e)
        {
            LoadPage(new ucTongQuan(), "Bảng điều khiển");
        }

        private void BtnHSBA_Click(object sender, EventArgs e)
        {
            LoadPage(new ucHSBA(), "Hồ sơ bệnh án");
        }

        private void BtnHSCN_Click(object sender, EventArgs e)
        {
            LoadPage(new ucHSCN(), "Hồ sơ cá nhân");
        }

        // Load UserControl vào vùng nội dung chính.
        private void LoadPage(UserControl control, string title)
        {
            pnlContent.Controls.Clear();
            control.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(control);
            SetPageTitle(title);
        }

        private void SetPageTitle(string title)
        {
            lblPageTitle.Text = title;
        }
    }
}
