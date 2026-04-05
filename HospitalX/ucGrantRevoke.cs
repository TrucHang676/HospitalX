using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace HospitalX
{
    // Giao diện "Cấp quyền" (Grant) và "Thu hồi quyền" (Revoke)
    // Dùng 2 tab chuyển qua lại: tab Grant hiện 4 bước chọn lần lượt,
    // tab Revoke load ucRevoke vào panel phủ lên.
    public partial class ucGrantRevoke : UserControl
    {
        // Chuỗi kết nối Oracle dùng chung cho toàn trang
        private string _connectionString;
        // Tên object đang được chọn ở bước 2 (dùng để truyền vào ColPicker)
        private string _selectedObject = "NHANVIEN";

        // Lưu cột đã chọn riêng cho từng quyền
        private List<string> _selectCols = new List<string>();
        private List<string> _updateCols = new List<string>();

        // =====================================================
        // CONSTRUCTOR — khởi tạo, cấu hình ListBox và wire event
        // =====================================================
        public ucGrantRevoke(string connStr)
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            _connectionString = connStr;

            // Cấu hình ListBox cột 1 (User/Role): vẽ tay để hiển thị avatar + tên đẹp hơn
            lstGrantees.DrawMode = DrawMode.OwnerDrawFixed;
            lstGrantees.ItemHeight = 46;
            lstGrantees.DrawItem += LstGrantees_DrawItem;

            // Cấu hình ListBox cột 2 (Object): vẽ tay để hiển thị icon + tên + loại
            lstObjects.DrawMode = DrawMode.OwnerDrawFixed;
            lstObjects.ItemHeight = 46;
            lstObjects.DrawItem += lstObjects_DrawItem;

            this.Load += ucGrantRevoke_Load;

            // Nút mở ColPicker để chọn cột giới hạn cho quyền SELECT và UPDATE
            btnEditColSelect.Click += (s, e) => ShowColPicker("SELECT");
            btnEditColUpdate.Click += (s, e) => ShowColPicker("UPDATE");

            // Nút chuyển tab giữa Grant và Revoke
            btnTabGrant.Click += (s, e) => SwitchToGrant();
            btnRevoke.Click += (s, e) => SwitchToRevoke();

            // Nút làm mới — reset toàn bộ form về trạng thái ban đầu
            btnReset.Click += (s, e) => ResetAll();

            // ↓ QUAN TRỌNG: mọi tương tác đều gọi RefreshStepUI()
            // để cập nhật trạng thái các step button và lock/unlock cột
            lstGrantees.SelectedIndexChanged += (s, e) => RefreshStepUI();
            lstObjects.SelectedIndexChanged += (s, e) =>
            {
                // Cập nhật tên object đang chọn cho ColPicker
                if (lstObjects.SelectedItem is ObjectItem obj)
                    _selectedObject = obj.Name;
                RefreshStepUI();
            };

            // Các checkbox quyền: hiện/ẩn hint box cột và refresh step
            cbSelect.CheckedChanged += (s, e) => { pnlColSelectHint.Visible = cbSelect.Checked; RefreshStepUI(); };
            cbUpdate.CheckedChanged += (s, e) => { pnlColUpdateHint.Visible = cbUpdate.Checked; RefreshStepUI(); };
            cbInsert.CheckedChanged += (s, e) => RefreshStepUI();
            cbDelete.CheckedChanged += (s, e) => RefreshStepUI();

            // Nút GRANT thành công → đánh dấu step 4 done
            btnExecuteGrant.Click += (s, e) =>
            {
                // TODO: logic grant Oracle ở đây
                _step4Done = true;
                RefreshStepUI();
                msgSuccess.Parent = this.FindForm();

                // Nếu ông muốn đổi nội dung động bằng code:
                msgSuccess.Text = "Đã cấp quyền thành công cho người dùng!";
                msgSuccess.Caption = "Thông báo";

                // Hiển thị
                msgSuccess.Show();
            };

            // Panel chứa ucRevoke — ẩn mặc định khi mới vào tab Grant
            pnlContentRevoke.Visible = false;
        }

        // Cache ucRevoke để không tạo lại mỗi lần bấm tab
        private ucRevoke _ucRevoke = null;

        // =====================================================
        // CHUYỂN SANG TAB THU HỒI QUYỀN (REVOKE)
        // Tạo ucRevoke lần đầu rồi load vào pnlContentRevoke,
        // sau đó cho panel đó phủ lên toàn bộ nội dung Grant
        // =====================================================
        private void SwitchToRevoke()
        {
            if (_ucRevoke == null)
            {
                _ucRevoke = new ucRevoke(_connectionString);
                _ucRevoke.Dock = DockStyle.Fill;
                pnlContentRevoke.Controls.Add(_ucRevoke);
            }

            // Cập nhật lại size phòng trường hợp form đã resize
            int topOffset = 79;
            pnlContentRevoke.Location = new System.Drawing.Point(0, topOffset);
            pnlContentRevoke.Size = new System.Drawing.Size(
                this.Width,
                this.Height - topOffset
            );

            pnlContentRevoke.Visible = true;
            pnlContentRevoke.BringToFront();

            btnTabGrant.Checked = false;
            btnRevoke.Checked = true;
        }

        // =====================================================
        // CHUYỂN VỀ TAB CẤP QUYỀN (GRANT)
        // Ẩn panel Revoke đi, nội dung Grant hiện lại bên dưới
        // =====================================================
        private void SwitchToGrant()
        {
            pnlContentRevoke.Visible = false;
            btnTabGrant.Checked = true;
            btnRevoke.Checked = false;
        }

        // =====================================================
        // NÚT LÀM MỚI — reset toàn bộ form về trạng thái ban đầu
        // =====================================================
        private void ResetAll()
        {
            // --- Bước 1: Bỏ chọn user/role ---
            lstGrantees.SelectedIndex = -1;

            // --- Bước 2: Bỏ chọn object, xóa filter type ---
            lstObjects.SelectedIndex = -1;
            _selectedObject = "";

            // Reset 4 nút filter loại object về trạng thái mặc định
            btnTypeTable.Checked = false;
            btnTypeView.Checked = false;
            btnTypeProc.Checked = false;
            btnTypeFunc.Checked = false;

            // Xóa ô tìm kiếm
            txtSearchGrantee.Text = "";
            txtSearchObject.Text = "";

            // --- Bước 3: Bỏ tick tất cả checkbox quyền ---
            cbSelect.Checked = false;
            cbUpdate.Checked = false;
            cbInsert.Checked = false;
            cbDelete.Checked = false;
            cbGrant.Checked = false;

            // Ẩn 2 hint box cột (vàng)
            pnlColSelectHint.Visible = false;
            pnlColUpdateHint.Visible = false;

            // Xóa danh sách cột đã chọn
            _selectCols.Clear();
            _updateCols.Clear();

            // Reset text nút về mặc định
            btnEditColSelect.Text = "Giới hạn →";
            btnEditColUpdate.Text = "Giới hạn →";

            // Reset text hint label
            lblColSelectHint.Text = "Tất cả cột (chưa giới hạn)";
            lblHintUpdate.Text = "Tất cả cột (chưa giới hạn)";

            // --- Bước 4: Reset trạng thái done ---
            _step4Done = false;

            // --- Cập nhật lại toàn bộ step UI ---
            RefreshStepUI();
        }

        // =====================================================
        // LOAD — chạy khi UC được hiển thị lần đầu
        // Set tab mặc định, setup panel Revoke, load mock data,
        // và khởi tạo trạng thái step UI ban đầu (tất cả xám)
        // =====================================================
        private void ucGrantRevoke_Load(object sender, EventArgs e)
        {
            btnTabGrant.Checked = true;
            btnRevoke.Checked = false;

            // Re-parent pnlContentRevoke ra ngoài để nó có thể phủ đúng kích thước
            SetupRevokePanel();

            // Mock data — sau này thay bằng query FN_LIST_USERS() / FN_LIST_ROLES()
            lstGrantees.Items.Clear();
            lstGrantees.Items.Add(new GranteeItem("U_BACSI01", "ROLE_BACSI", Color.FromArgb(0, 120, 180)));
            lstGrantees.Items.Add(new GranteeItem("U_DPV01", "ROLE_DPV", Color.BlueViolet));
            lstGrantees.Items.Add(new GranteeItem("U_KTV01", "ROLE_KTV", Color.Orange));

            // Mock data — sau này thay bằng query FN_LIST_OBJECTS()
            lstObjects.Items.Clear();
            lstObjects.Items.Add(new ObjectItem("NHANVIEN", "TABLE", "📊", Color.FromArgb(0, 180, 216)));
            lstObjects.Items.Add(new ObjectItem("HSBA", "TABLE", "📄", Color.FromArgb(0, 180, 216)));
            lstObjects.Items.Add(new ObjectItem("V_HSBA_PHONGKHAM", "VIEW", "🔍", Color.FromArgb(124, 58, 237)));
            lstObjects.Items.Add(new ObjectItem("DONTHUOC", "TABLE", "💊", Color.FromArgb(0, 180, 216)));
            lstObjects.Items.Add(new ObjectItem("SP_CAP_NHAT_HSBA", "PROCEDURE", "⚙️", Color.FromArgb(249, 115, 22)));

            flpChoices.PerformLayout();

            // ← Gọi 1 lần để set trạng thái ban đầu (tất cả xám, chỉ cột 1 mở)
            RefreshStepUI();
        }

        // =====================================================
        // SETUP PANEL REVOKE — di chuyển pnlContentRevoke ra khỏi
        // guna2Panel2 (bị clip) và gắn thẳng vào UserControl này
        // để panel có thể phủ đúng toàn bộ vùng nội dung
        // =====================================================
        private void SetupRevokePanel()
        {
            // Bước 1: Lấy pnlContentRevoke ra khỏi guna2Panel2 (nếu còn đó)
            if (pnl2.Controls.Contains(pnlContentRevoke))
                pnl2.Controls.Remove(pnlContentRevoke);

            // Bước 2: Add thẳng vào UserControl (this), không phải tblMain
            if (!this.Controls.Contains(pnlContentRevoke))
                this.Controls.Add(pnlContentRevoke);

            // Bước 3: Cho phủ toàn bộ UserControl từ dưới tab bar trở xuống
            // Tab bar (guna2Panel1) cao 60px + padding top 16px + margin 3px = ~79px
            int topOffset = 79;
            pnlContentRevoke.Location = new System.Drawing.Point(0, topOffset);
            pnlContentRevoke.Size = new System.Drawing.Size(
                this.Width,
                this.Height - topOffset
            );
            pnlContentRevoke.Anchor = AnchorStyles.Top | AnchorStyles.Bottom
                                       | AnchorStyles.Left | AnchorStyles.Right;
            pnlContentRevoke.BackColor = System.Drawing.Color.FromArgb(240, 244, 248);
            pnlContentRevoke.Visible = false;

            // Bước 4: Đảm bảo nằm trên cùng
            pnlContentRevoke.BringToFront();
        }

        // =====================================================
        // STEP STATE TRACKING — theo dõi trạng thái từng bước
        // Dùng property tính toán trực tiếp từ UI thay vì biến bool riêng
        // =====================================================

        // 4 biến theo dõi từng bước
        private bool _step1Done => lstGrantees.SelectedItem != null;
        private bool _step2Done => lstObjects.SelectedItem != null;
        private bool _step3Done => cbSelect.Checked || cbUpdate.Checked
                                || cbInsert.Checked || cbDelete.Checked;
        private bool _step4Done = false; // true sau khi bấm GRANT thành công

        // Màu sắc dùng chung
        private readonly Color _colorActive = Color.FromArgb(0, 120, 180);   // xanh đang active
        private readonly Color _colorDone = Color.FromArgb(0, 120, 180);
        private readonly Color _colorInactive = Color.FromArgb(208, 228, 240); // xám viền
        private readonly Color _colorBgInact = Color.FromArgb(240, 244, 248); // xám nền
        private readonly Color _colorTextInact = Color.FromArgb(138, 168, 190); // xám chữ

        // =====================================================
        // REFRESH STEP UI — cập nhật màu 4 nút step và lock/unlock cột
        // Gọi sau MỌI tương tác của user để UI luôn phản ánh đúng trạng thái
        // =====================================================
        private void RefreshStepUI()
        {
            UpdateCircleButton(btn1Big, step: 1,
                isDone: _step1Done,
                isCurrent: !_step1Done);

            UpdateCircleButton(btn2Big, step: 2,
                isDone: _step2Done,
                isCurrent: _step1Done && !_step2Done);

            UpdateCircleButton(btn3Big, step: 3,
                isDone: _step3Done,
                isCurrent: _step2Done && !_step3Done);

            UpdateCircleButton(btn4Big, step: 4,
                isDone: _step4Done,
                isCurrent: _step3Done && !_step4Done);

            // Lock/Unlock các cột theo thứ tự
            SetColumnEnabled(pnlCol1, enabled: true);          // cột 1 luôn mở
            SetColumnEnabled(pnlCol2, enabled: _step1Done);    // cột 2 (object)
            SetColumnEnabled(pnlCol3, enabled: _step2Done);    // cột 3 (quyền)
            SetColumnEnabled(pnlMainBot, enabled: _step3Done);   // row 4 (confirm)
            btnExecuteGrant.Enabled = _step3Done;
        }

        // =====================================================
        // VẼ 1 CIRCLE BUTTON THEO TRẠNG THÁI
        // 3 trạng thái: chưa đến (xám) / đang ở (xanh sáng) / hoàn thành (tick)
        // =====================================================
        private void UpdateCircleButton(
            Guna.UI2.WinForms.Guna2CircleButton btn,
            int step, bool isDone, bool isCurrent)
        {
            if (isDone)
            {
                // ✓ Đã hoàn thành — xanh đậm + tick
                btn.FillColor = _colorDone;
                btn.ForeColor = Color.White;
                btn.BorderColor = _colorDone;
                btn.Text = "✓";
            }
            else if (isCurrent)
            {
                // ● Đang ở bước này — xanh sáng + số
                btn.FillColor = _colorActive;
                btn.ForeColor = Color.White;
                btn.BorderColor = _colorActive;
                btn.Text = step.ToString();
            }
            else
            {
                // ○ Chưa đến — xám nhạt + số
                btn.FillColor = _colorBgInact;
                btn.ForeColor = _colorTextInact;
                btn.BorderColor = _colorInactive;
                btn.Text = step.ToString();
            }
        }

        // =====================================================
        // LOCK / UNLOCK TOÀN BỘ CONTROLS TRONG 1 PANEL
        // Dùng để ngăn user tương tác với cột chưa đến lượt
        // Label tiêu đề và CircleButton không bị lock để giữ UI đẹp
        // =====================================================
        private void SetColumnEnabled(Control container, bool enabled)
        {
            // Dùng overlay mờ thay vì disable từng control (đẹp hơn)
            // Cách đơn giản: set Enabled cho toàn container
            // Tuy nhiên Guna2Panel không có Enabled nên ta set từng child
            foreach (Control c in container.Controls)
            {
                // Giữ nguyên label tiêu đề (guna2HtmlLabel), chỉ lock phần input
                if (c is Guna.UI2.WinForms.Guna2HtmlLabel ||
                    c is Guna.UI2.WinForms.Guna2CircleButton) continue;

                c.Enabled = enabled;
            }

            // Thêm overlay mờ khi bị lock để user thấy rõ
            container.BackColor = enabled
                ? Color.White
                : Color.FromArgb(248, 250, 252);
        }

        // =====================================================
        // VẼ LISTBOX ĐỐI TƯỢNG (cột 2) — OwnerDraw
        // Hiển thị icon bo góc màu + tên object + loại (TABLE/VIEW...)
        // =====================================================
        private void lstObjects_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            e.DrawBackground();
            var item = lstObjects.Items[e.Index] as ObjectItem;
            if (item == null) return;

            bool selected = (e.State & DrawItemState.Selected) != 0;
            var bg = selected ? Color.FromArgb(232, 244, 251) : (e.Index % 2 == 0 ? Color.White : Color.FromArgb(247, 250, 252));

            using (var brush = new SolidBrush(bg)) e.Graphics.FillRectangle(brush, e.Bounds);

            // Vẽ Icon/Emoji đại diện (Thay vì Avatar tròn)
            var iconRect = new Rectangle(e.Bounds.X + 8, e.Bounds.Y + 6, 34, 34);
            using (var iconBrush = new SolidBrush(item.ThemeColor))
            {
                // Vẽ hình vuông bo góc nhẹ làm nền cho icon
                GraphicsPath path = new GraphicsPath();
                int r = 8;
                path.AddArc(iconRect.X, iconRect.Y, r, r, 180, 90);
                path.AddArc(iconRect.Right - r, iconRect.Y, r, r, 270, 90);
                path.AddArc(iconRect.Right - r, iconRect.Bottom - r, r, r, 0, 90);
                path.AddArc(iconRect.X, iconRect.Bottom - r, r, r, 90, 90);
                e.Graphics.FillPath(iconBrush, path);
            }

            using (var fIcon = new Font("Segoe UI Emoji", 14))
                e.Graphics.DrawString(item.Icon, fIcon, Brushes.White, iconRect, new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });

            // Vẽ Tên Đối tượng & Loại (TABLE/VIEW...)
            using (var fName = new Font("Segoe UI", 10, FontStyle.Bold))
                e.Graphics.DrawString(item.Name, fName, new SolidBrush(Color.FromArgb(10, 42, 64)), e.Bounds.X + 50, e.Bounds.Y + 8);

            using (var fType = new Font("Segoe UI", 8))
                e.Graphics.DrawString(item.Type, fType, new SolidBrush(Color.FromArgb(138, 168, 190)), e.Bounds.X + 50, e.Bounds.Y + 26);

            if (selected) { /* Vẽ dấu tích nếu cần */ }
        }

        // =====================================================
        // MỞ DIALOG CHỌN CỘT (ColPicker)
        // Cho phép DBA giới hạn SELECT/UPDATE chỉ trên một số cột cụ thể
        // Kết quả lưu vào _selectCols hoặc _updateCols tương ứng
        // =====================================================
        private void ShowColPicker(string privType)
        {
            var currentCols = privType == "SELECT" ? _selectCols : _updateCols;

            var picker = new ColPicker(privType, _selectedObject, currentCols);

            // Hiển thị cạnh nút bấm cho tự nhiên
            picker.StartPosition = FormStartPosition.CenterParent;

            if (picker.ShowDialog(this) == DialogResult.OK)
            {
                if (privType == "SELECT")
                {
                    _selectCols = picker.SelectedColumns;
                    // Cập nhật text hint panel vàng của SELECT
                    lblColSelectHint.Text = _selectCols.Count > 0
                        ? $"Cột: {string.Join(", ", _selectCols)}"
                        : "Tất cả cột (chưa giới hạn)";
                    btnEditColSelect.Text = _selectCols.Count > 0 ? "Sửa →" : "Giới hạn →";
                }
                else
                {
                    _updateCols = picker.SelectedColumns;
                    // Cập nhật text hint panel vàng của UPDATE
                    // guna2HtmlLabel12 là label hint của UPDATE trong designer của bạn
                    lblHintUpdate.Text = _updateCols.Count > 0
                        ? $"Cột: {string.Join(", ", _updateCols)}"
                        : "Tất cả cột (chưa giới hạn)";
                    btnEditColUpdate.Text = _updateCols.Count > 0 ? "Sửa →" : "Giới hạn →";
                }
            }
        }

        // =====================================================
        // TẠO DÒNG QUYỀN TRONG FlpSummary (bước 4 xác nhận)
        // Hiện thị tóm tắt quyền đã chọn: loại + cột giới hạn
        // =====================================================
        private void AddPrivilegeRow(string type, List<string> cols)
        {
            Guna.UI2.WinForms.Guna2Panel row = new Guna.UI2.WinForms.Guna2Panel();
            row.Size = new Size(flpChoices.Width - 40, 45);
            row.Margin = new Padding(0, 0, 0, 8);
            row.FillColor = Color.FromArgb(248, 250, 252);
            row.BorderRadius = 8;

            Label lbl = new Label();
            lbl.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lbl.ForeColor = Color.FromArgb(10, 42, 64);
            lbl.Location = new Point(15, 12);

            string colInfo = (cols != null && cols.Count > 0)
                             ? $" (Cột: {string.Join(", ", cols)})"
                             : " (Tất cả cột)";
            lbl.Text = $"✓ Quyền {type}{colInfo}";
            lbl.AutoSize = true;

            row.Controls.Add(lbl);
            //
            //flpSummary.Controls.Add(row);
        }

        // =====================================================
        // VẼ LISTBOX GRANTEE (cột 1) — OwnerDraw
        // Hiển thị avatar tròn màu + tên user/role + dấu tick khi selected
        // =====================================================
        private void LstGrantees_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            e.DrawBackground();
            var item = lstGrantees.Items[e.Index] as GranteeItem;
            if (item == null) return;

            bool selected = (e.State & DrawItemState.Selected) != 0;
            var bg = selected
                ? Color.FromArgb(232, 244, 251)
                : (e.Index % 2 == 0 ? Color.White : Color.FromArgb(247, 250, 252));

            using (var brush = new SolidBrush(bg))
                e.Graphics.FillRectangle(brush, e.Bounds);

            var avatarRect = new Rectangle(e.Bounds.X + 8, e.Bounds.Y + 7, 30, 30);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (var avBrush = new SolidBrush(item.Color))
                e.Graphics.FillEllipse(avBrush, avatarRect);

            var avatarTxt = item.Name.Length >= 2 ? item.Name.Substring(0, 2) : item.Name;
            using (var f = new Font("Segoe UI", 9, FontStyle.Bold))
                e.Graphics.DrawString(avatarTxt, f, Brushes.White, avatarRect,
                    new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });

            using (var fName = new Font("Segoe UI", 12, FontStyle.Bold))
                e.Graphics.DrawString(item.Name, fName, new SolidBrush(Color.FromArgb(10, 42, 64)),
                    new Rectangle(e.Bounds.X + 46, e.Bounds.Y + 6, e.Bounds.Width - 60, 18));

            using (var fRole = new Font("Segoe UI", 10))
                e.Graphics.DrawString(item.RoleName, fRole, new SolidBrush(Color.FromArgb(138, 168, 190)),
                    new Rectangle(e.Bounds.X + 46, e.Bounds.Y + 24, e.Bounds.Width - 60, 16));

            if (selected)
            {
                var checkRect = new Rectangle(e.Bounds.Right - 26, e.Bounds.Y + 13, 16, 16);
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(0, 120, 180)), checkRect);
                e.Graphics.DrawString("✓", new Font("Segoe UI", 9, FontStyle.Bold), Brushes.White,
                    checkRect, new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
            }
        }

        // Khi tick/bỏ tick SELECT
        private void cbSelect_CheckedChanged(object sender, EventArgs e)
        {
            // Hiện panel vàng của SELECT nếu được tick, ngược lại thì ẩn
            pnlColSelectHint.Visible = cbSelect.Checked;
        }

        // Khi tick/bỏ tick UPDATE
        private void cbUpdate_CheckedChanged(object sender, EventArgs e)
        {
            // Hiện panel vàng của UPDATE nếu được tick, ngược lại thì ẩn
            pnlColUpdateHint.Visible = cbUpdate.Checked;
        }

        private void cbInsert_CheckedChanged(object sender, EventArgs e)
        {
            //
        }
    }

    // =====================================================
    // MODEL: GranteeItem — đại diện 1 user hoặc role trong ListBox cột 1
    // Gồm: tên hiển thị, tên role, màu avatar
    // =====================================================
    public class GranteeItem
    {
        public string Name { get; set; }
        public string RoleName { get; set; }
        public Color Color { get; set; }
        public GranteeItem(string name, string role, Color color)
        { Name = name; RoleName = role; Color = color; }
    }

    // =====================================================
    // MODEL: ObjectItem — đại diện 1 đối tượng DB trong ListBox cột 2
    // Gồm: tên object, loại (TABLE/VIEW/PROCEDURE), icon emoji, màu chủ đạo
    // =====================================================
    public class ObjectItem
    {
        public string Name { get; set; }
        public string Type { get; set; } // TABLE, VIEW, PROCEDURE
        public string Icon { get; set; } // Emoji hoặc Icon đại diện
        public Color ThemeColor { get; set; }

        public ObjectItem(string name, string type, string icon, Color color)
        {
            Name = name;
            Type = type;
            Icon = icon;
            ThemeColor = color;
        }
    }
}