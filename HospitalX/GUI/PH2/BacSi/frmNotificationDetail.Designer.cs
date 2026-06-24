namespace HospitalX.GUI.PH2.BacSi
{
    partial class frmNotificationDetail
    {
        private System.ComponentModel.IContainer components = null;

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
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.pnlHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.btnClose = new Guna.UI2.WinForms.Guna2ControlBox();
            this.lblSender = new System.Windows.Forms.Label();
            this.lblLevel = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlBody = new Guna.UI2.WinForms.Guna2Panel();
            this.btnMarkRead = new Guna.UI2.WinForms.Guna2Button();
            this.txtContent = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblContentTitle = new System.Windows.Forms.Label();
            this.lblLocationValue = new System.Windows.Forms.Label();
            this.lblLocationTitle = new System.Windows.Forms.Label();
            this.lblTimeValue = new System.Windows.Forms.Label();
            this.lblTimeTitle = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.BorderRadius = 14;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BorderRadius = 12;
            this.pnlHeader.Controls.Add(this.btnClose);
            this.pnlHeader.Controls.Add(this.lblSender);
            this.pnlHeader.Controls.Add(this.lblLevel);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(79)))), ((int)(((byte)(61)))));
            this.pnlHeader.Location = new System.Drawing.Point(18, 16);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(844, 140);
            this.pnlHeader.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BorderRadius = 8;
            this.btnClose.FillColor = System.Drawing.Color.Transparent;
            this.btnClose.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(79)))), ((int)(((byte)(61)))));
            this.btnClose.IconColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(796, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(34, 30);
            this.btnClose.TabIndex = 3;
            // 
            // lblSender
            // 
            this.lblSender.BackColor = System.Drawing.Color.Transparent;
            this.lblSender.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblSender.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(244)))), ((int)(((byte)(240)))));
            this.lblSender.Location = new System.Drawing.Point(30, 92);
            this.lblSender.Name = "lblSender";
            this.lblSender.Size = new System.Drawing.Size(620, 24);
            this.lblSender.TabIndex = 2;
            this.lblSender.Text = "Người gửi";
            // 
            // lblLevel
            // 
            this.lblLevel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(244)))), ((int)(((byte)(240)))));
            this.lblLevel.Font = new System.Drawing.Font("Segoe UI", 8.8F, System.Drawing.FontStyle.Bold);
            this.lblLevel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.lblLevel.Location = new System.Drawing.Point(30, 17);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(120, 26);
            this.lblLevel.TabIndex = 0;
            this.lblLevel.Text = "KHOA";
            this.lblLevel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(28, 52);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(680, 44);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Chi tiết thông báo";
            // 
            // pnlBody
            // 
            this.pnlBody.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.pnlBody.BorderRadius = 12;
            this.pnlBody.BorderThickness = 1;
            this.pnlBody.Controls.Add(this.btnMarkRead);
            this.pnlBody.Controls.Add(this.txtContent);
            this.pnlBody.Controls.Add(this.lblContentTitle);
            this.pnlBody.Controls.Add(this.lblLocationValue);
            this.pnlBody.Controls.Add(this.lblLocationTitle);
            this.pnlBody.Controls.Add(this.lblTimeValue);
            this.pnlBody.Controls.Add(this.lblTimeTitle);
            this.pnlBody.FillColor = System.Drawing.Color.White;
            this.pnlBody.Location = new System.Drawing.Point(18, 174);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(844, 483);
            this.pnlBody.TabIndex = 1;
            // 
            // btnMarkRead
            // 
            this.btnMarkRead.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMarkRead.BackColor = System.Drawing.Color.Transparent;
            this.btnMarkRead.BorderRadius = 8;
            this.btnMarkRead.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMarkRead.DefaultAutoSize = true;
            this.btnMarkRead.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.btnMarkRead.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMarkRead.ForeColor = System.Drawing.Color.White;
            this.btnMarkRead.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(148)))), ((int)(((byte)(112)))));
            this.btnMarkRead.Location = new System.Drawing.Point(318, 421);
            this.btnMarkRead.Name = "btnMarkRead";
            this.btnMarkRead.Size = new System.Drawing.Size(154, 31);
            this.btnMarkRead.TabIndex = 6;
            this.btnMarkRead.Text = "Đánh dấu đã đọc";
            this.btnMarkRead.Click += new System.EventHandler(this.btnMarkRead_Click);
            // 
            // txtContent
            // 
            this.txtContent.BackColor = System.Drawing.Color.Transparent;
            this.txtContent.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.txtContent.BorderRadius = 8;
            this.txtContent.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtContent.DefaultText = "";
            this.txtContent.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(248)))));
            this.txtContent.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtContent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(42)))));
            this.txtContent.Location = new System.Drawing.Point(34, 205);
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.PlaceholderText = "";
            this.txtContent.ReadOnly = true;
            this.txtContent.SelectedText = "";
            this.txtContent.Size = new System.Drawing.Size(755, 190);
            this.txtContent.TabIndex = 5;
            // 
            // lblContentTitle
            // 
            this.lblContentTitle.AutoSize = true;
            this.lblContentTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblContentTitle.Font = new System.Drawing.Font("Segoe UI", 8.7F, System.Drawing.FontStyle.Bold);
            this.lblContentTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblContentTitle.Location = new System.Drawing.Point(34, 171);
            this.lblContentTitle.Name = "lblContentTitle";
            this.lblContentTitle.Size = new System.Drawing.Size(142, 15);
            this.lblContentTitle.TabIndex = 4;
            this.lblContentTitle.Text = "NỘI DUNG THÔNG BÁO";
            // 
            // lblLocationValue
            // 
            this.lblLocationValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(248)))));
            this.lblLocationValue.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblLocationValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(42)))));
            this.lblLocationValue.Location = new System.Drawing.Point(291, 73);
            this.lblLocationValue.Name = "lblLocationValue";
            this.lblLocationValue.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblLocationValue.Size = new System.Drawing.Size(450, 38);
            this.lblLocationValue.TabIndex = 3;
            this.lblLocationValue.Text = "Địa điểm";
            this.lblLocationValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLocationTitle
            // 
            this.lblLocationTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblLocationTitle.Font = new System.Drawing.Font("Segoe UI", 8.7F, System.Drawing.FontStyle.Bold);
            this.lblLocationTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblLocationTitle.Location = new System.Drawing.Point(292, 36);
            this.lblLocationTitle.Name = "lblLocationTitle";
            this.lblLocationTitle.Size = new System.Drawing.Size(180, 20);
            this.lblLocationTitle.TabIndex = 2;
            this.lblLocationTitle.Text = "ĐỊA ĐIỂM";
            // 
            // lblTimeValue
            // 
            this.lblTimeValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(248)))));
            this.lblTimeValue.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTimeValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(42)))));
            this.lblTimeValue.Location = new System.Drawing.Point(33, 73);
            this.lblTimeValue.Name = "lblTimeValue";
            this.lblTimeValue.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblTimeValue.Size = new System.Drawing.Size(220, 38);
            this.lblTimeValue.TabIndex = 1;
            this.lblTimeValue.Text = "08:00 · 21/05/2026";
            this.lblTimeValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTimeTitle
            // 
            this.lblTimeTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTimeTitle.Font = new System.Drawing.Font("Segoe UI", 8.7F, System.Drawing.FontStyle.Bold);
            this.lblTimeTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblTimeTitle.Location = new System.Drawing.Point(34, 36);
            this.lblTimeTitle.Name = "lblTimeTitle";
            this.lblTimeTitle.Size = new System.Drawing.Size(180, 20);
            this.lblTimeTitle.TabIndex = 0;
            this.lblTimeTitle.Text = "THỜI GIAN";
            // 
            // frmNotificationDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(245)))), ((int)(((byte)(243)))));
            this.ClientSize = new System.Drawing.Size(889, 683);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmNotificationDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chi tiết thông báo";
            this.pnlHeader.ResumeLayout(false);
            this.pnlBody.ResumeLayout(false);
            this.pnlBody.PerformLayout();
            this.ResumeLayout(false);

        }

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2Panel pnlHeader;
        private Guna.UI2.WinForms.Guna2ControlBox btnClose;
        private System.Windows.Forms.Label lblSender;
        private System.Windows.Forms.Label lblLevel;
        private System.Windows.Forms.Label lblTitle;
        private Guna.UI2.WinForms.Guna2Panel pnlBody;
        private Guna.UI2.WinForms.Guna2Button btnMarkRead;
        private Guna.UI2.WinForms.Guna2TextBox txtContent;
        private System.Windows.Forms.Label lblContentTitle;
        private System.Windows.Forms.Label lblLocationValue;
        private System.Windows.Forms.Label lblLocationTitle;
        private System.Windows.Forms.Label lblTimeValue;
        private System.Windows.Forms.Label lblTimeTitle;
    }
}
