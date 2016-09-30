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
    class DBLogin
    {
        private static string tablename = "login";

        private string studentid;
        private string username;
        private string password;

        public string Studentid
        {
            set
            {
                studentid = value;
            }
            get
            {
                return studentid;
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
      public DBLogin()
        {

        }
         public DBLogin( string username, string password)
        {
            this.username = username;
            this.password = password;
            
        }
    public void Add()
        {

            string query = "INSERT INTO login VALUES(13218441,@username,@password)";
           
            MySqlConnection connection = DBConnection.ConnectDatabase();

            try
            {


                MySqlCommand command = new MySqlCommand(query, connection);


                command.Parameters.AddWithValue("@student_id", this.Studentid);
                command.Parameters.AddWithValue("@username", this.Username);
                command.Parameters.AddWithValue("@password", this.Password);
          
                command.ExecuteNonQuery();

             

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
}
}