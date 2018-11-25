using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Example_QueryExtentionMethod
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double[] x1 = { 2.0, 1.5, -3.1, 1.8 };

            double y1 = x1.Max();
            label1.Text = "最大値:" + y1.ToString();

            double y2 = x1.Select(x => Math.Abs(x)).Max();
            // double y2 = x1.Max(x => Math.Abs(x));
            label2.Text = "絶対値の最大値：" + y2.ToString();

            double y3 = x1.Average();
            label3.Text = "平均値：" + y3.ToString();

            bool y4 = x1.All(x => x > 0.0);
            label4.Text = "すべての要素が0より大きいか：" + y4.ToString();

            bool y5 = x1.Any(x => x < 0.0);
            label5.Text = "マイナスの要素が含まれているか" + y5.ToString();

        }
    }
}
