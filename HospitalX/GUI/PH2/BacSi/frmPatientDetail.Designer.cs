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
            this.lblCccdValue = new System.Windows.Forms.Label();
            this.lblCccdTitle = new System.Windows.Forms.Label();
            this.lblHometownValue = new System.Windows.Forms.Label();
            this.lblHometownTitle = new System.Windows.Forms.Label();
            this.lblRxCountValue = new System.Windows.Forms.Label();
            this.lblRxCountTitle = new System.Windows.Forms.Label();
            this.lblHsbaCountValue = new System.Windows.Forms.Label();
            this.lblHsbaCountTitle = new System.Windows.Forms.Label();
            this.lblAgeValue = new System.Windows.Forms.Label();
            this.lblAgeTitle = new System.Windows.Forms.Label();
            this.lblGenderValue = new System.Windows.Forms.Label();
            this.lblGenderTitle = new System.Windows.Forms.Label();
            this.lblPatientCodeValue = new System.Windows.Forms.Label();
            this.lblPatientCodeTitle = new System.Windows.Forms.Label();
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
            this.pnlHeader.Location = new System.Drawing.Point(24, 20);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1226, 135);
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
            this.btnClose.Location = new System.Drawing.Point(1177, 9);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(36, 32);
            this.btnClose.TabIndex = 5;
            // 
            // lblCode
            // 
            this.lblCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(244)))), ((int)(((byte)(240)))));
            this.lblCode.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold);
            this.lblCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.lblCode.Location = new System.Drawing.Point(1037, 77);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(160, 34);
            this.lblCode.TabIndex = 2;
            this.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.White;
            this.lblName.Location = new System.Drawing.Point(21, 64);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(182, 32);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Tên bệnh nhân";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(79)))), ((int)(((byte)(61)))));
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(244)))), ((int)(((byte)(240)))));
            this.lblTitle.Location = new System.Drawing.Point(24, 24);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(139, 17);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Thông tin bệnh nhân";
            // 
            // pnlInfo
            // 
            this.pnlInfo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.pnlInfo.BorderRadius = 12;
            this.pnlInfo.BorderThickness = 1;
            this.pnlInfo.Controls.Add(this.lblCccdValue);
            this.pnlInfo.Controls.Add(this.lblCccdTitle);
            this.pnlInfo.Controls.Add(this.lblHometownValue);
            this.pnlInfo.Controls.Add(this.lblHometownTitle);
            this.pnlInfo.Controls.Add(this.lblRxCountValue);
            this.pnlInfo.Controls.Add(this.lblRxCountTitle);
            this.pnlInfo.Controls.Add(this.lblHsbaCountValue);
            this.pnlInfo.Controls.Add(this.lblHsbaCountTitle);
            this.pnlInfo.Controls.Add(this.lblAgeValue);
            this.pnlInfo.Controls.Add(this.lblAgeTitle);
            this.pnlInfo.Controls.Add(this.lblGenderValue);
            this.pnlInfo.Controls.Add(this.lblGenderTitle);
            this.pnlInfo.Controls.Add(this.lblPatientCodeValue);
            this.pnlInfo.Controls.Add(this.lblPatientCodeTitle);
            this.pnlInfo.Controls.Add(this.lblInfoTitle);
            this.pnlInfo.FillColor = System.Drawing.Color.White;
            this.pnlInfo.Location = new System.Drawing.Point(28, 174);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(430, 628);
            this.pnlInfo.TabIndex = 1;
            // 
            // lblCccdValue
            // 
            this.lblCccdValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(248)))));
            this.lblCccdValue.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Bold);
            this.lblCccdValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.lblCccdValue.Location = new System.Drawing.Point(34, 534);
            this.lblCccdValue.Name = "lblCccdValue";
            this.lblCccdValue.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblCccdValue.Size = new System.Drawing.Size(354, 38);
            this.lblCccdValue.TabIndex = 14;
            this.lblCccdValue.Text = "079074012345";
            this.lblCccdValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCccdTitle
            // 
            this.lblCccdTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblCccdTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblCccdTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblCccdTitle.Location = new System.Drawing.Point(34, 510);
            this.lblCccdTitle.Name = "lblCccdTitle";
            this.lblCccdTitle.Size = new System.Drawing.Size(170, 18);
            this.lblCccdTitle.TabIndex = 13;
            this.lblCccdTitle.Text = "CCCD";
            // 
            // lblHometownValue
            // 
            this.lblHometownValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(248)))));
            this.lblHometownValue.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblHometownValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(42)))));
            this.lblHometownValue.Location = new System.Drawing.Point(33, 431);
            this.lblHometownValue.Name = "lblHometownValue";
            this.lblHometownValue.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblHometownValue.Size = new System.Drawing.Size(354, 38);
            this.lblHometownValue.TabIndex = 12;
            this.lblHometownValue.Text = "TP.HCM";
            this.lblHometownValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblHometownTitle
            // 
            this.lblHometownTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblHometownTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblHometownTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblHometownTitle.Location = new System.Drawing.Point(33, 407);
            this.lblHometownTitle.Name = "lblHometownTitle";
            this.lblHometownTitle.Size = new System.Drawing.Size(170, 18);
            this.lblHometownTitle.TabIndex = 11;
            this.lblHometownTitle.Text = "QUÊ QUÁN";
            // 
            // lblRxCountValue
            // 
            this.lblRxCountValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(248)))));
            this.lblRxCountValue.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblRxCountValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(42)))));
            this.lblRxCountValue.Location = new System.Drawing.Point(237, 335);
            this.lblRxCountValue.Name = "lblRxCountValue";
            this.lblRxCountValue.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblRxCountValue.Size = new System.Drawing.Size(150, 38);
            this.lblRxCountValue.TabIndex = 10;
            this.lblRxCountValue.Text = "2";
            this.lblRxCountValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRxCountTitle
            // 
            this.lblRxCountTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblRxCountTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblRxCountTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblRxCountTitle.Location = new System.Drawing.Point(237, 311);
            this.lblRxCountTitle.Name = "lblRxCountTitle";
            this.lblRxCountTitle.Size = new System.Drawing.Size(170, 18);
            this.lblRxCountTitle.TabIndex = 9;
            this.lblRxCountTitle.Text = "SỐ ĐƠN THUỐC";
            // 
            // lblHsbaCountValue
            // 
            this.lblHsbaCountValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(248)))));
            this.lblHsbaCountValue.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblHsbaCountValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(42)))));
            this.lblHsbaCountValue.Location = new System.Drawing.Point(33, 335);
            this.lblHsbaCountValue.Name = "lblHsbaCountValue";
            this.lblHsbaCountValue.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblHsbaCountValue.Size = new System.Drawing.Size(150, 38);
            this.lblHsbaCountValue.TabIndex = 8;
            this.lblHsbaCountValue.Text = "3";
            this.lblHsbaCountValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblHsbaCountTitle
            // 
            this.lblHsbaCountTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblHsbaCountTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblHsbaCountTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblHsbaCountTitle.Location = new System.Drawing.Point(33, 311);
            this.lblHsbaCountTitle.Name = "lblHsbaCountTitle";
            this.lblHsbaCountTitle.Size = new System.Drawing.Size(170, 18);
            this.lblHsbaCountTitle.TabIndex = 7;
            this.lblHsbaCountTitle.Text = "SỐ HSBA";
            // 
            // lblAgeValue
            // 
            this.lblAgeValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(248)))));
            this.lblAgeValue.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblAgeValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(42)))));
            this.lblAgeValue.Location = new System.Drawing.Point(237, 235);
            this.lblAgeValue.Name = "lblAgeValue";
            this.lblAgeValue.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblAgeValue.Size = new System.Drawing.Size(150, 38);
            this.lblAgeValue.TabIndex = 6;
            this.lblAgeValue.Text = "52 tuổi";
            this.lblAgeValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAgeTitle
            // 
            this.lblAgeTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblAgeTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblAgeTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblAgeTitle.Location = new System.Drawing.Point(237, 211);
            this.lblAgeTitle.Name = "lblAgeTitle";
            this.lblAgeTitle.Size = new System.Drawing.Size(170, 18);
            this.lblAgeTitle.TabIndex = 5;
            this.lblAgeTitle.Text = "TUỔI";
            // 
            // lblGenderValue
            // 
            this.lblGenderValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(248)))));
            this.lblGenderValue.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblGenderValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(42)))));
            this.lblGenderValue.Location = new System.Drawing.Point(33, 235);
            this.lblGenderValue.Name = "lblGenderValue";
            this.lblGenderValue.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblGenderValue.Size = new System.Drawing.Size(150, 38);
            this.lblGenderValue.TabIndex = 4;
            this.lblGenderValue.Text = "Nam";
            this.lblGenderValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblGenderTitle
            // 
            this.lblGenderTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblGenderTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblGenderTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblGenderTitle.Location = new System.Drawing.Point(33, 211);
            this.lblGenderTitle.Name = "lblGenderTitle";
            this.lblGenderTitle.Size = new System.Drawing.Size(170, 18);
            this.lblGenderTitle.TabIndex = 3;
            this.lblGenderTitle.Text = "GIỚI TÍNH";
            // 
            // lblPatientCodeValue
            // 
            this.lblPatientCodeValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(248)))));
            this.lblPatientCodeValue.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Bold);
            this.lblPatientCodeValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.lblPatientCodeValue.Location = new System.Drawing.Point(34, 128);
            this.lblPatientCodeValue.Name = "lblPatientCodeValue";
            this.lblPatientCodeValue.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblPatientCodeValue.Size = new System.Drawing.Size(354, 38);
            this.lblPatientCodeValue.TabIndex = 2;
            this.lblPatientCodeValue.Text = "BN-00341";
            this.lblPatientCodeValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPatientCodeTitle
            // 
            this.lblPatientCodeTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblPatientCodeTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblPatientCodeTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblPatientCodeTitle.Location = new System.Drawing.Point(34, 104);
            this.lblPatientCodeTitle.Name = "lblPatientCodeTitle";
            this.lblPatientCodeTitle.Size = new System.Drawing.Size(170, 18);
            this.lblPatientCodeTitle.TabIndex = 1;
            this.lblPatientCodeTitle.Text = "MÃ BỆNH NHÂN";
            // 
            // lblInfoTitle
            // 
            this.lblInfoTitle.AutoSize = true;
            this.lblInfoTitle.BackColor = System.Drawing.Color.Transparent;
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
            this.flpHsba.BackColor = System.Drawing.Color.White;
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
            this.lblHsbaTitle.BackColor = System.Drawing.Color.Transparent;
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
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblTitle;
        private Guna.UI2.WinForms.Guna2Panel pnlInfo;
        private System.Windows.Forms.Label lblCccdValue;
        private System.Windows.Forms.Label lblCccdTitle;
        private System.Windows.Forms.Label lblHometownValue;
        private System.Windows.Forms.Label lblHometownTitle;
        private System.Windows.Forms.Label lblRxCountValue;
        private System.Windows.Forms.Label lblRxCountTitle;
        private System.Windows.Forms.Label lblHsbaCountValue;
        private System.Windows.Forms.Label lblHsbaCountTitle;
        private System.Windows.Forms.Label lblAgeValue;
        private System.Windows.Forms.Label lblAgeTitle;
        private System.Windows.Forms.Label lblGenderValue;
        private System.Windows.Forms.Label lblGenderTitle;
        private System.Windows.Forms.Label lblPatientCodeValue;
        private System.Windows.Forms.Label lblPatientCodeTitle;
        private System.Windows.Forms.Label lblInfoTitle;
        private Guna.UI2.WinForms.Guna2Panel pnlHsba;
        private System.Windows.Forms.FlowLayoutPanel flpHsba;
        private System.Windows.Forms.Label lblHsbaTitle;
        private Guna.UI2.WinForms.Guna2ControlBox btnClose;
    }
}
