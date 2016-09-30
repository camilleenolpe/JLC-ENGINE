using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MetroFramework.Forms;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace SEM.Database
{
    class DBConnection
    {
        public static MySqlConnection ConnectDatabase()
        {
            MySqlConnection con = null;
            String connectionStr = @"server=localhost; database=expense_manager; userid=root; password=;pooling = false; convert zero datetime=True";

            try
            {
                con = new MySqlConnection(connectionStr);
                con.Open(); //open the connection
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Connection : " + ex.Message);
            }

            return con;
        }

    }
}
