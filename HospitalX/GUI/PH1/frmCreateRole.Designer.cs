namespace HospitalX.GUI.PH1
{
    partial class frmCreateRole
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
            this.pnlTop = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblRoleName = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtRoleName = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblAuthType = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.cmbAuthType = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblPassword = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            this.btnCreate = new Guna.UI2.WinForms.Guna2Button();
            this.msgDialog = new Guna.UI2.WinForms.Guna2MessageDialog();
            this.guna2BorderlessForm2 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(180)))));
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(500, 50);
            this.pnlTop.TabIndex = 8;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 13);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(118, 23);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "+ Tạo Role mới";
            // 
            // lblRoleName
            // 
            this.lblRoleName.BackColor = System.Drawing.Color.Transparent;
            this.lblRoleName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoleName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(110)))), ((int)(((byte)(120)))));
            this.lblRoleName.Location = new System.Drawing.Point(40, 80);
            this.lblRoleName.Name = "lblRoleName";
            this.lblRoleName.Size = new System.Drawing.Size(67, 19);
            this.lblRoleName.TabIndex = 7;
            this.lblRoleName.Text = "Tên Role <span style=\'color:red;\'>*</span>";
            // 
            // txtRoleName
            // 
            this.txtRoleName.BorderRadius = 8;
            this.txtRoleName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRoleName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRoleName.DefaultText = "";
            this.txtRoleName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(180)))));
            this.txtRoleName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtRoleName.Location = new System.Drawing.Point(40, 105);
            this.txtRoleName.Name = "txtRoleName";
            this.txtRoleName.PlaceholderText = "VD: ROLE_DEMO";
            this.txtRoleName.SelectedText = "";
            this.txtRoleName.Size = new System.Drawing.Size(420, 40);
            this.txtRoleName.TabIndex = 6;
            // 
            // lblAuthType
            // 
            this.lblAuthType.BackColor = System.Drawing.Color.Transparent;
            this.lblAuthType.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAuthType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(110)))), ((int)(((byte)(120)))));
            this.lblAuthType.Location = new System.Drawing.Point(40, 160);
            this.lblAuthType.Name = "lblAuthType";
            this.lblAuthType.Size = new System.Drawing.Size(86, 19);
            this.lblAuthType.TabIndex = 5;
            this.lblAuthType.Text = "Kiểu xác thực";
            // 
            // cmbAuthType
            // 
            this.cmbAuthType.BackColor = System.Drawing.Color.Transparent;
            this.cmbAuthType.BorderRadius = 8;
            this.cmbAuthType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbAuthType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAuthType.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(180)))));
            this.cmbAuthType.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(180)))));
            this.cmbAuthType.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbAuthType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbAuthType.ItemHeight = 30;
            this.cmbAuthType.Items.AddRange(new object[] {
            "NOT IDENTIFIED",
            "BY PASSWORD"});
            this.cmbAuthType.Location = new System.Drawing.Point(40, 185);
            this.cmbAuthType.Name = "cmbAuthType";
            this.cmbAuthType.Size = new System.Drawing.Size(200, 36);
            this.cmbAuthType.TabIndex = 4;
            // 
            // lblPassword
            // 
            this.lblPassword.BackColor = System.Drawing.Color.Transparent;
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(110)))), ((int)(((byte)(120)))));
            this.lblPassword.Location = new System.Drawing.Point(260, 160);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(61, 19);
            this.lblPassword.TabIndex = 3;
            this.lblPassword.Text = "Mật khẩu";
            // 
            // txtPassword
            // 
            this.txtPassword.BorderRadius = 8;
            this.txtPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPassword.DefaultText = "";
            this.txtPassword.Enabled = false;
            this.txtPassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(180)))));
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPassword.Location = new System.Drawing.Point(260, 185);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PlaceholderText = "Nhập mật khẩu...";
            this.txtPassword.SelectedText = "";
            this.txtPassword.Size = new System.Drawing.Size(200, 36);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // btnCancel
            // 
            this.btnCancel.BorderRadius = 8;
            this.btnCancel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(235)))), ((int)(((byte)(238)))));
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.btnCancel.Location = new System.Drawing.Point(250, 260);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 42);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Hủy";
            // 
            // btnCreate
            // 
            this.btnCreate.BorderRadius = 8;
            this.btnCreate.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(180)))));
            this.btnCreate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCreate.ForeColor = System.Drawing.Color.White;
            this.btnCreate.Location = new System.Drawing.Point(360, 260);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(100, 42);
            this.btnCreate.TabIndex = 0;
            this.btnCreate.Text = "+ Tạo";
            // 
            // msgDialog
            // 
            this.msgDialog.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
            this.msgDialog.Caption = "Hệ thống";
            this.msgDialog.Icon = Guna.UI2.WinForms.MessageDialogIcon.None;
            this.msgDialog.Parent = null;
            this.msgDialog.Style = Guna.UI2.WinForms.MessageDialogStyle.Light;
            this.msgDialog.Text = null;
            // 
            // guna2BorderlessForm2
            // 
            this.guna2BorderlessForm2.BorderRadius = 20;
            this.guna2BorderlessForm2.ContainerControl = this;
            this.guna2BorderlessForm2.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm2.ShadowColor = System.Drawing.Color.CornflowerBlue;
            this.guna2BorderlessForm2.TransparentWhileDrag = true;
            // 
            // frmCreateRole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(500, 330);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.cmbAuthType);
            this.Controls.Add(this.lblAuthType);
            this.Controls.Add(this.txtRoleName);
            this.Controls.Add(this.lblRoleName);
            this.Controls.Add(this.pnlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmCreateRole";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tạo Role Mới";
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Panel pnlTop;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTitle;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblRoleName;
        private Guna.UI2.WinForms.Guna2TextBox txtRoleName;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblAuthType;
        private Guna.UI2.WinForms.Guna2ComboBox cmbAuthType;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblPassword;
        private Guna.UI2.WinForms.Guna2TextBox txtPassword;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
        private Guna.UI2.WinForms.Guna2Button btnCreate;
        private Guna.UI2.WinForms.Guna2MessageDialog msgDialog;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm2;
    }
}
