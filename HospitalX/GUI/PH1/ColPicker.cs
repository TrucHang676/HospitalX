using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using HospitalX.DAO;

namespace HospitalX.GUI.PH1
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

            LoadColumns(currentCols);

            // Wire events
            btnSelectAllCols.Click += (s, e) => SetAllChecked(true);
            btnClearAllCols.Click += (s, e) => SetAllChecked(false);
            btnCancelCol.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };
            btnCloseColPopup.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };
            btnExecuteGrant.Click += BtnExecuteGrant_Click;
            clbColumns.ItemCheck += (s, e) => {
                if (this.IsHandleCreated)
                {
                    this.BeginInvoke((Action)UpdateColCount);
                }
            };

        }

        private void LoadColumns(List<string> currentCols)
        {
            try
            {
                // Gọi stored procedure thay vì raw SQL (đẩy nghiệp vụ xuống Oracle)
                var parameters = new OracleParameter[] {
                    new OracleParameter("p_table_name", OracleDbType.Varchar2) { Value = _objectName.ToUpper() },
                    new OracleParameter("p_cursor", OracleDbType.RefCursor) { Direction = ParameterDirection.Output }
                };

                var dtColumns = DataProvider.Instance.ExecuteQuery("USP_GET_TABLE_COLUMNS", parameters, isStoredProc: true);

                clbColumns.Items.Clear();
                if (dtColumns != null && dtColumns.Rows.Count > 0)
                {
                    foreach (DataRow row in dtColumns.Rows)
                    {
                        string colName = row["COLUMN_NAME"].ToString();
                        bool alreadyChecked = currentCols.Contains(colName);
                        clbColumns.Items.Add(colName, alreadyChecked);
                    }
                }

                UpdateColCount();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh sách cột: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

                UpdateColCount();
            }
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