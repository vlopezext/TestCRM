using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;

namespace GESTCRM.Formularios
{
	/// <summary>
	/// Descripción breve de frmReporting.
	/// </summary>
	public class frmReporting : System.Windows.Forms.Form
	{
		//Guardan el valor pasado como parámetro
		private string		ParamTipoAcceso;	//Tipo de acceso al formulario A:Alta, M:Modificación, C:Consulta
		private int			ParamIdReport;		//Identificador de Report, sólo en Modificaciones y Consultas
		private DateTime	ParamFecha;			//sólo en Altas desde planificación
		private int			ParamiIdDelegado;	//Identificador de delegado
        private DateTime    ParamNuevaFecha;    //Fecha en la que hacer copia del report planificación para convertirlo en visita //---- GSG (17/06/2016)
	
		private bool SalirDesdeGuardar;
		private int	Var_iEstado;
		private int Var_bPlanificacion;
		private int Var_bEnviadoCEN;
		private int Var_iIdCentro;
		private int Var_iIdAtencion;
		private int Var_iNumAtencion;
		private string Var_sIdTipoAtencion;
		private string Var_sTipoAtencion;

		private int	Temp_iIdGadget;
		private int Temp_iIdCliente;
		private string Temp_ProxObj;

		private DataTable dtSiNo;
		private DataTable dtProductosDg;	//Registros que aparecen por pantalla
        private DataTable dtProductosRep;	//Registros BD ---- GSG (27/02/2015)
		private DataTable  dtClientesDg;	//Registros que aparecen por pantalla
		private DataTable  dtGadgetsDg;		//Registros que aparecen por pantalla
		private DataTable  dtGadgetsRep;	//Registros con los que se actualiza la BD
		private DataTable  dtAtencionesDg;	//Registros que aparecen por pantalla
		private DataTable  dtAtencionesRep;	//Registros con los que se actualiza la BD
//		private DataTable  dtAtenciones;    //LLeva el ImporteReal de las Atenciones Asignadas
		private DataTable  dtPedidosDg;		//Registros que aparecen por pantalla
        //---- GSG (13/10/2011) 
        private DataTable dtPedidosRep;     //tots
        //---- GSG (30/08/2011) 
        //En el cas de client SAP guardem per a cada client la seva propia hora d'inici i fi 
        private DataTable dtClienteHoraDg;
        //---- GSG (23/03/2012)
        const int K_MIN_HOUR = 420;         //7:00 en minuts
        const int K_MAX_HOUR = 1230;        //20:30 en minuts
        //---- GSG (15/05/2012)
        private bool _convertit = false;
        //---- GSG (03/07/2019)
        private bool _bEncuesta = false;
        private bool _bSalidaFlecha = false;

        protected System.Data.SqlClient.SqlTransaction sqlTran;
		private System.Windows.Forms.TextBox txbObjetivo;
		private System.Windows.Forms.Label lblObjetivo;
		private System.Windows.Forms.Label lblProxObj;
		private System.Windows.Forms.TextBox txbObservaciones;
		private System.Windows.Forms.Label lblObservaciones;
		private System.Data.SqlClient.SqlConnection sqlConn;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.ComboBox cbHorario;
		private System.Windows.Forms.ComboBox cbTipoRActibidad;
		private System.Windows.Forms.Label lblTipoRActividad;
		private System.Windows.Forms.ComboBox cbTipoCliente;
		private System.Windows.Forms.Label lblTipoCliente;
		private System.Data.SqlClient.SqlDataAdapter sqldaTipoRActividad;
		private System.Data.SqlClient.SqlDataAdapter sqldaTipoCliente;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		private System.Data.SqlClient.SqlDataAdapter sqldaTipoHorarioRep;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand4;
		private System.Windows.Forms.Label lblFecha;
		private System.Windows.Forms.Label lblHorario;
		private System.Windows.Forms.Label lblDelegado;
		private System.Windows.Forms.Panel pnReportActiv;
		private System.Windows.Forms.DateTimePicker dtpFecha;
		private System.Windows.Forms.TextBox txtClienteSAP;
		private System.Windows.Forms.Label lblCentro;
		private System.Data.SqlClient.SqlDataAdapter sqldaListaPromocionProd;
		private System.Data.SqlClient.SqlDataAdapter sqldaListaRepActProductos;
        private System.Data.SqlClient.SqlDataAdapter sqldaListaBuscarProductos; //---- GSG (23/02/2015)
		private System.Data.SqlClient.SqlCommand sqlSelectCommand5;
		private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DataGrid dgClientes;
		private System.Windows.Forms.Button btClienteActualizar;
        private System.Windows.Forms.Button btClienteEliminar;
		private System.Windows.Forms.DataGrid dgPedidos;
		private System.Windows.Forms.ComboBox cbPedidos;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button btPedActualizar;
		private System.Windows.Forms.Button btPedEliminar;
		private System.Windows.Forms.Label label9;
		private System.Data.SqlClient.SqlCommand sqlcomdGetRepActividadCab;
		private System.Windows.Forms.TextBox txtProxObjetivo;
		private System.Data.SqlClient.SqlDataAdapter sqldaCentroClienteCOM;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand10;
		private System.Data.SqlClient.SqlDataAdapter sqldaRepActClientes;
		private System.Data.SqlClient.SqlDataAdapter sqldaRepActGadgets;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle3;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn8;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn9;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand12;
		private System.Windows.Forms.TextBox txtsIdCentro;
		private System.Windows.Forms.TextBox txtsCentro;
		private System.Windows.Forms.Button btBuscarCentro;
		private System.Windows.Forms.TextBox txtsCliente;
		private System.Windows.Forms.Button btBuscarCliente;
        private System.Windows.Forms.TextBox txtsDelegado;
		private System.Windows.Forms.Panel pnClientesVisitados;
		private System.Data.SqlClient.SqlDataAdapter sqldaRepActAtenciones;
        private System.Data.SqlClient.SqlDataAdapter sqldaRepActPedidos;
		private System.Data.SqlClient.SqlDataAdapter sqldaPedidosAsignables;

		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle5;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn11;
		private System.Data.SqlClient.SqlCommand sqlcmdSetRepActividad_Cab;
		private System.Data.SqlClient.SqlCommand sqlcmdSetRepActividad_Cli;
		private System.Data.SqlClient.SqlCommand sqlcmdSetRepActividad_Aten;
		private System.Data.SqlClient.SqlCommand sqlcmdSetRepActividad_Ped;
		private System.Data.SqlClient.SqlCommand sqlcmdSetRepActividad_Gad;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn12;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel pnPedidos;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtClienteObserv;
		private System.Windows.Forms.TextBox txtClienteProxObj;
		private System.Windows.Forms.TextBox txtClienteObjetivo;
		private System.Windows.Forms.Label label7;
		private System.Data.SqlClient.SqlCommand sqlcmdSetRepActividadCli_ProxObj;
		private System.Data.SqlClient.SqlDataAdapter sqldaListaRepActividadCli_ProxObj;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn13;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn14;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn15;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn16;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn17;
		private System.Windows.Forms.CheckBox cbSustituto;
        private GESTCRM.Controles.ucBotoneraSecundaria ucBotoneraSecundaria1;
		private System.Data.SqlClient.SqlCommand sqlcomdSetRepActividad_ImporteReal_Aten;
        private System.Windows.Forms.Button btVerCentro;
        private System.Windows.Forms.Panel panel4;

		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn24;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn25;
		private System.Windows.Forms.Panel pnDatosClientesPlanif;
		private System.Windows.Forms.DataGrid dgClientesProxObj;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle6;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn26;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn27;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn28;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn29;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn30;
        private System.Windows.Forms.Button btNuevoPedido;
		private System.Windows.Forms.Label lblTotClientes;
		private System.Windows.Forms.Label lblTotProxObj;
		private GESTCRM.Controles.LabelGradient lblReporting;
		private System.Windows.Forms.Panel panel6;
        private GESTCRM.Controles.LabelGradient labelGradient2;
		private System.Windows.Forms.Panel panel10;
		private GESTCRM.Controles.LabelGradient labelGradient6;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn31;
		private System.Windows.Forms.ContextMenu cmClientes;
		private System.Windows.Forms.MenuItem mnNuevoCli;
		private System.Windows.Forms.MenuItem mnEliminarCli;
		private System.Windows.Forms.ContextMenu cmGadgets;
		private System.Windows.Forms.MenuItem mnNuevoGad;
		private System.Windows.Forms.MenuItem mnEliminarGad;
		private System.Windows.Forms.ContextMenu cmAtenciones;
		private System.Windows.Forms.MenuItem mnNuevoAten;
		private System.Windows.Forms.MenuItem mnEliminarAten;
		private System.Windows.Forms.ContextMenu cmPedidos;
		private System.Windows.Forms.MenuItem mnNuevoPed;
		private System.Windows.Forms.MenuItem mnEliminarPed;
		private System.Windows.Forms.ContextMenu cmProductos;
		private System.Windows.Forms.MenuItem mnNuevoProd;
		private System.Windows.Forms.MenuItem mnEliminarProd;
		private System.Windows.Forms.Label lblToolTipBoton;
		private GESTCRM.Formularios.DataSets.dsReports dsReports1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn32;
        private System.Data.SqlClient.SqlCommand sqlSelectCommand6;
        private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand9;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand11;        
		private System.Data.SqlClient.SqlCommand sqlSelectCommand7;
        private System.Data.SqlClient.SqlCommand sqlSelectCommand8;
		private System.Data.SqlClient.SqlCommand sqlcmdSetRepActividad_Prom;
        private System.Data.SqlClient.SqlCommand sqlSelectCmdBuscarProductos;
        private DateTimePicker dtpHoraInicio;
        private Label label13;
        private DateTimePicker dtpHoraFin;
        private Label label12;
        private TextBox txbHoraFin;
        private TextBox txbHoraInicio;
        private Busquedas.dsBuscar dsBuscar1;
        private BindingSource listaBuscarProductosBindingSource;
        private BindingSource listaPromocionProdBindingSource1;
        private Panel pnDatosClienteVisita;
        private Panel pnProductosProm;
        private Panel panel5;
        private DataGridView dGVProductosPromo;
        private Panel panel9;
        private Label lblToolTipBtPed;
        private Label lblTotPedidos;
        private Controles.LabelGradient labelGradient5;
        private DataGrid dgProductos;
        private DataGridTableStyle dataGridTableStyle1;
        private Label lblTotProductos;
        private Controles.LabelGradient labelGradient1;
        private Button btModifProd;
        private Button btBorrarProd;
        private Panel pnProductos;
        private Button btBuscarProducto;
        private TextBox txtsProducto;
        private TextBox txtsIdProducto;
        private NumericUpDown nudiMuestras;
        private NumericUpDown nudiOrden;
        private Label lblProducto;
        private Label lblOrdeb;
        private Label lbliMuestras;
        private Panel panel3;
        private Button btBuscarAtencion;
        private TextBox txtsIdAtencion;
        private NumericUpDown nupImporteCli;
        private Label label5;
        private Label label8;
        private Label label11;
        private Label label10;
        private Label txtfImportePrev;
        private Label txtTipoAtencion;
        private Button btAtenActualizar;
        private Button btAtenEliminar;
        private Panel pnTodaAtencion;
        private Panel panel8;
        private DataGrid dgAtenciones;
        private DataGridTableStyle dataGridTableStyle4;
        private Label lblTotAtenciones;
        private Controles.LabelGradient labelGradient4;
        private Panel panel7;
        private DataGrid dgGadgets;
        private DataGridTableStyle dataGridTableStyle2;
        private Label lblTotGadgets;
        private Controles.LabelGradient labelGradient3;
        private Panel panel2;
        private Button btBuscarGadget;
        private TextBox txtsGadget;
        private NumericUpDown nudCantidadGad;
        private Label label3;
        private Label label2;
        private Button btGadgetActualizar;
        private Button btGadgetEliminar;
        private DataGridTextBoxColumn dataGridTextBoxColumn3;
        private DataGridTextBoxColumn dataGridTextBoxColumn7;
        private DataGridTextBoxColumn dataGridTextBoxColumn36;
        private DataGridTextBoxColumn dataGridTextBoxColumn35;
        private DataGridTextBoxColumn dataGridTextBoxColumn23;
        private DataGridTextBoxColumn dataGridTextBoxColumn22;
        private DataGridTextBoxColumn dataGridTextBoxColumn21;
        private DataGridTextBoxColumn dataGridTextBoxColumn20;
        private DataGridTextBoxColumn dataGridTextBoxColumn34;
        private DataGridTextBoxColumn dataGridTextBoxColumn33;
        private DataGridTextBoxColumn dataGridTextBoxColumn10;
        private DataGridTextBoxColumn dtgsSelected;
        private DataGridTextBoxColumn dtgiIdCliente;
        private DataGridTextBoxColumn dtgsProducto;
        private DataGridTextBoxColumn dtgCant;
        private DataGridTextBoxColumn dtgOrden;
        private DataGridTextBoxColumn dtgsDescripcion;
        private Panel pnAceptarPromo;
        private Label lblActProdProm;
        private Button btAceptarProdsPromo;
        private Button btEncuestas;
        private BindingSource listaPromocionProdBindingSource;

		public frmReporting(string TipoAcceso, int IdReport,DateTime Fecha,int iIdDelegado)
		{
            InitializeComponent();


            //---- GSG (06/03/2021)
            Utiles.GetConfigConnection();
            this.sqlConn.ConnectionString = Utiles._connection.ConnectionString.ToString();



            this.ParamTipoAcceso=TipoAcceso;//A-> Alta; M->Modificación; C->Consulta
			this.ParamIdReport=IdReport;	// Identificador del Report
			this.ParamFecha=Fecha;			// Fecha del Report, sólo se usa para el alta y cuando la llamada es desde Planificación			
			this.ParamiIdDelegado=iIdDelegado;
            this.ParamNuevaFecha = DateTime.MinValue;  // Nueva Fecha del Report, sólo se usa para el paso de planificación a visita y cuando la llamada es desde Planificación        
        }

        //---- GSG (17/06/2016)
        public frmReporting(string TipoAcceso, int IdReport, DateTime Fecha, int iIdDelegado, DateTime nuevaFecha)
        {
            InitializeComponent();

            //---- GSG (06/03/2021)
            Utiles.GetConfigConnection();
            this.sqlConn.ConnectionString = Utiles._connection.ConnectionString.ToString();

           

            this.ParamTipoAcceso = TipoAcceso;//A-> Alta; M->Modificación; C->Consulta
            this.ParamIdReport = IdReport;  // Identificador del Report
            this.ParamFecha = Fecha;            // Fecha del Report, sólo se usa para el alta y cuando la llamada es desde Planificación			
            this.ParamiIdDelegado = iIdDelegado;
            this.ParamNuevaFecha = nuevaFecha;  // Nueva Fecha del Report, sólo se usa para el paso de planificación a visita y cuando la llamada es desde Planificación
        }


        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Método necesario para admitir el Diseñador, no se puede modificar
		/// el contenido del método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReporting));
            System.Configuration.AppSettingsReader configurationAppSettings = new System.Configuration.AppSettingsReader();
            this.pnReportActiv = new System.Windows.Forms.Panel();
            this.dtpHoraFin = new System.Windows.Forms.DateTimePicker();
            this.dtpHoraInicio = new System.Windows.Forms.DateTimePicker();
            this.txbHoraFin = new System.Windows.Forms.TextBox();
            this.txbHoraInicio = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblReporting = new GESTCRM.Controles.LabelGradient();
            this.lblProxObj = new System.Windows.Forms.Label();
            this.lblObjetivo = new System.Windows.Forms.Label();
            this.txtsDelegado = new System.Windows.Forms.TextBox();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.cbTipoCliente = new System.Windows.Forms.ComboBox();
            this.dsReports1 = new GESTCRM.Formularios.DataSets.dsReports();
            this.cbTipoRActibidad = new System.Windows.Forms.ComboBox();
            this.cbHorario = new System.Windows.Forms.ComboBox();
            this.txbObservaciones = new System.Windows.Forms.TextBox();
            this.txtProxObjetivo = new System.Windows.Forms.TextBox();
            this.txbObjetivo = new System.Windows.Forms.TextBox();
            this.lblDelegado = new System.Windows.Forms.Label();
            this.lblHorario = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblTipoCliente = new System.Windows.Forms.Label();
            this.lblTipoRActividad = new System.Windows.Forms.Label();
            this.lblObservaciones = new System.Windows.Forms.Label();
            this.btBuscarCliente = new System.Windows.Forms.Button();
            this.txtsCliente = new System.Windows.Forms.TextBox();
            this.txtsCentro = new System.Windows.Forms.TextBox();
            this.btBuscarCentro = new System.Windows.Forms.Button();
            this.dgClientes = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle3 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn8 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn9 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn12 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn13 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn14 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn15 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn16 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn17 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn31 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.lblCentro = new System.Windows.Forms.Label();
            this.txtsIdCentro = new System.Windows.Forms.TextBox();
            this.txtClienteSAP = new System.Windows.Forms.TextBox();
            this.btClienteActualizar = new System.Windows.Forms.Button();
            this.btClienteEliminar = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.sqlConn = new System.Data.SqlClient.SqlConnection();
            this.sqldaTipoRActividad = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
            this.sqldaTipoCliente = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
            this.sqldaTipoHorarioRep = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand4 = new System.Data.SqlClient.SqlCommand();
            this.pnPedidos = new System.Windows.Forms.Panel();
            this.dgPedidos = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle5 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn11 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn24 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn25 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn32 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btPedActualizar = new System.Windows.Forms.Button();
            this.btNuevoPedido = new System.Windows.Forms.Button();
            this.cbPedidos = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btPedEliminar = new System.Windows.Forms.Button();
            this.listaPromocionProdBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.sqldaListaPromocionProd = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand5 = new System.Data.SqlClient.SqlCommand();
            this.sqldaListaRepActProductos = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand6 = new System.Data.SqlClient.SqlCommand();
            this.sqldaListaBuscarProductos = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCmdBuscarProductos = new System.Data.SqlClient.SqlCommand();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btVerCentro = new System.Windows.Forms.Button();
            this.btGadgetEliminar = new System.Windows.Forms.Button();
            this.btGadgetActualizar = new System.Windows.Forms.Button();
            this.btAtenEliminar = new System.Windows.Forms.Button();
            this.btAtenActualizar = new System.Windows.Forms.Button();
            this.btBuscarAtencion = new System.Windows.Forms.Button();
            this.btBuscarProducto = new System.Windows.Forms.Button();
            this.btBorrarProd = new System.Windows.Forms.Button();
            this.btModifProd = new System.Windows.Forms.Button();
            this.btAceptarProdsPromo = new System.Windows.Forms.Button();
            this.sqlcomdGetRepActividadCab = new System.Data.SqlClient.SqlCommand();
            this.sqldaCentroClienteCOM = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand10 = new System.Data.SqlClient.SqlCommand();
            this.sqldaRepActClientes = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand9 = new System.Data.SqlClient.SqlCommand();
            this.sqldaRepActGadgets = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand12 = new System.Data.SqlClient.SqlCommand();
            this.pnClientesVisitados = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.lblToolTipBoton = new System.Windows.Forms.Label();
            this.lblTotClientes = new System.Windows.Forms.Label();
            this.labelGradient6 = new GESTCRM.Controles.LabelGradient();
            this.pnDatosClientesPlanif = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.dgClientesProxObj = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle6 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn26 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn27 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn28 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn29 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn30 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.lblTotProxObj = new System.Windows.Forms.Label();
            this.labelGradient2 = new GESTCRM.Controles.LabelGradient();
            this.pnDatosClienteVisita = new System.Windows.Forms.Panel();
            this.pnProductosProm = new System.Windows.Forms.Panel();
            this.pnAceptarPromo = new System.Windows.Forms.Panel();
            this.lblActProdProm = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dGVProductosPromo = new System.Windows.Forms.DataGridView();
            this.dgProductos = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.lblTotProductos = new System.Windows.Forms.Label();
            this.labelGradient1 = new GESTCRM.Controles.LabelGradient();
            this.pnProductos = new System.Windows.Forms.Panel();
            this.txtsProducto = new System.Windows.Forms.TextBox();
            this.txtsIdProducto = new System.Windows.Forms.TextBox();
            this.nudiMuestras = new System.Windows.Forms.NumericUpDown();
            this.nudiOrden = new System.Windows.Forms.NumericUpDown();
            this.lblProducto = new System.Windows.Forms.Label();
            this.lblOrdeb = new System.Windows.Forms.Label();
            this.lbliMuestras = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtsIdAtencion = new System.Windows.Forms.TextBox();
            this.nupImporteCli = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtfImportePrev = new System.Windows.Forms.Label();
            this.txtTipoAtencion = new System.Windows.Forms.Label();
            this.pnTodaAtencion = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.dgAtenciones = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle4 = new System.Windows.Forms.DataGridTableStyle();
            this.lblTotAtenciones = new System.Windows.Forms.Label();
            this.labelGradient4 = new GESTCRM.Controles.LabelGradient();
            this.panel7 = new System.Windows.Forms.Panel();
            this.dgGadgets = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
            this.lblTotGadgets = new System.Windows.Forms.Label();
            this.labelGradient3 = new GESTCRM.Controles.LabelGradient();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btBuscarGadget = new System.Windows.Forms.Button();
            this.txtsGadget = new System.Windows.Forms.TextBox();
            this.nudCantidadGad = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.lblToolTipBtPed = new System.Windows.Forms.Label();
            this.lblTotPedidos = new System.Windows.Forms.Label();
            this.labelGradient5 = new GESTCRM.Controles.LabelGradient();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbSustituto = new System.Windows.Forms.CheckBox();
            this.txtClienteObserv = new System.Windows.Forms.TextBox();
            this.txtClienteObjetivo = new System.Windows.Forms.TextBox();
            this.txtClienteProxObj = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.sqldaRepActAtenciones = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqldaRepActPedidos = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand7 = new System.Data.SqlClient.SqlCommand();
            this.sqldaPedidosAsignables = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand8 = new System.Data.SqlClient.SqlCommand();
            this.sqlcmdSetRepActividad_Cab = new System.Data.SqlClient.SqlCommand();
            this.sqlcmdSetRepActividad_Cli = new System.Data.SqlClient.SqlCommand();
            this.sqlcmdSetRepActividad_Aten = new System.Data.SqlClient.SqlCommand();
            this.sqlcmdSetRepActividad_Ped = new System.Data.SqlClient.SqlCommand();
            this.sqlcmdSetRepActividad_Gad = new System.Data.SqlClient.SqlCommand();
            this.sqlcmdSetRepActividad_Prom = new System.Data.SqlClient.SqlCommand();
            this.cmClientes = new System.Windows.Forms.ContextMenu();
            this.mnNuevoCli = new System.Windows.Forms.MenuItem();
            this.mnEliminarCli = new System.Windows.Forms.MenuItem();
            this.sqlcmdSetRepActividadCli_ProxObj = new System.Data.SqlClient.SqlCommand();
            this.sqldaListaRepActividadCli_ProxObj = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand11 = new System.Data.SqlClient.SqlCommand();
            this.ucBotoneraSecundaria1 = new GESTCRM.Controles.ucBotoneraSecundaria();
            this.sqlcomdSetRepActividad_ImporteReal_Aten = new System.Data.SqlClient.SqlCommand();
            this.cmGadgets = new System.Windows.Forms.ContextMenu();
            this.mnNuevoGad = new System.Windows.Forms.MenuItem();
            this.mnEliminarGad = new System.Windows.Forms.MenuItem();
            this.cmAtenciones = new System.Windows.Forms.ContextMenu();
            this.mnNuevoAten = new System.Windows.Forms.MenuItem();
            this.mnEliminarAten = new System.Windows.Forms.MenuItem();
            this.cmPedidos = new System.Windows.Forms.ContextMenu();
            this.mnNuevoPed = new System.Windows.Forms.MenuItem();
            this.mnEliminarPed = new System.Windows.Forms.MenuItem();
            this.cmProductos = new System.Windows.Forms.ContextMenu();
            this.mnNuevoProd = new System.Windows.Forms.MenuItem();
            this.mnEliminarProd = new System.Windows.Forms.MenuItem();
            this.dsBuscar1 = new GESTCRM.Formularios.Busquedas.dsBuscar();
            this.listaBuscarProductosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.listaPromocionProdBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn7 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn36 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn35 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn23 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn22 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn21 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn20 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn34 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn33 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn10 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dtgsSelected = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dtgiIdCliente = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dtgsProducto = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dtgCant = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dtgOrden = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dtgsDescripcion = new System.Windows.Forms.DataGridTextBoxColumn();
            this.btEncuestas = new System.Windows.Forms.Button();
            this.pnReportActiv.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsReports1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgClientes)).BeginInit();
            this.pnPedidos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPedidos)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listaPromocionProdBindingSource1)).BeginInit();
            this.pnClientesVisitados.SuspendLayout();
            this.panel10.SuspendLayout();
            this.pnDatosClientesPlanif.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgClientesProxObj)).BeginInit();
            this.pnDatosClienteVisita.SuspendLayout();
            this.pnProductosProm.SuspendLayout();
            this.pnAceptarPromo.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVProductosPromo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgProductos)).BeginInit();
            this.pnProductos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudiMuestras)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudiOrden)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupImporteCli)).BeginInit();
            this.pnTodaAtencion.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgAtenciones)).BeginInit();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgGadgets)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidadGad)).BeginInit();
            this.panel9.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsBuscar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listaBuscarProductosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listaPromocionProdBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // pnReportActiv
            // 
            this.pnReportActiv.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnReportActiv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnReportActiv.Controls.Add(this.dtpHoraFin);
            this.pnReportActiv.Controls.Add(this.dtpHoraInicio);
            this.pnReportActiv.Controls.Add(this.txbHoraFin);
            this.pnReportActiv.Controls.Add(this.txbHoraInicio);
            this.pnReportActiv.Controls.Add(this.label13);
            this.pnReportActiv.Controls.Add(this.label12);
            this.pnReportActiv.Controls.Add(this.lblReporting);
            this.pnReportActiv.Controls.Add(this.lblProxObj);
            this.pnReportActiv.Controls.Add(this.lblObjetivo);
            this.pnReportActiv.Controls.Add(this.txtsDelegado);
            this.pnReportActiv.Controls.Add(this.dtpFecha);
            this.pnReportActiv.Controls.Add(this.cbTipoCliente);
            this.pnReportActiv.Controls.Add(this.cbTipoRActibidad);
            this.pnReportActiv.Controls.Add(this.cbHorario);
            this.pnReportActiv.Controls.Add(this.txbObservaciones);
            this.pnReportActiv.Controls.Add(this.txtProxObjetivo);
            this.pnReportActiv.Controls.Add(this.txbObjetivo);
            this.pnReportActiv.Controls.Add(this.lblDelegado);
            this.pnReportActiv.Controls.Add(this.lblHorario);
            this.pnReportActiv.Controls.Add(this.lblFecha);
            this.pnReportActiv.Controls.Add(this.lblTipoCliente);
            this.pnReportActiv.Controls.Add(this.lblTipoRActividad);
            this.pnReportActiv.Controls.Add(this.lblObservaciones);
            this.pnReportActiv.Location = new System.Drawing.Point(2, 38);
            this.pnReportActiv.Name = "pnReportActiv";
            this.pnReportActiv.Size = new System.Drawing.Size(1534, 140);
            this.pnReportActiv.TabIndex = 0;
            // 
            // dtpHoraFin
            // 
            this.dtpHoraFin.CustomFormat = "HH:mm";
            this.dtpHoraFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpHoraFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHoraFin.Location = new System.Drawing.Point(702, 3);
            this.dtpHoraFin.Name = "dtpHoraFin";
            this.dtpHoraFin.ShowUpDown = true;
            this.dtpHoraFin.Size = new System.Drawing.Size(50, 22);
            this.dtpHoraFin.TabIndex = 68;
            this.dtpHoraFin.Visible = false;
            this.dtpHoraFin.Leave += new System.EventHandler(this.dtpHoraFin_Leave);
            this.dtpHoraFin.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.dtpHoraFin_PreviewKeyDown);
            // 
            // dtpHoraInicio
            // 
            this.dtpHoraInicio.CustomFormat = "HH:mm";
            this.dtpHoraInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpHoraInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHoraInicio.Location = new System.Drawing.Point(648, 3);
            this.dtpHoraInicio.Name = "dtpHoraInicio";
            this.dtpHoraInicio.ShowUpDown = true;
            this.dtpHoraInicio.Size = new System.Drawing.Size(49, 22);
            this.dtpHoraInicio.TabIndex = 6;
            this.dtpHoraInicio.Visible = false;
            this.dtpHoraInicio.Leave += new System.EventHandler(this.dtpHoraInicio_Leave);
            this.dtpHoraInicio.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.dtpHoraInicio_PreviewKeyDown);
            // 
            // txbHoraFin
            // 
            this.txbHoraFin.BackColor = System.Drawing.Color.White;
            this.txbHoraFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbHoraFin.ForeColor = System.Drawing.Color.Black;
            this.txbHoraFin.Location = new System.Drawing.Point(1253, 89);
            this.txbHoraFin.MaxLength = 20;
            this.txbHoraFin.Name = "txbHoraFin";
            this.txbHoraFin.Size = new System.Drawing.Size(87, 26);
            this.txbHoraFin.TabIndex = 71;
            this.txbHoraFin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txbHoraFin.Enter += new System.EventHandler(this.txbHoraFin_Enter);
            // 
            // txbHoraInicio
            // 
            this.txbHoraInicio.BackColor = System.Drawing.Color.White;
            this.txbHoraInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbHoraInicio.ForeColor = System.Drawing.Color.Black;
            this.txbHoraInicio.Location = new System.Drawing.Point(1120, 89);
            this.txbHoraInicio.MaxLength = 20;
            this.txbHoraInicio.Name = "txbHoraInicio";
            this.txbHoraInicio.Size = new System.Drawing.Size(87, 26);
            this.txbHoraInicio.TabIndex = 70;
            this.txbHoraInicio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txbHoraInicio.Enter += new System.EventHandler(this.txbHoraInicio_Enter);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(1218, 92);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 20);
            this.label13.TabIndex = 69;
            this.label13.Text = "Fin:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(1066, 91);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(50, 20);
            this.label12.TabIndex = 67;
            this.label12.Text = "Inicio:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblReporting
            // 
            this.lblReporting.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblReporting.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReporting.ForeColor = System.Drawing.Color.White;
            this.lblReporting.GradientColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.lblReporting.GradientColorTwo = System.Drawing.Color.White;
            this.lblReporting.Location = new System.Drawing.Point(0, 0);
            this.lblReporting.Name = "lblReporting";
            this.lblReporting.Size = new System.Drawing.Size(1532, 22);
            this.lblReporting.TabIndex = 66;
            this.lblReporting.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblProxObj
            // 
            this.lblProxObj.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblProxObj.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProxObj.ForeColor = System.Drawing.Color.Black;
            this.lblProxObj.Location = new System.Drawing.Point(636, 70);
            this.lblProxObj.Name = "lblProxObj";
            this.lblProxObj.Size = new System.Drawing.Size(98, 16);
            this.lblProxObj.TabIndex = 43;
            this.lblProxObj.Text = "Próx. Objetivo";
            this.lblProxObj.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblObjetivo
            // 
            this.lblObjetivo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblObjetivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblObjetivo.ForeColor = System.Drawing.Color.Black;
            this.lblObjetivo.Location = new System.Drawing.Point(346, 68);
            this.lblObjetivo.Name = "lblObjetivo";
            this.lblObjetivo.Size = new System.Drawing.Size(119, 18);
            this.lblObjetivo.TabIndex = 41;
            this.lblObjetivo.Text = "Objetivo";
            this.lblObjetivo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtsDelegado
            // 
            this.txtsDelegado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtsDelegado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsDelegado.ForeColor = System.Drawing.Color.Black;
            this.txtsDelegado.Location = new System.Drawing.Point(87, 33);
            this.txtsDelegado.Name = "txtsDelegado";
            this.txtsDelegado.ReadOnly = true;
            this.txtsDelegado.Size = new System.Drawing.Size(364, 26);
            this.txtsDelegado.TabIndex = 0;
            this.txtsDelegado.TabStop = false;
            // 
            // dtpFecha
            // 
            this.dtpFecha.CalendarForeColor = System.Drawing.Color.Black;
            this.dtpFecha.CalendarMonthBackground = System.Drawing.Color.White;
            this.dtpFecha.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.dtpFecha.CalendarTitleForeColor = System.Drawing.Color.White;
            this.dtpFecha.CalendarTrailingForeColor = System.Drawing.Color.Gray;
            this.dtpFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecha.Location = new System.Drawing.Point(520, 33);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(291, 26);
            this.dtpFecha.TabIndex = 1;
            this.dtpFecha.ValueChanged += new System.EventHandler(this.dtpFecha_ValueChanged);
            // 
            // cbTipoCliente
            // 
            this.cbTipoCliente.BackColor = System.Drawing.Color.White;
            this.cbTipoCliente.DataSource = this.dsReports1.ListaTipoCliente;
            this.cbTipoCliente.DisplayMember = "sLiteral";
            this.cbTipoCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoCliente.Enabled = false;
            this.cbTipoCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTipoCliente.ForeColor = System.Drawing.Color.Black;
            this.cbTipoCliente.Location = new System.Drawing.Point(1177, 33);
            this.cbTipoCliente.Name = "cbTipoCliente";
            this.cbTipoCliente.Size = new System.Drawing.Size(124, 28);
            this.cbTipoCliente.TabIndex = 3;
            this.cbTipoCliente.ValueMember = "sValor";
            this.cbTipoCliente.SelectedIndexChanged += new System.EventHandler(this.cbTipoCliente_SelectedIndexChanged);
            this.cbTipoCliente.Leave += new System.EventHandler(this.cbTipoCliente_Leave);
            // 
            // dsReports1
            // 
            this.dsReports1.DataSetName = "dsReports";
            this.dsReports1.Locale = new System.Globalization.CultureInfo("en-US");
            this.dsReports1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cbTipoRActibidad
            // 
            this.cbTipoRActibidad.BackColor = System.Drawing.Color.White;
            this.cbTipoRActibidad.DataSource = this.dsReports1.ListaTipoRActividad;
            this.cbTipoRActibidad.DisplayMember = "sLiteral";
            this.cbTipoRActibidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoRActibidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTipoRActibidad.ForeColor = System.Drawing.Color.Black;
            this.cbTipoRActibidad.Location = new System.Drawing.Point(935, 33);
            this.cbTipoRActibidad.Name = "cbTipoRActibidad";
            this.cbTipoRActibidad.Size = new System.Drawing.Size(124, 28);
            this.cbTipoRActibidad.TabIndex = 2;
            this.cbTipoRActibidad.ValueMember = "sValor";
            this.cbTipoRActibidad.SelectedIndexChanged += new System.EventHandler(this.cbTipoRActibidad_SelectedIndexChanged);
            this.cbTipoRActibidad.Leave += new System.EventHandler(this.cbTipoRActibidad_Leave);
            // 
            // cbHorario
            // 
            this.cbHorario.BackColor = System.Drawing.Color.White;
            this.cbHorario.DataSource = this.dsReports1.ListaTipoHorarioRep;
            this.cbHorario.DisplayMember = "sLiteral";
            this.cbHorario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHorario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbHorario.ForeColor = System.Drawing.Color.Black;
            this.cbHorario.Location = new System.Drawing.Point(1392, 33);
            this.cbHorario.Name = "cbHorario";
            this.cbHorario.Size = new System.Drawing.Size(124, 28);
            this.cbHorario.TabIndex = 4;
            this.cbHorario.ValueMember = "sValor";
            this.cbHorario.Visible = false;
            this.cbHorario.Leave += new System.EventHandler(this.cbHorario_Leave);
            // 
            // txbObservaciones
            // 
            this.txbObservaciones.BackColor = System.Drawing.Color.White;
            this.txbObservaciones.ForeColor = System.Drawing.Color.Black;
            this.txbObservaciones.Location = new System.Drawing.Point(7, 86);
            this.txbObservaciones.MaxLength = 8000;
            this.txbObservaciones.Multiline = true;
            this.txbObservaciones.Name = "txbObservaciones";
            this.txbObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txbObservaciones.Size = new System.Drawing.Size(333, 50);
            this.txbObservaciones.TabIndex = 5;
            // 
            // txtProxObjetivo
            // 
            this.txtProxObjetivo.BackColor = System.Drawing.Color.White;
            this.txtProxObjetivo.ForeColor = System.Drawing.Color.Black;
            this.txtProxObjetivo.Location = new System.Drawing.Point(634, 86);
            this.txtProxObjetivo.MaxLength = 8000;
            this.txtProxObjetivo.Multiline = true;
            this.txtProxObjetivo.Name = "txtProxObjetivo";
            this.txtProxObjetivo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtProxObjetivo.Size = new System.Drawing.Size(279, 50);
            this.txtProxObjetivo.TabIndex = 7;
            // 
            // txbObjetivo
            // 
            this.txbObjetivo.BackColor = System.Drawing.Color.White;
            this.txbObjetivo.ForeColor = System.Drawing.Color.Black;
            this.txbObjetivo.Location = new System.Drawing.Point(347, 86);
            this.txbObjetivo.MaxLength = 8000;
            this.txbObjetivo.Multiline = true;
            this.txbObjetivo.Name = "txbObjetivo";
            this.txbObjetivo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txbObjetivo.Size = new System.Drawing.Size(279, 50);
            this.txbObjetivo.TabIndex = 6;
            // 
            // lblDelegado
            // 
            this.lblDelegado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDelegado.ForeColor = System.Drawing.Color.Black;
            this.lblDelegado.Location = new System.Drawing.Point(5, 33);
            this.lblDelegado.Name = "lblDelegado";
            this.lblDelegado.Size = new System.Drawing.Size(85, 21);
            this.lblDelegado.TabIndex = 65;
            this.lblDelegado.Text = "Delegado:";
            this.lblDelegado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblHorario
            // 
            this.lblHorario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHorario.ForeColor = System.Drawing.Color.Black;
            this.lblHorario.Location = new System.Drawing.Point(1327, 33);
            this.lblHorario.Name = "lblHorario";
            this.lblHorario.Size = new System.Drawing.Size(65, 21);
            this.lblHorario.TabIndex = 64;
            this.lblHorario.Text = "Horario:";
            this.lblHorario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblHorario.Visible = false;
            // 
            // lblFecha
            // 
            this.lblFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.ForeColor = System.Drawing.Color.Black;
            this.lblFecha.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblFecha.Location = new System.Drawing.Point(460, 33);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(58, 21);
            this.lblFecha.TabIndex = 63;
            this.lblFecha.Text = "Fecha:";
            this.lblFecha.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTipoCliente
            // 
            this.lblTipoCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoCliente.ForeColor = System.Drawing.Color.Black;
            this.lblTipoCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTipoCliente.Location = new System.Drawing.Point(1082, 33);
            this.lblTipoCliente.Name = "lblTipoCliente";
            this.lblTipoCliente.Size = new System.Drawing.Size(96, 21);
            this.lblTipoCliente.TabIndex = 61;
            this.lblTipoCliente.Text = "Tipo Cliente:";
            this.lblTipoCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTipoRActividad
            // 
            this.lblTipoRActividad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoRActividad.ForeColor = System.Drawing.Color.Black;
            this.lblTipoRActividad.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTipoRActividad.Location = new System.Drawing.Point(840, 33);
            this.lblTipoRActividad.Name = "lblTipoRActividad";
            this.lblTipoRActividad.Size = new System.Drawing.Size(96, 21);
            this.lblTipoRActividad.TabIndex = 59;
            this.lblTipoRActividad.Text = "Tipo Report:";
            this.lblTipoRActividad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblObservaciones
            // 
            this.lblObservaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblObservaciones.ForeColor = System.Drawing.Color.Black;
            this.lblObservaciones.Location = new System.Drawing.Point(4, 67);
            this.lblObservaciones.Name = "lblObservaciones";
            this.lblObservaciones.Size = new System.Drawing.Size(136, 18);
            this.lblObservaciones.TabIndex = 47;
            this.lblObservaciones.Text = "Observaciones";
            this.lblObservaciones.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btBuscarCliente
            // 
            this.btBuscarCliente.Image = ((System.Drawing.Image)(resources.GetObject("btBuscarCliente.Image")));
            this.btBuscarCliente.Location = new System.Drawing.Point(508, 10);
            this.btBuscarCliente.Name = "btBuscarCliente";
            this.btBuscarCliente.Size = new System.Drawing.Size(28, 28);
            this.btBuscarCliente.TabIndex = 9;
            this.btBuscarCliente.TabStop = false;
            this.toolTip1.SetToolTip(this.btBuscarCliente, "Buscar Cliente");
            this.btBuscarCliente.UseVisualStyleBackColor = true;
            this.btBuscarCliente.Click += new System.EventHandler(this.btBuscarCliente_Click);
            // 
            // txtsCliente
            // 
            this.txtsCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtsCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsCliente.ForeColor = System.Drawing.Color.Black;
            this.txtsCliente.Location = new System.Drawing.Point(220, 10);
            this.txtsCliente.Name = "txtsCliente";
            this.txtsCliente.ReadOnly = true;
            this.txtsCliente.Size = new System.Drawing.Size(290, 26);
            this.txtsCliente.TabIndex = 8;
            this.txtsCliente.TabStop = false;
            // 
            // txtsCentro
            // 
            this.txtsCentro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtsCentro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsCentro.ForeColor = System.Drawing.Color.Black;
            this.txtsCentro.Location = new System.Drawing.Point(842, 11);
            this.txtsCentro.Name = "txtsCentro";
            this.txtsCentro.ReadOnly = true;
            this.txtsCentro.Size = new System.Drawing.Size(290, 26);
            this.txtsCentro.TabIndex = 2;
            this.txtsCentro.TabStop = false;
            // 
            // btBuscarCentro
            // 
            this.btBuscarCentro.Image = ((System.Drawing.Image)(resources.GetObject("btBuscarCentro.Image")));
            this.btBuscarCentro.Location = new System.Drawing.Point(1131, 10);
            this.btBuscarCentro.Name = "btBuscarCentro";
            this.btBuscarCentro.Size = new System.Drawing.Size(28, 28);
            this.btBuscarCentro.TabIndex = 3;
            this.btBuscarCentro.TabStop = false;
            this.toolTip1.SetToolTip(this.btBuscarCentro, "Buscar Centro");
            this.btBuscarCentro.UseVisualStyleBackColor = true;
            this.btBuscarCentro.Click += new System.EventHandler(this.btBuscarCentro_Click);
            // 
            // dgClientes
            // 
            this.dgClientes.AllowSorting = false;
            this.dgClientes.BackgroundColor = System.Drawing.Color.White;
            this.dgClientes.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.dgClientes.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgClientes.CaptionText = "Clientes Visitados";
            this.dgClientes.CaptionVisible = false;
            this.dgClientes.DataMember = "";
            this.dgClientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgClientes.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgClientes.Location = new System.Drawing.Point(0, 20);
            this.dgClientes.Name = "dgClientes";
            this.dgClientes.ReadOnly = true;
            this.dgClientes.RowHeaderWidth = 15;
            this.dgClientes.Size = new System.Drawing.Size(609, 255);
            this.dgClientes.TabIndex = 0;
            this.dgClientes.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle3});
            this.dgClientes.CurrentCellChanged += new System.EventHandler(this.dgClientes_CurrentCellChanged);
            this.dgClientes.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dgClientes_MouseMove);
            // 
            // dataGridTableStyle3
            // 
            this.dataGridTableStyle3.AllowSorting = false;
            this.dataGridTableStyle3.DataGrid = this.dgClientes;
            this.dataGridTableStyle3.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn8,
            this.dataGridTextBoxColumn9,
            this.dataGridTextBoxColumn12,
            this.dataGridTextBoxColumn13,
            this.dataGridTextBoxColumn14,
            this.dataGridTextBoxColumn15,
            this.dataGridTextBoxColumn16,
            this.dataGridTextBoxColumn17,
            this.dataGridTextBoxColumn31});
            this.dataGridTableStyle3.HeaderBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridTableStyle3.HeaderForeColor = System.Drawing.Color.Black;
            this.dataGridTableStyle3.RowHeaderWidth = 15;
            // 
            // dataGridTextBoxColumn8
            // 
            this.dataGridTextBoxColumn8.Format = "";
            this.dataGridTextBoxColumn8.FormatInfo = null;
            this.dataGridTextBoxColumn8.HeaderText = "Código";
            this.dataGridTextBoxColumn8.MappingName = "sIdCliente";
            this.dataGridTextBoxColumn8.NullText = "";
            this.dataGridTextBoxColumn8.Width = 110;
            // 
            // dataGridTextBoxColumn9
            // 
            this.dataGridTextBoxColumn9.Format = "";
            this.dataGridTextBoxColumn9.FormatInfo = null;
            this.dataGridTextBoxColumn9.HeaderText = "Nombre";
            this.dataGridTextBoxColumn9.MappingName = "sNombre";
            this.dataGridTextBoxColumn9.NullText = "";
            this.dataGridTextBoxColumn9.Width = 420;
            // 
            // dataGridTextBoxColumn12
            // 
            this.dataGridTextBoxColumn12.Format = "";
            this.dataGridTextBoxColumn12.FormatInfo = null;
            this.dataGridTextBoxColumn12.MappingName = "iIdCliente";
            this.dataGridTextBoxColumn12.Width = 0;
            // 
            // dataGridTextBoxColumn13
            // 
            this.dataGridTextBoxColumn13.Format = "";
            this.dataGridTextBoxColumn13.FormatInfo = null;
            this.dataGridTextBoxColumn13.HeaderText = "Sust.";
            this.dataGridTextBoxColumn13.MappingName = "tSustituto";
            this.dataGridTextBoxColumn13.NullText = "";
            this.dataGridTextBoxColumn13.Width = 0;
            // 
            // dataGridTextBoxColumn14
            // 
            this.dataGridTextBoxColumn14.Format = "";
            this.dataGridTextBoxColumn14.FormatInfo = null;
            this.dataGridTextBoxColumn14.MappingName = "bSustituto";
            this.dataGridTextBoxColumn14.NullText = "";
            this.dataGridTextBoxColumn14.Width = 0;
            // 
            // dataGridTextBoxColumn15
            // 
            this.dataGridTextBoxColumn15.Format = "";
            this.dataGridTextBoxColumn15.FormatInfo = null;
            this.dataGridTextBoxColumn15.MappingName = "tObservaciones";
            this.dataGridTextBoxColumn15.NullText = "";
            this.dataGridTextBoxColumn15.Width = 0;
            // 
            // dataGridTextBoxColumn16
            // 
            this.dataGridTextBoxColumn16.Format = "";
            this.dataGridTextBoxColumn16.FormatInfo = null;
            this.dataGridTextBoxColumn16.MappingName = "tObjetivos";
            this.dataGridTextBoxColumn16.NullText = "";
            this.dataGridTextBoxColumn16.Width = 0;
            // 
            // dataGridTextBoxColumn17
            // 
            this.dataGridTextBoxColumn17.Format = "";
            this.dataGridTextBoxColumn17.FormatInfo = null;
            this.dataGridTextBoxColumn17.MappingName = "tProxObj";
            this.dataGridTextBoxColumn17.NullText = "";
            this.dataGridTextBoxColumn17.Width = 0;
            // 
            // dataGridTextBoxColumn31
            // 
            this.dataGridTextBoxColumn31.Format = "";
            this.dataGridTextBoxColumn31.FormatInfo = null;
            this.dataGridTextBoxColumn31.MappingName = "Boton";
            this.dataGridTextBoxColumn31.NullText = "";
            this.dataGridTextBoxColumn31.Width = 75;
            // 
            // lblCentro
            // 
            this.lblCentro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCentro.ForeColor = System.Drawing.Color.Black;
            this.lblCentro.Location = new System.Drawing.Point(626, 13);
            this.lblCentro.Name = "lblCentro";
            this.lblCentro.Size = new System.Drawing.Size(78, 20);
            this.lblCentro.TabIndex = 0;
            this.lblCentro.Text = "Centro:";
            this.lblCentro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtsIdCentro
            // 
            this.txtsIdCentro.BackColor = System.Drawing.Color.White;
            this.txtsIdCentro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsIdCentro.ForeColor = System.Drawing.Color.Black;
            this.txtsIdCentro.Location = new System.Drawing.Point(689, 11);
            this.txtsIdCentro.MaxLength = 20;
            this.txtsIdCentro.Name = "txtsIdCentro";
            this.txtsIdCentro.Size = new System.Drawing.Size(149, 26);
            this.txtsIdCentro.TabIndex = 0;
            this.txtsIdCentro.Leave += new System.EventHandler(this.txtsIdCentro_Leave);
            // 
            // txtClienteSAP
            // 
            this.txtClienteSAP.BackColor = System.Drawing.Color.White;
            this.txtClienteSAP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClienteSAP.ForeColor = System.Drawing.Color.Black;
            this.txtClienteSAP.Location = new System.Drawing.Point(68, 10);
            this.txtClienteSAP.MaxLength = 20;
            this.txtClienteSAP.Name = "txtClienteSAP";
            this.txtClienteSAP.Size = new System.Drawing.Size(149, 26);
            this.txtClienteSAP.TabIndex = 0;
            this.txtClienteSAP.Leave += new System.EventHandler(this.txtClienteSAP_Leave);
            // 
            // btClienteActualizar
            // 
            this.btClienteActualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btClienteActualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btClienteActualizar.ForeColor = System.Drawing.Color.Black;
            this.btClienteActualizar.Image = ((System.Drawing.Image)(resources.GetObject("btClienteActualizar.Image")));
            this.btClienteActualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btClienteActualizar.Location = new System.Drawing.Point(753, 102);
            this.btClienteActualizar.Name = "btClienteActualizar";
            this.btClienteActualizar.Size = new System.Drawing.Size(109, 32);
            this.btClienteActualizar.TabIndex = 3;
            this.btClienteActualizar.Text = "&Actualizar";
            this.btClienteActualizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.btClienteActualizar, "Actualizar Cliente ALT+A");
            this.btClienteActualizar.UseVisualStyleBackColor = true;
            this.btClienteActualizar.Click += new System.EventHandler(this.btClienteActualizar_Click);
            // 
            // btClienteEliminar
            // 
            this.btClienteEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btClienteEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btClienteEliminar.ForeColor = System.Drawing.Color.Black;
            this.btClienteEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btClienteEliminar.Image")));
            this.btClienteEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btClienteEliminar.Location = new System.Drawing.Point(753, 147);
            this.btClienteEliminar.Name = "btClienteEliminar";
            this.btClienteEliminar.Size = new System.Drawing.Size(109, 32);
            this.btClienteEliminar.TabIndex = 4;
            this.btClienteEliminar.Text = "&Eliminar";
            this.btClienteEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.btClienteEliminar, "Eliminar Cliente ALT+E");
            this.btClienteEliminar.UseVisualStyleBackColor = true;
            this.btClienteEliminar.Click += new System.EventHandler(this.btClienteEliminar_Click);
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(6, 13);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 20);
            this.label9.TabIndex = 9;
            this.label9.Text = "Cliente:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            // 
            // sqlConn
            // 
            this.sqlConn.ConnectionString = Utiles._connection.ConnectionString.ToString();
            this.sqlConn.FireInfoMessageEventOnUserErrors = false;
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
            // pnPedidos
            // 
            this.pnPedidos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnPedidos.Controls.Add(this.dgPedidos);
            this.pnPedidos.Location = new System.Drawing.Point(2, 18);
            this.pnPedidos.Name = "pnPedidos";
            this.pnPedidos.Size = new System.Drawing.Size(320, 157);
            this.pnPedidos.TabIndex = 8;
            // 
            // dgPedidos
            // 
            this.dgPedidos.AllowSorting = false;
            this.dgPedidos.BackgroundColor = System.Drawing.Color.White;
            this.dgPedidos.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.dgPedidos.CaptionText = "Pedidos Asociadosa  un Cliente";
            this.dgPedidos.CaptionVisible = false;
            this.dgPedidos.DataMember = "";
            this.dgPedidos.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgPedidos.Location = new System.Drawing.Point(-1, 2);
            this.dgPedidos.Name = "dgPedidos";
            this.dgPedidos.ReadOnly = true;
            this.dgPedidos.RowHeaderWidth = 15;
            this.dgPedidos.Size = new System.Drawing.Size(319, 151);
            this.dgPedidos.TabIndex = 0;
            this.dgPedidos.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle5});
            this.dgPedidos.CurrentCellChanged += new System.EventHandler(this.dgPedidos_CurrentCellChanged);
            this.dgPedidos.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dgPedidos_MouseMove);
            // 
            // dataGridTableStyle5
            // 
            this.dataGridTableStyle5.AllowSorting = false;
            this.dataGridTableStyle5.DataGrid = this.dgPedidos;
            this.dataGridTableStyle5.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn11,
            this.dataGridTextBoxColumn24,
            this.dataGridTextBoxColumn25,
            this.dataGridTextBoxColumn32});
            this.dataGridTableStyle5.HeaderBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridTableStyle5.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle5.RowHeaderWidth = 15;
            // 
            // dataGridTextBoxColumn11
            // 
            this.dataGridTextBoxColumn11.Format = "";
            this.dataGridTextBoxColumn11.FormatInfo = null;
            this.dataGridTextBoxColumn11.HeaderText = "Código";
            this.dataGridTextBoxColumn11.MappingName = "sIdPedido";
            this.dataGridTextBoxColumn11.Width = 120;
            // 
            // dataGridTextBoxColumn24
            // 
            this.dataGridTextBoxColumn24.Format = "dd/MM/yyyy";
            this.dataGridTextBoxColumn24.FormatInfo = null;
            this.dataGridTextBoxColumn24.HeaderText = "F.Pedido";
            this.dataGridTextBoxColumn24.MappingName = "dFechaPedido";
            this.dataGridTextBoxColumn24.NullText = "";
            this.dataGridTextBoxColumn24.Width = 105;
            // 
            // dataGridTextBoxColumn25
            // 
            this.dataGridTextBoxColumn25.Format = "";
            this.dataGridTextBoxColumn25.FormatInfo = null;
            this.dataGridTextBoxColumn25.HeaderText = "Tipo";
            this.dataGridTextBoxColumn25.MappingName = "sIdTipoPedido";
            this.dataGridTextBoxColumn25.NullText = "";
            this.dataGridTextBoxColumn25.Width = 80;
            // 
            // dataGridTextBoxColumn32
            // 
            this.dataGridTextBoxColumn32.Format = "";
            this.dataGridTextBoxColumn32.FormatInfo = null;
            this.dataGridTextBoxColumn32.MappingName = "Boton";
            this.dataGridTextBoxColumn32.NullText = "";
            this.dataGridTextBoxColumn32.Width = 40;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.btPedActualizar);
            this.panel4.Controls.Add(this.btNuevoPedido);
            this.panel4.Controls.Add(this.cbPedidos);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.btPedEliminar);
            this.panel4.Location = new System.Drawing.Point(0, 177);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(326, 47);
            this.panel4.TabIndex = 1;
            // 
            // btPedActualizar
            // 
            this.btPedActualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btPedActualizar.ForeColor = System.Drawing.Color.Black;
            this.btPedActualizar.Image = ((System.Drawing.Image)(resources.GetObject("btPedActualizar.Image")));
            this.btPedActualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btPedActualizar.Location = new System.Drawing.Point(222, 14);
            this.btPedActualizar.Name = "btPedActualizar";
            this.btPedActualizar.Size = new System.Drawing.Size(97, 28);
            this.btPedActualizar.TabIndex = 2;
            this.btPedActualizar.Text = "Act&ualizar";
            this.btPedActualizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.btPedActualizar, "Actualizar Pedido ALT+U");
            this.btPedActualizar.UseVisualStyleBackColor = true;
            this.btPedActualizar.Click += new System.EventHandler(this.btPedActualizar_Click);
            // 
            // btNuevoPedido
            // 
            this.btNuevoPedido.Image = ((System.Drawing.Image)(resources.GetObject("btNuevoPedido.Image")));
            this.btNuevoPedido.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btNuevoPedido.Location = new System.Drawing.Point(199, 15);
            this.btNuevoPedido.Name = "btNuevoPedido";
            this.btNuevoPedido.Size = new System.Drawing.Size(23, 27);
            this.btNuevoPedido.TabIndex = 12;
            this.btNuevoPedido.TabStop = false;
            this.toolTip1.SetToolTip(this.btNuevoPedido, "Nuevo Pedido");
            this.btNuevoPedido.UseVisualStyleBackColor = true;
            this.btNuevoPedido.Click += new System.EventHandler(this.btNuevoPedido_Click);
            // 
            // cbPedidos
            // 
            this.cbPedidos.BackColor = System.Drawing.Color.White;
            this.cbPedidos.DataSource = this.dsReports1.ListaPedidosAsignables;
            this.cbPedidos.DisplayMember = "tPedido";
            this.cbPedidos.ForeColor = System.Drawing.Color.Black;
            this.cbPedidos.Location = new System.Drawing.Point(2, 16);
            this.cbPedidos.Name = "cbPedidos";
            this.cbPedidos.Size = new System.Drawing.Size(198, 26);
            this.cbPedidos.TabIndex = 0;
            this.cbPedidos.ValueMember = "sIdPedido";
            // 
            // label6
            // 
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(0, -1);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 21);
            this.label6.TabIndex = 1;
            this.label6.Text = "Pedido:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btPedEliminar
            // 
            this.btPedEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btPedEliminar.ForeColor = System.Drawing.Color.Black;
            this.btPedEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btPedEliminar.Image")));
            this.btPedEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btPedEliminar.Location = new System.Drawing.Point(222, 14);
            this.btPedEliminar.Name = "btPedEliminar";
            this.btPedEliminar.Size = new System.Drawing.Size(96, 26);
            this.btPedEliminar.TabIndex = 3;
            this.btPedEliminar.Text = "Eli&minar";
            this.btPedEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.btPedEliminar, "Eliminar Pedido ALT+M");
            this.btPedEliminar.UseVisualStyleBackColor = true;
            this.btPedEliminar.Click += new System.EventHandler(this.btPedEliminar_Click);
            // 
            // listaPromocionProdBindingSource1
            // 
            this.listaPromocionProdBindingSource1.DataMember = "ListaPromocionProd";
            this.listaPromocionProdBindingSource1.DataSource = this.dsReports1;
            // 
            // sqldaListaPromocionProd
            // 
            this.sqldaListaPromocionProd.SelectCommand = this.sqlSelectCommand5;
            this.sqldaListaPromocionProd.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaPromocionProd", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iOrden", "iOrden"),
                        new System.Data.Common.DataColumnMapping("sIdProducto", "sIdProducto"),
                        new System.Data.Common.DataColumnMapping("iIdPromocion", "iIdPromocion"),
                        new System.Data.Common.DataColumnMapping("sDescripcion", "sDescripcion")})});
            // 
            // sqlSelectCommand5
            // 
            this.sqlSelectCommand5.CommandText = "[ListaPromocionProd]";
            this.sqlSelectCommand5.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand5.Connection = this.sqlConn;
            this.sqlSelectCommand5.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdReport", System.Data.SqlDbType.Int, 4)});
            // 
            // sqldaListaRepActProductos
            // 
            this.sqldaListaRepActProductos.SelectCommand = this.sqlSelectCommand6;
            this.sqldaListaRepActProductos.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
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
            // sqlSelectCommand6
            // 
            this.sqlSelectCommand6.CommandText = "[ListaRepActividadProd]";
            this.sqlSelectCommand6.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand6.Connection = this.sqlConn;
            this.sqlSelectCommand6.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdReport", System.Data.SqlDbType.Int, 4)});
            // 
            // sqldaListaBuscarProductos
            // 
            this.sqldaListaBuscarProductos.SelectCommand = this.sqlSelectCmdBuscarProductos;
            this.sqldaListaBuscarProductos.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaBuscarProductos", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("sIdProducto", "sIdProducto"),
                        new System.Data.Common.DataColumnMapping("sDescripcion", "sDescripcion")})});
            // 
            // sqlSelectCmdBuscarProductos
            // 
            this.sqlSelectCmdBuscarProductos.CommandText = "[ListaBuscarProductos]";
            this.sqlSelectCmdBuscarProductos.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCmdBuscarProductos.Connection = this.sqlConn;
            this.sqlSelectCmdBuscarProductos.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@sIdProducto", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@sDescripcion", System.Data.SqlDbType.VarChar, 50),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4)});
            // 
            // btVerCentro
            // 
            this.btVerCentro.Image = ((System.Drawing.Image)(resources.GetObject("btVerCentro.Image")));
            this.btVerCentro.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btVerCentro.Location = new System.Drawing.Point(1160, 10);
            this.btVerCentro.Name = "btVerCentro";
            this.btVerCentro.Size = new System.Drawing.Size(25, 27);
            this.btVerCentro.TabIndex = 73;
            this.btVerCentro.TabStop = false;
            this.toolTip1.SetToolTip(this.btVerCentro, "Editar Centro");
            this.btVerCentro.UseVisualStyleBackColor = true;
            this.btVerCentro.Visible = false;
            this.btVerCentro.Click += new System.EventHandler(this.btVerCentro_Click);
            // 
            // btGadgetEliminar
            // 
            this.btGadgetEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btGadgetEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btGadgetEliminar.ForeColor = System.Drawing.Color.Black;
            this.btGadgetEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btGadgetEliminar.Image")));
            this.btGadgetEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btGadgetEliminar.Location = new System.Drawing.Point(109, 152);
            this.btGadgetEliminar.Name = "btGadgetEliminar";
            this.btGadgetEliminar.Size = new System.Drawing.Size(97, 26);
            this.btGadgetEliminar.TabIndex = 3;
            this.btGadgetEliminar.Text = "E&liminar";
            this.btGadgetEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.btGadgetEliminar, "Eliminar Gadget ALT+L");
            this.btGadgetEliminar.UseVisualStyleBackColor = true;
            this.btGadgetEliminar.Click += new System.EventHandler(this.btGadgetEliminar_Click);
            // 
            // btGadgetActualizar
            // 
            this.btGadgetActualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btGadgetActualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btGadgetActualizar.ForeColor = System.Drawing.Color.Black;
            this.btGadgetActualizar.Image = ((System.Drawing.Image)(resources.GetObject("btGadgetActualizar.Image")));
            this.btGadgetActualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btGadgetActualizar.Location = new System.Drawing.Point(11, 152);
            this.btGadgetActualizar.Name = "btGadgetActualizar";
            this.btGadgetActualizar.Size = new System.Drawing.Size(97, 26);
            this.btGadgetActualizar.TabIndex = 2;
            this.btGadgetActualizar.Text = "A&ctualizar";
            this.btGadgetActualizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.btGadgetActualizar, "Actualizar Gadgte ALT+C");
            this.btGadgetActualizar.UseVisualStyleBackColor = true;
            this.btGadgetActualizar.Click += new System.EventHandler(this.btGadgetActualizar_Click);
            // 
            // btAtenEliminar
            // 
            this.btAtenEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btAtenEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAtenEliminar.ForeColor = System.Drawing.Color.Black;
            this.btAtenEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btAtenEliminar.Image")));
            this.btAtenEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btAtenEliminar.Location = new System.Drawing.Point(103, 151);
            this.btAtenEliminar.Name = "btAtenEliminar";
            this.btAtenEliminar.Size = new System.Drawing.Size(97, 26);
            this.btAtenEliminar.TabIndex = 7;
            this.btAtenEliminar.Text = "El&iminar";
            this.btAtenEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.btAtenEliminar, "Eliminar Atención ALT+I");
            this.btAtenEliminar.UseVisualStyleBackColor = true;
            this.btAtenEliminar.Click += new System.EventHandler(this.btAtenEliminar_Click);
            // 
            // btAtenActualizar
            // 
            this.btAtenActualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btAtenActualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAtenActualizar.ForeColor = System.Drawing.Color.Black;
            this.btAtenActualizar.Image = ((System.Drawing.Image)(resources.GetObject("btAtenActualizar.Image")));
            this.btAtenActualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btAtenActualizar.Location = new System.Drawing.Point(332, 154);
            this.btAtenActualizar.Name = "btAtenActualizar";
            this.btAtenActualizar.Size = new System.Drawing.Size(97, 26);
            this.btAtenActualizar.TabIndex = 6;
            this.btAtenActualizar.Text = "Ac&tualizar";
            this.btAtenActualizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.btAtenActualizar, "ctualizar Atención ALT+T");
            this.btAtenActualizar.UseVisualStyleBackColor = true;
            this.btAtenActualizar.Click += new System.EventHandler(this.btAtenActualizar_Click);
            // 
            // btBuscarAtencion
            // 
            this.btBuscarAtencion.Image = ((System.Drawing.Image)(resources.GetObject("btBuscarAtencion.Image")));
            this.btBuscarAtencion.Location = new System.Drawing.Point(100, 15);
            this.btBuscarAtencion.Name = "btBuscarAtencion";
            this.btBuscarAtencion.Size = new System.Drawing.Size(21, 24);
            this.btBuscarAtencion.TabIndex = 38;
            this.btBuscarAtencion.TabStop = false;
            this.toolTip1.SetToolTip(this.btBuscarAtencion, "Buscar Atención");
            this.btBuscarAtencion.UseVisualStyleBackColor = true;
            this.btBuscarAtencion.Click += new System.EventHandler(this.btBuscarAtencion_Click);
            // 
            // btBuscarProducto
            // 
            this.btBuscarProducto.Image = ((System.Drawing.Image)(resources.GetObject("btBuscarProducto.Image")));
            this.btBuscarProducto.Location = new System.Drawing.Point(122, 16);
            this.btBuscarProducto.Name = "btBuscarProducto";
            this.btBuscarProducto.Size = new System.Drawing.Size(16, 20);
            this.btBuscarProducto.TabIndex = 10;
            this.btBuscarProducto.TabStop = false;
            this.toolTip1.SetToolTip(this.btBuscarProducto, "Buscar Producto");
            this.btBuscarProducto.UseVisualStyleBackColor = true;
            this.btBuscarProducto.Click += new System.EventHandler(this.btBuscarProducto_Click);
            // 
            // btBorrarProd
            // 
            this.btBorrarProd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btBorrarProd.ForeColor = System.Drawing.Color.Black;
            this.btBorrarProd.Image = ((System.Drawing.Image)(resources.GetObject("btBorrarProd.Image")));
            this.btBorrarProd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btBorrarProd.Location = new System.Drawing.Point(68, 153);
            this.btBorrarProd.Name = "btBorrarProd";
            this.btBorrarProd.Size = new System.Drawing.Size(64, 24);
            this.btBorrarProd.TabIndex = 3;
            this.btBorrarProd.Text = "Elimi&nar";
            this.btBorrarProd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.btBorrarProd, "Eliminar Producto ALT+N");
            this.btBorrarProd.UseVisualStyleBackColor = true;
            this.btBorrarProd.Visible = false;
            this.btBorrarProd.Click += new System.EventHandler(this.mnEliminarProd_Click);
            // 
            // btModifProd
            // 
            this.btModifProd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btModifProd.ForeColor = System.Drawing.Color.Black;
            this.btModifProd.Image = ((System.Drawing.Image)(resources.GetObject("btModifProd.Image")));
            this.btModifProd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btModifProd.Location = new System.Drawing.Point(65, 153);
            this.btModifProd.Name = "btModifProd";
            this.btModifProd.Size = new System.Drawing.Size(67, 24);
            this.btModifProd.TabIndex = 2;
            this.btModifProd.Text = "Actuali&zar";
            this.btModifProd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.btModifProd, "Actualizar Producto ALT+Z");
            this.btModifProd.UseVisualStyleBackColor = true;
            this.btModifProd.Visible = false;
            this.btModifProd.Click += new System.EventHandler(this.btModifProd_Click);
            // 
            // btAceptarProdsPromo
            // 
            this.btAceptarProdsPromo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btAceptarProdsPromo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAceptarProdsPromo.ForeColor = System.Drawing.Color.Black;
            this.btAceptarProdsPromo.Image = ((System.Drawing.Image)(resources.GetObject("btAceptarProdsPromo.Image")));
            this.btAceptarProdsPromo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btAceptarProdsPromo.Location = new System.Drawing.Point(215, 1);
            this.btAceptarProdsPromo.Name = "btAceptarProdsPromo";
            this.btAceptarProdsPromo.Size = new System.Drawing.Size(98, 32);
            this.btAceptarProdsPromo.TabIndex = 7;
            this.btAceptarProdsPromo.Text = "Ac&tualizar";
            this.btAceptarProdsPromo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.btAceptarProdsPromo, "ctualizar Atención ALT+T");
            this.btAceptarProdsPromo.UseVisualStyleBackColor = true;
            this.btAceptarProdsPromo.Click += new System.EventHandler(this.btAceptarProdsPromo_Click);
            // 
            // sqlcomdGetRepActividadCab
            // 
            this.sqlcomdGetRepActividadCab.CommandText = "[GetRepActividad_Cab]";
            this.sqlcomdGetRepActividadCab.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlcomdGetRepActividadCab.Connection = this.sqlConn;
            this.sqlcomdGetRepActividadCab.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdReport", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdDelegado", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Output, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@sIdReportTemp", System.Data.SqlDbType.VarChar, 15, System.Data.ParameterDirection.Output, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@sTipoRActividad", System.Data.SqlDbType.VarChar, 10, System.Data.ParameterDirection.Output, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@sIdTipoCliente", System.Data.SqlDbType.VarChar, 10, System.Data.ParameterDirection.Output, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdCentro", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Output, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@sIdCentro", System.Data.SqlDbType.VarChar, 20, System.Data.ParameterDirection.Output, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@tCentro", System.Data.SqlDbType.VarChar, 100, System.Data.ParameterDirection.Output, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@dFecha", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Output, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iHorario", System.Data.SqlDbType.VarChar, 10, System.Data.ParameterDirection.Output, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@tObjetivo", System.Data.SqlDbType.VarChar, 8000, System.Data.ParameterDirection.Output, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@tProxObjetivo", System.Data.SqlDbType.VarChar, 8000, System.Data.ParameterDirection.Output, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@tObservaciones", System.Data.SqlDbType.VarChar, 8000, System.Data.ParameterDirection.Output, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@dFUM", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Output, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt, 2, System.Data.ParameterDirection.Output, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@bPlanificacion", System.Data.SqlDbType.SmallInt, 2, System.Data.ParameterDirection.Output, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@bEnviadoCEN", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Output, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@bEnviadoPDA", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Output, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@dHoraInicio", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Output, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@dHoraFin", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Output, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null)});
            // 
            // sqldaCentroClienteCOM
            // 
            this.sqldaCentroClienteCOM.SelectCommand = this.sqlSelectCommand10;
            this.sqldaCentroClienteCOM.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaCentrosClientesCom", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("sIdCliente", "sIdCliente"),
                        new System.Data.Common.DataColumnMapping("sNombre", "sNombre")})});
            // 
            // sqlSelectCommand10
            // 
            this.sqlSelectCommand10.CommandText = "[ListaCentrosClientesCom]";
            this.sqlSelectCommand10.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand10.Connection = this.sqlConn;
            this.sqlSelectCommand10.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@sIdCentro", System.Data.SqlDbType.VarChar, 14)});
            // 
            // sqldaRepActClientes
            // 
            this.sqldaRepActClientes.SelectCommand = this.sqlSelectCommand9;
            this.sqldaRepActClientes.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
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
            // sqlSelectCommand9
            // 
            this.sqlSelectCommand9.CommandText = "[ListaRepActividadCli]";
            this.sqlSelectCommand9.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand9.Connection = this.sqlConn;
            this.sqlSelectCommand9.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdReport", System.Data.SqlDbType.Int, 4)});
            // 
            // sqldaRepActGadgets
            // 
            this.sqldaRepActGadgets.SelectCommand = this.sqlSelectCommand12;
            this.sqldaRepActGadgets.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaRepActividGadget", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iIdReport", "iIdReport"),
                        new System.Data.Common.DataColumnMapping("iIdCliente", "iIdCliente"),
                        new System.Data.Common.DataColumnMapping("sIdCliente", "sIdCliente"),
                        new System.Data.Common.DataColumnMapping("iIdGadget", "iIdGadget"),
                        new System.Data.Common.DataColumnMapping("iCantidad", "iCantidad"),
                        new System.Data.Common.DataColumnMapping("sDescripcion", "sDescripcion")})});
            // 
            // sqlSelectCommand12
            // 
            this.sqlSelectCommand12.CommandText = "[ListaRepActividGadget]";
            this.sqlSelectCommand12.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand12.Connection = this.sqlConn;
            this.sqlSelectCommand12.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdReport", System.Data.SqlDbType.Int, 4)});
            // 
            // pnClientesVisitados
            // 
            this.pnClientesVisitados.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnClientesVisitados.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnClientesVisitados.Controls.Add(this.btEncuestas);
            this.pnClientesVisitados.Controls.Add(this.panel10);
            this.pnClientesVisitados.Controls.Add(this.pnDatosClientesPlanif);
            this.pnClientesVisitados.Controls.Add(this.pnDatosClienteVisita);
            this.pnClientesVisitados.Controls.Add(this.txtsCentro);
            this.pnClientesVisitados.Controls.Add(this.btBuscarCentro);
            this.pnClientesVisitados.Controls.Add(this.txtsIdCentro);
            this.pnClientesVisitados.Controls.Add(this.lblCentro);
            this.pnClientesVisitados.Controls.Add(this.btVerCentro);
            this.pnClientesVisitados.Controls.Add(this.panel1);
            this.pnClientesVisitados.Location = new System.Drawing.Point(2, 180);
            this.pnClientesVisitados.Name = "pnClientesVisitados";
            this.pnClientesVisitados.Size = new System.Drawing.Size(1534, 795);
            this.pnClientesVisitados.TabIndex = 5;
            this.pnClientesVisitados.Paint += new System.Windows.Forms.PaintEventHandler(this.pnClientesVisitados_Paint);
            // 
            // panel10
            // 
            this.panel10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel10.Controls.Add(this.lblToolTipBoton);
            this.panel10.Controls.Add(this.dgClientes);
            this.panel10.Controls.Add(this.lblTotClientes);
            this.panel10.Controls.Add(this.labelGradient6);
            this.panel10.Location = new System.Drawing.Point(2, 2);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(613, 284);
            this.panel10.TabIndex = 1;
            // 
            // lblToolTipBoton
            // 
            this.lblToolTipBoton.BackColor = System.Drawing.SystemColors.Info;
            this.lblToolTipBoton.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblToolTipBoton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToolTipBoton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblToolTipBoton.Location = new System.Drawing.Point(0, 0);
            this.lblToolTipBoton.Name = "lblToolTipBoton";
            this.lblToolTipBoton.Size = new System.Drawing.Size(10, 13);
            this.lblToolTipBoton.TabIndex = 76;
            this.lblToolTipBoton.Text = "O";
            this.lblToolTipBoton.Visible = false;
            // 
            // lblTotClientes
            // 
            this.lblTotClientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.lblTotClientes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotClientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotClientes.ForeColor = System.Drawing.Color.Black;
            this.lblTotClientes.Location = new System.Drawing.Point(556, -3);
            this.lblTotClientes.Name = "lblTotClientes";
            this.lblTotClientes.Size = new System.Drawing.Size(51, 22);
            this.lblTotClientes.TabIndex = 75;
            this.lblTotClientes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.labelGradient6.Size = new System.Drawing.Size(609, 21);
            this.labelGradient6.TabIndex = 0;
            this.labelGradient6.Text = "Clientes Visitados";
            this.labelGradient6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnDatosClientesPlanif
            // 
            this.pnDatosClientesPlanif.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnDatosClientesPlanif.Controls.Add(this.panel6);
            this.pnDatosClientesPlanif.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnDatosClientesPlanif.Location = new System.Drawing.Point(2, 529);
            this.pnDatosClientesPlanif.Name = "pnDatosClientesPlanif";
            this.pnDatosClientesPlanif.Size = new System.Drawing.Size(1525, 155);
            this.pnDatosClientesPlanif.TabIndex = 6;
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel6.Controls.Add(this.dgClientesProxObj);
            this.panel6.Controls.Add(this.lblTotProxObj);
            this.panel6.Controls.Add(this.labelGradient2);
            this.panel6.Location = new System.Drawing.Point(2, -1);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1460, 152);
            this.panel6.TabIndex = 2;
            // 
            // dgClientesProxObj
            // 
            this.dgClientesProxObj.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgClientesProxObj.CaptionText = "Objetivos Fijados en la Ultima Visita";
            this.dgClientesProxObj.CaptionVisible = false;
            this.dgClientesProxObj.DataMember = "ListaRepActividadCli_ProxObj";
            this.dgClientesProxObj.DataSource = this.dsReports1;
            this.dgClientesProxObj.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgClientesProxObj.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgClientesProxObj.Location = new System.Drawing.Point(0, 18);
            this.dgClientesProxObj.Name = "dgClientesProxObj";
            this.dgClientesProxObj.ReadOnly = true;
            this.dgClientesProxObj.RowHeaderWidth = 17;
            this.dgClientesProxObj.Size = new System.Drawing.Size(1453, 124);
            this.dgClientesProxObj.TabIndex = 0;
            this.dgClientesProxObj.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle6});
            // 
            // dataGridTableStyle6
            // 
            this.dataGridTableStyle6.DataGrid = this.dgClientesProxObj;
            this.dataGridTableStyle6.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn26,
            this.dataGridTextBoxColumn27,
            this.dataGridTextBoxColumn28,
            this.dataGridTextBoxColumn29,
            this.dataGridTextBoxColumn30});
            this.dataGridTableStyle6.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle6.MappingName = "ListaRepActividadCli_ProxObj";
            this.dataGridTableStyle6.RowHeaderWidth = 17;
            // 
            // dataGridTextBoxColumn26
            // 
            this.dataGridTextBoxColumn26.Format = "";
            this.dataGridTextBoxColumn26.FormatInfo = null;
            this.dataGridTextBoxColumn26.MappingName = "iIdCliente";
            this.dataGridTextBoxColumn26.NullText = "";
            this.dataGridTextBoxColumn26.Width = 0;
            // 
            // dataGridTextBoxColumn27
            // 
            this.dataGridTextBoxColumn27.Format = "";
            this.dataGridTextBoxColumn27.FormatInfo = null;
            this.dataGridTextBoxColumn27.HeaderText = "Código";
            this.dataGridTextBoxColumn27.MappingName = "sIdCliente";
            this.dataGridTextBoxColumn27.NullText = "";
            this.dataGridTextBoxColumn27.Width = 75;
            // 
            // dataGridTextBoxColumn28
            // 
            this.dataGridTextBoxColumn28.Format = "";
            this.dataGridTextBoxColumn28.FormatInfo = null;
            this.dataGridTextBoxColumn28.HeaderText = "Nombre";
            this.dataGridTextBoxColumn28.MappingName = "sNombre";
            this.dataGridTextBoxColumn28.NullText = "";
            this.dataGridTextBoxColumn28.Width = 500;
            // 
            // dataGridTextBoxColumn29
            // 
            this.dataGridTextBoxColumn29.Format = "";
            this.dataGridTextBoxColumn29.FormatInfo = null;
            this.dataGridTextBoxColumn29.HeaderText = "Próximos Objetivos";
            this.dataGridTextBoxColumn29.MappingName = "tProxObj";
            this.dataGridTextBoxColumn29.NullText = "";
            this.dataGridTextBoxColumn29.Width = 500;
            // 
            // dataGridTextBoxColumn30
            // 
            this.dataGridTextBoxColumn30.Format = "";
            this.dataGridTextBoxColumn30.FormatInfo = null;
            this.dataGridTextBoxColumn30.HeaderText = "Ultima Visita";
            this.dataGridTextBoxColumn30.MappingName = "dFecha";
            this.dataGridTextBoxColumn30.NullText = "";
            this.dataGridTextBoxColumn30.Width = 110;
            // 
            // lblTotProxObj
            // 
            this.lblTotProxObj.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.lblTotProxObj.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotProxObj.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotProxObj.ForeColor = System.Drawing.Color.Black;
            this.lblTotProxObj.Location = new System.Drawing.Point(1408, 0);
            this.lblTotProxObj.Name = "lblTotProxObj";
            this.lblTotProxObj.Size = new System.Drawing.Size(50, 18);
            this.lblTotProxObj.TabIndex = 1;
            this.lblTotProxObj.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.labelGradient2.Size = new System.Drawing.Size(1456, 18);
            this.labelGradient2.TabIndex = 0;
            this.labelGradient2.Text = "Objetivos fijados en la última visita";
            this.labelGradient2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnDatosClienteVisita
            // 
            this.pnDatosClienteVisita.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnDatosClienteVisita.Controls.Add(this.pnProductosProm);
            this.pnDatosClienteVisita.Controls.Add(this.panel3);
            this.pnDatosClienteVisita.Controls.Add(this.btAtenActualizar);
            this.pnDatosClienteVisita.Controls.Add(this.pnTodaAtencion);
            this.pnDatosClienteVisita.Controls.Add(this.panel7);
            this.pnDatosClienteVisita.Controls.Add(this.panel2);
            this.pnDatosClienteVisita.Controls.Add(this.btGadgetActualizar);
            this.pnDatosClienteVisita.Controls.Add(this.btGadgetEliminar);
            this.pnDatosClienteVisita.Controls.Add(this.panel9);
            this.pnDatosClienteVisita.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnDatosClienteVisita.Location = new System.Drawing.Point(2, 292);
            this.pnDatosClienteVisita.Name = "pnDatosClienteVisita";
            this.pnDatosClienteVisita.Size = new System.Drawing.Size(1525, 234);
            this.pnDatosClienteVisita.TabIndex = 9;
            this.pnDatosClienteVisita.Paint += new System.Windows.Forms.PaintEventHandler(this.pnDatosClienteVisita_Paint);
            // 
            // pnProductosProm
            // 
            this.pnProductosProm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnProductosProm.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnProductosProm.Controls.Add(this.pnAceptarPromo);
            this.pnProductosProm.Controls.Add(this.panel5);
            this.pnProductosProm.Controls.Add(this.btModifProd);
            this.pnProductosProm.Controls.Add(this.btBorrarProd);
            this.pnProductosProm.Controls.Add(this.pnProductos);
            this.pnProductosProm.Location = new System.Drawing.Point(648, 1);
            this.pnProductosProm.Name = "pnProductosProm";
            this.pnProductosProm.Size = new System.Drawing.Size(326, 228);
            this.pnProductosProm.TabIndex = 47;
            // 
            // pnAceptarPromo
            // 
            this.pnAceptarPromo.Controls.Add(this.lblActProdProm);
            this.pnAceptarPromo.Controls.Add(this.btAceptarProdsPromo);
            this.pnAceptarPromo.Location = new System.Drawing.Point(2, 190);
            this.pnAceptarPromo.Name = "pnAceptarPromo";
            this.pnAceptarPromo.Size = new System.Drawing.Size(323, 35);
            this.pnAceptarPromo.TabIndex = 12;
            // 
            // lblActProdProm
            // 
            this.lblActProdProm.AutoSize = true;
            this.lblActProdProm.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActProdProm.ForeColor = System.Drawing.Color.Red;
            this.lblActProdProm.Location = new System.Drawing.Point(4, 8);
            this.lblActProdProm.Name = "lblActProdProm";
            this.lblActProdProm.Size = new System.Drawing.Size(196, 18);
            this.lblActProdProm.TabIndex = 8;
            this.lblActProdProm.Text = "Falta Actualizar Cambios";
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel5.Controls.Add(this.dGVProductosPromo);
            this.panel5.Controls.Add(this.dgProductos);
            this.panel5.Controls.Add(this.lblTotProductos);
            this.panel5.Controls.Add(this.labelGradient1);
            this.panel5.Location = new System.Drawing.Point(0, 1);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(326, 204);
            this.panel5.TabIndex = 0;
            // 
            // dGVProductosPromo
            // 
            this.dGVProductosPromo.AllowUserToAddRows = false;
            this.dGVProductosPromo.AllowUserToDeleteRows = false;
            this.dGVProductosPromo.AllowUserToResizeRows = false;
            this.dGVProductosPromo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVProductosPromo.Location = new System.Drawing.Point(0, 20);
            this.dGVProductosPromo.MultiSelect = false;
            this.dGVProductosPromo.Name = "dGVProductosPromo";
            this.dGVProductosPromo.RowHeadersVisible = false;
            this.dGVProductosPromo.Size = new System.Drawing.Size(320, 166);
            this.dGVProductosPromo.TabIndex = 16;
            this.dGVProductosPromo.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dGVProductosPromo_CellBeginEdit);
            this.dGVProductosPromo.Paint += new System.Windows.Forms.PaintEventHandler(this.dGVProductosPromo_Paint);
            this.dGVProductosPromo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dGVProductosPromo_MouseUp);
            // 
            // dgProductos
            // 
            this.dgProductos.AllowSorting = false;
            this.dgProductos.BackgroundColor = System.Drawing.Color.White;
            this.dgProductos.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.dgProductos.CaptionText = "Promociones";
            this.dgProductos.CaptionVisible = false;
            this.dgProductos.DataMember = "";
            this.dgProductos.DataSource = this.listaPromocionProdBindingSource1;
            this.dgProductos.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgProductos.Location = new System.Drawing.Point(1, 20);
            this.dgProductos.Name = "dgProductos";
            this.dgProductos.ReadOnly = true;
            this.dgProductos.RowHeaderWidth = 30;
            this.dgProductos.Size = new System.Drawing.Size(220, 127);
            this.dgProductos.TabIndex = 0;
            this.dgProductos.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            this.dgProductos.Visible = false;
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.DataGrid = this.dgProductos;
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle1.MappingName = "ListaPromocionProd";
            this.dataGridTableStyle1.ReadOnly = true;
            this.dataGridTableStyle1.RowHeaderWidth = 30;
            // 
            // lblTotProductos
            // 
            this.lblTotProductos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.lblTotProductos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotProductos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotProductos.ForeColor = System.Drawing.Color.Black;
            this.lblTotProductos.Location = new System.Drawing.Point(272, 0);
            this.lblTotProductos.Name = "lblTotProductos";
            this.lblTotProductos.Size = new System.Drawing.Size(50, 18);
            this.lblTotProductos.TabIndex = 13;
            this.lblTotProductos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.labelGradient1.Size = new System.Drawing.Size(322, 18);
            this.labelGradient1.TabIndex = 0;
            this.labelGradient1.Text = "Promociones";
            this.labelGradient1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnProductos
            // 
            this.pnProductos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnProductos.Controls.Add(this.btBuscarProducto);
            this.pnProductos.Controls.Add(this.txtsProducto);
            this.pnProductos.Controls.Add(this.txtsIdProducto);
            this.pnProductos.Controls.Add(this.nudiMuestras);
            this.pnProductos.Controls.Add(this.nudiOrden);
            this.pnProductos.Controls.Add(this.lblProducto);
            this.pnProductos.Controls.Add(this.lblOrdeb);
            this.pnProductos.Controls.Add(this.lbliMuestras);
            this.pnProductos.Location = new System.Drawing.Point(0, 145);
            this.pnProductos.Name = "pnProductos";
            this.pnProductos.Size = new System.Drawing.Size(325, 42);
            this.pnProductos.TabIndex = 1;
            this.pnProductos.Visible = false;
            // 
            // txtsProducto
            // 
            this.txtsProducto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtsProducto.ForeColor = System.Drawing.Color.Black;
            this.txtsProducto.Location = new System.Drawing.Point(2, 16);
            this.txtsProducto.Name = "txtsProducto";
            this.txtsProducto.ReadOnly = true;
            this.txtsProducto.Size = new System.Drawing.Size(118, 24);
            this.txtsProducto.TabIndex = 8;
            this.txtsProducto.TabStop = false;
            // 
            // txtsIdProducto
            // 
            this.txtsIdProducto.ForeColor = System.Drawing.Color.Black;
            this.txtsIdProducto.Location = new System.Drawing.Point(7, 16);
            this.txtsIdProducto.MaxLength = 10;
            this.txtsIdProducto.Name = "txtsIdProducto";
            this.txtsIdProducto.Size = new System.Drawing.Size(93, 24);
            this.txtsIdProducto.TabIndex = 0;
            this.txtsIdProducto.Visible = false;
            // 
            // nudiMuestras
            // 
            this.nudiMuestras.ForeColor = System.Drawing.Color.Black;
            this.nudiMuestras.Location = new System.Drawing.Point(172, 16);
            this.nudiMuestras.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudiMuestras.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudiMuestras.Name = "nudiMuestras";
            this.nudiMuestras.Size = new System.Drawing.Size(50, 24);
            this.nudiMuestras.TabIndex = 3;
            this.nudiMuestras.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudiOrden
            // 
            this.nudiOrden.ForeColor = System.Drawing.Color.Black;
            this.nudiOrden.Location = new System.Drawing.Point(144, 16);
            this.nudiOrden.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudiOrden.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudiOrden.Name = "nudiOrden";
            this.nudiOrden.Size = new System.Drawing.Size(35, 24);
            this.nudiOrden.TabIndex = 2;
            this.nudiOrden.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudiOrden.Visible = false;
            // 
            // lblProducto
            // 
            this.lblProducto.ForeColor = System.Drawing.Color.Black;
            this.lblProducto.Location = new System.Drawing.Point(2, -2);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(48, 16);
            this.lblProducto.TabIndex = 1;
            this.lblProducto.Text = "Producto";
            this.lblProducto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblOrdeb
            // 
            this.lblOrdeb.ForeColor = System.Drawing.Color.Black;
            this.lblOrdeb.Location = new System.Drawing.Point(142, 0);
            this.lblOrdeb.Name = "lblOrdeb";
            this.lblOrdeb.Size = new System.Drawing.Size(30, 16);
            this.lblOrdeb.TabIndex = 7;
            this.lblOrdeb.Text = "Orden";
            this.lblOrdeb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblOrdeb.Visible = false;
            // 
            // lbliMuestras
            // 
            this.lbliMuestras.ForeColor = System.Drawing.Color.Black;
            this.lbliMuestras.Location = new System.Drawing.Point(172, 0);
            this.lbliMuestras.Name = "lbliMuestras";
            this.lbliMuestras.Size = new System.Drawing.Size(43, 16);
            this.lbliMuestras.TabIndex = 5;
            this.lbliMuestras.Text = "Muestras";
            this.lbliMuestras.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.btBuscarAtencion);
            this.panel3.Controls.Add(this.txtsIdAtencion);
            this.panel3.Controls.Add(this.nupImporteCli);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.txtfImportePrev);
            this.panel3.Controls.Add(this.txtTipoAtencion);
            this.panel3.Location = new System.Drawing.Point(326, 183);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(317, 41);
            this.panel3.TabIndex = 5;
            // 
            // txtsIdAtencion
            // 
            this.txtsIdAtencion.BackColor = System.Drawing.Color.White;
            this.txtsIdAtencion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtsIdAtencion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsIdAtencion.ForeColor = System.Drawing.Color.Black;
            this.txtsIdAtencion.Location = new System.Drawing.Point(2, 16);
            this.txtsIdAtencion.MaxLength = 20;
            this.txtsIdAtencion.Name = "txtsIdAtencion";
            this.txtsIdAtencion.Size = new System.Drawing.Size(100, 24);
            this.txtsIdAtencion.TabIndex = 0;
            this.txtsIdAtencion.Leave += new System.EventHandler(this.txtsIdAtencion_Leave);
            // 
            // nupImporteCli
            // 
            this.nupImporteCli.BackColor = System.Drawing.Color.White;
            this.nupImporteCli.DecimalPlaces = 2;
            this.nupImporteCli.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nupImporteCli.ForeColor = System.Drawing.Color.Black;
            this.nupImporteCli.Location = new System.Drawing.Point(181, 16);
            this.nupImporteCli.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nupImporteCli.Name = "nupImporteCli";
            this.nupImporteCli.Size = new System.Drawing.Size(71, 24);
            this.nupImporteCli.TabIndex = 1;
            this.nupImporteCli.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(7, -2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 20);
            this.label5.TabIndex = 32;
            this.label5.Text = "Atención:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(264, -2);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 18);
            this.label8.TabIndex = 36;
            this.label8.Text = "Total Previsto:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(179, -2);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(83, 18);
            this.label11.TabIndex = 40;
            this.label11.Text = "Imp. Cliente:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(118, -2);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(84, 18);
            this.label10.TabIndex = 37;
            this.label10.Text = "Tipo:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtfImportePrev
            // 
            this.txtfImportePrev.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtfImportePrev.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtfImportePrev.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtfImportePrev.Location = new System.Drawing.Point(252, 16);
            this.txtfImportePrev.Name = "txtfImportePrev";
            this.txtfImportePrev.Size = new System.Drawing.Size(62, 20);
            this.txtfImportePrev.TabIndex = 6;
            this.txtfImportePrev.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTipoAtencion
            // 
            this.txtTipoAtencion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtTipoAtencion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtTipoAtencion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTipoAtencion.Location = new System.Drawing.Point(118, 16);
            this.txtTipoAtencion.Name = "txtTipoAtencion";
            this.txtTipoAtencion.Size = new System.Drawing.Size(63, 20);
            this.txtTipoAtencion.TabIndex = 5;
            this.txtTipoAtencion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnTodaAtencion
            // 
            this.pnTodaAtencion.Controls.Add(this.panel8);
            this.pnTodaAtencion.Controls.Add(this.btAtenEliminar);
            this.pnTodaAtencion.Location = new System.Drawing.Point(326, 3);
            this.pnTodaAtencion.Name = "pnTodaAtencion";
            this.pnTodaAtencion.Size = new System.Drawing.Size(320, 222);
            this.pnTodaAtencion.TabIndex = 46;
            // 
            // panel8
            // 
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel8.Controls.Add(this.dgAtenciones);
            this.panel8.Controls.Add(this.lblTotAtenciones);
            this.panel8.Controls.Add(this.labelGradient4);
            this.panel8.Location = new System.Drawing.Point(-2, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(320, 148);
            this.panel8.TabIndex = 4;
            // 
            // dgAtenciones
            // 
            this.dgAtenciones.AllowSorting = false;
            this.dgAtenciones.BackgroundColor = System.Drawing.Color.White;
            this.dgAtenciones.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.dgAtenciones.CaptionText = "Atenciones Reportadas a un Cliente";
            this.dgAtenciones.CaptionVisible = false;
            this.dgAtenciones.DataMember = "";
            this.dgAtenciones.HeaderBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgAtenciones.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgAtenciones.Location = new System.Drawing.Point(0, 21);
            this.dgAtenciones.Name = "dgAtenciones";
            this.dgAtenciones.ReadOnly = true;
            this.dgAtenciones.RowHeaderWidth = 15;
            this.dgAtenciones.Size = new System.Drawing.Size(317, 125);
            this.dgAtenciones.TabIndex = 0;
            this.dgAtenciones.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle4});
            this.dgAtenciones.CurrentCellChanged += new System.EventHandler(this.dgAtenciones_CurrentCellChanged);
            // 
            // dataGridTableStyle4
            // 
            this.dataGridTableStyle4.AllowSorting = false;
            this.dataGridTableStyle4.DataGrid = this.dgAtenciones;
            this.dataGridTableStyle4.HeaderBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridTableStyle4.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle4.RowHeaderWidth = 15;
            // 
            // lblTotAtenciones
            // 
            this.lblTotAtenciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.lblTotAtenciones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotAtenciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotAtenciones.ForeColor = System.Drawing.Color.Black;
            this.lblTotAtenciones.Location = new System.Drawing.Point(266, 0);
            this.lblTotAtenciones.Name = "lblTotAtenciones";
            this.lblTotAtenciones.Size = new System.Drawing.Size(51, 18);
            this.lblTotAtenciones.TabIndex = 44;
            this.lblTotAtenciones.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelGradient4
            // 
            this.labelGradient4.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelGradient4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGradient4.ForeColor = System.Drawing.Color.White;
            this.labelGradient4.GradientColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.labelGradient4.GradientColorTwo = System.Drawing.Color.White;
            this.labelGradient4.Location = new System.Drawing.Point(0, 0);
            this.labelGradient4.Name = "labelGradient4";
            this.labelGradient4.Size = new System.Drawing.Size(316, 18);
            this.labelGradient4.TabIndex = 0;
            this.labelGradient4.Text = "Atenciones reportadas a un cliente";
            this.labelGradient4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel7
            // 
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel7.Controls.Add(this.dgGadgets);
            this.panel7.Controls.Add(this.lblTotGadgets);
            this.panel7.Controls.Add(this.labelGradient3);
            this.panel7.Location = new System.Drawing.Point(2, 3);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(322, 149);
            this.panel7.TabIndex = 45;
            // 
            // dgGadgets
            // 
            this.dgGadgets.AllowSorting = false;
            this.dgGadgets.BackgroundColor = System.Drawing.Color.White;
            this.dgGadgets.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.dgGadgets.CaptionText = "Gadgets Reportados a un Cliente";
            this.dgGadgets.CaptionVisible = false;
            this.dgGadgets.DataMember = "";
            this.dgGadgets.HeaderBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgGadgets.HeaderForeColor = System.Drawing.Color.Black;
            this.dgGadgets.Location = new System.Drawing.Point(0, 21);
            this.dgGadgets.Name = "dgGadgets";
            this.dgGadgets.ReadOnly = true;
            this.dgGadgets.RowHeaderWidth = 15;
            this.dgGadgets.Size = new System.Drawing.Size(319, 123);
            this.dgGadgets.TabIndex = 0;
            this.dgGadgets.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle2});
            this.dgGadgets.CurrentCellChanged += new System.EventHandler(this.dgGadgets_CurrentCellChanged);
            // 
            // dataGridTableStyle2
            // 
            this.dataGridTableStyle2.AllowSorting = false;
            this.dataGridTableStyle2.DataGrid = this.dgGadgets;
            this.dataGridTableStyle2.HeaderBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridTableStyle2.HeaderForeColor = System.Drawing.Color.Black;
            this.dataGridTableStyle2.RowHeaderWidth = 15;
            // 
            // lblTotGadgets
            // 
            this.lblTotGadgets.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.lblTotGadgets.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotGadgets.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotGadgets.ForeColor = System.Drawing.Color.Black;
            this.lblTotGadgets.Location = new System.Drawing.Point(277, 0);
            this.lblTotGadgets.Name = "lblTotGadgets";
            this.lblTotGadgets.Size = new System.Drawing.Size(42, 18);
            this.lblTotGadgets.TabIndex = 43;
            this.lblTotGadgets.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelGradient3
            // 
            this.labelGradient3.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelGradient3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGradient3.ForeColor = System.Drawing.Color.White;
            this.labelGradient3.GradientColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.labelGradient3.GradientColorTwo = System.Drawing.Color.White;
            this.labelGradient3.Location = new System.Drawing.Point(0, 0);
            this.labelGradient3.Name = "labelGradient3";
            this.labelGradient3.Size = new System.Drawing.Size(318, 18);
            this.labelGradient3.TabIndex = 0;
            this.labelGradient3.Text = "Gadgets";
            this.labelGradient3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.btBuscarGadget);
            this.panel2.Controls.Add(this.txtsGadget);
            this.panel2.Controls.Add(this.nudCantidadGad);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(2, 181);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(323, 41);
            this.panel2.TabIndex = 1;
            // 
            // btBuscarGadget
            // 
            this.btBuscarGadget.Image = ((System.Drawing.Image)(resources.GetObject("btBuscarGadget.Image")));
            this.btBuscarGadget.Location = new System.Drawing.Point(232, 15);
            this.btBuscarGadget.Name = "btBuscarGadget";
            this.btBuscarGadget.Size = new System.Drawing.Size(21, 24);
            this.btBuscarGadget.TabIndex = 4;
            this.btBuscarGadget.TabStop = false;
            this.btBuscarGadget.UseVisualStyleBackColor = true;
            this.btBuscarGadget.Click += new System.EventHandler(this.btBuscarGadget_Click);
            // 
            // txtsGadget
            // 
            this.txtsGadget.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsGadget.ForeColor = System.Drawing.Color.Black;
            this.txtsGadget.Location = new System.Drawing.Point(2, 16);
            this.txtsGadget.MaxLength = 10;
            this.txtsGadget.Name = "txtsGadget";
            this.txtsGadget.Size = new System.Drawing.Size(231, 24);
            this.txtsGadget.TabIndex = 0;
            this.txtsGadget.Leave += new System.EventHandler(this.txtsGadget_Leave);
            // 
            // nudCantidadGad
            // 
            this.nudCantidadGad.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudCantidadGad.ForeColor = System.Drawing.Color.Black;
            this.nudCantidadGad.Location = new System.Drawing.Point(252, 16);
            this.nudCantidadGad.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudCantidadGad.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCantidadGad.Name = "nudCantidadGad";
            this.nudCantidadGad.Size = new System.Drawing.Size(66, 24);
            this.nudCantidadGad.TabIndex = 1;
            this.nudCantidadGad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudCantidadGad.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label3.Location = new System.Drawing.Point(241, -3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Cantidad:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label2.Location = new System.Drawing.Point(2, -3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Materiales:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel9
            // 
            this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel9.Controls.Add(this.panel4);
            this.panel9.Controls.Add(this.pnPedidos);
            this.panel9.Controls.Add(this.lblToolTipBtPed);
            this.panel9.Controls.Add(this.lblTotPedidos);
            this.panel9.Controls.Add(this.labelGradient5);
            this.panel9.Location = new System.Drawing.Point(648, 1);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(325, 229);
            this.panel9.TabIndex = 0;
            // 
            // lblToolTipBtPed
            // 
            this.lblToolTipBtPed.BackColor = System.Drawing.SystemColors.Info;
            this.lblToolTipBtPed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblToolTipBtPed.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToolTipBtPed.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblToolTipBtPed.Location = new System.Drawing.Point(0, 0);
            this.lblToolTipBtPed.Name = "lblToolTipBtPed";
            this.lblToolTipBtPed.Size = new System.Drawing.Size(10, 13);
            this.lblToolTipBtPed.TabIndex = 77;
            this.lblToolTipBtPed.Text = "O";
            this.lblToolTipBtPed.Visible = false;
            // 
            // lblTotPedidos
            // 
            this.lblTotPedidos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.lblTotPedidos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotPedidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotPedidos.ForeColor = System.Drawing.Color.Black;
            this.lblTotPedidos.Location = new System.Drawing.Point(269, -1);
            this.lblTotPedidos.Name = "lblTotPedidos";
            this.lblTotPedidos.Size = new System.Drawing.Size(51, 20);
            this.lblTotPedidos.TabIndex = 5;
            this.lblTotPedidos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelGradient5
            // 
            this.labelGradient5.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelGradient5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGradient5.ForeColor = System.Drawing.Color.White;
            this.labelGradient5.GradientColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.labelGradient5.GradientColorTwo = System.Drawing.Color.White;
            this.labelGradient5.Location = new System.Drawing.Point(0, 0);
            this.labelGradient5.Name = "labelGradient5";
            this.labelGradient5.Size = new System.Drawing.Size(321, 21);
            this.labelGradient5.TabIndex = 0;
            this.labelGradient5.Text = "Pedidos Asociados a un Cliente";
            this.labelGradient5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.txtClienteSAP);
            this.panel1.Controls.Add(this.cbSustituto);
            this.panel1.Controls.Add(this.btBuscarCliente);
            this.panel1.Controls.Add(this.btClienteEliminar);
            this.panel1.Controls.Add(this.btClienteActualizar);
            this.panel1.Controls.Add(this.txtsCliente);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txtClienteObserv);
            this.panel1.Controls.Add(this.txtClienteObjetivo);
            this.panel1.Controls.Add(this.txtClienteProxObj);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(620, 67);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(900, 219);
            this.panel1.TabIndex = 2;
            // 
            // cbSustituto
            // 
            this.cbSustituto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSustituto.ForeColor = System.Drawing.Color.Black;
            this.cbSustituto.Location = new System.Drawing.Point(553, 15);
            this.cbSustituto.Name = "cbSustituto";
            this.cbSustituto.Size = new System.Drawing.Size(161, 21);
            this.cbSustituto.TabIndex = 1;
            this.cbSustituto.Text = "Sustituto";
            // 
            // txtClienteObserv
            // 
            this.txtClienteObserv.BackColor = System.Drawing.Color.White;
            this.txtClienteObserv.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClienteObserv.ForeColor = System.Drawing.Color.Black;
            this.txtClienteObserv.Location = new System.Drawing.Point(2, 66);
            this.txtClienteObserv.MaxLength = 8000;
            this.txtClienteObserv.Multiline = true;
            this.txtClienteObserv.Name = "txtClienteObserv";
            this.txtClienteObserv.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtClienteObserv.Size = new System.Drawing.Size(230, 144);
            this.txtClienteObserv.TabIndex = 2;
            // 
            // txtClienteObjetivo
            // 
            this.txtClienteObjetivo.BackColor = System.Drawing.Color.White;
            this.txtClienteObjetivo.Enabled = false;
            this.txtClienteObjetivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClienteObjetivo.ForeColor = System.Drawing.Color.Black;
            this.txtClienteObjetivo.Location = new System.Drawing.Point(243, 66);
            this.txtClienteObjetivo.MaxLength = 8000;
            this.txtClienteObjetivo.Multiline = true;
            this.txtClienteObjetivo.Name = "txtClienteObjetivo";
            this.txtClienteObjetivo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtClienteObjetivo.Size = new System.Drawing.Size(230, 144);
            this.txtClienteObjetivo.TabIndex = 3;
            // 
            // txtClienteProxObj
            // 
            this.txtClienteProxObj.BackColor = System.Drawing.Color.White;
            this.txtClienteProxObj.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClienteProxObj.ForeColor = System.Drawing.Color.Black;
            this.txtClienteProxObj.Location = new System.Drawing.Point(485, 66);
            this.txtClienteProxObj.MaxLength = 8000;
            this.txtClienteProxObj.Multiline = true;
            this.txtClienteProxObj.Name = "txtClienteProxObj";
            this.txtClienteProxObj.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtClienteProxObj.Size = new System.Drawing.Size(230, 143);
            this.txtClienteProxObj.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(2, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(139, 21);
            this.label7.TabIndex = 53;
            this.label7.Text = "Observaciones:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(243, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 19);
            this.label4.TabIndex = 51;
            this.label4.Text = "Objetivo:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(485, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 19);
            this.label1.TabIndex = 52;
            this.label1.Text = "Próx. Obj.:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sqldaRepActAtenciones
            // 
            this.sqldaRepActAtenciones.SelectCommand = this.sqlSelectCommand1;
            this.sqldaRepActAtenciones.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
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
                        new System.Data.Common.DataColumnMapping("sTipoAtencion", "sTipoAtencion"),
                        new System.Data.Common.DataColumnMapping("bEnviadoCEN", "bEnviadoCEN")})});
            // 
            // sqlSelectCommand1
            // 
            this.sqlSelectCommand1.CommandText = "[ListaRepActividAtenciones]";
            this.sqlSelectCommand1.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand1.Connection = this.sqlConn;
            this.sqlSelectCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdReport", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4)});
            // 
            // sqldaRepActPedidos
            // 
            this.sqldaRepActPedidos.SelectCommand = this.sqlSelectCommand7;
            this.sqldaRepActPedidos.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaRepActividPedidos", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iIdReport", "iIdReport"),
                        new System.Data.Common.DataColumnMapping("sIdPedido", "sIdPedido"),
                        new System.Data.Common.DataColumnMapping("sIdTipoPedido", "sIdTipoPedido"),
                        new System.Data.Common.DataColumnMapping("dFechaPedido", "dFechaPedido"),
                        new System.Data.Common.DataColumnMapping("tFechaPedido", "tFechaPedido"),
                        new System.Data.Common.DataColumnMapping("Boton", "Boton")})});
            // 
            // sqlSelectCommand7
            // 
            this.sqlSelectCommand7.CommandText = "[ListaRepActividPedidos]";
            this.sqlSelectCommand7.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand7.Connection = this.sqlConn;
            this.sqlSelectCommand7.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdReport", System.Data.SqlDbType.Int, 4)});
            // 
            // sqldaPedidosAsignables
            // 
            this.sqldaPedidosAsignables.SelectCommand = this.sqlSelectCommand8;
            this.sqldaPedidosAsignables.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaPedidosAsignables", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("sIdPedido", "sIdPedido"),
                        new System.Data.Common.DataColumnMapping("tPedido", "tPedido"),
                        new System.Data.Common.DataColumnMapping("dFechaPedido", "dFechaPedido"),
                        new System.Data.Common.DataColumnMapping("tFechaPedido", "tFechaPedido"),
                        new System.Data.Common.DataColumnMapping("sIdTipoPedido", "sIdTipoPedido")})});
            // 
            // sqlSelectCommand8
            // 
            this.sqlSelectCommand8.CommandText = "[ListaPedidosAsignables]";
            this.sqlSelectCommand8.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand8.Connection = this.sqlConn;
            this.sqlSelectCommand8.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdDelegado", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sIdCliente", System.Data.SqlDbType.VarChar, 20),
            new System.Data.SqlClient.SqlParameter("@iIdReport", System.Data.SqlDbType.Int, 4)});
            // 
            // sqlcmdSetRepActividad_Cab
            // 
            this.sqlcmdSetRepActividad_Cab.CommandText = "[SetRepActividad_Cab]";
            this.sqlcmdSetRepActividad_Cab.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlcmdSetRepActividad_Cab.Connection = this.sqlConn;
            this.sqlcmdSetRepActividad_Cab.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@Accion", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdReport", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.InputOutput, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdDelegado", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sIdReportTemp", System.Data.SqlDbType.VarChar, 15, System.Data.ParameterDirection.Output, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@sTipoRActividad", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@sIdTipoCliente", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@iIdCentro", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@dFecha", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@iHorario", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@tObjetivo", System.Data.SqlDbType.VarChar, 2147483647),
            new System.Data.SqlClient.SqlParameter("@tProxObjetivo", System.Data.SqlDbType.VarChar, 2147483647),
            new System.Data.SqlClient.SqlParameter("@tObservaciones", System.Data.SqlDbType.VarChar, 2147483647),
            new System.Data.SqlClient.SqlParameter("@bPlanificacion", System.Data.SqlDbType.SmallInt, 2),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt, 2),
            new System.Data.SqlClient.SqlParameter("@dHoraInicio", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@dHoraFin", System.Data.SqlDbType.DateTime, 8)});
            // 
            // sqlcmdSetRepActividad_Cli
            // 
            this.sqlcmdSetRepActividad_Cli.CommandText = "[SetRepActividad_Cli]";
            this.sqlcmdSetRepActividad_Cli.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlcmdSetRepActividad_Cli.Connection = this.sqlConn;
            this.sqlcmdSetRepActividad_Cli.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@Accion", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdReport", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@tObservaciones", System.Data.SqlDbType.VarChar, 8000),
            new System.Data.SqlClient.SqlParameter("@tObjetivos", System.Data.SqlDbType.VarChar, 8000),
            new System.Data.SqlClient.SqlParameter("@tProxObj", System.Data.SqlDbType.VarChar, 8000),
            new System.Data.SqlClient.SqlParameter("@bSustituto", System.Data.SqlDbType.Bit, 1),
            new System.Data.SqlClient.SqlParameter("@sIdRed", System.Data.SqlDbType.VarChar, 4)});
            // 
            // sqlcmdSetRepActividad_Aten
            // 
            this.sqlcmdSetRepActividad_Aten.CommandText = "[SetRepActividad_Aten]";
            this.sqlcmdSetRepActividad_Aten.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlcmdSetRepActividad_Aten.Connection = this.sqlConn;
            this.sqlcmdSetRepActividad_Aten.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@Accion", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdReport", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdAtencion", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iNumAtencion", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@fImporte", System.Data.SqlDbType.Float, 8)});
            // 
            // sqlcmdSetRepActividad_Ped
            // 
            this.sqlcmdSetRepActividad_Ped.CommandText = "[SetRepActividad_Ped]";
            this.sqlcmdSetRepActividad_Ped.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlcmdSetRepActividad_Ped.Connection = this.sqlConn;
            this.sqlcmdSetRepActividad_Ped.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@Accion", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdReport", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sIdPedido", System.Data.SqlDbType.VarChar, 12)});
            // 
            // sqlcmdSetRepActividad_Gad
            // 
            this.sqlcmdSetRepActividad_Gad.CommandText = "[SetRepActividad_Gad]";
            this.sqlcmdSetRepActividad_Gad.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlcmdSetRepActividad_Gad.Connection = this.sqlConn;
            this.sqlcmdSetRepActividad_Gad.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@Accion", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdReport", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdGadget", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iCantidad", System.Data.SqlDbType.Int, 4)});
            // 
            // sqlcmdSetRepActividad_Prom
            // 
            this.sqlcmdSetRepActividad_Prom.CommandText = "[SetRepActividad_Prom]";
            this.sqlcmdSetRepActividad_Prom.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlcmdSetRepActividad_Prom.Connection = this.sqlConn;
            this.sqlcmdSetRepActividad_Prom.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@Accion", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdReport", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sIdProducto", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@iCantidad", System.Data.SqlDbType.SmallInt, 2),
            new System.Data.SqlClient.SqlParameter("@iOrden", System.Data.SqlDbType.Int, 4)});
            // 
            // cmClientes
            // 
            this.cmClientes.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnNuevoCli,
            this.mnEliminarCli});
            // 
            // mnNuevoCli
            // 
            this.mnNuevoCli.Index = 0;
            this.mnNuevoCli.Shortcut = System.Windows.Forms.Shortcut.CtrlN;
            this.mnNuevoCli.Text = "Nuevo";
            this.mnNuevoCli.Click += new System.EventHandler(this.mnNuevoCli_Click);
            // 
            // mnEliminarCli
            // 
            this.mnEliminarCli.Index = 1;
            this.mnEliminarCli.Shortcut = System.Windows.Forms.Shortcut.CtrlX;
            this.mnEliminarCli.Text = "Eliminar";
            this.mnEliminarCli.Click += new System.EventHandler(this.mnEliminarCli_Click);
            // 
            // sqlcmdSetRepActividadCli_ProxObj
            // 
            this.sqlcmdSetRepActividadCli_ProxObj.CommandText = "[SetRepActividadCli_ProxObj]";
            this.sqlcmdSetRepActividadCli_ProxObj.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlcmdSetRepActividadCli_ProxObj.Connection = this.sqlConn;
            this.sqlcmdSetRepActividadCli_ProxObj.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@Accion", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdReport", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdCentro", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@tProxObj", System.Data.SqlDbType.VarChar, 8000),
            new System.Data.SqlClient.SqlParameter("@dFecha", System.Data.SqlDbType.DateTime, 8)});
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
            // ucBotoneraSecundaria1
            // 
            this.ucBotoneraSecundaria1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(117)))), ((int)(((byte)(1)))));
            this.ucBotoneraSecundaria1.ForeColor = System.Drawing.Color.Black;
            this.ucBotoneraSecundaria1.Location = new System.Drawing.Point(1, 2);
            this.ucBotoneraSecundaria1.Name = "ucBotoneraSecundaria1";
            this.ucBotoneraSecundaria1.Size = new System.Drawing.Size(1535, 36);
            this.ucBotoneraSecundaria1.TabIndex = 5;
            // 
            // sqlcomdSetRepActividad_ImporteReal_Aten
            // 
            this.sqlcomdSetRepActividad_ImporteReal_Aten.CommandText = "[SetRepActividad_ImporteReal_Aten]";
            this.sqlcomdSetRepActividad_ImporteReal_Aten.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlcomdSetRepActividad_ImporteReal_Aten.Connection = this.sqlConn;
            this.sqlcomdSetRepActividad_ImporteReal_Aten.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdAtencion", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@fImporteReal", System.Data.SqlDbType.Float, 8),
            new System.Data.SqlClient.SqlParameter("@dFechaCierre", System.Data.SqlDbType.DateTime, 8)});
            // 
            // cmGadgets
            // 
            this.cmGadgets.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnNuevoGad,
            this.mnEliminarGad});
            // 
            // mnNuevoGad
            // 
            this.mnNuevoGad.Index = 0;
            this.mnNuevoGad.Shortcut = System.Windows.Forms.Shortcut.CtrlN;
            this.mnNuevoGad.Text = "Nuevo";
            this.mnNuevoGad.Click += new System.EventHandler(this.mnNuevoGad_Click);
            // 
            // mnEliminarGad
            // 
            this.mnEliminarGad.Index = 1;
            this.mnEliminarGad.Shortcut = System.Windows.Forms.Shortcut.CtrlX;
            this.mnEliminarGad.Text = "Eliminar";
            this.mnEliminarGad.Click += new System.EventHandler(this.mnEliminarGad_Click);
            // 
            // cmAtenciones
            // 
            this.cmAtenciones.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnNuevoAten,
            this.mnEliminarAten});
            // 
            // mnNuevoAten
            // 
            this.mnNuevoAten.Index = 0;
            this.mnNuevoAten.Shortcut = System.Windows.Forms.Shortcut.CtrlN;
            this.mnNuevoAten.Text = "Nuevo";
            this.mnNuevoAten.Click += new System.EventHandler(this.mnNuevoAten_Click);
            // 
            // mnEliminarAten
            // 
            this.mnEliminarAten.Index = 1;
            this.mnEliminarAten.Shortcut = System.Windows.Forms.Shortcut.CtrlX;
            this.mnEliminarAten.Text = "Eliminar";
            this.mnEliminarAten.Click += new System.EventHandler(this.mnEliminarAten_Click);
            // 
            // cmPedidos
            // 
            this.cmPedidos.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnNuevoPed,
            this.mnEliminarPed});
            // 
            // mnNuevoPed
            // 
            this.mnNuevoPed.Index = 0;
            this.mnNuevoPed.Shortcut = System.Windows.Forms.Shortcut.CtrlN;
            this.mnNuevoPed.Text = "Nuevo";
            this.mnNuevoPed.Click += new System.EventHandler(this.mnNuevoPed_Click);
            // 
            // mnEliminarPed
            // 
            this.mnEliminarPed.Index = 1;
            this.mnEliminarPed.Shortcut = System.Windows.Forms.Shortcut.CtrlX;
            this.mnEliminarPed.Text = "Eliminar";
            this.mnEliminarPed.Click += new System.EventHandler(this.mnEliminarPed_Click);
            // 
            // cmProductos
            // 
            this.cmProductos.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnNuevoProd,
            this.mnEliminarProd});
            // 
            // mnNuevoProd
            // 
            this.mnNuevoProd.Index = 0;
            this.mnNuevoProd.Shortcut = System.Windows.Forms.Shortcut.CtrlN;
            this.mnNuevoProd.Text = "Nuevo";
            this.mnNuevoProd.Click += new System.EventHandler(this.mnNuevoProd_Click);
            // 
            // mnEliminarProd
            // 
            this.mnEliminarProd.Index = 1;
            this.mnEliminarProd.Shortcut = System.Windows.Forms.Shortcut.CtrlX;
            this.mnEliminarProd.Text = "Eliminar";
            this.mnEliminarProd.Click += new System.EventHandler(this.mnEliminarProd_Click);
            // 
            // dsBuscar1
            // 
            this.dsBuscar1.DataSetName = "dsBuscar";
            this.dsBuscar1.Locale = new System.Globalization.CultureInfo("es-ES");
            this.dsBuscar1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // listaBuscarProductosBindingSource
            // 
            this.listaBuscarProductosBindingSource.DataMember = "ListaBuscarProductos";
            this.listaBuscarProductosBindingSource.DataSource = this.dsBuscar1;
            // 
            // listaPromocionProdBindingSource
            // 
            this.listaPromocionProdBindingSource.DataMember = "ListaPromocionProd";
            this.listaPromocionProdBindingSource.DataSource = this.dsReports1;
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.HeaderText = "Cantidad";
            this.dataGridTextBoxColumn3.MappingName = "iCantidad";
            this.dataGridTextBoxColumn3.NullText = "";
            this.dataGridTextBoxColumn3.Width = 75;
            // 
            // dataGridTextBoxColumn7
            // 
            this.dataGridTextBoxColumn7.Format = "";
            this.dataGridTextBoxColumn7.FormatInfo = null;
            this.dataGridTextBoxColumn7.HeaderText = "Código";
            this.dataGridTextBoxColumn7.MappingName = "sDescripcion";
            this.dataGridTextBoxColumn7.NullText = "";
            this.dataGridTextBoxColumn7.Width = 280;
            // 
            // dataGridTextBoxColumn36
            // 
            this.dataGridTextBoxColumn36.Format = "";
            this.dataGridTextBoxColumn36.FormatInfo = null;
            this.dataGridTextBoxColumn36.MappingName = "bEnviadoCEN";
            this.dataGridTextBoxColumn36.NullText = "";
            this.dataGridTextBoxColumn36.Width = 0;
            // 
            // dataGridTextBoxColumn35
            // 
            this.dataGridTextBoxColumn35.Format = "";
            this.dataGridTextBoxColumn35.FormatInfo = null;
            this.dataGridTextBoxColumn35.MappingName = "sIdTipoAtencion";
            this.dataGridTextBoxColumn35.NullText = "";
            this.dataGridTextBoxColumn35.Width = 0;
            // 
            // dataGridTextBoxColumn23
            // 
            this.dataGridTextBoxColumn23.Format = "";
            this.dataGridTextBoxColumn23.FormatInfo = null;
            this.dataGridTextBoxColumn23.MappingName = "iIdAtencion";
            this.dataGridTextBoxColumn23.NullText = "";
            this.dataGridTextBoxColumn23.Width = 0;
            // 
            // dataGridTextBoxColumn22
            // 
            this.dataGridTextBoxColumn22.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn22.Format = "N2";
            this.dataGridTextBoxColumn22.FormatInfo = null;
            this.dataGridTextBoxColumn22.MappingName = "fImporteReal";
            this.dataGridTextBoxColumn22.NullText = "";
            this.dataGridTextBoxColumn22.Width = 0;
            // 
            // dataGridTextBoxColumn21
            // 
            this.dataGridTextBoxColumn21.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn21.Format = "N2";
            this.dataGridTextBoxColumn21.FormatInfo = null;
            this.dataGridTextBoxColumn21.HeaderText = "Imp. Prev.";
            this.dataGridTextBoxColumn21.MappingName = "fImportePrev";
            this.dataGridTextBoxColumn21.NullText = "";
            this.dataGridTextBoxColumn21.Width = 60;
            // 
            // dataGridTextBoxColumn20
            // 
            this.dataGridTextBoxColumn20.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn20.Format = "N2";
            this.dataGridTextBoxColumn20.FormatInfo = null;
            this.dataGridTextBoxColumn20.HeaderText = "Imp. Cliente";
            this.dataGridTextBoxColumn20.MappingName = "fImporte";
            this.dataGridTextBoxColumn20.NullText = "";
            this.dataGridTextBoxColumn20.Width = 65;
            // 
            // dataGridTextBoxColumn34
            // 
            this.dataGridTextBoxColumn34.Format = "";
            this.dataGridTextBoxColumn34.FormatInfo = null;
            this.dataGridTextBoxColumn34.HeaderText = "Tipo";
            this.dataGridTextBoxColumn34.MappingName = "sTipoAtencion";
            this.dataGridTextBoxColumn34.NullText = "";
            this.dataGridTextBoxColumn34.Width = 70;
            // 
            // dataGridTextBoxColumn33
            // 
            this.dataGridTextBoxColumn33.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.dataGridTextBoxColumn33.Format = "";
            this.dataGridTextBoxColumn33.FormatInfo = null;
            this.dataGridTextBoxColumn33.HeaderText = "Núm.";
            this.dataGridTextBoxColumn33.MappingName = "iNumAtencion";
            this.dataGridTextBoxColumn33.NullText = "";
            this.dataGridTextBoxColumn33.Width = 30;
            // 
            // dataGridTextBoxColumn10
            // 
            this.dataGridTextBoxColumn10.Format = "";
            this.dataGridTextBoxColumn10.FormatInfo = null;
            this.dataGridTextBoxColumn10.HeaderText = "Código";
            this.dataGridTextBoxColumn10.MappingName = "sIdAtencion";
            this.dataGridTextBoxColumn10.NullText = "";
            this.dataGridTextBoxColumn10.Width = 110;
            // 
            // dtgsSelected
            // 
            this.dtgsSelected.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.dtgsSelected.Format = "";
            this.dtgsSelected.FormatInfo = null;
            this.dtgsSelected.Width = 50;
            // 
            // dtgiIdCliente
            // 
            this.dtgiIdCliente.Format = "";
            this.dtgiIdCliente.FormatInfo = null;
            this.dtgiIdCliente.MappingName = "iIdCliente";
            this.dtgiIdCliente.ReadOnly = true;
            this.dtgiIdCliente.Width = 0;
            // 
            // dtgsProducto
            // 
            this.dtgsProducto.Format = "";
            this.dtgsProducto.FormatInfo = null;
            this.dtgsProducto.HeaderText = "IdProducto";
            this.dtgsProducto.MappingName = "sIdProducto";
            this.dtgsProducto.ReadOnly = true;
            this.dtgsProducto.Width = 0;
            // 
            // dtgCant
            // 
            this.dtgCant.Format = "";
            this.dtgCant.FormatInfo = null;
            this.dtgCant.HeaderText = "Cant";
            this.dtgCant.MappingName = "iCantidad";
            this.dtgCant.Width = 40;
            // 
            // dtgOrden
            // 
            this.dtgOrden.Format = "";
            this.dtgOrden.FormatInfo = null;
            this.dtgOrden.HeaderText = "Orden";
            this.dtgOrden.MappingName = "Orden";
            this.dtgOrden.ReadOnly = true;
            this.dtgOrden.Width = 40;
            // 
            // dtgsDescripcion
            // 
            this.dtgsDescripcion.Format = "";
            this.dtgsDescripcion.FormatInfo = null;
            this.dtgsDescripcion.HeaderText = "Producto";
            this.dtgsDescripcion.MappingName = "sDescripcion";
            this.dtgsDescripcion.ReadOnly = true;
            this.dtgsDescripcion.Width = 125;
            // 
            // btEncuestas
            // 
            this.btEncuestas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btEncuestas.ForeColor = System.Drawing.Color.Black;
            this.btEncuestas.Location = new System.Drawing.Point(1393, 10);
            this.btEncuestas.Name = "btEncuestas";
            this.btEncuestas.Size = new System.Drawing.Size(122, 45);
            this.btEncuestas.TabIndex = 90;
            this.btEncuestas.Text = "Encuestas";
            this.btEncuestas.UseVisualStyleBackColor = true;
            this.btEncuestas.Click += new System.EventHandler(this.btEncuestas_Click);
            // 
            // frmReporting
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.ClientSize = new System.Drawing.Size(1548, 882);
            this.Controls.Add(this.ucBotoneraSecundaria1);
            this.Controls.Add(this.pnClientesVisitados);
            this.Controls.Add(this.pnReportActiv);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmReporting";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporting";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmReporting_Closing);
            this.Closed += new System.EventHandler(this.frmReporting_Closed);
            this.Load += new System.EventHandler(this.frmReporting_Load);
            this.pnReportActiv.ResumeLayout(false);
            this.pnReportActiv.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsReports1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgClientes)).EndInit();
            this.pnPedidos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgPedidos)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listaPromocionProdBindingSource1)).EndInit();
            this.pnClientesVisitados.ResumeLayout(false);
            this.pnClientesVisitados.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.pnDatosClientesPlanif.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgClientesProxObj)).EndInit();
            this.pnDatosClienteVisita.ResumeLayout(false);
            this.pnProductosProm.ResumeLayout(false);
            this.pnAceptarPromo.ResumeLayout(false);
            this.pnAceptarPromo.PerformLayout();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGVProductosPromo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgProductos)).EndInit();
            this.pnProductos.ResumeLayout(false);
            this.pnProductos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudiMuestras)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudiOrden)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupImporteCli)).EndInit();
            this.pnTodaAtencion.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgAtenciones)).EndInit();
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgGadgets)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidadGad)).EndInit();
            this.panel9.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsBuscar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listaBuscarProductosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listaPromocionProdBindingSource)).EndInit();
            this.ResumeLayout(false);

        }
		#endregion


		#region frmReporting_Load
		private void frmReporting_Load(object sender, System.EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;

			try
			{
				GESTCRM.Utiles.Formato_Formulario(this);

				if(this.Parent == null) this.WindowState = FormWindowState.Normal;


				//En altas y modificaciones el delegado viene fijado de configuración 
				this.txtsDelegado.Text = GESTCRM.Utiles.NombreDeleg(this.ParamiIdDelegado);

				if(GESTCRM.Clases.Configuracion.iGVisitas==1) this.ParamTipoAcceso="C";
				
				Inicializar_dtClientes();
				Inicializar_dtProductos(); 
				Inicializar_dtGadgets();
				Inicializar_dtAtenciones();
				Inicializar_dtPedidos();
				Inicializar_dtSiNo();
                //---- GSG (30/08/2011) 
                Inicializar_dtClienteHora();
                //---- FI GSG

				Inicializar_Combos();

				this.pnClientesVisitados.Visible=true;
                //---- GSG (09/03/2015)
                //this.pnClientesVisitados.Width= 940;
                //this.pnClientesVisitados.Height = 455;

                //---- GSG (13/03/2019)
				//this.pnDatosClienteVisita.Location = new Point(2,216);
				//this.pnDatosClientesPlanif.Location = new Point(2,216);
                this.pnDatosClienteVisita.Location = new Point(2, 300); //246
                this.pnDatosClientesPlanif.Location = new Point(2, 300);
                this.pnClientesVisitados.Height = 540;

                this.pnDatosClientesPlanif.Visible = false;
				this.pnPedidos.Visible=false;
                lblActProdProm.Visible = false; //---- GSG (27/02/2015)

				this.Temp_iIdGadget=-1;
				this.Var_iIdAtencion=-1;
				this.Var_iIdCentro=-1;

				if(this.ParamTipoAcceso=="A") //Alta
				{
					this.cbTipoRActibidad.SelectedValue="1";//Tipo Report = Visita

                    //---- GSG (27/06/2013)
					//this.cbTipoCliente.SelectedValue="C";	//Tipo Cliente = ClienteCOM
                    this.cbTipoCliente.SelectedValue = "S"; //Cliente sap
                    Activa_Centro(false);
                    //---- FI GSG

					//this.cbHorario.SelectedValue="0";		//Horario = Mañana
                    cbHorario.SelectedIndex = 0;
					//Fecha recibida conmo parámetro
					//Desde menú se pasa el día actual
					//Desde planificación puede recibir cualquier día
					this.dtpFecha.Value=this.ParamFecha.Date;
					if (this.dtpFecha.Value.Date > DateTime.Today.Date) //Planificar Visita
					{
						this.Var_bPlanificacion = 1;
					}
					else
					{
						this.Var_bPlanificacion = 0;
					}
				}
				else //Modificación o Consulta
				{
					Recuperar_RepActividadCab();
				}

                Cargar_dgGadgets();
                Cargar_dgAtenciones();
                
                //---- GSG (30/08/2011) ATENCIO: Ha d'anar abans de Cargar_dgClientes();
                if (this.cbTipoCliente.SelectedValue.ToString() == "S") //ClienteSAP
                {
                    this.dtClienteHoraDg.Rows.Clear();
    }
                //---- FI GSG

                //---- GSG (14/06/2017) 
                //Cargar_dgProductosGrid(); //---- GSG (27/02/2015) 
                Cargar_dgProductosGrid(-1);

                Cargar_dgProductos();  

                Cargar_dgClientes();

               
                             

                //ATENCIO: Ha d'anar després de Cargar_dgClientes();
                Cargar_dgPedidos();

				Inicializar_DataGrid();



				//Un delegado no se puede Crear ni Modificar Reports de otros delegados 
				if(GESTCRM.Clases.Configuracion.iIdDelegado!=this.ParamiIdDelegado) 
                    this.ParamTipoAcceso="C";
			
				//No se pueden modificar Reports activos con fecha inferior o igual a la actual
				//que ya han sido enviados a Central
				//Si se permite modificar Reports activos con fecha superior a la actual, hayan sido
				//enviados o no a Central
				if(this.ParamTipoAcceso=="M" && (this.Var_iEstado!=0 || (this.Var_bEnviadoCEN==1 && this.Var_bPlanificacion==0)))
				{
					this.ParamTipoAcceso = "C";
				}

				//En función del Tipo de acceso se activan/inactivan campos del formulario
                Activar_Formulario();
                 
                

				if(this.Var_bPlanificacion ==0 ) //Creando un Report
				{
					if(this.dtClientesDg.Rows.Count > 0)
					{
						this.dgClientes.Focus();
						this.dgClientes.CurrentRowIndex=0;
						Utiles.Seleccionar_UnaFilaDataGrid(this,this.dgClientes,0);
						Cargar_dgGadgets_Cliente(this.dgClientes[this.dgClientes.CurrentRowIndex,0].ToString(),this.dgClientes[this.dgClientes.CurrentRowIndex,1].ToString());
						Cargar_dgAtenciones_Cliente(this.dgClientes[this.dgClientes.CurrentRowIndex,0].ToString(),this.dgClientes[this.dgClientes.CurrentRowIndex,1].ToString());
                        //---- GSG (13/10/2011) 
                        Cargar_dgPedidos_Cliente(this.dgClientes[this.dgClientes.CurrentRowIndex, 0].ToString(), this.dgClientes[this.dgClientes.CurrentRowIndex, 1].ToString());
                        //---- FI GSG


                        if (this.cbTipoCliente.SelectedValue.ToString()=="S")
						{
                            //---- GSG (13/10/2011) 
                            //LlenarCombo_cbPedidos();
                            LlenarCombo_cbPedidos(this.dgClientes.CurrentRowIndex);
                            //---- FI GSG
						}
					}
				}
				else
				{
					if(this.Var_iIdCentro!=-1)
					{
						Cargar_dgClientesProxObj();
					}
				}


                //this.dgProductos.DataSource=this.dtProductosDg;

                Inicializar_Botonera();

				//this.lblTotProductos.Text = dsReports1.ListaPromocionProd.Rows.Count.ToString();

				this.Temp_iIdCliente=-1;

                //if(this.ParamTipoAcceso=="C")
                //{
                //    this.cmPedidos.Dispose();
                //    this.cmProductos.Dispose();
                //    this.cmAtenciones.Dispose();
                //    this.cmGadgets.Dispose();
                //    this.cmClientes.Dispose();
                //}

				this.SalirDesdeGuardar=false;

                //RH
                dtpHoraInicio.Left = txbHoraInicio.Left;
                dtpHoraInicio.Top = txbHoraInicio.Top;
                dtpHoraInicio.Width = txbHoraInicio.Width;
                dtpHoraInicio.Height = txbHoraInicio.Height;

                dtpHoraFin.Left = txbHoraFin.Left;
                dtpHoraFin.Top = txbHoraFin.Top;
                dtpHoraFin.Width = txbHoraFin.Width;
                dtpHoraFin.Height = txbHoraFin.Height;



            }
            catch (Exception ex)
            {
                Mensajes.ShowError(ex.Message);
            }

			Cursor.Current = Cursors.Default;

		}

		#endregion



		#region Inicializar_Botonera
		private void Inicializar_Botonera()
		{
			try
			{
				if(this.ParamTipoAcceso=="C")
				{
					this.ucBotoneraSecundaria1.Activar_botonera(true,false,false,false,false,false);
				}
				else
				{
					this.ucBotoneraSecundaria1.Activar_botonera(true,false,false,false,true,false);
				}
                this.ucBotoneraSecundaria1.btSalir.Click += new EventHandler(btSalir_Click);
                this.ucBotoneraSecundaria1.btGrabar.Click += new EventHandler(btGrabar_Click);
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region Inicializar_Combos()
		private void Inicializar_Combos()
		{
			try
			{

				//cbHorario
				this.sqldaTipoHorarioRep.Fill(this.dsReports1);

				//cbTipoRActividad
				this.sqldaTipoRActividad.Fill(this.dsReports1);
                //if (cbTipoRActibidad.Items.Count > 0)
                //    cbTipoRActibidad.SelectedIndex = 0;

				//cbTipoCliente
				this.sqldaTipoCliente.Fill(this.dsReports1);
                //if (cbTipoCliente.Items.Count > 0)
                //    cbTipoCliente.SelectedIndex = 0;

			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region LlenarCombo_cbPedidos()
        //---- GSG (13/10/2011)
		//private void LlenarCombo_cbPedidos()
        private void LlenarCombo_cbPedidos(int fila)
        //---- FI GSG
		{
			try
			{
				if(this.dtClientesDg.Rows.Count>0)
				{
					this.dsReports1.ListaPedidosAsignables.Rows.Clear();

					this.sqldaPedidosAsignables.SelectCommand.Parameters["@iIdDelegado"].Value=this.ParamiIdDelegado;
                    //---- GSG (13/10/2011)
					//this.sqldaPedidosAsignables.SelectCommand.Parameters["@sIdCliente"].Value=this.dgClientes[0,0].ToString();
                    this.sqldaPedidosAsignables.SelectCommand.Parameters["@sIdCliente"].Value = this.dgClientes[fila, 0].ToString();
                    //---- FI GSG
                    this.sqldaPedidosAsignables.SelectCommand.Parameters["@iIdReport"].Value=this.ParamIdReport;
					this.sqldaPedidosAsignables.Fill(this.dsReports1);
					this.cbPedidos.SelectedIndex=-1;
					this.cbPedidos.SelectedIndex=-1;
				}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region Inicializar_dtSiNo()
		private void Inicializar_dtSiNo()
		{
			try
			{
				this.dtSiNo = new DataTable();
				this.dtSiNo.Columns.Add("Valor");
				this.dtSiNo.Columns.Add("Descripcion");
				DataRow filaNo = this.dtSiNo.NewRow();
				filaNo["Valor"]=0;
				filaNo["Descripcion"]="NO";
				this.dtSiNo.Rows.Add(filaNo);
				DataRow filaSi = this.dtSiNo.NewRow();
				filaSi["Valor"]=1;
				filaSi["Descripcion"]="SI";
				this.dtSiNo.Rows.Add(filaSi);
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region Inicializar_dtProductos()
		private void Inicializar_dtProductos()
		{
			try
			{
				this.dtProductosDg = new DataTable();

                //---- GSG (23/02/2015)
                //this.dtProductosDg.Columns.Add("sIdProducto");
                //this.dtProductosDg.Columns.Add("tProducto");
                //this.dtProductosDg.Columns.Add("iIdPromocion");
                //this.dtProductosDg.Columns.Add("bPromociona");
                //this.dtProductosDg.Columns.Add("tPromociona");
                //this.dtProductosDg.Columns.Add("iOrden");
                //this.dtProductosDg.Columns.Add("iMuestras");

                this.dtProductosDg.Columns.Add("sDescripcion");
                this.dtProductosDg.Columns.Add("Orden");
                this.dtProductosDg.Columns.Add("iCantidad");
                this.dtProductosDg.Columns.Add("sIdProducto");
                this.dtProductosDg.Columns.Add("iIdCliente");
                this.dtProductosDg.Columns.Add("bSelected");

                this.dtProductosRep = new DataTable();
                this.dtProductosRep.Columns.Add("iIdReport");
                this.dtProductosRep.Columns.Add("iIdCliente");
                this.dtProductosRep.Columns.Add("sIdProducto");
                this.dtProductosRep.Columns.Add("iCantidad");
                this.dtProductosRep.Columns.Add("Orden");
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region Inicializar_dtClientes()
		private void Inicializar_dtClientes()
		{
			try
			{
				this.dtClientesDg = new DataTable();
				this.dtClientesDg.Columns.Add("sIdCliente");
				this.dtClientesDg.Columns.Add("sNombre");
				this.dtClientesDg.Columns.Add("iIdCliente");
				this.dtClientesDg.Columns.Add("bSustituto");
				this.dtClientesDg.Columns.Add("tSustituto");
				this.dtClientesDg.Columns.Add("tObservaciones");
				this.dtClientesDg.Columns.Add("tObjetivos");
				this.dtClientesDg.Columns.Add("tProxObj");
				this.dtClientesDg.Columns.Add("Boton");


				//				this.dtClientesRep = new DataTable();
				//				this.dtClientesRep.Columns.Add("iIdReport");
				//				this.dtClientesRep.Columns.Add("iIdCliente");
				//				this.dtClientesRep.Columns.Add("sIdCliente");
				//				this.dtClientesRep.Columns.Add("tObservaciones");
				//				this.dtClientesRep.Columns.Add("tObjetivos");
				//				this.dtClientesRep.Columns.Add("tProxObj");
				//				this.dtClientesRep.Columns.Add("bSustituto");
				//				this.dtClientesRep.Columns.Add("Accion");
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion


        //---- GSG (30/08/2011) 
        #region Inicializar estructuras cliente()
        private void Inicializar_dtClienteHora()
		{
			try
			{
                this.dtClienteHoraDg = new DataTable();
                this.dtClienteHoraDg.Columns.Add("iIdCliente");
                this.dtClienteHoraDg.Columns.Add("hIni");
                this.dtClienteHoraDg.Columns.Add("hFin");
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}

        #endregion



        #region Inicializar_dtGadgets()
        private void Inicializar_dtGadgets()
		{
			try
			{
				this.dtGadgetsDg = new DataTable();
				this.dtGadgetsDg.Columns.Add("iIdGadget");
				this.dtGadgetsDg.Columns.Add("sDescripcion");
				this.dtGadgetsDg.Columns.Add("iCantidad");

				this.dtGadgetsRep = new DataTable();
				this.dtGadgetsRep.Columns.Add("iIdReport");
				this.dtGadgetsRep.Columns.Add("sIdCliente");
				this.dtGadgetsRep.Columns.Add("iIdCliente");
				this.dtGadgetsRep.Columns.Add("iIdGadget");
				this.dtGadgetsRep.Columns.Add("sDescripcion");
				this.dtGadgetsRep.Columns.Add("iCantidad");
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region Inicializar_dtAtenciones()
		private void Inicializar_dtAtenciones()
		{
			try
			{
				this.dtAtencionesDg = new DataTable();
				this.dtAtencionesDg.Columns.Add("sIdAtencion");
				this.dtAtencionesDg.Columns.Add("iNumAtencion");
				this.dtAtencionesDg.Columns.Add("sIdTipoAtencion");
				this.dtAtencionesDg.Columns.Add("sTipoAtencion");
				this.dtAtencionesDg.Columns.Add("fImporte",System.Type.GetType("System.Double"));
				this.dtAtencionesDg.Columns.Add("fImportePrev",System.Type.GetType("System.Double"));
				this.dtAtencionesDg.Columns.Add("fImporteReal",System.Type.GetType("System.Double"));
				this.dtAtencionesDg.Columns.Add("iIdAtencion");
				this.dtAtencionesDg.Columns.Add("bEnviadoCEN");

				this.dtAtencionesRep = new DataTable();
				this.dtAtencionesRep.Columns.Add("iIdReport");
				this.dtAtencionesRep.Columns.Add("sIdCliente");
				this.dtAtencionesRep.Columns.Add("iIdCliente");
				this.dtAtencionesRep.Columns.Add("iIdAtencion");
				this.dtAtencionesRep.Columns.Add("sIdAtencion");
				this.dtAtencionesRep.Columns.Add("iNumAtencion");
				this.dtAtencionesRep.Columns.Add("sIdTipoAtencion");
				this.dtAtencionesRep.Columns.Add("sTipoAtencion");
				this.dtAtencionesRep.Columns.Add("fImporte",System.Type.GetType("System.Double"));
				this.dtAtencionesRep.Columns.Add("fImportePrev",System.Type.GetType("System.Double"));
				this.dtAtencionesRep.Columns.Add("fImporteReal",System.Type.GetType("System.Double"));
				this.dtAtencionesRep.Columns.Add("bEnviadoCEN");

//				dtAtenciones = new DataTable();
//				dtAtenciones.Columns.Add("iIdAtencion");
//				dtAtenciones.Columns.Add("fImporteReal");
//
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region Inicializar_dtPedidos()
		private void Inicializar_dtPedidos()
		{
			try
			{
				this.dtPedidosDg = new DataTable();
				this.dtPedidosDg.Columns.Add("sIdPedido");
				this.dtPedidosDg.Columns.Add("dFechaPedido",System.Type.GetType("System.DateTime"));
				this.dtPedidosDg.Columns.Add("sIdTipoPedido");
				this.dtPedidosDg.Columns.Add("Boton");		
                
                //---- GSG (13/10/2011)
                this.dtPedidosRep = new DataTable();
                this.dtPedidosRep.Columns.Add("sIdPedido");
                this.dtPedidosRep.Columns.Add("dFechaPedido", System.Type.GetType("System.DateTime"));
                this.dtPedidosRep.Columns.Add("sIdTipoPedido");
                this.dtPedidosRep.Columns.Add("Boton");
                this.dtPedidosRep.Columns.Add("sIdCliente");
                this.dtPedidosRep.Columns.Add("iIdCliente");
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region Inicializar_DataGrid
		private void Inicializar_DataGrid()
		{
			try
			{
//				Utiles.Formatear_DataGrid(this.dgClientes,null,this.cmClientes);
				Utiles.Formatear_DgConColumnaBoton(this.dgClientes,null,this.cmClientes,8);

				GESTCRM.DataGridButtonColumn clboton1 = (GESTCRM.DataGridButtonColumn)this.dgClientes.TableStyles[0].GridColumnStyles[8];
				clboton1.CellButtonClicked += 
						new DataGridCellButtonClickEventHandler(HandleCellbtVerClienteClick);
				

				Utiles.Formatear_DataGrid(this.dgGadgets,null,this.cmGadgets);
				Utiles.Formatear_DgConFilabEnviadoCEN(this.dgAtenciones,null,this.cmAtenciones);
				
//				Utiles.Formatear_DataGrid(this.dgPedidos,null,this.cmPedidos);
				Utiles.Formatear_DgConColumnaBoton(this.dgPedidos,null,this.cmPedidos,3);
				GESTCRM.DataGridButtonColumn clboton2 = (GESTCRM.DataGridButtonColumn)this.dgPedidos.TableStyles[0].GridColumnStyles[3];
				clboton2.CellButtonClicked += 
					new DataGridCellButtonClickEventHandler(HandleCellbtVerPedidoClick);

				//Utiles.Formatear_DataGrid(this.dgProductos,null,this.cmProductos); ---- GSG (27/02/2015)
				Utiles.Formatear_DataGrid(this,this.dgClientesProxObj,"C",true,null);
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		//Cargar_dgClientes
		//Recupera los clientes asociados al Report en BD
		//Se Utiliza al inicializar el formulario
		#region Cargar_dgClientes
		private void Cargar_dgClientes()
		{
			try
			{
				this.dtClientesDg.Rows.Clear();
				this.dsReports1.ListaRepActividadCli.Rows.Clear();

				this.sqldaRepActClientes.SelectCommand.Parameters["@iIdReport"].Value=this.ParamIdReport;
				this.sqldaRepActClientes.Fill(this.dsReports1);
				for(int i=0;i<this.dsReports1.ListaRepActividadCli.Rows.Count;i++)
				{
					DataRow filaDg = this.dtClientesDg.NewRow();
					filaDg["sIdCliente"]=this.dsReports1.ListaRepActividadCli.Rows[i]["sIdCliente"];
					filaDg["sNombre"]=this.dsReports1.ListaRepActividadCli.Rows[i]["sNombre"];
					filaDg["iIdCliente"]=this.dsReports1.ListaRepActividadCli.Rows[i]["iIdCliente"];
					filaDg["bSustituto"]=this.dsReports1.ListaRepActividadCli.Rows[i]["bSustituto"];
					if(filaDg["bSustituto"].ToString()=="0") filaDg["tSustituto"]="NO";
					else filaDg["tSustituto"]="SI";
					filaDg["tObservaciones"]=this.dsReports1.ListaRepActividadCli.Rows[i]["tObservaciones"];
					filaDg["tObjetivos"]=this.dsReports1.ListaRepActividadCli.Rows[i]["tObjetivos"];
					filaDg["tProxObj"]=this.dsReports1.ListaRepActividadCli.Rows[i]["tProxObj"];
					filaDg["Boton"]="Atenciones";

					this.dtClientesDg.Rows.Add(filaDg);

                    //---- GSG (30/08/2011) 
                    Cargar_dgClienteHora(int.Parse(filaDg["iIdCliente"].ToString()));
                    //---- FI GSG
				}
				this.dgClientes.DataSource=this.dtClientesDg;

				if(this.dtClientesDg.Rows.Count>0) 
				{
                    int fila = this.dgClientes.CurrentRowIndex;
                    Utiles.Seleccionar_UnaFilaDataGrid(this, this.dgClientes, fila);

                    Cargar_DatosCliente(fila);

                    this.dGVProductosPromo.RefreshEdit(); //---- GSG (13/01/2016)

                }
				this.lblTotClientes.Text = this.dtClientesDg.Rows.Count.ToString();
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion
        
        

		//Cargar_dgGadgets
		//Recupera los gadgets asociados al Report en BD
		//Se Utiliza al inicializar el formulario
		#region Cargar_dgGadgets
		private void Cargar_dgGadgets()
		{
			try
			{
				this.dtGadgetsDg.Rows.Clear();
				this.dtGadgetsRep.Rows.Clear();
				this.dsReports1.ListaRepActividGadget.Rows.Clear();

				this.sqldaRepActGadgets.SelectCommand.Parameters["@iIdReport"].Value=this.ParamIdReport;
				this.sqldaRepActGadgets.Fill(this.dsReports1);
				for(int i=0;i<this.dsReports1.ListaRepActividGadget.Rows.Count;i++)
				{
					DataRow filaRep = this.dtGadgetsRep.NewRow();
					filaRep["iIdReport"]= this.ParamIdReport;
					filaRep["iIdCliente"]=this.dsReports1.ListaRepActividGadget.Rows[i]["iIdCliente"];
					filaRep["sIdCliente"]=this.dsReports1.ListaRepActividGadget.Rows[i]["sIdCliente"];
					filaRep["iIdGadget"]=this.dsReports1.ListaRepActividGadget.Rows[i]["iIdGadget"];
					filaRep["sDescripcion"]=this.dsReports1.ListaRepActividGadget.Rows[i]["sDescripcion"];
					filaRep["iCantidad"]=this.dsReports1.ListaRepActividGadget.Rows[i]["iCantidad"];

					this.dtGadgetsRep.Rows.Add(filaRep);
				}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		//Cargar_dgAtenciones
		//Recupera las atenciones asociadas al Report en BD
		//Se Utiliza al inicializar el formulario
		#region Cargar_dgAtenciones
		private void Cargar_dgAtenciones()
		{
			try
			{
				this.dtAtencionesDg.Rows.Clear();
				this.dtAtencionesRep.Rows.Clear();
				this.dsReports1.ListaRepActividAtenciones.Rows.Clear();

				this.sqldaRepActAtenciones.SelectCommand.Parameters["@iIdReport"].Value=this.ParamIdReport;
				this.sqldaRepActAtenciones.Fill(this.dsReports1);
				for(int i=0;i<this.dsReports1.ListaRepActividAtenciones.Rows.Count;i++)
				{
					DataRow filaRep = this.dtAtencionesRep.NewRow();
					filaRep["iIdReport"]= this.ParamIdReport;
					filaRep["iIdCliente"]=this.dsReports1.ListaRepActividAtenciones.Rows[i]["iIdCliente"];
					filaRep["sIdCliente"]=this.dsReports1.ListaRepActividAtenciones.Rows[i]["sIdCliente"];
					filaRep["iIdAtencion"]=this.dsReports1.ListaRepActividAtenciones.Rows[i]["iIdAtencion"];
					filaRep["sIdAtencion"]=this.dsReports1.ListaRepActividAtenciones.Rows[i]["sIdAtencion"];
					filaRep["iNumAtencion"]=this.dsReports1.ListaRepActividAtenciones.Rows[i]["iNumAtencion"];
					filaRep["fImporte"]=this.dsReports1.ListaRepActividAtenciones.Rows[i]["fImporte"];
					filaRep["fImportePrev"]=this.dsReports1.ListaRepActividAtenciones.Rows[i]["fImportePrev"];
					filaRep["fImporteReal"]=this.dsReports1.ListaRepActividAtenciones.Rows[i]["fImporteReal"];
					filaRep["sIdTipoAtencion"]=this.dsReports1.ListaRepActividAtenciones.Rows[i]["sIdTipoAtencion"];
					filaRep["sTipoAtencion"]=this.dsReports1.ListaRepActividAtenciones.Rows[i]["sTipoAtencion"];
					filaRep["bEnviadoCEN"]=this.dsReports1.ListaRepActividAtenciones.Rows[i]["bEnviadoCEN"];

					this.dtAtencionesRep.Rows.Add(filaRep);
				}


//				int fila=-1;
//				string iIdAtencion =" -1";
//				float Importe=0;
//				string sIdTipoAtencion;
//				for(int i=0;i<this.dtAtencionesRep.Rows.Count;i++)
//				{
//					sIdTipoAtencion = this.dtAtencionesRep.Rows[i]["sIdTipoAtencion"].ToString();
//					if(sIdTipoAtencion=="2")//Atención manual
//					{
//						iIdAtencion = this.dtAtencionesRep.Rows[i]["iIdAtencion"].ToString();
//						Importe = float.Parse(this.dtAtencionesRep.Rows[i]["fImporteReal"].ToString());
//						fila = Utiles.Buscar_fila_dtTabla(this.dtAtenciones,"iIdAtencion",iIdAtencion);
//						if(fila==-1)
//						{
//							DataRow dtAtenfila = this.dtAtenciones.NewRow();
//							dtAtenfila["iIdAtencion"]=iIdAtencion;
//							dtAtenfila["fImporteReal"]=Importe;
//							this.dtAtenciones.Rows.Add(dtAtenfila);
//						}
//					}
//				}

			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}

        //---- GSG (18/06/2015)
        private void Formatear_dgAtenciones()
        {
            for (int i = 0; i < 9; i++ )
                dgAtenciones.TableStyles[0].GridColumnStyles[i].Width = 0;

            //--- GSG (13/03/2019)
            //dgAtenciones.TableStyles[0].GridColumnStyles[0].Width = 250;
            //dgAtenciones.TableStyles[0].GridColumnStyles[4].Width = 100;
            dgAtenciones.TableStyles[0].GridColumnStyles[0].Width = 200;
            dgAtenciones.TableStyles[0].GridColumnStyles[4].Width = 150;


            dgAtenciones.TableStyles[0].GridColumnStyles[0].HeaderText = "Atención";
            dgAtenciones.TableStyles[0].GridColumnStyles[4].HeaderText = "Importe";
        }
		#endregion

		//Cargar_dgProductos
		//Recupera los productos asociados al Report en BD
		//Se Utiliza al inicializar el formulario
		#region Cargar_dgProductos

        //---- GSG (27/02/2015)

        //private void Cargar_dgProductos()
        //{
        //    try
        //    {
        //        string sIdCliente = "-1";
        //        if (dgClientes.CurrentRowIndex != -1)
        //            sIdCliente = this.dgClientes[this.dgClientes.CurrentRowIndex, 2].ToString();
				
        //        dsReports1.ListaPromocionProd.Rows.Clear();
        //        sqldaListaPromocionProd.SelectCommand.Parameters["@iIdReport"].Value= ParamIdReport;
        //        sqldaListaPromocionProd.Fill(this.dsReports1);

        //        dsReports1.ListaPromocionProd.DefaultView.RowFilter = "iIdCliente = " + sIdCliente;
        //        Nuevo_Producto();

        //    }
        //    catch(Exception ex){Mensajes.ShowError(ex.Message);}
        //}

        private void Cargar_dgProductos()
        {
            try
            {
                this.dtProductosRep.Rows.Clear();
                this.dsReports1.ListaPromocionProd.Rows.Clear();

                this.sqldaListaPromocionProd.SelectCommand.Parameters["@iIdReport"].Value = this.ParamIdReport;
                this.sqldaListaPromocionProd.Fill(this.dsReports1);
                for (int i = 0; i < this.dsReports1.ListaPromocionProd.Rows.Count; i++)
                {
                    DataRow filaRep = this.dtProductosRep.NewRow();
                    filaRep["iIdReport"] = this.ParamIdReport;
                    filaRep["iIdCliente"] = this.dsReports1.ListaPromocionProd.Rows[i]["iIdCliente"];
                    filaRep["sIdProducto"] = this.dsReports1.ListaPromocionProd.Rows[i]["sIdProducto"];
                    filaRep["iCantidad"] = this.dsReports1.ListaPromocionProd.Rows[i]["iCantidad"];
                    filaRep["Orden"] = this.dsReports1.ListaPromocionProd.Rows[i]["Orden"];                   

                    this.dtProductosRep.Rows.Add(filaRep);
                }

            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }


        //---- GSG (14/06/2017)
        //private void Cargar_dgProductosGrid()
        private void Cargar_dgProductosGrid(int iIdCliente)
        {
            try
            {
                this.dsBuscar1.ListaBuscarProductos.Rows.Clear();

                this.sqldaListaBuscarProductos.SelectCommand.Parameters["@sIdProducto"].Value = null;
                this.sqldaListaBuscarProductos.SelectCommand.Parameters["@sDescripcion"].Value = null;
                this.sqldaListaBuscarProductos.SelectCommand.Parameters["@iIdCliente"].Value = iIdCliente; //---- GSG (14/06/2017)

                this.sqldaListaBuscarProductos.Fill(this.dsBuscar1);

                if (this.dsBuscar1.ListaBuscarProductos.Rows.Count > 0)
                {
                    this.dtProductosDg.Rows.Clear();

                    for (int i = 0; i < dsBuscar1.ListaBuscarProductos.Rows.Count; i++)
                    {
                        DataRow filaDg = this.dtProductosDg.NewRow();
                        string producto = this.dsBuscar1.ListaBuscarProductos.Rows[i]["sIdProducto"].ToString();

                        filaDg["sDescripcion"] = this.dsBuscar1.ListaBuscarProductos.Rows[i]["sDescripcion"];
                        filaDg["Orden"] = i + 1;
                        filaDg["sIdProducto"] = producto;
                        //---- GSG (14/06/2017)
                        //filaDg["iIdCliente"] = "-1";
                        filaDg["iIdCliente"] = iIdCliente.ToString();

                        
                        filaDg["bSelected"] = false;
                        
                        filaDg["iCantidad"] = 0;

                        this.dtProductosDg.Rows.Add(filaDg);
                    }

                    //---- GSG (14/06/2017)
                    if (dGVProductosPromo.Columns.Count > 0)
                        dGVProductosPromo.Columns.RemoveAt(0); 

                    dGVProductosPromo.DataSource = this.dtProductosDg;

                    DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
                    checkBoxColumn.HeaderText = "X";
                    checkBoxColumn.Width = 20;
                    checkBoxColumn.Name = "selected";
                    dGVProductosPromo.Columns.Insert(0, checkBoxColumn);


                    Formatear_dGVProductosPromo();
                }
            }
            catch (Exception ex)
            {
                Mensajes.ShowError(ex.Message);
            }
        }
        
        private void Cargar_dgProductos_Cliente(int iIdCliente)
        {
            // En el grid los visualizamos todos y chequeamos los del clientes
            try
            {
                //limpiar grid de cliente anterior

                foreach (DataGridViewRow row in dGVProductosPromo.Rows)
                {
                    row.Cells["selected"].Value = false;
                    row.Cells["bSelected"].Value = false;
                    row.Cells["iCantidad"].Value = 0;
                }

                //poner los datos del cliente seleccionado
                for (int i = 0; i < this.dtProductosRep.Rows.Count; i++)
                {
                    if (this.dtProductosRep.Rows[i]["iIdCliente"].ToString() == iIdCliente.ToString())
                    {
                        for (int j = 0; j < dGVProductosPromo.Rows.Count; j++)
                        {
                            if (dGVProductosPromo.Rows[j].Cells["sIdProducto"].Value.ToString() == this.dtProductosRep.Rows[i]["sIdProducto"].ToString())
                            {
                                dGVProductosPromo.Rows[j].Cells["selected"].Value = true;
                                dGVProductosPromo.Rows[j].Cells["bSelected"].Value = true;
                                dGVProductosPromo.Rows[j].Cells["iCantidad"].Value = this.dtProductosRep.Rows[i]["iCantidad"].ToString();

                                //---- GSG (13/01/2017)
                                //dGVProductosPromo.EndEdit();
                                this.dGVProductosPromo.RefreshEdit();
                                this.dGVProductosPromo.NotifyCurrentCellDirty(true);

                                break;
                            }
                        }
                    }
                }

                

                //this.dsBuscar1.ListaBuscarProductos.Rows.Clear();

                //this.sqldaListaBuscarProductos.SelectCommand.Parameters["@sIdProducto"].Value = null;
                //this.sqldaListaBuscarProductos.SelectCommand.Parameters["@sDescripcion"].Value = null;

                //this.sqldaListaBuscarProductos.Fill(this.dsBuscar1);

                //if (this.dsBuscar1.ListaBuscarProductos.Rows.Count > 0)
                //{
                //    this.dtProductosDg.Rows.Clear();

                //    for (int i = 0; i < dsBuscar1.ListaBuscarProductos.Rows.Count; i++)
                //    {
                //        DataRow filaDg = this.dtProductosDg.NewRow();
                //        string producto = this.dsBuscar1.ListaBuscarProductos.Rows[i]["sIdProducto"].ToString();

                //        filaDg["sDescripcion"] = this.dsBuscar1.ListaBuscarProductos.Rows[i]["sDescripcion"];
                //        filaDg["Orden"] = i + 1;
                //        filaDg["sIdProducto"] = producto;
                //        filaDg["iIdCliente"] = iIdCliente.ToString();
                //        filaDg["bSelected"] = false;
                //        filaDg["iCantidad"] = 0;

                //        for (int j = 0; j < this.dtProductosRep.Rows.Count; j++)
                //        {
                //            if (this.dtProductosRep.Rows[j]["iIdCliente"].ToString() == iIdCliente.ToString() && int.Parse(this.dtProductosRep.Rows[j]["Orden"].ToString()) == i + 1)
                //            {
                //                filaDg["bSelected"] = true;
                //                filaDg["iCantidad"] = this.dtProductosRep.Rows[j]["iCantidad"].ToString();
                //            }
                //        }

                //        this.dtProductosDg.Rows.Add(filaDg);
                //    }

                //    dGVProductosPromo.DataSource = this.dtProductosDg;

                //    Formatear_dGVProductosPromo();
                //}




            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }


        private void Cargar_dgProductosGridCliente(int iIdCliente)
        {
            try
            {             

                this.dsBuscar1.ListaBuscarProductos.Rows.Clear();

                this.sqldaListaBuscarProductos.SelectCommand.Parameters["@sIdProducto"].Value = null;
                this.sqldaListaBuscarProductos.SelectCommand.Parameters["@sDescripcion"].Value = null;

                this.sqldaListaBuscarProductos.Fill(this.dsBuscar1);

                if (this.dsBuscar1.ListaBuscarProductos.Rows.Count > 0)
                {
                    this.dtProductosDg.Rows.Clear();

                    for (int i = 0; i < dsBuscar1.ListaBuscarProductos.Rows.Count; i++)
                    {
                        DataRow filaDg = this.dtProductosDg.NewRow();
                        string producto = this.dsBuscar1.ListaBuscarProductos.Rows[i]["sIdProducto"].ToString();

                        filaDg["sDescripcion"] = this.dsBuscar1.ListaBuscarProductos.Rows[i]["sDescripcion"];
                        filaDg["Orden"] = i + 1;
                        filaDg["sIdProducto"] = producto;
                        filaDg["iIdCliente"] = "-1";
                        filaDg["bSelected"] = false;                        
                        filaDg["iCantidad"] = 0;

                        this.dtProductosDg.Rows.Add(filaDg);
                    }

                    

                    dGVProductosPromo.DataSource = this.dtProductosDg;

                    DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
                    checkBoxColumn.HeaderText = "X";
                    checkBoxColumn.Width = 20;
                    checkBoxColumn.Name = "selected";
                    dGVProductosPromo.Columns.Insert(0, checkBoxColumn);


                    Formatear_dGVProductosPromo();
                }
            }
            catch (Exception ex)
            {
                Mensajes.ShowError(ex.Message);
            }
        }


        
        private void Formatear_dGVProductosPromo()
        {
            dGVProductosPromo.Columns[4].Visible = false; //sIdProducto
            dGVProductosPromo.Columns[5].Visible = false; //iIdCliente
            dGVProductosPromo.Columns[6].Visible = false; //bSelected

            dGVProductosPromo.Columns[1].HeaderText = "Producto";
            dGVProductosPromo.Columns[2].HeaderText = "Orden";
            dGVProductosPromo.Columns[3].HeaderText = "Cant.";

            dGVProductosPromo.Columns[1].Width = 280;
            dGVProductosPromo.Columns[2].Width = 50;
            dGVProductosPromo.Columns[3].Width = 50;

            dGVProductosPromo.Columns[1].ReadOnly= true;
            dGVProductosPromo.Columns[2].ReadOnly = true;
            dGVProductosPromo.Columns[3].ReadOnly = false;
        }


        private List<string[]> GetProductosPromoCliente(string sIdCliente, out string[] prods)
        {
            string[] prodsPromoCliente = new string[20000];
            List<string[]> lProds = new List<string[]>();            
            int index = 0;            

            FiltrarProductosClientes(sIdCliente);

            foreach (DataRow row in dsReports1.ListaPromocionProd.Rows)
            {
                string[] lin = new string[2];

                lin[0] = row["sIdProducto"].ToString();
                lin[1] = row["iCantidad"].ToString();

                lProds.Add(lin);

                prodsPromoCliente[index] = row["sIdProducto"].ToString();
                index++;
            }

            prods = prodsPromoCliente;

            return lProds;
        }

		#endregion

        


		#region Filtrar Productos Clientes
		private void FiltrarProductosClientes()
		{
			string sIdCliente = "-1";
			if (dgClientes.CurrentRowIndex != -1)
			{
				sIdCliente = this.dgClientes[this.dgClientes.CurrentRowIndex,2].ToString();
				FiltrarProductosClientes(sIdCliente);
			}
		}
		private void FiltrarProductosClientes(string sIdCliente)
		{
			dsReports1.ListaPromocionProd.DefaultView.RowFilter = "iIdCliente = " + sIdCliente;
			lblTotProductos.Text = dsReports1.ListaPromocionProd.DefaultView.Count.ToString();
		}
		#endregion

		//Cargar_dgPedidos
		//Recupera los pedidos asociados al Report en BD
		//Se Utiliza al inicializar el formulario
		#region Cargar_dgPedidos
		private void Cargar_dgPedidos()
		{
			try
			{
				this.dtPedidosDg.Rows.Clear();
                this.dtPedidosRep.Clear(); //---- GSG (13/10/2011)
				this.dsReports1.ListaRepActividPedidos.Rows.Clear();

				this.sqldaRepActPedidos.SelectCommand.Parameters["@iIdReport"].Value=this.ParamIdReport;
				this.sqldaRepActPedidos.Fill(this.dsReports1);

                //---- GSG (13/10/2011)
                //for(int i=0;i<this.dsReports1.ListaRepActividPedidos.Rows.Count;i++)
                //{
                //    DataRow filaDg = this.dtPedidosDg.NewRow();
                //    filaDg["sIdPedido"]=this.dsReports1.ListaRepActividPedidos.Rows[i]["sIdPedido"];
                //    filaDg["dFechaPedido"]=this.dsReports1.ListaRepActividPedidos.Rows[i]["dFechaPedido"];
                //    filaDg["sIdTipoPedido"]=this.dsReports1.ListaRepActividPedidos.Rows[i]["sIdTipoPedido"];
                //    this.dtPedidosDg.Rows.Add(filaDg);
                //}

                //this.dgPedidos.DataSource = this.dtPedidosDg;

                for(int i=0;i<this.dsReports1.ListaRepActividPedidos.Rows.Count;i++)
				{
					DataRow filaRep = this.dtPedidosRep.NewRow();
                    filaRep["sIdPedido"] = this.dsReports1.ListaRepActividPedidos.Rows[i]["sIdPedido"];
                    filaRep["dFechaPedido"] = this.dsReports1.ListaRepActividPedidos.Rows[i]["dFechaPedido"];
                    filaRep["sIdTipoPedido"] = this.dsReports1.ListaRepActividPedidos.Rows[i]["sIdTipoPedido"];

                    if (dgClientes.CurrentRowIndex != -1)
                    {
                        filaRep["sIdCliente"] = this.dgClientes[this.dgClientes.CurrentRowIndex, 0].ToString();
                        filaRep["iIdCliente"] = Int32.Parse(this.dgClientes[this.dgClientes.CurrentRowIndex, 2].ToString());
                    }

                    this.dtPedidosRep.Rows.Add(filaRep);
				}
                //---- FI GSG

                

				this.lblTotPedidos.Text = this.dtPedidosDg.Rows.Count.ToString();

				if(GESTCRM.Clases.Configuracion.iGPedidos==2)//no tiene acceso a pedidos
				{this.dgPedidos.TableStyles[0].GridColumnStyles[3].Width=0;}
				else {this.dgPedidos.TableStyles[0].GridColumnStyles[3].Width=40;}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

        //---- GSG (13/10/2011)
        #region Cargar_dgPedidos_Cliente
        private void Cargar_dgPedidos_Cliente(string sIdCliente, string tCliente)
        {
            try
            {
                this.dtPedidosDg.Rows.Clear();
                for (int i = 0; i < this.dtPedidosRep.Rows.Count; i++)
                {
                    if (this.dtPedidosRep.Rows[i]["sIdCliente"].ToString() == sIdCliente)
                    {
                        DataRow filaDg = this.dtPedidosDg.NewRow();
                        filaDg["sIdPedido"] = this.dtPedidosRep.Rows[i]["sIdPedido"];
                        filaDg["dFechaPedido"] = this.dtPedidosRep.Rows[i]["dFechaPedido"];
                        filaDg["sIdTipoPedido"] = this.dtPedidosRep.Rows[i]["sIdTipoPedido"];

                        this.dtPedidosDg.Rows.Add(filaDg);
                    }
                }

                this.dgPedidos.DataSource = this.dtPedidosDg;
                this.lblTotPedidos.Text = this.dtPedidosDg.Rows.Count.ToString();
                //Nuevo_Gadget();

            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }
        #endregion
        //---- FI GSG

		#region Cargar_dgClientesProxObj
		private void Cargar_dgClientesProxObj()
		{
			try
			{
				this.dsReports1.ListaRepActividadCli_ProxObj.Rows.Clear();
				if(this.Var_iIdCentro!=-1)
				{
					this.sqldaListaRepActividadCli_ProxObj.SelectCommand.Parameters["@iIdCentro"].Value = this.Var_iIdCentro;
					this.sqldaListaRepActividadCli_ProxObj.SelectCommand.Parameters["@iIdCliente"].Value = -1;

					this.sqldaListaRepActividadCli_ProxObj.Fill(this.dsReports1);
				}
				this.lblTotProxObj.Text = this.dsReports1.ListaRepActividadCli_ProxObj.Rows.Count.ToString();
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion


		//Menú Contextual asociado a los DataGrigs
		#region menuEliminar_Click
//		private void menuEliminar_Click(object sender, System.EventArgs e)
//		{
//			try
//			{
//				string Objeto = this.contextMenu1.SourceControl.Name.ToString();
//				if(Objeto.Length==0) Objeto = this.contextMenu1.SourceControl.Parent.Name.ToString();
//				switch(Objeto)
//				{
//					case "dgClientes":	 Eliminar_Cliente();break;
//					case "dgGadgets":	 Eliminar_Gadget();break;
//					case "dgAtenciones": Eliminar_Atencion();break;
//					case "dgPedidos":	 Eliminar_Pedido();break;
//					case "dgProductos":	 Eliminar_Producto();break;
//					default: break;
//				}
//			}
//			catch(Exception ex)
//			{
//				Mensajes.ShowError(ex.Message);
//			}
//		}

		private void mnEliminarCli_Click(object sender, System.EventArgs e)
		{
			Eliminar_Cliente();
		}
		private void mnEliminarProd_Click(object sender, System.EventArgs e)
		{
			Eliminar_Producto();
		}
		private void mnEliminarPed_Click(object sender, System.EventArgs e)
		{
			Eliminar_Pedido();
		}
		private void mnEliminarAten_Click(object sender, System.EventArgs e)
		{
			Eliminar_Atencion();
		}
		private void mnEliminarGad_Click(object sender, System.EventArgs e)
		{
			Eliminar_Gadget();
		}

		#endregion

		#region menuNuevo_Click
//		private void menuNuevo_Click(object sender, System.EventArgs e)
//		{
//			try
//			{
//				string Objeto = this.contextMenu1.SourceControl.Name.ToString();
//				if(Objeto.Length==0) Objeto = this.contextMenu1.SourceControl.Parent.Name.ToString();
//
//				switch(Objeto)
//				{
//					case "dgClientes":	 Nuevo_Cliente();break;
//					case "dgGadgets":	 Nuevo_Gadget();break;
//					case "dgAtenciones": Nueva_Atencion();break;
//					case "dgPedidos":	 Nuevo_Pedido();break;
//					case "dgProductos":	 Nuevo_Producto();break;
//					default: break;
//				}
//			}
//			catch(Exception ex)
//			{
//				Mensajes.ShowError(ex.Message);
//			}
//		}
		private void mnNuevoCli_Click(object sender, System.EventArgs e)
		{
			Nuevo_Cliente();
		}
		private void mnNuevoProd_Click(object sender, System.EventArgs e)
		{
			Nuevo_Producto();
		}
		private void mnNuevoPed_Click(object sender, System.EventArgs e)
		{
			Nuevo_Pedido();
		}
		private void mnNuevoAten_Click(object sender, System.EventArgs e)
		{
			Nueva_Atencion();
		}
		private void mnNuevoGad_Click(object sender, System.EventArgs e)
		{
			Nuevo_Gadget();
		}
		#endregion




		//Limpiar_CentroCliente
		//Cuando es un Report de un ClienteSAP no hay Centro asociado al Report
		//Se limpia el campo Centro y todos los clientes asociados
		#region Limpiar_CentroCliente()
		private void Limpiar_CentroCliente()
		{
			try
			{
				this.txtsIdCentro.Text=null;
				this.txtsCentro.Text=null;
				this.Var_iIdCentro=-1;

				Limpiar_Clientes();
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}

		}
		#endregion

		//Limpiar_Clientes
		//Se Borran todos los Clientes de pantalla y se marcan para borrar en BD
		//Lo mismo para Atenciones, Gadgets y Pedidos
		//Utilizada al modificar el valor del campo centro
		#region Limpiar_Clientes()
		private void Limpiar_Clientes()
		{
			try
			{
				this.dtClientesDg.Rows.Clear();
				this.dtAtencionesDg.Rows.Clear();
				this.dtAtencionesRep.Rows.Clear();
				this.dtGadgetsDg.Rows.Clear();
				this.dtGadgetsRep.Rows.Clear();
				this.dtPedidosDg.Rows.Clear();
                //---- GSG (30/08/2011) 
                if (this.cbTipoCliente.SelectedValue.ToString() == "S") //ClienteSAP
                {
                    this.dtClienteHoraDg.Rows.Clear();
                }
                //---- FI GSG

                //---- GSG (27/02/2015)
                //dsReports1.ListaPromocionProd.Rows.Clear();
                //dsReports1.ListaPromocionProd.AcceptChanges();
                //Nuevo_Producto();
                this.dtProductosDg.Rows.Clear();
                this.dtProductosRep.Rows.Clear();
                //----FI GSG


				Nuevo_Cliente();

				this.pnDatosClienteVisita.Visible=false;
                //---- GSG (21/11/2013)
                this.pnProductosProm.Visible = false;

				if(this.Var_bPlanificacion==1)
				{
					if(this.cbTipoCliente.SelectedValue.ToString()=="S") this.pnDatosClientesPlanif.Visible=false;
					else
					{
						Cargar_dgClientesProxObj();
						this.pnDatosClientesPlanif.Visible=true;
					}
				}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region Recuperar_RepActividadCab()
		private void Recuperar_RepActividadCab()
		{
			try
			{
				this.sqlcomdGetRepActividadCab.Parameters["@iIdReport"].Value=this.ParamIdReport;
				this.sqlcomdGetRepActividadCab.Parameters["@iIdDelegado"].Value=-1;//int.Parse(this.cbDelegado.SelectedValue.ToString());
                this.sqlcomdGetRepActividadCab.Parameters["@dFecha"].Value = DBNull.Value;//this.dtpFecha.Value;
                this.sqlcomdGetRepActividadCab.Parameters["@sTipoRActividad"].Value = DBNull.Value;//this.cbTipoRActibidad.SelectedValue.ToString();
                this.sqlcomdGetRepActividadCab.Parameters["@sIdTipoCliente"].Value = DBNull.Value;//this.cbTipoCliente.SelectedValue.ToString();
                this.sqlcomdGetRepActividadCab.Parameters["@iHorario"].Value = DBNull.Value;//this.cbHorario.SelectedValue.ToString();
                this.sqlcomdGetRepActividadCab.Parameters["@tObservaciones"].Value = DBNull.Value;//this.txbObservaciones.Text.ToString();
                this.sqlcomdGetRepActividadCab.Parameters["@tObjetivo"].Value = DBNull.Value;//this.txbObjetivo.Text.ToString();
                this.sqlcomdGetRepActividadCab.Parameters["@tProxObjetivo"].Value = DBNull.Value;//this.txtProxObjetivo.Text.ToString();
                this.sqlcomdGetRepActividadCab.Parameters["@dFUM"].Value = DBNull.Value;//this.txtCentro.Text.ToString();
				this.sqlcomdGetRepActividadCab.Parameters["@iEstado"].Value=-1;
				this.sqlcomdGetRepActividadCab.Parameters["@bEnviadoPDA"].Value=0;
				this.sqlcomdGetRepActividadCab.Parameters["@bEnviadoCEN"].Value=0;
				this.sqlcomdGetRepActividadCab.Parameters["@iIdCentro"].Value=0;
				this.sqlcomdGetRepActividadCab.Parameters["@sIdCentro"].Value="";
				this.sqlcomdGetRepActividadCab.Parameters["@sIdReportTemp"].Value="";
                //RH
                this.sqlcomdGetRepActividadCab.Parameters["@dHoraInicio"].Value = DBNull.Value;
                this.sqlcomdGetRepActividadCab.Parameters["@dHoraFin"].Value = DBNull.Value;

				try
				{
                    //---- GSG (10/09/2014)
                    //sqlConn.Open();
                    if (sqlConn.State == ConnectionState.Closed)
                        sqlConn.Open();
					this.sqlcomdGetRepActividadCab.ExecuteNonQuery();


                    //---- GSG (17/06/2016)
                    // En caso de tratarse de una conversión de planificación a visita, tenemos que cambiar algunos datos

                    if (this.ParamNuevaFecha == DateTime.MinValue)
                    {
                        // Como estaba
                        this.dtpFecha.Value = DateTime.Parse(this.sqlcomdGetRepActividadCab.Parameters["@dFecha"].Value.ToString());
                        this.cbTipoRActibidad.SelectedValue = this.sqlcomdGetRepActividadCab.Parameters["@sTipoRActividad"].Value.ToString();
                        this.cbTipoCliente.SelectedValue = this.sqlcomdGetRepActividadCab.Parameters["@sIdTipoCliente"].Value.ToString();
                        this.cbHorario.SelectedValue = this.sqlcomdGetRepActividadCab.Parameters["@iHorario"].Value.ToString();
                        this.txbObservaciones.Text = this.sqlcomdGetRepActividadCab.Parameters["@tObservaciones"].Value.ToString();
                        this.txbObjetivo.Text = this.sqlcomdGetRepActividadCab.Parameters["@tObjetivo"].Value.ToString();
                        this.txtProxObjetivo.Text = this.sqlcomdGetRepActividadCab.Parameters["@tProxObjetivo"].Value.ToString();
                        this.txtsIdCentro.Text = this.sqlcomdGetRepActividadCab.Parameters["@sIdCentro"].Value.ToString();
                        this.txtsCentro.Text = this.sqlcomdGetRepActividadCab.Parameters["@tCentro"].Value.ToString();

                        try { this.Var_iIdCentro = Int32.Parse(this.sqlcomdGetRepActividadCab.Parameters["@iIdCentro"].Value.ToString()); }
                        catch { }
                        this.Var_iEstado = int.Parse(this.sqlcomdGetRepActividadCab.Parameters["@iEstado"].Value.ToString());
                        this.Var_bEnviadoCEN = int.Parse(this.sqlcomdGetRepActividadCab.Parameters["@bEnviadoCEN"].Value.ToString());
                        this.Var_bPlanificacion = int.Parse(this.sqlcomdGetRepActividadCab.Parameters["@bPlanificacion"].Value.ToString());

                        //RH                    
                        dtpHoraInicio.Value = (DateTime)sqlcomdGetRepActividadCab.Parameters["@dHoraInicio"].Value;
                        txbHoraInicio.Text = dtpHoraInicio.Value.ToShortTimeString();
                        dtpHoraFin.Value = (DateTime)sqlcomdGetRepActividadCab.Parameters["@dHoraFin"].Value;
                        txbHoraFin.Text = dtpHoraFin.Value.ToShortTimeString();
                    }
                    else
                    {
                        this.dtpFecha.Value = this.ParamNuevaFecha;
                        this.cbTipoRActibidad.SelectedValue = this.sqlcomdGetRepActividadCab.Parameters["@sTipoRActividad"].Value.ToString();
                        this.cbTipoCliente.SelectedValue = this.sqlcomdGetRepActividadCab.Parameters["@sIdTipoCliente"].Value.ToString();
                        this.cbHorario.SelectedValue = this.sqlcomdGetRepActividadCab.Parameters["@iHorario"].Value.ToString();
                        this.txbObservaciones.Text = this.sqlcomdGetRepActividadCab.Parameters["@tObservaciones"].Value.ToString();
                        this.txbObjetivo.Text = this.sqlcomdGetRepActividadCab.Parameters["@tObjetivo"].Value.ToString();
                        this.txtProxObjetivo.Text = this.sqlcomdGetRepActividadCab.Parameters["@tProxObjetivo"].Value.ToString();
                        this.txtsIdCentro.Text = this.sqlcomdGetRepActividadCab.Parameters["@sIdCentro"].Value.ToString();
                        this.txtsCentro.Text = this.sqlcomdGetRepActividadCab.Parameters["@tCentro"].Value.ToString();

                        try { this.Var_iIdCentro = Int32.Parse(this.sqlcomdGetRepActividadCab.Parameters["@iIdCentro"].Value.ToString()); }
                        catch { }
                        this.Var_iEstado = int.Parse(this.sqlcomdGetRepActividadCab.Parameters["@iEstado"].Value.ToString());
                        this.Var_bEnviadoCEN = 0;
                        this.Var_bPlanificacion = 0;
                  
                        dtpHoraInicio.Value = (DateTime)sqlcomdGetRepActividadCab.Parameters["@dHoraInicio"].Value;
                        txbHoraInicio.Text = dtpHoraInicio.Value.ToShortTimeString();
                        dtpHoraFin.Value = (DateTime)sqlcomdGetRepActividadCab.Parameters["@dHoraFin"].Value;
                        txbHoraFin.Text = dtpHoraFin.Value.ToShortTimeString();
                    }


					
				}
				catch(SqlException e)
				{
					//MessageBox.Show(e.Message);
                    Mensajes.ShowError(e.Message);
				}
				catch(Exception e)
				{
					//MessageBox.Show(e.Message);
                    Mensajes.ShowError(e.Message);
				}
				finally
				{
					this.sqlConn.Close();
				}
			}
			catch(Exception ex)
            {
                //Mensajes.ShowError(ex.Message);
                Mensajes.ShowError(ex.Message);
            }
		}
		#endregion

		#region cbTipoRActibidad_SelectedIndexChanged
		private void cbTipoRActibidad_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				if(this.cbTipoRActibidad.SelectedValue.ToString()=="2")//Report Tipo Pedido
				{
					if(this.ParamTipoAcceso=="A")
					{
						this.cbTipoCliente.SelectedValue="S";
						this.cbTipoCliente.Enabled=false;
					}
					if (this.dtpFecha.Value.Date<=DateTime.Today.Date) 
					{
						this.pnPedidos.Visible=true;//Entrar Visita
						this.pnPedidos.BringToFront();
					}
                    //---- GSG (21/11/2013)
                    this.pnProductosProm.Visible = false;

				}
				else//Report Tipo Vistita
				{
					//if(this.ParamTipoAcceso=="A") this.cbTipoCliente.Enabled=true;  //---- GSG (13/03/2019)
					if (this.dtpFecha.Value.Date<=DateTime.Today.Date) 
					{
						this.pnPedidos.Visible=false;//Entrar Visita
						this.pnPedidos.SendToBack();
					}
					this.dtPedidosDg.Rows.Clear();
//					this.dtPedidosRep.Rows.Clear();

                    
                    //---- GSG (21/11/2013)
                    //---- GSG (10/03/2015)
                    //if (this.ParamTipoAcceso == "M")
                    if (this.ParamTipoAcceso == "M" || this.ParamTipoAcceso == "A")
                        this.pnProductosProm.Visible = true;
				}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region dtpFecha_ValueChanged
		private void dtpFecha_ValueChanged(object sender, System.EventArgs e)
		{
			try
			{
				if (this.dtpFecha.Value.Date > DateTime.Today.Date) //Planificar Visita
				{
                    btEncuestas.Enabled = false; //---- GSG (03/07/2019)

					if(this.dtpFecha.Enabled) this.Var_bPlanificacion=1;
					//this.pnProductosProm.Visible=false;
					this.pnClientesVisitados.Visible=true;
					this.cbTipoRActibidad.SelectedValue=1;
					this.cbTipoRActibidad.Enabled=false;
					this.pnDatosClienteVisita.Visible=false;

                    if (this.cbTipoCliente.SelectedValue.ToString() == "S")
                    {
                        this.pnDatosClientesPlanif.Visible = false;
                    }
                    else
                    {
                        Cargar_dgClientesProxObj();
                        this.pnDatosClientesPlanif.Visible = true;
                        //---- GSG (21/11/2013)
                        this.pnProductosProm.Visible = false;
                    }

				}
				else//Entrar Visita
				{
                    btEncuestas.Enabled = true; //---- GSG (03/07/2019)

                    if (this.dtpFecha.Enabled) this.Var_bPlanificacion=0;
					this.cbTipoRActibidad.Enabled=true;
					this.pnDatosClientesPlanif.Visible=false;
                    if (this.dtClientesDg.Rows.Count == 0)
                    {
                        this.pnDatosClienteVisita.Visible = false;
                        //---- GSG (21/11/2013)
                        this.pnProductosProm.Visible = false;
                    }
                    else
                    {
                        this.pnDatosClienteVisita.Visible = true;
                        if (this.cbTipoRActibidad.SelectedValue.ToString() == "1") this.pnPedidos.Visible = false;//Report tipo Visita
                        else this.pnPedidos.Visible = true;//Report tipo Pedido
                        //---- GSG (21/11/2013)
                        this.pnProductosProm.Visible = true;
                    }
				}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region cbTipoCliente_SelectedIndexChanged
		private void cbTipoCliente_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				if(this.cbTipoCliente.SelectedValue.ToString()=="S")//Cliente SAP
				{
					Activa_Centro(false);
					Limpiar_CentroCliente(); //Report de Cliente SAP no tiene centro asociado
					this.cbSustituto.Visible=false;
					this.dgClientes.TableStyles[0].GridColumnStyles[3].Width=0;
					if(GESTCRM.Clases.Configuracion.iGClientesSAP==2) //no tiene acceso a clientes COM
					{this.dgClientes.TableStyles[0].GridColumnStyles[8].Width=0;}
					else this.dgClientes.TableStyles[0].GridColumnStyles[8].Width=40;
				}
				else//Cliente COM
				{
					Activa_Centro(true);
                	Limpiar_Clientes();//Al modificar el tipo de cliente se elimina el cliente SAP existente
                    this.cbSustituto.Visible=true;
                    this.dgClientes.TableStyles[0].GridColumnStyles[3].Width=30;
                    if(GESTCRM.Clases.Configuracion.iGClientesCOM==2) //No tiene acceso a clientes COM
                    {this.dgClientes.TableStyles[0].GridColumnStyles[8].Width=0;}
                    else this.dgClientes.TableStyles[0].GridColumnStyles[8].Width=40;
                    
                }
				Activa_Cliente(true);
				this.cbTipoCliente.Focus();
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region txtsIdCentro_Leave
		private void txtsIdCentro_Leave(object sender, System.EventArgs e)
		{
			try
			{
				GESTCRM.Formularios.Busquedas.frmMCentros frmBCent = new GESTCRM.Formularios.Busquedas.frmMCentros();
				frmBCent.ParamI_iIdDelegado = this.ParamiIdDelegado;
				frmBCent.ParamIO_sIdCentro= this.txtsIdCentro.Text.ToString();
				frmBCent.ParamIO_sDescripcion="";
				frmBCent.Buscar_sCentro();
				if(this.txtsIdCentro.Text!=frmBCent.ParamIO_sIdCentro || this.txtsCentro.Text!=frmBCent.ParamIO_sDescripcion)
				{
					if(this.txtsIdCentro.Text.ToString().Length>0  && frmBCent.ParamO_iIdCentro==-1) Mensajes.ShowError("Este código de Centro no existe.");
					this.Var_iIdCentro = frmBCent.ParamO_iIdCentro;
					this.txtsIdCentro.Text=frmBCent.ParamIO_sIdCentro;
					this.txtsCentro.Text=frmBCent.ParamIO_sDescripcion;
					Limpiar_Clientes();
				}
				frmBCent.Dispose();
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
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
				frmBCent.ParamI_iIdDelegado = this.ParamiIdDelegado;
				frmBCent.ShowDialog(this);
				if (frmBCent.DialogResult==System.Windows.Forms.DialogResult.OK)
				{
					if(this.txtsIdCentro.Text!=frmBCent.ParamIO_sIdCentro)
					{
						this.Var_iIdCentro = frmBCent.ParamO_iIdCentro;
						this.txtsIdCentro.Text=frmBCent.ParamIO_sIdCentro;
						this.txtsCentro.Text=frmBCent.ParamIO_sDescripcion;
						Limpiar_Clientes();
					}
				}
				frmBCent.Dispose();
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region btVerCentro_Click
		private void btVerCentro_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (this.Var_iIdCentro!=-1)
				{
					bool abierto = false;
					if(this.ParentForm== null && this.Owner==null)
					{
						Mensajes.ShowInformation("No se puede abrir el formulario. Demasiadas ventanas abiertas. ");
					}
					else
					{
						if(this.ParentForm == null) abierto=Utiles.MirarSiFormAbierto("frmAltaCentros",this.Owner);
						else abierto = Utiles.MirarSiFormAbierto("frmAltaCentros",this.ParentForm);
						//El formulario de Centros es sólo de consulta
						Formularios.frmAltaCentros frmCent=new Formularios.frmAltaCentros("M", Int32.Parse(txtsIdCentro.Text),DateTime.Now,0);
						frmCent.ShowDialog();
					}
				}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region txtClienteSAP_Leave
		private void txtClienteSAP_Leave(object sender, System.EventArgs e)
		{
			try
			{
                //---- GSG (29/07/2011) Modificació per a que en cas de ClientesSAP (no persona) 
                // gravi un report per client seleccionat.
                // En aquest cas fins ara sols es podia seleccionar un client, ara se'n podran seleccionar varis (igual que quan es tria persona)                    
                //bool BusquedaMultiple=false;
                //if(this.cbTipoCliente.SelectedValue.ToString()=="C") BusquedaMultiple=true;
                //---- FI GSG
                GESTCRM.Formularios.Busquedas.frmMClientesSAP frmBCli = new GESTCRM.Formularios.Busquedas.frmMClientesSAP(true,"R");
				frmBCli.ParamI_iIdDelegado = this.ParamiIdDelegado;
				frmBCli.ParamI_sIdCentro= this.txtsIdCentro.Text.ToString();
				frmBCli.ParamI_sIdTipoCliente=this.cbTipoCliente.SelectedValue.ToString();
				frmBCli.ParamIO_sIdCliente = this.txtClienteSAP.Text.ToString();
				if(this.cbTipoRActibidad.SelectedValue.ToString()=="1") frmBCli.ParamI_TipoVisita=1;//Visita
				else frmBCli.ParamI_TipoVisita=0;//Pedido
				frmBCli.Buscar_tNombre();
				if(this.txtClienteSAP.Text.ToString().Length>0 && frmBCli.ParamO_iIdCliente==-1) Mensajes.ShowError("Este código de Cliente no existe.");
				this.txtClienteSAP.Text=frmBCli.ParamIO_sIdCliente;
				this.txtsCliente.Text=frmBCli.ParamO_tNombre;
				this.Temp_ProxObj = frmBCli.ParamO_tProxObj;
				this.txtClienteObjetivo.Text = frmBCli.ParamO_tProxObj;
				this.Temp_iIdCliente = frmBCli.ParamO_iIdCliente;
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
                Utiles.Seleccionar_UnaFilaDataGrid(this, this.dgClientes, fila);
                //FiltrarProductosClientes(); //---- GSG (27/02/2015)
                Cargar_DatosCliente(fila);
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}

  
		#endregion

		#region Cargar_DatosCliente
		private void Cargar_DatosCliente(int fila)
		{
			try
			{
				if(fila>-1)
				{
					this.txtClienteSAP.Text=this.dgClientes[fila,0].ToString();
					this.txtsCliente.Text= this.dgClientes[fila,1].ToString();
					if(this.dgClientes[fila,4].ToString()=="0") this.cbSustituto.Checked=false;
					else this.cbSustituto.Checked=true;

                    this.Temp_iIdCliente = Int32.Parse(this.dgClientes[fila, 2].ToString());

                    this.txtClienteObserv.Text = this.dgClientes[fila,5].ToString();
					this.txtClienteObjetivo.Text = this.dgClientes[fila,6].ToString();

                    //---- GSG (19/09/2017)
                    if (txtClienteObjetivo.Text.Trim() == "")
                    {
                        //---- GSG (13/03/2019)
                        //txtClienteObjetivo.Text = GESTCRM.Utiles.ProximoObjetivoVisita(Temp_iIdCliente, this.ParamIdReport);
                        txtClienteObjetivo.Text = GESTCRM.Utiles.ProximoObjetivoVisita(Temp_iIdCliente, this.ParamIdReport, dtpFecha.Value);
                        
                    }
                    //---- FI GSG 


					this.txtClienteProxObj.Text = this.dgClientes[fila,7].ToString();

					

					if(this.Var_bPlanificacion==0)
					{
						if(this.ParamTipoAcceso!="C") Utiles.Activar_Control(this.txtClienteProxObj,true);
						Cargar_dgGadgets_Cliente(this.dgClientes[fila,0].ToString(),this.dgClientes[fila,1].ToString());
						Cargar_dgAtenciones_Cliente(this.dgClientes[fila,0].ToString(),this.dgClientes[fila,1].ToString());
                        //---- GSG (13/10/2011) 
                        Cargar_dgPedidos_Cliente(this.dgClientes[this.dgClientes.CurrentRowIndex, 0].ToString(), this.dgClientes[this.dgClientes.CurrentRowIndex, 1].ToString());


                        //---- GSG (14/06/2017)

                        ////---- GSG (27/02/2015)
                        ////FiltrarProductosClientes(this.dgClientes[fila,2].ToString());         
                        //Cargar_dgProductos_Cliente(int.Parse(this.dgClientes[this.dgClientes.CurrentRowIndex, 2].ToString()));                      
                        Cargar_dgProductosGrid(Temp_iIdCliente);
                        Cargar_dgProductos_Cliente(Temp_iIdCliente); //---- GSG (09/11/2017)



                        if (this.cbTipoCliente.SelectedValue.ToString()=="S")
						{
                            //---- GSG (13/10/2011) 
							//LlenarCombo_cbPedidos();
                            LlenarCombo_cbPedidos(fila);
						}

                        //---- GSG (30/08/2011) 
                        if (this.cbTipoCliente.SelectedValue.ToString() == "S") //ClienteSAP
                        {
                            //---- GSG (15/05/2012)
                            //PosarHoraClient(Temp_iIdCliente);
                            if (!_convertit)
                                PosarHoraClient(Temp_iIdCliente);
                            else
                                _convertit = false;
                        }
                        //---- FI GSG
					}
					else
					{
                        //---- GSG (09/11/2017) He canviat les dues línies següents d'ordre

                        //---- GSG (14/06/2017)
                        Cargar_dgProductosGrid(Temp_iIdCliente);
                        Cargar_dgProductos_Cliente(int.Parse(this.dgClientes[this.dgClientes.CurrentRowIndex, 2].ToString())); //---- GSG (10/06/2015)

                        



                        Utiles.Activar_Control(this.txtClienteProxObj,false);
					}


                    ////---- GSG (09/11/2017)
                    //DataRow rowReport = dtProductosRep.Rows.Find(this.ParamIdReport);
                    //if (rowReport != null)
                    //{
                        
                    //}


                }
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

				if(fila>-1 && columna==8)
				{
					this.lblToolTipBoton.Visible=true;
					int y = dg.Location.Y + cy;
					int x = dg.Location.X + dg.Width-dg.TableStyles[0].GridColumnStyles[1].Width;
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


		#region btBuscarCliente_Click
		private void btBuscarCliente_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(this.cbTipoCliente.SelectedValue.ToString()=="C" && this.Var_iIdCentro==-1)
				{
					Mensajes.ShowInformation("Primero debe introducir un Centro");
				}
				else
				{
                    //---- GSG (29/07/2011) Modificació per a que en cas de ClientesSAP (no persona) 
                    // gravi un report per client seleccionat.
                    // En aquest cas fins ara sols es podia seleccionar un client, ara se'n podran seleccionar varis (igual que quan es tria persona)
                    //bool BusquedaMultiple=false;
                    //if(this.cbTipoCliente.SelectedValue.ToString()=="C") BusquedaMultiple=true;
                    bool BusquedaMultiple = true;
                    //---- FI GSG
					GESTCRM.Formularios.Busquedas.frmMClientesSAP frmBCli = new GESTCRM.Formularios.Busquedas.frmMClientesSAP(BusquedaMultiple,"R");
					frmBCli.ParamI_sIdTipoCliente = this.cbTipoCliente.SelectedValue.ToString();
					frmBCli.ParamIO_sIdCliente = "";
					frmBCli.ParamI_sIdCentro = this.txtsIdCentro.Text.ToString();
					frmBCli.ParamI_iIdDelegado = this.ParamiIdDelegado;
					if(this.cbTipoRActibidad.SelectedValue.ToString()=="1") frmBCli.ParamI_TipoVisita=1;//Visita
					else frmBCli.ParamI_TipoVisita=0;//Pedido

					frmBCli.ShowDialog(this);
					
					if (frmBCli.DialogResult==System.Windows.Forms.DialogResult.OK)
					{
						if(frmBCli.dtSeleccion.Rows.Count==0)
						{
							this.txtClienteSAP.Text=frmBCli.ParamIO_sIdCliente;
							this.txtsCliente.Text = frmBCli.ParamO_tNombre;
							this.txtClienteObjetivo.Text = frmBCli.ParamO_tProxObj;
							this.Temp_ProxObj = frmBCli.ParamO_tProxObj;
							this.Temp_iIdCliente = frmBCli.ParamO_iIdCliente;
						}
						else
						{
							int fila = -1;
							string  sIdCliente = "";
							for(int i=0; i<frmBCli.dtSeleccion.Rows.Count ;i++)
							{
								sIdCliente=frmBCli.dtSeleccion.Rows[i]["sIdCliente"].ToString();
								fila = Utiles.Buscar_fila_dtTabla(this.dtClientesDg,"sIdCliente",sIdCliente);
								if(fila==-1)
								{
									DataRow filaCli = this.dtClientesDg.NewRow();

									filaCli["sIdCliente"]=frmBCli.dtSeleccion.Rows[i]["sIdCliente"];
									filaCli["sNombre"]=frmBCli.dtSeleccion.Rows[i]["tNombre"];
									filaCli["iIdCliente"]=frmBCli.dtSeleccion.Rows[i]["iIdCliente"];
									filaCli["bSustituto"]=0;
									filaCli["tSustituto"]="NO";
									filaCli["tObjetivos"]=frmBCli.dtSeleccion.Rows[i]["tProxObj"];
									
									this.dtClientesDg.Rows.Add(filaCli);

									int NumFilaDg = this.dtClientesDg.Rows.Count-1;
									this.dgClientes.CurrentRowIndex=NumFilaDg;
									Utiles.Seleccionar_UnaFilaDataGrid(this,this.dgClientes,NumFilaDg);

                                    //---- GSG (30/08/2011) 
                                    Cargar_dgClienteHora(int.Parse(filaCli["iIdCliente"].ToString()));
                                    //---- FI GSG

									Cargar_DatosCliente(NumFilaDg);

									//Nuevo_Cliente();
									
                                    //---- GSG (23/03/2012)
                                    //AIXÒ JA NO ÉS AIXI, POT HABER-HI SELECCIÓ MÚLTIPLE
                                    ////Sólo puede haber un ClienteSAP por Report                                    
                                    //if(this.cbTipoCliente.SelectedValue.ToString()=="S")
                                    //{
                                    //    if(this.dtClientesDg.Rows.Count==0) Activa_Cliente(true);
                                    //    else Activa_Cliente(false);
                                    //}
                                    //---- FI GSG
									//Si no hay Clientes no se pueden asignar Gadgets ni Atenciones
                                    if (this.dtClientesDg.Rows.Count == 0)
                                    {
                                        this.pnDatosClienteVisita.Visible = false;
                                        //---- GSG (21/11/2013)
                                        this.pnProductosProm.Visible = false;
                                    }
                                    else
                                    {
                                        if (this.Var_bPlanificacion == 0)
                                        {
                                            this.pnDatosClienteVisita.Visible = true;
                                            if (this.cbTipoRActibidad.SelectedValue.ToString() == "1")
                                            {
                                                this.pnPedidos.Visible = false;
                                                //---- GSG (21/11/2013)
                                                this.pnProductosProm.Visible = true;
                                            }
                                            else
                                            {
                                                this.pnPedidos.Visible = true;
                                                //---- GSG (21/11/2013)
                                                this.pnProductosProm.Visible = false;
                                            }
                                        }
                                        else
                                        {
                                            this.pnDatosClienteVisita.Visible = false;
                                            //---- GSG (21/11/2013)
                                            this.pnProductosProm.Visible = true;
                                        }
                                        
                                    }
								}
							}
						}

                        //---- GSG (22/07/2011)
                        Actualiza_Cliente();
                        //---- FI GSG
					}
					this.lblTotClientes.Text = this.dtClientesDg.Rows.Count.ToString();
					//frmBCli.Dispose();
				}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region Mostrar_FormularioCliente
		private void Mostrar_FormularioCliente()
		{
			try
			{
				int iIdCliente=-1;

				if(this.Temp_iIdCliente!=-1 && this.Temp_iIdCliente.ToString().Length>0 && 
					this.txtClienteSAP.Text.ToString().Length>0 && this.txtsCliente.Text.ToString().Length>0)
				{
					iIdCliente = this.Temp_iIdCliente;
				}
				Abrir_FormularioCliente(iIdCliente);
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}

		private void Mostrar_FormularioCliente(int fila)
		{
			try
			{
				int iIdCliente=-1;
				if(fila>-1)
				{
					iIdCliente = Int32.Parse(this.dgClientes[fila,2].ToString());
				}

				Abrir_FormularioCliente(iIdCliente);
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}

		private void Abrir_FormularioCliente(int iIdCliente)
		{	
			try
			{
				string Acceso;

				if(this.ParamTipoAcceso == "C") Acceso="C";
				else Acceso="M";

				if(iIdCliente > -1)
				{
					bool abierto=false;
					if(this.cbTipoCliente.SelectedValue.ToString()!="S")
					{
						if(this.ParentForm== null && this.Owner==null)
						{
							Mensajes.ShowInformation("No se puede abrir el formulario. Demasiadas ventanas abiertas. ");
						}
						else
						{
//							if(this.ParentForm == null) abierto=Utiles.MirarSiFormAbierto("frmMClientesCOM",this.Owner);
							if(this.ParentForm == null) abierto=Utiles.MirarSiFormAbierto("frmAltaMedicos",this.Owner);
//							else abierto = Utiles.MirarSiFormAbierto("frmMClientesCOM",this.ParentForm);
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
//								Formularios.Mantenimientos.frmMClientesCOM myFormCOM = new Formularios.Mantenimientos.frmMClientesCOM(Acceso,iIdCliente,0);				
								Formularios.frmAltaMedicos myFormCOM = new Formularios.frmAltaMedicos(Acceso,iIdCliente);				
								myFormCOM.ShowDialog();
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
								myFormSAP.ShowDialog();
							}
						}
					}
				}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region btClienteNuevo_Click
		private void btClienteNuevo_Click(object sender, System.EventArgs e)
		{
			Nuevo_Cliente();
		}
		#endregion

		#region btClienteActualizar_Click
		private void btClienteActualizar_Click(object sender, System.EventArgs e)
		{
			Actualiza_Cliente();
		}
		#endregion

		#region btClienteEliminar_Click
		private void btClienteEliminar_Click(object sender, System.EventArgs e)
		{
			Eliminar_Cliente();
		}
		#endregion

		#region Nuevo_Cliente
		private void Nuevo_Cliente()
		{
			try
			{
				/*this.txtClienteSAP.Focus();*/ //He tret aquesta línia pq feia que la càrrega de la pantalla fos lenta
                this.txtClienteSAP.Text="";
                this.txtsCliente.Text="";
                this.cbSustituto.Checked=false;
                this.txtClienteObjetivo.Text="";
                this.txtClienteProxObj.Text="";
                this.txtClienteObserv.Text="";
                this.Temp_iIdCliente=-1;
                
				this.lblTotClientes.Text = this.dtClientesDg.Rows.Count.ToString();
            }
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region Actualiza_Cliente
		private void Actualiza_Cliente()
		{
			try
			{
				if((this.cbTipoCliente.SelectedValue.ToString()=="S" && this.dtClientesDg.Rows.Count<1)||this.cbTipoCliente.SelectedValue.ToString()=="C")
				{
					if(this.txtClienteSAP.Text.ToString()!="" && this.txtsCliente.Text.ToString()!="")
					{
						int NumFilaDg = Utiles.Buscar_fila_dtTabla(this.dtClientesDg,"sIdCliente",this.txtClienteSAP.Text.ToString());
						if(NumFilaDg==-1) //Insertar en pantalla
						{
							DataRow filaDg = this.dtClientesDg.NewRow();
							filaDg["sIdCliente"]=this.txtClienteSAP.Text.ToString();
							filaDg["sNombre"]=this.txtsCliente.Text.ToString();
							filaDg["iIdCliente"]=this.Temp_iIdCliente;
							filaDg["tObservaciones"]=this.txtClienteObserv.Text.ToString();
							filaDg["tObjetivos"]=this.txtClienteObjetivo.Text.ToString();
							filaDg["tProxObj"]=	this.txtClienteProxObj.Text.ToString();
//														filaDg["Boton"]="Atenciones";
							if(this.cbSustituto.Checked){filaDg["bSustituto"]=1;filaDg["tSustituto"]="SI";}
							else{filaDg["bSustituto"]=0;filaDg["tSustituto"]="NO";}
							this.dtClientesDg.Rows.Add(filaDg);
							NumFilaDg=this.dtClientesDg.Rows.Count-1;
						}
						else
						{
							this.dtClientesDg.Rows[NumFilaDg]["tObservaciones"]=this.txtClienteObserv.Text.ToString();
							this.dtClientesDg.Rows[NumFilaDg]["tObjetivos"]=this.txtClienteObjetivo.Text.ToString();
							this.dtClientesDg.Rows[NumFilaDg]["tProxObj"]=this.txtClienteProxObj.Text.ToString();
							if(this.cbSustituto.Checked){this.dtClientesDg.Rows[NumFilaDg]["bSustituto"]=1;this.dtClientesDg.Rows[NumFilaDg]["tSustituto"]="SI";}
							else{this.dtClientesDg.Rows[NumFilaDg]["bSustituto"]=0;this.dtClientesDg.Rows[NumFilaDg]["tSustituto"]="NO";}
						}
						this.dgClientes.CurrentRowIndex=NumFilaDg;

						Cargar_DatosCliente(NumFilaDg);
						Nuevo_Cliente();

						//Sólo puede haber un ClienteSAP por Report  //---- GSG (30/08/2011) JA NO
						if(this.cbTipoCliente.SelectedValue.ToString()=="S")
						{
							if(this.dtClientesDg.Rows.Count==0) Activa_Cliente(true);
							else Activa_Cliente(false);
						}

						//Si no hay Clientes no se pueden asignar Gadgets ni Atenciones
                        if (this.dtClientesDg.Rows.Count == 0)
                        {
                            this.pnDatosClienteVisita.Visible = false;
                            //---- GSG (21/11/2013)
                            this.pnProductosProm.Visible = false;
                        }
                        else
                        {
                            if (this.Var_bPlanificacion == 0)
                            {
                                this.pnDatosClienteVisita.Visible = true;
                                if (this.cbTipoRActibidad.SelectedValue.ToString() == "1") this.pnPedidos.Visible = false;
                                else this.pnPedidos.Visible = true;
                                //---- GSG (10/03/2015)
                                //---- GSG (21/11/2013)
                                //this.pnProductosProm.Visible = true;
                                if (this.pnPedidos.Visible)
                                    this.pnProductosProm.Visible = false;
                                else
                                    this.pnProductosProm.Visible = true;
                            }
                            else
                            {
                                this.pnDatosClienteVisita.Visible = false;
                                //---- GSG (21/11/2013)
                                this.pnProductosProm.Visible = false;
                            }
                        }
					}
				}
                //else if(this.cbTipoCliente.SelectedValue.ToString()=="S" && this.dtClientesDg.Rows.Count==1)
                else if (this.cbTipoCliente.SelectedValue.ToString() == "S" && this.dtClientesDg.Rows.Count > 0) //---- GSG (19/09/2017)
                {
					int NumFilaDg = Utiles.Buscar_fila_dtTabla(this.dtClientesDg,"sIdCliente",this.txtClienteSAP.Text.ToString());
					if(NumFilaDg !=-1)
					{
						this.dtClientesDg.Rows[NumFilaDg]["tObservaciones"]=this.txtClienteObserv.Text.ToString();
						this.dtClientesDg.Rows[NumFilaDg]["tObjetivos"]=this.txtClienteObjetivo.Text.ToString();
						this.dtClientesDg.Rows[NumFilaDg]["tProxObj"]=this.txtClienteProxObj.Text.ToString();
						if(this.cbSustituto.Checked){this.dtClientesDg.Rows[NumFilaDg]["bSustituto"]=1;this.dtClientesDg.Rows[NumFilaDg]["tSustituto"]="SI";}
						else{this.dtClientesDg.Rows[NumFilaDg]["bSustituto"]=0;this.dtClientesDg.Rows[NumFilaDg]["tSustituto"]="NO";}

						this.dgClientes.CurrentRowIndex=NumFilaDg;
						Cargar_DatosCliente(NumFilaDg);

					}

				}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region Eliminar_Cliente
		private void Eliminar_Cliente()
		{
			try
			{
				if(this.dgClientes.CurrentRowIndex!=-1)
				{
					string sIdCliente=this.dgClientes[this.dgClientes.CurrentRowIndex,0].ToString();
				
					//Se elimina de la pantalla
					int NumFilaDg = Utiles.Buscar_fila_dtTabla(this.dtClientesDg,"sIdCliente",sIdCliente);
					if(NumFilaDg>-1) this.dtClientesDg.Rows.RemoveAt(NumFilaDg);

					//Se borran por pantalla todos los Gadgets del Cliente
//					Limpiar_dtTablaDg_Cliente(this.dtGadgetsDg,sIdCliente);
					this.dtGadgetsDg.Rows.Clear();
				
					//Se marcan para borrar en BD todos los Gadgets recuperados de BD y se eliminan los nuevos
					Limpiar_dtTablaRep_Cliente(this.dtGadgetsRep,sIdCliente);
				
					//Se borran por pantalla todas las Atenciones del Cliente
//					Limpiar_dtTablaDg_Cliente(this.dtAtencionesDg,sIdCliente);
					this.dtAtencionesDg.Rows.Clear();

			
					//Se marcan para borrar en BD todas las Atenciones recuperadas de BD y se eliminan las nuevas
					Limpiar_dtTablaRep_Cliente(this.dtAtencionesRep,sIdCliente);

					//Se borran por pantalla todos los Pedidos del Cliente(Sólo afecta a ClientesSAP y sólo puede haber uno por Report)
                    //---- GSG (02/08/2011)
					//this.dtPedidosDg.Rows.Clear();
                    if (this.cbTipoCliente.SelectedValue.ToString() == "S")
                    {
                        if (dtClienteHoraDg.Rows.Count <= 1)
                            this.dtPedidosDg.Rows.Clear();
                        else
                        {
                            for (int i = dtPedidosDg.Rows.Count - 1; i >= 0; i--)
                            {
                                DataRow filaPed = this.dtPedidosDg.Rows[i];
                                if (int.Parse(filaPed["iIdCliente"].ToString()) == this.Temp_iIdCliente)
                                {
                                    this.dtPedidosDg.Rows.RemoveAt(i);
                                }
                            }
                        }                       
                    }
                    //---- FI GSG
				
					//Se marcan para borrar en BD todos los Pedidos recuperados de BD y se eliminan los nuevos
//					Limpiar_dtTablaRep(this.dtPedidosRep);

                    //---- GSG (02/08/2011) JA NO
                    ////Sólo puede haber un ClienteSAP por Report 
                    //if (this.dtClientesDg.Rows.Count == 0) Activa_Cliente(true);
                    //else Activa_Cliente(false);
                    if (this.cbTipoCliente.SelectedValue.ToString() == "S")
                    {
                        Activa_Cliente(true);

                        for (int i = dtClienteHoraDg.Rows.Count - 1; i >= 0; i--)
                        {
                            DataRow filaDg = this.dtClienteHoraDg.Rows[i];
                            if (int.Parse(filaDg["iIdCliente"].ToString()) == this.Temp_iIdCliente)
                            {
                                this.dtClienteHoraDg.Rows.RemoveAt(i);
                            }
                        }

                       
                    }
                    else
                    {
                        if (this.dtClientesDg.Rows.Count == 0) Activa_Cliente(true);
                        else Activa_Cliente(false);
                    }
                    //---- FI GSG


					//Si no hay Clientes no se pueden asignar Gadgets ni Atenciones
                    if (this.dtClientesDg.Rows.Count == 0)
                    {
                        this.pnDatosClienteVisita.Visible = false;
                        //---- GSG (21/11/2013)
                        this.pnProductosProm.Visible = false;
                    }
                    else
                    {
                        if (this.Var_bPlanificacion == 0)
                        {
                            this.pnDatosClienteVisita.Visible = true;
                            if (this.cbTipoRActibidad.SelectedValue.ToString() == "1") this.pnPedidos.Visible = false;
                            else this.pnPedidos.Visible = true;
                            //---- GSG (21/11/2013)
                            this.pnProductosProm.Visible = true;
                        }
                        else
                        {
                            this.pnDatosClienteVisita.Visible = false;
                            //---- GSG (21/11/2013)
                            this.pnProductosProm.Visible = false;
                        }
                        NumFilaDg = NumFilaDg - 1;
                        if (NumFilaDg == -1) NumFilaDg = 0;
                    }
					if(NumFilaDg>-1 && this.dtClientesDg.Rows.Count>0)
					{
						this.dgClientes.CurrentRowIndex=NumFilaDg;
						Utiles.Seleccionar_UnaFilaDataGrid(this,this.dgClientes,NumFilaDg);
						Cargar_DatosCliente(NumFilaDg);

                       

					}

					Nuevo_Cliente();
				}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion




		#region Cargar_dgGadgets_Cliente
		private void Cargar_dgGadgets_Cliente(string sIdCliente,string tCliente)
		{
			try
			{
				this.dtGadgetsDg.Rows.Clear();
				for(int i=0;i<this.dtGadgetsRep.Rows.Count;i++)
				{
					if(this.dtGadgetsRep.Rows[i]["sIdCliente"].ToString()==sIdCliente)
					{
						DataRow filaDg = this.dtGadgetsDg.NewRow();
						filaDg["iIdGadget"]=this.dtGadgetsRep.Rows[i]["iIdGadget"];
						filaDg["sDescripcion"]=this.dtGadgetsRep.Rows[i]["sDescripcion"];
						filaDg["iCantidad"]=this.dtGadgetsRep.Rows[i]["iCantidad"];

						this.dtGadgetsDg.Rows.Add(filaDg);
					}
				}
				this.dgGadgets.DataSource=this.dtGadgetsDg;
				this.lblTotGadgets.Text = this.dtGadgetsDg.Rows.Count.ToString();
				Nuevo_Gadget();

                Formatear_dgGadgets(); //---- GSG (18/06/2015)
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}

        //---- GSG (18/06/2015)
        private void Formatear_dgGadgets()
        {            
            dgGadgets.TableStyles[0].GridColumnStyles[0].Width = 0; //id oculto        
            //--- GSG (13/03/2019)    
            //dgGadgets.TableStyles[0].GridColumnStyles[1].Width = 270;
            //dgGadgets.TableStyles[0].GridColumnStyles[2].Width = 80;
            dgGadgets.TableStyles[0].GridColumnStyles[1].Width = 230;
            dgGadgets.TableStyles[0].GridColumnStyles[2].Width = 120;

            dgGadgets.TableStyles[0].GridColumnStyles[1].HeaderText = "Gadget";
            dgGadgets.TableStyles[0].GridColumnStyles[2].HeaderText = "Cantidad";
        }
		#endregion

		#region dgGadgets_CurrentCellChanged
		private void dgGadgets_CurrentCellChanged(object sender, System.EventArgs e)
		{
			try
			{
				int fila = this.dgGadgets.CurrentRowIndex;
				if(fila>-1)
				{
					Utiles.Seleccionar_UnaFilaDataGrid(this,this.dgGadgets,fila);

					this.Temp_iIdGadget = Int32.Parse(this.dtGadgetsDg.Rows[fila]["iIdGadget"].ToString());
					this.txtsGadget.Text=this.dtGadgetsDg.Rows[fila]["sDescripcion"].ToString();
					this.nudCantidadGad.Value = Int32.Parse(this.dtGadgetsDg.Rows[fila]["iCantidad"].ToString());

				}

			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region btBuscarGadget_Click
		private void btBuscarGadget_Click(object sender, System.EventArgs e)
		{
			try
			{
				GESTCRM.Formularios.Busquedas.frmMGadgets frmBGad = new GESTCRM.Formularios.Busquedas.frmMGadgets();
				frmBGad.ParamIO_sDescripcion = this.txtsGadget.Text.ToString();
				frmBGad.ShowDialog(this);
				if (frmBGad.DialogResult==System.Windows.Forms.DialogResult.OK)
				{
					this.txtsGadget.Text=frmBGad.ParamIO_sDescripcion;
					this.Temp_iIdGadget = frmBGad.ParamIO_iIdGadget;
				}
				frmBGad.Dispose();
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region txtsGadget_Leave
		private void txtsGadget_Leave(object sender, System.EventArgs e)
		{
			try
			{
				GESTCRM.Formularios.Busquedas.frmMGadgets frmBGad = new GESTCRM.Formularios.Busquedas.frmMGadgets();
				frmBGad.ParamIO_sDescripcion = this.txtsGadget.Text.ToString();
				frmBGad.Buscar_Gadget();
				
				if(frmBGad.ParamIO_iIdGadget==-1 && this.txtsGadget.Text.ToString().Length>0) Mensajes.ShowError("Este código de Gadget no existe.");
				
				this.txtsGadget.Text=frmBGad.ParamIO_sDescripcion;
				this.Temp_iIdGadget = frmBGad.ParamIO_iIdGadget;

				frmBGad.Dispose();
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion


		#region btGadgetNuevo_Click
		private void btGadgetNuevo_Click(object sender, System.EventArgs e)
		{
			Nuevo_Gadget();
		}
		#endregion

		#region btGadgetActualizar_Click
		private void btGadgetActualizar_Click(object sender, System.EventArgs e)
		{
			Actualiza_Gadget();
		}
		#endregion

		#region btGadgetEliminar_Click
		private void btGadgetEliminar_Click(object sender, System.EventArgs e)
		{
			Eliminar_Gadget();
		}
		#endregion

		#region Nuevo_Gadget
		private void Nuevo_Gadget()
		{
			try
			{
				this.txtsGadget.Focus();
				this.txtsGadget.Text="";this.nudCantidadGad.Value=this.nudCantidadGad.Minimum;
				this.lblTotGadgets.Text = this.dtGadgetsDg.Rows.Count.ToString();
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region Actualiza_Gadget
		private void Actualiza_Gadget()
		{
			try
			{
				string sIdCliente=this.dgClientes[this.dgClientes.CurrentRowIndex,0].ToString();
				int iIdCliente=Int32.Parse(this.dgClientes[this.dgClientes.CurrentRowIndex,2].ToString());

				if(this.Temp_iIdGadget !=-1)
				{
					int fila = Utiles.Buscar_fila_dtTabla(this.dtGadgetsRep,"sIdCliente",sIdCliente,"iIdGadget",this.Temp_iIdGadget.ToString());
					if(fila==-1) //Insertar en tabla de Gadgets
					{
						DataRow filaRep = this.dtGadgetsRep.NewRow();
						filaRep["iIdCliente"]=iIdCliente;
						filaRep["sIdCliente"]=sIdCliente;
						filaRep["iIdGadget"]=this.Temp_iIdGadget;
						filaRep["sDescripcion"]=this.txtsGadget.Text.ToString();
						filaRep["iCantidad"]=Convert.ToInt32(this.nudCantidadGad.Value);
						this.dtGadgetsRep.Rows.Add(filaRep);
					}
					else //Modificar en tabla de Gadgets
					{
						this.dtGadgetsRep.Rows[fila]["iCantidad"]=Convert.ToInt32(this.nudCantidadGad.Value);
					}

					int NumFilaDg = Utiles.Buscar_fila_dtTabla(this.dtGadgetsDg,"iIdGadget",this.Temp_iIdGadget.ToString());
					if(NumFilaDg==-1) //Insertar en Pantalla
					{
						DataRow filaDg = this.dtGadgetsDg.NewRow();
						filaDg["iIdGadget"]=this.Temp_iIdGadget;
						filaDg["sDescripcion"]=this.txtsGadget.Text.ToString();
						filaDg["iCantidad"]=Convert.ToInt32(this.nudCantidadGad.Value);
						this.dtGadgetsDg.Rows.Add(filaDg);
					}
					else //Modificar en Pantalla
					{
						this.dtGadgetsDg.Rows[NumFilaDg]["iCantidad"]=Convert.ToInt32(this.nudCantidadGad.Value);
					}

					Nuevo_Gadget();

				}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region Eliminar_Gadget
		private void Eliminar_Gadget()
		{
			try
			{
				if(this.dgGadgets.CurrentRowIndex>-1 )
				{
					string iIdGadget = this.dtGadgetsDg.Rows[this.dgGadgets.CurrentRowIndex]["iIdGadget"].ToString(); 
					string sIdCliente=this.dgClientes[this.dgClientes.CurrentRowIndex,0].ToString();
					//Se borra entabla de Gadgets
					int fila = Utiles.Buscar_fila_dtTabla(this.dtGadgetsRep,"sIdCliente",sIdCliente,"iIdGadget",iIdGadget);
					if(fila>-1) this.dtGadgetsRep.Rows.RemoveAt(fila);//MarcarRegBorrarBD_dtTablaRep(this.dtGadgetsRep,fila);
					//Se borra de pantalla
					int filaDg = Utiles.Buscar_fila_dtTabla(this.dtGadgetsDg,"iIdGadget",iIdGadget);
					if(filaDg>-1) this.dtGadgetsDg.Rows.RemoveAt(filaDg);
					Nuevo_Gadget();
				}
				else
				{
					Mensajes.ShowError("No hay ningún Gadget seleccionado");
				}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion
        				
		#region Cargar_dgAtenciones_Cliente
		private void Cargar_dgAtenciones_Cliente(string sIdCliente,string tCliente)
		{
			try
			{
				this.dtAtencionesDg.Rows.Clear();
                //int fila=-1;
				for(int i=0;i<this.dtAtencionesRep.Rows.Count;i++)
				{
					if(this.dtAtencionesRep.Rows[i]["sIdCliente"].ToString()==sIdCliente)
					{
						DataRow filaDg = this.dtAtencionesDg.NewRow();
						filaDg["iIdAtencion"]=this.dtAtencionesRep.Rows[i]["iIdAtencion"];
						filaDg["iNumAtencion"]=this.dtAtencionesRep.Rows[i]["iNumAtencion"];
						filaDg["sIdAtencion"]=this.dtAtencionesRep.Rows[i]["sIdAtencion"];
						filaDg["sIdTipoAtencion"]=this.dtAtencionesRep.Rows[i]["sIdTipoAtencion"];
						filaDg["sTipoAtencion"]=this.dtAtencionesRep.Rows[i]["sTipoAtencion"];
						filaDg["fImporte"]=this.dtAtencionesRep.Rows[i]["fImporte"];
						filaDg["fImportePrev"]=this.dtAtencionesRep.Rows[i]["fImportePrev"];
						filaDg["fImporteReal"]=this.dtAtencionesRep.Rows[i]["fImporteReal"];
						filaDg["bEnviadoCEN"]=this.dtAtencionesRep.Rows[i]["bEnviadoCEN"];

//						if(this.dtAtencionesRep.Rows[i]["sIdTipoAtencion"].ToString()=="2")//Manual
//						{
//							fila = Utiles.Buscar_fila_dtTabla(this.dtAtenciones,"iIdAtencion",this.dtAtencionesRep.Rows[i]["iIdAtencion"].ToString());
//							if(fila==-1) filaDg["fImporteReal"]=this.dtAtencionesRep.Rows[i]["fImporteReal"];
//							else filaDg["fImporteReal"]=this.dtAtenciones.Rows[fila]["fImporteReal"];
//						}
//						else //Permanente
//						{
//							filaDg["fImporteReal"]=this.dtAtencionesRep.Rows[i]["fImporteReal"];
//						}
						this.dtAtencionesDg.Rows.Add(filaDg);
					}
				}
				this.dgAtenciones.DataSource=this.dtAtencionesDg;
				this.lblTotAtenciones.Text = this.dtAtencionesDg.Rows.Count.ToString();
				Nueva_Atencion();

                Formatear_dgAtenciones(); //---- GSG (18/06/2015)
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
				this.txtsIdAtencion.Text = this.dgAtenciones[fila,0].ToString();
                //this.nupImporteCli.Value = Convert.ToDecimal(this.dgAtenciones[fila,3].ToString());
                //this.txtfImportePrev.Text = Convert.ToDouble(this.dgAtenciones[fila,4].ToString()).ToString("N2");
                //this.txtTipoAtencion.Text = this.dgAtenciones[fila,2].ToString();
                this.nupImporteCli.Value = Convert.ToDecimal(this.dgAtenciones[fila, 4].ToString());
                this.txtfImportePrev.Text = Convert.ToDouble(this.dgAtenciones[fila, 5].ToString()).ToString("N2");
                this.txtTipoAtencion.Text = this.dgAtenciones[fila, 3].ToString();

                //this.Var_iIdAtencion = Int32.Parse(this.dgAtenciones[fila,6].ToString());
                //this.Var_iNumAtencion = int.Parse(this.dgAtenciones[fila,1].ToString());
                //this.Var_sIdTipoAtencion = this.dgAtenciones[fila,7].ToString();
                //this.Var_sTipoAtencion = this.dgAtenciones[fila,2].ToString();
                this.Var_iIdAtencion = Int32.Parse(this.dgAtenciones[fila, 7].ToString());
                this.Var_iNumAtencion = int.Parse(this.dgAtenciones[fila, 1].ToString());
                this.Var_sIdTipoAtencion = this.dgAtenciones[fila, 2].ToString();
                this.Var_sTipoAtencion = this.dgAtenciones[fila, 3].ToString();

				if(this.dgAtenciones[fila,8].ToString()=="1")
				{
					Utiles.Activar_Panel(this.panel3,false);
					Utiles.Activar_Control(this.btAtenActualizar,false);
					Utiles.Activar_Control(this.btAtenEliminar,false);
				}
				else if(this.ParamTipoAcceso!="C")
				{
					Utiles.Activar_Panel(this.panel3,true);
					Utiles.Activar_Control(this.btAtenActualizar,true);
					Utiles.Activar_Control(this.btAtenEliminar,true);
				}
				if(this.Var_sIdTipoAtencion=="2") this.nupImporteCli.Enabled=false;
				else this.nupImporteCli.Enabled=true;
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region btBuscarAtencion_Click
		private void btBuscarAtencion_Click(object sender, System.EventArgs e)
		{
			try
			{
				GESTCRM.Formularios.Busquedas.frmMBuscaAtenciones frmBAten = new GESTCRM.Formularios.Busquedas.frmMBuscaAtenciones();
				frmBAten.ParamI_iIdDelegado = this.ParamiIdDelegado;
				int iIdCliente = Int32.Parse(this.dgClientes[this.dgClientes.CurrentRowIndex,2].ToString());
				frmBAten.ParamI_iIdCliente = iIdCliente;
				frmBAten.ParamIO_sIdAtencion = "";

				frmBAten.ShowDialog(this);
				if (frmBAten.DialogResult==System.Windows.Forms.DialogResult.OK)
				{
					if(this.txtsIdAtencion.Text!=frmBAten.ParamIO_sIdAtencion)
					{
						this.txtsIdAtencion.Text=frmBAten.ParamIO_sIdAtencion;
						float f1 = frmBAten.ParamO_fImportePrev;
						this.txtfImportePrev.Text=f1.ToString();
						float f2=frmBAten.ParamO_fImporteReal;
						this.Var_iIdAtencion = frmBAten.ParamIO_iIdAtencion;
						this.Var_sIdTipoAtencion = frmBAten.ParamIO_sIdTipoAtencion;
						this.Var_sTipoAtencion = frmBAten.ParamIO_sTipoAtencion;
						if(this.Var_sIdTipoAtencion=="1") 
						{
							this.Var_iNumAtencion= Calcula_iNumAtencion(this.Var_iIdAtencion);
							this.nupImporteCli.Enabled=true;
						}
						else 
						{
							this.nupImporteCli.Value=Convert.ToDecimal(f2);
							this.nupImporteCli.Enabled=false;
						}
					}
				}
				frmBAten.Dispose();
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region txtsIdAtencion_Leave
		private void txtsIdAtencion_Leave(object sender, System.EventArgs e)
		{
			try
			{
				GESTCRM.Formularios.Busquedas.frmMBuscaAtenciones frmBAten = new GESTCRM.Formularios.Busquedas.frmMBuscaAtenciones();
				frmBAten.ParamI_iIdDelegado =this.ParamiIdDelegado;
				int iIdCliente = Int32.Parse(this.dgClientes[this.dgClientes.CurrentRowIndex,2].ToString());
				frmBAten.ParamI_iIdCliente = iIdCliente;
				frmBAten.ParamIO_sIdAtencion = this.txtsIdAtencion.Text.ToString();

				frmBAten.Buscar_Atencion();

				if(this.Var_iIdAtencion!=frmBAten.ParamIO_iIdAtencion || frmBAten.ParamIO_iIdAtencion == -1)
				{
					this.txtsIdAtencion.Text=frmBAten.ParamIO_sIdAtencion;
					float f1 = frmBAten.ParamO_fImportePrev;
					this.txtfImportePrev.Text=f1.ToString();
					float f2=frmBAten.ParamO_fImporteReal;
					this.Var_iIdAtencion = frmBAten.ParamIO_iIdAtencion;
					this.Var_sIdTipoAtencion = frmBAten.ParamIO_sIdTipoAtencion;
					this.Var_sTipoAtencion = frmBAten.ParamIO_sTipoAtencion;
					if(this.Var_sIdTipoAtencion=="1") 
					{
						this.Var_iNumAtencion= Calcula_iNumAtencion(this.Var_iIdAtencion);
						this.nupImporteCli.Enabled=true;
					}
					else 
					{
						this.nupImporteCli.Value=Convert.ToDecimal(f2);
						this.nupImporteCli.Enabled=false;
					}
				}

				frmBAten.Dispose();
				
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion
		
		#region Calcula_iNumAtencion
		private int Calcula_iNumAtencion(int iIdAtencion)
		{
			int max=0;
			int iNumAtencion=0;
			for(int i=0 ;i< this.dtAtencionesDg.Rows.Count;i++)
			{
				if(iIdAtencion == Int32.Parse(this.dtAtencionesDg.Rows[i]["iIdAtencion"].ToString()))
				{
					iNumAtencion = int.Parse(this.dtAtencionesDg.Rows[i]["iNumAtencion"].ToString());
					if(iNumAtencion>max) max=iNumAtencion;
				}
			}
			max=max+1;
			return max;
		}
		#endregion

		#region btAtenNuevo_Click
		private void btAtenNuevo_Click(object sender, System.EventArgs e)
		{
			Nueva_Atencion();
		}
		#endregion

		#region btAtenActualizar_Click
		private void btAtenActualizar_Click(object sender, System.EventArgs e)
		{
			Actualiza_Atencion();
		}
		#endregion

		#region btAtenEliminar_Click
		private void btAtenEliminar_Click(object sender, System.EventArgs e)
		{
			Eliminar_Atencion();
		}
		#endregion

		#region Nueva_Atencion
		private void Nueva_Atencion()
		{
			try
			{
				this.txtsIdAtencion.Focus();
				this.txtsIdAtencion.Text="";
				this.nupImporteCli.Value = this.nupImporteCli.Minimum;
				this.txtfImportePrev.Text="";
				this.txtTipoAtencion.Text="";
				this.lblTotAtenciones.Text = this.dtAtencionesDg.Rows.Count.ToString();
				this.Var_iIdAtencion=-1;
				this.Var_iNumAtencion=1;
				this.Var_sIdTipoAtencion="-1";
				this.Var_sTipoAtencion="";

				if(this.ParamTipoAcceso!="C")
				{
					Utiles.Activar_Panel(this.panel3,true);
					Utiles.Activar_Control(this.btAtenActualizar,true);
					Utiles.Activar_Control(this.btAtenEliminar,true);
				}

			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion
		
		#region Actualiza_Atencion
		private void Actualiza_Atencion()
		{
			try
			{
				string sIdCliente=this.dgClientes[this.dgClientes.CurrentRowIndex,0].ToString();
				int iIdCliente=Int32.Parse(this.dgClientes[this.dgClientes.CurrentRowIndex,2].ToString());

				if(this.txtsIdAtencion.Text.ToString().Trim()!="" && this.Var_iIdAtencion>-1 && (this.Var_sIdTipoAtencion=="2" ||(this.Var_sIdTipoAtencion=="1" && this.nupImporteCli.Value>0)))
				{
					string iIdAtencion = this.Var_iIdAtencion.ToString();
					string iNumAtencion = this.Var_iNumAtencion.ToString();

					int fila = Utiles.Buscar_fila_dtTabla(this.dtAtencionesRep,"sIdCliente",sIdCliente,"iIdAtencion",iIdAtencion,"iNumAtencion",iNumAtencion);
					if(fila==-1) //Marcar para Insertar en BD
					{
						DataRow filaRep = this.dtAtencionesRep.NewRow();
						filaRep["iIdCliente"]=iIdCliente;
						filaRep["sIdCliente"]=sIdCliente;
						filaRep["iIdAtencion"]=Int32.Parse(iIdAtencion);
						filaRep["iNumAtencion"]=int.Parse(iNumAtencion);
						filaRep["sIdAtencion"]=this.txtsIdAtencion.Text.ToString();
						filaRep["sIdTipoAtencion"]=this.Var_sIdTipoAtencion;
						filaRep["stipoAtencion"]=this.Var_sTipoAtencion;
						filaRep["fImporte"]=Convert.ToDouble(this.nupImporteCli.Value);
						filaRep["fImportePrev"]=Convert.ToDouble(this.txtfImportePrev.Text.ToString());
						filaRep["bEnviadoCEN"]=0;
						if(this.Var_sIdTipoAtencion=="2") filaRep["fImporteReal"]=Convert.ToDouble(this.nupImporteCli.Value);
						
						this.dtAtencionesRep.Rows.Add(filaRep);
					}
					else //Marcar para Modificar En BD
					{
						this.dtAtencionesRep.Rows[fila]["fImporte"]=Convert.ToDouble(this.nupImporteCli.Value);
						this.dtAtencionesRep.Rows[fila]["fImportePrev"]=Convert.ToDouble(this.txtfImportePrev.Text.ToString());
						if(this.Var_sIdTipoAtencion=="2")
						{
							this.dtAtencionesRep.Rows[fila]["fImporteReal"]=Convert.ToDouble(this.nupImporteCli.Value);
						}
					}


					int NumFilaDg = Utiles.Buscar_fila_dtTabla(this.dtAtencionesDg,"iIdAtencion",iIdAtencion,"iNumAtencion",iNumAtencion);
					if(NumFilaDg==-1) //Insertar en Pantalla
					{
						DataRow filaDg = this.dtAtencionesDg.NewRow();
						filaDg["iIdAtencion"]=iIdAtencion;
						filaDg["iNumAtencion"]=iNumAtencion;
						filaDg["sIdAtencion"]=this.txtsIdAtencion.Text.ToString();
						filaDg["sIdTipoAtencion"]=this.Var_sIdTipoAtencion;
						filaDg["sTipoAtencion"]=this.Var_sTipoAtencion;
						filaDg["fImporte"]=Convert.ToDouble(this.nupImporteCli.Value);
						filaDg["fImportePrev"]=Convert.ToDouble(this.txtfImportePrev.Text.ToString());
						filaDg["bEnviadoCEN"]=0;
						if(this.Var_sIdTipoAtencion=="2") filaDg["fImporteReal"]=Convert.ToDouble(this.nupImporteCli.Value);
						this.dtAtencionesDg.Rows.Add(filaDg);
					}
					else 
					{
						this.dtAtencionesDg.Rows[NumFilaDg]["fImporte"]=Convert.ToDouble(this.nupImporteCli.Value);
						this.dtAtencionesDg.Rows[NumFilaDg]["fImportePrev"]=Convert.ToDouble(this.txtfImportePrev.Text.ToString());
						if(this.Var_sIdTipoAtencion=="2")
						{
							this.dtAtencionesDg.Rows[NumFilaDg]["fImporteReal"]=Convert.ToDouble(this.nupImporteCli.Value);
						}
					}

					Nueva_Atencion();
				}
				else //no se puede añadir la atención
				{
					if(this.nupImporteCli.Value==0)
					{
						Mensajes.ShowError("Importe Obligatorio");
					}
					else
					{
						Mensajes.ShowError("Acción Obligatoria");
					}

				}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region Eliminar_Atencion
		private void Eliminar_Atencion()
		{
			try
			{
				if(this.dgAtenciones.CurrentRowIndex>-1 && this.dgAtenciones[this.dgAtenciones.CurrentRowIndex,8].ToString()=="0")
				{
					string sIdCliente=this.dgClientes[this.dgClientes.CurrentRowIndex,0].ToString();
					//string iIdAtencion = this.dgAtenciones[this.dgAtenciones.CurrentRowIndex,6].ToString();
                    string iIdAtencion = this.dgAtenciones[this.dgAtenciones.CurrentRowIndex, 7].ToString(); //---- GSG (18/06/2015)
					string iNumAtencion = this.dgAtenciones[this.dgAtenciones.CurrentRowIndex,1].ToString();
					//Se borra de tabla interna
					int fila = Utiles.Buscar_fila_dtTabla(this.dtAtencionesRep,"sIdCliente",sIdCliente,"iIdAtencion",iIdAtencion,"iNumAtencion",iNumAtencion);
					if(fila>-1) this.dtAtencionesRep.Rows.RemoveAt(fila);
					//Se borra de pantalla
					int filaDg = Utiles.Buscar_fila_dtTabla(this.dtAtencionesDg,"iIdAtencion",iIdAtencion,"iNumAtencion",iNumAtencion);
					if (filaDg>-1) this.dtAtencionesDg.Rows.RemoveAt(filaDg);
					Nueva_Atencion();
				}
				else
				{
					if(this.dgAtenciones.CurrentRowIndex==-1)
					{
						Mensajes.ShowError("No hay ninguna Atención seleccionada");
					}
					else if(this.dgAtenciones[this.dgAtenciones.CurrentRowIndex,8].ToString()!="0")
					{
						Mensajes.ShowError("No se puede eliminar esta Atención porque está asignada a unas Nota de Gastos que ya ha sido enciada a Central.");
					}
				}
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
				if(fila>-1) this.cbPedidos.SelectedValue = this.dgPedidos[fila,0].ToString();
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
					//			if(fila>-1)
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

		#region VerPedido
		private void VerPedido(int fila)
		{
			try
			{
				char Acceso;

				if(this.ParamTipoAcceso == "C") Acceso='C';
				else Acceso='M';
				if(GESTCRM.Clases.Configuracion.iGPedidos==1)
				{
					Acceso='C';
				}

				if (fila>-1)
				{
					string sIdPedido = this.dgPedidos[fila,0].ToString();
					int iIdDelegado = this.ParamiIdDelegado;

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
							DialogResult dr=Mensajes.ShowQuestion("No se puede modificar el pedido porque ya hay uno abierto. Si quiere modificar un pedido cierre el que ya está abierto. ¿Desea abrirlo en modo consulta?");
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
                                //---- GSG (22/07/2011)
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

		#region btNuevoPedido_Click



		private void btNuevoPedido_Click(object sender, System.EventArgs e)
		{
			try
			{
				bool abierto=false;
				if(GESTCRM.Clases.Configuracion.iGPedidos==0)
				{
					if(this.ParentForm== null && this.Owner==null)
					{
						Mensajes.ShowInformation("No se puede abrir el formulario. Demasiadas ventanas abiertas. ");
					}
					else
					{
						if(this.ParentForm == null) abierto=Utiles.MirarSiFormAbierto("frmPedidos",this.Owner);
						else abierto = Utiles.MirarSiFormAbierto("frmPedidos",this.MdiParent);
						if (!abierto)
						{
                            using (Formularios.frmPedidos frmPed = new Formularios.frmPedidos(this.dgClientes[this.dgClientes.CurrentRowIndex, 0].ToString()))                            
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

                                //---- GSG (22/07/2011) tornat a posar (estava comentat)
                                //---- GSG (13/10/2011) 
                                //LlenarCombo_cbPedidos();
                                LlenarCombo_cbPedidos(this.dgClientes.CurrentRowIndex);
                                //---- FI GSG
                                if (frmPed.IdPedido != null && frmPed.IdPedido.ToString().Trim().Length > 0)
                                {
                                    this.cbPedidos.SelectedValue = frmPed.IdPedido;
                                    Actualizar_Pedido();
                                }
                                 
                            }
                           
						}
						else
						{
							Mensajes.ShowInformation("No se puede crear un pedido porque ya hay un pedido abierto. Si quiere crear un pedido cierre el que ya está abierto.");
						}
					}
				}
				else
				{
					Mensajes.ShowInformation("No se puede crear un pedido. Sólo se pueden consultar.");
				}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion 

		#region btPedNuevo_Click
		private void btPedNuevo_Click(object sender, System.EventArgs e)
		{
			Nuevo_Pedido();
		}
		#endregion

		#region btPedActualizar_Click
		private void btPedActualizar_Click(object sender, System.EventArgs e)
		{
			Actualizar_Pedido();
		}
		#endregion

		#region btPedEliminar_Click
		private void btPedEliminar_Click(object sender, System.EventArgs e)
		{
			Eliminar_Pedido();
		}
		#endregion

		#region Nuevo_Pedido
		private void Nuevo_Pedido()
		{
			try
			{
				this.cbPedidos.Focus();
				this.cbPedidos.SelectedIndex=-1;
				this.cbPedidos.SelectedIndex=-1;
				this.lblTotPedidos.Text = this.dtPedidosDg.Rows.Count.ToString();
			}
			catch{}
		}
		#endregion

		#region Actualizar_Pedido
		private void Actualizar_Pedido()
		{
			try
			{
                string sIdCliente = this.dgClientes[this.dgClientes.CurrentRowIndex,0].ToString();
				int iIdCliente = Int32.Parse(this.dgClientes[this.dgClientes.CurrentRowIndex,2].ToString());

                //if(this.cbPedidos.SelectedIndex!=-1)
                //{
                //    int NumFilaDg = Utiles.Buscar_fila_dtTabla(this.dtPedidosDg,"sIdPedido",this.cbPedidos.SelectedValue.ToString());
                //    if(NumFilaDg==-1) //Insertar el Pedido en tabla
                //    {
                //        DataRow filaDg = this.dtPedidosDg.NewRow();
                //        int FilaPed = Utiles.Buscar_fila_dtTabla(this.dsReports1.ListaPedidosAsignables,"sIdPedido",this.cbPedidos.SelectedValue.ToString());
                //        if(FilaPed>-1)
                //        {
                //            filaDg["sIdPedido"]=this.cbPedidos.SelectedValue.ToString();
                //            filaDg["dFechaPedido"]=this.dsReports1.ListaPedidosAsignables.Rows[FilaPed]["dFechaPedido"];
                //            filaDg["sIdTipoPedido"]=this.dsReports1.ListaPedidosAsignables.Rows[FilaPed]["sIdTipoPedido"].ToString();

                //            this.dtPedidosDg.Rows.Add(filaDg);
                //        }
                //    }
                //    Nuevo_Pedido();

                //}

                if(this.cbPedidos.SelectedIndex!=-1)
				{
					int NumFilaRep = Utiles.Buscar_fila_dtTabla(this.dtPedidosRep,"sIdPedido",this.cbPedidos.SelectedValue.ToString(),"sIdCliente", sIdCliente);
					if(NumFilaRep==-1) //Insertar el Pedido en tabla
					{
						DataRow filaRep = this.dtPedidosRep.NewRow();
						int FilaPed = Utiles.Buscar_fila_dtTabla(this.dsReports1.ListaPedidosAsignables,"sIdPedido",this.cbPedidos.SelectedValue.ToString());
						if(FilaPed>-1)
						{
							filaRep["sIdPedido"]=this.cbPedidos.SelectedValue.ToString();
							filaRep["dFechaPedido"]=this.dsReports1.ListaPedidosAsignables.Rows[FilaPed]["dFechaPedido"];
							filaRep["sIdTipoPedido"]=this.dsReports1.ListaPedidosAsignables.Rows[FilaPed]["sIdTipoPedido"].ToString();
                            filaRep["sIdCliente"] = sIdCliente;
                            filaRep["iIdCliente"] = iIdCliente;

                            this.dtPedidosRep.Rows.Add(filaRep);
						}
					}


                    int NumFilaDg = Utiles.Buscar_fila_dtTabla(this.dtPedidosDg, "sIdPedido", this.cbPedidos.SelectedValue.ToString());
                    if (NumFilaDg == -1) //Insertar en Pantalla
                    {
                        DataRow filaDg = this.dtPedidosDg.NewRow();
                        int FilaPed = Utiles.Buscar_fila_dtTabla(this.dsReports1.ListaPedidosAsignables, "sIdPedido", this.cbPedidos.SelectedValue.ToString());
                        if (FilaPed > -1)
                        {
                            filaDg["sIdPedido"] = this.cbPedidos.SelectedValue.ToString();
                            filaDg["dFechaPedido"] = this.dsReports1.ListaPedidosAsignables.Rows[FilaPed]["dFechaPedido"];
                            filaDg["sIdTipoPedido"] = this.dsReports1.ListaPedidosAsignables.Rows[FilaPed]["sIdTipoPedido"].ToString();

                            this.dtPedidosDg.Rows.Add(filaDg);
                        }
                    }
                    

					Nuevo_Pedido();

				}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}


     	#endregion

		#region Eliminar_Pedido
		private void Eliminar_Pedido()
		{
			try
			{
				if(this.dgPedidos.CurrentRowIndex>-1)
				{
					string sIdPedido = this.dgPedidos[this.dgPedidos.CurrentRowIndex,0].ToString();
                    
                    string sIdCliente = this.dgClientes[this.dgClientes.CurrentRowIndex, 0].ToString();

                    //Se borra de tabla interna
                    int fila = Utiles.Buscar_fila_dtTabla(this.dtPedidosRep, "sIdCliente", sIdCliente, "sIdPedido", sIdPedido);
                    if (fila > -1) this.dtPedidosRep.Rows.RemoveAt(fila);
					//Borrar el pedido en tabla
					int filaDg = Utiles.Buscar_fila_dtTabla(this.dtPedidosDg,"sIdPedido",sIdPedido);
					if(filaDg > -1) this.dtPedidosDg.Rows.RemoveAt(filaDg);

					Nuevo_Pedido();
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
				int dgfila = this.dgProductos.CurrentRowIndex;
				Utiles.Seleccionar_UnaFilaDataGrid(this,this.dgProductos,dgfila);

				this.txtsIdProducto.Text=this.dgProductos[dgfila,0].ToString();
				this.txtsProducto.Text=this.dgProductos[dgfila,1].ToString();
				
				this.nudiOrden.Value = int.Parse(this.dgProductos[dgfila,3].ToString());
				this.nudiMuestras.Value=int.Parse(this.dgProductos[dgfila,4].ToString());

				Utiles.Activar_Control(this.txtsIdProducto,false);
				Utiles.Activar_Control(this.btBuscarProducto,false);
				
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region txtsIdProducto_Leave
		private void txtsIdProducto_Leave(object sender, System.EventArgs e)
		{
			try
			{
				GESTCRM.Formularios.Busquedas.frmMProductos frmBProd = new GESTCRM.Formularios.Busquedas.frmMProductos();
				frmBProd.ParamIO_sDescripcion = "";
				frmBProd.ParamIO_sIdProducto = this.txtsIdProducto.Text.ToString();
				frmBProd.Buscar_sProducto();
				if(this.txtsProducto.Text!=frmBProd.ParamIO_sDescripcion)
				{
					if(this.txtsIdProducto.Text.ToString().Length>0 && frmBProd.ParamIO_sIdProducto=="") Mensajes.ShowError("Este código de Producto no existe.");
					this.txtsIdProducto.Text=frmBProd.ParamIO_sIdProducto;
					this.txtsProducto.Text=frmBProd.ParamIO_sDescripcion;
				}
				frmBProd.Dispose();
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region btBuscarProducto_Click
		private void btBuscarProducto_Click(object sender, System.EventArgs e)
		{
			try
			{
				GESTCRM.Formularios.Busquedas.frmMProductos frmBProd = new GESTCRM.Formularios.Busquedas.frmMProductos();
				frmBProd.ParamIO_sDescripcion = "";
				frmBProd.ParamIO_sIdProducto = "";
				frmBProd.ShowDialog(this);
				if (frmBProd.DialogResult==System.Windows.Forms.DialogResult.OK)
				{
					if(this.txtsProducto.Text!=frmBProd.ParamIO_sDescripcion)
					{
						this.txtsIdProducto.Text=frmBProd.ParamIO_sIdProducto;
						this.txtsProducto.Text=frmBProd.ParamIO_sDescripcion;
					}
				}
				frmBProd.Dispose();
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region btAnadirProd_Click
		private void btAnadirProd_Click(object sender, System.EventArgs e)
		{
			Nuevo_Producto();
		}
		#endregion

		#region btModifProd_Click
		private void btModifProd_Click(object sender, System.EventArgs e)
		{
			Actualizar_Producto();
		}
		#endregion

		#region btBorrarProd_Click
		private void btBorrarProd_Click(object sender, System.EventArgs e)
		{
			Eliminar_Producto();
		}
		#endregion

		#region Nuevo_Producto
		private void Nuevo_Producto()
		{
			try
			{

				this.txtsIdProducto.Focus();
				this.txtsIdProducto.Text="";
				this.txtsProducto.Text="";
				//this.cbPromociona.SelectedIndex=1;
				//this.cbPromociona.SelectedIndex=1;
                //this.nudiOrden.Value = 1; //---- GSG (19/12/2013)
                this.nudiOrden.Value = this.dsReports1.ListaPromocionProd.Rows.Count + 1;
				this.nudiMuestras.Value=1;

				
				//this.cbPromociona.Enabled=false;
				Utiles.Activar_Control(this.txtsIdProducto,true);
				Utiles.Activar_Control(this.btBuscarProducto,true);

				this.lblTotProductos.Text = dsReports1.ListaPromocionProd.DefaultView.Count.ToString();

			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region Actualizar_Producto
		private void Actualizar_Producto()
		{
			try
			{
				if(this.txtsIdProducto.Text.ToString().Trim()!="" )
				{
					int NumFilaDg = Utiles.Buscar_fila_dtTabla(dsReports1.ListaPromocionProd,"sIdProducto",this.txtsIdProducto.Text.ToString(),"iIdCliente",this.dgClientes[this.dgClientes.CurrentRowIndex,2].ToString());
					if(NumFilaDg==-1) //Insertar en pantalla
					{
						DataRow oFila = dsReports1.ListaPromocionProd.NewRow();
						oFila["sDescripcion"]= this.txtsProducto.Text.ToString();
						oFila["Orden"] = this.nudiOrden.Value;
						oFila["iCantidad"]= this.nudiMuestras.Value; 
						oFila["sIdProducto"] = this.txtsIdProducto.Text.ToString();
	                    oFila["iIdCliente"] = this.dgClientes[this.dgClientes.CurrentRowIndex,2].ToString();
						dsReports1.ListaPromocionProd.Rows.Add(oFila);
						dsReports1.ListaPromocionProd.AcceptChanges();
					}
					else //Modificar en pantalla
					{
						
                        //---- GSG (19/12/2013)
                        //dsReports1.ListaPromocionProd.Rows[NumFilaDg]["Orden"] = this.nudiOrden.Value;
                        //renumerar lista
                        int orden = 1;
                        foreach (DataRow row in dsReports1.ListaPromocionProd.Rows)
                        {
                            row["Orden"] = orden;
                            orden++;
                        }
                        dsReports1.ListaPromocionProd.AcceptChanges();
                        //---- FI GSG




						dsReports1.ListaPromocionProd.Rows[NumFilaDg]["iCantidad"]=this.nudiMuestras.Value;
					}
					dsReports1.ListaPromocionProd.DefaultView.RowFilter = "iIdCliente = " + this.dgClientes[this.dgClientes.CurrentRowIndex,2].ToString();

					Nuevo_Producto();
				}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}


        

		#endregion

		#region Eliminar_Producto
		private void Eliminar_Producto()
		{
			try
			{
				if(this.dgProductos.CurrentRowIndex>-1)
				{
					string sIdProducto = this.dgProductos[this.dgProductos.CurrentRowIndex,3].ToString();
					string siIdCliente = dgProductos[dgProductos.CurrentRowIndex,4].ToString();

					//Borrar en pantalla
					int filaDg = Utiles.Buscar_fila_dtTabla(dsReports1.ListaPromocionProd,"sIdProducto",sIdProducto,"iIdCliente",siIdCliente);
					if(filaDg>-1) 
					{
						dsReports1.ListaPromocionProd.Rows.RemoveAt(filaDg);
						dsReports1.ListaPromocionProd.AcceptChanges();

                        //---- GSG (19/12/2013)
                        //renumerar lista
                        int orden = 1;
                        foreach (DataRow row in dsReports1.ListaPromocionProd.Rows)
                        {
                            row["Orden"] = orden;
                            orden++;
                        }
                        dsReports1.ListaPromocionProd.AcceptChanges();
                        //---- FI GSG
					}
					Nuevo_Producto();
				}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

        


        //Limpiar_dtTablaRep
		//Se marcan para borrar todos los registros recuperados de BD
		//Se borran todos los registros bo recuperados de BD
		#region Limpiar_dtTablaRep
		private void Limpiar_dtTablaRep(DataTable dt)
		{
			try
			{
				for(int i=dt.Rows.Count-1;i>=0;i--)
				{
					if(dt.Rows[i]["iIdReport"].ToString().Trim().Length==0)
					{
						dt.Rows.RemoveAt(i);
					}
					else
					{
						dt.Rows[i]["Accion"]="B";
					}
				}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion


		//Limpiar_dtTablaRep_Cliente
		//Se marcan para borrar todos los registros de un Cliente recuperados de BD
		//Se borran todos los registros de un Cliente no recuperados de BD
		#region Limpiar_dtTablaRep_Cliente
		private void Limpiar_dtTablaRep_Cliente(DataTable dt,string sIdCliente)
		{
			try
			{
				for(int i=dt.Rows.Count-1;i>=0;i--)
				{
					if(dt.Rows[i]["sIdCliente"].ToString()==sIdCliente)
					{
							dt.Rows.RemoveAt(i);
					}
				}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		//Limpiar_dtTablaDg_Cliente
		//Se borran por pantalla todos los registros de un Cliente
		#region Limpiar_dtTablaDg_Cliente
		private void Limpiar_dtTablaDg_Cliente(DataTable dt,string sIdCliente)
		{
			try
			{
				for(int i=dt.Rows.Count-1;i>=0;i--)
				{
					if(dt.Rows[i]["sIdCliente"].ToString()==sIdCliente)
					{
						dt.Rows.RemoveAt(i);
					}
				}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		//MarcarRegModificarBD_dtTablaRep
		//Las tablas dtTablaRep son para actualizar registros en BD
		//Aquí se marca para modificar en BD un registro si se ha recuperado de BD o se marca
		//para insertar si todavía no ha sido guardado
		#region MarcarRegModificarBD_dtTablaRep
		private void MarcarRegModificarBD_dtTablaRep(DataTable dt,int fila)
		{
			try
			{
				//No tiene el iIdReport informado => no está en BD => se marca para insertar en BD
				if(dt.Rows[fila]["iIdReport"].ToString().Trim().Length==0)
				{
					dt.Rows[fila]["Accion"]="I";
				}
				else//Tiene el iIdReport informado => recuperado de BD => se marca para modificar en BD
				{
					dt.Rows[fila]["Accion"]="M";
				}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion


		//MarcarRegBorrarBD_dtTablaRep
		//Las tablas dtTablaRep son para actualizar registros en BD
		//Aquí se marca para borrar en BD un registro si se ha recuperado de BD o se elimina
		//si todavía no ha sido guardado
		#region MarcarRegBorrarBD_dtTablaRep
		private void MarcarRegBorrarBD_dtTablaRep(DataTable dt,int fila)
		{
			try
			{
				//No tiene el iIdReport informado => no está en BD => se elimina de la tabla
				if(dt.Rows[fila]["iIdReport"].ToString().Trim().Length==0)
				{
					dt.Rows.RemoveAt(fila);
				}
				else//Tiene el iIdReport informado => recuperado de BD => se marca para borrar en BD
				{
					dt.Rows[fila]["Accion"]="B";
				}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion


		
		#region Activar_Formulario
		private void Activar_Formulario()
		{
			try
			{
				switch(this.ParamTipoAcceso)
				{
					case "C": Activar_Formulario_Consulta();break;
					case "A": Activar_Formulario_Alta();break;
					case "M": Activar_Formulario_Modificacion();break;
					default: break;
				}

				switch(this.ParamTipoAcceso)
				{
					case "C":
						if(this.Var_bPlanificacion==0) this.lblReporting.Text="Consulta de un report de actividad";
						else this.lblReporting.Text="Consulta de una planificación";
						break;
					case "A":
						if(this.Var_bPlanificacion==0) this.lblReporting.Text="Alta de un report de actividad";
						else this.lblReporting.Text="Alta de una planificación";
						break;
					case "M":
						if(this.Var_bPlanificacion==0) this.lblReporting.Text="Modificación de un report de actividad";
						else this.lblReporting.Text="Modificación de una planificación";
						break;
					default: break;
				}

				//Se comprueba si tiene acceso a Centros
				if(GESTCRM.Clases.Configuracion.iGCentros==2) this.btVerCentro.Enabled=false;
				else this.btVerCentro.Enabled=true;

				//Se comprueba si tiene acceso a Pedidos
				if(GESTCRM.Clases.Configuracion.iGPedidos==2) 
				{
					this.btNuevoPedido.Enabled=false;
					this.dgPedidos.TableStyles[0].GridColumnStyles[3].Width=0;
				}
				else if(GESTCRM.Clases.Configuracion.iGPedidos==1) 
				{
					this.btNuevoPedido.Enabled=false;
					this.dgPedidos.TableStyles[0].GridColumnStyles[3].Width=40;
				}
				else
				{
					this.btNuevoPedido.Enabled=true;
					this.dgPedidos.TableStyles[0].GridColumnStyles[3].Width=40;
				}

				//Se comprueba el acceso a Clientes COM
				if(this.cbTipoCliente.SelectedValue.ToString()=="C")
				{
					if(GESTCRM.Clases.Configuracion.iGClientesCOM==2)
					{
						this.dgClientes.TableStyles[0].GridColumnStyles[8].Width=0;
					}
				}
				else if(this.cbTipoCliente.SelectedValue.ToString()=="S")
				{
					if(GESTCRM.Clases.Configuracion.iGClientesSAP==2)
					{
						this.dgClientes.TableStyles[0].GridColumnStyles[8].Width=0;
					}
				}

			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region Activar_Formulario_Consulta
		private void Activar_Formulario_Consulta()
		{
			try
			{
				Utiles.Activar_Panel(this.pnClientesVisitados,false);
				Utiles.Activar_Panel(this.pnProductosProm,false);
				Utiles.Activar_Panel(this.pnReportActiv,false);
//				if(this.dtpFecha.Value<= DateTime.Now.Date) //Es un Report
				if(this.Var_bPlanificacion==0) //Es un Report
				{
                    if (this.dtClientesDg.Rows.Count == 0)
                    {
                        this.pnDatosClienteVisita.Visible = false;
                        //---- GSG (21/11/2013)
                        this.pnProductosProm.Visible = false;
                    }
                    else
                    {
                        this.pnDatosClienteVisita.Visible = true;
                        if (this.cbTipoRActibidad.SelectedValue.ToString() == "1") this.pnPedidos.Visible = false;
                        else this.pnPedidos.Visible = true;
                        //---- GSG (21/11/2013)
                        this.pnProductosProm.Visible = true;
                    }
				}
				else //es la planificación de una visita
				{
					this.pnDatosClienteVisita.Visible=false;
                    //---- GSG (21/11/2013)
                    this.pnProductosProm.Visible = false;

					if(this.cbTipoCliente.SelectedValue.ToString()=="C")
					{
						Cargar_dgClientesProxObj();
						this.pnDatosClientesPlanif.Visible=true;
					}
				}

				//Un ClienteSAP no tiene sustituto
				if(this.cbTipoCliente.SelectedValue.ToString()=="S") this.dgClientes.TableStyles[0].GridColumnStyles[3].Width=0;

			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region Activar_Formulario_Alta
		private void Activar_Formulario_Alta()
		{
			try
			{
				if(this.dtpFecha.Value<= DateTime.Now.Date) //Creando un Report
				{
					//Como no hay Clientes se desactivan Gadgets, Atenciones y Pedidos
					this.pnDatosClienteVisita.Visible=false;
					this.Var_bPlanificacion=0;
                    //---- GSG (21/11/2013)
                    this.pnProductosProm.Visible = false;
				}
				else // Planificando un Report
				{
					//En una Planificación no hay Productos, Pedidos, Gadgets ni Atenciones
					this.Var_bPlanificacion=1;
					this.pnDatosClienteVisita.Visible=false;
                    //---- GSG (21/11/2013)
                    this.pnProductosProm.Visible = false;


					this.cbTipoRActibidad.Enabled=false;
					if(this.cbTipoCliente.SelectedValue.ToString()=="C")
					{
						Cargar_dgClientesProxObj();
						this.pnDatosClientesPlanif.Visible=true;
					}
				}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region Activar_Formulario_Modificacion
		private void Activar_Formulario_Modificacion()
		{
            //bool Convertir = false;
			try
			{
				if(this.dtpFecha.Value<= DateTime.Now.Date && this.Var_bPlanificacion==1)
				{
					DialogResult dr = Mensajes.ShowQuestion("Es una Visita Planificada y la fecha no es superior al día de hoy. Puede consultarla o convertirla en Report de Actividad. ¿Desea convertirla en Report de Actividad?");
					if(dr == DialogResult.Yes)
					{
						this.Var_bPlanificacion=0;
                        //Convertir = true;
                        //---- GSG (23/03/2012)
                        //Si les poso iguales al grabar donarà avís i obligarà a canviar-les
                        txbHoraInicio.Text = "";
                        dtpHoraInicio.Value = DateTime.Today;
                        txbHoraFin.Text = "";
                        dtpHoraFin.Value = dtpHoraInicio.Value;
                        dtpHoraInicio.Text = "";
                        dtpHoraFin.Text = "";
                        //---- GSG (15/05/2012)
                        _convertit = true;
					}
					else
					{
						this.ParamTipoAcceso="C";
					}
				}

				if(this.ParamTipoAcceso=="M")
				{
//					if(this.dtpFecha.Value<= DateTime.Now.Date) //Es un Report
					if(this.Var_bPlanificacion==0) //Es un Report
					{
						//Un Report de tipo Pedido el Tipo de Cliente es fijo
						if (this.cbTipoRActibidad.SelectedValue.ToString()=="2")
                            this.cbTipoCliente.Enabled=false;

						//Un Report sin Clientes asociados no puede asignarle Gadgets, Atenciones ni Pedidos
                        if (this.dtClientesDg.Rows.Count <= 0)
                        {
                            this.pnDatosClienteVisita.Visible = false;
                            //---- GSG (21/11/2013)
                            this.pnProductosProm.Visible = false;
                        }
                        else
                        {
                            this.pnDatosClienteVisita.Visible = true;
                            if (this.cbTipoRActibidad.SelectedValue.ToString() == "1")
                                this.pnPedidos.Visible = false;
                            else this.pnPedidos.Visible = true;
                            //---- GSG (10/03/2015)
                            //---- GSG (21/11/2013)
                            //this.pnProductosProm.Visible = true;
                            if (this.pnPedidos.Visible)
                                this.pnProductosProm.Visible = false;
                            else
                                this.pnProductosProm.Visible = true;
                        }

					}
					else // Planificando un Report
					{
						this.pnDatosClienteVisita.Visible = false;
                        //---- GSG (23/02/2015)     
                        Cargar_dgProductos();

						this.cbTipoRActibidad.Enabled = false;
						if (this.cbTipoCliente.SelectedValue.ToString() == "C")
						{
							Cargar_dgClientesProxObj();
							this.pnDatosClientesPlanif.Visible=true;
						}
					}

					this.dtpFecha.Enabled=false;
					
					//Si el tipo de Cliente
					//es Cliente SAP se debe permitir modificar el Tipo de Report
					if(this.cbTipoCliente.SelectedValue.ToString()=="S")
					{
						this.cbTipoRActibidad.Enabled=true;
					}
					else this.cbTipoRActibidad.Enabled=false;
					
					this.cbTipoCliente.Enabled=false;
					this.cbHorario.Enabled=false;

                    //RH
                    txbHoraInicio.Enabled = true;
                    txbHoraFin.Enabled = true;

					//Un ClienteSAP no tiene Centro asociado
					if(this.cbTipoCliente.SelectedValue.ToString()=="S") 
					{
						this.cbSustituto.Visible=false;
						this.dgClientes.TableStyles[0].GridColumnStyles[3].Width = 0;
						if (this.dtClientesDg.Rows.Count > 0)
                            Activa_Cliente(false);
					}
					
					//En una modificación de Report o Planificación no está
					//permitido modificar el Centro
					Activa_Centro(false);

				}
				else
				{
					Activar_Formulario_Consulta();
				}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region Activa_Centro
		private void Activa_Centro(bool Activo)
		{
			try
			{
				if(!Activo && this.cbTipoCliente.SelectedValue.ToString()=="S") 
				{
					this.txtsCentro.Text=null;
					this.txtsIdCentro.Text=null;
					this.Var_iIdCentro=-1;
				}
				Utiles.Activar_Control(this.txtsIdCentro,Activo);
				Utiles.Activar_Control(this.btBuscarCentro,Activo);
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region Activa_Cliente
		private void Activa_Cliente(bool Activo)
		{
			try
			{
//				if(!Activo) this.txtClienteSAP.Text=null;
				Utiles.Activar_Control(this.txtClienteSAP,Activo);
				Utiles.Activar_Control(this.btBuscarCliente,Activo);
//				Utiles.Activar_Control(this.txtClienteObserv,Activo);
//				Utiles.Activar_Control(this.txtClienteObjetivo,Activo);
//				Utiles.Activar_Control(this.txtClienteProxObj,Activo);
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion
        		

		#region btSalir_Click
		private void btSalir_Click(object sender, System.EventArgs e)
		{
            //---- GSG (03/07/2019)
            //this.Close();
            _bSalidaFlecha = true;
            btGrabar_Click(sender, e);

        }
		#endregion

		#region frmReporting_Closing
		private void frmReporting_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
            //---- GSG (03/07/2019) ho comento
            /*
            try
			{
				if(this.ParamTipoAcceso!="C" && !SalirDesdeGuardar)
				{
					DialogResult dr1=Mensajes.ShowQuestion(3002);
					if(dr1 == System.Windows.Forms.DialogResult.Yes)
					{
						if(Validar_Report())
						{
                            //---- GSG (23/11/2011)

                            ////---- GSG (29/07/2011)
                            ////if (Grabar_Report())
                            ////{
                            ////    Utiles.Cargar_Planificacion = true;
                            ////    Mensajes.ShowInformation(3004);
                            ////}
                            ////else
                            ////{
                            ////    e.Cancel = true;
                            ////}

                            //int nBucle = 0;

                            //if (this.cbTipoCliente.SelectedValue.ToString() == "S")
                            //    nBucle = this.dtClientesDg.Rows.Count;
                            //else if (this.Var_bPlanificacion == 0) //no planificació
                            //    nBucle = 1;

                            //bool grabarOk = true;
                            
                            //// Si no es una Planificacion
                            //if (this.Var_bPlanificacion == 0)
                            //{
                            //    for (int i = 0; i < nBucle; i++)
                            //    {
                            //        grabarOk = grabarOk && Grabar_Report(Int32.Parse(this.dtClientesDg.Rows[i]["iIdCliente"].ToString()));
                            //    }
                            //}
                            //else //Planificación
                            //{
                            //    grabarOk = grabarOk && Grabar_Report(0);
                            //}

                            //if (grabarOk)
                            //{
                            //    Utiles.Cargar_Planificacion = true;
                            //    Mensajes.ShowInformation(3004);
                            //}
                            //else
                            //{
                            //    e.Cancel = true;
                            //}
                            ////---- FI GSG

                            int nBucle = 0;

                            if (this.cbTipoCliente.SelectedValue.ToString() == "S")
                                nBucle = this.dtClientesDg.Rows.Count;

                            bool grabarOk = true;

                            if (this.cbTipoCliente.SelectedValue.ToString() == "S")
                            {
                                for (int i = 0; i < nBucle; i++)
                                {
                                    grabarOk = grabarOk && Grabar_Report(Int32.Parse(this.dtClientesDg.Rows[i]["iIdCliente"].ToString()));
                                }
                            }
                            else
                            {
                                grabarOk = grabarOk && Grabar_Report(0);
                            }

                            if (grabarOk)
                            {
                                Mensajes.ShowInformation(3004);
                                this.SalirDesdeGuardar = true;
                                this.Close();
                            }//del Grabar
						}
						else
						{
							e.Cancel=true;
						}
					}
				}
				else if(SalirDesdeGuardar)
				{
					Utiles.Cargar_Planificacion=true;
				}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
            */
		}
		#endregion

		#region frmReporting_Closed
		private void frmReporting_Closed(object sender, System.EventArgs e)
		{
			this.Dispose();
		}
		#endregion
		
		#region btGrabar_Click
        //---- GSG (29/07/2011) Modificació per a que en cas de ClientesSAP (no persona) 
        // gravi un report per client seleccionat.
        // En aquest cas fins ara sols es podia seleccionar un client, ara se'n podran seleccionar varis (igual que quan es tria persona)

        private void btGrabar_Click(object sender, System.EventArgs e)
        {
            int nBucle = 0;

            try
            {
                //---- GSG (17/10/2011)
                //if (this.cbTipoCliente.SelectedValue.ToString() == "S")
                //    nBucle = this.dtClientesDg.Rows.Count;
                //else if (this.Var_bPlanificacion == 0) //no planificació
                //    nBucle = 1;

                //Si farmacia (SAP) --> tantes capçaleres com farmacies (clients)
                //Si metges (Persona) --> sols una capçalera i no calen metges (clients). Poden haber-n'hi o no
                //Si planificació --> igual que si no fos planificació. La implicació és que no caldrà l'hora

                if (this.cbTipoCliente.SelectedValue.ToString() == "S")
                    nBucle = this.dtClientesDg.Rows.Count;
                //---- FI GSG


                if (nBucle > 0)
                {

                    if (Validar_Report())
                    {
                        bool grabarOk = true;

                        if (this.cbTipoCliente.SelectedValue.ToString() == "S")
                        {
                            for (int i = 0; i < nBucle; i++)
                            {
                                //---- GSG (03/07/2019)
                                //grabarOk = grabarOk && Grabar_Report(Int32.Parse(this.dtClientesDg.Rows[i]["iIdCliente"].ToString()));
                                //-- Si hay encuesta obligatoria y no se ha contestado no se puede guardar la visita
                                if (this.dtpFecha.Value <= DateTime.Now.Date)
                                    Encuestas(false, this.dtClientesDg.Rows[i]["sIdCliente"].ToString());
                                else
                                    _bEncuesta = true;

                                if (!_bEncuesta) 
                                {
                                    Mensajes.ShowError("No se guardará la visita del cliente " + this.dtClientesDg.Rows[i]["sIdCliente"].ToString() + " hasta que haya contestado la encuesta.");
                                    grabarOk = false;
                                }
                                else
                                    grabarOk = grabarOk && Grabar_Report(Int32.Parse(this.dtClientesDg.Rows[i]["iIdCliente"].ToString()));
                            }
                        }
                        else
                        {
                            grabarOk = grabarOk && Grabar_Report(0);
                        }

                        if (grabarOk)
                        {
                            Mensajes.ShowInformation(3004);
                            this.SalirDesdeGuardar = true;
                            this.Close();
                        }//del Grabar
                    }//del Validar

                    _bSalidaFlecha = false; //---- GSG (03/07/2019)


                }
                else if (_bSalidaFlecha) //---- GSG (03/07/2019)
                {
                    _bSalidaFlecha = false;
                    this.Close();
                }
                else
                {
                    Mensajes.ShowInformation("No se puede guardar la visita. No ha seleccionado ningún cliente.");
                }
            }//del try
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }


		#endregion

		#region Validar_Report
		private bool Validar_Report()
		{
			try
			{
				if(this.dtpFecha.Value <= DateTime.Now.Date)
				{
					return Validar_ReportActividad();
				}
				else
				{
					return Validar_ReportPlanificado();
				}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);return false;}
		}
		#endregion

		//Validar_ReportActividad
		//Campos Obligatorios
		//  Fecha, Tipo Report,Tipo Cliente, Horario (por programación ninguno puede ser nulo por lo que no se comprueba)
		//  Si Tipo Report = Pedido 
		//       => Tipo Cliente = ClienteSAP (se pone por programación y no se puede cambiar, no se comprueba)
		//  Si Tipo Report = Visita
		//       => No puede tener pedidos asociados (ya se controla por programación, no se comprueba)
		//  Si Tipo Cliente = ClienteCOM => Obligatorio Centro y un Cliente asociado al Centro
		//  Si Tipo Cliente = ClienteSAP => Obligatorio un único Cliente
		//  Mínimo ha de tener los productos promocionados asociados (se controla por programación, no se comprueba)
		#region Validar_ReportActividad
		private bool Validar_ReportActividad()
		{
            StringBuilder ErrorMessage = new StringBuilder();
            char dot = (char)0x25CF;

			try
			{
                //---- GSG (30/08/2011)
                ////RH
                //if (txbHoraInicio.Text.Length == 0)
                //{
                //    ErrorMessage.AppendFormat("{0} Debe introducir la hora de inicio.", dot);
                //}

                //if (txbHoraFin.Text.Length == 0)
                //{
                //    if (ErrorMessage.Length > 0)
                //        ErrorMessage.Append("\n");
                //    ErrorMessage.AppendFormat("{0} Debe introducir la hora de finalización.", dot);
                //}


                if (this.cbTipoCliente.SelectedValue.ToString() == "S")
                {
                    ErrorMessage = Validar_Fechas();
                }
                else
                {
                    if (txbHoraInicio.Text.Length == 0)
                    {
                        ErrorMessage.AppendFormat("{0} Debe introducir la hora de inicio.", dot);
                    }

                    if (txbHoraFin.Text.Length == 0)
                    {
                        if (ErrorMessage.Length > 0)
                            ErrorMessage.Append("\n");
                        ErrorMessage.AppendFormat("{0} Debe introducir la hora de finalización.", dot);
                    }

                    ErrorMessage = Validar_Hora();
                }

                //---- FI GSG



                //---- GSG (29/07/2011)
                //if (this.cbTipoCliente.SelectedValue.ToString() == "S")//ClienteSAP
                //{
                //    if (this.dtClientesDg.Rows.Count > 1)
                //    {
                //        if (ErrorMessage.Length > 0)
                //            ErrorMessage.Append("\n");
                //        ErrorMessage.AppendFormat("{0} Es obligatorio introducir un único cliente.", dot);
                //    }
                //}
                //---- FI GSG



                


                if ((cbTipoCliente.SelectedValue.ToString() == "C") && (this.txtsIdCentro.Text.Trim().Length == 0))
                {
                    if (ErrorMessage.Length > 0)
                        ErrorMessage.Append("\n");
                    ErrorMessage.AppendFormat("{0} Es obligatorio introducir el centro.", dot);
                }

                if (this.dtClientesDg.Rows.Count == 0)
                {
                    if (ErrorMessage.Length > 0)
                        ErrorMessage.Append("\n");
                    ErrorMessage.AppendFormat("{0} Es obligatorio introducir como mínimo un cliente.", dot);
                }

                if (ErrorMessage.Length > 0)
                {
                    Mensajes.ShowError(ErrorMessage.ToString());
                    return false;
                }
				
				return true;
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);return false;}
		}
		#endregion

		//Validar_ReportPlanificado
		//Campos Obligatorios
		//  Tipo Report= Visita (por programación ya se pone este valor y el campo no es modificable por lo que no se comprueba)
		//  Fecha, Tipo Cliente, Horario (por programación ninguno puede ser nulo por lo que no se comprueba)
		//  Si Tipo Cliente = ClienteCOM => Obligatorio Centro
		//  Si Tipo Cliente = ClienteSAP => Obligatorio un único Cliente
		#region Validar_ReportPlanificado
		private bool Validar_ReportPlanificado()
		{
			try
			{
                if (this.cbTipoCliente.SelectedValue.ToString() == "S")//ClienteSAP 
				{
                    //---- GSG (29/07/2011)

                    //if(this.dtClientesDg.Rows.Count!=1)
                    //{
                    //    Mensajes.ShowError("Es obligatorio introducir un único ClienteSAP.");
                    //    return false;
                    //}

                    if (this.dtClientesDg.Rows.Count == 0)
                    {
                        Mensajes.ShowError("Es obligatorio introducir como mínimo un ClienteSAP.");
                        return false;
                    }
                    //---- FI GSG
				}
				else
				{
					if(this.txtsIdCentro.Text.Trim().Length==0)
					{
						Mensajes.ShowError("Es obligatorio introducir el Centro.");
						return false;
					}
				}
				return true;
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);return false;}
		}
		#endregion

		//Grabar_Report
		//Se utiliza una única transacción
		//Grabar por el siguiente orden en: 
		//  RepActividad_Cab
		//  RepActividad_Cli 
		//  RepActividadCli_ProxObj
		//  RepActividad_Gad
		//  RepActividad_Aten
		//  AtencionesComerciales(Actualizar ImporteReal)
		//  RepActividad_Prod
		//  RepActividad_Ped
		#region Grabar_Report
		private bool Grabar_Report(int idCliAct)
		{
			bool resultado=true;
			int	 Accion=Utiles.Transformar_TipoAcceso(this.ParamTipoAcceso);
			int iIdReport=this.ParamIdReport;
			string sIdReport=null;
            string sMensj = String.Empty;


            //			if(this.ParamIdReport==-1)
            //			{
            //				Clases.Configuracion.iUIVisitaCLI++;
            //
            //				iIdReport="999"+Clases.Configuracion.iUIVisitaCLI.ToString().PadLeft(6,'0');
            //				sIdReport = "T"+Clases.Configuracion.iIdDelegado.ToString().PadLeft(4,'0')+Clases.Configuracion.iUIVisitaCLI.ToString().PadLeft(6,'0');
            //			}

            //---- GSG (17/06/2016)
            if (ParamNuevaFecha != DateTime.MinValue)
            {
                Accion = 0; // alta
                iIdReport = -1;
            }



            //---- GSG (10/09/2014)
            //sqlConn.Open();
            if (sqlConn.State == ConnectionState.Closed)
                sqlConn.Open();


			this.sqlTran = this.sqlConn.BeginTransaction();

			this.sqlcmdSetRepActividad_Cab.Transaction = this.sqlTran;
			this.sqlcmdSetRepActividad_Cli.Transaction = this.sqlTran;
			this.sqlcmdSetRepActividad_Gad.Transaction = this.sqlTran;
			this.sqlcmdSetRepActividad_Aten.Transaction = this.sqlTran;
			this.sqlcmdSetRepActividad_Ped.Transaction = this.sqlTran;
			this.sqlcmdSetRepActividad_Prom.Transaction = this.sqlTran;
			this.sqlcmdSetRepActividadCli_ProxObj.Transaction = this.sqlTran;
			this.sqlcomdSetRepActividad_ImporteReal_Aten.Transaction=this.sqlTran;

			try
			{
				string tObjetivo=null;
				string tProxObjetivo=null;
				string tObservaciones=null;

				if(this.txbObjetivo.Text.Replace(" ","").Length!=0) tObjetivo = this.txbObjetivo.Text;
				if(this.txtProxObjetivo.Text.Replace(" ","").Length!=0) tProxObjetivo = this.txtProxObjetivo.Text;
				if(this.txbObservaciones.Text.Replace(" ","").Length!=0) tObservaciones = this.txbObservaciones.Text;

				this.sqlcmdSetRepActividad_Cab.Parameters["@iIdReport"].Value=iIdReport;
				//				this.sqlcmdSetRepActividad_Cab.Parameters["@sIdReportTemp"].Value=sIdReport;
				this.sqlcmdSetRepActividad_Cab.Parameters["@iIdDelegado"].Value=this.ParamiIdDelegado;
				this.sqlcmdSetRepActividad_Cab.Parameters["@sTipoRActividad"].Value=this.cbTipoRActibidad.SelectedValue.ToString();
				this.sqlcmdSetRepActividad_Cab.Parameters["@sIdTipoCliente"].Value=this.cbTipoCliente.SelectedValue.ToString();
				if(this.cbTipoCliente.SelectedValue.ToString()=="C")  this.sqlcmdSetRepActividad_Cab.Parameters["@iIdCentro"].Value = this.Var_iIdCentro;
				//				this.sqlcmdSetRepActividad_Cab.Parameters["@iIdCentro"].Value = this.Var_iIdCentro;
				this.sqlcmdSetRepActividad_Cab.Parameters["@dFecha"].Value = this.dtpFecha.Value.ToString("dd/MM/yyyy");
                //---- GSG (28/04/2017)
				//this.sqlcmdSetRepActividad_Cab.Parameters["@iHorario"].Value = this.cbHorario.SelectedValue.ToString();
                if (this.cbHorario.SelectedValue == null)
                    this.sqlcmdSetRepActividad_Cab.Parameters["@iHorario"].Value = "1";
                else
                    this.sqlcmdSetRepActividad_Cab.Parameters["@iHorario"].Value = this.cbHorario.SelectedValue.ToString();


                this.sqlcmdSetRepActividad_Cab.Parameters["@tObjetivo"].Value = tObjetivo;
				this.sqlcmdSetRepActividad_Cab.Parameters["@tProxObjetivo"].Value = tProxObjetivo;
				this.sqlcmdSetRepActividad_Cab.Parameters["@tObservaciones"].Value = tObservaciones;
				this.sqlcmdSetRepActividad_Cab.Parameters["@bPlanificacion"].Value = this.Var_bPlanificacion;
				this.sqlcmdSetRepActividad_Cab.Parameters["@Accion"].Value=Accion;

                //---- GSG (29/08/2011)
                ////RH
                //this.sqlcmdSetRepActividad_Cab.Parameters["@dHoraInicio"].Value = dtpHoraInicio.Value;
                //this.sqlcmdSetRepActividad_Cab.Parameters["@dHoraFin"].Value = dtpHoraFin.Value;

                if (this.cbTipoCliente.SelectedValue.ToString() == "S")
                {
                    for (int i = 0; i < dtClienteHoraDg.Rows.Count; i++)
                    {
                        DataRow filaDg = this.dtClienteHoraDg.Rows[i];
                        if (int.Parse(filaDg["iIdCliente"].ToString()) == idCliAct)
                        {
                            if (filaDg["hIni"].ToString().Length > 0)
                                this.sqlcmdSetRepActividad_Cab.Parameters["@dHoraInicio"].Value = filaDg["hIni"];
                            else
                                this.sqlcmdSetRepActividad_Cab.Parameters["@dHoraInicio"].Value = dtpHoraInicio.Value;

                            if (filaDg["hFin"].ToString().Length > 0)
                                this.sqlcmdSetRepActividad_Cab.Parameters["@dHoraFin"].Value = filaDg["hFin"];
                            else
                                this.sqlcmdSetRepActividad_Cab.Parameters["@dHoraFin"].Value = dtpHoraFin.Value;
                        }
                    }
                }
                else
                {
                    this.sqlcmdSetRepActividad_Cab.Parameters["@dHoraInicio"].Value = dtpHoraInicio.Value;
                    this.sqlcmdSetRepActividad_Cab.Parameters["@dHoraFin"].Value = dtpHoraFin.Value;
                }               
                //---- FI GSG
				

				this.sqlcmdSetRepActividad_Cab.ExecuteNonQuery();
 				
				if(Accion==0) 
				{
					iIdReport = Int32.Parse(this.sqlcmdSetRepActividad_Cab.Parameters["@iIdReport"].Value.ToString());
					sIdReport = this.sqlcmdSetRepActividad_Cab.Parameters["@sIdReportTemp"].Value.ToString();
				}
				//Borrar RepActividad_Cli, RepActividad_Gad, , RepActividad_Aten
				//RepActividadCli_ProxObj
				//Pone a 0 el Importe Real de todas las Atenciones Comerciales Manuales
				//que tenía asignadas el Report

				this.sqlcmdSetRepActividad_Cli.Parameters["@iIdReport"].Value=iIdReport;
				this.sqlcmdSetRepActividad_Cli.Parameters["@Accion"].Value = 2;
				this.sqlcmdSetRepActividad_Cli.ExecuteNonQuery();


				//Insertar RepActividad_Cli
				string tObjetivoCli=null;
				string tProxObjetivoCli=null;
				string tObservacionesCli=null;

                //---- GSG (29/04/2011) 
                int nBucle = 0;
                //---- GSG (17/10/2011) 
                //if (this.cbTipoCliente.SelectedValue.ToString() == "S")
                //    nBucle = this.dtClientesDg.Rows.Count; 
                //else if (this.Var_bPlanificacion == 0) //no planificació
                //    nBucle = 1;

                //En tots els casos cal guardar la info per a cada client
                //Si SAP segur que nBucle > 0 en cas contrari pot ser-ho o no
                nBucle = this.dtClientesDg.Rows.Count;
                //---- FI GSG


				//for(int i=0;i<this.dtClientesDg.Rows.Count;i++)
                for (int i = 0; i < nBucle; i++)
				{
                    //---- GSG (06/09/2011)
                    DataRow filaDg = this.dtClienteHoraDg.Rows[i];
                    //---- GSG (17/10/2011)
                    //if (int.Parse(filaDg["iIdCliente"].ToString()) == idCliAct)
                    if (int.Parse(filaDg["iIdCliente"].ToString()) == idCliAct || idCliAct == 0)
                    {
                    //---- FI GSG
                        tObjetivoCli = null;
                        tProxObjetivoCli = null;
                        tObservacionesCli = null;

                        if (this.dtClientesDg.Rows[i]["tObjetivos"].ToString().Replace(" ", "").Length != 0) tObjetivoCli = this.dtClientesDg.Rows[i]["tObjetivos"].ToString();
                        if (this.dtClientesDg.Rows[i]["tProxObj"].ToString().Replace(" ", "").Length != 0) tProxObjetivoCli = this.dtClientesDg.Rows[i]["tProxObj"].ToString();
                        if (this.dtClientesDg.Rows[i]["tObservaciones"].ToString().Replace(" ", "").Length != 0) tObservacionesCli = this.dtClientesDg.Rows[i]["tObservaciones"].ToString();

                        this.sqlcmdSetRepActividad_Cli.Parameters["@iIdReport"].Value = iIdReport;
                        //---- GSG (29/07/2011)
                        //this.sqlcmdSetRepActividad_Cli.Parameters["@iIdCliente"].Value=Int32.Parse(this.dtClientesDg.Rows[i]["iIdCliente"].ToString());
                        if (this.cbTipoCliente.SelectedValue.ToString() != "S")
                            this.sqlcmdSetRepActividad_Cli.Parameters["@iIdCliente"].Value = Int32.Parse(this.dtClientesDg.Rows[i]["iIdCliente"].ToString());
                        else
                            this.sqlcmdSetRepActividad_Cli.Parameters["@iIdCliente"].Value = idCliAct;
                        //---- FI GSG
                        this.sqlcmdSetRepActividad_Cli.Parameters["@tObservaciones"].Value = tObservacionesCli;
                        this.sqlcmdSetRepActividad_Cli.Parameters["@tObjetivos"].Value = tObjetivoCli;
                        this.sqlcmdSetRepActividad_Cli.Parameters["@tProxObj"].Value = tProxObjetivoCli;
                        this.sqlcmdSetRepActividad_Cli.Parameters["@bSustituto"].Value = int.Parse(this.dtClientesDg.Rows[i]["bSustituto"].ToString());
                        this.sqlcmdSetRepActividad_Cli.Parameters["@Accion"].Value = 0;
                        sqlcmdSetRepActividad_Cli.Parameters["@sIdRed"].Value = Clases.Configuracion.sIdRed;
                        this.sqlcmdSetRepActividad_Cli.ExecuteNonQuery();

                        // Si no es una Planificacion
                        if (this.Var_bPlanificacion == 0)
                        {
                            //Para cada cliente insertado se borra RepActividadCli_ProxObj
                            this.sqlcmdSetRepActividadCli_ProxObj.Parameters["@iIdCliente"].Value = Int32.Parse(this.dtClientesDg.Rows[i]["iIdCliente"].ToString());
                            if (this.cbTipoCliente.SelectedValue.ToString() == "C") this.sqlcmdSetRepActividadCli_ProxObj.Parameters["@iIdCentro"].Value = this.Var_iIdCentro;
                            else this.sqlcmdSetRepActividadCli_ProxObj.Parameters["@iIdCentro"].Value = -1;
                            this.sqlcmdSetRepActividadCli_ProxObj.Parameters["@Accion"].Value = 2;

                            this.sqlcmdSetRepActividadCli_ProxObj.ExecuteNonQuery();

                            //Para cada cliente insertado se inserta en RepActividadCli_ProxObj si el campo
                            // Próximos objetivos está informado 
                            if (this.dtClientesDg.Rows[i]["tProxObj"].ToString().Replace(" ", "").Length > 0)
                            {
                                this.sqlcmdSetRepActividadCli_ProxObj.Parameters["@iIdReport"].Value = iIdReport;

                                //---- GSG (29/07/2011)
                                //this.sqlcmdSetRepActividadCli_ProxObj.Parameters["@iIdCliente"].Value=Int32.Parse(this.dtClientesDg.Rows[i]["iIdCliente"].ToString());
                                if (this.cbTipoCliente.SelectedValue.ToString() != "S")
                                    this.sqlcmdSetRepActividadCli_ProxObj.Parameters["@iIdCliente"].Value = Int32.Parse(this.dtClientesDg.Rows[i]["iIdCliente"].ToString());
                                else
                                    this.sqlcmdSetRepActividadCli_ProxObj.Parameters["@iIdCliente"].Value = idCliAct;
                                //---- FI GSG
                                if (this.cbTipoCliente.SelectedValue.ToString() == "C") this.sqlcmdSetRepActividadCli_ProxObj.Parameters["@iIdCentro"].Value = this.Var_iIdCentro;
                                else this.sqlcmdSetRepActividadCli_ProxObj.Parameters["@iIdCentro"].Value = -1;
                                this.sqlcmdSetRepActividadCli_ProxObj.Parameters["@dFecha"].Value = this.dtpFecha.Value.Date.ToString("dd/MM/yyyy");
                                this.sqlcmdSetRepActividadCli_ProxObj.Parameters["@tProxObj"].Value = this.dtClientesDg.Rows[i]["tProxObj"].ToString();
                                this.sqlcmdSetRepActividadCli_ProxObj.Parameters["@Accion"].Value = 0;

                                this.sqlcmdSetRepActividadCli_ProxObj.ExecuteNonQuery();
                            }
                        }
                    }
				}

				//Grabar Gadgets
				for(int i=0;i<this.dtGadgetsRep.Rows.Count;i++)
				{
                    //---- GSG (29/08/2011)
                    //---- GSG (17/10/2011)
                    //if (idCliAct == Int32.Parse(this.dtGadgetsRep.Rows[i]["iIdCliente"].ToString()))
                    if (idCliAct == Int32.Parse(this.dtGadgetsRep.Rows[i]["iIdCliente"].ToString()) || idCliAct == 0)
                    {
                    //---- FI GSG
                        this.sqlcmdSetRepActividad_Gad.Parameters["@iIdReport"].Value = iIdReport;

                        this.sqlcmdSetRepActividad_Gad.Parameters["@iIdCliente"].Value=Int32.Parse(this.dtGadgetsRep.Rows[i]["iIdCliente"].ToString());
                        
                        this.sqlcmdSetRepActividad_Gad.Parameters["@iIdGadget"].Value = Int32.Parse(this.dtGadgetsRep.Rows[i]["iIdGadget"].ToString());
                        this.sqlcmdSetRepActividad_Gad.Parameters["@iCantidad"].Value = int.Parse(this.dtGadgetsRep.Rows[i]["iCantidad"].ToString());
                        this.sqlcmdSetRepActividad_Gad.Parameters["@Accion"].Value = 0;

                        this.sqlcmdSetRepActividad_Gad.ExecuteNonQuery();
                    }
				}

				//Grabar Atenciones
				for(int j=0;j<this.dtAtencionesRep.Rows.Count;j++)
				{
                    //---- GSG (29/08/2011)
                    //---- GSG (17/10/2011)
                    //if (idCliAct == Int32.Parse(this.dtAtencionesRep.Rows[j]["iIdCliente"].ToString()))
                    if (idCliAct == Int32.Parse(this.dtAtencionesRep.Rows[j]["iIdCliente"].ToString()) || idCliAct == 0)
                    {
                    //---- FI GSG
                        this.sqlcmdSetRepActividad_Aten.Parameters["@iIdReport"].Value = iIdReport;

                        this.sqlcmdSetRepActividad_Aten.Parameters["@iIdCliente"].Value = Int32.Parse(this.dtAtencionesRep.Rows[j]["iIdCliente"].ToString());

                        this.sqlcmdSetRepActividad_Aten.Parameters["@iIdAtencion"].Value = Int32.Parse(this.dtAtencionesRep.Rows[j]["iIdAtencion"].ToString());
                        this.sqlcmdSetRepActividad_Aten.Parameters["@iNumAtencion"].Value = Int32.Parse(this.dtAtencionesRep.Rows[j]["iNumAtencion"].ToString());
                        this.sqlcmdSetRepActividad_Aten.Parameters["@fImporte"].Value = float.Parse(this.dtAtencionesRep.Rows[j]["fImporte"].ToString());
                        this.sqlcmdSetRepActividad_Aten.Parameters["@Accion"].Value = 0;

                        this.sqlcmdSetRepActividad_Aten.ExecuteNonQuery();
                    }
				}

				#region antiguo
				//				string iIdCliente="";
				//				string iIdAtencion = "";
				//				string iNumAtencion = "";
				//				int fila = -1;
				//				for(int j=0;j<this.dsReports1.ListaRepActividAtenciones.Rows.Count;j++)
				//				{
				//					iIdCliente = this.dsReports1.ListaRepActividAtenciones.Rows[j]["iIdCliente"].ToString();
				//					iIdAtencion = this.dsReports1.ListaRepActividAtenciones.Rows[j]["iIdAtencion"].ToString();
				//					iNumAtencion = this.dsReports1.ListaRepActividAtenciones.Rows[j]["iNumAtencion"].ToString();
				//
				//					fila = Utiles.Buscar_fila_dtTabla(this.dtAtencionesRep,"iIdCliente",iIdCliente,"iIdAtencion",iIdAtencion,"iNumAtencion",iNumAtencion);
				//					
				//					if(fila==-1) Accion = 2;
				//					else Accion=1;
				//					
				//					this.sqlcmdSetRepActividad_Aten.Parameters["@iIdReport"].Value=iIdReport;
				//					this.sqlcmdSetRepActividad_Aten.Parameters["@iIdCliente"].Value=iIdCliente;
				//					this.sqlcmdSetRepActividad_Aten.Parameters["@iIdAtencion"].Value=iIdAtencion;
				//					this.sqlcmdSetRepActividad_Aten.Parameters["@iNumAtencion"].Value=iNumAtencion;
				//					if(Accion==1) this.sqlcmdSetRepActividad_Aten.Parameters["@fImporte"].Value=float.Parse(this.dtAtencionesRep.Rows[fila]["fImporte"].ToString());
				//					this.sqlcmdSetRepActividad_Aten.Parameters["@Accion"].Value=Accion;
				//
				//					this.sqlcmdSetRepActividad_Aten.ExecuteNonQuery();
				//				}

				//				for(int j=0;j<this.dtAtencionesRep.Rows.Count;j++)
				//				{
				//					iIdCliente = this.dtAtencionesRep.Rows[j]["iIdCliente"].ToString();
				//					iIdAtencion = this.dtAtencionesRep.Rows[j]["iIdAtencion"].ToString();
				//					iNumAtencion = this.dtAtencionesRep.Rows[j]["iNumAtencion"].ToString();
				//
				//					fila = Utiles.Buscar_fila_dtTabla(this.dsReports1.ListaRepActividAtenciones,"iIdCliente",iIdCliente,"iIdAtencion",iIdAtencion,"iNumAtencion",iNumAtencion);
				//					
				//					if(fila==-1) Accion = 0;
				//					else Accion = 1;
				//					
				//					if(Accion == 0)
				//					{
				//						this.sqlcmdSetRepActividad_Aten.Parameters["@iIdReport"].Value=iIdReport;
				//						this.sqlcmdSetRepActividad_Aten.Parameters["@iIdCliente"].Value=iIdCliente;
				//						this.sqlcmdSetRepActividad_Aten.Parameters["@iIdAtencion"].Value=iIdAtencion;
				//						this.sqlcmdSetRepActividad_Aten.Parameters["@iNumAtencion"].Value=iNumAtencion;
				//						this.sqlcmdSetRepActividad_Aten.Parameters["@fImporte"].Value=float.Parse(this.dtAtencionesRep.Rows[j]["fImporte"].ToString());
				//						this.sqlcmdSetRepActividad_Aten.Parameters["@Accion"].Value=Accion;
				//
				//						this.sqlcmdSetRepActividad_Aten.ExecuteNonQuery();
				//					}
				//				}
				#endregion

				//Actualizar Importe Real de las Atenciones Asignadas
				DataTable dtAten = new DataTable();
				dtAten.Columns.Add("iIdAtencion");
				dtAten.Columns.Add("fImporteReal");
				dtAten.Columns.Add("dFecha");
				int fila=-1;
				string iIdAtencion =" -1";
				float Importe=0;
				string fecha = this.dtpFecha.Value.ToString("dd/MM/yyyy");
				string sIdTipoAtencion="";
				for(int i=0;i<this.dtAtencionesRep.Rows.Count;i++)
				{
					sIdTipoAtencion = this.dtAtencionesRep.Rows[i]["sIdTipoAtencion"].ToString();
					if(sIdTipoAtencion=="2") //Atención Manual
					{
						iIdAtencion = this.dtAtencionesRep.Rows[i]["iIdAtencion"].ToString();
						Importe = float.Parse(this.dtAtencionesRep.Rows[i]["fImporte"].ToString());
						fila = Utiles.Buscar_fila_dtTabla(dtAten,"iIdAtencion",iIdAtencion);
						if(fila==-1)
						{
							DataRow dtAtenfila = dtAten.NewRow();
							dtAtenfila["iIdAtencion"]=iIdAtencion;
							dtAtenfila["fImporteReal"]=Importe;
							dtAtenfila["dFecha"]=fecha;
							dtAten.Rows.Add(dtAtenfila);
						}
						else
						{
							dtAten.Rows[fila]["fImporteReal"] = float.Parse(dtAten.Rows[fila]["fImporteReal"].ToString())+Importe;
						}
					}
				}

				for(int i=0;i<dtAten.Rows.Count;i++)
				{
					this.sqlcomdSetRepActividad_ImporteReal_Aten.Parameters["@iIdAtencion"].Value=Int32.Parse(dtAten.Rows[i]["iIdAtencion"].ToString());
					this.sqlcomdSetRepActividad_ImporteReal_Aten.Parameters["@fImporteReal"].Value=float.Parse(dtAten.Rows[i]["fImporteReal"].ToString());
					this.sqlcomdSetRepActividad_ImporteReal_Aten.Parameters["@dFechaCierre"].Value=dtAten.Rows[i]["dFecha"].ToString();

					this.sqlcomdSetRepActividad_ImporteReal_Aten.ExecuteNonQuery();
				}


				//Borrar Pedidos
				this.sqlcmdSetRepActividad_Ped.Parameters["@iIdReport"].Value=iIdReport;
				this.sqlcmdSetRepActividad_Ped.Parameters["@Accion"].Value=2;

				this.sqlcmdSetRepActividad_Ped.ExecuteNonQuery();


				//Grabar Pedidos
				//---- GSG (13/10/2011)
                //for(int i=0;i<this.dtPedidosDg.Rows.Count;i++)
                //{
                //    this.sqlcmdSetRepActividad_Ped.Parameters["@iIdReport"].Value=iIdReport;
                //    this.sqlcmdSetRepActividad_Ped.Parameters["@sIdPedido"].Value=this.dtPedidosDg.Rows[i]["sIdPedido"].ToString();
                //    this.sqlcmdSetRepActividad_Ped.Parameters["@Accion"].Value=0;

                //    this.sqlcmdSetRepActividad_Ped.ExecuteNonQuery();
                //}

                for (int i = 0; i < this.dtPedidosRep.Rows.Count; i++)
                {
                    if (idCliAct == int.Parse(this.dtPedidosRep.Rows[i]["iIdCliente"].ToString()))
                    {
                        this.sqlcmdSetRepActividad_Ped.Parameters["@iIdReport"].Value = iIdReport;
                        this.sqlcmdSetRepActividad_Ped.Parameters["@sIdPedido"].Value = this.dtPedidosRep.Rows[i]["sIdPedido"].ToString();
                        this.sqlcmdSetRepActividad_Ped.Parameters["@Accion"].Value = 0;

                        this.sqlcmdSetRepActividad_Ped.ExecuteNonQuery();
                    }
                }

                //---- FI GSG
				
				//Borrar Productos
				this.sqlcmdSetRepActividad_Prom.Parameters["@iIdReport"].Value=iIdReport;
				this.sqlcmdSetRepActividad_Prom.Parameters["@Accion"].Value=2;
				this.sqlcmdSetRepActividad_Prom.ExecuteNonQuery();

				//Grabar Productos
                //---- GSG (23/02/2015)
				//foreach(DataRow oRow in dsReports1.ListaPromocionProd.Rows)
                //{
                //    //---- GSG (29/08/2011)
                //    //---- GSG (17/10/2011)
                //    //if (idCliAct == Int32.Parse(oRow["iIdCliente"].ToString()))
                //    if (idCliAct == Int32.Parse(oRow["iIdCliente"].ToString()) || idCliAct == 0)
                //    {
                //        //---- FI GSG

                //        this.sqlcmdSetRepActividad_Prom.Parameters["@iIdReport"].Value = iIdReport;

                //        this.sqlcmdSetRepActividad_Prom.Parameters["@iIdCliente"].Value = oRow["iIdCliente"].ToString();

                //        this.sqlcmdSetRepActividad_Prom.Parameters["@sIdProducto"].Value = oRow["sIdProducto"].ToString();
                //        this.sqlcmdSetRepActividad_Prom.Parameters["@iOrden"].Value = oRow["Orden"].ToString();
                //        this.sqlcmdSetRepActividad_Prom.Parameters["@iCantidad"].Value = oRow["iCantidad"].ToString();
                //        this.sqlcmdSetRepActividad_Prom.Parameters["@Accion"].Value = 0;

                //        this.sqlcmdSetRepActividad_Prom.ExecuteNonQuery();
                //    }
                //}
                for (int i = 0; i < dtProductosRep.Rows.Count; i++)
                {
                    if (dtProductosRep.Rows[i]["iIdCliente"].ToString() == idCliAct.ToString())
                    {
                        this.sqlcmdSetRepActividad_Prom.Parameters["@iIdReport"].Value = iIdReport;

                        this.sqlcmdSetRepActividad_Prom.Parameters["@iIdCliente"].Value = idCliAct;

                        this.sqlcmdSetRepActividad_Prom.Parameters["@sIdProducto"].Value = dtProductosRep.Rows[i]["sIdProducto"].ToString();
                        this.sqlcmdSetRepActividad_Prom.Parameters["@iOrden"].Value = int.Parse(dtProductosRep.Rows[i]["Orden"].ToString());
                        this.sqlcmdSetRepActividad_Prom.Parameters["@iCantidad"].Value = int.Parse(dtProductosRep.Rows[i]["iCantidad"].ToString());
                        this.sqlcmdSetRepActividad_Prom.Parameters["@Accion"].Value = 0;

                        this.sqlcmdSetRepActividad_Prom.ExecuteNonQuery();
                    }
                }
//				for(int i=0;i<this.dtProductosDg.Rows.Count;i++)
//				{
//					this.sqlcmdSetRepActividad_Prod.Parameters["@iIdReport"].Value=iIdReport;
//					this.sqlcmdSetRepActividad_Prod.Parameters["@sIdProducto"].Value=this.dtProductosDg.Rows[i]["sIdProducto"].ToString();
//					try{this.sqlcmdSetRepActividad_Prod.Parameters["@iIdPromocion"].Value=Int32.Parse(this.dtProductosDg.Rows[i]["iIdPromocion"].ToString());}
//					catch{this.sqlcmdSetRepActividad_Prod.Parameters["@iIdPromocion"].Value=null;}
//					this.sqlcmdSetRepActividad_Prod.Parameters["@bPromocionado"].Value=int.Parse(this.dtProductosDg.Rows[i]["bPromociona"].ToString());
//					this.sqlcmdSetRepActividad_Prod.Parameters["@iOrden"].Value=int.Parse(this.dtProductosDg.Rows[i]["iOrden"].ToString());
//					this.sqlcmdSetRepActividad_Prod.Parameters["@iMuestras"].Value=int.Parse(this.dtProductosDg.Rows[i]["iMuestras"].ToString());
//					this.sqlcmdSetRepActividad_Prod.Parameters["@Accion"].Value=0;
//
//					this.sqlcmdSetRepActividad_Prod.ExecuteNonQuery();
//				}

				//Grabar en el fichero de Configuración
				if(this.ParamIdReport==-1)
				{
					//					Clases.Configuracion.GrabaValor(102,iIdReport);
					this.ParamIdReport=iIdReport;
				}

				this.sqlTran.Commit();
				resultado=true;
			}
			catch(System.Data.SqlClient.SqlException ex)
			{
				sMensj ="Error al actualizar Report de Actividad: ";
				foreach(System.Data.SqlClient.SqlError Err in ex.Errors)
				{
					if (Err.Number == 2627)
					{
						sMensj += "Código ya existente";
						break;
					}
					if (Err.Number != 3621)
					{
						sMensj +=Err.Number.ToString()+" - "+Err.Message.ToString();
					}
				}

				if(this.ParamIdReport==-1)
				{
					GESTCRM.Clases.Configuracion.iGVisitas--;
				}
				Mensajes.ShowError(sMensj);
				this.sqlTran.Rollback();
				resultado=false;
			}
			catch(Exception e)
			{
				Mensajes.ShowError(e.Message);
				this.sqlTran.Rollback();
				resultado=false;
			}


			this.sqlConn.Close();
			return resultado;
		}

		#endregion

		#region Columna_Boton
		private void Columna_Boton(DataGrid dg,int col)
		{
			try
			{
				int columna = dg.TableStyles[0].GridColumnStyles.Count;

				DataGridTableStyle tableStyle = new DataGridTableStyle();
				tableStyle.MappingName = dg.TableStyles[0].MappingName;
				tableStyle.AlternatingBackColor= dg.TableStyles[0].AlternatingBackColor;
				tableStyle.BackColor= dg.TableStyles[0].BackColor;
				tableStyle.HeaderBackColor= dg.TableStyles[0].HeaderBackColor;
				tableStyle.RowHeaderWidth= dg.TableStyles[0].RowHeaderWidth;
				tableStyle.SelectionBackColor= dg.TableStyles[0].SelectionBackColor;
				tableStyle.SelectionForeColor=dg.TableStyles[0].SelectionForeColor;
				tableStyle.ReadOnly = dg.TableStyles[0].ReadOnly;


				for(int i=0;i<dg.TableStyles[0].GridColumnStyles.Count;i++)
				{
					if(i==col)
					{
						GESTCRM.DataGridButtonColumn buttonColStyle = new GESTCRM.DataGridButtonColumn(i); //pass the column#
						buttonColStyle.HeaderText = "";
						buttonColStyle.MappingName =  dg.TableStyles[0].GridColumnStyles[i].MappingName;
						buttonColStyle.Width=40;
						buttonColStyle.TextBox.ContextMenu=null;
						//hookup our cellbutton handler...
						if(col==8) //Clientes
						{
							buttonColStyle.CellButtonClicked += 
								new DataGridCellButtonClickEventHandler(HandleCellbtVerClienteClick);
						}
						else //Pedidos
						{
							buttonColStyle.CellButtonClicked += 
								new DataGridCellButtonClickEventHandler(HandleCellbtVerPedidoClick);
						}

						tableStyle.GridColumnStyles.Add(buttonColStyle);

						//hook the mouse handlers
						dg.MouseDown += new MouseEventHandler(buttonColStyle.HandleMouseDown);
						dg.MouseUp += new MouseEventHandler(buttonColStyle.HandleMouseUp);
					}
					else
					{
						// add standard textbox columns for the other columns
						DataGridTextBoxColumn aColumnTextColumn = new DataGridTextBoxColumn();
						aColumnTextColumn.HeaderText = dg.TableStyles[0].GridColumnStyles[i].HeaderText;
						aColumnTextColumn.MappingName = dg.TableStyles[0].GridColumnStyles[i].MappingName;
						aColumnTextColumn.Width  = dg.TableStyles[0].GridColumnStyles[i].Width;
						aColumnTextColumn.NullText = dg.TableStyles[0].GridColumnStyles[i].NullText;
						aColumnTextColumn.ReadOnly = dg.TableStyles[0].GridColumnStyles[i].ReadOnly;
						tableStyle.GridColumnStyles.Add(aColumnTextColumn);
					}
				}

				dg.TableStyles.Clear();
				dg.TableStyles.Add(tableStyle);
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		// handler for a click on one of the gridcell buttons
		#region HandleCellbtVerClienteClick
		private void HandleCellbtVerClienteClick(object sender, DataGridCellButtonClickEventArgs e)
		{
//			GESTCRM.Formularios.Mantenimientos.frmMAccMarketing frmBAten = new GESTCRM.Formularios.Mantenimientos.frmMAccMarketing();
//			frmBAten.ShowDialog(this);

			Mostrar_FormularioCliente(e.RowIndex);

			//MessageBox.Show("row " + e.RowIndex.Message + "  col " + e.ColIndex.Message + " clicked.");
		}
		#endregion

		// handler for a click on one of the gridcell buttons
		#region HandleCellbtVerPedidoClick
		private void HandleCellbtVerPedidoClick(object sender, DataGridCellButtonClickEventArgs e)
		{
			VerPedido(e.RowIndex);
		}
		#endregion

		private void cbTipoRActibidad_Leave(object sender, System.EventArgs e)
		{
			if(this.cbTipoRActibidad.SelectedIndex==-1) this.cbTipoRActibidad.SelectedValue="1";//Tipo Report = Visita
		}

		private void cbTipoCliente_Leave(object sender, System.EventArgs e)
		{
			if(this.cbTipoCliente.SelectedIndex==-1) this.cbTipoCliente.SelectedValue="C";	//Tipo Cliente = ClienteCOM
		}

		private void cbHorario_Leave(object sender, System.EventArgs e)
		{
			if(this.cbHorario.SelectedIndex==-1) this.cbHorario.SelectedValue="0";		//Horario = Mañana
		}

        private void txbHoraInicio_Enter(object sender, EventArgs e)
        {
            if (dtpHoraInicio.Enabled == false)
                return;

            if (txbHoraInicio.Text.Length == 0)
            {
                dtpHoraInicio.Value = DateTime.Now;
                if (dtpHoraInicio.Value > dtpHoraFin.Value)
                    dtpHoraInicio.Value = dtpHoraFin.Value;
                txbHoraInicio.Text = dtpHoraInicio.Value.ToShortTimeString();
            }
            //else
            //    dtpHoraInicio.Value = DateTime.Parse(txbHoraInicio.Text);

            //---- GSG (30/08/2011)
            //dtpHoraInicio.MaxDate = dtpHoraFin.Value.AddSeconds(1);
            if (this.cbTipoCliente.SelectedValue.ToString() != "S")
            {
                dtpHoraInicio.MaxDate = dtpHoraFin.Value.AddSeconds(1);
            }
            //---- FI GSG

            dtpHoraInicio.Visible = true;
            dtpHoraInicio.BringToFront();
            dtpHoraInicio.Focus();
        }

        private void dtpHoraInicio_Leave(object sender, EventArgs e)
        {
            if ((dtpHoraInicio.Focused == false) && (txbHoraInicio.Focused == false))
            {
                dtpHoraInicio.Visible = false;
                txbHoraInicio.Text = dtpHoraInicio.Value.ToShortTimeString();
                txbHoraInicio.Visible = true;

                //---- GSG (30/08/2011)
                if (this.cbTipoCliente.SelectedValue.ToString() == "S")
                {
                    Actualiza_ClienteHora();
                }
                //---- FI GSG
            }
        }

        private void dtpHoraInicio_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyValue == 9)
            {
                dtpHoraInicio.Visible = false;
                txbHoraInicio.Text = dtpHoraInicio.Value.ToShortTimeString();
                txbHoraInicio.Visible = true;
                txtsDelegado.Focus();
            }
        }

        private void txbHoraFin_Enter(object sender, EventArgs e)
        {
            if (dtpHoraFin.Enabled == false)
                return;

            if (txbHoraFin.Text.Length == 0)
            {
                dtpHoraFin.Value = DateTime.Now;

                if (dtpHoraFin.Value < dtpHoraInicio.Value)
                    dtpHoraFin.Value = dtpHoraInicio.Value;
               
                txbHoraFin.Text = dtpHoraFin.Value.ToShortTimeString();
            }
            //else
            //    dtpHoraFin.Value = DateTime.Parse(txbHoraFin.Text);

            
            //---- GSG (30/08/2011)
            if (this.cbTipoCliente.SelectedValue.ToString() != "S")
            {
                dtpHoraFin.MinDate = dtpHoraInicio.Value.Subtract(new TimeSpan(0, 0, 1));
            }
            //---- FI GSG

            dtpHoraFin.Visible = true;
            dtpHoraFin.BringToFront();
            dtpHoraFin.Focus();
        }

        private void dtpHoraFin_Leave(object sender, EventArgs e)
        {
            if ((dtpHoraFin.Focused == false) && (txbHoraFin.Focused == false))
            {
                dtpHoraFin.Visible = false;
                txbHoraFin.Text = dtpHoraFin.Value.ToShortTimeString();
                txbHoraFin.Visible = true;

                //---- GSG (30/08/2011)
                if (this.cbTipoCliente.SelectedValue.ToString() == "S")
                {
                    Actualiza_ClienteHora();
                }
                //---- FI GSG
            }
        }

        private void dtpHoraFin_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyValue == 9)
            {
                dtpHoraFin.Visible = false;
                txbHoraFin.Text = dtpHoraFin.Value.ToShortTimeString();
                txbHoraFin.Visible = true;
                txtsDelegado.Focus();
            }
        }

        //---- GSG (30/08/2011) 
        private void PosarHoraClient(int idClient)
        {
            for(int i=0; i<dtClienteHoraDg.Rows.Count; i++)
			{
                DataRow filaDg = this.dtClienteHoraDg.Rows[i];
                if (int.Parse(filaDg["iIdCliente"].ToString()) == idClient)
                {
                    this.txbHoraInicio.Text = filaDg["hIni"].ToString();
                    this.txbHoraFin.Text = filaDg["hFin"].ToString();
                }
            }
        }

        private void Cargar_dgClienteHora(int idClient)
        {
            try
            {
                
                DataRow filaDg = this.dtClienteHoraDg.NewRow();
                filaDg["iIdCliente"] = idClient;
                filaDg["hIni"] = this.txbHoraInicio.Text;
                filaDg["hFin"] = this.txbHoraFin.Text;

                this.dtClienteHoraDg.Rows.Add(filaDg);
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }

        private void Actualiza_ClienteHora()
        {
            try
            {
                if (this.dgClientes.CurrentRowIndex > -1)
                {
                    string sIdCliente = this.dgClientes[this.dgClientes.CurrentRowIndex, 0].ToString();
                    int iIdCliente = Int32.Parse(this.dgClientes[this.dgClientes.CurrentRowIndex, 2].ToString());

                    for (int i = 0; i < dtClienteHoraDg.Rows.Count; i++)
                    {
                        DataRow filaDg = this.dtClienteHoraDg.Rows[i];
                        if (int.Parse(filaDg["iIdCliente"].ToString()) == iIdCliente)
                        {
                            filaDg["hIni"] = this.txbHoraInicio.Text;
                            filaDg["hFin"] = this.txbHoraFin.Text;
                        }
                    }
                }
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }

        private StringBuilder Validar_Fechas()
        {            
            StringBuilder ErrorMessage = new StringBuilder();
            char dot = (char)0x25CF;
            string hI, hF;
            string hI_Prima, hF_Prima;

            try
            {
                for (int i = 0; i < dtClienteHoraDg.Rows.Count; i++)
                {
                    DataRow filaDg = this.dtClienteHoraDg.Rows[i];

                    hI = filaDg["hIni"].ToString();
                    hF = filaDg["hFin"].ToString();

                    //Cal posar les hores d'inici i fi
                    if (hI.Length == 0)
                    {
                        ErrorMessage.AppendFormat("{0} Debe introducir la hora de inicio para cada cliente.", dot);
                    }
                    //---- GSG (23/03/2012)
                    else
                    {
                        int pos = hI.IndexOf(':');
                        int val = int.Parse(hI.Substring(0, pos)) * 60 + int.Parse(hI.Substring(pos+1, hI.Length - pos - 1));
                        if (val < K_MIN_HOUR)
                            ErrorMessage.AppendFormat("{0} La hora de inicio debe ser posterior o igual a las 7:00\n\r", dot);
                    }

                    if (hF.Length == 0)
                    {
                        if (ErrorMessage.Length > 0)
                            ErrorMessage.Append("\n");
                        ErrorMessage.AppendFormat("{0} Debe introducir la hora de de finalización para cada cliente.", dot);
                    }
                    //---- GSG (23/03/2012)
                    else
                    {
                        int pos = hF.IndexOf(':');
                        int val = int.Parse(hF.Substring(0, pos)) * 60 + int.Parse(hF.Substring(pos + 1, hF.Length - pos - 1));
                        if (val > K_MAX_HOUR)
                            ErrorMessage.AppendFormat("{0} La hora de finalización debe ser anterior o igual a las 20:30", dot);
                    }


                    //L'hora inicial ha de ser menor que la final
                    if (hI.Length > 0 && hF.Length > 0)
                    {
                        if (DateTime.Parse(hI).CompareTo(DateTime.Parse(hF)) >= 0)
                        {
                            if (ErrorMessage.Length > 0)
                                ErrorMessage.Append("\n");
                            ErrorMessage.AppendFormat("{0} La hora de inicio debe ser menor que la hora fin.", dot);
                        }
                    }

                    //Mira si hi ha solapaments
                    for (int j = 0; j < dtClienteHoraDg.Rows.Count; j++)
                    {
                        if (j != i)
                        {
                            DataRow filaDg_Prima = this.dtClienteHoraDg.Rows[j];

                            hI_Prima = filaDg_Prima["hIni"].ToString();
                            hF_Prima = filaDg_Prima["hFin"].ToString();

                            //Casos de solapament
                            //if ((hI_Prima > hI && hF_Prima < hF) || 
                            //     ( hI_Prima < hI && hF_Prima > hI && hF_Prima < hF ) || 
                            //     ( hF_Prima > hF && hI_Prima > hI && hI_Prima < hF ) || 
                            //     ( hI_Prima < hI && hF_Prima > hF ) )       
                            if (hI_Prima.Length > 0 && hF_Prima.Length > 0)
                            {
                                if ((DateTime.Parse(hI_Prima).CompareTo(DateTime.Parse(hI)) >= 0 && DateTime.Parse(hF_Prima).CompareTo(DateTime.Parse(hF)) <= 0) ||
                                     (DateTime.Parse(hI_Prima).CompareTo(DateTime.Parse(hI)) <= 0 && DateTime.Parse(hF_Prima).CompareTo(DateTime.Parse(hI)) >= 0 && DateTime.Parse(hF_Prima).CompareTo(DateTime.Parse(hF)) <= 0) ||
                                     (DateTime.Parse(hF_Prima).CompareTo(DateTime.Parse(hF)) >= 0 && DateTime.Parse(hI_Prima).CompareTo(DateTime.Parse(hI)) <= 0 && DateTime.Parse(hI_Prima).CompareTo(DateTime.Parse(hF)) <= 0) ||
                                     (DateTime.Parse(hI_Prima).CompareTo(DateTime.Parse(hI)) <= 0 && DateTime.Parse(hF_Prima).CompareTo(DateTime.Parse(hF)) >= 0))
                                {
                                    if (ErrorMessage.Length > 0)
                                        ErrorMessage.Append("\n");
                                    ErrorMessage.AppendFormat("{0} Hay horas de visita que se solapan.", dot);
                                }
                            }
                        }

                        //Si un està malament no continua
                        if (ErrorMessage.Length > 0)
                        {
                            return ErrorMessage;
                        }
                    }

                    //Si un està malament no continua
                    if (ErrorMessage.Length > 0)
                    {
                        return ErrorMessage;
                    }
                }               
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }

            return ErrorMessage;
        }


        //---- GSG (10/05/2012) 
        private StringBuilder Validar_Hora()
        {
            StringBuilder ErrorMessage = new StringBuilder();
            char dot = (char)0x25CF;
            string hI, hF;

            try
            {
                hI = txbHoraInicio.Text;
                hF = txbHoraFin.Text;

                int pos = hI.IndexOf(':');
                //---- GSG (15/05/2012)
                //int valI = int.Parse(hI.Substring(0, pos)) * 60 + int.Parse(hI.Substring(pos + 1, hI.Length - pos - 1));
                int valI = 0;
                if (hI != "")
                    valI = int.Parse(hI.Substring(0, pos)) * 60 + int.Parse(hI.Substring(pos + 1, hI.Length - pos - 1));

                pos = hF.IndexOf(':');
                //---- GSG (15/05/2012)
                //int valF = int.Parse(hF.Substring(0, pos)) * 60 + int.Parse(hF.Substring(pos + 1, hF.Length - pos - 1));
                int valF = 10000;
                if (hF != "")
                    valF = int.Parse(hF.Substring(0, pos)) * 60 + int.Parse(hF.Substring(pos + 1, hF.Length - pos - 1));

                if (hI.Length == 0 || hF.Length == 0 || valI < K_MIN_HOUR || valF > K_MAX_HOUR)
                {
                    ErrorMessage.AppendFormat("{0} La hora de inicio debe ser posterior o igual a las 7:00 y la hora fin anterior a las 20:30", dot);
                }

            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }

            return ErrorMessage;
        }


        //---- GSG (26/02/2015)
        private void btAceptarProdsPromo_Click(object sender, EventArgs e)
        {
            Actualiza_ProdsProm();
        }

        private void Actualiza_ProdsProm()
        {
            try
            {
                string sIdCliente = this.dgClientes[this.dgClientes.CurrentRowIndex, 0].ToString();
                int iIdCliente = Int32.Parse(this.dgClientes[this.dgClientes.CurrentRowIndex, 2].ToString());
                string sIdProducto = "";
                

                for (int i = 0; i < dGVProductosPromo.Rows.Count; i++)
                {
                    sIdProducto = dGVProductosPromo.Rows[i].Cells["sIdProducto"].Value.ToString();
                    int fila = Utiles.Buscar_fila_dtTabla(this.dtProductosRep, "iIdReport", this.ParamIdReport.ToString(), "iIdCliente", iIdCliente.ToString(), "sIdProducto", sIdProducto);
                    bool bFilaSel = false;
                    if (dGVProductosPromo.Rows[i].Cells["selected"].Value != null) 
                        bFilaSel = bool.Parse(dGVProductosPromo.Rows[i].Cells["selected"].Value.ToString());

                    if (fila == -1 && bFilaSel) //alta 
                    {
                        DataRow filaRep = this.dtProductosRep.NewRow();

                        filaRep["iIdReport"] = this.ParamIdReport; 
                        filaRep["iIdCliente"] = iIdCliente;
                        filaRep["sIdProducto"] = sIdProducto;
                        filaRep["iCantidad"] = int.Parse(dGVProductosPromo.Rows[i].Cells["iCantidad"].Value.ToString());
                        filaRep["Orden"] = int.Parse(dGVProductosPromo.Rows[i].Cells["Orden"].Value.ToString()); ;

                        this.dtProductosRep.Rows.Add(filaRep);
                    }
                    else if (fila != -1 && bFilaSel) //modificación
                    {
                        this.dtProductosRep.Rows[fila]["iCantidad"] = int.Parse(dGVProductosPromo.Rows[i].Cells["iCantidad"].Value.ToString());
                    }
                    else if (fila != -1 && !bFilaSel) //borrar
                    {
                        this.dtProductosRep.Rows.RemoveAt(fila);
                    }
                }

                lblActProdProm.Visible = false;

            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }

        //private void frmReporting_Paint(object sender, PaintEventArgs e)
        //{
        //    //--- GSG (13/01/2017)
        //    //for (int j = 0; j < dGVProductosPromo.Rows.Count; j++)
        //    //{
        //    //    if (bool.Parse(dGVProductosPromo.Rows[j].Cells["bSelected"].Value.ToString()))
        //    //        dGVProductosPromo.Rows[j].Cells["selected"].Value = true;
        //    //    else
        //    //        dGVProductosPromo.Rows[j].Cells["selected"].Value = false;
        //    //}
        //}

        private void dGVProductosPromo_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dGVProductosPromo_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            lblActProdProm.Visible = true;
        }



        //---- GSG (13/01/2017)
        private void dGVProductosPromo_MouseUp(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hti = dGVProductosPromo.HitTest(e.X, e.Y);

            if (hti.RowIndex < 0) //Se hizo click en la cabecera
                return;

            if (hti.ColumnIndex == 0)
            {
                if (dGVProductosPromo.Rows[hti.RowIndex].Cells["selected"].Value != null && bool.Parse(dGVProductosPromo.Rows[hti.RowIndex].Cells["selected"].Value.ToString())) // checked --> uncheked
                {
                    dGVProductosPromo.Rows[hti.RowIndex].Cells["selected"].Value = false;
                    dGVProductosPromo.Rows[hti.RowIndex].Cells["bSelected"].Value = false;
                    this.dGVProductosPromo.RefreshEdit();
                    this.dGVProductosPromo.NotifyCurrentCellDirty(true);
                }
                else
                {
                    dGVProductosPromo.Rows[hti.RowIndex].Cells["selected"].Value = true;
                    dGVProductosPromo.Rows[hti.RowIndex].Cells["bSelected"].Value = true;
                    this.dGVProductosPromo.RefreshEdit();
                    this.dGVProductosPromo.NotifyCurrentCellDirty(true);
                }
            }
        }

        //--- GSG (13/01/2017)
        private void dGVProductosPromo_Paint(object sender, PaintEventArgs e)
        {
            for (int j = 0; j < dGVProductosPromo.Rows.Count; j++)
            {
                if (bool.Parse(dGVProductosPromo.Rows[j].Cells["bSelected"].Value.ToString()))
                    dGVProductosPromo.Rows[j].Cells["selected"].Value = true;
                else
                    dGVProductosPromo.Rows[j].Cells["selected"].Value = false;
            }
        }

        private void pnClientesVisitados_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnDatosClienteVisita_Paint(object sender, PaintEventArgs e)
        {

        }

        //---- GSG (03/07/2019)
        private void btEncuestas_Click(object sender, EventArgs e)
        {
            if (this.dgClientes.CurrentRowIndex >= 0)
                Encuestas(true, this.dtClientesDg.Rows[this.dgClientes.CurrentRowIndex]["sIdCliente"].ToString());
            else
                Mensajes.ShowInformation("Para acceder a las encuestas es necesario seleccionar un cliente.");
        }

        private void Encuestas(bool abrir, string sIdCliente)
        {
            _bEncuesta = true;

            if (sIdCliente != "")
            {
                frmEncuesta frmEnc = new frmEncuesta(this.ParamiIdDelegado, sIdCliente);

                if (frmEnc.HayQueHacerlaSiOSi() || abrir)
                {
                    frmEnc.ShowDialog(this);

                    if (frmEnc.DialogResult == DialogResult.OK)
                    {
                        _bEncuesta = true;
                    }
                    else
                        _bEncuesta = false;
                }
                else
                    _bEncuesta = true;
            }
            else
            {
                Mensajes.ShowInformation("Para acceder a las encuestas es necesario seleccionar un cliente.");
            }
        }
    }
}
