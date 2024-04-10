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
    public partial class FormForUser : Form
    {
        public FormForUser()
        {
            InitializeComponent();
            Class_for_dataBase class_For_DataBase = new Class_for_dataBase();
            string qurey = "Select [id],[nameservice],[cost],[timeperfomens] from [service]";
            DataTable adapter = class_For_DataBase.getDataFromDataBase(qurey);
            if (adapter != null)
            {
                dataGridView1.DataSource = adapter;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Columns.Contains("id") && dataGridView1.SelectedRows.Count > 0)
            {
                Class_for_dataBase class_For_DataBase = new Class_for_dataBase();
                int serviceId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);
               
                class_For_DataBase.setServiceInUser(serviceId);
            }
            else
            {
                MessageBox.Show("Выберите строку с данными для присвоения сервиса.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormForUser_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "cOMP_COMPANYDataSet.Client". При необходимости она может быть перемещена или удалена.
            this.clientTableAdapter.Fill(this.cOMP_COMPANYDataSet.Client);

        }
    }
}
