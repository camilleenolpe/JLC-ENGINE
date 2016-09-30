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
    public partial class Form1 : MetroForm
    {
       

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public string Username
        {
            get { return this.txtUsernameLogin.Text; }
            set { this.txtUsernameLogin.Text = value; }
        }
        public string Password
        {
            get { return this.txtPasswordLogin.Text; }
            set { this.txtPasswordLogin.Text = value; }
        }
    
      
        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            if (txtUsernameLogin.Text == "" || txtPasswordLogin.Text == "")
            {
                MessageBox.Show("Please Fill all the blanks given");
            }
            else
            {
                MySqlConnection con = DBConnection.ConnectDatabase();
                try
                {
                    MySqlCommand cmd = new MySqlCommand("select * from register where username='" + this.txtUsernameLogin.Text + "' and password='" + this.txtPasswordLogin.Text + "';", con);
                    MySqlDataReader reader = cmd.ExecuteReader();


                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            DBRegister rawdata = new DBRegister();
                            rawdata.Username = reader.GetString(2);
                            rawdata.Password = reader.GetString(3);


                        }
                        Database.DBLogin r = new Database.DBLogin(txtUsernameLogin.Text, txtPasswordLogin.Text);
                        r.Add();
                        MessageBox.Show("Logged in successfully!");
                        Form3 f3 = new Form3();
                        f3.ShowDialog();
                      
                    }
                    else
                    {
                        MessageBox.Show("Password or username is incorrect!");
                    }
                    reader.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
         
        }

        private void btnToRegister_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            var Form2 = new Form2();
            Form2.Closed += (s, args) => this.Close();
            Form2.Show();
        }
    }
}
