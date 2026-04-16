namespace HospitalX.GUI
{
    partial class Splash
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Splash));
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.pnlLogo = new Guna.UI2.WinForms.Guna2Panel();
            this.ptbChuThap = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lblQTCSDL = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblVer = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblCSC = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.progressBar = new Guna.UI2.WinForms.Guna2ProgressBar();
            this.timerSplash = new System.Windows.Forms.Timer(this.components);
            this.lblStatus = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblPercent = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.lblHospital = new System.Windows.Forms.Label();
            this.pnlLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbChuThap)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.BorderRadius = 20;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.ShadowColor = System.Drawing.Color.CornflowerBlue;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // pnlLogo
            // 
            this.pnlLogo.BackColor = System.Drawing.Color.Transparent;
            this.pnlLogo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(180)))));
            this.pnlLogo.BorderRadius = 64;
            this.pnlLogo.BorderThickness = 1;
            this.pnlLogo.Controls.Add(this.ptbChuThap);
            this.pnlLogo.FillColor = System.Drawing.Color.White;
            this.pnlLogo.Location = new System.Drawing.Point(400, 74);
            this.pnlLogo.Margin = new System.Windows.Forms.Padding(4);
            this.pnlLogo.Name = "pnlLogo";
            this.pnlLogo.ShadowDecoration.BorderRadius = 50;
            this.pnlLogo.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(180)))));
            this.pnlLogo.ShadowDecoration.Depth = 8;
            this.pnlLogo.ShadowDecoration.Enabled = true;
            this.pnlLogo.Size = new System.Drawing.Size(133, 123);
            this.pnlLogo.TabIndex = 0;
            this.pnlLogo.UseTransparentBackground = true;
            // 
            // ptbChuThap
            // 
            this.ptbChuThap.BackColor = System.Drawing.Color.Transparent;
            this.ptbChuThap.FillColor = System.Drawing.Color.Transparent;
            this.ptbChuThap.Image = ((System.Drawing.Image)(resources.GetObject("ptbChuThap.Image")));
            this.ptbChuThap.ImageRotate = 0F;
            this.ptbChuThap.Location = new System.Drawing.Point(33, 34);
            this.ptbChuThap.Margin = new System.Windows.Forms.Padding(4);
            this.ptbChuThap.MinimumSize = new System.Drawing.Size(48, 44);
            this.ptbChuThap.Name = "ptbChuThap";
            this.ptbChuThap.Size = new System.Drawing.Size(71, 59);
            this.ptbChuThap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbChuThap.TabIndex = 1;
            this.ptbChuThap.TabStop = false;
            this.ptbChuThap.UseTransparentBackground = true;
            this.ptbChuThap.Click += new System.EventHandler(this.ptbChuThap_Click);
            // 
            // lblQTCSDL
            // 
            this.lblQTCSDL.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblQTCSDL.BackColor = System.Drawing.Color.Transparent;
            this.lblQTCSDL.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQTCSDL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.lblQTCSDL.Location = new System.Drawing.Point(278, 241);
            this.lblQTCSDL.Margin = new System.Windows.Forms.Padding(4);
            this.lblQTCSDL.Name = "lblQTCSDL";
            this.lblQTCSDL.Size = new System.Drawing.Size(374, 43);
            this.lblQTCSDL.TabIndex = 7;
            this.lblQTCSDL.Text = "Quản trị CSDL Bệnh viện X\r\n";
            this.lblQTCSDL.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblVer
            // 
            this.lblVer.BackColor = System.Drawing.Color.Transparent;
            this.lblVer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(218)))), ((int)(((byte)(232)))));
            this.lblVer.Location = new System.Drawing.Point(773, 521);
            this.lblVer.Margin = new System.Windows.Forms.Padding(4);
            this.lblVer.Name = "lblVer";
            this.lblVer.Size = new System.Drawing.Size(125, 22);
            this.lblVer.TabIndex = 8;
            this.lblVer.Text = "v1.0 · 2025–2026";
            this.lblVer.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCSC
            // 
            this.lblCSC.BackColor = System.Drawing.Color.Transparent;
            this.lblCSC.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCSC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(218)))), ((int)(((byte)(232)))));
            this.lblCSC.Location = new System.Drawing.Point(33, 521);
            this.lblCSC.Margin = new System.Windows.Forms.Padding(4);
            this.lblCSC.Name = "lblCSC";
            this.lblCSC.Size = new System.Drawing.Size(204, 22);
            this.lblCSC.TabIndex = 9;
            this.lblCSC.Text = "CSC12001 — KHTN · HCMUS";
            this.lblCSC.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // progressBar
            // 
            this.progressBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.progressBar.BorderRadius = 3;
            this.progressBar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(180)))));
            this.progressBar.Location = new System.Drawing.Point(263, 369);
            this.progressBar.Margin = new System.Windows.Forms.Padding(4);
            this.progressBar.Name = "progressBar";
            this.progressBar.ProgressColor = System.Drawing.Color.SkyBlue;
            this.progressBar.ProgressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(180)))));
            this.progressBar.Size = new System.Drawing.Size(400, 7);
            this.progressBar.TabIndex = 10;
            this.progressBar.Text = "guna2ProgressBar1";
            this.progressBar.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // timerSplash
            // 
            this.timerSplash.Interval = 20;
            this.timerSplash.Tick += new System.EventHandler(this.timerSplash_Tick);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = false;
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(168)))), ((int)(((byte)(190)))));
            this.lblStatus.Location = new System.Drawing.Point(330, 385);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(4);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(267, 21);
            this.lblStatus.TabIndex = 11;
            this.lblStatus.Text = "Khởi tạo kết nối Oracle...";
            this.lblStatus.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPercent
            // 
            this.lblPercent.BackColor = System.Drawing.Color.Transparent;
            this.lblPercent.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPercent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(180)))));
            this.lblPercent.Location = new System.Drawing.Point(637, 341);
            this.lblPercent.Margin = new System.Windows.Forms.Padding(4);
            this.lblPercent.Name = "lblPercent";
            this.lblPercent.Size = new System.Drawing.Size(25, 22);
            this.lblPercent.TabIndex = 12;
            this.lblPercent.Text = "0%";
            this.lblPercent.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.BorderRadius = 15;
            this.guna2ControlBox1.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.ForeColor = System.Drawing.Color.Black;
            this.guna2ControlBox1.HoverState.FillColor = System.Drawing.Color.LightBlue;
            this.guna2ControlBox1.IconColor = System.Drawing.Color.CornflowerBlue;
            this.guna2ControlBox1.Location = new System.Drawing.Point(875, 17);
            this.guna2ControlBox1.Margin = new System.Windows.Forms.Padding(4);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.Size = new System.Drawing.Size(37, 37);
            this.guna2ControlBox1.TabIndex = 13;
            // 
            // lblHospital
            // 
            this.lblHospital.AutoSize = true;
            this.lblHospital.BackColor = System.Drawing.Color.Transparent;
            this.lblHospital.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblHospital.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(180)))));
            this.lblHospital.Location = new System.Drawing.Point(326, 214);
            this.lblHospital.Name = "lblHospital";
            this.lblHospital.Size = new System.Drawing.Size(288, 23);
            this.lblHospital.TabIndex = 14;
            this.lblHospital.Text = "HOSPITAL MANAGEMENT SYSTEM";
            // 
            // Splash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(933, 566);
            this.Controls.Add(this.lblHospital);
            this.Controls.Add(this.guna2ControlBox1);
            this.Controls.Add(this.lblPercent);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.lblCSC);
            this.Controls.Add(this.lblVer);
            this.Controls.Add(this.lblQTCSDL);
            this.Controls.Add(this.pnlLogo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Splash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Splash";
            this.Load += new System.EventHandler(this.Splash_Load);
            this.pnlLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ptbChuThap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2Panel pnlLogo;
        private Guna.UI2.WinForms.Guna2PictureBox ptbChuThap;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblVer;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblQTCSDL;
        private Guna.UI2.WinForms.Guna2ProgressBar progressBar;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblCSC;
        private System.Windows.Forms.Timer timerSplash;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblPercent;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblStatus;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private System.Windows.Forms.Label lblHospital;
    }
}