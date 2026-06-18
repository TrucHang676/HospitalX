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
            ClientSize = new Size(800, 470);
            pnlHeader.Height = 82;
            pnlBody.Location = new Point(0, 82);
            pnlBody.Size = new Size(800, 388);
            btnExit.Location = new Point(750, 16);

            lblAuditId.BackColor = Color.Transparent;
            lblAuditId.Location = new Point(28, 15);
            lblAuditId.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblAuditId.Text = "Chi tiết kiểm toán";

            lblHeaderMeta.BackColor = Color.Transparent;
            lblHeaderMeta.Location = new Point(30, 52);
            lblHeaderMeta.Size = new Size(700, 22);
            lblHeaderMeta.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);

            foreach (Control control in pnlBody.Controls)
            {
                Label label = control as Label;
                if (label != null)
                {
                    if (label.Name.EndsWith("Value"))
                    {
                        label.BackColor = Color.FromArgb(247, 249, 248);
                    }
                    else
                    {
                        label.BackColor = Color.White;
                    }
                }
            }

            // Set column 1 locations & sizes (X = 32, Width = 224)
            lblTime.Location = new Point(32, 28);
            lblTimeValue.Location = new Point(32, 50);
            lblTimeValue.Size = new Size(224, 26);

            lblObject.Location = new Point(32, 98);
            lblObjectValue.Location = new Point(32, 120);
            lblObjectValue.Size = new Size(224, 26);

            lblPolicy.Location = new Point(32, 168);
            lblPolicyValue.Location = new Point(32, 190);
            lblPolicyValue.Size = new Size(224, 26);

            // Set column 2 locations & sizes (X = 288, Width = 224)
            lblUser.Location = new Point(288, 28);
            lblUserValue.Location = new Point(288, 50);
            lblUserValue.Size = new Size(224, 26);

            lblRows.Location = new Point(288, 98);
            lblRowsValue.Location = new Point(288, 120);
            lblRowsValue.Size = new Size(224, 26);

            lblResult.Location = new Point(288, 168);
            lblResultValue.Location = new Point(288, 190);
            lblResultValue.Size = new Size(224, 26);

            // Set column 3 locations & sizes (X = 544, Width = 224)
            lblAction.Location = new Point(544, 28);
            lblAction.Size = new Size(224, 20);
            lblActionValue.Location = new Point(544, 50);
            lblActionValue.Size = new Size(224, 26);

            lblIp.Location = new Point(544, 98);
            lblIp.Size = new Size(224, 20);
            lblIpValue.Location = new Point(544, 120);
            lblIpValue.Size = new Size(224, 26);

            lblDetail.Location = new Point(32, 238);
            txtDetail.Location = new Point(32, 262);
            txtDetail.Size = new Size(736, 102);

            // Rename labels to show error code and terminal
            lblRows.Text = "MÃ LỖI";
            lblIp.Text = "TERMINAL";
        }

        private void BindData()
        {
            lblHeaderMeta.Text = _record.Id + " · " + _record.Username + " · " + _record.ObjectName + " · " + _record.Action;
            lblTimeValue.Text = _record.Time.ToString("dd/MM/yyyy HH:mm:ss");
            lblUserValue.Text = _record.Username;
            lblActionValue.Text = _record.Action;
            lblObjectValue.Text = _record.ObjectName;
            lblRowsValue.Text = _record.ErrorCode;
            lblIpValue.Text = _record.Terminal;
            lblPolicyValue.Text = string.IsNullOrEmpty(_record.PolicyName) || _record.PolicyName == "-" ? "-" : _record.PolicyName;
            lblResultValue.Text = _record.Result;
            
            if (_record.Result == "Thành công" || _record.Result == "Ghi nhận FGA" || _record.Result == "Thanh cong" || _record.Result == "Ghi nhan FGA")
            {
                lblResultValue.ForeColor = Color.FromArgb(22, 163, 74); // green
            }
            else if (_record.Result == "Cảnh báo" || _record.Result == "Canh bao")
            {
                lblResultValue.ForeColor = Color.FromArgb(217, 119, 6); // amber/orange
            }
            else
            {
                lblResultValue.ForeColor = Color.FromArgb(220, 38, 38); // red
            }

            txtDetail.Text = _record.Detail;
        }
    }
}
