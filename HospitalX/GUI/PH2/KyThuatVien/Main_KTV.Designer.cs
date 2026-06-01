using Guna.UI2.WinForms;
using HospitalX.GUI.PH2.KyThuatVien;
using System.Drawing;
using System.Windows.Forms;

namespace HospitalX.GUI.PH2
{
    partial class Main_KTV
    {
        private System.ComponentModel.IContainer components = null;
        private Guna2BorderlessForm guna2BorderlessForm1;
        private Guna2Panel pnlSidebar;
        private Guna2Panel pnlTopbar;
        private Panel pnlContent;
        private Label lblPageTitle;
        private Label lblSubtitle;
        private Label lblBrand;
        private Label lblBrandSub;
        private Label lblTenKtv;
        private Label lblRole;
        private Guna2Panel pnlLogo;
        private Guna2Panel pnlAvatar;
        private Label lblLogoPlus;
        private Label lblAvatarText;
        private Guna2Button btnDashboard;
        private Guna2Button btnDichVu;
        private Guna2Button btnKetQua;
        private Guna2Button btnHoSo;
        private Guna2Button btnThongBao;
        private Guna2Button btnLogout;
        private Guna2ControlBox btnExit;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main_KTV));
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.pnlSidebar = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlLogo = new Guna.UI2.WinForms.Guna2Panel();
            this.lblLogoPlus = new System.Windows.Forms.Label();
            this.lblBrand = new System.Windows.Forms.Label();
            this.lblBrandSub = new System.Windows.Forms.Label();
            this.pnlAvatar = new Guna.UI2.WinForms.Guna2Panel();
            this.lblAvatarText = new System.Windows.Forms.Label();
            this.lblTenKtv = new System.Windows.Forms.Label();
            this.lblRole = new System.Windows.Forms.Label();
            this.btnDashboard = new Guna.UI2.WinForms.Guna2Button();
            this.btnDichVu = new Guna.UI2.WinForms.Guna2Button();
            this.btnKetQua = new Guna.UI2.WinForms.Guna2Button();
            this.btnHoSo = new Guna.UI2.WinForms.Guna2Button();
            this.btnThongBao = new Guna.UI2.WinForms.Guna2Button();
            this.btnLogout = new Guna.UI2.WinForms.Guna2Button();
            this.pnlTopbar = new Guna.UI2.WinForms.Guna2Panel();
            this.lblPageTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.btnExit = new Guna.UI2.WinForms.Guna2ControlBox();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.ptbChuThap = new Guna.UI2.WinForms.Guna2PictureBox();
            this.ptbAdmin = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pnlSidebar.SuspendLayout();
            this.pnlLogo.SuspendLayout();
            this.pnlAvatar.SuspendLayout();
            this.pnlTopbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbChuThap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbAdmin)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.BorderRadius = 20;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(79)))), ((int)(((byte)(61)))));
            this.pnlSidebar.Controls.Add(this.pnlLogo);
            this.pnlSidebar.Controls.Add(this.lblBrand);
            this.pnlSidebar.Controls.Add(this.lblBrandSub);
            this.pnlSidebar.Controls.Add(this.pnlAvatar);
            this.pnlSidebar.Controls.Add(this.lblTenKtv);
            this.pnlSidebar.Controls.Add(this.lblRole);
            this.pnlSidebar.Controls.Add(this.btnDashboard);
            this.pnlSidebar.Controls.Add(this.btnDichVu);
            this.pnlSidebar.Controls.Add(this.btnKetQua);
            this.pnlSidebar.Controls.Add(this.btnHoSo);
            this.pnlSidebar.Controls.Add(this.btnThongBao);
            this.pnlSidebar.Controls.Add(this.btnLogout);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(79)))), ((int)(((byte)(61)))));
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Margin = new System.Windows.Forms.Padding(4);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(293, 1046);
            this.pnlSidebar.TabIndex = 2;
            // 
            // pnlLogo
            // 
            this.pnlLogo.BorderRadius = 23;
            this.pnlLogo.Controls.Add(this.ptbChuThap);
            this.pnlLogo.Controls.Add(this.lblLogoPlus);
            this.pnlLogo.FillColor = System.Drawing.Color.White;
            this.pnlLogo.Location = new System.Drawing.Point(11, 7);
            this.pnlLogo.Margin = new System.Windows.Forms.Padding(4);
            this.pnlLogo.Name = "pnlLogo";
            this.pnlLogo.Size = new System.Drawing.Size(61, 57);
            this.pnlLogo.TabIndex = 0;
            // 
            // lblLogoPlus
            // 
            this.lblLogoPlus.BackColor = System.Drawing.Color.Transparent;
            this.lblLogoPlus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLogoPlus.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblLogoPlus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(225)))), ((int)(((byte)(220)))));
            this.lblLogoPlus.Location = new System.Drawing.Point(0, 0);
            this.lblLogoPlus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLogoPlus.Name = "lblLogoPlus";
            this.lblLogoPlus.Size = new System.Drawing.Size(61, 57);
            this.lblLogoPlus.TabIndex = 0;
            this.lblLogoPlus.Text = "+";
            this.lblLogoPlus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLogoPlus.Click += new System.EventHandler(this.lblLogoPlus_Click);
            // 
            // lblBrand
            // 
            this.lblBrand.AutoSize = true;
            this.lblBrand.BackColor = System.Drawing.Color.Transparent;
            this.lblBrand.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblBrand.ForeColor = System.Drawing.Color.White;
            this.lblBrand.Location = new System.Drawing.Point(87, 26);
            this.lblBrand.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(125, 32);
            this.lblBrand.TabIndex = 1;
            this.lblBrand.Text = "HospitalX";
            // 
            // lblBrandSub
            // 
            this.lblBrandSub.AutoSize = true;
            this.lblBrandSub.BackColor = System.Drawing.Color.Transparent;
            this.lblBrandSub.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Bold);
            this.lblBrandSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(220)))), ((int)(((byte)(205)))));
            this.lblBrandSub.Location = new System.Drawing.Point(88, 55);
            this.lblBrandSub.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBrandSub.Name = "lblBrandSub";
            this.lblBrandSub.Size = new System.Drawing.Size(95, 15);
            this.lblBrandSub.TabIndex = 2;
            this.lblBrandSub.Text = "KỸ THUẬT VIÊN";
            // 
            // pnlAvatar
            // 
            this.pnlAvatar.BorderRadius = 18;
            this.pnlAvatar.Controls.Add(this.ptbAdmin);
            this.pnlAvatar.Controls.Add(this.lblAvatarText);
            this.pnlAvatar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(245)))), ((int)(((byte)(240)))));
            this.pnlAvatar.Location = new System.Drawing.Point(24, 101);
            this.pnlAvatar.Margin = new System.Windows.Forms.Padding(4);
            this.pnlAvatar.Name = "pnlAvatar";
            this.pnlAvatar.Size = new System.Drawing.Size(48, 44);
            this.pnlAvatar.TabIndex = 3;
            // 
            // lblAvatarText
            // 
            this.lblAvatarText.BackColor = System.Drawing.Color.Transparent;
            this.lblAvatarText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAvatarText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblAvatarText.ForeColor = System.Drawing.Color.White;
            this.lblAvatarText.Location = new System.Drawing.Point(0, 0);
            this.lblAvatarText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAvatarText.Name = "lblAvatarText";
            this.lblAvatarText.Size = new System.Drawing.Size(48, 44);
            this.lblAvatarText.TabIndex = 0;
            this.lblAvatarText.Text = "NT";
            this.lblAvatarText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTenKtv
            // 
            this.lblTenKtv.AutoSize = true;
            this.lblTenKtv.BackColor = System.Drawing.Color.Transparent;
            this.lblTenKtv.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTenKtv.ForeColor = System.Drawing.Color.White;
            this.lblTenKtv.Location = new System.Drawing.Point(85, 106);
            this.lblTenKtv.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTenKtv.Name = "lblTenKtv";
            this.lblTenKtv.Size = new System.Drawing.Size(121, 20);
            this.lblTenKtv.TabIndex = 4;
            this.lblTenKtv.Text = "Nguyễn Thị Thu";
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.BackColor = System.Drawing.Color.Transparent;
            this.lblRole.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblRole.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(215)))), ((int)(((byte)(205)))));
            this.lblRole.Location = new System.Drawing.Point(85, 130);
            this.lblRole.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(99, 17);
            this.lblRole.TabIndex = 5;
            this.lblRole.Text = "KTV xét nghiệm";
            // 
            // btnDashboard
            // 
            this.btnDashboard.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDashboard.ForeColor = System.Drawing.Color.White;
            this.btnDashboard.Location = new System.Drawing.Point(0, 0);
            this.btnDashboard.Margin = new System.Windows.Forms.Padding(4);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(240, 55);
            this.btnDashboard.TabIndex = 6;
            // 
            // btnDichVu
            // 
            this.btnDichVu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDichVu.ForeColor = System.Drawing.Color.White;
            this.btnDichVu.Location = new System.Drawing.Point(0, 0);
            this.btnDichVu.Margin = new System.Windows.Forms.Padding(4);
            this.btnDichVu.Name = "btnDichVu";
            this.btnDichVu.Size = new System.Drawing.Size(240, 55);
            this.btnDichVu.TabIndex = 7;
            // 
            // btnKetQua
            // 
            this.btnKetQua.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnKetQua.ForeColor = System.Drawing.Color.White;
            this.btnKetQua.Location = new System.Drawing.Point(0, 0);
            this.btnKetQua.Margin = new System.Windows.Forms.Padding(4);
            this.btnKetQua.Name = "btnKetQua";
            this.btnKetQua.Size = new System.Drawing.Size(240, 55);
            this.btnKetQua.TabIndex = 8;
            // 
            // btnHoSo
            // 
            this.btnHoSo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnHoSo.ForeColor = System.Drawing.Color.White;
            this.btnHoSo.Location = new System.Drawing.Point(0, 0);
            this.btnHoSo.Margin = new System.Windows.Forms.Padding(4);
            this.btnHoSo.Name = "btnHoSo";
            this.btnHoSo.Size = new System.Drawing.Size(240, 55);
            this.btnHoSo.TabIndex = 9;
            // 
            // btnThongBao
            // 
            this.btnThongBao.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnThongBao.ForeColor = System.Drawing.Color.White;
            this.btnThongBao.Location = new System.Drawing.Point(0, 0);
            this.btnThongBao.Margin = new System.Windows.Forms.Padding(4);
            this.btnThongBao.Name = "btnThongBao";
            this.btnThongBao.Size = new System.Drawing.Size(240, 55);
            this.btnThongBao.TabIndex = 10;
            // 
            // btnLogout
            // 
            this.btnLogout.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.btnLogout.BorderRadius = 6;
            this.btnLogout.BorderThickness = 1;
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.FillColor = System.Drawing.Color.Transparent;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.btnLogout.HoverState.FillColor = System.Drawing.Color.Maroon;
            this.btnLogout.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(13, 955);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(4);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(267, 52);
            this.btnLogout.TabIndex = 11;
            this.btnLogout.Text = "Đăng xuất";
            // 
            // pnlTopbar
            // 
            this.pnlTopbar.Controls.Add(this.lblPageTitle);
            this.pnlTopbar.Controls.Add(this.lblSubtitle);
            this.pnlTopbar.Controls.Add(this.btnExit);
            this.pnlTopbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopbar.FillColor = System.Drawing.Color.White;
            this.pnlTopbar.Location = new System.Drawing.Point(293, 0);
            this.pnlTopbar.Margin = new System.Windows.Forms.Padding(4);
            this.pnlTopbar.Name = "pnlTopbar";
            this.pnlTopbar.Size = new System.Drawing.Size(1507, 80);
            this.pnlTopbar.TabIndex = 1;
            // 
            // lblPageTitle
            // 
            this.lblPageTitle.AutoSize = true;
            this.lblPageTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblPageTitle.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold);
            this.lblPageTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(39)))), ((int)(((byte)(51)))));
            this.lblPageTitle.Location = new System.Drawing.Point(32, 5);
            this.lblPageTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPageTitle.Name = "lblPageTitle";
            this.lblPageTitle.Size = new System.Drawing.Size(153, 40);
            this.lblPageTitle.TabIndex = 0;
            this.lblPageTitle.Text = "Trang chủ";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.BackColor = System.Drawing.Color.Transparent;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(152)))), ((int)(((byte)(170)))));
            this.lblSubtitle.Location = new System.Drawing.Point(35, 52);
            this.lblSubtitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(354, 20);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Xin chào, bạn có 7 dịch vụ được phân công hôm nay";
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.FillColor = System.Drawing.Color.Transparent;
            this.btnExit.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.btnExit.Location = new System.Drawing.Point(1437, 20);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(45, 37);
            this.btnExit.TabIndex = 2;
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(293, 80);
            this.pnlContent.Margin = new System.Windows.Forms.Padding(4);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1507, 966);
            this.pnlContent.TabIndex = 0;
            // 
            // ptbChuThap
            // 
            this.ptbChuThap.BackColor = System.Drawing.Color.Transparent;
            this.ptbChuThap.FillColor = System.Drawing.Color.Transparent;
            this.ptbChuThap.Image = ((System.Drawing.Image)(resources.GetObject("ptbChuThap.Image")));
            this.ptbChuThap.ImageRotate = 0F;
            this.ptbChuThap.Location = new System.Drawing.Point(13, 12);
            this.ptbChuThap.Margin = new System.Windows.Forms.Padding(4);
            this.ptbChuThap.Name = "ptbChuThap";
            this.ptbChuThap.Size = new System.Drawing.Size(35, 33);
            this.ptbChuThap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbChuThap.TabIndex = 1;
            this.ptbChuThap.TabStop = false;
            this.ptbChuThap.UseTransparentBackground = true;
            // 
            // ptbAdmin
            // 
            this.ptbAdmin.BackColor = System.Drawing.Color.Transparent;
            this.ptbAdmin.FillColor = System.Drawing.Color.Transparent;
            this.ptbAdmin.Image = ((System.Drawing.Image)(resources.GetObject("ptbAdmin.Image")));
            this.ptbAdmin.ImageRotate = 0F;
            this.ptbAdmin.Location = new System.Drawing.Point(0, 0);
            this.ptbAdmin.Margin = new System.Windows.Forms.Padding(4);
            this.ptbAdmin.MinimumSize = new System.Drawing.Size(48, 44);
            this.ptbAdmin.Name = "ptbAdmin";
            this.ptbAdmin.Size = new System.Drawing.Size(48, 44);
            this.ptbAdmin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbAdmin.TabIndex = 9;
            this.ptbAdmin.TabStop = false;
            this.ptbAdmin.UseTransparentBackground = true;
            // 
            // Main_KTV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1800, 1046);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlTopbar);
            this.Controls.Add(this.pnlSidebar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Main_KTV";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kỹ thuật viên";
            this.pnlSidebar.ResumeLayout(false);
            this.pnlSidebar.PerformLayout();
            this.pnlLogo.ResumeLayout(false);
            this.pnlAvatar.ResumeLayout(false);
            this.pnlTopbar.ResumeLayout(false);
            this.pnlTopbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbChuThap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbAdmin)).EndInit();
            this.ResumeLayout(false);

        }

        private Guna2PictureBox ptbChuThap;
        private Guna2PictureBox ptbAdmin;
    }
}
