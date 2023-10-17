using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace GESTCRM.Formularios
{
	/// <summary>
	/// Formulario para crear nuevos Médicos.
	/// </summary>
	public class frmAltaMedicos : System.Windows.Forms.Form
	{
		
		bool SalirDesdeGuardar;
		bool Saved;

		string Param_TipoAcceso;
		int Param_iIdCliente;
		int Param_iIdDelegado;
        //int Param_Inicio;
		int Var_iIdCentro;
		int Var_iIdAccion;
		string Var_sIdProd;
		string Param_sIdClienteTemp;
		string Param_NombreRed;
		int Param_iEstado;

		bool textDeleted = false;
		bool fNacChanged = false;
		bool fMatChanged = false;
		bool fNacData = false;
		bool fMatData = false;
		//		DataTable dtCentros;
		//		DataTable dtAccionesMark;



		
		private GESTCRM.Controles.ucBotoneraSecundaria ucBotoneraSecundaria1;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Panel pnCliente;
		private GESTCRM.Controles.LabelGradient lblTitulo;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.Label label29;
		private System.Windows.Forms.Label label31;
		private System.Windows.Forms.TextBox txtNombre;
		private System.Windows.Forms.TextBox txtApe1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtApe2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtNumCol1;
		private System.Windows.Forms.TextBox txtNumCol3;
		private System.Windows.Forms.ComboBox cmbTipoMedico;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox cmbClasif;
		private System.Windows.Forms.TextBox txtDireccion;
		private System.Windows.Forms.TextBox txtCP;
		private System.Windows.Forms.Button btBuscarPob;
		private System.Windows.Forms.Panel pnlDatosSec;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.DataGrid dgEspecialidades;
		private GESTCRM.Controles.LabelGradient labelGradient1;
		private System.Windows.Forms.ComboBox cbEspecialidades;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Button btEliminarEspec;
		private System.Windows.Forms.Button btActualizarEspec;
		private System.Windows.Forms.Panel pnlCentros;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ComboBox cmbRelacion;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button btClienteActualizar;
		private System.Windows.Forms.Button btClienteEliminar;
		private System.Windows.Forms.TextBox txtsCentro;
		private System.Windows.Forms.Button btBuscarCentro;
		private System.Windows.Forms.TextBox txtsIdCentro;
		private System.Windows.Forms.DataGrid dgCentros;
		private GESTCRM.Controles.LabelGradient labelGradient3;
		private System.Windows.Forms.Panel panel1;
		private GESTCRM.Controles.LabelGradient labelGradient2;
		private System.Windows.Forms.DataGrid dgProductos;
		private System.Windows.Forms.Button btEliminarProd;
		private System.Windows.Forms.Button btActualizarProd;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.NumericUpDown udPrioridad;
		private System.Windows.Forms.Panel panel8;
		private System.Windows.Forms.DataGrid dgAccionesMark;
		private GESTCRM.Controles.LabelGradient labelGradient4;
		private System.Windows.Forms.Button btBuscaAccion;
		private System.Windows.Forms.TextBox txtAccObservEntrega;
		private System.Windows.Forms.NumericUpDown nupAccCantidad;
		private System.Windows.Forms.DateTimePicker dtpAccFEntrega;
		private System.Windows.Forms.TextBox txtAccsIdAccion;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Button btActualizarAccion;
		private System.Windows.Forms.Button btEliminarAccion;
		private System.Windows.Forms.Panel panel9;
		private GESTCRM.Controles.LabelGradient labelGradient5;
		private System.Windows.Forms.DataGrid dgAficiones;
		private System.Windows.Forms.ComboBox cmbAficiones;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox txtTelefono;
		private System.Windows.Forms.TextBox txtMovil;
		private System.Windows.Forms.TextBox txtFax;
		private System.Windows.Forms.TextBox txtEMail;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.DateTimePicker dtFechaNac;
		private System.Windows.Forms.DateTimePicker dtFechaAniv;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.TextBox txtObsMedico;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem menuNuevo;
		private System.Windows.Forms.MenuItem menuEliminar;
		private GESTCRM.Formularios.DataSets.dsAltaMedicos  dsClientes1;
        private GESTCRM.Formularios.DataSets.dsClientes dsClientes2;
		private System.Data.SqlClient.SqlDataAdapter sqlDATipoMedico;
		private System.Data.SqlClient.SqlCommand sqlCmdListaTipoMedico;
		private System.Data.SqlClient.SqlConnection sqlConn;
		private System.Data.SqlClient.SqlDataAdapter sqlDAClasificacion;
		private System.Data.SqlClient.SqlCommand sqlSCmdClasif;
		private System.Data.SqlClient.SqlDataAdapter sqlDARelacionCliCen;
		private System.Data.SqlClient.SqlCommand sqlSCmdTipoRelacion;
		private System.Data.SqlClient.SqlDataAdapter sqlDAEspec;
		private System.Data.SqlClient.SqlCommand sqlSCmdEspecialidades;
		private System.Data.SqlClient.SqlDataAdapter sqlDAAfic;
		private System.Data.SqlClient.SqlCommand sqlSCmdAficiones;
		private System.Windows.Forms.TextBox txtProvincia;
		private System.Windows.Forms.TextBox txtPoblacion;
		private System.Windows.Forms.TextBox txtNumCol2;
		private System.Windows.Forms.Button btBuscarProducto;
		private System.Windows.Forms.Button btActAfic;
		private System.Windows.Forms.Button btElimAfic;
		private System.Windows.Forms.TextBox txtNIF;
		private System.Windows.Forms.TextBox txtProd;
		private System.Data.SqlClient.SqlCommand sqlCmdGetID;
		private System.ComponentModel.IContainer components;
        //---- GSG (07/10/2014)
        private System.Data.SqlClient.SqlDataAdapter sqldaListaAreasporCliente_SAP;
        private System.Data.SqlClient.SqlCommand sqlSelectCommandListaAreasporCliente_SAP;

		private System.Windows.Forms.DataGridTableStyle dataGridTableStyleCentrosCLientesCOM;
		private System.Windows.Forms.DataGridTextBoxColumn dgCentrosiIdCentro;
		private System.Windows.Forms.DataGridTextBoxColumn dgCentrossIdCentro;
		private System.Windows.Forms.DataGridTextBoxColumn dgCentrossDescripcion;
		private System.Windows.Forms.DataGridTextBoxColumn dgCentrossIdTipoRelacionCliCen;
		private System.Windows.Forms.DataGridTextBoxColumn dgCentrostRelacionTipoCliCen;
		private System.Windows.Forms.DataGridTextBoxColumn dgCentrosdFAR;
		private System.Windows.Forms.DataGridTextBoxColumn dgCentrosdFBR;
		private System.Windows.Forms.DataGridTextBoxColumn dgCentrosiEstado;
		private System.Windows.Forms.DataGridTextBoxColumn dgCentrosIdRed;

		private System.Data.SqlClient.SqlCommand sqlCmdGetCentro;
			
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyleEspecCLientesCOM;
		private System.Windows.Forms.DataGridTextBoxColumn dgEspecialidadestEspecialidad;
		private System.Windows.Forms.DataGridTextBoxColumn dgEspecialidadesIdEspecialidad;

		private System.Windows.Forms.DataGridTableStyle dataGridTableStyleProdCLientesCOM;
		private System.Windows.Forms.DataGridTextBoxColumn dgProductosiPrioridad;
		private System.Windows.Forms.DataGridTextBoxColumn dgProductossIdProducto;
		private System.Windows.Forms.DataGridTextBoxColumn dgProductossDescripcion;

		private System.Windows.Forms.DataGridTableStyle dataGridTableStyleAccionesMark;
		private System.Windows.Forms.DataGridTextBoxColumn dgAccionesMarksIdAccion;
		private System.Windows.Forms.DataGridTextBoxColumn dgAccionesMarkdFechaEntrega;
		private System.Windows.Forms.DataGridTextBoxColumn dgAccionesMarkfCantidad;
		private System.Windows.Forms.DataGridTextBoxColumn dgAccionesMarktObservEntrega;
		private System.Windows.Forms.DataGridTextBoxColumn dgAccionesMarkiIdAccion;
		private System.Windows.Forms.DataGridTextBoxColumn dgAccionesMarktFechaEntrega;
		private System.Windows.Forms.DataGridTextBoxColumn dgAccionesMarksCCoste;
		private System.Windows.Forms.DataGridTextBoxColumn dgAccionesMarkdFUM;
		private System.Windows.Forms.DataGridTextBoxColumn dgAccionesMarkiEstado;
		private System.Windows.Forms.DataGridTextBoxColumn dgAccionesMarkbEnviadoCen;

		private System.Windows.Forms.DataGridTableStyle dataGridTableStyleAficiones;
		private System.Windows.Forms.DataGridTextBoxColumn dgAficionestAficion;
		private System.Windows.Forms.Label lblTotProd;
		private System.Windows.Forms.Label lblTotEspec;
		private System.Windows.Forms.Label lblTotCentros;
		private System.Windows.Forms.Label lblTotAcciones;
		private System.Windows.Forms.Label lblTotAficiones;
		private System.Data.SqlClient.SqlCommand sqlCmdSetCliente;
		private System.Data.SqlClient.SqlCommand sqlCmdSetClienteRed;
		private System.Data.SqlClient.SqlDataAdapter sqlDAClienteCOM;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand5;
		private System.Data.SqlClient.SqlCommand sqlCmdSetCliente_COM;
		private System.Data.SqlClient.SqlCommand sqlCmdSetCentrosClientes_COM;
		private System.Data.SqlClient.SqlCommand sqlCmdSetEspecCLiente_COM;
		private System.Data.SqlClient.SqlCommand sqlCmdSetAficClientesCOM;
		private System.Data.SqlClient.SqlCommand sqlCmdSetProdClientesCOM;
		private System.Data.SqlClient.SqlCommand sqlCmdSetAccionesMarkClientes;
        private System.Data.SqlClient.SqlCommand sqlCmdSetAreasClientesSAP; //---- GSG (07/10/2014)
		private System.Data.SqlClient.SqlCommand sqlcmdExisteClienteRed;
		private System.Windows.Forms.DataGridTextBoxColumn dgCentrostRed;
        private Panel panel2;
        private Label lblTotContactosSAP;
        
        private DataGrid dgContactos;
        private DataGridTableStyle dataGridTableStyle1;
        private DataGridTextBoxColumn dataGridTextBoxColumn4;
        private DataGridTextBoxColumn dataGridTextBoxColumn5;
        private DataGridTextBoxColumn dataGridTextBoxColumn6;
        private DataGridTextBoxColumn dataGridTextBoxColumn3;
        private DataGridTextBoxColumn dataGridTextBoxColumn2;
        private DataGridTextBoxColumn dataGridTextBoxColumn1;
        private ComboBox cbContCargo;
        private System.Data.SqlClient.SqlDataAdapter sqldaListaTipoAreasClienteSAP;
        private System.Data.SqlClient.SqlCommand sqlSelectCommandTipoAreasClienteSAP;
        private BindingSource listaAreasporClienteSAPBindingSource;
        private BindingSource listaTipoAreaCliSAPBindingSource;
        private BindingSource listaTipoAreaCliSAPDataTableBindingSource;
		private System.Windows.Forms.DataGridTextBoxColumn dgAficionesIdAficion;

        
		





		public frmAltaMedicos(string TipoAcceso, int iIdCliente)
		{
			InitializeComponent();

			this.Param_TipoAcceso = TipoAcceso;
			this.Param_iIdCliente = iIdCliente;
			//this.Param_Inicio = -1;
		}
		public frmAltaMedicos()
		{
			//
			// Necesario para admitir el Diseñador de Windows Forms
			//
			InitializeComponent();

			//
			// TODO: agregar código de constructor después de llamar a InitializeComponent
			//
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

		#region Código generado por el Diseñador de Windows Forms
		/// <summary>
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido del método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAltaMedicos));
            this.ucBotoneraSecundaria1 = new GESTCRM.Controles.ucBotoneraSecundaria();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.txtNumCol1 = new System.Windows.Forms.TextBox();
            this.txtNumCol2 = new System.Windows.Forms.TextBox();
            this.txtNumCol3 = new System.Windows.Forms.TextBox();
            this.btBuscarPob = new System.Windows.Forms.Button();
            this.btBuscarCentro = new System.Windows.Forms.Button();
            this.btBuscarProducto = new System.Windows.Forms.Button();
            this.btBuscaAccion = new System.Windows.Forms.Button();
            this.pnCliente = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.txtProvincia = new System.Windows.Forms.TextBox();
            this.txtApe2 = new System.Windows.Forms.TextBox();
            this.txtApe1 = new System.Windows.Forms.TextBox();
            this.txtPoblacion = new System.Windows.Forms.TextBox();
            this.txtCP = new System.Windows.Forms.TextBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.cmbClasif = new System.Windows.Forms.ComboBox();
            this.dsClientes1 = new GESTCRM.Formularios.DataSets.dsAltaMedicos();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbTipoMedico = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTitulo = new GESTCRM.Controles.LabelGradient();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.pnlDatosSec = new System.Windows.Forms.Panel();
            this.cbContCargo = new System.Windows.Forms.ComboBox();
            this.dsClientes2 = new GESTCRM.Formularios.DataSets.dsClientes();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.dtFechaAniv = new System.Windows.Forms.DateTimePicker();
            this.dtFechaNac = new System.Windows.Forms.DateTimePicker();
            this.label22 = new System.Windows.Forms.Label();
            this.txtObsMedico = new System.Windows.Forms.TextBox();
            this.txtNIF = new System.Windows.Forms.TextBox();
            this.txtEMail = new System.Windows.Forms.TextBox();
            this.txtFax = new System.Windows.Forms.TextBox();
            this.txtMovil = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtAccObservEntrega = new System.Windows.Forms.TextBox();
            this.txtAccsIdAccion = new System.Windows.Forms.TextBox();
            this.txtProd = new System.Windows.Forms.TextBox();
            this.txtsCentro = new System.Windows.Forms.TextBox();
            this.txtsIdCentro = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbAficiones = new System.Windows.Forms.ComboBox();
            this.btActAfic = new System.Windows.Forms.Button();
            this.btElimAfic = new System.Windows.Forms.Button();
            this.btActualizarAccion = new System.Windows.Forms.Button();
            this.btEliminarAccion = new System.Windows.Forms.Button();
            this.nupAccCantidad = new System.Windows.Forms.NumericUpDown();
            this.dtpAccFEntrega = new System.Windows.Forms.DateTimePicker();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.lblTotAcciones = new System.Windows.Forms.Label();
            this.dgAccionesMark = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyleAccionesMark = new System.Windows.Forms.DataGridTableStyle();
            this.dgAccionesMarkiIdAccion = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dgAccionesMarksIdAccion = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dgAccionesMarkfCantidad = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dgAccionesMarkdFechaEntrega = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dgAccionesMarktObservEntrega = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dgAccionesMarksCCoste = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dgAccionesMarkdFUM = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dgCentrosiEstado = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dgAccionesMarkbEnviadoCen = new System.Windows.Forms.DataGridTextBoxColumn();
            this.labelGradient4 = new GESTCRM.Controles.LabelGradient();
            this.udPrioridad = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btEliminarProd = new System.Windows.Forms.Button();
            this.btActualizarProd = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTotProd = new System.Windows.Forms.Label();
            this.dgProductos = new System.Windows.Forms.DataGrid();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.menuNuevo = new System.Windows.Forms.MenuItem();
            this.menuEliminar = new System.Windows.Forms.MenuItem();
            this.dataGridTableStyleProdCLientesCOM = new System.Windows.Forms.DataGridTableStyle();
            this.dgProductossIdProducto = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dgProductossDescripcion = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dgProductosiPrioridad = new System.Windows.Forms.DataGridTextBoxColumn();
            this.labelGradient2 = new GESTCRM.Controles.LabelGradient();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lblTotEspec = new System.Windows.Forms.Label();
            this.dgEspecialidades = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyleEspecCLientesCOM = new System.Windows.Forms.DataGridTableStyle();
            this.dgEspecialidadesIdEspecialidad = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dgEspecialidadestEspecialidad = new System.Windows.Forms.DataGridTextBoxColumn();
            this.labelGradient1 = new GESTCRM.Controles.LabelGradient();
            this.btEliminarEspec = new System.Windows.Forms.Button();
            this.btActualizarEspec = new System.Windows.Forms.Button();
            this.pnlCentros = new System.Windows.Forms.Panel();
            this.lblTotCentros = new System.Windows.Forms.Label();
            this.dgCentros = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyleCentrosCLientesCOM = new System.Windows.Forms.DataGridTableStyle();
            this.dgCentrosiIdCentro = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dgCentrossIdCentro = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dgCentrossDescripcion = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dgCentrossIdTipoRelacionCliCen = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dgCentrostRelacionTipoCliCen = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dgCentrosdFAR = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dgCentrosdFBR = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dgCentrosIdRed = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dgCentrostRed = new System.Windows.Forms.DataGridTextBoxColumn();
            this.labelGradient3 = new GESTCRM.Controles.LabelGradient();
            this.btClienteActualizar = new System.Windows.Forms.Button();
            this.btClienteEliminar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbRelacion = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbEspecialidades = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgContactos = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn5 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn6 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.lblTotContactosSAP = new System.Windows.Forms.Label();
            this.lblTotAficiones = new System.Windows.Forms.Label();
            this.labelGradient5 = new GESTCRM.Controles.LabelGradient();
            this.dgAficiones = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyleAficiones = new System.Windows.Forms.DataGridTableStyle();
            this.dgAficionestAficion = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dgAficionesIdAficion = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dgAccionesMarktFechaEntrega = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dgAccionesMarkiEstado = new System.Windows.Forms.DataGridTextBoxColumn();
            this.sqlDATipoMedico = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCmdListaTipoMedico = new System.Data.SqlClient.SqlCommand();
            this.sqlConn = new System.Data.SqlClient.SqlConnection();
            this.sqlDAClasificacion = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSCmdClasif = new System.Data.SqlClient.SqlCommand();
            this.sqldaListaAreasporCliente_SAP = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommandListaAreasporCliente_SAP = new System.Data.SqlClient.SqlCommand();
            this.sqlDARelacionCliCen = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSCmdTipoRelacion = new System.Data.SqlClient.SqlCommand();
            this.sqlDAEspec = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSCmdEspecialidades = new System.Data.SqlClient.SqlCommand();
            this.sqlDAAfic = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSCmdAficiones = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdGetID = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdGetCentro = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdSetCliente = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdSetClienteRed = new System.Data.SqlClient.SqlCommand();
            this.sqlDAClienteCOM = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand5 = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdSetCliente_COM = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdSetCentrosClientes_COM = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdSetEspecCLiente_COM = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdSetAficClientesCOM = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdSetAreasClientesSAP = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdSetProdClientesCOM = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdSetAccionesMarkClientes = new System.Data.SqlClient.SqlCommand();
            this.sqlcmdExisteClienteRed = new System.Data.SqlClient.SqlCommand();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.sqldaListaTipoAreasClienteSAP = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommandTipoAreasClienteSAP = new System.Data.SqlClient.SqlCommand();
            this.listaAreasporClienteSAPBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.listaTipoAreaCliSAPBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.listaTipoAreaCliSAPDataTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pnCliente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsClientes1)).BeginInit();
            this.pnlDatosSec.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsClientes2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupAccCantidad)).BeginInit();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgAccionesMark)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udPrioridad)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgProductos)).BeginInit();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgEspecialidades)).BeginInit();
            this.pnlCentros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCentros)).BeginInit();
            this.panel9.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgContactos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgAficiones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listaAreasporClienteSAPBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listaTipoAreaCliSAPBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listaTipoAreaCliSAPDataTableBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ucBotoneraSecundaria1
            // 
            this.ucBotoneraSecundaria1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(117)))), ((int)(((byte)(1)))));
            this.ucBotoneraSecundaria1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucBotoneraSecundaria1.ForeColor = System.Drawing.Color.Black;
            this.ucBotoneraSecundaria1.Location = new System.Drawing.Point(0, 0);
            this.ucBotoneraSecundaria1.Name = "ucBotoneraSecundaria1";
            this.ucBotoneraSecundaria1.Size = new System.Drawing.Size(1263, 38);
            this.ucBotoneraSecundaria1.TabIndex = 0;
            this.ucBotoneraSecundaria1.TabStop = false;
            // 
            // txtNumCol1
            // 
            this.txtNumCol1.BackColor = System.Drawing.Color.White;
            this.txtNumCol1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumCol1.Location = new System.Drawing.Point(90, 64);
            this.txtNumCol1.MaxLength = 2;
            this.txtNumCol1.Name = "txtNumCol1";
            this.txtNumCol1.Size = new System.Drawing.Size(24, 20);
            this.txtNumCol1.TabIndex = 3;
            this.toolTip1.SetToolTip(this.txtNumCol1, "Número de Colegiado en Formato XX-YY-ZZZZ");
            this.txtNumCol1.TextChanged += new System.EventHandler(this.txtNumCol1_TextChanged);
            // 
            // txtNumCol2
            // 
            this.txtNumCol2.BackColor = System.Drawing.Color.White;
            this.txtNumCol2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumCol2.Location = new System.Drawing.Point(122, 64);
            this.txtNumCol2.MaxLength = 2;
            this.txtNumCol2.Name = "txtNumCol2";
            this.txtNumCol2.Size = new System.Drawing.Size(24, 20);
            this.txtNumCol2.TabIndex = 4;
            this.toolTip1.SetToolTip(this.txtNumCol2, "Número de Colegiado en Formato XX-YY-ZZZZ");
            this.txtNumCol2.TextChanged += new System.EventHandler(this.txtNumCol2_TextChanged);
            // 
            // txtNumCol3
            // 
            this.txtNumCol3.BackColor = System.Drawing.Color.White;
            this.txtNumCol3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumCol3.Location = new System.Drawing.Point(154, 64);
            this.txtNumCol3.MaxLength = 5;
            this.txtNumCol3.Name = "txtNumCol3";
            this.txtNumCol3.Size = new System.Drawing.Size(56, 20);
            this.txtNumCol3.TabIndex = 5;
            this.toolTip1.SetToolTip(this.txtNumCol3, "Número de Colegiado en Formato XX-YY-ZZZZ");
            this.txtNumCol3.TextChanged += new System.EventHandler(this.txtNumCol3_TextChanged);
            // 
            // btBuscarPob
            // 
            this.btBuscarPob.BackColor = System.Drawing.SystemColors.Control;
            this.btBuscarPob.Image = ((System.Drawing.Image)(resources.GetObject("btBuscarPob.Image")));
            this.btBuscarPob.Location = new System.Drawing.Point(914, 63);
            this.btBuscarPob.Name = "btBuscarPob";
            this.btBuscarPob.Size = new System.Drawing.Size(22, 22);
            this.btBuscarPob.TabIndex = 9;
            this.toolTip1.SetToolTip(this.btBuscarPob, "Buscar Poblacion");
            this.btBuscarPob.UseVisualStyleBackColor = false;
            this.btBuscarPob.Click += new System.EventHandler(this.btBuscarPob_Click);
            // 
            // btBuscarCentro
            // 
            this.btBuscarCentro.Image = ((System.Drawing.Image)(resources.GetObject("btBuscarCentro.Image")));
            this.btBuscarCentro.Location = new System.Drawing.Point(375, 142);
            this.btBuscarCentro.Name = "btBuscarCentro";
            this.btBuscarCentro.Size = new System.Drawing.Size(22, 22);
            this.btBuscarCentro.TabIndex = 0;
            this.toolTip1.SetToolTip(this.btBuscarCentro, "Buscar Centro");
            this.btBuscarCentro.Click += new System.EventHandler(this.btBuscarCentro_Click);
            // 
            // btBuscarProducto
            // 
            this.btBuscarProducto.Image = ((System.Drawing.Image)(resources.GetObject("btBuscarProducto.Image")));
            this.btBuscarProducto.Location = new System.Drawing.Point(1117, 140);
            this.btBuscarProducto.Name = "btBuscarProducto";
            this.btBuscarProducto.Size = new System.Drawing.Size(22, 22);
            this.btBuscarProducto.TabIndex = 18;
            this.toolTip1.SetToolTip(this.btBuscarProducto, "Buscar Centro");
            this.btBuscarProducto.Click += new System.EventHandler(this.btBuscarProducto_Click);
            // 
            // btBuscaAccion
            // 
            this.btBuscaAccion.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btBuscaAccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btBuscaAccion.Image = ((System.Drawing.Image)(resources.GetObject("btBuscaAccion.Image")));
            this.btBuscaAccion.Location = new System.Drawing.Point(482, 291);
            this.btBuscaAccion.Name = "btBuscaAccion";
            this.btBuscaAccion.Size = new System.Drawing.Size(21, 21);
            this.btBuscaAccion.TabIndex = 22;
            this.toolTip1.SetToolTip(this.btBuscaAccion, "Buscar Acción");
            this.btBuscaAccion.UseVisualStyleBackColor = false;
            this.btBuscaAccion.Click += new System.EventHandler(this.btBuscaAccion_Click);
            // 
            // pnCliente
            // 
            this.pnCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnCliente.Controls.Add(this.label5);
            this.pnCliente.Controls.Add(this.txtProvincia);
            this.pnCliente.Controls.Add(this.txtNumCol3);
            this.pnCliente.Controls.Add(this.txtNumCol2);
            this.pnCliente.Controls.Add(this.txtApe2);
            this.pnCliente.Controls.Add(this.txtApe1);
            this.pnCliente.Controls.Add(this.txtNumCol1);
            this.pnCliente.Controls.Add(this.txtPoblacion);
            this.pnCliente.Controls.Add(this.txtCP);
            this.pnCliente.Controls.Add(this.txtDireccion);
            this.pnCliente.Controls.Add(this.txtNombre);
            this.pnCliente.Controls.Add(this.btBuscarPob);
            this.pnCliente.Controls.Add(this.cmbClasif);
            this.pnCliente.Controls.Add(this.label3);
            this.pnCliente.Controls.Add(this.cmbTipoMedico);
            this.pnCliente.Controls.Add(this.label2);
            this.pnCliente.Controls.Add(this.label1);
            this.pnCliente.Controls.Add(this.lblTitulo);
            this.pnCliente.Controls.Add(this.label21);
            this.pnCliente.Controls.Add(this.label20);
            this.pnCliente.Controls.Add(this.label25);
            this.pnCliente.Controls.Add(this.label26);
            this.pnCliente.Controls.Add(this.label29);
            this.pnCliente.Controls.Add(this.label31);
            this.pnCliente.Location = new System.Drawing.Point(0, 40);
            this.pnCliente.Name = "pnCliente";
            this.pnCliente.Size = new System.Drawing.Size(1251, 100);
            this.pnCliente.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(962, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 18);
            this.label5.TabIndex = 110;
            this.label5.Text = "Provincia:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtProvincia
            // 
            this.txtProvincia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtProvincia.Location = new System.Drawing.Point(1018, 64);
            this.txtProvincia.Name = "txtProvincia";
            this.txtProvincia.ReadOnly = true;
            this.txtProvincia.Size = new System.Drawing.Size(128, 20);
            this.txtProvincia.TabIndex = 10;
            this.txtProvincia.TabStop = false;
            // 
            // txtApe2
            // 
            this.txtApe2.BackColor = System.Drawing.Color.White;
            this.txtApe2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtApe2.Location = new System.Drawing.Point(616, 32);
            this.txtApe2.MaxLength = 100;
            this.txtApe2.Name = "txtApe2";
            this.txtApe2.Size = new System.Drawing.Size(136, 20);
            this.txtApe2.TabIndex = 2;
            this.txtApe2.TextChanged += new System.EventHandler(this.txtApe2_TextChanged);
            // 
            // txtApe1
            // 
            this.txtApe1.BackColor = System.Drawing.Color.White;
            this.txtApe1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtApe1.Location = new System.Drawing.Point(336, 32);
            this.txtApe1.MaxLength = 100;
            this.txtApe1.Name = "txtApe1";
            this.txtApe1.Size = new System.Drawing.Size(136, 20);
            this.txtApe1.TabIndex = 1;
            this.txtApe1.TextChanged += new System.EventHandler(this.txtApe1_TextChanged);
            // 
            // txtPoblacion
            // 
            this.txtPoblacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtPoblacion.Location = new System.Drawing.Point(666, 64);
            this.txtPoblacion.Name = "txtPoblacion";
            this.txtPoblacion.ReadOnly = true;
            this.txtPoblacion.Size = new System.Drawing.Size(250, 20);
            this.txtPoblacion.TabIndex = 9;
            this.txtPoblacion.TabStop = false;
            // 
            // txtCP
            // 
            this.txtCP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtCP.Location = new System.Drawing.Point(538, 64);
            this.txtCP.Name = "txtCP";
            this.txtCP.ReadOnly = true;
            this.txtCP.Size = new System.Drawing.Size(50, 20);
            this.txtCP.TabIndex = 9;
            // 
            // txtDireccion
            // 
            this.txtDireccion.BackColor = System.Drawing.Color.White;
            this.txtDireccion.Location = new System.Drawing.Point(282, 64);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(208, 20);
            this.txtDireccion.TabIndex = 8;
            // 
            // txtNombre
            // 
            this.txtNombre.BackColor = System.Drawing.Color.White;
            this.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombre.Location = new System.Drawing.Point(72, 32);
            this.txtNombre.MaxLength = 50;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(136, 20);
            this.txtNombre.TabIndex = 0;
            this.txtNombre.TextChanged += new System.EventHandler(this.txtNombre_TextChanged);
            // 
            // cmbClasif
            // 
            this.cmbClasif.DataSource = this.dsClientes1.ListaTipoClasificacion;
            this.cmbClasif.DisplayMember = "sLiteral";
            this.cmbClasif.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClasif.Location = new System.Drawing.Point(1089, 32);
            this.cmbClasif.Name = "cmbClasif";
            this.cmbClasif.Size = new System.Drawing.Size(120, 21);
            this.cmbClasif.TabIndex = 7;
            this.cmbClasif.ValueMember = "sValor";
            this.cmbClasif.SelectedIndexChanged += new System.EventHandler(this.cmbClasif_SelectedIndexChanged);
            // 
            // dsClientes1
            // 
            this.dsClientes1.DataSetName = "dsAltaMedicos";
            this.dsClientes1.Locale = new System.Globalization.CultureInfo("en-US");
            this.dsClientes1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(1007, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 18);
            this.label3.TabIndex = 108;
            this.label3.Text = "Clasificacion:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbTipoMedico
            // 
            this.cmbTipoMedico.DataSource = this.dsClientes1.ListaTipoClienteCOM;
            this.cmbTipoMedico.DisplayMember = "sLiteral";
            this.cmbTipoMedico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoMedico.Location = new System.Drawing.Point(809, 32);
            this.cmbTipoMedico.MaxDropDownItems = 30;
            this.cmbTipoMedico.Name = "cmbTipoMedico";
            this.cmbTipoMedico.Size = new System.Drawing.Size(152, 21);
            this.cmbTipoMedico.TabIndex = 6;
            this.cmbTipoMedico.ValueMember = "sValor";
            this.cmbTipoMedico.SelectedIndexChanged += new System.EventHandler(this.cmbTipoMedico_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(504, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 18);
            this.label2.TabIndex = 106;
            this.label2.Text = "Segundo Apellido:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(225, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 18);
            this.label1.TabIndex = 104;
            this.label1.Text = "Primer Apellido:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.lblTitulo.Size = new System.Drawing.Size(1249, 22);
            this.lblTitulo.TabIndex = 102;
            this.lblTitulo.Text = "Alta de Médicos";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label21
            // 
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.Black;
            this.label21.Location = new System.Drawing.Point(16, 64);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(80, 18);
            this.label21.TabIndex = 97;
            this.label21.Text = "N. Colegiado:";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label20
            // 
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.Blue;
            this.label20.Location = new System.Drawing.Point(769, 32);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(32, 18);
            this.label20.TabIndex = 93;
            this.label20.Text = "Tipo:";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label25
            // 
            this.label25.Location = new System.Drawing.Point(605, 66);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(57, 18);
            this.label25.TabIndex = 79;
            this.label25.Text = "Población:";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label26
            // 
            this.label26.Location = new System.Drawing.Point(226, 64);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(67, 18);
            this.label26.TabIndex = 77;
            this.label26.Text = "Dirección:";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label29
            // 
            this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.ForeColor = System.Drawing.Color.Blue;
            this.label29.Location = new System.Drawing.Point(16, 32);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(67, 18);
            this.label29.TabIndex = 71;
            this.label29.Text = "Nombre:";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label31
            // 
            this.label31.Location = new System.Drawing.Point(509, 66);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(32, 18);
            this.label31.TabIndex = 78;
            this.label31.Text = "C.P.:";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlDatosSec
            // 
            this.pnlDatosSec.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlDatosSec.Controls.Add(this.cbContCargo);
            this.pnlDatosSec.Controls.Add(this.label24);
            this.pnlDatosSec.Controls.Add(this.label23);
            this.pnlDatosSec.Controls.Add(this.dtFechaAniv);
            this.pnlDatosSec.Controls.Add(this.dtFechaNac);
            this.pnlDatosSec.Controls.Add(this.label22);
            this.pnlDatosSec.Controls.Add(this.txtObsMedico);
            this.pnlDatosSec.Controls.Add(this.txtNIF);
            this.pnlDatosSec.Controls.Add(this.txtEMail);
            this.pnlDatosSec.Controls.Add(this.txtFax);
            this.pnlDatosSec.Controls.Add(this.txtMovil);
            this.pnlDatosSec.Controls.Add(this.txtTelefono);
            this.pnlDatosSec.Controls.Add(this.txtAccObservEntrega);
            this.pnlDatosSec.Controls.Add(this.txtAccsIdAccion);
            this.pnlDatosSec.Controls.Add(this.txtProd);
            this.pnlDatosSec.Controls.Add(this.txtsCentro);
            this.pnlDatosSec.Controls.Add(this.txtsIdCentro);
            this.pnlDatosSec.Controls.Add(this.label19);
            this.pnlDatosSec.Controls.Add(this.label18);
            this.pnlDatosSec.Controls.Add(this.label13);
            this.pnlDatosSec.Controls.Add(this.label12);
            this.pnlDatosSec.Controls.Add(this.label11);
            this.pnlDatosSec.Controls.Add(this.label10);
            this.pnlDatosSec.Controls.Add(this.cmbAficiones);
            this.pnlDatosSec.Controls.Add(this.btActAfic);
            this.pnlDatosSec.Controls.Add(this.btElimAfic);
            this.pnlDatosSec.Controls.Add(this.btActualizarAccion);
            this.pnlDatosSec.Controls.Add(this.btEliminarAccion);
            this.pnlDatosSec.Controls.Add(this.btBuscaAccion);
            this.pnlDatosSec.Controls.Add(this.nupAccCantidad);
            this.pnlDatosSec.Controls.Add(this.dtpAccFEntrega);
            this.pnlDatosSec.Controls.Add(this.label17);
            this.pnlDatosSec.Controls.Add(this.label16);
            this.pnlDatosSec.Controls.Add(this.label15);
            this.pnlDatosSec.Controls.Add(this.label14);
            this.pnlDatosSec.Controls.Add(this.panel8);
            this.pnlDatosSec.Controls.Add(this.udPrioridad);
            this.pnlDatosSec.Controls.Add(this.label9);
            this.pnlDatosSec.Controls.Add(this.btBuscarProducto);
            this.pnlDatosSec.Controls.Add(this.label8);
            this.pnlDatosSec.Controls.Add(this.btEliminarProd);
            this.pnlDatosSec.Controls.Add(this.btActualizarProd);
            this.pnlDatosSec.Controls.Add(this.panel1);
            this.pnlDatosSec.Controls.Add(this.panel6);
            this.pnlDatosSec.Controls.Add(this.btEliminarEspec);
            this.pnlDatosSec.Controls.Add(this.btActualizarEspec);
            this.pnlDatosSec.Controls.Add(this.pnlCentros);
            this.pnlDatosSec.Controls.Add(this.btClienteActualizar);
            this.pnlDatosSec.Controls.Add(this.btClienteEliminar);
            this.pnlDatosSec.Controls.Add(this.btBuscarCentro);
            this.pnlDatosSec.Controls.Add(this.label6);
            this.pnlDatosSec.Controls.Add(this.cmbRelacion);
            this.pnlDatosSec.Controls.Add(this.label4);
            this.pnlDatosSec.Controls.Add(this.cbEspecialidades);
            this.pnlDatosSec.Controls.Add(this.label7);
            this.pnlDatosSec.Controls.Add(this.panel9);
            this.pnlDatosSec.Location = new System.Drawing.Point(0, 140);
            this.pnlDatosSec.Name = "pnlDatosSec";
            this.pnlDatosSec.Size = new System.Drawing.Size(1251, 451);
            this.pnlDatosSec.TabIndex = 2;
            // 
            // cbContCargo
            // 
            this.cbContCargo.DataSource = this.dsClientes2.ListaTipoAreaCliSAP;
            this.cbContCargo.DisplayMember = "sLiteral";
            this.cbContCargo.Location = new System.Drawing.Point(744, 291);
            this.cbContCargo.Name = "cbContCargo";
            this.cbContCargo.Size = new System.Drawing.Size(206, 21);
            this.cbContCargo.TabIndex = 163;
            this.cbContCargo.ValueMember = "sValor";
            // 
            // dsClientes2
            // 
            this.dsClientes2.DataSetName = "dsClientes";
            this.dsClientes2.Locale = new System.Globalization.CultureInfo("es-ES");
            this.dsClientes2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label24
            // 
            this.label24.Location = new System.Drawing.Point(1056, 344);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(82, 18);
            this.label24.TabIndex = 162;
            this.label24.Text = "F. Aniversario:";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label23
            // 
            this.label23.Location = new System.Drawing.Point(1058, 320);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(80, 18);
            this.label23.TabIndex = 161;
            this.label23.Text = "F. Nacimiento:";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtFechaAniv
            // 
            this.dtFechaAniv.CustomFormat = "dd/mm/yyyy";
            this.dtFechaAniv.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaAniv.Location = new System.Drawing.Point(1138, 342);
            this.dtFechaAniv.Name = "dtFechaAniv";
            this.dtFechaAniv.Size = new System.Drawing.Size(94, 20);
            this.dtFechaAniv.TabIndex = 37;
            this.dtFechaAniv.Value = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtFechaAniv.ValueChanged += new System.EventHandler(this.fMatTrue);
            // 
            // dtFechaNac
            // 
            this.dtFechaNac.CustomFormat = "dd/mm/yyyy";
            this.dtFechaNac.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaNac.Location = new System.Drawing.Point(1138, 318);
            this.dtFechaNac.Name = "dtFechaNac";
            this.dtFechaNac.Size = new System.Drawing.Size(94, 20);
            this.dtFechaNac.TabIndex = 36;
            this.dtFechaNac.Value = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtFechaNac.ValueChanged += new System.EventHandler(this.fNacTrue);
            // 
            // label22
            // 
            this.label22.Location = new System.Drawing.Point(540, 353);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(86, 18);
            this.label22.TabIndex = 158;
            this.label22.Text = "Observaciones:";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtObsMedico
            // 
            this.txtObsMedico.Location = new System.Drawing.Point(536, 375);
            this.txtObsMedico.MaxLength = 8000;
            this.txtObsMedico.Multiline = true;
            this.txtObsMedico.Name = "txtObsMedico";
            this.txtObsMedico.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObsMedico.Size = new System.Drawing.Size(692, 60);
            this.txtObsMedico.TabIndex = 38;
            this.txtObsMedico.Enter += new System.EventHandler(this.txtObsMedico_Enter);
            // 
            // txtNIF
            // 
            this.txtNIF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNIF.Location = new System.Drawing.Point(573, 322);
            this.txtNIF.MaxLength = 20;
            this.txtNIF.Name = "txtNIF";
            this.txtNIF.Size = new System.Drawing.Size(100, 20);
            this.txtNIF.TabIndex = 33;
            // 
            // txtEMail
            // 
            this.txtEMail.Location = new System.Drawing.Point(898, 342);
            this.txtEMail.MaxLength = 100;
            this.txtEMail.Name = "txtEMail";
            this.txtEMail.Size = new System.Drawing.Size(142, 20);
            this.txtEMail.TabIndex = 35;
            // 
            // txtFax
            // 
            this.txtFax.Location = new System.Drawing.Point(898, 318);
            this.txtFax.MaxLength = 20;
            this.txtFax.Name = "txtFax";
            this.txtFax.Size = new System.Drawing.Size(100, 20);
            this.txtFax.TabIndex = 34;
            // 
            // txtMovil
            // 
            this.txtMovil.Location = new System.Drawing.Point(725, 343);
            this.txtMovil.MaxLength = 20;
            this.txtMovil.Name = "txtMovil";
            this.txtMovil.Size = new System.Drawing.Size(100, 20);
            this.txtMovil.TabIndex = 32;
            // 
            // txtTelefono
            // 
            this.txtTelefono.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTelefono.Location = new System.Drawing.Point(725, 319);
            this.txtTelefono.MaxLength = 20;
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(100, 20);
            this.txtTelefono.TabIndex = 31;
            // 
            // txtAccObservEntrega
            // 
            this.txtAccObservEntrega.Location = new System.Drawing.Point(4, 359);
            this.txtAccObservEntrega.MaxLength = 8000;
            this.txtAccObservEntrega.Multiline = true;
            this.txtAccObservEntrega.Name = "txtAccObservEntrega";
            this.txtAccObservEntrega.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAccObservEntrega.Size = new System.Drawing.Size(508, 76);
            this.txtAccObservEntrega.TabIndex = 27;
            // 
            // txtAccsIdAccion
            // 
            this.txtAccsIdAccion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtAccsIdAccion.Location = new System.Drawing.Point(274, 291);
            this.txtAccsIdAccion.MaxLength = 50;
            this.txtAccsIdAccion.Name = "txtAccsIdAccion";
            this.txtAccsIdAccion.ReadOnly = true;
            this.txtAccsIdAccion.Size = new System.Drawing.Size(208, 20);
            this.txtAccsIdAccion.TabIndex = 131;
            this.txtAccsIdAccion.TabStop = false;
            // 
            // txtProd
            // 
            this.txtProd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtProd.ForeColor = System.Drawing.Color.Black;
            this.txtProd.Location = new System.Drawing.Point(832, 142);
            this.txtProd.Name = "txtProd";
            this.txtProd.ReadOnly = true;
            this.txtProd.Size = new System.Drawing.Size(279, 20);
            this.txtProd.TabIndex = 126;
            this.txtProd.TabStop = false;
            // 
            // txtsCentro
            // 
            this.txtsCentro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtsCentro.ForeColor = System.Drawing.Color.Black;
            this.txtsCentro.Location = new System.Drawing.Point(64, 142);
            this.txtsCentro.Name = "txtsCentro";
            this.txtsCentro.ReadOnly = true;
            this.txtsCentro.Size = new System.Drawing.Size(310, 20);
            this.txtsCentro.TabIndex = 115;
            this.txtsCentro.TabStop = false;
            // 
            // txtsIdCentro
            // 
            this.txtsIdCentro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtsIdCentro.ForeColor = System.Drawing.Color.Black;
            this.txtsIdCentro.Location = new System.Drawing.Point(0, 142);
            this.txtsIdCentro.MaxLength = 20;
            this.txtsIdCentro.Name = "txtsIdCentro";
            this.txtsIdCentro.Size = new System.Drawing.Size(64, 20);
            this.txtsIdCentro.TabIndex = 1;
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(540, 325);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(28, 18);
            this.label19.TabIndex = 156;
            this.label19.Text = "NIF:";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(834, 346);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(60, 18);
            this.label18.TabIndex = 155;
            this.label18.Text = "E-Mail:";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(834, 322);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(60, 18);
            this.label13.TabIndex = 154;
            this.label13.Text = "FAX:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(684, 346);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(36, 18);
            this.label12.TabIndex = 153;
            this.label12.Text = "Móvil:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(692, 322);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(28, 18);
            this.label11.TabIndex = 152;
            this.label11.Text = "Tel.:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(700, 292);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 18);
            this.label10.TabIndex = 146;
            this.label10.Text = "Area:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbAficiones
            // 
            this.cmbAficiones.DataSource = this.dsClientes1.ListaTipoAficiones;
            this.cmbAficiones.DisplayMember = "sValor";
            this.cmbAficiones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAficiones.Enabled = false;
            this.cmbAficiones.Location = new System.Drawing.Point(744, 290);
            this.cmbAficiones.Name = "cmbAficiones";
            this.cmbAficiones.Size = new System.Drawing.Size(208, 21);
            this.cmbAficiones.TabIndex = 28;
            this.cmbAficiones.ValueMember = "sValor";
            this.cmbAficiones.Visible = false;
            // 
            // btActAfic
            // 
            this.btActAfic.BackColor = System.Drawing.SystemColors.Control;
            this.btActAfic.ForeColor = System.Drawing.Color.Black;
            this.btActAfic.Image = ((System.Drawing.Image)(resources.GetObject("btActAfic.Image")));
            this.btActAfic.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btActAfic.Location = new System.Drawing.Point(528, 290);
            this.btActAfic.Name = "btActAfic";
            this.btActAfic.Size = new System.Drawing.Size(80, 23);
            this.btActAfic.TabIndex = 29;
            this.btActAfic.Text = "Actualizar";
            this.btActAfic.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btActAfic.UseVisualStyleBackColor = true;
            this.btActAfic.Click += new System.EventHandler(this.btActualizarAfic_Click);
            // 
            // btElimAfic
            // 
            this.btElimAfic.BackColor = System.Drawing.SystemColors.Control;
            this.btElimAfic.ForeColor = System.Drawing.Color.Black;
            this.btElimAfic.Image = ((System.Drawing.Image)(resources.GetObject("btElimAfic.Image")));
            this.btElimAfic.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btElimAfic.Location = new System.Drawing.Point(608, 290);
            this.btElimAfic.Name = "btElimAfic";
            this.btElimAfic.Size = new System.Drawing.Size(75, 23);
            this.btElimAfic.TabIndex = 30;
            this.btElimAfic.Text = "Eliminar";
            this.btElimAfic.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btElimAfic.UseVisualStyleBackColor = true;
            this.btElimAfic.Click += new System.EventHandler(this.btEliminarAfic_Click);
            // 
            // btActualizarAccion
            // 
            this.btActualizarAccion.BackColor = System.Drawing.SystemColors.Control;
            this.btActualizarAccion.ForeColor = System.Drawing.Color.Black;
            this.btActualizarAccion.Image = ((System.Drawing.Image)(resources.GetObject("btActualizarAccion.Image")));
            this.btActualizarAccion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btActualizarAccion.Location = new System.Drawing.Point(2, 290);
            this.btActualizarAccion.Name = "btActualizarAccion";
            this.btActualizarAccion.Size = new System.Drawing.Size(80, 23);
            this.btActualizarAccion.TabIndex = 25;
            this.btActualizarAccion.Text = "Actualizar";
            this.btActualizarAccion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btActualizarAccion.UseVisualStyleBackColor = true;
            this.btActualizarAccion.Click += new System.EventHandler(this.btActualizarAcc_Click);
            // 
            // btEliminarAccion
            // 
            this.btEliminarAccion.BackColor = System.Drawing.SystemColors.Control;
            this.btEliminarAccion.ForeColor = System.Drawing.Color.Black;
            this.btEliminarAccion.Image = ((System.Drawing.Image)(resources.GetObject("btEliminarAccion.Image")));
            this.btEliminarAccion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btEliminarAccion.Location = new System.Drawing.Point(82, 290);
            this.btEliminarAccion.Name = "btEliminarAccion";
            this.btEliminarAccion.Size = new System.Drawing.Size(75, 23);
            this.btEliminarAccion.TabIndex = 26;
            this.btEliminarAccion.Text = "Eliminar";
            this.btEliminarAccion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btEliminarAccion.UseVisualStyleBackColor = true;
            this.btEliminarAccion.Click += new System.EventHandler(this.btEliminarAcc_Click);
            // 
            // nupAccCantidad
            // 
            this.nupAccCantidad.Location = new System.Drawing.Point(368, 322);
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
            this.nupAccCantidad.Size = new System.Drawing.Size(56, 20);
            this.nupAccCantidad.TabIndex = 24;
            this.nupAccCantidad.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // dtpAccFEntrega
            // 
            this.dtpAccFEntrega.Enabled = false;
            this.dtpAccFEntrega.Location = new System.Drawing.Point(104, 320);
            this.dtpAccFEntrega.Name = "dtpAccFEntrega";
            this.dtpAccFEntrega.Size = new System.Drawing.Size(200, 20);
            this.dtpAccFEntrega.TabIndex = 23;
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(4, 343);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(246, 18);
            this.label17.TabIndex = 139;
            this.label17.Text = "Observaciones de la Entrega:";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(2, 320);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(100, 18);
            this.label16.TabIndex = 138;
            this.label16.Text = "Fecha Entrega:";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(314, 324);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(60, 18);
            this.label15.TabIndex = 137;
            this.label15.Text = "Cantidad:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(232, 291);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(43, 18);
            this.label14.TabIndex = 135;
            this.label14.Text = "Acción:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel8
            // 
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel8.Controls.Add(this.lblTotAcciones);
            this.panel8.Controls.Add(this.dgAccionesMark);
            this.panel8.Controls.Add(this.labelGradient4);
            this.panel8.Location = new System.Drawing.Point(0, 164);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(526, 124);
            this.panel8.TabIndex = 130;
            // 
            // lblTotAcciones
            // 
            this.lblTotAcciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.lblTotAcciones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotAcciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotAcciones.ForeColor = System.Drawing.Color.Black;
            this.lblTotAcciones.Location = new System.Drawing.Point(490, 0);
            this.lblTotAcciones.Name = "lblTotAcciones";
            this.lblTotAcciones.Size = new System.Drawing.Size(32, 18);
            this.lblTotAcciones.TabIndex = 11;
            this.lblTotAcciones.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgAccionesMark
            // 
            this.dgAccionesMark.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgAccionesMark.BackgroundColor = System.Drawing.Color.White;
            this.dgAccionesMark.CaptionText = "Acciones";
            this.dgAccionesMark.CaptionVisible = false;
            this.dgAccionesMark.DataMember = "";
            this.dgAccionesMark.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgAccionesMark.Location = new System.Drawing.Point(0, 18);
            this.dgAccionesMark.Name = "dgAccionesMark";
            this.dgAccionesMark.ReadOnly = true;
            this.dgAccionesMark.Size = new System.Drawing.Size(526, 102);
            this.dgAccionesMark.TabIndex = 0;
            this.dgAccionesMark.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyleAccionesMark});
            this.dgAccionesMark.TabStop = false;
            this.dgAccionesMark.CurrentCellChanged += new System.EventHandler(this.dgAccionesMark_CurrentCellChanged);
            // 
            // dataGridTableStyleAccionesMark
            // 
            this.dataGridTableStyleAccionesMark.DataGrid = this.dgAccionesMark;
            this.dataGridTableStyleAccionesMark.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dgAccionesMarkiIdAccion,
            this.dgAccionesMarksIdAccion,
            this.dgAccionesMarkfCantidad,
            this.dgAccionesMarkdFechaEntrega,
            this.dgAccionesMarktObservEntrega,
            this.dgAccionesMarksCCoste,
            this.dgAccionesMarkdFUM,
            this.dgCentrosiEstado,
            this.dgAccionesMarkbEnviadoCen});
            this.dataGridTableStyleAccionesMark.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyleAccionesMark.MappingName = "AccionesMarkClientes";
            // 
            // dgAccionesMarkiIdAccion
            // 
            this.dgAccionesMarkiIdAccion.Format = "";
            this.dgAccionesMarkiIdAccion.FormatInfo = null;
            this.dgAccionesMarkiIdAccion.MappingName = "iIdAccion";
            this.dgAccionesMarkiIdAccion.NullText = "";
            this.dgAccionesMarkiIdAccion.Width = 0;
            // 
            // dgAccionesMarksIdAccion
            // 
            this.dgAccionesMarksIdAccion.Format = "";
            this.dgAccionesMarksIdAccion.FormatInfo = null;
            this.dgAccionesMarksIdAccion.HeaderText = "Acción";
            this.dgAccionesMarksIdAccion.MappingName = "sIdAccion";
            this.dgAccionesMarksIdAccion.NullText = "";
            this.dgAccionesMarksIdAccion.Width = 250;
            // 
            // dgAccionesMarkfCantidad
            // 
            this.dgAccionesMarkfCantidad.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dgAccionesMarkfCantidad.Format = "";
            this.dgAccionesMarkfCantidad.FormatInfo = null;
            this.dgAccionesMarkfCantidad.HeaderText = "Cantidad   ";
            this.dgAccionesMarkfCantidad.MappingName = "fCantidad";
            this.dgAccionesMarkfCantidad.NullText = "";
            this.dgAccionesMarkfCantidad.Width = 75;
            // 
            // dgAccionesMarkdFechaEntrega
            // 
            this.dgAccionesMarkdFechaEntrega.Format = "dd/MM/yyyy";
            this.dgAccionesMarkdFechaEntrega.FormatInfo = null;
            this.dgAccionesMarkdFechaEntrega.HeaderText = "F.Entrega";
            this.dgAccionesMarkdFechaEntrega.MappingName = "dFechaEntrega";
            this.dgAccionesMarkdFechaEntrega.NullText = "";
            this.dgAccionesMarkdFechaEntrega.Width = 75;
            // 
            // dgAccionesMarktObservEntrega
            // 
            this.dgAccionesMarktObservEntrega.Format = "dd/mm/yyyy";
            this.dgAccionesMarktObservEntrega.FormatInfo = null;
            this.dgAccionesMarktObservEntrega.HeaderText = "Observaciones Entrega";
            this.dgAccionesMarktObservEntrega.MappingName = "tObservEntrega";
            this.dgAccionesMarktObservEntrega.NullText = "";
            this.dgAccionesMarktObservEntrega.Width = 400;
            // 
            // dgAccionesMarksCCoste
            // 
            this.dgAccionesMarksCCoste.Format = "";
            this.dgAccionesMarksCCoste.FormatInfo = null;
            this.dgAccionesMarksCCoste.MappingName = "sCCoste";
            this.dgAccionesMarksCCoste.NullText = "";
            this.dgAccionesMarksCCoste.Width = 0;
            // 
            // dgAccionesMarkdFUM
            // 
            this.dgAccionesMarkdFUM.Format = "";
            this.dgAccionesMarkdFUM.FormatInfo = null;
            this.dgAccionesMarkdFUM.MappingName = "dFUM";
            this.dgAccionesMarkdFUM.NullText = "";
            this.dgAccionesMarkdFUM.Width = 0;
            // 
            // dgCentrosiEstado
            // 
            this.dgCentrosiEstado.Format = "";
            this.dgCentrosiEstado.FormatInfo = null;
            this.dgCentrosiEstado.MappingName = "iEstado";
            this.dgCentrosiEstado.NullText = "";
            this.dgCentrosiEstado.Width = 0;
            // 
            // dgAccionesMarkbEnviadoCen
            // 
            this.dgAccionesMarkbEnviadoCen.Format = "";
            this.dgAccionesMarkbEnviadoCen.FormatInfo = null;
            this.dgAccionesMarkbEnviadoCen.MappingName = "bEnviadoCen";
            this.dgAccionesMarkbEnviadoCen.NullText = "";
            this.dgAccionesMarkbEnviadoCen.Width = 0;
            // 
            // labelGradient4
            // 
            this.labelGradient4.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelGradient4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGradient4.ForeColor = System.Drawing.Color.White;
            this.labelGradient4.GradientColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.labelGradient4.GradientColorTwo = System.Drawing.Color.White;
            this.labelGradient4.Location = new System.Drawing.Point(0, 0);
            this.labelGradient4.Name = "labelGradient4";
            this.labelGradient4.Size = new System.Drawing.Size(522, 18);
            this.labelGradient4.TabIndex = 0;
            this.labelGradient4.Text = "Acciones";
            this.labelGradient4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // udPrioridad
            // 
            this.udPrioridad.Location = new System.Drawing.Point(1160, 142);
            this.udPrioridad.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udPrioridad.Name = "udPrioridad";
            this.udPrioridad.Size = new System.Drawing.Size(48, 20);
            this.udPrioridad.TabIndex = 19;
            this.udPrioridad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.udPrioridad.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(1158, 126);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 18);
            this.label9.TabIndex = 128;
            this.label9.Text = "Prioridad:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(829, 126);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 18);
            this.label8.TabIndex = 125;
            this.label8.Text = "Producto:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btEliminarProd
            // 
            this.btEliminarProd.Image = ((System.Drawing.Image)(resources.GetObject("btEliminarProd.Image")));
            this.btEliminarProd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btEliminarProd.Location = new System.Drawing.Point(907, 103);
            this.btEliminarProd.Name = "btEliminarProd";
            this.btEliminarProd.Size = new System.Drawing.Size(75, 23);
            this.btEliminarProd.TabIndex = 21;
            this.btEliminarProd.Text = "Eliminar";
            this.btEliminarProd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btEliminarProd.Click += new System.EventHandler(this.btEliminarProd_Click);
            // 
            // btActualizarProd
            // 
            this.btActualizarProd.Image = ((System.Drawing.Image)(resources.GetObject("btActualizarProd.Image")));
            this.btActualizarProd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btActualizarProd.Location = new System.Drawing.Point(827, 103);
            this.btActualizarProd.Name = "btActualizarProd";
            this.btActualizarProd.Size = new System.Drawing.Size(80, 23);
            this.btActualizarProd.TabIndex = 20;
            this.btActualizarProd.Text = "Actualizar";
            this.btActualizarProd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btActualizarProd.Click += new System.EventHandler(this.btActualizarProd_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.lblTotProd);
            this.panel1.Controls.Add(this.dgProductos);
            this.panel1.Controls.Add(this.labelGradient2);
            this.panel1.Location = new System.Drawing.Point(825, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(424, 103);
            this.panel1.TabIndex = 122;
            // 
            // lblTotProd
            // 
            this.lblTotProd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.lblTotProd.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotProd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotProd.ForeColor = System.Drawing.Color.Black;
            this.lblTotProd.Location = new System.Drawing.Point(387, 0);
            this.lblTotProd.Name = "lblTotProd";
            this.lblTotProd.Size = new System.Drawing.Size(32, 18);
            this.lblTotProd.TabIndex = 10;
            this.lblTotProd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgProductos
            // 
            this.dgProductos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgProductos.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgProductos.CaptionText = "Productos";
            this.dgProductos.CaptionVisible = false;
            this.dgProductos.ContextMenu = this.contextMenu1;
            this.dgProductos.DataMember = "ProdClientes_COM";
            this.dgProductos.DataSource = this.dsClientes1;
            this.dgProductos.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgProductos.Location = new System.Drawing.Point(0, 18);
            this.dgProductos.Name = "dgProductos";
            this.dgProductos.ReadOnly = true;
            this.dgProductos.RowHeaderWidth = 17;
            this.dgProductos.Size = new System.Drawing.Size(420, 84);
            this.dgProductos.TabIndex = 0;
            this.dgProductos.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyleProdCLientesCOM});
            this.dgProductos.TabStop = false;
            this.dgProductos.CurrentCellChanged += new System.EventHandler(this.dgProductos_CurrentCellChanged);
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
            // dataGridTableStyleProdCLientesCOM
            // 
            this.dataGridTableStyleProdCLientesCOM.DataGrid = this.dgProductos;
            this.dataGridTableStyleProdCLientesCOM.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dgProductossIdProducto,
            this.dgProductossDescripcion,
            this.dgProductosiPrioridad});
            this.dataGridTableStyleProdCLientesCOM.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyleProdCLientesCOM.MappingName = "ProdClientes_COM";
            this.dataGridTableStyleProdCLientesCOM.RowHeaderWidth = 17;
            // 
            // dgProductossIdProducto
            // 
            this.dgProductossIdProducto.Format = "";
            this.dgProductossIdProducto.FormatInfo = null;
            this.dgProductossIdProducto.HeaderText = "Código";
            this.dgProductossIdProducto.MappingName = "sIdProducto";
            this.dgProductossIdProducto.NullText = "";
            this.dgProductossIdProducto.ReadOnly = true;
            this.dgProductossIdProducto.Width = 0;
            // 
            // dgProductossDescripcion
            // 
            this.dgProductossDescripcion.Format = "";
            this.dgProductossDescripcion.FormatInfo = null;
            this.dgProductossDescripcion.HeaderText = "Producto";
            this.dgProductossDescripcion.MappingName = "sDescripcion";
            this.dgProductossDescripcion.NullText = "";
            this.dgProductossDescripcion.ReadOnly = true;
            this.dgProductossDescripcion.Width = 300;
            // 
            // dgProductosiPrioridad
            // 
            this.dgProductosiPrioridad.Format = "";
            this.dgProductosiPrioridad.FormatInfo = null;
            this.dgProductosiPrioridad.HeaderText = "Prioridad";
            this.dgProductosiPrioridad.MappingName = "iPrioridad";
            this.dgProductosiPrioridad.NullText = "";
            this.dgProductosiPrioridad.ReadOnly = true;
            this.dgProductosiPrioridad.Width = 75;
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
            this.labelGradient2.Size = new System.Drawing.Size(420, 18);
            this.labelGradient2.TabIndex = 0;
            this.labelGradient2.Text = "Productos";
            this.labelGradient2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel6.Controls.Add(this.lblTotEspec);
            this.panel6.Controls.Add(this.dgEspecialidades);
            this.panel6.Controls.Add(this.labelGradient1);
            this.panel6.Location = new System.Drawing.Point(525, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(298, 103);
            this.panel6.TabIndex = 13;
            // 
            // lblTotEspec
            // 
            this.lblTotEspec.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.lblTotEspec.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotEspec.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotEspec.ForeColor = System.Drawing.Color.Black;
            this.lblTotEspec.Location = new System.Drawing.Point(261, 0);
            this.lblTotEspec.Name = "lblTotEspec";
            this.lblTotEspec.Size = new System.Drawing.Size(32, 18);
            this.lblTotEspec.TabIndex = 10;
            this.lblTotEspec.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgEspecialidades
            // 
            this.dgEspecialidades.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgEspecialidades.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgEspecialidades.CaptionText = "Especialidades";
            this.dgEspecialidades.CaptionVisible = false;
            this.dgEspecialidades.DataMember = "EspecClientes_COM";
            this.dgEspecialidades.DataSource = this.dsClientes1;
            this.dgEspecialidades.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgEspecialidades.Location = new System.Drawing.Point(-1, 18);
            this.dgEspecialidades.Name = "dgEspecialidades";
            this.dgEspecialidades.ReadOnly = true;
            this.dgEspecialidades.RowHeaderWidth = 17;
            this.dgEspecialidades.Size = new System.Drawing.Size(294, 84);
            this.dgEspecialidades.TabIndex = 0;
            this.dgEspecialidades.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyleEspecCLientesCOM});
            this.dgEspecialidades.TabStop = false;
            this.dgEspecialidades.CurrentCellChanged += new System.EventHandler(this.dgEspecialidades_CurrentCellChanged);
            // 
            // dataGridTableStyleEspecCLientesCOM
            // 
            this.dataGridTableStyleEspecCLientesCOM.DataGrid = this.dgEspecialidades;
            this.dataGridTableStyleEspecCLientesCOM.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dgEspecialidadesIdEspecialidad,
            this.dgEspecialidadestEspecialidad});
            this.dataGridTableStyleEspecCLientesCOM.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyleEspecCLientesCOM.MappingName = "EspecClientes_COM";
            this.dataGridTableStyleEspecCLientesCOM.RowHeaderWidth = 17;
            // 
            // dgEspecialidadesIdEspecialidad
            // 
            this.dgEspecialidadesIdEspecialidad.Format = "";
            this.dgEspecialidadesIdEspecialidad.FormatInfo = null;
            this.dgEspecialidadesIdEspecialidad.MappingName = "sIdEspecialidad";
            this.dgEspecialidadesIdEspecialidad.NullText = "";
            this.dgEspecialidadesIdEspecialidad.Width = 0;
            // 
            // dgEspecialidadestEspecialidad
            // 
            this.dgEspecialidadestEspecialidad.Format = "";
            this.dgEspecialidadestEspecialidad.FormatInfo = null;
            this.dgEspecialidadestEspecialidad.HeaderText = "Especialidad";
            this.dgEspecialidadestEspecialidad.MappingName = "tEspecialidad";
            this.dgEspecialidadestEspecialidad.NullText = "";
            this.dgEspecialidadestEspecialidad.Width = 273;
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
            this.labelGradient1.Size = new System.Drawing.Size(294, 18);
            this.labelGradient1.TabIndex = 0;
            this.labelGradient1.Text = "Especialidades";
            this.labelGradient1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btEliminarEspec
            // 
            this.btEliminarEspec.Image = ((System.Drawing.Image)(resources.GetObject("btEliminarEspec.Image")));
            this.btEliminarEspec.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btEliminarEspec.Location = new System.Drawing.Point(607, 104);
            this.btEliminarEspec.Name = "btEliminarEspec";
            this.btEliminarEspec.Size = new System.Drawing.Size(75, 23);
            this.btEliminarEspec.TabIndex = 17;
            this.btEliminarEspec.Text = "Eliminar";
            this.btEliminarEspec.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btEliminarEspec.Click += new System.EventHandler(this.btEliminarEspec_Click);
            // 
            // btActualizarEspec
            // 
            this.btActualizarEspec.Image = ((System.Drawing.Image)(resources.GetObject("btActualizarEspec.Image")));
            this.btActualizarEspec.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btActualizarEspec.Location = new System.Drawing.Point(527, 104);
            this.btActualizarEspec.Name = "btActualizarEspec";
            this.btActualizarEspec.Size = new System.Drawing.Size(80, 23);
            this.btActualizarEspec.TabIndex = 16;
            this.btActualizarEspec.Text = "Actualizar";
            this.btActualizarEspec.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btActualizarEspec.Click += new System.EventHandler(this.btActualizarEspec_Click);
            // 
            // pnlCentros
            // 
            this.pnlCentros.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlCentros.Controls.Add(this.lblTotCentros);
            this.pnlCentros.Controls.Add(this.dgCentros);
            this.pnlCentros.Controls.Add(this.labelGradient3);
            this.pnlCentros.ForeColor = System.Drawing.Color.Black;
            this.pnlCentros.Location = new System.Drawing.Point(0, 0);
            this.pnlCentros.Name = "pnlCentros";
            this.pnlCentros.Size = new System.Drawing.Size(526, 104);
            this.pnlCentros.TabIndex = 0;
            // 
            // lblTotCentros
            // 
            this.lblTotCentros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.lblTotCentros.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotCentros.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotCentros.ForeColor = System.Drawing.Color.Black;
            this.lblTotCentros.Location = new System.Drawing.Point(490, 0);
            this.lblTotCentros.Name = "lblTotCentros";
            this.lblTotCentros.Size = new System.Drawing.Size(32, 18);
            this.lblTotCentros.TabIndex = 114;
            this.lblTotCentros.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgCentros
            // 
            this.dgCentros.AllowSorting = false;
            this.dgCentros.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgCentros.BackgroundColor = System.Drawing.Color.White;
            this.dgCentros.CaptionVisible = false;
            this.dgCentros.ContextMenu = this.contextMenu1;
            this.dgCentros.DataMember = "";
            this.dgCentros.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgCentros.Location = new System.Drawing.Point(0, 18);
            this.dgCentros.Name = "dgCentros";
            this.dgCentros.PreferredColumnWidth = 74;
            this.dgCentros.ReadOnly = true;
            this.dgCentros.RowHeaderWidth = 15;
            this.dgCentros.Size = new System.Drawing.Size(522, 84);
            this.dgCentros.TabIndex = 113;
            this.dgCentros.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyleCentrosCLientesCOM});
            this.dgCentros.TabStop = false;
            this.dgCentros.CurrentCellChanged += new System.EventHandler(this.dgCentros_CurrentCellChanged);
            // 
            // dataGridTableStyleCentrosCLientesCOM
            // 
            this.dataGridTableStyleCentrosCLientesCOM.DataGrid = this.dgCentros;
            this.dataGridTableStyleCentrosCLientesCOM.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dgCentrosiIdCentro,
            this.dgCentrossIdCentro,
            this.dgCentrossDescripcion,
            this.dgCentrossIdTipoRelacionCliCen,
            this.dgCentrostRelacionTipoCliCen,
            this.dgCentrosdFAR,
            this.dgCentrosdFBR,
            this.dgCentrosiEstado,
            this.dgCentrosIdRed,
            this.dgCentrostRed});
            this.dataGridTableStyleCentrosCLientesCOM.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyleCentrosCLientesCOM.MappingName = "CentrosClientes_COM";
            // 
            // dgCentrosiIdCentro
            // 
            this.dgCentrosiIdCentro.Format = "";
            this.dgCentrosiIdCentro.FormatInfo = null;
            this.dgCentrosiIdCentro.MappingName = "iIdCentro";
            this.dgCentrosiIdCentro.NullText = "";
            this.dgCentrosiIdCentro.Width = 0;
            // 
            // dgCentrossIdCentro
            // 
            this.dgCentrossIdCentro.Format = "";
            this.dgCentrossIdCentro.FormatInfo = null;
            this.dgCentrossIdCentro.HeaderText = "Código";
            this.dgCentrossIdCentro.MappingName = "sIdCentro";
            this.dgCentrossIdCentro.NullText = "";
            this.dgCentrossIdCentro.Width = 60;
            // 
            // dgCentrossDescripcion
            // 
            this.dgCentrossDescripcion.Format = "";
            this.dgCentrossDescripcion.FormatInfo = null;
            this.dgCentrossDescripcion.HeaderText = "Nombre Centro";
            this.dgCentrossDescripcion.MappingName = "sDescripcion";
            this.dgCentrossDescripcion.NullText = "";
            this.dgCentrossDescripcion.Width = 157;
            // 
            // dgCentrossIdTipoRelacionCliCen
            // 
            this.dgCentrossIdTipoRelacionCliCen.Format = "";
            this.dgCentrossIdTipoRelacionCliCen.FormatInfo = null;
            this.dgCentrossIdTipoRelacionCliCen.MappingName = "sIdTipoRelacionCliCen";
            this.dgCentrossIdTipoRelacionCliCen.NullText = "";
            this.dgCentrossIdTipoRelacionCliCen.Width = 0;
            // 
            // dgCentrostRelacionTipoCliCen
            // 
            this.dgCentrostRelacionTipoCliCen.Format = "";
            this.dgCentrostRelacionTipoCliCen.FormatInfo = null;
            this.dgCentrostRelacionTipoCliCen.HeaderText = "Relación";
            this.dgCentrostRelacionTipoCliCen.MappingName = "tRelacionTipoCliCen";
            this.dgCentrostRelacionTipoCliCen.NullText = "";
            this.dgCentrostRelacionTipoCliCen.Width = 55;
            // 
            // dgCentrosdFAR
            // 
            this.dgCentrosdFAR.Format = "";
            this.dgCentrosdFAR.FormatInfo = null;
            this.dgCentrosdFAR.MappingName = "dFAR";
            this.dgCentrosdFAR.NullText = "";
            this.dgCentrosdFAR.Width = 0;
            // 
            // dgCentrosdFBR
            // 
            this.dgCentrosdFBR.Format = "";
            this.dgCentrosdFBR.FormatInfo = null;
            this.dgCentrosdFBR.MappingName = "dFBR";
            this.dgCentrosdFBR.NullText = "";
            this.dgCentrosdFBR.Width = 0;
            // 
            // dgCentrosIdRed
            // 
            this.dgCentrosIdRed.Format = "";
            this.dgCentrosIdRed.FormatInfo = null;
            this.dgCentrosIdRed.MappingName = "sIdRed";
            this.dgCentrosIdRed.NullText = "";
            this.dgCentrosIdRed.Width = 0;
            // 
            // dgCentrostRed
            // 
            this.dgCentrostRed.Format = "";
            this.dgCentrostRed.FormatInfo = null;
            this.dgCentrostRed.HeaderText = "Red";
            this.dgCentrostRed.MappingName = "tRed";
            this.dgCentrostRed.Width = 75;
            // 
            // labelGradient3
            // 
            this.labelGradient3.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelGradient3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGradient3.ForeColor = System.Drawing.Color.White;
            this.labelGradient3.GradientColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.labelGradient3.GradientColorTwo = System.Drawing.Color.White;
            this.labelGradient3.Location = new System.Drawing.Point(0, 0);
            this.labelGradient3.Name = "labelGradient3";
            this.labelGradient3.Size = new System.Drawing.Size(522, 18);
            this.labelGradient3.TabIndex = 112;
            this.labelGradient3.Text = "Centros ";
            this.labelGradient3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btClienteActualizar
            // 
            this.btClienteActualizar.BackColor = System.Drawing.SystemColors.Control;
            this.btClienteActualizar.ForeColor = System.Drawing.Color.Black;
            this.btClienteActualizar.Image = ((System.Drawing.Image)(resources.GetObject("btClienteActualizar.Image")));
            this.btClienteActualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btClienteActualizar.Location = new System.Drawing.Point(0, 104);
            this.btClienteActualizar.Name = "btClienteActualizar";
            this.btClienteActualizar.Size = new System.Drawing.Size(80, 23);
            this.btClienteActualizar.TabIndex = 3;
            this.btClienteActualizar.Text = "Actualizar";
            this.btClienteActualizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btClienteActualizar.UseVisualStyleBackColor = true;
            this.btClienteActualizar.Click += new System.EventHandler(this.btClienteActualizar_Click);
            // 
            // btClienteEliminar
            // 
            this.btClienteEliminar.BackColor = System.Drawing.SystemColors.Control;
            this.btClienteEliminar.ForeColor = System.Drawing.Color.Black;
            this.btClienteEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btClienteEliminar.Image")));
            this.btClienteEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btClienteEliminar.Location = new System.Drawing.Point(80, 104);
            this.btClienteEliminar.Name = "btClienteEliminar";
            this.btClienteEliminar.Size = new System.Drawing.Size(75, 23);
            this.btClienteEliminar.TabIndex = 4;
            this.btClienteEliminar.Text = "Eliminar";
            this.btClienteEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btClienteEliminar.UseVisualStyleBackColor = true;
            this.btClienteEliminar.Click += new System.EventHandler(this.btClienteEliminar_Click);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(0, 128);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 16);
            this.label6.TabIndex = 121;
            this.label6.Text = "Centro:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbRelacion
            // 
            this.cmbRelacion.DataSource = this.dsClientes1.ListaTipoRelacionClienteCentro;
            this.cmbRelacion.DisplayMember = "sLiteral";
            this.cmbRelacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRelacion.Location = new System.Drawing.Point(402, 143);
            this.cmbRelacion.Name = "cmbRelacion";
            this.cmbRelacion.Size = new System.Drawing.Size(109, 21);
            this.cmbRelacion.TabIndex = 2;
            this.cmbRelacion.ValueMember = "sValor";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(402, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 18);
            this.label4.TabIndex = 119;
            this.label4.Text = "Relación:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbEspecialidades
            // 
            this.cbEspecialidades.DataSource = this.dsClientes1.ListaTipoEspeciadadMed;
            this.cbEspecialidades.DisplayMember = "sLiteral";
            this.cbEspecialidades.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEspecialidades.Location = new System.Drawing.Point(527, 142);
            this.cbEspecialidades.Name = "cbEspecialidades";
            this.cbEspecialidades.Size = new System.Drawing.Size(272, 21);
            this.cbEspecialidades.TabIndex = 15;
            this.cbEspecialidades.ValueMember = "sValor";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(527, 126);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 18);
            this.label7.TabIndex = 6;
            this.label7.Text = "Especialidad:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel9
            // 
            this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel9.Controls.Add(this.panel2);
            this.panel9.Controls.Add(this.lblTotAficiones);
            this.panel9.Controls.Add(this.labelGradient5);
            this.panel9.Controls.Add(this.dgAficiones);
            this.panel9.Location = new System.Drawing.Point(526, 164);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(723, 124);
            this.panel9.TabIndex = 142;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.dgContactos);
            this.panel2.Controls.Add(this.lblTotContactosSAP);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 18);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(719, 102);
            this.panel2.TabIndex = 1;
            // 
            // dgContactos
            // 
            this.dgContactos.BackgroundColor = System.Drawing.Color.White;
            this.dgContactos.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.dgContactos.CaptionText = "Areas";
            this.dgContactos.CaptionVisible = false;
            this.dgContactos.DataMember = "ListaAreas_porCliente_SAP";
            this.dgContactos.DataSource = this.dsClientes2;
            this.dgContactos.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgContactos.Location = new System.Drawing.Point(-1, -2);
            this.dgContactos.Name = "dgContactos";
            this.dgContactos.ReadOnly = true;
            this.dgContactos.RowHeaderWidth = 30;
            this.dgContactos.Size = new System.Drawing.Size(717, 102);
            this.dgContactos.TabIndex = 4;
            this.dgContactos.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            this.dgContactos.TabStop = false;
            this.dgContactos.CurrentCellChanged += new System.EventHandler(this.dgContactos_CurrentCellChanged);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.DataGrid = this.dgContactos;
            this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn4,
            this.dataGridTextBoxColumn5,
            this.dataGridTextBoxColumn6});
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle1.MappingName = "ListaAreas_porCliente_SAP";
            this.dataGridTableStyle1.RowHeaderWidth = 30;
            // 
            // dataGridTextBoxColumn4
            // 
            this.dataGridTextBoxColumn4.Format = "";
            this.dataGridTextBoxColumn4.FormatInfo = null;
            this.dataGridTextBoxColumn4.HeaderText = "Cliente";
            this.dataGridTextBoxColumn4.MappingName = "iIdCliente";
            this.dataGridTextBoxColumn4.NullText = "";
            this.dataGridTextBoxColumn4.ReadOnly = true;
            this.dataGridTextBoxColumn4.Width = 75;
            // 
            // dataGridTextBoxColumn5
            // 
            this.dataGridTextBoxColumn5.Format = "";
            this.dataGridTextBoxColumn5.FormatInfo = null;
            this.dataGridTextBoxColumn5.HeaderText = "Cod. Area";
            this.dataGridTextBoxColumn5.MappingName = "iIdContacto";
            this.dataGridTextBoxColumn5.NullText = "";
            this.dataGridTextBoxColumn5.ReadOnly = true;
            this.dataGridTextBoxColumn5.Width = 75;
            // 
            // dataGridTextBoxColumn6
            // 
            this.dataGridTextBoxColumn6.Format = "";
            this.dataGridTextBoxColumn6.FormatInfo = null;
            this.dataGridTextBoxColumn6.HeaderText = "Nombre Area";
            this.dataGridTextBoxColumn6.MappingName = "sNombre";
            this.dataGridTextBoxColumn6.NullText = "";
            this.dataGridTextBoxColumn6.ReadOnly = true;
            this.dataGridTextBoxColumn6.Width = 450;
            // 
            // lblTotContactosSAP
            // 
            this.lblTotContactosSAP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.lblTotContactosSAP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotContactosSAP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotContactosSAP.ForeColor = System.Drawing.Color.Black;
            this.lblTotContactosSAP.Location = new System.Drawing.Point(521, 0);
            this.lblTotContactosSAP.Name = "lblTotContactosSAP";
            this.lblTotContactosSAP.Size = new System.Drawing.Size(60, 18);
            this.lblTotContactosSAP.TabIndex = 3;
            this.lblTotContactosSAP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotAficiones
            // 
            this.lblTotAficiones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.lblTotAficiones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotAficiones.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotAficiones.ForeColor = System.Drawing.Color.Black;
            this.lblTotAficiones.Location = new System.Drawing.Point(687, 0);
            this.lblTotAficiones.Name = "lblTotAficiones";
            this.lblTotAficiones.Size = new System.Drawing.Size(32, 18);
            this.lblTotAficiones.TabIndex = 11;
            this.lblTotAficiones.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelGradient5
            // 
            this.labelGradient5.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelGradient5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGradient5.ForeColor = System.Drawing.Color.White;
            this.labelGradient5.GradientColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.labelGradient5.GradientColorTwo = System.Drawing.Color.White;
            this.labelGradient5.Location = new System.Drawing.Point(0, 0);
            this.labelGradient5.Name = "labelGradient5";
            this.labelGradient5.Size = new System.Drawing.Size(719, 18);
            this.labelGradient5.TabIndex = 0;
            this.labelGradient5.Text = "Areas";
            this.labelGradient5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgAficiones
            // 
            this.dgAficiones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgAficiones.BackgroundColor = System.Drawing.Color.White;
            this.dgAficiones.CaptionVisible = false;
            this.dgAficiones.DataMember = "AficClientes_COM";
            this.dgAficiones.DataSource = this.dsClientes1;
            this.dgAficiones.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgAficiones.Location = new System.Drawing.Point(0, 18);
            this.dgAficiones.Name = "dgAficiones";
            this.dgAficiones.ReadOnly = true;
            this.dgAficiones.RowHeaderWidth = 17;
            this.dgAficiones.Size = new System.Drawing.Size(725, 102);
            this.dgAficiones.TabIndex = 0;
            this.dgAficiones.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyleAficiones});
            this.dgAficiones.CurrentCellChanged += new System.EventHandler(this.dgAficiones_CurrentCellChanged);
            // 
            // dataGridTableStyleAficiones
            // 
            this.dataGridTableStyleAficiones.DataGrid = this.dgAficiones;
            this.dataGridTableStyleAficiones.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dgAficionestAficion,
            this.dgAficionesIdAficion});
            this.dataGridTableStyleAficiones.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyleAficiones.MappingName = "AficClientes_COM";
            this.dataGridTableStyleAficiones.RowHeaderWidth = 17;
            // 
            // dgAficionestAficion
            // 
            this.dgAficionestAficion.Format = "";
            this.dgAficionestAficion.FormatInfo = null;
            this.dgAficionestAficion.HeaderText = "Afición";
            this.dgAficionestAficion.MappingName = "tAficion";
            this.dgAficionestAficion.NullText = "";
            this.dgAficionestAficion.Width = 400;
            // 
            // dgAficionesIdAficion
            // 
            this.dgAficionesIdAficion.Format = "";
            this.dgAficionesIdAficion.FormatInfo = null;
            this.dgAficionesIdAficion.HeaderText = "Código";
            this.dgAficionesIdAficion.MappingName = "sIdAficion";
            this.dgAficionesIdAficion.Width = 0;
            // 
            // dgAccionesMarktFechaEntrega
            // 
            this.dgAccionesMarktFechaEntrega.Format = "";
            this.dgAccionesMarktFechaEntrega.FormatInfo = null;
            this.dgAccionesMarktFechaEntrega.Width = -1;
            // 
            // dgAccionesMarkiEstado
            // 
            this.dgAccionesMarkiEstado.Format = "";
            this.dgAccionesMarkiEstado.FormatInfo = null;
            this.dgAccionesMarkiEstado.MappingName = "iEstado";
            this.dgAccionesMarkiEstado.NullText = "";
            this.dgAccionesMarkiEstado.Width = 0;

            // 
            // sqlConn
            // 
            this.sqlConn = Utiles._connection;
            this.sqlConn.FireInfoMessageEventOnUserErrors = false;


            // 
            // sqlDATipoMedico
            // 
            this.sqlDATipoMedico.SelectCommand = this.sqlCmdListaTipoMedico;
            this.sqlDATipoMedico.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaTipoClienteCOM", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("sValor", "sValor"),
                        new System.Data.Common.DataColumnMapping("sLiteral", "sLiteral")})});
            // 
            // sqlCmdListaTipoMedico
            // 
            this.sqlCmdListaTipoMedico.CommandText = "[ListaTipoClienteCOM]";
            this.sqlCmdListaTipoMedico.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdListaTipoMedico.Connection = this.sqlConn;
            this.sqlCmdListaTipoMedico.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null)});
            
            // 
            // sqlDAClasificacion
            // 
            this.sqlDAClasificacion.SelectCommand = this.sqlSCmdClasif;
            this.sqlDAClasificacion.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaTipoClasificacion", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("sValor", "sValor"),
                        new System.Data.Common.DataColumnMapping("sLiteral", "sLiteral")})});
            // 
            // sqlSCmdClasif
            // 
            this.sqlSCmdClasif.CommandText = "[ListaTipoClasificacion]";
            this.sqlSCmdClasif.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSCmdClasif.Connection = this.sqlConn;
            this.sqlSCmdClasif.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
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
            // sqlDARelacionCliCen
            // 
            this.sqlDARelacionCliCen.SelectCommand = this.sqlSCmdTipoRelacion;
            this.sqlDARelacionCliCen.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaTipoRelacionClienteCentro", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("sValor", "sValor"),
                        new System.Data.Common.DataColumnMapping("sLiteral", "sLiteral")})});
            // 
            // sqlSCmdTipoRelacion
            // 
            this.sqlSCmdTipoRelacion.CommandText = "[ListaTipoRelacionClienteCentro]";
            this.sqlSCmdTipoRelacion.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSCmdTipoRelacion.Connection = this.sqlConn;
            this.sqlSCmdTipoRelacion.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null)});
            // 
            // sqlDAEspec
            // 
            this.sqlDAEspec.SelectCommand = this.sqlSCmdEspecialidades;
            this.sqlDAEspec.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaTipoEspeciadadMed", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("sValor", "sValor"),
                        new System.Data.Common.DataColumnMapping("sLiteral", "sLiteral")})});
            // 
            // sqlSCmdEspecialidades
            // 
            this.sqlSCmdEspecialidades.CommandText = "[ListaTipoEspeciadadMed]";
            this.sqlSCmdEspecialidades.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSCmdEspecialidades.Connection = this.sqlConn;
            this.sqlSCmdEspecialidades.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null)});
            // 
            // sqlDAAfic
            // 
            this.sqlDAAfic.SelectCommand = this.sqlSCmdAficiones;
            this.sqlDAAfic.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaTipoAficiones", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("sValor", "sValor"),
                        new System.Data.Common.DataColumnMapping("sLiteral", "sLiteral")})});
            // 
            // sqlSCmdAficiones
            // 
            this.sqlSCmdAficiones.CommandText = "[ListaTipoAficiones]";
            this.sqlSCmdAficiones.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSCmdAficiones.Connection = this.sqlConn;
            this.sqlSCmdAficiones.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null)});
            // 
            // sqlCmdGetID
            // 
            this.sqlCmdGetID.CommandText = "[GetClienteIdTemp]";
            this.sqlCmdGetID.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdGetID.Connection = this.sqlConn;
            this.sqlCmdGetID.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdDelegado", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@theDate", System.Data.SqlDbType.DateTime, 8)});
            // 
            // sqlCmdGetCentro
            // 
            this.sqlCmdGetCentro.CommandText = "[ListaBuscaCentros]";
            this.sqlCmdGetCentro.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdGetCentro.Connection = this.sqlConn;
            this.sqlCmdGetCentro.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdDelegado", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sIdCentro", System.Data.SqlDbType.VarChar, 20),
            new System.Data.SqlClient.SqlParameter("@sDescripcion", System.Data.SqlDbType.VarChar, 100),
            new System.Data.SqlClient.SqlParameter("@iIdPoblacion", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sCodPostal", System.Data.SqlDbType.VarChar, 5),
            new System.Data.SqlClient.SqlParameter("@iIdProvincia", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sPoblacion", System.Data.SqlDbType.VarChar, 50),
            new System.Data.SqlClient.SqlParameter("@sIdRed", System.Data.SqlDbType.VarChar, 4)});
            // 
            // sqlCmdSetCliente
            // 
            this.sqlCmdSetCliente.CommandText = "[SetCliente]";
            this.sqlCmdSetCliente.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdSetCliente.Connection = this.sqlConn;
            this.sqlCmdSetCliente.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sIdCliente", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@sIdClienteTemp", System.Data.SqlDbType.VarChar, 15),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt, 2),
            new System.Data.SqlClient.SqlParameter("@sNombre", System.Data.SqlDbType.VarChar, 50),
            new System.Data.SqlClient.SqlParameter("@sApellido1", System.Data.SqlDbType.VarChar, 100),
            new System.Data.SqlClient.SqlParameter("@sApellido2", System.Data.SqlDbType.VarChar, 100),
            new System.Data.SqlClient.SqlParameter("@sTelefono", System.Data.SqlDbType.VarChar, 15)});
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
            // sqlDAClienteCOM
            // 
            this.sqlDAClienteCOM.SelectCommand = this.sqlSelectCommand5;
            this.sqlDAClienteCOM.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "GetCliente_COM", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iIdCliente", "iIdCliente"),
                        new System.Data.Common.DataColumnMapping("sIdCliente", "sIdCliente"),
                        new System.Data.Common.DataColumnMapping("sTipoCliente", "sTipoCliente"),
                        new System.Data.Common.DataColumnMapping("sIdClienteTemp", "sIdClienteTemp"),
                        new System.Data.Common.DataColumnMapping("sNombre", "sNombre"),
                        new System.Data.Common.DataColumnMapping("sApellidos1", "sApellidos1"),
                        new System.Data.Common.DataColumnMapping("sApellidos2", "sApellidos2"),
                        new System.Data.Common.DataColumnMapping("sTelefono", "sTelefono"),
                        new System.Data.Common.DataColumnMapping("iEstado", "iEstado"),
                        new System.Data.Common.DataColumnMapping("dFUM", "dFUM"),
                        new System.Data.Common.DataColumnMapping("bEnviadoCEN", "bEnviadoCEN"),
                        new System.Data.Common.DataColumnMapping("bEnviadoPDA", "bEnviadoPDA")}),
            new System.Data.Common.DataTableMapping("Table1", "Table1", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iIdCliente", "iIdCliente"),
                        new System.Data.Common.DataColumnMapping("sIdRed", "sIdRed"),
                        new System.Data.Common.DataColumnMapping("sIdClasificacion", "sIdClasificacion"),
                        new System.Data.Common.DataColumnMapping("dFAR", "dFAR"),
                        new System.Data.Common.DataColumnMapping("dFBR", "dFBR"),
                        new System.Data.Common.DataColumnMapping("iEstado", "iEstado")}),
            new System.Data.Common.DataTableMapping("Table2", "Table2", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iIdCliente", "iIdCliente"),
                        new System.Data.Common.DataColumnMapping("sTipoCliente_COM", "sTipoCliente_COM"),
                        new System.Data.Common.DataColumnMapping("sIdCaracteristica", "sIdCaracteristica"),
                        new System.Data.Common.DataColumnMapping("tObservaciones", "tObservaciones"),
                        new System.Data.Common.DataColumnMapping("sEMail", "sEMail"),
                        new System.Data.Common.DataColumnMapping("sFax", "sFax"),
                        new System.Data.Common.DataColumnMapping("sTelMovil", "sTelMovil"),
                        new System.Data.Common.DataColumnMapping("sDireccion", "sDireccion"),
                        new System.Data.Common.DataColumnMapping("iIdPoblacion", "iIdPoblacion"),
                        new System.Data.Common.DataColumnMapping("dFecNacimiento", "dFecNacimiento"),
                        new System.Data.Common.DataColumnMapping("dFecAniversario", "dFecAniversario"),
                        new System.Data.Common.DataColumnMapping("sNIF", "sNIF"),
                        new System.Data.Common.DataColumnMapping("bAsignado", "bAsignado"),
                        new System.Data.Common.DataColumnMapping("bOcasional", "bOcasional"),
                        new System.Data.Common.DataColumnMapping("dFUM", "dFUM"),
                        new System.Data.Common.DataColumnMapping("bEnviadoCEN", "bEnviadoCEN")}),
            new System.Data.Common.DataTableMapping("Table3", "Table3", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iIdCliente", "iIdCliente"),
                        new System.Data.Common.DataColumnMapping("iIdCentro", "iIdCentro"),
                        new System.Data.Common.DataColumnMapping("sIdTipoRelacionCliCen", "sIdTipoRelacionCliCen"),
                        new System.Data.Common.DataColumnMapping("dFAR", "dFAR"),
                        new System.Data.Common.DataColumnMapping("dFBR", "dFBR"),
                        new System.Data.Common.DataColumnMapping("iEstado", "iEstado"),
                        new System.Data.Common.DataColumnMapping("sIdRed", "sIdRed")}),
            new System.Data.Common.DataTableMapping("Table4", "Table4", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iIdCliente", "iIdCliente"),
                        new System.Data.Common.DataColumnMapping("sIdEspecialidad", "sIdEspecialidad"),
                        new System.Data.Common.DataColumnMapping("dFUM", "dFUM"),
                        new System.Data.Common.DataColumnMapping("bEnviadoCEN", "bEnviadoCEN"),
                        new System.Data.Common.DataColumnMapping("iEstado", "iEstado")}),
            new System.Data.Common.DataTableMapping("Table5", "Table5", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iIdCliente", "iIdCliente"),
                        new System.Data.Common.DataColumnMapping("sIdAficion", "sIdAficion"),
                        new System.Data.Common.DataColumnMapping("dFUM", "dFUM"),
                        new System.Data.Common.DataColumnMapping("bEnviadoCEN", "bEnviadoCEN"),
                        new System.Data.Common.DataColumnMapping("iEstado", "iEstado")}),
            new System.Data.Common.DataTableMapping("Table6", "Table6", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iIdCliente", "iIdCliente"),
                        new System.Data.Common.DataColumnMapping("sIdProducto", "sIdProducto"),
                        new System.Data.Common.DataColumnMapping("iPrioridad", "iPrioridad"),
                        new System.Data.Common.DataColumnMapping("dFUM", "dFUM"),
                        new System.Data.Common.DataColumnMapping("bEnviadoCEN", "bEnviadoCEN"),
                        new System.Data.Common.DataColumnMapping("iEstado", "iEstado")}),
            new System.Data.Common.DataTableMapping("Table7", "Table7", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iIdAccion", "iIdAccion"),
                        new System.Data.Common.DataColumnMapping("iIdCliente", "iIdCliente"),
                        new System.Data.Common.DataColumnMapping("dFechaEntrega", "dFechaEntrega"),
                        new System.Data.Common.DataColumnMapping("fCantidad", "fCantidad"),
                        new System.Data.Common.DataColumnMapping("tObservaciones", "tObservaciones"),
                        new System.Data.Common.DataColumnMapping("sCCoste", "sCCoste"),
                        new System.Data.Common.DataColumnMapping("dFUM", "dFUM"),
                        new System.Data.Common.DataColumnMapping("benviadoCEN", "benviadoCEN")})});
            // 
            // sqlSelectCommand5
            // 
            this.sqlSelectCommand5.CommandText = "[GetCliente_COM]";
            this.sqlSelectCommand5.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand5.Connection = this.sqlConn;
            this.sqlSelectCommand5.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4)});
            // 
            // sqlCmdSetCliente_COM
            // 
            this.sqlCmdSetCliente_COM.CommandText = "[SetClienteCOM]";
            this.sqlCmdSetCliente_COM.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdSetCliente_COM.Connection = this.sqlConn;
            this.sqlCmdSetCliente_COM.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sTipoCliente_COM", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@sNumColegiado", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@sIdCaracteristica", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@tObservaciones", System.Data.SqlDbType.VarChar, 2147483647),
            new System.Data.SqlClient.SqlParameter("@sEMail", System.Data.SqlDbType.VarChar, 50),
            new System.Data.SqlClient.SqlParameter("@sFax", System.Data.SqlDbType.VarChar, 15),
            new System.Data.SqlClient.SqlParameter("@sTelMovil", System.Data.SqlDbType.VarChar, 15),
            new System.Data.SqlClient.SqlParameter("@sDireccion", System.Data.SqlDbType.VarChar, 100),
            new System.Data.SqlClient.SqlParameter("@iIdPoblacion", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@dFecNacimiento", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@dFecAniversario", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@sNIF", System.Data.SqlDbType.VarChar, 20),
            new System.Data.SqlClient.SqlParameter("@dFUM", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@bEnviadoCEN", System.Data.SqlDbType.Bit, 1)});
            // 
            // sqlCmdSetCentrosClientes_COM
            // 
            this.sqlCmdSetCentrosClientes_COM.CommandText = "[SetCentrosClientesCOM]";
            this.sqlCmdSetCentrosClientes_COM.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdSetCentrosClientes_COM.Connection = this.sqlConn;
            this.sqlCmdSetCentrosClientes_COM.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iAccion", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdCentro", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sIdTipoRelacionCliCen", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@sIdRed", System.Data.SqlDbType.VarChar, 4),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt, 2)});
            // 
            // sqlCmdSetEspecCLiente_COM
            // 
            this.sqlCmdSetEspecCLiente_COM.CommandText = "[SetEspecClientesCOM]";
            this.sqlCmdSetEspecCLiente_COM.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdSetEspecCLiente_COM.Connection = this.sqlConn;
            this.sqlCmdSetEspecCLiente_COM.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sIdEspecialidad", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@dFUM", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@bEnviadoCen", System.Data.SqlDbType.Bit, 1),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt, 2)});
            // 
            // sqlCmdSetAficClientesCOM
            // 
            this.sqlCmdSetAficClientesCOM.CommandText = "[SetAficClientesCOM]";
            this.sqlCmdSetAficClientesCOM.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdSetAficClientesCOM.Connection = this.sqlConn;
            this.sqlCmdSetAficClientesCOM.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sIdAficion", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@dFUM", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@bEnviadoCen", System.Data.SqlDbType.Bit, 1),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt, 2)});
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
            // sqlCmdSetProdClientesCOM
            // 
            this.sqlCmdSetProdClientesCOM.CommandText = "[SetProdClientesCOM]";
            this.sqlCmdSetProdClientesCOM.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdSetProdClientesCOM.Connection = this.sqlConn;
            this.sqlCmdSetProdClientesCOM.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sIdProducto", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@iPrioridad", System.Data.SqlDbType.SmallInt, 2),
            new System.Data.SqlClient.SqlParameter("@dFUM", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@bEnviadoCen", System.Data.SqlDbType.Bit, 1),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt, 2)});
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
            // sqlcmdExisteClienteRed
            // 
            this.sqlcmdExisteClienteRed.CommandText = "[ExisteClienteRed]";
            this.sqlcmdExisteClienteRed.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlcmdExisteClienteRed.Connection = this.sqlConn;
            this.sqlcmdExisteClienteRed.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sIdRed", System.Data.SqlDbType.VarChar, 4)});
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.HeaderText = "Nombre Area";
            this.dataGridTextBoxColumn3.MappingName = "sNombre";
            this.dataGridTextBoxColumn3.ReadOnly = true;
            this.dataGridTextBoxColumn3.Width = 75;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "Cod. Area";
            this.dataGridTextBoxColumn2.MappingName = "iIdContacto";
            this.dataGridTextBoxColumn2.ReadOnly = true;
            this.dataGridTextBoxColumn2.Width = 75;
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "Cliente";
            this.dataGridTextBoxColumn1.MappingName = "iIdCliente";
            this.dataGridTextBoxColumn1.ReadOnly = true;
            this.dataGridTextBoxColumn1.Width = 75;
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
            // listaAreasporClienteSAPBindingSource
            // 
            this.listaAreasporClienteSAPBindingSource.DataMember = "ListaAreas_porCliente_SAP";
            this.listaAreasporClienteSAPBindingSource.DataSource = this.dsClientes2;
            // 
            // listaTipoAreaCliSAPBindingSource
            // 
            this.listaTipoAreaCliSAPBindingSource.DataMember = "ListaTipoAreaCliSAP";
            this.listaTipoAreaCliSAPBindingSource.DataSource = this.dsClientes2;
            // 
            // listaTipoAreaCliSAPDataTableBindingSource
            // 
            this.listaTipoAreaCliSAPDataTableBindingSource.DataSource = typeof(GESTCRM.Formularios.DataSets.dsClientes.ListaTipoAreaCliSAPDataTable);
            // 
            // frmAltaMedicos
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(1263, 644);
            this.Controls.Add(this.pnlDatosSec);
            this.Controls.Add(this.pnCliente);
            this.Controls.Add(this.ucBotoneraSecundaria1);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAltaMedicos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alta de Médicos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmAltaMedicos_Closing);
            this.Load += new System.EventHandler(this.frmAltaMedicos_Load);
            this.pnCliente.ResumeLayout(false);
            this.pnCliente.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsClientes1)).EndInit();
            this.pnlDatosSec.ResumeLayout(false);
            this.pnlDatosSec.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsClientes2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupAccCantidad)).EndInit();
            this.panel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgAccionesMark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udPrioridad)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgProductos)).EndInit();
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgEspecialidades)).EndInit();
            this.pnlCentros.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgCentros)).EndInit();
            this.panel9.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgContactos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgAficiones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listaAreasporClienteSAPBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listaTipoAreaCliSAPBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listaTipoAreaCliSAPDataTableBindingSource)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void frmAltaMedicos_Load(object sender, System.EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;
			try
			{
				
				GESTCRM.Utiles.Formato_Formulario(this);

				//if(this.Parent == null) this.WindowState = FormWindowState.Normal;
			
				// inhabilita Todos los botones de la barra
				this.ucBotoneraSecundaria1.btEditar.Enabled = false;
				this.ucBotoneraSecundaria1.btNuevo.Enabled=false;
				this.ucBotoneraSecundaria1.btEliminar.Enabled = false;
				this.ucBotoneraSecundaria1.btGrabar.Enabled = false;
 
				this.ucBotoneraSecundaria1.btSalir.Click += new EventHandler(btSalir_Click);  
				this.ucBotoneraSecundaria1.btGrabar.Click += new EventHandler(btGrabar_Click);  

				this.Param_iIdDelegado = GESTCRM.Clases.Configuracion.iIdDelegado;
				
				// Es un nuevo médico. Genera el Identificador Temporal
				if (this.Param_iIdCliente ==-1 ) 
				{
					this.Param_iEstado = -3;
					this.Param_sIdClienteTemp = this.GetIDTemp();
					this.Param_iIdCliente = int.Parse(this.Param_sIdClienteTemp.Substring(0,3).ToString()  + this.Param_sIdClienteTemp.Substring(5,5).ToString()) ;    
				}

				//Application.DoEvents();

				Inicializar_DataGrids();

				//Application.DoEvents();
 
				Inicializar_Combos();

				//Application.DoEvents();

				DoBindings();

				//Application.DoEvents();

				this.Inicializar_Cliente(); 	

				//Application.DoEvents();

				if(this.Param_TipoAcceso == "A")
				{
					this.btBuscarProducto.Enabled = false;
					this.btBuscaAccion.Enabled = false;
				}
				
				if(this.Param_iIdCliente>-1)
				{

					if(this.Param_TipoAcceso == "M")
					{
						if((this.Param_iEstado!=0 && this.Param_iEstado!=-3)||(this.Param_iEstado==-3 && this.dsClientes1.Clientes[0].bEnviadoCEN ) || !EsDeMiRed()) this.Param_TipoAcceso="C";
						//else if(this.Var_bEnviadoCEN!=0) this.Param_TipoAcceso="C";
					}

				}

				//El delegado sólo tiene acceso de Consulta
				if(GESTCRM.Clases.Configuracion.iGClientesCOM==1) this.Param_TipoAcceso="C";

				switch(this.Param_TipoAcceso)
				{
					case "A": this.lblTitulo.Text = "Nuevo Cliente Personas";
						this.txtObsMedico.Text ="NO INTRODUCIR COMENTARIOS PERSONALES";
						this.labelGradient1.Text += " (Obligatorio)";
						this.labelGradient3.Text += " (Obligatorio)";
						Saved = false;
						this.ActivarAcciones(false); 	
						this.HabilitarCampos(true); 
						break;
					case "M": this.lblTitulo.Text = "Modificación de Datos de Cliente Personas";
						Saved = false;
						this.labelGradient1.Text += " (Obligatorio)";
						this.labelGradient3.Text += " (Obligatorio)";
						this.HabilitaGrabar(); 
						this.textDeleted=true;
						//						this.Inicializar_Cliente(); 	
						//this.ActivarAcciones((this.dsClientes1.ProdClientes_COM.Rows.Count >0) && this.Param_iEstado == 0  ); 	
						this.Activar_AccionesMark(); 
						this.HabilitarCampos((this.Param_iEstado==-3 && !this.dsClientes1.Clientes[0].bEnviadoCEN)); 
						HabilitarCamposSiVacios();
						//						foreach(DataTable dt in this.dsClientes1.Tables )
						//						{
						//							foreach(DataRow dr in dt.Rows ) dr.BeginEdit();
						//						}
						//

						break;
					case "C": this.lblTitulo.Text = "Consulta de Datos de Cliente Personas"; 
						//						this.Inicializar_Cliente();
						this.ActivarAcciones(false);
						this.HabilitarCampos(false); 
						this.txtDireccion.Enabled = false;
						this.btBuscarPob.Enabled = false;
						this.cmbClasif.Enabled = false;
						this.btActAfic.Enabled = false;
						this.btElimAfic.Enabled=false;
						this.cmbAficiones.Enabled = false;
						this.btActualizarEspec.Enabled= false;
						this.btEliminarEspec.Enabled=false;
						this.cbEspecialidades.Enabled = false;
						this.btActualizarProd.Enabled=false;
						this.btEliminarProd.Enabled=false;
						this.btBuscarProducto.Enabled = false;
						this.btBuscarCentro.Enabled = false;
						this.btClienteActualizar.Enabled=false;
						this.btClienteEliminar.Enabled = false;
						this.txtNIF.Enabled=false; 
						this.txtTelefono.Enabled=false;
						this.txtMovil.Enabled=false;
						this.txtFax.Enabled=false;
						this.txtEMail.Enabled=false;
						this.dtFechaAniv.Enabled =false;
						this.dtFechaNac.Enabled=false;
						this.txtObsMedico.Enabled=false;
						this.udPrioridad.Enabled=false;
						this.cmbRelacion.Enabled = false; 
						this.Saved=true;
						break;	
					default: break;
				}

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


				Application.DoEvents();


				if(this.Param_TipoAcceso=="C")
				{
					this.contextMenu1.Dispose();
				}

				this.SalirDesdeGuardar=true;
			}
			catch(Exception ex)
			{
				Mensajes.ShowError(ex.Message);
			}
			Cursor.Current = Cursors.Default;

		}

		bool EsDeMiRed ()
		{
			int iExiste = 0;
			try
			{
                //---- GSG (10/09/2014)
                //sqlConn.Open();
                if (sqlConn.State == ConnectionState.Closed)
                    sqlConn.Open();

				sqlcmdExisteClienteRed.Parameters["@iIdCliente"].Value = Param_iIdCliente;
				sqlcmdExisteClienteRed.Parameters["@sIdRed"].Value = Clases.Configuracion.sIdRed;
				iExiste = (int) sqlcmdExisteClienteRed.ExecuteScalar();
			}
			catch(Exception Ex)
			{
				//MessageBox.Show ("Error en EsDeMiRed "+ Ex.ToString());
                Mensajes.ShowError("Error en EsDeMiRed: " + Ex.ToString());
				return false;
			}
			finally
			{
				sqlConn.Close();
			}
			if (iExiste == 0) 
				return false;
			else
				return true;
		}
		
		#region DoBindings
		private void DoBindings()
		{
			this.txtProvincia.DataBindings.Add("Text", this.dsClientes1, "Clientes_COM.sProvincia");
			this.txtPoblacion.DataBindings.Add("Text", this.dsClientes1, "Clientes_COM.sPoblacion");
			this.txtCP.DataBindings.Add("Text", this.dsClientes1, "Clientes_COM.CodPostal");
			this.txtDireccion.DataBindings.Add("Text", this.dsClientes1, "Clientes_COM.sDireccion");
			//			this.dtFechaAniv.DataBindings.Add("Value", this.dsClientes1, "Clientes_COM.dFecAniversario");
			//			this.dtFechaNac.DataBindings.Add("Value", this.dsClientes1, "Clientes_COM.dFecNacimiento");
			this.txtObsMedico.DataBindings.Add("Text", this.dsClientes1, "Clientes_COM.tObservaciones");
			this.txtNIF.DataBindings.Add("Text", this.dsClientes1, "Clientes_COM.sNIF");
			this.txtEMail.DataBindings.Add("Text", this.dsClientes1, "Clientes_COM.sEMail");
			this.txtFax.DataBindings.Add("Text", this.dsClientes1, "Clientes_COM.sFax");
			this.txtMovil.DataBindings.Add("Text", this.dsClientes1, "Clientes_COM.sTelMovil");
			this.txtApe2.DataBindings.Add("Text", this.dsClientes1, "Clientes.sApellidos2");
			this.txtApe1.DataBindings.Add("Text", this.dsClientes1, "Clientes.sApellidos1");
			this.txtNombre.DataBindings.Add("Text", this.dsClientes1, "Clientes.sNombre");
			this.txtTelefono.DataBindings.Add("Text", this.dsClientes1, "Clientes.sTelefono");

			//			this.dsClientes1.AficClientes_COM.DefaultView.RowFilter="iEstado IN (0,-3)";  	
			//			this.dsClientes1.ProdClientes_COM.DefaultView.RowFilter="iEstado IN (0,-3)";  	
			//			this.dsClientes1.EspecClientes_COM.DefaultView.RowFilter="iEstado IN (0,-3)";  	
			//			this.dsClientes1.CentrosClientes_COM.DefaultView.RowFilter="iEstado IN (0,-3)";  	
			//			this.dsClientes1.AccionesMarkClientes.DefaultView.RowFilter="iEstado IN (0,-3)";  
	
            //---- GSG (07/10/2014)
			//this.dsClientes1.AficClientes_COM.DefaultView.RowFilter="iEstado ="+ this.dsClientes1.Clientes[0].iEstado.ToString();
            this.dsClientes2.ListaAreas_porCliente_SAP.DefaultView.RowFilter = "iEstado = 0 OR iEstado = -3";	
            //---- FI GSG 
			this.dsClientes1.ProdClientes_COM.DefaultView.RowFilter="iEstado ="+ this.dsClientes1.Clientes[0].iEstado.ToString();  		
			this.dsClientes1.EspecClientes_COM.DefaultView.RowFilter="iEstado ="+ this.dsClientes1.Clientes[0].iEstado.ToString();  	
			this.dsClientes1.CentrosClientes_COM.DefaultView.RowFilter="iEstado ="+ this.dsClientes1.Clientes[0].iEstado.ToString();  	 	
			this.dsClientes1.AccionesMarkClientes.DefaultView.RowFilter="iEstado ="+ this.dsClientes1.Clientes[0].iEstado.ToString();  	

			this.dgEspecialidades.DataSource = this.dsClientes1.EspecClientes_COM;
            //---- GSG (07/10/2014)
			//this.dgAficiones.DataSource = this.dsClientes1.AficClientes_COM;
            this.dgContactos.DataSource = this.dsClientes2.ListaAreas_porCliente_SAP; 



//			this.cmbTipoMedico.DataSource = this.dsClientes1.ListaTipoClienteCOM;
//			this.cmbClasif.SelectedValue  = this.dsClientes1.ClientesRedes[0].sIdClasificacion.ToString();    
			//this.cmbClasif.DataSource = this.dsClientes1.ListaTipoClasificacion;

		}
		#endregion

		#region Inicializar_DataGrids
		private void Inicializar_DataGrids()
		{
			try
			{	
				//Regoge los Datos con un solo DataAdapter, haciendo los TableMappings Correspondientes

				this.dsClientes1.Clientes.Rows.Clear();
				this.dsClientes1.ClientesRedes.Rows.Clear();
				this.dsClientes1.Clientes_COM.Rows.Clear();
				this.dsClientes1.CentrosClientes_COM.Rows.Clear();
				this.dsClientes1.EspecClientes_COM.Rows.Clear();
				//this.dsClientes1.AficClientes_COM.Rows.Clear();
                this.dsClientes2.ListaAreas_porCliente_SAP.Rows.Clear(); //---- GSG (07/10/2014)
				this.dsClientes1.ProdClientes_COM.Rows.Clear();
				this.dsClientes1.AccionesMarkClientes.Rows.Clear();
  
				this.sqlDAClienteCOM.TableMappings.Clear();
				this.sqlDAClienteCOM.TableMappings.Add("Table","Clientes");   
				this.sqlDAClienteCOM.TableMappings.Add("Table1","ClientesRedes");   
				this.sqlDAClienteCOM.TableMappings.Add("Table2","Clientes_COM");   
				this.sqlDAClienteCOM.TableMappings.Add("Table3","CentrosClientes_COM");   
				this.sqlDAClienteCOM.TableMappings.Add("Table4","EspecClientes_COM");   
				this.sqlDAClienteCOM.TableMappings.Add("Table5","AficClientes_COM");   
				this.sqlDAClienteCOM.TableMappings.Add("Table6","ProdClientes_COM");   
				this.sqlDAClienteCOM.TableMappings.Add("Table7","AccionesMarkClientes");   

				if (this.Param_iIdCliente>0 && (this.Param_TipoAcceso =="M" || this.Param_TipoAcceso == "C")  )
				{
					this.sqlDAClienteCOM.SelectCommand.Parameters["@iIdCliente"].Value = this.Param_iIdCliente;
    
					this.sqlDAClienteCOM.Fill(this.dsClientes1);
					this.dsClientes1.AcceptChanges();

                    //---- GSG (07/10/2014)
                    this.sqldaListaAreasporCliente_SAP.SelectCommand.Parameters["@iIdCliente"].Value = this.Param_iIdCliente;
                    this.sqldaListaAreasporCliente_SAP.Fill(this.dsClientes2);
                    this.dsClientes2.AcceptChanges();
                    
				}
				if (this.dsClientes1.Clientes_COM!=null && this.dsClientes1.Clientes_COM.Rows.Count>0)
				{
					this.fNacData = (!this.dsClientes1.Clientes_COM[0].IsdFecNacimientoNull());
					this.fMatData = (!this.dsClientes1.Clientes_COM[0].IsdFecAniversarioNull());
				}


                //---- GSG (07/10/2014)

				//DataGrid de Aficiones de un ClienteCOM
                //GESTCRM.Utiles.Formatear_DataGrid(this,this.dgAficiones,null,true,this.contextMenu1);
                ////				this.dsClientes1.ListaAficClientes_COM.Rows.Clear();
                ////				if (this.Param_iIdCliente>0 )
                ////				{
                ////					this.sqlDAAficCOM.SelectCommand.Parameters["@iIdCliente"].Value = this.Param_iIdCliente;
                ////					this.sqlDAAficCOM.Fill(this.dsClientes1);
                ////				}
                //this.lblTotAficiones.Text = this.dsClientes1.AficClientes_COM.DefaultView.Count.ToString();
                //if(int.Parse(this.lblTotAficiones.Text.ToString())>0)
                //{
                //    this.dgAficiones.CurrentCell = new DataGridCell(0,1);
                //    this.dgAficiones.CurrentCell = new DataGridCell(0,0);
                //}

                //---- FI GSG
				 

				//DataGrid de Especialidades de un ClienteCOM
				GESTCRM.Utiles.Formatear_DataGrid(this,this.dgEspecialidades,null,true,this.contextMenu1);
				//				this.dsClientes1.ListaEspecClientes_COM.Rows.Clear();
				//				if (this.Param_iIdCliente>0 )
				//				{
				//					this.sqlDAEspecCLiente.SelectCommand.Parameters["@iIdCliente"].Value = this.Param_iIdCliente;
				//					this.sqlDAEspecCLiente.Fill(this.dsClientes1);
				//				}
				this.lblTotEspec.Text = this.dsClientes1.EspecClientes_COM.DefaultView.Count.ToString();
				if(int.Parse(this.lblTotEspec.Text.ToString())>0)
				{
					this.dgEspecialidades.CurrentCell = new DataGridCell(0,1);
					this.dgEspecialidades.CurrentCell = new DataGridCell(0,0);
				}
				//DataGrid de Productos asociados a un ClienteCOM
				GESTCRM.Utiles.Formatear_DataGrid(this,this.dgProductos,null,true,this.contextMenu1);
				//				this.dsClientes1.ListaProdClientes_COM.Rows.Clear();
				//				if (this.Param_iIdCliente>0 )
				//				{
				//					this.sqlDAListaProdClientes_COM.SelectCommand.Parameters["@iIdCliente"].Value = this.Param_iIdCliente;
				//					this.sqlDAListaProdClientes_COM.Fill(this.dsClientes1);
				//				}
				this.dgProductos.DataSource=this.dsClientes1.ProdClientes_COM;    
				this.lblTotProd.Text = this.dsClientes1.ProdClientes_COM.DefaultView.Count.ToString();
				if(int.Parse(this.lblTotProd.Text.ToString())>0)
				{
					this.dgProductos.CurrentCell = new DataGridCell(0,1);
					this.dgProductos.CurrentCell = new DataGridCell(0,0);
				}

				//DataGrid de Centros asociados a un ClienteCOM
				GESTCRM.Utiles.Formatear_DataGrid(this.dgCentros,null,this.contextMenu1);
				//				this.dsClientes1.ListaCentros_porCliente_COM.Clear();
				//				if (this.Param_iIdCliente>0 )
				//				{
				//					this.sqlDACentrosClienteCOM.SelectCommand.Parameters["@iIdCliente"].Value = this.Param_iIdCliente;
				//					this.sqlDACentrosClienteCOM.Fill(this.dsClientes1);
				//				}
				//				this.dtCentros=GESTCRM.Utiles.Inicializar_Tabla(this.dsClientes1.CentrosClientes_COM);
				//				this.dgCentros.DataSource = this.dtCentros;
				this.dgCentros.DataSource = this.dsClientes1.CentrosClientes_COM  ;
				this.lblTotCentros.Text = this.dsClientes1.CentrosClientes_COM.DefaultView.Count.ToString();
				//				this.lblTotCentros.Text = this.dtCentros.Rows.Count.ToString();
				if(int.Parse(this.lblTotCentros.Text.ToString())>0)
				{
					this.dgCentros.CurrentCell = new DataGridCell(0,1);
					this.dgCentros.CurrentCell = new DataGridCell(0,0);
				}

				//DataGrid de Acciones asociados a un ClienteCOM
				GESTCRM.Utiles.Formatear_DataGrid(this.dgAccionesMark,null,this.contextMenu1);
				//				this.dsClientes1.ListaAccionesMarkClientes.Clear();
				//				if (this.Param_iIdCliente>0 )
				//				{
				//					this.sqlDAAccionesMarkCliente.SelectCommand.Parameters["@iIdCliente"].Value = this.Param_iIdCliente;
				//					this.sqlDAAccionesMarkCliente.Fill(this.dsClientes1);
				//				}
				//				//				this.dtAccionesMark.Columns["dFechaEntrega"].DataType=System.Type.GetType("System.DateTime");
				//				this.dtAccionesMark = GESTCRM.Utiles.Inicializar_Tabla(this.dsClientes1.AccionesMarkClientes);
				//				this.dgAccionesMark.DataSource = this.dtAccionesMark;
				this.dgAccionesMark.DataSource = this.dsClientes1.AccionesMarkClientes;  
				//				this.lblTotAcciones.Text = this.dtAccionesMark.Rows.Count.ToString();
				this.lblTotAcciones.Text = this.dsClientes1.AccionesMarkClientes.DefaultView.Count.ToString();   
				if(int.Parse(this.lblTotAcciones.Text.ToString())>0)
				{
					this.dgAccionesMark.CurrentCell = new DataGridCell(0,1);
					this.dgAccionesMark.CurrentCell = new DataGridCell(0,0);
				}


                //---- GSG (07/10/2014)
                // Datagrid areas ClienteCOM
                GESTCRM.Utiles.Formatear_DataGrid(this.dgContactos, null, this.contextMenu1);

                this.dgContactos.DataSource = this.dsClientes2.ListaAreas_porCliente_SAP;

                this.lblTotAficiones.Text = this.dsClientes2.ListaAreas_porCliente_SAP.DefaultView.Count.ToString();

                if (int.Parse(this.lblTotAficiones.Text.ToString()) > 0)
                {
                    this.dgContactos.CurrentCell = new DataGridCell(0, 1);
                    this.dgContactos.CurrentCell = new DataGridCell(0, 0);
                }

                //---- FI GSG



				// si es nuevo, crealos nuevos registros de las tablas con los valores por defecto
				if (this.Param_TipoAcceso=="A")
				{
					DataRow dr = this.dsClientes1.ClientesRedes.NewRow();
 
 
					dr["sIdRed"]=GESTCRM.Clases.Configuracion.sIdRed.ToString();
					dr["sIdClasificacion"]=Convert.ToString(null); 
					dr["dFAR"]=DateTime.Now;
					dr["dFBR"]=Convert.ToDateTime(null);
					dr["iEstado"]=this.Param_iEstado;
 
					this.dsClientes1.ClientesRedes.Rows.Add(dr);
					//					this.dsClientes1.ClientesRedes.AcceptChanges();   

					dr = this.dsClientes1.Clientes.NewRow();
   
					dr["iIdCliente"]= this.Param_iIdCliente;
					dr["sIdCLiente"]= this.Param_sIdClienteTemp ;
					dr["sIdClienteTemp"]=this.Param_sIdClienteTemp ;
					dr["sTipoCliente"]="C";
					dr["sNombre"]=DBNull.Value ;
					dr["sApellidos1"]=DBNull.Value ;
					dr["sApellidos2"]=DBNull.Value ;
					dr["sTelefono"]=DBNull.Value ;
					dr["iEstado"]=this.Param_iEstado;
					dr["dFUM"]=DateTime.Now ;
					dr["bEnviadoCen"]=0;
					dr["bEnviadoPDA"]=0;
 
					this.dsClientes1.Clientes.Rows.Add(dr);
					//					this.dsClientes1.Clientes.AcceptChanges (); 
 
					dr = this.dsClientes1.Clientes_COM.NewRow();

					dr["iIdCliente"]=this.Param_iIdCliente ;
					dr["sTipoCliente_COM"]=Convert.ToString(null); 
					dr["sNumColegiado"]=DBNull.Value ;
					dr["tObservaciones"]=DBNull.Value  ;
					dr["sEMail"]=DBNull.Value  ;
					dr["sFax"]=DBNull.Value  ;
					dr["sTelMovil"]=DBNull.Value  ;
					dr["sDireccion"]=DBNull.Value  ;
					dr["iIdPoblacion"]=DBNull.Value; 
					dr["dFecNacimiento"]=DBNull.Value;
					dr["dFecAniversario"]=DBNull.Value;
					dr["sNIF"]=DBNull.Value  ;
					dr["bAsignado"]=0;
					dr["bOcasional"]=0;
					dr["dFUM"]=DateTime.Now ;
					dr["bEnviadoCEN"]=0;

					this.dsClientes1.Clientes_COM.Rows.Add(dr);
					//					this.dsClientes1.Clientes_COM.AcceptChanges();  
					this.dsClientes1.AcceptChanges(); 
				
				}
			}
			catch(Exception e){Mensajes.ShowError(e.Message);}
		}
		private void Formatear_DataGrids()
		{
			try
			{	
                //---- GSG (07/10/2014)
				//DataGrid de Aficiones de un ClienteCOM
				//GESTCRM.Utiles.Formatear_DataGrid(this,this.dgAficiones,null,true,this.contextMenu1);
                //DataGrid de Areas de un ClienteCOM
                GESTCRM.Utiles.Formatear_DataGrid(this, this.dgContactos, null, true, this.contextMenu1);

                //---- FI GSG

				//DataGrid de Especialidades de un ClienteCOM
				GESTCRM.Utiles.Formatear_DataGrid(this,this.dgEspecialidades,null,true,this.contextMenu1);
				//DataGrid de Productos asociados a un ClienteCOM
				GESTCRM.Utiles.Formatear_DataGrid(this,this.dgProductos,null,true,this.contextMenu1);

				//DataGrid de Centros asociados a un ClienteCOM
				GESTCRM.Utiles.Formatear_DataGrid(this.dgCentros,null,this.contextMenu1);

				//DataGrid de Acciones asociados a un ClienteCOM
				GESTCRM.Utiles.Formatear_DataGrid(this.dgAccionesMark,null,this.contextMenu1);


			}
			catch(Exception e){Mensajes.ShowError(e.Message);}
		}
		#endregion

		#region  Acciones de Botones y Carga de Dataset
		/// <summary>
		/// Inicializa los combos con los valores 
		/// </summary>
		#region Inicializar_Combos
		private void Inicializar_Combos()
		{
			try
			{
				// Combo Tipo Médico
				this.sqlDATipoMedico.Fill(this.dsClientes1);
				this.dsClientes1.ListaTipoClienteCOM.AcceptChanges();

				// Combo clasificacion
				this.sqlDAClasificacion.Fill(this.dsClientes1);
				this.dsClientes1.ListaTipoClasificacion.AcceptChanges();
   
				// Combo TipoRelacion
				this.sqlDARelacionCliCen.Fill(this.dsClientes1);
				this.dsClientes1.ListaTipoRelacionClienteCentro.AcceptChanges();
  
				// Combo especialidades
				this.sqlDAEspec.Fill(this.dsClientes1);
				this.dsClientes1.ListaTipoEspeciadadMed.AcceptChanges();

                //---- GSG (07/10/2014)
				// Combo Aficiones
                //this.sqlDAAfic.Fill(this.dsClientes1);  
                //this.dsClientes1.ListaTipoAficiones.AcceptChanges();
                // Combo Areas
                this.sqldaListaTipoAreasClienteSAP.Fill(this.dsClientes2);
                this.dsClientes2.ListaTipoAreaCliSAP.AcceptChanges();
                
    

			}
			catch(Exception e){Mensajes.ShowError(e.Message);}
		}
		#endregion
		#region Inicializar_Botonera
		private void Inicializar_Botonera()
		{
			try
			{
				this.ucBotoneraSecundaria1.btSalir.Click += new EventHandler(btSalir_Click);
				//				this.ucBotoneraSecundaria1.btGrabar.Click += new EventHandler(btGrabar_Click);
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion
		#region btSalir_Click

		private void btSalir_Click(object sender, System.EventArgs e)
		{	

			try
			{
				if (this.Param_TipoAcceso!="C")
				{
					switch (this.ucBotoneraSecundaria1.btGrabar.Enabled)
					{
						case false:this.SalirDesdeGuardar=true;
							this.Close();break;
						default:if (!this.Saved )
								{
									DialogResult dr=Mensajes.ShowQuestion(3000);
									if(dr == System.Windows.Forms.DialogResult.Yes )
									{
										this.SalirDesdeGuardar=true;
										this.Saved = true;
										this.Close();
									}
								}
							break;
					}
				}
				else
				{
					this.SalirDesdeGuardar=true;
					this.Close();
				}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion
		#region Buscar Poblaciones
		private void btBuscarPob_Click(object sender, System.EventArgs e)
		{
			try
			{
				GESTCRM.Formularios.Busquedas.frmMPoblaciones frmBPob = new GESTCRM.Formularios.Busquedas.frmMPoblaciones();
				frmBPob.ShowDialog(this);

				if(frmBPob._ValorAceptar != null)
				{
					
					int iIdPoblacion = frmBPob.ParamO_iIdPoblacion;
					this.dsClientes1.Clientes_COM[0].sPoblacion = frmBPob.ParamO_sPoblacion;
					this.dsClientes1.Clientes_COM[0].CodPostal = frmBPob.ParamO_sCodPostal;
					this.dsClientes1.Clientes_COM[0].sProvincia  = frmBPob.ParamO_sProvincia; 

					this.dsClientes1.Clientes_COM[0].iIdPoblacion = frmBPob.ParamO_iIdPoblacion;
					
				}

			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion
		#region Chequeo Obligatorios
		/// <summary>
		/// Verifica que los campos obligatorios han sido rellenados
		/// </summary>
		/// <returns>true si los campos han sido rellenados, false en caso contrario</returns>
		private bool ChequeoObligatorios() 
		{

			return (this.txtNombre.TextLength>0 && this.txtApe1.TextLength >0 && this.txtApe2.TextLength >0 
//				&& (this.txtNumCol1.TextLength >0 || this.txtNumCol2.TextLength >0 ||this.txtNumCol3.TextLength >0  )
				&& (this.dsClientes1.CentrosClientes_COM.DefaultView.Count >0    ) && (this.dsClientes1.EspecClientes_COM.DefaultView.Count     >0 ));
		}
		#endregion
		#region Habilitar Boton Grabar
		/// <summary>
		/// Habilita el boton de Grabar si se cumple con imputar los campos obligatorios
		/// 
		/// El llamado hay que ponerlo en los eventos click y change de los campos obligatorios
		/// </summary>
		private void HabilitaGrabar()
		{
			this.ucBotoneraSecundaria1.btGrabar.Enabled = this.ChequeoObligatorios();   
		}
		#endregion

		#region Habilitar Campos para Adicion/Edicion
		private void HabilitarCampos(bool valor)
		{
			this.txtNombre.Enabled = valor;
			this.txtApe1.Enabled = valor; 
			this.txtApe2.Enabled  = valor;
//			this.txtNumCol1.Enabled = valor;
//			this.txtNumCol2.Enabled = valor;
//			this.txtNumCol3.Enabled = valor;
			this.cmbTipoMedico.Enabled  = valor; 
		}
		#endregion

		#region Habilitar Campos si estan vacios
		private void HabilitarCamposSiVacios()
		{
			this.txtNombre.Enabled = ((txtNombre.Text.Trim()== "") || (txtNombre.Text.Trim()!= "" && !this.dsClientes1.Clientes[0].bEnviadoCEN));
			this.txtApe1.Enabled = ((txtApe1.Text.Trim()== "") || (txtApe1.Text.Trim()!= "" && !this.dsClientes1.Clientes[0].bEnviadoCEN) ); 
			this.txtApe2.Enabled  = ((txtApe2.Text.Trim()== "") || ((txtApe2.Text.Trim()!= "") && !this.dsClientes1.Clientes[0].bEnviadoCEN));
//			this.txtNumCol1.Enabled = (txtNumCol1.Text.Trim()== "")||(txtNumCol2.Text.Trim()== "")||(txtNumCol3.Text.Trim()== "")|| !this.dsClientes1.Clientes[0].bEnviadoCEN;
//			this.txtNumCol2.Enabled = (txtNumCol1.Text.Trim()== "")||(txtNumCol2.Text.Trim()== "")||(txtNumCol3.Text.Trim()== "")|| !this.dsClientes1.Clientes[0].bEnviadoCEN;
//			this.txtNumCol3.Enabled = (txtNumCol1.Text.Trim()== "")||(txtNumCol2.Text.Trim()== "")||(txtNumCol3.Text.Trim()== "")|| !this.dsClientes1.Clientes[0].bEnviadoCEN;
		}
		#endregion


		private void txtNombre_TextChanged(object sender, System.EventArgs e)
		{
			
			this.HabilitaGrabar();
		}
		#endregion

		#region CONTROL DE ELEMENTOS
		private void txtApe1_TextChanged(object sender, System.EventArgs e)
		{
			
			this.HabilitaGrabar();
		}

		private void txtApe2_TextChanged(object sender, System.EventArgs e)
		{
			
			this.HabilitaGrabar();
		}

		private void txtNumCol1_TextChanged(object sender, System.EventArgs e)
		{
			
			this.HabilitaGrabar();
		}

		private void txtNumCol2_TextChanged(object sender, System.EventArgs e)
		{
			
			this.HabilitaGrabar();
		}

		private void txtNumCol3_TextChanged(object sender, System.EventArgs e)
		{
			
			this.HabilitaGrabar();
		}

		private void txtObsMedico_Enter(object sender, System.EventArgs e)
		{
			if (!this.textDeleted)
			{
				this.txtObsMedico.Clear();
				this.textDeleted = true;
			} 
		}
		#endregion

		#region BOTONES Y CONTROLES

		#region Centros
		private void btClienteActualizar_Click(object sender, System.EventArgs e)
		{
			Actualizar_Centro();		
			this.HabilitaGrabar();
		}
		private void btClienteEliminar_Click(object sender, System.EventArgs e)
		{
			Eliminar_Centro();
			this.HabilitaGrabar();
		}
		#endregion
		#region Especialidades
		#region btActualizarEspec_Click
		private void btActualizarEspec_Click(object sender, System.EventArgs e)
		{
			Actualizar_Especialidad();
			this.HabilitaGrabar();
			this.ChequeoEspecialidades(); 
		}
		#endregion

		#region btEliminarEspec_Click
		private void btEliminarEspec_Click(object sender, System.EventArgs e)
		{
			Eliminar_Especialidad();
			this.HabilitaGrabar();
			this.ChequeoEspecialidades(); 
		}
		#endregion
		#endregion
		#region Productos
		private void btActualizarProd_Click(object sender, System.EventArgs e)
		{
			Actualizar_Producto();
		}

		private void btEliminarProd_Click(object sender, System.EventArgs e)
		{
			Eliminar_Producto();
		}
		#endregion
		#region AccionesMarketing
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

		#endregion
		#region Aficiones
		#region btActualizarAfic_Click
		private void btActualizarAfic_Click(object sender, System.EventArgs e)
		{
            //---- GSG (07/10/2014)
			//Actualizar_Aficion();
            Actualizar_Contacto();
		}
		#endregion

		#region btEliminarAfic_Click
		private void btEliminarAfic_Click(object sender, System.EventArgs e)
		{
            //---- GSG (07/10/2014)
			//Eliminar_Aficion();
            Eliminar_Contacto();
		}
		#endregion



        #endregion
		#endregion //aficiones - contactos

		private void cmbTipoMedico_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.dsClientes1.Clientes_COM.Rows.Count >0  && cmbTipoMedico.SelectedValue!=null )
			{
				this.dsClientes1.Clientes_COM[0].sTipoCliente_COM  = cmbTipoMedico.SelectedValue.ToString();    
			}
			this.HabilitaGrabar();
		}


		private void fNacTrue(object sender, System.EventArgs e)
		{
			this.dsClientes1.Clientes_COM[0].dFecNacimiento= this.dtFechaNac.Value; 
			this.fNacChanged= true; 
		}

		private void fMatTrue(object sender, System.EventArgs e)
		{

			this.dsClientes1.Clientes_COM[0].dFecAniversario= this.dtFechaAniv.Value; 
			this.fMatChanged=true; 
		}

		private void btBuscarCentro_Click(object sender, System.EventArgs e)
		{
			try
			{
				GESTCRM.Formularios.Busquedas.frmMCentros frmBCent = new GESTCRM.Formularios.Busquedas.frmMCentros();
				frmBCent.ParamIO_sDescripcion = "";
				frmBCent.ParamIO_sIdCentro = "";
				frmBCent.ParamI_BloquearRed = true;
				frmBCent.ParamI_iIdDelegado = GESTCRM.Clases.Configuracion.iIdDelegado;   
				frmBCent.ShowDialog(this);
				if (frmBCent.DialogResult==System.Windows.Forms.DialogResult.OK)
				{
					if (frmBCent.ParamIO_sIdRed == Clases.Configuracion.sIdRed)
					{
//						if(this.txtsIdCentro.Text!=frmBCent.ParamIO_sIdCentro)
//						{
							this.Var_iIdCentro = frmBCent.ParamO_iIdCentro;
							this.txtsIdCentro.Text=frmBCent.ParamIO_sIdCentro;
							this.txtsCentro.Text=frmBCent.ParamIO_sDescripcion;
							this.Param_NombreRed = frmBCent.ParamO_tRed;  
//						}
					}
					else
					{
						Mensajes.ShowInformation("No puede asignar un centro que no pertenece a su red comercial.");
						this.Var_iIdCentro = -1;
						this.txtsIdCentro.Text="";
						this.txtsCentro.Text="";
					}
					this.btClienteEliminar.Enabled = true;
					this.btClienteActualizar.Enabled = true;

				}
				frmBCent.Dispose();
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}

		}

		private void btBuscarProducto_Click(object sender, System.EventArgs e)
		{
			try
			{
				GESTCRM.Formularios.Busquedas.frmMProductos frmBProd = new GESTCRM.Formularios.Busquedas.frmMProductos();
				frmBProd.ParamIO_sDescripcion= "";
				frmBProd.ParamIO_sIdProducto = "";
				frmBProd.ShowDialog(this);
				if (frmBProd.DialogResult==System.Windows.Forms.DialogResult.OK)
				{
					if(this.txtProd.Text!=frmBProd.ParamIO_sIdProducto)
					{
						this.txtProd.Text  =frmBProd.ParamIO_sDescripcion;
						this.Var_sIdProd = frmBProd.ParamIO_sIdProducto; 
					}
				}
			}
			catch(Exception ex)
			{
				Mensajes.ShowError(ex.Message);
			}

		}

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
						this.dtpAccFEntrega.Value = DateTime.Now.Date;
					}
					this.ActivarAcciones(true);
				}
			}
			catch(Exception ex)
			{
				Mensajes.ShowError(ex.Message);
			}

		}



		#region COMUNES
		#region GetIDTemp
		/// <summary>
		/// Retorna el Identificador Temporal para Clientes
		/// </summary>
		/// <returns>String con el Identificador</returns>
		private string GetIDTemp()
		{
			string sIDTemp="";
			try
			{
				if (this.sqlConn.State == ConnectionState.Closed)   this.sqlConn.Open();  
				this.sqlCmdGetID.Parameters["@iIdDelegado"].Value = GESTCRM.Clases.Configuracion.iIdDelegado;
				this.sqlCmdGetID.Parameters["@theDate"].Value = DateTime.Now.ToString();
				sIDTemp = this.sqlCmdGetID.ExecuteScalar().ToString() ;  
			}
			catch (Exception ex)
			{
				sIDTemp="";
			}
			finally
			{
				this.sqlConn.Close(); 
			}
			return sIDTemp;

		}
		#endregion
		#endregion

		#region CENTROS
		#region Actualizar_Centro
		private void Actualizar_Centro()
		{
			try
			{
				if(Validar_Centro())
				{
					//					int fila = GESTCRM.Utiles.Buscar_fila_dtTabla(this.dtCentros,"sIdCentro",this.txtsIdCentro.Text.ToString());
					int filaGrid = GESTCRM.Utiles.Buscar_filaDataGrid (this,this.dgCentros  ,"sIdCentro",this.txtsIdCentro.Text.ToString(),"sIdRed",GESTCRM.Clases.Configuracion.sIdRed.ToString());
					int record = GESTCRM.Utiles.Buscar_fila_dtTabla(this.dsClientes1.CentrosClientes_COM  ,"sIdCentro",this.txtsIdCentro.Text.ToString(),"sIdRed",GESTCRM.Clases.Configuracion.sIdRed.ToString());

					if(record==-1)
					{
						DataRow dvfila= this.dsClientes1.CentrosClientes_COM.NewRow();
						//						DataRow dvfila= this.dtCentros.NewRow();
						dvfila["iIdCentro"]=this.Var_iIdCentro;
						dvfila["sIdCentro"]=this.txtsIdCentro.Text.ToString();
						dvfila["sDescripcion"]=this.txtsCentro.Text.ToString();
						dvfila["dFAR"]=DateTime.Now; 
						dvfila["dFBR"]=DBNull.Value ; 
						dvfila["iEstado"]=this.Param_iEstado ; 
						dvfila["sIdRed"]=GESTCRM.Clases.Configuracion.sIdRed.ToString(); 
						dvfila["nuevo"]=true;
						dvfila["tRed"]=Param_NombreRed;
						try
						{
							dvfila["sIdTipoRelacionCliCen"]=this.cmbRelacion.SelectedValue.ToString();
							dvfila["tRelacionTipoCliCen"]=this.cmbRelacion.GetItemText(this.cmbRelacion.SelectedItem).ToString();
						}
						catch
						{
							dvfila["sIdTipoRelacionCliCen"]=null;
							dvfila["tRelacionTipoCliCen"]=null;
						}
					
						this.dsClientes1.CentrosClientes_COM.Rows.Add(dvfila);
						//						this.dtCentros.Rows.Add(dvfila);
					
						filaGrid = this.dsClientes1.CentrosClientes_COM.DefaultView.Count-1;
						//						fila = this.dtCentros.Rows.Count-1;
					}
					else
					{
						try
						{
							this.dsClientes1.CentrosClientes_COM.Rows[record]["sIdTipoRelacionCliCen"]=this.cmbRelacion.SelectedValue.ToString();
							this.dsClientes1.CentrosClientes_COM.Rows[record]["tRelacionTipoCliCen"]=this.cmbRelacion.GetItemText(this.cmbRelacion.SelectedItem).ToString();
						}
						catch
						{
							this.dsClientes1.CentrosClientes_COM.Rows[record]["sIdTipoRelacionCliCen"]=null;
							this.dsClientes1.CentrosClientes_COM.Rows[record]["tRelacionTipoCliCen"]=null;
						}
						if (!this.dsClientes1.CentrosClientes_COM[record].nuevo)
						{
							this.dsClientes1.CentrosClientes_COM[record].iEstado =Convert.ToInt16(this.Param_iEstado) ;
							this.dsClientes1.CentrosClientes_COM[record].dFBR = Convert.ToDateTime(null)  ; 
						}
						this.dsClientes1.CentrosClientes_COM[record].dFAR = DateTime.Now;    
						//						try
						//						{
						//							this.dtCentros.Rows[fila]["sIdTipoRelacionCliCen"]=this.cmbRelacion.SelectedValue.ToString();
						//							this.dtCentros.Rows[fila]["tRelacionTipoCliCen"]=this.cmbRelacion.GetItemText(this.cmbRelacion.SelectedItem).ToString();
						//						}
						//						catch
						//						{
						//							this.dtCentros.Rows[fila]["sIdTipoRelacionCliCen"]=null;
						//							this.dtCentros.Rows[fila]["tRelacionTipoCliCen"]=null;
						//						}
					}
					this.dgCentros.CurrentRowIndex= filaGrid;
					GESTCRM.Utiles.Seleccionar_UnaFilaDataGrid(this,this.dgCentros,filaGrid);
					//					this.lblTotCentros.Text = this.dtCentros.Rows.Count.ToString();
					this.lblTotCentros.Text = this.dsClientes1.CentrosClientes_COM.DefaultView.Count.ToString();
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
				if(this.txtsIdCentro.Text.ToString().Length==0 || this.Var_iIdCentro==-1)
				{
					Mensajes.ShowInformation("Debe informar el campo Centro. ");
					return false;
				}
				if(this.cmbRelacion.SelectedIndex==-1)
				{
					Mensajes.ShowInformation("Debe informar el campo Relación. ");
					return false;
				}

				if(this.cmbRelacion .SelectedValue.ToString()=="0") //Propio
				{ 
					// Si el Médico a Asignar no tiene especialidades del Delegado o de su red, se Asigna como Ocasional
					int CountEspec=0;
					foreach (Formularios.DataSets.dsAltaMedicos.EspecClientes_COMRow   rwE in this.dsClientes1.EspecClientes_COM.Rows)
					{
						if (ExisteEspecialidad(rwE.sIdEspecialidad)) CountEspec++;   
					}
					if (CountEspec==0)
					{
						Mensajes.ShowInformation("No se Puede Agregar el Médico con tipo relación Propio\nAl no Poseer Especialidades asignadas a su Red comercial.\nSe añadirá como tipo relación Ocasional. " );
						this.cmbRelacion.SelectedValue="1";//Ocasional
					}
					else
					{
						DataRow[] rw = dsClientes1.CentrosClientes_COM.Select(" iEstado in (0,-3) and sIdTipoRelacionCliCen='"+this.cmbRelacion.SelectedValue.ToString()+"' and sIdRed='" + GESTCRM.Clases.Configuracion.sIdRed.ToString() + "'"  );
						if (rw.Length>0)
						{
							Mensajes.ShowInformation("El Medico ya está asignado a otro centro con tipo relación Propio.\nSe añadirá como tipo relación Ocasional. " );
							this.cmbRelacion.SelectedValue="1";//Ocasional
						}
					}
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
		#region Nuevo_Centro
		private void Nuevo_Centro()
		{
			try
			{
				this.txtsIdCentro.Focus();
				this.txtsIdCentro.Text = null;
				this.txtsCentro.Text = null;
				this.cmbRelacion.SelectedIndex =-1;
				this.Var_iIdCentro=-1;
				this.btClienteActualizar.Enabled = true;
				this.btClienteEliminar.Enabled = true; 
			}
			catch(Exception ex){ Mensajes.ShowError(ex.Message); }
		}
		#endregion
		#region dgCentros_CurrentCellChanged
		private void dgCentros_CurrentCellChanged(object sender, System.EventArgs e)
		{
			try
			{
				int fila = this.dgCentros.CurrentRowIndex;
				GESTCRM.Utiles.Seleccionar_UnaFilaDataGrid(this,this.dgCentros,fila);

				this.Var_iIdCentro = int.Parse(this.dgCentros[fila,0].ToString());
				this.txtsIdCentro.Text = this.dgCentros[fila,1].ToString();
				this.txtsCentro.Text = this.dgCentros[fila,2].ToString();

				this.btClienteEliminar.Enabled = this.dgCentros[this.dgCentros.CurrentRowIndex,8].ToString()==GESTCRM.Clases.Configuracion.sIdRed;
				this.btClienteActualizar.Enabled = this.dgCentros[this.dgCentros.CurrentRowIndex,8].ToString()==GESTCRM.Clases.Configuracion.sIdRed;
			
				
				try{this.cmbRelacion.SelectedIndex=-1;this.cmbRelacion.SelectedValue = this.dgCentros[fila,3].ToString();}
				catch{this.cmbRelacion.SelectedIndex =-1;}
				//				try{this.cbCentRelacion.SelectedValue = this.dgCentros[fila,3].ToString();}
				//				catch{this.cbCentRelacion.SelectedIndex =-1;}
			}
			catch(Exception ex)
			{
				Mensajes.ShowError(ex.Message);
			}
		}
		#endregion
		#region Eliminar_Centro
		private void Eliminar_Centro()
		{
			try
			{
				if(this.dgCentros.CurrentRowIndex>-1 && this.btClienteEliminar.Enabled  )
				{
					//					int fila = GESTCRM.Utiles.Buscar_fila_dtTabla(this.dtCentros,"sIdCentro",this.dgCentros[this.dgCentros.CurrentRowIndex,1].ToString());
					int record = GESTCRM.Utiles.Buscar_fila_dtTabla(this.dsClientes1.CentrosClientes_COM ,"sIdCentro",this.dgCentros[this.dgCentros.CurrentRowIndex,1].ToString(),"sIdRed",GESTCRM.Clases.Configuracion.sIdRed.ToString());
					int filaGrid = GESTCRM.Utiles.Buscar_filaDataGrid (this,this.dgCentros ,"sIdCentro",this.dgCentros[this.dgCentros.CurrentRowIndex,1].ToString(),"sIdRed",GESTCRM.Clases.Configuracion.sIdRed.ToString());
					if(record > -1)
					{
						int SelFila = filaGrid;
						if(filaGrid>0) SelFila=filaGrid-1;
						//						if(this.dtCentros.Rows.Count-1==0) SelFila = -1;
						if(this.dsClientes1.CentrosClientes_COM.Rows.Count-1==0) SelFila = -1;
						this.dgCentros.CurrentRowIndex=SelFila;
						GESTCRM.Utiles.Seleccionar_UnaFilaDataGrid(this,this.dgCentros,SelFila);

						//						this.dtCentros.Rows.RemoveAt(fila);
						if (!this.dsClientes1.CentrosClientes_COM[record].nuevo)
						{
							this.dsClientes1.CentrosClientes_COM[record].iEstado = -1;
							this.dsClientes1.CentrosClientes_COM[record].dFBR =DateTime.Now;  
						}
						else
						{
							this.dsClientes1.CentrosClientes_COM.Rows.RemoveAt(record);    
						}
						//						this.lblTotCentros.Text = this.dtCentros.Rows.Count.ToString();
						this.lblTotCentros.Text = this.dsClientes1.CentrosClientes_COM.DefaultView.Count.ToString();
						Nuevo_Centro();
					}
				}
			}
			catch(Exception ex) { Mensajes.ShowError(ex.Message); }
		}
		#endregion
		#endregion

		#region MENU CONTEXTUAL
		#region menuEliminar_Click
		private void menuEliminar_Click(object sender, System.EventArgs e)
		{
			try
			{
				string Objeto = this.contextMenu1.SourceControl.Name.ToString();
				if(Objeto.Length==0) Objeto = this.contextMenu1.SourceControl.Parent.Name.ToString();
				switch(Objeto)
				{
					case "dgEspecialidades":	Eliminar_Especialidad();break;
					case "dgProductos":			Eliminar_Producto();break;
					case "dgCentros":			Eliminar_Centro();break;
					case "dgAccionesMark":		Eliminar_Accion();break;
					//---- GSG (07/10/2014)
                    //case "dgAficiones":		Eliminar_Aficion();break;
                    case "dgContactos":         Eliminar_Contacto(); break;
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
					case "dgEspecialidades":	Nueva_Especialidad();break;
					case "dgProductos":			Nuevo_Producto();break;
					case "dgCentros":			Nuevo_Centro();break;
					case "dgAccionesMark":		Nueva_Accion();break;
                        //---- GSG (07/10/2014)
					//case "dgAficion":			Nueva_Aficion();break;
                    case "dgContactos":         Nuevo_Contacto(); break;
					default: break;
				}
			}
			catch(Exception ex)
			{
				Mensajes.ShowError(ex.Message);
			}
		}
		#endregion
		#endregion

		#region ESPECIALIDADES
		#region dgEspecialidades_CurrentCellChanged
		private void dgEspecialidades_CurrentCellChanged(object sender, System.EventArgs e)
		{
			try
			{
				int fila = this.dgEspecialidades.CurrentRowIndex;

				if(this.dgEspecialidades[fila,1].ToString().Length==0) this.dgEspecialidades[fila,1]=" ";

				GESTCRM.Utiles.Seleccionar_UnaFilaDataGrid(this,this.dgEspecialidades,fila);

				try{this.cbEspecialidades.SelectedValue = this.dgEspecialidades[fila,0].ToString();}
				catch{this.cbEspecialidades.SelectedIndex=-1;}

				btEliminarEspec.Enabled = ExisteEspecialidad(dgEspecialidades[fila,0].ToString());

			}
			catch(Exception ex)
			{
				Mensajes.ShowError(ex.Message);
			}
		}
		#endregion

		#region Nueva_Especialidad
		private void Nueva_Especialidad()
		{
			try
			{
				this.cbEspecialidades.Focus();
				this.cbEspecialidades.SelectedIndex=-1;
				this.cbEspecialidades.SelectedIndex=-1;
			}
			catch(Exception ex)
			{
				Mensajes.ShowError(ex.Message);
			}
		}
		#endregion

		#region Eliminar_Especialidad
		private void Eliminar_Especialidad()
		{
			try
			{
				if(this.dgEspecialidades.CurrentRowIndex>-1)
				{
					if (ExisteEspecialidad(dgEspecialidades[dgEspecialidades.CurrentRowIndex,0].ToString()))
					{
						int record = GESTCRM.Utiles.Buscar_fila_dtTabla(this.dsClientes1.EspecClientes_COM,"sIdEspecialidad",this.dgEspecialidades[this.dgEspecialidades.CurrentRowIndex,0].ToString());
						int filaGrid = GESTCRM.Utiles.Buscar_filaDataGrid (this,this.dgEspecialidades ,"sIdEspecialidad",this.dgEspecialidades[this.dgEspecialidades.CurrentRowIndex,0].ToString());
					
						if(filaGrid>-1)
						{
							//						CurrencyManager cm = (CurrencyManager)this.BindingContext[this.dgEspecialidades.DataSource,this.dgEspecialidades.DataMember];
							//						DataView dv = (DataView)cm.List;
							int SelFila = filaGrid;
							if(filaGrid>0) SelFila=filaGrid-1;
							//						if(dv.Count-1==0) SelFila = -1;
							if (this.dsClientes1.EspecClientes_COM.DefaultView.Count -1 ==0) SelFila = -1;
							this.dgEspecialidades.CurrentRowIndex=SelFila;
							GESTCRM.Utiles.Seleccionar_UnaFilaDataGrid(this,this.dgEspecialidades,SelFila);
						
							//						dv.AllowDelete=true;
							//						dv.Delete(fila);
							//						dv.AllowDelete=false;
//							if (ExisteEspecialidad(dgEspecialidades[filaGrid,0].ToString()))
//							{
								if (!this.dsClientes1.EspecClientes_COM[record].nuevo)
								{
									this.dsClientes1.EspecClientes_COM[record].dFUM = DateTime.Now;
									this.dsClientes1.EspecClientes_COM[record].iEstado = -1;
									this.dsClientes1.EspecClientes_COM[record].bEnviadoCEN =false;
								}
								else
								{
									this.dsClientes1.EspecClientes_COM.Rows.RemoveAt(record);    
								}
//							}
//							else
//								Mensajes.ShowExclamation("No se pueden Eliminar Especialidades No Asociadas a su Red Comercial"); 

							//						this.lblTotEspec.Text = dv.Count.ToString();
							this.lblTotEspec.Text  = this.dsClientes1.EspecClientes_COM.DefaultView.Count.ToString();     
							Nueva_Especialidad();
						}
					}
					else
						Mensajes.ShowExclamation("No se pueden Eliminar Especialidades No Asociadas a su Red Comercial"); 
				}
			}
			catch(Exception ex)
			{
				Mensajes.ShowError(ex.Message);
			}
		}
		#endregion

		#region Actualizar_Especialidad
		private void Actualizar_Especialidad()
		{
			try
			{
				if(Validar_Especialidad())
				{
					int record = GESTCRM.Utiles.Buscar_fila_dtTabla (this.dsClientes1.EspecClientes_COM  ,"sIdEspecialidad",this.cbEspecialidades.SelectedValue.ToString());
					int filaGrid = GESTCRM.Utiles.Buscar_filaDataGrid(this,this.dgEspecialidades,"sIdEspecialidad",this.cbEspecialidades.SelectedValue.ToString());

					//					CurrencyManager cm = (CurrencyManager)this.BindingContext[this.dgEspecialidades.DataSource,this.dgEspecialidades.DataMember];
					//					DataView dv = (DataView)cm.List;

					if(record==-1)
					{
						//						DataRowView dvfila= dv.AddNew();
						DataRow dvfila = this.dsClientes1.EspecClientes_COM.NewRow(); 
						dvfila["sIdEspecialidad"]=this.cbEspecialidades.SelectedValue;
						dvfila["tEspecialidad"]=this.cbEspecialidades.GetItemText(this.cbEspecialidades.SelectedItem).ToString();
						dvfila["dFUM"]=DateTime.Now;
						dvfila["iEstado"]=this.Param_iEstado  ;
						dvfila["bEnviadoCen"]=false;
						dvfila["nuevo"]=true;
						//						fila = dv.Count-1;
						filaGrid = this.dsClientes1.EspecClientes_COM.DefaultView.Count;  
  
						this.dsClientes1.EspecClientes_COM.Rows.Add(dvfila);    
					}
					else
					{
						if (!this.dsClientes1.EspecClientes_COM[record].nuevo   )
						{
							this.dsClientes1.EspecClientes_COM[record].dFUM = DateTime.Now;
							this.dsClientes1.EspecClientes_COM[record].iEstado = Convert.ToInt16( this.Param_iEstado);
							this.dsClientes1.EspecClientes_COM[record].bEnviadoCEN = false;  
						}
					}
					this.dgEspecialidades.CurrentRowIndex = filaGrid;
					GESTCRM.Utiles.Seleccionar_UnaFilaDataGrid(this,this.dgEspecialidades,filaGrid);
					//					this.lblTotEspec.Text = dv.Count.ToString();
					this.lblTotEspec.Text = this.dsClientes1.EspecClientes_COM.DefaultView.Count.ToString();     
					Nueva_Especialidad();
				}
			}
			catch(Exception ex)
			{
				Mensajes.ShowError(ex.Message);
			}
		}
		#endregion

		#region Validar_Especialidad
		private bool Validar_Especialidad()
		{
			bool resultado = true;
			try
			{
				if(this.cbEspecialidades.SelectedIndex==-1)
				{
					Mensajes.ShowInformation("Debe informar el campo Especialidad. ");
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
		#endregion

		#region frmMClientesCOM_Closing
		private void frmAltaMedicos_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			try
			{
				//if(this.Param_TipoAcceso!="C" && this.ucBotoneraSecundaria1.btGrabar.Enabled && !Saved  )
				if(this.Param_TipoAcceso!="C" && !Saved  )
				{

					DialogResult dr1=Mensajes.ShowQuestion(3000);
					if(dr1 == System.Windows.Forms.DialogResult.No)
					{
						//						if(Guardar_Cliente())
						//						{
						//							Mensajes.ShowInformation(3004);
						//						}
						//						else
						//						{
						e.Cancel=true;
						//						}
					}

				}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region PRODUCTOS

		#region dgProductos_CurrentCellChanged
		private void dgProductos_CurrentCellChanged(object sender, System.EventArgs e)
		{
			try
			{
				int fila = this.dgProductos.CurrentRowIndex;
				GESTCRM.Utiles.Seleccionar_UnaFilaDataGrid(this,this.dgProductos,fila);

				try{this.udPrioridad.Value = int.Parse(this.dgProductos[fila,2].ToString());}
				catch{this.udPrioridad.Value=0;}
				this.Var_sIdProd = this.dgProductos[fila,0].ToString();
				this.txtProd.Text = this.dgProductos[fila,1].ToString();
			}
			catch(Exception ex)
			{
				Mensajes.ShowError(ex.Message);
			}
		}
		#endregion

		#region Nuevo_Producto
		private void Nuevo_Producto()
		{
			try
			{
				this.udPrioridad.Focus();
				this.udPrioridad.Value=this.udPrioridad.Minimum;
				this.Var_sIdProd  = "";
				this.txtProd.Text="";
			}
			catch(Exception ex)
			{
				Mensajes.ShowError(ex.Message);
			}
		}
		#endregion

		#region Eliminar_Producto
		private void Eliminar_Producto()
		{
			try
			{
				if(this.dgProductos.CurrentRowIndex>-1)
				{
					int record = GESTCRM.Utiles.Buscar_fila_dtTabla(this.dsClientes1.ProdClientes_COM,"sIdProducto",this.dgProductos[this.dgProductos.CurrentRowIndex,1].ToString());
					int filaGrid = GESTCRM.Utiles.Buscar_filaDataGrid (this,this.dgProductos ,"sIdProducto",this.dgProductos[this.dgProductos.CurrentRowIndex,1].ToString());
					if(filaGrid > -1)
					{
						//						CurrencyManager cm = (CurrencyManager)this.BindingContext[this.dgProductos.DataSource,this.dgProductos.DataMember];
						//						DataView dv = (DataView)cm.List;

						int SelFila = filaGrid;
						if(filaGrid>0) SelFila=filaGrid-1;
						//						if(dv.Count-1==0) SelFila = -1;
						if(this.dsClientes1.ProdClientes_COM.Rows.Count-1==0) SelFila = -1;
						this.dgProductos.CurrentRowIndex=SelFila;
						GESTCRM.Utiles.Seleccionar_UnaFilaDataGrid(this,this.dgProductos,SelFila);
						
						//						dv.AllowDelete=true;
						//						dv.Delete(fila);
						//						dv.AllowDelete=false;
						if (!this.dsClientes1.ProdClientes_COM[record].nuevo)
						{
							this.dsClientes1.ProdClientes_COM[record].iEstado =-1;
							this.dsClientes1.ProdClientes_COM[record].dFUM = DateTime.Now;
							this.dsClientes1.ProdClientes_COM[record].bEnviadoCen =false;
						}
						else
						{
							this.dsClientes1.ProdClientes_COM.Rows.RemoveAt(record); 
						}
						if (this.Param_iEstado ==0) Activar_AccionesMark();
						//						this.lblTotProd.Text = dv.Count.ToString();
						this.lblTotProd.Text = this.dsClientes1.ProdClientes_COM.DefaultView.Count.ToString();     
						Nuevo_Producto();
					}
				}
			}
			catch(Exception ex)
			{
				Mensajes.ShowError(ex.Message);
			}
		}
		#endregion

		#region Actualizar_Producto
		private void Actualizar_Producto()
		{
			try
			{
				if(Validar_Producto())
				{
					int filaGrid = GESTCRM.Utiles.Buscar_filaDataGrid(this,this.dgProductos,"sIdProducto",this.Var_sIdProd.ToString() );
					int record = GESTCRM.Utiles.Buscar_fila_dtTabla (this.dsClientes1.ProdClientes_COM ,"sIdProducto",this.Var_sIdProd.ToString() );

					//					CurrencyManager cm = (CurrencyManager)this.BindingContext[this.dgProductos.DataSource,this.dgProductos.DataMember];
					//					DataView dv = (DataView)cm.List;

					if(record==-1)
					{
						//						DataRowView dvfila= dv.AddNew();
						DataRow dvfila= this.dsClientes1.ProdClientes_COM.NewRow(); 
						dvfila["sIdProducto"]=this.Var_sIdProd.ToString();  
						dvfila["sDescripcion"]=this.txtProd.Text.ToString();
						dvfila["iPrioridad"]=Convert.ToInt32(this.udPrioridad .Value);
						dvfila["dFUM"]=DateTime.Now;
						dvfila["bEnviadoCen"]=0;
						dvfila["iEstado"]=this.Param_iEstado;
						dvfila["nuevo"]=true;
						//						fila = dv.Count-1;
						this.dsClientes1.ProdClientes_COM.Rows.Add(dvfila);    
						filaGrid = this.dsClientes1.ProdClientes_COM.DefaultView.Count -1;   
					}
					else
					{
						//						dv.AllowEdit=true;
						//						dv[fila]["iPrioridad"]=Convert.ToInt32(this.udPrioridad.Value);
						//						dv.AllowEdit=false;
						this.dsClientes1.ProdClientes_COM[record]["iPrioridad"]=Convert.ToInt32(this.udPrioridad .Value);
						this.dsClientes1.ProdClientes_COM[record]["dFUM"]=DateTime.Now;
						this.dsClientes1.ProdClientes_COM[record]["bEnviadoCen"]=this.Param_iEstado ;
						this.dsClientes1.ProdClientes_COM[record]["iEstado"]=this.Param_iEstado;
					}
					this.dgProductos.CurrentRowIndex= filaGrid;
					GESTCRM.Utiles.Seleccionar_UnaFilaDataGrid(this,this.dgProductos,filaGrid);
					if (this.Param_iEstado ==0) Activar_AccionesMark();
					//					this.lblTotProd.Text = dv.Count.ToString();
					this.lblTotProd.Text = this.dsClientes1.ProdClientes_COM.DefaultView.Count.ToString();   
					Nuevo_Producto();
				}
			}
			catch(Exception ex)
			{
				Mensajes.ShowError(ex.Message);
			}
		}
		#endregion

		#region Validar_Producto
		private bool Validar_Producto()
		{
			bool resultado = true;
			try
			{
				if((this.txtProd.Text.ToString().Length==0))
				{
					Mensajes.ShowInformation("Debe informar el campo Producto. ");
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


		#region Activar_AccionesMark
		private void Activar_AccionesMark()
		{
			try
			{
				//				CurrencyManager cm = (CurrencyManager)this.BindingContext[this.dgProductos.DataSource,this.dgProductos.DataMember];
				//				DataView dv = (DataView)cm.List;
				//
				//				if(dv.Count==0) //A un Cliente sin productos no se le pueden asignar acciones de marketing
				if(this.dsClientes1.ProdClientes_COM.DefaultView.Count ==0) //A un Cliente sin productos no se le pueden asignar acciones de marketing
				{
					//					this.dtAccionesMark.Rows.Clear();
					//					this.lblTotAcciones.Text = this.dtAccionesMark.Rows.Count.ToString();
					//					Nueva_Accion();
					this.dgAccionesMark.Enabled = false;

					this.ActivarAcciones(false); 
					this.ActivarBotonesAcciones(false);
				}
				else
				{
					this.dgAccionesMark.Enabled = true;

					this.ActivarAcciones(true); 
					this.ActivarBotonesAcciones(true);
				}
			}
			catch(Exception ex) { Mensajes.ShowError(ex.Message); }
		}
		#endregion

		#endregion

		#region ACCIONES DE MARKETING
		#region dgAccionesMark_CurrentCellChanged
		private void dgAccionesMark_CurrentCellChanged(object sender, System.EventArgs e)
		{
			try
			{
				int fila = this.dgAccionesMark.CurrentRowIndex;
				GESTCRM.Utiles.Seleccionar_UnaFilaDataGrid(this,this.dgAccionesMark,fila);

				this.Var_iIdAccion = int.Parse(this.dgAccionesMark[fila,0].ToString());
				this.txtAccsIdAccion.Text = this.dgAccionesMark[fila,1].ToString();
				this.dtpAccFEntrega.Value = DateTime.Parse(this.dgAccionesMark[fila,3].ToString());
				this.nupAccCantidad.Value = int.Parse(this.dgAccionesMark[fila,2].ToString());
				this.txtAccObservEntrega.Text = this.dgAccionesMark[fila,4].ToString();

//				this.ActivarAcciones(!(bool)(this.dgAccionesMark[fila,8]));
				this.ActivarAcciones(true);
			}
			catch(Exception ex) {Mensajes.ShowError(ex.Message);}
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
					if(this.Var_iIdAccion==-1) Mensajes.ShowInformation("Este código de Acción no existe.");
					else this.txtAccsIdAccion.Text=frmBAcc.ParamIO_sIdAccion;
				}
			}
			catch(Exception ex)
			{
				Mensajes.ShowError(ex.Message);
			}
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
			GESTCRM.Formularios.DataSets.dsAltaMedicos.AccionesMarkClientesRow rwAcc = null;     
			int record=-1;
			int filaGrid=-1;
			try
			{
				if(this.dgAccionesMark.CurrentRowIndex>-1)
				{
					//					int fila = GESTCRM.Utiles.Buscar_fila_dtTabla(this.dtAccionesMark,"sIdAccion",this.dgAccionesMark[this.dgAccionesMark.CurrentRowIndex,1].ToString());
//					int record = GESTCRM.Utiles.Buscar_fila_dtTabla(this.dsClientes1.AccionesMarkClientes  ,"sIdAccion",this.dgAccionesMark[this.dgAccionesMark.CurrentRowIndex,1].ToString());
//					int filaGrid = GESTCRM.Utiles.Buscar_filaDataGrid(this,this.dgAccionesMark,"sIdAccion",this.dgAccionesMark[this.dgAccionesMark.CurrentRowIndex,1].ToString());
					result = this.dsClientes1.AccionesMarkClientes.Select("sIdAccion='"+this.txtAccsIdAccion.Text.ToString()+"' and '"+this.dtpAccFEntrega.Value.Date.ToString()+"' = dFechaEntrega AND bEnviadoCEN=0");   
					if (result.Length >0) 
					{
						rwAcc = (GESTCRM.Formularios.DataSets.dsAltaMedicos.AccionesMarkClientesRow)result.GetValue(0); 
						record = GESTCRM.Utiles.Buscar_fila_dtTabla(this.dsClientes1.AccionesMarkClientes  ,"sIdAccion",this.txtAccsIdAccion.Text.ToString(),"dFechaEntrega",rwAcc.dFechaEntrega.ToString()    );
						filaGrid = GESTCRM.Utiles.Buscar_filaDataGrid(this,this.dgAccionesMark,"sIdAccion",this.txtAccsIdAccion.Text.ToString(),"dFechaEntrega",rwAcc.dFechaEntrega.ToString()    );
					}
					if(filaGrid > -1)
					{
						int SelFila = filaGrid;
						if(filaGrid>0) SelFila=filaGrid-1;
						//						if(this.dtAccionesMark.Rows.Count-1==0) SelFila = -1;
						if(this.dsClientes1.AccionesMarkClientes.Rows.Count-1==0) SelFila = -1;
						this.dgAccionesMark.CurrentRowIndex=SelFila;
						GESTCRM.Utiles.Seleccionar_UnaFilaDataGrid(this,this.dgAccionesMark,SelFila);
						
						if (!this.dsClientes1.AccionesMarkClientes[record].nuevo )
						{
							this.dsClientes1.AccionesMarkClientes[record].dFUM=DateTime.Now;
							this.dsClientes1.AccionesMarkClientes[record].iEstado=-1;
							this.dsClientes1.AccionesMarkClientes[record].bEnviadoCen = false; 
						}
						else
						{
							this.dsClientes1.AccionesMarkClientes.Rows.RemoveAt(record);  
						}
						//						this.dtAccionesMark.Rows.RemoveAt(fila);
						//						this.lblTotAcciones.Text = this.dtAccionesMark.Rows.Count.ToString();
						this.lblTotAcciones.Text = this.dsClientes1.AccionesMarkClientes.DefaultView.Count.ToString();   
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
			GESTCRM.Formularios.DataSets.dsAltaMedicos.AccionesMarkClientesRow rwAcc = null;     
			int record=-1;
			int filaGrid=-1;
			try
			{
				if(Validar_Accion())
				{
//					int fila = GESTCRM.Utiles.Buscar_fila_dtTabla(this.dtAccionesMark,"sIdAccion",this.txtAccsIdAccion.Text.ToString());
//					int record = GESTCRM.Utiles.Buscar_fila_dtTabla(this.dsClientes1.AccionesMarkClientes  ,"sIdAccion",this.txtAccsIdAccion.Text.ToString());
//					int filaGrid = GESTCRM.Utiles.Buscar_filaDataGrid(this,this.dgAccionesMark,"sIdAccion",this.txtAccsIdAccion.Text.ToString());  

                    //result = this.dsClientes1.AccionesMarkClientes.Select("sIdAccion='"+this.txtAccsIdAccion.Text.ToString()+"' and '"+this.dtpAccFEntrega.Value.Date.ToString()+"' = dFechaEntrega");   
                    
                    //RH
                    result = this.dsClientes1.AccionesMarkClientes.Select(String.Format("sIdAccion='{0}' AND tFechaEntrega='{1:dd/MM/yyyy}'", this.txtAccsIdAccion.Text, this.dtpAccFEntrega.Value));   

					if (result.Length > 0) 
					{
						rwAcc = (GESTCRM.Formularios.DataSets.dsAltaMedicos.AccionesMarkClientesRow)result.GetValue(0); 
						record = GESTCRM.Utiles.Buscar_fila_dtTabla(this.dsClientes1.AccionesMarkClientes  ,"sIdAccion",this.txtAccsIdAccion.Text,"dFechaEntrega",rwAcc.dFechaEntrega.ToString()    );
						filaGrid = GESTCRM.Utiles.Buscar_filaDataGrid(this,this.dgAccionesMark,"sIdAccion",this.txtAccsIdAccion.Text,"dFechaEntrega",rwAcc.dFechaEntrega.ToString()    );
					}

//					if(record==-1)
					//if((record==-1) || ( record!=-1 && (DateTime.Parse( this.dsClientes1.AccionesMarkClientes.Rows[record]["dFechaEntrega"].ToString()).ToString("dd/MM/yyyy")!=this.dtpAccFEntrega.Value.Date.ToString("dd/MM/yyyy")) && bool.Parse( dsClientes1.AccionesMarkClientes.Rows[record]["bEnviadoCen"].ToString() )     ))
                    //RH
                    if ((record == -1) ||
                        (record != -1 && (DateTime.Parse(this.dsClientes1.AccionesMarkClientes.Rows[record]["dFechaEntrega"].ToString()).Date != this.dtpAccFEntrega.Value) && bool.Parse(dsClientes1.AccionesMarkClientes.Rows[record]["bEnviadoCen"].ToString())))
					{
						//						DataRow dvfila= this.dtAccionesMark.NewRow();
						DataRow dvfila= this.dsClientes1.AccionesMarkClientes.NewRow();   
						dvfila["iIdAccion"]=this.Var_iIdAccion;
						dvfila["sIdAccion"]=this.txtAccsIdAccion.Text.ToString();

                        //RH
                        dvfila["dFechaEntrega"] = this.dtpAccFEntrega.Value; // this.dtpAccFEntrega.Value.Date.ToString("dd/MM/yyyy");
                        dvfila["tFechaEntrega"] = this.dtpAccFEntrega.Value.ToString("dd/MM/yyyy");
						
                        dvfila["fCantidad"]=Convert.ToInt32(this.nupAccCantidad.Value);
						dvfila["tObservEntrega"]=this.txtAccObservEntrega.Text;
						dvfila["sCCoste"]= System.Data.SqlTypes.SqlString.Null;
						dvfila["dFUM"]=DateTime.Now;
						dvfila["iEstado"]=0;
						dvfila["bEnviadoCen"]=false;
						dvfila["nuevo"]=true;
					
						//						this.dtAccionesMark.Rows.Add(dvfila);
						this.dsClientes1.AccionesMarkClientes.Rows.Add(dvfila);
					
						//						fila = this.dtAccionesMark.Rows.Count-1;
						filaGrid = this.dsClientes1.AccionesMarkClientes.DefaultView.Count-1;
					}
					else
					{
//						//solo será posible modificar si no ha sido enviada
//						if (!this.dsClientes1.AccionesMarkClientes[record].bEnviadoCen )
//						{
                        this.dsClientes1.AccionesMarkClientes[record]["dFechaEntrega"] = this.dtpAccFEntrega.Value; // this.dtpAccFEntrega.Value.Date.ToString("dd/MM/yyyy");
						if (bool.Parse( dsClientes1.AccionesMarkClientes.Rows[filaGrid]["bEnviadoCen"].ToString() ) && filaGrid != record)
						{
							this.dsClientes1.AccionesMarkClientes.Rows[filaGrid]["fCantidad"]=int.Parse(this.dsClientes1.AccionesMarkClientes.Rows[filaGrid]["fCantidad"].ToString() ) + Convert.ToInt32(this.nupAccCantidad.Value);
						}
						else
						{
							this.dsClientes1.AccionesMarkClientes.Rows[filaGrid]["fCantidad"]=Convert.ToInt32(this.nupAccCantidad.Value);
						}
						//							this.dsClientes1.AccionesMarkClientes[record]["fCantidad"]=Convert.ToInt32(this.nupAccCantidad.Value);
							this.dsClientes1.AccionesMarkClientes[record]["tObservEntrega"]=this.txtAccObservEntrega.Text;
							this.dsClientes1.AccionesMarkClientes[record]["dFUM"]=DateTime.Now;
							this.dsClientes1.AccionesMarkClientes[record]["bEnviadoCen"]=false;
							this.dsClientes1.AccionesMarkClientes[record]["iEstado"]=this.Param_iEstado;   
//						}
//						else
//						{
//							Mensajes.ShowExclamation("Las acciones de marketing una vez anviadas\na Central no pueden ser modificadas");  
//						}
					}
					this.dgAccionesMark.CurrentRowIndex= filaGrid;
					GESTCRM.Utiles.Seleccionar_UnaFilaDataGrid(this,this.dgAccionesMark,filaGrid);
					//					this.lblTotAcciones.Text = this.dtAccionesMark.Rows.Count.ToString();
					this.lblTotAcciones.Text = this.dsClientes1.AccionesMarkClientes.DefaultView.Count.ToString();    

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
					Mensajes.ShowInformation("Debe informar el campo Acción. ");
					return false;
				}
				if(this.dtpAccFEntrega.Value.ToString().Length==0)
				{
					Mensajes.ShowInformation("Debe informar el campo Fecha Entrega. ");
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


		#endregion

		#region AFICIONES
		#region dgAficiones_CurrentCellChanged
		private void dgAficiones_CurrentCellChanged(object sender, System.EventArgs e)
		{
			try
			{
				int fila = this.dgAficiones.CurrentRowIndex;

				if(this.dgAficiones[fila,0].ToString().Length==0) this.dgAficiones[fila,0]=" ";

				GESTCRM.Utiles.Seleccionar_UnaFilaDataGrid(this,this.dgAficiones,fila);

				try{this.cmbAficiones.SelectedValue = this.dgAficiones[fila,1].ToString();}
				catch{this.cmbAficiones.SelectedIndex=-1;}
			}
			catch(Exception ex)
			{
				Mensajes.ShowError(ex.Message);
			}
		}
		#endregion

		
		#region Nueva_Aficion
		private void Nueva_Aficion()
		{
			try
			{
				this.cmbAficiones .Focus();
				this.cmbAficiones.SelectedIndex=-1;
				this.cmbAficiones.SelectedIndex=-1;
			}
			catch(Exception ex)
			{
				Mensajes.ShowError(ex.Message);
			}
		}
		#endregion

		#region Eliminar_Aficion
		private void Eliminar_Aficion()
		{
			try
			{
				if(this.dgAficiones.CurrentRowIndex>-1)
				{
					int filaGrid = GESTCRM.Utiles.Buscar_filaDataGrid(this,this.dgAficiones,"sIdAficion",this.dgAficiones[this.dgAficiones.CurrentRowIndex,1].ToString());
					int record = GESTCRM.Utiles.Buscar_fila_dtTabla (this.dsClientes1.AficClientes_COM ,"sIdAficion",this.dgAficiones[this.dgAficiones.CurrentRowIndex,1].ToString());
					
					if(filaGrid>-1)
					{
						//						CurrencyManager cm = (CurrencyManager)this.BindingContext[this.dgAficiones.DataSource,this.dgAficiones.DataMember];
						//						DataView dv = (DataView)cm.List;

						int SelFila = filaGrid;
						if(filaGrid>0) SelFila=filaGrid-1;
						//						if(dv.Count-1==0) SelFila = -1;
						if(this.dsClientes1.AficClientes_COM.DefaultView.Count-1==0) SelFila = -1;
						this.dgAficiones.CurrentRowIndex=SelFila;
						GESTCRM.Utiles.Seleccionar_UnaFilaDataGrid(this,this.dgAficiones,SelFila);
						if (!this.dsClientes1.AficClientes_COM[record].nuevo)
						{
							this.dsClientes1.AficClientes_COM[record].dFUM = DateTime.Now ;
							this.dsClientes1.AficClientes_COM[record].iEstado =-1;
							this.dsClientes1.AficClientes_COM[record].bEnviadoCEN =false;
						}
						else
						{
							this.dsClientes1.AficClientes_COM.Rows.RemoveAt(record); 
						}
						
						//						dv.AllowDelete=true;
						//						dv.Delete(fila);
						//						dv.AllowDelete=false;
						//						this.lblTotAficiones.Text = dv.Count.ToString();
						this.lblTotAficiones.Text = this.dsClientes1.AficClientes_COM.DefaultView.Count.ToString();    
						Nueva_Aficion();
					}
				}
			}
			catch(Exception ex)
			{
				Mensajes.ShowError(ex.Message);
			}
		}
		#endregion

		#region Actualizar_Aficion
		private void Actualizar_Aficion()
		{
			try
			{
				if(Validar_Aficion())
				{
					int filaGrid = GESTCRM.Utiles.Buscar_filaDataGrid(this,this.dgAficiones,"sIdAficion",this.cmbAficiones.SelectedValue.ToString());
					int record = GESTCRM.Utiles.Buscar_fila_dtTabla (this.dsClientes1.AficClientes_COM ,"sIdAficion",this.cmbAficiones.SelectedValue.ToString());

					//					CurrencyManager cm = (CurrencyManager)this.BindingContext[this.dgAficiones.DataSource,this.dgAficiones.DataMember];
					//					DataView dv = (DataView)cm.List;

					if(record==-1)
					{
						//						DataRowView dvfila= dv.AddNew();
						DataRow dvfila = this.dsClientes1.AficClientes_COM.NewRow();   
						dvfila["sIdAficion"]=this.cmbAficiones.SelectedValue;
						dvfila["tAficion"]=this.cmbAficiones.GetItemText(this.cmbAficiones.SelectedItem).ToString();
						dvfila["dFUM"]=DateTime.Now;
						dvfila["bEnviadoCen"]=0;
						dvfila["iEstado"]=this.Param_iEstado;
						dvfila["nuevo"]=true;
						//						fila = dv.Count-1;
						this.dsClientes1.AficClientes_COM.Rows.Add(dvfila);
						filaGrid=this.dsClientes1.AficClientes_COM.DefaultView.Count -1;   
					}
					else
					{
						if (!this.dsClientes1.AficClientes_COM[record].nuevo )
						{
							this.dsClientes1.AficClientes_COM[record].dFUM =DateTime.Now;
							this.dsClientes1.AficClientes_COM[record].iEstado = Convert.ToInt16( this.Param_iEstado );
							this.dsClientes1.AficClientes_COM[record].bEnviadoCEN = false;  
						}
					}
					this.dgAficiones.CurrentRowIndex = filaGrid;
					GESTCRM.Utiles.Seleccionar_UnaFilaDataGrid(this,this.dgAficiones,filaGrid);
					//					this.lblTotAficiones.Text = dv.Count.ToString();
					this.lblTotAficiones.Text = this.dsClientes1.AficClientes_COM.DefaultView.Count.ToString();     
					Nueva_Aficion();
				}
			}
			catch(Exception ex)
			{
				Mensajes.ShowError(ex.Message);
			}
		}
		#endregion

		#region Validar_Aficion
		private bool Validar_Aficion()
		{
			bool resultado = true;
			try
			{
				if(this.cmbAficiones.SelectedIndex==-1)
				{
					Mensajes.ShowInformation("Debe informar el campo Afición. ");
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

		#endregion


        //---- GSG (07/10/2014)
        #region AREAS
        
        private void dgContactos_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                int fila = this.dgContactos.CurrentRowIndex;

                if (this.dgContactos[fila, 1].ToString().Length == 0) 
                    this.dgContactos[fila, 1] = " ";
                
                GESTCRM.Utiles.Seleccionar_UnaFilaDataGrid(this, this.dgContactos, fila);

                try { this.cbContCargo.SelectedValue = this.dgContactos[fila, 1].ToString(); }
                catch { this.cbContCargo.SelectedIndex = -1; }
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }

        private void Nuevo_Contacto()
        {
            try
            {
                this.cbContCargo.Focus(); 
                this.cbContCargo.SelectedIndex = -1;
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }

        private void Eliminar_Contacto()
        {
            try
            {
                if (this.dgContactos.CurrentRowIndex > -1)
                {
                    int record = GESTCRM.Utiles.Buscar_fila_dtTabla(this.dsClientes2.ListaAreas_porCliente_SAP, "sNombre", this.dgContactos[this.dgContactos.CurrentRowIndex, 2].ToString());
                    int fila = GESTCRM.Utiles.Buscar_filaDataGrid(this, this.dgContactos, "sNombre", this.dgContactos[this.dgContactos.CurrentRowIndex, 2].ToString());
                    if (fila > -1)
                    {
                        int SelFila = fila;
                        if (fila > 0) SelFila = fila - 1;

                        if (this.dsClientes2.ListaAreas_porCliente_SAP.DefaultView.Count - 1 == 0) SelFila = -1;
                        this.dgContactos.CurrentRowIndex = SelFila;
                        GESTCRM.Utiles.Seleccionar_UnaFilaDataGrid(this, this.dgContactos, SelFila);

                        if (int.Parse(dsClientes2.ListaAreas_porCliente_SAP[record]["iEstado"].ToString()) == -3)
                        {
                            dsClientes2.ListaAreas_porCliente_SAP.Rows.RemoveAt(record);   
                        }
                        else 
                        {
                            dsClientes2.ListaAreas_porCliente_SAP[record]["dFBR"] = DateTime.Now;
                            dsClientes2.ListaAreas_porCliente_SAP[record]["iEstado"] = -1;                           
                        }

                        this.lblTotAficiones.Text = this.dsClientes2.ListaAreas_porCliente_SAP.DefaultView.Count.ToString();
                        Nuevo_Contacto();
                    }
                }
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }

        private void Actualizar_Contacto()
        {
            try
            {
                if (Validar_Contacto())
                {
                    int fila = GESTCRM.Utiles.Buscar_filaDataGrid(this, this.dgContactos, "sNombre", this.cbContCargo.Text);
                    int record = GESTCRM.Utiles.Buscar_fila_dtTabla(this.dsClientes2.ListaAreas_porCliente_SAP, "sNombre", this.cbContCargo.Text);

                    if (record == -1)
                    {
                        DataRow dvfila = this.dsClientes2.ListaAreas_porCliente_SAP.NewRow();

                        dvfila["iIdCliente"] = this.Param_iIdCliente;
                        dvfila["iIdContacto"] = this.cbContCargo.SelectedValue.ToString();
                        dvfila["sNombre"] = this.cbContCargo.Text;
                        dvfila["sIdCargoContacto"] = "46";
                        dvfila["dFAR"] = DateTime.Now;
                        dvfila["dFBR"] = DBNull.Value;
                        dvfila["iEstado"] = this.Param_iEstado;

                        this.dsClientes2.ListaAreas_porCliente_SAP.Rows.Add(dvfila);
                        fila = this.dsClientes2.ListaAreas_porCliente_SAP.DefaultView.Count - 1;
                    }
                    else
                    {
                        dsClientes2.ListaAreas_porCliente_SAP.Rows[record]["sNombre"] = this.cbContCargo.Text;
                        dsClientes2.ListaAreas_porCliente_SAP.Rows[record]["iEstado"] = Convert.ToInt32(this.Param_iEstado);
                    }

                    this.dgContactos.CurrentRowIndex = fila;
                    GESTCRM.Utiles.Seleccionar_UnaFilaDataGrid(this, this.dgContactos, fila);

                    this.lblTotAficiones.Text = this.dsClientes2.ListaAreas_porCliente_SAP.DefaultView.Count.ToString();


                    Nuevo_Contacto();
                }
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }

        private bool Validar_Contacto()
        {
            bool resultado = true;
            try
            {

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
            catch (Exception e)
            {
                Mensajes.ShowError(e.Message);
                resultado = false;
            }
            return resultado;
        }

        #endregion


        #region Activar Acciones
        private void ActivarAcciones(bool Activar)
		{
			//this.dgAccionesMark.Enabled = Activar;
			this.btActualizarAccion.Enabled = Activar;
			this.btEliminarAccion.Enabled = Activar;

		}
		#endregion

		#region ActivarBotonesAcciones(bool Activar)
		private void ActivarBotonesAcciones(bool Activar)
		{
			this.btBuscaAccion.Enabled = Activar;
			this.nupAccCantidad.Enabled = Activar;
			this.txtAccObservEntrega.Enabled = Activar; 
			//this.dtpAccFEntrega.Enabled = Activar;
		}
		#endregion

		#region btGrabar_Click
		private void btGrabar_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (this.Param_TipoAcceso!="C")
				{
					if(SaveInfo())
					{
						Mensajes.ShowInformation(3004);
							this.SalirDesdeGuardar=true;
							this.Saved = true;
							this.Close();
					}
				}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion
		#region Validar
		#region ValidaFormulario
		/// <summary>
		/// Valida el formato de la informacion introducida
		/// </summary>
		/// <returns>True si todo es correcto, False en caso contrario</returns>
		private bool validaForm()
		{
			bool bVar = true;

			bVar=GESTCRM.Utiles.ValidaCampo(this.txtNombre.Name.ToString().ToUpper().Trim(),"Nombre ",GESTCRM.Utiles.sPatternOnlyCharsAndSpace,GESTCRM.Utiles.sPatternOnlyCharsAndSpaceGuide ,this );
			if (bVar)
			{
				bVar=GESTCRM.Utiles.ValidaCampo(this.txtApe1.Name.ToString().ToUpper().Trim(),"Apellido 1 ",GESTCRM.Utiles.sPatternOnlyCharsAndSpace,GESTCRM.Utiles.sPatternOnlyCharsAndSpaceGuide ,this  );
			}
			if (bVar)
			{
				bVar=GESTCRM.Utiles.ValidaCampo(this.txtApe2.Name.ToString().ToUpper().Trim(),"Apellido 2 ",GESTCRM.Utiles.sPatternOnlyCharsAndSpace,GESTCRM.Utiles.sPatternOnlyCharsAndSpaceGuide ,this  );
			}
			if (bVar)
			{
				bVar=GESTCRM.Utiles.ValidaCampo(this.txtNumCol1.Name.ToString().ToUpper().Trim(),"Número Colegiado ",Utiles.sPatternNumCol,Utiles.sPatternNumColGuide, this   ) &&   
					 GESTCRM.Utiles.ValidaCampo(this.txtNumCol2.Name.ToString().ToUpper().Trim(),"Número Colegiado ",Utiles.sPatternNumCol,Utiles.sPatternNumColGuide,this   ) &&
					 GESTCRM.Utiles.ValidaCampo(this.txtNumCol3.Name.ToString().ToUpper().Trim(),"Número Colegiado ",Utiles.sPatternNumCol2,Utiles.sPatternNumColGuide ,this  )  ;
				if (bVar)
				{
					if ((this.txtNumCol1.Text.Length +  this.txtNumCol2.Text.Length + this.txtNumCol3.Text.Length)>0 && (this.txtNumCol1.Text.Length +  this.txtNumCol2.Text.Length + this.txtNumCol3.Text.Length)<9)
					{
						Mensajes.ShowError("Formato del Campo Número Colegiado incorrecto.\n\nConsidere las siguientes alternativas:\n\n"+Utiles.sPatternNumColGuide.ToString()); 
						bVar=false;
					}
				}
				//Convierte los campos en un solo numero y lo deja en la tabla Clientes_COM;
				if (bVar)
				{
					this.dsClientes1.Clientes_COM[0].sNumColegiado =  this.txtNumCol1.Text.ToString().Trim() +
																	  this.txtNumCol2.Text.ToString().Trim() +
																	  this.txtNumCol3.Text.ToString().Trim();
				}
			}
			if (bVar)
			{
				bVar=GESTCRM.Utiles.ValidaCampo(this.txtTelefono.Name.ToString().ToUpper().Trim(),"Teléfono ",GESTCRM.Utiles.sPatternTelNumber ,GESTCRM.Utiles.sPatternTelGuide ,this    );
			}
			if (bVar)
			{
				bVar=GESTCRM.Utiles.ValidaCampo(this.txtFax.Name.ToString().ToUpper().Trim(),"FAX ",GESTCRM.Utiles.sPatternTelNumber  ,GESTCRM.Utiles.sPatternTelGuide,this     );
			}
			if (bVar)
			{
				bVar=GESTCRM.Utiles.ValidaCampo(this.txtMovil.Name.ToString().ToUpper().Trim(),"Móvil ",GESTCRM.Utiles.sPatternCelNumber   ,GESTCRM.Utiles.sPatternCelGuide ,this    );
			}
			if (bVar)
			{
				bVar=GESTCRM.Utiles.ValidaCampo(this.txtEMail.Name.ToString().ToUpper().Trim(),"EMail ",GESTCRM.Utiles.sPatternEmailPat   ,GESTCRM.Utiles.sPattrenEmailGuide ,this  );
			}
			if (bVar)
			{
				bVar=GESTCRM.Utiles.ValidaCampo(this.txtNIF.Name.ToString().ToUpper().Trim(),"NIF ",GESTCRM.Utiles.sPattrenNIFPat   ,GESTCRM.Utiles.sPattrenNIFGuide  ,this    ) ;    
				if (bVar && this.txtNIF.Text.ToString().ToUpper().Trim().Length>0 &&  !GESTCRM.Utiles.NifCorrecto(this.txtNIF.Text.ToString().ToUpper().Trim())) 
				{
					Mensajes.ShowError("El NIF Introducido no es Correcto"); 
					bVar= false;
					this.txtNIF.Focus();  
				}
			}
			//Validacion de las fechas
			if (bVar)
			{
				if (dtFechaNac.Value > DateTime.Today && this.fNacChanged && !this.dsClientes1.Clientes_COM[0].IsdFecNacimientoNull())
				{
					Mensajes.ShowInformation("La fecha de nacimiento debe de ser inferior a la fecha actual.");
					bVar= false;
				}
			}
			if (bVar)
			{
				if (dtFechaAniv.Value > DateTime.Today && this.fMatChanged && !this.dsClientes1.Clientes_COM[0].IsdFecAniversarioNull())
				{
					Mensajes.ShowInformation("La fecha de aniversario debe de ser inferior a la fecha actual.");
					bVar= false;
				}
			}
			return bVar;
		}
		#endregion
		#endregion
		#region Grabar Datos
		#region SaveInfo
		private bool SaveInfo()
		{
			bool bRetCode = true;
			System.Data.SqlClient.SqlTransaction SqlTrans;

			if (this.sqlConn.State == ConnectionState.Closed ) sqlConn.Open(); 

			SqlTrans = this.sqlConn.BeginTransaction();  

			try
			{
			
				// Se cancela la edicion de todos los controles para reflejar
				// los cambios en los DataTables y poder recogerlos con el DataTable.GetChanges
				foreach(DataTable dt in this.dsClientes1.Tables )
				{
					foreach(DataRow dr in dt.Rows ) dr.EndEdit();
				}
				bRetCode=validaForm();
				if (bRetCode)
				{
                    //---- GSG (07/10/2014)

                    //bRetCode = SetCliente(SqlTrans) &&
                    //    SetClienteRed(SqlTrans) &&
                    //    SetCliente_COM(SqlTrans) &&
                    //    SetCentrosClientes_COM(SqlTrans) &&
                    //    SetEspecClientes_COM(SqlTrans) &&
                    //    SetAficClientes_COM(SqlTrans) &&
                    //    SetProdClientes_COM(SqlTrans) &&
                    //    SetAccionesMarkClientes(SqlTrans);

                    bRetCode = SetCliente(SqlTrans) &&
                        SetClienteRed(SqlTrans) &&
                        SetCliente_COM(SqlTrans) &&
                        SetCentrosClientes_COM(SqlTrans) &&
                        SetEspecClientes_COM(SqlTrans) &&
                        SetAreasClientes_COM(SqlTrans) &&
                        SetProdClientes_COM(SqlTrans) &&
                        SetAccionesMarkClientes(SqlTrans);

					if (bRetCode)
					{
						SqlTrans.Commit(); 
					}
					else
					{
						SqlTrans.Rollback();
					}
				}
			}
			catch
			{
				bRetCode=false;
				SqlTrans.Rollback();
			}
			finally
			{
				sqlConn.Close(); 
			}
			return (bRetCode);
		}
		#endregion
		#region Set Cliente
		/// <summary>
		/// Inserta/Actualiza los Datos en la Tabla Clientes
		/// </summary>
		/// <param name="SqlTrans">Objeto Transaccion para ejecutar el comando</param>
		/// <returns>True si se graban los datos correctamente, 0 en caso contrario</returns>
		private bool SetCliente(System.Data.SqlClient.SqlTransaction SqlTrans)
		{
			bool bSuccess=true;
			try
			{

				this.sqlCmdSetCliente.Transaction = SqlTrans;
				GESTCRM.Formularios.DataSets.dsAltaMedicos.ClientesDataTable  dt =(GESTCRM.Formularios.DataSets.dsAltaMedicos.ClientesDataTable)this.dsClientes1.Clientes.GetChanges(DataRowState.Modified);

				if ((dt!=null && dt.Rows.Count  >0) || this.Param_TipoAcceso=="A" )

				{
					this.sqlCmdSetCliente.Parameters["@iIdCliente"].Value =dt[0].iIdCliente   ;
					this.sqlCmdSetCliente.Parameters["@sIdCliente"].Value =dt[0].sIdCliente ;
					this.sqlCmdSetCliente.Parameters["@sIdClienteTemp"].Value =dt[0].sIdClienteTemp;
					this.sqlCmdSetCliente.Parameters["@iEstado"].Value =dt[0].iEstado;
					this.sqlCmdSetCliente.Parameters["@sNombre"].Value = dt[0].sNombre.ToUpper().Trim();
					this.sqlCmdSetCliente.Parameters["@sApellido1"].Value =dt[0].sApellidos1.ToUpper().Trim();
					this.sqlCmdSetCliente.Parameters["@sApellido2"].Value =dt[0].sApellidos2.ToUpper().Trim();
					this.sqlCmdSetCliente.Parameters["@sTelefono"].Value =dt[0].sTelefono==null?System.Data.SqlTypes.SqlString.Null:dt[0].sTelefono;

					this.sqlCmdSetCliente.ExecuteScalar();

					bSuccess = (!Convert.ToBoolean (this.sqlCmdSetCliente.Parameters["@RETURN_VALUE"].Value ));
				}


			}
			catch(Exception e)
			{
				Mensajes.ShowError("Error en Actualización de tabla Clientes\n\n"+e.Message.ToString()); 
				bSuccess=false;
			}
			return bSuccess;
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
				GESTCRM.Formularios.DataSets.dsAltaMedicos.ClientesRedesDataTable  dt =(GESTCRM.Formularios.DataSets.dsAltaMedicos.ClientesRedesDataTable)this.dsClientes1.ClientesRedes.GetChanges();

				if ((dt!=null && dt.Rows.Count  >0) && dt[0].sIdRed == GESTCRM.Clases.Configuracion.sIdRed  )
				{
					this.sqlCmdSetClienteRed.Transaction = SqlTrans;
					this.sqlCmdSetClienteRed.Parameters["@iIdCliente"].Value = Param_iIdCliente;
					this.sqlCmdSetClienteRed.Parameters["@sIdRed"].Value =dt[0].sIdRed.ToString();    
					this.sqlCmdSetClienteRed.Parameters["@sIdClasificacion"].Value =dt[0].sIdClasificacion; 
					this.sqlCmdSetClienteRed.Parameters["@dFAR"].Value =DateTime.Now; 
					this.sqlCmdSetClienteRed.Parameters["@dFBR"].Value = System.Data.SqlTypes.SqlDateTime.Null; 
					this.sqlCmdSetClienteRed.Parameters["@iEstado"].Value =dt[0].iEstado; 
				}
				else
					if (this.Param_TipoAcceso =="A")
					{
					this.sqlCmdSetClienteRed.Transaction = SqlTrans;
					this.sqlCmdSetClienteRed.Parameters["@iIdCliente"].Value = Param_iIdCliente;
					this.sqlCmdSetClienteRed.Parameters["@sIdRed"].Value =this.dsClientes1.ClientesRedes[0].sIdRed.ToString();    
					this.sqlCmdSetClienteRed.Parameters["@sIdClasificacion"].Value =this.dsClientes1.ClientesRedes[0].IssIdClasificacionNull()?System.Data.SqlTypes.SqlString.Null:dsClientes1.ClientesRedes[0].sIdClasificacion; 
					this.sqlCmdSetClienteRed.Parameters["@dFAR"].Value =dsClientes1.ClientesRedes[0].dFAR; 
					this.sqlCmdSetClienteRed.Parameters["@dFBR"].Value = System.Data.SqlTypes.SqlDateTime.Null; 
					this.sqlCmdSetClienteRed.Parameters["@iEstado"].Value =dsClientes1.ClientesRedes[0].iEstado; 
					}

				if (dt!=null || this.Param_TipoAcceso =="A")
				{
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
		#region SetCliente_COM
		/// <summary>
		/// Inserta/Actualiza los Datos en la Tabla Clientes_COM
		/// </summary>
		/// <param name="SqlTrans">Objeto Transaccion para ejecutar el comando</param>
		/// <returns>True si se graban los datos correctamente, 0 en caso contrario</returns>
		private bool SetCliente_COM(System.Data.SqlClient.SqlTransaction SqlTrans)
		{
			bool bSuccess=true;
			try
			{
				GESTCRM.Formularios.DataSets.dsAltaMedicos.Clientes_COMDataTable  dt =(GESTCRM.Formularios.DataSets.dsAltaMedicos.Clientes_COMDataTable)this.dsClientes1.Clientes_COM.GetChanges();

				if (dt!=null && dt.Rows.Count  >0 )
				{
					this.sqlCmdSetCliente_COM.Transaction = SqlTrans;
					this.sqlCmdSetCliente_COM.Parameters["@iIdCliente"].Value = dt[0].iIdCliente;   
					this.sqlCmdSetCliente_COM.Parameters["@sTipoCliente_COM"].Value =(dt[0].IssTipoCliente_COMNull()?System.Data.SqlTypes.SqlString.Null:dt[0].sTipoCliente_COM.ToString());   
					this.sqlCmdSetCliente_COM.Parameters["@sNumColegiado"].Value = (dt[0].IssNumColegiadoNull() || dt[0].sNumColegiado.Trim().Length==0?System.Data.SqlTypes.SqlString.Null:dt[0].sNumColegiado.ToString());  

					this.sqlCmdSetCliente_COM.Parameters["@tObservaciones"].Value = (this.textDeleted && this.txtObsMedico.ToString().Trim().Length >0 && !dt[0].IstObservacionesNull())?dt[0].tObservaciones.ToString():System.Data.SqlTypes.SqlString.Null;     
					this.sqlCmdSetCliente_COM.Parameters["@sEMail"].Value =(dt[0].IssEMailNull()?System.Data.SqlTypes.SqlString.Null:dt[0].sEMail.ToString());   
					this.sqlCmdSetCliente_COM.Parameters["@sFax"].Value = (dt[0].IssFaxNull()?System.Data.SqlTypes.SqlString.Null:dt[0].sFax.ToString());   
					this.sqlCmdSetCliente_COM.Parameters["@sTelMovil"].Value = (dt[0].IssTelMovilNull()?System.Data.SqlTypes.SqlString.Null:dt[0].sTelMovil.ToString());  
					this.sqlCmdSetCliente_COM.Parameters["@sDireccion"].Value = (dt[0].IssDireccionNull()?System.Data.SqlTypes.SqlString.Null:dt[0].sDireccion.ToString());   
					this.sqlCmdSetCliente_COM.Parameters["@iIdPoblacion"].Value = (dt[0].IsiIdPoblacionNull()?System.Data.SqlTypes.SqlInt32.Null:dt[0].iIdPoblacion);   
		 
					this.sqlCmdSetCliente_COM.Parameters["@dFecNacimiento"].Value = ((this.fNacChanged || this.fNacData) && !dt[0].IsdFecNacimientoNull())?DateTime.Parse(dt[0].dFecNacimiento.ToShortDateString()) :System.Data.SqlTypes.SqlDateTime.Null;  
					this.sqlCmdSetCliente_COM.Parameters["@dFecAniversario"].Value = ((this.fMatChanged || this.fMatData) && !dt[0].IsdFecAniversarioNull())?DateTime.Parse(dt[0].dFecAniversario.ToShortDateString()):System.Data.SqlTypes.SqlDateTime.Null;

					this.sqlCmdSetCliente_COM.Parameters["@sNIF"].Value = (dt[0].IssNIFNull()?System.Data.SqlTypes.SqlString.Null:dt[0].sNIF.ToString());  
					this.sqlCmdSetCliente_COM.Parameters["@dFUM"].Value = DateTime.Now;
					this.sqlCmdSetCliente_COM.Parameters["@bEnviadoCEN"].Value = 0;

					this.sqlCmdSetCliente_COM.ExecuteScalar();

					bSuccess = (!Convert.ToBoolean (this.sqlCmdSetCliente_COM.Parameters["@RETURN_VALUE"].Value));
				}

			}
			catch(Exception e)
			{
				Mensajes.ShowError("Error en Actualización de tabla Clientes_COM\n\n"+e.Message.ToString()); 
				bSuccess=false;
			}
			return bSuccess;
		}
		#endregion
		#region SetCentrosClientes_COM
		/// <summary>
		/// Inserta/Actualiza los Datos en la Tabla CentrosClientes_COM
		/// </summary>
		/// <param name="SqlTrans">Objeto Transaccion para ejecutar el comando</param>
		/// <returns>True si se graban los datos correctamente, 0 en caso contrario</returns>
		private bool SetCentrosClientes_COM(System.Data.SqlClient.SqlTransaction SqlTrans)
		{
			bool bSuccess=true;
			try
			{
				GESTCRM.Formularios.DataSets.dsAltaMedicos.CentrosClientes_COMDataTable   dt =(GESTCRM.Formularios.DataSets.dsAltaMedicos.CentrosClientes_COMDataTable)this.dsClientes1.CentrosClientes_COM.GetChanges();

				if (dt!=null && dt.Rows.Count  >0 )
				{
					this.sqlCmdSetCentrosClientes_COM.Transaction = SqlTrans;

					foreach (GESTCRM.Formularios.DataSets.dsAltaMedicos.CentrosClientes_COMRow dr in dt.Rows)
					{

						if (dr.RowState!=DataRowState.Deleted  )
						{
							this.sqlCmdSetCentrosClientes_COM.Parameters["@iIdCliente"].Value = this.Param_iIdCliente; 
							this.sqlCmdSetCentrosClientes_COM.Parameters["@iAccion"].Value=(dr.RowState==DataRowState.Added)?0:(dr.RowState==DataRowState.Modified && dr.iEstado ==-1)?2:1;
							this.sqlCmdSetCentrosClientes_COM.Parameters["@iIdCentro"].Value= dr.iIdCentro;
							this.sqlCmdSetCentrosClientes_COM.Parameters["@sIdTipoRelacionCliCen"].Value=(dr.IssIdTipoRelacionCliCenNull()?System.Data.SqlTypes.SqlString.Null:dr.sIdTipoRelacionCliCen.ToString());
							this.sqlCmdSetCentrosClientes_COM.Parameters["@sIdRed"].Value =dr.sIdRed.ToString(); 
							this.sqlCmdSetCentrosClientes_COM.Parameters["@iEstado"].Value=dr.iEstado;
						
							this.sqlCmdSetCentrosClientes_COM.ExecuteScalar();

							bSuccess = (!Convert.ToBoolean (this.sqlCmdSetCentrosClientes_COM.Parameters["@RETURN_VALUE"].Value));

							if (!bSuccess) break;
						}
					}
				}

			}
			catch(Exception e)
			{
				Mensajes.ShowError("Error en Actualización de tabla CentrosClientes_COM\n\n"+e.Message.ToString()); 
				bSuccess=false;
			}
			return bSuccess;
		}
		#endregion
		#region SetEspecClientes_COM
		/// <summary>
		/// Inserta/Actualiza los Datos en la Tabla EspecClientes_COM
		/// </summary>
		/// <param name="SqlTrans">Objeto Transaccion para ejecutar el comando</param>
		/// <returns>True si se graban los datos correctamente, 0 en caso contrario</returns>
		private bool SetEspecClientes_COM(System.Data.SqlClient.SqlTransaction SqlTrans)
		{
			bool bSuccess=true;
			try
			{
				GESTCRM.Formularios.DataSets.dsAltaMedicos.EspecClientes_COMDataTable    dt =(GESTCRM.Formularios.DataSets.dsAltaMedicos.EspecClientes_COMDataTable)this.dsClientes1.EspecClientes_COM.GetChanges();

				if (dt!=null && dt.Rows.Count  >0 )
				{
					this.sqlCmdSetEspecCLiente_COM.Transaction = SqlTrans;

					foreach (GESTCRM.Formularios.DataSets.dsAltaMedicos.EspecClientes_COMRow  dr in dt.Rows)
					{

						if (dr.RowState!=DataRowState.Deleted )
						{
							this.sqlCmdSetEspecCLiente_COM.Parameters["@iIdCliente"].Value = this.Param_iIdCliente; 
							this.sqlCmdSetEspecCLiente_COM.Parameters["@sIdEspecialidad"].Value=dr.IssIdEspecialidadNull()?System.Data.SqlTypes.SqlString.Null:dr.sIdEspecialidad.ToString();
							this.sqlCmdSetEspecCLiente_COM.Parameters["@dFUM"].Value= DateTime.Now;
							this.sqlCmdSetEspecCLiente_COM.Parameters["@iEstado"].Value=dr.iEstado;
							this.sqlCmdSetEspecCLiente_COM.Parameters["@bEnviadoCen"].Value =0;
						
							this.sqlCmdSetEspecCLiente_COM.ExecuteScalar();

							bSuccess = (!Convert.ToBoolean (this.sqlCmdSetEspecCLiente_COM.Parameters["@RETURN_VALUE"].Value));
						}
						if (!bSuccess) break;
					}
				}

			}
			catch(Exception e)
			{
				Mensajes.ShowError("Error en Actualización de tabla EspecClientes_COM\n\n"+e.Message.ToString()); 
				bSuccess=false;
			}
			return bSuccess;
		}
		#endregion
		#region SetAficClientes_COM
		/// <summary>
		/// Inserta/Actualiza los Datos en la Tabla AficClientes_COM
		/// </summary>
		/// <param name="SqlTrans">Objeto Transaccion para ejecutar el comando</param>
		/// <returns>True si se graban los datos correctamente, 0 en caso contrario</returns>
		private bool SetAficClientes_COM(System.Data.SqlClient.SqlTransaction SqlTrans)
		{
			bool bSuccess=true;
			try
			{
				GESTCRM.Formularios.DataSets.dsAltaMedicos.AficClientes_COMDataTable    dt =(GESTCRM.Formularios.DataSets.dsAltaMedicos.AficClientes_COMDataTable)this.dsClientes1.AficClientes_COM.GetChanges();

				if (dt!=null && dt.Rows.Count  >0 )
				{
					this.sqlCmdSetAficClientesCOM.Transaction = SqlTrans;

					foreach (GESTCRM.Formularios.DataSets.dsAltaMedicos.AficClientes_COMRow  dr in dt.Rows)
					{

						if (dr.RowState!=DataRowState.Deleted )
						{
							this.sqlCmdSetAficClientesCOM.Parameters["@iIdCliente"].Value = this.Param_iIdCliente; 
							this.sqlCmdSetAficClientesCOM.Parameters["@sIdAficion"].Value=dr.IssIdAficionNull() ?System.Data.SqlTypes.SqlString.Null:dr.sIdAficion.ToString();
							this.sqlCmdSetAficClientesCOM.Parameters["@dFUM"].Value= DateTime.Now;
							this.sqlCmdSetAficClientesCOM.Parameters["@iEstado"].Value=dr.iEstado ;
							this.sqlCmdSetAficClientesCOM.Parameters["@bEnviadoCen"].Value =0;
						
							this.sqlCmdSetAficClientesCOM.ExecuteScalar();

							bSuccess = (!Convert.ToBoolean (this.sqlCmdSetAficClientesCOM.Parameters["@RETURN_VALUE"].Value));
						}
						if (!bSuccess) break;
					}
				}

			}
			catch(Exception e)
			{
				Mensajes.ShowError("Error en Actualización de tabla AficClientes_COM\n\n"+e.Message.ToString()); 
				bSuccess=false;
			}
			return bSuccess;
		}
		#endregion
		#region SetProdClientes_COM
		/// <summary>
		/// Inserta/Actualiza los Datos en la Tabla AficClientes_COM
		/// </summary>
		/// <param name="SqlTrans">Objeto Transaccion para ejecutar el comando</param>
		/// <returns>True si se graban los datos correctamente, 0 en caso contrario</returns>
		private bool SetProdClientes_COM(System.Data.SqlClient.SqlTransaction SqlTrans)
		{
			bool bSuccess=true;
			try
			{
				GESTCRM.Formularios.DataSets.dsAltaMedicos.ProdClientes_COMDataTable    dt =(GESTCRM.Formularios.DataSets.dsAltaMedicos.ProdClientes_COMDataTable)this.dsClientes1.ProdClientes_COM.GetChanges();

				if (dt!=null && dt.Rows.Count  >0 )
				{
					this.sqlCmdSetProdClientesCOM.Transaction = SqlTrans;

					foreach (GESTCRM.Formularios.DataSets.dsAltaMedicos.ProdClientes_COMRow   dr in dt.Rows)
					{

						if (dr.RowState!=DataRowState.Deleted )
						{
							this.sqlCmdSetProdClientesCOM.Parameters["@iIdCliente"].Value = this.Param_iIdCliente; 
							this.sqlCmdSetProdClientesCOM.Parameters["@sIdProducto"].Value=dr.IssIdProductoNull()?System.Data.SqlTypes.SqlString.Null:dr.sIdProducto.ToString();
							this.sqlCmdSetProdClientesCOM.Parameters["@iPrioridad"].Value=dr.iPrioridad;
							this.sqlCmdSetProdClientesCOM.Parameters["@dFUM"].Value= DateTime.Now;
							this.sqlCmdSetProdClientesCOM.Parameters["@iEstado"].Value=dr.iEstado;
							this.sqlCmdSetProdClientesCOM.Parameters["@bEnviadoCen"].Value =0;
						
							this.sqlCmdSetProdClientesCOM.ExecuteScalar();

							bSuccess = (!Convert.ToBoolean (this.sqlCmdSetProdClientesCOM.Parameters["@RETURN_VALUE"].Value));
						}
						if (!bSuccess) break;
					}
				}

			}
			catch(Exception e)
			{
				Mensajes.ShowError("Error en Actualización de tabla AficClientes_COM\n\n"+e.Message.ToString()); 
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
				GESTCRM.Formularios.DataSets.dsAltaMedicos.AccionesMarkClientesDataTable    dt =(GESTCRM.Formularios.DataSets.dsAltaMedicos.AccionesMarkClientesDataTable)this.dsClientes1.AccionesMarkClientes.GetChanges();

				if (dt!=null && dt.Rows.Count  >0 )
				{
					this.sqlCmdSetAccionesMarkClientes.Transaction = SqlTrans;

					foreach (GESTCRM.Formularios.DataSets.dsAltaMedicos.AccionesMarkClientesRow   dr in dt.Rows)
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
		#endregion


        private bool SetAreasClientes_COM(System.Data.SqlClient.SqlTransaction SqlTrans)
        {
            bool bSuccess = true;
            try
            {
                GESTCRM.Formularios.DataSets.dsClientes.ListaAreas_porCliente_SAPDataTable dt = (GESTCRM.Formularios.DataSets.dsClientes.ListaAreas_porCliente_SAPDataTable)this.dsClientes2.ListaAreas_porCliente_SAP.GetChanges();

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


            }
            catch (Exception e)
            {
                Mensajes.ShowError("Error en Actualización de tabla ContactosClientes_SAP\n\n" + e.Message.ToString());
                bSuccess = false;
            }
            return bSuccess;
        }


		#region Inicializar_Cliente
		private void Inicializar_Cliente()
		{
			try
			{
				if (this.dsClientes1.Clientes_COM.Rows.Count>0    )
				{
					this.Param_iEstado = this.dsClientes1.Clientes[0].iEstado;
					this.txtNumCol1.Text = (this.dsClientes1.Clientes_COM[0].IssNumColegiadoNull())||this.dsClientes1.Clientes_COM[0].sNumColegiado.Trim().Length==0?"":this.dsClientes1.Clientes_COM[0].sNumColegiado.ToString().Substring(0,2).Replace("-"," ").Trim() ;
					this.txtNumCol2.Text = (this.dsClientes1.Clientes_COM[0].IssNumColegiadoNull())||this.dsClientes1.Clientes_COM[0].sNumColegiado.Trim().Length==0?"":this.dsClientes1.Clientes_COM[0].sNumColegiado.ToString().Substring(2,2).Replace("-"," ").Trim();
					this.txtNumCol3.Text = (this.dsClientes1.Clientes_COM[0].IssNumColegiadoNull())||this.dsClientes1.Clientes_COM[0].sNumColegiado.Trim().Length==0?"":this.dsClientes1.Clientes_COM[0].sNumColegiado.ToString().Substring(4).Replace("-"," ").Trim();
					this.dtFechaNac.Value = (this.dsClientes1.Clientes_COM[0].IsdFecNacimientoNull()?DateTime.Now:this.dsClientes1.Clientes_COM[0].dFecNacimiento);
					this.dtFechaAniv .Value = (this.dsClientes1.Clientes_COM[0].IsdFecAniversarioNull()?DateTime.Now:this.dsClientes1.Clientes_COM[0].dFecAniversario);
					this.cmbTipoMedico.SelectedValue = (!this.dsClientes1.Clientes_COM[0].IssTipoCliente_COMNull() )?this.dsClientes1.Clientes_COM[0].sTipoCliente_COM:"1";     
					this.fMatChanged=false;
					this.fNacChanged=false;
					this.Param_iEstado = this.dsClientes1.Clientes[0].iEstado;

				}
				if (this.dsClientes1.ClientesRedes.Rows.Count >0 )
				{
					this.cmbClasif.SelectedValue = (!this.dsClientes1.ClientesRedes[0].IssIdClasificacionNull() )?this.dsClientes1.ClientesRedes[0].sIdClasificacion:"0"; 
				}
				else
				{
					this.cmbClasif.SelectedValue = "0";
				}
				// Se realiza el chequeo de las especialidades del Médico para bloquear las Asignaciones
				ChequeoEspecialidades();
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion 

		private void ChequeoEspecialidades()
		{
			int CountEspec=0;
			if (this.dsClientes1.EspecClientes_COM.Rows.Count >0  )
			{
				foreach (Formularios.DataSets.dsAltaMedicos.EspecClientes_COMRow   rwE in this.dsClientes1.EspecClientes_COM.Rows)
				{
					if (ExisteEspecialidad(rwE.sIdEspecialidad)) CountEspec++;   
				}
				btEliminarEspec.Enabled = CountEspec>0;
				btClienteActualizar.Enabled = CountEspec>0;
				cmbRelacion.SelectedIndex = (CountEspec>0)?0:1;
				cmbRelacion.Enabled = CountEspec>0;
			}
		}

		private bool ExisteEspecialidad(string sIdEspecialidad)
		{
			return this.dsClientes1.ListaTipoEspeciadadMed.Select("sValor='"+sIdEspecialidad+"'").Length >0;   
		}
		private void cmbClasif_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.dsClientes1.ClientesRedes.Rows.Count >0   )
			{
				this.dsClientes1.ClientesRedes[0].sIdClasificacion = cmbClasif.SelectedValue.ToString();    
			}
		}

       


	}
}

