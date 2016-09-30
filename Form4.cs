using MetroFramework.Forms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SEM.Database;

namespace SEM
{
    public partial class Form4 : MetroForm
    {
        public DateTime DatePast
        {
            get { return this.metroDateTime1.Value; }
            set { this.metroDateTime1.Value = value; }
        }

        public DateTime DatePresent
        {
            get { return this.metroDateTime2.Value; }
            set { this.metroDateTime2.Value = value; }
        }
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            metroDateTime1.Value = metroDateTime2.Value = DatePast = DatePresent = DateTime.Now;
           
            load_expensehistory();
            expense_history.Refresh();
        }
        public void load_expensehistory()
        {

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                BindingSource bindingsource = new BindingSource();
                List<Database.DBHistory> rec = Database.DBHistory.GetData();
                foreach (Database.DBHistory data in rec)

                    bindingsource.Add(new Database.DBHistory(
                        data.Id,
                        data.DateSpend,
                        data.Category,
                        data.Description,
                        data.Amount
                    ));

                this.expense_history.AutoGenerateColumns = false;
                this.expense_history.DataSource = bindingsource;
                this.expense_history.ClearSelection();

                Cursor.Current = Cursors.Default;

            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        public void load_expense_history()
        {

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                BindingSource bindingsource = new BindingSource();
                List<Database.DBHistory> rec = Database.DBHistory.GetDataByDateHistory(DatePast,DatePresent);
                foreach (Database.DBHistory data in rec)

                    bindingsource.Add(new Database.DBHistory(
                        data.Id,
                        data.DateSpend,
                        data.Category,
                        data.Description,
                        data.Amount
                    ));
             
                this.expense_history.AutoGenerateColumns = false;
                this.expense_history.DataSource = bindingsource;
                this.expense_history.ClearSelection();

                Cursor.Current = Cursors.Default;
             
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        
        private void metroDateTime1_ValueChanged(object sender, EventArgs e)
        {
            load_expense_history();
        }

        private void metroDateTime2_ValueChanged(object sender, EventArgs e)
        {
            load_expense_history();
        }
    }
}
