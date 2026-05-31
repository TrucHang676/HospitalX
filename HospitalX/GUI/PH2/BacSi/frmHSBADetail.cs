using System;
using System.Windows.Forms;

namespace HospitalX.GUI.PH2.BacSi
{
    public partial class frmHSBADetail : Form
    {
        private readonly ucHSBA.HsbaRecord _record;

        public frmHSBADetail(ucHSBA.HsbaRecord record)
        {
            _record = record;
            InitializeComponent();
            LoadRecord();
        }

        private void LoadRecord()
        {
            lblHsbaId.Text = _record.Id;
            lblPatientName.Text = _record.PatientName;
            lblPatientMeta.Text = string.Format("{0} · {1}, {2} tuổi · {3}", _record.PatientCode, _record.Gender, _record.Age, _record.Department);
            lblInfo.Text = string.Format("Ngày sinh: {0}\r\nCCCD: {1}\r\nĐịa chỉ: {2}\r\nNgày lập HSBA: {3:dd/MM/yyyy}\r\nDị ứng: {4}\r\nTiền sử: {5}",
                _record.BirthDate, _record.CitizenId, _record.Address, _record.CreatedDate, _record.Allergy, _record.MedicalHistory);
            txtDiagnosis.Text = _record.Diagnosis;
            txtTreatment.Text = _record.Treatment;
            txtConclusion.Text = _record.Conclusion;
            lstServices.Items.Clear();
            lstServices.Items.AddRange(_record.Services.ToArray());
            lstPrescriptions.Items.Clear();
            lstPrescriptions.Items.AddRange(_record.Prescriptions.ToArray());
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _record.Diagnosis = txtDiagnosis.Text.Trim();
            _record.Treatment = txtTreatment.Text.Trim();
            _record.Conclusion = txtConclusion.Text.Trim();
            MessageBox.Show("Đã lưu thay đổi HSBA.", "HospitalX", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
