using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LoginANDregistationSYSTEM
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        loginDBclassDataContext logcon = new loginDBclassDataContext();
        user us = new user();
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void clrbtn_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtUsername.Focus();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            new reg().Show();
            this.Hide();
        }

        private void chbxshwpss_CheckedChanged(object sender, EventArgs e)
        {
            if (chbxshwpss.Checked)
            {
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '*';
            }
        }

        private void loginbtn_Click(object sender, EventArgs e)
        {


            var user = logcon.users.Where(u => u.username.Equals(txtUsername.Text) && u.password.Equals(txtPassword.Text)).FirstOrDefault();
            if(user!=null)
            {
                home h = new home();
                h.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Error");
            }
        }
    }
    
}
