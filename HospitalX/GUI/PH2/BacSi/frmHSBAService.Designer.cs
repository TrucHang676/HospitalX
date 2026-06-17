namespace HospitalX.GUI.PH2.BacSi
{
    partial class frmHSBAService
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
            this.lstCurrentServices = new System.Windows.Forms.ListBox();
            this.lblCurrentHint = new System.Windows.Forms.Label();
            this.lblCurrentTitle = new System.Windows.Forms.Label();
            this.pnlNew = new Guna.UI2.WinForms.Guna2Panel();
            this.lblNoteTitle = new System.Windows.Forms.Label();
            this.txtServiceNote = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblNameTitle = new System.Windows.Forms.Label();
            this.txtServiceName = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblNewTitle = new System.Windows.Forms.Label();
            this.btnAdd = new Guna.UI2.WinForms.Guna2Button();
            this.btnDelete = new Guna.UI2.WinForms.Guna2Button();
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
            this.pnlHeader.Size = new System.Drawing.Size(852, 100);
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
            this.btnCloseBox.Location = new System.Drawing.Point(808, 9);
            this.btnCloseBox.Name = "btnCloseBox";
            this.btnCloseBox.Size = new System.Drawing.Size(36, 32);
            this.btnCloseBox.TabIndex = 3;
            // 
            // lblHsbaId
            // 
            this.lblHsbaId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(244)))), ((int)(((byte)(240)))));
            this.lblHsbaId.Font = new System.Drawing.Font("Consolas", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblHsbaId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.lblHsbaId.Location = new System.Drawing.Point(700, 48);
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
            this.lblPatient.Location = new System.Drawing.Point(30, 65);
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
            this.lblTitle.Location = new System.Drawing.Point(30, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(221, 45);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Thêm dịch vụ";
            // 
            // pnlCurrent
            // 
            this.pnlCurrent.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.pnlCurrent.BorderRadius = 10;
            this.pnlCurrent.BorderThickness = 1;
            this.pnlCurrent.Controls.Add(this.lstCurrentServices);
            this.pnlCurrent.Controls.Add(this.lblCurrentHint);
            this.pnlCurrent.Controls.Add(this.lblCurrentTitle);
            this.pnlCurrent.FillColor = System.Drawing.Color.White;
            this.pnlCurrent.Location = new System.Drawing.Point(24, 140);
            this.pnlCurrent.Name = "pnlCurrent";
            this.pnlCurrent.Size = new System.Drawing.Size(380, 370);
            this.pnlCurrent.TabIndex = 1;
            // 
            // lstCurrentServices
            // 
            this.lstCurrentServices.BackColor = System.Drawing.Color.White;
            this.lstCurrentServices.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstCurrentServices.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lstCurrentServices.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(82)))), ((int)(((byte)(73)))));
            this.lstCurrentServices.FormattingEnabled = true;
            this.lstCurrentServices.ItemHeight = 21;
            this.lstCurrentServices.Location = new System.Drawing.Point(26, 95);
            this.lstCurrentServices.Name = "lstCurrentServices";
            this.lstCurrentServices.Size = new System.Drawing.Size(330, 231);
            this.lstCurrentServices.TabIndex = 2;
            // 
            // lblCurrentHint
            // 
            this.lblCurrentHint.AutoSize = true;
            this.lblCurrentHint.BackColor = System.Drawing.Color.White;
            this.lblCurrentHint.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentHint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblCurrentHint.Location = new System.Drawing.Point(25, 60);
            this.lblCurrentHint.Name = "lblCurrentHint";
            this.lblCurrentHint.Size = new System.Drawing.Size(240, 20);
            this.lblCurrentHint.TabIndex = 1;
            this.lblCurrentHint.Text = "Các dịch vụ đã chỉ định cho HSBA";
            // 
            // lblCurrentTitle
            // 
            this.lblCurrentTitle.AutoSize = true;
            this.lblCurrentTitle.BackColor = System.Drawing.Color.White;
            this.lblCurrentTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblCurrentTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(42)))));
            this.lblCurrentTitle.Location = new System.Drawing.Point(24, 22);
            this.lblCurrentTitle.Name = "lblCurrentTitle";
            this.lblCurrentTitle.Size = new System.Drawing.Size(142, 25);
            this.lblCurrentTitle.TabIndex = 0;
            this.lblCurrentTitle.Text = "Dịch vụ đã làm";
            // 
            // pnlNew
            // 
            this.pnlNew.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.pnlNew.BorderRadius = 10;
            this.pnlNew.BorderThickness = 1;
            this.pnlNew.Controls.Add(this.lblNoteTitle);
            this.pnlNew.Controls.Add(this.txtServiceNote);
            this.pnlNew.Controls.Add(this.lblNameTitle);
            this.pnlNew.Controls.Add(this.txtServiceName);
            this.pnlNew.Controls.Add(this.lblNewTitle);
            this.pnlNew.FillColor = System.Drawing.Color.White;
            this.pnlNew.Location = new System.Drawing.Point(428, 140);
            this.pnlNew.Name = "pnlNew";
            this.pnlNew.Size = new System.Drawing.Size(448, 370);
            this.pnlNew.TabIndex = 2;
            // 
            // lblNoteTitle
            // 
            this.lblNoteTitle.AutoSize = true;
            this.lblNoteTitle.BackColor = System.Drawing.Color.White;
            this.lblNoteTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblNoteTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblNoteTitle.Location = new System.Drawing.Point(27, 180);
            this.lblNoteTitle.Name = "lblNoteTitle";
            this.lblNoteTitle.Size = new System.Drawing.Size(150, 20);
            this.lblNoteTitle.TabIndex = 4;
            this.lblNoteTitle.Text = "GHI CHÚ / KẾT QUẢ";
            // 
            // txtServiceNote
            // 
            this.txtServiceNote.BackColor = System.Drawing.Color.Transparent;
            this.txtServiceNote.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.txtServiceNote.BorderRadius = 8;
            this.txtServiceNote.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtServiceNote.DefaultText = "";
            this.txtServiceNote.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(248)))));
            this.txtServiceNote.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.txtServiceNote.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtServiceNote.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(148)))), ((int)(((byte)(112)))));
            this.txtServiceNote.Location = new System.Drawing.Point(28, 205);
            this.txtServiceNote.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtServiceNote.Multiline = true;
            this.txtServiceNote.Name = "txtServiceNote";
            this.txtServiceNote.PlaceholderText = "Ghi chú hoặc kết quả ban đầu...";
            this.txtServiceNote.SelectedText = "";
            this.txtServiceNote.Size = new System.Drawing.Size(390, 100);
            this.txtServiceNote.TabIndex = 3;
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.AutoSize = true;
            this.lblNameTitle.BackColor = System.Drawing.Color.White;
            this.lblNameTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblNameTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblNameTitle.Location = new System.Drawing.Point(27, 60);
            this.lblNameTitle.Name = "lblNameTitle";
            this.lblNameTitle.Size = new System.Drawing.Size(103, 20);
            this.lblNameTitle.TabIndex = 2;
            this.lblNameTitle.Text = "TÊN DỊCH VỤ";
            // 
            // txtServiceName
            // 
            this.txtServiceName.BackColor = System.Drawing.Color.Transparent;
            this.txtServiceName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.txtServiceName.BorderRadius = 8;
            this.txtServiceName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtServiceName.DefaultText = "";
            this.txtServiceName.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(248)))));
            this.txtServiceName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.txtServiceName.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtServiceName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(148)))), ((int)(((byte)(112)))));
            this.txtServiceName.Location = new System.Drawing.Point(28, 85);
            this.txtServiceName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtServiceName.Name = "txtServiceName";
            this.txtServiceName.PlaceholderText = "Tên dịch vụ cần thêm...";
            this.txtServiceName.SelectedText = "";
            this.txtServiceName.Size = new System.Drawing.Size(390, 66);
            this.txtServiceName.TabIndex = 1;
            // 
            // lblNewTitle
            // 
            this.lblNewTitle.AutoSize = true;
            this.lblNewTitle.BackColor = System.Drawing.Color.White;
            this.lblNewTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblNewTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(42)))));
            this.lblNewTitle.Location = new System.Drawing.Point(24, 22);
            this.lblNewTitle.Name = "lblNewTitle";
            this.lblNewTitle.Size = new System.Drawing.Size(117, 25);
            this.lblNewTitle.TabIndex = 0;
            this.lblNewTitle.Text = "Dịch vụ mới";
            // 
            // btnAdd
            // 
            this.btnAdd.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnAdd.BorderRadius = 8;
            this.btnAdd.BorderThickness = 2;
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.DefaultAutoSize = true;
            this.btnAdd.DisabledState.BorderColor = System.Drawing.Color.Silver;
            this.btnAdd.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(240)))));
            this.btnAdd.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.btnAdd.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(148)))), ((int)(((byte)(112)))));
            this.btnAdd.Location = new System.Drawing.Point(722, 525);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(79)))), ((int)(((byte)(61)))));
            this.btnAdd.Size = new System.Drawing.Size(154, 37);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Thêm dịch vụ";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BorderColor = System.Drawing.Color.DarkRed;
            this.btnDelete.BorderRadius = 8;
            this.btnDelete.BorderThickness = 2;
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.DefaultAutoSize = true;
            this.btnDelete.DisabledState.BorderColor = System.Drawing.Color.Silver;
            this.btnDelete.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(240)))));
            this.btnDelete.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.btnDelete.Enabled = false;
            this.btnDelete.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(58)))), ((int)(((byte)(46)))));
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(67)))), ((int)(((byte)(53)))));
            this.btnDelete.Location = new System.Drawing.Point(24, 525);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(49)))), ((int)(((byte)(38)))));
            this.btnDelete.Size = new System.Drawing.Size(138, 37);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Xóa dịch vụ";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // frmHSBAService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(245)))), ((int)(((byte)(243)))));
            this.ClientSize = new System.Drawing.Size(900, 580);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.pnlNew);
            this.Controls.Add(this.pnlCurrent);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmHSBAService";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thêm dịch vụ";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlCurrent.ResumeLayout(false);
            this.pnlCurrent.PerformLayout();
            this.pnlNew.ResumeLayout(false);
            this.pnlNew.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.ListBox lstCurrentServices;
        private Guna.UI2.WinForms.Guna2Panel pnlNew;
        private System.Windows.Forms.Label lblNewTitle;
        private System.Windows.Forms.Label lblNameTitle;
        private Guna.UI2.WinForms.Guna2TextBox txtServiceName;
        private System.Windows.Forms.Label lblNoteTitle;
        private Guna.UI2.WinForms.Guna2TextBox txtServiceNote;
        private Guna.UI2.WinForms.Guna2Button btnAdd;
        private Guna.UI2.WinForms.Guna2Button btnDelete;
    }
}
