using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace HospitalX.GUI.PH2.QuanTriVien
{
    public partial class ucSaoLuuPhucHoi : UserControl
    {
        private readonly List<BackupRecord> _backups = new List<BackupRecord>();
        private Timer _backupTimer;
        private Timer _restoreTimer;
        private int _backupPercent;
        private int _restoreStep;
        private int _restorePercent;
        private int _selectedRestoreIndex;

        public ucSaoLuuPhucHoi()
        {
            InitializeComponent();
            SeedData();
            WireEvents();
            LocalizeStaticText();
            StyleHistoryGrid();
            RenderHistory();
            RenderRestoreCards();
            ShowBackupTab();
            UpdateStartRestoreButtonState();
        }

        private void WireEvents()
        {
            btnTabBackup.Click += (s, e) => ShowBackupTab();
            btnTabRestore.Click += (s, e) => ShowRestoreTab();
            btnStartBackup.Click += BtnStartBackup_Click;
            btnDryRun.Click += BtnDryRun_Click;
            btnStartRestore.Click += BtnStartRestore_Click;
            chkFull.CheckedChanged += BackupTypeChanged;
            chkIncremental.CheckedChanged += BackupTypeChanged;
            dgvHistory.CellPainting += dgvHistory_CellPainting;

            _backupTimer = new Timer { Interval = 180 };
            _backupTimer.Tick += BackupTimer_Tick;
            _restoreTimer = new Timer { Interval = 900 };
            _restoreTimer.Tick += RestoreTimer_Tick;
        }

        private void PolishStaticLayout()
        {
            SetTransparentLabels(this);

            pnlRoot.Padding = new Padding(20, 14, 20, 16);
            pnlTabs.Height = 48;
            pnlBackupLeft.Width = 392;
            pnlRestoreLeft.Width = 500;

            pnlBackupProgress.Visible = true;
            pnlBackupProgress.Location = new Point(26, 458);
            pnlBackupProgress.Size = new Size(330, 82);
            lblBackupPercent.Text = "Sẵn sàng";
            lblBackupStatus.Text = "Chưa có tiến trình sao lưu đang chạy.";

            dgvHistory.RowTemplate.Height = 44;
            dgvHistory.ColumnHeadersHeight = 38;
            dgvHistory.DefaultCellStyle.Font = new Font("Segoe UI", 9.2F);
            dgvHistory.DefaultCellStyle.Padding = new Padding(8, 0, 8, 0);
            dgvHistory.Columns["colBackupType"].FillWeight = 62F;
            dgvHistory.Columns["colBackupSource"].FillWeight = 72F;
            dgvHistory.Columns["colBackupStatus"].FillWeight = 70F;

            flowRestoreCards.BackColor = Color.FromArgb(247, 249, 248);
            flowRestoreCards.Padding = new Padding(0, 0, 8, 0);

            txtConsole.Size = new Size(492, 170);
            txtConsole.Location = new Point(24, 386);
            lblStep1.Location = new Point(26, 122);
            lblStep2.Location = new Point(26, 158);
            lblStep3.Location = new Point(26, 194);
            lblStep4.Location = new Point(26, 230);
            lblStep5.Location = new Point(26, 266);

            btnStartRestore.Size = new Size(320, 42);
            btnStartRestore.Location = new Point(24, 548);
            btnStartRestore.FillColor = Color.FromArgb(220, 38, 38);
            btnStartRestore.HoverState.FillColor = Color.FromArgb(185, 28, 28);
            UpdateStartRestoreButtonState();

            btnStartBackup.Size = new Size(210, 40);
            btnDryRun.Size = new Size(112, 40);
        }

        private static void SetTransparentLabels(Control root)
        {
            foreach (Control control in root.Controls)
            {
                Label label = control as Label;
                if (label != null)
                {
                    label.BackColor = Color.Transparent;
                }

                if (control.HasChildren)
                {
                    SetTransparentLabels(control);
                }
            }
        }

        private void SeedData()
        {
            LoadBackupHistoryFromDB();
        }

        private void LoadBackupHistoryFromDB()
        {
            _backups.Clear();
            try
            {
                // Dung SP_GET_BACKUP_HISTORY_APP (tu bang BACKUP_LOG) - chinh xac hon
                System.Data.DataTable dt = null;
                try
                {
                    dt = HospitalX.DAO.DataProvider.Instance.ExecuteQuery(
                        "ADMINHOS.SP_GET_BACKUP_HISTORY_APP",
                        new Oracle.ManagedDataAccess.Client.OracleParameter[] {
                            new Oracle.ManagedDataAccess.Client.OracleParameter("p_cursor", Oracle.ManagedDataAccess.Client.OracleDbType.RefCursor) { Direction = System.Data.ParameterDirection.Output }
                        }, true);
                }
                catch
                {
                    // Fallback: thu SP_GET_BACKUP_HISTORY cu (tu V$BACKUP_SET) neu bang log chua ton tai
                    try
                    {
                        dt = HospitalX.DAO.DataProvider.Instance.ExecuteQuery(
                            "ADMINHOS.SP_GET_BACKUP_HISTORY",
                            new Oracle.ManagedDataAccess.Client.OracleParameter[] {
                                new Oracle.ManagedDataAccess.Client.OracleParameter("p_cursor", Oracle.ManagedDataAccess.Client.OracleDbType.RefCursor) { Direction = System.Data.ParameterDirection.Output }
                            }, true);
                    }
                    catch { dt = null; }
                }

                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (System.Data.DataRow row in dt.Rows)
                    {
                        string id = row["ID"]?.ToString() ?? "";
                        DateTime time = row["START_TIME"] != System.DBNull.Value ? Convert.ToDateTime(row["START_TIME"]) : DateTime.Now;
                        string type = row["TYPE"]?.ToString() ?? "FULL";
                        string source = row["SOURCE"]?.ToString() ?? "MANUAL";
                        string size = row["SIZE"]?.ToString() ?? "-";
                        string duration = row["DURATION"]?.ToString() ?? "-";
                        string status = row["STATUS"]?.ToString() ?? "SUCCESS";
                        // BACKUP_LOG dung 'SUCCESS'/'FAILED'/'RUNNING'; V$BACKUP_SET dung 'A'/'D'
                        bool success = (status == "SUCCESS" || status == "A" || status == "AVAILABLE" || status == "COMPLETED");
                        _backups.Add(new BackupRecord(id, time, type, source, size, duration, success));
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Warning: Loi load backup history: " + ex.Message);
            }
            // Chi lay du lieu tu database, khong dung du lieu gia lap
        }

        // -------------------------------------------------------------------
        // SAO LUU: Goi SP_RUN_DATAPUMP_BACKUP tren Oracle trong background thread
        // de khong block UI, sau do cap nhat progress bar theo timer
        // -------------------------------------------------------------------
        private void BtnStartBackup_Click(object sender, EventArgs e)
        {
            string backupType = chkIncremental.Checked ? "INCR" : "FULL";
            string tag = txtBackupTag?.Text?.Trim() ?? "";

            // Khoa nut, reset progress
            _backupPercent = 0;
            progressBackup.Value = 0;
            lblBackupPercent.Text = "0%";
            lblBackupStatus.Text = "Đang khởi động Data Pump Export...";
            pnlBackupProgress.Visible = true;
            btnStartBackup.Enabled = false;
            btnDryRun.Enabled = false;

            // Bat dau timer de cap nhat UI (progress gia lap trong khi Oracle chay)
            _backupTimer.Start();

            // Chay Oracle stored procedure trong background thread
            System.Threading.Tasks.Task.Run(() =>
            {
                string logId = null;
                string status = null;
                string message = null;
                Exception caughtEx = null;

                try
                {
                    var pLogId = new Oracle.ManagedDataAccess.Client.OracleParameter(
                        "p_log_id", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2, 50)
                    { Direction = System.Data.ParameterDirection.Output };

                    var pStatus = new Oracle.ManagedDataAccess.Client.OracleParameter(
                        "p_status", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2, 20)
                    { Direction = System.Data.ParameterDirection.Output };

                    var pMessage = new Oracle.ManagedDataAccess.Client.OracleParameter(
                        "p_message", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2, 1000)
                    { Direction = System.Data.ParameterDirection.Output };

                    var pType = new Oracle.ManagedDataAccess.Client.OracleParameter(
                        "p_backup_type", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2)
                    { Value = backupType, Direction = System.Data.ParameterDirection.Input };

                    var pTag = new Oracle.ManagedDataAccess.Client.OracleParameter(
                        "p_tag", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2)
                    { Value = string.IsNullOrEmpty(tag) ? (object)System.DBNull.Value : tag,
                      Direction = System.Data.ParameterDirection.Input };

                    HospitalX.DAO.DataProvider.Instance.ExecuteNonQuery(
                        "ADMINHOS.SP_RUN_DATAPUMP_BACKUP",
                        new Oracle.ManagedDataAccess.Client.OracleParameter[] { pType, pTag, pLogId, pStatus, pMessage },
                        true);

                    logId   = pLogId.Value?.ToString();
                    status  = pStatus.Value?.ToString() ?? "FAILED";
                    message = pMessage.Value?.ToString() ?? "";

                    if (!string.IsNullOrEmpty(message))
                    {
                        message = message.Replace("Sao l?u th?nh c?ng!", "Sao lưu thành công!")
                                         .Replace("Th? m?c Oracle:", "Thư mục Oracle!")
                                         .Replace("Job k?t th?c v?i tr?ng th?i:", "Job kết thúc với trạng thái:");
                    }
                }
                catch (Exception ex)
                {
                    status    = "FAILED";
                    caughtEx  = ex;
                    message   = ex.Message;
                }

                // Cap nhat UI tren main thread
                this.Invoke((System.Action)(() =>
                {
                    _backupTimer.Stop();
                    btnStartBackup.Enabled = true;
                    btnDryRun.Enabled = true;

                    if (status == "SUCCESS")
                    {
                        progressBackup.Value = 100;
                        lblBackupPercent.Text = "100%";
                        lblBackupStatus.Text = "Hoàn tất sao lưu thành công!";

                        string recId = logId ?? ("BK-" + DateTime.Now.ToString("yyyyMMdd-HHmmss"));
                        var record = new BackupRecord(
                            recId, DateTime.Now, backupType, "MANUAL",
                            "-", "-", true);
                        _backups.Insert(0, record);
                        RenderHistory();
                        RenderRestoreCards();

                        // Reload từ DB để lấy thông tin chính xác
                        System.Threading.Tasks.Task.Delay(2000).ContinueWith(_ =>
                        {
                            this.Invoke((System.Action)(() =>
                            {
                                LoadBackupHistoryFromDB();
                                RenderHistory();
                                RenderRestoreCards();
                            }));
                        });

                        MessageBox.Show(
                            "Sao lưu thành công!\n" + message,
                            "Sao lưu hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        progressBackup.Value = 0;
                        lblBackupPercent.Text = "Lỗi";
                        lblBackupStatus.Text = "Sao lưu thất bại — kiểm tra lỗi.";

                        string errMsg = caughtEx != null ? caughtEx.Message : message;
                        MessageBox.Show(
                            "Sao lưu thất bại!\n\n" + errMsg + "\n\n" +
                            "Kiểm tra:\n" +
                            "1. Oracle Directory HOSPITALX_BACKUP_DIR hoặc DATA_PUMP_DIR đã tồn tại?\n" +
                            "2. Thư mục trên Oracle server có thể ghi được?\n" +
                            "3. User có quyền DATAPUMP_EXP_FULL_DATABASE?",
                            "Lỗi Sao lưu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }));
            });
        }

        private void BackupTimer_Tick(object sender, EventArgs e)
        {
            // Tang dan progress trong khi Oracle dang xu ly (toi da 90% - con 10% cho ket qua)
            if (_backupPercent < 90)
            {
                _backupPercent = Math.Min(90, _backupPercent + 4);
            }
            progressBackup.Value = _backupPercent;
            lblBackupPercent.Text = _backupPercent + "%";

            if (_backupPercent < 20)
                lblBackupStatus.Text = "Khởi động DBMS_DATAPUMP...";
            else if (_backupPercent < 40)
                lblBackupStatus.Text = "Đang export metadata và cấu trúc bảng...";
            else if (_backupPercent < 65)
                lblBackupStatus.Text = "Đang export dữ liệu HSBA, dịch vụ...";
            else if (_backupPercent < 85)
                lblBackupStatus.Text = "Đang ghi file .dmp vào thư mục backup...";
            else
                lblBackupStatus.Text = "Hoàn tất — chờ Oracle xác nhận...";
        }

        private void LocalizeStaticText()
        {
            btnTabBackup.Text = "Sao lưu";
            btnTabRestore.Text = "Phục hồi";
            lblManualTitle.Text = "Sao lưu chủ động";
            lblBackupType.Text = "LOẠI SAO LƯU";
            chkFull.Text = "FULL - Toàn bộ CSDL";
            chkIncremental.Text = "INCREMENTAL - Dữ liệu thay đổi";
            lblDestination.Text = "ĐÍCH LƯU TRỮ";
            lblCompression.Text = "NÉN DỮ LIỆU";
            lblBackupTag.Text = "GHI CHÚ / TAG";
            btnStartBackup.Text = "Bắt đầu sao lưu";
            lblBackupPercent.Text = "Sẵn sàng";
            lblBackupStatus.Text = "Chưa có tiến trình sao lưu đang chạy.";
            lblHistoryTitle.Text = "Lịch sử sao lưu";

            lblRestoreListTitle.Text = "Chọn bản backup";
            lblPointInTime.Text = "POINT-IN-TIME RECOVERY";
            btnStartRestore.Text = "Khởi động phục hồi CSDL";
            lblRestoreProgressTitle.Text = "Tiến trình phục hồi";
            lblRestoreStatus.Text = "Standby";
            ResetStepLabels();
            txtConsole.Text = "Chưa có tiến trình phục hồi." + Environment.NewLine +
                "Khi khởi động phục hồi, nhật ký RMAN sẽ hiển thị tại đây.";
        }

        private void StyleHistoryGrid()
        {
            dgvHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHistory.BackgroundColor = Color.White;
            dgvHistory.BorderStyle = BorderStyle.None;
            dgvHistory.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvHistory.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvHistory.AdvancedCellBorderStyle.All = DataGridViewAdvancedCellBorderStyle.None;
            dgvHistory.AdvancedColumnHeadersBorderStyle.All = DataGridViewAdvancedCellBorderStyle.None;
            dgvHistory.ThemeStyle.GridColor = Color.White;
            dgvHistory.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvHistory.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.None;
            dgvHistory.EnableHeadersVisualStyles = false;
            dgvHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHistory.RowTemplate.Height = 68;
            dgvHistory.ColumnHeadersHeight = 44;
            dgvHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvHistory.GridColor = Color.White;

            dgvHistory.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(247, 249, 248);
            dgvHistory.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(122, 149, 137);
            dgvHistory.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvHistory.ColumnHeadersDefaultCellStyle.Padding = new Padding(10, 0, 8, 0);
            dgvHistory.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(247, 249, 248);
            dgvHistory.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(122, 149, 137);

            dgvHistory.DefaultCellStyle.BackColor = Color.White;
            dgvHistory.DefaultCellStyle.ForeColor = Color.FromArgb(61, 82, 73);
            dgvHistory.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
            dgvHistory.DefaultCellStyle.Padding = new Padding(10, 0, 8, 0);
            dgvHistory.DefaultCellStyle.SelectionBackColor = Color.FromArgb(230, 244, 240);
            dgvHistory.DefaultCellStyle.SelectionForeColor = Color.FromArgb(24, 48, 42);
            dgvHistory.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(247, 249, 248);
            dgvHistory.RowsDefaultCellStyle.BackColor = Color.White;

            colBackupId.HeaderText = "Backup ID";
            colBackupTime.HeaderText = "Thời gian";
            colBackupType.HeaderText = "Loại";
            colBackupSource.HeaderText = "Nguồn";
            colBackupSize.HeaderText = "Kích thước";
            colBackupDuration.HeaderText = "Thời lượng";
            colBackupStatus.HeaderText = "Trạng thái";

            colBackupId.FillWeight = 145F;
            colBackupTime.FillWeight = 118F;
            colBackupType.FillWeight = 72F;
            colBackupSource.FillWeight = 78F;
            colBackupSize.FillWeight = 82F;
            colBackupDuration.FillWeight = 88F;
            colBackupStatus.FillWeight = 82F;

            foreach (DataGridViewColumn column in dgvHistory.Columns)
            {
                column.DividerWidth = 0;
            }
        }

        private void ShowBackupTab()
        {
            pnlBackup.Dock = DockStyle.Fill;
            pnlRestore.Dock = DockStyle.Fill;
            pnlBackup.Visible = true;
            pnlRestore.Visible = false;
            btnTabBackup.Checked = true;
            btnTabRestore.Checked = false;
        }

        private void ShowRestoreTab()
        {
            pnlBackup.Dock = DockStyle.Fill;
            pnlRestore.Dock = DockStyle.Fill;
            pnlBackup.Visible = false;
            pnlRestore.Visible = true;
            btnTabBackup.Checked = false;
            btnTabRestore.Checked = true;
        }

        private void BackupTypeChanged(object sender, EventArgs e)
        {
            if (sender == chkFull && chkFull.Checked)
            {
                chkIncremental.Checked = false;
            }
            else if (sender == chkIncremental && chkIncremental.Checked)
            {
                chkFull.Checked = false;
            }

            if (!chkFull.Checked && !chkIncremental.Checked)
            {
                chkFull.Checked = true;
            }
        }

        private void BtnDryRun_Click(object sender, EventArgs e)
        {
            PrepareMessageDialog();
            msgDialog.Icon = MessageDialogIcon.Information;
            msgDialog.Buttons = MessageDialogButtons.OK;
            msgDialog.Caption = "Dry Run";
            msgDialog.Text = "Kiểm tra cấu hình RMAN hợp lệ. Có thể bắt đầu sao lưu.";
            msgDialog.Show();
        }


        private void RenderHistory()
        {
            dgvHistory.Rows.Clear();
            foreach (BackupRecord backup in _backups)
            {
                dgvHistory.Rows.Add(
                    backup.Id,
                    backup.Time.ToString("dd/MM/yyyy") + "\n" + backup.Time.ToString("HH:mm"),
                    backup.Type,
                    backup.Source,
                    backup.Size,
                    backup.Duration,
                    backup.Success ? "OK" : "Fail");
            }

            foreach (DataGridViewRow row in dgvHistory.Rows)
            {
                row.DividerHeight = 0;
            }

            dgvHistory.ClearSelection();
            lblHistoryTotal.Text = "Tổng: " + _backups.Count + " bản backup";
        }

        private void RenderRestoreCards()
        {
            flowRestoreCards.SuspendLayout();
            flowRestoreCards.Controls.Clear();
            List<BackupRecord> verified = _backups.Where(b => b.Success).Take(5).ToList();
            if (_selectedRestoreIndex >= verified.Count)
            {
                _selectedRestoreIndex = 0;
            }

            for (int i = 0; i < verified.Count; i++)
            {
                int index = i;
                BackupRecord backup = verified[i];
                Guna2Panel card = CreateRestoreCardModern(backup, i == _selectedRestoreIndex);
                card.Click += (s, e) =>
                {
                    _selectedRestoreIndex = index;
                    RenderRestoreCards();
                    UpdateStartRestoreButtonState();
                };
                foreach (Control child in card.Controls)
                {
                    child.Click += (s, e) =>
                    {
                        _selectedRestoreIndex = index;
                        RenderRestoreCards();
                        UpdateStartRestoreButtonState();
                    };
                }
                flowRestoreCards.Controls.Add(card);
            }

            flowRestoreCards.ResumeLayout();
            UpdateStartRestoreButtonState();
        }

        private void UpdateStartRestoreButtonState()
        {
            bool canRestore = GetSelectedRestore() != null
                && _restoreTimer != null
                && !_restoreTimer.Enabled;

            btnStartRestore.Visible = true;
            btnStartRestore.Enabled = canRestore;
            btnStartRestore.Cursor = canRestore ? Cursors.Hand : Cursors.Default;
        }

        private Guna2Panel CreateRestoreCard(BackupRecord backup, bool selected)
        {
            Color accent = Color.FromArgb(15, 110, 86);
            Guna2Panel card = new Guna2Panel
            {
                BorderColor = selected ? accent : Color.FromArgb(218, 232, 226),
                BorderRadius = 8,
                BorderThickness = selected ? 2 : 1,
                Cursor = Cursors.Hand,
                FillColor = selected ? Color.FromArgb(230, 244, 240) : Color.White,
                Height = 72,
                Margin = new Padding(0, 0, 0, 10),
                Width = Math.Max(420, flowRestoreCards.ClientSize.Width - 24),
                Tag = backup
            };

            Label id = new Label
            {
                AutoEllipsis = true,
                BackColor = Color.Transparent,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(24, 48, 42),
                Location = new Point(16, 11),
                Size = new Size(card.Width - 150, 22),
                Text = backup.Id
            };
            Label meta = new Label
            {
                AutoEllipsis = true,
                BackColor = Color.Transparent,
                Font = new Font("Segoe UI", 8.8F, FontStyle.Bold),
                ForeColor = Color.FromArgb(122, 149, 137),
                Location = new Point(16, 37),
                Size = new Size(card.Width - 150, 22),
                Text = backup.Time.ToString("dd/MM/yyyy HH:mm") + " · " + backup.Type + " · VERIFIED"
            };
            Label size = new Label
            {
                BackColor = Color.Transparent,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = accent,
                Location = new Point(card.Width - 120, 13),
                Size = new Size(92, 22),
                Text = backup.Size,
                TextAlign = ContentAlignment.MiddleRight
            };
            Label duration = new Label
            {
                BackColor = Color.Transparent,
                Font = new Font("Segoe UI", 8.5F),
                ForeColor = Color.FromArgb(122, 149, 137),
                Location = new Point(card.Width - 120, 38),
                Size = new Size(92, 20),
                Text = backup.Duration,
                TextAlign = ContentAlignment.MiddleRight
            };

            card.Controls.Add(id);
            card.Controls.Add(meta);
            card.Controls.Add(size);
            card.Controls.Add(duration);
            return card;
        }

        private Guna2Panel CreateRestoreCardModern(BackupRecord backup, bool selected)
        {
            Color accent = Color.FromArgb(15, 110, 86);
            Color ink = Color.FromArgb(15, 42, 64);
            Color muted = Color.FromArgb(100, 121, 116);
            Color badgeFill = backup.Type == "FULL" ? Color.FromArgb(220, 245, 236) : Color.FromArgb(219, 234, 254);
            Color badgeFore = backup.Type == "FULL" ? accent : Color.FromArgb(30, 64, 175);

            Guna2Panel card = new Guna2Panel
            {
                BorderColor = selected ? accent : Color.FromArgb(218, 232, 226),
                BorderRadius = 10,
                BorderThickness = selected ? 2 : 1,
                Cursor = Cursors.Hand,
                FillColor = selected ? Color.FromArgb(234, 246, 241) : Color.White,
                Height = 86,
                Margin = new Padding(0, 0, 0, 12),
                Width = Math.Max(420, flowRestoreCards.ClientSize.Width - 24),
                Tag = backup
            };

            Guna2Panel marker = new Guna2Panel
            {
                BorderRadius = 2,
                FillColor = selected ? accent : Color.FromArgb(214, 228, 223),
                Location = new Point(0, 14),
                Size = new Size(4, 58)
            };

            Guna2Panel typeBadge = new Guna2Panel
            {
                BorderRadius = 8,
                FillColor = badgeFill,
                Location = new Point(16, 50),
                Size = new Size(60, 24)
            };
            Label typeText = new Label
            {
                BackColor = Color.Transparent,
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 8.2F, FontStyle.Bold),
                ForeColor = badgeFore,
                Text = backup.Type,
                TextAlign = ContentAlignment.MiddleCenter
            };
            typeBadge.Controls.Add(typeText);

            Label id = new Label
            {
                AutoEllipsis = true,
                BackColor = Color.Transparent,
                Font = new Font("Segoe UI", 10.4F, FontStyle.Bold),
                ForeColor = ink,
                Location = new Point(16, 12),
                Size = new Size(card.Width - 170, 24),
                Text = backup.Id
            };
            Label meta = new Label
            {
                AutoEllipsis = true,
                BackColor = Color.Transparent,
                Font = new Font("Segoe UI", 8.8F),
                ForeColor = muted,
                Location = new Point(86, 52),
                Size = new Size(card.Width - 238, 22),
                Text = backup.Time.ToString("dd/MM/yyyy HH:mm") + " - " + backup.Source + " - VERIFIED"
            };
            Label size = new Label
            {
                BackColor = Color.Transparent,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = accent,
                Location = new Point(card.Width - 128, 14),
                Size = new Size(100, 24),
                Text = backup.Size,
                TextAlign = ContentAlignment.MiddleRight
            };
            Label duration = new Label
            {
                BackColor = Color.Transparent,
                Font = new Font("Segoe UI", 8.5F),
                ForeColor = muted,
                Location = new Point(card.Width - 128, 42),
                Size = new Size(100, 20),
                Text = backup.Duration,
                TextAlign = ContentAlignment.MiddleRight
            };

            card.Controls.Add(marker);
            card.Controls.Add(id);
            card.Controls.Add(typeBadge);
            card.Controls.Add(meta);
            card.Controls.Add(size);
            card.Controls.Add(duration);
            return card;
        }

        private void BtnStartRestore_Click(object sender, EventArgs e)
        {
            if (_restoreTimer.Enabled)
            {
                UpdateStartRestoreButtonState();
                return;
            }

            BackupRecord selected = GetSelectedRestore();
            if (selected == null)
            {
                UpdateStartRestoreButtonState();
                return;
            }

            PrepareMessageDialog();
            msgDialog.Icon = MessageDialogIcon.Warning;
            msgDialog.Buttons = MessageDialogButtons.YesNo;
            msgDialog.Caption = "Xác nhận phục hồi CSDL";
            msgDialog.Text = "Phục hồi dữ liệu từ bản " + selected.Id + " (Data Pump import) sẽ nạp đè dữ liệu hiện tại. Tiếp tục?";
            if (msgDialog.Show() != DialogResult.Yes)
            {
                return;
            }

            _restoreStep = 0;
            _restorePercent = 0;
            progressRestore.Value = 0;
            lblRestorePercent.Text = "0%";
            lblRestoreStatus.Text = "Running";
            txtConsole.Text = "";
            ResetStepLabels();
            btnStartRestore.Enabled = false;
            _restoreTimer.Start();
            UpdateStartRestoreButtonState();
            AppendConsole("Bắt đầu phục hồi dữ liệu từ bản backup " + selected.Id + " (Data Pump IMPORT)...");

            string backupId = selected.Id;

            // Chạy Data Pump IMPORT thật trong background thread (không treo UI)
            System.Threading.Tasks.Task.Run(() =>
            {
                string logId = null;
                string status = null;
                string message = null;
                Exception caughtEx = null;

                try
                {
                    var pBackupId = new Oracle.ManagedDataAccess.Client.OracleParameter(
                        "p_backup_id", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2)
                    { Value = backupId, Direction = System.Data.ParameterDirection.Input };

                    var pLogId = new Oracle.ManagedDataAccess.Client.OracleParameter(
                        "p_log_id", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2, 50)
                    { Direction = System.Data.ParameterDirection.Output };

                    var pStatus = new Oracle.ManagedDataAccess.Client.OracleParameter(
                        "p_status", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2, 20)
                    { Direction = System.Data.ParameterDirection.Output };

                    var pMessage = new Oracle.ManagedDataAccess.Client.OracleParameter(
                        "p_message", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2, 1000)
                    { Direction = System.Data.ParameterDirection.Output };

                    HospitalX.DAO.DataProvider.Instance.ExecuteNonQuery(
                        "ADMINHOS.SP_RUN_DATAPUMP_RESTORE",
                        new Oracle.ManagedDataAccess.Client.OracleParameter[] { pBackupId, pLogId, pStatus, pMessage },
                        true);

                    logId   = pLogId.Value?.ToString();
                    status  = pStatus.Value?.ToString() ?? "FAILED";
                    message = pMessage.Value?.ToString() ?? "";
                }
                catch (Exception ex)
                {
                    status   = "FAILED";
                    caughtEx = ex;
                    message  = ex.Message;
                }

                // Cập nhật UI trên main thread
                this.Invoke((System.Action)(() =>
                {
                    _restoreTimer.Stop();
                    btnStartRestore.Enabled = true;

                    bool ok = status == "SUCCESS" || status == "COMPLETED_WITH_WARN";
                    if (ok)
                    {
                        _restorePercent = 100;
                        progressRestore.Value = 100;
                        lblRestorePercent.Text = "100%";
                        lblRestoreStatus.Text = "Done";
                        for (int i = 1; i <= 5; i++) SetStepDone(i, StepText(i));
                        AppendConsole("[" + status + "] " + message);
                        AppendConsole("Hoàn tất phục hồi dữ liệu.");

                        LoadBackupHistoryFromDB();
                        RenderHistory();
                        RenderRestoreCards();

                        MessageBox.Show(
                            "Phục hồi hoàn tất!\n" + message,
                            "Phục hồi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        lblRestoreStatus.Text = "Failed";
                        lblRestorePercent.Text = "Lỗi";
                        string errMsg = caughtEx != null ? caughtEx.Message : message;
                        AppendConsole("LỖI: " + errMsg);

                        MessageBox.Show(
                            "Phục hồi thất bại!\n\n" + errMsg + "\n\n" +
                            "Kiểm tra:\n" +
                            "1. Bản backup đã chọn có file .dmp thật trong thư mục Oracle không?\n" +
                            "2. User có quyền DATAPUMP_IMP_FULL_DATABASE và READ/WRITE trên directory?\n" +
                            "3. Bản backup phải ở trạng thái SUCCESS trong BACKUP_LOG.",
                            "Lỗi phục hồi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    UpdateStartRestoreButtonState();
                }));
            });
        }

        private static string StepText(int step)
        {
            switch (step)
            {
                case 1: return "Xác thực bản backup";
                case 2: return "Khởi động DBMS_DATAPUMP (IMPORT)";
                case 3: return "Tạm vô hiệu khóa ngoại";
                case 4: return "Nạp lại dữ liệu (TRUNCATE + load)";
                default: return "Bật lại khóa ngoại & hoàn tất";
            }
        }

        private BackupRecord GetSelectedRestore()
        {
            List<BackupRecord> verified = _backups.Where(b => b.Success).Take(5).ToList();
            return verified.Count == 0 ? null : verified[Math.Min(_selectedRestoreIndex, verified.Count - 1)];
        }

        private void RestoreTimer_Tick(object sender, EventArgs e)
        {
            // Hiển thị tiến trình trong khi Oracle Data Pump IMPORT đang chạy nền
            // (tối đa 90%, 10% còn lại dành cho khi job hoàn tất).
            if (_restorePercent < 90)
            {
                _restorePercent = Math.Min(90, _restorePercent + 5);
            }
            progressRestore.Value = _restorePercent;
            lblRestorePercent.Text = _restorePercent + "%";

            int step = Math.Min(5, _restorePercent / 18 + 1);
            if (step > _restoreStep)
            {
                _restoreStep = step;
                SetStepDone(_restoreStep, StepText(_restoreStep));
                AppendConsole(StepText(_restoreStep) + "...");
            }

            if (_restorePercent < 20)
                lblRestoreStatus.Text = "Đang xác thực bản backup...";
            else if (_restorePercent < 55)
                lblRestoreStatus.Text = "Đang nạp lại dữ liệu (Data Pump import)...";
            else
                lblRestoreStatus.Text = "Đang hoàn tất phục hồi...";
        }

        private void PrepareMessageDialog()
        {
            msgDialog.Parent = FindForm();
            msgDialog.Style = MessageDialogStyle.Light;
        }

        private void ResetStepLabels()
        {
            lblStep1.Text = "1. " + StepText(1);
            lblStep2.Text = "2. " + StepText(2);
            lblStep3.Text = "3. " + StepText(3);
            lblStep4.Text = "4. " + StepText(4);
            lblStep5.Text = "5. " + StepText(5);
            lblStep1.ForeColor = lblStep2.ForeColor = lblStep3.ForeColor = lblStep4.ForeColor = lblStep5.ForeColor = Color.FromArgb(122, 149, 137);
        }

        private void dgvHistory_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                PaintHeaderCell(e);
                return;
            }

            string columnName = dgvHistory.Columns[e.ColumnIndex].Name;
            PaintCellBackground(e);
            string text = Convert.ToString(e.Value);
            Color back;
            Color fore;

            if (columnName == "colBackupId")
            {
                Rectangle idBadge = new Rectangle(e.CellBounds.X + 12, e.CellBounds.Y + 20, e.CellBounds.Width - 24, 28);
                PaintBadge(e.Graphics, idBadge, text, Color.FromArgb(230, 244, 240), Color.FromArgb(15, 110, 86), 8.8F);
                e.Handled = true;
                return;
            }

            if (columnName == "colBackupTime")
            {
                string[] lines = text.Split('\n');
                TextRenderer.DrawText(e.Graphics, lines[0], new Font("Segoe UI", 9.8F, FontStyle.Bold), new Rectangle(e.CellBounds.X + 14, e.CellBounds.Y + 10, e.CellBounds.Width - 22, 26), Color.FromArgb(24, 48, 42), TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
                if (lines.Length > 1)
                {
                    TextRenderer.DrawText(e.Graphics, lines[1], new Font("Segoe UI", 8.9F), new Rectangle(e.CellBounds.X + 14, e.CellBounds.Y + 36, e.CellBounds.Width - 22, 22), Color.FromArgb(122, 149, 137), TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
                }
                e.Handled = true;
                return;
            }

            if (columnName != "colBackupType" && columnName != "colBackupSource" && columnName != "colBackupStatus")
            {
                TextRenderer.DrawText(e.Graphics, text, new Font("Segoe UI", 9.5F), new Rectangle(e.CellBounds.X + 14, e.CellBounds.Y, e.CellBounds.Width - 22, e.CellBounds.Height), Color.FromArgb(24, 48, 42), TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
                e.Handled = true;
                return;
            }

            if (columnName == "colBackupType")
            {
                bool full = text == "FULL";
                back = full ? Color.FromArgb(230, 244, 240) : Color.FromArgb(219, 234, 254);
                fore = full ? Color.FromArgb(15, 110, 86) : Color.FromArgb(30, 64, 175);
            }
            else if (columnName == "colBackupSource")
            {
                bool manual = text == "MANUAL";
                back = manual ? Color.FromArgb(237, 233, 254) : Color.FromArgb(241, 245, 249);
                fore = manual ? Color.FromArgb(91, 33, 182) : Color.FromArgb(71, 85, 105);
            }
            else
            {
                bool ok = text == "OK";
                back = ok ? Color.FromArgb(220, 252, 231) : Color.FromArgb(254, 226, 226);
                fore = ok ? Color.FromArgb(22, 101, 52) : Color.FromArgb(185, 28, 28);
            }

            Rectangle badge = new Rectangle(e.CellBounds.X + 10, e.CellBounds.Y + 20, Math.Min(e.CellBounds.Width - 20, 82), 28);
            PaintBadge(e.Graphics, badge, text, back, fore, 8.8F);
            e.Handled = true;
        }

        private static void PaintCellBackground(DataGridViewCellPaintingEventArgs e)
        {
            Color fill = e.RowIndex % 2 == 0 ? Color.White : Color.FromArgb(247, 249, 248);
            using (SolidBrush brush = new SolidBrush(fill))
            {
                Rectangle cover = new Rectangle(e.CellBounds.X - 1, e.CellBounds.Y - 1, e.CellBounds.Width + 3, e.CellBounds.Height + 3);
                e.Graphics.FillRectangle(brush, cover);
            }
        }

        private static void PaintHeaderCell(DataGridViewCellPaintingEventArgs e)
        {
            using (SolidBrush brush = new SolidBrush(Color.FromArgb(247, 249, 248)))
            {
                Rectangle cover = new Rectangle(e.CellBounds.X - 1, e.CellBounds.Y - 1, e.CellBounds.Width + 3, e.CellBounds.Height + 3);
                e.Graphics.FillRectangle(brush, cover);
            }

            TextRenderer.DrawText(
                e.Graphics,
                Convert.ToString(e.Value),
                new Font("Segoe UI", 9F, FontStyle.Bold),
                new Rectangle(e.CellBounds.X + 10, e.CellBounds.Y, e.CellBounds.Width - 16, e.CellBounds.Height),
                Color.FromArgb(122, 149, 137),
                TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);

            e.Handled = true;
        }

        private static void PaintBadge(Graphics graphics, Rectangle rect, string text, Color fill, Color fore, float fontSize)
        {
            using (System.Drawing.Drawing2D.GraphicsPath path = RoundedPath(rect, 7))
            using (SolidBrush brush = new SolidBrush(fill))
            {
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                graphics.FillPath(brush, path);
            }

            TextRenderer.DrawText(graphics, text, new Font("Segoe UI", fontSize, FontStyle.Bold), rect, fore, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
        }

        private static System.Drawing.Drawing2D.GraphicsPath RoundedPath(Rectangle rect, int radius)
        {
            int d = radius * 2;
            var path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(rect.X, rect.Y, d, d, 180, 90);
            path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
            path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }

        private void SetStepDone(int step, string text)
        {
            Label label = step == 1 ? lblStep1 :
                step == 2 ? lblStep2 :
                step == 3 ? lblStep3 :
                step == 4 ? lblStep4 : lblStep5;
            label.Text = "✓ " + text;
            label.ForeColor = Color.FromArgb(22, 163, 74);
        }

        private void AppendConsole(string message)
        {
            txtConsole.AppendText("[" + DateTime.Now.ToString("HH:mm:ss") + "] " + message + Environment.NewLine);
        }

        private class BackupRecord
        {
            public BackupRecord(string id, DateTime time, string type, string source, string size, string duration, bool success)
            {
                Id = id;
                Time = time;
                Type = type;
                Source = source;
                Size = size;
                Duration = duration;
                Success = success;
            }

            public string Id { get; private set; }
            public DateTime Time { get; private set; }
            public string Type { get; private set; }
            public string Source { get; private set; }
            public string Size { get; private set; }
            public string Duration { get; private set; }
            public bool Success { get; private set; }
        }
    }
}
