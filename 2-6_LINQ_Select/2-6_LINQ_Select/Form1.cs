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

namespace _2_6_LINQ_Select
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

        private void Form1_Paint(object sendar, PaintEventArgs e)
        {
            float[] timeSeries = { 2.4f, 1.3f, 5.0f, 3.0f, 1.8f, 3.5f, 3.2f };
            IEnumerable<PointF> pts = timeSeries.Select((x, n) => new PointF(20 * n, -20 * x));

            Graphics gr = e.Graphics;
            gr.TranslateTransform(40, 130);

            gr.DrawLine(Pens.Black, -5, 0, 140, 0);
            gr.DrawLine(Pens.Black, 0, 5, 0, -110);

            gr.SmoothingMode = SmoothingMode.AntiAlias;
            Pen myPen = new Pen(Color.Black, 2);
            gr.DrawLines(myPen, pts.ToArray());
            SizeF offset = new SizeF(4, 4);
            SizeF r0 = offset + offset;

            SolidBrush myBrush = new SolidBrush(Color.White);

            foreach (PointF pt in pts)
            {
                RectangleF rect = new RectangleF(pt - offset, r0);
                gr.FillEllipse(myBrush, rect);
                gr.DrawEllipse(myPen, rect);
            }
        }
    }
}
