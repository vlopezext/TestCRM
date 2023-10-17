namespace GESTCRM.Formularios
{
    partial class frmAlarmasVisitas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAlarmasVisitas));
            this.sqlConn = new System.Data.SqlClient.SqlConnection();
            this.panelFiltros = new System.Windows.Forms.Panel();
            this.gbBrick = new System.Windows.Forms.GroupBox();
            this.dataGridViewBricks = new System.Windows.Forms.DataGridView();
            this.sIdBrick = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.selected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dsBuscar1 = new GESTCRM.Formularios.Busquedas.dsBuscar();
            this.lblNumRegBricks = new System.Windows.Forms.Label();
            this.labelGradientBrick = new GESTCRM.Controles.LabelGradient();
            this.lblAvisoVersion = new System.Windows.Forms.Label();
            this.lblTitulo = new GESTCRM.Controles.LabelGradient();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.sqldaListaBricks = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCmdListaBricks = new System.Data.SqlClient.SqlCommand();
            this.sqldaAlarmasVisitas = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCmdListaAlarmasVisitas = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdSetAlarmasVisitas = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdSetBrickTemp = new System.Data.SqlClient.SqlCommand();
            this.bricksTable = new System.Data.DataTable();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridViewAlarmas = new System.Windows.Forms.DataGridView();
            this.iIdCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sIdCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dUltVisita = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sIdClasificacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sPoblacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sBrickName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dFecUltPed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fImporteBrutoUltPed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsClientes = new GESTCRM.Formularios.DataSets.dsClientes();
            this.lblNumRegAlarmas = new System.Windows.Forms.Label();
            this.labelGradient1 = new GESTCRM.Controles.LabelGradient();
            this.panelFiltros.SuspendLayout();
            this.gbBrick.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBricks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBuscar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bricksTable)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAlarmas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // sqlConn
            // 
            this.sqlConn.ConnectionString = Utiles._connection.ConnectionString.ToString();   //---- GSG (06/03/2021)
            this.sqlConn.FireInfoMessageEventOnUserErrors = false;
            // 
            // panelFiltros
            // 
            this.panelFiltros.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelFiltros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelFiltros.Controls.Add(this.gbBrick);
            this.panelFiltros.Controls.Add(this.lblAvisoVersion);
            this.panelFiltros.Controls.Add(this.lblTitulo);
            this.panelFiltros.Controls.Add(this.btnBuscar);
            this.panelFiltros.Location = new System.Drawing.Point(4, 4);
            this.panelFiltros.Name = "panelFiltros";
            this.panelFiltros.Size = new System.Drawing.Size(1494, 223);
            this.panelFiltros.TabIndex = 32;
            // 
            // gbBrick
            // 
            this.gbBrick.Controls.Add(this.dataGridViewBricks);
            this.gbBrick.Controls.Add(this.lblNumRegBricks);
            this.gbBrick.Controls.Add(this.labelGradientBrick);
            this.gbBrick.Location = new System.Drawing.Point(9, 23);
            this.gbBrick.Name = "gbBrick";
            this.gbBrick.Size = new System.Drawing.Size(628, 187);
            this.gbBrick.TabIndex = 144;
            this.gbBrick.TabStop = false;
            // 
            // dataGridViewBricks
            // 
            this.dataGridViewBricks.AllowUserToAddRows = false;
            this.dataGridViewBricks.AllowUserToDeleteRows = false;
            this.dataGridViewBricks.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dataGridViewBricks.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewBricks.AutoGenerateColumns = false;
            this.dataGridViewBricks.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewBricks.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewBricks.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewBricks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBricks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sIdBrick,
            this.sDescripcion,
            this.selected});
            this.dataGridViewBricks.DataMember = "ListaBricks";
            this.dataGridViewBricks.DataSource = this.dsBuscar1;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewBricks.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewBricks.Location = new System.Drawing.Point(6, 39);
            this.dataGridViewBricks.MultiSelect = false;
            this.dataGridViewBricks.Name = "dataGridViewBricks";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewBricks.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewBricks.RowHeadersWidth = 25;
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            this.dataGridViewBricks.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewBricks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewBricks.Size = new System.Drawing.Size(617, 142);
            this.dataGridViewBricks.TabIndex = 141;
            // 
            // sIdBrick
            // 
            this.sIdBrick.DataPropertyName = "sIdBrick";
            this.sIdBrick.HeaderText = "Id. Brick";
            this.sIdBrick.Name = "sIdBrick";
            this.sIdBrick.ReadOnly = true;
            this.sIdBrick.Width = 110;
            // 
            // sDescripcion
            // 
            this.sDescripcion.DataPropertyName = "sDescripcion";
            this.sDescripcion.HeaderText = "Descripción Brick";
            this.sDescripcion.Name = "sDescripcion";
            this.sDescripcion.ReadOnly = true;
            this.sDescripcion.Width = 440;
            // 
            // selected
            // 
            this.selected.DataPropertyName = "selected";
            this.selected.FalseValue = "false";
            this.selected.HeaderText = "";
            this.selected.IndeterminateValue = "false";
            this.selected.Name = "selected";
            this.selected.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.selected.TrueValue = "true";
            this.selected.Width = 20;
            // 
            // dsBuscar1
            // 
            this.dsBuscar1.DataSetName = "dsBuscar";
            this.dsBuscar1.Locale = new System.Globalization.CultureInfo("es-ES");
            this.dsBuscar1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lblNumRegBricks
            // 
            this.lblNumRegBricks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.lblNumRegBricks.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblNumRegBricks.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumRegBricks.ForeColor = System.Drawing.Color.Black;
            this.lblNumRegBricks.Location = new System.Drawing.Point(559, 11);
            this.lblNumRegBricks.Name = "lblNumRegBricks";
            this.lblNumRegBricks.Size = new System.Drawing.Size(64, 22);
            this.lblNumRegBricks.TabIndex = 143;
            this.lblNumRegBricks.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelGradientBrick
            // 
            this.labelGradientBrick.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGradientBrick.ForeColor = System.Drawing.Color.White;
            this.labelGradientBrick.GradientColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.labelGradientBrick.GradientColorTwo = System.Drawing.Color.White;
            this.labelGradientBrick.Location = new System.Drawing.Point(6, 11);
            this.labelGradientBrick.Name = "labelGradientBrick";
            this.labelGradientBrick.Size = new System.Drawing.Size(616, 22);
            this.labelGradientBrick.TabIndex = 142;
            this.labelGradientBrick.Text = "Bricks";
            this.labelGradientBrick.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAvisoVersion
            // 
            this.lblAvisoVersion.AutoSize = true;
            this.lblAvisoVersion.BackColor = System.Drawing.Color.Yellow;
            this.lblAvisoVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvisoVersion.ForeColor = System.Drawing.Color.Red;
            this.lblAvisoVersion.Location = new System.Drawing.Point(809, -1);
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
            this.lblTitulo.Size = new System.Drawing.Size(1492, 22);
            this.lblTitulo.TabIndex = 92;
            this.lblTitulo.Text = "Alarmas Visitas";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.Color.Black;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.Location = new System.Drawing.Point(882, 168);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 31);
            this.btnBuscar.TabIndex = 137;
            this.btnBuscar.Text = "&Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // sqldaListaBricks
            // 
            this.sqldaListaBricks.SelectCommand = this.sqlCmdListaBricks;
            this.sqldaListaBricks.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaBricks", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("sIdBrick", "sIdBrick"),
                        new System.Data.Common.DataColumnMapping("sDescripcion", "sDescripcion")})});
            // 
            // sqlCmdListaBricks
            // 
            this.sqlCmdListaBricks.CommandText = "[ListaBricks]";
            this.sqlCmdListaBricks.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdListaBricks.Connection = this.sqlConn;
            this.sqlCmdListaBricks.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@sIdBrick", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt, 2)});
            // 
            // sqldaAlarmasVisitas
            // 
            this.sqldaAlarmasVisitas.SelectCommand = this.sqlCmdListaAlarmasVisitas;
            this.sqldaAlarmasVisitas.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "AlarmasVisitas", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iIdCliente", "iIdCliente"),
                        new System.Data.Common.DataColumnMapping("sIdCliente", "sIdCliente"),
                        new System.Data.Common.DataColumnMapping("sNombre", "sNombre"),
                        new System.Data.Common.DataColumnMapping("dUltVisita", "dUltVisita"),
                        new System.Data.Common.DataColumnMapping("sPoblacion", "sPoblacion"),
                        new System.Data.Common.DataColumnMapping("sBrickName", "sBrickName"),
                        new System.Data.Common.DataColumnMapping("sIdClasificacion", "sIdClasificacion"),
                        new System.Data.Common.DataColumnMapping("dFecUltPed", "dFecUltPed"),
                        new System.Data.Common.DataColumnMapping("fImporteBrutoUltPed", "fImporteBrutoUltPed")})});
            // 
            // sqlCmdListaAlarmasVisitas
            // 
            this.sqlCmdListaAlarmasVisitas.CommandText = "[ListaAlarmasVisitas]";
            this.sqlCmdListaAlarmasVisitas.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdListaAlarmasVisitas.Connection = this.sqlConn;
            this.sqlCmdListaAlarmasVisitas.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null)});
            // 
            // sqlCmdSetAlarmasVisitas
            // 
            this.sqlCmdSetAlarmasVisitas.CommandText = "[SetAlarmasVisitas]";
            this.sqlCmdSetAlarmasVisitas.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdSetAlarmasVisitas.Connection = this.sqlConn;
            // 
            // sqlCmdSetBrickTemp
            // 
            this.sqlCmdSetBrickTemp.CommandText = "[SetBrickTemp]";
            this.sqlCmdSetBrickTemp.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdSetBrickTemp.Connection = this.sqlConn;
            this.sqlCmdSetBrickTemp.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@Action", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@brick", System.Data.SqlDbType.VarChar, 10)});
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridViewAlarmas);
            this.groupBox1.Controls.Add(this.lblNumRegAlarmas);
            this.groupBox1.Controls.Add(this.labelGradient1);
            this.groupBox1.Location = new System.Drawing.Point(9, 233);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1489, 556);
            this.groupBox1.TabIndex = 145;
            this.groupBox1.TabStop = false;
            // 
            // dataGridViewAlarmas
            // 
            this.dataGridViewAlarmas.AllowUserToAddRows = false;
            this.dataGridViewAlarmas.AllowUserToDeleteRows = false;
            this.dataGridViewAlarmas.AllowUserToResizeRows = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            this.dataGridViewAlarmas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewAlarmas.AutoGenerateColumns = false;
            this.dataGridViewAlarmas.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewAlarmas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewAlarmas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewAlarmas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAlarmas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iIdCliente,
            this.sIdCliente,
            this.sNombre,
            this.dUltVisita,
            this.sIdClasificacion,
            this.sPoblacion,
            this.sBrickName,
            this.grupo,
            this.dFecUltPed,
            this.fImporteBrutoUltPed});
            this.dataGridViewAlarmas.DataMember = "AlarmasVisitas";
            this.dataGridViewAlarmas.DataSource = this.dsClientes;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewAlarmas.DefaultCellStyle = dataGridViewCellStyle12;
            this.dataGridViewAlarmas.Location = new System.Drawing.Point(6, 36);
            this.dataGridViewAlarmas.MultiSelect = false;
            this.dataGridViewAlarmas.Name = "dataGridViewAlarmas";
            this.dataGridViewAlarmas.ReadOnly = true;
            this.dataGridViewAlarmas.RowHeadersWidth = 25;
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.Black;
            this.dataGridViewAlarmas.RowsDefaultCellStyle = dataGridViewCellStyle13;
            this.dataGridViewAlarmas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewAlarmas.Size = new System.Drawing.Size(1476, 514);
            this.dataGridViewAlarmas.TabIndex = 141;
            this.dataGridViewAlarmas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewAlarmas_CellDoubleClick);
            this.dataGridViewAlarmas.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridViewAlarmas_CellPainting);
            this.dataGridViewAlarmas.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dataGridViewAlarmas_RowPrePaint);
            // 
            // iIdCliente
            // 
            this.iIdCliente.DataPropertyName = "iIdCliente";
            this.iIdCliente.HeaderText = "iIdCliente";
            this.iIdCliente.Name = "iIdCliente";
            this.iIdCliente.ReadOnly = true;
            this.iIdCliente.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.iIdCliente.Visible = false;
            // 
            // sIdCliente
            // 
            this.sIdCliente.DataPropertyName = "sIdCliente";
            this.sIdCliente.HeaderText = "sIdCliente";
            this.sIdCliente.Name = "sIdCliente";
            this.sIdCliente.ReadOnly = true;
            this.sIdCliente.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.sIdCliente.Visible = false;
            // 
            // sNombre
            // 
            this.sNombre.DataPropertyName = "sNombre";
            this.sNombre.HeaderText = "Cliente/Centro";
            this.sNombre.Name = "sNombre";
            this.sNombre.ReadOnly = true;
            this.sNombre.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.sNombre.Width = 335;
            // 
            // dUltVisita
            // 
            this.dUltVisita.DataPropertyName = "dUltVisita";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dUltVisita.DefaultCellStyle = dataGridViewCellStyle8;
            this.dUltVisita.HeaderText = "Última Visita";
            this.dUltVisita.Name = "dUltVisita";
            this.dUltVisita.ReadOnly = true;
            this.dUltVisita.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dUltVisita.Width = 120;
            // 
            // sIdClasificacion
            // 
            this.sIdClasificacion.DataPropertyName = "sIdClasificacion";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.sIdClasificacion.DefaultCellStyle = dataGridViewCellStyle9;
            this.sIdClasificacion.HeaderText = "Clasificación";
            this.sIdClasificacion.Name = "sIdClasificacion";
            this.sIdClasificacion.ReadOnly = true;
            this.sIdClasificacion.Width = 200;
            // 
            // sPoblacion
            // 
            this.sPoblacion.DataPropertyName = "sPoblacion";
            this.sPoblacion.HeaderText = "Poblacion";
            this.sPoblacion.Name = "sPoblacion";
            this.sPoblacion.ReadOnly = true;
            this.sPoblacion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.sPoblacion.Width = 240;
            // 
            // sBrickName
            // 
            this.sBrickName.DataPropertyName = "sBrickName";
            this.sBrickName.HeaderText = "Brick";
            this.sBrickName.Name = "sBrickName";
            this.sBrickName.ReadOnly = true;
            this.sBrickName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.sBrickName.Width = 200;
            // 
            // grupo
            // 
            this.grupo.DataPropertyName = "grupo";
            this.grupo.HeaderText = "grupo";
            this.grupo.Name = "grupo";
            this.grupo.ReadOnly = true;
            this.grupo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.grupo.Visible = false;
            // 
            // dFecUltPed
            // 
            this.dFecUltPed.DataPropertyName = "dFecUltPed";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.Format = "d";
            dataGridViewCellStyle10.NullValue = null;
            this.dFecUltPed.DefaultCellStyle = dataGridViewCellStyle10;
            this.dFecUltPed.HeaderText = "Ultimo Pedido";
            this.dFecUltPed.Name = "dFecUltPed";
            this.dFecUltPed.ReadOnly = true;
            this.dFecUltPed.Width = 160;
            // 
            // fImporteBrutoUltPed
            // 
            this.fImporteBrutoUltPed.DataPropertyName = "fImporteBrutoUltPed";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.Format = "N2";
            this.fImporteBrutoUltPed.DefaultCellStyle = dataGridViewCellStyle11;
            this.fImporteBrutoUltPed.HeaderText = "Bruto Ult. Ped.";
            this.fImporteBrutoUltPed.Name = "fImporteBrutoUltPed";
            this.fImporteBrutoUltPed.ReadOnly = true;
            this.fImporteBrutoUltPed.Width = 160;
            // 
            // dsClientes
            // 
            this.dsClientes.DataSetName = "dsClientes";
            this.dsClientes.Locale = new System.Globalization.CultureInfo("en-US");
            this.dsClientes.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lblNumRegAlarmas
            // 
            this.lblNumRegAlarmas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.lblNumRegAlarmas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblNumRegAlarmas.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumRegAlarmas.ForeColor = System.Drawing.Color.Black;
            this.lblNumRegAlarmas.Location = new System.Drawing.Point(1419, 9);
            this.lblNumRegAlarmas.Name = "lblNumRegAlarmas";
            this.lblNumRegAlarmas.Size = new System.Drawing.Size(64, 24);
            this.lblNumRegAlarmas.TabIndex = 143;
            this.lblNumRegAlarmas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelGradient1
            // 
            this.labelGradient1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGradient1.ForeColor = System.Drawing.Color.White;
            this.labelGradient1.GradientColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.labelGradient1.GradientColorTwo = System.Drawing.Color.White;
            this.labelGradient1.Location = new System.Drawing.Point(6, 11);
            this.labelGradient1.Name = "labelGradient1";
            this.labelGradient1.Size = new System.Drawing.Size(1476, 22);
            this.labelGradient1.TabIndex = 142;
            this.labelGradient1.Text = "Alarmas";
            this.labelGradient1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmAlarmasVisitas
            // 
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1503, 801);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panelFiltros);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAlarmasVisitas";
            this.Text = "Alarmas Visitas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmAlarmasVisitas_Load);
            this.panelFiltros.ResumeLayout(false);
            this.panelFiltros.PerformLayout();
            this.gbBrick.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBricks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBuscar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bricksTable)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAlarmas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsClientes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelFiltros;
        private System.Windows.Forms.Label lblAvisoVersion;
        private Controles.LabelGradient lblTitulo;
        private System.Windows.Forms.Button btnBuscar;
        private Busquedas.dsBuscar dsBuscar1;
        private System.Data.SqlClient.SqlConnection sqlConn;
        private System.Data.SqlClient.SqlDataAdapter sqldaListaBricks;
        private System.Data.SqlClient.SqlCommand sqlCmdListaBricks;
        private System.Windows.Forms.DataGridView dataGridViewBricks;
        private Controles.LabelGradient labelGradientBrick;
        private System.Windows.Forms.GroupBox gbBrick;
        private System.Windows.Forms.Label lblNumRegBricks;
        private System.Data.SqlClient.SqlDataAdapter sqldaAlarmasVisitas;
        private System.Data.SqlClient.SqlCommand sqlCmdSetAlarmasVisitas;
        private System.Data.SqlClient.SqlCommand sqlCmdListaAlarmasVisitas;
        private System.Data.SqlClient.SqlCommand sqlCmdSetBrickTemp;
        private System.Data.DataTable bricksTable;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridViewAlarmas;
        private System.Windows.Forms.Label lblNumRegAlarmas;
        private Controles.LabelGradient labelGradient1;
        private DataSets.dsClientes dsClientes;
        private System.Windows.Forms.DataGridViewTextBoxColumn sIdBrick;
        private System.Windows.Forms.DataGridViewTextBoxColumn sDescripcion;
        private System.Windows.Forms.DataGridViewCheckBoxColumn selected;
        private System.Windows.Forms.DataGridViewTextBoxColumn iIdCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn sIdCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn sNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn dUltVisita;
        private System.Windows.Forms.DataGridViewTextBoxColumn sIdClasificacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn sPoblacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn sBrickName;
        private System.Windows.Forms.DataGridViewTextBoxColumn grupo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dFecUltPed;
        private System.Windows.Forms.DataGridViewTextBoxColumn fImporteBrutoUltPed;
    }
}