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
using System.Windows.Forms.DataVisualization.Charting;


namespace BikeShopManagement
{
    public partial class dashboard : UserControl
    {
        private SqlConnection connection;
        private Timer timer;


        public dashboard()
        {
            InitializeComponent();
            Koneksyon koneksyon = new Koneksyon();
            connection = koneksyon.GetConnection();
            LoadTotalSales();

            timer = new Timer();
            timer.Interval = 5000; // update the dashboard (every 5 seconds)
            timer.Tick += Timer_Tick; 
            timer.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            // Refresh all dashboard data

            LoadTotalSales();
            LoadTotalInventory();
            LoadLowStockItems();
            LoadInventoryValue();
            LoadTotalProfit();
            LoadTotalCost();
            UpdateProfitCostChart();

        }


        // Updates the chart to display profit and cost values, optionally filtered by date
        private void UpdateProfitCostChart(DateTime? startDate = null, DateTime? endDate = null)
        {
            try
            {
                connection.Open();

                // Query for total sales and cost data
                string queryProfit = "SELECT SUM(SalePrice) FROM Sales";
                string queryCost = "SELECT SUM(Cost * QuantitySold) FROM Sales";

                if (startDate.HasValue && endDate.HasValue)// If a date range is provided, filter the data by date

                {
                    queryProfit += " WHERE SaleDate BETWEEN @startDate AND @endDate";
                    queryCost += " WHERE SaleDate BETWEEN @startDate AND @endDate";
                }

                decimal totalProfit = 0, totalCost = 0;

                using (SqlCommand profitCommand = new SqlCommand(queryProfit, connection))
                using (SqlCommand costCommand = new SqlCommand(queryCost, connection))
                {
                    if (startDate.HasValue && endDate.HasValue)
                    {
                        profitCommand.Parameters.AddWithValue("@startDate", startDate.Value);
                        profitCommand.Parameters.AddWithValue("@endDate", endDate.Value);
                        costCommand.Parameters.AddWithValue("@startDate", startDate.Value);
                        costCommand.Parameters.AddWithValue("@endDate", endDate.Value);
                    }

                    // Get total sales and total cost values
                    object profitResult = profitCommand.ExecuteScalar();
                    object costResult = costCommand.ExecuteScalar();

                    totalProfit = (profitResult != DBNull.Value) ? Convert.ToDecimal(profitResult) : 0;
                    totalCost = (costResult != DBNull.Value) ? Convert.ToDecimal(costResult) : 0;
                }

                // Update the chart with the new data
                chart1.Series.Clear();
                Series series = new Series("Total Values");
                series.Points.AddXY("Total Profit", totalProfit);
                series.Points.AddXY("Total Cost", totalCost);

                chart1.Series.Add(series);
                chart1.ChartAreas[0].RecalculateAxesScale();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating chart: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
        }

        // Loads and displays total sales from the database, optionally filtered by date
        private void LoadTotalSales(DateTime? startDate = null, DateTime? endDate = null)
        {
            string query = "SELECT SUM(SalePrice) AS TotalSales FROM Sales";

            if (startDate.HasValue && endDate.HasValue) // Apply date filter if a range is provided

            {
                query += " WHERE SaleDate BETWEEN @startDate AND @endDate";
            }

            try
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (startDate.HasValue && endDate.HasValue)
                    {
                        command.Parameters.AddWithValue("@startDate", startDate.Value);
                        command.Parameters.AddWithValue("@endDate", endDate.Value);
                    }

                    object result = command.ExecuteScalar();
                    if (result != DBNull.Value && result != null)
                    {
                        decimal totalSales = Convert.ToDecimal(result);
                        label2.Text = $"{totalSales:C}";
                    }
                    else
                    {
                        label2.Text = "0";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching total sales: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
        }
        
        private void LoadTotalInventory()// Loads and displays the total number of items in inventory
        {
            try
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM Inventory";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    object result = command.ExecuteScalar();
                    int totalInventory = result != DBNull.Value ? Convert.ToInt32(result) : 0;
                    label8.Text = totalInventory.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching total inventory: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
        }
       
        private void LoadLowStockItems() // Loads and displays the number of items in inventory with low stock

        {
            try
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM Inventory WHERE Quantity < 5";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    object result = command.ExecuteScalar();
                    int lowStockCount = result != DBNull.Value ? Convert.ToInt32(result) : 0;
                    label10.Text = lowStockCount.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching low stock items: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
        }


        private void LoadInventoryValue() // Load and displays inventory values
        {
            try
            {
                connection.Open();
                string query = "SELECT SUM(Price * Quantity) FROM Inventory";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    object result = command.ExecuteScalar();
                    decimal inventoryValue = result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                    label9.Text = $"{inventoryValue:C}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching inventory value: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
        }

        private void LoadTotalProfit(DateTime? startDate = null, DateTime? endDate = null) // Loads and displays total profit, optionally filtered by date
        {
            try
            {
                connection.Open();

                string querySales = "SELECT SUM(SalePrice) FROM Sales";
                string queryCost = "SELECT SUM(Cost * QuantitySold) FROM Sales";

                if (startDate.HasValue && endDate.HasValue)
                {
                    querySales += " WHERE SaleDate BETWEEN @startDate AND @endDate";
                    queryCost += " WHERE SaleDate BETWEEN @startDate AND @endDate";
                }

                using (SqlCommand salesCommand = new SqlCommand(querySales, connection))
                using (SqlCommand costCommand = new SqlCommand(queryCost, connection))
                {
                    if (startDate.HasValue && endDate.HasValue)
                    {
                        salesCommand.Parameters.AddWithValue("@startDate", startDate.Value);
                        salesCommand.Parameters.AddWithValue("@endDate", endDate.Value);
                        costCommand.Parameters.AddWithValue("@startDate", startDate.Value);
                        costCommand.Parameters.AddWithValue("@endDate", endDate.Value);
                    }

                    // Safely handle the result of ExecuteScalar to avoid casting issues
                    object salesResult = salesCommand.ExecuteScalar();
                    decimal totalSales = (salesResult != DBNull.Value && salesResult != null)
                                        ? Convert.ToDecimal(salesResult)
                                        : 0;

                    object costResult = costCommand.ExecuteScalar();
                    decimal totalCosts = (costResult != DBNull.Value && costResult != null)
                                        ? Convert.ToDecimal(costResult)
                                        : 0;

                    decimal grossProfit = totalSales - totalCosts;
                    label12.Text = $"{grossProfit:C}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching total profit: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
        }

        private void LoadTotalCost(DateTime? startDate = null, DateTime? endDate = null)  // Loads and displays total cost, optionally filtered by date
        {
            try
            {
                connection.Open();

                string queryCost = "SELECT SUM(Cost * QuantitySold) FROM Sales";

                if (startDate.HasValue && endDate.HasValue)
                {
                    queryCost += " WHERE SaleDate BETWEEN @startDate AND @endDate";
                }

                using (SqlCommand command = new SqlCommand(queryCost, connection))
                {
                    if (startDate.HasValue && endDate.HasValue)
                    {
                        command.Parameters.AddWithValue("@startDate", startDate.Value);
                        command.Parameters.AddWithValue("@endDate", endDate.Value);
                    }

                    object result = command.ExecuteScalar();
                    decimal totalCosts = result != DBNull.Value ? Convert.ToDecimal(result) : 0;

                    label11.Text = $"{totalCosts:C}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching total costs: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
        }



        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void dashboard_Load(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click_1(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click_1(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
        private void LoadDashboardData(DateTime? startDate = null, DateTime? endDate = null)
        {
            // Load all the data with optional date filters
            LoadTotalSales(startDate, endDate);
            LoadTotalInventory();  // Inventory is not time-bound, so no date filter
            LoadLowStockItems();   // Low stock is not time-bound either
            LoadInventoryValue();  // Same here, inventory value isn't time-bound
            LoadTotalProfit(startDate, endDate);
            LoadTotalCost(startDate, endDate);
            UpdateProfitCostChart(startDate, endDate);

        }
        // Button click for daily sales (updates all labels)
        private void button1_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = dateTimePicker1.Value;
            LoadDashboardData(selectedDate.Date, selectedDate.Date.AddDays(1));
        }

        // Button click for yearly sales (updates all labels)
        private void button2_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = dateTimePicker1.Value;
            DateTime startOfYear = new DateTime(selectedDate.Year, 1, 1);
            DateTime endOfYear = new DateTime(selectedDate.Year, 12, 31);
            LoadDashboardData(startOfYear, endOfYear); // Yearly data
        }

        // Button click for monthly sales (updates all labels)
        private void button3_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = dateTimePicker1.Value;
            DateTime startOfMonth = new DateTime(selectedDate.Year, selectedDate.Month, 1);
            DateTime endOfMonth = startOfMonth.AddMonths(1).AddDays(-1);
            LoadDashboardData(startOfMonth, endOfMonth); // Monthly data
        }

        // Button click for total sales (all-time, updates all labels)
        private void button4_Click(object sender, EventArgs e)
        {
            LoadDashboardData();  // Load all data without date filter
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = dateTimePicker1.Value;
            LoadDashboardData(selectedDate.Date, selectedDate.Date.AddDays(1));
        }

        private void Title_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dashboard_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void dashboard_MouseMove(object sender, MouseEventArgs e)
        {

        }
    }
}
