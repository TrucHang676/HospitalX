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
        private readonly List<PrescriptionItem> prescriptions;

        public ucDonThuocBN()
        {
            InitializeComponent();
            prescriptions = PatientMedicalRecord.CreateSampleData()
                .SelectMany(record => record.Prescriptions.Select(prescription => new PrescriptionItem(record, prescription)))
                .ToList();
            WireEvents();
            ApplyDateRange();
            RenderPrescriptions();
        }

        private void WireEvents()
        {
            txtSearch.TextChanged += (sender, args) => RenderPrescriptions();
            cmbDateRange.SelectedIndexChanged += (sender, args) => { ApplyDateRange(); RenderPrescriptions(); };
            dtpFrom.ValueChanged += (sender, args) => RenderPrescriptions();
            dtpTo.ValueChanged += (sender, args) => RenderPrescriptions();
            cmbSort.SelectedIndexChanged += (sender, args) => RenderPrescriptions();
            Resize += (sender, args) => LayoutCards();
        }

        private void ApplyDateRange()
        {
            var selected = cmbDateRange.SelectedItem?.ToString() ?? "Tất cả thời gian";
            dtpFrom.Enabled = selected == "Tùy chọn";
            dtpTo.Enabled = selected == "Tùy chọn";
            if (selected == "Tháng này")
            {
                var today = DateTime.Today;
                dtpFrom.Value = new DateTime(today.Year, today.Month, 1);
                dtpTo.Value = new DateTime(today.Year, today.Month, DateTime.DaysInMonth(today.Year, today.Month));
            }
            else if (selected == "3 tháng gần đây")
            {
                dtpFrom.Value = DateTime.Today.AddMonths(-3);
                dtpTo.Value = DateTime.Today;
            }
            else if (selected == "Tất cả thời gian")
            {
                dtpFrom.Value = new DateTime(2026, 1, 1);
                dtpTo.Value = new DateTime(2026, 12, 31);
            }
        }

        private void RenderPrescriptions()
        {
            flowPrescriptions.SuspendLayout();
            flowPrescriptions.Controls.Clear();
            foreach (var item in GetFilteredPrescriptions())
            {
                flowPrescriptions.Controls.Add(CreateCard(item));
            }

            lblCount.Text = $"Hiển thị {flowPrescriptions.Controls.Count} thuốc";
            LayoutCards();
            flowPrescriptions.ResumeLayout();
        }

        private IEnumerable<PrescriptionItem> GetFilteredPrescriptions()
        {
            var query = prescriptions.AsEnumerable();
            var keyword = RemoveDiacritics(txtSearch.Text.Trim()).ToLowerInvariant();
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                query = query.Where(item => RemoveDiacritics($"{item.Record.Id} {item.Prescription.MedicineName} {item.Prescription.Dose} {item.Record.Diagnosis}")
                    .ToLowerInvariant()
                    .Contains(keyword));
            }

            query = query.Where(item => item.Prescription.Date.Date >= dtpFrom.Value.Date && item.Prescription.Date.Date <= dtpTo.Value.Date);
            var sort = cmbSort.SelectedItem?.ToString();
            if (sort == "Cũ nhất") query = query.OrderBy(item => item.Prescription.Date);
            else if (sort == "Tên thuốc A-Z") query = query.OrderBy(item => item.Prescription.MedicineName);
            else query = query.OrderByDescending(item => item.Prescription.Date);
            return query.ToList();
        }

        private Control CreateCard(PrescriptionItem item)
        {
            var card = new Guna2Panel
            {
                BorderColor = Color.FromArgb(205, 224, 219),
                BorderRadius = 8,
                BorderThickness = 1,
                CustomBorderColor = Color.FromArgb(0, 128, 102),
                CustomBorderThickness = new Padding(4, 0, 0, 0),
                FillColor = Color.White,
                Height = 124,
                Margin = new Padding(0, 0, 0, 12),
                Width = 800
            };

            card.Controls.Add(CreateBadge(item.Record.Id, 24, 18, 116));
            card.Controls.Add(CreateText(item.Prescription.Date.ToString("dd/MM/yyyy"), 158, 22, 110, 22, 10f, FontStyle.Bold, Color.FromArgb(112, 138, 132)));
            card.Controls.Add(CreateText(item.Prescription.MedicineName, 24, 54, 620, 26, 13f, FontStyle.Bold, Color.FromArgb(10, 42, 64)));
            card.Controls.Add(CreateText($"Liều dùng: {item.Prescription.Dose} · Hồ sơ: {item.Record.Diagnosis}", 24, 86, 650, 22, 10f, FontStyle.Regular, Color.FromArgb(74, 98, 92)));

            var button = CreateDetailButton();
            button.Location = new Point(card.Width - 150, 43);
            button.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button.Click += (sender, args) =>
            {
                using (var form = new frmDonThuocDetailBN(item.Record, item.Prescription))
                {
                    form.ShowDialog(this);
                }
            };
            card.Controls.Add(button);
            card.Resize += (sender, args) => button.Location = new Point(card.Width - 150, 43);
            return card;
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
                Size = new Size(126, 38),
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
            foreach (Control card in flowPrescriptions.Controls) card.Width = width;
        }

        private string RemoveDiacritics(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return string.Empty;
            var normalized = text.Normalize(NormalizationForm.FormD);
            var builder = new StringBuilder();
            foreach (var c in normalized)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark) builder.Append(c);
            }
            return builder.ToString().Normalize(NormalizationForm.FormC).Replace("đ", "d").Replace("Đ", "D");
        }

        private class PrescriptionItem
        {
            public PrescriptionItem(PatientMedicalRecord record, RecordPrescription prescription)
            {
                Record = record;
                Prescription = prescription;
            }

            public PatientMedicalRecord Record { get; }
            public RecordPrescription Prescription { get; }
        }
    }
}
