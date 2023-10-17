namespace GESTCRM.Formularios
{
    partial class frmGraphDescuentoAplicado
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
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGraphDescuentoAplicado));
            this.dsGraphs1 = new GESTCRM.Formularios.DataSets.dsGraphs();
            this.sqlConn = new System.Data.SqlClient.SqlConnection();
            this.sqlCmdGetDescuentosAplicados = new System.Data.SqlClient.SqlCommand();
            this.sqldaGetDescuentosAplicados = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCmdGetNumPedidosClienteConMaterial = new System.Data.SqlClient.SqlCommand();
            this.chartDescuentosAplicados = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblMaterial = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dsGraphs1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDescuentosAplicados)).BeginInit();
            this.SuspendLayout();
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
            // sqlCmdGetDescuentosAplicados
            // 
            this.sqlCmdGetDescuentosAplicados.CommandText = "[GetDescuentosAplicados]";
            this.sqlCmdGetDescuentosAplicados.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdGetDescuentosAplicados.Connection = this.sqlConn;
            this.sqlCmdGetDescuentosAplicados.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@dFechaIni", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@dFechaFin", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@sCodNacional", System.Data.SqlDbType.VarChar, 6)});
            // 
            // sqldaGetDescuentosAplicados
            // 
            this.sqldaGetDescuentosAplicados.SelectCommand = this.sqlCmdGetDescuentosAplicados;
            this.sqldaGetDescuentosAplicados.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "DescuentosAplicadosFcia", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("valorDescuento", "valorDescuento"),
                        new System.Data.Common.DataColumnMapping("importeBruto", "importeBruto")})});
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
            // chartDescuentosAplicados
            // 
            chartArea1.AxisX.IsLabelAutoFit = false;
            chartArea1.AxisX.LabelStyle.Angle = -90;
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisY.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea1.AxisY.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea1.AxisY.MajorGrid.Enabled = false;
            chartArea1.AxisY.MajorTickMark.Interval = 5D;
            chartArea1.AxisY.MajorTickMark.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea1.AxisY.Maximum = 100D;
            chartArea1.AxisY.Minimum = 0D;
            chartArea1.AxisY2.LabelStyle.Enabled = false;
            chartArea1.AxisY2.MajorGrid.Enabled = false;
            chartArea1.Name = "ChartArea1";
            this.chartDescuentosAplicados.ChartAreas.Add(chartArea1);
            legend1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend1.IsTextAutoFit = false;
            legend1.Name = "Legend1";
            this.chartDescuentosAplicados.Legends.Add(legend1);
            this.chartDescuentosAplicados.Location = new System.Drawing.Point(15, 52);
            this.chartDescuentosAplicados.Name = "chartDescuentosAplicados";
            series1.BorderWidth = 4;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.IsVisibleInLegend = false;
            series1.Legend = "Legend1";
            series1.Name = "SerieDescAplicado";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series2.BorderColor = System.Drawing.Color.White;
            series2.BorderWidth = 2;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.Gold;
            series2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series2.Legend = "Legend1";
            series2.LegendText = "Media";
            series2.Name = "SerieMedia";
            series2.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series3.BorderColor = System.Drawing.Color.White;
            series3.BorderWidth = 2;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Color = System.Drawing.Color.Red;
            series3.Legend = "Legend1";
            series3.LegendText = "Máximo";
            series3.Name = "SerieMaximo";
            series3.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series4.BorderWidth = 2;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Color = System.Drawing.Color.LimeGreen;
            series4.Legend = "Legend1";
            series4.Name = "SerieMediaPedido";
            this.chartDescuentosAplicados.Series.Add(series1);
            this.chartDescuentosAplicados.Series.Add(series2);
            this.chartDescuentosAplicados.Series.Add(series3);
            this.chartDescuentosAplicados.Series.Add(series4);
            this.chartDescuentosAplicados.Size = new System.Drawing.Size(847, 315);
            this.chartDescuentosAplicados.TabIndex = 9;
            this.chartDescuentosAplicados.Text = "chart2";
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.Name = "Title1";
            title1.Text = "Descuento aplicado en los últimos pedidos";
            this.chartDescuentosAplicados.Titles.Add(title1);
            // 
            // lblMaterial
            // 
            this.lblMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaterial.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblMaterial.Location = new System.Drawing.Point(12, 13);
            this.lblMaterial.Name = "lblMaterial";
            this.lblMaterial.Size = new System.Drawing.Size(850, 23);
            this.lblMaterial.TabIndex = 8;
            this.lblMaterial.Text = "label1";
            // 
            // frmGraphDescuentoAplicado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(864, 369);
            this.Controls.Add(this.chartDescuentosAplicados);
            this.Controls.Add(this.lblMaterial);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGraphDescuentoAplicado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Descuentos aplicados en los últimos pedidos";
            this.Load += new System.EventHandler(this.frmGraphDescuentoAplicado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsGraphs1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDescuentosAplicados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataSets.dsGraphs dsGraphs1;
        private System.Data.SqlClient.SqlConnection sqlConn;
        private System.Data.SqlClient.SqlCommand sqlCmdGetDescuentosAplicados;
        private System.Data.SqlClient.SqlDataAdapter sqldaGetDescuentosAplicados;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDescuentosAplicados;
        private System.Windows.Forms.Label lblMaterial;
        private System.Data.SqlClient.SqlCommand sqlCmdGetNumPedidosClienteConMaterial;
    }
}