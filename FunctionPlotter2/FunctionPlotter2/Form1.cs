using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using MyPlotterDelegate;

namespace FunctionPlotter2
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
            Paint -= new PaintEventHandler(Form1_Paint);
            Paint += new PaintEventHandler(Form1_Paint);
            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            // デリゲード（メソッドを変数に入れる）とラムダ式（関数を簡単に表現する）のサンプル
            Plotter myPlot = new Plotter(ClientSize, e.Graphics);
            myPlot.Axis();

            Pen myPen = new Pen(Color.Black, 2);
            myPlot.Execute(myPen, fx);

            myPen.DashStyle = DashStyle.Dash;
            myPlot.Execute(myPen, x => -0.5 * x * (x * x - 1));

            Func<double, double> gx = x => -0.5 * x * x + 1.0;
            myPen.DashStyle = DashStyle.Dot;
            myPlot.Execute(myPen, gx);

        }

        private double fx(double x) { return x * x - 1.0; } 
    }
}
