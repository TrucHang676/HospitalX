using Guna.UI2.WinForms;
using HospitalX.GUI.PH2.DieuPhoiVien;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Linq;

namespace HospitalX.GUI.PH2.KyThuatVien
{
    public partial class ucKtvHoSo : UserControl
    {
        private static readonly Color ThemeGreen = Color.FromArgb(15, 110, 86); // #0F6E56
        private static readonly Color BorderGray = Color.FromArgb(218, 232, 226); // #DAE8E2
        private static readonly Color TextDark = Color.FromArgb(24, 48, 42); // #18302A
        private static readonly Color TextMuted = Color.FromArgb(122, 149, 137); // #7A9589
        private static readonly Color RowHoverBack = Color.FromArgb(232, 245, 242);

        private readonly List<AuditLogItem> _auditLogs = new List<AuditLogItem>();
        private Guna2MessageDialog _messageDialog;

        private static string SavedPhone = "0914 567 890";
        private static string SavedAddress = "45 Đường Lê Lợi, P.3, Biên Hòa, Đồng Nai";

        private string _originalContactPhone;
        private string _originalContactAddress;
        private bool _isLoadingContact;

        public class AuditLogItem
        {
            public string IconName { get; set; }
            public Color IconBack { get; set; }
            public string ActionText { get; set; }
            public string MetaText { get; set; }
            public DateTime Timestamp { get; set; }
        }

        public ucKtvHoSo()
        {
            InitializeComponent();
            DoubleBuffered = true;
            txtContactPhone.TextChanged += ContactFieldChanged;
            txtContactAddress.TextChanged += ContactFieldChanged;
        }

        private void ucKtvHoSo_Load(object sender, EventArgs e)
        {
            LoadProfileData();
            LoadAuditLogs();
            SetupStyles();
            ucKtvHoSo_Resize(null, null);
        }

        private void SetupStyles()
        {
            // Set styles for Left Card
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
            lblUserRole.Text = "Kỹ thuật viên Xét nghiệm";

            lblDeptAndFacility.ForeColor = TextMuted;
            lblDeptAndFacility.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            lblDeptAndFacility.Text = "Khoa Xét nghiệm\r\nBệnh viện Đa khoa HospitalX";

            // Style stat panels
            StyleStatPanel(pnlStat1, lblStat1Val, lblStat1Cap, "12", "Dịch vụ hôm nay");
            StyleStatPanel(pnlStat2, lblStat2Val, lblStat2Cap, "85", "Tổng ca hoàn thành");

            // Status badge
            lblStatusBadge.BackColor = Color.Transparent;
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

            // Titles
            lblTitleProf.ForeColor = ThemeGreen;
            lblTitleContact.ForeColor = ThemeGreen;
            lblTitleSecurity.ForeColor = ThemeGreen;
            lblTitleActivities.ForeColor = ThemeGreen;

            // Setup Professional text fields as Read-only styling
            SetupReadOnlyField(txtProfMaNV);
            SetupReadOnlyField(txtProfHoTen);
            SetupReadOnlyField(txtProfVaiTro);
            SetupReadOnlyField(txtKhoa);
            SetupReadOnlyField(txtProfGioiTinh);
            SetupReadOnlyField(txtProfNgaySinh);
            SetupReadOnlyField(txtProfCccd);

            // Setup editable contact text fields styling
            txtContactPhone.Font = new Font("Segoe UI", 9.5F);
            txtContactAddress.Font = new Font("Segoe UI", 9.5F);

            // Style buttons
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

        private void StyleStatPanel(Guna2Panel panel, Label val, Label cap, string value, string caption)
        {
            panel.BorderColor = Color.FromArgb(230, 238, 235);
            panel.BorderThickness = 1;
            panel.BorderRadius = 10;
            panel.FillColor = Color.FromArgb(247, 249, 248);

            val.Text = value;
            val.ForeColor = ThemeGreen;
            val.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold);

            cap.Text = caption;
            cap.ForeColor = TextMuted;
            cap.Font = new Font("Segoe UI", 8F, FontStyle.Regular);
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

        private void LoadProfileData()
        {
            KtvTechnician ktv = KtvData.CurrentTechnician();

            lblUserName.Text = ktv.HoTen;
            lblUserRole.Text = ktv.VaiTro + " " + ktv.ChuyenKhoa;
            lblDeptAndFacility.Text = $"{ktv.ChuyenKhoa}\r\nBệnh viện Đa khoa HospitalX";

            txtProfMaNV.Text = ktv.MaNv;
            txtProfHoTen.Text = ktv.HoTen;
            txtProfVaiTro.Text = ktv.VaiTro;
            txtProfGioiTinh.Text = ktv.Phai;
            txtProfNgaySinh.Text = ktv.NgaySinh;
            txtProfCccd.Text = ktv.Cmnd;

            SavedPhone = ktv.SoDt;
            SavedAddress = ktv.QueQuan;

            txtContactPhone.Text = SavedPhone;
            txtContactAddress.Text = SavedAddress;
            AcceptCurrentContactValues();

            // Load dynamically calculated stats
            try
            {
                var services = KtvData.Services();
                int todayCount = services.Count(s => s.NgayDv == DateTime.Today.ToString("dd/MM/yyyy"));
                int doneCount = services.Count(s => s.Status == "Hoàn thành");

                lblStat1Val.Text = todayCount.ToString();
                lblStat2Val.Text = doneCount.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Warning: Lỗi load stats cho KTV profile: " + ex.Message);
                lblStat1Val.Text = "0";
                lblStat2Val.Text = "0";
            }
        }

        private void LoadAuditLogs()
        {
            _auditLogs.Clear();
            _auditLogs.Add(new AuditLogItem
            {
                IconName = "buttonTick.png",
                IconBack = Color.FromArgb(230, 244, 240),
                ActionText = "Cập nhật kết quả **xét nghiệm máu** cho bệnh nhân **Nguyễn Văn An** thành công",
                MetaText = "Mã số HSBA-0156 — Chỉ số: Glucose, Cholesterol",
                Timestamp = DateTime.Now.AddMinutes(-15)
            });
            _auditLogs.Add(new AuditLogItem
            {
                IconName = "dpv_4.png",
                IconBack = Color.FromArgb(255, 248, 225),
                ActionText = "Nhận phân công thực hiện **xét nghiệm nước tiểu** cho bệnh nhân **Trần Thị Bích**",
                MetaText = "Khoa Xét nghiệm — Hẹn lúc: 14:30",
                Timestamp = DateTime.Now.AddHours(-1).AddMinutes(-30)
            });
            _auditLogs.Add(new AuditLogItem
            {
                IconName = "pencil (1).png",
                IconBack = Color.FromArgb(237, 231, 246),
                ActionText = "Cập nhật thông tin liên hệ và số điện thoại cá nhân",
                MetaText = "Số điện thoại mới: 0914 567 890",
                Timestamp = DateTime.Now.AddHours(-3)
            });
            _auditLogs.Add(new AuditLogItem
            {
                IconName = "dpv_2.png",
                IconBack = Color.FromArgb(230, 248, 246),
                ActionText = "Hoàn tất ca phân công **xét nghiệm đông máu** của bệnh nhân **Lê Thị Mai**",
                MetaText = "Kết quả đã chuyển tiếp đến Bác sĩ điều trị",
                Timestamp = DateTime.Now.AddHours(-5)
            });

            RenderAuditLogs();
        }

        private static Color GetDotColor(Color iconBack)
        {
            if (iconBack.R == 230 && iconBack.G == 244 && iconBack.B == 240) // light green (success)
                return Color.FromArgb(15, 110, 86);
            if (iconBack.R == 255 && iconBack.G == 248 && iconBack.B == 225) // light orange (warning/info)
                return Color.FromArgb(232, 168, 56);
            if (iconBack.R == 253 && iconBack.G == 236 && iconBack.B == 234) // light red (danger)
                return Color.FromArgb(229, 57, 53);
            if (iconBack.R == 237 && iconBack.G == 231 && iconBack.B == 246) // light purple
                return Color.FromArgb(103, 58, 183);
            if (iconBack.R == 230 && iconBack.G == 248 && iconBack.B == 246) // light teal
                return Color.FromArgb(0, 150, 136);
            return Color.FromArgb(15, 110, 86);
        }

        private void RenderAuditLogs()
        {
            flpActivities.Controls.Clear();
            foreach (var log in _auditLogs)
            {
                var row = new Panel
                {
                    Width = flpActivities.ClientSize.Width - 8,
                    Height = 68,
                    Margin = new Padding(0, 0, 0, 0),
                    BackColor = Color.White
                };

                Color dotColor = GetDotColor(log.IconBack);

                row.Paint += (s, e) =>
                {
                    var pnl = (Panel)s;
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                    using (var pen = new Pen(Color.FromArgb(245, 248, 246), 1))
                    {
                        e.Graphics.DrawLine(pen, 0, pnl.Height - 1, pnl.Width, pnl.Height - 1);
                    }

                    // Draw solid circular dot as status indicator instead of rendering too many icons
                    using (var brush = new SolidBrush(dotColor))
                    {
                        e.Graphics.FillEllipse(brush, 26, 30, 8, 8);
                    }
                };

                var lblText = new Label
                {
                    Name = "lblText",
                    Tag = log.ActionText,
                    Text = string.Empty,
                    Font = new Font("Segoe UI", 10F),
                    ForeColor = TextDark,
                    Location = new Point(52, 6),
                    Size = new Size(row.Width - 80, 30),
                    AutoSize = false,
                    BackColor = Color.Transparent
                };

                lblText.Paint += (s, e) =>
                {
                    var lbl = (Label)s;
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

                    string rawText = lbl.Tag != null ? lbl.Tag.ToString() : string.Empty;
                    string[] parts = rawText.Split(new string[] { "**" }, StringSplitOptions.None);

                    int currentX = 0;
                    int currentY = (lbl.Height - 20) / 2;

                    using (var regFont = new Font("Segoe UI", 10F, FontStyle.Regular))
                    using (var boldFont = new Font("Segoe UI", 10F, FontStyle.Bold))
                    {
                        for (int i = 0; i < parts.Length; i++)
                        {
                            if (string.IsNullOrEmpty(parts[i])) continue;
                            bool isBold = (i % 2 == 1);
                            Font font = isBold ? boldFont : regFont;
                            Color textCol = isBold ? ThemeGreen : lbl.ForeColor;

                            Size size = TextRenderer.MeasureText(e.Graphics, parts[i], font,
                                new Size(lbl.Width - currentX, lbl.Height),
                                TextFormatFlags.NoPadding | TextFormatFlags.SingleLine);

                            TextRenderer.DrawText(e.Graphics, parts[i], font, new Point(currentX, currentY), textCol,
                                TextFormatFlags.NoPadding | TextFormatFlags.SingleLine);

                            currentX += size.Width;
                        }
                    }
                };

                string timeText = FormatTimestamp(log.Timestamp);
                var lblMeta = new Label
                {
                    Name = "lblMeta",
                    Text = $"{timeText} — {log.MetaText}",
                    Font = new Font("Segoe UI", 8.5F),
                    ForeColor = TextMuted,
                    Location = new Point(52, 36),
                    AutoSize = true,
                    BackColor = Color.Transparent
                };

                row.Controls.Add(lblText);
                row.Controls.Add(lblMeta);
                flpActivities.Controls.Add(row);
            }
        }

        private static string FormatTimestamp(DateTime dt)
        {
            var diff = DateTime.Now - dt;
            if (diff.TotalMinutes < 60)
            {
                return $"{(int)Math.Max(1, diff.TotalMinutes)} phút trước";
            }
            if (diff.TotalHours < 24)
            {
                return $"{(int)diff.TotalHours} giờ trước";
            }
            return dt.ToString("HH:mm dd/MM/yyyy");
        }

        private void ucKtvHoSo_Resize(object sender, EventArgs e)
        {
            int totalW = pnlScroll.ClientSize.Width;
            if (totalW <= 0) return;

            int rightW = Math.Max(500, totalW - 368 - 24);
            pnlRight.SetBounds(368, 24, rightW, pnlRight.Height);

            pnlCardProfessional.Width = rightW;
            pnlCardContact.Width = rightW;
            pnlCardSecurity.Width = rightW;
            pnlCardActivities.Width = rightW;

            btnUpdateContact.Location = new Point(rightW - btnUpdateContact.Width - 24, btnUpdateContact.Top);
            btnChangePassword.Location = new Point(rightW - btnChangePassword.Width - 24, btnChangePassword.Top);

            flpActivities.Width = rightW - 40;
            foreach (Control ctrl in flpActivities.Controls)
            {
                ctrl.Width = flpActivities.ClientSize.Width - 8;
                if (ctrl.Controls["lblText"] is Label lbl)
                {
                    lbl.Width = ctrl.Width - 80;
                }
            }
        }

        private void btnUpdateContact_Click(object sender, EventArgs e)
        {
            string phone = txtContactPhone.Text.Trim();
            string address = txtContactAddress.Text.Trim();

            if (string.IsNullOrWhiteSpace(phone) || phone.Replace(" ", "").Length < 10 || !IsPhoneNumber(phone))
            {
                ShowInfoMessage("Số điện thoại phải là chữ số và có độ dài từ 10 ký tự trở lên.", "Lỗi nhập liệu", MessageDialogIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(address))
            {
                ShowInfoMessage("Quê quán không được bỏ trống.", "Lỗi nhập liệu", MessageDialogIcon.Warning);
                return;
            }

            try
            {
                string manv = HospitalX.DAO.DataProvider.Instance.CurrentUser;
                bool success = HospitalX.DAO.ProfileDAO.Instance.UpdateProfile(phone, address, manv);
                if (success)
                {
                    SavedPhone = phone;
                    SavedAddress = address;
                    ReloadContactData();
                    ShowInfoMessage("Cập nhật thông tin cá nhân thành công!", "Thông báo", MessageDialogIcon.Information);
                }
                else
                {
                    ShowInfoMessage("Không thể cập nhật thông tin cá nhân. Vui lòng thử lại.", "Lỗi cập nhật", MessageDialogIcon.Error);
                }
            }
            catch (Exception ex)
            {
                ShowInfoMessage("Lỗi kết nối CSDL: " + ex.Message, "Lỗi cập nhật", MessageDialogIcon.Error);
            }
        }

        private void ContactFieldChanged(object sender, EventArgs e)
        {
            if (_isLoadingContact) return;
            UpdateContactSaveButton();
        }

        private void ReloadContactData()
        {
            _isLoadingContact = true;
            txtContactPhone.Text = SavedPhone;
            txtContactAddress.Text = SavedAddress;
            AcceptCurrentContactValues();
            _isLoadingContact = false;
            UpdateContactSaveButton();
        }

        private void AcceptCurrentContactValues()
        {
            _originalContactPhone = NormalizeContactText(txtContactPhone.Text);
            _originalContactAddress = NormalizeContactText(txtContactAddress.Text);
        }

        private void UpdateContactSaveButton()
        {
            bool changed = NormalizeContactText(txtContactPhone.Text) != _originalContactPhone
                || NormalizeContactText(txtContactAddress.Text) != _originalContactAddress;
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
            // Open mock change password dialog
            using (var frm = new frmDoiMatKhau())
            {
                frm.ShowDialog(this);
            }
        }

        private static bool IsPhoneNumber(string value)
        {
            foreach (char c in value)
            {
                if (c != ' ' && (c < '0' || c > '9')) return false;
            }
            return true;
        }

        private void ShowInfoMessage(string message, string title, MessageDialogIcon icon)
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
