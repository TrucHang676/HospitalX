using System;
using System.Windows.Forms;

namespace HospitalX.GUI.PH2.BacSi
{
    public partial class frmPrescriptionDetail : Form
    {
        private readonly ucDonThuoc.PrescriptionRecord _record;
        private bool _changed;

        public frmPrescriptionDetail(ucDonThuoc.PrescriptionRecord record)
        {
            _record = record;
            InitializeComponent();
            LoadRecord();
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
            lblMeta.Text = string.Format("{0} · {1} · {2:dd/MM/yyyy}", _record.HsbaId, _record.PatientName, _record.CreatedDate);
            RefreshGrid();
        }

        private void RefreshGrid()
        {
            dgvDrugs.Rows.Clear();
            foreach (ucDonThuoc.DrugRecord drug in _record.Drugs)
            {
                int rowIndex = dgvDrugs.Rows.Add(drug.Name, drug.Dose, drug.Instruction, drug.Days, drug.IsWarning ? "Có" : "");
                dgvDrugs.Rows[rowIndex].Tag = drug;
            }
        }

        private void dgvDrugs_SelectionChanged(object sender, EventArgs e)
        {
            LoadSelectedDrug();
        }

        private void LoadSelectedDrug()
        {
            if (dgvDrugs.CurrentRow == null || dgvDrugs.CurrentRow.Tag == null)
            {
                return;
            }

            var drug = (ucDonThuoc.DrugRecord)dgvDrugs.CurrentRow.Tag;
            txtMedicineName.Text = drug.Name;
            txtDose.Text = drug.Dose;
            txtInstruction.Text = drug.Instruction;
            numDays.Value = Math.Max(numDays.Minimum, Math.Min(numDays.Maximum, drug.Days));
            chkWarning.Checked = drug.IsWarning;
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

            _record.Drugs.Add(new ucDonThuoc.DrugRecord(txtMedicineName.Text.Trim(), txtDose.Text.Trim(), txtInstruction.Text.Trim(), (int)numDays.Value, chkWarning.Checked));
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
            drug.Name = txtMedicineName.Text.Trim();
            drug.Dose = txtDose.Text.Trim();
            drug.Instruction = txtInstruction.Text.Trim();
            drug.Days = (int)numDays.Value;
            drug.IsWarning = chkWarning.Checked;
            _changed = true;
            RefreshGrid();
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

        private void ClearInputs()
        {
            txtMedicineName.Clear();
            txtDose.Clear();
            txtInstruction.Clear();
            numDays.Value = 30;
            chkWarning.Checked = false;
        }
    }
}
