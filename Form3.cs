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


namespace SEM
{
    public partial class Form3 : MetroForm
    {
        public Form3()
        {
            InitializeComponent();
        }
      
        public DateTime DateSpend
        {
            get { return this.metroDateTime1.Value; }
            set { this.metroDateTime1.Value = value; }
        }

        public string Category
        {
            get { return this.txtCategory.Text; }
            set { this.txtCategory.Text = value; }
        }

        public string Description
        {
            get { return this.txtDescription.Text; }
            set { this.txtDescription.Text = value; }
        }

        public double Amount
        {
            get { return 0; }
            set { this.txtAmount.Text = Convert.ToString(value); }
        }

        Database.DBExpense r = new Database.DBExpense();
        //----------load data from expenses table to datagrid --------------//
        public void load_data()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                BindingSource bindingsource = new BindingSource();
                List<Database.DBExpense> rec = Database.DBExpense.GetData();
                foreach (Database.DBExpense data in rec)

                    bindingsource.Add(new Database.DBExpense(
                    data.Id,
                    data.DateSpend,
                    data.Category,
                    data.Description,
                    data.Amount
                  
                    ));

                this.todays_expense.Refresh();
                this.todays_expense.AutoGenerateColumns = false;
                this.todays_expense.DataSource = bindingsource;
                this.todays_expense.ClearSelection();

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        //----------load student id --------------//
       /* public void load_studentid()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                BindingSource bindingsource = new BindingSource();
                List<Database.DBExpense> rec = Database.DBExpense.GetStudentid();
                foreach (Database.DBExpense data in rec)

                    bindingsource.Add(new Database.DBExpense(
                    data.Id,
                    data.DateSpend,
                    data.Category,
                    data.Description,
                    data.Amount

                    ));

                this.todays_expense.Refresh();
                this.todays_expense.AutoGenerateColumns = false;
                this.todays_expense.DataSource = bindingsource;
                this.todays_expense.ClearSelection();
                studentid.Text = id.ToString();
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        */
        //----------load category-combobox --------------//
        public void load_Category()
        {
            List<Database.DBCategory> obj;

            obj = Database.DBCategory.GetData();
            this.txtCategory.Items.Clear();
            foreach (Database.DBCategory rec in obj)
            {
                this.txtCategory.Items.Add(rec);
            }
        }
        //----------load form3 --------------//
        private void Form3_Load(object sender, EventArgs e)
        {
            load_data();
            load_Category();
           // load_studentid();
        }

        private void lblExpenseHistory_Click(object sender, EventArgs e)
        {

        }

        private void metroButton1_MouseClick(object sender, MouseEventArgs e)
        {
            Form6 f6 = new Form6();
            f6.ShowDialog();
        }
        //---------- select category --------------//
        private void txtCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            Database.DBCategory item = (Database.DBCategory)this.txtCategory.SelectedItem;

            r.Category = this.txtCategory.SelectedText;
        }
        //----------Button add --------------//
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Database.DBExpense r = new Database.DBExpense(this.id.ToString(), Convert.ToDateTime(metroDateTime1.Value), txtCategory.Text, txtDescription.Text, Convert.ToDouble(txtAmount.Text));
            
                    DialogResult dialogResult = MessageBox.Show(" Do you want to add this record?", "Add", MessageBoxButtons.YesNo);

                    if (dialogResult == DialogResult.Yes)
                    {
                        r.Add();
                        load_data();
                    }
                }
               
            
            catch (Exception)
            {
                MessageBox.Show("Incomplete Fields!");
            }


            try
            {
                string[] row = new string[] { this.id.ToString(), Convert.ToString(metroDateTime1.Value), txtCategory.Text, txtDescription.Text, txtAmount.Text };

                todays_expense.Rows.Add(row);
                todays_expense.Refresh();

                txtCategory.ResetText();
                txtDescription.Clear();
                txtAmount.Clear();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
              
        }
        //----------Button delete --------------//
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string id = todays_expense.CurrentRow.Cells[1].Value.ToString();
                Database.DBExpense cards = Database.DBExpense.GetDataID(id);

                if (cards == null)
                {

                    DialogResult dialogResult = MessageBox.Show(" Do you want to delete this record?", "Delete", MessageBoxButtons.YesNo);

                    if (dialogResult == DialogResult.Yes)
                    {
                      
                        r.Delete(id);
                        load_data();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting record " + ex.Message);
            }


        }

        //----------Button save --------------//
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (todays_expense.SelectedRows.Count > 0) // make sure user select at least 1 row 
            {

                string DateSpend = todays_expense.SelectedRows[0].Cells[1].Value + string.Empty;
                string Category = todays_expense.SelectedRows[0].Cells[2].Value + string.Empty;
                string Description = todays_expense.SelectedRows[0].Cells[3].Value + string.Empty;
                string Amount = todays_expense.SelectedRows[0].Cells[4].Value + string.Empty;
               
             
                metroDateTime1.Text = DateSpend;
                txtCategory.Text = Category;
                txtDescription.Text = Description;
                txtAmount.Text = Amount;
               
            }       
        }
        //----------Button edit --------------//
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (todays_expense.SelectedRows.Count > 0) // make sure user select at least 1 row 
            {
                string Date = todays_expense.SelectedRows[0].Cells[1].Value + string.Empty;
                string Category = todays_expense.SelectedRows[0].Cells[2].Value + string.Empty;
                string Description = todays_expense.SelectedRows[0].Cells[3].Value + string.Empty;
                string Amount = todays_expense.SelectedRows[0].Cells[4].Value + string.Empty;
               
            
                metroDateTime1.Value = DateSpend;
                txtCategory.Text = Category;
                txtDescription.Text = Description;
                txtAmount.Text = Amount;
              
            }       
            
           
           
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void lblExpenseHistory_MouseClick(object sender, MouseEventArgs e)
        {
            Form4 f4 = new Form4();
            f4.ShowDialog();
        }

        private void lblTotalExpense_MouseClick(object sender, MouseEventArgs e)
        {
            Form5 f5 = new Form5();
            f5.ShowDialog();
        }
      
                
      

    }
}
