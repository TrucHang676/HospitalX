using Guna.UI2.WinForms;
using HospitalX.GUI.PH2.QuanTriVien;
using System;
using System.Windows.Forms;
using ucThongBao = HospitalX.GUI.PH2.QuanTriVien.ucThongBao;

namespace HospitalX.GUI.PH2
{
    public partial class Main_QTV : Form
    {
        public Main_QTV()
        {
            InitializeComponent();
            WireNavigationEvents();
            LoadPage(new ucTrangChu(), "Tổng quan");
            btnTongQuan.Checked = true;
        }

        // Gắn sự kiện điều hướng cho các nút sidebar.
        private void WireNavigationEvents()
        {
            btnTongQuan.Click += BtnTongQuan_Click;
            btnTB.Click += BtnTB_Click;
            btnAudit.Click += BtnAudit_Click;
            btnBvsR.Click += BtnBvsR_Click;
            btnLogout.Click += BtnLogout_Click;
        }

        private void BtnTongQuan_Click(object sender, EventArgs e)
        {
            LoadPage(new ucTrangChu(), "Tổng quan");
        }

        private void BtnBvsR_Click(object sender, EventArgs e)
        {
            LoadPage(new ucSaoLuuPhucHoi(), "Sao lưu và phục hồi dữ liệu");
        }

        private void BtnTB_Click(object sender, EventArgs e)
        {
            LoadPage(new ucThongBao(), "Thông báo");
        }

        private void BtnAudit_Click(object sender, EventArgs e)
        {
            LoadPage(new ucAudit(), "Kiểm toán");
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
