using System.Drawing;
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
            PolishLayout();
            BindData();
        }

        private void PolishLayout()
        {
            ClientSize = new Size(700, 470);
            pnlHeader.Height = 82;
            pnlBody.Location = new Point(0, 82);
            pnlBody.Size = new Size(700, 388);
            btnClose.Location = new Point(650, 16);

            lblAuditId.BackColor = Color.Transparent;
            lblAuditId.Location = new Point(28, 15);
            lblAuditId.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblAuditId.Text = "Chi tiết kiểm toán";

            lblHeaderMeta.BackColor = Color.Transparent;
            lblHeaderMeta.Location = new Point(30, 52);
            lblHeaderMeta.Size = new Size(600, 22);
            lblHeaderMeta.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);

            foreach (Control control in pnlBody.Controls)
            {
                Label label = control as Label;
                if (label != null)
                {
                    label.BackColor = Color.Transparent;
                }
            }

            txtDetail.Size = new Size(636, 102);
        }

        private void BindData()
        {
            lblHeaderMeta.Text = _record.Id + " · " + _record.Username + " · " + _record.ObjectName + " · " + _record.Action;
            lblTimeValue.Text = _record.Time.ToString("dd/MM/yyyy HH:mm:ss");
            lblUserValue.Text = _record.Username;
            lblActionValue.Text = _record.Action;
            lblObjectValue.Text = _record.ObjectName;
            lblRowsValue.Text = _record.RowsAffected.ToString();
            lblIpValue.Text = _record.SourceIp;
            lblPolicyValue.Text = _record.PolicyCode;
            lblResultValue.Text = _record.Success ? "Thành công" : "Thất bại";
            lblResultValue.ForeColor = _record.Success ? Color.FromArgb(22, 163, 74) : Color.FromArgb(220, 38, 38);
            txtDetail.Text = _record.Detail;
        }
    }
}
