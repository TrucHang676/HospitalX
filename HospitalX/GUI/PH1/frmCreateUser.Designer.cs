using Guna.UI2.WinForms;
using System.Drawing;
using System.Windows.Forms;

namespace HospitalX.GUI.PH1
{
    partial class frmCreateUser
    {
        private System.ComponentModel.IContainer components = null;
        private Guna2MessageDialog msgDialog;

        // UI Components
        private Guna2Panel pnlHeader;
        private Guna2HtmlLabel lblTitle;
        private Guna2ControlBox btnCloseBox;
        
        private Guna2HtmlLabel lblUserLabel, lblFullNameLabel, lblPassLabel, lblConfirmPassLabel, lblTablespaceLabel;
        private Guna2TextBox txtUsername, txtFullName, txtPassword, txtConfirmPassword;
        private Guna2ComboBox cmbTablespace;
        
        private Guna2Panel pnlFooter;
        private Guna2Button btnCancel, btnCreate;
        private TableLayoutPanel tblContent;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.msgDialog = new Guna.UI2.WinForms.Guna2MessageDialog();
            this.pnlHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnCloseBox = new Guna.UI2.WinForms.Guna2ControlBox();
            this.lblUserLabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblFullNameLabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblPassLabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblConfirmPassLabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblTablespaceLabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtUsername = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtFullName = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtConfirmPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.cmbTablespace = new Guna.UI2.WinForms.Guna2ComboBox();
            this.pnlFooter = new Guna.UI2.WinForms.Guna2Panel();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            this.btnCreate = new Guna.UI2.WinForms.Guna2Button();
            this.tblContent = new System.Windows.Forms.TableLayoutPanel();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.pnlHeader.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.tblContent.SuspendLayout();
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
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(180)))));
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.btnCloseBox);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(4);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(827, 74);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(33, 22);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(225, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "+ Tạo Người Dùng Mới";
            // 
            // btnCloseBox
            // 
            this.btnCloseBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCloseBox.FillColor = System.Drawing.Color.Transparent;
            this.btnCloseBox.IconColor = System.Drawing.Color.White;
            this.btnCloseBox.Location = new System.Drawing.Point(763, 15);
            this.btnCloseBox.Margin = new System.Windows.Forms.Padding(4);
            this.btnCloseBox.Name = "btnCloseBox";
            this.btnCloseBox.Size = new System.Drawing.Size(53, 43);
            this.btnCloseBox.TabIndex = 1;
            // 
            // lblUserLabel
            // 
            this.lblUserLabel.BackColor = System.Drawing.Color.Transparent;
            this.lblUserLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserLabel.Location = new System.Drawing.Point(4, 4);
            this.lblUserLabel.Margin = new System.Windows.Forms.Padding(4);
            this.lblUserLabel.Name = "lblUserLabel";
            this.lblUserLabel.Size = new System.Drawing.Size(161, 23);
            this.lblUserLabel.TabIndex = 0;
            this.lblUserLabel.Text = "USERNAME (MÃ NV)";
            // 
            // lblFullNameLabel
            // 
            this.lblFullNameLabel.BackColor = System.Drawing.Color.Transparent;
            this.tblContent.SetColumnSpan(this.lblFullNameLabel, 2);
            this.lblFullNameLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFullNameLabel.Location = new System.Drawing.Point(4, 109);
            this.lblFullNameLabel.Margin = new System.Windows.Forms.Padding(4);
            this.lblFullNameLabel.Name = "lblFullNameLabel";
            this.lblFullNameLabel.Size = new System.Drawing.Size(88, 23);
            this.lblFullNameLabel.TabIndex = 4;
            this.lblFullNameLabel.Text = "HỌ VÀ TÊN";
            // 
            // lblPassLabel
            // 
            this.lblPassLabel.BackColor = System.Drawing.Color.Transparent;
            this.lblPassLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassLabel.Location = new System.Drawing.Point(4, 214);
            this.lblPassLabel.Margin = new System.Windows.Forms.Padding(4);
            this.lblPassLabel.Name = "lblPassLabel";
            this.lblPassLabel.Size = new System.Drawing.Size(87, 23);
            this.lblPassLabel.TabIndex = 6;
            this.lblPassLabel.Text = "MẬT KHẨU";
            // 
            // lblConfirmPassLabel
            // 
            this.lblConfirmPassLabel.BackColor = System.Drawing.Color.Transparent;
            this.lblConfirmPassLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfirmPassLabel.Location = new System.Drawing.Point(386, 214);
            this.lblConfirmPassLabel.Margin = new System.Windows.Forms.Padding(13, 4, 4, 4);
            this.lblConfirmPassLabel.Name = "lblConfirmPassLabel";
            this.lblConfirmPassLabel.Size = new System.Drawing.Size(175, 23);
            this.lblConfirmPassLabel.TabIndex = 7;
            this.lblConfirmPassLabel.Text = "XÁC NHẬN MẬT KHẨU";
            // 
            // lblTablespaceLabel
            // 
            this.lblTablespaceLabel.BackColor = System.Drawing.Color.Transparent;
            this.tblContent.SetColumnSpan(this.lblTablespaceLabel, 2);
            this.lblTablespaceLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTablespaceLabel.Location = new System.Drawing.Point(4, 319);
            this.lblTablespaceLabel.Margin = new System.Windows.Forms.Padding(4);
            this.lblTablespaceLabel.Name = "lblTablespaceLabel";
            this.lblTablespaceLabel.Size = new System.Drawing.Size(185, 23);
            this.lblTablespaceLabel.TabIndex = 10;
            this.lblTablespaceLabel.Text = "TABLESPACE MẶC ĐỊNH";
            // 
            // txtUsername
            // 
            this.txtUsername.BorderRadius = 8;
            this.txtUsername.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUsername.DefaultText = "";
            this.txtUsername.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtUsername.Location = new System.Drawing.Point(0, 41);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(0, 4, 13, 12);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.PlaceholderText = "VD: U_BACSI01";
            this.txtUsername.SelectedText = "";
            this.txtUsername.Size = new System.Drawing.Size(360, 52);
            this.txtUsername.TabIndex = 2;
            // 
            // txtFullName
            // 
            this.txtFullName.BorderRadius = 8;
            this.tblContent.SetColumnSpan(this.txtFullName, 2);
            this.txtFullName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFullName.DefaultText = "";
            this.txtFullName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFullName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtFullName.Location = new System.Drawing.Point(0, 146);
            this.txtFullName.Margin = new System.Windows.Forms.Padding(0, 4, 0, 12);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.PlaceholderText = "Nhập họ tên nhân viên...";
            this.txtFullName.SelectedText = "";
            this.txtFullName.Size = new System.Drawing.Size(747, 52);
            this.txtFullName.TabIndex = 5;
            // 
            // txtPassword
            // 
            this.txtPassword.BorderRadius = 8;
            this.txtPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPassword.DefaultText = "";
            this.txtPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPassword.Location = new System.Drawing.Point(0, 251);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(0, 4, 13, 12);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.PlaceholderText = "";
            this.txtPassword.SelectedText = "";
            this.txtPassword.Size = new System.Drawing.Size(360, 52);
            this.txtPassword.TabIndex = 8;
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.BorderRadius = 8;
            this.txtConfirmPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtConfirmPassword.DefaultText = "";
            this.txtConfirmPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtConfirmPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtConfirmPassword.Location = new System.Drawing.Point(386, 251);
            this.txtConfirmPassword.Margin = new System.Windows.Forms.Padding(13, 4, 0, 12);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '●';
            this.txtConfirmPassword.PlaceholderText = "";
            this.txtConfirmPassword.SelectedText = "";
            this.txtConfirmPassword.Size = new System.Drawing.Size(361, 52);
            this.txtConfirmPassword.TabIndex = 9;
            // 
            // cmbTablespace
            // 
            this.cmbTablespace.BackColor = System.Drawing.Color.Transparent;
            this.cmbTablespace.BorderRadius = 8;
            this.tblContent.SetColumnSpan(this.cmbTablespace, 2);
            this.cmbTablespace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbTablespace.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbTablespace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTablespace.FocusedColor = System.Drawing.Color.Empty;
            this.cmbTablespace.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbTablespace.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbTablespace.ItemHeight = 34;
            this.cmbTablespace.Location = new System.Drawing.Point(0, 356);
            this.cmbTablespace.Margin = new System.Windows.Forms.Padding(0, 4, 0, 12);
            this.cmbTablespace.Name = "cmbTablespace";
            this.cmbTablespace.Size = new System.Drawing.Size(747, 40);
            this.cmbTablespace.TabIndex = 11;
            // 
            // pnlFooter
            // 
            this.pnlFooter.Controls.Add(this.btnCancel);
            this.pnlFooter.Controls.Add(this.btnCreate);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.pnlFooter.Location = new System.Drawing.Point(0, 640);
            this.pnlFooter.Margin = new System.Windows.Forms.Padding(4);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(827, 98);
            this.pnlFooter.TabIndex = 2;
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
            this.btnCancel.Location = new System.Drawing.Point(427, 25);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(147, 49);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Hủy bỏ";
            // 
            // btnCreate
            // 
            this.btnCreate.BorderRadius = 8;
            this.btnCreate.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(180)))));
            this.btnCreate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCreate.ForeColor = System.Drawing.Color.White;
            this.btnCreate.Location = new System.Drawing.Point(593, 25);
            this.btnCreate.Margin = new System.Windows.Forms.Padding(4);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(180, 49);
            this.btnCreate.TabIndex = 1;
            this.btnCreate.Text = "Xác nhận tạo";
            // 
            // tblContent
            // 
            this.tblContent.BackColor = System.Drawing.Color.Transparent;
            this.tblContent.ColumnCount = 2;
            this.tblContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblContent.Controls.Add(this.lblUserLabel, 0, 0);
            this.tblContent.Controls.Add(this.txtUsername, 0, 1);
            this.tblContent.Controls.Add(this.lblFullNameLabel, 0, 2);
            this.tblContent.Controls.Add(this.txtFullName, 0, 3);
            this.tblContent.Controls.Add(this.lblPassLabel, 0, 4);
            this.tblContent.Controls.Add(this.lblConfirmPassLabel, 1, 4);
            this.tblContent.Controls.Add(this.txtPassword, 0, 5);
            this.tblContent.Controls.Add(this.txtConfirmPassword, 1, 5);
            this.tblContent.Controls.Add(this.lblTablespaceLabel, 0, 6);
            this.tblContent.Controls.Add(this.cmbTablespace, 0, 7);
            this.tblContent.Location = new System.Drawing.Point(40, 98);
            this.tblContent.Margin = new System.Windows.Forms.Padding(4);
            this.tblContent.Name = "tblContent";
            this.tblContent.RowCount = 8;
            this.tblContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tblContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 68F));
            this.tblContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tblContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 68F));
            this.tblContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tblContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 68F));
            this.tblContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tblContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 68F));
            this.tblContent.Size = new System.Drawing.Size(747, 517);
            this.tblContent.TabIndex = 1;
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.BorderRadius = 20;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.ShadowColor = System.Drawing.Color.CornflowerBlue;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // frmCreateUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(827, 738);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.tblContent);
            this.Controls.Add(this.pnlFooter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmCreateUser";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.tblContent.ResumeLayout(false);
            this.tblContent.PerformLayout();
            this.ResumeLayout(false);

        }
        private Guna2BorderlessForm guna2BorderlessForm1;
    }
}
