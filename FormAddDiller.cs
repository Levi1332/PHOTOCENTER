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
    public partial class FormAddDiller : Form
    {
        public FormAddDiller()
        {
            InitializeComponent();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "Введите имя диллера" ||
                textBox.Text == "Введите номер телефона диллера" ||
                textBox.Text == "Введите продукт диллера"||
                textBox.Text == "Введите адрес диллера"
                )
            {
                textBox.Text = "";
            }
        }
        private void login_textBox_Leave(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                if (textBox == textBoxNameDiller)
                {
                    textBox.Text = "Введите имя диллера";
                }
                else if (textBox == textBoxPhoneDiller)
                {
                    textBox.Text = "Введите номер телефона диллера";
                }
                else if (textBox == textBoxProduct)
                {
                    textBox.Text = "Введите продукт диллера";
                }
                else if (textBox == textBoxAddres)
                {
                    textBox.Text = "Введите адрес диллера";
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Class_for_dataBase classForDataBase = new Class_for_dataBase();
            if(classForDataBase.setInfoinDataBase(textBoxNameDiller.Text,textBoxPhoneDiller.Text,textBoxProduct.Text,textBoxAddres.Text))
            {
                MessageBox.Show("Диллер успешно добавлен","Успех",MessageBoxButtons.OK,MessageBoxIcon.Information);
                FormForAdmin formForAdmin = new FormForAdmin();
                
                formForAdmin.Show();
                formForAdmin.setDataInDataGrid();

                this.Close();
            }
            else
            {
                MessageBox.Show("Диллер не добавлен", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }
    }
}
