using System;
using System.Windows.Forms;
using Guna.UI2.WinForms;

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
            WireInputState();
        }

        private void LoadRecord()
        {
            msgDialog.Parent = this;
            lblTitle.Text = "Thêm đơn thuốc";
            lblHsbaId.Text = _record.Id;
            lblPatient.Text = _record.PatientName + " · " + _record.PatientCode;
            RefreshPrescriptions();
            ResetInputFields();
        }

        private void RefreshPrescriptions()
        {
            lstCurrentPrescriptions.Items.Clear();
            lstCurrentPrescriptions.Items.AddRange(_record.Prescriptions.ToArray());
        }

        private void WireInputState()
        {
            txtMedicineName.TextChanged += PrescriptionInputChanged;
            txtDose.TextChanged += PrescriptionInputChanged;
        }

        private void PrescriptionInputChanged(object sender, EventArgs e)
        {
            UpdateAddButtonVisibility();
        }

        private void UpdateAddButtonVisibility()
        {
            btnAdd.Visible = HasCompletePrescriptionInput();
        }

        private bool HasCompletePrescriptionInput()
        {
            return !string.IsNullOrWhiteSpace(txtMedicineName.Text)
                && !string.IsNullOrWhiteSpace(txtDose.Text);
        }

        private void ResetInputFields()
        {
            txtMedicineName.Clear();
            txtDose.Clear();
            UpdateAddButtonVisibility();
            txtMedicineName.Focus();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string medicine = txtMedicineName.Text.Trim();
            string dose = txtDose.Text.Trim();

            if (string.IsNullOrWhiteSpace(medicine))
            {
                msgDialog.Icon = MessageDialogIcon.Warning;
                msgDialog.Buttons = MessageDialogButtons.OK;
                msgDialog.Show("Vui lòng nhập tên thuốc.", "Thiếu thông tin");
                return;
            }

            if (string.IsNullOrWhiteSpace(dose))
            {
                msgDialog.Icon = MessageDialogIcon.Warning;
                msgDialog.Buttons = MessageDialogButtons.OK;
                msgDialog.Show("Vui lòng nhập liều dùng.", "Thiếu thông tin");
                return;
            }

            _record.Prescriptions.Add(medicine + " - " + dose);
            ResetInputFields();
            RefreshPrescriptions();
            msgDialog.Icon = MessageDialogIcon.Information;
            msgDialog.Buttons = MessageDialogButtons.OK;
            msgDialog.Show("Đã thêm thuốc vào đơn hiện tại.", "Thành công");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
