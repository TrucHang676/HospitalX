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
            this.msgDialog = new Guna.UI2.WinForms.Guna2MessageDialog();
            this.pnlHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.btnCloseBox = new Guna.UI2.WinForms.Guna2ControlBox();
            this.lblHsbaId = new System.Windows.Forms.Label();
            this.lblPatient = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlCurrent = new Guna.UI2.WinForms.Guna2Panel();
            this.lstCurrentPrescriptions = new System.Windows.Forms.ListBox();
            this.lblCurrentHint = new System.Windows.Forms.Label();
            this.lblCurrentTitle = new System.Windows.Forms.Label();
            this.pnlNew = new Guna.UI2.WinForms.Guna2Panel();
            this.lblDoseTitle = new System.Windows.Forms.Label();
            this.txtDose = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblMedicineTitle = new System.Windows.Forms.Label();
            this.txtMedicineName = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblNewTitle = new System.Windows.Forms.Label();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.btnAdd = new Guna.UI2.WinForms.Guna2Button();
            this.pnlHeader.SuspendLayout();
            this.pnlCurrent.SuspendLayout();
            this.pnlNew.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.BorderRadius = 16;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // msgDialog
            // 
            this.msgDialog.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
            this.msgDialog.Caption = "HospitalX";
            this.msgDialog.Icon = Guna.UI2.WinForms.MessageDialogIcon.None;
            this.msgDialog.Parent = this;
            this.msgDialog.Style = Guna.UI2.WinForms.MessageDialogStyle.Light;
            this.msgDialog.Text = null;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BorderRadius = 12;
            this.pnlHeader.Controls.Add(this.btnCloseBox);
            this.pnlHeader.Controls.Add(this.lblHsbaId);
            this.pnlHeader.Controls.Add(this.lblPatient);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(79)))), ((int)(((byte)(61)))));
            this.pnlHeader.Location = new System.Drawing.Point(24, 20);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1226, 135);
            this.pnlHeader.TabIndex = 0;
            // 
            // btnCloseBox
            // 
            this.btnCloseBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCloseBox.BackColor = System.Drawing.Color.Transparent;
            this.btnCloseBox.BorderRadius = 8;
            this.btnCloseBox.FillColor = System.Drawing.Color.Transparent;
            this.btnCloseBox.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(79)))), ((int)(((byte)(61)))));
            this.btnCloseBox.IconColor = System.Drawing.Color.White;
            this.btnCloseBox.Location = new System.Drawing.Point(1172, 9);
            this.btnCloseBox.Name = "btnCloseBox";
            this.btnCloseBox.Size = new System.Drawing.Size(36, 32);
            this.btnCloseBox.TabIndex = 3;
            // 
            // lblHsbaId
            // 
            this.lblHsbaId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(244)))), ((int)(((byte)(240)))));
            this.lblHsbaId.Font = new System.Drawing.Font("Consolas", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblHsbaId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.lblHsbaId.Location = new System.Drawing.Point(1074, 80);
            this.lblHsbaId.Name = "lblHsbaId";
            this.lblHsbaId.Size = new System.Drawing.Size(128, 30);
            this.lblHsbaId.TabIndex = 2;
            this.lblHsbaId.Text = "HSBA-0000";
            this.lblHsbaId.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPatient
            // 
            this.lblPatient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(79)))), ((int)(((byte)(61)))));
            this.lblPatient.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblPatient.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(244)))), ((int)(((byte)(240)))));
            this.lblPatient.Location = new System.Drawing.Point(32, 90);
            this.lblPatient.Name = "lblPatient";
            this.lblPatient.Size = new System.Drawing.Size(520, 24);
            this.lblPatient.TabIndex = 1;
            this.lblPatient.Text = "Tên bệnh nhân · Mã BN";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(79)))), ((int)(((byte)(61)))));
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 19F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(30, 35);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(216, 36);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Thêm đơn thuốc";
            // 
            // pnlCurrent
            // 
            this.pnlCurrent.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.pnlCurrent.BorderRadius = 10;
            this.pnlCurrent.BorderThickness = 1;
            this.pnlCurrent.Controls.Add(this.lstCurrentPrescriptions);
            this.pnlCurrent.Controls.Add(this.lblCurrentHint);
            this.pnlCurrent.Controls.Add(this.lblCurrentTitle);
            this.pnlCurrent.FillColor = System.Drawing.Color.White;
            this.pnlCurrent.Location = new System.Drawing.Point(24, 191);
            this.pnlCurrent.Name = "pnlCurrent";
            this.pnlCurrent.Size = new System.Drawing.Size(517, 508);
            this.pnlCurrent.TabIndex = 1;
            // 
            // lstCurrentPrescriptions
            // 
            this.lstCurrentPrescriptions.BackColor = System.Drawing.Color.White;
            this.lstCurrentPrescriptions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstCurrentPrescriptions.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lstCurrentPrescriptions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(82)))), ((int)(((byte)(73)))));
            this.lstCurrentPrescriptions.FormattingEnabled = true;
            this.lstCurrentPrescriptions.ItemHeight = 17;
            this.lstCurrentPrescriptions.Location = new System.Drawing.Point(26, 120);
            this.lstCurrentPrescriptions.Name = "lstCurrentPrescriptions";
            this.lstCurrentPrescriptions.Size = new System.Drawing.Size(446, 340);
            this.lstCurrentPrescriptions.TabIndex = 2;
            // 
            // lblCurrentHint
            // 
            this.lblCurrentHint.AutoSize = true;
            this.lblCurrentHint.BackColor = System.Drawing.Color.White;
            this.lblCurrentHint.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentHint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblCurrentHint.Location = new System.Drawing.Point(25, 72);
            this.lblCurrentHint.Name = "lblCurrentHint";
            this.lblCurrentHint.Size = new System.Drawing.Size(168, 15);
            this.lblCurrentHint.TabIndex = 1;
            this.lblCurrentHint.Text = "Các thuốc đang có trong đơn";
            // 
            // lblCurrentTitle
            // 
            this.lblCurrentTitle.AutoSize = true;
            this.lblCurrentTitle.BackColor = System.Drawing.Color.White;
            this.lblCurrentTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblCurrentTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(42)))));
            this.lblCurrentTitle.Location = new System.Drawing.Point(24, 22);
            this.lblCurrentTitle.Name = "lblCurrentTitle";
            this.lblCurrentTitle.Size = new System.Drawing.Size(138, 20);
            this.lblCurrentTitle.TabIndex = 0;
            this.lblCurrentTitle.Text = "Đơn thuốc hiện tại";
            // 
            // pnlNew
            // 
            this.pnlNew.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.pnlNew.BorderRadius = 10;
            this.pnlNew.BorderThickness = 1;
            this.pnlNew.Controls.Add(this.lblDoseTitle);
            this.pnlNew.Controls.Add(this.txtDose);
            this.pnlNew.Controls.Add(this.lblMedicineTitle);
            this.pnlNew.Controls.Add(this.txtMedicineName);
            this.pnlNew.Controls.Add(this.lblNewTitle);
            this.pnlNew.FillColor = System.Drawing.Color.White;
            this.pnlNew.Location = new System.Drawing.Point(593, 191);
            this.pnlNew.Name = "pnlNew";
            this.pnlNew.Size = new System.Drawing.Size(657, 508);
            this.pnlNew.TabIndex = 2;
            // 
            // lblDoseTitle
            // 
            this.lblDoseTitle.AutoSize = true;
            this.lblDoseTitle.BackColor = System.Drawing.Color.White;
            this.lblDoseTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblDoseTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblDoseTitle.Location = new System.Drawing.Point(29, 224);
            this.lblDoseTitle.Name = "lblDoseTitle";
            this.lblDoseTitle.Size = new System.Drawing.Size(71, 15);
            this.lblDoseTitle.TabIndex = 4;
            this.lblDoseTitle.Text = "LIỀU DÙNG";
            // 
            // txtDose
            // 
            this.txtDose.BackColor = System.Drawing.Color.Transparent;
            this.txtDose.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.txtDose.BorderRadius = 8;
            this.txtDose.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDose.DefaultText = "";
            this.txtDose.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(248)))));
            this.txtDose.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.txtDose.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtDose.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(148)))), ((int)(((byte)(112)))));
            this.txtDose.Location = new System.Drawing.Point(32, 256);
            this.txtDose.Multiline = true;
            this.txtDose.Name = "txtDose";
            this.txtDose.PlaceholderText = "Liều dùng, thời điểm uống, ghi chú...";
            this.txtDose.SelectedText = "";
            this.txtDose.Size = new System.Drawing.Size(580, 118);
            this.txtDose.TabIndex = 3;
            // 
            // lblMedicineTitle
            // 
            this.lblMedicineTitle.AutoSize = true;
            this.lblMedicineTitle.BackColor = System.Drawing.Color.White;
            this.lblMedicineTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblMedicineTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblMedicineTitle.Location = new System.Drawing.Point(27, 72);
            this.lblMedicineTitle.Name = "lblMedicineTitle";
            this.lblMedicineTitle.Size = new System.Drawing.Size(73, 15);
            this.lblMedicineTitle.TabIndex = 2;
            this.lblMedicineTitle.Text = "TÊN THUỐC";
            // 
            // txtMedicineName
            // 
            this.txtMedicineName.BackColor = System.Drawing.Color.Transparent;
            this.txtMedicineName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.txtMedicineName.BorderRadius = 8;
            this.txtMedicineName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMedicineName.DefaultText = "";
            this.txtMedicineName.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(248)))));
            this.txtMedicineName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.txtMedicineName.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtMedicineName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(148)))), ((int)(((byte)(112)))));
            this.txtMedicineName.Location = new System.Drawing.Point(28, 110);
            this.txtMedicineName.Name = "txtMedicineName";
            this.txtMedicineName.PlaceholderText = "Tên thuốc cần thêm...";
            this.txtMedicineName.SelectedText = "";
            this.txtMedicineName.Size = new System.Drawing.Size(580, 66);
            this.txtMedicineName.TabIndex = 1;
            // 
            // lblNewTitle
            // 
            this.lblNewTitle.AutoSize = true;
            this.lblNewTitle.BackColor = System.Drawing.Color.White;
            this.lblNewTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblNewTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(42)))));
            this.lblNewTitle.Location = new System.Drawing.Point(24, 22);
            this.lblNewTitle.Name = "lblNewTitle";
            this.lblNewTitle.Size = new System.Drawing.Size(83, 20);
            this.lblNewTitle.TabIndex = 0;
            this.lblNewTitle.Text = "Thuốc mới";
            // 
            // btnClose
            // 
            this.btnClose.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.btnClose.BorderRadius = 8;
            this.btnClose.BorderThickness = 1;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FillColor = System.Drawing.Color.White;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.btnClose.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(236)))), ((int)(((byte)(234)))));
            this.btnClose.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(79)))), ((int)(((byte)(61)))));
            this.btnClose.Location = new System.Drawing.Point(1085, 747);
            this.btnClose.Name = "btnClose";
            this.btnClose.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(79)))), ((int)(((byte)(61)))));
            this.btnClose.Size = new System.Drawing.Size(165, 44);
            this.btnClose.TabIndex = 4;
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
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(148)))), ((int)(((byte)(112)))));
            this.btnAdd.Location = new System.Drawing.Point(888, 747);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(79)))), ((int)(((byte)(61)))));
            this.btnAdd.Size = new System.Drawing.Size(165, 44);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Thêm thuốc";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // frmHSBAPrescription
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(245)))), ((int)(((byte)(243)))));
            this.ClientSize = new System.Drawing.Size(1277, 840);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.pnlNew);
            this.Controls.Add(this.pnlCurrent);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmHSBAPrescription";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thêm đơn thuốc";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlCurrent.ResumeLayout(false);
            this.pnlCurrent.PerformLayout();
            this.pnlNew.ResumeLayout(false);
            this.pnlNew.PerformLayout();
            this.ResumeLayout(false);

        }

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2MessageDialog msgDialog;
        private Guna.UI2.WinForms.Guna2Panel pnlHeader;
        private Guna.UI2.WinForms.Guna2ControlBox btnCloseBox;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblPatient;
        private System.Windows.Forms.Label lblHsbaId;
        private Guna.UI2.WinForms.Guna2Panel pnlCurrent;
        private System.Windows.Forms.Label lblCurrentTitle;
        private System.Windows.Forms.Label lblCurrentHint;
        private System.Windows.Forms.ListBox lstCurrentPrescriptions;
        private Guna.UI2.WinForms.Guna2Panel pnlNew;
        private System.Windows.Forms.Label lblNewTitle;
        private System.Windows.Forms.Label lblMedicineTitle;
        private Guna.UI2.WinForms.Guna2TextBox txtMedicineName;
        private System.Windows.Forms.Label lblDoseTitle;
        private Guna.UI2.WinForms.Guna2TextBox txtDose;
        private Guna.UI2.WinForms.Guna2Button btnAdd;
        private Guna.UI2.WinForms.Guna2Button btnClose;
    }
}
