using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace HospitalX.GUI.PH2.KyThuatVien
{
    public partial class ucKtvDashboard : UserControl
    {
        // Khai báo các Controls thành viên để hỗ trợ layout động (Responsive)
        private Guna2Panel banner;
        private Guna2Panel pnlBannerAvatar;
        private Label lblBannerAvatarText;
        private Label lblBannerTitle;
        private Label lblBannerSub;

        private Guna2Panel[] statCards = new Guna2Panel[4];
        private Guna2Panel[] statDots = new Guna2Panel[4];
        private Label[] lblStatValues = new Label[4];
        private Label[] lblStatLabels = new Label[4];
        private Label[] lblStatNotes = new Label[4];

        // Hàng 1
        private Guna2Panel taskCard;
        private Label lblTaskTitle;

        private Guna2Panel activityCard;
        private Label lblActivityTitle;

        // Hàng 2 (Timeline & Progress)
        private Guna2Panel scheduleCard;
        private Label lblScheduleTitle;
        private List<Control> scheduleControls = new List<Control>();

        private Guna2Panel progressCard;
        private Label lblProgressTitle;
        private Guna2CircleProgressBar[] progressRings = new Guna2CircleProgressBar[3];
        private Label[] lblProgressRingVals = new Label[3];
        private Label[] lblProgressRingLabels = new Label[3];
        private Guna2Panel progressDivider;
        private Label[] lblProgDetails = new Label[3];
        private Label[] lblProgVals = new Label[3];
        private Guna2Panel[] progressDetailRows = new Guna2Panel[3];

        public ucKtvDashboard()
        {
            InitializeComponent();
            BackColor = Color.FromArgb(236, 245, 243); // Đồng bộ nền xanh ngọc nhạt của phân hệ bác sĩ
            
            // Bật tự động cuộn trang (AutoScroll) cho UserControl
            this.AutoScroll = true;
            this.DoubleBuffered = true;

            // Đăng ký sự kiện Resize để tự động tính toán lại kích thước và vị trí các thẻ
            this.Resize += UcKtvDashboard_Resize;

            BuildControls();
            LoadData();
        }

        private void UcKtvDashboard_Resize(object sender, EventArgs e)
        {
            LayoutControls();
        }

        private void BuildControls()
        {
            Controls.Clear();

            // 1. Khởi tạo Banner (Đồng bộ cấu hình Avatar trái của phân hệ Bác sĩ, xóa bỏ emoji lỗi font)
            banner = new Guna2Panel
            {
                BorderRadius = 14,
                FillColor = Color.FromArgb(15, 110, 86) // Đồng bộ màu Teal của phân hệ Bác sĩ
            };

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

            lblBannerTitle = TextLabel("Chào buổi sáng!", 110, 32, 500, 34, 18F, FontStyle.Bold, Color.White);
            lblBannerSub = TextLabel("Đang tải dữ liệu ca làm việc...", 110, 68, 700, 24, 10F, FontStyle.Regular, Color.FromArgb(218, 242, 235));
            
            banner.Controls.Add(lblBannerTitle);
            banner.Controls.Add(lblBannerSub);
            Controls.Add(banner);

            // 2. Khởi tạo 4 Stat Cards
            Color[] statColors = { 
                Color.FromArgb(230, 244, 240), // Teal nhạt
                Color.FromArgb(255, 244, 220), // Vàng nhạt
                Color.FromArgb(230, 244, 240), // Teal nhạt
                Color.FromArgb(232, 241, 251)  // Xanh dương nhạt
            };
            
            string[] statTexts = { "DV", "KQ", "OK", "%" };
            Color[] statForeColors = {
                Color.FromArgb(15, 110, 86),
                Color.FromArgb(240, 165, 0),
                Color.FromArgb(15, 110, 86),
                Color.FromArgb(35, 119, 196)
            };

            for (int i = 0; i < 4; i++)
            {
                statCards[i] = KtvTheme.Card(0, 0, 10, 10);
                statCards[i].BorderColor = Color.FromArgb(218, 232, 226); // Đồng bộ viền của phân hệ Bác sĩ
                PrepareRoundedPanel(statCards[i]);

                statDots[i] = new Guna2Panel
                {
                    Size = new Size(48, 48),
                    BorderRadius = 14,
                    FillColor = statColors[i]
                };
                PrepareRoundedPanel(statDots[i]);
                
                var lblIconText = new Label
                {
                    Text = statTexts[i],
                    Location = new Point(0, 0),
                    Size = new Size(48, 48),
                    Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                    ForeColor = statForeColors[i],
                    TextAlign = ContentAlignment.MiddleCenter,
                    BackColor = Color.Transparent
                };
                statDots[i].Controls.Add(lblIconText);

                // Đồng bộ cỡ chữ với phân hệ bác sĩ (Value: 20F Bold, Caption: 9.5F Regular)
                // Đặt chiều cao 38 cho lblStatValues để tránh bị che mất phần dưới của số
                lblStatValues[i] = TextLabel("-", 86, 22, 120, 38, 20F, FontStyle.Bold, Color.FromArgb(24, 48, 42));
                lblStatLabels[i] = TextLabel("-", 88, 66, 140, 20, 9.5F, FontStyle.Regular, Color.FromArgb(122, 149, 137));
                lblStatNotes[i] = TextLabel("-", 88, 90, 140, 20, 8.5F, FontStyle.Bold, Color.FromArgb(15, 110, 86));

                statCards[i].Controls.Add(statDots[i]);
                statCards[i].Controls.Add(lblStatValues[i]);
                statCards[i].Controls.Add(lblStatLabels[i]);
                statCards[i].Controls.Add(lblStatNotes[i]);
                Controls.Add(statCards[i]);
            }

            // 3. Khởi tạo Task Card (Dịch vụ hôm nay) - Xóa hover của card cha
            taskCard = KtvTheme.Card(0, 0, 10, 10);
            taskCard.BorderColor = Color.FromArgb(218, 232, 226);
            PrepareRoundedPanel(taskCard);
            lblTaskTitle = TextLabel("Dịch vụ hôm nay", 26, 20, 300, 36, 14F, FontStyle.Bold, Color.FromArgb(24, 48, 42));
            taskCard.Controls.Add(lblTaskTitle);
            Controls.Add(taskCard);

            // 4. Khởi tạo Activity Card (Hoạt động gần đây) - Xóa hover của card cha
            activityCard = KtvTheme.Card(0, 0, 10, 10);
            activityCard.BorderColor = Color.FromArgb(218, 232, 226);
            PrepareRoundedPanel(activityCard);
            lblActivityTitle = TextLabel("Hoạt động gần đây", 24, 20, 260, 36, 14F, FontStyle.Bold, Color.FromArgb(24, 48, 42));
            activityCard.Controls.Add(lblActivityTitle);
            Controls.Add(activityCard);

            // 5. Khởi tạo Schedule Card (Lịch thực hiện hôm nay) - Xóa hover của card cha
            scheduleCard = KtvTheme.Card(0, 0, 10, 10);
            scheduleCard.BorderColor = Color.FromArgb(218, 232, 226);
            lblScheduleTitle = TextLabel("Lịch thực hiện hôm nay", 26, 20, 300, 36, 14F, FontStyle.Bold, Color.FromArgb(24, 48, 42));
            scheduleCard.Controls.Add(lblScheduleTitle);
            Controls.Add(scheduleCard);

            // 6. Khởi tạo Progress Card (Tiến độ hôm nay) - Xóa hover của card cha
            progressCard = KtvTheme.Card(0, 0, 10, 10);
            progressCard.BorderColor = Color.FromArgb(218, 232, 226);
            PrepareRoundedPanel(progressCard);
            lblProgressTitle = TextLabel("Tiến độ hôm nay", 24, 20, 260, 36, 14F, FontStyle.Bold, Color.FromArgb(24, 48, 42));
            progressCard.Controls.Add(lblProgressTitle);

            // Khởi tạo 3 Vòng tiến độ Guna2 sạch sẽ (Xóa background xám mờ)
            Color[] ringColors = { Color.FromArgb(15, 110, 86), Color.FromArgb(240, 165, 0), Color.FromArgb(217, 64, 64) };
            string[] ringLabels = { "Hoàn thành", "Đang thực hiện", "Chưa bắt đầu" };

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
                progressDetailRows[i].MouseEnter += (s, e) => {
                    var p = (Guna2Panel)s;
                    p.FillColor = Color.FromArgb(240, 247, 245);
                    p.BorderColor = detailColors[index];
                };
                progressDetailRows[i].MouseLeave += (s, e) => {
                    var p = (Guna2Panel)s;
                    p.FillColor = Color.White;
                    p.BorderColor = Color.FromArgb(245, 247, 246);
                };

                // Propagate events to children
                foreach (Control c in progressDetailRows[i].Controls)
                {
                    c.MouseEnter += (s, e) => {
                        progressDetailRows[index].FillColor = Color.FromArgb(240, 247, 245);
                        progressDetailRows[index].BorderColor = detailColors[index];
                    };
                    c.MouseLeave += (s, e) => {
                        progressDetailRows[index].FillColor = Color.White;
                        progressDetailRows[index].BorderColor = Color.FromArgb(245, 247, 246);
                    };
                    c.Cursor = Cursors.Hand;
                }

                progressCard.Controls.Add(progressDetailRows[i]);
            }

            Controls.Add(progressCard);
        }

        private void AddHoverEffect(Guna2Panel card)
        {
            // Thiết lập hiệu ứng chuyển màu viền mượt mà khi hover vào Card
            card.MouseEnter += (s, e) => {
                var p = (Guna2Panel)s;
                p.BorderColor = Color.FromArgb(15, 110, 86); // Đổi sang viền Teal đậm khi hover
                p.ShadowDecoration.Enabled = true;
                p.ShadowDecoration.Shadow = new Padding(0, 0, 10, 10);
                p.ShadowDecoration.Color = Color.FromArgb(15, 110, 86);
                p.ShadowDecoration.Depth = 10;
            };
            card.MouseLeave += (s, e) => {
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
            lblBannerTitle.Location = new Point(110, 32);
            lblBannerTitle.Width = banner.Width - 150;
            lblBannerSub.Location = new Point(110, 68);
            lblBannerSub.Width = banner.Width - 150;

            // 2. Layout 4 Stat Cards (Tăng chiều dài lên 138px để đồng bộ hoàn toàn với Bác sĩ và có nhiều khoảng thở)
            int cardWidth = (availWidth - 3 * gap) / 4;
            int cardHeight = 138; // Tăng lên 138px cực kỳ chuẩn (đồng bộ phân hệ bác sĩ)
            int statY = banner.Bottom + gap;

            for (int i = 0; i < 4; i++)
            {
                statCards[i].Location = new Point(margin + i * (cardWidth + gap), statY);
                statCards[i].Size = new Size(cardWidth, cardHeight);
                
                // Căn giữa ô vuông Icon theo chiều cao 138px mới
                statDots[i].Location = new Point(18, (cardHeight - 48) / 2);

                int labelWidth = cardWidth - 96;
                lblStatValues[i].Width = labelWidth;
                lblStatLabels[i].Width = labelWidth;
                lblStatNotes[i].Width = labelWidth;

                // Căn chỉnh tọa độ Y thông minh bên trong card cao 138px để hiển thị thoáng và sang trọng
                lblStatValues[i].Location = new Point(86, 22);
                lblStatLabels[i].Location = new Point(88, 66);
                lblStatNotes[i].Location = new Point(88, 90);
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

            // 4. Layout Hàng 2 (Lịch thực hiện hôm nay & Tiến độ hôm nay)
            int row2Y = taskCard.Bottom + gap;
            int row2Height = 380; 

            scheduleCard.Location = new Point(margin, row2Y);
            scheduleCard.Size = new Size(leftCardWidth, row2Height);

            progressCard.Location = new Point(margin + leftCardWidth + gap, row2Y);
            progressCard.Size = new Size(rightCardWidth, row2Height);

            // Cập nhật các dòng lịch trình biểu diễn trực quan (Timeline blocks)
            int schedY = 62;
            int blockWidth = leftCardWidth - 120;
            
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
            string ktvName = KtvData.TechnicianName();
            var mockSvc = KtvData.Services();

            // Tạo Avatar Initials động chuẩn Bác sĩ
            string initials = "KT";
            if (!string.IsNullOrEmpty(ktvName))
            {
                var parts = ktvName.Trim().Split(' ');
                if (parts.Length >= 2)
                {
                    initials = (parts[0][0].ToString() + parts[parts.Length - 1][0].ToString()).ToUpper();
                }
                else if (parts.Length == 1 && parts[0].Length > 0)
                {
                    initials = parts[0][0].ToString().ToUpper();
                }
            }
            lblBannerAvatarText.Text = initials;

            // 2. Tải số liệu thống kê từ dữ liệu giả lập
            int totalToday = mockSvc.Count;
            int pendingKq = mockSvc.Count(x => x.Status == "Chờ thực hiện");
            int completed = mockSvc.Count(x => x.Status == "Hoàn thành");
            int progress = totalToday > 0 ? (completed * 100 / totalToday) : 0;
            string progressNote = progress >= 100 ? "Hoàn thành ca" : "Theo ca làm";
            string pendingNote = pendingKq > 0 ? "Cần xử lý" : "Đã sạch việc";
            string totalNote = "Tăng 2 so với hôm qua";

            // Cập nhật Text cho Banner và Thống kê
            lblBannerTitle.Text = $"Chào buổi sáng, Kỹ thuật viên {ktvName}!";
            lblBannerSub.Text = $"Hôm nay bạn có {totalToday} dịch vụ cần thực hiện • {pendingKq} kết quả đang chờ cập nhật • Ca làm: 07:00 - 15:00";

            lblStatValues[0].Text = totalToday.ToString();
            lblStatLabels[0].Text = "Dịch vụ hôm nay";
            lblStatNotes[0].Text = totalNote;

            lblStatValues[1].Text = pendingKq.ToString();
            lblStatLabels[1].Text = "Chờ cập nhật KQ";
            lblStatNotes[1].Text = pendingNote;

            lblStatValues[2].Text = completed.ToString();
            lblStatLabels[2].Text = "Đã hoàn thành";
            lblStatNotes[2].Text = "Đúng tiến độ";

            lblStatValues[3].Text = $"{progress}%";
            lblStatLabels[3].Text = "Tiến độ trong ngày";
            lblStatNotes[3].Text = progressNote;

            // Cập nhật chi tiết 3 vòng tiến độ hôm nay
            int ring1Val = progress;
            int ring2Val = totalToday > 0 ? (pendingKq * 100 / totalToday) : 0;
            int ring3Val = Math.Max(0, 100 - ring1Val - ring2Val);

            progressRings[0].Value = ring1Val;
            lblProgressRingVals[0].Text = $"{ring1Val}%";

            progressRings[1].Value = ring2Val;
            lblProgressRingVals[1].Text = $"{ring2Val}%";

            progressRings[2].Value = ring3Val;
            lblProgressRingVals[2].Text = $"{ring3Val}%";

            lblProgVals[0].Text = totalToday.ToString();
            lblProgVals[1].Text = completed.ToString();
            lblProgVals[2].Text = pendingKq.ToString();

            // 3. Tải danh sách Dịch vụ hôm nay (Task list) từ dữ liệu giả lập
            for (int i = 0; i < Math.Min(5, mockSvc.Count); i++)
            {
                string info = $"{mockSvc[i].Patient}  ·  {mockSvc[i].RecordId}  ·  {mockSvc[i].Time}";
                AddTaskRow(mockSvc[i].Service, info, mockSvc[i].Status, mockSvc[i].Priority);
            }

            // 4. Tải Hoạt động gần đây - Decorate dòng cực kỳ sang trọng & hover dòng con
            AddActivityRow("Đã cập nhật KQ Siêu âm cho BN Hoàng Văn Tuấn", "10 phút trước", "✅", Color.FromArgb(15, 110, 86), Color.FromArgb(230, 244, 240));
            AddActivityRow("BS. Minh phân công XN CBC cho BN Trần Văn Bình", "45 phút trước", "📋", Color.FromArgb(240, 165, 0), Color.FromArgb(255, 244, 220));
            AddActivityRow("KQ Glucose BN Nguyễn Thị Mai cần xác nhận lại", "3 giờ trước", "⚠️", Color.FromArgb(217, 64, 64), Color.FromArgb(253, 234, 234));
            AddActivityRow("Nhận ca từ KTV Minh Anh, thêm 2 dịch vụ", "2 giờ trước", "🔔", Color.FromArgb(35, 119, 196), Color.FromArgb(232, 241, 251));

            // 5. Tải danh sách Lịch thực hiện hôm nay (Row 2 - Schedule Timeline)
            scheduleControls.Clear();
            var mockSvcList = mockSvc;
            AddScheduleItem("07:30", mockSvcList[0].Service, mockSvcList[0].Patient, mockSvcList[0].Room, Color.FromArgb(15, 110, 86), Color.FromArgb(230, 244, 240));
            AddScheduleItem("08:00", mockSvcList[1].Service, mockSvcList[1].Patient, mockSvcList[1].Room, Color.FromArgb(240, 165, 0), Color.FromArgb(255, 244, 220));
            AddScheduleItem("08:30", mockSvcList[2].Service, mockSvcList[2].Patient, mockSvcList[2].Room, Color.FromArgb(240, 165, 0), Color.FromArgb(255, 244, 220));
            AddScheduleItem("10:00", mockSvcList[5].Service, mockSvcList[5].Patient, mockSvcList[5].Room, Color.FromArgb(35, 119, 196), Color.FromArgb(232, 241, 251));
            AddScheduleItem("11:00", mockSvcList[6].Service, mockSvcList[6].Patient, mockSvcList[6].Room, Color.FromArgb(15, 110, 86), Color.FromArgb(230, 244, 240));

            // Cập nhật lại giao diện sau khi tải dữ liệu
            LayoutControls();
        }

        private void AddTaskRow(string service, string info, string status, string priority)
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

            // Dải màu chỉ thị độ ưu tiên ở sát lề trái, full chiều cao với bo góc trái CustomBorderRadius
            Color priColor = Color.FromArgb(15, 110, 86); // Bình thường: Teal
            if (priority == "Khẩn cấp") priColor = Color.FromArgb(217, 64, 64); // Khẩn cấp: Đỏ
            else if (priority == "Cao") priColor = Color.FromArgb(240, 165, 0); // Cao: Vàng cam

            var priBar = new Guna2Panel
            {
                Location = new Point(0, 8),
                Size = new Size(5, 42),
                BorderRadius = 2,
                FillColor = priColor
            };
            PrepareRoundedPanel(priBar);
            rowPanel.Controls.Add(priBar);

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
            else if (status == "Đang thực hiện")
            {
                badgeBg = Color.FromArgb(235, 243, 254);
                badgeFore = Color.FromArgb(30, 110, 190);
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
            rowPanel.MouseEnter += (s, e) => {
                var p = (Guna2Panel)s;
                p.FillColor = Color.FromArgb(240, 247, 245);
                p.BorderColor = Color.FromArgb(15, 110, 86);
            };
            rowPanel.MouseLeave += (s, e) => {
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
            actRow.MouseEnter += (s, e) => {
                var p = (Guna2Panel)s;
                p.FillColor = Color.FromArgb(245, 247, 249);
                p.BorderColor = Color.FromArgb(218, 232, 226);
            };
            actRow.MouseLeave += (s, e) => {
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

        private void AddScheduleItem(string time, string service, string patient, string room, Color borderColor, Color fillColor)
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
            var lblPat = TextLabel($"{patient}  ·  {room}", 16, 26, 250, 18, 8.8F, FontStyle.Regular, Color.FromArgb(74, 85, 104));

            block.Controls.Add(lblSvc);
            block.Controls.Add(lblPat);

            // Thêm hiệu ứng hover thú vị cho block lịch thực hiện (hover dòng nào sáng dòng đó)
            block.MouseEnter += (s, e) => {
                var p = (Guna2Panel)s;
                p.FillColor = fillColor; // Đổi sang màu nền nhạt của trạng thái khi hover
                p.BorderColor = borderColor;
            };
            block.MouseLeave += (s, e) => {
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
    }
}
