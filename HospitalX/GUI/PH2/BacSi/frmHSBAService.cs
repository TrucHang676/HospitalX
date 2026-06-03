using System;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace HospitalX.GUI.PH2.BacSi
{
    public partial class frmHSBAService : Form
    {
        private readonly ucHSBA.HsbaRecord _record;

        public frmHSBAService(ucHSBA.HsbaRecord record)
        {
            _record = record;
            InitializeComponent();
            LoadRecord();
            WireInputState();
        }

        private void LoadRecord()
        {
            msgDialog.Parent = this;
            lblTitle.Text = "Thêm dịch vụ";
            lblHsbaId.Text = _record.Id;
            lblPatient.Text = _record.PatientName + " · " + _record.PatientCode;
            RefreshServices();
            ResetInputFields();
        }

        private void RefreshServices()
        {
            lstCurrentServices.Items.Clear();
            lstCurrentServices.Items.AddRange(_record.Services.ToArray());
        }

        private void WireInputState()
        {
            txtServiceName.TextChanged += ServiceInputChanged;
            txtServiceNote.TextChanged += ServiceInputChanged;
        }

        private void ServiceInputChanged(object sender, EventArgs e)
        {
            UpdateAddButtonState();
        }

        private void UpdateAddButtonState()
        {
            bool canAdd = HasCompleteServiceInput();
            btnAdd.Visible = true;
            btnAdd.Enabled = canAdd;
            btnAdd.Cursor = canAdd ? Cursors.Hand : Cursors.Default;
        }

        private bool HasCompleteServiceInput()
        {
            return !string.IsNullOrWhiteSpace(txtServiceName.Text)
                && !string.IsNullOrWhiteSpace(txtServiceNote.Text);
        }

        private void ResetInputFields()
        {
            txtServiceName.Clear();
            txtServiceNote.Clear();
            UpdateAddButtonState();
            txtServiceName.Focus();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string serviceName = txtServiceName.Text.Trim();
            string note = txtServiceNote.Text.Trim();

            if (string.IsNullOrWhiteSpace(serviceName))
            {
                msgDialog.Icon = MessageDialogIcon.Warning;
                msgDialog.Buttons = MessageDialogButtons.OK;
                msgDialog.Show("Vui lòng nhập tên dịch vụ.", "Thiếu thông tin");
                return;
            }

            if (string.IsNullOrWhiteSpace(note))
            {
                msgDialog.Icon = MessageDialogIcon.Warning;
                msgDialog.Buttons = MessageDialogButtons.OK;
                msgDialog.Show("Vui lòng nhập ghi chú hoặc kết quả ban đầu.", "Thiếu thông tin");
                return;
            }

            _record.Services.Add(serviceName + " - " + note);
            ResetInputFields();
            RefreshServices();
            msgDialog.Icon = MessageDialogIcon.Information;
            msgDialog.Buttons = MessageDialogButtons.OK;
            msgDialog.Show("Đã thêm dịch vụ vào HSBA.", "Thành công");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
