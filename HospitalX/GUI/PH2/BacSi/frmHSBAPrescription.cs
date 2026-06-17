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
            UpdateAddButtonState();
        }

        private void UpdateAddButtonState()
        {
            bool canAdd = HasCompletePrescriptionInput();
            btnAdd.Visible = true;
            btnAdd.Enabled = canAdd;
            btnAdd.Cursor = canAdd ? Cursors.Hand : Cursors.Default;
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
            UpdateAddButtonState();
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

            try
            {
                bool success = HospitalX.DAO.HsbaDAO.InsertDonThuoc(_record.Id, medicine, dose);
                if (success)
                {
                    _record.Prescriptions.Add(medicine + " - " + dose);
                    ResetInputFields();
                    RefreshPrescriptions();
                    msgDialog.Icon = MessageDialogIcon.Information;
                    msgDialog.Buttons = MessageDialogButtons.OK;
                    msgDialog.Show("Đã thêm thuốc vào đơn hiện tại.", "Thành công");
                }
                else
                {
                    msgDialog.Icon = MessageDialogIcon.Error;
                    msgDialog.Buttons = MessageDialogButtons.OK;
                    msgDialog.Show("Thêm thuốc vào đơn thuốc thất bại. Vui lòng kiểm tra lại quyền hạn.", "Lỗi");
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
    }
}
