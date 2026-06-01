using System;
using System.Windows.Forms;

namespace HospitalX.GUI.PH2.KyThuatVien
{
    public partial class ucKtvFilter : UserControl
    {
        public event EventHandler FilterChanged;
        public event EventHandler ResetRequested;

        public ucKtvFilter()
        {
            InitializeComponent();
            cboStatus.SelectedIndex = 0;
        }

        public string SearchText
        {
            get => txtSearch.Text.Trim();
            set => txtSearch.Text = value ?? string.Empty;
        }

        public string SelectedStatus
        {
            get => cboStatus.SelectedItem?.ToString() ?? string.Empty;
            set
            {
                int index = cboStatus.Items.IndexOf(value);
                cboStatus.SelectedIndex = index >= 0 ? index : 0;
            }
        }

        public int SelectedStatusIndex
        {
            get => cboStatus.SelectedIndex;
            set => cboStatus.SelectedIndex = value >= 0 && value < cboStatus.Items.Count ? value : 0;
        }

        public void ResetFilter()
        {
            txtSearch.Clear();
            cboStatus.SelectedIndex = 0;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            FilterChanged?.Invoke(this, EventArgs.Empty);
        }

        private void cboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterChanged?.Invoke(this, EventArgs.Empty);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetFilter();
            ResetRequested?.Invoke(this, EventArgs.Empty);
            FilterChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
