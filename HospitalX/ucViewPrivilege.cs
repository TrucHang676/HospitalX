// ============================================================
// ucViewPrivilege.cs
// Giao diện "Xem quyền" — cho phép DBA xem toàn bộ quyền
// của một User hoặc Role trong hệ thống Oracle.
// Gồm: danh sách user/role bên trái, chi tiết quyền bên phải.
// ============================================================
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace HospitalX
{
    public partial class ucViewPrivilege : UserControl
    {
        // ===================================================
        // KHAI BÁO BIẾN DÙNG CHUNG
        // ===================================================
        private string _connectionString;
        private string _currentTab = "OBJ"; // Tab đang chọn: OBJ / SYS / ROLE

        public ucViewPrivilege(string connStr)
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            _connectionString = connStr;

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
            dgvPrivileges.Columns.Clear();

            switch (tabType)
            {
                case "OBJ":
                    dgvPrivileges.Columns.Add(new DataGridViewTextBoxColumn { Name = "colObj", HeaderText = "Đối tượng", FillWeight = 20 });
                    dgvPrivileges.Columns.Add(new DataGridViewTextBoxColumn { Name = "colType", HeaderText = "Loại", FillWeight = 10 });
                    dgvPrivileges.Columns.Add(new DataGridViewTextBoxColumn { Name = "colPriv", HeaderText = "Quyền", FillWeight = 12 });
                    dgvPrivileges.Columns.Add(new DataGridViewTextBoxColumn { Name = "colCols", HeaderText = "Cột giới hạn", FillWeight = 28 });
                    dgvPrivileges.Columns.Add(new DataGridViewTextBoxColumn { Name = "colGrant", HeaderText = "Grant Option", FillWeight = 12 });
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
        // MOCK DATA — DANH SÁCH USER
        // Sau này thay bằng: SELECT * FROM FN_LIST_USERS()
        // ===================================================
        private void LoadMockUsers()
        {
            lstUsers.Items.Clear();
            lstUsers.Items.Add(new UserItem("U_BACSI01", "ROLE_BACSI", 6, Color.FromArgb(0, 120, 180)));
            lstUsers.Items.Add(new UserItem("U_BACSI02", "ROLE_BACSI", 4, Color.FromArgb(0, 120, 180)));
            lstUsers.Items.Add(new UserItem("U_DPV01", "ROLE_DIEUPHOIVIEN", 5, Color.BlueViolet));
            lstUsers.Items.Add(new UserItem("U_KTV01", "ROLE_KYTHUATVIEN", 3, Color.Orange));
            lstUsers.Items.Add(new UserItem("U_BN01", "ROLE_BENHNHAN", 2, Color.SlateGray));

            // Chọn dòng đầu → tự động kích hoạt LstUsers_SelectedIndexChanged
            // → cập nhật toàn bộ cột 2 (header + bảng quyền)
            lstUsers.SelectedIndex = 0;
        }

        // ===================================================
        // MOCK DATA — DANH SÁCH ROLE
        // Sau này thay bằng: SELECT * FROM FN_LIST_ROLES()
        // ===================================================
        private void LoadMockRoles()
        {
            lstUsers.Items.Clear();
            lstUsers.Items.Add(new UserItem("ROLE_BACSI", "Role", 8, Color.FromArgb(0, 120, 180)));
            lstUsers.Items.Add(new UserItem("ROLE_DIEUPHOIVIEN", "Role", 6, Color.BlueViolet));
            lstUsers.Items.Add(new UserItem("ROLE_KYTHUATVIEN", "Role", 4, Color.Orange));
            lstUsers.Items.Add(new UserItem("ROLE_BENHNHAN", "Role", 3, Color.SlateGray));

            lstUsers.SelectedIndex = 0;
        }

        // ===================================================
        // MOCK DATA — QUYỀN CỦA USER/ROLE THEO TỪNG TAB
        // Sau này thay bằng:
        //   OBJ  → FN_GET_OBJ_PRIVS(p_grantee)
        //   SYS  → FN_GET_SYS_PRIVS(p_grantee)
        //   ROLE → FN_GET_ROLE_PRIVS(p_grantee)
        // ===================================================
        private void LoadPrivilegesForUser(string username, string tabType)
        {
            dgvPrivileges.Rows.Clear();

            // Lọc theo loại đối tượng từ combo (chỉ áp dụng cho tab OBJ)
            string filterObjType = cboObjType.SelectedItem?.ToString() ?? "Tất cả đối tượng";

            if (tabType == "OBJ")
            {
                // MOCK: quyền object của user
                var mockData = new[]
                {
                    new[]{ "NHANVIEN",         "TABLE",     "SELECT",  "MANV, HOTEN",         "YES", "BVDBA" },
                    new[]{ "NHANVIEN",         "TABLE",     "UPDATE",  "SODT, QUEQUAN",        "NO",  "BVDBA" },
                    new[]{ "HSBA",             "TABLE",     "SELECT",  "Tất cả cột",           "YES", "BVDBA" },
                    new[]{ "HSBA",             "TABLE",     "UPDATE",  "CHANDOAN, DIEUTRI",    "NO",  "BVDBA" },
                    new[]{ "DONTHUOC",         "TABLE",     "INSERT",  "—",                   "NO",  "BVDBA" },
                    new[]{ "DONTHUOC",         "TABLE",     "DELETE",  "—",                   "NO",  "BVDBA" },
                    new[]{ "V_BENHNHAN_BASIC", "VIEW",      "SELECT",  "Tất cả cột",           "NO",  "BVDBA" },
                    new[]{ "SP_CAP_NHAT_HSBA", "PROCEDURE", "EXECUTE", "—",                   "NO",  "BVDBA" },
                };

                foreach (var d in mockData)
                {
                    // Áp dụng filter loại đối tượng nếu không phải "Tất cả"
                    if (filterObjType != "Tất cả đối tượng" && d[1] != filterObjType)
                        continue;

                    int idx = dgvPrivileges.Rows.Add(d[0], d[1], d[2], d[3], d[4], d[5]);
                    var row = dgvPrivileges.Rows[idx];

                    // Màu chữ cột "Quyền" theo loại privilege
                    Color privColor;
                    switch (d[2])
                    {
                        case "SELECT": privColor = Color.FromArgb(22, 163, 74); break;
                        case "UPDATE": privColor = Color.FromArgb(234, 179, 8); break;
                        case "INSERT": privColor = Color.FromArgb(59, 130, 246); break;
                        case "DELETE": privColor = Color.FromArgb(239, 68, 68); break;
                        case "EXECUTE": privColor = Color.FromArgb(124, 58, 237); break;
                        default: privColor = Color.FromArgb(10, 42, 64); break;
                    }
                    row.Cells["colPriv"].Style.ForeColor = privColor;
                    row.Cells["colPriv"].Style.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);

                    // Màu cột "Grant Option": xanh = YES, đỏ = NO
                    row.Cells["colGrant"].Style.ForeColor = d[4] == "YES"
                        ? Color.FromArgb(22, 163, 74)
                        : Color.FromArgb(220, 38, 38);
                    row.Cells["colGrant"].Style.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
                }
            }
            else if (tabType == "SYS")
            {
                // MOCK: system privilege
                dgvPrivileges.Rows.Add("CREATE SESSION", "NO", "BVDBA");
                dgvPrivileges.Rows.Add("CREATE TABLE", "YES", "SYS");
            }
            else if (tabType == "ROLE")
            {
                // MOCK: role được gán cho user
                dgvPrivileges.Rows.Add("ROLE_BACSI", "NO", "YES");
            }

            // Cập nhật stat pills sau khi load xong
            UpdateStatPills(username);
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
        // CẬP NHẬT 3 STAT PILL — số quyền object/system/role
        // Sau này thay bằng COUNT từ query thật
        // ===================================================
        private void UpdateStatPills(string username)
        {
            // MOCK: số quyền tương ứng từng loại
            // Sau này: SELECT COUNT(*) FROM DBA_TAB_PRIVS WHERE GRANTEE = :username
            lblObjPrivCount.Text = "6";
            lblSysPrivCount.Text = "1";
            lblRoleCount.Text = "1";

            // Cập nhật số lượng trên text của nút tab
            btnTabObjPriv.Text = "Object Privileges (6)";
            btnTabSysPriv.Text = "System Privileges (1)";
            btnTabRole.Text = "Roles được gán (1)";
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
            LoadMockUsers();
        }

        private void btnSubRole_Click(object sender, EventArgs e)
        {
            btnSubRole.Checked = true;
            btnSubUser.Checked = false;
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
        // SỰ KIỆN: TÌM KIẾM REALTIME TRÊN BẢNG QUYỀN
        // Lọc các dòng theo keyword nhập vào
        // ===================================================
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string kw = txtSearch.Text.Trim().ToLower();
            foreach (DataGridViewRow row in dgvPrivileges.Rows)
            {
                bool match = row.Cells.Cast<DataGridViewCell>()
                    .Any(c => c.Value?.ToString().ToLower().Contains(kw) == true);
                row.Visible = string.IsNullOrEmpty(kw) || match;
            }
        }

        // ===================================================
        // SỰ KIỆN: NÚT LÀM MỚI — reset filter và tải lại dữ liệu
        // ===================================================
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
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
            var av = new Rectangle(e.Bounds.X + 10, e.Bounds.Y + 8, 30, 30);
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
                    new Rectangle(e.Bounds.X + 48, e.Bounds.Y + 6, e.Bounds.Width - 80, 18));

            // Role
            using (var fRole = new Font("Segoe UI", 9))
            using (var bRole = new SolidBrush(Color.FromArgb(138, 168, 190)))
                e.Graphics.DrawString(item.RoleName, fRole, bRole,
                    new Rectangle(e.Bounds.X + 48, e.Bounds.Y + 24, e.Bounds.Width - 80, 16));

            // Badge số quyền góc phải
            var cntRect = new Rectangle(e.Bounds.Right - 36, e.Bounds.Y + 13, 28, 18);
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