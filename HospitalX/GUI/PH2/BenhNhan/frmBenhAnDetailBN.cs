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
            AddNavigationButtons();

            // Wire up layout events to automatically fill the width when scrollbars are shown/hidden
            flowServices.Resize += (s, e) => LayoutCards();
            flowPrescriptions.Resize += (s, e) => LayoutCards();
            // Perform initial layout
            LayoutCards();
        }

        private void AddNavigationButtons()
        {
            // Nút xem chi tiết dịch vụ ở pnlServices
            var btnViewServices = new Guna2Button
            {
                Text = "Xem chi tiết",
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 105, 85),
                FillColor = Color.FromArgb(230, 245, 239),
                BorderRadius = 6,
                Cursor = Cursors.Hand,
                Size = new Size(140, 28),
                Location = new Point(pnlServices.Width - 140 - 16, 18)
            };
            btnViewServices.HoverState.FillColor = Color.FromArgb(200, 235, 225);
            btnViewServices.Click += (sender, e) =>
            {
                this.Close();
                if (Main_BN.Instance != null)
                {
                    Main_BN.Instance.NavigateToDichVu();
                }
            };
            pnlServices.Controls.Add(btnViewServices);

            // Nút xem chi tiết đơn thuốc ở pnlPrescription
            var btnViewPrescriptions = new Guna2Button
            {
                Text = "Xem chi tiết",
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 105, 85),
                FillColor = Color.FromArgb(230, 245, 239),
                BorderRadius = 6,
                Cursor = Cursors.Hand,
                Size = new Size(140, 28),
                Location = new Point(pnlPrescription.Width - 140 - 16, 18)
            };
            btnViewPrescriptions.HoverState.FillColor = Color.FromArgb(200, 235, 225);
            btnViewPrescriptions.Click += (sender, e) =>
            {
                this.Close();
                if (Main_BN.Instance != null)
                {
                    Main_BN.Instance.NavigateToDonThuoc();
                }
            };
            pnlPrescription.Controls.Add(btnViewPrescriptions);
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
                Width = 460
            };

            row.Controls.Add(new Label
            {
                AutoEllipsis = true,
                BackColor = Color.Transparent,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(10, 42, 64),
                Location = new Point(14, 8),
                Size = new Size(row.Width - 28, 24),
                Text = title,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            });

            row.Controls.Add(new Label
            {
                AutoEllipsis = true,
                BackColor = Color.Transparent,
                Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 105, 85),
                Location = new Point(14, 38),
                Size = new Size(180, 22),
                Text = meta,
                Anchor = AnchorStyles.Top | AnchorStyles.Left
            });

            row.Controls.Add(new Label
            {
                AutoEllipsis = true,
                BackColor = Color.Transparent,
                Font = new Font("Segoe UI", 8.5F),
                ForeColor = Color.FromArgb(74, 98, 92),
                Location = new Point(204, 38),
                Size = new Size(row.Width - 204 - 14, 22),
                Text = note,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            });

            return row;
        }

        private void LayoutCards()
        {
            int serviceCardWidth = flowServices.ClientSize.Width - 8;
            if (serviceCardWidth > 10)
            {
                foreach (Control card in flowServices.Controls)
                {
                    card.Width = serviceCardWidth;
                }
            }

            int prescriptionCardWidth = flowPrescriptions.ClientSize.Width - 8;
            if (prescriptionCardWidth > 10)
            {
                foreach (Control card in flowPrescriptions.Controls)
                {
                    card.Width = prescriptionCardWidth;
                }
            }
        }
    }
}
