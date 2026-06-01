namespace HospitalX.GUI.PH2.QuanTriVien
{
    partial class ucAudit
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucAudit));
            this.msgDialog = new Guna.UI2.WinForms.Guna2MessageDialog();
            this.pnlRoot = new System.Windows.Forms.Panel();
            this.pnlLogs = new Guna.UI2.WinForms.Guna2Panel();
            this.dgvLogs = new Guna.UI2.WinForms.Guna2DataGridView();
            this.colAuditId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colObject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDetail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRows = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colResult = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDetailAction = new System.Windows.Forms.DataGridViewButtonColumn();
            this.pnlLogsHeader = new System.Windows.Forms.Panel();
            this.lblResultCount = new System.Windows.Forms.Label();
            this.lblLogsTitle = new System.Windows.Forms.Label();
            this.pnlMiddle = new System.Windows.Forms.Panel();
            this.pnlScenario = new Guna.UI2.WinForms.Guna2Panel();
            this.dgvScenarios = new Guna.UI2.WinForms.Guna2DataGridView();
            this.colScenarioCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colScenarioType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colScenarioName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colScenarioTarget = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colScenarioStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlScenarioHeader = new System.Windows.Forms.Panel();
            this.btnEnableAudit = new Guna.UI2.WinForms.Guna2Button();
            this.lblScenarioTitle = new System.Windows.Forms.Label();
            this.pnlFilter = new Guna.UI2.WinForms.Guna2Panel();
            this.btnClear = new Guna.UI2.WinForms.Guna2Button();
            this.cmbSort = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.cmbObject = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblSort = new System.Windows.Forms.Label();
            this.lblSearch = new System.Windows.Forms.Label();
            this.dtpTo = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.dtpFrom = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.lblFrom = new System.Windows.Forms.Label();
            this.cmbResult = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblResult = new System.Windows.Forms.Label();
            this.cmbAction = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblAction = new System.Windows.Forms.Label();
            this.lblObject = new System.Windows.Forms.Label();
            this.pnlRoot.SuspendLayout();
            this.pnlLogs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogs)).BeginInit();
            this.pnlLogsHeader.SuspendLayout();
            this.pnlMiddle.SuspendLayout();
            this.pnlScenario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvScenarios)).BeginInit();
            this.pnlScenarioHeader.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // msgDialog
            // 
            this.msgDialog.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
            this.msgDialog.Caption = null;
            this.msgDialog.Icon = Guna.UI2.WinForms.MessageDialogIcon.None;
            this.msgDialog.Parent = null;
            this.msgDialog.Style = Guna.UI2.WinForms.MessageDialogStyle.Light;
            this.msgDialog.Text = null;
            // 
            // pnlRoot
            // 
            this.pnlRoot.Controls.Add(this.pnlLogs);
            this.pnlRoot.Controls.Add(this.pnlMiddle);
            this.pnlRoot.Controls.Add(this.pnlFilter);
            this.pnlRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRoot.Location = new System.Drawing.Point(0, 0);
            this.pnlRoot.Name = "pnlRoot";
            this.pnlRoot.Padding = new System.Windows.Forms.Padding(22, 18, 22, 18);
            this.pnlRoot.Size = new System.Drawing.Size(1128, 782);
            this.pnlRoot.TabIndex = 0;
            // 
            // pnlLogs
            // 
            this.pnlLogs.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.pnlLogs.BorderRadius = 10;
            this.pnlLogs.BorderThickness = 1;
            this.pnlLogs.Controls.Add(this.dgvLogs);
            this.pnlLogs.Controls.Add(this.pnlLogsHeader);
            this.pnlLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLogs.FillColor = System.Drawing.Color.White;
            this.pnlLogs.Location = new System.Drawing.Point(22, 403);
            this.pnlLogs.Name = "pnlLogs";
            this.pnlLogs.Padding = new System.Windows.Forms.Padding(1);
            this.pnlLogs.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(236)))), ((int)(((byte)(230)))));
            this.pnlLogs.ShadowDecoration.Depth = 5;
            this.pnlLogs.Size = new System.Drawing.Size(1084, 361);
            this.pnlLogs.TabIndex = 3;
            // 
            // dgvLogs
            // 
            this.dgvLogs.AllowUserToAddRows = false;
            this.dgvLogs.AllowUserToDeleteRows = false;
            this.dgvLogs.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(250)))));
            this.dgvLogs.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLogs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvLogs.ColumnHeadersHeight = 36;
            this.dgvLogs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colAuditId,
            this.colTime,
            this.colUser,
            this.colAction,
            this.colObject,
            this.colDetail,
            this.colRows,
            this.colIp,
            this.colResult,
            this.colDetailAction});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(42)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(244)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(42)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLogs.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvLogs.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(240)))));
            this.dgvLogs.Location = new System.Drawing.Point(4, 53);
            this.dgvLogs.MultiSelect = false;
            this.dgvLogs.Name = "dgvLogs";
            this.dgvLogs.ReadOnly = true;
            this.dgvLogs.RowHeadersVisible = false;
            this.dgvLogs.RowTemplate.Height = 48;
            this.dgvLogs.Size = new System.Drawing.Size(1076, 304);
            this.dgvLogs.TabIndex = 1;
            this.dgvLogs.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvLogs.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvLogs.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvLogs.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvLogs.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvLogs.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvLogs.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(240)))));
            this.dgvLogs.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(248)))));
            this.dgvLogs.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvLogs.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.dgvLogs.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.dgvLogs.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvLogs.ThemeStyle.HeaderStyle.Height = 36;
            this.dgvLogs.ThemeStyle.ReadOnly = true;
            this.dgvLogs.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvLogs.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvLogs.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvLogs.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(42)))));
            this.dgvLogs.ThemeStyle.RowsStyle.Height = 48;
            this.dgvLogs.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(244)))), ((int)(((byte)(240)))));
            this.dgvLogs.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(42)))));
            // 
            // colAuditId
            // 
            this.colAuditId.FillWeight = 78F;
            this.colAuditId.HeaderText = "Mã audit";
            this.colAuditId.Name = "colAuditId";
            this.colAuditId.ReadOnly = true;
            // 
            // colTime
            // 
            this.colTime.FillWeight = 115F;
            this.colTime.HeaderText = "Thời gian";
            this.colTime.Name = "colTime";
            this.colTime.ReadOnly = true;
            // 
            // colUser
            // 
            this.colUser.FillWeight = 88F;
            this.colUser.HeaderText = "User";
            this.colUser.Name = "colUser";
            this.colUser.ReadOnly = true;
            // 
            // colAction
            // 
            this.colAction.FillWeight = 70F;
            this.colAction.HeaderText = "Hành vi";
            this.colAction.Name = "colAction";
            this.colAction.ReadOnly = true;
            // 
            // colObject
            // 
            this.colObject.FillWeight = 82F;
            this.colObject.HeaderText = "Đối tượng";
            this.colObject.Name = "colObject";
            this.colObject.ReadOnly = true;
            // 
            // colDetail
            // 
            this.colDetail.FillWeight = 210F;
            this.colDetail.HeaderText = "Chi tiết";
            this.colDetail.Name = "colDetail";
            this.colDetail.ReadOnly = true;
            // 
            // colRows
            // 
            this.colRows.FillWeight = 58F;
            this.colRows.HeaderText = "Dòng";
            this.colRows.Name = "colRows";
            this.colRows.ReadOnly = true;
            // 
            // colIp
            // 
            this.colIp.FillWeight = 86F;
            this.colIp.HeaderText = "IP nguồn";
            this.colIp.Name = "colIp";
            this.colIp.ReadOnly = true;
            // 
            // colResult
            // 
            this.colResult.FillWeight = 82F;
            this.colResult.HeaderText = "Kết quả";
            this.colResult.Name = "colResult";
            this.colResult.ReadOnly = true;
            // 
            // colDetailAction
            // 
            this.colDetailAction.FillWeight = 64F;
            this.colDetailAction.HeaderText = "";
            this.colDetailAction.Name = "colDetailAction";
            this.colDetailAction.ReadOnly = true;
            this.colDetailAction.Text = "Xem";
            // 
            // pnlLogsHeader
            // 
            this.pnlLogsHeader.BackColor = System.Drawing.Color.White;
            this.pnlLogsHeader.Controls.Add(this.lblResultCount);
            this.pnlLogsHeader.Controls.Add(this.lblLogsTitle);
            this.pnlLogsHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLogsHeader.Location = new System.Drawing.Point(1, 1);
            this.pnlLogsHeader.Name = "pnlLogsHeader";
            this.pnlLogsHeader.Size = new System.Drawing.Size(1082, 52);
            this.pnlLogsHeader.TabIndex = 0;
            // 
            // lblResultCount
            // 
            this.lblResultCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblResultCount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblResultCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblResultCount.Location = new System.Drawing.Point(778, 17);
            this.lblResultCount.Name = "lblResultCount";
            this.lblResultCount.Size = new System.Drawing.Size(286, 20);
            this.lblResultCount.TabIndex = 1;
            this.lblResultCount.Text = "Hiển thị 0 bản ghi kiểm toán";
            this.lblResultCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLogsTitle
            // 
            this.lblLogsTitle.AutoSize = true;
            this.lblLogsTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblLogsTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.lblLogsTitle.Location = new System.Drawing.Point(17, 16);
            this.lblLogsTitle.Name = "lblLogsTitle";
            this.lblLogsTitle.Size = new System.Drawing.Size(138, 20);
            this.lblLogsTitle.TabIndex = 0;
            this.lblLogsTitle.Text = "Nhật ký kiểm toán";
            // 
            // pnlMiddle
            // 
            this.pnlMiddle.Controls.Add(this.pnlScenario);
            this.pnlMiddle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMiddle.Location = new System.Drawing.Point(22, 158);
            this.pnlMiddle.Name = "pnlMiddle";
            this.pnlMiddle.Padding = new System.Windows.Forms.Padding(0, 14, 0, 14);
            this.pnlMiddle.Size = new System.Drawing.Size(1084, 245);
            this.pnlMiddle.TabIndex = 2;
            // 
            // pnlScenario
            // 
            this.pnlScenario.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.pnlScenario.BorderRadius = 10;
            this.pnlScenario.BorderThickness = 2;
            this.pnlScenario.Controls.Add(this.dgvScenarios);
            this.pnlScenario.Controls.Add(this.pnlScenarioHeader);
            this.pnlScenario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlScenario.FillColor = System.Drawing.Color.White;
            this.pnlScenario.Location = new System.Drawing.Point(0, 14);
            this.pnlScenario.Name = "pnlScenario";
            this.pnlScenario.Padding = new System.Windows.Forms.Padding(1);
            this.pnlScenario.Size = new System.Drawing.Size(1084, 217);
            this.pnlScenario.TabIndex = 2;
            // 
            // dgvScenarios
            // 
            this.dgvScenarios.AllowUserToAddRows = false;
            this.dgvScenarios.AllowUserToDeleteRows = false;
            this.dgvScenarios.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(250)))));
            this.dgvScenarios.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvScenarios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvScenarios.ColumnHeadersHeight = 32;
            this.dgvScenarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colScenarioCode,
            this.colScenarioType,
            this.colScenarioName,
            this.colScenarioTarget,
            this.colScenarioStatus});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvScenarios.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvScenarios.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(240)))));
            this.dgvScenarios.Location = new System.Drawing.Point(4, 48);
            this.dgvScenarios.MultiSelect = false;
            this.dgvScenarios.Name = "dgvScenarios";
            this.dgvScenarios.ReadOnly = true;
            this.dgvScenarios.RowHeadersVisible = false;
            this.dgvScenarios.RowTemplate.Height = 34;
            this.dgvScenarios.Size = new System.Drawing.Size(1076, 165);
            this.dgvScenarios.TabIndex = 1;
            this.dgvScenarios.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvScenarios.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvScenarios.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvScenarios.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvScenarios.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvScenarios.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvScenarios.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(240)))));
            this.dgvScenarios.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvScenarios.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvScenarios.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvScenarios.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvScenarios.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvScenarios.ThemeStyle.HeaderStyle.Height = 32;
            this.dgvScenarios.ThemeStyle.ReadOnly = true;
            this.dgvScenarios.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvScenarios.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvScenarios.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvScenarios.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvScenarios.ThemeStyle.RowsStyle.Height = 34;
            this.dgvScenarios.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvScenarios.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // colScenarioCode
            // 
            this.colScenarioCode.FillWeight = 60F;
            this.colScenarioCode.HeaderText = "Mã";
            this.colScenarioCode.Name = "colScenarioCode";
            this.colScenarioCode.ReadOnly = true;
            // 
            // colScenarioType
            // 
            this.colScenarioType.FillWeight = 105F;
            this.colScenarioType.HeaderText = "Loại audit";
            this.colScenarioType.Name = "colScenarioType";
            this.colScenarioType.ReadOnly = true;
            // 
            // colScenarioName
            // 
            this.colScenarioName.FillWeight = 145F;
            this.colScenarioName.HeaderText = "Ngữ cảnh";
            this.colScenarioName.Name = "colScenarioName";
            this.colScenarioName.ReadOnly = true;
            // 
            // colScenarioTarget
            // 
            this.colScenarioTarget.FillWeight = 120F;
            this.colScenarioTarget.HeaderText = "Đối tượng";
            this.colScenarioTarget.Name = "colScenarioTarget";
            this.colScenarioTarget.ReadOnly = true;
            // 
            // colScenarioStatus
            // 
            this.colScenarioStatus.FillWeight = 76F;
            this.colScenarioStatus.HeaderText = "Trạng thái";
            this.colScenarioStatus.Name = "colScenarioStatus";
            this.colScenarioStatus.ReadOnly = true;
            // 
            // pnlScenarioHeader
            // 
            this.pnlScenarioHeader.BackColor = System.Drawing.Color.White;
            this.pnlScenarioHeader.Controls.Add(this.btnEnableAudit);
            this.pnlScenarioHeader.Controls.Add(this.lblScenarioTitle);
            this.pnlScenarioHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlScenarioHeader.Location = new System.Drawing.Point(1, 1);
            this.pnlScenarioHeader.Name = "pnlScenarioHeader";
            this.pnlScenarioHeader.Size = new System.Drawing.Size(1082, 47);
            this.pnlScenarioHeader.TabIndex = 0;
            // 
            // btnEnableAudit
            // 
            this.btnEnableAudit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnableAudit.BorderRadius = 8;
            this.btnEnableAudit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEnableAudit.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(240)))));
            this.btnEnableAudit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.btnEnableAudit.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.btnEnableAudit.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnableAudit.ForeColor = System.Drawing.Color.White;
            this.btnEnableAudit.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(148)))), ((int)(((byte)(112)))));
            this.btnEnableAudit.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnEnableAudit.Location = new System.Drawing.Point(901, 9);
            this.btnEnableAudit.Name = "btnEnableAudit";
            this.btnEnableAudit.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(79)))), ((int)(((byte)(61)))));
            this.btnEnableAudit.Size = new System.Drawing.Size(163, 30);
            this.btnEnableAudit.TabIndex = 2;
            this.btnEnableAudit.Text = "Kích hoạt audit";
            // 
            // lblScenarioTitle
            // 
            this.lblScenarioTitle.AutoSize = true;
            this.lblScenarioTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblScenarioTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.lblScenarioTitle.Location = new System.Drawing.Point(17, 14);
            this.lblScenarioTitle.Name = "lblScenarioTitle";
            this.lblScenarioTitle.Size = new System.Drawing.Size(117, 20);
            this.lblScenarioTitle.TabIndex = 0;
            this.lblScenarioTitle.Text = "Ngữ cảnh audit";
            // 
            // pnlFilter
            // 
            this.pnlFilter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.pnlFilter.BorderRadius = 10;
            this.pnlFilter.BorderThickness = 1;
            this.pnlFilter.Controls.Add(this.btnClear);
            this.pnlFilter.Controls.Add(this.cmbSort);
            this.pnlFilter.Controls.Add(this.lblSort);
            this.pnlFilter.Controls.Add(this.dtpTo);
            this.pnlFilter.Controls.Add(this.lblTo);
            this.pnlFilter.Controls.Add(this.dtpFrom);
            this.pnlFilter.Controls.Add(this.lblFrom);
            this.pnlFilter.Controls.Add(this.cmbResult);
            this.pnlFilter.Controls.Add(this.lblResult);
            this.pnlFilter.Controls.Add(this.cmbAction);
            this.pnlFilter.Controls.Add(this.lblAction);
            this.pnlFilter.Controls.Add(this.cmbObject);
            this.pnlFilter.Controls.Add(this.lblObject);
            this.pnlFilter.Controls.Add(this.txtSearch);
            this.pnlFilter.Controls.Add(this.lblSearch);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.FillColor = System.Drawing.Color.White;
            this.pnlFilter.Location = new System.Drawing.Point(22, 18);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(1084, 140);
            this.pnlFilter.TabIndex = 0;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Transparent;
            this.btnClear.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.btnClear.BorderRadius = 12;
            this.btnClear.BorderThickness = 1;
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(240)))));
            this.btnClear.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.btnClear.FillColor = System.Drawing.Color.White;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnClear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.btnClear.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(244)))), ((int)(((byte)(240)))));
            this.btnClear.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(79)))), ((int)(((byte)(61)))));
            this.btnClear.Location = new System.Drawing.Point(309, 96);
            this.btnClear.Name = "btnClear";
            this.btnClear.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(226)))), ((int)(((byte)(216)))));
            this.btnClear.Size = new System.Drawing.Size(112, 36);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "Xóa lọc";
            // 
            // cmbSort
            // 
            this.cmbSort.BackColor = System.Drawing.Color.Transparent;
            this.cmbSort.BorderColor = this.txtSearch.BorderColor;
            this.cmbSort.BorderRadius = 8;
            this.cmbSort.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSort.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.cmbSort.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.cmbSort.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbSort.ForeColor = this.cmbObject.ForeColor;
            this.cmbSort.ItemHeight = 30;
            this.cmbSort.Items.AddRange(new object[] {
            "Mới nhất",
            "Cũ nhất",
            "User A-Z"});
            this.cmbSort.Location = new System.Drawing.Point(763, 40);
            this.cmbSort.Name = "cmbSort";
            this.cmbSort.Size = new System.Drawing.Size(140, 36);
            this.cmbSort.StartIndex = 0;
            this.cmbSort.TabIndex = 2;
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.Transparent;
            this.txtSearch.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.txtSearch.BorderRadius = 8;
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.DefaultText = "";
            this.txtSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(42)))));
            this.txtSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.txtSearch.IconLeft = ((System.Drawing.Image)(resources.GetObject("txtSearch.IconLeft")));
            this.txtSearch.Location = new System.Drawing.Point(20, 40);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PlaceholderText = "Mã audit, user, đối tượng, nội dung...";
            this.txtSearch.SelectedText = "";
            this.txtSearch.Size = new System.Drawing.Size(270, 36);
            this.txtSearch.TabIndex = 14;
            // 
            // cmbObject
            // 
            this.cmbObject.BackColor = System.Drawing.Color.Transparent;
            this.cmbObject.BorderColor = this.txtSearch.BorderColor;
            this.cmbObject.BorderRadius = 8;
            this.cmbObject.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbObject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbObject.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.cmbObject.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.cmbObject.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbObject.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(42)))));
            this.cmbObject.ItemHeight = 30;
            this.cmbObject.Items.AddRange(new object[] {
            "Tất cả đối tượng",
            "HSBA",
            "HSBA_DV",
            "ĐƠNTHUỐC",
            "SESSION",
            "DBA_AUDIT_TRAIL",
            "AUDIT_POLICY",
            "BACKUP_HISTORY"});
            this.cmbObject.Location = new System.Drawing.Point(306, 40);
            this.cmbObject.Name = "cmbObject";
            this.cmbObject.Size = new System.Drawing.Size(150, 36);
            this.cmbObject.StartIndex = 0;
            this.cmbObject.TabIndex = 12;
            // 
            // lblSort
            // 
            this.lblSort.AutoSize = true;
            this.lblSort.BackColor = System.Drawing.Color.Transparent;
            this.lblSort.Font = this.lblSearch.Font;
            this.lblSort.ForeColor = this.lblSearch.ForeColor;
            this.lblSort.Location = new System.Drawing.Point(760, 18);
            this.lblSort.Name = "lblSort";
            this.lblSort.Size = new System.Drawing.Size(53, 15);
            this.lblSort.TabIndex = 3;
            this.lblSort.Text = "SẮP XẾP";
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.BackColor = System.Drawing.Color.Transparent;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblSearch.Location = new System.Drawing.Point(20, 18);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(61, 15);
            this.lblSearch.TabIndex = 15;
            this.lblSearch.Text = "TÌM KIẾM";
            // 
            // dtpTo
            // 
            this.dtpTo.BackColor = System.Drawing.Color.Transparent;
            this.dtpTo.BorderRadius = 8;
            this.dtpTo.Checked = true;
            this.dtpTo.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(247)))), ((int)(((byte)(237)))));
            this.dtpTo.FillColor = System.Drawing.Color.White;
            this.dtpTo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(168, 104);
            this.dtpTo.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpTo.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(132, 28);
            this.dtpTo.TabIndex = 4;
            this.dtpTo.Value = new System.DateTime(2026, 5, 24, 0, 0, 0, 0);
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.BackColor = System.Drawing.Color.Transparent;
            this.lblTo.Font = this.lblSearch.Font;
            this.lblTo.ForeColor = this.lblSearch.ForeColor;
            this.lblTo.Location = new System.Drawing.Point(168, 86);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(66, 15);
            this.lblTo.TabIndex = 5;
            this.lblTo.Text = "ĐẾN NGÀY";
            // 
            // dtpFrom
            // 
            this.dtpFrom.BackColor = System.Drawing.Color.Transparent;
            this.dtpFrom.BorderRadius = 8;
            this.dtpFrom.Checked = true;
            this.dtpFrom.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(247)))), ((int)(((byte)(237)))));
            this.dtpFrom.FillColor = System.Drawing.Color.White;
            this.dtpFrom.FocusedColor = System.Drawing.Color.White;
            this.dtpFrom.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(20, 104);
            this.dtpFrom.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpFrom.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(132, 28);
            this.dtpFrom.TabIndex = 6;
            this.dtpFrom.Value = new System.DateTime(2026, 5, 21, 0, 0, 0, 0);
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.BackColor = System.Drawing.Color.Transparent;
            this.lblFrom.Font = this.lblSearch.Font;
            this.lblFrom.ForeColor = this.lblSearch.ForeColor;
            this.lblFrom.Location = new System.Drawing.Point(20, 86);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(58, 15);
            this.lblFrom.TabIndex = 7;
            this.lblFrom.Text = "TỪ NGÀY";
            // 
            // cmbResult
            // 
            this.cmbResult.BackColor = System.Drawing.Color.Transparent;
            this.cmbResult.BorderColor = this.txtSearch.BorderColor;
            this.cmbResult.BorderRadius = 8;
            this.cmbResult.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbResult.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbResult.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.cmbResult.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.cmbResult.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbResult.ForeColor = this.cmbObject.ForeColor;
            this.cmbResult.ItemHeight = 30;
            this.cmbResult.Items.AddRange(new object[] {
            "Tất cả kết quả",
            "Thành công",
            "Thất bại"});
            this.cmbResult.Location = new System.Drawing.Point(613, 40);
            this.cmbResult.Name = "cmbResult";
            this.cmbResult.Size = new System.Drawing.Size(135, 36);
            this.cmbResult.StartIndex = 0;
            this.cmbResult.TabIndex = 8;
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.BackColor = System.Drawing.Color.Transparent;
            this.lblResult.Font = this.lblSearch.Font;
            this.lblResult.ForeColor = this.lblSearch.ForeColor;
            this.lblResult.Location = new System.Drawing.Point(613, 18);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(57, 15);
            this.lblResult.TabIndex = 9;
            this.lblResult.Text = "KẾT QUẢ";
            // 
            // cmbAction
            // 
            this.cmbAction.BackColor = System.Drawing.Color.Transparent;
            this.cmbAction.BorderColor = this.txtSearch.BorderColor;
            this.cmbAction.BorderRadius = 8;
            this.cmbAction.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAction.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.cmbAction.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.cmbAction.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbAction.ForeColor = this.cmbObject.ForeColor;
            this.cmbAction.ItemHeight = 30;
            this.cmbAction.Items.AddRange(new object[] {
            "Tất cả hành vi",
            "INSERT",
            "UPDATE",
            "DELETE",
            "SELECT",
            "LOGIN"});
            this.cmbAction.Location = new System.Drawing.Point(472, 40);
            this.cmbAction.Name = "cmbAction";
            this.cmbAction.Size = new System.Drawing.Size(125, 36);
            this.cmbAction.StartIndex = 0;
            this.cmbAction.TabIndex = 10;
            // 
            // lblAction
            // 
            this.lblAction.AutoSize = true;
            this.lblAction.BackColor = System.Drawing.Color.Transparent;
            this.lblAction.Font = this.lblSearch.Font;
            this.lblAction.ForeColor = this.lblSearch.ForeColor;
            this.lblAction.Location = new System.Drawing.Point(472, 18);
            this.lblAction.Name = "lblAction";
            this.lblAction.Size = new System.Drawing.Size(57, 15);
            this.lblAction.TabIndex = 11;
            this.lblAction.Text = "HÀNH VI";
            // 
            // lblObject
            // 
            this.lblObject.AutoSize = true;
            this.lblObject.BackColor = System.Drawing.Color.Transparent;
            this.lblObject.Font = this.lblSearch.Font;
            this.lblObject.ForeColor = this.lblSearch.ForeColor;
            this.lblObject.Location = new System.Drawing.Point(306, 18);
            this.lblObject.Name = "lblObject";
            this.lblObject.Size = new System.Drawing.Size(75, 15);
            this.lblObject.TabIndex = 13;
            this.lblObject.Text = "ĐỐI TƯỢNG";
            // 
            // ucAudit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.Controls.Add(this.pnlRoot);
            this.Name = "ucAudit";
            this.Size = new System.Drawing.Size(1128, 782);
            this.Load += new System.EventHandler(this.ucAudit_Load);
            this.pnlRoot.ResumeLayout(false);
            this.pnlLogs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogs)).EndInit();
            this.pnlLogsHeader.ResumeLayout(false);
            this.pnlLogsHeader.PerformLayout();
            this.pnlMiddle.ResumeLayout(false);
            this.pnlScenario.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvScenarios)).EndInit();
            this.pnlScenarioHeader.ResumeLayout(false);
            this.pnlScenarioHeader.PerformLayout();
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2MessageDialog msgDialog;
        private System.Windows.Forms.Panel pnlRoot;
        private Guna.UI2.WinForms.Guna2Panel pnlFilter;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private Guna.UI2.WinForms.Guna2ComboBox cmbObject;
        private System.Windows.Forms.Label lblObject;
        private Guna.UI2.WinForms.Guna2ComboBox cmbAction;
        private System.Windows.Forms.Label lblAction;
        private Guna.UI2.WinForms.Guna2ComboBox cmbResult;
        private System.Windows.Forms.Label lblResult;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblFrom;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpTo;
        private System.Windows.Forms.Label lblTo;
        private Guna.UI2.WinForms.Guna2ComboBox cmbSort;
        private System.Windows.Forms.Label lblSort;
        private Guna.UI2.WinForms.Guna2Button btnClear;
        private System.Windows.Forms.Panel pnlMiddle;
        private Guna.UI2.WinForms.Guna2Panel pnlScenario;
        private System.Windows.Forms.Panel pnlScenarioHeader;
        private System.Windows.Forms.Label lblScenarioTitle;
        private Guna.UI2.WinForms.Guna2Button btnEnableAudit;
        private Guna.UI2.WinForms.Guna2DataGridView dgvScenarios;
        private System.Windows.Forms.DataGridViewTextBoxColumn colScenarioCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colScenarioType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colScenarioName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colScenarioTarget;
        private System.Windows.Forms.DataGridViewTextBoxColumn colScenarioStatus;
        private Guna.UI2.WinForms.Guna2Panel pnlLogs;
        private System.Windows.Forms.Panel pnlLogsHeader;
        private System.Windows.Forms.Label lblResultCount;
        private System.Windows.Forms.Label lblLogsTitle;
        private Guna.UI2.WinForms.Guna2DataGridView dgvLogs;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAuditId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAction;
        private System.Windows.Forms.DataGridViewTextBoxColumn colObject;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRows;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIp;
        private System.Windows.Forms.DataGridViewTextBoxColumn colResult;
        private System.Windows.Forms.DataGridViewButtonColumn colDetailAction;
    }
}
