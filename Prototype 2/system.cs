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
    public partial class system : Form
    {
        public string address, apt, city, state, size, crust, toppings, drinkSize, drinkType;
        public int zip;
        private int checkCounter;
        private double price, toppingsCounter;
        decimal sum = 0;
        List<customers> currentCustomers = new List<customers>();
        Boolean isDelivery = true;

        public system(List<customers> customers)
        {
            InitializeComponent();
            panelNav.Height = buttonMenu.Height;
            panelNav.Top = buttonMenu.Top;
            panelNav.Left = buttonMenu.Left;
            buttonMenu.BackColor = Color.FromArgb(35, 35, 35);
            currentCustomers = customers;

            panelMenu.BringToFront();
        }
        /// <summary>
        /// View menu screen.
        /// </summary>
        private void buttonMenu_Click(object sender, EventArgs e)
        {
            panelNav.Height = buttonMenu.Height;
            panelNav.Top = buttonMenu.Top;
            panelNav.Left = buttonMenu.Left;
            buttonMenu.BackColor = Color.FromArgb(35, 35, 35);

            panelMenu.BringToFront();
        }

        /// <summary>
        /// Open delivery/pickup screen.
        /// </summary>
        private void buttonDelivery_Click(object sender, EventArgs e)
        {
            panelNav.Height = buttonDelivery.Height;
            panelNav.Top = buttonDelivery.Top;
            panelNav.Left = buttonDelivery.Left;
            buttonDelivery.BackColor = Color.FromArgb(35, 35, 35);

            panelDelivery.BringToFront();
        }

        /// <summary>
        /// Open order summary.
        /// </summary>
        private void buttonOrder_Click(object sender, EventArgs e)
        {
            sum = 0;
            panelNav.Height = buttonOrder.Height;
            panelNav.Top = buttonOrder.Top;
            panelNav.Left = buttonOrder.Left;
            buttonOrder.BackColor = Color.FromArgb(35, 35, 35);

            for (int i = 0; i < priceListBox.Items.Count; i++)
            {
                sum += Convert.ToDecimal(priceListBox.Items[i]);
            }
            totalCost.Text = "$" + Convert.ToString(sum);

            panelOrder.BringToFront();
        }

        /// <summary>
        /// Open restaurant contact information.
        /// </summary>
        private void buttonContact_Click(object sender, EventArgs e)
        {
            panelNav.Height = buttonContact.Height;
            panelNav.Top = buttonContact.Top;
            panelNav.Left = buttonContact.Left;
            buttonContact.BackColor = Color.FromArgb(35, 35, 35);

            panelContact.BringToFront();
        }

        /// <summary>
        /// Highlight last option chosen.
        /// </summary>
        private void buttonMenu_Leave(object sender, EventArgs e)
        {
            buttonMenu.BackColor = Color.FromArgb(45, 45, 45);
        }

        private void buttonDelivery_Leave(object sender, EventArgs e)
        {
            buttonDelivery.BackColor = Color.FromArgb(45, 45, 45);
        }

        private void buttonOrder_Leave(object sender, EventArgs e)
        {
            buttonOrder.BackColor = Color.FromArgb(45, 45, 45);
        }

        private void buttonContact_Leave(object sender, EventArgs e)
        {
            buttonContact.BackColor = Color.FromArgb(45, 45, 45);
        }

        /// <summary>
        /// Sign out of account.
        /// </summary>
        private void buttonSignOut_Click(object sender, EventArgs e)
        {
            new formRegister(currentCustomers).Show();
            this.Hide();
        }

        /// <summary>
        /// Exit application.
        /// </summary>
        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Change to pickup.
        /// </summary>
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                isDelivery = false;
                panelDeliveryInfo.Visible = false;
                labelDelivery.Text = "Pickup at 680 Arntson Rd, Suite 156, Marietta, GA 30060";
            }
        }

        /// <summary>
        /// Change to delivery.
        /// </summary>
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                isDelivery = true;
                panelDeliveryInfo.Visible = true;
                labelDelivery.Text = "Delivery at";
            }
        }

        /// <summary>
        /// Deliver information.
        /// </summary>
        private void txtAddress_TextChanged(object sender, EventArgs e)
        {
            address = txtAddress.Text;
        }

        private void txtApt_TextChanged(object sender, EventArgs e)
        {
            apt = txtApt.Text;
        }

        private void txtZip_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txtZip.Text, out zip))
            {
            }
        }

        private void txtCity_TextChanged(object sender, EventArgs e)
        {
            city = txtCity.Text;
        }

        private void txtState_TextChanged(object sender, EventArgs e)
        {
            state = txtState.Text;
        }

        /// <summary>
        /// Saves delivery information and places info in order summary.
        /// </summary>
        private void buttonSave_Click(object sender, EventArgs e)
        {
            txtAddress.Text = address;
            txtApt.Text = apt;
            txtZip.Text = "" + zip;
            txtCity.Text = city;
            txtState.Text = state;

            labelDelivery.Text = "Delivery at " + address + " " + apt + " " + zip + " " + city + ", " + state;
        }

        /// <summary>
        /// Brings up pizza creation screen.
        /// </summary>
        private void buttonCreate_Click(object sender, EventArgs e)
        {
            panelCreate.BringToFront();
        }

        private void buttonSmall_CheckedChanged(object sender, EventArgs e)
        {
            size = "Small";
        }

        private void buttonMed_CheckedChanged(object sender, EventArgs e)
        {
            size = "Medium";
        }

        private void buttonLarge_CheckedChanged(object sender, EventArgs e)
        {
            size = "Large";
        }

        private void buttonXL_CheckedChanged(object sender, EventArgs e)
        {
            size = "Extra large";
        }

        private void buttonThin_CheckedChanged(object sender, EventArgs e)
        {
            crust = "Thin";
        }

        private void buttonReg_CheckedChanged(object sender, EventArgs e)
        {
            crust = "Regular";
        }

        private void buttonPan_CheckedChanged(object sender, EventArgs e)
        {
            crust = "Pan";
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            CheckedListBox items = (CheckedListBox)sender;
            if (items.CheckedItems.Count > 3)
            {
                e.NewValue = CheckState.Unchecked;
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            toppingsCounter = 0;
            var items = new StringBuilder();
            foreach (Object ss in checkedListBox1.CheckedItems)
            {
                toppingsCounter++;
                items.Append(string.Format("{0}, ", ss.ToString()));
            }
            items.Remove(items.Length - 2, 1);

            if (size.Equals("Small"))
            {
                price = 4 + (0.5 * (toppingsCounter - 1));
            }
            else if (size.Equals("Medium"))
            {
                price = 6 + (0.75 * (toppingsCounter - 1));
            }
            else if (size.Equals("Large"))
            {
                price = 8 + (toppingsCounter - 1);
            }
            else if (size.Equals("Extra large"))
            {
                price = 10 + (1.25 * (toppingsCounter - 1));
            }
            toppings = items.ToString();

            if (size != null && crust != null && toppings != null)
            {
                orderListBox.Items.Add(new customerOrder(size, crust, toppings));

                priceListBox.Items.Add(String.Format("{0:0.00#}", price));

                panelMenu.BringToFront();
            }
            buttonSmall.Checked = false;
            buttonMed.Checked = false;
            buttonLarge.Checked = false;
            buttonXL.Checked = false;
            buttonThin.Checked = false;
            buttonReg.Checked = false;
            buttonPan.Checked = false;
            foreach (int i in checkedListBox1.CheckedIndices)
            {
                checkedListBox1.SetItemCheckState(i, CheckState.Unchecked);
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            panelMenu.BringToFront();
        }

        /// <summary>
        /// Brings up drinks menu.
        /// </summary>
        private void buttonDrinks_Click(object sender, EventArgs e)
        {
            panelDrinks.BringToFront();
        }

        private void smallDrink_CheckedChanged(object sender, EventArgs e)
        {
            drinkSize = "Small";
        }

        private void drinkMedium_CheckedChanged(object sender, EventArgs e)
        {
            drinkSize = "Medium";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            drinkSize = "Large";
        }

        private void buttonPepsi_CheckedChanged(object sender, EventArgs e)
        {
            drinkType = "Pepsi";
        }

        private void buttonDietPepsi_CheckedChanged(object sender, EventArgs e)
        {
            drinkType = "Diet Pepsi";
        }

        private void buttonOrange_CheckedChanged(object sender, EventArgs e)
        {
            drinkType = "Orange";
        }

        private void buttonDietOrange_CheckedChanged(object sender, EventArgs e)
        {
            drinkType = "Diet Orange";
        }

        private void buttonRootBeer_CheckedChanged(object sender, EventArgs e)
        {
            drinkType = "Root Beer";
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            drinkType = "Diet Root Beer";
        }

        private void buttonSierrra_CheckedChanged(object sender, EventArgs e)
        {
            drinkType = "Sierra Mist";
        }

        private void buttonLemonade_CheckedChanged(object sender, EventArgs e)
        {
            drinkType = "Lemonade";
        }

        /// <summary>
        /// Adds drink to order summary.
        /// </summary>
        private void addDrink_Click(object sender, EventArgs e)
        {
            orderListBox.Items.Add(drinkSize + " " + drinkType);
            priceListBox.Items.Add("1.00");

            panelMenu.BringToFront();

            smallDrink.Checked = false;
            drinkMedium.Checked = false;
            radioButton3.Checked = false;
            buttonPepsi.Checked = false;
            buttonDietPepsi.Checked = false;
            buttonOrange.Checked = false;
            buttonDietOrange.Checked = false;
            buttonRootBeer.Checked = false;
            radioButton7.Checked = false;
            buttonSierrra.Checked = false;
            buttonLemonade.Checked = false;
        }

        private void panelDeliveryInfo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            panelMenu.BringToFront();
        }

        /// <summary>
        /// Open other foods menu.
        /// </summary>
        private void buttonOtherFood_Click(object sender, EventArgs e)
        {
            panelOther.BringToFront();
        }

        /// <summary>
        /// Number of breadsticks and price is added to order.
        /// </summary>
        private void button2_Click(object sender, EventArgs e)
        {
            price = 4 * Convert.ToInt32(numBreadSticks.Text);
            orderListBox.Items.Add("Bread Sticks * " + numBreadSticks.Text);
            priceListBox.Items.Add(String.Format("{0:0.00#}", price));
        }

        /// <summary>
        /// Add bread stick bites and price to order summary.
        /// </summary>
        private void addBites_Click(object sender, EventArgs e)
        {
            price = 2 * Convert.ToInt32(numBites.Text);
            orderListBox.Items.Add("Bread Stick Bites * " + numBites.Text);
            priceListBox.Items.Add(String.Format("{0:0.00#}", price));
        }

        /// <summary>
        /// Add cookies and price to order summary.
        /// </summary>
        private void addCookies_Click(object sender, EventArgs e)
        {
            price = 4 * Convert.ToInt32(numCookies.Text);
            orderListBox.Items.Add("Cookies * " + numCookies.Text);
            priceListBox.Items.Add(String.Format("{0:0.00#}", price));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panelMenu.BringToFront();
        }

        private void orderListBox_Click(object sender, EventArgs e)
        {
            int i = orderListBox.SelectedIndex;

            if (i >= 0)
            {
                DialogResult result = MessageBox.Show("Would you like to delete this item?", "Delete item", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    orderListBox.Items.RemoveAt(i);
                    priceListBox.Items.RemoveAt(i);

                    sum = 0;
                    for (int j = 0; j < priceListBox.Items.Count; j++)
                    {
                        sum += Convert.ToDecimal(priceListBox.Items[j]);
                    }
                    totalCost.Text = "$" + Convert.ToString(sum);
                }
            }
        }

        /// <summary>
        /// Checkout.
        /// </summary>
        private void checkout_Click(object sender, EventArgs e)
        {
            panelCheckout.BringToFront();
        }

        /// <summary>
        /// Payment confirmation.
        /// </summary>
        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            panelMenu.BringToFront();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panelOrder.BringToFront();
        }
    }
}
