using System; 
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using GESTCRM.Controles;

namespace GESTCRM.Formularios.Busquedas
{
	/// <summary>
	/// Descripción breve de frmMClientesSAP.
	/// </summary>
	public class frmMClientesSAP : System.Windows.Forms.Form
	{
		public int	  ParamI_iIdDelegado;
		public int	  ParamI_TipoVisita=0;
		public int	  ParamO_iIdCliente;
		public string ParamIO_sIdCliente;
		public string ParamI_sIdTipoCliente;
		public string ParamO_tNombre;
		public string ParamI_sIdCentro;
		public string ParamO_tProxObj;
		public DataTable dtSeleccion;

		private string Param_Origen;
		private int BuscarConCentro;
		DataTable dtMostrar;
		private int Var_filaDg;

		private System.Windows.Forms.Panel pnlClientes;
		private System.Windows.Forms.TextBox txbNombre;
		private System.Windows.Forms.ComboBox cboTipo;
		private System.Windows.Forms.Label lblNombre;
		private System.Windows.Forms.Label lblTipo;
		private System.ComponentModel.IContainer components;
		private System.Data.SqlClient.SqlConnection sqlConn;
		private GESTCRM.Formularios.Busquedas.dsBuscar dsBuscar1;
		private System.Windows.Forms.Label lblsIdCliente;
		private System.Windows.Forms.Label lblMostrar;
		private System.Windows.Forms.DataGrid dgClientes;
		private System.Data.SqlClient.SqlDataAdapter sqldaListaBuscaClientes;
		private System.Data.SqlClient.SqlDataAdapter sqldaListaTipoCliente;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand2;
        //---- GSG (05/09/2011)
        private System.Data.SqlClient.SqlDataAdapter sqldaListaBricks;
        private System.Data.SqlClient.SqlCommand sqlCmdListaBricks;
        private System.Data.SqlClient.SqlCommand sqlCmdListaBricksCECL; //---- GSG CECL 19/05/2016
        //---- GSG (01/07/2013)
        private System.Data.SqlClient.SqlDataAdapter sqldaListaBuscaClientesSAP;
        private System.Data.SqlClient.SqlDataAdapter sqldaListaBuscaClientesCOM;
        private System.Data.SqlClient.SqlDataAdapter sqldaListaBuscaClientesTOT;
        private System.Data.SqlClient.SqlCommand sqlSelectCommandClientesSAP;
        private System.Data.SqlClient.SqlCommand sqlSelectCommandClientesSAPCECL; //---- GSG CECL 19/05/2016
        private System.Data.SqlClient.SqlCommand sqlSelectCommandClientesCOM;
        private System.Data.SqlClient.SqlCommand sqlSelectCommandClientesTOT;
        //---- FI GSG
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
		private System.Windows.Forms.ComboBox cboMostrar;
		private System.Windows.Forms.TextBox txtsIdCliente;
		private System.Windows.Forms.Label lblCentro;
		private System.Windows.Forms.TextBox txtsIdCentro;
		private System.Windows.Forms.Button btBuscarCentro;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Button btAceptar;
		private System.Windows.Forms.Button btCancelar;
		private System.Windows.Forms.TextBox txtsCentro;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
		private System.Data.SqlClient.SqlDataAdapter sqldaListaRelacionCliCen;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		private System.Windows.Forms.ComboBox cbTipoRelacionCentro;
		private System.Windows.Forms.Label lblRel;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn5;
		private System.Windows.Forms.Panel pnBusqueda;
		private System.Windows.Forms.Label lblNumReg;
		private GESTCRM.Controles.LabelGradient labelGradient2;
		private System.Windows.Forms.Button btBuscar;
		private System.Windows.Forms.TextBox txtCodPostal;
		private System.Windows.Forms.Label lblCodPostal;
		private System.Windows.Forms.Button btnBuscPob;
		private System.Windows.Forms.TextBox txbBPoblacion;
		private System.Windows.Forms.Label lblCliente;
		private System.Windows.Forms.TextBox txbIdPoblacion;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn6;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn7;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn8;
		private System.Windows.Forms.TextBox txbApellidos1;
		private System.Windows.Forms.TextBox txtApellidos2;
		private System.Windows.Forms.Label lblApellido1;
		private System.Windows.Forms.Label lblApellido2;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
        private System.Data.SqlClient.SqlCommand sqlSelectCommand1CECL; //---- GSG CECL 19/05/2016
        private System.Windows.Forms.ComboBox cboRed;
        private System.Windows.Forms.ComboBox cboDescBrick;
		private System.Windows.Forms.Label label1;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand4;
        private System.Data.SqlClient.SqlCommand sqlSelectCommand4CECL; //---- GSG CECL 19/05/2016
		private System.Data.SqlClient.SqlDataAdapter sqldaListaRedes;
        private Label lblBrick;
        private TextBox txtCodBrick;
        private Label lblCategoria;
        private ComboBox cboCategoria;
		private bool bBusquedaMultiple;
        //---- GSG (31/01/2012)
        private System.Data.SqlClient.SqlCommand sqlSelectCmdTipoClasificacion;
        private BindingSource listaTipoClasificacioBindingSource1;
        private ComboBox cboArea;
        private Label lblArea;
        private System.Data.SqlClient.SqlDataAdapter sqldaListaTipoClasificacion;
        //---- GSG (31/05/2013)
        private System.Data.SqlClient.SqlDataAdapter sqldaListaTipoAreasClienteSAP;
        private BindingSource listaTipoAreaBindingSource;
        private DataGridTextBoxColumn dataGridTextBoxColumn9;
        private DataGridTextBoxColumn dataGridTextBoxColumn10;
        private DataGridTextBoxColumn dataGridTextBoxColumn11;
        private DataGridTextBoxColumn dataGridTextBoxColumn12;
        private System.Data.SqlClient.SqlCommand sqlSelectCommandTipoAreasClienteSAP;
        //---- FI GSG


		public frmMClientesSAP (string Origen)
		{
            InitializeComponent();


            //---- GSG (06/03/2021)
            Utiles.GetConfigConnection();
            this.sqlConn.ConnectionString = Utiles._connection.ConnectionString.ToString();

            		
			this.Var_filaDg   = -1;
			bBusquedaMultiple = false;
			this.Param_Origen=Origen;
		}

		public frmMClientesSAP (bool BusquedaMultiple,string Origen)
		{
            InitializeComponent();


            //---- GSG (06/03/2021)
            Utiles.GetConfigConnection();
            this.sqlConn.ConnectionString = Utiles._connection.ConnectionString.ToString();

            		

			this.Var_filaDg = -1;
			this.bBusquedaMultiple = BusquedaMultiple;
			this.Param_Origen=Origen;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMClientesSAP));
            System.Configuration.AppSettingsReader configurationAppSettings = new System.Configuration.AppSettingsReader();
            this.dgClientes = new System.Windows.Forms.DataGrid();
            this.dsBuscar1 = new GESTCRM.Formularios.Busquedas.dsBuscar();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn5 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn6 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn7 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn8 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn9 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn10 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn11 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn12 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.pnlClientes = new System.Windows.Forms.Panel();
            this.cboArea = new System.Windows.Forms.ComboBox();
            this.listaTipoAreaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblArea = new System.Windows.Forms.Label();
            this.cboCategoria = new System.Windows.Forms.ComboBox();
            this.listaTipoClasificacioBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.lblCategoria = new System.Windows.Forms.Label();
            this.cboDescBrick = new System.Windows.Forms.ComboBox();
            this.txtCodBrick = new System.Windows.Forms.TextBox();
            this.lblBrick = new System.Windows.Forms.Label();
            this.cboRed = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtApellidos2 = new System.Windows.Forms.TextBox();
            this.lblApellido2 = new System.Windows.Forms.Label();
            this.txtCodPostal = new System.Windows.Forms.TextBox();
            this.lblCodPostal = new System.Windows.Forms.Label();
            this.btnBuscPob = new System.Windows.Forms.Button();
            this.txbBPoblacion = new System.Windows.Forms.TextBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.cbTipoRelacionCentro = new System.Windows.Forms.ComboBox();
            this.lblRel = new System.Windows.Forms.Label();
            this.txtsCentro = new System.Windows.Forms.TextBox();
            this.btBuscarCentro = new System.Windows.Forms.Button();
            this.txtsIdCentro = new System.Windows.Forms.TextBox();
            this.lblCentro = new System.Windows.Forms.Label();
            this.btBuscar = new System.Windows.Forms.Button();
            this.txtsIdCliente = new System.Windows.Forms.TextBox();
            this.cboMostrar = new System.Windows.Forms.ComboBox();
            this.lblMostrar = new System.Windows.Forms.Label();
            this.txbApellidos1 = new System.Windows.Forms.TextBox();
            this.txbNombre = new System.Windows.Forms.TextBox();
            this.cboTipo = new System.Windows.Forms.ComboBox();
            this.lblApellido1 = new System.Windows.Forms.Label();
            this.lblsIdCliente = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblTipo = new System.Windows.Forms.Label();
            this.txbIdPoblacion = new System.Windows.Forms.TextBox();
            this.sqldaListaBuscaClientes = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlConn = new System.Data.SqlClient.SqlConnection();
            this.sqlSelectCommand1CECL = new System.Data.SqlClient.SqlCommand();
            this.sqldaListaBuscaClientesSAP = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommandClientesSAP = new System.Data.SqlClient.SqlCommand();
            this.sqldaListaBuscaClientesCOM = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommandClientesCOM = new System.Data.SqlClient.SqlCommand();
            this.sqldaListaBuscaClientesTOT = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommandClientesTOT = new System.Data.SqlClient.SqlCommand();
            this.sqlSelectCommandClientesSAPCECL = new System.Data.SqlClient.SqlCommand();
            this.sqldaListaTipoCliente = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
            this.sqldaListaBricks = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCmdListaBricks = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdListaBricksCECL = new System.Data.SqlClient.SqlCommand();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btAceptar = new System.Windows.Forms.Button();
            this.btCancelar = new System.Windows.Forms.Button();
            this.sqldaListaRelacionCliCen = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
            this.pnBusqueda = new System.Windows.Forms.Panel();
            this.lblNumReg = new System.Windows.Forms.Label();
            this.labelGradient2 = new GESTCRM.Controles.LabelGradient();
            this.sqlSelectCommand4 = new System.Data.SqlClient.SqlCommand();
            this.sqlSelectCommand4CECL = new System.Data.SqlClient.SqlCommand();
            this.sqldaListaRedes = new System.Data.SqlClient.SqlDataAdapter();
            this.sqldaListaTipoClasificacion = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCmdTipoClasificacion = new System.Data.SqlClient.SqlCommand();
            this.sqldaListaTipoAreasClienteSAP = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommandTipoAreasClienteSAP = new System.Data.SqlClient.SqlCommand();
            ((System.ComponentModel.ISupportInitialize)(this.dgClientes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBuscar1)).BeginInit();
            this.pnlClientes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listaTipoAreaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listaTipoClasificacioBindingSource1)).BeginInit();
            this.pnBusqueda.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgClientes
            // 
            this.dgClientes.BackgroundColor = System.Drawing.Color.White;
            this.dgClientes.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.dgClientes.CaptionVisible = false;
            this.dgClientes.DataMember = "ListaBuscaClientes";
            this.dgClientes.DataSource = this.dsBuscar1;
            this.dgClientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgClientes.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgClientes.Location = new System.Drawing.Point(0, 18);
            this.dgClientes.Name = "dgClientes";
            this.dgClientes.ReadOnly = true;
            this.dgClientes.RowHeaderWidth = 15;
            this.dgClientes.Size = new System.Drawing.Size(1020, 348);
            this.dgClientes.TabIndex = 10;
            this.dgClientes.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            this.dgClientes.CurrentCellChanged += new System.EventHandler(this.dgClientes_CurrentCellChanged);
            this.dgClientes.Click += new System.EventHandler(this.dgClientes_Click);
            this.dgClientes.Paint += new System.Windows.Forms.PaintEventHandler(this.dgClientes_Paint);
            this.dgClientes.DoubleClick += new System.EventHandler(this.dgClientes_DoubleClick);
            // 
            // dsBuscar1
            // 
            this.dsBuscar1.DataSetName = "dsBuscar";
            this.dsBuscar1.Locale = new System.Globalization.CultureInfo("es-ES");
            this.dsBuscar1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.DataGrid = this.dgClientes;
            this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn1,
            this.dataGridTextBoxColumn2,
            this.dataGridTextBoxColumn3,
            this.dataGridTextBoxColumn4,
            this.dataGridTextBoxColumn5,
            this.dataGridTextBoxColumn6,
            this.dataGridTextBoxColumn7,
            this.dataGridTextBoxColumn8,
            this.dataGridTextBoxColumn9,
            this.dataGridTextBoxColumn10,
            this.dataGridTextBoxColumn11,
            this.dataGridTextBoxColumn12});
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle1.MappingName = "ListaBuscaClientes";
            this.dataGridTableStyle1.RowHeaderWidth = 15;
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "Código";
            this.dataGridTextBoxColumn1.MappingName = "sIdCliente";
            this.dataGridTextBoxColumn1.Width = 120;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "Tipo";
            this.dataGridTextBoxColumn2.MappingName = "tTipoCliente";
            this.dataGridTextBoxColumn2.Width = 0;
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.HeaderText = "Nombre";
            this.dataGridTextBoxColumn3.MappingName = "tNombre";
            this.dataGridTextBoxColumn3.Width = 400;
            // 
            // dataGridTextBoxColumn4
            // 
            this.dataGridTextBoxColumn4.Format = "";
            this.dataGridTextBoxColumn4.FormatInfo = null;
            this.dataGridTextBoxColumn4.MappingName = "iIdCliente";
            this.dataGridTextBoxColumn4.Width = 0;
            // 
            // dataGridTextBoxColumn5
            // 
            this.dataGridTextBoxColumn5.Format = "";
            this.dataGridTextBoxColumn5.FormatInfo = null;
            this.dataGridTextBoxColumn5.MappingName = "tProxObj";
            this.dataGridTextBoxColumn5.NullText = "";
            this.dataGridTextBoxColumn5.Width = 0;
            // 
            // dataGridTextBoxColumn6
            // 
            this.dataGridTextBoxColumn6.Format = "";
            this.dataGridTextBoxColumn6.FormatInfo = null;
            this.dataGridTextBoxColumn6.HeaderText = "Nombre";
            this.dataGridTextBoxColumn6.MappingName = "sNombre";
            this.dataGridTextBoxColumn6.NullText = "";
            this.dataGridTextBoxColumn6.Width = 0;
            // 
            // dataGridTextBoxColumn7
            // 
            this.dataGridTextBoxColumn7.Format = "";
            this.dataGridTextBoxColumn7.FormatInfo = null;
            this.dataGridTextBoxColumn7.HeaderText = "Población";
            this.dataGridTextBoxColumn7.MappingName = "sApellidos1";
            this.dataGridTextBoxColumn7.NullText = "";
            this.dataGridTextBoxColumn7.Width = 200;
            // 
            // dataGridTextBoxColumn8
            // 
            this.dataGridTextBoxColumn8.Format = "";
            this.dataGridTextBoxColumn8.FormatInfo = null;
            this.dataGridTextBoxColumn8.HeaderText = "CP";
            this.dataGridTextBoxColumn8.MappingName = "sApellidos2";
            this.dataGridTextBoxColumn8.NullText = "";
            this.dataGridTextBoxColumn8.Width = 75;
            // 
            // dataGridTextBoxColumn9
            // 
            this.dataGridTextBoxColumn9.Format = "";
            this.dataGridTextBoxColumn9.FormatInfo = null;
            this.dataGridTextBoxColumn9.HeaderText = "iIdArea";
            this.dataGridTextBoxColumn9.MappingName = "iIdArea";
            this.dataGridTextBoxColumn9.Width = 0;
            // 
            // dataGridTextBoxColumn10
            // 
            this.dataGridTextBoxColumn10.Format = "";
            this.dataGridTextBoxColumn10.FormatInfo = null;
            this.dataGridTextBoxColumn10.HeaderText = "Area";
            this.dataGridTextBoxColumn10.MappingName = "sNombreArea";
            this.dataGridTextBoxColumn10.NullText = "";
            this.dataGridTextBoxColumn10.Width = 75;
            // 
            // dataGridTextBoxColumn11
            // 
            this.dataGridTextBoxColumn11.Format = "";
            this.dataGridTextBoxColumn11.FormatInfo = null;
            this.dataGridTextBoxColumn11.HeaderText = "sIdTipoClasificacion";
            this.dataGridTextBoxColumn11.MappingName = "sIdTipoClasificacion";
            this.dataGridTextBoxColumn11.Width = 0;
            // 
            // dataGridTextBoxColumn12
            // 
            this.dataGridTextBoxColumn12.Format = "";
            this.dataGridTextBoxColumn12.FormatInfo = null;
            this.dataGridTextBoxColumn12.HeaderText = "Clasificación";
            this.dataGridTextBoxColumn12.MappingName = "tTipoClasificacion";
            this.dataGridTextBoxColumn12.Width = 120;
            // 
            // pnlClientes
            // 
            this.pnlClientes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlClientes.Controls.Add(this.cboArea);
            this.pnlClientes.Controls.Add(this.lblArea);
            this.pnlClientes.Controls.Add(this.cboCategoria);
            this.pnlClientes.Controls.Add(this.lblCategoria);
            this.pnlClientes.Controls.Add(this.cboDescBrick);
            this.pnlClientes.Controls.Add(this.txtCodBrick);
            this.pnlClientes.Controls.Add(this.lblBrick);
            this.pnlClientes.Controls.Add(this.cboRed);
            this.pnlClientes.Controls.Add(this.label1);
            this.pnlClientes.Controls.Add(this.txtApellidos2);
            this.pnlClientes.Controls.Add(this.lblApellido2);
            this.pnlClientes.Controls.Add(this.txtCodPostal);
            this.pnlClientes.Controls.Add(this.lblCodPostal);
            this.pnlClientes.Controls.Add(this.btnBuscPob);
            this.pnlClientes.Controls.Add(this.txbBPoblacion);
            this.pnlClientes.Controls.Add(this.lblCliente);
            this.pnlClientes.Controls.Add(this.cbTipoRelacionCentro);
            this.pnlClientes.Controls.Add(this.lblRel);
            this.pnlClientes.Controls.Add(this.txtsCentro);
            this.pnlClientes.Controls.Add(this.btBuscarCentro);
            this.pnlClientes.Controls.Add(this.txtsIdCentro);
            this.pnlClientes.Controls.Add(this.lblCentro);
            this.pnlClientes.Controls.Add(this.btBuscar);
            this.pnlClientes.Controls.Add(this.txtsIdCliente);
            this.pnlClientes.Controls.Add(this.cboMostrar);
            this.pnlClientes.Controls.Add(this.lblMostrar);
            this.pnlClientes.Controls.Add(this.txbApellidos1);
            this.pnlClientes.Controls.Add(this.txbNombre);
            this.pnlClientes.Controls.Add(this.cboTipo);
            this.pnlClientes.Controls.Add(this.lblApellido1);
            this.pnlClientes.Controls.Add(this.lblsIdCliente);
            this.pnlClientes.Controls.Add(this.lblNombre);
            this.pnlClientes.Controls.Add(this.lblTipo);
            this.pnlClientes.Controls.Add(this.txbIdPoblacion);
            this.pnlClientes.Location = new System.Drawing.Point(5, 5);
            this.pnlClientes.Name = "pnlClientes";
            this.pnlClientes.Size = new System.Drawing.Size(1026, 147);
            this.pnlClientes.TabIndex = 2;
            // 
            // cboArea
            // 
            this.cboArea.DataSource = this.listaTipoAreaBindingSource;
            this.cboArea.DisplayMember = "sLiteral";
            this.cboArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboArea.ItemHeight = 20;
            this.cboArea.Location = new System.Drawing.Point(297, 103);
            this.cboArea.Name = "cboArea";
            this.cboArea.Size = new System.Drawing.Size(134, 28);
            this.cboArea.TabIndex = 101;
            this.cboArea.ValueMember = "sValor";
            // 
            // listaTipoAreaBindingSource
            // 
            this.listaTipoAreaBindingSource.DataMember = "ListaTipoAreaCliSAP";
            this.listaTipoAreaBindingSource.DataSource = this.dsBuscar1;
            // 
            // lblArea
            // 
            this.lblArea.AutoSize = true;
            this.lblArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArea.Location = new System.Drawing.Point(250, 106);
            this.lblArea.Name = "lblArea";
            this.lblArea.Size = new System.Drawing.Size(63, 20);
            this.lblArea.TabIndex = 100;
            this.lblArea.Text = "Area:    ";
            // 
            // cboCategoria
            // 
            this.cboCategoria.DataSource = this.listaTipoClasificacioBindingSource1;
            this.cboCategoria.DisplayMember = "sLiteral";
            this.cboCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCategoria.ItemHeight = 20;
            this.cboCategoria.Location = new System.Drawing.Point(110, 103);
            this.cboCategoria.Name = "cboCategoria";
            this.cboCategoria.Size = new System.Drawing.Size(134, 28);
            this.cboCategoria.TabIndex = 99;
            this.cboCategoria.ValueMember = "sValor";
            // 
            // listaTipoClasificacioBindingSource1
            // 
            this.listaTipoClasificacioBindingSource1.DataMember = "ListaTipoClasificacion";
            this.listaTipoClasificacioBindingSource1.DataSource = this.dsBuscar1;
            // 
            // lblCategoria
            // 
            this.lblCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategoria.Location = new System.Drawing.Point(9, 106);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(102, 19);
            this.lblCategoria.TabIndex = 98;
            this.lblCategoria.Text = "Clasificación:";
            this.lblCategoria.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboDescBrick
            // 
            this.cboDescBrick.BackColor = System.Drawing.Color.White;
            this.cboDescBrick.DataSource = this.dsBuscar1.ListaBricks;
            this.cboDescBrick.DisplayMember = "sDescripcion";
            this.cboDescBrick.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDescBrick.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDescBrick.ForeColor = System.Drawing.Color.Black;
            this.cboDescBrick.Location = new System.Drawing.Point(550, 103);
            this.cboDescBrick.Name = "cboDescBrick";
            this.cboDescBrick.Size = new System.Drawing.Size(277, 28);
            this.cboDescBrick.TabIndex = 94;
            this.cboDescBrick.ValueMember = "sIdBrick";
            this.cboDescBrick.SelectedIndexChanged += new System.EventHandler(this.cboDescBrick_SelectedIndexChanged);
            // 
            // txtCodBrick
            // 
            this.txtCodBrick.BackColor = System.Drawing.Color.White;
            this.txtCodBrick.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodBrick.ForeColor = System.Drawing.Color.Black;
            this.txtCodBrick.Location = new System.Drawing.Point(485, 103);
            this.txtCodBrick.MaxLength = 10;
            this.txtCodBrick.Name = "txtCodBrick";
            this.txtCodBrick.Size = new System.Drawing.Size(64, 26);
            this.txtCodBrick.TabIndex = 97;
            this.txtCodBrick.TextChanged += new System.EventHandler(this.txtCodBrick_TextChanged);
            // 
            // lblBrick
            // 
            this.lblBrick.AutoSize = true;
            this.lblBrick.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBrick.Location = new System.Drawing.Point(437, 106);
            this.lblBrick.Name = "lblBrick";
            this.lblBrick.Size = new System.Drawing.Size(64, 20);
            this.lblBrick.TabIndex = 96;
            this.lblBrick.Text = "Brick:    ";
            // 
            // cboRed
            // 
            this.cboRed.BackColor = System.Drawing.Color.White;
            this.cboRed.DataSource = this.dsBuscar1.ListaRedes;
            this.cboRed.DisplayMember = "sLiteral";
            this.cboRed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboRed.ForeColor = System.Drawing.Color.Black;
            this.cboRed.Location = new System.Drawing.Point(665, 7);
            this.cboRed.Name = "cboRed";
            this.cboRed.Size = new System.Drawing.Size(191, 28);
            this.cboRed.TabIndex = 94;
            this.cboRed.ValueMember = "sValor";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(616, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 20);
            this.label1.TabIndex = 95;
            this.label1.Text = "Red:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtApellidos2
            // 
            this.txtApellidos2.BackColor = System.Drawing.Color.White;
            this.txtApellidos2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApellidos2.ForeColor = System.Drawing.Color.Black;
            this.txtApellidos2.Location = new System.Drawing.Point(277, 71);
            this.txtApellidos2.MaxLength = 100;
            this.txtApellidos2.Name = "txtApellidos2";
            this.txtApellidos2.Size = new System.Drawing.Size(150, 26);
            this.txtApellidos2.TabIndex = 93;
            // 
            // lblApellido2
            // 
            this.lblApellido2.AutoSize = true;
            this.lblApellido2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApellido2.Location = new System.Drawing.Point(200, 75);
            this.lblApellido2.Name = "lblApellido2";
            this.lblApellido2.Size = new System.Drawing.Size(78, 20);
            this.lblApellido2.TabIndex = 92;
            this.lblApellido2.Text = "Apellido2:";
            // 
            // txtCodPostal
            // 
            this.txtCodPostal.BackColor = System.Drawing.Color.White;
            this.txtCodPostal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodPostal.ForeColor = System.Drawing.Color.Black;
            this.txtCodPostal.Location = new System.Drawing.Point(476, 71);
            this.txtCodPostal.MaxLength = 5;
            this.txtCodPostal.Name = "txtCodPostal";
            this.txtCodPostal.Size = new System.Drawing.Size(64, 26);
            this.txtCodPostal.TabIndex = 9;
            this.txtCodPostal.TextChanged += new System.EventHandler(this.txtCodPostal_TextChanged);
            this.txtCodPostal.Leave += new System.EventHandler(this.txtCodPostal_Leave);
            // 
            // lblCodPostal
            // 
            this.lblCodPostal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodPostal.ForeColor = System.Drawing.Color.Black;
            this.lblCodPostal.Location = new System.Drawing.Point(434, 75);
            this.lblCodPostal.Name = "lblCodPostal";
            this.lblCodPostal.Size = new System.Drawing.Size(43, 16);
            this.lblCodPostal.TabIndex = 91;
            this.lblCodPostal.Text = "C.P.:";
            this.lblCodPostal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnBuscPob
            // 
            this.btnBuscPob.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscPob.Image")));
            this.btnBuscPob.Location = new System.Drawing.Point(900, 71);
            this.btnBuscPob.Name = "btnBuscPob";
            this.btnBuscPob.Size = new System.Drawing.Size(26, 26);
            this.btnBuscPob.TabIndex = 11;
            this.btnBuscPob.UseVisualStyleBackColor = true;
            this.btnBuscPob.Click += new System.EventHandler(this.btnBuscPob_Click);
            // 
            // txbBPoblacion
            // 
            this.txbBPoblacion.BackColor = System.Drawing.SystemColors.Window;
            this.txbBPoblacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbBPoblacion.ForeColor = System.Drawing.Color.Black;
            this.txbBPoblacion.Location = new System.Drawing.Point(629, 71);
            this.txbBPoblacion.MaxLength = 50;
            this.txbBPoblacion.Name = "txbBPoblacion";
            this.txbBPoblacion.Size = new System.Drawing.Size(270, 26);
            this.txbBPoblacion.TabIndex = 10;
            this.txbBPoblacion.TextChanged += new System.EventHandler(this.txbBPoblacion_TextChanged);
            this.txbBPoblacion.Leave += new System.EventHandler(this.txbBPoblacion_Leave);
            // 
            // lblCliente
            // 
            this.lblCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCliente.ForeColor = System.Drawing.Color.Black;
            this.lblCliente.Location = new System.Drawing.Point(546, 75);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(89, 20);
            this.lblCliente.TabIndex = 90;
            this.lblCliente.Text = "Poblacion:";
            this.lblCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbTipoRelacionCentro
            // 
            this.cbTipoRelacionCentro.DataSource = this.dsBuscar1.ListaRelacionClienteCentro;
            this.cbTipoRelacionCentro.DisplayMember = "Descripcion";
            this.cbTipoRelacionCentro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTipoRelacionCentro.Location = new System.Drawing.Point(826, 39);
            this.cbTipoRelacionCentro.Name = "cbTipoRelacionCentro";
            this.cbTipoRelacionCentro.Size = new System.Drawing.Size(188, 28);
            this.cbTipoRelacionCentro.TabIndex = 8;
            this.cbTipoRelacionCentro.ValueMember = "Valor";
            this.cbTipoRelacionCentro.SelectedIndexChanged += new System.EventHandler(this.cbTipoRelacionCentro_SelectedIndexChanged);
            // 
            // lblRel
            // 
            this.lblRel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRel.Location = new System.Drawing.Point(694, 42);
            this.lblRel.Name = "lblRel";
            this.lblRel.Size = new System.Drawing.Size(131, 18);
            this.lblRel.TabIndex = 17;
            this.lblRel.Text = "Relación  Centro:";
            this.lblRel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtsCentro
            // 
            this.txtsCentro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(230)))), ((int)(((byte)(239)))));
            this.txtsCentro.Enabled = false;
            this.txtsCentro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsCentro.ForeColor = System.Drawing.Color.Black;
            this.txtsCentro.Location = new System.Drawing.Point(466, 39);
            this.txtsCentro.Name = "txtsCentro";
            this.txtsCentro.Size = new System.Drawing.Size(192, 26);
            this.txtsCentro.TabIndex = 5;
            // 
            // btBuscarCentro
            // 
            this.btBuscarCentro.Image = ((System.Drawing.Image)(resources.GetObject("btBuscarCentro.Image")));
            this.btBuscarCentro.Location = new System.Drawing.Point(660, 39);
            this.btBuscarCentro.Name = "btBuscarCentro";
            this.btBuscarCentro.Size = new System.Drawing.Size(26, 26);
            this.btBuscarCentro.TabIndex = 6;
            this.toolTip1.SetToolTip(this.btBuscarCentro, "Buscar Centro");
            this.btBuscarCentro.UseVisualStyleBackColor = true;
            this.btBuscarCentro.Click += new System.EventHandler(this.btBuscarCentro_Click);
            // 
            // txtsIdCentro
            // 
            this.txtsIdCentro.BackColor = System.Drawing.Color.White;
            this.txtsIdCentro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsIdCentro.ForeColor = System.Drawing.Color.Black;
            this.txtsIdCentro.Location = new System.Drawing.Point(358, 39);
            this.txtsIdCentro.MaxLength = 20;
            this.txtsIdCentro.Name = "txtsIdCentro";
            this.txtsIdCentro.Size = new System.Drawing.Size(104, 26);
            this.txtsIdCentro.TabIndex = 4;
            this.txtsIdCentro.TabStop = false;
            this.txtsIdCentro.Leave += new System.EventHandler(this.txtsIdCentro_TextChanged);
            // 
            // lblCentro
            // 
            this.lblCentro.AutoSize = true;
            this.lblCentro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCentro.Location = new System.Drawing.Point(292, 42);
            this.lblCentro.Name = "lblCentro";
            this.lblCentro.Size = new System.Drawing.Size(61, 20);
            this.lblCentro.TabIndex = 12;
            this.lblCentro.Text = "Centro:";
            this.lblCentro.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btBuscar
            // 
            this.btBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btBuscar.Location = new System.Drawing.Point(941, 111);
            this.btBuscar.Name = "btBuscar";
            this.btBuscar.Size = new System.Drawing.Size(75, 28);
            this.btBuscar.TabIndex = 12;
            this.btBuscar.Text = "Buscar";
            this.btBuscar.UseVisualStyleBackColor = true;
            this.btBuscar.Click += new System.EventHandler(this.btBuscar_Click);
            // 
            // txtsIdCliente
            // 
            this.txtsIdCliente.BackColor = System.Drawing.Color.White;
            this.txtsIdCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsIdCliente.ForeColor = System.Drawing.Color.Black;
            this.txtsIdCliente.Location = new System.Drawing.Point(75, 7);
            this.txtsIdCliente.MaxLength = 20;
            this.txtsIdCliente.Name = "txtsIdCliente";
            this.txtsIdCliente.Size = new System.Drawing.Size(112, 26);
            this.txtsIdCliente.TabIndex = 0;
            this.txtsIdCliente.TextChanged += new System.EventHandler(this.txtsIdCliente_TextChanged);
            // 
            // cboMostrar
            // 
            this.cboMostrar.BackColor = System.Drawing.Color.White;
            this.cboMostrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMostrar.ForeColor = System.Drawing.Color.Black;
            this.cboMostrar.Location = new System.Drawing.Point(475, 7);
            this.cboMostrar.Name = "cboMostrar";
            this.cboMostrar.Size = new System.Drawing.Size(121, 28);
            this.cboMostrar.TabIndex = 2;
            this.cboMostrar.SelectedIndexChanged += new System.EventHandler(this.cboMostrar_SelectedIndexChanged);
            // 
            // lblMostrar
            // 
            this.lblMostrar.AutoSize = true;
            this.lblMostrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMostrar.Location = new System.Drawing.Point(402, 10);
            this.lblMostrar.Name = "lblMostrar";
            this.lblMostrar.Size = new System.Drawing.Size(67, 20);
            this.lblMostrar.TabIndex = 7;
            this.lblMostrar.Text = "Mostrar:";
            this.lblMostrar.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txbApellidos1
            // 
            this.txbApellidos1.BackColor = System.Drawing.Color.White;
            this.txbApellidos1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbApellidos1.ForeColor = System.Drawing.Color.Black;
            this.txbApellidos1.Location = new System.Drawing.Point(89, 71);
            this.txbApellidos1.MaxLength = 100;
            this.txbApellidos1.Name = "txbApellidos1";
            this.txbApellidos1.Size = new System.Drawing.Size(106, 26);
            this.txbApellidos1.TabIndex = 7;
            this.txbApellidos1.TextChanged += new System.EventHandler(this.txbApellidos_TextChanged);
            // 
            // txbNombre
            // 
            this.txbNombre.BackColor = System.Drawing.Color.White;
            this.txbNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbNombre.ForeColor = System.Drawing.Color.Black;
            this.txbNombre.Location = new System.Drawing.Point(75, 39);
            this.txbNombre.MaxLength = 50;
            this.txbNombre.Name = "txbNombre";
            this.txbNombre.Size = new System.Drawing.Size(216, 26);
            this.txbNombre.TabIndex = 3;
            this.txbNombre.TextChanged += new System.EventHandler(this.txbNombre_TextChanged);
            // 
            // cboTipo
            // 
            this.cboTipo.BackColor = System.Drawing.Color.White;
            this.cboTipo.DataSource = this.dsBuscar1.ListaTipoCliente;
            this.cboTipo.DisplayMember = "sLiteral";
            this.cboTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipo.ForeColor = System.Drawing.Color.Black;
            this.cboTipo.Location = new System.Drawing.Point(252, 7);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Size = new System.Drawing.Size(128, 28);
            this.cboTipo.TabIndex = 1;
            this.cboTipo.ValueMember = "sValor";
            this.cboTipo.SelectedIndexChanged += new System.EventHandler(this.cboTipo_SelectedIndexChanged);
            // 
            // lblApellido1
            // 
            this.lblApellido1.AutoSize = true;
            this.lblApellido1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApellido1.Location = new System.Drawing.Point(10, 75);
            this.lblApellido1.Name = "lblApellido1";
            this.lblApellido1.Size = new System.Drawing.Size(78, 20);
            this.lblApellido1.TabIndex = 2;
            this.lblApellido1.Text = "Apellido1:";
            // 
            // lblsIdCliente
            // 
            this.lblsIdCliente.AutoSize = true;
            this.lblsIdCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsIdCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblsIdCliente.Location = new System.Drawing.Point(10, 10);
            this.lblsIdCliente.Name = "lblsIdCliente";
            this.lblsIdCliente.Size = new System.Drawing.Size(63, 20);
            this.lblsIdCliente.TabIndex = 10;
            this.lblsIdCliente.Text = "Código:";
            this.lblsIdCliente.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblNombre.Location = new System.Drawing.Point(10, 42);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(69, 20);
            this.lblNombre.TabIndex = 3;
            this.lblNombre.Text = "Nombre:";
            this.lblNombre.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipo.Location = new System.Drawing.Point(206, 10);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(43, 20);
            this.lblTipo.TabIndex = 1;
            this.lblTipo.Text = "Tipo:";
            // 
            // txbIdPoblacion
            // 
            this.txbIdPoblacion.BackColor = System.Drawing.Color.White;
            this.txbIdPoblacion.ForeColor = System.Drawing.Color.Black;
            this.txbIdPoblacion.Location = new System.Drawing.Point(841, 119);
            this.txbIdPoblacion.Name = "txbIdPoblacion";
            this.txbIdPoblacion.Size = new System.Drawing.Size(72, 20);
            this.txbIdPoblacion.TabIndex = 13;
            this.txbIdPoblacion.Visible = false;
            // 
            // sqldaListaBuscaClientes
            // 
            this.sqldaListaBuscaClientes.SelectCommand = this.sqlSelectCommand1;
            this.sqldaListaBuscaClientes.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaBuscaClientes", new System.Data.Common.DataColumnMapping[] {
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
                        new System.Data.Common.DataColumnMapping("bPotencial_SAP", "bPotencial_SAP"),
                        new System.Data.Common.DataColumnMapping("xPotencial_SAP", "xPotencial_SAP"),
                        new System.Data.Common.DataColumnMapping("tProxObj", "tProxObj"),
                        new System.Data.Common.DataColumnMapping("GrupoClientes", "GrupoClientes"),
                        new System.Data.Common.DataColumnMapping("iIdArea", "iIdArea"),
                        new System.Data.Common.DataColumnMapping("sNombreArea", "sNombreArea")})});
            // 
            // sqlSelectCommand1
            // 
            this.sqlSelectCommand1.CommandText = "[ListaBuscaClientes]";
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
            new System.Data.SqlClient.SqlParameter("@sMostrarSap", System.Data.SqlDbType.VarChar, 1),
            new System.Data.SqlClient.SqlParameter("@sIdCentro", System.Data.SqlDbType.VarChar, 20),
            new System.Data.SqlClient.SqlParameter("@sIdTipoRelacionCliCen", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@iIdPoblacion", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sCodPostal", System.Data.SqlDbType.VarChar, 5),
            new System.Data.SqlClient.SqlParameter("@iIdProvincia", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sPoblacion", System.Data.SqlDbType.VarChar, 50),
            new System.Data.SqlClient.SqlParameter("@TipoVisita", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sIdRed", System.Data.SqlDbType.VarChar, 4),
            new System.Data.SqlClient.SqlParameter("@sIdBrick", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@sIdTipoClasificacion", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@iIdArea", System.Data.SqlDbType.Int, 4)});
            // 
            // sqlConn
            // 
            this.sqlConn.ConnectionString = Utiles._connection.ConnectionString.ToString();   //---- GSG (06/03/2021)
            this.sqlConn.FireInfoMessageEventOnUserErrors = false;
            // 
            // sqlSelectCommand1CECL
            // 
            this.sqlSelectCommand1CECL.CommandText = "[ListaBuscaClientesCECL]";
            this.sqlSelectCommand1CECL.CommandTimeout = 60;
            this.sqlSelectCommand1CECL.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand1CECL.Connection = this.sqlConn;
            this.sqlSelectCommand1CECL.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdDelegado", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sIdCliente", System.Data.SqlDbType.VarChar, 20),
            new System.Data.SqlClient.SqlParameter("@sTipoCliente", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@sNombre", System.Data.SqlDbType.VarChar, 50),
            new System.Data.SqlClient.SqlParameter("@sApellidos1", System.Data.SqlDbType.VarChar, 100),
            new System.Data.SqlClient.SqlParameter("@sApellidos2", System.Data.SqlDbType.VarChar, 100),
            new System.Data.SqlClient.SqlParameter("@sMostrarSap", System.Data.SqlDbType.VarChar, 1),
            new System.Data.SqlClient.SqlParameter("@sIdCentro", System.Data.SqlDbType.VarChar, 20),
            new System.Data.SqlClient.SqlParameter("@sIdTipoRelacionCliCen", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@iIdPoblacion", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sCodPostal", System.Data.SqlDbType.VarChar, 5),
            new System.Data.SqlClient.SqlParameter("@iIdProvincia", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sPoblacion", System.Data.SqlDbType.VarChar, 50),
            new System.Data.SqlClient.SqlParameter("@TipoVisita", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sIdRed", System.Data.SqlDbType.VarChar, 4),
            new System.Data.SqlClient.SqlParameter("@sIdBrick", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@sIdTipoClasificacion", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@sGrupoClientes", System.Data.SqlDbType.VarChar, 2),
            new System.Data.SqlClient.SqlParameter("@iIdArea", System.Data.SqlDbType.Int, 4)});
            // 
            // sqldaListaBuscaClientesSAP
            // 
            this.sqldaListaBuscaClientesSAP.SelectCommand = this.sqlSelectCommandClientesSAP;
            this.sqldaListaBuscaClientesSAP.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaBuscaClientesSAP", new System.Data.Common.DataColumnMapping[] {
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
                        new System.Data.Common.DataColumnMapping("bPotencial_SAP", "bPotencial_SAP"),
                        new System.Data.Common.DataColumnMapping("xPotencial_SAP", "xPotencial_SAP"),
                        new System.Data.Common.DataColumnMapping("tProxObj", "tProxObj"),
                        new System.Data.Common.DataColumnMapping("GrupoClientes", "GrupoClientes"),
                        new System.Data.Common.DataColumnMapping("iIdArea", "iIdArea"),
                        new System.Data.Common.DataColumnMapping("sNombreArea", "sNombreArea")})});
            // 
            // sqlSelectCommandClientesSAP
            // 
            this.sqlSelectCommandClientesSAP.CommandText = "[ListaBuscaClientesSAP]";
            this.sqlSelectCommandClientesSAP.CommandTimeout = 60;
            this.sqlSelectCommandClientesSAP.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommandClientesSAP.Connection = this.sqlConn;
            this.sqlSelectCommandClientesSAP.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdDelegado", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sIdCliente", System.Data.SqlDbType.VarChar, 20),
            new System.Data.SqlClient.SqlParameter("@sNombre", System.Data.SqlDbType.VarChar, 50),
            new System.Data.SqlClient.SqlParameter("@sApellidos1", System.Data.SqlDbType.VarChar, 100),
            new System.Data.SqlClient.SqlParameter("@sApellidos2", System.Data.SqlDbType.VarChar, 100),
            new System.Data.SqlClient.SqlParameter("@sMostrarSap", System.Data.SqlDbType.VarChar, 1),
            new System.Data.SqlClient.SqlParameter("@sIdCentro", System.Data.SqlDbType.VarChar, 20),
            new System.Data.SqlClient.SqlParameter("@sIdTipoRelacionCliCen", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@iIdPoblacion", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sCodPostal", System.Data.SqlDbType.VarChar, 5),
            new System.Data.SqlClient.SqlParameter("@iIdProvincia", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sPoblacion", System.Data.SqlDbType.VarChar, 50),
            new System.Data.SqlClient.SqlParameter("@TipoVisita", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sIdRed", System.Data.SqlDbType.VarChar, 4),
            new System.Data.SqlClient.SqlParameter("@sIdBrick", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@sIdTipoClasificacion", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@iIdArea", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.Int, 4)});
            // 
            // sqldaListaBuscaClientesCOM
            // 
            this.sqldaListaBuscaClientesCOM.SelectCommand = this.sqlSelectCommandClientesCOM;
            this.sqldaListaBuscaClientesCOM.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaBuscaClientesCOM", new System.Data.Common.DataColumnMapping[] {
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
                        new System.Data.Common.DataColumnMapping("bPotencial_SAP", "bPotencial_SAP"),
                        new System.Data.Common.DataColumnMapping("xPotencial_SAP", "xPotencial_SAP"),
                        new System.Data.Common.DataColumnMapping("tProxObj", "tProxObj"),
                        new System.Data.Common.DataColumnMapping("GrupoClientes", "GrupoClientes"),
                        new System.Data.Common.DataColumnMapping("iIdArea", "iIdArea"),
                        new System.Data.Common.DataColumnMapping("sNombreArea", "sNombreArea")})});
            // 
            // sqlSelectCommandClientesCOM
            // 
            this.sqlSelectCommandClientesCOM.CommandText = "[ListaBuscaClientesCOM]";
            this.sqlSelectCommandClientesCOM.CommandTimeout = 60;
            this.sqlSelectCommandClientesCOM.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommandClientesCOM.Connection = this.sqlConn;
            this.sqlSelectCommandClientesCOM.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdDelegado", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sIdCliente", System.Data.SqlDbType.VarChar, 20),
            new System.Data.SqlClient.SqlParameter("@sNombre", System.Data.SqlDbType.VarChar, 50),
            new System.Data.SqlClient.SqlParameter("@sApellidos1", System.Data.SqlDbType.VarChar, 100),
            new System.Data.SqlClient.SqlParameter("@sApellidos2", System.Data.SqlDbType.VarChar, 100),
            new System.Data.SqlClient.SqlParameter("@sMostrarSap", System.Data.SqlDbType.VarChar, 1),
            new System.Data.SqlClient.SqlParameter("@sIdCentro", System.Data.SqlDbType.VarChar, 20),
            new System.Data.SqlClient.SqlParameter("@sIdTipoRelacionCliCen", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@iIdPoblacion", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sCodPostal", System.Data.SqlDbType.VarChar, 5),
            new System.Data.SqlClient.SqlParameter("@iIdProvincia", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sPoblacion", System.Data.SqlDbType.VarChar, 50),
            new System.Data.SqlClient.SqlParameter("@TipoVisita", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sIdRed", System.Data.SqlDbType.VarChar, 4),
            new System.Data.SqlClient.SqlParameter("@sIdBrick", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@sIdTipoClasificacion", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@iIdArea", System.Data.SqlDbType.Int, 4)});
            // 
            // sqldaListaBuscaClientesTOT
            // 
            this.sqldaListaBuscaClientesTOT.SelectCommand = this.sqlSelectCommandClientesTOT;
            this.sqldaListaBuscaClientesTOT.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaBuscaClientesTOT", new System.Data.Common.DataColumnMapping[] {
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
                        new System.Data.Common.DataColumnMapping("bPotencial_SAP", "bPotencial_SAP"),
                        new System.Data.Common.DataColumnMapping("xPotencial_SAP", "xPotencial_SAP"),
                        new System.Data.Common.DataColumnMapping("tProxObj", "tProxObj"),
                        new System.Data.Common.DataColumnMapping("GrupoClientes", "GrupoClientes"),
                        new System.Data.Common.DataColumnMapping("iIdArea", "iIdArea"),
                        new System.Data.Common.DataColumnMapping("sNombreArea", "sNombreArea")})});
            // 
            // sqlSelectCommandClientesTOT
            // 
            this.sqlSelectCommandClientesTOT.CommandText = "[ListaBuscaClientesTOT]";
            this.sqlSelectCommandClientesTOT.CommandTimeout = 60;
            this.sqlSelectCommandClientesTOT.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommandClientesTOT.Connection = this.sqlConn;
            this.sqlSelectCommandClientesTOT.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdDelegado", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sIdCliente", System.Data.SqlDbType.VarChar, 20),
            new System.Data.SqlClient.SqlParameter("@sNombre", System.Data.SqlDbType.VarChar, 50),
            new System.Data.SqlClient.SqlParameter("@sApellidos1", System.Data.SqlDbType.VarChar, 100),
            new System.Data.SqlClient.SqlParameter("@sApellidos2", System.Data.SqlDbType.VarChar, 100),
            new System.Data.SqlClient.SqlParameter("@sMostrarSap", System.Data.SqlDbType.VarChar, 1),
            new System.Data.SqlClient.SqlParameter("@sIdCentro", System.Data.SqlDbType.VarChar, 20),
            new System.Data.SqlClient.SqlParameter("@sIdTipoRelacionCliCen", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@iIdPoblacion", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sCodPostal", System.Data.SqlDbType.VarChar, 5),
            new System.Data.SqlClient.SqlParameter("@iIdProvincia", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sPoblacion", System.Data.SqlDbType.VarChar, 50),
            new System.Data.SqlClient.SqlParameter("@TipoVisita", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sIdRed", System.Data.SqlDbType.VarChar, 4),
            new System.Data.SqlClient.SqlParameter("@sIdBrick", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@sIdTipoClasificacion", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@iIdArea", System.Data.SqlDbType.Int, 4)});
            // 
            // sqlSelectCommandClientesSAPCECL
            // 
            this.sqlSelectCommandClientesSAPCECL.CommandText = "[ListaBuscaClientesSAPCECL]";
            this.sqlSelectCommandClientesSAPCECL.CommandTimeout = 60;
            this.sqlSelectCommandClientesSAPCECL.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommandClientesSAPCECL.Connection = this.sqlConn;
            this.sqlSelectCommandClientesSAPCECL.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdDelegado", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sIdCliente", System.Data.SqlDbType.VarChar, 20),
            new System.Data.SqlClient.SqlParameter("@sNombre", System.Data.SqlDbType.VarChar, 50),
            new System.Data.SqlClient.SqlParameter("@sApellidos1", System.Data.SqlDbType.VarChar, 100),
            new System.Data.SqlClient.SqlParameter("@sApellidos2", System.Data.SqlDbType.VarChar, 100),
            new System.Data.SqlClient.SqlParameter("@sMostrarSap", System.Data.SqlDbType.VarChar, 1),
            new System.Data.SqlClient.SqlParameter("@sIdCentro", System.Data.SqlDbType.VarChar, 20),
            new System.Data.SqlClient.SqlParameter("@sIdTipoRelacionCliCen", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@iIdPoblacion", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sCodPostal", System.Data.SqlDbType.VarChar, 5),
            new System.Data.SqlClient.SqlParameter("@iIdProvincia", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sPoblacion", System.Data.SqlDbType.VarChar, 50),
            new System.Data.SqlClient.SqlParameter("@TipoVisita", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sIdRed", System.Data.SqlDbType.VarChar, 4),
            new System.Data.SqlClient.SqlParameter("@sIdBrick", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@sIdTipoClasificacion", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@iIdArea", System.Data.SqlDbType.Int, 4)});
            // 
            // sqldaListaTipoCliente
            // 
            this.sqldaListaTipoCliente.SelectCommand = this.sqlSelectCommand2;
            this.sqldaListaTipoCliente.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaTipoCliente", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("sValor", "sValor"),
                        new System.Data.Common.DataColumnMapping("sLiteral", "sLiteral")})});
            // 
            // sqlSelectCommand2
            // 
            this.sqlSelectCommand2.CommandText = "[ListaTipoCliente]";
            this.sqlSelectCommand2.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand2.Connection = this.sqlConn;
            this.sqlSelectCommand2.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null)});
            // 
            // sqldaListaBricks
            // 
            this.sqldaListaBricks.SelectCommand = this.sqlCmdListaBricks;
            this.sqldaListaBricks.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaBricks", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("sIdBrick", "sIdBrick"),
                        new System.Data.Common.DataColumnMapping("sDescripcion", "sDescripcion")})});
            // 
            // sqlCmdListaBricks
            // 
            this.sqlCmdListaBricks.CommandText = "[ListaBricks]";
            this.sqlCmdListaBricks.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdListaBricks.Connection = this.sqlConn;
            this.sqlCmdListaBricks.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@sIdBrick", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt, 2)});
            // 
            // sqlCmdListaBricksCECL
            // 
            this.sqlCmdListaBricksCECL.CommandText = "[ListaBricksCECL]";
            this.sqlCmdListaBricksCECL.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdListaBricksCECL.Connection = this.sqlConn;
            this.sqlCmdListaBricksCECL.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@sIdBrick", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt, 2),
            new System.Data.SqlClient.SqlParameter("@iIdDelegado", System.Data.SqlDbType.Int, 4)});
            // 
            // btAceptar
            // 
            this.btAceptar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAceptar.Location = new System.Drawing.Point(832, 551);
            this.btAceptar.Name = "btAceptar";
            this.btAceptar.Size = new System.Drawing.Size(88, 32);
            this.btAceptar.TabIndex = 11;
            this.btAceptar.Text = "Aceptar";
            this.btAceptar.UseVisualStyleBackColor = true;
            this.btAceptar.Click += new System.EventHandler(this.btAceptar_Click);
            // 
            // btCancelar
            // 
            this.btCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCancelar.Location = new System.Drawing.Point(934, 551);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(88, 32);
            this.btCancelar.TabIndex = 12;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // sqldaListaRelacionCliCen
            // 
            this.sqldaListaRelacionCliCen.SelectCommand = this.sqlSelectCommand3;
            this.sqldaListaRelacionCliCen.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaRelacionClienteCentro", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("Orden", "Orden"),
                        new System.Data.Common.DataColumnMapping("Valor", "Valor"),
                        new System.Data.Common.DataColumnMapping("Descripcion", "Descripcion")})});
            // 
            // sqlSelectCommand3
            // 
            this.sqlSelectCommand3.CommandText = "[ListaRelacionClienteCentro]";
            this.sqlSelectCommand3.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand3.Connection = this.sqlConn;
            this.sqlSelectCommand3.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null)});
            // 
            // pnBusqueda
            // 
            this.pnBusqueda.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnBusqueda.Controls.Add(this.lblNumReg);
            this.pnBusqueda.Controls.Add(this.labelGradient2);
            this.pnBusqueda.Controls.Add(this.dgClientes);
            this.pnBusqueda.Location = new System.Drawing.Point(5, 161);
            this.pnBusqueda.Name = "pnBusqueda";
            this.pnBusqueda.Size = new System.Drawing.Size(1026, 370);
            this.pnBusqueda.TabIndex = 13;
            // 
            // lblNumReg
            // 
            this.lblNumReg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.lblNumReg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblNumReg.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumReg.ForeColor = System.Drawing.Color.Black;
            this.lblNumReg.Location = new System.Drawing.Point(962, 0);
            this.lblNumReg.Name = "lblNumReg";
            this.lblNumReg.Size = new System.Drawing.Size(60, 18);
            this.lblNumReg.TabIndex = 89;
            this.lblNumReg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelGradient2
            // 
            this.labelGradient2.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelGradient2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGradient2.ForeColor = System.Drawing.Color.White;
            this.labelGradient2.GradientColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.labelGradient2.GradientColorTwo = System.Drawing.Color.White;
            this.labelGradient2.Location = new System.Drawing.Point(0, 0);
            this.labelGradient2.Name = "labelGradient2";
            this.labelGradient2.Size = new System.Drawing.Size(1022, 18);
            this.labelGradient2.TabIndex = 88;
            this.labelGradient2.Text = "Resultado de la Búsqueda";
            this.labelGradient2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sqlSelectCommand4
            // 
            this.sqlSelectCommand4.CommandText = "[ListaRedes]";
            this.sqlSelectCommand4.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand4.Connection = this.sqlConn;
            // 
            // sqlSelectCommand4CECL
            // 
            this.sqlSelectCommand4CECL.CommandText = "[ListaRedesCECL]";
            this.sqlSelectCommand4CECL.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand4CECL.Connection = this.sqlConn;
            // 
            // sqldaListaRedes
            // 
            this.sqldaListaRedes.SelectCommand = this.sqlSelectCommand4;
            this.sqldaListaRedes.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaRedes", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("sValor", "sValor"),
                        new System.Data.Common.DataColumnMapping("sLiteral", "sLiteral")})});
            // 
            // sqldaListaTipoClasificacion
            // 
            this.sqldaListaTipoClasificacion.SelectCommand = this.sqlSelectCmdTipoClasificacion;
            this.sqldaListaTipoClasificacion.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaTipoClasificacion", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("sValor", "sValor"),
                        new System.Data.Common.DataColumnMapping("sLiteral", "sLiteral")})});
            // 
            // sqlSelectCmdTipoClasificacion
            // 
            this.sqlSelectCmdTipoClasificacion.CommandText = "[ListaTipoClasificacion]";
            this.sqlSelectCmdTipoClasificacion.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCmdTipoClasificacion.Connection = this.sqlConn;
            this.sqlSelectCmdTipoClasificacion.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null)});
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
            // frmMClientesSAP
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(230)))), ((int)(((byte)(239)))));
            this.ClientSize = new System.Drawing.Size(1038, 590);
            this.Controls.Add(this.pnBusqueda);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.btAceptar);
            this.Controls.Add(this.pnlClientes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMClientesSAP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Búsqueda de Clientes";
            this.Load += new System.EventHandler(this.frmMClientesSAP_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgClientes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBuscar1)).EndInit();
            this.pnlClientes.ResumeLayout(false);
            this.pnlClientes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listaTipoAreaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listaTipoClasificacioBindingSource1)).EndInit();
            this.pnBusqueda.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void frmMClientesSAP_Load(object sender, System.EventArgs e)
		{
			try
			{
//				this.Var_FormOrigen = this.ParentForm.Name.ToString();
//				this.label1.Text = this.Var_FormOrigen;
				GESTCRM.Utiles.Formatear_DataGrid(this,this.dgClientes,"C",true);

				Inicializa_cboRed();
				this.cboRed.SelectedValue= Clases.Configuracion.sIdRed ;
				if(Clases.Configuracion.iTodosClientes==0 ) this.cboRed.Enabled=false;//La red queda Fijada


				Inicializa_cboTipo();
                //---- GSG (29/08/2019)
                //this.cboTipo.SelectedValue=this.ParamI_sIdTipoCliente;
                //if (this.ParamI_sIdTipoCliente != "T") this.cboTipo.Enabled = false;//El Tipo queda Fijado
                this.cboTipo.SelectedValue = "S";
                this.cboTipo.Enabled = false;
                //---- FI GSG 


                

				Inicializa_cboMostrar();
                //---- GSG (28/07/2011) Por defecto TODOS
                //if(this.Param_Origen=="R") this.cboMostrar.SelectedValue=-1; 
                //else this.cboMostrar.SelectedValue=0;
                this.cboMostrar.SelectedValue = -1;
                
                //---- GSG (28/07/2011)
                Inicializa_cboBricks();
                this.cboDescBrick.SelectedValue = -1;
                //---- GSG (31/01/2012)
                Inicializa_cboCategoria();
                this.cboCategoria.SelectedValue = -1;
                //---- GSG (31/05/2013)
                Inicializa_cboArea();
                this.cboArea.SelectedValue = -1;
                //---- FI GSG

				this.txtsIdCliente.Text = this.ParamIO_sIdCliente;

				this.txtsIdCentro.Text = this.ParamI_sIdCentro;
				if(this.ParamI_sIdCentro.Trim().Length>0) this.BuscarConCentro=1;
				else this.BuscarConCentro=0;
			
				if(this.BuscarConCentro==1)
				{
					Buscar_NombreCentro();
					this.txtsIdCentro.Enabled=false;
					this.btBuscarCentro.Enabled=false;
				}

				this.sqldaListaRelacionCliCen.Fill(this.dsBuscar1);
				// Tipo Relacion con el Centro = 0 -> Propio
				this.cbTipoRelacionCentro.SelectedValue="-2"; 

				Formatear_Campos(this.ParamI_sIdTipoCliente);

				Formatear_dgClientes();

                //---- GSG (23/03/2012)
                //BuscarClientes();
                if (this.Param_Origen != "A")
				    BuscarClientes();
                //---- FI GSG

				Crear_dtSeleccion();


			}
			catch(Exception ex)
			{
				Mensajes.ShowError(ex.Message);
			}
		}

		#region Crear_dtSeleccion
		private void Crear_dtSeleccion()
		{
			this.dtSeleccion = new DataTable();
			this.dtSeleccion.Columns.Add("iIdCliente");
			this.dtSeleccion.Columns.Add("sIdCliente");
			this.dtSeleccion.Columns.Add("tNombre");
			this.dtSeleccion.Columns.Add("tProxObj");
		}
		#endregion

		#region Recuperar_Seleccion
		private void Recuperar_Seleccion()
		{
			for(int i=0;i<this.dsBuscar1.ListaBuscaClientes.Rows.Count;i++)
			{
				if(this.dgClientes.IsSelected(i))
				{
					DataRow fila = this.dtSeleccion.NewRow();
					fila["iIdCliente"]=this.dgClientes[i,3];
					fila["sIdCliente"]=this.dgClientes[i,0];
					fila["tNombre"]=this.dgClientes[i,2];
					fila["tProxObj"]=this.dgClientes[i,4];

					this.dtSeleccion.Rows.Add(fila);
				}
			}
		}
		#endregion


		#region Inicializa_cboTipo
		private void Inicializa_cboTipo()
		{
			try
			{
				this.sqldaListaTipoCliente.Fill(this.dsBuscar1);
				DataRow filaTodos = this.dsBuscar1.ListaTipoCliente.NewRow();
				filaTodos["sValor"]="T";
				filaTodos["sLiteral"]="Todos";
				this.dsBuscar1.ListaTipoCliente.Rows.InsertAt(filaTodos,0);
			}
			catch (Exception ex)
			{
				Mensajes.ShowError(ex.Message);
			}
		}
		#endregion
		#region Inicializa_cboRed
		private void Inicializa_cboRed()
		{
			try
			{
                //---- GSG CECL 19/05/2016
                if (System.Configuration.ConfigurationManager.AppSettings["TipoDelegadoPedidosCentral"].ToString() == Comun.K_CECL)
                    sqldaListaRedes.SelectCommand = sqlSelectCommand4CECL;
                else
                    sqldaListaRedes.SelectCommand = sqlSelectCommand4;
                //---- FI GSG CECL

				this.sqldaListaRedes.Fill(this.dsBuscar1);
				DataRow filaTodos = this.dsBuscar1.ListaRedes.NewRow();
				filaTodos["sValor"]="T";
				filaTodos["sLiteral"]="Todos";
				this.dsBuscar1.ListaRedes.Rows.InsertAt(filaTodos,0);
				
			}
			catch (Exception ex)
			{
				Mensajes.ShowError(ex.Message);
			}
		}
		#endregion


        #region Inicializa_cboBricks
        private void Inicializa_cboBricks()
        {
            try
            {
                //---- GSG CECL 19/05/2016
                if (System.Configuration.ConfigurationManager.AppSettings["TipoDelegadoPedidosCentral"].ToString() == Comun.K_CECL)
                {
                    sqldaListaBricks.SelectCommand = sqlCmdListaBricksCECL;
                    sqldaListaBricks.SelectCommand.Parameters["@iIdDelegado"].Value = this.ParamI_iIdDelegado;
                }
                else
                    sqldaListaBricks.SelectCommand = sqlCmdListaBricks;
                //---- FI GSG CECL

                this.sqldaListaBricks.Fill(this.dsBuscar1);
                DataRow filaTodos = this.dsBuscar1.ListaBricks.NewRow();
                filaTodos["sIdBrick"] = "T";
                filaTodos["sDescripcion"] = "Todos";
                this.dsBuscar1.ListaBricks.Rows.InsertAt(filaTodos, 0);
            }
            catch (Exception ex)
            {
                Mensajes.ShowError(ex.Message);
            }
        }
        #endregion

        //---- GSG (31/01/2012)
        #region Inicializa_cboCategoria
        private void Inicializa_cboCategoria()
        {
            try
            {
                this.sqldaListaTipoClasificacion.Fill(this.dsBuscar1);
                DataRow filaTodos = this.dsBuscar1.ListaTipoClasificacion.NewRow();
                filaTodos["sValor"] = "T";
                filaTodos["sLiteral"] = "Todos";
                this.dsBuscar1.ListaTipoClasificacion.Rows.InsertAt(filaTodos, 0);
            }
            catch (Exception ex)
            {
                Mensajes.ShowError(ex.Message);
            }
        }
        #endregion
        //---- FI GSG

        //---- GSG (31/05/2013)
        #region Inicializa_cboArea
        private void Inicializa_cboArea()
        {
            try
            {
                this.sqldaListaTipoAreasClienteSAP.Fill(this.dsBuscar1);
                DataRow filaTodos = this.dsBuscar1.ListaTipoAreaCliSAP.NewRow();
                filaTodos["sValor"] = -1;
                filaTodos["sLiteral"] = "Todas";
                this.dsBuscar1.ListaTipoAreaCliSAP.Rows.InsertAt(filaTodos, 0);
            }
            catch (Exception ex)
            {
                Mensajes.ShowError(ex.Message);
            }
        }
        #endregion
        //---- FI GSG

		#region Inicializa_cboMostrar
		private void Inicializa_cboMostrar()
		{
			try
			{
				dtMostrar = new DataTable();
				dtMostrar.Columns.Add("Valor");
				dtMostrar.Columns.Add("Texto");

				DataRow fila0 = dtMostrar.NewRow();
				fila0["Valor"]=-1;
				fila0["Texto"]="Todos";
				dtMostrar.Rows.InsertAt(fila0,0);
			
				DataRow fila1 = dtMostrar.NewRow();
				fila1["Valor"]=0;
				fila1["Texto"]="Real";
				dtMostrar.Rows.InsertAt(fila1,1);
			
				DataRow fila2 = dtMostrar.NewRow();
				fila2["Valor"]=1;
				fila2["Texto"]="Potencial";
				dtMostrar.Rows.InsertAt(fila2,2);

				this.cboMostrar.DataSource = dtMostrar;
				this.cboMostrar.DisplayMember="Texto";
				this.cboMostrar.ValueMember="Valor";
			}
			catch(Exception ex)
			{
				Mensajes.ShowError(ex.Message);
			}
		}
		#endregion

		#region Formatear_Campos
		private void Formatear_Campos(string TipoCli)
		{
			try
			{
                //---- GSG (03/07/2019) Como no se usa ....
				//switch (TipoCli)
				//{
				//	case "S"://Cliente SAP
				//		this.lblMostrar.Visible=true; //Visible el campo de Cliente Potencial
				//		this.cboMostrar.Visible=true;
				//		this.txbApellidos1.Text=null; //No tiene Apellidos
				//		this.lblApellido1.Visible=false;
				//		this.txbApellidos1.Visible=false;
				//		this.txtApellidos2.Text=null; 
				//		this.lblApellido2.Visible=false;
				//		this.txtApellidos2.Visible=false;
				//		this.txtsIdCentro.Text=null; // No tiene Centros
				//		this.lblCentro.Visible=false;
				//		this.txtsIdCentro.Visible=false;
				//		this.txtsCentro.Visible=false;
				//		this.btBuscarCentro.Visible=false;
				//		this.cbTipoRelacionCentro.SelectedValue="-1";
				//		this.cbTipoRelacionCentro.Visible=false;
				//		this.lblRel.Visible=false;
    //                    //---- GSG (02/09/2011)
    //                    this.lblBrick.Visible = true;
    //                    this.txtCodBrick.Visible = true;
    //                    this.cboDescBrick.Visible = true;
    //                    //---- FI GSG
				//		break;
				//	case "C":				
				//		this.cboMostrar.SelectedValue=0;//No tiene campo de Cliente POtencial
				//		this.lblMostrar.Visible=false;
				//		this.cboMostrar.Visible=false;
				//		this.lblApellido1.Visible=true;//Visible Apellidos
				//		this.txbApellidos1.Visible=true;
				//		this.lblApellido2.Visible=true;
				//		this.txtApellidos2.Visible=true;
				//		this.lblCentro.Visible=true;//Visible Centro
				//		this.txtsIdCentro.Visible=true;
				//		this.txtsCentro.Visible=true;
				//		this.btBuscarCentro.Visible=true;
				//		if(!this.cbTipoRelacionCentro.Visible)
				//		{
				//			this.cbTipoRelacionCentro.SelectedValue="-2";
				//			this.cbTipoRelacionCentro.Visible=true;
				//			this.lblRel.Visible=true;
				//		}
    //                    //---- GSG (02/09/2011)
    //                    this.lblBrick.Visible = false;
    //                    this.txtCodBrick.Visible = false;
    //                    this.cboDescBrick.Visible = false;
    //                    //---- FI GSG
				//		break;
				//	default:				
				//		this.lblMostrar.Visible=true;
				//		this.cboMostrar.Visible=true;
				//		this.lblApellido1.Visible=true;
				//		this.txbApellidos1.Visible=true;
				//		this.lblApellido2.Visible=true;
				//		this.txtApellidos2.Visible=true;
				//		this.lblCentro.Visible=true;
				//		this.txtsIdCentro.Visible=true;
				//		this.txtsCentro.Visible=true;
				//		this.btBuscarCentro.Visible=true;
				//		if(!this.cbTipoRelacionCentro.Visible)
				//		{
				//			this.cbTipoRelacionCentro.SelectedValue="0";
				//			this.cbTipoRelacionCentro.Visible=true;
				//			this.lblRel.Visible=true;
				//		}
    //                    //---- GSG (02/09/2011)
    //                    this.lblBrick.Visible = false;
    //                    this.txtCodBrick.Visible = false;
    //                    this.cboDescBrick.Visible = false;
    //                    //---- FI GSG
				//		break;
				//}


                this.lblMostrar.Visible = true; //Visible el campo de Cliente Potencial
                this.cboMostrar.Visible = true;
                this.txbApellidos1.Text = null; //No tiene Apellidos
                this.lblApellido1.Visible = false;
                this.txbApellidos1.Visible = false;
                this.txtApellidos2.Text = null;
                this.lblApellido2.Visible = false;
                this.txtApellidos2.Visible = false;
                this.txtsIdCentro.Text = null; // No tiene Centros
                this.lblCentro.Visible = false;
                this.txtsIdCentro.Visible = false;
                this.txtsCentro.Visible = false;
                this.btBuscarCentro.Visible = false;
                this.cbTipoRelacionCentro.SelectedValue = "-1";
                this.cbTipoRelacionCentro.Visible = false;
                this.lblRel.Visible = false;
                this.lblBrick.Visible = true;
                this.txtCodBrick.Visible = true;
                this.cboDescBrick.Visible = true;


            }
            catch (Exception ex)
			{
				Mensajes.ShowError(ex.Message);
			}
		}
		#endregion

		#region Formatear_dgClientes
		private void Formatear_dgClientes()
		{
			try
			{
				for(int i=0; i< this.dgClientes.TableStyles[0].GridColumnStyles.Count;i++)
				{
					DataGridTextBoxColumn TextCol = (DataGridTextBoxColumn)dgClientes.TableStyles[0].GridColumnStyles[i];
					TextCol.TextBox.DoubleClick += new EventHandler(dgClientes_DoubleClick);			
				}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion
		
		#region BuscarClientes
        private void BuscarClientes()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                string tsIdCliente = null;
                string tsNombre = null;
                string tsApellidos1 = null;
                string tsApellidos2 = null;
                string tsIdCentro = null;
                string bPotencial = this.cboMostrar.SelectedValue.ToString();
                if (bPotencial == "-1") bPotencial = null;
                string tsTipoCliente = null;

                if (this.txtsIdCliente.Text.ToString().Trim().Length > 0) tsIdCliente = this.txtsIdCliente.Text.ToString();
                if (this.txbNombre.Text.ToString().Trim().Length > 0) tsNombre = this.txbNombre.Text.ToString();
                if (this.txbApellidos1.Text.ToString().Trim().Length > 0) tsApellidos1 = this.txbApellidos1.Text.ToString();
                if (this.txtApellidos2.Text.ToString().Trim().Length > 0) tsApellidos2 = this.txtApellidos2.Text.ToString();
                if (this.txtsIdCentro.Text.ToString().Trim().Length > 0) tsIdCentro = this.txtsIdCentro.Text.ToString();
                tsTipoCliente = this.cboTipo.SelectedValue.ToString();

                this.dsBuscar1.ListaBuscaClientes.Clear();

                //---- GSG CECL 19/05/2016
                if (System.Configuration.ConfigurationManager.AppSettings["TipoDelegadoPedidosCentral"].ToString() == Comun.K_CECL)
                    sqldaListaBuscaClientesSAP.SelectCommand = sqlSelectCommandClientesSAPCECL;
                else
                    sqldaListaBuscaClientesSAP.SelectCommand = sqlSelectCommandClientesSAP;
                //---- FI GSG CECL


                tsTipoCliente = "S"; //---- GSG (29/08/2019) Ya no tiene sentido los médicos 

                if (tsTipoCliente == "S")
                {
                    this.dsBuscar1.ListaBuscaClientesSAP.Rows.Clear();

                    //---- GSG CECL 19/05/2016
                    //this.sqldaListaBuscaClientesSAP.SelectCommand.Parameters["@iIdDelegado"].Value = this.ParamI_iIdDelegado;
                    if (System.Configuration.ConfigurationManager.AppSettings["TipoDelegadoPedidosCentral"].ToString() == Comun.K_CECL)
                        this.sqldaListaBuscaClientesSAP.SelectCommand.Parameters["@iIdDelegado"].Value = -1;
                    else
                        this.sqldaListaBuscaClientesSAP.SelectCommand.Parameters["@iIdDelegado"].Value = this.ParamI_iIdDelegado;
                    //---- FI GSG CECL

                    this.sqldaListaBuscaClientesSAP.SelectCommand.Parameters["@sIdCliente"].Value = tsIdCliente;
                    this.sqldaListaBuscaClientesSAP.SelectCommand.Parameters["@sNombre"].Value = tsNombre;
                    this.sqldaListaBuscaClientesSAP.SelectCommand.Parameters["@sApellidos1"].Value = tsApellidos1;
                    this.sqldaListaBuscaClientesSAP.SelectCommand.Parameters["@sApellidos2"].Value = tsApellidos2;
                    this.sqldaListaBuscaClientesSAP.SelectCommand.Parameters["@sMostrarSap"].Value = bPotencial;
                    this.sqldaListaBuscaClientesSAP.SelectCommand.Parameters["@sIdCentro"].Value = tsIdCentro;
                    this.sqldaListaBuscaClientesSAP.SelectCommand.Parameters["@sIdTipoRelacionCliCen"].Value = this.cbTipoRelacionCentro.SelectedValue.ToString();
                    this.sqldaListaBuscaClientesSAP.SelectCommand.Parameters["@TipoVisita"].Value = this.ParamI_TipoVisita;
                    this.sqldaListaBuscaClientesSAP.SelectCommand.Parameters["@sIdRed"].Value = this.cboRed.SelectedValue.ToString();

                    if (this.cboDescBrick.SelectedValue != null)
                        this.sqldaListaBuscaClientesSAP.SelectCommand.Parameters["@sIdBrick"].Value = this.cboDescBrick.SelectedValue.ToString();
                    else
                    {
                        txtCodBrick.Text = "";
                        this.sqldaListaBuscaClientesSAP.SelectCommand.Parameters["@sIdBrick"].Value = "T";
                    }

                    if (this.txbIdPoblacion.Text.ToString() == "")
                        this.sqldaListaBuscaClientesSAP.SelectCommand.Parameters["@iIdPoblacion"].Value = -1;
                    else
                        this.sqldaListaBuscaClientesSAP.SelectCommand.Parameters["@iIdPoblacion"].Value = int.Parse(txbIdPoblacion.Text.ToString());

                    this.sqldaListaBuscaClientesSAP.SelectCommand.Parameters["@sCodPostal"].Value = (this.txtCodPostal.Text.ToString() == "") ? "-1" : txtCodPostal.Text;
                    this.sqldaListaBuscaClientesSAP.SelectCommand.Parameters["@sPoblacion"].Value = (this.txbBPoblacion.Text.ToString() == "") ? null : txbBPoblacion.Text;
                    this.sqldaListaBuscaClientesSAP.SelectCommand.Parameters["@sIdTipoClasificacion"].Value = this.cboCategoria.SelectedValue.ToString();
                    this.sqldaListaBuscaClientesSAP.SelectCommand.Parameters["@iIdArea"].Value = int.Parse(this.cboArea.SelectedValue.ToString());
                    //---- GSG (28/06/2016)
                    if (System.Configuration.ConfigurationManager.AppSettings["TipoDelegadoPedidosCentral"].ToString() != Comun.K_CECL)
                    {
                        if (this.Param_Origen == "CP") // Consulta pedidos: tienen que salir todos los clientes, activos e inactivos
                            this.sqldaListaBuscaClientesSAP.SelectCommand.Parameters["@iEstado"].Value = -2;
                        else if (this.Param_Origen == "P") // Nuevo pedido: sólo clientes activos
                            this.sqldaListaBuscaClientesSAP.SelectCommand.Parameters["@iEstado"].Value = 0;
                        else // activos en cualquier otro caso 
                            this.sqldaListaBuscaClientesSAP.SelectCommand.Parameters["@iEstado"].Value = 0;
                    }

                    Application.DoEvents();
                    this.sqldaListaBuscaClientesSAP.Fill(this.dsBuscar1.ListaBuscaClientesSAP);
                    if (this.dsBuscar1.ListaBuscaClientesSAP.Rows.Count > 0)
                    {
                        this.dgClientes.CurrentCell = new DataGridCell(0, 1);
                        this.dgClientes.CurrentCell = new DataGridCell(0, 0);

                        
                        this.sqldaListaBuscaClientes = sqldaListaBuscaClientesSAP;
                        this.sqldaListaBuscaClientes.Fill(this.dsBuscar1.ListaBuscaClientes);
                        this.lblNumReg.Text = this.dsBuscar1.ListaBuscaClientes.Rows.Count.ToString();

                        this.lblNumReg.Text = this.dsBuscar1.ListaBuscaClientes.Rows.Count.ToString();
                    }
                    else
                        this.lblNumReg.Text = "0";
                }
                //---- GSG (03/07/2019) Como no se usa ...
                //else if (tsTipoCliente == "C")
                //{
                //    this.dsBuscar1.ListaBuscaClientesCOM.Rows.Clear();

                //    this.sqldaListaBuscaClientesCOM.SelectCommand.Parameters["@iIdDelegado"].Value = this.ParamI_iIdDelegado;
                //    this.sqldaListaBuscaClientesCOM.SelectCommand.Parameters["@sIdCliente"].Value = tsIdCliente;
                //    this.sqldaListaBuscaClientesCOM.SelectCommand.Parameters["@sNombre"].Value = tsNombre;
                //    this.sqldaListaBuscaClientesCOM.SelectCommand.Parameters["@sApellidos1"].Value = tsApellidos1;
                //    this.sqldaListaBuscaClientesCOM.SelectCommand.Parameters["@sApellidos2"].Value = tsApellidos2;
                //    this.sqldaListaBuscaClientesCOM.SelectCommand.Parameters["@sMostrarSap"].Value = bPotencial;
                //    this.sqldaListaBuscaClientesCOM.SelectCommand.Parameters["@sIdCentro"].Value = tsIdCentro;
                //    this.sqldaListaBuscaClientesCOM.SelectCommand.Parameters["@sIdTipoRelacionCliCen"].Value = this.cbTipoRelacionCentro.SelectedValue.ToString();
                //    this.sqldaListaBuscaClientesCOM.SelectCommand.Parameters["@TipoVisita"].Value = this.ParamI_TipoVisita;
                //    this.sqldaListaBuscaClientesCOM.SelectCommand.Parameters["@sIdRed"].Value = this.cboRed.SelectedValue.ToString();

                //    if (this.cboDescBrick.SelectedValue != null)
                //        this.sqldaListaBuscaClientesCOM.SelectCommand.Parameters["@sIdBrick"].Value = this.cboDescBrick.SelectedValue.ToString();
                //    else
                //    {
                //        txtCodBrick.Text = "";
                //        this.sqldaListaBuscaClientesCOM.SelectCommand.Parameters["@sIdBrick"].Value = "T";
                //    }

                //    if (this.txbIdPoblacion.Text.ToString() == "")
                //        this.sqldaListaBuscaClientesCOM.SelectCommand.Parameters["@iIdPoblacion"].Value = -1;
                //    else
                //        this.sqldaListaBuscaClientesCOM.SelectCommand.Parameters["@iIdPoblacion"].Value = int.Parse(txbIdPoblacion.Text.ToString());

                //    this.sqldaListaBuscaClientesCOM.SelectCommand.Parameters["@sCodPostal"].Value = (this.txtCodPostal.Text.ToString() == "") ? "-1" : txtCodPostal.Text;
                //    this.sqldaListaBuscaClientesCOM.SelectCommand.Parameters["@sPoblacion"].Value = (this.txbBPoblacion.Text.ToString() == "") ? null : txbBPoblacion.Text;
                //    this.sqldaListaBuscaClientesCOM.SelectCommand.Parameters["@sIdTipoClasificacion"].Value = this.cboCategoria.SelectedValue.ToString();
                //    this.sqldaListaBuscaClientesCOM.SelectCommand.Parameters["@iIdArea"].Value = int.Parse(this.cboArea.SelectedValue.ToString());


                //    Application.DoEvents();
                //    this.sqldaListaBuscaClientesCOM.Fill(this.dsBuscar1.ListaBuscaClientesCOM);
                //    if (this.dsBuscar1.ListaBuscaClientesCOM.Rows.Count > 0)
                //    {
                //        this.dgClientes.CurrentCell = new DataGridCell(0, 1);
                //        this.dgClientes.CurrentCell = new DataGridCell(0, 0);
                //        this.lblNumReg.Text = this.dsBuscar1.ListaBuscaClientesCOM.Rows.Count.ToString();
                //        this.sqldaListaBuscaClientes = sqldaListaBuscaClientesCOM;
                //        this.sqldaListaBuscaClientes.Fill(this.dsBuscar1.ListaBuscaClientes);
                //    }
                //    else
                //        this.lblNumReg.Text = "0";
                //}
                //else
                
                //{
                //    this.dsBuscar1.ListaBuscaClientesTOT.Rows.Clear();

                //    this.sqldaListaBuscaClientesTOT.SelectCommand.Parameters["@iIdDelegado"].Value = this.ParamI_iIdDelegado;
                //    this.sqldaListaBuscaClientesTOT.SelectCommand.Parameters["@sIdCliente"].Value = tsIdCliente;
                //    this.sqldaListaBuscaClientesTOT.SelectCommand.Parameters["@sNombre"].Value = tsNombre;
                //    this.sqldaListaBuscaClientesTOT.SelectCommand.Parameters["@sApellidos1"].Value = tsApellidos1;
                //    this.sqldaListaBuscaClientesTOT.SelectCommand.Parameters["@sApellidos2"].Value = tsApellidos2;
                //    this.sqldaListaBuscaClientesTOT.SelectCommand.Parameters["@sMostrarSap"].Value = bPotencial;
                //    this.sqldaListaBuscaClientesTOT.SelectCommand.Parameters["@sIdCentro"].Value = tsIdCentro;
                //    this.sqldaListaBuscaClientesTOT.SelectCommand.Parameters["@sIdTipoRelacionCliCen"].Value = this.cbTipoRelacionCentro.SelectedValue.ToString();
                //    this.sqldaListaBuscaClientesTOT.SelectCommand.Parameters["@TipoVisita"].Value = this.ParamI_TipoVisita;
                //    this.sqldaListaBuscaClientesTOT.SelectCommand.Parameters["@sIdRed"].Value = this.cboRed.SelectedValue.ToString();

                //    if (this.cboDescBrick.SelectedValue != null)
                //        this.sqldaListaBuscaClientesTOT.SelectCommand.Parameters["@sIdBrick"].Value = this.cboDescBrick.SelectedValue.ToString();
                //    else
                //    {
                //        txtCodBrick.Text = "";
                //        this.sqldaListaBuscaClientesTOT.SelectCommand.Parameters["@sIdBrick"].Value = "T";
                //    }

                //    if (this.txbIdPoblacion.Text.ToString() == "")
                //        this.sqldaListaBuscaClientesTOT.SelectCommand.Parameters["@iIdPoblacion"].Value = -1;
                //    else
                //        this.sqldaListaBuscaClientesTOT.SelectCommand.Parameters["@iIdPoblacion"].Value = int.Parse(txbIdPoblacion.Text.ToString());

                //    this.sqldaListaBuscaClientesTOT.SelectCommand.Parameters["@sCodPostal"].Value = (this.txtCodPostal.Text.ToString() == "") ? "-1" : txtCodPostal.Text;
                //    this.sqldaListaBuscaClientesTOT.SelectCommand.Parameters["@sPoblacion"].Value = (this.txbBPoblacion.Text.ToString() == "") ? null : txbBPoblacion.Text;
                //    this.sqldaListaBuscaClientesTOT.SelectCommand.Parameters["@sIdTipoClasificacion"].Value = this.cboCategoria.SelectedValue.ToString();
                //    this.sqldaListaBuscaClientesTOT.SelectCommand.Parameters["@iIdArea"].Value = int.Parse(this.cboArea.SelectedValue.ToString());

                //    Application.DoEvents();
                //    this.sqldaListaBuscaClientesTOT.Fill(this.dsBuscar1.ListaBuscaClientesTOT);
                //    if (this.dsBuscar1.ListaBuscaClientesTOT.Rows.Count > 0)
                //    {
                //        this.dgClientes.CurrentCell = new DataGridCell(0, 1);
                //        this.dgClientes.CurrentCell = new DataGridCell(0, 0);
                //        this.lblNumReg.Text = this.dsBuscar1.ListaBuscaClientesTOT.Rows.Count.ToString();
                //        this.sqldaListaBuscaClientes = sqldaListaBuscaClientesTOT;
                //        this.sqldaListaBuscaClientes.Fill(this.dsBuscar1.ListaBuscaClientes);
                //    }
                //    else
                //        this.lblNumReg.Text = "0";
                //}

                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                Mensajes.ShowError(ex.Message);
            }
        }
		#endregion

		#region btBuscar_Click
		private void btBuscar_Click(object sender, System.EventArgs e)
		{
            //---- GSG (17/10/2011)
            this.Var_filaDg = -1;
            //---- FI GSG
			BuscarClientes();
		}
		#endregion

		#region dgClientes_CurrentCellChanged
		private void dgClientes_CurrentCellChanged(object sender, System.EventArgs e)
		{
			try
			{
				int fila = this.dgClientes.CurrentRowIndex;

				this.ParamIO_sIdCliente=this.dgClientes[fila,0].ToString();
				this.ParamO_tNombre=this.dgClientes[fila,2].ToString();
				this.ParamO_iIdCliente=int.Parse(this.dgClientes[fila,3].ToString());
				this.ParamO_tProxObj = this.dgClientes[fila,4].ToString();
			}
			catch(Exception ex)
			{
				Mensajes.ShowError(ex.Message);
			}
		}
		#endregion

		#region btAceptar_Click
		private void btAceptar_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(this.dsBuscar1.ListaBuscaClientes.Rows.Count <= 0)
				{
					this.ParamIO_sIdCliente = "";
					this.ParamO_tNombre = "";
					this.ParamO_iIdCliente= -1;
					this.ParamO_tProxObj = "";
				}

                //---- GSG (24/07/2013)
                dgClientes_CurrentCellChanged(sender, e);
                //---- FI GSG



				if (bBusquedaMultiple) Recuperar_Seleccion();
				
				this.DialogResult=System.Windows.Forms.DialogResult.OK;
				this.Close();

			}
			catch(Exception ex)
			{
				Mensajes.ShowError(ex.Message);
			}
		}
		#endregion

		#region btCancelar_Click
		private void btCancelar_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.Close();
		}
		#endregion



		#region txtsIdCentro_TextChanged
		private void txtsIdCentro_TextChanged(object sender, System.EventArgs e)
		{
			Buscar_NombreCentro();
		}

		private void Buscar_NombreCentro()
		{
			try
			{
				GESTCRM.Formularios.Busquedas.frmMCentros frmBCent = new GESTCRM.Formularios.Busquedas.frmMCentros();
				frmBCent.ParamI_iIdDelegado = this.ParamI_iIdDelegado;
				frmBCent.ParamIO_sIdCentro= this.txtsIdCentro.Text.ToString();
				frmBCent.ParamIO_sDescripcion="";
				frmBCent.Buscar_sCentro();
				this.txtsIdCentro.Text=frmBCent.ParamIO_sIdCentro;
				this.txtsCentro.Text=frmBCent.ParamIO_sDescripcion;
			}
			catch(Exception ex)
			{
				Mensajes.ShowError(ex.Message);
			}
		}
		#endregion

		#region  btBuscarCentro_Click
		private void btBuscarCentro_Click(object sender, System.EventArgs e)
		{
			try
			{
				GESTCRM.Formularios.Busquedas.frmMCentros frmBCent = new GESTCRM.Formularios.Busquedas.frmMCentros();
				frmBCent.ParamIO_sDescripcion = null;
				frmBCent.ParamIO_sIdCentro = "";
				frmBCent.ParamI_iIdDelegado = this.ParamI_iIdDelegado;
				frmBCent.ShowDialog(this);
				if (frmBCent.DialogResult==System.Windows.Forms.DialogResult.OK)
				{
					this.txtsIdCentro.Text=frmBCent.ParamIO_sIdCentro;
					this.txtsCentro.Text=frmBCent.ParamIO_sDescripcion;
				}
			}
			catch(Exception ex)
			{
				Mensajes.ShowError(ex.Message);
			}
		}
		#endregion

		#region Buscar_tNombre
		public void Buscar_tNombre()
		{
			try
			{
				this.dsBuscar1.ListaBuscaClientes.Rows.Clear();

				string tsIdCentro = null;
				string tsTipoCliente = null;

				if(this.ParamI_sIdCentro.Trim().Length>0) tsIdCentro = this.ParamI_sIdCentro;
				if(this.ParamI_sIdTipoCliente.Trim().Length>0) tsTipoCliente=this.ParamI_sIdTipoCliente;


                //---- GSG CECL 19/05/2016
                if (System.Configuration.ConfigurationManager.AppSettings["TipoDelegadoPedidosCentral"].ToString() == Comun.K_CECL)
                {
                    sqldaListaBuscaClientes.SelectCommand = sqlSelectCommand1CECL;
                    this.sqldaListaBuscaClientes.SelectCommand.Parameters["@iIdDelegado"].Value = -1;
                    this.sqldaListaBuscaClientes.SelectCommand.Parameters["@sGrupoClientes"].Value = 'T';
                }
                else
                {
                    sqldaListaBuscaClientes.SelectCommand = sqlSelectCommand1;
                    this.sqldaListaBuscaClientes.SelectCommand.Parameters["@iIdDelegado"].Value = ParamI_iIdDelegado;
                }
                //---- FI GSG CECL


                //this.sqldaListaBuscaClientes.SelectCommand.Parameters["@iIdDelegado"].Value=this.ParamI_iIdDelegado; //---- GSG CECL 19/05/2016
                this.sqldaListaBuscaClientes.SelectCommand.Parameters["@sIdCliente"].Value=this.ParamIO_sIdCliente;
				this.sqldaListaBuscaClientes.SelectCommand.Parameters["@sTipoCliente"].Value=tsTipoCliente;
				this.sqldaListaBuscaClientes.SelectCommand.Parameters["@sNombre"].Value=null;
				this.sqldaListaBuscaClientes.SelectCommand.Parameters["@sApellidos1"].Value=null;
				this.sqldaListaBuscaClientes.SelectCommand.Parameters["@sApellidos2"].Value=null;
				this.sqldaListaBuscaClientes.SelectCommand.Parameters["@sMostrarSap"].Value=null;
				this.sqldaListaBuscaClientes.SelectCommand.Parameters["@sIdCentro"].Value=tsIdCentro;
				this.sqldaListaBuscaClientes.SelectCommand.Parameters["@sIdTipoRelacionCliCen"].Value= null; //this.cbTipoRelacionCentro.SelectedValue.ToString();
				this.sqldaListaBuscaClientes.SelectCommand.Parameters["@TipoVisita"].Value= this.ParamI_TipoVisita;
				this.sqldaListaBuscaClientes.SelectCommand.Parameters["@iIdPoblacion"].Value = -1;
				this.sqldaListaBuscaClientes.SelectCommand.Parameters["@sCodPostal"].Value="-1";
				this.sqldaListaBuscaClientes.SelectCommand.Parameters["@sPoblacion"].Value=null;
				//this.sqldaListaBuscaCentros.SelectCommand.Parameters["@iIdProvincia"].Value=(this.txbNomCentro.Text.ToString() == "")?null:txbNomCentro.Text;

				this.sqldaListaBuscaClientes.Fill(this.dsBuscar1);

                //---- GSG (19/10/2015)
				//if(this.dsBuscar1.ListaBuscaClientes.Rows.Count==1 && this.ParamIO_sIdCliente.ToString().Length>0)
                if (this.dsBuscar1.ListaBuscaClientes.Rows.Count >= 1 && this.ParamIO_sIdCliente.ToString().Length > 0)
				{
					this.ParamO_tNombre = this.dsBuscar1.ListaBuscaClientes.Rows[0]["tNombre"].ToString();
					this.ParamO_iIdCliente = int.Parse(this.dsBuscar1.ListaBuscaClientes.Rows[0]["iIdCliente"].ToString());
					this.ParamIO_sIdCliente = this.dsBuscar1.ListaBuscaClientes.Rows[0]["sIdCliente"].ToString();
					this.ParamO_tProxObj = this.dsBuscar1.ListaBuscaClientes.Rows[0]["tProxObj"].ToString();
				}
				else
				{
					this.ParamO_iIdCliente = -1;
					this.ParamIO_sIdCliente="";
					this.ParamO_tNombre="";
					this.ParamO_tProxObj=null;
				}
			}
			catch(Exception ex)
			{
				Mensajes.ShowError(ex.Message);
			}
		}
		#endregion

        //---- GSG (17/10/2011)
        private void dgClientes_Click(object sender, EventArgs e)
        {
            this.Var_filaDg = this.dgClientes.CurrentRowIndex;

            if (this.bBusquedaMultiple)
            {
                this.dgClientes.Select(this.Var_filaDg);
            }
            else
            {
                Utiles.Seleccionar_UnaFilaDataGrid(this, this.dgClientes, this.Var_filaDg);
            }
        }
        //---- FI GSG

		#region dgClientes_DoubleClick
		private void dgClientes_DoubleClick(object sender, System.EventArgs e)
		{
			if(this.dsBuscar1.ListaBuscaClientes.Rows.Count > 0)
			{
				try
                {
					//---- GSG (17/10/2011)
                    //if(this.bBusquedaMultiple) Recuperar_Seleccion();
                    if (this.bBusquedaMultiple)
                    {
                        this.dgClientes.Select(this.Var_filaDg);
                        Recuperar_Seleccion();
                    }
                    //---- FI GSG
                    else
                    {
                        this.ParamIO_sIdCliente = this.dgClientes[this.dgClientes.CurrentRowIndex, 0].ToString();
                        this.ParamO_tNombre = this.dgClientes[this.dgClientes.CurrentRowIndex, 2].ToString();
                        this.ParamO_iIdCliente = int.Parse(this.dgClientes[this.dgClientes.CurrentRowIndex, 3].ToString());


                    }
					this.DialogResult=System.Windows.Forms.DialogResult.OK;
					this.Close();		
				}
				catch(Exception ex)
				{
					Mensajes.ShowError(ex.Message);
				}
			}
		}
		#endregion

		#region dgClientes_Paint
		private void dgClientes_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
            //---- GSG (17/10/2011) Canvio el if quan venim de visita

            //if(this.dgClientes.CurrentRowIndex != -1 && this.dgClientes.CurrentRowIndex != this.Var_filaDg)
            //{
            //    this.Var_filaDg = this.dgClientes.CurrentRowIndex;

            //    if (this.bBusquedaMultiple)
            //    {
            //        this.dgClientes.Select(this.Var_filaDg);
            //    }
            //    else
            //    {
            //        Utiles.Seleccionar_UnaFilaDataGrid(this,this.dgClientes,this.Var_filaDg);
            //    }
            //}

            
            if (this.Param_Origen == "R")
            {
                if (this.dgClientes.CurrentRowIndex != -1)
                {
                    this.Var_filaDg = this.dgClientes.CurrentRowIndex;

                    if (this.bBusquedaMultiple)
                    {
                        this.dgClientes.Select(this.Var_filaDg);
                    }
                    else
                    {
                        Utiles.Seleccionar_UnaFilaDataGrid(this, this.dgClientes, this.Var_filaDg);
                    }
                }
            }
            else //pedido
            {
                if (this.dgClientes.CurrentRowIndex != -1 && this.dgClientes.CurrentRowIndex != this.Var_filaDg)
                {
                    this.Var_filaDg = this.dgClientes.CurrentRowIndex;

                    if (this.bBusquedaMultiple)
                    {
                        this.dgClientes.Select(this.Var_filaDg);
                    }
                    else
                    {
                        Utiles.Seleccionar_UnaFilaDataGrid(this, this.dgClientes, this.Var_filaDg);
                    }
                }
            }
		}
		#endregion




		#region BorraDatosBusqueda
		private void BorraDatosBusqueda()
		{
			this.dsBuscar1.ListaBuscaClientes.Rows.Clear();
			Application.DoEvents();
			this.dgClientes.Refresh();
			this.lblNumReg.Text = "";
		}
		#endregion

		#region cboTipo_SelectedIndexChanged
		private void cboTipo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			Formatear_Campos(this.cboTipo.SelectedValue.ToString());
			BorraDatosBusqueda();
		}
		#endregion

        //---- GSG (05/09/2011)
        private void cboDescBrick_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDescBrick.SelectedValue != null)
                txtCodBrick.Text = cboDescBrick.SelectedValue.ToString();
            else
                txtCodBrick.Text = "";
        }

        //private void cboDescBrick_TextChanged(object sender, EventArgs e)
        //{
        //    string sTextEntrat = cboDescBrick.Text;
        //    cboDescBrick.SelectedIndex = cboDescBrick.FindString(sTextEntrat.ToUpper(), -1);
        //}

        private void txtCodBrick_TextChanged(object sender, EventArgs e)
        {
            cboDescBrick.SelectedValue = txtCodBrick.Text;
        }


        //---- FI GSG

		#region txtsIdCliente_TextChanged
		private void txtsIdCliente_TextChanged(object sender, System.EventArgs e)
		{
			BorraDatosBusqueda();
		}
		#endregion

		#region cboMostrar_SelectedIndexChanged
		private void cboMostrar_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			BorraDatosBusqueda();
		}
		#endregion

		#region txbNombre_TextChanged
		private void txbNombre_TextChanged(object sender, System.EventArgs e)
		{
			BorraDatosBusqueda();
		}
		#endregion

		#region txbApellidos_TextChanged
		private void txbApellidos_TextChanged(object sender, System.EventArgs e)
		{
			BorraDatosBusqueda();
		}
		#endregion

		#region cbTipoRelacionCentro_SelectedIndexChanged
		private void cbTipoRelacionCentro_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			BorraDatosBusqueda();
		}
		#endregion

		#region txtCodPostal_TextChanged
		private void txtCodPostal_TextChanged(object sender, System.EventArgs e)
		{
			BorraDatosBusqueda();
		}
		#endregion

		#region txbBPoblacion_TextChanged
		private void txbBPoblacion_TextChanged(object sender, System.EventArgs e)
		{
			BorraDatosBusqueda();
		}
		#endregion

		#region txtCodPostal_Leave
		private void txtCodPostal_Leave(object sender, System.EventArgs e)
		{
			this.txbIdPoblacion.Text = "";
		}
		#endregion

		#region txbBPoblacion_Leave
		private void txbBPoblacion_Leave(object sender, System.EventArgs e)
		{
			// Quita el iIdPoblacion cuando no hay descripcion de esta
			if(this.txbBPoblacion.Text == "")
			{
				this.txbIdPoblacion.Text  = "";
			}
		}
		#endregion

		#region btnBuscPob_Click
		private void btnBuscPob_Click(object sender, System.EventArgs e)
		{
			GESTCRM.Formularios.Busquedas.frmMPoblaciones frmBPob = new GESTCRM.Formularios.Busquedas.frmMPoblaciones();
			frmBPob.ShowDialog(this);

			if(frmBPob._ValorAceptar != null)
			{
				int pos = frmBPob._ValorAceptar.IndexOf("/",0);
				this.txbBPoblacion.Text = frmBPob._ValorAceptar.Substring(0,pos);
				int pos1 = frmBPob._ValorAceptar.IndexOf("/",pos);
				string cp = frmBPob._ValorAceptar.Substring(pos+1,5).ToString();
				this.txtCodPostal.Text = cp;

				if (this.txbBPoblacion.Text != "" && cp != "")
				{
					string Retorno = "";
                    //SqlConnection sqlConn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["sConn"].ToString());//---- GSG (10/09/2014)

                    //---- GSG (10/09/2014)
					//sqlConn.Open();
                    if (sqlConn.State == ConnectionState.Closed)
                        sqlConn.Open();


					SqlCommand sqlCmd = sqlConn.CreateCommand();
					sqlCmd.CommandText = "GetiIdPoblacion_Texto";
					sqlCmd.CommandType=CommandType.StoredProcedure;
					sqlCmd.Parameters.Add("@sDescripcion",SqlDbType.VarChar); 
					sqlCmd.Parameters.Add("@sCodPostal",SqlDbType.VarChar); 
					sqlCmd.Parameters["@sDescripcion"].Value = this.txbBPoblacion.Text;
					sqlCmd.Parameters["@sCodPostal"].Value = cp.ToString();
					
					SqlDataReader drConf = sqlCmd.ExecuteReader();
			
					if (drConf.Read())
					{
						Retorno = drConf["iIdPoblacion"].ToString();
						this.txbIdPoblacion.Text = Retorno;
					}

					drConf.Close();
					sqlConn.Close();
                    //---- GSG (10/09/2014)
                    //sqlConn.Dispose();
				}
			}
			else
			{
				//this.txbIdPoblacion.Text = "";
				//this.txbBPoblacion.Text = "";
				//this.txtCodPostal.Text = "";
			}

		}
		#endregion



        

        
        

        

        
	}
}
