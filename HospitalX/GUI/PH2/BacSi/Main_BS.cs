using Guna.UI2.WinForms;
using HospitalX.GUI.PH2.BacSi;
using HospitalX.GUI.PH2.DieuPhoiVien;
using HospitalX.DAO;
using System;
using System.Data;
using System.Windows.Forms;

namespace HospitalX.GUI.PH2
{
    public partial class Main_BS : Form
    {
        public Main_BS()
        {
            InitializeComponent();
            LoadUserData();
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
            LoadPage(new HospitalX.GUI.PH2.BacSi.ucThongBao(), "Thông báo");
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

        private void LoadUserData()
        {
            try
            {
                DataTable dt = ProfileDAO.Instance.GetProfile();
                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    string hoTen = row["HOTEN"]?.ToString() ?? string.Empty;
                    string phai = row["PHAI"]?.ToString() ?? string.Empty;
                    string vaiTro = row["VAITRO"]?.ToString() ?? string.Empty;
                    string chuyenKhoa = row["CHUYENKHOA"]?.ToString() ?? string.Empty;

                    lblTenBS.Text = hoTen;
                    lbl.Text = string.IsNullOrEmpty(chuyenKhoa) ? vaiTro : "Bác sĩ " + chuyenKhoa;

                    // Set gender-appropriate avatar
                    if (phai.Equals("Nam", StringComparison.OrdinalIgnoreCase))
                    {
                        ptbAdmin.Image = DpvAssets.Load("male_doctor.png");
                    }
                    else
                    {
                        ptbAdmin.Image = DpvAssets.Load("female_doctor.png");
                    }
                }
            }
            catch
            {
                // Fallback to design defaults
            }
        }

        private void btnLogout_Click_1(object sender, EventArgs e)
        {

        }
    }
}
