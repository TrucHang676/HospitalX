using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace HospitalX
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
            lstGrantees.ItemHeight = 46;
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

            StyleDataGridView();

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
        // LOAD DANH SÁCH USER / ROLE — hiện tại dùng mock data
        // Sau này thay bằng: FN_LIST_USERS() hoặc FN_LIST_ROLES()
        // ================================================
        private void LoadGrantees(string mode)
        {
            lstGrantees.Items.Clear();
            dgvCurrentPrivs.Rows.Clear();
            _currentGrantee = "";
            UpdateActionBar();

            if (mode == "USER")
            {
                lstGrantees.Items.Add(new GranteeItem("U_BACSI01", "ROLE_BACSI", Color.FromArgb(0, 120, 180)));
                lstGrantees.Items.Add(new GranteeItem("U_BACSI02", "ROLE_BACSI", Color.FromArgb(0, 120, 180)));
                lstGrantees.Items.Add(new GranteeItem("U_DPV01", "ROLE_DIEUPHOIVIEN", Color.BlueViolet));
                lstGrantees.Items.Add(new GranteeItem("U_KTV01", "ROLE_KYTHUATVIEN", Color.Orange));
                lstGrantees.Items.Add(new GranteeItem("U_KTV02", "ROLE_KYTHUATVIEN", Color.Orange));
                lstGrantees.Items.Add(new GranteeItem("U_BN01", "ROLE_BENHNHAN", Color.SlateGray));
            }
            else
            {
                lstGrantees.Items.Add(new GranteeItem("ROLE_BACSI", "4 users", Color.FromArgb(0, 120, 180)));
                lstGrantees.Items.Add(new GranteeItem("ROLE_DIEUPHOIVIEN", "1 user", Color.BlueViolet));
                lstGrantees.Items.Add(new GranteeItem("ROLE_KYTHUATVIEN", "2 users", Color.Orange));
                lstGrantees.Items.Add(new GranteeItem("ROLE_BENHNHAN", "1 user", Color.SlateGray));
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
                LoadMockPrivileges(item.Name);
                UpdateActionBar();
            }
        }

        // ================================================
        // MOCK DATA — QUYỀN ĐANG CÓ của từng user/role
        // Sau này thay bằng:
        //   FN_GET_OBJ_PRIVS(p_grantee)  → object privilege
        //   FN_GET_COL_PRIVS(p_grantee)  → column privilege
        //   FN_GET_ROLE_PRIVS(p_grantee) → role được gán
        // ================================================
        private readonly (string obj, string type, string priv, string cols, string grantOpt)[]
            _mockPrivsBacSi =
        {
            ("NHANVIEN",         "TABLE",     "SELECT",  "MANV, HOTEN, VAITRO",        "YES"),
            ("NHANVIEN",         "TABLE",     "UPDATE",  "SODT, CHUYENKHOA",           "NO"),
            ("HSBA",             "TABLE",     "SELECT",  "Tất cả cột",                 "YES"),
            ("HSBA",             "TABLE",     "UPDATE",  "CHANDOAN, DIEUTRI, KETLUAN", "NO"),
            ("HSBA",             "TABLE",     "INSERT",  "—",                          "NO"),
            ("DONTHUOC",         "TABLE",     "INSERT",  "—",                          "NO"),
            ("DONTHUOC",         "TABLE",     "UPDATE",  "TENTHUOC, LIEUDUNG",         "NO"),
            ("DONTHUOC",         "TABLE",     "DELETE",  "—",                          "NO"),
            ("V_BENHNHAN_BASIC",  "VIEW",      "SELECT",  "Tất cả cột",                 "NO"),
            ("SP_CAP_NHAT_HSBA",  "PROCEDURE", "EXECUTE", "—",                          "NO"),
        };

        private readonly (string obj, string type, string priv, string cols, string grantOpt)[]
            _mockPrivsDPV =
        {
            ("BENHNHAN", "TABLE", "SELECT", "Tất cả cột",   "NO"),
            ("BENHNHAN", "TABLE", "INSERT", "—",            "NO"),
            ("BENHNHAN", "TABLE", "UPDATE", "Tất cả cột",   "NO"),
            ("HSBA",     "TABLE", "INSERT", "—",            "NO"),
            ("HSBA",     "TABLE", "UPDATE", "MAKHOA, MABS", "NO"),
            ("HSBA_DV",  "TABLE", "UPDATE", "MAKTV",        "NO"),
        };

        private readonly (string obj, string type, string priv, string cols, string grantOpt)[]
            _mockPrivsKTV =
        {
            ("HSBA_DV", "TABLE", "SELECT", "Tất cả cột", "NO"),
            ("HSBA_DV", "TABLE", "UPDATE", "KETQUA",     "NO"),
        };

        private void LoadMockPrivileges(string grantee)
        {
            dgvCurrentPrivs.Rows.Clear();

            // Chọn bộ mock data phù hợp dựa vào tên grantee
            (string obj, string type, string priv, string cols, string grantOpt)[] data;
            if (grantee.Contains("BACSI")) data = _mockPrivsBacSi;
            else if (grantee.Contains("DPV") || grantee.Contains("DIEU")) data = _mockPrivsDPV;
            else if (grantee.Contains("KTV")) data = _mockPrivsKTV;
            else data = new[] { ("BENHNHAN", "TABLE", "SELECT", "Thông tin cá nhân", "NO") };

            foreach (var row in data)
            {
                int idx = dgvCurrentPrivs.Rows.Add();
                var r = dgvCurrentPrivs.Rows[idx];

                r.Cells[colSelect.Name].Value = false;
                r.Cells[colObject.Name].Value = row.obj;
                r.Cells[colObjType.Name].Value = row.type;
                r.Cells[colPrivilege.Name].Value = row.priv;
                r.Cells[colColumns.Name].Value = row.cols;
                r.Cells[colGrantOption.Name].Value = row.grantOpt;

                // Tô màu cột Quyền theo loại để dễ phân biệt
                Color privColor;
                switch (row.priv)
                {
                    case "SELECT": privColor = Color.FromArgb(13, 148, 136); break;
                    case "UPDATE": privColor = Color.FromArgb(217, 119, 6); break;
                    case "INSERT": privColor = Color.FromArgb(22, 163, 74); break;
                    case "DELETE": privColor = Color.FromArgb(220, 38, 38); break;
                    case "EXECUTE": privColor = Color.FromArgb(124, 58, 237); break;
                    default: privColor = Color.FromArgb(10, 42, 64); break;
                }
                r.Cells[colPrivilege.Name].Style.ForeColor = privColor;
                r.Cells[colPrivilege.Name].Style.Font = new Font("Segoe UI", 10f, FontStyle.Bold);

                // Tô màu cột Loại đối tượng
                Color typeColor;
                switch (row.type)
                {
                    case "VIEW": typeColor = Color.FromArgb(124, 58, 237); break;
                    case "PROCEDURE": typeColor = Color.FromArgb(22, 163, 74); break;
                    case "FUNCTION": typeColor = Color.FromArgb(249, 115, 22); break;
                    default: typeColor = Color.FromArgb(0, 120, 180); break;
                }
                r.Cells[colObjType.Name].Style.ForeColor = typeColor;
                r.Cells[colObjType.Name].Style.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);

                // Tô màu cột Grant Option: xanh = có thể cấp lại, xám = không
                r.Cells[colGrantOption.Name].Style.ForeColor = row.grantOpt == "YES"
                    ? Color.FromArgb(22, 163, 74)
                    : Color.FromArgb(156, 163, 175);
                r.Cells[colGrantOption.Name].Style.Font
                    = new Font("Segoe UI", 10f, FontStyle.Bold);
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
                    ? $"Thu hồi {checkedCount} quyền từ [{_currentGrantee}] →"
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
                row.Cells[colSelect.Name].Value = value;
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
        // THỰC HIỆN REVOKE — gom quyền đã tick, xác nhận, và xử lý
        // ================================================
        private void BtnRevoke_Click(object sender, EventArgs e)
        {
            // Gom danh sách các quyền được tick
            var toRevoke = new List<(string obj, string type, string priv)>();
            foreach (DataGridViewRow row in dgvCurrentPrivs.Rows)
            {
                if (row.Cells[colSelect.Name].Value as bool? != true) continue;
                toRevoke.Add((
                    row.Cells[colObject.Name].Value?.ToString() ?? "",
                    row.Cells[colObjType.Name].Value?.ToString() ?? "",
                    row.Cells[colPrivilege.Name].Value?.ToString() ?? ""
                ));
            }

            // Kiểm tra phòng trường hợp gọi khi chưa có gì được tick
            if (toRevoke.Count == 0)
            {
                MessageBox.Show(
                    "Bạn chưa chọn quyền nào để thu hồi.\nTick vào ô checkbox ở cột đầu tiên.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Hiển thị hộp thoại xác nhận với danh sách quyền sẽ bị thu hồi
            string list = "";
            foreach (var (obj, type, priv) in toRevoke)
                list += $"  •  {priv}  ON  {obj}  ({type})\n";

            var confirm = MessageBox.Show(
                $"Xác nhận thu hồi {toRevoke.Count} quyền từ [{_currentGrantee}]?\n\n"
                + list + "\nThao tác này KHÔNG THỂ hoàn tác!",
                "Xác nhận REVOKE",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            // ---- KẾT NỐI ORACLE: Thay phần mock bằng code thật ----
            // Mỗi quyền cần 1 lần gọi SP_REVOKE_OBJ_PRIV
            //
            // using var conn = new OracleConnection(_connectionString);
            // conn.Open();
            // foreach (var (obj, type, priv) in toRevoke)
            // {
            //     var cmd = new OracleCommand("SP_REVOKE_OBJ_PRIV", conn);
            //     cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //     cmd.Parameters.Add("p_privilege",    OracleDbType.Varchar2).Value = priv;
            //     cmd.Parameters.Add("p_object_owner", OracleDbType.Varchar2).Value = "BVDBA";
            //     cmd.Parameters.Add("p_object_name",  OracleDbType.Varchar2).Value = obj;
            //     cmd.Parameters.Add("p_grantee",      OracleDbType.Varchar2).Value = _currentGrantee;
            //     cmd.ExecuteNonQuery();
            // }
            // ---------------------------------------------------------

            // MOCK: xóa các dòng đã tick khỏi grid để giả lập revoke thành công
            for (int i = dgvCurrentPrivs.Rows.Count - 1; i >= 0; i--)
                if (dgvCurrentPrivs.Rows[i].Cells[colSelect.Name].Value as bool? == true)
                    dgvCurrentPrivs.Rows.RemoveAt(i);

            UpdateActionBar();

            MessageBox.Show(
                $"Đã thu hồi {toRevoke.Count} quyền từ [{_currentGrantee}] thành công!",
                "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            var av = new Rectangle(e.Bounds.X + 12, e.Bounds.Y + 8, 30, 30);
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
                new Rectangle(e.Bounds.X + 50, e.Bounds.Y + 6,
                              e.Bounds.Width - 70, 18));

            // Role hoặc số lượng user (dòng phụ)
            e.Graphics.DrawString(item.RoleName,
                new Font("Segoe UI", 9),
                new SolidBrush(Color.FromArgb(138, 168, 190)),
                new Rectangle(e.Bounds.X + 50, e.Bounds.Y + 24,
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
}