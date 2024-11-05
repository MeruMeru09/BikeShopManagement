namespace BikeShopManagement
{
    partial class SalesReport
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.salesDataGridView = new System.Windows.Forms.DataGridView();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.btnShowMonthlySales = new System.Windows.Forms.Button();
            this.btnShowDailySales = new System.Windows.Forms.Button();
            this.totalSalesLabel = new System.Windows.Forms.Label();
            this.btnShowAllSales = new System.Windows.Forms.Button();
            this.btnShowYearlySales = new System.Windows.Forms.Button();
            this.btnExit2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.salesDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // salesDataGridView
            // 
            this.salesDataGridView.BackgroundColor = System.Drawing.Color.DarkSeaGreen;
            this.salesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.salesDataGridView.Location = new System.Drawing.Point(60, 101);
            this.salesDataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.salesDataGridView.Name = "salesDataGridView";
            this.salesDataGridView.RowHeadersWidth = 51;
            this.salesDataGridView.Size = new System.Drawing.Size(940, 351);
            this.salesDataGridView.TabIndex = 0;
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker.Location = new System.Drawing.Point(60, 50);
            this.dateTimePicker.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(268, 24);
            this.dateTimePicker.TabIndex = 1;
            this.dateTimePicker.ValueChanged += new System.EventHandler(this.dateTimePicker_ValueChanged);
            // 
            // btnShowMonthlySales
            // 
            this.btnShowMonthlySales.BackColor = System.Drawing.Color.SeaGreen;
            this.btnShowMonthlySales.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowMonthlySales.ForeColor = System.Drawing.Color.Honeydew;
            this.btnShowMonthlySales.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnShowMonthlySales.Location = new System.Drawing.Point(505, 47);
            this.btnShowMonthlySales.Margin = new System.Windows.Forms.Padding(4);
            this.btnShowMonthlySales.Name = "btnShowMonthlySales";
            this.btnShowMonthlySales.Size = new System.Drawing.Size(160, 28);
            this.btnShowMonthlySales.TabIndex = 2;
            this.btnShowMonthlySales.Text = "Show Monthly Sales";
            this.btnShowMonthlySales.UseVisualStyleBackColor = false;
            this.btnShowMonthlySales.Click += new System.EventHandler(this.btnShowMonthlySales_Click);
            // 
            // btnShowDailySales
            // 
            this.btnShowDailySales.BackColor = System.Drawing.Color.SeaGreen;
            this.btnShowDailySales.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowDailySales.ForeColor = System.Drawing.Color.Honeydew;
            this.btnShowDailySales.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnShowDailySales.Location = new System.Drawing.Point(337, 47);
            this.btnShowDailySales.Margin = new System.Windows.Forms.Padding(4);
            this.btnShowDailySales.Name = "btnShowDailySales";
            this.btnShowDailySales.Size = new System.Drawing.Size(160, 28);
            this.btnShowDailySales.TabIndex = 3;
            this.btnShowDailySales.Text = "Show Daily Sales";
            this.btnShowDailySales.UseVisualStyleBackColor = false;
            this.btnShowDailySales.Click += new System.EventHandler(this.btnShowDailySales_Click);
            // 
            // totalSalesLabel
            // 
            this.totalSalesLabel.AutoSize = true;
            this.totalSalesLabel.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalSalesLabel.Location = new System.Drawing.Point(56, 476);
            this.totalSalesLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.totalSalesLabel.Name = "totalSalesLabel";
            this.totalSalesLabel.Size = new System.Drawing.Size(173, 33);
            this.totalSalesLabel.TabIndex = 5;
            this.totalSalesLabel.Text = "Total Sales:";
            // 
            // btnShowAllSales
            // 
            this.btnShowAllSales.BackColor = System.Drawing.Color.SeaGreen;
            this.btnShowAllSales.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowAllSales.ForeColor = System.Drawing.Color.Honeydew;
            this.btnShowAllSales.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnShowAllSales.Location = new System.Drawing.Point(841, 47);
            this.btnShowAllSales.Margin = new System.Windows.Forms.Padding(4);
            this.btnShowAllSales.Name = "btnShowAllSales";
            this.btnShowAllSales.Size = new System.Drawing.Size(160, 28);
            this.btnShowAllSales.TabIndex = 6;
            this.btnShowAllSales.Text = "Show All Sales";
            this.btnShowAllSales.UseVisualStyleBackColor = false;
            this.btnShowAllSales.Click += new System.EventHandler(this.btnShowAllSales_Click);
            // 
            // btnShowYearlySales
            // 
            this.btnShowYearlySales.BackColor = System.Drawing.Color.SeaGreen;
            this.btnShowYearlySales.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowYearlySales.ForeColor = System.Drawing.Color.Honeydew;
            this.btnShowYearlySales.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnShowYearlySales.Location = new System.Drawing.Point(673, 47);
            this.btnShowYearlySales.Margin = new System.Windows.Forms.Padding(4);
            this.btnShowYearlySales.Name = "btnShowYearlySales";
            this.btnShowYearlySales.Size = new System.Drawing.Size(160, 28);
            this.btnShowYearlySales.TabIndex = 7;
            this.btnShowYearlySales.Text = "Show Yearly Sales";
            this.btnShowYearlySales.UseVisualStyleBackColor = false;
            this.btnShowYearlySales.Click += new System.EventHandler(this.btnShowYearlySales_Click);
            // 
            // btnExit2
            // 
            this.btnExit2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit2.Location = new System.Drawing.Point(1015, 0);
            this.btnExit2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExit2.Name = "btnExit2";
            this.btnExit2.Size = new System.Drawing.Size(52, 34);
            this.btnExit2.TabIndex = 0;
            this.btnExit2.Text = "X";
            this.btnExit2.UseVisualStyleBackColor = true;
            this.btnExit2.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // SalesReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnExit2);
            this.Controls.Add(this.btnShowYearlySales);
            this.Controls.Add(this.btnShowAllSales);
            this.Controls.Add(this.totalSalesLabel);
            this.Controls.Add(this.btnShowDailySales);
            this.Controls.Add(this.btnShowMonthlySales);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.salesDataGridView);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SalesReport";
            this.Size = new System.Drawing.Size(1067, 554);
            this.Load += new System.EventHandler(this.SalesReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.salesDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView salesDataGridView;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Button btnShowMonthlySales;
        private System.Windows.Forms.Button btnShowDailySales;
        private System.Windows.Forms.Label totalSalesLabel;
        private System.Windows.Forms.Button btnShowAllSales;
        private System.Windows.Forms.Button btnShowYearlySales;
        private System.Windows.Forms.Button btnExit2;
    }
}
