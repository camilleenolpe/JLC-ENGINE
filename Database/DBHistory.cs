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
    class DBHistory
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
       
          public DBHistory()
        {

        }

        public DBHistory(string id, DateTime datespend, string category, string description, double amount)
        {
            this.id = id;
            this.datespend = datespend;
            this.category = category;
            this.description = description;
            this.amount = amount;

        }
        public static List<DBHistory> GetData()
        {
            List<DBHistory> data = new List<DBHistory>();

            MySqlConnection con = DBConnection.ConnectDatabase();

            string sqlDataGrid = "SELECT * FROM expenses";

            try
            {
                MySqlCommand cmd = new MySqlCommand(sqlDataGrid, con);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        DBHistory rawData = new DBHistory();
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
        public static List<DBHistory> GetDataByDateHistory( DateTime past, DateTime present)
        {
            List<DBHistory> data = new List<DBHistory>();

            MySqlConnection con = DBConnection.ConnectDatabase();
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM " + tablename + " WHERE datespend BETWEEN '" + past.ToString("yyyy-MM-dd") + " 0:0:0" + "' AND '" + present.ToString("yyyy-MM-dd") + " 23:59:59" + "'", con);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        DBHistory rawData = new DBHistory();
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
    }
    
}
