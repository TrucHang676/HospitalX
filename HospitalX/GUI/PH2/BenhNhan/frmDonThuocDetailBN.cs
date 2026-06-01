using Guna.UI2.WinForms;
using System.Drawing;
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
            lblMeta.Text = $"{record.PatientId} · {record.PatientName} · {prescriptionDate:dd/MM/yyyy}";
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
                BorderRadius = 7,
                BorderThickness = 1,
                FillColor = Color.FromArgb(250, 252, 251),
                Height = 62,
                Margin = new Padding(0, 0, 0, 10),
                Width = 752
            };

            row.Controls.Add(new Label
            {
                AutoEllipsis = true,
                BackColor = Color.Transparent,
                Font = new Font("Segoe UI", 11f, FontStyle.Bold),
                ForeColor = Color.FromArgb(10, 42, 64),
                Location = new Point(18, 11),
                Size = new Size(360, 24),
                Text = prescription.MedicineName
            });

            row.Controls.Add(new Label
            {
                AutoEllipsis = true,
                BackColor = Color.FromArgb(226, 245, 239),
                Font = new Font("Segoe UI", 9.5f, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 105, 85),
                Location = new Point(18, 36),
                Padding = new Padding(8, 1, 8, 1),
                Size = new Size(150, 22),
                Text = prescription.Date.ToString("dd/MM/yyyy"),
                TextAlign = ContentAlignment.MiddleCenter
            });

            row.Controls.Add(new Label
            {
                AutoEllipsis = true,
                BackColor = Color.Transparent,
                Font = new Font("Segoe UI", 10f, FontStyle.Bold),
                ForeColor = Color.FromArgb(74, 98, 92),
                Location = new Point(398, 20),
                Size = new Size(320, 24),
                Text = $"Liều dùng: {prescription.Dose}"
            });

            return row;
        }
    }
}
