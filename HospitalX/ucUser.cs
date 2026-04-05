using HospitalX.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace HospitalX
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
                        // Sau này gọi reload từ DB
                        ApplyFilters();
                    }
                }
            };

            // Nút Sửa thông tin → mở form frmEditUser với thông tin user đang chọn
            btnEditInfo.Click += (s, e) =>
            {
                if (lstUsers.SelectedItem is UserItem item)
                {
                    using (var f = new frmEditUser(item.Username, item.Role, item.FullName, item.Gender, item.Phone, item.BirthDate, item.Address))
                    {
                        if (f.ShowDialog() == DialogResult.OK)
                        {
                            // Cập nhật lại dữ liệu Mock
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
                            // Sau này gọi câu lệnh SQL ALTER USER ... IDENTIFIED BY ...
                            // MessageBox.Show("Đã đổi mật khẩu thành công (Mock)"); 
                            // Thông báo đã được thực hiện bên trong frmChangePassword rồi
                        }
                    }
                }
            };

            // Khi vùng footer phải thay đổi kích thước → căn giữa lại các nút
            pnlRightFooter.Resize += PnlRightFooter_Resize;

            LoadMockData();
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
            string keyword = txtSearch.Text.Trim().ToUpper();
            string roleFilter = cmbFilterRole.SelectedItem?.ToString() ?? "Tất cả role";
            string statusFilter = cmbFilterStatus.SelectedItem?.ToString() ?? "Tất cả trạng thái";

            _filteredUsers = _allUsers.FindAll(u =>
                (string.IsNullOrEmpty(keyword) || u.Username.ToUpper().Contains(keyword)) &&
                (roleFilter == "Tất cả role" || u.Role == roleFilter) &&
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
        // MOCK DATA — tạo danh sách user giả lập để demo giao diện
        // Sau này thay bằng truy vấn Oracle: SELECT * FROM DBA_USERS
        // ================================================
        private void LoadMockData()
        {
            _allUsers = new List<UserItem>();
            string[] roles = { "ROLE_BACSI", "ROLE_DPV", "ROLE_KTV", "ROLE_BN" };
            Color[] colors = { Color.FromArgb(41, 121, 255), Color.FromArgb(150, 100, 250), Color.FromArgb(250, 150, 50), Color.FromArgb(140, 150, 160) };

            for (int i = 1; i <= 12; i++)
            {
                string r = roles[(i - 1) % 4];
                string status = (i == 4 || i == 9) ? "Locked" : "Active";
                string code = i.ToString("D2");
                string username = $"U_USER{code}";
                string init = "U" + code;

                if (i == 1) { username = "U_BACSI01"; init = "BA"; }
                else if (i == 2) { username = "U_DPV01"; init = "DP"; }
                else if (i == 3) { username = "U_KTV01"; init = "KT"; }
                else if (i == 4) { username = "U_BN01"; init = "BN"; }
                else if (i == 5) { username = "U_BACSI02"; init = "B2"; }

                var u = new UserItem(username, r, status, "01/01/2026", i % 2 == 0 ? "SYSTEM" : "BENHVIEN_TBS", init, colors[(i - 1) % 4]);

                // Thêm dữ liệu giả lập chi tiết
                u.FullName = i % 2 == 0 ? "Nguyễn Văn " + code : "Trần Thị " + code;
                u.Phone = "090" + (1000000 + i);
                u.BirthDate = "15/05/199" + (i % 10);
                u.Address = i % 2 == 0 ? "123 Đường Lê Lợi, Quận 1, TP.HCM" : "456 Đường CMT8, Quận 3, TP.HCM";

                u.Privileges.Add(new UserPrivItem("NHANVIEN", "SELECT"));
                if (i % 3 == 0) u.Privileges.Add(new UserPrivItem("HSBA", "UPDATE"));

                _allUsers.Add(u);
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
                lblUserRole.Text = item.Role;

                pnlDetailsGrid.Controls.Clear();
                AddDetailRow("USERNAME", item.Username, 0);
                AddDetailRow("TRẠNG THÁI", item.Status, 30);
                AddDetailRow("NGÀY TẠO", item.CreateDate, 60);
                AddDetailRow("TABLESPACE", item.TableSpace, 90);

                lstDetails.Items.Clear();
                foreach (var p in item.Privileges) lstDetails.Items.Add(p);

                btnLockAccount.Text = (item.Status == "Active") ? "Khóa tài khoản" : "Mở khóa tài khoản";
            }
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
                bool isActive = val == "Active";
                Color bg = isActive ? Color.FromArgb(235, 250, 240) : Color.FromArgb(255, 240, 240);
                Color fg = isActive ? Color.FromArgb(46, 160, 67) : Color.FromArgb(220, 53, 69);

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

            // 1. Avatar — hình tròn màu với 2 chữ viết tắt
            var avatarRect = new Rectangle(e.Bounds.X + 15, e.Bounds.Y + 15, 30, 30);
            using (var avatarBrush = new SolidBrush(item.AvatarColor))
                e.Graphics.FillEllipse(avatarBrush, avatarRect);

            e.Graphics.DrawString(item.Initials, new Font("Segoe UI", 8, FontStyle.Bold), Brushes.White, avatarRect, new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });

            // 2. Username — tên tài khoản Oracle
            e.Graphics.DrawString(item.Username, new Font("Segoe UI", 10, FontStyle.Bold), new SolidBrush(Color.FromArgb(10, 42, 64)), e.Bounds.X + 55, e.Bounds.Y + 20);

            // 3. Role Badge — hiển thị role đang được gán
            var roleBadge = new Rectangle(e.Bounds.X + 180, e.Bounds.Y + 20, 90, 20);
            using (var badgeBrush = new SolidBrush(Color.FromArgb(240, 248, 255)))
                e.Graphics.FillRoundedRectangle(badgeBrush, roleBadge, 10);
            e.Graphics.DrawString(item.Role, new Font("Segoe UI", 8), new SolidBrush(Color.FromArgb(60, 100, 180)), roleBadge, new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });

            // 4. Status Badge — xanh nếu Active, đỏ nếu Locked
            var statusRect = new Rectangle(e.Bounds.X + 300, e.Bounds.Y + 20, 60, 20);
            bool isActive = item.Status == "Active";
            using (var statusBrush = new SolidBrush(isActive ? Color.FromArgb(235, 250, 240) : Color.FromArgb(255, 240, 240)))
                e.Graphics.FillRoundedRectangle(statusBrush, statusRect, 10);

            e.Graphics.DrawString(item.Status, new Font("Segoe UI", 8), new SolidBrush(isActive ? Color.FromArgb(46, 160, 67) : Color.FromArgb(220, 53, 69)), statusRect, new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });

            // 5. Create Date — ngày tạo tài khoản
            e.Graphics.DrawString(item.CreateDate, new Font("Segoe UI", 9), new SolidBrush(Color.FromArgb(100, 100, 100)), e.Bounds.X + 420, e.Bounds.Y + 20);

            // 6. Action Buttons — vẽ giả 2 nút Khóa/Mở khóa và Xóa (chỉ hiển thị, chưa có sự kiện click)
            var btnRect1 = new Rectangle(e.Bounds.X + 550, e.Bounds.Y + 15, 65, 26);
            var btnRect2 = new Rectangle(e.Bounds.X + 625, e.Bounds.Y + 15, 50, 26);

            using (var p1 = new Pen(Color.FromArgb(100, 150, 200)))
                e.Graphics.DrawRoundedRectangle(p1, btnRect1, 6);
            e.Graphics.DrawString(isActive ? "Khóa" : "Mở khóa", new Font("Segoe UI", 8), new SolidBrush(isActive ? Color.FromArgb(60, 120, 180) : Color.FromArgb(180, 130, 0)), btnRect1, new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });

            using (var p2 = new Pen(Color.FromArgb(255, 200, 200)))
                e.Graphics.DrawRoundedRectangle(p2, btnRect2, 6);
            e.Graphics.DrawString("Xóa", new Font("Segoe UI", 8), Brushes.Maroon, btnRect2, new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
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
    }

    // ================================================
    // MODEL: UserItem — đại diện cho 1 tài khoản Oracle
    // Chứa thông tin cơ bản (username, role, status, tablespace)
    // và thông tin bổ sung (họ tên, giới tính, SĐT, ngày sinh, địa chỉ)
    // ================================================
    public class UserItem
    {
        public string Username { get; set; }
        public string Role { get; set; }
        public string Status { get; set; }
        public string CreateDate { get; set; }
        public string TableSpace { get; set; }
        public string Initials { get; set; }
        public Color AvatarColor { get; set; }
        public List<UserPrivItem> Privileges { get; set; }

        // Additional Info
        public string FullName { get; set; } = "";
        public string Gender { get; set; } = "Nam";
        public string Phone { get; set; } = "";
        public string BirthDate { get; set; } = ""; // Đã đổi sang string
        public string Address { get; set; } = "";

        public UserItem(string u, string r, string s, string d, string t, string init, Color c)
        {
            Username = u; Role = r; Status = s; CreateDate = d; TableSpace = t; Initials = init; AvatarColor = c;
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