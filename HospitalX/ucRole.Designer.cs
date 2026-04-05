namespace HospitalX
{
    partial class ucRole
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucRole));
            this.tblMain = new System.Windows.Forms.TableLayoutPanel();
            this.pnlColLeft = new Guna.UI2.WinForms.Guna2Panel();
            this.lstRoles = new System.Windows.Forms.ListBox();
            this.pnlLeftHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.lblCol1 = new System.Windows.Forms.Label();
            this.lblCol2 = new System.Windows.Forms.Label();
            this.lblCol3 = new System.Windows.Forms.Label();
            this.pnlLeftFooter = new Guna.UI2.WinForms.Guna2Panel();
            this.lblRoleCount = new System.Windows.Forms.Label();
            this.btnNext = new Guna.UI2.WinForms.Guna2Button();
            this.btnPage1 = new Guna.UI2.WinForms.Guna2Button();
            this.btnPrev = new Guna.UI2.WinForms.Guna2Button();
            this.pnlColRight = new Guna.UI2.WinForms.Guna2Panel();
            this.lstDetails = new System.Windows.Forms.ListBox();
            this.pnlDetailsHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlTabs = new Guna.UI2.WinForms.Guna2Panel();
            this.btnTabMembers = new Guna.UI2.WinForms.Guna2Button();
            this.btnTabPrivileges = new Guna.UI2.WinForms.Guna2Button();
            this.pnlStats = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlStatMember = new Guna.UI2.WinForms.Guna2Panel();
            this.lblStatMemberVal = new System.Windows.Forms.Label();
            this.lblStatMemberTxt = new System.Windows.Forms.Label();
            this.pnlStatPriv = new Guna.UI2.WinForms.Guna2Panel();
            this.lblStatPrivVal = new System.Windows.Forms.Label();
            this.lblStatPrivTxt = new System.Windows.Forms.Label();
            this.pnlRoleInfo = new Guna.UI2.WinForms.Guna2Panel();
            this.btnRoleIcon = new Guna.UI2.WinForms.Guna2CircleButton();
            this.lblRoleName = new System.Windows.Forms.Label();
            this.lblRoleSub = new System.Windows.Forms.Label();
            this.pnlRightFooter = new Guna.UI2.WinForms.Guna2Panel();
            this.btnDelete = new Guna.UI2.WinForms.Guna2Button();
            this.pnlTop = new Guna.UI2.WinForms.Guna2Panel();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.pnlSearchSpacer = new Guna.UI2.WinForms.Guna2Panel();
            this.btnCreate = new Guna.UI2.WinForms.Guna2Button();
            this.tblMain.SuspendLayout();
            this.pnlColLeft.SuspendLayout();
            this.pnlLeftHeader.SuspendLayout();
            this.pnlLeftFooter.SuspendLayout();
            this.pnlColRight.SuspendLayout();
            this.pnlTabs.SuspendLayout();
            this.pnlStats.SuspendLayout();
            this.pnlStatMember.SuspendLayout();
            this.pnlStatPriv.SuspendLayout();
            this.pnlRoleInfo.SuspendLayout();
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
            this.tblMain.Location = new System.Drawing.Point(0, 60);
            this.tblMain.Name = "tblMain";
            this.tblMain.Padding = new System.Windows.Forms.Padding(16);
            this.tblMain.RowCount = 1;
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblMain.Size = new System.Drawing.Size(1217, 775);
            this.tblMain.TabIndex = 0;
            // 
            // pnlColLeft
            // 
            this.pnlColLeft.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(228)))), ((int)(((byte)(240)))));
            this.pnlColLeft.BorderRadius = 16;
            this.pnlColLeft.BorderThickness = 1;
            this.pnlColLeft.Controls.Add(this.lstRoles);
            this.pnlColLeft.Controls.Add(this.pnlLeftHeader);
            this.pnlColLeft.Controls.Add(this.pnlLeftFooter);
            this.pnlColLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlColLeft.FillColor = System.Drawing.Color.White;
            this.pnlColLeft.Location = new System.Drawing.Point(16, 16);
            this.pnlColLeft.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.pnlColLeft.Name = "pnlColLeft";
            this.pnlColLeft.Size = new System.Drawing.Size(750, 743);
            this.pnlColLeft.TabIndex = 0;
            // 
            // lstRoles
            // 
            this.lstRoles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstRoles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstRoles.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lstRoles.FormattingEnabled = true;
            this.lstRoles.ItemHeight = 70;
            this.lstRoles.Location = new System.Drawing.Point(0, 46);
            this.lstRoles.Margin = new System.Windows.Forms.Padding(5);
            this.lstRoles.Name = "lstRoles";
            this.lstRoles.Size = new System.Drawing.Size(750, 641);
            this.lstRoles.TabIndex = 0;
            // 
            // pnlLeftHeader
            // 
            this.pnlLeftHeader.BackColor = System.Drawing.Color.Transparent;
            this.pnlLeftHeader.Controls.Add(this.lblCol1);
            this.pnlLeftHeader.Controls.Add(this.lblCol2);
            this.pnlLeftHeader.Controls.Add(this.lblCol3);
            this.pnlLeftHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLeftHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlLeftHeader.Name = "pnlLeftHeader";
            this.pnlLeftHeader.Size = new System.Drawing.Size(750, 46);
            this.pnlLeftHeader.TabIndex = 1;
            // 
            // lblCol1
            // 
            this.lblCol1.AutoSize = true;
            this.lblCol1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCol1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(168)))), ((int)(((byte)(190)))));
            this.lblCol1.Location = new System.Drawing.Point(20, 16);
            this.lblCol1.Name = "lblCol1";
            this.lblCol1.Size = new System.Drawing.Size(69, 17);
            this.lblCol1.TabIndex = 0;
            this.lblCol1.Text = "TÊN ROLE";
            // 
            // lblCol2
            // 
            this.lblCol2.AutoSize = true;
            this.lblCol2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCol2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(168)))), ((int)(((byte)(190)))));
            this.lblCol2.Location = new System.Drawing.Point(350, 16);
            this.lblCol2.Name = "lblCol2";
            this.lblCol2.Size = new System.Drawing.Size(89, 17);
            this.lblCol2.TabIndex = 1;
            this.lblCol2.Text = "THÀNH VIÊN";
            // 
            // lblCol3
            // 
            this.lblCol3.AutoSize = true;
            this.lblCol3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCol3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(168)))), ((int)(((byte)(190)))));
            this.lblCol3.Location = new System.Drawing.Point(500, 16);
            this.lblCol3.Name = "lblCol3";
            this.lblCol3.Size = new System.Drawing.Size(73, 17);
            this.lblCol3.TabIndex = 2;
            this.lblCol3.Text = "SỐ QUYỀN";
            // 
            // pnlLeftFooter
            // 
            this.pnlLeftFooter.BackColor = System.Drawing.Color.Transparent;
            this.pnlLeftFooter.Controls.Add(this.lblRoleCount);
            this.pnlLeftFooter.Controls.Add(this.btnNext);
            this.pnlLeftFooter.Controls.Add(this.btnPage1);
            this.pnlLeftFooter.Controls.Add(this.btnPrev);
            this.pnlLeftFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlLeftFooter.Location = new System.Drawing.Point(0, 687);
            this.pnlLeftFooter.Name = "pnlLeftFooter";
            this.pnlLeftFooter.Size = new System.Drawing.Size(750, 56);
            this.pnlLeftFooter.TabIndex = 2;
            // 
            // lblRoleCount
            // 
            this.lblRoleCount.AutoSize = true;
            this.lblRoleCount.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoleCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(168)))), ((int)(((byte)(190)))));
            this.lblRoleCount.Location = new System.Drawing.Point(20, 18);
            this.lblRoleCount.Name = "lblRoleCount";
            this.lblRoleCount.Size = new System.Drawing.Size(146, 17);
            this.lblRoleCount.TabIndex = 0;
            this.lblRoleCount.Text = "4 roles trong hệ thống";
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(228)))), ((int)(((byte)(240)))));
            this.btnNext.BorderRadius = 4;
            this.btnNext.BorderThickness = 1;
            this.btnNext.FillColor = System.Drawing.Color.White;
            this.btnNext.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnNext.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(143)))), ((int)(((byte)(168)))));
            this.btnNext.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.btnNext.Location = new System.Drawing.Point(704, 13);
            this.btnNext.Name = "btnNext";
            this.btnNext.PressedColor = System.Drawing.Color.LightBlue;
            this.btnNext.Size = new System.Drawing.Size(30, 30);
            this.btnNext.TabIndex = 1;
            this.btnNext.Text = ">";
            // 
            // btnPage1
            // 
            this.btnPage1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPage1.BorderRadius = 4;
            this.btnPage1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(180)))));
            this.btnPage1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPage1.ForeColor = System.Drawing.Color.White;
            this.btnPage1.Location = new System.Drawing.Point(666, 13);
            this.btnPage1.Name = "btnPage1";
            this.btnPage1.Size = new System.Drawing.Size(30, 30);
            this.btnPage1.TabIndex = 2;
            this.btnPage1.Text = "1";
            // 
            // btnPrev
            // 
            this.btnPrev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrev.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(228)))), ((int)(((byte)(240)))));
            this.btnPrev.BorderRadius = 4;
            this.btnPrev.BorderThickness = 1;
            this.btnPrev.FillColor = System.Drawing.Color.White;
            this.btnPrev.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnPrev.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(143)))), ((int)(((byte)(168)))));
            this.btnPrev.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.btnPrev.Location = new System.Drawing.Point(628, 13);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.PressedColor = System.Drawing.Color.LightBlue;
            this.btnPrev.Size = new System.Drawing.Size(30, 30);
            this.btnPrev.TabIndex = 3;
            this.btnPrev.Text = "<";
            // 
            // pnlColRight
            // 
            this.pnlColRight.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(228)))), ((int)(((byte)(240)))));
            this.pnlColRight.BorderRadius = 16;
            this.pnlColRight.BorderThickness = 1;
            this.pnlColRight.Controls.Add(this.lstDetails);
            this.pnlColRight.Controls.Add(this.pnlDetailsHeader);
            this.pnlColRight.Controls.Add(this.pnlTabs);
            this.pnlColRight.Controls.Add(this.pnlStats);
            this.pnlColRight.Controls.Add(this.pnlRoleInfo);
            this.pnlColRight.Controls.Add(this.pnlRightFooter);
            this.pnlColRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlColRight.FillColor = System.Drawing.Color.White;
            this.pnlColRight.Location = new System.Drawing.Point(782, 16);
            this.pnlColRight.Margin = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.pnlColRight.Name = "pnlColRight";
            this.pnlColRight.Padding = new System.Windows.Forms.Padding(20);
            this.pnlColRight.Size = new System.Drawing.Size(419, 743);
            this.pnlColRight.TabIndex = 1;
            // 
            // lstDetails
            // 
            this.lstDetails.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstDetails.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.lstDetails.FormattingEnabled = true;
            this.lstDetails.ItemHeight = 60;
            this.lstDetails.Location = new System.Drawing.Point(20, 240);
            this.lstDetails.Name = "lstDetails";
            this.lstDetails.Size = new System.Drawing.Size(379, 423);
            this.lstDetails.TabIndex = 0;
            // 
            // pnlDetailsHeader
            // 
            this.pnlDetailsHeader.BackColor = System.Drawing.Color.White;
            this.pnlDetailsHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDetailsHeader.Location = new System.Drawing.Point(20, 232);
            this.pnlDetailsHeader.Name = "pnlDetailsHeader";
            this.pnlDetailsHeader.Size = new System.Drawing.Size(379, 8);
            this.pnlDetailsHeader.TabIndex = 1;
            // 
            // pnlTabs
            // 
            this.pnlTabs.BackColor = System.Drawing.Color.Transparent;
            this.pnlTabs.Controls.Add(this.btnTabMembers);
            this.pnlTabs.Controls.Add(this.btnTabPrivileges);
            this.pnlTabs.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(235)))), ((int)(((byte)(238)))));
            this.pnlTabs.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.pnlTabs.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTabs.Location = new System.Drawing.Point(20, 186);
            this.pnlTabs.Name = "pnlTabs";
            this.pnlTabs.Size = new System.Drawing.Size(379, 46);
            this.pnlTabs.TabIndex = 2;
            // 
            // btnTabMembers
            // 
            this.btnTabMembers.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnTabMembers.Checked = true;
            this.btnTabMembers.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(180)))));
            this.btnTabMembers.CheckedState.FillColor = System.Drawing.Color.White;
            this.btnTabMembers.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(180)))));
            this.btnTabMembers.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.btnTabMembers.FillColor = System.Drawing.Color.White;
            this.btnTabMembers.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnTabMembers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(168)))), ((int)(((byte)(190)))));
            this.btnTabMembers.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(180)))));
            this.btnTabMembers.HoverState.FillColor = System.Drawing.Color.White;
            this.btnTabMembers.Location = new System.Drawing.Point(0, 0);
            this.btnTabMembers.Name = "btnTabMembers";
            this.btnTabMembers.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(239)))), ((int)(((byte)(251)))));
            this.btnTabMembers.Size = new System.Drawing.Size(193, 46);
            this.btnTabMembers.TabIndex = 0;
            this.btnTabMembers.Text = "Thành viên";
            // 
            // btnTabPrivileges
            // 
            this.btnTabPrivileges.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnTabPrivileges.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(180)))));
            this.btnTabPrivileges.CheckedState.FillColor = System.Drawing.Color.White;
            this.btnTabPrivileges.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(180)))));
            this.btnTabPrivileges.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.btnTabPrivileges.FillColor = System.Drawing.Color.White;
            this.btnTabPrivileges.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnTabPrivileges.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(168)))), ((int)(((byte)(190)))));
            this.btnTabPrivileges.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(180)))));
            this.btnTabPrivileges.HoverState.FillColor = System.Drawing.Color.White;
            this.btnTabPrivileges.Location = new System.Drawing.Point(193, 0);
            this.btnTabPrivileges.Name = "btnTabPrivileges";
            this.btnTabPrivileges.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(239)))), ((int)(((byte)(251)))));
            this.btnTabPrivileges.Size = new System.Drawing.Size(194, 46);
            this.btnTabPrivileges.TabIndex = 1;
            this.btnTabPrivileges.Text = "Quyền hạn";
            // 
            // pnlStats
            // 
            this.pnlStats.BackColor = System.Drawing.Color.Transparent;
            this.pnlStats.Controls.Add(this.pnlStatMember);
            this.pnlStats.Controls.Add(this.pnlStatPriv);
            this.pnlStats.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlStats.Location = new System.Drawing.Point(20, 100);
            this.pnlStats.Name = "pnlStats";
            this.pnlStats.Size = new System.Drawing.Size(379, 86);
            this.pnlStats.TabIndex = 3;
            // 
            // pnlStatMember
            // 
            this.pnlStatMember.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(180)))));
            this.pnlStatMember.BorderRadius = 8;
            this.pnlStatMember.BorderThickness = 1;
            this.pnlStatMember.Controls.Add(this.lblStatMemberVal);
            this.pnlStatMember.Controls.Add(this.lblStatMemberTxt);
            this.pnlStatMember.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(249)))), ((int)(((byte)(252)))));
            this.pnlStatMember.Location = new System.Drawing.Point(0, 10);
            this.pnlStatMember.Name = "pnlStatMember";
            this.pnlStatMember.Size = new System.Drawing.Size(120, 66);
            this.pnlStatMember.TabIndex = 0;
            // 
            // lblStatMemberVal
            // 
            this.lblStatMemberVal.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblStatMemberVal.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblStatMemberVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(180)))));
            this.lblStatMemberVal.Location = new System.Drawing.Point(0, 0);
            this.lblStatMemberVal.Name = "lblStatMemberVal";
            this.lblStatMemberVal.Size = new System.Drawing.Size(120, 36);
            this.lblStatMemberVal.TabIndex = 0;
            this.lblStatMemberVal.Text = "2";
            this.lblStatMemberVal.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lblStatMemberTxt
            // 
            this.lblStatMemberTxt.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblStatMemberTxt.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStatMemberTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(168)))), ((int)(((byte)(190)))));
            this.lblStatMemberTxt.Location = new System.Drawing.Point(0, 36);
            this.lblStatMemberTxt.Name = "lblStatMemberTxt";
            this.lblStatMemberTxt.Size = new System.Drawing.Size(120, 30);
            this.lblStatMemberTxt.TabIndex = 1;
            this.lblStatMemberTxt.Text = "Thành viên";
            this.lblStatMemberTxt.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pnlStatPriv
            // 
            this.pnlStatPriv.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(180)))));
            this.pnlStatPriv.BorderRadius = 8;
            this.pnlStatPriv.BorderThickness = 1;
            this.pnlStatPriv.Controls.Add(this.lblStatPrivVal);
            this.pnlStatPriv.Controls.Add(this.lblStatPrivTxt);
            this.pnlStatPriv.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(249)))), ((int)(((byte)(252)))));
            this.pnlStatPriv.Location = new System.Drawing.Point(130, 10);
            this.pnlStatPriv.Name = "pnlStatPriv";
            this.pnlStatPriv.Size = new System.Drawing.Size(120, 66);
            this.pnlStatPriv.TabIndex = 1;
            // 
            // lblStatPrivVal
            // 
            this.lblStatPrivVal.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblStatPrivVal.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblStatPrivVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(180)))));
            this.lblStatPrivVal.Location = new System.Drawing.Point(0, 0);
            this.lblStatPrivVal.Name = "lblStatPrivVal";
            this.lblStatPrivVal.Size = new System.Drawing.Size(120, 36);
            this.lblStatPrivVal.TabIndex = 0;
            this.lblStatPrivVal.Text = "4";
            this.lblStatPrivVal.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lblStatPrivTxt
            // 
            this.lblStatPrivTxt.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblStatPrivTxt.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStatPrivTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(168)))), ((int)(((byte)(190)))));
            this.lblStatPrivTxt.Location = new System.Drawing.Point(0, 36);
            this.lblStatPrivTxt.Name = "lblStatPrivTxt";
            this.lblStatPrivTxt.Size = new System.Drawing.Size(120, 30);
            this.lblStatPrivTxt.TabIndex = 1;
            this.lblStatPrivTxt.Text = "Quyền";
            this.lblStatPrivTxt.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pnlRoleInfo
            // 
            this.pnlRoleInfo.BackColor = System.Drawing.Color.Transparent;
            this.pnlRoleInfo.Controls.Add(this.btnRoleIcon);
            this.pnlRoleInfo.Controls.Add(this.lblRoleName);
            this.pnlRoleInfo.Controls.Add(this.lblRoleSub);
            this.pnlRoleInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlRoleInfo.Location = new System.Drawing.Point(20, 20);
            this.pnlRoleInfo.Name = "pnlRoleInfo";
            this.pnlRoleInfo.Size = new System.Drawing.Size(379, 80);
            this.pnlRoleInfo.TabIndex = 4;
            // 
            // btnRoleIcon
            // 
            this.btnRoleIcon.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(244)))), ((int)(((byte)(251)))));
            this.btnRoleIcon.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRoleIcon.ForeColor = System.Drawing.Color.White;
            this.btnRoleIcon.Location = new System.Drawing.Point(0, 5);
            this.btnRoleIcon.Name = "btnRoleIcon";
            this.btnRoleIcon.Size = new System.Drawing.Size(60, 60);
            this.btnRoleIcon.TabIndex = 0;
            // 
            // lblRoleName
            // 
            this.lblRoleName.AutoSize = true;
            this.lblRoleName.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblRoleName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.lblRoleName.Location = new System.Drawing.Point(86, 12);
            this.lblRoleName.Name = "lblRoleName";
            this.lblRoleName.Size = new System.Drawing.Size(120, 25);
            this.lblRoleName.TabIndex = 1;
            this.lblRoleName.Text = "ROLE_BACSI";
            // 
            // lblRoleSub
            // 
            this.lblRoleSub.AutoSize = true;
            this.lblRoleSub.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblRoleSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(168)))), ((int)(((byte)(190)))));
            this.lblRoleSub.Location = new System.Drawing.Point(86, 42);
            this.lblRoleSub.Name = "lblRoleSub";
            this.lblRoleSub.Size = new System.Drawing.Size(77, 19);
            this.lblRoleSub.TabIndex = 2;
            this.lblRoleSub.Text = "Bác sĩ / Y sĩ";
            // 
            // pnlRightFooter
            // 
            this.pnlRightFooter.BackColor = System.Drawing.Color.Transparent;
            this.pnlRightFooter.Controls.Add(this.btnDelete);
            this.pnlRightFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlRightFooter.Location = new System.Drawing.Point(20, 663);
            this.pnlRightFooter.Name = "pnlRightFooter";
            this.pnlRightFooter.Size = new System.Drawing.Size(379, 60);
            this.pnlRightFooter.TabIndex = 5;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDelete.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.btnDelete.BorderRadius = 8;
            this.btnDelete.BorderThickness = 1;
            this.btnDelete.FillColor = System.Drawing.Color.White;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnDelete.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnDelete.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(89, 10);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(200, 40);
            this.btnDelete.TabIndex = 0;
            this.btnDelete.Text = "Xóa Role";
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.txtSearch);
            this.pnlTop.Controls.Add(this.pnlSearchSpacer);
            this.pnlTop.Controls.Add(this.btnCreate);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Padding = new System.Windows.Forms.Padding(16, 16, 16, 0);
            this.pnlTop.Size = new System.Drawing.Size(1217, 60);
            this.pnlTop.TabIndex = 1;
            // 
            // txtSearch
            // 
            this.txtSearch.BorderRadius = 8;
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.DefaultText = "";
            this.txtSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearch.IconLeft = ((System.Drawing.Image)(resources.GetObject("txtSearch.IconLeft")));
            this.txtSearch.IconLeftOffset = new System.Drawing.Point(8, 0);
            this.txtSearch.Location = new System.Drawing.Point(16, 16);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 4, 16, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PlaceholderText = "Tìm kiếm tên role...";
            this.txtSearch.SelectedText = "";
            this.txtSearch.Size = new System.Drawing.Size(1005, 44);
            this.txtSearch.TabIndex = 0;
            // 
            // pnlSearchSpacer
            // 
            this.pnlSearchSpacer.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlSearchSpacer.FillColor = System.Drawing.Color.Transparent;
            this.pnlSearchSpacer.Location = new System.Drawing.Point(1021, 16);
            this.pnlSearchSpacer.Name = "pnlSearchSpacer";
            this.pnlSearchSpacer.Size = new System.Drawing.Size(16, 44);
            this.pnlSearchSpacer.TabIndex = 1;
            // 
            // btnCreate
            // 
            this.btnCreate.BorderRadius = 8;
            this.btnCreate.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCreate.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(180)))));
            this.btnCreate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCreate.ForeColor = System.Drawing.Color.White;
            this.btnCreate.Location = new System.Drawing.Point(1037, 16);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(164, 44);
            this.btnCreate.TabIndex = 2;
            this.btnCreate.Text = "+ Tạo Role mới";
            // 
            // ucRole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.Controls.Add(this.tblMain);
            this.Controls.Add(this.pnlTop);
            this.Name = "ucRole";
            this.Size = new System.Drawing.Size(1217, 835);
            this.tblMain.ResumeLayout(false);
            this.pnlColLeft.ResumeLayout(false);
            this.pnlLeftHeader.ResumeLayout(false);
            this.pnlLeftHeader.PerformLayout();
            this.pnlLeftFooter.ResumeLayout(false);
            this.pnlLeftFooter.PerformLayout();
            this.pnlColRight.ResumeLayout(false);
            this.pnlTabs.ResumeLayout(false);
            this.pnlStats.ResumeLayout(false);
            this.pnlStatMember.ResumeLayout(false);
            this.pnlStatPriv.ResumeLayout(false);
            this.pnlRoleInfo.ResumeLayout(false);
            this.pnlRoleInfo.PerformLayout();
            this.pnlRightFooter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tblMain;
        private Guna.UI2.WinForms.Guna2Panel pnlTop;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private Guna.UI2.WinForms.Guna2Panel pnlSearchSpacer;
        private Guna.UI2.WinForms.Guna2Button btnCreate;
        
        private Guna.UI2.WinForms.Guna2Panel pnlColLeft;
        private Guna.UI2.WinForms.Guna2Panel pnlColRight;
        
        private Guna.UI2.WinForms.Guna2Panel pnlLeftHeader;
        private System.Windows.Forms.Label lblCol1;
        private System.Windows.Forms.Label lblCol2;
        private System.Windows.Forms.Label lblCol3;
        private System.Windows.Forms.ListBox lstRoles;
        private Guna.UI2.WinForms.Guna2Panel pnlLeftFooter;
        private System.Windows.Forms.Label lblRoleCount;
        private Guna.UI2.WinForms.Guna2Button btnPrev;
        private Guna.UI2.WinForms.Guna2Button btnPage1;
        private Guna.UI2.WinForms.Guna2Button btnNext;

        private Guna.UI2.WinForms.Guna2Panel pnlRoleInfo;
        private Guna.UI2.WinForms.Guna2CircleButton btnRoleIcon;
        private System.Windows.Forms.Label lblRoleName;
        private System.Windows.Forms.Label lblRoleSub;
        
        private Guna.UI2.WinForms.Guna2Panel pnlStats;
        private Guna.UI2.WinForms.Guna2Panel pnlStatMember;
        private System.Windows.Forms.Label lblStatMemberVal;
        private System.Windows.Forms.Label lblStatMemberTxt;
        private Guna.UI2.WinForms.Guna2Panel pnlStatPriv;
        private System.Windows.Forms.Label lblStatPrivVal;
        private System.Windows.Forms.Label lblStatPrivTxt;

        private Guna.UI2.WinForms.Guna2Panel pnlTabs;
        private Guna.UI2.WinForms.Guna2Button btnTabMembers;
        private Guna.UI2.WinForms.Guna2Button btnTabPrivileges;
        
        private Guna.UI2.WinForms.Guna2Panel pnlDetailsHeader;
        private System.Windows.Forms.ListBox lstDetails;
        private Guna.UI2.WinForms.Guna2Panel pnlRightFooter;
        private Guna.UI2.WinForms.Guna2Button btnDelete;
        private Guna.UI2.WinForms.Guna2MessageDialog msgDialog;
    }
}
