using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace BikeShopManagement
{
    public partial class Reports : UserControl
    {
        private SqlConnection connection;

        public Reports()
        {
            InitializeComponent();
            Koneksyon koneksyon = new Koneksyon();
            connection = koneksyon.GetConnection();

            try
            {
                LoadProductData("total", "sold");
                LoadProductData("total", "profitable");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading reports: " + ex.Message);
            }
        }

        private void LoadProductData(string timePeriod, string productType, DateTime? selectedDate = null)
        {
            try
            {
                string sumColumn = productType == "sold" ? "SUM(QuantitySold)" : "SUM(SalePrice)";
                string chartTitle = productType == "sold" ? "Most Sold Products" : "Most Profitable Products";
                SeriesChartType chartType = productType == "sold" ? SeriesChartType.Line : SeriesChartType.Bar;
                var chart = productType == "sold" ? mostSoldChart : mostProfitableChart;

                string timeFilter = selectedDate.HasValue ? "CONVERT(DATE, SaleDate) = @SelectedDate" : GetTimeFilter(timePeriod);

                string query = $"SELECT TOP 10 ProductName, {sumColumn} AS Total " +
                               $"FROM Sales " +
                               $"WHERE {timeFilter} " +
                               $"GROUP BY ProductName " +
                               $"ORDER BY Total DESC";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    if (selectedDate.HasValue)
                    {
                        cmd.Parameters.AddWithValue("@SelectedDate", selectedDate.Value);
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    if (dataTable.Rows.Count == 0)
                    {
                        MessageBox.Show($"No products {productType} yet for the selected period.");
                        chart.Series.Clear();
                        return;
                    }

                    chart.Series.Clear();
                    Series series = new Series(chartTitle);
                    series.ChartType = chartType;

                    foreach (DataRow row in dataTable.Rows)
                    {
                        series.Points.AddXY(row["ProductName"], row["Total"]);
                    }

                    chart.Series.Add(series);
                    chart.ChartAreas[0].AxisX.Title = "Products";
                    chart.ChartAreas[0].AxisY.Title = productType == "sold" ? "Quantity Sold" : "Total Profit";
                    chart.Titles.Clear();
                    chart.Titles.Add($"Top 10 {chartTitle}" + (selectedDate.HasValue ? $" on {selectedDate.Value.ToShortDateString()}" : ""));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading {productType} chart data: " + ex.Message);
            }
        }

        private string GetTimeFilter(string timePeriod)
        {
            switch (timePeriod)
            {
                case "daily":
                    return "SaleDate = CONVERT(DATE, GETDATE())";
                case "weekly":
                    return "DATEPART(week, SaleDate) = DATEPART(week, GETDATE()) AND DATEPART(year, SaleDate) = DATEPART(year, GETDATE())";
                case "monthly":
                    return "MONTH(SaleDate) = MONTH(GETDATE()) AND YEAR(SaleDate) = YEAR(GETDATE())";
                case "total":
                default:
                    return "1=1"; // get all data
            }
        }


        private void mostProfitableChart_Click(object sender, EventArgs e)
        {

        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e) // Daily
        {
            LoadProductData("daily", "sold");
            LoadProductData("daily", "profitable");
        }

        private void button2_Click(object sender, EventArgs e) // Monthly
        {
            LoadProductData("monthly", "sold");
            LoadProductData("monthly", "profitable");
        }

        private void button3_Click(object sender, EventArgs e) // Weekly
        {
            LoadProductData("weekly", "sold");
            LoadProductData("weekly", "profitable");
        }

        private void button4_Click(object sender, EventArgs e) // Total
        {
            LoadProductData("total", "sold");
            LoadProductData("total", "profitable");
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = dateTimePicker1.Value.Date;
            LoadProductData(null, "sold", selectedDate);
            LoadProductData(null, "profitable", selectedDate);
        }
    }
}
