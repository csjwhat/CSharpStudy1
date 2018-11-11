using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;

namespace MyPlotterDelegate
{
    public class Plotter
    {
        const float X_MAX_ = 2.0f;
        const float Y_MAX_ = 2.0f;
        const float DIV_ = 4.0f;
        const float X_PX_ = 50;
        const float Y_PX_ = 50;
        const float WO_ = X_PX_ * DIV_;
        const float HO_ = Y_PX_ * DIV_;
        const float DX_ = 0.5f / X_PX_;

        readonly Graphics gr_;
        readonly PointF[] points_ = new PointF[2 * (int)(X_PX_ * DIV_) + 1];
        readonly RectangleF rect_ = new RectangleF(-X_PX_ * X_MAX_, -Y_PX_ * Y_MAX_, WO_, HO_);

        public Plotter(Size size, Graphics gr)
        {
            gr_ = gr;
            gr_.ResetTransform();
            gr_.TranslateTransform(size.Width / 2, size.Height / 2 - 30);
        }

        public void Axis()
        {
            gr_.FillRectangle(Brushes.White, rect_);

            Font myFont = new Font("Courier new", 12);

            for (int n = -(int)X_MAX_; n <= X_MAX_; n++)
                gr_.DrawLine(Pens.Black, X_PX_ * n, HO_ / 2, X_PX_ * n, -HO_ / 2);
            for (int n = -(int)X_MAX_; n <= X_MAX_; n += 2)
                gr_.DrawString(String.Format("{0,2}", n), myFont, Brushes.Black, n * X_PX_ - 17, HO_ / 2 + 6);

            for (int n = -(int)Y_MAX_; n <= Y_MAX_; n++)
                gr_.DrawLine(Pens.Black, -WO_ / 2, Y_PX_ * n, WO_ / 2, Y_PX_ * n);
            for (int n = -(int)Y_MAX_; n <= (int)Y_MAX_; n += 2)
                gr_.DrawString(String.Format("{0,2}", n), myFont, Brushes.Black, -WO_ / 2 - 26, -Y_PX_ * n - 10);
        }

        public void Execute(Pen myPen, Func<double, double> fx)
        {
            for (int n = 0; n < points_.Length; n++)
            {
                float x = DX_ * n - X_MAX_;
                points_[n] = new PointF(X_PX_ * x, -Y_PX_ * (float)fx(x));
            }

            gr_.SetClip(rect_);
            gr_.SmoothingMode = SmoothingMode.AntiAlias;

            gr_.DrawLines(myPen, points_);
            gr_.SmoothingMode = SmoothingMode.Default;
            gr_.ResetClip();
        }

    }
}
