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
            string loginAttemptReply = "";

            if (Program.TryLogin(user, pass))
            {
                loginAttemptReply = "Login successful!";
                Program.LoggedInUser = user;
                MessageBox.Show($"{loginAttemptReply}", "Information!");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                loginAttemptReply = "Invalid login. Please try again.";
                MessageBox.Show($"{loginAttemptReply}", "Warning!");
            }

            //Log user attempt login
            Program.LogUserLogin(user, pass, loginAttemptReply);
        }

        private void tbUserName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
