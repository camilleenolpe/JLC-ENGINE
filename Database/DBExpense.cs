using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MetroFramework.Forms;
using MySql.Data.MySqlClient;
using SEM.Database;
namespace SEM.Database
{
    class DBExpense
    {
        private static string tablename = "expenses";

        private string id;
        private DateTime datespend;
        private string category;
        private string description;
        private double amount;
       


        public string Id
        {
            set
            {
                id = value;
            }
            get
            {
                return id;
            }
        }

        public DateTime DateSpend
        {
            set
            {
                datespend = value;
            }
            get
            {
                return datespend;
            }
        }
        public string Category
        {
            set
            {
                category = value;
            }
            get
            {
                return category;
            }
        }
        public string Description
        {
            set
            {
                description = value;
            }
            get
            {
                return description;
            }
        }
        public double Amount
        {
            set
            {
                amount = value;
            }
            get
            {
                return amount;
            }
        }
       



        public DBExpense()
        {

        }

        public DBExpense( string id,DateTime datespend, string category, string description, double amount)
        {
            this.id = id;
            this.datespend = datespend;
            this.category = category;
            this.description = description;
            this.amount = amount;

        }
        //------------------------add expense method-------------------------//
        public void Add()
        {

            string query = "INSERT INTO expenses VALUES(@id,@datespend,@category,@description,@amount)";
           
            MySqlConnection connection = DBConnection.ConnectDatabase();

            try
            {


                MySqlCommand command = new MySqlCommand(query, connection);

                command.Parameters.AddWithValue("@id", this.Id);
                command.Parameters.AddWithValue("@datespend", this.DateSpend);
                command.Parameters.AddWithValue("@category", this.Category);
                command.Parameters.AddWithValue("@description", this.Description);
                command.Parameters.AddWithValue("@amount", this.Amount);
          
                command.ExecuteNonQuery();

                MessageBox.Show("Added Successfully");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            finally
            {
                connection.Close();
            }


        }

        public static List<DBExpense> GetData(string today)
        {

            List<DBExpense> data = new List<DBExpense>();

            MySqlConnection con = DBConnection.ConnectDatabase();

            string sqlDataGrid = "SELECT * FROM expenses WHERE datespend LIKE '%" + today + "%'";

            try
            {
                MySqlCommand cmd = new MySqlCommand(sqlDataGrid, con);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        DBExpense rawData = new DBExpense();
                        rawData.Id = reader.GetString(0);
                        rawData.DateSpend = reader.GetDateTime(1);
                        rawData.Category = reader.GetString(2);
                        rawData.Description = reader.GetString(3);
                        rawData.Amount = reader.GetDouble(4);

                        data.Add(rawData);
                    }
                }

                reader.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }

            return data;
        }
        public static List<DBExpense> GetStudentid()
        {
            List<DBExpense> data = new List<DBExpense>();

            MySqlConnection con = DBConnection.ConnectDatabase();

            string sqlDataGrid = "SELECT student_id FROM login ";

            try
            {
                MySqlCommand cmd = new MySqlCommand(sqlDataGrid, con);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        DBExpense rawData = new DBExpense();
                        rawData.Id = reader.GetString(0);
                        
                        data.Add(rawData);
                    }
                }

                reader.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }

            return data;
        }
        public static List<DBExpense> GetDataToday(DateTime datespend)
        {
            List<DBExpense> data = new List<DBExpense>();

            MySqlConnection con = DBConnection.ConnectDatabase();
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM " + tablename + " WHERE datespend = " + datespend , con);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        DBExpense rawData = new DBExpense();
                        rawData.Id = reader.GetString(0);
                        rawData.DateSpend = reader.GetDateTime(1);
                        rawData.Category = reader.GetString(2);
                        rawData.Description = reader.GetString(3);
                        rawData.Amount = reader.GetDouble(4);

                        data.Add(rawData);
                    }
                }

                reader.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }

            return data;
        }
        //------------------------delete expense method-------------------------//
        public void Delete(string id)
        {
            MySqlConnection con = DBConnection.ConnectDatabase();
            string command = "DELETE FROM " + tablename + " WHERE id=@id";

            try
            {
                MySqlCommand cmd = new MySqlCommand(command, con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery(); //execute the mysql command

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        public static DBExpense GetDataID(string id)
        {
            DBExpense data = null;

            MySqlConnection con = DBConnection.ConnectDatabase();

            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM login" + " WHERE studentid=" + id, con);

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {

                    reader.Read();

                    data = new DBExpense();
                    data.Id = reader.GetString(0);
                    data.DateSpend = reader.GetDateTime(1);
                    data.Category = reader.GetString(2);
                    data.Description = reader.GetString(3);
                    data.Amount = reader.GetDouble(4);

                }

                reader.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }

            return data;

        }
        //------------------------save/update expense method-------------------------//
        public void Update()
        {

            string cmdText = "UPDATE " + tablename + " SET  datespend = @datespend, category = @category,description =@description,amount = @amount";
            MySqlConnection con = DBConnection.ConnectDatabase();

            try
            {
                MySqlCommand cmd = new MySqlCommand(cmdText, con);
                cmd.Parameters.AddWithValue("@id", this.Id);
                cmd.Parameters.AddWithValue("@datespend", this.DateSpend);
                cmd.Parameters.AddWithValue("@category", this.Category);
                cmd.Parameters.AddWithValue("@description", this.Description);
                cmd.Parameters.AddWithValue("@amount", this.Amount);



                cmd.ExecuteNonQuery(); //execute the mysql command

                MessageBox.Show("Updated");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

    }
}
