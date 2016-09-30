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
    public partial class Form2 : MetroForm
    {
     

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtFullname.Text == "" || txtStudent_id.Text == "" || txtUsername.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Please Fill all the blanks given");
            }
            else
            {
                DBRegister r = new DBRegister(txtFullname.Text, txtStudent_id.Text, txtUsername.Text, txtPassword.Text);
                r.Add();
                this.Close();
                Form1 f1 = new Form1();
                f1.ShowDialog();

            }
        }

        private void txtPassword_Click(object sender, EventArgs e)
        {

            txtPassword.PasswordChar = '*';
        }

        private void txtStudent_id_Click(object sender, EventArgs e)
        {
            
        }

        private void txtStudent_id_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

        }

        private void txtFullname_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtFullname.Clear();
            txtStudent_id.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }

    }
}
