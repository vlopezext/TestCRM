namespace GESTCRM.Formularios
{
    partial class frmGraphPuntos
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
            System.Configuration.AppSettingsReader configurationAppSettings = new System.Configuration.AppSettingsReader();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGraphPuntos));
            this.dsGraphs1 = new GESTCRM.Formularios.DataSets.dsGraphs();
            this.sqlConn = new System.Data.SqlClient.SqlConnection();
            this.sqlCmdGetDatosMediosPedidos = new System.Data.SqlClient.SqlCommand();
            this.sqldaGetDatosMediosPedidos = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCmdGetDatosPedidosMes = new System.Data.SqlClient.SqlCommand();
            this.sqldaGetDatosPedidosMes = new System.Data.SqlClient.SqlDataAdapter();
            this.chartImportes = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartPuntos = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.dsGraphs1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartImportes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPuntos)).BeginInit();
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
            // sqlCmdGetDatosMediosPedidos
            // 
            this.sqlCmdGetDatosMediosPedidos.CommandText = "[GetDatosMediosPedidos]";
            this.sqlCmdGetDatosMediosPedidos.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdGetDatosMediosPedidos.Connection = this.sqlConn;
            this.sqlCmdGetDatosMediosPedidos.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@dFechaIni", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@dFechaFin", System.Data.SqlDbType.DateTime, 8)});
            // 
            // sqldaGetDatosMediosPedidos
            // 
            this.sqldaGetDatosMediosPedidos.SelectCommand = this.sqlCmdGetDatosMediosPedidos;
            this.sqldaGetDatosMediosPedidos.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "DatosMediosPedidos", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("valorDescuentoMedio", "valorDescuentoMedio"),
                        new System.Data.Common.DataColumnMapping("brutoMedio", "brutoMedio"),
                        new System.Data.Common.DataColumnMapping("netoMedio", "netoMedio"),
                        new System.Data.Common.DataColumnMapping("puntosMedio", "puntosMedio")})});
            // 
            // sqlCmdGetDatosPedidosMes
            // 
            this.sqlCmdGetDatosPedidosMes.CommandText = "[GetDatosMediosPedidosPorMes]";
            this.sqlCmdGetDatosPedidosMes.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdGetDatosPedidosMes.Connection = this.sqlConn;
            this.sqlCmdGetDatosPedidosMes.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@dFechaIni", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@dFechaFin", System.Data.SqlDbType.DateTime, 8)});
            // 
            // sqldaGetDatosPedidosMes
            // 
            this.sqldaGetDatosPedidosMes.SelectCommand = this.sqlCmdGetDatosPedidosMes;
            this.sqldaGetDatosPedidosMes.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "DatosPedidosMes", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("valorDescuentoMes", "valorDescuentoMes"),
                        new System.Data.Common.DataColumnMapping("brutoMes", "brutoMes"),
                        new System.Data.Common.DataColumnMapping("netoMes", "netoMes"),
                        new System.Data.Common.DataColumnMapping("puntosMes", "puntosMes"),
                        new System.Data.Common.DataColumnMapping("anyo", "anyo"),
                        new System.Data.Common.DataColumnMapping("mes", "mes")})});
            // 
            // chartImportes
            // 
            chartArea1.AxisX.IsLabelAutoFit = false;
            chartArea1.AxisX.LabelStyle.Angle = -90;
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisY.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea1.AxisY.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea1.AxisY.MajorTickMark.Enabled = false;
            chartArea1.AxisY.MajorTickMark.Interval = 5D;
            chartArea1.AxisY.MajorTickMark.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea1.AxisY.Maximum = 6000D;
            chartArea1.AxisY.Minimum = 0D;
            chartArea1.AxisY2.LabelStyle.Enabled = false;
            chartArea1.AxisY2.MajorGrid.Enabled = false;
            chartArea1.Name = "ChartArea1";
            this.chartImportes.ChartAreas.Add(chartArea1);
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend1.IsTextAutoFit = false;
            legend1.Name = "Legend1";
            this.chartImportes.Legends.Add(legend1);
            this.chartImportes.Location = new System.Drawing.Point(3, 2);
            this.chartImportes.Name = "chartImportes";
            series1.BorderWidth = 3;
            series1.ChartArea = "ChartArea1";
            series1.Color = System.Drawing.Color.RoyalBlue;
            series1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.LabelForeColor = System.Drawing.Color.Blue;
            series1.Legend = "Legend1";
            series1.Name = "Bruto";
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series2.BorderWidth = 3;
            series2.ChartArea = "ChartArea1";
            series2.Color = System.Drawing.Color.MediumSeaGreen;
            series2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series2.LabelForeColor = System.Drawing.Color.Green;
            series2.Legend = "Legend1";
            series2.Name = "Neto";
            series2.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series3.BorderWidth = 4;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Color = System.Drawing.Color.Gold;
            series3.Legend = "Legend1";
            series3.Name = "Media Bruto";
            series3.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series4.BorderWidth = 4;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Color = System.Drawing.Color.Orange;
            series4.Legend = "Legend1";
            series4.Name = "Media Neto";
            this.chartImportes.Series.Add(series1);
            this.chartImportes.Series.Add(series2);
            this.chartImportes.Series.Add(series3);
            this.chartImportes.Series.Add(series4);
            this.chartImportes.Size = new System.Drawing.Size(655, 452);
            this.chartImportes.TabIndex = 9;
            this.chartImportes.Text = "chart2";
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.Name = "Title1";
            title1.Text = "Importes Bruto y Neto (Media Mensual)";
            this.chartImportes.Titles.Add(title1);
            // 
            // chartPuntos
            // 
            chartArea2.AxisX.IsLabelAutoFit = false;
            chartArea2.AxisX.IsMarksNextToAxis = false;
            chartArea2.AxisX.LabelStyle.Angle = -90;
            chartArea2.AxisX.MajorGrid.Enabled = false;
            chartArea2.AxisY.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea2.AxisY.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea2.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea2.AxisY.MajorTickMark.Enabled = false;
            chartArea2.AxisY.MajorTickMark.Interval = 5D;
            chartArea2.AxisY.MajorTickMark.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea2.AxisY.Maximum = 2000D;
            chartArea2.AxisY.Minimum = 0D;
            chartArea2.AxisY2.LabelStyle.Enabled = false;
            chartArea2.AxisY2.MajorGrid.Enabled = false;
            chartArea2.Name = "ChartArea1";
            this.chartPuntos.ChartAreas.Add(chartArea2);
            legend2.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend2.IsTextAutoFit = false;
            legend2.Name = "Legend1";
            this.chartPuntos.Legends.Add(legend2);
            this.chartPuntos.Location = new System.Drawing.Point(656, 2);
            this.chartPuntos.Name = "chartPuntos";
            series5.BorderWidth = 3;
            series5.ChartArea = "ChartArea1";
            series5.Color = System.Drawing.Color.Crimson;
            series5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series5.Legend = "Legend1";
            series5.Name = "Puntos";
            series5.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            series5.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series6.BorderWidth = 4;
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series6.Color = System.Drawing.Color.DodgerBlue;
            series6.Legend = "Legend1";
            series6.Name = "Media Puntos";
            this.chartPuntos.Series.Add(series5);
            this.chartPuntos.Series.Add(series6);
            this.chartPuntos.Size = new System.Drawing.Size(668, 452);
            this.chartPuntos.TabIndex = 10;
            this.chartPuntos.Text = "chart2";
            title2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title2.Name = "Title1";
            title2.Text = "Puntos (Media Mensual)";
            this.chartPuntos.Titles.Add(title2);
            // 
            // frmGraphPuntos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1328, 472);
            this.Controls.Add(this.chartPuntos);
            this.Controls.Add(this.chartImportes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGraphPuntos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Medias Mensuales en los últimos Pedidos Directo, Transfer, Compromiso, Autopedido" +
    "";
            this.Load += new System.EventHandler(this.frmGraphPuntos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsGraphs1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartImportes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPuntos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataSets.dsGraphs dsGraphs1;
        private System.Data.SqlClient.SqlConnection sqlConn;
        private System.Data.SqlClient.SqlCommand sqlCmdGetDatosMediosPedidos;
        private System.Data.SqlClient.SqlDataAdapter sqldaGetDatosMediosPedidos;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartImportes;
        private System.Data.SqlClient.SqlCommand sqlCmdGetDatosPedidosMes;
        private System.Data.SqlClient.SqlDataAdapter sqldaGetDatosPedidosMes;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPuntos;
    }
}