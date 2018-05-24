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
    public partial class registration : Form
    {
        string pathTextLogPass;
        

        public registration(string pathTextLogPass)
        {
            InitializeComponent();

            this.pathTextLogPass = pathTextLogPass;
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            if (!(File.Exists(pathTextLogPass)))
                using (FileStream fs = new FileStream(pathTextLogPass, FileMode.CreateNew)) ;
            label6.Hide(); // Скрыть "Повторите пароль"
            secondpasswordtxt.Hide();
        }




        public registration()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (logintxt.Text == string.Empty)
            {
                MessageBox.Show("Введите логин");
                return;
            }
            if (password.Text == string.Empty || secondpasswordtxt.Text == string.Empty)
            {
                MessageBox.Show("Поле с паролем не заполнено");
                return;
            }
            if (password.Text != secondpasswordtxt.Text)
            {
                MessageBox.Show("Пароли не совпадают");
                return;
            }
            if (Save(logintxt.Text, password.Text) == true)
            {
                //DialogResult = DialogResult.OK;
                MessageBox.Show("Регистрация выполнена успешно");
                this.Close();
            }
            else
                return;
        }

        // Сохраняем пару логин/пароль
        bool Save(string login, string password)
        {
            try
            {
                if (NotHaveLogin(pathTextLogPass))
                {
                    File.AppendAllLines(pathTextLogPass, new[] { Encryption(login + "|" + password) }, Encoding.Default);
                    return true;
                }
                else
                    return false;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                return false;
            }
        }

        //шифрование пары логин/пароль
        string Encryption(string str)
        {
            StringBuilder stringBuilder = new StringBuilder(str);
            for (int i = 0; i < stringBuilder.Length; i++)
            {
                stringBuilder[i] = (char)(stringBuilder[i] + 2);
            }
            return stringBuilder.ToString();
        }

        // Проверяем,что такой логин еще не занят

        bool NotHaveLogin(string pathTextLogPass)
        {
            string[] lines = File.ReadAllLines(pathTextLogPass, Encoding.Default);
            foreach (string line in lines)
            {
                if (Decription(line).Split('|')[0].ToLower() == logintxt.Text.ToLower())
                {
                    MessageBox.Show("Такой логин уже существует");
                    return false;
                }
            }
            return true;
        }

        // расшифровка пары логин/пароль
        string Decription(string str)
        {
            StringBuilder stringBuilder = new StringBuilder(str);
            for (int i = 0; i < stringBuilder.Length; i++)
                stringBuilder[i] = (char)(stringBuilder[i] - 2);
            return stringBuilder.ToString();
        }

        // появление поля для повторного ввода пароля
        private void password_TextChanged(object sender, EventArgs e)
        {
            if (password.Text == string.Empty)
            {
                label6.Hide();
                secondpasswordtxt.Hide();
            }
            else
            {
                label6.Show();
                secondpasswordtxt.Show();
            }
        }

        // запрт ввода символа '|'
        private void password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '|')
            {
                MessageBox.Show("Символ ' | ' запрещен для ввода"); // // т.к этот символ будет разделителем для логина и пароля при хранении строк в файле
                e.Handled = true;
            }
        }

        private void password_TextChanged_1(object sender, EventArgs e)
        {
            if (password.Text == string.Empty)
            {
                label6.Hide();
                secondpasswordtxt.Hide();
            }
            else
            {
                label6.Show();
                secondpasswordtxt.Show();
            }
        }
    }
}
