using System;
using System.Windows.Forms;

namespace HospitalX.GUI.PH2.BacSi
{
    public partial class frmHSBAPrescription : Form
    {
        private readonly ucHSBA.HsbaRecord _record;

        public frmHSBAPrescription(ucHSBA.HsbaRecord record)
        {
            _record = record;
            InitializeComponent();
            LoadRecord();
        }

        private void LoadRecord()
        {
            lblTitle.Text = "Thêm đơn thuốc - " + _record.Id;
            lblPatient.Text = _record.PatientName + " · " + _record.PatientCode;
            RefreshPrescriptions();
        }

        private void RefreshPrescriptions()
        {
            lstCurrentPrescriptions.Items.Clear();
            lstCurrentPrescriptions.Items.AddRange(_record.Prescriptions.ToArray());
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string medicine = txtMedicineName.Text.Trim();
            string dose = txtDose.Text.Trim();

            if (string.IsNullOrWhiteSpace(medicine))
            {
                MessageBox.Show("Vui lòng nhập tên thuốc.", "HospitalX", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _record.Prescriptions.Add(string.IsNullOrWhiteSpace(dose) ? medicine : medicine + " - " + dose);
            txtMedicineName.Clear();
            txtDose.Clear();
            RefreshPrescriptions();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
