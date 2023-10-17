using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes; 


namespace GESTCRM.Formularios
{
	/// <summary>
	/// Descripción breve de Form1.
	/// </summary>
	public class frmAltaCentros : System.Windows.Forms.Form
	{

		

		private string		ParamTipoAcceso;	//Tipo de acceso al formulario A:Alta, M:Modificación, C:Consulta
		private int			ParamIdCentro;		//Identificador de Report, sólo en Modificaciones y Consultas
		private DateTime	ParamFecha;			//sólo en Altas desde planificación
		private int			ParamiIdDelegado;	//Identificador de delegado
		private int			iEstadoCentro;     //Solo se pueden asociar clientes con estado 0
		private	string		sIdCentro;			//Identificador del centro obtenido del sistema.
		private bool		bEnviadoCen;	//Indica si se ha enviado a central
		private int			iFILA = -1;		//Fila que se esta modificando
		private string		sAccionLinea = "" ; //Valor de Accion de la linea que se esta modificando.
		private ArrayList	aListaClientesBorrados = new ArrayList();

		//Acciones con la lineas del grid
		private const string Accion_Insertar = "I";
		private const string Accion_Modificar = "M";
		private const string Accion_Eliminar = "E";

		//Estados Centros
		private const int ESTADO_ACTIVO = 0;
		private const int ESTADO_PENDIENTE = -3;
		private const int ESTADO_RECHAZADO = -2;
		private const int ESTADO_INACTIVO = -1;

		protected System.Data.SqlClient.SqlTransaction sqlTran;
	
		private GESTCRM.Controles.ucBotoneraSecundaria ucBotoneraSecundaria1;
		private GESTCRM.Controles.LabelGradient labelGradient1;
		private System.Windows.Forms.TextBox txtCodPostal;
		private System.Windows.Forms.Label lblCodPostal;
		private System.Windows.Forms.Button btnBuscPob;
		private System.Windows.Forms.TextBox txbBPoblacion;
		private System.Windows.Forms.ComboBox cboTipoCentro;
		private System.Windows.Forms.Label lblTipoCentro;
		private System.Windows.Forms.TextBox txbIdPoblacion;
		private System.Windows.Forms.TextBox txbNomCentro;
		private System.Windows.Forms.Label lblNombreCentro;
		private System.Windows.Forms.Label lblPoblacion;
		private System.Windows.Forms.TextBox txbDireccionCentro;
		private System.Windows.Forms.Label lblDireccion;
		private System.Windows.Forms.TextBox txbBickIMS;
		private System.Windows.Forms.Label lblBricksIMS;
		private System.Windows.Forms.Label lblProvincia;
		private System.Windows.Forms.ComboBox cboClasificacion;
		private System.Windows.Forms.Label lblClasificacion;
		private System.Windows.Forms.Label lblTelefono;
		private System.Windows.Forms.Label lblFax;
		private System.Windows.Forms.ComboBox cboPactoPrescripcion;
		private System.Windows.Forms.Label lblPactoPrescripcion;
		private System.Windows.Forms.ComboBox cboPoliticaPrescripcion;
		private System.Windows.Forms.Label lblPolitica;
		private System.Windows.Forms.ComboBox cboVisitaColectiva;
		private System.Windows.Forms.Label lblVisitaColoectiva;
		private System.Windows.Forms.ComboBox cboSistemaInformatico;
		private System.Windows.Forms.Label lblSistemaInformatico;
		private System.Windows.Forms.Label lblNumRegistros;
		private GESTCRM.Controles.LabelGradient labelGradient2;
		private System.Windows.Forms.Label lblCliente;
		private System.Windows.Forms.ComboBox cboRelecionConElCentro;
		private System.Windows.Forms.Label lblRelecionConElCentro;
		public System.Windows.Forms.TextBox txtClienteSAP;
		private System.Windows.Forms.Button btBuscarCliente;
		private System.Windows.Forms.TextBox txtsCliente;
		private System.Windows.Forms.Button btnEliminar;
		private System.Windows.Forms.Button btnActualizar;
		private System.Data.SqlClient.SqlConnection sqlConn;
		private GESTCRM.Formularios.DataSets.dsAltaCentros dsAltaCentros;
		private System.Data.SqlClient.SqlDataAdapter sqldaTipoCentro;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		private System.Data.SqlClient.SqlDataAdapter sqldaListaTipoClasificacion;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand4;
		private System.Data.SqlClient.SqlDataAdapter sqldaListaTipoSistemaInformatico;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		private System.Data.SqlClient.SqlDataAdapter sqldaListaTipoPoliticaPrescripcion;
		private System.Data.SqlClient.SqlDataAdapter sqldaListaTipoRelacionClienteCentro;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand5;
		private System.Windows.Forms.TextBox txbProvincia;
		private System.Windows.Forms.DataGrid dgCLientesCentros;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle;
		private System.Windows.Forms.DataGridTextBoxColumn dgtxtiIdCliente;
		private System.Windows.Forms.DataGridTextBoxColumn dgtxtsIdCliente;
		private System.Windows.Forms.DataGridTextBoxColumn dgtxtNombre;
		private System.Windows.Forms.DataGridTextBoxColumn dgtxtsIdTipoRelacionCliCen;
		private System.Windows.Forms.DataGridTextBoxColumn dgtxtsLiteral;
		private System.Data.SqlClient.SqlDataAdapter sqldaListaCLientesCOM_Centros;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand6;
		public System.Windows.Forms.TextBox txbiIdCliente;
		private System.Windows.Forms.Panel pnAsociarClientes;
		private System.Windows.Forms.Panel pnClientes;
		private System.Data.SqlClient.SqlCommand sqlCmdExisteCentroRedPropioCliente;
		private System.Data.SqlClient.SqlCommand sqlcmdSetCentros;
		private System.Data.SqlClient.SqlCommand sqlCmdGetCentroIdTemp;
		private System.Windows.Forms.TextBox txbFax;
		private System.Windows.Forms.TextBox txbTelefono;
		private System.Data.SqlClient.SqlDataAdapter sqldaGetCentro;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand7;
		private System.Windows.Forms.DataGridTextBoxColumn dgtxtAccion;
		private System.Windows.Forms.Panel pnCentro;
		private System.Windows.Forms.Panel pnCombos;
		private System.Data.SqlClient.SqlCommand sqlcmdSetCentrosRedes;
		private System.Data.SqlClient.SqlCommand sqlcmdSetCentrosClientesCOM;
		private System.Windows.Forms.ContextMenu contextMenuGrigClientes;
		private System.Windows.Forms.MenuItem menuEditar;
		private System.Data.SqlClient.SqlCommand sqlcmdSetCP_CLientes_BrickCLientes;
		private System.Data.SqlClient.SqlCommand sqlcmdExisteCentroRed;
		private System.Windows.Forms.DataGridTextBoxColumn dgtxtsIdred;
		private System.Windows.Forms.DataGridTextBoxColumn dgtxtRed;
		private System.Data.SqlClient.SqlDataAdapter sqldaListaRedes;
		private System.Data.SqlClient.SqlCommand sqlCommand1;
		/// <summary>
		/// Variable del diseñador requerida.
		/// </summary>
		private System.ComponentModel.Container components = null;
		
		/// <summary>
		/// Formulario Alta Cnetro
		/// </summary>
		/// <param name="TipoAcceso">Tipo de acceso al formulario A-ALta, M-Modificacion, C-Consulta</param>
		/// <param name="IdCentro">Identificador del centro al consultar, -1 si no hay centro.</param>
		/// <param name="Fecha">Fecha</param>
		/// <param name="iIdDelegado">Identificador del delegado.</param>
		public frmAltaCentros(string TipoAcceso, int IdCentro,DateTime Fecha,int iIdDelegado)
		{
			//
			// Necesario para admitir el Diseñador de Windows Forms
			//
			InitializeComponent();

            //---- GSG (06/03/2021)
            Utiles.GetConfigConnection();
            this.sqlConn.ConnectionString = Utiles._connection.ConnectionString.ToString();


            this.ParamTipoAcceso=TipoAcceso;//A-> Alta; M->Modificación; C->Consulta
			this.ParamIdCentro=IdCentro;	// Identificador del Report
			this.ParamFecha=Fecha;			// Fecha del Report, sólo se usa para el alta y cuando la llamada es desde Planificación			
			this.ParamiIdDelegado=iIdDelegado;

		}


		public frmAltaCentros()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAltaCentros));
            this.ucBotoneraSecundaria1 = new GESTCRM.Controles.ucBotoneraSecundaria();
            this.pnCentro = new System.Windows.Forms.Panel();
            this.pnCombos = new System.Windows.Forms.Panel();
            this.cboPactoPrescripcion = new System.Windows.Forms.ComboBox();
            this.dsAltaCentros = new GESTCRM.Formularios.DataSets.dsAltaCentros();
            this.lblPactoPrescripcion = new System.Windows.Forms.Label();
            this.cboPoliticaPrescripcion = new System.Windows.Forms.ComboBox();
            this.lblPolitica = new System.Windows.Forms.Label();
            this.cboVisitaColectiva = new System.Windows.Forms.ComboBox();
            this.lblVisitaColoectiva = new System.Windows.Forms.Label();
            this.cboSistemaInformatico = new System.Windows.Forms.ComboBox();
            this.lblSistemaInformatico = new System.Windows.Forms.Label();
            this.cboClasificacion = new System.Windows.Forms.ComboBox();
            this.txbFax = new System.Windows.Forms.TextBox();
            this.lblFax = new System.Windows.Forms.Label();
            this.txbTelefono = new System.Windows.Forms.TextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.lblClasificacion = new System.Windows.Forms.Label();
            this.lblProvincia = new System.Windows.Forms.Label();
            this.txbProvincia = new System.Windows.Forms.TextBox();
            this.txbBickIMS = new System.Windows.Forms.TextBox();
            this.lblBricksIMS = new System.Windows.Forms.Label();
            this.txbDireccionCentro = new System.Windows.Forms.TextBox();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.labelGradient1 = new GESTCRM.Controles.LabelGradient();
            this.txtCodPostal = new System.Windows.Forms.TextBox();
            this.lblCodPostal = new System.Windows.Forms.Label();
            this.txbNomCentro = new System.Windows.Forms.TextBox();
            this.lblNombreCentro = new System.Windows.Forms.Label();
            this.btnBuscPob = new System.Windows.Forms.Button();
            this.txbBPoblacion = new System.Windows.Forms.TextBox();
            this.lblPoblacion = new System.Windows.Forms.Label();
            this.cboTipoCentro = new System.Windows.Forms.ComboBox();
            this.lblTipoCentro = new System.Windows.Forms.Label();
            this.txbIdPoblacion = new System.Windows.Forms.TextBox();
            this.pnClientes = new System.Windows.Forms.Panel();
            this.lblNumRegistros = new System.Windows.Forms.Label();
            this.labelGradient2 = new GESTCRM.Controles.LabelGradient();
            this.dgCLientesCentros = new System.Windows.Forms.DataGrid();
            this.contextMenuGrigClientes = new System.Windows.Forms.ContextMenu();
            this.menuEditar = new System.Windows.Forms.MenuItem();
            this.dataGridTableStyle = new System.Windows.Forms.DataGridTableStyle();
            this.dgtxtiIdCliente = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dgtxtsIdCliente = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dgtxtNombre = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dgtxtsIdTipoRelacionCliCen = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dgtxtsLiteral = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dgtxtAccion = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dgtxtsIdred = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dgtxtRed = new System.Windows.Forms.DataGridTextBoxColumn();
            this.pnAsociarClientes = new System.Windows.Forms.Panel();
            this.txbiIdCliente = new System.Windows.Forms.TextBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.cboRelecionConElCentro = new System.Windows.Forms.ComboBox();
            this.lblRelecionConElCentro = new System.Windows.Forms.Label();
            this.txtClienteSAP = new System.Windows.Forms.TextBox();
            this.btBuscarCliente = new System.Windows.Forms.Button();
            this.txtsCliente = new System.Windows.Forms.TextBox();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.sqlConn = new System.Data.SqlClient.SqlConnection();
            this.sqldaTipoCentro = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqldaListaTipoClasificacion = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand4 = new System.Data.SqlClient.SqlCommand();
            this.sqldaListaTipoSistemaInformatico = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
            this.sqldaListaTipoPoliticaPrescripcion = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
            this.sqldaListaTipoRelacionClienteCentro = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand5 = new System.Data.SqlClient.SqlCommand();
            this.sqldaListaCLientesCOM_Centros = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand6 = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdExisteCentroRedPropioCliente = new System.Data.SqlClient.SqlCommand();
            this.sqlcmdSetCentros = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdGetCentroIdTemp = new System.Data.SqlClient.SqlCommand();
            this.sqldaGetCentro = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand7 = new System.Data.SqlClient.SqlCommand();
            this.sqlcmdSetCentrosRedes = new System.Data.SqlClient.SqlCommand();
            this.sqlcmdSetCentrosClientesCOM = new System.Data.SqlClient.SqlCommand();
            this.sqlcmdSetCP_CLientes_BrickCLientes = new System.Data.SqlClient.SqlCommand();
            this.sqlcmdExisteCentroRed = new System.Data.SqlClient.SqlCommand();
            this.sqldaListaRedes = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCommand1 = new System.Data.SqlClient.SqlCommand();
            this.pnCentro.SuspendLayout();
            this.pnCombos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsAltaCentros)).BeginInit();
            this.pnClientes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCLientesCentros)).BeginInit();
            this.pnAsociarClientes.SuspendLayout();
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
            this.ucBotoneraSecundaria1.TabIndex = 36;
            // 
            // pnCentro
            // 
            this.pnCentro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnCentro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnCentro.Controls.Add(this.pnCombos);
            this.pnCentro.Controls.Add(this.cboClasificacion);
            this.pnCentro.Controls.Add(this.txbFax);
            this.pnCentro.Controls.Add(this.lblFax);
            this.pnCentro.Controls.Add(this.txbTelefono);
            this.pnCentro.Controls.Add(this.lblTelefono);
            this.pnCentro.Controls.Add(this.lblClasificacion);
            this.pnCentro.Controls.Add(this.lblProvincia);
            this.pnCentro.Controls.Add(this.txbProvincia);
            this.pnCentro.Controls.Add(this.txbBickIMS);
            this.pnCentro.Controls.Add(this.lblBricksIMS);
            this.pnCentro.Controls.Add(this.txbDireccionCentro);
            this.pnCentro.Controls.Add(this.lblDireccion);
            this.pnCentro.Controls.Add(this.labelGradient1);
            this.pnCentro.Controls.Add(this.txtCodPostal);
            this.pnCentro.Controls.Add(this.lblCodPostal);
            this.pnCentro.Controls.Add(this.txbNomCentro);
            this.pnCentro.Controls.Add(this.lblNombreCentro);
            this.pnCentro.Controls.Add(this.btnBuscPob);
            this.pnCentro.Controls.Add(this.txbBPoblacion);
            this.pnCentro.Controls.Add(this.lblPoblacion);
            this.pnCentro.Controls.Add(this.cboTipoCentro);
            this.pnCentro.Controls.Add(this.lblTipoCentro);
            this.pnCentro.Controls.Add(this.txbIdPoblacion);
            this.pnCentro.Location = new System.Drawing.Point(2, 38);
            this.pnCentro.Name = "pnCentro";
            this.pnCentro.Size = new System.Drawing.Size(1255, 120);
            this.pnCentro.TabIndex = 37;
            // 
            // pnCombos
            // 
            this.pnCombos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnCombos.Controls.Add(this.cboPactoPrescripcion);
            this.pnCombos.Controls.Add(this.lblPactoPrescripcion);
            this.pnCombos.Controls.Add(this.cboPoliticaPrescripcion);
            this.pnCombos.Controls.Add(this.lblPolitica);
            this.pnCombos.Controls.Add(this.cboVisitaColectiva);
            this.pnCombos.Controls.Add(this.lblVisitaColoectiva);
            this.pnCombos.Controls.Add(this.cboSistemaInformatico);
            this.pnCombos.Controls.Add(this.lblSistemaInformatico);
            this.pnCombos.Location = new System.Drawing.Point(4, 75);
            this.pnCombos.Name = "pnCombos";
            this.pnCombos.Size = new System.Drawing.Size(1246, 38);
            this.pnCombos.TabIndex = 98;
            // 
            // cboPactoPrescripcion
            // 
            this.cboPactoPrescripcion.DataSource = this.dsAltaCentros.ListaSiNo;
            this.cboPactoPrescripcion.DisplayMember = "sLiteral";
            this.cboPactoPrescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cboPactoPrescripcion.ForeColor = System.Drawing.Color.Black;
            this.cboPactoPrescripcion.ItemHeight = 13;
            this.cboPactoPrescripcion.Location = new System.Drawing.Point(110, 10);
            this.cboPactoPrescripcion.Name = "cboPactoPrescripcion";
            this.cboPactoPrescripcion.Size = new System.Drawing.Size(64, 21);
            this.cboPactoPrescripcion.TabIndex = 11;
            this.cboPactoPrescripcion.ValueMember = "sValor";
            // 
            // dsAltaCentros
            // 
            this.dsAltaCentros.DataSetName = "dsAltaCentros";
            this.dsAltaCentros.Locale = new System.Globalization.CultureInfo("es-ES");
            this.dsAltaCentros.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lblPactoPrescripcion
            // 
            this.lblPactoPrescripcion.AutoSize = true;
            this.lblPactoPrescripcion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblPactoPrescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblPactoPrescripcion.ForeColor = System.Drawing.Color.Black;
            this.lblPactoPrescripcion.Location = new System.Drawing.Point(4, 12);
            this.lblPactoPrescripcion.Name = "lblPactoPrescripcion";
            this.lblPactoPrescripcion.Size = new System.Drawing.Size(99, 13);
            this.lblPactoPrescripcion.TabIndex = 97;
            this.lblPactoPrescripcion.Text = "Pacto Prescripción:";
            // 
            // cboPoliticaPrescripcion
            // 
            this.cboPoliticaPrescripcion.DataSource = this.dsAltaCentros.ListaTipoPoliticaPrescripcion;
            this.cboPoliticaPrescripcion.DisplayMember = "sLiteral";
            this.cboPoliticaPrescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cboPoliticaPrescripcion.ForeColor = System.Drawing.Color.Black;
            this.cboPoliticaPrescripcion.ItemHeight = 13;
            this.cboPoliticaPrescripcion.Location = new System.Drawing.Point(312, 10);
            this.cboPoliticaPrescripcion.Name = "cboPoliticaPrescripcion";
            this.cboPoliticaPrescripcion.Size = new System.Drawing.Size(138, 21);
            this.cboPoliticaPrescripcion.TabIndex = 12;
            this.cboPoliticaPrescripcion.ValueMember = "sValor";
            // 
            // lblPolitica
            // 
            this.lblPolitica.AutoSize = true;
            this.lblPolitica.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblPolitica.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblPolitica.ForeColor = System.Drawing.Color.Black;
            this.lblPolitica.Location = new System.Drawing.Point(186, 12);
            this.lblPolitica.Name = "lblPolitica";
            this.lblPolitica.Size = new System.Drawing.Size(107, 13);
            this.lblPolitica.TabIndex = 99;
            this.lblPolitica.Text = "Política Prescripción:";
            // 
            // cboVisitaColectiva
            // 
            this.cboVisitaColectiva.DataSource = this.dsAltaCentros.ListaSiNob;
            this.cboVisitaColectiva.DisplayMember = "sLiteral";
            this.cboVisitaColectiva.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cboVisitaColectiva.ForeColor = System.Drawing.Color.Black;
            this.cboVisitaColectiva.ItemHeight = 13;
            this.cboVisitaColectiva.Location = new System.Drawing.Point(568, 10);
            this.cboVisitaColectiva.Name = "cboVisitaColectiva";
            this.cboVisitaColectiva.Size = new System.Drawing.Size(64, 21);
            this.cboVisitaColectiva.TabIndex = 13;
            this.cboVisitaColectiva.ValueMember = "sValor";
            // 
            // lblVisitaColoectiva
            // 
            this.lblVisitaColoectiva.AutoSize = true;
            this.lblVisitaColoectiva.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblVisitaColoectiva.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblVisitaColoectiva.ForeColor = System.Drawing.Color.Black;
            this.lblVisitaColoectiva.Location = new System.Drawing.Point(470, 12);
            this.lblVisitaColoectiva.Name = "lblVisitaColoectiva";
            this.lblVisitaColoectiva.Size = new System.Drawing.Size(82, 13);
            this.lblVisitaColoectiva.TabIndex = 101;
            this.lblVisitaColoectiva.Text = "Visita Colectiva:";
            // 
            // cboSistemaInformatico
            // 
            this.cboSistemaInformatico.DataSource = this.dsAltaCentros.ListaTipoSistemaInformatico;
            this.cboSistemaInformatico.DisplayMember = "sLiteral";
            this.cboSistemaInformatico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSistemaInformatico.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cboSistemaInformatico.ForeColor = System.Drawing.Color.Black;
            this.cboSistemaInformatico.ItemHeight = 13;
            this.cboSistemaInformatico.Location = new System.Drawing.Point(764, 10);
            this.cboSistemaInformatico.Name = "cboSistemaInformatico";
            this.cboSistemaInformatico.Size = new System.Drawing.Size(138, 21);
            this.cboSistemaInformatico.TabIndex = 14;
            this.cboSistemaInformatico.ValueMember = "sValor";
            // 
            // lblSistemaInformatico
            // 
            this.lblSistemaInformatico.AutoSize = true;
            this.lblSistemaInformatico.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblSistemaInformatico.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblSistemaInformatico.ForeColor = System.Drawing.Color.Black;
            this.lblSistemaInformatico.Location = new System.Drawing.Point(658, 12);
            this.lblSistemaInformatico.Name = "lblSistemaInformatico";
            this.lblSistemaInformatico.Size = new System.Drawing.Size(102, 13);
            this.lblSistemaInformatico.TabIndex = 103;
            this.lblSistemaInformatico.Text = "Sistema Informático:";
            // 
            // cboClasificacion
            // 
            this.cboClasificacion.DataSource = this.dsAltaCentros.ListaTipoClasificacion;
            this.cboClasificacion.DisplayMember = "sLiteral";
            this.cboClasificacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cboClasificacion.ForeColor = System.Drawing.Color.Black;
            this.cboClasificacion.ItemHeight = 13;
            this.cboClasificacion.Location = new System.Drawing.Point(1116, 50);
            this.cboClasificacion.Name = "cboClasificacion";
            this.cboClasificacion.Size = new System.Drawing.Size(121, 21);
            this.cboClasificacion.TabIndex = 8;
            this.cboClasificacion.ValueMember = "sValor";
            // 
            // txbFax
            // 
            this.txbFax.BackColor = System.Drawing.Color.White;
            this.txbFax.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txbFax.ForeColor = System.Drawing.Color.Black;
            this.txbFax.Location = new System.Drawing.Point(1057, 24);
            this.txbFax.MaxLength = 15;
            this.txbFax.Name = "txbFax";
            this.txbFax.Size = new System.Drawing.Size(180, 20);
            this.txbFax.TabIndex = 10;
            // 
            // lblFax
            // 
            this.lblFax.ForeColor = System.Drawing.Color.Black;
            this.lblFax.Location = new System.Drawing.Point(1026, 26);
            this.lblFax.Name = "lblFax";
            this.lblFax.Size = new System.Drawing.Size(30, 16);
            this.lblFax.TabIndex = 94;
            this.lblFax.Text = "Fax:";
            this.lblFax.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txbTelefono
            // 
            this.txbTelefono.BackColor = System.Drawing.Color.White;
            this.txbTelefono.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txbTelefono.ForeColor = System.Drawing.Color.Black;
            this.txbTelefono.Location = new System.Drawing.Point(855, 24);
            this.txbTelefono.MaxLength = 15;
            this.txbTelefono.Name = "txbTelefono";
            this.txbTelefono.Size = new System.Drawing.Size(152, 20);
            this.txbTelefono.TabIndex = 9;
            // 
            // lblTelefono
            // 
            this.lblTelefono.ForeColor = System.Drawing.Color.Black;
            this.lblTelefono.Location = new System.Drawing.Point(804, 26);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(52, 16);
            this.lblTelefono.TabIndex = 92;
            this.lblTelefono.Text = "Teléfono:";
            this.lblTelefono.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblClasificacion
            // 
            this.lblClasificacion.AutoSize = true;
            this.lblClasificacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblClasificacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblClasificacion.ForeColor = System.Drawing.Color.Black;
            this.lblClasificacion.Location = new System.Drawing.Point(1047, 52);
            this.lblClasificacion.Name = "lblClasificacion";
            this.lblClasificacion.Size = new System.Drawing.Size(69, 13);
            this.lblClasificacion.TabIndex = 90;
            this.lblClasificacion.Text = "Clasificación:";
            // 
            // lblProvincia
            // 
            this.lblProvincia.ForeColor = System.Drawing.Color.Black;
            this.lblProvincia.Location = new System.Drawing.Point(580, 50);
            this.lblProvincia.Name = "lblProvincia";
            this.lblProvincia.Size = new System.Drawing.Size(55, 16);
            this.lblProvincia.TabIndex = 88;
            this.lblProvincia.Text = "Provincia:";
            this.lblProvincia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txbProvincia
            // 
            this.txbProvincia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txbProvincia.ForeColor = System.Drawing.Color.Black;
            this.txbProvincia.Location = new System.Drawing.Point(638, 48);
            this.txbProvincia.MaxLength = 50;
            this.txbProvincia.Name = "txbProvincia";
            this.txbProvincia.ReadOnly = true;
            this.txbProvincia.Size = new System.Drawing.Size(161, 20);
            this.txbProvincia.TabIndex = 6;
            // 
            // txbBickIMS
            // 
            this.txbBickIMS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txbBickIMS.ForeColor = System.Drawing.Color.Black;
            this.txbBickIMS.Location = new System.Drawing.Point(69, 48);
            this.txbBickIMS.MaxLength = 10;
            this.txbBickIMS.Name = "txbBickIMS";
            this.txbBickIMS.ReadOnly = true;
            this.txbBickIMS.Size = new System.Drawing.Size(72, 20);
            this.txbBickIMS.TabIndex = 2;
            // 
            // lblBricksIMS
            // 
            this.lblBricksIMS.ForeColor = System.Drawing.Color.Black;
            this.lblBricksIMS.Location = new System.Drawing.Point(6, 50);
            this.lblBricksIMS.Name = "lblBricksIMS";
            this.lblBricksIMS.Size = new System.Drawing.Size(56, 16);
            this.lblBricksIMS.TabIndex = 86;
            this.lblBricksIMS.Text = "Brick IMS:";
            this.lblBricksIMS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txbDireccionCentro
            // 
            this.txbDireccionCentro.BackColor = System.Drawing.Color.White;
            this.txbDireccionCentro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txbDireccionCentro.ForeColor = System.Drawing.Color.Black;
            this.txbDireccionCentro.Location = new System.Drawing.Point(395, 24);
            this.txbDireccionCentro.MaxLength = 100;
            this.txbDireccionCentro.Name = "txbDireccionCentro";
            this.txbDireccionCentro.Size = new System.Drawing.Size(393, 20);
            this.txbDireccionCentro.TabIndex = 1;
            this.txbDireccionCentro.Tag = "*";
            // 
            // lblDireccion
            // 
            this.lblDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDireccion.ForeColor = System.Drawing.Color.Blue;
            this.lblDireccion.Location = new System.Drawing.Point(324, 26);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(65, 16);
            this.lblDireccion.TabIndex = 84;
            this.lblDireccion.Text = "Dirección:";
            this.lblDireccion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.labelGradient1.Size = new System.Drawing.Size(1253, 22);
            this.labelGradient1.TabIndex = 82;
            this.labelGradient1.Text = "Alta de Centros";
            // 
            // txtCodPostal
            // 
            this.txtCodPostal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtCodPostal.ForeColor = System.Drawing.Color.Black;
            this.txtCodPostal.Location = new System.Drawing.Point(179, 48);
            this.txtCodPostal.MaxLength = 5;
            this.txtCodPostal.Name = "txtCodPostal";
            this.txtCodPostal.ReadOnly = true;
            this.txtCodPostal.Size = new System.Drawing.Size(72, 20);
            this.txtCodPostal.TabIndex = 3;
            this.txtCodPostal.Tag = "*";
            // 
            // lblCodPostal
            // 
            this.lblCodPostal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodPostal.ForeColor = System.Drawing.Color.Blue;
            this.lblCodPostal.Location = new System.Drawing.Point(147, 50);
            this.lblCodPostal.Name = "lblCodPostal";
            this.lblCodPostal.Size = new System.Drawing.Size(32, 16);
            this.lblCodPostal.TabIndex = 81;
            this.lblCodPostal.Text = "C.P.:";
            this.lblCodPostal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txbNomCentro
            // 
            this.txbNomCentro.BackColor = System.Drawing.Color.White;
            this.txbNomCentro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txbNomCentro.ForeColor = System.Drawing.Color.Black;
            this.txbNomCentro.Location = new System.Drawing.Point(68, 24);
            this.txbNomCentro.MaxLength = 100;
            this.txbNomCentro.Name = "txbNomCentro";
            this.txbNomCentro.Size = new System.Drawing.Size(242, 20);
            this.txbNomCentro.TabIndex = 0;
            this.txbNomCentro.Tag = "*";
            // 
            // lblNombreCentro
            // 
            this.lblNombreCentro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreCentro.ForeColor = System.Drawing.Color.Blue;
            this.lblNombreCentro.Location = new System.Drawing.Point(6, 24);
            this.lblNombreCentro.Name = "lblNombreCentro";
            this.lblNombreCentro.Size = new System.Drawing.Size(56, 20);
            this.lblNombreCentro.TabIndex = 78;
            this.lblNombreCentro.Text = "Nombre:";
            this.lblNombreCentro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnBuscPob
            // 
            this.btnBuscPob.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscPob.Image")));
            this.btnBuscPob.Location = new System.Drawing.Point(550, 48);
            this.btnBuscPob.Name = "btnBuscPob";
            this.btnBuscPob.Size = new System.Drawing.Size(20, 20);
            this.btnBuscPob.TabIndex = 5;
            this.btnBuscPob.Click += new System.EventHandler(this.btnBuscPob_Click);
            // 
            // txbBPoblacion
            // 
            this.txbBPoblacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txbBPoblacion.ForeColor = System.Drawing.Color.Black;
            this.txbBPoblacion.Location = new System.Drawing.Point(325, 48);
            this.txbBPoblacion.MaxLength = 50;
            this.txbBPoblacion.Name = "txbBPoblacion";
            this.txbBPoblacion.ReadOnly = true;
            this.txbBPoblacion.Size = new System.Drawing.Size(221, 20);
            this.txbBPoblacion.TabIndex = 4;
            // 
            // lblPoblacion
            // 
            this.lblPoblacion.ForeColor = System.Drawing.Color.Black;
            this.lblPoblacion.Location = new System.Drawing.Point(262, 50);
            this.lblPoblacion.Name = "lblPoblacion";
            this.lblPoblacion.Size = new System.Drawing.Size(64, 16);
            this.lblPoblacion.TabIndex = 69;
            this.lblPoblacion.Text = "Poblacion:";
            this.lblPoblacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboTipoCentro
            // 
            this.cboTipoCentro.DataSource = this.dsAltaCentros.ListaTipoCentro;
            this.cboTipoCentro.DisplayMember = "sLiteral";
            this.cboTipoCentro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cboTipoCentro.ForeColor = System.Drawing.Color.Black;
            this.cboTipoCentro.ItemHeight = 13;
            this.cboTipoCentro.Location = new System.Drawing.Point(841, 50);
            this.cboTipoCentro.Name = "cboTipoCentro";
            this.cboTipoCentro.Size = new System.Drawing.Size(198, 21);
            this.cboTipoCentro.TabIndex = 7;
            this.cboTipoCentro.ValueMember = "sValor";
            // 
            // lblTipoCentro
            // 
            this.lblTipoCentro.AutoSize = true;
            this.lblTipoCentro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblTipoCentro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblTipoCentro.ForeColor = System.Drawing.Color.Black;
            this.lblTipoCentro.Location = new System.Drawing.Point(808, 52);
            this.lblTipoCentro.Name = "lblTipoCentro";
            this.lblTipoCentro.Size = new System.Drawing.Size(31, 13);
            this.lblTipoCentro.TabIndex = 1;
            this.lblTipoCentro.Text = "Tipo:";
            // 
            // txbIdPoblacion
            // 
            this.txbIdPoblacion.BackColor = System.Drawing.Color.White;
            this.txbIdPoblacion.ForeColor = System.Drawing.Color.Black;
            this.txbIdPoblacion.Location = new System.Drawing.Point(428, 48);
            this.txbIdPoblacion.Name = "txbIdPoblacion";
            this.txbIdPoblacion.Size = new System.Drawing.Size(72, 20);
            this.txbIdPoblacion.TabIndex = 7;
            this.txbIdPoblacion.Visible = false;
            // 
            // pnClientes
            // 
            this.pnClientes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnClientes.Controls.Add(this.lblNumRegistros);
            this.pnClientes.Controls.Add(this.labelGradient2);
            this.pnClientes.Controls.Add(this.dgCLientesCentros);
            this.pnClientes.Location = new System.Drawing.Point(4, 162);
            this.pnClientes.Name = "pnClientes";
            this.pnClientes.Size = new System.Drawing.Size(1255, 427);
            this.pnClientes.TabIndex = 38;
            // 
            // lblNumRegistros
            // 
            this.lblNumRegistros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.lblNumRegistros.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblNumRegistros.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumRegistros.ForeColor = System.Drawing.Color.Black;
            this.lblNumRegistros.Location = new System.Drawing.Point(1190, 0);
            this.lblNumRegistros.Name = "lblNumRegistros";
            this.lblNumRegistros.Size = new System.Drawing.Size(60, 18);
            this.lblNumRegistros.TabIndex = 84;
            this.lblNumRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.labelGradient2.Size = new System.Drawing.Size(1251, 18);
            this.labelGradient2.TabIndex = 83;
            this.labelGradient2.Text = "Clientes";
            this.labelGradient2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgCLientesCentros
            // 
            this.dgCLientesCentros.BackgroundColor = System.Drawing.Color.White;
            this.dgCLientesCentros.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.dgCLientesCentros.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgCLientesCentros.CaptionForeColor = System.Drawing.Color.White;
            this.dgCLientesCentros.CaptionVisible = false;
            this.dgCLientesCentros.ContextMenu = this.contextMenuGrigClientes;
            this.dgCLientesCentros.DataMember = "ListaClientesCOM_Centros";
            this.dgCLientesCentros.DataSource = this.dsAltaCentros;
            this.dgCLientesCentros.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.dgCLientesCentros.ForeColor = System.Drawing.Color.Black;
            this.dgCLientesCentros.HeaderBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgCLientesCentros.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgCLientesCentros.Location = new System.Drawing.Point(0, 18);
            this.dgCLientesCentros.Name = "dgCLientesCentros";
            this.dgCLientesCentros.ParentRowsBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgCLientesCentros.ReadOnly = true;
            this.dgCLientesCentros.RowHeaderWidth = 30;
            this.dgCLientesCentros.Size = new System.Drawing.Size(1250, 404);
            this.dgCLientesCentros.TabIndex = 15;
            this.dgCLientesCentros.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle});
            this.dgCLientesCentros.DoubleClick += new System.EventHandler(this.dgCLientesCentros_DoubleClick);
            // 
            // contextMenuGrigClientes
            // 
            this.contextMenuGrigClientes.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuEditar});
            // 
            // menuEditar
            // 
            this.menuEditar.Index = 0;
            this.menuEditar.Shortcut = System.Windows.Forms.Shortcut.CtrlE;
            this.menuEditar.Text = "Editar";
            this.menuEditar.Click += new System.EventHandler(this.menuEditar_Click);
            // 
            // dataGridTableStyle
            // 
            this.dataGridTableStyle.DataGrid = this.dgCLientesCentros;
            this.dataGridTableStyle.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dgtxtiIdCliente,
            this.dgtxtsIdCliente,
            this.dgtxtNombre,
            this.dgtxtsIdTipoRelacionCliCen,
            this.dgtxtsLiteral,
            this.dgtxtAccion,
            this.dgtxtsIdred,
            this.dgtxtRed});
            this.dataGridTableStyle.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle.MappingName = "ListaClientesCOM_Centros";
            this.dataGridTableStyle.RowHeaderWidth = 30;
            // 
            // dgtxtiIdCliente
            // 
            this.dgtxtiIdCliente.Format = "";
            this.dgtxtiIdCliente.FormatInfo = null;
            this.dgtxtiIdCliente.HeaderText = "Código Cliente";
            this.dgtxtiIdCliente.MappingName = "iIdCliente";
            this.dgtxtiIdCliente.ReadOnly = true;
            this.dgtxtiIdCliente.Width = 0;
            // 
            // dgtxtsIdCliente
            // 
            this.dgtxtsIdCliente.Format = "";
            this.dgtxtsIdCliente.FormatInfo = null;
            this.dgtxtsIdCliente.HeaderText = "Código Cliente";
            this.dgtxtsIdCliente.MappingName = "sIdCliente";
            this.dgtxtsIdCliente.ReadOnly = true;
            this.dgtxtsIdCliente.Width = 150;
            // 
            // dgtxtNombre
            // 
            this.dgtxtNombre.Format = "";
            this.dgtxtNombre.FormatInfo = null;
            this.dgtxtNombre.HeaderText = "Nombre";
            this.dgtxtNombre.MappingName = "tNombre";
            this.dgtxtNombre.ReadOnly = true;
            this.dgtxtNombre.Width = 500;
            // 
            // dgtxtsIdTipoRelacionCliCen
            // 
            this.dgtxtsIdTipoRelacionCliCen.Format = "";
            this.dgtxtsIdTipoRelacionCliCen.FormatInfo = null;
            this.dgtxtsIdTipoRelacionCliCen.MappingName = "sIdTipoRelacionCliCen";
            this.dgtxtsIdTipoRelacionCliCen.ReadOnly = true;
            this.dgtxtsIdTipoRelacionCliCen.Width = 0;
            // 
            // dgtxtsLiteral
            // 
            this.dgtxtsLiteral.Format = "";
            this.dgtxtsLiteral.FormatInfo = null;
            this.dgtxtsLiteral.HeaderText = "Tipo Relación Cliente";
            this.dgtxtsLiteral.MappingName = "sLiteral";
            this.dgtxtsLiteral.ReadOnly = true;
            this.dgtxtsLiteral.Width = 150;
            // 
            // dgtxtAccion
            // 
            this.dgtxtAccion.Format = "";
            this.dgtxtAccion.FormatInfo = null;
            this.dgtxtAccion.MappingName = "Accion";
            this.dgtxtAccion.Width = 0;
            // 
            // dgtxtsIdred
            // 
            this.dgtxtsIdred.Format = "";
            this.dgtxtsIdred.FormatInfo = null;
            this.dgtxtsIdred.MappingName = "sIdRed";
            this.dgtxtsIdred.Width = 0;
            // 
            // dgtxtRed
            // 
            this.dgtxtRed.Format = "";
            this.dgtxtRed.FormatInfo = null;
            this.dgtxtRed.HeaderText = "Red";
            this.dgtxtRed.MappingName = "Red";
            this.dgtxtRed.Width = 75;
            // 
            // pnAsociarClientes
            // 
            this.pnAsociarClientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnAsociarClientes.Controls.Add(this.txbiIdCliente);
            this.pnAsociarClientes.Controls.Add(this.lblCliente);
            this.pnAsociarClientes.Controls.Add(this.cboRelecionConElCentro);
            this.pnAsociarClientes.Controls.Add(this.lblRelecionConElCentro);
            this.pnAsociarClientes.Controls.Add(this.txtClienteSAP);
            this.pnAsociarClientes.Controls.Add(this.btBuscarCliente);
            this.pnAsociarClientes.Controls.Add(this.txtsCliente);
            this.pnAsociarClientes.Controls.Add(this.btnEliminar);
            this.pnAsociarClientes.Controls.Add(this.btnActualizar);
            this.pnAsociarClientes.Location = new System.Drawing.Point(4, 589);
            this.pnAsociarClientes.Name = "pnAsociarClientes";
            this.pnAsociarClientes.Size = new System.Drawing.Size(1253, 36);
            this.pnAsociarClientes.TabIndex = 104;
            // 
            // txbiIdCliente
            // 
            this.txbiIdCliente.BackColor = System.Drawing.Color.White;
            this.txbiIdCliente.ForeColor = System.Drawing.Color.Black;
            this.txbiIdCliente.Location = new System.Drawing.Point(882, 8);
            this.txbiIdCliente.MaxLength = 20;
            this.txbiIdCliente.Name = "txbiIdCliente";
            this.txbiIdCliente.Size = new System.Drawing.Size(34, 20);
            this.txbiIdCliente.TabIndex = 112;
            this.txbiIdCliente.Visible = false;
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblCliente.ForeColor = System.Drawing.Color.Black;
            this.lblCliente.Location = new System.Drawing.Point(166, 9);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(42, 13);
            this.lblCliente.TabIndex = 111;
            this.lblCliente.Text = "Cliente:";
            // 
            // cboRelecionConElCentro
            // 
            this.cboRelecionConElCentro.DataSource = this.dsAltaCentros.ListaTipoRelacionClienteCentro;
            this.cboRelecionConElCentro.DisplayMember = "sLiteral";
            this.cboRelecionConElCentro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cboRelecionConElCentro.ForeColor = System.Drawing.Color.Black;
            this.cboRelecionConElCentro.ItemHeight = 13;
            this.cboRelecionConElCentro.Location = new System.Drawing.Point(670, 7);
            this.cboRelecionConElCentro.Name = "cboRelecionConElCentro";
            this.cboRelecionConElCentro.Size = new System.Drawing.Size(138, 21);
            this.cboRelecionConElCentro.TabIndex = 108;
            this.cboRelecionConElCentro.ValueMember = "sValor";
            // 
            // lblRelecionConElCentro
            // 
            this.lblRelecionConElCentro.AutoSize = true;
            this.lblRelecionConElCentro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblRelecionConElCentro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblRelecionConElCentro.ForeColor = System.Drawing.Color.Black;
            this.lblRelecionConElCentro.Location = new System.Drawing.Point(548, 9);
            this.lblRelecionConElCentro.Name = "lblRelecionConElCentro";
            this.lblRelecionConElCentro.Size = new System.Drawing.Size(118, 13);
            this.lblRelecionConElCentro.TabIndex = 110;
            this.lblRelecionConElCentro.Text = "Releción con el Centro:";
            // 
            // txtClienteSAP
            // 
            this.txtClienteSAP.BackColor = System.Drawing.Color.White;
            this.txtClienteSAP.ForeColor = System.Drawing.Color.Black;
            this.txtClienteSAP.Location = new System.Drawing.Point(218, 7);
            this.txtClienteSAP.MaxLength = 20;
            this.txtClienteSAP.Name = "txtClienteSAP";
            this.txtClienteSAP.Size = new System.Drawing.Size(96, 20);
            this.txtClienteSAP.TabIndex = 106;
            this.txtClienteSAP.Leave += new System.EventHandler(this.txtClienteSAP_Leave);
            // 
            // btBuscarCliente
            // 
            this.btBuscarCliente.Image = ((System.Drawing.Image)(resources.GetObject("btBuscarCliente.Image")));
            this.btBuscarCliente.Location = new System.Drawing.Point(514, 7);
            this.btBuscarCliente.Name = "btBuscarCliente";
            this.btBuscarCliente.Size = new System.Drawing.Size(20, 20);
            this.btBuscarCliente.TabIndex = 107;
            this.btBuscarCliente.TabStop = false;
            this.btBuscarCliente.UseVisualStyleBackColor = true;
            this.btBuscarCliente.Click += new System.EventHandler(this.btBuscarCliente_Click);
            // 
            // txtsCliente
            // 
            this.txtsCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtsCliente.ForeColor = System.Drawing.Color.Black;
            this.txtsCliente.Location = new System.Drawing.Point(314, 7);
            this.txtsCliente.Name = "txtsCliente";
            this.txtsCliente.ReadOnly = true;
            this.txtsCliente.Size = new System.Drawing.Size(192, 20);
            this.txtsCliente.TabIndex = 109;
            this.txtsCliente.TabStop = false;
            // 
            // btnEliminar
            // 
            this.btnEliminar.ForeColor = System.Drawing.Color.Black;
            this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar.Location = new System.Drawing.Point(86, 7);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 105;
            this.btnEliminar.Text = "&Eliminar";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.ForeColor = System.Drawing.Color.Black;
            this.btnActualizar.Image = ((System.Drawing.Image)(resources.GetObject("btnActualizar.Image")));
            this.btnActualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnActualizar.Location = new System.Drawing.Point(6, 7);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(80, 23);
            this.btnActualizar.TabIndex = 104;
            this.btnActualizar.Text = "&Actualizar";
            this.btnActualizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // sqlConn
            // 
            this.sqlConn.FireInfoMessageEventOnUserErrors = false;
            // 
            // sqldaTipoCentro
            // 
            this.sqldaTipoCentro.SelectCommand = this.sqlSelectCommand1;
            this.sqldaTipoCentro.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaTipoCentro", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("sValor", "sValor"),
                        new System.Data.Common.DataColumnMapping("sLiteral", "sLiteral")})});
            // 
            // sqlSelectCommand1
            // 
            this.sqlSelectCommand1.CommandText = "[ListaTipoCentro]";
            this.sqlSelectCommand1.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand1.Connection = this.sqlConn;
            this.sqlSelectCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
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
            // sqldaListaTipoSistemaInformatico
            // 
            this.sqldaListaTipoSistemaInformatico.SelectCommand = this.sqlSelectCommand2;
            this.sqldaListaTipoSistemaInformatico.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaTipoSistemaInformatico", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("sValor", "sValor"),
                        new System.Data.Common.DataColumnMapping("sLiteral", "sLiteral")})});
            // 
            // sqlSelectCommand2
            // 
            this.sqlSelectCommand2.CommandText = "[ListaTipoSistemaInformatico]";
            this.sqlSelectCommand2.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand2.Connection = this.sqlConn;
            this.sqlSelectCommand2.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null)});
            // 
            // sqldaListaTipoPoliticaPrescripcion
            // 
            this.sqldaListaTipoPoliticaPrescripcion.SelectCommand = this.sqlSelectCommand3;
            this.sqldaListaTipoPoliticaPrescripcion.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaTipoPoliticaPrescripcion", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("sValor", "sValor"),
                        new System.Data.Common.DataColumnMapping("sLiteral", "sLiteral")})});
            // 
            // sqlSelectCommand3
            // 
            this.sqlSelectCommand3.CommandText = "[ListaTipoPoliticaPrescripcion]";
            this.sqlSelectCommand3.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand3.Connection = this.sqlConn;
            this.sqlSelectCommand3.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null)});
            // 
            // sqldaListaTipoRelacionClienteCentro
            // 
            this.sqldaListaTipoRelacionClienteCentro.SelectCommand = this.sqlSelectCommand5;
            this.sqldaListaTipoRelacionClienteCentro.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaTipoRelacionClienteCentro", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("sValor", "sValor"),
                        new System.Data.Common.DataColumnMapping("sLiteral", "sLiteral")})});
            // 
            // sqlSelectCommand5
            // 
            this.sqlSelectCommand5.CommandText = "[ListaTipoRelacionClienteCentro]";
            this.sqlSelectCommand5.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand5.Connection = this.sqlConn;
            this.sqlSelectCommand5.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null)});
            // 
            // sqldaListaCLientesCOM_Centros
            // 
            this.sqldaListaCLientesCOM_Centros.SelectCommand = this.sqlSelectCommand6;
            this.sqldaListaCLientesCOM_Centros.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaClientesCOM_Centros", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iIdCliente", "iIdCliente"),
                        new System.Data.Common.DataColumnMapping("sIdCliente", "sIdCliente"),
                        new System.Data.Common.DataColumnMapping("tNombre", "tNombre"),
                        new System.Data.Common.DataColumnMapping("sIdTipoRelacionCliCen", "sIdTipoRelacionCliCen"),
                        new System.Data.Common.DataColumnMapping("sLiteral", "sLiteral")})});
            // 
            // sqlSelectCommand6
            // 
            this.sqlSelectCommand6.CommandText = "[ListaClientesCOM_Centros]";
            this.sqlSelectCommand6.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand6.Connection = this.sqlConn;
            this.sqlSelectCommand6.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdCentro", System.Data.SqlDbType.Int, 4)});
            // 
            // sqlCmdExisteCentroRedPropioCliente
            // 
            this.sqlCmdExisteCentroRedPropioCliente.CommandText = "[ExisteCentroRedPropioCliente]";
            this.sqlCmdExisteCentroRedPropioCliente.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdExisteCentroRedPropioCliente.Connection = this.sqlConn;
            this.sqlCmdExisteCentroRedPropioCliente.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@iIdCentro", System.Data.SqlDbType.Int),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int),
            new System.Data.SqlClient.SqlParameter("@sIdRed", System.Data.SqlDbType.VarChar, 4)});
            // 
            // sqlcmdSetCentros
            // 
            this.sqlcmdSetCentros.CommandText = "[SetCentros]";
            this.sqlcmdSetCentros.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlcmdSetCentros.Connection = this.sqlConn;
            this.sqlcmdSetCentros.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iAccion", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdCentro", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sIdCentro", System.Data.SqlDbType.VarChar, 20),
            new System.Data.SqlClient.SqlParameter("@sIdCentroTemp", System.Data.SqlDbType.VarChar, 20),
            new System.Data.SqlClient.SqlParameter("@sIdTipoCentro", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@sDescripcion", System.Data.SqlDbType.VarChar, 100),
            new System.Data.SqlClient.SqlParameter("@sDireccion", System.Data.SqlDbType.VarChar, 100),
            new System.Data.SqlClient.SqlParameter("@iIdPoblacion", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sFax", System.Data.SqlDbType.VarChar, 15),
            new System.Data.SqlClient.SqlParameter("@sTelefono", System.Data.SqlDbType.VarChar, 15),
            new System.Data.SqlClient.SqlParameter("@sIdPolPrescripcion", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@sIdTipoClasificacion", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@sIdSistInformatico", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@bPactoPrescripcion", System.Data.SqlDbType.Bit, 1),
            new System.Data.SqlClient.SqlParameter("@bVisitaColectiva", System.Data.SqlDbType.Bit, 1),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt, 2),
            new System.Data.SqlClient.SqlParameter("@sIdRed", System.Data.SqlDbType.VarChar, 4)});
            // 
            // sqlCmdGetCentroIdTemp
            // 
            this.sqlCmdGetCentroIdTemp.CommandText = "[GetCentroIdTemp]";
            this.sqlCmdGetCentroIdTemp.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdGetCentroIdTemp.Connection = this.sqlConn;
            this.sqlCmdGetCentroIdTemp.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdDelegado", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@theDate", System.Data.SqlDbType.DateTime, 8)});
            // 
            // sqldaGetCentro
            // 
            this.sqldaGetCentro.SelectCommand = this.sqlSelectCommand7;
            this.sqldaGetCentro.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "GetCentro", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("sIdCentro", "sIdCentro"),
                        new System.Data.Common.DataColumnMapping("sIdCentroTemp", "sIdCentroTemp"),
                        new System.Data.Common.DataColumnMapping("sIdTipoCentro", "sIdTipoCentro"),
                        new System.Data.Common.DataColumnMapping("sDescripcion", "sDescripcion"),
                        new System.Data.Common.DataColumnMapping("sDireccion", "sDireccion"),
                        new System.Data.Common.DataColumnMapping("iIdPoblacion", "iIdPoblacion"),
                        new System.Data.Common.DataColumnMapping("sFax", "sFax"),
                        new System.Data.Common.DataColumnMapping("sTelefono", "sTelefono"),
                        new System.Data.Common.DataColumnMapping("sIdPolPrescripcion", "sIdPolPrescripcion"),
                        new System.Data.Common.DataColumnMapping("sIdTipoClasificacion", "sIdTipoClasificacion"),
                        new System.Data.Common.DataColumnMapping("sIdSistInformatico", "sIdSistInformatico"),
                        new System.Data.Common.DataColumnMapping("bPactoPrescripcion", "bPactoPrescripcion"),
                        new System.Data.Common.DataColumnMapping("bVisitaColectiva", "bVisitaColectiva"),
                        new System.Data.Common.DataColumnMapping("dFUM", "dFUM"),
                        new System.Data.Common.DataColumnMapping("iEstado", "iEstado"),
                        new System.Data.Common.DataColumnMapping("bEnviadoPDA", "bEnviadoPDA"),
                        new System.Data.Common.DataColumnMapping("bEnviadoCEN", "bEnviadoCEN")})});
            // 
            // sqlSelectCommand7
            // 
            this.sqlSelectCommand7.CommandText = "[GetCentro]";
            this.sqlSelectCommand7.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand7.Connection = this.sqlConn;
            this.sqlSelectCommand7.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdCentro", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sIdRed", System.Data.SqlDbType.VarChar, 4)});
            // 
            // sqlcmdSetCentrosRedes
            // 
            this.sqlcmdSetCentrosRedes.CommandText = "[SetCentrosRedes]";
            this.sqlcmdSetCentrosRedes.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlcmdSetCentrosRedes.Connection = this.sqlConn;
            this.sqlcmdSetCentrosRedes.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdCentro", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sIdRed", System.Data.SqlDbType.VarChar, 4),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt, 2)});
            // 
            // sqlcmdSetCentrosClientesCOM
            // 
            this.sqlcmdSetCentrosClientesCOM.CommandText = "[SetCentrosClientesCOM]";
            this.sqlcmdSetCentrosClientesCOM.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlcmdSetCentrosClientesCOM.Connection = this.sqlConn;
            this.sqlcmdSetCentrosClientesCOM.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iAccion", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdCentro", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sIdTipoRelacionCliCen", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@sIdRed", System.Data.SqlDbType.VarChar, 4)});
            // 
            // sqlcmdSetCP_CLientes_BrickCLientes
            // 
            this.sqlcmdSetCP_CLientes_BrickCLientes.CommandText = "[SetCP_CLientes_BrickCLientes]";
            this.sqlcmdSetCP_CLientes_BrickCLientes.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlcmdSetCP_CLientes_BrickCLientes.Connection = this.sqlConn;
            this.sqlcmdSetCP_CLientes_BrickCLientes.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIDPoblacion", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sCodPostal", System.Data.SqlDbType.VarChar, 5),
            new System.Data.SqlClient.SqlParameter("@iIDCLiente", System.Data.SqlDbType.Int, 4)});
            // 
            // sqlcmdExisteCentroRed
            // 
            this.sqlcmdExisteCentroRed.CommandText = "[ExisteCentroRed]";
            this.sqlcmdExisteCentroRed.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlcmdExisteCentroRed.Connection = this.sqlConn;
            this.sqlcmdExisteCentroRed.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdCentro", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sIdRed", System.Data.SqlDbType.VarChar, 4)});
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
            // frmAltaCentros
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.ClientSize = new System.Drawing.Size(1263, 656);
            this.Controls.Add(this.pnAsociarClientes);
            this.Controls.Add(this.pnClientes);
            this.Controls.Add(this.pnCentro);
            this.Controls.Add(this.ucBotoneraSecundaria1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmAltaCentros";
            this.Text = "Alta Centros";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmAltaCentros_Load);
            this.pnCentro.ResumeLayout(false);
            this.pnCentro.PerformLayout();
            this.pnCombos.ResumeLayout(false);
            this.pnCombos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsAltaCentros)).EndInit();
            this.pnClientes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgCLientesCentros)).EndInit();
            this.pnAsociarClientes.ResumeLayout(false);
            this.pnAsociarClientes.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion
		/// <summary>
		/// Se encarga de inicializar el mantenimiento Alta Centros
		/// Se inicializaran combos, grids etc.
		/// </summary>
		private void InicializaAltaCentros()
		{
			Utiles.Formato_Formulario(this);
			Application.DoEvents();
			InicializaComboTipo();
			InizalizaComboClasificacion();
			InicializaListaSino();
			InicicilizaComboPoliticaPrescripcion();
			InicicilizaComboSistemaInformatico();
			InicicilizaComboTipoRelacionClienteCentro();
			GESTCRM.Utiles.Formatear_DataGrid(this.dgCLientesCentros,null,this.contextMenuGrigClientes);
			this.sqldaListaRedes.Fill(this.dsAltaCentros.ListaRedes);

		}
		#region Obtener IdCentro
		/// <summary>
		/// Obtine el identificador del centro
		/// </summary>
		/// <returns>true si es corrcto</returns>
		private bool ObteneriIdCentro()
		{
			bool bOk = false;
			try
			{
                //---- GSG (10/09/2014)
                //sqlConn.Open();
                if (sqlConn.State == ConnectionState.Closed)
                    sqlConn.Open();


				sqlCmdGetCentroIdTemp.Parameters["@iIdDelegado"].Value = Clases.Configuracion.iIdDelegado;
				sqlCmdGetCentroIdTemp.Parameters["@theDate"].Value = DateTime.Now;
				sIdCentro = (string) sqlCmdGetCentroIdTemp.ExecuteScalar();
				bOk = true;
			}
			catch( Exception Ex)
			{
				//MessageBox.Show ("Error en ObteneriIdCentro "+ Ex.ToString());
                Mensajes.ShowError("Error en ObteneriIdCentro: " + Ex.ToString());
			}
			finally
			{
				sqlConn.Close();
			}
			return bOk ;
		}
		#endregion

		#region Iniciliza combos
		/// <summary>
		/// Inicializa Combo Tipo.
		/// </summary>
		private void InicializaComboTipo()
		{
			try
			{
				this.sqldaTipoCentro.Fill(this.dsAltaCentros);
				DataRow filaNA = this.dsAltaCentros.ListaTipoCentro.NewRow();
				filaNA["sValor"]="N/A";
				filaNA["sLiteral"]="No Asignado";
				this.dsAltaCentros.ListaTipoCentro.Rows.InsertAt(filaNA,0);
				cboTipoCentro.SelectedValue="1";
				
			}
			catch (Exception ex)
			{
				Mensajes.ShowError(ex.Message);
			}
		}
		/// <summary>
		/// Inicializa combo clasificacion. 
		/// </summary>
		private void InizalizaComboClasificacion()
		{
			this.sqldaListaTipoClasificacion.Fill(this.dsAltaCentros);
			DataRow filaNA = this.dsAltaCentros.ListaTipoClasificacion.NewRow();
			filaNA["sValor"]="N/A";
			filaNA["sLiteral"]="No Clasificado";
			this.dsAltaCentros.ListaTipoClasificacion.Rows.InsertAt(filaNA,0);
			this.cboClasificacion.SelectedValue="N/A";
		}
		/// <summary>
		/// Inicizliza combo Pacto Prescripcion
		/// </summary>
		private void InicializaListaSino()
		{
			DataRow filaNA = this.dsAltaCentros.ListaSiNo.NewRow();
			DataRow filaNAb = this.dsAltaCentros.ListaSiNob.NewRow();

			filaNAb["sValor"] = filaNA["sValor"]="false";
			filaNAb["sLiteral"]=filaNA["sLiteral"]="No";
			this.dsAltaCentros.ListaSiNo.Rows.InsertAt(filaNA,0);
			this.dsAltaCentros.ListaSiNob.Rows.InsertAt(filaNAb,0);
			DataRow filaNA2 = this.dsAltaCentros.ListaSiNo.NewRow();
			DataRow filaNA2b = this.dsAltaCentros.ListaSiNob.NewRow();
			filaNA2b["sValor"] = filaNA2["sValor"]="true";
			filaNA2b["sLiteral"]=filaNA2["sLiteral"]="Si";
			this.dsAltaCentros.ListaSiNo.Rows.InsertAt(filaNA2,1);
			this.dsAltaCentros.ListaSiNob.Rows.InsertAt(filaNA2b,1);
			this.dsAltaCentros.ListaSiNo.AcceptChanges();
			this.dsAltaCentros.ListaSiNob.AcceptChanges();
			this.cboPactoPrescripcion.SelectedValue="false";
			this.cboVisitaColectiva.SelectedValue="false";
			
		}
		/// <summary>
		/// Inicializa combo Politica Prescripcion
		/// </summary>
		private void InicicilizaComboPoliticaPrescripcion()
		{
			this.sqldaListaTipoPoliticaPrescripcion.Fill(this.dsAltaCentros);
			DataRow filaNA = this.dsAltaCentros.ListaTipoPoliticaPrescripcion.NewRow();
			filaNA["sValor"]="N/A";
			filaNA["sLiteral"]="No Asignado";
			this.dsAltaCentros.ListaTipoPoliticaPrescripcion.Rows.InsertAt(filaNA,0);
			this.cboPoliticaPrescripcion.SelectedValue="N/A";
		}
		//ListaTipoSistemaInformatico
		private void InicicilizaComboSistemaInformatico()
		{
			this.sqldaListaTipoSistemaInformatico.Fill(this.dsAltaCentros);
			DataRow filaNA = this.dsAltaCentros.ListaTipoSistemaInformatico.NewRow();
			filaNA["sValor"]="N/A";
			filaNA["sLiteral"]="No Asignado";
			this.dsAltaCentros.ListaTipoSistemaInformatico.Rows.InsertAt(filaNA,0);
			this.cboSistemaInformatico.SelectedValue="N/A";
		}
		//sqldaListaTipoRelacionClienteCentro
		private void InicicilizaComboTipoRelacionClienteCentro()
		{
			this.sqldaListaTipoRelacionClienteCentro.Fill(this.dsAltaCentros);
			this.cboSistemaInformatico.SelectedIndex = 0;
		}
		#endregion

		#region frmAltaCentros_Load
		private void frmAltaCentros_Load(object sender, System.EventArgs e)
		{
			InicializaAltaCentros();
			if (ParamTipoAcceso == "A")
			{			
				iEstadoCentro = ESTADO_PENDIENTE;
				Utiles.BloquearPanel(pnAsociarClientes);
				Utiles.BloquearPanel(pnClientes);
				ObteneriIdCentro();
			}
			else
			{
				this.labelGradient1.Text = "Modificación de Datos Centro";
				ObtenerCentro();
				ObtenerClientesCentro();


				if( iEstadoCentro == ESTADO_ACTIVO)
				{
					Utiles.BloquearPanel(pnCentro);
					if (cboTipoCentro.SelectedValue.ToString() == "3" || cboTipoCentro.SelectedValue.ToString() == "4")
					{
						//No se pueden asociar clientes a Farmacias "3" y mayoristas "4"
						Utiles.BloquearPanel(pnAsociarClientes);
						ParamTipoAcceso = "C";
						this.labelGradient1.Text = "Consulta de Datos Centro";
					}
					else
					{
						//Modificacion
						if (!EsDeMiRed())
						{
							Utiles.BloquearPanel(pnAsociarClientes);
							ParamTipoAcceso = "C";
							this.labelGradient1.Text = "Consulta de Datos Centro";
						}
						else
						{
							cboVisitaColectiva.Enabled = true;
							cboPactoPrescripcion.Enabled = true;
							cboPoliticaPrescripcion.Enabled = true;
							cboSistemaInformatico.Enabled = true;
						}
					}

				}
				else
				{
					if (iEstadoCentro == ESTADO_PENDIENTE)
					{
						if(bEnviadoCen)
						{
							//Modo Consulta no se pueden modificar los registros
							BloquearPaneles();
							this.labelGradient1.Text = "Consulta de Datos Centro";
							ParamTipoAcceso = "C";
						}
						else
						{
							//Modificacion
							if (!EsDeMiRed())
							{
								ParamTipoAcceso = "C";
								this.labelGradient1.Text = "Consulta de Datos Centro";
							}
							Utiles.BloquearPanel(pnAsociarClientes);
						}
					}
					else
					{
						//Modo Consulta no se pueden modificar los registros
						BloquearPaneles();
						this.labelGradient1.Text = "Consulta de Datos Centro";
						ParamTipoAcceso = "C";
					}
				}
			}
			Inicializar_Botonera();
		}

		#endregion

		bool EsDeMiRed ()
		{	int iExiste = 0;
			try
			{
                //---- GSG (10/09/2014)
                //sqlConn.Open();
                if (sqlConn.State == ConnectionState.Closed)
                    sqlConn.Open();

				sqlcmdExisteCentroRed.Parameters["@iIdCentro"].Value = ParamIdCentro;
				sqlcmdExisteCentroRed.Parameters["@sIdRed"].Value = Clases.Configuracion.sIdRed;
				iExiste = (int) sqlcmdExisteCentroRed.ExecuteScalar();
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

		#region Bloquear Paneles
		/// <summary>
		/// Bloquea los paneles de formulario modo consulta.
		/// </summary>
		private void BloquearPaneles()
		{
			Utiles.BloquearPanel(pnCentro);
			Utiles.BloquearPanel(pnClientes);
			Utiles.BloquearPanel(pnAsociarClientes);
		}
	
		#endregion

		#region Obtener Clientes Centro
		private void ObtenerClientesCentro()
		{
			try
			{	
				sqldaListaCLientesCOM_Centros.SelectCommand.Parameters["@iIdCentro"].Value = ParamIdCentro;
				sqldaListaCLientesCOM_Centros.Fill(dsAltaCentros);
				lblNumRegistros.Text = dsAltaCentros.ListaClientesCOM_Centros.Rows.Count.ToString();

			}
			catch (Exception ex)
			{
				Mensajes.ShowError(ex.Message);
			}

		}
		#endregion

		#region Obtener Centro
		/// <summary>
		/// Obtener el centro a partir de iIdCentro pasado por parametro
		/// </summary>
		private void ObtenerCentro()
		{
			try
			{	

				sqldaGetCentro.SelectCommand.Parameters["@iIdCentro"].Value = ParamIdCentro;
				sqldaGetCentro.SelectCommand.Parameters["@sIdRed"].Value = Clases.Configuracion.sIdRed;

				sqldaGetCentro.Fill(dsAltaCentros);
				
				// dsAltaCentros.GetCentro.Rows[0]["sIdCentro"].ToString();
				// dsAltaCentros.GetCentro.Rows[0]["sIdCentroTemp"].ToString(); 
				cboTipoCentro.SelectedValue = (dsAltaCentros.GetCentro.Rows[0]["sIdTipoCentro"] == DBNull.Value)?"N/A":dsAltaCentros.GetCentro.Rows[0]["sIdTipoCentro"].ToString();  
				txbNomCentro.Text = dsAltaCentros.GetCentro.Rows[0]["sDescripcion"].ToString();  
				txbDireccionCentro.Text =  dsAltaCentros.GetCentro.Rows[0]["sDireccion"].ToString();  
				txbIdPoblacion.Text = dsAltaCentros.GetCentro.Rows[0]["iIdPoblacion"].ToString();  
				txbFax.Text = dsAltaCentros.GetCentro.Rows[0]["sFax"].ToString();  
				txbTelefono.Text =  dsAltaCentros.GetCentro.Rows[0]["sTelefono"].ToString();  
				cboPoliticaPrescripcion.SelectedValue = (dsAltaCentros.GetCentro.Rows[0]["sIdPolPrescripcion"] == DBNull.Value )?"N/A":dsAltaCentros.GetCentro.Rows[0]["sIdPolPrescripcion"].ToString();  
				cboClasificacion.SelectedValue = (dsAltaCentros.GetCentro.Rows[0]["sIdTipoClasificacion"] == DBNull.Value)?"N/A":dsAltaCentros.GetCentro.Rows[0]["sIdTipoClasificacion"].ToString();  
				cboSistemaInformatico.SelectedValue = (dsAltaCentros.GetCentro.Rows[0]["sIdSistInformatico"] == DBNull.Value)?"N/A":dsAltaCentros.GetCentro.Rows[0]["sIdSistInformatico"].ToString();  
				cboPactoPrescripcion.SelectedValue = (dsAltaCentros.GetCentro.Rows[0]["bPactoPrescripcion"].ToString()== "True")?"true":"false" ;  
				cboVisitaColectiva.SelectedValue = (dsAltaCentros.GetCentro.Rows[0]["bVisitaColectiva"].ToString()== "True")?"true":"false";  
				//dsAltaCentros.GetCentro.Rows[0]["dFUM"].ToString();  
				iEstadoCentro = Int32.Parse(dsAltaCentros.GetCentro.Rows[0]["iEstado"].ToString());  
				//dsAltaCentros.GetCentro.Rows[0]["bEnviadoPDA"].ToString();  
				bEnviadoCen = (dsAltaCentros.GetCentro.Rows[0]["bEnviadoCEN"].ToString() == "True")?true:false;  
				txbBPoblacion.Text = dsAltaCentros.GetCentro.Rows[0]["Poblaciones"].ToString();  
				//dsAltaCentros.GetCentro.Rows[0]["iIdProvincia"].ToString();  
				txbProvincia.Text = dsAltaCentros.GetCentro.Rows[0]["sProvincia"].ToString();  
				txtCodPostal.Text =  dsAltaCentros.GetCentro.Rows[0]["sCodPostal"].ToString();  
				txbBickIMS.Text = dsAltaCentros.GetCentro.Rows[0]["sIdBrick"].ToString(); 
				
			}
			catch (Exception ex)
			{
				Mensajes.ShowError(ex.Message);
			}


		}

		#endregion

		#region Busca Poblaciones
		private void btnBuscPob_Click(object sender, System.EventArgs e)
		{
			try
			{	
				Application.DoEvents();
				GESTCRM.Formularios.Busquedas.frmMPoblaciones frmBPob = new GESTCRM.Formularios.Busquedas.frmMPoblaciones();
				frmBPob.ShowDialog(this);
				
				if(frmBPob._ValorAceptar != null)
				{
					int iIdPoblacion = frmBPob.ParamO_iIdPoblacion;
					this.txbIdPoblacion.Text= iIdPoblacion.ToString();
					this.txbBPoblacion.Text = frmBPob.ParamO_sPoblacion;
					this.txtCodPostal.Text = frmBPob.ParamO_sCodPostal;
					txbProvincia.Text=  frmBPob.ParamO_sProvincia;
					txbBickIMS.Text = frmBPob.ParamO_sBrick;
				
				}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region Busca Clientes
		private void btBuscarCliente_Click(object sender, System.EventArgs e)
		{
			int iDelegado;
			
			try 
			{
				
				iDelegado = Clases.Configuracion.iIdDelegado ;

				GESTCRM.Formularios.Busquedas.frmMClientesSAP frmBCli = new GESTCRM.Formularios.Busquedas.frmMClientesSAP("CP");

				frmBCli.ParamI_sIdTipoCliente = "C";
				frmBCli.ParamIO_sIdCliente = "";
				frmBCli.ParamI_sIdCentro = "";
				frmBCli.ParamI_iIdDelegado = (iDelegado != 0)?iDelegado:-1;
				frmBCli.ShowDialog(this);

				if (frmBCli.DialogResult==System.Windows.Forms.DialogResult.OK)
				{
					txtClienteSAP.Text = frmBCli.ParamIO_sIdCliente;
					txtsCliente.Text = frmBCli.ParamO_tNombre;
					int iIdcliente = frmBCli.ParamO_iIdCliente;
					txbiIdCliente.Text = iIdcliente.ToString();
				}
			}
			catch (Exception ev)
			{
				//MessageBox.Show ("Error en el evento del btn buscar cliente"+ev.ToString());
                Mensajes.ShowError("Error en el evento del btn buscar cliente: " + ev.ToString());
			}
		}
		#endregion

		#region Anyadir Clientes Centro
		private void btnActualizar_Click(object sender, System.EventArgs e)
		{
			//Validar Cliente
			if(txbiIdCliente.Text !="")
			{
				ActualizarCliente();
			}
			else
			{
				Mensajes.ShowInformation("Debe seleccionar un cliente.");
			}
		}
		
		private void ActualizarCliente()
		{
			if(iFILA == -1 )//Nuevo cliente 
			{
				if (!ExisteCliente())
				{
					if ( cboRelecionConElCentro.SelectedValue.ToString() == "0") ExisteOtroCentroPropio();
					DataRow dsfila = dsAltaCentros.ListaClientesCOM_Centros.NewRow();
					dsfila["iIdCliente"]= txbiIdCliente.Text;
					dsfila["sIdCliente"]= txtClienteSAP.Text;
					dsfila["tNombre"]= txtsCliente.Text;
					dsfila["sIdTipoRelacionCliCen"]= cboRelecionConElCentro.SelectedValue.ToString();
					dsfila["sLiteral"]= cboRelecionConElCentro.Text;
					dsfila["Accion"]= Accion_Insertar;
					dsfila["sIdRed"]= Clases.Configuracion.sIdRed;
					DataRow[] oRow = dsAltaCentros.ListaRedes.Select("sValor = '" + Clases.Configuracion.sIdRed + "'") ;
					dsfila["Red"]= oRow[0][1];

					dsAltaCentros.ListaClientesCOM_Centros.Rows.Add(dsfila);
				}
				else
				{
					Mensajes.ShowInformation("El cliente "+ txtClienteSAP.Text+  " ya está asignado a este centro.");
				}
			}
			else
			{ 
				int record = GESTCRM.Utiles.Buscar_fila_dtTabla(dsAltaCentros.ListaClientesCOM_Centros ,"sIdCliente",dgCLientesCentros[dgCLientesCentros.CurrentRowIndex,1].ToString(),"sIdRed",dgCLientesCentros[dgCLientesCentros.CurrentRowIndex,6].ToString());
				if (dsAltaCentros.ListaClientesCOM_Centros.Rows[record]["sIdRed"].ToString()== Clases.Configuracion.sIdRed)
				{
					if ( cboRelecionConElCentro.SelectedValue.ToString() == "0") ExisteOtroCentroPropio();
					dsAltaCentros.ListaClientesCOM_Centros.Rows[record]["sIdTipoRelacionCliCen"]= cboRelecionConElCentro.SelectedValue.ToString();
					dsAltaCentros.ListaClientesCOM_Centros.Rows[record]["sLiteral"]= cboRelecionConElCentro.Text;
					if (sAccionLinea != Accion_Insertar)
						dsAltaCentros.ListaClientesCOM_Centros.Rows[record]["Accion"]= Accion_Modificar;
				}
				else
				{
					Mensajes.ShowInformation("No se puede modificar un cliente que no pertenece a su red comercial.");
				}
			}
			dsAltaCentros.ListaClientesCOM_Centros.AcceptChanges();
			lblNumRegistros.Text = dsAltaCentros.ListaClientesCOM_Centros.Rows.Count.ToString();
			InicializaCliente();
						
		}


		/// <summary>
		/// Comprueba si el cliente ya esta asignado al centro
		/// </summary>
		/// <returns>true si existe el clientes, false si no existe</returns>
		private bool ExisteCliente()
		{
			bool bExiste = false;
			foreach( DataRow dsFila in dsAltaCentros.ListaClientesCOM_Centros.Rows)
			{
				if(dsFila["iIdCliente"].ToString() == txbiIdCliente.Text && dsFila["sIdRed"].ToString() == Clases.Configuracion.sIdRed )
				{
					bExiste = true;
					break;
				}
			}
			return bExiste;
		}
		/// <summary>
		/// Comprueba que el cliente no este asignado como propio a otro centro de la misma red
		/// </summary>
		private void ExisteOtroCentroPropio()
		{
			int Existe = 1;
			try
			{
                //---- GSG (10/09/2014)
                //sqlConn.Open();
                if (sqlConn.State == ConnectionState.Closed)
                    sqlConn.Open();
				
				sqlCmdExisteCentroRedPropioCliente.Parameters["@iIdCentro"].Value = ParamIdCentro;
				sqlCmdExisteCentroRedPropioCliente.Parameters["@iIdCLiente"].Value =  txbiIdCliente.Text;
				sqlCmdExisteCentroRedPropioCliente.Parameters["@sIdRed"].Value =  Clases.Configuracion.sIdRed; 

				Existe = (int) sqlCmdExisteCentroRedPropioCliente.ExecuteScalar();
			}
			catch(Exception Ex)
			{
				//MessageBox.Show ("Error en ExisteOtroCentroPropio "+ Ex.ToString());
                Mensajes.ShowError("Error en ExisteOtroCentroPropio: " + Ex.ToString());
			}
			finally
			{
				sqlConn.Close();
			}
			if (Existe == 1) 
			{
				Mensajes.ShowInformation("El cliente " + txtsCliente.Text + " ya está asignado a otro centro con tipo relación Propio.\nSe añadirá como tipo relación Ocasional.");
				cboRelecionConElCentro.SelectedValue  = 1;
			}
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

		#region Graba clientes
		/// <summary>
		/// Graba clientes
		/// </summary>
		/// <returns>True sino hay problemas</returns>
		private bool Graba_Clientes()
		{
			bool resultado=true;
            //---- GSG (10/09/2014)
            //sqlConn.Open();
            if (sqlConn.State == ConnectionState.Closed)
                sqlConn.Open();


			sqlTran = this.sqlConn.BeginTransaction();
			sqlcmdSetCentrosClientesCOM.Transaction = this.sqlTran;
			try
			{
				//Pone estado -1 a los eliminados
				foreach(string oClienteBorrado in aListaClientesBorrados)
				{
					sqlcmdSetCentrosClientesCOM.Parameters["@iAccion"].Value = 2; 
					sqlcmdSetCentrosClientesCOM.Parameters["@iIdCliente"].Value = oClienteBorrado;
					sqlcmdSetCentrosClientesCOM.Parameters["@iIdCentro"].Value = ParamIdCentro ;
					sqlcmdSetCentrosClientesCOM.Parameters["@sIdTipoRelacionCliCen"].Value = SqlString.Null;
					sqlcmdSetCentrosClientesCOM.Parameters["@sIdRed"].Value = Clases.Configuracion.sIdRed;
					sqlcmdSetCentrosClientesCOM.ExecuteNonQuery();
				}

				foreach( DataRow oRow in dsAltaCentros.ListaClientesCOM_Centros.Rows)
				{	
					if (oRow["Accion"].ToString() != "")
					{
						sqlcmdSetCentrosClientesCOM.Parameters["@iAccion"].Value = (oRow["Accion"].ToString()== Accion_Insertar)?0:1; 
						sqlcmdSetCentrosClientesCOM.Parameters["@iIdCliente"].Value = oRow["iIdCliente"].ToString();
						sqlcmdSetCentrosClientesCOM.Parameters["@iIdCentro"].Value = ParamIdCentro;
						sqlcmdSetCentrosClientesCOM.Parameters["@sIdTipoRelacionCliCen"].Value = oRow["sIdTipoRelacionCliCen"].ToString();
						sqlcmdSetCentrosClientesCOM.Parameters["@sIdRed"].Value = Clases.Configuracion.sIdRed;
						sqlcmdSetCentrosClientesCOM.ExecuteNonQuery();
//						if (oRow["Accion"].ToString()== Accion_Insertar) 
//						{
//							sqlcmdSetCP_CLientes_BrickCLientes.Transaction = this.sqlTran;
//							sqlcmdSetCP_CLientes_BrickCLientes.Parameters["@iIDPoblacion"].Value = txbIdPoblacion.Text;
//							sqlcmdSetCP_CLientes_BrickCLientes.Parameters["@sCodPostal"].Value = txtCodPostal.Text;
//							sqlcmdSetCP_CLientes_BrickCLientes.Parameters["@iIDCLiente"].Value = oRow["iIdCliente"].ToString();
//							sqlcmdSetCP_CLientes_BrickCLientes.ExecuteNonQuery();
//						}
					}

				}
				this.sqlTran.Commit();
				resultado=true;
			}
			catch(Exception e)
			{
				Mensajes.ShowError(e.Message);
				this.sqlTran.Rollback();
				resultado=false;
			}
			finally
			{
				this.sqlConn.Close();
			}
			return resultado;
		}
		#endregion

		#region Grabar Centro
		/// <summary>
		/// Graba el centro
		/// </summary>
		/// <returns>True sino hay problemas</returns>
		private bool Grabar_Centro()
		{
			bool resultado=true;
			int iAccion = Utiles.Transformar_TipoAcceso(this.ParamTipoAcceso);
            //---- GSG (10/09/2014)
            //sqlConn.Open();
            if (sqlConn.State == ConnectionState.Closed)
                sqlConn.Open();


			sqlTran = this.sqlConn.BeginTransaction();
			sqlcmdSetCentros.Transaction = this.sqlTran;
			sqlcmdSetCentrosRedes.Transaction = sqlTran;
			try
			{
				sqlcmdSetCentros.Parameters["@iAccion"].Value = iAccion;
				sqlcmdSetCentros.Parameters["@iIdCentro"].Value = (ParamTipoAcceso=="A")? Int32.Parse(sIdCentro.Substring(0,3)+ sIdCentro.Substring(5,5)):ParamIdCentro;
				sqlcmdSetCentros.Parameters["@sIdCentro"].Value = (ParamTipoAcceso=="A")?sIdCentro:SqlString.Null;
				sqlcmdSetCentros.Parameters["@sIdCentroTemp"].Value = (ParamTipoAcceso=="A")?sIdCentro:SqlString.Null;
				sqlcmdSetCentros.Parameters["@sIdTipoCentro"].Value = (cboTipoCentro.SelectedValue.ToString() == "N/A")?SqlString.Null:cboTipoCentro.SelectedValue;
				sqlcmdSetCentros.Parameters["@sDescripcion"].Value = txbNomCentro.Text.ToUpper();
				sqlcmdSetCentros.Parameters["@sDireccion"].Value = txbDireccionCentro.Text.ToUpper();
				sqlcmdSetCentros.Parameters["@iIdPoblacion"].Value = txbIdPoblacion.Text;
				sqlcmdSetCentros.Parameters["@sFax"].Value = (txbFax.Text.Trim() == "")?SqlString.Null:txbFax.Text.Trim();
				sqlcmdSetCentros.Parameters["@sTelefono"].Value = (txbTelefono.Text.Trim() == "")?SqlString.Null:txbTelefono.Text.Trim();
				sqlcmdSetCentros.Parameters["@sIdPolPrescripcion"].Value = (cboPoliticaPrescripcion.SelectedValue.ToString() == "N/A")? SqlString.Null: cboPoliticaPrescripcion.SelectedValue; 
				sqlcmdSetCentros.Parameters["@sIdTipoClasificacion"].Value = (cboClasificacion.SelectedValue.ToString() == "N/A")? SqlString.Null:cboClasificacion.SelectedValue;
				sqlcmdSetCentros.Parameters["@sIdSistInformatico"].Value = (cboSistemaInformatico.SelectedValue.ToString() == "N/A")? SqlString.Null:cboSistemaInformatico.SelectedValue;
				sqlcmdSetCentros.Parameters["@bPactoPrescripcion"].Value = (cboPactoPrescripcion.SelectedValue.ToString() == "true")?1:0;   
				sqlcmdSetCentros.Parameters["@bVisitaColectiva"].Value = (cboVisitaColectiva.SelectedValue.ToString() == "true")?1:0;
				sqlcmdSetCentros.Parameters["@iEstado"].Value = iEstadoCentro;
				sqlcmdSetCentros.ExecuteNonQuery();
				if ( ParamTipoAcceso  == "A")
				{
					sqlcmdSetCentrosRedes.Parameters["@iIdCentro"].Value = sIdCentro.Substring(0,3)+ sIdCentro.Substring(5,5);
					sqlcmdSetCentrosRedes.Parameters["@sIdRed"].Value = Clases.Configuracion.sIdRed;
					sqlcmdSetCentrosRedes.Parameters["@iEstado"].Value = -3;
					sqlcmdSetCentrosRedes.ExecuteNonQuery();
				}

				this.sqlTran.Commit();
				resultado=true;
			}
			catch(Exception e)
			{
				Mensajes.ShowError(e.Message);
				this.sqlTran.Rollback();
				resultado=false;
			}
			finally
			{
				this.sqlConn.Close();
			}
			return resultado;
		}

		#endregion

		#region btGrabar_Click
		private void btGrabar_Click(object sender, System.EventArgs e)
		{
			try
			{
				if ( ParamTipoAcceso == "A" || (iEstadoCentro == ESTADO_PENDIENTE && !bEnviadoCen))
				{
					if(Validar_Centro())
					{
						if (Grabar_Centro())
						{
							Mensajes.ShowInformation(3004);
							//this.SalirDesdeGuardar=true;
							this.Close();
						}//del Grabar
					}//del Validar
				}
				else if ( ParamTipoAcceso != "C")
				{
					Grabar_Centro();
					Graba_Clientes();
					this.Close();
				}
			}//del try
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region btSalir_Click
		private void btSalir_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
		#endregion

		
		#region Validar_Centro
		/// <summary>
		/// Valiada que los datos del centro sean acorrectos.
		/// </summary>
		/// <returns>true si son correctos</returns>
		private bool Validar_Centro()
		{
			if (txbNomCentro.Text.Trim() == "")
			{
				Mensajes.ShowInformation("Debe informar el Nombre del Centro");
				return false;
			}
			if (txbDireccionCentro.Text.Trim() == "")
			{
				Mensajes.ShowInformation("Debe informar la Dirección del Centro");
				return false;
			}	
			if (txtCodPostal.Text.Trim() == "")
			{
				Mensajes.ShowInformation("Debe informar el Código postal del Centro");
				return false;
			}	
			
			if (!Utiles.ValidaCampo(txbTelefono.Name.ToString().ToUpper().Trim(),"Teléfono ",Utiles.sPatternTelNumber , Utiles.sPatternTelGuide ,this ))
			{
				//Mensajes.ShowInformation("Debe informar el Teléfono correctamente.");
				return false;
			}
			if (!Utiles.ValidaCampo(txbFax.Name.ToString().ToUpper().Trim(),"Fax ",Utiles.sPatternTelNumber ,Utiles.sPatternTelGuide ,this ))
			{
				//Mensajes.ShowInformation("Debe informar el Fax correctamente.");
				return false;
			}
			if ( cboTipoCentro.SelectedValue.ToString() == "N/A") 
			{
				Mensajes.ShowInformation("Debe seleccionar un Tipo de Centro.");
				return false;
			}
			return true;
		}
		#endregion

		#region btnEliminar_Click
		private void btnEliminar_Click(object sender, System.EventArgs e)
		{
			if (dgCLientesCentros.CurrentRowIndex != -1)
			{
				int record = GESTCRM.Utiles.Buscar_fila_dtTabla(dsAltaCentros.ListaClientesCOM_Centros ,"sIdCliente",dgCLientesCentros[dgCLientesCentros.CurrentRowIndex,1].ToString(),"sIdRed",dgCLientesCentros[dgCLientesCentros.CurrentRowIndex,6].ToString());
				

				if (dsAltaCentros.ListaClientesCOM_Centros.Rows[record]["sIdRed"].ToString()== Clases.Configuracion.sIdRed)
				{
					string sMensaje = "¿Está seguro que desea eliminar el cliente\n " +  dsAltaCentros.ListaClientesCOM_Centros.Rows[record]["tNombre"].ToString()+"?";
					if(Mensajes.ShowQuestion(sMensaje)== DialogResult.Yes)
					{
						if (dsAltaCentros.ListaClientesCOM_Centros.Rows[record]["Accion"].ToString()!= Accion_Insertar)
							aListaClientesBorrados.Add(dsAltaCentros.ListaClientesCOM_Centros.Rows[record]["iIdCliente"].ToString());
						dsAltaCentros.ListaClientesCOM_Centros.Rows[record].Delete();
						dsAltaCentros.ListaClientesCOM_Centros.AcceptChanges();
						lblNumRegistros.Text = dsAltaCentros.ListaClientesCOM_Centros.Rows.Count.ToString();
						InicializaCliente();
					}
				}
				else
				{
					string sMensaje = "No se puede eliminar un cliente que no pertenece a su red comercial.";
					Mensajes.ShowInformation( sMensaje);
				}
			}
		}
		#endregion

		private void dgCLientesCentros_DoubleClick(object sender, System.EventArgs e)
		{
			if ( dgCLientesCentros.CurrentRowIndex != -1)
			{
				int record = GESTCRM.Utiles.Buscar_fila_dtTabla(dsAltaCentros.ListaClientesCOM_Centros ,"sIdCliente",dgCLientesCentros[dgCLientesCentros.CurrentRowIndex,1].ToString(),"sIdRed",dgCLientesCentros[dgCLientesCentros.CurrentRowIndex,6].ToString());
				EditarCliente(record);
			}
		}
		#region Editar Cliente
		/// <summary>
		/// Edita la el cliente seleccionado.
		/// </summary>
		/// <param name="iFila">Fila de grid a editar</param>
		private void EditarCliente(int iFila)
		{
			iFILA = iFila;
			Color   ColorBloqueo = Color.FromArgb(238, 243, 246);
			//Informar controles
			txbiIdCliente.Text = dsAltaCentros.ListaClientesCOM_Centros.Rows[iFila]["iIdCliente"].ToString();
			txtClienteSAP.Text = dsAltaCentros.ListaClientesCOM_Centros.Rows[iFila]["sIdCliente"].ToString();
			txtsCliente.Text = dsAltaCentros.ListaClientesCOM_Centros.Rows[iFila]["tNombre"].ToString();
			sAccionLinea = dsAltaCentros.ListaClientesCOM_Centros.Rows[iFila]["Accion"].ToString();
			cboRelecionConElCentro.SelectedValue = dsAltaCentros.ListaClientesCOM_Centros.Rows[iFila]["sIdTipoRelacionCliCen"].ToString();
			//Bloquear controles
			txtClienteSAP.ReadOnly = true;
			txtClienteSAP.BackColor = ColorBloqueo;
			btBuscarCliente.Enabled = false;
		}
		#endregion

		#region txtClienteSAP_Leave
		private void txtClienteSAP_Leave(object sender, System.EventArgs e)
		{
			int iDelegado;
			
			try 
			{
				
				iDelegado = Clases.Configuracion.iIdDelegado ;

				GESTCRM.Formularios.Busquedas.frmMClientesSAP frmBCli = new GESTCRM.Formularios.Busquedas.frmMClientesSAP("CP");

				frmBCli.ParamI_sIdTipoCliente = "C";
				frmBCli.ParamIO_sIdCliente = txtClienteSAP.Text = txtClienteSAP.Text.ToUpper();
				frmBCli.ParamI_sIdCentro = "";
				frmBCli.ParamI_iIdDelegado = (iDelegado != 0)?iDelegado:-1;
				frmBCli.Buscar_tNombre();
				
				txtClienteSAP.Text = frmBCli.ParamIO_sIdCliente;
				txtsCliente.Text = frmBCli.ParamO_tNombre;
				int iIdcliente = frmBCli.ParamO_iIdCliente;
				txbiIdCliente.Text = iIdcliente.ToString();
				
			}
			catch (Exception ev)
			{
				//MessageBox.Show ("Error en el evento del txtClienteSAP_Leave "+ev.ToString());
                Mensajes.ShowError("Error en el evento del txtClienteSAP_Leave: " + ev.ToString());
			}
		
		}
		#endregion

		private void InicializaCliente()
		{
			txtClienteSAP.Text = "";
			txtsCliente.Text = "";
			txbiIdCliente.Text = "";
			txtClienteSAP.BackColor = Color.White;
			txtClienteSAP.ReadOnly = false;
			btBuscarCliente.Enabled = true;
			iFILA = -1;
			this.cboRelecionConElCentro.SelectedIndex = 0;
		}

		
		private void menuEditar_Click(object sender, System.EventArgs e)
		{
			if ( dgCLientesCentros.CurrentRowIndex != -1)
			{
				EditarCliente(dgCLientesCentros.CurrentRowIndex);
			}
        }

		
	
		
	}
}
