using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Collections;
using System.Data;
using System.Xml.Linq;

namespace PHOTOCENTER
{
    internal class Class_for_dataBase
    {
        private static string connectionString = @"Data Source=37-4\SQLEXPRESS;Initial Catalog=PhotoRay;Integrated Security=True;";

        private SqlConnection connection = new SqlConnection(connectionString);
        public static string UserName { get; set; }
        public void setServiceName(string servicename)
        {
            UserName = servicename;
        }
        public bool setInfoinDataBase(string name, string phone, string product, string addres)
        {
            try
            {
                connection.Open();
                string query = "INSERT INTO diller(namediller,phonenumber,product,Adress) VALUES (@name,@phone,@product,@addres)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@phone", phone);
                command.Parameters.AddWithValue("@product", product);
                command.Parameters.AddWithValue("@addres", addres);
                command.ExecuteNonQuery();

                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Произошла ошибка при работе с базой данных:\n{ex.Message}",
                                  "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        public bool setInfoinDataBase(string login,string pass,string phoneNumber)
        {
            try
            {
                connection.Open();
                string query = "INSERT INTO UserLog(name,number,pass,truth_of_access) VALUES (@login,@pass,@phone,@truth_of_access)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@login", login);
                command.Parameters.AddWithValue("@phone", phoneNumber);
                command.Parameters.AddWithValue("@pass", pass);
                command.Parameters.AddWithValue("@truth_of_access", 0);
                command.ExecuteNonQuery();

                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Произошла ошибка при работе с базой данных:\n{ex.Message}",
                                  "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        public DataTable getDataFromDataBase(string query)
        {
            try
            {
                DataTable dataTable = new DataTable();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    connection.Open();
                    adapter.Fill(dataTable);
                }

                return dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка\n{ex.Message}", "Произошла ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public DataTable getDataFromDataBase(bool flag)
        {
            string query = "SELECT [id],[data_create],[fio],[name_product],[name_company],[tehTask] FROM product_info WHERE kyrator =@kyratorName";
            try
            {
                DataTable dataTable = new DataTable();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    command.Parameters.AddWithValue("@kyratorName", UserName);
                    connection.Open();
                    adapter.Fill(dataTable);
                }

                return dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка\n{ex.Message}", "Произошла ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public void setServiceInUser(int serviceId)
        {
            try
            {
                string userName = UserName;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlTransaction transaction = connection.BeginTransaction();
                    try
                    {
                        string assignProjectQuery = "UPDATE UserLog SET service = @serviceId WHERE name = @userName";
                        using (SqlCommand assignProjectCommand = new SqlCommand(assignProjectQuery, connection, transaction))
                        {
                            assignProjectCommand.Parameters.AddWithValue("@userName", userName);
                            assignProjectCommand.Parameters.AddWithValue("@serviceId", serviceId);
                            assignProjectCommand.ExecuteNonQuery();
                        }
                        transaction.Commit();
                        MessageBox.Show("Ваш заказ принят. В ближаейшее время с вами свяжеться фотограф.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private int GetUserIdByServiceName(string curatorName)
        {
            int curatorId = -1;
            try
            {
                string query = "SELECT id FROM UserLog WHERE name = @curatorName";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@curatorName", curatorName);

                    object result = command.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        curatorId = Convert.ToInt32(result);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Произошла ошибка при получении id куратора", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
            return curatorId;
        }
        public void deletDiller(string name)
        {
            try
            {
                string existingName = searchNameDiller(name);

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string deleteQuery = "DELETE FROM diller WHERE namediller = @name";
                    SqlCommand command = new SqlCommand(deleteQuery, connection);
                    command.Parameters.AddWithValue("@name", existingName);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected != 0)
                    {
                        MessageBox.Show($"{rowsAffected} строк удалено из таблицы", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (rowsAffected == 0)
                        MessageBox.Show("Диллера с таким именем не сущесвует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string searchNameDiller(string name)
        {
            string nameExists = "";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT namediller FROM diller;";
                    SqlCommand command = new SqlCommand(query, connection);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string dbName = reader["namediller"].ToString();
                            if (dbName.Equals(name, StringComparison.OrdinalIgnoreCase))
                            {
                                nameExists = dbName;
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при проверке имени: {ex.Message}");
            }
            return nameExists;
        }
    }
}