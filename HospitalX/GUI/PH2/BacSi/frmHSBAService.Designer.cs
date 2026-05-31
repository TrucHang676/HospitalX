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
            this.pnlMain = new Guna.UI2.WinForms.Guna2Panel();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.btnAdd = new Guna.UI2.WinForms.Guna2Button();
            this.txtServiceNote = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtServiceName = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblNewTitle = new System.Windows.Forms.Label();
            this.lstCurrentServices = new System.Windows.Forms.ListBox();
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
            this.pnlMain.Controls.Add(this.txtServiceNote);
            this.pnlMain.Controls.Add(this.txtServiceName);
            this.pnlMain.Controls.Add(this.lblNewTitle);
            this.pnlMain.Controls.Add(this.lstCurrentServices);
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
            this.btnAdd.Text = "Thêm dịch vụ";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtServiceNote
            // 
            this.txtServiceNote.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.txtServiceNote.BorderRadius = 8;
            this.txtServiceNote.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtServiceNote.DefaultText = "";
            this.txtServiceNote.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(248)))));
            this.txtServiceNote.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.txtServiceNote.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtServiceNote.Location = new System.Drawing.Point(40, 302);
            this.txtServiceNote.Multiline = true;
            this.txtServiceNote.Name = "txtServiceNote";
            this.txtServiceNote.PlaceholderText = "Ghi chú/kết quả ban đầu...";
            this.txtServiceNote.SelectedText = "";
            this.txtServiceNote.Size = new System.Drawing.Size(484, 58);
            this.txtServiceNote.TabIndex = 6;
            // 
            // txtServiceName
            // 
            this.txtServiceName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.txtServiceName.BorderRadius = 8;
            this.txtServiceName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtServiceName.DefaultText = "";
            this.txtServiceName.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(248)))));
            this.txtServiceName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.txtServiceName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtServiceName.Location = new System.Drawing.Point(40, 248);
            this.txtServiceName.Name = "txtServiceName";
            this.txtServiceName.PlaceholderText = "Tên dịch vụ cần thêm...";
            this.txtServiceName.SelectedText = "";
            this.txtServiceName.Size = new System.Drawing.Size(484, 40);
            this.txtServiceName.TabIndex = 5;
            // 
            // lblNewTitle
            // 
            this.lblNewTitle.AutoSize = true;
            this.lblNewTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblNewTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(42)))));
            this.lblNewTitle.Location = new System.Drawing.Point(36, 218);
            this.lblNewTitle.Name = "lblNewTitle";
            this.lblNewTitle.Size = new System.Drawing.Size(102, 19);
            this.lblNewTitle.TabIndex = 4;
            this.lblNewTitle.Text = "Dịch vụ mới";
            // 
            // lstCurrentServices
            // 
            this.lstCurrentServices.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstCurrentServices.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lstCurrentServices.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(82)))), ((int)(((byte)(73)))));
            this.lstCurrentServices.FormattingEnabled = true;
            this.lstCurrentServices.ItemHeight = 17;
            this.lstCurrentServices.Location = new System.Drawing.Point(40, 120);
            this.lstCurrentServices.Name = "lstCurrentServices";
            this.lstCurrentServices.Size = new System.Drawing.Size(484, 85);
            this.lstCurrentServices.TabIndex = 3;
            // 
            // lblCurrentTitle
            // 
            this.lblCurrentTitle.AutoSize = true;
            this.lblCurrentTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCurrentTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(42)))));
            this.lblCurrentTitle.Location = new System.Drawing.Point(36, 88);
            this.lblCurrentTitle.Name = "lblCurrentTitle";
            this.lblCurrentTitle.Size = new System.Drawing.Size(133, 19);
            this.lblCurrentTitle.TabIndex = 2;
            this.lblCurrentTitle.Text = "Dịch vụ đã làm";
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
            this.lblTitle.Size = new System.Drawing.Size(131, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Thêm dịch vụ";
            // 
            // frmHSBAService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(245)))), ((int)(((byte)(243)))));
            this.ClientSize = new System.Drawing.Size(600, 480);
            this.Controls.Add(this.pnlMain);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmHSBAService";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thêm dịch vụ";
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.ResumeLayout(false);

        }

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2Panel pnlMain;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblPatient;
        private System.Windows.Forms.Label lblCurrentTitle;
        private System.Windows.Forms.ListBox lstCurrentServices;
        private System.Windows.Forms.Label lblNewTitle;
        private Guna.UI2.WinForms.Guna2TextBox txtServiceName;
        private Guna.UI2.WinForms.Guna2TextBox txtServiceNote;
        private Guna.UI2.WinForms.Guna2Button btnAdd;
        private Guna.UI2.WinForms.Guna2Button btnClose;
    }
}
