using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlClient;
using GESTCRM.CRMControles;


namespace GESTCRM.Formularios.Mantenimientos
{
	public class frmManClientesSAP : GESTCRM.Formularios.Base.frmMantenimientos
	{
		#region Declaraciones
		bool SalirDesdeGuardar;

		string Param_TipoAcceso;
		int Param_iIdCliente;
		int Param_iIdDelegado;
		int Param_Inicio;

		int Var_NumFilaMay;
		int Var_iIdCentro;
		int Var_iIdAccion;

		int Var_iEstado;
		int Var_bEnviadoCEN;


		protected System.Data.SqlClient.SqlTransaction sqlTran;
		private System.Data.SqlClient.SqlConnection sqlConn;
		private System.ComponentModel.IContainer components = null;
		private System.Data.SqlClient.SqlCommand sqlCmdSetCliente;
		private System.Windows.Forms.Button btCentros;
		private System.Windows.Forms.Button btAccionesMark;
		private System.Windows.Forms.Panel pnCliente;
		private System.Windows.Forms.Panel pnCentros;
		private System.Windows.Forms.Panel pnAccionesMark;
		private GESTCRM.Formularios.DataSets.dsClientes dsClientes1;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem menuNuevo;
		private System.Windows.Forms.MenuItem menuEliminar;
		private System.Windows.Forms.DataGrid dgCentros;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle3;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn8;
		private System.Windows.Forms.TextBox txtCentrosId;
		private System.Windows.Forms.TextBox txtCentroDesc;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button btBuscarCentro;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Button btEliminarCen;
		private System.Windows.Forms.Button btActualizarCen;
		private System.Windows.Forms.DataGrid dgAccionesMark;
		private System.Data.SqlClient.SqlDataAdapter sqldaListaAccionesMarkCli;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle4;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn6;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn19;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn20;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn21;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.TextBox txtAccsIdAccion;
		private System.Windows.Forms.DateTimePicker dtpAccFEntrega;
		private System.Windows.Forms.NumericUpDown nupAccCantidad;
		private System.Windows.Forms.TextBox txtAccObservEntrega;
		private System.Windows.Forms.Button btEliminarAcc;
		private System.Windows.Forms.Button btActualizarAcc;
		private System.Windows.Forms.Button btBuscaAccion;
		private System.Data.SqlClient.SqlCommand sqlCmdSetAccionesMarkClientes;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn22;
		private System.Windows.Forms.Label lblTotAcciones;
		private System.Windows.Forms.Label lblTotCentros;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn23;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn24;

		private System.Windows.Forms.TextBox txtTipo_SAP;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.RadioButton rbPotencial_SAP;
		private System.Windows.Forms.TextBox txtDescGrupoCli_SAP;
		private System.Windows.Forms.TextBox txtDescCondPago_SAP;
		private System.Windows.Forms.TextBox txtGrupoCli_SAP;
		private System.Windows.Forms.TextBox txtCondPago_SAP;
		private System.Windows.Forms.TextBox txtDatosBancarios_SAP;
		private System.Windows.Forms.TextBox txtNIF_SAP;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.TextBox txtTeleFax_SAP;
		private System.Windows.Forms.TextBox txtTeles_SAP;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.TextBox txtTelefono2_SAP;
		private System.Windows.Forms.TextBox txtTelefono_SAP;
		private System.Windows.Forms.TextBox txtPoblacion_SAP;
		private System.Windows.Forms.TextBox txtProvincia_SAP;
		private System.Windows.Forms.TextBox txtCP_SAP;
		private System.Windows.Forms.TextBox txtDireccion_SAP;
		private System.Windows.Forms.TextBox txtNombre_SAP;
		private System.Windows.Forms.TextBox txtsIdCliente_SAP;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.Label label28;
		private System.Windows.Forms.Label lblsIdCliente;
		private System.Windows.Forms.Label label29;
		private System.Windows.Forms.Label label30;
		private System.Windows.Forms.Label label31;
		private System.Windows.Forms.Label label35;
		private System.Data.SqlClient.SqlDataAdapter sqldaGetCliente_SAP;
		private System.Data.SqlClient.SqlDataAdapter sqldaListaCentros_porCliente_SAP;
		private System.Windows.Forms.DataGrid dgContactos;

		private System.Data.SqlClient.SqlDataAdapter sqldaListaContactosporCliente_SAP;
        private System.Data.SqlClient.SqlDataAdapter sqldaListaTipoCtoClienteSAP;
        private System.Data.SqlClient.SqlDataAdapter sqldaListaAreasporCliente_SAP; //---- GSG (27/05/2013)
        private System.Data.SqlClient.SqlDataAdapter sqldaListaTipoAreasClienteSAP; //---- GSG (27/05/2013)
        private System.Data.SqlClient.SqlDataAdapter sqldaListaProgInfCliente_SAP; //---- GSG (27/05/2013)
        private System.Data.SqlClient.SqlDataAdapter sqldaListaTipoProgInfClienteSAP; //---- GSG (27/05/2013)
        
        
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
		private System.Windows.Forms.Label lblTotContactos;
		private System.Windows.Forms.Button btEliminaCont;
		private System.Windows.Forms.Button btActualizaCont;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		
        
		private System.Windows.Forms.ComboBox cbContCargo;
		private System.Windows.Forms.TextBox txtContNombre;

		private System.Data.SqlClient.SqlCommand sqlSelectCommand3;
        private System.Data.SqlClient.SqlCommand sqlSelectListaTipoCtoClienteSAP;

        private System.Data.SqlClient.SqlCommand sqlSelectCommandListaAreasporCliente_SAP; //---- GSG (27/05/2013)
        private System.Data.SqlClient.SqlCommand sqlSelectCommandTipoAreasClienteSAP; //---- GSG (27/05/2013)
        private System.Data.SqlClient.SqlCommand sqlSelectCommandListaProgInfporCliente_SAP; //---- GSG (27/05/2013)
        private System.Data.SqlClient.SqlCommand sqlSelectCommandTipoProgInfClienteSAP; //---- GSG (27/05/2013
        private System.Data.SqlClient.SqlCommand sqlCmdSetAreasClientesSAP; //---- GSG (27/05/2013)
        private System.Data.SqlClient.SqlCommand sqlCmdSetProgInfClientesSAP; //---- GSG (30/05/2013)

		private System.Data.SqlClient.SqlCommand sqlCmdSetCentrosClienteSAP;
		private System.Data.SqlClient.SqlCommand sqlCmdSetContactosClientesSAP;

        private bool _bEncuesta = false; //---- GSG (03/07/2019)

        private System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		private GESTCRM.Controles.ucBotoneraSecundaria ucBotoneraSecundaria1;
		private System.Windows.Forms.Button btCRM;
		private System.Windows.Forms.Panel pnCRM;
		private GESTCRM.CRMControles.ucUltimoPedido ucUltimoPedido1;
		private GESTCRM.CRMControles.ucRankingMatCli ucRankingMatCli1;
		private GESTCRM.Controles.LabelGradient lblTitulo;
		private System.Windows.Forms.Panel panel2;
		private GESTCRM.Controles.LabelGradient labelGradient1;
		private System.Windows.Forms.Panel panel3;
		private GESTCRM.Controles.LabelGradient labelGradient2;
		private System.Windows.Forms.Panel panel6;
		private GESTCRM.Controles.LabelGradient labelGradient3;
		private System.Windows.Forms.Button btMayoristas;
		private System.Windows.Forms.Panel pnMayoristas;
		private System.Windows.Forms.Panel panel7;
		private GESTCRM.Controles.LabelGradient labelGradient4;
		private System.Windows.Forms.DataGrid dgMayoristas;
		private System.Windows.Forms.Label lblTotMayoristas;
		private System.Data.SqlClient.SqlDataAdapter sqldaListaMayoristasClientes_SAP;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn5;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn9;
		private GESTCRM.CRMControles.ucUltimasVisitas ucUltimasVisitas1;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand6;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand5;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn10;
		private System.Windows.Forms.ComboBox cboClasificacion;
		private System.Windows.Forms.Label lblClasificacion;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand7;
		private System.Data.SqlClient.SqlDataAdapter sqldaListaTipoClasificacion;
		private System.Data.SqlClient.SqlCommand sqlCmdSetClienteRed;
		private System.Data.SqlClient.SqlDataAdapter sqlDAClienteRed;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand8;
		private System.Windows.Forms.Label lblGarantias;
		private System.Windows.Forms.TextBox txtGarantias_SAP;
		private System.Windows.Forms.TextBox txtEncComercial_SAP;
		private System.Windows.Forms.Label lblEnComercial;
		private TextBox txtGarantias_SAP_1;
		private Label lblGarantias1;
		private TextBox txtGarantias_SAP_4;
		private Label lblGarantias4;
		private TextBox txtGarntias_SAP_3;
		private Label lblGarantias3;
		private TextBox txtGarantias_SAP_2;
		private Label lblGarantias2;
        private BindingSource listaTipoAreaCliSAPBindingSource;
        private ComboBox cbProgInf;
        private BindingSource ListaTipoProgInfCliSAPBindingSource;
        private BindingSource dsClientes1BindingSource;
        private BindingSource listaAreasporClienteSAPBindingSource;
        private DataGridTextBoxColumn dataGridTextBoxColumn3;
        private DataGridTextBoxColumn dataGridTextBoxColumn7;
        private Button btEncuestas;
        private System.Windows.Forms.Label label36;


		#endregion


		public frmManClientesSAP(string TipoAcceso,int iIdCliente)
		{
            InitializeComponent();


            //---- GSG (06/03/2021)
            Utiles.GetConfigConnection();
            this.sqlConn.ConnectionString = Utiles._connection.ConnectionString.ToString();

            
	
			this.Param_TipoAcceso = TipoAcceso;
			this.Param_iIdCliente = iIdCliente;
			this.Param_Inicio = -1;
		}

		public frmManClientesSAP(string TipoAcceso,int iIdCliente,int Inicio)
		{
            InitializeComponent();


            //---- GSG (06/03/2021)
            Utiles.GetConfigConnection();
            this.sqlConn.ConnectionString = Utiles._connection.ConnectionString.ToString();

            
	
			this.Param_TipoAcceso = TipoAcceso;
			this.Param_iIdCliente = iIdCliente;
			this.Param_Inicio = Inicio;
		}
		
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManClientesSAP));
            this.sqlConn = new System.Data.SqlClient.SqlConnection();
            this.sqlCmdSetCliente = new System.Data.SqlClient.SqlCommand();
            this.pnCliente = new System.Windows.Forms.Panel();
            this.txtGarantias_SAP_4 = new System.Windows.Forms.TextBox();
            this.dsClientes1 = new GESTCRM.Formularios.DataSets.dsClientes();
            this.lblGarantias4 = new System.Windows.Forms.Label();
            this.txtGarntias_SAP_3 = new System.Windows.Forms.TextBox();
            this.lblGarantias3 = new System.Windows.Forms.Label();
            this.txtGarantias_SAP_2 = new System.Windows.Forms.TextBox();
            this.lblGarantias2 = new System.Windows.Forms.Label();
            this.txtGarantias_SAP_1 = new System.Windows.Forms.TextBox();
            this.lblGarantias1 = new System.Windows.Forms.Label();
            this.txtEncComercial_SAP = new System.Windows.Forms.TextBox();
            this.lblEnComercial = new System.Windows.Forms.Label();
            this.txtGarantias_SAP = new System.Windows.Forms.TextBox();
            this.lblGarantias = new System.Windows.Forms.Label();
            this.txtTipo_SAP = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtPoblacion_SAP = new System.Windows.Forms.TextBox();
            this.txtProvincia_SAP = new System.Windows.Forms.TextBox();
            this.txtCP_SAP = new System.Windows.Forms.TextBox();
            this.txtDireccion_SAP = new System.Windows.Forms.TextBox();
            this.txtNombre_SAP = new System.Windows.Forms.TextBox();
            this.txtsIdCliente_SAP = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.cboClasificacion = new System.Windows.Forms.ComboBox();
            this.lblTitulo = new GESTCRM.Controles.LabelGradient();
            this.txtDescGrupoCli_SAP = new System.Windows.Forms.TextBox();
            this.txtDescCondPago_SAP = new System.Windows.Forms.TextBox();
            this.txtGrupoCli_SAP = new System.Windows.Forms.TextBox();
            this.txtCondPago_SAP = new System.Windows.Forms.TextBox();
            this.txtDatosBancarios_SAP = new System.Windows.Forms.TextBox();
            this.txtNIF_SAP = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.txtTeleFax_SAP = new System.Windows.Forms.TextBox();
            this.txtTeles_SAP = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtTelefono2_SAP = new System.Windows.Forms.TextBox();
            this.txtTelefono_SAP = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.lblsIdCliente = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.rbPotencial_SAP = new System.Windows.Forms.RadioButton();
            this.lblClasificacion = new System.Windows.Forms.Label();
            this.btCentros = new System.Windows.Forms.Button();
            this.btAccionesMark = new System.Windows.Forms.Button();
            this.pnCentros = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgContactos = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.lblTotContactos = new System.Windows.Forms.Label();
            this.labelGradient2 = new GESTCRM.Controles.LabelGradient();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgCentros = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle3 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn7 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn22 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn8 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.lblTotCentros = new System.Windows.Forms.Label();
            this.labelGradient1 = new GESTCRM.Controles.LabelGradient();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cbContCargo = new System.Windows.Forms.ComboBox();
            this.txtContNombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btEliminaCont = new System.Windows.Forms.Button();
            this.btActualizaCont = new System.Windows.Forms.Button();
            this.btEliminarCen = new System.Windows.Forms.Button();
            this.btActualizarCen = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.cbProgInf = new System.Windows.Forms.ComboBox();
            this.txtCentroDesc = new System.Windows.Forms.TextBox();
            this.txtCentrosId = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btBuscarCentro = new System.Windows.Forms.Button();
            this.listaAreasporClienteSAPBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridTextBoxColumn24 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.pnAccionesMark = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.dgAccionesMark = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle4 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn6 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn19 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn20 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn21 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn23 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.lblTotAcciones = new System.Windows.Forms.Label();
            this.labelGradient3 = new GESTCRM.Controles.LabelGradient();
            this.btEliminarAcc = new System.Windows.Forms.Button();
            this.btActualizarAcc = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btBuscaAccion = new System.Windows.Forms.Button();
            this.txtAccObservEntrega = new System.Windows.Forms.TextBox();
            this.nupAccCantidad = new System.Windows.Forms.NumericUpDown();
            this.dtpAccFEntrega = new System.Windows.Forms.DateTimePicker();
            this.txtAccsIdAccion = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.menuNuevo = new System.Windows.Forms.MenuItem();
            this.menuEliminar = new System.Windows.Forms.MenuItem();
            this.sqldaListaCentros_porCliente_SAP = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.sqldaListaAccionesMarkCli = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand6 = new System.Data.SqlClient.SqlCommand();
            this.sqldaGetCliente_SAP = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdSetAccionesMarkClientes = new System.Data.SqlClient.SqlCommand();
            this.sqldaListaContactosporCliente_SAP = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
            this.sqldaListaTipoCtoClienteSAP = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectListaTipoCtoClienteSAP = new System.Data.SqlClient.SqlCommand();
            this.sqldaListaAreasporCliente_SAP = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommandListaAreasporCliente_SAP = new System.Data.SqlClient.SqlCommand();
            this.sqldaListaTipoAreasClienteSAP = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommandTipoAreasClienteSAP = new System.Data.SqlClient.SqlCommand();
            this.sqldaListaProgInfCliente_SAP = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommandListaProgInfporCliente_SAP = new System.Data.SqlClient.SqlCommand();
            this.sqldaListaTipoProgInfClienteSAP = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommandTipoProgInfClienteSAP = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdSetCentrosClienteSAP = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdSetAreasClientesSAP = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdSetProgInfClientesSAP = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdSetContactosClientesSAP = new System.Data.SqlClient.SqlCommand();
            this.ucBotoneraSecundaria1 = new GESTCRM.Controles.ucBotoneraSecundaria();
            this.btCRM = new System.Windows.Forms.Button();
            this.pnCRM = new System.Windows.Forms.Panel();
            this.ucUltimasVisitas1 = new GESTCRM.CRMControles.ucUltimasVisitas();
            this.ucRankingMatCli1 = new GESTCRM.CRMControles.ucRankingMatCli();
            this.ucUltimoPedido1 = new GESTCRM.CRMControles.ucUltimoPedido();
            this.btMayoristas = new System.Windows.Forms.Button();
            this.pnMayoristas = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.lblTotMayoristas = new System.Windows.Forms.Label();
            this.dgMayoristas = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn10 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn5 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn9 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.labelGradient4 = new GESTCRM.Controles.LabelGradient();
            this.sqldaListaMayoristasClientes_SAP = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand5 = new System.Data.SqlClient.SqlCommand();
            this.sqldaListaTipoClasificacion = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand7 = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdSetClienteRed = new System.Data.SqlClient.SqlCommand();
            this.sqlDAClienteRed = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand8 = new System.Data.SqlClient.SqlCommand();
            this.listaTipoAreaCliSAPBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ListaTipoProgInfCliSAPBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsClientes1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btEncuestas = new System.Windows.Forms.Button();
            this.pnCliente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsClientes1)).BeginInit();
            this.pnCentros.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgContactos)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCentros)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listaAreasporClienteSAPBindingSource)).BeginInit();
            this.pnAccionesMark.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgAccionesMark)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupAccCantidad)).BeginInit();
            this.pnMayoristas.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgMayoristas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listaTipoAreaCliSAPBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListaTipoProgInfCliSAPBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsClientes1BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // sqlConn
            // 
            this.sqlConn.FireInfoMessageEventOnUserErrors = false;
            // 
            // sqlCmdSetCliente
            // 
            this.sqlCmdSetCliente.CommandText = "[SetCliente]";
            this.sqlCmdSetCliente.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdSetCliente.Connection = this.sqlConn;
            this.sqlCmdSetCliente.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@Accion", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4)});
            // 
            // pnCliente
            // 
            this.pnCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnCliente.Controls.Add(this.txtGarantias_SAP_4);
            this.pnCliente.Controls.Add(this.lblGarantias4);
            this.pnCliente.Controls.Add(this.txtGarntias_SAP_3);
            this.pnCliente.Controls.Add(this.lblGarantias3);
            this.pnCliente.Controls.Add(this.txtGarantias_SAP_2);
            this.pnCliente.Controls.Add(this.lblGarantias2);
            this.pnCliente.Controls.Add(this.txtGarantias_SAP_1);
            this.pnCliente.Controls.Add(this.lblGarantias1);
            this.pnCliente.Controls.Add(this.txtEncComercial_SAP);
            this.pnCliente.Controls.Add(this.lblEnComercial);
            this.pnCliente.Controls.Add(this.txtGarantias_SAP);
            this.pnCliente.Controls.Add(this.lblGarantias);
            this.pnCliente.Controls.Add(this.txtTipo_SAP);
            this.pnCliente.Controls.Add(this.label18);
            this.pnCliente.Controls.Add(this.txtPoblacion_SAP);
            this.pnCliente.Controls.Add(this.txtProvincia_SAP);
            this.pnCliente.Controls.Add(this.txtCP_SAP);
            this.pnCliente.Controls.Add(this.txtDireccion_SAP);
            this.pnCliente.Controls.Add(this.txtNombre_SAP);
            this.pnCliente.Controls.Add(this.txtsIdCliente_SAP);
            this.pnCliente.Controls.Add(this.label24);
            this.pnCliente.Controls.Add(this.cboClasificacion);
            this.pnCliente.Controls.Add(this.lblTitulo);
            this.pnCliente.Controls.Add(this.txtDescGrupoCli_SAP);
            this.pnCliente.Controls.Add(this.txtDescCondPago_SAP);
            this.pnCliente.Controls.Add(this.txtGrupoCli_SAP);
            this.pnCliente.Controls.Add(this.txtCondPago_SAP);
            this.pnCliente.Controls.Add(this.txtDatosBancarios_SAP);
            this.pnCliente.Controls.Add(this.txtNIF_SAP);
            this.pnCliente.Controls.Add(this.label19);
            this.pnCliente.Controls.Add(this.label20);
            this.pnCliente.Controls.Add(this.txtTeleFax_SAP);
            this.pnCliente.Controls.Add(this.txtTeles_SAP);
            this.pnCliente.Controls.Add(this.label21);
            this.pnCliente.Controls.Add(this.txtTelefono2_SAP);
            this.pnCliente.Controls.Add(this.txtTelefono_SAP);
            this.pnCliente.Controls.Add(this.label25);
            this.pnCliente.Controls.Add(this.label26);
            this.pnCliente.Controls.Add(this.label27);
            this.pnCliente.Controls.Add(this.label28);
            this.pnCliente.Controls.Add(this.lblsIdCliente);
            this.pnCliente.Controls.Add(this.label29);
            this.pnCliente.Controls.Add(this.label30);
            this.pnCliente.Controls.Add(this.label31);
            this.pnCliente.Controls.Add(this.label35);
            this.pnCliente.Controls.Add(this.label36);
            this.pnCliente.Controls.Add(this.rbPotencial_SAP);
            this.pnCliente.Controls.Add(this.lblClasificacion);
            this.pnCliente.ForeColor = System.Drawing.Color.Black;
            this.pnCliente.Location = new System.Drawing.Point(1, 40);
            this.pnCliente.Name = "pnCliente";
            this.pnCliente.Size = new System.Drawing.Size(1103, 169);
            this.pnCliente.TabIndex = 0;
            // 
            // txtGarantias_SAP_4
            // 
            this.txtGarantias_SAP_4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtGarantias_SAP_4.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsClientes1, "GetCliente_SAP.sGarantias_SAP_4", true));
            this.txtGarantias_SAP_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGarantias_SAP_4.Location = new System.Drawing.Point(935, 136);
            this.txtGarantias_SAP_4.Name = "txtGarantias_SAP_4";
            this.txtGarantias_SAP_4.ReadOnly = true;
            this.txtGarantias_SAP_4.Size = new System.Drawing.Size(160, 26);
            this.txtGarantias_SAP_4.TabIndex = 103;
            // 
            // dsClientes1
            // 
            this.dsClientes1.DataSetName = "dsClientes";
            this.dsClientes1.Locale = new System.Globalization.CultureInfo("en-US");
            this.dsClientes1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lblGarantias4
            // 
            this.lblGarantias4.AutoSize = true;
            this.lblGarantias4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGarantias4.Location = new System.Drawing.Point(874, 139);
            this.lblGarantias4.Name = "lblGarantias4";
            this.lblGarantias4.Size = new System.Drawing.Size(58, 20);
            this.lblGarantias4.TabIndex = 102;
            this.lblGarantias4.Text = "Club 4:";
            // 
            // txtGarntias_SAP_3
            // 
            this.txtGarntias_SAP_3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtGarntias_SAP_3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsClientes1, "GetCliente_SAP.sGarantias_SAP_3", true));
            this.txtGarntias_SAP_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGarntias_SAP_3.Location = new System.Drawing.Point(712, 136);
            this.txtGarntias_SAP_3.Name = "txtGarntias_SAP_3";
            this.txtGarntias_SAP_3.ReadOnly = true;
            this.txtGarntias_SAP_3.Size = new System.Drawing.Size(160, 26);
            this.txtGarntias_SAP_3.TabIndex = 101;
            // 
            // lblGarantias3
            // 
            this.lblGarantias3.AutoSize = true;
            this.lblGarantias3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGarantias3.Location = new System.Drawing.Point(653, 139);
            this.lblGarantias3.Name = "lblGarantias3";
            this.lblGarantias3.Size = new System.Drawing.Size(58, 20);
            this.lblGarantias3.TabIndex = 100;
            this.lblGarantias3.Text = "Club 3:";
            // 
            // txtGarantias_SAP_2
            // 
            this.txtGarantias_SAP_2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtGarantias_SAP_2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsClientes1, "GetCliente_SAP.sGarantias_SAP_2", true));
            this.txtGarantias_SAP_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGarantias_SAP_2.Location = new System.Drawing.Point(491, 136);
            this.txtGarantias_SAP_2.Name = "txtGarantias_SAP_2";
            this.txtGarantias_SAP_2.ReadOnly = true;
            this.txtGarantias_SAP_2.Size = new System.Drawing.Size(160, 26);
            this.txtGarantias_SAP_2.TabIndex = 99;
            // 
            // lblGarantias2
            // 
            this.lblGarantias2.AutoSize = true;
            this.lblGarantias2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGarantias2.Location = new System.Drawing.Point(437, 139);
            this.lblGarantias2.Name = "lblGarantias2";
            this.lblGarantias2.Size = new System.Drawing.Size(58, 20);
            this.lblGarantias2.TabIndex = 98;
            this.lblGarantias2.Text = "Club 2:";
            // 
            // txtGarantias_SAP_1
            // 
            this.txtGarantias_SAP_1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtGarantias_SAP_1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsClientes1, "GetCliente_SAP.sGarantias_SAP_1", true));
            this.txtGarantias_SAP_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGarantias_SAP_1.Location = new System.Drawing.Point(274, 136);
            this.txtGarantias_SAP_1.Name = "txtGarantias_SAP_1";
            this.txtGarantias_SAP_1.ReadOnly = true;
            this.txtGarantias_SAP_1.Size = new System.Drawing.Size(160, 26);
            this.txtGarantias_SAP_1.TabIndex = 97;
            // 
            // lblGarantias1
            // 
            this.lblGarantias1.AutoSize = true;
            this.lblGarantias1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGarantias1.Location = new System.Drawing.Point(220, 139);
            this.lblGarantias1.Name = "lblGarantias1";
            this.lblGarantias1.Size = new System.Drawing.Size(58, 20);
            this.lblGarantias1.TabIndex = 96;
            this.lblGarantias1.Text = "Club 1:";
            // 
            // txtEncComercial_SAP
            // 
            this.txtEncComercial_SAP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtEncComercial_SAP.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsClientes1, "GetCliente_SAP.sEncComercial_SAP", true));
            this.txtEncComercial_SAP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEncComercial_SAP.Location = new System.Drawing.Point(428, 82);
            this.txtEncComercial_SAP.Name = "txtEncComercial_SAP";
            this.txtEncComercial_SAP.ReadOnly = true;
            this.txtEncComercial_SAP.Size = new System.Drawing.Size(140, 26);
            this.txtEncComercial_SAP.TabIndex = 94;
            // 
            // lblEnComercial
            // 
            this.lblEnComercial.AutoSize = true;
            this.lblEnComercial.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnComercial.Location = new System.Drawing.Point(333, 85);
            this.lblEnComercial.Name = "lblEnComercial";
            this.lblEnComercial.Size = new System.Drawing.Size(93, 20);
            this.lblEnComercial.TabIndex = 95;
            this.lblEnComercial.Text = "Impagados:";
            // 
            // txtGarantias_SAP
            // 
            this.txtGarantias_SAP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtGarantias_SAP.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsClientes1, "GetCliente_SAP.sGarantias_SAP", true));
            this.txtGarantias_SAP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGarantias_SAP.Location = new System.Drawing.Point(56, 136);
            this.txtGarantias_SAP.Name = "txtGarantias_SAP";
            this.txtGarantias_SAP.ReadOnly = true;
            this.txtGarantias_SAP.Size = new System.Drawing.Size(160, 26);
            this.txtGarantias_SAP.TabIndex = 18;
            // 
            // lblGarantias
            // 
            this.lblGarantias.AutoSize = true;
            this.lblGarantias.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGarantias.Location = new System.Drawing.Point(1, 139);
            this.lblGarantias.Name = "lblGarantias";
            this.lblGarantias.Size = new System.Drawing.Size(58, 20);
            this.lblGarantias.TabIndex = 93;
            this.lblGarantias.Text = "Club 0:";
            // 
            // txtTipo_SAP
            // 
            this.txtTipo_SAP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtTipo_SAP.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsClientes1, "GetCliente_SAP.tTipoCliente", true));
            this.txtTipo_SAP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTipo_SAP.Location = new System.Drawing.Point(237, 27);
            this.txtTipo_SAP.Name = "txtTipo_SAP";
            this.txtTipo_SAP.ReadOnly = true;
            this.txtTipo_SAP.Size = new System.Drawing.Size(82, 26);
            this.txtTipo_SAP.TabIndex = 1;
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(198, 31);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(43, 20);
            this.label18.TabIndex = 65;
            this.label18.Text = "Tipo:";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPoblacion_SAP
            // 
            this.txtPoblacion_SAP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtPoblacion_SAP.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsClientes1, "GetCliente_SAP.sPoblacion", true));
            this.txtPoblacion_SAP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPoblacion_SAP.Location = new System.Drawing.Point(84, 109);
            this.txtPoblacion_SAP.Name = "txtPoblacion_SAP";
            this.txtPoblacion_SAP.ReadOnly = true;
            this.txtPoblacion_SAP.Size = new System.Drawing.Size(170, 26);
            this.txtPoblacion_SAP.TabIndex = 13;
            // 
            // txtProvincia_SAP
            // 
            this.txtProvincia_SAP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtProvincia_SAP.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsClientes1, "GetCliente_SAP.sProvincia", true));
            this.txtProvincia_SAP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProvincia_SAP.Location = new System.Drawing.Point(428, 109);
            this.txtProvincia_SAP.Name = "txtProvincia_SAP";
            this.txtProvincia_SAP.ReadOnly = true;
            this.txtProvincia_SAP.Size = new System.Drawing.Size(139, 26);
            this.txtProvincia_SAP.TabIndex = 17;
            this.txtProvincia_SAP.TextChanged += new System.EventHandler(this.txtProvincia_SAP_TextChanged);
            // 
            // txtCP_SAP
            // 
            this.txtCP_SAP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtCP_SAP.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsClientes1, "GetCliente_SAP.CodPostal", true));
            this.txtCP_SAP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCP_SAP.Location = new System.Drawing.Point(297, 109);
            this.txtCP_SAP.Name = "txtCP_SAP";
            this.txtCP_SAP.ReadOnly = true;
            this.txtCP_SAP.Size = new System.Drawing.Size(50, 26);
            this.txtCP_SAP.TabIndex = 12;
            // 
            // txtDireccion_SAP
            // 
            this.txtDireccion_SAP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtDireccion_SAP.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsClientes1, "GetCliente_SAP.sDireccion_SAP", true));
            this.txtDireccion_SAP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDireccion_SAP.Location = new System.Drawing.Point(83, 82);
            this.txtDireccion_SAP.Name = "txtDireccion_SAP";
            this.txtDireccion_SAP.ReadOnly = true;
            this.txtDireccion_SAP.Size = new System.Drawing.Size(244, 26);
            this.txtDireccion_SAP.TabIndex = 8;
            // 
            // txtNombre_SAP
            // 
            this.txtNombre_SAP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtNombre_SAP.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsClientes1, "GetCliente_SAP.tNombre", true));
            this.txtNombre_SAP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre_SAP.Location = new System.Drawing.Point(70, 54);
            this.txtNombre_SAP.Name = "txtNombre_SAP";
            this.txtNombre_SAP.ReadOnly = true;
            this.txtNombre_SAP.Size = new System.Drawing.Size(348, 26);
            this.txtNombre_SAP.TabIndex = 5;
            // 
            // txtsIdCliente_SAP
            // 
            this.txtsIdCliente_SAP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtsIdCliente_SAP.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsClientes1, "GetCliente_SAP.sIdCliente", true));
            this.txtsIdCliente_SAP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsIdCliente_SAP.Location = new System.Drawing.Point(71, 27);
            this.txtsIdCliente_SAP.Name = "txtsIdCliente_SAP";
            this.txtsIdCliente_SAP.ReadOnly = true;
            this.txtsIdCliente_SAP.Size = new System.Drawing.Size(124, 26);
            this.txtsIdCliente_SAP.TabIndex = 0;
            // 
            // label24
            // 
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(2, 112);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(82, 18);
            this.label24.TabIndex = 42;
            this.label24.Text = "Población:";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboClasificacion
            // 
            this.cboClasificacion.DataSource = this.dsClientes1.ListaTipoClasificacion;
            this.cboClasificacion.DisplayMember = "sLiteral";
            this.cboClasificacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboClasificacion.Enabled = false;
            this.cboClasificacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboClasificacion.ForeColor = System.Drawing.Color.Black;
            this.cboClasificacion.ItemHeight = 20;
            this.cboClasificacion.Location = new System.Drawing.Point(425, 26);
            this.cboClasificacion.Name = "cboClasificacion";
            this.cboClasificacion.Size = new System.Drawing.Size(142, 28);
            this.cboClasificacion.TabIndex = 91;
            this.cboClasificacion.ValueMember = "sValor";
            this.cboClasificacion.SelectedIndexChanged += new System.EventHandler(this.cboClasificacion_SelectedIndexChanged);
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
            this.lblTitulo.Size = new System.Drawing.Size(1101, 22);
            this.lblTitulo.TabIndex = 67;
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDescGrupoCli_SAP
            // 
            this.txtDescGrupoCli_SAP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtDescGrupoCli_SAP.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsClientes1, "GetCliente_SAP.tTipoCli", true));
            this.txtDescGrupoCli_SAP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescGrupoCli_SAP.Location = new System.Drawing.Point(941, 109);
            this.txtDescGrupoCli_SAP.Name = "txtDescGrupoCli_SAP";
            this.txtDescGrupoCli_SAP.ReadOnly = true;
            this.txtDescGrupoCli_SAP.Size = new System.Drawing.Size(155, 26);
            this.txtDescGrupoCli_SAP.TabIndex = 16;
            // 
            // txtDescCondPago_SAP
            // 
            this.txtDescCondPago_SAP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtDescCondPago_SAP.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsClientes1, "GetCliente_SAP.tCodPago_SAP", true));
            this.txtDescCondPago_SAP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescCondPago_SAP.Location = new System.Drawing.Point(941, 82);
            this.txtDescCondPago_SAP.Name = "txtDescCondPago_SAP";
            this.txtDescCondPago_SAP.ReadOnly = true;
            this.txtDescCondPago_SAP.Size = new System.Drawing.Size(155, 26);
            this.txtDescCondPago_SAP.TabIndex = 11;
            // 
            // txtGrupoCli_SAP
            // 
            this.txtGrupoCli_SAP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtGrupoCli_SAP.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsClientes1, "GetCliente_SAP.sGrupoClientes_SAP", true));
            this.txtGrupoCli_SAP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGrupoCli_SAP.Location = new System.Drawing.Point(890, 108);
            this.txtGrupoCli_SAP.Name = "txtGrupoCli_SAP";
            this.txtGrupoCli_SAP.ReadOnly = true;
            this.txtGrupoCli_SAP.Size = new System.Drawing.Size(46, 26);
            this.txtGrupoCli_SAP.TabIndex = 15;
            // 
            // txtCondPago_SAP
            // 
            this.txtCondPago_SAP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtCondPago_SAP.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsClientes1, "GetCliente_SAP.sCodPago_SAP", true));
            this.txtCondPago_SAP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCondPago_SAP.Location = new System.Drawing.Point(891, 81);
            this.txtCondPago_SAP.Name = "txtCondPago_SAP";
            this.txtCondPago_SAP.ReadOnly = true;
            this.txtCondPago_SAP.Size = new System.Drawing.Size(46, 26);
            this.txtCondPago_SAP.TabIndex = 10;
            // 
            // txtDatosBancarios_SAP
            // 
            this.txtDatosBancarios_SAP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtDatosBancarios_SAP.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsClientes1, "GetCliente_SAP.sDatosBancarios_SAP", true));
            this.txtDatosBancarios_SAP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDatosBancarios_SAP.Location = new System.Drawing.Point(891, 54);
            this.txtDatosBancarios_SAP.Name = "txtDatosBancarios_SAP";
            this.txtDatosBancarios_SAP.ReadOnly = true;
            this.txtDatosBancarios_SAP.Size = new System.Drawing.Size(205, 26);
            this.txtDatosBancarios_SAP.TabIndex = 7;
            // 
            // txtNIF_SAP
            // 
            this.txtNIF_SAP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtNIF_SAP.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsClientes1, "GetCliente_SAP.sNIF_SAP", true));
            this.txtNIF_SAP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNIF_SAP.Location = new System.Drawing.Point(891, 27);
            this.txtNIF_SAP.Name = "txtNIF_SAP";
            this.txtNIF_SAP.ReadOnly = true;
            this.txtNIF_SAP.Size = new System.Drawing.Size(205, 26);
            this.txtNIF_SAP.TabIndex = 4;
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(759, 112);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(120, 21);
            this.label19.TabIndex = 57;
            this.label19.Text = "Grupo Clientes:";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label20
            // 
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(759, 85);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(96, 20);
            this.label20.TabIndex = 56;
            this.label20.Text = "Cond. Pago:";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTeleFax_SAP
            // 
            this.txtTeleFax_SAP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtTeleFax_SAP.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsClientes1, "GetCliente_SAP.sTelefax_SAP", true));
            this.txtTeleFax_SAP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTeleFax_SAP.Location = new System.Drawing.Point(654, 109);
            this.txtTeleFax_SAP.Name = "txtTeleFax_SAP";
            this.txtTeleFax_SAP.ReadOnly = true;
            this.txtTeleFax_SAP.Size = new System.Drawing.Size(101, 26);
            this.txtTeleFax_SAP.TabIndex = 14;
            // 
            // txtTeles_SAP
            // 
            this.txtTeles_SAP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtTeles_SAP.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsClientes1, "GetCliente_SAP.sTeles_SAP", true));
            this.txtTeles_SAP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTeles_SAP.Location = new System.Drawing.Point(654, 82);
            this.txtTeles_SAP.Name = "txtTeles_SAP";
            this.txtTeles_SAP.ReadOnly = true;
            this.txtTeles_SAP.Size = new System.Drawing.Size(101, 26);
            this.txtTeles_SAP.TabIndex = 9;
            // 
            // label21
            // 
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(570, 112);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(78, 18);
            this.label21.TabIndex = 53;
            this.label21.Text = "TeleFax:";
            // 
            // txtTelefono2_SAP
            // 
            this.txtTelefono2_SAP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtTelefono2_SAP.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsClientes1, "GetCliente_SAP.sTelefono2_SAP", true));
            this.txtTelefono2_SAP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelefono2_SAP.Location = new System.Drawing.Point(654, 54);
            this.txtTelefono2_SAP.Name = "txtTelefono2_SAP";
            this.txtTelefono2_SAP.ReadOnly = true;
            this.txtTelefono2_SAP.Size = new System.Drawing.Size(101, 26);
            this.txtTelefono2_SAP.TabIndex = 6;
            // 
            // txtTelefono_SAP
            // 
            this.txtTelefono_SAP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtTelefono_SAP.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsClientes1, "GetCliente_SAP.sTelefono", true));
            this.txtTelefono_SAP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelefono_SAP.Location = new System.Drawing.Point(654, 27);
            this.txtTelefono_SAP.Name = "txtTelefono_SAP";
            this.txtTelefono_SAP.ReadOnly = true;
            this.txtTelefono_SAP.Size = new System.Drawing.Size(101, 26);
            this.txtTelefono_SAP.TabIndex = 3;
            // 
            // label25
            // 
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(3, 85);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(79, 18);
            this.label25.TabIndex = 40;
            this.label25.Text = "Dirección:";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label26
            // 
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(349, 112);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(76, 18);
            this.label26.TabIndex = 39;
            this.label26.Text = "Provincia:";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label26.Click += new System.EventHandler(this.label26_Click);
            // 
            // label27
            // 
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(759, 31);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(90, 18);
            this.label27.TabIndex = 37;
            this.label27.Text = "NIF:";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label28
            // 
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(3, 58);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(69, 18);
            this.label28.TabIndex = 34;
            this.label28.Text = "Nombre:";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblsIdCliente
            // 
            this.lblsIdCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsIdCliente.Location = new System.Drawing.Point(3, 31);
            this.lblsIdCliente.Name = "lblsIdCliente";
            this.lblsIdCliente.Size = new System.Drawing.Size(67, 18);
            this.lblsIdCliente.TabIndex = 33;
            this.lblsIdCliente.Text = "Cód.Cli.:";
            this.lblsIdCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label29
            // 
            this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(259, 112);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(42, 18);
            this.label29.TabIndex = 41;
            this.label29.Text = "C.P.:";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label30
            // 
            this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.Location = new System.Drawing.Point(570, 31);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(84, 18);
            this.label30.TabIndex = 35;
            this.label30.Text = "Teléfono1:";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label31
            // 
            this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.Location = new System.Drawing.Point(570, 58);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(84, 18);
            this.label31.TabIndex = 32;
            this.label31.Text = "Teléfono2:";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label35
            // 
            this.label35.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label35.Location = new System.Drawing.Point(570, 85);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(56, 18);
            this.label35.TabIndex = 38;
            this.label35.Text = "Teles:";
            // 
            // label36
            // 
            this.label36.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.Location = new System.Drawing.Point(759, 58);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(131, 18);
            this.label36.TabIndex = 36;
            this.label36.Text = "Datos Bancarios:";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rbPotencial_SAP
            // 
            this.rbPotencial_SAP.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbPotencial_SAP.Enabled = false;
            this.rbPotencial_SAP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbPotencial_SAP.Location = new System.Drawing.Point(451, 56);
            this.rbPotencial_SAP.Name = "rbPotencial_SAP";
            this.rbPotencial_SAP.Size = new System.Drawing.Size(98, 24);
            this.rbPotencial_SAP.TabIndex = 18;
            this.rbPotencial_SAP.Text = "Potencial:";
            // 
            // lblClasificacion
            // 
            this.lblClasificacion.AutoSize = true;
            this.lblClasificacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblClasificacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClasificacion.ForeColor = System.Drawing.Color.Black;
            this.lblClasificacion.Location = new System.Drawing.Point(321, 31);
            this.lblClasificacion.Name = "lblClasificacion";
            this.lblClasificacion.Size = new System.Drawing.Size(101, 20);
            this.lblClasificacion.TabIndex = 92;
            this.lblClasificacion.Text = "Clasificación:";
            // 
            // btCentros
            // 
            this.btCentros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btCentros.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCentros.Location = new System.Drawing.Point(507, 213);
            this.btCentros.Name = "btCentros";
            this.btCentros.Size = new System.Drawing.Size(250, 29);
            this.btCentros.TabIndex = 4;
            this.btCentros.Text = "&4 - Area / Programa Informático";
            this.btCentros.UseVisualStyleBackColor = true;
            this.btCentros.Click += new System.EventHandler(this.btCentros_Click);
            // 
            // btAccionesMark
            // 
            this.btAccionesMark.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btAccionesMark.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAccionesMark.Location = new System.Drawing.Point(113, 213);
            this.btAccionesMark.Name = "btAccionesMark";
            this.btAccionesMark.Size = new System.Drawing.Size(217, 29);
            this.btAccionesMark.TabIndex = 2;
            this.btAccionesMark.Text = " &2 - Acciones Marketing";
            this.btAccionesMark.UseVisualStyleBackColor = true;
            this.btAccionesMark.Click += new System.EventHandler(this.btAccionesMark_Click);
            // 
            // pnCentros
            // 
            this.pnCentros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnCentros.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnCentros.Controls.Add(this.panel3);
            this.pnCentros.Controls.Add(this.panel2);
            this.pnCentros.Controls.Add(this.panel1);
            this.pnCentros.Controls.Add(this.btEliminaCont);
            this.pnCentros.Controls.Add(this.btActualizaCont);
            this.pnCentros.Controls.Add(this.btEliminarCen);
            this.pnCentros.Controls.Add(this.btActualizarCen);
            this.pnCentros.Controls.Add(this.panel4);
            this.pnCentros.Location = new System.Drawing.Point(1, 244);
            this.pnCentros.Name = "pnCentros";
            this.pnCentros.Size = new System.Drawing.Size(1102, 299);
            this.pnCentros.TabIndex = 5;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.dgContactos);
            this.panel3.Controls.Add(this.lblTotContactos);
            this.panel3.Controls.Add(this.labelGradient2);
            this.panel3.Location = new System.Drawing.Point(4, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(468, 204);
            this.panel3.TabIndex = 0;
            // 
            // dgContactos
            // 
            this.dgContactos.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgContactos.CaptionText = "Personas de Contacto";
            this.dgContactos.CaptionVisible = false;
            this.dgContactos.DataMember = "";
            this.dgContactos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgContactos.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgContactos.Location = new System.Drawing.Point(0, 20);
            this.dgContactos.Name = "dgContactos";
            this.dgContactos.Size = new System.Drawing.Size(463, 180);
            this.dgContactos.TabIndex = 0;
            this.dgContactos.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            this.dgContactos.CurrentCellChanged += new System.EventHandler(this.dgContactos_CurrentCellChanged);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.DataGrid = this.dgContactos;
            this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn3,
            this.dataGridTextBoxColumn1,
            this.dataGridTextBoxColumn2});
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle1.MappingName = "ListaAreas_porCliente_SAP";
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.MappingName = "iIdCliente";
            this.dataGridTextBoxColumn3.ReadOnly = true;
            this.dataGridTextBoxColumn3.Width = 0;
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "Id. Area";
            this.dataGridTextBoxColumn1.MappingName = "iIdContacto";
            this.dataGridTextBoxColumn1.NullText = "";
            this.dataGridTextBoxColumn1.ReadOnly = true;
            this.dataGridTextBoxColumn1.Width = 75;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "Nombre Area";
            this.dataGridTextBoxColumn2.MappingName = "sNombre";
            this.dataGridTextBoxColumn2.NullText = "";
            this.dataGridTextBoxColumn2.Width = 200;
            // 
            // lblTotContactos
            // 
            this.lblTotContactos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.lblTotContactos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotContactos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotContactos.ForeColor = System.Drawing.Color.Black;
            this.lblTotContactos.Location = new System.Drawing.Point(403, 0);
            this.lblTotContactos.Name = "lblTotContactos";
            this.lblTotContactos.Size = new System.Drawing.Size(60, 18);
            this.lblTotContactos.TabIndex = 6;
            this.lblTotContactos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelGradient2
            // 
            this.labelGradient2.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelGradient2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGradient2.ForeColor = System.Drawing.Color.White;
            this.labelGradient2.GradientColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.labelGradient2.GradientColorTwo = System.Drawing.Color.White;
            this.labelGradient2.Location = new System.Drawing.Point(0, 0);
            this.labelGradient2.Name = "labelGradient2";
            this.labelGradient2.Size = new System.Drawing.Size(464, 20);
            this.labelGradient2.TabIndex = 0;
            this.labelGradient2.Text = "Areas";
            this.labelGradient2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.dgCentros);
            this.panel2.Controls.Add(this.lblTotCentros);
            this.panel2.Controls.Add(this.labelGradient1);
            this.panel2.Location = new System.Drawing.Point(480, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(444, 204);
            this.panel2.TabIndex = 4;
            // 
            // dgCentros
            // 
            this.dgCentros.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgCentros.CaptionText = "Programa Informático";
            this.dgCentros.CaptionVisible = false;
            this.dgCentros.DataMember = "";
            this.dgCentros.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgCentros.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgCentros.Location = new System.Drawing.Point(0, 20);
            this.dgCentros.Name = "dgCentros";
            this.dgCentros.Size = new System.Drawing.Size(440, 180);
            this.dgCentros.TabIndex = 4;
            this.dgCentros.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle3});
            this.dgCentros.CurrentCellChanged += new System.EventHandler(this.dgCentros_CurrentCellChanged);
            // 
            // dataGridTableStyle3
            // 
            this.dataGridTableStyle3.DataGrid = this.dgCentros;
            this.dataGridTableStyle3.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn7,
            this.dataGridTextBoxColumn22,
            this.dataGridTextBoxColumn8});
            this.dataGridTableStyle3.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle3.MappingName = "ListaProgInf_porCliente_SAP";
            // 
            // dataGridTextBoxColumn7
            // 
            this.dataGridTextBoxColumn7.Format = "";
            this.dataGridTextBoxColumn7.FormatInfo = null;
            this.dataGridTextBoxColumn7.HeaderText = "Id. Cliente";
            this.dataGridTextBoxColumn7.MappingName = "iIdCliente";
            this.dataGridTextBoxColumn7.ReadOnly = true;
            this.dataGridTextBoxColumn7.Width = 0;
            // 
            // dataGridTextBoxColumn22
            // 
            this.dataGridTextBoxColumn22.Format = "";
            this.dataGridTextBoxColumn22.FormatInfo = null;
            this.dataGridTextBoxColumn22.HeaderText = "Código";
            this.dataGridTextBoxColumn22.MappingName = "iIdCentro";
            this.dataGridTextBoxColumn22.NullText = "";
            this.dataGridTextBoxColumn22.ReadOnly = true;
            this.dataGridTextBoxColumn22.Width = 75;
            // 
            // dataGridTextBoxColumn8
            // 
            this.dataGridTextBoxColumn8.Format = "";
            this.dataGridTextBoxColumn8.FormatInfo = null;
            this.dataGridTextBoxColumn8.HeaderText = "Nombre Programa Informático";
            this.dataGridTextBoxColumn8.MappingName = "sNombre";
            this.dataGridTextBoxColumn8.NullText = "";
            this.dataGridTextBoxColumn8.ReadOnly = true;
            this.dataGridTextBoxColumn8.Width = 280;
            // 
            // lblTotCentros
            // 
            this.lblTotCentros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.lblTotCentros.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotCentros.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotCentros.ForeColor = System.Drawing.Color.Black;
            this.lblTotCentros.Location = new System.Drawing.Point(381, 0);
            this.lblTotCentros.Name = "lblTotCentros";
            this.lblTotCentros.Size = new System.Drawing.Size(60, 18);
            this.lblTotCentros.TabIndex = 4;
            this.lblTotCentros.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelGradient1
            // 
            this.labelGradient1.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelGradient1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGradient1.ForeColor = System.Drawing.Color.White;
            this.labelGradient1.GradientColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.labelGradient1.GradientColorTwo = System.Drawing.Color.White;
            this.labelGradient1.Location = new System.Drawing.Point(0, 0);
            this.labelGradient1.Name = "labelGradient1";
            this.labelGradient1.Size = new System.Drawing.Size(440, 20);
            this.labelGradient1.TabIndex = 0;
            this.labelGradient1.Text = "Programa Informático";
            this.labelGradient1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cbContCargo);
            this.panel1.Controls.Add(this.txtContNombre);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(8, 240);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(464, 52);
            this.panel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Area:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbContCargo
            // 
            this.cbContCargo.DataSource = this.dsClientes1.ListaTipoAreaCliSAP;
            this.cbContCargo.DisplayMember = "sLiteral";
            this.cbContCargo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbContCargo.Location = new System.Drawing.Point(8, 18);
            this.cbContCargo.Name = "cbContCargo";
            this.cbContCargo.Size = new System.Drawing.Size(445, 28);
            this.cbContCargo.TabIndex = 1;
            this.cbContCargo.ValueMember = "sValor";
            // 
            // txtContNombre
            // 
            this.txtContNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtContNombre.Location = new System.Drawing.Point(8, 20);
            this.txtContNombre.MaxLength = 100;
            this.txtContNombre.Name = "txtContNombre";
            this.txtContNombre.Size = new System.Drawing.Size(230, 26);
            this.txtContNombre.TabIndex = 0;
            this.txtContNombre.Visible = false;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nombre:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Visible = false;
            // 
            // btEliminaCont
            // 
            this.btEliminaCont.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btEliminaCont.Image = ((System.Drawing.Image)(resources.GetObject("btEliminaCont.Image")));
            this.btEliminaCont.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btEliminaCont.Location = new System.Drawing.Point(115, 209);
            this.btEliminaCont.Name = "btEliminaCont";
            this.btEliminaCont.Size = new System.Drawing.Size(92, 30);
            this.btEliminaCont.TabIndex = 2;
            this.btEliminaCont.Text = "&Eliminar";
            this.btEliminaCont.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.btEliminaCont, "Eliminar Contacto ALT+E");
            this.btEliminaCont.UseVisualStyleBackColor = true;
            this.btEliminaCont.Click += new System.EventHandler(this.btEliminaCont_Click);
            // 
            // btActualizaCont
            // 
            this.btActualizaCont.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btActualizaCont.Image = ((System.Drawing.Image)(resources.GetObject("btActualizaCont.Image")));
            this.btActualizaCont.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btActualizaCont.Location = new System.Drawing.Point(8, 209);
            this.btActualizaCont.Name = "btActualizaCont";
            this.btActualizaCont.Size = new System.Drawing.Size(104, 30);
            this.btActualizaCont.TabIndex = 1;
            this.btActualizaCont.Text = "&Actualizar";
            this.btActualizaCont.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.btActualizaCont, "Actualizar Contactos ALT+A");
            this.btActualizaCont.UseVisualStyleBackColor = true;
            this.btActualizaCont.Click += new System.EventHandler(this.btActualizaCont_Click);
            // 
            // btEliminarCen
            // 
            this.btEliminarCen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btEliminarCen.Image = ((System.Drawing.Image)(resources.GetObject("btEliminarCen.Image")));
            this.btEliminarCen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btEliminarCen.Location = new System.Drawing.Point(587, 209);
            this.btEliminarCen.Name = "btEliminarCen";
            this.btEliminarCen.Size = new System.Drawing.Size(92, 30);
            this.btEliminarCen.TabIndex = 6;
            this.btEliminarCen.Text = "E&liminar";
            this.btEliminarCen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.btEliminarCen, "Eliminar Centro ALT+E");
            this.btEliminarCen.UseVisualStyleBackColor = true;
            this.btEliminarCen.Click += new System.EventHandler(this.btEliminarCen_Click);
            // 
            // btActualizarCen
            // 
            this.btActualizarCen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btActualizarCen.Image = ((System.Drawing.Image)(resources.GetObject("btActualizarCen.Image")));
            this.btActualizarCen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btActualizarCen.Location = new System.Drawing.Point(480, 209);
            this.btActualizarCen.Name = "btActualizarCen";
            this.btActualizarCen.Size = new System.Drawing.Size(104, 30);
            this.btActualizarCen.TabIndex = 5;
            this.btActualizarCen.Text = "A&ctualizar";
            this.btActualizarCen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.btActualizarCen, "Actualizar Centros ALT+A");
            this.btActualizarCen.UseVisualStyleBackColor = true;
            this.btActualizarCen.Click += new System.EventHandler(this.btActualizarCen_Click);
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.cbProgInf);
            this.panel4.Controls.Add(this.txtCentroDesc);
            this.panel4.Controls.Add(this.txtCentrosId);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.btBuscarCentro);
            this.panel4.Location = new System.Drawing.Point(480, 240);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(444, 52);
            this.panel4.TabIndex = 7;
            // 
            // cbProgInf
            // 
            this.cbProgInf.DataSource = this.dsClientes1.ListaTipoProgInfCliSAP;
            this.cbProgInf.DisplayMember = "sLiteral";
            this.cbProgInf.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbProgInf.Location = new System.Drawing.Point(4, 20);
            this.cbProgInf.Name = "cbProgInf";
            this.cbProgInf.Size = new System.Drawing.Size(429, 28);
            this.cbProgInf.TabIndex = 12;
            this.cbProgInf.ValueMember = "sValor";
            // 
            // txtCentroDesc
            // 
            this.txtCentroDesc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtCentroDesc.Location = new System.Drawing.Point(124, 20);
            this.txtCentroDesc.MaxLength = 100;
            this.txtCentroDesc.Name = "txtCentroDesc";
            this.txtCentroDesc.ReadOnly = true;
            this.txtCentroDesc.Size = new System.Drawing.Size(288, 26);
            this.txtCentroDesc.TabIndex = 2;
            this.txtCentroDesc.Visible = false;
            // 
            // txtCentrosId
            // 
            this.txtCentrosId.Location = new System.Drawing.Point(4, 20);
            this.txtCentrosId.MaxLength = 20;
            this.txtCentrosId.Name = "txtCentrosId";
            this.txtCentrosId.Size = new System.Drawing.Size(120, 26);
            this.txtCentrosId.TabIndex = 0;
            this.txtCentrosId.Visible = false;
            this.txtCentrosId.Leave += new System.EventHandler(this.txtCentrosId_Leave);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(4, -1);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(429, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "Programa Informático:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btBuscarCentro
            // 
            this.btBuscarCentro.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btBuscarCentro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btBuscarCentro.Image = ((System.Drawing.Image)(resources.GetObject("btBuscarCentro.Image")));
            this.btBuscarCentro.Location = new System.Drawing.Point(412, 19);
            this.btBuscarCentro.Name = "btBuscarCentro";
            this.btBuscarCentro.Size = new System.Drawing.Size(21, 21);
            this.btBuscarCentro.TabIndex = 1;
            this.toolTip1.SetToolTip(this.btBuscarCentro, "Buscar Centro");
            this.btBuscarCentro.UseVisualStyleBackColor = true;
            this.btBuscarCentro.Visible = false;
            this.btBuscarCentro.Click += new System.EventHandler(this.btBuscarCentro_Click);
            // 
            // listaAreasporClienteSAPBindingSource
            // 
            this.listaAreasporClienteSAPBindingSource.DataMember = "ListaAreas_porCliente_SAP";
            this.listaAreasporClienteSAPBindingSource.DataSource = this.dsClientes1;
            // 
            // dataGridTextBoxColumn24
            // 
            this.dataGridTextBoxColumn24.Format = "";
            this.dataGridTextBoxColumn24.FormatInfo = null;
            this.dataGridTextBoxColumn24.MappingName = "bEnviadoCen";
            this.dataGridTextBoxColumn24.NullText = "";
            this.dataGridTextBoxColumn24.Width = 0;
            // 
            // pnAccionesMark
            // 
            this.pnAccionesMark.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnAccionesMark.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnAccionesMark.Controls.Add(this.panel6);
            this.pnAccionesMark.Controls.Add(this.btEliminarAcc);
            this.pnAccionesMark.Controls.Add(this.btActualizarAcc);
            this.pnAccionesMark.Controls.Add(this.panel5);
            this.pnAccionesMark.Location = new System.Drawing.Point(1, 558);
            this.pnAccionesMark.Name = "pnAccionesMark";
            this.pnAccionesMark.Size = new System.Drawing.Size(1102, 302);
            this.pnAccionesMark.TabIndex = 6;
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel6.Controls.Add(this.dgAccionesMark);
            this.panel6.Controls.Add(this.lblTotAcciones);
            this.panel6.Controls.Add(this.labelGradient3);
            this.panel6.Location = new System.Drawing.Point(4, 5);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(963, 198);
            this.panel6.TabIndex = 6;
            // 
            // dgAccionesMark
            // 
            this.dgAccionesMark.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgAccionesMark.CaptionText = "Acciones";
            this.dgAccionesMark.CaptionVisible = false;
            this.dgAccionesMark.DataMember = "";
            this.dgAccionesMark.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgAccionesMark.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgAccionesMark.Location = new System.Drawing.Point(0, 20);
            this.dgAccionesMark.Name = "dgAccionesMark";
            this.dgAccionesMark.Size = new System.Drawing.Size(958, 175);
            this.dgAccionesMark.TabIndex = 0;
            this.dgAccionesMark.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle4});
            this.dgAccionesMark.CurrentCellChanged += new System.EventHandler(this.dgAccionesMark_CurrentCellChanged);
            // 
            // dataGridTableStyle4
            // 
            this.dataGridTableStyle4.DataGrid = this.dgAccionesMark;
            this.dataGridTableStyle4.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn6,
            this.dataGridTextBoxColumn19,
            this.dataGridTextBoxColumn20,
            this.dataGridTextBoxColumn21,
            this.dataGridTextBoxColumn23,
            this.dataGridTextBoxColumn24});
            this.dataGridTableStyle4.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle4.MappingName = "ListaAccionesMarkClientes";
            // 
            // dataGridTextBoxColumn6
            // 
            this.dataGridTextBoxColumn6.Format = "";
            this.dataGridTextBoxColumn6.FormatInfo = null;
            this.dataGridTextBoxColumn6.HeaderText = "Cód.Accion";
            this.dataGridTextBoxColumn6.MappingName = "sIdAccion";
            this.dataGridTextBoxColumn6.NullText = "";
            this.dataGridTextBoxColumn6.Width = 250;
            // 
            // dataGridTextBoxColumn19
            // 
            this.dataGridTextBoxColumn19.Format = "dd/MM/yyyy";
            this.dataGridTextBoxColumn19.FormatInfo = null;
            this.dataGridTextBoxColumn19.HeaderText = "F.Entrega";
            this.dataGridTextBoxColumn19.MappingName = "dFechaEntrega";
            this.dataGridTextBoxColumn19.NullText = "";
            this.dataGridTextBoxColumn19.Width = 75;
            // 
            // dataGridTextBoxColumn20
            // 
            this.dataGridTextBoxColumn20.Format = "";
            this.dataGridTextBoxColumn20.FormatInfo = null;
            this.dataGridTextBoxColumn20.HeaderText = "Cantidad";
            this.dataGridTextBoxColumn20.MappingName = "fCantidad";
            this.dataGridTextBoxColumn20.NullText = "";
            this.dataGridTextBoxColumn20.Width = 75;
            // 
            // dataGridTextBoxColumn21
            // 
            this.dataGridTextBoxColumn21.Format = "";
            this.dataGridTextBoxColumn21.FormatInfo = null;
            this.dataGridTextBoxColumn21.HeaderText = "Observaciones Entrega";
            this.dataGridTextBoxColumn21.MappingName = "tObservEntrega";
            this.dataGridTextBoxColumn21.NullText = "";
            this.dataGridTextBoxColumn21.Width = 470;
            // 
            // dataGridTextBoxColumn23
            // 
            this.dataGridTextBoxColumn23.Format = "";
            this.dataGridTextBoxColumn23.FormatInfo = null;
            this.dataGridTextBoxColumn23.MappingName = "iIdAccion";
            this.dataGridTextBoxColumn23.NullText = "";
            this.dataGridTextBoxColumn23.Width = 0;
            // 
            // lblTotAcciones
            // 
            this.lblTotAcciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.lblTotAcciones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotAcciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotAcciones.ForeColor = System.Drawing.Color.Black;
            this.lblTotAcciones.Location = new System.Drawing.Point(898, 0);
            this.lblTotAcciones.Name = "lblTotAcciones";
            this.lblTotAcciones.Size = new System.Drawing.Size(60, 18);
            this.lblTotAcciones.TabIndex = 5;
            this.lblTotAcciones.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelGradient3
            // 
            this.labelGradient3.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelGradient3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGradient3.ForeColor = System.Drawing.Color.White;
            this.labelGradient3.GradientColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.labelGradient3.GradientColorTwo = System.Drawing.Color.White;
            this.labelGradient3.Location = new System.Drawing.Point(0, 0);
            this.labelGradient3.Name = "labelGradient3";
            this.labelGradient3.Size = new System.Drawing.Size(959, 20);
            this.labelGradient3.TabIndex = 0;
            this.labelGradient3.Text = "Acciones";
            this.labelGradient3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btEliminarAcc
            // 
            this.btEliminarAcc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btEliminarAcc.Image = ((System.Drawing.Image)(resources.GetObject("btEliminarAcc.Image")));
            this.btEliminarAcc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btEliminarAcc.Location = new System.Drawing.Point(113, 202);
            this.btEliminarAcc.Name = "btEliminarAcc";
            this.btEliminarAcc.Size = new System.Drawing.Size(92, 30);
            this.btEliminarAcc.TabIndex = 2;
            this.btEliminarAcc.Text = "&Eliminar";
            this.btEliminarAcc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.btEliminarAcc, "Eliminar Acción ALT+E");
            this.btEliminarAcc.UseVisualStyleBackColor = true;
            this.btEliminarAcc.Click += new System.EventHandler(this.btEliminarAcc_Click);
            // 
            // btActualizarAcc
            // 
            this.btActualizarAcc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btActualizarAcc.Image = ((System.Drawing.Image)(resources.GetObject("btActualizarAcc.Image")));
            this.btActualizarAcc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btActualizarAcc.Location = new System.Drawing.Point(4, 202);
            this.btActualizarAcc.Name = "btActualizarAcc";
            this.btActualizarAcc.Size = new System.Drawing.Size(104, 30);
            this.btActualizarAcc.TabIndex = 1;
            this.btActualizarAcc.Text = "&Actualizar";
            this.btActualizarAcc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.btActualizarAcc, "Actualizar Acción ALT+A");
            this.btActualizarAcc.UseVisualStyleBackColor = true;
            this.btActualizarAcc.Click += new System.EventHandler(this.btActualizarAcc_Click);
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel5.Controls.Add(this.btBuscaAccion);
            this.panel5.Controls.Add(this.txtAccObservEntrega);
            this.panel5.Controls.Add(this.nupAccCantidad);
            this.panel5.Controls.Add(this.dtpAccFEntrega);
            this.panel5.Controls.Add(this.txtAccsIdAccion);
            this.panel5.Controls.Add(this.label17);
            this.panel5.Controls.Add(this.label16);
            this.panel5.Controls.Add(this.label15);
            this.panel5.Controls.Add(this.label14);
            this.panel5.Location = new System.Drawing.Point(4, 233);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1078, 64);
            this.panel5.TabIndex = 3;
            // 
            // btBuscaAccion
            // 
            this.btBuscaAccion.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btBuscaAccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btBuscaAccion.Image = ((System.Drawing.Image)(resources.GetObject("btBuscaAccion.Image")));
            this.btBuscaAccion.Location = new System.Drawing.Point(239, 20);
            this.btBuscaAccion.Name = "btBuscaAccion";
            this.btBuscaAccion.Size = new System.Drawing.Size(26, 27);
            this.btBuscaAccion.TabIndex = 1;
            this.toolTip1.SetToolTip(this.btBuscaAccion, "Buscar Acción");
            this.btBuscaAccion.UseVisualStyleBackColor = true;
            this.btBuscaAccion.Click += new System.EventHandler(this.btBuscaAccion_Click);
            // 
            // txtAccObservEntrega
            // 
            this.txtAccObservEntrega.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccObservEntrega.Location = new System.Drawing.Point(642, 20);
            this.txtAccObservEntrega.MaxLength = 8000;
            this.txtAccObservEntrega.Multiline = true;
            this.txtAccObservEntrega.Name = "txtAccObservEntrega";
            this.txtAccObservEntrega.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAccObservEntrega.Size = new System.Drawing.Size(425, 40);
            this.txtAccObservEntrega.TabIndex = 4;
            // 
            // nupAccCantidad
            // 
            this.nupAccCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nupAccCantidad.Location = new System.Drawing.Point(563, 20);
            this.nupAccCantidad.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nupAccCantidad.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nupAccCantidad.Name = "nupAccCantidad";
            this.nupAccCantidad.Size = new System.Drawing.Size(67, 26);
            this.nupAccCantidad.TabIndex = 3;
            this.nupAccCantidad.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // dtpAccFEntrega
            // 
            this.dtpAccFEntrega.Enabled = false;
            this.dtpAccFEntrega.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpAccFEntrega.Location = new System.Drawing.Point(272, 20);
            this.dtpAccFEntrega.Name = "dtpAccFEntrega";
            this.dtpAccFEntrega.Size = new System.Drawing.Size(283, 26);
            this.dtpAccFEntrega.TabIndex = 2;
            this.dtpAccFEntrega.ValueChanged += new System.EventHandler(this.dtpAccFEntrega_ValueChanged);
            // 
            // txtAccsIdAccion
            // 
            this.txtAccsIdAccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccsIdAccion.Location = new System.Drawing.Point(4, 20);
            this.txtAccsIdAccion.MaxLength = 50;
            this.txtAccsIdAccion.Name = "txtAccsIdAccion";
            this.txtAccsIdAccion.Size = new System.Drawing.Size(233, 26);
            this.txtAccsIdAccion.TabIndex = 0;
            this.txtAccsIdAccion.Leave += new System.EventHandler(this.txtAccsIdAccion_Leave);
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(640, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(228, 18);
            this.label17.TabIndex = 7;
            this.label17.Text = "Observaciones de la Entrega:";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(273, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(128, 20);
            this.label16.TabIndex = 6;
            this.label16.Text = "Fecha Entrega:";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(560, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(77, 18);
            this.label15.TabIndex = 5;
            this.label15.Text = "Cantidad:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(100, 18);
            this.label14.TabIndex = 4;
            this.label14.Text = "Acción:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // contextMenu1
            // 
            this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuNuevo,
            this.menuEliminar});
            // 
            // menuNuevo
            // 
            this.menuNuevo.Index = 0;
            this.menuNuevo.Shortcut = System.Windows.Forms.Shortcut.CtrlN;
            this.menuNuevo.Text = "Nuevo";
            this.menuNuevo.Click += new System.EventHandler(this.menuNuevo_Click);
            // 
            // menuEliminar
            // 
            this.menuEliminar.Index = 1;
            this.menuEliminar.Shortcut = System.Windows.Forms.Shortcut.CtrlX;
            this.menuEliminar.Text = "Eliminar";
            this.menuEliminar.Click += new System.EventHandler(this.menuEliminar_Click);
            // 
            // sqldaListaCentros_porCliente_SAP
            // 
            this.sqldaListaCentros_porCliente_SAP.SelectCommand = this.sqlSelectCommand2;
            this.sqldaListaCentros_porCliente_SAP.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaCentros_porCliente_SAP", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iIdCentro", "iIdCentro"),
                        new System.Data.Common.DataColumnMapping("sIdCentro", "sIdCentro"),
                        new System.Data.Common.DataColumnMapping("sDescripcion", "sDescripcion")})});
            // 
            // sqlSelectCommand2
            // 
            this.sqlSelectCommand2.CommandText = "[ListaCentros_porCliente_SAP]";
            this.sqlSelectCommand2.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand2.Connection = this.sqlConn;
            this.sqlSelectCommand2.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4)});
            // 
            // sqldaListaAccionesMarkCli
            // 
            this.sqldaListaAccionesMarkCli.SelectCommand = this.sqlSelectCommand6;
            this.sqldaListaAccionesMarkCli.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaAccionesMarkClientes", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iIdAccion", "iIdAccion"),
                        new System.Data.Common.DataColumnMapping("sIdAccion", "sIdAccion"),
                        new System.Data.Common.DataColumnMapping("dFechaEntrega", "dFechaEntrega"),
                        new System.Data.Common.DataColumnMapping("tFechaEntrega", "tFechaEntrega"),
                        new System.Data.Common.DataColumnMapping("fCantidad", "fCantidad"),
                        new System.Data.Common.DataColumnMapping("sCCoste", "sCCoste"),
                        new System.Data.Common.DataColumnMapping("tObservEntrega", "tObservEntrega")})});
            // 
            // sqlSelectCommand6
            // 
            this.sqlSelectCommand6.CommandText = "[ListaAccionesMarkClientes]";
            this.sqlSelectCommand6.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand6.Connection = this.sqlConn;
            this.sqlSelectCommand6.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4)});
            // 
            // sqldaGetCliente_SAP
            // 
            this.sqldaGetCliente_SAP.SelectCommand = this.sqlSelectCommand1;
            this.sqldaGetCliente_SAP.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "GetCliente_SAP", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iIdCliente", "iIdCliente"),
                        new System.Data.Common.DataColumnMapping("sIdCliente", "sIdCliente"),
                        new System.Data.Common.DataColumnMapping("sTipoCliente", "sTipoCliente"),
                        new System.Data.Common.DataColumnMapping("tTipoCliente", "tTipoCliente"),
                        new System.Data.Common.DataColumnMapping("sIdTipoClasificacion", "sIdTipoClasificacion"),
                        new System.Data.Common.DataColumnMapping("tTipoClasificacion", "tTipoClasificacion"),
                        new System.Data.Common.DataColumnMapping("sNombre", "sNombre"),
                        new System.Data.Common.DataColumnMapping("sApellidos", "sApellidos"),
                        new System.Data.Common.DataColumnMapping("tNombre", "tNombre"),
                        new System.Data.Common.DataColumnMapping("sTelefono", "sTelefono"),
                        new System.Data.Common.DataColumnMapping("cTipoCli", "cTipoCli"),
                        new System.Data.Common.DataColumnMapping("tTipoCli", "tTipoCli"),
                        new System.Data.Common.DataColumnMapping("iIdPoblacion", "iIdPoblacion"),
                        new System.Data.Common.DataColumnMapping("CodPostal", "CodPostal"),
                        new System.Data.Common.DataColumnMapping("sPoblacion", "sPoblacion"),
                        new System.Data.Common.DataColumnMapping("iIdProvincia", "iIdProvincia"),
                        new System.Data.Common.DataColumnMapping("sProvincia", "sProvincia"),
                        new System.Data.Common.DataColumnMapping("sNIF_SAP", "sNIF_SAP"),
                        new System.Data.Common.DataColumnMapping("sDatosBancarios_SAP", "sDatosBancarios_SAP"),
                        new System.Data.Common.DataColumnMapping("sDireccion_SAP", "sDireccion_SAP"),
                        new System.Data.Common.DataColumnMapping("sRegion_SAP", "sRegion_SAP"),
                        new System.Data.Common.DataColumnMapping("sTeles_SAP", "sTeles_SAP"),
                        new System.Data.Common.DataColumnMapping("sTelefono2_SAP", "sTelefono2_SAP"),
                        new System.Data.Common.DataColumnMapping("sTelefax_SAP", "sTelefax_SAP"),
                        new System.Data.Common.DataColumnMapping("sCodPago_SAP", "sCodPago_SAP"),
                        new System.Data.Common.DataColumnMapping("tCodPago_SAP", "tCodPago_SAP"),
                        new System.Data.Common.DataColumnMapping("sZonaCliente_SAP", "sZonaCliente_SAP"),
                        new System.Data.Common.DataColumnMapping("sOficinaVentas_SAP", "sOficinaVentas_SAP"),
                        new System.Data.Common.DataColumnMapping("sGrupoVendedores_SAP", "sGrupoVendedores_SAP"),
                        new System.Data.Common.DataColumnMapping("sGrupoClientes_SAP", "sGrupoClientes_SAP"),
                        new System.Data.Common.DataColumnMapping("sMoneda_SAP", "sMoneda_SAP"),
                        new System.Data.Common.DataColumnMapping("sCondExp_SAP", "sCondExp_SAP"),
                        new System.Data.Common.DataColumnMapping("sCentroSuministro_SAP", "sCentroSuministro_SAP"),
                        new System.Data.Common.DataColumnMapping("sIncoterms1_SAP", "sIncoterms1_SAP"),
                        new System.Data.Common.DataColumnMapping("sIncoterms2_SAP", "sIncoterms2_SAP"),
                        new System.Data.Common.DataColumnMapping("sAreaControlCred_SAP", "sAreaControlCred_SAP"),
                        new System.Data.Common.DataColumnMapping("sGarantias_SAP", "sGarantias_SAP"),
                        new System.Data.Common.DataColumnMapping("sEncComercial_SAP", "sEncComercial_SAP"),
                        new System.Data.Common.DataColumnMapping("sRespPedido_SAP", "sRespPedido_SAP"),
                        new System.Data.Common.DataColumnMapping("sCiaTransporte_SAP", "sCiaTransporte_SAP"),
                        new System.Data.Common.DataColumnMapping("fDescuento_SAP", "fDescuento_SAP"),
                        new System.Data.Common.DataColumnMapping("fBonificacion_SAP", "fBonificacion_SAP"),
                        new System.Data.Common.DataColumnMapping("sTR_SAP", "sTR_SAP"),
                        new System.Data.Common.DataColumnMapping("bPotencial_SAP", "bPotencial_SAP"),
                        new System.Data.Common.DataColumnMapping("xPotencial_SAP", "xPotencial_SAP"),
                        new System.Data.Common.DataColumnMapping("iEstado", "iEstado"),
                        new System.Data.Common.DataColumnMapping("bEnviadoCEN", "bEnviadoCEN"),
                        new System.Data.Common.DataColumnMapping("sGarantias_SAP_1", "sGarantias_SAP_1"),
                        new System.Data.Common.DataColumnMapping("sGarantias_SAP_2", "sGarantias_SAP_2"),
                        new System.Data.Common.DataColumnMapping("sGarantias_SAP_3", "sGarantias_SAP_3"),
                        new System.Data.Common.DataColumnMapping("sGarantias_SAP_4", "sGarantias_SAP_4")})});
            // 
            // sqlSelectCommand1
            // 
            this.sqlSelectCommand1.CommandText = "[GetCliente_SAP]";
            this.sqlSelectCommand1.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand1.Connection = this.sqlConn;
            this.sqlSelectCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4)});
            // 
            // sqlCmdSetAccionesMarkClientes
            // 
            this.sqlCmdSetAccionesMarkClientes.CommandText = "[SetAccionesMarkClientes]";
            this.sqlCmdSetAccionesMarkClientes.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdSetAccionesMarkClientes.Connection = this.sqlConn;
            this.sqlCmdSetAccionesMarkClientes.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdAccion", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@dFechaEntrega", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@fCantidad", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@tObservaciones", System.Data.SqlDbType.VarChar, 8000),
            new System.Data.SqlClient.SqlParameter("@sCoste", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@dFUM", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@bEnviadoCen", System.Data.SqlDbType.Bit, 1),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt, 2)});
            // 
            // sqldaListaContactosporCliente_SAP
            // 
            this.sqldaListaContactosporCliente_SAP.SelectCommand = this.sqlSelectCommand3;
            this.sqldaListaContactosporCliente_SAP.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaContactos_porCliente_SAP", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iIdContacto", "iIdContacto"),
                        new System.Data.Common.DataColumnMapping("sNombre", "sNombre"),
                        new System.Data.Common.DataColumnMapping("sIdCargoContacto", "sIdCargoContacto"),
                        new System.Data.Common.DataColumnMapping("tIdCargoContacto", "tIdCargoContacto")})});
            // 
            // sqlSelectCommand3
            // 
            this.sqlSelectCommand3.CommandText = "[ListaContactos_porCliente_SAP]";
            this.sqlSelectCommand3.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand3.Connection = this.sqlConn;
            this.sqlSelectCommand3.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4)});
            // 
            // sqldaListaTipoCtoClienteSAP
            // 
            this.sqldaListaTipoCtoClienteSAP.SelectCommand = this.sqlSelectListaTipoCtoClienteSAP;
            this.sqldaListaTipoCtoClienteSAP.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaTipoCargoCtoCliSAP", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("sValor", "sValor"),
                        new System.Data.Common.DataColumnMapping("sLiteral", "sLiteral")})});
            // 
            // sqlSelectListaTipoCtoClienteSAP
            // 
            this.sqlSelectListaTipoCtoClienteSAP.CommandText = "[ListaTipoCargoCtoCliSAP]";
            this.sqlSelectListaTipoCtoClienteSAP.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectListaTipoCtoClienteSAP.Connection = this.sqlConn;
            this.sqlSelectListaTipoCtoClienteSAP.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null)});
            // 
            // sqldaListaAreasporCliente_SAP
            // 
            this.sqldaListaAreasporCliente_SAP.SelectCommand = this.sqlSelectCommandListaAreasporCliente_SAP;
            this.sqldaListaAreasporCliente_SAP.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaAreas_porCliente_SAP", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iIdContacto", "iIdContacto"),
                        new System.Data.Common.DataColumnMapping("sNombre", "sNombre"),
                        new System.Data.Common.DataColumnMapping("sIdCargoContacto", "sIdCargoContacto"),
                        new System.Data.Common.DataColumnMapping("tIdCargoContacto", "tIdCargoContacto")})});
            // 
            // sqlSelectCommandListaAreasporCliente_SAP
            // 
            this.sqlSelectCommandListaAreasporCliente_SAP.CommandText = "[ListaAreas_porCliente_SAP]";
            this.sqlSelectCommandListaAreasporCliente_SAP.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommandListaAreasporCliente_SAP.Connection = this.sqlConn;
            this.sqlSelectCommandListaAreasporCliente_SAP.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4)});
            // 
            // sqldaListaTipoAreasClienteSAP
            // 
            this.sqldaListaTipoAreasClienteSAP.SelectCommand = this.sqlSelectCommandTipoAreasClienteSAP;
            this.sqldaListaTipoAreasClienteSAP.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaTipoAreaCliSAP", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("sValor", "sValor"),
                        new System.Data.Common.DataColumnMapping("sLiteral", "sLiteral")})});
            // 
            // sqlSelectCommandTipoAreasClienteSAP
            // 
            this.sqlSelectCommandTipoAreasClienteSAP.CommandText = "[ListaTipoAreaCliSAP]";
            this.sqlSelectCommandTipoAreasClienteSAP.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommandTipoAreasClienteSAP.Connection = this.sqlConn;
            this.sqlSelectCommandTipoAreasClienteSAP.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null)});
            // 
            // sqldaListaProgInfCliente_SAP
            // 
            this.sqldaListaProgInfCliente_SAP.SelectCommand = this.sqlSelectCommandListaProgInfporCliente_SAP;
            this.sqldaListaProgInfCliente_SAP.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaProgInf_porCliente_SAP", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iIdCliente", "iIdCliente"),
                        new System.Data.Common.DataColumnMapping("iIdCentro", "iIdCentro"),
                        new System.Data.Common.DataColumnMapping("sNombre", "sNombre")})});
            // 
            // sqlSelectCommandListaProgInfporCliente_SAP
            // 
            this.sqlSelectCommandListaProgInfporCliente_SAP.CommandText = "[ListaProgInf_porCliente_SAP]";
            this.sqlSelectCommandListaProgInfporCliente_SAP.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommandListaProgInfporCliente_SAP.Connection = this.sqlConn;
            this.sqlSelectCommandListaProgInfporCliente_SAP.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4)});
            // 
            // sqldaListaTipoProgInfClienteSAP
            // 
            this.sqldaListaTipoProgInfClienteSAP.SelectCommand = this.sqlSelectCommandTipoProgInfClienteSAP;
            this.sqldaListaTipoProgInfClienteSAP.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaTipoProgInfCliSAP", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("sValor", "sValor"),
                        new System.Data.Common.DataColumnMapping("sLiteral", "sLiteral")})});
            // 
            // sqlSelectCommandTipoProgInfClienteSAP
            // 
            this.sqlSelectCommandTipoProgInfClienteSAP.CommandText = "[ListaTipoProgInfCliSAP]";
            this.sqlSelectCommandTipoProgInfClienteSAP.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommandTipoProgInfClienteSAP.Connection = this.sqlConn;
            this.sqlSelectCommandTipoProgInfClienteSAP.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null)});
            // 
            // sqlCmdSetCentrosClienteSAP
            // 
            this.sqlCmdSetCentrosClienteSAP.CommandText = "[SetCentrosClienteSAP]";
            this.sqlCmdSetCentrosClienteSAP.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdSetCentrosClienteSAP.Connection = this.sqlConn;
            this.sqlCmdSetCentrosClienteSAP.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iAccion", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdCentro", System.Data.SqlDbType.Int, 4)});
            // 
            // sqlCmdSetAreasClientesSAP
            // 
            this.sqlCmdSetAreasClientesSAP.CommandText = "[SetAreasClientesSAP]";
            this.sqlCmdSetAreasClientesSAP.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdSetAreasClientesSAP.Connection = this.sqlConn;
            this.sqlCmdSetAreasClientesSAP.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdContacto", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sNombre", System.Data.SqlDbType.VarChar, 100),
            new System.Data.SqlClient.SqlParameter("@sIdCargoContacto", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@dFAR", System.Data.SqlDbType.VarChar, 20),
            new System.Data.SqlClient.SqlParameter("@dFBR", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt, 2)});
            // 
            // sqlCmdSetProgInfClientesSAP
            // 
            this.sqlCmdSetProgInfClientesSAP.CommandText = "[SetProgInfClientesSAP]";
            this.sqlCmdSetProgInfClientesSAP.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdSetProgInfClientesSAP.Connection = this.sqlConn;
            this.sqlCmdSetProgInfClientesSAP.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdCentro", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@dFAR", System.Data.SqlDbType.VarChar, 20),
            new System.Data.SqlClient.SqlParameter("@dFBR", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt, 2)});
            // 
            // sqlCmdSetContactosClientesSAP
            // 
            this.sqlCmdSetContactosClientesSAP.CommandText = "[SetContactosClientesSAP]";
            this.sqlCmdSetContactosClientesSAP.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdSetContactosClientesSAP.Connection = this.sqlConn;
            this.sqlCmdSetContactosClientesSAP.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdContacto", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sNombre", System.Data.SqlDbType.VarChar, 100),
            new System.Data.SqlClient.SqlParameter("@sIdCargoContacto", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@dFAR", System.Data.SqlDbType.VarChar, 20),
            new System.Data.SqlClient.SqlParameter("@dFBR", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt, 2)});
            // 
            // ucBotoneraSecundaria1
            // 
            this.ucBotoneraSecundaria1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(117)))), ((int)(((byte)(1)))));
            this.ucBotoneraSecundaria1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucBotoneraSecundaria1.ForeColor = System.Drawing.Color.Black;
            this.ucBotoneraSecundaria1.Location = new System.Drawing.Point(0, 0);
            this.ucBotoneraSecundaria1.Name = "ucBotoneraSecundaria1";
            this.ucBotoneraSecundaria1.Size = new System.Drawing.Size(1196, 38);
            this.ucBotoneraSecundaria1.TabIndex = 1;
            // 
            // btCRM
            // 
            this.btCRM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btCRM.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCRM.Location = new System.Drawing.Point(8, 213);
            this.btCRM.Name = "btCRM";
            this.btCRM.Size = new System.Drawing.Size(105, 29);
            this.btCRM.TabIndex = 1;
            this.btCRM.Text = "&1 - CRM";
            this.btCRM.UseVisualStyleBackColor = true;
            this.btCRM.Click += new System.EventHandler(this.btCRM_Click);
            // 
            // pnCRM
            // 
            this.pnCRM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnCRM.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnCRM.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnCRM.Location = new System.Drawing.Point(1, 861);
            this.pnCRM.Name = "pnCRM";
            this.pnCRM.Size = new System.Drawing.Size(1102, 296);
            this.pnCRM.TabIndex = 7;
            // 
            // ucUltimasVisitas1
            // 
            this.ucUltimasVisitas1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ucUltimasVisitas1.ForeColor = System.Drawing.Color.Black;
            this.ucUltimasVisitas1.Location = new System.Drawing.Point(528, 152);
            this.ucUltimasVisitas1.Name = "ucUltimasVisitas1";
            this.ucUltimasVisitas1.Size = new System.Drawing.Size(400, 135);
            this.ucUltimasVisitas1.TabIndex = 2;
            // 
            // ucRankingMatCli1
            // 
            this.ucRankingMatCli1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ucRankingMatCli1.ForeColor = System.Drawing.Color.Black;
            this.ucRankingMatCli1.Location = new System.Drawing.Point(528, 2);
            this.ucRankingMatCli1.Name = "ucRankingMatCli1";
            this.ucRankingMatCli1.Size = new System.Drawing.Size(400, 145);
            this.ucRankingMatCli1.TabIndex = 1;
            // 
            // ucUltimoPedido1
            // 
            this.ucUltimoPedido1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ucUltimoPedido1.Location = new System.Drawing.Point(7, 2);
            this.ucUltimoPedido1.Name = "ucUltimoPedido1";
            this.ucUltimoPedido1.Size = new System.Drawing.Size(509, 250);
            this.ucUltimoPedido1.TabIndex = 0;
            // 
            // btMayoristas
            // 
            this.btMayoristas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btMayoristas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btMayoristas.Location = new System.Drawing.Point(331, 213);
            this.btMayoristas.Name = "btMayoristas";
            this.btMayoristas.Size = new System.Drawing.Size(175, 29);
            this.btMayoristas.TabIndex = 3;
            this.btMayoristas.Text = "&3 - Interlocutores";
            this.btMayoristas.UseVisualStyleBackColor = true;
            this.btMayoristas.Click += new System.EventHandler(this.btMayoristas_Click);
            // 
            // pnMayoristas
            // 
            this.pnMayoristas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnMayoristas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnMayoristas.Controls.Add(this.panel7);
            this.pnMayoristas.Location = new System.Drawing.Point(1, 1166);
            this.pnMayoristas.Name = "pnMayoristas";
            this.pnMayoristas.Size = new System.Drawing.Size(1102, 296);
            this.pnMayoristas.TabIndex = 8;
            // 
            // panel7
            // 
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel7.Controls.Add(this.lblTotMayoristas);
            this.panel7.Controls.Add(this.dgMayoristas);
            this.panel7.Controls.Add(this.labelGradient4);
            this.panel7.Location = new System.Drawing.Point(4, 4);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1090, 287);
            this.panel7.TabIndex = 0;
            // 
            // lblTotMayoristas
            // 
            this.lblTotMayoristas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.lblTotMayoristas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotMayoristas.Location = new System.Drawing.Point(1027, 1);
            this.lblTotMayoristas.Name = "lblTotMayoristas";
            this.lblTotMayoristas.Size = new System.Drawing.Size(60, 18);
            this.lblTotMayoristas.TabIndex = 2;
            this.lblTotMayoristas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgMayoristas
            // 
            this.dgMayoristas.CaptionVisible = false;
            this.dgMayoristas.DataMember = "ListaMayoristasClientes_SAP";
            this.dgMayoristas.DataSource = this.dsClientes1;
            this.dgMayoristas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgMayoristas.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgMayoristas.Location = new System.Drawing.Point(0, 20);
            this.dgMayoristas.Name = "dgMayoristas";
            this.dgMayoristas.ReadOnly = true;
            this.dgMayoristas.RowHeaderWidth = 17;
            this.dgMayoristas.Size = new System.Drawing.Size(1087, 263);
            this.dgMayoristas.TabIndex = 1;
            this.dgMayoristas.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle2});
            this.dgMayoristas.Paint += new System.Windows.Forms.PaintEventHandler(this.dgMayoristas_Paint);
            // 
            // dataGridTableStyle2
            // 
            this.dataGridTableStyle2.DataGrid = this.dgMayoristas;
            this.dataGridTableStyle2.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn10,
            this.dataGridTextBoxColumn4,
            this.dataGridTextBoxColumn5,
            this.dataGridTextBoxColumn9});
            this.dataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle2.MappingName = "ListaMayoristasClientes_SAP";
            this.dataGridTableStyle2.RowHeaderWidth = 17;
            // 
            // dataGridTextBoxColumn10
            // 
            this.dataGridTextBoxColumn10.Format = "";
            this.dataGridTextBoxColumn10.FormatInfo = null;
            this.dataGridTextBoxColumn10.HeaderText = "Tipo";
            this.dataGridTextBoxColumn10.MappingName = "tInterlocutor";
            this.dataGridTextBoxColumn10.NullText = "";
            this.dataGridTextBoxColumn10.Width = 75;
            // 
            // dataGridTextBoxColumn4
            // 
            this.dataGridTextBoxColumn4.Format = "";
            this.dataGridTextBoxColumn4.FormatInfo = null;
            this.dataGridTextBoxColumn4.HeaderText = "Código Interlocutor";
            this.dataGridTextBoxColumn4.MappingName = "sIdCliente";
            this.dataGridTextBoxColumn4.NullText = "";
            this.dataGridTextBoxColumn4.Width = 180;
            // 
            // dataGridTextBoxColumn5
            // 
            this.dataGridTextBoxColumn5.Format = "";
            this.dataGridTextBoxColumn5.FormatInfo = null;
            this.dataGridTextBoxColumn5.HeaderText = "Nombre Interlocutor";
            this.dataGridTextBoxColumn5.MappingName = "sNombre";
            this.dataGridTextBoxColumn5.NullText = "";
            this.dataGridTextBoxColumn5.Width = 500;
            // 
            // dataGridTextBoxColumn9
            // 
            this.dataGridTextBoxColumn9.Format = "";
            this.dataGridTextBoxColumn9.FormatInfo = null;
            this.dataGridTextBoxColumn9.HeaderText = "Cód.Cliente del Interlocutor";
            this.dataGridTextBoxColumn9.MappingName = "sIdCodClientedelMay";
            this.dataGridTextBoxColumn9.NullText = "";
            this.dataGridTextBoxColumn9.Width = 260;
            // 
            // labelGradient4
            // 
            this.labelGradient4.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelGradient4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGradient4.ForeColor = System.Drawing.Color.White;
            this.labelGradient4.GradientColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.labelGradient4.GradientColorTwo = System.Drawing.Color.White;
            this.labelGradient4.Location = new System.Drawing.Point(0, 0);
            this.labelGradient4.Name = "labelGradient4";
            this.labelGradient4.Size = new System.Drawing.Size(1086, 20);
            this.labelGradient4.TabIndex = 0;
            this.labelGradient4.Text = "Interlocutores Asociados";
            this.labelGradient4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sqldaListaMayoristasClientes_SAP
            // 
            this.sqldaListaMayoristasClientes_SAP.SelectCommand = this.sqlSelectCommand5;
            this.sqldaListaMayoristasClientes_SAP.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaMayoristasClientes_SAP", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("sGrupoClientes", "sGrupoClientes"),
                        new System.Data.Common.DataColumnMapping("tInterlocutor", "tInterlocutor"),
                        new System.Data.Common.DataColumnMapping("iIdClienteMayorista", "iIdClienteMayorista"),
                        new System.Data.Common.DataColumnMapping("sIdCliente", "sIdCliente"),
                        new System.Data.Common.DataColumnMapping("sNombre", "sNombre"),
                        new System.Data.Common.DataColumnMapping("sIdCodClientedelMay", "sIdCodClientedelMay")})});
            // 
            // sqlSelectCommand5
            // 
            this.sqlSelectCommand5.CommandText = "[ListaMayoristasClientes_SAP]";
            this.sqlSelectCommand5.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand5.Connection = this.sqlConn;
            this.sqlSelectCommand5.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4)});
            // 
            // sqldaListaTipoClasificacion
            // 
            this.sqldaListaTipoClasificacion.SelectCommand = this.sqlSelectCommand7;
            this.sqldaListaTipoClasificacion.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaTipoClasificacion", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("sValor", "sValor"),
                        new System.Data.Common.DataColumnMapping("sLiteral", "sLiteral")})});
            // 
            // sqlSelectCommand7
            // 
            this.sqlSelectCommand7.CommandText = "[ListaTipoClasificacion]";
            this.sqlSelectCommand7.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand7.Connection = this.sqlConn;
            this.sqlSelectCommand7.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null)});
            // 
            // sqlCmdSetClienteRed
            // 
            this.sqlCmdSetClienteRed.CommandText = "[SetClienteRed]";
            this.sqlCmdSetClienteRed.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdSetClienteRed.Connection = this.sqlConn;
            this.sqlCmdSetClienteRed.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sIdRed", System.Data.SqlDbType.VarChar, 4),
            new System.Data.SqlClient.SqlParameter("@sIdClasificacion", System.Data.SqlDbType.VarChar, 1),
            new System.Data.SqlClient.SqlParameter("@dFAR", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@dFBR", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt, 2)});
            // 
            // sqlDAClienteRed
            // 
            this.sqlDAClienteRed.MissingMappingAction = System.Data.MissingMappingAction.Ignore;
            this.sqlDAClienteRed.SelectCommand = this.sqlSelectCommand8;
            this.sqlDAClienteRed.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaClienteRed", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("sIdRed", "sIdRed"),
                        new System.Data.Common.DataColumnMapping("sIdClasificacion", "sIdClasificacion"),
                        new System.Data.Common.DataColumnMapping("dFAR", "dFAR"),
                        new System.Data.Common.DataColumnMapping("dFBR", "dFBR"),
                        new System.Data.Common.DataColumnMapping("iEstado", "iEstado")})});
            // 
            // sqlSelectCommand8
            // 
            this.sqlSelectCommand8.CommandText = "[ListaClienteRed]";
            this.sqlSelectCommand8.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand8.Connection = this.sqlConn;
            this.sqlSelectCommand8.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdCLiente", System.Data.SqlDbType.Int, 4)});
            // 
            // listaTipoAreaCliSAPBindingSource
            // 
            this.listaTipoAreaCliSAPBindingSource.DataMember = "ListaTipoAreaCliSAP";
            this.listaTipoAreaCliSAPBindingSource.DataSource = this.dsClientes1;
            // 
            // ListaTipoProgInfCliSAPBindingSource
            // 
            this.ListaTipoProgInfCliSAPBindingSource.DataMember = "ListaTipoProgInfCliSAP";
            this.ListaTipoProgInfCliSAPBindingSource.DataSource = this.dsClientes1;
            // 
            // dsClientes1BindingSource
            // 
            this.dsClientes1BindingSource.DataSource = this.dsClientes1;
            this.dsClientes1BindingSource.Position = 0;
            // 
            // btEncuestas
            // 
            this.btEncuestas.Location = new System.Drawing.Point(974, 213);
            this.btEncuestas.Name = "btEncuestas";
            this.btEncuestas.Size = new System.Drawing.Size(122, 29);
            this.btEncuestas.TabIndex = 90;
            this.btEncuestas.Text = "Encuestas";
            this.btEncuestas.UseVisualStyleBackColor = true;
            this.btEncuestas.Click += new System.EventHandler(this.btEncuestas_Click);
            // 
            // frmManClientesSAP
            // 
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.ClientSize = new System.Drawing.Size(1213, 544);
            this.Controls.Add(this.btEncuestas);
            this.Controls.Add(this.pnMayoristas);
            this.Controls.Add(this.btMayoristas);
            this.Controls.Add(this.pnCRM);
            this.Controls.Add(this.btCRM);
            this.Controls.Add(this.pnAccionesMark);
            this.Controls.Add(this.pnCentros);
            this.Controls.Add(this.btAccionesMark);
            this.Controls.Add(this.btCentros);
            this.Controls.Add(this.pnCliente);
            this.Controls.Add(this.ucBotoneraSecundaria1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmManClientesSAP";
            this.Text = "Mantenimiento de Datos de Cliente SAP";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmManClientesSAP_Closing);
            this.Closed += new System.EventHandler(this.frmManClientesSAP_Closed);
            this.Load += new System.EventHandler(this.frmManClientesSAP_Load);
            this.pnCliente.ResumeLayout(false);
            this.pnCliente.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsClientes1)).EndInit();
            this.pnCentros.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgContactos)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgCentros)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listaAreasporClienteSAPBindingSource)).EndInit();
            this.pnAccionesMark.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgAccionesMark)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupAccCantidad)).EndInit();
            this.pnMayoristas.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgMayoristas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listaTipoAreaCliSAPBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListaTipoProgInfCliSAPBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsClientes1BindingSource)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region frmManClientesSAP_Load
		private void frmManClientesSAP_Load(object sender, System.EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;
                      

            try
			{
				GESTCRM.Utiles.Formato_Formulario(this);

                this.Width = 1150; //---- GSG (13/03/2019)

                if (this.Parent == null) this.WindowState = FormWindowState.Normal;

				this.Param_iIdDelegado = GESTCRM.Clases.Configuracion.iIdDelegado;
				//El delegado sólo tiene acceso de Consulta
				if(GESTCRM.Clases.Configuracion.iGClientesSAP==1) this.Param_TipoAcceso="C";

				//this.pnAccionesMark.Location= new Point(1,215);	//CAR
				this.pnAccionesMark.Location = new Point(1, 244);
				this.pnAccionesMark.Visible=false;
				//this.pnCentros.Location= new Point(1,215);	//CAR
				this.pnCentros.Location = new Point(1, 244);
				this.pnCentros.Visible=false;
				//this.pnMayoristas.Location= new Point(1,215);	//CAR
				this.pnMayoristas.Location = new Point(1, 244);
				this.pnMayoristas.Visible=false;
				//this.pnCRM.Location= new Point(1,215);	//CAR
				this.pnCRM.Location = new Point(1, 244);
				this.pnCRM.Visible=true;

				Application.DoEvents();
				Inicializar_DataGrids();

				Application.DoEvents();
				Inicializar_Combos();

				Application.DoEvents();
				
				

				if(this.Param_TipoAcceso == "M")
				{
					Inicializar_Cliente();
					if(this.Var_iEstado!=0) this.Param_TipoAcceso="C";
				}

				Application.DoEvents();
				Activar_Formulario();

				switch(this.Param_TipoAcceso)
				{
					case "A": this.lblTitulo.Text = "Alta de Cliente SAP";break;
					case "M": this.lblTitulo.Text = "Modificación de Cliente SAP";break;
					case "C": this.lblTitulo.Text = "Consulta de Cliente SAP";
						      this.cboClasificacion.Enabled = false;
							  this.btBuscaAccion.Enabled =false;
							  this.btActualizarAcc.Enabled =false;
							  this.btEliminarAcc.Enabled =false;
							  this.btBuscarCentro.Enabled =false;
						      this.btActualizarCen.Enabled =false;
						      this.btEliminarCen.Enabled =false;
							  this.btActualizaCont.Enabled =false;
							  this.btEliminaCont.Enabled =false;
								break;
					default: break;
				}

				Application.DoEvents();
				Inicializar_Botonera();

				if(this.Param_Inicio==0) //Se llama desde Report de Actividad
				{
					if(this.btAccionesMark.Enabled) Mostrar_Acciones();
				}

				if(this.Param_TipoAcceso=="C")
				{
					this.contextMenu1.Dispose();
				}

				this.SalirDesdeGuardar=false;


                //---- GSG (03/07/2019)
                if (ProponerEncuesta())
                    Mensajes.ShowInformation("El cliente tiene una encuesta pendiente de realizar.");


            }
            catch (Exception ex)
			{
				Mensajes.ShowError(ex.Message);
			}
			Cursor.Current = Cursors.Default;
		}


        private bool ProponerEncuesta()
        {
            bool bRet = false;

            if (this.txtsIdCliente_SAP.Text.Trim() != "")
            {
                frmEncuesta frmEnc = new frmEncuesta(this.Param_iIdDelegado, this.txtsIdCliente_SAP.Text);

                if (frmEnc.EncuestaPendiente())
                {
                    bRet = true;
                }
            }

            return bRet;
        }
        #endregion

        /// <summary>
        /// Inicializa combo clasificacion. 
        /// </summary>
        private void InizalizaComboClasificacion()
		{
			this.sqldaListaTipoClasificacion.Fill(this.dsClientes1);
		}

		#region Inicializar_Botonera
		private void Inicializar_Botonera()
		{
			try
			{
				this.ucBotoneraSecundaria1.btSalir.Click += new EventHandler(btSalir_Click);
				this.ucBotoneraSecundaria1.btGrabar.Click += new EventHandler(btGrabar_Click);
				if(this.Param_TipoAcceso=="C")
				{
					this.ucBotoneraSecundaria1.Activar_botonera(true,false,false,false,false,false);
				}
				else
				{
					this.ucBotoneraSecundaria1.Activar_botonera(true,false,false,false,true,false);
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
				this.sqldaListaTipoClasificacion.Fill(this.dsClientes1);

                //---- GSG (27/05/2013)
				//this.sqldaListaTipoCtoClienteSAP.Fill(this.dsClientes1);
                this.sqldaListaTipoAreasClienteSAP.Fill(this.dsClientes1);
                this.sqldaListaTipoProgInfClienteSAP.Fill(this.dsClientes1);
                //---- FI GSG
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region Inicializar_DataGrids
		private void Inicializar_DataGrids()
		{
			try
			{	
				//Inicializa la tabla ClientesRedes
				this.dsClientes1.GetCliente_SAP.Rows.Clear();
				this.dsClientes1.ListaClienteRed.Rows.Clear();
				this.sqldaGetCliente_SAP.SelectCommand.Parameters["@iIdCliente"].Value = this.Param_iIdCliente;
				this.sqldaGetCliente_SAP.Fill(this.dsClientes1);
				this.sqlDAClienteRed.SelectCommand.Parameters["@iIdCliente"].Value = this.Param_iIdCliente;
				this.sqlDAClienteRed.Fill(this.dsClientes1);

				//Inicializa los Default Views de todos los datatables asociados a Grids
				this.dsClientes1.ListaContactos_porCliente_SAP.DefaultView.RowFilter = "iEstado=0";
				this.dsClientes1.ListaCentros_porCliente_SAP.DefaultView.RowFilter = "iEstado=0";
				this.dsClientes1.ListaAccionesMarkClientes.DefaultView.RowFilter  = "iEstado=0"; 
				this.dsClientes1.ListaMayoristasClientes_SAP.DefaultView.RowFilter  = "iEstado=0";
                this.dsClientes1.ListaAreas_porCliente_SAP.DefaultView.RowFilter = "iEstado=0"; //---- GSG (28/05/2013)
                this.dsClientes1.ListaProgInf_porCliente_SAP.DefaultView.RowFilter = "iEstado=0"; //---- GSG (30/05/2013)

				//DataGrid de Contactos asociados a un ClienteSAP
				GESTCRM.Utiles.Formatear_DataGrid(this.dgContactos, null, this.contextMenu1);

                //---- GSG (27/05/2013) 
                //this.dsClientes1.ListaContactos_porCliente_SAP.Rows.Clear();
                //this.sqldaListaContactosporCliente_SAP.SelectCommand.Parameters["@iIdCliente"].Value = this.Param_iIdCliente;
                //this.sqldaListaContactosporCliente_SAP.Fill(this.dsClientes1);
                //this.dgContactos.DataSource =this.dsClientes1.ListaContactos_porCliente_SAP;
                //this.lblTotContactos.Text = this.dsClientes1.ListaContactos_porCliente_SAP.DefaultView.Count.ToString();

                this.dsClientes1.ListaAreas_porCliente_SAP.Rows.Clear();
                this.sqldaListaAreasporCliente_SAP.SelectCommand.Parameters["@iIdCliente"].Value = this.Param_iIdCliente;
                this.sqldaListaAreasporCliente_SAP.Fill(this.dsClientes1);
                this.dgContactos.DataSource = this.dsClientes1.ListaAreas_porCliente_SAP;

                this.lblTotContactos.Text = this.dsClientes1.ListaAreas_porCliente_SAP.DefaultView.Count.ToString();
                //---- FI GSG

                if (int.Parse(this.lblTotContactos.Text.ToString()) > 0)
                {
                    this.dgContactos.CurrentCell = new DataGridCell(0, 1);
                    this.dgContactos.CurrentCell = new DataGridCell(0, 0);
                }

				
				//DataGrid de Centros asociados a un ClienteSAP
				GESTCRM.Utiles.Formatear_DataGrid(this.dgCentros,null,this.contextMenu1);

                //---- GSG (27/05/2013) 

                //this.dsClientes1.ListaCentros_porCliente_SAP.Rows.Clear();
                //this.sqldaListaCentros_porCliente_SAP.SelectCommand.Parameters["@iIdCliente"].Value = this.Param_iIdCliente;
                //this.sqldaListaCentros_porCliente_SAP.Fill(this.dsClientes1);

                //this.dgCentros.DataSource = this.dsClientes1.ListaCentros_porCliente_SAP;
 
                //this.lblTotCentros.Text = this.dsClientes1.ListaCentros_porCliente_SAP.DefaultView.Count.ToString();

                this.dsClientes1.ListaProgInf_porCliente_SAP.Rows.Clear();
                this.sqldaListaProgInfCliente_SAP.SelectCommand.Parameters["@iIdCliente"].Value = this.Param_iIdCliente;
                this.sqldaListaProgInfCliente_SAP.Fill(this.dsClientes1);

                this.dgCentros.DataSource = this.dsClientes1.ListaProgInf_porCliente_SAP;

                this.lblTotCentros.Text = this.dsClientes1.ListaCentros_porCliente_SAP.DefaultView.Count.ToString();

                //---- FI GSG

				if(int.Parse(this.lblTotCentros.Text.ToString())>0)
				{
					this.dgCentros.CurrentCell = new DataGridCell(0,1);
					this.dgCentros.CurrentCell = new DataGridCell(0,0);
				}



				//DataGrid de Acciones asociados a un ClienteSAP
				GESTCRM.Utiles.Formatear_DataGrid(this.dgAccionesMark,null,this.contextMenu1);
				this.dsClientes1.ListaAccionesMarkClientes.Rows.Clear();
				this.sqldaListaAccionesMarkCli.SelectCommand.Parameters["@iIdCliente"].Value = this.Param_iIdCliente;
				this.sqldaListaAccionesMarkCli.Fill(this.dsClientes1);

				this.dgAccionesMark.DataSource= this.dsClientes1.ListaAccionesMarkClientes;
				this.lblTotAcciones.Text=this.dsClientes1.ListaAccionesMarkClientes.DefaultView.Count.ToString();

				if(int.Parse(this.lblTotAcciones.Text.ToString())>0)
				{
					this.dgAccionesMark.CurrentCell = new DataGridCell(0,1);
					this.dgAccionesMark.CurrentCell = new DataGridCell(0,0);
				}

				//DataGrid de Mayoristas asociados a un ClienteSAP
				GESTCRM.Utiles.Formatear_DataGrid(this,this.dgMayoristas,"C",true,null);
				this.dsClientes1.ListaMayoristasClientes_SAP.Rows.Clear();
				this.sqldaListaMayoristasClientes_SAP.SelectCommand.Parameters["@iIdCliente"].Value = this.Param_iIdCliente;
				this.sqldaListaMayoristasClientes_SAP.Fill(this.dsClientes1);

				this.lblTotMayoristas.Text = this.dsClientes1.ListaMayoristasClientes_SAP.Rows.Count.ToString();
				this.Var_NumFilaMay=-1;


				//Inicializar CRM
				this.ucUltimoPedido1.ultimos_pedidos_de(this.txtsIdCliente_SAP.Text.ToString());
				this.ucRankingMatCli1.RankingPorCliente(this.Param_iIdCliente);
				string Acceso;
				if(this.Param_TipoAcceso=="C") Acceso="C";
				else Acceso="M";
				this.ucUltimasVisitas1.UltimasVisitasPorCliente(this.Param_iIdCliente,this.Param_iIdDelegado,Acceso);


				this.dsClientes1.AcceptChanges();
			}
			catch(Exception e){Mensajes.ShowError(e.Message);}
		}
		#endregion

		#region Inicializar_Cliente
		private void Inicializar_Cliente()
		{
			try
			{
				if(this.dsClientes1.GetCliente_SAP.Rows.Count>0)
				{
					this.Var_iEstado = int.Parse(this.dsClientes1.GetCliente_SAP.Rows[0]["iEstado"].ToString());
					this.Var_bEnviadoCEN = int.Parse(this.dsClientes1.GetCliente_SAP.Rows[0]["bEnviadoCEN"].ToString());
				}
				if (this.dsClientes1.ListaClienteRed.Rows.Count>0 )
				{
					this.cboClasificacion.SelectedValue = (!this.dsClientes1.ListaClienteRed[0].IssIdClasificacionNull() )?this.dsClientes1.ListaClienteRed[0].sIdClasificacion:"0"; 
				}
				else
				{
					this.cboClasificacion.SelectedValue="0";
				}
			}
			catch(Exception e){Mensajes.ShowError(e.Message);}
		}
		#endregion 

		#region btCRM_Click
		private void btCRM_Click(object sender, System.EventArgs e)
		{
			try
			{
                //---- GSG (13/03/2019)
                //this.btCentros.Font = GESTCRM.Utiles.fuenteNoBold;
				//this.btAccionesMark.Font = GESTCRM.Utiles.fuenteNoBold;
				//this.btMayoristas.Font = GESTCRM.Utiles.fuenteNoBold;
				//this.btCRM.Font = GESTCRM.Utiles.fuenteBold;
                this.btCRM.Font = GESTCRM.Utiles.fuenteBoldBig;
                this.btCentros.Font = GESTCRM.Utiles.fuenteNoBoldBig;
                this.btAccionesMark.Font = GESTCRM.Utiles.fuenteNoBoldBig;
                this.btMayoristas.Font = GESTCRM.Utiles.fuenteNoBoldBig;



                this.pnCentros.Visible=false;
				this.pnAccionesMark.Visible=false;
				this.pnMayoristas.Visible=false;

				this.pnCRM.Visible=true;
			}
			catch(Exception ex)
			{
				Mensajes.ShowError(ex.Message);
			}
		}
		#endregion

		#region btAccionesMark_Click
		private void btAccionesMark_Click(object sender, System.EventArgs e)
		{
			Mostrar_Acciones();
		}

		private void Mostrar_Acciones()
		{
			try
			{


                //---- GSG (13/03/2019)
                //this.btAccionesMark.Font = GESTCRM.Utiles.fuenteBold;
                //this.btCentros.Font = GESTCRM.Utiles.fuenteNoBold;
                //this.btCRM.Font = GESTCRM.Utiles.fuenteNoBold;
                //this.btMayoristas.Font = GESTCRM.Utiles.fuenteNoBold;
                this.btAccionesMark.Font = GESTCRM.Utiles.fuenteBoldBig;
                this.btCentros.Font = GESTCRM.Utiles.fuenteNoBoldBig;
                this.btCRM.Font = GESTCRM.Utiles.fuenteNoBoldBig;
                this.btMayoristas.Font = GESTCRM.Utiles.fuenteNoBoldBig;



                this.pnCentros.Visible=false;
				this.pnCRM.Visible=false;
				this.pnMayoristas.Visible=false;

				this.pnAccionesMark.Visible=true;
			}
			catch(Exception ex)
			{
				Mensajes.ShowError(ex.Message);
			}
		}
		#endregion

		#region btMayoristas_Click
		private void btMayoristas_Click(object sender, System.EventArgs e)
		{
			try
			{
                //---- GSG (13/03/2019)
                //this.btCentros.Font = GESTCRM.Utiles.fuenteNoBold;
                //this.btAccionesMark.Font = GESTCRM.Utiles.fuenteNoBold;
                //this.btCRM.Font = GESTCRM.Utiles.fuenteNoBold;
                //this.btMayoristas.Font = GESTCRM.Utiles.fuenteBold;
                this.btMayoristas.Font = GESTCRM.Utiles.fuenteBoldBig;
                this.btCentros.Font = GESTCRM.Utiles.fuenteNoBoldBig;
                this.btAccionesMark.Font = GESTCRM.Utiles.fuenteNoBoldBig;
                this.btCRM.Font = GESTCRM.Utiles.fuenteNoBoldBig;

                this.pnCentros.Visible=false;
				this.pnAccionesMark.Visible=false;
				this.pnCRM.Visible=false;

				this.pnMayoristas.Visible=true;
			}
			catch(Exception ex)
			{
				Mensajes.ShowError(ex.Message);
			}
		}
		#endregion

		#region btCentros_Click
		private void btCentros_Click(object sender, System.EventArgs e)
		{
			try
			{



                //---- GSG (13/03/2019)
                //this.btAccionesMark.Font = GESTCRM.Utiles.fuenteNoBold;
                //this.btCRM.Font = GESTCRM.Utiles.fuenteNoBold;
                //this.btMayoristas.Font = GESTCRM.Utiles.fuenteNoBold;
                //this.btCentros.Font = GESTCRM.Utiles.fuenteBold;
                this.btAccionesMark.Font = GESTCRM.Utiles.fuenteNoBoldBig;
                this.btCRM.Font = GESTCRM.Utiles.fuenteNoBoldBig;
                this.btMayoristas.Font = GESTCRM.Utiles.fuenteNoBoldBig;
                this.btCentros.Font = GESTCRM.Utiles.fuenteBoldBig;

                this.pnAccionesMark.Visible=false;
				this.pnCRM.Visible=false;
				this.pnMayoristas.Visible=false;

				this.pnCentros.Visible=true;
			}
			catch(Exception ex)
			{
				Mensajes.ShowError(ex.Message);
			}
		}
		#endregion

		#region menuEliminar_Click
		private void menuEliminar_Click(object sender, System.EventArgs e)
		{
			try
			{
				string Objeto = this.contextMenu1.SourceControl.Name.ToString();
				if(Objeto.Length==0) Objeto = this.contextMenu1.SourceControl.Parent.Name.ToString();
				switch(Objeto)
				{
					case "dgCentros":		Eliminar_Centro();break;
					case "dgAccionesMark":	Eliminar_Accion();break;
					case "dgContactos":		Eliminar_Contacto();break;
					default: break;
				}
			}
			catch(Exception ex)
			{
				Mensajes.ShowError(ex.Message);
			}
		}
		#endregion

		#region menuNuevo_Click
		private void menuNuevo_Click(object sender, System.EventArgs e)
		{
			try
			{
				string Objeto = this.contextMenu1.SourceControl.Name.ToString();
				if(Objeto.Length==0) Objeto = this.contextMenu1.SourceControl.Parent.Name.ToString();

				switch(Objeto)
				{
					case "dgCentros":		Nuevo_Centro();break;
					case "dgAccionesMark":	Nueva_Accion();break;
					case "dgContactos":		Nuevo_Contacto();break;
					default: break;
				}
			}
			catch(Exception ex)
			{
				Mensajes.ShowError(ex.Message);
			}
		}
		#endregion

		#region dgMayoristas_Paint
		private void dgMayoristas_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			try
			{
				if(this.dgMayoristas.CurrentRowIndex!=-1 && this.Var_NumFilaMay != this.dgMayoristas.CurrentRowIndex)
				{
					this.Var_NumFilaMay= this.dgMayoristas.CurrentRowIndex;
					Utiles.Seleccionar_UnaFilaDataGrid(this.dgMayoristas,this.Var_NumFilaMay,this.dsClientes1.ListaMayoristasClientes_SAP.Rows.Count);
				}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region dgContactos_CurrentCellChanged
		private void dgContactos_CurrentCellChanged(object sender, System.EventArgs e)
		{
			try
			{
				int fila = this.dgContactos.CurrentRowIndex;
				GESTCRM.Utiles.Seleccionar_UnaFilaDataGrid(this,this.dgContactos,fila);

				//this.txtContNombre.Text = this.dgContactos[fila,0].ToString(); ---- GSG (28/05/2013)

				try{this.cbContCargo.SelectedValue = this.dgContactos[fila,1].ToString();}
				catch{this.cbContCargo.SelectedIndex=-1;}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion 

		#region btActualizaCont_Click
		private void btActualizaCont_Click(object sender, System.EventArgs e)
		{
			Actualizar_Contacto();
		}
		#endregion

		#region btEliminaCont_Click
		private void btEliminaCont_Click(object sender, System.EventArgs e)
		{
			Eliminar_Contacto();
		}
		#endregion

		#region Nuevo_Contacto
		private void Nuevo_Contacto()
		{
			try
			{
				this.txtContNombre.Focus();
				this.txtContNombre.Text = null;
				this.cbContCargo.SelectedIndex = -1;
				this.cbContCargo.SelectedIndex = -1;
			}
			catch(Exception ex){ Mensajes.ShowError(ex.Message); }
		}
		#endregion

		#region Eliminar_Contacto
		private void Eliminar_Contacto()
		{
			try
			{
				if(this.dgContactos.CurrentRowIndex>-1)
				{
                    //---- GSG (28/05/2013)
                    //int record = GESTCRM.Utiles.Buscar_fila_dtTabla(this.dsClientes1.ListaContactos_porCliente_SAP,"sNombre",this.dgContactos[this.dgContactos.CurrentRowIndex,0].ToString());
                    //int fila = GESTCRM.Utiles.Buscar_filaDataGrid(this,this.dgContactos,"sNombre",this.dgContactos[this.dgContactos.CurrentRowIndex,0].ToString());
                    //if(record > -1)
                    //{
                    //    int SelFila = fila;
                    //    if(fila>0) SelFila=fila-1;

                    //    if(this.dsClientes1.ListaContactos_porCliente_SAP.Rows.Count-1==0) SelFila = -1;
                    //    this.dgContactos.CurrentRowIndex=SelFila;
                    //    GESTCRM.Utiles.Seleccionar_UnaFilaDataGrid(this,this.dgContactos,SelFila);

                    //    if (!this.dsClientes1.ListaContactos_porCliente_SAP[record].nuevo)
                    //    {
                    //        dsClientes1.ListaContactos_porCliente_SAP[record]["dFBR"]=DateTime.Now;
                    //        dsClientes1.ListaContactos_porCliente_SAP[record]["iEstado"]= -1;
                    //    }
                    //    else
                    //    {
                    //        dsClientes1.ListaContactos_porCliente_SAP.Rows.RemoveAt(record);
                    //    }

                    //    this.lblTotContactos.Text = this.dsClientes1.ListaContactos_porCliente_SAP.DefaultView.Count.ToString();
                    //    Nuevo_Contacto();
                    //}

                    int record = GESTCRM.Utiles.Buscar_fila_dtTabla(this.dsClientes1.ListaAreas_porCliente_SAP, "sNombre", this.dgContactos[this.dgContactos.CurrentRowIndex, 2].ToString());
                    int fila = GESTCRM.Utiles.Buscar_filaDataGrid(this, this.dgContactos, "sNombre", this.dgContactos[this.dgContactos.CurrentRowIndex, 2].ToString());
                    if (record > -1)
                    {
                        int SelFila = fila;
                        if (fila > 0) SelFila = fila - 1;

                        if (this.dsClientes1.ListaAreas_porCliente_SAP.Rows.Count - 1 == 0) SelFila = -1;
                        this.dgContactos.CurrentRowIndex = SelFila;
                        GESTCRM.Utiles.Seleccionar_UnaFilaDataGrid(this, this.dgContactos, SelFila);

                        dsClientes1.ListaAreas_porCliente_SAP[record]["dFBR"] = DateTime.Now;
                        dsClientes1.ListaAreas_porCliente_SAP[record]["iEstado"] = -1;

                       
                        this.lblTotContactos.Text = this.dsClientes1.ListaAreas_porCliente_SAP.DefaultView.Count.ToString();
                        Nuevo_Contacto();
                    }

                    //---- FI GSG
				}

                
			}
			catch(Exception ex) { Mensajes.ShowError(ex.Message); }
		}
		#endregion

		#region Actualizar_Contacto
		private void Actualizar_Contacto()
		{
			try
			{
				if(Validar_Contacto())
				{

                    //---- GSG (28/05/2013)
                    //int fila = GESTCRM.Utiles.Buscar_filaDataGrid(this, this.dgContactos, "sNombre", this.txtContNombre.Text.ToString());
                    //int record = GESTCRM.Utiles.Buscar_fila_dtTabla(this.dsClientes1.ListaContactos_porCliente_SAP,"sNombre",this.txtContNombre.Text.ToString());                    

                    //if(record==-1)
                    //{
                    //    DataRow dvfila= this.dsClientes1.ListaContactos_porCliente_SAP.NewRow();
                    //    dvfila["sNombre"]=this.txtContNombre.Text.ToString();
                    //    dvfila["sIdCargoContacto"]=this.cbContCargo.SelectedValue.ToString();
                    //    dvfila["tIdCargoContacto"]=this.cbContCargo.GetItemText(this.cbContCargo.SelectedItem).ToString();
                    //    //---- GSG (17/05/2011)
                    //    //dvfila["dFAR"]=DateTime.Now;
                    //    dvfila["dFAR"] = "";
                    //    //---- FI GSG
                    //    dvfila["dFBR"]=DBNull.Value;
                    //    dvfila["iEstado"]=this.Var_iEstado;

                    //    this.dsClientes1.ListaContactos_porCliente_SAP.Rows.Add(dvfila);
					
                    //    fila = this.dsClientes1.ListaContactos_porCliente_SAP.DefaultView.Count-1;
                    //}
                    //else
                    //{
                    //    try
                    //    {
                    //        this.dsClientes1.ListaContactos_porCliente_SAP.Rows[record]["sIdCargoContacto"]=this.cbContCargo.SelectedValue.ToString();
                    //        this.dsClientes1.ListaContactos_porCliente_SAP.Rows[record]["tIdCargoContacto"]=this.cbContCargo.GetItemText(this.cbContCargo.SelectedItem).ToString();
                    //    }
                    //    catch
                    //    {
                    //        this.dsClientes1.ListaContactos_porCliente_SAP.Rows[record]["sIdCargoContacto"]=null;
                    //        this.dsClientes1.ListaContactos_porCliente_SAP.Rows[record]["tIdCargoContacto"]=null;
                    //    }

                    //    dsClientes1.ListaContactos_porCliente_SAP.Rows[record]["dFBR"]=DBNull.Value;
                    //    dsClientes1.ListaContactos_porCliente_SAP.Rows[record]["iEstado"]=Convert.ToInt32(this.Var_iEstado);

                    //    //---- GSG (17/05/2011)
                    //    //dsClientes1.ListaContactos_porCliente_SAP.Rows[record]["dFAR"]=DateTime.Now;
                    //    dsClientes1.ListaContactos_porCliente_SAP.Rows[record]["dFAR"] = "";
                    //    //---- FI GSG
                    //}

                    //this.dgContactos.CurrentRowIndex= fila;
                    //GESTCRM.Utiles.Seleccionar_UnaFilaDataGrid(this,this.dgContactos,fila);
                    //this.lblTotContactos.Text = this.dsClientes1.ListaContactos_porCliente_SAP.DefaultView.Count.ToString();
                    //dsClientes1.ListaCentros_porCliente_SAP.AcceptChanges();



                    int fila = GESTCRM.Utiles.Buscar_filaDataGrid(this, this.dgContactos, "sNombre", this.cbContCargo.Text);
                    int record = GESTCRM.Utiles.Buscar_fila_dtTabla(this.dsClientes1.ListaAreas_porCliente_SAP, "sNombre", this.cbContCargo.Text);

                    if (record == -1)
                    {
                        DataRow dvfila = this.dsClientes1.ListaAreas_porCliente_SAP.NewRow();

                        dvfila["iIdCliente"] = this.Param_iIdCliente;
                        dvfila["iIdContacto"] = this.cbContCargo.SelectedValue.ToString();
                        dvfila["sNombre"] = this.cbContCargo.Text;
                        dvfila["sIdCargoContacto"] = "46";
                        dvfila["dFAR"] = DateTime.Now;
                        dvfila["dFBR"] = DBNull.Value;
                        dvfila["iEstado"] = this.Var_iEstado;

                        this.dsClientes1.ListaAreas_porCliente_SAP.Rows.Add(dvfila);
                        fila = this.dsClientes1.ListaAreas_porCliente_SAP.DefaultView.Count - 1;
                    }
                    else
                    {
                        dsClientes1.ListaAreas_porCliente_SAP.Rows[record]["sNombre"] = this.cbContCargo.Text;
                        dsClientes1.ListaAreas_porCliente_SAP.Rows[record]["iEstado"] = Convert.ToInt32(this.Var_iEstado);
                    }

                    this.dgContactos.CurrentRowIndex = fila;
                    GESTCRM.Utiles.Seleccionar_UnaFilaDataGrid(this, this.dgContactos, fila);

                    this.lblTotContactos.Text = this.dsClientes1.ListaAreas_porCliente_SAP.DefaultView.Count.ToString();

                    //---- FI GSG

					Nuevo_Contacto();
				}
			}
			catch(Exception ex) { Mensajes.ShowError(ex.Message); }
		}
		#endregion

		#region Validar_Contacto
		private bool Validar_Contacto()
		{
			bool resultado = true;
			try
			{
                //---- GSG (28/05/2013)
                //if(this.txtContNombre.Text.ToString().Length==0 )
                //{
                //    Mensajes.ShowError("Campo Nombre Obligatorio. ");
                //    return false;
                //}
                //---- FI GSG

                if (this.cbContCargo.SelectedIndex == -1)
                {
                    Mensajes.ShowError("Campo Cargo Obligatorio. ");
                    return false;
                }
                else if (this.dgContactos.CurrentRowIndex > -1)
                {
                    Mensajes.ShowError("El area es única para el cliente. Si desea cambiar el area del cliente primero debe borrar la actual. ");
                    return false;
                }

			}
			catch(Exception e)
			{
				Mensajes.ShowError(e.Message);
				resultado = false;
			}
			return resultado;
		}
		#endregion




		#region dgCentros_CurrentCellChanged
		private void dgCentros_CurrentCellChanged(object sender, System.EventArgs e)
		{
			try
			{
				int fila = this.dgCentros.CurrentRowIndex;
				GESTCRM.Utiles.Seleccionar_UnaFilaDataGrid(this,this.dgCentros,fila);

				
                //---- GSG (30/05/2013)
                //this.Var_iIdCentro = int.Parse(this.dgCentros[fila, 2].ToString());
                //this.txtCentrosId.Text = this.dgCentros[fila,0].ToString();
                //this.txtCentroDesc.Text = this.dgCentros[fila,1].ToString();

                try { this.cbProgInf.SelectedValue = this.dgCentros[fila, 1].ToString(); }
                catch { this.cbProgInf.SelectedIndex = -1; }

                //---- FI GSG
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
				frmBCent.ParamI_iIdDelegado = this.Param_iIdDelegado;
				frmBCent.ShowDialog(this);
				if (frmBCent.DialogResult==System.Windows.Forms.DialogResult.OK)
				{
					if(this.txtCentrosId.Text!=frmBCent.ParamIO_sIdCentro)
					{
						this.txtCentrosId.Text=frmBCent.ParamIO_sIdCentro;
						this.txtCentroDesc.Text=frmBCent.ParamIO_sDescripcion;
						this.Var_iIdCentro = frmBCent.ParamO_iIdCentro;
					}
				}
			}
			catch(Exception ex)
			{
				Mensajes.ShowError(ex.Message);
			}
		}
		#endregion

		#region txtCentrosId_Leave
		private void txtCentrosId_Leave(object sender, System.EventArgs e)
		{
			try
			{
				GESTCRM.Formularios.Busquedas.frmMCentros frmBCent = new GESTCRM.Formularios.Busquedas.frmMCentros();
				frmBCent.ParamI_iIdDelegado =this.Param_iIdDelegado;
				frmBCent.ParamIO_sIdCentro= this.txtCentrosId.Text.ToString();
				frmBCent.ParamIO_sDescripcion="";
				frmBCent.Buscar_sCentro();
				if(this.txtCentroDesc.Text!=frmBCent.ParamIO_sDescripcion)
				{
					this.Var_iIdCentro = frmBCent.ParamO_iIdCentro;
					if(this.Var_iIdCentro==-1) Mensajes.ShowError("Este código de Centro no existe.");
					else
					{
						this.txtCentrosId.Text=frmBCent.ParamIO_sIdCentro;
						this.txtCentroDesc.Text=frmBCent.ParamIO_sDescripcion;
					}
				}
			}
			catch(Exception ex)
			{
				Mensajes.ShowError(ex.Message);
			}
		}
		#endregion

		#region btActualizarCen_Click
		private void btActualizarCen_Click(object sender, System.EventArgs e)
		{
			Actualizar_Centro();		
		}
		#endregion

		#region btEliminarCen_Click
		private void btEliminarCen_Click(object sender, System.EventArgs e)
		{
			Eliminar_Centro();
		}
		#endregion

		#region Nuevo_Centro
		private void Nuevo_Centro()
		{
			try
			{
				this.txtCentrosId.Focus();
				this.txtCentrosId.Text = null;
				this.txtCentroDesc.Text = null;
				this.Var_iIdCentro=-1;
			}
			catch(Exception ex){ Mensajes.ShowError(ex.Message); }
		}
		#endregion

		#region Eliminar_Centro
		private void Eliminar_Centro()
		{
			try
			{
				if(this.dgCentros.CurrentRowIndex>-1)
				{
                    //---- GSG (30/05/2013)
                    //int record = GESTCRM.Utiles.Buscar_fila_dtTabla(this.dsClientes1.ListaCentros_porCliente_SAP,"sIdCentro",this.dgCentros[this.dgCentros.CurrentRowIndex,0].ToString());
                    //int filaGrid = GESTCRM.Utiles.Buscar_filaDataGrid (this,this.dgCentros ,"sIdCentro",this.dgCentros[this.dgCentros.CurrentRowIndex,1].ToString());
                    //if(record > -1)
                    //{
                    //    int SelFila = filaGrid;
                    //    if(filaGrid>0) SelFila=filaGrid-1;
                    //    if(this.dsClientes1.ListaCentros_porCliente_SAP.Rows.Count-1==0) SelFila = -1;
                    //    this.dgCentros.CurrentRowIndex=SelFila;
                    //    GESTCRM.Utiles.Seleccionar_UnaFilaDataGrid(this,this.dgCentros,SelFila);

                    //    if (!this.dsClientes1.ListaCentros_porCliente_SAP[record].nuevo)
                    //    {
                    //        this.dsClientes1.ListaCentros_porCliente_SAP[record].iEstado = -1;
                    //        this.dsClientes1.ListaCentros_porCliente_SAP[record].dFBR =DateTime.Now;  
                    //    }
                    //    else
                    //    {
                    //        this.dsClientes1.ListaCentros_porCliente_SAP.Rows.RemoveAt(record);    
                    //    }

                    //    this.lblTotCentros.Text = this.dsClientes1.ListaCentros_porCliente_SAP.DefaultView.Count.ToString();
                    //    Nuevo_Centro();
                    //}

                    int record = GESTCRM.Utiles.Buscar_fila_dtTabla(this.dsClientes1.ListaProgInf_porCliente_SAP, "sNombre", this.dgCentros[this.dgCentros.CurrentRowIndex, 2].ToString());
                    int filaGrid = GESTCRM.Utiles.Buscar_filaDataGrid(this, this.dgCentros, "sNombre", this.dgCentros[this.dgCentros.CurrentRowIndex, 2].ToString());
                    
                    if (record > -1)
                    {
                        int SelFila = filaGrid;
                        if (filaGrid > 0) SelFila = filaGrid - 1;
                        if (this.dsClientes1.ListaProgInf_porCliente_SAP.Rows.Count - 1 == 0) SelFila = -1;
                        this.dgCentros.CurrentRowIndex = SelFila;
                        GESTCRM.Utiles.Seleccionar_UnaFilaDataGrid(this, this.dgCentros, SelFila);

                        this.dsClientes1.ListaProgInf_porCliente_SAP[record].iEstado = -1;
                        this.dsClientes1.ListaProgInf_porCliente_SAP[record].dFBR = DateTime.Now;


                        this.lblTotCentros.Text = this.dsClientes1.ListaProgInf_porCliente_SAP.DefaultView.Count.ToString();
                        Nuevo_Centro();
                    }
                    //---- FI GSG
				}
			}
			catch(Exception ex) { Mensajes.ShowError(ex.Message); }
		}


		#endregion

		#region Actualizar_Centro
		private void Actualizar_Centro()
		{
			try
			{
				if(Validar_Centro())
				{
                    //---- GSG (30/05/2013)
                    //int record = GESTCRM.Utiles.Buscar_fila_dtTabla(this.dsClientes1.ListaCentros_porCliente_SAP, "sIdCentro", this.txtCentrosId.Text.ToString());
                    //int fila = GESTCRM.Utiles.Buscar_filaDataGrid(this,this.dgCentros,"sIdCentro",this.txtCentrosId.Text.ToString());

                    //if(record == -1)
                    //{
                    //    DataRow dvfila= this.dsClientes1.ListaCentros_porCliente_SAP.NewRow();
                    //    dvfila["iIdCentro"]=this.Var_iIdCentro;
                    //    dvfila["sIdCentro"]=this.txtCentrosId.Text.ToString();
                    //    dvfila["sDescripcion"]=this.txtCentroDesc.Text.ToString();
                    //    dvfila["dFAR"]=DateTime.Now; 
                    //    dvfila["dFBR"]=DBNull.Value ; 
                    //    dvfila["iEstado"]=this.Var_iEstado; 
                    //    dvfila["nuevo"]=true;
					
                    //    this.dsClientes1.ListaCentros_porCliente_SAP.Rows.Add(dvfila);
					
                    //    fila = this.dsClientes1.ListaCentros_porCliente_SAP.DefaultView.Count-1;
                    //}
                    //else
                    //{
                    //    if (!this.dsClientes1.ListaCentros_porCliente_SAP[record].nuevo)
                    //    {
                    //        this.dsClientes1.ListaCentros_porCliente_SAP[record].iEstado =Convert.ToInt16(this.Var_iEstado) ;
                    //        this.dsClientes1.ListaCentros_porCliente_SAP[record].dFBR = Convert.ToDateTime(null); 
                    //    }
                    //    this.dsClientes1.ListaCentros_porCliente_SAP[record].dFAR = DateTime.Now;    
                    //}
				    
                    //this.dgCentros.CurrentRowIndex= fila;
                    //GESTCRM.Utiles.Seleccionar_UnaFilaDataGrid(this,this.dgCentros,fila);
                    //this.lblTotCentros.Text = this.dsClientes1.ListaCentros_porCliente_SAP.DefaultView.Count.ToString();

                    int record = GESTCRM.Utiles.Buscar_fila_dtTabla(this.dsClientes1.ListaProgInf_porCliente_SAP, "sNombre", this.cbProgInf.Text);
                    int fila = GESTCRM.Utiles.Buscar_filaDataGrid(this, this.dgCentros, "sNombre", this.cbProgInf.Text);

                    if (record == -1)
                    {
                        DataRow dvfila = this.dsClientes1.ListaProgInf_porCliente_SAP.NewRow();
                        dvfila["iIdCliente"] = this.Param_iIdCliente;
                        dvfila["iIdCentro"] = this.cbProgInf.SelectedValue.ToString();
                        dvfila["sNombre"] = this.cbProgInf.Text;
                        dvfila["dFAR"] = DateTime.Now;
                        dvfila["dFBR"] = DBNull.Value;
                        dvfila["iEstado"] = this.Var_iEstado;

                        this.dsClientes1.ListaProgInf_porCliente_SAP.Rows.Add(dvfila);
                        fila = this.dsClientes1.ListaProgInf_porCliente_SAP.DefaultView.Count - 1;
                    }
                    else
                    {
                        dsClientes1.ListaProgInf_porCliente_SAP.Rows[record]["sNombre"] = this.cbProgInf.Text;
                        dsClientes1.ListaProgInf_porCliente_SAP.Rows[record]["iEstado"] = Convert.ToInt32(this.Var_iEstado);
                    }

                    this.dgCentros.CurrentRowIndex = fila;
                    GESTCRM.Utiles.Seleccionar_UnaFilaDataGrid(this, this.dgCentros, fila);
                    this.lblTotCentros.Text = this.dsClientes1.ListaProgInf_porCliente_SAP.DefaultView.Count.ToString();

                    //---- FI GSGS
                    
                    Nuevo_Centro();
			    }
			}
			catch(Exception ex) { Mensajes.ShowError(ex.Message); }
		}
		#endregion

		#region Validar_Centro
		private bool Validar_Centro()
		{
			bool resultado = true;
			try
			{
                //---- GSG (30/05/2013)
                //if(this.txtCentrosId.Text.ToString().Length==0 || this.Var_iIdCentro==-1)
                //{
                //    Mensajes.ShowError("Campo Centro Obligatorio. ");
                //    return false;
                //}

                if (this.cbProgInf.SelectedIndex == -1)
                {
                    Mensajes.ShowError("Campo Programa Informático Obligatorio. ");
                    return false;
                }
                else if (this.dgCentros.CurrentRowIndex > -1)
                {
                    Mensajes.ShowError("El programa informático es único para el cliente. Si desea cambiar el programa informático del cliente primero debe borrar el actual. ");
                    return false;
                }
                //---- FI GSG
			}
			catch(Exception e)
			{
				Mensajes.ShowError(e.Message);
				resultado = false;
			}
			return resultado;
		}
		#endregion

		#region dgAccionesMark_CurrentCellChanged
		private void dgAccionesMark_CurrentCellChanged(object sender, System.EventArgs e)
		{
			try
			{
				int fila = this.dgAccionesMark.CurrentRowIndex;
				GESTCRM.Utiles.Seleccionar_UnaFilaDataGrid(this,this.dgAccionesMark,fila);

				this.Var_iIdAccion = int.Parse(this.dgAccionesMark[fila,4].ToString());
				this.txtAccsIdAccion.Text = this.dgAccionesMark[fila,0].ToString();
				this.dtpAccFEntrega.Value = DateTime.Parse(this.dgAccionesMark[fila,1].ToString());
				this.nupAccCantidad.Value = int.Parse(this.dgAccionesMark[fila,2].ToString());
				this.txtAccObservEntrega.Text = this.dgAccionesMark[fila,3].ToString();

				//this.ActivarAcciones(!(bool)(this.dgAccionesMark[fila,5]));
				this.ActivarAcciones((this.Param_TipoAcceso !="C"));
			}
			catch(Exception ex) {Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region Activar Acciones
		private void ActivarAcciones(bool Activar)
		{
			//this.dgAccionesMark.Enabled = Activar;
			this.btActualizarAcc.Enabled = Activar;
			this.btEliminarAcc.Enabled = Activar;
		}
		#endregion

		#region ActivarBotonesAcciones(bool Activar)
		private void ActivarBotonesAcciones(bool Activar)
		{
			this.btBuscaAccion.Enabled = Activar;
			this.nupAccCantidad.Enabled = Activar;
			this.txtAccObservEntrega.Enabled = Activar; 
			this.dtpAccFEntrega.Enabled = false;
		}
		#endregion


		#region btBuscaAccion_Click
		private void btBuscaAccion_Click(object sender, System.EventArgs e)
		{
			try
			{
				GESTCRM.Formularios.Busquedas.frmMAcciones frmBAcc = new GESTCRM.Formularios.Busquedas.frmMAcciones();
				frmBAcc.ShowDialog(this);
				if (frmBAcc.DialogResult==System.Windows.Forms.DialogResult.OK)
				{
					if(this.txtAccsIdAccion.Text!=frmBAcc.ParamIO_sIdAccion)
					{
						this.txtAccsIdAccion.Text=frmBAcc.ParamIO_sIdAccion;
						this.Var_iIdAccion = int.Parse(frmBAcc.ParamIO_iIdAccion);
						this.ActivarAcciones(true);
					}
					this.nupAccCantidad.Value = this.nupAccCantidad.Minimum;
					this.txtAccObservEntrega.Text = null;
				}
				this.dtpAccFEntrega.Value = DateTime.Now.Date;
			}
			catch(Exception ex)
			{
				Mensajes.ShowError(ex.Message);
			}
		}
		#endregion

		#region txtAccsIdAccion_Leave
		private void txtAccsIdAccion_Leave(object sender, System.EventArgs e)
		{
			try
			{
				GESTCRM.Formularios.Busquedas.frmMAcciones frmBAcc = new GESTCRM.Formularios.Busquedas.frmMAcciones();
				frmBAcc.ParamIO_sIdAccion =this.txtAccsIdAccion.Text.ToString();
				frmBAcc.DatosAccion();
				if(this.txtAccsIdAccion.Text!=frmBAcc.ParamIO_sIdAccion)
				{
					this.Var_iIdAccion = int.Parse(frmBAcc.ParamIO_iIdAccion);
					if(this.Var_iIdAccion==-1) Mensajes.ShowError("Esta Acción no existe.");
					else this.txtAccsIdAccion.Text=frmBAcc.ParamIO_sIdAccion;
				}
			}
			catch(Exception ex)
			{
				Mensajes.ShowError(ex.Message);
			}
		}
		#endregion


		#region btActualizarAcc_Click
		private void btActualizarAcc_Click(object sender, System.EventArgs e)
		{
			Actualizar_Accion();
		}
		#endregion

		#region btEliminarAcc_Click
		private void btEliminarAcc_Click(object sender, System.EventArgs e)
		{
			Eliminar_Accion();
		}
		#endregion 

		#region Nueva_Accion
		private void Nueva_Accion()
		{
			try
			{
				this.txtAccsIdAccion.Focus();
				this.txtAccsIdAccion.Text = null;
				this.dtpAccFEntrega.Value = DateTime.Now.Date;
				this.nupAccCantidad.Value = this.nupAccCantidad.Minimum;
				this.txtAccObservEntrega.Text = null;
				this.Var_iIdAccion=-1;
			}
			catch(Exception ex) {Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region Eliminar_Accion
		private void Eliminar_Accion()
		{
			DataRow[] result=null;
			GESTCRM.Formularios.DataSets.dsClientes.ListaAccionesMarkClientesRow rwAcc = null;     
			int record=-1;
			int fila=-1;
			try
			{
				if(this.dgAccionesMark.CurrentRowIndex>-1)
				{
                    //					int fila = GESTCRM.Utiles.Buscar_fila_dtTabla(this.dtAccionesMark,"sIdAccion",this.dgAccionesMark[this.dgAccionesMark.CurrentRowIndex,0].ToString());
                    //result = this.dsClientes1.ListaAccionesMarkClientes.Select("sIdAccion='"+this.txtAccsIdAccion.Text.ToString()+"' and '"+this.dtpAccFEntrega.Value.Date.ToString()+"' = dFechaEntrega AND bEnviadoCEN=0");
                    //---- GSG (21/06/2018)
                    //result = this.dsClientes1.ListaAccionesMarkClientes.Select("sIdAccion='" + this.txtAccsIdAccion.Text.ToString() + "' and '" + this.dtpAccFEntrega.Value.Date.ToString() + "' = dFechaEntrega AND bEnviadoCEN=0");
                    result = this.dsClientes1.ListaAccionesMarkClientes.Select("sIdAccion='" + this.txtAccsIdAccion.Text.ToString() + "' and tFechaEntrega = '" + this.dtpAccFEntrega.Value.Date.ToString().Substring(0, 10) + "' AND bEnviadoCEN=0");
                    
                    if (result.Length >0) 
					{
						rwAcc = (GESTCRM.Formularios.DataSets.dsClientes.ListaAccionesMarkClientesRow)result.GetValue(0); 
						record = GESTCRM.Utiles.Buscar_fila_dtTabla(this.dsClientes1.ListaAccionesMarkClientes  ,"sIdAccion",this.txtAccsIdAccion.Text.ToString(),"dFechaEntrega",rwAcc.dFechaEntrega.ToString()    );
						fila = GESTCRM.Utiles.Buscar_filaDataGrid(this,this.dgAccionesMark,"sIdAccion",this.txtAccsIdAccion.Text.ToString(),"dFechaEntrega",rwAcc.dFechaEntrega.ToString()    );
					}
//					int record = GESTCRM.Utiles.Buscar_fila_dtTabla(this.dsClientes1.ListaAccionesMarkClientes  ,"sIdAccion",this.dgAccionesMark[this.dgAccionesMark.CurrentRowIndex,0].ToString());
//					int fila = GESTCRM.Utiles.Buscar_filaDataGrid(this,this.dgAccionesMark,"sIdAccion",this.dgAccionesMark[this.dgAccionesMark.CurrentRowIndex,0].ToString());
					if(fila > -1)
					{
						int SelFila = fila;
						if(fila>0) SelFila=fila-1;
						//						if(this.dtAccionesMark.Rows.Count-1==0) SelFila = -1;
						if(this.dsClientes1.ListaAccionesMarkClientes.Rows.Count-1==0) SelFila = -1;
						this.dgAccionesMark.CurrentRowIndex=SelFila;
						GESTCRM.Utiles.Seleccionar_UnaFilaDataGrid(this,this.dgAccionesMark,SelFila);
						
						if (!this.dsClientes1.ListaAccionesMarkClientes[record].nuevo )
						{
							this.dsClientes1.ListaAccionesMarkClientes[record].dFUM=DateTime.Now;
							this.dsClientes1.ListaAccionesMarkClientes[record].iEstado=-1;
							this.dsClientes1.ListaAccionesMarkClientes[record].bEnviadoCen = false; 
						}
						else
						{
							this.dsClientes1.ListaAccionesMarkClientes.Rows.RemoveAt(record);  
						}
						
						//						this.dtAccionesMark.Rows.RemoveAt(fila);
						//						this.lblTotAcciones.Text = this.dtAccionesMark.Rows.Count.ToString();
						this.lblTotAcciones.Text=this.dsClientes1.ListaAccionesMarkClientes.DefaultView.Count.ToString();
						Nueva_Accion();
					}
					else
					{
						Mensajes.ShowExclamation("No se pueden eliminar Acciones de Marketing enviadas a Central");
					}
				}
			}
			catch(Exception ex) { Mensajes.ShowError(ex.Message); }
		}
		#endregion

		#region Actualizar_Accion
		private void Actualizar_Accion()
        {
			DataRow[] result=null;
			GESTCRM.Formularios.DataSets.dsClientes.ListaAccionesMarkClientesRow rwAcc = null;     
			int record=-1;
			int fila=-1;
			try
			{
				if(Validar_Accion())
				{
//					int fila = GESTCRM.Utiles.Buscar_fila_dtTabla(this.dtAccionesMark,"sIdAccion",this.txtAccsIdAccion.Text.ToString());
					//result = this.dsClientes1.ListaAccionesMarkClientes.Select("sIdAccion='"+this.txtAccsIdAccion.Text.ToString()+"' and '"+this.dtpAccFEntrega.Value.Date.ToString()+"' = dFechaEntrega");   
                    
                    //RH
                    result = this.dsClientes1.ListaAccionesMarkClientes.Select(String.Format("sIdAccion='{0}' AND tFechaEntrega='{1:dd/MM/yyyy}'", this.txtAccsIdAccion.Text, this.dtpAccFEntrega.Value));   
					
                    if (result.Length >0) 
					{
						rwAcc = (GESTCRM.Formularios.DataSets.dsClientes.ListaAccionesMarkClientesRow)result.GetValue(0); 
						record = GESTCRM.Utiles.Buscar_fila_dtTabla(this.dsClientes1.ListaAccionesMarkClientes  ,"sIdAccion",this.txtAccsIdAccion.Text.ToString(),"dFechaEntrega",rwAcc.dFechaEntrega.ToString()    );
						fila = GESTCRM.Utiles.Buscar_filaDataGrid(this,this.dgAccionesMark,"sIdAccion",this.txtAccsIdAccion.Text,"dFechaEntrega",rwAcc.dFechaEntrega.ToString()    );
					}

					//if((record==-1) || ( record!=-1 && (DateTime.Parse( this.dsClientes1.ListaAccionesMarkClientes.Rows[record]["dFechaEntrega"].ToString()).ToString("dd/MM/yyyy")!=this.dtpAccFEntrega.Value.Date.ToString("dd/MM/yyyy")) && bool.Parse( dsClientes1.ListaAccionesMarkClientes.Rows[record]["bEnviadoCen"].ToString() )     ))
                    //RH
                    if ((record == -1) || 
                        (record != -1 && (DateTime.Parse(this.dsClientes1.ListaAccionesMarkClientes.Rows[record]["dFechaEntrega"].ToString()).Date != this.dtpAccFEntrega.Value) && bool.Parse(dsClientes1.ListaAccionesMarkClientes.Rows[record]["bEnviadoCen"].ToString())))
					{
//						DataRow dvfila= this.dtAccionesMark.NewRow();
						DataRow dvfila= this.dsClientes1.ListaAccionesMarkClientes.NewRow();
						dvfila["iIdAccion"]=this.Var_iIdAccion;
						dvfila["sIdAccion"]=this.txtAccsIdAccion.Text.ToString();
                        
                        //RH
                        dvfila["dFechaEntrega"] = dtpAccFEntrega.Value; //this.dtpAccFEntrega.Value.Date.ToString("dd/MM/yyyy");
                        dvfila["tFechaEntrega"] = this.dtpAccFEntrega.Value.ToString("dd/MM/yyyy");
						
                        dvfila["fCantidad"]=Convert.ToInt32(this.nupAccCantidad.Value);
						dvfila["tObservEntrega"]=this.txtAccObservEntrega.Text;
						dvfila["dFUM"]=DateTime.Now;
						dvfila["iEstado"]=0;
						dvfila["bEnviadoCen"]=false;
					
//						this.dtAccionesMark.Rows.Add(dvfila);
						this.dsClientes1.ListaAccionesMarkClientes.Rows.Add(dvfila);
					
//						fila = this.dtAccionesMark.Rows.Count-1;
						fila = this.dsClientes1.ListaAccionesMarkClientes.DefaultView.Count-1;
					}
					else
					{
						//solo será posible modificar si no ha sido enviada
//						if (!this.dsClientes1.ListaAccionesMarkClientes[record].bEnviadoCen)
//						{
                        this.dsClientes1.ListaAccionesMarkClientes.Rows[fila]["dFechaEntrega"] = this.dtpAccFEntrega.Value; // this.dtpAccFEntrega.Value.Date.ToString("dd/MM/yyyy");
						if (bool.Parse( dsClientes1.ListaAccionesMarkClientes.Rows[fila]["bEnviadoCen"].ToString() ) && fila != record)
						{
							this.dsClientes1.ListaAccionesMarkClientes.Rows[fila]["fCantidad"]=int.Parse(this.dsClientes1.ListaAccionesMarkClientes.Rows[fila]["fCantidad"].ToString() ) + Convert.ToInt32(this.nupAccCantidad.Value);
						}
						else
						{
							this.dsClientes1.ListaAccionesMarkClientes.Rows[fila]["fCantidad"]=Convert.ToInt32(this.nupAccCantidad.Value);
						}
							this.dsClientes1.ListaAccionesMarkClientes.Rows[fila]["tObservEntrega"]=this.txtAccObservEntrega.Text;
							dsClientes1.ListaAccionesMarkClientes.Rows[fila]["dFUM"]= DateTime.Now;
							dsClientes1.ListaAccionesMarkClientes.Rows[fila]["bEnviadoCen"]=false;
							this.dsClientes1.ListaAccionesMarkClientes[record]["iEstado"]=this.Var_iEstado;   
//						}
//						else
//						{
//							Mensajes.ShowExclamation("Las acciones de marketing una vez anviadas\na Central no pueden ser modificadas");  
//						}
					}
					this.dgAccionesMark.CurrentRowIndex= fila;
					GESTCRM.Utiles.Seleccionar_UnaFilaDataGrid(this,this.dgAccionesMark,fila);

//					this.lblTotAcciones.Text = this.dtAccionesMark.Rows.Count.ToString();
					this.lblTotAcciones.Text = this.dsClientes1.ListaAccionesMarkClientes.DefaultView.Count.ToString();
					Nueva_Accion();
				}
			}
			catch(Exception ex) { Mensajes.ShowError(ex.Message); }
		}
		#endregion 

		#region Validar_Accion
		private bool Validar_Accion()
		{
			bool resultado = true;
			try
			{
				if(this.txtAccsIdAccion.Text.ToString().Length==0 || this.Var_iIdAccion==-1)
				{
					Mensajes.ShowError("Campo Acción Obligatorio. ");
					return false;
				}
				if(this.dtpAccFEntrega.Value.ToString().Length==0)
				{
					Mensajes.ShowError("Campo Fecha Entrega Obligatorio. ");
					return false;
				}

			}
			catch(Exception e)
			{
				Mensajes.ShowError(e.Message);
				resultado = false;
			}
			return resultado;
		}
		#endregion


		#region btSalir_Click
		private void btSalir_Click(object sender, System.EventArgs e)
		{	
			this.Close();
		}
		#endregion

		#region frmManClientesSAP_Closing
		private void frmManClientesSAP_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			try
			{
				if(this.Param_TipoAcceso!="C" && this.Param_iIdCliente>-1 && !SalirDesdeGuardar)
				{

					DialogResult dr1=Mensajes.ShowQuestion(3002);
					if(dr1 == System.Windows.Forms.DialogResult.Yes)
					{
						if(Guardar_Cliente())
						{
							Mensajes.ShowInformation(3004);
						}
						else
						{
							e.Cancel=true;
						}

					}
				}
			}
			catch(Exception ex) {Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region frmManClientesSAP_Closed
		private void frmManClientesSAP_Closed(object sender, System.EventArgs e)
		{
			this.Dispose();
		}
		#endregion


		#region btGrabar_Click
		private void btGrabar_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (this.Param_TipoAcceso=="M")
				{
					if(Guardar_Cliente())
					{
						Mensajes.ShowInformation(3004);
//						if(dr == System.Windows.Forms.DialogResult.Yes)
//						{
							this.SalirDesdeGuardar=true;
							this.Close();
//						}
					}
				}
			}
			catch(Exception ex) {Mensajes.ShowError(ex.Message);}
		}
		#endregion


		#region Set ClienteRed
		/// <summary>
		/// Inserta/Actualiza los Datos en la Tabla ClientesRedes
		/// </summary>
		/// <param name="SqlTrans">Objeto Transaccion para ejecutar el comando</param>
		/// <returns>True si se graban los datos correctamente, 0 en caso contrario</returns>
		private bool SetClienteRed(System.Data.SqlClient.SqlTransaction SqlTrans)
		{
			bool bSuccess=true;
			try
			{
				GESTCRM.Formularios.DataSets.dsClientes.ListaClienteRedDataTable dt =(GESTCRM.Formularios.DataSets.dsClientes.ListaClienteRedDataTable)this.dsClientes1.ListaClienteRed.GetChanges();

				if ((dt!=null && dt.Rows.Count  >0) && dt[0].sIdRed == GESTCRM.Clases.Configuracion.sIdRed  )
				{
					this.sqlCmdSetClienteRed.Transaction = SqlTrans;
					this.sqlCmdSetClienteRed.Parameters["@iIdCliente"].Value = Param_iIdCliente;
					this.sqlCmdSetClienteRed.Parameters["@sIdRed"].Value =dt[0].sIdRed.ToString();    
					this.sqlCmdSetClienteRed.Parameters["@sIdClasificacion"].Value =dt[0].sIdClasificacion; 
					this.sqlCmdSetClienteRed.Parameters["@dFAR"].Value =DateTime.Now;
					this.sqlCmdSetClienteRed.Parameters["@dFBR"].Value = System.Data.SqlTypes.SqlDateTime.Null; 
					this.sqlCmdSetClienteRed.Parameters["@iEstado"].Value =dt[0].iEstado; 

					this.sqlCmdSetClienteRed.ExecuteScalar();

					bSuccess = (!Convert.ToBoolean( this.sqlCmdSetClienteRed.Parameters["@RETURN_VALUE"].Value));
				}


			}
			catch(Exception e)
			{
				Mensajes.ShowError("Error en Actualización de tabla ClientesRedes\n\n"+e.Message.ToString()); 
				bSuccess=false;
			}
			return bSuccess;
		}
		#endregion
		#region SetCentros
		private bool SetCentros(System.Data.SqlClient.SqlTransaction SqlTrans)
		{
			bool bSuccess=true;
			try
			{
                //---- GSG (30/05/2013) 
                //GESTCRM.Formularios.DataSets.dsClientes.ListaCentros_porCliente_SAPDataTable dt =(GESTCRM.Formularios.DataSets.dsClientes.ListaCentros_porCliente_SAPDataTable)this.dsClientes1.ListaCentros_porCliente_SAP.GetChanges();

                //if ((dt!=null && dt.Rows.Count  >0))
                //{
                //    this.sqlCmdSetCentrosClienteSAP.Transaction =SqlTrans;

                //    foreach(Formularios.DataSets.dsClientes.ListaCentros_porCliente_SAPRow rw in dt.Rows)
                //    {
                //        if (rw.RowState!=DataRowState.Deleted  )
                //        {
                //            this.sqlCmdSetCentrosClienteSAP.Parameters["@iAccion"].Value=(rw.RowState==DataRowState.Added)?0:2;
                //            this.sqlCmdSetCentrosClienteSAP.Parameters["@iIdCliente"].Value =this.Param_iIdCliente;
                //            this.sqlCmdSetCentrosClienteSAP.Parameters["@iIdCentro"].Value=rw.iIdCentro;

                //            this.sqlCmdSetCentrosClienteSAP.ExecuteScalar();

                //            bSuccess = (!Convert.ToBoolean( this.sqlCmdSetCentrosClienteSAP.Parameters["@RETURN_VALUE"].Value));

                //            if (!bSuccess) break;
                //        }
                //    }
                //}



                GESTCRM.Formularios.DataSets.dsClientes.ListaProgInf_porCliente_SAPDataTable dt = (GESTCRM.Formularios.DataSets.dsClientes.ListaProgInf_porCliente_SAPDataTable)this.dsClientes1.ListaProgInf_porCliente_SAP.GetChanges();

                if ((dt != null && dt.Rows.Count > 0))
                {
                    this.sqlCmdSetProgInfClientesSAP.Transaction = SqlTrans;

                    foreach (Formularios.DataSets.dsClientes.ListaProgInf_porCliente_SAPRow rw in dt.Rows)
                    {
                        if (rw.RowState != DataRowState.Deleted)
                        {
                            this.sqlCmdSetProgInfClientesSAP.Parameters["@iIdCliente"].Value = this.Param_iIdCliente;
                            this.sqlCmdSetProgInfClientesSAP.Parameters["@iIdCentro"].Value = rw.iIdCentro;

                            this.sqlCmdSetProgInfClientesSAP.Parameters["@dFAR"].Value = "";
                            this.sqlCmdSetProgInfClientesSAP.Parameters["@dFBR"].Value = !rw.IsdFBRNull() ? rw.dFBR : System.Data.SqlTypes.SqlDateTime.Null;
                            this.sqlCmdSetProgInfClientesSAP.Parameters["@iEstado"].Value = rw.iEstado;

                            this.sqlCmdSetProgInfClientesSAP.ExecuteScalar();

                            bSuccess = (!Convert.ToBoolean(this.sqlCmdSetProgInfClientesSAP.Parameters["@RETURN_VALUE"].Value));

                            if (!bSuccess) break;
                        }
                    }
                }

                //---- FI GSG
			}
			catch(Exception e)
			{
				Mensajes.ShowError("Error en Actualización de tabla CentrosClientes_SAP al almacenar el programa informático\n\n"+e.Message.ToString()); 
				bSuccess=false;
			}
			return bSuccess;
		}

		#endregion
		#region SetContactos
		private bool SetContactos(System.Data.SqlClient.SqlTransaction SqlTrans)
		{
			bool bSuccess=true;
			try
			{
                //---- GSG (28/05/2013)
                //GESTCRM.Formularios.DataSets.dsClientes.ListaContactos_porCliente_SAPDataTable dt =(GESTCRM.Formularios.DataSets.dsClientes.ListaContactos_porCliente_SAPDataTable)this.dsClientes1.ListaContactos_porCliente_SAP.GetChanges();

                //if ((dt!=null && dt.Rows.Count  >0))
                //{
                //    this.sqlCmdSetContactosClientesSAP.Transaction =SqlTrans;

                //    foreach(Formularios.DataSets.dsClientes.ListaContactos_porCliente_SAPRow rw in dt.Rows)
                //    {
                //        if (rw.RowState!=DataRowState.Deleted  )
                //        {
                //            this.sqlCmdSetContactosClientesSAP.Parameters["@iIdCliente"].Value =this.Param_iIdCliente;
                //            this.sqlCmdSetContactosClientesSAP.Parameters["@iIdContacto"].Value= rw.iIdContacto;
                //            this.sqlCmdSetContactosClientesSAP.Parameters["@sNombre"].Value = rw.sNombre;
                //            this.sqlCmdSetContactosClientesSAP.Parameters["@sIdCargoContacto"].Value = rw.sIdCargoContacto;
                //            //---- GSG (10/05/2011)
                //            //this.sqlCmdSetContactosClientesSAP.Parameters["@dFAR"].Value=rw.dFAR;
                //            this.sqlCmdSetContactosClientesSAP.Parameters["@dFAR"].Value = "";
                //            //---- FI GSG
                //            this.sqlCmdSetContactosClientesSAP.Parameters["@dFBR"].Value=!rw.IsdFBRNull()?rw.dFBR:System.Data.SqlTypes.SqlDateTime.Null;
                //            this.sqlCmdSetContactosClientesSAP.Parameters["@iEstado"].Value=rw.iEstado;

                //            this.sqlCmdSetContactosClientesSAP.ExecuteScalar();

                //            bSuccess = (!Convert.ToBoolean( this.sqlCmdSetContactosClientesSAP.Parameters["@RETURN_VALUE"].Value));

                //            if (!bSuccess) break;
                //        }
                //    }
                //}


                GESTCRM.Formularios.DataSets.dsClientes.ListaAreas_porCliente_SAPDataTable dt = (GESTCRM.Formularios.DataSets.dsClientes.ListaAreas_porCliente_SAPDataTable) this.dsClientes1.ListaAreas_porCliente_SAP.GetChanges();

                if ((dt != null && dt.Rows.Count > 0))
                {
                    this.sqlCmdSetAreasClientesSAP.Transaction = SqlTrans;

                    foreach (Formularios.DataSets.dsClientes.ListaAreas_porCliente_SAPRow rw in dt.Rows)
                    {
                        if (rw.RowState != DataRowState.Deleted)
                        {
                            this.sqlCmdSetAreasClientesSAP.Parameters["@iIdCliente"].Value = this.Param_iIdCliente;
                            this.sqlCmdSetAreasClientesSAP.Parameters["@iIdContacto"].Value = rw.iIdContacto;
                            this.sqlCmdSetAreasClientesSAP.Parameters["@sNombre"].Value = rw.sNombre;
                            this.sqlCmdSetAreasClientesSAP.Parameters["@sIdCargoContacto"].Value = "46";
                            this.sqlCmdSetAreasClientesSAP.Parameters["@dFAR"].Value = "";
                            this.sqlCmdSetAreasClientesSAP.Parameters["@dFBR"].Value = !rw.IsdFBRNull() ? rw.dFBR : System.Data.SqlTypes.SqlDateTime.Null;
                            this.sqlCmdSetAreasClientesSAP.Parameters["@iEstado"].Value = rw.iEstado;

                            this.sqlCmdSetAreasClientesSAP.ExecuteScalar();

                            bSuccess = (!Convert.ToBoolean(this.sqlCmdSetAreasClientesSAP.Parameters["@RETURN_VALUE"].Value));

                            if (!bSuccess) break;
                        }
                    }
                }

                //---- FI GSG

			}
			catch(Exception e)
			{
				Mensajes.ShowError("Error en Actualización de tabla ContactosClientes_SAP\n\n"+e.Message.ToString()); 
				bSuccess=false;
			}
			return bSuccess;
		}

		#endregion
		#region SetAccionesMarkClientes
		/// <summary>
		/// Inserta/Actualiza los Datos en la Tabla AficClientes_COM
		/// </summary>
		/// <param name="SqlTrans">Objeto Transaccion para ejecutar el comando</param>
		/// <returns>True si se graban los datos correctamente, 0 en caso contrario</returns>
		private bool SetAccionesMarkClientes(System.Data.SqlClient.SqlTransaction SqlTrans)
		{
			bool bSuccess=true;
			try
			{
				GESTCRM.Formularios.DataSets.dsClientes.ListaAccionesMarkClientesDataTable   dt =(GESTCRM.Formularios.DataSets.dsClientes.ListaAccionesMarkClientesDataTable)this.dsClientes1.ListaAccionesMarkClientes.GetChanges();

				if (dt!=null && dt.Rows.Count  >0 )
				{
					this.sqlCmdSetAccionesMarkClientes.Transaction = SqlTrans;

					foreach (GESTCRM.Formularios.DataSets.dsClientes.ListaAccionesMarkClientesRow   dr in dt.Rows)
					{

						if (dr.RowState!=DataRowState.Deleted )
						{
							this.sqlCmdSetAccionesMarkClientes.Parameters["@iIdCliente"].Value = this.Param_iIdCliente; 
							this.sqlCmdSetAccionesMarkClientes.Parameters["@iIdAccion"].Value = dr.iIdAccion;
							this.sqlCmdSetAccionesMarkClientes.Parameters["@dFechaEntrega"].Value=dr.dFechaEntrega;
							this.sqlCmdSetAccionesMarkClientes.Parameters["@fCantidad"].Value=dr.fCantidad;
							this.sqlCmdSetAccionesMarkClientes.Parameters["@tObservaciones"].Value=dr.IstObservEntregaNull()?System.Data.SqlTypes.SqlString.Null:dr.tObservEntrega;
							this.sqlCmdSetAccionesMarkClientes.Parameters["@sCoste"].Value=System.Data.SqlTypes.SqlString.Null;
							this.sqlCmdSetAccionesMarkClientes.Parameters["@dFUM"].Value= DateTime.Now;
							this.sqlCmdSetAccionesMarkClientes.Parameters["@iEstado"].Value=dr.iEstado;
							this.sqlCmdSetAccionesMarkClientes.Parameters["@bEnviadoCen"].Value =0;
						
							this.sqlCmdSetAccionesMarkClientes.ExecuteScalar();

							bSuccess = (!Convert.ToBoolean (this.sqlCmdSetAccionesMarkClientes.Parameters["@RETURN_VALUE"].Value));
						}
						if (!bSuccess) break;
					}
				}

			}
			catch(Exception e)
			{
				Mensajes.ShowError("Error en Actualización de tabla AccionesMarkClientes\n\n"+e.Message.ToString()); 
				bSuccess=false;
			}
			return bSuccess;
		}
		#endregion

		#region Guardar_Cliente
		private bool Guardar_Cliente()
		{
			bool resultado=true;

            //---- GSG (03/07/2019)
            //-- Si hay encuesta obligatoria y no se ha contestado no se puede guardar el pedido
            Encuestas(false);
            if (!_bEncuesta)
            {
                Mensajes.ShowError("No se guardará la ficha del cliente hasta que haya contestado la encuesta.");
                return false;
            }



            Cursor.Current = Cursors.WaitCursor;
			if (this.sqlConn.State==ConnectionState.Closed )this.sqlConn.Open();
			this.sqlTran = this.sqlConn.BeginTransaction();


			// Se cancela la edicion de todos los controles para reflejar
			// los cambios en los DataTables y poder recogerlos con el DataTable.GetChanges
			foreach(DataTable dt in this.dsClientes1.Tables )
			{
				foreach(DataRow dr in dt.Rows ) dr.EndEdit();
			}

			try
			{
				resultado = SetClienteRed(this.sqlTran) && this.SetAccionesMarkClientes(sqlTran) && this.SetCentros(sqlTran) && this.SetContactos(sqlTran);
				//Marcar Cliente como Modificado
				//this.sqlCmdSetCliente.Parameters["@Accion"].Value=1;
				//this.sqlCmdSetCliente.Parameters["@iIdCliente"].Value=this.Param_iIdCliente;
//				if (SetClienteRed(this.sqlTran))
//				{
//
//					//Borrar Contactos
//					this.sqlCmdSetContactosClientesSAP.Parameters["@iAccion"].Value=2;
//					this.sqlCmdSetContactosClientesSAP.Parameters["@iIdCliente"].Value=this.Param_iIdCliente;
//					this.sqlCmdSetContactosClientesSAP.ExecuteNonQuery();
//
//					//Actualizar Contactos
//					for(int i=0;i<this.dtContactos.Rows.Count;i++)
//					{
//						this.sqlCmdSetContactosClientesSAP.Parameters["@iAccion"].Value=0;
//						this.sqlCmdSetContactosClientesSAP.Parameters["@iIdCliente"].Value=this.Param_iIdCliente;
//						this.sqlCmdSetContactosClientesSAP.Parameters["@sNombre"].Value=this.dtContactos.Rows[i]["sNombre"].ToString();
//						this.sqlCmdSetContactosClientesSAP.Parameters["@sIdCargoContacto"].Value=this.dtContactos.Rows[i]["sIdCargoContacto"].ToString();
//
//						this.sqlCmdSetContactosClientesSAP.ExecuteNonQuery();
//					}
//
//					//Borrar Centros
//					DataTable dtCentrosOrigen = GESTCRM.Utiles.Inicializar_Tabla(this.dsClientes1.ListaCentros_porCliente_SAP);
//					int fila = -1;
//					for(int i=0;i<dtCentrosOrigen.Rows.Count;i++)
//					{
//						fila = Utiles.Buscar_fila_dtTabla(this.dtCentros,"iIdCentro",dtCentrosOrigen.Rows[i]["iIdCentro"].ToString());
//						if(fila==-1)
//						{
//							this.sqlCmdSetCentrosClienteSAP.Parameters["@iAccion"].Value=2;
//							this.sqlCmdSetCentrosClienteSAP.Parameters["@iIdCliente"].Value=this.Param_iIdCliente;
//							this.sqlCmdSetCentrosClienteSAP.Parameters["@iIdCentro"].Value=int.Parse(dtCentrosOrigen.Rows[i]["iIdCentro"].ToString());
//
//							this.sqlCmdSetCentrosClienteSAP.ExecuteNonQuery();
//						}
//					}
//
//					//Actualizar Centros
//					fila=-1;
//					for(int i=0;i<this.dtCentros.Rows.Count;i++)
//					{
//						fila = Utiles.Buscar_fila_dtTabla(dtCentrosOrigen,"iIdCentro",this.dtCentros.Rows[i]["iIdCentro"].ToString());
//						if(fila==-1)
//						{
//							this.sqlCmdSetCentrosClienteSAP.Parameters["@iAccion"].Value=0;
//							this.sqlCmdSetCentrosClienteSAP.Parameters["@iIdCliente"].Value=this.Param_iIdCliente;
//							this.sqlCmdSetCentrosClienteSAP.Parameters["@iIdCentro"].Value=int.Parse(this.dtCentros.Rows[i]["iIdCentro"].ToString());
//
//							this.sqlCmdSetCentrosClienteSAP.ExecuteNonQuery();
//						}
//					}
//
//					//Borrar Acciones Existentes
//					this.sqlCmdSetAccionesMarkClientes.Parameters["@iAccion"].Value=2;
//					this.sqlCmdSetAccionesMarkClientes.Parameters["@iIdCliente"].Value=this.Param_iIdCliente;
//					this.sqlCmdSetAccionesMarkClientes.ExecuteNonQuery();
//
//					//Grabar Acciones
//					for(int i=0;i<this.dtAccionesMark.Rows.Count;i++)
//					{
//						this.sqlCmdSetAccionesMarkClientes.Parameters["@iAccion"].Value=0;
//						this.sqlCmdSetAccionesMarkClientes.Parameters["@iIdCliente"].Value=this.Param_iIdCliente;
//						this.sqlCmdSetAccionesMarkClientes.Parameters["@iIdAccion"].Value=int.Parse(this.dtAccionesMark.Rows[i]["iIdAccion"].ToString());
//						this.sqlCmdSetAccionesMarkClientes.Parameters["@dFechaEntrega"].Value=DateTime.Parse(this.dtAccionesMark.Rows[i]["dFechaEntrega"].ToString()).Date;
//						this.sqlCmdSetAccionesMarkClientes.Parameters["@fCantidad"].Value=int.Parse(this.dtAccionesMark.Rows[i]["fCantidad"].ToString());
//						this.sqlCmdSetAccionesMarkClientes.Parameters["@tObservaciones"].Value=this.dtAccionesMark.Rows[i]["tObservEntrega"].ToString();
//
//						this.sqlCmdSetAccionesMarkClientes.ExecuteNonQuery();
//					}
//

             

				if (resultado)
				{
					this.sqlTran.Commit(); 
					this.SalirDesdeGuardar=true;
				}
				else
				{
					sqlTran.Rollback();
				}
				//}
			}
			catch(Exception e)
			{
				Mensajes.ShowError(e.Message);
				this.sqlTran.Rollback();
				resultado=false;
			}
			finally
			{
				if (this.sqlConn.State==ConnectionState.Open )this.sqlConn.Close();
			}

			Cursor.Current = Cursors.Default;

			return resultado;
		}
		#endregion

		#region Activar_Formulario
		private void Activar_Formulario()
		{
			try
			{
				if(this.Param_TipoAcceso=="C")
				{
//					Utiles.Activar_Panel(this.pnlAcciones,false);
					this.ucBotoneraSecundaria1.Activar_botonera(true,false,false,false,false,false);
					Utiles.Activar_Panel(this.pnCentros,false);
					Utiles.Activar_Panel(this.pnAccionesMark,false);
				}
			}
			catch(Exception ex) { Mensajes.ShowError(ex.Message); }
		}
		#endregion


		private void cboClasificacion_SelectedIndexChanged(object sender, System.EventArgs e)
		{

            if (this.dsClientes1.ListaClienteRed.Rows.Count > 0)
            {
                this.dsClientes1.ListaClienteRed[0].sIdClasificacion = this.cboClasificacion.SelectedValue.ToString();
            }
        }

		private void dtpAccFEntrega_ValueChanged(object sender, System.EventArgs e)
		{
			this.nupAccCantidad.Value = this.nupAccCantidad.Minimum;
			this.txtAccObservEntrega.Text = null;

		}

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void txtProvincia_SAP_TextChanged(object sender, EventArgs e)
        {

        }

        //---- GSG (03/07/2019)
        private void btEncuestas_Click(object sender, EventArgs e)
        {
            Encuestas(true);
        }

        private void Encuestas(bool abrir)
        {
            if (this.txtsIdCliente_SAP.Text.Trim() != "")
            {
                frmEncuesta frmEnc = new frmEncuesta(Param_iIdDelegado, this.txtsIdCliente_SAP.Text);

                if (frmEnc.HayQueHacerlaSiOSi() || abrir)
                {
                    frmEnc.ShowDialog(this);

                    if (frmEnc.DialogResult == DialogResult.OK)
                    {
                        _bEncuesta = true;
                    }
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

