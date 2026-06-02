namespace HospitalX.GUI.PH2.DieuPhoiVien
{
    partial class frmDoiMatKhau
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
            this.btnClose = new Guna.UI2.WinForms.Guna2ControlBox();
            this.pnlHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblOldPass = new System.Windows.Forms.Label();
            this.txtOldPass = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblNewPass = new System.Windows.Forms.Label();
            this.txtNewPass = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblConfirmPass = new System.Windows.Forms.Label();
            this.txtConfirmPass = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnConfirm = new Guna.UI2.WinForms.Guna2Button();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BorderRadius = 8;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FillColor = System.Drawing.Color.Transparent;
            this.btnClose.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(79)))), ((int)(((byte)(61)))));
            this.btnClose.HoverState.IconColor = System.Drawing.Color.White;
            this.btnClose.IconColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(386, 9);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(36, 32);
            this.btnClose.TabIndex = 1;
            // 
            // borderlessForm
            // 
            this.borderlessForm.BorderRadius = 16;
            this.borderlessForm.ContainerControl = this;
            this.borderlessForm.TransparentWhileDrag = true;
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.btnClose);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(434, 50);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(16, 16);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(91, 16);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Đổi mật khẩu";
            // 
            // lblOldPass
            // 
            this.lblOldPass.AutoSize = true;
            this.lblOldPass.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblOldPass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblOldPass.Location = new System.Drawing.Point(24, 70);
            this.lblOldPass.Name = "lblOldPass";
            this.lblOldPass.Size = new System.Drawing.Size(147, 19);
            this.lblOldPass.TabIndex = 1;
            this.lblOldPass.Text = "MẬT KHẨU HIỆN TẠI";
            // 
            // txtOldPass
            // 
            this.txtOldPass.BorderRadius = 8;
            this.txtOldPass.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtOldPass.DefaultText = "";
            this.txtOldPass.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtOldPass.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtOldPass.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtOldPass.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtOldPass.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtOldPass.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtOldPass.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtOldPass.Location = new System.Drawing.Point(24, 90);
            this.txtOldPass.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtOldPass.Name = "txtOldPass";
            this.txtOldPass.PasswordChar = '•';
            this.txtOldPass.PlaceholderText = "Nhập mật khẩu hiện tại...";
            this.txtOldPass.SelectedText = "";
            this.txtOldPass.Size = new System.Drawing.Size(386, 38);
            this.txtOldPass.TabIndex = 2;
            // 
            // lblNewPass
            // 
            this.lblNewPass.AutoSize = true;
            this.lblNewPass.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblNewPass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblNewPass.Location = new System.Drawing.Point(24, 142);
            this.lblNewPass.Name = "lblNewPass";
            this.lblNewPass.Size = new System.Drawing.Size(111, 19);
            this.lblNewPass.TabIndex = 3;
            this.lblNewPass.Text = "MẬT KHẨU MỚI";
            // 
            // txtNewPass
            // 
            this.txtNewPass.BorderRadius = 8;
            this.txtNewPass.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNewPass.DefaultText = "";
            this.txtNewPass.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtNewPass.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtNewPass.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNewPass.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNewPass.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNewPass.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNewPass.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNewPass.Location = new System.Drawing.Point(24, 162);
            this.txtNewPass.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNewPass.Name = "txtNewPass";
            this.txtNewPass.PasswordChar = '•';
            this.txtNewPass.PlaceholderText = "Nhập mật khẩu mới...";
            this.txtNewPass.SelectedText = "";
            this.txtNewPass.Size = new System.Drawing.Size(386, 38);
            this.txtNewPass.TabIndex = 4;
            // 
            // lblConfirmPass
            // 
            this.lblConfirmPass.AutoSize = true;
            this.lblConfirmPass.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblConfirmPass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblConfirmPass.Location = new System.Drawing.Point(24, 214);
            this.lblConfirmPass.Name = "lblConfirmPass";
            this.lblConfirmPass.Size = new System.Drawing.Size(183, 19);
            this.lblConfirmPass.TabIndex = 5;
            this.lblConfirmPass.Text = "NHẬP LẠI MẬT KHẨU MỚI";
            // 
            // txtConfirmPass
            // 
            this.txtConfirmPass.BorderRadius = 8;
            this.txtConfirmPass.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtConfirmPass.DefaultText = "";
            this.txtConfirmPass.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtConfirmPass.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtConfirmPass.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtConfirmPass.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtConfirmPass.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtConfirmPass.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtConfirmPass.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtConfirmPass.Location = new System.Drawing.Point(24, 234);
            this.txtConfirmPass.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtConfirmPass.Name = "txtConfirmPass";
            this.txtConfirmPass.PasswordChar = '•';
            this.txtConfirmPass.PlaceholderText = "Nhập lại mật khẩu mới...";
            this.txtConfirmPass.SelectedText = "";
            this.txtConfirmPass.Size = new System.Drawing.Size(386, 38);
            this.txtConfirmPass.TabIndex = 6;
            // 
            // btnConfirm
            // 
            this.btnConfirm.BorderRadius = 8;
            this.btnConfirm.Location = new System.Drawing.Point(292, 296);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(118, 38);
            this.btnConfirm.TabIndex = 7;
            this.btnConfirm.Text = "Xác nhận";
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BorderRadius = 8;
            this.btnCancel.Location = new System.Drawing.Point(158, 296);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(118, 38);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Hủy bỏ";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmDoiMatKhau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(246)))));
            this.ClientSize = new System.Drawing.Size(434, 356);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.txtConfirmPass);
            this.Controls.Add(this.lblConfirmPass);
            this.Controls.Add(this.txtNewPass);
            this.Controls.Add(this.lblNewPass);
            this.Controls.Add(this.txtOldPass);
            this.Controls.Add(this.lblOldPass);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDoiMatKhau";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Đổi mật khẩu";
            this.Load += new System.EventHandler(this.frmDoiMatKhau_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm borderlessForm;
        private Guna.UI2.WinForms.Guna2ControlBox btnClose;
        private Guna.UI2.WinForms.Guna2Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblOldPass;
        private Guna.UI2.WinForms.Guna2TextBox txtOldPass;
        private System.Windows.Forms.Label lblNewPass;
        private Guna.UI2.WinForms.Guna2TextBox txtNewPass;
        private System.Windows.Forms.Label lblConfirmPass;
        private Guna.UI2.WinForms.Guna2TextBox txtConfirmPass;
        private Guna.UI2.WinForms.Guna2Button btnConfirm;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
    }
}
