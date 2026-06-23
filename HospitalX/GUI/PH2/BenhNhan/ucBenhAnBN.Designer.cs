namespace HospitalX.GUI.PH2.BenhNhan
{
    partial class ucBenhAnBN
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucBenhAnBN));
            this.pnlRoot = new System.Windows.Forms.Panel();
            this.flowRecords = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlToolbar = new Guna.UI2.WinForms.Guna2Panel();
            this.lblCount = new System.Windows.Forms.Label();
            this.lblSortLabel = new System.Windows.Forms.Label();
            this.cmbSort = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblDateTo = new System.Windows.Forms.Label();
            this.dtpTo = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.lblDateFrom = new System.Windows.Forms.Label();
            this.dtpFrom = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.lblDateRange = new System.Windows.Forms.Label();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.pnlRoot.SuspendLayout();
            this.pnlToolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlRoot
            // 
            this.pnlRoot.Controls.Add(this.flowRecords);
            this.pnlRoot.Controls.Add(this.pnlToolbar);
            this.pnlRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRoot.Location = new System.Drawing.Point(0, 0);
            this.pnlRoot.Name = "pnlRoot";
            this.pnlRoot.Padding = new System.Windows.Forms.Padding(24, 18, 24, 24);
            this.pnlRoot.Size = new System.Drawing.Size(1128, 782);
            this.pnlRoot.TabIndex = 0;
            // 
            // flowRecords
            // 
            this.flowRecords.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowRecords.AutoScroll = true;
            this.flowRecords.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(245)))), ((int)(((byte)(243)))));
            this.flowRecords.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowRecords.Location = new System.Drawing.Point(24, 106);
            this.flowRecords.Name = "flowRecords";
            this.flowRecords.Size = new System.Drawing.Size(1080, 652);
            this.flowRecords.TabIndex = 1;
            this.flowRecords.WrapContents = false;
            // 
            // pnlToolbar
            // 
            this.pnlToolbar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlToolbar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(224)))), ((int)(((byte)(219)))));
            this.pnlToolbar.BorderRadius = 8;
            this.pnlToolbar.BorderThickness = 1;
            this.pnlToolbar.Controls.Add(this.lblCount);
            this.pnlToolbar.Controls.Add(this.lblSortLabel);
            this.pnlToolbar.Controls.Add(this.cmbSort);
            this.pnlToolbar.Controls.Add(this.lblDateTo);
            this.pnlToolbar.Controls.Add(this.dtpTo);
            this.pnlToolbar.Controls.Add(this.lblDateFrom);
            this.pnlToolbar.Controls.Add(this.dtpFrom);
            this.pnlToolbar.Controls.Add(this.lblDateRange);
            this.pnlToolbar.Controls.Add(this.txtSearch);
            this.pnlToolbar.FillColor = System.Drawing.Color.White;
            this.pnlToolbar.Location = new System.Drawing.Point(24, 18);
            this.pnlToolbar.Name = "pnlToolbar";
            this.pnlToolbar.Padding = new System.Windows.Forms.Padding(16);
            this.pnlToolbar.Size = new System.Drawing.Size(1080, 74);
            this.pnlToolbar.TabIndex = 0;
            // 
            // 
            // lblCount
            // 
            this.lblCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCount.BackColor = System.Drawing.Color.Transparent;
            this.lblCount.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.lblCount.Location = new System.Drawing.Point(950, 19);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(112, 36);
            this.lblCount.TabIndex = 5;
            this.lblCount.Text = "Hiển thị 0 hồ sơ";
            this.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSortLabel
            // 
            this.lblSortLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSortLabel.AutoSize = false;
            this.lblSortLabel.BackColor = System.Drawing.Color.Transparent;
            this.lblSortLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSortLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(138)))), ((int)(((byte)(132)))));
            this.lblSortLabel.Location = new System.Drawing.Point(730, 19);
            this.lblSortLabel.Name = "lblSortLabel";
            this.lblSortLabel.Size = new System.Drawing.Size(60, 36);
            this.lblSortLabel.TabIndex = 11;
            this.lblSortLabel.Text = "Sắp xếp";
            this.lblSortLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbSort
            // 
            this.cmbSort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbSort.BackColor = System.Drawing.Color.Transparent;
            this.cmbSort.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(224)))), ((int)(((byte)(219)))));
            this.cmbSort.BorderRadius = 6;
            this.cmbSort.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbSort.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSort.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(251)))));
            this.cmbSort.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(85)))));
            this.cmbSort.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(85)))));
            this.cmbSort.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbSort.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.cmbSort.ItemHeight = 30;
            this.cmbSort.Items.AddRange(new object[] {
            "Mới nhất",
            "Cũ nhất",
            "Mã HSBA A-Z"});
            this.cmbSort.Location = new System.Drawing.Point(795, 19);
            this.cmbSort.Name = "cmbSort";
            this.cmbSort.Size = new System.Drawing.Size(145, 36);
            this.cmbSort.StartIndex = 0;
            this.cmbSort.TabIndex = 4;
            // 
            // lblDateTo
            // 
            this.lblDateTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDateTo.AutoSize = false;
            this.lblDateTo.BackColor = System.Drawing.Color.Transparent;
            this.lblDateTo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDateTo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(138)))), ((int)(((byte)(132)))));
            this.lblDateTo.Location = new System.Drawing.Point(545, 19);
            this.lblDateTo.Name = "lblDateTo";
            this.lblDateTo.Size = new System.Drawing.Size(35, 36);
            this.lblDateTo.TabIndex = 10;
            this.lblDateTo.Text = "Đến";
            this.lblDateTo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpTo
            // 
            this.dtpTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.dtpTo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(224)))), ((int)(((byte)(219)))));
            this.dtpTo.BorderRadius = 6;
            this.dtpTo.BorderThickness = 1;
            this.dtpTo.Checked = true;
            this.dtpTo.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(247)))), ((int)(((byte)(237)))));
            this.dtpTo.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(251)))));
            this.dtpTo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpTo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(585, 19);
            this.dtpTo.MaxDate = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            this.dtpTo.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(135, 36);
            this.dtpTo.TabIndex = 3;
            this.dtpTo.Value = new System.DateTime(2026, 5, 31, 0, 0, 0, 0);
            // 
            // lblDateFrom
            // 
            this.lblDateFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDateFrom.AutoSize = false;
            this.lblDateFrom.BackColor = System.Drawing.Color.Transparent;
            this.lblDateFrom.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDateFrom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(138)))), ((int)(((byte)(132)))));
            this.lblDateFrom.Location = new System.Drawing.Point(370, 19);
            this.lblDateFrom.Name = "lblDateFrom";
            this.lblDateFrom.Size = new System.Drawing.Size(25, 36);
            this.lblDateFrom.TabIndex = 9;
            this.lblDateFrom.Text = "Từ";
            this.lblDateFrom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.dtpFrom.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(224)))), ((int)(((byte)(219)))));
            this.dtpFrom.BorderRadius = 6;
            this.dtpFrom.BorderThickness = 1;
            this.dtpFrom.Checked = true;
            this.dtpFrom.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(247)))), ((int)(((byte)(237)))));
            this.dtpFrom.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(251)))));
            this.dtpFrom.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpFrom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(400, 19);
            this.dtpFrom.MaxDate = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            this.dtpFrom.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(135, 36);
            this.dtpFrom.TabIndex = 2;
            this.dtpFrom.Value = new System.DateTime(2026, 1, 1, 0, 0, 0, 0);
            // 
            // lblDateRange
            // 
            this.lblDateRange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDateRange.AutoSize = false;
            this.lblDateRange.BackColor = System.Drawing.Color.Transparent;
            this.lblDateRange.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDateRange.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(138)))), ((int)(((byte)(132)))));
            this.lblDateRange.Location = new System.Drawing.Point(290, 19);
            this.lblDateRange.Name = "lblDateRange";
            this.lblDateRange.Size = new System.Drawing.Size(75, 36);
            this.lblDateRange.TabIndex = 8;
            this.lblDateRange.Text = "Thời gian";
            this.lblDateRange.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.txtSearch.BackColor = System.Drawing.Color.Transparent;
            this.txtSearch.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(224)))), ((int)(((byte)(219)))));
            this.txtSearch.BorderRadius = 6;
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.DefaultText = "";
            this.txtSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(251)))));
            this.txtSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(85)))));
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.txtSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(85)))));
            this.txtSearch.IconLeft = ((System.Drawing.Image)(resources.GetObject("txtSearch.IconLeft")));
            this.txtSearch.Location = new System.Drawing.Point(18, 19);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(138)))), ((int)(((byte)(132)))));
            this.txtSearch.PlaceholderText = "Tìm theo mã HSBA, chẩn đoán, điều trị, bác sĩ...";
            this.txtSearch.SelectedText = "";
            this.txtSearch.Size = new System.Drawing.Size(260, 36);
            this.txtSearch.TabIndex = 0;
            // 
            // ucBenhAnBN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(245)))), ((int)(((byte)(243)))));
            this.Controls.Add(this.pnlRoot);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "ucBenhAnBN";
            this.Size = new System.Drawing.Size(1128, 782);
            this.pnlRoot.ResumeLayout(false);
            this.pnlToolbar.ResumeLayout(false);
            this.pnlToolbar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlRoot;
        private Guna.UI2.WinForms.Guna2Panel pnlToolbar;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private System.Windows.Forms.Label lblDateRange;
        private System.Windows.Forms.Label lblDateFrom;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblDateTo;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpTo;
        private System.Windows.Forms.Label lblSortLabel;
        private Guna.UI2.WinForms.Guna2ComboBox cmbSort;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.FlowLayoutPanel flowRecords;
    }
}
