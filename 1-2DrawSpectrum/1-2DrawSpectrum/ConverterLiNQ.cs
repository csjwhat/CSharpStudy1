using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Numerics;

namespace MyConverter
{
    public static class ConverterLinq
    {
        public static PointF[] Convert(string[] str, float min_DB, float dx, float dB1)
        {
            // 読み込んだ文字列をComplexに変換
            IEnumerable<Complex> xn = str.Select(
                s => new Complex(ToDouble(s, ":"), ToDouble(s, ",")));
 
            // ComplexのデータをdBに変換して返却
            return ToDecibel(xn)
                .Select((x, n) => new PointF(dx*n, -(x + min_DB)*dB1))
                .ToArray();
        }

        // 文字列をdoubleに変換するデリゲードオブジェクトの定義
        private static Func<string, string, double> ToDouble =
            (s, ch) => double.Parse(s.Substring(s.IndexOf(ch) + 1, 10));

        // 最大値で正規化されたdB値を求める
        private static IEnumerable<float> ToDecibel(IEnumerable<Complex> un)
        {
            // 配列の内容がすべて0の場合はnullを返す
            if (un.All(x => x == Complex.Zero)) return null;

            IEnumerable<double> absX = un.Select(x => Complex.Abs(x));
            double max = absX.Max();
            return absX.Select(x => x > 0.0f ? 20.0f * (float)Math.Log10(x / max) : -1000f);
        }
    }
}
