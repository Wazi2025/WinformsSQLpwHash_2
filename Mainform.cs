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
    public partial class Mainform : Form
    {
        public Mainform()
        {
            InitializeComponent();

            if (!Program.UserPrivileges(Program.LoggedInUser))
            {
                SystemMenu.Visible = false;
            }


        }

        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Add user routine here
             AddUserForm userForm = new AddUserForm();           
             userForm.Show();            
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            //Insert routine here
            List<string> data = new List<string>();

            //Add values from TextBoxes to List
            data.Add(tbFirstName.Text);
            data.Add(tbLastName.Text);
            data.Add(tbPhone.Text);
            data.Add(tbEmail.Text);
            data.Add(tbStreet.Text);
            data.Add(tbCity.Text);
            data.Add(tbZip.Text);
            data.Add(tbCountry.Text);

            if (data.Contains(""))
            {
                MessageBox.Show("Fields cannot be empty!", "Warning");
                return;
            }

            //Send TextBox values as parameters to SQLInsert method
            Program.SQLInsert(data);

            tbFirstName.Clear();
            tbLastName.Clear();
            tbPhone.Clear();
            tbEmail.Clear();
            tbStreet.Clear();
            tbCity.Clear();
            tbZip.Clear();
            tbCountry.Clear();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            //Select routine here
            //Add query result to DataSource component
            dataWindow.DataSource = Program.SQLSelect(tbWhere.Text);
        }

        private void systemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void AboutMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox aboutBox = new AboutBox();
            aboutBox.ShowDialog();
        }
    }
}
