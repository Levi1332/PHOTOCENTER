using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PHOTOCENTER
{
    internal class ClassForDataBase
    {
        private static string connectionString = @"Data Source=37-4\SQLEXPRESS;Initial Catalog=PhotoRay;Integrated Security=True;";

        public int ferivacation(string name, string pass, string number)
        {
            string query = "SELECT [name],[number],[pass],truth_of_access FROM [UserLog]";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        string namebd = reader["name"].ToString();
                        string numberbd = reader["number"].ToString();
                        string passbd = reader["pass"].ToString();
                        int truth_of_access =Convert.ToInt32(reader["truth_of_access"]);
                        if (numberbd == number && name == namebd && passbd == pass)
                        {
                            Class_for_dataBase class_For_DataBase = new Class_for_dataBase();
                            class_For_DataBase.setServiceName(name);
                            if (truth_of_access == 0)
                            {
                                return 0;
                            }
                            else if (truth_of_access == 1)
                                return 1;
                        }
                        
                    }
                    reader.Close();
                    return -1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Произошла ошибка при выполнении запроса: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
            }
        }

    }
}
