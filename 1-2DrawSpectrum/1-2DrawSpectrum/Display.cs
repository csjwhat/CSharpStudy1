using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace MyDisplaySpectrum
{
    public static class Display
    {
        public static void Execute(Graphics myGr, PointF[] points,float dx, float db1, float minD)
        {
            Graphics gr = myGr;
            Font myFont = new Font("ＭＳ ゴシック", 10);
            SolidBrush myBrush = new SolidBrush(Color.Black);

            gr.ResetTransform();
            gr.TranslateTransform(40, 200);

            // 横軸
            float w0 = points.Length * dx;
            float tickX = w0 / 4.0f;
            gr.DrawLine(Pens.Black, 0, 0, w0, 0);
            for (int n = 0; n <= 4; n++)
                gr.DrawLine(Pens.Black, (w0 / 4f) * n, 0, tickX * n, -3);
            for (float n = 0; n <= 4; n++)
                gr.DrawString(n.ToString(), myFont, myBrush, tickX * n - 5, 10);
            gr.DrawString("周波数[kHz]", myFont, myBrush, w0 / 2 - 38, 28);

            // 縦軸
            float h0 = db1 * minD;
            gr.DrawLine(Pens.Black, 0, 0, 0, -h0);
            for (int n = 0; n <= (int)minD; n += 10)
                gr.DrawLine(Pens.Black, 0, -db1 * n, 3, -db1 * n);
            for (float n = 0; n <= (int)minD; n += 10)
                gr.DrawString(String.Format("{0,3}", -minD + n), myFont, myBrush, -25, -db1 * n - 8);
            gr.DrawString("{dB}", myFont, myBrush, -24, -h0 - 22);

            // データの表示
            gr.SetClip(new RectangleF(0, -h0 - 3, w0, h0 + 3));
            gr.SmoothingMode = SmoothingMode.AntiAlias;
            gr.DrawCurve(new Pen(Color.Black, 2), points);
            gr.SmoothingMode = SmoothingMode.Default;
            gr.ResetClip();
        }
    }
}
