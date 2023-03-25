using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prototype_2
{
    public partial class formRegister : Form
    {
        public List<customers> newCustomers = new List<customers>();
        Boolean usernameTaken = false;

        public formRegister()
        {
            InitializeComponent();
        }

        public formRegister(List<customers> customers)
        {
            InitializeComponent();
            newCustomers = customers;
        }

            /// <summary>
            /// Creates an account from username and password inputted by user.
            /// Only works if both inputs are not empty.
            /// If successful, takes user to login screen.
            /// </summary>
            private void buttonRegister_Click(object sender, EventArgs e)
        {
            if(txtUsername.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Username or password field empty", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                usernameTaken = false;
                foreach(customers c in newCustomers)
                {
                    if (c.username.Equals(txtUsername.Text))
                    {
                        usernameTaken = true;
                    }
                }
                if (!usernameTaken)
                {
                    String username = txtUsername.Text;
                    String password = txtPassword.Text;
                    newCustomers.Add(new customers(username, password));

                    MessageBox.Show("Account successfully created", "Registration Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    new formLogin(newCustomers).Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Username already taken", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// If checkbox is checked, password is shown.
        /// Else, password is hidden.
        /// </summary>
        private void checkBoxShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxShowPass.Checked)
            {
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '•';
            }
        }

        /// <summary>
        /// Changes from registration to login page.
        /// </summary>
        private void labelLogIn_Click(object sender, EventArgs e)
        {
            new formLogin(newCustomers).Show();
            this.Hide();
        }

        /// <summary>
        /// Exits application.
        /// </summary>
        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
