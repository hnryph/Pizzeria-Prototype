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
    public partial class formLogin : Form
    {
        List<customers> currentCustomers = new List<customers>();
        Boolean accountExists = false;

        public formLogin(List<customers> newCustomers)
        {
            InitializeComponent();
            currentCustomers = newCustomers;
        }

        /// <summary>
        /// If checkbox is checked, password is shown.
        /// Else, password is hidden.
        /// </summary>
        private void checkBoxShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShowPass.Checked)
            {
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '•';
            }
        }

        /// <summary>
        /// If user inputs a valid username and password, login is successful.
        /// Then takes the user to the menu.
        /// </summary>
        private void buttonLogIn_Click(object sender, EventArgs e)
        {
            foreach (customers c in currentCustomers)
            {
                if(txtUsername.Text == c.username && txtPassword.Text == c.password)
                {
                    accountExists = true;
                }
            }
            if(accountExists)
            {
                new system(currentCustomers).Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password. Please try again.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Sends back to registration.
        /// </summary>
        private void labelCreate_Click(object sender, EventArgs e)
        {
            new formRegister(currentCustomers).Show();
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
