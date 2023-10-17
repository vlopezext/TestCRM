namespace GESTCRM.Formularios
{
    partial class frmAutopedAccMark
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAutopedAccMark));
            System.Configuration.AppSettingsReader configurationAppSettings = new System.Configuration.AppSettingsReader();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle67 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle68 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle71 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle72 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle69 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle70 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle73 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle74 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle77 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle78 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle75 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle76 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle79 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle80 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle82 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle83 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle81 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle84 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle85 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle87 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle88 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle86 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelFiltros = new System.Windows.Forms.Panel();
            this.lblAvisoVersion = new System.Windows.Forms.Label();
            this.txtsIdCliente = new System.Windows.Forms.TextBox();
            this.btBuscarCliente = new System.Windows.Forms.Button();
            this.txtsCliente = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lblTitulo = new GESTCRM.Controles.LabelGradient();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.sqlConn = new System.Data.SqlClient.SqlConnection();
            this.sqldaListaAccionesMarketing = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCmdListaAccionesMarketing = new System.Data.SqlClient.SqlCommand();
            this.sqldaListaAutoPedsSinAccMark = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCmdListaAutoPedsSinAccMark = new System.Data.SqlClient.SqlCommand();
            this.sqldaListaLinsAutoPedsSinAccMark = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCmdListaLinsAutoPedsSinAccMark = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdGetRentabilidadColor = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdGetMaterialesNoRentabilidad = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdGetCampanyasNoRentabilidad = new System.Data.SqlClient.SqlCommand();
            this.dsFormularios1 = new GESTCRM.Formularios.dsFormularios();
            this.sqldaListaImportes = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCmdListaImportesClientesSAPConAutopedsSinAccMark = new System.Data.SqlClient.SqlCommand();
            this.sqldaListaAsignaciones = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCmdListaAsignacionesAutopedsSinAccMark = new System.Data.SqlClient.SqlCommand();
            this.sqlGetNumAcckMarkADescartar = new System.Data.SqlClient.SqlCommand();
            this.sqlGetNewIdGrupoAutoPedAcciones = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdSetAutoPedAcciones = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdSetPedAcciones = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdMaxAccMark = new System.Data.SqlClient.SqlCommand();
            //---- GSG (06/03/2021)
            this.sqldaCodsAccMark = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCmdListaCodsAccMark = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdSetPedidosCab = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdSetPedidosLin = new System.Data.SqlClient.SqlCommand();
            this.sqldaCodsAccMarkPicking = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCmdListaCodsAccMarkPicking = new System.Data.SqlClient.SqlCommand();


            this.pnBusqueda = new System.Windows.Forms.Panel();
            this.dgvPeds = new System.Windows.Forms.DataGridView();
            this.sIdPedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dFechaPedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fImporteBruto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fImporteNeto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsAccMark = new GESTCRM.Formularios.DataSets.dsAccionesMarketing();
            this.lblNumReg = new System.Windows.Forms.Label();
            this.labelGradient2 = new GESTCRM.Controles.LabelGradient();
            this.dsPedidos1 = new GESTCRM.Formularios.DataSets.dsPedidos();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblNumRegAccMark = new System.Windows.Forms.Label();
            this.labelGradientAccMark = new GESTCRM.Controles.LabelGradient();
            this.dataGridViewAccMark = new System.Windows.Forms.DataGridView();
            this.selected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.fImpMax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iMaxAEntregar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fCosteTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iIdAccionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sIdAccionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sDescAccionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sIdTipoAccionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iUnidadesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iNumElemEntregarDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fCosteTotalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dFechaCreacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dFechaIniDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dFechaFinDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sObservacionesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sIdTipoImputacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dFUMDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iEstadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bEnviadoPDADataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.UnidadesAEntregar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fImpMin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sIdProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fCosteUnitarioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bIndepe = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.fRentabilidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bSuma = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.sqldaAccMarkExcluidas = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCmdAccMarkExcluidas = new System.Data.SqlClient.SqlCommand();
            this.btCancelar = new System.Windows.Forms.Button();
            this.btAceptar = new System.Windows.Forms.Button();
            this.tabControlX = new System.Windows.Forms.TabControl();
            this.tabPageConsultaImportes = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblNumImportes = new System.Windows.Forms.Label();
            this.labelGradient3 = new GESTCRM.Controles.LabelGradient();
            this.dataGridViewImportes = new System.Windows.Forms.DataGridView();
            this.iIdDelegadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreDelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iIdClienteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sIdClienteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tNombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.importeBrutoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txbNombreCliente = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txbCodCliente = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.labelGradient1 = new GESTCRM.Controles.LabelGradient();
            this.btBuscarImportes = new System.Windows.Forms.Button();
            this.tabPageAsignacion = new System.Windows.Forms.TabPage();
            this.panel6 = new System.Windows.Forms.Panel();
            this.txtbPuntosPedConAM = new System.Windows.Forms.TextBox();
            this.label47 = new System.Windows.Forms.Label();
            this.txtbPuntosPedAM = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.lblMissAM = new System.Windows.Forms.Label();
            this.txtbCosteTotalAM = new System.Windows.Forms.TextBox();
            this.label44 = new System.Windows.Forms.Label();
            this.txtbRentabilidadAM = new System.Windows.Forms.TextBox();
            this.label43 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.txtbDescMedioAM = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtbBrutoPedAM = new System.Windows.Forms.TextBox();
            this.tabPageConsultaAsignaciones = new System.Windows.Forms.TabPage();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblNumAsignaciones = new System.Windows.Forms.Label();
            this.labelGradient5 = new GESTCRM.Controles.LabelGradient();
            this.dataGridViewAsignaciones = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codAsignacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iIdAccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sDescAccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dFecEnvio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textoEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtsIdClienteConsulta = new System.Windows.Forms.TextBox();
            this.btBuscarClienteConsulta = new System.Windows.Forms.Button();
            this.txtsClienteConsulta = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.labelGradient4 = new GESTCRM.Controles.LabelGradient();
            this.btnBuscarAsignaciones = new System.Windows.Forms.Button();
            this.panelFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsFormularios1)).BeginInit();
            this.pnBusqueda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAccMark)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPedidos1)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAccMark)).BeginInit();
            this.tabControlX.SuspendLayout();
            this.tabPageConsultaImportes.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewImportes)).BeginInit();
            this.panel1.SuspendLayout();
            this.tabPageAsignacion.SuspendLayout();
            this.panel6.SuspendLayout();
            this.tabPageConsultaAsignaciones.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAsignaciones)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelFiltros
            // 
            this.panelFiltros.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelFiltros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelFiltros.Controls.Add(this.lblAvisoVersion);
            this.panelFiltros.Controls.Add(this.txtsIdCliente);
            this.panelFiltros.Controls.Add(this.btBuscarCliente);
            this.panelFiltros.Controls.Add(this.txtsCliente);
            this.panelFiltros.Controls.Add(this.label9);
            this.panelFiltros.Controls.Add(this.lblTitulo);
            this.panelFiltros.Controls.Add(this.btnBuscar);
            this.panelFiltros.Location = new System.Drawing.Point(2, 0);
            this.panelFiltros.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelFiltros.Name = "panelFiltros";
            this.panelFiltros.Size = new System.Drawing.Size(1502, 116);
            this.panelFiltros.TabIndex = 30;
            // 
            // lblAvisoVersion
            // 
            this.lblAvisoVersion.AutoSize = true;
            this.lblAvisoVersion.BackColor = System.Drawing.Color.Yellow;
            this.lblAvisoVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvisoVersion.ForeColor = System.Drawing.Color.Red;
            this.lblAvisoVersion.Location = new System.Drawing.Point(710, -2);
            this.lblAvisoVersion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAvisoVersion.Name = "lblAvisoVersion";
            this.lblAvisoVersion.Size = new System.Drawing.Size(57, 20);
            this.lblAvisoVersion.TabIndex = 127;
            this.lblAvisoVersion.Text = "label1";
            // 
            // txtsIdCliente
            // 
            this.txtsIdCliente.BackColor = System.Drawing.Color.White;
            this.txtsIdCliente.ForeColor = System.Drawing.Color.Black;
            this.txtsIdCliente.Location = new System.Drawing.Point(99, 54);
            this.txtsIdCliente.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtsIdCliente.MaxLength = 20;
            this.txtsIdCliente.Name = "txtsIdCliente";
            this.txtsIdCliente.Size = new System.Drawing.Size(190, 26);
            this.txtsIdCliente.TabIndex = 115;
            // 
            // btBuscarCliente
            // 
            this.btBuscarCliente.Image = ((System.Drawing.Image)(resources.GetObject("btBuscarCliente.Image")));
            this.btBuscarCliente.Location = new System.Drawing.Point(795, 52);
            this.btBuscarCliente.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btBuscarCliente.Name = "btBuscarCliente";
            this.btBuscarCliente.Size = new System.Drawing.Size(33, 34);
            this.btBuscarCliente.TabIndex = 117;
            this.btBuscarCliente.TabStop = false;
            this.btBuscarCliente.UseVisualStyleBackColor = true;
            this.btBuscarCliente.Click += new System.EventHandler(this.btBuscarCliente_Click);
            // 
            // txtsCliente
            // 
            this.txtsCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtsCliente.ForeColor = System.Drawing.Color.Black;
            this.txtsCliente.Location = new System.Drawing.Point(291, 54);
            this.txtsCliente.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtsCliente.Name = "txtsCliente";
            this.txtsCliente.ReadOnly = true;
            this.txtsCliente.Size = new System.Drawing.Size(502, 26);
            this.txtsCliente.TabIndex = 116;
            this.txtsCliente.TabStop = false;
            // 
            // label9
            // 
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(26, 57);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 25);
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
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(1500, 25);
            this.lblTitulo.TabIndex = 92;
            this.lblTitulo.Text = "Asignación de acciones de marketing a autopedidos";
            // 
            // btnBuscar
            // 
            this.btnBuscar.ForeColor = System.Drawing.Color.Black;
            this.btnBuscar.Location = new System.Drawing.Point(1071, 52);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(130, 37);
            this.btnBuscar.TabIndex = 12;
            this.btnBuscar.Text = "&Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // sqlConn
            // 
            this.sqlConn.ConnectionString = Utiles._connection.ConnectionString.ToString();   //---- GSG (06/03/2021)
            this.sqlConn.FireInfoMessageEventOnUserErrors = false;
            // 
            // sqldaListaAccionesMarketing
            // 
            this.sqldaListaAccionesMarketing.SelectCommand = this.sqlCmdListaAccionesMarketing;
            this.sqldaListaAccionesMarketing.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaAccionesMarketing", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iIdAccion", "iIdAccion"),
                        new System.Data.Common.DataColumnMapping("sIdAccion", "sIdAccion"),
                        new System.Data.Common.DataColumnMapping("sDescAccion", "sDescAccion"),
                        new System.Data.Common.DataColumnMapping("sIdTipoAccion", "sIdTipoAccion"),
                        new System.Data.Common.DataColumnMapping("dFechaCreacion", "dFechaCreacion"),
                        new System.Data.Common.DataColumnMapping("dFechaIni", "dFechaIni"),
                        new System.Data.Common.DataColumnMapping("dFechaFin", "dFechaFin"),
                        new System.Data.Common.DataColumnMapping("iUnidades", "iUnidades"),
                        new System.Data.Common.DataColumnMapping("fCosteUnitario", "fCosteUnitario"),
                        new System.Data.Common.DataColumnMapping("fCosteTotal", "fCosteTotal"),
                        new System.Data.Common.DataColumnMapping("sObservaciones", "sObservaciones"),
                        new System.Data.Common.DataColumnMapping("sIdTipoImputacion", "sIdTipoImputacion"),
                        new System.Data.Common.DataColumnMapping("dFUM", "dFUM"),
                        new System.Data.Common.DataColumnMapping("iEstado", "iEstado"),
                        new System.Data.Common.DataColumnMapping("bEnviadoPDA", "bEnviadoPDA"),
                        new System.Data.Common.DataColumnMapping("iNumElemEntregar", "iNumElemEntregar"),
                        new System.Data.Common.DataColumnMapping("fImpMin", "fImpMin"),
                        new System.Data.Common.DataColumnMapping("fImpMax", "fImpMax"),
                        new System.Data.Common.DataColumnMapping("iMaxAEntregar", "iMaxAEntregar")})});
            // 
            // sqlCmdListaAccionesMarketing
            // 
            this.sqlCmdListaAccionesMarketing.CommandText = "ListaAccionesMarketing";
            this.sqlCmdListaAccionesMarketing.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdListaAccionesMarketing.Connection = this.sqlConn;
            this.sqlCmdListaAccionesMarketing.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@sIdTipoAccion", System.Data.SqlDbType.NVarChar, 10),
            new System.Data.SqlClient.SqlParameter("@sIdProducto", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@iUnidadesSel", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@fImporteSel", System.Data.SqlDbType.Float, 8),
            new System.Data.SqlClient.SqlParameter("@fRentabSel", System.Data.SqlDbType.Float, 8),
            new System.Data.SqlClient.SqlParameter("@bIndepe", System.Data.SqlDbType.Bit, 1),
            new System.Data.SqlClient.SqlParameter("@iActivoPara", System.Data.SqlDbType.Int, 4)});
            // 
            // sqldaListaAutoPedsSinAccMark
            // 
            this.sqldaListaAutoPedsSinAccMark.SelectCommand = this.sqlCmdListaAutoPedsSinAccMark;
            this.sqldaListaAutoPedsSinAccMark.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaAutoPedsSinAccMark", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("sIdPedido", "sIdPedido"),
                        new System.Data.Common.DataColumnMapping("dFechaPedido", "dFechaPedido"),
                        new System.Data.Common.DataColumnMapping("fImporteBruto", "fImporteBruto")})});
            // 
            // sqlCmdListaAutoPedsSinAccMark
            // 
            this.sqlCmdListaAutoPedsSinAccMark.CommandText = "ListaAutoPedsSinAccMark";
            this.sqlCmdListaAutoPedsSinAccMark.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdListaAutoPedsSinAccMark.Connection = this.sqlConn;
            this.sqlCmdListaAutoPedsSinAccMark.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@iIdDelegado", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4)});
            // 
            // sqldaListaLinsAutoPedsSinAccMark
            // 
            this.sqldaListaLinsAutoPedsSinAccMark.SelectCommand = this.sqlCmdListaLinsAutoPedsSinAccMark;
            this.sqldaListaLinsAutoPedsSinAccMark.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaLinsAutoPedsSinAccMark", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("sIdMaterial", "sIdMaterial"),
                        new System.Data.Common.DataColumnMapping("sIdProducto", "sIdProducto"),
                        new System.Data.Common.DataColumnMapping("fPrecio", "fPrecio"),
                        new System.Data.Common.DataColumnMapping("iCantidad", "iCantidad"),
                        new System.Data.Common.DataColumnMapping("fCoste", "fCoste")})});
            // 
            // sqlCmdListaLinsAutoPedsSinAccMark
            // 
            this.sqlCmdListaLinsAutoPedsSinAccMark.CommandText = "ListaLinsAutoPedsSinAccMark";
            this.sqlCmdListaLinsAutoPedsSinAccMark.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdListaLinsAutoPedsSinAccMark.Connection = this.sqlConn;
            this.sqlCmdListaLinsAutoPedsSinAccMark.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@iIdDelegado", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4)});
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
            // sqlCmdGetMaterialesNoRentabilidad
            // 
            this.sqlCmdGetMaterialesNoRentabilidad.CommandText = "[GetMaterialesNoRentabilidad]";
            this.sqlCmdGetMaterialesNoRentabilidad.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdGetMaterialesNoRentabilidad.Connection = this.sqlConn;
            this.sqlCmdGetMaterialesNoRentabilidad.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@sIdPedido", System.Data.SqlDbType.VarChar, 12)});
            // 
            // sqlCmdGetCampanyasNoRentabilidad
            // 
            this.sqlCmdGetCampanyasNoRentabilidad.CommandText = "[GetCampanyasNoRentabilidad]";
            this.sqlCmdGetCampanyasNoRentabilidad.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdGetCampanyasNoRentabilidad.Connection = this.sqlConn;
            // 
            // dsFormularios1
            // 
            this.dsFormularios1.DataSetName = "dsFormularios";
            this.dsFormularios1.Locale = new System.Globalization.CultureInfo("es-ES");
            this.dsFormularios1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sqldaListaImportes
            // 
            this.sqldaListaImportes.SelectCommand = this.sqlCmdListaImportesClientesSAPConAutopedsSinAccMark;
            this.sqldaListaImportes.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaImportesClientesSAPConAutopedsSinAccMark", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iIdDelegado", "iIdDelegado"),
                        new System.Data.Common.DataColumnMapping("NombreDel", "NombreDel"),
                        new System.Data.Common.DataColumnMapping("iIdCliente", "iIdCliente"),
                        new System.Data.Common.DataColumnMapping("sIdCliente", "sIdCliente"),
                        new System.Data.Common.DataColumnMapping("tNombre", "tNombre"),
                        new System.Data.Common.DataColumnMapping("ImporteBruto", "ImporteBruto")})});
            // 
            // sqlCmdListaImportesClientesSAPConAutopedsSinAccMark
            // 
            this.sqlCmdListaImportesClientesSAPConAutopedsSinAccMark.CommandText = "ListaImportesClientesSAPConAutopedsSinAccMark";
            this.sqlCmdListaImportesClientesSAPConAutopedsSinAccMark.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdListaImportesClientesSAPConAutopedsSinAccMark.Connection = this.sqlConn;
            this.sqlCmdListaImportesClientesSAPConAutopedsSinAccMark.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@iIdDelegado", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sIdCliente", System.Data.SqlDbType.VarChar, 20),
            new System.Data.SqlClient.SqlParameter("@sNombre", System.Data.SqlDbType.VarChar, 50)});
            // 
            // sqldaListaAsignaciones
            // 
            this.sqldaListaAsignaciones.SelectCommand = this.sqlCmdListaAsignacionesAutopedsSinAccMark;
            this.sqldaListaAsignaciones.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaAsignacionesAutopedsSinAccMark", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iIdDelegado", "iIdDelegado"),
                        new System.Data.Common.DataColumnMapping("NombreDel", "NombreDel"),
                        new System.Data.Common.DataColumnMapping("codAsignacion", "codAsignacion"),
                        new System.Data.Common.DataColumnMapping("sIdCliente", "sIdCliente"),
                        new System.Data.Common.DataColumnMapping("sNombre", "sNombre"),
                        new System.Data.Common.DataColumnMapping("sIdPedido", "sIdPedido"),
                        new System.Data.Common.DataColumnMapping("iIdAccion", "iIdAccion"),
                        new System.Data.Common.DataColumnMapping("sDescAccion", "sDescAccion"),
                        new System.Data.Common.DataColumnMapping("ImporteBruto", "ImporteBruto")})});
            // 
            // sqlCmdListaAsignacionesAutopedsSinAccMark
            // 
            this.sqlCmdListaAsignacionesAutopedsSinAccMark.CommandText = "ListaAsignacionesAutopedsSinAccMark";
            this.sqlCmdListaAsignacionesAutopedsSinAccMark.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdListaAsignacionesAutopedsSinAccMark.Connection = this.sqlConn;
            this.sqlCmdListaAsignacionesAutopedsSinAccMark.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@iIdDelegado", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sIdCliente", System.Data.SqlDbType.VarChar, 20),
            new System.Data.SqlClient.SqlParameter("@sNombre", System.Data.SqlDbType.VarChar, 50)});
            // 
            // sqlGetNumAcckMarkADescartar
            // 
            this.sqlGetNumAcckMarkADescartar.CommandText = "[GetNumAccMarkSel]";
            this.sqlGetNumAcckMarkADescartar.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlGetNumAcckMarkADescartar.Connection = this.sqlConn;
            this.sqlGetNumAcckMarkADescartar.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@codsAccMark", System.Data.SqlDbType.VarChar, 500)});
            // 
            // sqlGetNewIdGrupoAutoPedAcciones
            // 
            this.sqlGetNewIdGrupoAutoPedAcciones.CommandText = "[GetNewIdGrupoAutoPedAcciones]";
            this.sqlGetNewIdGrupoAutoPedAcciones.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlGetNewIdGrupoAutoPedAcciones.Connection = this.sqlConn;
            this.sqlGetNewIdGrupoAutoPedAcciones.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@Ret", System.Data.SqlDbType.VarChar, 12, System.Data.ParameterDirection.Output, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null)});
            // 
            // sqlCmdSetAutoPedAcciones
            // 
            this.sqlCmdSetAutoPedAcciones.CommandText = "[SetAutoPedAcciones]";
            this.sqlCmdSetAutoPedAcciones.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdSetAutoPedAcciones.Connection = this.sqlConn;
            this.sqlCmdSetAutoPedAcciones.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@sIdGrupoAutoPedido", System.Data.SqlDbType.VarChar, 12),
            new System.Data.SqlClient.SqlParameter("@sIdPedido", System.Data.SqlDbType.VarChar, 12)});
            // 
            // sqlCmdSetPedAcciones
            // 
            this.sqlCmdSetPedAcciones.CommandText = "[SetPedAcciones]";
            this.sqlCmdSetPedAcciones.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdSetPedAcciones.Connection = this.sqlConn;
            this.sqlCmdSetPedAcciones.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iAccion", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sIdPedido", System.Data.SqlDbType.VarChar, 12),
            new System.Data.SqlClient.SqlParameter("@iUnidades", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@Destino", System.Data.SqlDbType.VarChar, 1),
            new System.Data.SqlClient.SqlParameter("@iIdAccion", System.Data.SqlDbType.Int),
            new System.Data.SqlClient.SqlParameter("@Bruto", System.Data.SqlDbType.Float, 8)});
            // 
            // sqlCmdMaxAccMark
            // 
            this.sqlCmdMaxAccMark.CommandText = "GetNumMaxAccMarkSel";
            this.sqlCmdMaxAccMark.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdMaxAccMark.Connection = this.sqlConn;
            this.sqlCmdMaxAccMark.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@fImporte", System.Data.SqlDbType.Float, 8)});

            // 
            // sqldaCodsAccMark
            // 
            this.sqldaCodsAccMark.SelectCommand = this.sqlCmdListaCodsAccMark;
            this.sqldaCodsAccMark.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaCodigosAccMark", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iIdAccion", "iIdAccion"),
                        new System.Data.Common.DataColumnMapping("sIdAccion", "sIdAccion")})});
            // 
            // sqlCmdListaCodsAccMark
            // 
            this.sqlCmdListaCodsAccMark.CommandText = "[ListaCodigosAccMark]";
            this.sqlCmdListaCodsAccMark.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdListaCodsAccMark.Connection = this.sqlConn;
            this.sqlCmdListaCodsAccMark.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null)});


            // 
            // sqldaCodsAccMarkPicking
            // 
            this.sqldaCodsAccMarkPicking.SelectCommand = this.sqlCmdListaCodsAccMarkPicking;
            this.sqldaCodsAccMarkPicking.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaCodigosAccMarkPicking", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iIdAccion", "iIdAccion"),
                        new System.Data.Common.DataColumnMapping("sIdAccion", "sIdAccion")})});
            // 
            // sqlCmdListaCodsAccMarkPicking
            // 
            this.sqlCmdListaCodsAccMarkPicking.CommandText = "[ListaCodigosAccMarkPicking]";
            this.sqlCmdListaCodsAccMarkPicking.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdListaCodsAccMarkPicking.Connection = this.sqlConn;
            this.sqlCmdListaCodsAccMarkPicking.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@sIdTipoPedido", System.Data.SqlDbType.VarChar, 4)});






            // 
            // sqlCmdSetPedidosCab
            // 
            this.sqlCmdSetPedidosCab.CommandText = "[SetPedidosCab]";
            this.sqlCmdSetPedidosCab.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdSetPedidosCab.Connection = this.sqlConn;
            this.sqlCmdSetPedidosCab.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iAccion", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sIdPedido", System.Data.SqlDbType.VarChar, 12, System.Data.ParameterDirection.InputOutput, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@sIdPedidoTemp", System.Data.SqlDbType.VarChar, 15, System.Data.ParameterDirection.InputOutput, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdDelegado", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sIdTipoPedido", System.Data.SqlDbType.VarChar, 4),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdDestinatario", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@dFechaPedido", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@dFechaPreferente", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@dFechaFijada", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@sOrgVentas", System.Data.SqlDbType.VarChar, 4),
            new System.Data.SqlClient.SqlParameter("@sGrupoVendedor", System.Data.SqlDbType.VarChar, 3),
            new System.Data.SqlClient.SqlParameter("@sCanal", System.Data.SqlDbType.VarChar, 2),
            new System.Data.SqlClient.SqlParameter("@sSector", System.Data.SqlDbType.VarChar, 2),
            new System.Data.SqlClient.SqlParameter("@fImporte", System.Data.SqlDbType.Float, 8),
            new System.Data.SqlClient.SqlParameter("@fDescuento", System.Data.SqlDbType.Float, 8),
            new System.Data.SqlClient.SqlParameter("@sIdTipoCampanya", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@tObservaciones", System.Data.SqlDbType.Text, 2147483647),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt, 2),
            new System.Data.SqlClient.SqlParameter("@fFUM", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@bEnviadoCEN", System.Data.SqlDbType.Bit, 1),
            new System.Data.SqlClient.SqlParameter("@bEnviadoPDA", System.Data.SqlDbType.Bit, 1),
            new System.Data.SqlClient.SqlParameter("@fDescuentoCampanya", System.Data.SqlDbType.Float, 8),
            new System.Data.SqlClient.SqlParameter("@fDescuentoAdicional", System.Data.SqlDbType.Float, 8),
            new System.Data.SqlClient.SqlParameter("@fRentabilidad", System.Data.SqlDbType.Float, 8),
            new System.Data.SqlClient.SqlParameter("@iIdAccion", System.Data.SqlDbType.Int),
            new System.Data.SqlClient.SqlParameter("@sFechaVencimiento", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@sCondPago", System.Data.SqlDbType.VarChar, 4),
            new System.Data.SqlClient.SqlParameter("@sPrioridad", System.Data.SqlDbType.VarChar, 2),
            new System.Data.SqlClient.SqlParameter("@dFechaFacturacion", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@sTipoPedidoCompromiso", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@sTipoGestionCompromiso", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@sCPCompra", System.Data.SqlDbType.VarChar, 5)});

            // 
            // sqlCmdSetPedidosLin
            // 
            this.sqlCmdSetPedidosLin.CommandText = "SetPedidosLin";
            this.sqlCmdSetPedidosLin.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdSetPedidosLin.Connection = this.sqlConn;
            this.sqlCmdSetPedidosLin.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iAccion", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sIdPedido", System.Data.SqlDbType.VarChar, 12),
            new System.Data.SqlClient.SqlParameter("@iIdLinea", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sIdMaterial", System.Data.SqlDbType.VarChar, 18),
            new System.Data.SqlClient.SqlParameter("@iCantidad", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@fPrecio", System.Data.SqlDbType.Float, 8),
            new System.Data.SqlClient.SqlParameter("@sidTipoPosicion", System.Data.SqlDbType.VarChar, 4),
            new System.Data.SqlClient.SqlParameter("@bEntregado", System.Data.SqlDbType.Bit, 1),
            new System.Data.SqlClient.SqlParameter("@dFechaPreferente", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@fDescuento", System.Data.SqlDbType.Float, 8),
            new System.Data.SqlClient.SqlParameter("@iBonificacion", System.Data.SqlDbType.Bit, 1),
            new System.Data.SqlClient.SqlParameter("@idCampanya", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@idArrastre", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@idGrupoMat", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@idPaquete", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sSerie", System.Data.SqlDbType.VarChar, 7),
            new System.Data.SqlClient.SqlParameter("@sCodVale", System.Data.SqlDbType.VarChar, 15),
            new System.Data.SqlClient.SqlParameter("@sRechazo", System.Data.SqlDbType.VarChar, 4)});

            // 
            // pnBusqueda
            // 
            this.pnBusqueda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnBusqueda.Controls.Add(this.dgvPeds);
            this.pnBusqueda.Controls.Add(this.lblNumReg);
            this.pnBusqueda.Controls.Add(this.labelGradient2);
            this.pnBusqueda.Location = new System.Drawing.Point(2, 123);
            this.pnBusqueda.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnBusqueda.Name = "pnBusqueda";
            this.pnBusqueda.Size = new System.Drawing.Size(386, 581);
            this.pnBusqueda.TabIndex = 122;
            // 
            // dgvPeds
            // 
            this.dgvPeds.AllowUserToAddRows = false;
            this.dgvPeds.AllowUserToDeleteRows = false;
            this.dgvPeds.AllowUserToResizeRows = false;
            dataGridViewCellStyle67.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvPeds.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle67;
            this.dgvPeds.AutoGenerateColumns = false;
            this.dgvPeds.BackgroundColor = System.Drawing.Color.White;
            this.dgvPeds.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle68.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle68.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle68.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle68.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle68.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle68.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle68.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPeds.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle68;
            this.dgvPeds.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPeds.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sIdPedido,
            this.dFechaPedido,
            this.fImporteBruto,
            this.fImporteNeto});
            this.dgvPeds.DataMember = "ListaAutoPedsSinAccMark";
            this.dgvPeds.DataSource = this.dsAccMark;
            dataGridViewCellStyle71.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle71.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle71.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle71.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle71.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle71.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle71.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPeds.DefaultCellStyle = dataGridViewCellStyle71;
            this.dgvPeds.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPeds.Location = new System.Drawing.Point(0, 25);
            this.dgvPeds.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvPeds.MultiSelect = false;
            this.dgvPeds.Name = "dgvPeds";
            this.dgvPeds.RowHeadersWidth = 25;
            dataGridViewCellStyle72.ForeColor = System.Drawing.Color.Black;
            this.dgvPeds.RowsDefaultCellStyle = dataGridViewCellStyle72;
            this.dgvPeds.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPeds.Size = new System.Drawing.Size(384, 554);
            this.dgvPeds.TabIndex = 90;
            // 
            // sIdPedido
            // 
            this.sIdPedido.DataPropertyName = "sIdPedido";
            this.sIdPedido.HeaderText = "Id. Pedido";
            this.sIdPedido.Name = "sIdPedido";
            this.sIdPedido.ReadOnly = true;
            // 
            // dFechaPedido
            // 
            this.dFechaPedido.DataPropertyName = "dFechaPedido";
            dataGridViewCellStyle69.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dFechaPedido.DefaultCellStyle = dataGridViewCellStyle69;
            this.dFechaPedido.HeaderText = "Fecha Pedido";
            this.dFechaPedido.Name = "dFechaPedido";
            this.dFechaPedido.ReadOnly = true;
            this.dFechaPedido.Width = 120;
            // 
            // fImporteBruto
            // 
            this.fImporteBruto.DataPropertyName = "fImporteBruto";
            dataGridViewCellStyle70.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle70.Format = "N2";
            dataGridViewCellStyle70.NullValue = null;
            this.fImporteBruto.DefaultCellStyle = dataGridViewCellStyle70;
            this.fImporteBruto.HeaderText = "Importe bruto";
            this.fImporteBruto.Name = "fImporteBruto";
            this.fImporteBruto.ReadOnly = true;
            this.fImporteBruto.Width = 120;
            // 
            // fImporteNeto
            // 
            this.fImporteNeto.DataPropertyName = "fImporteNeto";
            this.fImporteNeto.HeaderText = "fImporteNeto";
            this.fImporteNeto.Name = "fImporteNeto";
            this.fImporteNeto.ReadOnly = true;
            this.fImporteNeto.Visible = false;
            // 
            // dsAccMark
            // 
            this.dsAccMark.DataSetName = "dsAccionesMarketing";
            this.dsAccMark.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lblNumReg
            // 
            this.lblNumReg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.lblNumReg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblNumReg.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumReg.ForeColor = System.Drawing.Color.Black;
            this.lblNumReg.Location = new System.Drawing.Point(323, -2);
            this.lblNumReg.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNumReg.Name = "lblNumReg";
            this.lblNumReg.Size = new System.Drawing.Size(59, 28);
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
            this.labelGradient2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelGradient2.Name = "labelGradient2";
            this.labelGradient2.Size = new System.Drawing.Size(384, 25);
            this.labelGradient2.TabIndex = 88;
            this.labelGradient2.Text = "Autopedidos sin Acciones de Marketing";
            this.labelGradient2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dsPedidos1
            // 
            this.dsPedidos1.DataSetName = "dsPedidos";
            this.dsPedidos1.Locale = new System.Globalization.CultureInfo("en-US");
            this.dsPedidos1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.lblNumRegAccMark);
            this.panel3.Controls.Add(this.labelGradientAccMark);
            this.panel3.Controls.Add(this.dataGridViewAccMark);
            this.panel3.Location = new System.Drawing.Point(391, 123);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(747, 581);
            this.panel3.TabIndex = 125;
            // 
            // lblNumRegAccMark
            // 
            this.lblNumRegAccMark.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.lblNumRegAccMark.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblNumRegAccMark.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumRegAccMark.ForeColor = System.Drawing.Color.Black;
            this.lblNumRegAccMark.Location = new System.Drawing.Point(650, 5);
            this.lblNumRegAccMark.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNumRegAccMark.Name = "lblNumRegAccMark";
            this.lblNumRegAccMark.Size = new System.Drawing.Size(96, 26);
            this.lblNumRegAccMark.TabIndex = 95;
            this.lblNumRegAccMark.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelGradientAccMark
            // 
            this.labelGradientAccMark.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGradientAccMark.ForeColor = System.Drawing.Color.White;
            this.labelGradientAccMark.GradientColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.labelGradientAccMark.GradientColorTwo = System.Drawing.Color.White;
            this.labelGradientAccMark.Location = new System.Drawing.Point(4, 5);
            this.labelGradientAccMark.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelGradientAccMark.Name = "labelGradientAccMark";
            this.labelGradientAccMark.Size = new System.Drawing.Size(993, 25);
            this.labelGradientAccMark.TabIndex = 93;
            this.labelGradientAccMark.Text = "Acciones de Marketing";
            this.labelGradientAccMark.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dataGridViewAccMark
            // 
            this.dataGridViewAccMark.AllowUserToAddRows = false;
            this.dataGridViewAccMark.AllowUserToDeleteRows = false;
            this.dataGridViewAccMark.AllowUserToResizeRows = false;
            dataGridViewCellStyle73.BackColor = System.Drawing.Color.White;
            this.dataGridViewAccMark.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle73;
            this.dataGridViewAccMark.AutoGenerateColumns = false;
            this.dataGridViewAccMark.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewAccMark.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle74.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle74.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle74.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle74.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle74.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle74.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle74.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewAccMark.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle74;
            this.dataGridViewAccMark.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAccMark.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.selected,
            this.fImpMax,
            this.iMaxAEntregar,
            this.fCosteTotal,
            this.iIdAccionDataGridViewTextBoxColumn,
            this.sIdAccionDataGridViewTextBoxColumn,
            this.sDescAccionDataGridViewTextBoxColumn,
            this.sIdTipoAccionDataGridViewTextBoxColumn,
            this.iUnidadesDataGridViewTextBoxColumn,
            this.iNumElemEntregarDataGridViewTextBoxColumn,
            this.fCosteTotalDataGridViewTextBoxColumn,
            this.dFechaCreacionDataGridViewTextBoxColumn,
            this.dFechaIniDataGridViewTextBoxColumn,
            this.dFechaFinDataGridViewTextBoxColumn,
            this.sObservacionesDataGridViewTextBoxColumn,
            this.sIdTipoImputacionDataGridViewTextBoxColumn,
            this.dFUMDataGridViewTextBoxColumn,
            this.iEstadoDataGridViewTextBoxColumn,
            this.bEnviadoPDADataGridViewCheckBoxColumn,
            this.UnidadesAEntregar,
            this.fImpMin,
            this.sIdProducto,
            this.producto,
            this.fCosteUnitarioDataGridViewTextBoxColumn,
            this.bIndepe,
            this.fRentabilidad,
            this.bSuma});
            this.dataGridViewAccMark.DataMember = "ListaAccionesMarketing";
            this.dataGridViewAccMark.DataSource = this.dsAccMark;
            dataGridViewCellStyle77.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle77.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle77.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle77.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle77.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle77.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle77.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewAccMark.DefaultCellStyle = dataGridViewCellStyle77;
            this.dataGridViewAccMark.Location = new System.Drawing.Point(6, 34);
            this.dataGridViewAccMark.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridViewAccMark.MultiSelect = false;
            this.dataGridViewAccMark.Name = "dataGridViewAccMark";
            this.dataGridViewAccMark.RowHeadersVisible = false;
            this.dataGridViewAccMark.RowHeadersWidth = 25;
            dataGridViewCellStyle78.ForeColor = System.Drawing.Color.Black;
            this.dataGridViewAccMark.RowsDefaultCellStyle = dataGridViewCellStyle78;
            this.dataGridViewAccMark.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewAccMark.Size = new System.Drawing.Size(740, 424);
            this.dataGridViewAccMark.TabIndex = 94;
            this.dataGridViewAccMark.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dataGridViewAccMark_MouseUp);
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
            // fImpMax
            // 
            this.fImpMax.DataPropertyName = "fImpMax";
            this.fImpMax.HeaderText = "fImpMax";
            this.fImpMax.Name = "fImpMax";
            this.fImpMax.ReadOnly = true;
            this.fImpMax.Visible = false;
            // 
            // iMaxAEntregar
            // 
            this.iMaxAEntregar.DataPropertyName = "iMaxAEntregar";
            this.iMaxAEntregar.HeaderText = "Nº Unidades";
            this.iMaxAEntregar.Name = "iMaxAEntregar";
            this.iMaxAEntregar.ReadOnly = true;
            this.iMaxAEntregar.Visible = false;
            this.iMaxAEntregar.Width = 80;
            // 
            // fCosteTotal
            // 
            this.fCosteTotal.DataPropertyName = "fCosteTotal";
            this.fCosteTotal.HeaderText = "fCosteTotal";
            this.fCosteTotal.Name = "fCosteTotal";
            this.fCosteTotal.ReadOnly = true;
            this.fCosteTotal.Visible = false;
            // 
            // iIdAccionDataGridViewTextBoxColumn
            // 
            this.iIdAccionDataGridViewTextBoxColumn.DataPropertyName = "iIdAccion";
            this.iIdAccionDataGridViewTextBoxColumn.HeaderText = "iIdAccion";
            this.iIdAccionDataGridViewTextBoxColumn.Name = "iIdAccionDataGridViewTextBoxColumn";
            this.iIdAccionDataGridViewTextBoxColumn.Visible = false;
            // 
            // sIdAccionDataGridViewTextBoxColumn
            // 
            this.sIdAccionDataGridViewTextBoxColumn.DataPropertyName = "sIdAccion";
            this.sIdAccionDataGridViewTextBoxColumn.HeaderText = "sIdAccion";
            this.sIdAccionDataGridViewTextBoxColumn.Name = "sIdAccionDataGridViewTextBoxColumn";
            this.sIdAccionDataGridViewTextBoxColumn.Visible = false;
            // 
            // sDescAccionDataGridViewTextBoxColumn
            // 
            this.sDescAccionDataGridViewTextBoxColumn.DataPropertyName = "sDescAccion";
            this.sDescAccionDataGridViewTextBoxColumn.HeaderText = "Descripción";
            this.sDescAccionDataGridViewTextBoxColumn.Name = "sDescAccionDataGridViewTextBoxColumn";
            this.sDescAccionDataGridViewTextBoxColumn.Width = 250;
            // 
            // sIdTipoAccionDataGridViewTextBoxColumn
            // 
            this.sIdTipoAccionDataGridViewTextBoxColumn.DataPropertyName = "sIdTipoAccion";
            this.sIdTipoAccionDataGridViewTextBoxColumn.HeaderText = "sIdTipoAccion";
            this.sIdTipoAccionDataGridViewTextBoxColumn.Name = "sIdTipoAccionDataGridViewTextBoxColumn";
            this.sIdTipoAccionDataGridViewTextBoxColumn.Visible = false;
            // 
            // iUnidadesDataGridViewTextBoxColumn
            // 
            this.iUnidadesDataGridViewTextBoxColumn.DataPropertyName = "iUnidades";
            this.iUnidadesDataGridViewTextBoxColumn.HeaderText = "Min. Mat.";
            this.iUnidadesDataGridViewTextBoxColumn.Name = "iUnidadesDataGridViewTextBoxColumn";
            this.iUnidadesDataGridViewTextBoxColumn.Visible = false;
            // 
            // iNumElemEntregarDataGridViewTextBoxColumn
            // 
            this.iNumElemEntregarDataGridViewTextBoxColumn.DataPropertyName = "iNumElemEntregar";
            this.iNumElemEntregarDataGridViewTextBoxColumn.HeaderText = "Min. Unid.";
            this.iNumElemEntregarDataGridViewTextBoxColumn.Name = "iNumElemEntregarDataGridViewTextBoxColumn";
            this.iNumElemEntregarDataGridViewTextBoxColumn.Visible = false;
            // 
            // fCosteTotalDataGridViewTextBoxColumn
            // 
            this.fCosteTotalDataGridViewTextBoxColumn.DataPropertyName = "fCosteTotal";
            this.fCosteTotalDataGridViewTextBoxColumn.HeaderText = "fCosteTotal";
            this.fCosteTotalDataGridViewTextBoxColumn.Name = "fCosteTotalDataGridViewTextBoxColumn";
            this.fCosteTotalDataGridViewTextBoxColumn.Visible = false;
            // 
            // dFechaCreacionDataGridViewTextBoxColumn
            // 
            this.dFechaCreacionDataGridViewTextBoxColumn.DataPropertyName = "dFechaCreacion";
            this.dFechaCreacionDataGridViewTextBoxColumn.HeaderText = "dFechaCreacion";
            this.dFechaCreacionDataGridViewTextBoxColumn.Name = "dFechaCreacionDataGridViewTextBoxColumn";
            this.dFechaCreacionDataGridViewTextBoxColumn.Visible = false;
            // 
            // dFechaIniDataGridViewTextBoxColumn
            // 
            this.dFechaIniDataGridViewTextBoxColumn.DataPropertyName = "dFechaIni";
            this.dFechaIniDataGridViewTextBoxColumn.HeaderText = "dFechaIni";
            this.dFechaIniDataGridViewTextBoxColumn.Name = "dFechaIniDataGridViewTextBoxColumn";
            this.dFechaIniDataGridViewTextBoxColumn.Visible = false;
            // 
            // dFechaFinDataGridViewTextBoxColumn
            // 
            this.dFechaFinDataGridViewTextBoxColumn.DataPropertyName = "dFechaFin";
            this.dFechaFinDataGridViewTextBoxColumn.HeaderText = "dFechaFin";
            this.dFechaFinDataGridViewTextBoxColumn.Name = "dFechaFinDataGridViewTextBoxColumn";
            this.dFechaFinDataGridViewTextBoxColumn.Visible = false;
            // 
            // sObservacionesDataGridViewTextBoxColumn
            // 
            this.sObservacionesDataGridViewTextBoxColumn.DataPropertyName = "sObservaciones";
            this.sObservacionesDataGridViewTextBoxColumn.HeaderText = "sObservaciones";
            this.sObservacionesDataGridViewTextBoxColumn.Name = "sObservacionesDataGridViewTextBoxColumn";
            this.sObservacionesDataGridViewTextBoxColumn.Visible = false;
            // 
            // sIdTipoImputacionDataGridViewTextBoxColumn
            // 
            this.sIdTipoImputacionDataGridViewTextBoxColumn.DataPropertyName = "sIdTipoImputacion";
            this.sIdTipoImputacionDataGridViewTextBoxColumn.HeaderText = "sIdTipoImputacion";
            this.sIdTipoImputacionDataGridViewTextBoxColumn.Name = "sIdTipoImputacionDataGridViewTextBoxColumn";
            this.sIdTipoImputacionDataGridViewTextBoxColumn.Visible = false;
            // 
            // dFUMDataGridViewTextBoxColumn
            // 
            this.dFUMDataGridViewTextBoxColumn.DataPropertyName = "dFUM";
            this.dFUMDataGridViewTextBoxColumn.HeaderText = "dFUM";
            this.dFUMDataGridViewTextBoxColumn.Name = "dFUMDataGridViewTextBoxColumn";
            this.dFUMDataGridViewTextBoxColumn.Visible = false;
            // 
            // iEstadoDataGridViewTextBoxColumn
            // 
            this.iEstadoDataGridViewTextBoxColumn.DataPropertyName = "iEstado";
            this.iEstadoDataGridViewTextBoxColumn.HeaderText = "iEstado";
            this.iEstadoDataGridViewTextBoxColumn.Name = "iEstadoDataGridViewTextBoxColumn";
            this.iEstadoDataGridViewTextBoxColumn.Visible = false;
            // 
            // bEnviadoPDADataGridViewCheckBoxColumn
            // 
            this.bEnviadoPDADataGridViewCheckBoxColumn.DataPropertyName = "bEnviadoPDA";
            this.bEnviadoPDADataGridViewCheckBoxColumn.HeaderText = "bEnviadoPDA";
            this.bEnviadoPDADataGridViewCheckBoxColumn.Name = "bEnviadoPDADataGridViewCheckBoxColumn";
            this.bEnviadoPDADataGridViewCheckBoxColumn.Visible = false;
            // 
            // UnidadesAEntregar
            // 
            dataGridViewCellStyle75.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.UnidadesAEntregar.DefaultCellStyle = dataGridViewCellStyle75;
            this.UnidadesAEntregar.HeaderText = "Unidades";
            this.UnidadesAEntregar.Name = "UnidadesAEntregar";
            this.UnidadesAEntregar.ReadOnly = true;
            this.UnidadesAEntregar.Width = 110;
            // 
            // fImpMin
            // 
            this.fImpMin.DataPropertyName = "fImpMin";
            dataGridViewCellStyle76.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle76.Format = "N2";
            this.fImpMin.DefaultCellStyle = dataGridViewCellStyle76;
            this.fImpMin.HeaderText = "Min. Imp.";
            this.fImpMin.Name = "fImpMin";
            this.fImpMin.ReadOnly = true;
            this.fImpMin.Width = 90;
            // 
            // sIdProducto
            // 
            this.sIdProducto.DataPropertyName = "sIdProducto";
            this.sIdProducto.HeaderText = "sIdProducto";
            this.sIdProducto.Name = "sIdProducto";
            this.sIdProducto.ReadOnly = true;
            this.sIdProducto.Visible = false;
            // 
            // producto
            // 
            this.producto.DataPropertyName = "producto";
            this.producto.HeaderText = "Producto";
            this.producto.Name = "producto";
            this.producto.ReadOnly = true;
            this.producto.Width = 160;
            // 
            // fCosteUnitarioDataGridViewTextBoxColumn
            // 
            this.fCosteUnitarioDataGridViewTextBoxColumn.DataPropertyName = "fCosteUnitario";
            this.fCosteUnitarioDataGridViewTextBoxColumn.HeaderText = "Coste";
            this.fCosteUnitarioDataGridViewTextBoxColumn.Name = "fCosteUnitarioDataGridViewTextBoxColumn";
            this.fCosteUnitarioDataGridViewTextBoxColumn.Width = 80;
            // 
            // bIndepe
            // 
            this.bIndepe.DataPropertyName = "bIndepe";
            this.bIndepe.HeaderText = "bIndepe";
            this.bIndepe.Name = "bIndepe";
            this.bIndepe.ReadOnly = true;
            this.bIndepe.Visible = false;
            // 
            // fRentabilidad
            // 
            this.fRentabilidad.DataPropertyName = "fRentabilidad";
            this.fRentabilidad.HeaderText = "fRentabilidad";
            this.fRentabilidad.Name = "fRentabilidad";
            this.fRentabilidad.Visible = false;
            // 
            // bSuma
            // 
            this.bSuma.DataPropertyName = "bSuma";
            this.bSuma.HeaderText = "bSuma";
            this.bSuma.Name = "bSuma";
            this.bSuma.Visible = false;
            // 
            // sqldaAccMarkExcluidas
            // 
            this.sqldaAccMarkExcluidas.SelectCommand = this.sqlCmdAccMarkExcluidas;
            this.sqldaAccMarkExcluidas.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "AccMarkExcluidas", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iIdAccion1", "iIdAccion1"),
                        new System.Data.Common.DataColumnMapping("iIdAccion2", "iIdAccion2"),
                        new System.Data.Common.DataColumnMapping("iEstado", "iEstado")})});
            // 
            // sqlCmdAccMarkExcluidas
            // 
            this.sqlCmdAccMarkExcluidas.CommandText = "GetAccMarkExcluidas";
            this.sqlCmdAccMarkExcluidas.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdAccMarkExcluidas.Connection = this.sqlConn;
            this.sqlCmdAccMarkExcluidas.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null)});
            // 
            // btCancelar
            // 
            this.btCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCancelar.ForeColor = System.Drawing.Color.Black;
            this.btCancelar.Image = global::GESTCRM.Properties.Resources.cancel_032x032;
            this.btCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btCancelar.Location = new System.Drawing.Point(795, 885);
            this.btCancelar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(150, 55);
            this.btCancelar.TabIndex = 127;
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
            this.btAceptar.Location = new System.Drawing.Point(1278, 649);
            this.btAceptar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btAceptar.Name = "btAceptar";
            this.btAceptar.Size = new System.Drawing.Size(111, 41);
            this.btAceptar.TabIndex = 126;
            this.btAceptar.Text = "&Aceptar ";
            this.btAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btAceptar.UseVisualStyleBackColor = true;
            this.btAceptar.Click += new System.EventHandler(this.btAceptar_Click);
            // 
            // tabControlX
            // 
            this.tabControlX.Controls.Add(this.tabPageConsultaImportes);
            this.tabControlX.Controls.Add(this.tabPageAsignacion);
            this.tabControlX.Controls.Add(this.tabPageConsultaAsignaciones);
            this.tabControlX.Location = new System.Drawing.Point(3, 6);
            this.tabControlX.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabControlX.Name = "tabControlX";
            this.tabControlX.SelectedIndex = 0;
            this.tabControlX.Size = new System.Drawing.Size(1512, 747);
            this.tabControlX.TabIndex = 128;
            // 
            // tabPageConsultaImportes
            // 
            this.tabPageConsultaImportes.Controls.Add(this.panel2);
            this.tabPageConsultaImportes.Controls.Add(this.panel1);
            this.tabPageConsultaImportes.Location = new System.Drawing.Point(4, 29);
            this.tabPageConsultaImportes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPageConsultaImportes.Name = "tabPageConsultaImportes";
            this.tabPageConsultaImportes.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPageConsultaImportes.Size = new System.Drawing.Size(1504, 714);
            this.tabPageConsultaImportes.TabIndex = 1;
            this.tabPageConsultaImportes.Text = "Consulta Importes";
            this.tabPageConsultaImportes.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblNumImportes);
            this.panel2.Controls.Add(this.labelGradient3);
            this.panel2.Controls.Add(this.dataGridViewImportes);
            this.panel2.Location = new System.Drawing.Point(0, 118);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1496, 685);
            this.panel2.TabIndex = 126;
            // 
            // lblNumImportes
            // 
            this.lblNumImportes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.lblNumImportes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblNumImportes.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumImportes.ForeColor = System.Drawing.Color.Black;
            this.lblNumImportes.Location = new System.Drawing.Point(1397, 6);
            this.lblNumImportes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNumImportes.Name = "lblNumImportes";
            this.lblNumImportes.Size = new System.Drawing.Size(95, 24);
            this.lblNumImportes.TabIndex = 95;
            this.lblNumImportes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelGradient3
            // 
            this.labelGradient3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGradient3.ForeColor = System.Drawing.Color.White;
            this.labelGradient3.GradientColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.labelGradient3.GradientColorTwo = System.Drawing.Color.White;
            this.labelGradient3.Location = new System.Drawing.Point(4, 5);
            this.labelGradient3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelGradient3.Name = "labelGradient3";
            this.labelGradient3.Size = new System.Drawing.Size(1486, 28);
            this.labelGradient3.TabIndex = 93;
            this.labelGradient3.Text = "Clientes sin Acciones de Márketing asociadas a autopedidos";
            this.labelGradient3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dataGridViewImportes
            // 
            this.dataGridViewImportes.AllowUserToAddRows = false;
            this.dataGridViewImportes.AllowUserToDeleteRows = false;
            this.dataGridViewImportes.AllowUserToResizeRows = false;
            dataGridViewCellStyle79.BackColor = System.Drawing.Color.White;
            this.dataGridViewImportes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle79;
            this.dataGridViewImportes.AutoGenerateColumns = false;
            this.dataGridViewImportes.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewImportes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle80.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle80.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle80.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle80.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle80.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle80.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle80.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewImportes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle80;
            this.dataGridViewImportes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewImportes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iIdDelegadoDataGridViewTextBoxColumn,
            this.nombreDelDataGridViewTextBoxColumn,
            this.iIdClienteDataGridViewTextBoxColumn,
            this.sIdClienteDataGridViewTextBoxColumn,
            this.tNombreDataGridViewTextBoxColumn,
            this.importeBrutoDataGridViewTextBoxColumn});
            this.dataGridViewImportes.DataMember = "ListaImportesClientesSAPConAutopedsSinAccMark";
            this.dataGridViewImportes.DataSource = this.dsAccMark;
            dataGridViewCellStyle82.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle82.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle82.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle82.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle82.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle82.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle82.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewImportes.DefaultCellStyle = dataGridViewCellStyle82;
            this.dataGridViewImportes.Location = new System.Drawing.Point(6, 34);
            this.dataGridViewImportes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridViewImportes.MultiSelect = false;
            this.dataGridViewImportes.Name = "dataGridViewImportes";
            this.dataGridViewImportes.RowHeadersVisible = false;
            this.dataGridViewImportes.RowHeadersWidth = 25;
            dataGridViewCellStyle83.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle83.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dataGridViewImportes.RowsDefaultCellStyle = dataGridViewCellStyle83;
            this.dataGridViewImportes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewImportes.Size = new System.Drawing.Size(1484, 566);
            this.dataGridViewImportes.TabIndex = 94;
            // 
            // iIdDelegadoDataGridViewTextBoxColumn
            // 
            this.iIdDelegadoDataGridViewTextBoxColumn.DataPropertyName = "iIdDelegado";
            this.iIdDelegadoDataGridViewTextBoxColumn.HeaderText = "iIdDelegado";
            this.iIdDelegadoDataGridViewTextBoxColumn.Name = "iIdDelegadoDataGridViewTextBoxColumn";
            this.iIdDelegadoDataGridViewTextBoxColumn.Visible = false;
            // 
            // nombreDelDataGridViewTextBoxColumn
            // 
            this.nombreDelDataGridViewTextBoxColumn.DataPropertyName = "NombreDel";
            this.nombreDelDataGridViewTextBoxColumn.HeaderText = "NombreDel";
            this.nombreDelDataGridViewTextBoxColumn.Name = "nombreDelDataGridViewTextBoxColumn";
            this.nombreDelDataGridViewTextBoxColumn.Visible = false;
            // 
            // iIdClienteDataGridViewTextBoxColumn
            // 
            this.iIdClienteDataGridViewTextBoxColumn.DataPropertyName = "iIdCliente";
            this.iIdClienteDataGridViewTextBoxColumn.HeaderText = "iIdCliente";
            this.iIdClienteDataGridViewTextBoxColumn.Name = "iIdClienteDataGridViewTextBoxColumn";
            this.iIdClienteDataGridViewTextBoxColumn.Visible = false;
            // 
            // sIdClienteDataGridViewTextBoxColumn
            // 
            this.sIdClienteDataGridViewTextBoxColumn.DataPropertyName = "sIdCliente";
            this.sIdClienteDataGridViewTextBoxColumn.HeaderText = "Cód. Cliente";
            this.sIdClienteDataGridViewTextBoxColumn.Name = "sIdClienteDataGridViewTextBoxColumn";
            this.sIdClienteDataGridViewTextBoxColumn.Width = 120;
            // 
            // tNombreDataGridViewTextBoxColumn
            // 
            this.tNombreDataGridViewTextBoxColumn.DataPropertyName = "tNombre";
            this.tNombreDataGridViewTextBoxColumn.HeaderText = "Cliente";
            this.tNombreDataGridViewTextBoxColumn.Name = "tNombreDataGridViewTextBoxColumn";
            this.tNombreDataGridViewTextBoxColumn.Width = 400;
            // 
            // importeBrutoDataGridViewTextBoxColumn
            // 
            this.importeBrutoDataGridViewTextBoxColumn.DataPropertyName = "ImporteBruto";
            dataGridViewCellStyle81.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle81.Format = "N2";
            this.importeBrutoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle81;
            this.importeBrutoDataGridViewTextBoxColumn.HeaderText = "Importe Bruto";
            this.importeBrutoDataGridViewTextBoxColumn.Name = "importeBrutoDataGridViewTextBoxColumn";
            this.importeBrutoDataGridViewTextBoxColumn.ReadOnly = true;
            this.importeBrutoDataGridViewTextBoxColumn.Width = 140;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txbNombreCliente);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txbCodCliente);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.labelGradient1);
            this.panel1.Controls.Add(this.btBuscarImportes);
            this.panel1.Location = new System.Drawing.Point(2, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1496, 116);
            this.panel1.TabIndex = 31;
            // 
            // txbNombreCliente
            // 
            this.txbNombreCliente.BackColor = System.Drawing.Color.White;
            this.txbNombreCliente.ForeColor = System.Drawing.Color.Black;
            this.txbNombreCliente.Location = new System.Drawing.Point(475, 58);
            this.txbNombreCliente.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txbNombreCliente.MaxLength = 20;
            this.txbNombreCliente.Name = "txbNombreCliente";
            this.txbNombreCliente.Size = new System.Drawing.Size(565, 26);
            this.txbNombreCliente.TabIndex = 120;
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(350, 57);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 28);
            this.label1.TabIndex = 119;
            this.label1.Text = "Nombre Cliente:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txbCodCliente
            // 
            this.txbCodCliente.BackColor = System.Drawing.Color.White;
            this.txbCodCliente.ForeColor = System.Drawing.Color.Black;
            this.txbCodCliente.Location = new System.Drawing.Point(128, 58);
            this.txbCodCliente.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txbCodCliente.MaxLength = 20;
            this.txbCodCliente.Name = "txbCodCliente";
            this.txbCodCliente.Size = new System.Drawing.Size(190, 26);
            this.txbCodCliente.TabIndex = 115;
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(26, 57);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 28);
            this.label2.TabIndex = 118;
            this.label2.Text = "Cód. Cliente:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelGradient1
            // 
            this.labelGradient1.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelGradient1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGradient1.ForeColor = System.Drawing.Color.White;
            this.labelGradient1.GradientColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.labelGradient1.GradientColorTwo = System.Drawing.Color.White;
            this.labelGradient1.Location = new System.Drawing.Point(0, 0);
            this.labelGradient1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelGradient1.Name = "labelGradient1";
            this.labelGradient1.Size = new System.Drawing.Size(1494, 25);
            this.labelGradient1.TabIndex = 92;
            this.labelGradient1.Text = "Consulta de importes de clientes sin acciones de márketing asociadas a autopedido" +
    "s";
            // 
            // btBuscarImportes
            // 
            this.btBuscarImportes.ForeColor = System.Drawing.Color.Black;
            this.btBuscarImportes.Location = new System.Drawing.Point(1286, 53);
            this.btBuscarImportes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btBuscarImportes.Name = "btBuscarImportes";
            this.btBuscarImportes.Size = new System.Drawing.Size(107, 32);
            this.btBuscarImportes.TabIndex = 12;
            this.btBuscarImportes.Text = "&Buscar";
            this.btBuscarImportes.UseVisualStyleBackColor = true;
            this.btBuscarImportes.Click += new System.EventHandler(this.btBuscarImportes_Click);
            // 
            // tabPageAsignacion
            // 
            this.tabPageAsignacion.Controls.Add(this.panel6);
            this.tabPageAsignacion.Controls.Add(this.pnBusqueda);
            this.tabPageAsignacion.Controls.Add(this.btCancelar);
            this.tabPageAsignacion.Controls.Add(this.btAceptar);
            this.tabPageAsignacion.Controls.Add(this.panelFiltros);
            this.tabPageAsignacion.Controls.Add(this.panel3);
            this.tabPageAsignacion.Location = new System.Drawing.Point(4, 29);
            this.tabPageAsignacion.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPageAsignacion.Name = "tabPageAsignacion";
            this.tabPageAsignacion.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPageAsignacion.Size = new System.Drawing.Size(1504, 714);
            this.tabPageAsignacion.TabIndex = 0;
            this.tabPageAsignacion.Text = "Asignación";
            this.tabPageAsignacion.UseVisualStyleBackColor = true;
            this.tabPageAsignacion.Click += new System.EventHandler(this.tabPageAsignacion_Click);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.txtbPuntosPedConAM);
            this.panel6.Controls.Add(this.label47);
            this.panel6.Controls.Add(this.txtbPuntosPedAM);
            this.panel6.Controls.Add(this.label26);
            this.panel6.Controls.Add(this.lblMissAM);
            this.panel6.Controls.Add(this.txtbCosteTotalAM);
            this.panel6.Controls.Add(this.label44);
            this.panel6.Controls.Add(this.txtbRentabilidadAM);
            this.panel6.Controls.Add(this.label43);
            this.panel6.Controls.Add(this.label42);
            this.panel6.Controls.Add(this.txtbDescMedioAM);
            this.panel6.Controls.Add(this.label3);
            this.panel6.Controls.Add(this.txtbBrutoPedAM);
            this.panel6.Location = new System.Drawing.Point(1146, 154);
            this.panel6.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(368, 472);
            this.panel6.TabIndex = 128;
            // 
            // txtbPuntosPedConAM
            // 
            this.txtbPuntosPedConAM.BackColor = System.Drawing.Color.White;
            this.txtbPuntosPedConAM.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtbPuntosPedConAM.Enabled = false;
            this.txtbPuntosPedConAM.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbPuntosPedConAM.Location = new System.Drawing.Point(201, 250);
            this.txtbPuntosPedConAM.Name = "txtbPuntosPedConAM";
            this.txtbPuntosPedConAM.ReadOnly = true;
            this.txtbPuntosPedConAM.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtbPuntosPedConAM.Size = new System.Drawing.Size(144, 26);
            this.txtbPuntosPedConAM.TabIndex = 112;
            this.txtbPuntosPedConAM.TabStop = false;
            this.txtbPuntosPedConAM.Text = "0";
            // 
            // label47
            // 
            this.label47.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label47.ForeColor = System.Drawing.Color.DarkRed;
            this.label47.Location = new System.Drawing.Point(20, 238);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(171, 51);
            this.label47.TabIndex = 111;
            this.label47.Text = "Puntos con Acciones de Marketing:";
            this.label47.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtbPuntosPedAM
            // 
            this.txtbPuntosPedAM.BackColor = System.Drawing.Color.White;
            this.txtbPuntosPedAM.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtbPuntosPedAM.Enabled = false;
            this.txtbPuntosPedAM.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbPuntosPedAM.Location = new System.Drawing.Point(201, 102);
            this.txtbPuntosPedAM.Name = "txtbPuntosPedAM";
            this.txtbPuntosPedAM.ReadOnly = true;
            this.txtbPuntosPedAM.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtbPuntosPedAM.Size = new System.Drawing.Size(144, 26);
            this.txtbPuntosPedAM.TabIndex = 110;
            this.txtbPuntosPedAM.TabStop = false;
            this.txtbPuntosPedAM.Text = "0";
            // 
            // label26
            // 
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.Black;
            this.label26.Location = new System.Drawing.Point(18, 104);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(177, 20);
            this.label26.TabIndex = 109;
            this.label26.Text = "Total Puntos";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMissAM
            // 
            this.lblMissAM.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMissAM.ForeColor = System.Drawing.Color.Red;
            this.lblMissAM.Location = new System.Drawing.Point(21, 295);
            this.lblMissAM.Margin = new System.Windows.Forms.Padding(0);
            this.lblMissAM.Name = "lblMissAM";
            this.lblMissAM.Size = new System.Drawing.Size(326, 163);
            this.lblMissAM.TabIndex = 107;
            this.lblMissAM.Text = "miss";
            this.lblMissAM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtbCosteTotalAM
            // 
            this.txtbCosteTotalAM.BackColor = System.Drawing.Color.White;
            this.txtbCosteTotalAM.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtbCosteTotalAM.Enabled = false;
            this.txtbCosteTotalAM.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbCosteTotalAM.Location = new System.Drawing.Point(201, 145);
            this.txtbCosteTotalAM.Name = "txtbCosteTotalAM";
            this.txtbCosteTotalAM.ReadOnly = true;
            this.txtbCosteTotalAM.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtbCosteTotalAM.Size = new System.Drawing.Size(144, 26);
            this.txtbCosteTotalAM.TabIndex = 105;
            this.txtbCosteTotalAM.TabStop = false;
            this.txtbCosteTotalAM.Text = "0 €";
            // 
            // label44
            // 
            this.label44.BackColor = System.Drawing.Color.Transparent;
            this.label44.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label44.ForeColor = System.Drawing.Color.Navy;
            this.label44.Location = new System.Drawing.Point(18, 122);
            this.label44.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(177, 70);
            this.label44.TabIndex = 104;
            this.label44.Text = "Total Coste Acciones de Marketing:";
            this.label44.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtbRentabilidadAM
            // 
            this.txtbRentabilidadAM.BackColor = System.Drawing.Color.White;
            this.txtbRentabilidadAM.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtbRentabilidadAM.Enabled = false;
            this.txtbRentabilidadAM.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbRentabilidadAM.Location = new System.Drawing.Point(201, 197);
            this.txtbRentabilidadAM.Name = "txtbRentabilidadAM";
            this.txtbRentabilidadAM.ReadOnly = true;
            this.txtbRentabilidadAM.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtbRentabilidadAM.Size = new System.Drawing.Size(144, 26);
            this.txtbRentabilidadAM.TabIndex = 103;
            this.txtbRentabilidadAM.TabStop = false;
            // 
            // label43
            // 
            this.label43.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label43.ForeColor = System.Drawing.Color.DarkRed;
            this.label43.Location = new System.Drawing.Point(18, 185);
            this.label43.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(174, 51);
            this.label43.TabIndex = 102;
            this.label43.Text = "Rentabilidad con Acciones de Marketing:";
            this.label43.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label42
            // 
            this.label42.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label42.ForeColor = System.Drawing.Color.Black;
            this.label42.Location = new System.Drawing.Point(17, 52);
            this.label42.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(180, 52);
            this.label42.TabIndex = 101;
            this.label42.Text = "Total Descuento Medio:";
            this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtbDescMedioAM
            // 
            this.txtbDescMedioAM.BackColor = System.Drawing.Color.White;
            this.txtbDescMedioAM.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtbDescMedioAM.Enabled = false;
            this.txtbDescMedioAM.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbDescMedioAM.Location = new System.Drawing.Point(201, 65);
            this.txtbDescMedioAM.Name = "txtbDescMedioAM";
            this.txtbDescMedioAM.ReadOnly = true;
            this.txtbDescMedioAM.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtbDescMedioAM.Size = new System.Drawing.Size(144, 26);
            this.txtbDescMedioAM.TabIndex = 100;
            this.txtbDescMedioAM.TabStop = false;
            this.txtbDescMedioAM.Text = "0%";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(18, 25);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(156, 31);
            this.label3.TabIndex = 98;
            this.label3.Text = "Total Importe Bruto:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtbBrutoPedAM
            // 
            this.txtbBrutoPedAM.BackColor = System.Drawing.Color.White;
            this.txtbBrutoPedAM.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtbBrutoPedAM.Enabled = false;
            this.txtbBrutoPedAM.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbBrutoPedAM.Location = new System.Drawing.Point(201, 28);
            this.txtbBrutoPedAM.Name = "txtbBrutoPedAM";
            this.txtbBrutoPedAM.ReadOnly = true;
            this.txtbBrutoPedAM.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtbBrutoPedAM.Size = new System.Drawing.Size(144, 26);
            this.txtbBrutoPedAM.TabIndex = 99;
            this.txtbBrutoPedAM.TabStop = false;
            this.txtbBrutoPedAM.Text = "0 €";
            // 
            // tabPageConsultaAsignaciones
            // 
            this.tabPageConsultaAsignaciones.Controls.Add(this.panel5);
            this.tabPageConsultaAsignaciones.Controls.Add(this.panel4);
            this.tabPageConsultaAsignaciones.Location = new System.Drawing.Point(4, 22);
            this.tabPageConsultaAsignaciones.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPageConsultaAsignaciones.Name = "tabPageConsultaAsignaciones";
            this.tabPageConsultaAsignaciones.Size = new System.Drawing.Size(1504, 721);
            this.tabPageConsultaAsignaciones.TabIndex = 2;
            this.tabPageConsultaAsignaciones.Text = "Consulta Asignaciones";
            this.tabPageConsultaAsignaciones.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.lblNumAsignaciones);
            this.panel5.Controls.Add(this.labelGradient5);
            this.panel5.Controls.Add(this.dataGridViewAsignaciones);
            this.panel5.Location = new System.Drawing.Point(0, 118);
            this.panel5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1876, 868);
            this.panel5.TabIndex = 127;
            // 
            // lblNumAsignaciones
            // 
            this.lblNumAsignaciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.lblNumAsignaciones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblNumAsignaciones.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumAsignaciones.ForeColor = System.Drawing.Color.Black;
            this.lblNumAsignaciones.Location = new System.Drawing.Point(1404, 7);
            this.lblNumAsignaciones.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNumAsignaciones.Name = "lblNumAsignaciones";
            this.lblNumAsignaciones.Size = new System.Drawing.Size(95, 24);
            this.lblNumAsignaciones.TabIndex = 95;
            this.lblNumAsignaciones.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelGradient5
            // 
            this.labelGradient5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGradient5.ForeColor = System.Drawing.Color.White;
            this.labelGradient5.GradientColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.labelGradient5.GradientColorTwo = System.Drawing.Color.White;
            this.labelGradient5.Location = new System.Drawing.Point(4, 5);
            this.labelGradient5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelGradient5.Name = "labelGradient5";
            this.labelGradient5.Size = new System.Drawing.Size(1491, 25);
            this.labelGradient5.TabIndex = 93;
            this.labelGradient5.Text = "Asignaciones de Acciones de Márketing a autopedidos";
            this.labelGradient5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dataGridViewAsignaciones
            // 
            this.dataGridViewAsignaciones.AllowUserToAddRows = false;
            this.dataGridViewAsignaciones.AllowUserToDeleteRows = false;
            this.dataGridViewAsignaciones.AllowUserToResizeRows = false;
            dataGridViewCellStyle84.BackColor = System.Drawing.Color.White;
            this.dataGridViewAsignaciones.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle84;
            this.dataGridViewAsignaciones.AutoGenerateColumns = false;
            this.dataGridViewAsignaciones.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewAsignaciones.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle85.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle85.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle85.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle85.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle85.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle85.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle85.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewAsignaciones.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle85;
            this.dataGridViewAsignaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAsignaciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn4,
            this.sNombre,
            this.codAsignacion,
            this.iIdAccion,
            this.sDescAccion,
            this.dataGridViewTextBoxColumn6,
            this.dFecEnvio,
            this.Estado,
            this.textoEstado});
            this.dataGridViewAsignaciones.DataMember = "ListaAsignacionesAutopedsSinAccMark";
            this.dataGridViewAsignaciones.DataSource = this.dsAccMark;
            dataGridViewCellStyle87.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle87.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle87.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle87.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle87.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle87.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle87.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewAsignaciones.DefaultCellStyle = dataGridViewCellStyle87;
            this.dataGridViewAsignaciones.Location = new System.Drawing.Point(6, 34);
            this.dataGridViewAsignaciones.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridViewAsignaciones.MultiSelect = false;
            this.dataGridViewAsignaciones.Name = "dataGridViewAsignaciones";
            this.dataGridViewAsignaciones.RowHeadersVisible = false;
            this.dataGridViewAsignaciones.RowHeadersWidth = 25;
            dataGridViewCellStyle88.ForeColor = System.Drawing.Color.Black;
            this.dataGridViewAsignaciones.RowsDefaultCellStyle = dataGridViewCellStyle88;
            this.dataGridViewAsignaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewAsignaciones.Size = new System.Drawing.Size(1489, 550);
            this.dataGridViewAsignaciones.TabIndex = 94;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "iIdDelegado";
            this.dataGridViewTextBoxColumn1.HeaderText = "iIdDelegado";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            this.dataGridViewTextBoxColumn1.Width = 5;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "NombreDel";
            this.dataGridViewTextBoxColumn2.HeaderText = "NombreDel";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "sIdCliente";
            this.dataGridViewTextBoxColumn4.HeaderText = "Cód. Cliente";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 120;
            // 
            // sNombre
            // 
            this.sNombre.DataPropertyName = "sNombre";
            this.sNombre.HeaderText = "Cliente";
            this.sNombre.Name = "sNombre";
            this.sNombre.Width = 400;
            // 
            // codAsignacion
            // 
            this.codAsignacion.DataPropertyName = "codAsignacion";
            this.codAsignacion.HeaderText = "Agrupador";
            this.codAsignacion.Name = "codAsignacion";
            this.codAsignacion.ReadOnly = true;
            this.codAsignacion.Width = 140;
            // 
            // iIdAccion
            // 
            this.iIdAccion.DataPropertyName = "iIdAccion";
            this.iIdAccion.HeaderText = "iIdAccion";
            this.iIdAccion.Name = "iIdAccion";
            this.iIdAccion.Visible = false;
            // 
            // sDescAccion
            // 
            this.sDescAccion.DataPropertyName = "sDescAccion";
            this.sDescAccion.HeaderText = "Accion Márketing";
            this.sDescAccion.Name = "sDescAccion";
            this.sDescAccion.Width = 500;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "ImporteBruto";
            dataGridViewCellStyle86.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle86.Format = "N2";
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle86;
            this.dataGridViewTextBoxColumn6.HeaderText = "Importe Bruto";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 120;
            // 
            // dFecEnvio
            // 
            this.dFecEnvio.DataPropertyName = "dFecEnvio";
            this.dFecEnvio.HeaderText = "Fecha Envío";
            this.dFecEnvio.Name = "dFecEnvio";
            this.dFecEnvio.ReadOnly = true;
            this.dFecEnvio.Width = 110;
            // 
            // Estado
            // 
            this.Estado.DataPropertyName = "Estado";
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.Visible = false;
            // 
            // textoEstado
            // 
            this.textoEstado.DataPropertyName = "textoEstado";
            this.textoEstado.HeaderText = "Estado";
            this.textoEstado.Name = "textoEstado";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.txtsIdClienteConsulta);
            this.panel4.Controls.Add(this.btBuscarClienteConsulta);
            this.panel4.Controls.Add(this.txtsClienteConsulta);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.labelGradient4);
            this.panel4.Controls.Add(this.btnBuscarAsignaciones);
            this.panel4.Location = new System.Drawing.Point(2, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1876, 116);
            this.panel4.TabIndex = 31;
            // 
            // txtsIdClienteConsulta
            // 
            this.txtsIdClienteConsulta.BackColor = System.Drawing.Color.White;
            this.txtsIdClienteConsulta.ForeColor = System.Drawing.Color.Black;
            this.txtsIdClienteConsulta.Location = new System.Drawing.Point(99, 54);
            this.txtsIdClienteConsulta.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtsIdClienteConsulta.MaxLength = 20;
            this.txtsIdClienteConsulta.Name = "txtsIdClienteConsulta";
            this.txtsIdClienteConsulta.Size = new System.Drawing.Size(190, 26);
            this.txtsIdClienteConsulta.TabIndex = 115;
            // 
            // btBuscarClienteConsulta
            // 
            this.btBuscarClienteConsulta.Image = ((System.Drawing.Image)(resources.GetObject("btBuscarClienteConsulta.Image")));
            this.btBuscarClienteConsulta.Location = new System.Drawing.Point(795, 52);
            this.btBuscarClienteConsulta.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btBuscarClienteConsulta.Name = "btBuscarClienteConsulta";
            this.btBuscarClienteConsulta.Size = new System.Drawing.Size(33, 34);
            this.btBuscarClienteConsulta.TabIndex = 117;
            this.btBuscarClienteConsulta.TabStop = false;
            this.btBuscarClienteConsulta.UseVisualStyleBackColor = true;
            this.btBuscarClienteConsulta.Click += new System.EventHandler(this.btBuscarClienteConsulta_Click);
            // 
            // txtsClienteConsulta
            // 
            this.txtsClienteConsulta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtsClienteConsulta.ForeColor = System.Drawing.Color.Black;
            this.txtsClienteConsulta.Location = new System.Drawing.Point(291, 54);
            this.txtsClienteConsulta.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtsClienteConsulta.Name = "txtsClienteConsulta";
            this.txtsClienteConsulta.ReadOnly = true;
            this.txtsClienteConsulta.Size = new System.Drawing.Size(502, 26);
            this.txtsClienteConsulta.TabIndex = 116;
            this.txtsClienteConsulta.TabStop = false;
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(26, 57);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 25);
            this.label4.TabIndex = 118;
            this.label4.Text = "Cliente:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelGradient4
            // 
            this.labelGradient4.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelGradient4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGradient4.ForeColor = System.Drawing.Color.White;
            this.labelGradient4.GradientColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.labelGradient4.GradientColorTwo = System.Drawing.Color.White;
            this.labelGradient4.Location = new System.Drawing.Point(0, 0);
            this.labelGradient4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelGradient4.Name = "labelGradient4";
            this.labelGradient4.Size = new System.Drawing.Size(1874, 25);
            this.labelGradient4.TabIndex = 92;
            this.labelGradient4.Text = "Consulta de asignaciones acciones de márketing a autopedidos";
            // 
            // btnBuscarAsignaciones
            // 
            this.btnBuscarAsignaciones.ForeColor = System.Drawing.Color.Black;
            this.btnBuscarAsignaciones.Location = new System.Drawing.Point(1089, 52);
            this.btnBuscarAsignaciones.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnBuscarAsignaciones.Name = "btnBuscarAsignaciones";
            this.btnBuscarAsignaciones.Size = new System.Drawing.Size(130, 37);
            this.btnBuscarAsignaciones.TabIndex = 12;
            this.btnBuscarAsignaciones.Text = "&Buscar";
            this.btnBuscarAsignaciones.UseVisualStyleBackColor = true;
            this.btnBuscarAsignaciones.Click += new System.EventHandler(this.btnBuscarAsignaciones_Click);
            // 
            // frmAutopedAccMark
            // 
            this.ClientSize = new System.Drawing.Size(1516, 757);
            this.Controls.Add(this.tabControlX);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmAutopedAccMark";
            this.Text = "Asignación de Acciones de Marketing a Autopedidos";
            this.Load += new System.EventHandler(this.frmAutopedAccMark_Load);
            this.panelFiltros.ResumeLayout(false);
            this.panelFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsFormularios1)).EndInit();
            this.pnBusqueda.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAccMark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPedidos1)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAccMark)).EndInit();
            this.tabControlX.ResumeLayout(false);
            this.tabPageConsultaImportes.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewImportes)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPageAsignacion.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.tabPageConsultaAsignaciones.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAsignaciones)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelFiltros;
        private System.Windows.Forms.Label lblAvisoVersion;
        private System.Windows.Forms.TextBox txtsIdCliente;
        private System.Windows.Forms.Button btBuscarCliente;
        private System.Windows.Forms.TextBox txtsCliente;
        private System.Windows.Forms.Label label9;
        private Controles.LabelGradient lblTitulo;
        private System.Windows.Forms.Button btnBuscar;

        private System.Data.SqlClient.SqlConnection sqlConn;
        private System.Data.SqlClient.SqlDataAdapter sqldaListaAccionesMarketing;
        private System.Data.SqlClient.SqlCommand sqlCmdListaAccionesMarketing;        
        private System.Data.SqlClient.SqlDataAdapter sqldaListaAutoPedsSinAccMark;
        private System.Data.SqlClient.SqlCommand sqlCmdListaAutoPedsSinAccMark;
        private System.Data.SqlClient.SqlDataAdapter sqldaListaLinsAutoPedsSinAccMark;
        private System.Data.SqlClient.SqlCommand sqlCmdListaLinsAutoPedsSinAccMark;
        private System.Data.SqlClient.SqlCommand sqlGetNumAcckMarkADescartar;
        private System.Data.SqlClient.SqlCommand sqlGetNewIdGrupoAutoPedAcciones;
        private System.Data.SqlClient.SqlCommand sqlCmdSetAutoPedAcciones;
        private System.Data.SqlClient.SqlCommand sqlCmdSetPedAcciones;
        private System.Data.SqlClient.SqlDataAdapter sqldaListaImportes;
        private System.Data.SqlClient.SqlCommand sqlCmdListaImportesClientesSAPConAutopedsSinAccMark;
        private System.Data.SqlClient.SqlDataAdapter sqldaListaAsignaciones;
        private System.Data.SqlClient.SqlCommand sqlCmdListaAsignacionesAutopedsSinAccMark;
        private System.Data.SqlClient.SqlCommand sqlCmdGetRentabilidadColor;
        private System.Data.SqlClient.SqlCommand sqlCmdGetMaterialesNoRentabilidad;
        private System.Data.SqlClient.SqlCommand sqlCmdGetCampanyasNoRentabilidad;
        private System.Data.SqlClient.SqlDataAdapter sqldaAccMarkExcluidas;
        private System.Data.SqlClient.SqlCommand sqlCmdAccMarkExcluidas;
        private System.Data.SqlClient.SqlCommand sqlCmdMaxAccMark; 

        private DataSets.dsAccionesMarketing dsAccMark;
        private GESTCRM.Formularios.DataSets.dsPedidos dsPedidos1;
        private System.Windows.Forms.Panel pnBusqueda;
        private System.Windows.Forms.DataGridView dgvPeds;
        private System.Windows.Forms.Label lblNumReg;
        private Controles.LabelGradient labelGradient2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblNumRegAccMark;
        private Controles.LabelGradient labelGradientAccMark;
        private System.Windows.Forms.DataGridView dataGridViewAccMark;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.Button btAceptar;
        private System.Windows.Forms.TabControl tabControlX;
        private System.Windows.Forms.TabPage tabPageAsignacion;
        private System.Windows.Forms.TabPage tabPageConsultaImportes;
        private System.Windows.Forms.TabPage tabPageConsultaAsignaciones;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txbNombreCliente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbCodCliente;
        private System.Windows.Forms.Label label2;
        private Controles.LabelGradient labelGradient1;
        private System.Windows.Forms.Button btBuscarImportes;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblNumImportes;
        private Controles.LabelGradient labelGradient3;
        private System.Windows.Forms.DataGridView dataGridViewImportes;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtsIdClienteConsulta;
        private System.Windows.Forms.Button btBuscarClienteConsulta;
        private System.Windows.Forms.TextBox txtsClienteConsulta;
        private System.Windows.Forms.Label label4;
        private Controles.LabelGradient labelGradient4;
        private System.Windows.Forms.Button btnBuscarAsignaciones;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lblNumAsignaciones;
        private Controles.LabelGradient labelGradient5;
        private System.Windows.Forms.DataGridView dataGridViewAsignaciones;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label lblMissAM;
        private System.Windows.Forms.TextBox txtbCosteTotalAM;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.TextBox txtbRentabilidadAM;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.TextBox txtbDescMedioAM;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtbBrutoPedAM;
        private dsFormularios dsFormularios1;
        private System.Windows.Forms.DataGridViewTextBoxColumn iIdDelegadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreDelDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iIdClienteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sIdClienteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tNombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn importeBrutoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sIdPedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn dFechaPedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn fImporteBruto;
        private System.Windows.Forms.DataGridViewTextBoxColumn fImporteNeto;
        private System.Windows.Forms.DataGridViewCheckBoxColumn selected;
        private System.Windows.Forms.DataGridViewTextBoxColumn fImpMax;
        private System.Windows.Forms.DataGridViewTextBoxColumn iMaxAEntregar;
        private System.Windows.Forms.DataGridViewTextBoxColumn fCosteTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn iIdAccionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sIdAccionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sDescAccionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sIdTipoAccionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iUnidadesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iNumElemEntregarDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fCosteTotalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dFechaCreacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dFechaIniDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dFechaFinDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sObservacionesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sIdTipoImputacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dFUMDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iEstadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn bEnviadoPDADataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnidadesAEntregar;
        private System.Windows.Forms.DataGridViewTextBoxColumn fImpMin;
        private System.Windows.Forms.DataGridViewTextBoxColumn sIdProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn fCosteUnitarioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn bIndepe;
        private System.Windows.Forms.DataGridViewTextBoxColumn fRentabilidad;
        private System.Windows.Forms.DataGridViewCheckBoxColumn bSuma;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn sNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn codAsignacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn iIdAccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn sDescAccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dFecEnvio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn textoEstado;
        private System.Windows.Forms.TextBox txtbPuntosPedAM;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.TextBox txtbPuntosPedConAM;
        //---- GSG (06/03/2021)
        private System.Data.SqlClient.SqlDataAdapter sqldaCodsAccMark;
        private System.Data.SqlClient.SqlCommand sqlCmdListaCodsAccMark;
        private System.Data.SqlClient.SqlCommand sqlCmdSetPedidosCab;
        private System.Data.SqlClient.SqlCommand sqlCmdSetPedidosLin;
        private System.Data.SqlClient.SqlDataAdapter sqldaCodsAccMarkPicking;
        private System.Data.SqlClient.SqlCommand sqlCmdListaCodsAccMarkPicking;
    }
}