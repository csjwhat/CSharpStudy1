using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyPlotterDelegate;

namespace FunctionPlotter3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Paint -= new PaintEventHandler(Form1_Paint);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // イベントハンドラの登録と再描画;;
            Paint -= new PaintEventHandler(Form1_Paint);
            Paint += new PaintEventHandler(Form1_Paint);
            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Plotter myPlot = new Plotter(ClientSize, e.Graphics);
            myPlot.Axis();

            // チェビシェフの多項式
            const int MAX_ORDER = 4;
            Func<double, double>[] Tn = new Func<double, double>[MAX_ORDER+ 1];

            Tn[0] = x => 1.0;
            Tn[1] = x => x;
            Tn[2] = x => 2.0 * x * Tn[1](x) - Tn[0](x);
            Tn[3] = x => 2.0 * x * Tn[2](x) - Tn[1](x);
            Tn[4] = x => 2.0 * x * Tn[3](x) - Tn[2](x);

            /* for (int n=2; n<=MAX_ORDER; n++) 
             * {
             *   Tn[n] = x => 2.0 * x * Tn[n-1] - Tn[n-2];
             * }
             */

            // 2次以上の「チェビシェフの多項式」を描画
            const int ORDER1 = 2;
            Pen[] pen = new Pen[MAX_ORDER - ORDER1 + 1];
            for (int n = 0; n < pen.Length; n++) pen[n] = new Pen(Color.Black, 2);
            pen[1].DashStyle = DashStyle.Dash;
            pen[2].DashStyle = DashStyle.Dot;

            for (int n = ORDER1; n <= MAX_ORDER; n++)
                myPlot.Execute(pen[n - ORDER1], Tn[n]);
        }
    }
}
