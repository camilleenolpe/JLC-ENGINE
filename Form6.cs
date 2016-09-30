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
    public partial class Form6 : MetroForm
    {
        public Form6()
        {
            InitializeComponent();
        }
        
        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to save this as your allowance?", "ADD DAILY ALLOWANCE", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DBAllowance db = new DBAllowance(Convert.ToDecimal(txtAllowance.Text),Convert.ToDateTime(datefrom.Value));
                db.Add();
                
            }
        }
    }
}
