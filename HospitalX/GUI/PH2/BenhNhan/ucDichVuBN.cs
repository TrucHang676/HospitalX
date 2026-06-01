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
    public partial class ucDichVuBN : UserControl
    {
        private readonly List<ServiceItem> services;

        public ucDichVuBN()
        {
            InitializeComponent();
            services = PatientMedicalRecord.CreateSampleData()
                .SelectMany(record => record.Services.Select(service => new ServiceItem(record, service)))
                .ToList();
            WireEvents();
            ApplyDateRange();
            RenderServices();
        }

        private void WireEvents()
        {
            txtSearch.TextChanged += (sender, args) => RenderServices();
            cmbDateRange.SelectedIndexChanged += (sender, args) => { ApplyDateRange(); RenderServices(); };
            dtpFrom.ValueChanged += (sender, args) => RenderServices();
            dtpTo.ValueChanged += (sender, args) => RenderServices();
            cmbSort.SelectedIndexChanged += (sender, args) => RenderServices();
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

        private void RenderServices()
        {
            flowServices.SuspendLayout();
            flowServices.Controls.Clear();
            foreach (var item in GetFilteredServices())
            {
                flowServices.Controls.Add(CreateCard(item));
            }

            lblCount.Text = $"Hiển thị {flowServices.Controls.Count} dịch vụ";
            LayoutCards();
            flowServices.ResumeLayout();
        }

        private IEnumerable<ServiceItem> GetFilteredServices()
        {
            var query = services.AsEnumerable();
            var keyword = RemoveDiacritics(txtSearch.Text.Trim()).ToLowerInvariant();
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                query = query.Where(item => RemoveDiacritics($"{item.Record.Id} {item.Service.Type} {item.Service.Result} {item.Service.TechnicianId} {item.Record.Diagnosis}")
                    .ToLowerInvariant()
                    .Contains(keyword));
            }

            query = query.Where(item => item.Service.Date.Date >= dtpFrom.Value.Date && item.Service.Date.Date <= dtpTo.Value.Date);
            var sort = cmbSort.SelectedItem?.ToString();
            if (sort == "Cũ nhất") query = query.OrderBy(item => item.Service.Date);
            else if (sort == "Tên dịch vụ A-Z") query = query.OrderBy(item => item.Service.Type);
            else query = query.OrderByDescending(item => item.Service.Date);
            return query.ToList();
        }

        private Control CreateCard(ServiceItem item)
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
            card.Controls.Add(CreateText(item.Service.Date.ToString("dd/MM/yyyy"), 158, 22, 110, 22, 10f, FontStyle.Bold, Color.FromArgb(112, 138, 132)));
            card.Controls.Add(CreateText(item.Service.Type, 24, 54, 620, 26, 13f, FontStyle.Bold, Color.FromArgb(10, 42, 64)));
            card.Controls.Add(CreateText($"Kỹ thuật viên: {item.Service.TechnicianId} · Kết quả: {item.Service.Result}", 24, 86, 650, 22, 10f, FontStyle.Regular, Color.FromArgb(74, 98, 92)));

            var button = CreateDetailButton();
            button.Location = new Point(card.Width - 150, 43);
            button.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button.Click += (sender, args) =>
            {
                using (var form = new frmDichVuDetailBN(item.Record, item.Service))
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
            var width = Math.Max(720, flowServices.ClientSize.Width - 24);
            foreach (Control card in flowServices.Controls) card.Width = width;
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

        private class ServiceItem
        {
            public ServiceItem(PatientMedicalRecord record, RecordService service)
            {
                Record = record;
                Service = service;
            }

            public PatientMedicalRecord Record { get; }
            public RecordService Service { get; }
        }
    }
}
