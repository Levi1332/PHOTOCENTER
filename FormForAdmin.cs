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
    public partial class FormForAdmin : Form
    {
        public FormForAdmin()
        {
            InitializeComponent();
            setDataInDataGrid();
        }
        public void setDataInDataGrid()
        {
            Class_for_dataBase class_For_DataBase = new Class_for_dataBase();
            string qurey = "Select [namediller],[phonenumber],[Adress] from [diller]";
            DataTable adapter = class_For_DataBase.getDataFromDataBase(qurey);
            if (adapter != null)
            {
                dataGridView1.DataSource = adapter;
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            FormAddDiller addDiller= new FormAddDiller();
            this.Close();
            addDiller.Show();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBoxNameDiller.Visible= true;
            if (textBoxNameDiller.Text != "Введите имя диллера")
            {
                Class_for_dataBase class_For_DataBase = new Class_for_dataBase();
                class_For_DataBase.deletDiller(textBoxNameDiller.Text);
                setDataInDataGrid();
            }
        }
        private void textBox1_Enter(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "Введите имя диллера")
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
            }
        }
    }
}
