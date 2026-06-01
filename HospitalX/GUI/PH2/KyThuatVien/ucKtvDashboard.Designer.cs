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
            this.cardStat2 = new Guna.UI2.WinForms.Guna2Panel();
            this.cardStat3 = new Guna.UI2.WinForms.Guna2Panel();
            this.cardStat4 = new Guna.UI2.WinForms.Guna2Panel();

            this.banner.SuspendLayout();
            this.taskCard.SuspendLayout();
            this.activityCard.SuspendLayout();
            this.scheduleCard.SuspendLayout();
            this.progressCard.SuspendLayout();
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

            this.cardStat1.BorderRadius = 12;
            this.cardStat1.BorderColor = System.Drawing.Color.FromArgb(218, 232, 226);
            this.cardStat1.BorderThickness = 1;
            this.cardStat1.FillColor = System.Drawing.Color.White;
            this.cardStat1.Location = new System.Drawing.Point(28, 166);
            this.cardStat1.Size = new System.Drawing.Size(248, 138);
            this.cardStat1.Name = "cardStat1";
            this.Controls.Add(this.cardStat1);

            this.cardStat2.BorderRadius = 12;
            this.cardStat2.BorderColor = System.Drawing.Color.FromArgb(218, 232, 226);
            this.cardStat2.BorderThickness = 1;
            this.cardStat2.FillColor = System.Drawing.Color.White;
            this.cardStat2.Location = new System.Drawing.Point(296, 166);
            this.cardStat2.Size = new System.Drawing.Size(248, 138);
            this.cardStat2.Name = "cardStat2";
            this.Controls.Add(this.cardStat2);

            this.cardStat3.BorderRadius = 12;
            this.cardStat3.BorderColor = System.Drawing.Color.FromArgb(218, 232, 226);
            this.cardStat3.BorderThickness = 1;
            this.cardStat3.FillColor = System.Drawing.Color.White;
            this.cardStat3.Location = new System.Drawing.Point(564, 166);
            this.cardStat3.Size = new System.Drawing.Size(248, 138);
            this.cardStat3.Name = "cardStat3";
            this.Controls.Add(this.cardStat3);

            this.cardStat4.BorderRadius = 12;
            this.cardStat4.BorderColor = System.Drawing.Color.FromArgb(218, 232, 226);
            this.cardStat4.BorderThickness = 1;
            this.cardStat4.FillColor = System.Drawing.Color.White;
            this.cardStat4.Location = new System.Drawing.Point(832, 166);
            this.cardStat4.Size = new System.Drawing.Size(248, 138);
            this.cardStat4.Name = "cardStat4";
            this.Controls.Add(this.cardStat4);

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
    }
}
