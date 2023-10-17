using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using GESTCRM.Clases;


namespace GESTCRM.Formularios
{
	/// <summary>
	/// Descripción breve de frmPedidos.
	/// </summary>
	public class frmConsultaAtenciones : System.Windows.Forms.Form
	{
		int	Var_iIdCliente;
		int Var_fila;
		int Var_filaClientes;
		int Var_iIdAtencion;
		//		bool CambioDatos = false;


		private System.Windows.Forms.Panel panel3;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.ToolTip toolTipAtenciones;
		private System.Windows.Forms.ComboBox cboDelegado;
		private System.Windows.Forms.Label lblDelegado;
		private System.Windows.Forms.Label lblFechaSolicitud;
		private System.Windows.Forms.Label lblFechaLiq;
		private System.Windows.Forms.Label lblFechaAprob;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		private System.Windows.Forms.DataGrid dgAtenciones;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn10;
		private System.Windows.Forms.Button btnBuscar;
		private GESTCRM.Controles.ucBotoneraSecundaria ucBotoneraSecundaria1;
		private System.Windows.Forms.TextBox txtsIdAtencion;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn9;
		private System.Windows.Forms.Label lblCodigo;
		private System.Windows.Forms.TextBox txtDescripcion;
		private System.Windows.Forms.Label lblDescripcion;
		private System.Windows.Forms.DataGrid dgAtencionesClientes;
		private System.Data.SqlClient.SqlDataAdapter sqldaAtencionesClientes;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle2;
		private System.Windows.Forms.DataGridTextBoxColumn sIdCliente;
		private System.Windows.Forms.DataGridTextBoxColumn sNombre;
		private System.Windows.Forms.DataGridTextBoxColumn fImporte;
		private System.Windows.Forms.DataGridTextBoxColumn bSustituto;
		private System.Windows.Forms.DataGridTextBoxColumn dFecha;
		private GESTCRM.Controles.LabelGradient labelGradient1;
		private System.Windows.Forms.Label lblNumRegClientes;
		private System.Windows.Forms.DataGridTextBoxColumn sDescTipoCliente;
		private System.Windows.Forms.ContextMenu cntxMnuAtenciones;
		private System.Windows.Forms.Label lblComida;
		private System.Windows.Forms.ComboBox cboEstado;
		private System.Windows.Forms.Label lblEstado;
		private GESTCRM.Controles.LabelGradient labelGradient2;
		private System.Windows.Forms.Panel pnAtenciones;
		private System.Windows.Forms.Label lblNumRegAtenciones;
		private GESTCRM.Controles.LabelGradient labelGradient3;
		private System.Data.SqlClient.SqlConnection sqlConn;
		private GESTCRM.Formularios.DataSets.dsAtenciones dsAtenciones1;
		private System.Data.SqlClient.SqlDataAdapter sqldaListaAtencionesComerciales;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox cbBolsaViaje;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox cbTipoAtencion;
		private System.Windows.Forms.TextBox txtsIdCliente;
		private System.Windows.Forms.Button btBuscarCliente;
		private System.Windows.Forms.TextBox txtsCliente;
		private System.Windows.Forms.Label label9;
		private System.Data.SqlClient.SqlDataAdapter sqldaListaDelegados;
		private System.Data.SqlClient.SqlDataAdapter sqldaListaTipoEstadoAtencion;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand4;
		private System.Data.SqlClient.SqlDataAdapter sqldaListaTipoAtencionComercial;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand5;
		private System.Windows.Forms.MenuItem menuEditar;
		private System.Windows.Forms.MenuItem menuEliminar;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn11;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn12;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn13;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn14;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn15;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn16;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn17;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn18;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn19;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn22;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn23;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn24;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn25;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn26;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn27;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn28;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn29;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn30;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.DateTimePicker dtpFechaCierreIni;
		private System.Windows.Forms.DateTimePicker dtpFechaRealIni;
		private System.Windows.Forms.DateTimePicker dtpFechaAprob2Ini;
		private System.Windows.Forms.DateTimePicker dtpFechaPrevIni;
		private System.Windows.Forms.DateTimePicker dtpFechaLiqIni;
		private System.Windows.Forms.DateTimePicker dtpFechaAprob1Ini;
		private System.Windows.Forms.DateTimePicker dtpFechaPrevFin;
		private System.Windows.Forms.DateTimePicker dtpFechaAprob1Fin;
		private System.Windows.Forms.DateTimePicker dtpFechaAprob2Fin;
		private System.Windows.Forms.DateTimePicker dtpFechaLiqFin;
		private System.Windows.Forms.DateTimePicker dtpFechaRealFin;
		private System.Windows.Forms.DateTimePicker dtpFechaCierreFin;
		private System.Windows.Forms.TextBox txtsDescripcion;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtfImpPrev;
		private System.Windows.Forms.TextBox txtfImpReal;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.TextBox txtsIdEStadoAtencion;
		private System.Windows.Forms.TextBox txttsIdAtencion;
		private System.Windows.Forms.TextBox txtsIdTipoAtencion;
		private System.Windows.Forms.TextBox txtFechaPrev;
		private System.Windows.Forms.TextBox txtFechaAprob1;
		private System.Windows.Forms.TextBox txtFechaAprob2;
		private System.Windows.Forms.TextBox txtFechaReal;
		private System.Windows.Forms.TextBox txtFechaLiq;
		private System.Windows.Forms.TextBox txtFechaCierre;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.CheckBox chbBolsaViaje;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.TextBox txtsCentroCoste;
		private System.Windows.Forms.Panel pnDatosAtencion;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
		private System.Windows.Forms.Panel pnClientesPermanente;
		private System.Windows.Forms.Panel pnClienteManual;
		private System.Windows.Forms.TextBox txtFechaReport;
		private System.Windows.Forms.TextBox txtNombreCli;
		private System.Windows.Forms.TextBox txtTipoCli;
		private System.Windows.Forms.TextBox txtImpCliente;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.Label label28;
		private System.Windows.Forms.Label label29;
		private System.Windows.Forms.Label label30;
		private System.Windows.Forms.CheckBox chbSustituto;
		private GESTCRM.Controles.LabelGradient labelGradient4;
		private System.Windows.Forms.DateTimePicker dtpFReportIni;
		private System.Windows.Forms.DateTimePicker dtpFReportFin;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.Button btBuscarAtenCli;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		private System.Data.SqlClient.SqlCommand sqlCmdSetAtencionesComerciales;
		private System.Data.SqlClient.SqlDataAdapter sqldaGetCargoDelegado;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand6;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label31;
		private System.Windows.Forms.Label label32;
		private System.Windows.Forms.DateTimePicker dtpFechaCreacionFin;
		private System.Windows.Forms.DateTimePicker dtpFechaCreacionIni;
		private System.Windows.Forms.Label label33;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		private System.Windows.Forms.Label label34;
		private System.Windows.Forms.Label label35;
		private System.Windows.Forms.DateTimePicker dtpFechaAprob4Fin;
		private System.Windows.Forms.DateTimePicker dtpFechaAprob3Fin;
		private System.Windows.Forms.DateTimePicker dtpFechaAprob4Ini;
		private System.Windows.Forms.Label label36;
		private System.Windows.Forms.DateTimePicker dtpFechaAprob3Ini;
		private System.Windows.Forms.Label label37;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn5;
		private System.Windows.Forms.MenuItem menuNuevo;

		public frmConsultaAtenciones()
		{
			InitializeComponent();			
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmConsultaAtenciones));
			System.Configuration.AppSettingsReader configurationAppSettings = new System.Configuration.AppSettingsReader();
			this.panel3 = new System.Windows.Forms.Panel();
			this.label34 = new System.Windows.Forms.Label();
			this.label35 = new System.Windows.Forms.Label();
			this.dtpFechaAprob4Fin = new System.Windows.Forms.DateTimePicker();
			this.dtpFechaAprob3Fin = new System.Windows.Forms.DateTimePicker();
			this.dtpFechaAprob4Ini = new System.Windows.Forms.DateTimePicker();
			this.label36 = new System.Windows.Forms.Label();
			this.dtpFechaAprob3Ini = new System.Windows.Forms.DateTimePicker();
			this.label37 = new System.Windows.Forms.Label();
			this.label32 = new System.Windows.Forms.Label();
			this.dtpFechaCreacionFin = new System.Windows.Forms.DateTimePicker();
			this.dtpFechaCreacionIni = new System.Windows.Forms.DateTimePicker();
			this.label33 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.dtpFechaCierreFin = new System.Windows.Forms.DateTimePicker();
			this.dtpFechaLiqFin = new System.Windows.Forms.DateTimePicker();
			this.dtpFechaRealFin = new System.Windows.Forms.DateTimePicker();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.dtpFechaAprob2Fin = new System.Windows.Forms.DateTimePicker();
			this.dtpFechaAprob1Fin = new System.Windows.Forms.DateTimePicker();
			this.dtpFechaPrevFin = new System.Windows.Forms.DateTimePicker();
			this.txtsIdCliente = new System.Windows.Forms.TextBox();
			this.btBuscarCliente = new System.Windows.Forms.Button();
			this.txtsCliente = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.cbTipoAtencion = new System.Windows.Forms.ComboBox();
			this.dsAtenciones1 = new GESTCRM.Formularios.DataSets.dsAtenciones();
			this.cbBolsaViaje = new System.Windows.Forms.ComboBox();
			this.dtpFechaCierreIni = new System.Windows.Forms.DateTimePicker();
			this.label3 = new System.Windows.Forms.Label();
			this.dtpFechaRealIni = new System.Windows.Forms.DateTimePicker();
			this.label2 = new System.Windows.Forms.Label();
			this.dtpFechaAprob2Ini = new System.Windows.Forms.DateTimePicker();
			this.label1 = new System.Windows.Forms.Label();
			this.cboEstado = new System.Windows.Forms.ComboBox();
			this.lblEstado = new System.Windows.Forms.Label();
			this.labelGradient1 = new GESTCRM.Controles.LabelGradient();
			this.txtsIdAtencion = new System.Windows.Forms.TextBox();
			this.dtpFechaPrevIni = new System.Windows.Forms.DateTimePicker();
			this.lblFechaSolicitud = new System.Windows.Forms.Label();
			this.dtpFechaLiqIni = new System.Windows.Forms.DateTimePicker();
			this.dtpFechaAprob1Ini = new System.Windows.Forms.DateTimePicker();
			this.lblFechaLiq = new System.Windows.Forms.Label();
			this.lblFechaAprob = new System.Windows.Forms.Label();
			this.cboDelegado = new System.Windows.Forms.ComboBox();
			this.btnBuscar = new System.Windows.Forms.Button();
			this.lblComida = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.lblCodigo = new System.Windows.Forms.Label();
			this.lblDelegado = new System.Windows.Forms.Label();
			this.toolTipAtenciones = new System.Windows.Forms.ToolTip(this.components);
			this.btBuscarAtenCli = new System.Windows.Forms.Button();
			this.dgAtenciones = new System.Windows.Forms.DataGrid();
			this.cntxMnuAtenciones = new System.Windows.Forms.ContextMenu();
			this.menuNuevo = new System.Windows.Forms.MenuItem();
			this.menuEditar = new System.Windows.Forms.MenuItem();
			this.menuEliminar = new System.Windows.Forms.MenuItem();
			this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
			this.dataGridTextBoxColumn10 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn28 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn30 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn9 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn11 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn12 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn13 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn14 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn15 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn16 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn17 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn18 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn19 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn22 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn23 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn25 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn24 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn5 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn26 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn27 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn29 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.sqldaListaAtencionesComerciales = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlConn = new System.Data.SqlClient.SqlConnection();
			this.sqldaListaDelegados = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlCmdSetAtencionesComerciales = new System.Data.SqlClient.SqlCommand();
			this.ucBotoneraSecundaria1 = new GESTCRM.Controles.ucBotoneraSecundaria();
			this.txtDescripcion = new System.Windows.Forms.TextBox();
			this.lblDescripcion = new System.Windows.Forms.Label();
			this.dgAtencionesClientes = new System.Windows.Forms.DataGrid();
			this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
			this.dFecha = new System.Windows.Forms.DataGridTextBoxColumn();
			this.sIdCliente = new System.Windows.Forms.DataGridTextBoxColumn();
			this.sNombre = new System.Windows.Forms.DataGridTextBoxColumn();
			this.sDescTipoCliente = new System.Windows.Forms.DataGridTextBoxColumn();
			this.bSustituto = new System.Windows.Forms.DataGridTextBoxColumn();
			this.fImporte = new System.Windows.Forms.DataGridTextBoxColumn();
			this.sqldaAtencionesClientes = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
			this.lblNumRegClientes = new System.Windows.Forms.Label();
			this.sqldaListaTipoEstadoAtencion = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand4 = new System.Data.SqlClient.SqlCommand();
			this.pnAtenciones = new System.Windows.Forms.Panel();
			this.lblNumRegAtenciones = new System.Windows.Forms.Label();
			this.labelGradient2 = new GESTCRM.Controles.LabelGradient();
			this.pnClientesPermanente = new System.Windows.Forms.Panel();
			this.label27 = new System.Windows.Forms.Label();
			this.label26 = new System.Windows.Forms.Label();
			this.dtpFReportFin = new System.Windows.Forms.DateTimePicker();
			this.dtpFReportIni = new System.Windows.Forms.DateTimePicker();
			this.labelGradient3 = new GESTCRM.Controles.LabelGradient();
			this.sqldaListaTipoAtencionComercial = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand5 = new System.Data.SqlClient.SqlCommand();
			this.pnDatosAtencion = new System.Windows.Forms.Panel();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label31 = new System.Windows.Forms.Label();
			this.pnClienteManual = new System.Windows.Forms.Panel();
			this.labelGradient4 = new GESTCRM.Controles.LabelGradient();
			this.chbSustituto = new System.Windows.Forms.CheckBox();
			this.txtImpCliente = new System.Windows.Forms.TextBox();
			this.txtTipoCli = new System.Windows.Forms.TextBox();
			this.txtNombreCli = new System.Windows.Forms.TextBox();
			this.txtFechaReport = new System.Windows.Forms.TextBox();
			this.label30 = new System.Windows.Forms.Label();
			this.label29 = new System.Windows.Forms.Label();
			this.label25 = new System.Windows.Forms.Label();
			this.label28 = new System.Windows.Forms.Label();
			this.txtsCentroCoste = new System.Windows.Forms.TextBox();
			this.chbBolsaViaje = new System.Windows.Forms.CheckBox();
			this.txtFechaLiq = new System.Windows.Forms.TextBox();
			this.txtFechaReal = new System.Windows.Forms.TextBox();
			this.txtFechaAprob2 = new System.Windows.Forms.TextBox();
			this.txtFechaAprob1 = new System.Windows.Forms.TextBox();
			this.txtFechaPrev = new System.Windows.Forms.TextBox();
			this.txtsIdTipoAtencion = new System.Windows.Forms.TextBox();
			this.txttsIdAtencion = new System.Windows.Forms.TextBox();
			this.txtsIdEStadoAtencion = new System.Windows.Forms.TextBox();
			this.txtfImpReal = new System.Windows.Forms.TextBox();
			this.txtfImpPrev = new System.Windows.Forms.TextBox();
			this.txtsDescripcion = new System.Windows.Forms.TextBox();
			this.txtFechaCierre = new System.Windows.Forms.TextBox();
			this.label20 = new System.Windows.Forms.Label();
			this.label19 = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.label21 = new System.Windows.Forms.Label();
			this.label23 = new System.Windows.Forms.Label();
			this.label22 = new System.Windows.Forms.Label();
			this.label24 = new System.Windows.Forms.Label();
			this.sqldaGetCargoDelegado = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand6 = new System.Data.SqlClient.SqlCommand();
			this.panel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dsAtenciones1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgAtenciones)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgAtencionesClientes)).BeginInit();
			this.pnAtenciones.SuspendLayout();
			this.pnClientesPermanente.SuspendLayout();
			this.pnDatosAtencion.SuspendLayout();
			this.pnClienteManual.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel3
			// 
			this.panel3.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel3.Controls.Add(this.label34);
			this.panel3.Controls.Add(this.label35);
			this.panel3.Controls.Add(this.dtpFechaAprob4Fin);
			this.panel3.Controls.Add(this.dtpFechaAprob3Fin);
			this.panel3.Controls.Add(this.dtpFechaAprob4Ini);
			this.panel3.Controls.Add(this.label36);
			this.panel3.Controls.Add(this.dtpFechaAprob3Ini);
			this.panel3.Controls.Add(this.label37);
			this.panel3.Controls.Add(this.label32);
			this.panel3.Controls.Add(this.dtpFechaCreacionFin);
			this.panel3.Controls.Add(this.dtpFechaCreacionIni);
			this.panel3.Controls.Add(this.label33);
			this.panel3.Controls.Add(this.label10);
			this.panel3.Controls.Add(this.label11);
			this.panel3.Controls.Add(this.label12);
			this.panel3.Controls.Add(this.dtpFechaCierreFin);
			this.panel3.Controls.Add(this.dtpFechaLiqFin);
			this.panel3.Controls.Add(this.dtpFechaRealFin);
			this.panel3.Controls.Add(this.label8);
			this.panel3.Controls.Add(this.label7);
			this.panel3.Controls.Add(this.label6);
			this.panel3.Controls.Add(this.dtpFechaAprob2Fin);
			this.panel3.Controls.Add(this.dtpFechaAprob1Fin);
			this.panel3.Controls.Add(this.dtpFechaPrevFin);
			this.panel3.Controls.Add(this.txtsIdCliente);
			this.panel3.Controls.Add(this.btBuscarCliente);
			this.panel3.Controls.Add(this.txtsCliente);
			this.panel3.Controls.Add(this.label9);
			this.panel3.Controls.Add(this.cbTipoAtencion);
			this.panel3.Controls.Add(this.cbBolsaViaje);
			this.panel3.Controls.Add(this.dtpFechaCierreIni);
			this.panel3.Controls.Add(this.label3);
			this.panel3.Controls.Add(this.dtpFechaRealIni);
			this.panel3.Controls.Add(this.label2);
			this.panel3.Controls.Add(this.dtpFechaAprob2Ini);
			this.panel3.Controls.Add(this.label1);
			this.panel3.Controls.Add(this.cboEstado);
			this.panel3.Controls.Add(this.lblEstado);
			this.panel3.Controls.Add(this.labelGradient1);
			this.panel3.Controls.Add(this.txtsIdAtencion);
			this.panel3.Controls.Add(this.dtpFechaPrevIni);
			this.panel3.Controls.Add(this.lblFechaSolicitud);
			this.panel3.Controls.Add(this.dtpFechaLiqIni);
			this.panel3.Controls.Add(this.dtpFechaAprob1Ini);
			this.panel3.Controls.Add(this.lblFechaLiq);
			this.panel3.Controls.Add(this.lblFechaAprob);
			this.panel3.Controls.Add(this.cboDelegado);
			this.panel3.Controls.Add(this.btnBuscar);
			this.panel3.Controls.Add(this.lblComida);
			this.panel3.Controls.Add(this.label5);
			this.panel3.Controls.Add(this.lblCodigo);
			this.panel3.Controls.Add(this.lblDelegado);
			this.panel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.panel3.Location = new System.Drawing.Point(1, 40);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(934, 216);
			this.panel3.TabIndex = 0;
			// 
			// label34
			// 
			this.label34.Location = new System.Drawing.Point(720, 145);
			this.label34.Name = "label34";
			this.label34.Size = new System.Drawing.Size(30, 18);
			this.label34.TabIndex = 138;
			this.label34.Text = "entre";
			this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label35
			// 
			this.label35.Location = new System.Drawing.Point(720, 125);
			this.label35.Name = "label35";
			this.label35.Size = new System.Drawing.Size(30, 18);
			this.label35.TabIndex = 137;
			this.label35.Text = "entre";
			this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// dtpFechaAprob4Fin
			// 
			this.dtpFechaAprob4Fin.Checked = false;
			this.dtpFechaAprob4Fin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.dtpFechaAprob4Fin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpFechaAprob4Fin.Location = new System.Drawing.Point(752, 144);
			this.dtpFechaAprob4Fin.Name = "dtpFechaAprob4Fin";
			this.dtpFechaAprob4Fin.Size = new System.Drawing.Size(90, 20);
			this.dtpFechaAprob4Fin.TabIndex = 134;
			// 
			// dtpFechaAprob3Fin
			// 
			this.dtpFechaAprob3Fin.Checked = false;
			this.dtpFechaAprob3Fin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.dtpFechaAprob3Fin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpFechaAprob3Fin.Location = new System.Drawing.Point(752, 124);
			this.dtpFechaAprob3Fin.Name = "dtpFechaAprob3Fin";
			this.dtpFechaAprob3Fin.Size = new System.Drawing.Size(90, 20);
			this.dtpFechaAprob3Fin.TabIndex = 132;
			// 
			// dtpFechaAprob4Ini
			// 
			this.dtpFechaAprob4Ini.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.dtpFechaAprob4Ini.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpFechaAprob4Ini.Location = new System.Drawing.Point(632, 144);
			this.dtpFechaAprob4Ini.Name = "dtpFechaAprob4Ini";
			this.dtpFechaAprob4Ini.Size = new System.Drawing.Size(90, 20);
			this.dtpFechaAprob4Ini.TabIndex = 133;
			this.dtpFechaAprob4Ini.Value = new System.DateTime(2003, 8, 22, 0, 0, 0, 0);
			// 
			// label36
			// 
			this.label36.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.label36.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.label36.ForeColor = System.Drawing.Color.Black;
			this.label36.Location = new System.Drawing.Point(576, 148);
			this.label36.Name = "label36";
			this.label36.Size = new System.Drawing.Size(84, 16);
			this.label36.TabIndex = 136;
			this.label36.Text = "F. Aprob4:";
			// 
			// dtpFechaAprob3Ini
			// 
			this.dtpFechaAprob3Ini.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.dtpFechaAprob3Ini.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpFechaAprob3Ini.Location = new System.Drawing.Point(632, 124);
			this.dtpFechaAprob3Ini.Name = "dtpFechaAprob3Ini";
			this.dtpFechaAprob3Ini.Size = new System.Drawing.Size(90, 20);
			this.dtpFechaAprob3Ini.TabIndex = 131;
			this.dtpFechaAprob3Ini.Value = new System.DateTime(2003, 8, 22, 0, 0, 0, 0);
			// 
			// label37
			// 
			this.label37.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.label37.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.label37.ForeColor = System.Drawing.Color.Black;
			this.label37.Location = new System.Drawing.Point(576, 128);
			this.label37.Name = "label37";
			this.label37.Size = new System.Drawing.Size(88, 16);
			this.label37.TabIndex = 135;
			this.label37.Text = "F. Aprob3:";
			// 
			// label32
			// 
			this.label32.Location = new System.Drawing.Point(720, 24);
			this.label32.Name = "label32";
			this.label32.Size = new System.Drawing.Size(30, 18);
			this.label32.TabIndex = 130;
			this.label32.Text = "entre";
			this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// dtpFechaCreacionFin
			// 
			this.dtpFechaCreacionFin.Checked = false;
			this.dtpFechaCreacionFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.dtpFechaCreacionFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpFechaCreacionFin.Location = new System.Drawing.Point(752, 24);
			this.dtpFechaCreacionFin.Name = "dtpFechaCreacionFin";
			this.dtpFechaCreacionFin.Size = new System.Drawing.Size(90, 20);
			this.dtpFechaCreacionFin.TabIndex = 7;
			// 
			// dtpFechaCreacionIni
			// 
			this.dtpFechaCreacionIni.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.dtpFechaCreacionIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpFechaCreacionIni.Location = new System.Drawing.Point(632, 24);
			this.dtpFechaCreacionIni.Name = "dtpFechaCreacionIni";
			this.dtpFechaCreacionIni.Size = new System.Drawing.Size(90, 20);
			this.dtpFechaCreacionIni.TabIndex = 6;
			// 
			// label33
			// 
			this.label33.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.label33.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.label33.ForeColor = System.Drawing.Color.Black;
			this.label33.Location = new System.Drawing.Point(576, 28);
			this.label33.Name = "label33";
			this.label33.Size = new System.Drawing.Size(63, 16);
			this.label33.TabIndex = 128;
			this.label33.Text = "F. Cre.:";
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(720, 185);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(30, 18);
			this.label10.TabIndex = 126;
			this.label10.Text = "entre";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(720, 165);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(30, 18);
			this.label11.TabIndex = 125;
			this.label11.Text = "entre";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(720, 105);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(30, 18);
			this.label12.TabIndex = 124;
			this.label12.Text = "entre";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// dtpFechaCierreFin
			// 
			this.dtpFechaCierreFin.Checked = false;
			this.dtpFechaCierreFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.dtpFechaCierreFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpFechaCierreFin.Location = new System.Drawing.Point(752, 184);
			this.dtpFechaCierreFin.Name = "dtpFechaCierreFin";
			this.dtpFechaCierreFin.Size = new System.Drawing.Size(90, 20);
			this.dtpFechaCierreFin.TabIndex = 19;
			this.dtpFechaCierreFin.ValueChanged += new System.EventHandler(this.dtpFechaBuscar_ValueChanged);
			// 
			// dtpFechaLiqFin
			// 
			this.dtpFechaLiqFin.Checked = false;
			this.dtpFechaLiqFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.dtpFechaLiqFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpFechaLiqFin.Location = new System.Drawing.Point(752, 164);
			this.dtpFechaLiqFin.Name = "dtpFechaLiqFin";
			this.dtpFechaLiqFin.Size = new System.Drawing.Size(90, 20);
			this.dtpFechaLiqFin.TabIndex = 17;
			this.dtpFechaLiqFin.ValueChanged += new System.EventHandler(this.dtpFechaBuscar_ValueChanged);
			// 
			// dtpFechaRealFin
			// 
			this.dtpFechaRealFin.Checked = false;
			this.dtpFechaRealFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.dtpFechaRealFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpFechaRealFin.Location = new System.Drawing.Point(752, 104);
			this.dtpFechaRealFin.Name = "dtpFechaRealFin";
			this.dtpFechaRealFin.Size = new System.Drawing.Size(90, 20);
			this.dtpFechaRealFin.TabIndex = 15;
			this.dtpFechaRealFin.ValueChanged += new System.EventHandler(this.dtpFechaBuscar_ValueChanged);
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(720, 85);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(30, 18);
			this.label8.TabIndex = 120;
			this.label8.Text = "entre";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(720, 65);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(30, 18);
			this.label7.TabIndex = 119;
			this.label7.Text = "entre";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(720, 45);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(30, 18);
			this.label6.TabIndex = 118;
			this.label6.Text = "entre";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// dtpFechaAprob2Fin
			// 
			this.dtpFechaAprob2Fin.Checked = false;
			this.dtpFechaAprob2Fin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.dtpFechaAprob2Fin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpFechaAprob2Fin.Location = new System.Drawing.Point(752, 84);
			this.dtpFechaAprob2Fin.Name = "dtpFechaAprob2Fin";
			this.dtpFechaAprob2Fin.Size = new System.Drawing.Size(90, 20);
			this.dtpFechaAprob2Fin.TabIndex = 13;
			this.dtpFechaAprob2Fin.ValueChanged += new System.EventHandler(this.dtpFechaBuscar_ValueChanged);
			// 
			// dtpFechaAprob1Fin
			// 
			this.dtpFechaAprob1Fin.Checked = false;
			this.dtpFechaAprob1Fin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.dtpFechaAprob1Fin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpFechaAprob1Fin.Location = new System.Drawing.Point(752, 64);
			this.dtpFechaAprob1Fin.Name = "dtpFechaAprob1Fin";
			this.dtpFechaAprob1Fin.Size = new System.Drawing.Size(90, 20);
			this.dtpFechaAprob1Fin.TabIndex = 11;
			this.dtpFechaAprob1Fin.ValueChanged += new System.EventHandler(this.dtpFechaBuscar_ValueChanged);
			// 
			// dtpFechaPrevFin
			// 
			this.dtpFechaPrevFin.Checked = false;
			this.dtpFechaPrevFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.dtpFechaPrevFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpFechaPrevFin.Location = new System.Drawing.Point(752, 44);
			this.dtpFechaPrevFin.Name = "dtpFechaPrevFin";
			this.dtpFechaPrevFin.Size = new System.Drawing.Size(90, 20);
			this.dtpFechaPrevFin.TabIndex = 9;
			this.dtpFechaPrevFin.ValueChanged += new System.EventHandler(this.dtpFechaBuscar_ValueChanged);
			// 
			// txtsIdCliente
			// 
			this.txtsIdCliente.BackColor = System.Drawing.Color.White;
			this.txtsIdCliente.ForeColor = System.Drawing.Color.Black;
			this.txtsIdCliente.Location = new System.Drawing.Point(64, 126);
			this.txtsIdCliente.MaxLength = 20;
			this.txtsIdCliente.Name = "txtsIdCliente";
			this.txtsIdCliente.Size = new System.Drawing.Size(128, 20);
			this.txtsIdCliente.TabIndex = 5;
			this.txtsIdCliente.Text = "";
			this.txtsIdCliente.TextChanged += new System.EventHandler(this.Texto_TextChanged);
			this.txtsIdCliente.Leave += new System.EventHandler(this.txtsIdCliente_Leave);
			// 
			// btBuscarCliente
			// 
			this.btBuscarCliente.Image = ((System.Drawing.Image)(resources.GetObject("btBuscarCliente.Image")));
			this.btBuscarCliente.Location = new System.Drawing.Point(528, 125);
			this.btBuscarCliente.Name = "btBuscarCliente";
			this.btBuscarCliente.Size = new System.Drawing.Size(22, 22);
			this.btBuscarCliente.TabIndex = 113;
			this.btBuscarCliente.TabStop = false;
			this.toolTipAtenciones.SetToolTip(this.btBuscarCliente, "Buscar Cliente");
			this.btBuscarCliente.Click += new System.EventHandler(this.btBuscarCliente_Click);
			// 
			// txtsCliente
			// 
			this.txtsCliente.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(238)), ((System.Byte)(243)), ((System.Byte)(246)));
			this.txtsCliente.ForeColor = System.Drawing.Color.Black;
			this.txtsCliente.Location = new System.Drawing.Point(192, 126);
			this.txtsCliente.Name = "txtsCliente";
			this.txtsCliente.ReadOnly = true;
			this.txtsCliente.Size = new System.Drawing.Size(336, 20);
			this.txtsCliente.TabIndex = 112;
			this.txtsCliente.TabStop = false;
			this.txtsCliente.Text = "";
			// 
			// label9
			// 
			this.label9.ForeColor = System.Drawing.Color.Black;
			this.label9.Location = new System.Drawing.Point(8, 131);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(56, 16);
			this.label9.TabIndex = 114;
			this.label9.Text = "Cliente:";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cbTipoAtencion
			// 
			this.cbTipoAtencion.DataSource = this.dsAtenciones1.ListaTipoAtencionComercial;
			this.cbTipoAtencion.DisplayMember = "sLiteral";
			this.cbTipoAtencion.Location = new System.Drawing.Point(64, 60);
			this.cbTipoAtencion.Name = "cbTipoAtencion";
			this.cbTipoAtencion.Size = new System.Drawing.Size(184, 21);
			this.cbTipoAtencion.TabIndex = 2;
			this.cbTipoAtencion.ValueMember = "sValor";
			this.cbTipoAtencion.SelectedIndexChanged += new System.EventHandler(this.ComboBox_SetectedIndexChanged);
			this.cbTipoAtencion.Leave += new System.EventHandler(this.cbTipoAtencion_Leave);
			// 
			// dsAtenciones1
			// 
			this.dsAtenciones1.DataSetName = "dsAtenciones";
			this.dsAtenciones1.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// cbBolsaViaje
			// 
			this.cbBolsaViaje.Location = new System.Drawing.Point(366, 93);
			this.cbBolsaViaje.Name = "cbBolsaViaje";
			this.cbBolsaViaje.Size = new System.Drawing.Size(88, 21);
			this.cbBolsaViaje.TabIndex = 4;
			this.cbBolsaViaje.SelectedIndexChanged += new System.EventHandler(this.ComboBox_SetectedIndexChanged);
			this.cbBolsaViaje.Leave += new System.EventHandler(this.cbBolsaViaje_Leave);
			// 
			// dtpFechaCierreIni
			// 
			this.dtpFechaCierreIni.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.dtpFechaCierreIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpFechaCierreIni.Location = new System.Drawing.Point(632, 184);
			this.dtpFechaCierreIni.Name = "dtpFechaCierreIni";
			this.dtpFechaCierreIni.Size = new System.Drawing.Size(90, 20);
			this.dtpFechaCierreIni.TabIndex = 18;
			this.dtpFechaCierreIni.ValueChanged += new System.EventHandler(this.dtpFechaBuscar_ValueChanged);
			// 
			// label3
			// 
			this.label3.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.label3.ForeColor = System.Drawing.Color.Black;
			this.label3.Location = new System.Drawing.Point(576, 188);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(78, 16);
			this.label3.TabIndex = 103;
			this.label3.Text = "F. Cierre:";
			// 
			// dtpFechaRealIni
			// 
			this.dtpFechaRealIni.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.dtpFechaRealIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpFechaRealIni.Location = new System.Drawing.Point(632, 104);
			this.dtpFechaRealIni.Name = "dtpFechaRealIni";
			this.dtpFechaRealIni.Size = new System.Drawing.Size(90, 20);
			this.dtpFechaRealIni.TabIndex = 14;
			this.dtpFechaRealIni.Value = new System.DateTime(2003, 8, 22, 0, 0, 0, 0);
			this.dtpFechaRealIni.ValueChanged += new System.EventHandler(this.dtpFechaBuscar_ValueChanged);
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.label2.ForeColor = System.Drawing.Color.Black;
			this.label2.Location = new System.Drawing.Point(576, 108);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(84, 16);
			this.label2.TabIndex = 100;
			this.label2.Text = "F. Real:";
			// 
			// dtpFechaAprob2Ini
			// 
			this.dtpFechaAprob2Ini.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.dtpFechaAprob2Ini.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpFechaAprob2Ini.Location = new System.Drawing.Point(632, 84);
			this.dtpFechaAprob2Ini.Name = "dtpFechaAprob2Ini";
			this.dtpFechaAprob2Ini.Size = new System.Drawing.Size(90, 20);
			this.dtpFechaAprob2Ini.TabIndex = 12;
			this.dtpFechaAprob2Ini.Value = new System.DateTime(2003, 8, 22, 0, 0, 0, 0);
			this.dtpFechaAprob2Ini.ValueChanged += new System.EventHandler(this.dtpFechaBuscar_ValueChanged);
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.label1.ForeColor = System.Drawing.Color.Black;
			this.label1.Location = new System.Drawing.Point(576, 88);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(84, 16);
			this.label1.TabIndex = 97;
			this.label1.Text = "F. Aprob2:";
			// 
			// cboEstado
			// 
			this.cboEstado.DataSource = this.dsAtenciones1.ListaTipoEstadoAtencion;
			this.cboEstado.DisplayMember = "sLiteral";
			this.cboEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.cboEstado.ForeColor = System.Drawing.Color.Black;
			this.cboEstado.ItemHeight = 13;
			this.cboEstado.Location = new System.Drawing.Point(64, 93);
			this.cboEstado.Name = "cboEstado";
			this.cboEstado.Size = new System.Drawing.Size(184, 21);
			this.cboEstado.TabIndex = 3;
			this.toolTipAtenciones.SetToolTip(this.cboEstado, "Delegado");
			this.cboEstado.ValueMember = "sValor";
			this.cboEstado.SelectedIndexChanged += new System.EventHandler(this.ComboBox_SetectedIndexChanged);
			this.cboEstado.Leave += new System.EventHandler(this.cboEstado_Leave);
			// 
			// lblEstado
			// 
			this.lblEstado.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.lblEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.lblEstado.ForeColor = System.Drawing.Color.Black;
			this.lblEstado.Location = new System.Drawing.Point(8, 98);
			this.lblEstado.Name = "lblEstado";
			this.lblEstado.Size = new System.Drawing.Size(48, 16);
			this.lblEstado.TabIndex = 95;
			this.lblEstado.Text = "Estado:";
			// 
			// labelGradient1
			// 
			this.labelGradient1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.labelGradient1.ForeColor = System.Drawing.Color.White;
			this.labelGradient1.GradientColorOne = System.Drawing.Color.FromArgb(((System.Byte)(18)), ((System.Byte)(84)), ((System.Byte)(132)));
			this.labelGradient1.GradientColorTwo = System.Drawing.Color.White;
			this.labelGradient1.Location = new System.Drawing.Point(0, 0);
			this.labelGradient1.Name = "labelGradient1";
			this.labelGradient1.Size = new System.Drawing.Size(934, 22);
			this.labelGradient1.TabIndex = 91;
			this.labelGradient1.Text = "Consulta de Atenciones Comerciales";
			// 
			// txtsIdAtencion
			// 
			this.txtsIdAtencion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.txtsIdAtencion.ForeColor = System.Drawing.Color.Black;
			this.txtsIdAtencion.Location = new System.Drawing.Point(366, 27);
			this.txtsIdAtencion.MaxLength = 20;
			this.txtsIdAtencion.Name = "txtsIdAtencion";
			this.txtsIdAtencion.Size = new System.Drawing.Size(184, 20);
			this.txtsIdAtencion.TabIndex = 1;
			this.txtsIdAtencion.Text = "";
			this.toolTipAtenciones.SetToolTip(this.txtsIdAtencion, "Descripción");
			this.txtsIdAtencion.TextChanged += new System.EventHandler(this.Texto_TextChanged);
			// 
			// dtpFechaPrevIni
			// 
			this.dtpFechaPrevIni.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.dtpFechaPrevIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpFechaPrevIni.Location = new System.Drawing.Point(632, 44);
			this.dtpFechaPrevIni.Name = "dtpFechaPrevIni";
			this.dtpFechaPrevIni.Size = new System.Drawing.Size(90, 20);
			this.dtpFechaPrevIni.TabIndex = 8;
			this.dtpFechaPrevIni.ValueChanged += new System.EventHandler(this.dtpFechaBuscar_ValueChanged);
			// 
			// lblFechaSolicitud
			// 
			this.lblFechaSolicitud.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.lblFechaSolicitud.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.lblFechaSolicitud.ForeColor = System.Drawing.Color.Black;
			this.lblFechaSolicitud.Location = new System.Drawing.Point(576, 48);
			this.lblFechaSolicitud.Name = "lblFechaSolicitud";
			this.lblFechaSolicitud.Size = new System.Drawing.Size(63, 16);
			this.lblFechaSolicitud.TabIndex = 71;
			this.lblFechaSolicitud.Text = "F. Prev.:";
			// 
			// dtpFechaLiqIni
			// 
			this.dtpFechaLiqIni.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.dtpFechaLiqIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpFechaLiqIni.Location = new System.Drawing.Point(632, 164);
			this.dtpFechaLiqIni.Name = "dtpFechaLiqIni";
			this.dtpFechaLiqIni.Size = new System.Drawing.Size(90, 20);
			this.dtpFechaLiqIni.TabIndex = 16;
			this.dtpFechaLiqIni.ValueChanged += new System.EventHandler(this.dtpFechaBuscar_ValueChanged);
			// 
			// dtpFechaAprob1Ini
			// 
			this.dtpFechaAprob1Ini.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.dtpFechaAprob1Ini.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpFechaAprob1Ini.Location = new System.Drawing.Point(632, 64);
			this.dtpFechaAprob1Ini.Name = "dtpFechaAprob1Ini";
			this.dtpFechaAprob1Ini.Size = new System.Drawing.Size(90, 20);
			this.dtpFechaAprob1Ini.TabIndex = 10;
			this.dtpFechaAprob1Ini.Value = new System.DateTime(2003, 8, 22, 0, 0, 0, 0);
			this.dtpFechaAprob1Ini.ValueChanged += new System.EventHandler(this.dtpFechaBuscar_ValueChanged);
			// 
			// lblFechaLiq
			// 
			this.lblFechaLiq.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.lblFechaLiq.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.lblFechaLiq.ForeColor = System.Drawing.Color.Black;
			this.lblFechaLiq.Location = new System.Drawing.Point(576, 168);
			this.lblFechaLiq.Name = "lblFechaLiq";
			this.lblFechaLiq.Size = new System.Drawing.Size(78, 16);
			this.lblFechaLiq.TabIndex = 70;
			this.lblFechaLiq.Text = "F. Liq.:";
			// 
			// lblFechaAprob
			// 
			this.lblFechaAprob.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.lblFechaAprob.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.lblFechaAprob.ForeColor = System.Drawing.Color.Black;
			this.lblFechaAprob.Location = new System.Drawing.Point(576, 68);
			this.lblFechaAprob.Name = "lblFechaAprob";
			this.lblFechaAprob.Size = new System.Drawing.Size(88, 16);
			this.lblFechaAprob.TabIndex = 69;
			this.lblFechaAprob.Text = "F. Aprob1:";
			// 
			// cboDelegado
			// 
			this.cboDelegado.DataSource = this.dsAtenciones1.ListaDelegados;
			this.cboDelegado.DisplayMember = "sNombre";
			this.cboDelegado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.cboDelegado.ForeColor = System.Drawing.Color.Black;
			this.cboDelegado.ItemHeight = 13;
			this.cboDelegado.Location = new System.Drawing.Point(64, 27);
			this.cboDelegado.Name = "cboDelegado";
			this.cboDelegado.Size = new System.Drawing.Size(248, 21);
			this.cboDelegado.TabIndex = 0;
			this.toolTipAtenciones.SetToolTip(this.cboDelegado, "Delegado");
			this.cboDelegado.ValueMember = "iIdDelegado";
			this.cboDelegado.SelectedIndexChanged += new System.EventHandler(this.ComboBox_SetectedIndexChanged);
			this.cboDelegado.Leave += new System.EventHandler(this.cboDelegado_Leave);
			// 
			// btnBuscar
			// 
			this.btnBuscar.ForeColor = System.Drawing.Color.Black;
			this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.btnBuscar.Location = new System.Drawing.Point(848, 80);
			this.btnBuscar.Name = "btnBuscar";
			this.btnBuscar.Size = new System.Drawing.Size(75, 24);
			this.btnBuscar.TabIndex = 20;
			this.btnBuscar.Text = "Buscar";
			this.toolTipAtenciones.SetToolTip(this.btnBuscar, "Buscar Atenciones");
			this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
			// 
			// lblComida
			// 
			this.lblComida.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.lblComida.ForeColor = System.Drawing.Color.Black;
			this.lblComida.Location = new System.Drawing.Point(328, 96);
			this.lblComida.Name = "lblComida";
			this.lblComida.Size = new System.Drawing.Size(32, 16);
			this.lblComida.TabIndex = 89;
			this.lblComida.Text = "AP :";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(8, 63);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(100, 18);
			this.label5.TabIndex = 109;
			this.label5.Text = "Tipo:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblCodigo
			// 
			this.lblCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.lblCodigo.ForeColor = System.Drawing.Color.Black;
			this.lblCodigo.Location = new System.Drawing.Point(320, 32);
			this.lblCodigo.Name = "lblCodigo";
			this.lblCodigo.Size = new System.Drawing.Size(43, 16);
			this.lblCodigo.TabIndex = 90;
			this.lblCodigo.Text = "Código:";
			// 
			// lblDelegado
			// 
			this.lblDelegado.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.lblDelegado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.lblDelegado.ForeColor = System.Drawing.Color.Black;
			this.lblDelegado.Location = new System.Drawing.Point(8, 32);
			this.lblDelegado.Name = "lblDelegado";
			this.lblDelegado.Size = new System.Drawing.Size(56, 16);
			this.lblDelegado.TabIndex = 12;
			this.lblDelegado.Text = "Delegado:";
			// 
			// btBuscarAtenCli
			// 
			this.btBuscarAtenCli.Location = new System.Drawing.Point(456, 21);
			this.btBuscarAtenCli.Name = "btBuscarAtenCli";
			this.btBuscarAtenCli.TabIndex = 2;
			this.btBuscarAtenCli.Text = "Buscar";
			this.toolTipAtenciones.SetToolTip(this.btBuscarAtenCli, "Buscar Clientes Asignados");
			this.btBuscarAtenCli.Click += new System.EventHandler(this.btBuscarAtenCli_Click);
			// 
			// dgAtenciones
			// 
			this.dgAtenciones.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.dgAtenciones.BackgroundColor = System.Drawing.Color.White;
			this.dgAtenciones.CaptionBackColor = System.Drawing.Color.FromArgb(((System.Byte)(18)), ((System.Byte)(84)), ((System.Byte)(132)));
			this.dgAtenciones.CaptionVisible = false;
			this.dgAtenciones.ContextMenu = this.cntxMnuAtenciones;
			this.dgAtenciones.DataMember = "ListaAtencionesComerciales";
			this.dgAtenciones.DataSource = this.dsAtenciones1;
			this.dgAtenciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.dgAtenciones.HeaderBackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.dgAtenciones.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgAtenciones.Location = new System.Drawing.Point(0, 16);
			this.dgAtenciones.Name = "dgAtenciones";
			this.dgAtenciones.ReadOnly = true;
			this.dgAtenciones.RowHeaderWidth = 30;
			this.dgAtenciones.Size = new System.Drawing.Size(928, 160);
			this.dgAtenciones.TabIndex = 0;
			this.dgAtenciones.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																									 this.dataGridTableStyle1});
			this.dgAtenciones.DoubleClick += new System.EventHandler(this.dgAtenciones_DoubleClick);
			this.dgAtenciones.CurrentCellChanged += new System.EventHandler(this.dgAtenciones_CurrentCellChanged);
			// 
			// cntxMnuAtenciones
			// 
			this.cntxMnuAtenciones.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
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
			this.menuEditar.Click += new System.EventHandler(this.btEditar_Click);
			// 
			// menuEliminar
			// 
			this.menuEliminar.Index = 2;
			this.menuEliminar.Shortcut = System.Windows.Forms.Shortcut.CtrlX;
			this.menuEliminar.Text = "Eliminar";
			this.menuEliminar.Click += new System.EventHandler(this.btEliminar_Click);
			// 
			// dataGridTableStyle1
			// 
			this.dataGridTableStyle1.DataGrid = this.dgAtenciones;
			this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.dataGridTextBoxColumn10,
																												  this.dataGridTextBoxColumn28,
																												  this.dataGridTextBoxColumn30,
																												  this.dataGridTextBoxColumn9,
																												  this.dataGridTextBoxColumn11,
																												  this.dataGridTextBoxColumn12,
																												  this.dataGridTextBoxColumn13,
																												  this.dataGridTextBoxColumn14,
																												  this.dataGridTextBoxColumn15,
																												  this.dataGridTextBoxColumn16,
																												  this.dataGridTextBoxColumn17,
																												  this.dataGridTextBoxColumn18,
																												  this.dataGridTextBoxColumn19,
																												  this.dataGridTextBoxColumn1,
																												  this.dataGridTextBoxColumn2,
																												  this.dataGridTextBoxColumn3,
																												  this.dataGridTextBoxColumn22,
																												  this.dataGridTextBoxColumn23,
																												  this.dataGridTextBoxColumn25,
																												  this.dataGridTextBoxColumn24,
																												  this.dataGridTextBoxColumn4,
																												  this.dataGridTextBoxColumn5,
																												  this.dataGridTextBoxColumn26,
																												  this.dataGridTextBoxColumn27,
																												  this.dataGridTextBoxColumn29});
			this.dataGridTableStyle1.HeaderBackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle1.MappingName = "ListaAtencionesComerciales";
			this.dataGridTableStyle1.RowHeaderWidth = 30;
			// 
			// dataGridTextBoxColumn10
			// 
			this.dataGridTextBoxColumn10.Format = "";
			this.dataGridTextBoxColumn10.FormatInfo = null;
			this.dataGridTextBoxColumn10.MappingName = "iIdAtencion";
			this.dataGridTextBoxColumn10.NullText = "";
			this.dataGridTextBoxColumn10.Width = 0;
			// 
			// dataGridTextBoxColumn28
			// 
			this.dataGridTextBoxColumn28.Format = "";
			this.dataGridTextBoxColumn28.FormatInfo = null;
			this.dataGridTextBoxColumn28.MappingName = "iIdDelegado";
			this.dataGridTextBoxColumn28.NullText = "";
			this.dataGridTextBoxColumn28.Width = 0;
			// 
			// dataGridTextBoxColumn30
			// 
			this.dataGridTextBoxColumn30.Format = "";
			this.dataGridTextBoxColumn30.FormatInfo = null;
			this.dataGridTextBoxColumn30.MappingName = "bEnviadoCEN";
			this.dataGridTextBoxColumn30.NullText = "";
			this.dataGridTextBoxColumn30.Width = 0;
			// 
			// dataGridTextBoxColumn9
			// 
			this.dataGridTextBoxColumn9.Format = "";
			this.dataGridTextBoxColumn9.FormatInfo = null;
			this.dataGridTextBoxColumn9.HeaderText = "Código";
			this.dataGridTextBoxColumn9.MappingName = "sIdAtencion";
			this.dataGridTextBoxColumn9.NullText = "";
			this.dataGridTextBoxColumn9.Width = 85;
			// 
			// dataGridTextBoxColumn11
			// 
			this.dataGridTextBoxColumn11.Format = "";
			this.dataGridTextBoxColumn11.FormatInfo = null;
			this.dataGridTextBoxColumn11.HeaderText = "Descripción";
			this.dataGridTextBoxColumn11.MappingName = "sDescripcion";
			this.dataGridTextBoxColumn11.NullText = "";
			this.dataGridTextBoxColumn11.Width = 0;
			// 
			// dataGridTextBoxColumn12
			// 
			this.dataGridTextBoxColumn12.Format = "";
			this.dataGridTextBoxColumn12.FormatInfo = null;
			this.dataGridTextBoxColumn12.MappingName = "sIdTipoAtencion";
			this.dataGridTextBoxColumn12.NullText = "";
			this.dataGridTextBoxColumn12.Width = 0;
			// 
			// dataGridTextBoxColumn13
			// 
			this.dataGridTextBoxColumn13.Format = "";
			this.dataGridTextBoxColumn13.FormatInfo = null;
			this.dataGridTextBoxColumn13.HeaderText = "Tipo";
			this.dataGridTextBoxColumn13.MappingName = "sTipoAtencion";
			this.dataGridTextBoxColumn13.NullText = "";
			this.dataGridTextBoxColumn13.Width = 70;
			// 
			// dataGridTextBoxColumn14
			// 
			this.dataGridTextBoxColumn14.Format = "";
			this.dataGridTextBoxColumn14.FormatInfo = null;
			this.dataGridTextBoxColumn14.MappingName = "sIdEstAtencion";
			this.dataGridTextBoxColumn14.NullText = "";
			this.dataGridTextBoxColumn14.Width = 0;
			// 
			// dataGridTextBoxColumn15
			// 
			this.dataGridTextBoxColumn15.Format = "";
			this.dataGridTextBoxColumn15.FormatInfo = null;
			this.dataGridTextBoxColumn15.HeaderText = "Estado";
			this.dataGridTextBoxColumn15.MappingName = "sEstAtencion";
			this.dataGridTextBoxColumn15.NullText = "";
			this.dataGridTextBoxColumn15.Width = 65;
			// 
			// dataGridTextBoxColumn16
			// 
			this.dataGridTextBoxColumn16.Format = "";
			this.dataGridTextBoxColumn16.FormatInfo = null;
			this.dataGridTextBoxColumn16.MappingName = "bLiqNotaGastos";
			this.dataGridTextBoxColumn16.NullText = "";
			this.dataGridTextBoxColumn16.Width = 0;
			// 
			// dataGridTextBoxColumn17
			// 
			this.dataGridTextBoxColumn17.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
			this.dataGridTextBoxColumn17.Format = "";
			this.dataGridTextBoxColumn17.FormatInfo = null;
			this.dataGridTextBoxColumn17.MappingName = "tLiqNotaGastos";
			this.dataGridTextBoxColumn17.NullText = "";
			this.dataGridTextBoxColumn17.Width = 0;
			// 
			// dataGridTextBoxColumn18
			// 
			this.dataGridTextBoxColumn18.Format = "";
			this.dataGridTextBoxColumn18.FormatInfo = null;
			this.dataGridTextBoxColumn18.MappingName = "bBolsaViaje";
			this.dataGridTextBoxColumn18.NullText = "";
			this.dataGridTextBoxColumn18.Width = 0;
			// 
			// dataGridTextBoxColumn19
			// 
			this.dataGridTextBoxColumn19.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
			this.dataGridTextBoxColumn19.Format = "";
			this.dataGridTextBoxColumn19.FormatInfo = null;
			this.dataGridTextBoxColumn19.HeaderText = "¿AP?";
			this.dataGridTextBoxColumn19.MappingName = "tBolsaViaje";
			this.dataGridTextBoxColumn19.NullText = "";
			this.dataGridTextBoxColumn19.Width = 40;
			// 
			// dataGridTextBoxColumn1
			// 
			this.dataGridTextBoxColumn1.Format = "";
			this.dataGridTextBoxColumn1.FormatInfo = null;
			this.dataGridTextBoxColumn1.HeaderText = "Cód.Cliente";
			this.dataGridTextBoxColumn1.MappingName = "sIdCliente";
			this.dataGridTextBoxColumn1.NullText = "";
			this.dataGridTextBoxColumn1.Width = 0;
			// 
			// dataGridTextBoxColumn2
			// 
			this.dataGridTextBoxColumn2.Format = "";
			this.dataGridTextBoxColumn2.FormatInfo = null;
			this.dataGridTextBoxColumn2.HeaderText = "Nombre Cli.";
			this.dataGridTextBoxColumn2.MappingName = "sNombreCli";
			this.dataGridTextBoxColumn2.NullText = "";
			this.dataGridTextBoxColumn2.Width = 140;
			// 
			// dataGridTextBoxColumn3
			// 
			this.dataGridTextBoxColumn3.Format = "dd/MM/yyyy";
			this.dataGridTextBoxColumn3.FormatInfo = null;
			this.dataGridTextBoxColumn3.HeaderText = "F.Cre.";
			this.dataGridTextBoxColumn3.MappingName = "dFechaCreacion";
			this.dataGridTextBoxColumn3.NullText = "";
			this.dataGridTextBoxColumn3.Width = 65;
			// 
			// dataGridTextBoxColumn22
			// 
			this.dataGridTextBoxColumn22.Format = "dd/MM/yyyy";
			this.dataGridTextBoxColumn22.FormatInfo = null;
			this.dataGridTextBoxColumn22.HeaderText = "F.Prev.";
			this.dataGridTextBoxColumn22.MappingName = "dFechaPrev";
			this.dataGridTextBoxColumn22.NullText = "";
			this.dataGridTextBoxColumn22.Width = 65;
			// 
			// dataGridTextBoxColumn23
			// 
			this.dataGridTextBoxColumn23.Format = "dd/MM/yyyy";
			this.dataGridTextBoxColumn23.FormatInfo = null;
			this.dataGridTextBoxColumn23.HeaderText = "F.Aprob1";
			this.dataGridTextBoxColumn23.MappingName = "dFechaAprob1";
			this.dataGridTextBoxColumn23.NullText = "";
			this.dataGridTextBoxColumn23.Width = 65;
			// 
			// dataGridTextBoxColumn25
			// 
			this.dataGridTextBoxColumn25.Format = "dd/MM/yyyy";
			this.dataGridTextBoxColumn25.FormatInfo = null;
			this.dataGridTextBoxColumn25.HeaderText = "F.Aprob2";
			this.dataGridTextBoxColumn25.MappingName = "dFechaAprob2";
			this.dataGridTextBoxColumn25.NullText = "";
			this.dataGridTextBoxColumn25.Width = 65;
			// 
			// dataGridTextBoxColumn24
			// 
			this.dataGridTextBoxColumn24.Format = "dd/MM/yyyy";
			this.dataGridTextBoxColumn24.FormatInfo = null;
			this.dataGridTextBoxColumn24.HeaderText = "F.Real";
			this.dataGridTextBoxColumn24.MappingName = "dFechaReal";
			this.dataGridTextBoxColumn24.NullText = "";
			this.dataGridTextBoxColumn24.Width = 65;
			// 
			// dataGridTextBoxColumn4
			// 
			this.dataGridTextBoxColumn4.Format = "dd/MM/yyyy";
			this.dataGridTextBoxColumn4.FormatInfo = null;
			this.dataGridTextBoxColumn4.HeaderText = "F.Aprob3";
			this.dataGridTextBoxColumn4.MappingName = "dFechaAprob3";
			this.dataGridTextBoxColumn4.NullText = "";
			this.dataGridTextBoxColumn4.Width = 65;
			// 
			// dataGridTextBoxColumn5
			// 
			this.dataGridTextBoxColumn5.Format = "dd/MM/yyyy";
			this.dataGridTextBoxColumn5.FormatInfo = null;
			this.dataGridTextBoxColumn5.HeaderText = "F.Aprob4";
			this.dataGridTextBoxColumn5.MappingName = "dFechaAprob4";
			this.dataGridTextBoxColumn5.NullText = "";
			this.dataGridTextBoxColumn5.Width = 65;
			// 
			// dataGridTextBoxColumn26
			// 
			this.dataGridTextBoxColumn26.Format = "dd/MM/yyyy";
			this.dataGridTextBoxColumn26.FormatInfo = null;
			this.dataGridTextBoxColumn26.HeaderText = "F.Liq.";
			this.dataGridTextBoxColumn26.MappingName = "dFechaLiq";
			this.dataGridTextBoxColumn26.NullText = "";
			this.dataGridTextBoxColumn26.Width = 65;
			// 
			// dataGridTextBoxColumn27
			// 
			this.dataGridTextBoxColumn27.Format = "dd/MM/yyyy";
			this.dataGridTextBoxColumn27.FormatInfo = null;
			this.dataGridTextBoxColumn27.HeaderText = "F.Cierre";
			this.dataGridTextBoxColumn27.MappingName = "dFechaCierre";
			this.dataGridTextBoxColumn27.NullText = "";
			this.dataGridTextBoxColumn27.Width = 65;
			// 
			// dataGridTextBoxColumn29
			// 
			this.dataGridTextBoxColumn29.Format = "";
			this.dataGridTextBoxColumn29.FormatInfo = null;
			this.dataGridTextBoxColumn29.HeaderText = "Delegado";
			this.dataGridTextBoxColumn29.MappingName = "sNombre";
			this.dataGridTextBoxColumn29.NullText = "";
			this.dataGridTextBoxColumn29.Width = 40;
			// 
			// sqldaListaAtencionesComerciales
			// 
			this.sqldaListaAtencionesComerciales.SelectCommand = this.sqlSelectCommand1;
			this.sqldaListaAtencionesComerciales.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																													  new System.Data.Common.DataTableMapping("Table", "ListaAtencionesComerciales", new System.Data.Common.DataColumnMapping[] {
																																																													new System.Data.Common.DataColumnMapping("iIdAtencion", "iIdAtencion"),
																																																													new System.Data.Common.DataColumnMapping("sIdAtencionTemp", "sIdAtencionTemp"),
																																																													new System.Data.Common.DataColumnMapping("sIdAtencion", "sIdAtencion"),
																																																													new System.Data.Common.DataColumnMapping("sDescripcion", "sDescripcion"),
																																																													new System.Data.Common.DataColumnMapping("tObservaciones", "tObservaciones"),
																																																													new System.Data.Common.DataColumnMapping("sIdTipoAtencion", "sIdTipoAtencion"),
																																																													new System.Data.Common.DataColumnMapping("sTipoAtencion", "sTipoAtencion"),
																																																													new System.Data.Common.DataColumnMapping("bBolsaViaje", "bBolsaViaje"),
																																																													new System.Data.Common.DataColumnMapping("tBolsaViaje", "tBolsaViaje"),
																																																													new System.Data.Common.DataColumnMapping("bLiqNotaGastos", "bLiqNotaGastos"),
																																																													new System.Data.Common.DataColumnMapping("tLiqNotaGastos", "tLiqNotaGastos"),
																																																													new System.Data.Common.DataColumnMapping("sIdCentroCoste", "sIdCentroCoste"),
																																																													new System.Data.Common.DataColumnMapping("sCentroCoste", "sCentroCoste"),
																																																													new System.Data.Common.DataColumnMapping("iIdDelegado", "iIdDelegado"),
																																																													new System.Data.Common.DataColumnMapping("sNombre", "sNombre"),
																																																													new System.Data.Common.DataColumnMapping("sIdEstAtencion", "sIdEstAtencion"),
																																																													new System.Data.Common.DataColumnMapping("sEstAtencion", "sEstAtencion"),
																																																													new System.Data.Common.DataColumnMapping("iIdCliente", "iIdCliente"),
																																																													new System.Data.Common.DataColumnMapping("fImportePrev", "fImportePrev"),
																																																													new System.Data.Common.DataColumnMapping("fImporteReal", "fImporteReal"),
																																																													new System.Data.Common.DataColumnMapping("dFechaCreacion", "dFechaCreacion"),
																																																													new System.Data.Common.DataColumnMapping("tFechaCreacion", "tFechaCreacion"),
																																																													new System.Data.Common.DataColumnMapping("dFechaPrev", "dFechaPrev"),
																																																													new System.Data.Common.DataColumnMapping("tFechaPrev", "tFechaPrev"),
																																																													new System.Data.Common.DataColumnMapping("dFechaAprob1", "dFechaAprob1"),
																																																													new System.Data.Common.DataColumnMapping("tFechaAprob1", "tFechaAprob1"),
																																																													new System.Data.Common.DataColumnMapping("dFechaAprob2", "dFechaAprob2"),
																																																													new System.Data.Common.DataColumnMapping("tFechaAprob2", "tFechaAprob2"),
																																																													new System.Data.Common.DataColumnMapping("dFechaReal", "dFechaReal"),
																																																													new System.Data.Common.DataColumnMapping("tFechaReal", "tFechaReal"),
																																																													new System.Data.Common.DataColumnMapping("dFechaLiq", "dFechaLiq"),
																																																													new System.Data.Common.DataColumnMapping("tFechaLiq", "tFechaLiq"),
																																																													new System.Data.Common.DataColumnMapping("dFechaCierre", "dFechaCierre"),
																																																													new System.Data.Common.DataColumnMapping("tFechaCierre", "tFechaCierre"),
																																																													new System.Data.Common.DataColumnMapping("sIdCliente", "sIdCliente"),
																																																													new System.Data.Common.DataColumnMapping("sNombreCli", "sNombreCli"),
																																																													new System.Data.Common.DataColumnMapping("dFUM", "dFUM"),
																																																													new System.Data.Common.DataColumnMapping("iEstado", "iEstado"),
																																																													new System.Data.Common.DataColumnMapping("bEnviadoPDA", "bEnviadoPDA"),
																																																													new System.Data.Common.DataColumnMapping("bEnviadoCEN", "bEnviadoCEN")})});
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = "[ListaAtencionesComerciales]";
			this.sqlSelectCommand1.CommandTimeout = 60;
			this.sqlSelectCommand1.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelectCommand1.Connection = this.sqlConn;
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iIdDelegado", System.Data.SqlDbType.Int, 4));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sIdAtencion", System.Data.SqlDbType.VarChar, 20));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@dFechaCreacionIni", System.Data.SqlDbType.DateTime, 8));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@dFechaPrevIni", System.Data.SqlDbType.DateTime, 8));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@dFechaAprob1Ini", System.Data.SqlDbType.DateTime, 8));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@dFechaAprob2Ini", System.Data.SqlDbType.DateTime, 8));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@dFechaRealIni", System.Data.SqlDbType.DateTime, 8));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@dFechaLiqIni", System.Data.SqlDbType.DateTime, 8));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@dFechaCierreIni", System.Data.SqlDbType.DateTime, 8));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@dFechaCreacionFin", System.Data.SqlDbType.DateTime, 8));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@dFechaPrevFin", System.Data.SqlDbType.DateTime, 8));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@dFechaAprob1Fin", System.Data.SqlDbType.DateTime, 8));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@dFechaAprob2Fin", System.Data.SqlDbType.DateTime, 8));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@dFechaRealFin", System.Data.SqlDbType.DateTime, 8));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@dFechaLiqFin", System.Data.SqlDbType.DateTime, 8));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@dFechaCierreFin", System.Data.SqlDbType.DateTime, 8));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@bBolsaViaje", System.Data.SqlDbType.Int, 4));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sIdEstAtencion", System.Data.SqlDbType.VarChar, 10));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sIdTipoAtencion", System.Data.SqlDbType.VarChar, 10));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@dFechaAprob3Ini", System.Data.SqlDbType.DateTime, 8));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@dFechaAprob4Ini", System.Data.SqlDbType.DateTime, 8));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@dFechaAprob3Fin", System.Data.SqlDbType.DateTime, 8));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@dFechaAprob4Fin", System.Data.SqlDbType.DateTime, 8));
			// 
			// sqlConn
			// 
			this.sqlConn.ConnectionString = ((string)(configurationAppSettings.GetValue("sConn", typeof(string))));
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
			this.sqlSelectCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			// 
			// sqlCmdSetAtencionesComerciales
			// 
			this.sqlCmdSetAtencionesComerciales.CommandText = "[SetAtencionesComerciales]";
			this.sqlCmdSetAtencionesComerciales.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlCmdSetAtencionesComerciales.Connection = this.sqlConn;
			this.sqlCmdSetAtencionesComerciales.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdSetAtencionesComerciales.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iAccion", System.Data.SqlDbType.Int, 4));
			this.sqlCmdSetAtencionesComerciales.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iIdAtencion", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.InputOutput, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdSetAtencionesComerciales.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sIdAtencionTemp", System.Data.SqlDbType.VarChar, 15, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdSetAtencionesComerciales.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sIdAtencion", System.Data.SqlDbType.VarChar, 20));
			this.sqlCmdSetAtencionesComerciales.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iIdDelegado", System.Data.SqlDbType.Int, 4));
			this.sqlCmdSetAtencionesComerciales.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sIdEstAtencion", System.Data.SqlDbType.VarChar, 10));
			this.sqlCmdSetAtencionesComerciales.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sIdTipoAtencion", System.Data.SqlDbType.VarChar, 10));
			this.sqlCmdSetAtencionesComerciales.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sIdCentroCoste", System.Data.SqlDbType.VarChar, 10));
			this.sqlCmdSetAtencionesComerciales.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sDescripcion", System.Data.SqlDbType.VarChar, 50));
			this.sqlCmdSetAtencionesComerciales.Parameters.Add(new System.Data.SqlClient.SqlParameter("@tObservaciones", System.Data.SqlDbType.VarChar, 8000));
			this.sqlCmdSetAtencionesComerciales.Parameters.Add(new System.Data.SqlClient.SqlParameter("@dFechaPrev", System.Data.SqlDbType.DateTime, 8));
			this.sqlCmdSetAtencionesComerciales.Parameters.Add(new System.Data.SqlClient.SqlParameter("@dFechaAprob1", System.Data.SqlDbType.DateTime, 8));
			this.sqlCmdSetAtencionesComerciales.Parameters.Add(new System.Data.SqlClient.SqlParameter("@dFechaAprob2", System.Data.SqlDbType.DateTime, 8));
			this.sqlCmdSetAtencionesComerciales.Parameters.Add(new System.Data.SqlClient.SqlParameter("@dFechaReal", System.Data.SqlDbType.DateTime, 8));
			this.sqlCmdSetAtencionesComerciales.Parameters.Add(new System.Data.SqlClient.SqlParameter("@dFechaLiq", System.Data.SqlDbType.DateTime, 8));
			this.sqlCmdSetAtencionesComerciales.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fImportePrev", System.Data.SqlDbType.Float, 8));
			this.sqlCmdSetAtencionesComerciales.Parameters.Add(new System.Data.SqlClient.SqlParameter("@bBolsaViaje", System.Data.SqlDbType.Bit, 1));
			this.sqlCmdSetAtencionesComerciales.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sUsuAprob1", System.Data.SqlDbType.VarChar, 10));
			this.sqlCmdSetAtencionesComerciales.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sUsuAprob2", System.Data.SqlDbType.VarChar, 10));
			this.sqlCmdSetAtencionesComerciales.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4));
			this.sqlCmdSetAtencionesComerciales.Parameters.Add(new System.Data.SqlClient.SqlParameter("@bEnviadoCEN", System.Data.SqlDbType.Bit, 1));
			this.sqlCmdSetAtencionesComerciales.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Res", System.Data.SqlDbType.VarChar, 10, System.Data.ParameterDirection.Output, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdSetAtencionesComerciales.Parameters.Add(new System.Data.SqlClient.SqlParameter("@dFechaAprob3", System.Data.SqlDbType.DateTime, 8));
			this.sqlCmdSetAtencionesComerciales.Parameters.Add(new System.Data.SqlClient.SqlParameter("@dFechaAprob4", System.Data.SqlDbType.DateTime, 8));
			// 
			// ucBotoneraSecundaria1
			// 
			this.ucBotoneraSecundaria1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(211)), ((System.Byte)(117)), ((System.Byte)(1)));
			this.ucBotoneraSecundaria1.Dock = System.Windows.Forms.DockStyle.Top;
			this.ucBotoneraSecundaria1.ForeColor = System.Drawing.Color.Black;
			this.ucBotoneraSecundaria1.Location = new System.Drawing.Point(0, 0);
			this.ucBotoneraSecundaria1.Name = "ucBotoneraSecundaria1";
			this.ucBotoneraSecundaria1.Size = new System.Drawing.Size(975, 38);
			this.ucBotoneraSecundaria1.TabIndex = 5;
			// 
			// txtDescripcion
			// 
			this.txtDescripcion.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(238)), ((System.Byte)(243)), ((System.Byte)(246)));
			this.txtDescripcion.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsAtenciones1, "ListaAtencionesComerciales.tObservaciones"));
			this.txtDescripcion.ForeColor = System.Drawing.Color.Black;
			this.txtDescripcion.Location = new System.Drawing.Point(2, 80);
			this.txtDescripcion.Multiline = true;
			this.txtDescripcion.Name = "txtDescripcion";
			this.txtDescripcion.ReadOnly = true;
			this.txtDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtDescripcion.Size = new System.Drawing.Size(232, 136);
			this.txtDescripcion.TabIndex = 15;
			this.txtDescripcion.TabStop = false;
			this.txtDescripcion.Text = "";
			// 
			// lblDescripcion
			// 
			this.lblDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.lblDescripcion.ForeColor = System.Drawing.Color.Black;
			this.lblDescripcion.Location = new System.Drawing.Point(0, 67);
			this.lblDescripcion.Name = "lblDescripcion";
			this.lblDescripcion.Size = new System.Drawing.Size(88, 16);
			this.lblDescripcion.TabIndex = 91;
			this.lblDescripcion.Text = "Observaciones:";
			// 
			// dgAtencionesClientes
			// 
			this.dgAtencionesClientes.BackgroundColor = System.Drawing.Color.White;
			this.dgAtencionesClientes.CaptionBackColor = System.Drawing.Color.FromArgb(((System.Byte)(18)), ((System.Byte)(84)), ((System.Byte)(132)));
			this.dgAtencionesClientes.CaptionVisible = false;
			this.dgAtencionesClientes.DataMember = "ListaAtencionesClientes";
			this.dgAtencionesClientes.DataSource = this.dsAtenciones1;
			this.dgAtencionesClientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.dgAtencionesClientes.HeaderBackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.dgAtencionesClientes.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgAtencionesClientes.Location = new System.Drawing.Point(-2, 48);
			this.dgAtencionesClientes.Name = "dgAtencionesClientes";
			this.dgAtencionesClientes.ReadOnly = true;
			this.dgAtencionesClientes.RowHeaderWidth = 30;
			this.dgAtencionesClientes.Size = new System.Drawing.Size(679, 99);
			this.dgAtencionesClientes.TabIndex = 3;
			this.dgAtencionesClientes.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																											 this.dataGridTableStyle2});
			this.dgAtencionesClientes.CurrentCellChanged += new System.EventHandler(this.dgAtencionesClientes_CurrentCellChanged);
			// 
			// dataGridTableStyle2
			// 
			this.dataGridTableStyle2.DataGrid = this.dgAtencionesClientes;
			this.dataGridTableStyle2.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.dFecha,
																												  this.sIdCliente,
																												  this.sNombre,
																												  this.sDescTipoCliente,
																												  this.bSustituto,
																												  this.fImporte});
			this.dataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle2.MappingName = "ListaAtencionesClientes";
			this.dataGridTableStyle2.RowHeaderWidth = 30;
			// 
			// dFecha
			// 
			this.dFecha.Format = "dd/MM/yyyy";
			this.dFecha.FormatInfo = null;
			this.dFecha.HeaderText = "F.Report";
			this.dFecha.MappingName = "dFecha";
			this.dFecha.NullText = "";
			this.dFecha.Width = 65;
			// 
			// sIdCliente
			// 
			this.sIdCliente.Format = "";
			this.sIdCliente.FormatInfo = null;
			this.sIdCliente.HeaderText = "Código";
			this.sIdCliente.MappingName = "sIdCliente";
			this.sIdCliente.NullText = "";
			this.sIdCliente.Width = 110;
			// 
			// sNombre
			// 
			this.sNombre.Format = "";
			this.sNombre.FormatInfo = null;
			this.sNombre.HeaderText = "Nombre";
			this.sNombre.MappingName = "sNombre";
			this.sNombre.NullText = "";
			this.sNombre.Width = 260;
			// 
			// sDescTipoCliente
			// 
			this.sDescTipoCliente.Format = "";
			this.sDescTipoCliente.FormatInfo = null;
			this.sDescTipoCliente.HeaderText = "Tipo";
			this.sDescTipoCliente.MappingName = "sDescTipoCliente";
			this.sDescTipoCliente.NullText = "";
			this.sDescTipoCliente.Width = 80;
			// 
			// bSustituto
			// 
			this.bSustituto.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
			this.bSustituto.Format = "";
			this.bSustituto.FormatInfo = null;
			this.bSustituto.HeaderText = "Sust.";
			this.bSustituto.MappingName = "tSustituto";
			this.bSustituto.NullText = "";
			this.bSustituto.Width = 40;
			// 
			// fImporte
			// 
			this.fImporte.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
			this.fImporte.Format = "";
			this.fImporte.FormatInfo = null;
			this.fImporte.HeaderText = "Importe";
			this.fImporte.MappingName = "fImporte";
			this.fImporte.NullText = "";
			this.fImporte.Width = 75;
			// 
			// sqldaAtencionesClientes
			// 
			this.sqldaAtencionesClientes.SelectCommand = this.sqlSelectCommand3;
			this.sqldaAtencionesClientes.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																											  new System.Data.Common.DataTableMapping("Table", "ListaAtencionesClientes", new System.Data.Common.DataColumnMapping[] {
																																																										 new System.Data.Common.DataColumnMapping("iIdReport", "iIdReport"),
																																																										 new System.Data.Common.DataColumnMapping("iIdCliente", "iIdCliente"),
																																																										 new System.Data.Common.DataColumnMapping("sIdCliente", "sIdCliente"),
																																																										 new System.Data.Common.DataColumnMapping("sTipoCliente", "sTipoCliente"),
																																																										 new System.Data.Common.DataColumnMapping("sDescTipoCliente", "sDescTipoCliente"),
																																																										 new System.Data.Common.DataColumnMapping("sNombre", "sNombre"),
																																																										 new System.Data.Common.DataColumnMapping("fImporte", "fImporte"),
																																																										 new System.Data.Common.DataColumnMapping("bSustituto", "bSustituto"),
																																																										 new System.Data.Common.DataColumnMapping("tSustituto", "tSustituto"),
																																																										 new System.Data.Common.DataColumnMapping("dFecha", "dFecha"),
																																																										 new System.Data.Common.DataColumnMapping("tFecha", "tFecha"),
																																																										 new System.Data.Common.DataColumnMapping("bEnviadoCEN", "bEnviadoCEN")})});
			// 
			// sqlSelectCommand3
			// 
			this.sqlSelectCommand3.CommandText = "[ListaAtencionesClientes]";
			this.sqlSelectCommand3.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelectCommand3.Connection = this.sqlConn;
			this.sqlSelectCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelectCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iIdAtencion", System.Data.SqlDbType.Int, 4));
			this.sqlSelectCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@dFReportIni", System.Data.SqlDbType.DateTime, 8));
			this.sqlSelectCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@dFReportFin", System.Data.SqlDbType.DateTime, 8));
			// 
			// lblNumRegClientes
			// 
			this.lblNumRegClientes.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(238)), ((System.Byte)(243)), ((System.Byte)(246)));
			this.lblNumRegClientes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblNumRegClientes.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblNumRegClientes.ForeColor = System.Drawing.Color.Black;
			this.lblNumRegClientes.Location = new System.Drawing.Point(617, 0);
			this.lblNumRegClientes.Name = "lblNumRegClientes";
			this.lblNumRegClientes.Size = new System.Drawing.Size(60, 18);
			this.lblNumRegClientes.TabIndex = 97;
			this.lblNumRegClientes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// sqldaListaTipoEstadoAtencion
			// 
			this.sqldaListaTipoEstadoAtencion.SelectCommand = this.sqlSelectCommand4;
			this.sqldaListaTipoEstadoAtencion.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																												   new System.Data.Common.DataTableMapping("Table", "ListaTipoEstadoAtencion", new System.Data.Common.DataColumnMapping[] {
																																																											  new System.Data.Common.DataColumnMapping("sValor", "sValor"),
																																																											  new System.Data.Common.DataColumnMapping("sLiteral", "sLiteral")})});
			// 
			// sqlSelectCommand4
			// 
			this.sqlSelectCommand4.CommandText = "[ListaTipoEstadoAtencion]";
			this.sqlSelectCommand4.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelectCommand4.Connection = this.sqlConn;
			this.sqlSelectCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			// 
			// pnAtenciones
			// 
			this.pnAtenciones.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.pnAtenciones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pnAtenciones.Controls.Add(this.lblNumRegAtenciones);
			this.pnAtenciones.Controls.Add(this.labelGradient2);
			this.pnAtenciones.Controls.Add(this.dgAtenciones);
			this.pnAtenciones.Location = new System.Drawing.Point(1, 264);
			this.pnAtenciones.Name = "pnAtenciones";
			this.pnAtenciones.Size = new System.Drawing.Size(934, 176);
			this.pnAtenciones.TabIndex = 1;
			// 
			// lblNumRegAtenciones
			// 
			this.lblNumRegAtenciones.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(238)), ((System.Byte)(243)), ((System.Byte)(246)));
			this.lblNumRegAtenciones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblNumRegAtenciones.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblNumRegAtenciones.ForeColor = System.Drawing.Color.Black;
			this.lblNumRegAtenciones.Location = new System.Drawing.Point(870, 0);
			this.lblNumRegAtenciones.Name = "lblNumRegAtenciones";
			this.lblNumRegAtenciones.Size = new System.Drawing.Size(60, 18);
			this.lblNumRegAtenciones.TabIndex = 96;
			this.lblNumRegAtenciones.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
			this.labelGradient2.Size = new System.Drawing.Size(930, 18);
			this.labelGradient2.TabIndex = 92;
			this.labelGradient2.Text = "Atenciones Comerciales";
			this.labelGradient2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// pnClientesPermanente
			// 
			this.pnClientesPermanente.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pnClientesPermanente.Controls.Add(this.btBuscarAtenCli);
			this.pnClientesPermanente.Controls.Add(this.label27);
			this.pnClientesPermanente.Controls.Add(this.label26);
			this.pnClientesPermanente.Controls.Add(this.dtpFReportFin);
			this.pnClientesPermanente.Controls.Add(this.dtpFReportIni);
			this.pnClientesPermanente.Controls.Add(this.lblNumRegClientes);
			this.pnClientesPermanente.Controls.Add(this.labelGradient3);
			this.pnClientesPermanente.Controls.Add(this.dgAtencionesClientes);
			this.pnClientesPermanente.Location = new System.Drawing.Point(248, 67);
			this.pnClientesPermanente.Name = "pnClientesPermanente";
			this.pnClientesPermanente.Size = new System.Drawing.Size(680, 150);
			this.pnClientesPermanente.TabIndex = 16;
			// 
			// label27
			// 
			this.label27.Location = new System.Drawing.Point(304, 24);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(32, 18);
			this.label27.TabIndex = 101;
			this.label27.Text = "entre";
			this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label26
			// 
			this.label26.Location = new System.Drawing.Point(152, 24);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(56, 18);
			this.label26.TabIndex = 100;
			this.label26.Text = "F.Report:";
			this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// dtpFReportFin
			// 
			this.dtpFReportFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpFReportFin.Location = new System.Drawing.Point(344, 22);
			this.dtpFReportFin.Name = "dtpFReportFin";
			this.dtpFReportFin.Size = new System.Drawing.Size(88, 20);
			this.dtpFReportFin.TabIndex = 1;
			this.dtpFReportFin.ValueChanged += new System.EventHandler(this.dtpFechaReport_ValueChanged);
			// 
			// dtpFReportIni
			// 
			this.dtpFReportIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpFReportIni.Location = new System.Drawing.Point(208, 22);
			this.dtpFReportIni.Name = "dtpFReportIni";
			this.dtpFReportIni.Size = new System.Drawing.Size(88, 20);
			this.dtpFReportIni.TabIndex = 0;
			this.dtpFReportIni.ValueChanged += new System.EventHandler(this.dtpFechaReport_ValueChanged);
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
			this.labelGradient3.Size = new System.Drawing.Size(676, 18);
			this.labelGradient3.TabIndex = 93;
			this.labelGradient3.Text = "Clientes con Atención Comercial Asignada en Report de Actividad";
			this.labelGradient3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// sqldaListaTipoAtencionComercial
			// 
			this.sqldaListaTipoAtencionComercial.SelectCommand = this.sqlSelectCommand5;
			this.sqldaListaTipoAtencionComercial.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																													  new System.Data.Common.DataTableMapping("Table", "ListaTipoAtencionComercial", new System.Data.Common.DataColumnMapping[] {
																																																													new System.Data.Common.DataColumnMapping("sValor", "sValor"),
																																																													new System.Data.Common.DataColumnMapping("sLiteral", "sLiteral")})});
			// 
			// sqlSelectCommand5
			// 
			this.sqlSelectCommand5.CommandText = "[ListaTipoAtencionComercial]";
			this.sqlSelectCommand5.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelectCommand5.Connection = this.sqlConn;
			this.sqlSelectCommand5.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			// 
			// pnDatosAtencion
			// 
			this.pnDatosAtencion.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.pnDatosAtencion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pnDatosAtencion.Controls.Add(this.textBox1);
			this.pnDatosAtencion.Controls.Add(this.label31);
			this.pnDatosAtencion.Controls.Add(this.pnClienteManual);
			this.pnDatosAtencion.Controls.Add(this.txtsCentroCoste);
			this.pnDatosAtencion.Controls.Add(this.chbBolsaViaje);
			this.pnDatosAtencion.Controls.Add(this.txtFechaLiq);
			this.pnDatosAtencion.Controls.Add(this.txtFechaReal);
			this.pnDatosAtencion.Controls.Add(this.txtFechaAprob2);
			this.pnDatosAtencion.Controls.Add(this.txtFechaAprob1);
			this.pnDatosAtencion.Controls.Add(this.txtFechaPrev);
			this.pnDatosAtencion.Controls.Add(this.txtsIdTipoAtencion);
			this.pnDatosAtencion.Controls.Add(this.txttsIdAtencion);
			this.pnDatosAtencion.Controls.Add(this.txtsIdEStadoAtencion);
			this.pnDatosAtencion.Controls.Add(this.txtfImpReal);
			this.pnDatosAtencion.Controls.Add(this.txtfImpPrev);
			this.pnDatosAtencion.Controls.Add(this.txtsDescripcion);
			this.pnDatosAtencion.Controls.Add(this.txtDescripcion);
			this.pnDatosAtencion.Controls.Add(this.lblDescripcion);
			this.pnDatosAtencion.Controls.Add(this.pnClientesPermanente);
			this.pnDatosAtencion.Controls.Add(this.txtFechaCierre);
			this.pnDatosAtencion.Controls.Add(this.label20);
			this.pnDatosAtencion.Controls.Add(this.label19);
			this.pnDatosAtencion.Controls.Add(this.label18);
			this.pnDatosAtencion.Controls.Add(this.label17);
			this.pnDatosAtencion.Controls.Add(this.label16);
			this.pnDatosAtencion.Controls.Add(this.label15);
			this.pnDatosAtencion.Controls.Add(this.label4);
			this.pnDatosAtencion.Controls.Add(this.label14);
			this.pnDatosAtencion.Controls.Add(this.label13);
			this.pnDatosAtencion.Controls.Add(this.label21);
			this.pnDatosAtencion.Controls.Add(this.label23);
			this.pnDatosAtencion.Controls.Add(this.label22);
			this.pnDatosAtencion.Controls.Add(this.label24);
			this.pnDatosAtencion.Location = new System.Drawing.Point(1, 442);
			this.pnDatosAtencion.Name = "pnDatosAtencion";
			this.pnDatosAtencion.Size = new System.Drawing.Size(934, 390);
			this.pnDatosAtencion.TabIndex = 2;
			// 
			// textBox1
			// 
			this.textBox1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(238)), ((System.Byte)(243)), ((System.Byte)(246)));
			this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsAtenciones1, "ListaAtencionesComerciales.tFechaCreacion"));
			this.textBox1.ForeColor = System.Drawing.Color.Black;
			this.textBox1.Location = new System.Drawing.Point(45, 44);
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(80, 20);
			this.textBox1.TabIndex = 8;
			this.textBox1.Text = "";
			// 
			// label31
			// 
			this.label31.Location = new System.Drawing.Point(0, 46);
			this.label31.Name = "label31";
			this.label31.Size = new System.Drawing.Size(100, 18);
			this.label31.TabIndex = 125;
			this.label31.Text = "F.Cre.:";
			this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// pnClienteManual
			// 
			this.pnClienteManual.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pnClienteManual.Controls.Add(this.labelGradient4);
			this.pnClienteManual.Controls.Add(this.chbSustituto);
			this.pnClienteManual.Controls.Add(this.txtImpCliente);
			this.pnClienteManual.Controls.Add(this.txtTipoCli);
			this.pnClienteManual.Controls.Add(this.txtNombreCli);
			this.pnClienteManual.Controls.Add(this.txtFechaReport);
			this.pnClienteManual.Controls.Add(this.label30);
			this.pnClienteManual.Controls.Add(this.label29);
			this.pnClienteManual.Controls.Add(this.label25);
			this.pnClienteManual.Controls.Add(this.label28);
			this.pnClienteManual.Location = new System.Drawing.Point(248, 224);
			this.pnClienteManual.Name = "pnClienteManual";
			this.pnClienteManual.Size = new System.Drawing.Size(680, 150);
			this.pnClienteManual.TabIndex = 17;
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
			this.labelGradient4.Size = new System.Drawing.Size(676, 18);
			this.labelGradient4.TabIndex = 12;
			this.labelGradient4.Text = "Cliente con Atención Comercial Asignada";
			this.labelGradient4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// chbSustituto
			// 
			this.chbSustituto.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.dsAtenciones1, "ListaAtencionesClientes.bSustituto"));
			this.chbSustituto.Enabled = false;
			this.chbSustituto.Location = new System.Drawing.Point(240, 90);
			this.chbSustituto.Name = "chbSustituto";
			this.chbSustituto.Size = new System.Drawing.Size(104, 18);
			this.chbSustituto.TabIndex = 3;
			this.chbSustituto.Text = "Sustituto";
			// 
			// txtImpCliente
			// 
			this.txtImpCliente.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(238)), ((System.Byte)(243)), ((System.Byte)(246)));
			this.txtImpCliente.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsAtenciones1, "ListaAtencionesClientes.fImporte"));
			this.txtImpCliente.ForeColor = System.Drawing.Color.Black;
			this.txtImpCliente.Location = new System.Drawing.Point(120, 120);
			this.txtImpCliente.Name = "txtImpCliente";
			this.txtImpCliente.ReadOnly = true;
			this.txtImpCliente.TabIndex = 4;
			this.txtImpCliente.Text = "";
			// 
			// txtTipoCli
			// 
			this.txtTipoCli.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(238)), ((System.Byte)(243)), ((System.Byte)(246)));
			this.txtTipoCli.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsAtenciones1, "ListaAtencionesClientes.sDescTipoCliente"));
			this.txtTipoCli.ForeColor = System.Drawing.Color.Black;
			this.txtTipoCli.Location = new System.Drawing.Point(120, 88);
			this.txtTipoCli.Name = "txtTipoCli";
			this.txtTipoCli.ReadOnly = true;
			this.txtTipoCli.TabIndex = 2;
			this.txtTipoCli.Text = "";
			// 
			// txtNombreCli
			// 
			this.txtNombreCli.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(238)), ((System.Byte)(243)), ((System.Byte)(246)));
			this.txtNombreCli.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsAtenciones1, "ListaAtencionesComerciales.sNombreCli"));
			this.txtNombreCli.ForeColor = System.Drawing.Color.Black;
			this.txtNombreCli.Location = new System.Drawing.Point(120, 56);
			this.txtNombreCli.Name = "txtNombreCli";
			this.txtNombreCli.ReadOnly = true;
			this.txtNombreCli.Size = new System.Drawing.Size(384, 20);
			this.txtNombreCli.TabIndex = 1;
			this.txtNombreCli.Text = "";
			// 
			// txtFechaReport
			// 
			this.txtFechaReport.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(238)), ((System.Byte)(243)), ((System.Byte)(246)));
			this.txtFechaReport.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsAtenciones1, "ListaAtencionesClientes.tFecha"));
			this.txtFechaReport.ForeColor = System.Drawing.Color.Black;
			this.txtFechaReport.Location = new System.Drawing.Point(120, 24);
			this.txtFechaReport.Name = "txtFechaReport";
			this.txtFechaReport.ReadOnly = true;
			this.txtFechaReport.TabIndex = 0;
			this.txtFechaReport.Text = "";
			// 
			// label30
			// 
			this.label30.Location = new System.Drawing.Point(56, 120);
			this.label30.Name = "label30";
			this.label30.Size = new System.Drawing.Size(72, 18);
			this.label30.TabIndex = 10;
			this.label30.Text = "Importe Cli.:";
			this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label29
			// 
			this.label29.Location = new System.Drawing.Point(56, 90);
			this.label29.Name = "label29";
			this.label29.Size = new System.Drawing.Size(60, 18);
			this.label29.TabIndex = 9;
			this.label29.Text = "Tipo Cli.:";
			this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label25
			// 
			this.label25.Location = new System.Drawing.Point(56, 26);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(60, 18);
			this.label25.TabIndex = 5;
			this.label25.Text = "F.Report:";
			this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label28
			// 
			this.label28.Location = new System.Drawing.Point(56, 58);
			this.label28.Name = "label28";
			this.label28.Size = new System.Drawing.Size(72, 18);
			this.label28.TabIndex = 8;
			this.label28.Text = "Nombre Cli.:";
			this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtsCentroCoste
			// 
			this.txtsCentroCoste.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(238)), ((System.Byte)(243)), ((System.Byte)(246)));
			this.txtsCentroCoste.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsAtenciones1, "ListaAtencionesComerciales.sCentroCoste"));
			this.txtsCentroCoste.ForeColor = System.Drawing.Color.Black;
			this.txtsCentroCoste.Location = new System.Drawing.Point(776, 4);
			this.txtsCentroCoste.Name = "txtsCentroCoste";
			this.txtsCentroCoste.ReadOnly = true;
			this.txtsCentroCoste.Size = new System.Drawing.Size(152, 20);
			this.txtsCentroCoste.TabIndex = 4;
			this.txtsCentroCoste.Text = "";
			// 
			// chbBolsaViaje
			// 
			this.chbBolsaViaje.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.dsAtenciones1, "ListaAtencionesComerciales.bBolsaViaje"));
			this.chbBolsaViaje.Enabled = false;
			this.chbBolsaViaje.Location = new System.Drawing.Point(216, 5);
			this.chbBolsaViaje.Name = "chbBolsaViaje";
			this.chbBolsaViaje.Size = new System.Drawing.Size(104, 18);
			this.chbBolsaViaje.TabIndex = 1;
			this.chbBolsaViaje.Text = "AP";
			// 
			// txtFechaLiq
			// 
			this.txtFechaLiq.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(238)), ((System.Byte)(243)), ((System.Byte)(246)));
			this.txtFechaLiq.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsAtenciones1, "ListaAtencionesComerciales.tFechaLiq"));
			this.txtFechaLiq.ForeColor = System.Drawing.Color.Black;
			this.txtFechaLiq.Location = new System.Drawing.Point(712, 44);
			this.txtFechaLiq.Name = "txtFechaLiq";
			this.txtFechaLiq.ReadOnly = true;
			this.txtFechaLiq.Size = new System.Drawing.Size(80, 20);
			this.txtFechaLiq.TabIndex = 13;
			this.txtFechaLiq.Text = "";
			// 
			// txtFechaReal
			// 
			this.txtFechaReal.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(238)), ((System.Byte)(243)), ((System.Byte)(246)));
			this.txtFechaReal.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsAtenciones1, "ListaAtencionesComerciales.tFechaReal"));
			this.txtFechaReal.ForeColor = System.Drawing.Color.Black;
			this.txtFechaReal.Location = new System.Drawing.Point(584, 44);
			this.txtFechaReal.Name = "txtFechaReal";
			this.txtFechaReal.ReadOnly = true;
			this.txtFechaReal.Size = new System.Drawing.Size(80, 20);
			this.txtFechaReal.TabIndex = 12;
			this.txtFechaReal.Text = "";
			// 
			// txtFechaAprob2
			// 
			this.txtFechaAprob2.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(238)), ((System.Byte)(243)), ((System.Byte)(246)));
			this.txtFechaAprob2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsAtenciones1, "ListaAtencionesComerciales.tFechaAprob2"));
			this.txtFechaAprob2.ForeColor = System.Drawing.Color.Black;
			this.txtFechaAprob2.Location = new System.Drawing.Point(448, 44);
			this.txtFechaAprob2.Name = "txtFechaAprob2";
			this.txtFechaAprob2.ReadOnly = true;
			this.txtFechaAprob2.Size = new System.Drawing.Size(80, 20);
			this.txtFechaAprob2.TabIndex = 11;
			this.txtFechaAprob2.Text = "";
			// 
			// txtFechaAprob1
			// 
			this.txtFechaAprob1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(238)), ((System.Byte)(243)), ((System.Byte)(246)));
			this.txtFechaAprob1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsAtenciones1, "ListaAtencionesComerciales.tFechaAprob1"));
			this.txtFechaAprob1.ForeColor = System.Drawing.Color.Black;
			this.txtFechaAprob1.Location = new System.Drawing.Point(312, 44);
			this.txtFechaAprob1.Name = "txtFechaAprob1";
			this.txtFechaAprob1.ReadOnly = true;
			this.txtFechaAprob1.Size = new System.Drawing.Size(80, 20);
			this.txtFechaAprob1.TabIndex = 10;
			this.txtFechaAprob1.Text = "";
			// 
			// txtFechaPrev
			// 
			this.txtFechaPrev.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(238)), ((System.Byte)(243)), ((System.Byte)(246)));
			this.txtFechaPrev.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsAtenciones1, "ListaAtencionesComerciales.tFechaPrev"));
			this.txtFechaPrev.ForeColor = System.Drawing.Color.Black;
			this.txtFechaPrev.Location = new System.Drawing.Point(176, 44);
			this.txtFechaPrev.Name = "txtFechaPrev";
			this.txtFechaPrev.ReadOnly = true;
			this.txtFechaPrev.Size = new System.Drawing.Size(80, 20);
			this.txtFechaPrev.TabIndex = 9;
			this.txtFechaPrev.Text = "";
			// 
			// txtsIdTipoAtencion
			// 
			this.txtsIdTipoAtencion.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(238)), ((System.Byte)(243)), ((System.Byte)(246)));
			this.txtsIdTipoAtencion.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsAtenciones1, "ListaAtencionesComerciales.sTipoAtencion"));
			this.txtsIdTipoAtencion.ForeColor = System.Drawing.Color.Black;
			this.txtsIdTipoAtencion.Location = new System.Drawing.Point(480, 4);
			this.txtsIdTipoAtencion.Name = "txtsIdTipoAtencion";
			this.txtsIdTipoAtencion.ReadOnly = true;
			this.txtsIdTipoAtencion.TabIndex = 2;
			this.txtsIdTipoAtencion.Text = "";
			// 
			// txttsIdAtencion
			// 
			this.txttsIdAtencion.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(238)), ((System.Byte)(243)), ((System.Byte)(246)));
			this.txttsIdAtencion.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsAtenciones1, "ListaAtencionesComerciales.sIdAtencion"));
			this.txttsIdAtencion.ForeColor = System.Drawing.Color.Black;
			this.txttsIdAtencion.Location = new System.Drawing.Point(45, 4);
			this.txttsIdAtencion.Name = "txttsIdAtencion";
			this.txttsIdAtencion.ReadOnly = true;
			this.txttsIdAtencion.Size = new System.Drawing.Size(144, 20);
			this.txttsIdAtencion.TabIndex = 0;
			this.txttsIdAtencion.Text = "";
			// 
			// txtsIdEStadoAtencion
			// 
			this.txtsIdEStadoAtencion.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(238)), ((System.Byte)(243)), ((System.Byte)(246)));
			this.txtsIdEStadoAtencion.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsAtenciones1, "ListaAtencionesComerciales.sEstAtencion"));
			this.txtsIdEStadoAtencion.ForeColor = System.Drawing.Color.Black;
			this.txtsIdEStadoAtencion.Location = new System.Drawing.Point(480, 24);
			this.txtsIdEStadoAtencion.Name = "txtsIdEStadoAtencion";
			this.txtsIdEStadoAtencion.ReadOnly = true;
			this.txtsIdEStadoAtencion.TabIndex = 6;
			this.txtsIdEStadoAtencion.Text = "";
			// 
			// txtfImpReal
			// 
			this.txtfImpReal.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(238)), ((System.Byte)(243)), ((System.Byte)(246)));
			this.txtfImpReal.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsAtenciones1, "ListaAtencionesComerciales.fImporteReal"));
			this.txtfImpReal.ForeColor = System.Drawing.Color.Black;
			this.txtfImpReal.Location = new System.Drawing.Point(632, 24);
			this.txtfImpReal.Name = "txtfImpReal";
			this.txtfImpReal.ReadOnly = true;
			this.txtfImpReal.Size = new System.Drawing.Size(75, 20);
			this.txtfImpReal.TabIndex = 7;
			this.txtfImpReal.Text = "";
			// 
			// txtfImpPrev
			// 
			this.txtfImpPrev.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(238)), ((System.Byte)(243)), ((System.Byte)(246)));
			this.txtfImpPrev.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsAtenciones1, "ListaAtencionesComerciales.fImportePrev"));
			this.txtfImpPrev.ForeColor = System.Drawing.Color.Black;
			this.txtfImpPrev.Location = new System.Drawing.Point(632, 4);
			this.txtfImpPrev.Name = "txtfImpPrev";
			this.txtfImpPrev.ReadOnly = true;
			this.txtfImpPrev.Size = new System.Drawing.Size(75, 20);
			this.txtfImpPrev.TabIndex = 3;
			this.txtfImpPrev.Text = "";
			// 
			// txtsDescripcion
			// 
			this.txtsDescripcion.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(238)), ((System.Byte)(243)), ((System.Byte)(246)));
			this.txtsDescripcion.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsAtenciones1, "ListaAtencionesComerciales.sDescripcion"));
			this.txtsDescripcion.ForeColor = System.Drawing.Color.Black;
			this.txtsDescripcion.Location = new System.Drawing.Point(45, 24);
			this.txtsDescripcion.Name = "txtsDescripcion";
			this.txtsDescripcion.ReadOnly = true;
			this.txtsDescripcion.Size = new System.Drawing.Size(387, 20);
			this.txtsDescripcion.TabIndex = 5;
			this.txtsDescripcion.Text = "";
			// 
			// txtFechaCierre
			// 
			this.txtFechaCierre.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(238)), ((System.Byte)(243)), ((System.Byte)(246)));
			this.txtFechaCierre.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dsAtenciones1, "ListaAtencionesComerciales.tFechaCierre"));
			this.txtFechaCierre.ForeColor = System.Drawing.Color.Black;
			this.txtFechaCierre.Location = new System.Drawing.Point(848, 44);
			this.txtFechaCierre.Name = "txtFechaCierre";
			this.txtFechaCierre.ReadOnly = true;
			this.txtFechaCierre.Size = new System.Drawing.Size(80, 20);
			this.txtFechaCierre.TabIndex = 14;
			this.txtFechaCierre.Text = "";
			// 
			// label20
			// 
			this.label20.Location = new System.Drawing.Point(808, 46);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(100, 18);
			this.label20.TabIndex = 115;
			this.label20.Text = "F.Cierre:";
			this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label19
			// 
			this.label19.Location = new System.Drawing.Point(680, 46);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(100, 18);
			this.label19.TabIndex = 114;
			this.label19.Text = "F.Liq.:";
			this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label18
			// 
			this.label18.Location = new System.Drawing.Point(544, 46);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(100, 18);
			this.label18.TabIndex = 113;
			this.label18.Text = "F.Real:";
			this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label17
			// 
			this.label17.Location = new System.Drawing.Point(400, 46);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(100, 18);
			this.label17.TabIndex = 112;
			this.label17.Text = "F.Aprob2:";
			this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label16
			// 
			this.label16.Location = new System.Drawing.Point(136, 46);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(100, 18);
			this.label16.TabIndex = 111;
			this.label16.Text = "F.Prev.:";
			this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(264, 46);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(100, 18);
			this.label15.TabIndex = 110;
			this.label15.Text = "F.Aprob1:";
			this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(0, 24);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(72, 18);
			this.label4.TabIndex = 96;
			this.label4.Text = "Descrip.:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(584, 26);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(56, 18);
			this.label14.TabIndex = 100;
			this.label14.Text = "Imp.Real:";
			this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(584, 6);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(56, 18);
			this.label13.TabIndex = 99;
			this.label13.Text = "Imp.Prev.:";
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label21
			// 
			this.label21.Location = new System.Drawing.Point(0, 6);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(100, 18);
			this.label21.TabIndex = 116;
			this.label21.Text = "Código:";
			this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label23
			// 
			this.label23.Location = new System.Drawing.Point(440, 6);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(100, 18);
			this.label23.TabIndex = 120;
			this.label23.Text = "Tipo:";
			this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label22
			// 
			this.label22.Location = new System.Drawing.Point(440, 26);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(100, 18);
			this.label22.TabIndex = 119;
			this.label22.Text = "Estado:";
			this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label24
			// 
			this.label24.Location = new System.Drawing.Point(712, 6);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(100, 18);
			this.label24.TabIndex = 122;
			this.label24.Text = "CentroCoste:";
			this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// sqldaGetCargoDelegado
			// 
			this.sqldaGetCargoDelegado.SelectCommand = this.sqlSelectCommand6;
			this.sqldaGetCargoDelegado.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																											new System.Data.Common.DataTableMapping("Table", "GetCargoDelegado", new System.Data.Common.DataColumnMapping[] {
																																																								new System.Data.Common.DataColumnMapping("iIdCargo", "iIdCargo")})});
			// 
			// sqlSelectCommand6
			// 
			this.sqlSelectCommand6.CommandText = "[GetCargoDelegado]";
			this.sqlSelectCommand6.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelectCommand6.Connection = this.sqlConn;
			this.sqlSelectCommand6.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelectCommand6.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iIdDelegado", System.Data.SqlDbType.Int, 4));
			// 
			// frmConsultaAtenciones
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(238)), ((System.Byte)(243)), ((System.Byte)(246)));
			this.ClientSize = new System.Drawing.Size(975, 446);
			this.Controls.Add(this.pnDatosAtencion);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.ucBotoneraSecundaria1);
			this.Controls.Add(this.pnAtenciones);
			this.ForeColor = System.Drawing.Color.Black;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmConsultaAtenciones";
			this.Text = "Consulta de Atenciones Comerciales";
			this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
			this.Load += new System.EventHandler(this.frmConsultaAtenciones_Load);
			this.Closed += new System.EventHandler(this.frmConsultaAtenciones_Closed);
			this.panel3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dsAtenciones1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgAtenciones)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgAtencionesClientes)).EndInit();
			this.pnAtenciones.ResumeLayout(false);
			this.pnClientesPermanente.ResumeLayout(false);
			this.pnDatosAtencion.ResumeLayout(false);
			this.pnClienteManual.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region frmConsultaAtenciones_Load
		private void frmConsultaAtenciones_Load(object sender, System.EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;
			
			try
			{
				Utiles.Formato_Formulario( this );
				if(this.Parent == null) this.WindowState = FormWindowState.Normal;

				Inicializar_Combos();   
				Inicializar_Fechas();
				Inicializar_DataGrid();
				Inicializar_Botonera();		

				this.Var_iIdCliente=-1;
				this.Var_iIdAtencion=-1;
				this.Var_fila=-1;

				this.pnClienteManual.Location = new Point(248,68);
				this.pnClientesPermanente.Location = new Point(248,68);
				this.pnDatosAtencion.Height = 223;
				this.pnDatosAtencion.Visible=false;

				if(Configuracion.iGAtenciones!=0)
				{
					this.menuEliminar.Enabled=false;
					this.menuNuevo.Enabled=false;
				}
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
				//Inicializar ComboBox cboDelegado
				this.sqldaListaDelegados.Fill(this.dsAtenciones1);
				DataRow fila1 = this.dsAtenciones1.ListaDelegados.NewRow();
				fila1["iIdDelegado"]=-1;
				fila1["sNombre"]="Todos";
				this.dsAtenciones1.ListaDelegados.Rows.InsertAt(fila1,0);
				this.cboDelegado.SelectedValue = Clases.Configuracion.iIdDelegado;

				//Inicializar ComboBox cbTipoAtencion
				this.sqldaListaTipoAtencionComercial.Fill(this.dsAtenciones1);
				DataRow fila2 = this.dsAtenciones1.ListaTipoAtencionComercial.NewRow();
				fila2["sValor"] = "-1";
				fila2["sLiteral"] = "Todos";
				this.dsAtenciones1.ListaTipoAtencionComercial.Rows.InsertAt(fila2,0);
				this.dsAtenciones1.ListaTipoAtencionComercial.Rows.RemoveAt(1);
				this.cbTipoAtencion.SelectedValue = "-1";

				//Inicializar ComboBox cboEstado
				this.sqldaListaTipoEstadoAtencion.Fill(this.dsAtenciones1);
				DataRow fila3 = this.dsAtenciones1.ListaTipoEstadoAtencion.NewRow();
				fila3["sValor"] = "-1";
				fila3["sLiteral"] = "Todos";
				this.dsAtenciones1.ListaTipoEstadoAtencion.Rows.InsertAt(fila3,0);
				this.cboEstado.SelectedValue = "-1";


				//Inicializar ComboBox cbBolsaViaje
				DataTable tabla1 = new DataTable();
				tabla1.Columns.Add("sValor");
				tabla1.Columns.Add("sLiteral");
				DataRow fila50 = tabla1.NewRow();
				fila50["sValor"] = -1;
				fila50["sLiteral"] = "Todos";
				tabla1.Rows.Add(fila50);
				DataRow fila51 = tabla1.NewRow();
				fila51["sValor"] = 0;
				fila51["sLiteral"] = "NO";
				tabla1.Rows.Add(fila51);
				DataRow fila52 = tabla1.NewRow();
				fila52["sValor"] = 1;
				fila52["sLiteral"] = "SI";
				tabla1.Rows.Add(fila52);

				this.cbBolsaViaje.DataSource = tabla1;
				this.cbBolsaViaje.ValueMember = "sValor";
				this.cbBolsaViaje.DisplayMember = "sLiteral";
				this.cbBolsaViaje.SelectedValue = -1;
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}

		}
		#endregion

		#region Inicializar_Fechas
		private void Inicializar_Fechas()
		{
			try
			{
				this.dtpFechaCreacionIni.Value = DateTime.Parse("01/01/"+DateTime.Today.Year.ToString());
				this.dtpFechaCreacionFin.Value = DateTime.Parse("31/12/"+ (DateTime.Today.Year + 1) );
				this.dtpFechaPrevIni.Value = DateTime.Parse("01/01/"+DateTime.Today.Year.ToString());
				this.dtpFechaPrevFin.Value = DateTime.Parse("31/12/"+ (DateTime.Today.Year + 1) );
				this.dtpFechaAprob1Ini.Value = DateTime.Parse("01/01/"+DateTime.Today.Year.ToString());
				this.dtpFechaAprob1Fin.Value = DateTime.Parse("31/12/"+ (DateTime.Today.Year + 1) );
				this.dtpFechaAprob2Ini.Value = DateTime.Parse("01/01/"+DateTime.Today.Year.ToString());
				this.dtpFechaAprob2Fin.Value = DateTime.Parse("31/12/"+ (DateTime.Today.Year + 1) );
				this.dtpFechaAprob3Ini.Value = DateTime.Parse("01/01/"+DateTime.Today.Year.ToString());
				this.dtpFechaAprob3Fin.Value = DateTime.Parse("31/12/"+ (DateTime.Today.Year + 1) );
				this.dtpFechaAprob4Ini.Value = DateTime.Parse("01/01/"+DateTime.Today.Year.ToString());
				this.dtpFechaAprob4Fin.Value = DateTime.Parse("31/12/"+ (DateTime.Today.Year + 1) );
				this.dtpFechaRealIni.Value = DateTime.Parse("01/01/"+DateTime.Today.Year.ToString());
				this.dtpFechaRealFin.Value = DateTime.Parse("31/12/"+ (DateTime.Today.Year + 1) );
				this.dtpFechaLiqIni.Value = DateTime.Parse("01/01/"+DateTime.Today.Year.ToString());
				this.dtpFechaLiqFin.Value = DateTime.Parse("31/12/"+ (DateTime.Today.Year + 1) );
				this.dtpFechaCierreIni.Value = DateTime.Parse("01/01/"+DateTime.Today.Year.ToString());
				this.dtpFechaCierreFin.Value = DateTime.Parse("31/12/"+ (DateTime.Today.Year + 1) );

				this.dtpFReportIni.Value = DateTime.Parse("01/01/"+DateTime.Today.Year.ToString());
				this.dtpFReportFin.Value = DateTime.Parse("31/12/"+ (DateTime.Today.Year + 1) );

			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region Inicializar_DataGrid
		private void Inicializar_DataGrid()
		{
			try
			{
				Utiles.Formatear_DgConFilabEnviadoCEN(this.dgAtenciones,null,this.cntxMnuAtenciones);
				for(int i=0;i<this.dgAtenciones.TableStyles[0].GridColumnStyles.Count;i++)
				{
					DataGridTextBoxColumn TextCol0 = (DataGridTextBoxColumn)this.dgAtenciones.TableStyles[0].GridColumnStyles[i];
					TextCol0.TextBox.DoubleClick += new EventHandler(dgAtenciones_DoubleClick);
				}

				Utiles.Formatear_DataGrid(this,this.dgAtencionesClientes,"C",true);
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

				if(Configuracion.iGAtenciones==0)
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


		#region btSalir_Click
		private void btSalir_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
		#endregion

		#region frmConsultaAtenciones_Closed
		private void frmConsultaAtenciones_Closed(object sender, System.EventArgs e)
		{
			this.Dispose();
		}
		#endregion

		#region btNuevo_Click
		private void btNuevo_Click(object sender, System.EventArgs e)
		{
			Nueva_Atencion();
		}
		#endregion 

		#region btEditar_Click
		private void btEditar_Click(object sender, System.EventArgs e)
		{
			Editar_Atencion();
		}
		#endregion 

		#region btEliminar_Click
		private void btEliminar_Click(object sender, System.EventArgs e)
		{
			Eliminar_Atencion();
		}
		#endregion

		#region menuNuevo_Click
		private void menuNuevo_Click(object sender, System.EventArgs e)
		{
			Nueva_Atencion();
		}
		#endregion 

		#region menuEditar_Click
		private void menuEditar_Click(object sender, System.EventArgs e)
		{
			Editar_Atencion();
		}
		#endregion 

		#region menuEliminar_Click
		private void menuEliminar_Click(object sender, System.EventArgs e)
		{
			Eliminar_Atencion();
		}
		#endregion


		#region Nueva_Atencion
		private void Nueva_Atencion()
		{
			try
			{
				if(GESTCRM.Clases.Configuracion.iGAtenciones==0)
				{
					if(int.Parse(this.cboDelegado.SelectedValue.ToString())== GESTCRM.Clases.Configuracion.iIdDelegado)
					{
						bool abierto=false;

						if(this.ParentForm == null) abierto=Utiles.MirarSiFormAbierto("frmAtenciones",this.Owner);
						else abierto = Utiles.MirarSiFormAbierto("frmAtenciones",this.ParentForm);

						if (!abierto)
						{
							Form frmTemp=new Formularios.frmAtenciones("A",-1,Configuracion.iIdDelegado);
							frmTemp.MdiParent=this.ParentForm;
							frmTemp.Show();
							Realizar_Busqueda();
						}
						else
						{
							DialogResult dr=Mensajes.ShowQuestion("No se puede crear una Atención porque ya hay uno abierta. ¿Desea ver la Atención abierta?.");
							if(dr==System.Windows.Forms.DialogResult.Yes)
							{
								GESTCRM.Utiles.ActivaFormularioAbierto("frmAtenciones",this.MdiParent);
								Realizar_Busqueda();
							}
						}
					}
					else
					{
						GESTCRM.Mensajes.ShowError(4000);//Sólo crear Atenciones propias
					}
				}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}

		}
		#endregion

		#region Editar_Atencion
		private void Editar_Atencion()
		{
			try
			{
				if(this.dgAtenciones.CurrentRowIndex!=-1)
				{
					string Acceso="M";
					bool abierto=false;
					string TipoAtencion = this.dgAtenciones[this.Var_fila,5].ToString();

					if(TipoAtencion=="2")//Sólo se tiene acceso a atenciones manuales
					{
						int iIdDelegado = Int32.Parse(this.dgAtenciones[this.Var_fila,1].ToString());

						if(iIdDelegado!= GESTCRM.Clases.Configuracion.iIdDelegado) //el delegado creador no es el mismo que el que está usando la aplicación
						{
							this.dsAtenciones1.GetCargoDelegado.Rows.Clear();
							this.sqldaGetCargoDelegado.SelectCommand.Parameters["@iIdDelegado"].Value = Configuracion.iIdDelegado;
							this.sqldaGetCargoDelegado.Fill(this.dsAtenciones1);
							if(this.dsAtenciones1.GetCargoDelegado.Rows.Count==1)
							{
								int Cargo = Int32.Parse(this.dsAtenciones1.GetCargoDelegado.Rows[0]["iIdCargo"].ToString());
								//el cargo del delegado que está usando la aplicación debe ser 
								//un cargo aprobador de Atenciones, sinó el acceso es de consulta
								if(Cargo!= Configuracion.iCargoAprob1 && Cargo != Configuracion.iCargoAprob2)
								{
									Acceso="C";
								}
							}
							else// sinó se puede determinar el cargo
							{
								Acceso="C";
							}
						}

						if(GESTCRM.Clases.Configuracion.iGAtenciones>0) Acceso="C";//No tiene acceso de escritura

						if(this.ParentForm == null) abierto=Utiles.MirarSiFormAbierto("frmAtenciones",this.Owner);
						else abierto = Utiles.MirarSiFormAbierto("frmAtenciones",this.ParentForm);

						if (!abierto)
						{
							Form frmTemp=new Formularios.frmAtenciones(Acceso,this.Var_iIdAtencion,GESTCRM.Clases.Configuracion.iIdDelegado);
							frmTemp.MdiParent=this.ParentForm;
							frmTemp.Show();
							Realizar_Busqueda();
						}
						else
						{
							DialogResult dr=Mensajes.ShowQuestion("No se puede modificar una Atención porque ya hay una abierta. ¿Desea ver la Atención abierta?.");
							if(dr==System.Windows.Forms.DialogResult.Yes)
							{
								GESTCRM.Utiles.ActivaFormularioAbierto("frmAtenciones",this.MdiParent);
								Realizar_Busqueda();
							}
						}
					}
					else
					{
						GESTCRM.Mensajes.ShowError("No se puede acceder a Atenciones Comerciales que sean de Tipo Permanente");
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
				if(this.dgAtenciones.CurrentRowIndex!=-1)
				{
					string sMensj="";
					bool borrado = false;
					int bEnviadoCEN = int.Parse(this.dgAtenciones[this.Var_fila,2].ToString());
					string TipoAtencion = this.dgAtenciones[this.Var_fila,5].ToString();

					if(GESTCRM.Clases.Configuracion.iGAtenciones==0)//tiene acceso de escritura
					{
						if(TipoAtencion == "2") //Sólo Manuales
						{
							int iIdDelegado = Int32.Parse(this.dgAtenciones[this.Var_fila,1].ToString());
							if(bEnviadoCEN==0)//no se ha enviado a Central
							{
								DialogResult dr=Mensajes.ShowQuestion("¿Desea borrar el registro?");
								if(dr == System.Windows.Forms.DialogResult.Yes)
								{
									if(iIdDelegado== GESTCRM.Clases.Configuracion.iIdDelegado)//el delegado que usa la aplicación es el creador de la atención
									{
										bool abierto=false;

										if(this.ParentForm == null) abierto=Utiles.MirarSiFormAbierto("frmAtenciones",this.Owner);
										else abierto = Utiles.MirarSiFormAbierto("frmAtenciones",this.ParentForm);

										if(!abierto)
										{
											if(this.dgAtenciones.CurrentRowIndex>-1)
											{
												int iIdAtencion=Int32.Parse(this.dgAtenciones[this.dgAtenciones.CurrentRowIndex,0].ToString());
												string sIdEstAtencion = this.dgAtenciones[this.dgAtenciones.CurrentRowIndex,7].ToString();
												//si el estado es Creada,Aprobada2,Realizada o Liquidada puede borrar
												if(sIdEstAtencion =="0" || sIdEstAtencion == "2" || sIdEstAtencion == "3" || sIdEstAtencion == "4")
												{
													//Borrar
													this.sqlConn.Open();
													try
													{
														this.sqlCmdSetAtencionesComerciales.Parameters["@iIdAtencion"].Value=iIdAtencion;
														this.sqlCmdSetAtencionesComerciales.Parameters["@iAccion"].Value=2;
								
														this.sqlCmdSetAtencionesComerciales.ExecuteNonQuery();

														Mensajes.ShowInformation("Se ha eliminado la Atención");
														borrado=true;

													}
													catch(System.Data.SqlClient.SqlException ex)
													{
														sMensj ="Error al eliminar Atención Comercial: ";
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
												else //else de mirar estado de la Atención
												{
													GESTCRM.Mensajes.ShowError("No se pueden borrar Atenciones Comerciales en este estado");
												}
											}
										}
										else // else de mirar si abierto Formulario
										{
											DialogResult dr1=Mensajes.ShowQuestion("No se puede eliminar una Atención porque hay uno abierta. ¿Desea ver la Atención abierta?.");
											if(dr1==System.Windows.Forms.DialogResult.Yes)
											{
												GESTCRM.Utiles.ActivaFormularioAbierto("frmAtenciones",this.MdiParent);
											}
										}
									}
									else //else del Delegado
									{
										GESTCRM.Mensajes.ShowError("No se pueden borrar Atenciones Comerciales de otro delegado");//Sólo modificar Atenciones propios
									}
								}
								else //else del bEnviadoCEN
								{
									GESTCRM.Mensajes.ShowError("No se pueden borrar Atenciones Comerciales que estan Enviadas a Central");
								}
							}
						}
						else//else del Tipo de Atención
						{
							GESTCRM.Mensajes.ShowError("No se pueden borrar Atenciones Comerciales que sean de Tipo Permanente");
						}
					}
				}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}

		#endregion

		

		#region cboDelegado_Leave
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
		#endregion

		#region cboEstado_Leave
		private void cboEstado_Leave(object sender, System.EventArgs e)
		{
			try
			{
				if(this.cboEstado.SelectedIndex == -1)
				{
					this.cboEstado.SelectedValue = "-1";
				}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region cbTipoAtencion_Leave
		private void cbTipoAtencion_Leave(object sender, System.EventArgs e)
		{
			try
			{
				if(this.cbTipoAtencion.SelectedIndex == -1)
				{
					this.cbTipoAtencion.SelectedValue = "-1";
				}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region cbBolsaViaje_Leave
		private void cbBolsaViaje_Leave(object sender, System.EventArgs e)
		{
			try
			{
				if(this.cbBolsaViaje.SelectedIndex == -1)
				{
					this.cbBolsaViaje.SelectedValue = "-1";
				}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region txtsIdCliente_Leave
		private void txtsIdCliente_Leave(object sender, System.EventArgs e)
		{
			try
			{
				GESTCRM.Formularios.Busquedas.frmMClientesSAP frmBCli = new GESTCRM.Formularios.Busquedas.frmMClientesSAP(false,"A");
				
				frmBCli.ParamI_iIdDelegado = Int32.Parse(this.cboDelegado.SelectedValue.ToString());
				frmBCli.ParamI_sIdCentro= "";
				frmBCli.ParamI_sIdTipoCliente="T";
				frmBCli.ParamIO_sIdCliente = this.txtsIdCliente.Text.ToString();
				
				frmBCli.Buscar_tNombre();
				
				if(this.txtsIdCliente.Text.ToString().Length>0 && frmBCli.ParamO_iIdCliente==-1) Mensajes.ShowError("Este código de Cliente no existe.");
				this.txtsIdCliente.Text=frmBCli.ParamIO_sIdCliente;
				this.txtsCliente.Text=frmBCli.ParamO_tNombre;
				this.Var_iIdCliente = frmBCli.ParamO_iIdCliente;

				frmBCli.Dispose();
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region btBuscarCliente_Click
		private void btBuscarCliente_Click(object sender, System.EventArgs e)
		{
			try
			{
				GESTCRM.Formularios.Busquedas.frmMClientesSAP frmBCli = new GESTCRM.Formularios.Busquedas.frmMClientesSAP(false,"A");
				
				frmBCli.ParamIO_sIdCliente = "";
				frmBCli.ParamI_sIdCentro = "";
				frmBCli.ParamI_sIdTipoCliente="T";
				frmBCli.ParamI_iIdDelegado = Int32.Parse(this.cboDelegado.SelectedValue.ToString());

				frmBCli.ShowDialog(this);
				if (frmBCli.DialogResult==System.Windows.Forms.DialogResult.OK)
				{
					if(frmBCli.dtSeleccion.Rows.Count==0)
					{
						this.txtsIdCliente.Text=frmBCli.ParamIO_sIdCliente;
						this.txtsCliente.Text = frmBCli.ParamO_tNombre;
						this.Var_iIdCliente = frmBCli.ParamO_iIdCliente;
					}
				}
				frmBCli.Dispose();
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region ComboBox_SetectedIndexChanged
		private void ComboBox_SetectedIndexChanged(object sender, System.EventArgs e)
		{
			BorraDatosBusqueda();
		}		
		#endregion

		#region Texto_TextChanged
		private void Texto_TextChanged(object sender, System.EventArgs e)
		{
			BorraDatosBusqueda();
		}		
		#endregion

		#region dtpFechaBuscar_ValueChanged
		private void dtpFechaBuscar_ValueChanged(object sender, System.EventArgs e)
		{
			BorraDatosBusqueda();
		}		
		#endregion



		// Borra los Grids y cajas de texto cuando se hace algún cambio sobre los criterios de búsqueda
		#region BorraDatosBusqueda
		private void BorraDatosBusqueda()
		{
			try
			{
				this.dsAtenciones1.ListaAtencionesComerciales.Clear();
				this.dsAtenciones1.ListaAtencionesClientes.Clear();
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region btnBuscar_Click
		private void btnBuscar_Click(object sender, System.EventArgs e)
		{
			Realizar_Busqueda();
		}
		#endregion

		#region Realizar_Busqueda
		private void Realizar_Busqueda()
		{
			Cursor.Current = Cursors.WaitCursor;
			try
			{
				this.dsAtenciones1.ListaAtencionesComerciales.Rows.Clear();

				//Poner a nulo todos los parámetros
				for(int i=1;i<this.sqldaListaAtencionesComerciales.SelectCommand.Parameters.Count;i++)
				{
					this.sqldaListaAtencionesComerciales.SelectCommand.Parameters[i].Value = DBNull.Value;
				}
				this.sqldaListaAtencionesComerciales.SelectCommand.Parameters["@iIdDelegado"].Value = Int32.Parse(this.cboDelegado.SelectedValue.ToString());
				if(this.txtsIdAtencion.Text.ToString().Length>0)
				{
					this.sqldaListaAtencionesComerciales.SelectCommand.Parameters["@sIdAtencion"].Value = this.txtsIdAtencion.Text.ToString();
				}
				this.sqldaListaAtencionesComerciales.SelectCommand.Parameters["@sIdTipoAtencion"].Value = this.cbTipoAtencion.SelectedValue.ToString();
				this.sqldaListaAtencionesComerciales.SelectCommand.Parameters["@sIdEstAtencion"].Value = this.cboEstado.SelectedValue.ToString();
				this.sqldaListaAtencionesComerciales.SelectCommand.Parameters["@bBolsaViaje"].Value = this.cbBolsaViaje.SelectedValue.ToString();
				try{this.sqldaListaAtencionesComerciales.SelectCommand.Parameters["@dFechaCreacionIni"].Value = DateTime.Parse(this.dtpFechaCreacionIni.Value.ToString("dd/MM/yyyy"));}
				catch{}
				try{this.sqldaListaAtencionesComerciales.SelectCommand.Parameters["@dFechaPrevIni"].Value = DateTime.Parse(this.dtpFechaPrevIni.Value.ToString("dd/MM/yyyy"));}
				catch{}
				try{this.sqldaListaAtencionesComerciales.SelectCommand.Parameters["@dFechaAprob1Ini"].Value = DateTime.Parse(this.dtpFechaAprob1Ini.Value.ToString("dd/MM/yyyy"));}
				catch{}
				try{this.sqldaListaAtencionesComerciales.SelectCommand.Parameters["@dFechaAprob2Ini"].Value = DateTime.Parse(this.dtpFechaAprob2Ini.Value.ToString("dd/MM/yyyy"));}
				catch{}
				try{this.sqldaListaAtencionesComerciales.SelectCommand.Parameters["@dFechaAprob3Ini"].Value = DateTime.Parse(this.dtpFechaAprob3Ini.Value.ToString("dd/MM/yyyy"));}
				catch{}
				try{this.sqldaListaAtencionesComerciales.SelectCommand.Parameters["@dFechaAprob4Ini"].Value = DateTime.Parse(this.dtpFechaAprob4Ini.Value.ToString("dd/MM/yyyy"));}
				catch{}
				try{this.sqldaListaAtencionesComerciales.SelectCommand.Parameters["@dFechaRealIni"].Value = DateTime.Parse(this.dtpFechaRealIni.Value.ToString("dd/MM/yyyy"));}
				catch{}
				try{this.sqldaListaAtencionesComerciales.SelectCommand.Parameters["@dFechaLiqIni"].Value = DateTime.Parse(this.dtpFechaLiqIni.Value.ToString("dd/MM/yyyy"));}
				catch{}
				try{this.sqldaListaAtencionesComerciales.SelectCommand.Parameters["@dFechaCierreIni"].Value = DateTime.Parse(this.dtpFechaCierreIni.Value.ToString("dd/MM/yyyy"));}
				catch{}
				try{this.sqldaListaAtencionesComerciales.SelectCommand.Parameters["@dFechaCreacionFin"].Value = DateTime.Parse(this.dtpFechaCreacionFin.Value.ToString("dd/MM/yyyy"));}
				catch{}
				try{this.sqldaListaAtencionesComerciales.SelectCommand.Parameters["@dFechaPrevFin"].Value = DateTime.Parse(this.dtpFechaPrevFin.Value.ToString("dd/MM/yyyy"));}
				catch{}
				try{this.sqldaListaAtencionesComerciales.SelectCommand.Parameters["@dFechaAprob1Fin"].Value = DateTime.Parse(this.dtpFechaAprob1Fin.Value.ToString("dd/MM/yyyy"));}
				catch{}
				try{this.sqldaListaAtencionesComerciales.SelectCommand.Parameters["@dFechaAprob2Fin"].Value = DateTime.Parse(this.dtpFechaAprob2Fin.Value.ToString("dd/MM/yyyy"));}
				catch{}
				try{this.sqldaListaAtencionesComerciales.SelectCommand.Parameters["@dFechaAprob3Fin"].Value = DateTime.Parse(this.dtpFechaAprob3Fin.Value.ToString("dd/MM/yyyy"));}
				catch{}
				try{this.sqldaListaAtencionesComerciales.SelectCommand.Parameters["@dFechaAprob4Fin"].Value = DateTime.Parse(this.dtpFechaAprob4Fin.Value.ToString("dd/MM/yyyy"));}
				catch{}
				try{this.sqldaListaAtencionesComerciales.SelectCommand.Parameters["@dFechaRealFin"].Value = DateTime.Parse(this.dtpFechaRealFin.Value.ToString("dd/MM/yyyy"));}
				catch{}
				try{this.sqldaListaAtencionesComerciales.SelectCommand.Parameters["@dFechaLiqFin"].Value = DateTime.Parse(this.dtpFechaLiqFin.Value.ToString("dd/MM/yyyy"));}
				catch{}
				try{this.sqldaListaAtencionesComerciales.SelectCommand.Parameters["@dFechaCierreFin"].Value = DateTime.Parse(this.dtpFechaCierreFin.Value.ToString("dd/MM/yyyy"));}
				catch{}
				this.sqldaListaAtencionesComerciales.SelectCommand.Parameters["@iIdCliente"].Value = this.Var_iIdCliente;

			

				this.sqldaListaAtencionesComerciales.Fill(this.dsAtenciones1);
				this.lblNumRegAtenciones.Text = this.dsAtenciones1.ListaAtencionesComerciales.Rows.Count.ToString();
				if(this.dsAtenciones1.ListaAtencionesComerciales.Rows.Count>0)
				{
					this.Var_iIdAtencion = Int32.Parse(this.dgAtenciones[0,0].ToString());
					this.Var_fila=0;
					Utiles.Seleccionar_UnaFilaDataGrid(this,this.dgAtenciones,0);
					this.pnDatosAtencion.Visible=true;
					Cargar_dgAtencionesClientes();
				}
				else
				{
					this.pnDatosAtencion.Visible=false;
					this.Var_iIdAtencion=-1;
					this.Var_fila=-1;
				}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
			Cursor.Current = Cursors.Default;
		}
		#endregion


		#region dgAtenciones_DoubleClick
		private void dgAtenciones_DoubleClick(object sender, System.EventArgs e)
		{
			Editar_Atencion();
		}
		#endregion

		#region dgAtenciones_CurrentCellChanged
		private void dgAtenciones_CurrentCellChanged(object sender, System.EventArgs e)
		{
			try
			{
				if(this.dgAtenciones.CurrentRowIndex>-1)
				{
					int fila = this.dgAtenciones.CurrentRowIndex;
					Utiles.Seleccionar_UnaFilaDataGrid(this,this.dgAtenciones,fila);
					this.Var_iIdAtencion = Int32.Parse(this.dgAtenciones[fila,0].ToString());
					this.Var_fila= fila;
				}
				else
				{
					this.Var_iIdAtencion = -1;
					this.Var_fila= -1;
				}
				Cargar_dgAtencionesClientes();
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region Cargar_dgAtencionesClientes
		private void Cargar_dgAtencionesClientes()
		{
			try
			{
				this.dsAtenciones1.ListaAtencionesClientes.Clear();
				this.sqldaAtencionesClientes.SelectCommand.Parameters["@iIdAtencion"].Value = this.Var_iIdAtencion;
				try{this.sqldaAtencionesClientes.SelectCommand.Parameters["@dFReportIni"].Value = DateTime.Parse(this.dtpFReportIni.Value.ToString("dd/MM/yyyy"));}
				catch{}
				try{this.sqldaAtencionesClientes.SelectCommand.Parameters["@dFReportFin"].Value = DateTime.Parse(this.dtpFReportFin.Value.ToString("dd/MM/yyyy"));}
				catch{}
				this.sqldaAtencionesClientes.Fill(this.dsAtenciones1);
				this.lblNumRegClientes.Text = this.dsAtenciones1.ListaAtencionesClientes.Rows.Count.ToString();
				if(this.dsAtenciones1.ListaAtencionesClientes.Rows.Count>0)
				{
					Utiles.Seleccionar_UnaFilaDataGrid(this,this.dgAtencionesClientes,0);
				}
				if(this.dgAtenciones[this.Var_fila,5].ToString()=="1")//Permanente
				{
					this.pnClienteManual.Visible=false;
					this.pnClientesPermanente.Visible=true;
				}
				else
				{
					this.pnClienteManual.Visible=true;
					this.pnClientesPermanente.Visible=false;
				}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region btBuscarAtenCli_Click
		private void btBuscarAtenCli_Click(object sender, System.EventArgs e)
		{
			Cargar_dgAtencionesClientes();
		}
		#endregion

		#region dtpFechaReport_ValueChanged
		private void dtpFechaReport_ValueChanged(object sender, System.EventArgs e)
		{
			try
			{
				this.dsAtenciones1.ListaAtencionesClientes.Clear();
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}		
		#endregion

		#region dgAtencionesClientes_CurrentCellChanged
		private void dgAtencionesClientes_CurrentCellChanged(object sender, System.EventArgs e)
		{
			try
			{
				Utiles.Seleccionar_UnaFilaDataGrid(this,this.dgAtencionesClientes,this.dgAtencionesClientes.CurrentRowIndex);
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion



	}
}
