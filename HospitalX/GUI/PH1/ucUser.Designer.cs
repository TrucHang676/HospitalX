namespace HospitalX.GUI.PH1
{
    partial class ucUser
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

        #region Component Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucUser));
            this.tblMain = new System.Windows.Forms.TableLayoutPanel();
            this.pnlColLeft = new Guna.UI2.WinForms.Guna2Panel();
            this.lstUsers = new System.Windows.Forms.ListBox();
            this.pnlLeftHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.lblCol1 = new System.Windows.Forms.Label();
            this.lblCol2 = new System.Windows.Forms.Label();
            this.lblCol3 = new System.Windows.Forms.Label();
            this.lblCol4 = new System.Windows.Forms.Label();
            this.lblCol5 = new System.Windows.Forms.Label();
            this.pnlLeftFooter = new Guna.UI2.WinForms.Guna2Panel();
            this.lblPageInfo = new System.Windows.Forms.Label();
            this.lblUserCount = new System.Windows.Forms.Label();
            this.btnNext = new Guna.UI2.WinForms.Guna2Button();
            this.btnPage1 = new Guna.UI2.WinForms.Guna2Button();
            this.btnPrev = new Guna.UI2.WinForms.Guna2Button();
            this.pnlColRight = new Guna.UI2.WinForms.Guna2Panel();
            this.lstDetails = new System.Windows.Forms.ListBox();
            this.pnlPrivilegesHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.lblPrivTitle = new System.Windows.Forms.Label();
            this.pnlDetailsGrid = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlUserInfo = new Guna.UI2.WinForms.Guna2Panel();
            this.btnUserIcon = new Guna.UI2.WinForms.Guna2CircleButton();
            this.lblUsername = new System.Windows.Forms.Label();
            this.pnlRightFooter = new Guna.UI2.WinForms.Guna2Panel();
            this.btnEditInfo = new Guna.UI2.WinForms.Guna2Button();
            this.btnChangePassword = new Guna.UI2.WinForms.Guna2Button();
            this.btnLockAccount = new Guna.UI2.WinForms.Guna2Button();
            this.pnlTop = new Guna.UI2.WinForms.Guna2Panel();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.cmbFilterRole = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cmbFilterStatus = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnCreate = new Guna.UI2.WinForms.Guna2Button();
            this.tblMain.SuspendLayout();
            this.pnlColLeft.SuspendLayout();
            this.pnlLeftHeader.SuspendLayout();
            this.pnlLeftFooter.SuspendLayout();
            this.pnlColRight.SuspendLayout();
            this.pnlPrivilegesHeader.SuspendLayout();
            this.pnlUserInfo.SuspendLayout();
            this.pnlRightFooter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblMain
            // 
            this.tblMain.ColumnCount = 2;
            this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64F));
            this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36F));
            this.tblMain.Controls.Add(this.pnlColLeft, 0, 0);
            this.tblMain.Controls.Add(this.pnlColRight, 1, 0);
            this.tblMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblMain.Location = new System.Drawing.Point(0, 74);
            this.tblMain.Margin = new System.Windows.Forms.Padding(4);
            this.tblMain.Name = "tblMain";
            this.tblMain.Padding = new System.Windows.Forms.Padding(21, 20, 21, 20);
            this.tblMain.RowCount = 1;
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblMain.Size = new System.Drawing.Size(1623, 954);
            this.tblMain.TabIndex = 0;
            // 
            // pnlColLeft
            // 
            this.pnlColLeft.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(228)))), ((int)(((byte)(240)))));
            this.pnlColLeft.BorderRadius = 16;
            this.pnlColLeft.BorderThickness = 1;
            this.pnlColLeft.Controls.Add(this.lstUsers);
            this.pnlColLeft.Controls.Add(this.pnlLeftHeader);
            this.pnlColLeft.Controls.Add(this.pnlLeftFooter);
            this.pnlColLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlColLeft.FillColor = System.Drawing.Color.White;
            this.pnlColLeft.Location = new System.Drawing.Point(21, 20);
            this.pnlColLeft.Margin = new System.Windows.Forms.Padding(0, 0, 11, 0);
            this.pnlColLeft.Name = "pnlColLeft";
            this.pnlColLeft.Size = new System.Drawing.Size(1000, 914);
            this.pnlColLeft.TabIndex = 0;
            // 
            // lstUsers
            // 
            this.lstUsers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstUsers.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lstUsers.FormattingEnabled = true;
            this.lstUsers.ItemHeight = 60;
            this.lstUsers.Location = new System.Drawing.Point(0, 57);
            this.lstUsers.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.lstUsers.Name = "lstUsers";
            this.lstUsers.Size = new System.Drawing.Size(1000, 788);
            this.lstUsers.TabIndex = 0;
            // 
            // pnlLeftHeader
            // 
            this.pnlLeftHeader.BackColor = System.Drawing.Color.Transparent;
            this.pnlLeftHeader.Controls.Add(this.lblCol1);
            this.pnlLeftHeader.Controls.Add(this.lblCol2);
            this.pnlLeftHeader.Controls.Add(this.lblCol3);
            this.pnlLeftHeader.Controls.Add(this.lblCol4);
            this.pnlLeftHeader.Controls.Add(this.lblCol5);
            this.pnlLeftHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLeftHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlLeftHeader.Margin = new System.Windows.Forms.Padding(4);
            this.pnlLeftHeader.Name = "pnlLeftHeader";
            this.pnlLeftHeader.Size = new System.Drawing.Size(1000, 57);
            this.pnlLeftHeader.TabIndex = 1;
            // 
            // lblCol1
            // 
            this.lblCol1.AutoSize = true;
            this.lblCol1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCol1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(168)))), ((int)(((byte)(190)))));
            this.lblCol1.Location = new System.Drawing.Point(47, 20);
            this.lblCol1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCol1.Name = "lblCol1";
            this.lblCol1.Size = new System.Drawing.Size(102, 23);
            this.lblCol1.TabIndex = 0;
            this.lblCol1.Text = "USERNAME";
            // 
            // lblCol2
            // 
            this.lblCol2.AutoSize = true;
            this.lblCol2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCol2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(168)))), ((int)(((byte)(190)))));
            this.lblCol2.Location = new System.Drawing.Point(331, 20);
            this.lblCol2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCol2.Name = "lblCol2";
            this.lblCol2.Size = new System.Drawing.Size(52, 23);
            this.lblCol2.TabIndex = 1;
            this.lblCol2.Text = "ROLE";
            // 
            // lblCol3
            // 
            this.lblCol3.AutoSize = true;
            this.lblCol3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCol3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(168)))), ((int)(((byte)(190)))));
            this.lblCol3.Location = new System.Drawing.Point(503, 20);
            this.lblCol3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCol3.Name = "lblCol3";
            this.lblCol3.Size = new System.Drawing.Size(113, 23);
            this.lblCol3.TabIndex = 2;
            this.lblCol3.Text = "TRẠNG THÁI";
            // 
            // lblCol4
            // 
            this.lblCol4.AutoSize = true;
            this.lblCol4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCol4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(168)))), ((int)(((byte)(190)))));
            this.lblCol4.Location = new System.Drawing.Point(692, 20);
            this.lblCol4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCol4.Name = "lblCol4";
            this.lblCol4.Size = new System.Drawing.Size(96, 23);
            this.lblCol4.TabIndex = 3;
            this.lblCol4.Text = "NGÀY TẠO";
            // 
            // lblCol5
            // 
            this.lblCol5.AutoSize = true;
            this.lblCol5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCol5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(168)))), ((int)(((byte)(190)))));
            this.lblCol5.Location = new System.Drawing.Point(855, 20);
            this.lblCol5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCol5.Name = "lblCol5";
            this.lblCol5.Size = new System.Drawing.Size(95, 23);
            this.lblCol5.TabIndex = 4;
            this.lblCol5.Text = "THAO TÁC";
            // 
            // pnlLeftFooter
            // 
            this.pnlLeftFooter.BackColor = System.Drawing.Color.Transparent;
            this.pnlLeftFooter.Controls.Add(this.lblPageInfo);
            this.pnlLeftFooter.Controls.Add(this.lblUserCount);
            this.pnlLeftFooter.Controls.Add(this.btnNext);
            this.pnlLeftFooter.Controls.Add(this.btnPage1);
            this.pnlLeftFooter.Controls.Add(this.btnPrev);
            this.pnlLeftFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlLeftFooter.Location = new System.Drawing.Point(0, 845);
            this.pnlLeftFooter.Margin = new System.Windows.Forms.Padding(4);
            this.pnlLeftFooter.Name = "pnlLeftFooter";
            this.pnlLeftFooter.Size = new System.Drawing.Size(1000, 69);
            this.pnlLeftFooter.TabIndex = 2;
            // 
            // lblPageInfo
            // 
            this.lblPageInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblPageInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPageInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.lblPageInfo.Location = new System.Drawing.Point(399, 4);
            this.lblPageInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPageInfo.Name = "lblPageInfo";
            this.lblPageInfo.Size = new System.Drawing.Size(183, 63);
            this.lblPageInfo.TabIndex = 0;
            this.lblPageInfo.Text = "Trang 1 / 2";
            this.lblPageInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUserCount
            // 
            this.lblUserCount.AutoSize = true;
            this.lblUserCount.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(168)))), ((int)(((byte)(190)))));
            this.lblUserCount.Location = new System.Drawing.Point(27, 22);
            this.lblUserCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUserCount.Name = "lblUserCount";
            this.lblUserCount.Size = new System.Drawing.Size(140, 23);
            this.lblUserCount.TabIndex = 1;
            this.lblUserCount.Text = "Tổng số: 12 users";
            // 
            // btnNext
            // 
            this.btnNext.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnNext.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(228)))), ((int)(((byte)(240)))));
            this.btnNext.BorderRadius = 4;
            this.btnNext.BorderThickness = 1;
            this.btnNext.FillColor = System.Drawing.Color.White;
            this.btnNext.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnNext.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(143)))), ((int)(((byte)(168)))));
            this.btnNext.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.btnNext.Location = new System.Drawing.Point(939, 16);
            this.btnNext.Margin = new System.Windows.Forms.Padding(4);
            this.btnNext.Name = "btnNext";
            this.btnNext.PressedColor = System.Drawing.Color.LightBlue;
            this.btnNext.Size = new System.Drawing.Size(40, 37);
            this.btnNext.TabIndex = 2;
            this.btnNext.Text = ">";
            // 
            // btnPage1
            // 
            this.btnPage1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnPage1.BorderRadius = 4;
            this.btnPage1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(180)))));
            this.btnPage1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPage1.ForeColor = System.Drawing.Color.White;
            this.btnPage1.Location = new System.Drawing.Point(888, 16);
            this.btnPage1.Margin = new System.Windows.Forms.Padding(4);
            this.btnPage1.Name = "btnPage1";
            this.btnPage1.Size = new System.Drawing.Size(40, 37);
            this.btnPage1.TabIndex = 4;
            this.btnPage1.Text = "1";
            // 
            // btnPrev
            // 
            this.btnPrev.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnPrev.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(228)))), ((int)(((byte)(240)))));
            this.btnPrev.BorderRadius = 4;
            this.btnPrev.BorderThickness = 1;
            this.btnPrev.FillColor = System.Drawing.Color.White;
            this.btnPrev.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnPrev.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(143)))), ((int)(((byte)(168)))));
            this.btnPrev.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.btnPrev.Location = new System.Drawing.Point(837, 16);
            this.btnPrev.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.PressedColor = System.Drawing.Color.LightBlue;
            this.btnPrev.Size = new System.Drawing.Size(40, 37);
            this.btnPrev.TabIndex = 5;
            this.btnPrev.Text = "<";
            // 
            // pnlColRight
            // 
            this.pnlColRight.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(228)))), ((int)(((byte)(240)))));
            this.pnlColRight.BorderRadius = 16;
            this.pnlColRight.BorderThickness = 1;
            this.pnlColRight.Controls.Add(this.lstDetails);
            this.pnlColRight.Controls.Add(this.pnlPrivilegesHeader);
            this.pnlColRight.Controls.Add(this.pnlDetailsGrid);
            this.pnlColRight.Controls.Add(this.pnlUserInfo);
            this.pnlColRight.Controls.Add(this.pnlRightFooter);
            this.pnlColRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlColRight.FillColor = System.Drawing.Color.White;
            this.pnlColRight.Location = new System.Drawing.Point(1043, 20);
            this.pnlColRight.Margin = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.pnlColRight.Name = "pnlColRight";
            this.pnlColRight.Padding = new System.Windows.Forms.Padding(27, 25, 27, 25);
            this.pnlColRight.Size = new System.Drawing.Size(559, 914);
            this.pnlColRight.TabIndex = 1;
            // 
            // lstDetails
            // 
            this.lstDetails.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstDetails.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lstDetails.FormattingEnabled = true;
            this.lstDetails.ItemHeight = 40;
            this.lstDetails.Location = new System.Drawing.Point(27, 445);
            this.lstDetails.Margin = new System.Windows.Forms.Padding(4);
            this.lstDetails.Name = "lstDetails";
            this.lstDetails.Size = new System.Drawing.Size(505, 247);
            this.lstDetails.TabIndex = 0;
            // 
            // pnlPrivilegesHeader
            // 
            this.pnlPrivilegesHeader.BackColor = System.Drawing.Color.Transparent;
            this.pnlPrivilegesHeader.Controls.Add(this.lblPrivTitle);
            this.pnlPrivilegesHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPrivilegesHeader.Location = new System.Drawing.Point(27, 396);
            this.pnlPrivilegesHeader.Margin = new System.Windows.Forms.Padding(4);
            this.pnlPrivilegesHeader.Name = "pnlPrivilegesHeader";
            this.pnlPrivilegesHeader.Size = new System.Drawing.Size(505, 49);
            this.pnlPrivilegesHeader.TabIndex = 1;
            // 
            // lblPrivTitle
            // 
            this.lblPrivTitle.AutoSize = true;
            this.lblPrivTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPrivTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.lblPrivTitle.Location = new System.Drawing.Point(-3, 10);
            this.lblPrivTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPrivTitle.Name = "lblPrivTitle";
            this.lblPrivTitle.Size = new System.Drawing.Size(134, 23);
            this.lblPrivTitle.TabIndex = 0;
            this.lblPrivTitle.Text = "● Quyền đã cấp";
            // 
            // pnlDetailsGrid
            // 
            this.pnlDetailsGrid.BackColor = System.Drawing.Color.Transparent;
            this.pnlDetailsGrid.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDetailsGrid.Location = new System.Drawing.Point(27, 153);
            this.pnlDetailsGrid.Margin = new System.Windows.Forms.Padding(4);
            this.pnlDetailsGrid.Name = "pnlDetailsGrid";
            this.pnlDetailsGrid.Padding = new System.Windows.Forms.Padding(0, 12, 0, 12);
            this.pnlDetailsGrid.Size = new System.Drawing.Size(505, 243);
            this.pnlDetailsGrid.TabIndex = 2;
            // 
            // pnlUserInfo
            // 
            this.pnlUserInfo.BackColor = System.Drawing.Color.Transparent;
            this.pnlUserInfo.Controls.Add(this.btnUserIcon);
            this.pnlUserInfo.Controls.Add(this.lblUsername);
            this.pnlUserInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlUserInfo.Location = new System.Drawing.Point(27, 25);
            this.pnlUserInfo.Margin = new System.Windows.Forms.Padding(4);
            this.pnlUserInfo.Name = "pnlUserInfo";
            this.pnlUserInfo.Size = new System.Drawing.Size(505, 128);
            this.pnlUserInfo.TabIndex = 3;
            // 
            // btnUserIcon
            // 
            this.btnUserIcon.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(180)))));
            this.btnUserIcon.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUserIcon.ForeColor = System.Drawing.Color.White;
            this.btnUserIcon.Location = new System.Drawing.Point(208, 4);
            this.btnUserIcon.Margin = new System.Windows.Forms.Padding(4);
            this.btnUserIcon.Name = "btnUserIcon";
            this.btnUserIcon.Size = new System.Drawing.Size(81, 77);
            this.btnUserIcon.TabIndex = 0;
            this.btnUserIcon.Text = "BA";
            // 
            // lblUsername
            // 
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.lblUsername.Location = new System.Drawing.Point(4, 89);
            this.lblUsername.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(497, 37);
            this.lblUsername.TabIndex = 1;
            this.lblUsername.Text = "U_BACSI01";
            this.lblUsername.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlRightFooter
            // 
            this.pnlRightFooter.BackColor = System.Drawing.Color.Transparent;
            this.pnlRightFooter.Controls.Add(this.btnEditInfo);
            this.pnlRightFooter.Controls.Add(this.btnChangePassword);
            this.pnlRightFooter.Controls.Add(this.btnLockAccount);
            this.pnlRightFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlRightFooter.Location = new System.Drawing.Point(27, 692);
            this.pnlRightFooter.Margin = new System.Windows.Forms.Padding(4);
            this.pnlRightFooter.Name = "pnlRightFooter";
            this.pnlRightFooter.Size = new System.Drawing.Size(505, 197);
            this.pnlRightFooter.TabIndex = 4;
            // 
            // btnEditInfo
            // 
            this.btnEditInfo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(180)))));
            this.btnEditInfo.BorderRadius = 8;
            this.btnEditInfo.BorderThickness = 1;
            this.btnEditInfo.FillColor = System.Drawing.Color.White;
            this.btnEditInfo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(180)))));
            this.btnEditInfo.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(180)))));
            this.btnEditInfo.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnEditInfo.Location = new System.Drawing.Point(19, 12);
            this.btnEditInfo.Margin = new System.Windows.Forms.Padding(4);
            this.btnEditInfo.Name = "btnEditInfo";
            this.btnEditInfo.Size = new System.Drawing.Size(463, 49);
            this.btnEditInfo.TabIndex = 0;
            this.btnEditInfo.Text = "Chỉnh sửa thông tin";
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.btnChangePassword.BorderRadius = 8;
            this.btnChangePassword.BorderThickness = 1;
            this.btnChangePassword.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(252)))), ((int)(((byte)(235)))));
            this.btnChangePassword.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangePassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(130)))), ((int)(((byte)(0)))));
            this.btnChangePassword.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(215)))), ((int)(((byte)(135)))));
            this.btnChangePassword.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(120)))), ((int)(((byte)(7)))));
            this.btnChangePassword.Location = new System.Drawing.Point(19, 74);
            this.btnChangePassword.Margin = new System.Windows.Forms.Padding(4);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(463, 49);
            this.btnChangePassword.TabIndex = 1;
            this.btnChangePassword.Text = "Đổi mật khẩu";
            // 
            // btnLockAccount
            // 
            this.btnLockAccount.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnLockAccount.BorderRadius = 8;
            this.btnLockAccount.BorderThickness = 1;
            this.btnLockAccount.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.btnLockAccount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLockAccount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnLockAccount.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnLockAccount.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnLockAccount.Location = new System.Drawing.Point(19, 135);
            this.btnLockAccount.Margin = new System.Windows.Forms.Padding(4);
            this.btnLockAccount.Name = "btnLockAccount";
            this.btnLockAccount.Size = new System.Drawing.Size(463, 49);
            this.btnLockAccount.TabIndex = 2;
            this.btnLockAccount.Text = "Khóa tài khoản";
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.txtSearch);
            this.pnlTop.Controls.Add(this.cmbFilterRole);
            this.pnlTop.Controls.Add(this.cmbFilterStatus);
            this.pnlTop.Controls.Add(this.btnCreate);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Margin = new System.Windows.Forms.Padding(4);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Padding = new System.Windows.Forms.Padding(21, 20, 21, 0);
            this.pnlTop.Size = new System.Drawing.Size(1623, 74);
            this.pnlTop.TabIndex = 1;
            // 
            // txtSearch
            // 
            this.txtSearch.BorderRadius = 8;
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.DefaultText = "";
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearch.IconLeft = ((System.Drawing.Image)(resources.GetObject("txtSearch.IconLeft")));
            this.txtSearch.IconLeftOffset = new System.Drawing.Point(10, 0);
            this.txtSearch.IconLeftSize = new System.Drawing.Size(18, 18);
            this.txtSearch.Location = new System.Drawing.Point(21, 20);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PlaceholderText = "Tìm kiếm username...";
            this.txtSearch.SelectedText = "";
            this.txtSearch.Size = new System.Drawing.Size(840, 49);
            this.txtSearch.TabIndex = 0;
            // 
            // cmbFilterRole
            // 
            this.cmbFilterRole.BackColor = System.Drawing.Color.Transparent;
            this.cmbFilterRole.BorderRadius = 8;
            this.cmbFilterRole.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbFilterRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterRole.FocusedColor = System.Drawing.Color.Empty;
            this.cmbFilterRole.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFilterRole.ForeColor = System.Drawing.Color.Black;
            this.cmbFilterRole.ItemHeight = 34;
            this.cmbFilterRole.Items.AddRange(new object[] {
            "Tất cả role",
            "ROLE_BACSI",
            "ROLE_DPV",
            "ROLE_KTV",
            "ROLE_BN"});
            this.cmbFilterRole.Location = new System.Drawing.Point(880, 20);
            this.cmbFilterRole.Margin = new System.Windows.Forms.Padding(4);
            this.cmbFilterRole.Name = "cmbFilterRole";
            this.cmbFilterRole.Size = new System.Drawing.Size(262, 40);
            this.cmbFilterRole.StartIndex = 0;
            this.cmbFilterRole.TabIndex = 1;
            // 
            // cmbFilterStatus
            // 
            this.cmbFilterStatus.BackColor = System.Drawing.Color.Transparent;
            this.cmbFilterStatus.BorderRadius = 8;
            this.cmbFilterStatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbFilterStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterStatus.FocusedColor = System.Drawing.Color.Empty;
            this.cmbFilterStatus.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFilterStatus.ForeColor = System.Drawing.Color.Black;
            this.cmbFilterStatus.ItemHeight = 34;
            this.cmbFilterStatus.Items.AddRange(new object[] {
            "Tất cả trạng thái",
            "OPEN",
            "LOCKED"});
            this.cmbFilterStatus.Location = new System.Drawing.Point(1160, 20);
            this.cmbFilterStatus.Margin = new System.Windows.Forms.Padding(4);
            this.cmbFilterStatus.Name = "cmbFilterStatus";
            this.cmbFilterStatus.Size = new System.Drawing.Size(199, 40);
            this.cmbFilterStatus.StartIndex = 0;
            this.cmbFilterStatus.TabIndex = 2;
            // 
            // btnCreate
            // 
            this.btnCreate.BorderRadius = 8;
            this.btnCreate.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(180)))));
            this.btnCreate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCreate.ForeColor = System.Drawing.Color.White;
            this.btnCreate.Location = new System.Drawing.Point(1441, 21);
            this.btnCreate.Margin = new System.Windows.Forms.Padding(4);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(160, 49);
            this.btnCreate.TabIndex = 3;
            this.btnCreate.Text = "+ Tạo mới";
            // 
            // ucUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.Controls.Add(this.tblMain);
            this.Controls.Add(this.pnlTop);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ucUser";
            this.Size = new System.Drawing.Size(1623, 1028);
            this.tblMain.ResumeLayout(false);
            this.pnlColLeft.ResumeLayout(false);
            this.pnlLeftHeader.ResumeLayout(false);
            this.pnlLeftHeader.PerformLayout();
            this.pnlLeftFooter.ResumeLayout(false);
            this.pnlLeftFooter.PerformLayout();
            this.pnlColRight.ResumeLayout(false);
            this.pnlPrivilegesHeader.ResumeLayout(false);
            this.pnlPrivilegesHeader.PerformLayout();
            this.pnlUserInfo.ResumeLayout(false);
            this.pnlRightFooter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tblMain;
        private Guna.UI2.WinForms.Guna2Panel pnlTop;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private Guna.UI2.WinForms.Guna2ComboBox cmbFilterRole;
        private Guna.UI2.WinForms.Guna2ComboBox cmbFilterStatus;
        private Guna.UI2.WinForms.Guna2Button btnCreate;
        
        private Guna.UI2.WinForms.Guna2Panel pnlColLeft;
        private Guna.UI2.WinForms.Guna2Panel pnlColRight;
        
        private Guna.UI2.WinForms.Guna2Panel pnlLeftHeader;
        private System.Windows.Forms.Label lblCol1;
        private System.Windows.Forms.Label lblCol2;
        private System.Windows.Forms.Label lblCol3;
        private System.Windows.Forms.Label lblCol4;
        private System.Windows.Forms.Label lblCol5;
        private System.Windows.Forms.ListBox lstUsers;
        private Guna.UI2.WinForms.Guna2Panel pnlLeftFooter;
        private System.Windows.Forms.Label lblUserCount;
        private System.Windows.Forms.Label lblPageInfo;
        private Guna.UI2.WinForms.Guna2Button btnPrev;
        private Guna.UI2.WinForms.Guna2Button btnPage1;
        private Guna.UI2.WinForms.Guna2Button btnNext;

        private Guna.UI2.WinForms.Guna2Panel pnlUserInfo;
        private Guna.UI2.WinForms.Guna2CircleButton btnUserIcon;
        private System.Windows.Forms.Label lblUsername;
        
        private Guna.UI2.WinForms.Guna2Panel pnlDetailsGrid;
        private Guna.UI2.WinForms.Guna2Panel pnlPrivilegesHeader;
        private System.Windows.Forms.Label lblPrivTitle;
        private System.Windows.Forms.ListBox lstDetails;
        
        private Guna.UI2.WinForms.Guna2Panel pnlRightFooter;
        private Guna.UI2.WinForms.Guna2Button btnEditInfo;
        private Guna.UI2.WinForms.Guna2Button btnChangePassword;
        private Guna.UI2.WinForms.Guna2Button btnLockAccount;
    }
}
