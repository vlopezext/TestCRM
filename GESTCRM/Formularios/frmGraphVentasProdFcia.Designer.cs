namespace GESTCRM.Formularios
{
    partial class frmGraphVentasProdFcia
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Configuration.AppSettingsReader configurationAppSettings = new System.Configuration.AppSettingsReader();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGraphVentasProdFcia));
            this.chartVentasPedidoCanal = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.sqlConn = new System.Data.SqlClient.SqlConnection();
            this.sqldaGetVentasMatFciaPorCanal = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCmdGetVentasMatFciaPorCanal = new System.Data.SqlClient.SqlCommand();
            this.dsGraphs1 = new GESTCRM.Formularios.DataSets.dsGraphs();
            this.lblMaterial = new System.Windows.Forms.Label();
            this.chartVentasCanal = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartVentasPedidoCanal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsGraphs1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartVentasCanal)).BeginInit();
            this.SuspendLayout();
            // 
            // chartVentasPedidoCanal
            // 
            chartArea1.AxisX.IsLabelAutoFit = false;
            chartArea1.AxisX.LabelStyle.Angle = -90;
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisY.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea1.AxisY.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea1.AxisY.MajorGrid.Enabled = false;
            chartArea1.Name = "ChartArea1";
            this.chartVentasPedidoCanal.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartVentasPedidoCanal.Legends.Add(legend1);
            this.chartVentasPedidoCanal.Location = new System.Drawing.Point(349, 53);
            this.chartVentasPedidoCanal.Name = "chartVentasPedidoCanal";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            series1.IsVisibleInLegend = false;
            series1.Legend = "Legend1";
            series1.Name = "Directo";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            series2.IsVisibleInLegend = false;
            series2.Legend = "Legend1";
            series2.Name = "Transfer";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            series2.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            series3.IsVisibleInLegend = false;
            series3.Legend = "Legend1";
            series3.Name = "Club";
            series3.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            series3.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            series4.IsVisibleInLegend = false;
            series4.Legend = "Legend1";
            series4.Name = "Autopedido";
            series4.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            series4.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.chartVentasPedidoCanal.Series.Add(series1);
            this.chartVentasPedidoCanal.Series.Add(series2);
            this.chartVentasPedidoCanal.Series.Add(series3);
            this.chartVentasPedidoCanal.Series.Add(series4);
            this.chartVentasPedidoCanal.Size = new System.Drawing.Size(523, 264);
            this.chartVentasPedidoCanal.TabIndex = 4;
            this.chartVentasPedidoCanal.Text = "chart1";
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.Name = "Title1";
            title1.Text = "Ventas por pedido y canal";
            this.chartVentasPedidoCanal.Titles.Add(title1);
            // 
            // sqlConn
            // 
            //this.sqlConn.ConnectionString = ((string)(configurationAppSettings.GetValue("sConn", typeof(string))));//---- GSG (10/09/2014)
            this.sqlConn = Utiles._connection;
            this.sqlConn.FireInfoMessageEventOnUserErrors = false;
            // 
            // sqldaGetVentasMatFciaPorCanal
            // 
            this.sqldaGetVentasMatFciaPorCanal.SelectCommand = this.sqlCmdGetVentasMatFciaPorCanal;
            this.sqldaGetVentasMatFciaPorCanal.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "VentasMatFciaPorCanal", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("Directo", "Directo"),
                        new System.Data.Common.DataColumnMapping("Transfer", "Transfer"),
                        new System.Data.Common.DataColumnMapping("Club", "Club"),
                        new System.Data.Common.DataColumnMapping("Autopedido", "Autopedido")})});
            // 
            // sqlCmdGetVentasMatFciaPorCanal
            // 
            this.sqlCmdGetVentasMatFciaPorCanal.CommandText = "[GetVentasMatFciaPorCanal]";
            this.sqlCmdGetVentasMatFciaPorCanal.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdGetVentasMatFciaPorCanal.Connection = this.sqlConn;
            this.sqlCmdGetVentasMatFciaPorCanal.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@dFechaIni", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@dFechaFin", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@sCodNacional", System.Data.SqlDbType.VarChar, 6)});
            // 
            // dsGraphs1
            // 
            this.dsGraphs1.DataSetName = "dsGraphs";
            this.dsGraphs1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lblMaterial
            // 
            this.lblMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaterial.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblMaterial.Location = new System.Drawing.Point(12, 13);
            this.lblMaterial.Name = "lblMaterial";
            this.lblMaterial.Size = new System.Drawing.Size(850, 23);
            this.lblMaterial.TabIndex = 5;
            this.lblMaterial.Text = "label1";
            // 
            // chartVentasCanal
            // 
            chartArea2.Name = "ChartArea1";
            this.chartVentasCanal.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartVentasCanal.Legends.Add(legend2);
            this.chartVentasCanal.Location = new System.Drawing.Point(12, 53);
            this.chartVentasCanal.Name = "chartVentasCanal";
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series5.IsValueShownAsLabel = true;
            series5.LabelFormat = "{N2}%";
            series5.Legend = "Legend1";
            series5.Name = "SerieVentaCanal";
            series5.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            series5.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.chartVentasCanal.Series.Add(series5);
            this.chartVentasCanal.Size = new System.Drawing.Size(331, 259);
            this.chartVentasCanal.TabIndex = 6;
            this.chartVentasCanal.Text = "chart1";
            title2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title2.Name = "Title1";
            title2.Text = "Canal de venta";
            this.chartVentasCanal.Titles.Add(title2);
            // 
            // frmGraphVentasProdFcia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(884, 335);
            this.Controls.Add(this.chartVentasCanal);
            this.Controls.Add(this.lblMaterial);
            this.Controls.Add(this.chartVentasPedidoCanal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGraphVentasProdFcia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Resumen de ventas del producto en la farmacia";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmGraphVentasProdFcia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartVentasPedidoCanal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsGraphs1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartVentasCanal)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartVentasPedidoCanal;
        private DataSets.dsGraphs dsGraphs1;
        private System.Windows.Forms.Label lblMaterial;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartVentasCanal;
    }
}