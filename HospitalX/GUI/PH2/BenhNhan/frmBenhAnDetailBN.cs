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
                Height = 80,
                Margin = new Padding(0, 0, 0, 10),
                Width = 680
            };

            row.Controls.Add(new Label
            {
                AutoEllipsis = true,
                BackColor = Color.Transparent,
                Font = new Font("Segoe UI", 10.5f, FontStyle.Bold),
                ForeColor = Color.FromArgb(10, 42, 64),
                Location = new Point(16, 9),
                Size = new Size(400, 30),
                Text = title
            });

            row.Controls.Add(new Label
            {
                AutoEllipsis = true,
                BackColor = Color.Transparent,
                Font = new Font("Segoe UI", 9f, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 105, 85),
                Location = new Point(16, 40),
                Size = new Size(200, 25),
                Text = meta
            });

            row.Controls.Add(new Label
            {
                AutoEllipsis = true,
                BackColor = Color.Transparent,
                Font = new Font("Segoe UI", 9f),
                ForeColor = Color.FromArgb(74, 98, 92),
                Location = new Point(250, 40),
                Size = new Size(300, 25),
                Text = note
            });

            return row;
        }
    }
}
