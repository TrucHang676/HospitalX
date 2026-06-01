using Guna.UI2.WinForms;
using System.Windows.Forms;

namespace HospitalX.GUI.PH2.BacSi
{
    public partial class frmPatientHistory : Form
    {
        private ucBenhNhanCuaToi.PatientRecord _patient;

        // Constructor rỗng để Visual Studio Designer render đầy đủ control.
        public frmPatientHistory()
        {
            InitializeComponent();
        }

        public frmPatientHistory(ucBenhNhanCuaToi.PatientRecord patient)
            : this()
        {
            _patient = patient;
            LoadPatient();
        }

        private void LoadPatient()
        {
            lblName.Text = _patient.Name;
            lblCode.Text = _patient.Code;
            txtAllergy.Text = _patient.Allergy;
            txtMedicalHistory.Text = _patient.MedicalHistory;
            txtFamilyHistory.Text = _patient.FamilyHistory;
            msgDialog.Parent = this;
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            _patient.Allergy = txtAllergy.Text.Trim();
            _patient.MedicalHistory = txtMedicalHistory.Text.Trim();
            _patient.FamilyHistory = txtFamilyHistory.Text.Trim();
            msgDialog.Icon = MessageDialogIcon.Information;
            msgDialog.Buttons = MessageDialogButtons.OK;
            msgDialog.Show("Đã cập nhật tiền sử bệnh.", "HospitalX");
        }
    }
}
