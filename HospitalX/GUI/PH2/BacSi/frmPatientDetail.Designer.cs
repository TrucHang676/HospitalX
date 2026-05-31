namespace HospitalX.GUI.PH2.BacSi
{
    partial class frmPatientDetail
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
            this.lblCode = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlInfo = new Guna.UI2.WinForms.Guna2Panel();
            this.lblInfoTitle = new System.Windows.Forms.Label();
            this.pnlHsba = new Guna.UI2.WinForms.Guna2Panel();
            this.flpHsba = new System.Windows.Forms.FlowLayoutPanel();
            this.lblHsbaTitle = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlInfo.SuspendLayout();
            this.pnlHsba.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.BorderRadius = 12;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BorderRadius = 12;
            this.pnlHeader.Controls.Add(this.btnClose);
            this.pnlHeader.Controls.Add(this.lblCode);
            this.pnlHeader.Controls.Add(this.lblName);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(79)))), ((int)(((byte)(61)))));
            this.pnlHeader.Location = new System.Drawing.Point(28, 24);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1221, 128);
            this.pnlHeader.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(148)))), ((int)(((byte)(112)))));
            this.btnClose.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(79)))), ((int)(((byte)(61)))));
            this.btnClose.IconColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(1158, 30);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(34, 34);
            this.btnClose.TabIndex = 3;
            // 
            // lblCode
            // 
            this.lblCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(244)))), ((int)(((byte)(240)))));
            this.lblCode.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold);
            this.lblCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.lblCode.Location = new System.Drawing.Point(966, 52);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(160, 34);
            this.lblCode.TabIndex = 2;
            this.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblName.ForeColor = System.Drawing.Color.White;
            this.lblName.Location = new System.Drawing.Point(32, 58);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(0, 41);
            this.lblName.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(34, 26);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(191, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Thông tin bệnh nhân";
            // 
            // pnlInfo
            // 
            this.pnlInfo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.pnlInfo.BorderRadius = 12;
            this.pnlInfo.BorderThickness = 1;
            this.pnlInfo.Controls.Add(this.lblInfoTitle);
            this.pnlInfo.FillColor = System.Drawing.Color.White;
            this.pnlInfo.Location = new System.Drawing.Point(28, 174);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(430, 628);
            this.pnlInfo.TabIndex = 1;
            // 
            // lblInfoTitle
            // 
            this.lblInfoTitle.AutoSize = true;
            this.lblInfoTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblInfoTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(42)))));
            this.lblInfoTitle.Location = new System.Drawing.Point(32, 28);
            this.lblInfoTitle.Name = "lblInfoTitle";
            this.lblInfoTitle.Size = new System.Drawing.Size(174, 28);
            this.lblInfoTitle.TabIndex = 0;
            this.lblInfoTitle.Text = "Thông tin cơ bản";
            // 
            // pnlHsba
            // 
            this.pnlHsba.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.pnlHsba.BorderRadius = 12;
            this.pnlHsba.BorderThickness = 1;
            this.pnlHsba.Controls.Add(this.flpHsba);
            this.pnlHsba.Controls.Add(this.lblHsbaTitle);
            this.pnlHsba.FillColor = System.Drawing.Color.White;
            this.pnlHsba.Location = new System.Drawing.Point(484, 174);
            this.pnlHsba.Name = "pnlHsba";
            this.pnlHsba.Size = new System.Drawing.Size(765, 628);
            this.pnlHsba.TabIndex = 2;
            // 
            // flpHsba
            // 
            this.flpHsba.AutoScroll = true;
            this.flpHsba.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpHsba.Location = new System.Drawing.Point(32, 78);
            this.flpHsba.Name = "flpHsba";
            this.flpHsba.Size = new System.Drawing.Size(700, 510);
            this.flpHsba.TabIndex = 1;
            this.flpHsba.WrapContents = false;
            // 
            // lblHsbaTitle
            // 
            this.lblHsbaTitle.AutoSize = true;
            this.lblHsbaTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblHsbaTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(42)))));
            this.lblHsbaTitle.Location = new System.Drawing.Point(32, 28);
            this.lblHsbaTitle.Name = "lblHsbaTitle";
            this.lblHsbaTitle.Size = new System.Drawing.Size(243, 28);
            this.lblHsbaTitle.TabIndex = 0;
            this.lblHsbaTitle.Text = "Hồ sơ bệnh án liên quan";
            // 
            // frmPatientDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(245)))), ((int)(((byte)(243)))));
            this.ClientSize = new System.Drawing.Size(1277, 840);
            this.Controls.Add(this.pnlHsba);
            this.Controls.Add(this.pnlInfo);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPatientDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chi tiết bệnh nhân";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlInfo.ResumeLayout(false);
            this.pnlInfo.PerformLayout();
            this.pnlHsba.ResumeLayout(false);
            this.pnlHsba.PerformLayout();
            this.ResumeLayout(false);

        }

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2Panel pnlHeader;
        private Guna.UI2.WinForms.Guna2ControlBox btnClose;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblTitle;
        private Guna.UI2.WinForms.Guna2Panel pnlInfo;
        private System.Windows.Forms.Label lblInfoTitle;
        private Guna.UI2.WinForms.Guna2Panel pnlHsba;
        private System.Windows.Forms.FlowLayoutPanel flpHsba;
        private System.Windows.Forms.Label lblHsbaTitle;
    }
}
