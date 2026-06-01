namespace HospitalX.GUI.PH2.KyThuatVien
{
    partial class ucKtvHoSo
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlScroll = new System.Windows.Forms.Panel();
            this.pnlHero = new Guna.UI2.WinForms.Guna2Panel();
            this.lblDesignerHeroName = new System.Windows.Forms.Label();
            this.lblDesignerHeroRole = new System.Windows.Forms.Label();
            this.cardPersonalInfo = new Guna.UI2.WinForms.Guna2Panel();
            this.lblDesignerPersonalTitle = new System.Windows.Forms.Label();
            this.cardWorkInfo = new Guna.UI2.WinForms.Guna2Panel();
            this.lblDesignerWorkTitle = new System.Windows.Forms.Label();
            this.cardSkills = new Guna.UI2.WinForms.Guna2Panel();
            this.lblDesignerSkillsTitle = new System.Windows.Forms.Label();
            this.cardCerts = new Guna.UI2.WinForms.Guna2Panel();
            this.lblDesignerCertsTitle = new System.Windows.Forms.Label();
            this.cardActivities = new Guna.UI2.WinForms.Guna2Panel();
            this.lblDesignerActivitiesTitle = new System.Windows.Forms.Label();
            
            // 4 Stats Cards
            this.cardStat1 = new Guna.UI2.WinForms.Guna2Panel();
            this.cardStat2 = new Guna.UI2.WinForms.Guna2Panel();
            this.cardStat3 = new Guna.UI2.WinForms.Guna2Panel();
            this.cardStat4 = new Guna.UI2.WinForms.Guna2Panel();

            this.pnlScroll.SuspendLayout();
            this.pnlHero.SuspendLayout();
            this.cardPersonalInfo.SuspendLayout();
            this.cardWorkInfo.SuspendLayout();
            this.cardSkills.SuspendLayout();
            this.cardCerts.SuspendLayout();
            this.cardActivities.SuspendLayout();
            this.SuspendLayout();

            // 
            // pnlScroll
            // 
            this.pnlScroll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlScroll.AutoScroll = true;
            this.pnlScroll.BackColor = System.Drawing.Color.Transparent;
            this.pnlScroll.Name = "pnlScroll";

            // 
            // pnlHero
            // 
            this.pnlHero.BorderRadius = 12;
            this.pnlHero.FillColor = System.Drawing.Color.FromArgb(10, 79, 61); // TealDark
            this.pnlHero.Location = new System.Drawing.Point(28, 28);
            this.pnlHero.Size = new System.Drawing.Size(1054, 134);
            this.pnlHero.Name = "pnlHero";
            this.pnlHero.Controls.Add(this.lblDesignerHeroName);
            this.pnlHero.Controls.Add(this.lblDesignerHeroRole);

            this.lblDesignerHeroName.AutoSize = true;
            this.lblDesignerHeroName.BackColor = System.Drawing.Color.Transparent;
            this.lblDesignerHeroName.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblDesignerHeroName.ForeColor = System.Drawing.Color.White;
            this.lblDesignerHeroName.Location = new System.Drawing.Point(134, 20);
            this.lblDesignerHeroName.Name = "lblDesignerHeroName";
            this.lblDesignerHeroName.Text = "Nguyễn Thị Thu";

            this.lblDesignerHeroRole.AutoSize = true;
            this.lblDesignerHeroRole.BackColor = System.Drawing.Color.Transparent;
            this.lblDesignerHeroRole.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblDesignerHeroRole.ForeColor = System.Drawing.Color.FromArgb(218, 242, 235);
            this.lblDesignerHeroRole.Location = new System.Drawing.Point(136, 62);
            this.lblDesignerHeroRole.Name = "lblDesignerHeroRole";
            this.lblDesignerHeroRole.Text = "Kỹ thuật viên xét nghiệm - Khoa xét nghiệm";

            // 
            // cardPersonalInfo
            // 
            this.cardPersonalInfo.BorderRadius = 12;
            this.cardPersonalInfo.FillColor = System.Drawing.Color.White;
            this.cardPersonalInfo.Location = new System.Drawing.Point(28, 294);
            this.cardPersonalInfo.Size = new System.Drawing.Size(517, 340);
            this.cardPersonalInfo.Name = "cardPersonalInfo";
            this.cardPersonalInfo.Controls.Add(this.lblDesignerPersonalTitle);

            this.lblDesignerPersonalTitle.AutoSize = true;
            this.lblDesignerPersonalTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblDesignerPersonalTitle.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblDesignerPersonalTitle.ForeColor = System.Drawing.Color.FromArgb(24, 48, 42);
            this.lblDesignerPersonalTitle.Location = new System.Drawing.Point(20, 18);
            this.lblDesignerPersonalTitle.Name = "lblDesignerPersonalTitle";
            this.lblDesignerPersonalTitle.Text = "Thông tin cá nhân";

            // 
            // cardWorkInfo
            // 
            this.cardWorkInfo.BorderRadius = 12;
            this.cardWorkInfo.FillColor = System.Drawing.Color.White;
            this.cardWorkInfo.Location = new System.Drawing.Point(565, 294);
            this.cardWorkInfo.Size = new System.Drawing.Size(517, 340);
            this.cardWorkInfo.Name = "cardWorkInfo";
            this.cardWorkInfo.Controls.Add(this.lblDesignerWorkTitle);

            this.lblDesignerWorkTitle.AutoSize = true;
            this.lblDesignerWorkTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblDesignerWorkTitle.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblDesignerWorkTitle.ForeColor = System.Drawing.Color.FromArgb(24, 48, 42);
            this.lblDesignerWorkTitle.Location = new System.Drawing.Point(20, 18);
            this.lblDesignerWorkTitle.Name = "lblDesignerWorkTitle";
            this.lblDesignerWorkTitle.Text = "Thông tin công tác";

            // 
            // cardSkills
            // 
            this.cardSkills.BorderRadius = 12;
            this.cardSkills.FillColor = System.Drawing.Color.White;
            this.cardSkills.Location = new System.Drawing.Point(28, 654);
            this.cardSkills.Size = new System.Drawing.Size(517, 230);
            this.cardSkills.Name = "cardSkills";
            this.cardSkills.Controls.Add(this.lblDesignerSkillsTitle);

            this.lblDesignerSkillsTitle.AutoSize = true;
            this.lblDesignerSkillsTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblDesignerSkillsTitle.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblDesignerSkillsTitle.ForeColor = System.Drawing.Color.FromArgb(24, 48, 42);
            this.lblDesignerSkillsTitle.Location = new System.Drawing.Point(20, 18);
            this.lblDesignerSkillsTitle.Name = "lblDesignerSkillsTitle";
            this.lblDesignerSkillsTitle.Text = "Kỹ năng chuyên môn";

            // 
            // cardCerts
            // 
            this.cardCerts.BorderRadius = 12;
            this.cardCerts.FillColor = System.Drawing.Color.White;
            this.cardCerts.Location = new System.Drawing.Point(28, 904);
            this.cardCerts.Size = new System.Drawing.Size(517, 230);
            this.cardCerts.Name = "cardCerts";
            this.cardCerts.Controls.Add(this.lblDesignerCertsTitle);

            this.lblDesignerCertsTitle.AutoSize = true;
            this.lblDesignerCertsTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblDesignerCertsTitle.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblDesignerCertsTitle.ForeColor = System.Drawing.Color.FromArgb(24, 48, 42);
            this.lblDesignerCertsTitle.Location = new System.Drawing.Point(20, 18);
            this.lblDesignerCertsTitle.Name = "lblDesignerCertsTitle";
            this.lblDesignerCertsTitle.Text = "Chứng chỉ";

            // 
            // cardActivities
            // 
            this.cardActivities.BorderRadius = 12;
            this.cardActivities.FillColor = System.Drawing.Color.White;
            this.cardActivities.Location = new System.Drawing.Point(565, 654);
            this.cardActivities.Size = new System.Drawing.Size(517, 480);
            this.cardActivities.Name = "cardActivities";
            this.cardActivities.Controls.Add(this.lblDesignerActivitiesTitle);

            this.lblDesignerActivitiesTitle.AutoSize = true;
            this.lblDesignerActivitiesTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblDesignerActivitiesTitle.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblDesignerActivitiesTitle.ForeColor = System.Drawing.Color.FromArgb(24, 48, 42);
            this.lblDesignerActivitiesTitle.Location = new System.Drawing.Point(20, 18);
            this.lblDesignerActivitiesTitle.Name = "lblDesignerActivitiesTitle";
            this.lblDesignerActivitiesTitle.Text = "Hoạt động gần đây";

            this.cardStat1.BorderRadius = 12;
            this.cardStat1.FillColor = System.Drawing.Color.White;
            this.cardStat1.Location = new System.Drawing.Point(28, 182);
            this.cardStat1.Size = new System.Drawing.Size(248, 92);
            this.cardStat1.Name = "cardStat1";
            this.pnlScroll.Controls.Add(this.cardStat1);

            this.cardStat2.BorderRadius = 12;
            this.cardStat2.FillColor = System.Drawing.Color.White;
            this.cardStat2.Location = new System.Drawing.Point(296, 182);
            this.cardStat2.Size = new System.Drawing.Size(248, 92);
            this.cardStat2.Name = "cardStat2";
            this.pnlScroll.Controls.Add(this.cardStat2);

            this.cardStat3.BorderRadius = 12;
            this.cardStat3.FillColor = System.Drawing.Color.White;
            this.cardStat3.Location = new System.Drawing.Point(564, 182);
            this.cardStat3.Size = new System.Drawing.Size(248, 92);
            this.cardStat3.Name = "cardStat3";
            this.pnlScroll.Controls.Add(this.cardStat3);

            this.cardStat4.BorderRadius = 12;
            this.cardStat4.FillColor = System.Drawing.Color.White;
            this.cardStat4.Location = new System.Drawing.Point(832, 182);
            this.cardStat4.Size = new System.Drawing.Size(248, 92);
            this.cardStat4.Name = "cardStat4";
            this.pnlScroll.Controls.Add(this.cardStat4);

            this.pnlScroll.Controls.Add(this.pnlHero);
            this.pnlScroll.Controls.Add(this.cardPersonalInfo);
            this.pnlScroll.Controls.Add(this.cardWorkInfo);
            this.pnlScroll.Controls.Add(this.cardSkills);
            this.pnlScroll.Controls.Add(this.cardCerts);
            this.pnlScroll.Controls.Add(this.cardActivities);

            this.Controls.Add(this.pnlScroll);

            this.Name = "ucKtvHoSo";
            this.Size = new System.Drawing.Size(1128, 782);
            this.pnlScroll.ResumeLayout(false);
            this.pnlHero.ResumeLayout(false);
            this.pnlHero.PerformLayout();
            this.cardPersonalInfo.ResumeLayout(false);
            this.cardPersonalInfo.PerformLayout();
            this.cardWorkInfo.ResumeLayout(false);
            this.cardWorkInfo.PerformLayout();
            this.cardSkills.ResumeLayout(false);
            this.cardSkills.PerformLayout();
            this.cardCerts.ResumeLayout(false);
            this.cardCerts.PerformLayout();
            this.cardActivities.ResumeLayout(false);
            this.cardActivities.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlScroll;
        private Guna.UI2.WinForms.Guna2Panel pnlHero;
        private System.Windows.Forms.Label lblDesignerHeroName;
        private System.Windows.Forms.Label lblDesignerHeroRole;
        private Guna.UI2.WinForms.Guna2Panel cardPersonalInfo;
        private System.Windows.Forms.Label lblDesignerPersonalTitle;
        private Guna.UI2.WinForms.Guna2Panel cardWorkInfo;
        private System.Windows.Forms.Label lblDesignerWorkTitle;
        private Guna.UI2.WinForms.Guna2Panel cardSkills;
        private System.Windows.Forms.Label lblDesignerSkillsTitle;
        private Guna.UI2.WinForms.Guna2Panel cardCerts;
        private System.Windows.Forms.Label lblDesignerCertsTitle;
        private Guna.UI2.WinForms.Guna2Panel cardActivities;
        private System.Windows.Forms.Label lblDesignerActivitiesTitle;
        private Guna.UI2.WinForms.Guna2Panel cardStat1;
        private Guna.UI2.WinForms.Guna2Panel cardStat2;
        private Guna.UI2.WinForms.Guna2Panel cardStat3;
        private Guna.UI2.WinForms.Guna2Panel cardStat4;
    }
}
