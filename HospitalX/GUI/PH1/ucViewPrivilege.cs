// ============================================================
// ucViewPrivilege.cs
// Giao diện "Xem quyền" — cho phép DBA xem toàn bộ quyền
// của một User hoặc Role trong hệ thống Oracle.
// Gồm: danh sách user/role bên trái, chi tiết quyền bên phải.
// ============================================================
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using HospitalX.DAO;

namespace HospitalX.GUI.PH1
{
    public partial class ucViewPrivilege : UserControl
    {
        // ===================================================
        // KHAI BÁO BIẾN DÙNG CHUNG
        // ===================================================
        private string _connectionString;
        private string _currentTab = "OBJ"; // Tab đang chọn: OBJ / SYS / ROLE
        private List<UserItem> _allUsers = new List<UserItem>();
        private List<UserItem> _allRoles = new List<UserItem>();
        private Guna.UI2.WinForms.Guna2TextBox txtSearchDGV;

        public ucViewPrivilege(string connStr)
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            _connectionString = connStr;

            // FIX TẠI ĐÂY: Tăng độ cao dòng để không bị cắt chữ
            lstUsers.ItemHeight = 50;
            lstUsers.DrawMode = DrawMode.OwnerDrawFixed; // Đảm bảo chế độ vẽ tay được bật

            // Bật double buffer cho ListBox để tránh nhấp nháy khi scroll
            EnableListBoxDoubleBuffer(lstUsers);

            // Wire sự kiện — làm ở đây thay vì trong Load
            // để đảm bảo event luôn sẵn sàng trước khi dữ liệu được load
            lstUsers.SelectedIndexChanged += LstUsers_SelectedIndexChanged;
            txtSearch.TextChanged += txtSearch_TextChanged;
            btnRefresh.Click += btnRefresh_Click;
            btnSubUser.Click += btnSubUser_Click;
            btnSubRole.Click += btnSubRole_Click;
            btnTabObjPriv.Click += btnTabObjPriv_Click;
            btnTabSysPriv.Click += btnTabSysPriv_Click;
            btnTabRole.Click += btnTabRole_Click;
            cboPrivType.SelectedIndexChanged += cboPrivType_SelectedIndexChanged;
            cboObjType.SelectedIndexChanged += cboObjType_SelectedIndexChanged;

            // Tạo ô tìm kiếm trên Grid Quyền programmatically
            txtSearchDGV = new Guna.UI2.WinForms.Guna2TextBox();
            txtSearchDGV.Name = "txtSearchDGV";
            txtSearchDGV.PlaceholderText = "Tìm kiếm quyền, đối tượng...";
            txtSearchDGV.Size = new Size(300, 36);
            txtSearchDGV.Location = new Point(pnlData.Width - txtSearchDGV.Width - 10, 10);
            txtSearchDGV.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtSearchDGV.BorderRadius = 8;
            txtSearchDGV.FillColor = Color.FromArgb(247, 250, 252);
            txtSearchDGV.BorderColor = Color.FromArgb(208, 228, 240);
            txtSearchDGV.Font = new Font("Segoe UI", 9F);
            txtSearchDGV.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtSearchDGV.FocusedState.BorderColor = Color.FromArgb(0, 120, 180); // Tông xanh dương của Xem quyền

            pnlData.Controls.Add(txtSearchDGV);
            txtSearchDGV.BringToFront();

            txtSearchDGV.TextChanged += TxtSearchDGV_TextChanged;

            // Co giãn DGV tự động
            dgvPrivileges.Location = new Point(9, 52);
            dgvPrivileges.Size = new Size(pnlData.Width - 18, pnlData.Height - 62);
            dgvPrivileges.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            this.Load += ucViewPrivilege_Load;
        }

        // ===================================================
        // KHỞI TẠO KHI LOAD TRANG
        // ===================================================
        private void ucViewPrivilege_Load(object sender, EventArgs e)
        {
            StyleDataGridView();

            // Mặc định tab "User" active khi mới vào
            btnSubUser.Checked = true;
            btnSubRole.Checked = false;

            // Mặc định tab quyền là Object Privilege
            SetActiveTab(btnTabObjPriv);
            SetupColumns("OBJ");

            // Load danh sách — SelectedIndexChanged sẽ tự kích hoạt
            // cập nhật cột 2 vì event đã được wire trước đó
            LoadMockUsers();
        }

        // ===================================================
        // STYLE DATAGRIDVIEW — định dạng bảng hiển thị quyền
        // ===================================================
        private void StyleDataGridView()
        {
            dgvPrivileges.EnableHeadersVisualStyles = false;
            dgvPrivileges.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(210, 241, 245);
            dgvPrivileges.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(0, 120, 180);
            dgvPrivileges.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11f, FontStyle.Bold);
            dgvPrivileges.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(210, 241, 245);
            dgvPrivileges.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(0, 120, 180);
            dgvPrivileges.ColumnHeadersHeight = 46;
            dgvPrivileges.DefaultCellStyle.SelectionBackColor = Color.FromArgb(232, 244, 251);
            dgvPrivileges.DefaultCellStyle.SelectionForeColor = Color.FromArgb(10, 42, 64);
            dgvPrivileges.DefaultCellStyle.Font = new Font("Segoe UI", 10.5f);
            dgvPrivileges.GridColor = Color.FromArgb(244, 247, 250);
            dgvPrivileges.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(249, 251, 253);
            dgvPrivileges.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPrivileges.AllowUserToAddRows = false;
            dgvPrivileges.ReadOnly = true;
            dgvPrivileges.RowHeadersVisible = false;
            dgvPrivileges.MultiSelect = false;
            dgvPrivileges.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        // ===================================================
        // SETUP CỘT DATAGRIDVIEW THEO LOẠI TAB ĐANG CHỌN
        // OBJ = Object Privilege, SYS = System Privilege, ROLE = Role
        // ===================================================
        private void SetupColumns(string tabType)
        {
            _currentTab = tabType;
            if (txtSearchDGV != null) txtSearchDGV.Text = ""; // Reset tìm kiếm DGV khi chuyển tab
            dgvPrivileges.Columns.Clear();

            switch (tabType)
            {
                case "OBJ":
                    dgvPrivileges.Columns.Add(new DataGridViewTextBoxColumn { Name = "colObj", HeaderText = "Đối tượng", FillWeight = 20 });
                    dgvPrivileges.Columns.Add(new DataGridViewTextBoxColumn { Name = "colType", HeaderText = "Loại", FillWeight = 16 });
                    dgvPrivileges.Columns.Add(new DataGridViewTextBoxColumn { Name = "colPriv", HeaderText = "Quyền", FillWeight = 12 });
                    dgvPrivileges.Columns.Add(new DataGridViewTextBoxColumn { Name = "colCols", HeaderText = "Cột giới hạn", FillWeight = 22 });
                    dgvPrivileges.Columns.Add(new DataGridViewTextBoxColumn { Name = "colGrant", HeaderText = "Grant Option", FillWeight = 18 });
                    dgvPrivileges.Columns.Add(new DataGridViewTextBoxColumn { Name = "colGrantor", HeaderText = "Grantor", FillWeight = 18 });
                    break;

                case "SYS":
                    dgvPrivileges.Columns.Add(new DataGridViewTextBoxColumn { Name = "colSysPriv", HeaderText = "System Privilege", FillWeight = 50 });
                    dgvPrivileges.Columns.Add(new DataGridViewTextBoxColumn { Name = "colAdmin", HeaderText = "Admin Option", FillWeight = 25 });
                    dgvPrivileges.Columns.Add(new DataGridViewTextBoxColumn { Name = "colGrantor", HeaderText = "Grantor", FillWeight = 25 });
                    break;

                case "ROLE":
                    dgvPrivileges.Columns.Add(new DataGridViewTextBoxColumn { Name = "colRole", HeaderText = "Role", FillWeight = 40 });
                    dgvPrivileges.Columns.Add(new DataGridViewTextBoxColumn { Name = "colAdmin", HeaderText = "Admin Option", FillWeight = 30 });
                    dgvPrivileges.Columns.Add(new DataGridViewTextBoxColumn { Name = "colDefault", HeaderText = "Default Role", FillWeight = 30 });
                    break;
            }

            // Load dữ liệu nếu đang có user đang chọn
            if (lstUsers.SelectedIndex >= 0)
            {
                var user = lstUsers.Items[lstUsers.SelectedIndex] as UserItem;
                if (user != null) LoadPrivilegesForUser(user.Name, tabType);
            }
        }

        // ===================================================
        // LOAD USERS TỪ DATABASE — USP_LIST_USERS
        // Lấy danh sách users từ Oracle DBA_USERS
        // ===================================================
        private void LoadMockUsers()
        {
            lstUsers.Items.Clear();

            try
            {
                var param = new OracleParameter[] {
                    new OracleParameter("p_cursor", OracleDbType.RefCursor) { Direction = ParameterDirection.Output }
                };

                DataTable dt = DataProvider.Instance.ExecuteQuery("USP_LIST_USERS", param);

                Color[] colors = { Color.FromArgb(0, 120, 180), Color.BlueViolet, Color.Orange, Color.SlateGray };

                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        string username = row["USERNAME"]?.ToString() ?? "";
                        string status = row["ACCOUNT_STATUS"]?.ToString() ?? "";

                        // Chỉ hiển thị user OPEN (không bị khóa)
                        if (status != "OPEN") continue;

                        // Lấy role của user
                        string userRole = GetUserRoleFromDb(username);
                        if (string.IsNullOrEmpty(userRole)) userRole = "USER";

                        // Lấy số lượng quyền object privilege
                        int privCount = GetUserPrivilegeCount(username);

                        // Chọn màu dựa trên role
                        Color color;
                        if (userRole.Contains("BACSI")) color = Color.FromArgb(0, 120, 180);
                        else if (userRole.Contains("DIEUPHOIVIEN")) color = Color.BlueViolet;
                        else if (userRole.Contains("KYTHUATVIEN")) color = Color.Orange;
                        else color = Color.SlateGray;

                        _allUsers.Add(new UserItem(username, userRole, privCount, color));
                    }
                }

                ApplyUserFilter();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh sách users: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===================================================
        // LOAD ROLES TỪ DATABASE — USP_LIST_ROLES
        // Lấy danh sách roles từ Oracle DBA_ROLES
        // ===================================================
        private void LoadMockRoles()
        {
            lstUsers.Items.Clear();

            try
            {
                var param = new OracleParameter[] {
                    new OracleParameter("p_cursor", OracleDbType.RefCursor) { Direction = ParameterDirection.Output }
                };

                DataTable dt = DataProvider.Instance.ExecuteQuery("USP_LIST_ROLES", param);

                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        string roleName = row["ROLE"]?.ToString() ?? "";

                        // Lấy số lượng members (users gán vào role này)
                        int memberCount = GetRoleMemberCount(roleName);

                        // Lấy số lượng quyền của role
                        int privCount = GetRolePrivilegeCount(roleName);

                        // Chọn màu dựa trên tên role
                        Color color;
                        if (roleName.Contains("BACSI")) color = Color.FromArgb(0, 120, 180);
                        else if (roleName.Contains("DIEUPHOIVIEN")) color = Color.BlueViolet;
                        else if (roleName.Contains("KYTHUATVIEN")) color = Color.Orange;
                        else color = Color.SlateGray;

                        _allRoles.Add(new UserItem(roleName, "Role", privCount, color));
                    }
                }

                ApplyUserFilter();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh sách roles: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===================================================
        // LOAD QUYỀN CỦA USER/ROLE TỪNG TAB
        // OBJ  → FN_GET_OBJ_PRIVS(p_grantee) hoặc query DBA_TAB_PRIVS
        // SYS  → FN_GET_SYS_PRIVS(p_grantee) hoặc query DBA_SYS_PRIVS
        // ROLE → FN_GET_ROLE_PRIVS(p_grantee) hoặc query DBA_ROLE_PRIVS
        // ===================================================
        private void LoadPrivilegesForUser(string username, string tabType)
        {
            dgvPrivileges.Rows.Clear();

            try
            {
                if (tabType == "OBJ")
                {
                    LoadObjectPrivileges(username);
                }
                else if (tabType == "SYS")
                {
                    LoadSystemPrivileges(username);
                }
                else if (tabType == "ROLE")
                {
                    LoadRolePrivileges(username);
                }

                // Cập nhật stat pills sau khi load xong
                UpdateStatPills(username);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải quyền: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===================================================
        // LOAD OBJECT PRIVILEGES — quyền trên TABLE/VIEW/PROCEDURE
        // Dùng USP_GET_OBJ_PRIVS từ HospitalX_PH1.sql
        // Gồm cả quyền mức bảng (DBA_TAB_PRIVS) + cột (DBA_COL_PRIVS)
        // ===================================================
        private void LoadObjectPrivileges(string grantee)
        {
            try
            {
                // Lọc theo loại đối tượng từ combo (chỉ áp dụng cho tab OBJ)
                string filterObjType = cboObjType.SelectedItem?.ToString() ?? "Tất cả đối tượng";

                // Gọi USP_GET_OBJ_PRIVS từ SQL script
                var param = new OracleParameter[] {
                    new OracleParameter("p_grantee", OracleDbType.Varchar2) { Value = grantee },
                    new OracleParameter("p_result", OracleDbType.RefCursor) { Direction = ParameterDirection.Output }
                };

                DataTable dt = DataProvider.Instance.ExecuteQuery("USP_GET_OBJ_PRIVS", param);

                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        string objectName = row["OBJECT_NAME"]?.ToString() ?? "";
                        string objectType = row["TYPE"]?.ToString() ?? "TABLE";
                        string privilege = row["PRIVILEGE"]?.ToString() ?? "";
                        string columnName = row["COLUMN_NAME"]?.ToString() ?? "ALL COLUMN";
                        string grantOption = row["GRANT_OPTION"]?.ToString() ?? "NO";
                        string grantor = row["GRANTOR"]?.ToString() ?? "";

                        // Lọc theo loại object nếu được chọn
                        if (filterObjType != "Tất cả đối tượng" && objectType != filterObjType)
                            continue;

                        // Nếu cột là "ALL COLUMN" thì hiển thị "Tất cả cột", ngược lại hiển thị tên cột
                        string columnInfo = columnName == "ALL COLUMN" ? "Tất cả cột" : columnName;

                        int idx = dgvPrivileges.Rows.Add(objectName, objectType, privilege, columnInfo, grantOption, grantor);
                        var dgvRow = dgvPrivileges.Rows[idx];

                        // Màu chữ cột "Quyền" theo loại privilege
                        Color privColor;
                        switch (privilege)
                        {
                            case "SELECT": privColor = Color.FromArgb(22, 163, 74); break;
                            case "UPDATE": privColor = Color.FromArgb(234, 179, 8); break;
                            case "INSERT": privColor = Color.FromArgb(59, 130, 246); break;
                            case "DELETE": privColor = Color.FromArgb(239, 68, 68); break;
                            case "EXECUTE": privColor = Color.FromArgb(124, 58, 237); break;
                            default: privColor = Color.FromArgb(10, 42, 64); break;
                        }
                        dgvRow.Cells["colPriv"].Style.ForeColor = privColor;
                        dgvRow.Cells["colPriv"].Style.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);

                        // Màu cột "Grant Option": xanh = YES, đỏ = NO
                        dgvRow.Cells["colGrant"].Style.ForeColor = grantOption == "YES"
                            ? Color.FromArgb(22, 163, 74)
                            : Color.FromArgb(220, 38, 38);
                        dgvRow.Cells["colGrant"].Style.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("LoadObjectPrivileges error: " + ex.Message);
            }
        }

        // ===================================================
        // LOAD SYSTEM PRIVILEGES — quyền hệ thống
        // Không có procedure riêng, query trực tiếp DBA_SYS_PRIVS
        // ===================================================
        private void LoadSystemPrivileges(string grantee)
        {
            try
            {
                // Gọi stored procedure thay vì raw SQL (đẩy nghiệp vụ xuống Oracle)
                var parameters = new OracleParameter[] {
                    new OracleParameter("p_grantee", OracleDbType.Varchar2) { Value = grantee },
                    new OracleParameter("p_cursor", OracleDbType.RefCursor) { Direction = ParameterDirection.Output }
                };

                DataTable dt = DataProvider.Instance.ExecuteQuery("USP_GET_SYS_PRIVS", parameters, isStoredProc: true);

                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        string privilege = row["PRIVILEGE"]?.ToString() ?? "";
                        string adminOption = row["ADMIN_OPTION"]?.ToString() ?? "NO";

                        dgvPrivileges.Rows.Add(privilege, adminOption, "SYS");

                        // Màu admin option
                        int idx = dgvPrivileges.Rows.Count - 1;
                        var dgvRow = dgvPrivileges.Rows[idx];
                        dgvRow.Cells["colAdmin"].Style.ForeColor = adminOption == "YES"
                            ? Color.FromArgb(22, 163, 74)
                            : Color.FromArgb(220, 38, 38);
                        dgvRow.Cells["colAdmin"].Style.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("LoadSystemPrivileges error: " + ex.Message);
            }
        }

        // ===================================================
        // LOAD ROLE PRIVILEGES — các role được gán cho user/role
        // Dùng USP_GET_ROLE_PRIVS từ HospitalX_PH1.sql
        // ===================================================
        private void LoadRolePrivileges(string grantee)
        {
            try
            {
                // Gọi USP_GET_ROLE_PRIVS từ SQL script
                var param = new OracleParameter[] {
                    new OracleParameter("p_grantee", OracleDbType.Varchar2) { Value = grantee },
                    new OracleParameter("p_result", OracleDbType.RefCursor) { Direction = ParameterDirection.Output }
                };

                DataTable dt = DataProvider.Instance.ExecuteQuery("USP_GET_ROLE_PRIVS", param);

                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        string roleName = row["GRANTED_ROLE"]?.ToString() ?? "";
                        string adminOption = row["ADMIN_OPTION"]?.ToString() ?? "NO";
                        string defaultRole = row["DEFAULT_ROLE"]?.ToString() ?? "NO";

                        dgvPrivileges.Rows.Add(roleName, adminOption, defaultRole);

                        // Màu admin option và default role
                        int idx = dgvPrivileges.Rows.Count - 1;
                        var dgvRow = dgvPrivileges.Rows[idx];

                        dgvRow.Cells["colAdmin"].Style.ForeColor = adminOption == "YES"
                            ? Color.FromArgb(22, 163, 74)
                            : Color.FromArgb(220, 38, 38);
                        dgvRow.Cells["colAdmin"].Style.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);

                        dgvRow.Cells["colDefault"].Style.ForeColor = defaultRole == "YES"
                            ? Color.FromArgb(22, 163, 74)
                            : Color.FromArgb(220, 38, 38);
                        dgvRow.Cells["colDefault"].Style.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("LoadRolePrivileges error: " + ex.Message);
            }
        }

        // ===================================================
        // CẬP NHẬT HEADER CỘT 2 — avatar, tên, role, số quyền
        // Gọi mỗi khi user/role được chọn từ danh sách
        // ===================================================
        private void UpdateDetailHeader(UserItem item)
        {
            if (item == null) return;

            // Avatar + màu
            pnlDetailAvatar.FillColor = item.Color;
            lblAvatarText.Text = item.Name.Length >= 2
                                        ? item.Name.Substring(0, 2).ToUpper()
                                        : item.Name;

            // Tên và role
            lblDetailName.Text = item.Name;
            lblDetailRole.Text = item.RoleName + " · Active";
        }

        // ===================================================
        // CẬP NHẬT STAT PILLS — số quyền object/system/role
        // Dùng USP_GET_OBJ_PRIVS, DBA_SYS_PRIVS, USP_GET_ROLE_PRIVS
        // QUAN TRỌNG: Đếm cả quyền mức bảng VÀ mức cột
        // ===================================================
        private void UpdateStatPills(string grantee)
        {
            try
            {
                // 1. Count Object Privileges (cộng cả table-level và column-level)
                var paramObjPriv = new OracleParameter[] {
                    new OracleParameter("p_grantee", OracleDbType.Varchar2) { Value = grantee },
                    new OracleParameter("p_result", OracleDbType.RefCursor) { Direction = ParameterDirection.Output }
                };
                DataTable dtObjPriv = DataProvider.Instance.ExecuteQuery("USP_GET_OBJ_PRIVS", paramObjPriv);
                int objPrivCount = dtObjPriv?.Rows.Count ?? 0;

                // 2. Count System Privileges (gọi stored procedure thay vì raw SQL)
                var paramSysPrivCount = new OracleParameter[] {
                    new OracleParameter("p_grantee", OracleDbType.Varchar2) { Value = grantee },
                    new OracleParameter("p_count", OracleDbType.Decimal) { Direction = ParameterDirection.Output }
                };
                DataProvider.Instance.ExecuteNonQuery("USP_COUNT_SYS_PRIVS", paramSysPrivCount, true);
                int sysPrivCount = 0;
                if (paramSysPrivCount[1].Value != null && paramSysPrivCount[1].Value != DBNull.Value)
                {
                    if (int.TryParse(paramSysPrivCount[1].Value.ToString(), out int cnt2))
                        sysPrivCount = cnt2;
                }

                // 3. Count Roles
                var paramRole = new OracleParameter[] {
                    new OracleParameter("p_grantee", OracleDbType.Varchar2) { Value = grantee },
                    new OracleParameter("p_result", OracleDbType.RefCursor) { Direction = ParameterDirection.Output }
                };
                DataTable dtRole = DataProvider.Instance.ExecuteQuery("USP_GET_ROLE_PRIVS", paramRole);
                int roleCount = dtRole?.Rows.Count ?? 0;

                lblObjPrivCount.Text = objPrivCount.ToString();
                lblSysPrivCount.Text = sysPrivCount.ToString();
                lblRoleCount.Text = roleCount.ToString();

                btnTabObjPriv.Text = $"Object Privileges ({objPrivCount})";
                btnTabSysPriv.Text = $"System Privileges ({sysPrivCount})";
                btnTabRole.Text = $"Roles được gán ({roleCount})";
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("UpdateStatPills error: " + ex.Message);
            }
        }

        // ===================================================
        // SỰ KIỆN: CHỌN USER/ROLE TỪ DANH SÁCH BÊN TRÁI
        // Cập nhật toàn bộ cột 2 khi user bấm vào 1 dòng
        // ===================================================
        private void LstUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstUsers.SelectedIndex < 0) return;
            var item = lstUsers.Items[lstUsers.SelectedIndex] as UserItem;
            if (item == null) return;

            // Reset DGV search box when selected user changes
            if (txtSearchDGV != null) txtSearchDGV.Text = "";

            // Cập nhật header (avatar, tên, role)
            UpdateDetailHeader(item);

            // Load lại bảng quyền cho user này theo tab hiện tại
            LoadPrivilegesForUser(item.Name, _currentTab);
        }

        // ===================================================
        // SỰ KIỆN: SWITCH TAB OBJECT / SYSTEM / ROLE
        // Đổi cột và tải lại dữ liệu tương ứng
        // ===================================================
        private void btnTabObjPriv_Click(object sender, EventArgs e)
        {
            SetActiveTab(btnTabObjPriv);
            SetupColumns("OBJ");
        }

        private void btnTabSysPriv_Click(object sender, EventArgs e)
        {
            SetActiveTab(btnTabSysPriv);
            SetupColumns("SYS");
        }

        private void btnTabRole_Click(object sender, EventArgs e)
        {
            SetActiveTab(btnTabRole);
            SetupColumns("ROLE");
        }

        // Hàm highlight nút tab đang active
        private void SetActiveTab(Guna.UI2.WinForms.Guna2Button active)
        {
            foreach (var t in new[] { btnTabObjPriv, btnTabSysPriv, btnTabRole })
            {
                t.FillColor = Color.White;
                t.ForeColor = ColorTranslator.FromHtml("#6A8FA8");
                t.BorderColor = ColorTranslator.FromHtml("#D0E4F0");
            }
            active.FillColor = ColorTranslator.FromHtml("#0078B4");
            active.ForeColor = Color.White;
            active.BorderColor = ColorTranslator.FromHtml("#0078B4");
        }

        // ===================================================
        // SỰ KIỆN: SWITCH SUB-TAB USER / ROLE BÊN CỘT TRÁI
        // ===================================================
        private void btnSubUser_Click(object sender, EventArgs e)
        {
            btnSubUser.Checked = true;
            btnSubRole.Checked = false;
            txtSearch.Text = ""; // Clear tìm kiếm user/role
            LoadMockUsers();
        }

        private void btnSubRole_Click(object sender, EventArgs e)
        {
            btnSubRole.Checked = true;
            btnSubUser.Checked = false;
            txtSearch.Text = ""; // Clear tìm kiếm user/role
            LoadMockRoles();
        }

        // ===================================================
        // SỰ KIỆN: COMBO FILTER LOẠI QUYỀN (Object/System/Role)
        // ===================================================
        private void cboPrivType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboPrivType.SelectedIndex)
            {
                case 1: btnTabObjPriv.PerformClick(); break;
                case 2: btnTabSysPriv.PerformClick(); break;
                case 3: btnTabRole.PerformClick(); break;
                default: btnTabObjPriv.PerformClick(); break;
            }
        }

        // ===================================================
        // SỰ KIỆN: COMBO FILTER LOẠI ĐỐI TƯỢNG (TABLE/VIEW...)
        // Chỉ có tác dụng khi đang ở tab Object Privilege
        // ===================================================
        private void cboObjType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstUsers.SelectedIndex < 0) return;
            var user = lstUsers.Items[lstUsers.SelectedIndex] as UserItem;
            if (user != null) LoadPrivilegesForUser(user.Name, _currentTab);
        }

        // ===================================================
        // SỰ KIỆN: TÌM KIẾM REALTIME TRÊN DANH SÁCH BÊN TRÁI
        // ===================================================
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyUserFilter();
        }

        private void ApplyUserFilter()
        {
            string kw = txtSearch.Text.Trim().ToLower();
            if (kw == "tìm username...") kw = "";

            lstUsers.SelectedIndexChanged -= LstUsers_SelectedIndexChanged;
            lstUsers.Items.Clear();

            var sourceList = btnSubUser.Checked ? _allUsers : _allRoles;
            foreach (var item in sourceList)
            {
                bool match = string.IsNullOrEmpty(kw)
                    || item.Name.ToLower().Contains(kw)
                    || item.RoleName.ToLower().Contains(kw);
                if (match)
                {
                    lstUsers.Items.Add(item);
                }
            }

            lstUsers.SelectedIndexChanged += LstUsers_SelectedIndexChanged;

            if (lstUsers.Items.Count > 0)
            {
                lstUsers.SelectedIndex = 0;
            }
            else
            {
                dgvPrivileges.Rows.Clear();
                lblObjPrivCount.Text = "0";
                lblSysPrivCount.Text = "0";
                lblRoleCount.Text = "0";
            }
        }

        // ===================================================
        // SỰ KIỆN: TÌM KIẾM REALTIME TRÊN GRID QUYỀN (BÊN PHẢI)
        // ===================================================
        private void TxtSearchDGV_TextChanged(object sender, EventArgs e)
        {
            string kw = txtSearchDGV.Text.Trim().ToLower();
            dgvPrivileges.CurrentCell = null; // Tránh lỗi CurrencyManager khi ẩn dòng đang được select
            foreach (DataGridViewRow row in dgvPrivileges.Rows)
            {
                bool match = false;
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null && cell.Value.ToString().ToLower().Contains(kw))
                    {
                        match = true;
                        break;
                    }
                }
                row.Visible = string.IsNullOrEmpty(kw) || match;
            }
        }

        // ===================================================
        // SỰ KIỆN: NÚT LÀM MỚI — reset filter và tải lại dữ liệu
        // ===================================================
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            if (txtSearchDGV != null) txtSearchDGV.Text = "";
            cboPrivType.SelectedIndex = 0;
            cboObjType.SelectedIndex = 0;

            // Reload lại danh sách theo sub-tab đang chọn
            if (btnSubUser.Checked) LoadMockUsers();
            else LoadMockRoles();
        }

        // ===================================================
        // OWNERDRAW — Vẽ từng dòng trong ListBox cột trái
        // ===================================================
        private void lstUsers_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            var item = lstUsers.Items[e.Index] as UserItem;
            if (item == null) return;

            e.DrawBackground();
            bool sel = (e.State & DrawItemState.Selected) != 0;

            // Nền row
            using (var bgBrush = new SolidBrush(sel ? Color.FromArgb(232, 244, 251) : Color.White))
                e.Graphics.FillRectangle(bgBrush, e.Bounds);

            // Viền khi selected
            if (sel)
                using (var pen = new Pen(Color.FromArgb(176, 212, 234), 1f))
                    e.Graphics.DrawRectangle(pen,
                        new Rectangle(e.Bounds.X + 1, e.Bounds.Y + 1,
                                      e.Bounds.Width - 2, e.Bounds.Height - 2));

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Avatar tròn
            var av = new Rectangle(e.Bounds.X + 10, e.Bounds.Y + 10, 32, 32);
            using (var avBrush = new SolidBrush(item.Color))
                e.Graphics.FillEllipse(avBrush, av);

            string avTxt = item.Name.Length >= 2 ? item.Name.Substring(0, 2).ToUpper() : item.Name;
            using (var fAv = new Font("Segoe UI", 8, FontStyle.Bold))
            using (var fmt = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                e.Graphics.DrawString(avTxt, fAv, Brushes.White, av, fmt);

            // Tên
            using (var fName = new Font("Segoe UI", 11, FontStyle.Bold))
            using (var bName = new SolidBrush(Color.FromArgb(10, 42, 64)))
                e.Graphics.DrawString(item.Name, fName, bName,
                    new Rectangle(e.Bounds.X + 52, e.Bounds.Y + 7, e.Bounds.Width - 80, 22));

            // Role
            using (var fRole = new Font("Segoe UI", 9))
            using (var bRole = new SolidBrush(Color.FromArgb(138, 168, 190)))
                e.Graphics.DrawString(item.RoleName, fRole, bRole,
                    new Rectangle(e.Bounds.X + 52, e.Bounds.Y + 28, e.Bounds.Width - 80, 18));

            // Badge số quyền góc phải
            var cntRect = new Rectangle(e.Bounds.Right - 36, e.Bounds.Y + 16, 28, 18);
            using (var bBadge = new SolidBrush(Color.FromArgb(232, 244, 251)))
                e.Graphics.FillRectangle(bBadge, cntRect);
            using (var fCnt = new Font("Segoe UI", 8.5f, FontStyle.Bold))
            using (var bCnt = new SolidBrush(Color.FromArgb(0, 120, 180)))
            using (var fmtC = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                e.Graphics.DrawString(item.PrivCount.ToString(), fCnt, bCnt, cntRect, fmtC);
        }

        // ===================================================
        // HELPER — Bật DoubleBuffer cho ListBox qua reflection
        // tránh nhấp nháy khi scroll danh sách dài
        // ===================================================
        private static void EnableListBoxDoubleBuffer(ListBox lb)
        {
            typeof(Control)
                .GetProperty("DoubleBuffered",
                    System.Reflection.BindingFlags.NonPublic |
                    System.Reflection.BindingFlags.Instance)
                ?.SetValue(lb, true, null);
        }

        // ===================================================
        // HELPER METHODS — các hàm hỗ trợ lấy dữ liệu từ DB
        // ===================================================

        /// <summary>
        /// Lấy role của user từ database (DBA_ROLE_PRIVS)
        /// Lấy role đầu tiên nếu user có multiple roles
        /// </summary>
        private string GetUserRoleFromDb(string username)
        {
            try
            {
                // Dùng stored procedure USP_GET_USER_ROLE từ SQL script
                var parameters = new OracleParameter[] {
                    new OracleParameter("p_username", OracleDbType.Varchar2) { Value = username },
                    new OracleParameter("p_cursor", OracleDbType.RefCursor) { Direction = ParameterDirection.Output }
                };
                DataTable dt = DataProvider.Instance.ExecuteQuery("USP_GET_USER_ROLE", parameters);
                if (dt != null && dt.Rows.Count > 0)
                    return dt.Rows[0][0]?.ToString() ?? "";
            }
            catch { }
            return "";
        }

        /// <summary>
        /// Lấy số lượng object privilege của user
        /// Đếm cả quyền mức bảng (DBA_TAB_PRIVS) + quyền mức cột (DBA_COL_PRIVS)
        /// bằng cách lấy số hàng từ USP_GET_OBJ_PRIVS
        /// </summary>
        private int GetUserPrivilegeCount(string username)
        {
            try
            {
                var parameters = new OracleParameter[] {
                    new OracleParameter("p_grantee", OracleDbType.Varchar2) { Value = username },
                    new OracleParameter("p_result", OracleDbType.RefCursor) { Direction = ParameterDirection.Output }
                };
                DataTable dt = DataProvider.Instance.ExecuteQuery("USP_GET_OBJ_PRIVS", parameters);
                return dt?.Rows.Count ?? 0;
            }
            catch { }
            return 0;
        }

        /// <summary>
        /// Lấy số lượng members của một role
        /// </summary>
        private int GetRoleMemberCount(string roleName)
        {
            try
            {
                var parameters = new OracleParameter[] {
                    new OracleParameter("p_role_name", OracleDbType.Varchar2) { Value = roleName },
                    new OracleParameter("p_cursor", OracleDbType.RefCursor) { Direction = ParameterDirection.Output }
                };
                DataTable dt = DataProvider.Instance.ExecuteQuery("USP_LIST_ROLE_MEMBERS", parameters);
                return dt?.Rows.Count ?? 0;
            }
            catch { }
            return 0;
        }

        /// <summary>
        /// Lấy số lượng quyền (object privilege) của một role
        /// Đếm cả quyền mức bảng + mức cột
        /// </summary>
        private int GetRolePrivilegeCount(string roleName)
        {
            try
            {
                var parameters = new OracleParameter[] {
                    new OracleParameter("p_grantee", OracleDbType.Varchar2) { Value = roleName },
                    new OracleParameter("p_result", OracleDbType.RefCursor) { Direction = ParameterDirection.Output }
                };
                DataTable dt = DataProvider.Instance.ExecuteQuery("USP_GET_OBJ_PRIVS", parameters);
                return dt?.Rows.Count ?? 0;
            }
            catch { }
            return 0;
        }

        // ===================================================
        // CLASS MODEL — đại diện cho 1 user/role trong ListBox
        // ===================================================
        public class UserItem
        {
            public string Name { get; set; }
            public string RoleName { get; set; }
            public int PrivCount { get; set; }
            public Color Color { get; set; }

            public UserItem(string name, string roleName, int privCount, Color color)
            {
                Name = name;
                RoleName = roleName;
                PrivCount = privCount;
                Color = color;
            }

            public override string ToString() => Name;
        }
    }
}