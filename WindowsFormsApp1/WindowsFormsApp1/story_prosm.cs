using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class story_prosm : Form
    {
        public story_prosm()
        {
            InitializeComponent();
        }

        const string pathTextStory = @"story\story_u.txt";

        private void story_prosm_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = File.ReadAllText(pathTextStory);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            File.WriteAllText(pathTextStory, string.Empty);
            richTextBox1.Text = File.ReadAllText(pathTextStory);
        }
    }
}
