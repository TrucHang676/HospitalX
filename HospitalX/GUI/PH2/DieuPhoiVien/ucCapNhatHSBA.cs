using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace HospitalX.GUI.PH2.DieuPhoiVien
{
    public partial class ucCapNhatHSBA : UserControl
    {
        private List<HsbaItem> _hsbaList = null;
        private string _originalMaKhoa = "";
        private string _originalMaBs = "";
        private bool _isSelectingRow = false;

        public ucCapNhatHSBA()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            
            ConfigureStyles();
            
            cboFacilityFilter.Visible = false;

            LoadHsbaData();
            LoadDepartments();
            ApplyFilter();

            // Wire event handlers
            dgvHsba.SelectionChanged += DgvHsba_SelectionChanged;
            txtSearch.TextChanged += TxtSearch_TextChanged;
            cboKhoa.SelectedIndexChanged += CboKhoa_SelectedIndexChanged;
            cboBacSi.SelectedIndexChanged += CboBacSi_SelectedIndexChanged;
            btnUpdate.Click += BtnUpdate_Click;
            cboDeptFilter.SelectedIndexChanged += (s, ev) => ApplyFilter();

            // Handle responsiveness
            this.Resize += (s, ev) => AdjustLayout();
            AdjustLayout();
        }

        private void ConfigureStyles()
        {
            lblListTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblListTitle.ForeColor = Color.FromArgb(10, 42, 64);
            lblListSub.Font = new Font("Segoe UI", 8.5F, FontStyle.Regular);
            lblListSub.ForeColor = Color.FromArgb(122, 149, 137);

            lblDetailTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblDetailTitle.ForeColor = Color.FromArgb(10, 42, 64);
            lblDetailSub.Font = new Font("Segoe UI", 8.5F, FontStyle.Regular);
            lblDetailSub.ForeColor = Color.FromArgb(122, 149, 137);

            // Styling search box with magnifying-glass icon matching ucTaoHSBA
            txtSearch.Width = 380;
            txtSearch.IconLeft = DpvAssets.Load("magnifying-glass.png");
            txtSearch.IconLeftSize = new Size(16, 16);
            txtSearch.IconLeftOffset = new Point(10, 0);
            txtSearch.TextOffset = new Point(10, 0);
            txtSearch.FillColor = Color.FromArgb(247, 249, 248);
            txtSearch.PlaceholderForeColor = Color.FromArgb(180, 195, 188);
            txtSearch.BorderColor = Color.FromArgb(218, 232, 226);
            txtSearch.FocusedState.BorderColor = Color.FromArgb(15, 110, 86);
            txtSearch.HoverState.BorderColor = Color.FromArgb(15, 110, 86);
            txtSearch.Font = new Font("Segoe UI", 9.75F);
            txtSearch.ForeColor = Color.FromArgb(24, 48, 42);

            // Grid header styling
            var headerBack = Color.FromArgb(247, 249, 248);
            var headerFore = Color.FromArgb(122, 149, 137);

            dgvHsba.EnableHeadersVisualStyles = false;
            dgvHsba.ColumnHeadersDefaultCellStyle.BackColor = headerBack;
            dgvHsba.ColumnHeadersDefaultCellStyle.ForeColor = headerFore;
            dgvHsba.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            dgvHsba.ColumnHeadersDefaultCellStyle.SelectionBackColor = headerBack;
            dgvHsba.ColumnHeadersDefaultCellStyle.SelectionForeColor = headerFore;
            dgvHsba.ColumnHeadersHeight = 36;

            dgvHsba.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dgvHsba.DefaultCellStyle.ForeColor = Color.FromArgb(24, 48, 42);
            dgvHsba.DefaultCellStyle.BackColor = Color.White;
            dgvHsba.DefaultCellStyle.SelectionBackColor = Color.FromArgb(230, 244, 240);
            dgvHsba.DefaultCellStyle.SelectionForeColor = Color.FromArgb(24, 48, 42);
            dgvHsba.RowTemplate.Height = 48;

            cboFacilityFilter.Visible = false;

            cboDeptFilter.Height = 36;
            cboDeptFilter.BorderRadius = 8;
            cboDeptFilter.FillColor = Color.FromArgb(247, 249, 248);
            cboDeptFilter.BorderColor = Color.FromArgb(218, 232, 226);
            cboDeptFilter.FocusedState.BorderColor = Color.FromArgb(15, 110, 86);
            cboDeptFilter.HoverState.BorderColor = Color.FromArgb(15, 110, 86);
            cboDeptFilter.Font = new Font("Segoe UI", 9.75F);
            cboDeptFilter.ForeColor = Color.FromArgb(24, 48, 42);
        }

        private void LoadHsbaData()
        {
            _hsbaList = new List<HsbaItem>();
            try
            {
                System.Data.DataTable dt = HospitalX.DAO.HsbaDAO.GetHsbaForDieuPhoi();
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (System.Data.DataRow row in dt.Rows)
                    {
                        var item = new HsbaItem
                        {
                            MaHsba = row["MAHSBA"] != DBNull.Value ? row["MAHSBA"].ToString().Trim() : "",
                            MaBn = row["MABN"] != DBNull.Value ? row["MABN"].ToString().Trim() : "",
                            TenBn = row["TEN_BENH_NHAN"] != DBNull.Value ? row["TEN_BENH_NHAN"].ToString().Trim() : "",
                            Ngay = row["NGAY"] != DBNull.Value ? Convert.ToDateTime(row["NGAY"]).ToString("dd/MM/yyyy HH:mm:ss") : "",
                            ChanDoan = row["CHANDOAN"] != DBNull.Value ? row["CHANDOAN"].ToString().Trim() : "",
                            DieuTri = row["DIEUTRI"] != DBNull.Value ? row["DIEUTRI"].ToString().Trim() : "",
                            MaBs = row["MABS"] != DBNull.Value ? row["MABS"].ToString().Trim() : "",
                            MaKhoa = row["MAKHOA"] != DBNull.Value ? row["MAKHOA"].ToString().Trim() : "",
                            TenBs = row["TEN_BACSI"] != DBNull.Value ? row["TEN_BACSI"].ToString().Trim() : "",
                            KetLuan = row["KETLUAN"] != DBNull.Value ? row["KETLUAN"].ToString().Trim() : "",
                            CungCoSo = row.Table.Columns.Contains("CUNG_CO_SO") && row["CUNG_CO_SO"] != DBNull.Value ? Convert.ToInt32(row["CUNG_CO_SO"]) : 1
                        };

                        if (string.IsNullOrEmpty(item.MaKhoa) && row["CHUYENKHOA_BACSI"] != DBNull.Value)
                        {
                            item.MaKhoa = MapKhoaToCode(row["CHUYENKHOA_BACSI"].ToString().Trim());
                        }

                        _hsbaList.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                ShowDialog("Lỗi", "Không thể tải danh sách hồ sơ bệnh án từ cơ sở dữ liệu.\nChi tiết: " + ex.Message, MessageDialogIcon.Error);
            }
        }

        private void LoadDepartments()
        {
            cboKhoa.Items.Clear();
            cboKhoa.Items.Add(new DepartmentItem { MaKhoa = "", TenKhoa = "Chưa chọn khoa" });

            cboDeptFilter.Items.Clear();
            
            try
            {
                System.Data.DataTable dt = HospitalX.DAO.HsbaDAO.GetDepartments();
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (System.Data.DataRow row in dt.Rows)
                    {
                        if (row["CHUYENKHOA"] != DBNull.Value)
                        {
                            string tenKhoa = row["CHUYENKHOA"].ToString().Trim();
                            string maKhoa = MapKhoaToCode(tenKhoa);
                            cboKhoa.Items.Add(new DepartmentItem { MaKhoa = maKhoa, TenKhoa = tenKhoa });
                            cboDeptFilter.Items.Add(new DepartmentItem { MaKhoa = maKhoa, TenKhoa = tenKhoa });
                        }
                    }
                }
            }
            catch
            {
                // Fallback
                cboKhoa.Items.Add(new DepartmentItem { MaKhoa = "KTM", TenKhoa = "Khoa tim mạch" });
                cboKhoa.Items.Add(new DepartmentItem { MaKhoa = "KTH", TenKhoa = "Khoa tiêu hóa" });
                cboKhoa.Items.Add(new DepartmentItem { MaKhoa = "KTK", TenKhoa = "Khoa thần kinh" });

                cboDeptFilter.Items.Add(new DepartmentItem { MaKhoa = "KTM", TenKhoa = "Khoa tim mạch" });
                cboDeptFilter.Items.Add(new DepartmentItem { MaKhoa = "KTH", TenKhoa = "Khoa tiêu hóa" });
                cboDeptFilter.Items.Add(new DepartmentItem { MaKhoa = "KTK", TenKhoa = "Khoa thần kinh" });
            }
            
            cboKhoa.SelectedIndex = 0;
            cboDeptFilter.SelectedIndex = 0;
        }

        private void LoadDoctorsForDepartment(string maKhoa)
        {
            cboBacSi.Items.Clear();
            cboBacSi.Items.Add(new DoctorItem { MaBS = "", TenBS = "Chưa chỉ định bác sĩ" });
            
            if (string.IsNullOrEmpty(maKhoa))
            {
                cboBacSi.SelectedIndex = 0;
                return;
            }

            string specialty = MapCodeToKhoa(maKhoa);
            try
            {
                System.Data.DataTable dt = HospitalX.DAO.HsbaDAO.GetDoctorsForTaoHSBA(specialty);
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (System.Data.DataRow row in dt.Rows)
                    {
                        string maBs = row["MANV"].ToString().Trim();
                        string tenBs = row["HOTEN"].ToString().Trim();
                        cboBacSi.Items.Add(new DoctorItem { MaBS = maBs, TenBS = tenBs });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Loi doc danh sach bac si: " + ex.Message);
            }
            
            cboBacSi.SelectedIndex = 0;
        }

        private void ApplyFilter()
        {
            if (_hsbaList == null) return;

            string selectedMaHsba = "";
            if (dgvHsba.SelectedRows.Count > 0)
            {
                selectedMaHsba = dgvHsba.SelectedRows[0].Cells[colMaHSBA.Index].Value?.ToString() ?? "";
            }

            string selectedDept = "";
            if (cboDeptFilter.SelectedItem is DepartmentItem selectedDeptItem)
            {
                selectedDept = selectedDeptItem.MaKhoa;
            }

            dgvHsba.Rows.Clear();
            string search = txtSearch.Text.Trim().ToLower();

            int count = 0;
            DataGridViewRow selectTargetRow = null;

            foreach (var item in _hsbaList)
            {
                if (!string.IsNullOrEmpty(selectedDept) && item.MaKhoa != selectedDept)
                {
                    continue;
                }

                string bsDisplay = string.IsNullOrEmpty(item.MaBs) ? "Chưa chỉ định" : $"{item.TenBs} ({item.MaBs})";
                string khoaDisplay = string.IsNullOrEmpty(item.MaKhoa) ? "Chưa chọn khoa" : MapCodeToKhoa(item.MaKhoa);

                if (!string.IsNullOrEmpty(search))
                {
                    if (!item.MaHsba.ToLower().Contains(search) &&
                        !item.MaBn.ToLower().Contains(search) &&
                        !item.TenBn.ToLower().Contains(search) &&
                        !item.MaBs.ToLower().Contains(search) &&
                        !item.TenBs.ToLower().Contains(search))
                    {
                        continue;
                    }
                }

                int rowIndex = dgvHsba.Rows.Add();
                DataGridViewRow dgvRow = dgvHsba.Rows[rowIndex];
                dgvRow.Tag = item;

                dgvRow.Cells[colMaHSBA.Index].Value = item.MaHsba;
                dgvRow.Cells[colMaBN.Index].Value = item.MaBn;
                dgvRow.Cells[colTenBN.Index].Value = item.TenBn;
                dgvRow.Cells[colNgay.Index].Value = item.Ngay.Split(' ')[0];
                dgvRow.Cells[colKhoa.Index].Value = khoaDisplay;
                dgvRow.Cells[colBacSi.Index].Value = bsDisplay;

                if (item.MaHsba == selectedMaHsba)
                {
                    selectTargetRow = dgvRow;
                }

                count++;
            }

            if (count == 0)
            {
                lblListSub.Text = "Chưa có hồ sơ bệnh án nào";
            }
            else
            {
                lblListSub.Text = $"Hiển thị {count} hồ sơ bệnh án";
            }
            
            dgvHsba.ClearSelection();
            dgvHsba.CurrentCell = null;
            
            if (selectTargetRow != null)
            {
                selectTargetRow.Selected = true;
            }
            else
            {
                ClearDetails();
            }
        }

        private void ClearDetails()
        {
            txtMaHSBA.Text = "";
            txtTenBN.Text = "";
            txtNgayTao.Text = "";
            txtChanDoan.Text = "";
            txtDieuTri.Text = "";
            txtKetLuan.Text = "";
            
            cboKhoa.Enabled = false;
            cboBacSi.Enabled = false;
            lblWarning.Visible = false;
            if (cboKhoa.Items.Count > 0) cboKhoa.SelectedIndex = 0;
            if (cboBacSi.Items.Count > 0) cboBacSi.SelectedIndex = 0;
            
            btnUpdate.Enabled = false;
        }

        private void DgvHsba_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvHsba.SelectedRows.Count == 0)
            {
                ClearDetails();
                return;
            }

            var selectedRow = dgvHsba.SelectedRows[0];
            if (selectedRow.Tag is HsbaItem item)
            {
                _isSelectingRow = true;
                _originalMaKhoa = item.MaKhoa;
                _originalMaBs = item.MaBs;

                txtMaHSBA.Text = item.MaHsba;
                txtTenBN.Text = $"{item.TenBn} ({item.MaBn})";
                txtNgayTao.Text = item.Ngay;
                txtChanDoan.Text = item.ChanDoan;
                txtDieuTri.Text = item.DieuTri;
                txtKetLuan.Text = item.KetLuan;

                bool isEditable = (item.CungCoSo == 1);
                cboKhoa.Enabled = isEditable;
                cboBacSi.Enabled = isEditable;
                lblWarning.Visible = !isEditable;

                // Select khoa in combobox
                bool foundKhoa = false;
                for (int i = 0; i < cboKhoa.Items.Count; i++)
                {
                    if (cboKhoa.Items[i] is DepartmentItem dept && dept.MaKhoa == item.MaKhoa)
                    {
                        cboKhoa.SelectedIndex = i;
                        foundKhoa = true;
                        break;
                    }
                }
                if (!foundKhoa && cboKhoa.Items.Count > 0)
                {
                    cboKhoa.SelectedIndex = 0;
                }

                // Select doctor in combobox
                bool foundBs = false;
                for (int i = 0; i < cboBacSi.Items.Count; i++)
                {
                    if (cboBacSi.Items[i] is DoctorItem doc && doc.MaBS == item.MaBs)
                    {
                        cboBacSi.SelectedIndex = i;
                        foundBs = true;
                        break;
                    }
                }
                if (!foundBs && cboBacSi.Items.Count > 0)
                {
                    cboBacSi.SelectedIndex = 0;
                }

                _isSelectingRow = false;
                btnUpdate.Enabled = false;
            }
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void CboKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboKhoa.SelectedItem is DepartmentItem selectedDept)
            {
                LoadDoctorsForDepartment(selectedDept.MaKhoa);
            }
            else
            {
                LoadDoctorsForDepartment("");
            }
            CheckForChanges();
        }

        private void CboBacSi_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckForChanges();
        }

        private void CheckForChanges()
        {
            if (_isSelectingRow) return;
            if (dgvHsba.SelectedRows.Count == 0)
            {
                btnUpdate.Enabled = false;
                return;
            }

            var selectedRow = dgvHsba.SelectedRows[0];
            if (selectedRow.Tag is HsbaItem item && item.CungCoSo == 0)
            {
                btnUpdate.Enabled = false;
                return;
            }

            string currentMaKhoa = "";
            if (cboKhoa.SelectedItem is DepartmentItem selectedDept)
            {
                currentMaKhoa = selectedDept.MaKhoa;
            }

            string currentMaBs = "";
            if (cboBacSi.SelectedItem is DoctorItem selectedDoc)
            {
                currentMaBs = selectedDoc.MaBS;
            }

            btnUpdate.Enabled = (currentMaKhoa != _originalMaKhoa || currentMaBs != _originalMaBs);
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvHsba.SelectedRows.Count == 0) return;
            var selectedRow = dgvHsba.SelectedRows[0];
            
            if (selectedRow.Tag is HsbaItem item)
            {
                string maKhoa = "";
                string tenKhoa = "Chưa chọn khoa";
                if (cboKhoa.SelectedItem is DepartmentItem selectedDept)
                {
                    maKhoa = selectedDept.MaKhoa;
                    tenKhoa = selectedDept.TenKhoa;
                }

                string maBs = "";
                string tenBs = "Chưa chỉ định";
                if (cboBacSi.SelectedItem is DoctorItem selectedDoc)
                {
                    maBs = selectedDoc.MaBS;
                    tenBs = selectedDoc.TenBS;
                }

                // Update database
                bool dbSuccess = false;
                string dbError = "";
                try
                {
                    dbSuccess = HospitalX.DAO.HsbaDAO.UpdateHsbaDepartmentAndDoctor(item.MaHsba, maKhoa, maBs);
                }
                catch (Exception ex)
                {
                    dbSuccess = false;
                    dbError = ex.Message;
                }

                if (!dbSuccess)
                {
                    ShowDialog("Lỗi Cơ Sở Dữ Liệu", "Không thể cập nhật hồ sơ bệnh án.\nChi tiết lỗi: " + dbError, MessageDialogIcon.Error);
                    return;
                }

                // Update item on-the-fly to reflect changes immediately in UI
                item.MaKhoa = maKhoa;
                item.MaBs = maBs;
                item.TenBs = tenBs;

                _originalMaKhoa = maKhoa;
                _originalMaBs = maBs;

                ShowDialog("Thành công", $"Cập nhật hồ sơ bệnh án {item.MaHsba} thành công!\n- Khoa: {tenKhoa}\n- Bác sĩ: {tenBs} ({maBs})", MessageDialogIcon.Information);
                
                // Refresh grid binding
                int selectedIndex = selectedRow.Index;
                ApplyFilter();
                
                if (dgvHsba.Rows.Count > selectedIndex)
                {
                    dgvHsba.Rows[selectedIndex].Selected = true;
                }
            }
        }

        private void ShowDialog(string caption, string message, MessageDialogIcon icon)
        {
            guna2MessageDialog1.Parent = this.FindForm();
            guna2MessageDialog1.Icon = icon;
            guna2MessageDialog1.Buttons = MessageDialogButtons.OK;
            guna2MessageDialog1.Caption = caption;
            guna2MessageDialog1.Style = MessageDialogStyle.Light;
            guna2MessageDialog1.Show(message);
        }

        private string MapCodeToKhoa(string code)
        {
            if (string.IsNullOrEmpty(code)) return "";
            string upper = code.ToUpper();
            if (upper == "KTM") return "Khoa tim mạch";
            if (upper == "KTK") return "Khoa thần kinh";
            if (upper == "KTH") return "Khoa tiêu hóa";
            return code;
        }

        private string MapKhoaToCode(string text)
        {
            if (string.IsNullOrEmpty(text)) return "";
            string lower = text.ToLower();
            if (lower.Contains("tim mạch") || lower.Contains("ktm")) return "KTM";
            if (lower.Contains("thần kinh") || lower.Contains("ktk")) return "KTK";
            if (lower.Contains("tiêu hóa") || lower.Contains("kth")) return "KTH";
            
            int start = text.IndexOf('(');
            int end = text.IndexOf(')');
            if (start >= 0 && end > start)
            {
                return text.Substring(start + 1, end - start - 1);
            }
            return text.Length > 10 ? text.Substring(0, 10) : text;
        }

        private void AdjustLayout()
        {
            int leftW = pnlScroll.ClientSize.Width - 440;
            if (leftW < 600) leftW = 600;
            int rightX = leftW + 30;
            int rightW = pnlScroll.ClientSize.Width - rightX - 20;
            if (rightW < 360) rightW = 360;

            pnlListCard.Width = leftW;
            pnlListCard.Height = pnlScroll.ClientSize.Height - 40;

            pnlDetailCard.Location = new Point(rightX, 20);
            pnlDetailCard.Width = rightW;
            pnlDetailCard.Height = pnlScroll.ClientSize.Height - 40;

            int gap = 10;
            txtSearch.Width = 200;
            txtSearch.Left = pnlListCard.Width - txtSearch.Width - 20;

            cboFacilityFilter.Visible = false;

            cboDeptFilter.Width = 180; // Increased width to contain full department name
            cboDeptFilter.Left = txtSearch.Left - cboDeptFilter.Width - gap;
            cboDeptFilter.Top = txtSearch.Top;

            dgvHsba.Width = pnlListCard.Width - 40;
            dgvHsba.Height = pnlListCard.Height - dgvHsba.Top - 20;

            int cardInnerW = pnlDetailCard.Width - 40;
            
            int halfW = (cardInnerW - 15) / 2;
            txtMaHSBA.Width = halfW;
            lblTenBNLabel.Left = txtMaHSBA.Right + 15;
            txtTenBN.Left = txtMaHSBA.Right + 15;
            txtTenBN.Width = halfW;

            txtNgayTao.Width = cardInnerW;
            txtChanDoan.Width = cardInnerW;
            txtDieuTri.Width = cardInnerW;
            txtKetLuan.Width = cardInnerW;
            cboKhoa.Width = cardInnerW;
            cboBacSi.Width = cardInnerW;
            btnUpdate.Width = cardInnerW;

            btnUpdate.Top = pnlDetailCard.Height - btnUpdate.Height - 20;

            lblWarning.Width = cardInnerW;
            lblWarning.Top = btnUpdate.Top - lblWarning.Height - 15;
        }

        private class DepartmentItem
        {
            public string MaKhoa { get; set; }
            public string TenKhoa { get; set; }
            public override string ToString()
            {
                return TenKhoa;
            }
        }

        private class DoctorItem
        {
            public string MaBS { get; set; }
            public string TenBS { get; set; }
            public override string ToString()
            {
                return string.IsNullOrEmpty(MaBS) ? TenBS : $"{TenBS} ({MaBS})";
            }
        }

        private class HsbaItem
        {
            public string MaHsba { get; set; }
            public string MaBn { get; set; }
            public string TenBn { get; set; }
            public string Ngay { get; set; }
            public string MaKhoa { get; set; }
            public string MaBs { get; set; }
            public string TenBs { get; set; }
            public string ChanDoan { get; set; }
            public string DieuTri { get; set; }
            public string KetLuan { get; set; }
            public int CungCoSo { get; set; }
        }
    }
}

