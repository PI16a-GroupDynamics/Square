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
    public partial class autorisation : Form
    {
        const string pathTextLogPass = @"password\pass.txt";
        const string pathTextStory = @"story\story_u.txt";
        Form1 form1;
        string login_u;

        public autorisation()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string login;
            string password;

            if (File.Exists(pathTextLogPass))
            {
                string[] lines = File.ReadAllLines(pathTextLogPass, Encoding.Default);
                foreach (string line in lines)
                {
                    string[] linesDec = Decryption(line).Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                    login = linesDec[0];
                    password = linesDec[1];

                    if (login.ToLower() == txtlogin.Text.ToLower() && password == txtpassword.Text)
                    {
                        login_u = txtlogin.Text;
                        Start();
                        return;
                    }
                }
            }
            if (txtlogin.Text.ToLower() == "admin" && txtpassword.Text == "admin") {
                login_u = "admin";
                Start();
                return;
            }
            MessageBox.Show("Такого логина или пароля не существует.\n Повторите ввод или зарегестрируйтесь!");
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



        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            registration reg = new registration(pathTextLogPass);
            reg.ShowDialog();
            if (reg.DialogResult == DialogResult.OK)
                Start();
        }

        void Start()
        {
            //this.DialogResult = DialogResult.OK;
            Hide();
            form1 = new Form1(login_u);
            form1.Show();
            DateTime localDate = DateTime.Now;
            try
            {
                File.AppendAllLines(pathTextStory, new[] { "--------------------------------------------------------------------------------------------------------------------------" }, Encoding.Default);
                File.AppendAllLines(pathTextStory, new[] { "User "+login_u +" logged in "+localDate.ToString() }, Encoding.Default);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

    }
}
