using Guna.UI2.WinForms;
using HospitalX.GUI.PH2.BacSi;
using System;
using System.Windows.Forms;

namespace HospitalX.GUI.PH2
{
    public partial class Main_BN : Form
    {
        public Main_BN()
        {
            InitializeComponent();
            WireNavigationEvents();
            LoadPage(CreateTongQuanPage(), "Bảng điều khiển");
            btnTongQuan.Checked = true;
        }

        // Gắn sự kiện điều hướng cho các nút sidebar.
        private void WireNavigationEvents()
        {
            btnTongQuan.Click += BtnTongQuan_Click;
            btnHSBA.Click += BtnHSBA_Click;
            btnBN.Click += BtnBN_Click;
            btnDT.Click += BtnDT_Click;
            btnThongBao.Click += BtnThongBao_Click;
            btnHSCN.Click += BtnHSCN_Click;
            btnLogout.Click += BtnLogout_Click;
        }

        private void BtnTongQuan_Click(object sender, EventArgs e)
        {
            LoadPage(CreateTongQuanPage(), "Bảng điều khiển");
        }

        private void BtnHSBA_Click(object sender, EventArgs e)
        {
            NavigateToHsbaPage();
        }

        private void BtnBN_Click(object sender, EventArgs e)
        {
            LoadPage(new ucBenhNhanCuaToi(), "Bệnh nhân của tôi");
        }

        private void BtnDT_Click(object sender, EventArgs e)
        {
            LoadPage(new ucDonThuoc(), "Đơn thuốc");
        }

        private void BtnThongBao_Click(object sender, EventArgs e)
        {
            LoadPage(new ucThongBao(), "Thông báo");
        }

        private void BtnHSCN_Click(object sender, EventArgs e)
        {
            LoadPage(new ucHSCN(), "Hồ sơ cá nhân");
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

        private ucTongQuan CreateTongQuanPage()
        {
            var page = new ucTongQuan();
            page.ViewAllHsbaRequested += (s, e) => NavigateToHsbaPage();
            return page;
        }

        private void NavigateToHsbaPage()
        {
            btnHSBA.Checked = true;
            LoadPage(new ucHSBA(), "Hồ sơ bệnh án");
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
