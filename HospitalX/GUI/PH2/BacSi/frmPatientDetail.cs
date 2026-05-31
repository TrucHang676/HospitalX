using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace HospitalX.GUI.PH2.BacSi
{
    public partial class frmPatientDetail : Form
    {
        private ucBenhNhanCuaToi.PatientRecord _patient;

        // Constructor rong de Visual Studio Designer render day du control.
        public frmPatientDetail()
        {
            InitializeComponent();
        }

        public frmPatientDetail(ucBenhNhanCuaToi.PatientRecord patient)
            : this()
        {
            _patient = patient;
            LoadPatient();
        }

        private void LoadPatient()
        {
            lblName.Text = _patient.Name;
            lblCode.Text = _patient.Code;
            lblPatientCodeValue.Text = _patient.Code;
            lblGenderValue.Text = _patient.Gender;
            lblAgeValue.Text = _patient.Age + " tuổi";
            lblHsbaCountValue.Text = _patient.HsbaCount.ToString();
            lblRxCountValue.Text = _patient.PrescriptionCount.ToString();
            lblHometownValue.Text = _patient.Hometown;
            lblCccdValue.Text = _patient.Cccd;

            flpHsba.Controls.Clear();
            foreach (string hsba in _patient.HsbaList)
            {
                flpHsba.Controls.Add(CreateHsbaItem(hsba));
            }
        }

        private Guna2Panel CreateHsbaItem(string hsba)
        {
            ParseHsbaText(hsba, out string code, out string date, out string diagnosis);

            var item = new Guna2Panel
            {
                BorderColor = Color.FromArgb(218, 232, 226),
                BorderRadius = 10,
                BorderThickness = 1,
                FillColor = Color.White,
                Margin = new Padding(0, 0, 0, 12),
                Size = new Size(668, 90)
            };
            item.ShadowDecoration.Enabled = true;
            item.ShadowDecoration.Color = Color.FromArgb(226, 239, 234);
            item.ShadowDecoration.Depth = 4;
            item.MouseEnter += (s, e) => item.BorderColor = Color.FromArgb(26, 148, 112);
            item.MouseLeave += (s, e) => item.BorderColor = Color.FromArgb(218, 232, 226);

            var accent = new Panel
            {
                BackColor = Color.FromArgb(15, 110, 86),
                Location = new Point(0, 0),
                Size = new Size(4, item.Height),
                Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom
            };

            var lblCode = new Label
            {
                BackColor = Color.FromArgb(230, 244, 240),
                Font = new Font("Consolas", 9.8F, FontStyle.Bold),
                ForeColor = Color.FromArgb(15, 110, 86),
                Location = new Point(22, 18),
                Size = new Size(118, 28),
                Text = code,
                TextAlign = ContentAlignment.MiddleCenter
            };

            var lblDate = new Label
            {
                AutoEllipsis = true,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = Color.FromArgb(122, 149, 137),
                Location = new Point(154, 20),
                Size = new Size(120, 24),
                Text = date,
                TextAlign = ContentAlignment.MiddleLeft
            };

            var lblDiagnosis = new Label
            {
                AutoEllipsis = true,
                Font = new Font("Segoe UI", 10.3F, FontStyle.Bold),
                ForeColor = Color.FromArgb(24, 48, 42),
                Location = new Point(22, 54),
                Size = new Size(510, 24),
                Text = diagnosis,
                TextAlign = ContentAlignment.MiddleLeft
            };

            var btnView = new Guna2Button
            {
                BorderRadius = 8,
                Cursor = Cursors.Hand,
                FillColor = Color.White,
                BorderColor = Color.FromArgb(15, 110, 86),
                BorderThickness = 1,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = Color.FromArgb(15, 110, 86),
                Location = new Point(552, 27),
                Size = new Size(88, 36),
                Text = "Xem"
            };
            btnView.HoverState.FillColor = Color.FromArgb(230, 244, 240);
            btnView.HoverState.BorderColor = Color.FromArgb(26, 148, 112);
            btnView.HoverState.ForeColor = Color.FromArgb(10, 79, 61);
            btnView.Click += (s, e) =>
            {
                OpenHsbaDetail(code, date, diagnosis);
            };

            item.Controls.Add(accent);
            item.Controls.Add(lblCode);
            item.Controls.Add(lblDate);
            item.Controls.Add(lblDiagnosis);
            item.Controls.Add(btnView);
            return item;
        }

        private static void ParseHsbaText(string hsba, out string code, out string date, out string diagnosis)
        {
            string[] parts = hsba.Split('|');
            if (parts.Length >= 3)
            {
                code = parts[0].Trim();
                date = parts[1].Trim();
                diagnosis = parts[2].Trim();
                return;
            }

            code = hsba;
            date = string.Empty;
            diagnosis = hsba;
        }

        private void OpenHsbaDetail(string code, string date, string diagnosis)
        {
            ucHSBA.HsbaRecord record = CreateHsbaRecord(code, date, diagnosis);
            using (frmHSBADetail form = new frmHSBADetail(record))
            {
                form.ShowDialog(this);
            }
        }

        private ucHSBA.HsbaRecord CreateHsbaRecord(string code, string date, string diagnosis)
        {
            DateTime createdDate;
            if (!DateTime.TryParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out createdDate))
            {
                createdDate = DateTime.Today;
            }

            return new ucHSBA.HsbaRecord
            {
                Id = code,
                PatientCode = _patient.Code,
                PatientName = _patient.Name,
                Gender = _patient.Gender,
                Age = _patient.Age,
                Department = "Khoa Tim Mạch",
                CreatedDate = createdDate,
                BirthDate = "(Chưa cập nhật)",
                CitizenId = _patient.Cccd,
                Address = _patient.Hometown,
                Allergy = _patient.Allergy,
                MedicalHistory = _patient.MedicalHistory,
                Diagnosis = diagnosis,
                Treatment = "(Chưa cập nhật phác đồ điều trị)",
                Conclusion = "(Chưa có kết luận)",
                Services = new List<string> { "(Chưa có dịch vụ liên quan)" },
                Prescriptions = new List<string> { _patient.PrescriptionCount > 0 ? "(Xem đơn thuốc liên quan trong phân hệ đơn thuốc)" : "(Chưa có đơn thuốc)" }
            };
        }
    }
}
