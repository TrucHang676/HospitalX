using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace HospitalX.GUI.PH2.KyThuatVien
{
    public partial class ucKtvHoSo : UserControl
    {
        // --- Add these to your field declarations ---
        private Guna2Panel pnlEditModalOverlay;
        private Guna2Panel cardEditModal;

        // Stats Controls
        private Guna2Panel[] cardStats = new Guna2Panel[4];

        // Hero Panel Controls
        private Guna2Panel pnlHeroAvatar;
        private Label lblHeroAvatarText;
        private Guna2Panel pnlHeroAvatarEdit;
        private Label lblHeroName;
        private Label lblHeroRole;
        private FlowLayoutPanel flpHeroTags;
        private Guna2Button btnHeroEdit;
        private Guna2Button btnHeroPw;

        // Edit Profile Modal Overlay — PASSWORD CHANGE (inline)
        private Guna2Panel pnlPwModalOverlay;
        private Guna2Panel cardPwModal;
        private Guna2TextBox txtPwCurrent;
        private Guna2TextBox txtPwNew;
        private Guna2TextBox txtPwConfirm;
        private Label lblPwError;
        private Guna2Button btnPwSave;
        private Guna2Button btnPwCancel;

        // Edit Profile fields (declared for compatibility; modal is now frmKtvEditProfile)
        private Guna2TextBox txtEditName;
        private Guna2DateTimePicker dtpEditDob;
        private Guna2ComboBox cboEditGender;
        private Guna2TextBox txtEditCccd;
        private Guna2TextBox txtEditPhone;
        private Guna2TextBox txtEditEmail;
        private Guna2TextBox txtEditAddress;
        private Guna2ComboBox cboEditShift;
        private Guna2TextBox txtEditSkills;
        private Guna2Button btnEditSave;
        private Guna2Button btnEditCancel;

        // Slide-up Toast Notification
        private Guna2Panel pnlToast;
        private Label lblToastText;
        private Timer tmrToast;
        private int toastTicks = 0;
        private bool isToastShowing = false;

        // Shared local state data — từ NHANVIEN (không có Email, địa chỉ nhà riêng; chỉ có SODT và QUEQUAN)
        private string ktvName    = "Nguyễn Thị Thu";
        private string ktvDob     = "15/08/1992";   // NGAYSINH
        private string ktvGender  = "Nữ";            // PHAI
        private string ktvCmnd    = "079292013456"; // CMND
        private string ktvPhone   = "0914 567 890"; // SODT
        private string ktvQueQuan = "45 Đường Lê Lợi, P.3, TP. Biên Hòa, Đồng Nai"; // QUEQUAN
        private string ktvAddress = "45 Đường Lê Lợi, P.3, TP. Biên Hòa, Đồng Nai"; // map to Quê quán
        private string ktvEmail   = "thu.nguyen@hospitalx.vn";
        private string ktvShift   = "Ca sáng: 07:00 – 15:00";
        private string ktvMaNv    = "KTV042";       // MANV
        private string ktvVaiTro  = "Kỹ thuật viên"; // VAITRO
        private string ktvChuyenKhoa = "Khoa Xét nghiệm"; // CHUYENKHOA

        public ucKtvHoSo()
        {
            InitializeComponent();
            DoubleBuffered = true;
            BackColor = KtvTheme.Bg;
            this.AutoScroll = false;

            // Link the array cardStats to the designer-generated cardStat controls
            cardStats[0] = this.cardStat1;
            cardStats[1] = this.cardStat2;
            cardStats[2] = this.cardStat3;
            cardStats[3] = this.cardStat4;

            BuildBaseStructure();
            BuildModals(); // Only builds the Password Change modal now

            this.Resize += UcKtvHoSo_Resize;
            this.Load += UcKtvHoSo_Load;
        }

        private void UcKtvHoSo_Load(object sender, EventArgs e)
        {
            LayoutControls();
        }

        private void UcKtvHoSo_Resize(object sender, EventArgs e)
        {
            LayoutControls();
        }

        private void BuildBaseStructure()
        {
            // Do NOT call Controls.Clear() and do NOT re-instantiate container panels because they are created in InitializeComponent()!
            
            // Clear controls inside the main container cards to redraw fresh content at runtime
            pnlHero.Controls.Clear();
            cardPersonalInfo.Controls.Clear();
            cardWorkInfo.Controls.Clear();
            cardSkills.Controls.Clear();
            cardCerts.Controls.Clear();
            cardActivities.Controls.Clear();
            for (int i = 0; i < 4; i++)
            {
                cardStats[i].Controls.Clear();
            }

            // A. Profile Hero Card
            // Avatar Container
            pnlHeroAvatar = new Guna2Panel
            {
                Size = new Size(90, 90),
                BorderRadius = 45,
                FillColor = Color.FromArgb(40, 255, 255, 255),
                BorderColor = Color.FromArgb(80, 255, 255, 255),
                BorderThickness = 3,
                Cursor = Cursors.Hand
            };
            pnlHeroAvatar.Click += (s, e) => OpenModal(pnlEditModalOverlay);

            lblHeroAvatarText = KtvTheme.Label("NT", 0, 0, 22F, FontStyle.Bold, Color.White);
            lblHeroAvatarText.AutoSize = false;
            lblHeroAvatarText.Location = new Point(0, 0);
            lblHeroAvatarText.Size = new Size(90, 90);
            lblHeroAvatarText.TextAlign = ContentAlignment.MiddleCenter;
            pnlHeroAvatar.Controls.Add(lblHeroAvatarText);
            pnlHero.Controls.Add(pnlHeroAvatar);

            lblHeroAvatarText.Click += (s, e) => OpenModal(pnlEditModalOverlay);

            // Edit Avatar Small Badge
            pnlHeroAvatarEdit = new Guna2Panel
            {
                Size = new Size(26, 26),
                BorderRadius = 13,
                FillColor = KtvTheme.Accent,
                BorderColor = Color.White,
                BorderThickness = 2,
                Cursor = Cursors.Hand
            };
            var lblCam = KtvTheme.Label("📷", 0, 0, 8.5F, FontStyle.Regular, Color.White);
            lblCam.AutoSize = false;
            lblCam.Location = new Point(0, 0);
            lblCam.Size = new Size(26, 26);
            lblCam.TextAlign = ContentAlignment.MiddleCenter;
            pnlHeroAvatarEdit.Controls.Add(lblCam);
            pnlHero.Controls.Add(pnlHeroAvatarEdit);

            pnlHeroAvatarEdit.Click += (s, e) => OpenModal(pnlEditModalOverlay);
            lblCam.Click += (s, e) => OpenModal(pnlEditModalOverlay);

            lblHeroName = KtvTheme.Label(ktvName, 134, 20, 18F, FontStyle.Bold, Color.White);
            lblHeroRole = KtvTheme.Label("Kỹ thuật viên Xét nghiệm · Khoa Xét nghiệm — Bệnh viện Đa khoa HospitalX", 134, 52, 9.5F, FontStyle.Regular, Color.FromArgb(200, 230, 222));
            
            flpHeroTags = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false,
                BackColor = Color.Transparent,
                Height = 30
            };
            AddHeroTag("🔬 Huyết học");
            AddHeroTag("🧪 Sinh hóa");
            AddHeroTag("🦠 Vi sinh");
            AddHeroTag("Mã NV: KTV-2019-042");

            pnlHero.Controls.AddRange(new Control[] { lblHeroName, lblHeroRole, flpHeroTags });

            btnHeroEdit = KtvTheme.Button("Chỉnh", Color.White, KtvTheme.TealDark);
            btnHeroEdit.Size = new Size(112, 36);
            btnHeroEdit.BorderRadius = 8;
            btnHeroEdit.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnHeroEdit.TextAlign = HorizontalAlignment.Center;
            btnHeroEdit.TextOffset = new Point(0, 0);
            btnHeroEdit.Padding = new Padding(0);
            btnHeroEdit.Click += (s, e) => OpenEditProfileForm();
            pnlHero.Controls.Add(btnHeroEdit);
            btnHeroEdit.Visible = false;

            btnHeroPw = KtvTheme.Button("Đổi mật khẩu", Color.FromArgb(40, 255, 255, 255), Color.White);
            btnHeroPw.BorderColor = Color.FromArgb(80, 255, 255, 255);
            btnHeroPw.BorderThickness = 1;
            btnHeroPw.Size = new Size(160, 36);
            btnHeroPw.TextAlign = HorizontalAlignment.Center;
            btnHeroPw.TextOffset = new Point(0, 0);
            btnHeroPw.Click += (s, e) => OpenModal(pnlPwModalOverlay);
            pnlHero.Controls.Add(btnHeroPw);
            btnHeroPw.Visible = false;

            // B. Stats Row — dữ liệu từ HSBA_DV
            var allSvc = KtvData.Services();
            int totalDv  = allSvc.Count;
            int doneDv   = allSvc.Count(x => x.Status == "Hoàn thành");
            int pendDv   = allSvc.Count(x => x.Status == "Chờ thực hiện");

            string[] statVals   = { totalDv.ToString(), doneDv.ToString(), pendDv.ToString(), ktvChuyenKhoa };
            string[] statLbls   = { "Tổng DV được phân công", "Đã hoàn thành", "Chờ thực hiện", "Chuyên khoa" };
            string[] statEmojis = { "🧪", "✅", "⏳", "🏥" };
            Color[] statBgs     = { KtvTheme.TealLight, KtvTheme.AccentSoft, KtvTheme.InfoSoft, Color.FromArgb(240, 235, 248) };
            Color[] statColors  = { KtvTheme.Teal, Color.FromArgb(160, 112, 0), KtvTheme.Info, Color.FromArgb(123, 94, 167) };

            for (int i = 0; i < 4; i++)
            {
                cardStats[i].ShadowDecoration.Enabled = true;
                cardStats[i].ShadowDecoration.Color = KtvTheme.Teal;
                cardStats[i].ShadowDecoration.Depth = 6;

                var pnlIcon = new Guna2Panel
                {
                    Size = new Size(52, 52),
                    Location = new Point(16, 20),
                    BorderRadius = 12,
                    FillColor = statBgs[i]
                };
                var lblEmoji = KtvTheme.Label(statEmojis[i], 0, 0, 15F, FontStyle.Regular, Color.Black);
                lblEmoji.AutoSize = false;
                lblEmoji.Location = new Point(0, 0);
                lblEmoji.Size = new Size(52, 52);
                lblEmoji.TextAlign = ContentAlignment.MiddleCenter;
                pnlIcon.Controls.Add(lblEmoji);

                var lblVal = KtvTheme.Label(statVals[i], 82, 18, 15F, FontStyle.Bold, KtvTheme.TextDark);
                var lblLbl = KtvTheme.Label(statLbls[i], 82, 48, 8.5F, FontStyle.Regular, KtvTheme.TextLight);

                cardStats[i].Controls.AddRange(new Control[] { pnlIcon, lblVal, lblLbl });
            }

            // C. Personal Info Card
            cardPersonalInfo.ShadowDecoration.Enabled = true;
            cardPersonalInfo.ShadowDecoration.Color = KtvTheme.Teal;
            cardPersonalInfo.ShadowDecoration.Depth = 8;

            // D. Work Info Card
            cardWorkInfo.ShadowDecoration.Enabled = true;
            cardWorkInfo.ShadowDecoration.Color = KtvTheme.Teal;
            cardWorkInfo.ShadowDecoration.Depth = 8;

            // E. Skills Card
            cardSkills.ShadowDecoration.Enabled = true;
            cardSkills.ShadowDecoration.Color = KtvTheme.Teal;
            cardSkills.ShadowDecoration.Depth = 8;

            // F. Certificates Card
            cardCerts.ShadowDecoration.Enabled = true;
            cardCerts.ShadowDecoration.Color = KtvTheme.Teal;
            cardCerts.ShadowDecoration.Depth = 8;

            // G. Activity Card
            cardActivities.ShadowDecoration.Enabled = true;
            cardActivities.ShadowDecoration.Color = KtvTheme.Teal;
            cardActivities.ShadowDecoration.Depth = 8;

            // H. Toast Notification
            pnlToast = new Guna2Panel
            {
                Size = new Size(360, 52),
                BorderRadius = 10,
                FillColor = KtvTheme.TealDark,
                Visible = false
            };
            pnlToast.ShadowDecoration.Enabled = true;
            pnlToast.ShadowDecoration.Color = Color.Black;
            pnlToast.ShadowDecoration.Depth = 12;

            lblToastText = new Label
            {
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                Location = new Point(16, 16),
                Size = new Size(328, 20),
                TextAlign = ContentAlignment.MiddleLeft,
                BackColor = Color.Transparent
            };
            pnlToast.Controls.Add(lblToastText);
            Controls.Add(pnlToast); // Put directly in main control, not in scroll panel

            tmrToast = new Timer { Interval = 20 };
            tmrToast.Tick += TmrToast_Tick;
        }

        private void AddHeroTag(string text)
        {
            var pnlTag = new Guna2Panel
            {
                BorderRadius = 10,
                FillColor = Color.FromArgb(40, 255, 255, 255),
                Margin = new Padding(0, 0, 8, 0),
                Height = 24
            };
            var lblTText = KtvTheme.Label(text, 0, 0, 8F, FontStyle.Bold, Color.White);
            lblTText.AutoSize = false;
            lblTText.Location = new Point(0, 0);
            lblTText.TextAlign = ContentAlignment.MiddleCenter;
            pnlTag.Controls.Add(lblTText);

            // Compute size dynamically
            using (var g = CreateGraphics())
            {
                SizeF size = g.MeasureString(text, lblTText.Font);
                pnlTag.Width = (int)size.Width + 38;
            }
            lblTText.Size = new Size(pnlTag.Width, 24);
            flpHeroTags.Controls.Add(pnlTag);
        }

        private void LayoutControls()
        {
            int margin = 28;
            int gap = 20;

            pnlScroll.Size = new Size(this.Width, this.Height);

            int cardW = this.Width - 2 * margin;
            if (cardW < 400) cardW = 400;

            // 1. Layout Hero Panel
            pnlHero.Location = new Point(margin, margin);
            pnlHero.Size = new Size(cardW, 134);

            pnlHeroAvatar.Location = new Point(24, 22);
            pnlHeroAvatarEdit.Location = new Point(90, 86);

            lblHeroName.Location = new Point(134, 20);
            lblHeroRole.Location = new Point(134, 52);
            
            int heroButtonsY = 49;
            int heroEditX = cardW - 28;
            flpHeroTags.Location = new Point(134, 82);
            flpHeroTags.Size = new Size(Math.Max(260, heroEditX - flpHeroTags.Left - 18), 32);

            if (btnHeroEdit != null) btnHeroEdit.Location = new Point(heroEditX, heroButtonsY);
            if (btnHeroPw != null) btnHeroPw.Location = new Point(cardW - 174, 49);

            // 2. Layout Stats Row
            int statW = (cardW - 3 * gap) / 4;
            int statY = pnlHero.Bottom + gap;
            for (int i = 0; i < 4; i++)
            {
                cardStats[i].Location = new Point(margin + i * (statW + gap), statY);
                cardStats[i].Size = new Size(statW, 92);
                // Adjust label width to prevent cutting text
                cardStats[i].Controls[2].Width = statW - 96;
            }

            // 3. Layout Two Columns Info
            int infoW = (cardW - gap) / 2;
            int infoY = cardStats[0].Bottom + gap;

            cardPersonalInfo.Location = new Point(margin, infoY);
            cardPersonalInfo.Size = new Size(infoW, 340);
            RenderPersonalInfo();

            cardWorkInfo.Location = new Point(margin + infoW + gap, infoY);
            cardWorkInfo.Size = new Size(infoW, 340);
            RenderWorkInfo();

            // 4. Layout Skills, Certs (Left) & Activities (Right)
            int splitY = cardPersonalInfo.Bottom + gap;
            
            cardSkills.Location = new Point(margin, splitY);
            cardSkills.Size = new Size(infoW, 230);
            RenderSkills();

            cardCerts.Location = new Point(margin, cardSkills.Bottom + gap);
            cardCerts.Size = new Size(infoW, 230);
            RenderCertificates();

            cardActivities.Location = new Point(margin + infoW + gap, splitY);
            cardActivities.Size = new Size(infoW, 480);
            RenderActivities();

            // Setup toast placement
            pnlToast.Location = new Point(this.Width - pnlToast.Width - margin, this.Height - pnlToast.Height - 16);
            pnlToast.BringToFront();

            // Resize password modal overlay
            pnlPwModalOverlay.Size = new Size(this.Width, this.Height);
            cardPwModal.Location = new Point((this.Width - cardPwModal.Width) / 2, (this.Height - cardPwModal.Height) / 2);
        }

        private void RenderPersonalInfo()
        {
            cardPersonalInfo.Controls.Clear();
            var lblTitle = KtvTheme.Label("👤 Thông tin cá nhân", 20, 18, 10.5F, FontStyle.Bold, KtvTheme.TextDark);
            
            var btnEdit = new Guna2Button
            {
                Text = "Chỉnh",
                Size = new Size(88, 28),
                Location = new Point(cardPersonalInfo.Width - 108, 15),
                BorderRadius = 13,
                FillColor = KtvTheme.TealLight,
                ForeColor = KtvTheme.Teal,
                Font = new Font("Segoe UI", 8F, FontStyle.Bold),
                TextAlign = HorizontalAlignment.Center,
                TextOffset = new Point(0, 0),
                Padding = new Padding(0),
                Cursor = Cursors.Hand,
                HoverState = { FillColor = Color.FromArgb(200, 236, 224) }
            };
            btnEdit.Click += (s, e) => OpenEditProfileForm();

            cardPersonalInfo.Controls.AddRange(new Control[] { lblTitle, btnEdit });

            // Thông tin cá nhân — chỉ hiển thị trường thực có trong NHANVIEN
            // Họ tên, Ngày sinh, Giới tính, CMND, Số điện thoại, Quê quán, Trạng thái
            // Email và địa chỉ nhà riêng đã bỏ vì không tồn tại trong Oracle schema
            string[] personalLabels = { "Họ và tên", "Ngày sinh", "Giới tính", "CMND / CCCD", "Số điện thoại", "Quê quán", "Trạng thái" };
            string[] personalVals  = { ktvName, ktvDob, ktvGender, ktvCmnd, ktvPhone, ktvQueQuan, "ACTIVE" };

            int yRow = 58;
            for (int i = 0; i < 7; i++) // 7 rows: họ tên, ngày sinh, giới tính, cmnd, sđt, quê quán, trạng thái
            {
                var lblRow = KtvTheme.Label(personalLabels[i], 20, yRow + 6, 9F, FontStyle.Regular, KtvTheme.TextLight);
                cardPersonalInfo.Controls.Add(lblRow);

                if (i == 6) // Status Badge (index 6 now, not 7)
                {
                    var pnlBadge = new Guna2Panel
                    {
                        Location = new Point(180, yRow + 4),
                        Size = new Size(130, 24),
                        BorderRadius = 12,
                        FillColor = KtvTheme.TealLight
                    };
                    var lblBadgeText = KtvTheme.Label("🟢 Đang hoạt động", 0, 0, 7.8F, FontStyle.Bold, KtvTheme.Teal);
                    lblBadgeText.AutoSize = false;
                    lblBadgeText.Location = new Point(0, 0);
                    lblBadgeText.Size = new Size(130, 24);
                    lblBadgeText.TextAlign = ContentAlignment.MiddleCenter;
                    pnlBadge.Controls.Add(lblBadgeText);
                    cardPersonalInfo.Controls.Add(pnlBadge);
                }
                else
                {
                    var lblVal = KtvTheme.Label(personalVals[i], 180, yRow + 6, 9F, FontStyle.Bold, KtvTheme.TextDark);
                    // Allow autoellipsis for address
                    if (i == 6)
                    {
                        lblVal.AutoSize = false;
                        lblVal.Size = new Size(cardPersonalInfo.Width - 200, 20);
                        lblVal.AutoEllipsis = true;
                    }
                    cardPersonalInfo.Controls.Add(lblVal);
                }

                // Divider line
                if (i < 6)
                {
                    var line = new Guna2Panel { Location = new Point(20, yRow + 32), Size = new Size(cardPersonalInfo.Width - 40, 1), FillColor = Color.FromArgb(244, 247, 250) };
                    cardPersonalInfo.Controls.Add(line);
                }

                yRow += 33;
            }
        }

        private void RenderWorkInfo()
        {
            cardWorkInfo.Controls.Clear();
            var lblTitle = KtvTheme.Label("🏥 Thông tin công tác", 20, 18, 10.5F, FontStyle.Bold, KtvTheme.TextDark);
            cardWorkInfo.Controls.Add(lblTitle);

            // Chỉ hiển thị các trường có trong NHANVIEN (bỏ Ca làm, Phòng ban, Bằng cấp, Nơi đào tạo)
            // VAITRO, CHUYENKHOA, MANV là các cột thực có
            string[] workLabels = { "Mã nhân viên", "Chức danh", "Chuyên khoa" };
            string[] workVals   = { ktvMaNv, ktvVaiTro, ktvChuyenKhoa };

            int yRow = 58;
            for (int i = 0; i < 3; i++)
            {
                var lblRow = KtvTheme.Label(workLabels[i], 20, yRow + 6, 9F, FontStyle.Regular, KtvTheme.TextLight);
                var lblVal = KtvTheme.Label(workVals[i], 180, yRow + 6, 9F, FontStyle.Bold, KtvTheme.TextDark);
                
                cardWorkInfo.Controls.AddRange(new Control[] { lblRow, lblVal });

                if (i < 2)
                {
                    var line = new Guna2Panel { Location = new Point(20, yRow + 32), Size = new Size(cardWorkInfo.Width - 40, 1), FillColor = Color.FromArgb(244, 247, 250) };
                    cardWorkInfo.Controls.Add(line);
                }

                yRow += 33;
            }
        }

        private void RenderSkills()
        {
            cardSkills.Controls.Clear();
            var lblTitle = KtvTheme.Label("🧪 Thống kê dịch vụ (từ HSBA_DV)", 20, 18, 10.5F, FontStyle.Bold, KtvTheme.TextDark);
            cardSkills.Controls.Add(lblTitle);

            // Dữ liệu từ HSBA_DV — không có skill bars trong Oracle schema
            var allSvc  = KtvData.Services();
            var byType  = allSvc.GroupBy(x => x.Service)
                                .Select(g => new { Name = g.Key, Count = g.Count(), Done = g.Count(s => s.Status == "Hoàn thành") })
                                .OrderByDescending(g => g.Count)
                                .ToList();

            int yRow = 52;
            foreach (var item in byType)
            {
                int pct = item.Count > 0 ? item.Done * 100 / item.Count : 0;
                var lblName = KtvTheme.Label($"{item.Name}", 20, yRow, 8.8F, FontStyle.Bold, KtvTheme.TextDark);
                var lblPct  = KtvTheme.Label($"{item.Done}/{item.Count} hoàn thành", cardSkills.Width - 160, yRow, 8.5F, FontStyle.Bold, KtvTheme.TextMid);

                var pnlBarBg = new Guna2Panel
                {
                    Location = new Point(20, yRow + 20),
                    Size = new Size(cardSkills.Width - 40, 6),
                    BorderRadius = 3,
                    FillColor = KtvTheme.TealLight
                };
                int barW = cardSkills.Width - 40;
                var pnlBarFg = new Guna2Panel
                {
                    Location = new Point(0, 0),
                    Size = new Size((int)(barW * pct / 100), 6),
                    BorderRadius = 3,
                    FillColor = KtvTheme.Teal
                };
                pnlBarBg.Controls.Add(pnlBarFg);

                cardSkills.Controls.AddRange(new Control[] { lblName, lblPct, pnlBarBg });
                yRow += 48;
            }
        }

        private void RenderCertificates()
        {
            cardCerts.Controls.Clear();
            // Chứng chỉ không có trong Oracle schema — thay bằng danh sách dịch vụ gần nhất từ HSBA_DV
            var lblTitle = KtvTheme.Label("📊 Dịch vụ gần nhất (HSBA_DV)", 20, 18, 10.5F, FontStyle.Bold, KtvTheme.TextDark);
            cardCerts.Controls.Add(lblTitle);

            var allSvc  = KtvData.Services();
            // Hiển thị 4 dịch vụ đầu tiên (ORDER BY NGAYDV DESC)
            var recent  = allSvc.OrderByDescending(x => x.NgayDv).Take(4).ToList();

            int yRow = 52;
            foreach (var svc in recent)
            {
                Color dot  = svc.Status == "Hoàn thành" ? KtvTheme.Teal  : Color.FromArgb(240, 165, 0);
                Color dotBg = svc.Status == "Hoàn thành" ? KtvTheme.TealLight : KtvTheme.AccentSoft;
                string icon = svc.Status == "Hoàn thành" ? "✅" : "⏳";

                var pnlIc = new Guna2Panel
                {
                    Size = new Size(32, 32),
                    Location = new Point(20, yRow),
                    BorderRadius = 8,
                    FillColor = dotBg
                };
                var lblIc = KtvTheme.Label(icon, 0, 0, 10F, FontStyle.Regular, dot);
                lblIc.AutoSize = false; lblIc.Location = new Point(0,0); lblIc.Size = new Size(32,32);
                lblIc.TextAlign = ContentAlignment.MiddleCenter;
                pnlIc.Controls.Add(lblIc);

                var lblN = KtvTheme.Label(svc.Service, 64, yRow, 9F, FontStyle.Bold, KtvTheme.TextDark);
                var lblS = KtvTheme.Label($"{svc.Patient}  ·  {svc.NgayDv}  ·  {svc.Status}", 64, yRow + 20, 7.8F, FontStyle.Regular, KtvTheme.TextLight);

                cardCerts.Controls.AddRange(new Control[] { pnlIc, lblN, lblS });

                var line = new Guna2Panel { Location = new Point(20, yRow + 46), Size = new Size(cardCerts.Width - 40, 1), FillColor = Color.FromArgb(244, 247, 250) };
                cardCerts.Controls.Add(line);

                yRow += 54;
            }
        }

        private void RenderActivities()
        {
            cardActivities.Controls.Clear();
            // Không có audit log trong Oracle schema — hiển thị danh sách dịch vụ phân công (từ HSBA_DV JOIN BENHNHAN)
            var lblTitle = KtvTheme.Label("📝 Dịch vụ được phân công (HSBA_DV)", 20, 18, 10.5F, FontStyle.Bold, KtvTheme.TextDark);
            cardActivities.Controls.Add(lblTitle);

            var allSvc = KtvData.Services();

            int yRow = 52;
            foreach (var svc in allSvc)
            {
                string icon   = svc.Status == "Hoàn thành" ? "✅" : "⏳";
                Color dotBg   = svc.Status == "Hoàn thành" ? KtvTheme.TealLight : KtvTheme.AccentSoft;
                Color dotFore = svc.Status == "Hoàn thành" ? KtvTheme.Teal : Color.FromArgb(160, 112, 0);

                var pnlDot = new Guna2Panel
                {
                    Size = new Size(28, 28),
                    Location = new Point(20, yRow + 2),
                    BorderRadius = 14,
                    FillColor = dotBg
                };
                var lblI = KtvTheme.Label(icon, 0, 0, 9F, FontStyle.Regular, dotFore);
                lblI.Size = new Size(28, 28);
                lblI.TextAlign = ContentAlignment.MiddleCenter;
                pnlDot.Controls.Add(lblI);

                // Tên dịch vụ (LOAIDV) — Bệnh nhân (TENBN)
                var lblT = KtvTheme.Label($"{svc.Service} — {svc.Patient}", 60, yRow, 8.8F, FontStyle.Bold, KtvTheme.TextDark);
                lblT.AutoSize = false;
                lblT.Size = new Size(cardActivities.Width - 80, 20);
                lblT.AutoEllipsis = true;

                // Ngày DV (NGAYDV) · MAHSBA · Trạng thái
                var lblTm = KtvTheme.Label($"{svc.NgayDv}  ·  {svc.MaHsba}  ·  {svc.Status}", 60, yRow + 20, 7.8F, FontStyle.Regular, KtvTheme.TextLight);

                cardActivities.Controls.AddRange(new Control[] { pnlDot, lblT, lblTm });

                var line = new Guna2Panel { Location = new Point(60, yRow + 44), Size = new Size(cardActivities.Width - 80, 1), FillColor = Color.FromArgb(244, 247, 250) };
                cardActivities.Controls.Add(line);

                yRow += 51;
            }
        }

        private void BuildModals()
        {
            // 1. Build Profile Edit Modal
            pnlEditModalOverlay = new Guna2Panel
            {
                FillColor = Color.FromArgb(90, 0, 0, 0),
                Location = new Point(0, 0),
                Size = new Size(1200, 800),
                Visible = false
            };
            pnlEditModalOverlay.Click += (s, e) => { if (e.GetType() == typeof(MouseEventArgs) && pnlEditModalOverlay.ClientRectangle.Contains(((MouseEventArgs)e).Location)) CloseModal(pnlEditModalOverlay); };

            cardEditModal = KtvTheme.Card(0, 0, 560, 560);
            cardEditModal.ShadowDecoration.Enabled = true;
            cardEditModal.ShadowDecoration.Depth = 20;

            var lblTitle = KtvTheme.Label("✏️ Chỉnh sửa hồ sơ cá nhân", 24, 20, 12F, FontStyle.Bold, KtvTheme.TextDark);
            
            var btnClose = new Guna2Button
            {
                Text = "✕",
                Size = new Size(28, 28),
                Location = new Point(508, 16),
                BorderRadius = 14,
                FillColor = Color.White,
                ForeColor = KtvTheme.TextLight,
                BorderColor = KtvTheme.Border,
                BorderThickness = 1,
                Font = new Font("Segoe UI", 8F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnClose.Click += (s, e) => CloseModal(pnlEditModalOverlay);

            cardEditModal.Controls.AddRange(new Control[] { lblTitle, btnClose });

            // Fields Stack
            int fY = 64;

            // Name & Phone
            cardEditModal.Controls.Add(KtvTheme.Label("Họ và tên *", 24, fY, 8.5F, FontStyle.Bold, KtvTheme.TextMid));
            txtEditName = new Guna2TextBox { Text = ktvName, Location = new Point(24, fY + 20), Size = new Size(240, 36), BorderRadius = 8, BorderColor = KtvTheme.Border, Font = new Font("Segoe UI", 9F) };
            cardEditModal.Controls.Add(txtEditName);

            cardEditModal.Controls.Add(KtvTheme.Label("Số điện thoại *", 284, fY, 8.5F, FontStyle.Bold, KtvTheme.TextMid));
            txtEditPhone = new Guna2TextBox { Text = ktvPhone, Location = new Point(284, fY + 20), Size = new Size(252, 36), BorderRadius = 8, BorderColor = KtvTheme.Border, Font = new Font("Segoe UI", 9F) };
            cardEditModal.Controls.Add(txtEditPhone);

            fY += 72;

            // Email & DOB
            cardEditModal.Controls.Add(KtvTheme.Label("Email liên lạc *", 24, fY, 8.5F, FontStyle.Bold, KtvTheme.TextMid));
            txtEditEmail = new Guna2TextBox { Text = ktvEmail, Location = new Point(24, fY + 20), Size = new Size(240, 36), BorderRadius = 8, BorderColor = KtvTheme.Border, Font = new Font("Segoe UI", 9F) };
            cardEditModal.Controls.Add(txtEditEmail);

            cardEditModal.Controls.Add(KtvTheme.Label("Ngày sinh *", 284, fY, 8.5F, FontStyle.Bold, KtvTheme.TextMid));
            dtpEditDob = new Guna2DateTimePicker { Value = new DateTime(1992, 8, 15), Format = DateTimePickerFormat.Short, Location = new Point(284, fY + 20), Size = new Size(252, 36), BorderRadius = 8, FillColor = Color.White, BorderColor = KtvTheme.Border, BorderThickness = 1, Font = new Font("Segoe UI", 9F) };
            cardEditModal.Controls.Add(dtpEditDob);

            fY += 72;

            // Address & Gender
            cardEditModal.Controls.Add(KtvTheme.Label("Địa chỉ nơi ở", 24, fY, 8.5F, FontStyle.Bold, KtvTheme.TextMid));
            txtEditAddress = new Guna2TextBox { Text = ktvAddress, Location = new Point(24, fY + 20), Size = new Size(240, 36), BorderRadius = 8, BorderColor = KtvTheme.Border, Font = new Font("Segoe UI", 9F) };
            cardEditModal.Controls.Add(txtEditAddress);

            cardEditModal.Controls.Add(KtvTheme.Label("Giới tính", 284, fY, 8.5F, FontStyle.Bold, KtvTheme.TextMid));
            cboEditGender = new Guna2ComboBox { Location = new Point(284, fY + 20), Size = new Size(252, 36), BorderRadius = 8, BorderColor = KtvTheme.Border, Font = new Font("Segoe UI", 9F) };
            cboEditGender.Items.AddRange(new object[] { "Nữ", "Nam", "Khác" });
            cboEditGender.SelectedIndex = 0;
            cardEditModal.Controls.Add(cboEditGender);

            fY += 72;

            // Shift
            cardEditModal.Controls.Add(KtvTheme.Label("Ca làm việc đăng ký", 24, fY, 8.5F, FontStyle.Bold, KtvTheme.TextMid));
            cboEditShift = new Guna2ComboBox { Location = new Point(24, fY + 20), Size = new Size(512, 36), BorderRadius = 8, BorderColor = KtvTheme.Border, Font = new Font("Segoe UI", 9F) };
            cboEditShift.Items.AddRange(new object[] { "Ca sáng: 07:00 – 15:00", "Ca chiều: 13:00 – 21:00", "Ca tối/đêm: 21:00 – 07:00" });
            cboEditShift.SelectedIndex = 0;
            cardEditModal.Controls.Add(cboEditShift);

            fY += 72;

            // Skills details
            cardEditModal.Controls.Add(KtvTheme.Label("Mô tả tóm tắt kỹ năng chuyên môn", 24, fY, 8.5F, FontStyle.Bold, KtvTheme.TextMid));
            txtEditSkills = new Guna2TextBox { Text = "Có kinh nghiệm 6 năm xét nghiệm huyết học, sinh hóa lâm sàng. Vận hành máy Sysmex XN-1000, Cobas 6000 chuyên nghiệp.", Location = new Point(24, fY + 20), Size = new Size(512, 70), Multiline = true, BorderRadius = 8, BorderColor = KtvTheme.Border, Font = new Font("Segoe UI", 9F) };
            cardEditModal.Controls.Add(txtEditSkills);

            // Footer
            var div = new Guna2Panel { Location = new Point(0, 496), Size = new Size(560, 1), FillColor = KtvTheme.Border };
            cardEditModal.Controls.Add(div);

            btnEditCancel = KtvTheme.Button("Hủy", Color.White, KtvTheme.TextMid);
            btnEditCancel.BorderColor = KtvTheme.Border;
            btnEditCancel.BorderThickness = 1;
            btnEditCancel.Size = new Size(96, 36);
            btnEditCancel.Location = new Point(328, 510);
            btnEditCancel.Click += (s, e) => CloseModal(pnlEditModalOverlay);
            cardEditModal.Controls.Add(btnEditCancel);

            btnEditSave = KtvTheme.Button("💾 Lưu thay đổi", KtvTheme.Teal, Color.White);
            btnEditSave.Size = new Size(130, 36);
            btnEditSave.Location = new Point(20 + 412, 510);
            btnEditSave.Click += BtnEditSave_Click;
            cardEditModal.Controls.Add(btnEditSave);

            pnlEditModalOverlay.Controls.Add(cardEditModal);
            Controls.Add(pnlEditModalOverlay);

            // 2. Build Password Change Modal
            pnlPwModalOverlay = new Guna2Panel
            {
                FillColor = Color.FromArgb(90, 0, 0, 0),
                Location = new Point(0, 0),
                Size = new Size(1200, 800),
                Visible = false
            };
            pnlPwModalOverlay.Click += (s, e) => { if (e.GetType() == typeof(MouseEventArgs) && pnlPwModalOverlay.ClientRectangle.Contains(((MouseEventArgs)e).Location)) CloseModal(pnlPwModalOverlay); };

            cardPwModal = KtvTheme.Card(0, 0, 460, 412);
            cardPwModal.ShadowDecoration.Enabled = true;
            cardPwModal.ShadowDecoration.Depth = 20;

            var lblPwT = KtvTheme.Label("🔒 Đổi mật khẩu tài khoản", 24, 20, 11F, FontStyle.Bold, KtvTheme.TextDark);
            
            var btnPwClose = new Guna2Button
            {
                Text = "✕",
                Size = new Size(28, 28),
                Location = new Point(408, 16),
                BorderRadius = 14,
                FillColor = Color.White,
                ForeColor = KtvTheme.TextLight,
                BorderColor = KtvTheme.Border,
                BorderThickness = 1,
                Font = new Font("Segoe UI", 8F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnPwClose.Click += (s, e) => CloseModal(pnlPwModalOverlay);
            cardPwModal.Controls.AddRange(new Control[] { lblPwT, btnPwClose });

            // Fields
            int pwY = 64;
            cardPwModal.Controls.Add(KtvTheme.Label("Mật khẩu hiện tại *", 24, pwY, 8.5F, FontStyle.Bold, KtvTheme.TextMid));
            txtPwCurrent = new Guna2TextBox { PasswordChar = '●', Location = new Point(24, pwY + 20), Size = new Size(412, 36), BorderRadius = 8, BorderColor = KtvTheme.Border, Font = new Font("Segoe UI", 9F) };
            cardPwModal.Controls.Add(txtPwCurrent);

            pwY += 70;
            cardPwModal.Controls.Add(KtvTheme.Label("Mật khẩu mới *", 24, pwY, 8.5F, FontStyle.Bold, KtvTheme.TextMid));
            txtPwNew = new Guna2TextBox { PasswordChar = '●', Location = new Point(24, pwY + 20), Size = new Size(412, 36), BorderRadius = 8, BorderColor = KtvTheme.Border, Font = new Font("Segoe UI", 9F) };
            cardPwModal.Controls.Add(txtPwNew);

            pwY += 70;
            cardPwModal.Controls.Add(KtvTheme.Label("Xác nhận mật khẩu mới *", 24, pwY, 8.5F, FontStyle.Bold, KtvTheme.TextMid));
            txtPwConfirm = new Guna2TextBox { PasswordChar = '●', Location = new Point(24, pwY + 20), Size = new Size(412, 36), BorderRadius = 8, BorderColor = KtvTheme.Border, Font = new Font("Segoe UI", 9F) };
            cardPwModal.Controls.Add(txtPwConfirm);

            lblPwError = KtvTheme.Label("⚠ Mật khẩu xác nhận không trùng khớp!", 24, pwY + 60, 8F, FontStyle.Bold, KtvTheme.Danger);
            lblPwError.Visible = false;
            cardPwModal.Controls.Add(lblPwError);

            // Footer
            var divPw = new Guna2Panel { Location = new Point(0, 348), Size = new Size(460, 1), FillColor = KtvTheme.Border };
            cardPwModal.Controls.Add(divPw);

            btnPwCancel = KtvTheme.Button("Hủy", Color.White, KtvTheme.TextMid);
            btnPwCancel.BorderColor = KtvTheme.Border;
            btnPwCancel.BorderThickness = 1;
            btnPwCancel.Size = new Size(96, 36);
            btnPwCancel.Location = new Point(220, 360);
            btnPwCancel.Click += (s, e) => CloseModal(pnlPwModalOverlay);
            cardPwModal.Controls.Add(btnPwCancel);

            btnPwSave = KtvTheme.Button("🔒 Đổi mật khẩu", KtvTheme.Teal, Color.White);
            btnPwSave.Size = new Size(116, 36);
            btnPwSave.Location = new Point(324, 360);
            btnPwSave.Click += BtnPwSave_Click;
            cardPwModal.Controls.Add(btnPwSave);

            pnlPwModalOverlay.Controls.Add(cardPwModal);
            Controls.Add(pnlPwModalOverlay);
        }

        /// <summary>
        /// Opens the profile edit form as a dialog.
        /// Replaces the old inline modal overlay approach.
        /// </summary>
        private void OpenEditProfileForm()
        {
            DateTime dob;
            if (!DateTime.TryParseExact(ktvDob, "dd/MM/yyyy",
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None, out dob))
            {
                dob = new DateTime(1992, 8, 15);
            }

            using (var frm = new frmKtvEditProfile(
                ktvName, ktvPhone, ktvEmail,
                dob, ktvAddress, ktvGender,
                ktvShift,
                "Có kinh nghiệm 6 năm xét nghiệm huyết học, sinh hóa lâm sàng. Vận hành máy Sysmex XN-1000, Cobas 6000 chuyên nghiệp."))
            {
                if (frm.ShowDialog(this.ParentForm) == DialogResult.OK)
                {
                    // Commit changes from the form
                    ktvName    = frm.ResultName;
                    ktvPhone   = frm.ResultPhone;
                    ktvEmail   = frm.ResultEmail;
                    ktvDob     = frm.ResultDob.ToString("dd/MM/yyyy");
                    ktvAddress = frm.ResultAddress;
                    ktvGender  = frm.ResultGender;
                    ktvShift   = frm.ResultShift;

                    // Re-render hero area
                    lblHeroName.Text      = ktvName;
                    lblHeroAvatarText.Text = GetInitials(ktvName);

                    // Re-render info cards
                    RenderPersonalInfo();
                    RenderWorkInfo();

                    ShowToastNotification("\u2705 Đã cập nhật thông tin hồ sơ thành công!");
                }
            }
        }

        // BtnEditSave_Click is now handled inside frmKtvEditProfile.
        // Kept here as an empty stub for backward compatibility.
        private void BtnEditSave_Click(object sender, EventArgs e) { }

        private void BtnPwSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPwCurrent.Text) || string.IsNullOrEmpty(txtPwNew.Text) || string.IsNullOrEmpty(txtPwConfirm.Text))
            {
                lblPwError.Text = "⚠ Vui lòng nhập đầy đủ các trường mật khẩu!";
                lblPwError.Visible = true;
                return;
            }

            if (txtPwNew.Text != txtPwConfirm.Text)
            {
                lblPwError.Text = "⚠ Mật khẩu xác nhận không trùng khớp!";
                lblPwError.Visible = true;
                return;
            }

            if (txtPwNew.Text.Length < 8)
            {
                lblPwError.Text = "⚠ Mật khẩu mới phải có tối thiểu 8 ký tự!";
                lblPwError.Visible = true;
                return;
            }

            lblPwError.Visible = false;
            txtPwCurrent.Clear();
            txtPwNew.Clear();
            txtPwConfirm.Clear();

            CloseModal(pnlPwModalOverlay);
            ShowToastNotification("🔒 Mật khẩu tài khoản đã được thay đổi thành công!");
        }

        private void OpenModal(Guna2Panel overlay)
        {
            overlay.Size = new Size(this.Width, this.Height);
            overlay.Visible = true;
            overlay.BringToFront();
        }

        private void CloseModal(Guna2Panel overlay)
        {
            overlay.Visible = false;
            if (lblPwError != null) lblPwError.Visible = false;
        }

        private string GetInitials(string fullName)
        {
            if (string.IsNullOrEmpty(fullName)) return "—";
            var parts = fullName.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length >= 2)
            {
                return (parts[parts.Length - 2].Substring(0, 1) + parts[parts.Length - 1].Substring(0, 1)).ToUpper();
            }
            return fullName.Substring(0, Math.Min(2, fullName.Length)).ToUpper();
        }

        private void ShowToastNotification(string message)
        {
            lblToastText.Text = message;
            pnlToast.Visible = true;
            isToastShowing = true;
            toastTicks = 0;
            pnlToast.Location = new Point(this.Width - pnlToast.Width - 28, this.Height);
            pnlToast.BringToFront();
            tmrToast.Start();
        }

        private void TmrToast_Tick(object sender, EventArgs e)
        {
            int step = 6;
            int targetY = this.Height - pnlToast.Height - 20;

            if (isToastShowing)
            {
                if (pnlToast.Top - step > targetY)
                {
                    pnlToast.Top -= step;
                }
                else
                {
                    pnlToast.Top = targetY;
                    toastTicks++;
                    if (toastTicks > 120) // Display toast for ~2.4 seconds
                    {
                        isToastShowing = false;
                    }
                }
            }
            else
            {
                int exitY = this.Height + 10;
                if (pnlToast.Top + step < exitY)
                {
                    pnlToast.Top += step;
                }
                else
                {
                    pnlToast.Top = exitY;
                    pnlToast.Visible = false;
                    tmrToast.Stop();
                }
            }
        }
    }
}
