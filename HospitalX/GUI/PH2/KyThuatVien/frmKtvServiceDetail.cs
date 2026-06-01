using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace HospitalX.GUI.PH2.KyThuatVien
{
    public class frmKtvServiceDetail : Form
    {
        private readonly string recordId;

        public frmKtvServiceDetail(string patientName, string recordId, string serviceName, string doctorName, string timeStr, string priority, string status, string room)
        {
            this.recordId = recordId;

            Text = "Chi tiết phân công";
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.None;
            BackColor = Color.White;
            Size = new Size(460, 620);
            ShowInTaskbar = false;

            BuildLayout(patientName, recordId, serviceName, doctorName, timeStr, priority, status, room);
        }

        private void BuildLayout(string patientName, string recordId, string serviceName, string doctorName, string timeStr, string priority, string status, string room)
        {
            var root = new Guna2Panel
            {
                Dock = DockStyle.Fill,
                BorderRadius = 14,
                BorderThickness = 1,
                BorderColor = KtvTheme.Border,
                FillColor = Color.White
            };
            root.ShadowDecoration.Enabled = true;
            root.ShadowDecoration.Color = KtvTheme.Teal;
            root.ShadowDecoration.Depth = 14;
            Controls.Add(root);

            var header = new Guna2Panel
            {
                Location = new Point(0, 0),
                Size = new Size(460, 76),
                FillColor = Color.White,
                CustomBorderColor = KtvTheme.Border,
                CustomBorderThickness = new Padding(0, 0, 0, 1)
            };

            var lblTitle = TextLabel("Chi tiết phân công", 24, 18, 300, 26, 13F, FontStyle.Bold, KtvTheme.TextDark);
            var lblSub = TextLabel(recordId, 24, 44, 260, 20, 8.8F, FontStyle.Regular, KtvTheme.TextLight);
            var btnClose = new Guna2Button
            {
                Text = "X",
                Size = new Size(34, 34),
                Location = new Point(402, 20),
                BorderRadius = 17,
                FillColor = Color.White,
                ForeColor = KtvTheme.TextLight,
                BorderColor = KtvTheme.Border,
                BorderThickness = 1,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnClose.HoverState.FillColor = KtvTheme.DangerSoft;
            btnClose.HoverState.ForeColor = KtvTheme.Danger;
            btnClose.Click += (s, e) => Close();
            header.Controls.AddRange(new Control[] { lblTitle, lblSub, btnClose });
            root.Controls.Add(header);

            var body = new Panel
            {
                Location = new Point(0, 76),
                Size = new Size(460, 468),
                AutoScroll = true,
                BackColor = Color.White
            };
            root.Controls.Add(body);

            int y = 22;
            body.Controls.Add(SectionLabel("THÔNG TIN BỆNH NHÂN", y));
            y += 30;
            AddInfoRow(body, "Họ tên", patientName, ref y);
            AddInfoRow(body, "Mã HSBA", recordId, ref y);
            AddInfoRow(body, "Ngày sinh", "12/03/1978", ref y);
            AddInfoRow(body, "Giới tính", "Nam", ref y);
            AddInfoRow(body, "Số điện thoại", "0912 345 678", ref y);

            y += 18;
            body.Controls.Add(SectionLabel("THÔNG TIN DỊCH VỤ", y));
            y += 30;
            AddInfoRow(body, "Tên dịch vụ", serviceName, ref y);
            AddInfoRow(body, "Phòng thực hiện", room, ref y);
            AddInfoRow(body, "Bác sĩ chỉ định", doctorName, ref y);
            AddInfoRow(body, "Giờ hẹn", timeStr, ref y);
            AddInfoRow(body, "Ưu tiên", priority, ref y);
            AddInfoRow(body, "Trạng thái", status, ref y);

            y += 18;
            body.Controls.Add(SectionLabel("GHI CHÚ CHỈ ĐỊNH", y));
            y += 28;
            var note = new Guna2Panel
            {
                Location = new Point(24, y),
                Size = new Size(400, 88),
                BorderRadius = 10,
                FillColor = KtvTheme.Bg
            };
            note.Controls.Add(TextLabel("Bệnh nhân có tiền sử tiểu đường type 2. Cần lấy mẫu máu tĩnh mạch trong trạng thái nhịn ăn ít nhất 8 giờ. Ưu tiên xử lý nhanh.", 14, 12, 370, 62, 9F, FontStyle.Regular, KtvTheme.TextMid));
            body.Controls.Add(note);

            var footer = new Guna2Panel
            {
                Location = new Point(0, 544),
                Size = new Size(460, 76),
                FillColor = Color.White,
                CustomBorderColor = KtvTheme.Border,
                CustomBorderThickness = new Padding(0, 1, 0, 0)
            };
            root.Controls.Add(footer);

            var btnResult = KtvTheme.Button("Nhập kết quả", KtvTheme.Teal, Color.White);
            btnResult.Location = new Point(24, 19);
            btnResult.Size = new Size(190, 38);
            btnResult.Click += BtnResult_Click;

            var btnCloseFoot = KtvTheme.Button("Đóng", Color.White, KtvTheme.TextMid);
            btnCloseFoot.Location = new Point(234, 19);
            btnCloseFoot.Size = new Size(190, 38);
            btnCloseFoot.BorderColor = KtvTheme.Border;
            btnCloseFoot.BorderThickness = 1;
            btnCloseFoot.Click += (s, e) => Close();

            footer.Controls.AddRange(new Control[] { btnResult, btnCloseFoot });
        }

        private void BtnResult_Click(object sender, EventArgs e)
        {
            Close();
            MessageBox.Show($"Chuyển sang phân hệ Nhập kết quả cho bệnh nhân mã {recordId}!", "HospitalX", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private Label SectionLabel(string text, int y)
        {
            return TextLabel(text, 24, y, 360, 20, 8.5F, FontStyle.Bold, KtvTheme.TextLight);
        }

        private void AddInfoRow(Control parent, string labelText, string valueText, ref int y)
        {
            var row = new Guna2Panel
            {
                Location = new Point(24, y),
                Size = new Size(400, 36),
                CustomBorderColor = Color.FromArgb(238, 242, 240),
                CustomBorderThickness = new Padding(0, 0, 0, 1),
                BackColor = Color.Transparent
            };

            row.Controls.Add(TextLabel(labelText, 0, 8, 140, 20, 9F, FontStyle.Regular, KtvTheme.TextLight));
            row.Controls.Add(TextLabel(valueText, 142, 8, 258, 20, 9F, FontStyle.Bold, KtvTheme.TextDark, ContentAlignment.MiddleRight));
            parent.Controls.Add(row);
            y += 36;
        }

        private Label TextLabel(string text, int x, int y, int width, int height, float size, FontStyle style, Color color, ContentAlignment align = ContentAlignment.MiddleLeft)
        {
            return new Label
            {
                Text = text,
                Location = new Point(x, y),
                Size = new Size(width, height),
                AutoSize = false,
                AutoEllipsis = true,
                TextAlign = align,
                Font = new Font("Segoe UI", size, style),
                ForeColor = color,
                BackColor = Color.Transparent
            };
        }
    }
}
