using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PHOTOCENTER
{
    public partial class FormForRegistration : Form
    {
        public FormForRegistration()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {          
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Class_for_dataBase class_For_DataBase= new Class_for_dataBase();
            if (class_For_DataBase.setInfoinDataBase(textBoxName.Text, textBoxPass.Text, textBoxNumber.Text))
            {
                MessageBox.Show("Вы успешно зарегестрированы", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Произошла ошибка","Ошибка",MessageBoxButtons.OK,MessageBoxIcon.Error);
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
    }
}
