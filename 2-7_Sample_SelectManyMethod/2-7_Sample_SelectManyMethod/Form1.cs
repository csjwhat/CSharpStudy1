using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2_7_Sample_SelectManyMethod
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        // 係数の記号のままで乗算
        private void button1_Click(object sender, EventArgs e)
        {
            string[] s1 = { "a", "b", "c" };
            string[] s2 = { "A", "B", "C", "D" };

            IEnumerable<string> s0 = s1.SelectMany(x => s2, (x, y) => x + "*" + y);

            textBox1.AppendText("\r\nSelectMany()の処理結果\r\n");
            foreach (string vs in s0)
                textBox1.AppendText(vs + "\r\n");

            string[] sx = new string[s1.Length + s2.Length - 1];
            for (int n = 0; n < s1.Length; n++)
                for (int k = 0; k < s2.Length; k++)
                    // x^(k+n)の係数をsx[k+n]に設定する。s0.ElementAt(k+n*s2.Length)は、
                    // 例えば、aC (n=0, k=2), bB(n=1, k=1), cA(n=2, k=0)を示す
                    sx[k + n] = sx[k + n] + " + " + s0.ElementAt(k + n * s2.Length);
            sx = sx.Select(x => x.Substring(3)).ToArray();

            textBox1.AppendText("\r\n多項式の乗算の結果\r\n");
            for (int n = 0; n < sx.Length; n++)
                textBox1.AppendText((sx.Length - n - 1).ToString() + "次の項：" + sx[n] + "\r\n");
        }

        // 係数の数値の乗算
     

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            double[] x1 = { 1, 2, 3, 4, 5 };
            double[] x2 = { 6, 7, 8 };

            IEnumerable<double> x0 = x1.SelectMany(x => x2, (x, y) => x * y);

            double[] y0 = new double[x1.Length + x2.Length - 1];
            for (int n = 0; n < x1.Length; n++)
                for (int k = 0; k < x2.Length; k++)
                    y0[k + n] = y0[k + n] + x0.ElementAt(k + n * x2.Length);

            textBox1.AppendText("\r\n多項式の乗算の結果\r\n");
            for (int n = 0; n < y0.Length; n++)
                textBox1.AppendText((y0.Length - n - 1).ToString() + "次の項；" + y0[n] + "\r\n");
        }
    }
   
}
