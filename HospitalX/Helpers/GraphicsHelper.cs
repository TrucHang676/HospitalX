using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace HospitalX.Helpers
{
    public static class GraphicsHelper
    {
        public static void FillRoundedRectangle(this Graphics g, Brush b, Rectangle r, int radius)
        {
            if (g == null) throw new ArgumentNullException(nameof(g));
            if (b == null) throw new ArgumentNullException(nameof(b));
            using (GraphicsPath path = RoundedRect(r, radius))
            {
                g.FillPath(b, path);
            }
        }

        public static void DrawRoundedRectangle(this Graphics g, Pen p, Rectangle r, int radius)
        {
            if (g == null) throw new ArgumentNullException(nameof(g));
            if (p == null) throw new ArgumentNullException(nameof(p));
            using (GraphicsPath path = RoundedRect(r, radius))
            {
                g.DrawPath(p, path);
            }
        }

        private static GraphicsPath RoundedRect(Rectangle r, int radius)
        {
            int d = radius * 2;
            GraphicsPath path = new GraphicsPath();
            if (radius <= 0)
            {
                path.AddRectangle(r);
                return path;
            }
            
            // Ensure diameter is not larger than rectangle dimensions
            if (d > r.Width) d = r.Width;
            if (d > r.Height) d = r.Height;

            path.AddArc(r.X, r.Y, d, d, 180, 90);
            path.AddArc(r.Right - d, r.Y, d, d, 270, 90);
            path.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
            path.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}
