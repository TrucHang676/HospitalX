using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace HospitalX.GUI.PH2.KyThuatVien
{
    public partial class ucKtvThongBao : UserControl
    {
        // Internal data class for notifications
        private class KtvNotification
        {
            public string Id { get; set; }
            public string Title { get; set; }
            public string Body { get; set; }
            public string Time { get; set; }
            public string DateGroup { get; set; } // "Hôm nay", "Hôm qua"
            public string Type { get; set; } // "Phân công", "Kết quả", "Khẩn cấp", "Hệ thống", "Chuyển ca", "Đào tạo"
            public bool IsUnread { get; set; }
            public bool IsUrgent { get; set; }
            public string[] Tags { get; set; }
            public string ActionText { get; set; }
            public string ActionType { get; set; } // "view_result", "view_assignment", "register", "swap", "none"
        }
        // Layout UI controls
        private Label lblHeroTitle;
        private Label lblHeroSub;
        private Guna2Button btnHeroMarkAll;
        private Label lblFilterTitle;
        private Guna2TextBox txtSearch;
        private Guna2Panel divFilter;
        private FlowLayoutPanel flpCategories;

        // Stats Strip Cards (Top of list)
        private Guna2Panel[] cardStats = new Guna2Panel[4];
        private Label[] lblStatVals = new Label[4];

        // List Toolbar
        private Guna2Button btnPillAll;
        private Guna2Button btnPillUnread;
        private Guna2Button btnPillUrgent;
        private Guna2ComboBox cboSort;
        private Guna2Button btnMarkAll;

        // Custom Toast Notification
        private Label lblToastText;
        private Timer tmrToast;
        private int toastTicks = 0;
        private bool isToastShowing = false;

        // Local state
        private List<KtvNotification> allNotifs = new List<KtvNotification>();
        private string activePill = "all"; // "all", "unread", "urgent"
        private string activeCategory = "all"; // "all", "unread", "read", "Phân công", "Kết quả", "Khẩn cấp", "Hệ thống", "Đào tạo"
        private List<Guna2Panel> catItemPanels = new List<Guna2Panel>();

        public ucKtvThongBao()
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

            InitializeMockData();
            BuildControls();
            
            this.Resize += UcKtvThongBao_Resize;
            this.Load += UcKtvThongBao_Load;
        }

        private void UcKtvThongBao_Load(object sender, EventArgs e)
        {
            LayoutControls();
            RenderNotificationsList();
        }

        private void UcKtvThongBao_Resize(object sender, EventArgs e)
        {
            LayoutControls();
        }

        private void InitializeMockData()
        {
            allNotifs.Clear();
            allNotifs.Add(new KtvNotification
            {
                Id = "n1",
                Title = "Kết quả XN BẤT THƯỜNG — Cần xử lý ngay",
                Time = "5 phút trước",
                DateGroup = "HÔM NAY",
                Type = "Khẩn cấp",
                Body = "Kết quả Hemoglobin = 6.2 g/dL của bệnh nhân Trần Văn Bình (BV-2025-00412) vượt ngưỡng nguy hiểm. Bác sĩ Lê Minh Đức yêu cầu xác nhận lại mẫu và thông báo kết quả khẩn.",
                IsUnread = true,
                IsUrgent = true,
                Tags = new[] { "🚨 Khẩn cấp", "🔬 Kết quả XN", "BV-2025-00412" },
                ActionText = "🔬 Xem kết quả",
                ActionType = "view_result"
            });

            allNotifs.Add(new KtvNotification
            {
                Id = "n2",
                Title = "Phân công khẩn — XN Nước tiểu",
                Time = "22 phút trước",
                DateGroup = "HÔM NAY",
                Type = "Khẩn cấp",
                Body = "Bác sĩ Nguyễn Thị Hoa vừa phân công gấp xét nghiệm Urinalysis (tổng phân tích nước tiểu) cho bệnh nhân Lê Văn Dũng (BV-2025-00421). Lý do: nghi ngờ nhiễm trùng đường tiết niệu cấp. Cần thực hiện trước 09:00.",
                IsUnread = true,
                IsUrgent = true,
                Tags = new[] { "🚨 Khẩn cấp", "📋 Phân công mới" },
                ActionText = "📋 Xem phân công",
                ActionType = "view_assignment"
            });

            allNotifs.Add(new KtvNotification
            {
                Id = "n3",
                Title = "Bác sĩ đã duyệt kết quả XN ngực",
                Time = "1 giờ trước",
                DateGroup = "HÔM NAY",
                Type = "Kết quả",
                Body = "Bác sĩ Trần Quốc Hùng đã duyệt và xác nhận kết quả Chụp X-quang ngực thẳng của bệnh nhân Phạm Thị Lan (BV-2025-00403). Kết quả đã được ghi vào hồ sơ bệnh án.",
                IsUnread = true,
                IsUrgent = false,
                Tags = new[] { "✅ Đã duyệt", "BV-2025-00403" },
                ActionText = "🖨 In kết quả",
                ActionType = "none"
            });

            allNotifs.Add(new KtvNotification
            {
                Id = "n4",
                Title = "Phân công dịch vụ mới — Điện tim ECG",
                Time = "2 giờ trước",
                DateGroup = "HÔM NAY",
                Type = "Phân công",
                Body = "Bạn được phân công thực hiện Điện tim (ECG 12 chuyển đạo) cho bệnh nhân Vũ Thị Hằng (BV-2025-00435). Thời gian: 10:30 hôm nay tại Phòng Tim mạch. Bác sĩ chỉ định: Phạm Anh Tuấn.",
                IsUnread = true,
                IsUrgent = false,
                Tags = new[] { "📋 Phân công mới", "Phòng Tim mạch" },
                ActionText = "📋 Xem chi tiết",
                ActionType = "view_assignment"
            });

            allNotifs.Add(new KtvNotification
            {
                Id = "n5",
                Title = "Nhận bàn giao ca từ KTV Minh Anh",
                Time = "3 giờ trước",
                DateGroup = "HÔM NAY",
                Type = "Chuyển ca",
                Body = "KTV Nguyễn Minh Anh đã bàn giao 2 dịch vụ chưa hoàn thành cho bạn do nghỉ đột xuất: (1) Sinh hóa máu — BN Hoàng Thị Thu và (2) DEXA Scan — BN Phạm Văn Sơn. Vui lòng xác nhận.",
                IsUnread = true,
                IsUrgent = false,
                Tags = new[] { "🔄 Chuyển ca", "2 dịch vụ" },
                ActionText = "✅ Xác nhận nhận ca",
                ActionType = "swap"
            });

            allNotifs.Add(new KtvNotification
            {
                Id = "n6",
                Title = "Khen thưởng hiệu suất xuất sắc — Tháng 04/2025",
                Time = "Hôm qua · 08:00",
                DateGroup = "HÔM QUA",
                Type = "Đào tạo",
                Body = "Ban Giám đốc Khoa Xét nghiệm đánh giá bạn đạt hiệu suất xuất sắc trong tháng 04/2025 với 200 dịch vụ hoàn thành, tỷ lệ sai sót kỹ thuật 0%. Chúc mừng!",
                IsUnread = false,
                IsUrgent = false,
                Tags = new[] { "🏆 Khen thưởng" },
                ActionText = "",
                ActionType = "none"
            });

            allNotifs.Add(new KtvNotification
            {
                Id = "n7",
                Title = "Thông báo bảo trì hệ thống MedCore HIS",
                Time = "Hôm qua · 16:30",
                DateGroup = "HÔM QUA",
                Type = "Hệ thống",
                Body = "Hệ thống MedCore HIS sẽ được bảo trì định kỳ vào Chủ nhật 25/05/2025 từ 02:00 – 04:00 sáng. Trong thời gian này, một số phân hệ có thể không khả dụng. Vui lòng lưu hồ sơ trước 01:45.",
                IsUnread = false,
                IsUrgent = false,
                Tags = new[] { "⚙️ Hệ thống", "Bảo trì" },
                ActionText = "",
                ActionType = "none"
            });

            allNotifs.Add(new KtvNotification
            {
                Id = "n8",
                Title = "Lịch tập huấn — Kỹ năng XN miễn dịch nâng cao",
                Time = "Hôm qua · 09:00",
                DateGroup = "HÔM QUA",
                Type = "Đào tạo",
                Body = "Phòng Đào tạo thông báo lịch tập huấn 'Kỹ thuật xét nghiệm miễn dịch nâng cao' vào Thứ Ba 27/05/2025, từ 08:00 – 11:00 tại Hội trường A. Hạn chót đăng ký: 26/05.",
                IsUnread = false,
                IsUrgent = false,
                Tags = new[] { "📚 Đào tạo" },
                ActionText = "📝 Đăng ký tham dự",
                ActionType = "register"
            });
        }

        private void BuildControls()
        {
            // Do NOT call Controls.Clear() and do NOT re-instantiate container panels because they are created in InitializeComponent()!

            // Clear children of main container panels to rebuild dynamically at runtime
            pnlHero.Controls.Clear();
            pnlFilter.Controls.Clear();
            pnlToolbar.Controls.Clear();
            pnlToast.Controls.Clear();

            pnlHero.BorderRadius = 14;
            pnlHero.FillColor = KtvTheme.TealDark;
            pnlHero.ShadowDecoration.Enabled = true;
            pnlHero.ShadowDecoration.Color = Color.FromArgb(45, 15, 110, 86);
            pnlHero.ShadowDecoration.Depth = 12;

            lblHeroTitle = KtvTheme.Label("Trung tâm thông báo", 24, 18, 17F, FontStyle.Bold, Color.White);
            lblHeroSub = KtvTheme.Label("Theo dõi phân công, cảnh báo xét nghiệm và cập nhật nghiệp vụ trong ca trực.", 24, 50, 9.5F, FontStyle.Regular, Color.FromArgb(214, 239, 232));
            lblHeroSub.AutoSize = false;
            lblHeroSub.Size = new Size(640, 24);

            btnHeroMarkAll = new Guna2Button
            {
                Text = "Đọc tất cả",
                Size = new Size(116, 34),
                BorderRadius = 8,
                FillColor = Color.White,
                ForeColor = KtvTheme.Teal,
                Font = new Font("Segoe UI", 8.8F, FontStyle.Bold),
                Cursor = Cursors.Hand,
                HoverState = { FillColor = Color.FromArgb(232, 245, 240) }
            };
            btnHeroMarkAll.Click += BtnMarkAll_Click;

            pnlHero.Controls.AddRange(new Control[] { lblHeroTitle, lblHeroSub, btnHeroMarkAll });

            // 1. Filter Panel (Left)
            pnlFilter.BorderColor = KtvTheme.Border;
            pnlFilter.ShadowDecoration.Enabled = true;
            pnlFilter.ShadowDecoration.Color = KtvTheme.Teal;
            pnlFilter.ShadowDecoration.Depth = 8;
            pnlFilter.ShadowDecoration.Shadow = new Padding(0, 2, 8, 2);

            lblFilterTitle = KtvTheme.Label("🗂 Phân loại thông báo", 20, 18, 10.5F, FontStyle.Bold, KtvTheme.TextDark);
            pnlFilter.Controls.Add(lblFilterTitle);

            txtSearch = new Guna2TextBox
            {
                PlaceholderText = "Tìm kiếm thông báo…",
                FillColor = Color.FromArgb(244, 247, 250),
                BorderColor = KtvTheme.Border,
                BorderRadius = 8,
                Font = new Font("Segoe UI", 9F),
                ForeColor = KtvTheme.TextDark,
                PlaceholderForeColor = KtvTheme.TextLight,
                Size = new Size(260, 36),
                Location = new Point(20, 52)
            };
            txtSearch.TextChanged += TxtSearch_TextChanged;
            pnlFilter.Controls.Add(txtSearch);

            divFilter = new Guna2Panel { Location = new Point(0, 102), Size = new Size(300, 1), FillColor = KtvTheme.Border };
            pnlFilter.Controls.Add(divFilter);

            flpCategories = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                AutoScroll = true,
                BackColor = Color.White
            };
            pnlFilter.Controls.Add(flpCategories);

            // 2. Build Toolbar (Right Column inside Scroll container)
            pnlToolbar.ShadowDecoration.Enabled = true;
            pnlToolbar.ShadowDecoration.Color = KtvTheme.Teal;
            pnlToolbar.ShadowDecoration.Depth = 6;

            btnPillAll = CreatePillButton("Tất cả (12)", true);
            btnPillAll.Location = new Point(14, 8);
            btnPillAll.Click += (s, e) => SwitchPill("all");

            btnPillUnread = CreatePillButton("Chưa đọc (5)", false);
            btnPillUnread.Location = new Point(116, 8);
            btnPillUnread.Click += (s, e) => SwitchPill("unread");

            btnPillUrgent = CreatePillButton("Khẩn cấp (2)", false);
            btnPillUrgent.Location = new Point(228, 8);
            btnPillUrgent.Click += (s, e) => SwitchPill("urgent");

            pnlToolbar.Controls.AddRange(new Control[] { btnPillAll, btnPillUnread, btnPillUrgent });

            cboSort = new Guna2ComboBox
            {
                Size = new Size(188, 34),
                BorderRadius = 6,
                BorderColor = KtvTheme.Border,
                Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
                ForeColor = KtvTheme.TextMid,
                ItemHeight = 28,
                DropDownHeight = 94,
                DropDownWidth = 188,
                MaxDropDownItems = 3,
                IntegralHeight = false
            };
            cboSort.Items.AddRange(new object[] { "Mới nhất trước", "Cũ nhất trước", "Ưu tiên cao nhất" });
            cboSort.SelectedIndex = 0;
            pnlToolbar.Controls.Add(cboSort);

            btnMarkAll = new Guna2Button
            {
                Text = "✅ Đọc tất cả",
                Size = new Size(110, 32),
                BorderRadius = 6,
                FillColor = Color.Transparent,
                ForeColor = KtvTheme.Teal,
                BorderColor = KtvTheme.Border,
                BorderThickness = 1,
                Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
                Cursor = Cursors.Hand,
                HoverState = { FillColor = KtvTheme.TealLight }
            };
            btnMarkAll.Click += BtnMarkAll_Click;
            pnlToolbar.Controls.Add(btnMarkAll);

            // 3. Build Toast Notification
            pnlToast.Size = new Size(360, 52);
            pnlToast.BorderRadius = 10;
            pnlToast.FillColor = KtvTheme.TealDark;
            pnlToast.Visible = false;
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

            tmrToast = new Timer { Interval = 20 };
            tmrToast.Tick += TmrToast_Tick;
        }

        private void LayoutControls()
        {
            int margin = 28;
            int gap = 20;
            int heroH = 92;

            pnlHero.Location = new Point(margin, margin);
            pnlHero.Size = new Size(this.Width - 2 * margin, heroH);
            btnHeroMarkAll.Location = new Point(pnlHero.Width - btnHeroMarkAll.Width - 24, 29);
            lblHeroSub.Width = Math.Max(320, pnlHero.Width - btnHeroMarkAll.Width - 90);

            int bodyY = margin + heroH + 18;
            int availHeight = this.Height - bodyY - margin;
            if (availHeight < 200) availHeight = 500;

            // 1. Layout Left Categories panel
            pnlFilter.Location = new Point(margin, bodyY);
            pnlFilter.Size = new Size(300, availHeight);
            
            flpCategories.Location = new Point(1, 106);
            flpCategories.Size = new Size(298, availHeight - 108);
            BuildCategoriesList();

            // 2. Layout Right Scroll panel container
            int listX = pnlFilter.Right + gap;
            int listW = this.Width - listX - margin;
            if (listW < 400) listW = 400;

            pnlNotifScroll.Location = new Point(listX, bodyY);
            pnlNotifScroll.Size = new Size(listW, availHeight);

            // A. Stats Cards (Top)
            int statW = (listW - 3 * gap) / 4;
            int statY = 0;
            string[] statLbls = { "Chưa đọc", "Khẩn cấp", "Hôm nay", "Tháng này" };
            string[] statVals = { GetUnreadCount().ToString(), "2", "12", "48" };
            Color[] valColors = { KtvTheme.Teal, KtvTheme.Danger, KtvTheme.TextDark, KtvTheme.TextDark };

            for (int i = 0; i < 4; i++)
            {
                cardStats[i].Controls.Clear();
                cardStats[i].ShadowDecoration.Enabled = true;
                cardStats[i].ShadowDecoration.Color = KtvTheme.Teal;
                cardStats[i].ShadowDecoration.Depth = 6;

                lblStatVals[i] = KtvTheme.Label(statVals[i], 20, 8, 20F, FontStyle.Bold, valColors[i]);
                lblStatVals[i].AutoSize = false;
                lblStatVals[i].Size = new Size(80, 36);

                var lblL = KtvTheme.Label(statLbls[i], 20, 44, 9F, FontStyle.Regular, KtvTheme.TextLight);
                lblL.AutoSize = false;
                lblL.Size = new Size(100, 20);

                cardStats[i].Controls.AddRange(new Control[] { lblStatVals[i], lblL });
                
                cardStats[i].Location = new Point(0 + i * (statW + gap), statY);
                cardStats[i].Size = new Size(statW, 72);
                cardStats[i].FillColor = i == 0 ? Color.FromArgb(242, 250, 247) : (i == 1 ? Color.FromArgb(253, 244, 244) : Color.White);
                cardStats[i].BorderColor = i == 0 ? Color.FromArgb(196, 224, 214) : (i == 1 ? Color.FromArgb(248, 218, 218) : KtvTheme.Border);
                lblStatVals[i].Text = statVals[i];
                lblStatVals[i].Width = statW - 30;
                cardStats[i].Controls[1].Width = statW - 30;
            }

            // B. Toolbar Card
            pnlToolbar.Location = new Point(0, statY + 72 + 16);
            pnlToolbar.Size = new Size(listW - 12, 52);

            btnPillAll.Location = new Point(14, 8);
            btnPillUnread.Location = new Point(124, 8);
            btnPillUrgent.Location = new Point(234, 8);
            
            cboSort.Location = new Point(listW - 320, 10);
            btnMarkAll.Location = new Point(listW - 146, 10);

            // Re-render the notification rows
            RenderNotificationsList();

            // Setup toast placement
            pnlToast.Location = new Point(this.Width - pnlToast.Width - margin, this.Height - pnlToast.Height - 16);
            pnlToast.BringToFront();
        }

        private void BuildCategoriesList()
        {
            flpCategories.Controls.Clear();
            catItemPanels.Clear();

            int allCount = allNotifs.Count;
            int unreadCount = GetUnreadCount();
            int readCount = allCount - unreadCount;

            // SECTION 1: TRẠNG THÁI
            flpCategories.Controls.Add(CreateSectionHeader("TRẠNG THÁI"));
            flpCategories.Controls.Add(CreateCategoryItem("🗂 Tất cả", allCount.ToString(), "all", activeCategory == "all"));
            flpCategories.Controls.Add(CreateCategoryItem("💠 Chưa đọc", unreadCount.ToString(), "unread", activeCategory == "unread", KtvTheme.Teal));
            flpCategories.Controls.Add(CreateCategoryItem("☑ Đã đọc", readCount.ToString(), "read", activeCategory == "read"));

            // SECTION 2: LOẠI THÔNG BÁO
            flpCategories.Controls.Add(CreateSectionHeader("LOẠI THÔNG BÁO"));
            int cPrio = allNotifs.Count(x => x.Type == "Phân công");
            int cRes = allNotifs.Count(x => x.Type == "Kết quả");
            int cUrg = allNotifs.Count(x => x.Type == "Khẩn cấp");
            int cSys = allNotifs.Count(x => x.Type == "Hệ thống");
            int cEdu = allNotifs.Count(x => x.Type == "Đào tạo");

            flpCategories.Controls.Add(CreateCategoryItem("🧾 Phân công dịch vụ", cPrio.ToString(), "Phân công", activeCategory == "Phân công"));
            flpCategories.Controls.Add(CreateCategoryItem("🧪 Kết quả cần duyệt", cRes.ToString(), "Kết quả", activeCategory == "Kết quả"));
            flpCategories.Controls.Add(CreateCategoryItem("🚑 Khẩn cấp", cUrg.ToString(), "Khẩn cấp", activeCategory == "Khẩn cấp", KtvTheme.Danger));
            flpCategories.Controls.Add(CreateCategoryItem("⚙ Hệ thống", cSys.ToString(), "Hệ thống", activeCategory == "Hệ thống"));
            flpCategories.Controls.Add(CreateCategoryItem("📣 Thông báo chung", cEdu.ToString(), "Đào tạo", activeCategory == "Đào tạo"));

            // SECTION 3: THỜI GIAN
            flpCategories.Controls.Add(CreateSectionHeader("THỜI GIAN"));
            flpCategories.Controls.Add(CreateCategoryItem("🕘 Hôm nay", "5", "today", activeCategory == "today"));
            flpCategories.Controls.Add(CreateCategoryItem("🗓 7 ngày qua", "8", "week", activeCategory == "week"));
        }

        private Label CreateSectionHeader(string text)
        {
            var lbl = KtvTheme.Label(text, 0, 0, 7.5F, FontStyle.Bold, KtvTheme.TextLight);
            lbl.Margin = new Padding(12, 14, 12, 6);
            return lbl;
        }

        private Guna2Panel CreateCategoryItem(string text, string count, string catCode, bool active, Color? countBg = null)
        {
            Color badgeFill = Color.FromArgb(228, 238, 244);
            Color badgeFore = KtvTheme.TextLight;

            if (active)
            {
                badgeFill = KtvTheme.Teal;
                badgeFore = Color.White;
            }
            else if (countBg.HasValue)
            {
                badgeFill = countBg.Value;
                badgeFore = Color.White;
            }

            var pnl = new Guna2Panel
            {
                Size = new Size(276, 36),
                BorderRadius = 8,
                FillColor = active ? KtvTheme.TealLight : Color.White,
                BorderThickness = active ? 1 : 0,
                BorderColor = active ? Color.FromArgb(194, 224, 214) : Color.Transparent,
                Cursor = Cursors.Hand,
                Margin = new Padding(10, 3, 10, 3)
            };
            pnl.Click += (s, e) => SwitchCategory(catCode);
            pnl.MouseEnter += (s, e) => SetCategoryHover(pnl, true, active);
            pnl.MouseLeave += (s, e) => SetCategoryHover(pnl, false, active);

            var lblT = KtvTheme.Label(text, 10, 9, 8.8F, active ? FontStyle.Bold : FontStyle.Regular, active ? KtvTheme.Teal : KtvTheme.TextMid);
            lblT.Click += (s, e) => SwitchCategory(catCode);
            lblT.MouseEnter += (s, e) => SetCategoryHover(pnl, true, active);
            lblT.MouseLeave += (s, e) => SetCategoryHover(pnl, false, active);
            pnl.Controls.Add(lblT);

            var pnlCount = new Guna2Panel
            {
                Size = new Size(34, 20),
                Location = new Point(232, 8),
                BorderRadius = 10,
                FillColor = badgeFill
            };
            pnlCount.ShadowDecoration.Enabled = active || countBg.HasValue;
            pnlCount.ShadowDecoration.Color = badgeFill;
            pnlCount.ShadowDecoration.Depth = 3;

            var lblC = KtvTheme.Label(count, 0, 0, 7.5F, FontStyle.Bold, badgeFore);
            lblC.AutoSize = false;
            lblC.Location = new Point(0, 0);
            lblC.Size = new Size(34, 20);
            lblC.TextAlign = ContentAlignment.MiddleCenter;
            pnlCount.Controls.Add(lblC);
            pnl.Controls.Add(pnlCount);

            lblC.Click += (s, e) => SwitchCategory(catCode);
            pnlCount.Click += (s, e) => SwitchCategory(catCode);
            pnlCount.MouseEnter += (s, e) => SetCategoryHover(pnl, true, active);
            pnlCount.MouseLeave += (s, e) => SetCategoryHover(pnl, false, active);

            catItemPanels.Add(pnl);
            return pnl;
        }

        private void SetCategoryHover(Guna2Panel panel, bool hover, bool active)
        {
            if (panel == null || active) return;
            panel.FillColor = hover ? Color.FromArgb(244, 250, 248) : Color.White;
            panel.BorderThickness = hover ? 1 : 0;
            panel.BorderColor = hover ? Color.FromArgb(218, 232, 226) : Color.Transparent;
        }

        private void RenderNotificationsList()
        {
            if (pnlNotifScroll == null) return;

            // Remove previous rows (they are in pnlNotifScroll starting below the toolbar)
            var toRemove = new List<Control>();
            foreach (Control c in pnlNotifScroll.Controls)
            {
                if (c.Location.Y > pnlToolbar.Bottom)
                {
                    toRemove.Add(c);
                }
            }
            foreach (var c in toRemove) c.Dispose();

            // Refresh toolbar pills counts
            btnPillAll.Text = $"Tất cả ({allNotifs.Count})";
            btnPillUnread.Text = $"Chưa đọc ({GetUnreadCount()})";
            btnPillUrgent.Text = $"Khẩn cấp ({allNotifs.Count(x => x.IsUrgent)})";

            // Update stats cards numbers
            if (lblStatVals[0] != null) lblStatVals[0].Text = GetUnreadCount().ToString();

            // Filter data
            string searchKey = txtSearch.Text.Trim().ToLowerInvariant();
            var query = allNotifs.AsEnumerable();

            // Sort or Search
            if (!string.IsNullOrEmpty(searchKey))
            {
                query = query.Where(x => x.Title.ToLowerInvariant().Contains(searchKey) || x.Body.ToLowerInvariant().Contains(searchKey));
            }

            // Toolbar Pills Filter
            if (activePill == "unread") query = query.Where(x => x.IsUnread);
            else if (activePill == "urgent") query = query.Where(x => x.IsUrgent);

            // Left Categories Filter
            if (activeCategory == "unread") query = query.Where(x => x.IsUnread);
            else if (activeCategory == "read") query = query.Where(x => !x.IsUnread);
            else if (activeCategory == "today") query = query.Where(x => x.DateGroup == "HÔM NAY");
            else if (activeCategory == "week") query = query.Where(x => x.DateGroup == "HÔM NAY" || x.DateGroup == "HÔM QUA");
            else if (activeCategory != "all") query = query.Where(x => x.Type == activeCategory);

            var list = query.ToList();

            int yRow = pnlToolbar.Bottom + 16;
            int cardW = pnlNotifScroll.Width - 14;

            // Group by Date Groups
            var groups = list.GroupBy(x => x.DateGroup).ToList();

            if (list.Count == 0)
            {
                // Empty state card
                var cardEmpty = KtvTheme.Card(0, yRow, cardW, 180);
                var lblE1 = KtvTheme.Label("📭 Hộp thư thông báo trống", 0, 50, 11F, FontStyle.Bold, KtvTheme.TextLight);
                lblE1.Size = new Size(cardW, 28);
                lblE1.TextAlign = ContentAlignment.MiddleCenter;
                var lblE2 = KtvTheme.Label("Bạn không có thông báo nào phù hợp với bộ lọc hiện tại.", 0, 84, 9F, FontStyle.Regular, KtvTheme.TextLight);
                lblE2.Size = new Size(cardW, 20);
                lblE2.TextAlign = ContentAlignment.MiddleCenter;
                cardEmpty.Controls.AddRange(new Control[] { lblE1, lblE2 });
                pnlNotifScroll.Controls.Add(cardEmpty);
                return;
            }

            foreach (var group in groups)
            {
                // Render Date Divider
                var pnlDivider = new Guna2Panel
                {
                    Location = new Point(0, yRow),
                    Size = new Size(cardW, 30),
                    FillColor = KtvTheme.Bg,
                    BorderRadius = 4,
                    CustomBorderColor = KtvTheme.Border,
                    CustomBorderThickness = new Padding(0, 1, 0, 1)
                };
                string divText = group.Key == "HÔM NAY" ? "📅 Hôm nay — Thứ Bảy, 24/05/2025" : "📅 Hôm qua — Thứ Sáu, 23/05/2025";
                var lblDivText = KtvTheme.Label(divText, 16, 5, 8F, FontStyle.Bold, KtvTheme.TextLight);
                pnlDivider.Controls.Add(lblDivText);
                pnlNotifScroll.Controls.Add(pnlDivider);

                yRow += 30 + 12;

                foreach (var notif in group)
                {
                    // Render Notification Card
                    int rowH = notif.IsUrgent ? 150 : 142;
                    var notifCard = new Guna2Panel
                    {
                        Location = new Point(0, yRow),
                        Size = new Size(cardW, rowH),
                        BorderRadius = 12,
                        BorderColor = notif.IsUrgent ? Color.FromArgb(248, 204, 204) : (notif.IsUnread ? Color.FromArgb(196, 224, 214) : KtvTheme.Border),
                        BorderThickness = 1,
                        FillColor = notif.IsUnread ? Color.FromArgb(242, 250, 247) : Color.White
                    };

                    // Shadow effect
                    notifCard.ShadowDecoration.Enabled = true;
                    notifCard.ShadowDecoration.Color = KtvTheme.Teal;
                    notifCard.ShadowDecoration.Depth = 4;
                    notifCard.ShadowDecoration.Shadow = new Padding(0, 2, 6, 2);

                    // Unread vertical bar
                    var pnlUnreadBar = new Guna2Panel
                    {
                        Size = new Size(4, 132),
                        Location = new Point(0, 1),
                        BorderRadius = 2,
                        FillColor = notif.IsUnread ? (notif.IsUrgent ? KtvTheme.Danger : KtvTheme.Teal) : Color.Transparent
                    };
                    pnlUnreadBar.Height = rowH - 2;
                    notifCard.Controls.Add(pnlUnreadBar);

                    // Icon Circle
                    var pnlIcon = new Guna2Panel
                    {
                        Size = new Size(42, 42),
                        Location = new Point(18, 20),
                        BorderRadius = 21,
                        UseTransparentBackground = true,
                        FillColor = notif.IsUrgent ? KtvTheme.DangerSoft : (notif.Type == "Phân công" ? KtvTheme.AccentSoft : (notif.Type == "Hệ thống" ? KtvTheme.InfoSoft : KtvTheme.TealLight))
                    };
                    string emoji = notif.IsUrgent ? "🚨" : (notif.Type == "Phân công" ? "📋" : (notif.Type == "Hệ thống" ? "🏥" : "✅"));
                    var lblEmoji = KtvTheme.Label(emoji, 0, 0, 11F, FontStyle.Regular, Color.Black);
                    lblEmoji.AutoSize = false;
                    lblEmoji.Location = new Point(0, 0);
                    lblEmoji.Size = new Size(42, 42);
                    lblEmoji.TextAlign = ContentAlignment.MiddleCenter;
                    pnlIcon.Controls.Add(lblEmoji);
                    notifCard.Controls.Add(pnlIcon);

                    // Title
                    var lblTitle = KtvTheme.Label(notif.Title, 72, 14, 9.5F, notif.IsUnread ? FontStyle.Bold : FontStyle.Bold, notif.IsUnread ? KtvTheme.TextDark : KtvTheme.TextMid);
                    notifCard.Controls.Add(lblTitle);

                    // Time
                    var lblTime = KtvTheme.Label(notif.Time, cardW - 130, 14, 8F, FontStyle.Regular, KtvTheme.TextLight);
                    lblTime.Size = new Size(110, 18);
                    lblTime.TextAlign = ContentAlignment.TopRight;
                    notifCard.Controls.Add(lblTime);

                    // Body Description
                    var lblBody = KtvTheme.Label(notif.Body, 72, 40, 8.8F, FontStyle.Regular, KtvTheme.TextMid);
                    lblBody.AutoSize = false;
                    lblBody.Size = new Size(cardW - 104, 46);
                    lblBody.AutoEllipsis = true;
                    notifCard.Controls.Add(lblBody);

                    // Tags stack (horizontal flow)
                    int tagX = 72;
                    foreach (var tag in notif.Tags)
                    {
                        var pnlTag = new Guna2Panel
                        {
                            Location = new Point(tagX, 94),
                            Size = new Size(100, 20),
                            BorderRadius = 10,
                            FillColor = notif.IsUrgent ? KtvTheme.DangerSoft : KtvTheme.TealLight
                        };
                        var lblTagText = KtvTheme.Label(tag, 0, 0, 7.2F, FontStyle.Bold, notif.IsUrgent ? KtvTheme.Danger : KtvTheme.Teal);
                        lblTagText.Size = new Size(100, 20);
                        lblTagText.TextAlign = ContentAlignment.MiddleCenter;
                        pnlTag.Controls.Add(lblTagText);

                        using (var gr = CreateGraphics())
                        {
                            SizeF sz = gr.MeasureString(tag, lblTagText.Font);
                            pnlTag.Width = (int)sz.Width + 18;
                            lblTagText.Width = (int)sz.Width + 18;
                        }

                        notifCard.Controls.Add(pnlTag);
                        tagX += pnlTag.Width + 6;
                    }

                    // Action buttons (under or inside row)
                    int rightPad = 24;
                    int readW = 88;
                    int actionW = 154;
                    int readX = cardW - rightPad - readW;
                    int actionX = cardW - rightPad - actionW;
                    if (notif.IsUnread)
                    {
                        var btnRead = new Guna2Button
                        {
                            Text = "Đã đọc",
                            Size = new Size(readW, 26),
                            Location = new Point(readX, rowH - 43),
                            BorderRadius = 6,
                            FillColor = Color.White,
                            ForeColor = KtvTheme.TextMid,
                            BorderColor = KtvTheme.Border,
                            BorderThickness = 1,
                            Font = new Font("Segoe UI", 8F, FontStyle.Bold),
                            TextAlign = HorizontalAlignment.Center,
                            TextOffset = new Point(0, 0),
                            Padding = new Padding(0),
                            Cursor = Cursors.Hand
                        };
                        btnRead.Click += (s, e) => MarkNotifRead(notif);
                        notifCard.Controls.Add(btnRead);
                        actionX = readX - actionW - 10;
                    }

                    if (!string.IsNullOrEmpty(notif.ActionText))
                    {
                        var btnAction = new Guna2Button
                        {
                            Text = notif.ActionText,
                            Size = new Size(actionW, 26),
                            Location = new Point(actionX, rowH - 43),
                            BorderRadius = 6,
                            FillColor = KtvTheme.Teal,
                            ForeColor = Color.White,
                            Font = new Font("Segoe UI", 8F, FontStyle.Bold),
                            TextAlign = HorizontalAlignment.Center,
                            TextOffset = new Point(0, 0),
                            Cursor = Cursors.Hand
                        };
                        btnAction.Click += (s, e) => {
                            MarkNotifRead(notif); // Automatically mark read
                            if (notif.ActionType == "view_result")
                            {
                                ShowToastNotification("🔬 Chuyển sang phân hệ Nhập kết quả lâm sàng!");
                            }
                            else if (notif.ActionType == "view_assignment")
                            {
                                ShowToastNotification("📋 Chuyển sang danh mục Dịch vụ được phân công!");
                            }
                            else
                            {
                                ShowToastNotification($"✅ Đăng ký thành công: {notif.Title}");
                            }
                        };
                        notifCard.Controls.Add(btnAction);
                    }

                    pnlNotifScroll.Controls.Add(notifCard);
                    yRow += rowH + 14;
                }
            }

            // Pagination footer at bottom
            var pnlPage = new Guna2Panel
            {
                Location = new Point(0, yRow),
                Size = new Size(cardW, 46),
                FillColor = Color.White,
                BorderRadius = 8,
                BorderColor = KtvTheme.Border,
                BorderThickness = 1
            };
            var lblPInfo = KtvTheme.Label($"Hiển thị {list.Count} / {allNotifs.Count} thông báo", 20, 13, 8.8F, FontStyle.Regular, KtvTheme.TextLight);
            pnlPage.Controls.Add(lblPInfo);

            // Circular page buttons
            var btnPrev = CreatePageButton("‹", false);
            btnPrev.Location = new Point(cardW - 130, 8);
            var btnP1 = CreatePageButton("1", true);
            btnP1.Location = new Point(cardW - 94, 8);
            var btnNext = CreatePageButton("›", false);
            btnNext.Location = new Point(cardW - 58, 8);
            pnlPage.Controls.AddRange(new Control[] { btnPrev, btnP1, btnNext });

            pnlNotifScroll.Controls.Add(pnlPage);
        }

        private void MarkNotifRead(KtvNotification notif)
        {
            if (!notif.IsUnread) return;
            notif.IsUnread = false;

            // Trigger animation
            ShowToastNotification("✅ Đã đánh dấu thông báo là đã đọc!");
            RenderNotificationsList();
            BuildCategoriesList();
        }

        private void BtnMarkAll_Click(object sender, EventArgs e)
        {
            int unreads = allNotifs.Count(x => x.IsUnread);
            if (unreads == 0) return;

            foreach (var n in allNotifs)
            {
                n.IsUnread = false;
            }

            ShowToastNotification("✅ Đã đánh dấu đọc toàn bộ thông báo!");
            RenderNotificationsList();
            BuildCategoriesList();
        }

        private void SwitchPill(string pill)
        {
            activePill = pill;
            btnPillAll.Checked = (pill == "all");
            btnPillUnread.Checked = (pill == "unread");
            btnPillUrgent.Checked = (pill == "urgent");

            RenderNotificationsList();
        }

        private void SwitchCategory(string catCode)
        {
            activeCategory = catCode;
            BuildCategoriesList();
            RenderNotificationsList();
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            RenderNotificationsList();
        }

        private int GetUnreadCount()
        {
            return allNotifs.Count(x => x.IsUnread);
        }

        private Guna2Button CreatePillButton(string text, bool active)
        {
            var btn = new Guna2Button
            {
                Text = text,
                Size = new Size(104, 32),
                BorderRadius = 16,
                BorderThickness = 1,
                BorderColor = KtvTheme.Border,
                FillColor = Color.White,
                ForeColor = KtvTheme.TextMid,
                Font = new Font("Segoe UI", 8.2F, FontStyle.Bold),
                Cursor = Cursors.Hand,
                ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton,
                Checked = active,
                TextAlign = HorizontalAlignment.Center,
                TextOffset = new Point(0, 0),
                Padding = new Padding(0),
                CheckedState = { FillColor = KtvTheme.Teal, ForeColor = Color.White, BorderColor = KtvTheme.Teal },
                HoverState = { FillColor = KtvTheme.TealLight }
            };
            return btn;
        }

        private Guna2Button CreatePageButton(string text, bool active)
        {
            return new Guna2Button
            {
                Text = text,
                Size = new Size(30, 30),
                BorderRadius = 6,
                BorderThickness = 1,
                BorderColor = active ? KtvTheme.Teal : KtvTheme.Border,
                FillColor = active ? KtvTheme.Teal : Color.White,
                ForeColor = active ? Color.White : KtvTheme.TextMid,
                Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
                Cursor = Cursors.Hand,
                HoverState = { FillColor = active ? KtvTheme.Teal : KtvTheme.TealLight }
            };
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
