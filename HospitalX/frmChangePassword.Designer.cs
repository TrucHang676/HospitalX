using System;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace HospitalX
{
    partial class frmChangePassword
    {
        private System.ComponentModel.IContainer components = null;
        private Guna2MessageDialog msgDialog;

        // UI Components
        private Guna2Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private Guna2ControlBox btnClose;
        
        private Guna2Panel pnlInfo;
        private System.Windows.Forms.Label lblUserLabel;
        private System.Windows.Forms.Label lblUsernameDisplay;
        
        private Guna2Panel pnlContent;
        private System.Windows.Forms.Label lblPassLabel;
        private Guna2TextBox txtNewPassword;
        private System.Windows.Forms.Label lblConfirmPassLabel;
        private Guna2TextBox txtConfirmPassword;
        
        private Guna2Panel pnlFooter;
        private Guna2Button btnCancel;
        private Guna2Button btnConfirm;

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
            this.msgDialog = new Guna.UI2.WinForms.Guna2MessageDialog();
            this.pnlHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnClose = new Guna.UI2.WinForms.Guna2ControlBox();
            this.pnlInfo = new Guna.UI2.WinForms.Guna2Panel();
            this.lblUserLabel = new System.Windows.Forms.Label();
            this.lblUsernameDisplay = new System.Windows.Forms.Label();
            this.pnlContent = new Guna.UI2.WinForms.Guna2Panel();
            this.lblPassLabel = new System.Windows.Forms.Label();
            this.txtNewPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblConfirmPassLabel = new System.Windows.Forms.Label();
            this.txtConfirmPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.pnlFooter = new Guna.UI2.WinForms.Guna2Panel();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            this.btnConfirm = new Guna.UI2.WinForms.Guna2Button();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.pnlHeader.SuspendLayout();
            this.pnlInfo.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
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
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.btnClose);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(180)))));
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(375, 57);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(19, 16);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(284, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "ĐỔI MẬT KHẨU NGƯỜI DÙNG";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.FillColor = System.Drawing.Color.Transparent;
            this.btnClose.IconColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(562, 8);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(34, 24);
            this.btnClose.TabIndex = 1;
            // 
            // pnlInfo
            // 
            this.pnlInfo.BorderRadius = 10;
            this.pnlInfo.Controls.Add(this.lblUserLabel);
            this.pnlInfo.Controls.Add(this.lblUsernameDisplay);
            this.pnlInfo.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.pnlInfo.Location = new System.Drawing.Point(22, 77);
            this.pnlInfo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(330, 65);
            this.pnlInfo.TabIndex = 1;
            // 
            // lblUserLabel
            // 
            this.lblUserLabel.AutoSize = true;
            this.lblUserLabel.BackColor = System.Drawing.Color.Transparent;
            this.lblUserLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(168)))), ((int)(((byte)(190)))));
            this.lblUserLabel.Location = new System.Drawing.Point(11, 10);
            this.lblUserLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUserLabel.Name = "lblUserLabel";
            this.lblUserLabel.Size = new System.Drawing.Size(157, 17);
            this.lblUserLabel.TabIndex = 0;
            this.lblUserLabel.Text = "Tài khoản đang thực hiện:";
            // 
            // lblUsernameDisplay
            // 
            this.lblUsernameDisplay.AutoSize = true;
            this.lblUsernameDisplay.BackColor = System.Drawing.Color.Transparent;
            this.lblUsernameDisplay.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblUsernameDisplay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.lblUsernameDisplay.Location = new System.Drawing.Point(11, 28);
            this.lblUsernameDisplay.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUsernameDisplay.Name = "lblUsernameDisplay";
            this.lblUsernameDisplay.Size = new System.Drawing.Size(92, 21);
            this.lblUsernameDisplay.TabIndex = 1;
            this.lblUsernameDisplay.Text = "U_BACSI01";
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.lblPassLabel);
            this.pnlContent.Controls.Add(this.txtNewPassword);
            this.pnlContent.Controls.Add(this.lblConfirmPassLabel);
            this.pnlContent.Controls.Add(this.txtConfirmPassword);
            this.pnlContent.Location = new System.Drawing.Point(22, 154);
            this.pnlContent.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(330, 146);
            this.pnlContent.TabIndex = 2;
            // 
            // lblPassLabel
            // 
            this.lblPassLabel.AutoSize = true;
            this.lblPassLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.lblPassLabel.Location = new System.Drawing.Point(0, 8);
            this.lblPassLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPassLabel.Name = "lblPassLabel";
            this.lblPassLabel.Size = new System.Drawing.Size(107, 17);
            this.lblPassLabel.TabIndex = 0;
            this.lblPassLabel.Text = "MẬT KHẨU MỚI";
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.BorderRadius = 8;
            this.txtNewPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNewPassword.DefaultText = "";
            this.txtNewPassword.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewPassword.IconRightCursor = System.Windows.Forms.Cursors.Hand;
            this.txtNewPassword.IconRightOffset = new System.Drawing.Point(10, 0);
            this.txtNewPassword.Location = new System.Drawing.Point(0, 28);
            this.txtNewPassword.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.PasswordChar = '●';
            this.txtNewPassword.PlaceholderText = "Nhập mật khẩu mới...";
            this.txtNewPassword.SelectedText = "";
            this.txtNewPassword.Size = new System.Drawing.Size(330, 37);
            this.txtNewPassword.TabIndex = 1;
            this.txtNewPassword.IconRightClick += new System.EventHandler(this.txtNewPassword_IconRightClick);
            this.txtNewPassword.MouseLeave += new System.EventHandler(this.txtNewPassword_MouseLeave);
            this.txtNewPassword.MouseMove += new System.Windows.Forms.MouseEventHandler(this.txtNewPassword_MouseMove);
            // 
            // lblConfirmPassLabel
            // 
            this.lblConfirmPassLabel.AutoSize = true;
            this.lblConfirmPassLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfirmPassLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.lblConfirmPassLabel.Location = new System.Drawing.Point(0, 77);
            this.lblConfirmPassLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblConfirmPassLabel.Name = "lblConfirmPassLabel";
            this.lblConfirmPassLabel.Size = new System.Drawing.Size(150, 17);
            this.lblConfirmPassLabel.TabIndex = 2;
            this.lblConfirmPassLabel.Text = "XÁC NHẬN MẬT KHẨU";
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.BorderRadius = 8;
            this.txtConfirmPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtConfirmPassword.DefaultText = "";
            this.txtConfirmPassword.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirmPassword.IconRightCursor = System.Windows.Forms.Cursors.Hand;
            this.txtConfirmPassword.IconRightOffset = new System.Drawing.Point(10, 0);
            this.txtConfirmPassword.Location = new System.Drawing.Point(0, 98);
            this.txtConfirmPassword.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '●';
            this.txtConfirmPassword.PlaceholderText = "Nhập lại mật khẩu mới...";
            this.txtConfirmPassword.SelectedText = "";
            this.txtConfirmPassword.Size = new System.Drawing.Size(330, 37);
            this.txtConfirmPassword.TabIndex = 3;
            this.txtConfirmPassword.IconRightClick += new System.EventHandler(this.txtConfirmPassword_IconRightClick);
            this.txtConfirmPassword.MouseLeave += new System.EventHandler(this.txtConfirmPassword_MouseLeave);
            this.txtConfirmPassword.MouseMove += new System.Windows.Forms.MouseEventHandler(this.txtConfirmPassword_MouseMove);
            // 
            // pnlFooter
            // 
            this.pnlFooter.Controls.Add(this.btnCancel);
            this.pnlFooter.Controls.Add(this.btnConfirm);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.pnlFooter.Location = new System.Drawing.Point(0, 317);
            this.pnlFooter.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(375, 73);
            this.pnlFooter.TabIndex = 3;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(228)))), ((int)(((byte)(240)))));
            this.btnCancel.BorderRadius = 8;
            this.btnCancel.BorderThickness = 1;
            this.btnCancel.FillColor = System.Drawing.Color.White;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.btnCancel.Location = new System.Drawing.Point(105, 20);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(98, 37);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Hủy bỏ";
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.Color.Transparent;
            this.btnConfirm.BorderRadius = 8;
            this.btnConfirm.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(180)))));
            this.btnConfirm.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnConfirm.ForeColor = System.Drawing.Color.White;
            this.btnConfirm.Location = new System.Drawing.Point(214, 20);
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(139, 37);
            this.btnConfirm.TabIndex = 1;
            this.btnConfirm.Text = "Xác nhận đổi";
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.BorderRadius = 20;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.ShadowColor = System.Drawing.Color.CornflowerBlue;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // frmChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(375, 390);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlInfo);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlFooter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmChangePassword";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlInfo.ResumeLayout(false);
            this.pnlInfo.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private Guna2BorderlessForm guna2BorderlessForm1;
    }
}
