using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace HospitalX
{
    // Trang Dashboard tổng quan — hiện thị các thống kê nhanh
    // và phân bố user theo role khi DBA mới đăng nhập vào app
    public partial class ucDashboard : UserControl
    {
        // Chuỗi kết nối Oracle dùng chung cho toàn trang
        private string _connectionString;

        public ucDashboard(string connStr)
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            _connectionString = connStr;
            this.Load += ucDashboard_Load;
        }

        // =====================================================
        // LOAD — chạy khi Dashboard được hiển thị lần đầu
        // Gọi tuần tự các hàm load để điền đầy đủ dữ liệu lên UI
        // =====================================================
        private void ucDashboard_Load(object sender, EventArgs e)
        {
            LoadDate();
            LoadStatCards();
            SetupAndLoadObjectList();
            LoadRoleDistribution();
        }

        // ================================================
        // NGÀY HIỆN TẠI VÀO PILL
        // Hiện ngày hôm nay ở góc phải phần header Dashboard
        // ================================================
        private void LoadDate()
        {
            lblDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        // ================================================
        // MOCK DATA — 4 STAT CARDS
        // Hiển thị 4 con số thống kê nhanh ở hàng trên cùng
        // Sau này thay bằng query Oracle:
        //   lblUserCount : SELECT COUNT(*) FROM DBA_USERS (lọc user hệ thống)
        //   lblRoleCount : SELECT COUNT(*) FROM DBA_ROLES
        //   lblPriCount  : SELECT COUNT(*) FROM DBA_TAB_PRIVS WHERE OWNER='BVDBA'
        //   lblDBCount   : SELECT COUNT(*) FROM DBA_OBJECTS WHERE OWNER='BVDBA'
        //                  AND OBJECT_TYPE IN ('TABLE','VIEW','PROCEDURE','FUNCTION')
        // ================================================
        private void LoadStatCards()
        {
            lblUserCount.Text = "5";   // MOCK: U_BACSI01, U_BACSI02, U_DPV01, U_KTV01, U_BN01
            lblRoleCount.Text = "4";   // MOCK: ROLE_BACSI, ROLE_DIEUPHOIVIEN, ROLE_KYTHUATVIEN, ROLE_BENHNHAN
            lblPriCount.Text = "12";  // MOCK: tổng số object privilege đã cấp trên schema BVDBA
            lblDBCount.Text = "11";  // MOCK: 5 TABLE + 2 VIEW + 2 PROC + 2 FUNCTION
        }

        // ================================================
        // MOCK DATA — LISTVIEW ĐỐI TƯỢNG DB (pnlObjCard)
        // Hiển thị danh sách các đối tượng trong schema BVDBA
        // kèm icon phân loại và số quyền đã cấp trên mỗi object
        // Dùng OwnerDraw để vẽ icon + tên + loại + số quyền
        // Sau này thay bằng query:
        //   SELECT o.OBJECT_NAME, o.OBJECT_TYPE, COUNT(p.PRIVILEGE) AS SO_QUYEN
        //   FROM DBA_OBJECTS o
        //   LEFT JOIN DBA_TAB_PRIVS p ON p.TABLE_NAME = o.OBJECT_NAME AND p.OWNER = 'BVDBA'
        //   WHERE o.OWNER = 'BVDBA'
        //   AND o.OBJECT_TYPE IN ('TABLE','VIEW','PROCEDURE','FUNCTION')
        //   GROUP BY o.OBJECT_NAME, o.OBJECT_TYPE ORDER BY o.OBJECT_TYPE, o.OBJECT_NAME
        // ================================================
        private void SetupAndLoadObjectList()
        {
            // --- Setup OwnerDraw ---
            // Dùng SmallImageList với chiều cao lớn để tăng row height
            lvObjects.SmallImageList = new ImageList { ImageSize = new Size(1, 62) };
            lvObjects.OwnerDraw = true;
            lvObjects.HeaderStyle = ColumnHeaderStyle.None;
            lvObjects.GridLines = false;

            // Điều chỉnh độ rộng cột: ẩn cột "Loại" (vẽ như subtitle dưới tên)
            columnHeader1.Width = lvObjects.Width - 120;  // cột tên (rộng)
            columnHeader2.Width = 0;                      // ẩn cột "Loại"
            columnHeader3.Width = 110;                    // cột số quyền

            lvObjects.DrawColumnHeader += (s, e) => { };  // không vẽ header
            lvObjects.DrawItem += (s, e) => { };  // DrawSubItem xử lý hết
            lvObjects.DrawSubItem += LvObjects_DrawSubItem;

            // --- Load mock data ---
            lvObjects.Items.Clear();

            // MOCK: (Tên object, Loại, Số quyền đã cấp)
            var mockObjects = new[]
            {
                ("NHANVIEN",          "TABLE",     "8 quyền"),
                ("BENHNHAN",          "TABLE",     "6 quyền"),
                ("HSBA",              "TABLE",     "5 quyền"),
                ("HSBA_DV",           "TABLE",     "3 quyền"),
                ("DONTHUOC",          "TABLE",     "4 quyền"),
                ("V_BENHNHAN_BASIC",  "VIEW",      "4 quyền"),
                ("V_HSBA_SUMMARY",    "VIEW",      "2 quyền"),
                ("SP_THEM_BENHNHAN",  "PROCEDURE", "3 quyền"),
                ("SP_CAP_NHAT_HSBA",  "PROCEDURE", "1 quyền"),
                ("FN_DEM_BENHNHAN",   "FUNCTION",  "1 quyền"),
                ("FN_TEN_BENHNHAN",   "FUNCTION",  "1 quyền"),
            };

            foreach (var (ten, loai, soQuyen) in mockObjects)
            {
                var item = new ListViewItem(ten);
                item.SubItems.Add(loai);
                item.SubItems.Add(soQuyen);
                lvObjects.Items.Add(item);
            }
        }

        // =====================================================
        // VẼ TỪNG Ô TRONG LISTVIEW (OwnerDraw)
        // Cột 0: icon bo góc + tên object + loại (subtitle)
        // Cột 2: số quyền căn phải màu xanh
        // =====================================================
        private void LvObjects_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            string type = e.Item.SubItems.Count > 1 ? e.Item.SubItems[1].Text : "";
            string count = e.Item.SubItems.Count > 2 ? e.Item.SubItems[2].Text : "";
            Color objColor = GetObjectColor(type);

            // Nền row
            bool selected = e.Item.Selected && lvObjects.Focused;
            using (var bg = new SolidBrush(selected ? Color.FromArgb(232, 244, 251) : Color.White))
                g.FillRectangle(bg, e.Bounds);

            if (e.ColumnIndex == 0)
            {
                // --- Icon bo góc ---
                int iconSize = 40;
                int iconX = e.Bounds.X + 12;
                int iconY = e.Bounds.Y + (e.Bounds.Height - iconSize) / 2;
                var iconRect = new Rectangle(iconX, iconY, iconSize, iconSize);

                // Nền icon màu nhạt
                DrawRoundedRect(g, iconRect, 10, Color.FromArgb(28, objColor.R, objColor.G, objColor.B));

                // Ký hiệu icon
                string sym = GetObjectSymbol(type);
                using (var f = new Font("Segoe UI", 13))
                using (var b = new SolidBrush(objColor))
                {
                    var fmt = new StringFormat
                    { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                    g.DrawString(sym, f, b, iconRect, fmt);
                }

                // Tên object (in đậm)
                int textX = iconX + iconSize + 14;
                using (var f = new Font("Segoe UI", 10, FontStyle.Bold))
                using (var b = new SolidBrush(Color.FromArgb(10, 42, 64)))
                    g.DrawString(e.Item.Text, f, b, new PointF(textX, e.Bounds.Y + 11));

                // Loại (chữ nhỏ xám bên dưới)
                using (var f = new Font("Segoe UI", 8.5f))
                using (var b = new SolidBrush(Color.FromArgb(138, 168, 190)))
                    g.DrawString(type, f, b, new PointF(textX, e.Bounds.Y + 33));

                // Đường phân cách (trừ dòng cuối)
                if (e.Item.Index < lvObjects.Items.Count - 1)
                {
                    using (var pen = new Pen(Color.FromArgb(22, 0, 0, 0), 0.5f))
                        g.DrawLine(pen, e.Bounds.X + 12, e.Bounds.Bottom - 1,
                                        e.Bounds.X + lvObjects.ClientSize.Width - 12, e.Bounds.Bottom - 1);
                }
            }
            else if (e.ColumnIndex == 2) // Cột số quyền
            {
                using (var f = new Font("Segoe UI", 9.5f, FontStyle.Bold))
                using (var b = new SolidBrush(Color.FromArgb(0, 120, 180)))
                {
                    var fmt = new StringFormat
                    { Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Center };
                    var rect = new RectangleF(e.Bounds.X, e.Bounds.Y, e.Bounds.Width - 10, e.Bounds.Height);
                    g.DrawString(count, f, b, rect, fmt);
                }
            }
        }

        // =====================================================
        // TRẢ VỀ MÀU TƯƠNG ỨNG THEO LOẠI OBJECT
        // Dùng để tô màu icon và chữ cho từng loại đối tượng DB
        // =====================================================
        private static Color GetObjectColor(string type)
        {
            switch (type)
            {
                case "TABLE": return Color.FromArgb(59, 130, 246);  // xanh dương
                case "VIEW": return Color.FromArgb(124, 58, 237);  // tím
                case "PROCEDURE": return Color.FromArgb(16, 185, 129);  // xanh lá
                case "FUNCTION": return Color.FromArgb(249, 115, 22);  // cam
                default: return Color.FromArgb(100, 116, 139);  // xám
            }
        }

        // =====================================================
        // TRẢ VỀ KÝ HIỆU ICON THEO LOẠI OBJECT
        // Ký tự Unicode đơn giản, hiển thị bên trong icon bo góc
        // =====================================================
        private static string GetObjectSymbol(string type)
        {
            switch (type)
            {
                case "TABLE": return "⊟";
                case "VIEW": return "≡";
                case "PROCEDURE": return "▽";
                case "FUNCTION": return "f";
                default: return "○";
            }
        }

        // =====================================================
        // VẼ HÌNH CHỮ NHẬT BO GÓC — dùng GraphicsPath
        // Dùng để tạo nền icon bo góc cho mỗi row trong ListView
        // =====================================================
        private static void DrawRoundedRect(Graphics g, Rectangle rect, int r, Color fill)
        {
            using (var path = new GraphicsPath())
            {
                path.AddArc(rect.X, rect.Y, r * 2, r * 2, 180, 90);
                path.AddArc(rect.Right - r * 2, rect.Y, r * 2, r * 2, 270, 90);
                path.AddArc(rect.Right - r * 2, rect.Bottom - r * 2, r * 2, r * 2, 0, 90);
                path.AddArc(rect.X, rect.Bottom - r * 2, r * 2, r * 2, 90, 90);
                path.CloseFigure();
                using (var b = new SolidBrush(fill))
                    g.FillPath(b, path);
            }
        }

        // ================================================
        // MOCK DATA — PHÂN BỐ USER THEO ROLE (pnlRoleCard)
        // Hiển thị danh sách role kèm avatar viết tắt và số user
        // Dùng 3 FlowLayoutPanel song song: avatar | tên | đếm
        // Sau này thay bằng query:
        //   SELECT r.GRANTED_ROLE, COUNT(*) AS SO_USER
        //   FROM DBA_ROLE_PRIVS r
        //   JOIN DBA_USERS u ON u.USERNAME = r.GRANTEE
        //   WHERE r.GRANTED_ROLE IN ('ROLE_BACSI','ROLE_DIEUPHOIVIEN','ROLE_KYTHUATVIEN','ROLE_BENHNHAN')
        //   GROUP BY r.GRANTED_ROLE ORDER BY SO_USER DESC
        // ================================================
        private void LoadRoleDistribution()
        {
            // Xóa template cũ từ designer
            flpAvatar.Controls.Clear();
            flpName.Controls.Clear();
            flpCount.Controls.Clear();

            // MOCK: (Viết tắt, Tên hiển thị, Số user, Màu avatar)
            var mockRoles = new[]
            {
                ("BS", "Bác sĩ / Y sĩ",    2, Color.FromArgb(0,   120, 180)),
                ("ĐP", "Điều phối viên",    1, Color.FromArgb(124,  58, 237)),
                ("KT", "Kỹ thuật viên",     1, Color.FromArgb(249, 115,  22)),
                ("BN", "Bệnh nhân",         1, Color.FromArgb(100, 116, 139)),
            };

            // Tính tổng để hiện vào pill header (guna2Panel1)
            int total = 0;
            foreach (var r in mockRoles) total += r.Item3;

            // Pill tổng — hiện số user tổng ở góc phải header của card Role
            var lblTotal = new Label
            {
                Text = $"{total} user tổng",
                Font = new Font("Segoe UI", 8.5f, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 120, 180),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                BackColor = Color.Transparent,
            };
            pnlTongUser.Controls.Clear();
            pnlTongUser.FillColor = Color.FromArgb(232, 244, 251);
            pnlTongUser.Controls.Add(lblTotal);

            int rowHeight = 49;
            int rowGap = 6;

            foreach (var (abbr, displayName, soUser, mau) in mockRoles)
            {
                // --- Cột 1: Avatar pill có chữ viết tắt màu nền theo role ---
                var pill = new Guna.UI2.WinForms.Guna2Panel
                {
                    Size = new Size(49, 49),
                    BorderRadius = 10,
                    FillColor = mau,
                    Margin = new Padding(0, 0, 0, rowGap),
                };
                var lblAbbr = new Label
                {
                    Text = abbr,
                    Font = new Font("Segoe UI", 8.5f, FontStyle.Bold),
                    ForeColor = Color.White,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill,
                    BackColor = Color.Transparent,
                };
                pill.Controls.Add(lblAbbr);
                flpAvatar.Controls.Add(pill);

                // --- Cột 2: Tên hiển thị của role ---
                var namePanel = new Panel
                {
                    Width = flpName.Width - 4,
                    Height = rowHeight,
                    BackColor = Color.Transparent,
                    Margin = new Padding(0, 0, 0, rowGap),
                };
                var lblName = new Label
                {
                    Text = displayName,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    ForeColor = Color.FromArgb(10, 42, 64),
                    Location = new Point(0, (rowHeight - 20) / 2),
                    AutoSize = true,
                    BackColor = Color.Transparent,
                };
                namePanel.Controls.Add(lblName);
                flpName.Controls.Add(namePanel);

                // --- Cột 3: Số user thuộc role đó, căn phải ---
                var countPanel = new Panel
                {
                    Width = flpCount.Width - 4,
                    Height = rowHeight,
                    BackColor = Color.Transparent,
                    Margin = new Padding(0, 0, 0, rowGap),
                };
                var lblCount = new Label
                {
                    Text = $"{soUser} user",
                    Font = new Font("Segoe UI", 9.5f),
                    ForeColor = Color.FromArgb(138, 168, 190),
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleRight,
                    BackColor = Color.Transparent,
                };
                countPanel.Controls.Add(lblCount);
                flpCount.Controls.Add(countPanel);
            }
        }
    }
}