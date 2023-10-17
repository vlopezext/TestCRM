namespace GESTCRM.Formularios
{
    partial class frmStocks
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
            this.components = new System.ComponentModel.Container();
            System.Configuration.AppSettingsReader configurationAppSettings = new System.Configuration.AppSettingsReader();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStocks));
            this.ucBotoneraSecundaria1 = new GESTCRM.Controles.ucBotoneraSecundaria();
            this.panelFiltros = new System.Windows.Forms.Panel();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.txbsDescripcion = new System.Windows.Forms.TextBox();
            this.lblAvisoVersion = new System.Windows.Forms.Label();
            this.lblTitulo = new GESTCRM.Controles.LabelGradient();
            this.dsMateriales1 = new GESTCRM.Formularios.dsMateriales();
            this.bindingSourceStocks = new System.Windows.Forms.BindingSource(this.components);
            this.sqlConn = new System.Data.SqlClient.SqlConnection();
            this.sqldaListaStocks = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCmdListaStocks = new System.Data.SqlClient.SqlCommand();
            this.pnVentas = new System.Windows.Forms.Panel();
            this.dGVStocks = new System.Windows.Forms.DataGridView();
            this.lblNumReg = new System.Windows.Forms.Label();
            this.labelGradient2 = new GESTCRM.Controles.LabelGradient();
            this.sIdMaterial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sCodNacional = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sMaterial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sIdMaterialDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sCodNacionalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sMaterialDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iStockDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsMateriales1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceStocks)).BeginInit();
            this.pnVentas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVStocks)).BeginInit();
            this.SuspendLayout();
            // 
            // ucBotoneraSecundaria1
            // 
            this.ucBotoneraSecundaria1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(117)))), ((int)(((byte)(1)))));
            this.ucBotoneraSecundaria1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucBotoneraSecundaria1.ForeColor = System.Drawing.Color.Black;
            this.ucBotoneraSecundaria1.Location = new System.Drawing.Point(0, 0);
            this.ucBotoneraSecundaria1.Name = "ucBotoneraSecundaria1";
            this.ucBotoneraSecundaria1.Size = new System.Drawing.Size(1503, 38);
            this.ucBotoneraSecundaria1.TabIndex = 30;
            // 
            // panelFiltros
            // 
            this.panelFiltros.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelFiltros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelFiltros.Controls.Add(this.lblDescripcion);
            this.panelFiltros.Controls.Add(this.txbsDescripcion);
            this.panelFiltros.Controls.Add(this.lblAvisoVersion);
            this.panelFiltros.Controls.Add(this.lblTitulo);
            this.panelFiltros.Location = new System.Drawing.Point(4, 40);
            this.panelFiltros.Name = "panelFiltros";
            this.panelFiltros.Size = new System.Drawing.Size(1497, 70);
            this.panelFiltros.TabIndex = 31;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescripcion.ForeColor = System.Drawing.Color.Black;
            this.lblDescripcion.Location = new System.Drawing.Point(17, 35);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(73, 20);
            this.lblDescripcion.TabIndex = 130;
            this.lblDescripcion.Text = "Material :";
            // 
            // txbsDescripcion
            // 
            this.txbsDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbsDescripcion.Location = new System.Drawing.Point(94, 33);
            this.txbsDescripcion.Name = "txbsDescripcion";
            this.txbsDescripcion.Size = new System.Drawing.Size(448, 26);
            this.txbsDescripcion.TabIndex = 129;
            this.txbsDescripcion.TextChanged += new System.EventHandler(this.txbsDescripcion_TextChanged);
            // 
            // lblAvisoVersion
            // 
            this.lblAvisoVersion.AutoSize = true;
            this.lblAvisoVersion.BackColor = System.Drawing.Color.Yellow;
            this.lblAvisoVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvisoVersion.ForeColor = System.Drawing.Color.Red;
            this.lblAvisoVersion.Location = new System.Drawing.Point(326, 0);
            this.lblAvisoVersion.Name = "lblAvisoVersion";
            this.lblAvisoVersion.Size = new System.Drawing.Size(57, 20);
            this.lblAvisoVersion.TabIndex = 128;
            this.lblAvisoVersion.Text = "label1";
            // 
            // lblTitulo
            // 
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.GradientColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.lblTitulo.GradientColorTwo = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(1495, 22);
            this.lblTitulo.TabIndex = 92;
            this.lblTitulo.Text = "Consulta de stock de materiales";
            // 
            // dsMateriales1
            // 
            this.dsMateriales1.DataSetName = "dsMateriales";
            this.dsMateriales1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bindingSourceStocks
            // 
            this.bindingSourceStocks.DataMember = "ListaStocks";
            this.bindingSourceStocks.DataSource = this.dsMateriales1;
            // 
            // sqlConn
            // 
            this.sqlConn.ConnectionString = Utiles._connection.ConnectionString.ToString();   //---- GSG (06/03/2021)
            this.sqlConn.FireInfoMessageEventOnUserErrors = false;
            // 
            // sqldaListaStocks
            // 
            this.sqldaListaStocks.SelectCommand = this.sqlCmdListaStocks;
            this.sqldaListaStocks.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaStocks", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("sIdMaterial", "sIdMaterial"),
                        new System.Data.Common.DataColumnMapping("sCodNacional", "sCodNacional"),
                        new System.Data.Common.DataColumnMapping("sMaterial", "sMaterial"),
                        new System.Data.Common.DataColumnMapping("iStock", "iStock")})});
            // 
            // sqlCmdListaStocks
            // 
            this.sqlCmdListaStocks.CommandText = "ListaStocks";
            this.sqlCmdListaStocks.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdListaStocks.Connection = this.sqlConn;
            this.sqlCmdListaStocks.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@sIdMaterial", System.Data.SqlDbType.VarChar)});
            // 
            // pnVentas
            // 
            this.pnVentas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnVentas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnVentas.Controls.Add(this.dGVStocks);
            this.pnVentas.Controls.Add(this.lblNumReg);
            this.pnVentas.Controls.Add(this.labelGradient2);
            this.pnVentas.Location = new System.Drawing.Point(4, 113);
            this.pnVentas.Name = "pnVentas";
            this.pnVentas.Size = new System.Drawing.Size(1496, 691);
            this.pnVentas.TabIndex = 32;
            // 
            // dGVStocks
            // 
            this.dGVStocks.AllowUserToAddRows = false;
            this.dGVStocks.AllowUserToDeleteRows = false;
            this.dGVStocks.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGVStocks.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dGVStocks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVStocks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sIdMaterial,
            this.sCodNacional,
            this.sMaterial,
            this.iStock,
            this.sIdMaterialDataGridViewTextBoxColumn,
            this.sCodNacionalDataGridViewTextBoxColumn,
            this.sMaterialDataGridViewTextBoxColumn,
            this.iStockDataGridViewTextBoxColumn});
            this.dGVStocks.DataMember = "ListaStocks";
            this.dGVStocks.DataSource = this.dsMateriales1;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dGVStocks.DefaultCellStyle = dataGridViewCellStyle3;
            this.dGVStocks.GridColor = System.Drawing.SystemColors.ControlLight;
            this.dGVStocks.Location = new System.Drawing.Point(1, 24);
            this.dGVStocks.Name = "dGVStocks";
            this.dGVStocks.ReadOnly = true;
            this.dGVStocks.RowHeadersWidth = 30;
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            this.dGVStocks.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dGVStocks.Size = new System.Drawing.Size(1488, 660);
            this.dGVStocks.TabIndex = 97;
            this.dGVStocks.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dGVStocks_KeyPress);
            // 
            // lblNumReg
            // 
            this.lblNumReg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.lblNumReg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblNumReg.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumReg.ForeColor = System.Drawing.Color.Black;
            this.lblNumReg.Location = new System.Drawing.Point(1430, 0);
            this.lblNumReg.Name = "lblNumReg";
            this.lblNumReg.Size = new System.Drawing.Size(62, 24);
            this.lblNumReg.TabIndex = 96;
            this.lblNumReg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelGradient2
            // 
            this.labelGradient2.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelGradient2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGradient2.ForeColor = System.Drawing.Color.White;
            this.labelGradient2.GradientColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.labelGradient2.GradientColorTwo = System.Drawing.Color.White;
            this.labelGradient2.Location = new System.Drawing.Point(0, 0);
            this.labelGradient2.Name = "labelGradient2";
            this.labelGradient2.Size = new System.Drawing.Size(1492, 22);
            this.labelGradient2.TabIndex = 92;
            this.labelGradient2.Text = "Stocks";
            this.labelGradient2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sIdMaterial
            // 
            this.sIdMaterial.DataPropertyName = "sIdMaterial";
            this.sIdMaterial.HeaderText = "sIdMaterial";
            this.sIdMaterial.Name = "sIdMaterial";
            this.sIdMaterial.ReadOnly = true;
            this.sIdMaterial.Visible = false;
            // 
            // sCodNacional
            // 
            this.sCodNacional.DataPropertyName = "sCodNacional";
            this.sCodNacional.HeaderText = "Cód. Nacional";
            this.sCodNacional.Name = "sCodNacional";
            this.sCodNacional.ReadOnly = true;
            this.sCodNacional.Width = 160;
            // 
            // sMaterial
            // 
            this.sMaterial.DataPropertyName = "sMaterial";
            this.sMaterial.HeaderText = "sMaterial";
            this.sMaterial.Name = "sMaterial";
            this.sMaterial.ReadOnly = true;
            this.sMaterial.Width = 500;
            // 
            // iStock
            // 
            this.iStock.DataPropertyName = "iStock";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.iStock.DefaultCellStyle = dataGridViewCellStyle2;
            this.iStock.HeaderText = "Stock";
            this.iStock.Name = "iStock";
            this.iStock.ReadOnly = true;
            // 
            // sIdMaterialDataGridViewTextBoxColumn
            // 
            this.sIdMaterialDataGridViewTextBoxColumn.DataPropertyName = "sIdMaterial";
            this.sIdMaterialDataGridViewTextBoxColumn.HeaderText = "sIdMaterial";
            this.sIdMaterialDataGridViewTextBoxColumn.Name = "sIdMaterialDataGridViewTextBoxColumn";
            this.sIdMaterialDataGridViewTextBoxColumn.ReadOnly = true;
            this.sIdMaterialDataGridViewTextBoxColumn.Visible = false;
            // 
            // sCodNacionalDataGridViewTextBoxColumn
            // 
            this.sCodNacionalDataGridViewTextBoxColumn.DataPropertyName = "sCodNacional";
            this.sCodNacionalDataGridViewTextBoxColumn.HeaderText = "sCodNacional";
            this.sCodNacionalDataGridViewTextBoxColumn.Name = "sCodNacionalDataGridViewTextBoxColumn";
            this.sCodNacionalDataGridViewTextBoxColumn.ReadOnly = true;
            this.sCodNacionalDataGridViewTextBoxColumn.Visible = false;
            // 
            // sMaterialDataGridViewTextBoxColumn
            // 
            this.sMaterialDataGridViewTextBoxColumn.DataPropertyName = "sMaterial";
            this.sMaterialDataGridViewTextBoxColumn.HeaderText = "sMaterial";
            this.sMaterialDataGridViewTextBoxColumn.Name = "sMaterialDataGridViewTextBoxColumn";
            this.sMaterialDataGridViewTextBoxColumn.ReadOnly = true;
            this.sMaterialDataGridViewTextBoxColumn.Visible = false;
            // 
            // iStockDataGridViewTextBoxColumn
            // 
            this.iStockDataGridViewTextBoxColumn.DataPropertyName = "iStock";
            this.iStockDataGridViewTextBoxColumn.HeaderText = "iStock";
            this.iStockDataGridViewTextBoxColumn.Name = "iStockDataGridViewTextBoxColumn";
            this.iStockDataGridViewTextBoxColumn.ReadOnly = true;
            this.iStockDataGridViewTextBoxColumn.Visible = false;
            // 
            // frmStocks
            // 
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1503, 816);
            this.Controls.Add(this.pnVentas);
            this.Controls.Add(this.panelFiltros);
            this.Controls.Add(this.ucBotoneraSecundaria1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmStocks";
            this.Text = "Consulta Stocks";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmStocks_Load);
            this.panelFiltros.ResumeLayout(false);
            this.panelFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsMateriales1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceStocks)).EndInit();
            this.pnVentas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGVStocks)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controles.ucBotoneraSecundaria ucBotoneraSecundaria1;
        private System.Windows.Forms.Panel panelFiltros;
        private System.Windows.Forms.Label lblAvisoVersion;
        private Controles.LabelGradient lblTitulo;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.TextBox txbsDescripcion;
        private dsMateriales dsMateriales1;
        private System.Windows.Forms.BindingSource bindingSourceStocks;
        private System.Data.SqlClient.SqlConnection sqlConn;
        private System.Data.SqlClient.SqlDataAdapter sqldaListaStocks;
        private System.Data.SqlClient.SqlCommand sqlCmdListaStocks;
        private System.Windows.Forms.Panel pnVentas;
        private System.Windows.Forms.DataGridView dGVStocks;
        private System.Windows.Forms.Label lblNumReg;
        private Controles.LabelGradient labelGradient2;
        private System.Windows.Forms.DataGridViewTextBoxColumn sIdMaterial;
        private System.Windows.Forms.DataGridViewTextBoxColumn sCodNacional;
        private System.Windows.Forms.DataGridViewTextBoxColumn sMaterial;
        private System.Windows.Forms.DataGridViewTextBoxColumn iStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn sIdMaterialDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sCodNacionalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sMaterialDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iStockDataGridViewTextBoxColumn;
    }
}