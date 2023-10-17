namespace GESTCRM.Formularios
{
    partial class frmGraphCantidadesAdquiridas
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
            System.Configuration.AppSettingsReader configurationAppSettings = new System.Configuration.AppSettingsReader();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGraphCantidadesAdquiridas));
            this.lblMaterial = new System.Windows.Forms.Label();
            this.chartCantidadesVendidas = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dsGraphs1 = new GESTCRM.Formularios.DataSets.dsGraphs();
            this.sqlConn = new System.Data.SqlClient.SqlConnection();
            this.sqlCmdGetCantidadesAdquiridas = new System.Data.SqlClient.SqlCommand();
            this.sqldaGetCantidadesAdquiridas = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCmdGetNumPedidosClienteConMaterial = new System.Data.SqlClient.SqlCommand();
            ((System.ComponentModel.ISupportInitialize)(this.chartCantidadesVendidas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsGraphs1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMaterial
            // 
            this.lblMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaterial.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblMaterial.Location = new System.Drawing.Point(12, 13);
            this.lblMaterial.Name = "lblMaterial";
            this.lblMaterial.Size = new System.Drawing.Size(850, 23);
            this.lblMaterial.TabIndex = 6;
            this.lblMaterial.Text = "label1";
            // 
            // chartCantidadesVendidas
            // 
            chartArea1.AxisX.IsLabelAutoFit = false;
            chartArea1.AxisX.LabelStyle.Angle = -90;
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisY.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea1.AxisY.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea1.AxisY.MajorGrid.Enabled = false;
            chartArea1.AxisY2.LabelStyle.Enabled = false;
            chartArea1.AxisY2.MajorGrid.Enabled = false;
            chartArea1.Name = "ChartArea1";
            this.chartCantidadesVendidas.ChartAreas.Add(chartArea1);
            legend1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend1.IsTextAutoFit = false;
            legend1.Name = "Legend1";
            this.chartCantidadesVendidas.Legends.Add(legend1);
            this.chartCantidadesVendidas.Location = new System.Drawing.Point(15, 52);
            this.chartCantidadesVendidas.Name = "chartCantidadesVendidas";
            series1.ChartArea = "ChartArea1";
            series1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.IsVisibleInLegend = false;
            series1.Legend = "Legend1";
            series1.Name = "SerieVentas";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series2.BorderColor = System.Drawing.Color.White;
            series2.BorderWidth = 3;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.Gold;
            series2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series2.Legend = "Legend1";
            series2.LegendText = "Media por meses";
            series2.Name = "SerieMediaVenta";
            series2.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series3.BorderColor = System.Drawing.Color.White;
            series3.BorderWidth = 3;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Color = System.Drawing.Color.LimeGreen;
            series3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series3.Legend = "Legend1";
            series3.LegendText = "Media por Pedido";
            series3.Name = "SerieMediaPedido";
            series3.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            this.chartCantidadesVendidas.Series.Add(series1);
            this.chartCantidadesVendidas.Series.Add(series2);
            this.chartCantidadesVendidas.Series.Add(series3);
            this.chartCantidadesVendidas.Size = new System.Drawing.Size(847, 315);
            this.chartCantidadesVendidas.TabIndex = 7;
            this.chartCantidadesVendidas.Text = "chart2";
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.Name = "Title1";
            title1.Text = "Cantidades adquiridas en los últimos pedidos";
            this.chartCantidadesVendidas.Titles.Add(title1);
            // 
            // dsGraphs1
            // 
            this.dsGraphs1.DataSetName = "dsGraphs";
            this.dsGraphs1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sqlConn
            // 
            this.sqlConn.ConnectionString = Utiles._connection.ConnectionString.ToString();   //---- GSG (06/03/2021)
            this.sqlConn.FireInfoMessageEventOnUserErrors = false;
            // 
            // sqlCmdGetCantidadesAdquiridas
            // 
            this.sqlCmdGetCantidadesAdquiridas.CommandText = "[GetCantidadesAdquiridas]";
            this.sqlCmdGetCantidadesAdquiridas.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdGetCantidadesAdquiridas.Connection = this.sqlConn;
            this.sqlCmdGetCantidadesAdquiridas.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@dFechaIni", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@dFechaFin", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@sCodNacional", System.Data.SqlDbType.VarChar, 6)});
            // 
            // sqldaGetCantidadesAdquiridas
            // 
            this.sqldaGetCantidadesAdquiridas.SelectCommand = this.sqlCmdGetCantidadesAdquiridas;
            this.sqldaGetCantidadesAdquiridas.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "CantidadesAdquiridasFcia", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("cantidad", "cantidad")})});
            // 
            // sqlCmdGetNumPedidosClienteConMaterial
            // 
            this.sqlCmdGetNumPedidosClienteConMaterial.CommandText = "[GetNumPedidosClienteConMaterial]";
            this.sqlCmdGetNumPedidosClienteConMaterial.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdGetNumPedidosClienteConMaterial.Connection = this.sqlConn;
            this.sqlCmdGetNumPedidosClienteConMaterial.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@dFechaIni", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@dFechaFin", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@sCodNacional", System.Data.SqlDbType.VarChar, 6)});
            // 
            // frmGraphCantidadesAdquiridas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(874, 379);
            this.Controls.Add(this.chartCantidadesVendidas);
            this.Controls.Add(this.lblMaterial);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGraphCantidadesAdquiridas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cantidades adquiridas en los últimos pedidos";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmGraphCantidadesAdquiridas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartCantidadesVendidas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsGraphs1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblMaterial;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartCantidadesVendidas;
        private DataSets.dsGraphs dsGraphs1;
        private System.Data.SqlClient.SqlConnection sqlConn;
        private System.Data.SqlClient.SqlCommand sqlCmdGetCantidadesAdquiridas;
        private System.Data.SqlClient.SqlDataAdapter sqldaGetCantidadesAdquiridas;
        private System.Data.SqlClient.SqlCommand sqlCmdGetNumPedidosClienteConMaterial;

        
    }
}