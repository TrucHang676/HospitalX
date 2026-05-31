namespace HospitalX.GUI.PH2.BacSi
{
    partial class frmHSBAPrescription
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
            this.pnlMain = new Guna.UI2.WinForms.Guna2Panel();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.btnAdd = new Guna.UI2.WinForms.Guna2Button();
            this.txtDose = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtMedicineName = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblNewTitle = new System.Windows.Forms.Label();
            this.lstCurrentPrescriptions = new System.Windows.Forms.ListBox();
            this.lblCurrentTitle = new System.Windows.Forms.Label();
            this.lblPatient = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.BorderRadius = 16;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // pnlMain
            // 
            this.pnlMain.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.pnlMain.BorderRadius = 12;
            this.pnlMain.BorderThickness = 1;
            this.pnlMain.Controls.Add(this.btnClose);
            this.pnlMain.Controls.Add(this.btnAdd);
            this.pnlMain.Controls.Add(this.txtDose);
            this.pnlMain.Controls.Add(this.txtMedicineName);
            this.pnlMain.Controls.Add(this.lblNewTitle);
            this.pnlMain.Controls.Add(this.lstCurrentPrescriptions);
            this.pnlMain.Controls.Add(this.lblCurrentTitle);
            this.pnlMain.Controls.Add(this.lblPatient);
            this.pnlMain.Controls.Add(this.lblTitle);
            this.pnlMain.FillColor = System.Drawing.Color.White;
            this.pnlMain.Location = new System.Drawing.Point(18, 18);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(564, 444);
            this.pnlMain.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.btnClose.BorderRadius = 8;
            this.btnClose.BorderThickness = 1;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FillColor = System.Drawing.Color.White;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.btnClose.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(236)))), ((int)(((byte)(234)))));
            this.btnClose.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(79)))), ((int)(((byte)(61)))));
            this.btnClose.Location = new System.Drawing.Point(412, 376);
            this.btnClose.Name = "btnClose";
            this.btnClose.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(79)))), ((int)(((byte)(61)))));
            this.btnClose.Size = new System.Drawing.Size(112, 40);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Đóng";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BorderRadius = 8;
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(240)))));
            this.btnAdd.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.btnAdd.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(148)))), ((int)(((byte)(112)))));
            this.btnAdd.Location = new System.Drawing.Point(282, 376);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(79)))), ((int)(((byte)(61)))));
            this.btnAdd.Size = new System.Drawing.Size(112, 40);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "Thêm thuốc";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtDose
            // 
            this.txtDose.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.txtDose.BorderRadius = 8;
            this.txtDose.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDose.DefaultText = "";
            this.txtDose.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(248)))));
            this.txtDose.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.txtDose.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDose.Location = new System.Drawing.Point(40, 302);
            this.txtDose.Multiline = true;
            this.txtDose.Name = "txtDose";
            this.txtDose.PlaceholderText = "Liều dùng, thời điểm uống, ghi chú...";
            this.txtDose.SelectedText = "";
            this.txtDose.Size = new System.Drawing.Size(484, 58);
            this.txtDose.TabIndex = 6;
            // 
            // txtMedicineName
            // 
            this.txtMedicineName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.txtMedicineName.BorderRadius = 8;
            this.txtMedicineName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMedicineName.DefaultText = "";
            this.txtMedicineName.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(248)))));
            this.txtMedicineName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.txtMedicineName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtMedicineName.Location = new System.Drawing.Point(40, 248);
            this.txtMedicineName.Name = "txtMedicineName";
            this.txtMedicineName.PlaceholderText = "Tên thuốc cần thêm...";
            this.txtMedicineName.SelectedText = "";
            this.txtMedicineName.Size = new System.Drawing.Size(484, 40);
            this.txtMedicineName.TabIndex = 5;
            // 
            // lblNewTitle
            // 
            this.lblNewTitle.AutoSize = true;
            this.lblNewTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblNewTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(42)))));
            this.lblNewTitle.Location = new System.Drawing.Point(36, 218);
            this.lblNewTitle.Name = "lblNewTitle";
            this.lblNewTitle.Size = new System.Drawing.Size(82, 19);
            this.lblNewTitle.TabIndex = 4;
            this.lblNewTitle.Text = "Thuốc mới";
            // 
            // lstCurrentPrescriptions
            // 
            this.lstCurrentPrescriptions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstCurrentPrescriptions.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lstCurrentPrescriptions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(82)))), ((int)(((byte)(73)))));
            this.lstCurrentPrescriptions.FormattingEnabled = true;
            this.lstCurrentPrescriptions.ItemHeight = 17;
            this.lstCurrentPrescriptions.Location = new System.Drawing.Point(40, 120);
            this.lstCurrentPrescriptions.Name = "lstCurrentPrescriptions";
            this.lstCurrentPrescriptions.Size = new System.Drawing.Size(484, 85);
            this.lstCurrentPrescriptions.TabIndex = 3;
            // 
            // lblCurrentTitle
            // 
            this.lblCurrentTitle.AutoSize = true;
            this.lblCurrentTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCurrentTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(42)))));
            this.lblCurrentTitle.Location = new System.Drawing.Point(36, 88);
            this.lblCurrentTitle.Name = "lblCurrentTitle";
            this.lblCurrentTitle.Size = new System.Drawing.Size(128, 19);
            this.lblCurrentTitle.TabIndex = 2;
            this.lblCurrentTitle.Text = "Đơn thuốc hiện tại";
            // 
            // lblPatient
            // 
            this.lblPatient.AutoSize = true;
            this.lblPatient.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPatient.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblPatient.Location = new System.Drawing.Point(38, 51);
            this.lblPatient.Name = "lblPatient";
            this.lblPatient.Size = new System.Drawing.Size(122, 15);
            this.lblPatient.TabIndex = 1;
            this.lblPatient.Text = "Tên bệnh nhân · Mã";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(42)))));
            this.lblTitle.Location = new System.Drawing.Point(36, 24);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(154, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Thêm đơn thuốc";
            // 
            // frmHSBAPrescription
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(245)))), ((int)(((byte)(243)))));
            this.ClientSize = new System.Drawing.Size(600, 480);
            this.Controls.Add(this.pnlMain);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmHSBAPrescription";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thêm đơn thuốc";
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.ResumeLayout(false);

        }

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2Panel pnlMain;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblPatient;
        private System.Windows.Forms.Label lblCurrentTitle;
        private System.Windows.Forms.ListBox lstCurrentPrescriptions;
        private System.Windows.Forms.Label lblNewTitle;
        private Guna.UI2.WinForms.Guna2TextBox txtMedicineName;
        private Guna.UI2.WinForms.Guna2TextBox txtDose;
        private Guna.UI2.WinForms.Guna2Button btnAdd;
        private Guna.UI2.WinForms.Guna2Button btnClose;
    }
}
