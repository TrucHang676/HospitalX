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
            this.taskCard = new Guna.UI2.WinForms.Guna2Panel();
            this.activityCard = new Guna.UI2.WinForms.Guna2Panel();
            this.scheduleCard = new Guna.UI2.WinForms.Guna2Panel();
            this.progressCard = new Guna.UI2.WinForms.Guna2Panel();
            
            // 4 Stats Cards
            this.cardStat1 = new Guna.UI2.WinForms.Guna2Panel();
            this.cardStat2 = new Guna.UI2.WinForms.Guna2Panel();
            this.cardStat3 = new Guna.UI2.WinForms.Guna2Panel();
            this.cardStat4 = new Guna.UI2.WinForms.Guna2Panel();

            this.SuspendLayout();

            // 
            // banner
            // 
            this.banner.BorderRadius = 14;
            this.banner.FillColor = System.Drawing.Color.FromArgb(15, 110, 86); // Teal
            this.banner.Location = new System.Drawing.Point(28, 28);
            this.banner.Size = new System.Drawing.Size(1054, 118);
            this.banner.Name = "banner";

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
            this.ResumeLayout(false);
        }

        private Guna.UI2.WinForms.Guna2Panel banner;
        private Guna.UI2.WinForms.Guna2Panel taskCard;
        private Guna.UI2.WinForms.Guna2Panel activityCard;
        private Guna.UI2.WinForms.Guna2Panel scheduleCard;
        private Guna.UI2.WinForms.Guna2Panel progressCard;
        private Guna.UI2.WinForms.Guna2Panel cardStat1;
        private Guna.UI2.WinForms.Guna2Panel cardStat2;
        private Guna.UI2.WinForms.Guna2Panel cardStat3;
        private Guna.UI2.WinForms.Guna2Panel cardStat4;
    }
}
