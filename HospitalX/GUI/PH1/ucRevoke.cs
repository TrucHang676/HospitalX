using HospitalX.DAO;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace HospitalX.GUI.PH1
{
    public partial class ucRevoke : UserControl
    {
        // ================================================
        // BIẾN TOÀN CỤC
        // _connectionString : chuỗi kết nối Oracle, nhận từ form cha
        // _currentGrantee   : tên user/role đang được chọn ở ListBox
        // _allGrantees      : danh sách gốc để filter tìm kiếm
        // ================================================
        private string _connectionString;
        private string _currentGrantee = "";
        private List<GranteeItem> _allGrantees = new List<GranteeItem>();
        private Guna.UI2.WinForms.Guna2TextBox txtSearchDGV;

        // ================================================
        // CONSTRUCTOR — khởi tạo component và wire toàn bộ sự kiện
        // ================================================
        public ucRevoke(string connStr)
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            _connectionString = connStr;

            // Thiết lập ListBox vẽ tay (OwnerDraw) để hiển thị avatar + tên đẹp hơn
            lstGrantees.DrawMode = DrawMode.OwnerDrawFixed;
            lstGrantees.ItemHeight = 50;
            lstGrantees.DrawItem += LstGrantees_DrawItem;

            // Gắn các sự kiện cho control
            this.Load += ucRevoke_Load;
            lstGrantees.SelectedIndexChanged += LstGrantees_SelectedIndexChanged;
            btnGranteeUser.Click += (s, e) => SwitchGranteeTab("USER");
            btnGranteeRole.Click += (s, e) => SwitchGranteeTab("ROLE");
            btnExeRevoke.Click += BtnRevoke_Click;
            btnAll.Click += (s, e) => SetAllChecked(true);
            btnClearAllCols.Click += (s, e) => SetAllChecked(false);
            txtSearchGrantee.TextChanged += TxtSearch_TextChanged;

            // Tạo ô tìm kiếm quyền trên DGV
            txtSearchDGV = new Guna.UI2.WinForms.Guna2TextBox();
            txtSearchDGV.Name = "txtSearchDGV";
            txtSearchDGV.PlaceholderText = "Tìm kiếm quyền, đối tượng...";
            txtSearchDGV.Size = new Size(250, 36);
            txtSearchDGV.Location = new Point(pnlGrant.Width - txtSearchDGV.Width - 10, 10);
            txtSearchDGV.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtSearchDGV.BorderRadius = 8;
            txtSearchDGV.FillColor = Color.FromArgb(247, 250, 252);
            txtSearchDGV.BorderColor = Color.FromArgb(208, 228, 240);
            txtSearchDGV.Font = new Font("Segoe UI", 9F);
            txtSearchDGV.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtSearchDGV.FocusedState.BorderColor = Color.FromArgb(228, 45, 45); // Tông đỏ của Revoke

            pnlGrant.Controls.Add(txtSearchDGV);
            txtSearchDGV.BringToFront();

            txtSearchDGV.TextChanged += TxtSearchDGV_TextChanged;

            StyleDataGridView();

            // Cho phép dgvCurrentPrivs tự động co giãn theo Panel ngoài
            dgvCurrentPrivs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            // QUAN TRỌNG: Phải wire 2 event này để checkbox DGV hoạt động đúng
            // Nếu thiếu → tick checkbox xong nút Revoke không enable lên được
            dgvCurrentPrivs.CellValueChanged
                += DgvCurrentPrivs_CellValueChanged;
            dgvCurrentPrivs.CurrentCellDirtyStateChanged
                += DgvCurrentPrivs_CurrentCellDirtyStateChanged;

            // FIX CHÍNH: Tắt DefaultAutoSize của btnExeRevoke
            // Nguyên nhân nút "mất tiêu": DefaultAutoSize = true trong Designer
            // → khi text thay đổi thành chuỗi dài, nút tự giãn vượt quá FlowLayoutPanel
            // → bị đẩy xuống dòng ngoài vùng nhìn thấy
            btnExeRevoke.DefaultAutoSize = false;
            btnExeRevoke.Size = new Size(280, 33);

            // Tắt AutoSize cho 2 nút còn lại để layout ổn định
            btnAll.DefaultAutoSize = false;
            btnAll.Size = new Size(130, 33);
            btnClearAllCols.DefaultAutoSize = false;
            btnClearAllCols.Size = new Size(155, 33);
        }

        // ================================================
        // STYLE DATAGRIDVIEW — định dạng màu sắc, font, kích thước cột
        // ================================================
        private void StyleDataGridView()
        {
            var dgv = dgvCurrentPrivs;
            dgv.EnableHeadersVisualStyles = false;

            // Header màu đỏ — đồng bộ theme Thu hồi quyền
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(228, 45, 45);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12f, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(228, 45, 45);
            dgv.ColumnHeadersHeight = 38;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            // Kiểu dáng dòng dữ liệu
            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = Color.FromArgb(10, 42, 64);
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10f);
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 235, 235);
            dgv.DefaultCellStyle.SelectionForeColor = Color.FromArgb(228, 45, 45);
            dgv.RowTemplate.Height = 40;
            dgv.GridColor = Color.FromArgb(248, 240, 240);
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(255, 249, 249);

            // Cài đặt chung cho DGV
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.ReadOnly = false;
            dgv.MultiSelect = true;
            // CellSelect thay vì FullRowSelect để checkbox hoạt động mượt hơn
            dgv.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgv.RowHeadersVisible = false;
            dgv.BackgroundColor = Color.White;

            // Cột checkbox để chọn quyền cần thu hồi
            colSelect.ReadOnly = false;
            colSelect.Width = 44;
            colSelect.HeaderText = "✓";
            colSelect.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Các cột thông tin chỉ đọc
            colObject.ReadOnly = true;
            colObjType.ReadOnly = true;
            colPrivilege.ReadOnly = true;
            colColumns.ReadOnly = true;
            colGrantOption.ReadOnly = true;

            // Độ rộng từng cột
            colObject.Width = 180;
            colObjType.Width = 90;
            colPrivilege.Width = 90;
            colColumns.Width = 180;
            colGrantOption.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        // ================================================
        // SỰ KIỆN LOAD — chạy khi UserControl được hiển thị lần đầu
        // ================================================
        private void ucRevoke_Load(object sender, EventArgs e)
        {
            // Mặc định hiển thị tab User khi mở trang
            SwitchGranteeTab("USER");
        }

        // ================================================
        // CHUYỂN TAB USER / ROLE — cập nhật nút active và load danh sách
        // ================================================
        private void SwitchGranteeTab(string mode)
        {
            // Cập nhật trạng thái checked của 2 nút radio
            btnGranteeUser.Checked = (mode == "USER");
            btnGranteeRole.Checked = (mode == "ROLE");

            // Reset cache tìm kiếm khi đổi tab
            _allGrantees.Clear();

            LoadGrantees(mode);
        }

        // ================================================
        // LOAD DANH SÁCH USER / ROLE — từ database
        // ================================================
        private void LoadGrantees(string mode)
        {
            lstGrantees.Items.Clear();
            dgvCurrentPrivs.Rows.Clear();
            _currentGrantee = "";
            UpdateActionBar();

            try
            {
                if (mode == "USER")
                {
                    var param = new OracleParameter[] {
                        new OracleParameter("p_cursor", OracleDbType.RefCursor) { Direction = ParameterDirection.Output }
                    };

                    DataTable dt = DataProvider.Instance.ExecuteQuery("USP_LIST_USERS", param);
                    Color[] colors = { Color.FromArgb(0, 120, 180), Color.BlueViolet, Color.Orange, Color.SlateGray };

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        int colorIdx = 0;
                        foreach (DataRow row in dt.Rows)
                        {
                            string username = row["USERNAME"]?.ToString() ?? "";
                            string status = row["ACCOUNT_STATUS"]?.ToString() ?? "";

                            if (status != "OPEN") continue;

                            // Lấy role của user
                            string userRole = GetUserRoleFromDb(username) ?? "USER";
                            Color color = colors[colorIdx % colors.Length];

                            lstGrantees.Items.Add(new GranteeItem(username, userRole, color));
                            colorIdx++;
                        }
                    }
                }
                else // ROLE
                {
                    var param = new OracleParameter[] {
                        new OracleParameter("p_cursor", OracleDbType.RefCursor) { Direction = ParameterDirection.Output }
                    };

                    DataTable dt = DataProvider.Instance.ExecuteQuery("USP_LIST_ROLES", param);
                    Color[] colors = { Color.FromArgb(0, 120, 180), Color.BlueViolet, Color.Orange, Color.SlateGray };

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        int colorIdx = 0;
                        foreach (DataRow row in dt.Rows)
                        {
                            string roleName = row["ROLE"]?.ToString() ?? "";

                            // Đếm số user có role này
                            int userCount = GetRoleMemberCount(roleName);
                            string memberInfo = userCount == 1 ? "1 user" : $"{userCount} users";

                            Color color = colors[colorIdx % colors.Length];
                            lstGrantees.Items.Add(new GranteeItem(roleName, memberInfo, color));
                            colorIdx++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================================================
        // LẤY ROLE CỦA USER
        // ================================================
        private string GetUserRoleFromDb(string username)
        {
            try
            {
                var param = new OracleParameter[] {
                    new OracleParameter("p_grantee", OracleDbType.Varchar2) { Value = username },
                    new OracleParameter("p_role", OracleDbType.Varchar2, System.Data.ParameterDirection.Output)
                };

                DataProvider.Instance.ExecuteQuery("USP_GET_USER_ROLE", param);
                return param[1].Value?.ToString() ?? "";
            }
            catch
            {
                return "USER";
            }
        }

        // ================================================
        // ĐẾM SỐ USER TRONG ROLE
        // ================================================
        private int GetRoleMemberCount(string roleName)
        {
            try
            {
                var param = new OracleParameter[] {
                    new OracleParameter("p_role_name", OracleDbType.Varchar2) { Value = roleName },
                    new OracleParameter("p_cursor", OracleDbType.RefCursor) { Direction = ParameterDirection.Output }
                };

                DataTable dt = DataProvider.Instance.ExecuteQuery("USP_LIST_ROLE_MEMBERS", param);
                return dt?.Rows.Count ?? 0;
            }
            catch
            {
                return 0;
            }
        }

        // ================================================
        // KHI CHỌN USER/ROLE — load quyền tương ứng lên DGV
        // ================================================
        private void LstGrantees_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstGrantees.SelectedItem is GranteeItem item)
            {
                _currentGrantee = item.Name;
                if (txtSearchDGV != null) txtSearchDGV.Text = ""; // Reset ô tìm kiếm DGV
                LoadPrivilegesFromDb(item.Name);
                UpdateActionBar();
            }
        }

        // ================================================
        // LOAD PRIVILEGES TỪ DATABASE — USP_GET_OBJ_PRIVS
        // Lấy quyền object + column level của user/role
        // ================================================
        private void LoadPrivilegesFromDb(string grantee)
        {
            dgvCurrentPrivs.Rows.Clear();

            try
            {
                var param = new OracleParameter[] {
                    new OracleParameter("p_grantee", OracleDbType.Varchar2) { Value = grantee },
                    new OracleParameter("p_result", OracleDbType.RefCursor) { Direction = ParameterDirection.Output }
                };

                DataTable dt = DataProvider.Instance.ExecuteQuery("USP_GET_OBJ_PRIVS", param);

                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        int idx = dgvCurrentPrivs.Rows.Add();
                        var dgvRow = dgvCurrentPrivs.Rows[idx];

                        string objName = row["OBJECT_NAME"]?.ToString() ?? "";
                        string objType = row["TYPE"]?.ToString() ?? "";
                        string privilege = row["PRIVILEGE"]?.ToString() ?? "";
                        string columns = row["COLUMN_NAME"]?.ToString() ?? "ALL COLUMN";
                        string grantOpt = row["GRANT_OPTION"]?.ToString() ?? "NO";

                        // Convert column name display
                        if (columns == "ALL COLUMN") columns = "Tất cả cột";

                        dgvRow.Cells[colSelect.Name].Value = false;
                        dgvRow.Cells[colObject.Name].Value = objName;
                        dgvRow.Cells[colObjType.Name].Value = objType;
                        dgvRow.Cells[colPrivilege.Name].Value = privilege;
                        dgvRow.Cells[colColumns.Name].Value = columns;
                        dgvRow.Cells[colGrantOption.Name].Value = grantOpt;

                        // Tô màu cột Quyền theo loại
                        Color privColor;
                        switch (privilege)
                        {
                            case "SELECT": privColor = Color.FromArgb(13, 148, 136); break;
                            case "UPDATE": privColor = Color.FromArgb(217, 119, 6); break;
                            case "INSERT": privColor = Color.FromArgb(22, 163, 74); break;
                            case "DELETE": privColor = Color.FromArgb(220, 38, 38); break;
                            case "EXECUTE": privColor = Color.FromArgb(124, 58, 237); break;
                            default: privColor = Color.FromArgb(10, 42, 64); break;
                        }
                        dgvRow.Cells[colPrivilege.Name].Style.ForeColor = privColor;
                        dgvRow.Cells[colPrivilege.Name].Style.Font = new Font("Segoe UI", 10f, FontStyle.Bold);

                        // Tô màu cột Loại đối tượng
                        Color typeColor;
                        switch (objType)
                        {
                            case "VIEW": typeColor = Color.FromArgb(124, 58, 237); break;
                            case "PROCEDURE": typeColor = Color.FromArgb(22, 163, 74); break;
                            case "FUNCTION": typeColor = Color.FromArgb(249, 115, 22); break;
                            default: typeColor = Color.FromArgb(0, 120, 180); break;
                        }
                        dgvRow.Cells[colObjType.Name].Style.ForeColor = typeColor;
                        dgvRow.Cells[colObjType.Name].Style.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);

                        // Tô màu cột Grant Option
                        dgvRow.Cells[colGrantOption.Name].Style.ForeColor = grantOpt == "YES"
                            ? Color.FromArgb(22, 163, 74)
                            : Color.FromArgb(156, 163, 175);
                        dgvRow.Cells[colGrantOption.Name].Style.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
                    }

                    // Cập nhật tiêu đề với số lượng quyền
                    int totalPrivs = dt.Rows.Count;
                    lblTitle2.Text = $"Quyền đang có của <b>{grantee}</b> — {totalPrivs} quyền";
                }
                else
                {
                    // Không có quyền nào
                    lblTitle2.Text = $"Quyền đang có của <b>{grantee}</b> — 0 quyền";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải quyền: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================================================
        // CẬP NHẬT ACTION BAR — đổi text nút và tiêu đề DGV
        // theo số quyền đang được tick chọn
        // ================================================
        private void UpdateActionBar()
        {
            int checkedCount = CountChecked();

            if (string.IsNullOrEmpty(_currentGrantee))
            {
                btnExeRevoke.Text = "← Chọn user/role trước";
                btnExeRevoke.Enabled = false;
            }
            else
            {
                int total = dgvCurrentPrivs.Rows.Count;
                btnExeRevoke.Text = checkedCount > 0
                    ? $"Thu hồi {checkedCount} quyền"
                    : $"Thực hiện REVOKE →";
                btnExeRevoke.Enabled = checkedCount > 0;

                lblTitle2.Text =
                    $"Quyền đang có của <b>{_currentGrantee}</b> — {total} quyền";
            }
        }

        // ================================================
        // ĐẾM SỐ QUYỀN ĐANG ĐƯỢC TICK — dùng để cập nhật nút
        // ================================================
        private int CountChecked()
        {
            int count = 0;
            foreach (DataGridViewRow row in dgvCurrentPrivs.Rows)
                if (row.Cells[colSelect.Name].Value as bool? == true)
                    count++;
            return count;
        }

        // ================================================
        // SỰ KIỆN CHECKBOX DGV THAY ĐỔI — cập nhật action bar ngay lập tức
        // Phải có CurrentCellDirtyStateChanged để CommitEdit kịp thời,
        // nếu không CellValueChanged sẽ fire trễ hoặc không fire
        // ================================================
        private void DgvCurrentPrivs_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Chỉ xử lý khi cột checkbox thay đổi
            if (e.ColumnIndex == colSelect.Index)
                UpdateActionBar();
        }

        private void DgvCurrentPrivs_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            // Commit thay đổi ngay để CellValueChanged fire đúng thời điểm
            if (dgvCurrentPrivs.IsCurrentCellDirty)
                dgvCurrentPrivs.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        // ================================================
        // CHỌN / BỎ CHỌN TẤT CẢ — dùng cho btnAll và btnClearAllCols
        // ================================================
        private void SetAllChecked(bool value)
        {
            foreach (DataGridViewRow row in dgvCurrentPrivs.Rows)
            {
                if (row.Visible)
                {
                    row.Cells[colSelect.Name].Value = value;
                }
            }
            UpdateActionBar();
        }

        // ================================================
        // TÌM KIẾM REALTIME — lọc ListBox theo từ khóa nhập vào
        // ================================================
        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            string kw = txtSearchGrantee.Text.Trim().ToLower();

            // Lần đầu gõ → lưu toàn bộ danh sách vào cache
            if (_allGrantees.Count == 0)
            {
                foreach (var o in lstGrantees.Items)
                    if (o is GranteeItem g) _allGrantees.Add(g);
            }

            // Lưu item đang selected để restore sau
            var selected = lstGrantees.SelectedItem as GranteeItem;

            // Filter danh sách theo từ khóa
            lstGrantees.Items.Clear();
            foreach (var g in _allGrantees)
            {
                bool match = string.IsNullOrEmpty(kw)
                    || g.Name.ToLower().Contains(kw)
                    || g.RoleName.ToLower().Contains(kw);
                if (match) lstGrantees.Items.Add(g);
            }

            // Khôi phục selection nếu item vẫn còn trong list
            if (selected != null)
                for (int i = 0; i < lstGrantees.Items.Count; i++)
                    if ((lstGrantees.Items[i] as GranteeItem)?.Name == selected.Name)
                    { lstGrantees.SelectedIndex = i; break; }
        }

        // ================================================
        // TÌM KIẾM DGV REALTIME
        // ================================================
        private void TxtSearchDGV_TextChanged(object sender, EventArgs e)
        {
            string kw = txtSearchDGV.Text.Trim().ToLower();
            dgvCurrentPrivs.CurrentCell = null; // Tránh lỗi CurrencyManager khi ẩn dòng đang được select
            foreach (DataGridViewRow row in dgvCurrentPrivs.Rows)
            {
                bool match = false;
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.ColumnIndex > 0 && cell.Value != null)
                    {
                        if (cell.Value.ToString().ToLower().Contains(kw))
                        {
                            match = true;
                            break;
                        }
                    }
                }
                row.Visible = string.IsNullOrEmpty(kw) || match;
            }
        }

        // ================================================
        // THỰC HIỆN REVOKE — gom quyền đã tick, xác nhận, và xử lý
        // ================================================
        private void BtnRevoke_Click(object sender, EventArgs e)
        {
            // Lấy danh sách dòng được chọn
            var selectedRows = dgvCurrentPrivs.Rows.Cast<DataGridViewRow>()
                                .Where(r => Convert.ToBoolean(r.Cells[colSelect.Name].Value) == true)
                                .ToList();

            if (selectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn quyền cần thu hồi!");
                return;
            }

            if (MessageBox.Show($"Xác nhận thu hồi {selectedRows.Count} quyền?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            int successCount = 0;
            foreach (var row in selectedRows)
            {
                try
                {
                    // LẤY DỮ LIỆU TRỰC TIẾP TỪ GRID 
                    string objName = row.Cells[colObject.Name].Value?.ToString().Trim() ?? "";
                    string privName = row.Cells[colPrivilege.Name].Value?.ToString().Trim() ?? "";
                    string type = row.Cells[colObjType.Name].Value?.ToString().Trim() ?? "";
                    string colNameOnGrid = row.Cells[colColumns.Name].Value?.ToString().Trim() ?? "";

                    string columnToIn = null;

                    // Kiểm tra nếu không phải là "Tất cả cột" thì mới là quyền mức cột
                    if (!string.IsNullOrEmpty(colNameOnGrid) && colNameOnGrid != "Tất cả cột")
                    {
                        columnToIn = colNameOnGrid;
                    }

                    var parameters = new OracleParameter[] {
                new OracleParameter("p_type", OracleDbType.Varchar2, type, ParameterDirection.Input),
                new OracleParameter("p_privilege", OracleDbType.Varchar2, privName, ParameterDirection.Input),
                new OracleParameter("p_object", OracleDbType.Varchar2, string.IsNullOrEmpty(objName) ? (object)DBNull.Value : objName, ParameterDirection.Input),
                new OracleParameter("p_grantee", OracleDbType.Varchar2, _currentGrantee.Trim(), ParameterDirection.Input),
                new OracleParameter("p_columns", OracleDbType.Varchar2, (object)columnToIn ?? DBNull.Value, ParameterDirection.Input)
            };

                    // Gọi Proc
                    DataProvider.Instance.ExecuteNonQuery("sp_revoke_privilege", parameters);
                    successCount++;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi tại dòng {row.Index + 1}: {ex.Message}");
                }
            }

            MessageBox.Show($"Đã thu hồi thành công {successCount} quyền.");
            LoadPrivilegesFromDb(_currentGrantee);
            UpdateActionBar();
        }

        // ================================================
        // VẼ THỦ CÔNG LISTBOX — hiển thị avatar tròn, tên, role
        // Dùng OwnerDraw để tùy chỉnh giao diện từng item
        // ================================================
        private void LstGrantees_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            var item = lstGrantees.Items[e.Index] as GranteeItem;
            if (item == null) return;

            bool sel = (e.State & DrawItemState.Selected) != 0;

            // Màu nền: đỏ nhạt khi selected, trắng xen hồng nhạt khi bình thường
            Color bg = sel
                ? Color.FromArgb(255, 232, 232)
                : (e.Index % 2 == 0 ? Color.White : Color.FromArgb(255, 249, 249));
            e.Graphics.FillRectangle(new SolidBrush(bg), e.Bounds);

            // Thanh màu đỏ bên trái khi item được chọn
            if (sel)
                e.Graphics.FillRectangle(
                    new SolidBrush(Color.FromArgb(228, 45, 45)),
                    new Rectangle(e.Bounds.X, e.Bounds.Y, 3, e.Bounds.Height));

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Avatar hình tròn với 2 chữ cái đầu của tên
            var av = new Rectangle(e.Bounds.X + 10, e.Bounds.Y + 10, 32, 32);
            e.Graphics.FillEllipse(new SolidBrush(item.Color), av);
            string avTxt = item.Name.Length >= 2
                ? item.Name.Substring(0, 2).ToUpper() : item.Name;
            e.Graphics.DrawString(avTxt,
                new Font("Segoe UI", 8, FontStyle.Bold), Brushes.White, av,
                new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                });

            // Tên user/role
            e.Graphics.DrawString(item.Name,
                new Font("Segoe UI", 11, FontStyle.Bold),
                new SolidBrush(Color.FromArgb(10, 42, 64)),
                new Rectangle(e.Bounds.X + 52, e.Bounds.Y + 7,
                              e.Bounds.Width - 70, 22));

            // Role hoặc số lượng user (dòng phụ)
            e.Graphics.DrawString(item.RoleName,
                new Font("Segoe UI", 9),
                new SolidBrush(Color.FromArgb(138, 168, 190)),
                new Rectangle(e.Bounds.X + 52, e.Bounds.Y + 28,
                              e.Bounds.Width - 70, 16));

            // Dấu tick đỏ góc phải khi item đang được chọn
            if (sel)
            {
                var ck = new Rectangle(e.Bounds.Right - 28, e.Bounds.Y + 13, 16, 16);
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(228, 45, 45)), ck);
                e.Graphics.DrawString("✓",
                    new Font("Segoe UI", 8, FontStyle.Bold), Brushes.White, ck,
                    new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    });
            }
        }
    }

    // ================================================
    // MODEL: GranteeItem — đại diện 1 user hoặc role
    // ================================================
    public class GranteeItem
    {
        public string Name { get; set; }
        public string RoleName { get; set; }
        public Color Color { get; set; }
        public GranteeItem(string name, string role, Color color)
        { Name = name; RoleName = role; Color = color; }
    }
}