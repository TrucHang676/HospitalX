using Guna.UI2.WinForms;
using System.Drawing;
using System.Windows.Forms;

namespace HospitalX.GUI.PH2.BenhNhan
{
    public partial class frmBenhAnDetailBN : Form
    {
        private readonly PatientMedicalRecord record;

        public frmBenhAnDetailBN(PatientMedicalRecord record)
        {
            this.record = record;
            InitializeComponent();
            BindData();
        }

        private void BindData()
        {
            lblRecordId.Text = record.Id;
            lblHeaderMeta.Text = $"{record.PatientId} · {record.PatientName} · {record.Date:dd/MM/yyyy}";

            lblDoctorNameValue.Text = $"{record.DoctorId} · {record.DoctorName}";
            lblDoctorRoleValue.Text = record.DoctorRole;
            lblDoctorDeptValue.Text = record.Department;
            lblDoctorPhoneValue.Text = record.DoctorPhone;

            lblRecordDateValue.Text = record.Date.ToString("dd/MM/yyyy");
            txtDiagnosis.Text = record.Diagnosis;
            txtTreatment.Text = record.Treatment;
            txtConclusion.Text = record.Conclusion;

            RenderServices();
            RenderPrescriptions();
        }

        private void RenderServices()
        {
            flowServices.Controls.Clear();
            foreach (var service in record.Services)
            {
                flowServices.Controls.Add(CreateRow(
                    service.Type,
                    $"{service.Date:dd/MM/yyyy} · {service.TechnicianId}",
                    service.Result));
            }
        }

        private void RenderPrescriptions()
        {
            flowPrescriptions.Controls.Clear();
            foreach (var prescription in record.Prescriptions)
            {
                flowPrescriptions.Controls.Add(CreateRow(
                    prescription.MedicineName,
                    prescription.Date.ToString("dd/MM/yyyy"),
                    prescription.Dose));
            }
        }

        private Control CreateRow(string title, string meta, string note)
        {
            var row = new Guna2Panel
            {
                BorderColor = Color.FromArgb(205, 224, 219),
                BorderRadius = 7,
                BorderThickness = 1,
                FillColor = Color.FromArgb(250, 252, 251),
                Height = 74,
                Margin = new Padding(0, 0, 0, 8),
                Width = 445
            };

            row.Controls.Add(new Label
            {
                AutoEllipsis = true,
                BackColor = Color.Transparent,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(10, 42, 64),
                Location = new Point(14, 8),
                Size = new Size(415, 24),
                Text = title
            });

            row.Controls.Add(new Label
            {
                AutoEllipsis = true,
                BackColor = Color.Transparent,
                Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 105, 85),
                Location = new Point(14, 38),
                Size = new Size(180, 22),
                Text = meta
            });

            row.Controls.Add(new Label
            {
                AutoEllipsis = true,
                BackColor = Color.Transparent,
                Font = new Font("Segoe UI", 8.5F),
                ForeColor = Color.FromArgb(74, 98, 92),
                Location = new Point(204, 38),
                Size = new Size(225, 22),
                Text = note
            });

            return row;
        }
    }
}
