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
            this.cardPersonalInfo = new Guna.UI2.WinForms.Guna2Panel();
            this.cardWorkInfo = new Guna.UI2.WinForms.Guna2Panel();
            this.cardSkills = new Guna.UI2.WinForms.Guna2Panel();
            this.cardCerts = new Guna.UI2.WinForms.Guna2Panel();
            this.cardActivities = new Guna.UI2.WinForms.Guna2Panel();
            
            // 4 Stats Cards
            this.cardStat1 = new Guna.UI2.WinForms.Guna2Panel();
            this.cardStat2 = new Guna.UI2.WinForms.Guna2Panel();
            this.cardStat3 = new Guna.UI2.WinForms.Guna2Panel();
            this.cardStat4 = new Guna.UI2.WinForms.Guna2Panel();

            this.pnlScroll.SuspendLayout();
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

            // 
            // cardPersonalInfo
            // 
            this.cardPersonalInfo.BorderRadius = 12;
            this.cardPersonalInfo.FillColor = System.Drawing.Color.White;
            this.cardPersonalInfo.Location = new System.Drawing.Point(28, 294);
            this.cardPersonalInfo.Size = new System.Drawing.Size(517, 340);
            this.cardPersonalInfo.Name = "cardPersonalInfo";

            // 
            // cardWorkInfo
            // 
            this.cardWorkInfo.BorderRadius = 12;
            this.cardWorkInfo.FillColor = System.Drawing.Color.White;
            this.cardWorkInfo.Location = new System.Drawing.Point(565, 294);
            this.cardWorkInfo.Size = new System.Drawing.Size(517, 340);
            this.cardWorkInfo.Name = "cardWorkInfo";

            // 
            // cardSkills
            // 
            this.cardSkills.BorderRadius = 12;
            this.cardSkills.FillColor = System.Drawing.Color.White;
            this.cardSkills.Location = new System.Drawing.Point(28, 654);
            this.cardSkills.Size = new System.Drawing.Size(517, 230);
            this.cardSkills.Name = "cardSkills";

            // 
            // cardCerts
            // 
            this.cardCerts.BorderRadius = 12;
            this.cardCerts.FillColor = System.Drawing.Color.White;
            this.cardCerts.Location = new System.Drawing.Point(28, 904);
            this.cardCerts.Size = new System.Drawing.Size(517, 230);
            this.cardCerts.Name = "cardCerts";

            // 
            // cardActivities
            // 
            this.cardActivities.BorderRadius = 12;
            this.cardActivities.FillColor = System.Drawing.Color.White;
            this.cardActivities.Location = new System.Drawing.Point(565, 654);
            this.cardActivities.Size = new System.Drawing.Size(517, 480);
            this.cardActivities.Name = "cardActivities";

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
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlScroll;
        private Guna.UI2.WinForms.Guna2Panel pnlHero;
        private Guna.UI2.WinForms.Guna2Panel cardPersonalInfo;
        private Guna.UI2.WinForms.Guna2Panel cardWorkInfo;
        private Guna.UI2.WinForms.Guna2Panel cardSkills;
        private Guna.UI2.WinForms.Guna2Panel cardCerts;
        private Guna.UI2.WinForms.Guna2Panel cardActivities;
        private Guna.UI2.WinForms.Guna2Panel cardStat1;
        private Guna.UI2.WinForms.Guna2Panel cardStat2;
        private Guna.UI2.WinForms.Guna2Panel cardStat3;
        private Guna.UI2.WinForms.Guna2Panel cardStat4;
    }
}
