using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MyConverter;
using MyDisplaySpectrum;


namespace _1_2DrawSpectrum
{
    public partial class Form1 : Form
    {
        private const float DB1_ = 4;
        private const float DX_ = 3;
        private const float MIN_D_ = 40;

        private PointF[] points_;

        public Form1()
        {
            InitializeComponent();
            Paint -= new PaintEventHandler(Form1_Paint);
        }



        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Display.Execute(e.Graphics, points_, DX_, DB1_, MIN_D_);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string fileName = "FFT_data.txt";
            if (!File.Exists(fileName)){
                MessageBox.Show("ファイルが存在しません");
                return;               
            }

            // テキストファイルの読み込みとデータ変換
            string[] data = File.ReadAllLines(fileName);
            // points_ = ConverterLoop.Convert(data, MIN_D_, DB1_, DB1_);
            points_ = ConverterLinq.Convert(data, MIN_D_, DB1_, DB1_);

            Paint -= new PaintEventHandler(Form1_Paint);
            Paint += new PaintEventHandler(Form1_Paint);
            Invalidate();
        }
    }
}
