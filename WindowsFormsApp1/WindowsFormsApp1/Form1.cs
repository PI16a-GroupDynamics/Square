using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if((e.KeyChar<48 || e.KeyChar >= 58) && e.KeyChar!=8)
            {
                e.Handled = true;
            }
            
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar >= 58) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar >= 58) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a = Convert.ToInt32(this.textBox1.Text);
            int b = Convert.ToInt32(this.textBox2.Text);
            int c = Convert.ToInt32(this.textBox2.Text);

            double x1 = 0;
            double x2 = 0;

            int countRoot;

            double diskriminant = b * b - 4 * a * c;

            if (diskriminant == 0)
            {
                countRoot = 1;
                x1 = (-b) / (2 * a);
            }
            else if (diskriminant > 0)
            {
                countRoot = 2;
                x1= (-b-Math.Sqrt(diskriminant)) / (2 * a);
                x2 = (-b + Math.Sqrt(diskriminant)) / (2 * a);
            }
        }
    }
}
