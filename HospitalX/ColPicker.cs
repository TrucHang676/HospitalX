using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HospitalX
{
    public partial class ColPicker : Form
    {
        // Property để ucGrantRevoke đọc kết quả sau khi ShowDialog()
        public List<string> SelectedColumns { get; private set; } = new List<string>();

        private readonly string _privType;      // "SELECT" hay "UPDATE"
        private readonly string _objectName;    // Tên bảng đang chọn

        // Constructor nhận đủ thông tin cần thiết
        public ColPicker(string privType, string objectName, List<string> currentCols)
        {
            InitializeComponent();
            _privType = privType;
            _objectName = objectName;

            // Set title và sub
            lblColPopupTitle.Text = $"Chọn cột cho quyền {privType}";
            // guna2HtmlLabel1 là label phụ (sub) trong designer của bạn
            lblNameObject.Text = $"Bảng: {objectName} · Chọn cột được phép truy cập";

            // Wire events
            btnSelectAllCols.Click += (s, e) => SetAllChecked(true);
            btnClearAllCols.Click += (s, e) => SetAllChecked(false);
            btnCancelCol.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };
            btnCloseColPopup.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };
            btnExecuteGrant.Click += BtnExecuteGrant_Click;
            clbColumns.ItemCheck += (s, e) => this.BeginInvoke((Action)UpdateColCount);

            // Load mock data — sau thay bằng query từ DB
            LoadColumns(currentCols);
        }

        private void LoadColumns(List<string> currentCols)
        {
            // Mock: sau này thay bằng query FN_LIST_COLUMNS từ Oracle
            var mockCols = new List<string>
            {
                "MANV","HOTEN","PHAI","NGAYSINH","CMND","SODT","VAITRO","CHUYENKHOA"
            };

            clbColumns.Items.Clear();
            foreach (var col in mockCols)
            {
                bool alreadyChecked = currentCols.Contains(col);
                clbColumns.Items.Add(col, alreadyChecked);
            }
            UpdateColCount();
        }

        private void UpdateColCount()
        {
            int selected = clbColumns.CheckedItems.Count;
            int total = clbColumns.Items.Count;
            lblSelectedColCount.Text = $"Đã chọn: {selected} / {total} cột";
        }

        private void SetAllChecked(bool check)
        {
            for (int i = 0; i < clbColumns.Items.Count; i++)
                clbColumns.SetItemChecked(i, check);
            UpdateColCount();
        }

        private void BtnExecuteGrant_Click(object sender, EventArgs e)
        {
            SelectedColumns.Clear();
            foreach (var item in clbColumns.CheckedItems)
                SelectedColumns.Add(item.ToString());

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}