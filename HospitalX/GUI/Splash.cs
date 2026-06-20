using System;
using System.Drawing;
using System.Drawing.Drawing2D;
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
            LoadBrandingLogo();
            SetupGradientHospitalLabel();
        }

        private void LoadBrandingLogo()
        {
            var logoImg = LoadImageSafely("logoHX4-Photoroom.png");
            if (logoImg != null)
            {
                ptbChuThap.Image = logoImg;
                ptbChuThap.SizeMode = PictureBoxSizeMode.Zoom;
                // Căn giữa chính xác bên trong pnlLogo kích thước 130x130
                ptbChuThap.Location = new Point(20, 20);
                ptbChuThap.Size = new Size(90, 90);
            }
        }

        private void SetupGradientHospitalLabel()
        {
            // Xóa text mặc định để tự vẽ gradient
            lblHospital.Text = "";
            lblHospital.Paint += (s, e) =>
            {
                var label = (Label)s;
                var g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;

                string text = "HOSPITAL MANAGEMENT SYSTEM";
                using (var font = new Font(label.Font.FontFamily, label.Font.Size, label.Font.Style))
                {
                    var size = g.MeasureString(text, font);
                    float x = (label.Width - size.Width) / 2;
                    float y = (label.Height - size.Height) / 2;

                    using (var brush = new LinearGradientBrush(
                        new PointF(x, 0),
                        new PointF(x + size.Width, 0),
                        Color.FromArgb(20, 116, 91),   // Xanh lá
                        Color.FromArgb(23, 76, 145)))  // Xanh dương
                    {
                        g.DrawString(text, font, brush, x, y);
                    }
                }
            };
        }

        private Image LoadImageSafely(string filename)
        {
            try
            {
                string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                string imgPath = System.IO.Path.GetFullPath(System.IO.Path.Combine(baseDir, @"..\..\..\image\"));
                if (!System.IO.Directory.Exists(imgPath))
                    imgPath = System.IO.Path.GetFullPath(System.IO.Path.Combine(baseDir, @"image\"));
                string filePath = System.IO.Path.Combine(imgPath, filename);
                if (System.IO.File.Exists(filePath))
                {
                    return Image.FromFile(filePath);
                }
            }
            catch { }
            return null;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // Vùng chéo trái màu Mint
            Point[] shape = {
                new Point(0,0), new Point(500,0),
                new Point(220,700), new Point(0,700)
            };
            using (var b = new SolidBrush(ColorTranslator.FromHtml("#E2F4F0")))
                g.FillPolygon(b, shape);

            // Dot grid (chấm trang trí màu xanh ngọc nhạt)
            using (var b = new SolidBrush(ColorTranslator.FromHtml("#CBE6E0")))
                for (int x = 0; x < Width; x += 24)
                    for (int y = 0; y < Height; y += 24)
                        g.FillEllipse(b, x, y, 2, 2);

            // 4 góc bracket (giữ nguyên cấu trúc nguyên bản)
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

            // Khởi tạo và hiện màn chọn vai trò đăng nhập.
            var roleSelection = new RoleSelection();
            roleSelection.FormClosed += (s, e) => {
                Application.Exit();
            };
            roleSelection.Show();

            // Ẩn Splash đi
            this.Hide();
        }

        private void ptbChuThap_Click(object sender, EventArgs e)
        {

        }
    }
}
