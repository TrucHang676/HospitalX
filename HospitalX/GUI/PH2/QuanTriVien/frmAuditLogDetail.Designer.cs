namespace HospitalX.GUI.PH2.QuanTriVien
{
    partial class frmAuditLogDetail
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.borderlessForm = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.pnlHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.btnExit = new Guna.UI2.WinForms.Guna2ControlBox();
            this.lblHeaderMeta = new System.Windows.Forms.Label();
            this.lblAuditId = new System.Windows.Forms.Label();
            this.pnlBody = new Guna.UI2.WinForms.Guna2Panel();
            this.txtDetail = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblDetail = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblResultValue = new System.Windows.Forms.Label();
            this.lblTimeValue = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.lblPolicyValue = new System.Windows.Forms.Label();
            this.lblPolicy = new System.Windows.Forms.Label();
            this.lblIpValue = new System.Windows.Forms.Label();
            this.lblIp = new System.Windows.Forms.Label();
            this.lblRowsValue = new System.Windows.Forms.Label();
            this.lblRows = new System.Windows.Forms.Label();
            this.lblObjectValue = new System.Windows.Forms.Label();
            this.lblObject = new System.Windows.Forms.Label();
            this.lblActionValue = new System.Windows.Forms.Label();
            this.lblAction = new System.Windows.Forms.Label();
            this.lblUserValue = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.SuspendLayout();
            // 
            // borderlessForm
            // 
            this.borderlessForm.BorderRadius = 18;
            this.borderlessForm.ContainerControl = this;
            this.borderlessForm.DockIndicatorTransparencyValue = 0.6D;
            this.borderlessForm.TransparentWhileDrag = true;
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.btnExit);
            this.pnlHeader.Controls.Add(this.lblHeaderMeta);
            this.pnlHeader.Controls.Add(this.lblAuditId);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(58)))), ((int)(((byte)(95)))));
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(720, 92);
            this.pnlHeader.TabIndex = 0;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.BorderRadius = 15;
            this.btnExit.CustomIconSize = 20F;
            this.btnExit.FillColor = System.Drawing.Color.Transparent;
            this.btnExit.ForeColor = System.Drawing.Color.Black;
            this.btnExit.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(79)))), ((int)(((byte)(61)))));
            this.btnExit.IconColor = System.Drawing.Color.DodgerBlue;
            this.btnExit.Location = new System.Drawing.Point(675, 12);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(33, 32);
            this.btnExit.TabIndex = 15;
            // 
            // lblHeaderMeta
            // 
            this.lblHeaderMeta.AutoEllipsis = true;
            this.lblHeaderMeta.BackColor = System.Drawing.Color.Transparent;
            this.lblHeaderMeta.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblHeaderMeta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(232)))), ((int)(((byte)(222)))));
            this.lblHeaderMeta.Location = new System.Drawing.Point(28, 61);
            this.lblHeaderMeta.Name = "lblHeaderMeta";
            this.lblHeaderMeta.Size = new System.Drawing.Size(610, 24);
            this.lblHeaderMeta.TabIndex = 1;
            this.lblHeaderMeta.Text = "user · object · action";
            // 
            // lblAuditId
            // 
            this.lblAuditId.AutoSize = true;
            this.lblAuditId.BackColor = System.Drawing.Color.Transparent;
            this.lblAuditId.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblAuditId.ForeColor = System.Drawing.Color.White;
            this.lblAuditId.Location = new System.Drawing.Point(26, 18);
            this.lblAuditId.Name = "lblAuditId";
            this.lblAuditId.Size = new System.Drawing.Size(118, 32);
            this.lblAuditId.TabIndex = 0;
            this.lblAuditId.Text = "AUD-000";
            // 
            // pnlBody
            // 
            this.pnlBody.Controls.Add(this.txtDetail);
            this.pnlBody.Controls.Add(this.lblDetail);
            this.pnlBody.Controls.Add(this.lblResultValue);
            this.pnlBody.Controls.Add(this.lblResult);
            this.pnlBody.Controls.Add(this.lblPolicyValue);
            this.pnlBody.Controls.Add(this.lblPolicy);
            this.pnlBody.Controls.Add(this.lblIpValue);
            this.pnlBody.Controls.Add(this.lblIp);
            this.pnlBody.Controls.Add(this.lblRowsValue);
            this.pnlBody.Controls.Add(this.lblRows);
            this.pnlBody.Controls.Add(this.lblObjectValue);
            this.pnlBody.Controls.Add(this.lblObject);
            this.pnlBody.Controls.Add(this.lblActionValue);
            this.pnlBody.Controls.Add(this.lblAction);
            this.pnlBody.Controls.Add(this.lblUserValue);
            this.pnlBody.Controls.Add(this.lblUser);
            this.pnlBody.Controls.Add(this.lblTimeValue);
            this.pnlBody.Controls.Add(this.lblTime);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.FillColor = System.Drawing.Color.White;
            this.pnlBody.Location = new System.Drawing.Point(0, 92);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Padding = new System.Windows.Forms.Padding(28);
            this.pnlBody.Size = new System.Drawing.Size(720, 408);
            this.pnlBody.TabIndex = 1;
            // 
            // txtDetail
            // 
            this.txtDetail.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.txtDetail.BorderRadius = 8;
            this.txtDetail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDetail.DefaultText = "";
            this.txtDetail.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(251)))));
            this.txtDetail.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.txtDetail.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDetail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(42)))));
            this.txtDetail.Location = new System.Drawing.Point(32, 262);
            this.txtDetail.Multiline = true;
            this.txtDetail.Name = "txtDetail";
            this.txtDetail.PlaceholderText = "";
            this.txtDetail.ReadOnly = true;
            this.txtDetail.SelectedText = "";
            this.txtDetail.Size = new System.Drawing.Size(656, 112);
            this.txtDetail.TabIndex = 0;
            // 
            // lblDetail
            // 
            this.lblDetail.Font = this.lblTime.Font;
            this.lblDetail.ForeColor = this.lblTime.ForeColor;
            this.lblDetail.Location = new System.Drawing.Point(32, 238);
            this.lblDetail.Name = "lblDetail";
            this.lblDetail.Size = new System.Drawing.Size(120, 20);
            this.lblDetail.TabIndex = 1;
            this.lblDetail.Text = "CHI TIẾT / WHERE";
            // 
            // lblTime
            // 
            this.lblTime.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblTime.Location = new System.Drawing.Point(32, 28);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(100, 20);
            this.lblTime.TabIndex = 17;
            this.lblTime.Text = "THỜI GIAN";
            // 
            // lblResultValue
            // 
            this.lblResultValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(248)))));
            this.lblResultValue.Font = this.lblTimeValue.Font;
            this.lblResultValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.lblResultValue.Location = new System.Drawing.Point(272, 190);
            this.lblResultValue.Name = "lblResultValue";
            this.lblResultValue.Size = new System.Drawing.Size(220, 26);
            this.lblResultValue.TabIndex = 2;
            this.lblResultValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTimeValue
            // 
            this.lblTimeValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(248)))));
            this.lblTimeValue.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblTimeValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(42)))));
            this.lblTimeValue.Location = new System.Drawing.Point(32, 50);
            this.lblTimeValue.Name = "lblTimeValue";
            this.lblTimeValue.Size = new System.Drawing.Size(220, 26);
            this.lblTimeValue.TabIndex = 16;
            this.lblTimeValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblResult
            // 
            this.lblResult.Font = this.lblTime.Font;
            this.lblResult.ForeColor = this.lblTime.ForeColor;
            this.lblResult.Location = new System.Drawing.Point(272, 168);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(100, 20);
            this.lblResult.TabIndex = 3;
            this.lblResult.Text = "KẾT QUẢ";
            // 
            // lblPolicyValue
            // 
            this.lblPolicyValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(248)))));
            this.lblPolicyValue.Font = this.lblTimeValue.Font;
            this.lblPolicyValue.ForeColor = this.lblTimeValue.ForeColor;
            this.lblPolicyValue.Location = new System.Drawing.Point(32, 190);
            this.lblPolicyValue.Name = "lblPolicyValue";
            this.lblPolicyValue.Size = new System.Drawing.Size(220, 26);
            this.lblPolicyValue.TabIndex = 4;
            this.lblPolicyValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPolicy
            // 
            this.lblPolicy.Font = this.lblTime.Font;
            this.lblPolicy.ForeColor = this.lblTime.ForeColor;
            this.lblPolicy.Location = new System.Drawing.Point(32, 168);
            this.lblPolicy.Name = "lblPolicy";
            this.lblPolicy.Size = new System.Drawing.Size(100, 20);
            this.lblPolicy.TabIndex = 5;
            this.lblPolicy.Text = "POLICY";
            // 
            // lblIpValue
            // 
            this.lblIpValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(248)))));
            this.lblIpValue.Font = this.lblTimeValue.Font;
            this.lblIpValue.ForeColor = this.lblTimeValue.ForeColor;
            this.lblIpValue.Location = new System.Drawing.Point(472, 120);
            this.lblIpValue.Name = "lblIpValue";
            this.lblIpValue.Size = new System.Drawing.Size(160, 26);
            this.lblIpValue.TabIndex = 6;
            this.lblIpValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblIp
            // 
            this.lblIp.Font = this.lblTime.Font;
            this.lblIp.ForeColor = this.lblTime.ForeColor;
            this.lblIp.Location = new System.Drawing.Point(472, 98);
            this.lblIp.Name = "lblIp";
            this.lblIp.Size = new System.Drawing.Size(100, 20);
            this.lblIp.TabIndex = 7;
            this.lblIp.Text = "IP NGUỒN";
            // 
            // lblRowsValue
            // 
            this.lblRowsValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(248)))));
            this.lblRowsValue.Font = this.lblTimeValue.Font;
            this.lblRowsValue.ForeColor = this.lblTimeValue.ForeColor;
            this.lblRowsValue.Location = new System.Drawing.Point(272, 120);
            this.lblRowsValue.Name = "lblRowsValue";
            this.lblRowsValue.Size = new System.Drawing.Size(170, 26);
            this.lblRowsValue.TabIndex = 8;
            this.lblRowsValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRows
            // 
            this.lblRows.Font = this.lblTime.Font;
            this.lblRows.ForeColor = this.lblTime.ForeColor;
            this.lblRows.Location = new System.Drawing.Point(272, 98);
            this.lblRows.Name = "lblRows";
            this.lblRows.Size = new System.Drawing.Size(100, 20);
            this.lblRows.TabIndex = 9;
            this.lblRows.Text = "SỐ DÒNG";
            // 
            // lblObjectValue
            // 
            this.lblObjectValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(248)))));
            this.lblObjectValue.Font = this.lblTimeValue.Font;
            this.lblObjectValue.ForeColor = this.lblTimeValue.ForeColor;
            this.lblObjectValue.Location = new System.Drawing.Point(32, 120);
            this.lblObjectValue.Name = "lblObjectValue";
            this.lblObjectValue.Size = new System.Drawing.Size(220, 26);
            this.lblObjectValue.TabIndex = 10;
            this.lblObjectValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblObject
            // 
            this.lblObject.Font = this.lblTime.Font;
            this.lblObject.ForeColor = this.lblTime.ForeColor;
            this.lblObject.Location = new System.Drawing.Point(32, 98);
            this.lblObject.Name = "lblObject";
            this.lblObject.Size = new System.Drawing.Size(100, 20);
            this.lblObject.TabIndex = 11;
            this.lblObject.Text = "ĐỐI TƯỢNG";
            // 
            // lblActionValue
            // 
            this.lblActionValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(248)))));
            this.lblActionValue.Font = this.lblTimeValue.Font;
            this.lblActionValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.lblActionValue.Location = new System.Drawing.Point(472, 50);
            this.lblActionValue.Name = "lblActionValue";
            this.lblActionValue.Size = new System.Drawing.Size(160, 26);
            this.lblActionValue.TabIndex = 12;
            this.lblActionValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAction
            // 
            this.lblAction.Font = this.lblTime.Font;
            this.lblAction.ForeColor = this.lblTime.ForeColor;
            this.lblAction.Location = new System.Drawing.Point(472, 28);
            this.lblAction.Name = "lblAction";
            this.lblAction.Size = new System.Drawing.Size(100, 20);
            this.lblAction.TabIndex = 13;
            this.lblAction.Text = "HÀNH VI";
            // 
            // lblUserValue
            // 
            this.lblUserValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(248)))));
            this.lblUserValue.Font = this.lblTimeValue.Font;
            this.lblUserValue.ForeColor = this.lblTimeValue.ForeColor;
            this.lblUserValue.Location = new System.Drawing.Point(272, 50);
            this.lblUserValue.Name = "lblUserValue";
            this.lblUserValue.Size = new System.Drawing.Size(170, 26);
            this.lblUserValue.TabIndex = 14;
            this.lblUserValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblUser
            // 
            this.lblUser.Font = this.lblTime.Font;
            this.lblUser.ForeColor = this.lblTime.ForeColor;
            this.lblUser.Location = new System.Drawing.Point(272, 28);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(100, 20);
            this.lblUser.TabIndex = 15;
            this.lblUser.Text = "USER";
            // 
            // frmAuditLogDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(720, 500);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAuditLogDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chi tiết audit";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlBody.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm borderlessForm;
        private Guna.UI2.WinForms.Guna2Panel pnlHeader;
        private System.Windows.Forms.Label lblHeaderMeta;
        private System.Windows.Forms.Label lblAuditId;
        private Guna.UI2.WinForms.Guna2Panel pnlBody;
        private Guna.UI2.WinForms.Guna2TextBox txtDetail;
        private System.Windows.Forms.Label lblDetail;
        private System.Windows.Forms.Label lblResultValue;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label lblPolicyValue;
        private System.Windows.Forms.Label lblPolicy;
        private System.Windows.Forms.Label lblIpValue;
        private System.Windows.Forms.Label lblIp;
        private System.Windows.Forms.Label lblRowsValue;
        private System.Windows.Forms.Label lblRows;
        private System.Windows.Forms.Label lblObjectValue;
        private System.Windows.Forms.Label lblObject;
        private System.Windows.Forms.Label lblActionValue;
        private System.Windows.Forms.Label lblAction;
        private System.Windows.Forms.Label lblUserValue;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblTimeValue;
        private System.Windows.Forms.Label lblTime;
        private Guna.UI2.WinForms.Guna2ControlBox btnExit;
    }
}
