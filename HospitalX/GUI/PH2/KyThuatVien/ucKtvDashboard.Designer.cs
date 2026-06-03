namespace HospitalX.GUI.PH2.KyThuatVien
{
    partial class ucKtvDashboard
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.banner = new Guna.UI2.WinForms.Guna2Panel();
            this.lblDesignerBannerTitle = new System.Windows.Forms.Label();
            this.lblDesignerBannerSub = new System.Windows.Forms.Label();
            this.taskCard = new Guna.UI2.WinForms.Guna2Panel();
            this.lblDesignerTaskTitle = new System.Windows.Forms.Label();
            this.activityCard = new Guna.UI2.WinForms.Guna2Panel();
            this.lblDesignerActivityTitle = new System.Windows.Forms.Label();
            this.scheduleCard = new Guna.UI2.WinForms.Guna2Panel();
            this.lblDesignerScheduleTitle = new System.Windows.Forms.Label();
            this.progressCard = new Guna.UI2.WinForms.Guna2Panel();
            this.lblDesignerProgressTitle = new System.Windows.Forms.Label();
            
            // 4 Stats Cards
            this.cardStat1 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblStat1Value = new System.Windows.Forms.Label();
            this.lblStat1Title = new System.Windows.Forms.Label();
            this.flpStat1Trend = new System.Windows.Forms.FlowLayoutPanel();
            this.lblStat1TrendValue = new System.Windows.Forms.Label();
            this.lblStat1TrendText = new System.Windows.Forms.Label();

            this.cardStat2 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblStat2Value = new System.Windows.Forms.Label();
            this.lblStat2Title = new System.Windows.Forms.Label();
            this.flpStat2Trend = new System.Windows.Forms.FlowLayoutPanel();
            this.lblStat2TrendValue = new System.Windows.Forms.Label();
            this.lblStat2TrendText = new System.Windows.Forms.Label();

            this.cardStat3 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblStat3Value = new System.Windows.Forms.Label();
            this.lblStat3Title = new System.Windows.Forms.Label();
            this.flpStat3Trend = new System.Windows.Forms.FlowLayoutPanel();
            this.lblStat3TrendValue = new System.Windows.Forms.Label();
            this.lblStat3TrendText = new System.Windows.Forms.Label();

            this.cardStat4 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblStat4Value = new System.Windows.Forms.Label();
            this.lblStat4Title = new System.Windows.Forms.Label();
            this.flpStat4Trend = new System.Windows.Forms.FlowLayoutPanel();
            this.lblStat4TrendValue = new System.Windows.Forms.Label();
            this.lblStat4TrendText = new System.Windows.Forms.Label();

            this.banner.SuspendLayout();
            this.taskCard.SuspendLayout();
            this.activityCard.SuspendLayout();
            this.scheduleCard.SuspendLayout();
            this.progressCard.SuspendLayout();
            this.cardStat1.SuspendLayout();
            this.flpStat1Trend.SuspendLayout();
            this.cardStat2.SuspendLayout();
            this.flpStat2Trend.SuspendLayout();
            this.cardStat3.SuspendLayout();
            this.flpStat3Trend.SuspendLayout();
            this.cardStat4.SuspendLayout();
            this.flpStat4Trend.SuspendLayout();
            this.SuspendLayout();

            // 
            // banner
            // 
            this.banner.BorderRadius = 14;
            this.banner.FillColor = System.Drawing.Color.FromArgb(15, 110, 86); // Teal
            this.banner.Location = new System.Drawing.Point(28, 28);
            this.banner.Size = new System.Drawing.Size(1054, 118);
            this.banner.Name = "banner";
            this.banner.Controls.Add(this.lblDesignerBannerTitle);
            this.banner.Controls.Add(this.lblDesignerBannerSub);

            this.lblDesignerBannerTitle.AutoSize = true;
            this.lblDesignerBannerTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblDesignerBannerTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblDesignerBannerTitle.ForeColor = System.Drawing.Color.White;
            this.lblDesignerBannerTitle.Location = new System.Drawing.Point(110, 32);
            this.lblDesignerBannerTitle.Name = "lblDesignerBannerTitle";
            this.lblDesignerBannerTitle.Text = "Xin chào, Kỹ thuật viên Nguyễn Thị Thu!";

            this.lblDesignerBannerSub.AutoSize = true;
            this.lblDesignerBannerSub.BackColor = System.Drawing.Color.Transparent;
            this.lblDesignerBannerSub.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDesignerBannerSub.ForeColor = System.Drawing.Color.FromArgb(218, 242, 235);
            this.lblDesignerBannerSub.Location = new System.Drawing.Point(112, 68);
            this.lblDesignerBannerSub.Name = "lblDesignerBannerSub";
            this.lblDesignerBannerSub.Text = "7 dịch vụ được phân công - 4 kết quả chờ cập nhật";

            // 
            // taskCard
            // 
            this.taskCard.BorderRadius = 12;
            this.taskCard.BorderColor = System.Drawing.Color.FromArgb(218, 232, 226);
            this.taskCard.BorderThickness = 1;
            this.taskCard.FillColor = System.Drawing.Color.White;
            this.taskCard.Location = new System.Drawing.Point(28, 326);
            this.taskCard.Size = new System.Drawing.Size(650, 380);
            this.taskCard.Name = "taskCard";
            this.taskCard.Controls.Add(this.lblDesignerTaskTitle);

            this.lblDesignerTaskTitle.AutoSize = true;
            this.lblDesignerTaskTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblDesignerTaskTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblDesignerTaskTitle.ForeColor = System.Drawing.Color.FromArgb(24, 48, 42);
            this.lblDesignerTaskTitle.Location = new System.Drawing.Point(26, 20);
            this.lblDesignerTaskTitle.Name = "lblDesignerTaskTitle";
            this.lblDesignerTaskTitle.Text = "Dịch vụ hôm nay";

            // 
            // activityCard
            // 
            this.activityCard.BorderRadius = 12;
            this.activityCard.BorderColor = System.Drawing.Color.FromArgb(218, 232, 226);
            this.activityCard.BorderThickness = 1;
            this.activityCard.FillColor = System.Drawing.Color.White;
            this.activityCard.Location = new System.Drawing.Point(698, 326);
            this.activityCard.Size = new System.Drawing.Size(384, 380);
            this.activityCard.Name = "activityCard";
            this.activityCard.Controls.Add(this.lblDesignerActivityTitle);

            this.lblDesignerActivityTitle.AutoSize = true;
            this.lblDesignerActivityTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblDesignerActivityTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblDesignerActivityTitle.ForeColor = System.Drawing.Color.FromArgb(24, 48, 42);
            this.lblDesignerActivityTitle.Location = new System.Drawing.Point(24, 20);
            this.lblDesignerActivityTitle.Name = "lblDesignerActivityTitle";
            this.lblDesignerActivityTitle.Text = "Hoạt động gần đây";

            // 
            // scheduleCard
            // 
            this.scheduleCard.BorderRadius = 12;
            this.scheduleCard.BorderColor = System.Drawing.Color.FromArgb(218, 232, 226);
            this.scheduleCard.BorderThickness = 1;
            this.scheduleCard.FillColor = System.Drawing.Color.White;
            this.scheduleCard.Location = new System.Drawing.Point(28, 726);
            this.scheduleCard.Size = new System.Drawing.Size(650, 380);
            this.scheduleCard.Name = "scheduleCard";
            this.scheduleCard.Controls.Add(this.lblDesignerScheduleTitle);

            this.lblDesignerScheduleTitle.AutoSize = true;
            this.lblDesignerScheduleTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblDesignerScheduleTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblDesignerScheduleTitle.ForeColor = System.Drawing.Color.FromArgb(24, 48, 42);
            this.lblDesignerScheduleTitle.Location = new System.Drawing.Point(26, 20);
            this.lblDesignerScheduleTitle.Name = "lblDesignerScheduleTitle";
            this.lblDesignerScheduleTitle.Text = "Lịch thực hiện hôm nay";

            // 
            // progressCard
            // 
            this.progressCard.BorderRadius = 12;
            this.progressCard.BorderColor = System.Drawing.Color.FromArgb(218, 232, 226);
            this.progressCard.BorderThickness = 1;
            this.progressCard.FillColor = System.Drawing.Color.White;
            this.progressCard.Location = new System.Drawing.Point(698, 726);
            this.progressCard.Size = new System.Drawing.Size(384, 380);
            this.progressCard.Name = "progressCard";
            this.progressCard.Controls.Add(this.lblDesignerProgressTitle);

            this.lblDesignerProgressTitle.AutoSize = true;
            this.lblDesignerProgressTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblDesignerProgressTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblDesignerProgressTitle.ForeColor = System.Drawing.Color.FromArgb(24, 48, 42);
            this.lblDesignerProgressTitle.Location = new System.Drawing.Point(24, 20);
            this.lblDesignerProgressTitle.Name = "lblDesignerProgressTitle";
            this.lblDesignerProgressTitle.Text = "Tiến độ hôm nay";

            // 
            // cardStat1
            // 
            this.cardStat1.BorderRadius = 12;
            this.cardStat1.BorderColor = System.Drawing.Color.FromArgb(218, 232, 226);
            this.cardStat1.BorderThickness = 1;
            this.cardStat1.FillColor = System.Drawing.Color.White;
            this.cardStat1.Location = new System.Drawing.Point(28, 166);
            this.cardStat1.Size = new System.Drawing.Size(248, 138);
            this.cardStat1.Name = "cardStat1";
            this.cardStat1.Controls.Add(this.lblStat1Value);
            this.cardStat1.Controls.Add(this.lblStat1Title);
            this.cardStat1.Controls.Add(this.flpStat1Trend);
            this.Controls.Add(this.cardStat1);

            // 
            // lblStat1Value
            // 
            this.lblStat1Value.AutoSize = true;
            this.lblStat1Value.BackColor = System.Drawing.Color.Transparent;
            this.lblStat1Value.Font = new System.Drawing.Font("Segoe UI", 21F, System.Drawing.FontStyle.Bold);
            this.lblStat1Value.ForeColor = System.Drawing.Color.FromArgb(24, 48, 42);
            this.lblStat1Value.Location = new System.Drawing.Point(66, 44);
            this.lblStat1Value.Name = "lblStat1Value";
            this.lblStat1Value.Size = new System.Drawing.Size(40, 47);
            this.lblStat1Value.TabIndex = 1;
            this.lblStat1Value.Text = "7";

            // 
            // lblStat1Title
            // 
            this.lblStat1Title.AutoSize = true;
            this.lblStat1Title.BackColor = System.Drawing.Color.Transparent;
            this.lblStat1Title.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblStat1Title.ForeColor = System.Drawing.Color.FromArgb(122, 149, 137);
            this.lblStat1Title.Location = new System.Drawing.Point(66, 22);
            this.lblStat1Title.Name = "lblStat1Title";
            this.lblStat1Title.Size = new System.Drawing.Size(110, 19);
            this.lblStat1Title.TabIndex = 2;
            this.lblStat1Title.Text = "DỊCH VỤ HÔM NAY";

            // 
            // flpStat1Trend
            // 
            this.flpStat1Trend.BackColor = System.Drawing.Color.Transparent;
            this.flpStat1Trend.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            this.flpStat1Trend.Location = new System.Drawing.Point(66, 98);
            this.flpStat1Trend.Name = "flpStat1Trend";
            this.flpStat1Trend.Size = new System.Drawing.Size(200, 25);
            this.flpStat1Trend.WrapContents = false;
            this.flpStat1Trend.Controls.Add(this.lblStat1TrendValue);
            this.flpStat1Trend.Controls.Add(this.lblStat1TrendText);
            this.flpStat1Trend.TabIndex = 3;

            // 
            // lblStat1TrendValue
            // 
            this.lblStat1TrendValue.AutoSize = true;
            this.lblStat1TrendValue.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblStat1TrendValue.ForeColor = System.Drawing.Color.FromArgb(15, 110, 86);
            this.lblStat1TrendValue.Location = new System.Drawing.Point(0, 0);
            this.lblStat1TrendValue.Margin = new System.Windows.Forms.Padding(0);
            this.lblStat1TrendValue.Name = "lblStat1TrendValue";
            this.lblStat1TrendValue.Text = "";

            // 
            // lblStat1TrendText
            // 
            this.lblStat1TrendText.AutoSize = true;
            this.lblStat1TrendText.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblStat1TrendText.ForeColor = System.Drawing.Color.FromArgb(15, 110, 86);
            this.lblStat1TrendText.Location = new System.Drawing.Point(0, 0);
            this.lblStat1TrendText.Margin = new System.Windows.Forms.Padding(0);
            this.lblStat1TrendText.Name = "lblStat1TrendText";
            this.lblStat1TrendText.Text = "Trong ca trực";

            // 
            // cardStat2
            // 
            this.cardStat2.BorderRadius = 12;
            this.cardStat2.BorderColor = System.Drawing.Color.FromArgb(218, 232, 226);
            this.cardStat2.BorderThickness = 1;
            this.cardStat2.FillColor = System.Drawing.Color.White;
            this.cardStat2.Location = new System.Drawing.Point(296, 166);
            this.cardStat2.Size = new System.Drawing.Size(248, 138);
            this.cardStat2.Name = "cardStat2";
            this.cardStat2.Controls.Add(this.lblStat2Value);
            this.cardStat2.Controls.Add(this.lblStat2Title);
            this.cardStat2.Controls.Add(this.flpStat2Trend);
            this.Controls.Add(this.cardStat2);

            // 
            // lblStat2Value
            // 
            this.lblStat2Value.AutoSize = true;
            this.lblStat2Value.BackColor = System.Drawing.Color.Transparent;
            this.lblStat2Value.Font = new System.Drawing.Font("Segoe UI", 21F, System.Drawing.FontStyle.Bold);
            this.lblStat2Value.ForeColor = System.Drawing.Color.FromArgb(240, 165, 0);
            this.lblStat2Value.Location = new System.Drawing.Point(66, 44);
            this.lblStat2Value.Name = "lblStat2Value";
            this.lblStat2Value.Size = new System.Drawing.Size(40, 47);
            this.lblStat2Value.TabIndex = 1;
            this.lblStat2Value.Text = "4";

            // 
            // lblStat2Title
            // 
            this.lblStat2Title.AutoSize = true;
            this.lblStat2Title.BackColor = System.Drawing.Color.Transparent;
            this.lblStat2Title.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblStat2Title.ForeColor = System.Drawing.Color.FromArgb(122, 149, 137);
            this.lblStat2Title.Location = new System.Drawing.Point(66, 22);
            this.lblStat2Title.Name = "lblStat2Title";
            this.lblStat2Title.Size = new System.Drawing.Size(121, 20);
            this.lblStat2Title.TabIndex = 2;
            this.lblStat2Title.Text = "CHỜ THỰC HIỆN";

            // 
            // flpStat2Trend
            // 
            this.flpStat2Trend.BackColor = System.Drawing.Color.Transparent;
            this.flpStat2Trend.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            this.flpStat2Trend.Location = new System.Drawing.Point(66, 98);
            this.flpStat2Trend.Name = "flpStat2Trend";
            this.flpStat2Trend.Size = new System.Drawing.Size(200, 25);
            this.flpStat2Trend.WrapContents = false;
            this.flpStat2Trend.Controls.Add(this.lblStat2TrendValue);
            this.flpStat2Trend.Controls.Add(this.lblStat2TrendText);
            this.flpStat2Trend.TabIndex = 3;

            // 
            // lblStat2TrendValue
            // 
            this.lblStat2TrendValue.AutoSize = true;
            this.lblStat2TrendValue.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblStat2TrendValue.ForeColor = System.Drawing.Color.FromArgb(160, 112, 0);
            this.lblStat2TrendValue.Location = new System.Drawing.Point(0, 0);
            this.lblStat2TrendValue.Margin = new System.Windows.Forms.Padding(0);
            this.lblStat2TrendValue.Name = "lblStat2TrendValue";
            this.lblStat2TrendValue.Text = "";

            // 
            // lblStat2TrendText
            // 
            this.lblStat2TrendText.AutoSize = true;
            this.lblStat2TrendText.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblStat2TrendText.ForeColor = System.Drawing.Color.FromArgb(160, 112, 0);
            this.lblStat2TrendText.Location = new System.Drawing.Point(0, 0);
            this.lblStat2TrendText.Margin = new System.Windows.Forms.Padding(0);
            this.lblStat2TrendText.Name = "lblStat2TrendText";
            this.lblStat2TrendText.Text = "Cần nhập KQ";

            // 
            // cardStat3
            // 
            this.cardStat3.BorderRadius = 12;
            this.cardStat3.BorderColor = System.Drawing.Color.FromArgb(218, 232, 226);
            this.cardStat3.BorderThickness = 1;
            this.cardStat3.FillColor = System.Drawing.Color.White;
            this.cardStat3.Location = new System.Drawing.Point(564, 166);
            this.cardStat3.Size = new System.Drawing.Size(248, 138);
            this.cardStat3.Name = "cardStat3";
            this.cardStat3.Controls.Add(this.lblStat3Value);
            this.cardStat3.Controls.Add(this.lblStat3Title);
            this.cardStat3.Controls.Add(this.flpStat3Trend);
            this.Controls.Add(this.cardStat3);

            // 
            // lblStat3Value
            // 
            this.lblStat3Value.AutoSize = true;
            this.lblStat3Value.BackColor = System.Drawing.Color.Transparent;
            this.lblStat3Value.Font = new System.Drawing.Font("Segoe UI", 21F, System.Drawing.FontStyle.Bold);
            this.lblStat3Value.ForeColor = System.Drawing.Color.FromArgb(15, 110, 86);
            this.lblStat3Value.Location = new System.Drawing.Point(66, 44);
            this.lblStat3Value.Name = "lblStat3Value";
            this.lblStat3Value.Size = new System.Drawing.Size(40, 47);
            this.lblStat3Value.TabIndex = 1;
            this.lblStat3Value.Text = "3";

            // 
            // lblStat3Title
            // 
            this.lblStat3Title.AutoSize = true;
            this.lblStat3Title.BackColor = System.Drawing.Color.Transparent;
            this.lblStat3Title.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblStat3Title.ForeColor = System.Drawing.Color.FromArgb(122, 149, 137);
            this.lblStat3Title.Location = new System.Drawing.Point(66, 22);
            this.lblStat3Title.Name = "lblStat3Title";
            this.lblStat3Title.Size = new System.Drawing.Size(107, 20);
            this.lblStat3Title.TabIndex = 2;
            this.lblStat3Title.Text = "HOÀN THÀNH";

            // 
            // flpStat3Trend
            // 
            this.flpStat3Trend.BackColor = System.Drawing.Color.Transparent;
            this.flpStat3Trend.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            this.flpStat3Trend.Location = new System.Drawing.Point(66, 98);
            this.flpStat3Trend.Name = "flpStat3Trend";
            this.flpStat3Trend.Size = new System.Drawing.Size(200, 18);
            this.flpStat3Trend.WrapContents = false;
            this.flpStat3Trend.Controls.Add(this.lblStat3TrendValue);
            this.flpStat3Trend.Controls.Add(this.lblStat3TrendText);
            this.flpStat3Trend.TabIndex = 3;

            // 
            // lblStat3TrendValue
            // 
            this.lblStat3TrendValue.AutoSize = true;
            this.lblStat3TrendValue.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblStat3TrendValue.ForeColor = System.Drawing.Color.FromArgb(229, 57, 53);
            this.lblStat3TrendValue.Location = new System.Drawing.Point(0, 0);
            this.lblStat3TrendValue.Margin = new System.Windows.Forms.Padding(0);
            this.lblStat3TrendValue.Name = "lblStat3TrendValue";
            this.lblStat3TrendValue.Text = "";

            // 
            // lblStat3TrendText
            // 
            this.lblStat3TrendText.AutoSize = true;
            this.lblStat3TrendText.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblStat3TrendText.ForeColor = System.Drawing.Color.FromArgb(229, 57, 53);
            this.lblStat3TrendText.Location = new System.Drawing.Point(0, 0);
            this.lblStat3TrendText.Margin = new System.Windows.Forms.Padding(0);
            this.lblStat3TrendText.Name = "lblStat3TrendText";
            this.lblStat3TrendText.Text = "Đã hoàn thành";

            // 
            // cardStat4
            // 
            this.cardStat4.BorderRadius = 12;
            this.cardStat4.BorderColor = System.Drawing.Color.FromArgb(218, 232, 226);
            this.cardStat4.BorderThickness = 1;
            this.cardStat4.FillColor = System.Drawing.Color.White;
            this.cardStat4.Location = new System.Drawing.Point(832, 166);
            this.cardStat4.Size = new System.Drawing.Size(248, 138);
            this.cardStat4.Name = "cardStat4";
            this.cardStat4.Controls.Add(this.lblStat4Value);
            this.cardStat4.Controls.Add(this.lblStat4Title);
            this.cardStat4.Controls.Add(this.flpStat4Trend);
            this.Controls.Add(this.cardStat4);

            // 
            // lblStat4Value
            // 
            this.lblStat4Value.AutoSize = true;
            this.lblStat4Value.BackColor = System.Drawing.Color.Transparent;
            this.lblStat4Value.Font = new System.Drawing.Font("Segoe UI", 21F, System.Drawing.FontStyle.Bold);
            this.lblStat4Value.ForeColor = System.Drawing.Color.FromArgb(25, 118, 210);
            this.lblStat4Value.Location = new System.Drawing.Point(66, 44);
            this.lblStat4Value.Name = "lblStat4Value";
            this.lblStat4Value.Size = new System.Drawing.Size(40, 47);
            this.lblStat4Value.TabIndex = 1;
            this.lblStat4Value.Text = "42%";

            // 
            // lblStat4Title
            // 
            this.lblStat4Title.AutoSize = true;
            this.lblStat4Title.BackColor = System.Drawing.Color.Transparent;
            this.lblStat4Title.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblStat4Title.ForeColor = System.Drawing.Color.FromArgb(122, 149, 137);
            this.lblStat4Title.Location = new System.Drawing.Point(66, 22);
            this.lblStat4Title.Name = "lblStat4Title";
            this.lblStat4Title.Size = new System.Drawing.Size(125, 20);
            this.lblStat4Title.TabIndex = 2;
            this.lblStat4Title.Text = "TIẾN ĐỘ TRONG NGÀY";

            // 
            // flpStat4Trend
            // 
            this.flpStat4Trend.BackColor = System.Drawing.Color.Transparent;
            this.flpStat4Trend.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            this.flpStat4Trend.Location = new System.Drawing.Point(66, 98);
            this.flpStat4Trend.Name = "flpStat4Trend";
            this.flpStat4Trend.Size = new System.Drawing.Size(200, 18);
            this.flpStat4Trend.WrapContents = false;
            this.flpStat4Trend.Controls.Add(this.lblStat4TrendValue);
            this.flpStat4Trend.Controls.Add(this.lblStat4TrendText);
            this.flpStat4Trend.TabIndex = 3;

            // 
            // lblStat4TrendValue
            // 
            this.lblStat4TrendValue.AutoSize = true;
            this.lblStat4TrendValue.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblStat4TrendValue.ForeColor = System.Drawing.Color.FromArgb(25, 118, 210);
            this.lblStat4TrendValue.Location = new System.Drawing.Point(0, 0);
            this.lblStat4TrendValue.Margin = new System.Windows.Forms.Padding(0);
            this.lblStat4TrendValue.Name = "lblStat4TrendValue";
            this.lblStat4TrendValue.Text = "";

            // 
            // lblStat4TrendText
            // 
            this.lblStat4TrendText.AutoSize = true;
            this.lblStat4TrendText.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblStat4TrendText.ForeColor = System.Drawing.Color.FromArgb(25, 118, 210);
            this.lblStat4TrendText.Location = new System.Drawing.Point(0, 0);
            this.lblStat4TrendText.Margin = new System.Windows.Forms.Padding(0);
            this.lblStat4TrendText.Name = "lblStat4TrendText";
            this.lblStat4TrendText.Text = " dịch vụ";

            this.Controls.Add(this.banner);
            this.Controls.Add(this.taskCard);
            this.Controls.Add(this.activityCard);
            this.Controls.Add(this.scheduleCard);
            this.Controls.Add(this.progressCard);

            this.Name = "ucKtvDashboard";
            this.Size = new System.Drawing.Size(1128, 1150);
            this.banner.ResumeLayout(false);
            this.banner.PerformLayout();
            this.taskCard.ResumeLayout(false);
            this.taskCard.PerformLayout();
            this.activityCard.ResumeLayout(false);
            this.activityCard.PerformLayout();
            this.scheduleCard.ResumeLayout(false);
            this.scheduleCard.PerformLayout();
            this.progressCard.ResumeLayout(false);
            this.progressCard.PerformLayout();
            this.cardStat1.ResumeLayout(false);
            this.cardStat1.PerformLayout();
            this.flpStat1Trend.ResumeLayout(false);
            this.flpStat1Trend.PerformLayout();
            this.cardStat2.ResumeLayout(false);
            this.cardStat2.PerformLayout();
            this.flpStat2Trend.ResumeLayout(false);
            this.flpStat2Trend.PerformLayout();
            this.cardStat3.ResumeLayout(false);
            this.cardStat3.PerformLayout();
            this.flpStat3Trend.ResumeLayout(false);
            this.flpStat3Trend.PerformLayout();
            this.cardStat4.ResumeLayout(false);
            this.cardStat4.PerformLayout();
            this.flpStat4Trend.ResumeLayout(false);
            this.flpStat4Trend.PerformLayout();
            this.ResumeLayout(false);
        }

        private Guna.UI2.WinForms.Guna2Panel banner;
        private System.Windows.Forms.Label lblDesignerBannerTitle;
        private System.Windows.Forms.Label lblDesignerBannerSub;
        private Guna.UI2.WinForms.Guna2Panel taskCard;
        private System.Windows.Forms.Label lblDesignerTaskTitle;
        private Guna.UI2.WinForms.Guna2Panel activityCard;
        private System.Windows.Forms.Label lblDesignerActivityTitle;
        private Guna.UI2.WinForms.Guna2Panel scheduleCard;
        private System.Windows.Forms.Label lblDesignerScheduleTitle;
        private Guna.UI2.WinForms.Guna2Panel progressCard;
        private System.Windows.Forms.Label lblDesignerProgressTitle;
        private Guna.UI2.WinForms.Guna2Panel cardStat1;
        private Guna.UI2.WinForms.Guna2Panel cardStat2;
        private Guna.UI2.WinForms.Guna2Panel cardStat3;
        private Guna.UI2.WinForms.Guna2Panel cardStat4;

        private System.Windows.Forms.Label lblStat1Value;
        private System.Windows.Forms.Label lblStat1Title;
        private System.Windows.Forms.FlowLayoutPanel flpStat1Trend;
        private System.Windows.Forms.Label lblStat1TrendValue;
        private System.Windows.Forms.Label lblStat1TrendText;

        private System.Windows.Forms.Label lblStat2Value;
        private System.Windows.Forms.Label lblStat2Title;
        private System.Windows.Forms.FlowLayoutPanel flpStat2Trend;
        private System.Windows.Forms.Label lblStat2TrendValue;
        private System.Windows.Forms.Label lblStat2TrendText;

        private System.Windows.Forms.Label lblStat3Value;
        private System.Windows.Forms.Label lblStat3Title;
        private System.Windows.Forms.FlowLayoutPanel flpStat3Trend;
        private System.Windows.Forms.Label lblStat3TrendValue;
        private System.Windows.Forms.Label lblStat3TrendText;

        private System.Windows.Forms.Label lblStat4Value;
        private System.Windows.Forms.Label lblStat4Title;
        private System.Windows.Forms.FlowLayoutPanel flpStat4Trend;
        private System.Windows.Forms.Label lblStat4TrendValue;
        private System.Windows.Forms.Label lblStat4TrendText;
    }
}
