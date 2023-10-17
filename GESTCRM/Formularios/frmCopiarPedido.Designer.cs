namespace GESTCRM.Formularios
{
    partial class frmCopiarPedido
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCopiarPedido));
            this.ucBotoneraSecundaria1 = new GESTCRM.Controles.ucBotoneraSecundaria();
            this.panelFiltros = new System.Windows.Forms.Panel();
            this.chkBoxFlexible = new System.Windows.Forms.CheckBox();
            this.lblAvisoVersion = new System.Windows.Forms.Label();
            this.cBoxCampanyas = new System.Windows.Forms.ComboBox();
            this.txtsIdCliente = new System.Windows.Forms.TextBox();
            this.btBuscarCliente = new System.Windows.Forms.Button();
            this.txtsCliente = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lblTitulo = new GESTCRM.Controles.LabelGradient();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dsFormularios1 = new GESTCRM.Formularios.dsFormularios();
            this.sqldaListaBuscaPedidos = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand4 = new System.Data.SqlClient.SqlCommand();
            this.sqlConn = new System.Data.SqlClient.SqlConnection();
            this.sqlSelectCommand4CECL = new System.Data.SqlClient.SqlCommand();
            this.sqldaListaAccMarkCampByCli = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCmdListaAccMarkCampByCli = new System.Data.SqlClient.SqlCommand();
            this.sqldaListaCampanyasPedido = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCmdListaCampanyasPedido = new System.Data.SqlClient.SqlCommand();
            this.sqldaListaCampanyas = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCmdListaCampanyasNEW = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdListaCampanyas = new System.Data.SqlClient.SqlCommand();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblCuentaPedidos = new System.Windows.Forms.Label();
            this.labelGradient6 = new GESTCRM.Controles.LabelGradient();
            this.dgCabeceraPedidos = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.sIdPedido = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dFechaPedido = new System.Windows.Forms.DataGridTextBoxColumn();
            this.fImporteBruto = new System.Windows.Forms.DataGridTextBoxColumn();
            this.sIdTipoPedido = new System.Windows.Forms.DataGridTextBoxColumn();
            this.sNombre = new System.Windows.Forms.DataGridTextBoxColumn();
            this.sIdCliente1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dsAccionesMarketing1 = new GESTCRM.Formularios.DataSets.dsAccionesMarketing();
            this.panelFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsFormularios1)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCabeceraPedidos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAccionesMarketing1)).BeginInit();
            this.SuspendLayout();
            // 
            // ucBotoneraSecundaria1
            // 
            this.ucBotoneraSecundaria1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(117)))), ((int)(((byte)(1)))));
            this.ucBotoneraSecundaria1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucBotoneraSecundaria1.ForeColor = System.Drawing.Color.Black;
            this.ucBotoneraSecundaria1.Location = new System.Drawing.Point(0, 0);
            this.ucBotoneraSecundaria1.Name = "ucBotoneraSecundaria1";
            this.ucBotoneraSecundaria1.Size = new System.Drawing.Size(1510, 38);
            this.ucBotoneraSecundaria1.TabIndex = 26;
            // 
            // panelFiltros
            // 
            this.panelFiltros.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelFiltros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelFiltros.Controls.Add(this.chkBoxFlexible);
            this.panelFiltros.Controls.Add(this.lblAvisoVersion);
            this.panelFiltros.Controls.Add(this.cBoxCampanyas);
            this.panelFiltros.Controls.Add(this.txtsIdCliente);
            this.panelFiltros.Controls.Add(this.btBuscarCliente);
            this.panelFiltros.Controls.Add(this.txtsCliente);
            this.panelFiltros.Controls.Add(this.label9);
            this.panelFiltros.Controls.Add(this.lblTitulo);
            this.panelFiltros.Controls.Add(this.btnBuscar);
            this.panelFiltros.Location = new System.Drawing.Point(6, 43);
            this.panelFiltros.Name = "panelFiltros";
            this.panelFiltros.Size = new System.Drawing.Size(1492, 76);
            this.panelFiltros.TabIndex = 28;
            // 
            // chkBoxFlexible
            // 
            this.chkBoxFlexible.AutoSize = true;
            this.chkBoxFlexible.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBoxFlexible.ForeColor = System.Drawing.Color.Black;
            this.chkBoxFlexible.Location = new System.Drawing.Point(1221, 34);
            this.chkBoxFlexible.Name = "chkBoxFlexible";
            this.chkBoxFlexible.Size = new System.Drawing.Size(223, 24);
            this.chkBoxFlexible.TabIndex = 127;
            this.chkBoxFlexible.Text = "Importar a campaña flexible";
            this.chkBoxFlexible.UseVisualStyleBackColor = true;
            // 
            // lblAvisoVersion
            // 
            this.lblAvisoVersion.AutoSize = true;
            this.lblAvisoVersion.BackColor = System.Drawing.Color.Yellow;
            this.lblAvisoVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvisoVersion.ForeColor = System.Drawing.Color.Red;
            this.lblAvisoVersion.Location = new System.Drawing.Point(254, 0);
            this.lblAvisoVersion.Name = "lblAvisoVersion";
            this.lblAvisoVersion.Size = new System.Drawing.Size(57, 20);
            this.lblAvisoVersion.TabIndex = 126;
            this.lblAvisoVersion.Text = "label1";
            // 
            // cBoxCampanyas
            // 
            this.cBoxCampanyas.BackColor = System.Drawing.Color.White;
            this.cBoxCampanyas.DisplayMember = "NombreCampanya";
            this.cBoxCampanyas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxCampanyas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cBoxCampanyas.ForeColor = System.Drawing.Color.Black;
            this.cBoxCampanyas.Location = new System.Drawing.Point(937, 34);
            this.cBoxCampanyas.Name = "cBoxCampanyas";
            this.cBoxCampanyas.Size = new System.Drawing.Size(265, 21);
            this.cBoxCampanyas.TabIndex = 125;
            this.cBoxCampanyas.ValueMember = "idCampanya";
            this.cBoxCampanyas.Visible = false;
            // 
            // txtsIdCliente
            // 
            this.txtsIdCliente.BackColor = System.Drawing.Color.White;
            this.txtsIdCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsIdCliente.ForeColor = System.Drawing.Color.Black;
            this.txtsIdCliente.Location = new System.Drawing.Point(95, 35);
            this.txtsIdCliente.MaxLength = 20;
            this.txtsIdCliente.Name = "txtsIdCliente";
            this.txtsIdCliente.Size = new System.Drawing.Size(168, 26);
            this.txtsIdCliente.TabIndex = 115;
            // 
            // btBuscarCliente
            // 
            this.btBuscarCliente.Image = ((System.Drawing.Image)(resources.GetObject("btBuscarCliente.Image")));
            this.btBuscarCliente.Location = new System.Drawing.Point(699, 34);
            this.btBuscarCliente.Name = "btBuscarCliente";
            this.btBuscarCliente.Size = new System.Drawing.Size(28, 28);
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
            this.txtsCliente.Location = new System.Drawing.Point(267, 35);
            this.txtsCliente.Name = "txtsCliente";
            this.txtsCliente.ReadOnly = true;
            this.txtsCliente.Size = new System.Drawing.Size(431, 26);
            this.txtsCliente.TabIndex = 116;
            this.txtsCliente.TabStop = false;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(30, 37);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 16);
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
            this.lblTitulo.Size = new System.Drawing.Size(1490, 22);
            this.lblTitulo.TabIndex = 92;
            this.lblTitulo.Text = "Copia de un pedido de cliente";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.Color.Black;
            this.btnBuscar.Location = new System.Drawing.Point(825, 35);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(87, 29);
            this.btnBuscar.TabIndex = 12;
            this.btnBuscar.Text = "Aceptar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // dsFormularios1
            // 
            this.dsFormularios1.DataSetName = "dsFormularios";
            this.dsFormularios1.Locale = new System.Globalization.CultureInfo("es-ES");
            this.dsFormularios1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sqldaListaBuscaPedidos
            // 
            this.sqldaListaBuscaPedidos.SelectCommand = this.sqlSelectCommand4;
            this.sqldaListaBuscaPedidos.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaBuscaPedidos", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("sIdPedido", "sIdPedido"),
                        new System.Data.Common.DataColumnMapping("sIdTipoPedido", "sIdTipoPedido"),
                        new System.Data.Common.DataColumnMapping("sLiteral", "sLiteral"),
                        new System.Data.Common.DataColumnMapping("sIdCliente", "sIdCliente"),
                        new System.Data.Common.DataColumnMapping("sNombre", "sNombre"),
                        new System.Data.Common.DataColumnMapping("sIdCliente1", "sIdCliente1"),
                        new System.Data.Common.DataColumnMapping("sNombre1", "sNombre1"),
                        new System.Data.Common.DataColumnMapping("dFechaPedido", "dFechaPedido"),
                        new System.Data.Common.DataColumnMapping("dFechaPreferente", "dFechaPreferente"),
                        new System.Data.Common.DataColumnMapping("dFechaFijada", "dFechaFijada"),
                        new System.Data.Common.DataColumnMapping("fImporte", "fImporte"),
                        new System.Data.Common.DataColumnMapping("fImporteBruto", "fImporteBruto"),
                        new System.Data.Common.DataColumnMapping("fDescuento", "fDescuento"),
                        new System.Data.Common.DataColumnMapping("sIdTipoCampanya", "sIdTipoCampanya"),
                        new System.Data.Common.DataColumnMapping("sLiteral1", "sLiteral1"),
                        new System.Data.Common.DataColumnMapping("tObservaciones", "tObservaciones"),
                        new System.Data.Common.DataColumnMapping("iIdDelegado", "iIdDelegado"),
                        new System.Data.Common.DataColumnMapping("iIdCliente", "iIdCliente"),
                        new System.Data.Common.DataColumnMapping("iIdCliente1", "iIdCliente1"),
                        new System.Data.Common.DataColumnMapping("sNombre2", "sNombre2"),
                        new System.Data.Common.DataColumnMapping("bEnviadoCEN", "bEnviadoCEN"),
                        new System.Data.Common.DataColumnMapping("dto", "dto"),
                        new System.Data.Common.DataColumnMapping("sIdEstEntPedido", "sIdEstEntPedido"),
                        new System.Data.Common.DataColumnMapping("tIdEstEntPedido", "tIdEstEntPedido"),
                        new System.Data.Common.DataColumnMapping("sIdEstFacPedido", "sIdEstFacPedido"),
                        new System.Data.Common.DataColumnMapping("tIdEstFacPedido", "tIdEstFacPedido")})});
            // 
            // sqlSelectCommand4
            // 
            this.sqlSelectCommand4.CommandText = "[ListaBuscaPedidos]";
            this.sqlSelectCommand4.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand4.Connection = this.sqlConn;
            this.sqlSelectCommand4.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdDelegado", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sIdCliente", System.Data.SqlDbType.VarChar, 20),
            new System.Data.SqlClient.SqlParameter("@sIdDestinatario", System.Data.SqlDbType.VarChar, 20),
            new System.Data.SqlClient.SqlParameter("@sIdTipoCampanya", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@dFechaPedido", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@dFechaPedidoEntre", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@sIdPedido", System.Data.SqlDbType.VarChar, 12),
            new System.Data.SqlClient.SqlParameter("@sIdTipoPedido", System.Data.SqlDbType.VarChar, 4),
            new System.Data.SqlClient.SqlParameter("@counter", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@EstEntPedido", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@EstFacPedido", System.Data.SqlDbType.VarChar, 10)});
            // 
            // sqlConn
            // 
            this.sqlConn.FireInfoMessageEventOnUserErrors = false;
            // 
            // sqlSelectCommand4CECL
            // 
            this.sqlSelectCommand4CECL.CommandText = "[ListaBuscaPedidosCECL]";
            this.sqlSelectCommand4CECL.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand4CECL.Connection = this.sqlConn;
            this.sqlSelectCommand4CECL.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdDelegado", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sIdCliente", System.Data.SqlDbType.VarChar, 20),
            new System.Data.SqlClient.SqlParameter("@sIdDestinatario", System.Data.SqlDbType.VarChar, 20),
            new System.Data.SqlClient.SqlParameter("@sIdTipoCampanya", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@dFechaPedido", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@dFechaPedidoEntre", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@sIdPedido", System.Data.SqlDbType.VarChar, 12),
            new System.Data.SqlClient.SqlParameter("@sIdTipoPedido", System.Data.SqlDbType.VarChar, 4),
            new System.Data.SqlClient.SqlParameter("@counter", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@EstEntPedido", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@EstFacPedido", System.Data.SqlDbType.VarChar, 10)});
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
            // sqldaListaCampanyasPedido
            // 
            this.sqldaListaCampanyasPedido.SelectCommand = this.sqlCmdListaCampanyasPedido;
            this.sqldaListaCampanyasPedido.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaCampanyasPedido", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("idCampanya", "idCampanya")})});
            // 
            // sqlCmdListaCampanyasPedido
            // 
            this.sqlCmdListaCampanyasPedido.CommandText = "[ListaCampanyasPedido]";
            this.sqlCmdListaCampanyasPedido.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdListaCampanyasPedido.Connection = this.sqlConn;
            this.sqlCmdListaCampanyasPedido.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@sIdPedido", System.Data.SqlDbType.VarChar, 12)});
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
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.lblCuentaPedidos);
            this.panel4.Controls.Add(this.labelGradient6);
            this.panel4.Controls.Add(this.dgCabeceraPedidos);
            this.panel4.Location = new System.Drawing.Point(6, 124);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1492, 651);
            this.panel4.TabIndex = 29;
            // 
            // lblCuentaPedidos
            // 
            this.lblCuentaPedidos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.lblCuentaPedidos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCuentaPedidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCuentaPedidos.ForeColor = System.Drawing.Color.Black;
            this.lblCuentaPedidos.Location = new System.Drawing.Point(1403, 0);
            this.lblCuentaPedidos.Name = "lblCuentaPedidos";
            this.lblCuentaPedidos.Size = new System.Drawing.Size(85, 18);
            this.lblCuentaPedidos.TabIndex = 88;
            this.lblCuentaPedidos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelGradient6
            // 
            this.labelGradient6.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelGradient6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGradient6.ForeColor = System.Drawing.Color.White;
            this.labelGradient6.GradientColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.labelGradient6.GradientColorTwo = System.Drawing.Color.White;
            this.labelGradient6.Location = new System.Drawing.Point(0, 0);
            this.labelGradient6.Name = "labelGradient6";
            this.labelGradient6.Size = new System.Drawing.Size(1488, 18);
            this.labelGradient6.TabIndex = 87;
            this.labelGradient6.Text = "Pedidos";
            this.labelGradient6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgCabeceraPedidos
            // 
            this.dgCabeceraPedidos.BackgroundColor = System.Drawing.Color.White;
            this.dgCabeceraPedidos.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.dgCabeceraPedidos.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgCabeceraPedidos.CaptionText = "Pedidos";
            this.dgCabeceraPedidos.CaptionVisible = false;
            this.dgCabeceraPedidos.DataMember = "ListaBuscaPedidos";
            this.dgCabeceraPedidos.DataSource = this.dsFormularios1;
            this.dgCabeceraPedidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgCabeceraPedidos.HeaderBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgCabeceraPedidos.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgCabeceraPedidos.Location = new System.Drawing.Point(0, 20);
            this.dgCabeceraPedidos.Name = "dgCabeceraPedidos";
            this.dgCabeceraPedidos.ParentRowsBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgCabeceraPedidos.ReadOnly = true;
            this.dgCabeceraPedidos.RowHeaderWidth = 15;
            this.dgCabeceraPedidos.Size = new System.Drawing.Size(1485, 624);
            this.dgCabeceraPedidos.TabIndex = 0;
            this.dgCabeceraPedidos.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.DataGrid = this.dgCabeceraPedidos;
            this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.sIdPedido,
            this.dFechaPedido,
            this.fImporteBruto,
            this.sIdTipoPedido,
            this.sNombre,
            this.sIdCliente1});
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle1.MappingName = "ListaBuscaPedidos";
            this.dataGridTableStyle1.ReadOnly = true;
            this.dataGridTableStyle1.RowHeaderWidth = 15;
            // 
            // sIdPedido
            // 
            this.sIdPedido.Format = "";
            this.sIdPedido.FormatInfo = null;
            this.sIdPedido.HeaderText = "Pedido";
            this.sIdPedido.MappingName = "sIdPedido";
            this.sIdPedido.ReadOnly = true;
            this.sIdPedido.Width = 140;
            // 
            // dFechaPedido
            // 
            this.dFechaPedido.Format = "";
            this.dFechaPedido.FormatInfo = null;
            this.dFechaPedido.HeaderText = "Fecha";
            this.dFechaPedido.MappingName = "dFechaPedido";
            this.dFechaPedido.ReadOnly = true;
            this.dFechaPedido.Width = 102;
            // 
            // fImporteBruto
            // 
            this.fImporteBruto.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.fImporteBruto.Format = "N2";
            this.fImporteBruto.FormatInfo = null;
            this.fImporteBruto.HeaderText = "Importe Bruto .";
            this.fImporteBruto.MappingName = "fImporteBruto";
            this.fImporteBruto.NullText = "0";
            this.fImporteBruto.ReadOnly = true;
            this.fImporteBruto.Width = 120;
            // 
            // sIdTipoPedido
            // 
            this.sIdTipoPedido.Format = "";
            this.sIdTipoPedido.FormatInfo = null;
            this.sIdTipoPedido.HeaderText = "Tipo pedido";
            this.sIdTipoPedido.MappingName = "sIdTipoPedido";
            this.sIdTipoPedido.ReadOnly = true;
            this.sIdTipoPedido.Width = 120;
            // 
            // sNombre
            // 
            this.sNombre.Format = "";
            this.sNombre.FormatInfo = null;
            this.sNombre.HeaderText = "Cliente";
            this.sNombre.MappingName = "sNombre";
            this.sNombre.Width = 500;
            // 
            // sIdCliente1
            // 
            this.sIdCliente1.Format = "";
            this.sIdCliente1.FormatInfo = null;
            this.sIdCliente1.HeaderText = "Mayorista";
            this.sIdCliente1.MappingName = "sIdCliente1";
            this.sIdCliente1.Width = 0;
            // 
            // dsAccionesMarketing1
            // 
            this.dsAccionesMarketing1.DataSetName = "dsAccionesMarketing";
            this.dsAccionesMarketing1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // frmCopiarPedido
            // 
            this.ClientSize = new System.Drawing.Size(1510, 787);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panelFiltros);
            this.Controls.Add(this.ucBotoneraSecundaria1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCopiarPedido";
            this.Text = "Crear pedido a partir de uno existente";
            this.Load += new System.EventHandler(this.frmCopiarPedido_Load);
            this.panelFiltros.ResumeLayout(false);
            this.panelFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsFormularios1)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgCabeceraPedidos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAccionesMarketing1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controles.ucBotoneraSecundaria ucBotoneraSecundaria1;
        private System.Windows.Forms.Panel panelFiltros;
        private System.Windows.Forms.TextBox txtsIdCliente;
        private System.Windows.Forms.Button btBuscarCliente;
        private System.Windows.Forms.TextBox txtsCliente;
        private System.Windows.Forms.Label label9;
        private Controles.LabelGradient lblTitulo;
        private System.Windows.Forms.Button btnBuscar;
        private dsFormularios dsFormularios1;
        private System.Data.SqlClient.SqlDataAdapter sqldaListaBuscaPedidos;
        private System.Data.SqlClient.SqlCommand sqlSelectCommand4;
        private System.Data.SqlClient.SqlCommand sqlSelectCommand4CECL; //---- GSG CECL 19/05/2016
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblCuentaPedidos;
        private Controles.LabelGradient labelGradient6;
        private System.Windows.Forms.DataGrid dgCabeceraPedidos;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private System.Windows.Forms.DataGridTextBoxColumn sIdPedido;
        private System.Windows.Forms.DataGridTextBoxColumn dFechaPedido;
        private System.Windows.Forms.DataGridTextBoxColumn fImporteBruto;
        private System.Data.SqlClient.SqlConnection sqlConn;
        private System.Windows.Forms.DataGridTextBoxColumn sNombre;
        private DataSets.dsAccionesMarketing dsAccionesMarketing1;
        private System.Data.SqlClient.SqlDataAdapter sqldaListaAccMarkCampByCli;
        private System.Data.SqlClient.SqlCommand sqlCmdListaAccMarkCampByCli;
        private System.Data.SqlClient.SqlDataAdapter sqldaListaCampanyasPedido;
        private System.Data.SqlClient.SqlCommand sqlCmdListaCampanyasPedido;
        private System.Windows.Forms.ComboBox cBoxCampanyas;
        private System.Data.SqlClient.SqlDataAdapter sqldaListaCampanyas;
        private System.Data.SqlClient.SqlCommand sqlCmdListaCampanyas;
        private System.Data.SqlClient.SqlCommand sqlCmdListaCampanyasNEW;
        private System.Windows.Forms.DataGridTextBoxColumn sIdTipoPedido;
        private System.Windows.Forms.Label lblAvisoVersion;
        private System.Windows.Forms.CheckBox chkBoxFlexible;
        private System.Windows.Forms.DataGridTextBoxColumn sIdCliente1;
    }
}