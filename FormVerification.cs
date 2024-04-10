using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using TextBox = System.Windows.Forms.TextBox;

namespace PHOTOCENTER
{
    public partial class FormVerification : Form
    {
        public FormVerification()
        {
            InitializeComponent();
            textBoxPass.UseSystemPasswordChar = false;
            
        }

       
        private void button1_Click(object sender, EventArgs e)
        {
            ClassForDataBase classForDataBase = new ClassForDataBase();
            if (classForDataBase.ferivacation(textBoxName.Text.ToString(),
                                                textBoxPass.Text.ToString(),
                                                textBoxNumber.Text.ToString()) == 0)
            {
                FormForUser form2 = new FormForUser();
                form2.Show();

            }
            else if (classForDataBase.ferivacation(textBoxName.Text.ToString(),
                                                textBoxPass.Text.ToString(),
                                                textBoxNumber.Text.ToString()) == 1)
            { 
                 FormForAdmin form2 = new FormForAdmin();
                    form2.Show();
            }
            else
            {
                MessageBox.Show("Данного аккаунта не существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
      

        }
        private void textBox1_Enter(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox textBox = (System.Windows.Forms.TextBox)sender;
            if (textBox.Text == "Введите логин" ||
                textBox.Text == "Введите номер телефона" ||
                textBox.Text == "Введите пароль" 
                )
            {
                textBox.Text = "";
            }
        }
        private void login_textBox_Leave(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox textBox = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                if (textBox == textBoxName)
                {
                    textBox.Text = "Введите логин";
                }
                else if (textBox == textBoxNumber)
                {
                    textBox.Text = "Введите номер телефона";
                }
                else if (textBox == textBoxPass)
                {
                    textBox.Text = "Введите пароль";
                }
            }
        }

        private void textBoxPass_Click(object sender, EventArgs e)
        {
            textBoxPass.PasswordChar = '*';
        }

        private void label2_Click(object sender, EventArgs e)
        {
            FormForRegistration formForRegistration = new FormForRegistration();
            formForRegistration.Show();
        }
    }
}
