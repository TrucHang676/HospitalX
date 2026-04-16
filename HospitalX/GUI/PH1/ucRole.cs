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

namespace HospitalX.GUI.PH1
{
    public partial class ucRole : UserControl
    {
        // ================================================
        // BIẾN TOÀN CỤC
        // _connectionString : chuỗi kết nối Oracle, nhận từ form cha khi khởi tạo
        // _roles            : toàn bộ danh sách role trong hệ thống
        // _members          : danh sách thành viên của role đang được chọn
        // _privs            : danh sách quyền của role đang được chọn
        // _currentTab       : tab đang hiển thị bên phải ("members" hoặc "privileges")
        // ================================================
        private string _connectionString;

        private List<RoleItem> _roles = new List<RoleItem>(); // Khởi tạo tránh null
        private List<MemberItem> _members = new List<MemberItem>();
        private List<PrivItem> _privs = new List<PrivItem>();

        private string _currentTab = "members";

        // ================================================
        // CONSTRUCTOR — khởi tạo component, cấu hình dialog,
        // gắn sự kiện và load dữ liệu mock
        // ================================================
        public ucRole(string connStr)
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            _connectionString = connStr;

            // Khởi tạo msgDialog nếu designer chưa làm
            if (this.msgDialog == null) this.msgDialog = new Guna.UI2.WinForms.Guna2MessageDialog();
            this.msgDialog.Style = Guna.UI2.WinForms.MessageDialogStyle.Light;
            this.msgDialog.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
            this.msgDialog.Caption = "Hệ thống";
            this.Load += (s, e) => { this.msgDialog.Parent = this.FindForm(); };

            // Gắn sự kiện cho các control
            btnTabMembers.Click += BtnTabMembers_Click;
            btnTabPrivileges.Click += BtnTabPrivileges_Click;
            lstRoles.DrawItem += LstRoles_DrawItem;
            lstRoles.SelectedIndexChanged += LstRoles_SelectedIndexChanged;
            lstDetails.DrawItem += LstDetails_DrawItem;
            lstDetails.MeasureItem += LstDetails_MeasureItem;
            btnCreate.Click += BtnCreate_Click;
            btnDelete.Click += BtnDelete_Click;
            txtSearch.TextChanged += TxtSearch_TextChanged;
            pnlRightFooter.Resize += PnlRightFooter_Resize;

            RefreshData();

            PnlRightFooter_Resize(null, null);
        }

        // ================================================
        // TÌM KIẾM ROLE REALTIME — lọc ListBox theo từ khóa
        // khớp với tên role hoặc subtitle (tên vai trò tiếng Việt)
        // ================================================
        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim().ToUpper();
            lstRoles.Items.Clear();
            foreach (var r in _roles)
            {
                if (string.IsNullOrEmpty(keyword) || r.Name.ToUpper().Contains(keyword) || r.Subtitle.ToUpper().Contains(keyword))
                    lstRoles.Items.Add(r);
            }
            UpdateFooter();
            if (lstRoles.Items.Count > 0)
                lstRoles.SelectedIndex = 0;
        }

        // ================================================
        // CĂN GIỮA NÚT XÓA — tính toán lại vị trí nút btnDelete
        // mỗi khi pnlRightFooter thay đổi kích thước
        // ================================================
        private void PnlRightFooter_Resize(object sender, EventArgs e)
        {
            btnDelete.Left = (pnlRightFooter.Width - btnDelete.Width) / 2;
            btnDelete.Top = (pnlRightFooter.Height - btnDelete.Height) / 2;
        }

        // ================================================
        // TẠO ROLE MỚI — mở form frmCreateRole, nếu xác nhận
        // thì gọi sp_CreateRole để tạo role trên Oracle
        // ================================================
        private void BtnCreate_Click(object sender, EventArgs e)
        {
            using (var frm = new frmCreateRole())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Gọi stored procedure sp_CreateRole để tạo role trên Oracle
                        var parameters = new OracleParameter[] {
                            new OracleParameter("p_role_name", OracleDbType.Varchar2, frm.RoleName, ParameterDirection.Input)
                        };

                        DataProvider.Instance.ExecuteNonQuery("sp_CreateRole", parameters);

                        msgDialog.Parent = this.FindForm();
                        msgDialog.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
                        msgDialog.Show($"Đã tạo Role '{frm.RoleName}' thành công!", "Thành công");

                        // Reload danh sách role từ DB và refresh UI
                        RefreshData();
                    }
                    catch (Oracle.ManagedDataAccess.Client.OracleException ex)
                    {
                        msgDialog.Icon = Guna.UI2.WinForms.MessageDialogIcon.Error;
                        msgDialog.Show("Lỗi khi tạo role: " + ex.Message, "Lỗi");
                    }
                    catch (Exception ex)
                    {
                        msgDialog.Icon = Guna.UI2.WinForms.MessageDialogIcon.Error;
                        msgDialog.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi");
                    }
                }
            }
        }

        // ================================================
        // LOAD ROLES TỪ ORACLE DATABASE 
        // Gọi USP_LIST_ROLES để lấy danh sách role từ DBA_ROLES
        // ================================================
        private void LoadRolesFromDb()
        {
            _roles = new List<RoleItem>();

            try
            {
                var param = new OracleParameter[] {
                    new OracleParameter("p_cursor", OracleDbType.RefCursor) { Direction = ParameterDirection.Output }
                };

                DataTable dt = DataProvider.Instance.ExecuteQuery("USP_LIST_ROLES", param);

                Color[] colors = { 
                    Color.FromArgb(230, 240, 255), 
                    Color.FromArgb(250, 240, 245), 
                    Color.FromArgb(255, 250, 230), 
                    Color.FromArgb(240, 255, 245),
                    Color.FromArgb(240, 248, 255)
                };

                Color[] iconColors = {
                    Color.FromArgb(0, 50, 150),
                    Color.OrangeRed,
                    Color.DarkGoldenrod,
                    Color.SeaGreen,
                    Color.FromArgb(0, 120, 180)
                };

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var row = dt.Rows[i];
                    string roleName = row["ROLE"]?.ToString() ?? "";

                    // Color index based on role name hash
                    int colorIdx = (roleName.GetHashCode() & 0x7fffffff) % colors.Length;

                    // Create role item (members/privileges will load on selection)
                    var r = new RoleItem(
                        roleName, 
                        $"Role - {roleName}", 
                        colors[colorIdx], 
                        iconColors[colorIdx]
                    );

                    _roles.Add(r);
                }
            }
            catch (Exception ex)
            {
                _roles = new List<RoleItem>();
                System.Diagnostics.Debug.WriteLine("LoadRolesFromDb error: " + ex.Message);
            }
        }

        // ================================================
        // CẬP NHẬT FOOTER — hiển thị tổng số role hoặc
        // số đang hiển thị / tổng khi đang filter tìm kiếm
        // ================================================
        private void UpdateFooter()
        {
            int total = _roles.Count;
            int showing = lstRoles.Items.Count;
            if (showing == total)
                lblRoleCount.Text = $"{total} roles trong hệ thống";
            else
                lblRoleCount.Text = $"Hiển thị {showing}/{total} roles";
        }

        // ================================================
        // KHI CHỌN ROLE TỪ LISTBOX — cập nhật toàn bộ panel
        // bên phải: tên role, subtitle, số thành viên, số quyền,
        // icon, và render lại tab đang mở (members hoặc privileges)
        // ================================================
        private void LstRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstRoles.SelectedItem is RoleItem item)
            {
                lblRoleName.Text = item.Name;
                lblRoleSub.Text = item.Subtitle;

                var initStr = item.Name.Replace("ROLE_", "").Substring(0, 1);
                btnRoleIcon.Text = initStr;
                btnRoleIcon.Font = new Font("Segoe UI", 16, FontStyle.Bold);
                btnRoleIcon.FillColor = item.BgColor;
                btnRoleIcon.ForeColor = item.IconColor;

                // Cập nhật members và privileges của role đang chọn
                _members = item.Members;
                _privs = item.Privileges;

                _members = item.Members;
                _privs = item.Privileges;

                // Update stats
                lblStatMemberVal.Text = _members.Count.ToString();
                lblStatPrivVal.Text = _privs.Count.ToString();

                RenderTabDetails();
            }
        }

        // ================================================
        // LOAD MEMBERS CỦA ROLE — lấy danh sách users gán vào role từ DB
        // ================================================
        private void LoadRoleMembers(RoleItem targetRole) // Truyền object vào luôn
        {
            if (targetRole == null) return;

            try
            {
                var param = new OracleParameter[] {
                new OracleParameter("p_role_name", OracleDbType.Varchar2, targetRole.Name, ParameterDirection.Input),
                new OracleParameter("p_cursor", OracleDbType.RefCursor) { Direction = ParameterDirection.Output }
            };

                DataTable dt = DataProvider.Instance.ExecuteQuery("USP_LIST_ROLE_MEMBERS", param);
                targetRole.Members.Clear();

                Color[] colors = { Color.FromArgb(41, 121, 255), Color.FromArgb(150, 100, 250), Color.FromArgb(250, 150, 50), Color.FromArgb(140, 150, 160) };

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var row = dt.Rows[i];
                    string username = row["GRANTEE"]?.ToString() ?? "";
                    string initials = username.Length >= 2 ? username.Substring(0, 2).ToUpper() : "??";
                    int colorIdx = (username.GetHashCode() & 0x7fffffff) % colors.Length;

                    targetRole.Members.Add(new MemberItem(username, initials, colors[colorIdx]));
                }
            }
            catch (Exception ex) { System.Diagnostics.Debug.WriteLine("LoadRoleMembers error: " + ex.Message); }
        }
        //private void LoadRoleMembers(RoleItem targetRole)
        //{
        //    if (targetRole == null) return;

        //    try
        //    {
        //        var param = new OracleParameter[] {
        //            new OracleParameter("p_role_name", OracleDbType.Varchar2, roleName, ParameterDirection.Input),
        //            new OracleParameter("p_cursor", OracleDbType.RefCursor) { Direction = ParameterDirection.Output }
        //        };

        //        DataTable dt = DataProvider.Instance.ExecuteQuery("USP_LIST_ROLE_MEMBERS", param);

        //        selectedRole.Members.Clear();

        //        Color[] colors = { Color.FromArgb(41, 121, 255), Color.FromArgb(150, 100, 250), Color.FromArgb(250, 150, 50), Color.FromArgb(140, 150, 160) };

        //        for (int i = 0; i < dt.Rows.Count; i++)
        //        {
        //            var row = dt.Rows[i];
        //            string username = row["GRANTEE"]?.ToString() ?? "";

        //            // Derive initials
        //            string initials = "--";
        //            var parts = username.Split(new char[] { '_', '.' }, StringSplitOptions.RemoveEmptyEntries);
        //            if (parts.Length > 0)
        //                initials = parts[0].Length >= 2 ? parts[0].Substring(0, 2).ToUpper() : parts[0].ToUpper();

        //            int colorIdx = (username.GetHashCode() & 0x7fffffff) % colors.Length;

        //            selectedRole.Members.Add(new MemberItem(username, initials, colors[colorIdx]));
        //        }

        //        // Refresh badges when member count changes
        //        lstRoles.Invalidate();
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Diagnostics.Debug.WriteLine("LoadRoleMembers error: " + ex.Message);
        //    }
        //}

        // ================================================
        // LOAD PRIVILEGES CỦA ROLE — lấy danh sách quyền của role từ DB
        // ================================================
        private void LoadRolePrivileges(RoleItem targetRole) // Truyền object vào luôn
        {
            if (targetRole == null) return;

            try
            {
                var param = new OracleParameter[] {
                new OracleParameter("p_role_name", OracleDbType.Varchar2, targetRole.Name, ParameterDirection.Input),
                new OracleParameter("p_cursor", OracleDbType.RefCursor) { Direction = ParameterDirection.Output }
            };

                DataTable dt = DataProvider.Instance.ExecuteQuery("USP_LIST_ROLE_PRIVILEGES", param);
                targetRole.Privileges.Clear();

                Dictionary<string, List<string>> objectPrivs = new Dictionary<string, List<string>>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var row = dt.Rows[i];
                    string objectName = row["object_name"]?.ToString() ?? row["OBJECT_NAME"]?.ToString() ?? "";
                    string privilege = row["PRIVILEGE"]?.ToString() ?? "";

                    if (!objectPrivs.ContainsKey(objectName)) objectPrivs[objectName] = new List<string>();
                    if (!objectPrivs[objectName].Contains(privilege)) objectPrivs[objectName].Add(privilege);
                }

                foreach (var kvp in objectPrivs)
                {
                    targetRole.Privileges.Add(new PrivItem(kvp.Key, "TABLE", kvp.Value.ToArray()));
                }
            }
            catch (Exception ex) { System.Diagnostics.Debug.WriteLine(ex.Message); }
        }
        //private void LoadRolePrivileges(string roleName)
        //{
        //    if (!(lstRoles.SelectedItem is RoleItem selectedRole)) return;

        //    try
        //    {
        //        var param = new OracleParameter[] {
        //            new OracleParameter("p_role_name", OracleDbType.Varchar2, roleName, ParameterDirection.Input),
        //            new OracleParameter("p_cursor", OracleDbType.RefCursor) { Direction = ParameterDirection.Output }
        //        };

        //        DataTable dt = DataProvider.Instance.ExecuteQuery("USP_LIST_ROLE_PRIVILEGES", param);

        //        selectedRole.Privileges.Clear();

        //        // Group privileges by object name
        //        Dictionary<string, List<string>> objectPrivs = new Dictionary<string, List<string>>();

        //        for (int i = 0; i < dt.Rows.Count; i++)
        //        {
        //            var row = dt.Rows[i];
        //            // Handle both uppercase and lowercase column names from Oracle alias
        //            string objectName = row["object_name"]?.ToString() ?? row["OBJECT_NAME"]?.ToString() ?? "";
        //            string privilege = row["PRIVILEGE"]?.ToString() ?? "";

        //            if (!objectPrivs.ContainsKey(objectName))
        //                objectPrivs[objectName] = new List<string>();

        //            if (!objectPrivs[objectName].Contains(privilege))
        //                objectPrivs[objectName].Add(privilege);
        //        }

        //        // Create PrivItem for each object
        //        foreach (var kvp in objectPrivs)
        //        {
        //            string objName = kvp.Key;
        //            string[] privs = kvp.Value.ToArray();

        //            // Determine object type (simplified - assume TABLE)
        //            string objType = "TABLE";

        //            selectedRole.Privileges.Add(new PrivItem(objName, objType, privs));
        //        }

        //        // Refresh badges when privilege count changes
        //        lstRoles.Invalidate();
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Diagnostics.Debug.WriteLine("LoadRolePrivileges error: " + ex.Message);
        //    }
        //}


        // ================================================
        // REFRESH DỮ LIỆU — load lại toàn bộ role từ DB, sau đó load members/privs cho từng role
        // ================================================
        private void RefreshData()
        {
            LoadRolesFromDb();
            // Sau khi load role, phải load luôn members/privs cho từng cái để hiện badge
            foreach (var r in _roles)
            {
                LoadRoleMembers(r);
                LoadRolePrivileges(r);
            }
            TxtSearch_TextChanged(null, null);
        }

        // ================================================
        // DELETE ROLE — xóa role đang chọn bằng sp_DropRole
        // ================================================
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (!(lstRoles.SelectedItem is RoleItem item)) return;

            var dr = MessageBox.Show($"Bạn có chắc muốn xóa role {item.Name}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr != DialogResult.Yes) return;

            try
            {
                var parameters = new OracleParameter[] {
                    new OracleParameter("p_role_name", OracleDbType.Varchar2, item.Name, ParameterDirection.Input)
                };

                DataProvider.Instance.ExecuteNonQuery("sp_DropRole", parameters);

                msgDialog.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
                msgDialog.Show($"Đã xóa role {item.Name}", "Thành công");

                // Reload
                RefreshData();
            }
            catch (Oracle.ManagedDataAccess.Client.OracleException ex)
            {
                msgDialog.Icon = Guna.UI2.WinForms.MessageDialogIcon.Error;
                msgDialog.Show("Lỗi khi xóa role: " + ex.Message, "Lỗi");
            }
        }

        // ================================================
        // CHUYỂN TAB MEMBERS — hiển thị danh sách user
        // thuộc role đang chọn ở panel bên phải
        // ================================================
        private void BtnTabMembers_Click(object sender, EventArgs e)
        {
            _currentTab = "members";
            RenderTabDetails();
        }

        // ================================================
        // CHUYỂN TAB PRIVILEGES — hiển thị danh sách quyền
        // (object privilege) của role đang chọn
        // ================================================
        private void BtnTabPrivileges_Click(object sender, EventArgs e)
        {
            _currentTab = "privileges";
            RenderTabDetails();
        }

        // ================================================
        // RENDER NỘI DUNG TAB — đổ dữ liệu vào lstDetails
        // theo _currentTab đang active (members hoặc privileges)
        // ================================================
        private void RenderTabDetails()
        {
            lstDetails.Items.Clear();
            if (_currentTab == "members")
            {
                foreach (var m in _members) lstDetails.Items.Add(m);
            }
            else
            {
                foreach (var p in _privs) lstDetails.Items.Add(p);
            }
        }

        // ================================================
        // VẼ THỦ CÔNG TỪNG ITEM TRONG LISTBOX ROLE (OwnerDraw)
        // Mỗi dòng gồm: icon bo góc với chữ viết tắt, tên role,
        // subtitle tiếng Việt, badge số thành viên và số quyền
        // ================================================
        private void LstRoles_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            e.DrawBackground();

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

            var item = lstRoles.Items[e.Index] as RoleItem;
            if (item == null) return;

            bool selected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;
            var bg = selected ? Color.FromArgb(240, 248, 255) : Color.White;
            using (var brush = new SolidBrush(bg))
            {
                e.Graphics.FillRectangle(brush, e.Bounds);
            }

            // Draw Separator line
            e.Graphics.DrawLine(new Pen(Color.FromArgb(240, 240, 240)), e.Bounds.X, e.Bounds.Bottom - 1, e.Bounds.Right, e.Bounds.Bottom - 1);

            // Draw Icon Bg — hình vuông bo góc làm nền cho icon role
            var iconRect = new Rectangle(e.Bounds.X + 20, e.Bounds.Y + 15, 40, 40);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.FillRoundedRectangle(new SolidBrush(item.BgColor), iconRect, 10);

            // Draw Icon Initial Text — chữ cái đầu của tên role (bỏ tiền tố "ROLE_")
            var initStr = item.Name.Replace("ROLE_", "").Substring(0, 1);
            e.Graphics.DrawString(initStr, new Font("Segoe UI", 12, FontStyle.Bold), new SolidBrush(item.IconColor), iconRect, new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });

            // Draw Texts — tên role và subtitle tiếng Việt
            var txtBrush = new SolidBrush(Color.FromArgb(10, 42, 64));
            var subBrush = new SolidBrush(Color.FromArgb(138, 168, 190));
            e.Graphics.DrawString(item.Name, new Font("Segoe UI", 11, FontStyle.Bold), txtBrush, e.Bounds.X + 75, e.Bounds.Y + 15);
            e.Graphics.DrawString(item.Subtitle, new Font("Segoe UI", 9), subBrush, e.Bounds.X + 75, e.Bounds.Y + 38);

            string memberText = $"{item.MemberCount} users";
            var memberFont = new Font("Segoe UI", 9);
            var memberSize = e.Graphics.MeasureString(memberText, memberFont);
            int badgeH = 30;

            int badgeY = e.Bounds.Y + (e.Bounds.Height - badgeH) / 2;

            // ===== BADGE "x quyền" — số object privilege của role =====
            string privText = $"{item.PrivilegeCount} quyền";
            var privSize = e.Graphics.MeasureString(privText, memberFont);
            int badgeW2 = (int)privSize.Width + 20;
            int badgeX2 = e.Bounds.Right - badgeW2 - 80;
            var badgeRect2 = new Rectangle(badgeX2, badgeY, badgeW2, badgeH);
            using (var b2Brush = new SolidBrush(Color.FromArgb(245, 240, 255)))
                e.Graphics.FillRoundedRectangle(b2Brush, badgeRect2, 11);
            e.Graphics.DrawString(privText, memberFont, new SolidBrush(Color.FromArgb(110, 80, 170)), badgeRect2, new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });


            // ===== BADGE "x users" — số thành viên thuộc role này =====
            int badgeW1 = (int)memberSize.Width + 20;
            int badgeX1 = badgeX2 - badgeW1 - 80; ;
            var badgeRect1 = new Rectangle(badgeX1, badgeY, badgeW1, badgeH);
            using (var b1Brush = new SolidBrush(Color.FromArgb(235, 245, 255)))
                e.Graphics.FillRoundedRectangle(b1Brush, badgeRect1, 11);
            e.Graphics.DrawString(memberText, memberFont, new SolidBrush(Color.FromArgb(60, 120, 180)), badgeRect1, new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });

        }

        // ================================================
        // ĐO CHIỀU CAO ITEM TRONG LISTBOX CHI TIẾT (MeasureItem)
        // Tab members: chiều cao cố định 60px
        // Tab privileges: chiều cao tăng thêm nếu nhiều tag quyền
        // (mỗi hàng chứa tối đa 2 tag, mỗi hàng thêm cao 32px)
        // ================================================
        private void LstDetails_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            if (e.Index < 0) return;
            var itemStr = lstDetails.Items[e.Index];
            if (_currentTab == "members")
            {
                e.ItemHeight = 60;
            }
            else if (_currentTab == "privileges" && itemStr is PrivItem p)
            {
                int tagRows = (int)Math.Ceiling(p.Tags.Length / 2.0);
                int baseHeight = 60;
                if (tagRows > 1)
                {
                    baseHeight += (tagRows - 1) * 32;
                }
                e.ItemHeight = baseHeight;
            }
        }

        // ================================================
        // VẼ THỦ CÔNG TỪNG ITEM TRONG LISTBOX CHI TIẾT (OwnerDraw)
        // Tab members : avatar tròn, tên user, badge "Active"
        // Tab privileges: tên đối tượng, loại (TABLE/VIEW/PROCEDURE),
        //                 các badge tag quyền xếp 2 cột từ phải sang trái
        // ================================================
        private void LstDetails_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            if (e.Index < 0) return;
            var itemStr = lstDetails.Items[e.Index];

            // Màu nền xen kẽ trắng/xanh rất nhạt
            var bg = (e.Index % 2 == 0) ? Color.White : Color.FromArgb(250, 252, 254);
            using (var b = new SolidBrush(bg)) e.Graphics.FillRectangle(b, e.Bounds);
            // Draw Separator line
            e.Graphics.DrawLine(new Pen(Color.FromArgb(240, 240, 240)), e.Bounds.X, e.Bounds.Bottom - 1, e.Bounds.Right, e.Bounds.Bottom - 1);

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            if (_currentTab == "members" && itemStr is MemberItem m)
            {
                // Avatar tròn với chữ viết tắt
                var avatarRect = new Rectangle(e.Bounds.X + 15, e.Bounds.Y + 15, 30, 30);
                e.Graphics.FillEllipse(new SolidBrush(m.Color), avatarRect);
                e.Graphics.DrawString(m.Initials, new Font("Segoe UI", 8, FontStyle.Bold), Brushes.White, avatarRect, new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });

                // Tên user
                e.Graphics.DrawString(m.Name, new Font("Segoe UI", 10, FontStyle.Regular), new SolidBrush(Color.FromArgb(10, 42, 64)), e.Bounds.X + 55, e.Bounds.Y + 20);

                // Badge trạng thái Active (cố định xanh vì mock data không có Locked)
                var activeLabel = new Rectangle(e.Bounds.Right - 65, e.Bounds.Y + 20, 50, 20);
                e.Graphics.FillRoundedRectangle(new SolidBrush(Color.FromArgb(235, 250, 240)), activeLabel, 10);
                e.Graphics.DrawString("Active", new Font("Segoe UI", 8), new SolidBrush(Color.FromArgb(46, 160, 67)), activeLabel, new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
            }
            else if (_currentTab == "privileges" && itemStr is PrivItem p)
            {
                // Tên đối tượng DB và loại (TABLE/VIEW/PROCEDURE)
                e.Graphics.DrawString(p.ObjName, new Font("Segoe UI", 10, FontStyle.Bold), new SolidBrush(Color.FromArgb(10, 42, 64)), e.Bounds.X + 15, e.Bounds.Y + 12);
                e.Graphics.DrawString(p.ObjType, new Font("Segoe UI", 8), new SolidBrush(Color.FromArgb(150, 160, 170)), e.Bounds.X + 15, e.Bounds.Y + 32);

                // Vẽ badge tag quyền: tối đa 2 tag mỗi hàng, căn phải
                int currentY = e.Bounds.Y + 18;
                for (int i = 0; i < p.Tags.Length; i += 2)
                {
                    int itemsInRow = Math.Min(2, p.Tags.Length - i);
                    int currentX = e.Bounds.Right - 20;

                    // Render backwards so itemsInRow-1 is left-most, 0 is right-most ensuring right-alignment
                    for (int j = itemsInRow - 1; j >= 0; j--)
                    {
                        string tag = p.Tags[i + j];
                        Color tagBg = Color.White;
                        Color tagFg = Color.Black;
                        if (tag == "SELECT") { tagBg = Color.FromArgb(238, 243, 250); tagFg = Color.FromArgb(60, 100, 160); }
                        else if (tag == "UPDATE") { tagBg = Color.FromArgb(254, 249, 230); tagFg = Color.FromArgb(180, 130, 40); }
                        else if (tag == "INSERT") { tagBg = Color.FromArgb(235, 250, 240); tagFg = Color.FromArgb(46, 160, 67); }
                        else if (tag == "EXECUTE") { tagBg = Color.FromArgb(245, 235, 250); tagFg = Color.FromArgb(130, 60, 180); }

                        int width = (int)e.Graphics.MeasureString(tag, new Font("Segoe UI", 8, FontStyle.Bold)).Width + 20;
                        currentX -= width;

                        var tagRect = new Rectangle(currentX, currentY, width, 24);
                        e.Graphics.FillRoundedRectangle(new SolidBrush(tagBg), tagRect, 12);
                        e.Graphics.DrawString(tag, new Font("Segoe UI", 8, FontStyle.Bold), new SolidBrush(tagFg), tagRect, new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });

                        currentX -= 5; // margin left
                    }
                    currentY += 32; // next row starts lower
                }
            }
        }
    }

    // ================================================
    // MODEL: RoleItem — đại diện cho 1 role Oracle trong hệ thống
    // Chứa danh sách thành viên (Members) và quyền (Privileges)
    // BgColor/IconColor: màu sắc hiển thị icon trong ListBox
    // ================================================
    public class RoleItem
    {
        public string Name { get; set; }
        public string Subtitle { get; set; }
        public Color BgColor { get; set; }
        public Color IconColor { get; set; }
        public List<MemberItem> Members { get; set; }
        public List<PrivItem> Privileges { get; set; }

        public int MemberCount => Members.Count;
        public int PrivilegeCount => Privileges.Count;

        public RoleItem(string n, string sub, Color bg, Color ic)
        {
            Name = n; Subtitle = sub; BgColor = bg; IconColor = ic;
            Members = new List<MemberItem>();
            Privileges = new List<PrivItem>();
        }
    }

    // ================================================
    // MODEL: MemberItem — đại diện cho 1 user thuộc role
    // Name    : username Oracle
    // Initials: 2 chữ viết tắt hiển thị trong avatar
    // Color   : màu nền avatar
    // ================================================
    public class MemberItem
    {
        public string Name { get; set; }
        public string Initials { get; set; }
        public Color Color { get; set; }
        public MemberItem(string n, string init, Color c) { Name = n; Initials = init; Color = c; }
    }

    // ================================================
    // MODEL: PrivItem — đại diện cho 1 object privilege của role
    // ObjName: tên đối tượng DB (bảng/view/procedure)
    // ObjType: loại đối tượng (TABLE / VIEW / PROCEDURE)
    // Tags   : mảng các loại quyền (SELECT, UPDATE, INSERT, EXECUTE)
    // ================================================
    public class PrivItem
    {
        public string ObjName { get; set; }
        public string ObjType { get; set; }
        public string[] Tags { get; set; }
        public PrivItem(string n, string t, string[] tags) { ObjName = n; ObjType = t; Tags = tags; }
    }
}