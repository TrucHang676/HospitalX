namespace HospitalX.GUI.PH1
{
    partial class ucRevoke
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucRevoke));
            this.pnlMain = new Guna.UI2.WinForms.Guna2Panel();
            this.tblMain = new System.Windows.Forms.TableLayoutPanel();
            this.pnlBot = new Guna.UI2.WinForms.Guna2Panel();
            this.flpButton = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAll = new Guna.UI2.WinForms.Guna2Button();
            this.btnClearAllCols = new Guna.UI2.WinForms.Guna2Button();
            this.btnExeRevoke = new Guna.UI2.WinForms.Guna2Button();
            this.pnlMainRight = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlGrant = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTitle2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btn2 = new Guna.UI2.WinForms.Guna2CircleButton();
            this.dgvCurrentPrivs = new Guna.UI2.WinForms.Guna2DataGridView();
            this.colSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colObject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colObjType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrivilege = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colColumns = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGrantOption = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlCol1 = new Guna.UI2.WinForms.Guna2Panel();
            this.lstGrantees = new System.Windows.Forms.ListBox();
            this.txtSearchGrantee = new Guna.UI2.WinForms.Guna2TextBox();
            this.pnl2button = new Guna.UI2.WinForms.Guna2Panel();
            this.btnGranteeRole = new Guna.UI2.WinForms.Guna2Button();
            this.btnGranteeUser = new Guna.UI2.WinForms.Guna2Button();
            this.pnlGrantee = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTitle1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btn1 = new Guna.UI2.WinForms.Guna2CircleButton();
            this.btnUserRole = new Guna.UI2.WinForms.Guna2Button();
            this.pnlMain.SuspendLayout();
            this.tblMain.SuspendLayout();
            this.pnlBot.SuspendLayout();
            this.flpButton.SuspendLayout();
            this.pnlMainRight.SuspendLayout();
            this.pnlGrant.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCurrentPrivs)).BeginInit();
            this.pnlCol1.SuspendLayout();
            this.pnl2button.SuspendLayout();
            this.pnlGrantee.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.tblMain);
            this.pnlMain.Location = new System.Drawing.Point(14, 16);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1191, 687);
            this.pnlMain.TabIndex = 0;
            // 
            // tblMain
            // 
            this.tblMain.ColumnCount = 2;
            this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.60033F));
            this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64.39967F));
            this.tblMain.Controls.Add(this.pnlBot, 1, 1);
            this.tblMain.Controls.Add(this.pnlMainRight, 1, 0);
            this.tblMain.Controls.Add(this.pnlCol1, 0, 0);
            this.tblMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblMain.Location = new System.Drawing.Point(0, 0);
            this.tblMain.Name = "tblMain";
            this.tblMain.RowCount = 2;
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75.25473F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.74527F));
            this.tblMain.Size = new System.Drawing.Size(1191, 687);
            this.tblMain.TabIndex = 0;
            // 
            // pnlBot
            // 
            this.pnlBot.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.pnlBot.BorderRadius = 12;
            this.pnlBot.BorderThickness = 1;
            this.pnlBot.Controls.Add(this.flpButton);
            this.pnlBot.FillColor = System.Drawing.Color.White;
            this.pnlBot.Location = new System.Drawing.Point(423, 517);
            this.pnlBot.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.pnlBot.Name = "pnlBot";
            this.pnlBot.Padding = new System.Windows.Forms.Padding(12);
            this.pnlBot.Size = new System.Drawing.Size(758, 105);
            this.pnlBot.TabIndex = 24;
            // 
            // flpButton
            // 
            this.flpButton.BackColor = System.Drawing.Color.Transparent;
            this.flpButton.Controls.Add(this.btnAll);
            this.flpButton.Controls.Add(this.btnClearAllCols);
            this.flpButton.Controls.Add(this.btnExeRevoke);
            this.flpButton.Location = new System.Drawing.Point(12, 15);
            this.flpButton.Name = "flpButton";
            this.flpButton.Size = new System.Drawing.Size(731, 75);
            this.flpButton.TabIndex = 2;
            // 
            // btnAll
            // 
            this.btnAll.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(228)))), ((int)(((byte)(240)))));
            this.btnAll.BorderRadius = 15;
            this.btnAll.BorderThickness = 1;
            this.btnAll.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(180)))));
            this.btnAll.CheckedState.ForeColor = System.Drawing.Color.White;
            this.btnAll.DefaultAutoSize = true;
            this.btnAll.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAll.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAll.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAll.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAll.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.btnAll.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(180)))));
            this.btnAll.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(238)))), ((int)(((byte)(247)))));
            this.btnAll.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(180)))));
            this.btnAll.Location = new System.Drawing.Point(3, 22);
            this.btnAll.Margin = new System.Windows.Forms.Padding(3, 22, 3, 3);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(119, 33);
            this.btnAll.TabIndex = 0;
            this.btnAll.Text = "Chọn tất cả";
            // 
            // btnClearAllCols
            // 
            this.btnClearAllCols.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(165)))), ((int)(((byte)(165)))));
            this.btnClearAllCols.BorderRadius = 15;
            this.btnClearAllCols.BorderThickness = 1;
            this.btnClearAllCols.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(71)))), ((int)(((byte)(87)))));
            this.btnClearAllCols.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.btnClearAllCols.CheckedState.ForeColor = System.Drawing.Color.White;
            this.btnClearAllCols.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClearAllCols.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnClearAllCols.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnClearAllCols.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(143)))), ((int)(((byte)(168)))));
            this.btnClearAllCols.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.btnClearAllCols.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearAllCols.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.btnClearAllCols.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(178)))), ((int)(((byte)(178)))));
            this.btnClearAllCols.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnClearAllCols.Location = new System.Drawing.Point(150, 22);
            this.btnClearAllCols.Margin = new System.Windows.Forms.Padding(25, 22, 3, 3);
            this.btnClearAllCols.Name = "btnClearAllCols";
            this.btnClearAllCols.Size = new System.Drawing.Size(144, 33);
            this.btnClearAllCols.TabIndex = 23;
            this.btnClearAllCols.Text = "Bỏ chọn tất cả";
            // 
            // btnExeRevoke
            // 
            this.btnExeRevoke.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(165)))), ((int)(((byte)(165)))));
            this.btnExeRevoke.BorderRadius = 15;
            this.btnExeRevoke.BorderThickness = 1;
            this.btnExeRevoke.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(180)))));
            this.btnExeRevoke.CheckedState.ForeColor = System.Drawing.Color.White;
            this.btnExeRevoke.DefaultAutoSize = true;
            this.btnExeRevoke.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnExeRevoke.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnExeRevoke.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnExeRevoke.DisabledState.ForeColor = System.Drawing.Color.White;
            this.btnExeRevoke.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.btnExeRevoke.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExeRevoke.ForeColor = System.Drawing.Color.White;
            this.btnExeRevoke.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(238)))), ((int)(((byte)(247)))));
            this.btnExeRevoke.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(180)))));
            this.btnExeRevoke.Location = new System.Drawing.Point(322, 22);
            this.btnExeRevoke.Margin = new System.Windows.Forms.Padding(25, 22, 3, 3);
            this.btnExeRevoke.Name = "btnExeRevoke";
            this.btnExeRevoke.Size = new System.Drawing.Size(193, 33);
            this.btnExeRevoke.TabIndex = 1;
            this.btnExeRevoke.Text = "Thực hiện REVOKE →";
            // 
            // pnlMainRight
            // 
            this.pnlMainRight.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.pnlMainRight.BorderRadius = 12;
            this.pnlMainRight.BorderThickness = 1;
            this.pnlMainRight.Controls.Add(this.pnlGrant);
            this.pnlMainRight.Controls.Add(this.dgvCurrentPrivs);
            this.pnlMainRight.FillColor = System.Drawing.Color.White;
            this.pnlMainRight.Location = new System.Drawing.Point(423, 0);
            this.pnlMainRight.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.pnlMainRight.Name = "pnlMainRight";
            this.pnlMainRight.Padding = new System.Windows.Forms.Padding(12);
            this.pnlMainRight.Size = new System.Drawing.Size(758, 493);
            this.pnlMainRight.TabIndex = 3;
            // 
            // pnlGrant
            // 
            this.pnlGrant.BackColor = System.Drawing.Color.Transparent;
            this.pnlGrant.Controls.Add(this.lblTitle2);
            this.pnlGrant.Controls.Add(this.btn2);
            this.pnlGrant.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlGrant.Location = new System.Drawing.Point(12, 12);
            this.pnlGrant.Name = "pnlGrant";
            this.pnlGrant.Size = new System.Drawing.Size(734, 57);
            this.pnlGrant.TabIndex = 0;
            // 
            // lblTitle2
            // 
            this.lblTitle2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTitle2.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle2.ForeColor = System.Drawing.Color.Black;
            this.lblTitle2.Location = new System.Drawing.Point(39, 21);
            this.lblTitle2.Name = "lblTitle2";
            this.lblTitle2.Size = new System.Drawing.Size(86, 22);
            this.lblTitle2.TabIndex = 8;
            this.lblTitle2.Text = "Chọn \r\nquyền";
            // 
            // btn2
            // 
            this.btn2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn2.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(180)))));
            this.btn2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.btn2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn2.ForeColor = System.Drawing.Color.White;
            this.btn2.Location = new System.Drawing.Point(3, 14);
            this.btn2.Name = "btn2";
            this.btn2.ShadowDecoration.BorderRadius = 20;
            this.btn2.ShadowDecoration.Color = System.Drawing.Color.DimGray;
            this.btn2.ShadowDecoration.Depth = 15;
            this.btn2.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btn2.Size = new System.Drawing.Size(30, 30);
            this.btn2.TabIndex = 7;
            this.btn2.Text = "2";
            // 
            // dgvCurrentPrivs
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvCurrentPrivs.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCurrentPrivs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCurrentPrivs.ColumnHeadersHeight = 15;
            this.dgvCurrentPrivs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvCurrentPrivs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSelect,
            this.colObject,
            this.colObjType,
            this.colPrivilege,
            this.colColumns,
            this.colGrantOption});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCurrentPrivs.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCurrentPrivs.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvCurrentPrivs.Location = new System.Drawing.Point(15, 78);
            this.dgvCurrentPrivs.Name = "dgvCurrentPrivs";
            this.dgvCurrentPrivs.RowHeadersVisible = false;
            this.dgvCurrentPrivs.Size = new System.Drawing.Size(731, 385);
            this.dgvCurrentPrivs.TabIndex = 3;
            this.dgvCurrentPrivs.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvCurrentPrivs.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvCurrentPrivs.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvCurrentPrivs.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvCurrentPrivs.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvCurrentPrivs.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvCurrentPrivs.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvCurrentPrivs.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvCurrentPrivs.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvCurrentPrivs.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvCurrentPrivs.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvCurrentPrivs.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvCurrentPrivs.ThemeStyle.HeaderStyle.Height = 15;
            this.dgvCurrentPrivs.ThemeStyle.ReadOnly = false;
            this.dgvCurrentPrivs.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvCurrentPrivs.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvCurrentPrivs.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvCurrentPrivs.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvCurrentPrivs.ThemeStyle.RowsStyle.Height = 22;
            this.dgvCurrentPrivs.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvCurrentPrivs.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // colSelect
            // 
            this.colSelect.FillWeight = 2.888619F;
            this.colSelect.HeaderText = "``";
            this.colSelect.Name = "colSelect";
            // 
            // colObject
            // 
            this.colObject.FillWeight = 140.1015F;
            this.colObject.HeaderText = "Đối tượng ";
            this.colObject.Name = "colObject";
            // 
            // colObjType
            // 
            this.colObjType.FillWeight = 29.48268F;
            this.colObjType.HeaderText = "Loại";
            this.colObjType.Name = "colObjType";
            // 
            // colPrivilege
            // 
            this.colPrivilege.FillWeight = 47.87513F;
            this.colPrivilege.HeaderText = "Quyền";
            this.colPrivilege.Name = "colPrivilege";
            // 
            // colColumns
            // 
            this.colColumns.FillWeight = 179.702F;
            this.colColumns.HeaderText = "Cột";
            this.colColumns.Name = "colColumns";
            // 
            // colGrantOption
            // 
            this.colGrantOption.FillWeight = 199.9502F;
            this.colGrantOption.HeaderText = "Grant Option";
            this.colGrantOption.Name = "colGrantOption";
            // 
            // pnlCol1
            // 
            this.pnlCol1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.pnlCol1.BorderRadius = 12;
            this.pnlCol1.BorderThickness = 1;
            this.pnlCol1.Controls.Add(this.lstGrantees);
            this.pnlCol1.Controls.Add(this.txtSearchGrantee);
            this.pnlCol1.Controls.Add(this.pnl2button);
            this.pnlCol1.Controls.Add(this.pnlGrantee);
            this.pnlCol1.FillColor = System.Drawing.Color.White;
            this.pnlCol1.Location = new System.Drawing.Point(0, 0);
            this.pnlCol1.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.pnlCol1.Name = "pnlCol1";
            this.pnlCol1.Padding = new System.Windows.Forms.Padding(12);
            this.pnlCol1.Size = new System.Drawing.Size(384, 493);
            this.pnlCol1.TabIndex = 1;
            // 
            // lstGrantees
            // 
            this.lstGrantees.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstGrantees.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lstGrantees.FormattingEnabled = true;
            this.lstGrantees.ItemHeight = 46;
            this.lstGrantees.Location = new System.Drawing.Point(15, 183);
            this.lstGrantees.Name = "lstGrantees";
            this.lstGrantees.Size = new System.Drawing.Size(347, 276);
            this.lstGrantees.TabIndex = 5;
            // 
            // txtSearchGrantee
            // 
            this.txtSearchGrantee.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSearchGrantee.BorderRadius = 8;
            this.txtSearchGrantee.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearchGrantee.DefaultText = "";
            this.txtSearchGrantee.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSearchGrantee.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSearchGrantee.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearchGrantee.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearchGrantee.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(254)))));
            this.txtSearchGrantee.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(180)))));
            this.txtSearchGrantee.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSearchGrantee.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtSearchGrantee.IconLeft = ((System.Drawing.Image)(resources.GetObject("txtSearchGrantee.IconLeft")));
            this.txtSearchGrantee.Location = new System.Drawing.Point(15, 129);
            this.txtSearchGrantee.Name = "txtSearchGrantee";
            this.txtSearchGrantee.PlaceholderText = "Tìm username, role...";
            this.txtSearchGrantee.SelectedText = "";
            this.txtSearchGrantee.Size = new System.Drawing.Size(347, 34);
            this.txtSearchGrantee.TabIndex = 4;
            // 
            // pnl2button
            // 
            this.pnl2button.BackColor = System.Drawing.Color.Transparent;
            this.pnl2button.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.pnl2button.BorderRadius = 15;
            this.pnl2button.BorderThickness = 1;
            this.pnl2button.Controls.Add(this.btnGranteeRole);
            this.pnl2button.Controls.Add(this.btnGranteeUser);
            this.pnl2button.FillColor = System.Drawing.Color.White;
            this.pnl2button.Location = new System.Drawing.Point(15, 78);
            this.pnl2button.Name = "pnl2button";
            this.pnl2button.ShadowDecoration.BorderRadius = 15;
            this.pnl2button.ShadowDecoration.Depth = 3;
            this.pnl2button.ShadowDecoration.Enabled = true;
            this.pnl2button.Size = new System.Drawing.Size(347, 40);
            this.pnl2button.TabIndex = 3;
            // 
            // btnGranteeRole
            // 
            this.btnGranteeRole.BorderRadius = 12;
            this.btnGranteeRole.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnGranteeRole.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.btnGranteeRole.CheckedState.ForeColor = System.Drawing.Color.White;
            this.btnGranteeRole.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnGranteeRole.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnGranteeRole.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnGranteeRole.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(143)))), ((int)(((byte)(168)))));
            this.btnGranteeRole.FillColor = System.Drawing.Color.Transparent;
            this.btnGranteeRole.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGranteeRole.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(143)))), ((int)(((byte)(168)))));
            this.btnGranteeRole.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.btnGranteeRole.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnGranteeRole.Location = new System.Drawing.Point(188, 4);
            this.btnGranteeRole.Name = "btnGranteeRole";
            this.btnGranteeRole.Size = new System.Drawing.Size(145, 32);
            this.btnGranteeRole.TabIndex = 1;
            this.btnGranteeRole.Text = "Role";
            // 
            // btnGranteeUser
            // 
            this.btnGranteeUser.BorderRadius = 12;
            this.btnGranteeUser.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnGranteeUser.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.btnGranteeUser.CheckedState.ForeColor = System.Drawing.Color.White;
            this.btnGranteeUser.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnGranteeUser.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnGranteeUser.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnGranteeUser.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(143)))), ((int)(((byte)(168)))));
            this.btnGranteeUser.FillColor = System.Drawing.Color.Transparent;
            this.btnGranteeUser.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGranteeUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(143)))), ((int)(((byte)(168)))));
            this.btnGranteeUser.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.btnGranteeUser.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnGranteeUser.Location = new System.Drawing.Point(14, 4);
            this.btnGranteeUser.Name = "btnGranteeUser";
            this.btnGranteeUser.Size = new System.Drawing.Size(145, 32);
            this.btnGranteeUser.TabIndex = 0;
            this.btnGranteeUser.Text = "User";
            // 
            // pnlGrantee
            // 
            this.pnlGrantee.BackColor = System.Drawing.Color.Transparent;
            this.pnlGrantee.Controls.Add(this.lblTitle1);
            this.pnlGrantee.Controls.Add(this.btn1);
            this.pnlGrantee.Controls.Add(this.btnUserRole);
            this.pnlGrantee.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlGrantee.Location = new System.Drawing.Point(12, 12);
            this.pnlGrantee.Name = "pnlGrantee";
            this.pnlGrantee.Size = new System.Drawing.Size(360, 57);
            this.pnlGrantee.TabIndex = 0;
            // 
            // lblTitle1
            // 
            this.lblTitle1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTitle1.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle1.ForeColor = System.Drawing.Color.Black;
            this.lblTitle1.Location = new System.Drawing.Point(40, 21);
            this.lblTitle1.Name = "lblTitle1";
            this.lblTitle1.Size = new System.Drawing.Size(99, 22);
            this.lblTitle1.TabIndex = 8;
            this.lblTitle1.Text = "Chọn \r\nGrantee";
            // 
            // btn1
            // 
            this.btn1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn1.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(180)))));
            this.btn1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.btn1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn1.ForeColor = System.Drawing.Color.White;
            this.btn1.Location = new System.Drawing.Point(4, 14);
            this.btn1.Name = "btn1";
            this.btn1.ShadowDecoration.BorderRadius = 20;
            this.btn1.ShadowDecoration.Color = System.Drawing.Color.DimGray;
            this.btn1.ShadowDecoration.Depth = 15;
            this.btn1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btn1.Size = new System.Drawing.Size(30, 30);
            this.btn1.TabIndex = 7;
            this.btn1.Text = "1";
            // 
            // btnUserRole
            // 
            this.btnUserRole.BorderRadius = 10;
            this.btnUserRole.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnUserRole.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnUserRole.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnUserRole.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnUserRole.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.btnUserRole.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUserRole.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.btnUserRole.Location = new System.Drawing.Point(265, 16);
            this.btnUserRole.Margin = new System.Windows.Forms.Padding(0);
            this.btnUserRole.Name = "btnUserRole";
            this.btnUserRole.Size = new System.Drawing.Size(85, 25);
            this.btnUserRole.TabIndex = 1;
            this.btnUserRole.Text = "User / Role";
            // 
            // ucRevoke
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.Controls.Add(this.pnlMain);
            this.Name = "ucRevoke";
            this.Size = new System.Drawing.Size(1200, 700);
            this.pnlMain.ResumeLayout(false);
            this.tblMain.ResumeLayout(false);
            this.pnlBot.ResumeLayout(false);
            this.flpButton.ResumeLayout(false);
            this.flpButton.PerformLayout();
            this.pnlMainRight.ResumeLayout(false);
            this.pnlGrant.ResumeLayout(false);
            this.pnlGrant.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCurrentPrivs)).EndInit();
            this.pnlCol1.ResumeLayout(false);
            this.pnl2button.ResumeLayout(false);
            this.pnlGrantee.ResumeLayout(false);
            this.pnlGrantee.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlMain;
        private System.Windows.Forms.TableLayoutPanel tblMain;
        private Guna.UI2.WinForms.Guna2Panel pnlCol1;
        private System.Windows.Forms.ListBox lstGrantees;
        private Guna.UI2.WinForms.Guna2TextBox txtSearchGrantee;
        private Guna.UI2.WinForms.Guna2Panel pnl2button;
        private Guna.UI2.WinForms.Guna2Button btnGranteeRole;
        private Guna.UI2.WinForms.Guna2Button btnGranteeUser;
        private Guna.UI2.WinForms.Guna2Panel pnlGrantee;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTitle1;
        private Guna.UI2.WinForms.Guna2CircleButton btn1;
        private Guna.UI2.WinForms.Guna2Button btnUserRole;
        private Guna.UI2.WinForms.Guna2Button btnClearAllCols;
        private Guna.UI2.WinForms.Guna2Button btnAll;
        private Guna.UI2.WinForms.Guna2Button btnExeRevoke;
        private Guna.UI2.WinForms.Guna2Panel pnlMainRight;
        private Guna.UI2.WinForms.Guna2Panel pnlGrant;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTitle2;
        private Guna.UI2.WinForms.Guna2CircleButton btn2;
        private Guna.UI2.WinForms.Guna2DataGridView dgvCurrentPrivs;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn colObject;
        private System.Windows.Forms.DataGridViewTextBoxColumn colObjType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrivilege;
        private System.Windows.Forms.DataGridViewTextBoxColumn colColumns;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGrantOption;
        private Guna.UI2.WinForms.Guna2Panel pnlBot;
        private System.Windows.Forms.FlowLayoutPanel flpButton;
    }
}
