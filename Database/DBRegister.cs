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
    class DBRegister
    {
   

        
        private string fullname;
        private string student_id;
        private string username;
        private string password;

     
        public string Fullname
        {
            set
            {
                fullname = value;
            }
            get
            {
                return fullname;
            }
        }
        public string Student_id
        {
            set
            {
                student_id = value;
            }
            get
            {
                return student_id;
            }
        }
        public string Username
        {
            set
            {
                username = value;
            }
            get
            {
                return username;
            }
        }
        public string Password
        {
            set
            {
                password = value;
            }
            get
            {
                return password;
            }
        }

        public DBRegister()
        {

        }

        public DBRegister(string student_id, string fullname,  string username, string password)
        {
            this.student_id = student_id;
            this.fullname = fullname;
            this.username = username;
            this.password = password;

        }
        public void Add()
        {


            string query = "INSERT INTO register VALUES(@student_id,@fullname,@username,@password)";
            MySqlConnection connection = DBConnection.ConnectDatabase();

            try
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@student_id", this.Student_id);
                command.Parameters.AddWithValue("@fullname", this.Fullname);
                command.Parameters.AddWithValue("@username", this.Username);
                command.Parameters.AddWithValue("@password", this.Password);

                // command.Parameters.Add(new MySqlParameter("@IMG", imageBt));

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

        public static List<DBRegister> GetData()
        {
            List<DBRegister> data = new List<DBRegister>();

            MySqlConnection con = DBConnection.ConnectDatabase();

            string sqlDataGrid = "SELECT * FROM register";

            try
            {
                MySqlCommand cmd = new MySqlCommand(sqlDataGrid, con);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        DBRegister rawData = new DBRegister();
                        rawData.Student_id = reader.GetString(0);
                        rawData.Fullname = reader.GetString(1);
                        rawData.Username = reader.GetString(2);
                        rawData.Password = reader.GetString(3);

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
    }
}
