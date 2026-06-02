using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace HospitalX.GUI.PH2.KyThuatVien
{
    public partial class frmKtvServiceDetail : Form
    {
        private readonly string recordId;

        public frmKtvServiceDetail(string patientName, string recordId, string serviceName, string doctorName, string timeStr, string status, string gender = "Nam", string dob = "18/09/1995")
        {
            this.recordId = recordId;
            InitializeComponent();
            if (System.IO.File.Exists(@"d:\HospitalX\image\medical-team.ico"))
            {
                this.Icon = new System.Drawing.Icon(@"d:\HospitalX\image\medical-team.ico");
            }

            // Populate data from constructor parameters
            lblHoTenVal.Text = patientName;
            lblMaHSBAVal.Text = recordId;
            lblTenDVVal.Text = serviceName;
            lblBSChiDinhVal.Text = doctorName;
            lblGioHenVal.Text = timeStr;
            lblTrangThaiVal.Text = status;
            lblGioiTinhVal.Text = gender;
            lblNgaySinhVal.Text = dob;
        }

        private void btnCloseX_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCloseFoot_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnResult_Click(object sender, EventArgs e)
        {
            Close();
            if (Main_KTV.Instance != null)
            {
                Main_KTV.Instance.SwitchToKetQua(recordId);
            }
            else
            {
                MessageBox.Show($"Chuyển sang phân hệ Nhập kết quả cho bệnh nhân mã {recordId}!", "HospitalX", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
