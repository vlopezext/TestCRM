namespace GESTCRM.Formularios
{
    partial class frmPropuestaPedido
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPropuestaPedido));
            System.Configuration.AppSettingsReader configurationAppSettings = new System.Configuration.AppSettingsReader();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelFiltros = new System.Windows.Forms.Panel();
            this.lblAvisoVersion = new System.Windows.Forms.Label();
            this.txtbCobertura = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtsIdCliente = new System.Windows.Forms.TextBox();
            this.btBuscarCliente = new System.Windows.Forms.Button();
            this.txtsCliente = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lblTitulo = new GESTCRM.Controles.LabelGradient();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txbDto = new System.Windows.Forms.TextBox();
            this.txbImporte = new System.Windows.Forms.TextBox();
            this.lblImporte = new System.Windows.Forms.Label();
            this.txbImporteBruto = new System.Windows.Forms.TextBox();
            this.lblImporteBruto = new System.Windows.Forms.Label();
            this.txbRentabilidad = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.sqlConn = new System.Data.SqlClient.SqlConnection();
            this.pnBusqueda = new System.Windows.Forms.Panel();
            this.dgvMats = new System.Windows.Forms.DataGridView();
            this.dsMateriales1 = new GESTCRM.Formularios.dsMateriales();
            this.lblNumReg = new System.Windows.Forms.Label();
            this.labelGradient2 = new GESTCRM.Controles.LabelGradient();
            this.btCancelar = new System.Windows.Forms.Button();
            this.btAceptar = new System.Windows.Forms.Button();
            this.sqldaPropuestaMateriales = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCmdPropuestaMateriales = new System.Data.SqlClient.SqlCommand();
            this.sqlGetCosteMat = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdGetMaterialesNoRentabilidad = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdGetRentabilidadDescripcion = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdGetRentabilidadColor = new System.Data.SqlClient.SqlCommand();
            this.sqldaListaAccMarkCampByCli = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCmdListaAccMarkCampByCli = new System.Data.SqlClient.SqlCommand();
            this.sqlDaListaMateriales = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectListaMateriales = new System.Data.SqlClient.SqlCommand();
            this.sqldaListaCampanyas = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCmdListaCampanyasNEW = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdListaCampanyas = new System.Data.SqlClient.SqlCommand();
            this.sqldaListaLineasPedidoRentAnual = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectLineasPedidoRentAnual = new System.Data.SqlClient.SqlCommand();
            this.dsPedidos1 = new GESTCRM.Formularios.DataSets.dsPedidos();
            this.cBoxCampanyas = new System.Windows.Forms.ComboBox();
            this.dsAccionesMarketing1 = new GESTCRM.Formularios.DataSets.dsAccionesMarketing();
            this.dsFormularios1 = new GESTCRM.Formularios.dsFormularios();
            this.btExportar = new System.Windows.Forms.Button();
            this.chkbMarcar = new System.Windows.Forms.CheckBox();
            this.txtRentAA = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.selected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Rentabilidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sCodNacional = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sMaterial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sIdMaterial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descmedio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iUnidadesEnfajado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iCajaCompleta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelFiltros.SuspendLayout();
            this.pnBusqueda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMats)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsMateriales1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPedidos1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAccionesMarketing1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsFormularios1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelFiltros
            // 
            this.panelFiltros.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelFiltros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelFiltros.Controls.Add(this.lblAvisoVersion);
            this.panelFiltros.Controls.Add(this.txtbCobertura);
            this.panelFiltros.Controls.Add(this.label1);
            this.panelFiltros.Controls.Add(this.txtsIdCliente);
            this.panelFiltros.Controls.Add(this.btBuscarCliente);
            this.panelFiltros.Controls.Add(this.txtsCliente);
            this.panelFiltros.Controls.Add(this.label9);
            this.panelFiltros.Controls.Add(this.lblTitulo);
            this.panelFiltros.Controls.Add(this.btnBuscar);
            this.panelFiltros.Location = new System.Drawing.Point(2, 3);
            this.panelFiltros.Name = "panelFiltros";
            this.panelFiltros.Size = new System.Drawing.Size(1496, 76);
            this.panelFiltros.TabIndex = 29;
            // 
            // lblAvisoVersion
            // 
            this.lblAvisoVersion.AutoSize = true;
            this.lblAvisoVersion.BackColor = System.Drawing.Color.Yellow;
            this.lblAvisoVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvisoVersion.ForeColor = System.Drawing.Color.Red;
            this.lblAvisoVersion.Location = new System.Drawing.Point(178, 0);
            this.lblAvisoVersion.Name = "lblAvisoVersion";
            this.lblAvisoVersion.Size = new System.Drawing.Size(57, 20);
            this.lblAvisoVersion.TabIndex = 127;
            this.lblAvisoVersion.Text = "label1";
            // 
            // txtbCobertura
            // 
            this.txtbCobertura.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbCobertura.Location = new System.Drawing.Point(875, 34);
            this.txtbCobertura.Name = "txtbCobertura";
            this.txtbCobertura.Size = new System.Drawing.Size(58, 26);
            this.txtbCobertura.TabIndex = 120;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(752, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 22);
            this.label1.TabIndex = 119;
            this.label1.Text = "Días cobertura:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtsIdCliente
            // 
            this.txtsIdCliente.BackColor = System.Drawing.Color.White;
            this.txtsIdCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsIdCliente.ForeColor = System.Drawing.Color.Black;
            this.txtsIdCliente.Location = new System.Drawing.Point(81, 35);
            this.txtsIdCliente.MaxLength = 20;
            this.txtsIdCliente.Name = "txtsIdCliente";
            this.txtsIdCliente.Size = new System.Drawing.Size(138, 26);
            this.txtsIdCliente.TabIndex = 115;
            // 
            // btBuscarCliente
            // 
            this.btBuscarCliente.Image = ((System.Drawing.Image)(resources.GetObject("btBuscarCliente.Image")));
            this.btBuscarCliente.Location = new System.Drawing.Point(664, 34);
            this.btBuscarCliente.Name = "btBuscarCliente";
            this.btBuscarCliente.Size = new System.Drawing.Size(29, 29);
            this.btBuscarCliente.TabIndex = 117;
            this.btBuscarCliente.TabStop = false;
            this.btBuscarCliente.UseVisualStyleBackColor = true;
            this.btBuscarCliente.Click += new System.EventHandler(this.btBuscarCliente_Click);
            // 
            // txtsCliente
            // 
            this.txtsCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtsCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsCliente.ForeColor = System.Drawing.Color.Black;
            this.txtsCliente.Location = new System.Drawing.Point(223, 35);
            this.txtsCliente.Name = "txtsCliente";
            this.txtsCliente.ReadOnly = true;
            this.txtsCliente.Size = new System.Drawing.Size(437, 26);
            this.txtsCliente.TabIndex = 116;
            this.txtsCliente.TabStop = false;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(17, 37);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 22);
            this.label9.TabIndex = 118;
            this.label9.Text = "Cliente:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.lblTitulo.Size = new System.Drawing.Size(1494, 22);
            this.lblTitulo.TabIndex = 92;
            this.lblTitulo.Text = "Propuesta de pedido";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.Color.Black;
            this.btnBuscar.Location = new System.Drawing.Point(1352, 30);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(122, 30);
            this.btnBuscar.TabIndex = 12;
            this.btnBuscar.Text = "&Ver Propuesta";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txbDto
            // 
            this.txbDto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txbDto.Cursor = System.Windows.Forms.Cursors.Default;
            this.txbDto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbDto.Location = new System.Drawing.Point(750, 93);
            this.txbDto.Margin = new System.Windows.Forms.Padding(2);
            this.txbDto.Name = "txbDto";
            this.txbDto.ReadOnly = true;
            this.txbDto.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txbDto.Size = new System.Drawing.Size(83, 26);
            this.txbDto.TabIndex = 116;
            this.txbDto.TabStop = false;
            this.txbDto.Text = "0%";
            // 
            // txbImporte
            // 
            this.txbImporte.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txbImporte.Cursor = System.Windows.Forms.Cursors.Default;
            this.txbImporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbImporte.Location = new System.Drawing.Point(151, 93);
            this.txbImporte.Margin = new System.Windows.Forms.Padding(2);
            this.txbImporte.Name = "txbImporte";
            this.txbImporte.ReadOnly = true;
            this.txbImporte.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txbImporte.Size = new System.Drawing.Size(127, 26);
            this.txbImporte.TabIndex = 115;
            this.txbImporte.TabStop = false;
            this.txbImporte.Text = "0 €";
            // 
            // lblImporte
            // 
            this.lblImporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImporte.ForeColor = System.Drawing.Color.Red;
            this.lblImporte.Location = new System.Drawing.Point(33, 93);
            this.lblImporte.Name = "lblImporte";
            this.lblImporte.Size = new System.Drawing.Size(117, 24);
            this.lblImporte.TabIndex = 113;
            this.lblImporte.Text = "Importe neto:";
            this.lblImporte.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txbImporteBruto
            // 
            this.txbImporteBruto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txbImporteBruto.Cursor = System.Windows.Forms.Cursors.Default;
            this.txbImporteBruto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbImporteBruto.Location = new System.Drawing.Point(454, 94);
            this.txbImporteBruto.Margin = new System.Windows.Forms.Padding(2);
            this.txbImporteBruto.Name = "txbImporteBruto";
            this.txbImporteBruto.ReadOnly = true;
            this.txbImporteBruto.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txbImporteBruto.Size = new System.Drawing.Size(127, 26);
            this.txbImporteBruto.TabIndex = 120;
            this.txbImporteBruto.TabStop = false;
            this.txbImporteBruto.Text = "0 €";
            // 
            // lblImporteBruto
            // 
            this.lblImporteBruto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImporteBruto.ForeColor = System.Drawing.Color.Red;
            this.lblImporteBruto.Location = new System.Drawing.Point(330, 94);
            this.lblImporteBruto.Name = "lblImporteBruto";
            this.lblImporteBruto.Size = new System.Drawing.Size(123, 24);
            this.lblImporteBruto.TabIndex = 114;
            this.lblImporteBruto.Text = "Importe bruto:";
            this.lblImporteBruto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txbRentabilidad
            // 
            this.txbRentabilidad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txbRentabilidad.Cursor = System.Windows.Forms.Cursors.Default;
            this.txbRentabilidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbRentabilidad.ForeColor = System.Drawing.Color.White;
            this.txbRentabilidad.Location = new System.Drawing.Point(1034, 91);
            this.txbRentabilidad.Margin = new System.Windows.Forms.Padding(2);
            this.txbRentabilidad.Name = "txbRentabilidad";
            this.txbRentabilidad.ReadOnly = true;
            this.txbRentabilidad.Size = new System.Drawing.Size(126, 26);
            this.txbRentabilidad.TabIndex = 118;
            this.txbRentabilidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(643, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 24);
            this.label3.TabIndex = 119;
            this.label3.Text = "Des. medio:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(892, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 24);
            this.label2.TabIndex = 117;
            this.label2.Text = "Rent. Selección:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sqlConn
            // 
            this.sqlConn.ConnectionString = Utiles._connection.ConnectionString.ToString();   //---- GSG (06/03/2021)
            this.sqlConn.FireInfoMessageEventOnUserErrors = false;
            // 
            // pnBusqueda
            // 
            this.pnBusqueda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnBusqueda.Controls.Add(this.dgvMats);
            this.pnBusqueda.Controls.Add(this.lblNumReg);
            this.pnBusqueda.Controls.Add(this.labelGradient2);
            this.pnBusqueda.Location = new System.Drawing.Point(3, 132);
            this.pnBusqueda.Name = "pnBusqueda";
            this.pnBusqueda.Size = new System.Drawing.Size(1494, 576);
            this.pnBusqueda.TabIndex = 121;
            // 
            // dgvMats
            // 
            this.dgvMats.AllowUserToAddRows = false;
            this.dgvMats.AllowUserToDeleteRows = false;
            this.dgvMats.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvMats.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMats.AutoGenerateColumns = false;
            this.dgvMats.BackgroundColor = System.Drawing.Color.White;
            this.dgvMats.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMats.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvMats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMats.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.selected,
            this.Rentabilidad,
            this.sCodNacional,
            this.sMaterial,
            this.sIdMaterial,
            this.fPrecio,
            this.cantidad,
            this.descmedio,
            this.iStock,
            this.iUnidadesEnfajado,
            this.iCajaCompleta});
            this.dgvMats.DataMember = "PropuestaPedido";
            this.dgvMats.DataSource = this.dsMateriales1;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMats.DefaultCellStyle = dataGridViewCellStyle13;
            this.dgvMats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMats.Location = new System.Drawing.Point(0, 18);
            this.dgvMats.MultiSelect = false;
            this.dgvMats.Name = "dgvMats";
            this.dgvMats.RowHeadersVisible = false;
            this.dgvMats.RowHeadersWidth = 25;
            this.dgvMats.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMats.Size = new System.Drawing.Size(1492, 556);
            this.dgvMats.TabIndex = 90;
            this.dgvMats.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMats_CellDoubleClick);
            this.dgvMats.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMats_CellEndEdit);
            this.dgvMats.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvMats_CellMouseUp);
            this.dgvMats.CellParsing += new System.Windows.Forms.DataGridViewCellParsingEventHandler(this.dgvMats_CellParsing);
            this.dgvMats.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvMats_DataError);
            // 
            // dsMateriales1
            // 
            this.dsMateriales1.DataSetName = "dsMateriales";
            this.dsMateriales1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lblNumReg
            // 
            this.lblNumReg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.lblNumReg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblNumReg.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumReg.ForeColor = System.Drawing.Color.Black;
            this.lblNumReg.Location = new System.Drawing.Point(1428, 0);
            this.lblNumReg.Name = "lblNumReg";
            this.lblNumReg.Size = new System.Drawing.Size(64, 18);
            this.lblNumReg.TabIndex = 89;
            this.lblNumReg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelGradient2
            // 
            this.labelGradient2.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelGradient2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGradient2.ForeColor = System.Drawing.Color.White;
            this.labelGradient2.GradientColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.labelGradient2.GradientColorTwo = System.Drawing.Color.White;
            this.labelGradient2.Location = new System.Drawing.Point(0, 0);
            this.labelGradient2.Name = "labelGradient2";
            this.labelGradient2.Size = new System.Drawing.Size(1492, 18);
            this.labelGradient2.TabIndex = 88;
            this.labelGradient2.Text = "Resultado de la búsqueda";
            this.labelGradient2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btCancelar
            // 
            this.btCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCancelar.ForeColor = System.Drawing.Color.Black;
            this.btCancelar.Image = global::GESTCRM.Properties.Resources.cancel_032x032;
            this.btCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btCancelar.Location = new System.Drawing.Point(1112, 726);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(114, 41);
            this.btCancelar.TabIndex = 123;
            this.btCancelar.Text = "&Cancelar";
            this.btCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // btAceptar
            // 
            this.btAceptar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAceptar.ForeColor = System.Drawing.Color.Black;
            this.btAceptar.Image = global::GESTCRM.Properties.Resources.ok_032x032;
            this.btAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btAceptar.Location = new System.Drawing.Point(980, 726);
            this.btAceptar.Name = "btAceptar";
            this.btAceptar.Size = new System.Drawing.Size(114, 41);
            this.btAceptar.TabIndex = 122;
            this.btAceptar.Text = "&Aceptar ";
            this.btAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btAceptar.UseVisualStyleBackColor = true;
            this.btAceptar.Click += new System.EventHandler(this.btAceptar_Click);
            // 
            // sqldaPropuestaMateriales
            // 
            this.sqldaPropuestaMateriales.SelectCommand = this.sqlCmdPropuestaMateriales;
            this.sqldaPropuestaMateriales.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "PropuestaPedido", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("sCodNacional", "sCodNacional"),
                        new System.Data.Common.DataColumnMapping("sIdMaterial", "sIdMaterial"),
                        new System.Data.Common.DataColumnMapping("sMaterial", "sMaterial"),
                        new System.Data.Common.DataColumnMapping("fPrecio", "fPrecio"),
                        new System.Data.Common.DataColumnMapping("cantidad", "cantidad"),
                        new System.Data.Common.DataColumnMapping("descmedio", "descmedio")})});
            // 
            // sqlCmdPropuestaMateriales
            // 
            this.sqlCmdPropuestaMateriales.CommandText = "GetPropuestaPedido";
            this.sqlCmdPropuestaMateriales.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdPropuestaMateriales.Connection = this.sqlConn;
            this.sqlCmdPropuestaMateriales.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iDiasCobertura", System.Data.SqlDbType.Int, 4)});
            // 
            // sqlGetCosteMat
            // 
            this.sqlGetCosteMat.CommandText = "GetCosteMaterial";
            this.sqlGetCosteMat.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlGetCosteMat.Connection = this.sqlConn;
            this.sqlGetCosteMat.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@sIdMaterial", System.Data.SqlDbType.VarChar, 18),
            new System.Data.SqlClient.SqlParameter("@Ret", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Output, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null)});
            // 
            // sqlCmdGetMaterialesNoRentabilidad
            // 
            this.sqlCmdGetMaterialesNoRentabilidad.CommandText = "[GetMaterialesNoRentabilidad]";
            this.sqlCmdGetMaterialesNoRentabilidad.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdGetMaterialesNoRentabilidad.Connection = this.sqlConn;
            this.sqlCmdGetMaterialesNoRentabilidad.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@sIdPedido", System.Data.SqlDbType.VarChar, 12)});
            // 
            // sqlCmdGetRentabilidadDescripcion
            // 
            this.sqlCmdGetRentabilidadDescripcion.CommandText = "dbo.[GetRentabilidadDescripcion]";
            this.sqlCmdGetRentabilidadDescripcion.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdGetRentabilidadDescripcion.Connection = this.sqlConn;
            this.sqlCmdGetRentabilidadDescripcion.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@Rentabilidad", System.Data.SqlDbType.Float, 8),
            new System.Data.SqlClient.SqlParameter("@fecha", System.Data.SqlDbType.DateTime, 8)});
            // 
            // sqlCmdGetRentabilidadColor
            // 
            this.sqlCmdGetRentabilidadColor.CommandText = "dbo.[GetRentabilidadColor]";
            this.sqlCmdGetRentabilidadColor.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdGetRentabilidadColor.Connection = this.sqlConn;
            this.sqlCmdGetRentabilidadColor.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@Rentabilidad", System.Data.SqlDbType.Float, 8),
            new System.Data.SqlClient.SqlParameter("@fecha", System.Data.SqlDbType.DateTime, 8)});
            // 
            // sqldaListaAccMarkCampByCli
            // 
            this.sqldaListaAccMarkCampByCli.SelectCommand = this.sqlCmdListaAccMarkCampByCli;
            this.sqldaListaAccMarkCampByCli.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaMAccMarkCampSolsCods", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("sIdAccion", "sIdAccion"),
                        new System.Data.Common.DataColumnMapping("idCampanya", "idCampanya")})});
            // 
            // sqlCmdListaAccMarkCampByCli
            // 
            this.sqlCmdListaAccMarkCampByCli.CommandText = "[ListaAccMarkCampByCli]";
            this.sqlCmdListaAccMarkCampByCli.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdListaAccMarkCampByCli.Connection = this.sqlConn;
            this.sqlCmdListaAccMarkCampByCli.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4)});
            // 
            // sqlDaListaMateriales
            // 
            this.sqlDaListaMateriales.SelectCommand = this.sqlSelectListaMateriales;
            this.sqlDaListaMateriales.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaMateriales", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("sIdMaterial", "sIdMaterial"),
                        new System.Data.Common.DataColumnMapping("sMaterial", "sMaterial"),
                        new System.Data.Common.DataColumnMapping("sCodNacional", "sCodNacional"),
                        new System.Data.Common.DataColumnMapping("fPrecio", "fPrecio"),
                        new System.Data.Common.DataColumnMapping("selected", "selected"),
                        new System.Data.Common.DataColumnMapping("iStock", "iStock"),
                        new System.Data.Common.DataColumnMapping("dEntrega", "dEntrega"),
                        new System.Data.Common.DataColumnMapping("iPendientes", "iPendientes")})});
            // 
            // sqlSelectListaMateriales
            // 
            this.sqlSelectListaMateriales.CommandText = "ListaMaterialesDesCamp";
            this.sqlSelectListaMateriales.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectListaMateriales.Connection = this.sqlConn;
            this.sqlSelectListaMateriales.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@sIdMaterial", System.Data.SqlDbType.VarChar, 18),
            new System.Data.SqlClient.SqlParameter("@sMaterial", System.Data.SqlDbType.VarChar, 50),
            new System.Data.SqlClient.SqlParameter("@sCodNacional", System.Data.SqlDbType.VarChar, 6),
            new System.Data.SqlClient.SqlParameter("@fPrecio", System.Data.SqlDbType.Float, 8),
            new System.Data.SqlClient.SqlParameter("@sIdRed", System.Data.SqlDbType.VarChar, 4),
            new System.Data.SqlClient.SqlParameter("@iIdCamp", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@sidCampanya", System.Data.SqlDbType.VarChar, 10)});
            // 
            // sqldaListaCampanyas
            // 
            this.sqldaListaCampanyas.SelectCommand = this.sqlCmdListaCampanyasNEW;
            this.sqldaListaCampanyas.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaTipoCampPedido", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("idCampanya", "idCampanya"),
                        new System.Data.Common.DataColumnMapping("NombreCampanya", "NombreCampanya"),
                        new System.Data.Common.DataColumnMapping("bSeleccionable", "bSeleccionable"),
                        new System.Data.Common.DataColumnMapping("iNumMinOblis", "iNumMinOblis"),
                        new System.Data.Common.DataColumnMapping("fImporteMinObli", "fImporteMinObli"),
                        new System.Data.Common.DataColumnMapping("fDescImpNeto", "fDescImpNeto"),
                        new System.Data.Common.DataColumnMapping("bArrastre", "bArrastre"),
                        new System.Data.Common.DataColumnMapping("fDescMinGar", "fDescMinGar")})});
            // 
            // sqlCmdListaCampanyasNEW
            // 
            this.sqlCmdListaCampanyasNEW.CommandText = "ListaCampanyasVer";
            this.sqlCmdListaCampanyasNEW.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdListaCampanyasNEW.Connection = this.sqlConn;
            this.sqlCmdListaCampanyasNEW.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@sIdDelegado", System.Data.SqlDbType.VarChar, 4),
            new System.Data.SqlClient.SqlParameter("@sIdTipoPedido", System.Data.SqlDbType.VarChar, 4),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sIdMayorista", System.Data.SqlDbType.VarChar, 20)});
            // 
            // sqlCmdListaCampanyas
            // 
            this.sqlCmdListaCampanyas.CommandText = "ListaCampanyasSegunClienteYVisibles";
            this.sqlCmdListaCampanyas.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdListaCampanyas.Connection = this.sqlConn;
            this.sqlCmdListaCampanyas.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iTipo", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@idCampanya", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@tipoCampanya", System.Data.SqlDbType.VarChar, 3),
            new System.Data.SqlClient.SqlParameter("@sIdDelegado", System.Data.SqlDbType.VarChar, 4),
            new System.Data.SqlClient.SqlParameter("@sIdTipoPedido", System.Data.SqlDbType.VarChar, 4)});
            // 
            // sqldaListaLineasPedidoRentAnual
            // 
            this.sqldaListaLineasPedidoRentAnual.SelectCommand = this.sqlSelectLineasPedidoRentAnual;
            this.sqldaListaLineasPedidoRentAnual.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaLineasPedidoRentAnual", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("sCodSAP", "sCodSAP"),
                        new System.Data.Common.DataColumnMapping("dFecIni", "dFecIni"),
                        new System.Data.Common.DataColumnMapping("dFecFin", "dFecFin"),
                        new System.Data.Common.DataColumnMapping("fCoste", "fCoste"),
                        new System.Data.Common.DataColumnMapping("iCuenta", "iCuenta")})});
            // 
            // sqlSelectLineasPedidoRentAnual
            // 
            this.sqlSelectLineasPedidoRentAnual.CommandText = "[ListaLineasPedidoRentAnual]";
            this.sqlSelectLineasPedidoRentAnual.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectLineasPedidoRentAnual.Connection = this.sqlConn;
            this.sqlSelectLineasPedidoRentAnual.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4)});
            // 
            // dsPedidos1
            // 
            this.dsPedidos1.DataSetName = "dsPedidos";
            this.dsPedidos1.Locale = new System.Globalization.CultureInfo("en-US");
            this.dsPedidos1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cBoxCampanyas
            // 
            this.cBoxCampanyas.BackColor = System.Drawing.Color.White;
            this.cBoxCampanyas.DisplayMember = "NombreCampanya";
            this.cBoxCampanyas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxCampanyas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cBoxCampanyas.ForeColor = System.Drawing.Color.Black;
            this.cBoxCampanyas.Location = new System.Drawing.Point(473, 746);
            this.cBoxCampanyas.Name = "cBoxCampanyas";
            this.cBoxCampanyas.Size = new System.Drawing.Size(265, 21);
            this.cBoxCampanyas.TabIndex = 124;
            this.cBoxCampanyas.ValueMember = "idCampanya";
            this.cBoxCampanyas.Visible = false;
            // 
            // dsAccionesMarketing1
            // 
            this.dsAccionesMarketing1.DataSetName = "dsAccionesMarketing";
            this.dsAccionesMarketing1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dsFormularios1
            // 
            this.dsFormularios1.DataSetName = "dsFormularios";
            this.dsFormularios1.Locale = new System.Globalization.CultureInfo("es-ES");
            this.dsFormularios1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btExportar
            // 
            this.btExportar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btExportar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btExportar.ForeColor = System.Drawing.Color.Black;
            this.btExportar.Image = ((System.Drawing.Image)(resources.GetObject("btExportar.Image")));
            this.btExportar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btExportar.Location = new System.Drawing.Point(1303, 726);
            this.btExportar.Name = "btExportar";
            this.btExportar.Size = new System.Drawing.Size(174, 41);
            this.btExportar.TabIndex = 125;
            this.btExportar.Text = "&Exportar a Excel";
            this.btExportar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btExportar.UseVisualStyleBackColor = true;
            this.btExportar.Click += new System.EventHandler(this.btExportar_Click);
            // 
            // chkbMarcar
            // 
            this.chkbMarcar.AutoSize = true;
            this.chkbMarcar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkbMarcar.ForeColor = System.Drawing.Color.Black;
            this.chkbMarcar.Location = new System.Drawing.Point(24, 714);
            this.chkbMarcar.Name = "chkbMarcar";
            this.chkbMarcar.Size = new System.Drawing.Size(203, 24);
            this.chkbMarcar.TabIndex = 126;
            this.chkbMarcar.Text = "Marcar/Desmarcar todos";
            this.chkbMarcar.UseVisualStyleBackColor = true;
            this.chkbMarcar.CheckedChanged += new System.EventHandler(this.chkbMarcar_CheckedChanged);
            // 
            // txtRentAA
            // 
            this.txtRentAA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtRentAA.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtRentAA.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRentAA.Location = new System.Drawing.Point(1351, 93);
            this.txtRentAA.MaxLength = 50;
            this.txtRentAA.Name = "txtRentAA";
            this.txtRentAA.ReadOnly = true;
            this.txtRentAA.Size = new System.Drawing.Size(126, 26);
            this.txtRentAA.TabIndex = 128;
            this.txtRentAA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(1194, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(151, 24);
            this.label4.TabIndex = 129;
            this.label4.Text = "Rent. Año Actual:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // selected
            // 
            this.selected.FalseValue = "false";
            this.selected.HeaderText = "x";
            this.selected.Name = "selected";
            this.selected.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.selected.TrueValue = "true";
            this.selected.Width = 20;
            // 
            // Rentabilidad
            // 
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            this.Rentabilidad.DefaultCellStyle = dataGridViewCellStyle3;
            this.Rentabilidad.HeaderText = "Rent.";
            this.Rentabilidad.Name = "Rentabilidad";
            this.Rentabilidad.ReadOnly = true;
            this.Rentabilidad.Visible = false;
            this.Rentabilidad.Width = 60;
            // 
            // sCodNacional
            // 
            this.sCodNacional.DataPropertyName = "sCodNacional";
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            this.sCodNacional.DefaultCellStyle = dataGridViewCellStyle4;
            this.sCodNacional.HeaderText = "Cód. Nacional";
            this.sCodNacional.Name = "sCodNacional";
            this.sCodNacional.ReadOnly = true;
            this.sCodNacional.Width = 115;
            // 
            // sMaterial
            // 
            this.sMaterial.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.sMaterial.DataPropertyName = "sMaterial";
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            this.sMaterial.DefaultCellStyle = dataGridViewCellStyle5;
            this.sMaterial.HeaderText = "Descripción";
            this.sMaterial.Name = "sMaterial";
            this.sMaterial.ReadOnly = true;
            this.sMaterial.Width = 600;
            // 
            // sIdMaterial
            // 
            this.sIdMaterial.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.sIdMaterial.DataPropertyName = "sIdMaterial";
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            this.sIdMaterial.DefaultCellStyle = dataGridViewCellStyle6;
            this.sIdMaterial.HeaderText = "Material";
            this.sIdMaterial.Name = "sIdMaterial";
            this.sIdMaterial.ReadOnly = true;
            // 
            // fPrecio
            // 
            this.fPrecio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.fPrecio.DataPropertyName = "fPrecio";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.Format = "N2";
            this.fPrecio.DefaultCellStyle = dataGridViewCellStyle7;
            this.fPrecio.HeaderText = "Precio";
            this.fPrecio.Name = "fPrecio";
            this.fPrecio.ReadOnly = true;
            this.fPrecio.Width = 90;
            // 
            // cantidad
            // 
            this.cantidad.DataPropertyName = "cantidad";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.NullValue = "0";
            this.cantidad.DefaultCellStyle = dataGridViewCellStyle8;
            this.cantidad.HeaderText = "Cantidad";
            this.cantidad.Name = "cantidad";
            this.cantidad.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cantidad.Width = 90;
            // 
            // descmedio
            // 
            this.descmedio.DataPropertyName = "descmedio";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.Format = "N0";
            dataGridViewCellStyle9.NullValue = "0";
            this.descmedio.DefaultCellStyle = dataGridViewCellStyle9;
            this.descmedio.HeaderText = "Descuento";
            this.descmedio.Name = "descmedio";
            this.descmedio.ReadOnly = true;
            // 
            // iStock
            // 
            this.iStock.DataPropertyName = "iStock";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.Format = "N0";
            dataGridViewCellStyle10.NullValue = null;
            this.iStock.DefaultCellStyle = dataGridViewCellStyle10;
            this.iStock.HeaderText = "Stock";
            this.iStock.Name = "iStock";
            this.iStock.ReadOnly = true;
            this.iStock.Width = 90;
            // 
            // iUnidadesEnfajado
            // 
            this.iUnidadesEnfajado.DataPropertyName = "iUnidadesEnfajado";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black;
            this.iUnidadesEnfajado.DefaultCellStyle = dataGridViewCellStyle11;
            this.iUnidadesEnfajado.HeaderText = "Uni. Enfajado";
            this.iUnidadesEnfajado.Name = "iUnidadesEnfajado";
            this.iUnidadesEnfajado.ReadOnly = true;
            this.iUnidadesEnfajado.Width = 125;
            // 
            // iCajaCompleta
            // 
            this.iCajaCompleta.DataPropertyName = "iCajaCompleta";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black;
            this.iCajaCompleta.DefaultCellStyle = dataGridViewCellStyle12;
            this.iCajaCompleta.HeaderText = "Caja Completa";
            this.iCajaCompleta.Name = "iCajaCompleta";
            this.iCajaCompleta.ReadOnly = true;
            this.iCajaCompleta.Width = 125;
            // 
            // frmPropuestaPedido
            // 
            this.ClientSize = new System.Drawing.Size(1510, 787);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtRentAA);
            this.Controls.Add(this.chkbMarcar);
            this.Controls.Add(this.btExportar);
            this.Controls.Add(this.cBoxCampanyas);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.btAceptar);
            this.Controls.Add(this.pnBusqueda);
            this.Controls.Add(this.txbDto);
            this.Controls.Add(this.txbImporte);
            this.Controls.Add(this.lblImporte);
            this.Controls.Add(this.txbImporteBruto);
            this.Controls.Add(this.lblImporteBruto);
            this.Controls.Add(this.txbRentabilidad);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panelFiltros);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPropuestaPedido";
            this.Text = "Crear pedido a partir de los datos de los últimos pedidos realizados";
            this.Load += new System.EventHandler(this.frmPropuestaPedido_Load);
            this.panelFiltros.ResumeLayout(false);
            this.panelFiltros.PerformLayout();
            this.pnBusqueda.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMats)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsMateriales1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPedidos1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAccionesMarketing1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsFormularios1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelFiltros;
        private System.Windows.Forms.TextBox txtbCobertura;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtsIdCliente;
        private System.Windows.Forms.Button btBuscarCliente;
        private System.Windows.Forms.TextBox txtsCliente;
        private System.Windows.Forms.Label label9;
        private Controles.LabelGradient lblTitulo;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txbDto;
        private System.Windows.Forms.TextBox txbImporte;
        private System.Windows.Forms.Label lblImporte;
        private System.Windows.Forms.TextBox txbImporteBruto;
        private System.Windows.Forms.Label lblImporteBruto;
        private System.Windows.Forms.TextBox txbRentabilidad;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Data.SqlClient.SqlConnection sqlConn;
        private dsMateriales dsMateriales1;
        private System.Windows.Forms.Panel pnBusqueda;
        private System.Windows.Forms.DataGridView dgvMats;
        private System.Windows.Forms.Label lblNumReg;
        private Controles.LabelGradient labelGradient2;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.Button btAceptar;
        private DataSets.dsPedidos dsPedidos1;
        private System.Windows.Forms.ComboBox cBoxCampanyas;
        private DataSets.dsAccionesMarketing dsAccionesMarketing1;
        private dsFormularios dsFormularios1;
        private System.Windows.Forms.Label lblAvisoVersion;
        private System.Windows.Forms.Button btExportar;
        private System.Windows.Forms.CheckBox chkbMarcar;
        private System.Windows.Forms.TextBox txtRentAA;
        private dsMateriales.ListaLineasPedidoRentAnualDataTable dtLineasPedidoRentAnual;
        private System.Data.SqlClient.SqlDataAdapter sqldaListaLineasPedidoRentAnual;
        private System.Data.SqlClient.SqlCommand sqlSelectLineasPedidoRentAnual;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewCheckBoxColumn selected;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rentabilidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn sCodNacional;
        private System.Windows.Forms.DataGridViewTextBoxColumn sMaterial;
        private System.Windows.Forms.DataGridViewTextBoxColumn sIdMaterial;
        private System.Windows.Forms.DataGridViewTextBoxColumn fPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn descmedio;
        private System.Windows.Forms.DataGridViewTextBoxColumn iStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn iUnidadesEnfajado;
        private System.Windows.Forms.DataGridViewTextBoxColumn iCajaCompleta;
    }
}