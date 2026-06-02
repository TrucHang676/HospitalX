namespace HospitalX.GUI.PH2.KyThuatVien
{
    partial class frmKtvNotificationDetail
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKtvNotificationDetail));
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.pnlHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnCloseX = new Guna.UI2.WinForms.Guna2Button();
            this.divHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.lblNotifTitle = new System.Windows.Forms.Label();
            this.txtNotifTitle = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblNotifType = new System.Windows.Forms.Label();
            this.txtNotifType = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblNotifTime = new System.Windows.Forms.Label();
            this.txtNotifTime = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblNotifTags = new System.Windows.Forms.Label();
            this.txtNotifTags = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblNotifBody = new System.Windows.Forms.Label();
            this.txtNotifBody = new Guna.UI2.WinForms.Guna2TextBox();
            this.divFooter = new Guna.UI2.WinForms.Guna2Panel();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.BorderRadius = 16;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.btnCloseX);
            this.pnlHeader.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(82)))), ((int)(((byte)(64)))));
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(560, 56);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 16);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(400, 24);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "🔔 Chi tiết thông báo nghiệp vụ";
            // 
            // btnCloseX
            // 
            this.btnCloseX.BackColor = System.Drawing.Color.Transparent;
            this.btnCloseX.BorderColor = System.Drawing.Color.Transparent;
            this.btnCloseX.BorderRadius = 8;
            this.btnCloseX.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCloseX.FillColor = System.Drawing.Color.Transparent;
            this.btnCloseX.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCloseX.ForeColor = System.Drawing.Color.White;
            this.btnCloseX.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(79)))), ((int)(((byte)(61)))));
            this.btnCloseX.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnCloseX.Location = new System.Drawing.Point(512, 12);
            this.btnCloseX.Name = "btnCloseX";
            this.btnCloseX.Size = new System.Drawing.Size(36, 32);
            this.btnCloseX.TabIndex = 1;
            this.btnCloseX.Text = "✕";
            this.btnCloseX.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // divHeader
            // 
            this.divHeader.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.divHeader.Location = new System.Drawing.Point(0, 56);
            this.divHeader.Name = "divHeader";
            this.divHeader.Size = new System.Drawing.Size(560, 1);
            this.divHeader.TabIndex = 1;
            // 
            // lblNotifTitle
            // 
            this.lblNotifTitle.AutoSize = true;
            this.lblNotifTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblNotifTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblNotifTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(98)))), ((int)(((byte)(89)))));
            this.lblNotifTitle.Location = new System.Drawing.Point(24, 76);
            this.lblNotifTitle.Name = "lblNotifTitle";
            this.lblNotifTitle.Size = new System.Drawing.Size(136, 20);
            this.lblNotifTitle.TabIndex = 2;
            this.lblNotifTitle.Text = "Tiêu đề thông báo";
            // 
            // txtNotifTitle
            // 
            this.txtNotifTitle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.txtNotifTitle.BorderRadius = 8;
            this.txtNotifTitle.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNotifTitle.DefaultText = "";
            this.txtNotifTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNotifTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(39)))), ((int)(((byte)(51)))));
            this.txtNotifTitle.Location = new System.Drawing.Point(24, 96);
            this.txtNotifTitle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNotifTitle.Name = "txtNotifTitle";
            this.txtNotifTitle.PlaceholderText = "";
            this.txtNotifTitle.ReadOnly = true;
            this.txtNotifTitle.SelectedText = "";
            this.txtNotifTitle.Size = new System.Drawing.Size(512, 36);
            this.txtNotifTitle.TabIndex = 3;
            // 
            // lblNotifType
            // 
            this.lblNotifType.AutoSize = true;
            this.lblNotifType.BackColor = System.Drawing.Color.Transparent;
            this.lblNotifType.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblNotifType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(98)))), ((int)(((byte)(89)))));
            this.lblNotifType.Location = new System.Drawing.Point(24, 148);
            this.lblNotifType.Name = "lblNotifType";
            this.lblNotifType.Size = new System.Drawing.Size(73, 20);
            this.lblNotifType.TabIndex = 4;
            this.lblNotifType.Text = "Phân loại";
            // 
            // txtNotifType
            // 
            this.txtNotifType.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.txtNotifType.BorderRadius = 8;
            this.txtNotifType.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNotifType.DefaultText = "";
            this.txtNotifType.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNotifType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(39)))), ((int)(((byte)(51)))));
            this.txtNotifType.Location = new System.Drawing.Point(24, 168);
            this.txtNotifType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNotifType.Name = "txtNotifType";
            this.txtNotifType.PlaceholderText = "";
            this.txtNotifType.ReadOnly = true;
            this.txtNotifType.SelectedText = "";
            this.txtNotifType.Size = new System.Drawing.Size(244, 36);
            this.txtNotifType.TabIndex = 5;
            // 
            // lblNotifTime
            // 
            this.lblNotifTime.AutoSize = true;
            this.lblNotifTime.BackColor = System.Drawing.Color.Transparent;
            this.lblNotifTime.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblNotifTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(98)))), ((int)(((byte)(89)))));
            this.lblNotifTime.Location = new System.Drawing.Point(284, 148);
            this.lblNotifTime.Name = "lblNotifTime";
            this.lblNotifTime.Size = new System.Drawing.Size(113, 20);
            this.lblNotifTime.TabIndex = 6;
            this.lblNotifTime.Text = "Thời gian nhận";
            // 
            // txtNotifTime
            // 
            this.txtNotifTime.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.txtNotifTime.BorderRadius = 8;
            this.txtNotifTime.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNotifTime.DefaultText = "";
            this.txtNotifTime.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNotifTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(39)))), ((int)(((byte)(51)))));
            this.txtNotifTime.Location = new System.Drawing.Point(284, 168);
            this.txtNotifTime.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNotifTime.Name = "txtNotifTime";
            this.txtNotifTime.PlaceholderText = "";
            this.txtNotifTime.ReadOnly = true;
            this.txtNotifTime.SelectedText = "";
            this.txtNotifTime.Size = new System.Drawing.Size(252, 36);
            this.txtNotifTime.TabIndex = 7;
            // 
            // lblNotifTags
            // 
            this.lblNotifTags.AutoSize = true;
            this.lblNotifTags.BackColor = System.Drawing.Color.Transparent;
            this.lblNotifTags.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblNotifTags.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(98)))), ((int)(((byte)(89)))));
            this.lblNotifTags.Location = new System.Drawing.Point(24, 220);
            this.lblNotifTags.Name = "lblNotifTags";
            this.lblNotifTags.Size = new System.Drawing.Size(99, 20);
            this.lblNotifTags.TabIndex = 8;
            this.lblNotifTags.Text = "Thẻ gắn kèm";
            // 
            // txtNotifTags
            // 
            this.txtNotifTags.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.txtNotifTags.BorderRadius = 8;
            this.txtNotifTags.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNotifTags.DefaultText = "";
            this.txtNotifTags.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNotifTags.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(39)))), ((int)(((byte)(51)))));
            this.txtNotifTags.Location = new System.Drawing.Point(24, 240);
            this.txtNotifTags.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNotifTags.Name = "txtNotifTags";
            this.txtNotifTags.PlaceholderText = "";
            this.txtNotifTags.ReadOnly = true;
            this.txtNotifTags.SelectedText = "";
            this.txtNotifTags.Size = new System.Drawing.Size(512, 36);
            this.txtNotifTags.TabIndex = 9;
            // 
            // lblNotifBody
            // 
            this.lblNotifBody.AutoSize = true;
            this.lblNotifBody.BackColor = System.Drawing.Color.Transparent;
            this.lblNotifBody.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblNotifBody.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(98)))), ((int)(((byte)(89)))));
            this.lblNotifBody.Location = new System.Drawing.Point(24, 292);
            this.lblNotifBody.Name = "lblNotifBody";
            this.lblNotifBody.Size = new System.Drawing.Size(126, 20);
            this.lblNotifBody.TabIndex = 10;
            this.lblNotifBody.Text = "Nội dung chi tiết";
            // 
            // txtNotifBody
            // 
            this.txtNotifBody.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.txtNotifBody.BorderRadius = 8;
            this.txtNotifBody.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNotifBody.DefaultText = "";
            this.txtNotifBody.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNotifBody.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(39)))), ((int)(((byte)(51)))));
            this.txtNotifBody.Location = new System.Drawing.Point(24, 312);
            this.txtNotifBody.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNotifBody.Multiline = true;
            this.txtNotifBody.Name = "txtNotifBody";
            this.txtNotifBody.PlaceholderText = "";
            this.txtNotifBody.ReadOnly = true;
            this.txtNotifBody.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNotifBody.SelectedText = "";
            this.txtNotifBody.Size = new System.Drawing.Size(512, 90);
            this.txtNotifBody.TabIndex = 11;
            // 
            // divFooter
            // 
            this.divFooter.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.divFooter.Location = new System.Drawing.Point(0, 418);
            this.divFooter.Name = "divFooter";
            this.divFooter.Size = new System.Drawing.Size(560, 1);
            this.divFooter.TabIndex = 12;
            // 
            // btnCancel
            // 
            this.btnCancel.BorderRadius = 8;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(82)))), ((int)(((byte)(64)))));
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.btnCancel.Location = new System.Drawing.Point(420, 430);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.btnCancel.Size = new System.Drawing.Size(116, 38);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Đóng";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmKtvNotificationDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(246)))));
            this.ClientSize = new System.Drawing.Size(560, 484);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.divHeader);
            this.Controls.Add(this.lblNotifTitle);
            this.Controls.Add(this.txtNotifTitle);
            this.Controls.Add(this.lblNotifType);
            this.Controls.Add(this.txtNotifType);
            this.Controls.Add(this.lblNotifTime);
            this.Controls.Add(this.txtNotifTime);
            this.Controls.Add(this.lblNotifTags);
            this.Controls.Add(this.txtNotifTags);
            this.Controls.Add(this.lblNotifBody);
            this.Controls.Add(this.txtNotifBody);
            this.Controls.Add(this.divFooter);
            this.Controls.Add(this.btnCancel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmKtvNotificationDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chi tiết thông báo";
            this.pnlHeader.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        // ── Field declarations ────────────────────────────────────
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private Guna.UI2.WinForms.Guna2Button btnCloseX;
        private Guna.UI2.WinForms.Guna2Panel divHeader;

        private System.Windows.Forms.Label lblNotifTitle;
        private Guna.UI2.WinForms.Guna2TextBox txtNotifTitle;

        private System.Windows.Forms.Label lblNotifType;
        private Guna.UI2.WinForms.Guna2TextBox txtNotifType;
        private System.Windows.Forms.Label lblNotifTime;
        private Guna.UI2.WinForms.Guna2TextBox txtNotifTime;

        private System.Windows.Forms.Label lblNotifTags;
        private Guna.UI2.WinForms.Guna2TextBox txtNotifTags;

        private System.Windows.Forms.Label lblNotifBody;
        private Guna.UI2.WinForms.Guna2TextBox txtNotifBody;

        private Guna.UI2.WinForms.Guna2Panel divFooter;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
    }
}
