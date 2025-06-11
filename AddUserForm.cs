using Microsoft.IdentityModel.Tokens;
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
    public partial class AddUserForm : Form
    {
        
        public AddUserForm()
        {
            InitializeComponent();
            
        }

        private void AddUserForm_Load(object sender, EventArgs e)
        {
            
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            //Add new user routine here
            //Check for empty username/pw
            if (tbNewUser.Text.IsNullOrEmpty() || tbNewUserPw.Text.IsNullOrEmpty())
            {
                MessageBox.Show("Username/Password can not be empty.", "Error!");
                return;
            }

            //Add new User and PW into DB        
            if (Program.SQLAddUser(tbNewUser.Text, tbNewUserPw.Text))
            {
                MessageBox.Show("A user with that name already exists. Please choose another.", "Error!");
                return;
            }
            else
                MessageBox.Show("New user added successfully.", "Information!");

            tbNewUser.Clear();
            tbNewUserPw.Clear();
            this.Close();
        }
    }
}
