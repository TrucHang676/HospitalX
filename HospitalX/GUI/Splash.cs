using System;
using System.Drawing;
using System.Windows.Forms;

namespace HospitalX.GUI
{
    public partial class Splash : Form
    {
        private int _progress = 0;

        private readonly (int pct, string txt)[] _steps = {
            (8,  "Khởi tạo kết nối Oracle..."),
            (20, "Tải cấu hình hệ thống..."),
            (35, "Kiểm tra Oracle Data Provider..."),
            (50, "Xác thực phiên làm việc..."),
            (65, "Tải danh sách đối tượng..."),
            (78, "Kiểm tra quyền BVDBA..."),
            (90, "Chuẩn bị giao diện..."),
            (100,"Sẵn sàng!"),
        };
        private int _stepIndex = 0;

        public Splash()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Vùng chéo trái xanh nhạt
            Point[] shape = {
                new Point(0,0), new Point(400,0),
                new Point(250,700), new Point(0,700)
            };
            using (var b = new SolidBrush(ColorTranslator.FromHtml("#E2EEF7")))
                g.FillPolygon(b, shape);

            // Dot grid (chấm trang trí)
            using (var b = new SolidBrush(ColorTranslator.FromHtml("#C8DAE8")))
                for (int x = 0; x < Width; x += 24)
                    for (int y = 0; y < Height; y += 24)
                        g.FillEllipse(b, x, y, 2, 2);

            // 4 góc bracket
            using (var pen = new Pen(ColorTranslator.FromHtml("#0078B4"), 2f))
            {
                int s = 20, m = 14;
                g.DrawLine(pen, m, m, m + s, m);       // TL ngang
                g.DrawLine(pen, m, m, m, m + s);       // TL dọc
                g.DrawLine(pen, Width - m, m, Width - m - s, m);    // TR ngang
                g.DrawLine(pen, Width - m, m, Width - m, m + s);    // TR dọc
                g.DrawLine(pen, m, Height - m, m + s, Height - m);  // BL ngang
                g.DrawLine(pen, m, Height - m, m, Height - m - s);  // BL dọc
                g.DrawLine(pen, Width - m, Height - m, Width - m - s, Height - m); // BR ngang
                g.DrawLine(pen, Width - m, Height - m, Width - m, Height - m - s); // BR dọc
            }
        }

        private void Splash_Load(object sender, EventArgs e)
        {
            if (_steps.Length > 0) lblStatus.Text = _steps[0].txt;
            timerSplash.Start();
        }

        private void timerSplash_Tick(object sender, EventArgs e)
        {
            if (_stepIndex >= _steps.Length)
            {
                timerSplash.Stop();
                ChuyenSangLogin();
                return;
            }

            var step = _steps[_stepIndex];

            if (_progress < step.pct)
            {
                _progress += 2;
                if (progressBar.Value < progressBar.Maximum) // Tránh lỗi vượt quá 100
                    progressBar.Value = _progress;
                lblPercent.Text = _progress + "%";
            }
            else
            {
                _stepIndex++;
                if (_stepIndex < _steps.Length)
                {
                    lblStatus.Text = _steps[_stepIndex].txt;
                }
            }
        }

        private async void ChuyenSangLogin()
        {
            // Đợi một chút để người dùng kịp thấy trạng thái "Sẵn sàng!"
            await System.Threading.Tasks.Task.Delay(500);

            // Khởi tạo và hiện Login
            var login = new Login();
            login.Show();

            // Ẩn Splash đi
            this.Hide();
        }

        private void ptbChuThap_Click(object sender, EventArgs e)
        {

        }
    }
}
