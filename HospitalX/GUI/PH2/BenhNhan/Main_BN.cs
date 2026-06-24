using Guna.UI2.WinForms;
using HospitalX.GUI.PH2.BenhNhan;
using System;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using HospitalX.DAO;

namespace HospitalX.GUI.PH2
{
    public partial class Main_BN : Form
    {
        public static Main_BN Instance { get; private set; }
        private bool _isLoggingOut = false;

        public Main_BN()
        {
            InitializeComponent();
            Instance = this;
            this.FormClosed += Main_BN_FormClosed;
            WireNavigationEvents();
            LoadPage(new ucHSCN(), "Trang chủ");
            btnHSCN.Checked = true;
            LoadPatientInfo();
        }

        public void NavigateToDichVu()
        {
            btnDV.Checked = true;
            btnHSBA.Checked = false;
            btnDT.Checked = false;
            btnHSCN.Checked = false;
            LoadPage(new ucDichVuBN(), "Dịch vụ");
        }

        public void NavigateToDonThuoc()
        {
            btnDT.Checked = true;
            btnHSBA.Checked = false;
            btnDV.Checked = false;
            btnHSCN.Checked = false;
            LoadPage(new ucDonThuocBN(), "Đơn thuốc");
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
                confirmDialog.Style = Guna.UI2.WinForms.MessageDialogStyle.Light;
                confirmDialog.Icon = MessageDialogIcon.Question;
                confirmDialog.Buttons = MessageDialogButtons.YesNo;
                confirmDialog.Caption = "Xác nhận đăng xuất";
                confirmDialog.Text = "Bạn có chắc chắn muốn đăng xuất không?";

                if (confirmDialog.Show() == DialogResult.Yes)
                {
                    _isLoggingOut = true;
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

        private void Main_BN_FormClosed(object sender, FormClosedEventArgs e)
        {
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

        public void LoadPatientInfo()
        {
            try
            {
                OracleParameter[] selfParams = new OracleParameter[]
                {
                    new OracleParameter("p_cursor", OracleDbType.RefCursor) { Direction = ParameterDirection.Output }
                };
                System.Data.DataTable dt = DataProvider.Instance.ExecuteQuery("ADMINHOS.SP_GET_PATIENT_SELF", selfParams, true);
                if (dt != null && dt.Rows.Count > 0)
                {
                    System.Data.DataRow row = dt.Rows[0];
                    string name = row["TENBN"]?.ToString() ?? "";
                    string phai = row["PHAI"]?.ToString() ?? "";
                    DateTime dob = row["NGAYSINH"] != DBNull.Value ? Convert.ToDateTime(row["NGAYSINH"]) : DateTime.Today;
                    
                    int age = DateTime.Today.Year - dob.Year;
                    if (dob.Date > DateTime.Today.AddYears(-age)) age--;

                    lblTenBN.Text = "BN. " + name;
                    lblPhai_Tuoi.Text = $"{phai}, {age} tuổi";
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error loading patient header info: " + ex.Message);
            }
        }
    }
}
