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
        private int _selectedRestoreIndex;

        public ucSaoLuuPhucHoi()
        {
            InitializeComponent();
            SeedData();
            WireEvents();
            RenderHistory();
            RenderRestoreCards();
            ShowBackupTab();
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

            _backupTimer = new Timer { Interval = 180 };
            _backupTimer.Tick += BackupTimer_Tick;
            _restoreTimer = new Timer { Interval = 900 };
            _restoreTimer.Tick += RestoreTimer_Tick;
        }

        private void SeedData()
        {
            _backups.Add(new BackupRecord("BK-20260524-F", new DateTime(2026, 5, 24, 0, 1, 0), "FULL", "AUTO", "8.4 GB", "48m 10s", true));
            _backups.Add(new BackupRecord("BK-20260523-I18", new DateTime(2026, 5, 23, 18, 0, 0), "INCR", "AUTO", "2.1 GB", "13m 40s", true));
            _backups.Add(new BackupRecord("BK-20260523-I12", new DateTime(2026, 5, 23, 12, 0, 0), "INCR", "AUTO", "1.7 GB", "10m 58s", true));
            _backups.Add(new BackupRecord("BK-20260523-F", new DateTime(2026, 5, 23, 0, 1, 0), "FULL", "AUTO", "8.3 GB", "47m 05s", true));
            _backups.Add(new BackupRecord("BK-20260522-M01", new DateTime(2026, 5, 22, 9, 30, 0), "FULL", "MANUAL", "8.2 GB", "46m 12s", true));
            _backups.Add(new BackupRecord("BK-20260521-I18", new DateTime(2026, 5, 21, 18, 0, 0), "INCR", "AUTO", "-", "-", false));
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
            msgDialog.Icon = MessageDialogIcon.Information;
            msgDialog.Buttons = MessageDialogButtons.OK;
            msgDialog.Caption = "Dry Run";
            msgDialog.Text = "Kiểm tra cấu hình RMAN hợp lệ. Có thể bắt đầu sao lưu.";
            msgDialog.Show();
        }

        private void BtnStartBackup_Click(object sender, EventArgs e)
        {
            _backupPercent = 0;
            progressBackup.Value = 0;
            lblBackupPercent.Text = "0%";
            lblBackupStatus.Text = "Đang chuẩn bị RMAN channel...";
            pnlBackupProgress.Visible = true;
            btnStartBackup.Enabled = false;
            _backupTimer.Start();
        }

        private void BackupTimer_Tick(object sender, EventArgs e)
        {
            _backupPercent = Math.Min(100, _backupPercent + 7);
            progressBackup.Value = _backupPercent;
            lblBackupPercent.Text = _backupPercent + "%";

            if (_backupPercent < 30)
            {
                lblBackupStatus.Text = "Đang sao lưu SYSTEM và DATA tablespace...";
            }
            else if (_backupPercent < 65)
            {
                lblBackupStatus.Text = "Đang sao lưu dữ liệu nghiệp vụ phân hệ 2...";
            }
            else if (_backupPercent < 95)
            {
                lblBackupStatus.Text = "Đang sao lưu archive log và kiểm tra catalog...";
            }
            else
            {
                lblBackupStatus.Text = "Hoàn tất sao lưu.";
            }

            if (_backupPercent < 100)
            {
                return;
            }

            _backupTimer.Stop();
            btnStartBackup.Enabled = true;
            string type = chkIncremental.Checked ? "INCR" : "FULL";
            BackupRecord record = new BackupRecord(
                "BK-NOW-" + DateTime.Now.ToString("HHmmss"),
                DateTime.Now,
                type,
                "MANUAL",
                type == "FULL" ? "8.4 GB" : "1.8 GB",
                type == "FULL" ? "48m" : "12m",
                true);
            _backups.Insert(0, record);
            RenderHistory();
            RenderRestoreCards();
        }

        private void RenderHistory()
        {
            dgvHistory.Rows.Clear();
            foreach (BackupRecord backup in _backups)
            {
                dgvHistory.Rows.Add(
                    backup.Id,
                    backup.Time.ToString("dd/MM/yyyy HH:mm"),
                    backup.Type,
                    backup.Source,
                    backup.Size,
                    backup.Duration,
                    backup.Success ? "OK" : "Fail");
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
                Guna2Panel card = CreateRestoreCard(backup, i == _selectedRestoreIndex);
                card.Click += (s, e) =>
                {
                    _selectedRestoreIndex = index;
                    RenderRestoreCards();
                };
                foreach (Control child in card.Controls)
                {
                    child.Click += (s, e) =>
                    {
                        _selectedRestoreIndex = index;
                        RenderRestoreCards();
                    };
                }
                flowRestoreCards.Controls.Add(card);
            }

            flowRestoreCards.ResumeLayout();
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
                Height = 78,
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
                Location = new Point(16, 13),
                Size = new Size(card.Width - 150, 22),
                Text = backup.Id
            };
            Label meta = new Label
            {
                AutoEllipsis = true,
                BackColor = Color.Transparent,
                Font = new Font("Segoe UI", 8.8F, FontStyle.Bold),
                ForeColor = Color.FromArgb(122, 149, 137),
                Location = new Point(16, 39),
                Size = new Size(card.Width - 150, 22),
                Text = backup.Time.ToString("dd/MM/yyyy HH:mm") + " · " + backup.Type + " · VERIFIED"
            };
            Label size = new Label
            {
                BackColor = Color.Transparent,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = accent,
                Location = new Point(card.Width - 120, 15),
                Size = new Size(92, 22),
                Text = backup.Size,
                TextAlign = ContentAlignment.MiddleRight
            };
            Label duration = new Label
            {
                BackColor = Color.Transparent,
                Font = new Font("Segoe UI", 8.5F),
                ForeColor = Color.FromArgb(122, 149, 137),
                Location = new Point(card.Width - 120, 41),
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

        private void BtnStartRestore_Click(object sender, EventArgs e)
        {
            BackupRecord selected = GetSelectedRestore();
            if (selected == null)
            {
                return;
            }

            msgDialog.Icon = MessageDialogIcon.Warning;
            msgDialog.Buttons = MessageDialogButtons.YesNo;
            msgDialog.Caption = "Xác nhận phục hồi CSDL";
            msgDialog.Text = "Phục hồi về bản " + selected.Id + " sẽ dừng kết nối và không thể hoàn tác. Tiếp tục?";
            if (msgDialog.Show() != DialogResult.Yes)
            {
                return;
            }

            _restoreStep = 0;
            progressRestore.Value = 0;
            lblRestorePercent.Text = "0%";
            lblRestoreStatus.Text = "Running";
            txtConsole.Text = "";
            ResetStepLabels();
            _restoreTimer.Start();
            AppendConsole("RMAN restore initiated - target " + selected.Id);
        }

        private BackupRecord GetSelectedRestore()
        {
            List<BackupRecord> verified = _backups.Where(b => b.Success).Take(5).ToList();
            return verified.Count == 0 ? null : verified[Math.Min(_selectedRestoreIndex, verified.Count - 1)];
        }

        private void RestoreTimer_Tick(object sender, EventArgs e)
        {
            string[] steps =
            {
                "Xác thực bản backup",
                "Tắt DB / MOUNT mode",
                "Restore datafiles",
                "Recover archive log",
                "OPEN RESETLOGS"
            };

            if (_restoreStep >= steps.Length)
            {
                _restoreTimer.Stop();
                lblRestoreStatus.Text = "Done";
                AppendConsole("Hoàn tất phục hồi CSDL.");
                return;
            }

            int percent = (_restoreStep + 1) * 20;
            progressRestore.Value = percent;
            lblRestorePercent.Text = percent + "%";
            SetStepDone(_restoreStep + 1, steps[_restoreStep]);
            AppendConsole("Hoàn thành: " + steps[_restoreStep]);
            _restoreStep++;
        }

        private void ResetStepLabels()
        {
            lblStep1.Text = "1. Xác thực bản backup";
            lblStep2.Text = "2. Tắt DB / MOUNT mode";
            lblStep3.Text = "3. Restore datafiles";
            lblStep4.Text = "4. Recover archive log";
            lblStep5.Text = "5. OPEN RESETLOGS";
            lblStep1.ForeColor = lblStep2.ForeColor = lblStep3.ForeColor = lblStep4.ForeColor = lblStep5.ForeColor = Color.FromArgb(122, 149, 137);
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
