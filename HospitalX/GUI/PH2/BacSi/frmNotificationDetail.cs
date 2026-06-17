using System;
using System.Windows.Forms;

namespace HospitalX.GUI.PH2.BacSi
{
    public partial class frmNotificationDetail : Form
    {
        private readonly ucThongBao.NotificationRecord _record;

        public frmNotificationDetail(ucThongBao.NotificationRecord record)
        {
            _record = record;
            InitializeComponent();
            LoadRecord();
            ConfigureReadOnlyTextBox();
        }

        private void LoadRecord()
        {
            lblTitle.Text = _record.Title;
            lblLevel.Text = _record.Level.ToUpperInvariant();
            lblSender.Text = _record.Sender;
            lblTimeValue.Text = _record.Time.ToString("HH:mm · dd/MM/yyyy");
            lblLocationValue.Text = _record.Location;
            txtContent.Text = _record.Content;
            btnMarkRead.Visible = false;
        }

        private void ConfigureReadOnlyTextBox()
        {
            txtContent.Cursor = Cursors.Default;
            txtContent.TabStop = false;
            txtContent.HoverState.BorderColor = txtContent.BorderColor;
            txtContent.FocusedState.BorderColor = txtContent.BorderColor;
            txtContent.HoverState.FillColor = txtContent.FillColor;
            txtContent.FocusedState.FillColor = txtContent.FillColor;
            txtContent.Enter += (s, e) => this.ActiveControl = null;
        }

        private void btnMarkRead_Click(object sender, EventArgs e)
        {
            _record.IsRead = true;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
