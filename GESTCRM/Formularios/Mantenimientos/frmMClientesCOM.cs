using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace GESTCRM.Formularios.Mantenimientos
{
	public class frmMClientesCOM : GESTCRM.Formularios.Base.frmMantenimientos
	{

		bool SalirDesdeGuardar;

		string Param_TipoAcceso;
		int Param_iIdCliente;
		int Param_iIdDelegado;
		int Param_Inicio;


		int Var_iIdCentro;
		int Var_iIdAccion;

		int Var_iEstado;
		int Var_bEnviadoCEN;

		DataTable dtCentros;
		DataTable dtAccionesMark;

		protected System.Data.SqlClient.SqlTransaction sqlTran;
		private System.Data.SqlClient.SqlConnection sqlConn;
		private System.ComponentModel.IContainer components = null;
		private System.Data.SqlClient.SqlCommand sqlCmdSetCliente;
		private System.Data.SqlClient.SqlCommand sqlCmdSetCentrosClientesCOM;
		private System.Data.SqlClient.SqlCommand sqlCmdSetEspecClientesCOM;
		private System.Data.SqlClient.SqlCommand sqlCmdSetProdClientesCOM;
		private System.Windows.Forms.TextBox txtEstadoCli_COM;
		private System.Windows.Forms.Label label36;
		private System.Windows.Forms.TextBox txtTipoCliente_COM;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.TextBox txtNumColegiado_COM;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.TextBox txtDatosFinancieros_COM;
		private System.Windows.Forms.TextBox txtNIF_COM;
		private System.Windows.Forms.TextBox txtTipo_COM;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.TextBox txtEMail_COM;
		private System.Windows.Forms.TextBox txtFax_COM;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.TextBox txtTelMovil_COM;
		private System.Windows.Forms.TextBox txtTelefono_COM;
		private System.Windows.Forms.TextBox txtPoblacion_COM;
		private System.Windows.Forms.TextBox txtCategoria_COM;
		private System.Windows.Forms.TextBox txtProvincia_COM;
		private System.Windows.Forms.TextBox txtCP_COM;
		private System.Windows.Forms.TextBox txtDireccion_COM;
		private System.Windows.Forms.TextBox txtNombre_COM;
		private System.Windows.Forms.TextBox txtsIdCliente_COM;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.Label label28;
		private System.Windows.Forms.Label label29;
		private System.Windows.Forms.Label label30;
		private System.Windows.Forms.Label label31;
		private System.Windows.Forms.Label label32;
		private System.Windows.Forms.Label label33;
		private System.Windows.Forms.Label label34;
		private System.Windows.Forms.Label label35;
		private System.Windows.Forms.TextBox txtObservaciones_COM;
		private System.Windows.Forms.TextBox txtPolGen_COM;
		private System.Windows.Forms.TextBox txtFecAniv_COM;
		private System.Windows.Forms.TextBox txtFecNacim_COM;
		private System.Windows.Forms.TextBox txtIdioma2_COM;
		private System.Windows.Forms.TextBox txtIdioma1_COM;
		private System.Windows.Forms.TextBox txtEstadoCivil_COM;
		private System.Windows.Forms.TextBox txttIdCaracteristica_COM;
		private System.Windows.Forms.Label label47;
		private System.Windows.Forms.Label label44;
		private System.Windows.Forms.Label label43;
		private System.Windows.Forms.Label label42;
		private System.Windows.Forms.Label label40;
		private System.Windows.Forms.Label label38;
		private System.Windows.Forms.Label label37;
		private System.Windows.Forms.Label label39;
		private System.Windows.Forms.Button btAmpliacion;
		private System.Windows.Forms.Button btAccionesMark;
		private System.Windows.Forms.Panel pnCliente;
		private System.Windows.Forms.Panel pnAccionesMark;
		private System.Windows.Forms.DataGrid dgEspecialidades;
		private System.Data.SqlClient.SqlDataAdapter sqldaListaEspecClientes_COM;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		private GESTCRM.Formularios.DataSets.dsClientes dsClientes1;
		private System.Windows.Forms.DataGrid dgProductos;
		private System.Data.SqlClient.SqlDataAdapter sqldaListaProdClientes_COM;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		private System.Windows.Forms.Button btActualizarEspec;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
		private System.Windows.Forms.Button btEliminarEspec;
		private System.Windows.Forms.ComboBox cbEspecialidades;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btEliminarProd;
		private System.Windows.Forms.Button btActualizarProd;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.TextBox txtProdCodigo;
		private System.Windows.Forms.NumericUpDown nupPrioridadProd;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Data.SqlClient.SqlDataAdapter sqldaListaTipoEspecialidadMed;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		private System.Data.SqlClient.SqlDataAdapter sqldaListaProductos;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand4;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem menuNuevo;
		private System.Windows.Forms.MenuItem menuEliminar;
		private System.Data.SqlClient.SqlDataAdapter sqldaListaCentros_porCliente_COM;
		private System.Windows.Forms.DataGrid dgCentros;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle3;
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
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn17;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn18;
		private System.Windows.Forms.TextBox txtCentrosId;
		private System.Windows.Forms.TextBox txtCentroDesc;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Button btBuscarCentro;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.ComboBox cbCentRelacion;
		private System.Windows.Forms.TextBox txtCenManIni;
		private System.Windows.Forms.ComboBox cbCenHorario;
		private System.Windows.Forms.TextBox txtCentDiaVis;
		private System.Windows.Forms.TextBox txtCenManFin;
		private System.Windows.Forms.TextBox txtCenTarFin;
		private System.Windows.Forms.TextBox txtCenObservVisi;
		private System.Windows.Forms.TextBox txtCenTarIni;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Data.SqlClient.SqlDataAdapter sqldaListaTipoHorarioCentro;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand6;
		private System.Data.SqlClient.SqlDataAdapter sqldaListaTipoRelacionClienteCentro;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand7;
		private System.Windows.Forms.Button btEliminarCen;
		private System.Windows.Forms.Button btActualizarCen;
		private System.Windows.Forms.DataGrid dgAccionesMark;
		private System.Data.SqlClient.SqlDataAdapter sqldaListaAccionesMarkCli;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle4;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn6;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn19;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn20;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn21;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand5;
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
		private System.Data.SqlClient.SqlDataAdapter sqldaGetCliente_COM;
		private System.Data.SqlClient.SqlCommand sqlCmdSetAccionesMarkClientes;
		private System.Data.SqlClient.SqlCommand sqlCmdSetCentrosCliCom_Horarios;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn22;
		private System.Windows.Forms.Label lblTotAcciones;
		private System.Windows.Forms.Label lblTotCentros;
		private System.Windows.Forms.Label lblTotProductos;
		private System.Windows.Forms.Label lblTotEspecialidades;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand9;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn23;
		private GESTCRM.Controles.ucBotoneraSecundaria ucBotoneraSecundaria1;
		private GESTCRM.Controles.LabelGradient lblTitulo;
		private System.Windows.Forms.Panel panel2;
		private GESTCRM.Controles.LabelGradient labelGradient1;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Panel panel7;
		private GESTCRM.Controles.LabelGradient labelGradient2;
		private GESTCRM.Controles.LabelGradient labelGradient3;
		private System.Windows.Forms.Button btCRM;
		private System.Windows.Forms.Panel pnCRM;
		private System.Windows.Forms.Panel panel8;
		private GESTCRM.Controles.LabelGradient labelGradient4;
		private System.Windows.Forms.Panel panel9;
		private System.Windows.Forms.Label lblTotAficiones;
		private GESTCRM.Controles.LabelGradient labelGradient5;
		private System.Windows.Forms.Panel panel10;
		private System.Windows.Forms.ComboBox cbAficiones;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Button btEliminarAfic;
		private System.Windows.Forms.Button btActualizarAfic;
		private System.Data.SqlClient.SqlDataAdapter sqldaListaAficClientes_COM;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand10;
		private System.Data.SqlClient.SqlDataAdapter sqldaListaTipoAficiones;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand11;
		private System.Data.SqlClient.SqlCommand sqlCmdSetAficClientes_COM;
		private System.Windows.Forms.DataGrid dgAficiones;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle5;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn24;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn25;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn5;
		private System.Windows.Forms.Button btBuscarProducto;
		private System.Windows.Forms.TextBox txttProducto;
		private GESTCRM.CRMControles.ucUltimasVisitas ucUltimasVisitas1;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand8;
		private System.Windows.Forms.Panel pnAmpliacion;

		public frmMClientesCOM(string TipoAcceso,int iIdCliente)
		{	
			InitializeComponent();
	
			this.Param_TipoAcceso = TipoAcceso;
			this.Param_iIdCliente = iIdCliente;
			this.Param_Inicio = -1;
		}

		public frmMClientesCOM(string TipoAcceso,int iIdCliente,int Inicio)
		{	
			InitializeComponent();
	
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
			System.Configuration.AppSettingsReader configurationAppSettings = new System.Configuration.AppSettingsReader();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMClientesCOM));
			this.sqlConn = new System.Data.SqlClient.SqlConnection();
			this.sqldaListaEspecClientes_COM = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlCmdSetCliente = new System.Data.SqlClient.SqlCommand();
			this.sqlCmdSetCentrosClientesCOM = new System.Data.SqlClient.SqlCommand();
			this.sqlCmdSetEspecClientesCOM = new System.Data.SqlClient.SqlCommand();
			this.sqlCmdSetProdClientesCOM = new System.Data.SqlClient.SqlCommand();
			this.pnCliente = new System.Windows.Forms.Panel();
			this.lblTitulo = new GESTCRM.Controles.LabelGradient();
			this.txtEstadoCli_COM = new System.Windows.Forms.TextBox();
			this.dsClientes1 = new GESTCRM.Formularios.DataSets.dsClientes();
			this.txtTipoCliente_COM = new System.Windows.Forms.TextBox();
			this.txtNumColegiado_COM = new System.Windows.Forms.TextBox();
			this.txtProvincia_COM = new System.Windows.Forms.TextBox();
			this.label36 = new System.Windows.Forms.Label();
			this.label22 = new System.Windows.Forms.Label();
			this.label21 = new System.Windows.Forms.Label();
			this.txtDatosFinancieros_COM = new System.Windows.Forms.TextBox();
			this.txtNIF_COM = new System.Windows.Forms.TextBox();
			this.txtTipo_COM = new System.Windows.Forms.TextBox();
			this.label20 = new System.Windows.Forms.Label();
			this.txtPoblacion_COM = new System.Windows.Forms.TextBox();
			this.txtCategoria_COM = new System.Windows.Forms.TextBox();
			this.txtCP_COM = new System.Windows.Forms.TextBox();
			this.txtDireccion_COM = new System.Windows.Forms.TextBox();
			this.txtNombre_COM = new System.Windows.Forms.TextBox();
			this.txtsIdCliente_COM = new System.Windows.Forms.TextBox();
			this.label24 = new System.Windows.Forms.Label();
			this.label25 = new System.Windows.Forms.Label();
			this.label26 = new System.Windows.Forms.Label();
			this.label27 = new System.Windows.Forms.Label();
			this.label28 = new System.Windows.Forms.Label();
			this.label29 = new System.Windows.Forms.Label();
			this.label30 = new System.Windows.Forms.Label();
			this.label31 = new System.Windows.Forms.Label();
			this.label35 = new System.Windows.Forms.Label();
			this.txtEMail_COM = new System.Windows.Forms.TextBox();
			this.txtFax_COM = new System.Windows.Forms.TextBox();
			this.label23 = new System.Windows.Forms.Label();
			this.txtTelMovil_COM = new System.Windows.Forms.TextBox();
			this.txtTelefono_COM = new System.Windows.Forms.TextBox();
			this.label32 = new System.Windows.Forms.Label();
			this.label33 = new System.Windows.Forms.Label();
			this.label34 = new System.Windows.Forms.Label();
			this.pnAmpliacion = new System.Windows.Forms.Panel();
			this.panel9 = new System.Windows.Forms.Panel();
			this.lblTotAficiones = new System.Windows.Forms.Label();
			this.labelGradient5 = new GESTCRM.Controles.LabelGradient();
			this.dgAficiones = new System.Windows.Forms.DataGrid();
			this.dataGridTableStyle5 = new System.Windows.Forms.DataGridTableStyle();
			this.dataGridTextBoxColumn24 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn25 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.panel10 = new System.Windows.Forms.Panel();
			this.cbAficiones = new System.Windows.Forms.ComboBox();
			this.label19 = new System.Windows.Forms.Label();
			this.btEliminarAfic = new System.Windows.Forms.Button();
			this.btActualizarAfic = new System.Windows.Forms.Button();
			this.txtPolGen_COM = new System.Windows.Forms.TextBox();
			this.txtObservaciones_COM = new System.Windows.Forms.TextBox();
			this.txtFecAniv_COM = new System.Windows.Forms.TextBox();
			this.txtFecNacim_COM = new System.Windows.Forms.TextBox();
			this.txtIdioma2_COM = new System.Windows.Forms.TextBox();
			this.txtIdioma1_COM = new System.Windows.Forms.TextBox();
			this.txtEstadoCivil_COM = new System.Windows.Forms.TextBox();
			this.txttIdCaracteristica_COM = new System.Windows.Forms.TextBox();
			this.label47 = new System.Windows.Forms.Label();
			this.label44 = new System.Windows.Forms.Label();
			this.label43 = new System.Windows.Forms.Label();
			this.label42 = new System.Windows.Forms.Label();
			this.label40 = new System.Windows.Forms.Label();
			this.label38 = new System.Windows.Forms.Label();
			this.label37 = new System.Windows.Forms.Label();
			this.label39 = new System.Windows.Forms.Label();
			this.btAmpliacion = new System.Windows.Forms.Button();
			this.btCRM = new System.Windows.Forms.Button();
			this.btAccionesMark = new System.Windows.Forms.Button();
			this.lblTotEspecialidades = new System.Windows.Forms.Label();
			this.lblTotProductos = new System.Windows.Forms.Label();
			this.dgEspecialidades = new System.Windows.Forms.DataGrid();
			this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
			this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn5 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dgProductos = new System.Windows.Forms.DataGrid();
			this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
			this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.panel3 = new System.Windows.Forms.Panel();
			this.txttProducto = new System.Windows.Forms.TextBox();
			this.btBuscarProducto = new System.Windows.Forms.Button();
			this.nupPrioridadProd = new System.Windows.Forms.NumericUpDown();
			this.txtProdCodigo = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.btEliminarProd = new System.Windows.Forms.Button();
			this.btActualizarProd = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.cbEspecialidades = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btEliminarEspec = new System.Windows.Forms.Button();
			this.btActualizarEspec = new System.Windows.Forms.Button();
			this.pnCRM = new System.Windows.Forms.Panel();
			this.ucUltimasVisitas1 = new GESTCRM.CRMControles.ucUltimasVisitas();
			this.panel7 = new System.Windows.Forms.Panel();
			this.labelGradient2 = new GESTCRM.Controles.LabelGradient();
			this.panel6 = new System.Windows.Forms.Panel();
			this.labelGradient3 = new GESTCRM.Controles.LabelGradient();
			this.panel2 = new System.Windows.Forms.Panel();
			this.dgCentros = new System.Windows.Forms.DataGrid();
			this.dataGridTableStyle3 = new System.Windows.Forms.DataGridTableStyle();
			this.dataGridTextBoxColumn10 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn7 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn8 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn9 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn11 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn12 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn18 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn13 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn14 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn15 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn16 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn17 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn22 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.lblTotCentros = new System.Windows.Forms.Label();
			this.labelGradient1 = new GESTCRM.Controles.LabelGradient();
			this.btEliminarCen = new System.Windows.Forms.Button();
			this.btActualizarCen = new System.Windows.Forms.Button();
			this.panel4 = new System.Windows.Forms.Panel();
			this.txtCenObservVisi = new System.Windows.Forms.TextBox();
			this.txtCenManFin = new System.Windows.Forms.TextBox();
			this.txtCenTarFin = new System.Windows.Forms.TextBox();
			this.txtCenManIni = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.txtCenTarIni = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.txtCentroDesc = new System.Windows.Forms.TextBox();
			this.txtCentrosId = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.btBuscarCentro = new System.Windows.Forms.Button();
			this.cbCentRelacion = new System.Windows.Forms.ComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this.txtCentDiaVis = new System.Windows.Forms.TextBox();
			this.cbCenHorario = new System.Windows.Forms.ComboBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.pnAccionesMark = new System.Windows.Forms.Panel();
			this.panel8 = new System.Windows.Forms.Panel();
			this.dgAccionesMark = new System.Windows.Forms.DataGrid();
			this.dataGridTableStyle4 = new System.Windows.Forms.DataGridTableStyle();
			this.dataGridTextBoxColumn6 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn19 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn20 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn21 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn23 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.lblTotAcciones = new System.Windows.Forms.Label();
			this.labelGradient4 = new GESTCRM.Controles.LabelGradient();
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
			this.sqldaListaProdClientes_COM = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqldaListaTipoEspecialidadMed = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
			this.sqldaListaProductos = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand4 = new System.Data.SqlClient.SqlCommand();
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.menuNuevo = new System.Windows.Forms.MenuItem();
			this.menuEliminar = new System.Windows.Forms.MenuItem();
			this.sqldaListaCentros_porCliente_COM = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand5 = new System.Data.SqlClient.SqlCommand();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.sqldaListaTipoHorarioCentro = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand6 = new System.Data.SqlClient.SqlCommand();
			this.sqldaListaTipoRelacionClienteCentro = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand7 = new System.Data.SqlClient.SqlCommand();
			this.sqldaListaAccionesMarkCli = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand8 = new System.Data.SqlClient.SqlCommand();
			this.sqldaGetCliente_COM = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand9 = new System.Data.SqlClient.SqlCommand();
			this.sqlCmdSetAccionesMarkClientes = new System.Data.SqlClient.SqlCommand();
			this.sqlCmdSetCentrosCliCom_Horarios = new System.Data.SqlClient.SqlCommand();
			this.ucBotoneraSecundaria1 = new GESTCRM.Controles.ucBotoneraSecundaria();
			this.sqldaListaAficClientes_COM = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand10 = new System.Data.SqlClient.SqlCommand();
			this.sqldaListaTipoAficiones = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand11 = new System.Data.SqlClient.SqlCommand();
			this.sqlCmdSetAficClientes_COM = new System.Data.SqlClient.SqlCommand();
			this.pnCliente.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dsClientes1)).BeginInit();
			this.pnAmpliacion.SuspendLayout();
			this.panel9.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgAficiones)).BeginInit();
			this.panel10.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgEspecialidades)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgProductos)).BeginInit();
			this.panel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nupPrioridadProd)).BeginInit();
			this.panel1.SuspendLayout();
			this.pnCRM.SuspendLayout();
			this.panel7.SuspendLayout();
			this.panel6.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgCentros)).BeginInit();
			this.panel4.SuspendLayout();
			this.pnAccionesMark.SuspendLayout();
			this.panel8.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgAccionesMark)).BeginInit();
			this.panel5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nupAccCantidad)).BeginInit();
			this.SuspendLayout();
			// 
			// sqlConn
			// 
			this.sqlConn.ConnectionString = ((string)(configurationAppSettings.GetValue("sConn", typeof(string))));
			// 
			// sqldaListaEspecClientes_COM
			// 
			this.sqldaListaEspecClientes_COM.SelectCommand = this.sqlSelectCommand1;
			this.sqldaListaEspecClientes_COM.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																												  new System.Data.Common.DataTableMapping("Table", "ListaEspecClientes_COM", new System.Data.Common.DataColumnMapping[] {
																																																											new System.Data.Common.DataColumnMapping("sIdEspecialidad", "sIdEspecialidad"),
																																																											new System.Data.Common.DataColumnMapping("tEspecialidad", "tEspecialidad")})});
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = "[ListaEspecClientes_COM]";
			this.sqlSelectCommand1.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelectCommand1.Connection = this.sqlConn;
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4));
			// 
			// sqlCmdSetCliente
			// 
			this.sqlCmdSetCliente.CommandText = "[SetCliente]";
			this.sqlCmdSetCliente.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlCmdSetCliente.Connection = this.sqlConn;
			this.sqlCmdSetCliente.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdSetCliente.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Accion", System.Data.SqlDbType.Int, 4));
			this.sqlCmdSetCliente.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4));
			// 
			// sqlCmdSetCentrosClientesCOM
			// 
			this.sqlCmdSetCentrosClientesCOM.CommandText = "[SetCentrosClientesCOM]";
			this.sqlCmdSetCentrosClientesCOM.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlCmdSetCentrosClientesCOM.Connection = this.sqlConn;
			this.sqlCmdSetCentrosClientesCOM.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdSetCentrosClientesCOM.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iAccion", System.Data.SqlDbType.Int, 4));
			this.sqlCmdSetCentrosClientesCOM.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4));
			this.sqlCmdSetCentrosClientesCOM.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iIdCentro", System.Data.SqlDbType.Int, 4));
			this.sqlCmdSetCentrosClientesCOM.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sIdTipoRelacionCliCen", System.Data.SqlDbType.VarChar, 10));
			// 
			// sqlCmdSetEspecClientesCOM
			// 
			this.sqlCmdSetEspecClientesCOM.CommandText = "[SetEspecClientesCOM]";
			this.sqlCmdSetEspecClientesCOM.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlCmdSetEspecClientesCOM.Connection = this.sqlConn;
			this.sqlCmdSetEspecClientesCOM.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdSetEspecClientesCOM.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iAccion", System.Data.SqlDbType.Int, 4));
			this.sqlCmdSetEspecClientesCOM.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4));
			this.sqlCmdSetEspecClientesCOM.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sIdEspecialidad", System.Data.SqlDbType.VarChar, 10));
			// 
			// sqlCmdSetProdClientesCOM
			// 
			this.sqlCmdSetProdClientesCOM.CommandText = "[SetProdClientesCOM]";
			this.sqlCmdSetProdClientesCOM.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlCmdSetProdClientesCOM.Connection = this.sqlConn;
			this.sqlCmdSetProdClientesCOM.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdSetProdClientesCOM.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iAccion", System.Data.SqlDbType.Int, 4));
			this.sqlCmdSetProdClientesCOM.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4));
			this.sqlCmdSetProdClientesCOM.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sIdProducto", System.Data.SqlDbType.VarChar, 10));
			this.sqlCmdSetProdClientesCOM.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iPrioridad", System.Data.SqlDbType.SmallInt, 2));
			// 
			// pnCliente
			// 
			this.pnCliente.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.pnCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnCliente.Controls.Add(this.lblTitulo);
			this.pnCliente.Controls.Add(this.txtEstadoCli_COM);
			this.pnCliente.Controls.Add(this.txtTipoCliente_COM);
			this.pnCliente.Controls.Add(this.txtNumColegiado_COM);
			this.pnCliente.Controls.Add(this.txtProvincia_COM);
			this.pnCliente.Controls.Add(this.label36);
			this.pnCliente.Controls.Add(this.label22);
			this.pnCliente.Controls.Add(this.label21);
			this.pnCliente.Controls.Add(this.txtDatosFinancieros_COM);
			this.pnCliente.Controls.Add(this.txtNIF_COM);
			this.pnCliente.Controls.Add(this.txtTipo_COM);
			this.pnCliente.Controls.Add(this.label20);
			this.pnCliente.Controls.Add(this.txtPoblacion_COM);
			this.pnCliente.Controls.Add(this.txtCategoria_COM);
			this.pnCliente.Controls.Add(this.txtCP_COM);
			this.pnCliente.Controls.Add(this.txtDireccion_COM);
			this.pnCliente.Controls.Add(this.txtNombre_COM);
			this.pnCliente.Controls.Add(this.txtsIdCliente_COM);
			this.pnCliente.Controls.Add(this.label24);
			this.pnCliente.Controls.Add(this.label25);
			this.pnCliente.Controls.Add(this.label26);
			this.pnCliente.Controls.Add(this.label27);
			this.pnCliente.Controls.Add(this.label28);
			this.pnCliente.Controls.Add(this.label29);
			this.pnCliente.Controls.Add(this.label30);
			this.pnCliente.Controls.Add(this.label31);
			this.pnCliente.Controls.Add(this.label35);
			this.pnCliente.Location = new System.Drawing.Point(1, 40);
			this.pnCliente.Name = "pnCliente";
			this.pnCliente.Size = new System.Drawing.Size(934, 118);
			this.pnCliente.TabIndex = 0;
			// 
			// lblTitulo
			// 
			this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
			this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblTitulo.ForeColor = System.Drawing.Color.White;
			this.lblTitulo.GradientColorOne = System.Drawing.Color.FromArgb(((System.Byte)(18)), ((System.Byte)(84)), ((System.Byte)(132)));
			this.lblTitulo.GradientColorTwo = System.Drawing.Color.White;
			this.lblTitulo.Location = new System.Drawing.Point(0, 0);
			this.lblTitulo.Name = "lblTitulo";
			this.lblTitulo.Size = new System.Drawing.Size(932, 22);
			this.lblTitulo.TabIndex = 102;
			this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtEstadoCli_COM
			// 
			this.txtEstadoCli_COM.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(238)), ((System.Byte)(243)), ((System.Byte)(246)));
			this.txtEstadoCli_COM.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsClientes1, "GetCliente_COM.tIdEstadoCliCom_COM"));
			this.txtEstadoCli_COM.Location = new System.Drawing.Point(496, 52);
			this.txtEstadoCli_COM.Name = "txtEstadoCli_COM";
			this.txtEstadoCli_COM.ReadOnly = true;
			this.txtEstadoCli_COM.Size = new System.Drawing.Size(170, 20);
			this.txtEstadoCli_COM.TabIndex = 5;
			this.txtEstadoCli_COM.TabStop = false;
			this.txtEstadoCli_COM.Text = "";
			// 
			// dsClientes1
			// 
			this.dsClientes1.DataSetName = "dsClientes";
			this.dsClientes1.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// txtTipoCliente_COM
			// 
			this.txtTipoCliente_COM.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(238)), ((System.Byte)(243)), ((System.Byte)(246)));
			this.txtTipoCliente_COM.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsClientes1, "GetCliente_COM.tTipoCliente_COM"));
			this.txtTipoCliente_COM.Location = new System.Drawing.Point(496, 72);
			this.txtTipoCliente_COM.Name = "txtTipoCliente_COM";
			this.txtTipoCliente_COM.ReadOnly = true;
			this.txtTipoCliente_COM.Size = new System.Drawing.Size(170, 20);
			this.txtTipoCliente_COM.TabIndex = 7;
			this.txtTipoCliente_COM.TabStop = false;
			this.txtTipoCliente_COM.Text = "";
			// 
			// txtNumColegiado_COM
			// 
			this.txtNumColegiado_COM.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(238)), ((System.Byte)(243)), ((System.Byte)(246)));
			this.txtNumColegiado_COM.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsClientes1, "GetCliente_COM.sNumColegiado_COM"));
			this.txtNumColegiado_COM.Location = new System.Drawing.Point(496, 32);
			this.txtNumColegiado_COM.Name = "txtNumColegiado_COM";
			this.txtNumColegiado_COM.ReadOnly = true;
			this.txtNumColegiado_COM.Size = new System.Drawing.Size(130, 20);
			this.txtNumColegiado_COM.TabIndex = 3;
			this.txtNumColegiado_COM.TabStop = false;
			this.txtNumColegiado_COM.Text = "";
			// 
			// txtProvincia_COM
			// 
			this.txtProvincia_COM.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(238)), ((System.Byte)(243)), ((System.Byte)(246)));
			this.txtProvincia_COM.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsClientes1, "GetCliente_COM.sProvincia"));
			this.txtProvincia_COM.Location = new System.Drawing.Point(496, 92);
			this.txtProvincia_COM.Name = "txtProvincia_COM";
			this.txtProvincia_COM.ReadOnly = true;
			this.txtProvincia_COM.Size = new System.Drawing.Size(170, 20);
			this.txtProvincia_COM.TabIndex = 10;
			this.txtProvincia_COM.TabStop = false;
			this.txtProvincia_COM.Text = "";
			// 
			// label36
			// 
			this.label36.Location = new System.Drawing.Point(424, 56);
			this.label36.Name = "label36";
			this.label36.Size = new System.Drawing.Size(90, 18);
			this.label36.TabIndex = 101;
			this.label36.Text = "Estado:";
			this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label22
			// 
			this.label22.Location = new System.Drawing.Point(424, 72);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(90, 18);
			this.label22.TabIndex = 99;
			this.label22.Text = "Clase Cliente:";
			this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label21
			// 
			this.label21.Location = new System.Drawing.Point(424, 32);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(90, 18);
			this.label21.TabIndex = 97;
			this.label21.Text = "N. Colegiado:";
			this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtDatosFinancieros_COM
			// 
			this.txtDatosFinancieros_COM.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(238)), ((System.Byte)(243)), ((System.Byte)(246)));
			this.txtDatosFinancieros_COM.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsClientes1, "GetCliente_COM.tDatosFinacieros_COM"));
			this.txtDatosFinancieros_COM.Location = new System.Drawing.Point(672, 72);
			this.txtDatosFinancieros_COM.Multiline = true;
			this.txtDatosFinancieros_COM.Name = "txtDatosFinancieros_COM";
			this.txtDatosFinancieros_COM.ReadOnly = true;
			this.txtDatosFinancieros_COM.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtDatosFinancieros_COM.Size = new System.Drawing.Size(256, 40);
			this.txtDatosFinancieros_COM.TabIndex = 12;
			this.txtDatosFinancieros_COM.TabStop = false;
			this.txtDatosFinancieros_COM.Text = "";
			// 
			// txtNIF_COM
			// 
			this.txtNIF_COM.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(238)), ((System.Byte)(243)), ((System.Byte)(246)));
			this.txtNIF_COM.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsClientes1, "GetCliente_COM.sNIF_COM"));
			this.txtNIF_COM.Location = new System.Drawing.Point(704, 32);
			this.txtNIF_COM.Name = "txtNIF_COM";
			this.txtNIF_COM.ReadOnly = true;
			this.txtNIF_COM.Size = new System.Drawing.Size(130, 20);
			this.txtNIF_COM.TabIndex = 11;
			this.txtNIF_COM.TabStop = false;
			this.txtNIF_COM.Text = "";
			// 
			// txtTipo_COM
			// 
			this.txtTipo_COM.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(238)), ((System.Byte)(243)), ((System.Byte)(246)));
			this.txtTipo_COM.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsClientes1, "GetCliente_COM.tTipoCliente"));
			this.txtTipo_COM.Location = new System.Drawing.Point(200, 32);
			this.txtTipo_COM.Name = "txtTipo_COM";
			this.txtTipo_COM.ReadOnly = true;
			this.txtTipo_COM.TabIndex = 1;
			this.txtTipo_COM.TabStop = false;
			this.txtTipo_COM.Text = "";
			// 
			// label20
			// 
			this.label20.Location = new System.Drawing.Point(168, 32);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(30, 18);
			this.label20.TabIndex = 93;
			this.label20.Text = "Tipo:";
			this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtPoblacion_COM
			// 
			this.txtPoblacion_COM.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(238)), ((System.Byte)(243)), ((System.Byte)(246)));
			this.txtPoblacion_COM.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsClientes1, "GetCliente_COM.sPoblacion"));
			this.txtPoblacion_COM.Location = new System.Drawing.Point(168, 92);
			this.txtPoblacion_COM.Name = "txtPoblacion_COM";
			this.txtPoblacion_COM.ReadOnly = true;
			this.txtPoblacion_COM.Size = new System.Drawing.Size(250, 20);
			this.txtPoblacion_COM.TabIndex = 9;
			this.txtPoblacion_COM.TabStop = false;
			this.txtPoblacion_COM.Text = "";
			// 
			// txtCategoria_COM
			// 
			this.txtCategoria_COM.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(238)), ((System.Byte)(243)), ((System.Byte)(246)));
			this.txtCategoria_COM.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsClientes1, "GetCliente_COM.tTipoClasificacion"));
			this.txtCategoria_COM.Location = new System.Drawing.Point(376, 32);
			this.txtCategoria_COM.Name = "txtCategoria_COM";
			this.txtCategoria_COM.ReadOnly = true;
			this.txtCategoria_COM.Size = new System.Drawing.Size(30, 20);
			this.txtCategoria_COM.TabIndex = 2;
			this.txtCategoria_COM.TabStop = false;
			this.txtCategoria_COM.Text = "";
			// 
			// txtCP_COM
			// 
			this.txtCP_COM.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(238)), ((System.Byte)(243)), ((System.Byte)(246)));
			this.txtCP_COM.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsClientes1, "GetCliente_COM.CodPostal"));
			this.txtCP_COM.Location = new System.Drawing.Point(64, 92);
			this.txtCP_COM.Name = "txtCP_COM";
			this.txtCP_COM.ReadOnly = true;
			this.txtCP_COM.Size = new System.Drawing.Size(50, 20);
			this.txtCP_COM.TabIndex = 8;
			this.txtCP_COM.TabStop = false;
			this.txtCP_COM.Text = "";
			// 
			// txtDireccion_COM
			// 
			this.txtDireccion_COM.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(238)), ((System.Byte)(243)), ((System.Byte)(246)));
			this.txtDireccion_COM.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsClientes1, "GetCliente_COM.sDireccion_COM"));
			this.txtDireccion_COM.Location = new System.Drawing.Point(64, 72);
			this.txtDireccion_COM.Name = "txtDireccion_COM";
			this.txtDireccion_COM.ReadOnly = true;
			this.txtDireccion_COM.Size = new System.Drawing.Size(354, 20);
			this.txtDireccion_COM.TabIndex = 6;
			this.txtDireccion_COM.TabStop = false;
			this.txtDireccion_COM.Text = "";
			// 
			// txtNombre_COM
			// 
			this.txtNombre_COM.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(238)), ((System.Byte)(243)), ((System.Byte)(246)));
			this.txtNombre_COM.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsClientes1, "GetCliente_COM.tNombre"));
			this.txtNombre_COM.Location = new System.Drawing.Point(64, 52);
			this.txtNombre_COM.Name = "txtNombre_COM";
			this.txtNombre_COM.ReadOnly = true;
			this.txtNombre_COM.Size = new System.Drawing.Size(354, 20);
			this.txtNombre_COM.TabIndex = 4;
			this.txtNombre_COM.TabStop = false;
			this.txtNombre_COM.Text = "";
			// 
			// txtsIdCliente_COM
			// 
			this.txtsIdCliente_COM.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(238)), ((System.Byte)(243)), ((System.Byte)(246)));
			this.txtsIdCliente_COM.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsClientes1, "GetCliente_COM.sIdCliente"));
			this.txtsIdCliente_COM.Location = new System.Drawing.Point(64, 32);
			this.txtsIdCliente_COM.Name = "txtsIdCliente_COM";
			this.txtsIdCliente_COM.ReadOnly = true;
			this.txtsIdCliente_COM.TabIndex = 0;
			this.txtsIdCliente_COM.TabStop = false;
			this.txtsIdCliente_COM.Text = "";
			// 
			// label24
			// 
			this.label24.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label24.Location = new System.Drawing.Point(312, 32);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(60, 18);
			this.label24.TabIndex = 80;
			this.label24.Text = "Categoría:";
			// 
			// label25
			// 
			this.label25.Location = new System.Drawing.Point(112, 96);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(57, 18);
			this.label25.TabIndex = 79;
			this.label25.Text = "Población:";
			this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label26
			// 
			this.label26.Location = new System.Drawing.Point(0, 74);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(67, 18);
			this.label26.TabIndex = 77;
			this.label26.Text = "Dirección:";
			this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label27
			// 
			this.label27.Location = new System.Drawing.Point(424, 94);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(67, 18);
			this.label27.TabIndex = 76;
			this.label27.Text = "Provincia:";
			this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label28
			// 
			this.label28.Location = new System.Drawing.Point(672, 32);
			this.label28.Name = "label28";
			this.label28.Size = new System.Drawing.Size(90, 18);
			this.label28.TabIndex = 74;
			this.label28.Text = "NIF:";
			this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label29
			// 
			this.label29.Location = new System.Drawing.Point(0, 56);
			this.label29.Name = "label29";
			this.label29.Size = new System.Drawing.Size(67, 18);
			this.label29.TabIndex = 71;
			this.label29.Text = "Nombre:";
			this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label30
			// 
			this.label30.Location = new System.Drawing.Point(0, 32);
			this.label30.Name = "label30";
			this.label30.Size = new System.Drawing.Size(67, 18);
			this.label30.TabIndex = 70;
			this.label30.Text = "Cód.Cliente:";
			this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label31
			// 
			this.label31.Location = new System.Drawing.Point(0, 96);
			this.label31.Name = "label31";
			this.label31.Size = new System.Drawing.Size(67, 18);
			this.label31.TabIndex = 78;
			this.label31.Text = "C.P.:";
			this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label35
			// 
			this.label35.Location = new System.Drawing.Point(672, 56);
			this.label35.Name = "label35";
			this.label35.Size = new System.Drawing.Size(104, 18);
			this.label35.TabIndex = 73;
			this.label35.Text = "Datos Bancarios:";
			this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtEMail_COM
			// 
			this.txtEMail_COM.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(238)), ((System.Byte)(243)), ((System.Byte)(246)));
			this.txtEMail_COM.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsClientes1, "GetCliente_COM.sEmail_COM"));
			this.txtEMail_COM.Location = new System.Drawing.Point(64, 68);
			this.txtEMail_COM.Name = "txtEMail_COM";
			this.txtEMail_COM.ReadOnly = true;
			this.txtEMail_COM.Size = new System.Drawing.Size(130, 20);
			this.txtEMail_COM.TabIndex = 10;
			this.txtEMail_COM.TabStop = false;
			this.txtEMail_COM.Text = "";
			// 
			// txtFax_COM
			// 
			this.txtFax_COM.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(238)), ((System.Byte)(243)), ((System.Byte)(246)));
			this.txtFax_COM.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsClientes1, "GetCliente_COM.sFax_COM"));
			this.txtFax_COM.Location = new System.Drawing.Point(64, 48);
			this.txtFax_COM.Name = "txtFax_COM";
			this.txtFax_COM.ReadOnly = true;
			this.txtFax_COM.Size = new System.Drawing.Size(130, 20);
			this.txtFax_COM.TabIndex = 8;
			this.txtFax_COM.TabStop = false;
			this.txtFax_COM.Text = "";
			// 
			// label23
			// 
			this.label23.Location = new System.Drawing.Point(8, 70);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(50, 18);
			this.label23.TabIndex = 90;
			this.label23.Text = "EMail:";
			// 
			// txtTelMovil_COM
			// 
			this.txtTelMovil_COM.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(238)), ((System.Byte)(243)), ((System.Byte)(246)));
			this.txtTelMovil_COM.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsClientes1, "GetCliente_COM.sTelMovil_COM"));
			this.txtTelMovil_COM.Location = new System.Drawing.Point(64, 28);
			this.txtTelMovil_COM.Name = "txtTelMovil_COM";
			this.txtTelMovil_COM.ReadOnly = true;
			this.txtTelMovil_COM.Size = new System.Drawing.Size(130, 20);
			this.txtTelMovil_COM.TabIndex = 4;
			this.txtTelMovil_COM.TabStop = false;
			this.txtTelMovil_COM.Text = "";
			// 
			// txtTelefono_COM
			// 
			this.txtTelefono_COM.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(238)), ((System.Byte)(243)), ((System.Byte)(246)));
			this.txtTelefono_COM.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsClientes1, "GetCliente_COM.sTelefono"));
			this.txtTelefono_COM.Location = new System.Drawing.Point(64, 8);
			this.txtTelefono_COM.Name = "txtTelefono_COM";
			this.txtTelefono_COM.ReadOnly = true;
			this.txtTelefono_COM.Size = new System.Drawing.Size(130, 20);
			this.txtTelefono_COM.TabIndex = 0;
			this.txtTelefono_COM.TabStop = false;
			this.txtTelefono_COM.Text = "";
			// 
			// label32
			// 
			this.label32.Location = new System.Drawing.Point(8, 10);
			this.label32.Name = "label32";
			this.label32.Size = new System.Drawing.Size(67, 18);
			this.label32.TabIndex = 72;
			this.label32.Text = "Teléfono:";
			this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label33
			// 
			this.label33.Location = new System.Drawing.Point(8, 30);
			this.label33.Name = "label33";
			this.label33.Size = new System.Drawing.Size(67, 18);
			this.label33.TabIndex = 69;
			this.label33.Text = "Tel. Móvil:";
			this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label34
			// 
			this.label34.Location = new System.Drawing.Point(8, 50);
			this.label34.Name = "label34";
			this.label34.Size = new System.Drawing.Size(50, 18);
			this.label34.TabIndex = 75;
			this.label34.Text = "Fax:";
			// 
			// pnAmpliacion
			// 
			this.pnAmpliacion.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.pnAmpliacion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pnAmpliacion.Controls.Add(this.panel9);
			this.pnAmpliacion.Controls.Add(this.panel10);
			this.pnAmpliacion.Controls.Add(this.btEliminarAfic);
			this.pnAmpliacion.Controls.Add(this.btActualizarAfic);
			this.pnAmpliacion.Controls.Add(this.txtPolGen_COM);
			this.pnAmpliacion.Controls.Add(this.txtObservaciones_COM);
			this.pnAmpliacion.Controls.Add(this.txtFecAniv_COM);
			this.pnAmpliacion.Controls.Add(this.txtFecNacim_COM);
			this.pnAmpliacion.Controls.Add(this.txtIdioma2_COM);
			this.pnAmpliacion.Controls.Add(this.txtIdioma1_COM);
			this.pnAmpliacion.Controls.Add(this.txtEstadoCivil_COM);
			this.pnAmpliacion.Controls.Add(this.txttIdCaracteristica_COM);
			this.pnAmpliacion.Controls.Add(this.label47);
			this.pnAmpliacion.Controls.Add(this.label44);
			this.pnAmpliacion.Controls.Add(this.label43);
			this.pnAmpliacion.Controls.Add(this.label42);
			this.pnAmpliacion.Controls.Add(this.label40);
			this.pnAmpliacion.Controls.Add(this.label38);
			this.pnAmpliacion.Controls.Add(this.label37);
			this.pnAmpliacion.Controls.Add(this.label39);
			this.pnAmpliacion.Controls.Add(this.txtEMail_COM);
			this.pnAmpliacion.Controls.Add(this.txtFax_COM);
			this.pnAmpliacion.Controls.Add(this.txtTelMovil_COM);
			this.pnAmpliacion.Controls.Add(this.txtTelefono_COM);
			this.pnAmpliacion.Controls.Add(this.label32);
			this.pnAmpliacion.Controls.Add(this.label33);
			this.pnAmpliacion.Controls.Add(this.label34);
			this.pnAmpliacion.Controls.Add(this.label23);
			this.pnAmpliacion.Location = new System.Drawing.Point(1, 187);
			this.pnAmpliacion.Name = "pnAmpliacion";
			this.pnAmpliacion.Size = new System.Drawing.Size(934, 475);
			this.pnAmpliacion.TabIndex = 12;
			// 
			// panel9
			// 
			this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel9.Controls.Add(this.lblTotAficiones);
			this.panel9.Controls.Add(this.labelGradient5);
			this.panel9.Controls.Add(this.dgAficiones);
			this.panel9.Location = new System.Drawing.Point(424, 112);
			this.panel9.Name = "panel9";
			this.panel9.Size = new System.Drawing.Size(456, 288);
			this.panel9.TabIndex = 12;
			// 
			// lblTotAficiones
			// 
			this.lblTotAficiones.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(238)), ((System.Byte)(243)), ((System.Byte)(246)));
			this.lblTotAficiones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblTotAficiones.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblTotAficiones.ForeColor = System.Drawing.Color.Black;
			this.lblTotAficiones.Location = new System.Drawing.Point(391, 0);
			this.lblTotAficiones.Name = "lblTotAficiones";
			this.lblTotAficiones.Size = new System.Drawing.Size(60, 18);
			this.lblTotAficiones.TabIndex = 9;
			this.lblTotAficiones.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelGradient5
			// 
			this.labelGradient5.Dock = System.Windows.Forms.DockStyle.Top;
			this.labelGradient5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.labelGradient5.ForeColor = System.Drawing.Color.White;
			this.labelGradient5.GradientColorOne = System.Drawing.Color.FromArgb(((System.Byte)(18)), ((System.Byte)(84)), ((System.Byte)(132)));
			this.labelGradient5.GradientColorTwo = System.Drawing.Color.White;
			this.labelGradient5.Location = new System.Drawing.Point(0, 0);
			this.labelGradient5.Name = "labelGradient5";
			this.labelGradient5.Size = new System.Drawing.Size(452, 18);
			this.labelGradient5.TabIndex = 0;
			this.labelGradient5.Text = "Aficiones";
			this.labelGradient5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// dgAficiones
			// 
			this.dgAficiones.CaptionVisible = false;
			this.dgAficiones.DataMember = "ListaAficClientes_COM";
			this.dgAficiones.DataSource = this.dsClientes1;
			this.dgAficiones.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgAficiones.Location = new System.Drawing.Point(-2, 18);
			this.dgAficiones.Name = "dgAficiones";
			this.dgAficiones.ReadOnly = true;
			this.dgAficiones.RowHeaderWidth = 17;
			this.dgAficiones.Size = new System.Drawing.Size(455, 268);
			this.dgAficiones.TabIndex = 0;
			this.dgAficiones.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																									this.dataGridTableStyle5});
			this.dgAficiones.CurrentCellChanged += new System.EventHandler(this.dgAficiones_CurrentCellChanged);
			// 
			// dataGridTableStyle5
			// 
			this.dataGridTableStyle5.DataGrid = this.dgAficiones;
			this.dataGridTableStyle5.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.dataGridTextBoxColumn24,
																												  this.dataGridTextBoxColumn25});
			this.dataGridTableStyle5.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle5.MappingName = "ListaAficClientes_COM";
			this.dataGridTableStyle5.RowHeaderWidth = 17;
			// 
			// dataGridTextBoxColumn24
			// 
			this.dataGridTextBoxColumn24.Format = "";
			this.dataGridTextBoxColumn24.FormatInfo = null;
			this.dataGridTextBoxColumn24.HeaderText = "Afición";
			this.dataGridTextBoxColumn24.MappingName = "tAficion";
			this.dataGridTextBoxColumn24.NullText = "";
			this.dataGridTextBoxColumn24.Width = 400;
			// 
			// dataGridTextBoxColumn25
			// 
			this.dataGridTextBoxColumn25.Format = "";
			this.dataGridTextBoxColumn25.FormatInfo = null;
			this.dataGridTextBoxColumn25.MappingName = "sIdAficion";
			this.dataGridTextBoxColumn25.NullText = "";
			this.dataGridTextBoxColumn25.Width = 0;
			// 
			// panel10
			// 
			this.panel10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel10.Controls.Add(this.cbAficiones);
			this.panel10.Controls.Add(this.label19);
			this.panel10.Location = new System.Drawing.Point(424, 426);
			this.panel10.Name = "panel10";
			this.panel10.Size = new System.Drawing.Size(456, 40);
			this.panel10.TabIndex = 13;
			// 
			// cbAficiones
			// 
			this.cbAficiones.DataSource = this.dsClientes1.ListaTipoAficiones;
			this.cbAficiones.DisplayMember = "sLiteral";
			this.cbAficiones.Location = new System.Drawing.Point(8, 16);
			this.cbAficiones.Name = "cbAficiones";
			this.cbAficiones.Size = new System.Drawing.Size(272, 21);
			this.cbAficiones.TabIndex = 0;
			this.cbAficiones.ValueMember = "sValor";
			// 
			// label19
			// 
			this.label19.Location = new System.Drawing.Point(8, 0);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(72, 18);
			this.label19.TabIndex = 6;
			this.label19.Text = "Afición:";
			this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btEliminarAfic
			// 
			this.btEliminarAfic.Image = ((System.Drawing.Image)(resources.GetObject("btEliminarAfic.Image")));
			this.btEliminarAfic.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btEliminarAfic.Location = new System.Drawing.Point(504, 403);
			this.btEliminarAfic.Name = "btEliminarAfic";
			this.btEliminarAfic.TabIndex = 15;
			this.btEliminarAfic.Text = "Elimina&r";
			this.btEliminarAfic.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.toolTip1.SetToolTip(this.btEliminarAfic, "Eliminar Afición ALT+R");
			this.btEliminarAfic.Click += new System.EventHandler(this.btEliminarAfic_Click);
			// 
			// btActualizarAfic
			// 
			this.btActualizarAfic.Image = ((System.Drawing.Image)(resources.GetObject("btActualizarAfic.Image")));
			this.btActualizarAfic.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btActualizarAfic.Location = new System.Drawing.Point(424, 403);
			this.btActualizarAfic.Name = "btActualizarAfic";
			this.btActualizarAfic.Size = new System.Drawing.Size(80, 23);
			this.btActualizarAfic.TabIndex = 14;
			this.btActualizarAfic.Text = "Actuali&zar";
			this.btActualizarAfic.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.toolTip1.SetToolTip(this.btActualizarAfic, "Actualizar Afición ALT+Z");
			this.btActualizarAfic.Click += new System.EventHandler(this.btActualizarAfic_Click);
			// 
			// txtPolGen_COM
			// 
			this.txtPolGen_COM.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(238)), ((System.Byte)(243)), ((System.Byte)(246)));
			this.txtPolGen_COM.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsClientes1, "GetCliente_COM.tIdPolGenericos_COM"));
			this.txtPolGen_COM.Location = new System.Drawing.Point(280, 28);
			this.txtPolGen_COM.Name = "txtPolGen_COM";
			this.txtPolGen_COM.ReadOnly = true;
			this.txtPolGen_COM.Size = new System.Drawing.Size(200, 20);
			this.txtPolGen_COM.TabIndex = 9;
			this.txtPolGen_COM.TabStop = false;
			this.txtPolGen_COM.Text = "";
			// 
			// txtObservaciones_COM
			// 
			this.txtObservaciones_COM.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(238)), ((System.Byte)(243)), ((System.Byte)(246)));
			this.txtObservaciones_COM.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsClientes1, "GetCliente_COM.tObservaciones_COM"));
			this.txtObservaciones_COM.Location = new System.Drawing.Point(8, 112);
			this.txtObservaciones_COM.Multiline = true;
			this.txtObservaciones_COM.Name = "txtObservaciones_COM";
			this.txtObservaciones_COM.ReadOnly = true;
			this.txtObservaciones_COM.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtObservaciones_COM.Size = new System.Drawing.Size(360, 355);
			this.txtObservaciones_COM.TabIndex = 11;
			this.txtObservaciones_COM.TabStop = false;
			this.txtObservaciones_COM.Text = "";
			// 
			// txtFecAniv_COM
			// 
			this.txtFecAniv_COM.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(238)), ((System.Byte)(243)), ((System.Byte)(246)));
			this.txtFecAniv_COM.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsClientes1, "GetCliente_COM.dFecAniversario_COM"));
			this.txtFecAniv_COM.Location = new System.Drawing.Point(816, 28);
			this.txtFecAniv_COM.Name = "txtFecAniv_COM";
			this.txtFecAniv_COM.ReadOnly = true;
			this.txtFecAniv_COM.TabIndex = 7;
			this.txtFecAniv_COM.TabStop = false;
			this.txtFecAniv_COM.Text = "";
			// 
			// txtFecNacim_COM
			// 
			this.txtFecNacim_COM.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(238)), ((System.Byte)(243)), ((System.Byte)(246)));
			this.txtFecNacim_COM.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsClientes1, "GetCliente_COM.dFecNacimiento_COM"));
			this.txtFecNacim_COM.Location = new System.Drawing.Point(816, 8);
			this.txtFecNacim_COM.Name = "txtFecNacim_COM";
			this.txtFecNacim_COM.ReadOnly = true;
			this.txtFecNacim_COM.TabIndex = 3;
			this.txtFecNacim_COM.TabStop = false;
			this.txtFecNacim_COM.Text = "";
			// 
			// txtIdioma2_COM
			// 
			this.txtIdioma2_COM.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(238)), ((System.Byte)(243)), ((System.Byte)(246)));
			this.txtIdioma2_COM.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsClientes1, "GetCliente_COM.tIdioma2_COM"));
			this.txtIdioma2_COM.Location = new System.Drawing.Point(536, 28);
			this.txtIdioma2_COM.Name = "txtIdioma2_COM";
			this.txtIdioma2_COM.ReadOnly = true;
			this.txtIdioma2_COM.Size = new System.Drawing.Size(200, 20);
			this.txtIdioma2_COM.TabIndex = 6;
			this.txtIdioma2_COM.TabStop = false;
			this.txtIdioma2_COM.Text = "";
			// 
			// txtIdioma1_COM
			// 
			this.txtIdioma1_COM.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(238)), ((System.Byte)(243)), ((System.Byte)(246)));
			this.txtIdioma1_COM.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsClientes1, "GetCliente_COM.tIdioma1_COM"));
			this.txtIdioma1_COM.Location = new System.Drawing.Point(536, 8);
			this.txtIdioma1_COM.Name = "txtIdioma1_COM";
			this.txtIdioma1_COM.ReadOnly = true;
			this.txtIdioma1_COM.Size = new System.Drawing.Size(200, 20);
			this.txtIdioma1_COM.TabIndex = 2;
			this.txtIdioma1_COM.TabStop = false;
			this.txtIdioma1_COM.Text = "";
			// 
			// txtEstadoCivil_COM
			// 
			this.txtEstadoCivil_COM.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(238)), ((System.Byte)(243)), ((System.Byte)(246)));
			this.txtEstadoCivil_COM.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsClientes1, "GetCliente_COM.tEstadoCivil_COM"));
			this.txtEstadoCivil_COM.Location = new System.Drawing.Point(280, 8);
			this.txtEstadoCivil_COM.Name = "txtEstadoCivil_COM";
			this.txtEstadoCivil_COM.ReadOnly = true;
			this.txtEstadoCivil_COM.Size = new System.Drawing.Size(200, 20);
			this.txtEstadoCivil_COM.TabIndex = 5;
			this.txtEstadoCivil_COM.TabStop = false;
			this.txtEstadoCivil_COM.Text = "";
			// 
			// txttIdCaracteristica_COM
			// 
			this.txttIdCaracteristica_COM.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(238)), ((System.Byte)(243)), ((System.Byte)(246)));
			this.txttIdCaracteristica_COM.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsClientes1, "GetCliente_COM.tIdCaracteristica_COM"));
			this.txttIdCaracteristica_COM.Location = new System.Drawing.Point(568, 72);
			this.txttIdCaracteristica_COM.Name = "txttIdCaracteristica_COM";
			this.txttIdCaracteristica_COM.ReadOnly = true;
			this.txttIdCaracteristica_COM.Size = new System.Drawing.Size(200, 20);
			this.txttIdCaracteristica_COM.TabIndex = 1;
			this.txttIdCaracteristica_COM.TabStop = false;
			this.txttIdCaracteristica_COM.Text = "";
			this.txttIdCaracteristica_COM.Visible = false;
			// 
			// label47
			// 
			this.label47.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label47.Location = new System.Drawing.Point(208, 30);
			this.label47.Name = "label47";
			this.label47.Size = new System.Drawing.Size(85, 18);
			this.label47.TabIndex = 33;
			this.label47.Text = "Pol. Genéricos:";
			this.label47.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label44
			// 
			this.label44.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label44.Location = new System.Drawing.Point(208, 10);
			this.label44.Name = "label44";
			this.label44.Size = new System.Drawing.Size(85, 18);
			this.label44.TabIndex = 30;
			this.label44.Text = "Estado Civil:";
			this.label44.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label43
			// 
			this.label43.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label43.Location = new System.Drawing.Point(744, 30);
			this.label43.Name = "label43";
			this.label43.Size = new System.Drawing.Size(85, 18);
			this.label43.TabIndex = 29;
			this.label43.Text = "F.Aniversario:";
			this.label43.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label42
			// 
			this.label42.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label42.Location = new System.Drawing.Point(488, 10);
			this.label42.Name = "label42";
			this.label42.Size = new System.Drawing.Size(85, 18);
			this.label42.TabIndex = 28;
			this.label42.Text = "Idioma1:";
			this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label40
			// 
			this.label40.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label40.Location = new System.Drawing.Point(8, 96);
			this.label40.Name = "label40";
			this.label40.Size = new System.Drawing.Size(95, 18);
			this.label40.TabIndex = 26;
			this.label40.Text = "Observaciones:";
			this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label38
			// 
			this.label38.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label38.Location = new System.Drawing.Point(744, 10);
			this.label38.Name = "label38";
			this.label38.Size = new System.Drawing.Size(85, 18);
			this.label38.TabIndex = 25;
			this.label38.Text = "F.Nacimiento:";
			this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label37
			// 
			this.label37.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label37.Location = new System.Drawing.Point(496, 72);
			this.label37.Name = "label37";
			this.label37.Size = new System.Drawing.Size(85, 18);
			this.label37.TabIndex = 24;
			this.label37.Text = "Característica:";
			this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label37.Visible = false;
			// 
			// label39
			// 
			this.label39.Location = new System.Drawing.Point(488, 30);
			this.label39.Name = "label39";
			this.label39.Size = new System.Drawing.Size(85, 18);
			this.label39.TabIndex = 41;
			this.label39.Text = "Idioma2:";
			this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btAmpliacion
			// 
			this.btAmpliacion.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.btAmpliacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btAmpliacion.Location = new System.Drawing.Point(228, 165);
			this.btAmpliacion.Name = "btAmpliacion";
			this.btAmpliacion.Size = new System.Drawing.Size(144, 23);
			this.btAmpliacion.TabIndex = 3;
			this.btAmpliacion.Text = "&3 - Ampliación Cliente";
			this.btAmpliacion.Click += new System.EventHandler(this.btAmpliacion_Click);
			// 
			// btCRM
			// 
			this.btCRM.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.btCRM.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btCRM.Location = new System.Drawing.Point(4, 165);
			this.btCRM.Name = "btCRM";
			this.btCRM.Size = new System.Drawing.Size(80, 23);
			this.btCRM.TabIndex = 1;
			this.btCRM.Text = "&1 - CRM";
			this.btCRM.Click += new System.EventHandler(this.btCentros_Click);
			// 
			// btAccionesMark
			// 
			this.btAccionesMark.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.btAccionesMark.Location = new System.Drawing.Point(84, 165);
			this.btAccionesMark.Name = "btAccionesMark";
			this.btAccionesMark.Size = new System.Drawing.Size(144, 23);
			this.btAccionesMark.TabIndex = 2;
			this.btAccionesMark.Text = " &2 - Acciones Marketing";
			this.btAccionesMark.Click += new System.EventHandler(this.btAccionesMark_Click);
			// 
			// lblTotEspecialidades
			// 
			this.lblTotEspecialidades.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(238)), ((System.Byte)(243)), ((System.Byte)(246)));
			this.lblTotEspecialidades.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblTotEspecialidades.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblTotEspecialidades.ForeColor = System.Drawing.Color.Black;
			this.lblTotEspecialidades.Location = new System.Drawing.Point(320, 0);
			this.lblTotEspecialidades.Name = "lblTotEspecialidades";
			this.lblTotEspecialidades.Size = new System.Drawing.Size(60, 18);
			this.lblTotEspecialidades.TabIndex = 9;
			this.lblTotEspecialidades.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblTotProductos
			// 
			this.lblTotProductos.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(238)), ((System.Byte)(243)), ((System.Byte)(246)));
			this.lblTotProductos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblTotProductos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblTotProductos.ForeColor = System.Drawing.Color.Black;
			this.lblTotProductos.Location = new System.Drawing.Point(470, 0);
			this.lblTotProductos.Name = "lblTotProductos";
			this.lblTotProductos.Size = new System.Drawing.Size(60, 18);
			this.lblTotProductos.TabIndex = 8;
			this.lblTotProductos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// dgEspecialidades
			// 
			this.dgEspecialidades.CaptionText = "Especialidades";
			this.dgEspecialidades.CaptionVisible = false;
			this.dgEspecialidades.DataMember = "ListaEspecClientes_COM";
			this.dgEspecialidades.DataSource = this.dsClientes1;
			this.dgEspecialidades.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgEspecialidades.Location = new System.Drawing.Point(-2, 18);
			this.dgEspecialidades.Name = "dgEspecialidades";
			this.dgEspecialidades.ReadOnly = true;
			this.dgEspecialidades.RowHeaderWidth = 17;
			this.dgEspecialidades.Size = new System.Drawing.Size(382, 133);
			this.dgEspecialidades.TabIndex = 0;
			this.dgEspecialidades.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																										 this.dataGridTableStyle1});
			this.dgEspecialidades.CurrentCellChanged += new System.EventHandler(this.dgEspecialidades_CurrentCellChanged);
			// 
			// dataGridTableStyle1
			// 
			this.dataGridTableStyle1.DataGrid = this.dgEspecialidades;
			this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.dataGridTextBoxColumn1,
																												  this.dataGridTextBoxColumn5});
			this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle1.MappingName = "ListaEspecClientes_COM";
			this.dataGridTableStyle1.RowHeaderWidth = 17;
			// 
			// dataGridTextBoxColumn1
			// 
			this.dataGridTextBoxColumn1.Format = "";
			this.dataGridTextBoxColumn1.FormatInfo = null;
			this.dataGridTextBoxColumn1.HeaderText = "Especialidad";
			this.dataGridTextBoxColumn1.MappingName = "tEspecialidad";
			this.dataGridTextBoxColumn1.NullText = "";
			this.dataGridTextBoxColumn1.Width = 350;
			// 
			// dataGridTextBoxColumn5
			// 
			this.dataGridTextBoxColumn5.Format = "";
			this.dataGridTextBoxColumn5.FormatInfo = null;
			this.dataGridTextBoxColumn5.MappingName = "sIdEspecialidad";
			this.dataGridTextBoxColumn5.NullText = "";
			this.dataGridTextBoxColumn5.Width = 0;
			// 
			// dgProductos
			// 
			this.dgProductos.CaptionText = "Productos";
			this.dgProductos.CaptionVisible = false;
			this.dgProductos.DataMember = "ListaProdClientes_COM";
			this.dgProductos.DataSource = this.dsClientes1;
			this.dgProductos.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgProductos.Location = new System.Drawing.Point(-2, 18);
			this.dgProductos.Name = "dgProductos";
			this.dgProductos.ReadOnly = true;
			this.dgProductos.RowHeaderWidth = 17;
			this.dgProductos.Size = new System.Drawing.Size(533, 132);
			this.dgProductos.TabIndex = 4;
			this.dgProductos.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																									this.dataGridTableStyle2});
			this.dgProductos.CurrentCellChanged += new System.EventHandler(this.dgProductos_CurrentCellChanged);
			// 
			// dataGridTableStyle2
			// 
			this.dataGridTableStyle2.DataGrid = this.dgProductos;
			this.dataGridTableStyle2.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.dataGridTextBoxColumn2,
																												  this.dataGridTextBoxColumn3,
																												  this.dataGridTextBoxColumn4});
			this.dataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle2.MappingName = "ListaProdClientes_COM";
			this.dataGridTableStyle2.RowHeaderWidth = 17;
			// 
			// dataGridTextBoxColumn2
			// 
			this.dataGridTextBoxColumn2.Format = "";
			this.dataGridTextBoxColumn2.FormatInfo = null;
			this.dataGridTextBoxColumn2.HeaderText = "Prioridad";
			this.dataGridTextBoxColumn2.MappingName = "iPrioridad";
			this.dataGridTextBoxColumn2.NullText = "";
			this.dataGridTextBoxColumn2.ReadOnly = true;
			this.dataGridTextBoxColumn2.Width = 60;
			// 
			// dataGridTextBoxColumn3
			// 
			this.dataGridTextBoxColumn3.Format = "";
			this.dataGridTextBoxColumn3.FormatInfo = null;
			this.dataGridTextBoxColumn3.HeaderText = "Código";
			this.dataGridTextBoxColumn3.MappingName = "sIdProducto";
			this.dataGridTextBoxColumn3.NullText = "";
			this.dataGridTextBoxColumn3.ReadOnly = true;
			this.dataGridTextBoxColumn3.Width = 120;
			// 
			// dataGridTextBoxColumn4
			// 
			this.dataGridTextBoxColumn4.Format = "";
			this.dataGridTextBoxColumn4.FormatInfo = null;
			this.dataGridTextBoxColumn4.HeaderText = "Producto";
			this.dataGridTextBoxColumn4.MappingName = "sDescripcion";
			this.dataGridTextBoxColumn4.NullText = "";
			this.dataGridTextBoxColumn4.ReadOnly = true;
			this.dataGridTextBoxColumn4.Width = 300;
			// 
			// panel3
			// 
			this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel3.Controls.Add(this.txttProducto);
			this.panel3.Controls.Add(this.btBuscarProducto);
			this.panel3.Controls.Add(this.nupPrioridadProd);
			this.panel3.Controls.Add(this.txtProdCodigo);
			this.panel3.Controls.Add(this.label4);
			this.panel3.Controls.Add(this.label3);
			this.panel3.Controls.Add(this.label2);
			this.panel3.Location = new System.Drawing.Point(4, 426);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(532, 40);
			this.panel3.TabIndex = 6;
			// 
			// txttProducto
			// 
			this.txttProducto.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(238)), ((System.Byte)(243)), ((System.Byte)(246)));
			this.txttProducto.ForeColor = System.Drawing.Color.Black;
			this.txttProducto.Location = new System.Drawing.Point(205, 16);
			this.txttProducto.Name = "txttProducto";
			this.txttProducto.ReadOnly = true;
			this.txttProducto.Size = new System.Drawing.Size(296, 20);
			this.txttProducto.TabIndex = 12;
			this.txttProducto.TabStop = false;
			this.txttProducto.Text = "";
			// 
			// btBuscarProducto
			// 
			this.btBuscarProducto.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.btBuscarProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.btBuscarProducto.Image = ((System.Drawing.Image)(resources.GetObject("btBuscarProducto.Image")));
			this.btBuscarProducto.Location = new System.Drawing.Point(184, 16);
			this.btBuscarProducto.Name = "btBuscarProducto";
			this.btBuscarProducto.Size = new System.Drawing.Size(21, 21);
			this.btBuscarProducto.TabIndex = 11;
			this.toolTip1.SetToolTip(this.btBuscarProducto, "Buscar Producto");
			this.btBuscarProducto.Click += new System.EventHandler(this.btBuscarProducto_Click);
			// 
			// nupPrioridadProd
			// 
			this.nupPrioridadProd.Location = new System.Drawing.Point(8, 16);
			this.nupPrioridadProd.Maximum = new System.Decimal(new int[] {
																			 10000,
																			 0,
																			 0,
																			 0});
			this.nupPrioridadProd.Minimum = new System.Decimal(new int[] {
																			 1,
																			 0,
																			 0,
																			 0});
			this.nupPrioridadProd.Name = "nupPrioridadProd";
			this.nupPrioridadProd.Size = new System.Drawing.Size(56, 20);
			this.nupPrioridadProd.TabIndex = 0;
			this.nupPrioridadProd.Value = new System.Decimal(new int[] {
																		   1,
																		   0,
																		   0,
																		   0});
			// 
			// txtProdCodigo
			// 
			this.txtProdCodigo.Location = new System.Drawing.Point(64, 16);
			this.txtProdCodigo.MaxLength = 10;
			this.txtProdCodigo.Name = "txtProdCodigo";
			this.txtProdCodigo.Size = new System.Drawing.Size(120, 20);
			this.txtProdCodigo.TabIndex = 1;
			this.txtProdCodigo.Text = "";
			this.txtProdCodigo.Leave += new System.EventHandler(this.txtProdCodigo_Leave);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(205, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 18);
			this.label4.TabIndex = 5;
			this.label4.Text = "Producto:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(64, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 18);
			this.label3.TabIndex = 4;
			this.label3.Text = "Código:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 18);
			this.label2.TabIndex = 3;
			this.label2.Text = "Prioridad:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btEliminarProd
			// 
			this.btEliminarProd.Image = ((System.Drawing.Image)(resources.GetObject("btEliminarProd.Image")));
			this.btEliminarProd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btEliminarProd.Location = new System.Drawing.Point(84, 403);
			this.btEliminarProd.Name = "btEliminarProd";
			this.btEliminarProd.TabIndex = 8;
			this.btEliminarProd.Text = "E&liminar";
			this.btEliminarProd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.toolTip1.SetToolTip(this.btEliminarProd, "Eliminar Producto ALT+L");
			this.btEliminarProd.Click += new System.EventHandler(this.btEliminarProd_Click);
			// 
			// btActualizarProd
			// 
			this.btActualizarProd.Image = ((System.Drawing.Image)(resources.GetObject("btActualizarProd.Image")));
			this.btActualizarProd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btActualizarProd.Location = new System.Drawing.Point(4, 403);
			this.btActualizarProd.Name = "btActualizarProd";
			this.btActualizarProd.Size = new System.Drawing.Size(80, 23);
			this.btActualizarProd.TabIndex = 7;
			this.btActualizarProd.Text = "A&ctualizar";
			this.btActualizarProd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.toolTip1.SetToolTip(this.btActualizarProd, "Actualizar Productos ALT+C");
			this.btActualizarProd.Click += new System.EventHandler(this.btActualizarProd_Click);
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel1.Controls.Add(this.cbEspecialidades);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Location = new System.Drawing.Point(544, 426);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(288, 40);
			this.panel1.TabIndex = 10;
			// 
			// cbEspecialidades
			// 
			this.cbEspecialidades.DataSource = this.dsClientes1.ListaTipoEspeciadadMed;
			this.cbEspecialidades.DisplayMember = "sLiteral";
			this.cbEspecialidades.Location = new System.Drawing.Point(8, 16);
			this.cbEspecialidades.Name = "cbEspecialidades";
			this.cbEspecialidades.Size = new System.Drawing.Size(272, 21);
			this.cbEspecialidades.TabIndex = 0;
			this.cbEspecialidades.ValueMember = "sValor";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 18);
			this.label1.TabIndex = 6;
			this.label1.Text = "Especialidad:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btEliminarEspec
			// 
			this.btEliminarEspec.Image = ((System.Drawing.Image)(resources.GetObject("btEliminarEspec.Image")));
			this.btEliminarEspec.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btEliminarEspec.Location = new System.Drawing.Point(624, 403);
			this.btEliminarEspec.Name = "btEliminarEspec";
			this.btEliminarEspec.TabIndex = 12;
			this.btEliminarEspec.Text = "El&iminar";
			this.btEliminarEspec.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.toolTip1.SetToolTip(this.btEliminarEspec, "Eliminar Especialidad ALT+I");
			this.btEliminarEspec.Click += new System.EventHandler(this.btEliminarEspec_Click);
			// 
			// btActualizarEspec
			// 
			this.btActualizarEspec.Image = ((System.Drawing.Image)(resources.GetObject("btActualizarEspec.Image")));
			this.btActualizarEspec.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btActualizarEspec.Location = new System.Drawing.Point(544, 403);
			this.btActualizarEspec.Name = "btActualizarEspec";
			this.btActualizarEspec.Size = new System.Drawing.Size(80, 23);
			this.btActualizarEspec.TabIndex = 11;
			this.btActualizarEspec.Text = "Ac&tualizar";
			this.btActualizarEspec.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.toolTip1.SetToolTip(this.btActualizarEspec, "Actualizar Especialidades ALT+T");
			this.btActualizarEspec.Click += new System.EventHandler(this.btActualizarEspec_Click);
			// 
			// pnCRM
			// 
			this.pnCRM.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.pnCRM.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pnCRM.Controls.Add(this.ucUltimasVisitas1);
			this.pnCRM.Controls.Add(this.panel7);
			this.pnCRM.Controls.Add(this.panel6);
			this.pnCRM.Controls.Add(this.panel2);
			this.pnCRM.Controls.Add(this.btEliminarCen);
			this.pnCRM.Controls.Add(this.btActualizarCen);
			this.pnCRM.Controls.Add(this.panel4);
			this.pnCRM.Controls.Add(this.panel1);
			this.pnCRM.Controls.Add(this.btEliminarEspec);
			this.pnCRM.Controls.Add(this.btActualizarEspec);
			this.pnCRM.Controls.Add(this.btEliminarProd);
			this.pnCRM.Controls.Add(this.btActualizarProd);
			this.pnCRM.Controls.Add(this.panel3);
			this.pnCRM.Location = new System.Drawing.Point(4, 680);
			this.pnCRM.Name = "pnCRM";
			this.pnCRM.Size = new System.Drawing.Size(934, 475);
			this.pnCRM.TabIndex = 4;
			// 
			// ucUltimasVisitas1
			// 
			this.ucUltimasVisitas1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.ucUltimasVisitas1.ForeColor = System.Drawing.Color.Black;
			this.ucUltimasVisitas1.Location = new System.Drawing.Point(528, 2);
			this.ucUltimasVisitas1.Name = "ucUltimasVisitas1";
			this.ucUltimasVisitas1.Size = new System.Drawing.Size(400, 135);
			this.ucUltimasVisitas1.TabIndex = 13;
			// 
			// panel7
			// 
			this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel7.Controls.Add(this.lblTotProductos);
			this.panel7.Controls.Add(this.labelGradient2);
			this.panel7.Controls.Add(this.dgProductos);
			this.panel7.Location = new System.Drawing.Point(2, 248);
			this.panel7.Name = "panel7";
			this.panel7.Size = new System.Drawing.Size(534, 152);
			this.panel7.TabIndex = 5;
			// 
			// labelGradient2
			// 
			this.labelGradient2.Dock = System.Windows.Forms.DockStyle.Top;
			this.labelGradient2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.labelGradient2.ForeColor = System.Drawing.Color.White;
			this.labelGradient2.GradientColorOne = System.Drawing.Color.FromArgb(((System.Byte)(18)), ((System.Byte)(84)), ((System.Byte)(132)));
			this.labelGradient2.GradientColorTwo = System.Drawing.Color.White;
			this.labelGradient2.Location = new System.Drawing.Point(0, 0);
			this.labelGradient2.Name = "labelGradient2";
			this.labelGradient2.Size = new System.Drawing.Size(530, 18);
			this.labelGradient2.TabIndex = 0;
			this.labelGradient2.Text = "Productos";
			this.labelGradient2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel6
			// 
			this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel6.Controls.Add(this.dgEspecialidades);
			this.panel6.Controls.Add(this.lblTotEspecialidades);
			this.panel6.Controls.Add(this.labelGradient3);
			this.panel6.Location = new System.Drawing.Point(544, 248);
			this.panel6.Name = "panel6";
			this.panel6.Size = new System.Drawing.Size(384, 152);
			this.panel6.TabIndex = 9;
			// 
			// labelGradient3
			// 
			this.labelGradient3.Dock = System.Windows.Forms.DockStyle.Top;
			this.labelGradient3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.labelGradient3.ForeColor = System.Drawing.Color.White;
			this.labelGradient3.GradientColorOne = System.Drawing.Color.FromArgb(((System.Byte)(18)), ((System.Byte)(84)), ((System.Byte)(132)));
			this.labelGradient3.GradientColorTwo = System.Drawing.Color.White;
			this.labelGradient3.Location = new System.Drawing.Point(0, 0);
			this.labelGradient3.Name = "labelGradient3";
			this.labelGradient3.Size = new System.Drawing.Size(380, 18);
			this.labelGradient3.TabIndex = 0;
			this.labelGradient3.Text = "Especialidades";
			this.labelGradient3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel2
			// 
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel2.Controls.Add(this.dgCentros);
			this.panel2.Controls.Add(this.lblTotCentros);
			this.panel2.Controls.Add(this.labelGradient1);
			this.panel2.Location = new System.Drawing.Point(2, 2);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(520, 145);
			this.panel2.TabIndex = 0;
			// 
			// dgCentros
			// 
			this.dgCentros.CaptionText = "Centros ";
			this.dgCentros.CaptionVisible = false;
			this.dgCentros.DataMember = "";
			this.dgCentros.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgCentros.Location = new System.Drawing.Point(-2, 18);
			this.dgCentros.Name = "dgCentros";
			this.dgCentros.Size = new System.Drawing.Size(519, 125);
			this.dgCentros.TabIndex = 0;
			this.dgCentros.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																								  this.dataGridTableStyle3});
			this.dgCentros.CurrentCellChanged += new System.EventHandler(this.dgCentros_CurrentCellChanged);
			// 
			// dataGridTableStyle3
			// 
			this.dataGridTableStyle3.DataGrid = this.dgCentros;
			this.dataGridTableStyle3.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.dataGridTextBoxColumn10,
																												  this.dataGridTextBoxColumn7,
																												  this.dataGridTextBoxColumn8,
																												  this.dataGridTextBoxColumn9,
																												  this.dataGridTextBoxColumn11,
																												  this.dataGridTextBoxColumn12,
																												  this.dataGridTextBoxColumn18,
																												  this.dataGridTextBoxColumn13,
																												  this.dataGridTextBoxColumn14,
																												  this.dataGridTextBoxColumn15,
																												  this.dataGridTextBoxColumn16,
																												  this.dataGridTextBoxColumn17,
																												  this.dataGridTextBoxColumn22});
			this.dataGridTableStyle3.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle3.MappingName = "";
			// 
			// dataGridTextBoxColumn10
			// 
			this.dataGridTextBoxColumn10.Format = "";
			this.dataGridTextBoxColumn10.FormatInfo = null;
			this.dataGridTextBoxColumn10.HeaderText = "Relación";
			this.dataGridTextBoxColumn10.MappingName = "tRelacionTipoCliCen";
			this.dataGridTextBoxColumn10.NullText = "";
			this.dataGridTextBoxColumn10.Width = 60;
			// 
			// dataGridTextBoxColumn7
			// 
			this.dataGridTextBoxColumn7.Format = "";
			this.dataGridTextBoxColumn7.FormatInfo = null;
			this.dataGridTextBoxColumn7.HeaderText = "Código";
			this.dataGridTextBoxColumn7.MappingName = "sIdCentro";
			this.dataGridTextBoxColumn7.NullText = "";
			this.dataGridTextBoxColumn7.Width = 110;
			// 
			// dataGridTextBoxColumn8
			// 
			this.dataGridTextBoxColumn8.Format = "";
			this.dataGridTextBoxColumn8.FormatInfo = null;
			this.dataGridTextBoxColumn8.HeaderText = "Nombre Centro";
			this.dataGridTextBoxColumn8.MappingName = "sDescripcion";
			this.dataGridTextBoxColumn8.NullText = "";
			this.dataGridTextBoxColumn8.Width = 150;
			// 
			// dataGridTextBoxColumn9
			// 
			this.dataGridTextBoxColumn9.Format = "";
			this.dataGridTextBoxColumn9.FormatInfo = null;
			this.dataGridTextBoxColumn9.MappingName = "sIdTipoRelacionCliCen";
			this.dataGridTextBoxColumn9.NullText = "";
			this.dataGridTextBoxColumn9.Width = 0;
			// 
			// dataGridTextBoxColumn11
			// 
			this.dataGridTextBoxColumn11.Format = "";
			this.dataGridTextBoxColumn11.FormatInfo = null;
			this.dataGridTextBoxColumn11.HeaderText = "Día Visita";
			this.dataGridTextBoxColumn11.MappingName = "sDia";
			this.dataGridTextBoxColumn11.NullText = "";
			this.dataGridTextBoxColumn11.Width = 75;
			// 
			// dataGridTextBoxColumn12
			// 
			this.dataGridTextBoxColumn12.Format = "";
			this.dataGridTextBoxColumn12.FormatInfo = null;
			this.dataGridTextBoxColumn12.MappingName = "sManTarde";
			this.dataGridTextBoxColumn12.NullText = "";
			this.dataGridTextBoxColumn12.Width = 0;
			// 
			// dataGridTextBoxColumn18
			// 
			this.dataGridTextBoxColumn18.Format = "";
			this.dataGridTextBoxColumn18.FormatInfo = null;
			this.dataGridTextBoxColumn18.HeaderText = "Horario";
			this.dataGridTextBoxColumn18.MappingName = "tManTarde";
			this.dataGridTextBoxColumn18.NullText = "";
			this.dataGridTextBoxColumn18.Width = 75;
			// 
			// dataGridTextBoxColumn13
			// 
			this.dataGridTextBoxColumn13.Format = "";
			this.dataGridTextBoxColumn13.FormatInfo = null;
			this.dataGridTextBoxColumn13.HeaderText = "Man.Ini.";
			this.dataGridTextBoxColumn13.MappingName = "sHoraManIni";
			this.dataGridTextBoxColumn13.NullText = "";
			this.dataGridTextBoxColumn13.Width = 50;
			// 
			// dataGridTextBoxColumn14
			// 
			this.dataGridTextBoxColumn14.Format = "";
			this.dataGridTextBoxColumn14.FormatInfo = null;
			this.dataGridTextBoxColumn14.HeaderText = "Man.Fin.";
			this.dataGridTextBoxColumn14.MappingName = "sHoraManFin";
			this.dataGridTextBoxColumn14.NullText = "";
			this.dataGridTextBoxColumn14.Width = 50;
			// 
			// dataGridTextBoxColumn15
			// 
			this.dataGridTextBoxColumn15.Format = "";
			this.dataGridTextBoxColumn15.FormatInfo = null;
			this.dataGridTextBoxColumn15.HeaderText = "Tar.Ini";
			this.dataGridTextBoxColumn15.MappingName = "sHoraTarIni";
			this.dataGridTextBoxColumn15.NullText = "";
			this.dataGridTextBoxColumn15.Width = 45;
			// 
			// dataGridTextBoxColumn16
			// 
			this.dataGridTextBoxColumn16.Format = "";
			this.dataGridTextBoxColumn16.FormatInfo = null;
			this.dataGridTextBoxColumn16.HeaderText = "Tar.Fin";
			this.dataGridTextBoxColumn16.MappingName = "sHoraTarFin";
			this.dataGridTextBoxColumn16.NullText = "";
			this.dataGridTextBoxColumn16.Width = 45;
			// 
			// dataGridTextBoxColumn17
			// 
			this.dataGridTextBoxColumn17.Format = "";
			this.dataGridTextBoxColumn17.FormatInfo = null;
			this.dataGridTextBoxColumn17.HeaderText = "Observ.Horario";
			this.dataGridTextBoxColumn17.MappingName = "tObservaciones";
			this.dataGridTextBoxColumn17.NullText = "";
			this.dataGridTextBoxColumn17.Width = 75;
			// 
			// dataGridTextBoxColumn22
			// 
			this.dataGridTextBoxColumn22.Format = "";
			this.dataGridTextBoxColumn22.FormatInfo = null;
			this.dataGridTextBoxColumn22.MappingName = "iIdCentro";
			this.dataGridTextBoxColumn22.NullText = "";
			this.dataGridTextBoxColumn22.Width = 0;
			// 
			// lblTotCentros
			// 
			this.lblTotCentros.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(238)), ((System.Byte)(243)), ((System.Byte)(246)));
			this.lblTotCentros.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblTotCentros.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblTotCentros.ForeColor = System.Drawing.Color.Black;
			this.lblTotCentros.Location = new System.Drawing.Point(458, 0);
			this.lblTotCentros.Name = "lblTotCentros";
			this.lblTotCentros.Size = new System.Drawing.Size(60, 18);
			this.lblTotCentros.TabIndex = 4;
			this.lblTotCentros.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelGradient1
			// 
			this.labelGradient1.Dock = System.Windows.Forms.DockStyle.Top;
			this.labelGradient1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.labelGradient1.ForeColor = System.Drawing.Color.White;
			this.labelGradient1.GradientColorOne = System.Drawing.Color.FromArgb(((System.Byte)(18)), ((System.Byte)(84)), ((System.Byte)(132)));
			this.labelGradient1.GradientColorTwo = System.Drawing.Color.White;
			this.labelGradient1.Location = new System.Drawing.Point(0, 0);
			this.labelGradient1.Name = "labelGradient1";
			this.labelGradient1.Size = new System.Drawing.Size(516, 18);
			this.labelGradient1.TabIndex = 0;
			this.labelGradient1.Text = "Centros";
			this.labelGradient1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btEliminarCen
			// 
			this.btEliminarCen.Image = ((System.Drawing.Image)(resources.GetObject("btEliminarCen.Image")));
			this.btEliminarCen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btEliminarCen.Location = new System.Drawing.Point(84, 152);
			this.btEliminarCen.Name = "btEliminarCen";
			this.btEliminarCen.TabIndex = 3;
			this.btEliminarCen.Text = "&Eliminar";
			this.btEliminarCen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.toolTip1.SetToolTip(this.btEliminarCen, "Eliminar Centro ALT+E");
			this.btEliminarCen.Click += new System.EventHandler(this.btEliminarCen_Click);
			// 
			// btActualizarCen
			// 
			this.btActualizarCen.Image = ((System.Drawing.Image)(resources.GetObject("btActualizarCen.Image")));
			this.btActualizarCen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btActualizarCen.Location = new System.Drawing.Point(4, 152);
			this.btActualizarCen.Name = "btActualizarCen";
			this.btActualizarCen.Size = new System.Drawing.Size(80, 23);
			this.btActualizarCen.TabIndex = 2;
			this.btActualizarCen.Text = "&Actualizar";
			this.btActualizarCen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.toolTip1.SetToolTip(this.btActualizarCen, "Actualizar Centros ALT+A");
			this.btActualizarCen.Click += new System.EventHandler(this.btActualizarCen_Click);
			// 
			// panel4
			// 
			this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel4.Controls.Add(this.txtCenObservVisi);
			this.panel4.Controls.Add(this.txtCenManFin);
			this.panel4.Controls.Add(this.txtCenTarFin);
			this.panel4.Controls.Add(this.txtCenManIni);
			this.panel4.Controls.Add(this.label9);
			this.panel4.Controls.Add(this.txtCenTarIni);
			this.panel4.Controls.Add(this.label8);
			this.panel4.Controls.Add(this.txtCentroDesc);
			this.panel4.Controls.Add(this.txtCentrosId);
			this.panel4.Controls.Add(this.label5);
			this.panel4.Controls.Add(this.btBuscarCentro);
			this.panel4.Controls.Add(this.cbCentRelacion);
			this.panel4.Controls.Add(this.label6);
			this.panel4.Controls.Add(this.txtCentDiaVis);
			this.panel4.Controls.Add(this.cbCenHorario);
			this.panel4.Controls.Add(this.label7);
			this.panel4.Controls.Add(this.label12);
			this.panel4.Controls.Add(this.label10);
			this.panel4.Controls.Add(this.label13);
			this.panel4.Controls.Add(this.label11);
			this.panel4.Location = new System.Drawing.Point(4, 176);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(924, 64);
			this.panel4.TabIndex = 1;
			// 
			// txtCenObservVisi
			// 
			this.txtCenObservVisi.Location = new System.Drawing.Point(704, 16);
			this.txtCenObservVisi.MaxLength = 8000;
			this.txtCenObservVisi.Multiline = true;
			this.txtCenObservVisi.Name = "txtCenObservVisi";
			this.txtCenObservVisi.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtCenObservVisi.Size = new System.Drawing.Size(216, 40);
			this.txtCenObservVisi.TabIndex = 8;
			this.txtCenObservVisi.Text = "";
			// 
			// txtCenManFin
			// 
			this.txtCenManFin.Location = new System.Drawing.Point(664, 16);
			this.txtCenManFin.MaxLength = 5;
			this.txtCenManFin.Name = "txtCenManFin";
			this.txtCenManFin.Size = new System.Drawing.Size(40, 20);
			this.txtCenManFin.TabIndex = 5;
			this.txtCenManFin.Text = "";
			this.toolTip1.SetToolTip(this.txtCenManFin, "Formato HH:MM");
			this.txtCenManFin.Leave += new System.EventHandler(this.txtCenManFin_Leave);
			// 
			// txtCenTarFin
			// 
			this.txtCenTarFin.Location = new System.Drawing.Point(664, 36);
			this.txtCenTarFin.MaxLength = 5;
			this.txtCenTarFin.Name = "txtCenTarFin";
			this.txtCenTarFin.Size = new System.Drawing.Size(40, 20);
			this.txtCenTarFin.TabIndex = 7;
			this.txtCenTarFin.Text = "";
			this.toolTip1.SetToolTip(this.txtCenTarFin, "Formato HH:MM");
			this.txtCenTarFin.Leave += new System.EventHandler(this.txtCenTarFin_Leave);
			// 
			// txtCenManIni
			// 
			this.txtCenManIni.Location = new System.Drawing.Point(624, 16);
			this.txtCenManIni.MaxLength = 5;
			this.txtCenManIni.Name = "txtCenManIni";
			this.txtCenManIni.Size = new System.Drawing.Size(40, 20);
			this.txtCenManIni.TabIndex = 4;
			this.txtCenManIni.Text = "";
			this.toolTip1.SetToolTip(this.txtCenManIni, "Formato HH:MM");
			this.txtCenManIni.Leave += new System.EventHandler(this.txtCenManIni_Leave);
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(576, 16);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(48, 18);
			this.label9.TabIndex = 15;
			this.label9.Text = "Mañana:";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtCenTarIni
			// 
			this.txtCenTarIni.Location = new System.Drawing.Point(624, 36);
			this.txtCenTarIni.MaxLength = 5;
			this.txtCenTarIni.Name = "txtCenTarIni";
			this.txtCenTarIni.Size = new System.Drawing.Size(40, 20);
			this.txtCenTarIni.TabIndex = 6;
			this.txtCenTarIni.Text = "";
			this.toolTip1.SetToolTip(this.txtCenTarIni, "Formato HH:MM");
			this.txtCenTarIni.Leave += new System.EventHandler(this.txtCenTarIni_Leave);
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(576, 32);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(40, 18);
			this.label8.TabIndex = 14;
			this.label8.Text = "Tarde:";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtCentroDesc
			// 
			this.txtCentroDesc.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(238)), ((System.Byte)(243)), ((System.Byte)(246)));
			this.txtCentroDesc.Location = new System.Drawing.Point(2, 36);
			this.txtCentroDesc.MaxLength = 100;
			this.txtCentroDesc.Name = "txtCentroDesc";
			this.txtCentroDesc.ReadOnly = true;
			this.txtCentroDesc.Size = new System.Drawing.Size(259, 20);
			this.txtCentroDesc.TabIndex = 9;
			this.txtCentroDesc.TabStop = false;
			this.txtCentroDesc.Text = "";
			// 
			// txtCentrosId
			// 
			this.txtCentrosId.Location = new System.Drawing.Point(2, 16);
			this.txtCentrosId.MaxLength = 20;
			this.txtCentrosId.Name = "txtCentrosId";
			this.txtCentrosId.Size = new System.Drawing.Size(115, 20);
			this.txtCentrosId.TabIndex = 0;
			this.txtCentrosId.Text = "";
			this.txtCentrosId.Leave += new System.EventHandler(this.txtCentrosId_Leave);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(2, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(48, 18);
			this.label5.TabIndex = 11;
			this.label5.Text = "Centro:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btBuscarCentro
			// 
			this.btBuscarCentro.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.btBuscarCentro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.btBuscarCentro.Image = ((System.Drawing.Image)(resources.GetObject("btBuscarCentro.Image")));
			this.btBuscarCentro.Location = new System.Drawing.Point(118, 16);
			this.btBuscarCentro.Name = "btBuscarCentro";
			this.btBuscarCentro.Size = new System.Drawing.Size(21, 21);
			this.btBuscarCentro.TabIndex = 10;
			this.toolTip1.SetToolTip(this.btBuscarCentro, "Buscar Centro");
			this.btBuscarCentro.Click += new System.EventHandler(this.btBuscarCentro_Click);
			// 
			// cbCentRelacion
			// 
			this.cbCentRelacion.DataSource = this.dsClientes1.ListaTipoRelacionClienteCentro;
			this.cbCentRelacion.DisplayMember = "sLiteral";
			this.cbCentRelacion.Location = new System.Drawing.Point(139, 16);
			this.cbCentRelacion.Name = "cbCentRelacion";
			this.cbCentRelacion.Size = new System.Drawing.Size(121, 21);
			this.cbCentRelacion.TabIndex = 1;
			this.cbCentRelacion.ValueMember = "sValor";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(139, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(56, 18);
			this.label6.TabIndex = 12;
			this.label6.Text = "Relación:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtCentDiaVis
			// 
			this.txtCentDiaVis.Location = new System.Drawing.Point(260, 16);
			this.txtCentDiaVis.MaxLength = 100;
			this.txtCentDiaVis.Multiline = true;
			this.txtCentDiaVis.Name = "txtCentDiaVis";
			this.txtCentDiaVis.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtCentDiaVis.Size = new System.Drawing.Size(190, 40);
			this.txtCentDiaVis.TabIndex = 2;
			this.txtCentDiaVis.Text = "";
			// 
			// cbCenHorario
			// 
			this.cbCenHorario.DataSource = this.dsClientes1.ListaTipoHorarioCentro;
			this.cbCenHorario.DisplayMember = "sLiteral";
			this.cbCenHorario.Location = new System.Drawing.Point(450, 16);
			this.cbCenHorario.Name = "cbCenHorario";
			this.cbCenHorario.Size = new System.Drawing.Size(121, 21);
			this.cbCenHorario.TabIndex = 3;
			this.cbCenHorario.ValueMember = "sValor";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(664, 0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(32, 18);
			this.label7.TabIndex = 13;
			this.label7.Text = ".Fin:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(624, 0);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(24, 18);
			this.label12.TabIndex = 18;
			this.label12.Text = "Ini.:";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(704, 0);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(100, 18);
			this.label10.TabIndex = 16;
			this.label10.Text = "Observ.Horario:";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(260, 0);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(56, 18);
			this.label13.TabIndex = 19;
			this.label13.Text = "Día Visita:";
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(450, 0);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(48, 18);
			this.label11.TabIndex = 17;
			this.label11.Text = "Horario:";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// pnAccionesMark
			// 
			this.pnAccionesMark.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.pnAccionesMark.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pnAccionesMark.Controls.Add(this.panel8);
			this.pnAccionesMark.Controls.Add(this.btEliminarAcc);
			this.pnAccionesMark.Controls.Add(this.btActualizarAcc);
			this.pnAccionesMark.Controls.Add(this.panel5);
			this.pnAccionesMark.Location = new System.Drawing.Point(1, 1184);
			this.pnAccionesMark.Name = "pnAccionesMark";
			this.pnAccionesMark.Size = new System.Drawing.Size(934, 475);
			this.pnAccionesMark.TabIndex = 5;
			// 
			// panel8
			// 
			this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel8.Controls.Add(this.dgAccionesMark);
			this.panel8.Controls.Add(this.lblTotAcciones);
			this.panel8.Controls.Add(this.labelGradient4);
			this.panel8.Location = new System.Drawing.Point(4, 4);
			this.panel8.Name = "panel8";
			this.panel8.Size = new System.Drawing.Size(924, 372);
			this.panel8.TabIndex = 0;
			// 
			// dgAccionesMark
			// 
			this.dgAccionesMark.CaptionText = "Acciones";
			this.dgAccionesMark.CaptionVisible = false;
			this.dgAccionesMark.DataMember = "";
			this.dgAccionesMark.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgAccionesMark.Location = new System.Drawing.Point(-2, 18);
			this.dgAccionesMark.Name = "dgAccionesMark";
			this.dgAccionesMark.Size = new System.Drawing.Size(922, 352);
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
																												  this.dataGridTextBoxColumn23});
			this.dataGridTableStyle4.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle4.MappingName = "";
			// 
			// dataGridTextBoxColumn6
			// 
			this.dataGridTextBoxColumn6.Format = "";
			this.dataGridTextBoxColumn6.FormatInfo = null;
			this.dataGridTextBoxColumn6.HeaderText = "Acción";
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
			this.dataGridTextBoxColumn20.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this.dataGridTextBoxColumn20.Format = "";
			this.dataGridTextBoxColumn20.FormatInfo = null;
			this.dataGridTextBoxColumn20.HeaderText = "Cantidad";
			this.dataGridTextBoxColumn20.MappingName = "fCantidad";
			this.dataGridTextBoxColumn20.NullText = "";
			this.dataGridTextBoxColumn20.Width = 75;
			// 
			// dataGridTextBoxColumn21
			// 
			this.dataGridTextBoxColumn21.Format = "dd/mm/yyyy";
			this.dataGridTextBoxColumn21.FormatInfo = null;
			this.dataGridTextBoxColumn21.HeaderText = "Observaciones Entrega";
			this.dataGridTextBoxColumn21.MappingName = "tObservEntrega";
			this.dataGridTextBoxColumn21.NullText = "";
			this.dataGridTextBoxColumn21.Width = 400;
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
			this.lblTotAcciones.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(238)), ((System.Byte)(243)), ((System.Byte)(246)));
			this.lblTotAcciones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblTotAcciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblTotAcciones.ForeColor = System.Drawing.Color.Black;
			this.lblTotAcciones.Location = new System.Drawing.Point(859, 0);
			this.lblTotAcciones.Name = "lblTotAcciones";
			this.lblTotAcciones.Size = new System.Drawing.Size(60, 18);
			this.lblTotAcciones.TabIndex = 5;
			this.lblTotAcciones.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelGradient4
			// 
			this.labelGradient4.Dock = System.Windows.Forms.DockStyle.Top;
			this.labelGradient4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.labelGradient4.ForeColor = System.Drawing.Color.White;
			this.labelGradient4.GradientColorOne = System.Drawing.Color.FromArgb(((System.Byte)(18)), ((System.Byte)(84)), ((System.Byte)(132)));
			this.labelGradient4.GradientColorTwo = System.Drawing.Color.White;
			this.labelGradient4.Location = new System.Drawing.Point(0, 0);
			this.labelGradient4.Name = "labelGradient4";
			this.labelGradient4.Size = new System.Drawing.Size(920, 18);
			this.labelGradient4.TabIndex = 0;
			this.labelGradient4.Text = "Acciones";
			this.labelGradient4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btEliminarAcc
			// 
			this.btEliminarAcc.Image = ((System.Drawing.Image)(resources.GetObject("btEliminarAcc.Image")));
			this.btEliminarAcc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btEliminarAcc.Location = new System.Drawing.Point(84, 379);
			this.btEliminarAcc.Name = "btEliminarAcc";
			this.btEliminarAcc.TabIndex = 3;
			this.btEliminarAcc.Text = "Eli&minar";
			this.btEliminarAcc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.toolTip1.SetToolTip(this.btEliminarAcc, "Eliminar Acción ALT+M");
			this.btEliminarAcc.Click += new System.EventHandler(this.btEliminarAcc_Click);
			// 
			// btActualizarAcc
			// 
			this.btActualizarAcc.Image = ((System.Drawing.Image)(resources.GetObject("btActualizarAcc.Image")));
			this.btActualizarAcc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btActualizarAcc.Location = new System.Drawing.Point(4, 379);
			this.btActualizarAcc.Name = "btActualizarAcc";
			this.btActualizarAcc.Size = new System.Drawing.Size(80, 23);
			this.btActualizarAcc.TabIndex = 2;
			this.btActualizarAcc.Text = "Act&ualizar";
			this.btActualizarAcc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.toolTip1.SetToolTip(this.btActualizarAcc, "Actualizar Acción ALT+U");
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
			this.panel5.Location = new System.Drawing.Point(4, 402);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(924, 64);
			this.panel5.TabIndex = 1;
			// 
			// btBuscaAccion
			// 
			this.btBuscaAccion.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.btBuscaAccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.btBuscaAccion.Image = ((System.Drawing.Image)(resources.GetObject("btBuscaAccion.Image")));
			this.btBuscaAccion.Location = new System.Drawing.Point(212, 16);
			this.btBuscaAccion.Name = "btBuscaAccion";
			this.btBuscaAccion.Size = new System.Drawing.Size(21, 21);
			this.btBuscaAccion.TabIndex = 4;
			this.toolTip1.SetToolTip(this.btBuscaAccion, "Buscar Acción");
			this.btBuscaAccion.Click += new System.EventHandler(this.btBuscaAccion_Click);
			// 
			// txtAccObservEntrega
			// 
			this.txtAccObservEntrega.Location = new System.Drawing.Point(489, 16);
			this.txtAccObservEntrega.MaxLength = 8000;
			this.txtAccObservEntrega.Multiline = true;
			this.txtAccObservEntrega.Name = "txtAccObservEntrega";
			this.txtAccObservEntrega.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtAccObservEntrega.Size = new System.Drawing.Size(430, 40);
			this.txtAccObservEntrega.TabIndex = 3;
			this.txtAccObservEntrega.Text = "";
			// 
			// nupAccCantidad
			// 
			this.nupAccCantidad.Location = new System.Drawing.Point(433, 16);
			this.nupAccCantidad.Maximum = new System.Decimal(new int[] {
																		   10000,
																		   0,
																		   0,
																		   0});
			this.nupAccCantidad.Minimum = new System.Decimal(new int[] {
																		   1,
																		   0,
																		   0,
																		   0});
			this.nupAccCantidad.Name = "nupAccCantidad";
			this.nupAccCantidad.Size = new System.Drawing.Size(56, 20);
			this.nupAccCantidad.TabIndex = 2;
			this.nupAccCantidad.Value = new System.Decimal(new int[] {
																		 1,
																		 0,
																		 0,
																		 0});
			// 
			// dtpAccFEntrega
			// 
			this.dtpAccFEntrega.Location = new System.Drawing.Point(233, 16);
			this.dtpAccFEntrega.Name = "dtpAccFEntrega";
			this.dtpAccFEntrega.TabIndex = 1;
			// 
			// txtAccsIdAccion
			// 
			this.txtAccsIdAccion.Location = new System.Drawing.Point(4, 16);
			this.txtAccsIdAccion.MaxLength = 50;
			this.txtAccsIdAccion.Name = "txtAccsIdAccion";
			this.txtAccsIdAccion.Size = new System.Drawing.Size(208, 20);
			this.txtAccsIdAccion.TabIndex = 0;
			this.txtAccsIdAccion.Text = "";
			this.txtAccsIdAccion.Leave += new System.EventHandler(this.txtAccsIdAccion_Leave);
			// 
			// label17
			// 
			this.label17.Location = new System.Drawing.Point(489, 0);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(168, 18);
			this.label17.TabIndex = 7;
			this.label17.Text = "Observaciones de la Entrega:";
			this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label16
			// 
			this.label16.Location = new System.Drawing.Point(233, 0);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(100, 18);
			this.label16.TabIndex = 6;
			this.label16.Text = "Fecha Entrega:";
			this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(433, 0);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(60, 18);
			this.label15.TabIndex = 5;
			this.label15.Text = "Cantidad:";
			this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(4, 0);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(100, 18);
			this.label14.TabIndex = 4;
			this.label14.Text = "Acción:";
			this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// sqldaListaProdClientes_COM
			// 
			this.sqldaListaProdClientes_COM.SelectCommand = this.sqlSelectCommand2;
			this.sqldaListaProdClientes_COM.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																												 new System.Data.Common.DataTableMapping("Table", "ListaProdClientes_COM", new System.Data.Common.DataColumnMapping[] {
																																																										  new System.Data.Common.DataColumnMapping("sIdProducto", "sIdProducto"),
																																																										  new System.Data.Common.DataColumnMapping("sDescripcion", "sDescripcion"),
																																																										  new System.Data.Common.DataColumnMapping("iPrioridad", "iPrioridad")})});
			// 
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = "[ListaProdClientes_COM]";
			this.sqlSelectCommand2.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelectCommand2.Connection = this.sqlConn;
			this.sqlSelectCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelectCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4));
			// 
			// sqldaListaTipoEspecialidadMed
			// 
			this.sqldaListaTipoEspecialidadMed.SelectCommand = this.sqlSelectCommand3;
			this.sqldaListaTipoEspecialidadMed.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																													new System.Data.Common.DataTableMapping("Table", "ListaTipoEspeciadadMed", new System.Data.Common.DataColumnMapping[] {
																																																											  new System.Data.Common.DataColumnMapping("sValor", "sValor"),
																																																											  new System.Data.Common.DataColumnMapping("sLiteral", "sLiteral")})});
			// 
			// sqlSelectCommand3
			// 
			this.sqlSelectCommand3.CommandText = "[ListaTipoEspeciadadMed]";
			this.sqlSelectCommand3.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelectCommand3.Connection = this.sqlConn;
			this.sqlSelectCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			// 
			// sqldaListaProductos
			// 
			this.sqldaListaProductos.SelectCommand = this.sqlSelectCommand4;
			this.sqldaListaProductos.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																										  new System.Data.Common.DataTableMapping("Table", "ListaProductos", new System.Data.Common.DataColumnMapping[] {
																																																							new System.Data.Common.DataColumnMapping("sIdProducto", "sIdProducto"),
																																																							new System.Data.Common.DataColumnMapping("sDescripcion", "sDescripcion")})});
			// 
			// sqlSelectCommand4
			// 
			this.sqlSelectCommand4.CommandText = "[ListaProductos]";
			this.sqlSelectCommand4.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelectCommand4.Connection = this.sqlConn;
			this.sqlSelectCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
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
			// sqldaListaCentros_porCliente_COM
			// 
			this.sqldaListaCentros_porCliente_COM.SelectCommand = this.sqlSelectCommand5;
			this.sqldaListaCentros_porCliente_COM.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																													   new System.Data.Common.DataTableMapping("Table", "ListaCentros_porCliente_COM", new System.Data.Common.DataColumnMapping[] {
																																																													  new System.Data.Common.DataColumnMapping("iIdCentro", "iIdCentro"),
																																																													  new System.Data.Common.DataColumnMapping("sIdCentro", "sIdCentro"),
																																																													  new System.Data.Common.DataColumnMapping("sDescripcion", "sDescripcion"),
																																																													  new System.Data.Common.DataColumnMapping("sIdTipoRelacionCliCen", "sIdTipoRelacionCliCen"),
																																																													  new System.Data.Common.DataColumnMapping("tRelacionTipoCliCen", "tRelacionTipoCliCen"),
																																																													  new System.Data.Common.DataColumnMapping("sDia", "sDia"),
																																																													  new System.Data.Common.DataColumnMapping("sManTarde", "sManTarde"),
																																																													  new System.Data.Common.DataColumnMapping("tManTarde", "tManTarde"),
																																																													  new System.Data.Common.DataColumnMapping("sHoraManIni", "sHoraManIni"),
																																																													  new System.Data.Common.DataColumnMapping("sHoraManFin", "sHoraManFin"),
																																																													  new System.Data.Common.DataColumnMapping("sHoraTarIni", "sHoraTarIni"),
																																																													  new System.Data.Common.DataColumnMapping("sHoraTarFin", "sHoraTarFin"),
																																																													  new System.Data.Common.DataColumnMapping("tObservaciones", "tObservaciones")})});
			// 
			// sqlSelectCommand5
			// 
			this.sqlSelectCommand5.CommandText = "[ListaCentros_porCliente_COM]";
			this.sqlSelectCommand5.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelectCommand5.Connection = this.sqlConn;
			this.sqlSelectCommand5.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelectCommand5.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4));
			// 
			// sqldaListaTipoHorarioCentro
			// 
			this.sqldaListaTipoHorarioCentro.SelectCommand = this.sqlSelectCommand6;
			this.sqldaListaTipoHorarioCentro.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																												  new System.Data.Common.DataTableMapping("Table", "ListaTipoHorarioCentro", new System.Data.Common.DataColumnMapping[] {
																																																											new System.Data.Common.DataColumnMapping("sValor", "sValor"),
																																																											new System.Data.Common.DataColumnMapping("sLiteral", "sLiteral")})});
			// 
			// sqlSelectCommand6
			// 
			this.sqlSelectCommand6.CommandText = "[ListaTipoHorarioCentro]";
			this.sqlSelectCommand6.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelectCommand6.Connection = this.sqlConn;
			this.sqlSelectCommand6.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			// 
			// sqldaListaTipoRelacionClienteCentro
			// 
			this.sqldaListaTipoRelacionClienteCentro.SelectCommand = this.sqlSelectCommand7;
			this.sqldaListaTipoRelacionClienteCentro.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																														  new System.Data.Common.DataTableMapping("Table", "ListaTipoRelacionClienteCentro", new System.Data.Common.DataColumnMapping[] {
																																																															new System.Data.Common.DataColumnMapping("sValor", "sValor"),
																																																															new System.Data.Common.DataColumnMapping("sLiteral", "sLiteral")})});
			// 
			// sqlSelectCommand7
			// 
			this.sqlSelectCommand7.CommandText = "[ListaTipoRelacionClienteCentro]";
			this.sqlSelectCommand7.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelectCommand7.Connection = this.sqlConn;
			this.sqlSelectCommand7.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			// 
			// sqldaListaAccionesMarkCli
			// 
			this.sqldaListaAccionesMarkCli.SelectCommand = this.sqlSelectCommand8;
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
			// sqlSelectCommand8
			// 
			this.sqlSelectCommand8.CommandText = "[ListaAccionesMarkClientes]";
			this.sqlSelectCommand8.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelectCommand8.Connection = this.sqlConn;
			this.sqlSelectCommand8.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelectCommand8.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4));
			// 
			// sqldaGetCliente_COM
			// 
			this.sqldaGetCliente_COM.SelectCommand = this.sqlSelectCommand9;
			this.sqldaGetCliente_COM.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																										  new System.Data.Common.DataTableMapping("Table", "GetCliente_COM", new System.Data.Common.DataColumnMapping[] {
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
																																																							new System.Data.Common.DataColumnMapping("sTipoCliente_COM", "sTipoCliente_COM"),
																																																							new System.Data.Common.DataColumnMapping("tTipoCliente_COM", "tTipoCliente_COM"),
																																																							new System.Data.Common.DataColumnMapping("sNumColegiado_COM", "sNumColegiado_COM"),
																																																							new System.Data.Common.DataColumnMapping("sIdCaracteristica_COM", "sIdCaracteristica_COM"),
																																																							new System.Data.Common.DataColumnMapping("tIdCaracteristica_COM", "tIdCaracteristica_COM"),
																																																							new System.Data.Common.DataColumnMapping("tObservaciones_COM", "tObservaciones_COM"),
																																																							new System.Data.Common.DataColumnMapping("tHobbies_COM", "tHobbies_COM"),
																																																							new System.Data.Common.DataColumnMapping("sEmail_COM", "sEmail_COM"),
																																																							new System.Data.Common.DataColumnMapping("sFax_COM", "sFax_COM"),
																																																							new System.Data.Common.DataColumnMapping("sTelMovil_COM", "sTelMovil_COM"),
																																																							new System.Data.Common.DataColumnMapping("sDireccion_COM", "sDireccion_COM"),
																																																							new System.Data.Common.DataColumnMapping("sEstadoCivil_COM", "sEstadoCivil_COM"),
																																																							new System.Data.Common.DataColumnMapping("tEstadoCivil_COM", "tEstadoCivil_COM"),
																																																							new System.Data.Common.DataColumnMapping("sIdioma1_COM", "sIdioma1_COM"),
																																																							new System.Data.Common.DataColumnMapping("tIdioma1_COM", "tIdioma1_COM"),
																																																							new System.Data.Common.DataColumnMapping("sIdioma2_COM", "sIdioma2_COM"),
																																																							new System.Data.Common.DataColumnMapping("tIdioma2_COM", "tIdioma2_COM"),
																																																							new System.Data.Common.DataColumnMapping("dFecNacimiento_COM", "dFecNacimiento_COM"),
																																																							new System.Data.Common.DataColumnMapping("dFecAniversario_COM", "dFecAniversario_COM"),
																																																							new System.Data.Common.DataColumnMapping("tAficionesPasivas_COM", "tAficionesPasivas_COM"),
																																																							new System.Data.Common.DataColumnMapping("tAficionesActivas_COM", "tAficionesActivas_COM"),
																																																							new System.Data.Common.DataColumnMapping("sNIF_COM", "sNIF_COM"),
																																																							new System.Data.Common.DataColumnMapping("sIdEstadoCliCom_COM", "sIdEstadoCliCom_COM"),
																																																							new System.Data.Common.DataColumnMapping("tIdEstadoCliCom_COM", "tIdEstadoCliCom_COM"),
																																																							new System.Data.Common.DataColumnMapping("sIdPolGenericos_COM", "sIdPolGenericos_COM"),
																																																							new System.Data.Common.DataColumnMapping("tIdPolGenericos_COM", "tIdPolGenericos_COM"),
																																																							new System.Data.Common.DataColumnMapping("bAsignado_COM", "bAsignado_COM"),
																																																							new System.Data.Common.DataColumnMapping("tDatosFinacieros_COM", "tDatosFinacieros_COM"),
																																																							new System.Data.Common.DataColumnMapping("iEstado", "iEstado"),
																																																							new System.Data.Common.DataColumnMapping("bEnviadoCEN", "bEnviadoCEN")})});
			// 
			// sqlSelectCommand9
			// 
			this.sqlSelectCommand9.CommandText = "[GetCliente_COM]";
			this.sqlSelectCommand9.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelectCommand9.Connection = this.sqlConn;
			this.sqlSelectCommand9.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelectCommand9.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4));
			// 
			// sqlCmdSetAccionesMarkClientes
			// 
			this.sqlCmdSetAccionesMarkClientes.CommandText = "[SetAccionesMarkClientes]";
			this.sqlCmdSetAccionesMarkClientes.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlCmdSetAccionesMarkClientes.Connection = this.sqlConn;
			this.sqlCmdSetAccionesMarkClientes.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdSetAccionesMarkClientes.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iAccion", System.Data.SqlDbType.Int, 4));
			this.sqlCmdSetAccionesMarkClientes.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4));
			this.sqlCmdSetAccionesMarkClientes.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iIdAccion", System.Data.SqlDbType.Int, 4));
			this.sqlCmdSetAccionesMarkClientes.Parameters.Add(new System.Data.SqlClient.SqlParameter("@dFechaEntrega", System.Data.SqlDbType.DateTime, 8));
			this.sqlCmdSetAccionesMarkClientes.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fCantidad", System.Data.SqlDbType.Int, 4));
			this.sqlCmdSetAccionesMarkClientes.Parameters.Add(new System.Data.SqlClient.SqlParameter("@tObservaciones", System.Data.SqlDbType.VarChar, 8000));
			this.sqlCmdSetAccionesMarkClientes.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sCoste", System.Data.SqlDbType.VarChar, 10));
			// 
			// sqlCmdSetCentrosCliCom_Horarios
			// 
			this.sqlCmdSetCentrosCliCom_Horarios.CommandText = "[SetCentrosCliCOM_Horarios]";
			this.sqlCmdSetCentrosCliCom_Horarios.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlCmdSetCentrosCliCom_Horarios.Connection = this.sqlConn;
			this.sqlCmdSetCentrosCliCom_Horarios.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdSetCentrosCliCom_Horarios.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iAccion", System.Data.SqlDbType.Int, 4));
			this.sqlCmdSetCentrosCliCom_Horarios.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4));
			this.sqlCmdSetCentrosCliCom_Horarios.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iIdCentro", System.Data.SqlDbType.Int, 4));
			this.sqlCmdSetCentrosCliCom_Horarios.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sDia", System.Data.SqlDbType.VarChar, 100));
			this.sqlCmdSetCentrosCliCom_Horarios.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sManTarde", System.Data.SqlDbType.VarChar, 10));
			this.sqlCmdSetCentrosCliCom_Horarios.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sHoraManIni", System.Data.SqlDbType.VarChar, 5));
			this.sqlCmdSetCentrosCliCom_Horarios.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sHoraManFin", System.Data.SqlDbType.VarChar, 5));
			this.sqlCmdSetCentrosCliCom_Horarios.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sHoraTarIni", System.Data.SqlDbType.VarChar, 5));
			this.sqlCmdSetCentrosCliCom_Horarios.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sHoraTarFin", System.Data.SqlDbType.VarChar, 5));
			this.sqlCmdSetCentrosCliCom_Horarios.Parameters.Add(new System.Data.SqlClient.SqlParameter("@tObservaciones", System.Data.SqlDbType.VarChar, 8000));
			// 
			// ucBotoneraSecundaria1
			// 
			this.ucBotoneraSecundaria1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(211)), ((System.Byte)(117)), ((System.Byte)(1)));
			this.ucBotoneraSecundaria1.Dock = System.Windows.Forms.DockStyle.Top;
			this.ucBotoneraSecundaria1.ForeColor = System.Drawing.Color.Black;
			this.ucBotoneraSecundaria1.Location = new System.Drawing.Point(0, 0);
			this.ucBotoneraSecundaria1.Name = "ucBotoneraSecundaria1";
			this.ucBotoneraSecundaria1.Size = new System.Drawing.Size(938, 38);
			this.ucBotoneraSecundaria1.TabIndex = 211;
			// 
			// sqldaListaAficClientes_COM
			// 
			this.sqldaListaAficClientes_COM.SelectCommand = this.sqlSelectCommand10;
			this.sqldaListaAficClientes_COM.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																												 new System.Data.Common.DataTableMapping("Table", "ListaAficClientes_COM", new System.Data.Common.DataColumnMapping[] {
																																																										  new System.Data.Common.DataColumnMapping("sIdAficion", "sIdAficion"),
																																																										  new System.Data.Common.DataColumnMapping("tAficion", "tAficion")})});
			// 
			// sqlSelectCommand10
			// 
			this.sqlSelectCommand10.CommandText = "[ListaAficClientes_COM]";
			this.sqlSelectCommand10.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelectCommand10.Connection = this.sqlConn;
			this.sqlSelectCommand10.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelectCommand10.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4));
			// 
			// sqldaListaTipoAficiones
			// 
			this.sqldaListaTipoAficiones.SelectCommand = this.sqlSelectCommand11;
			this.sqldaListaTipoAficiones.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																											  new System.Data.Common.DataTableMapping("Table", "ListaTipoAficiones", new System.Data.Common.DataColumnMapping[] {
																																																									new System.Data.Common.DataColumnMapping("sValor", "sValor"),
																																																									new System.Data.Common.DataColumnMapping("sLiteral", "sLiteral")})});
			// 
			// sqlSelectCommand11
			// 
			this.sqlSelectCommand11.CommandText = "[ListaTipoAficiones]";
			this.sqlSelectCommand11.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelectCommand11.Connection = this.sqlConn;
			this.sqlSelectCommand11.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			// 
			// sqlCmdSetAficClientes_COM
			// 
			this.sqlCmdSetAficClientes_COM.CommandText = "[SetAficClientesCOM]";
			this.sqlCmdSetAficClientes_COM.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlCmdSetAficClientes_COM.Connection = this.sqlConn;
			this.sqlCmdSetAficClientes_COM.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdSetAficClientes_COM.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iAccion", System.Data.SqlDbType.Int, 4));
			this.sqlCmdSetAficClientes_COM.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4));
			this.sqlCmdSetAficClientes_COM.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sIdAficion", System.Data.SqlDbType.VarChar, 10));
			// 
			// frmMClientesCOM
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(238)), ((System.Byte)(243)), ((System.Byte)(246)));
			this.ClientSize = new System.Drawing.Size(804, 217);
			this.Controls.Add(this.ucBotoneraSecundaria1);
			this.Controls.Add(this.pnAccionesMark);
			this.Controls.Add(this.pnCRM);
			this.Controls.Add(this.btAccionesMark);
			this.Controls.Add(this.btCRM);
			this.Controls.Add(this.btAmpliacion);
			this.Controls.Add(this.pnAmpliacion);
			this.Controls.Add(this.pnCliente);
			this.ForeColor = System.Drawing.Color.Black;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmMClientesCOM";
			this.Text = "Mantenimiento de Datos de Cliente Persona/s";
			this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
			this.Closing += new System.ComponentModel.CancelEventHandler(this.frmMClientesCOM_Closing);
			this.Load += new System.EventHandler(this.frmMClientesCOM_Load);
			this.Closed += new System.EventHandler(this.frmMClientesCOM_Closed);
			this.pnCliente.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dsClientes1)).EndInit();
			this.pnAmpliacion.ResumeLayout(false);
			this.panel9.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgAficiones)).EndInit();
			this.panel10.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgEspecialidades)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgProductos)).EndInit();
			this.panel3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nupPrioridadProd)).EndInit();
			this.panel1.ResumeLayout(false);
			this.pnCRM.ResumeLayout(false);
			this.panel7.ResumeLayout(false);
			this.panel6.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgCentros)).EndInit();
			this.panel4.ResumeLayout(false);
			this.pnAccionesMark.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgAccionesMark)).EndInit();
			this.panel5.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nupAccCantidad)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region frmMClientesCOM_Load
		private void frmMClientesCOM_Load(object sender, System.EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;
			try
			{
				GESTCRM.Utiles.Formato_Formulario(this);

				if(this.Parent == null) this.WindowState = FormWindowState.Normal;
			

				this.Param_iIdDelegado = GESTCRM.Clases.Configuracion.iIdDelegado;
				//El delegado sólo tiene acceso de Consulta
				if(GESTCRM.Clases.Configuracion.iGClientesCOM==1) this.Param_TipoAcceso="C";

				this.pnAmpliacion.Location= new Point(1,187);
				this.pnAmpliacion.Visible=false;
				this.pnAccionesMark.Location= new Point(1,187);
				this.pnAccionesMark.Visible=false;
				this.pnCRM.Location= new Point(1,187);
				this.pnCRM.Visible=true;

				Inicializar_Cliente();

				if(this.Param_iIdCliente>-1)
				{

					Inicializar_DataGrids();

					Inicializar_Combos();


					if(this.Param_TipoAcceso == "M")
					{
						if(this.Var_iEstado!=0) this.Param_TipoAcceso="C";
						//else if(this.Var_bEnviadoCEN!=0) this.Param_TipoAcceso="C";
					}

					Activar_Formulario();
					switch(this.Param_TipoAcceso)
					{
						case "A": this.lblTitulo.Text = "Alta de Cliente Persona/s";break;
						case "M": this.lblTitulo.Text = "Modificación de Cliente Persona/s";break;
						case "C": this.lblTitulo.Text = "Consulta de Cliente Persona/s";break;
						default: break;
					}

					Inicializar_Botonera();

					if(this.Param_Inicio==0) //Se llama desde Report de Actividad
					{
						if(this.btAccionesMark.Enabled) Mostrar_Acciones();
					}
				}

				if(this.Param_TipoAcceso=="C")
				{
					this.contextMenu1.Dispose();
				}

				this.SalirDesdeGuardar=false;
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
			Cursor.Current = Cursors.Default;
			if(this.Param_iIdCliente==-1) this.Close();
		}
		#endregion

		#region Inicializar_Botonera
		private void Inicializar_Botonera()
		{
			try
			{
				this.ucBotoneraSecundaria1.btSalir.Click += new EventHandler(btSalir_Click);
				this.ucBotoneraSecundaria1.btGrabar.Click += new EventHandler(btGrabar_Click);
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region Inicializar_DataGrids
		private void Inicializar_DataGrids()
		{
			try
			{	
				//DataGrid de Aficiones de un ClienteCOM
				GESTCRM.Utiles.Formatear_DataGrid(this,this.dgAficiones,null,true,this.contextMenu1);
				this.dsClientes1.ListaAficClientes_COM.Rows.Clear();
				this.sqldaListaAficClientes_COM.SelectCommand.Parameters["@iIdCliente"].Value = this.Param_iIdCliente;
				this.sqldaListaAficClientes_COM.Fill(this.dsClientes1);
				this.lblTotAficiones.Text = this.dsClientes1.ListaAficClientes_COM.Rows.Count.ToString();
				if(int.Parse(this.lblTotAficiones.Text.ToString())>0)
				{
					this.dgAficiones.CurrentCell = new DataGridCell(0,1);
					this.dgAficiones.CurrentCell = new DataGridCell(0,0);
				}

				//DataGrid de Especialidades de un ClienteCOM
				GESTCRM.Utiles.Formatear_DataGrid(this,this.dgEspecialidades,null,true,this.contextMenu1);
				this.dsClientes1.ListaEspecClientes_COM.Rows.Clear();
				this.sqldaListaEspecClientes_COM.SelectCommand.Parameters["@iIdCliente"].Value = this.Param_iIdCliente;
				this.sqldaListaEspecClientes_COM.Fill(this.dsClientes1);
				this.lblTotEspecialidades.Text = this.dsClientes1.ListaEspecClientes_COM.Rows.Count.ToString();
				if(int.Parse(this.lblTotEspecialidades.Text.ToString())>0)
				{
					this.dgEspecialidades.CurrentCell = new DataGridCell(0,1);
					this.dgEspecialidades.CurrentCell = new DataGridCell(0,0);
				}

				//DataGrid de Productos asociados a un ClienteCOM
				GESTCRM.Utiles.Formatear_DataGrid(this,this.dgProductos,null,true,this.contextMenu1);
				this.dsClientes1.ListaProdClientes_COM.Rows.Clear();
				this.sqldaListaProdClientes_COM.SelectCommand.Parameters["@iIdCliente"].Value = this.Param_iIdCliente;
				this.sqldaListaProdClientes_COM.Fill(this.dsClientes1);
				this.lblTotProductos.Text = this.dsClientes1.ListaProdClientes_COM.Rows.Count.ToString();
				if(int.Parse(this.lblTotProductos.Text.ToString())>0)
				{
					this.dgProductos.CurrentCell = new DataGridCell(0,1);
					this.dgProductos.CurrentCell = new DataGridCell(0,0);
				}

				//DataGrid de Centros asociados a un ClienteCOM
				GESTCRM.Utiles.Formatear_DataGrid(this.dgCentros,null,this.contextMenu1);
				this.dsClientes1.ListaCentros_porCliente_COM.Clear();
				this.sqldaListaCentros_porCliente_COM.SelectCommand.Parameters["@iIdCliente"].Value = this.Param_iIdCliente;
				this.sqldaListaCentros_porCliente_COM.Fill(this.dsClientes1);
				this.dtCentros=GESTCRM.Utiles.Inicializar_Tabla(this.dsClientes1.ListaCentros_porCliente_COM);
				this.dgCentros.DataSource = this.dtCentros;
				this.lblTotCentros.Text = this.dtCentros.Rows.Count.ToString();
				if(int.Parse(this.lblTotCentros.Text.ToString())>0)
				{
					this.dgCentros.CurrentCell = new DataGridCell(0,1);
					this.dgCentros.CurrentCell = new DataGridCell(0,0);
				}

				//DataGrid de Acciones asociados a un ClienteCOM
				GESTCRM.Utiles.Formatear_DataGrid(this.dgAccionesMark,null,this.contextMenu1);
				this.dsClientes1.ListaAccionesMarkClientes.Clear();
				this.sqldaListaAccionesMarkCli.SelectCommand.Parameters["@iIdCliente"].Value = this.Param_iIdCliente;
				this.sqldaListaAccionesMarkCli.Fill(this.dsClientes1);
				this.dtAccionesMark = GESTCRM.Utiles.Inicializar_Tabla(this.dsClientes1.ListaAccionesMarkClientes);
//				this.dtAccionesMark.Columns["dFechaEntrega"].DataType=System.Type.GetType("System.DateTime");
				this.dgAccionesMark.DataSource = this.dtAccionesMark;
				this.lblTotAcciones.Text = this.dtAccionesMark.Rows.Count.ToString();
				if(int.Parse(this.lblTotAcciones.Text.ToString())>0)
				{
					this.dgAccionesMark.CurrentCell = new DataGridCell(0,1);
					this.dgAccionesMark.CurrentCell = new DataGridCell(0,0);
				}

				//UserControl del CRM últimas visitas
				string Acceso;
				if(this.Param_TipoAcceso=="C") Acceso="C";
				else Acceso="M";
				this.ucUltimasVisitas1.UltimasVisitasPorCliente(this.Param_iIdCliente,this.Param_iIdDelegado,Acceso);
			}
			catch(Exception e){Mensajes.ShowError(e.Message);}
		}
		#endregion

		#region Inicializar_Combos
		private void Inicializar_Combos()
		{
			try
			{
				//ComboBox cbAficiones
				this.sqldaListaTipoAficiones.Fill(this.dsClientes1);

				//ComboBox cbEspecialidades
				this.sqldaListaTipoEspecialidadMed.Fill(this.dsClientes1);

				//ComboBox cbProdDescripcion
				this.sqldaListaProductos.Fill(this.dsClientes1);

				//ComboBox cbCenHorario
				this.sqldaListaTipoHorarioCentro.Fill(this.dsClientes1);

				//ComboBox cbCentRelacion
				this.sqldaListaTipoRelacionClienteCentro.Fill(this.dsClientes1);
			}
			catch(Exception e){Mensajes.ShowError(e.Message);}
		}
		#endregion

		#region Inicializar_Cliente
		private void Inicializar_Cliente()
		{
			try
			{
				this.dsClientes1.GetCliente_COM.Rows.Clear();
				this.sqldaGetCliente_COM.SelectCommand.Parameters["@iIdCliente"].Value = this.Param_iIdCliente;
				this.sqldaGetCliente_COM.Fill(this.dsClientes1);
				if(this.dsClientes1.GetCliente_COM.Rows.Count==0)
				{
					this.Var_iEstado = int.Parse(this.dsClientes1.GetCliente_COM.Rows[0]["iEstado"].ToString());
					this.Var_bEnviadoCEN = int.Parse(this.dsClientes1.GetCliente_COM.Rows[0]["bEnviadoCEN"].ToString());
				}
			}
			catch(Exception ex)
			{
				this.Param_iIdCliente=-1;
			}
		}
		#endregion 

		#region btAmpliacion_Click
		private void btAmpliacion_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.btCRM.Font = Utiles.fuenteNoBold;
				this.btAccionesMark.Font = Utiles.fuenteNoBold;

				this.btAmpliacion.Font = Utiles.fuenteBold;

				this.pnAccionesMark.Visible=false;
				this.pnCRM.Visible=false;

				this.pnAmpliacion.Visible=true;
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
				this.btAmpliacion.Font = Utiles.fuenteNoBold;
				this.btAccionesMark.Font = Utiles.fuenteNoBold;

				this.btCRM.Font = Utiles.fuenteBold;

				this.pnAmpliacion.Visible=false;
				this.pnAccionesMark.Visible=false;

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
				this.btAmpliacion.Font = Utiles.fuenteNoBold;
				this.btCRM.Font = Utiles.fuenteNoBold;

				this.btAccionesMark.Font = Utiles.fuenteBold;

				this.pnAmpliacion.Visible=false;
				this.pnCRM.Visible=false;

				this.pnAccionesMark.Visible=true;
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
					case "dgEspecialidades":	Eliminar_Especialidad();break;
					case "dgProductos":			Eliminar_Producto();break;
					case "dgCentros":			Eliminar_Centro();break;
					case "dgAccionesMark":		Eliminar_Accion();break;
					case "dgAficiones":			Eliminar_Aficion();break;
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
					case "dgAficion":			Nueva_Aficion();break;
					default: break;
				}
			}
			catch(Exception ex)
			{
				Mensajes.ShowError(ex.Message);
			}
		}
		#endregion



		#region dgEspecialidades_CurrentCellChanged
		private void dgEspecialidades_CurrentCellChanged(object sender, System.EventArgs e)
		{
			try
			{
				int fila = this.dgEspecialidades.CurrentRowIndex;

				if(this.dgEspecialidades[fila,0].ToString().Length==0) this.dgEspecialidades[fila,0]=" ";

				GESTCRM.Utiles.Seleccionar_UnaFilaDataGrid(this,this.dgEspecialidades,fila);

				try{this.cbEspecialidades.SelectedValue = this.dgEspecialidades[fila,1].ToString();}
				catch{this.cbEspecialidades.SelectedIndex=-1;}
			}
			catch(Exception ex)
			{
				Mensajes.ShowError(ex.Message);
			}
		}
		#endregion

		#region btActualizarEspec_Click
		private void btActualizarEspec_Click(object sender, System.EventArgs e)
		{
			Actualizar_Especialidad();
		}
		#endregion

		#region btEliminarEspec_Click
		private void btEliminarEspec_Click(object sender, System.EventArgs e)
		{
			Eliminar_Especialidad();
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
					int fila = GESTCRM.Utiles.Buscar_filaDataGrid(this,this.dgEspecialidades,"sIdEspecialidad",this.dgEspecialidades[this.dgEspecialidades.CurrentRowIndex,1].ToString());
					
					if(fila>-1)
					{
						CurrencyManager cm = (CurrencyManager)this.BindingContext[this.dgEspecialidades.DataSource,this.dgEspecialidades.DataMember];
						DataView dv = (DataView)cm.List;

						int SelFila = fila;
						if(fila>0) SelFila=fila-1;
						if(dv.Count-1==0) SelFila = -1;
						this.dgEspecialidades.CurrentRowIndex=SelFila;
						GESTCRM.Utiles.Seleccionar_UnaFilaDataGrid(this,this.dgEspecialidades,SelFila);
						
						dv.AllowDelete=true;
						dv.Delete(fila);
						dv.AllowDelete=false;
						this.lblTotEspecialidades.Text = dv.Count.ToString();
						Nueva_Especialidad();
					}
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
					int fila = GESTCRM.Utiles.Buscar_filaDataGrid(this,this.dgEspecialidades,"sIdEspecialidad",this.cbEspecialidades.SelectedValue.ToString());

					CurrencyManager cm = (CurrencyManager)this.BindingContext[this.dgEspecialidades.DataSource,this.dgEspecialidades.DataMember];
					DataView dv = (DataView)cm.List;

					if(fila==-1)
					{
						DataRowView dvfila= dv.AddNew();
						dvfila["sIdEspecialidad"]=this.cbEspecialidades.SelectedValue;
						dvfila["tEspecialidad"]=this.cbEspecialidades.GetItemText(this.cbEspecialidades.SelectedItem).ToString();
						fila = dv.Count-1;
					}
					this.dgEspecialidades.CurrentRowIndex = fila;
					GESTCRM.Utiles.Seleccionar_UnaFilaDataGrid(this,this.dgEspecialidades,fila);
					this.lblTotEspecialidades.Text = dv.Count.ToString();
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
					Mensajes.ShowError("Campo Especialidad Obligatorio. ");
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


		#region dgProductos_CurrentCellChanged
		private void dgProductos_CurrentCellChanged(object sender, System.EventArgs e)
		{
			try
			{
				int fila = this.dgProductos.CurrentRowIndex;
				GESTCRM.Utiles.Seleccionar_UnaFilaDataGrid(this,this.dgProductos,fila);

				try{this.nupPrioridadProd.Value = int.Parse(this.dgProductos[fila,0].ToString());}
				catch{this.nupPrioridadProd.Value=0;}
				this.txtProdCodigo.Text = this.dgProductos[fila,1].ToString();
				this.txttProducto.Text = this.dgProductos[fila,2].ToString();
			}
			catch(Exception ex)
			{
				Mensajes.ShowError(ex.Message);
			}
		}
		#endregion

		#region btBuscarProducto_Click
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
					if(this.txtProdCodigo.Text!=frmBProd.ParamIO_sIdProducto)
					{
						this.txtProdCodigo.Text=frmBProd.ParamIO_sIdProducto;
						this.txttProducto.Text=frmBProd.ParamIO_sDescripcion;
					}
				}
			}
			catch(Exception ex)
			{
				Mensajes.ShowError(ex.Message);
			}
		}
		#endregion

		#region txtProdCodigo_Leave
		private void txtProdCodigo_Leave(object sender, System.EventArgs e)
		{
			try
			{
				GESTCRM.Formularios.Busquedas.frmMProductos frmBProd = new GESTCRM.Formularios.Busquedas.frmMProductos();
				frmBProd.ParamIO_sDescripcion= "";
				frmBProd.ParamIO_sIdProducto = this.txtProdCodigo.Text.ToString();
				frmBProd.Buscar_sProducto();
				this.txttProducto.Text = frmBProd.ParamIO_sDescripcion;
				if(frmBProd.ParamIO_sIdProducto=="" && this.txtProdCodigo.Text.ToString().Length!=0) Mensajes.ShowError("Este código de Producto no existe.");
				else this.txtProdCodigo.Text=frmBProd.ParamIO_sIdProducto;
			}
			catch(Exception ex)
			{
				Mensajes.ShowError(ex.Message);
			}
		}
		#endregion

		#region btActualizarProd_Click
		private void btActualizarProd_Click(object sender, System.EventArgs e)
		{
			Actualizar_Producto();
		}
		#endregion

		#region btEliminarProd_Click
		private void btEliminarProd_Click(object sender, System.EventArgs e)
		{
			Eliminar_Producto();
		}
		#endregion

		#region Nuevo_Producto
		private void Nuevo_Producto()
		{
			try
			{
				this.nupPrioridadProd.Focus();
				this.nupPrioridadProd.Value=this.nupPrioridadProd.Minimum;
				this.txtProdCodigo.Text = "";
				this.txttProducto.Text="";
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
					int fila = GESTCRM.Utiles.Buscar_filaDataGrid(this,this.dgProductos,"sIdProducto",this.dgProductos[this.dgProductos.CurrentRowIndex,1].ToString());
					if(fila > -1)
					{
						CurrencyManager cm = (CurrencyManager)this.BindingContext[this.dgProductos.DataSource,this.dgProductos.DataMember];
						DataView dv = (DataView)cm.List;

						int SelFila = fila;
						if(fila>0) SelFila=fila-1;
						if(dv.Count-1==0) SelFila = -1;
						this.dgProductos.CurrentRowIndex=SelFila;
						GESTCRM.Utiles.Seleccionar_UnaFilaDataGrid(this,this.dgProductos,SelFila);
						
						dv.AllowDelete=true;
						dv.Delete(fila);
						dv.AllowDelete=false;
						this.lblTotProductos.Text = dv.Count.ToString();
						Activar_AccionesMark();
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
					int fila = GESTCRM.Utiles.Buscar_filaDataGrid(this,this.dgProductos,"sIdProducto",this.txtProdCodigo.Text.ToString());

					CurrencyManager cm = (CurrencyManager)this.BindingContext[this.dgProductos.DataSource,this.dgProductos.DataMember];
					DataView dv = (DataView)cm.List;

					if(fila==-1)
					{
						DataRowView dvfila= dv.AddNew();
						dvfila["sIdProducto"]=this.txtProdCodigo.Text.ToString();
						dvfila["sDescripcion"]=this.txttProducto.Text.ToString();
						dvfila["iPrioridad"]=Convert.ToInt32(this.nupPrioridadProd.Value);
						fila = dv.Count-1;
					}
					else
					{
						dv.AllowEdit=true;
						dv[fila]["iPrioridad"]=Convert.ToInt32(this.nupPrioridadProd.Value);
						dv.AllowEdit=false;
					}
					this.dgProductos.CurrentRowIndex= fila;
					GESTCRM.Utiles.Seleccionar_UnaFilaDataGrid(this,this.dgProductos,fila);
					this.lblTotProductos.Text = dv.Count.ToString();
					Activar_AccionesMark();
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
				if(this.txtProdCodigo.Text.ToString().Length==0)
				{
					Mensajes.ShowError("Campo Producto Obligatorio. ");
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
				CurrencyManager cm = (CurrencyManager)this.BindingContext[this.dgProductos.DataSource,this.dgProductos.DataMember];
				DataView dv = (DataView)cm.List;

				if(dv.Count==0) //A un Cliente sin productos no se le pueden asignar acciones de marketing
				{
					this.dtAccionesMark.Rows.Clear();
					this.lblTotAcciones.Text = this.dtAccionesMark.Rows.Count.ToString();
					Nueva_Accion();
					this.btAccionesMark.Enabled=false;
				}
				else
				{
					this.btAccionesMark.Enabled=true;
				}
			}
			catch(Exception ex) { Mensajes.ShowError(ex.Message); }
		}
		#endregion



		#region dgCentros_CurrentCellChanged
		private void dgCentros_CurrentCellChanged(object sender, System.EventArgs e)
		{
			try
			{
				int fila = this.dgCentros.CurrentRowIndex;
				GESTCRM.Utiles.Seleccionar_UnaFilaDataGrid(this,this.dgCentros,fila);

				this.Var_iIdCentro = int.Parse(this.dgCentros[fila,12].ToString());
				this.txtCentrosId.Text = this.dgCentros[fila,1].ToString();
				this.txtCentroDesc.Text = this.dgCentros[fila,2].ToString();
				
				try{this.cbCentRelacion.SelectedIndex=-1;this.cbCentRelacion.SelectedValue = this.dgCentros[fila,3].ToString();}
				catch{this.cbCentRelacion.SelectedIndex =-1;}
//				try{this.cbCentRelacion.SelectedValue = this.dgCentros[fila,3].ToString();}
//				catch{this.cbCentRelacion.SelectedIndex =-1;}
				this.txtCentDiaVis.Text = this.dgCentros[fila,4].ToString();
				try{this.cbCenHorario.SelectedValue = this.dgCentros[fila,5].ToString();}
				catch{this.cbCenHorario.SelectedIndex =-1;this.cbCenHorario.SelectedIndex =-1;}
				this.txtCenManIni.Text = this.dgCentros[fila,7].ToString();
				this.txtCenManFin.Text = this.dgCentros[fila,8].ToString();
				this.txtCenTarIni.Text = this.dgCentros[fila,9].ToString();
				this.txtCenTarFin.Text = this.dgCentros[fila,10].ToString();
				this.txtCenObservVisi.Text = this.dgCentros[fila,11].ToString();
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

		#region txtCenManIni_Leave
		private void txtCenManIni_Leave(object sender, System.EventArgs e)
		{
			try
			{
				if(!Validar_Formato_Hora(this.txtCenManIni.Text.ToString())) this.txtCenManIni.Focus();
			}
			catch(Exception ex) {Mensajes.ShowError(ex.Message); }
		}
		#endregion

		#region txtCenManFin_Leave
		private void txtCenManFin_Leave(object sender, System.EventArgs e)
		{
			try
			{
				if(!Validar_Formato_Hora(this.txtCenManFin.Text.ToString())) this.txtCenManFin.Focus();
			}
			catch(Exception ex) {Mensajes.ShowError(ex.Message); }
		}
		#endregion

		#region txtCenTarIni_Leave
		private void txtCenTarIni_Leave(object sender, System.EventArgs e)
		{
			try
			{
				if(!Validar_Formato_Hora(this.txtCenTarIni.Text.ToString())) this.txtCenTarIni.Focus();
			}
			catch(Exception ex) {Mensajes.ShowError(ex.Message); }
		}
		#endregion

		#region txtCenTarFin_Leave
		private void txtCenTarFin_Leave(object sender, System.EventArgs e)
		{
			try
			{
				if(!Validar_Formato_Hora(this.txtCenTarFin.Text.ToString())) this.txtCenTarFin.Focus();
			}
			catch(Exception ex) {Mensajes.ShowError(ex.Message); }
		}
		#endregion

		#region Validar_Formato_Hora
		private bool Validar_Formato_Hora(string Hora)
		{
			bool resultado = false;
			try
			{
				if(Hora.Length>0)
				{
					int pos = Hora.IndexOf(":");
					int HH;
					int MM;
				
					if(pos<=0 || pos>2) 
					{
						GESTCRM.Mensajes.ShowError("Formato de Hora Incorrecto: HH:MM");
						return false;
					}

					try{HH=int.Parse(Hora.Substring(0,pos));}
					catch{GESTCRM.Mensajes.ShowError("Formato de Hora Incorrecto: HH:MM"); return false;}

					if(HH<0 ||HH>23) 
					{
						GESTCRM.Mensajes.ShowError("Formato de Hora Incorrecto: HH:MM"); 
						return false;
					}


					try{MM=int.Parse(Hora.Substring(pos+1,Hora.Length-(pos+1)));}
					catch{GESTCRM.Mensajes.ShowError("Formato de Hora Incorrecto: HH:MM"); return false;}

					if(MM<0 ||MM>59) 
					{
						GESTCRM.Mensajes.ShowError("Formato de Hora Incorrecto: HH:MM"); 
						return false;
					}

				}
				resultado = true;
			}
			catch(Exception ex)
			{
				Mensajes.ShowError(ex.Message);
				resultado=false;
			}

			return resultado;
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
				this.cbCentRelacion.SelectedIndex =-1;
				this.cbCentRelacion.SelectedIndex =-1;
				this.txtCentDiaVis.Text = null;
				this.cbCenHorario.SelectedIndex =-1;
				this.cbCenHorario.SelectedIndex =-1;
				this.txtCenManIni.Text = null;
				this.txtCenManFin.Text = null;
				this.txtCenTarIni.Text = null;
				this.txtCenTarFin.Text = null;
				this.txtCenObservVisi.Text = null;
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
					int fila = GESTCRM.Utiles.Buscar_fila_dtTabla(this.dtCentros,"sIdCentro",this.dgCentros[this.dgCentros.CurrentRowIndex,1].ToString());
					if(fila > -1)
					{
						int SelFila = fila;
						if(fila>0) SelFila=fila-1;
						if(this.dtCentros.Rows.Count-1==0) SelFila = -1;
						this.dgCentros.CurrentRowIndex=SelFila;
						GESTCRM.Utiles.Seleccionar_UnaFilaDataGrid(this,this.dgCentros,SelFila);

						this.dtCentros.Rows.RemoveAt(fila);
						this.lblTotCentros.Text = this.dtCentros.Rows.Count.ToString();
						Nuevo_Centro();
					}
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
					   int fila = GESTCRM.Utiles.Buscar_fila_dtTabla(this.dtCentros,"sIdCentro",this.txtCentrosId.Text.ToString());

					   if(fila==-1)
					   {
						   DataRow dvfila= this.dtCentros.NewRow();
						   dvfila["iIdCentro"]=this.Var_iIdCentro;
						   dvfila["sIdCentro"]=this.txtCentrosId.Text.ToString();
						   dvfila["sDescripcion"]=this.txtCentroDesc.Text.ToString();
						   try
						   {
							   dvfila["sIdTipoRelacionCliCen"]=this.cbCentRelacion.SelectedValue.ToString();
							   dvfila["tRelacionTipoCliCen"]=this.cbCentRelacion.GetItemText(this.cbCentRelacion.SelectedItem).ToString();
						   }
						   catch
						   {
							   dvfila["sIdTipoRelacionCliCen"]=null;
							   dvfila["tRelacionTipoCliCen"]=null;
						   }
						   dvfila["sDia"]=this.txtCentDiaVis.Text;
						   try
						   {
							   dvfila["sManTarde"]=this.cbCenHorario.SelectedValue.ToString();
							   dvfila["tManTarde"]=this.cbCenHorario.GetItemText(this.cbCenHorario.SelectedItem).ToString();
						   }
						   catch
						   {
							   dvfila["sManTarde"]=null;dvfila["tManTarde"]=null;
						   }
						   dvfila["sHoraManIni"]=this.txtCenManIni.Text;
						   dvfila["sHoraManFin"]=this.txtCenManFin.Text;
						   dvfila["sHoraTarIni"]=this.txtCenTarIni.Text;
						   dvfila["sHoraTarFin"]=this.txtCenTarFin.Text;
						   dvfila["tObservaciones"]=this.txtCenObservVisi.Text;
					
						   this.dtCentros.Rows.Add(dvfila);
					
						   fila = this.dtCentros.Rows.Count-1;
					   }
					   else
					   {
						   try
						   {
							   this.dtCentros.Rows[fila]["sIdTipoRelacionCliCen"]=this.cbCentRelacion.SelectedValue.ToString();
							   this.dtCentros.Rows[fila]["tRelacionTipoCliCen"]=this.cbCentRelacion.GetItemText(this.cbCentRelacion.SelectedItem).ToString();
						   }
						   catch
						   {
							   this.dtCentros.Rows[fila]["sIdTipoRelacionCliCen"]=null;
							   this.dtCentros.Rows[fila]["tRelacionTipoCliCen"]=null;
						   }
						   this.dtCentros.Rows[fila]["sDia"]=this.txtCentDiaVis.Text;
						   try
						   {
							   this.dtCentros.Rows[fila]["sManTarde"]=this.cbCenHorario.SelectedValue.ToString();
							   this.dtCentros.Rows[fila]["tManTarde"]=this.cbCenHorario.GetItemText(this.cbCenHorario.SelectedItem).ToString();
						   }
						   catch
						   {
							   this.dtCentros.Rows[fila]["sManTarde"]=null;this.dtCentros.Rows[fila]["tManTarde"]=null;
						   }
						   this.dtCentros.Rows[fila]["sHoraManIni"]=this.txtCenManIni.Text.ToString();
						   this.dtCentros.Rows[fila]["sHoraManFin"]=this.txtCenManFin.Text.ToString();
						   this.dtCentros.Rows[fila]["sHoraTarIni"]=this.txtCenTarIni.Text.ToString();
						   this.dtCentros.Rows[fila]["sHoraTarFin"]=this.txtCenTarFin.Text.ToString();
						   this.dtCentros.Rows[fila]["tObservaciones"]=this.txtCenObservVisi.Text.ToString();
					   }
					   this.dgCentros.CurrentRowIndex= fila;
					   GESTCRM.Utiles.Seleccionar_UnaFilaDataGrid(this,this.dgCentros,fila);
					   this.lblTotCentros.Text = this.dtCentros.Rows.Count.ToString();
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
				if(this.txtCentrosId.Text.ToString().Length==0 || this.Var_iIdCentro==-1)
				{
					Mensajes.ShowError("Campo Centro Obligatorio. ");
					return false;
				}
				if(this.cbCentRelacion.SelectedIndex==-1)
				{
					Mensajes.ShowError("Campo Relación Obligatorio. ");
					return false;
				}

				if(this.cbCentRelacion.SelectedValue.ToString()=="0") //Propio
				{
					DataTable dtCentrosAux = Utiles.Inicializar_Tabla(this.dtCentros);
					int fila = Utiles.Buscar_fila_dtTabla(dtCentrosAux,"iIdCentro",this.Var_iIdCentro.ToString());
					if(fila>-1) dtCentrosAux.Rows.RemoveAt(fila);

					int fila1 = Utiles.Buscar_fila_dtTabla(dtCentrosAux,"sIdTipoRelacionCliCen",this.cbCentRelacion.SelectedValue.ToString());
					if(fila1>-1)
					{
						Mensajes.ShowError("Ya existe un Centro Propio, se actualizará como Ocasional. Sólo se puede definir un Centro con Relación=Propio. ");
						this.cbCentRelacion.SelectedValue="1";//Ocasional
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
			}
			catch(Exception ex) {Mensajes.ShowError(ex.Message);}
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
					}
				}
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
					if(this.Var_iIdAccion==-1) Mensajes.ShowError("Este código de Acción no existe.");
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
			try
			{
				if(this.dgAccionesMark.CurrentRowIndex>-1)
				{
					int fila = GESTCRM.Utiles.Buscar_fila_dtTabla(this.dtAccionesMark,"sIdAccion",this.dgAccionesMark[this.dgAccionesMark.CurrentRowIndex,0].ToString());
					if(fila > -1)
					{
						int SelFila = fila;
						if(fila>0) SelFila=fila-1;
						if(this.dtAccionesMark.Rows.Count-1==0) SelFila = -1;
						this.dgAccionesMark.CurrentRowIndex=SelFila;
						GESTCRM.Utiles.Seleccionar_UnaFilaDataGrid(this,this.dgAccionesMark,SelFila);
						
						this.dtAccionesMark.Rows.RemoveAt(fila);
						this.lblTotAcciones.Text = this.dtAccionesMark.Rows.Count.ToString();
						Nueva_Accion();
					}
				}
			}
			catch(Exception ex) { Mensajes.ShowError(ex.Message); }
		}
		#endregion

		#region Actualizar_Accion
		private void Actualizar_Accion()
		{
			try
			{
				if(Validar_Accion())
				{
					int fila = GESTCRM.Utiles.Buscar_fila_dtTabla(this.dtAccionesMark,"sIdAccion",this.txtAccsIdAccion.Text.ToString());

					if(fila==-1)
					{
						DataRow dvfila= this.dtAccionesMark.NewRow();
						dvfila["iIdAccion"]=this.Var_iIdAccion;
						dvfila["sIdAccion"]=this.txtAccsIdAccion.Text.ToString();
						dvfila["dFechaEntrega"]=this.dtpAccFEntrega.Value.Date.ToString("dd/MM/yyyy");
						dvfila["fCantidad"]=Convert.ToInt32(this.nupAccCantidad.Value);
						dvfila["tObservEntrega"]=this.txtAccObservEntrega.Text;
					
						this.dtAccionesMark.Rows.Add(dvfila);
					
						fila = this.dtAccionesMark.Rows.Count-1;
					}
					else
					{
						this.dtAccionesMark.Rows[fila]["dFechaEntrega"]=this.dtpAccFEntrega.Value.Date.ToString("dd/MM/yyyy");
						this.dtAccionesMark.Rows[fila]["fCantidad"]=Convert.ToInt32(this.nupAccCantidad.Value);
						this.dtAccionesMark.Rows[fila]["tObservEntrega"]=this.txtAccObservEntrega.Text;
					}
					this.dgAccionesMark.CurrentRowIndex= fila;
					GESTCRM.Utiles.Seleccionar_UnaFilaDataGrid(this,this.dgAccionesMark,fila);

					this.lblTotAcciones.Text = this.dtAccionesMark.Rows.Count.ToString();
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


		#region dgAficiones_CurrentCellChanged
		private void dgAficiones_CurrentCellChanged(object sender, System.EventArgs e)
		{
			try
			{
				int fila = this.dgAficiones.CurrentRowIndex;

				if(this.dgAficiones[fila,0].ToString().Length==0) this.dgAficiones[fila,0]=" ";

				GESTCRM.Utiles.Seleccionar_UnaFilaDataGrid(this,this.dgAficiones,fila);

				try{this.cbAficiones.SelectedValue = this.dgAficiones[fila,1].ToString();}
				catch{this.cbAficiones.SelectedIndex=-1;}
			}
			catch(Exception ex)
			{
				Mensajes.ShowError(ex.Message);
			}
		}
		#endregion

		#region btActualizarAfic_Click
		private void btActualizarAfic_Click(object sender, System.EventArgs e)
		{
			Actualizar_Aficion();
		}
		#endregion

		#region btEliminarAfic_Click
		private void btEliminarAfic_Click(object sender, System.EventArgs e)
		{
			Eliminar_Aficion();
		}
		#endregion
		
		#region Nueva_Aficion
		private void Nueva_Aficion()
		{
			try
			{
				this.cbAficiones.Focus();
				this.cbAficiones.SelectedIndex=-1;
				this.cbAficiones.SelectedIndex=-1;
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
					int fila = GESTCRM.Utiles.Buscar_filaDataGrid(this,this.dgAficiones,"sIdAficion",this.dgAficiones[this.dgAficiones.CurrentRowIndex,1].ToString());
					
					if(fila>-1)
					{
						CurrencyManager cm = (CurrencyManager)this.BindingContext[this.dgAficiones.DataSource,this.dgAficiones.DataMember];
						DataView dv = (DataView)cm.List;

						int SelFila = fila;
						if(fila>0) SelFila=fila-1;
						if(dv.Count-1==0) SelFila = -1;
						this.dgAficiones.CurrentRowIndex=SelFila;
						GESTCRM.Utiles.Seleccionar_UnaFilaDataGrid(this,this.dgAficiones,SelFila);
						
						dv.AllowDelete=true;
						dv.Delete(fila);
						dv.AllowDelete=false;
						this.lblTotAficiones.Text = dv.Count.ToString();
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
					int fila = GESTCRM.Utiles.Buscar_filaDataGrid(this,this.dgAficiones,"sIdAficion",this.cbAficiones.SelectedValue.ToString());

					CurrencyManager cm = (CurrencyManager)this.BindingContext[this.dgAficiones.DataSource,this.dgAficiones.DataMember];
					DataView dv = (DataView)cm.List;

					if(fila==-1)
					{
						DataRowView dvfila= dv.AddNew();
						dvfila["sIdAficion"]=this.cbAficiones.SelectedValue;
						dvfila["tAficion"]=this.cbAficiones.GetItemText(this.cbAficiones.SelectedItem).ToString();
						fila = dv.Count-1;
					}
					this.dgAficiones.CurrentRowIndex = fila;
					GESTCRM.Utiles.Seleccionar_UnaFilaDataGrid(this,this.dgAficiones,fila);
					this.lblTotAficiones.Text = dv.Count.ToString();
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
				if(this.cbAficiones.SelectedIndex==-1)
				{
					Mensajes.ShowError("Campo Afición Obligatorio. ");
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

		#region frmMClientesCOM_Closing
		private void frmMClientesCOM_Closing(object sender, System.ComponentModel.CancelEventArgs e)
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
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region frmMClientesCOM_Closed
		private void frmMClientesCOM_Closed(object sender, System.EventArgs e)
		{
			this.Dispose();
		}
		#endregion

		#region btGrabar_Click
		private void btGrabar_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (this.Param_TipoAcceso!="C")
				{
					if(Guardar_Cliente())
					{
						DialogResult dr=Mensajes.ShowQuestion(3003);
						if(dr == System.Windows.Forms.DialogResult.Yes)
						{
							this.SalirDesdeGuardar=true;
							this.Close();
						}
					}
				}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region Guardar_Cliente
		private bool Guardar_Cliente()
		{
			bool resultado=true;
			string sMensj="";

			Cursor.Current = Cursors.WaitCursor;

			this.sqlConn.Open();
			this.sqlTran = this.sqlConn.BeginTransaction();

			this.sqlCmdSetCliente.Transaction = this.sqlTran;
			this.sqlCmdSetEspecClientesCOM.Transaction = this.sqlTran;
			this.sqlCmdSetAficClientes_COM.Transaction = this.sqlTran;
			this.sqlCmdSetProdClientesCOM.Transaction = this.sqlTran;
			this.sqlCmdSetCentrosClientesCOM.Transaction = this.sqlTran;
			this.sqlCmdSetCentrosCliCom_Horarios.Transaction = this.sqlTran;
			this.sqlCmdSetAccionesMarkClientes.Transaction = this.sqlTran;


			try
			{
				//Marcar Cliente como Modificado
				this.sqlCmdSetCliente.Parameters["@Accion"].Value=1;
				this.sqlCmdSetCliente.Parameters["@iIdCliente"].Value=this.Param_iIdCliente;

				//Borrar Especialidades existentes
				this.sqlCmdSetEspecClientesCOM.Parameters["@iAccion"].Value=2;
				this.sqlCmdSetEspecClientesCOM.Parameters["@iIdCliente"].Value=this.Param_iIdCliente;
				this.sqlCmdSetEspecClientesCOM.ExecuteNonQuery();
				
				//Grabar Especialidades 
				CurrencyManager cmEsp = (CurrencyManager)this.BindingContext[this.dgEspecialidades.DataSource,this.dgEspecialidades.DataMember];
				DataView dvEspec = (DataView)cmEsp.List;
				for(int i=0; i<dvEspec.Count;i++)
				{
					this.sqlCmdSetEspecClientesCOM.Parameters["@iAccion"].Value=0;
					this.sqlCmdSetEspecClientesCOM.Parameters["@iIdCliente"].Value=this.Param_iIdCliente;
					this.sqlCmdSetEspecClientesCOM.Parameters["@sIdEspecialidad"].Value=dvEspec[i]["sIdEspecialidad"].ToString();

					this.sqlCmdSetEspecClientesCOM.ExecuteNonQuery();
				}

				//Borrar Productos existentes
				this.sqlCmdSetProdClientesCOM.Parameters["@iAccion"].Value=2;
				this.sqlCmdSetProdClientesCOM.Parameters["@iIdCliente"].Value=this.Param_iIdCliente;
				this.sqlCmdSetProdClientesCOM.ExecuteNonQuery();

				//Grabar Productos 
				CurrencyManager cmProd = (CurrencyManager)this.BindingContext[this.dgProductos.DataSource,this.dgProductos.DataMember];
				DataView dvProd = (DataView)cmProd.List;
				for(int i=0; i<dvProd.Count;i++)
				{
					this.sqlCmdSetProdClientesCOM.Parameters["@iAccion"].Value=0;
					this.sqlCmdSetProdClientesCOM.Parameters["@iIdCliente"].Value=this.Param_iIdCliente;
					this.sqlCmdSetProdClientesCOM.Parameters["@sIdProducto"].Value=dvProd[i]["sIdProducto"].ToString();
					this.sqlCmdSetProdClientesCOM.Parameters["@iPrioridad"].Value=int.Parse(dvProd[i]["iPrioridad"].ToString());

					this.sqlCmdSetProdClientesCOM.ExecuteNonQuery();
				}

				//Borrar Horario Centros existentes
				this.sqlCmdSetCentrosCliCom_Horarios.Parameters["@iAccion"].Value=2;
				this.sqlCmdSetCentrosCliCom_Horarios.Parameters["@iIdCliente"].Value=this.Param_iIdCliente;
				this.sqlCmdSetCentrosCliCom_Horarios.ExecuteNonQuery();

				//Borrar Centros
				DataTable dtCentrosOrigen = GESTCRM.Utiles.Inicializar_Tabla(this.dsClientes1.ListaCentros_porCliente_COM);
				int fila = -1;
				for(int i=0;i<dtCentrosOrigen.Rows.Count;i++)
				{
					fila = Utiles.Buscar_fila_dtTabla(this.dtCentros,"iIdCentro",dtCentrosOrigen.Rows[i]["iIdCentro"].ToString());
					if(fila==-1)
					{
						this.sqlCmdSetCentrosClientesCOM.Parameters["@iAccion"].Value=2;
						this.sqlCmdSetCentrosClientesCOM.Parameters["@iIdCliente"].Value=this.Param_iIdCliente;
						this.sqlCmdSetCentrosClientesCOM.Parameters["@iIdCentro"].Value=int.Parse(dtCentrosOrigen.Rows[i]["iIdCentro"].ToString());

						this.sqlCmdSetCentrosClientesCOM.ExecuteNonQuery();
					}
				}

				//Actualizar Centros
				fila=-1;
				for(int i=0;i<this.dtCentros.Rows.Count;i++)
				{
					fila = Utiles.Buscar_fila_dtTabla(dtCentrosOrigen,"iIdCentro",this.dtCentros.Rows[i]["iIdCentro"].ToString());
					if(fila==-1)
					{
						this.sqlCmdSetCentrosClientesCOM.Parameters["@iAccion"].Value=0;
						this.sqlCmdSetCentrosClientesCOM.Parameters["@iIdCliente"].Value=this.Param_iIdCliente;
						this.sqlCmdSetCentrosClientesCOM.Parameters["@iIdCentro"].Value=int.Parse(this.dtCentros.Rows[i]["iIdCentro"].ToString());
						this.sqlCmdSetCentrosClientesCOM.Parameters["@sIdTipoRelacionCliCen"].Value=this.dtCentros.Rows[i]["sIdTipoRelacionCliCen"].ToString();

						this.sqlCmdSetCentrosClientesCOM.ExecuteNonQuery();
					}
					else
					{
						this.sqlCmdSetCentrosClientesCOM.Parameters["@iAccion"].Value=1;
						this.sqlCmdSetCentrosClientesCOM.Parameters["@iIdCliente"].Value=this.Param_iIdCliente;
						this.sqlCmdSetCentrosClientesCOM.Parameters["@iIdCentro"].Value=int.Parse(this.dtCentros.Rows[i]["iIdCentro"].ToString());
						this.sqlCmdSetCentrosClientesCOM.Parameters["@sIdTipoRelacionCliCen"].Value=this.dtCentros.Rows[i]["sIdTipoRelacionCliCen"].ToString();

						this.sqlCmdSetCentrosClientesCOM.ExecuteNonQuery();
					}
				}
				//Grabar Horario Centros
				for(int i=0;i<this.dtCentros.Rows.Count;i++)
				{
					this.sqlCmdSetCentrosCliCom_Horarios.Parameters["@iAccion"].Value=0;
					this.sqlCmdSetCentrosCliCom_Horarios.Parameters["@iIdCliente"].Value=this.Param_iIdCliente;
					this.sqlCmdSetCentrosCliCom_Horarios.Parameters["@iIdCentro"].Value=int.Parse(this.dtCentros.Rows[i]["iIdCentro"].ToString());
					this.sqlCmdSetCentrosCliCom_Horarios.Parameters["@sDia"].Value=int.Parse(this.dtCentros.Rows[i]["iIdCentro"].ToString());
					this.sqlCmdSetCentrosCliCom_Horarios.Parameters["@sManTarde"].Value=this.dtCentros.Rows[i]["sManTarde"].ToString();
					this.sqlCmdSetCentrosCliCom_Horarios.Parameters["@sHoraManIni"].Value=this.dtCentros.Rows[i]["sHoraManIni"].ToString();
					this.sqlCmdSetCentrosCliCom_Horarios.Parameters["@sHoraManFin"].Value=this.dtCentros.Rows[i]["sHoraManFin"].ToString();
					this.sqlCmdSetCentrosCliCom_Horarios.Parameters["@sHoraTarIni"].Value=this.dtCentros.Rows[i]["sHoraTarIni"].ToString();
					this.sqlCmdSetCentrosCliCom_Horarios.Parameters["@sHoraTarFin"].Value=this.dtCentros.Rows[i]["sHoraTarFin"].ToString();
					this.sqlCmdSetCentrosCliCom_Horarios.Parameters["@tObservaciones"].Value=this.dtCentros.Rows[i]["tObservaciones"].ToString();

					this.sqlCmdSetCentrosCliCom_Horarios.ExecuteNonQuery();
				}

				//Borrar Acciones Existentes
				this.sqlCmdSetAccionesMarkClientes.Parameters["@iAccion"].Value=2;
				this.sqlCmdSetAccionesMarkClientes.Parameters["@iIdCliente"].Value=this.Param_iIdCliente;
				this.sqlCmdSetAccionesMarkClientes.ExecuteNonQuery();

				//Grabar Acciones
				for(int i=0;i<this.dtAccionesMark.Rows.Count;i++)
				{
					this.sqlCmdSetAccionesMarkClientes.Parameters["@iAccion"].Value=0;
					this.sqlCmdSetAccionesMarkClientes.Parameters["@iIdCliente"].Value=this.Param_iIdCliente;
					this.sqlCmdSetAccionesMarkClientes.Parameters["@iIdAccion"].Value=int.Parse(this.dtAccionesMark.Rows[i]["iIdAccion"].ToString());
					this.sqlCmdSetAccionesMarkClientes.Parameters["@dFechaEntrega"].Value=DateTime.Parse(this.dtAccionesMark.Rows[i]["dFechaEntrega"].ToString()).Date;
					this.sqlCmdSetAccionesMarkClientes.Parameters["@fCantidad"].Value=int.Parse(this.dtAccionesMark.Rows[i]["fCantidad"].ToString());
					this.sqlCmdSetAccionesMarkClientes.Parameters["@tObservaciones"].Value=this.dtAccionesMark.Rows[i]["tObservEntrega"].ToString();

					this.sqlCmdSetAccionesMarkClientes.ExecuteNonQuery();
				}


				//Borrar Aficiones existentes
				this.sqlCmdSetAficClientes_COM.Parameters["@iAccion"].Value=2;
				this.sqlCmdSetAficClientes_COM.Parameters["@iIdCliente"].Value=this.Param_iIdCliente;
				this.sqlCmdSetAficClientes_COM.ExecuteNonQuery();
				
				//Grabar Aficiones 
				CurrencyManager cmAfi = (CurrencyManager)this.BindingContext[this.dgAficiones.DataSource,this.dgAficiones.DataMember];
				DataView dvAfic = (DataView)cmAfi.List;
				for(int i=0; i<dvAfic.Count;i++)
				{
					this.sqlCmdSetAficClientes_COM.Parameters["@iAccion"].Value=0;
					this.sqlCmdSetAficClientes_COM.Parameters["@iIdCliente"].Value=this.Param_iIdCliente;
					this.sqlCmdSetAficClientes_COM.Parameters["@sIdAficion"].Value=dvAfic[i]["sIdAficion"].ToString();

					this.sqlCmdSetAficClientes_COM.ExecuteNonQuery();
				}

				this.sqlTran.Commit();
				resultado=true;
			}
			catch(System.Data.SqlClient.SqlException ex)
			{
				sMensj ="Error al actualizar Cliente: ";
				foreach(System.Data.SqlClient.SqlError Err in ex.Errors)
				{
					if (Err.Number == 2627)
					{
						sMensj += "Código de Cliente ya existente";
						break;
					}
					if (Err.Number != 3621)
					{
						sMensj +=Err.Number.ToString()+" - "+Err.Message.ToString();
					}
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
			Cursor.Current = Cursors.Default;

			return resultado;
		}
		#endregion

		#region Activar_Formulario
		private void Activar_Formulario()
		{
			try
			{
				Activar_AccionesMark();

				this.pnCRM.Focus();

				if(this.Param_TipoAcceso=="C")
				{
					this.ucBotoneraSecundaria1.Activar_botonera(true,false,false,false,false,false);
					Utiles.Activar_Panel(this.pnCRM,false);
					Utiles.Activar_Panel(this.pnAccionesMark,false);
					Utiles.Activar_Panel(this.pnAmpliacion,false);
				}
				else
				{
					this.ucBotoneraSecundaria1.Activar_botonera(true,false,false,false,true,false);
				}
			}
			catch(Exception ex) { Mensajes.ShowError(ex.Message); }
		}
		#endregion



	}
}

