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

namespace FuctionPlotter2_Inheritance
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Paint -= new PaintEventHandler(Form1_Paint);
        }

        // このイベントハンドラで関数のグラフを描画する
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            PlotterBase myPlot = new PlotterFx1(ClientSize, e.Graphics);
            myPlot.Axis();

            Pen myPen = new Pen(Color.Black, 2);
            myPlot.Execute(myPen);

            myPlot = new PlotterFx2(ClientSize, e.Graphics);
            myPen.DashStyle = DashStyle.Dash;
            myPlot.Execute(myPen);

            myPen.DashStyle = DashStyle.DashDot;
            (new PlotterFx3(ClientSize, e.Graphics)).Execute(myPen);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Paint -= new PaintEventHandler(Form1_Paint);
            Paint += new PaintEventHandler(Form1_Paint);
            Invalidate();
        }
    }

    public class PlotterFx1 : PlotterBase
    {
        public PlotterFx1(Size size, Graphics gr) : base(size, gr) { }
        public override double fx(double x) { return x * x - 1.0; }
    }

    public class PlotterFx2 : PlotterBase
    {
        public PlotterFx2(Size size, Graphics gr) : base(size, gr) { }
        public override double fx(double x) { return 0.5 * x * (x * x - 1.0); }
    }

    public class PlotterFx3 : PlotterBase
    {
        public PlotterFx3(Size size, Graphics gr) : base(size, gr) { }
        public override double fx(double x) { return -0.5 * x * x + 1.0; }
    }
}
