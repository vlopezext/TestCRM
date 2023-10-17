using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Threading;

namespace GESTCRM.Formularios
{
	/// <summary>
	/// Formulario principal.
	/// </summary>
	public class frmPrincipal : System.Windows.Forms.Form
    {
        #region controles

        private System.Windows.Forms.MainMenu mnuPrincipal;
        private System.Windows.Forms.ImageList imlPrincipal;
		private System.ComponentModel.IContainer components;
		private System.Data.SqlClient.SqlDataAdapter sqlDADelegados;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		private System.Data.SqlClient.SqlConnection sqlConn;
		private System.Data.SqlClient.SqlDataAdapter sqlDATipoPedido;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		private System.Data.SqlClient.SqlDataAdapter sqlDATipoPosicion;
        private System.Data.SqlClient.SqlCommand sqlSelectCommand3;

        //---- GSG (13/03/2019)
        //private System.Windows.Forms.MenuItem mnuGestion;
        //private System.Windows.Forms.MenuItem mnuConsultas;
        //private System.Windows.Forms.MenuItem mnuHerramientas;
        //private System.Windows.Forms.MenuItem mnuVentana;
        //private System.Windows.Forms.MenuItem mnuCascada;
        //private System.Windows.Forms.MenuItem mnuHorizontal;
        //private System.Windows.Forms.MenuItem mnuVertical;

        private Font fontMenu;

        private Clases.CustomMenuItem mnuGestion;
        private Clases.CustomMenuItem mnuConsultas;
        private Clases.CustomMenuItem mnuHerramientas;
        private Clases.CustomMenuItem mnuVentana;
        private Clases.CustomMenuItem mnuCascada;
        private Clases.CustomMenuItem mnuHorizontal;
        private Clases.CustomMenuItem mnuVertical;
        //--- FI GSG
		
		private MyIconMenuItem mnuIPedidos;
		private MyIconMenuItem mnuIClientes;
		private MyIconMenuItem mnuICentros;
		private MyIconMenuItem mnuIGastos;
		private MyIconMenuItem mnuIVisitas;
		private MyIconMenuItem mnuIAtenciones;
		private MyIconMenuItem mnuISAP;
        private MyIconMenuItem mnuIEncuestas; //---- GSG (03/07/2019)
        private MyIconMenuItem mnuIPersonas;
		private MyIconMenuItem mnuISincro;
		private MyIconMenuItem mnuISincroPDA;
        private MyIconMenuItem mnuIVentas; //---- GSG (13/01/2014)
        private MyIconMenuItem mnuIAlarmasVisitas; //---- GSG (25/03/2014)
        private MyIconMenuItem mnuIStocks; //---- GSG (02/04/2014)
        private MyIconMenuItem mnuIIndicadores; //---- GSG (02/06/2014)
        //---- GSG (10/07/2013)
        private MyIconMenuItem mnuIImportarPedido;
        private MyIconMenuItem mnuIIPFarmatic;
        private MyIconMenuItem mnuIIPUnycop;
        //---- FI GSG
		private MyIconMenuItem mnuISeguridad;
		private MyIconMenuItem mnuICSeguridad;
		private MyIconMenuItem mnuIRSeguridad;
		private MyIconMenuItem mnuIcPedidos;
		private MyIconMenuItem mnuIcClientes;
		private MyIconMenuItem mnuIcGastos;
		private MyIconMenuItem mnuIcVisitas;
		private MyIconMenuItem mnuIcAtenciones;
		private MyIconMenuItem mnuIcPlanificacion;
		private MyIconMenuItem mnuIcCentros;
		private MyIconMenuItem mnuICliGen;
		private MyIconMenuItem mnuIPresupuestos;
		private MyIconMenuItem mnuIMedicos;
        //---- GSG (15/01/2014)
        private MyIconMenuItem mnuIIPedidos;
        private MyIconMenuItem mnuIICopiaPedido;
        private MyIconMenuItem mnuIIPedidoTipo;
        //---- GSG (14/03/2014)
        private MyIconMenuItem mnuIAutoPedAccMark;

		private System.Data.SqlClient.SqlDataAdapter sqlDAGastos;
		private GESTCRM.Formularios.dsFormularios dsFormularios;
        private GESTCRM.Formularios.DataSets.dsClientes dsClientes1; //---- GSG (13/03/2019)
        private System.Windows.Forms.StatusBar statBar;
		private System.Windows.Forms.Timer tmrBarra;
		private System.Windows.Forms.StatusBarPanel statPanelHora;
		private System.Windows.Forms.StatusBarPanel sbUsuario;
		private System.Windows.Forms.StatusBarPanel sbFUSCEN;
		private System.Windows.Forms.StatusBarPanel sbFUSPDA;
		private GESTCRM.Controles.ucBotoneraPrincipal ucBotoneraPrincipal1;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand4;
        private Clases.CustomMenuItem mnuAnalisis;
        private System.Data.SqlClient.SqlDataAdapter sqldaGetExisteNotaGastos;
		private System.Data.SqlClient.SqlCommand sqlCommand1;
        //---- GSG (23/01/2014)
        private System.Data.SqlClient.SqlDataAdapter sqlDARetenidos;
        private System.Data.SqlClient.SqlCommand sqlCmdRetenidos;
        //---- GSG (13/03/2019)
        private System.Data.SqlClient.SqlDataAdapter sqldaListaImpagos;
        private System.Data.SqlClient.SqlCommand sqlCmdListaImpagos;
        private System.Data.SqlClient.SqlDataAdapter sqlDALogin;
        private System.Data.SqlClient.SqlCommand sqlCmdLogin;


        private System.Windows.Forms.ToolTip toolTip1;

        //---- GSG (13/03/2019)
        //private System.Windows.Forms.MenuItem mnuAyuda;
		//private System.Windows.Forms.MenuItem mnuHelp;
		//private System.Windows.Forms.MenuItem mnuBarra;
		//private System.Windows.Forms.MenuItem mnuAcerca;
        private Clases.CustomMenuItem mnuAyuda;
        private Clases.CustomMenuItem mnuHelp;
        private Clases.CustomMenuItem mnuBarra;
        private Clases.CustomMenuItem mnuAcerca;


        private Panel pnlOpening;
        private Label label1;
        private ProgressBar progressBarOpening;
        private PictureBox pictureBox1;
        private Clases.CustomMenuItem mnuConf;

        //---- GSG (10/07/2013)
        //private const string K_FARMATIC = "FARMATIC";
        private const string K_FARMATIC = "Excel"; //---- GSG (11/03/2014)
        private const string K_UNYCOP = "UNYCOP";

        #endregion

        private volatile bool iniciando = false;
        private DataSets.dsClientes dsClientes;
        private bool shouldClose = false;

        public frmPrincipal()
		{
            InitializeComponent();



            Utiles.GetConfigConnection();
            //---- GSG (06/03/2021)
            this.sqlConn.ConnectionString = Utiles._connection.ConnectionString.ToString();



            InicializacionMenuPpal();
		
			Inicializar_ucBotoneraPrincipal();

            this.tmrBarra.Start();
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


		#region Windows Form Designer generated code
		/// <summary>
		/// Método necesario para admitir el Diseñador, no se puede modificar
		/// el contenido del método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.imlPrincipal = new System.Windows.Forms.ImageList(this.components);
            this.sqlDADelegados = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlConn = new System.Data.SqlClient.SqlConnection();
            this.sqlDATipoPedido = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
            this.sqlDATipoPosicion = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
            this.sqlDAGastos = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand4 = new System.Data.SqlClient.SqlCommand();
            this.statBar = new System.Windows.Forms.StatusBar();
            this.sbUsuario = new System.Windows.Forms.StatusBarPanel();
            this.sbFUSCEN = new System.Windows.Forms.StatusBarPanel();
            this.sbFUSPDA = new System.Windows.Forms.StatusBarPanel();
            this.statPanelHora = new System.Windows.Forms.StatusBarPanel();
            this.tmrBarra = new System.Windows.Forms.Timer(this.components);
            this.sqldaGetExisteNotaGastos = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlDARetenidos = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCmdRetenidos = new System.Data.SqlClient.SqlCommand();
            this.sqldaListaImpagos = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCmdListaImpagos = new System.Data.SqlClient.SqlCommand();
            this.sqlDALogin = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCmdLogin = new System.Data.SqlClient.SqlCommand();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pnlOpening = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBarOpening = new System.Windows.Forms.ProgressBar();
            this.ucBotoneraPrincipal1 = new GESTCRM.Controles.ucBotoneraPrincipal();
            this.dsFormularios = new GESTCRM.Formularios.dsFormularios();
            this.dsClientes1 = new GESTCRM.Formularios.DataSets.dsClientes();
            this.dsClientes = new GESTCRM.Formularios.DataSets.dsClientes();
            this.mnuPrincipal = new System.Windows.Forms.MainMenu(this.components);
            this.mnuGestion = new GESTCRM.Clases.CustomMenuItem();
            this.mnuConsultas = new GESTCRM.Clases.CustomMenuItem();
            this.mnuAnalisis = new GESTCRM.Clases.CustomMenuItem();
            this.mnuHerramientas = new GESTCRM.Clases.CustomMenuItem();
            this.mnuVentana = new GESTCRM.Clases.CustomMenuItem();
            this.mnuAyuda = new GESTCRM.Clases.CustomMenuItem();
            this.mnuHelp = new GESTCRM.Clases.CustomMenuItem();
            this.mnuAcerca = new GESTCRM.Clases.CustomMenuItem();
            this.mnuConf = new GESTCRM.Clases.CustomMenuItem();
            this.mnuBarra = new GESTCRM.Clases.CustomMenuItem();
            this.mnuCascada = new GESTCRM.Clases.CustomMenuItem();
            this.mnuHorizontal = new GESTCRM.Clases.CustomMenuItem();
            this.mnuVertical = new GESTCRM.Clases.CustomMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.sbUsuario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbFUSCEN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbFUSPDA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statPanelHora)).BeginInit();
            this.pnlOpening.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsFormularios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsClientes1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // imlPrincipal
            // 
            this.imlPrincipal.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlPrincipal.ImageStream")));
            this.imlPrincipal.TransparentColor = System.Drawing.Color.Transparent;
            this.imlPrincipal.Images.SetKeyName(0, "");
            this.imlPrincipal.Images.SetKeyName(1, "");
            this.imlPrincipal.Images.SetKeyName(2, "");
            this.imlPrincipal.Images.SetKeyName(3, "");
            this.imlPrincipal.Images.SetKeyName(4, "");
            this.imlPrincipal.Images.SetKeyName(5, "");
            this.imlPrincipal.Images.SetKeyName(6, "");
            this.imlPrincipal.Images.SetKeyName(7, "");
            this.imlPrincipal.Images.SetKeyName(8, "");
            this.imlPrincipal.Images.SetKeyName(9, "");
            this.imlPrincipal.Images.SetKeyName(10, "");
            this.imlPrincipal.Images.SetKeyName(11, "");
            this.imlPrincipal.Images.SetKeyName(12, "");
            this.imlPrincipal.Images.SetKeyName(13, "");
            this.imlPrincipal.Images.SetKeyName(14, "");
            this.imlPrincipal.Images.SetKeyName(15, "");
            this.imlPrincipal.Images.SetKeyName(16, "");
            this.imlPrincipal.Images.SetKeyName(17, "");
            this.imlPrincipal.Images.SetKeyName(18, "");
            this.imlPrincipal.Images.SetKeyName(19, "");
            this.imlPrincipal.Images.SetKeyName(20, "");
            this.imlPrincipal.Images.SetKeyName(21, "");
            this.imlPrincipal.Images.SetKeyName(22, "");
            // 
            // sqlDADelegados
            // 
            this.sqlDADelegados.SelectCommand = this.sqlSelectCommand1;
            this.sqlDADelegados.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
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
            // sqlDATipoPedido
            // 
            this.sqlDATipoPedido.SelectCommand = this.sqlSelectCommand2;
            this.sqlDATipoPedido.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaTipoPedido", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("sValor", "sValor"),
                        new System.Data.Common.DataColumnMapping("sLiteral", "sLiteral")})});
            // 
            // sqlSelectCommand2
            // 
            this.sqlSelectCommand2.CommandText = "[ListaTipoPedido]";
            this.sqlSelectCommand2.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand2.Connection = this.sqlConn;
            this.sqlSelectCommand2.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null)});
            // 
            // sqlDATipoPosicion
            // 
            this.sqlDATipoPosicion.SelectCommand = this.sqlSelectCommand3;
            this.sqlDATipoPosicion.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaTipoPosicion", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("sValor", "sValor"),
                        new System.Data.Common.DataColumnMapping("sLiteral", "sLiteral"),
                        new System.Data.Common.DataColumnMapping("bEntregado", "bEntregado"),
                        new System.Data.Common.DataColumnMapping("bGratis", "bGratis"),
                        new System.Data.Common.DataColumnMapping("sIdTipoPedido", "sIdTipoPedido")})});
            // 
            // sqlSelectCommand3
            // 
            this.sqlSelectCommand3.CommandText = "[ListaTipoPosicion]";
            this.sqlSelectCommand3.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand3.Connection = this.sqlConn;
            this.sqlSelectCommand3.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null)});
            // 
            // sqlDAGastos
            // 
            this.sqlDAGastos.SelectCommand = this.sqlSelectCommand4;
            this.sqlDAGastos.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaBuscaGastos", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iIdNota", "iIdNota"),
                        new System.Data.Common.DataColumnMapping("dFechaAprob", "dFechaAprob"),
                        new System.Data.Common.DataColumnMapping("sUsuarioAprob", "sUsuarioAprob"),
                        new System.Data.Common.DataColumnMapping("dFechaLiq", "dFechaLiq"),
                        new System.Data.Common.DataColumnMapping("tObservaciones", "tObservaciones")}),
            new System.Data.Common.DataTableMapping("Table1", "Table1", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iIdNota", "iIdNota"),
                        new System.Data.Common.DataColumnMapping("dFechaAprob", "dFechaAprob"),
                        new System.Data.Common.DataColumnMapping("sUsuarioAprob", "sUsuarioAprob"),
                        new System.Data.Common.DataColumnMapping("dFechaLiq", "dFechaLiq"),
                        new System.Data.Common.DataColumnMapping("tObservaciones", "tObservaciones")}),
            new System.Data.Common.DataTableMapping("Table2", "Table2", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iIdNota", "iIdNota"),
                        new System.Data.Common.DataColumnMapping("dFechaAprob", "dFechaAprob"),
                        new System.Data.Common.DataColumnMapping("sUsuarioAprob", "sUsuarioAprob"),
                        new System.Data.Common.DataColumnMapping("dFechaLiq", "dFechaLiq"),
                        new System.Data.Common.DataColumnMapping("tObservaciones", "tObservaciones")}),
            new System.Data.Common.DataTableMapping("Table3", "Table3", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iIdNota", "iIdNota"),
                        new System.Data.Common.DataColumnMapping("dFechaAprob", "dFechaAprob"),
                        new System.Data.Common.DataColumnMapping("sUsuarioAprob", "sUsuarioAprob"),
                        new System.Data.Common.DataColumnMapping("dFechaLiq", "dFechaLiq"),
                        new System.Data.Common.DataColumnMapping("tObservaciones", "tObservaciones")})});
            // 
            // sqlSelectCommand4
            // 
            this.sqlSelectCommand4.CommandText = "[ListaBuscaGastos]";
            this.sqlSelectCommand4.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand4.Connection = this.sqlConn;
            this.sqlSelectCommand4.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@TipoComp", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdNota", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@dFecha", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@dFechaEntre", System.Data.SqlDbType.DateTime, 8)});
            // 
            // statBar
            // 
            this.statBar.Location = new System.Drawing.Point(0, -22);
            this.statBar.Name = "statBar";
            this.statBar.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.sbUsuario,
            this.sbFUSCEN,
            this.sbFUSPDA,
            this.statPanelHora});
            this.statBar.ShowPanels = true;
            this.statBar.Size = new System.Drawing.Size(807, 22);
            this.statBar.TabIndex = 9;
            // 
            // sbUsuario
            // 
            this.sbUsuario.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            this.sbUsuario.Name = "sbUsuario";
            this.sbUsuario.ToolTipText = "Nombre del Usuario.";
            this.sbUsuario.Width = 760;
            // 
            // sbFUSCEN
            // 
            this.sbFUSCEN.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            this.sbFUSCEN.Name = "sbFUSCEN";
            this.sbFUSCEN.ToolTipText = "Fecha de Última Sincronización con Central.";
            this.sbFUSCEN.Width = 10;
            // 
            // sbFUSPDA
            // 
            this.sbFUSPDA.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            this.sbFUSPDA.Name = "sbFUSPDA";
            this.sbFUSPDA.ToolTipText = "Fecha de Última Sincronización con PDA.";
            this.sbFUSPDA.Width = 10;
            // 
            // statPanelHora
            // 
            this.statPanelHora.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            this.statPanelHora.Name = "statPanelHora";
            this.statPanelHora.ToolTipText = "Fecha y Hora local.";
            this.statPanelHora.Width = 10;
            // 
            // tmrBarra
            // 
            this.tmrBarra.Tick += new System.EventHandler(this.tmrBarra_Tick);
            // 
            // sqldaGetExisteNotaGastos
            // 
            this.sqldaGetExisteNotaGastos.SelectCommand = this.sqlCommand1;
            this.sqldaGetExisteNotaGastos.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "GetExisteNotaGastos", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iIdNota", "iIdNota"),
                        new System.Data.Common.DataColumnMapping("iIdDelegado", "iIdDelegado"),
                        new System.Data.Common.DataColumnMapping("dFecha", "dFecha"),
                        new System.Data.Common.DataColumnMapping("tFecha", "tFecha"),
                        new System.Data.Common.DataColumnMapping("bVisa", "bVisa"),
                        new System.Data.Common.DataColumnMapping("tVisa", "tVisa"),
                        new System.Data.Common.DataColumnMapping("dFechaAprob", "dFechaAprob"),
                        new System.Data.Common.DataColumnMapping("tFechaAprob", "tFechaAprob"),
                        new System.Data.Common.DataColumnMapping("sUsuarioAprob", "sUsuarioAprob"),
                        new System.Data.Common.DataColumnMapping("dFechaLiq", "dFechaLiq"),
                        new System.Data.Common.DataColumnMapping("tFechaLiq", "tFechaLiq"),
                        new System.Data.Common.DataColumnMapping("tObservaciones", "tObservaciones"),
                        new System.Data.Common.DataColumnMapping("bEnviadoCEN", "bEnviadoCEN")})});
            // 
            // sqlCommand1
            // 
            this.sqlCommand1.CommandText = "[GetExisteNotaGastos]";
            this.sqlCommand1.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCommand1.Connection = this.sqlConn;
            this.sqlCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@dFecha", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@iIdDelegado", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@bVisa", System.Data.SqlDbType.Int, 4)});
            // 
            // sqlDARetenidos
            // 
            this.sqlDARetenidos.SelectCommand = this.sqlCmdRetenidos;
            this.sqlDARetenidos.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "PedidosRetenidos", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("sIdPedido", "sIdPedido")})});
            // 
            // sqlCmdRetenidos
            // 
            this.sqlCmdRetenidos.CommandText = "[ListaPedidosRetenidos]";
            this.sqlCmdRetenidos.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdRetenidos.Connection = this.sqlConn;
            this.sqlCmdRetenidos.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdDelegado", System.Data.SqlDbType.Int, 4)});
            // 
            // sqldaListaImpagos
            // 
            this.sqldaListaImpagos.SelectCommand = this.sqlCmdListaImpagos;
            this.sqldaListaImpagos.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaImpagos", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iIdCliente", "iIdCliente"),
                        new System.Data.Common.DataColumnMapping("sIdCliente", "sIdCliente"),
                        new System.Data.Common.DataColumnMapping("sNombre", "sNombre"),
                        new System.Data.Common.DataColumnMapping("sEncComercial_SAP", "sEncComercial_SAP")})});
            // 
            // sqlCmdListaImpagos
            // 
            this.sqlCmdListaImpagos.CommandText = "ListaImpagos";
            this.sqlCmdListaImpagos.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdListaImpagos.Connection = this.sqlConn;
            this.sqlCmdListaImpagos.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdDelegado", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4)});
            // 
            // sqlDALogin
            // 
            this.sqlDALogin.SelectCommand = this.sqlCmdLogin;
            this.sqlDALogin.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Login", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("@iRet", "@iRet")})});
            // 
            // sqlCmdLogin
            // 
            this.sqlCmdLogin.CommandText = "[LoginUsuario]";
            this.sqlCmdLogin.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdLogin.Connection = this.sqlConn;
            this.sqlCmdLogin.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@sUsuarioWindows", System.Data.SqlDbType.VarChar, 50),
            new System.Data.SqlClient.SqlParameter("@iRet", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Output, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null)});
            // 
            // pnlOpening
            // 
            this.pnlOpening.Controls.Add(this.pictureBox1);
            this.pnlOpening.Controls.Add(this.label1);
            this.pnlOpening.Controls.Add(this.progressBarOpening);
            this.pnlOpening.Location = new System.Drawing.Point(78, 26);
            this.pnlOpening.Name = "pnlOpening";
            this.pnlOpening.Size = new System.Drawing.Size(541, 79);
            this.pnlOpening.TabIndex = 15;
            this.pnlOpening.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(7, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(67, 62);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(81, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(455, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Abriendo STADA GESTCRM Cliente...";
            // 
            // progressBarOpening
            // 
            this.progressBarOpening.Location = new System.Drawing.Point(82, 46);
            this.progressBarOpening.Name = "progressBarOpening";
            this.progressBarOpening.Size = new System.Drawing.Size(449, 16);
            this.progressBarOpening.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBarOpening.TabIndex = 0;
            // 
            // ucBotoneraPrincipal1
            // 
            this.ucBotoneraPrincipal1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(230)))), ((int)(((byte)(239)))));
            this.ucBotoneraPrincipal1.Dock = System.Windows.Forms.DockStyle.Left;
            this.ucBotoneraPrincipal1.ForeColor = System.Drawing.Color.Black;
            this.ucBotoneraPrincipal1.Location = new System.Drawing.Point(0, 0);
            this.ucBotoneraPrincipal1.Name = "ucBotoneraPrincipal1";
            this.ucBotoneraPrincipal1.Size = new System.Drawing.Size(1, 0);
            this.ucBotoneraPrincipal1.TabIndex = 13;
            this.ucBotoneraPrincipal1.Visible = false;
            // 
            // dsFormularios
            // 
            this.dsFormularios.DataSetName = "dsFormularios";
            this.dsFormularios.Locale = new System.Globalization.CultureInfo("es-ES");
            this.dsFormularios.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dsClientes1
            // 
            this.dsClientes1.DataSetName = "dsClientes1";
            this.dsClientes1.Locale = new System.Globalization.CultureInfo("es-ES");
            this.dsClientes1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dsClientes
            // 
            this.dsClientes.DataSetName = "dsClientes1";
            this.dsClientes.Locale = new System.Globalization.CultureInfo("en-US");
            this.dsClientes.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // mnuPrincipal
            // 
            this.mnuPrincipal.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuGestion,
            this.mnuConsultas,
            this.mnuAnalisis,
            this.mnuHerramientas,
            this.mnuVentana,
            this.mnuAyuda});
            // 
            // mnuGestion
            // 
            this.mnuGestion.Font = new System.Drawing.Font("Verdana", 12F);
            this.mnuGestion.Index = 0;
            this.mnuGestion.OwnerDraw = true;
            this.mnuGestion.Shortcut = System.Windows.Forms.Shortcut.CtrlF1;
            this.mnuGestion.Text = "Nuevo";
            // 
            // mnuConsultas
            // 
            this.mnuConsultas.Font = new System.Drawing.Font("Verdana", 12F);
            this.mnuConsultas.Index = 1;
            this.mnuConsultas.OwnerDraw = true;
            this.mnuConsultas.Shortcut = System.Windows.Forms.Shortcut.CtrlF2;
            this.mnuConsultas.Text = "Consultas";
            // 
            // mnuAnalisis
            // 
            this.mnuAnalisis.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuAnalisis.Index = 2;
            this.mnuAnalisis.OwnerDraw = true;
            this.mnuAnalisis.Shortcut = System.Windows.Forms.Shortcut.CtrlF3;
            this.mnuAnalisis.Text = "Análisis";
            this.mnuAnalisis.Visible = false;
            // 
            // mnuHerramientas
            // 
            this.mnuHerramientas.Font = new System.Drawing.Font("Verdana", 12F);
            this.mnuHerramientas.Index = 3;
            this.mnuHerramientas.OwnerDraw = true;
            this.mnuHerramientas.Shortcut = System.Windows.Forms.Shortcut.CtrlF4;
            this.mnuHerramientas.Text = "Herramientas";
            // 
            // mnuVentana
            // 
            this.mnuVentana.Font = new System.Drawing.Font("Verdana", 12F);
            this.mnuVentana.Index = 4;
            this.mnuVentana.MdiList = true;
            this.mnuVentana.OwnerDraw = true;
            this.mnuVentana.Shortcut = System.Windows.Forms.Shortcut.CtrlF5;
            this.mnuVentana.Text = "Ventana";
            // 
            // mnuAyuda
            // 
            this.mnuAyuda.Font = new System.Drawing.Font("Verdana", 12F);
            this.mnuAyuda.Index = 5;
            this.mnuAyuda.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuHelp,
            this.mnuAcerca,
            this.mnuConf});
            this.mnuAyuda.OwnerDraw = true;
            this.mnuAyuda.Text = "Ayuda";
            // 
            // mnuHelp
            // 
            this.mnuHelp.Font = new System.Drawing.Font("Verdana", 12F);
            this.mnuHelp.Index = 0;
            this.mnuHelp.OwnerDraw = true;
            this.mnuHelp.Text = "Ayuda";
            this.mnuHelp.Visible = false;
            // 
            // mnuAcerca
            // 
            this.mnuAcerca.Font = new System.Drawing.Font("Verdana", 12F);
            this.mnuAcerca.Index = 1;
            this.mnuAcerca.OwnerDraw = true;
            this.mnuAcerca.Text = "Acerca de...";
            this.mnuAcerca.Click += new System.EventHandler(this.mnuAcerca_Click);
            // 
            // mnuConf
            // 
            this.mnuConf.Font = new System.Drawing.Font("Verdana", 12F);
            this.mnuConf.Index = 2;
            this.mnuConf.OwnerDraw = true;
            this.mnuConf.Shortcut = System.Windows.Forms.Shortcut.CtrlShiftF12;
            this.mnuConf.Text = "Configuración";
            this.mnuConf.Visible = false;
            this.mnuConf.Click += new System.EventHandler(this.mnuConf_Click);
            // 
            // mnuBarra
            // 
            this.mnuBarra.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuBarra.Index = -1;
            this.mnuBarra.OwnerDraw = true;
            this.mnuBarra.Text = "-";
            // 
            // mnuCascada
            // 
            this.mnuCascada.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuCascada.Index = -1;
            this.mnuCascada.OwnerDraw = true;
            this.mnuCascada.Text = "";
            // 
            // mnuHorizontal
            // 
            this.mnuHorizontal.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuHorizontal.Index = -1;
            this.mnuHorizontal.OwnerDraw = true;
            this.mnuHorizontal.Text = "";
            // 
            // mnuVertical
            // 
            this.mnuVertical.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuVertical.Index = -1;
            this.mnuVertical.OwnerDraw = true;
            this.mnuVertical.Text = "";
            // 
            // frmPrincipal
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(807, 0);
            this.Controls.Add(this.pnlOpening);
            this.Controls.Add(this.ucBotoneraPrincipal1);
            this.Controls.Add(this.statBar);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Menu = this.mnuPrincipal;
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "STADA GESTCRM";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmPrincipal_Closing);
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sbUsuario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbFUSCEN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbFUSPDA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statPanelHora)).EndInit();
            this.pnlOpening.ResumeLayout(false);
            this.pnlOpening.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsFormularios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsClientes1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsClientes)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region Inicializar_ucBotoneraPrincipal
		private void Inicializar_ucBotoneraPrincipal()
		{
			this.ucBotoneraPrincipal1.btPedidos.Click += new EventHandler(mnuIcPedidos_Click);
			this.ucBotoneraPrincipal1.btClientes.Click += new EventHandler(mnuIcClientes_Click);
			this.ucBotoneraPrincipal1.btCliCOM.Click += new EventHandler(mnuIPersonas_Click);
			this.ucBotoneraPrincipal1.btCliSAP.Click += new EventHandler(mnuISAP_Click);
            this.ucBotoneraPrincipal1.btCliSAP.Click += new EventHandler(mnuIEncuestas_Click); //---- GSG (03/07/2019)
			this.ucBotoneraPrincipal1.btGastos.Click += new EventHandler(mnuIcGastos_Click);
			this.ucBotoneraPrincipal1.btReporting.Click += new EventHandler(mnuIcVisitas_Click);
			this.ucBotoneraPrincipal1.btPlanificacion.Click += new EventHandler(mnuIcPlanificacion_Click);
			this.ucBotoneraPrincipal1.btCentros.Click += new EventHandler(mnuIcCentros_Click);
			this.ucBotoneraPrincipal1.btListaAtenciones.Click += new EventHandler(mnuIcAtenciones_Click);
			
			this.ucBotoneraPrincipal1.btNAtenciones.Click += new EventHandler(mnuIAtenciones_Click);
			this.ucBotoneraPrincipal1.btNPedidos.Click += new EventHandler(mnuIPedidos_Click);
			this.ucBotoneraPrincipal1.btNGastos.Click += new EventHandler(mnuIGastos_Click);
			this.ucBotoneraPrincipal1.btNReporting.Click += new EventHandler(mnuIVisitas_Click);
			
			this.ucBotoneraPrincipal1.btnPresupuestos.Click += new EventHandler(mnuIPresupuestos_Click);  
			this.ucBotoneraPrincipal1.btCrearMedico.Click += new EventHandler(mnuIMedicos_Click);  
			this.ucBotoneraPrincipal1.btCrearCentro.Click += new EventHandler(mnuICentros_Click);  

			this.ucBotoneraPrincipal1.btSalir.Click += new EventHandler(mnuSalir_Click);
		}
		#endregion

		#region InicializacionMenuPpal
		private void InicializacionMenuPpal()
		{
            string sAvisoVersion = " - " + System.Configuration.ConfigurationManager.AppSettings["AvisoVersion"].ToString(); //---- GSG (14/02/2014)

            Icon icoPedidos = global::GESTCRM.Properties.Resources.pedidos; //new Icon(Application.StartupPath + "\\Misc\\pedidos.ico");			
            Icon icoClientes = global::GESTCRM.Properties.Resources.clientes; //new Icon(Application.StartupPath + "\\Misc\\clientes.ico");
            Icon icoGastos = global::GESTCRM.Properties.Resources.gastos; //new Icon(Application.StartupPath + "\\Misc\\gastos.ico");
            Icon icoVisitas = global::GESTCRM.Properties.Resources.report; //new Icon(Application.StartupPath + "\\Misc\\report.ico");
            Icon icoAtenciones = global::GESTCRM.Properties.Resources.atencion; //new Icon(Application.StartupPath + "\\Misc\\atencion.ico");			
            Icon icoCentros = global::GESTCRM.Properties.Resources.scs; //new Icon(Application.StartupPath + "\\Misc\\scs.ico");
            Icon icoPlanif = global::GESTCRM.Properties.Resources.planif; //new Icon(Application.StartupPath + "\\Misc\\planif.ico");
            Icon icoSincro = global::GESTCRM.Properties.Resources.sincro; //new Icon(Application.StartupPath + "\\Misc\\sincro.ico");
            Icon icoCliSAP = global::GESTCRM.Properties.Resources.sap_logo; //new Icon(Application.StartupPath + "\\Misc\\sap_logo.ico");
            Icon icoCliPers = global::GESTCRM.Properties.Resources.clientespers; //new Icon(Application.StartupPath + "\\Misc\\clientesPers.ico");
            Icon icoCliGen = global::GESTCRM.Properties.Resources.clientes; //new Icon(Application.StartupPath + "\\Misc\\clientes.ico");
            Icon icoImprimir = global::GESTCRM.Properties.Resources.Imprimir; //new Icon(Application.StartupPath + "\\Misc\\imprimir.ico");
            Icon icoPresup = global::GESTCRM.Properties.Resources.presupuestos; //new Icon(Application.StartupPath + "\\Misc\\Presupuestos.ico");
            Icon icoIVentas = global::GESTCRM.Properties.Resources.iVentas; //---- GSG (13/01/2014)
            Icon icoIAlarmas = global::GESTCRM.Properties.Resources.alarma; //---- GSG (25/03/2014)
            Icon icoAutoPedAccMark = global::GESTCRM.Properties.Resources.accMark; //---- GSG (14/03/2014)
            Icon icoIStock = global::GESTCRM.Properties.Resources.stock; //---- GSG (02/04/2014)
            Icon icoIIGlobales = global::GESTCRM.Properties.Resources.iIGlobales; //---- GSG (06/06/2014)
            Icon icoSurvey = global::GESTCRM.Properties.Resources.Surveys24x24; //---- GSG (03/07/2019)

            mnuIPedidos = new MyIconMenuItem("&Pedidos",null,Shortcut.CtrlP,icoPedidos);			
			mnuIClientes = new MyIconMenuItem("&Clientes",null,Shortcut.None,icoClientes);
			mnuICentros = new MyIconMenuItem("Cen&tros",null,Shortcut.None,icoCentros);
			mnuIGastos = new MyIconMenuItem("&Gastos",null,Shortcut.CtrlG,icoGastos);
			mnuIVisitas = new MyIconMenuItem("&Visitas",null,Shortcut.CtrlV,icoVisitas);
			mnuIAtenciones = new MyIconMenuItem("&Atenciones",null,Shortcut.CtrlA,icoAtenciones);
			mnuIPresupuestos = new MyIconMenuItem("Asignación &Presupuestos",null,Shortcut.CtrlP,icoPresup);
			mnuIMedicos = new MyIconMenuItem("&Médicos",null,Shortcut.None,icoCliPers);

 
			
			mnuISAP = new MyIconMenuItem("&SAP",null,Shortcut.F7,icoCliSAP);
            mnuIEncuestas = new MyIconMenuItem("&Encuestas", null, Shortcut.None, icoSurvey); //---- GSG (03/07/2019)

            mnuIPersonas = new MyIconMenuItem("&Personas",null,Shortcut.F8,icoCliPers);
			mnuICliGen = new MyIconMenuItem("&General",null,Shortcut.F6,icoCliGen);
            //mnuIVentas = new MyIconMenuItem("&Informe Ventas Farmacia" + sAvisoVersion, null, Shortcut.None, icoIVentas);	 //---- GSG (13/01/2014)
            mnuIVentas = new MyIconMenuItem("&Indicadores y Alarmas" + sAvisoVersion, null, Shortcut.None, icoIVentas);	 //---- GSG (25/03/2014)
            mnuIAlarmasVisitas = new MyIconMenuItem("A&larmas Visitas" + sAvisoVersion, null, Shortcut.None, icoIAlarmas);	 //---- GSG (25/03/2014)
            mnuIStocks = new MyIconMenuItem("Stoc&ks" + sAvisoVersion, null, Shortcut.None, icoIStock); ; //---- GSG (02/04/2014)
            mnuIIndicadores = new MyIconMenuItem("I&ndicadores Globales" + sAvisoVersion, null, Shortcut.None, icoIIGlobales);	 //---- GSG (02/06/2014)
            
            mnuISincro = new MyIconMenuItem("&Sincron. Central",null,Shortcut.CtrlZ,icoSincro);
			mnuISincroPDA = new MyIconMenuItem("&Sincron. PDA",null,Shortcut.None,icoSincro);
            //---- GSG (10/07/2013)
            mnuIImportarPedido = new MyIconMenuItem("Importar Pedido", null, Shortcut.None, icoPedidos); 
            //mnuIIPFarmatic = new MyIconMenuItem("Farmatic", null, Shortcut.None, icoPedidos);
            mnuIIPFarmatic = new MyIconMenuItem("Importación Excel", null, Shortcut.None, icoPedidos); //---- GSG (11/03/2014)
            mnuIIPUnycop = new MyIconMenuItem("Unycop", null, Shortcut.None, icoPedidos); 
            //---- FI GSG
			mnuISeguridad = new MyIconMenuItem("Copias de Seguridad",null,Shortcut.CtrlB,icoCliPers);
			mnuICSeguridad = new MyIconMenuItem("Realizar Copia",null,Shortcut.CtrlS,icoCliPers);
			mnuIRSeguridad = new MyIconMenuItem("Recuperar Copia",null,Shortcut.CtrlR,icoCliPers);
            mnuIRSeguridad.Enabled = false;

			mnuIcPedidos = new MyIconMenuItem("&Pedidos",null,Shortcut.F3,icoPedidos);
			mnuIcClientes = new MyIconMenuItem("&Clientes",null,Shortcut.F11,icoClientes);
			mnuIcGastos = new MyIconMenuItem("&Gastos",null,Shortcut.F4,icoGastos);
			mnuIcVisitas = new MyIconMenuItem("&Visitas",null,Shortcut.F2,icoVisitas);
			mnuIcAtenciones = new MyIconMenuItem("&Atenciones",null,Shortcut.F5,icoAtenciones);
			mnuIcPlanificacion = new MyIconMenuItem("&Planificacion",null,Shortcut.F9,icoPlanif);
			mnuIcCentros = new MyIconMenuItem("&Centros",null,Shortcut.F10,icoCentros);

            //---- GSG (15/01/2014)

            mnuIIPedidos = new MyIconMenuItem("Crear Pedido", null, Shortcut.None, icoPedidos);
            mnuIICopiaPedido = new MyIconMenuItem("Copiar Pedido" + sAvisoVersion, null, Shortcut.None, icoPedidos);
            mnuIIPedidoTipo = new MyIconMenuItem("Propuesta Pedido" + sAvisoVersion, null, Shortcut.None, icoPedidos);
            //---- GSG (14/03/2014)
            mnuIAutoPedAccMark = new MyIconMenuItem("Acciones Márketing Autopedido", null, Shortcut.None, icoAutoPedAccMark);

//			foreach(string fAn in System.IO.Directory.GetFiles(Application.StartupPath + @"\Analisis\","*.XLS"))
//			{
//				MyIconMenuItem mnuIcAnalisis = new MyIconMenuItem(System.IO.Path.GetFileNameWithoutExtension(fAn),null,Shortcut.CtrlL,icoImprimir);
//				this.mnuAnalisis.MenuItems.Add(mnuIcAnalisis);
//				mnuIcAnalisis.Click += new System.EventHandler(this.mnuAnalisis_Click);
//			}
			
			// Eventos del menú
            //---- GSG (15/01/2014)
            //this.mnuIPedidos.Click += new System.EventHandler(mnuIPedidos_Click);						
            this.mnuIIPedidos.Click += new System.EventHandler(mnuIPedidos_Click);
            this.mnuIICopiaPedido.Click += new System.EventHandler(mnuIICopiaPedido_Click);
            this.mnuIIPedidoTipo.Click += new System.EventHandler(mnuIIPedidoTipo_Click);	
            //---- FI GSG
            
            this.mnuIGastos.Click += new System.EventHandler(mnuIGastos_Click);
			this.mnuIVisitas.Click += new System.EventHandler(mnuIVisitas_Click);			
			this.mnuIAtenciones.Click += new System.EventHandler(mnuIAtenciones_Click);
			this.mnuISincro.Click += new System.EventHandler(mnuISincro_Click);
			this.mnuISincroPDA.Click += new System.EventHandler(mnuISincroPDA_Click);
            //---- GSG (10/07/2013)
            this.mnuIIPFarmatic.Click += new System.EventHandler(mnuIImportarPedidoFarmatic_Click);
            this.mnuIIPUnycop.Click += new System.EventHandler(mnuIImportarPedidoUnycop_Click); 
            //---- FI GSG
			this.mnuICSeguridad.Click += new System.EventHandler(mnuICSeguridad_Click);
			//this.mnuIRSeguridad.Click += new System.EventHandler(mnuIRSeguridad_Click);
			this.mnuIcPedidos.Click += new System.EventHandler(mnuIcPedidos_Click);
			this.mnuIcClientes.Click += new System.EventHandler(mnuIcClientes_Click);
			this.mnuIcGastos.Click += new System.EventHandler(mnuIcGastos_Click);
			this.mnuIcVisitas.Click += new System.EventHandler(mnuIcVisitas_Click);			
			this.mnuIcAtenciones.Click += new System.EventHandler(mnuIcAtenciones_Click);
			this.mnuIcPlanificacion.Click += new System.EventHandler(mnuIcPlanificacion_Click);
			this.mnuIcCentros.Click += new System.EventHandler(mnuIcCentros_Click);
			this.mnuISAP.Click += new System.EventHandler(mnuISAP_Click);
            this.mnuIEncuestas.Click += new System.EventHandler(mnuIEncuestas_Click); //---- GSG (03/07/2019)
            this.mnuIPersonas.Click += new System.EventHandler(mnuIPersonas_Click);			
			this.mnuICliGen.Click += new System.EventHandler(mnuIcClientes_Click);

			this.mnuIMedicos.Click += new System.EventHandler(mnuIMedicos_Click);
			this.mnuIPresupuestos.Click += new System.EventHandler(mnuIPresupuestos_Click);
			this.mnuICentros.Click += new System.EventHandler(mnuICentros_Click);

            this.mnuIVentas.Click += new System.EventHandler(mnuIVentas_Click); //---- GSG (13/01/2014)
            this.mnuIAlarmasVisitas.Click += new System.EventHandler(mnuIAlarmasVisitas_Click); //---- GSG (25/03/2014)
            
            this.mnuIAutoPedAccMark.Click += new System.EventHandler(mnuIAutoPedAccMark_Click); //---- GSG (14/03/2014)

            this.mnuIStocks.Click += new System.EventHandler(mnuIStocks_Click); //---- GSG (02/04/2014)
            this.mnuIIndicadores.Click += new System.EventHandler(mnuIIndicadores_Click); //---- GSG (02/06/2014)
            // 
			// mnuGestion
			//
			this.mnuGestion.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.mnuIVisitas,
																					   this.mnuIPedidos,
																					   this.mnuIGastos,
																					   this.mnuIAtenciones,
																					   //this.mnuIMedicos, //---- GSG (13/03/2019)
																					   //this.mnuICentros,  //---- GSG (13/03/2019)
																					   //this.mnuIPresupuestos, //---- GSG (13/03/2019)
                                                                                       this.mnuIAutoPedAccMark}); //---- GSG (14/03/2014)
            //---- GSG (15/01/2014)
            this.mnuIPedidos.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.mnuIIPedidos,
																						 this.mnuIICopiaPedido,																						
																						 this.mnuIIPedidoTipo});
            //---- FI bGSG
			
			//
			//Consultas 
			//
			
			this.mnuConsultas.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.mnuIcVisitas,
																						 this.mnuIcPedidos,
																						 this.mnuIcGastos,
																						 this.mnuIcAtenciones,
																						 this.mnuIClientes,
																						 this.mnuIcPlanificacion,
																						 //this.mnuIcCentros, //---- GSG (13/03/2019)
                                                                                         this.mnuIVentas, //---- GSG (13/01/2014)
                                                                                         this.mnuIAlarmasVisitas, //---- GSG (25/03/2014)
                                                                                         this.mnuIStocks, //---- GSG (02/043/2014)
                                                                                         this.mnuIIndicadores}); //---- GSG (02/06/2014)

			this.mnuIClientes.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.mnuISAP,
                //this.mnuIPersonas, //---- GSG (13/03/2019)																						
                //this.mnuICliGen //---- GSG (13/03/2019)
                this.mnuIEncuestas //---- GSG (03/07/2019)
                });
			//
			//Herramientas
			//
			this.mnuHerramientas.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																							this.mnuISincro,
                                                                                            //---- GSG (10/07/2013)
																							//this.mnuISincroPDA,
                                                                                            this.mnuIImportarPedido,
																							this.mnuISeguridad});
			//
			//Copias de Seguridad
			//
			this.mnuISeguridad.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																							this.mnuICSeguridad,
																							this.mnuIRSeguridad});

            //---- GSG (10/07/2013)
            //Importación de Pedidos 
            //
            this.mnuIImportarPedido.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																							this.mnuIIPFarmatic,
                //this.mnuIIPUnycop //---- GSG (13/03/2019)
            });

		}

		#endregion


		#region frmPrincipal_Load

		private void frmPrincipal_Load(object sender, System.EventArgs e)
        {
            //RH
            this.Enabled = false;
            pnlOpening.Left = this.Width / 2 - pnlOpening.Width / 2 - 20;
            pnlOpening.Top = this.Height / 2 - pnlOpening.Height / 2 - 100;
            pnlOpening.Visible = true;

            iniciando = true;
            Thread t = new Thread(new ThreadStart(ThreadProc));
            t.Start();

            while (iniciando)
            {
                Application.DoEvents();
                Thread.Sleep(100);
            }
            
            t.Join();

            //Si el proceso del thread paralelo determinó que se debe cerrar la aplicación
            if (shouldClose)
            {
                CloseForm();
                return;
            }


            //---- GSG (13/03/2019)

            int iLogin = Login(Environment.UserName);
            //using (frmLogin Login = new frmLogin())



#if DEBUG            
            // VLP Debug Login
            iLogin = 1;
#endif


            if (iLogin >= 0)
            {
                pnlOpening.Visible = false;

                //Login.ShowDialog();

                //if (Login.DialogResult == DialogResult.OK)
                //{
                    Cursor = Cursors.WaitCursor;

                    this.sqlDADelegados.Fill(GESTCRM.Datos.dsForms);
                    this.sqlDATipoPedido.Fill(GESTCRM.Datos.dsForms);
                    this.sqlDATipoPosicion.Fill(GESTCRM.Datos.dsForms);

                    this.sbUsuario.Text = GESTCRM.Clases.Configuracion.sNombreDelegado;
                    this.sbUsuario.Text += " Usuario CRM: " + GESTCRM.Clases.Configuracion.sUsuario;

                    if (GESTCRM.Clases.Configuracion.sIdDelegado_SAP.Trim() != "")
                    {
                        this.sbUsuario.Text += " Código SAP: " + GESTCRM.Clases.Configuracion.sIdDelegado_SAP.Trim();
                    }

                    //---- GSG (23/08/2016)
                    //this.sbFUSPDA.Text = "F.U.S. PDA: " + GESTCRM.Clases.Configuracion.dFUSPDA.ToShortDateString();                    
                    // VLP (12/04/2023) comentado. Ahora se utiliza sbFUSPDA para rehorganizar los indices de las tablas de la DB.
                    //this.sbFUSPDA.Text = "Red de Ventas: " + System.Configuration.ConfigurationManager.AppSettings["RedVentas"].ToString(); 


                    this.sbFUSCEN.Text = "F.U.S. Central: " + GESTCRM.Clases.Configuracion.dFUSCEN.ToShortDateString();

                    Inicializar_Accesos();

                    //---- GSG (28/03/2020) Copia en OneDrive de la BD 
                    ////////////////////////////////////7CSeguridadAutoDrive(); DE MOMENT HO COMENTO

                    //---- GSG (02/02/2021) Copia en Backup y escritorio, de la BD
                    CSeguridadAutomatica();


                    //---- GSG (23/01/2014)
                    // Mirar si el delegado tiene algún pedido retenido
                    int delegado = Clases.Configuracion.iIdDelegado;
                    GESTCRM.Datos.dsForms.ListaPedidosRetenidos.Clear();

                    sqlDARetenidos.SelectCommand.Parameters["@iIdDelegado"].Value = delegado;

                    this.sqlDARetenidos.Fill(GESTCRM.Datos.dsForms.ListaPedidosRetenidos);

                    int num = GESTCRM.Datos.dsForms.ListaPedidosRetenidos.Rows.Count;
                                        //---- GSG (13/03/2019)
                    //if (num > 0)
                    //{
                    //    Mensajes.ShowInformation("Hay " + num.ToString() + " pedidos retenidos.");
                    //}

                    string mensaje = "";
                    int numTotal = num;
                    if (num > 0)
                        mensaje += "Hay " + num.ToString() + " pedidos retenidos.";

                    // mostrar impagos
                    this.dsClientes1.ListaImpagos.Clear();
                    this.sqldaListaImpagos.SelectCommand.Parameters["@iIdDelegado"].Value = Clases.Configuracion.iIdDelegado;
                    this.sqldaListaImpagos.SelectCommand.Parameters["@iIdCliente"].Value = -1;

                    this.sqldaListaImpagos.Fill(this.dsClientes);

                    num = this.dsClientes.ListaImpagos.Rows.Count;

                    if (num > 0)
                    {
                        numTotal += num;
                        mensaje += "\r\rHay " + num.ToString() + " clientes con impagos. Vaya a Indicadores Globales para ver la información en detalle. \r";
                        //for (int i = 0; i < num; i++)
                        //{
                        //    mensaje += this.dsClientes.ListaImpagos.Rows[i]["sIdCliente"].ToString();
                        //    mensaje += " - ";
                        //    mensaje += this.dsClientes.ListaImpagos.Rows[i]["sNombre"].ToString();
                        //    mensaje += "\r";
                        //}
                    }

                    if (numTotal > 0)
                        Mensajes.ShowInformation(mensaje);




                    //Se abre automáticamente la planificación si tiene acceso a Reports
                    if (GESTCRM.Clases.Configuracion.iGVisitas != 2)
                    {
                        Form frmTemp = new Formularios.frmConsultaVisit();
                        frmTemp.MdiParent = this;
                        frmTemp.Show();
                    }

                    this.Enabled = true;
                    Cursor = Cursors.Default;
                //}
                //else
                //    CloseForm();
            }
            else //---- GSG (13/03/2019)
                CloseForm();

        }

        private void CloseForm()
        {
            Closing -= new System.ComponentModel.CancelEventHandler(this.frmPrincipal_Closing);
            Close();
        }

        public void ThreadProc()
        {
            ////---- GSG (21/01/2013)
            ////using (SqlConnection sqlConn = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["sConn"].ToString()))
            //using (SqlConnection sqlConn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["sConn"].ToString()))
            //{
            //    try
            //    {
            //        sqlConn.Open(); 
            //        sqlConn.Close();
            //    }
            //    catch (Exception e)
            //    {
            //        sqlConn.Close();

            //        Mensajes.ShowError("No se ha podido conectar con la base de datos.\n\nEl programa se cerrará.");
            //        //Application.Exit();
            //        shouldClose = true;
            //        iniciando = false;
            //        return;
            //    }
            //}

            //---- GSG (10/09/2014)
            try
            {
                sqlConn.Open();
                sqlConn.Close();
            }
            catch (Exception e)
            {
                sqlConn.Close();

                Mensajes.ShowError("No se ha podido conectar con la base de datos.\n\nEl programa se cerrará.");
                shouldClose = true;
                iniciando = false;
                return;
            }
            //---- FI GSG


            //Cargo la pantalla de password para validar el usuario
            GESTCRM.Clases.Configuracion.Carga();


            iniciando = false;
        }

		#endregion

		//En la tabla Configuración están definidos los accesos
		//a los distintos módulos de la aplicación
		// Acceso = 0 -> Total
		// Acceso = 1 -> Sólo Consulta
		// Acceso = 2 -> No tiene acceso
		#region Inicializar_Accesos
		private void Inicializar_Accesos()
		{
            switch (GESTCRM.Clases.Configuracion.iGVisitas)
			{
				case 1:
					this.mnuIVisitas.Enabled=false;
					this.ucBotoneraPrincipal1.btNReporting.Enabled=false;
					break;
				case 2: 
					this.mnuIVisitas.Enabled=false;
					this.mnuIcVisitas.Enabled=false;
					this.mnuIcPlanificacion.Enabled=false;
					this.ucBotoneraPrincipal1.btNReporting.Enabled=false;
					this.ucBotoneraPrincipal1.btReporting.Enabled=false;
					this.ucBotoneraPrincipal1.btPlanificacion.Enabled=false;
					break;
				default:break;
			}
			switch(GESTCRM.Clases.Configuracion.iGAtenciones)
			{
				case 1:
					this.mnuIAtenciones.Enabled=false;
					this.ucBotoneraPrincipal1.btNAtenciones.Enabled=false;
					break;
				case 2:
					this.mnuIAtenciones.Enabled=false;
					this.mnuIcAtenciones.Enabled=false;
					this.ucBotoneraPrincipal1.btNAtenciones.Enabled=false;
					this.ucBotoneraPrincipal1.btListaAtenciones.Enabled=false;
					break;
				default:break;
			}
			switch(GESTCRM.Clases.Configuracion.iGPedidos)
			{
				case 1:
					this.mnuIPedidos.Enabled=false;
					this.ucBotoneraPrincipal1.btNPedidos.Enabled=false;
					break;
				case 2:
					this.mnuIPedidos.Enabled=false;
					this.mnuIcPedidos.Enabled=false;
					this.ucBotoneraPrincipal1.btNPedidos.Enabled=false;
					this.ucBotoneraPrincipal1.btPedidos.Enabled=false;
					break;
				default:break;
			}
			switch(GESTCRM.Clases.Configuracion.iGGastos)
			{
				case 1:
					this.mnuIGastos.Enabled=false;
					this.ucBotoneraPrincipal1.btNGastos.Enabled=false;
					break;
				case 2:
					this.mnuIGastos.Enabled=false;
					this.mnuIcGastos.Enabled=false;
					this.ucBotoneraPrincipal1.btNGastos.Enabled=false;
					this.ucBotoneraPrincipal1.btGastos.Enabled=false;
					break;
				default:break;
			}

			if(GESTCRM.Clases.Configuracion.iGClientesCOM==2 &&
				GESTCRM.Clases.Configuracion.iGClientesSAP==2)
			{
				this.mnuIClientes.Enabled=false;
				this.ucBotoneraPrincipal1.btClientes.Enabled=false;
			}

			switch(GESTCRM.Clases.Configuracion.iGClientesCOM)
			{
				case 2:
					this.mnuIPersonas.Enabled=false;
					this.ucBotoneraPrincipal1.btCliCOM.Enabled=false;
					break;
				default:break;
			}
			switch(GESTCRM.Clases.Configuracion.iGClientesSAP)
			{
				case 2:
					this.mnuISAP.Enabled=false;
					this.ucBotoneraPrincipal1.btCliSAP.Enabled=false;
					break;
				default:break;
			}
			switch(GESTCRM.Clases.Configuracion.iGCentros)
			{
				case 2:
					this.mnuIcCentros.Enabled=false;
					this.ucBotoneraPrincipal1.btCentros.Enabled=false;
					break;
				default:break;
			}

			switch(GESTCRM.Clases.Configuracion.iGPresupuestos)
			{
				case 2:
					this.mnuIPresupuestos.Enabled = false;
					this.ucBotoneraPrincipal1.btnPresupuestos.Enabled=false;
					break;
				default:break;
			}

			switch(GESTCRM.Clases.Configuracion.iCreaCentros )
			{
				case 1:
				case 2:
					this.mnuICentros.Enabled = false;
					this.ucBotoneraPrincipal1.btCrearCentro.Enabled=false;
					break;
				default:break;
			}

			switch(GESTCRM.Clases.Configuracion.iCreaMedicos )
			{
				case 1:
				case 2:
					this.mnuIMedicos.Enabled = false;
					this.ucBotoneraPrincipal1.btCrearMedico.Enabled =false;  
					break;
				default:break;
			}

            //---- GSG (14/03/2014)
            switch (GESTCRM.Clases.Configuracion.iGPedidosCrear)
            {
                case 1:
                case 2:
                    this.mnuIIPedidos.Enabled = false;
                    this.ucBotoneraPrincipal1.btNPedidos.Enabled = false;
                    this.ucBotoneraPrincipal1.btPedidos.Enabled = false;
                    break;
                default: break;
            }
            switch (GESTCRM.Clases.Configuracion.iGPedidosCopiar)
            {
                case 1:
                case 2:
                    this.mnuIICopiaPedido.Enabled = false;
                    break;
                default: break;
            }
            switch (GESTCRM.Clases.Configuracion.iGPedidosPropuesta)
            {
                case 1:
                case 2:
                    this.mnuIIPedidoTipo.Enabled = false;
                    break;
                default: break;
            }
            switch (GESTCRM.Clases.Configuracion.iGInformeVentas)
            {
                case 1:
                case 2:
                    this.mnuIVentas.Enabled = false;
                    break;
                default: break;
            }
            switch (GESTCRM.Clases.Configuracion.iGImportExcel)
            {
                case 1:
                case 2:
                    this.mnuIIPFarmatic.Enabled = false;
                    break;
                default: break;
            }
            switch (GESTCRM.Clases.Configuracion.iGImportUnycop)
            {
                case 1:
                case 2:
                    this.mnuIIPUnycop.Enabled = false;
                    break;
                default: break;
            }
            switch (GESTCRM.Clases.Configuracion.iIndicadoresGlobales)
            {
                case 1:
                case 2:
                    this.mnuIIndicadores.Enabled = false;
                    break;
                default: break;
            }

            //---- GSG CECL 19/05/2016
            switch (GESTCRM.Clases.Configuracion.iGAccMarkPed)
            {
                case 1:
                case 2:
                    this.mnuIAutoPedAccMark.Enabled = false;
                    break;
                default: break;
            }
            switch (GESTCRM.Clases.Configuracion.iGAlarmVisit)
            {
                case 1:
                case 2:
                    this.mnuIAlarmasVisitas.Enabled = false;
                    break;
                default: break;
            }
            switch (GESTCRM.Clases.Configuracion.iGStock)
            {
                case 1:
                case 2:
                    this.mnuIStocks.Enabled = false;
                    break;
                default: break;
            }
            switch (GESTCRM.Clases.Configuracion.iGSincro)
            {
                case 1:
                case 2:
                    this.mnuISincro.Enabled = false;
                    break;
                default: break;
            }
            switch (GESTCRM.Clases.Configuracion.iGCopiaSeg)
            {
                case 1:
                case 2:
                    this.mnuISeguridad.Enabled = false;
                    break;
                default: break;
            }
            switch (GESTCRM.Clases.Configuracion.iGImportUnycop)
            {
                case 1:
                case 2:
                    this.mnuIIPUnycop.Enabled = false;
                    break;
                default: break;
            }
            //---- FI GSG CECL

		}
		#endregion

		//Acceso a formularios de creación
		#region Nuevo_Report
		private void Nuevo_Report()
		{
			if (!GESTCRM.Utiles.MirarSiAbierto(this,"frmReporting"))
			{
				Form frmTemp=new Formularios.frmReporting("A",-1,DateTime.Now,GESTCRM.Clases.Configuracion.iIdDelegado);
				frmTemp.MdiParent=this;
				frmTemp.Show();
			}
			else
			{
				DialogResult dr = Mensajes.ShowQuestion("No se puede crear un Report porque ya hay uno abierto. ¿Desea ver el Report abierto?");
				if(dr == DialogResult.Yes)
				{
					GESTCRM.Utiles.ActivaFormularioAbierto(this,"frmReporting");
				}
			}
		}
		#endregion

		#region Nuevo_Pedido
		private void Nuevo_Pedido()
		{
			if (!GESTCRM.Utiles.MirarSiAbierto(this,"frmPedidos"))
			{
				Form frmTemp=new Formularios.frmPedidos();
				frmTemp.MdiParent=this;	
				frmTemp.Show();				
			}
			else
			{
				DialogResult dr = Mensajes.ShowQuestion("No se puede crear un Pedido porque ya hay uno abierto. ¿Desea ver el Pedido abierto?");
				if(dr == DialogResult.Yes)
				{
					GESTCRM.Utiles.ActivaFormularioAbierto(this, "frmPedidos");
				}
			}
		}

        private void Copia_Pedido()
        {
            if (!GESTCRM.Utiles.MirarSiAbierto(this, "frmPedidos"))
            {
                Form frmTemp = new Formularios.frmCopiarPedido();
                frmTemp.MdiParent = this;
                frmTemp.Show();
            }
            else
            {
                DialogResult dr = Mensajes.ShowQuestion("No se puede crear un Pedido porque ya hay uno abierto. ¿Desea ver el Pedido abierto?");
                if (dr == DialogResult.Yes)
                {
                    GESTCRM.Utiles.ActivaFormularioAbierto(this, "frmPedidos");
                }
            }
        }

        private void Propuesta_Pedido()
        {
            if (!GESTCRM.Utiles.MirarSiAbierto(this, "frmPedidos"))
            {
                Form frmTemp = new Formularios.frmPropuestaPedido();
                frmTemp.MdiParent = this;
                frmTemp.Show();
            }
            else
            {
                DialogResult dr = Mensajes.ShowQuestion("No se puede crear un Pedido a partir de una propuesta porque ya hay uno abierto. ¿Desea ver el Pedido abierto?");
                if (dr == DialogResult.Yes)
                {
                    GESTCRM.Utiles.ActivaFormularioAbierto(this, "frmPedidos");
                }
            }
        }

		#endregion

		#region Nueva_NotaGastos
		private void Nueva_NotaGastos()
		{
			AbrirNotasGasto();
		}
		#endregion

		#region Alta_Centro
		private void AltaCentros()
		{
			if (!GESTCRM.Utiles.MirarSiAbierto(this,"frmAltaCentros"))
			{
				Form frmTemp=new Formularios.frmAltaCentros("A",-1,DateTime.Now,GESTCRM.Clases.Configuracion.iIdDelegado);
				frmTemp.MdiParent=this;
				frmTemp.Show();
			}
			else
			{
				DialogResult dr = Mensajes.ShowQuestion("No se puede crear un Centro porque ya hay uno abierto. ¿Desea ver el Centro abierto?");
				if(dr == DialogResult.Yes)
				{
					GESTCRM.Utiles.ActivaFormularioAbierto(this,"frmAltaCentros");
				}
			}
		}
		#endregion

		#region Asignacion Presupuestos
		private void AsignacionPresupuestos()
		{
			if (ExistePeriodo(DateTime.Now))
			{
				string sTipoAcceso = (GESTCRM.Clases.Configuracion.iGPresupuestos==0)?"A":"C";
				if (!GESTCRM.Utiles.MirarSiAbierto(this,"frmPresupuestos"))
				{
					Form frmTemp=new Formularios.frmPresupuestos( sTipoAcceso,GESTCRM.Clases.Configuracion.iIdDelegado);
					frmTemp.MdiParent=this;
					frmTemp.Show();
				}
				else
				{
					GESTCRM.Utiles.ActivaFormularioAbierto(this,"frmPresupuestos");
				}
			}
			else
			{
				Mensajes.ShowInformation("No existe ningun periodo de presupuestos activo para fecha actual.\nNo se puede asignar Presupuestos");
			}
		}
		#endregion

		#region Nueva_Atencion
		private void Nueva_Atencion()
		{
			if (!GESTCRM.Utiles.MirarSiAbierto(this,"frmAtenciones"))
			{
				Form frmTemp=new Formularios.frmAtenciones("A",-1,GESTCRM.Clases.Configuracion.iIdDelegado);
				frmTemp.MdiParent=this;						
				frmTemp.Show();	
			}
			else
			{
				DialogResult dr = Mensajes.ShowQuestion("No se puede crear una Atención porque ya hay uno abierta. ¿Desea ver la Atención abierta?");
				if(dr == DialogResult.Yes)
				{
					GESTCRM.Utiles.ActivaFormularioAbierto(this,"frmAtenciones");
				}
			}
		}
		#endregion

		#region Funcion de Apertura de Notas de Gasto
		private void AbrirNotasGasto()
		{
			int NotaGasto = 0;
			DateTime Fecha;
			string EnvCentral = "";
			int idNota = -1;
			
			Fecha = DateTime.Parse(DateTime.Now.ToShortDateString());			

			this.dsFormularios.GetExisteNotaGastos.Rows.Clear();

			this.sqldaGetExisteNotaGastos.SelectCommand.Parameters["@dFecha"].Value = Fecha;
			this.sqldaGetExisteNotaGastos.SelectCommand.Parameters["@iIdDelegado"].Value = GESTCRM.Clases.Configuracion.iIdDelegado;
			this.sqldaGetExisteNotaGastos.SelectCommand.Parameters["@bVisa"].Value = -1;				

			this.sqldaGetExisteNotaGastos.Fill(this.dsFormularios);

			if (this.dsFormularios.GetExisteNotaGastos.Rows.Count == 0)
			{

				if (!GESTCRM.Utiles.MirarSiAbierto(this,"frmGastos"))
				{
					Form frmTemp=new Formularios.frmGastos("A",-1,Fecha.ToShortTimeString(),Clases.Configuracion.iIdDelegado);
					frmTemp.MdiParent=this;
					frmTemp.Show();
				}
				else
				{
					DialogResult dr1 = Mensajes.ShowQuestion("No se puede crear una Nota de Gastos porque ya hay una abierta. ¿Desea ver la Nota de Gastos abierta?");
					if(dr1 == DialogResult.Yes)
					{
						GESTCRM.Utiles.ActivaFormularioAbierto(this,"frmGastos");
					}
				}
			}
			else
			{
				EnvCentral = dsFormularios.GetExisteNotaGastos.Rows[0]["bEnviadoCEN"].ToString();
				if (EnvCentral == "0")
				{
					DialogResult dr=Mensajes.ShowQuestion("Ya existe una nota de gasto para el dia de hoy.\n ¿Desea abrirla?");
			
					if(dr == System.Windows.Forms.DialogResult.Yes)
					{
						NotaGasto = Convert.ToInt32(dsFormularios.GetExisteNotaGastos.Rows[0]["iIdNota"].ToString());

						if (!GESTCRM.Utiles.MirarSiAbierto(this,"frmGastos"))
						{
							Form frmTemp=new Formularios.frmGastos("M",NotaGasto,Fecha.ToShortDateString(),Clases.Configuracion.iIdDelegado);
							frmTemp.MdiParent=this;
							frmTemp.Show();
						}
						else
						{
							DialogResult dr2 = Mensajes.ShowQuestion("No se puede crear una Nota de Gastos porque ya hay una abierta. ¿Desea ver la Nota de Gastos abierta?");
							if(dr2 == DialogResult.Yes)
							{
								GESTCRM.Utiles.ActivaFormularioAbierto(this,"frmGastos");
							}
						}
					}
					else
					{
						if (!GESTCRM.Utiles.MirarSiAbierto(this,"frmGastos"))
						{
							Form frmTemp=new Formularios.frmGastos("A",-1,null,Clases.Configuracion.iIdDelegado);
							frmTemp.MdiParent=this;
							frmTemp.Show();
						}
						else
						{
							DialogResult dr3 = Mensajes.ShowQuestion("No se puede crear una Nota de Gastos porque ya hay una abierta. ¿Desea ver la Nota de Gastos abierta?");
							if(dr3 == DialogResult.Yes)
							{
								GESTCRM.Utiles.ActivaFormularioAbierto(this,"frmGastos");
							}
						}
					}
				}
				else
				{
					//La Nota de Gasto se ha enviado a CENTRAL y no se puede editar
					//Mensajes.ShowError(1014);
					//LSR 01042003
					
					DialogResult dr=Mensajes.ShowQuestion("Ya existe una nota de gasto para el dia de hoy.\n ¿Desea abrirla?");
		
					if(dr == System.Windows.Forms.DialogResult.Yes)
					{
						idNota = Convert.ToInt32(dsFormularios.GetExisteNotaGastos.Rows[0]["iIdNota"].ToString());
						//idNota = Convert.ToInt32(this.dsFormularios.ListaBuscaGastos.Rows[0]["iIdNota"].ToString());
									
						Form frmTemp=new Formularios.frmGastos("M",idNota,Fecha.ToShortTimeString(),Clases.Configuracion.iIdDelegado);
						frmTemp.MdiParent=this;
						frmTemp.Show();
					}
					else
					{
						Form frmTemp=new Formularios.frmGastos("A",-1,null,Clases.Configuracion.iIdDelegado);
						frmTemp.MdiParent=this;
						frmTemp.Show();
					}
					//LSR
				}
			}
		}


		#endregion		


		//Acceso a formularios de Consultas
		#region Consulta_Pedidos
		private void Consulta_Pedidos()
		{
			if (!GESTCRM.Utiles.MirarSiAbierto (this,"frmConsultaPedidos"))
			{
				Form frmTemp = new  Formularios.frmConsultaPedidos();
				frmTemp.MdiParent = this;
				frmTemp.Show();
			}
			else
			{
				GESTCRM.Utiles.ActivaFormularioAbierto(this,"frmConsultaPedidos");
			}
		}
		#endregion
		
		#region Consulta_Clientes
		private void Consulta_Clientes(string TipoCliente)
		{
			if(TipoCliente==null)
			{
				if(GESTCRM.Clases.Configuracion.iGClientesCOM==2) TipoCliente="S";
				if(GESTCRM.Clases.Configuracion.iGClientesSAP==2) TipoCliente="C";
			}
			if (!GESTCRM.Utiles.MirarSiAbierto(this,"frmClientes"))
			{
				Form frmTemp=new Formularios.frmClientes(TipoCliente);
				frmTemp.MdiParent=this;	
				frmTemp.Show();
			}
			else
			{
				GESTCRM.Utiles.ActivaFormularioAbierto(this,"frmClientes");
			}
		}
        #endregion

        //---- GSG (03/07/2019)
        #region Consulta Encuestas
        private void Consulta_Encuestas()
        {
            if (!GESTCRM.Utiles.MirarSiAbierto(this, "frmConsultaEncuestas"))
            {
                Form frmTemp = new Formularios.frmConsultaEncuestas();
                frmTemp.MdiParent = this;
                frmTemp.Show();
            }
            else
            {
                GESTCRM.Utiles.ActivaFormularioAbierto(this, "frmConsultaEncuestas");
            }
        }
        #endregion

        #region Consulta_Gastos
        private void Consulta_Gastos()
		{
			if (!GESTCRM.Utiles.MirarSiAbierto (this,"frmConsultaGastos"))
			{
				Form frmTemp = new Formularios.frmConsultaGastos();
				frmTemp.MdiParent = this;
				frmTemp.Show();
			}
			else
			{
				GESTCRM.Utiles.ActivaFormularioAbierto(this,"frmConsultaGastos");
			}
		}
		#endregion

		#region Consulta_Atenciones
		private void Consulta_Atenciones()
		{
			if (!GESTCRM.Utiles.MirarSiAbierto(this,"frmConsultaAtenciones"))
			{
				Form frmTemp=new Formularios.frmConsultaAtenciones();
				frmTemp.MdiParent=this;						
				frmTemp.Show();	
			}
			else
			{
				GESTCRM.Utiles.ActivaFormularioAbierto(this,"frmConsultaAtenciones");
			}
		}
		#endregion

		#region Consulta_Report
		private void Consulta_Report()
		{
			if (!GESTCRM.Utiles.MirarSiAbierto(this,"frmConsultaReport"))
			{
				Form frmTemp=new Formularios.frmConsultaReport();
				frmTemp.MdiParent=this;	
				frmTemp.Show();
			}
			else
			{
				GESTCRM.Utiles.ActivaFormularioAbierto(this,"frmConsultaReport");
			}
		}
		#endregion

		#region Consulta_Planificacion
		private void Consulta_Planificacion()
		{
			if (!GESTCRM.Utiles.MirarSiAbierto(this,"frmConsultaVisit"))
			{
				Form frmTemp=new Formularios.frmConsultaVisit();
				frmTemp.MdiParent=this;	
				frmTemp.Show();
			}
			else
			{
				GESTCRM.Utiles.ActivaFormularioAbierto(this,"frmConsultaVisit");
			}
		}
		#endregion

		#region Consulta_Centros
		private void Consulta_Centros()
		{
			if (!GESTCRM.Utiles.MirarSiAbierto(this,"frmConsultaCentros"))
			{

				Form frmTemp=new Formularios.frmConsultaCentros(null);
				frmTemp.Cursor = Cursors.WaitCursor;
				frmTemp.MdiParent=this;	
				frmTemp.Show();
				frmTemp.Cursor = Cursors.Default;
			}
			else
			{
				GESTCRM.Utiles.ActivaFormularioAbierto(this,"frmConsultaCentros");
			}
		}
		#endregion


        //---- GSG (13/01/2014)
        #region Consulta_Ventas
        private void Consulta_Ventas()
        {
            // ---- GSG (24/03/2014)
            //if (!GESTCRM.Utiles.MirarSiAbierto(this, "frmConsultaVentas"))
            //{

            //    Form frmTemp = new Formularios.frmConsultaVentas();
            //    frmTemp.Cursor = Cursors.WaitCursor;
            //    frmTemp.MdiParent = this;
            //    frmTemp.Show();
            //    frmTemp.Cursor = Cursors.Default;
            //}
            //else
            //{
            //    GESTCRM.Utiles.ActivaFormularioAbierto(this, "frmConsultaVentas");
            //}

            if (!GESTCRM.Utiles.MirarSiAbierto(this, "frmIndicadoresIAlarmas"))
            {

                Form frmTemp = new Formularios.frmIndicadoresIAlarmas();
                frmTemp.Cursor = Cursors.WaitCursor;
                frmTemp.MdiParent = this;
                frmTemp.Show();
                frmTemp.Cursor = Cursors.Default;
            }
            else
            {
                GESTCRM.Utiles.ActivaFormularioAbierto(this, "frmIndicadoresIAlarmas");
            }
        }
        #endregion

        //---- GSG (25/03/2014)
        private void Consulta_AlarmasVisitas()
        {
            if (!GESTCRM.Utiles.MirarSiAbierto(this, "frmAlarmasVisitas"))
            {

                Form frmTemp = new Formularios.frmAlarmasVisitas();
                frmTemp.Cursor = Cursors.WaitCursor;
                frmTemp.MdiParent = this;
                frmTemp.Show();
                frmTemp.Cursor = Cursors.Default;
            }
            else
            {
                GESTCRM.Utiles.ActivaFormularioAbierto(this, "frmAlarmasVisitas");
            }
        }
		
        //---- GSG (02/04/2014)
        private void Consulta_Stocks()
        {
            if (!GESTCRM.Utiles.MirarSiAbierto(this, "frmStocks"))
            {
                Form frmTemp = new Formularios.frmStocks();
                frmTemp.Cursor = Cursors.WaitCursor;
                frmTemp.MdiParent = this;
                frmTemp.Show();
                frmTemp.Cursor = Cursors.Default;
            }
            else
            {
                GESTCRM.Utiles.ActivaFormularioAbierto(this, "frmStocks");
            }
        }

        //---- GSG (02/06/2014)

        private void Consulta_IndicadoresGlobales()
        {
            if (!GESTCRM.Utiles.MirarSiAbierto(this, "frmIndicadores_2"))
            {
                Form frmTemp = new Formularios.frmIndicadores_2();
                frmTemp.Cursor = Cursors.WaitCursor;
                frmTemp.MdiParent = this;
                frmTemp.Show();
                frmTemp.Cursor = Cursors.Default;
            }
            else
            {
                GESTCRM.Utiles.ActivaFormularioAbierto(this, "frmIndicadores_2");
            }
        }

		//Acceso a formulario de Sincronizacion
		#region Sincronizacion
		private void Sincronizacion()
		{
			Formularios.frmSincro frmSinc = new GESTCRM.Formularios.frmSincro();
			frmSinc.ShowDialog();
		}
		#endregion

		//Acceso a formulario de Sincronizacion con PDA
		#region SincronizacionPDA
		private void SincronizacionPDA()
		{
			Formularios.frmSincroPDA  frmSinc = new GESTCRM.Formularios.frmSincroPDA(); 
			frmSinc.ShowDialog();
		}
		#endregion


		//Acceso a formulario de Seguridad
		#region Seguridad
		private void CSeguridad()
		{
			DialogResult dr=Mensajes.ShowQuestion("¿Desea realizar copia de seguridad de la base de datos GESTCRM?");
			if (dr==DialogResult.Yes)
			{
				System.Data.SqlClient.SqlCommand sqlBack = new SqlCommand();

                //---- GSG (10/09/2014)
                //this.sqlConn.Open();
                if (sqlConn.State == ConnectionState.Closed)
                    this.sqlConn.Open();

				sqlBack.Connection=this.sqlConn;
				sqlBack.CommandTimeout=1800;
				
                //---- GSG (03/06/2021)
				//sqlBack.CommandText="BACKUP DATABASE GESTCRMCL TO DRIVE='"+Application.StartupPath+@"\Backup\GESTCRMCL"+DateTime.Now.Year.ToString()+DateTime.Now.Month.ToString().PadLeft(2,'0')+DateTime.Now.Day.ToString().PadLeft(2,'0')+DateTime.Now.Hour.ToString().PadLeft(2,'0')+DateTime.Now.Minute.ToString().PadLeft(2,'0')+DateTime.Now.Second.ToString().PadLeft(2,'0')+".BAK' WITH INIT, SKIP";
                sqlBack.CommandText = "BACKUP DATABASE GESTCRMCL TO DISK='" + Application.StartupPath + @"\Backup\GESTCRMCL" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Day.ToString().PadLeft(2, '0') + DateTime.Now.Hour.ToString().PadLeft(2, '0') + DateTime.Now.Minute.ToString().PadLeft(2, '0') + DateTime.Now.Second.ToString().PadLeft(2, '0') + ".BAK' WITH INIT, SKIP";
               



                sqlBack.ExecuteNonQuery();
				this.sqlConn.Close();

				Mensajes.ShowExclamation("La Copia de Seguridad se ha realizado con éxito.");
			}
		}


        //---- GSG (02/02/2021)
        private void CSeguridadAutomatica()
        {
            try
            {
                // Rutas y parámetros para copia
                
                //---- GSG (06/03/2021)
                //string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);


                string backupCRMPath = Application.StartupPath + @"\Backup";
                int iDiasParaCopia = int.Parse(System.Configuration.ConfigurationManager.AppSettings["DaysForOneDriveCopy"].ToString());

                // Obtener fecha de la última copia
                string[] files = System.IO.Directory.GetFiles(backupCRMPath, "*.bak");
                System.IO.FileInfo infoFile = null;
                DateTime lastCopy = DateTime.Parse("01/01/2021");
                
                foreach (string fit in files)
                {
                    try
                    {
                        infoFile = new System.IO.FileInfo(fit);
                        if (infoFile.CreationTime > lastCopy)
                            lastCopy = infoFile.CreationTime;

                    }
                    catch (System.IO.FileNotFoundException e)
                    {
                        continue;
                    }
                }


                // Tenemos la fecha del backup más reciente
                // Si hace más de una semana (días indicados en appconfig) que se hizo hay que volverla a hacer
                if (lastCopy < DateTime.Today)
                {
                    TimeSpan ts = DateTime.Today - lastCopy;
                    if (ts.Days >= iDiasParaCopia)
                    {
                        //---- Para que no se acumulen ficheros, borrar los antiguos, dejaré el último
                        string[] filesToDelete = System.IO.Directory.GetFiles(backupCRMPath);
                        foreach (string f in filesToDelete)
                            System.IO.File.Delete(f);

                        string[] filesToDelete2 = System.IO.Directory.GetFiles(desktopPath);
                        foreach (string f in filesToDelete2)
                        {
                            if (f.Contains("GESTCRMCL") && (f.Contains(".bak") || f.Contains(".BAK")))
                                System.IO.File.Delete(f);
                        }




                        System.Data.SqlClient.SqlCommand sqlBack = new SqlCommand();

                        if (sqlConn.State == ConnectionState.Closed)
                            this.sqlConn.Open();

                        sqlBack.Connection = this.sqlConn;
                        sqlBack.CommandTimeout = 1800;

                        // Primero se genera en la carpeta backup
                        string NombreFichero = @"\GESTCRMCL" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Day.ToString().PadLeft(2, '0') + DateTime.Now.Hour.ToString().PadLeft(2, '0') + DateTime.Now.Minute.ToString().PadLeft(2, '0') + DateTime.Now.Second.ToString().PadLeft(2, '0') + ".BAK";
                        //sqlBack.CommandText = "BACKUP DATABASE GESTCRMCL TO DISK='" + backupCRMPath + @"\GESTCRMCL" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Day.ToString().PadLeft(2, '0') + DateTime.Now.Hour.ToString().PadLeft(2, '0') + DateTime.Now.Minute.ToString().PadLeft(2, '0') + DateTime.Now.Second.ToString().PadLeft(2, '0') + ".BAK' WITH INIT, SKIP";
                        sqlBack.CommandText = "BACKUP DATABASE GESTCRMCL TO DISK='" + backupCRMPath + NombreFichero + "' WITH INIT, SKIP";
                        sqlBack.ExecuteNonQuery();

                        // Despues se genera en el escritorio (ya que el escritorio ya se sincroniza con OneDrive)
                        // Cambiado escritorio por Documentos que también sincroniza con OneDrive
                        ///sqlBack.CommandText = "BACKUP DATABASE GESTCRMCL TO DISK='" + desktopPath + @"\GESTCRMCL" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Day.ToString().PadLeft(2, '0') + DateTime.Now.Hour.ToString().PadLeft(2, '0') + DateTime.Now.Minute.ToString().PadLeft(2, '0') + DateTime.Now.Second.ToString().PadLeft(2, '0') + ".BAK' WITH INIT, SKIP";
                        System.IO.File.Copy(backupCRMPath + NombreFichero, desktopPath + NombreFichero, true);



                        sqlBack.ExecuteNonQuery();
                        this.sqlConn.Close();
                    }
                }

                // VLP (03/04/2023)
                // Rehacer índices de todas las tablas. Se utiliza el parámetro dFUSPDA ValorConf(5) para guaardar la fecha de la úlitma ejecución.                
                DateTime lasReubidDBIndexes = GESTCRM.Clases.Configuracion.dFUSPDA;
                TimeSpan daysAfterLasRebuildDBIndexes = DateTime.Today - lasReubidDBIndexes;
                int daysForRebuildAllDBIndexes = int.Parse(System.Configuration.ConfigurationManager.AppSettings["DaysForRebuildAllDBIndexes"].ToString());
                if (daysAfterLasRebuildDBIndexes.Days >= daysForRebuildAllDBIndexes)
                {
                    if (System.Configuration.ConfigurationManager.AppSettings["TipoDelegadoPedidosCentral"].ToString() != Comun.K_CECL) //Si no es CENTRAL
                        RebuidAlldDBIndexes();
                }

            }
            catch(Exception e)
            {

            }
        }


        // VLP (03/04/2023) 
        // Rehace los índices de todas las tablas de la DB
        private void RebuidAlldDBIndexes()
        {
            try
            {
                if (this.sqlConn.State == ConnectionState.Closed)
                {
                    this.sqlConn.Open();
                }

                using (System.Data.SqlClient.SqlCommand sqlCmd = new SqlCommand(@"[dbo].[ReorganizarIndices]", sqlConn))
                {
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.CommandTimeout = 1800;
                    sqlCmd.ExecuteNonQuery();

                    GESTCRM.Clases.Configuracion.GrabaValor(5, (DateTime.Today).ToString());

                    //throw new Exception("VLP exception test");
                }

                this.sqlConn.Close();
            }
            catch (Exception ex)
            {

            }
        }


        //---- GSG (28/03/2020)
        private void CSeguridadAutoDrive()
        {
            string sFolderONEDRIVECopiasCRM = System.Configuration.ConfigurationManager.AppSettings["FolderOneDriveBackupCRM"].ToString();
            int iDiasParaCopia = int.Parse(System.Configuration.ConfigurationManager.AppSettings["DaysForOneDriveCopy"].ToString());

            if (!System.IO.Directory.Exists(sFolderONEDRIVECopiasCRM))
            {
                // Crear carpeta para copias si no existe
                System.IO.Directory.CreateDirectory(sFolderONEDRIVECopiasCRM);
            }

            // Obtener fecha de la última copia
            string[] files = System.IO.Directory.GetFiles(sFolderONEDRIVECopiasCRM, "*.bak");
            System.IO.FileInfo infoFile = null;
            DateTime lastCopy = DateTime.Parse("01/01/2020");

            foreach (string fit in files)
            {
                try
                {
                    infoFile = new System.IO.FileInfo(fit);
                    if (infoFile.CreationTime > lastCopy)
                        lastCopy = infoFile.CreationTime;

                }
                catch (System.IO.FileNotFoundException e)
                {
                    continue;
                }
            }

            // Tenemos la fecha del backup más reciente
            // Si hace más de una semana (días indicados en appconfig) que se hizo hay que volverla a hacer
            if (lastCopy < DateTime.Today)
            {
                TimeSpan ts = DateTime.Today - lastCopy;
                if (ts.Days >= iDiasParaCopia)
                {
                    System.Data.SqlClient.SqlCommand sqlBack = new SqlCommand();

                    if (sqlConn.State == ConnectionState.Closed)
                        this.sqlConn.Open();

                    sqlBack.Connection = this.sqlConn;
                    sqlBack.CommandTimeout = 1800;

                    sqlBack.CommandText = "BACKUP DATABASE GESTCRMCL TO DISK='" + sFolderONEDRIVECopiasCRM + @"\GESTCRMCL" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Day.ToString().PadLeft(2, '0') + DateTime.Now.Hour.ToString().PadLeft(2, '0') + DateTime.Now.Minute.ToString().PadLeft(2, '0') + DateTime.Now.Second.ToString().PadLeft(2, '0') + ".BAK' WITH INIT, SKIP";
                    
                    sqlBack.ExecuteNonQuery();
                    this.sqlConn.Close();

                    Mensajes.ShowExclamation("La Copia de Seguridad a ONEDRIVE se ha realizado con éxito.");
                }
            }
            

        }



        #endregion

        //Acceso a formlario de Importación de pedido //---- GSG (10/07/2013)
        #region Importación pedido
        private void ImportacionPedido(string tipoImportacion)
        {
            Formularios.frmImportarPedido frmImp = new GESTCRM.Formularios.frmImportarPedido(tipoImportacion);
            frmImp.MdiParent = this;
            frmImp.Show();
        }
        #endregion

        //---- GSG (14/03/2014)
        #region Asignar Acciones de Márketing a Autopedidos
        private void AsignarAutopedAccMark()
        {
            if (!GESTCRM.Utiles.MirarSiAbierto(this, "frmAutopedAccMark"))
            {

                Form frmTemp = new Formularios.frmAutopedAccMark();
                frmTemp.Cursor = Cursors.WaitCursor;
                frmTemp.MdiParent = this;
                frmTemp.Show();
                frmTemp.Cursor = Cursors.Default;
            }
            else
            {
                GESTCRM.Utiles.ActivaFormularioAbierto(this, "frmAutopedAccMark");
            }
        }
        #endregion



        //Gestión de los eventos de pantalla de Menú
		#region Tipo aparición de pantallas
		private void mnuCascada_Click(object sender, System.EventArgs e)
		{
			this.LayoutMdi(MdiLayout.Cascade);
		}

		private void mnuHorizontal_Click(object sender, System.EventArgs e)
		{
			this.LayoutMdi(MdiLayout.TileHorizontal);
		}

		private void mnuVertical_Click(object sender, System.EventArgs e)
		{
			this.LayoutMdi(MdiLayout.TileVertical);
		}
		#endregion



		//Gestión de los eventos de aplicación de Menú y de la Botonera principal
		//Se han definidos los mismos eventos de aplicación para menú y botonera
		
		//Eventos de Aplicación SALIR
		#region mnuSalir_Click
		private void mnuSalir_Click(object sender, System.EventArgs e)
		{
            //DialogResult dr=Mensajes.ShowQuestion("¿Desea salir por completo de la aplicación?");
			
            //if(dr == System.Windows.Forms.DialogResult.Yes)
            //{
            //    //Application.Exit();
            //}

            //RH
            Close();
		}
		#endregion

		//Eventos de Aplicación NUEVO
		#region mnuIPedidos_Click 
		private void mnuIPedidos_Click(object sender, System.EventArgs e)
		{
			Nuevo_Pedido();
		}

        //---- GSG (15/01/2014)
        private void mnuIICopiaPedido_Click(object sender, System.EventArgs e)
        {
            Copia_Pedido();
        }

        private void mnuIIPedidoTipo_Click(object sender, System.EventArgs e)
        {
            Propuesta_Pedido();
        }
        //---- FI GSG
		#endregion

		#region mnuIGastos_Click --Nueva Nota de Gastos
		private void mnuIGastos_Click(object sender, System.EventArgs e)
		{
			Nueva_NotaGastos();
		}
		#endregion 

		#region mnuIVisitas_Click --Nuevo Report
		private void mnuIVisitas_Click(object sender, System.EventArgs e)
		{
			Nuevo_Report();
		}
		#endregion

		#region mnuIAtenciones_Click --Nueva Atencion
		private void mnuIAtenciones_Click(object sender, System.EventArgs e)
		{
			Nueva_Atencion();
		}
		#endregion

		//Eventos de Aplicación	CONSULTAS	
		#region mnuIcPedidos_Click --Consulta Pedidos
		private void mnuIcPedidos_Click(object sender, System.EventArgs e)
		{
			Consulta_Pedidos();
		}
		#endregion

		#region mnuIcClientes_Click --Consulta Clientes
		private void mnuIcClientes_Click(object sender, System.EventArgs e)
		{
			Consulta_Clientes(null);
		}




		#endregion

		#region mnuISAP_Click --Consulta Clientes SAP
		private void mnuISAP_Click(object sender, System.EventArgs e)
		{
			Consulta_Clientes("S");
        }
        #endregion

        //---- GSG (03/07/2019)
        #region mnuIEncuestas_Click --Consulta Encuestas
        private void mnuIEncuestas_Click(object sender, System.EventArgs e)
        {
            Consulta_Encuestas();
        }
		#endregion





        #region mnuIPersonas_Click --Consulta Clientes COM
        private void mnuIPersonas_Click(object sender, System.EventArgs e)
		{
			Consulta_Clientes("C");
		}
		#endregion

		#region mnuIcGastos_Click --Consulta Gastos
		private void mnuIcGastos_Click(object sender, System.EventArgs e)
		{
			Consulta_Gastos();
		}
		#endregion

		#region mnuIcVisitas_Click --Consulta Reports
		private void mnuIcVisitas_Click(object sender, System.EventArgs e)
		{
			Consulta_Report();

		}
		#endregion

		#region mnuIcAtenciones_Click --Consulta Atenciones
		private void mnuIcAtenciones_Click(object sender, System.EventArgs e)
		{
			Consulta_Atenciones();
		}
		#endregion 

		#region mnuIcPlanificacion_Click --Consulta Planificacion
		private void mnuIcPlanificacion_Click(object sender, System.EventArgs e)
		{
			Consulta_Planificacion();
		}
		#endregion

		#region mnuIcCentros_Click --Consulta_Centros
		private void mnuIcCentros_Click(object sender, System.EventArgs e)
		{
			Consulta_Centros();
		}
		#endregion

        //---- GSG (13/01/2014)
        #region mnuIVentas_Click -- Consulta Datos Ventas Farmacia
        private void mnuIVentas_Click(object sender, System.EventArgs e)
		{
			Consulta_Ventas();
		}
        #endregion

        //---- GSG (25/03/2014)
        #region mnuIAlarmasVisitas_Click 
        private void mnuIAlarmasVisitas_Click(object sender, System.EventArgs e)
        {
            Consulta_AlarmasVisitas();
        }
        #endregion

        //---- GSG (02/04/2014)
        #region mnuIStocks_Click
        private void mnuIStocks_Click(object sender, System.EventArgs e)
        {
            Consulta_Stocks();
        }

        
        #endregion

        //---- GSG (02/06/2014)
        #region mnuIIndicadores_Click
        private void mnuIIndicadores_Click(object sender, System.EventArgs e)
        {
            Consulta_IndicadoresGlobales();
        }
        #endregion

		//Eventos de Aplicación HERRAMIENTAS
		#region mnuISincro_Click --Acceso a formulario de sincronización.
		private void mnuISincro_Click(object sender, System.EventArgs e)
		{
			Sincronizacion();
		}
		#endregion

		#region mnuISincroPDA_Click --Acceso a formulario de sincronización con PDA.
		private void mnuISincroPDA_Click(object sender, System.EventArgs e)
		{
			SincronizacionPDA();
		}
		#endregion
		#region mnuICSeguridad_Click --Acceso a Realizar Copia de seguridad.
		private void mnuICSeguridad_Click(object sender, System.EventArgs e)
		{
			Cursor.Current=Cursors.WaitCursor;

			CSeguridad();

			Cursor.Current=Cursors.Default;
		}
		#endregion

		#region mnuIRSeguridad_Click --Acceso a Restaurar de Copia de seguridad.
		private void mnuIRSeguridad_Click(object sender, System.EventArgs e)
		{
			frmRestore frmRest = new frmRestore();
			frmRest.ShowDialog();
		}
		#endregion

        //---- GSG (10/07/2013)
        #region mnuIImportarPedido_Click --Acceso a formulario de Importación de pedidos.
        private void mnuIImportarPedidoFarmatic_Click(object sender, System.EventArgs e)
		{
            ImportacionPedido(K_FARMATIC);
		}

        private void mnuIImportarPedidoUnycop_Click(object sender, System.EventArgs e)
        {
            ImportacionPedido(K_UNYCOP);
        }
		#endregion

		//Eventos de Aplicación ANALISIS
		#region mnuAnalisis_Click
		private void mnuAnalisis_Click(object sender, System.EventArgs e)
		{
			System.Windows.Forms.MenuItem mnuItem = (System.Windows.Forms.MenuItem)(sender);
//			Microsoft.Office.Interop.Excel.ApplicationClass aExcel = new Microsoft.Office.Interop.Excel.ApplicationClass();
//			aExcel.Workbooks.Open(Application.StartupPath + @"\Analisis\"+mnuItem.Text+".XLS",true,false,null,null,null,true,null,null,true,false,null,false,null,null);
		}
		#endregion

        //---- GSG (14/03/2014)
        #region mnuIAutoPedAccMark_Click
        private void mnuIAutoPedAccMark_Click(object sender, System.EventArgs e)
        {
            AsignarAutopedAccMark();
        }
        #endregion

        #region tmrBarra_Tick
        private void tmrBarra_Tick(object sender, System.EventArgs e)
		{	
			this.statPanelHora.Text = DateTime.Now.ToString();
		}
		#endregion


		#region frmPrincipal_Closing
		private void frmPrincipal_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			DialogResult dr = Mensajes.ShowQuestion("¿Desea salir por completo de la aplicación?");

            //RH
            e.Cancel = (dr != DialogResult.Yes);
			
            //if(dr == System.Windows.Forms.DialogResult.Yes)
            //{
            //    Application.Exit();
            //}
            //else
            //{
            //    e.Cancel = true;
            //}
		}
		#endregion

		
		#region Clase del Menu
		public class MyIconMenuItem : System.Windows.Forms.MenuItem
		{
			private Font fontx;
			private Icon iconx;
		
			public MyIconMenuItem(string menuText,EventHandler handler,Shortcut shortcut,Icon ico):base(menuText,handler,shortcut)				
			{
                

				try
				{
					this.iconx = ico;
                    //---- GSG (13/03/2019)
                    //this.fontx = SystemInformation.MenuFont;
                    this.fontx = new Font("verdana", 12F); 

                    this.OwnerDraw = true;
				}
				catch{}
			}

			protected override void OnMeasureItem(MeasureItemEventArgs e)
			{
				try
				{
					base.OnMeasureItem (e);
					StringFormat sf = new StringFormat();

					sf.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.Show;
					sf.SetTabStops(50.0f,new float[]{0});

					if (this.iconx.Height > this.fontx.Height)
					{
						e.ItemHeight = this.iconx.Height + 6;
					}
					else
					{
						e.ItemHeight = this.fontx.Height + 6;
					}
			
					//e.ItemWidth = Convert.ToInt32(e.Graphics.MeasureString(AppendShortcut(),this.fontx, 1000,sf).Width) + this.iconx.Width + 5;
					e.ItemWidth = Convert.ToInt32(e.Graphics.MeasureString(this.Text,this.fontx, 1000,sf).Width) + this.iconx.Width + 5;
					sf.Dispose();
				}
				catch{}
			}

			protected override void OnDrawItem(DrawItemEventArgs e)
			{
				try
				{
					Brush br;
					StringFormat sf;

					base.OnDrawItem (e);
					e.Graphics.FillRectangle(SystemBrushes.Control, e.Bounds);
					if(((e.State & DrawItemState.Selected)==DrawItemState.Selected) && this.Enabled)
					{
						br = new SolidBrush(Color.White);
						e.DrawBackground();
						//ControlPaint.DrawMenuGlyph(e.Graphics,1,1,50,20,MenuGlyph.Arrow);
					}
					else
					{
						br = new SolidBrush(SystemColors.WindowText);
					}
					if(!this.Enabled)//Opción desactivada
					{
						br = new SolidBrush(Color.Gray);
					}

					if(this.iconx != null)
					{
						e.Graphics.DrawIcon(this.iconx,e.Bounds.Left + 3, e.Bounds.Top + 3);
					}
					sf = new StringFormat();
					sf.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.Show;
					sf.SetTabStops(50.0f,new float[]{0});

					//			br = new SolidBrush(SystemColors.WindowText);
					//e.Graphics.DrawString(AppendShortcut(), this.fontx, br, e.Bounds.Left + this.iconx.Width + 10, e.Bounds.Top + 2, sf);
					e.Graphics.DrawString(this.Text, this.fontx, br, e.Bounds.Left + this.iconx.Width + 10, e.Bounds.Top + 2, sf);
					br.Dispose();
					sf.Dispose();
				}
				catch{}
			}
		
			private string AppendShortcut()
			{
				string s="";
				try
				{
					s = this.Text;
					if(this.ShowShortcut && (this.Shortcut != Shortcut.None))
					{
						Keys k = (Keys)Shortcut;					
						s = s + Convert.ToChar(9) + Convert.ToString(k);
					}
					return s;
				}
				catch{return s;}
			}

		}
		#endregion


		private void mnuAcerca_Click(object sender, System.EventArgs e)
		{
            using (frmAbout frmAcercaDe = new frmAbout())
            {
                frmAcercaDe.ShowDialog();
            }
		}

		private void mnuConf_Click(object sender, System.EventArgs e)
		{
            using (Mantenimientos.frmMConfiguracion frmConf = new GESTCRM.Formularios.Mantenimientos.frmMConfiguracion())
            {
                frmConf.ShowDialog();
            }

			Application.DoEvents();

			// Vuelve a cargar la configuracion  
			GESTCRM.Clases.Configuracion.Carga();

			// Vuelve a inicializar los accesos
			this.Inicializar_Accesos(); 
		}

		#region Creación de Médicos
		private void mnuIMedicos_Click(object sender, System.EventArgs e)
		{
			AltaMedicos();
		}
		#endregion
		#region Creación de Centros
		private void mnuICentros_Click(object sender, System.EventArgs e)
		{
			AltaCentros();
		}
		#endregion
		#region Asignación de Presupuestos
		private void mnuIPresupuestos_Click(object sender, System.EventArgs e)
		{
			AsignacionPresupuestos();
		}
		#endregion
		#region AltaMedicos
		private void AltaMedicos()
		{
			if (!GESTCRM.Utiles.MirarSiAbierto(this,"frmAltaMedicos"))
			{
				Form frmTemp=new Formularios.frmAltaMedicos("A",-1);
				frmTemp.MdiParent=this;
				frmTemp.Show();
			}
			else
			{
				DialogResult dr = Mensajes.ShowQuestion("No se puede crear un Médico porque ya hay un formulario igual abierto. ¿Desea ver el Formulario abierto?");
				if(dr == DialogResult.Yes)
				{
					GESTCRM.Utiles.ActivaFormularioAbierto(this,"frmAltaMedicos");
				}
			}
		}
		#endregion

		#region RevisaPeriodoPresupuesto
		public bool ExistePeriodo (DateTime theDate)
		{
			bool existe = false;
			System.Data.SqlClient.SqlCommand sCmd = new SqlCommand();
			try
			{
				sCmd.CommandType = CommandType.Text;
				sCmd.CommandText="SELECT iIdPeriodo FROM PeriodosPresupuestos WHERE (iEstado = 0) AND (@dFecha BETWEEN dFechaIni AND dFechaFin )";
				sCmd.Parameters.Clear();
				sCmd.Parameters.Add("@dFecha",SqlDbType.DateTime);
				sCmd.Parameters["@dFecha"].Value = theDate;
				sCmd.Connection = this.sqlConn;

				if (this.sqlConn.State==ConnectionState.Closed) sqlConn.Open();

				existe =!(sCmd.ExecuteScalar()==null);

			}
			catch (Exception E)
			{
				Mensajes.ShowError(E.Message);
				return false;
			}
			finally
			{
				if (this.sqlConn.State==ConnectionState.Open) sqlConn.Close();
			}
			return (existe);
		}
        #endregion

        //---- GSG (13/03/2019)
        public int Login(string usuario)
        {
            /*
             iRet = 0; No existía y se ha creado
             iRet = -1; Existía y login incorrecto
             iRet = 1; Existía y login ok
            */

            int iRet = -2; //-2 petada           

            try
            {
                DataTable dt = new DataTable();

                this.sqlCmdLogin.Parameters["@sUsuarioWindows"].Value = usuario;
                sqlDALogin.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.NewRow();
                    dr = dt.Rows[0];

                    iRet = int.Parse(dr[0].ToString());
                }                
            }
            catch (Exception E)
            {
                Mensajes.ShowError("Error Login:" + E.Message);
            }

            return iRet;
        }


    }
}
