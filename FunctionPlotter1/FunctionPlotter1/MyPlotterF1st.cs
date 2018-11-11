using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;

namespace MyPlotterF1st
{
    public class Plotter1st
    {
        const float X_MAX_ = 2.0f; // Xの値のMax値
        const float Y_MAX_ = 2.0f; // Yの値のMax値
        const float DIV_ = 4.0f;   // X方向の分割数
        const float X_PX_ = 50;    // X方向のピクセル数
        const float Y_PX_ = 50;    // Y方向のピクセル数
        const float WO_ = X_PX_ * DIV_;    // はば
        const float HO_ = Y_PX_ * DIV_;    // 高さ
        const float DX_ = 0.5f / X_PX_;    // 罫線描画時のX方向増分

        readonly Graphics gr_;
        readonly PointF[] points_ = new PointF[2 * (int)(X_PX_ * DIV_) + 1]; // 点の数は81個
        readonly RectangleF rect_ = new RectangleF(-X_PX_ * X_MAX_, -Y_PX_ * Y_MAX_, WO_, HO_);

        // コンストラクタ
        public Plotter1st(Size size, Graphics gr)
        {
            gr_ = gr;
            gr_.ResetTransform();
            gr_.TranslateTransform(size.Width / 2, size.Height / 2 - 30); // 原点の変更
        }

        // 描画領域を示す四角形と座標軸の描画
        public void Axis()
        {
            // 描画領域を示す四角形と座標軸の描画
            gr_.FillRectangle(Brushes.White, rect_);

            Font myFont = new Font("Courier New", 12);
            // 座標軸と目盛値の描画 （X軸）
            for (int n = -(int)X_MAX_; n <= (int)X_MAX_; n++)
                gr_.DrawLine(Pens.Black, X_PX_ * n, HO_ / 2, X_PX_ * n, -HO_ / 2);
            for (int n = -(int)X_MAX_; n <= (int)X_MAX_; n += 2)
                gr_.DrawString(String.Format("{0,2}", n), myFont, Brushes.Black, n * X_PX_ - 17, HO_ / 2 + 6);

            // 座標軸と目盛値の描画（Y軸）
            for (int n = -(int)Y_MAX_; n <= Y_MAX_; n++)
                gr_.DrawLine(Pens.Black, -WO_ / 2, Y_PX_ * n, WO_ / 2, Y_PX_ * n);
            for (int n = -(int)Y_MAX_; n <= (int)Y_MAX_; n += 2)
                gr_.DrawString(String.Format("{0,2}", n), myFont, Brushes.Black, -WO_ / 2 - 26, -Y_PX_ * n - 10);
        }

        // 関数の描画
        public void Execute(Pen myPen)
        {
            // 描画点の計算
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

        // 描画する関数の定義
        private double fx(double x) { return x * x - 1.0; }
    }
}
