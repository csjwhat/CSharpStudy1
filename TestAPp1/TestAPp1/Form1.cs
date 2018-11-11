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

namespace TestAPp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // InitializeComponentで登録されたPaintイベントの登録を解除する。
            Paint -= new PaintEventHandler(Form1_Paint);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            // (30,150)から(250,50)に線を引く
            Graphics gr = e.Graphics;
            gr.DrawLine(Pens.Blue, 30, 150, 250, 50);

            Point pt1 = new Point(30, 150);
            Point pt2 = new Point(250, 50);
            Size sz1 = new Size(20, 20);

            // Penオブジェクトに含まれる属性、線種、幅、色
            Pen greenPen = new Pen(Color.Green, 2);
            greenPen.DashStyle = DashStyle.DashDot;

            // 文字を書くためのオブジェクトFont
            Font font1 = new Font("Arial", 12);

            // 文字の色・テクスチャ
            SolidBrush sb1 = new SolidBrush(Color.Red);

            // PaintEventArgs.Graphicsプロパティに含まれる属性、Smoothmode
            gr.SmoothingMode = SmoothingMode.AntiAlias;

            // PaintEventArgs.Graphicsオブジェクトの操作 DrawLine、DrawString
            gr.DrawLine(greenPen, pt1 + sz1, pt2 + sz1);

            gr.DrawString("ABC", font1, sb1, pt2 + sz1 + sz1);
            gr.DrawString("DEF", font1, Brushes.Blue, pt2 + sz1 + sz1 + sz1 + sz1);
            gr.DrawString("GHI", this.Font, Brushes.Blue, pt2 + sz1 + sz1 + sz1 + sz1 + sz1 + sz1);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Paint -= new PaintEventHandler(Form1_Paint);
            // Paintイベントの再登録
            Paint += new PaintEventHandler(Form1_Paint);
            Invalidate(); // 画面の再描画 → Paintイベントを追加しているのでイベント発火しForm1_Paintが追加される。
        }
    }
}
