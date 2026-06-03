using System;
using System.Windows.Forms;

namespace HospitalX.GUI.PH2.KyThuatVien
{
    public partial class frmKtvNotificationDetail : Form
    {
        public frmKtvNotificationDetail(
            string title, string type, string time, string tags, string body)
        {
            InitializeComponent();
            if (System.IO.File.Exists(@"d:\HospitalX\image\medical-team.ico"))
            {
                this.Icon = new System.Drawing.Icon(@"d:\HospitalX\image\medical-team.ico");
            }
            LoadData(title, type, time, tags, body);
            ConfigureReadOnlyTextBoxes();
        }

        private void LoadData(
            string title, string type, string time, string tags, string body)
        {
            txtNotifTitle.Text = title;
            txtNotifType.Text = type;
            txtNotifTime.Text = time;
            txtNotifTags.Text = tags;
            txtNotifBody.Text = body;
        }

        private void ConfigureReadOnlyTextBoxes()
        {
            var textBoxes = new Guna.UI2.WinForms.Guna2TextBox[] { txtNotifTitle, txtNotifType, txtNotifTime, txtNotifTags, txtNotifBody };
            foreach (var txt in textBoxes)
            {
                txt.Cursor = Cursors.Default;
                txt.TabStop = false;
                txt.HoverState.BorderColor = txt.BorderColor;
                txt.FocusedState.BorderColor = txt.BorderColor;
                txt.HoverState.FillColor = txt.FillColor;
                txt.FocusedState.FillColor = txt.FillColor;
                txt.Enter += (s, e) => this.ActiveControl = null;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
