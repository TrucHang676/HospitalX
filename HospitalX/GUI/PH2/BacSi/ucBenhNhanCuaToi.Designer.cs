namespace HospitalX.GUI.PH2.BacSi
{
    partial class ucBenhNhanCuaToi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucBenhNhanCuaToi));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlToolbar = new Guna.UI2.WinForms.Guna2Panel();
            this.lblCount = new System.Windows.Forms.Label();
            this.cmbGender = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.pnlTable = new Guna.UI2.WinForms.Guna2Panel();
            this.dgvPatients = new System.Windows.Forms.DataGridView();
            this.colPatient = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHsbaCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRxCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHometown = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDetail = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colHistory = new System.Windows.Forms.DataGridViewButtonColumn();
            this.pnlToolbar.SuspendLayout();
            this.pnlTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatients)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlToolbar
            // 
            this.pnlToolbar.BackColor = System.Drawing.Color.Transparent;
            this.pnlToolbar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.pnlToolbar.BorderRadius = 12;
            this.pnlToolbar.BorderThickness = 1;
            this.pnlToolbar.Controls.Add(this.lblCount);
            this.pnlToolbar.Controls.Add(this.cmbGender);
            this.pnlToolbar.Controls.Add(this.txtSearch);
            this.pnlToolbar.FillColor = System.Drawing.Color.White;
            this.pnlToolbar.Location = new System.Drawing.Point(24, 18);
            this.pnlToolbar.Name = "pnlToolbar";
            this.pnlToolbar.Size = new System.Drawing.Size(1080, 128);
            this.pnlToolbar.TabIndex = 0;
            // 
            // lblCount
            // 
            this.lblCount.Font = new System.Drawing.Font("Segoe UI", 9.2F, System.Drawing.FontStyle.Bold);
            this.lblCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.lblCount.Location = new System.Drawing.Point(846, 88);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(204, 22);
            this.lblCount.TabIndex = 4;
            this.lblCount.Text = "9 bệnh nhân";
            this.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbGender
            // 
            this.cmbGender.BackColor = System.Drawing.Color.Transparent;
            this.cmbGender.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.cmbGender.BorderRadius = 8;
            this.cmbGender.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGender.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(248)))));
            this.cmbGender.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.cmbGender.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.cmbGender.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbGender.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(82)))), ((int)(((byte)(73)))));
            this.cmbGender.ItemHeight = 32;
            this.cmbGender.Items.AddRange(new object[] {
            "Tất cả giới tính",
            "Nam",
            "Nữ"});
            this.cmbGender.Location = new System.Drawing.Point(778, 42);
            this.cmbGender.Name = "cmbGender";
            this.cmbGender.Size = new System.Drawing.Size(272, 38);
            this.cmbGender.StartIndex = 0;
            this.cmbGender.TabIndex = 3;
            this.cmbGender.SelectedIndexChanged += new System.EventHandler(this.FilterChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.txtSearch.BorderRadius = 8;
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.DefaultText = "";
            this.txtSearch.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(248)))));
            this.txtSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(42)))));
            this.txtSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(148)))), ((int)(((byte)(112)))));
            this.txtSearch.IconLeft = ((System.Drawing.Image)(resources.GetObject("txtSearch.IconLeft")));
            this.txtSearch.IconLeftOffset = new System.Drawing.Point(10, 0);
            this.txtSearch.IconLeftSize = new System.Drawing.Size(18, 18);
            this.txtSearch.Location = new System.Drawing.Point(34, 42);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.txtSearch.PlaceholderText = "Tìm theo tên hoặc mã bệnh nhân...";
            this.txtSearch.SelectedText = "";
            this.txtSearch.Size = new System.Drawing.Size(720, 38);
            this.txtSearch.TabIndex = 2;
            this.txtSearch.TextChanged += new System.EventHandler(this.FilterChanged);
            // 
            // pnlTable
            // 
            this.pnlTable.BackColor = System.Drawing.Color.Transparent;
            this.pnlTable.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.pnlTable.BorderRadius = 12;
            this.pnlTable.BorderThickness = 1;
            this.pnlTable.Controls.Add(this.dgvPatients);
            this.pnlTable.FillColor = System.Drawing.Color.White;
            this.pnlTable.Location = new System.Drawing.Point(24, 162);
            this.pnlTable.Name = "pnlTable";
            this.pnlTable.Padding = new System.Windows.Forms.Padding(14);
            this.pnlTable.Size = new System.Drawing.Size(1080, 596);
            this.pnlTable.TabIndex = 1;
            // 
            // dgvPatients
            // 
            this.dgvPatients.AllowUserToAddRows = false;
            this.dgvPatients.AllowUserToDeleteRows = false;
            this.dgvPatients.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(248)))));
            this.dgvPatients.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPatients.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPatients.BackgroundColor = System.Drawing.Color.White;
            this.dgvPatients.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPatients.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvPatients.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPatients.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPatients.ColumnHeadersHeight = 42;
            this.dgvPatients.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPatient,
            this.colGender,
            this.colAge,
            this.colHsbaCount,
            this.colRxCount,
            this.colHometown,
            this.colDetail,
            this.colHistory});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(42)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(244)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(42)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPatients.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPatients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPatients.EnableHeadersVisualStyles = false;
            this.dgvPatients.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(240)))));
            this.dgvPatients.Location = new System.Drawing.Point(14, 14);
            this.dgvPatients.MultiSelect = false;
            this.dgvPatients.Name = "dgvPatients";
            this.dgvPatients.ReadOnly = true;
            this.dgvPatients.RowHeadersVisible = false;
            this.dgvPatients.RowTemplate.Height = 64;
            this.dgvPatients.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPatients.Size = new System.Drawing.Size(1052, 568);
            this.dgvPatients.TabIndex = 0;
            this.dgvPatients.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPatients_CellContentClick);
            // 
            // colPatient
            // 
            this.colPatient.FillWeight = 28F;
            this.colPatient.HeaderText = "BỆNH NHÂN";
            this.colPatient.Name = "colPatient";
            this.colPatient.ReadOnly = true;
            // 
            // colGender
            // 
            this.colGender.FillWeight = 10F;
            this.colGender.HeaderText = "GIỚI TÍNH";
            this.colGender.Name = "colGender";
            this.colGender.ReadOnly = true;
            // 
            // colAge
            // 
            this.colAge.FillWeight = 8F;
            this.colAge.HeaderText = "TUỔI";
            this.colAge.Name = "colAge";
            this.colAge.ReadOnly = true;
            // 
            // colHsbaCount
            // 
            this.colHsbaCount.FillWeight = 8F;
            this.colHsbaCount.HeaderText = "HSBA";
            this.colHsbaCount.Name = "colHsbaCount";
            this.colHsbaCount.ReadOnly = true;
            // 
            // colRxCount
            // 
            this.colRxCount.FillWeight = 10F;
            this.colRxCount.HeaderText = "ĐƠN THUỐC";
            this.colRxCount.Name = "colRxCount";
            this.colRxCount.ReadOnly = true;
            // 
            // colHometown
            // 
            this.colHometown.FillWeight = 17F;
            this.colHometown.HeaderText = "QUÊ QUÁN";
            this.colHometown.Name = "colHometown";
            this.colHometown.ReadOnly = true;
            // 
            // colDetail
            // 
            this.colDetail.FillWeight = 11F;
            this.colDetail.HeaderText = "CHI TIẾT";
            this.colDetail.Name = "colDetail";
            this.colDetail.ReadOnly = true;
            this.colDetail.Text = "Xem chi tiết";
            this.colDetail.UseColumnTextForButtonValue = true;
            // 
            // colHistory
            // 
            this.colHistory.FillWeight = 12F;
            this.colHistory.HeaderText = "TIỀN SỬ";
            this.colHistory.Name = "colHistory";
            this.colHistory.ReadOnly = true;
            this.colHistory.Text = "Tiền sử bệnh";
            this.colHistory.UseColumnTextForButtonValue = true;
            // 
            // ucBenhNhanCuaToi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(245)))), ((int)(((byte)(243)))));
            this.Controls.Add(this.pnlTable);
            this.Controls.Add(this.pnlToolbar);
            this.Name = "ucBenhNhanCuaToi";
            this.Size = new System.Drawing.Size(1128, 782);
            this.pnlToolbar.ResumeLayout(false);
            this.pnlTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatients)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlToolbar;
        private System.Windows.Forms.Label lblCount;
        private Guna.UI2.WinForms.Guna2ComboBox cmbGender;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private Guna.UI2.WinForms.Guna2Panel pnlTable;
        private System.Windows.Forms.DataGridView dgvPatients;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPatient;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGender;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAge;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHsbaCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRxCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHometown;
        private System.Windows.Forms.DataGridViewButtonColumn colDetail;
        private System.Windows.Forms.DataGridViewButtonColumn colHistory;
    }
}
