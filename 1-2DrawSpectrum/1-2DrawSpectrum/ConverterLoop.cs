using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Numerics;

namespace MyConverter
{
    public static class ConverterLoop
    {
        // 読み込んだデータを表示用のデータへ変換
        public static PointF[] Convert(string[] str, float min_dB, float dx, float dB1)
        {
            // 読み込んだ文字列をComplexに変換して配列へ
            Complex[] xn = new Complex[str.Length];
            for (int n = 0; n < str.Length; n++)
                xn[n] = new Complex(ToDouble(str[n], ":"), ToDouble(str[n], ","));

            // 配列のデータをdB値に変換し、表示用のPointFの配列へ格納
            float[] yn = ToDecibel(xn);
            PointF[] points = new PointF[str.Length];
            for (int n = 0; n < str.Length; n++)
                points[n] = new PointF(dx * n, -(yn[n] + min_dB) * dB1);
            return points;            
        }

        //文字列をdoubleに変換する。
        private static double ToDouble(string s, string ch)
        {
            return double.Parse(s.Substring(s.IndexOf(ch) + 1, 10));
        }

        // 最大値で正規化されたdB値に変換する
        private static float[] ToDecibel(Complex[] un)
        {
            // 配列の内容がすべて0の場合、nullを返す
            bool zero = true;
            foreach (Complex x in un)
                if (x != Complex.Zero) zero = false;
            if (zero) return null;

            // 複素数の絶対値を求める。
            double[] absUn = new double[un.Length];
            for (int n = 0; n < un.Length; n++)
                absUn[n] = Complex.Abs(un[n]); 

            // 複素数の絶対値の最大値を求める。
            double max = 0;
            for (int n = 0; n < un.Length; n++)
                max = Math.Max(max, absUn[n]);

            // dBに変換する。
            float[] db = new float[un.Length];
            for (int n = 0; n < un.Length; n++)
                db[n] = absUn[n] > 0.0 ?
                    20.0f * (float)Math.Log10(absUn[n] / max) : -1000f;
            return db;
        }
    }
}
