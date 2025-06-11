using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WinformsSQLpwHash_2
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            //add login stuff here
            

            string user = tbUserName.Text.Trim();
            string pass = tbPassword.Text;

            if (Program.TryLogin(user, pass))
            {
                Program.LoggedInUser = user;
                MessageBox.Show("Login successful!", "Information!");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
                MessageBox.Show("Invalid login. Please try again.", "Warning!");
        }

        private void tbUserName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
