using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Data;
using HospitalX.DAO;
using HospitalX.GUI.PH2.DieuPhoiVien;

namespace HospitalX.GUI.PH2.KyThuatVien
{
    public partial class ucKtvThongBao : UserControl
    {
        private readonly List<NotificationRecord> _notifications = new List<NotificationRecord>();
        private bool _isLoaded;

        public ucKtvThongBao()
        {
            InitializeComponent();
        }

        private void ucKtvThongBao_Load(object sender, EventArgs e)
        {
            if (_isLoaded)
            {
                return;
            }

            _isLoaded = true;
            SeedData();
            WireEvents();
            ApplyFilters();
        }

        private void WireEvents()
        {
            txtSearch.TextChanged += (s, e) => ApplyFilters();
            cmbDateRange.SelectedIndexChanged += (s, e) => ApplyFilters();
            cmbLevel.SelectedIndexChanged += (s, e) => ApplyFilters();
            cmbStatus.SelectedIndexChanged += (s, e) => ApplyFilters();
            flpNotificationList.Resize += (s, e) => ResizeCards();
        }

        private void SeedData()
        {
            _notifications.Clear();
            try
            {
                DataTable dt = NoticeDAO.Instance.GetNotifications();
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        string matb = row["MATB"] != DBNull.Value ? row["MATB"].ToString().Trim() : "";
                        string noidung = row["NOIDUNG"] != DBNull.Value ? row["NOIDUNG"].ToString().Trim() : "";
                        DateTime ngaygio = row["NGAYGIO"] != DBNull.Value ? Convert.ToDateTime(row["NGAYGIO"]) : DateTime.Now;
                        string diadiem = row["DIADIEM"] != DBNull.Value ? row["DIADIEM"].ToString().Trim() : "";
                        string nhanOls = row["NHAN_OLS"] != DBNull.Value ? row["NHAN_OLS"].ToString().Trim() : "";

                        var record = new NotificationRecord
                        {
                            Title = "Thông báo " + matb,
                            Content = noidung,
                            Time = ngaygio,
                            Location = diadiem,
                            Sender = "Ban Giám Đốc",
                            Level = DetermineLevelFromOls(nhanOls),
                            IsRead = false,
                            IsImportant = matb == "T1" || matb == "T2" || matb == "T3"
                        };
                            _notifications.Add(record);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Loi doc danh sach thong bao: " + ex.Message);
            }
        }

        private string DetermineLevelFromOls(string olsLabel)
        {
            if (string.IsNullOrEmpty(olsLabel)) return "Cơ sở y tế";
            string upper = olsLabel.ToUpper();
            if (upper.Contains("TM") || upper.Contains("TK") || upper.Contains("TH"))
            {
                return "Khoa";
            }
            return "Cơ sở y tế";
        }

        private void ApplyFilters()
        {
            IEnumerable<NotificationRecord> query = _notifications;
            string keyword = txtSearch.Text.Trim().ToLowerInvariant();
            string level = cmbLevel.SelectedItem == null ? "Tất cả cấp" : cmbLevel.SelectedItem.ToString();
            string status = cmbStatus.SelectedItem == null ? "Tất cả trạng thái" : cmbStatus.SelectedItem.ToString();

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                query = query.Where(n =>
                    n.Title.ToLowerInvariant().Contains(keyword) ||
                    n.Content.ToLowerInvariant().Contains(keyword) ||
                    n.Location.ToLowerInvariant().Contains(keyword) ||
                    n.Sender.ToLowerInvariant().Contains(keyword));
            }

            if (level != "Tất cả cấp")
            {
                query = query.Where(n => n.Level == level);
            }

            if (status == "Chưa đọc")
            {
                query = query.Where(n => !n.IsRead);
            }
            else if (status == "Đã đọc")
            {
                query = query.Where(n => n.IsRead);
            }

            DateTime fromDate;
            DateTime toDate;
            GetDateRange(out fromDate, out toDate);
            query = query.Where(n => n.Time.Date >= fromDate.Date && n.Time.Date <= toDate.Date);

            List<NotificationRecord> filtered = query.OrderByDescending(n => n.Time).ToList();
            RenderCards(filtered);
            lblResultCount.Text = "Hiển thị " + filtered.Count + " thông báo";
        }

        private void GetDateRange(out DateTime fromDate, out DateTime toDate)
        {
            DateTime maxDate = _notifications.Count == 0 ? DateTime.Today : _notifications.Max(n => n.Time.Date);
            string mode = cmbDateRange.SelectedItem == null ? "Tháng này" : cmbDateRange.SelectedItem.ToString();

            if (mode == "Tất cả")
            {
                fromDate = DateTime.MinValue;
                toDate = DateTime.MaxValue;
                return;
            }

            if (mode == "Hôm nay")
            {
                fromDate = maxDate;
                toDate = maxDate;
                return;
            }

            if (mode == "7 ngày gần đây")
            {
                fromDate = maxDate.AddDays(-6);
                toDate = maxDate;
                return;
            }

            fromDate = new DateTime(maxDate.Year, maxDate.Month, 1);
            toDate = fromDate.AddMonths(1).AddDays(-1);
        }

        private void RenderCards(List<NotificationRecord> records)
        {
            flpNotificationList.SuspendLayout();
            flpNotificationList.Controls.Clear();

            if (records.Count == 0)
            {
                flpNotificationList.Controls.Add(new Label
                {
                    AutoSize = false,
                    Width = Math.Max(400, flpNotificationList.ClientSize.Width - 28),
                    Height = 90,
                    Text = "Không tìm thấy thông báo phù hợp.",
                    Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(122, 149, 137),
                    TextAlign = ContentAlignment.MiddleCenter
                });
                flpNotificationList.ResumeLayout();
                return;
            }

            foreach (NotificationRecord record in records)
            {
                flpNotificationList.Controls.Add(CreateNotificationCard(record));
            }

            flpNotificationList.ResumeLayout();
            BeginInvoke(new Action(ResizeCards));
        }

        private Guna2Panel CreateNotificationCard(NotificationRecord record)
        {
            int cardWidth = GetCardWidth();
            Color accent = record.IsImportant ? Color.FromArgb(217, 79, 61) : Color.FromArgb(15, 110, 86);
            var card = new Guna2Panel
            {
                BorderColor = Color.FromArgb(218, 232, 226),
                BorderRadius = 10,
                BorderThickness = 1,
                FillColor = record.IsRead ? Color.FromArgb(247, 249, 248) : Color.White,
                Margin = new Padding(0, 0, 0, 12),
                Size = new Size(cardWidth, 140),
                Tag = record
            };
            card.ShadowDecoration.Enabled = !record.IsRead;
            card.ShadowDecoration.Color = Color.FromArgb(226, 239, 234);
            card.ShadowDecoration.Depth = 5;
            card.MouseEnter += (s, e) => card.BorderColor = Color.FromArgb(26, 148, 112);
            card.MouseLeave += (s, e) => card.BorderColor = Color.FromArgb(218, 232, 226);

            var left = new Panel { BackColor = accent, Location = new Point(0, 0), Size = new Size(4, card.Height), Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom };
            var pnlLevel = new Guna2Panel
            {
                BorderRadius = 6,
                FillColor = record.Level == "Cơ sở y tế" ? Color.FromArgb(253, 236, 234) : Color.FromArgb(230, 244, 240),
                Location = new Point(24, 18),
                Size = new Size(112, 26)
            };
            var lblLevel = new Label
            {
                BackColor = Color.Transparent,
                Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
                ForeColor = accent,
                Dock = DockStyle.Fill,
                Text = record.Level.ToUpperInvariant(),
                TextAlign = ContentAlignment.MiddleCenter
            };
            pnlLevel.Controls.Add(lblLevel);

            var lblTitle = new Label
            {
                AutoEllipsis = true,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = Color.FromArgb(24, 48, 42),
                Location = new Point(150, 16),
                Size = new Size(cardWidth - 330, 35),
                Text = record.Title
            };
            var lblMeta = new Label
            {
                AutoEllipsis = true,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = Color.FromArgb(122, 149, 137),
                Location = new Point(150, 52),
                Size = new Size(cardWidth - 330, 30),
                Text = string.Format("{0} · {1:HH:mm dd/MM/yyyy} · {2}", record.Sender, record.Time, record.Location)
            };
            var lblBody = new Label
            {
                AutoEllipsis = true,
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.FromArgb(61, 82, 73),
                Location = new Point(24, 90),
                Size = new Size(cardWidth - 210, 35),
                Text = record.Content
            };
            var btnDetail = CreateActionButton("Xem chi tiết", Color.FromArgb(15, 110, 86), Color.White);
            btnDetail.Location = new Point(cardWidth - 166, 72);
            btnDetail.Size = new Size(134, 36);
            btnDetail.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDetail.Click += (s, e) => OpenNotificationDetail(record);

            card.Controls.Add(left);
            card.Controls.Add(pnlLevel);
            card.Controls.Add(lblTitle);
            card.Controls.Add(lblMeta);
            card.Controls.Add(lblBody);
            card.Controls.Add(btnDetail);
            return card;
        }

        private Guna2Button CreateActionButton(string text, Color fill, Color fore)
        {
            var button = new Guna2Button
            {
                BorderRadius = 8,
                Cursor = Cursors.Hand,
                FillColor = fill,
                ForeColor = fore,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Text = text
            };
            button.HoverState.FillColor = Color.FromArgb(26, 148, 112);
            button.PressedColor = Color.FromArgb(10, 79, 61);
            return button;
        }

        private void OpenNotificationDetail(NotificationRecord record)
        {
            using (var form = new frmKtvNotificationDetail(
                record.Title,
                record.Level,
                record.Time.ToString("HH:mm · dd/MM/yyyy"),
                record.Sender,
                record.Content))
            {
                record.IsRead = true;
                if (form.ShowDialog(FindForm()) == DialogResult.OK)
                {
                    ApplyFilters();
                }
            }
        }

        private int GetCardWidth()
        {
            return Math.Max(780, flpNotificationList.Width - flpNotificationList.Padding.Horizontal - 28);
        }

        private void ResizeCards()
        {
            int cardWidth = GetCardWidth();
            foreach (Control control in flpNotificationList.Controls)
            {
                control.Width = cardWidth;
            }
        }

        public class NotificationRecord
        {
            public string Title { get; set; }
            public string Level { get; set; }
            public string Sender { get; set; }
            public DateTime Time { get; set; }
            public string Location { get; set; }
            public string Content { get; set; }
            public bool IsRead { get; set; }
            public bool IsImportant { get; set; }
        }
    }
}
