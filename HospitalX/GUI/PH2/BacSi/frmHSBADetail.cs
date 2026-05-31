using System;
using System.Windows.Forms;
using Guna.UI2.WinForms;

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
            msgDialog.Parent = this;
            lblHsbaId.Text = _record.Id;
            lblPatientName.Text = _record.PatientName;
            lblPatientMeta.Text = string.Format("{0} · {1}, {2} tuổi · {3}", _record.PatientCode, _record.Gender, _record.Age, _record.Department);
            lblBirthValue.Text = _record.BirthDate;
            lblCccdValue.Text = _record.CitizenId;
            lblAddressValue.Text = _record.Address;
            lblCreatedValue.Text = _record.CreatedDate.ToString("dd/MM/yyyy");
            lblAllergyValue.Text = _record.Allergy;
            lblHistoryValue.Text = _record.MedicalHistory;
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
            msgDialog.Icon = MessageDialogIcon.Information;
            msgDialog.Buttons = MessageDialogButtons.OK;
            msgDialog.Show("Đã lưu thay đổi HSBA.", "Thành công");
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
