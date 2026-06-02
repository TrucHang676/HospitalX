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
            this.lblDesignerHeroTitle = new System.Windows.Forms.Label();
            this.lblDesignerHeroSub = new System.Windows.Forms.Label();
            this.pnlFilter = new Guna.UI2.WinForms.Guna2Panel();
            this.lblDesignerFilterTitle = new System.Windows.Forms.Label();
            this.txtDesignerSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.pnlToolbar = new Guna.UI2.WinForms.Guna2Panel();
            this.btnDesignerAll = new Guna.UI2.WinForms.Guna2Button();
            this.btnDesignerUnread = new Guna.UI2.WinForms.Guna2Button();
            this.btnDesignerUrgent = new Guna.UI2.WinForms.Guna2Button();
            this.pnlNotifScroll = new System.Windows.Forms.Panel();
            this.pnlToast = new Guna.UI2.WinForms.Guna2Panel();
            this.cboSort = new Guna.UI2.WinForms.Guna2ComboBox();
            
            // 4 Stats Cards
            this.cardStat1 = new Guna.UI2.WinForms.Guna2Panel();
            this.cardStat2 = new Guna.UI2.WinForms.Guna2Panel();
            this.cardStat3 = new Guna.UI2.WinForms.Guna2Panel();
            this.cardStat4 = new Guna.UI2.WinForms.Guna2Panel();

            this.pnlHero.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.pnlToolbar.SuspendLayout();
            this.SuspendLayout();

            // 
            // pnlHero
            // 
            this.pnlHero.BorderRadius = 14;
            this.pnlHero.FillColor = System.Drawing.Color.FromArgb(15, 110, 86); // TealDark
            this.pnlHero.Location = new System.Drawing.Point(28, 28);
            this.pnlHero.Size = new System.Drawing.Size(1072, 92);
            this.pnlHero.Name = "pnlHero";
            this.pnlHero.Controls.Add(this.lblDesignerHeroTitle);
            this.pnlHero.Controls.Add(this.lblDesignerHeroSub);

            this.lblDesignerHeroTitle.AutoSize = true;
            this.lblDesignerHeroTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblDesignerHeroTitle.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold);
            this.lblDesignerHeroTitle.ForeColor = System.Drawing.Color.White;
            this.lblDesignerHeroTitle.Location = new System.Drawing.Point(24, 16);
            this.lblDesignerHeroTitle.Name = "lblDesignerHeroTitle";
            this.lblDesignerHeroTitle.Text = "Trung tâm thông báo";

            this.lblDesignerHeroSub.AutoSize = true;
            this.lblDesignerHeroSub.BackColor = System.Drawing.Color.Transparent;
            this.lblDesignerHeroSub.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblDesignerHeroSub.ForeColor = System.Drawing.Color.FromArgb(214, 239, 232);
            this.lblDesignerHeroSub.Location = new System.Drawing.Point(24, 56);
            this.lblDesignerHeroSub.Name = "lblDesignerHeroSub";
            this.lblDesignerHeroSub.Text = "Theo dõi phân công, cảnh báo xét nghiệm và cập nhật nghiệp vụ.";

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
            this.pnlFilter.Controls.Add(this.lblDesignerFilterTitle);
            this.pnlFilter.Controls.Add(this.txtDesignerSearch);

            this.lblDesignerFilterTitle.AutoSize = true;
            this.lblDesignerFilterTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblDesignerFilterTitle.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblDesignerFilterTitle.ForeColor = System.Drawing.Color.FromArgb(24, 48, 42);
            this.lblDesignerFilterTitle.Location = new System.Drawing.Point(20, 18);
            this.lblDesignerFilterTitle.Name = "lblDesignerFilterTitle";
            this.lblDesignerFilterTitle.Text = "Phân loại thông báo";

            this.txtDesignerSearch.BorderColor = System.Drawing.Color.FromArgb(218, 232, 226);
            this.txtDesignerSearch.BorderRadius = 8;
            this.txtDesignerSearch.FillColor = System.Drawing.Color.FromArgb(244, 247, 250);
            this.txtDesignerSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDesignerSearch.Location = new System.Drawing.Point(20, 52);
            this.txtDesignerSearch.Name = "txtDesignerSearch";
            this.txtDesignerSearch.PlaceholderText = "Tìm kiếm thông báo...";
            this.txtDesignerSearch.Size = new System.Drawing.Size(260, 36);

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
            this.pnlToolbar.Controls.Add(this.btnDesignerAll);
            this.pnlToolbar.Controls.Add(this.btnDesignerUnread);
            this.pnlToolbar.Controls.Add(this.btnDesignerUrgent);
            this.pnlToolbar.Controls.Add(this.cboSort);

            this.btnDesignerAll.BorderRadius = 16;
            this.btnDesignerAll.FillColor = System.Drawing.Color.FromArgb(15, 110, 86);
            this.btnDesignerAll.Font = new System.Drawing.Font("Segoe UI", 8.2F, System.Drawing.FontStyle.Bold);
            this.btnDesignerAll.ForeColor = System.Drawing.Color.White;
            this.btnDesignerAll.Location = new System.Drawing.Point(14, 8);
            this.btnDesignerAll.Name = "btnDesignerAll";
            this.btnDesignerAll.Size = new System.Drawing.Size(104, 32);
            this.btnDesignerAll.Text = "Tất cả";
            this.btnDesignerAll.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

            this.btnDesignerUnread.BorderColor = System.Drawing.Color.FromArgb(218, 232, 226);
            this.btnDesignerUnread.BorderRadius = 16;
            this.btnDesignerUnread.BorderThickness = 1;
            this.btnDesignerUnread.FillColor = System.Drawing.Color.White;
            this.btnDesignerUnread.Font = new System.Drawing.Font("Segoe UI", 8.2F, System.Drawing.FontStyle.Bold);
            this.btnDesignerUnread.ForeColor = System.Drawing.Color.FromArgb(74, 85, 104);
            this.btnDesignerUnread.Location = new System.Drawing.Point(124, 8);
            this.btnDesignerUnread.Name = "btnDesignerUnread";
            this.btnDesignerUnread.Size = new System.Drawing.Size(104, 32);
            this.btnDesignerUnread.Text = "Chưa đọc";
            this.btnDesignerUnread.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

            this.btnDesignerUrgent.BorderColor = System.Drawing.Color.FromArgb(218, 232, 226);
            this.btnDesignerUrgent.BorderRadius = 16;
            this.btnDesignerUrgent.BorderThickness = 1;
            this.btnDesignerUrgent.FillColor = System.Drawing.Color.White;
            this.btnDesignerUrgent.Font = new System.Drawing.Font("Segoe UI", 8.2F, System.Drawing.FontStyle.Bold);
            this.btnDesignerUrgent.ForeColor = System.Drawing.Color.FromArgb(74, 85, 104);
            this.btnDesignerUrgent.Location = new System.Drawing.Point(234, 8);
            this.btnDesignerUrgent.Name = "btnDesignerUrgent";
            this.btnDesignerUrgent.Size = new System.Drawing.Size(104, 32);
            this.btnDesignerUrgent.Text = "Khẩn cấp";
            this.btnDesignerUrgent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

            // 
            // cboSort
            // 
            this.cboSort.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(235)))), ((int)(((byte)(240)))));
            this.cboSort.BorderRadius = 6;
            this.cboSort.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.cboSort.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(85)))), ((int)(((byte)(104)))));
            this.cboSort.Items.AddRange(new object[] {
            "Mới nhất trước",
            "Cũ nhất trước"});
            this.cboSort.SelectedIndex = 0;
            this.cboSort.Size = new System.Drawing.Size(188, 34);
            this.cboSort.Name = "cboSort";


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
            this.pnlHero.ResumeLayout(false);
            this.pnlHero.PerformLayout();
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.pnlToolbar.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private Guna.UI2.WinForms.Guna2Panel pnlHero;
        private System.Windows.Forms.Label lblDesignerHeroTitle;
        private System.Windows.Forms.Label lblDesignerHeroSub;
        private Guna.UI2.WinForms.Guna2Panel pnlFilter;
        private System.Windows.Forms.Label lblDesignerFilterTitle;
        private Guna.UI2.WinForms.Guna2TextBox txtDesignerSearch;
        private Guna.UI2.WinForms.Guna2Panel pnlToolbar;
        private Guna.UI2.WinForms.Guna2Button btnDesignerAll;
        private Guna.UI2.WinForms.Guna2Button btnDesignerUnread;
        private Guna.UI2.WinForms.Guna2Button btnDesignerUrgent;
        private System.Windows.Forms.Panel pnlNotifScroll;
        private Guna.UI2.WinForms.Guna2Panel pnlToast;
        private Guna.UI2.WinForms.Guna2Panel cardStat1;
        private Guna.UI2.WinForms.Guna2Panel cardStat2;
        private Guna.UI2.WinForms.Guna2Panel cardStat3;
        private Guna.UI2.WinForms.Guna2Panel cardStat4;
        private Guna.UI2.WinForms.Guna2ComboBox cboSort;
    }
}
