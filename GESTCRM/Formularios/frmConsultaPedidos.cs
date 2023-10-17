using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Drawing2D;


namespace GESTCRM.Formularios
{
    /// <summary>
    /// Descripción breve de frmConsultaPedidos.
    /// </summary>
    public class frmConsultaPedidos : System.Windows.Forms.Form
    {
        private int iIdCliente = -1;
        private int iIdDestinatario = -1;

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox cboDelegado;
        private System.Windows.Forms.Label lblDelegado;
        private System.Windows.Forms.Label lblTipoPedido;
        private System.Windows.Forms.TextBox txbsIdPedido;
        private System.Windows.Forms.Label lbsIdPedido;
        private System.Windows.Forms.ComboBox cboTipoCampanya;
        private System.Windows.Forms.Label lblTipoCampanya;
        private System.Windows.Forms.Label lblFechaPedido;
        private System.Data.SqlClient.SqlConnection sqlConn;
        private GESTCRM.Formularios.dsFormularios dsFormularios1;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private System.Data.SqlClient.SqlDataAdapter sqldaListaDelegados;
        private System.Data.SqlClient.SqlDataAdapter sqldaTipoPedido;
        private System.Windows.Forms.ComboBox cboTipoPedido;
        private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btBuscarCliente;
        private System.Windows.Forms.TextBox txtClienteSAP;
        private System.Windows.Forms.TextBox txtsCliente;
        private System.Data.SqlClient.SqlDataAdapter sqldaListaBuscaPedidos;
        private System.Windows.Forms.DataGrid dgCabeceraPedidos;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridTextBoxColumn sIdPedido;
        private System.Windows.Forms.DataGridTextBoxColumn sIdTipoPedido;
        private System.Windows.Forms.DataGridTextBoxColumn sTipoPedido;
        private System.Windows.Forms.DataGridTextBoxColumn sIdCliente;
        private System.Windows.Forms.DataGridTextBoxColumn sNomCliente;
        private System.Windows.Forms.DataGridTextBoxColumn sIdDestinatario;
        private System.Windows.Forms.DataGridTextBoxColumn sNomDest;
        private System.Windows.Forms.DataGridTextBoxColumn fImporte;
        //---- GSG (28/01/2011)
        private System.Windows.Forms.DataGridTextBoxColumn fImporteBruto;
        //---- FI GSG
        private System.Windows.Forms.DataGridTextBoxColumn fDescuento;
        private System.Windows.Forms.DataGridTextBoxColumn sIdTipoCampanya;
        private System.Windows.Forms.DataGridTextBoxColumn sTipoCampanya;
        private System.Windows.Forms.DataGridTextBoxColumn dFechaPedido;
        private System.Windows.Forms.DataGridTextBoxColumn dFechaPreferente;
        private System.Windows.Forms.DataGridTextBoxColumn dFechaFijada;
        private System.Windows.Forms.DataGridTextBoxColumn bEnviadoCen;
        private System.Windows.Forms.Label lblObs;
        private System.Windows.Forms.TextBox txbObs;
        private System.Windows.Forms.Label lblFechaFij;
        private System.Windows.Forms.Label lblFechaPref;
        private System.Windows.Forms.DataGridTextBoxColumn tObservaciones;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.TextBox txtFechaPref;
        private System.Windows.Forms.TextBox txtFechaFij;
        private System.Data.SqlClient.SqlDataAdapter sqldaListaLineasPedidos;
        private System.Data.SqlClient.SqlCommand sqlSelectCommand5;
        private System.Windows.Forms.ToolTip toolTipConsultaPedidos;
        private System.Windows.Forms.DataGridTextBoxColumn iIdDelegado;
        private System.Windows.Forms.PictureBox pcbFechaPref;
        private System.Windows.Forms.DateTimePicker dtpFechaPedido;
        private System.Windows.Forms.DataGridTextBoxColumn sDelegado;
        private System.Windows.Forms.ContextMenu contextMenu1;
        private System.Data.SqlClient.SqlCommand sqlcmdSetPedidosCab;
        private System.Data.SqlClient.SqlCommand sqlcmDelPedidoRetenido;
        private GESTCRM.Controles.ucBotoneraSecundaria ucBotoneraSecundaria1;
        private System.Data.SqlClient.SqlCommand sqlcmdSetPedidosLin;
        private System.Windows.Forms.Button btBuscarDestinatario;
        private System.Windows.Forms.TextBox txtDestinatarioSAP;
        private System.Windows.Forms.TextBox txtsDestinatario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel4;
        private GESTCRM.Controles.LabelGradient labelGradient6;
        private System.Windows.Forms.Label lblCuentaPedidos;
        private GESTCRM.Controles.LabelGradient labelGradient1;
        private System.Windows.Forms.Label lblCuentaLineas;
        private GESTCRM.Controles.LabelGradient lblTitulo;
        private GESTCRM.Controles.LabelGradient labelGradient2;
        private System.Windows.Forms.MenuItem menuEditar;
        private System.Windows.Forms.MenuItem menuEliminar;
        private System.Windows.Forms.MenuItem menuNuevo;
        private System.Data.SqlClient.SqlCommand sqlSelectCommand2;
        private System.Windows.Forms.DataGridTextBoxColumn tIdEstEntPedido;
        private System.Windows.Forms.DataGridTextBoxColumn tIdEstFacPedido;
        private System.Data.SqlClient.SqlDataAdapter sqldaListaEstadosPedidos;
        private System.Data.SqlClient.SqlCommand sqlSelectCommand6;
        private System.Windows.Forms.ComboBox cbEstadoEntregado;
        private System.Windows.Forms.ComboBox cbEstadoFacturado;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpFechaPedidoEntre;
        private System.Data.SqlClient.SqlCommand sqlSelectCommand4;
        private System.Data.SqlClient.SqlCommand sqlSelectCommand4CECL; //---- GSG CECL 19/05/2016
        private System.Windows.Forms.DataGridTextBoxColumn sDescripcionRentabilidad;
        private BindingSource dsFormularios1BindingSource;
        private DataGridView dataGridViewLineas;
        private SqlDataAdapter sqldaListaCampCabecera;
        private SqlCommand sqlCommand4;
        //---- GSG (19/10/2015)
        private SqlDataAdapter sqldaGetTarjetasClientePedido;
        private SqlCommand sqlCmdGetTarjetasClientePedido;
        private SqlCommand sqlCmdSetUsoTarjetasCliente;
        private GESTCRM.Formularios.DataSets.dsClientes dsClientes1;

        private dsMateriales dsMateriales1;
        private CheckBox chkRetenido;
        private DataGridViewTextBoxColumn iIdLineaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn sIdMaterialDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn ColProducto;
        private DataGridViewTextBoxColumn ColCampanya;
        private DataGridViewTextBoxColumn ColObligatorio;
        private DataGridViewTextBoxColumn ColCantidad;
        private DataGridViewTextBoxColumn ColPrecioBruto;
        private DataGridViewTextBoxColumn ColPrecio;
        private DataGridViewTextBoxColumn ColDescuento;
        private DataGridViewTextBoxColumn ColImporteLin;
        private DataGridViewTextBoxColumn ColDescuentoMaximo;
        private DataGridViewTextBoxColumn fRentabilidadDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn fCosteDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn ColidCampanya;
        private DataGridViewTextBoxColumn idArrastreDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn ColUnidMinimas;
        private DataGridViewTextBoxColumn ColIdGrupoMat;
        private DataGridViewTextBoxColumn sRechazo;
        private DataGridViewTextBoxColumn rechazo;
        private System.ComponentModel.IContainer components;



        #region constructor
        public frmConsultaPedidos()
        {
            InitializeComponent();


            //---- GSG (06/03/2021)
            Utiles.GetConfigConnection();
            this.sqlConn.ConnectionString = Utiles._connection.ConnectionString.ToString();

            

  
        }

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #endregion constructor

        #region Windows Form Designer generated code
        /// <summary>
        /// Método necesario para admitir el Diseñador, no se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsultaPedidos));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgCabeceraPedidos = new System.Windows.Forms.DataGrid();
            this.dsFormularios1 = new GESTCRM.Formularios.dsFormularios();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dFechaPedido = new System.Windows.Forms.DataGridTextBoxColumn();
            this.sIdPedido = new System.Windows.Forms.DataGridTextBoxColumn();
            this.sIdTipoPedido = new System.Windows.Forms.DataGridTextBoxColumn();
            this.sTipoPedido = new System.Windows.Forms.DataGridTextBoxColumn();
            this.sIdCliente = new System.Windows.Forms.DataGridTextBoxColumn();
            this.sNomCliente = new System.Windows.Forms.DataGridTextBoxColumn();
            this.sIdDestinatario = new System.Windows.Forms.DataGridTextBoxColumn();
            this.sNomDest = new System.Windows.Forms.DataGridTextBoxColumn();
            this.fImporte = new System.Windows.Forms.DataGridTextBoxColumn();
            this.fImporteBruto = new System.Windows.Forms.DataGridTextBoxColumn();
            this.fDescuento = new System.Windows.Forms.DataGridTextBoxColumn();
            this.sIdTipoCampanya = new System.Windows.Forms.DataGridTextBoxColumn();
            this.sTipoCampanya = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dFechaPreferente = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dFechaFijada = new System.Windows.Forms.DataGridTextBoxColumn();
            this.tObservaciones = new System.Windows.Forms.DataGridTextBoxColumn();
            this.sDelegado = new System.Windows.Forms.DataGridTextBoxColumn();
            this.iIdDelegado = new System.Windows.Forms.DataGridTextBoxColumn();
            this.tIdEstEntPedido = new System.Windows.Forms.DataGridTextBoxColumn();
            this.tIdEstFacPedido = new System.Windows.Forms.DataGridTextBoxColumn();
            this.bEnviadoCen = new System.Windows.Forms.DataGridTextBoxColumn();
            this.sDescripcionRentabilidad = new System.Windows.Forms.DataGridTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.chkRetenido = new System.Windows.Forms.CheckBox();
            this.dtpFechaPedidoEntre = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbEstadoFacturado = new System.Windows.Forms.ComboBox();
            this.cbEstadoEntregado = new System.Windows.Forms.ComboBox();
            this.lblTitulo = new GESTCRM.Controles.LabelGradient();
            this.btBuscarDestinatario = new System.Windows.Forms.Button();
            this.txtDestinatarioSAP = new System.Windows.Forms.TextBox();
            this.txtsDestinatario = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFechaPedido = new System.Windows.Forms.DateTimePicker();
            this.pcbFechaPref = new System.Windows.Forms.PictureBox();
            this.btBuscarCliente = new System.Windows.Forms.Button();
            this.txtClienteSAP = new System.Windows.Forms.TextBox();
            this.txtsCliente = new System.Windows.Forms.TextBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblFechaPedido = new System.Windows.Forms.Label();
            this.cboTipoCampanya = new System.Windows.Forms.ComboBox();
            this.lblTipoCampanya = new System.Windows.Forms.Label();
            this.lbsIdPedido = new System.Windows.Forms.Label();
            this.txbsIdPedido = new System.Windows.Forms.TextBox();
            this.cboTipoPedido = new System.Windows.Forms.ComboBox();
            this.lblTipoPedido = new System.Windows.Forms.Label();
            this.cboDelegado = new System.Windows.Forms.ComboBox();
            this.lblDelegado = new System.Windows.Forms.Label();
            this.sqldaListaDelegados = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlConn = new System.Data.SqlClient.SqlConnection();
            this.sqldaTipoPedido = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
            this.sqldaListaBuscaPedidos = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand4 = new System.Data.SqlClient.SqlCommand();
            this.sqlSelectCommand4CECL = new System.Data.SqlClient.SqlCommand();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridViewLineas = new System.Windows.Forms.DataGridView();
            this.iIdLineaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sIdMaterialDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCampanya = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColObligatorio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPrecioBruto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDescuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColImporteLin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDescuentoMaximo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fRentabilidadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fCosteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColidCampanya = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idArrastreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColUnidMinimas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColIdGrupoMat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sRechazo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rechazo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsFormularios1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsMateriales1 = new GESTCRM.Formularios.dsMateriales();
            this.lblCuentaLineas = new System.Windows.Forms.Label();
            this.labelGradient2 = new GESTCRM.Controles.LabelGradient();
            this.labelGradient1 = new GESTCRM.Controles.LabelGradient();
            this.txtFechaFij = new System.Windows.Forms.TextBox();
            this.txtFechaPref = new System.Windows.Forms.TextBox();
            this.lblObs = new System.Windows.Forms.Label();
            this.txbObs = new System.Windows.Forms.TextBox();
            this.lblFechaFij = new System.Windows.Forms.Label();
            this.lblFechaPref = new System.Windows.Forms.Label();
            this.sqldaListaLineasPedidos = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand5 = new System.Data.SqlClient.SqlCommand();
            this.toolTipConsultaPedidos = new System.Windows.Forms.ToolTip(this.components);
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.menuNuevo = new System.Windows.Forms.MenuItem();
            this.menuEditar = new System.Windows.Forms.MenuItem();
            this.menuEliminar = new System.Windows.Forms.MenuItem();
            this.sqlcmdSetPedidosCab = new System.Data.SqlClient.SqlCommand();
            this.sqlcmDelPedidoRetenido = new System.Data.SqlClient.SqlCommand();
            this.ucBotoneraSecundaria1 = new GESTCRM.Controles.ucBotoneraSecundaria();
            this.sqlcmdSetPedidosLin = new System.Data.SqlClient.SqlCommand();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblCuentaPedidos = new System.Windows.Forms.Label();
            this.labelGradient6 = new GESTCRM.Controles.LabelGradient();
            this.sqldaListaEstadosPedidos = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand6 = new System.Data.SqlClient.SqlCommand();
            this.sqldaListaCampCabecera = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCommand4 = new System.Data.SqlClient.SqlCommand();
            this.sqldaGetTarjetasClientePedido = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCmdGetTarjetasClientePedido = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdSetUsoTarjetasCliente = new System.Data.SqlClient.SqlCommand();
            this.dsClientes1 = new GESTCRM.Formularios.DataSets.dsClientes();
            ((System.ComponentModel.ISupportInitialize)(this.dgCabeceraPedidos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsFormularios1)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbFechaPref)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLineas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsFormularios1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsMateriales1)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsClientes1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgCabeceraPedidos
            // 
            this.dgCabeceraPedidos.BackgroundColor = System.Drawing.Color.White;
            this.dgCabeceraPedidos.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.dgCabeceraPedidos.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgCabeceraPedidos.CaptionText = "Pedidos";
            this.dgCabeceraPedidos.CaptionVisible = false;
            this.dgCabeceraPedidos.DataMember = "ListaBuscaPedidos";
            this.dgCabeceraPedidos.DataSource = this.dsFormularios1;
            this.dgCabeceraPedidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgCabeceraPedidos.HeaderBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgCabeceraPedidos.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgCabeceraPedidos.Location = new System.Drawing.Point(-2, 23);
            this.dgCabeceraPedidos.Name = "dgCabeceraPedidos";
            this.dgCabeceraPedidos.ParentRowsBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgCabeceraPedidos.ReadOnly = true;
            this.dgCabeceraPedidos.RowHeaderWidth = 15;
            this.dgCabeceraPedidos.Size = new System.Drawing.Size(1513, 313);
            this.dgCabeceraPedidos.TabIndex = 0;
            this.dgCabeceraPedidos.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            this.dgCabeceraPedidos.CurrentCellChanged += new System.EventHandler(this.dgCabeceraPedidos_CurrentCellChanged);
            this.dgCabeceraPedidos.DoubleClick += new System.EventHandler(this.dgCabeceraPedidos_DobleClick);
            // 
            // dsFormularios1
            // 
            this.dsFormularios1.DataSetName = "dsFormularios";
            this.dsFormularios1.Locale = new System.Globalization.CultureInfo("es-ES");
            this.dsFormularios1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.DataGrid = this.dgCabeceraPedidos;
            this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dFechaPedido,
            this.sIdPedido,
            this.sIdTipoPedido,
            this.sTipoPedido,
            this.sIdCliente,
            this.sNomCliente,
            this.sIdDestinatario,
            this.sNomDest,
            this.fImporte,
            this.fImporteBruto,
            this.fDescuento,
            this.sIdTipoCampanya,
            this.sTipoCampanya,
            this.dFechaPreferente,
            this.dFechaFijada,
            this.tObservaciones,
            this.sDelegado,
            this.iIdDelegado,
            this.tIdEstEntPedido,
            this.tIdEstFacPedido,
            this.bEnviadoCen,
            this.sDescripcionRentabilidad});
            this.dataGridTableStyle1.HeaderBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle1.MappingName = "ListaBuscaPedidos";
            this.dataGridTableStyle1.RowHeaderWidth = 15;
            // 
            // dFechaPedido
            // 
            this.dFechaPedido.Format = "";
            this.dFechaPedido.FormatInfo = null;
            this.dFechaPedido.HeaderText = "Fecha";
            this.dFechaPedido.MappingName = "dFechaPedido";
            this.dFechaPedido.NullText = "";
            this.dFechaPedido.Width = 95;
            // 
            // sIdPedido
            // 
            this.sIdPedido.Format = "";
            this.sIdPedido.FormatInfo = null;
            this.sIdPedido.HeaderText = "Pedido";
            this.sIdPedido.MappingName = "sIdPedido";
            this.sIdPedido.NullText = "";
            this.sIdPedido.ReadOnly = true;
            this.sIdPedido.Width = 110;
            // 
            // sIdTipoPedido
            // 
            this.sIdTipoPedido.Format = "";
            this.sIdTipoPedido.FormatInfo = null;
            this.sIdTipoPedido.HeaderText = "IdTipoPedido";
            this.sIdTipoPedido.MappingName = "sIdTipoPedido";
            this.sIdTipoPedido.NullText = "";
            this.sIdTipoPedido.Width = 0;
            // 
            // sTipoPedido
            // 
            this.sTipoPedido.Format = "";
            this.sTipoPedido.FormatInfo = null;
            this.sTipoPedido.HeaderText = "Tipo Pedido";
            this.sTipoPedido.MappingName = "sLiteral";
            this.sTipoPedido.NullText = "";
            this.sTipoPedido.Width = 120;
            // 
            // sIdCliente
            // 
            this.sIdCliente.Format = "";
            this.sIdCliente.FormatInfo = null;
            this.sIdCliente.HeaderText = "sIdCliente";
            this.sIdCliente.MappingName = "sIdCliente";
            this.sIdCliente.NullText = "";
            this.sIdCliente.Width = 0;
            // 
            // sNomCliente
            // 
            this.sNomCliente.Format = "";
            this.sNomCliente.FormatInfo = null;
            this.sNomCliente.HeaderText = "Cliente";
            this.sNomCliente.MappingName = "sNombre";
            this.sNomCliente.NullText = "";
            this.sNomCliente.Width = 250;
            // 
            // sIdDestinatario
            // 
            this.sIdDestinatario.Format = "";
            this.sIdDestinatario.FormatInfo = null;
            this.sIdDestinatario.HeaderText = "sIdDestinatario";
            this.sIdDestinatario.MappingName = "sIdCliente1";
            this.sIdDestinatario.NullText = "";
            this.sIdDestinatario.Width = 0;
            // 
            // sNomDest
            // 
            this.sNomDest.Format = "";
            this.sNomDest.FormatInfo = null;
            this.sNomDest.HeaderText = "Destinatario";
            this.sNomDest.MappingName = "sNombre1";
            this.sNomDest.NullText = "";
            this.sNomDest.Width = 220;
            // 
            // fImporte
            // 
            this.fImporte.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.fImporte.Format = "N2";
            this.fImporte.FormatInfo = null;
            this.fImporte.HeaderText = "Importe";
            this.fImporte.MappingName = "fImporte";
            this.fImporte.NullText = "";
            this.fImporte.Width = 95;
            // 
            // fImporteBruto
            // 
            this.fImporteBruto.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.fImporteBruto.Format = "N2";
            this.fImporteBruto.FormatInfo = null;
            this.fImporteBruto.HeaderText = "Imp. Bruto";
            this.fImporteBruto.MappingName = "fImporteBruto";
            this.fImporteBruto.NullText = "";
            this.fImporteBruto.Width = 95;
            // 
            // fDescuento
            // 
            this.fDescuento.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.fDescuento.Format = "N2";
            this.fDescuento.FormatInfo = null;
            this.fDescuento.HeaderText = "Dto.";
            this.fDescuento.MappingName = "dto";
            this.fDescuento.NullText = "";
            this.fDescuento.Width = 65;
            // 
            // sIdTipoCampanya
            // 
            this.sIdTipoCampanya.Format = "";
            this.sIdTipoCampanya.FormatInfo = null;
            this.sIdTipoCampanya.HeaderText = "IdCampanya";
            this.sIdTipoCampanya.MappingName = "sIdTipoCampanya";
            this.sIdTipoCampanya.NullText = "";
            this.sIdTipoCampanya.Width = 0;
            // 
            // sTipoCampanya
            // 
            this.sTipoCampanya.Format = "";
            this.sTipoCampanya.FormatInfo = null;
            this.sTipoCampanya.HeaderText = "TipoCampanya";
            this.sTipoCampanya.MappingName = "sLiteral1";
            this.sTipoCampanya.NullText = "";
            this.sTipoCampanya.Width = 0;
            // 
            // dFechaPreferente
            // 
            this.dFechaPreferente.Format = "";
            this.dFechaPreferente.FormatInfo = null;
            this.dFechaPreferente.HeaderText = "FechaPref";
            this.dFechaPreferente.MappingName = "dFechaPreferente";
            this.dFechaPreferente.NullText = "";
            this.dFechaPreferente.Width = 0;
            // 
            // dFechaFijada
            // 
            this.dFechaFijada.Format = "";
            this.dFechaFijada.FormatInfo = null;
            this.dFechaFijada.HeaderText = "FechaFij";
            this.dFechaFijada.MappingName = "dFechaFijada";
            this.dFechaFijada.NullText = "";
            this.dFechaFijada.Width = 0;
            // 
            // tObservaciones
            // 
            this.tObservaciones.Format = "";
            this.tObservaciones.FormatInfo = null;
            this.tObservaciones.HeaderText = "Obs";
            this.tObservaciones.MappingName = "tObservaciones";
            this.tObservaciones.NullText = "";
            this.tObservaciones.Width = 0;
            // 
            // sDelegado
            // 
            this.sDelegado.Format = "";
            this.sDelegado.FormatInfo = null;
            this.sDelegado.HeaderText = "Delegado";
            this.sDelegado.MappingName = "sNombre2";
            this.sDelegado.NullText = "";
            this.sDelegado.Width = 140;
            // 
            // iIdDelegado
            // 
            this.iIdDelegado.Format = "";
            this.iIdDelegado.FormatInfo = null;
            this.iIdDelegado.HeaderText = "IdDelegado";
            this.iIdDelegado.MappingName = "iIdDelegado";
            this.iIdDelegado.NullText = "";
            this.iIdDelegado.Width = 0;
            // 
            // tIdEstEntPedido
            // 
            this.tIdEstEntPedido.Format = "";
            this.tIdEstEntPedido.FormatInfo = null;
            this.tIdEstEntPedido.HeaderText = "E.Entr.";
            this.tIdEstEntPedido.MappingName = "tIdEstEntPedido";
            this.tIdEstEntPedido.Width = 85;
            // 
            // tIdEstFacPedido
            // 
            this.tIdEstFacPedido.Format = "";
            this.tIdEstFacPedido.FormatInfo = null;
            this.tIdEstFacPedido.HeaderText = "E.Fact.";
            this.tIdEstFacPedido.MappingName = "tIdEstFacPedido";
            this.tIdEstFacPedido.Width = 85;
            // 
            // bEnviadoCen
            // 
            this.bEnviadoCen.Format = "";
            this.bEnviadoCen.FormatInfo = null;
            this.bEnviadoCen.MappingName = "bEnviadoCen";
            this.bEnviadoCen.Width = 0;
            // 
            // sDescripcionRentabilidad
            // 
            this.sDescripcionRentabilidad.Format = "";
            this.sDescripcionRentabilidad.FormatInfo = null;
            this.sDescripcionRentabilidad.HeaderText = "Rentabilidad";
            this.sDescripcionRentabilidad.MappingName = "sDescripcionRentabilidad";
            this.sDescripcionRentabilidad.Width = 120;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.chkRetenido);
            this.panel3.Controls.Add(this.dtpFechaPedidoEntre);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.cbEstadoFacturado);
            this.panel3.Controls.Add(this.cbEstadoEntregado);
            this.panel3.Controls.Add(this.lblTitulo);
            this.panel3.Controls.Add(this.btBuscarDestinatario);
            this.panel3.Controls.Add(this.txtDestinatarioSAP);
            this.panel3.Controls.Add(this.txtsDestinatario);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.dtpFechaPedido);
            this.panel3.Controls.Add(this.pcbFechaPref);
            this.panel3.Controls.Add(this.btBuscarCliente);
            this.panel3.Controls.Add(this.txtClienteSAP);
            this.panel3.Controls.Add(this.txtsCliente);
            this.panel3.Controls.Add(this.lblCliente);
            this.panel3.Controls.Add(this.btnBuscar);
            this.panel3.Controls.Add(this.lblFechaPedido);
            this.panel3.Controls.Add(this.cboTipoCampanya);
            this.panel3.Controls.Add(this.lblTipoCampanya);
            this.panel3.Controls.Add(this.lbsIdPedido);
            this.panel3.Controls.Add(this.txbsIdPedido);
            this.panel3.Controls.Add(this.cboTipoPedido);
            this.panel3.Controls.Add(this.lblTipoPedido);
            this.panel3.Controls.Add(this.cboDelegado);
            this.panel3.Controls.Add(this.lblDelegado);
            this.panel3.Location = new System.Drawing.Point(4, 38);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1511, 135);
            this.panel3.TabIndex = 9;
            // 
            // chkRetenido
            // 
            this.chkRetenido.AutoSize = true;
            this.chkRetenido.ForeColor = System.Drawing.Color.Black;
            this.chkRetenido.Location = new System.Drawing.Point(8, 108);
            this.chkRetenido.Name = "chkRetenido";
            this.chkRetenido.Size = new System.Drawing.Size(146, 24);
            this.chkRetenido.TabIndex = 118;
            this.chkRetenido.Text = "Pedido Retenido";
            this.chkRetenido.UseVisualStyleBackColor = true;
            // 
            // dtpFechaPedidoEntre
            // 
            this.dtpFechaPedidoEntre.Checked = false;
            this.dtpFechaPedidoEntre.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaPedidoEntre.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaPedidoEntre.Location = new System.Drawing.Point(285, 35);
            this.dtpFechaPedidoEntre.MaxDate = new System.DateTime(2999, 12, 31, 0, 0, 0, 0);
            this.dtpFechaPedidoEntre.Name = "dtpFechaPedidoEntre";
            this.dtpFechaPedidoEntre.Size = new System.Drawing.Size(120, 24);
            this.dtpFechaPedidoEntre.TabIndex = 1;
            this.dtpFechaPedidoEntre.ValueChanged += new System.EventHandler(this.dtpFechaPedidoEntre_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(247, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 16);
            this.label4.TabIndex = 97;
            this.label4.Text = "entre";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(1049, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 20);
            this.label3.TabIndex = 96;
            this.label3.Text = "Estado Fact.:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(1048, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 20);
            this.label2.TabIndex = 95;
            this.label2.Text = "Estado Entr.:";
            // 
            // cbEstadoFacturado
            // 
            this.cbEstadoFacturado.BackColor = System.Drawing.Color.White;
            this.cbEstadoFacturado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEstadoFacturado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbEstadoFacturado.ForeColor = System.Drawing.Color.Black;
            this.cbEstadoFacturado.ItemHeight = 20;
            this.cbEstadoFacturado.Location = new System.Drawing.Point(1153, 103);
            this.cbEstadoFacturado.Name = "cbEstadoFacturado";
            this.cbEstadoFacturado.Size = new System.Drawing.Size(122, 28);
            this.cbEstadoFacturado.TabIndex = 11;
            // 
            // cbEstadoEntregado
            // 
            this.cbEstadoEntregado.BackColor = System.Drawing.Color.White;
            this.cbEstadoEntregado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEstadoEntregado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbEstadoEntregado.ForeColor = System.Drawing.Color.Black;
            this.cbEstadoEntregado.ItemHeight = 20;
            this.cbEstadoEntregado.Location = new System.Drawing.Point(1153, 69);
            this.cbEstadoEntregado.Name = "cbEstadoEntregado";
            this.cbEstadoEntregado.Size = new System.Drawing.Size(122, 28);
            this.cbEstadoEntregado.TabIndex = 7;
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
            this.lblTitulo.Size = new System.Drawing.Size(1509, 27);
            this.lblTitulo.TabIndex = 92;
            this.lblTitulo.Text = "Consulta de pedidos";
            // 
            // btBuscarDestinatario
            // 
            this.btBuscarDestinatario.Image = ((System.Drawing.Image)(resources.GetObject("btBuscarDestinatario.Image")));
            this.btBuscarDestinatario.Location = new System.Drawing.Point(1007, 65);
            this.btBuscarDestinatario.Name = "btBuscarDestinatario";
            this.btBuscarDestinatario.Size = new System.Drawing.Size(36, 35);
            this.btBuscarDestinatario.TabIndex = 9;
            this.btBuscarDestinatario.TabStop = false;
            this.toolTipConsultaPedidos.SetToolTip(this.btBuscarDestinatario, "Buscar Mayorista/Pagador");
            this.btBuscarDestinatario.Click += new System.EventHandler(this.btBuscarDestinatario_Click);
            // 
            // txtDestinatarioSAP
            // 
            this.txtDestinatarioSAP.BackColor = System.Drawing.Color.White;
            this.txtDestinatarioSAP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDestinatarioSAP.ForeColor = System.Drawing.Color.Black;
            this.txtDestinatarioSAP.Location = new System.Drawing.Point(634, 68);
            this.txtDestinatarioSAP.MaxLength = 20;
            this.txtDestinatarioSAP.Name = "txtDestinatarioSAP";
            this.txtDestinatarioSAP.Size = new System.Drawing.Size(111, 26);
            this.txtDestinatarioSAP.TabIndex = 8;
            this.txtDestinatarioSAP.Leave += new System.EventHandler(this.txtDestinatarioSAP_Leave);
            // 
            // txtsDestinatario
            // 
            this.txtsDestinatario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtsDestinatario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsDestinatario.ForeColor = System.Drawing.Color.Black;
            this.txtsDestinatario.Location = new System.Drawing.Point(746, 68);
            this.txtsDestinatario.Name = "txtsDestinatario";
            this.txtsDestinatario.ReadOnly = true;
            this.txtsDestinatario.Size = new System.Drawing.Size(260, 26);
            this.txtsDestinatario.TabIndex = 85;
            this.txtsDestinatario.TabStop = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(491, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 29);
            this.label1.TabIndex = 82;
            this.label1.Text = "Mayorista/Pagador:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpFechaPedido
            // 
            this.dtpFechaPedido.Checked = false;
            this.dtpFechaPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaPedido.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaPedido.Location = new System.Drawing.Point(127, 35);
            this.dtpFechaPedido.Name = "dtpFechaPedido";
            this.dtpFechaPedido.Size = new System.Drawing.Size(120, 24);
            this.dtpFechaPedido.TabIndex = 0;
            this.dtpFechaPedido.Value = new System.DateTime(2009, 4, 21, 0, 0, 0, 0);
            this.dtpFechaPedido.ValueChanged += new System.EventHandler(this.dtpFechaPedido_ValueChanged);
            // 
            // pcbFechaPref
            // 
            this.pcbFechaPref.Image = ((System.Drawing.Image)(resources.GetObject("pcbFechaPref.Image")));
            this.pcbFechaPref.Location = new System.Drawing.Point(102, 39);
            this.pcbFechaPref.Name = "pcbFechaPref";
            this.pcbFechaPref.Size = new System.Drawing.Size(20, 20);
            this.pcbFechaPref.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbFechaPref.TabIndex = 80;
            this.pcbFechaPref.TabStop = false;
            this.toolTipConsultaPedidos.SetToolTip(this.pcbFechaPref, "Limpiar campos de Fecha");
            this.pcbFechaPref.Click += new System.EventHandler(this.pcbFechaPref_Click);
            // 
            // btBuscarCliente
            // 
            this.btBuscarCliente.Image = ((System.Drawing.Image)(resources.GetObject("btBuscarCliente.Image")));
            this.btBuscarCliente.Location = new System.Drawing.Point(455, 64);
            this.btBuscarCliente.Name = "btBuscarCliente";
            this.btBuscarCliente.Size = new System.Drawing.Size(36, 35);
            this.btBuscarCliente.TabIndex = 5;
            this.btBuscarCliente.TabStop = false;
            this.toolTipConsultaPedidos.SetToolTip(this.btBuscarCliente, "Buscar Solicitante");
            this.btBuscarCliente.Click += new System.EventHandler(this.btBuscarCliente_Click);
            // 
            // txtClienteSAP
            // 
            this.txtClienteSAP.BackColor = System.Drawing.Color.White;
            this.txtClienteSAP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClienteSAP.ForeColor = System.Drawing.Color.Black;
            this.txtClienteSAP.Location = new System.Drawing.Point(85, 67);
            this.txtClienteSAP.MaxLength = 20;
            this.txtClienteSAP.Name = "txtClienteSAP";
            this.txtClienteSAP.Size = new System.Drawing.Size(110, 26);
            this.txtClienteSAP.TabIndex = 4;
            this.txtClienteSAP.Leave += new System.EventHandler(this.txtClienteSAP_Leave);
            // 
            // txtsCliente
            // 
            this.txtsCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtsCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsCliente.ForeColor = System.Drawing.Color.Black;
            this.txtsCliente.Location = new System.Drawing.Point(195, 67);
            this.txtsCliente.Name = "txtsCliente";
            this.txtsCliente.ReadOnly = true;
            this.txtsCliente.Size = new System.Drawing.Size(260, 26);
            this.txtsCliente.TabIndex = 72;
            this.txtsCliente.TabStop = false;
            // 
            // lblCliente
            // 
            this.lblCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCliente.ForeColor = System.Drawing.Color.Black;
            this.lblCliente.Location = new System.Drawing.Point(1, 68);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(114, 24);
            this.lblCliente.TabIndex = 69;
            this.lblCliente.Text = "Solicitante:";
            this.lblCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.Color.Black;
            this.btnBuscar.Location = new System.Drawing.Point(1368, 78);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(96, 38);
            this.btnBuscar.TabIndex = 12;
            this.btnBuscar.Text = "&Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lblFechaPedido
            // 
            this.lblFechaPedido.AutoSize = true;
            this.lblFechaPedido.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblFechaPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaPedido.ForeColor = System.Drawing.Color.Black;
            this.lblFechaPedido.Location = new System.Drawing.Point(4, 38);
            this.lblFechaPedido.Name = "lblFechaPedido";
            this.lblFechaPedido.Size = new System.Drawing.Size(97, 20);
            this.lblFechaPedido.TabIndex = 21;
            this.lblFechaPedido.Text = "Fec. Pedido:";
            // 
            // cboTipoCampanya
            // 
            this.cboTipoCampanya.BackColor = System.Drawing.Color.White;
            this.cboTipoCampanya.DataSource = this.dsFormularios1;
            this.cboTipoCampanya.DisplayMember = "ListaCampanyasCabecera.NombreCampanya";
            this.cboTipoCampanya.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoCampanya.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipoCampanya.ItemHeight = 20;
            this.cboTipoCampanya.Location = new System.Drawing.Point(1329, 34);
            this.cboTipoCampanya.Name = "cboTipoCampanya";
            this.cboTipoCampanya.Size = new System.Drawing.Size(173, 28);
            this.cboTipoCampanya.TabIndex = 3;
            this.cboTipoCampanya.ValueMember = "ListaCampanyasCabecera.IdCampanya";
            // 
            // lblTipoCampanya
            // 
            this.lblTipoCampanya.AutoSize = true;
            this.lblTipoCampanya.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblTipoCampanya.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoCampanya.ForeColor = System.Drawing.Color.Black;
            this.lblTipoCampanya.Location = new System.Drawing.Point(1240, 38);
            this.lblTipoCampanya.Name = "lblTipoCampanya";
            this.lblTipoCampanya.Size = new System.Drawing.Size(93, 20);
            this.lblTipoCampanya.TabIndex = 17;
            this.lblTipoCampanya.Text = "Tipo Camp.:";
            // 
            // lbsIdPedido
            // 
            this.lbsIdPedido.AutoSize = true;
            this.lbsIdPedido.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lbsIdPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbsIdPedido.ForeColor = System.Drawing.Color.Black;
            this.lbsIdPedido.Location = new System.Drawing.Point(760, 39);
            this.lbsIdPedido.Name = "lbsIdPedido";
            this.lbsIdPedido.Size = new System.Drawing.Size(84, 20);
            this.lbsIdPedido.TabIndex = 14;
            this.lbsIdPedido.Text = "Id. Pedido:";
            // 
            // txbsIdPedido
            // 
            this.txbsIdPedido.BackColor = System.Drawing.Color.White;
            this.txbsIdPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbsIdPedido.Location = new System.Drawing.Point(845, 36);
            this.txbsIdPedido.MaxLength = 12;
            this.txbsIdPedido.Name = "txbsIdPedido";
            this.txbsIdPedido.Size = new System.Drawing.Size(132, 26);
            this.txbsIdPedido.TabIndex = 6;
            // 
            // cboTipoPedido
            // 
            this.cboTipoPedido.BackColor = System.Drawing.Color.White;
            this.cboTipoPedido.DataSource = this.dsFormularios1.ListaTipoPedido;
            this.cboTipoPedido.DisplayMember = "sLiteral";
            this.cboTipoPedido.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipoPedido.ForeColor = System.Drawing.Color.Black;
            this.cboTipoPedido.ItemHeight = 20;
            this.cboTipoPedido.Location = new System.Drawing.Point(1075, 36);
            this.cboTipoPedido.Name = "cboTipoPedido";
            this.cboTipoPedido.Size = new System.Drawing.Size(159, 28);
            this.cboTipoPedido.TabIndex = 10;
            this.cboTipoPedido.ValueMember = "sValor";
            // 
            // lblTipoPedido
            // 
            this.lblTipoPedido.AutoSize = true;
            this.lblTipoPedido.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblTipoPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoPedido.ForeColor = System.Drawing.Color.Black;
            this.lblTipoPedido.Location = new System.Drawing.Point(981, 38);
            this.lblTipoPedido.Name = "lblTipoPedido";
            this.lblTipoPedido.Size = new System.Drawing.Size(96, 20);
            this.lblTipoPedido.TabIndex = 11;
            this.lblTipoPedido.Text = "Tipo Pedido:";
            // 
            // cboDelegado
            // 
            this.cboDelegado.BackColor = System.Drawing.Color.White;
            this.cboDelegado.DataSource = this.dsFormularios1.ListaDelegados;
            this.cboDelegado.DisplayMember = "sNombre";
            this.cboDelegado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDelegado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDelegado.ItemHeight = 20;
            this.cboDelegado.Location = new System.Drawing.Point(485, 34);
            this.cboDelegado.Name = "cboDelegado";
            this.cboDelegado.Size = new System.Drawing.Size(270, 28);
            this.cboDelegado.TabIndex = 2;
            this.cboDelegado.ValueMember = "iIdDelegado";
            // 
            // lblDelegado
            // 
            this.lblDelegado.AutoSize = true;
            this.lblDelegado.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblDelegado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDelegado.ForeColor = System.Drawing.Color.Black;
            this.lblDelegado.Location = new System.Drawing.Point(406, 38);
            this.lblDelegado.Name = "lblDelegado";
            this.lblDelegado.Size = new System.Drawing.Size(82, 20);
            this.lblDelegado.TabIndex = 1;
            this.lblDelegado.Text = "Delegado:";
            // 
            // sqldaListaDelegados
            // 
            this.sqldaListaDelegados.SelectCommand = this.sqlSelectCommand1;
            this.sqldaListaDelegados.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaDelegados", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iIdDelegado", "iIdDelegado"),
                        new System.Data.Common.DataColumnMapping("sNombre", "sNombre")})});
            // 
            // sqlSelectCommand1
            // 
            this.sqlSelectCommand1.CommandText = "[ListaDelegados]";
            this.sqlSelectCommand1.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand1.Connection = this.sqlConn;
            this.sqlSelectCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null)});
            // 
            // sqlConn
            // 
            this.sqlConn.FireInfoMessageEventOnUserErrors = false;
            // 
            // sqldaTipoPedido
            // 
            this.sqldaTipoPedido.SelectCommand = this.sqlSelectCommand2;
            this.sqldaTipoPedido.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaTipoPedido", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("sValor", "sValor"),
                        new System.Data.Common.DataColumnMapping("sLiteral", "sLiteral")})});
            // 
            // sqlSelectCommand2
            // 
            this.sqlSelectCommand2.CommandText = "[ListaTipoPedidoTodos]";
            this.sqlSelectCommand2.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand2.Connection = this.sqlConn;
            this.sqlSelectCommand2.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null)});
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
            new System.Data.SqlClient.SqlParameter("@EstFacPedido", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@bRetenido", System.Data.SqlDbType.Bit, 1)});
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
            new System.Data.SqlClient.SqlParameter("@EstFacPedido", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@bRetenido", System.Data.SqlDbType.Bit, 1)});
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.dataGridViewLineas);
            this.panel1.Controls.Add(this.lblCuentaLineas);
            this.panel1.Controls.Add(this.labelGradient2);
            this.panel1.Controls.Add(this.labelGradient1);
            this.panel1.Controls.Add(this.txtFechaFij);
            this.panel1.Controls.Add(this.txtFechaPref);
            this.panel1.Controls.Add(this.lblObs);
            this.panel1.Controls.Add(this.txbObs);
            this.panel1.Controls.Add(this.lblFechaFij);
            this.panel1.Controls.Add(this.lblFechaPref);
            this.panel1.Location = new System.Drawing.Point(2, 523);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1511, 285);
            this.panel1.TabIndex = 24;
            // 
            // dataGridViewLineas
            // 
            this.dataGridViewLineas.AllowUserToAddRows = false;
            this.dataGridViewLineas.AllowUserToDeleteRows = false;
            this.dataGridViewLineas.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridViewLineas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewLineas.AutoGenerateColumns = false;
            this.dataGridViewLineas.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewLineas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewLineas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewLineas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLineas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iIdLineaDataGridViewTextBoxColumn,
            this.sIdMaterialDataGridViewTextBoxColumn,
            this.ColProducto,
            this.ColCampanya,
            this.ColObligatorio,
            this.ColCantidad,
            this.ColPrecioBruto,
            this.ColPrecio,
            this.ColDescuento,
            this.ColImporteLin,
            this.ColDescuentoMaximo,
            this.fRentabilidadDataGridViewTextBoxColumn,
            this.fCosteDataGridViewTextBoxColumn,
            this.ColidCampanya,
            this.idArrastreDataGridViewTextBoxColumn,
            this.ColUnidMinimas,
            this.ColIdGrupoMat,
            this.sRechazo,
            this.rechazo});
            this.dataGridViewLineas.DataMember = "ListaLineasPedido";
            this.dataGridViewLineas.DataSource = this.dsFormularios1BindingSource;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewLineas.DefaultCellStyle = dataGridViewCellStyle12;
            this.dataGridViewLineas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewLineas.Location = new System.Drawing.Point(0, 90);
            this.dataGridViewLineas.MultiSelect = false;
            this.dataGridViewLineas.Name = "dataGridViewLineas";
            this.dataGridViewLineas.ReadOnly = true;
            this.dataGridViewLineas.RowHeadersVisible = false;
            this.dataGridViewLineas.RowHeadersWidth = 25;
            this.dataGridViewLineas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewLineas.ShowCellToolTips = false;
            this.dataGridViewLineas.Size = new System.Drawing.Size(1483, 188);
            this.dataGridViewLineas.TabIndex = 92;
            this.dataGridViewLineas.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dataGridViewLineas_RowPrePaint);
            // 
            // iIdLineaDataGridViewTextBoxColumn
            // 
            this.iIdLineaDataGridViewTextBoxColumn.DataPropertyName = "iIdLinea";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iIdLineaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.iIdLineaDataGridViewTextBoxColumn.HeaderText = "Línea";
            this.iIdLineaDataGridViewTextBoxColumn.Name = "iIdLineaDataGridViewTextBoxColumn";
            this.iIdLineaDataGridViewTextBoxColumn.ReadOnly = true;
            this.iIdLineaDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.iIdLineaDataGridViewTextBoxColumn.Width = 70;
            // 
            // sIdMaterialDataGridViewTextBoxColumn
            // 
            this.sIdMaterialDataGridViewTextBoxColumn.DataPropertyName = "sIdMaterial";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sIdMaterialDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.sIdMaterialDataGridViewTextBoxColumn.HeaderText = "Cod. Prod.";
            this.sIdMaterialDataGridViewTextBoxColumn.Name = "sIdMaterialDataGridViewTextBoxColumn";
            this.sIdMaterialDataGridViewTextBoxColumn.ReadOnly = true;
            this.sIdMaterialDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColProducto
            // 
            this.ColProducto.DataPropertyName = "sMaterial";
            this.ColProducto.HeaderText = "Producto";
            this.ColProducto.Name = "ColProducto";
            this.ColProducto.ReadOnly = true;
            this.ColProducto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColProducto.Width = 400;
            // 
            // ColCampanya
            // 
            this.ColCampanya.DataPropertyName = "NombreCampanya";
            this.ColCampanya.HeaderText = "Campaña";
            this.ColCampanya.Name = "ColCampanya";
            this.ColCampanya.ReadOnly = true;
            this.ColCampanya.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColCampanya.Width = 250;
            // 
            // ColObligatorio
            // 
            this.ColObligatorio.DataPropertyName = "sObligatorio";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColObligatorio.DefaultCellStyle = dataGridViewCellStyle5;
            this.ColObligatorio.HeaderText = "Oblig.";
            this.ColObligatorio.Name = "ColObligatorio";
            this.ColObligatorio.ReadOnly = true;
            this.ColObligatorio.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColObligatorio.Width = 60;
            // 
            // ColCantidad
            // 
            this.ColCantidad.DataPropertyName = "iCantidad";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColCantidad.DefaultCellStyle = dataGridViewCellStyle6;
            this.ColCantidad.HeaderText = "Cantidad";
            this.ColCantidad.Name = "ColCantidad";
            this.ColCantidad.ReadOnly = true;
            this.ColCantidad.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColPrecioBruto
            // 
            this.ColPrecioBruto.DataPropertyName = "fPrecio";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.Format = "C2";
            dataGridViewCellStyle7.NullValue = null;
            this.ColPrecioBruto.DefaultCellStyle = dataGridViewCellStyle7;
            this.ColPrecioBruto.HeaderText = "PrecioBruto";
            this.ColPrecioBruto.Name = "ColPrecioBruto";
            this.ColPrecioBruto.ReadOnly = true;
            this.ColPrecioBruto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColPrecioBruto.Visible = false;
            this.ColPrecioBruto.Width = 63;
            // 
            // ColPrecio
            // 
            this.ColPrecio.DataPropertyName = "PrecioUnitario";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.Format = "C2";
            this.ColPrecio.DefaultCellStyle = dataGridViewCellStyle8;
            this.ColPrecio.HeaderText = "Precio";
            this.ColPrecio.Name = "ColPrecio";
            this.ColPrecio.ReadOnly = true;
            this.ColPrecio.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColPrecio.Width = 63;
            // 
            // ColDescuento
            // 
            this.ColDescuento.DataPropertyName = "fDescuento";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.Format = "N2";
            dataGridViewCellStyle9.NullValue = null;
            this.ColDescuento.DefaultCellStyle = dataGridViewCellStyle9;
            this.ColDescuento.HeaderText = "Descuento";
            this.ColDescuento.Name = "ColDescuento";
            this.ColDescuento.ReadOnly = true;
            this.ColDescuento.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColImporteLin
            // 
            this.ColImporteLin.DataPropertyName = "ImporteLin";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.Format = "C2";
            dataGridViewCellStyle10.NullValue = null;
            this.ColImporteLin.DefaultCellStyle = dataGridViewCellStyle10;
            this.ColImporteLin.HeaderText = "Importe";
            this.ColImporteLin.Name = "ColImporteLin";
            this.ColImporteLin.ReadOnly = true;
            this.ColImporteLin.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColDescuentoMaximo
            // 
            this.ColDescuentoMaximo.DataPropertyName = "fDescuentoMaximo";
            this.ColDescuentoMaximo.HeaderText = "fDescuentoMaximo";
            this.ColDescuentoMaximo.Name = "ColDescuentoMaximo";
            this.ColDescuentoMaximo.ReadOnly = true;
            this.ColDescuentoMaximo.Visible = false;
            // 
            // fRentabilidadDataGridViewTextBoxColumn
            // 
            this.fRentabilidadDataGridViewTextBoxColumn.DataPropertyName = "fRentabilidad";
            this.fRentabilidadDataGridViewTextBoxColumn.HeaderText = "fRentabilidad";
            this.fRentabilidadDataGridViewTextBoxColumn.Name = "fRentabilidadDataGridViewTextBoxColumn";
            this.fRentabilidadDataGridViewTextBoxColumn.ReadOnly = true;
            this.fRentabilidadDataGridViewTextBoxColumn.Visible = false;
            // 
            // fCosteDataGridViewTextBoxColumn
            // 
            this.fCosteDataGridViewTextBoxColumn.DataPropertyName = "fCoste";
            this.fCosteDataGridViewTextBoxColumn.HeaderText = "fCoste";
            this.fCosteDataGridViewTextBoxColumn.Name = "fCosteDataGridViewTextBoxColumn";
            this.fCosteDataGridViewTextBoxColumn.ReadOnly = true;
            this.fCosteDataGridViewTextBoxColumn.Visible = false;
            // 
            // ColidCampanya
            // 
            this.ColidCampanya.DataPropertyName = "idCampanya";
            this.ColidCampanya.HeaderText = "idCampanya";
            this.ColidCampanya.Name = "ColidCampanya";
            this.ColidCampanya.ReadOnly = true;
            this.ColidCampanya.Visible = false;
            // 
            // idArrastreDataGridViewTextBoxColumn
            // 
            this.idArrastreDataGridViewTextBoxColumn.DataPropertyName = "idArrastre";
            this.idArrastreDataGridViewTextBoxColumn.HeaderText = "idArrastre";
            this.idArrastreDataGridViewTextBoxColumn.Name = "idArrastreDataGridViewTextBoxColumn";
            this.idArrastreDataGridViewTextBoxColumn.ReadOnly = true;
            this.idArrastreDataGridViewTextBoxColumn.Visible = false;
            // 
            // ColUnidMinimas
            // 
            this.ColUnidMinimas.DataPropertyName = "UnidMinimas";
            this.ColUnidMinimas.HeaderText = "UnidMinimas";
            this.ColUnidMinimas.Name = "ColUnidMinimas";
            this.ColUnidMinimas.ReadOnly = true;
            this.ColUnidMinimas.Visible = false;
            // 
            // ColIdGrupoMat
            // 
            this.ColIdGrupoMat.DataPropertyName = "idGrupoMat";
            this.ColIdGrupoMat.HeaderText = "idGrupoMat";
            this.ColIdGrupoMat.Name = "ColIdGrupoMat";
            this.ColIdGrupoMat.ReadOnly = true;
            this.ColIdGrupoMat.Visible = false;
            // 
            // sRechazo
            // 
            this.sRechazo.DataPropertyName = "sRechazo";
            this.sRechazo.HeaderText = "sRechazo";
            this.sRechazo.Name = "sRechazo";
            this.sRechazo.ReadOnly = true;
            this.sRechazo.Visible = false;
            // 
            // rechazo
            // 
            this.rechazo.DataPropertyName = "rechazo";
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rechazo.DefaultCellStyle = dataGridViewCellStyle11;
            this.rechazo.HeaderText = "Rechazo";
            this.rechazo.Name = "rechazo";
            this.rechazo.ReadOnly = true;
            // 
            // dsFormularios1BindingSource
            // 
            this.dsFormularios1BindingSource.DataSource = this.dsMateriales1;
            this.dsFormularios1BindingSource.Position = 0;
            // 
            // dsMateriales1
            // 
            this.dsMateriales1.DataSetName = "dsMateriales";
            this.dsMateriales1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lblCuentaLineas
            // 
            this.lblCuentaLineas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.lblCuentaLineas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCuentaLineas.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCuentaLineas.ForeColor = System.Drawing.Color.Black;
            this.lblCuentaLineas.Location = new System.Drawing.Point(1415, 69);
            this.lblCuentaLineas.Name = "lblCuentaLineas";
            this.lblCuentaLineas.Size = new System.Drawing.Size(68, 21);
            this.lblCuentaLineas.TabIndex = 89;
            this.lblCuentaLineas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelGradient2
            // 
            this.labelGradient2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGradient2.ForeColor = System.Drawing.Color.White;
            this.labelGradient2.GradientColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.labelGradient2.GradientColorTwo = System.Drawing.Color.White;
            this.labelGradient2.Location = new System.Drawing.Point(0, 69);
            this.labelGradient2.Name = "labelGradient2";
            this.labelGradient2.Size = new System.Drawing.Size(1483, 21);
            this.labelGradient2.TabIndex = 90;
            this.labelGradient2.Text = "Lineas de pedido";
            this.labelGradient2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelGradient1
            // 
            this.labelGradient1.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelGradient1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGradient1.ForeColor = System.Drawing.Color.White;
            this.labelGradient1.GradientColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.labelGradient1.GradientColorTwo = System.Drawing.Color.White;
            this.labelGradient1.Location = new System.Drawing.Point(0, 0);
            this.labelGradient1.Name = "labelGradient1";
            this.labelGradient1.Size = new System.Drawing.Size(1507, 22);
            this.labelGradient1.TabIndex = 88;
            this.labelGradient1.Text = "Detalle de pedido";
            this.labelGradient1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtFechaFij
            // 
            this.txtFechaFij.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtFechaFij.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaFij.ForeColor = System.Drawing.Color.Black;
            this.txtFechaFij.Location = new System.Drawing.Point(557, 30);
            this.txtFechaFij.Name = "txtFechaFij";
            this.txtFechaFij.ReadOnly = true;
            this.txtFechaFij.Size = new System.Drawing.Size(300, 26);
            this.txtFechaFij.TabIndex = 74;
            this.txtFechaFij.TabStop = false;
            // 
            // txtFechaPref
            // 
            this.txtFechaPref.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtFechaPref.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaPref.ForeColor = System.Drawing.Color.Black;
            this.txtFechaPref.Location = new System.Drawing.Point(150, 31);
            this.txtFechaPref.Name = "txtFechaPref";
            this.txtFechaPref.ReadOnly = true;
            this.txtFechaPref.Size = new System.Drawing.Size(300, 26);
            this.txtFechaPref.TabIndex = 73;
            this.txtFechaPref.TabStop = false;
            // 
            // lblObs
            // 
            this.lblObs.AutoSize = true;
            this.lblObs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblObs.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblObs.ForeColor = System.Drawing.Color.Black;
            this.lblObs.Location = new System.Drawing.Point(868, 34);
            this.lblObs.Name = "lblObs";
            this.lblObs.Size = new System.Drawing.Size(118, 20);
            this.lblObs.TabIndex = 32;
            this.lblObs.Text = "Observaciones:";
            // 
            // txbObs
            // 
            this.txbObs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txbObs.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbObs.Location = new System.Drawing.Point(992, 25);
            this.txbObs.Multiline = true;
            this.txbObs.Name = "txbObs";
            this.txbObs.ReadOnly = true;
            this.txbObs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txbObs.Size = new System.Drawing.Size(491, 40);
            this.txbObs.TabIndex = 31;
            this.txbObs.TabStop = false;
            // 
            // lblFechaFij
            // 
            this.lblFechaFij.AutoSize = true;
            this.lblFechaFij.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblFechaFij.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaFij.ForeColor = System.Drawing.Color.Black;
            this.lblFechaFij.Location = new System.Drawing.Point(456, 33);
            this.lblFechaFij.Name = "lblFechaFij";
            this.lblFechaFij.Size = new System.Drawing.Size(105, 20);
            this.lblFechaFij.TabIndex = 30;
            this.lblFechaFij.Text = "Fecha Fijada:";
            // 
            // lblFechaPref
            // 
            this.lblFechaPref.AutoSize = true;
            this.lblFechaPref.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblFechaPref.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaPref.ForeColor = System.Drawing.Color.Black;
            this.lblFechaPref.Location = new System.Drawing.Point(10, 33);
            this.lblFechaPref.Name = "lblFechaPref";
            this.lblFechaPref.Size = new System.Drawing.Size(137, 20);
            this.lblFechaPref.TabIndex = 29;
            this.lblFechaPref.Text = "Fecha Preferente:";
            // 
            // sqldaListaLineasPedidos
            // 
            this.sqldaListaLineasPedidos.SelectCommand = this.sqlSelectCommand5;
            this.sqldaListaLineasPedidos.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaLineasPedido", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iIdLinea", "iIdLinea"),
                        new System.Data.Common.DataColumnMapping("sIdMaterial", "sIdMaterial"),
                        new System.Data.Common.DataColumnMapping("sMaterial", "sMaterial"),
                        new System.Data.Common.DataColumnMapping("iCantidad", "iCantidad"),
                        new System.Data.Common.DataColumnMapping("fPrecio", "fPrecio"),
                        new System.Data.Common.DataColumnMapping("fDescuento", "fDescuento"),
                        new System.Data.Common.DataColumnMapping("ImporteLin", "ImporteLin"),
                        new System.Data.Common.DataColumnMapping("PrecioUnitario", "PrecioUnitario"),
                        new System.Data.Common.DataColumnMapping("fDescuentoMaximo", "fDescuentoMaximo"),
                        new System.Data.Common.DataColumnMapping("fRentabilidad", "fRentabilidad"),
                        new System.Data.Common.DataColumnMapping("fCoste", "fCoste"),
                        new System.Data.Common.DataColumnMapping("idCampanya", "idCampanya"),
                        new System.Data.Common.DataColumnMapping("idArrastre", "idArrastre"),
                        new System.Data.Common.DataColumnMapping("NombreCampanya", "NombreCampanya"),
                        new System.Data.Common.DataColumnMapping("UnidMinimas", "UnidMinimas"),
                        new System.Data.Common.DataColumnMapping("sObligatorio", "sObligatorio"),
                        new System.Data.Common.DataColumnMapping("idGrupoMat", "idGrupoMat"),
                        new System.Data.Common.DataColumnMapping("sRechazo", "sRechazo"),
                        new System.Data.Common.DataColumnMapping("rechazo", "rechazo")})});
            // 
            // sqlSelectCommand5
            // 
            this.sqlSelectCommand5.CommandText = "ListaLineasPedido";
            this.sqlSelectCommand5.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand5.Connection = this.sqlConn;
            this.sqlSelectCommand5.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@sIdPedido", System.Data.SqlDbType.VarChar, 12)});
            // 
            // contextMenu1
            // 
            this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuNuevo,
            this.menuEditar,
            this.menuEliminar});
            // 
            // menuNuevo
            // 
            this.menuNuevo.Index = 0;
            this.menuNuevo.Shortcut = System.Windows.Forms.Shortcut.CtrlN;
            this.menuNuevo.Text = "Nuevo";
            this.menuNuevo.Click += new System.EventHandler(this.menuNuevo_Click);
            // 
            // menuEditar
            // 
            this.menuEditar.Index = 1;
            this.menuEditar.Shortcut = System.Windows.Forms.Shortcut.CtrlE;
            this.menuEditar.Text = "Editar";
            this.menuEditar.Click += new System.EventHandler(this.menuEditar_Click);
            // 
            // menuEliminar
            // 
            this.menuEliminar.Index = 2;
            this.menuEliminar.Shortcut = System.Windows.Forms.Shortcut.CtrlX;
            this.menuEliminar.Text = "Eliminar";
            this.menuEliminar.Click += new System.EventHandler(this.borrar_pedido);
            // 
            // sqlcmdSetPedidosCab
            // 
            this.sqlcmdSetPedidosCab.CommandText = "[SetPedidosCab]";
            this.sqlcmdSetPedidosCab.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlcmdSetPedidosCab.Connection = this.sqlConn;
            this.sqlcmdSetPedidosCab.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iAccion", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sIdPedido", System.Data.SqlDbType.VarChar, 12),
            new System.Data.SqlClient.SqlParameter("@sIdPedidoTemp", System.Data.SqlDbType.VarChar, 15),
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
            new System.Data.SqlClient.SqlParameter("@tObservaciones", System.Data.SqlDbType.VarChar, 2147483647),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt, 2),
            new System.Data.SqlClient.SqlParameter("@fFUM", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@bEnviadoCEN", System.Data.SqlDbType.Bit, 1),
            new System.Data.SqlClient.SqlParameter("@bEnviadoPDA", System.Data.SqlDbType.Bit, 1)});
            // 
            // sqlcmDelPedidoRetenido
            // 
            this.sqlcmDelPedidoRetenido.CommandText = "[DelPedidoRetenido]";
            this.sqlcmDelPedidoRetenido.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlcmDelPedidoRetenido.Connection = this.sqlConn;
            this.sqlcmDelPedidoRetenido.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@sIdPedido", System.Data.SqlDbType.VarChar, 12)});
            // 
            // ucBotoneraSecundaria1
            // 
            this.ucBotoneraSecundaria1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(117)))), ((int)(((byte)(1)))));
            this.ucBotoneraSecundaria1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucBotoneraSecundaria1.ForeColor = System.Drawing.Color.Black;
            this.ucBotoneraSecundaria1.Location = new System.Drawing.Point(0, 0);
            this.ucBotoneraSecundaria1.Name = "ucBotoneraSecundaria1";
            this.ucBotoneraSecundaria1.Size = new System.Drawing.Size(1519, 38);
            this.ucBotoneraSecundaria1.TabIndex = 25;
            // 
            // sqlcmdSetPedidosLin
            // 
            this.sqlcmdSetPedidosLin.CommandText = "[SetPedidosLin]";
            this.sqlcmdSetPedidosLin.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlcmdSetPedidosLin.Connection = this.sqlConn;
            this.sqlcmdSetPedidosLin.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
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
            new System.Data.SqlClient.SqlParameter("@iBonificacion", System.Data.SqlDbType.Bit, 1)});
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.lblCuentaPedidos);
            this.panel4.Controls.Add(this.labelGradient6);
            this.panel4.Controls.Add(this.dgCabeceraPedidos);
            this.panel4.Location = new System.Drawing.Point(2, 178);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1513, 343);
            this.panel4.TabIndex = 26;
            // 
            // lblCuentaPedidos
            // 
            this.lblCuentaPedidos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.lblCuentaPedidos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCuentaPedidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCuentaPedidos.ForeColor = System.Drawing.Color.Black;
            this.lblCuentaPedidos.Location = new System.Drawing.Point(1435, 0);
            this.lblCuentaPedidos.Name = "lblCuentaPedidos";
            this.lblCuentaPedidos.Size = new System.Drawing.Size(74, 22);
            this.lblCuentaPedidos.TabIndex = 88;
            this.lblCuentaPedidos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelGradient6
            // 
            this.labelGradient6.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelGradient6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGradient6.ForeColor = System.Drawing.Color.White;
            this.labelGradient6.GradientColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.labelGradient6.GradientColorTwo = System.Drawing.Color.White;
            this.labelGradient6.Location = new System.Drawing.Point(0, 0);
            this.labelGradient6.Name = "labelGradient6";
            this.labelGradient6.Size = new System.Drawing.Size(1509, 22);
            this.labelGradient6.TabIndex = 87;
            this.labelGradient6.Text = "Pedidos";
            this.labelGradient6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sqldaListaEstadosPedidos
            // 
            this.sqldaListaEstadosPedidos.SelectCommand = this.sqlSelectCommand6;
            this.sqldaListaEstadosPedidos.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaTipoEstadosPedidos", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("sValor", "sValor"),
                        new System.Data.Common.DataColumnMapping("sLiteral", "sLiteral")})});
            // 
            // sqlSelectCommand6
            // 
            this.sqlSelectCommand6.CommandText = "[ListaTipoEstadosPedidos]";
            this.sqlSelectCommand6.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand6.Connection = this.sqlConn;
            this.sqlSelectCommand6.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null)});
            // 
            // sqldaListaCampCabecera
            // 
            this.sqldaListaCampCabecera.SelectCommand = this.sqlCommand4;
            this.sqldaListaCampCabecera.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaCampanyasCabecera", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("IdCampanya", "IdCampanya"),
                        new System.Data.Common.DataColumnMapping("NombreCampanya", "NombreCampanya"),
                        new System.Data.Common.DataColumnMapping("Descuento", "Descuento")})});
            // 
            // sqlCommand4
            // 
            this.sqlCommand4.CommandText = "dbo.ListaCampanyasCabecera";
            this.sqlCommand4.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCommand4.Connection = this.sqlConn;
            this.sqlCommand4.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null)});
            // 
            // sqldaGetTarjetasClientePedido
            // 
            this.sqldaGetTarjetasClientePedido.SelectCommand = this.sqlCmdGetTarjetasClientePedido;
            this.sqldaGetTarjetasClientePedido.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaTarjetasCliente", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("sIdMaterial", "sIdMaterial")})});
            // 
            // sqlCmdGetTarjetasClientePedido
            // 
            this.sqlCmdGetTarjetasClientePedido.CommandText = "[GetTarjetasClientePedido]";
            this.sqlCmdGetTarjetasClientePedido.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdGetTarjetasClientePedido.Connection = this.sqlConn;
            this.sqlCmdGetTarjetasClientePedido.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@sIdPedido", System.Data.SqlDbType.VarChar, 12)});
            // 
            // sqlCmdSetUsoTarjetasCliente
            // 
            this.sqlCmdSetUsoTarjetasCliente.CommandText = "[SetUsoTarjetasCliente]";
            this.sqlCmdSetUsoTarjetasCliente.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdSetUsoTarjetasCliente.Connection = this.sqlConn;
            this.sqlCmdSetUsoTarjetasCliente.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@sIdCliente", System.Data.SqlDbType.VarChar, 20),
            new System.Data.SqlClient.SqlParameter("@sIdMaterial", System.Data.SqlDbType.VarChar, 18),
            new System.Data.SqlClient.SqlParameter("@dFecAsignacion", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@dFecUso", System.Data.SqlDbType.DateTime, 8)});
            // 
            // dsClientes1
            // 
            this.dsClientes1.DataSetName = "dsClientes";
            this.dsClientes1.Locale = new System.Globalization.CultureInfo("en-US");
            this.dsClientes1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // frmConsultaPedidos
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 19);
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.ClientSize = new System.Drawing.Size(1536, 760);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.ucBotoneraSecundaria1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmConsultaPedidos";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Consulta Pedidos";
            this.Closed += new System.EventHandler(this.frmConsultaPedidos_Closed);
            this.Load += new System.EventHandler(this.frmConsultaPedidos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgCabeceraPedidos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsFormularios1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbFechaPref)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLineas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsFormularios1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsMateriales1)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dsClientes1)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region frmConsultaPedidos_Load
        private void frmConsultaPedidos_Load(object sender, System.EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                GESTCRM.Utiles.Formato_Formulario(this);
                if (this.Parent == null)
                    this.WindowState = FormWindowState.Normal;

                Inicializar_Botonera();

                //Inicializar datagrid
                Utiles.Formatear_DgConFilabEnviadoCEN(dgCabeceraPedidos, null, contextMenu1);
                //GESTCRM.Utiles.Formatear_DataGrid(this, this.dgLineasPedidos, "C", true, null);
                dataGridViewLineas.RowsDefaultCellStyle.SelectionBackColor = Utiles.ColorSelecionFilaDataGrid;
                

                //				this.dsFormularios1.ListaTiposPedidoSAP.Rows.Clear();
                //				this.sqldaTipoPedido
                //Opcion Todos
                DataRow fila_pedido = this.dsFormularios1.ListaTipoPedido.NewRow();
                fila_pedido.BeginEdit();
                fila_pedido[0] = "T";
                fila_pedido[1] = "Todos";
                fila_pedido.EndEdit();
                this.dsFormularios1.ListaTipoPedido.Rows.InsertAt(fila_pedido, 0);

                //Tipo campaña: "todas"+"sin campaña"+CAMPAÑAS
                //DataRow fila_camp = this.dsFormularios1.ListaTipoCampPedido.NewRow();
                //fila_camp.BeginEdit();
                //fila_camp[0] = -2;
                //fila_camp[1] = "Todas";
                //fila_camp[2] = 0;
                //fila_camp.EndEdit();
                //this.dsFormularios1.ListaTipoCampPedido.Rows.InsertAt(fila_camp, 0);

                //RH
                dsFormularios.ListaCampanyasCabeceraRow fila_camp = 
                    dsFormularios1.ListaCampanyasCabecera.NewListaCampanyasCabeceraRow();
                fila_camp.IdCampanya = "-2";
                fila_camp.NombreCampanya = "Todas";
                fila_camp.Descuento = 0;
                this.dsFormularios1.ListaCampanyasCabecera.Rows.InsertAt(fila_camp, 0);

                ////fila_camp = this.dsFormularios1.ListaTipoCampPedido.NewRow();
                //fila_camp = this.dsFormularios1.ListaCampanyasCabecera.NewRow();
                //fila_camp.BeginEdit();
                //fila_camp[0] = -1;
                //fila_camp[1] = "Sin Campaña";
                //fila_camp[2] = 0;
                //fila_camp.EndEdit();
                ////this.dsFormularios1.ListaTipoCampPedido.Rows.InsertAt(fila_camp, 0);
                //this.dsFormularios1.ListaCampanyasCabecera.Rows.InsertAt(fila_camp, 0);

                DataRow fila_dele = this.dsFormularios1.ListaDelegados.NewRow();
                fila_dele.BeginEdit();
                fila_dele[0] = -1;
                fila_dele[1] = "Todos";
                fila_dele.EndEdit();
                this.dsFormularios1.ListaDelegados.Rows.InsertAt(fila_dele, 0);

                this.sqldaListaEstadosPedidos.Fill(this.dsFormularios1);
                Cargar_ddlEstadosPedidos(this.cbEstadoEntregado);
                Cargar_ddlEstadosPedidos(this.cbEstadoFacturado);


                //DataPickers
                dtpFechaPedido.Format = DateTimePickerFormat.Custom;
                dtpFechaPedido.CustomFormat = " ";
                //---- GSG (10/03/2014)
                //dtpFechaPedido.Checked = false;
                dtpFechaPedido.Checked = true;

                dtpFechaPedidoEntre.Format = DateTimePickerFormat.Custom;
                dtpFechaPedidoEntre.CustomFormat = " ";
                dtpFechaPedidoEntre.Checked = false;

                //Llenar datacombos
                this.sqldaListaDelegados.Fill(this.dsFormularios1);
                //this.sqldaTipoCampaña.Fill(this.dsFormularios1);
                sqldaListaCampCabecera.Fill(this.dsFormularios1.ListaCampanyasCabecera);
                this.sqldaTipoPedido.Fill(this.dsFormularios1);

                //Por defecto seleccionar delegado de configuracion
                //---- GSG CECL 19/05/2016
                //cboDelegado.SelectedValue = Convert.ToInt32(Clases.Configuracion.ValorConf(1));

                if (System.Configuration.ConfigurationManager.AppSettings["TipoDelegadoPedidosCentral"].ToString() == Comun.K_CECL)
                    cboDelegado.SelectedValue = Clases.Configuracion.iIdDelegado;
                else
                    cboDelegado.SelectedValue = Convert.ToInt32(Clases.Configuracion.ValorConf(1));
                //---- FI GSG CECL 




                this.cargar_eventos();

                if (GESTCRM.Clases.Configuracion.iGPedidos != 0)
                {
                    this.menuNuevo.Enabled = false;
                    this.menuEliminar.Enabled = false;
                }
            }
            catch (Exception ev) 
            { 
                //MessageBox.Show("Falla evento load " + ev.ToString()); 
                Mensajes.ShowError("Falla evento load: " + ev.ToString()); 
            }

            Cursor.Current = Cursors.Default;

            dtpFechaPedido.Value = DateTime.Now.AddMonths(-3);
            dtpFechaPedido.Text = DateTime.Now.AddMonths(-3).ToShortDateString();
        }
        #endregion

        #region Inicializar_Botonera
        private void Inicializar_Botonera()
        {
            try
            {
                this.ucBotoneraSecundaria1.btSalir.Click += new EventHandler(salir);
                this.ucBotoneraSecundaria1.btNuevo.Click += new EventHandler(pedido_nuevo);
                this.ucBotoneraSecundaria1.btEditar.Click += new EventHandler(dgCabeceraPedidos_DobleClick);
                this.ucBotoneraSecundaria1.btEliminar.Click += new EventHandler(borrar_pedido);
                if (GESTCRM.Clases.Configuracion.iGPedidos == 0)
                {
                    this.ucBotoneraSecundaria1.Activar_botonera(true, true, true, true, false, false);
                }
                else
                {
                    this.ucBotoneraSecundaria1.Activar_botonera(true, false, true, false, false, false);
                }
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }
        #endregion

        #region Cargar_ddlEstadosPedidos
        private void Cargar_ddlEstadosPedidos(ComboBox cb)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("sValor");
            dt.Columns.Add("sLiteral");

            DataRow fila0 = dt.NewRow();
            fila0[0] = "T";
            fila0[1] = "Todos";
            dt.Rows.Add(fila0);

            DataRow fila1 = dt.NewRow(); ;
            fila1[0] = "-1";
            fila1[1] = "Sin Asignar";
            dt.Rows.Add(fila1);

            for (int i = 0; i < this.dsFormularios1.ListaTipoEstadosPedidos.Rows.Count; i++)
            {
                DataRow fila = dt.NewRow();
                fila[0] = this.dsFormularios1.ListaTipoEstadosPedidos.Rows[i]["sValor"].ToString();
                fila[1] = this.dsFormularios1.ListaTipoEstadosPedidos.Rows[i]["sLiteral"].ToString();

                dt.Rows.Add(fila);
            }

            cb.DataSource = dt;
            cb.ValueMember = "sValor";
            cb.DisplayMember = "sLiteral";
        }
        #endregion

        #region btnBuscar_Click
        private void btnBuscar_Click(object sender, System.EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                //Validar
                if (cboDelegado.SelectedValue == null)
                {
                    //MessageBox.Show("Debe elegir un delegado que este en la lista");
                    Mensajes.ShowInformation("Debe elegir un delegado que esté en la lista.");
                    return;
                }
                if (cboTipoCampanya.SelectedValue == null)
                {
                    //MessageBox.Show("Debe elegir un tipo de campaña que  este en la lista");
                    Mensajes.ShowInformation("Debe elegir un tipo de campaña que esté en la lista.");
                    return;
                }
                if (cboTipoPedido.SelectedValue == null)
                {
                    //MessageBox.Show("Debe elegir un Tipo de pedido que este en la lista");
                   Mensajes.ShowInformation("Debe elegir un Tipo de pedido que esté en la lista.");
                    return;
                }

                //Buscar Clientes

                //---- GSG CECL 19/05/2016
                if (System.Configuration.ConfigurationManager.AppSettings["TipoDelegadoPedidosCentral"].ToString() == Comun.K_CECL)
                    sqldaListaBuscaPedidos.SelectCommand = sqlSelectCommand4CECL;
                else
                    sqldaListaBuscaPedidos.SelectCommand = sqlSelectCommand4;
                //---- FI GSG CECL 


                this.dsFormularios1.ListaBuscaPedidos.Rows.Clear();
                this.lblCuentaPedidos.Text = "0";

                //this.sqldaListaBuscaPedidos.SelectCommand.Parameters.Clear();
                this.sqldaListaBuscaPedidos.SelectCommand.Parameters["@iIdDelegado"].Value = cboDelegado.SelectedValue;
                this.sqldaListaBuscaPedidos.SelectCommand.Parameters["@sIdCliente"].Value = (txtClienteSAP.Text.ToString() == "") ? null : txtClienteSAP.Text.ToString();
                this.sqldaListaBuscaPedidos.SelectCommand.Parameters["@sIdDestinatario"].Value = (txtDestinatarioSAP.Text.ToString() == "") ? null : txtDestinatarioSAP.Text.ToString();
                this.sqldaListaBuscaPedidos.SelectCommand.Parameters["@sIdTipoCampanya"].Value = (cboTipoCampanya.SelectedValue.ToString() == "-1") ? null : cboTipoCampanya.SelectedValue.ToString();

                if (dtpFechaPedido.Checked)
                    this.sqldaListaBuscaPedidos.SelectCommand.Parameters["@dFechaPedido"].Value = this.dtpFechaPedido.Value.ToLongDateString();
                else
                    this.sqldaListaBuscaPedidos.SelectCommand.Parameters["@dFechaPedido"].Value = null;

                if (dtpFechaPedidoEntre.Checked)
                    this.sqldaListaBuscaPedidos.SelectCommand.Parameters["@dFechaPedidoEntre"].Value = this.dtpFechaPedidoEntre.Value.ToLongDateString();
                else
                    this.sqldaListaBuscaPedidos.SelectCommand.Parameters["@dFechaPedidoEntre"].Value = null;

                this.sqldaListaBuscaPedidos.SelectCommand.Parameters["@sIdPedido"].Value = (txbsIdPedido.Text == "") ? null : txbsIdPedido.Text;
                this.sqldaListaBuscaPedidos.SelectCommand.Parameters["@sIdTipoPedido"].Value = (cboTipoPedido.SelectedValue.ToString() == "T") ? null : cboTipoPedido.SelectedValue;
                this.sqldaListaBuscaPedidos.SelectCommand.Parameters["@counter"].Value = 0;

                this.sqldaListaBuscaPedidos.SelectCommand.Parameters["@EstEntPedido"].Value = this.cbEstadoEntregado.SelectedValue.ToString();
                this.sqldaListaBuscaPedidos.SelectCommand.Parameters["@EstFacPedido"].Value = this.cbEstadoFacturado.SelectedValue.ToString();

                //---- GSG (23/01/2014)
                this.sqldaListaBuscaPedidos.SelectCommand.Parameters["@bRetenido"].Value = this.chkRetenido.Checked;


                this.sqldaListaBuscaPedidos.Fill(this.dsFormularios1);

                this.lblCuentaPedidos.Text = dsFormularios1.ListaBuscaPedidos.Rows.Count.ToString();
                dgCabeceraPedidos_CurrentCellChanged(sender, e);


                //marcar_los_enviados_a_central ();

            }
            catch (Exception ev) 
            { 
                //MessageBox.Show("Error en evento del boton buscar" + ev.ToString());
                Mensajes.ShowError("Error en evento del boton buscar: " + ev.ToString());
            }

            Cursor.Current = Cursors.Default;
        }
        #endregion

        #region salir
        private void salir(object sender, System.EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region marcar_los_enviados_a_central
        private void marcar_los_enviados_a_central()
        {
            try
            {
                Utiles.Formatear_DgConFilabEnviadoCEN(dgCabeceraPedidos, null, contextMenu1);
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }
        #endregion

        #region Buscar_Cliente
        private void btBuscarCliente_Click(object sender, System.EventArgs e)
        {
            int iDelegado;

            try
            {

                iDelegado = Convert.ToInt32(cboDelegado.SelectedValue.ToString());

                GESTCRM.Formularios.Busquedas.frmMClientesSAP frmBCli = new GESTCRM.Formularios.Busquedas.frmMClientesSAP("CP");

                frmBCli.ParamI_sIdTipoCliente = "S";
                frmBCli.ParamIO_sIdCliente = "";
                frmBCli.ParamI_sIdCentro = "";
                frmBCli.ParamI_iIdDelegado = (iDelegado != 0) ? iDelegado : -1;
                frmBCli.ShowDialog(this);

                if (frmBCli.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    this.txtClienteSAP.Text = frmBCli.ParamIO_sIdCliente;
                    this.txtsCliente.Text = frmBCli.ParamO_tNombre;
                    this.iIdCliente = frmBCli.ParamO_iIdCliente;
                }
            }
            catch (Exception ev)
            {
                //MessageBox.Show("Error en el evento del btn buscar cliente" + ev.ToString());
                Mensajes.ShowError("Error en el evento del botón Buscar Cliente: " + ev.ToString());
            }
        }


        private void txtClienteSAP_Leave(object sender, System.EventArgs e)
        {
            int iDelegado;

            try
            {
                iDelegado = Convert.ToInt32(cboDelegado.SelectedValue.ToString());

                GESTCRM.Formularios.Busquedas.frmMClientesSAP frmBCli = new GESTCRM.Formularios.Busquedas.frmMClientesSAP("C");

                frmBCli.ParamI_iIdDelegado = (iDelegado != 0) ? iDelegado : -1;
                frmBCli.ParamI_sIdCentro = "";
                frmBCli.ParamI_sIdTipoCliente = "";
                frmBCli.ParamIO_sIdCliente = this.txtClienteSAP.Text.ToString();
                frmBCli.Buscar_tNombre();

                this.txtClienteSAP.Text = frmBCli.ParamIO_sIdCliente;
                this.txtsCliente.Text = frmBCli.ParamO_tNombre;
                this.iIdCliente = frmBCli.ParamO_iIdCliente;

            }
            catch (Exception ev)
            {
                //MessageBox.Show("Error en el evento al salir del campo codigo cliente" + ev.ToString());
                Mensajes.ShowError("Error en el evento al salir del campo Código Cliente: " + ev.ToString());
            }

        }
        #endregion

        #region Buscar Destinatario
        private void btBuscarDestinatario_Click(object sender, System.EventArgs e)
        {

            txtDestinatarioSAP.Text = txtDestinatarioSAP.Text.Trim().ToUpper();
            int Interlocutor;
            int iIdCliente = -1;
            string sIdCliente = "";
            string sNombre = "";

            //---- GSG (31/05/2011)
            //if (cboTipoPedido.SelectedValue.ToString() == GESTCRM.Clases.Configuracion.sPedTransfer) Interlocutor = 0;
            if (Comun.IsInTheArray(cboTipoPedido.SelectedValue.ToString(), GESTCRM.Clases.Configuracion.asPedTransfer)) Interlocutor = 0;
            //---- FI GSG
            else if (cboTipoPedido.SelectedValue.ToString() == "T") Interlocutor = -1;
            else Interlocutor = 1;
            if (this.txtClienteSAP.Text != "")
            {
                sIdCliente = this.txtClienteSAP.Text.ToString();
                sNombre = this.txtsCliente.Text.ToString();
                iIdCliente = this.iIdCliente;
            }

            GESTCRM.Formularios.Busquedas.frmMMayoristas frmMayorista;
            frmMayorista = new GESTCRM.Formularios.Busquedas.frmMMayoristas(iIdCliente, sIdCliente, sNombre, Interlocutor);
            frmMayorista.ShowDialog();

            if (frmMayorista.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                txtDestinatarioSAP.Text = frmMayorista.ParamO_sIdMayorista;
                txtsDestinatario.Text = frmMayorista.ParamO_sNombreMayorista;
            }
        }


        private void txtDestinatarioSAP_Leave(object sender, System.EventArgs e)
        {
            int Interlocutor;
            int iIdCliente = -1;
            string sIdCliente = "";
            string sNombre = "";

            //---- GSG (31/05/2011)
            //if (cboTipoPedido.SelectedValue.ToString() == GESTCRM.Clases.Configuracion.sPedTransfer) Interlocutor = 0;
            if (Comun.IsInTheArray(cboTipoPedido.SelectedValue.ToString(), GESTCRM.Clases.Configuracion.asPedTransfer)) Interlocutor = 0;
            //---- FI GSG
            else if (cboTipoPedido.SelectedValue.ToString() == "T") Interlocutor = -1;
            else Interlocutor = 1;

            if (this.txtClienteSAP.Text != "")
            {
                iIdCliente = this.iIdCliente;
                sIdCliente = this.txtClienteSAP.Text.ToString();
                sNombre = this.txtsCliente.Text.ToString();
            }

            if (this.txtDestinatarioSAP.Text != "")
            {
                GESTCRM.Formularios.Busquedas.frmMMayoristas frmMayorista;
                frmMayorista = new GESTCRM.Formularios.Busquedas.frmMMayoristas(iIdCliente, sIdCliente, sNombre, Interlocutor);
                frmMayorista.DevuelveMayorista(txtDestinatarioSAP.Text);

                txtsDestinatario.Text = frmMayorista.ParamO_sNombreMayorista;
                this.txtDestinatarioSAP.Text = frmMayorista.ParamO_sIdMayorista;
                iIdDestinatario = frmMayorista.ParamO_iIdClienteMayorista;
            }
            else
            {
                txtsDestinatario.Text = "";
                this.txtDestinatarioSAP.Text = "";
                iIdDestinatario = -1;
            }
        }
        #endregion

        #region llamada_pedidos
        private void llamada_pedidos(bool parametros)
        {
            try
            {
                bool abierto = false;

                if (this.ParentForm == null) abierto = Utiles.MirarSiFormAbierto("frmPedidos", this.Owner);
                else abierto = Utiles.MirarSiFormAbierto("frmPedidos", this.ParentForm);

                if (!abierto)
                {
                    //Pedido nuevo
                    Form frmTemp;

                    if (!parametros)
                    {
                        //Comprobar tipo de acceso
                        if (GESTCRM.Clases.Configuracion.iGPedidos == 0)
                        {
                            int iIdDelegado = Convert.ToInt32(this.cboDelegado.SelectedValue.ToString());

                            if (iIdDelegado == GESTCRM.Clases.Configuracion.iIdDelegado) //Comprobar si el delegado de acceso es el de creación del pedido
                            {
                                frmTemp = new frmPedidos();
                                frmTemp.MdiParent = this.MdiParent;
                                frmTemp.Show();
                            }
                            else//else del delegado
                            {
                                Mensajes.ShowInformation("No se pueden crear pedidos de otro delegado.");
                            }
                        }
                    }
                    else
                    {
                        //Editar/Consultar pedido
                        if (dsFormularios1.ListaBuscaPedidos.Rows.Count > 0)
                        {
                            string sIdPedido = dgCabeceraPedidos[dgCabeceraPedidos.CurrentCell.RowNumber, 1].ToString();
                            //---- GSG (28/01/2011)
                            //L'import brut s'ha inserit a la columna 9 i per tant els que venen darrera s'han desplaçat
                            //int iIdDelegado = Convert.ToInt32(dgCabeceraPedidos[dgCabeceraPedidos.CurrentCell.RowNumber, 16].ToString());
                            int iIdDelegado = Convert.ToInt32(dgCabeceraPedidos[dgCabeceraPedidos.CurrentCell.RowNumber, 17].ToString());
                            //----FI GSG
                            char acceso = 'M';
                            //Comprobar si tipo de acceso 
                            if (GESTCRM.Clases.Configuracion.iGPedidos != 0) acceso = 'C';


                            //Comprobar si el delegado de acceso es el de creación del pedido

                            if (iIdDelegado == GESTCRM.Clases.Configuracion.iIdDelegado) 
                            {
                                frmTemp = new Formularios.frmPedidos(sIdPedido, iIdDelegado, acceso);
                                frmTemp.MdiParent = this.MdiParent;
                                frmTemp.Show();
                            }
                            else//else del delegado
                            {
                                Mensajes.ShowInformation("No se pueden modificar pedidos de otro delegado.");
                            }
                        }
                    }
                }
                else //existe un formulario de ficha pedido abierto
                {
                    string Mensaje = "";
                    if (!parametros) Mensaje = "No se puede crear un pedido porque ya hay uno abierto. ¿Desea ver el pedido abierto?";
                    else Mensaje = "No se puede modificar un pedido porque ya hay uno abierto. ¿Desea ver el pedido abierto?";

                    DialogResult dr = Mensajes.ShowQuestion(Mensaje);
                    if (dr == System.Windows.Forms.DialogResult.Yes)
                    {
                        GESTCRM.Utiles.ActivaFormularioAbierto("frmPedidos", this.MdiParent);
                    }
                }
            }
            catch (Exception ev)
            {
                //MessageBox.Show("Error en  llamada_pedidos " + ev.ToString());
                Mensajes.ShowError("Error en llamada_pedidos: " + ev.ToString());
            }
        }
        #endregion

        #region pcbFechaPref_Click
        private void pcbFechaPref_Click(object sender, System.EventArgs e)
        {
            try
            {
                //Vaciar la fecha
                dtpFechaPedido.CustomFormat = " ";
                dtpFechaPedido.Checked = false;
                dtpFechaPedidoEntre.CustomFormat = " ";
                dtpFechaPedidoEntre.Checked = false;
            }
            catch (Exception ev)
            {
                //MessageBox.Show("Error en el evento clic de pcbFechaPref (borrar fecha)" + ev.ToString());
                Mensajes.ShowError("Error en el evento clic de pcbFechaPref (borrar fecha): " + ev.ToString());
            }
        }
        #endregion

        #region Eventos DataGrid

        private void cargar_eventos()
        {
            try
            {
                for (int i = 0; i < dgCabeceraPedidos.TableStyles[0].GridColumnStyles.Count; i++)
                {
                    DataGridTextBoxColumn TextCol = (DataGridTextBoxColumn)dgCabeceraPedidos.TableStyles[0].GridColumnStyles[i];
                    TextCol.TextBox.DoubleClick += new EventHandler(dgCabeceraPedidos_DobleClick);
                }
            }
            catch (Exception ev)
            {
                //MessageBox.Show("Error en funcion cargar_eventos()" + ev.ToString());
                Mensajes.ShowError("Error en función cargar_eventos(): " + ev.ToString());
            }
        }



        private void dgCabeceraPedidos_DobleClick(object sender, System.EventArgs e)
        {
            try
            {
                llamada_pedidos(true);
            }
            catch (Exception ev)
            {
                //MessageBox.Show("Error en funcion dgCabeceraPedidos_DobleClick()" + ev.ToString());
                Mensajes.ShowError("Error en función dgCabeceraPedidos_DobleClick(): " + ev.ToString());
            }
        }


        private void dgCabeceraPedidos_CurrentCellChanged(object sender, System.EventArgs e)
        {
            String Text;
            DateTime FechaPref, FechaFij;

            try
            {
                //Estilo datagrid
                GESTCRM.Utiles.Seleccionar_UnaFilaDataGrid(this, this.dgCabeceraPedidos, this.dgCabeceraPedidos.CurrentRowIndex);

                //CurrencyManager cm = (CurrencyManager)Formulario.BindingContext[dgCabeceraPedidos.DataSource,dgCabeceraPedidos.DataMember];
                //DataView dv = (DataView)cm.List;



                //Limpieza
                this.dsMateriales1.ListaLineasPedido.Rows.Clear();
                txbObs.Text = txtFechaPref.Text = txtFechaFij.Text = "";

                //Continuara solo si hay registros de cabecera
                if (this.dsFormularios1.ListaBuscaPedidos.Rows.Count > 0)
                {
                    //Leer valores de las columnas ocultas

                    //---- GSG (28/01/2011)
                    //L'import brut s'ha inserit a la columna 9 i per tant els que venen darrera s'han desplaçat
                    //Text = dgCabeceraPedidos[dgCabeceraPedidos.CurrentRowIndex, 14].ToString();
                    //FechaPref = Convert.ToDateTime(dgCabeceraPedidos[dgCabeceraPedidos.CurrentRowIndex, 12].ToString());
                    //FechaFij = Convert.ToDateTime(dgCabeceraPedidos[dgCabeceraPedidos.CurrentRowIndex, 13].ToString());
                    Text = dgCabeceraPedidos[dgCabeceraPedidos.CurrentRowIndex, 15].ToString();
                    FechaPref = Convert.ToDateTime(dgCabeceraPedidos[dgCabeceraPedidos.CurrentRowIndex, 13].ToString());
                    FechaFij = Convert.ToDateTime(dgCabeceraPedidos[dgCabeceraPedidos.CurrentRowIndex, 14].ToString());
                    //---- FI GSG

                    //Mostrar los valores
                    txbObs.Text = Text;
                    if (FechaPref.ToString() != "")
                        txtFechaPref.Text = FechaPref.ToLongDateString().ToString();

                    if (FechaFij.ToString() != "")
                        txtFechaFij.Text = FechaFij.ToLongDateString().ToString();

                    refresca_grid_lineas();

                }
            }
            catch (Exception ev)
            {
                //MessageBox.Show("Error en dgCabeceraPedidos_CurrentCellChanged()" + ev.ToString());
                Mensajes.ShowError("Error en dgCabeceraPedidos_CurrentCellChanged(): " + ev.ToString());
            }
        }

        #endregion

        #region refresca_grid_cabecera
        private void refresca_grid_cabecera()
        {
            try
            {
                //---- GSG CECL 19/05/2016
                if (System.Configuration.ConfigurationManager.AppSettings["TipoDelegadoPedidosCentral"].ToString() == Comun.K_CECL)
                    sqldaListaBuscaPedidos.SelectCommand = sqlSelectCommand4CECL;
                else
                    sqldaListaBuscaPedidos.SelectCommand = sqlSelectCommand4;
                //---- FI GSG CECL 


                //Refrescar grid de cabeceras de pedidos
                dsFormularios1.ListaBuscaPedidos.Rows.Clear();
                sqldaListaBuscaPedidos.Fill(dsFormularios1.ListaBuscaPedidos);
                refresca_grid_lineas();
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }
        #endregion

        #region refresca_grid_lineas
        private void refresca_grid_lineas()
        {
            try
            {
                //Refrescar grid de lineas de pedidos
                sqldaListaLineasPedidos.SelectCommand.Parameters["@sIdPedido"].Value = dgCabeceraPedidos[dgCabeceraPedidos.CurrentRowIndex, 1].ToString();
                sqldaListaLineasPedidos.Fill(dsMateriales1.ListaLineasPedido);
                lblCuentaLineas.Text = dsMateriales1.ListaLineasPedido.Rows.Count.ToString();

                //RH
                FormatDataGridLineas();
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }
        #endregion

        #region pedido_nuevo
        private void pedido_nuevo(object sender, System.EventArgs e)
        {
            llamada_pedidos(false);
        }
        #endregion

        #region dtpFechaPedido_ValueChanged
        private void dtpFechaPedido_ValueChanged(object sender, System.EventArgs e)
        {
            this.dtpFechaPedido.CustomFormat = "";
        }
        #endregion

        #region dtpFechaPedidoEntre_ValueChanged
        private void dtpFechaPedidoEntre_ValueChanged(object sender, System.EventArgs e)
        {
            this.dtpFechaPedidoEntre.CustomFormat = "";
        }
        #endregion

        #region borrar_pedido --menuElimiar y botón de botonera principal
        private void borrar_pedido(object sender, System.EventArgs e)
        {

            if (GESTCRM.Clases.Configuracion.iGPedidos == 0)//tiene acceso de escritura
            {
                bool abierto = false;

                if (this.ParentForm == null)
                    abierto = Utiles.MirarSiFormAbierto("frmPedidos", this.Owner);
                else 
                    abierto = Utiles.MirarSiFormAbierto("frmPedidos", this.ParentForm);

                //---- GSG (21/10/2015)
                // Desfem aquesta condició i per tant una comanda sí podrá ser borrada encara que tingui una visita asociada.
                // Al eliminar la comanda eliminarem la relació amb la visita però no la visita en sí
                
                ////---- GSG (09/09/2011)
                ////Si la comanda està asociada a una visita no s'ha de poder borrar
                //string sIdPed = this.dgCabeceraPedidos[this.dgCabeceraPedidos.CurrentRowIndex, 1].ToString();
                //bool visita = false;
                //visita = MirarSiVisitaAsociada(sIdPed);
                ////---- FI GSG


                //---- GSG (28/01/2011)
                //L'import brut s'ha inserit a la columna 9 i per tant els que venen darrera s'han desplaçat
                //if (!Convert.ToBoolean(dgCabeceraPedidos[dgCabeceraPedidos.CurrentRowIndex, 19]))
                if (!Convert.ToBoolean(dgCabeceraPedidos[dgCabeceraPedidos.CurrentRowIndex, 20]))
                //---- FI GSG
                {

                    //---- GSG (09/09/2011)
                    //if (!abierto)
                    //---- GSG (21/10/2015)
                    //if (!abierto && !visita)
                    if (!abierto)
                    {
                        //---- GSG (28/01/2011)
                        //L'import brut s'ha inserit a la columna 9 i per tant els que venen darrera s'han desplaçat
                        //int iIdDelegado = Convert.ToInt32(dgCabeceraPedidos[dgCabeceraPedidos.CurrentRowIndex, 16].ToString());
                        int iIdDelegado = Convert.ToInt32(dgCabeceraPedidos[dgCabeceraPedidos.CurrentRowIndex, 17].ToString());
                        //---- FI GSG
                        if (iIdDelegado == GESTCRM.Clases.Configuracion.iIdDelegado)
                        {
                            SqlTransaction sqlTran;
                            
                            string sIdPedido = this.dgCabeceraPedidos[this.dgCabeceraPedidos.CurrentRowIndex, 1].ToString();
                            
                            if (Mensajes.ShowQuestion("¿Desea eliminar el pedido " + sIdPedido + "?") == DialogResult.Yes)
                            {

                                Cursor.Current = Cursors.WaitCursor;
                                if (sqlConn.State.ToString() == "Closed")
                                    sqlConn.Open();

                                sqlTran = sqlConn.BeginTransaction();

                                try
                                {
                                    //---- GSG (19/10/2015)
                                    // Tratar Tarjetas Cliente: si el pedido borrado llevaba tarjetas, estas deben liberarse
                                    // Hacerlo antes de borrar el pedido
                                    ActualizaTarjetasClienteBorradoPedido(sqlTran, sIdPedido);



                                    sqlcmdSetPedidosLin.Transaction = sqlTran;
                                    sqlcmdSetPedidosCab.Transaction = sqlTran;

                                    //---- GSG CECL 19/05/2016
                                    if (System.Configuration.ConfigurationManager.AppSettings["TipoDelegadoPedidosCentral"].ToString() == Comun.K_CECL)
                                    {
                                        sqlcmdSetPedidosCab.CommandText = "[SetPedidosCabCECL]";
                                        sqlcmdSetPedidosLin.CommandText = "[SetPedidosLinCECL]";
                                    }
                                    else
                                    {
                                        sqlcmdSetPedidosCab.CommandText = "[SetPedidosCab]";
                                        sqlcmdSetPedidosLin.CommandText = "[SetPedidosLin]";
                                    }
                                    //---- FI GSG CECL


                                    //Borrar Lineas del Pedido
                                    sqlcmdSetPedidosLin.Parameters["@iAccion"].Value = 2;
                                    sqlcmdSetPedidosLin.Parameters["@iIdLinea"].Value = -1;
                                    sqlcmdSetPedidosLin.Parameters["@sIdPedido"].Value = sIdPedido;
                                    sqlcmdSetPedidosLin.ExecuteNonQuery();

                                    //Borrar Cabecera del Pedido
                                    sqlcmdSetPedidosCab.Parameters["@iAccion"].Value = 2;
                                    sqlcmdSetPedidosCab.Parameters["@sIdPedido"].Value = sIdPedido;
                                    sqlcmdSetPedidosCab.ExecuteNonQuery();


                                    //---- GSG (04/07/2014)
                                    //Borrar el pedido de la tabla retenidos
                                    sqlcmDelPedidoRetenido.Transaction = sqlTran;
                                    sqlcmDelPedidoRetenido.Parameters["@sIdPedido"].Value = sIdPedido;
                                    sqlcmDelPedidoRetenido.ExecuteNonQuery();
                                    //---- FI GSG


                                    sqlTran.Commit();
                                    sqlConn.Close();
                                    btnBuscar_Click(sender, e);
                                    Cursor.Current = Cursors.Default;
                                }
                                catch (Exception ex)
                                {
                                    sqlTran.Rollback();
                                    Cursor.Current = Cursors.Default;
                                    //MessageBox.Show("No se ha podido eliminar. " + ex);
                                    Mensajes.ShowError("No se ha podido eliminar. " + ex);
                                }
                                finally
                                {
                                    sqlTran.Dispose();
                                }
                            }
                        }
                        else//else del delegado
                        {
                            Mensajes.ShowInformation("No se pueden eliminar pedidos de otro delegado.");
                        }
                    }//hay una ficha de pedido abierta
                    //---- GSG (09/09/2011)
                    //else
                    else // if (abierto) // ---- GSG (21/10/2015)
                    {
                        string Mensaje = "";
                        Mensaje = "No se puede eliminar un pedido porque ya hay uno abierto. ¿Desea ver el pedido abierto?";

                        DialogResult dr = Mensajes.ShowQuestion(Mensaje);
                        if (dr == System.Windows.Forms.DialogResult.Yes)
                        {
                            GESTCRM.Utiles.ActivaFormularioAbierto("frmPedidos", this.MdiParent);
                        }
                    }
                    // ---- GSG (21/10/2015)
                    //else if (visita)
                    //{
                    //    string Mensaje = "";
                    //    Mensaje = "No se puede eliminar un pedido porque está asociado a una visita. Modifique la visita antes de borrar el pedido";

                    //    Mensajes.ShowInformation(Mensaje);
                    //}
                }
                else
                {
                    Mensajes.ShowExclamation("No se pueden eliminar los pedidos enviados a central.");
                }
            }
        }
        #endregion

        #region menuEditar_Click
        private void menuEditar_Click(object sender, System.EventArgs e)
        {
            this.llamada_pedidos(true);
        }
        #endregion

        #region menuNuevo_Click
        private void menuNuevo_Click(object sender, System.EventArgs e)
        {
            this.llamada_pedidos(false);
        }
        #endregion

        #region frmConsultaPedidos_Closed
        private void frmConsultaPedidos_Closed(object sender, System.EventArgs e)
        {
            this.Dispose();
        }
        #endregion

        //RH
        private void FormatDataGridLineas()
        {
            dataGridViewLineas.DefaultCellStyle.ForeColor = Color.Black;
            for (int i = 0; i < dataGridViewLineas.Rows.Count - 1; i++)
            {
                if ((dataGridViewLineas.Rows[i].Cells["ColIdGrupoMat"].Value != DBNull.Value) &&
                    (dataGridViewLineas.Rows[i + 1].Cells["ColIdGrupoMat"].Value != DBNull.Value))
                {
                    if ((int)dataGridViewLineas.Rows[i].Cells["ColIdGrupoMat"].Value !=
                        (int)dataGridViewLineas.Rows[i + 1].Cells["ColIdGrupoMat"].Value)
                        dataGridViewLineas.Rows[i].DividerHeight = 1;
                }

                

            }


            //---- GSG (11/07/2016)            
            Utiles.pintaLineasGrid(dataGridViewLineas, Color.FromArgb(255, 180, 255), "ColCantidad");
        }


        //---- GSG (28/01/2011)
        private bool MirarSiVisitaAsociada(string sIdPed)
        {
            bool bRet = false;

            if (sqlConn.State.ToString() == "Closed")
                sqlConn.Open();
            SqlCommand sqlCmd = sqlConn.CreateCommand();
            sqlCmd.CommandText = "GetVisitaAsociadaPed";
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.Add("@sIdPedido", SqlDbType.VarChar, 12);
            sqlCmd.Parameters["@sIdPedido"].Value = sIdPed;
            SqlDataReader drConf = sqlCmd.ExecuteReader();

            if (drConf.Read())
            {
                bRet = true; 
            }

            drConf.Close();
            sqlConn.Close();


            return bRet;
        }
        

        //---- GSG (19/10/2015)
        private int GetTarjetasClientePedido(SqlTransaction sqlT, string psIdPedido)
        {
            int iRet = 0;

            this.dsClientes1.ListaTarjetasCliente.Rows.Clear();  //En este caso guardará las del pedido

            this.sqlCmdGetTarjetasClientePedido.Transaction = sqlT;

            try
            {
                this.sqlCmdGetTarjetasClientePedido.Parameters["@sIdPedido"].Value = psIdPedido;
                this.sqldaGetTarjetasClientePedido.Fill(this.dsClientes1);

                iRet = dsClientes1.ListaTarjetasCliente.Rows.Count;
            }
            catch (Exception e)
            {
                Mensajes.ShowError(e.Message);
            }

            return iRet;
        }


        private void ActualizaTarjetasClienteBorradoPedido(SqlTransaction sqlT, string psIdPedido)
        {
            int numTarjs = GetTarjetasClientePedido(sqlT, psIdPedido);

            if (numTarjs > 0)
            {
                foreach (GESTCRM.Formularios.DataSets.dsClientes.ListaTarjetasClienteRow row in dsClientes1.ListaTarjetasCliente.Rows)
                {
                    // Actualizar la tarjeta
                    DateTime fecUso = DateTime.MinValue;
                    SetUsoTarjetasCliente(sqlT, row.sIdCliente, row.sIdMaterial, row.dFecAsignacion, fecUso);
                }
            }
        }


        private void SetUsoTarjetasCliente(SqlTransaction sqlT, string psIdCliente, string psIdMaterial, DateTime pdFecAsignacion, DateTime pdFecUso)
        {
            try
            {
                this.sqlCmdSetUsoTarjetasCliente.Transaction = sqlT;

                sqlCmdSetUsoTarjetasCliente.Parameters["@sIdCliente"].Value = psIdCliente;
                sqlCmdSetUsoTarjetasCliente.Parameters["@sIdMaterial"].Value = psIdMaterial;
                sqlCmdSetUsoTarjetasCliente.Parameters["@dFecAsignacion"].Value = pdFecAsignacion;
                if (pdFecUso != DateTime.MinValue)
                    sqlCmdSetUsoTarjetasCliente.Parameters["@dFecUso"].Value = pdFecUso;

                sqlCmdSetUsoTarjetasCliente.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Mensajes.ShowError(e.ToString());
            }
        }

        //---- GSG (11/07/2016)
        private void dataGridViewLineas_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            // Do not automatically paint the focus rectangle.
            //e.PaintParts &= ~DataGridViewPaintParts.Focus;

            //if (int.Parse(dataGridViewLineas.Rows[e.RowIndex].Cells["ColCantidad"].Value.ToString()) == 0)
            //{
            //    Rectangle rowBounds = new Rectangle(
            //        this.dataGridViewLineas.RowHeadersWidth, e.RowBounds.Top,
            //        this.dataGridViewLineas.Columns.GetColumnsWidth(
            //            DataGridViewElementStates.Visible) -
            //        this.dataGridViewLineas.HorizontalScrollingOffset + 1,
            //        e.RowBounds.Height);
                
            //    using (Brush backbrush =
            //        new System.Drawing.Drawing2D.LinearGradientBrush(rowBounds,
            //            Color.FromArgb(224, 165, 220),
            //            Color.FromArgb(252, 245, 252),
            //            System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal))
            //    {
            //        e.Graphics.FillRectangle(backbrush, rowBounds);
            //    }
            //}
            //else
            //{
            //    Rectangle rowBounds = new Rectangle(
            //        this.dataGridViewLineas.RowHeadersWidth, e.RowBounds.Top,
            //        this.dataGridViewLineas.Columns.GetColumnsWidth(
            //            DataGridViewElementStates.Visible) -
            //        this.dataGridViewLineas.HorizontalScrollingOffset + 1,
            //        e.RowBounds.Height);

            //    using (Brush backbrush =
            //        new System.Drawing.Drawing2D.LinearGradientBrush(rowBounds,
            //            this.dataGridViewLineas.DefaultCellStyle.SelectionBackColor,
            //            e.InheritedRowStyle.ForeColor,
            //            System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal))
            //    {
            //        e.Graphics.FillRectangle(backbrush, rowBounds);
            //    }
            //}
        }


        
    }
}
