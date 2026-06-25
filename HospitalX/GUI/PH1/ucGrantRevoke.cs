using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Data;
using System.Linq;
using Oracle.ManagedDataAccess.Client;
using HospitalX.DAO;

namespace HospitalX.GUI.PH1
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

        // Lưu danh sách grantees và objects không lọc để hỗ trợ lọc động
        private List<GranteeItem> _allGrantees = new List<GranteeItem>();
        private List<ObjectItem> _allObjects = new List<ObjectItem>();

        // Theo dõi tab và filter hiện tại
        private string _currentGranteeTab = "USER";
        private string _currentObjectFilter = "";

        // Cache cbExec reference để tránh repeated searches (control có thể nested)
        //private CheckBox _cbExec = null;

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
            lstGrantees.ItemHeight = 50;
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
                {
                    _selectedObject = obj.Name;
                    // Cập nhật trạng thái checkbox quyền theo loại object
                    UpdatePrivilegeCheckboxes(obj);
                }
                RefreshStepUI();
            };

            // Các checkbox quyền: hiện/ẩn hint box cột và refresh step
            cbSelect.CheckedChanged += (s, e) => { pnlColSelectHint.Visible = cbSelect.Checked; RefreshStepUI(); };
            cbUpdate.CheckedChanged += (s, e) => { pnlColUpdateHint.Visible = cbUpdate.Checked; RefreshStepUI(); };
            cbInsert.CheckedChanged += (s, e) => RefreshStepUI();
            cbDelete.CheckedChanged += (s, e) => RefreshStepUI();
            cbGrant.CheckedChanged += (s, e) => RefreshStepUI();
            cbExec.CheckedChanged += (s, e) => RefreshStepUI();

            // Nút GRANT thành công → đánh dấu step 4 done
            btnExecuteGrant.Click += (s, e) => ExecuteGrant();

            //// Wire cbExec event handler nếu control tồn tại (Note: _cbExec sẽ được gán trong Load)
            //if (_cbExec != null)
            //{
            //    _cbExec.CheckedChanged += (s, e) => 
            //    { 
            //        // Ngăn tick cbExec khi nó disabled (TABLE/VIEW mode)
            //        if (!_isUpdatingCheckboxes && !_cbExec.Enabled && _cbExec.Checked)
            //        {
            //            _isUpdatingCheckboxes = true;
            //            _cbExec.Checked = false;
            //            _isUpdatingCheckboxes = false;
            //        }
            //        RefreshStepUI();
            //    };
            //}

            // Nút filter grantee theo loại (User/Role)
            btnGranteeUser.Click += (s, e) => ApplyGranteeFilter("USER");
            btnGranteeRole.Click += (s, e) => ApplyGranteeFilter("ROLE");

            // Nút filter object theo loại (Table/View/Proc/Func)
            btnTypeTable.Click += (s, e) => ApplyObjectFilter("TABLE");
            btnTypeView.Click += (s, e) => ApplyObjectFilter("VIEW");
            btnTypeProc.Click += (s, e) => ApplyObjectFilter("PROCEDURE");
            btnTypeFunc.Click += (s, e) => ApplyObjectFilter("FUNCTION");

            // Wire sự kiện tìm kiếm realtime
            txtSearchGrantee.TextChanged += (s, e) => ApplyGranteeFilter(_currentGranteeTab);
            txtSearchObject.TextChanged += (s, e) => ApplyObjectFilter(_currentObjectFilter);

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
            cbExec.Checked = false;

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
        // Set tab mặc định, setup panel Revoke, load dữ liệu từ DB
        // và khởi tạo trạng thái step UI ban đầu (tất cả xám)
        // =====================================================
        private void ucGrantRevoke_Load(object sender, EventArgs e)
        {
            btnTabGrant.Checked = true;
            btnRevoke.Checked = false;

            //// Cache cbExec reference (tìm một lần, sử dụng mãi mãi)
            //_cbExec = this.Controls.OfType<CheckBox>().FirstOrDefault(c => c.Name == "cbExec");

            // Re-parent pnlContentRevoke ra ngoài để nó có thể phủ đúng kích thước
            SetupRevokePanel();

            // Load từ database
            LoadGrantees();
            LoadObjects();

            flpChoices.PerformLayout();

            // ← Gọi 1 lần để set trạng thái ban đầu (tất cả xám, chỉ cột 1 mở)
            RefreshStepUI();
        }

        // =====================================================
        // LOAD GRANTEES — tải danh sách users và roles từ Oracle
        // =====================================================
        private void LoadGrantees()
        {
            try
            {
                _allGrantees.Clear();
                lstGrantees.Items.Clear();

                // Load users từ USP_LIST_USERS
                var usersParams = new OracleParameter[] {
                    new OracleParameter("p_cursor", OracleDbType.RefCursor) 
                    { Direction = ParameterDirection.Output }
                };

                var dtUsers = DataProvider.Instance.ExecuteQuery("USP_LIST_USERS", usersParams);

                if (dtUsers != null && dtUsers.Rows.Count > 0)
                {
                    foreach (DataRow row in dtUsers.Rows)
                    {
                        string username = row["USERNAME"].ToString();
                        string status = row["ACCOUNT_STATUS"] != DBNull.Value ? row["ACCOUNT_STATUS"].ToString() : "OPEN";

                        // Chỉ thêm user OPEN (không bị khóa)
                        if (status == "OPEN")
                        {
                            _allGrantees.Add(new GranteeItem(username, "USER", Color.FromArgb(0, 120, 180)));
                        }
                    }
                }

                // Load roles từ USP_LIST_ROLES
                var rolesParams = new OracleParameter[] {
                    new OracleParameter("p_cursor", OracleDbType.RefCursor) 
                    { Direction = ParameterDirection.Output }
                };

                var dtRoles = DataProvider.Instance.ExecuteQuery("USP_LIST_ROLES", rolesParams);

                if (dtRoles != null && dtRoles.Rows.Count > 0)
                {
                    foreach (DataRow row in dtRoles.Rows)
                    {
                        string roleName = row["ROLE"].ToString();
                        _allGrantees.Add(new GranteeItem(roleName, "ROLE", Color.BlueViolet));
                    }
                }

                // Áp dụng filter hiện tại
                ApplyGranteeFilter(_currentGranteeTab);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh sách users/roles: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =====================================================
        // LOAD OBJECTS — tải danh sách tables, views, procedures từ DB
        // =====================================================
        private void LoadObjects()
        {
            try
            {
                _allObjects.Clear();
                lstObjects.Items.Clear();

                // Gọi stored procedure thay vì raw SQL (đẩy nghiệp vụ xuống Oracle)
                var parameters = new OracleParameter[] {
                    new OracleParameter("p_cursor", OracleDbType.RefCursor) { Direction = ParameterDirection.Output }
                };
                var dtObjects = DataProvider.Instance.ExecuteQuery("USP_GET_SCHEMA_OBJECTS", parameters, isStoredProc: true);

                if (dtObjects != null && dtObjects.Rows.Count > 0)
                {
                    foreach (DataRow row in dtObjects.Rows)
                    {
                        string objName = row["OBJECT_NAME"].ToString();
                        string objType = row["OBJECT_TYPE"].ToString();

                        string icon;
                        if (objType == "TABLE") icon = "📊";
                        else if (objType == "VIEW") icon = "🔍";
                        else if (objType == "PROCEDURE") icon = "⚙️";
                        else if (objType == "FUNCTION") icon = "ƒ";
                        else icon = "🔹";

                        Color color;
                        if (objType == "TABLE") color = Color.FromArgb(0, 180, 216);
                        else if (objType == "VIEW") color = Color.FromArgb(124, 58, 237);
                        else if (objType == "PROCEDURE") color = Color.FromArgb(249, 115, 22);
                        else if (objType == "FUNCTION") color = Color.FromArgb(34, 197, 94);
                        else color = Color.Gray;

                        _allObjects.Add(new ObjectItem(objName, objType, icon, color));
                    }
                }

                // Áp dụng filter hiện tại
                ApplyObjectFilter(_currentObjectFilter);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh sách objects: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
        private bool _step3Done
        {
            get
            {
                if (cbSelect.Checked || cbUpdate.Checked || cbInsert.Checked || cbDelete.Checked || cbExec.Checked)
                    return true;

                return false;
            }
        }
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
        // LỌC GRANTEES THEO LOẠI (USER/ROLE)
        // =====================================================
        private void ApplyGranteeFilter(string tab)
        {
            _currentGranteeTab = tab;
            lstGrantees.Items.Clear();

            string kw = txtSearchGrantee.Text.Trim().ToLower();

            // Lọc danh sách _allGrantees theo tab được chọn và keyword tìm kiếm
            foreach (var grantee in _allGrantees)
            {
                if (grantee.RoleName == tab)
                {
                    bool match = string.IsNullOrEmpty(kw) || grantee.Name.ToLower().Contains(kw);
                    if (match)
                    {
                        lstGrantees.Items.Add(grantee);
                    }
                }
            }

            // Cập nhật trạng thái nút (Checked = active)
            btnGranteeUser.Checked = (tab == "USER");
            btnGranteeRole.Checked = (tab == "ROLE");

            // Reset lựa chọn
            lstGrantees.SelectedIndex = -1;
            RefreshStepUI();
        }

        // =====================================================
        // LỌC OBJECTS THEO LOẠI (TABLE/VIEW/PROCEDURE/FUNCTION)
        // =====================================================
        private void ApplyObjectFilter(string objType)
        {
            _currentObjectFilter = objType;
            lstObjects.Items.Clear();

            string kw = txtSearchObject.Text.Trim().ToLower();

            // Nếu objType rỗng, hiển thị tất cả; ngược lại chỉ hiển thị loại được chọn có chứa keyword
            foreach (var obj in _allObjects)
            {
                if (string.IsNullOrEmpty(objType) || obj.Type == objType)
                {
                    bool match = string.IsNullOrEmpty(kw) || obj.Name.ToLower().Contains(kw);
                    if (match)
                    {
                        lstObjects.Items.Add(obj);
                    }
                }
            }

            // Cập nhật trạng thái nút (Checked = active)
            btnTypeTable.Checked = (objType == "TABLE");
            btnTypeView.Checked = (objType == "VIEW");
            btnTypeProc.Checked = (objType == "PROCEDURE");
            btnTypeFunc.Checked = (objType == "FUNCTION");

            // Reset lựa chọn
            lstObjects.SelectedIndex = -1;
            RefreshStepUI();
        }

        // =====================================================
        // CẬP NHẬT TRẠNG THÁI CHECKBOX QUYỀN THEO LOẠI OBJECT
        // TABLE/VIEW: Select, Insert, Update, Delete
        // PROCEDURE/FUNCTION: Chỉ Exec
        // =====================================================
        private void UpdatePrivilegeCheckboxes(ObjectItem obj)
        {
            if (obj == null) return;

            bool isTableOrView = (obj.Type == "TABLE" || obj.Type == "VIEW");
            bool isProcOrFunc = (obj.Type == "PROCEDURE" || obj.Type == "FUNCTION");

            //var execCheckbox = this.Controls.OfType<CheckBox>().FirstOrDefault(c => c.Name == "cbExec");

            // Kiểm tra xem grantee có phải USER không (ROLE không thể có GRANT OPTION)
            bool isGranteeUser = (lstGrantees.SelectedItem is GranteeItem grantee && grantee.RoleName == "USER");

            if (isTableOrView)
            {
                // Bảng/View: bật các quyền thông thường, tắt EXEC
                cbSelect.Enabled = true;
                cbInsert.Enabled = true;
                cbUpdate.Enabled = true;
                cbDelete.Enabled = true;
                cbExec.Enabled = false;
                cbGrant.Enabled = isGranteeUser;  // GRANT OPTION chỉ cho USER

                //if (execCheckbox != null)
                //    execCheckbox.Enabled = false;
            }
            else if (isProcOrFunc)
            {
                // Procedure/Function: chỉ bật EXEC, tắt các quyền khác
                // NHƯNG cbGrant vẫn được enable vì nó là WITH GRANT OPTION, không phải privilege
                cbSelect.Enabled = false;
                cbInsert.Enabled = false;
                cbUpdate.Enabled = false;
                cbDelete.Enabled = false;
                cbExec.Enabled = true;
                cbGrant.Enabled = isGranteeUser;  // GRANT OPTION chỉ cho USER

                //if (execCheckbox != null)
                //    execCheckbox.Enabled = true;
            }

            // Bỏ check các checkbox bị disable
            if (!cbSelect.Enabled) cbSelect.Checked = false;
            if (!cbInsert.Enabled) cbInsert.Checked = false;
            if (!cbUpdate.Enabled) cbUpdate.Checked = false;
            if (!cbDelete.Enabled) cbDelete.Checked = false;
            if (!cbExec.Enabled) cbExec.Checked = false;
            if (!cbGrant.Enabled) cbGrant.Checked = false;
            //if (execCheckbox != null && !execCheckbox.Enabled)
            //    execCheckbox.Checked = false;

            RefreshStepUI();
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

            var avatarRect = new Rectangle(e.Bounds.X + 10, e.Bounds.Y + 10, 32, 32);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (var avBrush = new SolidBrush(item.Color))
                e.Graphics.FillEllipse(avBrush, avatarRect);

            var avatarTxt = item.Name.Length >= 2 ? item.Name.Substring(0, 2) : item.Name;
            using (var f = new Font("Segoe UI", 8, FontStyle.Bold))
                e.Graphics.DrawString(avatarTxt, f, Brushes.White, avatarRect,
                    new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });

            using (var fName = new Font("Segoe UI", 11, FontStyle.Bold))
                e.Graphics.DrawString(item.Name, fName, new SolidBrush(Color.FromArgb(10, 42, 64)),
                    new Rectangle(e.Bounds.X + 52, e.Bounds.Y + 7, e.Bounds.Width - 60, 22));

            using (var fRole = new Font("Segoe UI", 9))
                e.Graphics.DrawString(item.RoleName, fRole, new SolidBrush(Color.FromArgb(138, 168, 190)),
                    new Rectangle(e.Bounds.X + 52, e.Bounds.Y + 28, e.Bounds.Width - 60, 16));

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

        // =====================================================
        // EXECUTE GRANT — xây dựng câu lệnh GRANT từ các lựa chọn
        // và gửi đến Oracle qua SP_GRANT_PRIVILEGE
        // =====================================================
        private void ExecuteGrant()
        {
            if (!(lstGrantees.SelectedItem is GranteeItem grantee))
            {
                MessageBox.Show("Vui lòng chọn User hoặc Role!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!(lstObjects.SelectedItem is ObjectItem obj))
            {
                MessageBox.Show("Vui lòng chọn Object!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra ít nhất 1 privilege được chọn (SELECT, UPDATE, INSERT, DELETE, EXECUTE)
            // cbGrant không phải privilege, nó chỉ là "WITH GRANT OPTION"
            bool hasPrivilege = cbSelect.Checked || cbUpdate.Checked || cbInsert.Checked 
                                || cbDelete.Checked || cbExec.Checked;

            if (!hasPrivilege)
            {
                MessageBox.Show("Vui lòng chọn ít nhất 1 quyền (SELECT, UPDATE, INSERT, DELETE hoặc EXECUTE)!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Xây dựng danh sách quyền
                List<string> privileges = new List<string>();
                string selectCols = "";
                string updateCols = "";

                if (cbSelect.Checked)
                {
                    privileges.Add("SELECT");
                    selectCols = _selectCols.Count > 0 ? string.Join(",", _selectCols) : "";
                }

                if (cbUpdate.Checked)
                {
                    privileges.Add("UPDATE");
                    updateCols = _updateCols.Count > 0 ? string.Join(",", _updateCols) : "";
                }

                if (cbInsert.Checked)
                    privileges.Add("INSERT");

                if (cbDelete.Checked)
                    privileges.Add("DELETE");

                // Thêm EXECUTE nếu được tick
                if (cbExec.Checked)
                    privileges.Add("EXECUTE");

                // QUAN TRỌNG: cbGrant không phải là privilege, nó là WITH GRANT OPTION
                // Nó được dùng cho tất cả các privilege được select, không thêm vào danh sách
                bool withOption = cbGrant.Checked && grantee.RoleName == "USER";

                // Gọi SP_GRANT_PRIVILEGE cho từng quyền
                foreach (string priv in privileges)
                {
                    string columns = priv == "SELECT" ? selectCols : (priv == "UPDATE" ? updateCols : "");

                    var parameters = new OracleParameter[] {
                        new OracleParameter("p_privilege", OracleDbType.Varchar2) { Value = priv },
                        new OracleParameter("p_object_type", OracleDbType.Varchar2) { Value = obj.Type },
                        new OracleParameter("p_object_name", OracleDbType.Varchar2) { Value = obj.Name },
                        new OracleParameter("p_columns", OracleDbType.Varchar2) { Value = columns ?? "" },
                        new OracleParameter("p_grantee", OracleDbType.Varchar2) { Value = grantee.Name },
                        new OracleParameter("p_grantee_type", OracleDbType.Varchar2) { Value = grantee.RoleName },
                        new OracleParameter("p_with_option", OracleDbType.Varchar2) { Value = withOption ? "YES" : "NO" }
                    };

                    DataProvider.Instance.ExecuteNonQuery("SP_GRANT_PRIVILEGE", parameters);
                }

                _step4Done = true;
                RefreshStepUI();

                msgSuccess.Parent = this.FindForm();
                msgSuccess.Text = $"Đã cấp quyền {string.Join(", ", privileges)} cho {grantee.Name} trên {obj.Name}!";
                msgSuccess.Caption = "Thành công";
                msgSuccess.Show();

                // Reset form
                ResetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi cấp quyền: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        }