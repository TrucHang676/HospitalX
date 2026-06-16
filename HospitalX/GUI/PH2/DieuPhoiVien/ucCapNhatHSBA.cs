using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace HospitalX.GUI.PH2.DieuPhoiVien
{
    public partial class ucCapNhatHSBA : UserControl
    {
        private List<MockHsbaItem> _mockList = null;
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
            LoadMockData();
            LoadDepartments();
            ApplyFilter();

            // Wire event handlers
            dgvHsba.SelectionChanged += DgvHsba_SelectionChanged;
            txtSearch.TextChanged += TxtSearch_TextChanged;
            cboKhoa.SelectedIndexChanged += CboKhoa_SelectedIndexChanged;
            cboBacSi.SelectedIndexChanged += CboBacSi_SelectedIndexChanged;
            btnUpdate.Click += BtnUpdate_Click;

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
        }

        private void LoadMockData()
        {
            _mockList = new List<MockHsbaItem>
            {
                new MockHsbaItem
                {
                    MaHsba = "BA-2026-0001", MaBn = "BN0001", TenBn = "Nguyễn Văn A", Ngay = "15/06/2026 08:30:15",
                    MaKhoa = "KTM", MaBs = "BS001", TenBs = "BS. Nguyễn Văn B",
                    ChanDoan = "Đau thắt ngực không ổn định, tăng huyết áp độ 2.",
                    DieuTri = "Theo dõi điện tâm đồ, dùng thuốc giãn mạch Nitroglycerin, thuốc chẹn beta.",
                    KetLuan = "Đã kiểm soát được huyết áp, cơn đau giảm dần. Cần tái khám chuyên khoa Tim mạch."
                },
                new MockHsbaItem
                {
                    MaHsba = "BA-2026-0002", MaBn = "BN0002", TenBn = "Trần Thị B", Ngay = "16/06/2026 09:15:24",
                    MaKhoa = "", MaBs = "", TenBs = "",
                    ChanDoan = "Đau thượng vị cấp, nghi ngờ viêm loét dạ dày tá tràng.",
                    DieuTri = "Truyền dịch bù nước điện giải, chuẩn bị thực hiện nội soi dạ dày.",
                    KetLuan = "Chờ kết quả nội soi tiêu hóa để lên phác đồ điều trị cụ thể."
                },
                new MockHsbaItem
                {
                    MaHsba = "BA-2026-0003", MaBn = "BN0003", TenBn = "Lê Văn C", Ngay = "16/06/2026 10:05:40",
                    MaKhoa = "KTK", MaBs = "BS005", TenBs = "BS. Hoàng Văn F",
                    ChanDoan = "Đau đầu dữ dội kèm chóng mặt, nghi ngờ thiếu máu não cục bộ thoáng qua.",
                    DieuTri = "Cho nằm đầu thấp, bổ sung dưỡng chất não, chụp MRI sọ não.",
                    KetLuan = "Cần theo dõi thêm biểu hiện thần kinh khu trú tại phòng bệnh chuyên khoa."
                },
                new MockHsbaItem
                {
                    MaHsba = "BA-2026-0004", MaBn = "BN0004", TenBn = "Phạm Thị D", Ngay = "16/06/2026 11:20:00",
                    MaKhoa = "", MaBs = "", TenBs = "",
                    ChanDoan = "Rối loạn nhịp tim chưa rõ nguyên nhân, đau ngực trái âm ỉ.",
                    DieuTri = "Đo ECG 24h (Holter), sẵn sàng xử lý cấp cứu nếu loạn nhịp nặng.",
                    KetLuan = "Chưa có kết luận cuối cùng, cần hội chẩn chuyên khoa sâu."
                }
            };
        }

        private void LoadDepartments()
        {
            cboKhoa.Items.Clear();
            cboKhoa.Items.Add(new DepartmentItem { MaKhoa = "", TenKhoa = "Chưa chọn khoa" });
            cboKhoa.Items.Add(new DepartmentItem { MaKhoa = "KTM", TenKhoa = "Khoa tim mạch" });
            cboKhoa.Items.Add(new DepartmentItem { MaKhoa = "KTH", TenKhoa = "Khoa tiêu hóa" });
            cboKhoa.Items.Add(new DepartmentItem { MaKhoa = "KTK", TenKhoa = "Khoa thần kinh" });
            cboKhoa.SelectedIndex = 0;
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

            if (maKhoa == "KTM")
            {
                cboBacSi.Items.Add(new DoctorItem { MaBS = "BS001", TenBS = "BS. Nguyễn Văn B" });
                cboBacSi.Items.Add(new DoctorItem { MaBS = "BS002", TenBS = "BS. Trần Văn C" });
            }
            else if (maKhoa == "KTH")
            {
                cboBacSi.Items.Add(new DoctorItem { MaBS = "BS003", TenBS = "BS. Lê Văn D" });
                cboBacSi.Items.Add(new DoctorItem { MaBS = "BS004", TenBS = "BS. Phạm Văn E" });
            }
            else if (maKhoa == "KTK")
            {
                cboBacSi.Items.Add(new DoctorItem { MaBS = "BS005", TenBS = "BS. Hoàng Văn F" });
                cboBacSi.Items.Add(new DoctorItem { MaBS = "BS006", TenBS = "BS. Vũ Văn G" });
            }
            
            cboBacSi.SelectedIndex = 0;
        }

        private void ApplyFilter()
        {
            if (_mockList == null) return;

            string selectedMaHsba = "";
            if (dgvHsba.SelectedRows.Count > 0)
            {
                selectedMaHsba = dgvHsba.SelectedRows[0].Cells[colMaHSBA.Index].Value?.ToString() ?? "";
            }

            dgvHsba.Rows.Clear();
            string search = txtSearch.Text.Trim().ToLower();

            int count = 0;
            DataGridViewRow selectTargetRow = null;

            foreach (var item in _mockList)
            {
                string bsDisplay = string.IsNullOrEmpty(item.MaBs) ? "Chưa chỉ định" : $"{item.TenBs} ({item.MaBs})";
                string khoaDisplay = string.IsNullOrEmpty(item.MaKhoa) ? "Chưa chọn khoa" : MapCodeToKhoa(item.MaKhoa);

                if (!string.IsNullOrEmpty(search))
                {
                    if (!item.MaHsba.ToLower().Contains(search) &&
                        !item.MaBn.ToLower().Contains(search) &&
                        !item.TenBn.ToLower().Contains(search))
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

            lblListSub.Text = $"Hiển thị {count} hồ sơ bệnh án";
            
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
            if (selectedRow.Tag is MockHsbaItem item)
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

                cboKhoa.Enabled = true;
                cboBacSi.Enabled = true;

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
            
            if (selectedRow.Tag is MockHsbaItem item)
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

                // Update mock list item on-the-fly to reflect changes immediately in UI
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

            txtSearch.Left = pnlListCard.Width - txtSearch.Width - 20;
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

        private class MockHsbaItem
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
        }
    }
}
