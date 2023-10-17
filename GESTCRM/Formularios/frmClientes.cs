using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using GESTCRM.CRMControles;

namespace GESTCRM.Formularios
{
	/// <summary>
	/// Descripción breve de frmClientes.
	/// </summary>
	public class frmClientes : System.Windows.Forms.Form
	{
        private const int K_TOP_RANKING = 5; //---- GSG (28/01/2014)

		System.Drawing.Font fuenteBold; 
		System.Drawing.Font fuenteNoBold; 
		//		Point BotonEspecProd;
		//		Point BotonMasDatos;
		//		Point BotonCentros;
		Point BotonDatosSAP;
		Point BotonDatosCOM;
		//		Point BotonCentrosContact;

		string Var_Tipo;
		int    Var_fila;
		int	   Var_iIdCliente;
		int    Var_iIdPoblacion;
		int    Var_iEstado;
        string Var_NombreCliente; //---- GSG (04/12/2012)
        string Var_CodSAP; //---- GSG (25/03/2014)
        //---- GSG (13/03/2015)
        int _posYButtons = 454;
        //---- GSG (13/03/2019)
        //int _posYPanels = 432;
        int _posYPanels = 485;

		string ParamI_TipoCliente;

		private System.Windows.Forms.Label lblTipoMedio;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.Panel pnlBClientes;
		private System.ComponentModel.IContainer components;
		private System.Data.SqlClient.SqlConnection sqlConn;
		private System.Windows.Forms.ComboBox cboTipoCli;
		private System.Windows.Forms.Label lblTipoCli;
		private System.Windows.Forms.ComboBox cboCategoria;
		private System.Windows.Forms.Label lblCategoria;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txbCP;
		private System.Windows.Forms.TextBox txbNombre;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label lblCentro;
		private System.Windows.Forms.ToolTip toolTipClientes;
		
		//Variables globales.
		//		public static string Var1 = "2";
		private System.Windows.Forms.TextBox txbBPoblacion;
		private System.Windows.Forms.Button btnBuscPob;
		private System.Windows.Forms.Label label1;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand3;


		//Variables publicas a todo el formulario
		//		public static string TCliente = "";
		//		public DataTable dtProductos = new DataTable();
		//		public DataTable dtCentros = new DataTable();
		//		public DataTable dtAccmark = new DataTable();
		//		public DataTable dtEspecialidades = new DataTable();
		private System.Windows.Forms.DataGridTextBoxColumn Col0;
		private System.Windows.Forms.DataGridTextBoxColumn Col1;
		private System.Windows.Forms.DataGridTextBoxColumn Col2;
		private System.Windows.Forms.DataGridTextBoxColumn Col3;
		private System.Windows.Forms.DataGridTextBoxColumn Col4;
		private System.Windows.Forms.DataGridTextBoxColumn Col5;
		private System.Windows.Forms.DataGridTextBoxColumn Col6;
		private System.Windows.Forms.DataGridTextBoxColumn Col7;
		private System.Windows.Forms.DataGridTextBoxColumn Col8;
		private System.Windows.Forms.DataGridTextBoxColumn Col9;
		private System.Windows.Forms.DataGridTextBoxColumn Col10;
		private System.Windows.Forms.DataGridTextBoxColumn Col11;
		private System.Windows.Forms.DataGridTextBoxColumn Col12;
		private System.Windows.Forms.DataGridTextBoxColumn Col13;
		private System.Windows.Forms.DataGridTextBoxColumn Col14;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGrid dtgGeneral;
		private System.Windows.Forms.Label lblNumRegistros;

		//		public DataTable dt = new DataTable();
		private System.Data.SqlClient.SqlDataAdapter sqldaListaClientes;
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
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn17;
		private System.Windows.Forms.Button btBuscar;
		private System.Data.SqlClient.SqlDataAdapter sqldaListaDelegados;
		private System.Data.SqlClient.SqlDataAdapter sqldaTipoCliente;
		private System.Windows.Forms.ComboBox cbDelegado;
		private System.Windows.Forms.TextBox txtsIdCentro;
		private System.Windows.Forms.TextBox txtsIdCliente;
		private System.Windows.Forms.Label lblCliente;
		private System.Windows.Forms.TextBox txtsCentro;
		private System.Windows.Forms.Button btBuscarCentro;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn18;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn19;
		private System.Windows.Forms.Panel pnDatosSAP;
		private System.Windows.Forms.Label lblsIdCliente;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.RadioButton rbPotencial_SAP;
		private System.Windows.Forms.TextBox txtsIdCliente_SAP;
		private System.Windows.Forms.TextBox txtNombre_SAP;
		private System.Windows.Forms.TextBox txtDireccion_SAP;
		private System.Windows.Forms.TextBox txtCP_SAP;
		private System.Windows.Forms.TextBox txtProvincia_SAP;
		private System.Windows.Forms.TextBox txtCategoría_SAP;
		private System.Windows.Forms.TextBox txtPoblacion_SAP;
		private System.Windows.Forms.TextBox txtTelefono_SAP;
		private System.Windows.Forms.TextBox txtTelefono2_SAP;
		private System.Windows.Forms.TextBox txtTeles_SAP;
		private System.Windows.Forms.TextBox txtTeleFax_SAP;
		private System.Windows.Forms.TextBox txtNIF_SAP;
		private System.Windows.Forms.TextBox txtDatosBancarios_SAP;
		private System.Windows.Forms.TextBox txtCondPago_SAP;
		private System.Windows.Forms.TextBox txtGrupoCli_SAP;
		private System.Windows.Forms.TextBox txtDescCondPago_SAP;
		private System.Windows.Forms.TextBox txtDescGrupoCli_SAP;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtTipo_SAP;
		private System.Windows.Forms.Panel pnDatosCOM;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label23;
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
		private System.Windows.Forms.TextBox txtTipo_COM;
		private System.Windows.Forms.TextBox txtPoblacion_COM;
		private System.Windows.Forms.TextBox txtCategoria_COM;
		private System.Windows.Forms.TextBox txtProvincia_COM;
		private System.Windows.Forms.TextBox txtCP_COM;
		private System.Windows.Forms.TextBox txtDireccion_COM;
		private System.Windows.Forms.TextBox txtNombre_COM;
		private System.Windows.Forms.TextBox txtsIdCliente_COM;
		private System.Windows.Forms.TextBox txtEMail_COM;
		private System.Windows.Forms.TextBox txtFax_COM;
		private System.Windows.Forms.TextBox txtTelMovil_COM;
		private System.Windows.Forms.TextBox txtTelefono_COM;
		private System.Windows.Forms.TextBox txtNIF_COM;
		private System.Windows.Forms.TextBox txtNumColegiado_COM;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.TextBox txtTipoCliente_COM;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Button btAccionesMark;
		private System.Windows.Forms.Label label38;
		private System.Windows.Forms.Label label40;
		private System.Windows.Forms.TextBox txtFecNacim_COM;
		private System.Windows.Forms.TextBox txtObservaciones_COM;
		private System.Windows.Forms.Panel pnAccionesMark;
		private System.Windows.Forms.DataGrid dgAccionesMark;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle2;
		private System.Data.SqlClient.SqlDataAdapter sqldaListaAccionesMark;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn20;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn21;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn22;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn23;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn24;
		private System.Windows.Forms.Label lblTotAccionesMark;
		private GESTCRM.Formularios.DataSets.dsClientes dsClientes1;
		private System.Data.SqlClient.SqlDataAdapter sqldaListaEspecClientes_COM;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand6;
		private System.Data.SqlClient.SqlDataAdapter sqldaListaProdClientes_COM;
		private System.Windows.Forms.DataGrid dgEspecialidades;
		private System.Windows.Forms.DataGrid dgProductos;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle3;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn25;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle4;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn26;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn27;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn28;
		private System.Windows.Forms.Label lblTotEspecialidades;
		private System.Windows.Forms.Label lblTotProductos;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand7;
		private System.Windows.Forms.DataGrid dgCentrosCOM;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle5;
		private System.Data.SqlClient.SqlDataAdapter sqlListaCentros_porClienteCOM;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn29;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn30;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn31;
		private System.Windows.Forms.Label lblTotCentrosCOM;
		private System.Data.SqlClient.SqlDataAdapter sqldaListaCentros_porCliente_SAP;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand9;
		private System.Data.SqlClient.SqlDataAdapter sqldaListaContactos_porCliente_SAP;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand10;
		private System.Windows.Forms.DataGrid dgCentrosSAP;
		private System.Windows.Forms.DataGrid dgContactosSAP;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle6;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle7;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn32;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn33;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn34;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn35;
		private System.Windows.Forms.Label lblTotContactosSAP;
		private System.Windows.Forms.Label lblTotCentrosSAP;
		private System.Windows.Forms.Label label48;
		private System.Windows.Forms.ComboBox cbRelacionConCentro;
		private System.Data.SqlClient.SqlDataAdapter sqldaListaRelacionClienteCentro;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand11;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem menuNuevo;
		private System.Windows.Forms.MenuItem menuEditar;
		private System.Windows.Forms.MenuItem menuEliminar;
		private GESTCRM.Controles.ucBotoneraSecundaria ucBotoneraSecundaria1;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand4;
		private System.Data.SqlClient.SqlDataAdapter sqldaListaTipoClasificacion;
		//		private GESTCRM.Controles.LabelGradient lblGBusquedaCli;
		private GESTCRM.Controles.LabelGradient labelGradient1;
		private System.Windows.Forms.Panel panel1;
		private GESTCRM.Controles.LabelGradient labelGradient2;
		private System.Windows.Forms.Panel panel2;
		private GESTCRM.Controles.LabelGradient labelGradient3;
		private System.Windows.Forms.Panel panel3;
		private GESTCRM.Controles.LabelGradient labelGradient4;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Panel panel5;
		private GESTCRM.Controles.LabelGradient labelGradient7;
		private System.Windows.Forms.Panel panel6;
		private GESTCRM.Controles.LabelGradient labelGradient8;
		private System.Windows.Forms.Panel panel7;
		private GESTCRM.Controles.LabelGradient labelGradient9;
		private System.Windows.Forms.Panel panel8;
		private GESTCRM.Controles.LabelGradient labelGradient10;
		private System.Windows.Forms.Label lblTotAficiones;
		private System.Windows.Forms.Button btCRM;
		private System.Windows.Forms.Panel pnCRM_COM;
		private System.Windows.Forms.Panel pnCRM_SAP;
		private GESTCRM.Controles.LabelGradient lblGBusquedaCli;
		private System.Windows.Forms.Button btMayoristas;
		private System.Windows.Forms.Button btDatosCliente;
		private System.Windows.Forms.Panel pnMayoristas;
		private System.Windows.Forms.Panel panel9;
		private GESTCRM.Controles.LabelGradient labelGradient5;
		private GESTCRM.CRMControles.ucUltimoPedido ucUltimoPedido_SAP;
		private System.Windows.Forms.Label lblTotMayoristas;
		private System.Data.SqlClient.SqlDataAdapter sqldaListaMayoristasClientes_SAP;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle8;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn36;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn37;
		private System.Windows.Forms.DataGrid dgMayoristas;
		private System.Data.SqlClient.SqlDataAdapter sqldaListaAficClientes_COM;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand13;
		private System.Windows.Forms.DataGrid dgAficiones;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle9;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn38;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn39;
		private GESTCRM.CRMControles.ucRankingMatCli ucRankingMatCli_SAP;
		private GESTCRM.CRMControles.ucUltimasVisitas ucUltimasVisitas_SAP;
		private GESTCRM.CRMControles.ucUltimasVisitas ucUltimasVisitas_COM;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand8;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn40;
		private System.Windows.Forms.Label lblToolTipBoton;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn41;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		private System.Windows.Forms.TextBox txbApellidos1;
		private System.Windows.Forms.TextBox txtsApellidos2;
		private System.Windows.Forms.Label label39;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn42;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand5;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand12;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn43;
		private System.Windows.Forms.ComboBox cboEstado;
		private System.Windows.Forms.Label lblEstado;
		private System.Windows.Forms.ComboBox cboRed;
		private System.Windows.Forms.Label label41;
		private System.Data.SqlClient.SqlDataAdapter sqldaListaRedes;
		private System.Data.SqlClient.SqlCommand sqlCommand1;
		private System.Data.SqlClient.SqlDataAdapter sqldaListaEstado;
		private System.Data.SqlClient.SqlCommand sqlCommand2;
		private System.Data.SqlClient.SqlCommand sqlCmdEliminarCLiente;
		private GESTCRM.Controles.LabelGradient labelGradient6;
		private System.Windows.Forms.DataGridTextBoxColumn dtgtEstado;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumnRed;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn44;
		private GESTCRM.Formularios.DataSets.dsClientes dsClientes2;
		private DataGridTextBoxColumn dataGridTextBoxColumn50;
		private DataGridTextBoxColumn dataGridTextBoxColumn51;
		private DataGridTextBoxColumn dataGridTextBoxColumn52;
		private DataGridTextBoxColumn dataGridTextBoxColumn53;
		private DataGridTextBoxColumn dataGridTextBoxColumn54;
		private DataGridTextBoxColumn dataGridTextBoxColumn45;
		private DataGridTextBoxColumn dataGridTextBoxColumn46;
		private DataGridTextBoxColumn dataGridTextBoxColumn47;
        private GESTCRM.Controles.LabelGradient lblTitulo;
        private Label label35;
        private DataGridTextBoxColumn dataGridTextBoxColumn48;
        private DataGridTextBoxColumn dataGridTextBoxColumn49;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumniEstado;
        private System.Data.SqlClient.SqlDataAdapter sqldaListaAreasporCliente_SAP; //---- GSG (27/05/2013)
        private System.Data.SqlClient.SqlDataAdapter sqldaListaProgInfCliente_SAP; //---- GSG (27/05/2013)
        private System.Data.SqlClient.SqlCommand sqlSelectCommandListaAreasporCliente_SAP;
        private Button btFOnLine;
        private Panel pnFOnLine; //---- GSG (27/05/2013)
        private System.Data.SqlClient.SqlCommand sqlSelectCommandListaProgInfporCliente_SAP; //---- GSG (27/05/2013)
        private ComboBox cbFOLadival;
        private Label label44;
        private ComboBox cbFOOperativa;
        private Label label43;
        private TextBox txtFONombreOnLine;
        private Label label42;
        private Panel panel10;
        private TextBox txtFONombre;
        private TextBox txtFOCodCli;
        private Label label36;
        private Label label37;
        private TextBox txtFOUrl;
        private Label label45;
        private Button btFOEliminar;
        //---- GSG (04/12/2013)
        private Button btFOActualizar;
        private System.Data.SqlClient.SqlDataAdapter sqldaListaClientesOnLine;
        private System.Data.SqlClient.SqlCommand sqlCmdListaClientesOnLine;
        private Panel pnCRM_SAP_New;
        protected System.Data.SqlClient.SqlCommand sqlCmdSetClientesOnLine;
        private dsMateriales dsMateriales1;
        //---- GSG (28/01/2014)
        private System.Data.SqlClient.SqlDataAdapter sqldaListaLineasPedidoRentAnual;
        private DataSets.dsPedidos dsPedidos1;
        private System.Data.SqlClient.SqlCommand sqlSelectLineasPedidoRentAnual;
        private System.Data.SqlClient.SqlCommand sqlCmdGetRentabilidadColor;
        private SqlCommand sqlCmdGetVentasMatFciaPorCanal;
        private SqlDataAdapter sqldaGetVentasMatFciaPorCanal;
        private DataSets.dsGraphs dsGraphs1;
        private SqlCommand sqlCmdGetImporteVentas;
        private SqlDataAdapter sqldaGetImporteVentas;
        private SqlDataAdapter sqldaGetRankingVentasMat;
        private SqlCommand sqlCmdGetRankingVentasMat;
        private GroupBox gbClubs;
        private TextBox txtGarantias4;
        private TextBox txtGarantias3;
        private Label label49;
        private TextBox txtGarantias2;
        private TextBox txtGarantias;
        private TextBox txtGarantias1;
        private Label label50;
        private Label label51;
        private Label label52;
        private Label label53;
        private Button button1;
        private DataGrid dgAreasCOM;
        private Panel panel11;
        private Label label46;
        private Controles.LabelGradient labelGradient11;
        private System.Data.SqlClient.SqlCommand sqlCmdGetRentUltPedCli;



		public frmClientes(string TipoCliente)
		{
            InitializeComponent();

            //---- GSG (06/03/2021)
            Utiles.GetConfigConnection();
            this.sqlConn.ConnectionString = Utiles._connection.ConnectionString.ToString();

            
			this.ParamI_TipoCliente = TipoCliente;
			this.Var_iIdPoblacion=-1;
			this.Var_iIdCliente=-1;
            Var_NombreCliente = ""; //---- GSG (04/12/2013)
            Var_CodSAP = ""; //---- GSG (25/03/2014)
		}

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClientes));
            this.pnlBClientes = new System.Windows.Forms.Panel();
            this.label35 = new System.Windows.Forms.Label();
            this.lblTitulo = new GESTCRM.Controles.LabelGradient();
            this.cboEstado = new System.Windows.Forms.ComboBox();
            this.dsClientes1 = new GESTCRM.Formularios.DataSets.dsClientes();
            this.lblEstado = new System.Windows.Forms.Label();
            this.cboRed = new System.Windows.Forms.ComboBox();
            this.label41 = new System.Windows.Forms.Label();
            this.cboCategoria = new System.Windows.Forms.ComboBox();
            this.txtsApellidos2 = new System.Windows.Forms.TextBox();
            this.cbRelacionConCentro = new System.Windows.Forms.ComboBox();
            this.label48 = new System.Windows.Forms.Label();
            this.txtsCentro = new System.Windows.Forms.TextBox();
            this.txtsIdCliente = new System.Windows.Forms.TextBox();
            this.txbBPoblacion = new System.Windows.Forms.TextBox();
            this.btnBuscPob = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtsIdCentro = new System.Windows.Forms.TextBox();
            this.txbCP = new System.Windows.Forms.TextBox();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.cboTipoCli = new System.Windows.Forms.ComboBox();
            this.txbApellidos1 = new System.Windows.Forms.TextBox();
            this.cbDelegado = new System.Windows.Forms.ComboBox();
            this.btBuscar = new System.Windows.Forms.Button();
            this.lblCentro = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTipoCli = new System.Windows.Forms.Label();
            this.txbNombre = new System.Windows.Forms.TextBox();
            this.label39 = new System.Windows.Forms.Label();
            this.btBuscarCentro = new System.Windows.Forms.Button();
            this.lblTipoMedio = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblGBusquedaCli = new GESTCRM.Controles.LabelGradient();
            this.label2 = new System.Windows.Forms.Label();
            this.labelGradient1 = new GESTCRM.Controles.LabelGradient();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.sqlConn = new System.Data.SqlClient.SqlConnection();
            this.toolTipClientes = new System.Windows.Forms.ToolTip(this.components);
            this.sqldaListaDelegados = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
            this.sqldaTipoCliente = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
            this.sqldaListaTipoClasificacion = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand4 = new System.Data.SqlClient.SqlCommand();
            this.dtgGeneral = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn19 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn9 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn7 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn8 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn42 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn5 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn6 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn10 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn11 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn12 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn13 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn14 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn15 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn17 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn16 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dtgtEstado = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn18 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn41 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumniEstado = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumnRed = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn50 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn51 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn52 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn53 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn54 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn45 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn46 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn47 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.Col0 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.Col1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.Col2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.Col3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.Col4 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.Col5 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.Col6 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.Col7 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.Col8 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.Col9 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.Col10 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.Col11 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.Col12 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.Col13 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.Col14 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.lblNumRegistros = new System.Windows.Forms.Label();
            this.sqldaListaClientes = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
            this.pnDatosSAP = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lblTotCentrosSAP = new System.Windows.Forms.Label();
            this.labelGradient8 = new GESTCRM.Controles.LabelGradient();
            this.dgCentrosSAP = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle6 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn49 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn34 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn35 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dgContactosSAP = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle7 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn48 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn33 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn32 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.lblTotContactosSAP = new System.Windows.Forms.Label();
            this.labelGradient7 = new GESTCRM.Controles.LabelGradient();
            this.txtTipo_SAP = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.rbPotencial_SAP = new System.Windows.Forms.RadioButton();
            this.txtDescGrupoCli_SAP = new System.Windows.Forms.TextBox();
            this.txtDescCondPago_SAP = new System.Windows.Forms.TextBox();
            this.txtGrupoCli_SAP = new System.Windows.Forms.TextBox();
            this.txtCondPago_SAP = new System.Windows.Forms.TextBox();
            this.txtDatosBancarios_SAP = new System.Windows.Forms.TextBox();
            this.txtNIF_SAP = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txtTeleFax_SAP = new System.Windows.Forms.TextBox();
            this.txtTeles_SAP = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTelefono2_SAP = new System.Windows.Forms.TextBox();
            this.txtTelefono_SAP = new System.Windows.Forms.TextBox();
            this.txtPoblacion_SAP = new System.Windows.Forms.TextBox();
            this.txtCategoría_SAP = new System.Windows.Forms.TextBox();
            this.txtProvincia_SAP = new System.Windows.Forms.TextBox();
            this.txtCP_SAP = new System.Windows.Forms.TextBox();
            this.txtDireccion_SAP = new System.Windows.Forms.TextBox();
            this.txtNombre_SAP = new System.Windows.Forms.TextBox();
            this.txtsIdCliente_SAP = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblsIdCliente = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.dgAreasCOM = new System.Windows.Forms.DataGrid();
            this.btMayoristas = new System.Windows.Forms.Button();
            this.pnDatosCOM = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.label46 = new System.Windows.Forms.Label();
            this.labelGradient11 = new GESTCRM.Controles.LabelGradient();
            this.dgAficiones = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle9 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn38 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.lblTotAficiones = new System.Windows.Forms.Label();
            this.labelGradient10 = new GESTCRM.Controles.LabelGradient();
            this.txtTipoCliente_COM = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txtNumColegiado_COM = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtNIF_COM = new System.Windows.Forms.TextBox();
            this.txtTipo_COM = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtEMail_COM = new System.Windows.Forms.TextBox();
            this.txtFax_COM = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.txtTelMovil_COM = new System.Windows.Forms.TextBox();
            this.txtTelefono_COM = new System.Windows.Forms.TextBox();
            this.txtPoblacion_COM = new System.Windows.Forms.TextBox();
            this.txtCategoria_COM = new System.Windows.Forms.TextBox();
            this.txtProvincia_COM = new System.Windows.Forms.TextBox();
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
            this.label32 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.txtFecNacim_COM = new System.Windows.Forms.TextBox();
            this.txtObservaciones_COM = new System.Windows.Forms.TextBox();
            this.label40 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.btAccionesMark = new System.Windows.Forms.Button();
            this.btCRM = new System.Windows.Forms.Button();
            this.pnAccionesMark = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.lblTotAccionesMark = new System.Windows.Forms.Label();
            this.labelGradient9 = new GESTCRM.Controles.LabelGradient();
            this.dgAccionesMark = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn20 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn21 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn22 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn23 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn24 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.pnCRM_COM = new System.Windows.Forms.Panel();
            this.ucUltimasVisitas_COM = new GESTCRM.CRMControles.ucUltimasVisitas();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblToolTipBoton = new System.Windows.Forms.Label();
            this.labelGradient2 = new GESTCRM.Controles.LabelGradient();
            this.dgCentrosCOM = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle5 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn29 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn30 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn31 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn44 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn40 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.lblTotCentrosCOM = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblTotProductos = new System.Windows.Forms.Label();
            this.labelGradient4 = new GESTCRM.Controles.LabelGradient();
            this.dgProductos = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle4 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn26 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn27 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn28 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblTotEspecialidades = new System.Windows.Forms.Label();
            this.labelGradient3 = new GESTCRM.Controles.LabelGradient();
            this.dgEspecialidades = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle3 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn25 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.pnCRM_SAP = new System.Windows.Forms.Panel();
            this.ucUltimasVisitas_SAP = new GESTCRM.CRMControles.ucUltimasVisitas();
            this.ucRankingMatCli_SAP = new GESTCRM.CRMControles.ucRankingMatCli();
            this.ucUltimoPedido_SAP = new GESTCRM.CRMControles.ucUltimoPedido();
            this.sqldaListaAccionesMark = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand5 = new System.Data.SqlClient.SqlCommand();
            this.sqldaListaEspecClientes_COM = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand6 = new System.Data.SqlClient.SqlCommand();
            this.sqldaListaProdClientes_COM = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand7 = new System.Data.SqlClient.SqlCommand();
            this.sqlListaCentros_porClienteCOM = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand8 = new System.Data.SqlClient.SqlCommand();
            this.sqldaListaCentros_porCliente_SAP = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand9 = new System.Data.SqlClient.SqlCommand();
            this.sqldaListaContactos_porCliente_SAP = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand10 = new System.Data.SqlClient.SqlCommand();
            this.sqldaListaRelacionClienteCentro = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand11 = new System.Data.SqlClient.SqlCommand();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.menuNuevo = new System.Windows.Forms.MenuItem();
            this.menuEditar = new System.Windows.Forms.MenuItem();
            this.menuEliminar = new System.Windows.Forms.MenuItem();
            this.ucBotoneraSecundaria1 = new GESTCRM.Controles.ucBotoneraSecundaria();
            this.labelGradient6 = new GESTCRM.Controles.LabelGradient();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btDatosCliente = new System.Windows.Forms.Button();
            this.pnMayoristas = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.dgMayoristas = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle8 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn43 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn36 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn37 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn39 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.lblTotMayoristas = new System.Windows.Forms.Label();
            this.labelGradient5 = new GESTCRM.Controles.LabelGradient();
            this.sqldaListaMayoristasClientes_SAP = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand12 = new System.Data.SqlClient.SqlCommand();
            this.sqldaListaAficClientes_COM = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand13 = new System.Data.SqlClient.SqlCommand();
            this.sqldaListaRedes = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqldaListaEstado = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCommand2 = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdEliminarCLiente = new System.Data.SqlClient.SqlCommand();
            this.dsClientes2 = new GESTCRM.Formularios.DataSets.dsClientes();
            this.sqldaListaAreasporCliente_SAP = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommandListaAreasporCliente_SAP = new System.Data.SqlClient.SqlCommand();
            this.sqldaListaProgInfCliente_SAP = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommandListaProgInfporCliente_SAP = new System.Data.SqlClient.SqlCommand();
            this.sqldaListaClientesOnLine = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCmdListaClientesOnLine = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdSetClientesOnLine = new System.Data.SqlClient.SqlCommand();
            this.sqldaListaLineasPedidoRentAnual = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectLineasPedidoRentAnual = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdGetRentabilidadColor = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdGetRentUltPedCli = new System.Data.SqlClient.SqlCommand();
            this.btFOnLine = new System.Windows.Forms.Button();
            this.pnFOnLine = new System.Windows.Forms.Panel();
            this.btFOEliminar = new System.Windows.Forms.Button();
            this.btFOActualizar = new System.Windows.Forms.Button();
            this.txtFOUrl = new System.Windows.Forms.TextBox();
            this.label45 = new System.Windows.Forms.Label();
            this.cbFOLadival = new System.Windows.Forms.ComboBox();
            this.label44 = new System.Windows.Forms.Label();
            this.cbFOOperativa = new System.Windows.Forms.ComboBox();
            this.label43 = new System.Windows.Forms.Label();
            this.txtFONombreOnLine = new System.Windows.Forms.TextBox();
            this.label42 = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.txtFONombre = new System.Windows.Forms.TextBox();
            this.txtFOCodCli = new System.Windows.Forms.TextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.pnCRM_SAP_New = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.gbClubs = new System.Windows.Forms.GroupBox();
            this.txtGarantias4 = new System.Windows.Forms.TextBox();
            this.txtGarantias3 = new System.Windows.Forms.TextBox();
            this.label49 = new System.Windows.Forms.Label();
            this.txtGarantias2 = new System.Windows.Forms.TextBox();
            this.txtGarantias = new System.Windows.Forms.TextBox();
            this.txtGarantias1 = new System.Windows.Forms.TextBox();
            this.label50 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.dsMateriales1 = new GESTCRM.Formularios.dsMateriales();
            this.dsPedidos1 = new GESTCRM.Formularios.DataSets.dsPedidos();
            this.sqlCmdGetVentasMatFciaPorCanal = new System.Data.SqlClient.SqlCommand();
            this.sqldaGetVentasMatFciaPorCanal = new System.Data.SqlClient.SqlDataAdapter();
            this.dsGraphs1 = new GESTCRM.Formularios.DataSets.dsGraphs();
            this.sqlCmdGetImporteVentas = new System.Data.SqlClient.SqlCommand();
            this.sqldaGetImporteVentas = new System.Data.SqlClient.SqlDataAdapter();
            this.sqldaGetRankingVentasMat = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCmdGetRankingVentasMat = new System.Data.SqlClient.SqlCommand();
            this.pnlBClientes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsClientes1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgGeneral)).BeginInit();
            this.pnDatosSAP.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCentrosSAP)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgContactosSAP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgAreasCOM)).BeginInit();
            this.pnDatosCOM.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgAficiones)).BeginInit();
            this.pnAccionesMark.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgAccionesMark)).BeginInit();
            this.pnCRM_COM.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCentrosCOM)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgProductos)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgEspecialidades)).BeginInit();
            this.pnCRM_SAP.SuspendLayout();
            this.panel4.SuspendLayout();
            this.pnMayoristas.SuspendLayout();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgMayoristas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsClientes2)).BeginInit();
            this.pnFOnLine.SuspendLayout();
            this.panel10.SuspendLayout();
            this.pnCRM_SAP_New.SuspendLayout();
            this.gbClubs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsMateriales1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPedidos1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsGraphs1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBClientes
            // 
            this.pnlBClientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnlBClientes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBClientes.Controls.Add(this.label35);
            this.pnlBClientes.Controls.Add(this.lblTitulo);
            this.pnlBClientes.Controls.Add(this.cboEstado);
            this.pnlBClientes.Controls.Add(this.lblEstado);
            this.pnlBClientes.Controls.Add(this.cboRed);
            this.pnlBClientes.Controls.Add(this.label41);
            this.pnlBClientes.Controls.Add(this.cboCategoria);
            this.pnlBClientes.Controls.Add(this.txtsApellidos2);
            this.pnlBClientes.Controls.Add(this.cbRelacionConCentro);
            this.pnlBClientes.Controls.Add(this.label48);
            this.pnlBClientes.Controls.Add(this.txtsCentro);
            this.pnlBClientes.Controls.Add(this.txtsIdCliente);
            this.pnlBClientes.Controls.Add(this.txbBPoblacion);
            this.pnlBClientes.Controls.Add(this.btnBuscPob);
            this.pnlBClientes.Controls.Add(this.label1);
            this.pnlBClientes.Controls.Add(this.txtsIdCentro);
            this.pnlBClientes.Controls.Add(this.txbCP);
            this.pnlBClientes.Controls.Add(this.lblCategoria);
            this.pnlBClientes.Controls.Add(this.cboTipoCli);
            this.pnlBClientes.Controls.Add(this.txbApellidos1);
            this.pnlBClientes.Controls.Add(this.cbDelegado);
            this.pnlBClientes.Controls.Add(this.btBuscar);
            this.pnlBClientes.Controls.Add(this.lblCentro);
            this.pnlBClientes.Controls.Add(this.label3);
            this.pnlBClientes.Controls.Add(this.lblTipoCli);
            this.pnlBClientes.Controls.Add(this.txbNombre);
            this.pnlBClientes.Controls.Add(this.label39);
            this.pnlBClientes.Controls.Add(this.btBuscarCentro);
            this.pnlBClientes.Controls.Add(this.lblTipoMedio);
            this.pnlBClientes.Controls.Add(this.lblCliente);
            this.pnlBClientes.Controls.Add(this.label12);
            this.pnlBClientes.ForeColor = System.Drawing.Color.Black;
            this.pnlBClientes.Location = new System.Drawing.Point(0, 40);
            this.pnlBClientes.Name = "pnlBClientes";
            this.pnlBClientes.Size = new System.Drawing.Size(1489, 116);
            this.pnlBClientes.TabIndex = 0;
            // 
            // label35
            // 
            this.label35.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label35.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label35.Location = new System.Drawing.Point(455, 58);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(78, 22);
            this.label35.TabIndex = 105;
            this.label35.Text = "Apellido1:";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.lblTitulo.Size = new System.Drawing.Size(1487, 22);
            this.lblTitulo.TabIndex = 104;
            this.lblTitulo.Text = "Consulta de Clientes SAP";
            // 
            // cboEstado
            // 
            this.cboEstado.BackColor = System.Drawing.Color.White;
            this.cboEstado.DataSource = this.dsClientes1.ListaEstados;
            this.cboEstado.DisplayMember = "sLiteral";
            this.cboEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboEstado.ForeColor = System.Drawing.Color.Black;
            this.cboEstado.Location = new System.Drawing.Point(887, 24);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(118, 28);
            this.cboEstado.TabIndex = 102;
            this.cboEstado.ValueMember = "sValor";
            // 
            // dsClientes1
            // 
            this.dsClientes1.DataSetName = "dsClientes";
            this.dsClientes1.Locale = new System.Globalization.CultureInfo("es-ES");
            this.dsClientes1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.ForeColor = System.Drawing.Color.Black;
            this.lblEstado.Location = new System.Drawing.Point(822, 28);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(64, 20);
            this.lblEstado.TabIndex = 103;
            this.lblEstado.Text = "Estado:";
            this.lblEstado.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cboRed
            // 
            this.cboRed.BackColor = System.Drawing.Color.White;
            this.cboRed.DataSource = this.dsClientes1.ListaRedes;
            this.cboRed.DisplayMember = "sLiteral";
            this.cboRed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboRed.ForeColor = System.Drawing.Color.Black;
            this.cboRed.Location = new System.Drawing.Point(623, 26);
            this.cboRed.Name = "cboRed";
            this.cboRed.Size = new System.Drawing.Size(170, 28);
            this.cboRed.TabIndex = 100;
            this.cboRed.ValueMember = "sValor";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label41.ForeColor = System.Drawing.Color.Black;
            this.label41.Location = new System.Drawing.Point(576, 28);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(43, 20);
            this.label41.TabIndex = 101;
            this.label41.Text = "Red:";
            this.label41.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cboCategoria
            // 
            this.cboCategoria.DataSource = this.dsClientes1.ListaTipoClasificacion;
            this.cboCategoria.DisplayMember = "sLiteral";
            this.cboCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCategoria.ItemHeight = 20;
            this.cboCategoria.Location = new System.Drawing.Point(1303, 25);
            this.cboCategoria.Name = "cboCategoria";
            this.cboCategoria.Size = new System.Drawing.Size(134, 28);
            this.cboCategoria.TabIndex = 5;
            this.cboCategoria.ValueMember = "sValor";
            this.cboCategoria.Leave += new System.EventHandler(this.cboCategoria_Leave);
            // 
            // txtsApellidos2
            // 
            this.txtsApellidos2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsApellidos2.Location = new System.Drawing.Point(728, 56);
            this.txtsApellidos2.MaxLength = 100;
            this.txtsApellidos2.Name = "txtsApellidos2";
            this.txtsApellidos2.Size = new System.Drawing.Size(113, 26);
            this.txtsApellidos2.TabIndex = 48;
            // 
            // cbRelacionConCentro
            // 
            this.cbRelacionConCentro.DataSource = this.dsClientes1.ListaRelacionClienteCentro;
            this.cbRelacionConCentro.DisplayMember = "Descripcion";
            this.cbRelacionConCentro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbRelacionConCentro.Location = new System.Drawing.Point(657, 84);
            this.cbRelacionConCentro.Name = "cbRelacionConCentro";
            this.cbRelacionConCentro.Size = new System.Drawing.Size(184, 28);
            this.cbRelacionConCentro.TabIndex = 12;
            this.cbRelacionConCentro.ValueMember = "Valor";
            this.cbRelacionConCentro.Leave += new System.EventHandler(this.cbRelacionConCentro_Leave);
            // 
            // label48
            // 
            this.label48.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label48.Location = new System.Drawing.Point(485, 86);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(173, 22);
            this.label48.TabIndex = 45;
            this.label48.Text = "Relación con el Centro:";
            // 
            // txtsCentro
            // 
            this.txtsCentro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtsCentro.Enabled = false;
            this.txtsCentro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsCentro.Location = new System.Drawing.Point(200, 84);
            this.txtsCentro.Name = "txtsCentro";
            this.txtsCentro.Size = new System.Drawing.Size(238, 26);
            this.txtsCentro.TabIndex = 10;
            this.txtsCentro.TabStop = false;
            // 
            // txtsIdCliente
            // 
            this.txtsIdCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsIdCliente.Location = new System.Drawing.Point(404, 26);
            this.txtsIdCliente.MaxLength = 20;
            this.txtsIdCliente.Name = "txtsIdCliente";
            this.txtsIdCliente.Size = new System.Drawing.Size(141, 26);
            this.txtsIdCliente.TabIndex = 1;
            // 
            // txbBPoblacion
            // 
            this.txbBPoblacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbBPoblacion.Location = new System.Drawing.Point(1067, 56);
            this.txbBPoblacion.Name = "txbBPoblacion";
            this.txbBPoblacion.Size = new System.Drawing.Size(236, 26);
            this.txbBPoblacion.TabIndex = 7;
            this.txbBPoblacion.Leave += new System.EventHandler(this.txbBPoblacion_Leave);
            // 
            // btnBuscPob
            // 
            this.btnBuscPob.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnBuscPob.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnBuscPob.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscPob.Image")));
            this.btnBuscPob.Location = new System.Drawing.Point(1303, 55);
            this.btnBuscPob.Name = "btnBuscPob";
            this.btnBuscPob.Size = new System.Drawing.Size(28, 28);
            this.btnBuscPob.TabIndex = 8;
            this.toolTipClientes.SetToolTip(this.btnBuscPob, "Buscar Población");
            this.btnBuscPob.UseVisualStyleBackColor = true;
            this.btnBuscPob.Click += new System.EventHandler(this.btnBuscPob_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(987, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 22);
            this.label1.TabIndex = 39;
            this.label1.Text = "Población:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtsIdCentro
            // 
            this.txtsIdCentro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsIdCentro.Location = new System.Drawing.Point(70, 84);
            this.txtsIdCentro.MaxLength = 20;
            this.txtsIdCentro.Name = "txtsIdCentro";
            this.txtsIdCentro.Size = new System.Drawing.Size(127, 26);
            this.txtsIdCentro.TabIndex = 9;
            this.txtsIdCentro.Leave += new System.EventHandler(this.txtsIdCentro_Leave);
            // 
            // txbCP
            // 
            this.txbCP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbCP.Location = new System.Drawing.Point(898, 56);
            this.txbCP.Name = "txbCP";
            this.txbCP.Size = new System.Drawing.Size(74, 26);
            this.txbCP.TabIndex = 6;
            this.txbCP.Leave += new System.EventHandler(this.txbCP_Leave);
            // 
            // lblCategoria
            // 
            this.lblCategoria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategoria.Location = new System.Drawing.Point(1202, 28);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(101, 22);
            this.lblCategoria.TabIndex = 29;
            this.lblCategoria.Text = "Clasificación:";
            this.lblCategoria.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboTipoCli
            // 
            this.cboTipoCli.DataSource = this.dsClientes1.ListaTipoCliente;
            this.cboTipoCli.DisplayMember = "sLiteral";
            this.cboTipoCli.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipoCli.ItemHeight = 20;
            this.cboTipoCli.Location = new System.Drawing.Point(1075, 26);
            this.cboTipoCli.Name = "cboTipoCli";
            this.cboTipoCli.Size = new System.Drawing.Size(106, 28);
            this.cboTipoCli.TabIndex = 4;
            this.cboTipoCli.ValueMember = "sValor";
            this.cboTipoCli.SelectedIndexChanged += new System.EventHandler(this.cboTipoCli_SelectedIndexChanged);
            this.cboTipoCli.Leave += new System.EventHandler(this.cboTipoCli_Leave);
            // 
            // txbApellidos1
            // 
            this.txbApellidos1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbApellidos1.Location = new System.Drawing.Point(532, 56);
            this.txbApellidos1.MaxLength = 100;
            this.txbApellidos1.Name = "txbApellidos1";
            this.txbApellidos1.Size = new System.Drawing.Size(113, 26);
            this.txbApellidos1.TabIndex = 3;
            // 
            // cbDelegado
            // 
            this.cbDelegado.DataSource = this.dsClientes1.ListaDelegados;
            this.cbDelegado.DisplayMember = "sNombre";
            this.cbDelegado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDelegado.ItemHeight = 20;
            this.cbDelegado.Location = new System.Drawing.Point(91, 26);
            this.cbDelegado.Name = "cbDelegado";
            this.cbDelegado.Size = new System.Drawing.Size(232, 28);
            this.cbDelegado.TabIndex = 0;
            this.cbDelegado.ValueMember = "iIdDelegado";
            this.cbDelegado.Leave += new System.EventHandler(this.cbDelegado_Leave);
            // 
            // btBuscar
            // 
            this.btBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btBuscar.Location = new System.Drawing.Point(1381, 66);
            this.btBuscar.Name = "btBuscar";
            this.btBuscar.Size = new System.Drawing.Size(75, 36);
            this.btBuscar.TabIndex = 13;
            this.btBuscar.Text = "Buscar";
            this.btBuscar.UseVisualStyleBackColor = true;
            this.btBuscar.Click += new System.EventHandler(this.btBuscar_Click);
            // 
            // lblCentro
            // 
            this.lblCentro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblCentro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCentro.Location = new System.Drawing.Point(8, 86);
            this.lblCentro.Name = "lblCentro";
            this.lblCentro.Size = new System.Drawing.Size(61, 22);
            this.lblCentro.TabIndex = 38;
            this.lblCentro.Text = "Centro:";
            this.lblCentro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(852, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 22);
            this.label3.TabIndex = 32;
            this.label3.Text = "C.P.:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTipoCli
            // 
            this.lblTipoCli.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblTipoCli.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoCli.Location = new System.Drawing.Point(1030, 28);
            this.lblTipoCli.Name = "lblTipoCli";
            this.lblTipoCli.Size = new System.Drawing.Size(43, 22);
            this.lblTipoCli.TabIndex = 25;
            this.lblTipoCli.Text = "Tipo:";
            this.lblTipoCli.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txbNombre
            // 
            this.txbNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbNombre.Location = new System.Drawing.Point(77, 56);
            this.txbNombre.MaxLength = 50;
            this.txbNombre.Name = "txbNombre";
            this.txbNombre.Size = new System.Drawing.Size(363, 26);
            this.txbNombre.TabIndex = 2;
            // 
            // label39
            // 
            this.label39.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label39.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label39.Location = new System.Drawing.Point(650, 58);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(78, 22);
            this.label39.TabIndex = 49;
            this.label39.Text = "Apellido2:";
            this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btBuscarCentro
            // 
            this.btBuscarCentro.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btBuscarCentro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btBuscarCentro.Image = ((System.Drawing.Image)(resources.GetObject("btBuscarCentro.Image")));
            this.btBuscarCentro.Location = new System.Drawing.Point(439, 86);
            this.btBuscarCentro.Name = "btBuscarCentro";
            this.btBuscarCentro.Size = new System.Drawing.Size(27, 27);
            this.btBuscarCentro.TabIndex = 11;
            this.toolTipClientes.SetToolTip(this.btBuscarCentro, "Buscar Centro");
            this.btBuscarCentro.UseVisualStyleBackColor = true;
            this.btBuscarCentro.Click += new System.EventHandler(this.btBuscarCentro_Click);
            // 
            // lblTipoMedio
            // 
            this.lblTipoMedio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblTipoMedio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoMedio.Location = new System.Drawing.Point(8, 28);
            this.lblTipoMedio.Name = "lblTipoMedio";
            this.lblTipoMedio.Size = new System.Drawing.Size(82, 22);
            this.lblTipoMedio.TabIndex = 2;
            this.lblTipoMedio.Text = "Delegado:";
            this.lblTipoMedio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCliente
            // 
            this.lblCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCliente.Location = new System.Drawing.Point(337, 28);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(63, 22);
            this.lblCliente.TabIndex = 42;
            this.lblCliente.Text = "Código:";
            this.lblCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(8, 58);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(69, 22);
            this.label12.TabIndex = 35;
            this.label12.Text = "Nombre:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblGBusquedaCli
            // 
            this.lblGBusquedaCli.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGBusquedaCli.ForeColor = System.Drawing.Color.White;
            this.lblGBusquedaCli.GradientColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.lblGBusquedaCli.GradientColorTwo = System.Drawing.Color.White;
            this.lblGBusquedaCli.Location = new System.Drawing.Point(0, 0);
            this.lblGBusquedaCli.Name = "lblGBusquedaCli";
            this.lblGBusquedaCli.Size = new System.Drawing.Size(100, 22);
            this.lblGBusquedaCli.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 0;
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
            this.labelGradient1.Size = new System.Drawing.Size(938, 22);
            this.labelGradient1.TabIndex = 47;
            this.labelGradient1.Text = "labelGradient1";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            // 
            // sqlConn
            // 
            this.sqlConn.FireInfoMessageEventOnUserErrors = false;
            // 
            // sqldaListaDelegados
            // 
            this.sqldaListaDelegados.SelectCommand = this.sqlSelectCommand2;
            this.sqldaListaDelegados.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaDelegados", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iIdDelegado", "iIdDelegado"),
                        new System.Data.Common.DataColumnMapping("sNombre", "sNombre")})});
            // 
            // sqlSelectCommand2
            // 
            this.sqlSelectCommand2.CommandText = "[ListaDelegados]";
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
            // sqldaListaTipoClasificacion
            // 
            this.sqldaListaTipoClasificacion.SelectCommand = this.sqlSelectCommand4;
            this.sqldaListaTipoClasificacion.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaTipoClasificacion", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("sValor", "sValor"),
                        new System.Data.Common.DataColumnMapping("sLiteral", "sLiteral")})});
            // 
            // sqlSelectCommand4
            // 
            this.sqlSelectCommand4.CommandText = "[ListaTipoClasificacion]";
            this.sqlSelectCommand4.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand4.Connection = this.sqlConn;
            this.sqlSelectCommand4.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null)});
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
            this.dtgGeneral.DataMember = "ListaClientes";
            this.dtgGeneral.DataSource = this.dsClientes1;
            this.dtgGeneral.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgGeneral.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dtgGeneral.Location = new System.Drawing.Point(1, 18);
            this.dtgGeneral.Name = "dtgGeneral";
            this.dtgGeneral.ReadOnly = true;
            this.dtgGeneral.RowHeaderWidth = 17;
            this.dtgGeneral.SelectionBackColor = System.Drawing.Color.White;
            this.dtgGeneral.SelectionForeColor = System.Drawing.Color.Black;
            this.dtgGeneral.Size = new System.Drawing.Size(1483, 268);
            this.dtgGeneral.TabIndex = 0;
            this.dtgGeneral.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            this.dtgGeneral.CurrentCellChanged += new System.EventHandler(this.dtgGeneral_CurrentCellChanged);
            this.dtgGeneral.DoubleClick += new System.EventHandler(this.dtgGeneral_DoubleClick);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.AlternatingBackColor = System.Drawing.Color.White;
            this.dataGridTableStyle1.BackColor = System.Drawing.Color.White;
            this.dataGridTableStyle1.DataGrid = this.dtgGeneral;
            this.dataGridTableStyle1.ForeColor = System.Drawing.Color.Black;
            this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn19,
            this.dataGridTextBoxColumn2,
            this.dataGridTextBoxColumn1,
            this.dataGridTextBoxColumn9,
            this.dataGridTextBoxColumn7,
            this.dataGridTextBoxColumn8,
            this.dataGridTextBoxColumn42,
            this.dataGridTextBoxColumn3,
            this.dataGridTextBoxColumn4,
            this.dataGridTextBoxColumn5,
            this.dataGridTextBoxColumn6,
            this.dataGridTextBoxColumn10,
            this.dataGridTextBoxColumn11,
            this.dataGridTextBoxColumn12,
            this.dataGridTextBoxColumn13,
            this.dataGridTextBoxColumn14,
            this.dataGridTextBoxColumn15,
            this.dataGridTextBoxColumn17,
            this.dataGridTextBoxColumn16,
            this.dtgtEstado,
            this.dataGridTextBoxColumn18,
            this.dataGridTextBoxColumn41,
            this.dataGridTextBoxColumniEstado,
            this.dataGridTextBoxColumnRed,
            this.dataGridTextBoxColumn50,
            this.dataGridTextBoxColumn51,
            this.dataGridTextBoxColumn52,
            this.dataGridTextBoxColumn53,
            this.dataGridTextBoxColumn54,
            this.dataGridTextBoxColumn45,
            this.dataGridTextBoxColumn46,
            this.dataGridTextBoxColumn47});
            this.dataGridTableStyle1.HeaderBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle1.MappingName = "ListaClientes";
            this.dataGridTableStyle1.RowHeaderWidth = 17;
            this.dataGridTableStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dataGridTableStyle1.SelectionForeColor = System.Drawing.Color.Black;
            // 
            // dataGridTextBoxColumn19
            // 
            this.dataGridTextBoxColumn19.Format = "";
            this.dataGridTextBoxColumn19.FormatInfo = null;
            this.dataGridTextBoxColumn19.MappingName = "iIdDelegado";
            this.dataGridTextBoxColumn19.Width = 0;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "Código";
            this.dataGridTextBoxColumn2.MappingName = "sIdCliente";
            this.dataGridTextBoxColumn2.NullText = "";
            this.dataGridTextBoxColumn2.Width = 110;
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.MappingName = "iIdCliente";
            this.dataGridTextBoxColumn1.NullText = "";
            this.dataGridTextBoxColumn1.Width = 0;
            // 
            // dataGridTextBoxColumn9
            // 
            this.dataGridTextBoxColumn9.Format = "";
            this.dataGridTextBoxColumn9.FormatInfo = null;
            this.dataGridTextBoxColumn9.HeaderText = "Nombre";
            this.dataGridTextBoxColumn9.MappingName = "tNombre";
            this.dataGridTextBoxColumn9.NullText = "";
            this.dataGridTextBoxColumn9.Width = 0;
            // 
            // dataGridTextBoxColumn7
            // 
            this.dataGridTextBoxColumn7.Format = "";
            this.dataGridTextBoxColumn7.FormatInfo = null;
            this.dataGridTextBoxColumn7.HeaderText = "Nombre";
            this.dataGridTextBoxColumn7.MappingName = "sNombre";
            this.dataGridTextBoxColumn7.NullText = "";
            this.dataGridTextBoxColumn7.Width = 360;
            // 
            // dataGridTextBoxColumn8
            // 
            this.dataGridTextBoxColumn8.Format = "";
            this.dataGridTextBoxColumn8.FormatInfo = null;
            this.dataGridTextBoxColumn8.HeaderText = "Apellido1";
            this.dataGridTextBoxColumn8.MappingName = "sApellidos1";
            this.dataGridTextBoxColumn8.NullText = "";
            this.dataGridTextBoxColumn8.Width = 90;
            // 
            // dataGridTextBoxColumn42
            // 
            this.dataGridTextBoxColumn42.Format = "";
            this.dataGridTextBoxColumn42.FormatInfo = null;
            this.dataGridTextBoxColumn42.HeaderText = "Apellido2";
            this.dataGridTextBoxColumn42.MappingName = "sApellidos2";
            this.dataGridTextBoxColumn42.NullText = "";
            this.dataGridTextBoxColumn42.Width = 80;
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.MappingName = "sTipoCliente";
            this.dataGridTextBoxColumn3.NullText = "";
            this.dataGridTextBoxColumn3.Width = 0;
            // 
            // dataGridTextBoxColumn4
            // 
            this.dataGridTextBoxColumn4.Format = "";
            this.dataGridTextBoxColumn4.FormatInfo = null;
            this.dataGridTextBoxColumn4.HeaderText = "Tipo";
            this.dataGridTextBoxColumn4.MappingName = "tTipoCliente";
            this.dataGridTextBoxColumn4.NullText = "";
            this.dataGridTextBoxColumn4.Width = 0;
            // 
            // dataGridTextBoxColumn5
            // 
            this.dataGridTextBoxColumn5.Format = "";
            this.dataGridTextBoxColumn5.FormatInfo = null;
            this.dataGridTextBoxColumn5.MappingName = "sIdTipoClasificacion";
            this.dataGridTextBoxColumn5.NullText = "";
            this.dataGridTextBoxColumn5.Width = 0;
            // 
            // dataGridTextBoxColumn6
            // 
            this.dataGridTextBoxColumn6.Format = "";
            this.dataGridTextBoxColumn6.FormatInfo = null;
            this.dataGridTextBoxColumn6.HeaderText = "Clasif.";
            this.dataGridTextBoxColumn6.MappingName = "tTipoClasificacion";
            this.dataGridTextBoxColumn6.NullText = "";
            this.dataGridTextBoxColumn6.Width = 125;
            // 
            // dataGridTextBoxColumn10
            // 
            this.dataGridTextBoxColumn10.Format = "";
            this.dataGridTextBoxColumn10.FormatInfo = null;
            this.dataGridTextBoxColumn10.MappingName = "sTelefono";
            this.dataGridTextBoxColumn10.NullText = "";
            this.dataGridTextBoxColumn10.Width = 0;
            // 
            // dataGridTextBoxColumn11
            // 
            this.dataGridTextBoxColumn11.Format = "";
            this.dataGridTextBoxColumn11.FormatInfo = null;
            this.dataGridTextBoxColumn11.MappingName = "cTipoCli";
            this.dataGridTextBoxColumn11.NullText = "";
            this.dataGridTextBoxColumn11.Width = 0;
            // 
            // dataGridTextBoxColumn12
            // 
            this.dataGridTextBoxColumn12.Format = "";
            this.dataGridTextBoxColumn12.FormatInfo = null;
            this.dataGridTextBoxColumn12.MappingName = "tTipoCli";
            this.dataGridTextBoxColumn12.NullText = "";
            this.dataGridTextBoxColumn12.Width = 0;
            // 
            // dataGridTextBoxColumn13
            // 
            this.dataGridTextBoxColumn13.Format = "";
            this.dataGridTextBoxColumn13.FormatInfo = null;
            this.dataGridTextBoxColumn13.MappingName = "iIdPoblacion";
            this.dataGridTextBoxColumn13.NullText = "";
            this.dataGridTextBoxColumn13.Width = 0;
            // 
            // dataGridTextBoxColumn14
            // 
            this.dataGridTextBoxColumn14.Format = "";
            this.dataGridTextBoxColumn14.FormatInfo = null;
            this.dataGridTextBoxColumn14.HeaderText = "C.P.";
            this.dataGridTextBoxColumn14.MappingName = "CodPostal";
            this.dataGridTextBoxColumn14.NullText = "";
            this.dataGridTextBoxColumn14.Width = 0;
            // 
            // dataGridTextBoxColumn15
            // 
            this.dataGridTextBoxColumn15.Format = "";
            this.dataGridTextBoxColumn15.FormatInfo = null;
            this.dataGridTextBoxColumn15.HeaderText = "Población";
            this.dataGridTextBoxColumn15.MappingName = "sPoblacion";
            this.dataGridTextBoxColumn15.NullText = "";
            this.dataGridTextBoxColumn15.Width = 0;
            // 
            // dataGridTextBoxColumn17
            // 
            this.dataGridTextBoxColumn17.Format = "";
            this.dataGridTextBoxColumn17.FormatInfo = null;
            this.dataGridTextBoxColumn17.HeaderText = "Provincia";
            this.dataGridTextBoxColumn17.MappingName = "sProvincia";
            this.dataGridTextBoxColumn17.NullText = "";
            this.dataGridTextBoxColumn17.Width = 0;
            // 
            // dataGridTextBoxColumn16
            // 
            this.dataGridTextBoxColumn16.Format = "";
            this.dataGridTextBoxColumn16.FormatInfo = null;
            this.dataGridTextBoxColumn16.MappingName = "iIdProvincia";
            this.dataGridTextBoxColumn16.NullText = "";
            this.dataGridTextBoxColumn16.Width = 0;
            // 
            // dtgtEstado
            // 
            this.dtgtEstado.Format = "";
            this.dtgtEstado.FormatInfo = null;
            this.dtgtEstado.HeaderText = "Estado";
            this.dtgtEstado.MappingName = "tEstado";
            this.dtgtEstado.Width = 75;
            // 
            // dataGridTextBoxColumn18
            // 
            this.dataGridTextBoxColumn18.Format = "";
            this.dataGridTextBoxColumn18.FormatInfo = null;
            this.dataGridTextBoxColumn18.HeaderText = "Delegado";
            this.dataGridTextBoxColumn18.MappingName = "NombreDel";
            this.dataGridTextBoxColumn18.NullText = "";
            this.dataGridTextBoxColumn18.Width = 75;
            // 
            // dataGridTextBoxColumn41
            // 
            this.dataGridTextBoxColumn41.Format = "";
            this.dataGridTextBoxColumn41.FormatInfo = null;
            this.dataGridTextBoxColumn41.MappingName = "bEnviadoCEN";
            this.dataGridTextBoxColumn41.NullText = "";
            this.dataGridTextBoxColumn41.Width = 0;
            // 
            // dataGridTextBoxColumniEstado
            // 
            this.dataGridTextBoxColumniEstado.Format = "";
            this.dataGridTextBoxColumniEstado.FormatInfo = null;
            this.dataGridTextBoxColumniEstado.MappingName = "iEstado";
            this.dataGridTextBoxColumniEstado.NullText = "";
            this.dataGridTextBoxColumniEstado.Width = 0;
            // 
            // dataGridTextBoxColumnRed
            // 
            this.dataGridTextBoxColumnRed.Format = "";
            this.dataGridTextBoxColumnRed.FormatInfo = null;
            this.dataGridTextBoxColumnRed.MappingName = "sIdRed";
            this.dataGridTextBoxColumnRed.Width = 0;
            // 
            // dataGridTextBoxColumn50
            // 
            this.dataGridTextBoxColumn50.Format = "";
            this.dataGridTextBoxColumn50.FormatInfo = null;
            this.dataGridTextBoxColumn50.HeaderText = "Club0";
            this.dataGridTextBoxColumn50.MappingName = "LitsGarantias_SAP";
            this.dataGridTextBoxColumn50.Width = 110;
            // 
            // dataGridTextBoxColumn51
            // 
            this.dataGridTextBoxColumn51.Format = "";
            this.dataGridTextBoxColumn51.FormatInfo = null;
            this.dataGridTextBoxColumn51.HeaderText = "Club1";
            this.dataGridTextBoxColumn51.MappingName = "LitsGarantias_SAP_1";
            this.dataGridTextBoxColumn51.Width = 110;
            // 
            // dataGridTextBoxColumn52
            // 
            this.dataGridTextBoxColumn52.Format = "";
            this.dataGridTextBoxColumn52.FormatInfo = null;
            this.dataGridTextBoxColumn52.HeaderText = "Club2";
            this.dataGridTextBoxColumn52.MappingName = "LitsGarantias_SAP_2";
            this.dataGridTextBoxColumn52.Width = 110;
            // 
            // dataGridTextBoxColumn53
            // 
            this.dataGridTextBoxColumn53.Format = "";
            this.dataGridTextBoxColumn53.FormatInfo = null;
            this.dataGridTextBoxColumn53.HeaderText = "Club3";
            this.dataGridTextBoxColumn53.MappingName = "LitsGarantias_SAP_3";
            this.dataGridTextBoxColumn53.Width = 110;
            // 
            // dataGridTextBoxColumn54
            // 
            this.dataGridTextBoxColumn54.Format = "";
            this.dataGridTextBoxColumn54.FormatInfo = null;
            this.dataGridTextBoxColumn54.HeaderText = "Club4";
            this.dataGridTextBoxColumn54.MappingName = "LitsGarantias_SAP_4";
            this.dataGridTextBoxColumn54.Width = 110;
            // 
            // dataGridTextBoxColumn45
            // 
            this.dataGridTextBoxColumn45.Format = "";
            this.dataGridTextBoxColumn45.FormatInfo = null;
            this.dataGridTextBoxColumn45.MappingName = "sGarantias_SAP";
            this.dataGridTextBoxColumn45.Width = 0;
            // 
            // dataGridTextBoxColumn46
            // 
            this.dataGridTextBoxColumn46.Format = "";
            this.dataGridTextBoxColumn46.FormatInfo = null;
            this.dataGridTextBoxColumn46.MappingName = "sGarantias_SAP_1";
            this.dataGridTextBoxColumn46.Width = 0;
            // 
            // dataGridTextBoxColumn47
            // 
            this.dataGridTextBoxColumn47.Format = "";
            this.dataGridTextBoxColumn47.FormatInfo = null;
            this.dataGridTextBoxColumn47.MappingName = "sGarantias_SAP_2";
            this.dataGridTextBoxColumn47.Width = 0;
            // 
            // Col0
            // 
            this.Col0.Format = "";
            this.Col0.FormatInfo = null;
            this.Col0.HeaderText = "Id";
            this.Col0.MappingName = "Id";
            this.Col0.Width = 0;
            // 
            // Col1
            // 
            this.Col1.Format = "";
            this.Col1.FormatInfo = null;
            this.Col1.HeaderText = "Tipo Cliente";
            this.Col1.MappingName = "TipoCliente";
            this.Col1.Width = 0;
            // 
            // Col2
            // 
            this.Col2.Format = "";
            this.Col2.FormatInfo = null;
            this.Col2.HeaderText = "Nombre";
            this.Col2.MappingName = "Nombre";
            this.Col2.Width = 200;
            // 
            // Col3
            // 
            this.Col3.Format = "";
            this.Col3.FormatInfo = null;
            this.Col3.HeaderText = "Apellidos";
            this.Col3.MappingName = "Apellidos";
            this.Col3.Width = 200;
            // 
            // Col4
            // 
            this.Col4.Format = "";
            this.Col4.FormatInfo = null;
            this.Col4.HeaderText = "CP";
            this.Col4.MappingName = "CP";
            this.Col4.Width = 50;
            // 
            // Col5
            // 
            this.Col5.Format = "";
            this.Col5.FormatInfo = null;
            this.Col5.HeaderText = "Población";
            this.Col5.MappingName = "Poblacion";
            this.Col5.Width = 200;
            // 
            // Col6
            // 
            this.Col6.Format = "";
            this.Col6.FormatInfo = null;
            this.Col6.HeaderText = "Colegiado";
            this.Col6.MappingName = "Colegiado";
            this.Col6.Width = 0;
            // 
            // Col7
            // 
            this.Col7.Format = "";
            this.Col7.FormatInfo = null;
            this.Col7.HeaderText = "Direccion";
            this.Col7.MappingName = "Direccion";
            this.Col7.Width = 0;
            // 
            // Col8
            // 
            this.Col8.Format = "";
            this.Col8.FormatInfo = null;
            this.Col8.HeaderText = "Fax";
            this.Col8.MappingName = "Fax";
            this.Col8.Width = 0;
            // 
            // Col9
            // 
            this.Col9.Format = "";
            this.Col9.FormatInfo = null;
            this.Col9.HeaderText = "Telefono";
            this.Col9.MappingName = "Telefono";
            this.Col9.Width = 0;
            // 
            // Col10
            // 
            this.Col10.Format = "";
            this.Col10.FormatInfo = null;
            this.Col10.HeaderText = "Comentarios";
            this.Col10.MappingName = "Comentarios";
            this.Col10.Width = 0;
            // 
            // Col11
            // 
            this.Col11.Format = "";
            this.Col11.FormatInfo = null;
            this.Col11.MappingName = "FechaNacimiento";
            this.Col11.Width = 0;
            // 
            // Col12
            // 
            this.Col12.Format = "";
            this.Col12.FormatInfo = null;
            this.Col12.MappingName = "EstadoCivil";
            this.Col12.Width = 0;
            // 
            // Col13
            // 
            this.Col13.Format = "";
            this.Col13.FormatInfo = null;
            this.Col13.MappingName = "AfiAct";
            this.Col13.Width = 0;
            // 
            // Col14
            // 
            this.Col14.Format = "";
            this.Col14.FormatInfo = null;
            this.Col14.MappingName = "AfiPas";
            this.Col14.Width = 0;
            // 
            // lblNumRegistros
            // 
            this.lblNumRegistros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.lblNumRegistros.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblNumRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumRegistros.ForeColor = System.Drawing.Color.Black;
            this.lblNumRegistros.Location = new System.Drawing.Point(1424, -1);
            this.lblNumRegistros.Name = "lblNumRegistros";
            this.lblNumRegistros.Size = new System.Drawing.Size(60, 18);
            this.lblNumRegistros.TabIndex = 27;
            this.lblNumRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sqldaListaClientes
            // 
            this.sqldaListaClientes.SelectCommand = this.sqlSelectCommand1;
            this.sqldaListaClientes.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaClientes", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iIdDelegado", "iIdDelegado"),
                        new System.Data.Common.DataColumnMapping("NombreDel", "NombreDel"),
                        new System.Data.Common.DataColumnMapping("iIdCliente", "iIdCliente"),
                        new System.Data.Common.DataColumnMapping("sIdCliente", "sIdCliente"),
                        new System.Data.Common.DataColumnMapping("sTipoCliente", "sTipoCliente"),
                        new System.Data.Common.DataColumnMapping("tTipoCliente", "tTipoCliente"),
                        new System.Data.Common.DataColumnMapping("sIdTipoClasificacion", "sIdTipoClasificacion"),
                        new System.Data.Common.DataColumnMapping("tTipoClasificacion", "tTipoClasificacion"),
                        new System.Data.Common.DataColumnMapping("sNombre", "sNombre"),
                        new System.Data.Common.DataColumnMapping("sApellidos1", "sApellidos1"),
                        new System.Data.Common.DataColumnMapping("sApellidos2", "sApellidos2"),
                        new System.Data.Common.DataColumnMapping("tNombre", "tNombre"),
                        new System.Data.Common.DataColumnMapping("sTelefono", "sTelefono"),
                        new System.Data.Common.DataColumnMapping("bEnviadoCEN", "bEnviadoCEN"),
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
                        new System.Data.Common.DataColumnMapping("sNIF_COM", "sNIF_COM"),
                        new System.Data.Common.DataColumnMapping("sIdEstadoCliCom_COM", "sIdEstadoCliCom_COM"),
                        new System.Data.Common.DataColumnMapping("tIdEstadoCliCom_COM", "tIdEstadoCliCom_COM"),
                        new System.Data.Common.DataColumnMapping("sIdPolGenericos_COM", "sIdPolGenericos_COM"),
                        new System.Data.Common.DataColumnMapping("tIdPolGenericos_COM", "tIdPolGenericos_COM"),
                        new System.Data.Common.DataColumnMapping("bAsignado_COM", "bAsignado_COM"),
                        new System.Data.Common.DataColumnMapping("tDatosFinacieros_COM", "tDatosFinacieros_COM"),
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
                        new System.Data.Common.DataColumnMapping("sGarantias_SAP_1", "sGarantias_SAP_1"),
                        new System.Data.Common.DataColumnMapping("sGarantias_SAP_2", "sGarantias_SAP_2"),
                        new System.Data.Common.DataColumnMapping("sGarantias_SAP_3", "sGarantias_SAP_3"),
                        new System.Data.Common.DataColumnMapping("sGarantias_SAP_4", "sGarantias_SAP_4"),
                        new System.Data.Common.DataColumnMapping("LitsGarantias_SAP", "LitsGarantias_SAP"),
                        new System.Data.Common.DataColumnMapping("LitsGarantias_SAP_1", "LitsGarantias_SAP_1"),
                        new System.Data.Common.DataColumnMapping("LitsGarantias_SAP_2", "LitsGarantias_SAP_2"),
                        new System.Data.Common.DataColumnMapping("LitsGarantias_SAP_3", "LitsGarantias_SAP_3"),
                        new System.Data.Common.DataColumnMapping("LitsGarantias_SAP_4", "LitsGarantias_SAP_4")})});
            // 
            // sqlSelectCommand1
            // 
            this.sqlSelectCommand1.CommandText = "[ListaClientes]";
            this.sqlSelectCommand1.CommandTimeout = 60;
            this.sqlSelectCommand1.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand1.Connection = this.sqlConn;
            this.sqlSelectCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdDelegado", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sIdCliente", System.Data.SqlDbType.VarChar, 20),
            new System.Data.SqlClient.SqlParameter("@sTipoCliente", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@sNombre", System.Data.SqlDbType.VarChar, 50),
            new System.Data.SqlClient.SqlParameter("@sApellidos1", System.Data.SqlDbType.VarChar, 100),
            new System.Data.SqlClient.SqlParameter("@sApellidos2", System.Data.SqlDbType.VarChar, 100),
            new System.Data.SqlClient.SqlParameter("@sIdCentro", System.Data.SqlDbType.VarChar, 20),
            new System.Data.SqlClient.SqlParameter("@sIdTipoClasificacion", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@iIdProvincia", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdPoblacion", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sCodPostal", System.Data.SqlDbType.VarChar, 5),
            new System.Data.SqlClient.SqlParameter("@sPoblacion", System.Data.SqlDbType.VarChar, 50),
            new System.Data.SqlClient.SqlParameter("@sIdTipoRelacionCliCen", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@sIdRed", System.Data.SqlDbType.VarChar, 4),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt, 2),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.NVarChar)});
            // 
            // pnDatosSAP
            // 
            this.pnDatosSAP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnDatosSAP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnDatosSAP.Controls.Add(this.panel6);
            this.pnDatosSAP.Controls.Add(this.panel5);
            this.pnDatosSAP.Controls.Add(this.txtTipo_SAP);
            this.pnDatosSAP.Controls.Add(this.label7);
            this.pnDatosSAP.Controls.Add(this.rbPotencial_SAP);
            this.pnDatosSAP.Controls.Add(this.txtDescGrupoCli_SAP);
            this.pnDatosSAP.Controls.Add(this.txtDescCondPago_SAP);
            this.pnDatosSAP.Controls.Add(this.txtGrupoCli_SAP);
            this.pnDatosSAP.Controls.Add(this.txtCondPago_SAP);
            this.pnDatosSAP.Controls.Add(this.txtDatosBancarios_SAP);
            this.pnDatosSAP.Controls.Add(this.txtNIF_SAP);
            this.pnDatosSAP.Controls.Add(this.label19);
            this.pnDatosSAP.Controls.Add(this.label18);
            this.pnDatosSAP.Controls.Add(this.txtTeleFax_SAP);
            this.pnDatosSAP.Controls.Add(this.txtTeles_SAP);
            this.pnDatosSAP.Controls.Add(this.label4);
            this.pnDatosSAP.Controls.Add(this.txtTelefono2_SAP);
            this.pnDatosSAP.Controls.Add(this.txtTelefono_SAP);
            this.pnDatosSAP.Controls.Add(this.txtPoblacion_SAP);
            this.pnDatosSAP.Controls.Add(this.txtCategoría_SAP);
            this.pnDatosSAP.Controls.Add(this.txtProvincia_SAP);
            this.pnDatosSAP.Controls.Add(this.txtCP_SAP);
            this.pnDatosSAP.Controls.Add(this.txtDireccion_SAP);
            this.pnDatosSAP.Controls.Add(this.txtNombre_SAP);
            this.pnDatosSAP.Controls.Add(this.txtsIdCliente_SAP);
            this.pnDatosSAP.Controls.Add(this.label11);
            this.pnDatosSAP.Controls.Add(this.label10);
            this.pnDatosSAP.Controls.Add(this.label9);
            this.pnDatosSAP.Controls.Add(this.label8);
            this.pnDatosSAP.Controls.Add(this.label6);
            this.pnDatosSAP.Controls.Add(this.label5);
            this.pnDatosSAP.Controls.Add(this.lblsIdCliente);
            this.pnDatosSAP.Controls.Add(this.label13);
            this.pnDatosSAP.Controls.Add(this.label14);
            this.pnDatosSAP.Controls.Add(this.label15);
            this.pnDatosSAP.Controls.Add(this.label16);
            this.pnDatosSAP.Controls.Add(this.label17);
            this.pnDatosSAP.ForeColor = System.Drawing.Color.Black;
            this.pnDatosSAP.Location = new System.Drawing.Point(1, 485);
            this.pnDatosSAP.Name = "pnDatosSAP";
            this.pnDatosSAP.Size = new System.Drawing.Size(1487, 298);
            this.pnDatosSAP.TabIndex = 6;
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel6.Controls.Add(this.lblTotCentrosSAP);
            this.panel6.Controls.Add(this.labelGradient8);
            this.panel6.Controls.Add(this.dgCentrosSAP);
            this.panel6.Location = new System.Drawing.Point(472, 124);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(547, 165);
            this.panel6.TabIndex = 33;
            // 
            // lblTotCentrosSAP
            // 
            this.lblTotCentrosSAP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.lblTotCentrosSAP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotCentrosSAP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotCentrosSAP.ForeColor = System.Drawing.Color.Black;
            this.lblTotCentrosSAP.Location = new System.Drawing.Point(485, 0);
            this.lblTotCentrosSAP.Name = "lblTotCentrosSAP";
            this.lblTotCentrosSAP.Size = new System.Drawing.Size(60, 18);
            this.lblTotCentrosSAP.TabIndex = 3;
            this.lblTotCentrosSAP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelGradient8
            // 
            this.labelGradient8.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelGradient8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGradient8.ForeColor = System.Drawing.Color.White;
            this.labelGradient8.GradientColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.labelGradient8.GradientColorTwo = System.Drawing.Color.White;
            this.labelGradient8.Location = new System.Drawing.Point(0, 0);
            this.labelGradient8.Name = "labelGradient8";
            this.labelGradient8.Size = new System.Drawing.Size(543, 18);
            this.labelGradient8.TabIndex = 0;
            this.labelGradient8.Text = "Programa Informático";
            this.labelGradient8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgCentrosSAP
            // 
            this.dgCentrosSAP.AlternatingBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.dgCentrosSAP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.dgCentrosSAP.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.dgCentrosSAP.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.dgCentrosSAP.CaptionText = "Centros de Influencia";
            this.dgCentrosSAP.CaptionVisible = false;
            this.dgCentrosSAP.DataMember = "ListaProgInf_porCliente_SAP";
            this.dgCentrosSAP.DataSource = this.dsClientes1;
            this.dgCentrosSAP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgCentrosSAP.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgCentrosSAP.Location = new System.Drawing.Point(-2, 18);
            this.dgCentrosSAP.Name = "dgCentrosSAP";
            this.dgCentrosSAP.ReadOnly = true;
            this.dgCentrosSAP.RowHeaderWidth = 17;
            this.dgCentrosSAP.Size = new System.Drawing.Size(547, 143);
            this.dgCentrosSAP.TabIndex = 0;
            this.dgCentrosSAP.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle6});
            this.dgCentrosSAP.CurrentCellChanged += new System.EventHandler(this.dgCentrosSAP_CurrentCellChanged);
            // 
            // dataGridTableStyle6
            // 
            this.dataGridTableStyle6.AlternatingBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(230)))), ((int)(((byte)(239)))));
            this.dataGridTableStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(230)))), ((int)(((byte)(239)))));
            this.dataGridTableStyle6.DataGrid = this.dgCentrosSAP;
            this.dataGridTableStyle6.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn49,
            this.dataGridTextBoxColumn34,
            this.dataGridTextBoxColumn35});
            this.dataGridTableStyle6.HeaderBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridTableStyle6.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle6.MappingName = "ListaProgInf_porCliente_SAP";
            this.dataGridTableStyle6.RowHeaderWidth = 17;
            // 
            // dataGridTextBoxColumn49
            // 
            this.dataGridTextBoxColumn49.Format = "";
            this.dataGridTextBoxColumn49.FormatInfo = null;
            this.dataGridTextBoxColumn49.HeaderText = "Cliente";
            this.dataGridTextBoxColumn49.MappingName = "iIdCliente";
            this.dataGridTextBoxColumn49.ReadOnly = true;
            this.dataGridTextBoxColumn49.Width = 0;
            // 
            // dataGridTextBoxColumn34
            // 
            this.dataGridTextBoxColumn34.Format = "";
            this.dataGridTextBoxColumn34.FormatInfo = null;
            this.dataGridTextBoxColumn34.HeaderText = "Código";
            this.dataGridTextBoxColumn34.MappingName = "iIdCentro";
            this.dataGridTextBoxColumn34.NullText = "";
            this.dataGridTextBoxColumn34.Width = 120;
            // 
            // dataGridTextBoxColumn35
            // 
            this.dataGridTextBoxColumn35.Format = "";
            this.dataGridTextBoxColumn35.FormatInfo = null;
            this.dataGridTextBoxColumn35.HeaderText = "Nombre Programa Informático";
            this.dataGridTextBoxColumn35.MappingName = "sNombre";
            this.dataGridTextBoxColumn35.NullText = "";
            this.dataGridTextBoxColumn35.Width = 400;
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel5.Controls.Add(this.dgContactosSAP);
            this.panel5.Controls.Add(this.lblTotContactosSAP);
            this.panel5.Controls.Add(this.labelGradient7);
            this.panel5.Location = new System.Drawing.Point(4, 124);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(460, 165);
            this.panel5.TabIndex = 32;
            // 
            // dgContactosSAP
            // 
            this.dgContactosSAP.AlternatingBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.dgContactosSAP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.dgContactosSAP.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.dgContactosSAP.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.dgContactosSAP.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgContactosSAP.CaptionText = "Personas de Contacto";
            this.dgContactosSAP.CaptionVisible = false;
            this.dgContactosSAP.DataMember = "ListaAreas_porCliente_SAP";
            this.dgContactosSAP.DataSource = this.dsClientes1;
            this.dgContactosSAP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgContactosSAP.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgContactosSAP.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgContactosSAP.Location = new System.Drawing.Point(-2, 18);
            this.dgContactosSAP.Name = "dgContactosSAP";
            this.dgContactosSAP.ReadOnly = true;
            this.dgContactosSAP.RowHeaderWidth = 15;
            this.dgContactosSAP.Size = new System.Drawing.Size(458, 143);
            this.dgContactosSAP.TabIndex = 1;
            this.dgContactosSAP.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle7});
            this.dgContactosSAP.CurrentCellChanged += new System.EventHandler(this.dgContactosSAP_CurrentCellChanged);
            // 
            // dataGridTableStyle7
            // 
            this.dataGridTableStyle7.AlternatingBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(230)))), ((int)(((byte)(239)))));
            this.dataGridTableStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(230)))), ((int)(((byte)(239)))));
            this.dataGridTableStyle7.DataGrid = this.dgContactosSAP;
            this.dataGridTableStyle7.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn48,
            this.dataGridTextBoxColumn33,
            this.dataGridTextBoxColumn32});
            this.dataGridTableStyle7.HeaderBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridTableStyle7.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle7.MappingName = "ListaAreas_porCliente_SAP";
            this.dataGridTableStyle7.RowHeaderWidth = 15;
            // 
            // dataGridTextBoxColumn48
            // 
            this.dataGridTextBoxColumn48.Format = "";
            this.dataGridTextBoxColumn48.FormatInfo = null;
            this.dataGridTextBoxColumn48.HeaderText = "Cliente";
            this.dataGridTextBoxColumn48.MappingName = "iIdCliente";
            this.dataGridTextBoxColumn48.ReadOnly = true;
            this.dataGridTextBoxColumn48.Width = 0;
            // 
            // dataGridTextBoxColumn33
            // 
            this.dataGridTextBoxColumn33.Format = "";
            this.dataGridTextBoxColumn33.FormatInfo = null;
            this.dataGridTextBoxColumn33.HeaderText = "Cód. Area";
            this.dataGridTextBoxColumn33.MappingName = "iIdContacto";
            this.dataGridTextBoxColumn33.NullText = "";
            this.dataGridTextBoxColumn33.ReadOnly = true;
            this.dataGridTextBoxColumn33.Width = 120;
            // 
            // dataGridTextBoxColumn32
            // 
            this.dataGridTextBoxColumn32.Format = "";
            this.dataGridTextBoxColumn32.FormatInfo = null;
            this.dataGridTextBoxColumn32.HeaderText = "Nombre Area";
            this.dataGridTextBoxColumn32.MappingName = "sNombre";
            this.dataGridTextBoxColumn32.NullText = "";
            this.dataGridTextBoxColumn32.ReadOnly = true;
            this.dataGridTextBoxColumn32.Width = 310;
            // 
            // lblTotContactosSAP
            // 
            this.lblTotContactosSAP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.lblTotContactosSAP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotContactosSAP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotContactosSAP.ForeColor = System.Drawing.Color.Black;
            this.lblTotContactosSAP.Location = new System.Drawing.Point(396, 0);
            this.lblTotContactosSAP.Name = "lblTotContactosSAP";
            this.lblTotContactosSAP.Size = new System.Drawing.Size(60, 18);
            this.lblTotContactosSAP.TabIndex = 2;
            this.lblTotContactosSAP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelGradient7
            // 
            this.labelGradient7.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelGradient7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGradient7.ForeColor = System.Drawing.Color.White;
            this.labelGradient7.GradientColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.labelGradient7.GradientColorTwo = System.Drawing.Color.White;
            this.labelGradient7.Location = new System.Drawing.Point(0, 0);
            this.labelGradient7.Name = "labelGradient7";
            this.labelGradient7.Size = new System.Drawing.Size(456, 18);
            this.labelGradient7.TabIndex = 0;
            this.labelGradient7.Text = "Area";
            this.labelGradient7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTipo_SAP
            // 
            this.txtTipo_SAP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtTipo_SAP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTipo_SAP.Location = new System.Drawing.Point(276, 9);
            this.txtTipo_SAP.Name = "txtTipo_SAP";
            this.txtTipo_SAP.ReadOnly = true;
            this.txtTipo_SAP.Size = new System.Drawing.Size(100, 26);
            this.txtTipo_SAP.TabIndex = 31;
            this.txtTipo_SAP.TabStop = false;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(234, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 22);
            this.label7.TabIndex = 30;
            this.label7.Text = "Tipo:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rbPotencial_SAP
            // 
            this.rbPotencial_SAP.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbPotencial_SAP.Enabled = false;
            this.rbPotencial_SAP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbPotencial_SAP.Location = new System.Drawing.Point(780, 11);
            this.rbPotencial_SAP.Name = "rbPotencial_SAP";
            this.rbPotencial_SAP.Size = new System.Drawing.Size(97, 22);
            this.rbPotencial_SAP.TabIndex = 29;
            this.rbPotencial_SAP.TabStop = true;
            this.rbPotencial_SAP.Text = "Potencial:";
            // 
            // txtDescGrupoCli_SAP
            // 
            this.txtDescGrupoCli_SAP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtDescGrupoCli_SAP.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsClientes1, "ListaClientes.tTipoCliente", true));
            this.txtDescGrupoCli_SAP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescGrupoCli_SAP.Location = new System.Drawing.Point(1211, 106);
            this.txtDescGrupoCli_SAP.Name = "txtDescGrupoCli_SAP";
            this.txtDescGrupoCli_SAP.ReadOnly = true;
            this.txtDescGrupoCli_SAP.Size = new System.Drawing.Size(155, 26);
            this.txtDescGrupoCli_SAP.TabIndex = 28;
            this.txtDescGrupoCli_SAP.TabStop = false;
            this.txtDescGrupoCli_SAP.Visible = false;
            // 
            // txtDescCondPago_SAP
            // 
            this.txtDescCondPago_SAP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtDescCondPago_SAP.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsClientes1, "ListaClientes.tCodPago_SAP", true));
            this.txtDescCondPago_SAP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescCondPago_SAP.Location = new System.Drawing.Point(1285, 41);
            this.txtDescCondPago_SAP.Name = "txtDescCondPago_SAP";
            this.txtDescCondPago_SAP.ReadOnly = true;
            this.txtDescCondPago_SAP.Size = new System.Drawing.Size(188, 26);
            this.txtDescCondPago_SAP.TabIndex = 27;
            this.txtDescCondPago_SAP.TabStop = false;
            // 
            // txtGrupoCli_SAP
            // 
            this.txtGrupoCli_SAP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtGrupoCli_SAP.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsClientes1, "ListaClientes.cTipoCli", true));
            this.txtGrupoCli_SAP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGrupoCli_SAP.Location = new System.Drawing.Point(724, 9);
            this.txtGrupoCli_SAP.Name = "txtGrupoCli_SAP";
            this.txtGrupoCli_SAP.ReadOnly = true;
            this.txtGrupoCli_SAP.Size = new System.Drawing.Size(34, 26);
            this.txtGrupoCli_SAP.TabIndex = 26;
            this.txtGrupoCli_SAP.TabStop = false;
            // 
            // txtCondPago_SAP
            // 
            this.txtCondPago_SAP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtCondPago_SAP.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsClientes1, "ListaClientes.sCodPago_SAP", true));
            this.txtCondPago_SAP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCondPago_SAP.Location = new System.Drawing.Point(1231, 41);
            this.txtCondPago_SAP.Name = "txtCondPago_SAP";
            this.txtCondPago_SAP.ReadOnly = true;
            this.txtCondPago_SAP.Size = new System.Drawing.Size(51, 26);
            this.txtCondPago_SAP.TabIndex = 25;
            this.txtCondPago_SAP.TabStop = false;
            // 
            // txtDatosBancarios_SAP
            // 
            this.txtDatosBancarios_SAP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtDatosBancarios_SAP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDatosBancarios_SAP.Location = new System.Drawing.Point(1220, 9);
            this.txtDatosBancarios_SAP.Name = "txtDatosBancarios_SAP";
            this.txtDatosBancarios_SAP.ReadOnly = true;
            this.txtDatosBancarios_SAP.Size = new System.Drawing.Size(208, 26);
            this.txtDatosBancarios_SAP.TabIndex = 24;
            this.txtDatosBancarios_SAP.TabStop = false;
            // 
            // txtNIF_SAP
            // 
            this.txtNIF_SAP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtNIF_SAP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNIF_SAP.Location = new System.Drawing.Point(948, 9);
            this.txtNIF_SAP.Name = "txtNIF_SAP";
            this.txtNIF_SAP.ReadOnly = true;
            this.txtNIF_SAP.Size = new System.Drawing.Size(123, 26);
            this.txtNIF_SAP.TabIndex = 23;
            this.txtNIF_SAP.TabStop = false;
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(605, 11);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(119, 22);
            this.label19.TabIndex = 22;
            this.label19.Text = "Grupo Clientes:";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(1134, 43);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(97, 22);
            this.label18.TabIndex = 21;
            this.label18.Text = "Cond. Pago:";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTeleFax_SAP
            // 
            this.txtTeleFax_SAP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtTeleFax_SAP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTeleFax_SAP.Location = new System.Drawing.Point(1018, 41);
            this.txtTeleFax_SAP.Name = "txtTeleFax_SAP";
            this.txtTeleFax_SAP.ReadOnly = true;
            this.txtTeleFax_SAP.Size = new System.Drawing.Size(112, 26);
            this.txtTeleFax_SAP.TabIndex = 20;
            this.txtTeleFax_SAP.TabStop = false;
            // 
            // txtTeles_SAP
            // 
            this.txtTeles_SAP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtTeles_SAP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTeles_SAP.Location = new System.Drawing.Point(859, 41);
            this.txtTeles_SAP.Name = "txtTeles_SAP";
            this.txtTeles_SAP.ReadOnly = true;
            this.txtTeles_SAP.Size = new System.Drawing.Size(112, 26);
            this.txtTeles_SAP.TabIndex = 19;
            this.txtTeles_SAP.TabStop = false;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(979, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 22);
            this.label4.TabIndex = 18;
            this.label4.Text = "Fax:";
            // 
            // txtTelefono2_SAP
            // 
            this.txtTelefono2_SAP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtTelefono2_SAP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelefono2_SAP.Location = new System.Drawing.Point(688, 41);
            this.txtTelefono2_SAP.Name = "txtTelefono2_SAP";
            this.txtTelefono2_SAP.ReadOnly = true;
            this.txtTelefono2_SAP.Size = new System.Drawing.Size(112, 26);
            this.txtTelefono2_SAP.TabIndex = 17;
            this.txtTelefono2_SAP.TabStop = false;
            // 
            // txtTelefono_SAP
            // 
            this.txtTelefono_SAP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtTelefono_SAP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelefono_SAP.Location = new System.Drawing.Point(516, 41);
            this.txtTelefono_SAP.Name = "txtTelefono_SAP";
            this.txtTelefono_SAP.ReadOnly = true;
            this.txtTelefono_SAP.Size = new System.Drawing.Size(112, 26);
            this.txtTelefono_SAP.TabIndex = 16;
            this.txtTelefono_SAP.TabStop = false;
            // 
            // txtPoblacion_SAP
            // 
            this.txtPoblacion_SAP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtPoblacion_SAP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPoblacion_SAP.Location = new System.Drawing.Point(651, 73);
            this.txtPoblacion_SAP.Name = "txtPoblacion_SAP";
            this.txtPoblacion_SAP.ReadOnly = true;
            this.txtPoblacion_SAP.Size = new System.Drawing.Size(299, 26);
            this.txtPoblacion_SAP.TabIndex = 14;
            this.txtPoblacion_SAP.TabStop = false;
            // 
            // txtCategoría_SAP
            // 
            this.txtCategoría_SAP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtCategoría_SAP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCategoría_SAP.Location = new System.Drawing.Point(487, 9);
            this.txtCategoría_SAP.Name = "txtCategoría_SAP";
            this.txtCategoría_SAP.ReadOnly = true;
            this.txtCategoría_SAP.Size = new System.Drawing.Size(111, 26);
            this.txtCategoría_SAP.TabIndex = 13;
            this.txtCategoría_SAP.TabStop = false;
            // 
            // txtProvincia_SAP
            // 
            this.txtProvincia_SAP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtProvincia_SAP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProvincia_SAP.Location = new System.Drawing.Point(1030, 73);
            this.txtProvincia_SAP.Name = "txtProvincia_SAP";
            this.txtProvincia_SAP.ReadOnly = true;
            this.txtProvincia_SAP.Size = new System.Drawing.Size(158, 26);
            this.txtProvincia_SAP.TabIndex = 12;
            this.txtProvincia_SAP.TabStop = false;
            // 
            // txtCP_SAP
            // 
            this.txtCP_SAP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtCP_SAP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCP_SAP.Location = new System.Drawing.Point(490, 73);
            this.txtCP_SAP.Name = "txtCP_SAP";
            this.txtCP_SAP.ReadOnly = true;
            this.txtCP_SAP.Size = new System.Drawing.Size(69, 26);
            this.txtCP_SAP.TabIndex = 11;
            this.txtCP_SAP.TabStop = false;
            // 
            // txtDireccion_SAP
            // 
            this.txtDireccion_SAP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtDireccion_SAP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDireccion_SAP.Location = new System.Drawing.Point(90, 73);
            this.txtDireccion_SAP.Name = "txtDireccion_SAP";
            this.txtDireccion_SAP.ReadOnly = true;
            this.txtDireccion_SAP.Size = new System.Drawing.Size(354, 26);
            this.txtDireccion_SAP.TabIndex = 10;
            this.txtDireccion_SAP.TabStop = false;
            // 
            // txtNombre_SAP
            // 
            this.txtNombre_SAP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtNombre_SAP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre_SAP.Location = new System.Drawing.Point(78, 41);
            this.txtNombre_SAP.Name = "txtNombre_SAP";
            this.txtNombre_SAP.ReadOnly = true;
            this.txtNombre_SAP.Size = new System.Drawing.Size(354, 26);
            this.txtNombre_SAP.TabIndex = 9;
            this.txtNombre_SAP.TabStop = false;
            // 
            // txtsIdCliente_SAP
            // 
            this.txtsIdCliente_SAP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtsIdCliente_SAP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsIdCliente_SAP.Location = new System.Drawing.Point(105, 9);
            this.txtsIdCliente_SAP.Name = "txtsIdCliente_SAP";
            this.txtsIdCliente_SAP.ReadOnly = true;
            this.txtsIdCliente_SAP.Size = new System.Drawing.Size(120, 26);
            this.txtsIdCliente_SAP.TabIndex = 8;
            this.txtsIdCliente_SAP.TabStop = false;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label11.Location = new System.Drawing.Point(386, 11);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(101, 22);
            this.label11.TabIndex = 7;
            this.label11.Text = "Clasificación:";
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(568, 75);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(82, 22);
            this.label10.TabIndex = 6;
            this.label10.Text = "Población:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(11, 75);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 22);
            this.label9.TabIndex = 5;
            this.label9.Text = "Dirección:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(956, 75);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 22);
            this.label8.TabIndex = 4;
            this.label8.Text = "Provincia:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(906, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 22);
            this.label6.TabIndex = 2;
            this.label6.Text = "NIF:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(11, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 22);
            this.label5.TabIndex = 1;
            this.label5.Text = "Nombre:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblsIdCliente
            // 
            this.lblsIdCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsIdCliente.Location = new System.Drawing.Point(11, 11);
            this.lblsIdCliente.Name = "lblsIdCliente";
            this.lblsIdCliente.Size = new System.Drawing.Size(95, 22);
            this.lblsIdCliente.TabIndex = 0;
            this.lblsIdCliente.Text = "Cód.Cliente:";
            this.lblsIdCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(449, 75);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(42, 22);
            this.label13.TabIndex = 5;
            this.label13.Text = "C.P.:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(436, 43);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(87, 22);
            this.label14.TabIndex = 1;
            this.label14.Text = "Teléfono1:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(634, 43);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(84, 22);
            this.label15.TabIndex = 0;
            this.label15.Text = "Telf. 2:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(808, 43);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(51, 22);
            this.label16.TabIndex = 3;
            this.label16.Text = "Teles:";
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(1087, 11);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(131, 22);
            this.label17.TabIndex = 2;
            this.label17.Text = "Datos Bancarios:";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgAreasCOM
            // 
            this.dgAreasCOM.AlternatingBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.dgAreasCOM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.dgAreasCOM.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.dgAreasCOM.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.dgAreasCOM.CaptionText = "Personas de Contacto";
            this.dgAreasCOM.CaptionVisible = false;
            this.dgAreasCOM.DataMember = "ListaAreas_porCliente_SAP";
            this.dgAreasCOM.DataSource = this.dsClientes1;
            this.dgAreasCOM.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgAreasCOM.Location = new System.Drawing.Point(0, 18);
            this.dgAreasCOM.Name = "dgAreasCOM";
            this.dgAreasCOM.ReadOnly = true;
            this.dgAreasCOM.RowHeaderWidth = 15;
            this.dgAreasCOM.Size = new System.Drawing.Size(424, 199);
            this.dgAreasCOM.TabIndex = 1;
            this.dgAreasCOM.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle7});
            // 
            // btMayoristas
            // 
            this.btMayoristas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btMayoristas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btMayoristas.ForeColor = System.Drawing.Color.Black;
            this.btMayoristas.Location = new System.Drawing.Point(286, 454);
            this.btMayoristas.Name = "btMayoristas";
            this.btMayoristas.Size = new System.Drawing.Size(159, 31);
            this.btMayoristas.TabIndex = 4;
            this.btMayoristas.Text = "&3 - Interlocutores";
            this.btMayoristas.UseVisualStyleBackColor = true;
            this.btMayoristas.Click += new System.EventHandler(this.btMayoristas_Click);
            // 
            // pnDatosCOM
            // 
            this.pnDatosCOM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnDatosCOM.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnDatosCOM.Controls.Add(this.panel8);
            this.pnDatosCOM.Controls.Add(this.txtTipoCliente_COM);
            this.pnDatosCOM.Controls.Add(this.label22);
            this.pnDatosCOM.Controls.Add(this.txtNumColegiado_COM);
            this.pnDatosCOM.Controls.Add(this.label21);
            this.pnDatosCOM.Controls.Add(this.txtNIF_COM);
            this.pnDatosCOM.Controls.Add(this.txtTipo_COM);
            this.pnDatosCOM.Controls.Add(this.label20);
            this.pnDatosCOM.Controls.Add(this.txtEMail_COM);
            this.pnDatosCOM.Controls.Add(this.txtFax_COM);
            this.pnDatosCOM.Controls.Add(this.label23);
            this.pnDatosCOM.Controls.Add(this.txtTelMovil_COM);
            this.pnDatosCOM.Controls.Add(this.txtTelefono_COM);
            this.pnDatosCOM.Controls.Add(this.txtPoblacion_COM);
            this.pnDatosCOM.Controls.Add(this.txtCategoria_COM);
            this.pnDatosCOM.Controls.Add(this.txtProvincia_COM);
            this.pnDatosCOM.Controls.Add(this.txtCP_COM);
            this.pnDatosCOM.Controls.Add(this.txtDireccion_COM);
            this.pnDatosCOM.Controls.Add(this.txtNombre_COM);
            this.pnDatosCOM.Controls.Add(this.txtsIdCliente_COM);
            this.pnDatosCOM.Controls.Add(this.label24);
            this.pnDatosCOM.Controls.Add(this.label25);
            this.pnDatosCOM.Controls.Add(this.label26);
            this.pnDatosCOM.Controls.Add(this.label27);
            this.pnDatosCOM.Controls.Add(this.label28);
            this.pnDatosCOM.Controls.Add(this.label29);
            this.pnDatosCOM.Controls.Add(this.label30);
            this.pnDatosCOM.Controls.Add(this.label31);
            this.pnDatosCOM.Controls.Add(this.label32);
            this.pnDatosCOM.Controls.Add(this.label33);
            this.pnDatosCOM.Controls.Add(this.label34);
            this.pnDatosCOM.Controls.Add(this.txtFecNacim_COM);
            this.pnDatosCOM.Controls.Add(this.txtObservaciones_COM);
            this.pnDatosCOM.Controls.Add(this.label40);
            this.pnDatosCOM.Controls.Add(this.label38);
            this.pnDatosCOM.ForeColor = System.Drawing.Color.Black;
            this.pnDatosCOM.Location = new System.Drawing.Point(1, 814);
            this.pnDatosCOM.Name = "pnDatosCOM";
            this.pnDatosCOM.Size = new System.Drawing.Size(1278, 258);
            this.pnDatosCOM.TabIndex = 7;
            // 
            // panel8
            // 
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel8.Controls.Add(this.panel11);
            this.panel8.Controls.Add(this.dgAficiones);
            this.panel8.Controls.Add(this.lblTotAficiones);
            this.panel8.Controls.Add(this.labelGradient10);
            this.panel8.Location = new System.Drawing.Point(482, 52);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(432, 226);
            this.panel8.TabIndex = 69;
            // 
            // panel11
            // 
            this.panel11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel11.Controls.Add(this.dgAreasCOM);
            this.panel11.Controls.Add(this.label46);
            this.panel11.Controls.Add(this.labelGradient11);
            this.panel11.Location = new System.Drawing.Point(-2, 0);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(427, 224);
            this.panel11.TabIndex = 70;
            // 
            // label46
            // 
            this.label46.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.label46.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label46.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label46.ForeColor = System.Drawing.Color.Black;
            this.label46.Location = new System.Drawing.Point(364, 0);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(60, 18);
            this.label46.TabIndex = 2;
            this.label46.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelGradient11
            // 
            this.labelGradient11.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelGradient11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGradient11.ForeColor = System.Drawing.Color.White;
            this.labelGradient11.GradientColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.labelGradient11.GradientColorTwo = System.Drawing.Color.White;
            this.labelGradient11.Location = new System.Drawing.Point(0, 0);
            this.labelGradient11.Name = "labelGradient11";
            this.labelGradient11.Size = new System.Drawing.Size(423, 18);
            this.labelGradient11.TabIndex = 0;
            this.labelGradient11.Text = "Area";
            this.labelGradient11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.dgAficiones.Size = new System.Drawing.Size(430, 206);
            this.dgAficiones.TabIndex = 2;
            this.dgAficiones.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle9});
            this.dgAficiones.Visible = false;
            // 
            // dataGridTableStyle9
            // 
            this.dataGridTableStyle9.DataGrid = this.dgAficiones;
            this.dataGridTableStyle9.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn38});
            this.dataGridTableStyle9.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle9.MappingName = "ListaAficClientes_COM";
            this.dataGridTableStyle9.RowHeaderWidth = 17;
            // 
            // dataGridTextBoxColumn38
            // 
            this.dataGridTextBoxColumn38.Format = "";
            this.dataGridTextBoxColumn38.FormatInfo = null;
            this.dataGridTextBoxColumn38.HeaderText = "Descripción";
            this.dataGridTextBoxColumn38.MappingName = "tAficion";
            this.dataGridTextBoxColumn38.NullText = "";
            this.dataGridTextBoxColumn38.Width = 360;
            // 
            // lblTotAficiones
            // 
            this.lblTotAficiones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.lblTotAficiones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotAficiones.Location = new System.Drawing.Point(368, 0);
            this.lblTotAficiones.Name = "lblTotAficiones";
            this.lblTotAficiones.Size = new System.Drawing.Size(60, 18);
            this.lblTotAficiones.TabIndex = 1;
            this.lblTotAficiones.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelGradient10
            // 
            this.labelGradient10.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelGradient10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGradient10.ForeColor = System.Drawing.Color.White;
            this.labelGradient10.GradientColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.labelGradient10.GradientColorTwo = System.Drawing.Color.White;
            this.labelGradient10.Location = new System.Drawing.Point(0, 0);
            this.labelGradient10.Name = "labelGradient10";
            this.labelGradient10.Size = new System.Drawing.Size(428, 18);
            this.labelGradient10.TabIndex = 0;
            this.labelGradient10.Text = "Aficiones";
            this.labelGradient10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTipoCliente_COM
            // 
            this.txtTipoCliente_COM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtTipoCliente_COM.Location = new System.Drawing.Point(564, 22);
            this.txtTipoCliente_COM.Name = "txtTipoCliente_COM";
            this.txtTipoCliente_COM.ReadOnly = true;
            this.txtTipoCliente_COM.Size = new System.Drawing.Size(224, 20);
            this.txtTipoCliente_COM.TabIndex = 66;
            this.txtTipoCliente_COM.TabStop = false;
            // 
            // label22
            // 
            this.label22.Location = new System.Drawing.Point(480, 24);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(64, 18);
            this.label22.TabIndex = 65;
            this.label22.Text = "Clase Cli.:";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNumColegiado_COM
            // 
            this.txtNumColegiado_COM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtNumColegiado_COM.Location = new System.Drawing.Point(564, 2);
            this.txtNumColegiado_COM.Name = "txtNumColegiado_COM";
            this.txtNumColegiado_COM.ReadOnly = true;
            this.txtNumColegiado_COM.Size = new System.Drawing.Size(130, 20);
            this.txtNumColegiado_COM.TabIndex = 64;
            this.txtNumColegiado_COM.TabStop = false;
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(480, 4);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(74, 18);
            this.label21.TabIndex = 63;
            this.label21.Text = "N. Colegiado:";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNIF_COM
            // 
            this.txtNIF_COM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtNIF_COM.Location = new System.Drawing.Point(786, 2);
            this.txtNIF_COM.Name = "txtNIF_COM";
            this.txtNIF_COM.ReadOnly = true;
            this.txtNIF_COM.Size = new System.Drawing.Size(130, 20);
            this.txtNIF_COM.TabIndex = 61;
            this.txtNIF_COM.TabStop = false;
            // 
            // txtTipo_COM
            // 
            this.txtTipo_COM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtTipo_COM.Location = new System.Drawing.Point(246, 2);
            this.txtTipo_COM.Name = "txtTipo_COM";
            this.txtTipo_COM.ReadOnly = true;
            this.txtTipo_COM.Size = new System.Drawing.Size(100, 20);
            this.txtTipo_COM.TabIndex = 60;
            this.txtTipo_COM.TabStop = false;
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(214, 4);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(30, 18);
            this.label20.TabIndex = 59;
            this.label20.Text = "Tipo:";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtEMail_COM
            // 
            this.txtEMail_COM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtEMail_COM.Location = new System.Drawing.Point(318, 142);
            this.txtEMail_COM.Name = "txtEMail_COM";
            this.txtEMail_COM.ReadOnly = true;
            this.txtEMail_COM.Size = new System.Drawing.Size(130, 20);
            this.txtEMail_COM.TabIndex = 55;
            this.txtEMail_COM.TabStop = false;
            // 
            // txtFax_COM
            // 
            this.txtFax_COM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtFax_COM.Location = new System.Drawing.Point(318, 122);
            this.txtFax_COM.Name = "txtFax_COM";
            this.txtFax_COM.ReadOnly = true;
            this.txtFax_COM.Size = new System.Drawing.Size(130, 20);
            this.txtFax_COM.TabIndex = 54;
            this.txtFax_COM.TabStop = false;
            // 
            // label23
            // 
            this.label23.Location = new System.Drawing.Point(256, 144);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(50, 18);
            this.label23.TabIndex = 53;
            this.label23.Text = "EMail:";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTelMovil_COM
            // 
            this.txtTelMovil_COM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtTelMovil_COM.Location = new System.Drawing.Point(94, 142);
            this.txtTelMovil_COM.Name = "txtTelMovil_COM";
            this.txtTelMovil_COM.ReadOnly = true;
            this.txtTelMovil_COM.Size = new System.Drawing.Size(130, 20);
            this.txtTelMovil_COM.TabIndex = 52;
            this.txtTelMovil_COM.TabStop = false;
            // 
            // txtTelefono_COM
            // 
            this.txtTelefono_COM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtTelefono_COM.Location = new System.Drawing.Point(94, 122);
            this.txtTelefono_COM.Name = "txtTelefono_COM";
            this.txtTelefono_COM.ReadOnly = true;
            this.txtTelefono_COM.Size = new System.Drawing.Size(130, 20);
            this.txtTelefono_COM.TabIndex = 51;
            this.txtTelefono_COM.TabStop = false;
            // 
            // txtPoblacion_COM
            // 
            this.txtPoblacion_COM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtPoblacion_COM.Location = new System.Drawing.Point(198, 62);
            this.txtPoblacion_COM.Name = "txtPoblacion_COM";
            this.txtPoblacion_COM.ReadOnly = true;
            this.txtPoblacion_COM.Size = new System.Drawing.Size(250, 20);
            this.txtPoblacion_COM.TabIndex = 50;
            this.txtPoblacion_COM.TabStop = false;
            // 
            // txtCategoria_COM
            // 
            this.txtCategoria_COM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtCategoria_COM.Location = new System.Drawing.Point(418, 2);
            this.txtCategoria_COM.Name = "txtCategoria_COM";
            this.txtCategoria_COM.ReadOnly = true;
            this.txtCategoria_COM.Size = new System.Drawing.Size(30, 20);
            this.txtCategoria_COM.TabIndex = 49;
            this.txtCategoria_COM.TabStop = false;
            // 
            // txtProvincia_COM
            // 
            this.txtProvincia_COM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtProvincia_COM.Location = new System.Drawing.Point(94, 82);
            this.txtProvincia_COM.Name = "txtProvincia_COM";
            this.txtProvincia_COM.ReadOnly = true;
            this.txtProvincia_COM.Size = new System.Drawing.Size(208, 20);
            this.txtProvincia_COM.TabIndex = 48;
            this.txtProvincia_COM.TabStop = false;
            // 
            // txtCP_COM
            // 
            this.txtCP_COM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtCP_COM.Location = new System.Drawing.Point(94, 62);
            this.txtCP_COM.Name = "txtCP_COM";
            this.txtCP_COM.ReadOnly = true;
            this.txtCP_COM.Size = new System.Drawing.Size(50, 20);
            this.txtCP_COM.TabIndex = 47;
            this.txtCP_COM.TabStop = false;
            // 
            // txtDireccion_COM
            // 
            this.txtDireccion_COM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtDireccion_COM.Location = new System.Drawing.Point(94, 42);
            this.txtDireccion_COM.Name = "txtDireccion_COM";
            this.txtDireccion_COM.ReadOnly = true;
            this.txtDireccion_COM.Size = new System.Drawing.Size(354, 20);
            this.txtDireccion_COM.TabIndex = 46;
            this.txtDireccion_COM.TabStop = false;
            // 
            // txtNombre_COM
            // 
            this.txtNombre_COM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtNombre_COM.Location = new System.Drawing.Point(94, 22);
            this.txtNombre_COM.Name = "txtNombre_COM";
            this.txtNombre_COM.ReadOnly = true;
            this.txtNombre_COM.Size = new System.Drawing.Size(354, 20);
            this.txtNombre_COM.TabIndex = 45;
            this.txtNombre_COM.TabStop = false;
            // 
            // txtsIdCliente_COM
            // 
            this.txtsIdCliente_COM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtsIdCliente_COM.Location = new System.Drawing.Point(94, 2);
            this.txtsIdCliente_COM.Name = "txtsIdCliente_COM";
            this.txtsIdCliente_COM.ReadOnly = true;
            this.txtsIdCliente_COM.Size = new System.Drawing.Size(100, 20);
            this.txtsIdCliente_COM.TabIndex = 44;
            this.txtsIdCliente_COM.TabStop = false;
            // 
            // label24
            // 
            this.label24.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label24.Location = new System.Drawing.Point(358, 4);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(60, 18);
            this.label24.TabIndex = 43;
            this.label24.Text = "Categoría:";
            // 
            // label25
            // 
            this.label25.Location = new System.Drawing.Point(142, 64);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(57, 18);
            this.label25.TabIndex = 42;
            this.label25.Text = "Población:";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label26
            // 
            this.label26.Location = new System.Drawing.Point(14, 44);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(67, 18);
            this.label26.TabIndex = 40;
            this.label26.Text = "Dirección:";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label27
            // 
            this.label27.Location = new System.Drawing.Point(14, 84);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(67, 18);
            this.label27.TabIndex = 39;
            this.label27.Text = "Provincia:";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label28
            // 
            this.label28.Location = new System.Drawing.Point(702, 4);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(74, 18);
            this.label28.TabIndex = 37;
            this.label28.Text = "NIF:";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label29
            // 
            this.label29.Location = new System.Drawing.Point(14, 24);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(67, 18);
            this.label29.TabIndex = 34;
            this.label29.Text = "Nombre:";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label30
            // 
            this.label30.Location = new System.Drawing.Point(14, 4);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(67, 18);
            this.label30.TabIndex = 33;
            this.label30.Text = "Cód.Cliente:";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label31
            // 
            this.label31.Location = new System.Drawing.Point(14, 64);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(67, 18);
            this.label31.TabIndex = 41;
            this.label31.Text = "C.P.:";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label32
            // 
            this.label32.Location = new System.Drawing.Point(14, 124);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(67, 18);
            this.label32.TabIndex = 35;
            this.label32.Text = "Teléfono:";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label33
            // 
            this.label33.Location = new System.Drawing.Point(14, 144);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(67, 18);
            this.label33.TabIndex = 32;
            this.label33.Text = "Tel. Móvil:";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label34
            // 
            this.label34.Location = new System.Drawing.Point(256, 124);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(50, 18);
            this.label34.TabIndex = 38;
            this.label34.Text = "Fax:";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtFecNacim_COM
            // 
            this.txtFecNacim_COM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtFecNacim_COM.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsClientes1, "GetCliente_COM.dFecNacimiento_COM", true));
            this.txtFecNacim_COM.Location = new System.Drawing.Point(94, 102);
            this.txtFecNacim_COM.Name = "txtFecNacim_COM";
            this.txtFecNacim_COM.ReadOnly = true;
            this.txtFecNacim_COM.Size = new System.Drawing.Size(130, 20);
            this.txtFecNacim_COM.TabIndex = 16;
            this.txtFecNacim_COM.TabStop = false;
            // 
            // txtObservaciones_COM
            // 
            this.txtObservaciones_COM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtObservaciones_COM.Location = new System.Drawing.Point(94, 164);
            this.txtObservaciones_COM.Multiline = true;
            this.txtObservaciones_COM.Name = "txtObservaciones_COM";
            this.txtObservaciones_COM.ReadOnly = true;
            this.txtObservaciones_COM.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObservaciones_COM.Size = new System.Drawing.Size(354, 114);
            this.txtObservaciones_COM.TabIndex = 20;
            this.txtObservaciones_COM.TabStop = false;
            // 
            // label40
            // 
            this.label40.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label40.Location = new System.Drawing.Point(14, 164);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(95, 18);
            this.label40.TabIndex = 3;
            this.label40.Text = "Observaciones:";
            this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label38
            // 
            this.label38.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label38.Location = new System.Drawing.Point(14, 104);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(74, 18);
            this.label38.TabIndex = 1;
            this.label38.Text = "F.Nacimiento:";
            this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btAccionesMark
            // 
            this.btAccionesMark.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btAccionesMark.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAccionesMark.ForeColor = System.Drawing.Color.Black;
            this.btAccionesMark.Location = new System.Drawing.Point(86, 454);
            this.btAccionesMark.Name = "btAccionesMark";
            this.btAccionesMark.Size = new System.Drawing.Size(200, 31);
            this.btAccionesMark.TabIndex = 3;
            this.btAccionesMark.Text = "&2 - Acciones Marketing";
            this.btAccionesMark.UseVisualStyleBackColor = true;
            this.btAccionesMark.Click += new System.EventHandler(this.btAccionesMark_Click);
            // 
            // btCRM
            // 
            this.btCRM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btCRM.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCRM.ForeColor = System.Drawing.Color.Black;
            this.btCRM.Location = new System.Drawing.Point(4, 454);
            this.btCRM.Name = "btCRM";
            this.btCRM.Size = new System.Drawing.Size(82, 31);
            this.btCRM.TabIndex = 2;
            this.btCRM.Text = "&1 - CRM";
            this.btCRM.UseVisualStyleBackColor = true;
            this.btCRM.Click += new System.EventHandler(this.btCRM_Click);
            // 
            // pnAccionesMark
            // 
            this.pnAccionesMark.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnAccionesMark.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnAccionesMark.Controls.Add(this.panel7);
            this.pnAccionesMark.ForeColor = System.Drawing.Color.Black;
            this.pnAccionesMark.Location = new System.Drawing.Point(1, 1673);
            this.pnAccionesMark.Name = "pnAccionesMark";
            this.pnAccionesMark.Size = new System.Drawing.Size(1478, 285);
            this.pnAccionesMark.TabIndex = 10;
            // 
            // panel7
            // 
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel7.Controls.Add(this.lblTotAccionesMark);
            this.panel7.Controls.Add(this.labelGradient9);
            this.panel7.Controls.Add(this.dgAccionesMark);
            this.panel7.Location = new System.Drawing.Point(2, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1469, 280);
            this.panel7.TabIndex = 2;
            // 
            // lblTotAccionesMark
            // 
            this.lblTotAccionesMark.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.lblTotAccionesMark.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotAccionesMark.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotAccionesMark.ForeColor = System.Drawing.Color.Black;
            this.lblTotAccionesMark.Location = new System.Drawing.Point(1407, 0);
            this.lblTotAccionesMark.Name = "lblTotAccionesMark";
            this.lblTotAccionesMark.Size = new System.Drawing.Size(60, 18);
            this.lblTotAccionesMark.TabIndex = 1;
            this.lblTotAccionesMark.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelGradient9
            // 
            this.labelGradient9.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelGradient9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGradient9.ForeColor = System.Drawing.Color.White;
            this.labelGradient9.GradientColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.labelGradient9.GradientColorTwo = System.Drawing.Color.White;
            this.labelGradient9.Location = new System.Drawing.Point(0, 0);
            this.labelGradient9.Name = "labelGradient9";
            this.labelGradient9.Size = new System.Drawing.Size(1465, 18);
            this.labelGradient9.TabIndex = 0;
            this.labelGradient9.Text = "Acciones de Marketing Asociadas al Cliente";
            this.labelGradient9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgAccionesMark
            // 
            this.dgAccionesMark.AlternatingBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.dgAccionesMark.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.dgAccionesMark.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.dgAccionesMark.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.dgAccionesMark.CaptionText = "Acciones de Marketing Asociadas al Cliente";
            this.dgAccionesMark.CaptionVisible = false;
            this.dgAccionesMark.DataMember = "ListaAccionesMarkClientes";
            this.dgAccionesMark.DataSource = this.dsClientes1;
            this.dgAccionesMark.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgAccionesMark.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgAccionesMark.Location = new System.Drawing.Point(-2, 18);
            this.dgAccionesMark.Name = "dgAccionesMark";
            this.dgAccionesMark.PreferredRowHeight = 32;
            this.dgAccionesMark.ReadOnly = true;
            this.dgAccionesMark.RowHeaderWidth = 17;
            this.dgAccionesMark.Size = new System.Drawing.Size(1469, 258);
            this.dgAccionesMark.TabIndex = 0;
            this.dgAccionesMark.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle2});
            this.dgAccionesMark.CurrentCellChanged += new System.EventHandler(this.dgAccionesMark_CurrentCellChanged);
            // 
            // dataGridTableStyle2
            // 
            this.dataGridTableStyle2.AlternatingBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.dataGridTableStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.dataGridTableStyle2.DataGrid = this.dgAccionesMark;
            this.dataGridTableStyle2.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn20,
            this.dataGridTextBoxColumn21,
            this.dataGridTextBoxColumn22,
            this.dataGridTextBoxColumn23,
            this.dataGridTextBoxColumn24});
            this.dataGridTableStyle2.HeaderBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle2.MappingName = "ListaAccionesMarkClientes";
            this.dataGridTableStyle2.PreferredRowHeight = 32;
            this.dataGridTableStyle2.RowHeaderWidth = 17;
            // 
            // dataGridTextBoxColumn20
            // 
            this.dataGridTextBoxColumn20.Format = "";
            this.dataGridTextBoxColumn20.FormatInfo = null;
            this.dataGridTextBoxColumn20.HeaderText = "Acción";
            this.dataGridTextBoxColumn20.MappingName = "sIdAccion";
            this.dataGridTextBoxColumn20.NullText = "";
            this.dataGridTextBoxColumn20.Width = 480;
            // 
            // dataGridTextBoxColumn21
            // 
            this.dataGridTextBoxColumn21.Format = "dd/MM/yyyy";
            this.dataGridTextBoxColumn21.FormatInfo = null;
            this.dataGridTextBoxColumn21.HeaderText = "F. Entrega";
            this.dataGridTextBoxColumn21.MappingName = "dFechaEntrega";
            this.dataGridTextBoxColumn21.NullText = "";
            this.dataGridTextBoxColumn21.Width = 110;
            // 
            // dataGridTextBoxColumn22
            // 
            this.dataGridTextBoxColumn22.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn22.Format = "";
            this.dataGridTextBoxColumn22.FormatInfo = null;
            this.dataGridTextBoxColumn22.HeaderText = "Cantidad";
            this.dataGridTextBoxColumn22.MappingName = "fCantidad";
            this.dataGridTextBoxColumn22.NullText = "";
            this.dataGridTextBoxColumn22.Width = 75;
            // 
            // dataGridTextBoxColumn23
            // 
            this.dataGridTextBoxColumn23.Format = "";
            this.dataGridTextBoxColumn23.FormatInfo = null;
            this.dataGridTextBoxColumn23.HeaderText = "Cód.Coste";
            this.dataGridTextBoxColumn23.MappingName = "sCCoste";
            this.dataGridTextBoxColumn23.NullText = "";
            this.dataGridTextBoxColumn23.Width = 110;
            // 
            // dataGridTextBoxColumn24
            // 
            this.dataGridTextBoxColumn24.Format = "";
            this.dataGridTextBoxColumn24.FormatInfo = null;
            this.dataGridTextBoxColumn24.HeaderText = "Observaciones";
            this.dataGridTextBoxColumn24.MappingName = "tObservEntrega";
            this.dataGridTextBoxColumn24.NullText = "";
            this.dataGridTextBoxColumn24.Width = 600;
            // 
            // pnCRM_COM
            // 
            this.pnCRM_COM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnCRM_COM.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnCRM_COM.Controls.Add(this.ucUltimasVisitas_COM);
            this.pnCRM_COM.Controls.Add(this.panel1);
            this.pnCRM_COM.Controls.Add(this.panel3);
            this.pnCRM_COM.Controls.Add(this.panel2);
            this.pnCRM_COM.ForeColor = System.Drawing.Color.Black;
            this.pnCRM_COM.Location = new System.Drawing.Point(1, 1089);
            this.pnCRM_COM.Name = "pnCRM_COM";
            this.pnCRM_COM.Size = new System.Drawing.Size(1278, 285);
            this.pnCRM_COM.TabIndex = 8;
            // 
            // ucUltimasVisitas_COM
            // 
            this.ucUltimasVisitas_COM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ucUltimasVisitas_COM.ForeColor = System.Drawing.Color.Black;
            this.ucUltimasVisitas_COM.Location = new System.Drawing.Point(528, 4);
            this.ucUltimasVisitas_COM.Name = "ucUltimasVisitas_COM";
            this.ucUltimasVisitas_COM.Size = new System.Drawing.Size(400, 135);
            this.ucUltimasVisitas_COM.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.lblToolTipBoton);
            this.panel1.Controls.Add(this.labelGradient2);
            this.panel1.Controls.Add(this.dgCentrosCOM);
            this.panel1.Controls.Add(this.lblTotCentrosCOM);
            this.panel1.Location = new System.Drawing.Point(2, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(520, 135);
            this.panel1.TabIndex = 5;
            // 
            // lblToolTipBoton
            // 
            this.lblToolTipBoton.BackColor = System.Drawing.SystemColors.Info;
            this.lblToolTipBoton.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblToolTipBoton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToolTipBoton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblToolTipBoton.Location = new System.Drawing.Point(0, 0);
            this.lblToolTipBoton.Name = "lblToolTipBoton";
            this.lblToolTipBoton.Size = new System.Drawing.Size(12, 13);
            this.lblToolTipBoton.TabIndex = 78;
            this.lblToolTipBoton.Text = "O";
            this.lblToolTipBoton.Visible = false;
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
            this.labelGradient2.Size = new System.Drawing.Size(516, 18);
            this.labelGradient2.TabIndex = 1;
            this.labelGradient2.Text = "Centros";
            this.labelGradient2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgCentrosCOM
            // 
            this.dgCentrosCOM.AlternatingBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.dgCentrosCOM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.dgCentrosCOM.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.dgCentrosCOM.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.dgCentrosCOM.CaptionText = "Centros";
            this.dgCentrosCOM.CaptionVisible = false;
            this.dgCentrosCOM.DataMember = "ListaCentros_porCliente_COM";
            this.dgCentrosCOM.DataSource = this.dsClientes1;
            this.dgCentrosCOM.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgCentrosCOM.Location = new System.Drawing.Point(-2, 18);
            this.dgCentrosCOM.Name = "dgCentrosCOM";
            this.dgCentrosCOM.ReadOnly = true;
            this.dgCentrosCOM.RowHeaderWidth = 17;
            this.dgCentrosCOM.Size = new System.Drawing.Size(519, 114);
            this.dgCentrosCOM.TabIndex = 0;
            this.dgCentrosCOM.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle5});
            this.dgCentrosCOM.CurrentCellChanged += new System.EventHandler(this.dgCentrosCOM_CurrentCellChanged);
            this.dgCentrosCOM.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dgCentrosCOM_MouseMove);
            // 
            // dataGridTableStyle5
            // 
            this.dataGridTableStyle5.AlternatingBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.dataGridTableStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.dataGridTableStyle5.DataGrid = this.dgCentrosCOM;
            this.dataGridTableStyle5.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn29,
            this.dataGridTextBoxColumn30,
            this.dataGridTextBoxColumn31,
            this.dataGridTextBoxColumn44,
            this.dataGridTextBoxColumn40});
            this.dataGridTableStyle5.HeaderBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridTableStyle5.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle5.MappingName = "ListaCentros_porCliente_COM";
            this.dataGridTableStyle5.RowHeaderWidth = 17;
            // 
            // dataGridTextBoxColumn29
            // 
            this.dataGridTextBoxColumn29.Format = "";
            this.dataGridTextBoxColumn29.FormatInfo = null;
            this.dataGridTextBoxColumn29.HeaderText = "Relación";
            this.dataGridTextBoxColumn29.MappingName = "tRelacionTipoCliCen";
            this.dataGridTextBoxColumn29.NullText = "";
            this.dataGridTextBoxColumn29.Width = 75;
            // 
            // dataGridTextBoxColumn30
            // 
            this.dataGridTextBoxColumn30.Format = "";
            this.dataGridTextBoxColumn30.FormatInfo = null;
            this.dataGridTextBoxColumn30.HeaderText = "Cód. Centro";
            this.dataGridTextBoxColumn30.MappingName = "sIdCentro";
            this.dataGridTextBoxColumn30.NullText = "";
            this.dataGridTextBoxColumn30.Width = 65;
            // 
            // dataGridTextBoxColumn31
            // 
            this.dataGridTextBoxColumn31.Format = "";
            this.dataGridTextBoxColumn31.FormatInfo = null;
            this.dataGridTextBoxColumn31.HeaderText = "Nombre Centro";
            this.dataGridTextBoxColumn31.MappingName = "sDescripcion";
            this.dataGridTextBoxColumn31.NullText = "";
            this.dataGridTextBoxColumn31.Width = 230;
            // 
            // dataGridTextBoxColumn44
            // 
            this.dataGridTextBoxColumn44.Format = "";
            this.dataGridTextBoxColumn44.FormatInfo = null;
            this.dataGridTextBoxColumn44.HeaderText = "Red";
            this.dataGridTextBoxColumn44.MappingName = "Red";
            this.dataGridTextBoxColumn44.NullText = "";
            this.dataGridTextBoxColumn44.Width = 70;
            // 
            // dataGridTextBoxColumn40
            // 
            this.dataGridTextBoxColumn40.Format = "";
            this.dataGridTextBoxColumn40.FormatInfo = null;
            this.dataGridTextBoxColumn40.MappingName = "Boton";
            this.dataGridTextBoxColumn40.NullText = "";
            this.dataGridTextBoxColumn40.Width = 40;
            // 
            // lblTotCentrosCOM
            // 
            this.lblTotCentrosCOM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.lblTotCentrosCOM.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotCentrosCOM.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotCentrosCOM.ForeColor = System.Drawing.Color.Black;
            this.lblTotCentrosCOM.Location = new System.Drawing.Point(457, 0);
            this.lblTotCentrosCOM.Name = "lblTotCentrosCOM";
            this.lblTotCentrosCOM.Size = new System.Drawing.Size(60, 18);
            this.lblTotCentrosCOM.TabIndex = 1;
            this.lblTotCentrosCOM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.lblTotProductos);
            this.panel3.Controls.Add(this.labelGradient4);
            this.panel3.Controls.Add(this.dgProductos);
            this.panel3.Location = new System.Drawing.Point(2, 146);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(520, 129);
            this.panel3.TabIndex = 0;
            // 
            // lblTotProductos
            // 
            this.lblTotProductos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.lblTotProductos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotProductos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotProductos.ForeColor = System.Drawing.Color.Black;
            this.lblTotProductos.Location = new System.Drawing.Point(458, 0);
            this.lblTotProductos.Name = "lblTotProductos";
            this.lblTotProductos.Size = new System.Drawing.Size(60, 18);
            this.lblTotProductos.TabIndex = 3;
            this.lblTotProductos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.labelGradient4.Size = new System.Drawing.Size(516, 18);
            this.labelGradient4.TabIndex = 0;
            this.labelGradient4.Text = "Productos";
            this.labelGradient4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgProductos
            // 
            this.dgProductos.AlternatingBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.dgProductos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.dgProductos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.dgProductos.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.dgProductos.CaptionText = "Productos";
            this.dgProductos.CaptionVisible = false;
            this.dgProductos.DataMember = "ListaProdClientes_COM";
            this.dgProductos.DataSource = this.dsClientes1;
            this.dgProductos.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgProductos.Location = new System.Drawing.Point(-2, 18);
            this.dgProductos.Name = "dgProductos";
            this.dgProductos.ReadOnly = true;
            this.dgProductos.RowHeaderWidth = 17;
            this.dgProductos.Size = new System.Drawing.Size(519, 108);
            this.dgProductos.TabIndex = 1;
            this.dgProductos.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle4});
            this.dgProductos.CurrentCellChanged += new System.EventHandler(this.dgProductos_CurrentCellChanged);
            // 
            // dataGridTableStyle4
            // 
            this.dataGridTableStyle4.AlternatingBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.dataGridTableStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.dataGridTableStyle4.DataGrid = this.dgProductos;
            this.dataGridTableStyle4.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn26,
            this.dataGridTextBoxColumn27,
            this.dataGridTextBoxColumn28});
            this.dataGridTableStyle4.HeaderBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridTableStyle4.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle4.MappingName = "ListaProdClientes_COM";
            this.dataGridTableStyle4.RowHeaderWidth = 17;
            // 
            // dataGridTextBoxColumn26
            // 
            this.dataGridTextBoxColumn26.Format = "";
            this.dataGridTextBoxColumn26.FormatInfo = null;
            this.dataGridTextBoxColumn26.HeaderText = "Prioridad";
            this.dataGridTextBoxColumn26.MappingName = "iPrioridad";
            this.dataGridTextBoxColumn26.NullText = "";
            this.dataGridTextBoxColumn26.Width = 70;
            // 
            // dataGridTextBoxColumn27
            // 
            this.dataGridTextBoxColumn27.Format = "";
            this.dataGridTextBoxColumn27.FormatInfo = null;
            this.dataGridTextBoxColumn27.HeaderText = "Cód.Prod.";
            this.dataGridTextBoxColumn27.MappingName = "sIdProducto";
            this.dataGridTextBoxColumn27.NullText = "";
            this.dataGridTextBoxColumn27.Width = 70;
            // 
            // dataGridTextBoxColumn28
            // 
            this.dataGridTextBoxColumn28.Format = "";
            this.dataGridTextBoxColumn28.FormatInfo = null;
            this.dataGridTextBoxColumn28.HeaderText = "Producto";
            this.dataGridTextBoxColumn28.MappingName = "sDescripcion";
            this.dataGridTextBoxColumn28.NullText = "";
            this.dataGridTextBoxColumn28.Width = 320;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.lblTotEspecialidades);
            this.panel2.Controls.Add(this.labelGradient3);
            this.panel2.Controls.Add(this.dgEspecialidades);
            this.panel2.Location = new System.Drawing.Point(528, 146);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(400, 129);
            this.panel2.TabIndex = 0;
            // 
            // lblTotEspecialidades
            // 
            this.lblTotEspecialidades.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.lblTotEspecialidades.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotEspecialidades.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotEspecialidades.ForeColor = System.Drawing.Color.Black;
            this.lblTotEspecialidades.Location = new System.Drawing.Point(339, 0);
            this.lblTotEspecialidades.Name = "lblTotEspecialidades";
            this.lblTotEspecialidades.Size = new System.Drawing.Size(60, 18);
            this.lblTotEspecialidades.TabIndex = 2;
            this.lblTotEspecialidades.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelGradient3
            // 
            this.labelGradient3.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelGradient3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGradient3.ForeColor = System.Drawing.Color.White;
            this.labelGradient3.GradientColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.labelGradient3.GradientColorTwo = System.Drawing.Color.White;
            this.labelGradient3.Location = new System.Drawing.Point(0, 0);
            this.labelGradient3.Name = "labelGradient3";
            this.labelGradient3.Size = new System.Drawing.Size(396, 18);
            this.labelGradient3.TabIndex = 0;
            this.labelGradient3.Text = "Especialidades";
            this.labelGradient3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgEspecialidades
            // 
            this.dgEspecialidades.AlternatingBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.dgEspecialidades.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.dgEspecialidades.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.dgEspecialidades.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.dgEspecialidades.CaptionText = "Especialidades";
            this.dgEspecialidades.CaptionVisible = false;
            this.dgEspecialidades.DataMember = "ListaEspecClientes_COM";
            this.dgEspecialidades.DataSource = this.dsClientes1;
            this.dgEspecialidades.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgEspecialidades.Location = new System.Drawing.Point(-2, 18);
            this.dgEspecialidades.Name = "dgEspecialidades";
            this.dgEspecialidades.ReadOnly = true;
            this.dgEspecialidades.RowHeaderWidth = 17;
            this.dgEspecialidades.Size = new System.Drawing.Size(398, 108);
            this.dgEspecialidades.TabIndex = 0;
            this.dgEspecialidades.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle3});
            this.dgEspecialidades.CurrentCellChanged += new System.EventHandler(this.dgEspecialidades_CurrentCellChanged);
            // 
            // dataGridTableStyle3
            // 
            this.dataGridTableStyle3.AlternatingBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.dataGridTableStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.dataGridTableStyle3.DataGrid = this.dgEspecialidades;
            this.dataGridTableStyle3.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn25});
            this.dataGridTableStyle3.HeaderBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridTableStyle3.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle3.MappingName = "ListaEspecClientes_COM";
            this.dataGridTableStyle3.RowHeaderWidth = 17;
            // 
            // dataGridTextBoxColumn25
            // 
            this.dataGridTextBoxColumn25.Format = "";
            this.dataGridTextBoxColumn25.FormatInfo = null;
            this.dataGridTextBoxColumn25.HeaderText = "Nombre Especialidad";
            this.dataGridTextBoxColumn25.MappingName = "tEspecialidad";
            this.dataGridTextBoxColumn25.NullText = "";
            this.dataGridTextBoxColumn25.Width = 290;
            // 
            // pnCRM_SAP
            // 
            this.pnCRM_SAP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnCRM_SAP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnCRM_SAP.Controls.Add(this.ucUltimasVisitas_SAP);
            this.pnCRM_SAP.Controls.Add(this.ucRankingMatCli_SAP);
            this.pnCRM_SAP.Controls.Add(this.ucUltimoPedido_SAP);
            this.pnCRM_SAP.ForeColor = System.Drawing.Color.Black;
            this.pnCRM_SAP.Location = new System.Drawing.Point(0, 1383);
            this.pnCRM_SAP.Name = "pnCRM_SAP";
            this.pnCRM_SAP.Size = new System.Drawing.Size(1279, 285);
            this.pnCRM_SAP.TabIndex = 9;
            // 
            // ucUltimasVisitas_SAP
            // 
            this.ucUltimasVisitas_SAP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ucUltimasVisitas_SAP.ForeColor = System.Drawing.Color.Black;
            this.ucUltimasVisitas_SAP.Location = new System.Drawing.Point(524, 145);
            this.ucUltimasVisitas_SAP.Name = "ucUltimasVisitas_SAP";
            this.ucUltimasVisitas_SAP.Size = new System.Drawing.Size(400, 135);
            this.ucUltimasVisitas_SAP.TabIndex = 9;
            // 
            // ucRankingMatCli_SAP
            // 
            this.ucRankingMatCli_SAP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ucRankingMatCli_SAP.ForeColor = System.Drawing.Color.Black;
            this.ucRankingMatCli_SAP.Location = new System.Drawing.Point(524, 0);
            this.ucRankingMatCli_SAP.Name = "ucRankingMatCli_SAP";
            this.ucRankingMatCli_SAP.Size = new System.Drawing.Size(400, 145);
            this.ucRankingMatCli_SAP.TabIndex = 8;
            // 
            // ucUltimoPedido_SAP
            // 
            this.ucUltimoPedido_SAP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ucUltimoPedido_SAP.Location = new System.Drawing.Point(10, 2);
            this.ucUltimoPedido_SAP.Name = "ucUltimoPedido_SAP";
            this.ucUltimoPedido_SAP.Size = new System.Drawing.Size(509, 250);
            this.ucUltimoPedido_SAP.TabIndex = 6;
            // 
            // sqldaListaAccionesMark
            // 
            this.sqldaListaAccionesMark.SelectCommand = this.sqlSelectCommand5;
            this.sqldaListaAccionesMark.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaAccionesMarkClientes", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iIdAccion", "iIdAccion"),
                        new System.Data.Common.DataColumnMapping("sIdAccion", "sIdAccion"),
                        new System.Data.Common.DataColumnMapping("dFechaEntrega", "dFechaEntrega"),
                        new System.Data.Common.DataColumnMapping("tFechaEntrega", "tFechaEntrega"),
                        new System.Data.Common.DataColumnMapping("fCantidad", "fCantidad"),
                        new System.Data.Common.DataColumnMapping("sCCoste", "sCCoste"),
                        new System.Data.Common.DataColumnMapping("tObservEntrega", "tObservEntrega")})});
            // 
            // sqlSelectCommand5
            // 
            this.sqlSelectCommand5.CommandText = "[ListaAccionesMarkClientes]";
            this.sqlSelectCommand5.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand5.Connection = this.sqlConn;
            this.sqlSelectCommand5.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4)});
            // 
            // sqldaListaEspecClientes_COM
            // 
            this.sqldaListaEspecClientes_COM.SelectCommand = this.sqlSelectCommand6;
            this.sqldaListaEspecClientes_COM.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaEspecClientes_COM", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("tEspecialidad", "tEspecialidad")})});
            // 
            // sqlSelectCommand6
            // 
            this.sqlSelectCommand6.CommandText = "[ListaEspecClientes_COM]";
            this.sqlSelectCommand6.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand6.Connection = this.sqlConn;
            this.sqlSelectCommand6.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4)});
            // 
            // sqldaListaProdClientes_COM
            // 
            this.sqldaListaProdClientes_COM.SelectCommand = this.sqlSelectCommand7;
            this.sqldaListaProdClientes_COM.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaProdClientes_COM", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("sIdProducto", "sIdProducto"),
                        new System.Data.Common.DataColumnMapping("sDescripcion", "sDescripcion"),
                        new System.Data.Common.DataColumnMapping("iPrioridad", "iPrioridad")})});
            // 
            // sqlSelectCommand7
            // 
            this.sqlSelectCommand7.CommandText = "[ListaProdClientes_COM]";
            this.sqlSelectCommand7.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand7.Connection = this.sqlConn;
            this.sqlSelectCommand7.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4)});
            // 
            // sqlListaCentros_porClienteCOM
            // 
            this.sqlListaCentros_porClienteCOM.SelectCommand = this.sqlSelectCommand8;
            this.sqlListaCentros_porClienteCOM.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
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
                        new System.Data.Common.DataColumnMapping("tObservaciones", "tObservaciones"),
                        new System.Data.Common.DataColumnMapping("Boton", "Boton")})});
            // 
            // sqlSelectCommand8
            // 
            this.sqlSelectCommand8.CommandText = "[ListaCentros_porCliente_COM]";
            this.sqlSelectCommand8.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand8.Connection = this.sqlConn;
            this.sqlSelectCommand8.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4)});
            // 
            // sqldaListaCentros_porCliente_SAP
            // 
            this.sqldaListaCentros_porCliente_SAP.SelectCommand = this.sqlSelectCommand9;
            this.sqldaListaCentros_porCliente_SAP.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaCentros_porCliente_SAP", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("sIdCentro", "sIdCentro"),
                        new System.Data.Common.DataColumnMapping("sDescripcion", "sDescripcion")})});
            // 
            // sqlSelectCommand9
            // 
            this.sqlSelectCommand9.CommandText = "[ListaCentros_porCliente_SAP]";
            this.sqlSelectCommand9.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand9.Connection = this.sqlConn;
            this.sqlSelectCommand9.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4)});
            // 
            // sqldaListaContactos_porCliente_SAP
            // 
            this.sqldaListaContactos_porCliente_SAP.SelectCommand = this.sqlSelectCommand10;
            this.sqldaListaContactos_porCliente_SAP.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaContactos_porCliente_SAP", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("sNombre", "sNombre"),
                        new System.Data.Common.DataColumnMapping("tIdCargoContacto", "tIdCargoContacto")})});
            // 
            // sqlSelectCommand10
            // 
            this.sqlSelectCommand10.CommandText = "[ListaContactos_porCliente_SAP]";
            this.sqlSelectCommand10.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand10.Connection = this.sqlConn;
            this.sqlSelectCommand10.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4)});
            // 
            // sqldaListaRelacionClienteCentro
            // 
            this.sqldaListaRelacionClienteCentro.SelectCommand = this.sqlSelectCommand11;
            this.sqldaListaRelacionClienteCentro.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaRelacionClienteCentro", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("Orden", "Orden"),
                        new System.Data.Common.DataColumnMapping("Valor", "Valor"),
                        new System.Data.Common.DataColumnMapping("Descripcion", "Descripcion")})});
            // 
            // sqlSelectCommand11
            // 
            this.sqlSelectCommand11.CommandText = "[ListaRelacionClienteCentro]";
            this.sqlSelectCommand11.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand11.Connection = this.sqlConn;
            this.sqlSelectCommand11.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null)});
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
            this.menuEliminar.Click += new System.EventHandler(this.menuEliminar_Click);
            // 
            // ucBotoneraSecundaria1
            // 
            this.ucBotoneraSecundaria1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(117)))), ((int)(((byte)(1)))));
            this.ucBotoneraSecundaria1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucBotoneraSecundaria1.ForeColor = System.Drawing.Color.Black;
            this.ucBotoneraSecundaria1.Location = new System.Drawing.Point(0, 0);
            this.ucBotoneraSecundaria1.Name = "ucBotoneraSecundaria1";
            this.ucBotoneraSecundaria1.Size = new System.Drawing.Size(1604, 38);
            this.ucBotoneraSecundaria1.TabIndex = 41;
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
            this.labelGradient6.Size = new System.Drawing.Size(1484, 18);
            this.labelGradient6.TabIndex = 0;
            this.labelGradient6.Text = "Clientes";
            this.labelGradient6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.lblNumRegistros);
            this.panel4.Controls.Add(this.labelGradient6);
            this.panel4.Controls.Add(this.dtgGeneral);
            this.panel4.Location = new System.Drawing.Point(1, 157);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1488, 293);
            this.panel4.TabIndex = 1;
            // 
            // btDatosCliente
            // 
            this.btDatosCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btDatosCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDatosCliente.ForeColor = System.Drawing.Color.Black;
            this.btDatosCliente.Location = new System.Drawing.Point(445, 454);
            this.btDatosCliente.Name = "btDatosCliente";
            this.btDatosCliente.Size = new System.Drawing.Size(154, 31);
            this.btDatosCliente.TabIndex = 5;
            this.btDatosCliente.Text = "&4 - Datos Cliente";
            this.btDatosCliente.UseVisualStyleBackColor = true;
            this.btDatosCliente.Click += new System.EventHandler(this.btDatosCliente_Click);
            // 
            // pnMayoristas
            // 
            this.pnMayoristas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnMayoristas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnMayoristas.Controls.Add(this.panel9);
            this.pnMayoristas.ForeColor = System.Drawing.Color.Black;
            this.pnMayoristas.Location = new System.Drawing.Point(1, 1963);
            this.pnMayoristas.Name = "pnMayoristas";
            this.pnMayoristas.Size = new System.Drawing.Size(1487, 285);
            this.pnMayoristas.TabIndex = 11;
            // 
            // panel9
            // 
            this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel9.Controls.Add(this.dgMayoristas);
            this.panel9.Controls.Add(this.lblTotMayoristas);
            this.panel9.Controls.Add(this.labelGradient5);
            this.panel9.Location = new System.Drawing.Point(2, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(1478, 280);
            this.panel9.TabIndex = 0;
            // 
            // dgMayoristas
            // 
            this.dgMayoristas.CaptionVisible = false;
            this.dgMayoristas.DataMember = "ListaMayoristasClientes_SAP";
            this.dgMayoristas.DataSource = this.dsClientes1;
            this.dgMayoristas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgMayoristas.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgMayoristas.Location = new System.Drawing.Point(-2, 19);
            this.dgMayoristas.Name = "dgMayoristas";
            this.dgMayoristas.ReadOnly = true;
            this.dgMayoristas.RowHeaderWidth = 17;
            this.dgMayoristas.Size = new System.Drawing.Size(1476, 260);
            this.dgMayoristas.TabIndex = 3;
            this.dgMayoristas.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle8});
            // 
            // dataGridTableStyle8
            // 
            this.dataGridTableStyle8.DataGrid = this.dgMayoristas;
            this.dataGridTableStyle8.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn43,
            this.dataGridTextBoxColumn36,
            this.dataGridTextBoxColumn37,
            this.dataGridTextBoxColumn39});
            this.dataGridTableStyle8.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle8.MappingName = "ListaMayoristasClientes_SAP";
            this.dataGridTableStyle8.RowHeaderWidth = 17;
            // 
            // dataGridTextBoxColumn43
            // 
            this.dataGridTextBoxColumn43.Format = "";
            this.dataGridTextBoxColumn43.FormatInfo = null;
            this.dataGridTextBoxColumn43.HeaderText = "Tipo";
            this.dataGridTextBoxColumn43.MappingName = "tInterlocutor";
            this.dataGridTextBoxColumn43.NullText = "";
            this.dataGridTextBoxColumn43.Width = 120;
            // 
            // dataGridTextBoxColumn36
            // 
            this.dataGridTextBoxColumn36.Format = "";
            this.dataGridTextBoxColumn36.FormatInfo = null;
            this.dataGridTextBoxColumn36.HeaderText = "Código Interlocutor";
            this.dataGridTextBoxColumn36.MappingName = "sIdCliente";
            this.dataGridTextBoxColumn36.NullText = "";
            this.dataGridTextBoxColumn36.Width = 160;
            // 
            // dataGridTextBoxColumn37
            // 
            this.dataGridTextBoxColumn37.Format = "";
            this.dataGridTextBoxColumn37.FormatInfo = null;
            this.dataGridTextBoxColumn37.HeaderText = "Nombre Interlocutor";
            this.dataGridTextBoxColumn37.MappingName = "sNombre";
            this.dataGridTextBoxColumn37.NullText = "";
            this.dataGridTextBoxColumn37.Width = 700;
            // 
            // dataGridTextBoxColumn39
            // 
            this.dataGridTextBoxColumn39.Format = "";
            this.dataGridTextBoxColumn39.FormatInfo = null;
            this.dataGridTextBoxColumn39.HeaderText = "Cód.Cliente del Interlocutor";
            this.dataGridTextBoxColumn39.MappingName = "sIdCodClientedelMay";
            this.dataGridTextBoxColumn39.NullText = "";
            this.dataGridTextBoxColumn39.Width = 300;
            // 
            // lblTotMayoristas
            // 
            this.lblTotMayoristas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.lblTotMayoristas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotMayoristas.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotMayoristas.ForeColor = System.Drawing.Color.Black;
            this.lblTotMayoristas.Location = new System.Drawing.Point(1409, -1);
            this.lblTotMayoristas.Name = "lblTotMayoristas";
            this.lblTotMayoristas.Size = new System.Drawing.Size(60, 18);
            this.lblTotMayoristas.TabIndex = 2;
            this.lblTotMayoristas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.labelGradient5.Size = new System.Drawing.Size(1474, 18);
            this.labelGradient5.TabIndex = 0;
            this.labelGradient5.Text = "Interlocutores Asociados";
            this.labelGradient5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sqldaListaMayoristasClientes_SAP
            // 
            this.sqldaListaMayoristasClientes_SAP.SelectCommand = this.sqlSelectCommand12;
            this.sqldaListaMayoristasClientes_SAP.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaMayoristasClientes_SAP", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("sGrupoClientes", "sGrupoClientes"),
                        new System.Data.Common.DataColumnMapping("tInterlocutor", "tInterlocutor"),
                        new System.Data.Common.DataColumnMapping("iIdClienteMayorista", "iIdClienteMayorista"),
                        new System.Data.Common.DataColumnMapping("sIdCliente", "sIdCliente"),
                        new System.Data.Common.DataColumnMapping("sNombre", "sNombre"),
                        new System.Data.Common.DataColumnMapping("sIdCodClientedelMay", "sIdCodClientedelMay")})});
            // 
            // sqlSelectCommand12
            // 
            this.sqlSelectCommand12.CommandText = "[ListaMayoristasClientes_SAP]";
            this.sqlSelectCommand12.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand12.Connection = this.sqlConn;
            this.sqlSelectCommand12.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4)});
            // 
            // sqldaListaAficClientes_COM
            // 
            this.sqldaListaAficClientes_COM.SelectCommand = this.sqlSelectCommand13;
            this.sqldaListaAficClientes_COM.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaAficClientes_COM", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("sIdAficion", "sIdAficion"),
                        new System.Data.Common.DataColumnMapping("tAficion", "tAficion")})});
            // 
            // sqlSelectCommand13
            // 
            this.sqlSelectCommand13.CommandText = "[ListaAficClientes_COM]";
            this.sqlSelectCommand13.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand13.Connection = this.sqlConn;
            this.sqlSelectCommand13.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4)});
            // 
            // sqldaListaRedes
            // 
            this.sqldaListaRedes.SelectCommand = this.sqlCommand1;
            this.sqldaListaRedes.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaRedes", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("sValor", "sValor"),
                        new System.Data.Common.DataColumnMapping("sLiteral", "sLiteral")})});
            // 
            // sqlCommand1
            // 
            this.sqlCommand1.CommandText = "[ListaRedes]";
            this.sqlCommand1.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCommand1.Connection = this.sqlConn;
            this.sqlCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null)});
            // 
            // sqldaListaEstado
            // 
            this.sqldaListaEstado.SelectCommand = this.sqlCommand2;
            this.sqldaListaEstado.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaEstados", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("sValor", "sValor"),
                        new System.Data.Common.DataColumnMapping("sLiteral", "sLiteral")})});
            // 
            // sqlCommand2
            // 
            this.sqlCommand2.CommandText = "[ListaEstados]";
            this.sqlCommand2.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCommand2.Connection = this.sqlConn;
            this.sqlCommand2.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null)});
            // 
            // sqlCmdEliminarCLiente
            // 
            this.sqlCmdEliminarCLiente.CommandText = "[EliminarClienteCOM]";
            this.sqlCmdEliminarCLiente.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdEliminarCLiente.Connection = this.sqlConn;
            this.sqlCmdEliminarCLiente.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4)});
            // 
            // dsClientes2
            // 
            this.dsClientes2.DataSetName = "dsClientes";
            this.dsClientes2.Locale = new System.Globalization.CultureInfo("es-ES");
            this.dsClientes2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            // sqldaListaClientesOnLine
            // 
            this.sqldaListaClientesOnLine.SelectCommand = this.sqlCmdListaClientesOnLine;
            this.sqldaListaClientesOnLine.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaMClientesOnLine", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iIdCliente", "iIdCliente"),
                        new System.Data.Common.DataColumnMapping("sNombre", "sNombre"),
                        new System.Data.Common.DataColumnMapping("bOperativa", "bOperativa"),
                        new System.Data.Common.DataColumnMapping("bLinkLadival", "bLinkLadival"),
                        new System.Data.Common.DataColumnMapping("sUrl", "sUrl"),
                        new System.Data.Common.DataColumnMapping("iEstado", "iEstado")})});
            // 
            // sqlCmdListaClientesOnLine
            // 
            this.sqlCmdListaClientesOnLine.CommandText = "[ListaMClientesOnLine]";
            this.sqlCmdListaClientesOnLine.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdListaClientesOnLine.Connection = this.sqlConn;
            this.sqlCmdListaClientesOnLine.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sNombre", System.Data.SqlDbType.VarChar, 100),
            new System.Data.SqlClient.SqlParameter("@iOperativa", System.Data.SqlDbType.SmallInt),
            new System.Data.SqlClient.SqlParameter("@iLinkLadival", System.Data.SqlDbType.SmallInt),
            new System.Data.SqlClient.SqlParameter("@sUrl", System.Data.SqlDbType.VarChar, 50),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt)});
            // 
            // sqlCmdSetClientesOnLine
            // 
            this.sqlCmdSetClientesOnLine.CommandText = "[SetMClientesOnLine]";
            this.sqlCmdSetClientesOnLine.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdSetClientesOnLine.Connection = this.sqlConn;
            this.sqlCmdSetClientesOnLine.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@Accion", System.Data.SqlDbType.Int),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sNombre", System.Data.SqlDbType.VarChar, 100),
            new System.Data.SqlClient.SqlParameter("@bOperativa", System.Data.SqlDbType.Bit),
            new System.Data.SqlClient.SqlParameter("@bLinkLadival", System.Data.SqlDbType.Bit),
            new System.Data.SqlClient.SqlParameter("@sUrl", System.Data.SqlDbType.VarChar, 50),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt)});
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
            // sqlCmdGetRentabilidadColor
            // 
            this.sqlCmdGetRentabilidadColor.CommandText = "dbo.[GetRentabilidadColor]";
            this.sqlCmdGetRentabilidadColor.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdGetRentabilidadColor.Connection = this.sqlConn;
            this.sqlCmdGetRentabilidadColor.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@Rentabilidad", System.Data.SqlDbType.Float, 8)});
            // 
            // sqlCmdGetRentUltPedCli
            // 
            this.sqlCmdGetRentUltPedCli.CommandText = "dbo.[GetRentUltPedCli]";
            this.sqlCmdGetRentUltPedCli.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdGetRentUltPedCli.Connection = this.sqlConn;
            this.sqlCmdGetRentUltPedCli.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4)});
            // 
            // btFOnLine
            // 
            this.btFOnLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btFOnLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btFOnLine.ForeColor = System.Drawing.Color.Black;
            this.btFOnLine.Location = new System.Drawing.Point(599, 454);
            this.btFOnLine.Name = "btFOnLine";
            this.btFOnLine.Size = new System.Drawing.Size(193, 31);
            this.btFOnLine.TabIndex = 6;
            this.btFOnLine.Text = "&5 - Farmacias OnLine";
            this.btFOnLine.UseVisualStyleBackColor = true;
            this.btFOnLine.Click += new System.EventHandler(this.btFOnLine_Click);
            // 
            // pnFOnLine
            // 
            this.pnFOnLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnFOnLine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnFOnLine.Controls.Add(this.btFOEliminar);
            this.pnFOnLine.Controls.Add(this.btFOActualizar);
            this.pnFOnLine.Controls.Add(this.txtFOUrl);
            this.pnFOnLine.Controls.Add(this.label45);
            this.pnFOnLine.Controls.Add(this.cbFOLadival);
            this.pnFOnLine.Controls.Add(this.label44);
            this.pnFOnLine.Controls.Add(this.cbFOOperativa);
            this.pnFOnLine.Controls.Add(this.label43);
            this.pnFOnLine.Controls.Add(this.txtFONombreOnLine);
            this.pnFOnLine.Controls.Add(this.label42);
            this.pnFOnLine.Controls.Add(this.panel10);
            this.pnFOnLine.Location = new System.Drawing.Point(1, 2256);
            this.pnFOnLine.Name = "pnFOnLine";
            this.pnFOnLine.Size = new System.Drawing.Size(1487, 162);
            this.pnFOnLine.TabIndex = 43;
            // 
            // btFOEliminar
            // 
            this.btFOEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btFOEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btFOEliminar.Image")));
            this.btFOEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btFOEliminar.Location = new System.Drawing.Point(1334, 107);
            this.btFOEliminar.Name = "btFOEliminar";
            this.btFOEliminar.Size = new System.Drawing.Size(101, 33);
            this.btFOEliminar.TabIndex = 45;
            this.btFOEliminar.Text = "Eliminar";
            this.btFOEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btFOEliminar.Click += new System.EventHandler(this.btFOEliminar_Click);
            // 
            // btFOActualizar
            // 
            this.btFOActualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btFOActualizar.Image = ((System.Drawing.Image)(resources.GetObject("btFOActualizar.Image")));
            this.btFOActualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btFOActualizar.Location = new System.Drawing.Point(1196, 107);
            this.btFOActualizar.Name = "btFOActualizar";
            this.btFOActualizar.Size = new System.Drawing.Size(103, 33);
            this.btFOActualizar.TabIndex = 44;
            this.btFOActualizar.Text = "Actualizar";
            this.btFOActualizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btFOActualizar.Click += new System.EventHandler(this.btFOActualizar_Click);
            // 
            // txtFOUrl
            // 
            this.txtFOUrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFOUrl.Location = new System.Drawing.Point(61, 91);
            this.txtFOUrl.MaxLength = 50;
            this.txtFOUrl.Name = "txtFOUrl";
            this.txtFOUrl.Size = new System.Drawing.Size(405, 26);
            this.txtFOUrl.TabIndex = 43;
            // 
            // label45
            // 
            this.label45.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label45.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label45.Location = new System.Drawing.Point(12, 93);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(46, 23);
            this.label45.TabIndex = 42;
            this.label45.Text = "URL:";
            this.label45.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbFOLadival
            // 
            this.cbFOLadival.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFOLadival.FormattingEnabled = true;
            this.cbFOLadival.Items.AddRange(new object[] {
            "No",
            "Si"});
            this.cbFOLadival.Location = new System.Drawing.Point(1044, 50);
            this.cbFOLadival.Name = "cbFOLadival";
            this.cbFOLadival.Size = new System.Drawing.Size(76, 28);
            this.cbFOLadival.TabIndex = 41;
            // 
            // label44
            // 
            this.label44.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label44.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label44.Location = new System.Drawing.Point(832, 52);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(207, 23);
            this.label44.TabIndex = 40;
            this.label44.Text = "¿Poner link en web Ladival?";
            this.label44.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbFOOperativa
            // 
            this.cbFOOperativa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFOOperativa.FormattingEnabled = true;
            this.cbFOOperativa.Items.AddRange(new object[] {
            "No",
            "Si"});
            this.cbFOOperativa.Location = new System.Drawing.Point(720, 50);
            this.cbFOOperativa.Name = "cbFOOperativa";
            this.cbFOOperativa.Size = new System.Drawing.Size(76, 28);
            this.cbFOOperativa.TabIndex = 39;
            // 
            // label43
            // 
            this.label43.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label43.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label43.Location = new System.Drawing.Point(581, 52);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(133, 23);
            this.label43.TabIndex = 38;
            this.label43.Text = "¿Está operativa?";
            this.label43.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtFONombreOnLine
            // 
            this.txtFONombreOnLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFONombreOnLine.Location = new System.Drawing.Point(210, 50);
            this.txtFONombreOnLine.MaxLength = 50;
            this.txtFONombreOnLine.Name = "txtFONombreOnLine";
            this.txtFONombreOnLine.Size = new System.Drawing.Size(344, 26);
            this.txtFONombreOnLine.TabIndex = 36;
            // 
            // label42
            // 
            this.label42.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label42.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label42.Location = new System.Drawing.Point(12, 52);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(194, 23);
            this.label42.TabIndex = 37;
            this.label42.Text = "Nombre Farmacia OnLine:";
            this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel10.Controls.Add(this.txtFONombre);
            this.panel10.Controls.Add(this.txtFOCodCli);
            this.panel10.Controls.Add(this.label36);
            this.panel10.Controls.Add(this.label37);
            this.panel10.Location = new System.Drawing.Point(-1, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(1481, 43);
            this.panel10.TabIndex = 0;
            // 
            // txtFONombre
            // 
            this.txtFONombre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtFONombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFONombre.Location = new System.Drawing.Point(332, 7);
            this.txtFONombre.Name = "txtFONombre";
            this.txtFONombre.ReadOnly = true;
            this.txtFONombre.Size = new System.Drawing.Size(354, 26);
            this.txtFONombre.TabIndex = 13;
            this.txtFONombre.TabStop = false;
            // 
            // txtFOCodCli
            // 
            this.txtFOCodCli.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtFOCodCli.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFOCodCli.Location = new System.Drawing.Point(107, 7);
            this.txtFOCodCli.Name = "txtFOCodCli";
            this.txtFOCodCli.ReadOnly = true;
            this.txtFOCodCli.Size = new System.Drawing.Size(118, 26);
            this.txtFOCodCli.TabIndex = 12;
            this.txtFOCodCli.TabStop = false;
            // 
            // label36
            // 
            this.label36.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.Location = new System.Drawing.Point(261, 9);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(69, 18);
            this.label36.TabIndex = 11;
            this.label36.Text = "Nombre:";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label37
            // 
            this.label37.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label37.Location = new System.Drawing.Point(12, 9);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(95, 18);
            this.label37.TabIndex = 10;
            this.label37.Text = "Cód.Cliente:";
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnCRM_SAP_New
            // 
            this.pnCRM_SAP_New.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnCRM_SAP_New.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnCRM_SAP_New.Controls.Add(this.button1);
            this.pnCRM_SAP_New.Controls.Add(this.gbClubs);
            this.pnCRM_SAP_New.Location = new System.Drawing.Point(0, 2424);
            this.pnCRM_SAP_New.Name = "pnCRM_SAP_New";
            this.pnCRM_SAP_New.Size = new System.Drawing.Size(1487, 129);
            this.pnCRM_SAP_New.TabIndex = 44;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::GESTCRM.Properties.Resources.quesu;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(39, 83);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(218, 32);
            this.button1.TabIndex = 120;
            this.button1.Text = "Indicadores de Ventas";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // gbClubs
            // 
            this.gbClubs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gbClubs.Controls.Add(this.txtGarantias4);
            this.gbClubs.Controls.Add(this.txtGarantias3);
            this.gbClubs.Controls.Add(this.label49);
            this.gbClubs.Controls.Add(this.txtGarantias2);
            this.gbClubs.Controls.Add(this.txtGarantias);
            this.gbClubs.Controls.Add(this.txtGarantias1);
            this.gbClubs.Controls.Add(this.label50);
            this.gbClubs.Controls.Add(this.label51);
            this.gbClubs.Controls.Add(this.label52);
            this.gbClubs.Controls.Add(this.label53);
            this.gbClubs.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbClubs.ForeColor = System.Drawing.Color.Black;
            this.gbClubs.Location = new System.Drawing.Point(5, 3);
            this.gbClubs.Margin = new System.Windows.Forms.Padding(0);
            this.gbClubs.Name = "gbClubs";
            this.gbClubs.Padding = new System.Windows.Forms.Padding(0);
            this.gbClubs.Size = new System.Drawing.Size(1469, 61);
            this.gbClubs.TabIndex = 119;
            this.gbClubs.TabStop = false;
            this.gbClubs.Text = "CLUBS";
            // 
            // txtGarantias4
            // 
            this.txtGarantias4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtGarantias4.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtGarantias4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGarantias4.Location = new System.Drawing.Point(1250, 22);
            this.txtGarantias4.Name = "txtGarantias4";
            this.txtGarantias4.ReadOnly = true;
            this.txtGarantias4.Size = new System.Drawing.Size(200, 26);
            this.txtGarantias4.TabIndex = 117;
            this.txtGarantias4.TabStop = false;
            // 
            // txtGarantias3
            // 
            this.txtGarantias3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtGarantias3.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtGarantias3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGarantias3.Location = new System.Drawing.Point(971, 22);
            this.txtGarantias3.Name = "txtGarantias3";
            this.txtGarantias3.ReadOnly = true;
            this.txtGarantias3.Size = new System.Drawing.Size(200, 26);
            this.txtGarantias3.TabIndex = 116;
            this.txtGarantias3.TabStop = false;
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label49.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label49.ForeColor = System.Drawing.Color.Black;
            this.label49.Location = new System.Drawing.Point(74, 23);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(60, 20);
            this.label49.TabIndex = 108;
            this.label49.Text = "Club0:";
            // 
            // txtGarantias2
            // 
            this.txtGarantias2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtGarantias2.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtGarantias2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGarantias2.Location = new System.Drawing.Point(692, 22);
            this.txtGarantias2.Name = "txtGarantias2";
            this.txtGarantias2.ReadOnly = true;
            this.txtGarantias2.Size = new System.Drawing.Size(200, 26);
            this.txtGarantias2.TabIndex = 115;
            this.txtGarantias2.TabStop = false;
            // 
            // txtGarantias
            // 
            this.txtGarantias.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtGarantias.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtGarantias.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGarantias.Location = new System.Drawing.Point(134, 22);
            this.txtGarantias.Name = "txtGarantias";
            this.txtGarantias.ReadOnly = true;
            this.txtGarantias.Size = new System.Drawing.Size(200, 26);
            this.txtGarantias.TabIndex = 109;
            this.txtGarantias.TabStop = false;
            // 
            // txtGarantias1
            // 
            this.txtGarantias1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtGarantias1.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtGarantias1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGarantias1.Location = new System.Drawing.Point(413, 22);
            this.txtGarantias1.Name = "txtGarantias1";
            this.txtGarantias1.ReadOnly = true;
            this.txtGarantias1.Size = new System.Drawing.Size(200, 26);
            this.txtGarantias1.TabIndex = 114;
            this.txtGarantias1.TabStop = false;
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label50.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label50.ForeColor = System.Drawing.Color.Black;
            this.label50.Location = new System.Drawing.Point(352, 23);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(60, 20);
            this.label50.TabIndex = 110;
            this.label50.Text = "Club1:";
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label51.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label51.ForeColor = System.Drawing.Color.Black;
            this.label51.Location = new System.Drawing.Point(1190, 23);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(60, 20);
            this.label51.TabIndex = 113;
            this.label51.Text = "Club4:";
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label52.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label52.ForeColor = System.Drawing.Color.Black;
            this.label52.Location = new System.Drawing.Point(631, 23);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(60, 20);
            this.label52.TabIndex = 111;
            this.label52.Text = "Club2:";
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label53.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label53.ForeColor = System.Drawing.Color.Black;
            this.label53.Location = new System.Drawing.Point(910, 23);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(60, 20);
            this.label53.TabIndex = 112;
            this.label53.Text = "Club3:";
            // 
            // dsMateriales1
            // 
            this.dsMateriales1.DataSetName = "dsMateriales";
            this.dsMateriales1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dsPedidos1
            // 
            this.dsPedidos1.DataSetName = "dsPedidos";
            this.dsPedidos1.Locale = new System.Globalization.CultureInfo("en-US");
            this.dsPedidos1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sqlCmdGetVentasMatFciaPorCanal
            // 
            this.sqlCmdGetVentasMatFciaPorCanal.CommandText = "[GetVentasMatFciaPorCanal]";
            this.sqlCmdGetVentasMatFciaPorCanal.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdGetVentasMatFciaPorCanal.Connection = this.sqlConn;
            this.sqlCmdGetVentasMatFciaPorCanal.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@dFechaIni", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@dFechaFin", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@sCodNacional", System.Data.SqlDbType.VarChar, 6)});
            // 
            // sqldaGetVentasMatFciaPorCanal
            // 
            this.sqldaGetVentasMatFciaPorCanal.SelectCommand = this.sqlCmdGetVentasMatFciaPorCanal;
            this.sqldaGetVentasMatFciaPorCanal.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "VentasMatFciaPorCanal", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("Directo", "Directo"),
                        new System.Data.Common.DataColumnMapping("Transfer", "Transfer"),
                        new System.Data.Common.DataColumnMapping("Club", "Club"),
                        new System.Data.Common.DataColumnMapping("Autopedido", "Autopedido")})});
            // 
            // dsGraphs1
            // 
            this.dsGraphs1.DataSetName = "dsGraphs";
            this.dsGraphs1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sqlCmdGetImporteVentas
            // 
            this.sqlCmdGetImporteVentas.CommandText = "GetImporteVentas";
            this.sqlCmdGetImporteVentas.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdGetImporteVentas.Connection = this.sqlConn;
            this.sqlCmdGetImporteVentas.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@dFechaIni", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@dFechaFin", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@sCodNacional", System.Data.SqlDbType.VarChar, 6)});
            // 
            // sqldaGetImporteVentas
            // 
            this.sqldaGetImporteVentas.SelectCommand = this.sqlCmdGetImporteVentas;
            this.sqldaGetImporteVentas.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ImporteVentasFcia", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("cantidad", "cantidad")})});
            // 
            // sqldaGetRankingVentasMat
            // 
            this.sqldaGetRankingVentasMat.SelectCommand = this.sqlCmdGetRankingVentasMat;
            this.sqldaGetRankingVentasMat.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "RankingVentasMat", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("sIdMaterial", "sIdMaterial"),
                        new System.Data.Common.DataColumnMapping("sMaterial", "sMaterial"),
                        new System.Data.Common.DataColumnMapping("QtyDirecto", "QtyDirecto"),
                        new System.Data.Common.DataColumnMapping("QtyTransfer", "QtyTransfer"),
                        new System.Data.Common.DataColumnMapping("QtyClub", "QtyClub"),
                        new System.Data.Common.DataColumnMapping("QtyAutopedido", "QtyAutopedido"),
                        new System.Data.Common.DataColumnMapping("brutoDirecto", "brutoDirecto"),
                        new System.Data.Common.DataColumnMapping("brutoTransfer", "brutoTransfer"),
                        new System.Data.Common.DataColumnMapping("brutoClub", "brutoClub"),
                        new System.Data.Common.DataColumnMapping("brutoAutopedido", "brutoAutopedido"),
                        new System.Data.Common.DataColumnMapping("totalQty", "totalQty"),
                        new System.Data.Common.DataColumnMapping("totalBruto", "totalBruto")})});
            // 
            // sqlCmdGetRankingVentasMat
            // 
            this.sqlCmdGetRankingVentasMat.CommandText = "GetRankingVentasMat";
            this.sqlCmdGetRankingVentasMat.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdGetRankingVentasMat.Connection = this.sqlConn;
            this.sqlCmdGetRankingVentasMat.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@dFechaIni", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@dFechaFin", System.Data.SqlDbType.DateTime, 8)});
            // 
            // frmClientes
            // 
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.ClientSize = new System.Drawing.Size(1621, 787);
            this.Controls.Add(this.pnCRM_SAP_New);
            this.Controls.Add(this.pnFOnLine);
            this.Controls.Add(this.btFOnLine);
            this.Controls.Add(this.pnMayoristas);
            this.Controls.Add(this.btDatosCliente);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.ucBotoneraSecundaria1);
            this.Controls.Add(this.pnCRM_SAP);
            this.Controls.Add(this.pnAccionesMark);
            this.Controls.Add(this.btCRM);
            this.Controls.Add(this.btAccionesMark);
            this.Controls.Add(this.pnDatosCOM);
            this.Controls.Add(this.btMayoristas);
            this.Controls.Add(this.pnDatosSAP);
            this.Controls.Add(this.pnlBClientes);
            this.Controls.Add(this.pnCRM_COM);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmClientes";
            this.Text = "Gestión de Clientes";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Closed += new System.EventHandler(this.frmClientes_Closed);
            this.Load += new System.EventHandler(this.frmClientes_Load);
            this.pnlBClientes.ResumeLayout(false);
            this.pnlBClientes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsClientes1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgGeneral)).EndInit();
            this.pnDatosSAP.ResumeLayout(false);
            this.pnDatosSAP.PerformLayout();
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgCentrosSAP)).EndInit();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgContactosSAP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgAreasCOM)).EndInit();
            this.pnDatosCOM.ResumeLayout(false);
            this.pnDatosCOM.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgAficiones)).EndInit();
            this.pnAccionesMark.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgAccionesMark)).EndInit();
            this.pnCRM_COM.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgCentrosCOM)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgProductos)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgEspecialidades)).EndInit();
            this.pnCRM_SAP.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.pnMayoristas.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgMayoristas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsClientes2)).EndInit();
            this.pnFOnLine.ResumeLayout(false);
            this.pnFOnLine.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.pnCRM_SAP_New.ResumeLayout(false);
            this.gbClubs.ResumeLayout(false);
            this.gbClubs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsMateriales1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPedidos1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsGraphs1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region frmClientes_Load
		private void frmClientes_Load(object sender, System.EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;
			try
			{
                GESTCRM.Utiles.Formato_Formulario(this);
				if(this.Parent == null) this.WindowState = FormWindowState.Normal;

                //---- GSG (13/03/2019)
                //fuenteBold = Utiles.fuenteBold;
                //fuenteNoBold = Utiles.fuenteNoBold;
                fuenteBold = Utiles.fuenteBoldBig;
                fuenteNoBold = Utiles.fuenteNoBoldBig;
                


                Application.DoEvents();
                this.btCRM.Location = new Point(4, _posYButtons);
                this.btAccionesMark.Location = new Point(86, _posYButtons);
                //---- GSG (13/03/2019)
                //this.btMayoristas.Location = new Point(236, _posYButtons);
                //this.btDatosCliente.Location = new Point(386, _posYButtons);
                //this.btFOnLine.Location = new Point(530, _posYButtons); //---- GSG (04/12/2013)
                //this.BotonDatosCOM = new Point(236, _posYButtons);
                //this.BotonDatosSAP = new Point(386, _posYButtons);
                this.btMayoristas.Location = new Point(286, _posYButtons);
                this.btDatosCliente.Location = new Point(445, _posYButtons);
                this.btFOnLine.Location = new Point(599, _posYButtons); 
                this.BotonDatosCOM = new Point(286, _posYButtons);
                this.BotonDatosSAP = new Point(445, _posYButtons);


				Application.DoEvents();
				Inicializar_Combos();

                this.pnDatosCOM.Location = new Point(1, _posYPanels);
				this.pnDatosCOM.Visible=false;
                this.pnDatosSAP.Location = new Point(1, _posYPanels);
				this.pnDatosSAP.Visible=false;
                this.pnAccionesMark.Location = new Point(1, _posYPanels);
				this.pnAccionesMark.Visible=false;
                this.pnCRM_COM.Location = new Point(1, _posYPanels);
				this.pnCRM_COM.Visible=false;

                this.pnCRM_SAP.Location = new Point(1, _posYPanels);
				this.pnCRM_SAP.Visible=false;
                //---- GSG (28/01/2014)
                this.pnCRM_SAP_New.Location = new Point(1, _posYPanels);
                this.pnCRM_SAP_New.Visible = false; 
                //---- FI GSG 

                this.pnMayoristas.Location = new Point(1, _posYPanels);
				this.pnMayoristas.Visible=false;
				this.txtsIdCentro.Enabled = true;
				this.btBuscarCentro.Enabled = true;
                //---- GSG (04/12/2013)
                this.pnFOnLine.Location = new Point(1, _posYPanels);
                this.pnFOnLine.Visible = false; 



				Application.DoEvents();

				if(this.ParamI_TipoCliente!=null)
				{
					this.cboTipoCli.SelectedValue=this.ParamI_TipoCliente;
					this.cboTipoCli.Enabled=false;
					this.lblGBusquedaCli.Text = this.lblGBusquedaCli.Text+": "+this.cboTipoCli.GetItemText(this.cboTipoCli.SelectedItem);
					if(this.ParamI_TipoCliente=="C")
					{
                        this.Icon = global::GESTCRM.Properties.Resources.clientespers; //new Icon(Application.StartupPath + "\\Misc\\clientesPers.ico");
					}
					else if(this.ParamI_TipoCliente=="S")
					{
                        this.Icon = global::GESTCRM.Properties.Resources.sap_logo; //new Icon(Application.StartupPath + "\\Misc\\sap_logo.ico");
						this.txtsIdCentro.Enabled = false;
						this.btBuscarCentro.Enabled = false;
					}
					
				}
				Application.DoEvents();
				Inicializar_DataGrids();
				Application.DoEvents();
				Inicializar_Botonera();

				if(this.ParamI_TipoCliente=="C" && GESTCRM.Clases.Configuracion.iGClientesCOM!=0)
				{
					this.menuNuevo.Enabled=false;this.menuEliminar.Enabled=false;
				}
				else if(this.ParamI_TipoCliente=="S" && GESTCRM.Clases.Configuracion.iGClientesSAP!=0)
				{
					this.menuNuevo.Enabled=false;this.menuEliminar.Enabled=false;
				}
				else if(GESTCRM.Clases.Configuracion.iGClientesCOM!=0 && GESTCRM.Clases.Configuracion.iGClientesSAP!=0)
				{
					this.menuNuevo.Enabled=false;this.menuEliminar.Enabled=false;
				}

				if(GESTCRM.Clases.Configuracion.iGCentros==2)//no tiene acceso a Centros
				{
					this.dgCentrosCOM.TableStyles[0].GridColumnStyles[4].Width=0;
				}
				Application.DoEvents();
				Ocultar_Detalle();

				this.dsClientes1.ListaAccionesMarkClientes.DefaultView.RowFilter="iEstado=0";
				this.dsClientes1.ListaCentros_porCliente_SAP.DefaultView.RowFilter="iEstado=0";
				this.dsClientes1.ListaContactos_porCliente_SAP.DefaultView.RowFilter="iEstado=0";
				this.dsClientes1.ListaMayoristasClientes_SAP.DefaultView.RowFilter="iEstado=0";

                //---- GSG (29/08/2011)
                if (this.ParamI_TipoCliente == "C")
                {
                    lblTitulo.Text = "Consulta de Clientes (Personas)";
                }
                else if (this.ParamI_TipoCliente == "S")
                {
                    lblTitulo.Text = "Consulta de Clientes SAP";
                }
                else
                {
                    lblTitulo.Text = "Consulta de Clientes (General)";
                }
                //---- FI GSG
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}

			Cursor.Current = Cursors.Default;

		}
		#endregion

		#region Inicializar_Combos
		private void Inicializar_Combos()
		{
			try
			{
				this.sqldaListaDelegados.Fill(this.dsClientes1);
				DataRow fila1 = this.dsClientes1.ListaDelegados.NewRow();
				fila1["iIdDelegado"]=-1;
				fila1["sNombre"]="Todos";
				this.dsClientes1.ListaDelegados.Rows.InsertAt(fila1,1);
				this.cbDelegado.SelectedValue=GESTCRM.Clases.Configuracion.iIdDelegado;


				this.sqldaTipoCliente.Fill(this.dsClientes1);
				DataRow fila2 = this.dsClientes1.ListaTipoCliente.NewRow();
				fila2["sValor"]="T";
				fila2["sLiteral"]="Todos";
				this.dsClientes1.ListaTipoCliente.Rows.InsertAt(fila2,1);
				this.cboTipoCli.SelectedValue="T";
			
				this.sqldaListaTipoClasificacion.Fill(this.dsClientes1);
				DataRow fila3 = this.dsClientes1.ListaTipoClasificacion.NewRow();
				fila3["sValor"]="T";
				fila3["sLiteral"]="Todos";
				this.dsClientes1.ListaTipoClasificacion.Rows.InsertAt(fila3,1);
				this.cboCategoria.SelectedValue="T";

				this.sqldaListaRelacionClienteCentro.Fill(this.dsClientes1);
				this.cbRelacionConCentro.SelectedValue="-2";

				Inicializa_cboRed();
				this.cboRed.SelectedValue = GESTCRM.Clases.Configuracion.sIdRed;
				Inicializa_cboEstado();
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
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

				if(this.ParamI_TipoCliente=="C" && GESTCRM.Clases.Configuracion.iGClientesCOM!=0)
				{
					this.ucBotoneraSecundaria1.Activar_botonera(true,false,true,false,false,false);
				}
				else if(this.ParamI_TipoCliente=="S" && GESTCRM.Clases.Configuracion.iGClientesSAP!=0)
				{
					this.ucBotoneraSecundaria1.Activar_botonera(true,false,true,false,false,false);
				}
				else if((GESTCRM.Clases.Configuracion.iGClientesCOM!=0 && GESTCRM.Clases.Configuracion.iGClientesSAP!=0) || GESTCRM.Clases.Configuracion.iCreaMedicos!=0)
				{
					this.ucBotoneraSecundaria1.Activar_botonera(true,false,true,false,false,false);
				}
				else
				{
					this.ucBotoneraSecundaria1.Activar_botonera(true,true,true,true,false,false);
				}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region Inicializar_DataGrids
		private void Inicializar_DataGrids()
		{
			try
			{
				//Utiles.Formatear_DgConFilabEnviadoCEN(this.dtgGeneral,null,this.contextMenu1);
				Utiles.Formatear_DataGrid(this.dtgGeneral,null,this.contextMenu1);
				for(int i=0 ; i< this.dtgGeneral.TableStyles[0].GridColumnStyles.Count;i++)
				{
					DataGridTextBoxColumn TextCol1 = (DataGridTextBoxColumn)this.dtgGeneral.TableStyles[0].GridColumnStyles[i];
					TextCol1.TextBox.DoubleClick += new EventHandler(dtgGeneral_DoubleClick);
				}

				Utiles.Formatear_DataGrid(this,this.dgAccionesMark,"C",true);

				Utiles.Formatear_DgConColumnaBoton(this.dgCentrosCOM,"C",null,4);
				GESTCRM.DataGridButtonColumn clboton1 = (GESTCRM.DataGridButtonColumn)this.dgCentrosCOM.TableStyles[0].GridColumnStyles[4];
				clboton1.CellButtonClicked += 
					new DataGridCellButtonClickEventHandler(HandleCellbtVerCentroClick);

				Utiles.Formatear_DataGrid(this,this.dgCentrosSAP,"C",true);
				Utiles.Formatear_DataGrid(this,this.dgContactosSAP,"C",true);
				Utiles.Formatear_DataGrid(this,this.dgEspecialidades,"C",true);
				Utiles.Formatear_DataGrid(this,this.dgProductos,"C",true);
				Utiles.Formatear_DataGrid(this,this.dgMayoristas,"C",true);
				//---- GSG (07/10/2014)
                //Utiles.Formatear_DataGrid(this,this.dgAficiones,"C",true);
                Utiles.Formatear_DataGrid(this, this.dgAreasCOM, "C", true);

				
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion 

		#region Inicializa_cboRed
		private void Inicializa_cboRed()
		{
			try
			{
				this.sqldaListaRedes.Fill(this.dsClientes1);
				DataRow filaTodos = this.dsClientes1.ListaRedes.NewRow();
				filaTodos["sValor"]="T";
				filaTodos["sLiteral"]="Todos";
				this.dsClientes1.ListaRedes.Rows.InsertAt(filaTodos,0);
				}
            catch(Exception ex)
			{
				Mensajes.ShowError(ex.Message);
			}
		}
		#endregion

		#region Inicializa_cboEstado
		private void Inicializa_cboEstado()
		{
			try
			{
				this.sqldaListaEstado.Fill(this.dsClientes1);
				DataRow filaTodos = this.dsClientes1.ListaEstados.NewRow();
				filaTodos["sValor"]="2";
				filaTodos["sLiteral"]="Todos";
				this.dsClientes1.ListaEstados.Rows.InsertAt(filaTodos,0);
				cboEstado.SelectedValue = "1";
				
			}
			catch (Exception ex)
			{
				Mensajes.ShowError(ex.Message);
			}
		}
		#endregion

		#region btBuscar_Click
		private void btBuscar_Click(object sender, System.EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;
			try
			{
				string sNombre=null;
				string sApellidos1=null;
				string sApellidos2=null;
				string sIdCliente=null;
				string sIdCentro=null;
				string sCodPostal="-1";
				string sPoblacion="-1";

				if(this.txtsIdCliente.Text.ToString().Trim().Length>0) sIdCliente= this.txtsIdCliente.Text.ToString();
				if(this.txbNombre.Text.ToString().Trim().Length>0) sNombre = this.txbNombre.Text.ToString();
				if(this.txbApellidos1.Text.ToString().Trim().Length>0) sApellidos1=this.txbApellidos1.Text.ToString();
				if(this.txtsApellidos2.Text.ToString().Trim().Length>0) sApellidos2=this.txtsApellidos2.Text.ToString();
				if(this.txtsIdCentro.Text.ToString().Trim().Length>0) sIdCentro=this.txtsIdCentro.Text.ToString();
				if(this.txbCP.Text.ToString().Trim().Length>0) sCodPostal=this.txbCP.Text.ToString();
				if(this.txbBPoblacion.Text.ToString().Trim().Length>0) sPoblacion=this.txbBPoblacion.Text.ToString();

				this.dsClientes1.ListaClientes.Rows.Clear();

				this.sqldaListaClientes.SelectCommand.Parameters["@iIdDelegado"].Value=int.Parse(this.cbDelegado.SelectedValue.ToString());
				this.sqldaListaClientes.SelectCommand.Parameters["@sIdCliente"].Value=sIdCliente;
				this.sqldaListaClientes.SelectCommand.Parameters["@sTipoCliente"].Value = this.cboTipoCli.SelectedValue.ToString();
				this.sqldaListaClientes.SelectCommand.Parameters["@sNombre"].Value=sNombre;
				this.sqldaListaClientes.SelectCommand.Parameters["@sApellidos1"].Value=sApellidos1;
				this.sqldaListaClientes.SelectCommand.Parameters["@sApellidos2"].Value=sApellidos2;
				this.sqldaListaClientes.SelectCommand.Parameters["@sIdCentro"].Value=sIdCentro;
				this.sqldaListaClientes.SelectCommand.Parameters["@sIdTipoClasificacion"].Value = this.cboCategoria.SelectedValue.ToString();
				//			this.sqldaListaClientes.SelectCommand.Parameters["@iIdProvincia"].Value
				this.sqldaListaClientes.SelectCommand.Parameters["@iIdPoblacion"].Value=this.Var_iIdPoblacion;
				this.sqldaListaClientes.SelectCommand.Parameters["@sCodPostal"].Value=sCodPostal;
				this.sqldaListaClientes.SelectCommand.Parameters["@sPoblacion"].Value=sPoblacion;
				this.sqldaListaClientes.SelectCommand.Parameters["@sIdTipoRelacionCliCen"].Value=this.cbRelacionConCentro.SelectedValue.ToString();

				this.sqldaListaClientes.SelectCommand.Parameters["@sIdRed"].Value = cboRed.SelectedValue;
				this.sqldaListaClientes.SelectCommand.Parameters["@iEstado"].Value = cboEstado.SelectedValue;
				this.sqldaListaClientes.SelectCommand.Parameters["@iIdCliente"].Value = -1;
				this.sqldaListaClientes.Fill(this.dsClientes1);

				this.lblNumRegistros.Text=this.dsClientes1.ListaClientes.Rows.Count.ToString();

				if(this.dsClientes1.ListaClientes.Rows.Count>0)
				{
					this.dtgGeneral.CurrentCell = new DataGridCell(0,1);
					this.dtgGeneral.CurrentCell = new DataGridCell(0,0);
				}
				else
				{
					Ocultar_Detalle();
					this.Var_iIdCliente=-1;
                    Var_NombreCliente = ""; //---- GSG (04/12/2013)
                    Var_CodSAP = ""; //---- GSG (25/03/2014)
				}

				this.dtgGeneral.Focus();
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
			Cursor.Current = Cursors.Default;
		}
		#endregion
		
		#region btnBuscPob_Click
		private void btnBuscPob_Click(object sender, System.EventArgs e)
		{
			try
			{
				
				
				Cursor = Cursors.WaitCursor;
				Formularios.Busquedas.frmMPoblaciones myform =  new Formularios.Busquedas.frmMPoblaciones();
				Application.DoEvents();
				myform.ShowDialog(this);
				if (myform.DialogResult==System.Windows.Forms.DialogResult.OK)
				{
					this.txbBPoblacion.Text = myform.ParamO_sPoblacion;
					this.txbCP.Text = myform.ParamO_sCodPostal;
					this.Var_iIdPoblacion = myform.ParamO_iIdPoblacion;
				}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
			finally
			{
				Cursor = Cursors.Default;
			}
		}
		#endregion

		#region btNuevo_Click
		private void btNuevo_Click(object sender, System.EventArgs e)
		{	
			//No hay Altas de Cliente
			//			Acceso_Cliente("A");
			//			Mensajes.ShowInformation("No se permite crear Clientes");
			if (Clases.Configuracion.iCreaMedicos==0) AltaMedicos();

		}
		#endregion

		#region btEliminar_Click
		private void btEliminar_Click(object sender, System.EventArgs e)
		{
			//			Mensajes.ShowInformation("No se permite dar de baja Clientes");
			if (EliminarCliente()) this.btBuscar_Click(this,null); 
		}
		#endregion 

		#region btEditar_Click
		private void btEditar_Click(object sender, System.EventArgs e)
		{
			Acceso_Cliente("M");				
		}
		#endregion

		#region Acceso_Cliente
		private void Acceso_Cliente(string TipoAcceso)
		{
			try
			{
				if(this.Var_iIdCliente>=0)
				{
					string Acceso = TipoAcceso;
					bool abierto=false;
					
					//if(this.dtgGeneral[this.Var_fila,19].ToString()!="0") Acceso="C"; //Enviado a Central
					
					int iIdDelegado = Int32.Parse(this.dtgGeneral[this.Var_fila,0].ToString());
					if(iIdDelegado!=GESTCRM.Clases.Configuracion.iIdDelegado) Acceso="C";

					if(this.Var_Tipo!="S")
					{
						if(GESTCRM.Clases.Configuracion.iGClientesCOM!=0) Acceso="C";

						//						if(this.ParentForm == null) abierto=Utiles.MirarSiFormAbierto("frmMClientesCOM",this.Owner);
						if(this.ParentForm == null) abierto=Utiles.MirarSiFormAbierto("frmAltaMedicos",this.Owner);
							//						else abierto = Utiles.MirarSiFormAbierto("frmMClientesCOM",this.ParentForm);
						else abierto = Utiles.MirarSiFormAbierto("frmAltaMedicos",this.ParentForm);
						//						if (abierto && Acceso!="C")
						if (abierto)
						{
							//							DialogResult dr=Mensajes.ShowQuestion("No se puede modificar el cliente porque ya hay uno abierto. Si quiere modificar un cliente cierre el que ya está abierto. ¿Desea abrirlo en modo consulta?.");
							//							if(dr==System.Windows.Forms.DialogResult.Yes)
							//							{
							//								abierto=false;
							//								Acceso="C";
							//							}
							DialogResult dr=Mensajes.ShowQuestion("No se puede modificar el cliente porque ya hay uno abierto. ¿Desea ver el cliente abierto?.");
							if(dr==System.Windows.Forms.DialogResult.Yes)
							{
								//								GESTCRM.Utiles.ActivaFormularioAbierto("frmMClientesCOM",this.MdiParent);
								GESTCRM.Utiles.ActivaFormularioAbierto("frmAltaMedicos",this.MdiParent);
							}
						}
						if (!abierto)
						{
							//							Formularios.Mantenimientos.frmMClientesCOM myFormCOM = new Formularios.Mantenimientos.frmMClientesCOM(Acceso,this.Var_iIdCliente);				
							//							myFormCOM.MdiParent=this.ParentForm;
							//							myFormCOM.Show();
							Formularios.frmAltaMedicos  myFormCOM = new Formularios.frmAltaMedicos (Acceso,this.Var_iIdCliente);				
							myFormCOM.MdiParent=this.ParentForm;
							myFormCOM.Show();
						}
					}
					else
					{
						if(GESTCRM.Clases.Configuracion.iGClientesSAP!=0) Acceso="C";

						if(this.ParentForm == null) abierto=Utiles.MirarSiFormAbierto("frmMClientesSAP",this.Owner);
						else abierto = Utiles.MirarSiFormAbierto("frmMClientesSAP",this.ParentForm);
						//						if (abierto && Acceso!="C")
						if (abierto)
						{
							//							DialogResult dr=Mensajes.ShowQuestion("No se puede modificar el cliente porque ya hay uno abierto. Si quiere modificar un cliente cierre el que ya está abierto. ¿Desea abrirlo en modo consulta?.");
							//							if(dr==System.Windows.Forms.DialogResult.Yes)
							//							{
							//								abierto=false;
							//								Acceso="C";
							//							}
							DialogResult dr=Mensajes.ShowQuestion("No se puede modificar el cliente porque ya hay uno abierto. ¿Desea ver el cliente abierto?.");
							if(dr==System.Windows.Forms.DialogResult.Yes)
							{
								GESTCRM.Utiles.ActivaFormularioAbierto("frmMClientesSAP",this.MdiParent);
							}
						}
						if (!abierto)
						{
							Formularios.Mantenimientos.frmManClientesSAP myFormSAP = new Formularios.Mantenimientos.frmManClientesSAP(Acceso,this.Var_iIdCliente);				
							myFormSAP.MdiParent=this.ParentForm;
							myFormSAP.Show();
						}
					}
				}
				else
				{
					Mensajes.ShowInformation("Primero seleccione un Cliente.");
				}
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
				frmBCent.ParamI_iIdDelegado = int.Parse(this.cbDelegado.SelectedValue.ToString());
				frmBCent.ShowDialog(this);
				if (frmBCent.DialogResult==System.Windows.Forms.DialogResult.OK)
				{
					if(this.txtsIdCentro.Text!=frmBCent.ParamIO_sIdCentro)
					{
						this.txtsIdCentro.Text=frmBCent.ParamIO_sIdCentro;
						this.txtsCentro.Text=frmBCent.ParamIO_sDescripcion;
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
				GESTCRM.Formularios.Busquedas.frmMCentros frmBCent = new GESTCRM.Formularios.Busquedas.frmMCentros();
				frmBCent.ParamI_iIdDelegado =int.Parse(this.cbDelegado.SelectedValue.ToString());
				frmBCent.ParamIO_sIdCentro= this.txtsIdCentro.Text.ToString();
				frmBCent.ParamIO_sDescripcion="";
				frmBCent.Buscar_sCentro();
				if(this.txtsCentro.Text!=frmBCent.ParamIO_sDescripcion)
				{
					this.txtsIdCentro.Text=frmBCent.ParamIO_sIdCentro;
					this.txtsCentro.Text=frmBCent.ParamIO_sDescripcion;
				}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region menuEliminar_Click
		private void menuEliminar_Click(object sender, System.EventArgs e)
		{
			//			Mensajes.ShowInformation("No se permite dar de baja Clientes");
			if (EliminarCliente()) this.btBuscar_Click(this,null); 
		}
		#endregion

		#region menuEditar_Click
		private void menuEditar_Click(object sender, System.EventArgs e)
		{
			Acceso_Cliente("M");				
		}
		#endregion

		#region menuNuevo_Click
		private void menuNuevo_Click(object sender, System.EventArgs e)
		{
			//			Mensajes.ShowInformation("No se permite crear Clientes");
			AltaMedicos();
		}
		#endregion


		#region dtgGeneral_CurrentCellChanged
		private void dtgGeneral_CurrentCellChanged(object sender, System.EventArgs e)
		{
			try
			{
				GESTCRM.Utiles.Seleccionar_UnaFilaDataGrid(this,this.dtgGeneral,this.dtgGeneral.CurrentRowIndex);

				string sIdCliente = this.dtgGeneral[this.dtgGeneral.CurrentRowIndex,1].ToString();
				int iIdDelegado = int.Parse(this.dtgGeneral[this.dtgGeneral.CurrentRowIndex,0].ToString());
			
				this.Var_iIdCliente = int.Parse(this.dtgGeneral[this.dtgGeneral.CurrentRowIndex,2].ToString());
				this.Var_Tipo = this.dtgGeneral[this.dtgGeneral.CurrentRowIndex,7].ToString();
				this.Var_fila = -1;
				this.Var_iEstado= int.Parse(this.dtgGeneral[this.dtgGeneral.CurrentRowIndex,21].ToString());
                //---- GSG (04/12/2013)
                Var_NombreCliente = this.dtgGeneral[this.dtgGeneral.CurrentRowIndex, 3].ToString();
                //---- GSG (25/03/2014)
                Var_CodSAP = this.dtgGeneral[this.dtgGeneral.CurrentRowIndex, 1].ToString();

				#region OldCode Modificado por VCS 16/01/2008
				//				for(int i=0; i< this.dsClientes1.ListaClientes.Rows.Count;i++)
				//				{
				//					if(this.dsClientes1.ListaClientes.Rows[i]["sIdCliente"].ToString()==sIdCliente && 
				//						int.Parse(this.dsClientes1.ListaClientes.Rows[i]["iIdDelegado"].ToString())==iIdDelegado
				//						)
				//					{
				//						this.Var_fila=i;
				//						break;
				//					}
				//				}
				#endregion

				if(this.dtgGeneral.CurrentRowIndex>-1)
				{
					this.Var_fila=this.dtgGeneral.CurrentRowIndex;
					Utiles.Seleccionar_UnaFilaDataGrid(this,this.dtgGeneral,this.Var_fila);
				}
				else				
					this.Var_fila=-1;
				
				if(this.Var_fila>-1)
				{
					Activar_Botones_Cliente(this.Var_Tipo);
					if(this.btDatosCliente.Font.Bold) 
						Llenar_pnDatos(this.Var_Tipo,this.Var_fila,this.Var_iIdCliente);
					if(this.btCRM.Font.Bold && this.btCRM.Visible) 
						Llenar_pnCRM(this.Var_Tipo,this.Var_fila,this.Var_iIdCliente);
					if(this.btAccionesMark.Font.Bold && this.btAccionesMark.Visible) 
						Llenar_pnAccionesMark(this.Var_iIdCliente);
					if(this.btMayoristas.Font.Bold && this.btMayoristas.Visible) 
						Llenar_pnMayoristas(this.Var_iIdCliente);
                    //---- GSG (04/12/2013)
                    if (this.btFOnLine.Font.Bold && this.btFOnLine.Visible)
                        Llenar_pnFOnLine(this.Var_iIdCliente, this.Var_NombreCliente);
				}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region dtgGeneral_DoubleClick
		private void dtgGeneral_DoubleClick(object sender, System.EventArgs e)
		{
			Acceso_Cliente("M");				
		}
		#endregion

		#region Llenar_pnDatos_SAP
		private void Llenar_pnDatos_SAP(int fila,int iIdClienteSAP)
		{
			try
			{
				this.dsClientes2.ListaClientes.Rows.Clear();

				this.sqldaListaClientes.SelectCommand.Parameters["@iIdCliente"].Value = iIdClienteSAP;
			
				this.sqldaListaClientes.Fill(this.dsClientes2);
				
				this.txtsIdCliente_SAP.Text = this.dsClientes2.ListaClientes.Rows[0]["sIdCliente"].ToString();
				this.txtTipo_SAP.Text = this.dsClientes2.ListaClientes.Rows[0]["tTipoCliente"].ToString();
				this.txtCategoría_SAP.Text = this.dsClientes2.ListaClientes.Rows[0]["tTipoClasificacion"].ToString();
				this.txtNombre_SAP.Text = this.dsClientes2.ListaClientes.Rows[0]["tNombre"].ToString();
				this.txtDireccion_SAP.Text = this.dsClientes2.ListaClientes.Rows[0]["sDireccion_SAP"].ToString();
				this.txtCP_SAP.Text = this.dsClientes2.ListaClientes.Rows[0]["CodPostal"].ToString();
				this.txtPoblacion_SAP.Text = this.dsClientes2.ListaClientes.Rows[0]["sPoblacion"].ToString();
				this.txtProvincia_SAP.Text = this.dsClientes2.ListaClientes.Rows[0]["sProvincia"].ToString();
				this.txtTelefono_SAP.Text = this.dsClientes2.ListaClientes.Rows[0]["sTelefono"].ToString();
				this.txtTelefono2_SAP.Text = this.dsClientes2.ListaClientes.Rows[0]["sTelefono2_SAP"].ToString();
				this.txtTeles_SAP.Text = this.dsClientes2.ListaClientes.Rows[0]["sTeles_SAP"].ToString();
				this.txtTeleFax_SAP.Text = this.dsClientes2.ListaClientes.Rows[0]["sTelefax_SAP"].ToString();
				this.txtNIF_SAP.Text = this.dsClientes2.ListaClientes.Rows[0]["sNIF_SAP"].ToString();
				this.txtDatosBancarios_SAP.Text = this.dsClientes2.ListaClientes.Rows[0]["sDatosBancarios_SAP"].ToString();
				this.txtCondPago_SAP.Text = this.dsClientes2.ListaClientes.Rows[0]["sCodPago_SAP"].ToString();
				//			this.txtDescCondPago_SAP.Text = this.dsFormularios1.ListaClientes.Rows[fila]["sIdCliente"].ToString();
				this.txtGrupoCli_SAP.Text = this.dsClientes2.ListaClientes.Rows[0]["sGrupoClientes_SAP"].ToString();
				//			this.txtDescGrupoCli_SAP.Text = this.dsFormularios1.ListaClientes.Rows[fila]["sIdCliente"].ToString();
				if (this.dsClientes2.ListaClientes.Rows[0]["xPotencial_SAP"].ToString()=="0")
				{
					this.rbPotencial_SAP.Checked = false;
				}
				else
				{
					this.rbPotencial_SAP.Checked = true;
				}

				int iIdCliente = Int32.Parse(this.dsClientes2.ListaClientes.Rows[0]["iIdCliente"].ToString());
				Llenar_dgCentrosContact_SAP(iIdCliente);
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region Llenar_pnDatos_COM
		private void Llenar_pnDatos_COM(int fila,int iIdCliente)
		{
			try
			{
				this.dsClientes2.ListaClientes.Rows.Clear();

				this.sqldaListaClientes.SelectCommand.Parameters["@iIdCliente"].Value = iIdCliente;
			
				this.sqldaListaClientes.Fill(this.dsClientes2);

				this.txtsIdCliente_COM.Text = this.dsClientes2.ListaClientes.Rows[0]["sIdCliente"].ToString();
				this.txtTipo_COM.Text = this.dsClientes2.ListaClientes.Rows[0]["tTipoCliente"].ToString();
				this.txtCategoria_COM.Text = this.dsClientes2.ListaClientes.Rows[0]["tTipoClasificacion"].ToString();
				this.txtNombre_COM.Text = this.dsClientes2.ListaClientes.Rows[0]["tNombre"].ToString();
				this.txtDireccion_COM.Text = this.dsClientes2.ListaClientes.Rows[0]["sDireccion_COM"].ToString();
				this.txtCP_COM.Text = this.dsClientes2.ListaClientes.Rows[0]["CodPostal"].ToString();
				this.txtPoblacion_COM.Text = this.dsClientes2.ListaClientes.Rows[0]["sPoblacion"].ToString();
				this.txtProvincia_COM.Text = this.dsClientes2.ListaClientes.Rows[0]["sProvincia"].ToString();
				this.txtTelefono_COM.Text = this.dsClientes2.ListaClientes.Rows[0]["sTelefono"].ToString();
				this.txtTelMovil_COM.Text = this.dsClientes2.ListaClientes.Rows[0]["sTelMovil_COM"].ToString();
				this.txtFax_COM.Text = this.dsClientes2.ListaClientes.Rows[0]["sFax_COM"].ToString();
				this.txtEMail_COM.Text = this.dsClientes2.ListaClientes.Rows[0]["sEMail_COM"].ToString();
				this.txtNIF_COM.Text = this.dsClientes2.ListaClientes.Rows[0]["sNIF_COM"].ToString();
				//this.txtDatosFinancieros_COM.Text = this.dsClientes1.ListaClientes.Rows[fila]["tDatosFinacieros_COM"].ToString();
				this.txtNumColegiado_COM.Text = this.dsClientes2.ListaClientes.Rows[0]["sNumColegiado_COM"].ToString();
				this.txtTipoCliente_COM.Text = this.dsClientes2.ListaClientes.Rows[0]["tTipoCliente_COM"].ToString();
				//this.txtEstadoCli_COM.Text = this.dsClientes1.ListaClientes.Rows[fila]["tIdEstadoCliCom_COM"].ToString();
				//this.txttIdCaracteristica_COM.Text = this.dsClientes1.ListaClientes.Rows[fila]["tIdCaracteristica_COM"].ToString();
				//this.txtEstadoCivil_COM.Text = this.dsClientes1.ListaClientes.Rows[fila]["tEstadoCivil_COM"].ToString();
				//this.txtIdioma1_COM.Text = this.dsClientes1.ListaClientes.Rows[fila]["tIdioma1_COM"].ToString();
				//				this.txtIdioma2_COM.Text = this.dsClientes1.ListaClientes.Rows[fila]["tIdioma2_COM"].ToString();
				this.txtFecNacim_COM.Text = this.dsClientes2.ListaClientes.Rows[0]["dFecNacimiento_COM"].ToString();
				//				this.txtFecAniv_COM.Text = this.dsClientes1.ListaClientes.Rows[fila]["dFecAniversario_COM"].ToString();
				//this.txtPolGen_COM.Text = this.dsClientes1.ListaClientes.Rows[fila]["tIdPolGenericos_COM"].ToString();
				this.txtObservaciones_COM.Text = this.dsClientes2.ListaClientes.Rows[0]["tObservaciones_COM"].ToString();
				//				this.txtHobbies_COM.Text = this.dsClientes1.ListaClientes.Rows[fila]["tHobbies_COM"].ToString();
				//				this.txtAficActivas_COM.Text = this.dsClientes1.ListaClientes.Rows[fila]["tAficionesActivas_COM"].ToString();
				//				this.txtAficPasivas_COM.Text = this.dsClientes1.ListaClientes.Rows[fila]["tAficionesPasivas_COM"].ToString();


                //---- GSG (07/10/2014)
				//Llenar DataGrid de Aficiones
                //this.dsClientes1.ListaAficClientes_COM.Rows.Clear();

                //this.sqldaListaAficClientes_COM.SelectCommand.Parameters["@iIdCliente"].Value = iIdCliente;
                //this.sqldaListaAficClientes_COM.Fill(this.dsClientes1);

                //this.lblTotAficiones.Text = this.dsClientes1.ListaAficClientes_COM.Rows.Count.ToString();

                //Llenar DataGrid de Areas COM
                Llenar_dgCentrosContact_SAP(iIdCliente);

                //---- FI GSG
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region Llenar_pnDatos
		private void Llenar_pnDatos(string Tipo, int fila,int iIdCliente)
		{
			try
			{
				this.pnCRM_COM.Visible=false;
				this.pnCRM_SAP.Visible=false;
                this.pnCRM_SAP_New.Visible = false; //---- GSG (28/01/2014)
				this.pnAccionesMark.Visible=false;
				this.pnMayoristas.Visible = false;
                this.pnFOnLine.Visible = false; //---- GSG (04/12/2013)

				if(Tipo=="S")
				{
					this.pnDatosCOM.Visible=false;
					this.pnDatosSAP.Visible=true;
					Llenar_pnDatos_SAP(fila,iIdCliente);
				}
				else
				{
					this.pnDatosSAP.Visible=false;
					this.pnDatosCOM.Visible=true;
					Llenar_pnDatos_COM(fila,iIdCliente);
				}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region Llenar_pnCRM
		private void Llenar_pnCRM(string Tipo, int fila,int iIdCliente)
		{
			try
			{
				this.pnDatosSAP.Visible=false;
				this.pnDatosCOM.Visible=false;
				this.pnAccionesMark.Visible=false;
				this.pnMayoristas.Visible = false;
                this.pnFOnLine.Visible = false; //---- GSG (04/12/2013)

				if(Tipo=="S")
				{
					this.pnCRM_COM.Visible=false;
                    //---- GSG (28/01/2014)
                    //this.pnCRM_SAP.Visible=true;
                    //Llenar_pnCRM_SAP(iIdCliente, fila);
                    this.pnCRM_SAP_New.Visible = true;
                    Llenar_pnCRM_SAP_New(iIdCliente);
                    //---- FI GSG
					
				}
				else
				{
					this.pnCRM_SAP.Visible=false;
                    this.pnCRM_SAP_New.Visible = false; //---- GSG (28/01/2014)
					this.pnCRM_COM.Visible=true;
					Llenar_pnCRM_COM(iIdCliente,fila);
				}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region Llenar_pnCRM_SAP / Llenar_pnCRM_SAP_New
		private void Llenar_pnCRM_SAP(int iIdCliente,int fila)
		{
			try
			{
				string sIdCliente = this.dtgGeneral[fila,1].ToString();
				this.ucUltimoPedido_SAP.ultimos_pedidos_de(sIdCliente);

				this.ucRankingMatCli_SAP.RankingPorCliente(iIdCliente);

				int	   iIdDelegado = int.Parse(this.dtgGeneral[fila,0].ToString());
				string Acceso;
				if(GESTCRM.Clases.Configuracion.iGClientesSAP==1) Acceso="C";
				else Acceso="M";
				this.ucUltimasVisitas_SAP.UltimasVisitasPorCliente(iIdCliente,iIdDelegado,Acceso);
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}

        //---- GSG (28/01/2014)
        private void Llenar_pnCRM_SAP_New(int iIdCliente)
		{
            try
            {
                //---- GSG (12/03/2014)
                //Datos clubs
                string[] clubs = new string[5];

                clubs = CargarClubs();

                txtGarantias.Text = clubs[0];
                txtGarantias1.Text = clubs[1];
                txtGarantias2.Text = clubs[2];
                txtGarantias3.Text = clubs[3];
                txtGarantias4.Text = clubs[4];
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
		}

        
		#endregion

		#region Llenar_pnCRM_COM
		private void Llenar_pnCRM_COM(int iIdCliente,int fila)
		{
			try
			{
				Llenar_dgCentrosCOM(iIdCliente);
				int	   iIdDelegado = int.Parse(this.dtgGeneral[fila,0].ToString());
				string Acceso;
				if(GESTCRM.Clases.Configuracion.iGClientesCOM==1) Acceso="C";
				else Acceso="M";
				this.ucUltimasVisitas_COM.UltimasVisitasPorCliente(iIdCliente,iIdDelegado,Acceso);
				Llenar_dgEspecProd(iIdCliente);
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region Llenar_dgCentrosCOM
		private void Llenar_dgCentrosCOM(int iIdCliente)
		{
			try
			{
				this.dsClientes1.ListaCentros_porCliente_COM.Rows.Clear();

				this.sqlListaCentros_porClienteCOM.SelectCommand.Parameters["@iIdCliente"].Value=iIdCliente;

				this.sqlListaCentros_porClienteCOM.Fill(this.dsClientes1);

				this.lblTotCentrosCOM.Text = this.dsClientes1.ListaCentros_porCliente_COM.Rows.Count.ToString();
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region Llenar_dgCentrosContact_SAP
		private void Llenar_dgCentrosContact_SAP(int iIdCliente)
		{
			try
			{
                //---- GSG (31/05/2013)

                //this.dsClientes1.ListaCentros_porCliente_SAP.Rows.Clear();
                //this.dsClientes1.ListaContactos_porCliente_SAP.Rows.Clear();

                //this.sqldaListaCentros_porCliente_SAP.SelectCommand.Parameters["@iIdCliente"].Value=iIdCliente;
                //this.sqldaListaContactos_porCliente_SAP.SelectCommand.Parameters["@iIdCliente"].Value=iIdCliente;

                //this.sqldaListaCentros_porCliente_SAP.Fill(this.dsClientes1);
                //this.sqldaListaContactos_porCliente_SAP.Fill(this.dsClientes1);

                //this.lblTotCentrosSAP.Text=this.dsClientes1.ListaCentros_porCliente_SAP.Rows.Count.ToString();
                //this.lblTotContactosSAP.Text=this.dsClientes1.ListaContactos_porCliente_SAP.Rows.Count.ToString();


                this.dsClientes1.ListaAreas_porCliente_SAP.Rows.Clear();
                this.dsClientes1.ListaProgInf_porCliente_SAP.Rows.Clear();

                this.sqldaListaAreasporCliente_SAP.SelectCommand.Parameters["@iIdCliente"].Value = iIdCliente;
                this.sqldaListaProgInfCliente_SAP.SelectCommand.Parameters["@iIdCliente"].Value = iIdCliente;

                this.sqldaListaAreasporCliente_SAP.Fill(this.dsClientes1);
                this.sqldaListaProgInfCliente_SAP.Fill(this.dsClientes1);

                //---- FI GSG
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region Llenar_dgEspecProd
		private void Llenar_dgEspecProd(int iIdCliente)
		{
			try
			{
				this.dsClientes1.ListaEspecClientes_COM.Rows.Clear();
				this.dsClientes1.ListaProdClientes_COM.Rows.Clear();

				this.sqldaListaEspecClientes_COM.SelectCommand.Parameters["@iIdCliente"].Value=iIdCliente;
				this.sqldaListaProdClientes_COM.SelectCommand.Parameters["@iIdCliente"].Value=iIdCliente;

				this.sqldaListaEspecClientes_COM.Fill(this.dsClientes1);
				this.sqldaListaProdClientes_COM.Fill(this.dsClientes1);

				this.lblTotEspecialidades.Text = this.dsClientes1.ListaEspecClientes_COM.Rows.Count.ToString();
				this.lblTotProductos.Text = this.dsClientes1.ListaProdClientes_COM.Rows.Count.ToString();
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region Llenar_pnAccionesMark
		private void Llenar_pnAccionesMark(int iIdCliente)
		{
			try
			{
				this.pnDatosCOM.Visible=false;
				this.pnDatosSAP.Visible=false;
				this.pnCRM_SAP.Visible=false;
                this.pnCRM_SAP_New.Visible = false; //---- GSG (28/01/2014)

				this.pnCRM_COM.Visible=false;
				this.pnMayoristas.Visible = false;
                this.pnFOnLine.Visible = false; //---- GSG (04/12/2013)

				this.pnAccionesMark.Visible=true;

				this.dsClientes1.ListaAccionesMarkClientes.Rows.Clear();

				this.sqldaListaAccionesMark.SelectCommand.Parameters["@iIdCliente"].Value = iIdCliente;
			
				this.sqldaListaAccionesMark.Fill(this.dsClientes1);
			
				DataGridTextBoxColumn TextCol4 = (DataGridTextBoxColumn)this.dgAccionesMark.TableStyles[0].GridColumnStyles[4];
				TextCol4.TextBox.Multiline=true;
				TextCol4.TextBox.ScrollBars = ScrollBars.Vertical;
				TextCol4.TextBox.Height=32;
				this.dgAccionesMark.TableStyles[0].PreferredRowHeight=32;
          
				this.lblTotAccionesMark.Text=this.dsClientes1.ListaAccionesMarkClientes.Rows.Count.ToString();
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region Llenar_pnMayoristas
		private void Llenar_pnMayoristas(int iIdCliente)
		{
			try
			{
				this.pnDatosCOM.Visible=false;
				this.pnDatosSAP.Visible=false;
				this.pnCRM_SAP.Visible=false;
                this.pnCRM_SAP_New.Visible = false; //---- GSG (28/01/2014)
				this.pnCRM_COM.Visible=false;
                this.pnFOnLine.Visible = false; //---- GSG (04/12/2013)
				this.pnMayoristas.Visible = true;

				this.pnAccionesMark.Visible=false;

				this.dsClientes1.ListaMayoristasClientes_SAP.Rows.Clear();

				this.sqldaListaMayoristasClientes_SAP.SelectCommand.Parameters["@iIdCliente"].Value = iIdCliente;
				this.sqldaListaMayoristasClientes_SAP.Fill(this.dsClientes1);

				this.lblTotMayoristas.Text = this.dsClientes1.ListaMayoristasClientes_SAP.Rows.Count.ToString();

			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

        //---- GSG (04/12/2013)
        #region Llenar_pnFOnLine
        private void Llenar_pnFOnLine(int iIdCliente, string sNombreCliente)
        {
            try
            {
                this.pnDatosCOM.Visible = false;
                this.pnDatosSAP.Visible = false;
                this.pnCRM_SAP.Visible = false;
                this.pnCRM_SAP_New.Visible = false; //---- GSG (28/01/2014)
                this.pnCRM_COM.Visible = false;
                this.pnMayoristas.Visible = false;
                this.pnAccionesMark.Visible = false;

                this.pnFOnLine.Visible = true;

                this.dsClientes2.ListaMClientesOnLine.Rows.Clear();
                this.sqldaListaClientesOnLine.SelectCommand.Parameters["@iIdCliente"].Value = iIdCliente;
                this.sqldaListaClientesOnLine.SelectCommand.Parameters["@iEstado"].Value = 0;

                this.sqldaListaClientesOnLine.Fill(this.dsClientes2);

                this.txtFOCodCli.Text = iIdCliente.ToString();
                this.txtFONombre.Text = sNombreCliente;

                if (dsClientes2.ListaMClientesOnLine.Rows.Count > 0)
                {
                    this.txtFONombreOnLine.Text = this.dsClientes2.ListaMClientesOnLine.Rows[0]["sNombre"].ToString();
                    if (bool.Parse(this.dsClientes2.ListaMClientesOnLine.Rows[0]["bOperativa"].ToString()))
                        this.cbFOOperativa.SelectedIndex = 1;
                    else
                        this.cbFOOperativa.SelectedIndex = 0;
                    if (bool.Parse(this.dsClientes2.ListaMClientesOnLine.Rows[0]["bLinkLadival"].ToString()))
                        this.cbFOLadival.SelectedIndex = 1;
                    else this.cbFOLadival.SelectedIndex = 0;
                    this.txtFOUrl.Text = this.dsClientes2.ListaMClientesOnLine.Rows[0]["sUrl"].ToString();
                }
                else
                {
                    this.txtFONombreOnLine.Text = "";
                    this.cbFOOperativa.SelectedIndex = 0;
                    this.cbFOLadival.SelectedIndex = 0;
                    this.txtFOUrl.Text = "";
                }
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }
        #endregion
        //---- FI GSG



        #region btDatosCliente_Click
        private void btDatosCliente_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.btCRM.Font = this.fuenteNoBold;
				this.btAccionesMark.Font = this.fuenteNoBold;
				this.btMayoristas.Font = this.fuenteNoBold;
                this.btFOnLine.Font = this.fuenteNoBold; //---- GSG (04/12/2013)
			
				this.btDatosCliente.Font= this.fuenteBold;

				Llenar_pnDatos(this.Var_Tipo,this.Var_fila,this.Var_iIdCliente);
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region btCRM_Click
		private void btCRM_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.btDatosCliente.Font = this.fuenteNoBold;
				this.btAccionesMark.Font = this.fuenteNoBold;
				this.btMayoristas.Font = this.fuenteNoBold;
                this.btFOnLine.Font = this.fuenteNoBold; //---- GSG (04/12/2013)

				this.btCRM.Font = this.fuenteBold;

				Llenar_pnCRM(this.Var_Tipo,this.Var_fila,this.Var_iIdCliente);
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region btAccionesMark_Click
		private void btAccionesMark_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.btDatosCliente.Font = this.fuenteNoBold;
				this.btCRM.Font = this.fuenteNoBold;
				this.btMayoristas.Font = this.fuenteNoBold;
                this.btFOnLine.Font = this.fuenteNoBold; //---- GSG (04/12/2013)

				this.btAccionesMark.Font = this.fuenteBold;

				Llenar_pnAccionesMark(this.Var_iIdCliente);
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region btMayoristas_Click
		private void btMayoristas_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.btCRM.Font = this.fuenteNoBold;
				this.btAccionesMark.Font = this.fuenteNoBold;
				this.btMayoristas.Font = this.fuenteBold;
                this.btFOnLine.Font = this.fuenteNoBold; //---- GSG (04/12/2013)

                this.btDatosCliente.Font = this.fuenteNoBold;

				Llenar_pnMayoristas(this.Var_iIdCliente);
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

        //---- GSG (04/12/2013)
        #region btFOnLine_Click
        private void btFOnLine_Click(object sender, EventArgs e)
        {
            try
            {
                this.btCRM.Font = this.fuenteNoBold;
                this.btAccionesMark.Font = this.fuenteNoBold;
                this.btMayoristas.Font = this.fuenteNoBold;
                this.btDatosCliente.Font = this.fuenteNoBold;
                

                this.btFOnLine.Font = this.fuenteBold;

                Llenar_pnFOnLine(this.Var_iIdCliente, this.Var_NombreCliente);
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }
        #endregion
        //---- FI GSG

        #region Activar_Botones_Cliente
        private void Activar_Botones_Cliente(string TipoCliente)
		{
			try
			{
				this.btDatosCliente.Visible=true;
				if(TipoCliente=="S")
				{
					this.btDatosCliente.Visible=true;
					this.btAccionesMark.Visible=true;
					this.btCRM.Visible=true;
					this.btMayoristas.Visible=true;
                    this.btFOnLine.Visible = true; //---- GSG (04/12/2013)


                    //---- GSG (09/09/2011) Si la pantalla està redimensionada el botó marxa cap a sota
                    this.BotonDatosSAP.Y = this.btMayoristas.Location.Y;
                    //---- FI GSG

					this.btDatosCliente.Location = this.BotonDatosSAP;
					//					this.btAccionesMark.Location = this.BotonAccionesMarkSAP;
					//

                    //---- GSG (04/12/2013)
                    //if (!this.btAccionesMark.Font.Bold &&
                    //    !this.btMayoristas.Font.Bold &&
                    //    !this.btDatosCliente.Font.Bold) 
					if(!this.btAccionesMark.Font.Bold &&
						!this.btMayoristas.Font.Bold &&
						!this.btDatosCliente.Font.Bold &&
                        !this.btFOnLine.Font.Bold) 
                         this.btCRM.Font=this.fuenteBold;
					else this.btCRM.Font=this.fuenteNoBold;
				}
				else
				{ 
					this.btDatosCliente.Visible=true;
					this.btAccionesMark.Visible=true;
					this.btCRM.Visible=true;
					this.btMayoristas.Visible=false;
                    this.btFOnLine.Visible = false; //---- GSG (04/12/2013)

                    //---- GSG (09/09/2011) Si la pantalla està redimensionada el botó marxa cap a sota
                    this.BotonDatosCOM.Y = this.btMayoristas.Location.Y;
                    //---- FI GSG

					this.btDatosCliente.Location = this.BotonDatosCOM;

					//					this.btCentrosContact.Visible=false;
					//
					//					this.btMasDatosCliente.Visible=true;
					//					this.btEspecProd.Visible=true;
					//					this.btCentros.Visible=true;
					//					this.btAccionesMark.Visible=true;
					//
					//					this.btMasDatosCliente.Location = this.BotonMasDatos;
					//					this.btEspecProd.Location = this.BotonEspecProd;
					//					this.btCentros.Location = this.BotonCentros;
					//					this.btAccionesMark.Location = this.BotonAccionesMarkCOM;
					//
					if(!this.btDatosCliente.Font.Bold && 
						!this.btAccionesMark.Font.Bold) this.btCRM.Font=this.fuenteBold;
					else this.btCRM.Font=this.fuenteNoBold;

				}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region Ocultar_Detalle
		private void Ocultar_Detalle()
		{
			try
			{
				this.pnAccionesMark.Visible=false;
				this.pnDatosCOM.Visible=false;
				this.pnDatosSAP.Visible=false;
				this.pnCRM_COM.Visible=false;
				this.pnCRM_SAP.Visible=false;
                this.pnCRM_SAP_New.Visible = false; //---- GSG (28/01/2014)
				this.pnMayoristas.Visible=false;
                this.pnFOnLine.Visible = false; //---- GSG (04/12/2013)

				this.btAccionesMark.Visible=false;
				this.btCRM.Visible=false;
				this.btDatosCliente.Visible=false;
				this.btMayoristas.Visible=false;
                this.btFOnLine.Visible = false; //---- GSG (04/12/2013)
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region txbCP_Leave
		private void txbCP_Leave(object sender, System.EventArgs e)
		{
			this.Var_iIdPoblacion=-1;
		}
		#endregion

		#region txbBPoblacion_Leave
		private void txbBPoblacion_Leave(object sender, System.EventArgs e)
		{
			this.Var_iIdPoblacion=-1;
		}
		#endregion

		#region cboTipoCli_SelectedIndexChanged
		private void cboTipoCli_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				this.txtsIdCentro.Enabled = true;
				this.btBuscarCentro.Enabled = true;
				if(this.cboTipoCli.SelectedValue.ToString()=="S")
				{
					this.cbRelacionConCentro.SelectedValue="-1";
					this.cbRelacionConCentro.Enabled=false;
					this.txtsIdCentro.Enabled = false;
					this.btBuscarCentro.Enabled = false;
				}
				else
				{
					if(!this.cbRelacionConCentro.Enabled)
					{
						this.cbRelacionConCentro.Enabled=true;
						this.cbRelacionConCentro.SelectedValue="-2";
					}
				}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region dgAccionesMark_CurrentCellChanged
		private void dgAccionesMark_CurrentCellChanged(object sender, System.EventArgs e)
		{
			try
			{
				Utiles.Seleccionar_UnaFilaDataGrid(this,this.dgAccionesMark,this.dgAccionesMark.CurrentRowIndex);
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region dgEspecialidades_CurrentCellChanged
		private void dgEspecialidades_CurrentCellChanged(object sender, System.EventArgs e)
		{
			try
			{
				Utiles.Seleccionar_UnaFilaDataGrid(this,this.dgEspecialidades,this.dgEspecialidades.CurrentRowIndex);
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region dgProductos_CurrentCellChanged
		private void dgProductos_CurrentCellChanged(object sender, System.EventArgs e)
		{
			try
			{
				Utiles.Seleccionar_UnaFilaDataGrid(this,this.dgProductos,this.dgProductos.CurrentRowIndex);
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region dgCentrosCOM_CurrentCellChanged
		private void dgCentrosCOM_CurrentCellChanged(object sender, System.EventArgs e)
		{
			try
			{
				Utiles.Seleccionar_UnaFilaDataGrid(this,this.dgCentrosCOM,this.dgCentrosCOM.CurrentRowIndex);
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region dgCentrosCOM_MouseMouve
		private void dgCentrosCOM_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			dgCentrosCOM_ToolTip(this.dgCentrosCOM,e.X,e.Y);
		}

		private void dgCentrosCOM_ToolTip(DataGrid dg, int cx, int cy)
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
					this.lblToolTipBoton.Visible=true;
					int y = dg.Location.Y + cy;
					int x = dg.Location.X + dg.Width-100;
					System.Drawing.Point p = new Point(x+10,y+15);
					this.lblToolTipBoton.Location =p;
					this.lblToolTipBoton.Text = "Acceso al Centro";
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


		#region dgContactosSAP_CurrentCellChanged
		private void dgContactosSAP_CurrentCellChanged(object sender, System.EventArgs e)
		{
			try
			{
				Utiles.Seleccionar_UnaFilaDataGrid(this,this.dgContactosSAP,this.dgContactosSAP.CurrentRowIndex);
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region dgCentrosSAP_CurrentCellChanged
		private void dgCentrosSAP_CurrentCellChanged(object sender, System.EventArgs e)
		{
			try
			{
				Utiles.Seleccionar_UnaFilaDataGrid(this,this.dgCentrosSAP,this.dgCentrosSAP.CurrentRowIndex);
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region Acceso_Centros
		private void Acceso_Centros(int fila)
		{
			try
			{
				if (fila > -1)
				{
					bool abierto = false;
					if(this.ParentForm== null && this.ParentForm.Owner==null)
					{
						Mensajes.ShowInformation("No se puede abrir el formulario. Demasiadas ventanas abiertas. ");
					}
					else
					{
						if(this.ParentForm == null) abierto=Utiles.MirarSiFormAbierto("frmAltaCentros",this.Owner);
						else abierto = Utiles.MirarSiFormAbierto("frmAltaCentros",this.ParentForm);
					}

					string sIdCentro = this.dgCentrosCOM[fila,1].ToString();
					Formularios.frmAltaCentros frmCentro = new frmAltaCentros("M",Int32.Parse(sIdCentro),DateTime.Now,0);
					frmCentro.MdiParent = this.MdiParent;
					frmCentro.Show();
				}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region AltaMedicos
		private void AltaMedicos()
		{
			if (!GESTCRM.Utiles.MirarSiAbierto(this.MdiParent,"frmAltaMedicos"))
			{
				Form frmTemp=new Formularios.frmAltaMedicos("A",-1);
				frmTemp.MdiParent=this.MdiParent ;
				frmTemp.Show();
			}
			else
			{
				DialogResult dr = Mensajes.ShowQuestion("No se puede crear un Médico porque ya hay un formulario igual abierto. ¿Desea ver el Formulario abierto?");
				if(dr == DialogResult.Yes)
				{
					GESTCRM.Utiles.ActivaFormularioAbierto(this.MdiParent,"frmAltaMedicos");
				}
			}
		}
		#endregion

		// handler for a click on one of the gridcell buttons
		#region HandleCellbtVerCentroClick
		private void HandleCellbtVerCentroClick(object sender, DataGridCellButtonClickEventArgs e)
		{
			Acceso_Centros(e.RowIndex);
		}
		#endregion


		#region btSalir_Click
		private void btSalir_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
		#endregion

		#region frmClientes_Closed
		private void frmClientes_Closed(object sender, System.EventArgs e)
		{
			this.Dispose();
		}
		#endregion

		private void cbDelegado_Leave(object sender, System.EventArgs e)
		{
			if(this.cbDelegado.SelectedIndex==-1) this.cbDelegado.SelectedValue=-1;
		}

		private void cboTipoCli_Leave(object sender, System.EventArgs e)
		{
			if(this.cboTipoCli.SelectedIndex==-1) this.cboTipoCli.SelectedValue="T";
		}

		private void cboCategoria_Leave(object sender, System.EventArgs e)
		{
			if(this.cboCategoria.SelectedIndex==-1) this.cboCategoria.SelectedValue="T";
		}

		private void cbRelacionConCentro_Leave(object sender, System.EventArgs e)
		{
			if(this.cbRelacionConCentro.SelectedIndex==-1) this.cbRelacionConCentro.SelectedValue="-2";
		}


		#region Eliminar Cliente
		private bool EliminarCliente()
		{
			
			bool bRetCode = true;
			if (this.sqlConn.State == ConnectionState.Closed ) this.sqlConn.Open();
			try
			{
				// Si el Clientes esta pendiente y se ha enviado a Central, no se puede eliminar
				if (int.Parse(this.dtgGeneral[this.dtgGeneral.CurrentRowIndex,21].ToString())==1 &&
					int.Parse(this.dtgGeneral[this.dtgGeneral.CurrentRowIndex,22].ToString())==-3)
				{
					Mensajes.ShowInformation("Este Registro esta en Estado Pendiente y ha sido enviado a Central.\nDebe esperar a su aprobacion o rechazo para poder operar sobre él.");
				}
				else
					// Los Clientes SAP no se pueden eliminar
					if (this.dtgGeneral[this.dtgGeneral.CurrentRowIndex,7].ToString()=="S")
				{
					Mensajes.ShowInformation("No se Permite Eliminar Farmacias");
				}
				else
				{
					if ( this.dtgGeneral[this.dtgGeneral.CurrentRowIndex,23].ToString() == Clases.Configuracion.sIdRed)
					{
						if (Mensajes.ShowQuestion("¿Está seguro que desea eliminar el cliente "+this.dtgGeneral[this.dtgGeneral.CurrentRowIndex,3].ToString()+" de su Red Comercial ?")==DialogResult.Yes)
						{
							this.sqlCmdEliminarCLiente.Parameters["@iIdCliente"].Value= this.Var_iIdCliente;

							this.sqlCmdEliminarCLiente.ExecuteScalar();

							bRetCode = !Convert.ToBoolean(this.sqlCmdEliminarCLiente.Parameters["@RETURN_VALUE"].Value);
						}
					}
					else
					{
						Mensajes.ShowInformation("No se permite eliminar Clientes que no asignados a otra red comercial.");
					}
				}
			}
			catch (Exception Ex)
			{
				Mensajes.ShowError(Ex.Message);
				bRetCode=false;
			}
			finally
			{
				if (this.sqlConn.State == ConnectionState.Open ) this.sqlConn.Close();
			}
			return bRetCode;
		}
		#endregion


        //---- GSG (04/12/2013)
        private void btFOActualizar_Click(object sender, EventArgs e)
        {
            int ret = Actualizar_ClienteOnLine();
            if (ret == 0)
                Mensajes.ShowInformation("Se han guardado los datos correctamente.");
            else if (ret == -1)
                Mensajes.ShowError("No se han podido guardar los datos de la farmacia online.");
            else if (ret == 1)
                Mensajes.ShowError("No se peden actualizar los datos de la farmacia online porque ya ha sido enviada a central.");
        }

        private void btFOEliminar_Click(object sender, EventArgs e)
        {
            int ret = Eliminar_ClienteOnLine();
            if (ret == 0)
            {
                Mensajes.ShowInformation("Se han eliminado los datos correctamente.");

                this.txtFONombreOnLine.Text = "";
                this.cbFOOperativa.SelectedIndex = 0;
                this.cbFOLadival.SelectedIndex = 0;
                this.txtFOUrl.Text = "";
            }
            else if (ret == -1)
                Mensajes.ShowError("No se han podido eliminar los datos de la farmacia online.");
            else if (ret == 1)
                Mensajes.ShowError("No se peden borrar los datos de la farmacia online porque ya ha sido enviada a central.");
        }

        private int Actualizar_ClienteOnLine()
        {
            int iRet = -1;

            try
            {
                if (this.sqlConn.State == ConnectionState.Closed) this.sqlConn.Open();

                if (txtFONombreOnLine.Text.Trim() != "" && txtFOUrl.Text.Trim() != "")
                {
                    //Si los datos ya se han enviado a central y están activos, no se pueden modificar.
                    DataRow[] rows = this.dsClientes2.ListaMClientesOnLine.Select("iIdCliente = " + this.Var_iIdCliente);
                    bool bEnviado = false;
                    bool bActivo = true; //activo
                    if (rows.Length > 0)
                    {
                        if (bool.Parse(rows[0]["bEnviadoCEN"].ToString()))
                            bEnviado = true;
                        if (int.Parse(rows[0]["iEstado"].ToString()) == -1)
                            bEnviado = false;
                    }

                    if (bEnviado && bActivo)
                    {
                        iRet = 1;
                    }
                    else
                    {

                        sqlCmdSetClientesOnLine.Parameters["@Accion"].Value = 0; //INSERT / UPDATE
                        sqlCmdSetClientesOnLine.Parameters["@iIdCliente"].Value = this.Var_iIdCliente;
                        sqlCmdSetClientesOnLine.Parameters["@sNombre"].Value = txtFONombreOnLine.Text.Trim();
                        sqlCmdSetClientesOnLine.Parameters["@bOperativa"].Value = cbFOOperativa.SelectedIndex;
                        sqlCmdSetClientesOnLine.Parameters["@bLinkLadival"].Value = cbFOLadival.SelectedIndex;
                        sqlCmdSetClientesOnLine.Parameters["@sUrl"].Value = txtFOUrl.Text.Trim();

                        this.sqlCmdSetClientesOnLine.ExecuteNonQuery();

                        iRet = 0;
                    }
                }
                else
                {
                    Mensajes.ShowInformation("Falta introducir el nombre de la farmacia online y/o la url del cliente " + txtFONombre.Text + ".");
                }
            }
            catch (Exception Ex)
            {
                Mensajes.ShowError(Ex.Message);
            }
            finally
            {
                if (this.sqlConn.State == ConnectionState.Open) this.sqlConn.Close();
            }

            return iRet;
        }


        private int Eliminar_ClienteOnLine()
        {
            int iRet = -1;

            try
            {
                if (this.sqlConn.State == ConnectionState.Closed) this.sqlConn.Open();

                if (Mensajes.ShowQuestion("¿Está seguro que desea eliminar la farmacia OnLine del cliente " + txtFONombre.Text + "?") == DialogResult.Yes)
                {
                    //Si los datos ya se han enviado a central y están activos, no se pueden modificar.
                    DataRow[] rows = this.dsClientes2.ListaMClientesOnLine.Select("iIdCliente = " + this.Var_iIdCliente);
                    bool bEnviado = false;
                    bool bActivo = true; //activo
                    if (rows.Length > 0)
                    {
                        if (bool.Parse(rows[0]["bEnviadoCEN"].ToString()))
                            bEnviado = true;
                        if (int.Parse(rows[0]["iEstado"].ToString()) == -1)
                            bEnviado = false;
                    }

                    if (bEnviado && bActivo)
                    {
                        iRet = 1;
                    }
                    else
                    {
                        this.sqlCmdSetClientesOnLine.Parameters["@Accion"].Value = 2;
                        this.sqlCmdSetClientesOnLine.Parameters["@iIdCliente"].Value = this.Var_iIdCliente;

                        this.sqlCmdSetClientesOnLine.ExecuteNonQuery();

                        iRet = 0;
                    }
                }
            }
            catch (Exception Ex)
            {
                Mensajes.ShowError(Ex.Message);
            }
            finally
            {
                if (this.sqlConn.State == ConnectionState.Open) this.sqlConn.Close();
            }

            return iRet;
        }


        //---- GSG (12/03/2014)
        #region clubs
        private string[] CargarClubs()
        {
            return Utiles.GetClubsCliente(Var_iIdCliente);
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            if (!GESTCRM.Utiles.MirarSiAbierto(this, "frmIndicadoresIAlarmas"))
            {
                Form frmTemp = new Formularios.frmIndicadoresIAlarmas(2, Var_iIdCliente, Var_CodSAP, Var_NombreCliente); //2 = pestanya clientes
                frmTemp.Cursor = Cursors.WaitCursor;
                frmTemp.MdiParent = this.MdiParent;
                frmTemp.Show();
                frmTemp.Cursor = Cursors.Default;
            }
            else
            {
                GESTCRM.Utiles.ActivaFormularioAbierto(this, "frmIndicadoresIAlarmas");
            }
        }
    }
}
