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
    public partial class ProductForm : Form
    {
        public int ProductID { get; private set; }
        public string ProductName => productNameTextBox.Text;
        public string Category => categoryComboBox.Text;
        public string Brand => brandComboBox.Text;
        public int Quantity => int.Parse(quantityTextBox.Text);
        public decimal Price => decimal.Parse(priceTextBox.Text);
        public decimal Cost
        {
            get
            {
                if (decimal.TryParse(costTextBox.Text, out decimal cost))
                {
                    return cost;
                }
                else
                {
                    MessageBox.Show("Invalid cost format. Please enter a valid decimal value.",
                                    "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return 0; 
                }
            }
        }
        public ProductForm(int id, string title, string productName, string category, string brand, int quantity, decimal price, decimal cost, List<string> categories, List<string> brands)
        {
            InitializeComponent();
            this.Text = title;
            ProductID = id;

            productNameTextBox.Text = productName;
            quantityTextBox.Text = quantity.ToString();
            priceTextBox.Text = price.ToString();
            costTextBox.Text = cost.ToString();

            // Populate ComboBoxes and set selected values
            categoryComboBox.Items.AddRange(categories.ToArray());
            brandComboBox.Items.AddRange(brands.ToArray());
            categoryComboBox.Text = category;
            brandComboBox.Text = brand;
        }
        public ProductForm(string title, List<string> categories, List<string> brands)
        {
            InitializeComponent();
            this.Text = title;

            // Populate ComboBoxes with existing values
            categoryComboBox.Items.AddRange(categories.ToArray());
            brandComboBox.Items.AddRange(brands.ToArray());
        }

        private void quantityTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void ProductForm_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }


}
