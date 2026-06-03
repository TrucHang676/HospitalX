namespace HospitalX.GUI.PH2.BenhNhan
{
    partial class frmPatientAddressEdit
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
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.pnlHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.btnClose = new Guna.UI2.WinForms.Guna2ControlBox();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlBody = new Guna.UI2.WinForms.Guna2Panel();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.txtCity = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblCity = new System.Windows.Forms.Label();
            this.txtDistrict = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblDistrict = new System.Windows.Forms.Label();
            this.txtStreetName = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblStreetName = new System.Windows.Forms.Label();
            this.txtHouseNumber = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblHouseNumber = new System.Windows.Forms.Label();
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
            this.pnlHeader.Controls.Add(this.lblSubtitle);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(82)))), ((int)(((byte)(66)))));
            this.pnlHeader.Location = new System.Drawing.Point(20, 12);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(480, 104);
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
            this.btnClose.Location = new System.Drawing.Point(433, 11);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(36, 32);
            this.btnClose.TabIndex = 4;
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.BackColor = System.Drawing.Color.Transparent;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(235)))), ((int)(((byte)(225)))));
            this.lblSubtitle.Location = new System.Drawing.Point(32, 68);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(254, 19);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Nhập đủ thông tin để lưu địa chỉ mới";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(30, 22);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(233, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Chỉnh sửa địa chỉ";
            // 
            // pnlBody
            // 
            this.pnlBody.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(224)))), ((int)(((byte)(219)))));
            this.pnlBody.BorderRadius = 10;
            this.pnlBody.BorderThickness = 1;
            this.pnlBody.Controls.Add(this.btnSave);
            this.pnlBody.Controls.Add(this.txtCity);
            this.pnlBody.Controls.Add(this.lblCity);
            this.pnlBody.Controls.Add(this.txtDistrict);
            this.pnlBody.Controls.Add(this.lblDistrict);
            this.pnlBody.Controls.Add(this.txtStreetName);
            this.pnlBody.Controls.Add(this.lblStreetName);
            this.pnlBody.Controls.Add(this.txtHouseNumber);
            this.pnlBody.Controls.Add(this.lblHouseNumber);
            this.pnlBody.FillColor = System.Drawing.Color.White;
            this.pnlBody.Location = new System.Drawing.Point(20, 136);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(480, 304);
            this.pnlBody.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnSave.BorderRadius = 8;
            this.btnSave.BorderThickness = 2;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnSave.DefaultAutoSize = true;
            this.btnSave.DisabledState.BorderColor = System.Drawing.Color.Silver;
            this.btnSave.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(240)))));
            this.btnSave.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.btnSave.Enabled = false;
            this.btnSave.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(148)))), ((int)(((byte)(112)))));
            this.btnSave.Location = new System.Drawing.Point(169, 239);
            this.btnSave.Name = "btnSave";
            this.btnSave.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(79)))), ((int)(((byte)(61)))));
            this.btnSave.Size = new System.Drawing.Size(111, 29);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Lưu thay đổi";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtCity
            // 
            this.txtCity.BackColor = System.Drawing.Color.Transparent;
            this.txtCity.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(224)))), ((int)(((byte)(219)))));
            this.txtCity.BorderRadius = 8;
            this.txtCity.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCity.DefaultText = "";
            this.txtCity.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.txtCity.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.txtCity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.txtCity.Location = new System.Drawing.Point(246, 160);
            this.txtCity.Name = "txtCity";
            this.txtCity.PlaceholderText = "VD: TP.HCM";
            this.txtCity.SelectedText = "";
            this.txtCity.Size = new System.Drawing.Size(196, 42);
            this.txtCity.TabIndex = 7;
            this.txtCity.TextChanged += new System.EventHandler(this.AddressField_TextChanged);
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.BackColor = System.Drawing.Color.Transparent;
            this.lblCity.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblCity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(138)))), ((int)(((byte)(132)))));
            this.lblCity.Location = new System.Drawing.Point(248, 134);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(55, 15);
            this.lblCity.TabIndex = 6;
            this.lblCity.Text = "TỈNH/TP";
            // 
            // txtDistrict
            // 
            this.txtDistrict.BackColor = System.Drawing.Color.Transparent;
            this.txtDistrict.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(224)))), ((int)(((byte)(219)))));
            this.txtDistrict.BorderRadius = 8;
            this.txtDistrict.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDistrict.DefaultText = "";
            this.txtDistrict.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.txtDistrict.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.txtDistrict.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.txtDistrict.Location = new System.Drawing.Point(38, 160);
            this.txtDistrict.Name = "txtDistrict";
            this.txtDistrict.PlaceholderText = "VD: Quận 1";
            this.txtDistrict.SelectedText = "";
            this.txtDistrict.Size = new System.Drawing.Size(182, 42);
            this.txtDistrict.TabIndex = 5;
            this.txtDistrict.TextChanged += new System.EventHandler(this.AddressField_TextChanged);
            // 
            // lblDistrict
            // 
            this.lblDistrict.AutoSize = true;
            this.lblDistrict.BackColor = System.Drawing.Color.Transparent;
            this.lblDistrict.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblDistrict.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(138)))), ((int)(((byte)(132)))));
            this.lblDistrict.Location = new System.Drawing.Point(40, 134);
            this.lblDistrict.Name = "lblDistrict";
            this.lblDistrict.Size = new System.Drawing.Size(87, 15);
            this.lblDistrict.TabIndex = 4;
            this.lblDistrict.Text = "QUẬN/HUYỆN";
            // 
            // txtStreetName
            // 
            this.txtStreetName.BackColor = System.Drawing.Color.Transparent;
            this.txtStreetName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(224)))), ((int)(((byte)(219)))));
            this.txtStreetName.BorderRadius = 8;
            this.txtStreetName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtStreetName.DefaultText = "";
            this.txtStreetName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.txtStreetName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.txtStreetName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.txtStreetName.Location = new System.Drawing.Point(164, 62);
            this.txtStreetName.Name = "txtStreetName";
            this.txtStreetName.PlaceholderText = "VD: Nguyễn Trãi";
            this.txtStreetName.SelectedText = "";
            this.txtStreetName.Size = new System.Drawing.Size(278, 42);
            this.txtStreetName.TabIndex = 3;
            this.txtStreetName.TextChanged += new System.EventHandler(this.AddressField_TextChanged);
            // 
            // lblStreetName
            // 
            this.lblStreetName.AutoSize = true;
            this.lblStreetName.BackColor = System.Drawing.Color.Transparent;
            this.lblStreetName.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblStreetName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(138)))), ((int)(((byte)(132)))));
            this.lblStreetName.Location = new System.Drawing.Point(166, 36);
            this.lblStreetName.Name = "lblStreetName";
            this.lblStreetName.Size = new System.Drawing.Size(77, 15);
            this.lblStreetName.TabIndex = 2;
            this.lblStreetName.Text = "TÊN ĐƯỜNG";
            // 
            // txtHouseNumber
            // 
            this.txtHouseNumber.BackColor = System.Drawing.Color.Transparent;
            this.txtHouseNumber.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(224)))), ((int)(((byte)(219)))));
            this.txtHouseNumber.BorderRadius = 8;
            this.txtHouseNumber.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtHouseNumber.DefaultText = "";
            this.txtHouseNumber.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.txtHouseNumber.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.txtHouseNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.txtHouseNumber.Location = new System.Drawing.Point(38, 62);
            this.txtHouseNumber.Name = "txtHouseNumber";
            this.txtHouseNumber.PlaceholderText = "VD: 12";
            this.txtHouseNumber.SelectedText = "";
            this.txtHouseNumber.Size = new System.Drawing.Size(96, 42);
            this.txtHouseNumber.TabIndex = 1;
            this.txtHouseNumber.TextChanged += new System.EventHandler(this.AddressField_TextChanged);
            // 
            // lblHouseNumber
            // 
            this.lblHouseNumber.AutoSize = true;
            this.lblHouseNumber.BackColor = System.Drawing.Color.Transparent;
            this.lblHouseNumber.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblHouseNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(138)))), ((int)(((byte)(132)))));
            this.lblHouseNumber.Location = new System.Drawing.Point(40, 36);
            this.lblHouseNumber.Name = "lblHouseNumber";
            this.lblHouseNumber.Size = new System.Drawing.Size(52, 15);
            this.lblHouseNumber.TabIndex = 0;
            this.lblHouseNumber.Text = "SỐ NHÀ";
            // 
            // frmPatientAddressEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(245)))), ((int)(((byte)(243)))));
            this.ClientSize = new System.Drawing.Size(520, 462);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPatientAddressEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chỉnh sửa địa chỉ";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlBody.ResumeLayout(false);
            this.pnlBody.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2Panel pnlHeader;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblTitle;
        private Guna.UI2.WinForms.Guna2Panel pnlBody;
        private System.Windows.Forms.Label lblHouseNumber;
        private Guna.UI2.WinForms.Guna2TextBox txtHouseNumber;
        private Guna.UI2.WinForms.Guna2TextBox txtStreetName;
        private System.Windows.Forms.Label lblStreetName;
        private Guna.UI2.WinForms.Guna2TextBox txtDistrict;
        private System.Windows.Forms.Label lblDistrict;
        private Guna.UI2.WinForms.Guna2TextBox txtCity;
        private System.Windows.Forms.Label lblCity;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private Guna.UI2.WinForms.Guna2ControlBox btnClose;
    }
}
