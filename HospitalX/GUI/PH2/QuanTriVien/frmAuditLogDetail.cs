using System;
using System.Windows.Forms;

namespace HospitalX.GUI.PH2.QuanTriVien
{
    public partial class frmAuditLogDetail : Form
    {
        private readonly AuditLogRecord _record;

        public frmAuditLogDetail(AuditLogRecord record)
        {
            _record = record;
            InitializeComponent();
            BindData();
        }

        private void BindData()
        {
            lblAuditId.Text = _record.Id;
            lblHeaderMeta.Text = _record.Username + " · " + _record.ObjectName + " · " + _record.Action;
            lblTimeValue.Text = _record.Time.ToString("dd/MM/yyyy HH:mm:ss");
            lblUserValue.Text = _record.Username;
            lblActionValue.Text = _record.Action;
            lblObjectValue.Text = _record.ObjectName;
            lblRowsValue.Text = _record.RowsAffected.ToString();
            lblIpValue.Text = _record.SourceIp;
            lblPolicyValue.Text = _record.PolicyCode;
            lblResultValue.Text = _record.Success ? "Thành công" : "Thất bại";
            txtDetail.Text = _record.Detail;
        }
    }
}
