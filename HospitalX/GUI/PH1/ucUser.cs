using HospitalX.DAO;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using HospitalX.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;
using System.Linq;

namespace HospitalX.GUI.PH1
{
    public partial class ucUser : UserControl
    {
        // ================================================
        // BIẾN TOÀN CỤC
        // _connectionString : chuỗi kết nối Oracle, nhận từ form cha khi khởi tạo
        // _allUsers         : toàn bộ danh sách user gốc (không bị lọc)
        // _filteredUsers    : danh sách user sau khi áp dụng bộ lọc tìm kiếm
        // _pageSize         : số user hiển thị tối đa trên mỗi trang
        // _currentPage      : trang hiện tại đang xem
        // ================================================
        private string _connectionString;
        private List<UserItem> _allUsers;
        private List<UserItem> _filteredUsers;

        private int _pageSize = 8;
        private int _currentPage = 1;

        // ================================================
        // CONSTRUCTOR — khởi tạo component, gắn sự kiện và load dữ liệu
        // ================================================
        // Xóa user đang chọn (gọi stored procedure sp_DropUser trên Oracle)
        private void DeleteSelectedUser()
        {
            if (!(lstUsers.SelectedItem is UserItem item)) return;

            var dr = MessageBox.Show($"Bạn có chắc muốn xóa người dùng {item.Username} (CASCADE)?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr != DialogResult.Yes) return;

            // gọi stored procedure sp_DropUser với parameter p_username để xóa user
            try
            {
                var parameters = new OracleParameter[] {
                    new OracleParameter("p_username", OracleDbType.Varchar2, item.Username, System.Data.ParameterDirection.Input)
                };

                DataProvider.Instance.ExecuteNonQuery("sp_DropUser", parameters);

                MessageBox.Show($"Đã xóa người dùng {item.Username}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reload
                LoadUsersFromDb();
                ApplyFilters();
            }
            catch (Oracle.ManagedDataAccess.Client.OracleException ex)
            {
                MessageBox.Show("Lỗi khi xóa user: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Kiểm tra trạng thái hiện tại của user: Oracle có thể trả về nhiều giá trị
        // như 'OPEN', 'LOCKED', 'EXPIRED', 'EXPIRED & LOCKED', 'LOCKED(TIMED)', v.v.
        private bool IsAccountOpen(string status)
        {
            if (string.IsNullOrEmpty(status)) return false;
            return status.Equals("OPEN", StringComparison.OrdinalIgnoreCase);
        }

        // Khóa hoặc mở khóa tài khoản người dùng (gọi stored procedure sp_LockUser hoặc sp_UnlockUser trên Oracle)
        // Sử dụng _connectionString trực tiếp để đảm bảo dùng quyền của Admin đang đăng nhập
        private void LockUnlockUser(UserItem item)
        {
            if (item == null) return;

            // Kiểm tra Oracle ACCOUNT_STATUS: chỉ 'OPEN' là mở; mọi giá trị khác đều coi là đã khóa/hạn chế
            bool isCurrentlyOpen = IsAccountOpen(item.Status);
            string action = isCurrentlyOpen ? "khóa" : "mở khóa";

            var dr = MessageBox.Show(
                $"Bạn có chắc muốn {action} tài khoản [{item.Username}]?\n" +
                $"Trạng thái hiện tại: {item.Status}",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr != DialogResult.Yes) return;

            try
            {
                string spName = isCurrentlyOpen ? "sp_LockUser" : "sp_UnlockUser";

                // Dùng _connectionString của ucUser (connection admin đã đăng nhập)
                // để đảm bảo có đủ quyền ALTER USER
                using (var conn = new OracleConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = new OracleCommand(spName, conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.BindByName = true;
                        cmd.Parameters.Add(new OracleParameter("p_username", OracleDbType.Varchar2) { Value = item.Username });
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(
                    $"Đã {action} tài khoản [{item.Username}] thành công!\n" +
                    $"Tài khoản này {(isCurrentlyOpen ? "sẽ KHÔNG thể đăng nhập" : "có thể đăng nhập lại")}.",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reload để cập nhật trạng thái mới
                LoadUsersFromDb();
                ApplyFilters();
            }
            catch (OracleException ex)
            {
                MessageBox.Show(
                    $"Lỗi Oracle khi {action} tài khoản [{item.Username}]:\n" +
                    $"ORA-{ex.Number}: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Lỗi không xác định khi {action} tài khoản [{item.Username}]:\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public ucUser(string connStr)
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            _connectionString = connStr;

            // Gắn sự kiện vẽ tay (OwnerDraw) cho 2 ListBox
            lstUsers.DrawItem += LstUsers_DrawItem;
            lstUsers.SelectedIndexChanged += LstUsers_SelectedIndexChanged;
            lstDetails.DrawItem += LstDetails_DrawItem;

            // Mỗi khi tìm kiếm hoặc đổi bộ lọc → reset về trang 1 và lọc lại
            txtSearch.TextChanged += (s, e) => { _currentPage = 1; ApplyFilters(); };
            cmbFilterRole.SelectedIndexChanged += (s, e) => { _currentPage = 1; ApplyFilters(); };
            cmbFilterStatus.SelectedIndexChanged += (s, e) => { _currentPage = 1; ApplyFilters(); };

            // Load roles from database
            LoadRolesFromDb();

            // Nút phân trang: lùi, tiến, nhảy về trang hiện tại
            btnPrev.Click += (s, e) => { if (_currentPage > 1) { _currentPage--; DisplayPage(); } };
            btnNext.Click += (s, e) => { if (_currentPage < TotalPages()) { _currentPage++; DisplayPage(); } };
            btnPage1.Click += (s, e) => { _currentPage = 1; DisplayPage(); };

            // Nút Tạo user mới → mở form frmCreateUser
            btnCreate.Click += (s, e) =>
            {
                using (var f = new frmCreateUser())
                {
                    if (f.ShowDialog() == DialogResult.OK)
                    {
                        // Reload từ DB để hiện thay đổi
                        LoadUsersFromDb();
                        ApplyFilters();
                    }

                }
            };


            // Nút Sửa thông tin → mở form frmEditUser với thông tin user đang chọn
            btnEditInfo.Click += (s, e) =>
            {
                if (lstUsers.SelectedItem is UserItem item)
                {
                    using (var f = new frmEditUser(item.Username))
                    {
                        if (f.ShowDialog() == DialogResult.OK)
                        {
                            // Cập nhật lại dữ liệu từ form
                            item.FullName = f.FullName;
                            item.Gender = f.Gender;
                            item.Phone = f.Phone;
                            item.BirthDate = f.BirthDate;
                            item.Address = f.Address;

                            // Load lại chi tiết để thấy thay đổi (nếu có hiển thị)
                            LstUsers_SelectedIndexChanged(null, null);
                        }
                    }
                }
            };

            // Nút Đổi mật khẩu → mở form frmChangePassword với username đang chọn
            btnChangePassword.Click += (s, e) =>
            {
                if (lstUsers.SelectedItem is UserItem item)
                {
                    using (var f = new frmChangePassword(item.Username))
                    {
                        if (f.ShowDialog() == DialogResult.OK)
                        {
                            // Đổi mật khẩu đã được thực hiện trong frmChangePassword (gọi sp_ChangeUserPassword)
                            MessageBox.Show($"Đã đổi mật khẩu cho {item.Username}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            };

            // Context menu for list (Delete user)
            var cms = new ContextMenuStrip();
            cms.Items.Add("Xóa người dùng", null, (s, e) => DeleteSelectedUser());
            lstUsers.ContextMenuStrip = cms;

            // Button lock/unlock
            btnLockAccount.Click += (sender, evt) =>
            {
                if (lstUsers.SelectedItem is UserItem itm)
                {
                    LockUnlockUser(itm);
                }
            };

            // Enable clickable buttons in listbox items (Lock/Unlock and Delete)
            lstUsers.MouseClick += LstUsers_MouseClick;

            // Khi vùng footer phải thay đổi kích thước → căn giữa lại các nút
            pnlRightFooter.Resize += PnlRightFooter_Resize;

            // Load real users from Oracle DB (falls back to empty list if error)
            LoadUsersFromDb();
            ApplyFilters();
        }

        // ================================================
        // TÍNH TỔNG SỐ TRANG — dựa trên số user đã lọc và pageSize
        // ================================================
        private int TotalPages() => Math.Max(1, (int)Math.Ceiling(_filteredUsers.Count / (double)_pageSize));

        // ================================================
        // LỌC DANH SÁCH USER — áp dụng đồng thời 3 bộ lọc:
        // keyword (tìm theo username), role, trạng thái (Active/Locked)
        // ================================================
        private void ApplyFilters()
        {
            if (_allUsers == null) return;

            string keyword = txtSearch.Text.Trim().ToUpper();
            string roleFilter = cmbFilterRole.SelectedItem?.ToString() ?? "Tất cả role";
            string statusFilter = cmbFilterStatus.SelectedItem?.ToString() ?? "Tất cả trạng thái";

            _filteredUsers = _allUsers.FindAll(u =>
                (string.IsNullOrEmpty(keyword) || u.Username.ToUpper().Contains(keyword)) &&
                (roleFilter == "Tất cả role" || u.Roles.Contains(roleFilter)) &&
                (statusFilter == "Tất cả trạng thái" || u.Status == statusFilter)
            );

            DisplayPage();
        }

        // ================================================
        // HIỂN THỊ TRANG HIỆN TẠI — cắt danh sách đã lọc
        // theo _currentPage và _pageSize rồi đổ vào ListBox
        // ================================================
        private void DisplayPage()
        {
            lstUsers.Items.Clear();
            int startIdx = (_currentPage - 1) * _pageSize;
            int endIdx = Math.Min(startIdx + _pageSize, _filteredUsers.Count);

            for (int i = startIdx; i < endIdx; i++)
            {
                lstUsers.Items.Add(_filteredUsers[i]);
            }

            if (lstUsers.Items.Count > 0)
                lstUsers.SelectedIndex = 0;

            UpdateFooterUI();
        }

        // ================================================
        // CẬP NHẬT FOOTER — hiển thị tổng số user, số trang
        // và đánh dấu nút trang hiện tại màu xanh
        // ================================================
        private void UpdateFooterUI()
        {
            lblUserCount.Text = $"Tổng số: {_allUsers.Count} users trong hệ thống";
            lblPageInfo.Text = $"Trang {_currentPage} / {TotalPages()}";

            // Hiển thị số trang hiện tại trong nút bấm duy nhất
            btnPage1.Text = _currentPage.ToString();

            // Luôn để btnPage1 là Active (nền xanh)
            btnPage1.FillColor = Color.FromArgb(0, 120, 180);
            btnPage1.ForeColor = Color.White;

        }

        // ================================================
        // Load users from Oracle using stored procedure USP_LIST_USERS
        // Expects the stored procedure to return a SYS_REFCURSOR with columns:
        // USERNAME, ACCOUNT_STATUS, DEFAULT_TABLESPACE, CREATED
        // ================================================
        private void LoadUsersFromDb()
        {
            _allUsers = new List<UserItem>();

            try
            {
                var param = new OracleParameter[] {
                    new OracleParameter("p_cursor", OracleDbType.RefCursor) { Direction = ParameterDirection.Output }
                };

                DataTable dt = DataProvider.Instance.ExecuteQuery("USP_LIST_USERS", param);

                Color[] colors = { Color.FromArgb(41, 121, 255), Color.FromArgb(150, 100, 250), Color.FromArgb(250, 150, 50), Color.FromArgb(140, 150, 160) };

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var row = dt.Rows[i];
                    string username = row["USERNAME"]?.ToString() ?? "";
                    string status = row["ACCOUNT_STATUS"]?.ToString() ?? "";
                    string tablespace = row["DEFAULT_TABLESPACE"]?.ToString() ?? "";
                    string created = row["CREATED"]?.ToString() ?? "";

                    // Load role from database
                    List<string> roles = GetUserRoles(username);

                    // Derive initials (first two non-underscore letters)
                    string initials = "--";
                    var parts = username.Split(new char[] { '_', '.' }, StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length > 0)
                        initials = parts[0].Length >= 2 ? parts[0].Substring(0, 2).ToUpper() : parts[0].ToUpper();

                    // Pick a color deterministically
                    int colorIdx = (username.GetHashCode() & 0x7fffffff) % colors.Length;
                    var u = new UserItem(username, roles, status, created, tablespace, initials, colors[colorIdx]);

                    _allUsers.Add(u);
                }
            }
            catch (Exception ex)
            {
                // Nếu có lỗi, để danh sách rỗng và log thông báo (có thể hiện UI message sau)
                _allUsers = new List<UserItem>();
                System.Diagnostics.Debug.WriteLine("LoadUsersFromDb error: " + ex.Message);
            }
        }

        // ================================================
        // Hàm vẽ danh sách Role dạng Badge bên phải khi chọn user
        // ================================================
        private void AddRolesToDetail(List<string> roles, int y)
        {

            // Lấy User đang được chọn để dùng trong câu lệnh Revoke
            if (!(lstUsers.SelectedItem is UserItem currentUser)) return;

            // KIỂM TRA TRẠNG THÁI USER
            bool isLocked = currentUser.Status != "OPEN";

            Label lblTitle = new Label
            {
                Text = "VAI TRÒ HỆ THỐNG",
                Location = new Point(0, y),
                Font = new Font("Segoe UI", 8, FontStyle.Bold),
                ForeColor = Color.FromArgb(138, 168, 190),
                AutoSize = true
            };
            pnlDetailsGrid.Controls.Add(lblTitle);

            // NÚT "+": Để thêm Role
            var btnAddRole = new Guna.UI2.WinForms.Guna2Button
            {
                Text = "+",
                Size = new Size(60, 25),
                BorderRadius = 5,
                Location = new Point(lblTitle.Right + 295, y),
                FillColor = Color.FromArgb(0, 120, 180), // Xanh dương đồng bộ App
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 7.5F, FontStyle.Bold), // Font to rõ ràng
                Cursor = Cursors.Hand,
                Enabled = !isLocked,
                Animated = true, // Hiệu ứng khi nhấn
            };
            btnAddRole.Click += (s, e) => ShowAddRolePopup(currentUser);
            pnlDetailsGrid.Controls.Add(btnAddRole);

            // FlowLayoutPanel CÓ THANH CUỘN
            FlowLayoutPanel flpRoles = new FlowLayoutPanel
            {
                Location = new Point(0, y + 22),
                Size = new Size(pnlDetailsGrid.Width - 5, 80), // Chiều cao cố định để kích hoạt scroll
                AutoScroll = true, 
                WrapContents = true,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
                Padding = new Padding(0, 5, 5, 5)
            };

            foreach (var role in roles)
            {
                var badge = new Guna.UI2.WinForms.Guna2Button
                {
                    Text = role,
                    Font = new Font("Segoe UI", 7.5f, FontStyle.Bold),
                    BorderRadius = 10,
                    Height = 22,
                    AutoSize = true,
                    Cursor = Cursors.Hand,
                    Enabled = true // Mở lại để bấm được
                };

                // Màu hồng 
                Color pinkBg = Color.FromArgb(255, 240, 245);
                Color pinkText = Color.FromArgb(219, 112, 147);
                badge.FillColor = pinkBg;
                badge.ForeColor = pinkText;
                // Hover vào hiện màu đỏ nhẹ để cảnh báo "xóa"
                badge.HoverState.FillColor = Color.FromArgb(255, 230, 230);
                badge.HoverState.ForeColor = Color.Red;

                // XỬ LÝ THU HỒI KHI CLICK
                badge.Click += (s, e) => {
                    var res = MessageBox.Show($"Bạn có muốn thu hồi vai trò [{role}] từ người dùng [{currentUser.Username}]?",
                                            "Xác nhận Thu hồi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.Yes)
                    {
                        ExecuteRevokeRole(currentUser.Username, role);
                    }
                };

                flpRoles.Controls.Add(badge);
            }
            pnlDetailsGrid.Controls.Add(flpRoles);
        }


        // ================================================
        // Hàm revoke role từ user
        // — gọi stored procedure sp_revoke_privilege
        // - với type=ROLE, privilege=roleName, grantee=username
        // ================================================
        private void ExecuteRevokeRole(string username, string roleName)
        {
            try
            {
                var parameters = new OracleParameter[] {
            new OracleParameter("p_type", OracleDbType.Varchar2) { Value = "ROLE" },
            new OracleParameter("p_privilege", OracleDbType.Varchar2) { Value = roleName },
            new OracleParameter("p_object", OracleDbType.Varchar2) { Value = DBNull.Value },
            new OracleParameter("p_grantee", OracleDbType.Varchar2) { Value = username },
            new OracleParameter("p_column", OracleDbType.Varchar2) { Value = DBNull.Value }
        };

                DataProvider.Instance.ExecuteNonQuery("sp_revoke_privilege", parameters);
                MessageBox.Show($"Đã thu hồi vai trò {roleName} thành công!");

                // Refresh lại dữ liệu
                LoadUsersFromDb();
                ApplyFilters();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thu hồi role: " + ex.Message);
            }
        }

        // ================================================
        // Hàm hiển thị danh sách role để grant cho user
        // ================================================
        private void ShowAddRolePopup(UserItem user)
        {
            Form f = new Form
            {
                Text = "Cấp vai trò cho " + user.Username,
                Size = new Size(320, 400),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                BackColor = Color.White
            };

            // Panel chính bao ngoài
            FlowLayoutPanel mainPnl = new FlowLayoutPanel { Dock = DockStyle.Fill, Padding = new Padding(20) };

            Label lbl = new Label
            {
                Text = "Chọn các vai trò muốn cấp:",
                AutoSize = true,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                Margin = new Padding(0, 0, 0, 10)
            };
            mainPnl.Controls.Add(lbl);

            // --- PANEL CUỘN CHỨA DANH SÁCH ROLE ---
            FlowLayoutPanel scrollPnl = new FlowLayoutPanel
            {
                Size = new Size(265, 190), // Chiều cao cố định 
                AutoScroll = true,
                WrapContents = false,
                FlowDirection = FlowDirection.TopDown,
                BorderStyle = BorderStyle.None
            };

            var param = new OracleParameter[] { new OracleParameter("p_cursor", OracleDbType.RefCursor) { Direction = ParameterDirection.Output } };
            DataTable dtRoles = DataProvider.Instance.ExecuteQuery("USP_LIST_ROLES", param);

            foreach (DataRow r in dtRoles.Rows)
            {
                string rName = r["ROLE"].ToString();
                if (!user.Roles.Contains(rName))
                {
                    Guna.UI2.WinForms.Guna2CheckBox cb = new Guna.UI2.WinForms.Guna2CheckBox
                    {
                        Text = rName,
                        Tag = rName,
                        Width = 240,
                        Font = new Font("Segoe UI", 9),
                        CheckedState = { FillColor = Color.FromArgb(0, 120, 180) },
                        Margin = new Padding(0, 0, 0, 5)
                    };
                    scrollPnl.Controls.Add(cb);
                }
            }
            mainPnl.Controls.Add(scrollPnl);

            // --- CÁC THÀNH PHẦN CỐ ĐỊNH Ở DƯỚI ---
            Guna.UI2.WinForms.Guna2CheckBox cbAdmin = new Guna.UI2.WinForms.Guna2CheckBox
            {
                Text = "WITH ADMIN OPTION",
                ForeColor = Color.OrangeRed,
                Font = new Font("Segoe UI", 8, FontStyle.Italic | FontStyle.Bold),
                Margin = new Padding(0, 15, 0, 10), 
                AutoSize = true
            };
            mainPnl.Controls.Add(cbAdmin);

            Guna.UI2.WinForms.Guna2Button btnGrant = new Guna.UI2.WinForms.Guna2Button
            {
                Text = "Thực hiện GRANT →",
                FillColor = Color.FromArgb(0, 120, 180),
                BorderRadius = 10,
                Width = 260,
                Height = 40,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                Cursor = Cursors.Hand,
                Animated = true
            };

            btnGrant.Click += (s, e) => {
                var selectedRoles = scrollPnl.Controls.OfType<Guna.UI2.WinForms.Guna2CheckBox>()
                                    .Where(c => c.Checked).Select(c => c.Tag.ToString()).ToList();

                if (selectedRoles.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn ít nhất một vai trò!");
                    return;
                }

                foreach (var r in selectedRoles)
                {
                    var grantParam = new OracleParameter[] {
                new OracleParameter("p_role_name", OracleDbType.Varchar2) { Value = r },
                new OracleParameter("p_grantee", OracleDbType.Varchar2) { Value = user.Username },
                new OracleParameter("p_with_admin", OracleDbType.Varchar2) { Value = cbAdmin.Checked ? "YES" : "NO" }
            };
                    DataProvider.Instance.ExecuteNonQuery("SP_GRANT_ROLE_TO_USER", grantParam);
                }

                MessageBox.Show($"Đã cấp {selectedRoles.Count} vai trò thành công!");
                f.DialogResult = DialogResult.OK;
            };

            mainPnl.Controls.Add(btnGrant);
            f.Controls.Add(mainPnl);

            if (f.ShowDialog() == DialogResult.OK)
            {
                LoadUsersFromDb();
                ApplyFilters();
            }
        }
        // ================================================
        // KHI CHỌN USER TỪ LISTBOX — cập nhật toàn bộ panel
        // bên phải: avatar, tên, role, thông tin chi tiết, danh sách quyền
        // và đổi text nút Khóa/Mở khóa theo trạng thái hiện tại
        // ================================================
        private void LstUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstUsers.SelectedItem is UserItem item)
            {
                btnUserIcon.Text = item.Initials;
                btnUserIcon.FillColor = item.AvatarColor;
                lblUsername.Text = item.Username;

                pnlDetailsGrid.Controls.Clear();
                AddDetailRow("USERNAME", item.Username, 0);
                AddDetailRow("TRẠNG THÁI", item.Status, 30);
                AddDetailRow("NGÀY TẠO", item.CreateDate, 60);
                AddDetailRow("TABLESPACE", item.TableSpace, 90);

                int yRoles = 125; // Vị trí y tiếp theo sau Tablespace
                AddRolesToDetail(item.Roles, yRoles);

                lstDetails.Items.Clear();
                LoadUserPrivileges(item.Username);

                        btnLockAccount.Text = (item.Status == "OPEN") ? "Khóa tài khoản" : "Mở khóa tài khoản";
                    }
                }

                // ================================================
                // LOAD USER PRIVILEGES — lấy danh sách quyền của user từ DB
                // Gọi procedure USP_GET_OBJ_PRIVS để lấy quyền mức bảng và mức cột
                // ================================================
                private void LoadUserPrivileges(string username)
                {
                    lstDetails.Items.Clear();

                    try
                    {
                        var param = new OracleParameter[] {
                            new OracleParameter("p_grantee", OracleDbType.Varchar2, username, ParameterDirection.Input),
                            new OracleParameter("p_result", OracleDbType.RefCursor) { Direction = ParameterDirection.Output }
                        };

                        DataTable dt = DataProvider.Instance.ExecuteQuery("USP_GET_OBJ_PRIVS", param);

                        foreach (DataRow row in dt.Rows)
                        {
                            string objectName = row["OBJECT_NAME"]?.ToString() ?? "";
                            string objectType = row["TYPE"]?.ToString() ?? "";
                            string privilege = row["PRIVILEGE"]?.ToString() ?? "";
                            string columnName = row["COLUMN_NAME"]?.ToString() ?? "ALL COLUMN";

                            // Tạo display name: "OBJECT_NAME.PRIVILEGE" hoặc "OBJECT_NAME.COLUMN_NAME.PRIVILEGE"
                            string displayName = columnName == "ALL COLUMN" 
                                ? $"{objectName}.{privilege}" 
                                : $"{objectName}.{columnName}.{privilege}";

                            var privItem = new UserPrivItem(displayName, privilege);
                            lstDetails.Items.Add(privItem);
                        }

                        // Nếu không có quyền nào, hiển thị message
                        if (lstDetails.Items.Count == 0)
                        {
                            lstDetails.Items.Add(new UserPrivItem("Không có quyền", "NONE"));
                        }
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine("LoadUserPrivileges error: " + ex.Message);
                        lstDetails.Items.Add(new UserPrivItem("Lỗi tải quyền", "ERROR"));
                    }
                }

        // ================================================
        // HANDLER CLICK TRÊN LISTBOX ITEMS — phát hiện khi người dùng
        // click vào nút Lock/Unlock hoặc Delete trong từng item
        // ================================================
        private void LstUsers_MouseClick(object sender, MouseEventArgs e)
        {
            int index = lstUsers.IndexFromPoint(e.Location);
            if (index < 0) return;

            var item = lstUsers.Items[index] as UserItem;
            var bounds = lstUsers.GetItemRectangle(index);

            // Tính toán lại tọa độ y hệt như lúc vẽ
            int xButtons = bounds.Right - 157;
            var lockBtnRect = new Rectangle(xButtons, bounds.Y + 15, 65, 26);
            var deleteBtnRect = new Rectangle(xButtons + 75, bounds.Y + 15, 50, 26);

            if (lockBtnRect.Contains(e.Location)) LockUnlockUser(item);
            else if (deleteBtnRect.Contains(e.Location)) DeleteSelectedUser();
        }

        // ================================================
        // TẠO DÒNG THÔNG TIN CHI TIẾT — vẽ label key + value
        // vào pnlDetailsGrid theo vị trí y được truyền vào.
        // Trường TRẠNG THÁI được hiển thị dạng badge màu đặc biệt
        // ================================================
        private void AddDetailRow(string key, string val, int y)
        {
            int totalWidth = pnlDetailsGrid.Width > 40 ? pnlDetailsGrid.Width : 347;

            var lblKey = new Label
            {
                Text = key,
                Location = new Point(0, y),
                AutoSize = true,
                Font = new Font("Segoe UI", 8, FontStyle.Bold),
                ForeColor = Color.FromArgb(138, 168, 190),
                BackColor = Color.Transparent
            };
            pnlDetailsGrid.Controls.Add(lblKey);

            if (key == "TRẠNG THÁI")
            {
                bool isOpen = val == "OPEN";
                Color bg = isOpen ? Color.FromArgb(235, 250, 240) : Color.FromArgb(255, 240, 240);
                Color fg = isOpen ? Color.FromArgb(46, 160, 67) : Color.FromArgb(220, 53, 69);

                var badge = new Guna.UI2.WinForms.Guna2Panel
                {
                    Size = new Size(70, 22),
                    Location = new Point(totalWidth - 75, y - 2),
                    BorderRadius = 11,
                    FillColor = bg,
                    Anchor = AnchorStyles.Top | AnchorStyles.Right
                };

                var lblBadgeText = new Label
                {
                    Text = val,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill,
                    Font = new Font("Segoe UI", 8, FontStyle.Bold),
                    ForeColor = fg,
                    BackColor = Color.Transparent
                };

                badge.Controls.Add(lblBadgeText);
                pnlDetailsGrid.Controls.Add(badge);
            }
            else
            {
                var lblVal = new Label
                {
                    Text = val,
                    Location = new Point(0, y),
                    Size = new Size(totalWidth - 5, 20),
                    TextAlign = ContentAlignment.MiddleRight,
                    Font = new Font("Segoe UI", 9, FontStyle.Bold),
                    ForeColor = Color.FromArgb(10, 42, 64),
                    Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
                    BackColor = Color.Transparent
                };
                pnlDetailsGrid.Controls.Add(lblVal);
            }

            // Đường kẻ ngang mờ phân cách các dòng
            var line = new Panel
            {
                Height = 1,
                BackColor = Color.FromArgb(245, 245, 245),
                Location = new Point(0, y + 25),
                Width = totalWidth,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };
            pnlDetailsGrid.Controls.Add(line);
        }

        // ================================================
        // CĂN GIỮA CÁC NÚT ACTION — chạy khi pnlRightFooter
        // thay đổi kích thước để giữ các nút luôn nằm giữa panel
        // ================================================
        private void PnlRightFooter_Resize(object sender, EventArgs e)
        {
            int btnWidth = btnEditInfo.Width;
            int startX = (pnlRightFooter.Width - btnWidth) / 2;
            btnEditInfo.Left = startX;
            btnChangePassword.Left = startX;
            btnLockAccount.Left = startX;
        }

        // ================================================
        // VẼ THỦ CÔNG TỪNG ITEM TRONG LISTBOX USER (OwnerDraw)
        // Mỗi dòng gồm: avatar tròn, username, badge role,
        // badge trạng thái, ngày tạo, và 2 nút hành động vẽ giả
        // ================================================
        private void LstUsers_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            e.DrawBackground();
            Graphics g = e.Graphics;

            // Cấu hình Graphics chất lượng cao
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

            var item = lstUsers.Items[e.Index] as UserItem;
            if (item == null) return;

            bool selected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;
            var bg = selected ? Color.FromArgb(240, 248, 255) : Color.White;
            using (var brush = new SolidBrush(bg)) e.Graphics.FillRectangle(brush, e.Bounds);

            // Vẽ đường kẻ mờ phân cách
            using (var pen = new Pen(Color.FromArgb(245, 245, 245)))
                e.Graphics.DrawLine(pen, e.Bounds.X, e.Bounds.Bottom - 1, e.Bounds.Right, e.Bounds.Bottom - 1);

            // --- CĂN CHỈNH TỌA ĐỘ CỐ ĐỊNH THEO TỈ LỆ ---
            int xAvatar = e.Bounds.X + 15;
            int xUsername = xAvatar + 45;
            int xRoles = xUsername + 250; // Cột Role bắt đầu từ đây

            // Các cột phía sau tính từ lề phải (Right) để luôn thẳng hàng
            int xButtons = e.Bounds.Right - 157;
            int xDate = xButtons - 145;
            int xStatus = xDate - 175;

            // 1. Avatar
            var avRect = new Rectangle(xAvatar, e.Bounds.Y + 15, 30, 30);
            g.FillEllipse(new SolidBrush(item.AvatarColor), avRect);
            g.DrawString(item.Initials, new Font("Segoe UI", 8, FontStyle.Bold), Brushes.White, avRect, new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });

            // 2. Username
            g.DrawString(item.Username, new Font("Segoe UI", 10, FontStyle.Bold), new SolidBrush(Color.FromArgb(10, 42, 64)), xUsername, e.Bounds.Y + 20);

            // 3. SMART ROLE DISPLAY (Hiện Role thông minh)
            if (item.Roles.Count > 0)
            {
                string roleTxt = item.Roles[0];
                var roleSize = g.MeasureString(roleTxt, new Font("Segoe UI", 8));
                var roleRect = new Rectangle(xRoles, e.Bounds.Y + 20, (int)roleSize.Width + 15, 20);

                g.FillRoundedRectangle(new SolidBrush(Color.FromArgb(240, 248, 255)), roleRect, 10);
                g.DrawString(roleTxt, new Font("Segoe UI", 8), new SolidBrush(Color.FromArgb(60, 100, 180)), roleRect, new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });

                // Nếu có nhiều hơn 1 role, hiện thêm badge "+N"
                if (item.Roles.Count > 1)
                {
                    var moreRect = new Rectangle(roleRect.Right + 5, e.Bounds.Y + 20, 35, 20);
                    g.FillRoundedRectangle(new SolidBrush(Color.FromArgb(255, 245, 230)), moreRect, 10);
                    g.DrawString($"+{item.Roles.Count - 1}", new Font("Segoe UI", 8, FontStyle.Bold), new SolidBrush(Color.OrangeRed), moreRect, new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                }
            }

            // 4. Status Badge
            var stRect = new Rectangle(xStatus, e.Bounds.Y + 20, 65, 20);
            bool isOpen = item.Status == "OPEN";
            g.FillRoundedRectangle(new SolidBrush(isOpen ? Color.FromArgb(235, 250, 240) : Color.FromArgb(255, 240, 240)), stRect, 10);
            g.DrawString(item.Status, new Font("Segoe UI", 8, FontStyle.Bold), new SolidBrush(isOpen ? Color.FromArgb(46, 160, 67) : Color.FromArgb(220, 53, 69)), stRect, new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });

            // 5. Date
            g.DrawString(item.CreateDate, new Font("Segoe UI", 9), new SolidBrush(Color.Gray), xDate, e.Bounds.Y + 20);

            // 6. Action Buttons (Xác định lại tọa độ chuẩn để click)
            var btnLock = new Rectangle(xButtons, e.Bounds.Y + 15, 65, 26);
            var btnDel = new Rectangle(xButtons + 75, e.Bounds.Y + 15, 50, 26);

            g.DrawRoundedRectangle(new Pen(Color.FromArgb(100, 150, 200)), btnLock, 6);
            g.DrawString(isOpen ? "Khóa" : "Mở khóa", new Font("Segoe UI", 8), new SolidBrush(Color.FromArgb(60, 120, 180)), btnLock, new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });

            g.DrawRoundedRectangle(new Pen(Color.FromArgb(255, 200, 200)), btnDel, 6);
            g.DrawString("Xóa", new Font("Segoe UI", 8), Brushes.Maroon, btnDel, new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
        }

        // ================================================
        // VẼ THỦ CÔNG TỪNG ITEM TRONG LISTBOX CHI TIẾT QUYỀN
        // Hiển thị tên đối tượng và badge màu theo loại quyền (SELECT/UPDATE/INSERT/EXECUTE)
        // ================================================
        private void LstDetails_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            e.DrawBackground();

            // Cấu hình Graphics chất lượng cao
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            var p = lstDetails.Items[e.Index] as UserPrivItem;
            if (p == null) return;

            e.Graphics.FillRectangle(Brushes.White, e.Bounds);
            using (var pLine = new Pen(Color.FromArgb(245, 245, 245)))
                e.Graphics.DrawLine(pLine, e.Bounds.X, e.Bounds.Bottom - 1, e.Bounds.Right, e.Bounds.Bottom - 1);

            // Tên đối tượng DB (bảng/view/procedure)
            e.Graphics.DrawString(p.ObjName, new Font("Segoe UI", 9, FontStyle.Bold), new SolidBrush(Color.FromArgb(10, 42, 64)), e.Bounds.X, e.Bounds.Y + 10);

            // Badge loại quyền — màu sắc khác nhau theo từng loại
            string tag = p.Action;
            Color tagBg = Color.FromArgb(238, 243, 250);
            Color tagFg = Color.FromArgb(60, 100, 160);
            if (tag == "UPDATE") { tagBg = Color.FromArgb(254, 249, 230); tagFg = Color.FromArgb(180, 130, 40); }
            else if (tag == "INSERT") { tagBg = Color.FromArgb(235, 250, 240); tagFg = Color.FromArgb(46, 160, 67); }
            else if (tag == "EXECUTE") { tagBg = Color.FromArgb(245, 235, 250); tagFg = Color.FromArgb(130, 60, 180); }

            int width = (int)e.Graphics.MeasureString(tag, new Font("Segoe UI", 8, FontStyle.Bold)).Width + 20;
            var tagRect = new Rectangle(e.Bounds.Right - width, e.Bounds.Y + 8, width, 22);

            using (var tagBrush = new SolidBrush(tagBg))
                e.Graphics.FillRoundedRectangle(tagBrush, tagRect, 11);

            e.Graphics.DrawString(tag, new Font("Segoe UI", 8, FontStyle.Bold), new SolidBrush(tagFg), tagRect, new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
        }

        // ================================================
        // LOAD ALL ROLES FROM DATABASE — lấy toàn bộ roles
        // từ DBA_ROLES để hiển thị trong filter dropdown
        // ================================================
        private void LoadRolesFromDb()
        {
            cmbFilterRole.Items.Clear();
            cmbFilterRole.Items.Add("Tất cả role");

            try
            {
                var param = new OracleParameter[] {
                    new OracleParameter("p_cursor", OracleDbType.RefCursor) { Direction = ParameterDirection.Output }
                };

                DataTable dt = DataProvider.Instance.ExecuteQuery("USP_LIST_ROLES", param);

                foreach (DataRow row in dt.Rows)
                {
                    string role = row["ROLE"]?.ToString() ?? "";
                    if (!string.IsNullOrEmpty(role))
                        cmbFilterRole.Items.Add(role);
                }

                cmbFilterRole.SelectedIndex = 0; // Chọn "Tất cả role" mặc định
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("LoadRolesFromDb error: " + ex.Message);
                cmbFilterRole.Items.Clear();
                cmbFilterRole.Items.Add("Tất cả role");
                cmbFilterRole.SelectedIndex = 0;
            }
        }

        // ================================================
        // GET USER ROLE — lấy role đang được gán cho user
        // từ DBA_ROLE_PRIVS (nếu có multiple roles, lấy role đầu tiên, và số lượng role còn lại)
        // ================================================
        private List<string> GetUserRoles(string username)
        {
            var roles = new List<string>();
            try
            {
                var param = new OracleParameter[] {
            new OracleParameter("p_username", OracleDbType.Varchar2, username, ParameterDirection.Input),
            new OracleParameter("p_cursor", OracleDbType.RefCursor) { Direction = ParameterDirection.Output }
        };
                DataTable dt = DataProvider.Instance.ExecuteQuery("USP_GET_USER_ROLE", param);
                foreach (DataRow row in dt.Rows)
                {
                    roles.Add(row["GRANTED_ROLE"]?.ToString() ?? "");
                }
            }
            catch { }
            return roles;
        }
    }


    // ================================================
    // MODEL: UserItem — đại diện cho 1 tài khoản Oracle
    // Chứa thông tin cơ bản (username, role, status, tablespace)
    // và thông tin bổ sung (họ tên, giới tính, SĐT, ngày sinh, địa chỉ)
    // ================================================
    public class UserItem
    {
        public string Username { get; set; }
        public string Status { get; set; }
        public string CreateDate { get; set; }
        public string TableSpace { get; set; }
        public string Initials { get; set; }
        public Color AvatarColor { get; set; }
        public List<UserPrivItem> Privileges { get; set; }
        public List<string> Roles { get; set; } = new List<string>();
        // Thuộc tính phụ để hiển thị nhanh
        public string Role => PrimaryRole;
        public string PrimaryRole => Roles.Count > 0 ? Roles[0] : "No Role";

        // Additional Info
        public string FullName { get; set; } = "";
        public string Gender { get; set; } = "Nam";
        public string Phone { get; set; } = "";
        public string BirthDate { get; set; } = ""; // Đã đổi sang string
        public string Address { get; set; } = "";

        public UserItem(string u, List<string> r, string s, string d, string t, string init, Color c)
        {
            Username = u; Roles = r; Status = s; CreateDate = d; TableSpace = t; Initials = init; AvatarColor = c;
            Privileges = new List<UserPrivItem>();
        }
    }

    // ================================================
    // MODEL: UserPrivItem — đại diện cho 1 quyền của user
    // ObjName: tên đối tượng DB (bảng/view/procedure)
    // Action : loại quyền (SELECT / UPDATE / INSERT / EXECUTE)
    // ================================================
    public class UserPrivItem
    {
        public string ObjName { get; set; }
        public string Action { get; set; }
        public UserPrivItem(string n, string a) { ObjName = n; Action = a; }
    }


}