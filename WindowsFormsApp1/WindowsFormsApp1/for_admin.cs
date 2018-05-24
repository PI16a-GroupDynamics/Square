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

namespace WindowsFormsApp1
{
    public partial class for_admin : Form
    {
        public for_admin()
        {
            InitializeComponent();
        }

        const string pathTextLogPass = @"password\pass.txt";

        private void for_admin_Load(object sender, EventArgs e)
        {
            string[] lines = File.ReadAllLines(pathTextLogPass, Encoding.Default);
            foreach (string line in lines)
            {
                string[] linesDec = Decryption(line).Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                string temp = "Логин: " + linesDec[0] + "Пароль: " + linesDec[1]+"\n";
                richTextBox1.AppendText(temp);
            }
        }

        // Шифрование пары логин/пароль
        string Decryption(string str)
        {
            StringBuilder stringBuilder = new StringBuilder(str);
            for (int i = 0; i < stringBuilder.Length; i++)
            {
                stringBuilder[i] = (char)(stringBuilder[i] - 2);
            }
            return stringBuilder.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            File.WriteAllText(pathTextLogPass, string.Empty);
            richTextBox1.Text = File.ReadAllText(pathTextLogPass);
        }
    }
}
