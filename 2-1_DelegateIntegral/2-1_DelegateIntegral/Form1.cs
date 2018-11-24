using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2_1_DelegateIntegral
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double y1 = Integral(fx1, 1, 2, 10);
            label1.Text = "y1: " + y1.ToString("0.#####");

            double y2 = Integral(fx2, -1, 1, 100);
            label2.Text = "y2: " + y2.ToString("0.#####");

            // メソッドとの違い
            double a0 = 1.0;
            double b0 = 1.5;
            Func<double, double> fx3 = x => a0 * x + b0;

            double y3 = Integral(fx3, 1, 2, 100);
            label3.Text = "y3: " + y3.ToString("0.#####");

            a0 = -1.0;
            b0 = 2.0;
            double y4 = Integral(fx3, 1, 2, 100);
            label4.Text = "y4: " + y4.ToString("0.#####");
        }

        // デリゲードの宣言
        private delegate double Integrand(double x);

        // デリゲードを引数に持つメソッド
        // 台形公式による定積分計算
        private double Integral(Func<double,double> fx, double x1, double x2, int k)
        {
            double dx = (x2 - x1) / (double)k; // 増分
            double sum = (fx(x1) + fx(x2)) / 2.0;
            for (double x = x1 + dx; x < x2; x += dx) sum = sum + fx(x);

            return sum * dx;
        }

        // 被積分関数の定義
        private double fx1(double x)
        {
            return 1.0 / x;
        }

        // 被積分関数の定義２
        private double fx2(double x)
        {
            return 1.0 / (1 + x * x);
        }
    }
}
