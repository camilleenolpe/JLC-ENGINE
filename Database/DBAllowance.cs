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
    class DBAllowance
    {
        
        private int id;
        private decimal allowance;
        private DateTime datefrom;
        private DateTime dateto;

        public int Id
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

        public decimal Allowance
        {
            set
            {
                allowance = value;
            }
            get 
            {
                return allowance;
            }
        }
        public DateTime Datefrom
        {
            set
            {
                datefrom = value;
            }
            get
            {
                return datefrom;
            }
        }
        public DateTime Dateto
        {
            set
            {
                dateto = value;
            }
            get
            {
                return dateto;
            }
        }


        public DBAllowance()
        {
    
        }

         public DBAllowance(decimal allowance,DateTime datefrom)
        {
           
            this.allowance = allowance;
            this.datefrom = datefrom;
           
        }

       
         public void Add()
         {

             string query = "INSERT INTO allowance VALUES(@id,@allowance,@datefrom,@dateto)" ;

             MySqlConnection connection = DBConnection.ConnectDatabase();

             try
             {


                 MySqlCommand command = new MySqlCommand(query, connection);

                 command.Parameters.AddWithValue("@id", this.Id);
                 command.Parameters.AddWithValue("@allowance", this.Allowance);
                 command.Parameters.AddWithValue("@datefrom", this.Datefrom);
                 command.Parameters.AddWithValue("@dateto", this.Dateto);

                 command.ExecuteNonQuery();

                 MessageBox.Show("Daily allowance saved.");
                 
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
