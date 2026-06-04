using Guna.UI2.WinForms;
using HospitalX.GUI.PH2.BenhNhan;
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
            LoadPage(new ucHSCN(), "Trang chủ");
            btnHSCN.Checked = true;
        }

        // Gắn sự kiện điều hướng cho các nút sidebar.
        private void WireNavigationEvents()
        {
            btnHSBA.Click += BtnHSBA_Click;
            btnDV.Click += BtnDV_Click;
            btnDT.Click += BtnDT_Click;
            btnHSCN.Click += BtnHSCN_Click;
            btnLogout.Click += BtnLogout_Click;
        }

        private void BtnHSCN_Click(object sender, EventArgs e)
        {
            LoadPage(new ucHSCN(), "Hồ sơ cá nhân");
        }

        private void BtnHSBA_Click(object sender, EventArgs e)
        {
            LoadPage(new ucBenhAnBN(), "Hồ sơ bệnh án");
        }

        private void BtnDV_Click(object sender, EventArgs e)
        {
            LoadPage(new ucDichVuBN(), "Dịch vụ");
        }

        private void BtnDT_Click(object sender, EventArgs e)
        {
            LoadPage(new ucDonThuocBN(), "Đơn thuốc");
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
                    Close();
                }
            }
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
