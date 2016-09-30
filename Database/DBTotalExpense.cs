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
    class DBTotalExpense
    {
        private DateTime datespend;
        private double totalexpense;
     
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
        public double Totalexpense
        {
            set
            {
                totalexpense = value;
            }
            get
            {
                return totalexpense;
            }
        }
     
       
        public DBTotalExpense()
        {

        }
        public DBTotalExpense(DateTime datespend, double totalexpense)
        {
            this.datespend = datespend;
            this.totalexpense = totalexpense;

        }
        public static List<DBTotalExpense> GetTotalToday()
        {
            List<DBTotalExpense> data = new List<DBTotalExpense>();

            MySqlConnection con = DBConnection.ConnectDatabase();

            string sqlDataGrid = "SELECT datespend,SUM(amount) FROM expenses GROUP BY datespend";

            try
            {
                MySqlCommand cmd = new MySqlCommand(sqlDataGrid, con);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        DBTotalExpense rawData = new DBTotalExpense();
                        rawData.DateSpend = reader.GetDateTime(0);
                        rawData.Totalexpense = reader.GetDouble(1);

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
