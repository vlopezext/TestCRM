namespace GESTCRM.Formularios
{
    partial class frmConsultaVentas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsultaVentas));
            System.Configuration.AppSettingsReader configurationAppSettings = new System.Configuration.AppSettingsReader();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle33 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle34 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle29 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle30 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle31 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle32 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelFiltros = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.cbCrecimiento = new System.Windows.Forms.ComboBox();
            this.chkbAutoped = new System.Windows.Forms.CheckBox();
            this.chkbVClub = new System.Windows.Forms.CheckBox();
            this.chkbVTrans = new System.Windows.Forms.CheckBox();
            this.chkbVDir = new System.Windows.Forms.CheckBox();
            this.lblAvisoVersion = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbTotalVenta = new System.Windows.Forms.ComboBox();
            this.cbTipoMaterial = new System.Windows.Forms.ComboBox();
            this.listaTipoMaterialInformeBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dsMateriales1 = new GESTCRM.Formularios.dsMateriales();
            this.txtsIdCliente = new System.Windows.Forms.TextBox();
            this.btBuscarCliente = new System.Windows.Forms.Button();
            this.txtsCliente = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTitulo = new GESTCRM.Controles.LabelGradient();
            this.dtpFechaIni = new System.Windows.Forms.DateTimePicker();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblFechaPedido = new System.Windows.Forms.Label();
            this.sqlConn = new System.Data.SqlClient.SqlConnection();
            this.sqldaListaTipoMaterialInforme = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCmdListaTipoMaterialInforme = new System.Data.SqlClient.SqlCommand();
            this.sqldaInformeS = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCmdListaInformeS = new System.Data.SqlClient.SqlCommand();
            this.listaTipoMaterialInformeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pnVentas = new System.Windows.Forms.Panel();
            this.dGVVentas = new System.Windows.Forms.DataGridView();
            this.sCodNacional1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sMaterial1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalVenta1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ventasMes1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tendencia1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.directo1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.brutoD1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descMedioD1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transfer1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.brutoT1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descMedioT1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.club1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.brutoC1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descMedioC1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.autopedido1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.brutoA1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descMedioA1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblNumReg = new System.Windows.Forms.Label();
            this.labelGradient2 = new GESTCRM.Controles.LabelGradient();
            this.dsMateriales1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ucBotoneraSecundaria1 = new GESTCRM.Controles.ucBotoneraSecundaria();
            this.txtGarantias4 = new System.Windows.Forms.TextBox();
            this.txtGarantias3 = new System.Windows.Forms.TextBox();
            this.txtGarantias2 = new System.Windows.Forms.TextBox();
            this.txtGarantias1 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtGarantias = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.gbClubs = new System.Windows.Forms.GroupBox();
            this.panelFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listaTipoMaterialInformeBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsMateriales1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listaTipoMaterialInformeBindingSource)).BeginInit();
            this.pnVentas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVVentas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsMateriales1BindingSource)).BeginInit();
            this.gbClubs.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelFiltros
            // 
            this.panelFiltros.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelFiltros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelFiltros.Controls.Add(this.label2);
            this.panelFiltros.Controls.Add(this.cbCrecimiento);
            this.panelFiltros.Controls.Add(this.chkbAutoped);
            this.panelFiltros.Controls.Add(this.chkbVClub);
            this.panelFiltros.Controls.Add(this.chkbVTrans);
            this.panelFiltros.Controls.Add(this.chkbVDir);
            this.panelFiltros.Controls.Add(this.lblAvisoVersion);
            this.panelFiltros.Controls.Add(this.label1);
            this.panelFiltros.Controls.Add(this.label5);
            this.panelFiltros.Controls.Add(this.cbTotalVenta);
            this.panelFiltros.Controls.Add(this.cbTipoMaterial);
            this.panelFiltros.Controls.Add(this.txtsIdCliente);
            this.panelFiltros.Controls.Add(this.btBuscarCliente);
            this.panelFiltros.Controls.Add(this.txtsCliente);
            this.panelFiltros.Controls.Add(this.label9);
            this.panelFiltros.Controls.Add(this.dtpFechaFin);
            this.panelFiltros.Controls.Add(this.label4);
            this.panelFiltros.Controls.Add(this.lblTitulo);
            this.panelFiltros.Controls.Add(this.dtpFechaIni);
            this.panelFiltros.Controls.Add(this.btnBuscar);
            this.panelFiltros.Controls.Add(this.lblFechaPedido);
            this.panelFiltros.Location = new System.Drawing.Point(4, 40);
            this.panelFiltros.Name = "panelFiltros";
            this.panelFiltros.Size = new System.Drawing.Size(932, 97);
            this.panelFiltros.TabIndex = 27;
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(665, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 18);
            this.label2.TabIndex = 134;
            this.label2.Text = "Crecimiento:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbCrecimiento
            // 
            this.cbCrecimiento.Items.AddRange(new object[] {
            "Todos",
            "Positivo",
            "Negativo",
            "Igual"});
            this.cbCrecimiento.Location = new System.Drawing.Point(733, 63);
            this.cbCrecimiento.Name = "cbCrecimiento";
            this.cbCrecimiento.Size = new System.Drawing.Size(107, 21);
            this.cbCrecimiento.TabIndex = 133;
            // 
            // chkbAutoped
            // 
            this.chkbAutoped.AutoSize = true;
            this.chkbAutoped.ForeColor = System.Drawing.Color.Black;
            this.chkbAutoped.Location = new System.Drawing.Point(540, 65);
            this.chkbAutoped.Name = "chkbAutoped";
            this.chkbAutoped.Size = new System.Drawing.Size(116, 17);
            this.chkbAutoped.TabIndex = 132;
            this.chkbAutoped.Text = "Ventas Autopedido";
            this.chkbAutoped.UseVisualStyleBackColor = true;
            // 
            // chkbVClub
            // 
            this.chkbVClub.AutoSize = true;
            this.chkbVClub.ForeColor = System.Drawing.Color.Black;
            this.chkbVClub.Location = new System.Drawing.Point(452, 65);
            this.chkbVClub.Name = "chkbVClub";
            this.chkbVClub.Size = new System.Drawing.Size(83, 17);
            this.chkbVClub.TabIndex = 131;
            this.chkbVClub.Text = "Ventas Club";
            this.chkbVClub.UseVisualStyleBackColor = true;
            // 
            // chkbVTrans
            // 
            this.chkbVTrans.AutoSize = true;
            this.chkbVTrans.ForeColor = System.Drawing.Color.Black;
            this.chkbVTrans.Location = new System.Drawing.Point(352, 65);
            this.chkbVTrans.Name = "chkbVTrans";
            this.chkbVTrans.Size = new System.Drawing.Size(96, 17);
            this.chkbVTrans.TabIndex = 130;
            this.chkbVTrans.Text = "Ventas Tranfer";
            this.chkbVTrans.UseVisualStyleBackColor = true;
            // 
            // chkbVDir
            // 
            this.chkbVDir.AutoSize = true;
            this.chkbVDir.ForeColor = System.Drawing.Color.Black;
            this.chkbVDir.Location = new System.Drawing.Point(252, 65);
            this.chkbVDir.Name = "chkbVDir";
            this.chkbVDir.Size = new System.Drawing.Size(96, 17);
            this.chkbVDir.TabIndex = 129;
            this.chkbVDir.Text = "Ventas Directo";
            this.chkbVDir.UseVisualStyleBackColor = true;
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
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(643, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 18);
            this.label1.TabIndex = 122;
            this.label1.Text = "Total Venta:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Visible = false;
            // 
            // label5
            // 
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(17, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 18);
            this.label5.TabIndex = 120;
            this.label5.Text = "Tipo Material:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbTotalVenta
            // 
            this.cbTotalVenta.Items.AddRange(new object[] {
            "Todos",
            "Sin Ventas",
            "Con Ventas"});
            this.cbTotalVenta.Location = new System.Drawing.Point(718, 8);
            this.cbTotalVenta.Name = "cbTotalVenta";
            this.cbTotalVenta.Size = new System.Drawing.Size(122, 21);
            this.cbTotalVenta.TabIndex = 121;
            this.cbTotalVenta.Visible = false;
            // 
            // cbTipoMaterial
            // 
            this.cbTipoMaterial.DataSource = this.listaTipoMaterialInformeBindingSource1;
            this.cbTipoMaterial.DisplayMember = "sLiteral";
            this.cbTipoMaterial.Location = new System.Drawing.Point(89, 61);
            this.cbTipoMaterial.Name = "cbTipoMaterial";
            this.cbTipoMaterial.Size = new System.Drawing.Size(149, 21);
            this.cbTipoMaterial.TabIndex = 119;
            this.cbTipoMaterial.ValueMember = "sValor";
            // 
            // listaTipoMaterialInformeBindingSource1
            // 
            this.listaTipoMaterialInformeBindingSource1.DataMember = "ListaTipoMaterialInforme";
            this.listaTipoMaterialInformeBindingSource1.DataSource = this.dsMateriales1;
            // 
            // dsMateriales1
            // 
            this.dsMateriales1.DataSetName = "dsMateriales";
            this.dsMateriales1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // txtsIdCliente
            // 
            this.txtsIdCliente.BackColor = System.Drawing.Color.White;
            this.txtsIdCliente.ForeColor = System.Drawing.Color.Black;
            this.txtsIdCliente.Location = new System.Drawing.Point(66, 35);
            this.txtsIdCliente.MaxLength = 20;
            this.txtsIdCliente.Name = "txtsIdCliente";
            this.txtsIdCliente.Size = new System.Drawing.Size(128, 20);
            this.txtsIdCliente.TabIndex = 115;
            // 
            // btBuscarCliente
            // 
            this.btBuscarCliente.Image = ((System.Drawing.Image)(resources.GetObject("btBuscarCliente.Image")));
            this.btBuscarCliente.Location = new System.Drawing.Point(530, 34);
            this.btBuscarCliente.Name = "btBuscarCliente";
            this.btBuscarCliente.Size = new System.Drawing.Size(22, 22);
            this.btBuscarCliente.TabIndex = 117;
            this.btBuscarCliente.TabStop = false;
            this.btBuscarCliente.UseVisualStyleBackColor = true;
            this.btBuscarCliente.Click += new System.EventHandler(this.btBuscarCliente_Click);
            // 
            // txtsCliente
            // 
            this.txtsCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtsCliente.ForeColor = System.Drawing.Color.Black;
            this.txtsCliente.Location = new System.Drawing.Point(194, 35);
            this.txtsCliente.Name = "txtsCliente";
            this.txtsCliente.ReadOnly = true;
            this.txtsCliente.Size = new System.Drawing.Size(336, 20);
            this.txtsCliente.TabIndex = 116;
            this.txtsCliente.TabStop = false;
            // 
            // label9
            // 
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(17, 37);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 16);
            this.label9.TabIndex = 118;
            this.label9.Text = "Cliente:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Checked = false;
            this.dtpFechaFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new System.Drawing.Point(760, 36);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(96, 20);
            this.dtpFechaFin.TabIndex = 1;
            this.dtpFechaFin.ValueChanged += new System.EventHandler(this.dtpFechaFin_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(744, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(12, 13);
            this.label4.TabIndex = 97;
            this.label4.Text = "y";
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
            this.lblTitulo.Size = new System.Drawing.Size(930, 22);
            this.lblTitulo.TabIndex = 92;
            this.lblTitulo.Text = "Consulta datos de ventas de farmacia";
            // 
            // dtpFechaIni
            // 
            this.dtpFechaIni.Checked = false;
            this.dtpFechaIni.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.dtpFechaIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaIni.Location = new System.Drawing.Point(644, 36);
            this.dtpFechaIni.Name = "dtpFechaIni";
            this.dtpFechaIni.Size = new System.Drawing.Size(96, 20);
            this.dtpFechaIni.TabIndex = 0;
            this.dtpFechaIni.Value = new System.DateTime(2009, 4, 21, 0, 0, 0, 0);
            this.dtpFechaIni.ValueChanged += new System.EventHandler(this.dtpFechaIni_ValueChanged);
            // 
            // btnBuscar
            // 
            this.btnBuscar.ForeColor = System.Drawing.Color.Black;
            this.btnBuscar.Location = new System.Drawing.Point(858, 61);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(64, 24);
            this.btnBuscar.TabIndex = 12;
            this.btnBuscar.Text = "&Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lblFechaPedido
            // 
            this.lblFechaPedido.AutoSize = true;
            this.lblFechaPedido.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblFechaPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblFechaPedido.ForeColor = System.Drawing.Color.Black;
            this.lblFechaPedido.Location = new System.Drawing.Point(567, 39);
            this.lblFechaPedido.Name = "lblFechaPedido";
            this.lblFechaPedido.Size = new System.Drawing.Size(75, 13);
            this.lblFechaPedido.TabIndex = 21;
            this.lblFechaPedido.Text = "Período entre:";
            // 
            // sqlConn
            // 
            //this.sqlConn.ConnectionString = ((string)(configurationAppSettings.GetValue("sConn", typeof(string))));//---- GSG (10/09/2014)
            this.sqlConn = Utiles._connection;
            this.sqlConn.FireInfoMessageEventOnUserErrors = false;
            // 
            // sqldaListaTipoMaterialInforme
            // 
            this.sqldaListaTipoMaterialInforme.SelectCommand = this.sqlCmdListaTipoMaterialInforme;
            this.sqldaListaTipoMaterialInforme.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaTipoMaterialInforme", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("sValor", "sValor"),
                        new System.Data.Common.DataColumnMapping("sLiteral", "sLiteral")})});
            // 
            // sqlCmdListaTipoMaterialInforme
            // 
            this.sqlCmdListaTipoMaterialInforme.CommandText = "[ListaTipoMaterialInforme]";
            this.sqlCmdListaTipoMaterialInforme.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdListaTipoMaterialInforme.Connection = this.sqlConn;
            this.sqlCmdListaTipoMaterialInforme.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null)});
            // 
            // sqldaInformeS
            // 
            this.sqldaInformeS.SelectCommand = this.sqlCmdListaInformeS;
            this.sqldaInformeS.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaInformeS", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("sCodNacional", "sCodNacional"),
                        new System.Data.Common.DataColumnMapping("sMaterial", "sMaterial"),
                        new System.Data.Common.DataColumnMapping("Directo", "Directo"),
                        new System.Data.Common.DataColumnMapping("BrutoD", "BrutoD"),
                        new System.Data.Common.DataColumnMapping("DescMedioD", "DescMedioD"),
                        new System.Data.Common.DataColumnMapping("Transfer", "Transfer"),
                        new System.Data.Common.DataColumnMapping("BrutoT", "BrutoT"),
                        new System.Data.Common.DataColumnMapping("DescMedioT", "DescMedioT"),
                        new System.Data.Common.DataColumnMapping("Club", "Club"),
                        new System.Data.Common.DataColumnMapping("BrutoC", "BrutoC"),
                        new System.Data.Common.DataColumnMapping("DescMedioC", "DescMedioC"),
                        new System.Data.Common.DataColumnMapping("Autopedido", "Autopedido"),
                        new System.Data.Common.DataColumnMapping("BrutoA", "BrutoA"),
                        new System.Data.Common.DataColumnMapping("DescMedioA", "DescMedioA"),
                        new System.Data.Common.DataColumnMapping("totalVenta", "totalVenta")})});
            // 
            // sqlCmdListaInformeS
            // 
            this.sqlCmdListaInformeS.CommandText = "[ListaInformeS]";
            this.sqlCmdListaInformeS.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdListaInformeS.Connection = this.sqlConn;
            this.sqlCmdListaInformeS.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@dFechaIni", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@dFechaFin", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@sTipoMatInformes", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@iConVentas", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iConVentasDir", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iConVentasTrans", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iConVentasAutoped", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iConVentasClub", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sTendencia", System.Data.SqlDbType.VarChar, 1)});
            // 
            // listaTipoMaterialInformeBindingSource
            // 
            this.listaTipoMaterialInformeBindingSource.DataMember = "ListaTipoMaterialInforme";
            this.listaTipoMaterialInformeBindingSource.DataSource = this.dsMateriales1;
            // 
            // pnVentas
            // 
            this.pnVentas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnVentas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnVentas.Controls.Add(this.dGVVentas);
            this.pnVentas.Controls.Add(this.lblNumReg);
            this.pnVentas.Controls.Add(this.labelGradient2);
            this.pnVentas.Location = new System.Drawing.Point(3, 177);
            this.pnVentas.Name = "pnVentas";
            this.pnVentas.Size = new System.Drawing.Size(934, 489);
            this.pnVentas.TabIndex = 28;
            // 
            // dGVVentas
            // 
            this.dGVVentas.AllowUserToAddRows = false;
            this.dGVVentas.AllowUserToDeleteRows = false;
            this.dGVVentas.AutoGenerateColumns = false;
            this.dGVVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVVentas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sCodNacional1,
            this.sMaterial1,
            this.totalVenta1,
            this.ventasMes1,
            this.tendencia1,
            this.directo1,
            this.brutoD1,
            this.descMedioD1,
            this.transfer1,
            this.brutoT1,
            this.descMedioT1,
            this.club1,
            this.brutoC1,
            this.descMedioC1,
            this.autopedido1,
            this.brutoA1,
            this.descMedioA1});
            this.dGVVentas.DataMember = "ListaInformeS";
            this.dGVVentas.DataSource = this.dsMateriales1;
            dataGridViewCellStyle33.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle33.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle33.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle33.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle33.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle33.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle33.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dGVVentas.DefaultCellStyle = dataGridViewCellStyle33;
            this.dGVVentas.GridColor = System.Drawing.SystemColors.ControlLight;
            this.dGVVentas.Location = new System.Drawing.Point(1, 20);
            this.dGVVentas.Name = "dGVVentas";
            this.dGVVentas.ReadOnly = true;
            this.dGVVentas.RowHeadersWidth = 15;
            dataGridViewCellStyle34.ForeColor = System.Drawing.Color.Black;
            this.dGVVentas.RowsDefaultCellStyle = dataGridViewCellStyle34;
            this.dGVVentas.Size = new System.Drawing.Size(929, 502);
            this.dGVVentas.TabIndex = 97;
            this.dGVVentas.DoubleClick += new System.EventHandler(this.dGVVentas_DoubleClick);
            // 
            // sCodNacional1
            // 
            this.sCodNacional1.DataPropertyName = "sCodNacional";
            this.sCodNacional1.Frozen = true;
            this.sCodNacional1.HeaderText = "C. Nacional";
            this.sCodNacional1.Name = "sCodNacional1";
            this.sCodNacional1.ReadOnly = true;
            this.sCodNacional1.Width = 90;
            // 
            // sMaterial1
            // 
            this.sMaterial1.DataPropertyName = "sMaterial";
            this.sMaterial1.Frozen = true;
            this.sMaterial1.HeaderText = "Descripción";
            this.sMaterial1.Name = "sMaterial1";
            this.sMaterial1.ReadOnly = true;
            this.sMaterial1.Width = 200;
            // 
            // totalVenta1
            // 
            this.totalVenta1.DataPropertyName = "totalVenta";
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle18.Format = "N0";
            dataGridViewCellStyle18.NullValue = "0";
            this.totalVenta1.DefaultCellStyle = dataGridViewCellStyle18;
            this.totalVenta1.HeaderText = "Total Ventas";
            this.totalVenta1.Name = "totalVenta1";
            this.totalVenta1.ReadOnly = true;
            this.totalVenta1.Width = 95;
            // 
            // ventasMes1
            // 
            this.ventasMes1.DataPropertyName = "VentasMes";
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle19.Format = "N2";
            dataGridViewCellStyle19.NullValue = "0";
            this.ventasMes1.DefaultCellStyle = dataGridViewCellStyle19;
            this.ventasMes1.HeaderText = "Ventas/Mes";
            this.ventasMes1.Name = "ventasMes1";
            this.ventasMes1.ReadOnly = true;
            this.ventasMes1.Width = 80;
            // 
            // tendencia1
            // 
            this.tendencia1.DataPropertyName = "Tendencia";
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle20.NullValue = "=";
            this.tendencia1.DefaultCellStyle = dataGridViewCellStyle20;
            this.tendencia1.HeaderText = "Crecimiento";
            this.tendencia1.Name = "tendencia1";
            this.tendencia1.ReadOnly = true;
            this.tendencia1.Width = 80;
            // 
            // directo1
            // 
            this.directo1.DataPropertyName = "Directo";
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle21.Format = "N0";
            dataGridViewCellStyle21.NullValue = "0";
            this.directo1.DefaultCellStyle = dataGridViewCellStyle21;
            this.directo1.HeaderText = "Directo";
            this.directo1.Name = "directo1";
            this.directo1.ReadOnly = true;
            this.directo1.Width = 80;
            // 
            // brutoD1
            // 
            this.brutoD1.DataPropertyName = "BrutoD";
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle22.Format = "N2";
            dataGridViewCellStyle22.NullValue = "0";
            this.brutoD1.DefaultCellStyle = dataGridViewCellStyle22;
            this.brutoD1.HeaderText = "bruto D";
            this.brutoD1.Name = "brutoD1";
            this.brutoD1.ReadOnly = true;
            this.brutoD1.Width = 80;
            // 
            // descMedioD1
            // 
            this.descMedioD1.DataPropertyName = "DescMedioD";
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle23.Format = "N2";
            dataGridViewCellStyle23.NullValue = "0";
            this.descMedioD1.DefaultCellStyle = dataGridViewCellStyle23;
            this.descMedioD1.HeaderText = "% dto D";
            this.descMedioD1.Name = "descMedioD1";
            this.descMedioD1.ReadOnly = true;
            this.descMedioD1.Width = 70;
            // 
            // transfer1
            // 
            this.transfer1.DataPropertyName = "Transfer";
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle24.Format = "N0";
            dataGridViewCellStyle24.NullValue = "0";
            this.transfer1.DefaultCellStyle = dataGridViewCellStyle24;
            this.transfer1.HeaderText = "Transfer";
            this.transfer1.Name = "transfer1";
            this.transfer1.ReadOnly = true;
            this.transfer1.Width = 80;
            // 
            // brutoT1
            // 
            this.brutoT1.DataPropertyName = "BrutoT";
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle25.Format = "N2";
            dataGridViewCellStyle25.NullValue = "0";
            this.brutoT1.DefaultCellStyle = dataGridViewCellStyle25;
            this.brutoT1.HeaderText = "bruto T";
            this.brutoT1.Name = "brutoT1";
            this.brutoT1.ReadOnly = true;
            this.brutoT1.Width = 80;
            // 
            // descMedioT1
            // 
            this.descMedioT1.DataPropertyName = "DescMedioT";
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle26.Format = "N2";
            dataGridViewCellStyle26.NullValue = "0";
            this.descMedioT1.DefaultCellStyle = dataGridViewCellStyle26;
            this.descMedioT1.HeaderText = "% dto T";
            this.descMedioT1.Name = "descMedioT1";
            this.descMedioT1.ReadOnly = true;
            this.descMedioT1.Width = 70;
            // 
            // club1
            // 
            this.club1.DataPropertyName = "Club";
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle27.Format = "N0";
            dataGridViewCellStyle27.NullValue = "0";
            this.club1.DefaultCellStyle = dataGridViewCellStyle27;
            this.club1.HeaderText = "Club";
            this.club1.Name = "club1";
            this.club1.ReadOnly = true;
            this.club1.Width = 80;
            // 
            // brutoC1
            // 
            this.brutoC1.DataPropertyName = "BrutoC";
            dataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle28.Format = "N2";
            dataGridViewCellStyle28.NullValue = "0";
            this.brutoC1.DefaultCellStyle = dataGridViewCellStyle28;
            this.brutoC1.HeaderText = "bruto C";
            this.brutoC1.Name = "brutoC1";
            this.brutoC1.ReadOnly = true;
            this.brutoC1.Width = 80;
            // 
            // descMedioC1
            // 
            this.descMedioC1.DataPropertyName = "DescMedioC";
            dataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle29.Format = "N2";
            dataGridViewCellStyle29.NullValue = "0";
            this.descMedioC1.DefaultCellStyle = dataGridViewCellStyle29;
            this.descMedioC1.HeaderText = "% dto C";
            this.descMedioC1.Name = "descMedioC1";
            this.descMedioC1.ReadOnly = true;
            this.descMedioC1.Width = 70;
            // 
            // autopedido1
            // 
            this.autopedido1.DataPropertyName = "Autopedido";
            dataGridViewCellStyle30.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle30.Format = "N0";
            dataGridViewCellStyle30.NullValue = "0";
            this.autopedido1.DefaultCellStyle = dataGridViewCellStyle30;
            this.autopedido1.HeaderText = "Autopedido";
            this.autopedido1.Name = "autopedido1";
            this.autopedido1.ReadOnly = true;
            this.autopedido1.Width = 80;
            // 
            // brutoA1
            // 
            this.brutoA1.DataPropertyName = "BrutoA";
            dataGridViewCellStyle31.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle31.Format = "N2";
            dataGridViewCellStyle31.NullValue = "0";
            this.brutoA1.DefaultCellStyle = dataGridViewCellStyle31;
            this.brutoA1.HeaderText = "bruto A";
            this.brutoA1.Name = "brutoA1";
            this.brutoA1.ReadOnly = true;
            this.brutoA1.Width = 80;
            // 
            // descMedioA1
            // 
            this.descMedioA1.DataPropertyName = "DescMedioA";
            dataGridViewCellStyle32.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle32.Format = "N2";
            dataGridViewCellStyle32.NullValue = "0";
            this.descMedioA1.DefaultCellStyle = dataGridViewCellStyle32;
            this.descMedioA1.HeaderText = "% dto A";
            this.descMedioA1.Name = "descMedioA1";
            this.descMedioA1.ReadOnly = true;
            this.descMedioA1.Width = 70;
            // 
            // lblNumReg
            // 
            this.lblNumReg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.lblNumReg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblNumReg.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumReg.ForeColor = System.Drawing.Color.Black;
            this.lblNumReg.Location = new System.Drawing.Point(870, 0);
            this.lblNumReg.Name = "lblNumReg";
            this.lblNumReg.Size = new System.Drawing.Size(60, 18);
            this.lblNumReg.TabIndex = 96;
            this.lblNumReg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelGradient2
            // 
            this.labelGradient2.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelGradient2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGradient2.ForeColor = System.Drawing.Color.White;
            this.labelGradient2.GradientColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.labelGradient2.GradientColorTwo = System.Drawing.Color.White;
            this.labelGradient2.Location = new System.Drawing.Point(0, 0);
            this.labelGradient2.Name = "labelGradient2";
            this.labelGradient2.Size = new System.Drawing.Size(930, 18);
            this.labelGradient2.TabIndex = 92;
            this.labelGradient2.Text = "Ventas Cliente";
            this.labelGradient2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dsMateriales1BindingSource
            // 
            this.dsMateriales1BindingSource.DataSource = this.dsMateriales1;
            this.dsMateriales1BindingSource.Position = 0;
            // 
            // ucBotoneraSecundaria1
            // 
            this.ucBotoneraSecundaria1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(117)))), ((int)(((byte)(1)))));
            this.ucBotoneraSecundaria1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucBotoneraSecundaria1.ForeColor = System.Drawing.Color.Black;
            this.ucBotoneraSecundaria1.Location = new System.Drawing.Point(0, 0);
            this.ucBotoneraSecundaria1.Name = "ucBotoneraSecundaria1";
            this.ucBotoneraSecundaria1.Size = new System.Drawing.Size(942, 38);
            this.ucBotoneraSecundaria1.TabIndex = 29;
            // 
            // txtGarantias4
            // 
            this.txtGarantias4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtGarantias4.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtGarantias4.Location = new System.Drawing.Point(769, 12);
            this.txtGarantias4.Name = "txtGarantias4";
            this.txtGarantias4.ReadOnly = true;
            this.txtGarantias4.Size = new System.Drawing.Size(120, 20);
            this.txtGarantias4.TabIndex = 117;
            this.txtGarantias4.TabStop = false;
            // 
            // txtGarantias3
            // 
            this.txtGarantias3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtGarantias3.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtGarantias3.Location = new System.Drawing.Point(595, 12);
            this.txtGarantias3.Name = "txtGarantias3";
            this.txtGarantias3.ReadOnly = true;
            this.txtGarantias3.Size = new System.Drawing.Size(120, 20);
            this.txtGarantias3.TabIndex = 116;
            this.txtGarantias3.TabStop = false;
            // 
            // txtGarantias2
            // 
            this.txtGarantias2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtGarantias2.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtGarantias2.Location = new System.Drawing.Point(422, 12);
            this.txtGarantias2.Name = "txtGarantias2";
            this.txtGarantias2.ReadOnly = true;
            this.txtGarantias2.Size = new System.Drawing.Size(120, 20);
            this.txtGarantias2.TabIndex = 115;
            this.txtGarantias2.TabStop = false;
            // 
            // txtGarantias1
            // 
            this.txtGarantias1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtGarantias1.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtGarantias1.Location = new System.Drawing.Point(250, 12);
            this.txtGarantias1.Name = "txtGarantias1";
            this.txtGarantias1.ReadOnly = true;
            this.txtGarantias1.Size = new System.Drawing.Size(120, 20);
            this.txtGarantias1.TabIndex = 114;
            this.txtGarantias1.TabStop = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(724, 12);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(42, 15);
            this.label12.TabIndex = 113;
            this.label12.Text = "Club4:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(550, 12);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(42, 15);
            this.label11.TabIndex = 112;
            this.label11.Text = "Club3:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(377, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 15);
            this.label8.TabIndex = 111;
            this.label8.Text = "Club2:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(205, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 15);
            this.label7.TabIndex = 110;
            this.label7.Text = "Club1:";
            // 
            // txtGarantias
            // 
            this.txtGarantias.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtGarantias.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtGarantias.Location = new System.Drawing.Point(73, 12);
            this.txtGarantias.Name = "txtGarantias";
            this.txtGarantias.ReadOnly = true;
            this.txtGarantias.Size = new System.Drawing.Size(120, 20);
            this.txtGarantias.TabIndex = 109;
            this.txtGarantias.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(29, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 15);
            this.label3.TabIndex = 108;
            this.label3.Text = "Club0:";
            // 
            // gbClubs
            // 
            this.gbClubs.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gbClubs.Controls.Add(this.txtGarantias4);
            this.gbClubs.Controls.Add(this.txtGarantias3);
            this.gbClubs.Controls.Add(this.label3);
            this.gbClubs.Controls.Add(this.txtGarantias2);
            this.gbClubs.Controls.Add(this.txtGarantias);
            this.gbClubs.Controls.Add(this.txtGarantias1);
            this.gbClubs.Controls.Add(this.label7);
            this.gbClubs.Controls.Add(this.label12);
            this.gbClubs.Controls.Add(this.label8);
            this.gbClubs.Controls.Add(this.label11);
            this.gbClubs.ForeColor = System.Drawing.Color.Black;
            this.gbClubs.Location = new System.Drawing.Point(5, 137);
            this.gbClubs.Margin = new System.Windows.Forms.Padding(0);
            this.gbClubs.Name = "gbClubs";
            this.gbClubs.Padding = new System.Windows.Forms.Padding(0);
            this.gbClubs.Size = new System.Drawing.Size(929, 37);
            this.gbClubs.TabIndex = 118;
            this.gbClubs.TabStop = false;
            // 
            // frmConsultaVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(942, 670);
            this.Controls.Add(this.gbClubs);
            this.Controls.Add(this.ucBotoneraSecundaria1);
            this.Controls.Add(this.pnVentas);
            this.Controls.Add(this.panelFiltros);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmConsultaVentas";
            this.Text = "Consulta Datos Ventas Farmacia";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmConsultaVentas_Load);
            this.panelFiltros.ResumeLayout(false);
            this.panelFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listaTipoMaterialInformeBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsMateriales1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listaTipoMaterialInformeBindingSource)).EndInit();
            this.pnVentas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGVVentas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsMateriales1BindingSource)).EndInit();
            this.gbClubs.ResumeLayout(false);
            this.gbClubs.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelFiltros;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.Label label4;
        private Controles.LabelGradient lblTitulo;
        private System.Windows.Forms.DateTimePicker dtpFechaIni;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lblFechaPedido;
        private System.Windows.Forms.TextBox txtsIdCliente;
        private System.Windows.Forms.Button btBuscarCliente;
        private System.Windows.Forms.TextBox txtsCliente;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbTipoMaterial;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbTotalVenta;
        private System.Windows.Forms.Label label1;
        private dsMateriales dsMateriales1;
        private System.Windows.Forms.BindingSource listaTipoMaterialInformeBindingSource;
        private System.Windows.Forms.Panel pnVentas;
        private System.Windows.Forms.Label lblNumReg;
        private Controles.LabelGradient labelGradient2;
        private System.Windows.Forms.BindingSource dsMateriales1BindingSource;
        private Controles.ucBotoneraSecundaria ucBotoneraSecundaria1;
        private System.Windows.Forms.Label lblAvisoVersion;
        private System.Windows.Forms.CheckBox chkbVClub;
        private System.Windows.Forms.CheckBox chkbVTrans;
        private System.Windows.Forms.CheckBox chkbVDir;
        private System.Windows.Forms.CheckBox chkbAutoped;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbCrecimiento;
        private System.Windows.Forms.BindingSource listaTipoMaterialInformeBindingSource1;
        private System.Windows.Forms.DataGridView dGVVentas;
        private System.Windows.Forms.DataGridViewTextBoxColumn sCodNacional1;
        private System.Windows.Forms.DataGridViewTextBoxColumn sMaterial1;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalVenta1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ventasMes1;
        private System.Windows.Forms.DataGridViewTextBoxColumn tendencia1;
        private System.Windows.Forms.DataGridViewTextBoxColumn directo1;
        private System.Windows.Forms.DataGridViewTextBoxColumn brutoD1;
        private System.Windows.Forms.DataGridViewTextBoxColumn descMedioD1;
        private System.Windows.Forms.DataGridViewTextBoxColumn transfer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn brutoT1;
        private System.Windows.Forms.DataGridViewTextBoxColumn descMedioT1;
        private System.Windows.Forms.DataGridViewTextBoxColumn club1;
        private System.Windows.Forms.DataGridViewTextBoxColumn brutoC1;
        private System.Windows.Forms.DataGridViewTextBoxColumn descMedioC1;
        private System.Windows.Forms.DataGridViewTextBoxColumn autopedido1;
        private System.Windows.Forms.DataGridViewTextBoxColumn brutoA1;
        private System.Windows.Forms.DataGridViewTextBoxColumn descMedioA1;
        private System.Windows.Forms.TextBox txtGarantias4;
        private System.Windows.Forms.TextBox txtGarantias3;
        private System.Windows.Forms.TextBox txtGarantias2;
        private System.Windows.Forms.TextBox txtGarantias1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtGarantias;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox gbClubs;
       

    }
}