using Guna.UI2.WinForms;
using System;
using System.Windows.Forms;

namespace HospitalX.GUI.PH2.BacSi
{
    public partial class frmHSBADetail : Form
    {
        private readonly ucHSBA.HsbaRecord _record;
        private string _originalDiagnosis;
        private string _originalTreatment;
        private string _originalConclusion;
        private bool _isLoadingRecord;

        public frmHSBADetail(ucHSBA.HsbaRecord record)
        {
            _record = record;
            InitializeComponent();
            LoadRecord();
            WireChangeTracking();
        }

        private void LoadRecord()
        {
            _isLoadingRecord = true;
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
            _originalDiagnosis = txtDiagnosis.Text.Trim();
            _originalTreatment = txtTreatment.Text.Trim();
            _originalConclusion = txtConclusion.Text.Trim();
            lstServices.Items.Clear();
            lstServices.Items.AddRange(_record.Services.ToArray());
            lstPrescriptions.Items.Clear();
            lstPrescriptions.Items.AddRange(_record.Prescriptions.ToArray());
            UpdateSaveButtonState();
            _isLoadingRecord = false;
        }

        private void WireChangeTracking()
        {
            txtDiagnosis.TextChanged += EditableFieldChanged;
            txtTreatment.TextChanged += EditableFieldChanged;
            txtConclusion.TextChanged += EditableFieldChanged;
        }

        private void EditableFieldChanged(object sender, EventArgs e)
        {
            if (_isLoadingRecord)
            {
                return;
            }

            UpdateSaveButtonState();
        }

        private bool HasPendingChanges()
        {
            return !string.Equals(txtDiagnosis.Text.Trim(), _originalDiagnosis, StringComparison.Ordinal)
                || !string.Equals(txtTreatment.Text.Trim(), _originalTreatment, StringComparison.Ordinal)
                || !string.Equals(txtConclusion.Text.Trim(), _originalConclusion, StringComparison.Ordinal);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string chanDoan = txtDiagnosis.Text.Trim();
            string dieuTri = txtTreatment.Text.Trim();
            string ketLuan = txtConclusion.Text.Trim();

            try
            {
                bool success = HospitalX.DAO.HsbaDAO.UpdateHsbaDetails(_record.Id, chanDoan, dieuTri, ketLuan);
                if (success)
                {
                    _record.Diagnosis = chanDoan;
                    _record.Treatment = dieuTri;
                    _record.Conclusion = ketLuan;
                    _originalDiagnosis = _record.Diagnosis;
                    _originalTreatment = _record.Treatment;
                    _originalConclusion = _record.Conclusion;
                    UpdateSaveButtonState();
                    msgDialog.Icon = MessageDialogIcon.Information;
                    msgDialog.Buttons = MessageDialogButtons.OK;
                    msgDialog.Show("Đã lưu thay đổi HSBA.", "Thành công");
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    msgDialog.Icon = MessageDialogIcon.Error;
                    msgDialog.Buttons = MessageDialogButtons.OK;
                    msgDialog.Show("Lưu thay đổi HSBA thất bại. Vui lòng kiểm tra lại quyền hạn.", "Lỗi");
                }
            }
            catch (Exception ex)
            {
                msgDialog.Icon = MessageDialogIcon.Error;
                msgDialog.Buttons = MessageDialogButtons.OK;
                msgDialog.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message, "Lỗi");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void UpdateSaveButtonState()
        {
            bool hasChanges = HasPendingChanges();
            btnSave.Visible = true;
            btnSave.Enabled = hasChanges;
            btnSave.Cursor = hasChanges ? Cursors.Hand : Cursors.Default;
        }
    }
}
