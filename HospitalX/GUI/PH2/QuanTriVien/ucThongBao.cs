using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace HospitalX.GUI.PH2.QuanTriVien
{
    public partial class ucThongBao : UserControl
    {
        private readonly List<NotificationRecord> _notifications = new List<NotificationRecord>();
        private readonly List<LabelOption> _labelOptions = new List<LabelOption>();
        private readonly Dictionary<string, Guna2Button> _labelButtons = new Dictionary<string, Guna2Button>();
        private readonly HashSet<string> _selectedLabels = new HashSet<string>();
        private Guna2Button _selectAllButton;
        private bool _loaded;

        public ucThongBao()
        {
            InitializeComponent();
            flowSent.Resize += (s, e) => RenderSentCards();
        }

        private void ucThongBao_Load(object sender, EventArgs e)
        {
            if (_loaded)
            {
                return;
            }

            _loaded = true;
            SeedData();
            BuildLabelChips();
            RenderSentCards();
            UpdateSelectedCount();
        }

        private void SeedData()
        {
            if (_notifications.Count > 0)
            {
                return;
            }

            _labelOptions.Add(new LabelOption("t1", "Toàn bộ nhân viên", "~124 người"));
            _labelOptions.Add(new LabelOption("t2", "Ban Giám đốc", "~5 người"));
            _labelOptions.Add(new LabelOption("t3", "Lãnh đạo khoa/phòng", "~22 người"));
            _labelOptions.Add(new LabelOption("t4", "Khoa Ngoại trú", "~31 người"));
            _labelOptions.Add(new LabelOption("t5", "Khoa Nội trú", "~28 người"));
            _labelOptions.Add(new LabelOption("t6", "Nhân viên Cơ sở 1", "~68 người"));
            _labelOptions.Add(new LabelOption("t7", "Nhân viên Cơ sở 2", "~56 người"));

            _notifications.Add(new NotificationRecord("24/05 09:15", "Nhắc nhở cập nhật mật khẩu trước ngày 30/05", "Hội trường A", "t1", "Quan trọng"));
            _notifications.Add(new NotificationRecord("23/05 16:42", "Họp giao ban Ban Giám đốc tại phòng họp số 3", "Phòng họp số 3", "t2", "Khẩn cấp"));
            _notifications.Add(new NotificationRecord("22/05 11:00", "Cập nhật quy trình nhập liệu HSBA tháng 6 theo mẫu mới", "", "t3, t4", "Thông thường"));
            _notifications.Add(new NotificationRecord("21/05 08:30", "Bảo trì hệ thống 22h-02h, lưu dữ liệu trước khi thoát", "", "t1", "Khẩn cấp"));
            _notifications.Add(new NotificationRecord("19/05 14:00", "Kiểm tra phòng khám Cơ sở 2 theo kế hoạch", "Cơ sở 2", "t7", "Quan trọng"));
            _notifications.Add(new NotificationRecord("16/05 09:00", "Họp lãnh đạo khoa toàn bệnh viện, tổng kết tháng 5", "Hội trường lớn", "t2, t3", "Thông thường"));
        }

        private void BuildLabelChips()
        {
            flowLabels.SuspendLayout();
            flowLabels.Controls.Clear();
            _labelButtons.Clear();

            _selectAllButton = CreateSelectAllButton();
            flowLabels.Controls.Add(_selectAllButton);

            foreach (LabelOption option in _labelOptions)
            {
                Guna2Button button = CreateLabelChip(option);
                _labelButtons.Add(option.Code, button);
                flowLabels.Controls.Add(button);
            }

            flowLabels.ResumeLayout();
        }

        private Guna2Button CreateSelectAllButton()
        {
            Guna2Button button = new Guna2Button
            {
                BorderColor = Color.FromArgb(196, 226, 216),
                BorderRadius = 8,
                BorderThickness = 1,
                ButtonMode = ButtonMode.ToogleButton,
                CheckedState =
                {
                    BorderColor = Color.FromArgb(15, 110, 86),
                    FillColor = Color.FromArgb(230, 244, 240),
                    ForeColor = Color.FromArgb(15, 110, 86)
                },
                Cursor = Cursors.Hand,
                FillColor = Color.FromArgb(247, 250, 249),
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = Color.FromArgb(15, 110, 86),
                HoverState =
                {
                    BorderColor = Color.FromArgb(15, 110, 86),
                    FillColor = Color.FromArgb(239, 248, 245),
                    ForeColor = Color.FromArgb(15, 110, 86)
                },
                Margin = new Padding(0, 0, 0, 6),
                PressedColor = Color.FromArgb(214, 238, 231),
                Size = new Size(394, 30),
                Text = "Chọn tất cả nhóm nhận",
                TextAlign = HorizontalAlignment.Left,
                TextOffset = new Point(10, 0)
            };

            button.Click += (s, e) => ToggleAllLabels();
            return button;
        }

        private Guna2Button CreateLabelChip(LabelOption option)
        {
            Guna2Button button = new Guna2Button
            {
                BorderColor = Color.FromArgb(218, 232, 226),
                BorderRadius = 9,
                BorderThickness = 1,
                ButtonMode = ButtonMode.ToogleButton,
                CheckedState =
                {
                    BorderColor = Color.FromArgb(15, 110, 86),
                    FillColor = Color.FromArgb(230, 244, 240),
                    ForeColor = Color.FromArgb(10, 42, 64)
                },
                Cursor = Cursors.Hand,
                FillColor = Color.White,
                Font = new Font("Segoe UI", 8F, FontStyle.Bold),
                ForeColor = Color.FromArgb(24, 48, 42),
                HoverState =
                {
                    BorderColor = Color.FromArgb(15, 110, 86),
                    FillColor = Color.FromArgb(247, 250, 249),
                    ForeColor = Color.FromArgb(10, 42, 64)
                },
                Margin = new Padding(0, 0, 8, 4),
                PressedColor = Color.FromArgb(214, 238, 231),
                Size = new Size(188, 40),
                Tag = option.Code,
                Text = option.Code + "  " + option.Name + Environment.NewLine + option.CountText,
                TextAlign = HorizontalAlignment.Left,
                TextOffset = new Point(10, 0)
            };

            button.Click += (s, e) => ToggleLabel(option.Code);
            return button;
        }

        private void ToggleAllLabels()
        {
            bool selectAll = _selectedLabels.Count != _labelOptions.Count;
            _selectedLabels.Clear();
            if (selectAll)
            {
                foreach (LabelOption option in _labelOptions)
                {
                    _selectedLabels.Add(option.Code);
                }
            }

            UpdateLabelButtons();
        }

        private void ToggleLabel(string code)
        {
            if (_selectedLabels.Contains(code))
            {
                _selectedLabels.Remove(code);
            }
            else
            {
                _selectedLabels.Add(code);
            }

            UpdateLabelButtons();
        }

        private void UpdateLabelButtons()
        {
            foreach (KeyValuePair<string, Guna2Button> pair in _labelButtons)
            {
                pair.Value.Checked = _selectedLabels.Contains(pair.Key);
            }

            if (_selectAllButton != null)
            {
                _selectAllButton.Checked = _selectedLabels.Count == _labelOptions.Count;
            }

            UpdateSelectedCount();
        }

        private void RenderSentCards()
        {
            if (!_loaded)
            {
                return;
            }

            flowSent.SuspendLayout();
            flowSent.Controls.Clear();

            int cardWidth = Math.Max(520, flowSent.ClientSize.Width - 24);
            foreach (NotificationRecord notification in _notifications)
            {
                flowSent.Controls.Add(CreateNotificationCard(notification, cardWidth));
            }

            flowSent.ResumeLayout();
            UpdateHistoryCount();
        }

        private Guna2Panel CreateNotificationCard(NotificationRecord notification, int width)
        {
            Color accent = GetPriorityColor(notification.Priority);
            Color soft = GetPrioritySoftColor(notification.Priority);

            Guna2Panel card = new Guna2Panel
            {
                BorderColor = soft,
                BorderRadius = 8,
                BorderThickness = 1,
                FillColor = notification.Priority == "Khẩn cấp" ? Color.FromArgb(255, 249, 249) : Color.White,
                Margin = new Padding(0, 0, 0, 12),
                Size = new Size(width, 86)
            };

            Label time = new Label
            {
                BackColor = Color.Transparent,
                Font = new Font("Segoe UI", 8.4F, FontStyle.Bold),
                ForeColor = Color.FromArgb(102, 128, 116),
                Location = new Point(16, 15),
                Size = new Size(88, 36),
                Text = notification.Time.Replace(" ", Environment.NewLine),
                TextAlign = ContentAlignment.TopLeft
            };

            Label content = new Label
            {
                AutoEllipsis = true,
                BackColor = Color.Transparent,
                Font = new Font("Segoe UI", 9.4F, FontStyle.Bold),
                ForeColor = Color.FromArgb(10, 42, 64),
                Location = new Point(108, 14),
                Size = new Size(width - 300, 24),
                Text = notification.Content
            };

            Label location = new Label
            {
                AutoEllipsis = true,
                BackColor = Color.Transparent,
                Font = new Font("Segoe UI", 8.6F),
                ForeColor = Color.FromArgb(102, 128, 116),
                Location = new Point(108, 42),
                Size = new Size(width - 300, 22),
                Text = string.IsNullOrWhiteSpace(notification.Location) ? "dba_admin" : notification.Location + " · dba_admin"
            };

            Guna2Button labelBadge = CreateBadge(notification.Labels, Color.FromArgb(219, 234, 254), Color.FromArgb(30, 64, 175));
            labelBadge.Location = new Point(width - 172, 16);
            labelBadge.Size = new Size(62, 28);

            Guna2Button priorityBadge = CreateBadge(notification.Priority, soft, accent);
            priorityBadge.Location = new Point(width - 102, 16);
            priorityBadge.Size = new Size(86, 28);

            card.Controls.Add(time);
            card.Controls.Add(content);
            card.Controls.Add(location);
            card.Controls.Add(labelBadge);
            card.Controls.Add(priorityBadge);
            return card;
        }

        private static Guna2Button CreateBadge(string text, Color fill, Color fore)
        {
            return new Guna2Button
            {
                BorderRadius = 7,
                Cursor = Cursors.Default,
                DisabledState =
                {
                    FillColor = fill,
                    ForeColor = fore
                },
                Enabled = false,
                FillColor = fill,
                Font = new Font("Segoe UI", 8.2F, FontStyle.Bold),
                ForeColor = fore,
                Text = text
            };
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string content = txtContent.Text.Trim();
            List<string> labels = _selectedLabels.OrderBy(label => label).ToList();

            if (string.IsNullOrWhiteSpace(content))
            {
                ShowMessage("Thiếu nội dung", "Vui lòng nhập nội dung thông báo.", MessageDialogIcon.Warning);
                return;
            }

            if (labels.Count == 0)
            {
                ShowMessage("Thiếu nhãn OLS", "Vui lòng chọn ít nhất một nhóm nhận.", MessageDialogIcon.Warning);
                return;
            }

            string summary = content.Length > 96 ? content.Substring(0, 96) + "..." : content;
            _notifications.Insert(0, new NotificationRecord(
                dtpTime.Value.ToString("dd/MM HH:mm"),
                summary,
                txtLocation.Text.Trim(),
                string.Join(", ", labels),
                Convert.ToString(cmbPriority.SelectedItem)));

            txtContent.Clear();
            txtLocation.Clear();
            _selectedLabels.Clear();
            UpdateLabelButtons();
            RenderSentCards();
            ShowMessage("Thông báo OLS", "Đã gửi thông báo thành công.", MessageDialogIcon.Information);
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void LabelCheckChanged(object sender, EventArgs e)
        {
        }

        private void UpdateSelectedCount()
        {
            lblSelectedCount.Text = _selectedLabels.Count + " nhóm được chọn";
        }

        private void UpdateHistoryCount()
        {
            lblHistoryCount.Text = _notifications.Count + " bản ghi";
        }

        private void ShowMessage(string caption, string text, MessageDialogIcon icon)
        {
            msgDialog.Parent = FindForm();
            msgDialog.Caption = caption;
            msgDialog.Text = text;
            msgDialog.Icon = icon;
            msgDialog.Buttons = MessageDialogButtons.OK;
            msgDialog.Show();
        }

        private static Color GetPriorityColor(string priority)
        {
            if (priority == "Khẩn cấp")
            {
                return Color.FromArgb(185, 28, 28);
            }

            if (priority == "Quan trọng")
            {
                return Color.FromArgb(180, 83, 9);
            }

            return Color.FromArgb(51, 65, 85);
        }

        private static Color GetPrioritySoftColor(string priority)
        {
            if (priority == "Khẩn cấp")
            {
                return Color.FromArgb(254, 226, 226);
            }

            if (priority == "Quan trọng")
            {
                return Color.FromArgb(254, 243, 199);
            }

            return Color.FromArgb(241, 245, 249);
        }

        private class LabelOption
        {
            public LabelOption(string code, string name, string countText)
            {
                Code = code;
                Name = name;
                CountText = countText;
            }

            public string Code { get; private set; }
            public string Name { get; private set; }
            public string CountText { get; private set; }
        }

        private class NotificationRecord
        {
            public NotificationRecord(string time, string content, string location, string labels, string priority)
            {
                Time = time;
                Content = content;
                Location = location;
                Labels = labels;
                Priority = priority;
            }

            public string Time { get; private set; }
            public string Content { get; private set; }
            public string Location { get; private set; }
            public string Labels { get; private set; }
            public string Priority { get; private set; }
        }
    }
}
