using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Windows.Forms;
using Newtonsoft.Json;
using MaterialDesignThemes.Wpf;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Controls;

namespace WindowsFormsApp1
{
    public partial class Мониторинг : Form
    {
        private PrintDocument printDocument;
        InsertBD insertBD = new InsertBD();
        public Мониторинг()
        {
            InitializeComponent();
            linkLabel1.Text = Аккаунты.login;
            if (linkLabel1.Text == "Войти")
            {
                button1.Enabled = false;
                toolStripMenuItem1.Enabled = false;
                comboBox1.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
                toolStripMenuItem1.Enabled = true;
                comboBox1.Enabled = true;
                textBox2.Text = linkLabel1.Text;
            }
            printDocument = new PrintDocument();
            printDocument.PrintPage += PrintDocument_PrintPage;

            insertBD.PR(comboBox1, textBox2);
            insertBD.LoadL(listBox1);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                this.BackColor = Color.Black;
                tabPage1.BackColor = Color.Black;
                tabPage2.BackColor = Color.Black;
                button1.BackColor = Color.Black;
                button3.BackColor = Color.Black;
                button4.BackColor = Color.Black;

                listBox1.BackColor = Color.Black;

                textBox1.BackColor = Color.Black;
                textBox4.BackColor = Color.Black;
                textBox5.BackColor = Color.Black;
                textBox3.BackColor = Color.Black;
                textBox6.BackColor = Color.Black;
                textBox7.BackColor = Color.Black;
                textBox8.BackColor = Color.Black;
                textBox9.BackColor = Color.Black;
                textBox10.BackColor = Color.Black;
                textBox11.BackColor = Color.Black;
                textBox2.BackColor = Color.Black;

                toolStripTextBox1.BackColor = Color.Black;
                toolStripTextBox2.BackColor = Color.Black;
                comboBox1.BackColor = Color.Black;


                label2.ForeColor = Color.White;

                label3.ForeColor = Color.White;
                label1.ForeColor = Color.White;
                label5.ForeColor = Color.White;

                label4.ForeColor = Color.White;
                label6.ForeColor = Color.White;
                label7.ForeColor = Color.White;
                label8.ForeColor = Color.White;

                listBox1.ForeColor = Color.White;

                textBox1.ForeColor = Color.White;
                textBox4.ForeColor = Color.White;
                textBox5.ForeColor = Color.White;
                textBox3.ForeColor = Color.White;
                textBox6.ForeColor = Color.White;
                textBox7.ForeColor = Color.White;
                textBox8.ForeColor = Color.White;
                textBox9.ForeColor = Color.White;
                textBox10.ForeColor = Color.White;
                textBox11.ForeColor = Color.White;
                textBox2.ForeColor = Color.White;

                темаДневникаToolStripMenuItem.ForeColor = Color.White;
                вашВесToolStripMenuItem.ForeColor = Color.White;
                toolStripMenuItem1.ForeColor = Color.White;
                toolStripTextBox1.ForeColor = Color.White;
                toolStripTextBox2.ForeColor = Color.White;
                comboBox1.ForeColor = Color.White;

                label9.ForeColor = Color.White;
                label10.ForeColor = Color.White;
                button1.ForeColor = Color.White;
                button3.ForeColor = Color.White;
                button4.ForeColor = Color.White;
                checkBox1.ForeColor = Color.White;
                linkLabel1.LinkColor = Color.White;

                checkBox1.Text = "Светлая тема";
            }
            else
            {
                this.BackColor = Color.White;
                tabPage1.BackColor = Color.White;
                tabPage2.BackColor = Color.White;
                button1.BackColor = Color.White;
                button3.BackColor = Color.White;
                button4.BackColor = Color.White;

                listBox1.BackColor = Color.White;
                textBox1.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox2.BackColor = Color.White;

                toolStripTextBox1.BackColor = Color.White;
                toolStripTextBox2.BackColor = Color.White;
                comboBox1.BackColor = Color.White;



                label2.ForeColor = Color.Black;
                label9.ForeColor = Color.Black;
                label10.ForeColor = Color.Black;

                label4.ForeColor = Color.Black;
                label6.ForeColor = Color.Black;
                label7.ForeColor = Color.Black;
                label8.ForeColor = Color.Black;


                label3.ForeColor = Color.Black;
                label1.ForeColor = Color.Black;
                label5.ForeColor = Color.Black;

                listBox1.ForeColor = Color.Black;

                textBox1.ForeColor = Color.Black;
                textBox4.ForeColor = Color.Black;
                textBox5.ForeColor = Color.Black;
                textBox3.ForeColor = Color.Black;
                textBox6.ForeColor = Color.Black;
                textBox7.ForeColor = Color.Black;
                textBox8.ForeColor = Color.Black;
                textBox9.ForeColor = Color.Black;
                textBox10.ForeColor = Color.Black;
                textBox11.ForeColor = Color.Black;
                textBox2.ForeColor = Color.Black;

                темаДневникаToolStripMenuItem.ForeColor = Color.Black;
                вашВесToolStripMenuItem.ForeColor = Color.Black;
                toolStripMenuItem1.ForeColor = Color.Black;
                toolStripTextBox1.ForeColor = Color.Black;
                toolStripTextBox2.ForeColor = Color.Black;
                comboBox1.ForeColor = Color.Black;

                button1.ForeColor = Color.Black;
                button3.ForeColor = Color.Black;
                button4.ForeColor = Color.Black;
                checkBox1.ForeColor = Color.Black;
                linkLabel1.LinkColor = Color.Black;

                checkBox1.Text = "Темная тема";
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Аккаунт аккаунт = new Аккаунт();
            аккаунт.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            comboBox1.Items.Clear();
            insertBD.P(toolStripTextBox1, toolStripTextBox2, dateTimePicker1, dateTimePicker2, dateTimePicker3, textBox1, textBox4, textBox5, textBox3, textBox6, textBox7, textBox8, textBox9, textBox10, textBox2);
            insertBD.PR(comboBox1, textBox2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.PrintDialog printDialog = new System.Windows.Forms.PrintDialog();
            printDocument.DefaultPageSettings.PaperSize = new PaperSize("A4", 827, 1169); // Размер страницы A4
            printDialog.Document = printDocument;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            float pageWidth = e.PageSettings.PrintableArea.Width;
            float pageHeight = e.PageSettings.PrintableArea.Height;

            Font font = new Font("Sans", 14);

            System.Windows.Forms.Control control = new System.Windows.Forms.Control();
            float x = control.Left * pageWidth / Width;
            float y = control.Top * pageHeight / Height;

            string text = $"Тема дневника: {toolStripTextBox1.Text} Ваш вес: {toolStripTextBox2.Text}\n\n"
                + $"Завтрак {dateTimePicker1.Text} - {textBox1.Text}: {textBox3.Text}, {textBox8.Text}\n\n"
                + $"Обед {dateTimePicker2.Text} - {textBox4.Text}: {textBox6.Text}, {textBox9.Text}\n\n"
                + $"Ужин {dateTimePicker3.Text} - {textBox5.Text}: {textBox7.Text}, {textBox10.Text}\n\n";

            e.Graphics.DrawString(text, font, Brushes.Black, x, y);

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            insertBD.SearchTopic(textBox12, toolStripTextBox1, toolStripTextBox2, dateTimePicker1, dateTimePicker2, dateTimePicker3, textBox1, textBox4, textBox5, textBox3, textBox6, textBox7, textBox8, textBox9, textBox10, textBox2);
            MessageBox.Show("Успешно сохранено в ваших дневниках, проверяйте ;)");
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedItem = listBox1.SelectedItem;

            if (selectedItem != null)
            {
                var selectedItemText = selectedItem.ToString();

                var lines = selectedItemText.Split();

                textBox12.Text = lines[0];
            }
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            insertBD.SearchAll(listBox1,textBox11);
        }

        private void label10_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            insertBD.LoadL(listBox1);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            insertBD.PS(comboBox1,toolStripTextBox1, toolStripTextBox2, dateTimePicker1, dateTimePicker2, dateTimePicker3, textBox1, textBox4, textBox5, textBox3, textBox6, textBox7, textBox8, textBox9, textBox10, textBox2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox4.Clear();
            textBox5.Clear();

            textBox3.Clear();
            textBox6.Clear();
            textBox7.Clear();

            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();

            toolStripTextBox1.Clear();
            toolStripTextBox2.Clear();

            comboBox1.Text = "";

            if (linkLabel1.Text == "Войти")
            {
                textBox2.Text = "";
            }
            else
            {
                textBox2.Text = linkLabel1.Text;
            }
        }
    }
}


