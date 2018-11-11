using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyPlotterF1st
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Paint -= new PaintEventHandler(Form1_Paint); // 初期イベントでの描画を抑止
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // 関数を描画するメソッド
        private void Form1_Paint(object sendar, PaintEventArgs e)
        {
            Plotter1st myPlot = new Plotter1st(ClientSize, e.Graphics);
            myPlot.Axis();
            myPlot.Execute(new Pen(Color.Black, 2));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Paint -= new PaintEventHandler(Form1_Paint); // イベント登録を解除
            Paint += new PaintEventHandler(Form1_Paint); // イベントを再登録
            Invalidate(); // 表示をいったん無効にする。（再表示時に登録されたイベントが発火）
        }
    }
}
