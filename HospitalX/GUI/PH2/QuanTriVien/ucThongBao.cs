using Guna.UI2.WinForms;
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
        private readonly Dictionary<string, Guna2Button> _labelButtons = new Dictionary<string, Guna2Button>();
        private readonly HashSet<string> _selectedLabels = new HashSet<string>();
        private Guna2Button _selectAllButton;
        private bool _loaded;

        public ucThongBao()
        {
            InitializeComponent();
            flowSent.Resize += (s, e) => RenderSentCards();
            txtContent.TextChanged += (s, e) => UpdateSendButtonState();
        }

        private void ucThongBao_Load(object sender, EventArgs e)
        {
            if (_loaded)
            {
                return;
            }

            _loaded = true;
            LocalizeStaticText();
            SeedData();
            BindDesignerLabelButtons();
            RenderSentCards();
            UpdateSelectedCount();
            UpdateSendButtonState();
        }

        private void LocalizeStaticText()
        {
            lblComposeTitle.Text = "Soạn thông báo mới";
            lblContent.Text = "NỘI DUNG";
            lblTime.Text = "NGÀY GIỜ";
            lblLocation.Text = "ĐỊA ĐIỂM";
            lblPriority.Text = "ƯU TIÊN";
            lblLabelsTitle.Text = "Nhãn OLS gửi";
            lblHistoryTitle.Text = "Thông báo đã gửi";
            btnSend.Text = "Gửi thông báo qua OLS";
            txtContent.PlaceholderText = "Nhập nội dung thông báo nội bộ...";
            txtLocation.PlaceholderText = "VD: Hội trường A";

        }

        private void SeedData()
        {
            if (_notifications.Count > 0)
            {
                return;
            }

            _notifications.Add(new NotificationRecord("24/05 09:15", "Nhắc nhở cập nhật mật khẩu trước ngày 30/05", "Hội trường A", "t1", "Quan trọng"));
            _notifications.Add(new NotificationRecord("23/05 16:42", "Họp giao ban Ban Giám đốc tại phòng họp số 3", "Phòng họp số 3", "t2", "Khẩn cấp"));
            _notifications.Add(new NotificationRecord("22/05 11:00", "Cập nhật quy trình nhập liệu HSBA tháng 6 theo mẫu mới", "", "t3, t4", "Thông thường"));
            _notifications.Add(new NotificationRecord("21/05 08:30", "Bảo trì hệ thống 22h-02h, lưu dữ liệu trước khi thoát", "", "t1", "Khẩn cấp"));
            _notifications.Add(new NotificationRecord("19/05 14:00", "Kiểm tra phòng khám Cơ sở 2 theo kế hoạch", "Cơ sở 2", "t7", "Quan trọng"));
            _notifications.Add(new NotificationRecord("16/05 09:00", "Họp lãnh đạo khoa toàn bệnh viện, tổng kết tháng 5", "Hội trường lớn", "t2, t3", "Thông thường"));
        }

        private void BindDesignerLabelButtons()
        {
            _labelButtons.Clear();
            _selectAllButton = btnLabelAll;

            RegisterLabelButton(btnLabelT1, "t1");
            RegisterLabelButton(btnLabelT2, "t2");
            RegisterLabelButton(btnLabelT3, "t3");
            RegisterLabelButton(btnLabelT4, "t4");
            RegisterLabelButton(btnLabelT5, "t5");
            RegisterLabelButton(btnLabelT6, "t6");
            RegisterLabelButton(btnLabelT7, "t7");

            btnLabelAll.Click -= DesignerSelectAll_Click;
            btnLabelAll.Click += DesignerSelectAll_Click;
        }

        private void RegisterLabelButton(Guna2Button button, string code)
        {
            button.Tag = code;
            _labelButtons[code] = button;
            button.Click -= DesignerLabel_Click;
            button.Click += DesignerLabel_Click;
        }

        private void DesignerSelectAll_Click(object sender, EventArgs e)
        {
            ToggleAllLabels();
        }

        private void DesignerLabel_Click(object sender, EventArgs e)
        {
            Guna2Button button = sender as Guna2Button;
            if (button == null || button.Tag == null)
            {
                return;
            }

            ToggleLabel(Convert.ToString(button.Tag));
        }

        private void ToggleAllLabels()
        {
            bool selectAll = _selectedLabels.Count != _labelButtons.Count;
            _selectedLabels.Clear();
            if (selectAll)
            {
                foreach (string code in _labelButtons.Keys)
                {
                    _selectedLabels.Add(code);
                }
            }

            UpdateLabelButtons();
            UpdateSendButtonState();
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
            UpdateSendButtonState();
        }

        private void UpdateLabelButtons()
        {
            foreach (KeyValuePair<string, Guna2Button> pair in _labelButtons)
            {
                pair.Value.Checked = _selectedLabels.Contains(pair.Key);
            }

            if (_selectAllButton != null)
            {
                _selectAllButton.Checked = _selectedLabels.Count == _labelButtons.Count;
            }

            UpdateSelectedCount();
            UpdateSendButtonState();
        }

        private void UpdateSendButtonState()
        {
            bool canSend = !string.IsNullOrWhiteSpace(txtContent.Text)
                && _selectedLabels.Count > 0;

            btnSend.Visible = true;
            btnSend.Enabled = canSend;
            btnSend.Cursor = canSend ? Cursors.Hand : Cursors.Default;
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
                Size = new Size(width, 95)
            };

            Label time = new Label
            {
                BackColor = Color.Transparent,
                Font = new Font("Segoe UI", 8.4F, FontStyle.Bold),
                ForeColor = Color.FromArgb(102, 128, 116),
                Location = new Point(16, 20),
                Size = new Size(90, 60),
                Text = notification.Time.Replace(" ", Environment.NewLine)
            };

            Label content = new Label
            {
                AutoEllipsis = true,
                BackColor = Color.Transparent,
                Font = new Font("Segoe UI", 9.4F, FontStyle.Bold),
                ForeColor = Color.FromArgb(10, 42, 64),
                Location = new Point(108, 15),
                Size = new Size(width - 300, 25),
                Text = notification.Content
            };

            Label location = new Label
            {
                AutoEllipsis = true,
                BackColor = Color.Transparent,
                Font = new Font("Segoe UI", 8.6F),
                ForeColor = Color.FromArgb(102, 128, 116),
                Location = new Point(108, 50),
                Size = new Size(width - 300, 23),
                Text = string.IsNullOrWhiteSpace(notification.Location) ? "dba_admin" : notification.Location + " - dba_admin"
            };

            Guna2Button labelBadge = CreateBadge(notification.Labels, Color.FromArgb(219, 234, 254), Color.FromArgb(30, 64, 175));
            labelBadge.Location = new Point(width - 172, 25);
            labelBadge.Size = new Size(120, 40);

            card.Controls.Add(time);
            card.Controls.Add(content);
            card.Controls.Add(location);
            card.Controls.Add(labelBadge);
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
            UpdateSendButtonState();
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
