using Guna.UI2.WinForms;
using System.Windows.Forms;

namespace HospitalX.GUI.PH2.KyThuatVien
{
    partial class ucKtvThongBao
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHero = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlFilter = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlToolbar = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlNotifScroll = new System.Windows.Forms.Panel();
            this.pnlToast = new Guna.UI2.WinForms.Guna2Panel();
            
            // 4 Stats Cards
            this.cardStat1 = new Guna.UI2.WinForms.Guna2Panel();
            this.cardStat2 = new Guna.UI2.WinForms.Guna2Panel();
            this.cardStat3 = new Guna.UI2.WinForms.Guna2Panel();
            this.cardStat4 = new Guna.UI2.WinForms.Guna2Panel();

            this.SuspendLayout();

            // 
            // pnlHero
            // 
            this.pnlHero.BorderRadius = 14;
            this.pnlHero.FillColor = System.Drawing.Color.FromArgb(15, 110, 86); // TealDark
            this.pnlHero.Location = new System.Drawing.Point(28, 28);
            this.pnlHero.Size = new System.Drawing.Size(1072, 92);
            this.pnlHero.Name = "pnlHero";

            // 
            // pnlFilter
            // 
            this.pnlFilter.BorderRadius = 12;
            this.pnlFilter.BorderColor = System.Drawing.Color.FromArgb(218, 232, 226);
            this.pnlFilter.BorderThickness = 1;
            this.pnlFilter.FillColor = System.Drawing.Color.White;
            this.pnlFilter.Location = new System.Drawing.Point(28, 138);
            this.pnlFilter.Size = new System.Drawing.Size(300, 600);
            this.pnlFilter.Name = "pnlFilter";

            // 
            // pnlNotifScroll
            // 
            this.pnlNotifScroll.BackColor = System.Drawing.Color.Transparent;
            this.pnlNotifScroll.Location = new System.Drawing.Point(348, 138);
            this.pnlNotifScroll.Size = new System.Drawing.Size(752, 600);
            this.pnlNotifScroll.Name = "pnlNotifScroll";
            this.pnlNotifScroll.AutoScroll = true;

            // 
            // pnlToolbar
            // 
            this.pnlToolbar.BorderRadius = 12;
            this.pnlToolbar.BorderColor = System.Drawing.Color.FromArgb(218, 232, 226);
            this.pnlToolbar.BorderThickness = 1;
            this.pnlToolbar.FillColor = System.Drawing.Color.White;
            this.pnlToolbar.Location = new System.Drawing.Point(0, 88);
            this.pnlToolbar.Size = new System.Drawing.Size(740, 52);
            this.pnlToolbar.Name = "pnlToolbar";

            // 
            // pnlToast
            // 
            this.pnlToast.BorderRadius = 10;
            this.pnlToast.FillColor = System.Drawing.Color.FromArgb(15, 110, 86);
            this.pnlToast.Location = new System.Drawing.Point(740, 720);
            this.pnlToast.Size = new System.Drawing.Size(360, 52);
            this.pnlToast.Name = "pnlToast";
            this.pnlToast.Visible = false;

            this.cardStat1.BorderRadius = 12;
            this.cardStat1.BorderColor = System.Drawing.Color.FromArgb(218, 232, 226);
            this.cardStat1.BorderThickness = 1;
            this.cardStat1.FillColor = System.Drawing.Color.White;
            this.cardStat1.Location = new System.Drawing.Point(0, 0);
            this.cardStat1.Size = new System.Drawing.Size(175, 72);
            this.cardStat1.Name = "cardStat1";
            this.pnlNotifScroll.Controls.Add(this.cardStat1);

            this.cardStat2.BorderRadius = 12;
            this.cardStat2.BorderColor = System.Drawing.Color.FromArgb(218, 232, 226);
            this.cardStat2.BorderThickness = 1;
            this.cardStat2.FillColor = System.Drawing.Color.White;
            this.cardStat2.Location = new System.Drawing.Point(185, 0);
            this.cardStat2.Size = new System.Drawing.Size(175, 72);
            this.cardStat2.Name = "cardStat2";
            this.pnlNotifScroll.Controls.Add(this.cardStat2);

            this.cardStat3.BorderRadius = 12;
            this.cardStat3.BorderColor = System.Drawing.Color.FromArgb(218, 232, 226);
            this.cardStat3.BorderThickness = 1;
            this.cardStat3.FillColor = System.Drawing.Color.White;
            this.cardStat3.Location = new System.Drawing.Point(370, 0);
            this.cardStat3.Size = new System.Drawing.Size(175, 72);
            this.cardStat3.Name = "cardStat3";
            this.pnlNotifScroll.Controls.Add(this.cardStat3);

            this.cardStat4.BorderRadius = 12;
            this.cardStat4.BorderColor = System.Drawing.Color.FromArgb(218, 232, 226);
            this.cardStat4.BorderThickness = 1;
            this.cardStat4.FillColor = System.Drawing.Color.White;
            this.cardStat4.Location = new System.Drawing.Point(555, 0);
            this.cardStat4.Size = new System.Drawing.Size(175, 72);
            this.cardStat4.Name = "cardStat4";
            this.pnlNotifScroll.Controls.Add(this.cardStat4);

            this.pnlNotifScroll.Controls.Add(this.pnlToolbar);

            this.Controls.Add(this.pnlHero);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.pnlNotifScroll);
            this.Controls.Add(this.pnlToast);

            this.Name = "ucKtvThongBao";
            this.Size = new System.Drawing.Size(1128, 782);
            this.ResumeLayout(false);
        }

        private Guna.UI2.WinForms.Guna2Panel pnlHero;
        private Guna.UI2.WinForms.Guna2Panel pnlFilter;
        private Guna.UI2.WinForms.Guna2Panel pnlToolbar;
        private System.Windows.Forms.Panel pnlNotifScroll;
        private Guna.UI2.WinForms.Guna2Panel pnlToast;
        private Guna.UI2.WinForms.Guna2Panel cardStat1;
        private Guna.UI2.WinForms.Guna2Panel cardStat2;
        private Guna.UI2.WinForms.Guna2Panel cardStat3;
        private Guna.UI2.WinForms.Guna2Panel cardStat4;
    }
}
