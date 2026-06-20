using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace HospitalX.GUI.PH2.KyThuatVien
{
    public partial class ucKtvDashboard : UserControl
    {
        // Khai báo các Controls thành viên để hỗ trợ layout động (Responsive)
        private Guna2Panel pnlBannerAvatar;
        private Label lblBannerAvatarText;
        private Label lblBannerTitle;

        private readonly Guna2Panel[] statCards = new Guna2Panel[4];
        private readonly Guna2Panel[] statDots = new Guna2Panel[4];
        private readonly Label[] lblStatValues = new Label[4];
        private readonly Label[] lblStatLabels = new Label[4];
        private readonly Label[] lblStatTrends = new Label[4];
        private readonly Label[] lblStatTrendsVal = new Label[4];
        private readonly Label[] lblStatTrendsTxt = new Label[4];

        // Hàng 1
        private Label lblTaskTitle;

        private Label lblActivityTitle;

        // Hàng 2 (Timeline & Progress)
        private Label lblScheduleTitle;
        private readonly List<Control> scheduleControls = new List<Control>();

        private Label lblProgressTitle;
        private readonly Guna2CircleProgressBar[] progressRings = new Guna2CircleProgressBar[3];
        private readonly Label[] lblProgressRingVals = new Label[3];
        private readonly Label[] lblProgressRingLabels = new Label[3];
        private Guna2Panel progressDivider;
        private readonly Label[] lblProgDetails = new Label[3];
        private readonly Label[] lblProgVals = new Label[3];
        private readonly Guna2Panel[] progressDetailRows = new Guna2Panel[3];

        public ucKtvDashboard()
        {
            InitializeComponent();
            BackColor = Color.FromArgb(236, 245, 243); // Đồng bộ nền xanh ngọc nhạt của phân hệ bác sĩ

            // Link the array statCards to the designer-generated cardStat controls
            statCards[0] = this.cardStat1;
            statCards[1] = this.cardStat2;
            statCards[2] = this.cardStat3;
            statCards[3] = this.cardStat4;

            // Link custom designer labels
            lblStatLabels[0] = this.lblStat1Title;
            lblStatLabels[1] = this.lblStat2Title;
            lblStatLabels[2] = this.lblStat3Title;
            lblStatLabels[3] = this.lblStat4Title;

            lblStatValues[0] = this.lblStat1Value;
            lblStatValues[1] = this.lblStat2Value;
            lblStatValues[2] = this.lblStat3Value;
            lblStatValues[3] = this.lblStat4Value;

            lblStatTrendsVal[0] = this.lblStat1TrendValue;
            lblStatTrendsVal[1] = this.lblStat2TrendValue;
            lblStatTrendsVal[2] = this.lblStat3TrendValue;
            lblStatTrendsVal[3] = this.lblStat4TrendValue;

            lblStatTrendsTxt[0] = this.lblStat1TrendText;
            lblStatTrendsTxt[1] = this.lblStat2TrendText;
            lblStatTrendsTxt[2] = this.lblStat3TrendText;
            lblStatTrendsTxt[3] = this.lblStat4TrendText;

            // Bật tự động cuộn trang (AutoScroll) cho UserControl
            this.AutoScroll = true;
            this.DoubleBuffered = true;

            // Đăng ký sự kiện Resize để tự động tính toán lại kích thước và vị trí các thẻ
            this.Resize += UcKtvDashboard_Resize;

            if (IsInDesigner())
            {
                return;
            }

            BuildControls();
            LoadData();
        }

        private bool IsInDesigner()
        {
            string processName = Process.GetCurrentProcess().ProcessName;
            return LicenseManager.UsageMode == LicenseUsageMode.Designtime
                || DesignMode
                || processName.Equals("devenv", StringComparison.OrdinalIgnoreCase)
                || processName.Equals("XDesProc", StringComparison.OrdinalIgnoreCase);
        }

        private void UcKtvDashboard_Resize(object sender, EventArgs e)
        {
            if (IsInDesigner()) return;
            LayoutControls();
        }

        private void BuildControls()
        {
            // Do NOT call Controls.Clear() and do NOT re-instantiate container panels because they are created in InitializeComponent()!

            // Clear children of main container panels to rebuild dynamically at runtime
            banner.Controls.Clear();
            taskCard.Controls.Clear();
            activityCard.Controls.Clear();
            scheduleCard.Controls.Clear();
            progressCard.Controls.Clear();

            // 1. Khởi tạo Banner (Đồng bộ cấu hình Avatar trái của phân hệ Bác sĩ, xóa bỏ emoji lỗi font)

            pnlBannerAvatar = new Guna2Panel
            {
                Size = new Size(60, 60),
                BorderRadius = 14,
                FillColor = Color.FromArgb(66, 132, 114), // Màu nền avatar đồng bộ
                BackColor = Color.Transparent
            };
            lblBannerAvatarText = new Label
            {
                Text = "KT",
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.Transparent
            };
            pnlBannerAvatar.Controls.Add(lblBannerAvatarText);
            banner.Controls.Add(pnlBannerAvatar);

            lblBannerTitle = TextLabel("Chào buổi sáng!", 110, 26, 500, 34, 18F, FontStyle.Bold, Color.White);
            lblBannerTitle.AutoSize = true;

            banner.Controls.Add(lblBannerTitle);
            Controls.Add(banner);

            // 2. Khởi tạo 4 Stat Cards
            string[] statLbls = { "DỊCH VỤ HÔM NAY", "CHỜ CẬP NHẬT KQ", "ĐÃ HOÀN THÀNH", "TIẾN ĐỘ TRONG NGÀY" };
            string[] statEmojis = { "🧪", "⏳", "✅", "📈" };
            Color[] accents = {
                Color.FromArgb(15, 110, 86),   // Deep Teal
                Color.FromArgb(255, 179, 0),   // Amber
                Color.FromArgb(229, 57, 53),   // Red
                Color.FromArgb(25, 118, 210)   // Blue
            };
            Color[] iconBgs = {
                Color.FromArgb(230, 244, 240),
                Color.FromArgb(255, 248, 225),
                Color.FromArgb(253, 244, 244),
                Color.FromArgb(227, 242, 253)
            };
            Color[] trendColors = {
                Color.FromArgb(15, 110, 86),
                Color.FromArgb(160, 112, 0),
                Color.FromArgb(229, 57, 53),
                Color.FromArgb(25, 118, 210)
            };

            for (int i = 0; i < 4; i++)
            {
                var card = statCards[i];
                card.ShadowDecoration.Enabled = false;
                card.BorderThickness = 1;
                card.BorderColor = Color.FromArgb(218, 232, 226);
                card.BorderRadius = 14;
                card.FillColor = Color.White;
                card.Padding = new Padding(0, 4, 0, 0);
                card.Tag = accents[i];

                // card.Paint -= KpiCard_Paint;
                // card.Paint += KpiCard_Paint;

                // Check if dot already exists to avoid duplication
                string dotName = $"statDot_{i}";
                Guna2Panel dot = card.Controls.Find(dotName, true).FirstOrDefault() as Guna2Panel;
                if (dot == null)
                {
                    // Create round icon box
                    dot = new Guna2Panel
                    {
                        Name = dotName,
                        Size = new Size(36, 36),
                        Location = new Point(18, 14),
                        BorderRadius = 10,
                        FillColor = iconBgs[i],
                        BackColor = Color.Transparent
                    };
                    PrepareRoundedPanel(dot);
                    var lblEmoji = new Label
                    {
                        Text = statEmojis[i],
                        Name = "lblEmoji",
                        Dock = DockStyle.Fill,
                        Font = new Font("Segoe UI", 11F),
                        TextAlign = ContentAlignment.MiddleCenter,
                        BackColor = Color.Transparent
                    };
                    dot.Controls.Add(lblEmoji);
                    card.Controls.Add(dot);
                }
                statDots[i] = dot;

                // Configure style of static labels
                if (lblStatLabels[i] != null)
                {
                    lblStatLabels[i].ForeColor = Color.FromArgb(122, 149, 137);
                    lblStatLabels[i].Font = new Font("Segoe UI", 8.25F, FontStyle.Bold);
                }
                if (lblStatValues[i] != null)
                {
                    lblStatValues[i].ForeColor = Color.FromArgb(24, 48, 42);
                    lblStatValues[i].Font = new Font("Segoe UI", 18F, FontStyle.Bold);
                }
                if (lblStatTrendsTxt[i] != null)
                {
                    lblStatTrendsTxt[i].ForeColor = trendColors[i];
                    lblStatTrendsTxt[i].Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
                }
                if (lblStatTrendsVal[i] != null)
                {
                    lblStatTrendsVal[i].ForeColor = trendColors[i];
                    lblStatTrendsVal[i].Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
                }

                // ConfigureKpiHover(card);

                if (!Controls.Contains(card))
                {
                    Controls.Add(card);
                }
            }

            // 3. Khởi tạo Task Card (Dịch vụ hôm nay) - Xóa hover của card cha
            taskCard.BorderColor = Color.FromArgb(218, 232, 226);
            PrepareRoundedPanel(taskCard);
            lblTaskTitle = TextLabel("Dịch vụ hôm nay", 26, 20, 300, 36, 14F, FontStyle.Bold, Color.FromArgb(24, 48, 42));
            taskCard.Controls.Add(lblTaskTitle);

            // 4. Khởi tạo Activity Card (Hoạt động gần đây) - Xóa hover của card cha
            activityCard.BorderColor = Color.FromArgb(218, 232, 226);
            PrepareRoundedPanel(activityCard);
            lblActivityTitle = TextLabel("Hoạt động gần đây", 24, 20, 260, 36, 14F, FontStyle.Bold, Color.FromArgb(24, 48, 42));
            activityCard.Controls.Add(lblActivityTitle);

            // 5. Khởi tạo Schedule Card (Lịch thực hiện hôm nay) - Xóa hover của card cha
            scheduleCard.BorderColor = Color.FromArgb(218, 232, 226);
            lblScheduleTitle = TextLabel("Lịch thực hiện hôm nay", 26, 20, 300, 36, 14F, FontStyle.Bold, Color.FromArgb(24, 48, 42));
            scheduleCard.Controls.Add(lblScheduleTitle);

            // 6. Khởi tạo Progress Card (Tiến độ hôm nay) - Xóa hover của card cha
            progressCard.BorderColor = Color.FromArgb(218, 232, 226);
            PrepareRoundedPanel(progressCard);
            lblProgressTitle = TextLabel("Tiến độ hôm nay", 24, 20, 260, 36, 14F, FontStyle.Bold, Color.FromArgb(24, 48, 42));
            progressCard.Controls.Add(lblProgressTitle);

            // Khởi tạo 3 Vòng tiến độ Guna2 sạch sẽ (Xóa background xám mờ)
            // Chỉ có 2 trạng thái thực trong DB: Hoàn thành (KETQUA IS NOT NULL) và Chờ thực hiện (KETQUA IS NULL)
            Color[] ringColors = { Color.FromArgb(15, 110, 86), Color.FromArgb(240, 165, 0), Color.FromArgb(100, 100, 100) };
            string[] ringLabels = { "Hoàn thành", "Chờ thực hiện", "Tiến độ" };

            for (int i = 0; i < 3; i++)
            {
                progressRings[i] = new Guna2CircleProgressBar
                {
                    Size = new Size(82, 82),
                    FillColor = Color.FromArgb(238, 242, 240),
                    ProgressColor = ringColors[i],
                    ProgressColor2 = ringColors[i],
                    ProgressThickness = 7,
                    FillThickness = 7,
                    InnerColor = Color.White,
                    BackColor = Color.Transparent
                };

                lblProgressRingVals[i] = TextLabel("0%", 0, 0, 82, 82, 11F, FontStyle.Bold, Color.FromArgb(24, 48, 42), ContentAlignment.MiddleCenter);
                progressRings[i].Controls.Add(lblProgressRingVals[i]);

                lblProgressRingLabels[i] = TextLabel(ringLabels[i], 0, 0, 110, 20, 8.8F, FontStyle.Regular, Color.FromArgb(122, 149, 137), ContentAlignment.MiddleCenter);

                progressCard.Controls.Add(progressRings[i]);
                progressCard.Controls.Add(lblProgressRingLabels[i]);
            }

            // Thanh chia tách mỏng và các dòng thống kê chi tiết
            progressDivider = new Guna2Panel { Height = 1, FillColor = Color.FromArgb(218, 232, 226) };
            progressCard.Controls.Add(progressDivider);

            string[] detailLabels = { "Tổng dịch vụ hôm nay", "Đã hoàn thành", "Kết quả chờ xác nhận" };
            Color[] detailColors = { Color.FromArgb(24, 48, 42), Color.FromArgb(15, 110, 86), Color.FromArgb(240, 165, 0) };

            for (int i = 0; i < 3; i++)
            {
                progressDetailRows[i] = new Guna2Panel
                {
                    Size = new Size(100, 36),
                    BorderRadius = 8,
                    FillColor = Color.White,
                    BorderThickness = 1,
                    BorderColor = Color.FromArgb(245, 247, 246),
                    Cursor = Cursors.Hand,
                    Tag = "ProgDetailRow"
                };
                PrepareRoundedPanel(progressDetailRows[i]);

                // Nhãn tròn chỉ thị màu
                var pnlDot = new Guna2Panel
                {
                    Location = new Point(12, 14),
                    Size = new Size(8, 8),
                    BorderRadius = 4,
                    FillColor = detailColors[i]
                };
                PrepareRoundedPanel(pnlDot);
                progressDetailRows[i].Controls.Add(pnlDot);

                lblProgDetails[i] = TextLabel(detailLabels[i], 28, 8, 220, 20, 9.5F, FontStyle.Regular, Color.FromArgb(122, 149, 137));
                lblProgVals[i] = TextLabel("0", 0, 8, 60, 20, 9.5F, FontStyle.Bold, detailColors[i], ContentAlignment.MiddleRight);

                progressDetailRows[i].Controls.Add(lblProgDetails[i]);
                progressDetailRows[i].Controls.Add(lblProgVals[i]);

                // Hover effect for progress row items
                int index = i; // capture index
                progressDetailRows[i].MouseEnter += (s, e) =>
                {
                    var p = (Guna2Panel)s;
                    p.FillColor = Color.FromArgb(240, 247, 245);
                    p.BorderColor = detailColors[index];
                };
                progressDetailRows[i].MouseLeave += (s, e) =>
                {
                    var p = (Guna2Panel)s;
                    p.FillColor = Color.White;
                    p.BorderColor = Color.FromArgb(245, 247, 246);
                };

                // Propagate events to children
                foreach (Control c in progressDetailRows[i].Controls)
                {
                    c.MouseEnter += (s, e) =>
                    {
                        progressDetailRows[index].FillColor = Color.FromArgb(240, 247, 245);
                        progressDetailRows[index].BorderColor = detailColors[index];
                    };
                    c.MouseLeave += (s, e) =>
                    {
                        progressDetailRows[index].FillColor = Color.White;
                        progressDetailRows[index].BorderColor = Color.FromArgb(245, 247, 246);
                    };
                    c.Cursor = Cursors.Hand;
                }

                progressCard.Controls.Add(progressDetailRows[i]);
            }

            // Removed redundant dynamic add of progressCard since it is created in InitializeComponent
        }

        private void AddHoverEffect(Guna2Panel card)
        {
            // Thiết lập hiệu ứng chuyển màu viền mượt mà khi hover vào Card
            card.MouseEnter += (s, e) =>
            {
                var p = (Guna2Panel)s;
                p.BorderColor = Color.FromArgb(15, 110, 86); // Đổi sang viền Teal đậm khi hover
                p.ShadowDecoration.Enabled = true;
                p.ShadowDecoration.Shadow = new Padding(0, 0, 10, 10);
                p.ShadowDecoration.Color = Color.FromArgb(15, 110, 86);
                p.ShadowDecoration.Depth = 10;
            };
            card.MouseLeave += (s, e) =>
            {
                var p = (Guna2Panel)s;
                p.BorderColor = Color.FromArgb(218, 232, 226); // Trở về viền nhạt ban đầu
                p.ShadowDecoration.Enabled = false;
            };
        }

        private void PrepareRoundedPanel(Guna2Panel panel)
        {
            panel.BackColor = Color.Transparent;
            panel.UseTransparentBackground = true;
        }

        private void ConfigureKpiHover(Guna2Panel card)
        {
            card.Cursor = Cursors.Hand;
            card.ShadowDecoration.Enabled = true;
            card.ShadowDecoration.Color = Color.FromArgb(40, 15, 110, 86);
            card.ShadowDecoration.Depth = 5;
            card.ShadowDecoration.Shadow = new Padding(0, 2, 8, 4);

            EventHandler enter = (s, e) => SetKpiHoverState(card, true);
            EventHandler leave = (s, e) => SetKpiHoverState(card, false);

            card.MouseEnter += enter;
            card.MouseLeave += leave;

            foreach (Control child in card.Controls)
            {
                child.Cursor = Cursors.Hand;
                child.MouseEnter += enter;
                child.MouseLeave += leave;
            }
        }

        private void SetKpiHoverState(Guna2Panel card, bool hovered)
        {
            card.FillColor = hovered ? Color.FromArgb(248, 252, 250) : Color.White;
            card.BorderColor = hovered ? Color.FromArgb(15, 110, 86) : Color.FromArgb(218, 232, 226);
            card.ShadowDecoration.Enabled = true;
            card.ShadowDecoration.Depth = hovered ? 12 : 5;
            card.ShadowDecoration.Shadow = hovered ? new Padding(0, 4, 14, 8) : new Padding(0, 2, 8, 4);
        }

        private void LayoutControls()
        {
            int margin = 28;
            int gap = 20;

            int scrollbarWidth = this.VerticalScroll.Visible ? 18 : 0;
            int availWidth = this.Width - 2 * margin - scrollbarWidth;

            if (availWidth < 400) return;

            // 1. Layout Banner
            banner.Location = new Point(margin, margin);
            banner.Size = new Size(availWidth, 118);

            pnlBannerAvatar.Location = new Point(30, 29);
            lblBannerTitle.Location = new Point(110, 26);
            lblBannerTitle.Width = banner.Width - 150;

            // 2. Layout 4 Stat Cards
            int cardWidth = (availWidth - 3 * gap) / 4;
            int cardHeight = 130;
            int statY = banner.Bottom + gap;

            for (int i = 0; i < 4; i++)
            {
                var card = statCards[i];
                card.Location = new Point(margin + i * (cardWidth + gap), statY);
                card.Size = new Size(cardWidth, cardHeight);

                // Update children widths dynamically to fit
                foreach (Control ctrl in card.Controls)
                {
                    if (ctrl is Label lbl && lbl.Name != "lblEmoji")
                    {
                        lbl.Width = cardWidth - 76;
                    }
                    else if (ctrl is FlowLayoutPanel flp)
                    {
                        flp.Width = cardWidth - 76;
                    }
                }
            }

            // 3. Layout Hàng 1 (Dịch vụ hôm nay & Hoạt động gần đây)
            int row1Y = statCards[0].Bottom + gap;
            int row1Height = 380; // Tăng chiều cao lên 380px để hiển thị danh sách thoáng hơn

            int leftCardWidth = (int)(availWidth * 0.63f) - gap / 2;
            int rightCardWidth = availWidth - leftCardWidth - gap;

            taskCard.Location = new Point(margin, row1Y);
            taskCard.Size = new Size(leftCardWidth, row1Height);

            activityCard.Location = new Point(margin + leftCardWidth + gap, row1Y);
            activityCard.Size = new Size(rightCardWidth, row1Height);

            // Cập nhật vị trí các dòng dịch vụ (Task item panels) tự động co giãn theo chiều rộng Card
            int itemY = 62;
            foreach (Control ctrl in taskCard.Controls)
            {
                if (ctrl is Guna2Panel && ctrl.Tag != null && ctrl.Tag.ToString() == "TaskRow")
                {
                    ctrl.Location = new Point(20, itemY);
                    ctrl.Width = leftCardWidth - 40;

                    // Căn chỉnh các nhãn nội dung và Badge trạng thái sát lề phải của mỗi dòng dịch vụ
                    foreach (Control child in ctrl.Controls)
                    {
                        if (child is Guna2Panel && child.Width == 110) // Badge trạng thái bo tròn
                        {
                            child.Location = new Point(ctrl.Width - 130, (ctrl.Height - child.Height) / 2);
                        }
                        else if (child is Label)
                        {
                            child.Width = ctrl.Width - 160;
                        }
                    }
                    itemY += 62; // Đẹp mắt và cân đối
                }
            }

            // Cập nhật vị trí các dòng hoạt động gần đây
            int actY = 62;
            foreach (Control ctrl in activityCard.Controls)
            {
                if (ctrl is Guna2Panel && ctrl.Tag != null && ctrl.Tag.ToString() == "ActRow")
                {
                    ctrl.Location = new Point(20, actY);
                    ctrl.Width = rightCardWidth - 40;

                    foreach (Control child in ctrl.Controls)
                    {
                        if (child is Label)
                        {
                            child.Width = ctrl.Width - 76; // Đặt thành 76px để không đè lên avatar icon
                        }
                    }
                    actY += 72; // Khoảng giãn cách hoạt động
                }
            }

            // 4. Layout Hàng 2 (Lịch thực hiện hôm nay)
            int row2Y = taskCard.Bottom + gap;
            int row2Height = 380;

            scheduleCard.Location = new Point(margin, row2Y);
            scheduleCard.Size = new Size(availWidth, row2Height);

            progressCard.Visible = false;

            // Cập nhật các dòng lịch trình biểu diễn trực quan (Timeline blocks)
            int schedY = 62;
            int blockWidth = availWidth - 120;

            for (int i = 0; i < scheduleControls.Count; i++)
            {
                var ctrl = scheduleControls[i];
                if (ctrl.Tag != null)
                {
                    var info = (ScheduleControlInfo)ctrl.Tag;
                    if (info.Role == "Time")
                    {
                        ctrl.Location = new Point(18, schedY + 6);
                    }
                    else if (info.Role == "Block")
                    {
                        ctrl.Location = new Point(94, schedY);
                        ctrl.Size = new Size(blockWidth, 48);

                        foreach (Control child in ctrl.Controls)
                        {
                            child.Width = blockWidth - 32;
                        }
                        schedY += 60;
                    }
                }
            }

            // Cập nhật layout Vòng tròn Tiến độ hôm nay
            int ringSpacing = (rightCardWidth - 40 - (3 * 82)) / 2;
            if (ringSpacing < 10) ringSpacing = 10;

            int ringX = 20;
            for (int i = 0; i < 3; i++)
            {
                progressRings[i].Location = new Point(ringX, 64);
                lblProgressRingLabels[i].Location = new Point(ringX - 14, 154);
                ringX += 82 + ringSpacing;
            }

            // Layout danh sách chi tiết bên dưới vòng tròn
            progressDivider.Location = new Point(24, 196);
            progressDivider.Size = new Size(rightCardWidth - 48, 1);

            int detailY = 212;
            for (int i = 0; i < 3; i++)
            {
                progressDetailRows[i].Location = new Point(20, detailY);
                progressDetailRows[i].Width = rightCardWidth - 40;

                // Căn chỉnh nhãn chi tiết và giá trị số bên trong row panel
                lblProgDetails[i].Width = progressDetailRows[i].Width - 110;
                lblProgVals[i].Location = new Point(progressDetailRows[i].Width - 72, 8);
                detailY += 44; // 36px height + 8px gap
            }
        }

        private void LoadData()
        {
            var ktv = KtvData.CurrentTechnician();
            string ktvName = ktv.HoTen;
            var mockSvc = KtvData.Services();

            lblBannerAvatarText.Text = KtvData.GetInitials(ktvName);

            // 2. Tải số liệu thống kê — chỉ 2 trạng thái từ KETQUA: Chờ thực hiện / Hoàn thành
            int totalToday = mockSvc.Count;
            int pendingKq = mockSvc.Count(x => x.Status == "Chờ thực hiện");  // KETQUA IS NULL
            int completed = mockSvc.Count(x => x.Status == "Hoàn thành");     // KETQUA IS NOT NULL
            int progress = totalToday > 0 ? (completed * 100 / totalToday) : 0;
            string progressNote = progress >= 100 ? "Hoàn thành" : $"{completed}/{totalToday} DV";
            string pendingNote = pendingKq > 0 ? "Cần nhập KQ" : "Đã xong";

            // Cập nhật Banner — không có thông tin ca làm trong DB, chỉ hiển thị số liệu thực
            lblBannerTitle.Text = $"Xin chào, Kỹ thuật viên {ktvName}!";

            lblStatValues[0].Text = totalToday.ToString();
            lblStatTrendsVal[0].Text = "";

            lblStatValues[1].Text = pendingKq.ToString();
            lblStatTrendsVal[1].Text = "";
            lblStatTrendsTxt[1].Text = pendingKq > 0 ? "Cần nhập KQ" : "Đã xong";

            lblStatValues[2].Text = completed.ToString();
            lblStatTrendsVal[2].Text = "";

            lblStatValues[3].Text = $"{progress}%";
            lblStatTrendsVal[3].Text = $"{completed}/{totalToday}";

            // Vòng tiến độ: Ring 0=Hoàn thành, Ring 1=Chờ thực hiện, Ring 2=% Tổng tiến độ
            int ring0Val = totalToday > 0 ? (completed * 100 / totalToday) : 0;
            int ring1Val = totalToday > 0 ? (pendingKq * 100 / totalToday) : 0;
            int ring2Val = progress;

            progressRings[0].Value = ring0Val;
            lblProgressRingVals[0].Text = $"{ring0Val}%";

            progressRings[1].Value = ring1Val;
            lblProgressRingVals[1].Text = $"{ring1Val}%";

            progressRings[2].Value = ring2Val;
            lblProgressRingVals[2].Text = $"{ring2Val}%";

            // Detail rows: Tổng / Hoàn thành / Chờ cập nhật KQ
            lblProgVals[0].Text = totalToday.ToString();
            lblProgVals[1].Text = completed.ToString();
            lblProgVals[2].Text = pendingKq.ToString();

            // 3. Danh sách dịch vụ: LOAIDV · TENBN · NGAYDV (từ HSBA_DV JOIN BENHNHAN)
            for (int i = 0; i < Math.Min(5, mockSvc.Count); i++)
            {
                // info: TENBN · MABN · NGAYDV — phản ánh đúng join HSBA_DV-HSBA-BENHNHAN
                string info = $"{mockSvc[i].Patient}  ·  {mockSvc[i].MaBn}  ·  {mockSvc[i].NgayDv}";
                AddTaskRow(mockSvc[i].Service, info, mockSvc[i].Status);
            }

            // 4. Hoạt động gần đây — kiểm tra độ dài tránh lỗi văng index
            if (mockSvc.Count > 4)
                AddActivityRow($"Đã lưu KQ: {mockSvc[4].Service} — {mockSvc[4].Patient}",
                    "Vừa xong", "✅", Color.FromArgb(15, 110, 86), Color.FromArgb(230, 244, 240));
            if (mockSvc.Count > 0)
                AddActivityRow($"Nhận phân công mới: {mockSvc[0].Service} — {mockSvc[0].Patient}",
                    "30 phút trước", "📋", Color.FromArgb(240, 165, 0), Color.FromArgb(255, 244, 220));
            if (mockSvc.Count > 1)
                AddActivityRow($"Nhận phân công mới: {mockSvc[1].Service} — {mockSvc[1].Patient}",
                    "1 giờ trước", "📋", Color.FromArgb(35, 119, 196), Color.FromArgb(232, 241, 251));
            if (mockSvc.Count > 6)
                AddActivityRow($"Đã lưu KQ: {mockSvc[6].Service} — {mockSvc[6].Patient}",
                    "2 giờ trước", "✅", Color.FromArgb(15, 110, 86), Color.FromArgb(230, 244, 240));

            if (mockSvc.Count == 0)
            {
                AddActivityRow("Không có hoạt động gần đây", "", "ℹ️", Color.FromArgb(120, 130, 140), Color.FromArgb(245, 246, 248));
            }

            // 5. Lịch thực hiện hôm nay — kiểm tra độ dài tránh lỗi văng index
            scheduleControls.Clear();
            if (mockSvc.Count > 0) AddScheduleItem(mockSvc[0].Time, mockSvc[0].Service, mockSvc[0].Patient, Color.FromArgb(240, 165, 0), Color.FromArgb(255, 244, 220));
            if (mockSvc.Count > 1) AddScheduleItem(mockSvc[1].Time, mockSvc[1].Service, mockSvc[1].Patient, Color.FromArgb(240, 165, 0), Color.FromArgb(255, 244, 220));
            if (mockSvc.Count > 2) AddScheduleItem(mockSvc[2].Time, mockSvc[2].Service, mockSvc[2].Patient, Color.FromArgb(240, 165, 0), Color.FromArgb(255, 244, 220));
            if (mockSvc.Count > 4) AddScheduleItem(mockSvc[4].Time, mockSvc[4].Service, mockSvc[4].Patient, Color.FromArgb(15, 110, 86), Color.FromArgb(230, 244, 240));
            if (mockSvc.Count > 5) AddScheduleItem(mockSvc[5].Time, mockSvc[5].Service, mockSvc[5].Patient, Color.FromArgb(35, 119, 196), Color.FromArgb(232, 241, 251));

            if (mockSvc.Count == 0)
            {
                AddScheduleItem("--:--", "Không có lịch thực hiện hôm nay", "", Color.FromArgb(120, 130, 140), Color.FromArgb(245, 246, 248));
            }

            // Cập nhật lại giao diện sau khi tải dữ liệu
            LayoutControls();
        }

        private void AddTaskRow(string service, string info, string status)
        {
            // Mỗi dịch vụ hôm nay là một dòng Card nhỏ cực kỳ đẹp mắt có hover
            var rowPanel = new Guna2Panel
            {
                Size = new Size(100, 58),
                BorderRadius = 10,
                FillColor = Color.White,
                BorderThickness = 1,
                BorderColor = Color.FromArgb(238, 242, 240),
                Cursor = Cursors.Hand,
                Tag = "TaskRow"
            };
            PrepareRoundedPanel(rowPanel);

            // Các label text tinh chỉnh kích thước và font chữ chuẩn
            var lblTitle = TextLabel(service, 20, 8, 100, 22, 9.8F, FontStyle.Bold, Color.FromArgb(33, 49, 41));
            var lblSub = TextLabel(info, 20, 30, 100, 20, 8.8F, FontStyle.Regular, Color.FromArgb(120, 140, 132));
            rowPanel.Controls.Add(lblTitle);
            rowPanel.Controls.Add(lblSub);

            // Badge trạng thái bo tròn (Pill Badge) cực kỳ xịn sò như giao diện Web
            Color badgeBg = Color.FromArgb(230, 244, 240);
            Color badgeFore = Color.FromArgb(15, 110, 86);

            if (status == "Chờ thực hiện")
            {
                badgeBg = Color.FromArgb(255, 248, 230);
                badgeFore = Color.FromArgb(196, 128, 0);
            }
            else // Hoàn thành
            {
                badgeBg = Color.FromArgb(230, 246, 241);
                badgeFore = Color.FromArgb(12, 100, 78);
            }

            var badge = new Guna2Panel
            {
                Size = new Size(110, 26),
                BorderRadius = 13,
                FillColor = badgeBg
            };
            PrepareRoundedPanel(badge);
            var lblBadgeText = TextLabel(status, 0, 0, 110, 26, 8.5F, FontStyle.Bold, badgeFore, ContentAlignment.MiddleCenter);
            badge.Controls.Add(lblBadgeText);
            rowPanel.Controls.Add(badge);

            // Thêm hiệu ứng hover riêng cho dòng con (Chỉ đổi nền dòng con khi hover)
            rowPanel.MouseEnter += (s, e) =>
            {
                var p = (Guna2Panel)s;
                p.FillColor = Color.FromArgb(240, 247, 245);
                p.BorderColor = Color.FromArgb(15, 110, 86);
            };
            rowPanel.MouseLeave += (s, e) =>
            {
                var p = (Guna2Panel)s;
                p.FillColor = Color.White;
                p.BorderColor = Color.FromArgb(238, 242, 240);
            };

            // Chuyển tiếp sự kiện MouseEnter/MouseLeave của các control con lên rowPanel cha để hover mượt mà
            foreach (Control c in rowPanel.Controls)
            {
                c.MouseEnter += (s, e) => { rowPanel.FillColor = Color.FromArgb(240, 247, 245); rowPanel.BorderColor = Color.FromArgb(15, 110, 86); };
                c.MouseLeave += (s, e) => { rowPanel.FillColor = Color.White; rowPanel.BorderColor = Color.FromArgb(238, 242, 240); };
                c.Cursor = Cursors.Hand;
            }
            foreach (Control c in badge.Controls)
            {
                c.MouseEnter += (s, e) => { rowPanel.FillColor = Color.FromArgb(240, 247, 245); rowPanel.BorderColor = Color.FromArgb(15, 110, 86); };
                c.MouseLeave += (s, e) => { rowPanel.FillColor = Color.White; rowPanel.BorderColor = Color.FromArgb(238, 242, 240); };
                c.Cursor = Cursors.Hand;
            }

            taskCard.Controls.Add(rowPanel);
        }

        private void AddActivityRow(string text, string time, string icon, Color iconFore, Color iconBg)
        {
            // Mỗi hoạt động là một dòng Card nhỏ bo góc có hover riêng biệt
            var actRow = new Guna2Panel
            {
                Size = new Size(100, 64),
                BorderRadius = 10,
                FillColor = Color.White,
                BorderThickness = 1,
                BorderColor = Color.FromArgb(240, 243, 242),
                Cursor = Cursors.Hand,
                Tag = "ActRow"
            };
            PrepareRoundedPanel(actRow);

            // Ô tròn icon sắc nét bên trái dòng hoạt động, căn giữa đứng hoàn hảo
            var pnlIcon = new Guna2Panel
            {
                Location = new Point(14, 13),
                Size = new Size(38, 38),
                BorderRadius = 19,
                FillColor = iconBg
            };
            PrepareRoundedPanel(pnlIcon);
            var lblIcon = new Label
            {
                Text = icon,
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 11F),
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.Transparent,
                ForeColor = iconFore
            };
            pnlIcon.Controls.Add(lblIcon);
            actRow.Controls.Add(pnlIcon);

            // Các nhãn text với typography cao cấp và khoảng cách thoáng đãng
            var lblTxt = TextLabel(text, 64, 11, 100, 22, 9.5F, FontStyle.Regular, Color.FromArgb(43, 58, 66));
            var lblTm = TextLabel(time, 64, 33, 100, 18, 8.8F, FontStyle.Regular, Color.FromArgb(122, 149, 137));
            actRow.Controls.Add(lblTxt);
            actRow.Controls.Add(lblTm);

            // Hiệu ứng hover cho dòng hoạt động
            actRow.MouseEnter += (s, e) =>
            {
                var p = (Guna2Panel)s;
                p.FillColor = Color.FromArgb(245, 247, 249);
                p.BorderColor = Color.FromArgb(218, 232, 226);
            };
            actRow.MouseLeave += (s, e) =>
            {
                var p = (Guna2Panel)s;
                p.FillColor = Color.White;
                p.BorderColor = Color.FromArgb(240, 243, 242);
            };

            // Chuyển tiếp sự kiện MouseEnter/MouseLeave
            foreach (Control c in actRow.Controls)
            {
                c.MouseEnter += (s, e) => { actRow.FillColor = Color.FromArgb(245, 247, 249); actRow.BorderColor = Color.FromArgb(218, 232, 226); };
                c.MouseLeave += (s, e) => { actRow.FillColor = Color.White; actRow.BorderColor = Color.FromArgb(240, 243, 242); };
                c.Cursor = Cursors.Hand;
            }
            foreach (Control c in pnlIcon.Controls)
            {
                c.MouseEnter += (s, e) => { actRow.FillColor = Color.FromArgb(245, 247, 249); actRow.BorderColor = Color.FromArgb(218, 232, 226); };
                c.MouseLeave += (s, e) => { actRow.FillColor = Color.White; actRow.BorderColor = Color.FromArgb(240, 243, 242); };
                c.Cursor = Cursors.Hand;
            }

            activityCard.Controls.Add(actRow);
        }

        private void AddScheduleItem(string time, string service, string patient, Color borderColor, Color fillColor)
        {
            var lblTime = TextLabel(time, 0, 0, 60, 34, 9.5F, FontStyle.Bold, Color.FromArgb(122, 149, 137), ContentAlignment.MiddleCenter);
            lblTime.Tag = new ScheduleControlInfo { Role = "Time" };

            var block = new Guna2Panel
            {
                BorderRadius = 8,
                CustomBorderThickness = new Padding(3, 0, 0, 0),
                CustomBorderColor = borderColor,
                FillColor = Color.White, // Xóa bỏ background xám mờ nhạt, đổi thành nền trắng tinh khiết
                BorderThickness = 1,
                BorderColor = Color.FromArgb(238, 242, 240),
                Cursor = Cursors.Hand
            };
            block.Tag = new ScheduleControlInfo { Role = "Block" };

            var lblSvc = TextLabel(service, 16, 6, 200, 20, 9.8F, FontStyle.Bold, Color.FromArgb(24, 48, 42));
            var lblPat = TextLabel(patient, 16, 26, 250, 18, 8.8F, FontStyle.Regular, Color.FromArgb(74, 85, 104));

            block.Controls.Add(lblSvc);
            block.Controls.Add(lblPat);

            // Thêm hiệu ứng hover thú vị cho block lịch thực hiện (hover dòng nào sáng dòng đó)
            block.MouseEnter += (s, e) =>
            {
                var p = (Guna2Panel)s;
                p.FillColor = fillColor; // Đổi sang màu nền nhạt của trạng thái khi hover
                p.BorderColor = borderColor;
            };
            block.MouseLeave += (s, e) =>
            {
                var p = (Guna2Panel)s;
                p.FillColor = Color.White; // Trở lại trắng tinh khôi
                p.BorderColor = Color.FromArgb(238, 242, 240);
            };

            // Chuyển tiếp sự kiện MouseEnter/MouseLeave cho các control con của block
            foreach (Control c in block.Controls)
            {
                c.MouseEnter += (s, e) => { block.FillColor = fillColor; block.BorderColor = borderColor; };
                c.MouseLeave += (s, e) => { block.FillColor = Color.White; block.BorderColor = Color.FromArgb(238, 242, 240); };
                c.Cursor = Cursors.Hand;
            }

            scheduleCard.Controls.Add(lblTime);
            scheduleCard.Controls.Add(block);

            scheduleControls.Add(lblTime);
            scheduleControls.Add(block);
        }

        private Label TextLabel(string text, int x, int y, int width, int height, float size, FontStyle style, Color color, ContentAlignment align = ContentAlignment.MiddleLeft)
        {
            return new Label
            {
                Text = text,
                Location = new Point(x, y),
                Size = new Size(width, height),
                AutoSize = false,
                AutoEllipsis = true,
                TextAlign = align,
                Font = new Font("Segoe UI", size, style),
                ForeColor = color,
                BackColor = Color.Transparent
            };
        }

        private Color StatusColor(string status)
        {
            if (status == "Hoàn thành") return Color.FromArgb(15, 110, 86);
            if (status == "Đang thực hiện") return Color.FromArgb(35, 119, 196);
            return Color.FromArgb(240, 165, 0);
        }

        // Helper classes lưu trữ thông tin phục vụ layout động
        private class TaskControlInfo
        {
            public string Role { get; set; }
        }

        private class ActivityControlInfo
        {
            public string Role { get; set; }
        }

        private class ScheduleControlInfo
        {
            public string Role { get; set; }
        }

        private void KpiCard_Paint(object sender, PaintEventArgs e)
        {
            var card = (Guna2Panel)sender;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            using (var path = GetRoundedRectPath(new RectangleF(0, 0, card.Width, card.Height), 14))
            {
                e.Graphics.SetClip(path);

                // if (card.Tag is Color accentColor)
                // {
                //     using (var brush = new SolidBrush(accentColor))
                //     {
                //         e.Graphics.FillRectangle(brush, 0, 0, card.Width, 4);
                //     }
                // }

                e.Graphics.ResetClip();
            }
        }

        private static System.Drawing.Drawing2D.GraphicsPath GetRoundedRectPath(RectangleF rect, float radius)
        {
            var path = new System.Drawing.Drawing2D.GraphicsPath();
            float diameter = radius * 2;
            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}
