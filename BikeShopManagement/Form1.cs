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
    public partial class Form1 : Form
    {
        private SalesReport salesReport;
        private dashboard dashboardControl;
        public Point mouseLocation;
        public bool mouseDown;


        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        public Form1()
        {
            InitializeComponent();// Initializes all UI components
            ShowDashboard();
            this.Size = new Size(800, 450); // Sets the default form size
            btnExit.BringToFront(); // Put exit button to the front 
        }

        private void dashboardMenuItem_Click(object sender, EventArgs e) // event handler for dashboard
        {
            ShowDashboard();
            btnExit.BringToFront();
        }

        private void inventoryMenuItem_Click(object sender, EventArgs e) // event handler for inventory
        {
            LoadInventoryManagement();
            btnExit.BringToFront();
        }

        private void salesMenuItem_Click(object sender, EventArgs e) // event handler for sales tracker
        {
            LoadSalesReport();
            btnExit.BringToFront();
        }

        private void reportsMenuItem_Click(object sender, EventArgs e) // event handler for reports
        {
            ShowReports();
            btnExit.BringToFront();
        }
        private void ShowDashboard() // loads dahsboard controls  in the main panel
        {
            if (dashboardControl == null)
            {
                dashboardControl = new dashboard();  
                dashboardControl.Dock = DockStyle.Fill;
            }

            mainPanel.Controls.Clear(); 
            mainPanel.Controls.Add(dashboardControl);
            menuStrip1.BringToFront(); 
        }
        private void LoadInventoryManagement() //loads inventory management controls in the main panel
        {
            salesReport = new SalesReport();
            InventoryManagement inventoryControl = new InventoryManagement(salesReport);
            inventoryControl.Dock = DockStyle.Fill;
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(inventoryControl);
            menuStrip1.BringToFront();
        }
        private void LoadSalesReport() //loads sales  report controls in the main panel
        {
            salesReport = new SalesReport(); 
            salesReport.Dock = DockStyle.Fill; 
            mainPanel.Controls.Clear(); 
            mainPanel.Controls.Add(salesReport); 
            menuStrip1.BringToFront(); 
        }
        private void ShowSalesTracking() //laods sales tracking information in the main panel
        {
            mainPanel.Controls.Clear();
            Label salesLabel = new Label
            {
                Text = "Sales Tracking: Products Sold, Dates, Items, Amount, Quantity",
                Dock = DockStyle.Fill,
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            };
            mainPanel.Controls.Add(salesLabel);
        }

        private void ShowReports() // load the reports control in the main panel
        {
            Reports reportsControl = new Reports();
            reportsControl.Dock = DockStyle.Fill;
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(reportsControl);
            menuStrip1.BringToFront();
        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit(); // exit the app
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

    }
}