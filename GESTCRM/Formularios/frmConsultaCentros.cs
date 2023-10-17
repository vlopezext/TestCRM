using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;


namespace GESTCRM.Formularios
{
	/// <summary>
	/// Descripción breve de frmConsultaCentros.
	/// </summary>
	public class frmConsultaCentros : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.Label lblCliente;
		private System.Windows.Forms.ToolTip toolTipConsultaPedidos;
		private System.Windows.Forms.TextBox txbBPoblacion;
		private System.Windows.Forms.Button btnBuscPob;
		private System.Data.SqlClient.SqlDataAdapter sqldaTipoCentro;
		private System.Windows.Forms.ComboBox cboTipoCentro;
		private System.Windows.Forms.DataGrid dgCentros;
		private System.Windows.Forms.DataGridTextBoxColumn sIdCentro;
		private System.Windows.Forms.DataGridTextBoxColumn TipoCentro;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
		private System.Windows.Forms.TextBox txbIdPoblacion;
		private System.Windows.Forms.Label lblTipoCentro;
		private System.Windows.Forms.ComboBox cboDelegado;
		private System.Windows.Forms.Label lblDelegado;
		private System.Data.SqlClient.SqlDataAdapter sqldaListaDelegados;
		private System.Windows.Forms.Button btnBuscarC;
		private System.Windows.Forms.TextBox txbCodCentro;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txbNomCentro;
		private System.Windows.Forms.Label label2;
		private System.Data.SqlClient.SqlConnection sqlConn;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		private GESTCRM.Formularios.DataSets.dsCentros dsCentros1;
		private System.Windows.Forms.TextBox txtsIdCentro;
		private System.Windows.Forms.Label lblsIdCentro;
		private System.Windows.Forms.TextBox txtsFax;
		private System.Windows.Forms.TextBox txtsPoblacion;
		private System.Windows.Forms.TextBox txtsProvincia;
		private System.Windows.Forms.TextBox txtsCodPostal;
		private System.Windows.Forms.TextBox txtsDireccion;
		private System.Windows.Forms.TextBox txtsDecricpion;
		private System.Windows.Forms.Label lblsPoblacion;
		private System.Windows.Forms.Label lblsDireccion;
		private System.Windows.Forms.Label lbsProvincia;
		private System.Windows.Forms.Label lblsDescripcion;
		private System.Windows.Forms.Label lblsCodPostal;
		private System.Windows.Forms.Label lblsFax;
		private System.Windows.Forms.Label lblsTelefono;
		private System.Windows.Forms.Panel pnDatos;
		private System.ComponentModel.IContainer components;

		private System.Windows.Forms.TextBox txtsTelefono;
		private System.Data.SqlClient.SqlDataAdapter sqldaListaCentros;
		
		int	   Var_iIdCentro;
		int	   Var_iIdClienteCOM;
		string Var_TipoCliente;
		private System.Data.SqlClient.SqlDataAdapter sqldaCentrosClientesSAP_COM;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn iIdCentro;
		private System.Windows.Forms.DataGridTextBoxColumn sCentro;
		private System.Windows.Forms.DataGridTextBoxColumn sNombre;
		private System.Windows.Forms.DataGridTextBoxColumn sDescripcion;
		private System.Windows.Forms.DataGridTextBoxColumn sTipoCentro;
		private System.Windows.Forms.DataGridTextBoxColumn sPoblacion;
		
		System.Drawing.Font fuenteBold;
		private System.Windows.Forms.TextBox txtCodPostal;
		private System.Windows.Forms.Label lblCodPostal;
		private System.Windows.Forms.DataGridTextBoxColumn CodPostal;
		private System.Data.SqlClient.SqlDataAdapter sqldaListaCentrosCliCOM_Horarios;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand6;
		private System.Windows.Forms.Label lblsIdTipoClasificacion;
		private System.Windows.Forms.Label bPactoPrescripcion;
		private System.Windows.Forms.TextBox txtsIdPoliticaPrescripcion;
		private System.Windows.Forms.Label lblsIdPolPrescripcion;
		private System.Windows.Forms.TextBox txtbVisitaColectiva;
		private System.Windows.Forms.Label lblbVisitaColectiva;
		private System.Windows.Forms.TextBox txtsIdSistInformatico;
		private System.Windows.Forms.Label lblsIdSistInformatico;
		private System.Windows.Forms.TextBox txtsIdTipoClasificacion;
		private System.Windows.Forms.TextBox txtsIdAtenVisitas;
		private System.Windows.Forms.Label lblsIdAtenVisitas;
		private System.Windows.Forms.TextBox txtbPactoPrescripcion;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		private GESTCRM.Controles.ucBotoneraSecundaria ucBotoneraSecundaria1; 
		System.Drawing.Font fuenteNoBold; 
	
		int    Var_filaClienteCentro;
		int    Var_fila;
		private GESTCRM.Controles.LabelGradient labelGradient1;
		private System.Windows.Forms.Panel pnCentros;
		private GESTCRM.Controles.LabelGradient labelGradient2;
		private System.Windows.Forms.Label lblNumRegistros;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand5;
		private System.Windows.Forms.ComboBox cboRed;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.ComboBox cboEstado;
		private System.Windows.Forms.Label lblEstado;
		private System.Windows.Forms.DataGridTextBoxColumn Estado;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand7;
		private System.Data.SqlClient.SqlDataAdapter sqldaListaRedes;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand8;
		private System.Data.SqlClient.SqlDataAdapter sqldaListaEstado;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label lblNumRegCC;
		private GESTCRM.Controles.LabelGradient labelGradient4;
		private System.Windows.Forms.DataGrid dgCentrosClientes;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle2;
		private System.Windows.Forms.DataGridTextBoxColumn iIdCliente;
		private System.Windows.Forms.DataGridTextBoxColumn sIdCliente;
		private System.Windows.Forms.DataGridTextBoxColumn sTipoCliente;
		private System.Windows.Forms.DataGridTextBoxColumn sLiteral;
		private System.Windows.Forms.DataGridTextBoxColumn sNombreCli;
		private System.Windows.Forms.ContextMenu contextMenuGrigCentros;
		private System.Windows.Forms.MenuItem menuNuevo;
		private System.Windows.Forms.MenuItem menuEditar;
		private System.Data.SqlClient.SqlCommand sqlcmdSetCentros;
		private System.Windows.Forms.DataGridTextBoxColumn sIdRed;
		private System.Windows.Forms.MenuItem menuEliminar;
		private System.Windows.Forms.DataGridTextBoxColumn Red;
		
		string ParamI_sIdCentro;

		public frmConsultaCentros(string sIdCentro)
		{
			InitializeComponent();
			this.ParamI_sIdCentro = sIdCentro;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsultaCentros));
            this.dgCentros = new System.Windows.Forms.DataGrid();
            this.contextMenuGrigCentros = new System.Windows.Forms.ContextMenu();
            this.menuNuevo = new System.Windows.Forms.MenuItem();
            this.menuEditar = new System.Windows.Forms.MenuItem();
            this.menuEliminar = new System.Windows.Forms.MenuItem();
            this.dsCentros1 = new GESTCRM.Formularios.DataSets.dsCentros();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.iIdCentro = new System.Windows.Forms.DataGridTextBoxColumn();
            this.sCentro = new System.Windows.Forms.DataGridTextBoxColumn();
            this.sDescripcion = new System.Windows.Forms.DataGridTextBoxColumn();
            this.sTipoCentro = new System.Windows.Forms.DataGridTextBoxColumn();
            this.CodPostal = new System.Windows.Forms.DataGridTextBoxColumn();
            this.sPoblacion = new System.Windows.Forms.DataGridTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridTextBoxColumn();
            this.sNombre = new System.Windows.Forms.DataGridTextBoxColumn();
            this.sIdRed = new System.Windows.Forms.DataGridTextBoxColumn();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cboEstado = new System.Windows.Forms.ComboBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.cboRed = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.labelGradient1 = new GESTCRM.Controles.LabelGradient();
            this.txtCodPostal = new System.Windows.Forms.TextBox();
            this.txbNomCentro = new System.Windows.Forms.TextBox();
            this.txbCodCentro = new System.Windows.Forms.TextBox();
            this.cboDelegado = new System.Windows.Forms.ComboBox();
            this.lblDelegado = new System.Windows.Forms.Label();
            this.btnBuscarC = new System.Windows.Forms.Button();
            this.btnBuscPob = new System.Windows.Forms.Button();
            this.txbBPoblacion = new System.Windows.Forms.TextBox();
            this.cboTipoCentro = new System.Windows.Forms.ComboBox();
            this.lblTipoCentro = new System.Windows.Forms.Label();
            this.txbIdPoblacion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCodPostal = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.sqlConn = new System.Data.SqlClient.SqlConnection();
            this.sqldaTipoCentro = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqldaListaCentros = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
            this.toolTipConsultaPedidos = new System.Windows.Forms.ToolTip(this.components);
            this.sIdCentro = new System.Windows.Forms.DataGridTextBoxColumn();
            this.TipoCentro = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.sqldaListaDelegados = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
            this.pnDatos = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblNumRegCC = new System.Windows.Forms.Label();
            this.labelGradient4 = new GESTCRM.Controles.LabelGradient();
            this.dgCentrosClientes = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
            this.iIdCliente = new System.Windows.Forms.DataGridTextBoxColumn();
            this.sIdCliente = new System.Windows.Forms.DataGridTextBoxColumn();
            this.sTipoCliente = new System.Windows.Forms.DataGridTextBoxColumn();
            this.sLiteral = new System.Windows.Forms.DataGridTextBoxColumn();
            this.sNombreCli = new System.Windows.Forms.DataGridTextBoxColumn();
            this.Red = new System.Windows.Forms.DataGridTextBoxColumn();
            this.txtsIdAtenVisitas = new System.Windows.Forms.TextBox();
            this.lblsIdAtenVisitas = new System.Windows.Forms.Label();
            this.txtsIdSistInformatico = new System.Windows.Forms.TextBox();
            this.lblsIdSistInformatico = new System.Windows.Forms.Label();
            this.txtbVisitaColectiva = new System.Windows.Forms.TextBox();
            this.lblbVisitaColectiva = new System.Windows.Forms.Label();
            this.txtsIdPoliticaPrescripcion = new System.Windows.Forms.TextBox();
            this.lblsIdPolPrescripcion = new System.Windows.Forms.Label();
            this.bPactoPrescripcion = new System.Windows.Forms.Label();
            this.txtsIdTipoClasificacion = new System.Windows.Forms.TextBox();
            this.lblsIdTipoClasificacion = new System.Windows.Forms.Label();
            this.txtsFax = new System.Windows.Forms.TextBox();
            this.txtsTelefono = new System.Windows.Forms.TextBox();
            this.txtsPoblacion = new System.Windows.Forms.TextBox();
            this.txtsProvincia = new System.Windows.Forms.TextBox();
            this.txtsCodPostal = new System.Windows.Forms.TextBox();
            this.txtsDireccion = new System.Windows.Forms.TextBox();
            this.txtsDecricpion = new System.Windows.Forms.TextBox();
            this.lblsPoblacion = new System.Windows.Forms.Label();
            this.lblsDireccion = new System.Windows.Forms.Label();
            this.lbsProvincia = new System.Windows.Forms.Label();
            this.lblsDescripcion = new System.Windows.Forms.Label();
            this.lblsCodPostal = new System.Windows.Forms.Label();
            this.lblsTelefono = new System.Windows.Forms.Label();
            this.lblsFax = new System.Windows.Forms.Label();
            this.txtsIdCentro = new System.Windows.Forms.TextBox();
            this.lblsIdCentro = new System.Windows.Forms.Label();
            this.txtbPactoPrescripcion = new System.Windows.Forms.TextBox();
            this.sqldaCentrosClientesSAP_COM = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand5 = new System.Data.SqlClient.SqlCommand();
            this.sqldaListaCentrosCliCOM_Horarios = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand6 = new System.Data.SqlClient.SqlCommand();
            this.ucBotoneraSecundaria1 = new GESTCRM.Controles.ucBotoneraSecundaria();
            this.pnCentros = new System.Windows.Forms.Panel();
            this.lblNumRegistros = new System.Windows.Forms.Label();
            this.labelGradient2 = new GESTCRM.Controles.LabelGradient();
            this.sqldaListaRedes = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand7 = new System.Data.SqlClient.SqlCommand();
            this.sqldaListaEstado = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand8 = new System.Data.SqlClient.SqlCommand();
            this.sqlcmdSetCentros = new System.Data.SqlClient.SqlCommand();
            ((System.ComponentModel.ISupportInitialize)(this.dgCentros)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsCentros1)).BeginInit();
            this.panel3.SuspendLayout();
            this.pnDatos.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCentrosClientes)).BeginInit();
            this.pnCentros.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgCentros
            // 
            this.dgCentros.BackgroundColor = System.Drawing.Color.White;
            this.dgCentros.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.dgCentros.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgCentros.CaptionForeColor = System.Drawing.Color.White;
            this.dgCentros.CaptionVisible = false;
            this.dgCentros.ContextMenu = this.contextMenuGrigCentros;
            this.dgCentros.DataMember = "ListaCentros";
            this.dgCentros.DataSource = this.dsCentros1;
            this.dgCentros.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.dgCentros.ForeColor = System.Drawing.Color.Black;
            this.dgCentros.HeaderBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgCentros.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgCentros.Location = new System.Drawing.Point(0, 18);
            this.dgCentros.Name = "dgCentros";
            this.dgCentros.ParentRowsBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgCentros.ReadOnly = true;
            this.dgCentros.RowHeaderWidth = 17;
            this.dgCentros.Size = new System.Drawing.Size(1242, 218);
            this.dgCentros.TabIndex = 8;
            this.dgCentros.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            this.dgCentros.CurrentCellChanged += new System.EventHandler(this.dgCentros_CurrentCellChanged);
            this.dgCentros.DoubleClick += new System.EventHandler(this.dgCentros_DoubleClick);
            // 
            // contextMenuGrigCentros
            // 
            this.contextMenuGrigCentros.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
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
            this.menuEliminar.Shortcut = System.Windows.Forms.Shortcut.CtrlDel;
            this.menuEliminar.Text = "Eliminar";
            this.menuEliminar.Click += new System.EventHandler(this.menuEliminar_Click);
            // 
            // dsCentros1
            // 
            this.dsCentros1.DataSetName = "dsCentros";
            this.dsCentros1.Locale = new System.Globalization.CultureInfo("en-US");
            this.dsCentros1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.DataGrid = this.dgCentros;
            this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.iIdCentro,
            this.sCentro,
            this.sDescripcion,
            this.sTipoCentro,
            this.CodPostal,
            this.sPoblacion,
            this.Estado,
            this.sNombre,
            this.sIdRed});
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle1.MappingName = "ListaCentros";
            this.dataGridTableStyle1.RowHeaderWidth = 17;
            // 
            // iIdCentro
            // 
            this.iIdCentro.Format = "";
            this.iIdCentro.FormatInfo = null;
            this.iIdCentro.HeaderText = "iIdCentro";
            this.iIdCentro.MappingName = "iIdCentro";
            this.iIdCentro.Width = 0;
            // 
            // sCentro
            // 
            this.sCentro.Format = "";
            this.sCentro.FormatInfo = null;
            this.sCentro.HeaderText = "Código";
            this.sCentro.MappingName = "sIdCentro";
            this.sCentro.NullText = "";
            this.sCentro.Width = 105;
            // 
            // sDescripcion
            // 
            this.sDescripcion.Format = "";
            this.sDescripcion.FormatInfo = null;
            this.sDescripcion.HeaderText = "Nombre Centro";
            this.sDescripcion.MappingName = "sDescripcion";
            this.sDescripcion.NullText = "";
            this.sDescripcion.Width = 230;
            // 
            // sTipoCentro
            // 
            this.sTipoCentro.Format = "";
            this.sTipoCentro.FormatInfo = null;
            this.sTipoCentro.HeaderText = "Tipo Centro";
            this.sTipoCentro.MappingName = "sTipoCentro";
            this.sTipoCentro.NullText = "";
            this.sTipoCentro.Width = 165;
            // 
            // CodPostal
            // 
            this.CodPostal.Format = "";
            this.CodPostal.FormatInfo = null;
            this.CodPostal.HeaderText = "C.P.";
            this.CodPostal.MappingName = "CodPostal";
            this.CodPostal.Width = 40;
            // 
            // sPoblacion
            // 
            this.sPoblacion.Format = "";
            this.sPoblacion.FormatInfo = null;
            this.sPoblacion.HeaderText = "Población";
            this.sPoblacion.MappingName = "sPoblacion";
            this.sPoblacion.NullText = "";
            this.sPoblacion.Width = 230;
            // 
            // Estado
            // 
            this.Estado.Format = "";
            this.Estado.FormatInfo = null;
            this.Estado.HeaderText = "Estado";
            this.Estado.MappingName = "Estado";
            this.Estado.Width = 80;
            // 
            // sNombre
            // 
            this.sNombre.Format = "";
            this.sNombre.FormatInfo = null;
            this.sNombre.HeaderText = "Delegado";
            this.sNombre.MappingName = "sNombre";
            this.sNombre.NullText = "";
            this.sNombre.Width = 340;
            // 
            // sIdRed
            // 
            this.sIdRed.Format = "";
            this.sIdRed.FormatInfo = null;
            this.sIdRed.MappingName = "sIdRed";
            this.sIdRed.ReadOnly = true;
            this.sIdRed.Width = 0;
            // 
            // menuItem1
            // 
            this.menuItem1.Index = -1;
            this.menuItem1.Text = "Editar";
            // 
            // menuItem2
            // 
            this.menuItem2.Index = -1;
            this.menuItem2.Text = "Eliminar";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.cboEstado);
            this.panel3.Controls.Add(this.lblEstado);
            this.panel3.Controls.Add(this.cboRed);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.labelGradient1);
            this.panel3.Controls.Add(this.txtCodPostal);
            this.panel3.Controls.Add(this.txbNomCentro);
            this.panel3.Controls.Add(this.txbCodCentro);
            this.panel3.Controls.Add(this.cboDelegado);
            this.panel3.Controls.Add(this.lblDelegado);
            this.panel3.Controls.Add(this.btnBuscarC);
            this.panel3.Controls.Add(this.btnBuscPob);
            this.panel3.Controls.Add(this.txbBPoblacion);
            this.panel3.Controls.Add(this.cboTipoCentro);
            this.panel3.Controls.Add(this.lblTipoCentro);
            this.panel3.Controls.Add(this.txbIdPoblacion);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.lblCodPostal);
            this.panel3.Controls.Add(this.lblCliente);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(1, 40);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1245, 72);
            this.panel3.TabIndex = 0;
            // 
            // cboEstado
            // 
            this.cboEstado.BackColor = System.Drawing.Color.White;
            this.cboEstado.DataSource = this.dsCentros1.ListaEstados;
            this.cboEstado.DisplayMember = "sLiteral";
            this.cboEstado.ForeColor = System.Drawing.Color.Black;
            this.cboEstado.Location = new System.Drawing.Point(832, 45);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(90, 21);
            this.cboEstado.TabIndex = 98;
            this.cboEstado.ValueMember = "sValor";
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.ForeColor = System.Drawing.Color.Black;
            this.lblEstado.Location = new System.Drawing.Point(785, 46);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(43, 13);
            this.lblEstado.TabIndex = 99;
            this.lblEstado.Text = "Estado:";
            this.lblEstado.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cboRed
            // 
            this.cboRed.BackColor = System.Drawing.Color.White;
            this.cboRed.DataSource = this.dsCentros1.ListaRedes;
            this.cboRed.DisplayMember = "sLiteral";
            this.cboRed.ForeColor = System.Drawing.Color.Black;
            this.cboRed.Location = new System.Drawing.Point(832, 24);
            this.cboRed.Name = "cboRed";
            this.cboRed.Size = new System.Drawing.Size(170, 21);
            this.cboRed.TabIndex = 96;
            this.cboRed.ValueMember = "sValor";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(798, 28);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(30, 13);
            this.label10.TabIndex = 97;
            this.label10.Text = "Red:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
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
            this.labelGradient1.Size = new System.Drawing.Size(1243, 22);
            this.labelGradient1.TabIndex = 82;
            this.labelGradient1.Text = "Consulta de Centros";
            // 
            // txtCodPostal
            // 
            this.txtCodPostal.BackColor = System.Drawing.Color.White;
            this.txtCodPostal.ForeColor = System.Drawing.Color.Black;
            this.txtCodPostal.Location = new System.Drawing.Point(362, 45);
            this.txtCodPostal.MaxLength = 5;
            this.txtCodPostal.Name = "txtCodPostal";
            this.txtCodPostal.Size = new System.Drawing.Size(40, 20);
            this.txtCodPostal.TabIndex = 4;
            this.txtCodPostal.TextChanged += new System.EventHandler(this.txtCodPostal_TextChanged);
            this.txtCodPostal.Leave += new System.EventHandler(this.txtCodPostal_Leave);
            // 
            // txbNomCentro
            // 
            this.txbNomCentro.BackColor = System.Drawing.Color.White;
            this.txbNomCentro.ForeColor = System.Drawing.Color.Black;
            this.txbNomCentro.Location = new System.Drawing.Point(494, 24);
            this.txbNomCentro.MaxLength = 100;
            this.txbNomCentro.Name = "txbNomCentro";
            this.txbNomCentro.Size = new System.Drawing.Size(264, 20);
            this.txbNomCentro.TabIndex = 2;
            this.txbNomCentro.TextChanged += new System.EventHandler(this.txbNomCentro_TextChanged);
            // 
            // txbCodCentro
            // 
            this.txbCodCentro.BackColor = System.Drawing.Color.White;
            this.txbCodCentro.ForeColor = System.Drawing.Color.Black;
            this.txbCodCentro.Location = new System.Drawing.Point(362, 24);
            this.txbCodCentro.MaxLength = 20;
            this.txbCodCentro.Name = "txbCodCentro";
            this.txbCodCentro.Size = new System.Drawing.Size(70, 20);
            this.txbCodCentro.TabIndex = 1;
            this.txbCodCentro.TextChanged += new System.EventHandler(this.txbCodCentro_TextChanged);
            // 
            // cboDelegado
            // 
            this.cboDelegado.DataSource = this.dsCentros1.ListaDelegados;
            this.cboDelegado.DisplayMember = "sNombre";
            this.cboDelegado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cboDelegado.ForeColor = System.Drawing.Color.Black;
            this.cboDelegado.ItemHeight = 13;
            this.cboDelegado.Location = new System.Drawing.Point(59, 24);
            this.cboDelegado.Name = "cboDelegado";
            this.cboDelegado.Size = new System.Drawing.Size(248, 21);
            this.cboDelegado.TabIndex = 0;
            this.cboDelegado.ValueMember = "iIdDelegado";
            this.cboDelegado.SelectedIndexChanged += new System.EventHandler(this.cboDelegado_SelectedIndexChanged);
            this.cboDelegado.Leave += new System.EventHandler(this.cboDelegado_Leave);
            // 
            // lblDelegado
            // 
            this.lblDelegado.AutoSize = true;
            this.lblDelegado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblDelegado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblDelegado.ForeColor = System.Drawing.Color.Black;
            this.lblDelegado.Location = new System.Drawing.Point(7, 28);
            this.lblDelegado.Name = "lblDelegado";
            this.lblDelegado.Size = new System.Drawing.Size(56, 13);
            this.lblDelegado.TabIndex = 75;
            this.lblDelegado.Text = "Delegado:";
            // 
            // btnBuscarC
            // 
            this.btnBuscarC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarC.ForeColor = System.Drawing.Color.Black;
            this.btnBuscarC.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBuscarC.Location = new System.Drawing.Point(1160, 39);
            this.btnBuscarC.Name = "btnBuscarC";
            this.btnBuscarC.Size = new System.Drawing.Size(72, 23);
            this.btnBuscarC.TabIndex = 7;
            this.btnBuscarC.Text = "Buscar";
            this.btnBuscarC.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBuscarC.UseVisualStyleBackColor = true;
            this.btnBuscarC.Click += new System.EventHandler(this.btnBuscarC_Click);
            // 
            // btnBuscPob
            // 
            this.btnBuscPob.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscPob.Image")));
            this.btnBuscPob.Location = new System.Drawing.Point(745, 45);
            this.btnBuscPob.Name = "btnBuscPob";
            this.btnBuscPob.Size = new System.Drawing.Size(20, 20);
            this.btnBuscPob.TabIndex = 6;
            this.btnBuscPob.UseVisualStyleBackColor = true;
            this.btnBuscPob.Click += new System.EventHandler(this.btnBuscPob_Click);
            // 
            // txbBPoblacion
            // 
            this.txbBPoblacion.BackColor = System.Drawing.SystemColors.Window;
            this.txbBPoblacion.ForeColor = System.Drawing.Color.Black;
            this.txbBPoblacion.Location = new System.Drawing.Point(493, 45);
            this.txbBPoblacion.MaxLength = 50;
            this.txbBPoblacion.Name = "txbBPoblacion";
            this.txbBPoblacion.Size = new System.Drawing.Size(246, 20);
            this.txbBPoblacion.TabIndex = 5;
            this.txbBPoblacion.TextChanged += new System.EventHandler(this.txbBPoblacion_TextChanged);
            this.txbBPoblacion.Leave += new System.EventHandler(this.txbBPoblacion_Leave);
            // 
            // cboTipoCentro
            // 
            this.cboTipoCentro.DataSource = this.dsCentros1.ListaTipoCentro;
            this.cboTipoCentro.DisplayMember = "sLiteral";
            this.cboTipoCentro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cboTipoCentro.ForeColor = System.Drawing.Color.Black;
            this.cboTipoCentro.ItemHeight = 13;
            this.cboTipoCentro.Location = new System.Drawing.Point(59, 45);
            this.cboTipoCentro.Name = "cboTipoCentro";
            this.cboTipoCentro.Size = new System.Drawing.Size(248, 21);
            this.cboTipoCentro.TabIndex = 3;
            this.cboTipoCentro.ValueMember = "sValor";
            this.cboTipoCentro.SelectedIndexChanged += new System.EventHandler(this.cboTipoCentro_SelectedIndexChanged);
            this.cboTipoCentro.Leave += new System.EventHandler(this.cboTipoCentro_Leave);
            // 
            // lblTipoCentro
            // 
            this.lblTipoCentro.AutoSize = true;
            this.lblTipoCentro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblTipoCentro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblTipoCentro.ForeColor = System.Drawing.Color.Black;
            this.lblTipoCentro.Location = new System.Drawing.Point(7, 49);
            this.lblTipoCentro.Name = "lblTipoCentro";
            this.lblTipoCentro.Size = new System.Drawing.Size(31, 13);
            this.lblTipoCentro.TabIndex = 1;
            this.lblTipoCentro.Text = "Tipo:";
            // 
            // txbIdPoblacion
            // 
            this.txbIdPoblacion.BackColor = System.Drawing.Color.White;
            this.txbIdPoblacion.ForeColor = System.Drawing.Color.Black;
            this.txbIdPoblacion.Location = new System.Drawing.Point(552, 48);
            this.txbIdPoblacion.Name = "txbIdPoblacion";
            this.txbIdPoblacion.Size = new System.Drawing.Size(72, 20);
            this.txbIdPoblacion.TabIndex = 7;
            this.txbIdPoblacion.Visible = false;
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(324, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 76;
            this.label1.Text = "Código:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCodPostal
            // 
            this.lblCodPostal.ForeColor = System.Drawing.Color.Black;
            this.lblCodPostal.Location = new System.Drawing.Point(324, 45);
            this.lblCodPostal.Name = "lblCodPostal";
            this.lblCodPostal.Size = new System.Drawing.Size(32, 16);
            this.lblCodPostal.TabIndex = 81;
            this.lblCodPostal.Text = "C.P.:";
            this.lblCodPostal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCliente
            // 
            this.lblCliente.ForeColor = System.Drawing.Color.Black;
            this.lblCliente.Location = new System.Drawing.Point(441, 45);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(58, 16);
            this.lblCliente.TabIndex = 69;
            this.lblCliente.Text = "Poblacion:";
            this.lblCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(450, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 16);
            this.label2.TabIndex = 78;
            this.label2.Text = "Nombre:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sqlConn
            // 
            this.sqlConn = Utiles._connection;
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
            // sqldaListaCentros
            // 
            this.sqldaListaCentros.SelectCommand = this.sqlSelectCommand2;
            this.sqldaListaCentros.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaCentros", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iIdCentro", "iIdCentro"),
                        new System.Data.Common.DataColumnMapping("sIdCentro", "sIdCentro"),
                        new System.Data.Common.DataColumnMapping("sIdTipoCentro", "sIdTipoCentro"),
                        new System.Data.Common.DataColumnMapping("sTipoCentro", "sTipoCentro"),
                        new System.Data.Common.DataColumnMapping("sNombre", "sNombre"),
                        new System.Data.Common.DataColumnMapping("sDescripcion", "sDescripcion"),
                        new System.Data.Common.DataColumnMapping("sDireccion", "sDireccion"),
                        new System.Data.Common.DataColumnMapping("CodPostal", "CodPostal"),
                        new System.Data.Common.DataColumnMapping("sPoblacion", "sPoblacion"),
                        new System.Data.Common.DataColumnMapping("iIdProvincia", "iIdProvincia"),
                        new System.Data.Common.DataColumnMapping("sProvincia", "sProvincia"),
                        new System.Data.Common.DataColumnMapping("sFax", "sFax"),
                        new System.Data.Common.DataColumnMapping("sTelefono", "sTelefono"),
                        new System.Data.Common.DataColumnMapping("sIdAtenVisitas", "sIdAtenVisitas"),
                        new System.Data.Common.DataColumnMapping("sIdTipoClasificacion", "sIdTipoClasificacion"),
                        new System.Data.Common.DataColumnMapping("bPactoPrescripcion", "bPactoPrescripcion"),
                        new System.Data.Common.DataColumnMapping("sIdPolPrescripcion", "sIdPolPrescripcion"),
                        new System.Data.Common.DataColumnMapping("bVisitaColectiva", "bVisitaColectiva"),
                        new System.Data.Common.DataColumnMapping("sIdSistInformatico", "sIdSistInformatico")})});
            // 
            // sqlSelectCommand2
            // 
            this.sqlSelectCommand2.CommandText = "[ListaCentros]";
            this.sqlSelectCommand2.CommandTimeout = 60;
            this.sqlSelectCommand2.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand2.Connection = this.sqlConn;
            this.sqlSelectCommand2.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdDelegado", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sIdTipoCentro", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@iIdPoblacion", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sIdCentro", System.Data.SqlDbType.VarChar, 20),
            new System.Data.SqlClient.SqlParameter("@sDescripcion", System.Data.SqlDbType.VarChar, 100),
            new System.Data.SqlClient.SqlParameter("@sCodPostal", System.Data.SqlDbType.VarChar, 5),
            new System.Data.SqlClient.SqlParameter("@iIdProvincia", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sPoblacion", System.Data.SqlDbType.VarChar, 50),
            new System.Data.SqlClient.SqlParameter("@sIdRed", System.Data.SqlDbType.VarChar, 4),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt)});
            // 
            // sIdCentro
            // 
            this.sIdCentro.Format = "";
            this.sIdCentro.FormatInfo = null;
            this.sIdCentro.HeaderText = "Centro";
            this.sIdCentro.MappingName = "iIdCentro";
            this.sIdCentro.Width = 0;
            // 
            // TipoCentro
            // 
            this.TipoCentro.Format = "";
            this.TipoCentro.FormatInfo = null;
            this.TipoCentro.HeaderText = "Tipo Centro";
            this.TipoCentro.MappingName = "sTipoCentro";
            this.TipoCentro.Width = 200;
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "Descripción";
            this.dataGridTextBoxColumn1.MappingName = "sDescripcion";
            this.dataGridTextBoxColumn1.Width = 200;
            // 
            // sqldaListaDelegados
            // 
            this.sqldaListaDelegados.SelectCommand = this.sqlSelectCommand3;
            this.sqldaListaDelegados.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaDelegados", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iIdDelegado", "iIdDelegado"),
                        new System.Data.Common.DataColumnMapping("sNombre", "sNombre")})});
            // 
            // sqlSelectCommand3
            // 
            this.sqlSelectCommand3.CommandText = "[ListaDelegados]";
            this.sqlSelectCommand3.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand3.Connection = this.sqlConn;
            this.sqlSelectCommand3.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null)});
            // 
            // pnDatos
            // 
            this.pnDatos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnDatos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnDatos.Controls.Add(this.panel1);
            this.pnDatos.Controls.Add(this.txtsIdAtenVisitas);
            this.pnDatos.Controls.Add(this.lblsIdAtenVisitas);
            this.pnDatos.Controls.Add(this.txtsIdSistInformatico);
            this.pnDatos.Controls.Add(this.lblsIdSistInformatico);
            this.pnDatos.Controls.Add(this.txtbVisitaColectiva);
            this.pnDatos.Controls.Add(this.lblbVisitaColectiva);
            this.pnDatos.Controls.Add(this.txtsIdPoliticaPrescripcion);
            this.pnDatos.Controls.Add(this.lblsIdPolPrescripcion);
            this.pnDatos.Controls.Add(this.bPactoPrescripcion);
            this.pnDatos.Controls.Add(this.txtsIdTipoClasificacion);
            this.pnDatos.Controls.Add(this.lblsIdTipoClasificacion);
            this.pnDatos.Controls.Add(this.txtsFax);
            this.pnDatos.Controls.Add(this.txtsTelefono);
            this.pnDatos.Controls.Add(this.txtsPoblacion);
            this.pnDatos.Controls.Add(this.txtsProvincia);
            this.pnDatos.Controls.Add(this.txtsCodPostal);
            this.pnDatos.Controls.Add(this.txtsDireccion);
            this.pnDatos.Controls.Add(this.txtsDecricpion);
            this.pnDatos.Controls.Add(this.lblsPoblacion);
            this.pnDatos.Controls.Add(this.lblsDireccion);
            this.pnDatos.Controls.Add(this.lbsProvincia);
            this.pnDatos.Controls.Add(this.lblsDescripcion);
            this.pnDatos.Controls.Add(this.lblsCodPostal);
            this.pnDatos.Controls.Add(this.lblsTelefono);
            this.pnDatos.Controls.Add(this.lblsFax);
            this.pnDatos.Controls.Add(this.txtsIdCentro);
            this.pnDatos.Controls.Add(this.lblsIdCentro);
            this.pnDatos.Controls.Add(this.txtbPactoPrescripcion);
            this.pnDatos.Location = new System.Drawing.Point(1, 352);
            this.pnDatos.Name = "pnDatos";
            this.pnDatos.Size = new System.Drawing.Size(1244, 288);
            this.pnDatos.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.lblNumRegCC);
            this.panel1.Controls.Add(this.labelGradient4);
            this.panel1.Controls.Add(this.dgCentrosClientes);
            this.panel1.Location = new System.Drawing.Point(3, 72);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1232, 216);
            this.panel1.TabIndex = 56;
            // 
            // lblNumRegCC
            // 
            this.lblNumRegCC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.lblNumRegCC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblNumRegCC.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumRegCC.ForeColor = System.Drawing.Color.Black;
            this.lblNumRegCC.Location = new System.Drawing.Point(1168, 0);
            this.lblNumRegCC.Name = "lblNumRegCC";
            this.lblNumRegCC.Size = new System.Drawing.Size(60, 18);
            this.lblNumRegCC.TabIndex = 85;
            this.lblNumRegCC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.labelGradient4.Size = new System.Drawing.Size(1228, 18);
            this.labelGradient4.TabIndex = 84;
            this.labelGradient4.Text = "Clientes del Centro";
            this.labelGradient4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgCentrosClientes
            // 
            this.dgCentrosClientes.BackgroundColor = System.Drawing.Color.White;
            this.dgCentrosClientes.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.dgCentrosClientes.CaptionForeColor = System.Drawing.Color.White;
            this.dgCentrosClientes.CaptionVisible = false;
            this.dgCentrosClientes.DataMember = "ListaCentrosClientesSAP_COM";
            this.dgCentrosClientes.DataSource = this.dsCentros1;
            this.dgCentrosClientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgCentrosClientes.ForeColor = System.Drawing.Color.Black;
            this.dgCentrosClientes.HeaderBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgCentrosClientes.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgCentrosClientes.Location = new System.Drawing.Point(0, 18);
            this.dgCentrosClientes.Name = "dgCentrosClientes";
            this.dgCentrosClientes.ParentRowsBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgCentrosClientes.ReadOnly = true;
            this.dgCentrosClientes.RowHeaderWidth = 30;
            this.dgCentrosClientes.Size = new System.Drawing.Size(1227, 192);
            this.dgCentrosClientes.TabIndex = 26;
            this.dgCentrosClientes.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle2});
            this.dgCentrosClientes.CurrentCellChanged += new System.EventHandler(this.dgCentrosClientes_CurrentCellChanged);
            // 
            // dataGridTableStyle2
            // 
            this.dataGridTableStyle2.DataGrid = this.dgCentrosClientes;
            this.dataGridTableStyle2.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.iIdCliente,
            this.sIdCliente,
            this.sTipoCliente,
            this.sLiteral,
            this.sNombreCli,
            this.Red});
            this.dataGridTableStyle2.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle2.MappingName = "ListaCentrosClientesSAP_COM";
            this.dataGridTableStyle2.RowHeaderWidth = 30;
            // 
            // iIdCliente
            // 
            this.iIdCliente.Format = "";
            this.iIdCliente.FormatInfo = null;
            this.iIdCliente.HeaderText = "iIdCliente";
            this.iIdCliente.MappingName = "iIdCliente";
            this.iIdCliente.NullText = "";
            this.iIdCliente.Width = 0;
            // 
            // sIdCliente
            // 
            this.sIdCliente.Format = "";
            this.sIdCliente.FormatInfo = null;
            this.sIdCliente.HeaderText = "Cód.Cliente";
            this.sIdCliente.MappingName = "sIdCliente";
            this.sIdCliente.NullText = "";
            this.sIdCliente.Width = 140;
            // 
            // sTipoCliente
            // 
            this.sTipoCliente.Format = "";
            this.sTipoCliente.FormatInfo = null;
            this.sTipoCliente.HeaderText = "sTipoCliente";
            this.sTipoCliente.MappingName = "sTipoCliente";
            this.sTipoCliente.NullText = "";
            this.sTipoCliente.Width = 0;
            // 
            // sLiteral
            // 
            this.sLiteral.Format = "";
            this.sLiteral.FormatInfo = null;
            this.sLiteral.HeaderText = "Tipo Cliente";
            this.sLiteral.MappingName = "sLiteral";
            this.sLiteral.NullText = "";
            this.sLiteral.Width = 200;
            // 
            // sNombreCli
            // 
            this.sNombreCli.Format = "";
            this.sNombreCli.FormatInfo = null;
            this.sNombreCli.HeaderText = "Nombre";
            this.sNombreCli.MappingName = "sNombre";
            this.sNombreCli.NullText = "";
            this.sNombreCli.Width = 500;
            // 
            // Red
            // 
            this.Red.Format = "";
            this.Red.FormatInfo = null;
            this.Red.HeaderText = "Red";
            this.Red.MappingName = "Red";
            this.Red.Width = 75;
            // 
            // txtsIdAtenVisitas
            // 
            this.txtsIdAtenVisitas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtsIdAtenVisitas.ForeColor = System.Drawing.Color.Black;
            this.txtsIdAtenVisitas.Location = new System.Drawing.Point(1148, 27);
            this.txtsIdAtenVisitas.Name = "txtsIdAtenVisitas";
            this.txtsIdAtenVisitas.ReadOnly = true;
            this.txtsIdAtenVisitas.Size = new System.Drawing.Size(80, 20);
            this.txtsIdAtenVisitas.TabIndex = 19;
            this.txtsIdAtenVisitas.TabStop = false;
            // 
            // lblsIdAtenVisitas
            // 
            this.lblsIdAtenVisitas.ForeColor = System.Drawing.Color.Black;
            this.lblsIdAtenVisitas.Location = new System.Drawing.Point(1067, 27);
            this.lblsIdAtenVisitas.Name = "lblsIdAtenVisitas";
            this.lblsIdAtenVisitas.Size = new System.Drawing.Size(88, 18);
            this.lblsIdAtenVisitas.TabIndex = 48;
            this.lblsIdAtenVisitas.Text = "Atención Visita:";
            this.lblsIdAtenVisitas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtsIdSistInformatico
            // 
            this.txtsIdSistInformatico.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtsIdSistInformatico.ForeColor = System.Drawing.Color.Black;
            this.txtsIdSistInformatico.Location = new System.Drawing.Point(109, 48);
            this.txtsIdSistInformatico.Name = "txtsIdSistInformatico";
            this.txtsIdSistInformatico.ReadOnly = true;
            this.txtsIdSistInformatico.Size = new System.Drawing.Size(112, 20);
            this.txtsIdSistInformatico.TabIndex = 24;
            this.txtsIdSistInformatico.TabStop = false;
            // 
            // lblsIdSistInformatico
            // 
            this.lblsIdSistInformatico.ForeColor = System.Drawing.Color.Black;
            this.lblsIdSistInformatico.Location = new System.Drawing.Point(6, 48);
            this.lblsIdSistInformatico.Name = "lblsIdSistInformatico";
            this.lblsIdSistInformatico.Size = new System.Drawing.Size(112, 18);
            this.lblsIdSistInformatico.TabIndex = 46;
            this.lblsIdSistInformatico.Text = "Sistema Informático:";
            this.lblsIdSistInformatico.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtbVisitaColectiva
            // 
            this.txtbVisitaColectiva.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtbVisitaColectiva.ForeColor = System.Drawing.Color.Black;
            this.txtbVisitaColectiva.Location = new System.Drawing.Point(691, 27);
            this.txtbVisitaColectiva.Name = "txtbVisitaColectiva";
            this.txtbVisitaColectiva.ReadOnly = true;
            this.txtbVisitaColectiva.Size = new System.Drawing.Size(29, 20);
            this.txtbVisitaColectiva.TabIndex = 23;
            this.txtbVisitaColectiva.TabStop = false;
            // 
            // lblbVisitaColectiva
            // 
            this.lblbVisitaColectiva.ForeColor = System.Drawing.Color.Black;
            this.lblbVisitaColectiva.Location = new System.Drawing.Point(609, 27);
            this.lblbVisitaColectiva.Name = "lblbVisitaColectiva";
            this.lblbVisitaColectiva.Size = new System.Drawing.Size(88, 18);
            this.lblbVisitaColectiva.TabIndex = 44;
            this.lblbVisitaColectiva.Text = "Visita Colectiva:";
            this.lblbVisitaColectiva.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtsIdPoliticaPrescripcion
            // 
            this.txtsIdPoliticaPrescripcion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtsIdPoliticaPrescripcion.ForeColor = System.Drawing.Color.Black;
            this.txtsIdPoliticaPrescripcion.Location = new System.Drawing.Point(450, 26);
            this.txtsIdPoliticaPrescripcion.Name = "txtsIdPoliticaPrescripcion";
            this.txtsIdPoliticaPrescripcion.ReadOnly = true;
            this.txtsIdPoliticaPrescripcion.Size = new System.Drawing.Size(144, 20);
            this.txtsIdPoliticaPrescripcion.TabIndex = 22;
            this.txtsIdPoliticaPrescripcion.TabStop = false;
            // 
            // lblsIdPolPrescripcion
            // 
            this.lblsIdPolPrescripcion.ForeColor = System.Drawing.Color.Black;
            this.lblsIdPolPrescripcion.Location = new System.Drawing.Point(344, 26);
            this.lblsIdPolPrescripcion.Name = "lblsIdPolPrescripcion";
            this.lblsIdPolPrescripcion.Size = new System.Drawing.Size(112, 18);
            this.lblsIdPolPrescripcion.TabIndex = 42;
            this.lblsIdPolPrescripcion.Text = "Política Prescripción:";
            this.lblsIdPolPrescripcion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bPactoPrescripcion
            // 
            this.bPactoPrescripcion.BackColor = System.Drawing.Color.Transparent;
            this.bPactoPrescripcion.ForeColor = System.Drawing.Color.Black;
            this.bPactoPrescripcion.Location = new System.Drawing.Point(189, 25);
            this.bPactoPrescripcion.Name = "bPactoPrescripcion";
            this.bPactoPrescripcion.Size = new System.Drawing.Size(99, 18);
            this.bPactoPrescripcion.TabIndex = 40;
            this.bPactoPrescripcion.Text = "Pacto Prescripción:";
            this.bPactoPrescripcion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtsIdTipoClasificacion
            // 
            this.txtsIdTipoClasificacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtsIdTipoClasificacion.ForeColor = System.Drawing.Color.Black;
            this.txtsIdTipoClasificacion.Location = new System.Drawing.Point(75, 25);
            this.txtsIdTipoClasificacion.Name = "txtsIdTipoClasificacion";
            this.txtsIdTipoClasificacion.ReadOnly = true;
            this.txtsIdTipoClasificacion.Size = new System.Drawing.Size(95, 20);
            this.txtsIdTipoClasificacion.TabIndex = 20;
            this.txtsIdTipoClasificacion.TabStop = false;
            // 
            // lblsIdTipoClasificacion
            // 
            this.lblsIdTipoClasificacion.ForeColor = System.Drawing.Color.Black;
            this.lblsIdTipoClasificacion.Location = new System.Drawing.Point(7, 25);
            this.lblsIdTipoClasificacion.Name = "lblsIdTipoClasificacion";
            this.lblsIdTipoClasificacion.Size = new System.Drawing.Size(84, 18);
            this.lblsIdTipoClasificacion.TabIndex = 38;
            this.lblsIdTipoClasificacion.Text = "Clasificación:";
            this.lblsIdTipoClasificacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtsFax
            // 
            this.txtsFax.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtsFax.ForeColor = System.Drawing.Color.Black;
            this.txtsFax.Location = new System.Drawing.Point(954, 27);
            this.txtsFax.Name = "txtsFax";
            this.txtsFax.ReadOnly = true;
            this.txtsFax.Size = new System.Drawing.Size(96, 20);
            this.txtsFax.TabIndex = 18;
            this.txtsFax.TabStop = false;
            // 
            // txtsTelefono
            // 
            this.txtsTelefono.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtsTelefono.ForeColor = System.Drawing.Color.Black;
            this.txtsTelefono.Location = new System.Drawing.Point(827, 27);
            this.txtsTelefono.Name = "txtsTelefono";
            this.txtsTelefono.ReadOnly = true;
            this.txtsTelefono.Size = new System.Drawing.Size(88, 20);
            this.txtsTelefono.TabIndex = 17;
            this.txtsTelefono.TabStop = false;
            // 
            // txtsPoblacion
            // 
            this.txtsPoblacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtsPoblacion.ForeColor = System.Drawing.Color.Black;
            this.txtsPoblacion.Location = new System.Drawing.Point(870, 2);
            this.txtsPoblacion.Name = "txtsPoblacion";
            this.txtsPoblacion.ReadOnly = true;
            this.txtsPoblacion.Size = new System.Drawing.Size(199, 20);
            this.txtsPoblacion.TabIndex = 15;
            this.txtsPoblacion.TabStop = false;
            // 
            // txtsProvincia
            // 
            this.txtsProvincia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtsProvincia.ForeColor = System.Drawing.Color.Black;
            this.txtsProvincia.Location = new System.Drawing.Point(1132, 3);
            this.txtsProvincia.Name = "txtsProvincia";
            this.txtsProvincia.ReadOnly = true;
            this.txtsProvincia.Size = new System.Drawing.Size(96, 20);
            this.txtsProvincia.TabIndex = 16;
            this.txtsProvincia.TabStop = false;
            // 
            // txtsCodPostal
            // 
            this.txtsCodPostal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtsCodPostal.ForeColor = System.Drawing.Color.Black;
            this.txtsCodPostal.Location = new System.Drawing.Point(744, 2);
            this.txtsCodPostal.Name = "txtsCodPostal";
            this.txtsCodPostal.ReadOnly = true;
            this.txtsCodPostal.Size = new System.Drawing.Size(59, 20);
            this.txtsCodPostal.TabIndex = 14;
            this.txtsCodPostal.TabStop = false;
            // 
            // txtsDireccion
            // 
            this.txtsDireccion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtsDireccion.ForeColor = System.Drawing.Color.Black;
            this.txtsDireccion.Location = new System.Drawing.Point(480, 2);
            this.txtsDireccion.Name = "txtsDireccion";
            this.txtsDireccion.ReadOnly = true;
            this.txtsDireccion.Size = new System.Drawing.Size(223, 20);
            this.txtsDireccion.TabIndex = 13;
            this.txtsDireccion.TabStop = false;
            // 
            // txtsDecricpion
            // 
            this.txtsDecricpion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtsDecricpion.ForeColor = System.Drawing.Color.Black;
            this.txtsDecricpion.Location = new System.Drawing.Point(171, 2);
            this.txtsDecricpion.Name = "txtsDecricpion";
            this.txtsDecricpion.ReadOnly = true;
            this.txtsDecricpion.Size = new System.Drawing.Size(248, 20);
            this.txtsDecricpion.TabIndex = 12;
            this.txtsDecricpion.TabStop = false;
            // 
            // lblsPoblacion
            // 
            this.lblsPoblacion.ForeColor = System.Drawing.Color.Black;
            this.lblsPoblacion.Location = new System.Drawing.Point(814, 2);
            this.lblsPoblacion.Name = "lblsPoblacion";
            this.lblsPoblacion.Size = new System.Drawing.Size(57, 18);
            this.lblsPoblacion.TabIndex = 26;
            this.lblsPoblacion.Text = "Población:";
            this.lblsPoblacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblsDireccion
            // 
            this.lblsDireccion.ForeColor = System.Drawing.Color.Black;
            this.lblsDireccion.Location = new System.Drawing.Point(424, 2);
            this.lblsDireccion.Name = "lblsDireccion";
            this.lblsDireccion.Size = new System.Drawing.Size(56, 18);
            this.lblsDireccion.TabIndex = 24;
            this.lblsDireccion.Text = "Dirección:";
            this.lblsDireccion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbsProvincia
            // 
            this.lbsProvincia.ForeColor = System.Drawing.Color.Black;
            this.lbsProvincia.Location = new System.Drawing.Point(1076, 3);
            this.lbsProvincia.Name = "lbsProvincia";
            this.lbsProvincia.Size = new System.Drawing.Size(56, 18);
            this.lbsProvincia.TabIndex = 23;
            this.lbsProvincia.Text = "Provincia:";
            this.lbsProvincia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblsDescripcion
            // 
            this.lblsDescripcion.ForeColor = System.Drawing.Color.Black;
            this.lblsDescripcion.Location = new System.Drawing.Point(123, 2);
            this.lblsDescripcion.Name = "lblsDescripcion";
            this.lblsDescripcion.Size = new System.Drawing.Size(48, 18);
            this.lblsDescripcion.TabIndex = 20;
            this.lblsDescripcion.Text = "Nombre:";
            this.lblsDescripcion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblsCodPostal
            // 
            this.lblsCodPostal.ForeColor = System.Drawing.Color.Black;
            this.lblsCodPostal.Location = new System.Drawing.Point(712, 2);
            this.lblsCodPostal.Name = "lblsCodPostal";
            this.lblsCodPostal.Size = new System.Drawing.Size(32, 18);
            this.lblsCodPostal.TabIndex = 25;
            this.lblsCodPostal.Text = "C.P.:";
            this.lblsCodPostal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblsTelefono
            // 
            this.lblsTelefono.ForeColor = System.Drawing.Color.Black;
            this.lblsTelefono.Location = new System.Drawing.Point(799, 27);
            this.lblsTelefono.Name = "lblsTelefono";
            this.lblsTelefono.Size = new System.Drawing.Size(32, 18);
            this.lblsTelefono.TabIndex = 21;
            this.lblsTelefono.Text = "Telf:";
            this.lblsTelefono.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblsFax
            // 
            this.lblsFax.ForeColor = System.Drawing.Color.Black;
            this.lblsFax.Location = new System.Drawing.Point(930, 29);
            this.lblsFax.Name = "lblsFax";
            this.lblsFax.Size = new System.Drawing.Size(32, 18);
            this.lblsFax.TabIndex = 22;
            this.lblsFax.Text = "Fax:";
            // 
            // txtsIdCentro
            // 
            this.txtsIdCentro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtsIdCentro.ForeColor = System.Drawing.Color.Black;
            this.txtsIdCentro.Location = new System.Drawing.Point(40, 2);
            this.txtsIdCentro.Name = "txtsIdCentro";
            this.txtsIdCentro.ReadOnly = true;
            this.txtsIdCentro.Size = new System.Drawing.Size(77, 20);
            this.txtsIdCentro.TabIndex = 11;
            this.txtsIdCentro.TabStop = false;
            // 
            // lblsIdCentro
            // 
            this.lblsIdCentro.ForeColor = System.Drawing.Color.Black;
            this.lblsIdCentro.Location = new System.Drawing.Point(8, 2);
            this.lblsIdCentro.Name = "lblsIdCentro";
            this.lblsIdCentro.Size = new System.Drawing.Size(32, 18);
            this.lblsIdCentro.TabIndex = 9;
            this.lblsIdCentro.Text = "Cód.:";
            this.lblsIdCentro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtbPactoPrescripcion
            // 
            this.txtbPactoPrescripcion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtbPactoPrescripcion.ForeColor = System.Drawing.Color.Black;
            this.txtbPactoPrescripcion.Location = new System.Drawing.Point(288, 25);
            this.txtbPactoPrescripcion.Name = "txtbPactoPrescripcion";
            this.txtbPactoPrescripcion.ReadOnly = true;
            this.txtbPactoPrescripcion.Size = new System.Drawing.Size(34, 20);
            this.txtbPactoPrescripcion.TabIndex = 21;
            this.txtbPactoPrescripcion.TabStop = false;
            // 
            // sqldaCentrosClientesSAP_COM
            // 
            this.sqldaCentrosClientesSAP_COM.SelectCommand = this.sqlSelectCommand5;
            this.sqldaCentrosClientesSAP_COM.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaCentrosClientesSAP_COM", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iIdCliente", "iIdCliente"),
                        new System.Data.Common.DataColumnMapping("sIdCliente", "sIdCliente"),
                        new System.Data.Common.DataColumnMapping("sTipoCliente", "sTipoCliente"),
                        new System.Data.Common.DataColumnMapping("sLiteral", "sLiteral"),
                        new System.Data.Common.DataColumnMapping("sNombre", "sNombre"),
                        new System.Data.Common.DataColumnMapping("sIdTipoRelacion", "sIdTipoRelacion"),
                        new System.Data.Common.DataColumnMapping("bEnviadoCEN", "bEnviadoCEN")}),
            new System.Data.Common.DataTableMapping("Table1", "Table1", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iIdCliente", "iIdCliente"),
                        new System.Data.Common.DataColumnMapping("sIdCliente", "sIdCliente"),
                        new System.Data.Common.DataColumnMapping("sTipoCliente", "sTipoCliente"),
                        new System.Data.Common.DataColumnMapping("sLiteral", "sLiteral"),
                        new System.Data.Common.DataColumnMapping("sNombre", "sNombre"),
                        new System.Data.Common.DataColumnMapping("sIdTipoRelacion", "sIdTipoRelacion")}),
            new System.Data.Common.DataTableMapping("Table2", "Table2", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iIdCliente", "iIdCliente"),
                        new System.Data.Common.DataColumnMapping("sIdCliente", "sIdCliente"),
                        new System.Data.Common.DataColumnMapping("sTipoCliente", "sTipoCliente"),
                        new System.Data.Common.DataColumnMapping("sLiteral", "sLiteral"),
                        new System.Data.Common.DataColumnMapping("sNombre", "sNombre"),
                        new System.Data.Common.DataColumnMapping("sIdTipoRelacion", "sIdTipoRelacion")})});
            // 
            // sqlSelectCommand5
            // 
            this.sqlSelectCommand5.CommandText = "[ListaCentrosClientesSAP_COM]";
            this.sqlSelectCommand5.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand5.Connection = this.sqlConn;
            this.sqlSelectCommand5.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdCentro", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sTipoCliente", System.Data.SqlDbType.VarChar, 1),
            new System.Data.SqlClient.SqlParameter("@sIdRed", System.Data.SqlDbType.VarChar, 4)});
            // 
            // sqldaListaCentrosCliCOM_Horarios
            // 
            this.sqldaListaCentrosCliCOM_Horarios.SelectCommand = this.sqlSelectCommand6;
            this.sqldaListaCentrosCliCOM_Horarios.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaCentrosCliCOM_Horarios", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iIdCliente", "iIdCliente"),
                        new System.Data.Common.DataColumnMapping("iIdCentro", "iIdCentro"),
                        new System.Data.Common.DataColumnMapping("sDia", "sDia"),
                        new System.Data.Common.DataColumnMapping("sManTarde", "sManTarde"),
                        new System.Data.Common.DataColumnMapping("sHoraManIni", "sHoraManIni"),
                        new System.Data.Common.DataColumnMapping("sHoraManFin", "sHoraManFin"),
                        new System.Data.Common.DataColumnMapping("sHoraTarIni", "sHoraTarIni"),
                        new System.Data.Common.DataColumnMapping("sHoraTarFin", "sHoraTarFin"),
                        new System.Data.Common.DataColumnMapping("tObservaciones", "tObservaciones")})});
            // 
            // sqlSelectCommand6
            // 
            this.sqlSelectCommand6.CommandText = "[ListaCentrosCliCOM_Horarios]";
            this.sqlSelectCommand6.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand6.Connection = this.sqlConn;
            this.sqlSelectCommand6.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdCentro", System.Data.SqlDbType.Int, 4)});
            // 
            // ucBotoneraSecundaria1
            // 
            this.ucBotoneraSecundaria1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(117)))), ((int)(((byte)(1)))));
            this.ucBotoneraSecundaria1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucBotoneraSecundaria1.ForeColor = System.Drawing.Color.Black;
            this.ucBotoneraSecundaria1.Location = new System.Drawing.Point(0, 0);
            this.ucBotoneraSecundaria1.Name = "ucBotoneraSecundaria1";
            this.ucBotoneraSecundaria1.Size = new System.Drawing.Size(1246, 38);
            this.ucBotoneraSecundaria1.TabIndex = 35;
            // 
            // pnCentros
            // 
            this.pnCentros.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnCentros.Controls.Add(this.lblNumRegistros);
            this.pnCentros.Controls.Add(this.labelGradient2);
            this.pnCentros.Controls.Add(this.dgCentros);
            this.pnCentros.Location = new System.Drawing.Point(1, 115);
            this.pnCentros.Name = "pnCentros";
            this.pnCentros.Size = new System.Drawing.Size(1245, 240);
            this.pnCentros.TabIndex = 1;
            // 
            // lblNumRegistros
            // 
            this.lblNumRegistros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.lblNumRegistros.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblNumRegistros.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumRegistros.ForeColor = System.Drawing.Color.Black;
            this.lblNumRegistros.Location = new System.Drawing.Point(1182, -1);
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
            this.labelGradient2.Size = new System.Drawing.Size(1241, 18);
            this.labelGradient2.TabIndex = 83;
            this.labelGradient2.Text = "Centros";
            this.labelGradient2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sqldaListaRedes
            // 
            this.sqldaListaRedes.SelectCommand = this.sqlSelectCommand7;
            this.sqldaListaRedes.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaRedes", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("sValor", "sValor"),
                        new System.Data.Common.DataColumnMapping("sLiteral", "sLiteral")})});
            // 
            // sqlSelectCommand7
            // 
            this.sqlSelectCommand7.CommandText = "[ListaRedes]";
            this.sqlSelectCommand7.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand7.Connection = this.sqlConn;
            this.sqlSelectCommand7.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null)});
            // 
            // sqldaListaEstado
            // 
            this.sqldaListaEstado.SelectCommand = this.sqlSelectCommand8;
            this.sqldaListaEstado.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaEstados", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("sValor", "sValor"),
                        new System.Data.Common.DataColumnMapping("sLiteral", "sLiteral")})});
            // 
            // sqlSelectCommand8
            // 
            this.sqlSelectCommand8.CommandText = "[ListaEstados]";
            this.sqlSelectCommand8.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand8.Connection = this.sqlConn;
            this.sqlSelectCommand8.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null)});
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
            // frmConsultaCentros
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.ClientSize = new System.Drawing.Size(1263, 376);
            this.Controls.Add(this.pnCentros);
            this.Controls.Add(this.ucBotoneraSecundaria1);
            this.Controls.Add(this.pnDatos);
            this.Controls.Add(this.panel3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmConsultaCentros";
            this.Text = "Consulta de Centros";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Closed += new System.EventHandler(this.frmConsultaCentros_Closed);
            this.Load += new System.EventHandler(this.frmConsultaCentros_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgCentros)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsCentros1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.pnDatos.ResumeLayout(false);
            this.pnDatos.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgCentrosClientes)).EndInit();
            this.pnCentros.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		#region LOAD
		private void frmConsultaCentros_Load(object sender, System.EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;
			try
			{
				Application.DoEvents();
				Utiles.Formato_Formulario(this);
				if(this.Parent == null) this.WindowState = FormWindowState.Normal;
				Application.DoEvents();
				IniPantalla();
				Inicializa_cboRed();
				this.cboRed.SelectedValue= Clases.Configuracion.sIdRed ;
				if(Clases.Configuracion.iTodosCentros==0 ) this.cboRed.Enabled=false;//La red queda Fijada
				Application.DoEvents();
				Inicializa_cboEstado();
				Inicializar_Botonera();
				if(this.ParamI_sIdCentro != null)
				{
					BuscarPorCentro(ParamI_sIdCentro);
				}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
			Cursor.Current = Cursors.Default;
		}
		#endregion

		#region INI Variables
		private void Ini_Variables()
		{
			this.Var_fila =-1;
			this.Var_iIdCentro =-1;
			this.Var_TipoCliente = "T";
			this.Var_iIdClienteCOM =-1;
		}
		#endregion
		
		#region Inicializa los datos de la pantalla
		private void IniPantalla()
		{
			try
			{
				fuenteBold = new System.Drawing.Font("Microsoft Sans Serif",8.25F,FontStyle.Bold);
				fuenteNoBold = new System.Drawing.Font("Microsoft Sans Serif",8.25F);
				//this.pnClientesCentros.Location = new Point(1,384);
				GESTCRM.Utiles.Formatear_DataGrid(this,this.dgCentros,null,true);
				GESTCRM.Utiles.Formatear_DataGrid(this,this.dgCentrosClientes,"C",true);
				//GESTCRM.Utiles.Formatear_DgConFilabEnviadoCEN(this.dgCentrosClientes,null,null);
				//GESTCRM.Utiles.Formatear_DataGrid(this,this.dgHorariosCentros,"C",true);
			
				//Llena Combo Delegados			
				DataRow fila_dele = this.dsCentros1.ListaDelegados.NewRow();
				fila_dele.BeginEdit();
				fila_dele[0] = -1;
				fila_dele[1] = "Todos";
				fila_dele.EndEdit();
				this.dsCentros1.ListaDelegados.Rows.InsertAt(fila_dele,0);
				this.sqldaListaDelegados.Fill(this.dsCentros1.ListaDelegados);
				this.cboDelegado.SelectedValue = GESTCRM.Clases.Configuracion.iIdDelegado;
			
				//Llena Combo TiposCentro
				DataRow fila_TipoCentro = this.dsCentros1.ListaTipoCentro.NewRow();
				fila_TipoCentro.BeginEdit();
				fila_TipoCentro[0] = "-1";
				fila_TipoCentro[1] = "Todos";
				fila_TipoCentro.EndEdit();
				this.dsCentros1.ListaTipoCentro.Rows.InsertAt(fila_TipoCentro,0);			
				this.sqldaTipoCentro.Fill(this.dsCentros1.ListaTipoCentro);
				this.cboTipoCentro.SelectedValue = "-1";
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region Boton Buscar Poblacion
		private void btnBuscPob_Click(object sender, System.EventArgs e)
		{
			try
			{
				GESTCRM.Formularios.Busquedas.frmMPoblaciones frmBPob = new GESTCRM.Formularios.Busquedas.frmMPoblaciones();
				frmBPob.ShowDialog(this);

				if(frmBPob._ValorAceptar != null)
				{
					int iIdPoblacion = frmBPob.ParamO_iIdPoblacion;
					this.txbIdPoblacion.Text= iIdPoblacion.ToString();
					this.txbBPoblacion.Text = frmBPob.ParamO_sPoblacion;
					this.txtCodPostal.Text = frmBPob.ParamO_sCodPostal;
				}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}

		#endregion

		#region Buscar por un Centro en Concreto
		private void BuscarPorCentro(string BsIdCentro)
		{
			try
			{
				this.cboDelegado.SelectedValue = "-1";
				this.cboTipoCentro.SelectedValue = "-1";
				this.txbIdPoblacion.Text = "";
				this.txbCodCentro.Text = "";
				this.txbNomCentro.Text = "";
				this.txtCodPostal.Text = "";
				this.txbBPoblacion.Text = "";
				txbCodCentro.Text = BsIdCentro.ToString();
				BuscarCentros();
				Utiles.Activar_Panel(panel3,false);
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region Boton Buscar Centros
		private void BuscarCentros()
		{
			Cursor.Current = Cursors.WaitCursor;
			try
			{
				//Validar
				if (this.cboDelegado.SelectedValue == null) 
				{
					//MessageBox.Show ("Debe elegir un Delegado que este en la lista");
                    Mensajes.ShowInformation("Debe elegir un Delegado que esté en la lista.");
					return;
				}
				if (cboTipoCentro.SelectedValue == null) 
				{
					//MessageBox.Show ("Debe elegir un Tipo de Centro que este en la lista");
                    Mensajes.ShowInformation("Debe elegir un Tipo de Centro que esté en la lista.");
					return;
				}

				//Buscar Centros
				string sCodPostal="-1";
				if(this.txtCodPostal.Text.ToString().Trim().Length>0) sCodPostal=this.txtCodPostal.Text.ToString();

				this.dsCentros1.ListaCentros.Rows.Clear();
				this.sqldaListaCentros.SelectCommand.Parameters["@iIdDelegado"].Value = (int.Parse(this.cboDelegado.SelectedValue.ToString()) == -1)?null:cboDelegado.SelectedValue;
				this.sqldaListaCentros.SelectCommand.Parameters["@sIdTipoCentro"].Value = (this.cboTipoCentro.SelectedValue.ToString() == "-1")?null:cboTipoCentro.SelectedValue;
				this.sqldaListaCentros.SelectCommand.Parameters["@iIdPoblacion"].Value = (this.txbIdPoblacion.Text.ToString() == "")?null:txbIdPoblacion.Text;
				this.sqldaListaCentros.SelectCommand.Parameters["@sIdCentro"].Value = (this.txbCodCentro.Text.ToString()== "")?null:txbCodCentro.Text;
				this.sqldaListaCentros.SelectCommand.Parameters["@sDescripcion"].Value=(this.txbNomCentro.Text.ToString() == "")?null:txbNomCentro.Text;
				this.sqldaListaCentros.SelectCommand.Parameters["@sCodPostal"].Value=(this.txtCodPostal.Text.ToString() == "-1")?null:txtCodPostal.Text;
				this.sqldaListaCentros.SelectCommand.Parameters["@sPoblacion"].Value=(this.txbBPoblacion.Text.ToString() == "-1")?null:txbBPoblacion.Text;

				this.sqldaListaCentros.SelectCommand.Parameters["@sIdRed"].Value = cboRed.SelectedValue;
				this.sqldaListaCentros.SelectCommand.Parameters["@iEstado"].Value = cboEstado.SelectedValue;
				//this.sqldaListaCentros.SelectCommand.Parameters["@iIdProvincia"].Value=(this.txbNomCentro.Text.ToString() == "")?null:txbNomCentro.Text;
				this.sqldaListaCentros.Fill(this.dsCentros1);
				if (this.dsCentros1.ListaCentros.Rows.Count >0)
				{	
					this.lblNumRegistros.Text = (this.dsCentros1.ListaCentros.Rows.Count).ToString();
				}
				else
				{
					this.lblNumRegistros.Text ="0";
					dgCentros.Refresh();
				}

				// Borra Datos Clientes Centros. Prepara para Todos los TiposCliente
				this.dsCentros1.ListaCentrosClientesSAP_COM.Rows.Clear();
			
				// Borra Datos Centro de los TextBox
				BorraDatosCentros();

				if ( this.dsCentros1.ListaCentros.Rows.Count>0)
				{
					this.dgCentros.CurrentCell = new DataGridCell(0,1);
					this.dgCentros.CurrentCell = new DataGridCell(0,0);
				}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}

			Cursor.Current = Cursors.Default;
		}
		#endregion

		#region Boton Buscar Centros
		private void btnBuscarC_Click(object sender, System.EventArgs e)
		{
			BuscarCentros();
		}
		#endregion
		
		#region Cambia Celda Grid Centros
		private void dgCentros_CurrentCellChanged(object sender, System.EventArgs e)
		{
			try
			{
				Utiles.Seleccionar_UnaFilaDataGrid(this,this.dgCentros,this.dgCentros.CurrentRowIndex);
				string sIdCentro = this.dgCentros[this.dgCentros.CurrentRowIndex,1].ToString();
				this.Var_iIdCentro = int.Parse(this.dgCentros[this.dgCentros.CurrentRowIndex,0].ToString());
				this.Var_fila = -1;
			
				// Borra la Lista de Horarios CLiente Com, ya que estamos cambiando el Centro y este tendrá distintos clientes
				BorraDatos_CentrosCliCOM_Horarios();
					
				for(int i=0; i< this.dsCentros1.ListaCentros.Rows.Count;i++)
				{
					if(this.dsCentros1.ListaCentros.Rows[i]["sIdCentro"].ToString()==sIdCentro)
					{
						this.Var_fila=i;
						break;
					}
				}

				if(this.Var_fila>-1)
				{
					Llenar_pnDatos(this.Var_fila, this.Var_iIdCentro);
					// Llena Centros Clientes en funcion del TipoCliente seleccionad
					this.Var_TipoCliente = "T";
					this.dsCentros1.ListaCentrosClientesSAP_COM.Rows.Clear();
					this.sqldaCentrosClientesSAP_COM.SelectCommand.Parameters["@iIdCentro"].Value = (this.Var_iIdCentro.ToString() == "")?null:this.Var_iIdCentro.ToString();
					this.sqldaCentrosClientesSAP_COM.SelectCommand.Parameters["@sTipoCliente"].Value = this.Var_TipoCliente.ToString();
					this.sqldaCentrosClientesSAP_COM.SelectCommand.Parameters["@sIdRed"].Value = this.dgCentros[this.dgCentros.CurrentRowIndex,8].ToString();

					this.sqldaCentrosClientesSAP_COM.Fill(this.dsCentros1);
					if (this.dsCentros1.ListaCentrosClientesSAP_COM.Rows.Count >0)
					{	
						this.lblNumRegCC.Text = (this.dsCentros1.ListaCentrosClientesSAP_COM.Rows.Count).ToString();
					}
					else
					{
						this.lblNumRegCC.Text ="";
					}
					if (dgCentros.CurrentRowIndex != -1)
					{
						if (this.dgCentros[this.dgCentros.CurrentRowIndex,6].ToString() == "Pendiente" || this.dgCentros[this.dgCentros.CurrentRowIndex,6].ToString() == "Activo" )
						{
							this.ucBotoneraSecundaria1.Activar_botonera(true,true,true,true,false,false);
							menuEliminar.Enabled = true;
						}
						else
						{
							this.ucBotoneraSecundaria1.Activar_botonera(true,true,true,false,false,false);
							menuEliminar.Enabled = false;
						}
					}
				}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region Llena Panel Datos CliCOM Horarios
		private void Llenar_pnCentrosCliCOM_Horarios()
		{
			try
			{
				// Llena Datos Centro
//				this.txtsDiaCCH.Text = this.dsCentros1.ListaCentrosCliCOM_Horarios.Rows[0]["sDia"].ToString();
//				this.txtsManTardeCCH.Text = this.dsCentros1.ListaCentrosCliCOM_Horarios.Rows[0]["sManTarde"].ToString();
//				this.txtsHoraManIniCCH.Text = this.dsCentros1.ListaCentrosCliCOM_Horarios.Rows[0]["sHoraManIni"].ToString();
//				this.txtsHoraManFinCCH.Text = this.dsCentros1.ListaCentrosCliCOM_Horarios.Rows[0]["sHoraManFin"].ToString();
//				this.txtsHoraTarIniCCH.Text = this.dsCentros1.ListaCentrosCliCOM_Horarios.Rows[0]["sHoraTarIni"].ToString();
//				this.txtsHoraTarFinCCH.Text = this.dsCentros1.ListaCentrosCliCOM_Horarios.Rows[0]["sHoraTarFin"].ToString();
//				this.txttObsCCH.Text = this.dsCentros1.ListaCentrosCliCOM_Horarios.Rows[0]["tObservaciones"].ToString();
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region Llena Panel Datos Centros
		private void Llenar_pnDatos(int fila, int iIdCentro)
		{
			try
			{
				// Llena Datos Centro
				this.txtsIdCentro.Text = this.dsCentros1.ListaCentros.Rows[fila]["sIdCentro"].ToString();
				this.txtsDecricpion.Text = this.dsCentros1.ListaCentros.Rows[fila]["sDescripcion"].ToString();
				this.txtsDireccion.Text = this.dsCentros1.ListaCentros.Rows[fila]["sDireccion"].ToString();
				this.txtsCodPostal.Text = this.dsCentros1.ListaCentros.Rows[fila]["CodPostal"].ToString();
				this.txtsPoblacion.Text = this.dsCentros1.ListaCentros.Rows[fila]["sPoblacion"].ToString();
				this.txtsProvincia.Text = this.dsCentros1.ListaCentros.Rows[fila]["sProvincia"].ToString();
				this.txtsTelefono.Text = this.dsCentros1.ListaCentros.Rows[fila]["sTelefono"].ToString();
				this.txtsFax.Text = this.dsCentros1.ListaCentros.Rows[fila]["sFax"].ToString();
				//this.txtsIdAtenVisitas.Text = this.dsCentros1.ListaCentros.Rows[fila]["sIdAtenVisitas"].ToString();
				this.txtsIdTipoClasificacion.Text = this.dsCentros1.ListaCentros.Rows[fila]["sIdTipoClasificacion"].ToString();
				this.txtbPactoPrescripcion.Text = Utiles.DevuelveSI_NO(this.dsCentros1.ListaCentros.Rows[fila]["bPactoPrescripcion"].ToString());
				this.txtsIdPoliticaPrescripcion.Text = this.dsCentros1.ListaCentros.Rows[fila]["sIdPolPrescripcion"].ToString();
				this.txtbVisitaColectiva.Text = Utiles.DevuelveSI_NO(this.dsCentros1.ListaCentros.Rows[fila]["bVisitaColectiva"].ToString());
				this.txtsIdSistInformatico.Text = this.dsCentros1.ListaCentros.Rows[fila]["sIdSistInformatico"].ToString();
						
				// Llena Horarios Centro Visita
				//this.dsCentros1.ListaCentrosHorariosVisitas.Rows.Clear();
				//this.sqldaCentrosHorariosVisitas.SelectCommand.Parameters["@iIdCentro"].Value = Convert.ToInt32(this.dgCentros[this.dgCentros.CurrentRowIndex,0].ToString());
				//this.sqldaCentrosHorariosVisitas.Fill(this.dsCentros1);
				//if (this.dsCentros1.ListaCentrosHorariosVisitas.Rows.Count >0)
				//{	
				//	this.lblNumRegHC.Text = (this.dsCentros1.ListaCentrosHorariosVisitas.Rows.Count).ToString();
				//}
				//else
				//{
				//	this.lblNumRegHC.Text ="";
				//}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

//		#region Boton Datos Centro
//		private void btDatosCentro_Click(object sender, System.EventArgs e)
//		{
//			try
//			{
//				this.btDatosCentro.Font = this.fuenteBold;
//				this.btClientesCentro.Font = this.fuenteNoBold;
//				//this.pnClientesCentros.Visible = false;
//				this.pnDatos.Visible = true;
//				if (this.Var_iIdCentro > 0)
//				{
//					Llenar_pnDatos(this.Var_fila, this.Var_iIdCentro);
//				}
//			}
//			catch(Exception ex){Mensajes.ShowError(ex.Message);}
//		}
//		#endregion
		
		#region Inicializa_cboRed
		private void Inicializa_cboRed()
		{
			try
			{
				this.sqldaListaRedes.Fill(this.dsCentros1);
				DataRow filaTodos = this.dsCentros1.ListaRedes.NewRow();
				filaTodos["sValor"]="T";
				filaTodos["sLiteral"]="Todos";
				this.dsCentros1.ListaRedes.Rows.InsertAt(filaTodos,0);
				
			}
			catch (Exception ex)
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
				this.sqldaListaEstado.Fill(this.dsCentros1);
				DataRow filaTodos = this.dsCentros1.ListaEstados.NewRow();
				filaTodos["sValor"]="2";
				filaTodos["sLiteral"]="Todos";
				this.dsCentros1.ListaEstados.Rows.InsertAt(filaTodos,0);
				cboEstado.SelectedValue = "2";
				
			}
			catch (Exception ex)
			{
				Mensajes.ShowError(ex.Message);
			}
		}
		#endregion

//		#region Boton Clientes Centro
//		private void btClientesCentro_Click(object sender, System.EventArgs e)
//		{
//			try
//			{
//				this.btDatosCentro.Font = this.fuenteNoBold;
//				this.btClientesCentro.Font = this.fuenteBold;
//				//this.pnClientesCentros.Visible = true;
//				this.pnDatos.Visible = false;
//
//				// muestra todos los clientes
//				if (this.Var_iIdCentro >0)
//				{
//					this.Var_TipoCliente = "T";		
//					this.dsCentros1.ListaCentrosClientesSAP_COM.Rows.Clear();
//					this.sqldaCentrosClientesSAP_COM.SelectCommand.Parameters["@iIdCentro"].Value = (this.Var_iIdCentro.ToString() == "")?null:this.Var_iIdCentro.ToString();
//					this.sqldaCentrosClientesSAP_COM.SelectCommand.Parameters["@sTipoCliente"].Value = this.Var_TipoCliente;
//					this.sqldaCentrosClientesSAP_COM.Fill(this.dsCentros1);
//				}
//				if(this.dsCentros1.ListaCentrosClientesSAP_COM.Rows.Count>0)
//				{
//					this.dgCentrosClientes.CurrentCell = new DataGridCell(0,1);
//					this.dgCentrosClientes.CurrentCell = new DataGridCell(0,0);
//					Utiles.Seleccionar_UnaFilaDataGrid(this,this.dgCentrosClientes,0);
//				}
//			}
//			catch(Exception ex){Mensajes.ShowError(ex.Message);}
//		}
//		#endregion

		#region Cambio Celda Clientes Centro
		private void dgCentrosClientes_CurrentCellChanged(object sender, System.EventArgs e)
		{
			try
			{
				Utiles.Seleccionar_UnaFilaDataGrid(this,this.dgCentrosClientes,this.dgCentrosClientes.CurrentRowIndex);
				this.Var_iIdCentro = int.Parse(this.dgCentros[this.dgCentros.CurrentRowIndex,0].ToString());
				this.Var_iIdClienteCOM = int.Parse(this.dgCentrosClientes[this.dgCentrosClientes.CurrentRowIndex,0].ToString());
				this.Var_filaClienteCentro = -1;
			
				for(int i=0; i< this.dsCentros1.ListaCentrosClientesSAP_COM.Rows.Count;i++)
				{
					if(int.Parse(this.dsCentros1.ListaCentrosClientesSAP_COM.Rows[i]["iIdCliente"].ToString()) == this.Var_iIdCentro) 
					{
						this.Var_filaClienteCentro=i;
						break;
					}
				}

				if(this.Var_filaClienteCentro>-1)
				{
					// Llena ClientesCOM Horarios
					this.dsCentros1.ListaCentrosCliCOM_Horarios.Rows.Clear();
					this.sqldaListaCentrosCliCOM_Horarios.SelectCommand.Parameters["@iIdCentro"].Value = (this.Var_iIdCentro.ToString() == "")?null:this.Var_iIdCentro.ToString();
					this.sqldaListaCentrosCliCOM_Horarios.SelectCommand.Parameters["@iIdCliente"].Value = (this.Var_iIdClienteCOM.ToString() == "")?null:this.Var_iIdClienteCOM.ToString();
					this.sqldaListaCentrosCliCOM_Horarios.Fill(this.dsCentros1);
					if (this.dsCentros1.ListaCentrosCliCOM_Horarios.Rows.Count >0)
					{
						Llenar_pnCentrosCliCOM_Horarios();
					}
					else
					{
						BorraDatos_CentrosCliCOM_Horarios();
					}
				}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

//		#region Cambio Celda Horarios Centro
//		private void dgHorariosCentros_CurrentCellChanged(object sender, System.EventArgs e)
//		{
//			Utiles.Seleccionar_UnaFilaDataGrid(this,this.dgHorariosCentros,this.dgHorariosCentros.CurrentRowIndex);
//		}
//		#endregion

		#region Borrar Datos Centro
		private void BorraDatosCentros()
		{
			try
			{
				this.txtsIdCentro.Text = "";
				this.txtsDecricpion.Text = "";
				this.txtsDireccion.Text =  "";
				this.txtsCodPostal.Text =  "";
				this.txtsPoblacion.Text =  "";
				this.txtsProvincia.Text =  "";
				this.txtsTelefono.Text =  "";
				this.txtsFax.Text =  "";
				this.txtsIdAtenVisitas.Text = "";
				this.txtsIdTipoClasificacion.Text = "";
				this.txtbPactoPrescripcion.Text = "";
				this.txtsIdPoliticaPrescripcion.Text = "";
				this.txtbVisitaColectiva.Text = "";
				this.txtsIdSistInformatico.Text = "";
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region Borrar Datos Centros CliCOM_Horarios
		private void BorraDatos_CentrosCliCOM_Horarios()
		{
			try
			{
//				this.txtsDiaCCH.Text = ""; 
//				this.txtsManTardeCCH.Text = "";
//				this.txtsHoraManIniCCH.Text = "";
//				this.txtsHoraManFinCCH.Text = "";
//				this.txtsHoraTarIniCCH.Text = "";
//				this.txtsHoraTarFinCCH.Text = "";
//				this.txttObsCCH.Text = "";
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region Borrar Grids
		private void BorrarGrids()
		{
			try
			{
				Ini_Variables();
				BorraDatos_CentrosCliCOM_Horarios();
				BorraDatosCentros();
				this.dsCentros1.ListaCentros.Rows.Clear();
				this.dsCentros1.ListaCentrosHorariosVisitas.Rows.Clear();
				this.dsCentros1.ListaCentrosClientesSAP_COM.Rows.Clear();
				this.dsCentros1.ListaCentrosCliCOM_Horarios.Rows.Clear();
				this.lblNumRegistros.Text ="";
				this.lblNumRegCC.Text ="";
//				this.lblNumRegHC.Text ="";
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region Quita iIdPoblacion
		private void txbBPoblacion_Leave(object sender, System.EventArgs e)
		{
			try
			{
				// Quita el iIdPoblacion cuando no hay descripcion de esta
				if (this.txbBPoblacion.Text == "")
				{
					this.txbIdPoblacion.Text ="";
				}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region Change de Objetos
		private void txtCodPostal_TextChanged(object sender, System.EventArgs e)
		{
			BorrarGrids();
		}

		private void cboDelegado_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			BorrarGrids();
		}

		private void cboTipoCentro_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			BorrarGrids();
		}

		private void txbCodCentro_TextChanged(object sender, System.EventArgs e)
		{
			BorrarGrids();
		}

		private void txbNomCentro_TextChanged(object sender, System.EventArgs e)
		{
			BorrarGrids();
		}

		private void txbBPoblacion_TextChanged(object sender, System.EventArgs e)
		{
			BorrarGrids();
		}

		private void txtCodPostal_Leave(object sender, System.EventArgs e)
		{
			this.txbIdPoblacion.Text = "";
		}

		#endregion
		
		#region Cerrar
		private void btSalir_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
		#endregion

		#region frmConsultaCentros_Closed
		private void frmConsultaCentros_Closed(object sender, System.EventArgs e)
		{
			this.Dispose();
		}
		#endregion

		#region Inicializar_Botonera
		private void Inicializar_Botonera()
		{
			try
			{
				if(GESTCRM.Clases.Configuracion.iGCentros!=0)
				{
					this.ucBotoneraSecundaria1.Activar_botonera(true,true,true,false,false,false);
					menuEliminar.Enabled = false;
				}
				else
				{
					this.ucBotoneraSecundaria1.Activar_botonera(true,true,true,false,false,false);
					menuEliminar.Enabled = false;
				}
				this.ucBotoneraSecundaria1.btSalir.Click += new EventHandler(btSalir_Click);
				this.ucBotoneraSecundaria1.btNuevo.Click += new EventHandler(btNuevo_Click);
				this.ucBotoneraSecundaria1.btEditar.Click += new EventHandler(btEditar_Click);
				this.ucBotoneraSecundaria1.btEliminar.Click += new EventHandler (btEliminar_Click);
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion
		#region btEliminar_Click
		private void btEliminar_Click(object sender, System.EventArgs e)
		{
			BorrarCentro();
		}
		#endregion

		#region btNuevo_Click
		private void btNuevo_Click(object sender, System.EventArgs e)
		{	
			AltaCentros();
		}
		#endregion

		#region btEditar_Click
		private void btEditar_Click(object sender, System.EventArgs e)
		{
			EditarCentro();				
		}
		#endregion
		#region Alta_Centro
		private void AltaCentros()
		{
			
			Form frmTemp=new Formularios.frmAltaCentros("A",-1,DateTime.Now,GESTCRM.Clases.Configuracion.iIdDelegado);
			frmTemp.MdiParent=this.MdiParent;
			frmTemp.Show();
		
		}
		#endregion

		#region Leave de Objetos
		private void cboDelegado_Leave(object sender, System.EventArgs e)
		{
			try
			{
				if(this.cboDelegado.SelectedIndex == -1)
				{
					this.cboDelegado.SelectedValue = GESTCRM.Clases.Configuracion.iIdDelegado;
				}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}

		private void cboTipoCentro_Leave(object sender, System.EventArgs e)
		{
			try
			{
				if(this.cboTipoCentro.SelectedIndex == -1)
				{
					this.cboTipoCentro.SelectedValue = "-1";
				}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		
		#endregion

		private void dgCentros_DoubleClick(object sender, System.EventArgs e)
		{
			EditarCentro();	
		}

		#region EditarCentro
		private void EditarCentro()
		{
			if (this.dgCentros.CurrentRowIndex !=-1)
			{
				int iIdcentro = int.Parse(this.dgCentros[this.dgCentros.CurrentRowIndex,0].ToString());
				Form frmTemp=new Formularios.frmAltaCentros("M",iIdcentro,DateTime.Now,GESTCRM.Clases.Configuracion.iIdDelegado);
				frmTemp.MdiParent=this.MdiParent;
				frmTemp.Show();
			}
		}
		#endregion

		private void BorrarCentro()
		{
			try
			{
				string sMensaje = "¿Esta seguro que desea eliminar el centro\n" +  this.dgCentros[this.dgCentros.CurrentRowIndex,2].ToString() + "?";
				if(Mensajes.ShowQuestion(sMensaje)== DialogResult.Yes)
				{
					
					if (this.sqlConn.State == ConnectionState.Closed)   this.sqlConn.Open();  
					sqlcmdSetCentros.Parameters["@iAccion"].Value = 2;
					sqlcmdSetCentros.Parameters["@iIdCentro"].Value = int.Parse(this.dgCentros[this.dgCentros.CurrentRowIndex,0].ToString());
					sqlcmdSetCentros.Parameters["@sIdRed"].Value = this.dgCentros[this.dgCentros.CurrentRowIndex,8].ToString();
					sqlcmdSetCentros.ExecuteNonQuery();
					this.dsCentros1.ListaCentros.Rows[this.dgCentros.CurrentRowIndex].Delete();
					this.dsCentros1.ListaCentros.AcceptChanges();
				}
			}
			catch(Exception Ex)
			{
				Mensajes.ShowError(Ex.Message);
			}
			finally
			{
				sqlConn.Close();
			}
		}

		private void menuNuevo_Click(object sender, System.EventArgs e)
		{
			AltaCentros();
		}

		private void menuEditar_Click(object sender, System.EventArgs e)
		{
			EditarCentro();	
		}

		private void menuEliminar_Click(object sender, System.EventArgs e)
		{
			BorrarCentro();
		}



	}
}
