using Guna.UI2.WinForms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace HospitalX.GUI.PH2.BenhNhan
{
    public partial class frmDonThuocDetailBN : Form
    {
        private readonly PatientMedicalRecord record;

        public frmDonThuocDetailBN(PatientMedicalRecord record)
        {
            this.record = record;
            InitializeComponent();
            BindData();
        }

        private void BindData()
        {
            var prescriptionDate = record.Prescriptions
                .OrderByDescending(item => item.Date)
                .First()
                .Date;

            lblCode.Text = record.Id;
            lblMeta.Text = $"{record.PatientId} - {record.PatientName} - {prescriptionDate:dd/MM/yyyy}";
            lblHsbaValue.Text = record.Id;
            lblDateValue.Text = prescriptionDate.ToString("dd/MM/yyyy");
            lblCountValue.Text = $"{record.Prescriptions.Count} thuốc";
            txtDiagnosis.Text = record.Diagnosis;

            flowMedicines.Controls.Clear();
            foreach (var prescription in record.Prescriptions.OrderBy(item => item.MedicineName))
            {
                flowMedicines.Controls.Add(CreateMedicineRow(prescription));
            }
        }

        private Control CreateMedicineRow(RecordPrescription prescription)
        {
            var row = new Guna2Panel
            {
                BorderColor = Color.FromArgb(205, 224, 219),
                BorderRadius = 10,
                BorderThickness = 1,
                FillColor = Color.FromArgb(249, 252, 251),
                Height = 100,
                Margin = new Padding(0, 0, 0, 8),
                Width = 950
            };

            row.Paint += (sender, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (var brush = new SolidBrush(Color.FromArgb(0, 105, 85)))
                {
                    e.Graphics.FillRectangle(brush, 0, 12, 4, row.Height - 24);
                }
            };

            row.Controls.Add(new Label
            {
                AutoEllipsis = true,
                BackColor = Color.Transparent,
                Font = new Font("Segoe UI Semibold", 11.5f, FontStyle.Bold),
                ForeColor = Color.FromArgb(10, 42, 64),
                Location = new Point(22, 12),
                Size = new Size(360, 35),
                Text = prescription.MedicineName
            });

            row.Controls.Add(new Guna2Button
            {
                BackColor = Color.Transparent,
                BorderRadius = 8,
                CheckedState = { FillColor = Color.FromArgb(226, 245, 239) },
                DisabledState =
                {
                    FillColor = Color.FromArgb(226, 245, 239),
                    ForeColor = Color.FromArgb(0, 105, 85)
                },
                Enabled = false,
                FillColor = Color.FromArgb(226, 245, 239),
                Font = new Font("Segoe UI", 9.5f, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 105, 85),
                Location = new Point(22, 50),
                Size = new Size(136, 35),
                Text = prescription.Date.ToString("dd/MM/yyyy"),
                TextAlign = HorizontalAlignment.Center
            });

            row.Controls.Add(new Label
            {
                AutoEllipsis = true,
                BackColor = Color.Transparent,
                Font = new Font("Segoe UI", 8.5f, FontStyle.Bold),
                ForeColor = Color.FromArgb(122, 149, 137),
                Location = new Point(500, 20),
                Size = new Size(140, 35),
                Text = "LIỀU DÙNG"
            });

            row.Controls.Add(new Label
            {
                AutoEllipsis = true,
                BackColor = Color.Transparent,
                Font = new Font("Segoe UI Semibold", 10.5f, FontStyle.Bold),
                ForeColor = Color.FromArgb(24, 48, 42),
                Location = new Point(500, 50),
                Size = new Size(500, 35),
                Text = prescription.Dose
            });

            return row;
        }
    }
}
