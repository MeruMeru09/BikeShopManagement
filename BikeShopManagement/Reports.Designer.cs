namespace BikeShopManagement
{
    partial class Reports
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataVisualization.Charting.Chart mostSoldChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart mostProfitableChart;

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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea15 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series15 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea16 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series16 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.mostSoldChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.mostProfitableChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnExit1 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.mostSoldChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mostProfitableChart)).BeginInit();
            this.SuspendLayout();
            // 
            // mostSoldChart
            // 
            this.mostSoldChart.BackColor = System.Drawing.Color.LightGreen;
            this.mostSoldChart.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.DiagonalRight;
            this.mostSoldChart.BorderlineColor = System.Drawing.Color.Transparent;
            this.mostSoldChart.BorderSkin.BackColor = System.Drawing.Color.SeaGreen;
            this.mostSoldChart.BorderSkin.BorderColor = System.Drawing.Color.SeaGreen;
            this.mostSoldChart.BorderSkin.PageColor = System.Drawing.Color.Transparent;
            this.mostSoldChart.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Raised;
            chartArea15.Name = "ChartArea1";
            this.mostSoldChart.ChartAreas.Add(chartArea15);
            this.mostSoldChart.Location = new System.Drawing.Point(37, 126);
            this.mostSoldChart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mostSoldChart.Name = "mostSoldChart";
            series15.ChartArea = "ChartArea1";
            series15.Name = "Series1";
            this.mostSoldChart.Series.Add(series15);
            this.mostSoldChart.Size = new System.Drawing.Size(980, 206);
            this.mostSoldChart.TabIndex = 0;
            this.mostSoldChart.Text = "Most Sold Products";
            // 
            // mostProfitableChart
            // 
            this.mostProfitableChart.BackColor = System.Drawing.Color.LightGreen;
            this.mostProfitableChart.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.DiagonalLeft;
            this.mostProfitableChart.BorderlineColor = System.Drawing.Color.Transparent;
            this.mostProfitableChart.BorderSkin.PageColor = System.Drawing.Color.Transparent;
            this.mostProfitableChart.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Raised;
            chartArea16.Name = "ChartArea2";
            this.mostProfitableChart.ChartAreas.Add(chartArea16);
            this.mostProfitableChart.Location = new System.Drawing.Point(37, 336);
            this.mostProfitableChart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mostProfitableChart.Name = "mostProfitableChart";
            series16.ChartArea = "ChartArea2";
            series16.Name = "Series2";
            this.mostProfitableChart.Series.Add(series16);
            this.mostProfitableChart.Size = new System.Drawing.Size(980, 202);
            this.mostProfitableChart.TabIndex = 1;
            this.mostProfitableChart.Text = "Most Profitable Products";
            this.mostProfitableChart.Click += new System.EventHandler(this.mostProfitableChart_Click);
            // 
            // btnExit1
            // 
            this.btnExit1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit1.Location = new System.Drawing.Point(1015, 0);
            this.btnExit1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExit1.Name = "btnExit1";
            this.btnExit1.Size = new System.Drawing.Size(52, 34);
            this.btnExit1.TabIndex = 0;
            this.btnExit1.Text = "X";
            this.btnExit1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.BackColor = System.Drawing.Color.SeaGreen;
            this.button1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Honeydew;
            this.button1.Location = new System.Drawing.Point(54, 62);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 34);
            this.button1.TabIndex = 12;
            this.button1.Text = "Daily";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.AutoSize = true;
            this.button2.BackColor = System.Drawing.Color.SeaGreen;
            this.button2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Honeydew;
            this.button2.Location = new System.Drawing.Point(191, 62);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(131, 34);
            this.button2.TabIndex = 13;
            this.button2.Text = "Monthly";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.AutoSize = true;
            this.button3.BackColor = System.Drawing.Color.SeaGreen;
            this.button3.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.Honeydew;
            this.button3.Location = new System.Drawing.Point(328, 62);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(131, 34);
            this.button3.TabIndex = 14;
            this.button3.Text = "Yearly";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.AutoSize = true;
            this.button4.BackColor = System.Drawing.Color.SeaGreen;
            this.button4.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.Honeydew;
            this.button4.Location = new System.Drawing.Point(465, 62);
            this.button4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(131, 34);
            this.button4.TabIndex = 15;
            this.button4.Text = "Total";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarForeColor = System.Drawing.Color.Black;
            this.dateTimePicker1.CalendarMonthBackground = System.Drawing.Color.PaleGreen;
            this.dateTimePicker1.CalendarTitleBackColor = System.Drawing.Color.SeaGreen;
            this.dateTimePicker1.CalendarTitleForeColor = System.Drawing.Color.Honeydew;
            this.dateTimePicker1.CalendarTrailingForeColor = System.Drawing.Color.SeaGreen;
            this.dateTimePicker1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Location = new System.Drawing.Point(726, 72);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(291, 24);
            this.dateTimePicker1.TabIndex = 16;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // Reports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnExit1);
            this.Controls.Add(this.mostProfitableChart);
            this.Controls.Add(this.mostSoldChart);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Reports";
            this.Size = new System.Drawing.Size(1067, 565);
            ((System.ComponentModel.ISupportInitialize)(this.mostSoldChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mostProfitableChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExit1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}
