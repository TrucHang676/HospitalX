namespace HospitalX.GUI.PH2.KyThuatVien
{
    partial class UcKtvDichVu
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.pnlFilter = new Guna.UI2.WinForms.Guna2Panel();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.cboStatus = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnReset = new Guna.UI2.WinForms.Guna2Button();
            this.cardStat1 = new Guna.UI2.WinForms.Guna2Panel();
            this.dotStat1 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblStat1Value = new System.Windows.Forms.Label();
            this.lblStat1Text = new System.Windows.Forms.Label();
            this.cardStat2 = new Guna.UI2.WinForms.Guna2Panel();
            this.dotStat2 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblStat2Value = new System.Windows.Forms.Label();
            this.lblStat2Text = new System.Windows.Forms.Label();
            this.cardStat3 = new Guna.UI2.WinForms.Guna2Panel();
            this.dotStat3 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblStat3Value = new System.Windows.Forms.Label();
            this.lblStat3Text = new System.Windows.Forms.Label();
            this.cardStat4 = new Guna.UI2.WinForms.Guna2Panel();
            this.dotStat4 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblStat4Value = new System.Windows.Forms.Label();
            this.lblStat4Text = new System.Windows.Forms.Label();
            this.pnlTableCard = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlTabBar = new Guna.UI2.WinForms.Guna2Panel();
            this.btnTabAll = new Guna.UI2.WinForms.Guna2Button();
            this.btnTabPending = new Guna.UI2.WinForms.Guna2Button();
            this.btnTabDone = new Guna.UI2.WinForms.Guna2Button();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.pnlPagination = new Guna.UI2.WinForms.Guna2Panel();
            this.lblPageInfo = new System.Windows.Forms.Label();
            this.btnPrev = new Guna.UI2.WinForms.Guna2Button();
            this.btnPage1 = new Guna.UI2.WinForms.Guna2Button();
            this.btnNext = new Guna.UI2.WinForms.Guna2Button();
            this.pnlOverlay = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlDrawer = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlFilter.SuspendLayout();
            this.cardStat1.SuspendLayout();
            this.cardStat2.SuspendLayout();
            this.cardStat3.SuspendLayout();
            this.cardStat4.SuspendLayout();
            this.pnlTableCard.SuspendLayout();
            this.pnlTabBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.pnlPagination.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(39)))), ((int)(((byte)(51)))));
            this.lblTitle.Location = new System.Drawing.Point(24, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(359, 41);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Dịch vụ được phân công";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblSubtitle.Location = new System.Drawing.Point(27, 54);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(259, 20);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Danh sách HSBA_DV của kỹ thuật viên";
            // 
            // pnlFilter
            // 
            this.pnlFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFilter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.pnlFilter.BorderRadius = 12;
            this.pnlFilter.BorderThickness = 1;
            this.pnlFilter.Controls.Add(this.txtSearch);
            this.pnlFilter.Controls.Add(this.cboStatus);
            this.pnlFilter.Controls.Add(this.btnReset);
            this.pnlFilter.FillColor = System.Drawing.Color.White;
            this.pnlFilter.Location = new System.Drawing.Point(28, 96);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(1444, 72);
            this.pnlFilter.TabIndex = 2;
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.txtSearch.BorderRadius = 8;
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.DefaultText = "";
            this.txtSearch.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(42)))));
            this.txtSearch.Location = new System.Drawing.Point(18, 18);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(152)))), ((int)(((byte)(170)))));
            this.txtSearch.PlaceholderText = "Tìm bệnh nhân, mã HSBA, tên dịch vụ...";
            this.txtSearch.SelectedText = "";
            this.txtSearch.Size = new System.Drawing.Size(758, 36);
            this.txtSearch.TabIndex = 0;
            // 
            // cboStatus
            // 
            this.cboStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboStatus.BackColor = System.Drawing.Color.Transparent;
            this.cboStatus.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.cboStatus.BorderRadius = 8;
            this.cboStatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.cboStatus.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.cboStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(85)))), ((int)(((byte)(104)))));
            this.cboStatus.ItemHeight = 30;
            this.cboStatus.Items.AddRange(new object[] {
            "Tất cả trạng thái",
            "Chờ thực hiện",
            "Hoàn thành"});
            this.cboStatus.Location = new System.Drawing.Point(794, 18);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(320, 36);
            this.cboStatus.TabIndex = 1;
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.btnReset.BorderRadius = 8;
            this.btnReset.BorderThickness = 1;
            this.btnReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReset.FillColor = System.Drawing.Color.White;
            this.btnReset.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnReset.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(85)))), ((int)(((byte)(104)))));
            this.btnReset.Location = new System.Drawing.Point(1304, 18);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(120, 36);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "Đặt lại";
            // 
            // cardStat1
            // 
            this.cardStat1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.cardStat1.BorderRadius = 12;
            this.cardStat1.BorderThickness = 1;
            this.cardStat1.Controls.Add(this.dotStat1);
            this.cardStat1.Controls.Add(this.lblStat1Value);
            this.cardStat1.Controls.Add(this.lblStat1Text);
            this.cardStat1.FillColor = System.Drawing.Color.White;
            this.cardStat1.Location = new System.Drawing.Point(28, 188);
            this.cardStat1.Name = "cardStat1";
            this.cardStat1.Size = new System.Drawing.Size(472, 104);
            this.cardStat1.TabIndex = 3;
            // 
            // dotStat1
            // 
            this.dotStat1.BorderRadius = 6;
            this.dotStat1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(152)))), ((int)(((byte)(170)))));
            this.dotStat1.Location = new System.Drawing.Point(22, 48);
            this.dotStat1.Name = "dotStat1";
            this.dotStat1.Size = new System.Drawing.Size(12, 12);
            this.dotStat1.TabIndex = 0;
            // 
            // 
            // lblStat1Value
            // 
            this.lblStat1Value.AutoSize = true;
            this.lblStat1Value.BackColor = System.Drawing.Color.Transparent;
            this.lblStat1Value.Font = new System.Drawing.Font("Segoe UI", 21F, System.Drawing.FontStyle.Bold);
            this.lblStat1Value.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(39)))), ((int)(((byte)(51)))));
            this.lblStat1Value.Location = new System.Drawing.Point(48, 22);
            this.lblStat1Value.Name = "lblStat1Value";
            this.lblStat1Value.Size = new System.Drawing.Size(40, 47);
            this.lblStat1Value.TabIndex = 1;
            this.lblStat1Value.Text = "7";
            // 
            // lblStat1Text
            // 
            this.lblStat1Text.AutoSize = true;
            this.lblStat1Text.BackColor = System.Drawing.Color.Transparent;
            this.lblStat1Text.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStat1Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblStat1Text.Location = new System.Drawing.Point(49, 66);
            this.lblStat1Text.Name = "lblStat1Text";
            this.lblStat1Text.Size = new System.Drawing.Size(94, 20);
            this.lblStat1Text.TabIndex = 2;
            this.lblStat1Text.Text = "Tổng dịch vụ";
            // 
            // cardStat2
            // 
            this.cardStat2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.cardStat2.BorderRadius = 12;
            this.cardStat2.BorderThickness = 1;
            this.cardStat2.Controls.Add(this.dotStat2);
            this.cardStat2.Controls.Add(this.lblStat2Value);
            this.cardStat2.Controls.Add(this.lblStat2Text);
            this.cardStat2.FillColor = System.Drawing.Color.White;
            this.cardStat2.Location = new System.Drawing.Point(520, 188);
            this.cardStat2.Name = "cardStat2";
            this.cardStat2.Size = new System.Drawing.Size(472, 104);
            this.cardStat2.TabIndex = 4;
            // 
            // dotStat2
            // 
            this.dotStat2.BorderRadius = 6;
            this.dotStat2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(165)))), ((int)(((byte)(0)))));
            this.dotStat2.Location = new System.Drawing.Point(22, 48);
            this.dotStat2.Name = "dotStat2";
            this.dotStat2.Size = new System.Drawing.Size(12, 12);
            this.dotStat2.TabIndex = 0;
            // 
            // 
            // lblStat2Value
            // 
            this.lblStat2Value.AutoSize = true;
            this.lblStat2Value.BackColor = System.Drawing.Color.Transparent;
            this.lblStat2Value.Font = new System.Drawing.Font("Segoe UI", 21F, System.Drawing.FontStyle.Bold);
            this.lblStat2Value.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(165)))), ((int)(((byte)(0)))));
            this.lblStat2Value.Location = new System.Drawing.Point(48, 22);
            this.lblStat2Value.Name = "lblStat2Value";
            this.lblStat2Value.Size = new System.Drawing.Size(40, 47);
            this.lblStat2Value.TabIndex = 1;
            this.lblStat2Value.Text = "4";
            // 
            // lblStat2Text
            // 
            this.lblStat2Text.AutoSize = true;
            this.lblStat2Text.BackColor = System.Drawing.Color.Transparent;
            this.lblStat2Text.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStat2Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblStat2Text.Location = new System.Drawing.Point(49, 66);
            this.lblStat2Text.Name = "lblStat2Text";
            this.lblStat2Text.Size = new System.Drawing.Size(100, 20);
            this.lblStat2Text.TabIndex = 2;
            this.lblStat2Text.Text = "Chờ thực hiện";
            // 
            // cardStat3
            // 
            this.cardStat3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.cardStat3.BorderRadius = 12;
            this.cardStat3.BorderThickness = 1;
            this.cardStat3.Controls.Add(this.dotStat3);
            this.cardStat3.Controls.Add(this.lblStat3Value);
            this.cardStat3.Controls.Add(this.lblStat3Text);
            this.cardStat3.FillColor = System.Drawing.Color.White;
            this.cardStat3.Location = new System.Drawing.Point(1012, 188);
            this.cardStat3.Name = "cardStat3";
            this.cardStat3.Size = new System.Drawing.Size(460, 104);
            this.cardStat3.TabIndex = 5;
            // 
            // 
            // dotStat3
            // 
            this.dotStat3.BorderRadius = 6;
            this.dotStat3.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.dotStat3.Location = new System.Drawing.Point(22, 48);
            this.dotStat3.Name = "dotStat3";
            this.dotStat3.Size = new System.Drawing.Size(12, 12);
            this.dotStat3.TabIndex = 0;
            // 
            // lblStat3Value
            // 
            this.lblStat3Value.AutoSize = true;
            this.lblStat3Value.BackColor = System.Drawing.Color.Transparent;
            this.lblStat3Value.Font = new System.Drawing.Font("Segoe UI", 21F, System.Drawing.FontStyle.Bold);
            this.lblStat3Value.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.lblStat3Value.Location = new System.Drawing.Point(48, 22);
            this.lblStat3Value.Name = "lblStat3Value";
            this.lblStat3Value.Size = new System.Drawing.Size(40, 47);
            this.lblStat3Value.TabIndex = 1;
            this.lblStat3Value.Text = "3";
            // 
            // lblStat3Text
            // 
            this.lblStat3Text.AutoSize = true;
            this.lblStat3Text.BackColor = System.Drawing.Color.Transparent;
            this.lblStat3Text.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStat3Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblStat3Text.Location = new System.Drawing.Point(49, 66);
            this.lblStat3Text.Name = "lblStat3Text";
            this.lblStat3Text.Size = new System.Drawing.Size(86, 20);
            this.lblStat3Text.TabIndex = 2;
            this.lblStat3Text.Text = "Hoàn thành";
            // 
            // cardStat4
            // 
            this.cardStat4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.cardStat4.BorderRadius = 12;
            this.cardStat4.BorderThickness = 1;
            this.cardStat4.Controls.Add(this.dotStat4);
            this.cardStat4.Controls.Add(this.lblStat4Value);
            this.cardStat4.Controls.Add(this.lblStat4Text);
            this.cardStat4.FillColor = System.Drawing.Color.White;
            this.cardStat4.Location = new System.Drawing.Point(1012, 188);
            this.cardStat4.Name = "cardStat4";
            this.cardStat4.Size = new System.Drawing.Size(460, 104);
            this.cardStat4.TabIndex = 6;
            this.cardStat4.Visible = true;
            // 
            // 
            // dotStat4
            // 
            this.dotStat4.BorderRadius = 6;
            this.dotStat4.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.dotStat4.Location = new System.Drawing.Point(22, 48);
            this.dotStat4.Name = "dotStat4";
            this.dotStat4.Size = new System.Drawing.Size(12, 12);
            this.dotStat4.TabIndex = 0;
            // 
            // lblStat4Value
            // 
            this.lblStat4Value.AutoSize = true;
            this.lblStat4Value.BackColor = System.Drawing.Color.Transparent;
            this.lblStat4Value.Font = new System.Drawing.Font("Segoe UI", 21F, System.Drawing.FontStyle.Bold);
            this.lblStat4Value.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.lblStat4Value.Location = new System.Drawing.Point(48, 22);
            this.lblStat4Value.Name = "lblStat4Value";
            this.lblStat4Value.Size = new System.Drawing.Size(40, 47);
            this.lblStat4Value.TabIndex = 1;
            this.lblStat4Value.Text = "3";
            // 
            // lblStat4Text
            // 
            this.lblStat4Text.AutoSize = true;
            this.lblStat4Text.BackColor = System.Drawing.Color.Transparent;
            this.lblStat4Text.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStat4Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblStat4Text.Location = new System.Drawing.Point(49, 66);
            this.lblStat4Text.Name = "lblStat4Text";
            this.lblStat4Text.Size = new System.Drawing.Size(86, 20);
            this.lblStat4Text.TabIndex = 2;
            this.lblStat4Text.Text = "Hoàn thành";
            // 
            // pnlTableCard
            // 
            this.pnlTableCard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTableCard.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.pnlTableCard.BorderRadius = 12;
            this.pnlTableCard.BorderThickness = 1;
            this.pnlTableCard.Controls.Add(this.pnlTabBar);
            this.pnlTableCard.Controls.Add(this.dgv);
            this.pnlTableCard.Controls.Add(this.pnlPagination);
            this.pnlTableCard.FillColor = System.Drawing.Color.White;
            this.pnlTableCard.Location = new System.Drawing.Point(28, 314);
            this.pnlTableCard.Name = "pnlTableCard";
            this.pnlTableCard.Size = new System.Drawing.Size(1444, 640);
            this.pnlTableCard.TabIndex = 7;
            // 
            // pnlTabBar
            // 
            this.pnlTabBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTabBar.Controls.Add(this.btnTabAll);
            this.pnlTabBar.Controls.Add(this.btnTabPending);
            this.pnlTabBar.Controls.Add(this.btnTabDone);
            this.pnlTabBar.FillColor = System.Drawing.Color.White;
            this.pnlTabBar.Location = new System.Drawing.Point(1, 1);
            this.pnlTabBar.Name = "pnlTabBar";
            this.pnlTabBar.Size = new System.Drawing.Size(1442, 46);
            this.pnlTabBar.TabIndex = 0;
            // 
            // btnTabAll
            // 
            this.btnTabAll.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(246)))), ((int)(((byte)(243)))));
            this.btnTabAll.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnTabAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.btnTabAll.Location = new System.Drawing.Point(20, 1);
            this.btnTabAll.Name = "btnTabAll";
            this.btnTabAll.Size = new System.Drawing.Size(120, 44);
            this.btnTabAll.TabIndex = 0;
            this.btnTabAll.Text = "Tất cả (7)";
            // 
            // btnTabPending
            // 
            this.btnTabPending.FillColor = System.Drawing.Color.White;
            this.btnTabPending.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnTabPending.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.btnTabPending.Location = new System.Drawing.Point(140, 1);
            this.btnTabPending.Name = "btnTabPending";
            this.btnTabPending.Size = new System.Drawing.Size(190, 44);
            this.btnTabPending.TabIndex = 1;
            this.btnTabPending.Text = "Chờ thực hiện (4)";
            // 
            // btnTabDone
            // 
            this.btnTabDone.FillColor = System.Drawing.Color.White;
            this.btnTabDone.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnTabDone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.btnTabDone.Location = new System.Drawing.Point(330, 1);
            this.btnTabDone.Name = "btnTabDone";
            this.btnTabDone.Size = new System.Drawing.Size(160, 44);
            this.btnTabDone.TabIndex = 2;
            this.btnTabDone.Text = "Hoàn thành (3)";
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeColumns = false;
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.BackgroundColor = System.Drawing.Color.White;
            this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv.ColumnHeadersHeight = 40;
            this.dgv.EnableHeadersVisualStyles = false;
            this.dgv.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(240)))));
            this.dgv.Location = new System.Drawing.Point(20, 60);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowHeadersWidth = 51;
            this.dgv.RowTemplate.Height = 62;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(1404, 535);
            this.dgv.TabIndex = 1;
            // 
            // pnlPagination
            // 
            this.pnlPagination.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlPagination.Controls.Add(this.lblPageInfo);
            this.pnlPagination.Controls.Add(this.btnPrev);
            this.pnlPagination.Controls.Add(this.btnPage1);
            this.pnlPagination.Controls.Add(this.btnNext);
            this.pnlPagination.FillColor = System.Drawing.Color.White;
            this.pnlPagination.Location = new System.Drawing.Point(1, 595);
            this.pnlPagination.Name = "pnlPagination";
            this.pnlPagination.Size = new System.Drawing.Size(1442, 44);
            this.pnlPagination.TabIndex = 2;
            // 
            // lblPageInfo
            // 
            this.lblPageInfo.AutoSize = true;
            this.lblPageInfo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPageInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblPageInfo.Location = new System.Drawing.Point(24, 12);
            this.lblPageInfo.Name = "lblPageInfo";
            this.lblPageInfo.Size = new System.Drawing.Size(146, 20);
            this.lblPageInfo.TabIndex = 0;
            this.lblPageInfo.Text = "Hiển thị 7 / 7 dịch vụ";
            // 
            // btnPrev
            // 
            this.btnPrev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrev.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.btnPrev.BorderRadius = 8;
            this.btnPrev.BorderThickness = 1;
            this.btnPrev.FillColor = System.Drawing.Color.White;
            this.btnPrev.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnPrev.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(39)))), ((int)(((byte)(51)))));
            this.btnPrev.Location = new System.Drawing.Point(1322, 7);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(32, 30);
            this.btnPrev.TabIndex = 1;
            this.btnPrev.Text = "‹";
            // 
            // btnPage1
            // 
            this.btnPage1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPage1.BorderRadius = 8;
            this.btnPage1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.btnPage1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnPage1.ForeColor = System.Drawing.Color.White;
            this.btnPage1.Location = new System.Drawing.Point(1360, 7);
            this.btnPage1.Name = "btnPage1";
            this.btnPage1.Size = new System.Drawing.Size(32, 30);
            this.btnPage1.TabIndex = 2;
            this.btnPage1.Text = "1";
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.btnNext.BorderRadius = 8;
            this.btnNext.BorderThickness = 1;
            this.btnNext.FillColor = System.Drawing.Color.White;
            this.btnNext.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnNext.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(39)))), ((int)(((byte)(51)))));
            this.btnNext.Location = new System.Drawing.Point(1398, 7);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(32, 30);
            this.btnNext.TabIndex = 3;
            this.btnNext.Text = "›";
            // 
            // pnlOverlay
            // 
            this.pnlOverlay.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pnlOverlay.Location = new System.Drawing.Point(0, 0);
            this.pnlOverlay.Name = "pnlOverlay";
            this.pnlOverlay.Size = new System.Drawing.Size(1504, 962);
            this.pnlOverlay.TabIndex = 8;
            this.pnlOverlay.Visible = false;
            // 
            // pnlDrawer
            // 
            this.pnlDrawer.FillColor = System.Drawing.Color.White;
            this.pnlDrawer.Location = new System.Drawing.Point(1504, 0);
            this.pnlDrawer.Name = "pnlDrawer";
            this.pnlDrawer.Size = new System.Drawing.Size(420, 962);
            this.pnlDrawer.TabIndex = 9;
            // 
            // UcKtvDichVu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.Controls.Add(this.pnlTableCard);
            this.Controls.Add(this.cardStat4);
            this.Controls.Add(this.cardStat3);
            this.Controls.Add(this.cardStat2);
            this.Controls.Add(this.cardStat1);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.lblSubtitle);
            this.Controls.Add(this.lblTitle);
            this.Name = "UcKtvDichVu";
            this.Size = new System.Drawing.Size(1504, 962);
            this.pnlFilter.ResumeLayout(false);
            this.cardStat1.ResumeLayout(false);
            this.cardStat1.PerformLayout();
            this.cardStat2.ResumeLayout(false);
            this.cardStat2.PerformLayout();
            this.cardStat3.ResumeLayout(false);
            this.cardStat3.PerformLayout();
            this.cardStat4.ResumeLayout(false);
            this.cardStat4.PerformLayout();
            this.pnlTableCard.ResumeLayout(false);
            this.pnlTabBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.pnlPagination.ResumeLayout(false);
            this.pnlPagination.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private Guna.UI2.WinForms.Guna2Panel pnlFilter;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private Guna.UI2.WinForms.Guna2ComboBox cboStatus;
        private Guna.UI2.WinForms.Guna2Button btnReset;
        private Guna.UI2.WinForms.Guna2Panel cardStat1;
        private Guna.UI2.WinForms.Guna2Panel dotStat1;
        private System.Windows.Forms.Label lblStat1Value;
        private System.Windows.Forms.Label lblStat1Text;
        private Guna.UI2.WinForms.Guna2Panel cardStat2;
        private Guna.UI2.WinForms.Guna2Panel dotStat2;
        private System.Windows.Forms.Label lblStat2Value;
        private System.Windows.Forms.Label lblStat2Text;
        private Guna.UI2.WinForms.Guna2Panel cardStat3;
        private Guna.UI2.WinForms.Guna2Panel dotStat3;
        private System.Windows.Forms.Label lblStat3Value;
        private System.Windows.Forms.Label lblStat3Text;
        private Guna.UI2.WinForms.Guna2Panel cardStat4;
        private Guna.UI2.WinForms.Guna2Panel pnlTableCard;
        private Guna.UI2.WinForms.Guna2Panel pnlTabBar;
        private Guna.UI2.WinForms.Guna2Button btnTabAll;
        private Guna.UI2.WinForms.Guna2Button btnTabPending;
        private Guna.UI2.WinForms.Guna2Button btnTabDone;
        private System.Windows.Forms.DataGridView dgv;
        private Guna.UI2.WinForms.Guna2Panel pnlPagination;
        private System.Windows.Forms.Label lblPageInfo;
        private Guna.UI2.WinForms.Guna2Button btnPrev;
        private Guna.UI2.WinForms.Guna2Button btnPage1;
        private Guna.UI2.WinForms.Guna2Button btnNext;
        private Guna.UI2.WinForms.Guna2Panel pnlOverlay;
        private Guna.UI2.WinForms.Guna2Panel pnlDrawer;
        private Guna.UI2.WinForms.Guna2Panel dotStat4;
        private System.Windows.Forms.Label lblStat4Value;
        private System.Windows.Forms.Label lblStat4Text;
    }
}
