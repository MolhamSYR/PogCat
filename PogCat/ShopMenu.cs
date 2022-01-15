using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PogCat
{
    public partial class ShopMenu : UserControl
    {
        public ShopMenu()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Form1.DataJson.clicks > 150000)
            {
                Form1.DataJson.SHOPCPS += 50;
                Form1.DataJson.clicks -= 100000;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Form1.DataJson.clicks > 400000)
            {
                Form1.DataJson.SHOPCPS += 200;
                Form1.DataJson.clicks -= 200000;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Form1.DataJson.clicks > 1000000)
            {
                Form1.DataJson.SHOPCPS += 1000;
                Form1.DataJson.clicks -= 400000;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            
        }
    }
}
