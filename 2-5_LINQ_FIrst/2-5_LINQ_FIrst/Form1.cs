using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2_5_LINQ_FIrst
{
    public partial class Form1 : Form
    {
        // LINQで処理するサンプルデータ
        private int[] data_ = { 1, 3, -8, -6, 5, -2, 9 };

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IEnumerable<int> multiple = from n in data_
                                        where (n % 3) == 0
                                        select n;

            textBox1.AppendText("button1 をクリック\r\n");
            foreach (int i in multiple)
                textBox1.AppendText(String.Format("{0,4:D}\r\n", i));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            IEnumerable<int> multiple = data_.Where(n => (n % 3) == 0).Select(n => n);

            textBox1.AppendText("button2 をクリック\r\n");
            foreach (int i in multiple)
                textBox1.AppendText(String.Format("{0,4:D}\r\n", i));
        }
    }
}
