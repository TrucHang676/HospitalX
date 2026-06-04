using System;
using System.Windows.Forms;

namespace HospitalX.GUI.PH2.BacSi
{
    public partial class frmPrescriptionDetail : Form
    {
        private readonly ucDonThuoc.PrescriptionRecord _record;
        private ucDonThuoc.DrugRecord _selectedDrug;
        private bool _changed;
        private bool _isLoadingDrug;

        public frmPrescriptionDetail(ucDonThuoc.PrescriptionRecord record)
        {
            _record = record;
            InitializeComponent();
            LoadRecord();
            WireInputState();
            ClearInputs();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (_changed)
            {
                DialogResult = DialogResult.OK;
            }

            base.OnFormClosing(e);
        }

        private void LoadRecord()
        {
            lblHsbaId.Text = _record.HsbaId;
            lblMeta.Text = string.Format("{0} · {1:dd/MM/yyyy}", _record.PatientName, _record.CreatedDate);
            RefreshGrid();
        }

        private void RefreshGrid()
        {
            _isLoadingDrug = true;
            dgvDrugs.Rows.Clear();
            foreach (ucDonThuoc.DrugRecord drug in _record.Drugs)
            {
                int rowIndex = dgvDrugs.Rows.Add(drug.Name, drug.Dose);
                dgvDrugs.Rows[rowIndex].Tag = drug;
            }
            dgvDrugs.ClearSelection();
            dgvDrugs.CurrentCell = null;
            _selectedDrug = null;
            _isLoadingDrug = false;
        }

        private void dgvDrugs_SelectionChanged(object sender, EventArgs e)
        {
            if (_isLoadingDrug)
            {
                return;
            }

            LoadSelectedDrug();
        }

        private void LoadSelectedDrug()
        {
            if (dgvDrugs.CurrentRow == null || dgvDrugs.CurrentRow.Tag == null)
            {
                _selectedDrug = null;
                UpdateActionButtons();
                return;
            }

            _isLoadingDrug = true;
            _selectedDrug = (ucDonThuoc.DrugRecord)dgvDrugs.CurrentRow.Tag;
            txtMedicineName.Text = _selectedDrug.Name;
            txtDose.Text = _selectedDrug.Dose;
            _isLoadingDrug = false;
            UpdateActionButtons();
        }

        private void WireInputState()
        {
            txtMedicineName.TextChanged += PrescriptionInputChanged;
            txtDose.TextChanged += PrescriptionInputChanged;
        }

        private void PrescriptionInputChanged(object sender, EventArgs e)
        {
            if (_isLoadingDrug)
            {
                return;
            }

            UpdateActionButtons();
        }

        private void UpdateActionButtons()
        {
            bool hasCompleteInput = HasCompleteInput();
            bool hasSelectedDrug = _selectedDrug != null;
            bool canUpdate = hasSelectedDrug && hasCompleteInput && SelectedDrugChanged();

            SetActionButtonState(btnAdd, !hasSelectedDrug && hasCompleteInput);
            SetActionButtonState(btnUpdate, canUpdate);
            SetActionButtonState(btnDelete, hasSelectedDrug && !canUpdate);
            btnNewMedicine.Visible = true;
        }

        private void SetActionButtonState(Control button, bool enabled)
        {
            button.Visible = true;
            button.Enabled = enabled;
            button.Cursor = enabled ? Cursors.Hand : Cursors.Default;
        }

        private bool HasCompleteInput()
        {
            return !string.IsNullOrWhiteSpace(txtMedicineName.Text)
                && !string.IsNullOrWhiteSpace(txtDose.Text);
        }

        private bool SelectedDrugChanged()
        {
            if (_selectedDrug == null)
            {
                return false;
            }

            return !string.Equals(txtMedicineName.Text.Trim(), _selectedDrug.Name, StringComparison.Ordinal)
                || !string.Equals(txtDose.Text.Trim(), _selectedDrug.Dose, StringComparison.Ordinal);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMedicineName.Text))
            {
                msgDialog.Icon = Guna.UI2.WinForms.MessageDialogIcon.Warning;
                msgDialog.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                msgDialog.Show("Vui lòng nhập tên thuốc.", "Thiếu thông tin");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDose.Text))
            {
                msgDialog.Icon = Guna.UI2.WinForms.MessageDialogIcon.Warning;
                msgDialog.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                msgDialog.Show("Vui lòng nhập liều lượng.", "Thiếu thông tin");
                return;
            }

            _record.Drugs.Add(new ucDonThuoc.DrugRecord(txtMedicineName.Text.Trim(), txtDose.Text.Trim()));
            _changed = true;
            RefreshGrid();
            ClearInputs();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvDrugs.CurrentRow == null || dgvDrugs.CurrentRow.Tag == null)
            {
                return;
            }

            var drug = (ucDonThuoc.DrugRecord)dgvDrugs.CurrentRow.Tag;
            if (string.IsNullOrWhiteSpace(txtMedicineName.Text) || string.IsNullOrWhiteSpace(txtDose.Text))
            {
                msgDialog.Icon = Guna.UI2.WinForms.MessageDialogIcon.Warning;
                msgDialog.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                msgDialog.Show("Vui lòng nhập đầy đủ tên thuốc và liều lượng.", "Thiếu thông tin");
                return;
            }

            drug.Name = txtMedicineName.Text.Trim();
            drug.Dose = txtDose.Text.Trim();
            _changed = true;
            RefreshGrid();
            ClearInputs();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvDrugs.CurrentRow == null || dgvDrugs.CurrentRow.Tag == null)
            {
                return;
            }

            var drug = (ucDonThuoc.DrugRecord)dgvDrugs.CurrentRow.Tag;
            _record.Drugs.Remove(drug);
            _changed = true;
            RefreshGrid();
            ClearInputs();
        }

        private void btnNewMedicine_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void ClearInputs()
        {
            _isLoadingDrug = true;
            _selectedDrug = null;
            dgvDrugs.ClearSelection();
            dgvDrugs.CurrentCell = null;
            txtMedicineName.Clear();
            txtDose.Clear();
            _isLoadingDrug = false;
            UpdateActionButtons();
            txtMedicineName.Focus();
        }

    }
}
