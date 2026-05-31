using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace HospitalX.GUI.PH2.DieuPhoiVien
{
    public partial class frmChiTietBN : Form
    {
        private PatientModel _patient;

        /// <summary>Kết quả hành động khi đóng form.</summary>
        public enum ActionResult { None, EditPatient, ViewHSBA }
        public ActionResult Result { get; private set; } = ActionResult.None;

        public frmChiTietBN()
        {
            InitializeComponent();
        }

        public frmChiTietBN(PatientModel patient) : this()
        {
            _patient = patient;
            LoadPatient();
            ApplyButtonIcons();
        }

        private void LoadPatient()
        {
            // Header
            lblName.Text = _patient.Name;
            lblCode.Text = _patient.Id;

            // Info rows — built programmatically like frmPatientDetail (BacSi)
            int leftX = 28;
            int rightX = 274;

            AddInfo("Mã bệnh nhân", _patient.Id, leftX, 56, true);
            AddInfo("CCCD", _patient.Cccd, rightX, 56, true);

            AddInfo("Họ và tên", _patient.Name, leftX, 136, false);
            AddInfo("Ngày sinh", _patient.Dob, rightX, 136, false);

            AddInfo("Giới tính", _patient.Gender, leftX, 216, false);
            AddInfo("Ngày nhập viện", _patient.Date, rightX, 216, false);

            AddInfo("Khoa điều trị", _patient.Khoa, leftX, 296, false);
            AddInfo("Bác sĩ phụ trách", _patient.Bs, rightX, 296, false);

            // Status pill — custom paint
            var lblStatusCap = new Label
            {
                Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(122, 149, 137),
                Location = new Point(leftX, 376),
                Text = "TRẠNG THÁI",
                BackColor = Color.Transparent,
                AutoSize = true
            };
            pnlInfo.Controls.Add(lblStatusCap);

            var pnlPill = new Panel
            {
                Size = new Size(200, 26),
                Location = new Point(leftX, 396),
                BackColor = Color.Transparent
            };

            GetStatusColors(_patient.StatusLabel, out Color pillBack, out Color pillFore, out Color dotColor);

            pnlPill.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                string text = _patient.StatusLabel;
                int textW = TextRenderer.MeasureText(e.Graphics, text, new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold),
                    Size.Empty, TextFormatFlags.NoPadding | TextFormatFlags.SingleLine).Width;
                int pillW = Math.Max(textW + 36, 80);
                int pillH = 24;

                using (var path = new GraphicsPath())
                {
                    int r = 12;
                    path.AddArc(0, 0, r * 2, r * 2, 180, 90);
                    path.AddArc(pillW - r * 2, 0, r * 2, r * 2, 270, 90);
                    path.AddArc(pillW - r * 2, pillH - r * 2, r * 2, r * 2, 0, 90);
                    path.AddArc(0, pillH - r * 2, r * 2, r * 2, 90, 90);
                    path.CloseFigure();
                    using (var brush = new SolidBrush(pillBack))
                        e.Graphics.FillPath(brush, path);
                }
                using (var dotBrush = new SolidBrush(dotColor))
                    e.Graphics.FillEllipse(dotBrush, 10, 8, 8, 8);
            };
            pnlPill.Controls.Add(new Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold),
                ForeColor = pillFore,
                Location = new Point(22, 4),
                BackColor = Color.Transparent,
                Text = _patient.StatusLabel
            });
            pnlInfo.Controls.Add(pnlPill);
        }

        private void AddInfo(string label, string value, int x, int y, bool mono)
        {
            var lbl = new Label
            {
                Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(122, 149, 137),
                Location = new Point(x, y),
                Text = label.ToUpper(),
                BackColor = Color.Transparent,
                AutoSize = true
            };
            var val = new Label
            {
                BackColor = Color.FromArgb(247, 249, 248),
                Font = new Font(mono ? "Consolas" : "Segoe UI", 10F, FontStyle.Bold),
                ForeColor = mono ? Color.FromArgb(15, 110, 86) : Color.FromArgb(24, 48, 42),
                Location = new Point(x, y + 20),
                Padding = new Padding(10, 0, 0, 0),
                Size = new Size(220, 36),
                Text = value,
                TextAlign = ContentAlignment.MiddleLeft
            };
            pnlInfo.Controls.Add(lbl);
            pnlInfo.Controls.Add(val);
        }

        private void ApplyButtonIcons()
        {
            // Edit icon
            Image imgEdit = DpvAssets.Load("dpv_3.png");
            if (imgEdit != null)
            {
                btnEdit.Image = imgEdit;
                btnEdit.ImageSize = new Size(20, 20);
                btnEdit.ImageOffset = new Point(0, 0);
                btnEdit.TextOffset = new Point(0, 0);
            }

            // HSBA icon (Using dpv_4.png from image folder)
            Image imgHsba = DpvAssets.Load("dpv_4.png");
            if (imgHsba != null)
            {
                btnViewHsba.Image = imgHsba;
                btnViewHsba.ImageSize = new Size(20, 20);
                btnViewHsba.ImageOffset = new Point(0, 0);
                btnViewHsba.TextOffset = new Point(0, 0);
            }
        }

        private static void GetStatusColors(string status, out Color back, out Color fore, out Color dot)
        {
            back = Color.FromArgb(238, 242, 240);
            fore = Color.FromArgb(122, 149, 137);
            dot = fore;
            switch (status)
            {
                case "Đang điều trị":
                    back = Color.FromArgb(230, 244, 240);
                    fore = dot = Color.FromArgb(15, 110, 86);
                    break;
                case "Chờ xét nghiệm":
                    back = Color.FromArgb(255, 243, 224);
                    fore = dot = Color.FromArgb(230, 126, 34);
                    break;
                case "Cần điều phối KTV":
                    back = Color.FromArgb(253, 237, 236);
                    fore = dot = Color.FromArgb(192, 57, 43);
                    break;
                case "Chờ xuất viện":
                    back = Color.FromArgb(235, 245, 251);
                    fore = dot = Color.FromArgb(41, 128, 185);
                    break;
            }
        }

        // ── Button handlers ──
        private void btnEdit_Click(object sender, EventArgs e)
        {
            Result = ActionResult.EditPatient;
            this.Close();
        }

        private void btnViewHsba_Click(object sender, EventArgs e)
        {
            Result = ActionResult.ViewHSBA;
            this.Close();
        }

        private void btnCloseBottom_Click(object sender, EventArgs e)
        {
            Result = ActionResult.None;
            this.Close();
        }
    }
}
