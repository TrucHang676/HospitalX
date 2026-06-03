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
        }

        private void ucHSCN_Load(object sender, EventArgs e)
        {
            LoadProfileData();
            SetupStyles();
            LoadRecentActivities();
            ucHSCN_Resize(null, null);
        }

        private void LoadProfileData()
        {
            lblUserName.Text = "BS. Trúc Hằng";
            lblUserRole.Text = "Bác sĩ / Y sĩ";
            lblDeptAndFacility.Text = "Khoa Thần kinh\r\nBV Đa Khoa Tỉnh";

            txtProfMaNV.Text = "NV-BS-0047";
            txtProfHoTen.Text = "Nguyễn Thị Trúc";
            txtProfVaiTro.Text = "Bác sĩ";
            txtProfGioiTinh.Text = "Thần kinh";
            txtProfNgaySinh.Text = "BV Đa Khoa Tỉnh";

            txtContactPhone.Text = SavedPhone;
            txtAddress.Text = SavedAddress;

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
            SetupReadOnlyField(txtProfGioiTinh);
            SetupReadOnlyField(txtProfNgaySinh);
            SetupReadOnlyField(txtProfCccd);

            txtProfCccd.Visible = false;
            label6.Visible = false;
            label7.Visible = false;

            txtContactPhone.Font = new Font("Segoe UI", 9.5F);
            txtAddress.Font = new Font("Segoe UI", 9.5F);

            btnUpdateContact.FillColor = ThemeGreen;
            btnUpdateContact.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnUpdateContact.ForeColor = Color.White;
            btnUpdateContact.HoverState.FillColor = Color.FromArgb(10, 82, 64);
            btnUpdateContact.Cursor = Cursors.Hand;

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
            foreach (var activity in _activities)
            {
                int rowWidth = Math.Max(520, flpActivities.ClientSize.Width - 8);
                var row = new Panel
                {
                    Width = rowWidth,
                    Height = 68,
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
            }
        }

        private void ucHSCN_Resize(object sender, EventArgs e)
        {
            int totalWidth = pnlScroll.ClientSize.Width;
            if (totalWidth <= 0)
            {
                return;
            }

            int rightWidth = Math.Max(602, totalWidth - 368 - 24);
            pnlRight.SetBounds(368, 24, rightWidth, pnlRight.Height);

            pnlCardProfessional.Width = rightWidth;
            pnlCardContact.Width = rightWidth;
            pnlCardSecurity.Width = rightWidth;
            pnlCardActivities.Width = rightWidth;

            btnUpdateContact.Location = new Point(rightWidth - btnUpdateContact.Width - 24, btnUpdateContact.Top);
            btnChangePassword.Location = new Point(rightWidth - btnChangePassword.Width - 24, btnChangePassword.Top);

            txtAddress.Width = rightWidth - txtAddress.Left - 24;
            txtProfNgaySinh.Width = rightWidth - txtProfNgaySinh.Left - 24;
            flpActivities.Width = rightWidth - 40;

            foreach (Control row in flpActivities.Controls)
            {
                row.Width = Math.Max(520, flpActivities.ClientSize.Width - 8);
                if (row.Controls.Count >= 3)
                {
                    row.Controls[0].Width = row.Width - 230;
                    row.Controls[2].Left = row.Width - 170;
                }
            }
        }

        private void btnUpdateContact_Click(object sender, EventArgs e)
        {
            string phone = txtContactPhone.Text.Trim();
            string address = txtAddress.Text.Trim();

            if (string.IsNullOrWhiteSpace(phone) || phone.Replace(" ", "").Length < 10 || !IsPhoneNumber(phone))
            {
                ShowMessage("Số điện thoại liên hệ phải là chữ số và có độ dài từ 10 ký tự trở lên.", "Lỗi nhập liệu", MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(address))
            {
                ShowMessage("Địa chỉ cư trú không được bỏ trống.", "Lỗi nhập liệu", MessageBoxIcon.Warning);
                return;
            }

            SavedPhone = phone;
            SavedAddress = address;
            ShowMessage("Cập nhật thông tin liên hệ thành công.", "HospitalX", MessageBoxIcon.Information);
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

        private void ShowMessage(string message, string title, MessageBoxIcon icon)
        {
            MessageBox.Show(this, message, title, MessageBoxButtons.OK, icon);
        }
    }
}
