using Guna.UI2.WinForms;
using HospitalX.GUI.PH2.DieuPhoiVien;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace HospitalX.GUI.PH2.BacSi
{
    public partial class ucHSCN : UserControl
    {
        private static readonly Color ThemeGreen = Color.FromArgb(15, 110, 86);
        private static readonly Color BorderGray = Color.FromArgb(218, 232, 226);
        private static readonly Color TextDark = Color.FromArgb(24, 48, 42);
        private static readonly Color TextMuted = Color.FromArgb(122, 149, 137);

        private readonly List<ActivityItem> _activities = new List<ActivityItem>();
        private Guna2MessageDialog _messageDialog;
        private string _originalContactPhone;
        private string _originalContactAddress;
        private bool _isLoadingContact;

        private static string SavedPhone = "090 123 4567";
        private static string SavedAddress = "Q. Bình Thạnh, TP.HCM";

        private sealed class ActivityItem
        {
            public string Title { get; set; }
            public string Code { get; set; }
            public string Time { get; set; }
            public Color DotColor { get; set; }
        }

        public ucHSCN()
        {
            InitializeComponent();
            DoubleBuffered = true;
            txtContactPhone.TextChanged += ContactFieldChanged;
            txtAddress.TextChanged += ContactFieldChanged;
        }

        private void ucHSCN_Load(object sender, EventArgs e)
        {
            LoadProfileData();
            SetupStyles();
            LoadRecentActivities();
            ConfigureScrolling();
        }

        private void LoadProfileData()
        {
            lblUserName.Text = "BS. Trúc Hằng";
            lblUserRole.Text = "Bác sĩ / Y sĩ";
            lblDeptAndFacility.Text = "Khoa Thần kinh\r\nBV Đa Khoa Tỉnh";

            txtProfMaNV.Text = "NV-BS-0047";
            txtProfHoTen.Text = "Nguyễn Thị Trúc Hằng";
            txtProfVaiTro.Text = "Bác sĩ";
            txtKhoa.Text = "Thần kinh";
            txtProfGioiTinh.Text = "Nữ";
            txtProfNgaySinh.Text = "12/04/1992";

            txtContactPhone.Text = SavedPhone;
            txtAddress.Text = SavedAddress;
            txtProfCccd.Text = "079192004567";
            AcceptCurrentContactValues();

            lblStat1Val.Text = "59";
            lblStat1Cap.Text = "HSBA liên quan";
            lblStat2Val.Text = "9";
            lblStat2Cap.Text = "Bệnh nhân";
        }

        private void SetupStyles()
        {
            pnlLeftCard.BorderColor = BorderGray;
            pnlLeftCard.BorderThickness = 1;
            pnlLeftCard.BorderRadius = 14;
            pnlLeftCard.FillColor = Color.White;

            ptbAvatar.Image = DpvAssets.Load("female_doctor.png");
            ptbAvatar.SizeMode = PictureBoxSizeMode.Zoom;

            lblUserName.ForeColor = TextDark;
            lblUserName.Font = new Font("Segoe UI Semibold", 13.5F, FontStyle.Bold);
            lblUserRole.ForeColor = TextMuted;
            lblUserRole.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblDeptAndFacility.ForeColor = TextMuted;
            lblDeptAndFacility.Font = new Font("Segoe UI", 9F);

            StyleStatPanel(pnlStat1, lblStat1Val, lblStat1Cap);
            StyleStatPanel(pnlStat2, lblStat2Val, lblStat2Cap);

            lblStatusBadge.FillColor = Color.FromArgb(230, 244, 240);
            lblStatusBadge.ForeColor = ThemeGreen;
            lblStatusBadge.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
            lblStatusBadge.Text = "● Đang hoạt động";
            lblStatusBadge.BorderRadius = 15;
            lblStatusBadge.HoverState.FillColor = Color.FromArgb(230, 244, 240);
            lblStatusBadge.PressedColor = Color.FromArgb(230, 244, 240);
            lblStatusBadge.Cursor = Cursors.Default;

            foreach (var panel in new[] { pnlCardProfessional, pnlCardContact, pnlCardSecurity, pnlCardActivities })
            {
                panel.BorderColor = BorderGray;
                panel.BorderThickness = 1;
                panel.BorderRadius = 14;
                panel.FillColor = Color.White;
            }

            lblTitleProf.ForeColor = ThemeGreen;
            lblTitleContact.ForeColor = ThemeGreen;
            lblTitleSecurity.ForeColor = ThemeGreen;
            lblTitleActivities.ForeColor = ThemeGreen;

            SetupReadOnlyField(txtProfMaNV);
            SetupReadOnlyField(txtProfHoTen);
            SetupReadOnlyField(txtProfVaiTro);
            SetupReadOnlyField(txtKhoa);
            SetupReadOnlyField(txtProfGioiTinh);
            SetupReadOnlyField(txtProfNgaySinh);
            SetupReadOnlyField(txtProfCccd);

            txtContactPhone.Font = new Font("Segoe UI", 9.5F);
            txtAddress.Font = new Font("Segoe UI", 9.5F);

            btnUpdateContact.FillColor = ThemeGreen;
            btnUpdateContact.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnUpdateContact.ForeColor = Color.White;
            btnUpdateContact.HoverState.FillColor = Color.FromArgb(10, 82, 64);
            UpdateContactSaveButton();

            btnChangePassword.BorderColor = ThemeGreen;
            btnChangePassword.BorderThickness = 1;
            btnChangePassword.FillColor = Color.Transparent;
            btnChangePassword.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnChangePassword.ForeColor = ThemeGreen;
            btnChangePassword.HoverState.FillColor = Color.FromArgb(230, 244, 240);
            btnChangePassword.Cursor = Cursors.Hand;
        }

        private void StyleStatPanel(Guna2Panel panel, Label valueLabel, Label captionLabel)
        {
            panel.BorderColor = Color.FromArgb(230, 238, 235);
            panel.BorderThickness = 1;
            panel.BorderRadius = 10;
            panel.FillColor = Color.FromArgb(247, 249, 248);

            valueLabel.ForeColor = ThemeGreen;
            valueLabel.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold);

            captionLabel.ForeColor = TextMuted;
            captionLabel.Font = new Font("Segoe UI", 8F);
        }

        private void SetupReadOnlyField(Guna2TextBox box)
        {
            box.ReadOnly = true;
            box.Enabled = false;
            box.FillColor = Color.FromArgb(247, 249, 248);
            box.BorderColor = Color.FromArgb(230, 238, 235);
            box.ForeColor = Color.FromArgb(90, 110, 100);
            box.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
        }

        private void LoadRecentActivities()
        {
            _activities.Clear();
            _activities.Add(new ActivityItem
            {
                Title = "Cập nhật chẩn đoán và điều trị",
                Code = "HSBA-0821",
                Time = "Hôm nay, 08:45",
                DotColor = ThemeGreen
            });
            _activities.Add(new ActivityItem
            {
                Title = "Thêm dịch vụ Siêu âm tim",
                Code = "HSBA-0821",
                Time = "Hôm nay, 09:16",
                DotColor = Color.FromArgb(58, 130, 196)
            });
            _activities.Add(new ActivityItem
            {
                Title = "Kê thêm Aspirin 81mg vào đơn thuốc",
                Code = "HSBA-0821",
                Time = "Hôm nay, 10:05",
                DotColor = Color.FromArgb(232, 168, 56)
            });
            _activities.Add(new ActivityItem
            {
                Title = "Xem hồ sơ bệnh án",
                Code = "HSBA-0819",
                Time = "Hôm qua, 14:20",
                DotColor = TextMuted
            });

            RenderActivities();
        }

        private void RenderActivities()
        {
            flpActivities.Controls.Clear();
            int top = 0;
            foreach (var activity in _activities)
            {
                int rowWidth = GetActivityRowWidth();
                var row = new Panel
                {
                    Width = rowWidth,
                    Height = 68,
                    Location = new Point(0, top),
                    Margin = new Padding(0),
                    BackColor = Color.White
                };

                row.Paint += (s, e) =>
                {
                    var panel = (Panel)s;
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    using (var pen = new Pen(Color.FromArgb(245, 248, 246), 1))
                    {
                        e.Graphics.DrawLine(pen, 0, panel.Height - 1, panel.Width, panel.Height - 1);
                    }
                    using (var brush = new SolidBrush(activity.DotColor))
                    {
                        e.Graphics.FillEllipse(brush, 26, 30, 8, 8);
                    }
                };

                var lblTitle = new Label
                {
                    AutoEllipsis = true,
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                    ForeColor = TextDark,
                    Location = new Point(52, 8),
                    Size = new Size(rowWidth - 230, 26),
                    Text = activity.Title
                };

                var lblCode = new Label
                {
                    AutoEllipsis = true,
                    Font = new Font("Consolas", 8.7F, FontStyle.Bold),
                    ForeColor = ThemeGreen,
                    Location = new Point(52, 36),
                    Size = new Size(150, 24),
                    Text = activity.Code
                };

                var lblTime = new Label
                {
                    Font = new Font("Segoe UI", 8.7F),
                    ForeColor = TextMuted,
                    Location = new Point(rowWidth - 170, 20),
                    Size = new Size(140, 24),
                    Text = activity.Time,
                    TextAlign = ContentAlignment.MiddleRight
                };

                row.Controls.Add(lblTitle);
                row.Controls.Add(lblCode);
                row.Controls.Add(lblTime);
                flpActivities.Controls.Add(row);
                top += row.Height;
            }

            flpActivities.AutoScrollMinSize = new Size(0, (_activities.Count * 68) + 8);
            LayoutActivityRows();
            HideActivityHorizontalScroll();
        }

        private void ucHSCN_Resize(object sender, EventArgs e)
        {
            pnlScroll.AutoScrollMinSize = new Size(0, pnlRight.Bottom + 24);
            LayoutActivityRows();
            HideActivityHorizontalScroll();
        }

        private void LayoutActivityRows()
        {
            int rowWidth = GetActivityRowWidth();
            int top = 0;
            foreach (Control row in flpActivities.Controls)
            {
                row.Location = new Point(0, top);
                row.Width = rowWidth;
                if (row.Controls.Count >= 3)
                {
                    row.Controls[0].Width = row.Width - 230;
                    row.Controls[2].Left = row.Width - 170;
                }
                top += row.Height;
            }
        }

        private int GetActivityRowWidth()
        {
            int reserved = SystemInformation.VerticalScrollBarWidth;
            return Math.Max(320, flpActivities.ClientSize.Width - reserved - 6);
        }

        private void ConfigureScrolling()
        {
            pnlScroll.AutoScroll = true;
            pnlScroll.AutoScrollMargin = new Size(0, 24);
            pnlScroll.AutoScrollMinSize = new Size(0, pnlRight.Bottom + 24);

            flpActivities.AutoScroll = true;
            flpActivities.AutoScrollMargin = new Size(0, 8);
            flpActivities.AutoScrollMinSize = new Size(0, (_activities.Count * 68) + 8);
            HideActivityHorizontalScroll();

            pnlScroll.MouseWheel += ScrollRoot_MouseWheel;
            pnlRight.MouseWheel += ScrollRoot_MouseWheel;
            pnlCardProfessional.MouseWheel += ScrollRoot_MouseWheel;
            pnlCardContact.MouseWheel += ScrollRoot_MouseWheel;
            pnlCardSecurity.MouseWheel += ScrollRoot_MouseWheel;
            pnlCardActivities.MouseWheel += ScrollRoot_MouseWheel;
            flpActivities.MouseWheel += Activities_MouseWheel;
        }

        private void HideActivityHorizontalScroll()
        {
            flpActivities.HorizontalScroll.Enabled = false;
            flpActivities.HorizontalScroll.Visible = false;
            flpActivities.HorizontalScroll.Maximum = 0;
            flpActivities.AutoScrollMinSize = new Size(0, flpActivities.AutoScrollMinSize.Height);
        }

        private void ScrollRoot_MouseWheel(object sender, MouseEventArgs e)
        {
            ScrollContainer(pnlScroll, e.Delta);
        }

        private void Activities_MouseWheel(object sender, MouseEventArgs e)
        {
            bool activityListNeedsScroll = flpActivities.DisplayRectangle.Height > flpActivities.ClientSize.Height;
            ScrollContainer(activityListNeedsScroll ? (ScrollableControl)flpActivities : pnlScroll, e.Delta);
        }

        private static void ScrollContainer(ScrollableControl container, int delta)
        {
            int currentY = -container.AutoScrollPosition.Y;
            int nextY = currentY - Math.Sign(delta) * 48;
            if (nextY < 0)
            {
                nextY = 0;
            }

            container.AutoScrollPosition = new Point(0, nextY);
        }

        private void btnUpdateContact_Click(object sender, EventArgs e)
        {
            string phone = txtContactPhone.Text.Trim();
            string address = txtAddress.Text.Trim();

            if (string.IsNullOrWhiteSpace(phone) || phone.Replace(" ", "").Length < 10 || !IsPhoneNumber(phone))
            {
                ShowMessage("Số điện thoại liên hệ phải là chữ số và có độ dài từ 10 ký tự trở lên.", "Lỗi nhập liệu", MessageDialogIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(address))
            {
                ShowMessage("Địa chỉ cư trú không được bỏ trống.", "Lỗi nhập liệu", MessageDialogIcon.Warning);
                return;
            }

            SavedPhone = phone;
            SavedAddress = address;
            ReloadContactData();
            ShowMessage("Cập nhật thông tin liên hệ thành công.", "Thông báo", MessageDialogIcon.Information);
        }

        private void ContactFieldChanged(object sender, EventArgs e)
        {
            if (_isLoadingContact)
            {
                return;
            }

            UpdateContactSaveButton();
        }

        private void ReloadContactData()
        {
            _isLoadingContact = true;
            txtContactPhone.Text = SavedPhone;
            txtAddress.Text = SavedAddress;
            AcceptCurrentContactValues();
            _isLoadingContact = false;
            UpdateContactSaveButton();
        }

        private void AcceptCurrentContactValues()
        {
            _originalContactPhone = NormalizeContactText(txtContactPhone.Text);
            _originalContactAddress = NormalizeContactText(txtAddress.Text);
        }

        private void UpdateContactSaveButton()
        {
            bool changed = NormalizeContactText(txtContactPhone.Text) != _originalContactPhone
                || NormalizeContactText(txtAddress.Text) != _originalContactAddress;

            btnUpdateContact.Visible = true;
            btnUpdateContact.Enabled = changed;
            btnUpdateContact.Cursor = changed ? Cursors.Hand : Cursors.Default;
        }

        private static string NormalizeContactText(string value)
        {
            return (value ?? string.Empty).Trim();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            using (var frm = new frmDoiMatKhau())
            {
                frm.ShowDialog(this);
            }
        }

        private static bool IsPhoneNumber(string value)
        {
            foreach (char c in value)
            {
                if (c != ' ' && (c < '0' || c > '9'))
                {
                    return false;
                }
            }

            return true;
        }

        private void ShowMessage(string message, string title, MessageDialogIcon icon)
        {
            if (_messageDialog == null)
            {
                _messageDialog = new Guna2MessageDialog();
            }

            _messageDialog.Parent = FindForm();
            _messageDialog.Icon = icon;
            _messageDialog.Buttons = MessageDialogButtons.OK;
            _messageDialog.Caption = title;
            _messageDialog.Style = MessageDialogStyle.Light;
            _messageDialog.Show(message);
        }
    }
}
