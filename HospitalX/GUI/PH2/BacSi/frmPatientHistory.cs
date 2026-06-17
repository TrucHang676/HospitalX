using Guna.UI2.WinForms;
using System;
using System.Windows.Forms;

namespace HospitalX.GUI.PH2.BacSi
{
    public partial class frmPatientHistory : Form
    {
        private ucBenhNhanCuaToi.PatientRecord _patient;
        private string _originalAllergy;
        private string _originalMedicalHistory;
        private string _originalFamilyHistory;
        private bool _isLoadingPatient;

        // Constructor rỗng để Visual Studio Designer render đầy đủ control.
        public frmPatientHistory()
        {
            InitializeComponent();
            WireChangeTracking();
        }

        public frmPatientHistory(ucBenhNhanCuaToi.PatientRecord patient)
            : this()
        {
            _patient = patient;
            LoadPatient();
        }

        private void LoadPatient()
        {
            _isLoadingPatient = true;
            lblName.Text = _patient.Name;
            lblCode.Text = _patient.Code;
            txtAllergy.Text = _patient.Allergy;
            txtMedicalHistory.Text = _patient.MedicalHistory;
            txtFamilyHistory.Text = _patient.FamilyHistory;
            _originalAllergy = txtAllergy.Text.Trim();
            _originalMedicalHistory = txtMedicalHistory.Text.Trim();
            _originalFamilyHistory = txtFamilyHistory.Text.Trim();
            UpdateSaveButtonState();
            msgDialog.Parent = this;
            _isLoadingPatient = false;
        }

        private void WireChangeTracking()
        {
            txtAllergy.TextChanged += EditableFieldChanged;
            txtMedicalHistory.TextChanged += EditableFieldChanged;
            txtFamilyHistory.TextChanged += EditableFieldChanged;
        }

        private void EditableFieldChanged(object sender, EventArgs e)
        {
            if (_isLoadingPatient)
            {
                return;
            }

            UpdateSaveButtonState();
        }

        private void UpdateSaveButtonState()
        {
            bool canSave = HasPendingChanges();
            btnSave.Visible = true;
            btnSave.Enabled = canSave;
            btnSave.Cursor = canSave ? Cursors.Hand : Cursors.Default;
        }

        private bool HasPendingChanges()
        {
            return !string.Equals(txtAllergy.Text.Trim(), _originalAllergy, StringComparison.Ordinal)
                || !string.Equals(txtMedicalHistory.Text.Trim(), _originalMedicalHistory, StringComparison.Ordinal)
                || !string.Equals(txtFamilyHistory.Text.Trim(), _originalFamilyHistory, StringComparison.Ordinal);
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            if (!HasPendingChanges())
            {
                UpdateSaveButtonState();
                return;
            }

            string allergy = txtAllergy.Text.Trim();
            string medicalHistory = txtMedicalHistory.Text.Trim();
            string familyHistory = txtFamilyHistory.Text.Trim();

            try
            {
                bool success = HospitalX.DAO.PatientDAO.UpdatePatientHistory(_patient.Code, allergy, medicalHistory, familyHistory);
                if (success)
                {
                    _patient.Allergy = allergy;
                    _patient.MedicalHistory = medicalHistory;
                    _patient.FamilyHistory = familyHistory;
                    _originalAllergy = _patient.Allergy;
                    _originalMedicalHistory = _patient.MedicalHistory;
                    _originalFamilyHistory = _patient.FamilyHistory;
                    UpdateSaveButtonState();
                    msgDialog.Icon = MessageDialogIcon.Information;
                    msgDialog.Buttons = MessageDialogButtons.OK;
                    msgDialog.Show("Đã cập nhật tiền sử bệnh thành công.", "HospitalX");
                }
                else
                {
                    msgDialog.Icon = MessageDialogIcon.Error;
                    msgDialog.Buttons = MessageDialogButtons.OK;
                    msgDialog.Show("Cập nhật tiền sử bệnh thất bại. Vui lòng kiểm tra lại quyền hạn.", "Lỗi");
                }
            }
            catch (Exception ex)
            {
                msgDialog.Icon = MessageDialogIcon.Error;
                msgDialog.Buttons = MessageDialogButtons.OK;
                msgDialog.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message, "Lỗi");
            }
        }
    }
}
