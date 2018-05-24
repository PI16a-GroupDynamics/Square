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

using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string login_user;
        const string pathTextStory = @"story\story_u.txt";

        public Form1(string login_user)
        {
            this.login_user = login_user;

            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (login_user == "admin")
                button3.Visible = true;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Правильными символами считаются цифры,
            // запятая, <Enter> и <Backspace>.
            // Будем считатьать правильным символом
            // также точку, на заменим ее запятой.
            // Остальные символы запрещены.
            // Чтобы запрещенный символ не отображался 
            // в поле редактирования,присвоим 
            // значение true свойству Handled параметра e

            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
            {
                // цифра
                return;
            }

            if (e.KeyChar == '-')
            {
                if (textBox1.Text.IndexOf('-') != -1)
                {
                    // минус уже есть в поле редактирования
                    e.Handled = true;
                }
                return;
            }


            if (e.KeyChar == '.')
            {
                // точку заменим запятой
                e.KeyChar = ',';
            }

            if (e.KeyChar == ',')
            {
                if (textBox1.Text.IndexOf(',') != -1)
                {
                    // запятая уже есть в поле редактирования
                    e.Handled = true;
                }
                return;
            }

            if (Char.IsControl(e.KeyChar))
            {
                // <Enter>, <Backspace>, <Esc>
                if (e.KeyChar == (char)Keys.Enter)
                    // нажата клавиша <Enter>
                    // установить курсор на кнопку OK
                    button1.Focus();
                return;
            }

            // остальные символы запрещены
            e.Handled = true;


        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Правильными символами считаются цифры,
            // запятая, <Enter> и <Backspace>.
            // Будем считатьать правильным символом
            // также точку, на заменим ее запятой.
            // Остальные символы запрещены.
            // Чтобы запрещенный символ не отображался 
            // в поле редактирования,присвоим 
            // значение true свойству Handled параметра e

            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
            {
                // цифра
                return;
            }

            if (e.KeyChar == '-')
            {
                if (textBox3.Text.IndexOf('-') != -1)
                {
                    // минус уже есть в поле редактирования
                    e.Handled = true;
                }
                return;
            }


            if (e.KeyChar == '.')
            {
                // точку заменим запятой
                e.KeyChar = ',';
            }

            if (e.KeyChar == ',')
            {
                if (textBox3.Text.IndexOf(',') != -1)
                {
                    // запятая уже есть в поле редактирования
                    e.Handled = true;
                }
                return;
            }

            if (Char.IsControl(e.KeyChar))
            {
                // <Enter>, <Backspace>, <Esc>
                if (e.KeyChar == (char)Keys.Enter)
                    // нажата клавиша <Enter>
                    // установить курсор на кнопку OK
                    button1.Focus();
                return;
            }

            // остальные символы запрещены
            e.Handled = true;

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Правильными символами считаются цифры,
            // запятая, <Enter> и <Backspace>.
            // Будем считатьать правильным символом
            // также точку, на заменим ее запятой.
            // Остальные символы запрещены.
            // Чтобы запрещенный символ не отображался 
            // в поле редактирования,присвоим 
            // значение true свойству Handled параметра e

            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
            {
                // цифра
                return;
            }

            if (e.KeyChar == '-')
            {
                if (textBox2.Text.IndexOf('-') != -1)
                {
                    // минус уже есть в поле редактирования
                    e.Handled = true;
                }
                return;
            }


            if (e.KeyChar == '.')
            {
                // точку заменим запятой
                e.KeyChar = ',';
            }

            if (e.KeyChar == ',')
            {
                if (textBox2.Text.IndexOf(',') != -1)
                {
                    // запятая уже есть в поле редактирования
                    e.Handled = true;
                }
                return;
            }

            if (Char.IsControl(e.KeyChar))
            {
                // <Enter>, <Backspace>, <Esc>
                if (e.KeyChar == (char)Keys.Enter)
                    // нажата клавиша <Enter>
                    // установить курсор на кнопку OK
                    button1.Focus();
                return;
            }

            // остальные символы запрещены
            e.Handled = true;

        }

        public void global_FormClosed(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
            label8.Visible = true;
            label9.Visible = true;
            label10.Visible = true;


            double a = Convert.ToDouble(this.textBox1.Text);
            double b = Convert.ToDouble(this.textBox3.Text);
            double c = Convert.ToDouble(this.textBox2.Text);

            double x1 = 0;
            double x2 = 0;

            Complex root1 = null;
            Complex root2 = null;

            string type_of_Roots;

            int countRoot = 0;

            double diskriminant = b * b - 4 * a * c;

            if (diskriminant == 0)
            {
                type_of_Roots = "Действительный";
                countRoot = 1;
                x1 = (-b) / (2 * a);
            }
            else if (diskriminant > 0)
            {
                type_of_Roots = "Действительный";
                countRoot = 2;
                x1 = (-b - Math.Sqrt(diskriminant)) / (2 * a);
                x2 = (-b + Math.Sqrt(diskriminant)) / (2 * a);
            }
            else
            {
                type_of_Roots = "Комплексный";
                countRoot = 2;
                Complex D1 = new Complex(0, Math.Sqrt(Math.Abs(diskriminant)));
                Complex D2 = new Complex(0, -1 * Math.Sqrt(Math.Abs(diskriminant)));
                root1 = (D1 - b) / (2 * a);
                root2 = (D2 - b) / (2 * a);
            }
            this.label12.Visible = true;
            this.label13.Visible = true;
            this.label17.Visible = true;
            this.label12.Text = diskriminant.ToString();
            this.label13.Text = countRoot.ToString();
            this.label17.Text = type_of_Roots;
            if (diskriminant >= 0)
            {
                if (countRoot == 1)
                {
                    this.label14.Visible = true;
                    this.label14.Text = x1.ToString("0.00");
                }
                else
                {
                    this.label14.Visible = true;
                    this.label15.Visible = true;
                    this.label14.Text = x1.ToString("0.00");
                    this.label15.Text = x2.ToString("0.00");
                }
            }
            else
            {
                this.label14.Visible = true;
                this.label15.Visible = true;
                this.label14.Text = root1.ToString();
                this.label15.Text = root2.ToString();
            }
            DateTime localDate = DateTime.Now;
            File.AppendAllLines(pathTextStory, new[] { "User " + login_user + " has solved equation in " + localDate.ToString() }, Encoding.Default);
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void вtxtФорматеToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовый документ (*.txt)|*.txt|Все файлы (*.*)|*.*";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName);
                streamWriter.WriteLine("Уравнение:" + textBox1.Text + "x^2" + Convert.ToDouble(textBox3.Text).ToString("+0.00#;-0.00#;0") + "x" + Convert.ToDouble(textBox2.Text).ToString("+0.00#;-0.00#;0") + "=0");
                streamWriter.WriteLine("Дискриминант=" + label12.Text);
                streamWriter.WriteLine("Количество корней: " + label13.Text);
                streamWriter.WriteLine("Тип корней: " + label17.Text);
                if (Convert.ToInt32(label13.Text) == 0)
                    streamWriter.WriteLine("Корень=" + label14.Text);
                else
                {
                    streamWriter.WriteLine("Первый корень=" + label14.Text);
                    streamWriter.WriteLine("Второй корень=" + label15.Text);
                }
                streamWriter.Close();
            }
        }

        private void вrtfФорматеToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовый документ (*.rtf)|*.rtf|Все файлы (*.*)|*.*";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName);
                streamWriter.WriteLine("Уравнение:" + textBox1.Text + "x^2" + Convert.ToDouble(textBox3.Text).ToString("+0.00#;-0.00#;0") + "x" + Convert.ToDouble(textBox2.Text).ToString("+0.00#;-0.00#;0") + "=0");
                streamWriter.WriteLine("Дискриминант=" + label12.Text);
                streamWriter.WriteLine("Количество корней: " + label13.Text);
                streamWriter.WriteLine("Тип корней: " + label17.Text);
                if (Convert.ToInt32(label13.Text) == 0)
                    streamWriter.WriteLine("Корень=" + label14.Text);
                else
                {
                    streamWriter.WriteLine("Первый корень=" + label14.Text);
                    streamWriter.WriteLine("Второй корень=" + label15.Text);
                }
                streamWriter.Close();
            }
        }

        private void вpdfФорматеToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовый документ (*.pdf)|*.pdf|Все файлы (*.*)|*.*";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {

                Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
                PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(saveFileDialog.FileName, FileMode.Create));
                doc.Open(); // Открыть документ на запись
                Paragraph paragraph = new Paragraph("Quadratic equation: " + textBox1.Text + "x^2" + Convert.ToDouble(textBox3.Text).ToString("+0.00#;-0.00#;0") + "x" + Convert.ToDouble(textBox2.Text).ToString("+0.00#;-0.00#;0") + "=0");
                doc.Add(paragraph);
                Paragraph paragraph2 = new Paragraph("Discriminant=" + label12.Text);
                doc.Add(paragraph2);
                Paragraph paragraph3 = new Paragraph("Number of roots: " + label13.Text);
                doc.Add(paragraph3);
                //Paragraph paragraph4 = null;
                if (Convert.ToDouble(label12.Text) < 0)
                {
                    Paragraph paragraph4 = new Paragraph("Root type: complexZ");
                    doc.Add(paragraph4);
                }
                else
                {
                    Paragraph paragraph4 = new Paragraph("Root type: real");
                    doc.Add(paragraph4);
                }
                if (Convert.ToInt32(label13.Text) == 0)
                {
                    Paragraph paragraph5 = new Paragraph("Root=" + label14.Text);
                    doc.Add(paragraph5);
                }
                else
                {
                    Paragraph paragraph6 = new Paragraph("First root=" + label14.Text);
                    doc.Add(paragraph6);
                    Paragraph paragraph7 = new Paragraph("Second root=" + label15.Text);
                    doc.Add(paragraph7);
                }
                doc.Close();
            }
        }

        private void историяПросмотровToolStripMenuItem_Click(object sender, EventArgs e)
        {
            story_prosm story_Prosm = new story_prosm();
            story_Prosm.Show();
        }

        private void разработчикиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            razrab razr = new razrab();
            razr.Show();
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            spravka spravkaf = new spravka();
            spravkaf.Show();
        }

        private void оПрограммеToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            about aboutf = new about();
            aboutf.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";

            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
            label13.Visible = false;
            label14.Visible = false;
            label15.Visible = false;
            label17.Visible = false;


        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            for_admin adminf = new for_admin();
            adminf.Show();
        }

        
    }
}