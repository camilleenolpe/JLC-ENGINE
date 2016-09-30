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
    public partial class Form5 : MetroForm
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            load_totalexpensebyday();
        }
        public void load_totalexpensebyday()
        {

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                BindingSource bindingsource = new BindingSource();
                List<Database.DBTotalExpense> rec = Database.DBTotalExpense.GetTotalToday();
                foreach (Database.DBTotalExpense data in rec)

                    bindingsource.Add(new Database.DBTotalExpense(

                        
                         data.DateSpend,
                         data.Totalexpense
                    ));
                this.total_expense.Refresh();
                this.total_expense.AutoGenerateColumns = false;
                this.total_expense.DataSource = bindingsource;
                this.total_expense.ClearSelection();

                Cursor.Current = Cursors.Default;
                
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private void total_expense_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
