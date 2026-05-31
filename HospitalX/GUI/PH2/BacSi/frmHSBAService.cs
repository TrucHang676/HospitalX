using System;
using System.Windows.Forms;

namespace HospitalX.GUI.PH2.BacSi
{
    public partial class frmHSBAService : Form
    {
        private readonly ucHSBA.HsbaRecord _record;

        public frmHSBAService(ucHSBA.HsbaRecord record)
        {
            _record = record;
            InitializeComponent();
            LoadRecord();
        }

        private void LoadRecord()
        {
            lblTitle.Text = "Thêm dịch vụ - " + _record.Id;
            lblPatient.Text = _record.PatientName + " · " + _record.PatientCode;
            RefreshServices();
        }

        private void RefreshServices()
        {
            lstCurrentServices.Items.Clear();
            lstCurrentServices.Items.AddRange(_record.Services.ToArray());
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string serviceName = txtServiceName.Text.Trim();
            string note = txtServiceNote.Text.Trim();

            if (string.IsNullOrWhiteSpace(serviceName))
            {
                MessageBox.Show("Vui lòng nhập tên dịch vụ.", "HospitalX", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _record.Services.Add(string.IsNullOrWhiteSpace(note) ? serviceName + " - Chờ kết quả" : serviceName + " - " + note);
            txtServiceName.Clear();
            txtServiceNote.Clear();
            RefreshServices();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
