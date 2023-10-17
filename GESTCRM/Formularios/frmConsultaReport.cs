using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;


namespace GESTCRM.Formularios
{
	public class frmConsultaReport : System.Windows.Forms.Form
	{

		int Var_iIdCentro;
		int Var_iIdCliente;
		int Var_iIdReport;

		int Var_fila;

		private GESTCRM.Controles.ucBotoneraSecundaria ucBotoneraSecundaria1;
		private System.Windows.Forms.Button btBuscarCentro;
		private System.Windows.Forms.TextBox txtsCentro;
		private System.Windows.Forms.TextBox txtsIdCentro;
		private System.Windows.Forms.ComboBox cbDelegado;
		private System.Windows.Forms.Label lblTipoMedio;
		private System.Windows.Forms.Button btBuscar;
		private System.Windows.Forms.Label lblCentro;
		private System.Windows.Forms.Label lblTipoCli;
		private System.Windows.Forms.Panel pnBuscar;
		private System.Data.SqlClient.SqlConnection sqlConn;
		private System.Data.SqlClient.SqlDataAdapter sqldaListaDelegados;
		private GESTCRM.Controles.LabelGradient lblGBusquedaRep;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		private GESTCRM.Formularios.DataSets.dsReports dsReports1;
		private System.Data.SqlClient.SqlDataAdapter sqldaTipoRActividad;
		private System.Data.SqlClient.SqlDataAdapter sqldaTipoCliente;
		private System.Data.SqlClient.SqlDataAdapter sqldaTipoHorarioRep;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand4;
		private System.Windows.Forms.ComboBox cbTipoCliente;
		private System.Windows.Forms.Label lblTipoCliente;
		private System.Windows.Forms.ComboBox cbTipoReport;
		private System.Windows.Forms.ComboBox cbHorario;
		private System.Windows.Forms.Label lblHorario;
		private System.Windows.Forms.ComboBox cbPlanificacion;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtsIdCliente;
		private System.Windows.Forms.Button btBuscarCliente;
		private System.Windows.Forms.TextBox txtsCliente;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.DateTimePicker dtpFechaIni;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.DateTimePicker dtpFechaFin;
		private System.Data.SqlClient.SqlDataAdapter sqldaListaPlanificacion;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand5;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Label lblNumRegistros;
		private GESTCRM.Controles.LabelGradient labelGradient6;
		private System.Windows.Forms.DataGrid dtgGeneral;
		private System.Data.SqlClient.SqlDataAdapter sqldaListaRepActividad_Cab_Consulta;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn5;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn6;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn7;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn8;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn9;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn10;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn11;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn12;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn13;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn14;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn15;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn16;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem menuNuevo;
		private System.Windows.Forms.MenuItem menuEditar;
		private System.Windows.Forms.MenuItem menuEliminar;
		private System.Windows.Forms.ToolTip toolTipReport;
		private System.Data.SqlClient.SqlCommand sqlcmdSetRepActividad_Cab;
		private System.Windows.Forms.Panel pnDatosReport;
		private System.Windows.Forms.TextBox txtdFecha;
		private System.Windows.Forms.TextBox txtbPLanificacion;
		private System.Windows.Forms.TextBox txtTipoRActividad;
		private System.Windows.Forms.TextBox txtTipoCliente;
		private System.Windows.Forms.TextBox txtHorario;
		private System.Windows.Forms.TextBox txtCentro;
		private System.Windows.Forms.TextBox txtCentroDesc;
		private System.Windows.Forms.TextBox txtObservaciones;
		private System.Windows.Forms.TextBox txtObjetivo;
		private System.Windows.Forms.TextBox txtProxObj;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Button btClientes;
		private System.Windows.Forms.Button btDatos;
		private System.Windows.Forms.Panel pnClientes;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private System.Data.SqlClient.SqlDataAdapter sqldaListaRepActividad_Cli;
		private System.Data.SqlClient.SqlDataAdapter sqldaListaRepActividad_Gadget;
		private System.Data.SqlClient.SqlDataAdapter sqldaListaRepActividadAtenciones;
		private System.Data.SqlClient.SqlDataAdapter sqldaRepActividad_Pedidos;
		private GESTCRM.Controles.LabelGradient labelGradient1;
		private GESTCRM.Controles.LabelGradient labelGradient2;
		private GESTCRM.Controles.LabelGradient labelGradient3;
		private GESTCRM.Controles.LabelGradient labelGradient4;
		private System.Windows.Forms.Label lblTotClientes;
		private System.Windows.Forms.Label lblTotGadgets;
		private System.Windows.Forms.Label lblTotAtenciones;
		private System.Windows.Forms.Label lblTotPedidos;
		private System.Windows.Forms.DataGrid dgPedidos;
		private System.Windows.Forms.DataGrid dgAtenciones;
		private System.Windows.Forms.DataGrid dgGadgets;
		private System.Windows.Forms.DataGrid dgClientes;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn17;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn18;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn19;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn20;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle3;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn21;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn22;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle4;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn23;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn24;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn25;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle5;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn27;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn28;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand8;
		private System.Windows.Forms.TextBox txtClienteObserv;
		private System.Windows.Forms.TextBox txtClienteObjetivo;
		private System.Windows.Forms.TextBox txtClienteProxObj;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn29;
		private System.Windows.Forms.Panel pnDatosCliente;
		private System.Windows.Forms.Panel pnProxObj;
		private GESTCRM.Controles.LabelGradient labelGradient5;
		private System.Windows.Forms.Label lblTotProxObj;
		private System.Windows.Forms.DataGrid dgProxObj;
		private GESTCRM.Controles.LabelGradient labelGradient7;
		private System.Windows.Forms.Label lblTotProductos;
		private System.Windows.Forms.DataGrid dgProductos;
		private System.Data.SqlClient.SqlDataAdapter sqldaListaRepActividadCli_ProxObj;
		private System.Data.SqlClient.SqlDataAdapter sqldaListaRepActividadProd;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand12;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle6;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle7;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn35;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn36;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn37;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn38;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand11;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand7;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand10;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn39;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn40;
		private System.Windows.Forms.Label lblToolTipBoton;
		private System.Windows.Forms.Label lblToolTipBtPed;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand6;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand9;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn41;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn42;
		private System.Data.SqlClient.SqlCommand sqlCmdGetPuedeBorrarReport;
		private System.Windows.Forms.DataGridTextBoxColumn dgtsDescripcion;
		private System.Windows.Forms.DataGridTextBoxColumn dgtOrden;
		private System.Windows.Forms.DataGridTextBoxColumn dgtiCantidad;
		private System.Windows.Forms.DataGridTextBoxColumn dgtsIdProducto;
		private System.Windows.Forms.DataGridTextBoxColumn dgtiIdCliente;
		private System.Windows.Forms.Panel pnPromociones;
		private System.Windows.Forms.Panel pnPedidosAsociados;
		private System.Data.SqlClient.SqlDataAdapter sqldaListaPromocionProd;
		private System.Data.SqlClient.SqlCommand sqlCommand1;
		private System.ComponentModel.IContainer components = null;

		public frmConsultaReport()
		{
            InitializeComponent();

            //---- GSG (06/03/2021)
            Utiles.GetConfigConnection();
            this.sqlConn.ConnectionString = Utiles._connection.ConnectionString.ToString();

		}

		/// <summary>
		/// Limpiar los recursos que se estén utilizando.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Designer generated code
		/// <summary>
		/// Método necesario para admitir el Diseñador, no se puede modificar
		/// el contenido del método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsultaReport));
            this.ucBotoneraSecundaria1 = new GESTCRM.Controles.ucBotoneraSecundaria();
            this.pnBuscar = new System.Windows.Forms.Panel();
            this.dtpFechaIni = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.txtsIdCliente = new System.Windows.Forms.TextBox();
            this.btBuscarCliente = new System.Windows.Forms.Button();
            this.txtsCliente = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cbPlanificacion = new System.Windows.Forms.ComboBox();
            this.dsReports1 = new GESTCRM.Formularios.DataSets.dsReports();
            this.label1 = new System.Windows.Forms.Label();
            this.cbHorario = new System.Windows.Forms.ComboBox();
            this.lblHorario = new System.Windows.Forms.Label();
            this.lblGBusquedaRep = new GESTCRM.Controles.LabelGradient();
            this.btBuscarCentro = new System.Windows.Forms.Button();
            this.txtsCentro = new System.Windows.Forms.TextBox();
            this.txtsIdCentro = new System.Windows.Forms.TextBox();
            this.cbTipoCliente = new System.Windows.Forms.ComboBox();
            this.lblTipoCliente = new System.Windows.Forms.Label();
            this.cbTipoReport = new System.Windows.Forms.ComboBox();
            this.cbDelegado = new System.Windows.Forms.ComboBox();
            this.lblTipoMedio = new System.Windows.Forms.Label();
            this.btBuscar = new System.Windows.Forms.Button();
            this.lblCentro = new System.Windows.Forms.Label();
            this.lblTipoCli = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.sqlConn = new System.Data.SqlClient.SqlConnection();
            this.sqldaListaDelegados = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqldaTipoRActividad = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
            this.sqldaTipoCliente = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
            this.sqldaTipoHorarioRep = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand4 = new System.Data.SqlClient.SqlCommand();
            this.sqldaListaPlanificacion = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand5 = new System.Data.SqlClient.SqlCommand();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblNumRegistros = new System.Windows.Forms.Label();
            this.labelGradient6 = new GESTCRM.Controles.LabelGradient();
            this.dtgGeneral = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn5 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn15 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn6 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn7 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn8 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn9 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn10 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn11 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn12 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn13 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn14 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn16 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.sqldaListaRepActividad_Cab_Consulta = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand6 = new System.Data.SqlClient.SqlCommand();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.menuNuevo = new System.Windows.Forms.MenuItem();
            this.menuEditar = new System.Windows.Forms.MenuItem();
            this.menuEliminar = new System.Windows.Forms.MenuItem();
            this.toolTipReport = new System.Windows.Forms.ToolTip(this.components);
            this.sqlcmdSetRepActividad_Cab = new System.Data.SqlClient.SqlCommand();
            this.pnDatosReport = new System.Windows.Forms.Panel();
            this.txtProxObj = new System.Windows.Forms.TextBox();
            this.txtObjetivo = new System.Windows.Forms.TextBox();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.txtHorario = new System.Windows.Forms.TextBox();
            this.txtTipoCliente = new System.Windows.Forms.TextBox();
            this.txtTipoRActividad = new System.Windows.Forms.TextBox();
            this.txtbPLanificacion = new System.Windows.Forms.TextBox();
            this.txtdFecha = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCentroDesc = new System.Windows.Forms.TextBox();
            this.txtCentro = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btClientes = new System.Windows.Forms.Button();
            this.btDatos = new System.Windows.Forms.Button();
            this.pnClientes = new System.Windows.Forms.Panel();
            this.pnProxObj = new System.Windows.Forms.Panel();
            this.dgProxObj = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle7 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn35 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn36 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn37 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn38 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.lblTotProxObj = new System.Windows.Forms.Label();
            this.labelGradient5 = new GESTCRM.Controles.LabelGradient();
            this.pnDatosCliente = new System.Windows.Forms.Panel();
            this.pnPromociones = new System.Windows.Forms.Panel();
            this.dgProductos = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle6 = new System.Windows.Forms.DataGridTableStyle();
            this.dgtsDescripcion = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dgtOrden = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dgtiCantidad = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dgtsIdProducto = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dgtiIdCliente = new System.Windows.Forms.DataGridTextBoxColumn();
            this.lblTotProductos = new System.Windows.Forms.Label();
            this.labelGradient7 = new GESTCRM.Controles.LabelGradient();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgGadgets = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle3 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn21 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn22 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.lblTotGadgets = new System.Windows.Forms.Label();
            this.labelGradient2 = new GESTCRM.Controles.LabelGradient();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgAtenciones = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle4 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn23 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn41 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn42 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn24 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn25 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.lblTotAtenciones = new System.Windows.Forms.Label();
            this.labelGradient3 = new GESTCRM.Controles.LabelGradient();
            this.pnPedidosAsociados = new System.Windows.Forms.Panel();
            this.lblToolTipBtPed = new System.Windows.Forms.Label();
            this.dgPedidos = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle5 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn27 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn28 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn29 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn40 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.lblTotPedidos = new System.Windows.Forms.Label();
            this.labelGradient4 = new GESTCRM.Controles.LabelGradient();
            this.txtClienteObserv = new System.Windows.Forms.TextBox();
            this.txtClienteObjetivo = new System.Windows.Forms.TextBox();
            this.txtClienteProxObj = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblToolTipBoton = new System.Windows.Forms.Label();
            this.dgClientes = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn17 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn18 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn19 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn20 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn39 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.lblTotClientes = new System.Windows.Forms.Label();
            this.labelGradient1 = new GESTCRM.Controles.LabelGradient();
            this.sqldaListaRepActividad_Cli = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand7 = new System.Data.SqlClient.SqlCommand();
            this.sqldaListaRepActividad_Gadget = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand8 = new System.Data.SqlClient.SqlCommand();
            this.sqldaListaRepActividadAtenciones = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand9 = new System.Data.SqlClient.SqlCommand();
            this.sqldaRepActividad_Pedidos = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand10 = new System.Data.SqlClient.SqlCommand();
            this.sqldaListaRepActividadCli_ProxObj = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand11 = new System.Data.SqlClient.SqlCommand();
            this.sqldaListaRepActividadProd = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand12 = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdGetPuedeBorrarReport = new System.Data.SqlClient.SqlCommand();
            this.sqldaListaPromocionProd = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCommand1 = new System.Data.SqlClient.SqlCommand();
            this.pnBuscar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsReports1)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgGeneral)).BeginInit();
            this.pnDatosReport.SuspendLayout();
            this.pnClientes.SuspendLayout();
            this.pnProxObj.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgProxObj)).BeginInit();
            this.pnDatosCliente.SuspendLayout();
            this.pnPromociones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgProductos)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgGadgets)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgAtenciones)).BeginInit();
            this.pnPedidosAsociados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPedidos)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // ucBotoneraSecundaria1
            // 
            this.ucBotoneraSecundaria1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(117)))), ((int)(((byte)(1)))));
            this.ucBotoneraSecundaria1.ForeColor = System.Drawing.Color.Black;
            this.ucBotoneraSecundaria1.Location = new System.Drawing.Point(1, 2);
            this.ucBotoneraSecundaria1.Name = "ucBotoneraSecundaria1";
            this.ucBotoneraSecundaria1.Size = new System.Drawing.Size(1876, 36);
            this.ucBotoneraSecundaria1.TabIndex = 7;
            // 
            // pnBuscar
            // 
            this.pnBuscar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnBuscar.Controls.Add(this.dtpFechaIni);
            this.pnBuscar.Controls.Add(this.label3);
            this.pnBuscar.Controls.Add(this.dtpFechaFin);
            this.pnBuscar.Controls.Add(this.txtsIdCliente);
            this.pnBuscar.Controls.Add(this.btBuscarCliente);
            this.pnBuscar.Controls.Add(this.txtsCliente);
            this.pnBuscar.Controls.Add(this.label9);
            this.pnBuscar.Controls.Add(this.cbPlanificacion);
            this.pnBuscar.Controls.Add(this.label1);
            this.pnBuscar.Controls.Add(this.cbHorario);
            this.pnBuscar.Controls.Add(this.lblHorario);
            this.pnBuscar.Controls.Add(this.lblGBusquedaRep);
            this.pnBuscar.Controls.Add(this.btBuscarCentro);
            this.pnBuscar.Controls.Add(this.txtsCentro);
            this.pnBuscar.Controls.Add(this.txtsIdCentro);
            this.pnBuscar.Controls.Add(this.cbTipoCliente);
            this.pnBuscar.Controls.Add(this.lblTipoCliente);
            this.pnBuscar.Controls.Add(this.cbTipoReport);
            this.pnBuscar.Controls.Add(this.cbDelegado);
            this.pnBuscar.Controls.Add(this.lblTipoMedio);
            this.pnBuscar.Controls.Add(this.btBuscar);
            this.pnBuscar.Controls.Add(this.lblCentro);
            this.pnBuscar.Controls.Add(this.lblTipoCli);
            this.pnBuscar.Controls.Add(this.label2);
            this.pnBuscar.ForeColor = System.Drawing.Color.Black;
            this.pnBuscar.Location = new System.Drawing.Point(3, 39);
            this.pnBuscar.Name = "pnBuscar";
            this.pnBuscar.Size = new System.Drawing.Size(1874, 83);
            this.pnBuscar.TabIndex = 0;
            // 
            // dtpFechaIni
            // 
            this.dtpFechaIni.CalendarForeColor = System.Drawing.Color.Black;
            this.dtpFechaIni.CalendarMonthBackground = System.Drawing.Color.White;
            this.dtpFechaIni.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.dtpFechaIni.CalendarTitleForeColor = System.Drawing.Color.White;
            this.dtpFechaIni.CalendarTrailingForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dtpFechaIni.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaIni.Location = new System.Drawing.Point(388, 26);
            this.dtpFechaIni.Name = "dtpFechaIni";
            this.dtpFechaIni.Size = new System.Drawing.Size(106, 26);
            this.dtpFechaIni.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(329, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 20);
            this.label3.TabIndex = 76;
            this.label3.Text = "Fecha:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.CalendarForeColor = System.Drawing.Color.Black;
            this.dtpFechaFin.CalendarMonthBackground = System.Drawing.Color.White;
            this.dtpFechaFin.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.dtpFechaFin.CalendarTitleForeColor = System.Drawing.Color.White;
            this.dtpFechaFin.CalendarTrailingForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dtpFechaFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new System.Drawing.Point(543, 26);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(105, 26);
            this.dtpFechaFin.TabIndex = 2;
            // 
            // txtsIdCliente
            // 
            this.txtsIdCliente.BackColor = System.Drawing.Color.White;
            this.txtsIdCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsIdCliente.ForeColor = System.Drawing.Color.Black;
            this.txtsIdCliente.Location = new System.Drawing.Point(514, 53);
            this.txtsIdCliente.MaxLength = 20;
            this.txtsIdCliente.Name = "txtsIdCliente";
            this.txtsIdCliente.Size = new System.Drawing.Size(129, 26);
            this.txtsIdCliente.TabIndex = 10;
            this.txtsIdCliente.Leave += new System.EventHandler(this.txtsIdCliente_Leave);
            // 
            // btBuscarCliente
            // 
            this.btBuscarCliente.Image = ((System.Drawing.Image)(resources.GetObject("btBuscarCliente.Image")));
            this.btBuscarCliente.Location = new System.Drawing.Point(1021, 52);
            this.btBuscarCliente.Name = "btBuscarCliente";
            this.btBuscarCliente.Size = new System.Drawing.Size(28, 28);
            this.btBuscarCliente.TabIndex = 12;
            this.btBuscarCliente.TabStop = false;
            this.toolTipReport.SetToolTip(this.btBuscarCliente, "Buscar Cliente");
            this.btBuscarCliente.UseVisualStyleBackColor = true;
            this.btBuscarCliente.Click += new System.EventHandler(this.btBuscarCliente_Click);
            // 
            // txtsCliente
            // 
            this.txtsCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtsCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsCliente.ForeColor = System.Drawing.Color.Black;
            this.txtsCliente.Location = new System.Drawing.Point(647, 53);
            this.txtsCliente.Name = "txtsCliente";
            this.txtsCliente.ReadOnly = true;
            this.txtsCliente.Size = new System.Drawing.Size(363, 26);
            this.txtsCliente.TabIndex = 11;
            this.txtsCliente.TabStop = false;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(449, 56);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 20);
            this.label9.TabIndex = 72;
            this.label9.Text = "Cliente:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbPlanificacion
            // 
            this.cbPlanificacion.DataSource = this.dsReports1.ListaPlanificacion;
            this.cbPlanificacion.DisplayMember = "Descripcion";
            this.cbPlanificacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPlanificacion.ItemHeight = 20;
            this.cbPlanificacion.Location = new System.Drawing.Point(767, 26);
            this.cbPlanificacion.Name = "cbPlanificacion";
            this.cbPlanificacion.Size = new System.Drawing.Size(153, 28);
            this.cbPlanificacion.TabIndex = 3;
            this.cbPlanificacion.ValueMember = "Valor";
            this.cbPlanificacion.Leave += new System.EventHandler(this.cbPlanificacion_Leave);
            // 
            // dsReports1
            // 
            this.dsReports1.DataSetName = "dsReports";
            this.dsReports1.Locale = new System.Globalization.CultureInfo("es-ES");
            this.dsReports1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(665, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 20);
            this.label1.TabIndex = 68;
            this.label1.Text = "Planificacion:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbHorario
            // 
            this.cbHorario.BackColor = System.Drawing.Color.White;
            this.cbHorario.DataSource = this.dsReports1.ListaTipoHorarioRep;
            this.cbHorario.DisplayMember = "sLiteral";
            this.cbHorario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHorario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbHorario.ForeColor = System.Drawing.Color.Black;
            this.cbHorario.Location = new System.Drawing.Point(1534, 23);
            this.cbHorario.Name = "cbHorario";
            this.cbHorario.Size = new System.Drawing.Size(94, 28);
            this.cbHorario.TabIndex = 6;
            this.cbHorario.ValueMember = "sValor";
            this.cbHorario.Leave += new System.EventHandler(this.cbHorario_Leave);
            // 
            // lblHorario
            // 
            this.lblHorario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHorario.ForeColor = System.Drawing.Color.Black;
            this.lblHorario.Location = new System.Drawing.Point(1469, 27);
            this.lblHorario.Name = "lblHorario";
            this.lblHorario.Size = new System.Drawing.Size(65, 20);
            this.lblHorario.TabIndex = 66;
            this.lblHorario.Text = "Horario:";
            this.lblHorario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblGBusquedaRep
            // 
            this.lblGBusquedaRep.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblGBusquedaRep.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGBusquedaRep.ForeColor = System.Drawing.Color.White;
            this.lblGBusquedaRep.GradientColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.lblGBusquedaRep.GradientColorTwo = System.Drawing.Color.White;
            this.lblGBusquedaRep.Location = new System.Drawing.Point(0, 0);
            this.lblGBusquedaRep.Name = "lblGBusquedaRep";
            this.lblGBusquedaRep.Size = new System.Drawing.Size(1872, 19);
            this.lblGBusquedaRep.TabIndex = 47;
            this.lblGBusquedaRep.Text = "Consulta de reports de actividad";
            // 
            // btBuscarCentro
            // 
            this.btBuscarCentro.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btBuscarCentro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btBuscarCentro.Image = ((System.Drawing.Image)(resources.GetObject("btBuscarCentro.Image")));
            this.btBuscarCentro.Location = new System.Drawing.Point(377, 53);
            this.btBuscarCentro.Name = "btBuscarCentro";
            this.btBuscarCentro.Size = new System.Drawing.Size(28, 28);
            this.btBuscarCentro.TabIndex = 9;
            this.btBuscarCentro.TabStop = false;
            this.toolTipReport.SetToolTip(this.btBuscarCentro, "Buscar Centro");
            this.btBuscarCentro.UseVisualStyleBackColor = true;
            this.btBuscarCentro.Click += new System.EventHandler(this.btBuscarCentro_Click);
            // 
            // txtsCentro
            // 
            this.txtsCentro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtsCentro.Enabled = false;
            this.txtsCentro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsCentro.Location = new System.Drawing.Point(170, 54);
            this.txtsCentro.Name = "txtsCentro";
            this.txtsCentro.Size = new System.Drawing.Size(207, 26);
            this.txtsCentro.TabIndex = 8;
            this.txtsCentro.TabStop = false;
            // 
            // txtsIdCentro
            // 
            this.txtsIdCentro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsIdCentro.Location = new System.Drawing.Point(70, 54);
            this.txtsIdCentro.MaxLength = 20;
            this.txtsIdCentro.Name = "txtsIdCentro";
            this.txtsIdCentro.Size = new System.Drawing.Size(100, 26);
            this.txtsIdCentro.TabIndex = 7;
            this.txtsIdCentro.Leave += new System.EventHandler(this.txtsIdCentro_Leave);
            // 
            // cbTipoCliente
            // 
            this.cbTipoCliente.DataSource = this.dsReports1.ListaTipoCliente;
            this.cbTipoCliente.DisplayMember = "sLiteral";
            this.cbTipoCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTipoCliente.ItemHeight = 20;
            this.cbTipoCliente.Location = new System.Drawing.Point(1329, 23);
            this.cbTipoCliente.Name = "cbTipoCliente";
            this.cbTipoCliente.Size = new System.Drawing.Size(123, 28);
            this.cbTipoCliente.TabIndex = 5;
            this.cbTipoCliente.ValueMember = "sValor";
            this.cbTipoCliente.Leave += new System.EventHandler(this.cbTipoCliente_Leave);
            // 
            // lblTipoCliente
            // 
            this.lblTipoCliente.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblTipoCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoCliente.Location = new System.Drawing.Point(1234, 27);
            this.lblTipoCliente.Name = "lblTipoCliente";
            this.lblTipoCliente.Size = new System.Drawing.Size(96, 20);
            this.lblTipoCliente.TabIndex = 29;
            this.lblTipoCliente.Text = "Tipo Cliente:";
            this.lblTipoCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbTipoReport
            // 
            this.cbTipoReport.DataSource = this.dsReports1.ListaTipoRActividad;
            this.cbTipoReport.DisplayMember = "sLiteral";
            this.cbTipoReport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTipoReport.ItemHeight = 20;
            this.cbTipoReport.Location = new System.Drawing.Point(1032, 23);
            this.cbTipoReport.Name = "cbTipoReport";
            this.cbTipoReport.Size = new System.Drawing.Size(186, 28);
            this.cbTipoReport.TabIndex = 4;
            this.cbTipoReport.ValueMember = "sValor";
            this.cbTipoReport.Leave += new System.EventHandler(this.cbTipoReport_Leave);
            // 
            // cbDelegado
            // 
            this.cbDelegado.DataSource = this.dsReports1.ListaDelegados;
            this.cbDelegado.DisplayMember = "sNombre";
            this.cbDelegado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDelegado.ItemHeight = 20;
            this.cbDelegado.Location = new System.Drawing.Point(48, 22);
            this.cbDelegado.Name = "cbDelegado";
            this.cbDelegado.Size = new System.Drawing.Size(257, 28);
            this.cbDelegado.TabIndex = 0;
            this.cbDelegado.ValueMember = "iIdDelegado";
            this.cbDelegado.Leave += new System.EventHandler(this.cbDelegado_Leave);
            // 
            // lblTipoMedio
            // 
            this.lblTipoMedio.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblTipoMedio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoMedio.Location = new System.Drawing.Point(8, 27);
            this.lblTipoMedio.Name = "lblTipoMedio";
            this.lblTipoMedio.Size = new System.Drawing.Size(41, 20);
            this.lblTipoMedio.TabIndex = 2;
            this.lblTipoMedio.Text = "Del.:";
            this.lblTipoMedio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btBuscar
            // 
            this.btBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btBuscar.Location = new System.Drawing.Point(1701, 27);
            this.btBuscar.Name = "btBuscar";
            this.btBuscar.Size = new System.Drawing.Size(71, 29);
            this.btBuscar.TabIndex = 13;
            this.btBuscar.Text = "Buscar";
            this.toolTipReport.SetToolTip(this.btBuscar, "Buscar Reports");
            this.btBuscar.UseVisualStyleBackColor = true;
            this.btBuscar.Click += new System.EventHandler(this.btBuscar_Click);
            // 
            // lblCentro
            // 
            this.lblCentro.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblCentro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCentro.Location = new System.Drawing.Point(7, 56);
            this.lblCentro.Name = "lblCentro";
            this.lblCentro.Size = new System.Drawing.Size(64, 20);
            this.lblCentro.TabIndex = 38;
            this.lblCentro.Text = "Centro:";
            this.lblCentro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTipoCli
            // 
            this.lblTipoCli.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblTipoCli.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoCli.Location = new System.Drawing.Point(935, 27);
            this.lblTipoCli.Name = "lblTipoCli";
            this.lblTipoCli.Size = new System.Drawing.Size(96, 20);
            this.lblTipoCli.TabIndex = 25;
            this.lblTipoCli.Text = "Tipo Report:";
            this.lblTipoCli.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(494, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 20);
            this.label2.TabIndex = 77;
            this.label2.Text = "entre";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sqlConn
            // 
            this.sqlConn.FireInfoMessageEventOnUserErrors = false;
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
            // sqldaTipoRActividad
            // 
            this.sqldaTipoRActividad.SelectCommand = this.sqlSelectCommand2;
            this.sqldaTipoRActividad.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaTipoRActividad", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("sValor", "sValor"),
                        new System.Data.Common.DataColumnMapping("sLiteral", "sLiteral")})});
            // 
            // sqlSelectCommand2
            // 
            this.sqlSelectCommand2.CommandText = "[ListaTipoRActividad]";
            this.sqlSelectCommand2.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand2.Connection = this.sqlConn;
            this.sqlSelectCommand2.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null)});
            // 
            // sqldaTipoCliente
            // 
            this.sqldaTipoCliente.SelectCommand = this.sqlSelectCommand3;
            this.sqldaTipoCliente.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaTipoCliente", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("sValor", "sValor"),
                        new System.Data.Common.DataColumnMapping("sLiteral", "sLiteral")})});
            // 
            // sqlSelectCommand3
            // 
            this.sqlSelectCommand3.CommandText = "[ListaTipoCliente]";
            this.sqlSelectCommand3.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand3.Connection = this.sqlConn;
            this.sqlSelectCommand3.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null)});
            // 
            // sqldaTipoHorarioRep
            // 
            this.sqldaTipoHorarioRep.SelectCommand = this.sqlSelectCommand4;
            this.sqldaTipoHorarioRep.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaTipoHorarioRep", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("sValor", "sValor"),
                        new System.Data.Common.DataColumnMapping("sLiteral", "sLiteral")})});
            // 
            // sqlSelectCommand4
            // 
            this.sqlSelectCommand4.CommandText = "[ListaTipoHorarioRep]";
            this.sqlSelectCommand4.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand4.Connection = this.sqlConn;
            this.sqlSelectCommand4.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null)});
            // 
            // sqldaListaPlanificacion
            // 
            this.sqldaListaPlanificacion.SelectCommand = this.sqlSelectCommand5;
            this.sqldaListaPlanificacion.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaPlanificacion", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("Orden", "Orden"),
                        new System.Data.Common.DataColumnMapping("Valor", "Valor"),
                        new System.Data.Common.DataColumnMapping("Descripcion", "Descripcion")})});
            // 
            // sqlSelectCommand5
            // 
            this.sqlSelectCommand5.CommandText = "[ListaPlanificacion]";
            this.sqlSelectCommand5.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand5.Connection = this.sqlConn;
            this.sqlSelectCommand5.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null)});
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.lblNumRegistros);
            this.panel4.Controls.Add(this.labelGradient6);
            this.panel4.Controls.Add(this.dtgGeneral);
            this.panel4.Location = new System.Drawing.Point(2, 125);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1874, 199);
            this.panel4.TabIndex = 1;
            // 
            // lblNumRegistros
            // 
            this.lblNumRegistros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.lblNumRegistros.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblNumRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumRegistros.ForeColor = System.Drawing.Color.Black;
            this.lblNumRegistros.Location = new System.Drawing.Point(1466, 0);
            this.lblNumRegistros.Name = "lblNumRegistros";
            this.lblNumRegistros.Size = new System.Drawing.Size(50, 16);
            this.lblNumRegistros.TabIndex = 27;
            this.lblNumRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelGradient6
            // 
            this.labelGradient6.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelGradient6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGradient6.ForeColor = System.Drawing.Color.White;
            this.labelGradient6.GradientColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.labelGradient6.GradientColorTwo = System.Drawing.Color.White;
            this.labelGradient6.Location = new System.Drawing.Point(0, 0);
            this.labelGradient6.Name = "labelGradient6";
            this.labelGradient6.Size = new System.Drawing.Size(1870, 16);
            this.labelGradient6.TabIndex = 0;
            this.labelGradient6.Text = "Reports de Actividad";
            this.labelGradient6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtgGeneral
            // 
            this.dtgGeneral.AlternatingBackColor = System.Drawing.Color.White;
            this.dtgGeneral.BackColor = System.Drawing.Color.White;
            this.dtgGeneral.BackgroundColor = System.Drawing.Color.White;
            this.dtgGeneral.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.dtgGeneral.CaptionForeColor = System.Drawing.Color.White;
            this.dtgGeneral.CaptionText = "Clientes";
            this.dtgGeneral.CaptionVisible = false;
            this.dtgGeneral.DataMember = "ListaRepActividad_Consulta";
            this.dtgGeneral.DataSource = this.dsReports1;
            this.dtgGeneral.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgGeneral.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgGeneral.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dtgGeneral.Location = new System.Drawing.Point(1, 17);
            this.dtgGeneral.Name = "dtgGeneral";
            this.dtgGeneral.ReadOnly = true;
            this.dtgGeneral.RowHeaderWidth = 30;
            this.dtgGeneral.SelectionBackColor = System.Drawing.Color.White;
            this.dtgGeneral.SelectionForeColor = System.Drawing.Color.Black;
            this.dtgGeneral.Size = new System.Drawing.Size(1515, 175);
            this.dtgGeneral.TabIndex = 0;
            this.dtgGeneral.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            this.dtgGeneral.CurrentCellChanged += new System.EventHandler(this.dtgGeneral_CurrentCellChanged);
            this.dtgGeneral.DoubleClick += new System.EventHandler(this.dtgGeneral_DoubleClick);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.DataGrid = this.dtgGeneral;
            this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn1,
            this.dataGridTextBoxColumn2,
            this.dataGridTextBoxColumn3,
            this.dataGridTextBoxColumn4,
            this.dataGridTextBoxColumn5,
            this.dataGridTextBoxColumn15,
            this.dataGridTextBoxColumn6,
            this.dataGridTextBoxColumn7,
            this.dataGridTextBoxColumn8,
            this.dataGridTextBoxColumn9,
            this.dataGridTextBoxColumn10,
            this.dataGridTextBoxColumn11,
            this.dataGridTextBoxColumn12,
            this.dataGridTextBoxColumn13,
            this.dataGridTextBoxColumn14,
            this.dataGridTextBoxColumn16});
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle1.MappingName = "ListaRepActividad_Consulta";
            this.dataGridTableStyle1.RowHeaderWidth = 30;
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.MappingName = "iIdReport";
            this.dataGridTextBoxColumn1.NullText = "";
            this.dataGridTextBoxColumn1.Width = 0;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.MappingName = "iIdDelegado";
            this.dataGridTextBoxColumn2.NullText = "";
            this.dataGridTextBoxColumn2.Width = 0;
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.MappingName = "iIdCentro";
            this.dataGridTextBoxColumn3.NullText = "";
            this.dataGridTextBoxColumn3.Width = 0;
            // 
            // dataGridTextBoxColumn4
            // 
            this.dataGridTextBoxColumn4.Format = "";
            this.dataGridTextBoxColumn4.FormatInfo = null;
            this.dataGridTextBoxColumn4.MappingName = "bEnviadoCEN";
            this.dataGridTextBoxColumn4.NullText = "";
            this.dataGridTextBoxColumn4.Width = 0;
            // 
            // dataGridTextBoxColumn5
            // 
            this.dataGridTextBoxColumn5.Format = "dd/MM/yyyy";
            this.dataGridTextBoxColumn5.FormatInfo = null;
            this.dataGridTextBoxColumn5.HeaderText = "Fecha";
            this.dataGridTextBoxColumn5.MappingName = "Fecha";
            this.dataGridTextBoxColumn5.NullText = "";
            this.dataGridTextBoxColumn5.Width = 110;
            // 
            // dataGridTextBoxColumn15
            // 
            this.dataGridTextBoxColumn15.Format = "";
            this.dataGridTextBoxColumn15.FormatInfo = null;
            this.dataGridTextBoxColumn15.MappingName = "bPlanificacion";
            this.dataGridTextBoxColumn15.NullText = "";
            this.dataGridTextBoxColumn15.Width = 0;
            // 
            // dataGridTextBoxColumn6
            // 
            this.dataGridTextBoxColumn6.Format = "";
            this.dataGridTextBoxColumn6.FormatInfo = null;
            this.dataGridTextBoxColumn6.HeaderText = "Tipo";
            this.dataGridTextBoxColumn6.MappingName = "Planif";
            this.dataGridTextBoxColumn6.NullText = "";
            this.dataGridTextBoxColumn6.Width = 110;
            // 
            // dataGridTextBoxColumn7
            // 
            this.dataGridTextBoxColumn7.Format = "";
            this.dataGridTextBoxColumn7.FormatInfo = null;
            this.dataGridTextBoxColumn7.HeaderText = "¿Prox.Obj.?";
            this.dataGridTextBoxColumn7.MappingName = "ProxObj";
            this.dataGridTextBoxColumn7.NullText = "";
            this.dataGridTextBoxColumn7.Width = 110;
            // 
            // dataGridTextBoxColumn8
            // 
            this.dataGridTextBoxColumn8.Format = "";
            this.dataGridTextBoxColumn8.FormatInfo = null;
            this.dataGridTextBoxColumn8.MappingName = "sTipoRActividad";
            this.dataGridTextBoxColumn8.NullText = "";
            this.dataGridTextBoxColumn8.Width = 0;
            // 
            // dataGridTextBoxColumn9
            // 
            this.dataGridTextBoxColumn9.Format = "";
            this.dataGridTextBoxColumn9.FormatInfo = null;
            this.dataGridTextBoxColumn9.HeaderText = "Tipo Report";
            this.dataGridTextBoxColumn9.MappingName = "descTipoRActividad";
            this.dataGridTextBoxColumn9.NullText = "";
            this.dataGridTextBoxColumn9.Width = 120;
            // 
            // dataGridTextBoxColumn10
            // 
            this.dataGridTextBoxColumn10.Format = "";
            this.dataGridTextBoxColumn10.FormatInfo = null;
            this.dataGridTextBoxColumn10.MappingName = "sidTipoCliente";
            this.dataGridTextBoxColumn10.NullText = "";
            this.dataGridTextBoxColumn10.Width = 0;
            // 
            // dataGridTextBoxColumn11
            // 
            this.dataGridTextBoxColumn11.Format = "";
            this.dataGridTextBoxColumn11.FormatInfo = null;
            this.dataGridTextBoxColumn11.HeaderText = "Tipo Cliente";
            this.dataGridTextBoxColumn11.MappingName = "descTipoCliente";
            this.dataGridTextBoxColumn11.NullText = "";
            this.dataGridTextBoxColumn11.Width = 110;
            // 
            // dataGridTextBoxColumn12
            // 
            this.dataGridTextBoxColumn12.Format = "";
            this.dataGridTextBoxColumn12.FormatInfo = null;
            this.dataGridTextBoxColumn12.MappingName = "iHorario";
            this.dataGridTextBoxColumn12.NullText = "";
            this.dataGridTextBoxColumn12.Width = 0;
            // 
            // dataGridTextBoxColumn13
            // 
            this.dataGridTextBoxColumn13.Format = "";
            this.dataGridTextBoxColumn13.FormatInfo = null;
            this.dataGridTextBoxColumn13.HeaderText = "Horario";
            this.dataGridTextBoxColumn13.MappingName = "tHorario";
            this.dataGridTextBoxColumn13.NullText = "";
            this.dataGridTextBoxColumn13.Width = 75;
            // 
            // dataGridTextBoxColumn14
            // 
            this.dataGridTextBoxColumn14.Format = "";
            this.dataGridTextBoxColumn14.FormatInfo = null;
            this.dataGridTextBoxColumn14.HeaderText = "Cliente/Centro Visitado";
            this.dataGridTextBoxColumn14.MappingName = "sNombre";
            this.dataGridTextBoxColumn14.NullText = "";
            this.dataGridTextBoxColumn14.Width = 500;
            // 
            // dataGridTextBoxColumn16
            // 
            this.dataGridTextBoxColumn16.Format = "";
            this.dataGridTextBoxColumn16.FormatInfo = null;
            this.dataGridTextBoxColumn16.HeaderText = "Delegado";
            this.dataGridTextBoxColumn16.MappingName = "sNombreDel";
            this.dataGridTextBoxColumn16.NullText = "";
            this.dataGridTextBoxColumn16.Width = 340;
            // 
            // sqldaListaRepActividad_Cab_Consulta
            // 
            this.sqldaListaRepActividad_Cab_Consulta.SelectCommand = this.sqlSelectCommand6;
            this.sqldaListaRepActividad_Cab_Consulta.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaRepActividad_Consulta", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iIdReport", "iIdReport"),
                        new System.Data.Common.DataColumnMapping("Fecha", "Fecha"),
                        new System.Data.Common.DataColumnMapping("iIdDelegado", "iIdDelegado"),
                        new System.Data.Common.DataColumnMapping("sIdReportTemp", "sIdReportTemp"),
                        new System.Data.Common.DataColumnMapping("dFecha", "dFecha"),
                        new System.Data.Common.DataColumnMapping("Planif", "Planif"),
                        new System.Data.Common.DataColumnMapping("ProxObj", "ProxObj"),
                        new System.Data.Common.DataColumnMapping("sTipoRActividad", "sTipoRActividad"),
                        new System.Data.Common.DataColumnMapping("descTipoRActividad", "descTipoRActividad"),
                        new System.Data.Common.DataColumnMapping("sidTipoCliente", "sidTipoCliente"),
                        new System.Data.Common.DataColumnMapping("descTipoCliente", "descTipoCliente"),
                        new System.Data.Common.DataColumnMapping("iHorario", "iHorario"),
                        new System.Data.Common.DataColumnMapping("tHorario", "tHorario"),
                        new System.Data.Common.DataColumnMapping("sNombre", "sNombre"),
                        new System.Data.Common.DataColumnMapping("sNombreDel", "sNombreDel"),
                        new System.Data.Common.DataColumnMapping("tObservaciones", "tObservaciones"),
                        new System.Data.Common.DataColumnMapping("tObjetivo", "tObjetivo"),
                        new System.Data.Common.DataColumnMapping("tProxObjetivo", "tProxObjetivo"),
                        new System.Data.Common.DataColumnMapping("iIdCentro", "iIdCentro"),
                        new System.Data.Common.DataColumnMapping("sIdCentro", "sIdCentro"),
                        new System.Data.Common.DataColumnMapping("sDescripcion", "sDescripcion"),
                        new System.Data.Common.DataColumnMapping("bEnviadoCEN", "bEnviadoCEN"),
                        new System.Data.Common.DataColumnMapping("bPlanificacion", "bPlanificacion"),
                        new System.Data.Common.DataColumnMapping("Seleccionado", "Seleccionado")})});
            // 
            // sqlSelectCommand6
            // 
            this.sqlSelectCommand6.CommandText = "[ListaRepActividad_Consulta]";
            this.sqlSelectCommand6.CommandTimeout = 60;
            this.sqlSelectCommand6.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand6.Connection = this.sqlConn;
            this.sqlSelectCommand6.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdDelegado", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@bPlanificacion", System.Data.SqlDbType.SmallInt, 2),
            new System.Data.SqlClient.SqlParameter("@sTipoRActividad", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@iHorario", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@sIdTipoCliente", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@iIdCentro", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@dFechaIni", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@dFechaFin", System.Data.SqlDbType.DateTime, 8)});
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
            this.menuNuevo.Click += new System.EventHandler(this.btNuevo_Click);
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
            this.menuEliminar.Click += new System.EventHandler(this.btEliminar_Click);
            // 
            // sqlcmdSetRepActividad_Cab
            // 
            this.sqlcmdSetRepActividad_Cab.CommandText = "[SetRepActividad_Cab]";
            this.sqlcmdSetRepActividad_Cab.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlcmdSetRepActividad_Cab.Connection = this.sqlConn;
            this.sqlcmdSetRepActividad_Cab.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@Accion", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdReport", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdDelegado", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sIdReportTemp", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@sTipoRActividad", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@sIdTipoCliente", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@iIdCentro", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@dFecha", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@iHorario", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@tObjetivo", System.Data.SqlDbType.VarChar, 2147483647),
            new System.Data.SqlClient.SqlParameter("@tProxObjetivo", System.Data.SqlDbType.VarChar, 2147483647),
            new System.Data.SqlClient.SqlParameter("@tObservaciones", System.Data.SqlDbType.VarChar, 2147483647),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt, 2)});
            // 
            // pnDatosReport
            // 
            this.pnDatosReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnDatosReport.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnDatosReport.Controls.Add(this.txtProxObj);
            this.pnDatosReport.Controls.Add(this.txtObjetivo);
            this.pnDatosReport.Controls.Add(this.txtObservaciones);
            this.pnDatosReport.Controls.Add(this.txtHorario);
            this.pnDatosReport.Controls.Add(this.txtTipoCliente);
            this.pnDatosReport.Controls.Add(this.txtTipoRActividad);
            this.pnDatosReport.Controls.Add(this.txtbPLanificacion);
            this.pnDatosReport.Controls.Add(this.txtdFecha);
            this.pnDatosReport.Controls.Add(this.label13);
            this.pnDatosReport.Controls.Add(this.label12);
            this.pnDatosReport.Controls.Add(this.label11);
            this.pnDatosReport.Controls.Add(this.label8);
            this.pnDatosReport.Controls.Add(this.label7);
            this.pnDatosReport.Controls.Add(this.label6);
            this.pnDatosReport.Controls.Add(this.label5);
            this.pnDatosReport.Controls.Add(this.label4);
            this.pnDatosReport.Location = new System.Drawing.Point(1, 665);
            this.pnDatosReport.Name = "pnDatosReport";
            this.pnDatosReport.Size = new System.Drawing.Size(1876, 233);
            this.pnDatosReport.TabIndex = 7;
            // 
            // txtProxObj
            // 
            this.txtProxObj.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtProxObj.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsReports1, "ListaRepActividad_Consulta.tProxObjetivo", true));
            this.txtProxObj.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProxObj.ForeColor = System.Drawing.Color.Black;
            this.txtProxObj.Location = new System.Drawing.Point(697, 29);
            this.txtProxObj.Multiline = true;
            this.txtProxObj.Name = "txtProxObj";
            this.txtProxObj.ReadOnly = true;
            this.txtProxObj.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtProxObj.Size = new System.Drawing.Size(333, 180);
            this.txtProxObj.TabIndex = 6;
            // 
            // txtObjetivo
            // 
            this.txtObjetivo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtObjetivo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsReports1, "ListaRepActividad_Consulta.tObjetivo", true));
            this.txtObjetivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObjetivo.ForeColor = System.Drawing.Color.Black;
            this.txtObjetivo.Location = new System.Drawing.Point(351, 29);
            this.txtObjetivo.Multiline = true;
            this.txtObjetivo.Name = "txtObjetivo";
            this.txtObjetivo.ReadOnly = true;
            this.txtObjetivo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObjetivo.Size = new System.Drawing.Size(333, 180);
            this.txtObjetivo.TabIndex = 5;
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtObservaciones.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsReports1, "ListaRepActividad_Consulta.tObservaciones", true));
            this.txtObservaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObservaciones.ForeColor = System.Drawing.Color.Black;
            this.txtObservaciones.Location = new System.Drawing.Point(7, 29);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.ReadOnly = true;
            this.txtObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObservaciones.Size = new System.Drawing.Size(333, 180);
            this.txtObservaciones.TabIndex = 4;
            // 
            // txtHorario
            // 
            this.txtHorario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtHorario.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsReports1, "ListaRepActividad_Consulta.tHorario", true));
            this.txtHorario.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHorario.ForeColor = System.Drawing.Color.Black;
            this.txtHorario.Location = new System.Drawing.Point(1175, 138);
            this.txtHorario.Name = "txtHorario";
            this.txtHorario.ReadOnly = true;
            this.txtHorario.Size = new System.Drawing.Size(100, 24);
            this.txtHorario.TabIndex = 4;
            // 
            // txtTipoCliente
            // 
            this.txtTipoCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtTipoCliente.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsReports1, "ListaRepActividad_Consulta.descTipoCliente", true));
            this.txtTipoCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTipoCliente.ForeColor = System.Drawing.Color.Black;
            this.txtTipoCliente.Location = new System.Drawing.Point(1175, 111);
            this.txtTipoCliente.Name = "txtTipoCliente";
            this.txtTipoCliente.ReadOnly = true;
            this.txtTipoCliente.Size = new System.Drawing.Size(100, 24);
            this.txtTipoCliente.TabIndex = 3;
            // 
            // txtTipoRActividad
            // 
            this.txtTipoRActividad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtTipoRActividad.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsReports1, "ListaRepActividad_Consulta.descTipoRActividad", true));
            this.txtTipoRActividad.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTipoRActividad.ForeColor = System.Drawing.Color.Black;
            this.txtTipoRActividad.Location = new System.Drawing.Point(1175, 84);
            this.txtTipoRActividad.Name = "txtTipoRActividad";
            this.txtTipoRActividad.ReadOnly = true;
            this.txtTipoRActividad.Size = new System.Drawing.Size(100, 24);
            this.txtTipoRActividad.TabIndex = 2;
            // 
            // txtbPLanificacion
            // 
            this.txtbPLanificacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtbPLanificacion.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsReports1, "ListaRepActividad_Consulta.Planif", true));
            this.txtbPLanificacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbPLanificacion.ForeColor = System.Drawing.Color.Black;
            this.txtbPLanificacion.Location = new System.Drawing.Point(1175, 57);
            this.txtbPLanificacion.Name = "txtbPLanificacion";
            this.txtbPLanificacion.ReadOnly = true;
            this.txtbPLanificacion.Size = new System.Drawing.Size(100, 24);
            this.txtbPLanificacion.TabIndex = 1;
            // 
            // txtdFecha
            // 
            this.txtdFecha.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtdFecha.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsReports1, "ListaRepActividad_Consulta.dFecha", true));
            this.txtdFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdFecha.ForeColor = System.Drawing.Color.Black;
            this.txtdFecha.Location = new System.Drawing.Point(1176, 30);
            this.txtdFecha.Name = "txtdFecha";
            this.txtdFecha.ReadOnly = true;
            this.txtdFecha.Size = new System.Drawing.Size(100, 24);
            this.txtdFecha.TabIndex = 0;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(697, 5);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(124, 21);
            this.label13.TabIndex = 18;
            this.label13.Text = "Prox. Objetivos:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(350, 5);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(124, 21);
            this.label12.TabIndex = 17;
            this.label12.Text = "Objetivos:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(7, 5);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(172, 21);
            this.label11.TabIndex = 16;
            this.label11.Text = "Observaciones:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(1075, 134);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 26);
            this.label8.TabIndex = 14;
            this.label8.Text = "Horario:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(1073, 108);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 26);
            this.label7.TabIndex = 13;
            this.label7.Text = "Tipo Cliente:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(1073, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 26);
            this.label6.TabIndex = 12;
            this.label6.Text = "Tipo Report:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(1073, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 26);
            this.label5.TabIndex = 11;
            this.label5.Text = "Planificación:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(1073, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 26);
            this.label4.TabIndex = 10;
            this.label4.Text = "Fecha:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCentroDesc
            // 
            this.txtCentroDesc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtCentroDesc.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsReports1, "ListaRepActividad_Consulta.sDescripcion", true));
            this.txtCentroDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCentroDesc.ForeColor = System.Drawing.Color.Black;
            this.txtCentroDesc.Location = new System.Drawing.Point(748, 18);
            this.txtCentroDesc.Name = "txtCentroDesc";
            this.txtCentroDesc.ReadOnly = true;
            this.txtCentroDesc.Size = new System.Drawing.Size(233, 24);
            this.txtCentroDesc.TabIndex = 2;
            // 
            // txtCentro
            // 
            this.txtCentro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtCentro.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsReports1, "ListaRepActividad_Consulta.sIdCentro", true));
            this.txtCentro.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCentro.ForeColor = System.Drawing.Color.Black;
            this.txtCentro.Location = new System.Drawing.Point(631, 18);
            this.txtCentro.Name = "txtCentro";
            this.txtCentro.ReadOnly = true;
            this.txtCentro.Size = new System.Drawing.Size(117, 24);
            this.txtCentro.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(567, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 20);
            this.label10.TabIndex = 15;
            this.label10.Text = "Centro:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btClientes
            // 
            this.btClientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btClientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btClientes.ForeColor = System.Drawing.Color.Black;
            this.btClientes.Location = new System.Drawing.Point(7, 330);
            this.btClientes.Name = "btClientes";
            this.btClientes.Size = new System.Drawing.Size(154, 27);
            this.btClientes.TabIndex = 2;
            this.btClientes.Text = "Clientes Visitados";
            this.btClientes.UseVisualStyleBackColor = true;
            this.btClientes.Click += new System.EventHandler(this.btClientes_Click);
            // 
            // btDatos
            // 
            this.btDatos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDatos.ForeColor = System.Drawing.Color.Black;
            this.btDatos.Location = new System.Drawing.Point(170, 330);
            this.btDatos.Name = "btDatos";
            this.btDatos.Size = new System.Drawing.Size(154, 27);
            this.btDatos.TabIndex = 4;
            this.btDatos.Text = "Datos Report";
            this.btDatos.UseVisualStyleBackColor = true;
            this.btDatos.Visible = false;
            this.btDatos.Click += new System.EventHandler(this.btDatos_Click);
            // 
            // pnClientes
            // 
            this.pnClientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnClientes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnClientes.Controls.Add(this.pnProxObj);
            this.pnClientes.Controls.Add(this.pnDatosCliente);
            this.pnClientes.Controls.Add(this.txtClienteObserv);
            this.pnClientes.Controls.Add(this.txtClienteObjetivo);
            this.pnClientes.Controls.Add(this.txtClienteProxObj);
            this.pnClientes.Controls.Add(this.label14);
            this.pnClientes.Controls.Add(this.label15);
            this.pnClientes.Controls.Add(this.label16);
            this.pnClientes.Controls.Add(this.panel1);
            this.pnClientes.Controls.Add(this.txtCentroDesc);
            this.pnClientes.Controls.Add(this.txtCentro);
            this.pnClientes.Controls.Add(this.label10);
            this.pnClientes.Location = new System.Drawing.Point(2, 326);
            this.pnClientes.Name = "pnClientes";
            this.pnClientes.Size = new System.Drawing.Size(1874, 557);
            this.pnClientes.TabIndex = 5;
            // 
            // pnProxObj
            // 
            this.pnProxObj.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnProxObj.Controls.Add(this.dgProxObj);
            this.pnProxObj.Controls.Add(this.lblTotProxObj);
            this.pnProxObj.Controls.Add(this.labelGradient5);
            this.pnProxObj.Location = new System.Drawing.Point(1, 376);
            this.pnProxObj.Name = "pnProxObj";
            this.pnProxObj.Size = new System.Drawing.Size(1480, 98);
            this.pnProxObj.TabIndex = 7;
            // 
            // dgProxObj
            // 
            this.dgProxObj.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgProxObj.CaptionVisible = false;
            this.dgProxObj.DataMember = "ListaRepActividadCli_ProxObj";
            this.dgProxObj.DataSource = this.dsReports1;
            this.dgProxObj.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgProxObj.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgProxObj.Location = new System.Drawing.Point(-2, 16);
            this.dgProxObj.Name = "dgProxObj";
            this.dgProxObj.Size = new System.Drawing.Size(1475, 76);
            this.dgProxObj.TabIndex = 2;
            this.dgProxObj.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle7});
            this.dgProxObj.CurrentCellChanged += new System.EventHandler(this.dgProxObj_CurrentCellChanged);
            // 
            // dataGridTableStyle7
            // 
            this.dataGridTableStyle7.DataGrid = this.dgProxObj;
            this.dataGridTableStyle7.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn35,
            this.dataGridTextBoxColumn36,
            this.dataGridTextBoxColumn37,
            this.dataGridTextBoxColumn38});
            this.dataGridTableStyle7.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle7.MappingName = "ListaRepActividadCli_ProxObj";
            // 
            // dataGridTextBoxColumn35
            // 
            this.dataGridTextBoxColumn35.Format = "";
            this.dataGridTextBoxColumn35.FormatInfo = null;
            this.dataGridTextBoxColumn35.HeaderText = "Código";
            this.dataGridTextBoxColumn35.MappingName = "sIdCliente";
            this.dataGridTextBoxColumn35.NullText = "";
            this.dataGridTextBoxColumn35.Width = 120;
            // 
            // dataGridTextBoxColumn36
            // 
            this.dataGridTextBoxColumn36.Format = "";
            this.dataGridTextBoxColumn36.FormatInfo = null;
            this.dataGridTextBoxColumn36.HeaderText = "Nombre";
            this.dataGridTextBoxColumn36.MappingName = "sNombre";
            this.dataGridTextBoxColumn36.NullText = "";
            this.dataGridTextBoxColumn36.Width = 450;
            // 
            // dataGridTextBoxColumn37
            // 
            this.dataGridTextBoxColumn37.Format = "";
            this.dataGridTextBoxColumn37.FormatInfo = null;
            this.dataGridTextBoxColumn37.HeaderText = "Próximos Objetivos";
            this.dataGridTextBoxColumn37.MappingName = "tProxObj";
            this.dataGridTextBoxColumn37.NullText = "";
            this.dataGridTextBoxColumn37.Width = 650;
            // 
            // dataGridTextBoxColumn38
            // 
            this.dataGridTextBoxColumn38.Format = "";
            this.dataGridTextBoxColumn38.FormatInfo = null;
            this.dataGridTextBoxColumn38.HeaderText = "Ultima Visita";
            this.dataGridTextBoxColumn38.MappingName = "dFecha";
            this.dataGridTextBoxColumn38.NullText = "";
            this.dataGridTextBoxColumn38.Width = 120;
            // 
            // lblTotProxObj
            // 
            this.lblTotProxObj.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.lblTotProxObj.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotProxObj.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotProxObj.Location = new System.Drawing.Point(1424, 0);
            this.lblTotProxObj.Name = "lblTotProxObj";
            this.lblTotProxObj.Size = new System.Drawing.Size(50, 16);
            this.lblTotProxObj.TabIndex = 1;
            this.lblTotProxObj.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelGradient5
            // 
            this.labelGradient5.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelGradient5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGradient5.ForeColor = System.Drawing.Color.White;
            this.labelGradient5.GradientColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.labelGradient5.GradientColorTwo = System.Drawing.Color.White;
            this.labelGradient5.Location = new System.Drawing.Point(0, 0);
            this.labelGradient5.Name = "labelGradient5";
            this.labelGradient5.Size = new System.Drawing.Size(1476, 16);
            this.labelGradient5.TabIndex = 0;
            this.labelGradient5.Text = "Próximos objetivos";
            this.labelGradient5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnDatosCliente
            // 
            this.pnDatosCliente.Controls.Add(this.pnPromociones);
            this.pnDatosCliente.Controls.Add(this.panel2);
            this.pnDatosCliente.Controls.Add(this.panel3);
            this.pnDatosCliente.Controls.Add(this.pnPedidosAsociados);
            this.pnDatosCliente.Location = new System.Drawing.Point(1, 261);
            this.pnDatosCliente.Name = "pnDatosCliente";
            this.pnDatosCliente.Size = new System.Drawing.Size(1480, 102);
            this.pnDatosCliente.TabIndex = 6;
            // 
            // pnPromociones
            // 
            this.pnPromociones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnPromociones.Controls.Add(this.dgProductos);
            this.pnPromociones.Controls.Add(this.lblTotProductos);
            this.pnPromociones.Controls.Add(this.labelGradient7);
            this.pnPromociones.Location = new System.Drawing.Point(877, 2);
            this.pnPromociones.Name = "pnPromociones";
            this.pnPromociones.Size = new System.Drawing.Size(538, 100);
            this.pnPromociones.TabIndex = 0;
            // 
            // dgProductos
            // 
            this.dgProductos.CaptionVisible = false;
            this.dgProductos.DataMember = "";
            this.dgProductos.DataSource = this.dsReports1.ListaPromocionProd;
            this.dgProductos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgProductos.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgProductos.Location = new System.Drawing.Point(0, 16);
            this.dgProductos.Name = "dgProductos";
            this.dgProductos.Size = new System.Drawing.Size(531, 81);
            this.dgProductos.TabIndex = 2;
            this.dgProductos.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle6});
            this.dgProductos.CurrentCellChanged += new System.EventHandler(this.dgProductos_CurrentCellChanged);
            // 
            // dataGridTableStyle6
            // 
            this.dataGridTableStyle6.DataGrid = this.dgProductos;
            this.dataGridTableStyle6.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dgtsDescripcion,
            this.dgtOrden,
            this.dgtiCantidad,
            this.dgtsIdProducto,
            this.dgtiIdCliente});
            this.dataGridTableStyle6.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle6.MappingName = "ListaPromocionProd";
            // 
            // dgtsDescripcion
            // 
            this.dgtsDescripcion.Format = "";
            this.dgtsDescripcion.FormatInfo = null;
            this.dgtsDescripcion.HeaderText = "Producto";
            this.dgtsDescripcion.MappingName = "sDescripcion";
            this.dgtsDescripcion.Width = 200;
            // 
            // dgtOrden
            // 
            this.dgtOrden.Format = "";
            this.dgtOrden.FormatInfo = null;
            this.dgtOrden.HeaderText = "Orden";
            this.dgtOrden.MappingName = "Orden";
            this.dgtOrden.Width = 110;
            // 
            // dgtiCantidad
            // 
            this.dgtiCantidad.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.dgtiCantidad.Format = "";
            this.dgtiCantidad.FormatInfo = null;
            this.dgtiCantidad.HeaderText = "Cantidad  ";
            this.dgtiCantidad.MappingName = "iCantidad";
            this.dgtiCantidad.Width = 110;
            // 
            // dgtsIdProducto
            // 
            this.dgtsIdProducto.Format = "";
            this.dgtsIdProducto.FormatInfo = null;
            this.dgtsIdProducto.MappingName = "sIdProducto";
            this.dgtsIdProducto.Width = 0;
            // 
            // dgtiIdCliente
            // 
            this.dgtiIdCliente.Format = "";
            this.dgtiIdCliente.FormatInfo = null;
            this.dgtiIdCliente.MappingName = "iIdCliente";
            this.dgtiIdCliente.Width = 0;
            // 
            // lblTotProductos
            // 
            this.lblTotProductos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.lblTotProductos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotProductos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotProductos.Location = new System.Drawing.Point(481, 0);
            this.lblTotProductos.Name = "lblTotProductos";
            this.lblTotProductos.Size = new System.Drawing.Size(50, 16);
            this.lblTotProductos.TabIndex = 1;
            this.lblTotProductos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelGradient7
            // 
            this.labelGradient7.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelGradient7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGradient7.ForeColor = System.Drawing.Color.White;
            this.labelGradient7.GradientColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.labelGradient7.GradientColorTwo = System.Drawing.Color.White;
            this.labelGradient7.Location = new System.Drawing.Point(0, 0);
            this.labelGradient7.Name = "labelGradient7";
            this.labelGradient7.Size = new System.Drawing.Size(534, 16);
            this.labelGradient7.TabIndex = 0;
            this.labelGradient7.Text = "Productos promocionados";
            this.labelGradient7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.dgGadgets);
            this.panel2.Controls.Add(this.lblTotGadgets);
            this.panel2.Controls.Add(this.labelGradient2);
            this.panel2.Location = new System.Drawing.Point(3, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(335, 100);
            this.panel2.TabIndex = 0;
            // 
            // dgGadgets
            // 
            this.dgGadgets.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgGadgets.CaptionVisible = false;
            this.dgGadgets.DataMember = "ListaRepActividGadget";
            this.dgGadgets.DataSource = this.dsReports1;
            this.dgGadgets.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgGadgets.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgGadgets.Location = new System.Drawing.Point(-2, 16);
            this.dgGadgets.Name = "dgGadgets";
            this.dgGadgets.ReadOnly = true;
            this.dgGadgets.Size = new System.Drawing.Size(335, 82);
            this.dgGadgets.TabIndex = 22;
            this.dgGadgets.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle3});
            this.dgGadgets.CurrentCellChanged += new System.EventHandler(this.dgGadgets_CurrentCellChanged);
            // 
            // dataGridTableStyle3
            // 
            this.dataGridTableStyle3.DataGrid = this.dgGadgets;
            this.dataGridTableStyle3.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn21,
            this.dataGridTextBoxColumn22});
            this.dataGridTableStyle3.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle3.MappingName = "ListaRepActividGadget";
            // 
            // dataGridTextBoxColumn21
            // 
            this.dataGridTextBoxColumn21.Format = "";
            this.dataGridTextBoxColumn21.FormatInfo = null;
            this.dataGridTextBoxColumn21.HeaderText = "Código";
            this.dataGridTextBoxColumn21.MappingName = "sDescripcion";
            this.dataGridTextBoxColumn21.NullText = "";
            this.dataGridTextBoxColumn21.Width = 195;
            // 
            // dataGridTextBoxColumn22
            // 
            this.dataGridTextBoxColumn22.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.dataGridTextBoxColumn22.Format = "";
            this.dataGridTextBoxColumn22.FormatInfo = null;
            this.dataGridTextBoxColumn22.HeaderText = "Cantidad  ";
            this.dataGridTextBoxColumn22.MappingName = "iCantidad";
            this.dataGridTextBoxColumn22.NullText = "";
            this.dataGridTextBoxColumn22.Width = 75;
            // 
            // lblTotGadgets
            // 
            this.lblTotGadgets.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.lblTotGadgets.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotGadgets.Location = new System.Drawing.Point(288, 0);
            this.lblTotGadgets.Name = "lblTotGadgets";
            this.lblTotGadgets.Size = new System.Drawing.Size(41, 16);
            this.lblTotGadgets.TabIndex = 21;
            this.lblTotGadgets.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelGradient2
            // 
            this.labelGradient2.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelGradient2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGradient2.ForeColor = System.Drawing.Color.White;
            this.labelGradient2.GradientColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.labelGradient2.GradientColorTwo = System.Drawing.Color.White;
            this.labelGradient2.Location = new System.Drawing.Point(0, 0);
            this.labelGradient2.Name = "labelGradient2";
            this.labelGradient2.Size = new System.Drawing.Size(331, 16);
            this.labelGradient2.TabIndex = 0;
            this.labelGradient2.Text = "Gadgets";
            this.labelGradient2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.dgAtenciones);
            this.panel3.Controls.Add(this.lblTotAtenciones);
            this.panel3.Controls.Add(this.labelGradient3);
            this.panel3.Location = new System.Drawing.Point(347, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(524, 100);
            this.panel3.TabIndex = 1;
            // 
            // dgAtenciones
            // 
            this.dgAtenciones.CaptionVisible = false;
            this.dgAtenciones.DataMember = "ListaRepActividAtenciones";
            this.dgAtenciones.DataSource = this.dsReports1;
            this.dgAtenciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgAtenciones.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgAtenciones.Location = new System.Drawing.Point(-2, 16);
            this.dgAtenciones.Name = "dgAtenciones";
            this.dgAtenciones.ReadOnly = true;
            this.dgAtenciones.Size = new System.Drawing.Size(519, 82);
            this.dgAtenciones.TabIndex = 23;
            this.dgAtenciones.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle4});
            this.dgAtenciones.CurrentCellChanged += new System.EventHandler(this.dgAtenciones_CurrentCellChanged);
            // 
            // dataGridTableStyle4
            // 
            this.dataGridTableStyle4.DataGrid = this.dgAtenciones;
            this.dataGridTableStyle4.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn23,
            this.dataGridTextBoxColumn41,
            this.dataGridTextBoxColumn42,
            this.dataGridTextBoxColumn24,
            this.dataGridTextBoxColumn25});
            this.dataGridTableStyle4.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle4.MappingName = "ListaRepActividAtenciones";
            // 
            // dataGridTextBoxColumn23
            // 
            this.dataGridTextBoxColumn23.Format = "";
            this.dataGridTextBoxColumn23.FormatInfo = null;
            this.dataGridTextBoxColumn23.HeaderText = "Código";
            this.dataGridTextBoxColumn23.MappingName = "sIdAtencion";
            this.dataGridTextBoxColumn23.NullText = "";
            this.dataGridTextBoxColumn23.Width = 130;
            // 
            // dataGridTextBoxColumn41
            // 
            this.dataGridTextBoxColumn41.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.dataGridTextBoxColumn41.Format = "";
            this.dataGridTextBoxColumn41.FormatInfo = null;
            this.dataGridTextBoxColumn41.HeaderText = "Núm.";
            this.dataGridTextBoxColumn41.MappingName = "iNumAtencion";
            this.dataGridTextBoxColumn41.NullText = "";
            this.dataGridTextBoxColumn41.Width = 50;
            // 
            // dataGridTextBoxColumn42
            // 
            this.dataGridTextBoxColumn42.Format = "";
            this.dataGridTextBoxColumn42.FormatInfo = null;
            this.dataGridTextBoxColumn42.HeaderText = "Tipo";
            this.dataGridTextBoxColumn42.MappingName = "sTipoAtencion";
            this.dataGridTextBoxColumn42.NullText = "";
            this.dataGridTextBoxColumn42.Width = 70;
            // 
            // dataGridTextBoxColumn24
            // 
            this.dataGridTextBoxColumn24.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.dataGridTextBoxColumn24.Format = "";
            this.dataGridTextBoxColumn24.FormatInfo = null;
            this.dataGridTextBoxColumn24.HeaderText = "Imp. Cliente  ";
            this.dataGridTextBoxColumn24.MappingName = "fImporte";
            this.dataGridTextBoxColumn24.NullText = "";
            this.dataGridTextBoxColumn24.Width = 110;
            // 
            // dataGridTextBoxColumn25
            // 
            this.dataGridTextBoxColumn25.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.dataGridTextBoxColumn25.Format = "";
            this.dataGridTextBoxColumn25.FormatInfo = null;
            this.dataGridTextBoxColumn25.HeaderText = "Imp.Prev.";
            this.dataGridTextBoxColumn25.MappingName = "fImportePrev";
            this.dataGridTextBoxColumn25.NullText = "";
            this.dataGridTextBoxColumn25.Width = 75;
            // 
            // lblTotAtenciones
            // 
            this.lblTotAtenciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.lblTotAtenciones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotAtenciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotAtenciones.Location = new System.Drawing.Point(467, 0);
            this.lblTotAtenciones.Name = "lblTotAtenciones";
            this.lblTotAtenciones.Size = new System.Drawing.Size(50, 16);
            this.lblTotAtenciones.TabIndex = 22;
            this.lblTotAtenciones.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelGradient3
            // 
            this.labelGradient3.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelGradient3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGradient3.ForeColor = System.Drawing.Color.White;
            this.labelGradient3.GradientColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.labelGradient3.GradientColorTwo = System.Drawing.Color.White;
            this.labelGradient3.Location = new System.Drawing.Point(0, 0);
            this.labelGradient3.Name = "labelGradient3";
            this.labelGradient3.Size = new System.Drawing.Size(520, 16);
            this.labelGradient3.TabIndex = 0;
            this.labelGradient3.Text = "Atenciones reportadas a un cliente";
            this.labelGradient3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnPedidosAsociados
            // 
            this.pnPedidosAsociados.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnPedidosAsociados.Controls.Add(this.lblToolTipBtPed);
            this.pnPedidosAsociados.Controls.Add(this.dgPedidos);
            this.pnPedidosAsociados.Controls.Add(this.lblTotPedidos);
            this.pnPedidosAsociados.Controls.Add(this.labelGradient4);
            this.pnPedidosAsociados.Location = new System.Drawing.Point(881, 2);
            this.pnPedidosAsociados.Name = "pnPedidosAsociados";
            this.pnPedidosAsociados.Size = new System.Drawing.Size(471, 100);
            this.pnPedidosAsociados.TabIndex = 2;
            // 
            // lblToolTipBtPed
            // 
            this.lblToolTipBtPed.BackColor = System.Drawing.SystemColors.Info;
            this.lblToolTipBtPed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblToolTipBtPed.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToolTipBtPed.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblToolTipBtPed.Location = new System.Drawing.Point(0, 0);
            this.lblToolTipBtPed.Name = "lblToolTipBtPed";
            this.lblToolTipBtPed.Size = new System.Drawing.Size(10, 11);
            this.lblToolTipBtPed.TabIndex = 78;
            this.lblToolTipBtPed.Text = "O";
            this.lblToolTipBtPed.Visible = false;
            // 
            // dgPedidos
            // 
            this.dgPedidos.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgPedidos.CaptionVisible = false;
            this.dgPedidos.DataMember = "ListaRepActividPedidos";
            this.dgPedidos.DataSource = this.dsReports1;
            this.dgPedidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgPedidos.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgPedidos.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgPedidos.Location = new System.Drawing.Point(-2, 16);
            this.dgPedidos.Name = "dgPedidos";
            this.dgPedidos.ReadOnly = true;
            this.dgPedidos.Size = new System.Drawing.Size(466, 82);
            this.dgPedidos.TabIndex = 24;
            this.dgPedidos.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle5});
            this.dgPedidos.CurrentCellChanged += new System.EventHandler(this.dgPedidos_CurrentCellChanged);
            this.dgPedidos.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dgPedidos_MouseMove);
            // 
            // dataGridTableStyle5
            // 
            this.dataGridTableStyle5.DataGrid = this.dgPedidos;
            this.dataGridTableStyle5.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn27,
            this.dataGridTextBoxColumn28,
            this.dataGridTextBoxColumn29,
            this.dataGridTextBoxColumn40});
            this.dataGridTableStyle5.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle5.MappingName = "ListaRepActividPedidos";
            // 
            // dataGridTextBoxColumn27
            // 
            this.dataGridTextBoxColumn27.Format = "";
            this.dataGridTextBoxColumn27.FormatInfo = null;
            this.dataGridTextBoxColumn27.HeaderText = "Pedido";
            this.dataGridTextBoxColumn27.MappingName = "sIdPedido";
            this.dataGridTextBoxColumn27.NullText = "";
            this.dataGridTextBoxColumn27.Width = 120;
            // 
            // dataGridTextBoxColumn28
            // 
            this.dataGridTextBoxColumn28.Format = "";
            this.dataGridTextBoxColumn28.FormatInfo = null;
            this.dataGridTextBoxColumn28.HeaderText = "F.Pedido";
            this.dataGridTextBoxColumn28.MappingName = "dFechaPedido";
            this.dataGridTextBoxColumn28.NullText = "";
            this.dataGridTextBoxColumn28.Width = 120;
            // 
            // dataGridTextBoxColumn29
            // 
            this.dataGridTextBoxColumn29.Format = "";
            this.dataGridTextBoxColumn29.FormatInfo = null;
            this.dataGridTextBoxColumn29.HeaderText = "Tipo";
            this.dataGridTextBoxColumn29.MappingName = "sIdTipoPedido";
            this.dataGridTextBoxColumn29.NullText = "";
            this.dataGridTextBoxColumn29.Width = 120;
            // 
            // dataGridTextBoxColumn40
            // 
            this.dataGridTextBoxColumn40.Format = "";
            this.dataGridTextBoxColumn40.FormatInfo = null;
            this.dataGridTextBoxColumn40.MappingName = "Boton";
            this.dataGridTextBoxColumn40.NullText = "";
            this.dataGridTextBoxColumn40.Width = 40;
            // 
            // lblTotPedidos
            // 
            this.lblTotPedidos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.lblTotPedidos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotPedidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotPedidos.Location = new System.Drawing.Point(414, 0);
            this.lblTotPedidos.Name = "lblTotPedidos";
            this.lblTotPedidos.Size = new System.Drawing.Size(50, 16);
            this.lblTotPedidos.TabIndex = 23;
            this.lblTotPedidos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelGradient4
            // 
            this.labelGradient4.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelGradient4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGradient4.ForeColor = System.Drawing.Color.White;
            this.labelGradient4.GradientColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.labelGradient4.GradientColorTwo = System.Drawing.Color.White;
            this.labelGradient4.Location = new System.Drawing.Point(0, 0);
            this.labelGradient4.Name = "labelGradient4";
            this.labelGradient4.Size = new System.Drawing.Size(467, 16);
            this.labelGradient4.TabIndex = 0;
            this.labelGradient4.Text = "Pedidos Asociados a un Cliente";
            this.labelGradient4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtClienteObserv
            // 
            this.txtClienteObserv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtClienteObserv.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsReports1, "ListaRepActividadCli.tObservaciones", true));
            this.txtClienteObserv.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClienteObserv.ForeColor = System.Drawing.Color.Black;
            this.txtClienteObserv.Location = new System.Drawing.Point(1108, 13);
            this.txtClienteObserv.Multiline = true;
            this.txtClienteObserv.Name = "txtClienteObserv";
            this.txtClienteObserv.ReadOnly = true;
            this.txtClienteObserv.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtClienteObserv.Size = new System.Drawing.Size(350, 35);
            this.txtClienteObserv.TabIndex = 3;
            // 
            // txtClienteObjetivo
            // 
            this.txtClienteObjetivo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtClienteObjetivo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsReports1, "ListaRepActividadCli.tObjetivos", true));
            this.txtClienteObjetivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClienteObjetivo.ForeColor = System.Drawing.Color.Black;
            this.txtClienteObjetivo.Location = new System.Drawing.Point(1108, 48);
            this.txtClienteObjetivo.Multiline = true;
            this.txtClienteObjetivo.Name = "txtClienteObjetivo";
            this.txtClienteObjetivo.ReadOnly = true;
            this.txtClienteObjetivo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtClienteObjetivo.Size = new System.Drawing.Size(350, 34);
            this.txtClienteObjetivo.TabIndex = 4;
            // 
            // txtClienteProxObj
            // 
            this.txtClienteProxObj.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtClienteProxObj.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsReports1, "ListaRepActividadCli.tProxObj", true));
            this.txtClienteProxObj.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClienteProxObj.ForeColor = System.Drawing.Color.Black;
            this.txtClienteProxObj.Location = new System.Drawing.Point(1108, 82);
            this.txtClienteProxObj.Multiline = true;
            this.txtClienteProxObj.Name = "txtClienteProxObj";
            this.txtClienteProxObj.ReadOnly = true;
            this.txtClienteProxObj.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtClienteProxObj.Size = new System.Drawing.Size(350, 35);
            this.txtClienteProxObj.TabIndex = 5;
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(989, 21);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(114, 21);
            this.label14.TabIndex = 59;
            this.label14.Text = "Observaciones:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(1034, 51);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(70, 18);
            this.label15.TabIndex = 57;
            this.label15.Text = "Objetivo:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(1021, 82);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(84, 18);
            this.label16.TabIndex = 58;
            this.label16.Text = "Próx. Obj.:";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.lblToolTipBoton);
            this.panel1.Controls.Add(this.dgClientes);
            this.panel1.Controls.Add(this.lblTotClientes);
            this.panel1.Controls.Add(this.labelGradient1);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(553, 128);
            this.panel1.TabIndex = 0;
            // 
            // lblToolTipBoton
            // 
            this.lblToolTipBoton.BackColor = System.Drawing.SystemColors.Info;
            this.lblToolTipBoton.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblToolTipBoton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToolTipBoton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblToolTipBoton.Location = new System.Drawing.Point(0, 0);
            this.lblToolTipBoton.Name = "lblToolTipBoton";
            this.lblToolTipBoton.Size = new System.Drawing.Size(10, 11);
            this.lblToolTipBoton.TabIndex = 77;
            this.lblToolTipBoton.Text = "O";
            this.lblToolTipBoton.Visible = false;
            // 
            // dgClientes
            // 
            this.dgClientes.CaptionVisible = false;
            this.dgClientes.DataMember = "ListaRepActividadCli";
            this.dgClientes.DataSource = this.dsReports1;
            this.dgClientes.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgClientes.Location = new System.Drawing.Point(-2, 16);
            this.dgClientes.Name = "dgClientes";
            this.dgClientes.ReadOnly = true;
            this.dgClientes.Size = new System.Drawing.Size(537, 110);
            this.dgClientes.TabIndex = 21;
            this.dgClientes.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle2});
            this.dgClientes.CurrentCellChanged += new System.EventHandler(this.dgClientes_CurrentCellChanged);
            this.dgClientes.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dgClientes_MouseMove);
            // 
            // dataGridTableStyle2
            // 
            this.dataGridTableStyle2.DataGrid = this.dgClientes;
            this.dataGridTableStyle2.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn17,
            this.dataGridTextBoxColumn18,
            this.dataGridTextBoxColumn19,
            this.dataGridTextBoxColumn20,
            this.dataGridTextBoxColumn39});
            this.dataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle2.MappingName = "ListaRepActividadCli";
            // 
            // dataGridTextBoxColumn17
            // 
            this.dataGridTextBoxColumn17.Format = "";
            this.dataGridTextBoxColumn17.FormatInfo = null;
            this.dataGridTextBoxColumn17.MappingName = "iIdCliente";
            this.dataGridTextBoxColumn17.NullText = "";
            this.dataGridTextBoxColumn17.Width = 0;
            // 
            // dataGridTextBoxColumn18
            // 
            this.dataGridTextBoxColumn18.Format = "";
            this.dataGridTextBoxColumn18.FormatInfo = null;
            this.dataGridTextBoxColumn18.HeaderText = "Código";
            this.dataGridTextBoxColumn18.MappingName = "sIdCliente";
            this.dataGridTextBoxColumn18.NullText = "";
            this.dataGridTextBoxColumn18.Width = 110;
            // 
            // dataGridTextBoxColumn19
            // 
            this.dataGridTextBoxColumn19.Format = "";
            this.dataGridTextBoxColumn19.FormatInfo = null;
            this.dataGridTextBoxColumn19.HeaderText = "Nombre";
            this.dataGridTextBoxColumn19.MappingName = "sNombre";
            this.dataGridTextBoxColumn19.NullText = "";
            this.dataGridTextBoxColumn19.Width = 340;
            // 
            // dataGridTextBoxColumn20
            // 
            this.dataGridTextBoxColumn20.Format = "";
            this.dataGridTextBoxColumn20.FormatInfo = null;
            this.dataGridTextBoxColumn20.HeaderText = "Sust.";
            this.dataGridTextBoxColumn20.MappingName = "tSustituto";
            this.dataGridTextBoxColumn20.NullText = "";
            this.dataGridTextBoxColumn20.Width = 30;
            // 
            // dataGridTextBoxColumn39
            // 
            this.dataGridTextBoxColumn39.Format = "";
            this.dataGridTextBoxColumn39.FormatInfo = null;
            this.dataGridTextBoxColumn39.MappingName = "Boton";
            this.dataGridTextBoxColumn39.NullText = "";
            this.dataGridTextBoxColumn39.Width = 40;
            // 
            // lblTotClientes
            // 
            this.lblTotClientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.lblTotClientes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotClientes.Location = new System.Drawing.Point(499, 0);
            this.lblTotClientes.Name = "lblTotClientes";
            this.lblTotClientes.Size = new System.Drawing.Size(50, 16);
            this.lblTotClientes.TabIndex = 20;
            this.lblTotClientes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelGradient1
            // 
            this.labelGradient1.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelGradient1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGradient1.ForeColor = System.Drawing.Color.White;
            this.labelGradient1.GradientColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.labelGradient1.GradientColorTwo = System.Drawing.Color.White;
            this.labelGradient1.Location = new System.Drawing.Point(0, 0);
            this.labelGradient1.Name = "labelGradient1";
            this.labelGradient1.Size = new System.Drawing.Size(549, 16);
            this.labelGradient1.TabIndex = 0;
            this.labelGradient1.Text = "Clientes visitados";
            this.labelGradient1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sqldaListaRepActividad_Cli
            // 
            this.sqldaListaRepActividad_Cli.SelectCommand = this.sqlSelectCommand7;
            this.sqldaListaRepActividad_Cli.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaRepActividadCli", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iIdReport", "iIdReport"),
                        new System.Data.Common.DataColumnMapping("iIdCliente", "iIdCliente"),
                        new System.Data.Common.DataColumnMapping("sIdCliente", "sIdCliente"),
                        new System.Data.Common.DataColumnMapping("sNombre", "sNombre"),
                        new System.Data.Common.DataColumnMapping("tObservaciones", "tObservaciones"),
                        new System.Data.Common.DataColumnMapping("tObjetivos", "tObjetivos"),
                        new System.Data.Common.DataColumnMapping("tProxObj", "tProxObj"),
                        new System.Data.Common.DataColumnMapping("bSustituto", "bSustituto"),
                        new System.Data.Common.DataColumnMapping("tSustituto", "tSustituto"),
                        new System.Data.Common.DataColumnMapping("Boton", "Boton")})});
            // 
            // sqlSelectCommand7
            // 
            this.sqlSelectCommand7.CommandText = "[ListaRepActividadCli]";
            this.sqlSelectCommand7.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand7.Connection = this.sqlConn;
            this.sqlSelectCommand7.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdReport", System.Data.SqlDbType.Int, 4)});
            // 
            // sqldaListaRepActividad_Gadget
            // 
            this.sqldaListaRepActividad_Gadget.SelectCommand = this.sqlSelectCommand8;
            this.sqldaListaRepActividad_Gadget.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaRepActividGadget", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iIdReport", "iIdReport"),
                        new System.Data.Common.DataColumnMapping("iIdCliente", "iIdCliente"),
                        new System.Data.Common.DataColumnMapping("sIdCliente", "sIdCliente"),
                        new System.Data.Common.DataColumnMapping("iIdGadget", "iIdGadget"),
                        new System.Data.Common.DataColumnMapping("iCantidad", "iCantidad"),
                        new System.Data.Common.DataColumnMapping("sDescripcion", "sDescripcion")})});
            // 
            // sqlSelectCommand8
            // 
            this.sqlSelectCommand8.CommandText = "[ListaRepActividGadget]";
            this.sqlSelectCommand8.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand8.Connection = this.sqlConn;
            this.sqlSelectCommand8.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdReport", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4)});
            // 
            // sqldaListaRepActividadAtenciones
            // 
            this.sqldaListaRepActividadAtenciones.SelectCommand = this.sqlSelectCommand9;
            this.sqldaListaRepActividadAtenciones.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaRepActividAtenciones", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iIdReport", "iIdReport"),
                        new System.Data.Common.DataColumnMapping("iIdCliente", "iIdCliente"),
                        new System.Data.Common.DataColumnMapping("sIdCliente", "sIdCliente"),
                        new System.Data.Common.DataColumnMapping("iIdAtencion", "iIdAtencion"),
                        new System.Data.Common.DataColumnMapping("iNumAtencion", "iNumAtencion"),
                        new System.Data.Common.DataColumnMapping("fImporte", "fImporte"),
                        new System.Data.Common.DataColumnMapping("sIdAtencion", "sIdAtencion"),
                        new System.Data.Common.DataColumnMapping("fImportePrev", "fImportePrev"),
                        new System.Data.Common.DataColumnMapping("fImporteReal", "fImporteReal"),
                        new System.Data.Common.DataColumnMapping("sIdTipoAtencion", "sIdTipoAtencion"),
                        new System.Data.Common.DataColumnMapping("sTipoAtencion", "sTipoAtencion")})});
            // 
            // sqlSelectCommand9
            // 
            this.sqlSelectCommand9.CommandText = "[ListaRepActividAtenciones]";
            this.sqlSelectCommand9.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand9.Connection = this.sqlConn;
            this.sqlSelectCommand9.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdReport", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4)});
            // 
            // sqldaRepActividad_Pedidos
            // 
            this.sqldaRepActividad_Pedidos.SelectCommand = this.sqlSelectCommand10;
            this.sqldaRepActividad_Pedidos.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaRepActividPedidos", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iIdReport", "iIdReport"),
                        new System.Data.Common.DataColumnMapping("sIdPedido", "sIdPedido"),
                        new System.Data.Common.DataColumnMapping("sIdTipoPedido", "sIdTipoPedido"),
                        new System.Data.Common.DataColumnMapping("dFechaPedido", "dFechaPedido"),
                        new System.Data.Common.DataColumnMapping("Boton", "Boton")})});
            // 
            // sqlSelectCommand10
            // 
            this.sqlSelectCommand10.CommandText = "[ListaRepActividPedidos]";
            this.sqlSelectCommand10.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand10.Connection = this.sqlConn;
            this.sqlSelectCommand10.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdReport", System.Data.SqlDbType.Int, 4)});
            // 
            // sqldaListaRepActividadCli_ProxObj
            // 
            this.sqldaListaRepActividadCli_ProxObj.SelectCommand = this.sqlSelectCommand11;
            this.sqldaListaRepActividadCli_ProxObj.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaRepActividadCli_ProxObj", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iIdReport", "iIdReport"),
                        new System.Data.Common.DataColumnMapping("iIdCliente", "iIdCliente"),
                        new System.Data.Common.DataColumnMapping("sIdCliente", "sIdCliente"),
                        new System.Data.Common.DataColumnMapping("sNombre", "sNombre"),
                        new System.Data.Common.DataColumnMapping("tProxObj", "tProxObj"),
                        new System.Data.Common.DataColumnMapping("dFecha", "dFecha")})});
            // 
            // sqlSelectCommand11
            // 
            this.sqlSelectCommand11.CommandText = "[ListaRepActividadCli_ProxObj]";
            this.sqlSelectCommand11.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand11.Connection = this.sqlConn;
            this.sqlSelectCommand11.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdCentro", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4)});
            // 
            // sqldaListaRepActividadProd
            // 
            this.sqldaListaRepActividadProd.SelectCommand = this.sqlSelectCommand12;
            this.sqldaListaRepActividadProd.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaRepActividadProd", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iIdReport", "iIdReport"),
                        new System.Data.Common.DataColumnMapping("sIdProducto", "sIdProducto"),
                        new System.Data.Common.DataColumnMapping("iIdPromocion", "iIdPromocion"),
                        new System.Data.Common.DataColumnMapping("bPromocionado", "bPromocionado"),
                        new System.Data.Common.DataColumnMapping("tPromociona", "tPromociona"),
                        new System.Data.Common.DataColumnMapping("iOrden", "iOrden"),
                        new System.Data.Common.DataColumnMapping("iMuestras", "iMuestras"),
                        new System.Data.Common.DataColumnMapping("sDescripcion", "sDescripcion")})});
            // 
            // sqlSelectCommand12
            // 
            this.sqlSelectCommand12.CommandText = "[ListaRepActividadProd]";
            this.sqlSelectCommand12.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand12.Connection = this.sqlConn;
            this.sqlSelectCommand12.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdReport", System.Data.SqlDbType.Int, 4)});
            // 
            // sqlCmdGetPuedeBorrarReport
            // 
            this.sqlCmdGetPuedeBorrarReport.CommandText = "[GetPuedeBorrarReport]";
            this.sqlCmdGetPuedeBorrarReport.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdGetPuedeBorrarReport.Connection = this.sqlConn;
            this.sqlCmdGetPuedeBorrarReport.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdReport", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@Total", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Output, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null)});
            // 
            // sqldaListaPromocionProd
            // 
            this.sqldaListaPromocionProd.SelectCommand = this.sqlCommand1;
            this.sqldaListaPromocionProd.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaPromocionProd", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iOrden", "iOrden"),
                        new System.Data.Common.DataColumnMapping("sIdProducto", "sIdProducto"),
                        new System.Data.Common.DataColumnMapping("iIdPromocion", "iIdPromocion"),
                        new System.Data.Common.DataColumnMapping("sDescripcion", "sDescripcion")})});
            // 
            // sqlCommand1
            // 
            this.sqlCommand1.CommandText = "[ListaPromocionProd]";
            this.sqlCommand1.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCommand1.Connection = this.sqlConn;
            this.sqlCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdReport", System.Data.SqlDbType.Int, 4)});
            // 
            // frmConsultaReport
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.ClientSize = new System.Drawing.Size(1878, 895);
            this.Controls.Add(this.pnClientes);
            this.Controls.Add(this.btDatos);
            this.Controls.Add(this.pnDatosReport);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.pnBuscar);
            this.Controls.Add(this.ucBotoneraSecundaria1);
            this.Controls.Add(this.btClientes);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmConsultaReport";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta de reports de actividad";
            this.Closed += new System.EventHandler(this.frmConsultaReport_Closed);
            this.Load += new System.EventHandler(this.frmConsultaReport_Load);
            this.pnBuscar.ResumeLayout(false);
            this.pnBuscar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsReports1)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgGeneral)).EndInit();
            this.pnDatosReport.ResumeLayout(false);
            this.pnDatosReport.PerformLayout();
            this.pnClientes.ResumeLayout(false);
            this.pnClientes.PerformLayout();
            this.pnProxObj.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgProxObj)).EndInit();
            this.pnDatosCliente.ResumeLayout(false);
            this.pnPromociones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgProductos)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgGadgets)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgAtenciones)).EndInit();
            this.pnPedidosAsociados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgPedidos)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgClientes)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region frmConsultaReport_Load
		private void frmConsultaReport_Load(object sender, System.EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;
			try
			{
				GESTCRM.Utiles.Formato_Formulario(this);
				if(this.Parent == null) this.WindowState = FormWindowState.Normal;


				this.dtpFechaFin.Value = DateTime.Today;
				this.dtpFechaIni.Value = DateTime.Parse("01/01/"+DateTime.Today.Year.ToString());
				this.Var_iIdCentro=-1;
				this.Var_iIdCliente=-1;

                //---- GSG (13/03/2019)
                //this.pnClientes.Location = new Point(1,378);
                this.pnClientes.Location = new Point(1, 300);
                this.pnClientes.Height = 285;
				this.pnClientes.Visible=true;
				this.pnDatosCliente.Location = new Point(0,200);
				this.pnDatosCliente.Visible=false;
				this.pnProxObj.Location = new Point(0,200);
				this.pnProxObj.Visible=false;

				
				this.pnDatosReport.Location = new Point(1,378);
				this.pnDatosReport.Visible=false;

				this.btClientes.Font = Utiles.fuenteBold;
				this.btDatos.Font = Utiles.fuenteNoBold;

				Inicializar_Combos();

				Inicializar_DataGrids();

				Inicializar_Botonera();

				if(GESTCRM.Clases.Configuracion.iGVisitas>0)
				{
					this.menuNuevo.Enabled=false;
					this.menuEliminar.Enabled=false;
				}

				Activar_Paneles(false);

			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}

			Cursor.Current = Cursors.Default;
		}
		#endregion

		#region Inicializar_Botonera
		private void Inicializar_Botonera()
		{
			try
			{
				this.ucBotoneraSecundaria1.btSalir.Click += new EventHandler(btSalir_Click);
				this.ucBotoneraSecundaria1.btNuevo.Click += new EventHandler(btNuevo_Click);
				this.ucBotoneraSecundaria1.btEditar.Click += new EventHandler(btEditar_Click);
				this.ucBotoneraSecundaria1.btEliminar.Click += new EventHandler(btEliminar_Click);

				if(GESTCRM.Clases.Configuracion.iGVisitas==0)
				{
					this.ucBotoneraSecundaria1.Activar_botonera(true,true,true,true,false,false);
				}
				else
				{
					this.ucBotoneraSecundaria1.Activar_botonera(true,false,true,false,false,false);
				}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region Inicializar_Combos
		private void Inicializar_Combos()
		{
			try
			{
				//Inicializar ComboBox Delegados
				this.sqldaListaDelegados.Fill(this.dsReports1);
				DataRow fila1 = this.dsReports1.ListaDelegados.NewRow();
				fila1["iIdDelegado"]=-1;
				fila1["sNombre"]="Todos";
				this.dsReports1.ListaDelegados.Rows.InsertAt(fila1,1);
				this.cbDelegado.SelectedValue=GESTCRM.Clases.Configuracion.iIdDelegado;

				//Inicializar ComboBox Planificación
				this.sqldaListaPlanificacion.Fill(this.dsReports1);
				this.cbPlanificacion.SelectedValue="-1";

				//Inicializar ComboBox Tipo Report
				this.sqldaTipoRActividad.Fill(this.dsReports1);
				DataRow fila3 = this.dsReports1.ListaTipoRActividad.NewRow();
				fila3["sValor"]="-1";
				fila3["sLiteral"]="Todos";
				this.dsReports1.ListaTipoRActividad.Rows.InsertAt(fila3,1);
				this.cbTipoReport.SelectedValue="-1";

				//Inicializar ComboBox Tipo Cliente
				this.sqldaTipoCliente.Fill(this.dsReports1);
				DataRow fila2 = this.dsReports1.ListaTipoCliente.NewRow();
				fila2["sValor"]="-1";
				fila2["sLiteral"]="Todos";
				this.dsReports1.ListaTipoCliente.Rows.InsertAt(fila2,1);
                //---- GSG (13/03/2019)
                //this.cbTipoCliente.SelectedValue="-1";
                this.cbTipoCliente.SelectedValue = "S";

                //Inicializar ComboBox Tipo Horario
                this.sqldaTipoHorarioRep.Fill(this.dsReports1);
				DataRow fila4 = this.dsReports1.ListaTipoHorarioRep.NewRow();
				fila4["sValor"]="-1";
				fila4["sLiteral"]="Todos";
				this.dsReports1.ListaTipoHorarioRep.Rows.InsertAt(fila4,1);
				this.cbHorario.SelectedValue="-1";

			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region Inicializar_DataGrids
		private void Inicializar_DataGrids()
		{
			try
			{
//				Utiles.Formatear_DataGrid(this,this.dtgGeneral,null,true,this.contextMenu1);
				Utiles.Formatear_DgConFilabEnviadoCEN(this.dtgGeneral,null,this.contextMenu1);
				for(int i=0 ; i< this.dtgGeneral.TableStyles[0].GridColumnStyles.Count;i++)
				{
					DataGridTextBoxColumn TextCol1 = (DataGridTextBoxColumn)this.dtgGeneral.TableStyles[0].GridColumnStyles[i];
					TextCol1.TextBox.DoubleClick += new EventHandler(dtgGeneral_DoubleClick);
				}

//				Utiles.Formatear_DataGrid(this,this.dgClientes,"C",true);
				Utiles.Formatear_DgConColumnaBoton(this.dgClientes,"C",null,4);

				GESTCRM.DataGridButtonColumn clboton1 = (GESTCRM.DataGridButtonColumn)this.dgClientes.TableStyles[0].GridColumnStyles[4];
				clboton1.CellButtonClicked += 
					new DataGridCellButtonClickEventHandler(HandleCellbtVerClienteClick);
				
				
				Utiles.Formatear_DataGrid(this,this.dgGadgets,"C",true);
				Utiles.Formatear_DgConFilabEnviadoCEN(this.dgAtenciones,"C",null);
				
				
//				Utiles.Formatear_DataGrid(this,this.dgPedidos,"C",true);
				Utiles.Formatear_DgConColumnaBoton(this.dgPedidos,"C",null,3);
				GESTCRM.DataGridButtonColumn clboton2 = (GESTCRM.DataGridButtonColumn)this.dgPedidos.TableStyles[0].GridColumnStyles[3];
				clboton2.CellButtonClicked += 
					new DataGridCellButtonClickEventHandler(HandleCellbtVerPedidoClick);
				
				
				Utiles.Formatear_DataGrid(this,this.dgProductos,"C",true);
				Utiles.Formatear_DataGrid(this,this.dgProxObj,"C",true);
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion 


		#region btSalir_Click
		private void btSalir_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
		#endregion 

		#region frmConsultaReport_Closed
		private void frmConsultaReport_Closed(object sender, System.EventArgs e)
		{
			this.Dispose();
		}
		#endregion 

		#region btNuevo_Click
		private void btNuevo_Click(object sender, System.EventArgs e)
		{	
			Nuevo_Report();
		}
		#endregion

		#region btEliminar_Click
		private void btEliminar_Click(object sender, System.EventArgs e)
		{
			Eliminar_Report();
		}
		#endregion 

		#region btEditar_Click
		private void btEditar_Click(object sender, System.EventArgs e)
		{
			Editar_Report();
		}
		#endregion


		#region menuEliminar_Click
		private void menuEliminar_Click(object sender, System.EventArgs e)
		{
			Eliminar_Report();
		}
		#endregion

		#region menuEditar_Click
		private void menuEditar_Click(object sender, System.EventArgs e)
		{
			Editar_Report();
		}
		#endregion

		#region menuNuevo_Click
		private void menuNuevo_Click(object sender, System.EventArgs e)
		{
			Nuevo_Report();
		}
		#endregion



		#region Nuevo_Report
		private void Nuevo_Report()
		{
			try
			{
				if(GESTCRM.Clases.Configuracion.iGVisitas==0)
				{
					if(int.Parse(this.cbDelegado.SelectedValue.ToString())== GESTCRM.Clases.Configuracion.iIdDelegado)
					{
						bool abierto=false;

						if(this.ParentForm == null) abierto=Utiles.MirarSiFormAbierto("frmReporting",this.Owner);
						else abierto = Utiles.MirarSiFormAbierto("frmReporting",this.ParentForm);

						if (!abierto)
						{
							Form frmTemp=new Formularios.frmReporting("A",-1,DateTime.Today.Date,GESTCRM.Clases.Configuracion.iIdDelegado);
							frmTemp.MdiParent=this.ParentForm;
							frmTemp.Show();
							Realizar_Busqueda();
						}
						else
						{
							DialogResult dr=Mensajes.ShowQuestion("No se puede crear un Report porque ya hay uno abierto. ¿Desea ver el report abierto?");
							if(dr==System.Windows.Forms.DialogResult.Yes)
							{
								GESTCRM.Utiles.ActivaFormularioAbierto("frmReporting",this.MdiParent);
								Realizar_Busqueda();
							}
						}
					}
					else
					{
						GESTCRM.Mensajes.ShowError(2000);//Sólo crear Reports propios
					}
				}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion 

		#region Editar_Report
		private void Editar_Report()
		{
			try
			{
				if(this.dtgGeneral.CurrentRowIndex!=-1)
				{
					string Acceso="M";
					bool abierto=false;
					int  iIdDelegado = Int32.Parse(this.dtgGeneral[this.dtgGeneral.CurrentRowIndex,1].ToString());
					int EnviadoCen = int.Parse(this.dtgGeneral[this.dtgGeneral.CurrentRowIndex,3].ToString());

					if(iIdDelegado!= GESTCRM.Clases.Configuracion.iIdDelegado){Acceso="C";}

					if(EnviadoCen==1) Acceso="C";

					if(GESTCRM.Clases.Configuracion.iGVisitas>0) Acceso="C";

					if(this.ParentForm == null) abierto=Utiles.MirarSiFormAbierto("frmReporting",this.Owner);
					else abierto = Utiles.MirarSiFormAbierto("frmReporting",this.ParentForm);

					if (!abierto)
					{
						int IdReport=Int32.Parse(this.dtgGeneral[this.dtgGeneral.CurrentRowIndex,0].ToString());
						DateTime fecha = DateTime.Parse(this.dtgGeneral[this.dtgGeneral.CurrentRowIndex,4].ToString());
						Form frmTemp=new Formularios.frmReporting(Acceso,IdReport,fecha,Int32.Parse(this.cbDelegado.SelectedValue.ToString()));
						frmTemp.MdiParent=this.ParentForm;
						frmTemp.Show();
						Realizar_Busqueda();
					}
					else
					{
						DialogResult dr=Mensajes.ShowQuestion("No se puede modificar un Report porque ya hay uno abierto. ¿Desea ver el report abierto?");
						if(dr==System.Windows.Forms.DialogResult.Yes)
						{
							GESTCRM.Utiles.ActivaFormularioAbierto("frmReporting",this.MdiParent);
							Realizar_Busqueda();
						}
					}
				}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion 

		#region Eliminar_Report
		private void Eliminar_Report()
		{
			try
			{
				if(this.dtgGeneral.CurrentRowIndex!=-1)
				{
					string sMensj="";
					bool borrado = false;
					int EnviadoCen = int.Parse(this.dtgGeneral[this.dtgGeneral.CurrentRowIndex,3].ToString());

					if(GESTCRM.Clases.Configuracion.iGVisitas==0 && EnviadoCen==0)
					{
						DialogResult dr=Mensajes.ShowQuestion("¿Desea borrar el registro?");
						if(dr == System.Windows.Forms.DialogResult.Yes)
						{
							int  iIdDelegado = Int32.Parse(this.dtgGeneral[this.dtgGeneral.CurrentRowIndex,1].ToString());

							if(iIdDelegado == GESTCRM.Clases.Configuracion.iIdDelegado)
							{
								bool abierto=false;

								if(this.ParentForm == null) abierto=Utiles.MirarSiFormAbierto("frmReporting",this.Owner);
								else abierto = Utiles.MirarSiFormAbierto("frmReporting",this.ParentForm);

								if(!abierto)
								{
									if(this.dtgGeneral.CurrentRowIndex>-1)
									{
										int IdReport=Int32.Parse(this.dtgGeneral[this.dtgGeneral.CurrentRowIndex,0].ToString());
										//Borrar
                                        //---- GSG (10/09/2014)
                                        //sqlConn.Open();
                                        if (sqlConn.State == ConnectionState.Closed)
                                            sqlConn.Open();


										try
										{
											this.sqlCmdGetPuedeBorrarReport.Parameters["@iIdReport"].Value=IdReport;
								
											this.sqlCmdGetPuedeBorrarReport.ExecuteNonQuery();

											int Total = int.Parse(this.sqlCmdGetPuedeBorrarReport.Parameters["@Total"].Value.ToString());

											if(Total==0)
											{
												try
												{
													this.sqlcmdSetRepActividad_Cab.Parameters["@iIdReport"].Value=IdReport;
													this.sqlcmdSetRepActividad_Cab.Parameters["@Accion"].Value=2;
								
													this.sqlcmdSetRepActividad_Cab.ExecuteNonQuery();

													Mensajes.ShowInformation("Se ha eliminado el registro");
													borrado=true;

												}
												catch(System.Data.SqlClient.SqlException ex)
												{
													sMensj ="Error al eliminar Report de Actividad: ";
													foreach(System.Data.SqlClient.SqlError Err in ex.Errors)
													{
														sMensj +=Err.Number.ToString()+" - "+Err.Message.ToString();
													}
													Mensajes.ShowError(sMensj);
												}
												catch(Exception e)
												{
													Mensajes.ShowError(e.Message);
												}
											}
											else
											{
												Mensajes.ShowInformation("No se puede eliminar el Report porqué tiene Atenciones asignadas que están asociadas a una Nota de Gastos que ya se ha enviado a Central.");
											}
										}
										catch(System.Data.SqlClient.SqlException ex)
										{
											sMensj ="Error al eliminar Report de Actividad: ";
											foreach(System.Data.SqlClient.SqlError Err in ex.Errors)
											{
												sMensj +=Err.Number.ToString()+" - "+Err.Message.ToString();
											}
											Mensajes.ShowError(sMensj);
										}
										catch(Exception e)
										{
											Mensajes.ShowError(e.Message);
										}
										this.sqlConn.Close();
										if (borrado) Realizar_Busqueda();
									}
								}
								else
								{
									DialogResult dr1=Mensajes.ShowQuestion("No se puede eliminar un Report porque hay uno abierto. ¿Desea ver el report abierto?");
									if(dr1==System.Windows.Forms.DialogResult.Yes)
									{
										GESTCRM.Utiles.ActivaFormularioAbierto("frmReporting",this.MdiParent);
									}
								}
							}
							else
							{
								GESTCRM.Mensajes.ShowError("No se pueden borrar Reports de Visita de otro delegado");//Sólo modificar Reports propios
							}
						}
					}
				}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion


		#region txtsIdCentro_Leave
		private void txtsIdCentro_Leave(object sender, System.EventArgs e)
		{
			try
            {
                this.txtsIdCentro.Text = this.txtsIdCentro.Text.Trim();

				GESTCRM.Formularios.Busquedas.frmMCentros frmBCent = new GESTCRM.Formularios.Busquedas.frmMCentros();
				frmBCent.ParamI_iIdDelegado = Int32.Parse(this.cbDelegado.SelectedValue.ToString());
				frmBCent.ParamIO_sIdCentro = this.txtsIdCentro.Text;
				frmBCent.ParamIO_sDescripcion = "";
				frmBCent.Buscar_sCentro();

                if (this.txtsIdCentro.Text.Length == 0)
                {
                    this.Var_iIdCentro = -1;
                    this.txtsIdCentro.Text = String.Empty;
                    this.txtsCentro.Text = String.Empty;
                }
                else
				    if(this.txtsIdCentro.Text != frmBCent.ParamIO_sIdCentro || this.txtsCentro.Text != frmBCent.ParamIO_sDescripcion)
				    {
					    if (frmBCent.ParamO_iIdCentro == -1)
                            Mensajes.ShowError("Este código de centro no existe.");

					    this.Var_iIdCentro = frmBCent.ParamO_iIdCentro;
					    this.txtsIdCentro.Text = frmBCent.ParamIO_sIdCentro;
					    this.txtsCentro.Text = frmBCent.ParamIO_sDescripcion;
				    }

				frmBCent.Dispose();
			}
			catch(Exception ex)
            {
                Mensajes.ShowError(ex.Message);
            }
		}
		#endregion

		#region btBuscarCentro_Click
		private void btBuscarCentro_Click(object sender, System.EventArgs e)
		{
			try
			{
				GESTCRM.Formularios.Busquedas.frmMCentros frmBCent = new GESTCRM.Formularios.Busquedas.frmMCentros();
				frmBCent.ParamIO_sDescripcion = "";
				frmBCent.ParamIO_sIdCentro = "";
				frmBCent.ParamI_iIdDelegado = Int32.Parse(this.cbDelegado.SelectedValue.ToString());
				frmBCent.ShowDialog(this);
				if (frmBCent.DialogResult==System.Windows.Forms.DialogResult.OK)
				{
					if(this.txtsIdCentro.Text!=frmBCent.ParamIO_sIdCentro)
					{
						this.Var_iIdCentro = frmBCent.ParamO_iIdCentro;
						this.txtsIdCentro.Text=frmBCent.ParamIO_sIdCentro;
						this.txtsCentro.Text=frmBCent.ParamIO_sDescripcion;
					}
				}
				frmBCent.Dispose();
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region txtsIdCliente_Leave
		private void txtsIdCliente_Leave(object sender, System.EventArgs e)
		{
			try
			{
				GESTCRM.Formularios.Busquedas.frmMClientesSAP frmBCli = new GESTCRM.Formularios.Busquedas.frmMClientesSAP(false,"CR");
				
				frmBCli.ParamI_iIdDelegado = Int32.Parse(this.cbDelegado.SelectedValue.ToString());
				frmBCli.ParamI_sIdCentro= this.txtsIdCentro.Text.ToString();
				if(this.cbTipoCliente.SelectedValue.ToString()=="-1") frmBCli.ParamI_sIdTipoCliente="T";
				else frmBCli.ParamI_sIdTipoCliente=this.cbTipoCliente.SelectedValue.ToString();
				frmBCli.ParamIO_sIdCliente = this.txtsIdCliente.Text.ToString();
				if(this.cbTipoReport.SelectedValue.ToString()=="2") frmBCli.ParamI_TipoVisita=0;//Pedido
				else frmBCli.ParamI_TipoVisita=1;//Visita

				frmBCli.Buscar_tNombre();
				
				if(this.txtsIdCliente.Text.ToString().Length>0 && frmBCli.ParamO_iIdCliente==-1) Mensajes.ShowError("Este código de Cliente no existe.");
				this.txtsIdCliente.Text=frmBCli.ParamIO_sIdCliente;
				this.txtsCliente.Text=frmBCli.ParamO_tNombre;
				this.Var_iIdCliente = frmBCli.ParamO_iIdCliente;
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region btBuscarCliente_Click
		private void btBuscarCliente_Click(object sender, System.EventArgs e)
		{
			try
			{
				GESTCRM.Formularios.Busquedas.frmMClientesSAP frmBCli = new GESTCRM.Formularios.Busquedas.frmMClientesSAP(false,"CR");
				
				frmBCli.ParamIO_sIdCliente = "";
				frmBCli.ParamI_sIdCentro = this.txtsIdCentro.Text.ToString();
				if(this.cbTipoCliente.SelectedValue.ToString()=="-1") frmBCli.ParamI_sIdTipoCliente="T";                
                else frmBCli.ParamI_sIdTipoCliente=this.cbTipoCliente.SelectedValue.ToString();
                

                if (this.cbTipoReport.SelectedValue.ToString()=="2") frmBCli.ParamI_TipoVisita=0;//Pedido
				else frmBCli.ParamI_TipoVisita=1;//Visita

				frmBCli.ParamI_iIdDelegado = Int32.Parse(this.cbDelegado.SelectedValue.ToString());

				frmBCli.ShowDialog(this);
				if (frmBCli.DialogResult==System.Windows.Forms.DialogResult.OK)
				{
					if(frmBCli.dtSeleccion.Rows.Count==0)
					{
						this.txtsIdCliente.Text=frmBCli.ParamIO_sIdCliente;
						this.txtsCliente.Text = frmBCli.ParamO_tNombre;
						this.Var_iIdCliente = frmBCli.ParamO_iIdCliente;
					}
					frmBCli.Dispose();
				}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		
		#region btBuscar_Click
		private void btBuscar_Click(object sender, System.EventArgs e)
		{
			Realizar_Busqueda();
		}
		private void Realizar_Busqueda()
		{
			Cursor.Current = Cursors.WaitCursor;
			try
			{
				int iIdDelegado			= Int32.Parse(this.cbDelegado.SelectedValue.ToString());
				int bPlanificacion		= int.Parse(this.cbPlanificacion.SelectedValue.ToString());
				string sTipoRActividad	= this.cbTipoReport.SelectedValue.ToString();
				string iHorario			= this.cbHorario.SelectedValue.ToString();
				string sIdTipoCliente	= this.cbTipoCliente.SelectedValue.ToString();
				int iIdCentro			= this.Var_iIdCentro;
				int iIdCliente			= this.Var_iIdCliente;
				DateTime dFechaIni		= this.dtpFechaIni.Value;
				DateTime dFechaFin		= this.dtpFechaFin.Value;

				this.dsReports1.ListaRepActividad_Consulta.Rows.Clear();

				this.sqldaListaRepActividad_Cab_Consulta.SelectCommand.Parameters["@iIdDelegado"].Value=iIdDelegado;
				this.sqldaListaRepActividad_Cab_Consulta.SelectCommand.Parameters["@bPlanificacion"].Value=bPlanificacion;
				this.sqldaListaRepActividad_Cab_Consulta.SelectCommand.Parameters["@sTipoRActividad"].Value = sTipoRActividad;
				this.sqldaListaRepActividad_Cab_Consulta.SelectCommand.Parameters["@iHorario"].Value=iHorario;
				this.sqldaListaRepActividad_Cab_Consulta.SelectCommand.Parameters["@sIdTipoCliente"].Value=sIdTipoCliente;
				this.sqldaListaRepActividad_Cab_Consulta.SelectCommand.Parameters["@iIdCentro"].Value=iIdCentro;
				this.sqldaListaRepActividad_Cab_Consulta.SelectCommand.Parameters["@iIdCliente"].Value = iIdCliente;
				this.sqldaListaRepActividad_Cab_Consulta.SelectCommand.Parameters["@dFechaIni"].Value=dFechaIni;
				this.sqldaListaRepActividad_Cab_Consulta.SelectCommand.Parameters["@dFechaFin"].Value=dFechaFin;

				this.sqldaListaRepActividad_Cab_Consulta.Fill(this.dsReports1);

				this.lblNumRegistros.Text=this.dsReports1.ListaRepActividad_Consulta.Rows.Count.ToString();

				if(this.dsReports1.ListaRepActividad_Consulta.Rows.Count>0)
				{
					Utiles.Seleccionar_UnaFilaDataGrid(this,this.dtgGeneral,0);
					this.Var_fila=0;
					Activar_Paneles(true);
				}
				else
				{
					Activar_Paneles(false);
				}

				this.dtgGeneral.Focus();
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
			Cursor.Current = Cursors.Default;
		}

		#endregion



		#region dtgGeneral_DoubleClick
		private void dtgGeneral_DoubleClick(object sender, System.EventArgs e)
		{
			Editar_Report();				
		}
		#endregion

		#region dtgGeneral_CurrentCellChanged
		private void dtgGeneral_CurrentCellChanged(object sender, System.EventArgs e)
		{
			try
			{
				GESTCRM.Utiles.Seleccionar_UnaFilaDataGrid(this,this.dtgGeneral,this.dtgGeneral.CurrentRowIndex);

				this.Var_fila=this.dtgGeneral.CurrentRowIndex;
				if(this.Var_fila>-1)
				{
					Mostrar_Paneles();
				}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region Mostrar_Paneles
		private void Mostrar_Paneles()
		{
			try
			{
				this.Var_iIdReport = Int32.Parse(this.dtgGeneral[this.Var_fila,0].ToString());

				if(this.dtgGeneral[this.Var_fila,5].ToString()=="0")//es un Report
				{
					//this.btDatos.Visible=true; //---- GSG (13/03/2019)
					if(this.btClientes.Font.Bold) Llenar_pnClientes();
					if(this.btDatos.Font.Bold) Llenar_pnDatosReport();
				}
				else //es una planificación
				{
					this.btDatos.Visible=false;
					Boton_Clientes();
				}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region btClientes_Click
		private void btClientes_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.btClientes.Font = Utiles.fuenteBold;
				this.btDatos.Font = Utiles.fuenteNoBold;

				this.pnClientes.Visible=true;
				this.pnDatosReport.Visible=false;

				Llenar_pnClientes();
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}

		private void Boton_Clientes()
		{
			try
			{
				this.btClientes.Font = Utiles.fuenteBold;
				this.btDatos.Font = Utiles.fuenteNoBold;
				this.pnClientes.Visible=true;
				this.pnDatosReport.Visible=false;

				Llenar_pnClientes();
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

//		#region btProductos_Click
//		private void btProductos_Click(object sender, System.EventArgs e)
//		{
//			try
//			{
//				this.btClientes.Font = Utiles.fuenteNoBold;
//				this.btProductos.Font = Utiles.fuenteBold;
//				this.btDatos.Font = Utiles.fuenteNoBold;
//
//				this.pnClientes.Visible=false;
//				this.pnProductos.Visible=true;
//				this.pnDatosReport.Visible=false;
//
//				Llenar_pnProductos();
//			}
//			catch(Exception ex){Mensajes.ShowError(ex.Message);}
//		}
//		#endregion

		#region btDatos_Click
		private void btDatos_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.btClientes.Font = Utiles.fuenteNoBold;
				this.btDatos.Font = Utiles.fuenteBold;
				this.pnClientes.Visible=false;
				this.pnDatosReport.Visible=true;

				Llenar_pnDatosReport();
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region Llenar_pnClientes
		private void Llenar_pnClientes()
		{
			try
			{
				this.dsReports1.ListaRepActividadCli.Rows.Clear();

				this.sqldaListaRepActividad_Cli.SelectCommand.Parameters["@iIdReport"].Value=this.Var_iIdReport;
				this.sqldaListaRepActividad_Cli.Fill(this.dsReports1);

				this.lblTotClientes.Text = this.dsReports1.ListaRepActividadCli.Rows.Count.ToString();

				int iIdCliente = -1;
				if(this.dsReports1.ListaRepActividadCli.Rows.Count>0)
				{
					iIdCliente = Int32.Parse(this.dgClientes[0,0].ToString());
					Utiles.Seleccionar_UnaFilaDataGrid(this,this.dgClientes,0);
				}
				
				string TipoCliente = this.dtgGeneral[this.Var_fila,10].ToString();
				if(TipoCliente=="S") //ClienteSAP
				{
					this.dgClientes.TableStyles[0].GridColumnStyles[3].Width=0;
					if(GESTCRM.Clases.Configuracion.iGClientesSAP==2)//No tiene acceso a Clientes
					{
						this.dgClientes.TableStyles[0].GridColumnStyles[4].Width=0;
					}
					else this.dgClientes.TableStyles[0].GridColumnStyles[4].Width=40;
					pnPedidosAsociados.Visible = true;
					pnPromociones.Visible = false;

				}
				else if(TipoCliente=="C")//ClienteCOM
				{
					this.dgClientes.TableStyles[0].GridColumnStyles[3].Width=30;
					if(GESTCRM.Clases.Configuracion.iGClientesCOM==2)//No tiene acceso a Clientes
					{
						this.dgClientes.TableStyles[0].GridColumnStyles[4].Width=0;
					}
					else this.dgClientes.TableStyles[0].GridColumnStyles[4].Width=40;
					Cargar_dgProductos();
					pnPedidosAsociados.Visible = false;
					pnPromociones.Visible = true;

				}
				if(this.dtgGeneral[this.Var_fila,5].ToString()=="0")//es un Report
				{
					this.pnDatosCliente.Visible=true;
					this.pnProxObj.Visible=false;
					Cargar_DatosCliente(iIdCliente);
				}
				else//es una Planificación
				{
					this.pnProxObj.Visible=true;
					this.pnDatosCliente.Visible=false;
					Cargar_ProximosObjetivos();
				}

			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region Cargar_DatosCliente
		private void Cargar_DatosCliente(int iIdCliente)
		{
			try
			{
				this.dsReports1.ListaRepActividGadget.Rows.Clear();
				this.dsReports1.ListaRepActividAtenciones.Rows.Clear();
				this.dsReports1.ListaRepActividPedidos.Rows.Clear();
				if(iIdCliente>-1)
				{
					this.sqldaListaRepActividad_Gadget.SelectCommand.Parameters["@iIdReport"].Value = this.Var_iIdReport;
					this.sqldaListaRepActividad_Gadget.SelectCommand.Parameters["@iIdCliente"].Value = iIdCliente;
					this.sqldaListaRepActividad_Gadget.Fill(this.dsReports1);
					if(this.dsReports1.ListaRepActividGadget.Rows.Count>0)
					{
						Utiles.Seleccionar_UnaFilaDataGrid(this,this.dgGadgets,0);
					}

					this.sqldaListaRepActividadAtenciones.SelectCommand.Parameters["@iIdReport"].Value = this.Var_iIdReport;
					this.sqldaListaRepActividadAtenciones.SelectCommand.Parameters["@iIdCliente"].Value = iIdCliente;
					this.sqldaListaRepActividadAtenciones.Fill(this.dsReports1);
					if(this.dsReports1.ListaRepActividAtenciones.Rows.Count>0)
					{
						Utiles.Seleccionar_UnaFilaDataGrid(this,this.dgAtenciones,0);
					}

					this.sqldaRepActividad_Pedidos.SelectCommand.Parameters["@iIdReport"].Value = this.Var_iIdReport;
					this.sqldaRepActividad_Pedidos.Fill(this.dsReports1);
					if(this.dsReports1.ListaRepActividPedidos.Rows.Count>0)
					{
						Utiles.Seleccionar_UnaFilaDataGrid(this,this.dgPedidos,0);
					}
					if (GESTCRM.Clases.Configuracion.iGPedidos==2)//no tiene acceso a pedidos
					{this.dgPedidos.TableStyles[0].GridColumnStyles[3].Width=0;}
					else this.dgPedidos.TableStyles[0].GridColumnStyles[3].Width=40;
				}
				this.lblTotGadgets.Text = this.dsReports1.ListaRepActividGadget.Rows.Count.ToString();
				this.lblTotAtenciones.Text = this.dsReports1.ListaRepActividAtenciones.Rows.Count.ToString();
				this.lblTotPedidos.Text = this.dsReports1.ListaRepActividPedidos.Rows.Count.ToString();
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region Cargar_ProximosObjetivos
		private void Cargar_ProximosObjetivos()
		{
			try
			{
				int iIdCentro = -1;
				try
				{
					iIdCentro = Int32.Parse(this.dtgGeneral[this.Var_fila,2].ToString());
				}
				catch{}
				
				this.dsReports1.ListaRepActividadCli_ProxObj.Rows.Clear();

				if(iIdCentro>-1)
				{
					this.sqldaListaRepActividadCli_ProxObj.SelectCommand.Parameters["@iIdCentro"].Value=iIdCentro;
					this.sqldaListaRepActividadCli_ProxObj.SelectCommand.Parameters["@iIdCliente"].Value=-1;
					this.sqldaListaRepActividadCli_ProxObj.Fill(this.dsReports1);

					this.lblTotProxObj.Text = this.dsReports1.ListaRepActividadCli_ProxObj.Rows.Count.ToString();
					if(this.dsReports1.ListaRepActividadCli_ProxObj.Rows.Count>0)
					{
						Utiles.Seleccionar_UnaFilaDataGrid(this,this.dgProxObj,0);
					}
				}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region Llenar_pnProductos
		private void Llenar_pnProductos()
		{
			try
			{
				this.dsReports1.ListaRepActividadProd.Rows.Clear();

				this.sqldaListaRepActividadProd.SelectCommand.Parameters["@iIdReport"].Value = this.Var_iIdReport;
				this.sqldaListaRepActividadProd.Fill(this.dsReports1);

				this.lblTotProductos.Text = this.dsReports1.ListaRepActividadProd.Rows.Count.ToString();
				if(this.dsReports1.ListaRepActividadProd.Rows.Count>0)
				{
					Utiles.Seleccionar_UnaFilaDataGrid(this,this.dgProductos,0);
				}

			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region Llenar_pnDatosReport
		private void Llenar_pnDatosReport()
		{
			try
			{
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion


		#region dgClientes_CurrentCellChanged
		private void dgClientes_CurrentCellChanged(object sender, System.EventArgs e)
		{
			try
			{
				int fila = this.dgClientes.CurrentRowIndex;
				Utiles.Seleccionar_UnaFilaDataGrid(this,this.dgClientes,fila);
				int iIdCliente=-1;
				if(fila>-1) iIdCliente = Int32.Parse(this.dgClientes[fila,0].ToString());
				Cargar_DatosCliente(iIdCliente);
				FiltrarProductosClientes();
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region dgClientes_MouseMouve
		private void dgClientes_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			dgClientes_ToolTip(this.dgClientes,e.X,e.Y);
		}

		private void dgClientes_ToolTip(DataGrid dg, int cx, int cy)
		{
			try
			{
				System.Windows.Forms.DataGrid.HitTestInfo myHitTest;
				myHitTest = dg.HitTest(cx,cy);
				int columna = myHitTest.Column;
				int fila = myHitTest.Row;

				if(fila>-1 && columna==4)
				{
					this.lblToolTipBoton.Visible=true;
					int y = dg.Location.Y + cy;
					int x = dg.Location.X + dg.Width-200;
					System.Drawing.Point p = new Point(x+10,y+15);
					this.lblToolTipBoton.Location =p;
					this.lblToolTipBoton.Text = "Acceso al Cliente/Acciones de Marketing";
					this.lblToolTipBoton.AutoSize=true;
				}
				else
				{
					this.lblToolTipBoton.Visible=false;
				}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		
		#region dgGadgets_CurrentCellChanged
		private void dgGadgets_CurrentCellChanged(object sender, System.EventArgs e)
		{
			try
			{
				int fila = this.dgGadgets.CurrentRowIndex;
				Utiles.Seleccionar_UnaFilaDataGrid(this,this.dgGadgets,fila);
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion 

		#region dgAtenciones_CurrentCellChanged
		private void dgAtenciones_CurrentCellChanged(object sender, System.EventArgs e)
		{
			try
			{
				int fila = this.dgAtenciones.CurrentRowIndex;
				Utiles.Seleccionar_UnaFilaDataGrid(this,this.dgAtenciones,fila);
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion 

		#region dgPedidos_CurrentCellChanged
		private void dgPedidos_CurrentCellChanged(object sender, System.EventArgs e)
		{
			try
			{
				int fila = this.dgPedidos.CurrentRowIndex;
				Utiles.Seleccionar_UnaFilaDataGrid(this,this.dgPedidos,fila);
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion 

		#region dgPedidos_MouseMouve
		private void dgPedidos_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			dgPedidos_ToolTip(this.dgPedidos,e.X,e.Y);
		}

		private void dgPedidos_ToolTip(DataGrid dg, int cx, int cy)
		{
			try
			{
				System.Windows.Forms.DataGrid.HitTestInfo myHitTest;
				myHitTest = dg.HitTest(cx,cy);
				int columna = myHitTest.Column;
				int fila = myHitTest.Row;

				if(fila>-1 && columna==3)
				{
					this.lblToolTipBtPed.Visible=true;
					int y = dg.Location.Y + cy;
					int x = dg.Location.X + dg.Width-100;
					System.Drawing.Point p = new Point(x+10,y+15);
					this.lblToolTipBtPed.Location =p;
					this.lblToolTipBtPed.Text = "Acceso al Pedido";
					this.lblToolTipBtPed.AutoSize=true;
				}
				else
				{
					this.lblToolTipBtPed.Visible=false;
				}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion


		#region dgProductos_CurrentCellChanged
		private void dgProductos_CurrentCellChanged(object sender, System.EventArgs e)
		{
			try
			{
				int fila = this.dgProductos.CurrentRowIndex;
				Utiles.Seleccionar_UnaFilaDataGrid(this,this.dgProductos,fila);
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region dgProxObj_CurrentCellChanged
		private void dgProxObj_CurrentCellChanged(object sender, System.EventArgs e)
		{
			try
			{
				int fila = this.dgProxObj.CurrentRowIndex;
				Utiles.Seleccionar_UnaFilaDataGrid(this,this.dgProxObj,fila);
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion


		#region Activar_Paneles
		private void Activar_Paneles(bool Activar)
		{
			try
			{
				if(Activar)
				{
                    //this.btClientes.Visible=true; //---- GSG (13/03/2019)
                    this.pnClientes.Visible=true;
					Mostrar_Paneles();
				}
				else
				{
					this.btDatos.Visible=false;
					this.btClientes.Visible=false;
					this.pnClientes.Visible=false;
					this.pnDatosCliente.Visible=false;
				}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region Mostrar_FormularioCliente
		private void Mostrar_FormularioCliente(int fila)
		{
			try
			{
				int iIdCliente=-1;
				if(fila>-1)
				{
					iIdCliente = Int32.Parse(this.dgClientes[fila,0].ToString());
				}

				Abrir_FormularioCliente(iIdCliente,fila);
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}

		private void Abrir_FormularioCliente(int iIdCliente,int fila)
		{	
			try
			{
				string Acceso="M";
				string TipoCliente = this.dtgGeneral[this.Var_fila,10].ToString();

				if(int.Parse(this.cbDelegado.SelectedValue.ToString())!= GESTCRM.Clases.Configuracion.iIdDelegado)
				{Acceso="C";}
				
				if(GESTCRM.Clases.Configuracion.iGVisitas>0) Acceso="C";

				if(this.dtgGeneral[this.Var_fila,3].ToString()=="1") Acceso="C";//Report Enviado a Central
				
				if(iIdCliente > -1)
				{
					bool abierto=false;
					if(TipoCliente!="S")
					{
						if(this.ParentForm== null && this.Owner==null)
						{
							Mensajes.ShowInformation("No se puede abrir el formulario. Demasiadas ventanas abiertas. ");
						}
						else
						{
							if(this.ParentForm == null) abierto=Utiles.MirarSiFormAbierto("frmAltaMedicos",this.Owner);
							else abierto = Utiles.MirarSiFormAbierto("frmAltaMedicos",this.ParentForm);
							if (abierto && Acceso!="C")
							{
								DialogResult dr=Mensajes.ShowQuestion("No se puede modificar el cliente porque ya hay uno abierto. Si quiere modificar un cliente cierre el que ya está abierto. ¿Desea abrirlo en modo consulta?");
								if(dr==System.Windows.Forms.DialogResult.Yes)
								{
									abierto=false;
									Acceso="C";
								}
							}
							if (!abierto)
							{
								Formularios.frmAltaMedicos  myFormCOM = new Formularios.frmAltaMedicos(Acceso,iIdCliente);				
								myFormCOM.MdiParent=this.ParentForm;
								myFormCOM.Show();
							}
						}
					}
					else
					{
						if(this.ParentForm== null && this.Owner==null)
						{
							Mensajes.ShowInformation("No se puede abrir el formulario. Demasiadas ventanas abiertas. ");
						}
						else
						{
							if(this.ParentForm == null) abierto=Utiles.MirarSiFormAbierto("frmMClientesSAP",this.Owner);
							else abierto = Utiles.MirarSiFormAbierto("frmMClientesSAP",this.ParentForm);
							if (abierto && Acceso!="C")
							{
								DialogResult dr=Mensajes.ShowQuestion("No se puede modificar el cliente porque ya hay uno abierto. Si quiere modificar un cliente cierre el que ya está abierto. ¿Desea abrirlo en modo consulta?");
								if(dr==System.Windows.Forms.DialogResult.Yes)
								{
									abierto=false;
									Acceso="C";
								}
							}
							if (!abierto)
							{
								Formularios.Mantenimientos.frmManClientesSAP myFormSAP = new Formularios.Mantenimientos.frmManClientesSAP(Acceso,iIdCliente,0);				
								myFormSAP.MdiParent=this.ParentForm;
								myFormSAP.Show();
							}
						}
					}
				}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion


		// handler for a click on one of the gridcell buttons
		#region HandleCellbtVerClienteClick
		private void HandleCellbtVerClienteClick(object sender, DataGridCellButtonClickEventArgs e)
		{
			Mostrar_FormularioCliente(e.RowIndex);
		}
		#endregion

		#region VerPedido
		private void VerPedido(int fila)
		{
			try
			{
				char Acceso='M';

				if(GESTCRM.Clases.Configuracion.iGVisitas>0) Acceso='C';

				if(Int32.Parse(this.cbDelegado.SelectedValue.ToString())!= GESTCRM.Clases.Configuracion.iIdDelegado)
				{Acceso='C';}

				if(this.dtgGeneral[this.Var_fila,3].ToString()=="1") Acceso='C';//Report Enviado a Central

				if (fila>-1)
				{
					string sIdPedido = this.dgPedidos[fila,0].ToString();
					int iIdDelegado = Int32.Parse(this.cbDelegado.SelectedValue.ToString());

					bool abierto=false;
					if(this.ParentForm== null && this.Owner==null)
					{
						Mensajes.ShowInformation("No se puede abrir el formulario. Demasiadas ventanas abiertas. ");
					}
					else
					{
						if(this.ParentForm == null) abierto=Utiles.MirarSiFormAbierto("frmPedidos",this.Owner);
						else abierto = Utiles.MirarSiFormAbierto("frmPedidos",this.MdiParent);
						if (abierto && Acceso!='C')
						{
							DialogResult dr=Mensajes.ShowQuestion("No se puede modificar el pedido porque ya hay uno abierto.Si quiere modificar un pedido cierre el que ya está abierto. ¿Desea abrirlo en modo consulta?.");
							if(dr==System.Windows.Forms.DialogResult.Yes)
							{
								abierto=false;
								Acceso='C';
							}
						}

						if (!abierto)
						{
                            using (Formularios.frmPedidos frmPed = new Formularios.frmPedidos(sIdPedido, iIdDelegado, Acceso))
                            {
                                //---- GSG (28/06/2011)
                                //frmPed.ShowDialog(this);

                                frmPed.MdiParent = this.MdiParent;
                                frmPed.Show();
                                while (frmPed.Visible == true)
                                {
                                    System.Threading.Thread.Sleep(100);
                                    Application.DoEvents();
                                }
                                //---- FI GSG

                            }
						}
					}
				}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		// handler for a click on one of the gridcell buttons
		#region HandleCellbtVerPedidoClick
		private void HandleCellbtVerPedidoClick(object sender, DataGridCellButtonClickEventArgs e)
		{
			VerPedido(e.RowIndex);
		}
		#endregion

		private void cbDelegado_Leave(object sender, System.EventArgs e)
		{
			if(this.cbDelegado.SelectedIndex==-1) this.cbDelegado.SelectedValue=GESTCRM.Clases.Configuracion.iIdDelegado;
		}

		private void cbPlanificacion_Leave(object sender, System.EventArgs e)
		{
			if(this.cbPlanificacion.SelectedIndex==-1) this.cbPlanificacion.SelectedValue=-1;
		}

		private void cbTipoReport_Leave(object sender, System.EventArgs e)
		{
			if(this.cbTipoReport.SelectedIndex==-1) this.cbTipoReport.SelectedValue="-1";
		}

		private void cbTipoCliente_Leave(object sender, System.EventArgs e)
		{
			if(this.cbTipoCliente.SelectedIndex==-1) this.cbTipoCliente.SelectedValue="-1";
		}

		private void cbHorario_Leave(object sender, System.EventArgs e)
		{
			if(this.cbHorario.SelectedIndex==-1) this.cbHorario.SelectedValue="-1";
		}

		//Cargar_dgProductos
		//Recupera los productos asociados al Report en BD
		//Se Utiliza al inicializar el formulario
		#region Cargar_dgProductos
		private void Cargar_dgProductos()
		{
			try
			{	string siIdCLiente = "-1";
				if(this.dsReports1.ListaRepActividadCli.Rows.Count > 0)
					siIdCLiente = this.dgClientes[0,0].ToString();
				dsReports1.ListaPromocionProd.Rows.Clear();
				sqldaListaPromocionProd.SelectCommand.Parameters["@iIdReport"].Value= this.Var_iIdReport;
				sqldaListaPromocionProd.Fill(this.dsReports1);
				FiltrarProductosClientes(siIdCLiente);
				//dsReports1.ListaPromocionProd.DefaultView.RowFilter = "iIdCliente = " + siIdCLiente;
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		
		#endregion
		#region Filtrar Productos Clientes
		private void FiltrarProductosClientes()
		{
			string sIdCliente = "-1";
			if (dgClientes.CurrentRowIndex != -1)
			{
				sIdCliente = this.dgClientes[this.dgClientes.CurrentRowIndex,0].ToString();
				FiltrarProductosClientes(sIdCliente);
			}
		}
		private void FiltrarProductosClientes(string sIdCliente)
		{
			dsReports1.ListaPromocionProd.DefaultView.RowFilter = "iIdCliente = " + sIdCliente;
			lblTotProductos.Text = dsReports1.ListaPromocionProd.DefaultView.Count.ToString();
		}
		#endregion

	}
}

