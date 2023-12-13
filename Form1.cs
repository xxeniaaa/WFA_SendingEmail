using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using WFA_SendingEmail.UsersClasses;
using static WFA_SendingEmail.UsersClasses.InfoEmailSending;

namespace WFA_SendingEmail
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            textBoxEmail.Text = "task_code_development@list.ru";
            textBoxName.Text = "Антон Игоревич";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void textBoxEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxSubject_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxEmail.Text) ||
            string.IsNullOrWhiteSpace(textBoxName.Text) ||
            string.IsNullOrWhiteSpace(textBoxSubject.Text) ||
            string.IsNullOrWhiteSpace(textBoxBody.Text))
            {
                MessageBox.Show("Заполните все поля!"); 
                return;
            }
            string smtp = "smtp.mail.ru";
            StringPair fromInfo = new StringPair("xeanko@mail.ru", "Козлова Ксения Андреевна");
            string password = "B6j7VFz3YzwDJ6KaXTzW";

            StringPair toInfo = new StringPair(textBoxEmail.Text, textBoxName.Text);
            string subject = textBoxSubject.Text;
            string body = $"{DateTime.Now} \n" +       
            $"{ Dns.GetHostName()} \n" +
            $"{Dns.GetHostAddresses(Dns.GetHostName()).First()} \n" +
            $"{textBoxBody.Text}";

            InfoEmailSending info =
            new InfoEmailSending(smtp, fromInfo, password, toInfo, subject, body);
            UsersClasses.SendingEmail sendingEmail = new UsersClasses.SendingEmail(info);
            sendingEmail.Send();
                        
            MessageBox.Show("Message sent!");
            foreach (TextBox textBox in Controls.OfType<TextBox>())
                textBox.Text = "";


        }
    }
}
