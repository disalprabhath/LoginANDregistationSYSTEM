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
    public partial class reg : Form
    {
        loginDBclassDataContext logcon = new loginDBclassDataContext();
        user us = new user();
        public reg()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void clrbtn_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtconfirmpassword.Text = "";
            txtUsername.Focus();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            new Login().Show();
            this.Hide();
        }

        private void chbxshwpss_CheckedChanged(object sender, EventArgs e)
        {
            if (chbxshwpss.Checked)
            {
                txtPassword.PasswordChar = '\0';
                txtconfirmpassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '*';
                txtconfirmpassword.PasswordChar = '*';
            }
        }

        private void regbtn_Click(object sender, EventArgs e)
        {
            if(txtPassword.Text==txtconfirmpassword.Text)
            {
                us.username = txtUsername.Text;
                us.password = txtPassword.Text;
                
                MessageBox.Show("Successfully Registered","Successfull",MessageBoxButtons.OK,MessageBoxIcon.Information);

                logcon.users.InsertOnSubmit(us);
                logcon.SubmitChanges();
                new Login().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("password dosen't match" , "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
          

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
