using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HospitalX.GUI.PH2.BenhNhan
{
    public partial class ucDonThuocBN : UserControl
    {
        private readonly List<PatientMedicalRecord> prescriptions;

        public ucDonThuocBN()
        {
            InitializeComponent();
            dtpFrom.Value = new DateTime(2026, 1, 1);
            dtpTo.Value = new DateTime(2026, 12, 31);
            prescriptions = PatientMedicalRecord.LoadFromDB()
                .Where(record => record.Prescriptions.Any())
                .ToList();
            WireEvents();
            RenderPrescriptions();
        }

        private void WireEvents()
        {
            txtSearch.TextChanged += (sender, args) => RenderPrescriptions();
            dtpFrom.ValueChanged += (sender, args) => RenderPrescriptions();
            dtpTo.ValueChanged += (sender, args) => RenderPrescriptions();
            cmbSort.SelectedIndexChanged += (sender, args) => RenderPrescriptions();
            Resize += (sender, args) => LayoutCards();
        }

        private void RenderPrescriptions()
        {
            flowPrescriptions.SuspendLayout();
            flowPrescriptions.Controls.Clear();

            foreach (var record in GetFilteredPrescriptions())
            {
                flowPrescriptions.Controls.Add(CreateCard(record));
            }

            lblCount.Text = $"Hiển thị {flowPrescriptions.Controls.Count} đơn thuốc";
            LayoutCards();
            flowPrescriptions.ResumeLayout();
        }

        private IEnumerable<PatientMedicalRecord> GetFilteredPrescriptions()
        {
            var query = prescriptions.AsEnumerable();
            var keyword = RemoveDiacritics(txtSearch.Text.Trim()).ToLowerInvariant();
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                query = query.Where(record =>
                {
                    var medicines = string.Join(" ", record.Prescriptions.Select(item => $"{item.MedicineName} {item.Dose}"));
                    return RemoveDiacritics($"{record.Id} {record.PatientName} {record.Diagnosis} {record.DoctorName} {medicines}")
                        .ToLowerInvariant()
                        .Contains(keyword);
                });
            }

            query = query.Where(record =>
            {
                var prescriptionDate = GetPrescriptionDate(record);
                return prescriptionDate.Date >= dtpFrom.Value.Date && prescriptionDate.Date <= dtpTo.Value.Date;
            });

            var sort = cmbSort.SelectedItem?.ToString();
            if (sort == "Cũ nhất")
            {
                query = query.OrderBy(GetPrescriptionDate);
            }
            else if (sort == "Tên thuốc A-Z")
            {
                query = query.OrderBy(record => record.Prescriptions.First().MedicineName);
            }
            else
            {
                query = query.OrderByDescending(GetPrescriptionDate);
            }

            return query.ToList();
        }

        private Control CreateCard(PatientMedicalRecord record)
        {
            var prescriptionDate = GetPrescriptionDate(record);
            var medicineNames = string.Join(", ", record.Prescriptions.Select(item => item.MedicineName));

            var card = new Guna2Panel
            {
                BorderColor = Color.FromArgb(205, 224, 219),
                BorderRadius = 8,
                BorderThickness = 1,
                CustomBorderColor = Color.FromArgb(0, 128, 102),
                CustomBorderThickness = new Padding(4, 0, 0, 0),
                FillColor = Color.White,
                Height = 180,
                Margin = new Padding(0, 0, 0, 12),
                Width = 800
            };

            card.Controls.Add(CreateBadge(record.Id, 24, 18, 130));
            card.Controls.Add(CreateText(prescriptionDate.ToString("dd/MM/yyyy"), 170, 18, 130, 25, 10f, FontStyle.Bold, Color.FromArgb(112, 138, 132)));
            card.Controls.Add(CreateText($"{record.Prescriptions.Count} thuốc trong đơn", 24, 50, 620, 50, 13f, FontStyle.Bold, Color.FromArgb(10, 42, 64)));
            card.Controls.Add(CreateText(medicineNames, 24, 95, 620, 40, 10f, FontStyle.Regular, Color.FromArgb(74, 98, 92)));
            card.Controls.Add(CreateText($"Hồ sơ: {record.Diagnosis}", 24, 130, 620, 30, 9.5f, FontStyle.Regular, Color.FromArgb(112, 138, 132)));

            var button = CreateDetailButton();
            button.Location = new Point(card.Width - 200, 43);
            button.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button.Click += (sender, args) =>
            {
                using (var form = new frmDonThuocDetailBN(record))
                {
                    form.ShowDialog(this);
                }
            };
            card.Controls.Add(button);
            card.Resize += (sender, args) => button.Location = new Point(card.Width - 200, 43);
            return card;
        }

        private DateTime GetPrescriptionDate(PatientMedicalRecord record)
        {
            return record.Prescriptions
                .OrderByDescending(item => item.Date)
                .First()
                .Date;
        }

        private Guna2Button CreateDetailButton()
        {
            var button = new Guna2Button
            {
                BorderRadius = 7,
                Cursor = Cursors.Hand,
                FillColor = Color.FromArgb(0, 120, 95),
                Font = new Font("Segoe UI", 10f, FontStyle.Bold),
                ForeColor = Color.White,
                PressedColor = Color.FromArgb(0, 78, 63),
                Size = new Size(155, 42),
                Text = "Xem chi tiết"
            };
            button.HoverState.FillColor = Color.FromArgb(0, 97, 78);
            button.HoverState.ForeColor = Color.White;
            button.DisabledState.FillColor = Color.FromArgb(180, 205, 198);
            button.DisabledState.ForeColor = Color.White;
            return button;
        }

        private Label CreateBadge(string text, int x, int y, int width)
        {
            return new Label
            {
                BackColor = Color.FromArgb(226, 245, 239),
                Font = new Font("Consolas", 10f, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 105, 85),
                Location = new Point(x, y),
                Size = new Size(width, 26),
                Text = text,
                TextAlign = ContentAlignment.MiddleCenter
            };
        }

        private Label CreateText(string text, int x, int y, int width, int height, float size, FontStyle style, Color color)
        {
            return new Label
            {
                AutoEllipsis = true,
                BackColor = Color.Transparent,
                Font = new Font("Segoe UI", size, style),
                ForeColor = color,
                Location = new Point(x, y),
                Size = new Size(width, height),
                Text = text
            };
        }

        private void LayoutCards()
        {
            var width = Math.Max(720, flowPrescriptions.ClientSize.Width - 24);
            foreach (Control card in flowPrescriptions.Controls)
            {
                card.Width = width;
            }
        }

        private string RemoveDiacritics(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return string.Empty;
            var normalized = text.Normalize(NormalizationForm.FormD);
            var builder = new StringBuilder();
            foreach (var c in normalized)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                {
                    builder.Append(c);
                }
            }

            return builder.ToString().Normalize(NormalizationForm.FormC).Replace("đ", "d").Replace("Đ", "D");
        }
    }
}
