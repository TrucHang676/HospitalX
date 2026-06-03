using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace HospitalX.GUI.PH2.DieuPhoiVien
{
    public partial class ucHoSoCaNhan : UserControl
    {
        private static readonly Color ThemeGreen = Color.FromArgb(15, 110, 86); // #0F6E56
        private static readonly Color BorderGray = Color.FromArgb(218, 232, 226); // #DAE8E2
        private static readonly Color TextDark = Color.FromArgb(24, 48, 42); // #18302A
        private static readonly Color TextMuted = Color.FromArgb(122, 149, 137); // #7A9589
        private static readonly Color RowHoverBack = Color.FromArgb(232, 245, 242);

        private readonly List<AuditLogItem> _auditLogs = new List<AuditLogItem>();

        private static string SavedPhone = "0901234567";
        private static string SavedAddress = "78/15 Đường Nguyễn Chí Thanh, Quận 5, TP. Hồ Chí Minh";

        public class AuditLogItem
        {
            public string IconName { get; set; }
            public Color IconBack { get; set; }
            public string ActionText { get; set; }
            public string MetaText { get; set; }
            public DateTime Timestamp { get; set; }
        }

        public ucHoSoCaNhan()
        {
            InitializeComponent();
            DoubleBuffered = true;
            txtContactPhone.TextChanged += txtContactPhone_TextChanged;
            txtContactAddress.TextChanged += txtContactAddress_TextChanged;
        }

        private void ucHoSoCaNhan_Load(object sender, EventArgs e)
        {
            LoadProfileData();
            LoadAuditLogs();
            SetupStyles();
            ucHoSoCaNhan_Resize(null, null);
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

            lblDeptAndFacility.ForeColor = TextMuted;
            lblDeptAndFacility.Font = new Font("Segoe UI", 9F, FontStyle.Regular);

            // Style stat panels
            StyleStatPanel(pnlStat1, lblStat1Val, lblStat1Cap, "124", "HSBA đã tạo");
            StyleStatPanel(pnlStat2, lblStat2Val, lblStat2Cap, "98", "Lượt điều phối KTV");

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
            // In a real application, this would load from a database based on the logged-in employee ID.
            // e.g.:
            // NhanVien nv = NhanVienBLL.GetById(Session.CurrentNhanVienId);
            // txtProfMaNV.Text = nv.MaNV;
            // ...
            
            // Populating controls with profile data:
            lblUserName.Text = "Lê Hoài Thương";
            
            txtProfMaNV.Text = "NV-DPV-0047";
            txtProfHoTen.Text = "Lê Hoài Thương";
            txtProfVaiTro.Text = "Điều phối viên";
            txtKhoa.Text = "Khoa Tim mạch";
            lblDeptAndFacility.Text = "Khoa Tim mạch\r\nBệnh viện Đa khoa Tỉnh";
            txtProfGioiTinh.Text = "Nữ";
            txtProfNgaySinh.Text = "12/04/1992";
            txtProfCccd.Text = "079192004567";

            txtContactPhone.Text = SavedPhone;
            txtContactAddress.Text = SavedAddress;

            // Load dynamically calculated stats
            lblStat1Val.Text = "124";
            lblStat2Val.Text = "98";
        }

        private void LoadAuditLogs()
        {
            _auditLogs.Clear();
            _auditLogs.Add(new AuditLogItem
            {
                IconName = "buttonTick.png",
                IconBack = Color.FromArgb(230, 244, 240),
                ActionText = "Điều phối KTV **Bùi Trọng Nghĩa** thực hiện siêu âm cho bệnh nhân **Nguyễn Văn An**",
                MetaText = "Khoa Tim mạch — Mã số HSBA-0156",
                Timestamp = DateTime.Now.AddMinutes(-15)
            });
            _auditLogs.Add(new AuditLogItem
            {
                IconName = "dpv_4.png",
                IconBack = Color.FromArgb(255, 248, 225),
                ActionText = "Tạo hồ sơ bệnh án **HSBA-0157** cho bệnh nhân **Trần Thị Bích**",
                MetaText = "Khoa Nội tổng quát — Dịch vụ: Xét nghiệm máu",
                Timestamp = DateTime.Now.AddHours(-1).AddMinutes(-30)
            });
            _auditLogs.Add(new AuditLogItem
            {
                IconName = "pencil (1).png",
                IconBack = Color.FromArgb(237, 231, 246),
                ActionText = "Sửa thông tin hành chính bệnh nhân **Phạm Quốc Hùng**",
                MetaText = "Cập nhật Địa chỉ cư trú và Số điện thoại liên hệ",
                Timestamp = DateTime.Now.AddHours(-3)
            });
            _auditLogs.Add(new AuditLogItem
            {
                IconName = "dpv_2.png",
                IconBack = Color.FromArgb(230, 248, 246),
                ActionText = "Thêm bệnh nhân mới **Lê Thị Mai** vào hệ thống quản lý",
                MetaText = "Đăng ký thành công mã bệnh nhân BN240014",
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
                    Size = new Size(row.Width - 230, 30),
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
                    Text = log.MetaText,
                    Font = new Font("Segoe UI", 8.5F),
                    ForeColor = TextMuted,
                    Location = new Point(52, 36),
                    AutoSize = true,
                    BackColor = Color.Transparent
                };

                var lblTime = new Label
                {
                    Name = "lblTime",
                    Text = timeText,
                    Font = new Font("Segoe UI", 8.7F),
                    ForeColor = TextMuted,
                    Location = new Point(row.Width - 170, 20),
                    Size = new Size(140, 24),
                    TextAlign = ContentAlignment.MiddleRight,
                    BackColor = Color.Transparent
                };

                row.Controls.Add(lblText);
                row.Controls.Add(lblMeta);
                row.Controls.Add(lblTime);
                flpActivities.Controls.Add(row);
            }
        }

        private static string FormatTimestamp(DateTime dt)
        {
            var today = DateTime.Today;
            if (dt.Date == today)
            {
                return $"Hôm nay, {dt:HH:mm}";
            }
            if (dt.Date == today.AddDays(-1))
            {
                return $"Hôm qua, {dt:HH:mm}";
            }
            return dt.ToString("dd/MM/yyyy, HH:mm");
        }

        private void ucHoSoCaNhan_Resize(object sender, EventArgs e)
        {
            int totalW = pnlScroll.ClientSize.Width;
            if (totalW <= 0) return;

            int rightW = Math.Max(500, totalW - 368 - 24);
            pnlRight.SetBounds(368, 24, rightW, pnlRight.Height);

            pnlCardProfessional.Width = rightW;
            pnlCardContact.Width = rightW;
            pnlCardSecurity.Width = rightW;
            pnlCardActivities.Width = rightW;

            btnChangePassword.Location = new Point(rightW - btnChangePassword.Width - 24, btnChangePassword.Top);

            flpActivities.Width = rightW - 40;
            foreach (Control ctrl in flpActivities.Controls)
            {
                ctrl.Width = flpActivities.ClientSize.Width - 8;
                if (ctrl.Controls["lblText"] is Label lbl)
                {
                    lbl.Width = ctrl.Width - 230;
                }
                if (ctrl.Controls["lblTime"] is Label lblT)
                {
                    lblT.Location = new Point(ctrl.Width - 170, 20);
                }
            }
        }

        private void txtContactPhone_TextChanged(object sender, EventArgs e)
        {
            string phone = txtContactPhone.Text.Trim();
            if (phone.Length >= 10 && IsNumeric(phone))
            {
                SavedPhone = phone;
                // BLL integration point for saving to database:
                // NhanVienBLL.UpdatePhone(Session.CurrentNhanVienId, phone);
            }
        }

        private void txtContactAddress_TextChanged(object sender, EventArgs e)
        {
            string address = txtContactAddress.Text.Trim();
            if (!string.IsNullOrEmpty(address))
            {
                SavedAddress = address;
                // BLL integration point for saving to database:
                // NhanVienBLL.UpdateAddress(Session.CurrentNhanVienId, address);
            }
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            // Open mock change password dialog
            using (var frm = new frmDoiMatKhau())
            {
                frm.ShowDialog(this);
            }
        }

        private static bool IsNumeric(string val)
        {
            foreach (char c in val)
            {
                if (c < '0' || c > '9') return false;
            }
            return true;
        }

        private void ShowInfoMessage(string message, string title, MessageDialogIcon icon)
        {
            if (FindForm() is Main_DPV mainDpv)
            {
                mainDpv.ShowMessage(message, title, icon);
            }
            else
            {
                MessageBox.Show(message, title, MessageBoxButtons.OK, icon == MessageDialogIcon.Information ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
            }
        }
    }
}
