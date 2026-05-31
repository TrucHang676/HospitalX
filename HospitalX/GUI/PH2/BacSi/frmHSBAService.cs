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
        }

        private void LoadRecord()
        {
            msgDialog.Parent = this;
            lblTitle.Text = "Thêm dịch vụ";
            lblHsbaId.Text = _record.Id;
            lblPatient.Text = _record.PatientName + " · " + _record.PatientCode;
            RefreshServices();
        }

        private void RefreshServices()
        {
            lstCurrentServices.Items.Clear();
            lstCurrentServices.Items.AddRange(_record.Services.ToArray());
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

            _record.Services.Add(string.IsNullOrWhiteSpace(note) ? serviceName + " - Chờ kết quả" : serviceName + " - " + note);
            txtServiceName.Clear();
            txtServiceNote.Clear();
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
