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
    public partial class SalesReport : UserControl
    {
        private SqlConnection connection;

        public SalesReport()
        {
            InitializeComponent();
            Koneksyon koneksyon = new Koneksyon();
            connection = koneksyon.GetConnection();
        }

        // Method to load sales data from the Sales table
        private void LoadSalesData(DateTime? startDate = null, DateTime? endDate = null)
        {
            string query = "SELECT ProductID, ProductName, Brand, Category, QuantitySold, SalePrice, Cost, SaleDate FROM Sales";

            if (startDate.HasValue && endDate.HasValue)
            {
                query += " WHERE SaleDate BETWEEN @startDate AND @endDate";
            }

            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

                if (startDate.HasValue && endDate.HasValue)
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@startDate", startDate.Value);
                    adapter.SelectCommand.Parameters.AddWithValue("@endDate", endDate.Value);
                }

                DataTable salesDataTable = new DataTable();
                adapter.Fill(salesDataTable);
                salesDataGridView.DataSource = salesDataTable;

                // Calculate total sales
                decimal totalSales = salesDataTable.AsEnumerable().Sum(row => row.Field<decimal>("SalePrice"));
                totalSalesLabel.Text = $"Total Sales: {totalSales:C}";
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"Database error while loading sales data: {sqlEx.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading sales data: {ex.Message}");
            }
        }

        // Button click for showing daily sales
        private void btnShowDailySales_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = dateTimePicker.Value;
            LoadSalesData(selectedDate.Date, selectedDate.Date.AddDays(1));
        }

        // Button click for showing monthly sales
        private void btnShowMonthlySales_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = dateTimePicker.Value;
            LoadSalesData(new DateTime(selectedDate.Year, selectedDate.Month, 1),
                          new DateTime(selectedDate.Year, selectedDate.Month, DateTime.DaysInMonth(selectedDate.Year, selectedDate.Month)));
        }
        private void btnShowYearlySales_Click(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            LoadSalesData(new DateTime(now.Year, 1, 1), new DateTime(now.Year, 12, 31));
        }

        // Show all sales, no date filtering
        private void btnShowAllSales_Click(object sender, EventArgs e)
        {
            LoadSalesData(); // Load all sales without any date filters
        }

        public void RecordSale(int productId, string productName, string brand, string category, int quantitySold, decimal salePrice, decimal cost)
        {
            connection.Open(); // Open connection here
            using (SqlTransaction transaction = connection.BeginTransaction())
            {
                try
                {
                    // Record the sale
                    string insertQuery = "INSERT INTO Sales (ProductID, ProductName, Brand, Category, QuantitySold, SalePrice, Cost, SaleDate) " +
                                 "VALUES (@productId, @productName, @brand, @category, @quantitySold, @salePrice, @cost, GETDATE())";
                    using (SqlCommand cmd = new SqlCommand(insertQuery, connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@productId", productId);
                        cmd.Parameters.AddWithValue("@productName", productName);
                        cmd.Parameters.AddWithValue("@brand", brand);
                        cmd.Parameters.AddWithValue("@category", category);
                        cmd.Parameters.AddWithValue("@quantitySold", quantitySold);
                        cmd.Parameters.AddWithValue("@salePrice", salePrice * quantitySold);
                        cmd.Parameters.AddWithValue("@cost", cost);


                        cmd.ExecuteNonQuery();
                    }

                    // Commit transaction
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    // Rollback transaction on error
                    transaction.Rollback();
                    MessageBox.Show($"Error: {ex.Message}");
                }
                finally
                {
                    connection.Close(); // Ensure connection is closed after operation
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SalesReport_Load(object sender, EventArgs e)
        {

        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
