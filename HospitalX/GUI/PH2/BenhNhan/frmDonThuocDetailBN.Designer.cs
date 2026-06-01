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
            this.pnlInfo = new Guna.UI2.WinForms.Guna2Panel();
            this.txtDiagnosis = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblDiagnosis = new System.Windows.Forms.Label();
            this.lblDateValue = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblCountValue = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.lblHsbaValue = new System.Windows.Forms.Label();
            this.lblHsba = new System.Windows.Forms.Label();
            this.pnlMedicines = new Guna.UI2.WinForms.Guna2Panel();
            this.flowMedicines = new System.Windows.Forms.FlowLayoutPanel();
            this.lblMedicinesTitle = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlInfo.SuspendLayout();
            this.pnlMedicines.SuspendLayout();
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
            this.pnlHeader.Size = new System.Drawing.Size(832, 118);
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
            this.btnClose.Location = new System.Drawing.Point(781, 12);
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
            this.lblMeta.Size = new System.Drawing.Size(560, 24);
            this.lblMeta.TabIndex = 2;
            this.lblMeta.Text = "BN-00341 · Nguyễn Văn An";
            // 
            // lblCode
            // 
            this.lblCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(245)))), ((int)(((byte)(239)))));
            this.lblCode.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold);
            this.lblCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(85)))));
            this.lblCode.Location = new System.Drawing.Point(678, 68);
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
            this.lblTitle.Location = new System.Drawing.Point(29, 24);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(273, 41);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Chi tiết đơn thuốc";
            // 
            // pnlInfo
            // 
            this.pnlInfo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(224)))), ((int)(((byte)(219)))));
            this.pnlInfo.BorderRadius = 8;
            this.pnlInfo.BorderThickness = 1;
            this.pnlInfo.Controls.Add(this.txtDiagnosis);
            this.pnlInfo.Controls.Add(this.lblDiagnosis);
            this.pnlInfo.Controls.Add(this.lblDateValue);
            this.pnlInfo.Controls.Add(this.lblDate);
            this.pnlInfo.Controls.Add(this.lblCountValue);
            this.pnlInfo.Controls.Add(this.lblCount);
            this.pnlInfo.Controls.Add(this.lblHsbaValue);
            this.pnlInfo.Controls.Add(this.lblHsba);
            this.pnlInfo.FillColor = System.Drawing.Color.White;
            this.pnlInfo.Location = new System.Drawing.Point(24, 158);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(832, 156);
            this.pnlInfo.TabIndex = 1;
            // 
            // txtDiagnosis
            // 
            this.txtDiagnosis.BackColor = System.Drawing.Color.Transparent;
            this.txtDiagnosis.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(228)))));
            this.txtDiagnosis.BorderRadius = 6;
            this.txtDiagnosis.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDiagnosis.DefaultText = "";
            this.txtDiagnosis.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(250)))), ((int)(((byte)(249)))));
            this.txtDiagnosis.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDiagnosis.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.txtDiagnosis.Location = new System.Drawing.Point(26, 98);
            this.txtDiagnosis.Multiline = true;
            this.txtDiagnosis.Name = "txtDiagnosis";
            this.txtDiagnosis.PlaceholderText = "";
            this.txtDiagnosis.ReadOnly = true;
            this.txtDiagnosis.SelectedText = "";
            this.txtDiagnosis.Size = new System.Drawing.Size(780, 36);
            this.txtDiagnosis.TabIndex = 0;
            // 
            // lblDiagnosis
            // 
            this.lblDiagnosis.AutoSize = true;
            this.lblDiagnosis.BackColor = System.Drawing.Color.Transparent;
            this.lblDiagnosis.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblDiagnosis.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(138)))), ((int)(((byte)(132)))));
            this.lblDiagnosis.Location = new System.Drawing.Point(28, 78);
            this.lblDiagnosis.Name = "lblDiagnosis";
            this.lblDiagnosis.Size = new System.Drawing.Size(144, 15);
            this.lblDiagnosis.TabIndex = 1;
            this.lblDiagnosis.Text = "CHẨN ĐOÁN LIÊN QUAN";
            // 
            // lblDateValue
            // 
            this.lblDateValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(250)))), ((int)(((byte)(249)))));
            this.lblDateValue.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Bold);
            this.lblDateValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(85)))));
            this.lblDateValue.Location = new System.Drawing.Point(220, 38);
            this.lblDateValue.Name = "lblDateValue";
            this.lblDateValue.Padding = new System.Windows.Forms.Padding(10, 4, 8, 4);
            this.lblDateValue.Size = new System.Drawing.Size(158, 32);
            this.lblDateValue.TabIndex = 2;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.BackColor = System.Drawing.Color.Transparent;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(138)))), ((int)(((byte)(132)))));
            this.lblDate.Location = new System.Drawing.Point(222, 18);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(137, 15);
            this.lblDate.TabIndex = 3;
            this.lblDate.Text = "NGÀY LẬP ĐƠN THUỐC";
            // 
            // lblCountValue
            // 
            this.lblCountValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(250)))), ((int)(((byte)(249)))));
            this.lblCountValue.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCountValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.lblCountValue.Location = new System.Drawing.Point(415, 38);
            this.lblCountValue.Name = "lblCountValue";
            this.lblCountValue.Padding = new System.Windows.Forms.Padding(10, 4, 8, 4);
            this.lblCountValue.Size = new System.Drawing.Size(158, 32);
            this.lblCountValue.TabIndex = 4;
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.BackColor = System.Drawing.Color.Transparent;
            this.lblCount.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(138)))), ((int)(((byte)(132)))));
            this.lblCount.Location = new System.Drawing.Point(416, 18);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(67, 15);
            this.lblCount.TabIndex = 5;
            this.lblCount.Text = "SỐ THUỐC";
            // 
            // lblHsbaValue
            // 
            this.lblHsbaValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(245)))), ((int)(((byte)(239)))));
            this.lblHsbaValue.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Bold);
            this.lblHsbaValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(85)))));
            this.lblHsbaValue.Location = new System.Drawing.Point(26, 38);
            this.lblHsbaValue.Name = "lblHsbaValue";
            this.lblHsbaValue.Size = new System.Drawing.Size(158, 32);
            this.lblHsbaValue.TabIndex = 6;
            this.lblHsbaValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHsba
            // 
            this.lblHsba.AutoSize = true;
            this.lblHsba.BackColor = System.Drawing.Color.Transparent;
            this.lblHsba.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblHsba.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(138)))), ((int)(((byte)(132)))));
            this.lblHsba.Location = new System.Drawing.Point(28, 18);
            this.lblHsba.Name = "lblHsba";
            this.lblHsba.Size = new System.Drawing.Size(99, 15);
            this.lblHsba.TabIndex = 7;
            this.lblHsba.Text = "HỒ SƠ BỆNH ÁN";
            // 
            // pnlMedicines
            // 
            this.pnlMedicines.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(224)))), ((int)(((byte)(219)))));
            this.pnlMedicines.BorderRadius = 8;
            this.pnlMedicines.BorderThickness = 1;
            this.pnlMedicines.Controls.Add(this.flowMedicines);
            this.pnlMedicines.Controls.Add(this.lblMedicinesTitle);
            this.pnlMedicines.FillColor = System.Drawing.Color.White;
            this.pnlMedicines.Location = new System.Drawing.Point(24, 334);
            this.pnlMedicines.Name = "pnlMedicines";
            this.pnlMedicines.Size = new System.Drawing.Size(832, 290);
            this.pnlMedicines.TabIndex = 2;
            // 
            // flowMedicines
            // 
            this.flowMedicines.AutoScroll = true;
            this.flowMedicines.BackColor = System.Drawing.Color.White;
            this.flowMedicines.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowMedicines.Location = new System.Drawing.Point(24, 62);
            this.flowMedicines.Name = "flowMedicines";
            this.flowMedicines.Size = new System.Drawing.Size(784, 204);
            this.flowMedicines.TabIndex = 1;
            this.flowMedicines.WrapContents = false;
            // 
            // lblMedicinesTitle
            // 
            this.lblMedicinesTitle.AutoSize = true;
            this.lblMedicinesTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblMedicinesTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblMedicinesTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.lblMedicinesTitle.Location = new System.Drawing.Point(22, 20);
            this.lblMedicinesTitle.Name = "lblMedicinesTitle";
            this.lblMedicinesTitle.Size = new System.Drawing.Size(272, 28);
            this.lblMedicinesTitle.TabIndex = 0;
            this.lblMedicinesTitle.Text = "Danh sách thuốc trong đơn";
            // 
            // frmDonThuocDetailBN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(245)))), ((int)(((byte)(243)))));
            this.ClientSize = new System.Drawing.Size(880, 648);
            this.Controls.Add(this.pnlMedicines);
            this.Controls.Add(this.pnlInfo);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDonThuocDetailBN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chi tiết đơn thuốc";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlInfo.ResumeLayout(false);
            this.pnlInfo.PerformLayout();
            this.pnlMedicines.ResumeLayout(false);
            this.pnlMedicines.PerformLayout();
            this.ResumeLayout(false);

        }

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2Panel pnlHeader;
        private Guna.UI2.WinForms.Guna2ControlBox btnClose;
        private System.Windows.Forms.Label lblMeta;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.Label lblTitle;
        private Guna.UI2.WinForms.Guna2Panel pnlInfo;
        private Guna.UI2.WinForms.Guna2TextBox txtDiagnosis;
        private System.Windows.Forms.Label lblDiagnosis;
        private System.Windows.Forms.Label lblDateValue;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblCountValue;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Label lblHsbaValue;
        private System.Windows.Forms.Label lblHsba;
        private Guna.UI2.WinForms.Guna2Panel pnlMedicines;
        private System.Windows.Forms.FlowLayoutPanel flowMedicines;
        private System.Windows.Forms.Label lblMedicinesTitle;
    }
}
