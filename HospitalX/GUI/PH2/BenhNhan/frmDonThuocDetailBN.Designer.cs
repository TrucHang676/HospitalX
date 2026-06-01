namespace HospitalX.GUI.PH2.BenhNhan
{
    partial class frmDonThuocDetailBN
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.pnlHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.btnClose = new Guna.UI2.WinForms.Guna2ControlBox();
            this.lblMeta = new System.Windows.Forms.Label();
            this.lblCode = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlBody = new Guna.UI2.WinForms.Guna2Panel();
            this.txtDiagnosis = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblDiagnosis = new System.Windows.Forms.Label();
            this.lblDoseValue = new System.Windows.Forms.Label();
            this.lblDose = new System.Windows.Forms.Label();
            this.lblDateValue = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblMedicineValue = new System.Windows.Forms.Label();
            this.lblMedicine = new System.Windows.Forms.Label();
            this.lblHsbaValue = new System.Windows.Forms.Label();
            this.lblHsba = new System.Windows.Forms.Label();
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
            this.pnlHeader.Controls.Add(this.lblMeta);
            this.pnlHeader.Controls.Add(this.lblCode);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(82)))), ((int)(((byte)(66)))));
            this.pnlHeader.Location = new System.Drawing.Point(24, 20);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(752, 118);
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
            this.btnClose.Location = new System.Drawing.Point(701, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(36, 32);
            this.btnClose.TabIndex = 3;
            // 
            // lblMeta
            // 
            this.lblMeta.BackColor = System.Drawing.Color.Transparent;
            this.lblMeta.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblMeta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(235)))), ((int)(((byte)(225)))));
            this.lblMeta.Location = new System.Drawing.Point(32, 78);
            this.lblMeta.Name = "lblMeta";
            this.lblMeta.Size = new System.Drawing.Size(480, 24);
            this.lblMeta.TabIndex = 2;
            this.lblMeta.Text = "BN-00341 · Nguyễn Văn An";
            // 
            // lblCode
            // 
            this.lblCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(245)))), ((int)(((byte)(239)))));
            this.lblCode.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold);
            this.lblCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(85)))));
            this.lblCode.Location = new System.Drawing.Point(570, 48);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(130, 34);
            this.lblCode.TabIndex = 1;
            this.lblCode.Text = "HSBA-0000";
            this.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(28, 30);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(275, 41);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Chi tiết đơn thuốc";
            // 
            // pnlBody
            // 
            this.pnlBody.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(224)))), ((int)(((byte)(219)))));
            this.pnlBody.BorderRadius = 8;
            this.pnlBody.BorderThickness = 1;
            this.pnlBody.Controls.Add(this.txtDiagnosis);
            this.pnlBody.Controls.Add(this.lblDiagnosis);
            this.pnlBody.Controls.Add(this.lblDoseValue);
            this.pnlBody.Controls.Add(this.lblDose);
            this.pnlBody.Controls.Add(this.lblDateValue);
            this.pnlBody.Controls.Add(this.lblDate);
            this.pnlBody.Controls.Add(this.lblMedicineValue);
            this.pnlBody.Controls.Add(this.lblMedicine);
            this.pnlBody.Controls.Add(this.lblHsbaValue);
            this.pnlBody.Controls.Add(this.lblHsba);
            this.pnlBody.FillColor = System.Drawing.Color.White;
            this.pnlBody.Location = new System.Drawing.Point(24, 158);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(752, 270);
            this.pnlBody.TabIndex = 1;
            // 
            // fields
            // 
            this.lblHsba.AutoSize = true;
            this.lblHsba.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblHsba.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(138)))), ((int)(((byte)(132)))));
            this.lblHsba.Location = new System.Drawing.Point(28, 26);
            this.lblHsba.Text = "HỒ SƠ BỆNH ÁN";
            this.lblHsbaValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(245)))), ((int)(((byte)(239)))));
            this.lblHsbaValue.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Bold);
            this.lblHsbaValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(85)))));
            this.lblHsbaValue.Location = new System.Drawing.Point(26, 48);
            this.lblHsbaValue.Size = new System.Drawing.Size(158, 32);
            this.lblHsbaValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMedicine.AutoSize = true;
            this.lblMedicine.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblMedicine.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(138)))), ((int)(((byte)(132)))));
            this.lblMedicine.Location = new System.Drawing.Point(212, 26);
            this.lblMedicine.Text = "TÊN THUỐC";
            this.lblMedicineValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(250)))), ((int)(((byte)(249)))));
            this.lblMedicineValue.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMedicineValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.lblMedicineValue.Location = new System.Drawing.Point(210, 48);
            this.lblMedicineValue.Padding = new System.Windows.Forms.Padding(10, 4, 8, 4);
            this.lblMedicineValue.Size = new System.Drawing.Size(500, 32);
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(138)))), ((int)(((byte)(132)))));
            this.lblDate.Location = new System.Drawing.Point(28, 104);
            this.lblDate.Text = "NGÀY ĐƠN THUỐC";
            this.lblDateValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(250)))), ((int)(((byte)(249)))));
            this.lblDateValue.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Bold);
            this.lblDateValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(85)))));
            this.lblDateValue.Location = new System.Drawing.Point(26, 126);
            this.lblDateValue.Padding = new System.Windows.Forms.Padding(10, 4, 8, 4);
            this.lblDateValue.Size = new System.Drawing.Size(158, 32);
            this.lblDose.AutoSize = true;
            this.lblDose.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblDose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(138)))), ((int)(((byte)(132)))));
            this.lblDose.Location = new System.Drawing.Point(212, 104);
            this.lblDose.Text = "LIỀU DÙNG";
            this.lblDoseValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(250)))), ((int)(((byte)(249)))));
            this.lblDoseValue.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDoseValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.lblDoseValue.Location = new System.Drawing.Point(210, 126);
            this.lblDoseValue.Padding = new System.Windows.Forms.Padding(10, 4, 8, 4);
            this.lblDoseValue.Size = new System.Drawing.Size(246, 32);
            this.lblDiagnosis.AutoSize = true;
            this.lblDiagnosis.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblDiagnosis.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(138)))), ((int)(((byte)(132)))));
            this.lblDiagnosis.Location = new System.Drawing.Point(28, 182);
            this.lblDiagnosis.Text = "CHẨN ĐOÁN LIÊN QUAN";
            this.txtDiagnosis.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(228)))));
            this.txtDiagnosis.BorderRadius = 6;
            this.txtDiagnosis.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(250)))), ((int)(((byte)(249)))));
            this.txtDiagnosis.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDiagnosis.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.txtDiagnosis.Location = new System.Drawing.Point(26, 204);
            this.txtDiagnosis.Multiline = true;
            this.txtDiagnosis.ReadOnly = true;
            this.txtDiagnosis.Size = new System.Drawing.Size(684, 42);
            // 
            // frmDonThuocDetailBN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(245)))), ((int)(((byte)(243)))));
            this.ClientSize = new System.Drawing.Size(800, 454);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDonThuocDetailBN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chi tiết đơn thuốc";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlBody.ResumeLayout(false);
            this.pnlBody.PerformLayout();
            this.ResumeLayout(false);
        }

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2Panel pnlHeader;
        private Guna.UI2.WinForms.Guna2ControlBox btnClose;
        private System.Windows.Forms.Label lblMeta;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.Label lblTitle;
        private Guna.UI2.WinForms.Guna2Panel pnlBody;
        private Guna.UI2.WinForms.Guna2TextBox txtDiagnosis;
        private System.Windows.Forms.Label lblDiagnosis;
        private System.Windows.Forms.Label lblDoseValue;
        private System.Windows.Forms.Label lblDose;
        private System.Windows.Forms.Label lblDateValue;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblMedicineValue;
        private System.Windows.Forms.Label lblMedicine;
        private System.Windows.Forms.Label lblHsbaValue;
        private System.Windows.Forms.Label lblHsba;
    }
}
