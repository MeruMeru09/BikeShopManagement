    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;


    namespace BikeShopManagement
    {
        public partial class InventoryManagement : UserControl
        {
            private Koneksyon koneksyon;
            private SqlConnection connection;
            private SqlDataAdapter adapter;
            private DataTable dataTable;
            private SalesReport salesReport; 

            public InventoryManagement(SalesReport salesReport)
            {
                InitializeComponent();
                koneksyon = new Koneksyon();
                connection = koneksyon.GetConnection();
                this.salesReport = salesReport;
                LoadInventoryData();
            }

        private void LoadInventoryData() // load inventory data into the DataGridView
        {
            try
            {
                string query = "SELECT * FROM Inventory"; //select everything
                adapter = new SqlDataAdapter(query, connection);
                dataTable = new DataTable();
                adapter.Fill(dataTable);
                inventoryGridView.DataSource = dataTable;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("An error occurred while loading inventory data. Please try again later.");
                Console.WriteLine(ex.Message);  
            }
        }
        private void addButton_Click(object sender, EventArgs e) // adding a new product to inventory
        {
            try
            {
                List<string> categories = GetExistingValues("Category");
                List<string> brands = GetExistingValues("Brand");

                using (ProductForm productForm = new ProductForm("Add New Product", categories, brands))
                {
                    if (productForm.ShowDialog() == DialogResult.OK)
                    {
                        string checkQuery = "SELECT COUNT(*) FROM Inventory WHERE ProductName = @name"; // Check if the product name already exists
                        using (SqlCommand checkCmd = new SqlCommand(checkQuery, connection))
                        {
                            checkCmd.Parameters.AddWithValue("@name", productForm.ProductName);
                            connection.Open();
                            int count = (int)checkCmd.ExecuteScalar();
                            connection.Close();

                            if (count > 0)
                            {
                                MessageBox.Show("A product with this name already exists. Please choose a different name.");
                                return;
                            }
                        }

                        string query = "INSERT INTO Inventory (ProductName, Category, Brand, Quantity, Price, Cost) " +
                                       "VALUES (@name, @category, @brand, @quantity, @price, @cost)";
                        using (SqlCommand cmd = new SqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@name", productForm.ProductName);
                            cmd.Parameters.AddWithValue("@category", productForm.Category);
                            cmd.Parameters.AddWithValue("@brand", productForm.Brand);
                            cmd.Parameters.AddWithValue("@quantity", productForm.Quantity);
                            cmd.Parameters.AddWithValue("@price", productForm.Price);
                            cmd.Parameters.AddWithValue("@cost", productForm.Cost);

                            connection.Open();
                            cmd.ExecuteNonQuery();
                            connection.Close();
                        }

                        MessageBox.Show("Product added successfully.");
                        LoadInventoryData();
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("An error occurred while adding the product. Please try again.");
                Console.WriteLine(ex.Message);  
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }


        private void deleteButton_Click(object sender, EventArgs e) // deleting a selected product
        {
            // Check if a product is selected in the inventory grid view.
            if (inventoryGridView.SelectedRows.Count > 0)
            {
                // confirmation dialog asking the user if they are sure about deleting the selected product.
                DialogResult result = MessageBox.Show("Are you sure you want to delete this product?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                // Proceed with deletion if the user clicked 'Yes'.
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // Get the selected product's ID from the grid view.
                        int productID = (int)inventoryGridView.SelectedRows[0].Cells[0].Value;
                        string query = "DELETE FROM Inventory WHERE ProductID = @id";

                         using (SqlCommand cmd = new SqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@id", productID);
                            connection.Open();
                            cmd.ExecuteNonQuery();
                            connection.Close();
                        }

                         MessageBox.Show("Product deleted successfully.");
                        // Refresh the inventory grid to reflect the changes.
                        LoadInventoryData();
                    }
                    catch (SqlException ex)
                    {
                         MessageBox.Show("An error occurred while deleting the product. Please try again.");
                        Console.WriteLine(ex.Message);  
                    }
                    finally
                    {
                        // Ensure that the database connection is closed if it was left open.
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                    }
                }
                // If the user clicked 'No', do nothing and exit the method.
            }
            else
            {
                 MessageBox.Show("Please select a product to delete.");
            }
        }


        private void updateButton_Click(object sender, EventArgs e) // updating the selected product
        {
            if (inventoryGridView.SelectedRows.Count > 0)
            {
                try
                {
                    int productID = Convert.ToInt32(inventoryGridView.SelectedRows[0].Cells["ProductID"].Value);
                    string currentName = (string)inventoryGridView.SelectedRows[0].Cells["ProductName"].Value;
                    string currentCategory = (string)inventoryGridView.SelectedRows[0].Cells["Category"].Value;
                    string currentBrand = (string)inventoryGridView.SelectedRows[0].Cells["Brand"].Value;
                    int currentQuantity = Convert.ToInt32(inventoryGridView.SelectedRows[0].Cells["Quantity"].Value);
                    decimal currentPrice = Convert.ToDecimal(inventoryGridView.SelectedRows[0].Cells["Price"].Value);
                    decimal currentCost = Convert.ToDecimal(inventoryGridView.SelectedRows[0].Cells["Cost"].Value);

                    List<string> categories = GetExistingValues("Category");
                    List<string> brands = GetExistingValues("Brand");

                    using (ProductForm updateForm = new ProductForm(productID, "Update Product", currentName, currentCategory, currentBrand, currentQuantity, currentPrice, currentCost, categories, brands))
                    {
                        if (updateForm.ShowDialog() == DialogResult.OK)
                        {
                            string query = "UPDATE Inventory SET ProductName = @name, Category = @category, Brand = @brand, Quantity = @quantity, Price = @price, Cost = @cost WHERE ProductID = @id";
                            using (SqlCommand cmd = new SqlCommand(query, connection))
                            {
                                cmd.Parameters.AddWithValue("@name", updateForm.ProductName);
                                cmd.Parameters.AddWithValue("@category", updateForm.Category);
                                cmd.Parameters.AddWithValue("@brand", updateForm.Brand);
                                cmd.Parameters.AddWithValue("@quantity", updateForm.Quantity);
                                cmd.Parameters.AddWithValue("@price", updateForm.Price);
                                cmd.Parameters.AddWithValue("@cost", updateForm.Cost);
                                cmd.Parameters.AddWithValue("@id", updateForm.ProductID);

                                connection.Open();
                                cmd.ExecuteNonQuery();
                                connection.Close();
                            }

                            MessageBox.Show("Product updated successfully.");
                            LoadInventoryData();
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("An error occurred while updating the product. Please try again.");
                    Console.WriteLine(ex.Message); // Or log the error message
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a product to update.");
            }
        }

        private List<string> GetExistingValues(string column) // get distinct values (e.g., categories or brands) from the inventory
        {
            List<string> values = new List<string>();
            try
            {
                string query = $"SELECT DISTINCT {column} FROM Inventory";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            values.Add(reader[column].ToString());
                        }
                    }
                    connection.Close();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"An error occurred while fetching {column} data. Please try again.");
                Console.WriteLine(ex.Message); // Or log the error message
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            return values;
        }

        private void searchButton_Click(object sender, EventArgs e) // searching the inventory based on a search term
        {
            try
            {
                string searchTerm = textBoxSearch.Text.Trim();
                string query = "SELECT * FROM Inventory WHERE ProductName LIKE @search OR Category LIKE @search OR Brand LIKE @search";

                adapter = new SqlDataAdapter(query, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@search", "%" + searchTerm + "%");

                dataTable = new DataTable();
                adapter.Fill(dataTable);

                inventoryGridView.DataSource = dataTable;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("An error occurred while searching. Please try again.");
                Console.WriteLine(ex.Message); // Or log the error message
            }
        }

        private void inventoryGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {

            }

            private void buttonViewAll_Click(object sender, EventArgs e) //  Handles the "View All" button and display all values in the grid
        {
                LoadInventoryData();
            }

            private void buttonAddStock_Click(object sender, EventArgs e) // add more stock to a selected product in the inventory.
        {
            if (inventoryGridView.SelectedRows.Count > 0)
            {
                try
                {
                    int productID = Convert.ToInt32(inventoryGridView.SelectedRows[0].Cells["ProductID"].Value);
                    int currentQuantity = Convert.ToInt32(inventoryGridView.SelectedRows[0].Cells["Quantity"].Value);

                    using (StockForm stockForm = new StockForm("Add Stock"))
                    {
                        if (stockForm.ShowDialog() == DialogResult.OK)
                        {
                            int newQuantity = currentQuantity + stockForm.Quantity;

                            string query = "UPDATE Inventory SET Quantity = @quantity WHERE ProductID = @id";
                            using (SqlCommand cmd = new SqlCommand(query, connection))
                            {
                                cmd.Parameters.AddWithValue("@quantity", newQuantity);
                                cmd.Parameters.AddWithValue("@id", productID);
                                connection.Open();
                                cmd.ExecuteNonQuery();
                                connection.Close();
                            }

                            MessageBox.Show("Stock added successfully.");
                            LoadInventoryData();
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("An error occurred while adding stock. Please try again.");
                    Console.WriteLine(ex.Message); // Or log the error message
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a product to add stock.");
            }
        }

        private void buttonSellStock_Click(object sender, EventArgs e) // sell a specified quantity of a selected product.
        {
                if (inventoryGridView.SelectedRows.Count > 0)
                {
                    int productID = Convert.ToInt32(inventoryGridView.SelectedRows[0].Cells["ProductID"].Value);
                    int currentQuantity = Convert.ToInt32(inventoryGridView.SelectedRows[0].Cells["Quantity"].Value);
                    string productName = (string)inventoryGridView.SelectedRows[0].Cells["ProductName"].Value; 
                    string brand = (string)inventoryGridView.SelectedRows[0].Cells["Brand"].Value; 
                    string category = (string)inventoryGridView.SelectedRows[0].Cells["Category"].Value; 

                    using (StockForm stockForm = new StockForm("Sell Stock"))
                    {
                        if (stockForm.ShowDialog() == DialogResult.OK)
                        {
                            if (stockForm.Quantity > currentQuantity)
                            {
                                MessageBox.Show("Not enough stock to sell.");
                            }
                            else
                            {
                                int newQuantity = currentQuantity - stockForm.Quantity;

                                string query = "UPDATE Inventory SET Quantity = @quantity WHERE ProductID = @id";
                                using (SqlCommand cmd = new SqlCommand(query, connection))
                                {
                                    cmd.Parameters.AddWithValue("@quantity", newQuantity);
                                    cmd.Parameters.AddWithValue("@id", productID);
                                    connection.Open();
                                    cmd.ExecuteNonQuery();
                                    connection.Close();
                                }
                                salesReport.RecordSale(productID, productName, brand, category, stockForm.Quantity, Convert.ToDecimal(inventoryGridView.SelectedRows[0].Cells["Price"].Value), Convert.ToDecimal(inventoryGridView.SelectedRows[0].Cells["Cost"].Value));

                                MessageBox.Show("Stock sold successfully.");
                                LoadInventoryData();
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select a product to sell.");
                }
            }
        private void btnExit_Click(object sender, EventArgs e) // exit the application
        {
            Application.Exit();
        }

    }  


    }
