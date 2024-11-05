using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BikeShopManagement
{
    public partial class StockForm : Form
    {
        public int Quantity { get; private set; }

        public StockForm(string action)
        {
            InitializeComponent();
            this.Text = action;
            labelPrompt.Text = action;

            // Disable OK button initially
            okButton.Enabled = false;

            // Attach event handlers
            textBoxQuantity.KeyPress += TextBoxQuantity_KeyPress;
            textBoxQuantity.TextChanged += textBoxQuantity_TextChanged;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.TryParse(textBoxQuantity.Text, out int quantity) && quantity > 0)
                {
                    Quantity = quantity;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Please enter a positive number.");
                }
            }
            catch (OverflowException)
            {
                MessageBox.Show("The number you entered is too large. Please enter a smaller number.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}");
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void textBoxQuantity_TextChanged(object sender, EventArgs e)
        {
            // Enable the OK button only if there is a positive integer in the textbox
            if (int.TryParse(textBoxQuantity.Text, out int quantity) && quantity > 0)
            {
                okButton.Enabled = true;
            }
            else
            {
                okButton.Enabled = false;
            }
        }
        private void TextBoxQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only numeric characters and control characters (e.g., backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Block invalid input
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void StockForm_Load(object sender, EventArgs e)
        {

        }
    }

}
