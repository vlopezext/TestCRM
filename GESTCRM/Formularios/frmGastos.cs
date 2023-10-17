using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using GESTCRM.Controles;
using GESTCRM.Clases;

namespace GESTCRM.Formularios
{
	/// <summary>
	/// Formulario para el tratamiento de las Notas de Gasto.
	/// </summary>
	public class frmGastos : System.Windows.Forms.Form
	{
		//Guardan el valor pasado como parámetro
		private string		ParamTipoAcceso;	//Tipo de acceso al formulario A:Alta, M:Modificación, C:Consulta
		private int			ParamIdNota;		//Identificador de Nota, sólo en Modificaciones y Consultas
		private DateTime	ParamFecha;			//sólo en Altas 
		private string		ParamsFecha;			//sólo en Altas 
		private int			ParamiIdDelegado;	//Identificador de delegado
		
		private DataTable dtAtenCom;
		private DataTable dtRutas;
		private DataTable dtLineasGasto;
        //---- GSG (26/03/2012)
        private DataTable dtLineasViewGasto; 
        private double DefaultImportValue = 0.0;
        private int DefaultCantidadValue = 0;        
        private bool SetDefault = false;
        private bool bBorrando = false;
        //---- FI GSG

		private bool Var_CambioFecha;
		private bool SalirDesdeGuardar;

		private double TotalAtts = 0;
		private int ResultadoKms = 0;
		private double TotalLineas = 0;
		private double TotalImporte = 0;
		private int	bEnviadoCEN = 0;

		protected System.Data.SqlClient.SqlTransaction sqlTran;

		private System.Windows.Forms.Panel pnlNGasto;
		private System.Windows.Forms.Label lblDelegado;
		private System.Windows.Forms.ToolTip toolTipNotasGasto;
		private System.Windows.Forms.Label lblFecha;
		private System.Windows.Forms.CheckBox chkVisa;
		private System.Windows.Forms.DateTimePicker dtpFecha;
		private System.Windows.Forms.Label lblFechaArpob;
		private System.Windows.Forms.Label lblFechaLiq;
		private System.Windows.Forms.ComboBox cboGasto;
		private System.Windows.Forms.Label lblGasto;
		private System.Windows.Forms.Label lblCantidad;
		private System.Windows.Forms.NumericUpDown nmrCantidad;
		private System.Windows.Forms.Label lblPrecio;
		private System.Windows.Forms.Label lblDesc;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txbDescrip;
		private System.Data.SqlClient.SqlConnection sqlConn;
		private System.Windows.Forms.DataGrid dtgLineasNotasDeGasto;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn5;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn6;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn7;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn8;		
		private System.Data.SqlClient.SqlCommand sqlCmdSetNotasGastos;
		private System.Data.SqlClient.SqlCommand sqlCmdSetNotasDeGastosLineas;
		private System.Data.SqlClient.SqlCommand sqlCmdSetAtencionesNotasGasto;
		private System.Windows.Forms.ContextMenu cntMenu;
		private System.Windows.Forms.Panel pnlLineasGasto;
		private System.Windows.Forms.TextBox txtObservaciones;		
		private System.Windows.Forms.DataGrid dtgAtencionesCom;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn9;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn12;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn10;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.CheckedListBox chkListBoxRutas;
		private System.Windows.Forms.Label lbltotalKms;
		private System.Windows.Forms.Label lblKms;
		private System.Data.SqlClient.SqlCommand sqlCmdSetRutasNotasGastos;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn11;
		private System.Windows.Forms.Label lblTotalAtts;
		private System.Windows.Forms.Label lblLineas;
		private GESTCRM.Controles.ucBotoneraSecundaria ucBotoneraSecundaria1;
		private GESTCRM.Controles.LabelGradient labelGradient1;
		private GESTCRM.Controles.LabelGradient labelGradient3;
		private GESTCRM.Controles.LabelGradient lblGNotasGasto;
		private GESTCRM.Controles.LabelGradient labelGradient4;
		private GESTCRM.Controles.LabelGradient labelGradient2;
		private GESTCRM.Controles.LabelGradient labelGradient5;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox cboCCoste;
		private System.Windows.Forms.Label lblCCoste;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn13;
		private GESTCRM.Controles.LabelGradient labelGradient8;
		private System.Data.SqlClient.SqlDataAdapter sqldaGetNotaGastos;
		private System.Windows.Forms.TextBox txtNombreDelegado;
		private System.Windows.Forms.TextBox txtFechaAprob;
		private System.Windows.Forms.TextBox txtFechaLIq;
		private System.Data.SqlClient.SqlDataAdapter sqldaGetExisteNotaGastos;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand5;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand4;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand9;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		private GESTCRM.Formularios.DataSets.dsGastos dsGastos1;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		private System.Data.SqlClient.SqlDataAdapter sqldaListaGastos;
		private System.Data.SqlClient.SqlDataAdapter sqldaLineasGasto;
		private System.Data.SqlClient.SqlDataAdapter sqldaListaRutasNotasGasto;
		private System.Data.SqlClient.SqlDataAdapter sqldaListaRutas;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand8;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand6;
		private System.Windows.Forms.NumericUpDown nupPrecio;
		private System.Windows.Forms.MenuItem menuNuevaLinea;
		private System.Windows.Forms.MenuItem menuEliminarLinea;
		private System.Windows.Forms.Button btActualizarLinea;
		private System.Windows.Forms.Button btEliminarLinea;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
		private System.Data.SqlClient.SqlDataAdapter sqldaListaAtenCom;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Label lblTotLineas;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Label lblTotAtenciones;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtImpLinea;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		private GESTCRM.Controles.LabelGradient lblTitulo;
		private System.Windows.Forms.Panel pnDatos;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn14;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn15;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label lblTotImporte;
		private System.Windows.Forms.Label label11;
        private DataGridView dtgViewLineasNotasDeGasto;
        private BindingSource dsGastos1BindingSource;
		private System.Data.SqlClient.SqlDataAdapter sqldaListaCCoste;
        private System.Data.SqlClient.SqlCommand sqlListaLineasNotasGasto; 
        private System.Data.SqlClient.SqlDataAdapter sqldaLineasNotasGasto;
        //---- GSG (23/09/2013)
        private System.Data.SqlClient.SqlDataAdapter sqldaGetFecMaxNota;
        private DataGridViewTextBoxColumn iIdNotaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn iIdGastoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn descripGastoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn sIdCentroCosteDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn sCentroCosteDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn descripLineaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn fCantidadDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn fPrecioDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn importeGastoDataGridViewTextBoxColumn;
        private System.Data.SqlClient.SqlCommand sqlCmdGetFecMaxNota;

		
		public frmGastos(string TipoAcceso, int IdNota,string Fecha,int iIdDelegado)
		{
            InitializeComponent();


            //---- GSG (06/03/2021)
            Utiles.GetConfigConnection();
            this.sqlConn.ConnectionString = Utiles._connection.ConnectionString.ToString();

            
			
			this.ParamTipoAcceso=TipoAcceso;//A-> Alta; M->Modificación; C->Consulta
			this.ParamIdNota=IdNota;		// Identificador de Nota
			this.ParamsFecha=Fecha;			// Fecha Nota, sólo se usa para el alta 
			this.ParamiIdDelegado=iIdDelegado;
            			
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
            System.Configuration.AppSettingsReader configurationAppSettings = new System.Configuration.AppSettingsReader();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGastos));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlNGasto = new System.Windows.Forms.Panel();
            this.lblTotImporte = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtFechaLIq = new System.Windows.Forms.TextBox();
            this.txtFechaAprob = new System.Windows.Forms.TextBox();
            this.txtNombreDelegado = new System.Windows.Forms.TextBox();
            this.lblTitulo = new GESTCRM.Controles.LabelGradient();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblFechaLiq = new System.Windows.Forms.Label();
            this.lblFechaArpob = new System.Windows.Forms.Label();
            this.chkVisa = new System.Windows.Forms.CheckBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblDelegado = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.sqlConn = new System.Data.SqlClient.SqlConnection();
            this.lblGNotasGasto = new GESTCRM.Controles.LabelGradient();
            this.labelGradient1 = new GESTCRM.Controles.LabelGradient();
            this.dtgLineasNotasDeGasto = new System.Windows.Forms.DataGrid();
            this.cntMenu = new System.Windows.Forms.ContextMenu();
            this.menuNuevaLinea = new System.Windows.Forms.MenuItem();
            this.menuEliminarLinea = new System.Windows.Forms.MenuItem();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn13 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn10 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn8 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn7 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn5 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn6 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.toolTipNotasGasto = new System.Windows.Forms.ToolTip(this.components);
            this.btActualizarLinea = new System.Windows.Forms.Button();
            this.btEliminarLinea = new System.Windows.Forms.Button();
            this.pnlLineasGasto = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.txtImpLinea = new System.Windows.Forms.TextBox();
            this.nupPrecio = new System.Windows.Forms.NumericUpDown();
            this.cboCCoste = new System.Windows.Forms.ComboBox();
            this.dsGastos1 = new GESTCRM.Formularios.DataSets.dsGastos();
            this.lblCCoste = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txbDescrip = new System.Windows.Forms.TextBox();
            this.lblDesc = new System.Windows.Forms.Label();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.nmrCantidad = new System.Windows.Forms.NumericUpDown();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.cboGasto = new System.Windows.Forms.ComboBox();
            this.lblGasto = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labelGradient4 = new GESTCRM.Controles.LabelGradient();
            this.sqldaListaGastos = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
            this.sqldaListaAtenCom = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdSetNotasGastos = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdSetNotasDeGastosLineas = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdSetAtencionesNotasGasto = new System.Data.SqlClient.SqlCommand();
            this.sqldaLineasGasto = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand5 = new System.Data.SqlClient.SqlCommand();
            this.dtgAtencionesCom = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn9 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn12 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn14 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn15 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn11 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.sqldaListaRutas = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand6 = new System.Data.SqlClient.SqlCommand();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelGradient8 = new GESTCRM.Controles.LabelGradient();
            this.lblKms = new System.Windows.Forms.Label();
            this.lbltotalKms = new System.Windows.Forms.Label();
            this.chkListBoxRutas = new System.Windows.Forms.CheckedListBox();
            this.labelGradient3 = new GESTCRM.Controles.LabelGradient();
            this.sqldaListaRutasNotasGasto = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand8 = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdSetRutasNotasGastos = new System.Data.SqlClient.SqlCommand();
            this.sqlListaLineasNotasGasto = new System.Data.SqlClient.SqlCommand();
            this.sqldaLineasNotasGasto = new System.Data.SqlClient.SqlDataAdapter();
            this.lblTotalAtts = new System.Windows.Forms.Label();
            this.lblLineas = new System.Windows.Forms.Label();
            this.ucBotoneraSecundaria1 = new GESTCRM.Controles.ucBotoneraSecundaria();
            this.labelGradient2 = new GESTCRM.Controles.LabelGradient();
            this.labelGradient5 = new GESTCRM.Controles.LabelGradient();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.sqldaListaCCoste = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand9 = new System.Data.SqlClient.SqlCommand();
            this.sqldaGetNotaGastos = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqldaGetExisteNotaGastos = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand4 = new System.Data.SqlClient.SqlCommand();
            this.sqldaGetFecMaxNota = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCmdGetFecMaxNota = new System.Data.SqlClient.SqlCommand();
            this.pnDatos = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblTotAtenciones = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dtgViewLineasNotasDeGasto = new System.Windows.Forms.DataGridView();
            this.iIdNotaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iIdGastoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripGastoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sIdCentroCosteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sCentroCosteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripLineaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fCantidadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fPrecioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.importeGastoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsGastos1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblTotLineas = new System.Windows.Forms.Label();
            this.pnlNGasto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgLineasNotasDeGasto)).BeginInit();
            this.pnlLineasGasto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupPrecio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsGastos1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgAtencionesCom)).BeginInit();
            this.panel1.SuspendLayout();
            this.pnDatos.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgViewLineasNotasDeGasto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsGastos1BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlNGasto
            // 
            this.pnlNGasto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnlNGasto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlNGasto.Controls.Add(this.lblTotImporte);
            this.pnlNGasto.Controls.Add(this.label11);
            this.pnlNGasto.Controls.Add(this.txtFechaLIq);
            this.pnlNGasto.Controls.Add(this.txtFechaAprob);
            this.pnlNGasto.Controls.Add(this.txtNombreDelegado);
            this.pnlNGasto.Controls.Add(this.lblTitulo);
            this.pnlNGasto.Controls.Add(this.txtObservaciones);
            this.pnlNGasto.Controls.Add(this.label1);
            this.pnlNGasto.Controls.Add(this.lblFechaLiq);
            this.pnlNGasto.Controls.Add(this.lblFechaArpob);
            this.pnlNGasto.Controls.Add(this.chkVisa);
            this.pnlNGasto.Controls.Add(this.lblFecha);
            this.pnlNGasto.Controls.Add(this.dtpFecha);
            this.pnlNGasto.Controls.Add(this.lblDelegado);
            this.pnlNGasto.Controls.Add(this.label9);
            this.pnlNGasto.Location = new System.Drawing.Point(1, 40);
            this.pnlNGasto.Name = "pnlNGasto";
            this.pnlNGasto.Size = new System.Drawing.Size(1490, 120);
            this.pnlNGasto.TabIndex = 0;
            this.pnlNGasto.TabStop = true;
            // 
            // lblTotImporte
            // 
            this.lblTotImporte.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.lblTotImporte.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotImporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotImporte.ForeColor = System.Drawing.Color.Black;
            this.lblTotImporte.Location = new System.Drawing.Point(803, 76);
            this.lblTotImporte.Name = "lblTotImporte";
            this.lblTotImporte.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblTotImporte.Size = new System.Drawing.Size(104, 26);
            this.lblTotImporte.TabIndex = 47;
            this.lblTotImporte.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(909, 80);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(16, 19);
            this.label11.TabIndex = 48;
            this.label11.Text = "€";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtFechaLIq
            // 
            this.txtFechaLIq.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtFechaLIq.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaLIq.ForeColor = System.Drawing.Color.Black;
            this.txtFechaLIq.Location = new System.Drawing.Point(575, 75);
            this.txtFechaLIq.Name = "txtFechaLIq";
            this.txtFechaLIq.ReadOnly = true;
            this.txtFechaLIq.Size = new System.Drawing.Size(100, 26);
            this.txtFechaLIq.TabIndex = 34;
            this.txtFechaLIq.TabStop = false;
            // 
            // txtFechaAprob
            // 
            this.txtFechaAprob.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtFechaAprob.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaAprob.ForeColor = System.Drawing.Color.Black;
            this.txtFechaAprob.Location = new System.Drawing.Point(328, 73);
            this.txtFechaAprob.Name = "txtFechaAprob";
            this.txtFechaAprob.ReadOnly = true;
            this.txtFechaAprob.Size = new System.Drawing.Size(98, 26);
            this.txtFechaAprob.TabIndex = 33;
            this.txtFechaAprob.TabStop = false;
            // 
            // txtNombreDelegado
            // 
            this.txtNombreDelegado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtNombreDelegado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreDelegado.ForeColor = System.Drawing.Color.Black;
            this.txtNombreDelegado.Location = new System.Drawing.Point(103, 32);
            this.txtNombreDelegado.Name = "txtNombreDelegado";
            this.txtNombreDelegado.ReadOnly = true;
            this.txtNombreDelegado.Size = new System.Drawing.Size(312, 26);
            this.txtNombreDelegado.TabIndex = 32;
            this.txtNombreDelegado.TabStop = false;
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
            this.lblTitulo.Size = new System.Drawing.Size(1488, 22);
            this.lblTitulo.TabIndex = 31;
            this.lblTitulo.Text = "Notas de Gasto";
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.BackColor = System.Drawing.Color.White;
            this.txtObservaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObservaciones.ForeColor = System.Drawing.Color.Black;
            this.txtObservaciones.Location = new System.Drawing.Point(1042, 32);
            this.txtObservaciones.MaxLength = 8000;
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObservaciones.Size = new System.Drawing.Size(430, 80);
            this.txtObservaciones.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(917, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 22);
            this.label1.TabIndex = 25;
            this.label1.Text = "Observaciones:";
            // 
            // lblFechaLiq
            // 
            this.lblFechaLiq.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblFechaLiq.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaLiq.ForeColor = System.Drawing.Color.Black;
            this.lblFechaLiq.Location = new System.Drawing.Point(433, 77);
            this.lblFechaLiq.Name = "lblFechaLiq";
            this.lblFechaLiq.Size = new System.Drawing.Size(142, 22);
            this.lblFechaLiq.TabIndex = 14;
            this.lblFechaLiq.Text = "Fecha Liquidación:";
            // 
            // lblFechaArpob
            // 
            this.lblFechaArpob.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblFechaArpob.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaArpob.ForeColor = System.Drawing.Color.Black;
            this.lblFechaArpob.Location = new System.Drawing.Point(183, 75);
            this.lblFechaArpob.Name = "lblFechaArpob";
            this.lblFechaArpob.Size = new System.Drawing.Size(143, 22);
            this.lblFechaArpob.TabIndex = 12;
            this.lblFechaArpob.Text = "Fecha Aprobación:";
            // 
            // chkVisa
            // 
            this.chkVisa.Enabled = false;
            this.chkVisa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkVisa.ForeColor = System.Drawing.Color.Black;
            this.chkVisa.Location = new System.Drawing.Point(946, 79);
            this.chkVisa.Name = "chkVisa";
            this.chkVisa.Size = new System.Drawing.Size(79, 22);
            this.chkVisa.TabIndex = 8;
            this.chkVisa.TabStop = false;
            this.chkVisa.Text = "Visa";
            // 
            // lblFecha
            // 
            this.lblFecha.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.ForeColor = System.Drawing.Color.Black;
            this.lblFecha.Location = new System.Drawing.Point(16, 73);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(58, 20);
            this.lblFecha.TabIndex = 7;
            this.lblFecha.Text = "Fecha:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(75, 71);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(100, 26);
            this.dtpFecha.TabIndex = 0;
            this.dtpFecha.CloseUp += new System.EventHandler(this.dtpFecha_CloseUp);
            this.dtpFecha.Leave += new System.EventHandler(this.dtpFecha_Leave);
            // 
            // lblDelegado
            // 
            this.lblDelegado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblDelegado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDelegado.ForeColor = System.Drawing.Color.Black;
            this.lblDelegado.Location = new System.Drawing.Point(16, 33);
            this.lblDelegado.Name = "lblDelegado";
            this.lblDelegado.Size = new System.Drawing.Size(87, 16);
            this.lblDelegado.TabIndex = 1;
            this.lblDelegado.Text = "Delegado:";
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(675, 78);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(129, 21);
            this.label9.TabIndex = 49;
            this.label9.Text = "Total Imp. Nota:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sqlConn
            // 
            this.sqlConn.ConnectionString = Utiles._connection.ConnectionString.ToString();   //---- GSG (06/03/2021)
            this.sqlConn.FireInfoMessageEventOnUserErrors = false;
            // 
            // lblGNotasGasto
            // 
            this.lblGNotasGasto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGNotasGasto.ForeColor = System.Drawing.Color.White;
            this.lblGNotasGasto.GradientColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.lblGNotasGasto.GradientColorTwo = System.Drawing.Color.White;
            this.lblGNotasGasto.Location = new System.Drawing.Point(0, 0);
            this.lblGNotasGasto.Name = "lblGNotasGasto";
            this.lblGNotasGasto.Size = new System.Drawing.Size(744, 22);
            this.lblGNotasGasto.TabIndex = 31;
            this.lblGNotasGasto.Text = "Notas de Gasto";
            this.lblGNotasGasto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelGradient1
            // 
            this.labelGradient1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGradient1.ForeColor = System.Drawing.Color.White;
            this.labelGradient1.GradientColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.labelGradient1.GradientColorTwo = System.Drawing.Color.White;
            this.labelGradient1.Location = new System.Drawing.Point(336, 16);
            this.labelGradient1.Name = "labelGradient1";
            this.labelGradient1.Size = new System.Drawing.Size(100, 22);
            this.labelGradient1.TabIndex = 31;
            this.labelGradient1.Text = "labelGradient1";
            // 
            // dtgLineasNotasDeGasto
            // 
            this.dtgLineasNotasDeGasto.AlternatingBackColor = System.Drawing.Color.White;
            this.dtgLineasNotasDeGasto.BackColor = System.Drawing.Color.White;
            this.dtgLineasNotasDeGasto.BackgroundColor = System.Drawing.Color.White;
            this.dtgLineasNotasDeGasto.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.dtgLineasNotasDeGasto.CaptionForeColor = System.Drawing.Color.White;
            this.dtgLineasNotasDeGasto.CaptionText = "Líneas";
            this.dtgLineasNotasDeGasto.CaptionVisible = false;
            this.dtgLineasNotasDeGasto.ContextMenu = this.cntMenu;
            this.dtgLineasNotasDeGasto.DataMember = "";
            this.dtgLineasNotasDeGasto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgLineasNotasDeGasto.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dtgLineasNotasDeGasto.Location = new System.Drawing.Point(-2, 18);
            this.dtgLineasNotasDeGasto.Name = "dtgLineasNotasDeGasto";
            this.dtgLineasNotasDeGasto.ReadOnly = true;
            this.dtgLineasNotasDeGasto.Size = new System.Drawing.Size(915, 80);
            this.dtgLineasNotasDeGasto.TabIndex = 0;
            this.dtgLineasNotasDeGasto.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            this.dtgLineasNotasDeGasto.TabStop = false;
            this.dtgLineasNotasDeGasto.Visible = false;
            this.dtgLineasNotasDeGasto.CurrentCellChanged += new System.EventHandler(this.dtgLineasNotasDeGasto_CurrentCellChanged);
            // 
            // cntMenu
            // 
            this.cntMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuNuevaLinea,
            this.menuEliminarLinea});
            // 
            // menuNuevaLinea
            // 
            this.menuNuevaLinea.Index = 0;
            this.menuNuevaLinea.Shortcut = System.Windows.Forms.Shortcut.CtrlN;
            this.menuNuevaLinea.Text = "Nuevo";
            this.menuNuevaLinea.Click += new System.EventHandler(this.menuNuevaLinea_Click);
            // 
            // menuEliminarLinea
            // 
            this.menuEliminarLinea.Index = 1;
            this.menuEliminarLinea.Shortcut = System.Windows.Forms.Shortcut.CtrlX;
            this.menuEliminarLinea.Text = "Eliminar";
            this.menuEliminarLinea.Click += new System.EventHandler(this.btEliminarLinea_Click);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.DataGrid = this.dtgLineasNotasDeGasto;
            this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn13,
            this.dataGridTextBoxColumn4,
            this.dataGridTextBoxColumn10,
            this.dataGridTextBoxColumn8,
            this.dataGridTextBoxColumn2,
            this.dataGridTextBoxColumn7,
            this.dataGridTextBoxColumn5,
            this.dataGridTextBoxColumn6,
            this.dataGridTextBoxColumn1});
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle1.ReadOnly = true;
            // 
            // dataGridTextBoxColumn13
            // 
            this.dataGridTextBoxColumn13.Format = "";
            this.dataGridTextBoxColumn13.FormatInfo = null;
            this.dataGridTextBoxColumn13.HeaderText = "IdNotaGasto";
            this.dataGridTextBoxColumn13.MappingName = "iIdNota";
            this.dataGridTextBoxColumn13.Width = 0;
            // 
            // dataGridTextBoxColumn4
            // 
            this.dataGridTextBoxColumn4.Format = "";
            this.dataGridTextBoxColumn4.FormatInfo = null;
            this.dataGridTextBoxColumn4.HeaderText = "idGasto";
            this.dataGridTextBoxColumn4.MappingName = "idGasto";
            this.dataGridTextBoxColumn4.NullText = "";
            this.dataGridTextBoxColumn4.Width = 0;
            // 
            // dataGridTextBoxColumn10
            // 
            this.dataGridTextBoxColumn10.Format = "";
            this.dataGridTextBoxColumn10.FormatInfo = null;
            this.dataGridTextBoxColumn10.HeaderText = "Gasto";
            this.dataGridTextBoxColumn10.MappingName = "Gasto";
            this.dataGridTextBoxColumn10.NullText = "";
            this.dataGridTextBoxColumn10.Width = 150;
            // 
            // dataGridTextBoxColumn8
            // 
            this.dataGridTextBoxColumn8.Format = "";
            this.dataGridTextBoxColumn8.FormatInfo = null;
            this.dataGridTextBoxColumn8.HeaderText = "Centro de Coste";
            this.dataGridTextBoxColumn8.MappingName = "sIdCentroCoste";
            this.dataGridTextBoxColumn8.NullText = "";
            this.dataGridTextBoxColumn8.Width = 0;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "CentroCoste";
            this.dataGridTextBoxColumn2.MappingName = "sCentroCoste";
            this.dataGridTextBoxColumn2.NullText = "";
            this.dataGridTextBoxColumn2.Width = 110;
            // 
            // dataGridTextBoxColumn7
            // 
            this.dataGridTextBoxColumn7.Format = "";
            this.dataGridTextBoxColumn7.FormatInfo = null;
            this.dataGridTextBoxColumn7.HeaderText = "Descripcion";
            this.dataGridTextBoxColumn7.MappingName = "tObservaciones";
            this.dataGridTextBoxColumn7.NullText = "";
            this.dataGridTextBoxColumn7.Width = 370;
            // 
            // dataGridTextBoxColumn5
            // 
            this.dataGridTextBoxColumn5.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn5.Format = "";
            this.dataGridTextBoxColumn5.FormatInfo = null;
            this.dataGridTextBoxColumn5.HeaderText = "Cantidad";
            this.dataGridTextBoxColumn5.MappingName = "fCantidad";
            this.dataGridTextBoxColumn5.NullText = "";
            this.dataGridTextBoxColumn5.Width = 75;
            // 
            // dataGridTextBoxColumn6
            // 
            this.dataGridTextBoxColumn6.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn6.Format = "N4";
            this.dataGridTextBoxColumn6.FormatInfo = null;
            this.dataGridTextBoxColumn6.HeaderText = "Precio";
            this.dataGridTextBoxColumn6.MappingName = "fPrecio";
            this.dataGridTextBoxColumn6.NullText = "";
            this.dataGridTextBoxColumn6.Width = 75;
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn1.Format = "N4";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "Imp.Linea";
            this.dataGridTextBoxColumn1.MappingName = "fImpLinea";
            this.dataGridTextBoxColumn1.NullText = "";
            this.dataGridTextBoxColumn1.Width = 75;
            // 
            // btActualizarLinea
            // 
            this.btActualizarLinea.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btActualizarLinea.ForeColor = System.Drawing.Color.Black;
            this.btActualizarLinea.Image = ((System.Drawing.Image)(resources.GetObject("btActualizarLinea.Image")));
            this.btActualizarLinea.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btActualizarLinea.Location = new System.Drawing.Point(16, 224);
            this.btActualizarLinea.Name = "btActualizarLinea";
            this.btActualizarLinea.Size = new System.Drawing.Size(105, 29);
            this.btActualizarLinea.TabIndex = 2;
            this.btActualizarLinea.Text = "&Actualizar";
            this.btActualizarLinea.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTipNotasGasto.SetToolTip(this.btActualizarLinea, "Actualizar");
            this.btActualizarLinea.UseVisualStyleBackColor = true;
            this.btActualizarLinea.Click += new System.EventHandler(this.btnActualizarLinea_Click);
            // 
            // btEliminarLinea
            // 
            this.btEliminarLinea.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btEliminarLinea.ForeColor = System.Drawing.Color.Black;
            this.btEliminarLinea.Image = ((System.Drawing.Image)(resources.GetObject("btEliminarLinea.Image")));
            this.btEliminarLinea.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btEliminarLinea.Location = new System.Drawing.Point(125, 224);
            this.btEliminarLinea.Name = "btEliminarLinea";
            this.btEliminarLinea.Size = new System.Drawing.Size(95, 30);
            this.btEliminarLinea.TabIndex = 3;
            this.btEliminarLinea.Text = "&Eliminar";
            this.btEliminarLinea.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTipNotasGasto.SetToolTip(this.btEliminarLinea, "Eliminar");
            this.btEliminarLinea.UseVisualStyleBackColor = true;
            this.btEliminarLinea.Click += new System.EventHandler(this.btEliminarLinea_Click);
            // 
            // pnlLineasGasto
            // 
            this.pnlLineasGasto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnlLineasGasto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlLineasGasto.Controls.Add(this.label6);
            this.pnlLineasGasto.Controls.Add(this.txtImpLinea);
            this.pnlLineasGasto.Controls.Add(this.nupPrecio);
            this.pnlLineasGasto.Controls.Add(this.cboCCoste);
            this.pnlLineasGasto.Controls.Add(this.lblCCoste);
            this.pnlLineasGasto.Controls.Add(this.label2);
            this.pnlLineasGasto.Controls.Add(this.txbDescrip);
            this.pnlLineasGasto.Controls.Add(this.lblDesc);
            this.pnlLineasGasto.Controls.Add(this.lblPrecio);
            this.pnlLineasGasto.Controls.Add(this.nmrCantidad);
            this.pnlLineasGasto.Controls.Add(this.lblCantidad);
            this.pnlLineasGasto.Controls.Add(this.cboGasto);
            this.pnlLineasGasto.Controls.Add(this.lblGasto);
            this.pnlLineasGasto.Controls.Add(this.label7);
            this.pnlLineasGasto.Location = new System.Drawing.Point(8, 259);
            this.pnlLineasGasto.Name = "pnlLineasGasto";
            this.pnlLineasGasto.Size = new System.Drawing.Size(1463, 64);
            this.pnlLineasGasto.TabIndex = 1;
            this.pnlLineasGasto.TabStop = true;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(1209, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(16, 16);
            this.label6.TabIndex = 38;
            this.label6.Text = "€";
            // 
            // txtImpLinea
            // 
            this.txtImpLinea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtImpLinea.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImpLinea.ForeColor = System.Drawing.Color.Black;
            this.txtImpLinea.Location = new System.Drawing.Point(1324, 17);
            this.txtImpLinea.Name = "txtImpLinea";
            this.txtImpLinea.ReadOnly = true;
            this.txtImpLinea.Size = new System.Drawing.Size(106, 26);
            this.txtImpLinea.TabIndex = 37;
            this.txtImpLinea.TabStop = false;
            this.txtImpLinea.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nupPrecio
            // 
            this.nupPrecio.BackColor = System.Drawing.Color.White;
            this.nupPrecio.DecimalPlaces = 4;
            this.nupPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nupPrecio.ForeColor = System.Drawing.Color.Black;
            this.nupPrecio.Location = new System.Drawing.Point(1108, 17);
            this.nupPrecio.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nupPrecio.Name = "nupPrecio";
            this.nupPrecio.Size = new System.Drawing.Size(100, 26);
            this.nupPrecio.TabIndex = 34;
            this.nupPrecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nupPrecio.ValueChanged += new System.EventHandler(this.nupPrecio_ValueChanged);
            this.nupPrecio.Leave += new System.EventHandler(this.nupPrecio_ValueChanged);
            // 
            // cboCCoste
            // 
            this.cboCCoste.BackColor = System.Drawing.Color.White;
            this.cboCCoste.DataSource = this.dsGastos1.ListaTipoCCoste;
            this.cboCCoste.DisplayMember = "sLiteral";
            this.cboCCoste.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCCoste.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCCoste.ForeColor = System.Drawing.Color.Black;
            this.cboCCoste.ItemHeight = 20;
            this.cboCCoste.Location = new System.Drawing.Point(317, 22);
            this.cboCCoste.Name = "cboCCoste";
            this.cboCCoste.Size = new System.Drawing.Size(161, 28);
            this.cboCCoste.TabIndex = 31;
            this.cboCCoste.ValueMember = "sValor";
            // 
            // dsGastos1
            // 
            this.dsGastos1.DataSetName = "dsGastos";
            this.dsGastos1.Locale = new System.Globalization.CultureInfo("en-US");
            this.dsGastos1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lblCCoste
            // 
            this.lblCCoste.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblCCoste.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCCoste.ForeColor = System.Drawing.Color.Black;
            this.lblCCoste.Location = new System.Drawing.Point(317, 2);
            this.lblCCoste.Name = "lblCCoste";
            this.lblCCoste.Size = new System.Drawing.Size(92, 16);
            this.lblCCoste.TabIndex = 34;
            this.lblCCoste.Text = "C. Coste:";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(1429, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 16);
            this.label2.TabIndex = 27;
            this.label2.Text = "€";
            // 
            // txbDescrip
            // 
            this.txbDescrip.BackColor = System.Drawing.Color.White;
            this.txbDescrip.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbDescrip.ForeColor = System.Drawing.Color.Black;
            this.txbDescrip.Location = new System.Drawing.Point(582, 13);
            this.txbDescrip.MaxLength = 8000;
            this.txbDescrip.Multiline = true;
            this.txbDescrip.Name = "txbDescrip";
            this.txbDescrip.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txbDescrip.Size = new System.Drawing.Size(270, 42);
            this.txbDescrip.TabIndex = 2;
            // 
            // lblDesc
            // 
            this.lblDesc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesc.ForeColor = System.Drawing.Color.Black;
            this.lblDesc.Location = new System.Drawing.Point(484, 15);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(96, 25);
            this.lblDesc.TabIndex = 17;
            this.lblDesc.Text = "Descripción:";
            // 
            // lblPrecio
            // 
            this.lblPrecio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecio.ForeColor = System.Drawing.Color.Black;
            this.lblPrecio.Location = new System.Drawing.Point(1052, 18);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(57, 24);
            this.lblPrecio.TabIndex = 15;
            this.lblPrecio.Text = "Precio:";
            // 
            // nmrCantidad
            // 
            this.nmrCantidad.BackColor = System.Drawing.Color.White;
            this.nmrCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nmrCantidad.ForeColor = System.Drawing.Color.Black;
            this.nmrCantidad.Location = new System.Drawing.Point(935, 16);
            this.nmrCantidad.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nmrCantidad.Name = "nmrCantidad";
            this.nmrCantidad.Size = new System.Drawing.Size(100, 26);
            this.nmrCantidad.TabIndex = 3;
            this.nmrCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nmrCantidad.ValueChanged += new System.EventHandler(this.nmrCantidad_ValueChanged);
            this.nmrCantidad.Leave += new System.EventHandler(this.nmrCantidad_ValueChanged);
            // 
            // lblCantidad
            // 
            this.lblCantidad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidad.ForeColor = System.Drawing.Color.Black;
            this.lblCantidad.Location = new System.Drawing.Point(857, 18);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(77, 21);
            this.lblCantidad.TabIndex = 13;
            this.lblCantidad.Text = "Cantidad:";
            // 
            // cboGasto
            // 
            this.cboGasto.BackColor = System.Drawing.Color.White;
            this.cboGasto.DataSource = this.dsGastos1.ListaGastos;
            this.cboGasto.DisplayMember = "sDescripcion";
            this.cboGasto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGasto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboGasto.ForeColor = System.Drawing.Color.Black;
            this.cboGasto.ItemHeight = 20;
            this.cboGasto.Location = new System.Drawing.Point(4, 22);
            this.cboGasto.Name = "cboGasto";
            this.cboGasto.Size = new System.Drawing.Size(296, 28);
            this.cboGasto.TabIndex = 0;
            this.cboGasto.ValueMember = "iIdGasto";
            this.cboGasto.SelectedIndexChanged += new System.EventHandler(this.cboGasto_SelectedIndexChanged);
            // 
            // lblGasto
            // 
            this.lblGasto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblGasto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGasto.ForeColor = System.Drawing.Color.Black;
            this.lblGasto.Location = new System.Drawing.Point(4, 2);
            this.lblGasto.Name = "lblGasto";
            this.lblGasto.Size = new System.Drawing.Size(62, 16);
            this.lblGasto.TabIndex = 11;
            this.lblGasto.Text = "Gasto:";
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(1241, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 23);
            this.label7.TabIndex = 39;
            this.label7.Text = "Imp.Linea:";
            // 
            // labelGradient4
            // 
            this.labelGradient4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelGradient4.ForeColor = System.Drawing.Color.White;
            this.labelGradient4.GradientColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.labelGradient4.GradientColorTwo = System.Drawing.Color.White;
            this.labelGradient4.Location = new System.Drawing.Point(0, 0);
            this.labelGradient4.Name = "labelGradient4";
            this.labelGradient4.Size = new System.Drawing.Size(960, 22);
            this.labelGradient4.TabIndex = 32;
            this.labelGradient4.Text = "Detalle Nota de Gasto";
            this.labelGradient4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sqldaListaGastos
            // 
            this.sqldaListaGastos.SelectCommand = this.sqlSelectCommand2;
            this.sqldaListaGastos.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaGastos", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iIdGasto", "iIdGasto"),
                        new System.Data.Common.DataColumnMapping("sDescripcion", "sDescripcion"),
                        new System.Data.Common.DataColumnMapping("fPrecio", "fPrecio"),
                        new System.Data.Common.DataColumnMapping("sCuentaSAP", "sCuentaSAP"),
                        new System.Data.Common.DataColumnMapping("sCosteSAP", "sCosteSAP"),
                        new System.Data.Common.DataColumnMapping("tCosteSAP", "tCosteSAP"),
                        new System.Data.Common.DataColumnMapping("bSistema", "bSistema"),
                        new System.Data.Common.DataColumnMapping("bImputaPresup", "bImputaPresup"),
                        new System.Data.Common.DataColumnMapping("sIdTipCentroCoste", "sIdTipCentroCoste"),
                        new System.Data.Common.DataColumnMapping("sIdCategGasto", "sIdCategGasto"),
                        new System.Data.Common.DataColumnMapping("sIdTipoGasto", "sIdTipoGasto"),
                        new System.Data.Common.DataColumnMapping("iNumLimite", "iNumLimite"),
                        new System.Data.Common.DataColumnMapping("bSistema1", "bSistema1")})});
            // 
            // sqlSelectCommand2
            // 
            this.sqlSelectCommand2.CommandText = "[ListaGastos]";
            this.sqlSelectCommand2.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand2.Connection = this.sqlConn;
            this.sqlSelectCommand2.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdDelegado", System.Data.SqlDbType.Int)});
            // 
            // sqldaListaAtenCom
            // 
            this.sqldaListaAtenCom.SelectCommand = this.sqlSelectCommand3;
            this.sqldaListaAtenCom.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaAtencionesCom", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iIdNota", "iIdNota"),
                        new System.Data.Common.DataColumnMapping("iIdReport", "iIdReport"),
                        new System.Data.Common.DataColumnMapping("dFecha", "dFecha"),
                        new System.Data.Common.DataColumnMapping("tFechaRep", "tFechaRep"),
                        new System.Data.Common.DataColumnMapping("iIdCliente", "iIdCliente"),
                        new System.Data.Common.DataColumnMapping("sIdCliente", "sIdCliente"),
                        new System.Data.Common.DataColumnMapping("sNombreCli", "sNombreCli"),
                        new System.Data.Common.DataColumnMapping("iIdAtencion", "iIdAtencion"),
                        new System.Data.Common.DataColumnMapping("sIdAtencion", "sIdAtencion"),
                        new System.Data.Common.DataColumnMapping("iNumAtencion", "iNumAtencion"),
                        new System.Data.Common.DataColumnMapping("fImporte", "fImporte")})});
            // 
            // sqlSelectCommand3
            // 
            this.sqlSelectCommand3.CommandText = "[ListaAtencionesCom]";
            this.sqlSelectCommand3.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand3.Connection = this.sqlConn;
            this.sqlSelectCommand3.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdNota", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@dFecha", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@iIdDelegado", System.Data.SqlDbType.Int, 4)});
            // 
            // sqlCmdSetNotasGastos
            // 
            this.sqlCmdSetNotasGastos.CommandText = "[SetNotasDeGasto]";
            this.sqlCmdSetNotasGastos.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdSetNotasGastos.Connection = this.sqlConn;
            this.sqlCmdSetNotasGastos.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iAccion", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdNota", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.InputOutput, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@sIdNotaTemp", System.Data.SqlDbType.VarChar, 11, System.Data.ParameterDirection.Output, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@idDelegado", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@dFecha", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@bVisa", System.Data.SqlDbType.TinyInt, 1),
            new System.Data.SqlClient.SqlParameter("@tObservaciones", System.Data.SqlDbType.VarChar, 8000)});
            // 
            // sqlCmdSetNotasDeGastosLineas
            // 
            this.sqlCmdSetNotasDeGastosLineas.CommandText = "[SetNotasDeGastosLineas]";
            this.sqlCmdSetNotasDeGastosLineas.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdSetNotasDeGastosLineas.Connection = this.sqlConn;
            this.sqlCmdSetNotasDeGastosLineas.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iAccion", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdNota", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdGasto", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@fCantidad", System.Data.SqlDbType.Float, 8),
            new System.Data.SqlClient.SqlParameter("@fPrecio", System.Data.SqlDbType.Float, 8),
            new System.Data.SqlClient.SqlParameter("@tDescripcion", System.Data.SqlDbType.VarChar, 8000),
            new System.Data.SqlClient.SqlParameter("@sIdCentroCoste", System.Data.SqlDbType.VarChar, 10)});
            // 
            // sqlCmdSetAtencionesNotasGasto
            // 
            this.sqlCmdSetAtencionesNotasGasto.CommandText = "[SetAtencionesNotasGasto]";
            this.sqlCmdSetAtencionesNotasGasto.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdSetAtencionesNotasGasto.Connection = this.sqlConn;
            this.sqlCmdSetAtencionesNotasGasto.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iAccion", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdNota", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdReport", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@idAtencion", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iNumAtencion", System.Data.SqlDbType.Int, 4)});
            // 
            // sqldaLineasGasto
            // 
            this.sqldaLineasGasto.SelectCommand = this.sqlSelectCommand5;
            this.sqldaLineasGasto.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaLineasNotasGasto", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iIdNota", "iIdNota"),
                        new System.Data.Common.DataColumnMapping("iIdGasto", "iIdGasto"),
                        new System.Data.Common.DataColumnMapping("fCantidad", "fCantidad"),
                        new System.Data.Common.DataColumnMapping("fPrecio", "fPrecio"),
                        new System.Data.Common.DataColumnMapping("ImporteGasto", "ImporteGasto"),
                        new System.Data.Common.DataColumnMapping("DescripLinea", "DescripLinea"),
                        new System.Data.Common.DataColumnMapping("sIdCentroCoste", "sIdCentroCoste"),
                        new System.Data.Common.DataColumnMapping("sCentroCoste", "sCentroCoste"),
                        new System.Data.Common.DataColumnMapping("DescripGasto", "DescripGasto")})});
            // 
            // sqlSelectCommand5
            // 
            this.sqlSelectCommand5.CommandText = "[ListaLineasNotasGasto]";
            this.sqlSelectCommand5.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand5.Connection = this.sqlConn;
            this.sqlSelectCommand5.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdNota", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@Param", System.Data.SqlDbType.VarChar, 1),
            new System.Data.SqlClient.SqlParameter("@iIdDelegado", System.Data.SqlDbType.Int, 4)});
            // 
            // dtgAtencionesCom
            // 
            this.dtgAtencionesCom.AlternatingBackColor = System.Drawing.Color.White;
            this.dtgAtencionesCom.BackColor = System.Drawing.Color.White;
            this.dtgAtencionesCom.BackgroundColor = System.Drawing.Color.White;
            this.dtgAtencionesCom.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.dtgAtencionesCom.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgAtencionesCom.CaptionForeColor = System.Drawing.Color.White;
            this.dtgAtencionesCom.CaptionText = "Atenciones Comerciales";
            this.dtgAtencionesCom.CaptionVisible = false;
            this.dtgAtencionesCom.DataMember = "";
            this.dtgAtencionesCom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgAtencionesCom.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgAtencionesCom.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dtgAtencionesCom.Location = new System.Drawing.Point(-2, 18);
            this.dtgAtencionesCom.Name = "dtgAtencionesCom";
            this.dtgAtencionesCom.ReadOnly = true;
            this.dtgAtencionesCom.Size = new System.Drawing.Size(1458, 146);
            this.dtgAtencionesCom.TabIndex = 0;
            this.dtgAtencionesCom.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle2});
            // 
            // dataGridTableStyle2
            // 
            this.dataGridTableStyle2.DataGrid = this.dtgAtencionesCom;
            this.dataGridTableStyle2.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn9,
            this.dataGridTextBoxColumn12,
            this.dataGridTextBoxColumn3,
            this.dataGridTextBoxColumn14,
            this.dataGridTextBoxColumn15,
            this.dataGridTextBoxColumn11});
            this.dataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // dataGridTextBoxColumn9
            // 
            this.dataGridTextBoxColumn9.Format = "";
            this.dataGridTextBoxColumn9.FormatInfo = null;
            this.dataGridTextBoxColumn9.HeaderText = "Atención";
            this.dataGridTextBoxColumn9.MappingName = "idAtt";
            this.dataGridTextBoxColumn9.NullText = "";
            this.dataGridTextBoxColumn9.Width = 300;
            // 
            // dataGridTextBoxColumn12
            // 
            this.dataGridTextBoxColumn12.Format = "";
            this.dataGridTextBoxColumn12.FormatInfo = null;
            this.dataGridTextBoxColumn12.HeaderText = "Descripción";
            this.dataGridTextBoxColumn12.MappingName = "Descripcion";
            this.dataGridTextBoxColumn12.NullText = "";
            this.dataGridTextBoxColumn12.Width = 0;
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "dd/MM/yyyy";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.HeaderText = "F.Report";
            this.dataGridTextBoxColumn3.MappingName = "dFecha";
            this.dataGridTextBoxColumn3.NullText = "";
            this.dataGridTextBoxColumn3.Width = 140;
            // 
            // dataGridTextBoxColumn14
            // 
            this.dataGridTextBoxColumn14.Format = "";
            this.dataGridTextBoxColumn14.FormatInfo = null;
            this.dataGridTextBoxColumn14.HeaderText = "Cód. Cliente";
            this.dataGridTextBoxColumn14.MappingName = "sIdCliente";
            this.dataGridTextBoxColumn14.NullText = "";
            this.dataGridTextBoxColumn14.Width = 140;
            // 
            // dataGridTextBoxColumn15
            // 
            this.dataGridTextBoxColumn15.Format = "";
            this.dataGridTextBoxColumn15.FormatInfo = null;
            this.dataGridTextBoxColumn15.HeaderText = "Nombre Cliente";
            this.dataGridTextBoxColumn15.MappingName = "sNombreCli";
            this.dataGridTextBoxColumn15.NullText = "";
            this.dataGridTextBoxColumn15.Width = 500;
            // 
            // dataGridTextBoxColumn11
            // 
            this.dataGridTextBoxColumn11.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn11.Format = "N4";
            this.dataGridTextBoxColumn11.FormatInfo = null;
            this.dataGridTextBoxColumn11.HeaderText = "Importe";
            this.dataGridTextBoxColumn11.MappingName = "fImporteReal";
            this.dataGridTextBoxColumn11.NullText = "";
            this.dataGridTextBoxColumn11.Width = 120;
            // 
            // sqldaListaRutas
            // 
            this.sqldaListaRutas.SelectCommand = this.sqlSelectCommand6;
            this.sqldaListaRutas.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaRutas", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("sIdRuta", "sIdRuta"),
                        new System.Data.Common.DataColumnMapping("iIdRuta", "iIdRuta"),
                        new System.Data.Common.DataColumnMapping("sDescripcion", "sDescripcion"),
                        new System.Data.Common.DataColumnMapping("iKilometros", "iKilometros"),
                        new System.Data.Common.DataColumnMapping("sLiteral", "sLiteral")})});
            // 
            // sqlSelectCommand6
            // 
            this.sqlSelectCommand6.CommandText = "[ListaRutas]";
            this.sqlSelectCommand6.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand6.Connection = this.sqlConn;
            this.sqlSelectCommand6.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@idDelegado", System.Data.SqlDbType.Int, 4)});
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.labelGradient8);
            this.panel1.Controls.Add(this.lblKms);
            this.panel1.Controls.Add(this.lbltotalKms);
            this.panel1.Controls.Add(this.chkListBoxRutas);
            this.panel1.Location = new System.Drawing.Point(8, 337);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(270, 157);
            this.panel1.TabIndex = 4;
            this.panel1.TabStop = true;
            this.panel1.Visible = false;
            // 
            // labelGradient8
            // 
            this.labelGradient8.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelGradient8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGradient8.ForeColor = System.Drawing.Color.White;
            this.labelGradient8.GradientColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.labelGradient8.GradientColorTwo = System.Drawing.Color.White;
            this.labelGradient8.Location = new System.Drawing.Point(0, 0);
            this.labelGradient8.Name = "labelGradient8";
            this.labelGradient8.Size = new System.Drawing.Size(266, 18);
            this.labelGradient8.TabIndex = 41;
            this.labelGradient8.Text = "Rutas Realizadas";
            this.labelGradient8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblKms
            // 
            this.lblKms.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.lblKms.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblKms.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKms.ForeColor = System.Drawing.Color.Black;
            this.lblKms.Location = new System.Drawing.Point(164, 130);
            this.lblKms.Name = "lblKms";
            this.lblKms.Size = new System.Drawing.Size(104, 19);
            this.lblKms.TabIndex = 1;
            this.lblKms.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbltotalKms
            // 
            this.lbltotalKms.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltotalKms.ForeColor = System.Drawing.Color.Black;
            this.lbltotalKms.Location = new System.Drawing.Point(96, 133);
            this.lbltotalKms.Name = "lbltotalKms";
            this.lbltotalKms.Size = new System.Drawing.Size(80, 16);
            this.lbltotalKms.TabIndex = 39;
            this.lbltotalKms.Text = "Total Kms:";
            // 
            // chkListBoxRutas
            // 
            this.chkListBoxRutas.BackColor = System.Drawing.Color.White;
            this.chkListBoxRutas.CheckOnClick = true;
            this.chkListBoxRutas.ForeColor = System.Drawing.Color.Black;
            this.chkListBoxRutas.Location = new System.Drawing.Point(-2, 18);
            this.chkListBoxRutas.MultiColumn = true;
            this.chkListBoxRutas.Name = "chkListBoxRutas";
            this.chkListBoxRutas.Size = new System.Drawing.Size(270, 109);
            this.chkListBoxRutas.TabIndex = 0;
            this.chkListBoxRutas.ThreeDCheckBoxes = true;
            this.chkListBoxRutas.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chkListBoxRutas_ItemCheck);
            // 
            // labelGradient3
            // 
            this.labelGradient3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelGradient3.ForeColor = System.Drawing.Color.White;
            this.labelGradient3.GradientColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.labelGradient3.GradientColorTwo = System.Drawing.Color.White;
            this.labelGradient3.Location = new System.Drawing.Point(0, 0);
            this.labelGradient3.Name = "labelGradient3";
            this.labelGradient3.Size = new System.Drawing.Size(216, 22);
            this.labelGradient3.TabIndex = 32;
            this.labelGradient3.Text = "Rutas";
            this.labelGradient3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sqldaListaRutasNotasGasto
            // 
            this.sqldaListaRutasNotasGasto.SelectCommand = this.sqlSelectCommand8;
            this.sqldaListaRutasNotasGasto.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaRutasNotaGasto", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iIdNota", "iIdNota"),
                        new System.Data.Common.DataColumnMapping("sIdRuta", "sIdRuta"),
                        new System.Data.Common.DataColumnMapping("iIdRuta", "iIdRuta"),
                        new System.Data.Common.DataColumnMapping("sDescripcion", "sDescripcion"),
                        new System.Data.Common.DataColumnMapping("iKilometros", "iKilometros")})});
            // 
            // sqlSelectCommand8
            // 
            this.sqlSelectCommand8.CommandText = "[ListaRutasNotaGasto]";
            this.sqlSelectCommand8.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand8.Connection = this.sqlConn;
            this.sqlSelectCommand8.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdNota", System.Data.SqlDbType.Int, 4)});
            // 
            // sqlCmdSetRutasNotasGastos
            // 
            this.sqlCmdSetRutasNotasGastos.CommandText = "[SetRutasNotasGastos]";
            this.sqlCmdSetRutasNotasGastos.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdSetRutasNotasGastos.Connection = this.sqlConn;
            this.sqlCmdSetRutasNotasGastos.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iAccion", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdNota", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdRuta", System.Data.SqlDbType.Int, 4)});
            // 
            // sqlListaLineasNotasGasto
            // 
            this.sqlListaLineasNotasGasto.CommandText = "[ListaLineasNotasGastoConsulta]";
            this.sqlListaLineasNotasGasto.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlListaLineasNotasGasto.Connection = this.sqlConn;
            this.sqlListaLineasNotasGasto.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdNota", System.Data.SqlDbType.Int, 4)});
            // 
            // sqldaLineasNotasGasto
            // 
            this.sqldaLineasNotasGasto.SelectCommand = this.sqlListaLineasNotasGasto;
            this.sqldaLineasNotasGasto.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaLineasNotasGastoConsulta", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iIdNota", "iIdNota"),
                        new System.Data.Common.DataColumnMapping("iIdGasto", "iIdGasto"),
                        new System.Data.Common.DataColumnMapping("fCantidad", "fCantidad"),
                        new System.Data.Common.DataColumnMapping("fPrecio", "fPrecio"),
                        new System.Data.Common.DataColumnMapping("ImporteGasto", "ImporteGasto"),
                        new System.Data.Common.DataColumnMapping("DescripLinea", "DescripLinea"),
                        new System.Data.Common.DataColumnMapping("sIdCentroCoste", "sIdCentroCoste"),
                        new System.Data.Common.DataColumnMapping("sCentroCoste", "sCentroCoste"),
                        new System.Data.Common.DataColumnMapping("DescripGasto", "DescripGasto")})});
            // 
            // lblTotalAtts
            // 
            this.lblTotalAtts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.lblTotalAtts.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotalAtts.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAtts.ForeColor = System.Drawing.Color.Black;
            this.lblTotalAtts.Location = new System.Drawing.Point(1316, 178);
            this.lblTotalAtts.Name = "lblTotalAtts";
            this.lblTotalAtts.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblTotalAtts.Size = new System.Drawing.Size(114, 19);
            this.lblTotalAtts.TabIndex = 31;
            this.lblTotalAtts.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLineas
            // 
            this.lblLineas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.lblLineas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLineas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLineas.ForeColor = System.Drawing.Color.Black;
            this.lblLineas.Location = new System.Drawing.Point(1163, 230);
            this.lblLineas.Name = "lblLineas";
            this.lblLineas.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblLineas.Size = new System.Drawing.Size(106, 26);
            this.lblLineas.TabIndex = 32;
            this.lblLineas.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ucBotoneraSecundaria1
            // 
            this.ucBotoneraSecundaria1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(117)))), ((int)(((byte)(1)))));
            this.ucBotoneraSecundaria1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucBotoneraSecundaria1.ForeColor = System.Drawing.Color.Black;
            this.ucBotoneraSecundaria1.Location = new System.Drawing.Point(0, 0);
            this.ucBotoneraSecundaria1.Name = "ucBotoneraSecundaria1";
            this.ucBotoneraSecundaria1.Size = new System.Drawing.Size(1516, 38);
            this.ucBotoneraSecundaria1.TabIndex = 8;
            this.ucBotoneraSecundaria1.TabStop = false;
            // 
            // labelGradient2
            // 
            this.labelGradient2.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelGradient2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGradient2.ForeColor = System.Drawing.Color.White;
            this.labelGradient2.GradientColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.labelGradient2.GradientColorTwo = System.Drawing.Color.White;
            this.labelGradient2.Location = new System.Drawing.Point(0, 0);
            this.labelGradient2.Name = "labelGradient2";
            this.labelGradient2.Size = new System.Drawing.Size(1459, 18);
            this.labelGradient2.TabIndex = 1;
            this.labelGradient2.Text = "Líneas de la Nota de Gastos";
            this.labelGradient2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelGradient5
            // 
            this.labelGradient5.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelGradient5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGradient5.ForeColor = System.Drawing.Color.White;
            this.labelGradient5.GradientColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.labelGradient5.GradientColorTwo = System.Drawing.Color.White;
            this.labelGradient5.Location = new System.Drawing.Point(0, 0);
            this.labelGradient5.Name = "labelGradient5";
            this.labelGradient5.Size = new System.Drawing.Size(1459, 18);
            this.labelGradient5.TabIndex = 4;
            this.labelGradient5.Text = "Atenciones Comerciales Imputadas a la Nota de Gastos";
            this.labelGradient5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(1433, 178);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 19);
            this.label3.TabIndex = 42;
            this.label3.Text = "€";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(1272, 234);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 19);
            this.label4.TabIndex = 43;
            this.label4.Text = "€";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sqldaListaCCoste
            // 
            this.sqldaListaCCoste.SelectCommand = this.sqlSelectCommand9;
            this.sqldaListaCCoste.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaTipoCCoste", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("sValor", "sValor"),
                        new System.Data.Common.DataColumnMapping("sLiteral", "sLiteral")})});
            // 
            // sqlSelectCommand9
            // 
            this.sqlSelectCommand9.CommandText = "[ListaTipoCCoste]";
            this.sqlSelectCommand9.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand9.Connection = this.sqlConn;
            this.sqlSelectCommand9.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null)});
            // 
            // sqldaGetNotaGastos
            // 
            this.sqldaGetNotaGastos.SelectCommand = this.sqlSelectCommand1;
            this.sqldaGetNotaGastos.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "GetNotaGastos", new System.Data.Common.DataColumnMapping[] {
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
            // sqlSelectCommand1
            // 
            this.sqlSelectCommand1.CommandText = "[GetNotaGastos]";
            this.sqlSelectCommand1.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand1.Connection = this.sqlConn;
            this.sqlSelectCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdNota", System.Data.SqlDbType.Int, 4)});
            // 
            // sqldaGetExisteNotaGastos
            // 
            this.sqldaGetExisteNotaGastos.SelectCommand = this.sqlSelectCommand4;
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
            // sqlSelectCommand4
            // 
            this.sqlSelectCommand4.CommandText = "[GetExisteNotaGastos]";
            this.sqlSelectCommand4.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand4.Connection = this.sqlConn;
            this.sqlSelectCommand4.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@dFecha", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@iIdDelegado", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@bVisa", System.Data.SqlDbType.Int, 4)});
            // 
            // sqldaGetFecMaxNota
            // 
            this.sqldaGetFecMaxNota.SelectCommand = this.sqlCmdGetFecMaxNota;
            this.sqldaGetFecMaxNota.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "FecMaxNota", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("dFecMaxNota", "dFecMaxNota")})});
            // 
            // sqlCmdGetFecMaxNota
            // 
            this.sqlCmdGetFecMaxNota.CommandText = "[GetFecMaxNota]";
            this.sqlCmdGetFecMaxNota.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdGetFecMaxNota.Connection = this.sqlConn;
            this.sqlCmdGetFecMaxNota.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdDelegado", System.Data.SqlDbType.Int, 4)});
            // 
            // pnDatos
            // 
            this.pnDatos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnDatos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnDatos.Controls.Add(this.label8);
            this.pnDatos.Controls.Add(this.panel4);
            this.pnDatos.Controls.Add(this.panel3);
            this.pnDatos.Controls.Add(this.lblLineas);
            this.pnDatos.Controls.Add(this.label4);
            this.pnDatos.Controls.Add(this.btActualizarLinea);
            this.pnDatos.Controls.Add(this.btEliminarLinea);
            this.pnDatos.Controls.Add(this.pnlLineasGasto);
            this.pnDatos.Controls.Add(this.panel1);
            this.pnDatos.Location = new System.Drawing.Point(1, 168);
            this.pnDatos.Name = "pnDatos";
            this.pnDatos.Size = new System.Drawing.Size(1490, 562);
            this.pnDatos.TabIndex = 1;
            this.pnDatos.TabStop = true;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(1011, 231);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(149, 18);
            this.label8.TabIndex = 46;
            this.label8.Text = "Total Importe:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.lblTotAtenciones);
            this.panel4.Controls.Add(this.labelGradient5);
            this.panel4.Controls.Add(this.dtgAtencionesCom);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.lblTotalAtts);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Location = new System.Drawing.Point(8, 337);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1463, 211);
            this.panel4.TabIndex = 45;
            this.panel4.TabStop = true;
            // 
            // lblTotAtenciones
            // 
            this.lblTotAtenciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.lblTotAtenciones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotAtenciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotAtenciones.Location = new System.Drawing.Point(1399, -1);
            this.lblTotAtenciones.Name = "lblTotAtenciones";
            this.lblTotAtenciones.Size = new System.Drawing.Size(60, 18);
            this.lblTotAtenciones.TabIndex = 5;
            this.lblTotAtenciones.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(1194, 178);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 18);
            this.label5.TabIndex = 43;
            this.label5.Text = "Total Importe:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.dtgViewLineasNotasDeGasto);
            this.panel3.Controls.Add(this.lblTotLineas);
            this.panel3.Controls.Add(this.labelGradient2);
            this.panel3.Controls.Add(this.dtgLineasNotasDeGasto);
            this.panel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(8, 8);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1463, 216);
            this.panel3.TabIndex = 44;
            // 
            // dtgViewLineasNotasDeGasto
            // 
            this.dtgViewLineasNotasDeGasto.AllowUserToAddRows = false;
            this.dtgViewLineasNotasDeGasto.AllowUserToDeleteRows = false;
            this.dtgViewLineasNotasDeGasto.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dtgViewLineasNotasDeGasto.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgViewLineasNotasDeGasto.AutoGenerateColumns = false;
            this.dtgViewLineasNotasDeGasto.BackgroundColor = System.Drawing.Color.White;
            this.dtgViewLineasNotasDeGasto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgViewLineasNotasDeGasto.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgViewLineasNotasDeGasto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgViewLineasNotasDeGasto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iIdNotaDataGridViewTextBoxColumn,
            this.iIdGastoDataGridViewTextBoxColumn,
            this.descripGastoDataGridViewTextBoxColumn,
            this.sIdCentroCosteDataGridViewTextBoxColumn,
            this.sCentroCosteDataGridViewTextBoxColumn,
            this.descripLineaDataGridViewTextBoxColumn,
            this.fCantidadDataGridViewTextBoxColumn,
            this.fPrecioDataGridViewTextBoxColumn,
            this.importeGastoDataGridViewTextBoxColumn});
            this.dtgViewLineasNotasDeGasto.DataMember = "ListaLineasNotasGastoConsulta";
            this.dtgViewLineasNotasDeGasto.DataSource = this.dsGastos1BindingSource;
            this.dtgViewLineasNotasDeGasto.GridColor = System.Drawing.SystemColors.Control;
            this.dtgViewLineasNotasDeGasto.Location = new System.Drawing.Point(-1, 18);
            this.dtgViewLineasNotasDeGasto.MultiSelect = false;
            this.dtgViewLineasNotasDeGasto.Name = "dtgViewLineasNotasDeGasto";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgViewLineasNotasDeGasto.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dtgViewLineasNotasDeGasto.RowHeadersWidth = 16;
            this.dtgViewLineasNotasDeGasto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgViewLineasNotasDeGasto.Size = new System.Drawing.Size(1460, 191);
            this.dtgViewLineasNotasDeGasto.TabIndex = 3;
            this.dtgViewLineasNotasDeGasto.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dtgViewLineasNotasDeGasto_CellBeginEdit);
            this.dtgViewLineasNotasDeGasto.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgViewLineasNotasDeGasto_CellClick);
            this.dtgViewLineasNotasDeGasto.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgViewLineasNotasDeGasto_CellEndEdit);
            this.dtgViewLineasNotasDeGasto.CellParsing += new System.Windows.Forms.DataGridViewCellParsingEventHandler(this.dtgViewLineasNotasDeGasto_CellParsing);
            this.dtgViewLineasNotasDeGasto.CurrentCellChanged += new System.EventHandler(this.dtgViewLineasNotasDeGasto_CurrentCellChanged);
            this.dtgViewLineasNotasDeGasto.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dtgViewLineasNotasDeGasto_DataError);
            // 
            // iIdNotaDataGridViewTextBoxColumn
            // 
            this.iIdNotaDataGridViewTextBoxColumn.DataPropertyName = "iIdNota";
            this.iIdNotaDataGridViewTextBoxColumn.HeaderText = "iIdNota";
            this.iIdNotaDataGridViewTextBoxColumn.Name = "iIdNotaDataGridViewTextBoxColumn";
            this.iIdNotaDataGridViewTextBoxColumn.ReadOnly = true;
            this.iIdNotaDataGridViewTextBoxColumn.Visible = false;
            // 
            // iIdGastoDataGridViewTextBoxColumn
            // 
            this.iIdGastoDataGridViewTextBoxColumn.DataPropertyName = "iIdGasto";
            this.iIdGastoDataGridViewTextBoxColumn.HeaderText = "iIdGasto";
            this.iIdGastoDataGridViewTextBoxColumn.Name = "iIdGastoDataGridViewTextBoxColumn";
            this.iIdGastoDataGridViewTextBoxColumn.ReadOnly = true;
            this.iIdGastoDataGridViewTextBoxColumn.Visible = false;
            // 
            // descripGastoDataGridViewTextBoxColumn
            // 
            this.descripGastoDataGridViewTextBoxColumn.DataPropertyName = "DescripGasto";
            this.descripGastoDataGridViewTextBoxColumn.HeaderText = "Gasto";
            this.descripGastoDataGridViewTextBoxColumn.Name = "descripGastoDataGridViewTextBoxColumn";
            this.descripGastoDataGridViewTextBoxColumn.ReadOnly = true;
            this.descripGastoDataGridViewTextBoxColumn.Width = 400;
            // 
            // sIdCentroCosteDataGridViewTextBoxColumn
            // 
            this.sIdCentroCosteDataGridViewTextBoxColumn.DataPropertyName = "sIdCentroCoste";
            this.sIdCentroCosteDataGridViewTextBoxColumn.HeaderText = "sIdCentroCoste";
            this.sIdCentroCosteDataGridViewTextBoxColumn.Name = "sIdCentroCosteDataGridViewTextBoxColumn";
            this.sIdCentroCosteDataGridViewTextBoxColumn.ReadOnly = true;
            this.sIdCentroCosteDataGridViewTextBoxColumn.Visible = false;
            this.sIdCentroCosteDataGridViewTextBoxColumn.Width = 110;
            // 
            // sCentroCosteDataGridViewTextBoxColumn
            // 
            this.sCentroCosteDataGridViewTextBoxColumn.DataPropertyName = "sCentroCoste";
            this.sCentroCosteDataGridViewTextBoxColumn.HeaderText = "CentroCoste";
            this.sCentroCosteDataGridViewTextBoxColumn.Name = "sCentroCosteDataGridViewTextBoxColumn";
            this.sCentroCosteDataGridViewTextBoxColumn.ReadOnly = true;
            this.sCentroCosteDataGridViewTextBoxColumn.Width = 200;
            // 
            // descripLineaDataGridViewTextBoxColumn
            // 
            this.descripLineaDataGridViewTextBoxColumn.DataPropertyName = "DescripLinea";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.descripLineaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.descripLineaDataGridViewTextBoxColumn.HeaderText = "Descripción";
            this.descripLineaDataGridViewTextBoxColumn.Name = "descripLineaDataGridViewTextBoxColumn";
            this.descripLineaDataGridViewTextBoxColumn.Width = 350;
            // 
            // fCantidadDataGridViewTextBoxColumn
            // 
            this.fCantidadDataGridViewTextBoxColumn.DataPropertyName = "fCantidad";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.fCantidadDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.fCantidadDataGridViewTextBoxColumn.HeaderText = "Cantidad";
            this.fCantidadDataGridViewTextBoxColumn.Name = "fCantidadDataGridViewTextBoxColumn";
            this.fCantidadDataGridViewTextBoxColumn.Width = 90;
            // 
            // fPrecioDataGridViewTextBoxColumn
            // 
            this.fPrecioDataGridViewTextBoxColumn.DataPropertyName = "fPrecio";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N4";
            dataGridViewCellStyle5.NullValue = null;
            this.fPrecioDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.fPrecioDataGridViewTextBoxColumn.HeaderText = "Precio";
            this.fPrecioDataGridViewTextBoxColumn.Name = "fPrecioDataGridViewTextBoxColumn";
            this.fPrecioDataGridViewTextBoxColumn.Width = 110;
            // 
            // importeGastoDataGridViewTextBoxColumn
            // 
            this.importeGastoDataGridViewTextBoxColumn.DataPropertyName = "ImporteGasto";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N4";
            dataGridViewCellStyle6.NullValue = null;
            this.importeGastoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.importeGastoDataGridViewTextBoxColumn.HeaderText = "Imp. Linea";
            this.importeGastoDataGridViewTextBoxColumn.Name = "importeGastoDataGridViewTextBoxColumn";
            this.importeGastoDataGridViewTextBoxColumn.ReadOnly = true;
            this.importeGastoDataGridViewTextBoxColumn.Width = 110;
            // 
            // dsGastos1BindingSource
            // 
            this.dsGastos1BindingSource.DataSource = this.dsGastos1;
            this.dsGastos1BindingSource.Position = 0;
            // 
            // lblTotLineas
            // 
            this.lblTotLineas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.lblTotLineas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotLineas.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotLineas.Location = new System.Drawing.Point(1390, 0);
            this.lblTotLineas.Name = "lblTotLineas";
            this.lblTotLineas.Size = new System.Drawing.Size(71, 18);
            this.lblTotLineas.TabIndex = 2;
            this.lblTotLineas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmGastos
            // 
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.ClientSize = new System.Drawing.Size(1533, 573);
            this.Controls.Add(this.pnDatos);
            this.Controls.Add(this.ucBotoneraSecundaria1);
            this.Controls.Add(this.pnlNGasto);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmGastos";
            this.Text = "Gestión de Gastos";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmGastos_Closing);
            this.Closed += new System.EventHandler(this.frmGastos_Closed);
            this.Load += new System.EventHandler(this.frmGastos_Load);
            this.pnlNGasto.ResumeLayout(false);
            this.pnlNGasto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgLineasNotasDeGasto)).EndInit();
            this.pnlLineasGasto.ResumeLayout(false);
            this.pnlLineasGasto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupPrecio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsGastos1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgAtencionesCom)).EndInit();
            this.panel1.ResumeLayout(false);
            this.pnDatos.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgViewLineasNotasDeGasto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsGastos1BindingSource)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion


		#region frmGastos_Load
		private void frmGastos_Load(object sender, System.EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;
			try
			{
				Utiles.Formato_Formulario( this ); 
				if(this.Parent == null) this.WindowState = FormWindowState.Normal;
				
				//En altas y modificaciones el delegado viene fijado de configuración 
				this.txtNombreDelegado.Text = GESTCRM.Utiles.NombreDeleg(this.ParamiIdDelegado);

				if(GESTCRM.Clases.Configuracion.iGGastos==1) this.ParamTipoAcceso="C";
				if(this.ParamiIdDelegado!=Clases.Configuracion.iIdDelegado) this.ParamTipoAcceso="C";
			
				//Inicializo los Kms;
				this.lblKms.Text = "";
			
				//Relleno los diferentes Combos
				Inicializar_Combos();
			
				//Creación de las diferentes tablas que necesito para los grids
				Inicializar_dtLineasGastos();	//Tabla de Lineas de Gasto
				Inicializar_dtAtenCom();		//Tabla de Atenciones Comerciales
				Inicializar_dtRutas();			//Tabla de Rutas
                Inicializar_dtLineasViewGastos(); //---- GSG (26/03/2012)

				if(this.ParamTipoAcceso=="A")
				{
					this.dtpFecha.Format = DateTimePickerFormat.Custom;
					if(this.ParamsFecha!=null)
					{
						this.dtpFecha.Value=DateTime.Parse(this.ParamsFecha);
					}
					else
					{
						this.dtpFecha.CustomFormat=" ";
					}
					this.chkVisa.Checked=false;
					this.chkVisa.Enabled=false;
				}
				else
				{
					RecuperarNotaGastos();
					if(bEnviadoCEN==1) this.ParamTipoAcceso="C";
					this.dtpFecha.Enabled=false;
					this.chkVisa.Enabled=false;
				}

				//Cargar_Gastos();//Trato los Gastos

                //---- GSG (26/03/2012)
				//Cargar_LineasNotaGastos();
                Cargar_LineasViewNotaGastos();


				Cargar_AtencionesComerciales();
				//Cargar_Rutas();
                
                
				Inicializar_DataGrid(); //Formateo de los DataGrids
			
				Inicializar_Botonera();

				switch(this.ParamTipoAcceso)
				{
					case "A": this.lblTitulo.Text = "Alta de una Nota de Gastos";break;
					case "M": this.lblTitulo.Text = "Modificación de una Nota de Gastos";break;
					case "C": this.lblTitulo.Text = "Consulta de una Nota de Gastos";break;
					default: break;
				}

				if(this.ParamTipoAcceso=="C")
				{
					Utiles.Activar_Panel(this.pnlNGasto,false);
					Utiles.Activar_Panel(this.pnDatos,false);
					this.menuEliminarLinea.Visible=false;
					this.menuNuevaLinea.Visible=false;
				}
                

				this.Var_CambioFecha=true;
				this.SalirDesdeGuardar=false;
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

				//ComboBox cboGasto
				this.sqldaListaGastos.SelectCommand.Parameters["@iIdDelegado"].Value = this.ParamiIdDelegado;
				this.sqldaListaGastos.Fill(this.dsGastos1);

				cboGasto.DataSource = dsGastos1.ListaGastos; 
				cboGasto.SelectedIndex = 0;

				//ComboBox cboCCoste
				this.sqldaListaCCoste.Fill(this.dsGastos1);

			}
			catch(Exception ex)
				{
					Mensajes.ShowError(ex.Message);
				}
		}


		#endregion

		#region Inicializar_DataGrid
		private void Inicializar_DataGrid()
		{
			try
			{
                //---- GSG (27/03/2012)
				//Utiles.Formatear_DataGrid(this,this.dtgLineasNotasDeGasto,null,true,cntMenu);
                //---- FI GSG
				Utiles.Formatear_DataGrid(this.dtgAtencionesCom,"C",null);                
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region Inicializar_dtAtenCom
		private void Inicializar_dtAtenCom()
		{
			try
			{
				dtAtenCom = new DataTable();

				dtAtenCom.Columns.Add("Descripcion");
				dtAtenCom.Columns.Add("idAtt");
				dtAtenCom.Columns.Add("fImporteReal",System.Type.GetType("System.Double"));
				dtAtenCom.Columns.Add("iIdNota");
				dtAtenCom.Columns.Add("iIdReport");
				dtAtenCom.Columns.Add("iIdCliente");
				dtAtenCom.Columns.Add("iIdAtencion");
				dtAtenCom.Columns.Add("iNumAtencion");
				dtAtenCom.Columns.Add("dFecha",System.Type.GetType("System.DateTime"));
				dtAtenCom.Columns.Add("sIdCliente");
				dtAtenCom.Columns.Add("sNombreCli");
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region Inicializar_dtRutas
		private void Inicializar_dtRutas()
		{
			try
			{
				dtRutas = new DataTable();

				dtRutas.Columns.Add("sIdRuta");
				dtRutas.Columns.Add("iIdRuta");
				dtRutas.Columns.Add("Desc");
				dtRutas.Columns.Add("Kilometros");
				dtRutas.Columns.Add("Chk");	
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region Inicializar_dtLineasGastos
		private void Inicializar_dtLineasGastos()
		{
			try
			{
				dtLineasGasto = new DataTable();
			
				dtLineasGasto.Columns.Add("iIdNota");
				dtLineasGasto.Columns.Add("idGasto");
				dtLineasGasto.Columns.Add("Gasto");
				dtLineasGasto.Columns.Add("fCantidad");
				dtLineasGasto.Columns.Add("fPrecio",System.Type.GetType("System.Double"));
				dtLineasGasto.Columns.Add("fImpLinea",System.Type.GetType("System.Double"));
				dtLineasGasto.Columns.Add("tObservaciones");
				dtLineasGasto.Columns.Add("sIdCentroCoste");
				dtLineasGasto.Columns.Add("sCentroCoste");
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}

        //---- GSG (26/03/2012)
        private void Inicializar_dtLineasViewGastos()
        {
            try
            {
                dtLineasViewGasto = new DataTable();

                dtLineasViewGasto.Columns.Add("iIdNota", System.Type.GetType("System.Int32"));
                dtLineasViewGasto.Columns.Add("iIdGasto", System.Type.GetType("System.Int32"));
                dtLineasViewGasto.Columns.Add("DescripGasto");
                dtLineasViewGasto.Columns.Add("fCantidad", System.Type.GetType("System.Double"));
                dtLineasViewGasto.Columns.Add("fPrecio", System.Type.GetType("System.Double"));
                dtLineasViewGasto.Columns.Add("ImporteGasto", System.Type.GetType("System.Double"));
                dtLineasViewGasto.Columns.Add("DescripLinea");
                dtLineasViewGasto.Columns.Add("sIdCentroCoste");
                dtLineasViewGasto.Columns.Add("sCentroCoste");
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }
		#endregion


		#region Inicializar Botonera
		private void Inicializar_Botonera()
		{
			try
			{
				this.ucBotoneraSecundaria1.btSalir.Click += new EventHandler(btSalir_Click);			
				this.ucBotoneraSecundaria1.btGrabar.Click += new EventHandler(btGrabar_Click);
				
				if(this.ParamTipoAcceso!="C")
				{
					this.ucBotoneraSecundaria1.Activar_botonera(true,false,false,false,true,false);
				}
				else
				{
					this.ucBotoneraSecundaria1.Activar_botonera(true,false,false,false,false,false);
				}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion


		#region RecuperarNotaGastos
		private void RecuperarNotaGastos()
		{
			try
			{
				this.sqldaGetNotaGastos.SelectCommand.Parameters["@iIdNota"].Value=this.ParamIdNota;
				this.sqldaGetNotaGastos.Fill(this.dsGastos1);
				if(this.dsGastos1.GetNotaGastos.Rows.Count==1)
				{
					this.dtpFecha.Value = DateTime.Parse(this.dsGastos1.GetNotaGastos.Rows[0]["dFecha"].ToString());
					this.txtObservaciones.Text = this.dsGastos1.GetNotaGastos.Rows[0]["tObservaciones"].ToString();
					this.txtFechaAprob.Text = this.dsGastos1.GetNotaGastos.Rows[0]["tFechaAprob"].ToString();
					this.txtFechaLIq.Text = this.dsGastos1.GetNotaGastos.Rows[0]["tFechaLiq"].ToString();
					if(this.dsGastos1.GetNotaGastos.Rows[0]["bVisa"].ToString()=="0") this.chkVisa.Checked = false;
					else this.chkVisa.Checked = true;
					this.bEnviadoCEN=int.Parse(this.dsGastos1.GetNotaGastos.Rows[0]["bEnviadoCEN"].ToString());

//					this.lblTotImporte.Text=this.dsGastos1.GetNotaGastos.Rows[0]["ImpTotal"].ToString("N2");
				}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region Cargar_AtencionesComerciales
		private void Cargar_AtencionesComerciales()
		{
			try
			{
				this.dsGastos1.ListaAtencionesCom.Rows.Clear();
				this.dtAtenCom.Rows.Clear();
				TotalAtts=0;

				string Fecha="";

				if(this.ParamTipoAcceso=="C") Fecha = "01/01/1900";
				else Fecha=this.dtpFecha.Value.ToShortDateString();

				this.sqldaListaAtenCom.SelectCommand.Parameters["@iIdNota"].Value = this.ParamIdNota;
				this.sqldaListaAtenCom.SelectCommand.Parameters["@dFecha"].Value = DateTime.Parse(Fecha);					
				this.sqldaListaAtenCom.SelectCommand.Parameters["@iIdDelegado"].Value = Clases.Configuracion.iIdDelegado;
			
				this.sqldaListaAtenCom.Fill(this.dsGastos1);
				
				for(int i=0;i<this.dsGastos1.ListaAtencionesCom.Rows.Count;i++)
				{
					DataRow filaAten = dtAtenCom.NewRow();				
					filaAten["Descripcion"]=this.dsGastos1.ListaAtencionesCom.Rows[i]["sIdAtencion"];							
					filaAten["idAtt"]=this.dsGastos1.ListaAtencionesCom.Rows[i]["sIdAtencion"];	
					filaAten["fImporteReal"]=this.dsGastos1.ListaAtencionesCom.Rows[i]["fImporte"];
					filaAten["iIdNota"]=this.dsGastos1.ListaAtencionesCom.Rows[i]["iIdNota"];									
					filaAten["iIdReport"]=this.dsGastos1.ListaAtencionesCom.Rows[i]["iIdReport"];									
					filaAten["iIdCliente"]=this.dsGastos1.ListaAtencionesCom.Rows[i]["iIdCliente"];									
					filaAten["iIdAtencion"]=this.dsGastos1.ListaAtencionesCom.Rows[i]["iIdAtencion"];									
					filaAten["iNumAtencion"]=this.dsGastos1.ListaAtencionesCom.Rows[i]["iNumAtencion"];									
					filaAten["dFecha"]=this.dsGastos1.ListaAtencionesCom.Rows[i]["dFecha"];
					filaAten["sIdCliente"]=this.dsGastos1.ListaAtencionesCom.Rows[i]["sIdCliente"];
					filaAten["sNombreCli"]=this.dsGastos1.ListaAtencionesCom.Rows[i]["sNombreCli"];

					dtAtenCom.Rows.Add(filaAten);					
						
					TotalAtts += Convert.ToDouble(dtAtenCom.Rows[i]["fImporteReal"].ToString());
				}
				
				dtgAtencionesCom.DataSource = dtAtenCom;
				this.lblTotalAtts.Text = TotalAtts.ToString("N2");
				this.lblTotAtenciones.Text = this.dtAtenCom.Rows.Count.ToString();

				this.TotalImporte = this.TotalAtts+this.TotalLineas;
				this.lblTotImporte.Text= this.TotalImporte.ToString("N2");
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region Cargar_GastosFijos
		private void Cargar_GastosFijos()
		{	
			try
			{

				for(int i=0;i<this.dsGastos1.ListaGastos.Rows.Count;i++)
				{	
					//si bSistem es 1 o 2 son gastos fijos, los segundos van enlazados al delegado.
                    //---- GSG (20/09/2013)
					//if(this.dsGastos1.ListaGastos.Rows[i]["bSistema"].ToString()=="1"  || this.dsGastos1.ListaGastos.Rows[i]["bSistema"].ToString()=="2" )
                    if (this.dsGastos1.ListaGastos.Rows[i]["bSistema"].ToString() == "1" || this.dsGastos1.ListaGastos.Rows[i]["bSistema"].ToString() == "2" || this.dsGastos1.ListaGastos.Rows[i]["bSistema"].ToString() == "3")
					{
						DataRow fila = this.dtLineasGasto.NewRow();
						
						fila["idGasto"] = Int32.Parse(this.dsGastos1.ListaGastos.Rows[i]["iIdGasto"].ToString());
						fila["Gasto"] = this.dsGastos1.ListaGastos.Rows[i]["sDescripcion"].ToString();
						fila["fCantidad"] = 0;
						fila["fPrecio"] = float.Parse(this.dsGastos1.ListaGastos.Rows[i]["fPrecio"].ToString());
                        fila["fImpLinea"] = 0;
                        fila["tObservaciones"] = "";
						fila["sIdCentroCoste"] = this.dsGastos1.ListaGastos.Rows[i]["sCosteSAP"].ToString();
						fila["sCentroCoste"] = this.dsGastos1.ListaGastos.Rows[i]["tCosteSAP"].ToString();

						this.dtLineasGasto.Rows.Add(fila);
					}
				}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}

        //---- GSG (26/03/2012)
        private void Cargar_GastosFijosView()
        {
            try
            {

                for (int i = 0; i < this.dsGastos1.ListaGastos.Rows.Count; i++)
                {
                    //si bSistem es 1 o 2 son gastos fijos, los segundos van enlazados al delegado.
                    //---- GSG (20/04/2013)
                    //if (this.dsGastos1.ListaGastos.Rows[i]["bSistema"].ToString() == "1" || this.dsGastos1.ListaGastos.Rows[i]["bSistema"].ToString() == "2")
                    if (this.dsGastos1.ListaGastos.Rows[i]["bSistema"].ToString() == "1" || this.dsGastos1.ListaGastos.Rows[i]["bSistema"].ToString() == "2" || this.dsGastos1.ListaGastos.Rows[i]["bSistema"].ToString() == "3")
                    {
                        DataRow fila = this.dtLineasViewGasto.NewRow();

                        fila["iIdGasto"] = Int32.Parse(this.dsGastos1.ListaGastos.Rows[i]["iIdGasto"].ToString());
                        fila["DescripGasto"] = this.dsGastos1.ListaGastos.Rows[i]["sDescripcion"].ToString();
                        fila["fCantidad"] = 0;
                        fila["fPrecio"] = float.Parse(this.dsGastos1.ListaGastos.Rows[i]["fPrecio"].ToString());
                        fila["ImporteGasto"] = 0;
                        fila["DescripLinea"] = "";
                        fila["sIdCentroCoste"] = this.dsGastos1.ListaGastos.Rows[i]["sCosteSAP"].ToString();
                        fila["sCentroCoste"] = this.dsGastos1.ListaGastos.Rows[i]["tCosteSAP"].ToString();

                        this.dtLineasViewGasto.Rows.Add(fila);
                    }
                }
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }
		#endregion

		#region Cargar_LineasNotaGastos
		private void Cargar_LineasNotaGastos()
		{
			try
			{
				this.dtLineasGasto.Rows.Clear();

				TotalLineas=0;

				if(this.ParamTipoAcceso=="A") 
						Cargar_GastosFijos();
				else
				{
					this.dsGastos1.ListaLineasNotasGasto.Rows.Clear();

					this.sqldaLineasGasto.SelectCommand.Parameters["@iIdNota"].Value = this.ParamIdNota;
					this.sqldaLineasGasto.SelectCommand.Parameters["@Param"].Value = this.ParamTipoAcceso;
					this.sqldaLineasGasto.SelectCommand.Parameters["@iIdDelegado"].Value = this.ParamiIdDelegado;
					this.sqldaLineasGasto.Fill(this.dsGastos1);
					
					for(int i=0;i<this.dsGastos1.ListaLineasNotasGasto.Rows.Count;i++)
					{

						DataRow filaLinGasto = dtLineasGasto.NewRow();				
						filaLinGasto["iIdNota"]=this.dsGastos1.ListaLineasNotasGasto.Rows[i]["iIdNota"];																			
						filaLinGasto["idGasto"]=this.dsGastos1.ListaLineasNotasGasto.Rows[i]["iIdGasto"];	
						filaLinGasto["Gasto"]=this.dsGastos1.ListaLineasNotasGasto.Rows[i]["DescripGasto"];													
						filaLinGasto["fCantidad"]=float.Parse(this.dsGastos1.ListaLineasNotasGasto.Rows[i]["fCantidad"].ToString());							
						filaLinGasto["fPrecio"]=float.Parse(this.dsGastos1.ListaLineasNotasGasto.Rows[i]["fPrecio"].ToString());							
						filaLinGasto["fImpLinea"]=float.Parse(this.dsGastos1.ListaLineasNotasGasto.Rows[i]["ImporteGasto"].ToString());							
						filaLinGasto["tObservaciones"]=this.dsGastos1.ListaLineasNotasGasto.Rows[i]["DescripLinea"];							
						filaLinGasto["sIdCentroCoste"]=this.dsGastos1.ListaLineasNotasGasto.Rows[i]["sIdCentroCoste"];							
						filaLinGasto["sCentroCoste"]=this.dsGastos1.ListaLineasNotasGasto.Rows[i]["sCentroCoste"];							

						dtLineasGasto.Rows.Add(filaLinGasto);					
					
						TotalLineas += Convert.ToDouble(this.dsGastos1.ListaLineasNotasGasto.Rows[i]["ImporteGasto"].ToString());
					
					}

				}
	
                //---- GSG (07/11/2011) Canvi de N4 a N2
                //---- GSG (26/01/2012) Canvi de N2 a N4 ho tornem a deixar com estava
				this.lblLineas.Text = TotalLineas.ToString("N4");
                //this.lblLineas.Text = TotalLineas.ToString("N2");
                //---- FI GSG
				this.lblTotLineas.Text = this.dtLineasGasto.Rows.Count.ToString();
				this.dtgLineasNotasDeGasto.DataSource = dtLineasGasto;

			
				if(this.dtLineasGasto.Rows.Count!=0)
				{
					Utiles.Seleccionar_UnaFilaDataGrid(this,this.dtgLineasNotasDeGasto,0);
					Cargar_LineaNotaGastos();
				}
				this.TotalImporte = this.TotalAtts+this.TotalLineas;
				this.lblTotImporte.Text= this.TotalImporte.ToString("N2");
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}

        //---- GSG (26/03/2012)
        private void Cargar_LineasViewNotaGastos()
        {
            try
			{
				this.dtLineasViewGasto.Rows.Clear();

				TotalLineas=0;

				if(this.ParamTipoAcceso=="A")
                    Cargar_GastosFijosView();
				else
				{
					this.dsGastos1.ListaLineasNotasGasto.Rows.Clear();

					this.sqldaLineasNotasGasto.SelectCommand.Parameters["@iIdNota"].Value = this.ParamIdNota;
					this.sqldaLineasNotasGasto.Fill(this.dsGastos1);
					
                    Application.DoEvents();
                    sqldaLineasNotasGasto.Fill(dtLineasViewGasto);
                    Application.DoEvents();


                    //dtgViewLineasNotasDeGasto.DataSource = dtLineasViewGasto;

				}

                this.lblLineas.Text = TotalLineas.ToString("N4");
                this.lblTotLineas.Text = this.dtLineasViewGasto.Rows.Count.ToString();
                this.dtgViewLineasNotasDeGasto.DataSource = dtLineasViewGasto;


                if (this.dtgViewLineasNotasDeGasto.SelectedRows.Count > 0)
                {                    
                    Cargar_LineaViewNotaGastos();
                }
                this.TotalImporte = this.TotalAtts + this.TotalLineas;
                this.lblTotImporte.Text = this.TotalImporte.ToString("N2");
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
        }
        
		#endregion

		#region Cargar_Rutas
		private void Cargar_Rutas()
		{
			try
			{
				this.dtRutas.Rows.Clear();
				this.dsGastos1.ListaRutas.Rows.Clear();
				this.dsGastos1.ListaRutasNotaGasto.Rows.Clear();
				this.ResultadoKms=0;

				this.sqldaListaRutas.SelectCommand.Parameters["@idDelegado"].Value = this.ParamiIdDelegado;
				this.sqldaListaRutas.Fill(this.dsGastos1);

				this.sqldaListaRutasNotasGasto.SelectCommand.Parameters["@iIdNota"].Value = this.ParamIdNota;			
				this.sqldaListaRutasNotasGasto.Fill(this.dsGastos1);
					
				bool encontrada = false;
				int iIdRuta=-1;
				string sIdRuta="";
				int  iKilometros=0;
				string sDescripcion="";
				
				for(int i=0;i<this.dsGastos1.ListaRutas.Rows.Count;i++)
				{
					iIdRuta = Int32.Parse(this.dsGastos1.ListaRutas.Rows[i]["iIdRuta"].ToString());
					sIdRuta = this.dsGastos1.ListaRutas.Rows[i]["sIdRuta"].ToString();
					sDescripcion = this.dsGastos1.ListaRutas.Rows[i]["sDescripcion"].ToString();
					iKilometros = Int32.Parse(this.dsGastos1.ListaRutas.Rows[i]["iKilometros"].ToString());

					DataRow fRuta = dtRutas.NewRow();				
				
					fRuta["sIdRuta"]=this.dsGastos1.ListaRutas.Rows[i]["sIdRuta"].ToString();											
					fRuta["iIdRuta"]=Int32.Parse(this.dsGastos1.ListaRutas.Rows[i]["iIdRuta"].ToString());											
					fRuta["Desc"]=this.dsGastos1.ListaRutas.Rows[i]["sDescripcion"].ToString();											
					fRuta["Kilometros"]=Int32.Parse(this.dsGastos1.ListaRutas.Rows[i]["iKilometros"].ToString());	

					dtRutas.Rows.Add(fRuta);

					encontrada=false;
					for (int y=0;y<this.dsGastos1.ListaRutasNotaGasto.Rows.Count;y++)
					{
						if (Int32.Parse(this.dsGastos1.ListaRutasNotaGasto.Rows[y]["iIdRuta"].ToString()) == iIdRuta)
						{
							encontrada = true;
							break;
						}
					}

					if (encontrada)
					{
						chkListBoxRutas.Items.Add(sIdRuta+" - "+sDescripcion+ " - "+ iKilometros +" Kms",true);
						fRuta["Chk"]=1;
						this.ResultadoKms += iKilometros; 
					}
					else
					{
						chkListBoxRutas.Items.Add(sIdRuta+" - "+sDescripcion+ " - "+ iKilometros +" Kms",false);
						fRuta["Chk"]=0;
					}
				}			
				chkListBoxRutas.MultiColumn = true;
				chkListBoxRutas.ColumnWidth = 200;

				this.lblKms.Text = this.ResultadoKms.ToString();
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion


		#region dtpFecha_ValueChanged
		private void dtpFecha_ValueChanged(object sender, System.EventArgs e)
		{
//			MessageBox.Show("soy el cambio");
		}
		#endregion


		#region chkListBoxRutas_ItemCheck
		private void chkListBoxRutas_ItemCheck(object sender, System.Windows.Forms.ItemCheckEventArgs e)
		{
			try
			{
				if (e.CurrentValue.ToString() == "Unchecked")
				{
					ResultadoKms = ResultadoKms + Convert.ToInt32(this.dtRutas.Rows[e.Index]["Kilometros"].ToString());
					dtRutas.Rows[e.Index]["Chk"] = 1;
				}
				else
				{
					ResultadoKms = ResultadoKms - Convert.ToInt32(this.dtRutas.Rows[e.Index]["Kilometros"].ToString());
					dtRutas.Rows[e.Index]["Chk"] = 0;
				}
				this.lblKms.Text = ResultadoKms.ToString();
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion


		#region dtgLineasNotasDeGasto_CurrentCellChanged
		private void dtgLineasNotasDeGasto_CurrentCellChanged(object sender, System.EventArgs e)
		{
			try
			{
				int fila = this.dtgLineasNotasDeGasto.CurrentRowIndex;
				Utiles.Seleccionar_UnaFilaDataGrid(this,this.dtgLineasNotasDeGasto,fila);
				Cargar_LineaNotaGastos();
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region Cargar_LineaNotaGastos
		private void Cargar_LineaNotaGastos()
		{
			try
			{
				int iIdGasto=-1;
				if(this.dtgLineasNotasDeGasto.CurrentRowIndex!=-1)
				{
					iIdGasto = Int32.Parse(this.dtgLineasNotasDeGasto[this.dtgLineasNotasDeGasto.CurrentRowIndex,1].ToString());
				}


				if (dsGastos1.ListaGastos.Select("iIdGasto = " + iIdGasto.ToString()).Length <= 0)
				{
					
					this.cboGasto.Text = "";;
					this.nmrCantidad.Value = 0;
					this.nupPrecio.Value = 0;
					this.cboCCoste.Text = "";;
					this.txbDescrip.Text = "";
					
					cboGasto.Enabled = false;
					nmrCantidad.Enabled = false;
					nupPrecio.Enabled = false;
					cboCCoste.Enabled = false;
					txbDescrip.Enabled = false;

					btActualizarLinea.Enabled = false;
					
				}
				else 
				{

					btActualizarLinea.Enabled = true;

					cboGasto.Enabled = true;
					nmrCantidad.Enabled = true;
					nupPrecio.Enabled = true;
					cboCCoste.Enabled = true;
					txbDescrip.Enabled = true;

					this.cboGasto.SelectedValue = iIdGasto;	
					this.nmrCantidad.Value = Int32.Parse(this.dtgLineasNotasDeGasto[this.dtgLineasNotasDeGasto.CurrentRowIndex,6].ToString());		
					this.nupPrecio.Value = Decimal.Parse(this.dtgLineasNotasDeGasto[this.dtgLineasNotasDeGasto.CurrentRowIndex,7].ToString());		
					this.cboCCoste.SelectedValue = this.dtgLineasNotasDeGasto[this.dtgLineasNotasDeGasto.CurrentRowIndex,3].ToString();
					this.txbDescrip.Text = this.dtgLineasNotasDeGasto[this.dtgLineasNotasDeGasto.CurrentRowIndex,5].ToString();		
			
					int fila = Utiles.Buscar_fila_dtTabla(this.dsGastos1.ListaGastos,"iIdGasto",this.cboGasto.SelectedValue.ToString());

					if(fila!=-1)
					{
					
						string GastoFijo = this.dsGastos1.ListaGastos.Rows[fila]["bSistema"].ToString();
					
                        //---- GSG (20/09/2013)
						//if (GastoFijo=="1" || GastoFijo=="2" )
                        //---- GSG (15/06/2015) Volver a dejar el gasto tipo 3 como antes
                        //if (GastoFijo == "1" || GastoFijo == "2" || GastoFijo == "3")
                        if (GastoFijo == "1" || GastoFijo == "2") 
							this.nupPrecio.Enabled = false;
						else 
							this.nupPrecio.Enabled = true;
			
						string sIdCentroCoste = this.dsGastos1.ListaGastos.Rows[fila]["sCosteSAP"].ToString();
						if (sIdCentroCoste.Length==0)
						{
							this.cboCCoste.Visible = true;
							this.lblCCoste.Visible = true;
						}
						else
						{
							this.cboCCoste.Visible = false;
							this.lblCCoste.Visible = false;
						}

					}

				}

			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}

        private void Cargar_LineaViewNotaGastos()
        {
            try
            {
                int iIdGasto = -1;
                if (this.dtgViewLineasNotasDeGasto.SelectedRows.Count > 0)
                {
                    iIdGasto = Int32.Parse(this.dtgViewLineasNotasDeGasto.SelectedRows[0].Cells[1].Value.ToString());
                }


                if (dsGastos1.ListaGastos.Select("iIdGasto = " + iIdGasto.ToString()).Length <= 0)
                {

                    this.cboGasto.Text = ""; ;
                    this.nmrCantidad.Value = 0;
                    this.nupPrecio.Value = 0;
                    this.cboCCoste.Text = ""; ;
                    this.txbDescrip.Text = "";

                    cboGasto.Enabled = false;
                    nmrCantidad.Enabled = false;
                    nupPrecio.Enabled = false;
                    cboCCoste.Enabled = false;
                    txbDescrip.Enabled = false;

                    btActualizarLinea.Enabled = false;

                }
                else
                {

                    btActualizarLinea.Enabled = true;

                    cboGasto.Enabled = true;
                    nmrCantidad.Enabled = true;
                    nupPrecio.Enabled = true;
                    cboCCoste.Enabled = true;
                    txbDescrip.Enabled = true;

                    this.cboGasto.SelectedValue = iIdGasto;
                    this.nmrCantidad.Value = Int32.Parse(this.dtgViewLineasNotasDeGasto.SelectedRows[0].Cells[6].Value.ToString());
                    this.nupPrecio.Value = Decimal.Parse(this.dtgViewLineasNotasDeGasto.SelectedRows[0].Cells[7].Value.ToString());
                    this.cboCCoste.SelectedValue = this.dtgViewLineasNotasDeGasto.SelectedRows[0].Cells[3].Value.ToString();
                    this.txbDescrip.Text = this.dtgViewLineasNotasDeGasto.SelectedRows[0].Cells[5].Value.ToString();

                    int fila = Utiles.Buscar_fila_dtTabla(this.dsGastos1.ListaGastos, "iIdGasto", this.cboGasto.SelectedValue.ToString());

                    if (fila != -1)
                    {

                        string GastoFijo = this.dsGastos1.ListaGastos.Rows[fila]["bSistema"].ToString();

                        //---- GSG (20/09/2013)
                        //if (GastoFijo == "1" || GastoFijo == "2")
                        //---- GSG (15/06/2015) Volver a dejar el gasto tipo 3 como antes
                        //if (GastoFijo == "1" || GastoFijo == "2" || GastoFijo == "3")
                        if (GastoFijo == "1" || GastoFijo == "2")
                            this.nupPrecio.Enabled = false;
                        else
                            this.nupPrecio.Enabled = true;

                        string sIdCentroCoste = this.dsGastos1.ListaGastos.Rows[fila]["sCosteSAP"].ToString();
                        if (sIdCentroCoste.Length == 0)
                        {
                            this.cboCCoste.Visible = true;
                            this.lblCCoste.Visible = true;
                        }
                        else
                        {
                            this.cboCCoste.Visible = false;
                            this.lblCCoste.Visible = false;
                        }

                    }

                }

            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }
		#endregion		

		#region cboGasto_SelectedIndexChanged
		private void cboGasto_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				if(this.cboGasto.SelectedIndex!=-1)
				{
					int fila = Utiles.Buscar_fila_dtTabla(this.dsGastos1.ListaGastos,"iIdGasto",this.cboGasto.SelectedValue.ToString());

					if(fila!=-1)
					{
						this.nmrCantidad.Value = 0;			
					
						this.nupPrecio.Value = Decimal.Parse(this.dsGastos1.ListaGastos.Rows[fila]["fPrecio"].ToString());
						this.txbDescrip.Text = "";
			
						string GastoFijo = this.dsGastos1.ListaGastos.Rows[fila]["bSistema"].ToString();
					
                        //---- GSG (20/09/2013)
						//if (GastoFijo=="2" || GastoFijo=="1")
                        //---- GSG (15/06/2015) Volver a dejar el gasto tipo 3 como antes
                        //if (GastoFijo == "2" || GastoFijo == "1" || GastoFijo == "3")
                        if (GastoFijo == "2" || GastoFijo == "1") 
						    this.nupPrecio.Enabled = false;
						else 
							this.nupPrecio.Enabled = true;
			
						string sIdCentroCoste = this.dsGastos1.ListaGastos.Rows[fila]["sCosteSAP"].ToString();
						if (sIdCentroCoste.Length==0)
						{
							this.cboCCoste.Visible = true;
							this.lblCCoste.Visible   = true;
						}
						else
						{
							this.cboCCoste.Visible = false;
							this.lblCCoste.Visible = false;
						}
					}
				}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region nmrCantidad_ValueChanged
		private void nmrCantidad_ValueChanged(object sender, System.EventArgs e)
		{
			try
			{
				double Imp=0;
				if (this.cboGasto.SelectedIndex!=-1)
				{
					double Prec = Convert.ToDouble(this.nupPrecio.Value);
					int fila = Utiles.Buscar_fila_dtTabla(this.dsGastos1.ListaGastos,"iIdGasto",this.cboGasto.SelectedValue.ToString());

					if(fila!=-1)
					{
						string GastoFijo = this.dsGastos1.ListaGastos.Rows[fila]["bSistema"].ToString();
                        //---- GSG (20/09/2013)
						//if (GastoFijo=="True") Prec = Double.Parse(this.dsGastos1.ListaGastos.Rows[fila]["fPrecio"].ToString());
                        //---- GSG (15/06/2015) Volver a dejar el gasto tipo 3 como antes
                        //if (GastoFijo == "1" || GastoFijo == "2" || GastoFijo == "3")
                        if (GastoFijo == "1" || GastoFijo == "2") 
                            Prec = Double.Parse(this.dsGastos1.ListaGastos.Rows[fila]["fPrecio"].ToString());
					}					

					Imp = Convert.ToDouble(Convert.ToInt32(this.nmrCantidad.Value)*Prec);
                    //---- GSG (07/11/2011) Canvi de N4 a N2
                    //---- GSG (26/01/2012) Canvi de N2 a N4 ho tornem a deixar com estava
                    this.txtImpLinea.Text = Imp.ToString("N4");
                    //this.txtImpLinea.Text = Imp.ToString("N2");
                    //---- FI GSG
				}
                //---- GSG (07/11/2011) Canvi de N4 a N2
                //---- GSG (26/01/2012) Canvi de N2 a N4 ho tornem a deixar com estava
				this.txtImpLinea.Text = Imp.ToString("N4");
                //this.txtImpLinea.Text = Imp.ToString("N2");
                //---- FI GSG
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region nupPrecio_ValueChanged
		private void nupPrecio_ValueChanged(object sender, System.EventArgs e)
		{
			try
			{
				double Imp=0;
				double Prec=0;
				if (this.cboGasto.SelectedIndex!=-1)
				{
					Prec = Convert.ToDouble(this.nupPrecio.Value.ToString("N2"));
					int fila = Utiles.Buscar_fila_dtTabla(this.dsGastos1.ListaGastos,"iIdGasto",this.cboGasto.SelectedValue.ToString());

					if(fila!=-1)
					{
						string GastoFijo = this.dsGastos1.ListaGastos.Rows[fila]["bSistema"].ToString();
                        
                        //---- GSG (20/09/2013)
						//if (GastoFijo=="True") Prec = Double.Parse(this.dsGastos1.ListaGastos.Rows[fila]["fPrecio"].ToString());
                        //---- GSG (15/06/2015) Volver a dejar el gasto tipo 3 como antes
                        //if (GastoFijo == "1" || GastoFijo == "2" || GastoFijo == "3")
                        if (GastoFijo == "1" || GastoFijo == "2") 
                            Prec = Double.Parse(this.dsGastos1.ListaGastos.Rows[fila]["fPrecio"].ToString());
					}					

					 Imp = Convert.ToDouble(Convert.ToInt32(this.nmrCantidad.Value)*Prec);
				
					//double Imp = Convert.ToDouble(Convert.ToInt32(this.nmrCantidad.Value)*this.nupPrecio.Value);
				}
				this.txtImpLinea.Text = Imp.ToString("N2");
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion


		#region btEliminarLinea_Click
		private void btEliminarLinea_Click(object sender, System.EventArgs e)
		{
            //---- GSG (26/03/2012)
			//Eliminar_Linea();
            Eliminar_LineaView();
		}
		#endregion

		#region btActualizarLinea_Click
		private void btnActualizarLinea_Click(object sender, System.EventArgs e)
		{
            //---- GSG (26/03/2012)
			//Actualizar_Linea();
            if (SetDefault == true)
            {
                Mensajes.HideTip();
                dtgViewLineasNotasDeGasto.SelectedRows[0].Cells["fPrecioDataGridViewTextBoxColumn"].Value = DefaultImportValue;
                SetDefault = false;
            }

            Actualizar_LineaView();
		}
		#endregion

		#region menuEliminarLinea_Click
		private void menuEliminarLinea_Click(object sender, System.EventArgs e)
		{	
			Eliminar_Linea();
		}
		#endregion
		
		#region menuNuevaLinea_Click
		private void menuNuevaLinea_Click(object sender, System.EventArgs e)
		{
			Nueva_Linea();
		}
		#endregion

		#region Nueva_Linea
		private void Nueva_Linea()
		{
			try
			{
				this.cboGasto.SelectedIndex = -1;
				this.cboGasto.SelectedIndex = -1;
				this.nmrCantidad.Value = 0;
				this.nupPrecio.Value= 0;
				this.cboCCoste.SelectedIndex = -1;
				this.txbDescrip.Text = "";
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region Eliminar_Linea
		private void Eliminar_Linea()
		{
			try
			{
				double ImpLinea=0;

				if (this.dtgLineasNotasDeGasto.CurrentRowIndex != -1)
				{

					int fila = Utiles.Buscar_fila_dtTabla(this.dsGastos1.ListaGastos,"iIdGasto",this.cboGasto.SelectedValue.ToString());

					if(fila!=-1)
					{
						string GastoFijo = this.dsGastos1.ListaGastos.Rows[fila]["bSistema"].ToString();

                        //---- GSG (14/09/2011)                        
                        //if (GastoFijo=="True") Mensajes.ShowError("No se puede eliminar un gasto fijo");

                        //---- GSG (15/06/2015) Volver a dejar el gasto tipo 3 como antes
                        //---- GSG (20/09/2013)
                        //if (GastoFijo == "1" || GastoFijo == "2") Mensajes.ShowError("No se puede eliminar un gasto fijo");
                        //if (GastoFijo == "1" || GastoFijo == "2" || GastoFijo == "3") Mensajes.ShowError("No se puede eliminar un gasto fijo");
                        if (GastoFijo == "1" || GastoFijo == "2") Mensajes.ShowError("No se puede eliminar un gasto fijo");
                        //---- FI GSG
                        else	
						{
							ImpLinea = Convert.ToDouble(dtgLineasNotasDeGasto[this.dtgLineasNotasDeGasto.CurrentRowIndex,8].ToString());
							TotalLineas -= ImpLinea; 
							this.lblLineas.Text = TotalLineas.ToString("N2");

							string iIdGasto = this.dtgLineasNotasDeGasto[this.dtgLineasNotasDeGasto.CurrentRowIndex,1].ToString();
							int fila1 = Utiles.Buscar_fila_dtTabla(this.dtLineasGasto,"IdGasto",iIdGasto);
							this.dtLineasGasto.Rows.RemoveAt(fila1);
							this.lblTotLineas.Text = this.dtLineasGasto.Rows.Count.ToString();

							this.TotalImporte = this.TotalAtts+this.TotalLineas;
							this.lblTotImporte.Text= this.TotalImporte.ToString("N2");

							Nueva_Linea();
						}
					}
				}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}

        private void Eliminar_LineaView()
        {
            try
            {
                double ImpLinea = 0;

                if (this.dtgViewLineasNotasDeGasto.SelectedRows.Count > 0)
                {

                    int fila = Utiles.Buscar_fila_dtTabla(this.dsGastos1.ListaGastos, "iIdGasto", this.cboGasto.SelectedValue.ToString());

                    if (fila != -1)
                    {
                        string GastoFijo = this.dsGastos1.ListaGastos.Rows[fila]["bSistema"].ToString();

                        //---- GSG (15/06/2015) 
                        //---- GSG (20/09/2013)
                        //if (GastoFijo == "1" || GastoFijo == "2") Mensajes.ShowError("No se puede eliminar un gasto fijo");
                        //---- GSG (15/06/2015) Volver a dejar el gasto tipo 3 como antes
                        //if (GastoFijo == "1" || GastoFijo == "2" || GastoFijo == "3") Mensajes.ShowError("No se puede eliminar un gasto fijo");
                        if (GastoFijo == "1" || GastoFijo == "2") Mensajes.ShowError("No se puede eliminar un gasto fijo");
                        else
                        {
                            bBorrando = true;

                            ImpLinea = Convert.ToDouble(this.dtgViewLineasNotasDeGasto.SelectedRows[0].Cells[8].Value.ToString());
                            TotalLineas -= ImpLinea;
                            this.lblLineas.Text = TotalLineas.ToString("N2");

                            string iIdGasto = this.dtgViewLineasNotasDeGasto.SelectedRows[0].Cells[1].Value.ToString();
                            int fila1 = Utiles.Buscar_fila_dtTabla(this.dtLineasViewGasto, "iIdGasto", iIdGasto);
                            this.dtLineasViewGasto.Rows.RemoveAt(fila1);
                            //dtLineasViewGasto.AcceptChanges();
                            this.lblTotLineas.Text = this.dtLineasViewGasto.Rows.Count.ToString();

                            this.TotalImporte = this.TotalAtts + this.TotalLineas;
                            this.lblTotImporte.Text = this.TotalImporte.ToString("N2");

                            //Nueva_Linea();

                            bBorrando = false;
                        }
                    }
                }
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }
		#endregion
		
		#region Actualizar_Linea
		private void Actualizar_Linea()
		{
			try
			{
				if (Validar_Linea())
				{
					int fila = Utiles.Buscar_fila_dtTabla(this.dsGastos1.ListaGastos,"iIdGasto",this.cboGasto.SelectedValue.ToString());
					string GastoFijo = this.dsGastos1.ListaGastos.Rows[fila]["bSistema"].ToString();
					string sCosteSAP = this.dsGastos1.ListaGastos.Rows[fila]["sCosteSAP"].ToString();
						
					int fLinea = Utiles.Buscar_fila_dtTabla(this.dtLineasGasto,"idGasto",this.cboGasto.SelectedValue.ToString());

					double ImporteLin = Convert.ToDouble(Convert.ToInt32(this.nmrCantidad.Value)*this.nupPrecio.Value);
					double ImporteLinAntiguo = 0;
					if(fLinea==-1) //No existe esta línea de Gastos
					{

						DataRow filaDg = this.dtLineasGasto.NewRow();

						filaDg["iIdNota"]=this.ParamIdNota;
						filaDg["idGasto"]=this.cboGasto.SelectedValue.ToString();
						filaDg["Gasto"]=this.cboGasto.GetItemText(this.cboGasto.SelectedItem).ToString();
						filaDg["fCantidad"]=Convert.ToInt32(this.nmrCantidad.Value);
						filaDg["fPrecio"]=this.nupPrecio.Value;
						filaDg["fImpLinea"]=ImporteLin;
						filaDg["tObservaciones"]=txbDescrip.Text.ToString();			
			
						if (this.cboCCoste.Visible == false)
						{	
							filaDg["sIdCentroCoste"]=sCosteSAP;
							try
							{
								cboCCoste.SelectedValue=sCosteSAP;
								if(cboCCoste.SelectedIndex!=-1)
								{
									filaDg["sCentroCoste"]=this.cboCCoste.GetItemText(cboCCoste.SelectedItem).ToString();
								}
							}
							catch{}
						}
						else
						{
							filaDg["sIdCentroCoste"]=cboCCoste.SelectedValue.ToString();
							filaDg["sCentroCoste"]=this.cboCCoste.GetItemText(cboCCoste.SelectedItem).ToString();
						}
					
						this.dtLineasGasto.Rows.Add(filaDg);
					
					}
					else
					{
						this.dtLineasGasto.Rows[fLinea]["fCantidad"]=Convert.ToInt32(this.nmrCantidad.Value);
						this.dtLineasGasto.Rows[fLinea]["fPrecio"]=this.nupPrecio.Value;
						ImporteLinAntiguo = Convert.ToDouble(this.dtLineasGasto.Rows[fLinea]["fImpLinea"].ToString());
						this.dtLineasGasto.Rows[fLinea]["fImpLinea"]=ImporteLin;
						this.dtLineasGasto.Rows[fLinea]["tObservaciones"]=txbDescrip.Text.ToString();			
			
						if (this.cboCCoste.Visible == false)
						{	
							this.dtLineasGasto.Rows[fLinea]["sIdCentroCoste"]=sCosteSAP;
							try
							{
								cboCCoste.SelectedValue=sCosteSAP;
								if(cboCCoste.SelectedIndex!=-1)
								{
									this.dtLineasGasto.Rows[fLinea]["sCentroCoste"]=this.cboCCoste.GetItemText(cboCCoste.SelectedItem).ToString();
								}
							}
							catch{}
						}
						else
						{
							this.dtLineasGasto.Rows[fLinea]["sIdCentroCoste"]=cboCCoste.SelectedValue.ToString();
							this.dtLineasGasto.Rows[fLinea]["sCentroCoste"]=this.cboCCoste.GetItemText(cboCCoste.SelectedItem).ToString();
						}
					}
					this.TotalLineas = this.TotalLineas - ImporteLinAntiguo + ImporteLin;
					this.lblLineas.Text = TotalLineas.ToString("N2");
					this.lblTotLineas.Text = this.dtLineasGasto.Rows.Count.ToString();

					this.TotalImporte = this.TotalAtts+this.TotalLineas;
					this.lblTotImporte.Text= this.TotalImporte.ToString("N2");

					Nueva_Linea();
				}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}


        private void Actualizar_LineaView()
        {
            try
            {
                if (Validar_Linea())
                {
                    int fila = Utiles.Buscar_fila_dtTabla(this.dsGastos1.ListaGastos, "iIdGasto", this.cboGasto.SelectedValue.ToString());
                    string GastoFijo = this.dsGastos1.ListaGastos.Rows[fila]["bSistema"].ToString();
                    string sCosteSAP = this.dsGastos1.ListaGastos.Rows[fila]["sCosteSAP"].ToString();

                    int fLinea = Utiles.Buscar_fila_dtTabla(this.dtLineasViewGasto, "iIdGasto", this.cboGasto.SelectedValue.ToString());

                    double ImporteLin = Convert.ToDouble(Convert.ToInt32(this.nmrCantidad.Value) * this.nupPrecio.Value);
                    double ImporteLinAntiguo = 0;
                    if (fLinea == -1) //No existe esta línea de Gastos
                    {

                        DataRow filaDg = this.dtLineasViewGasto.NewRow();

                        filaDg["iIdNota"] = this.ParamIdNota;
                        filaDg["iIdGasto"] = this.cboGasto.SelectedValue.ToString();
                        filaDg["DescripGasto"] = this.cboGasto.GetItemText(this.cboGasto.SelectedItem).ToString();
                        filaDg["fCantidad"] = Convert.ToInt32(this.nmrCantidad.Value);
                        filaDg["fPrecio"] = this.nupPrecio.Value;
                        filaDg["ImporteGasto"] = ImporteLin;
                        filaDg["DescripLinea"] = txbDescrip.Text.ToString();

                        if (this.cboCCoste.Visible == false)
                        {
                            filaDg["sIdCentroCoste"] = sCosteSAP;
                            try
                            {
                                cboCCoste.SelectedValue = sCosteSAP;
                                if (cboCCoste.SelectedIndex != -1)
                                {
                                    filaDg["sCentroCoste"] = this.cboCCoste.GetItemText(cboCCoste.SelectedItem).ToString();
                                }
                            }
                            catch { }
                        }
                        else
                        {
                            filaDg["sIdCentroCoste"] = cboCCoste.SelectedValue.ToString();
                            filaDg["sCentroCoste"] = this.cboCCoste.GetItemText(cboCCoste.SelectedItem).ToString();
                        }

                        this.dtLineasViewGasto.Rows.Add(filaDg);

                    }
                    else
                    {
                        this.dtLineasViewGasto.Rows[fLinea]["fCantidad"] = Convert.ToInt32(this.nmrCantidad.Value);
                        this.dtLineasViewGasto.Rows[fLinea]["fPrecio"] = this.nupPrecio.Value;
                        ImporteLinAntiguo = Convert.ToDouble(this.dtLineasViewGasto.Rows[fLinea]["fPrecio"].ToString());
                        this.dtLineasViewGasto.Rows[fLinea]["ImporteGasto"] = ImporteLin;
                        this.dtLineasViewGasto.Rows[fLinea]["DescripLinea"] = txbDescrip.Text.ToString();

                        if (this.cboCCoste.Visible == false)
                        {
                            this.dtLineasViewGasto.Rows[fLinea]["sIdCentroCoste"] = sCosteSAP;
                            try
                            {
                                cboCCoste.SelectedValue = sCosteSAP;
                                if (cboCCoste.SelectedIndex != -1)
                                {
                                    this.dtLineasViewGasto.Rows[fLinea]["sCentroCoste"] = this.cboCCoste.GetItemText(cboCCoste.SelectedItem).ToString();
                                }
                            }
                            catch { }
                        }
                        else
                        {
                            this.dtLineasViewGasto.Rows[fLinea]["sIdCentroCoste"] = cboCCoste.SelectedValue.ToString();
                            this.dtLineasViewGasto.Rows[fLinea]["sCentroCoste"] = this.cboCCoste.GetItemText(cboCCoste.SelectedItem).ToString();
                        }
                    }

                    this.TotalLineas = this.TotalLineas - ImporteLinAntiguo + ImporteLin;
                    this.lblLineas.Text = TotalLineas.ToString("N2");
                    this.lblTotLineas.Text = this.dtLineasViewGasto.Rows.Count.ToString();

                    this.TotalImporte = this.TotalAtts + this.TotalLineas;
                    this.lblTotImporte.Text = this.TotalImporte.ToString("N2");

                    Nueva_Linea();
                }
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }
		#endregion

		#region Validar_Linea
		private bool Validar_Linea()
		{
			try
			{

				if(this.cboGasto.SelectedIndex==-1)
				{
					Mensajes.ShowError("Es obligatorio elegir un gasto.");
					return false;
				}

				if(this.cboCCoste.Visible && this.cboCCoste.SelectedIndex==-1)
				{
					Mensajes.ShowError("Es obligatorio elegir un Centro de Coste.");
					return false;
				}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message); return false;}

			return true;
		}
		#endregion
		

		#region btSalir_Click
		private void btSalir_Click(object sender, System.EventArgs e)
		{
			this.Close();				
		}
		#endregion

		#region frmGastos_Closing
		private void frmGastos_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			try
			{
				if(!SalirDesdeGuardar)								
				{
					//Va a salir ¿desea guardar los los cambios?
					DialogResult dr1=Mensajes.ShowQuestion(3002);
					if(dr1 == System.Windows.Forms.DialogResult.Yes)
					{
						if(Validar_NotaGastos())
						{
							if(Grabar_NotaGastos())
							{
								Mensajes.ShowInformation(3004);
							}
							else
							{
								e.Cancel=true;
							}
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

		#region frmGastos_Closed
		private void frmGastos_Closed(object sender, System.EventArgs e)
		{
			this.Dispose();
		}
		#endregion

		#region btGrabar_Click
		private void btGrabar_Click(object sender, System.EventArgs e)
		{	
			try
			{
				if(Validar_NotaGastos())
				{
					if (Grabar_NotaGastos())
					{
						//Los datos se han guardado correctamente. ¿Desea salir?					
						//DialogResult dr = Mensajes.ShowQuestion(3003);

						Mensajes.ShowInformation(3004);
						this.SalirDesdeGuardar=true;
						this.Close();
					
					
					}
				}
			}
			catch(Exception ex)
			{
				Mensajes.ShowError(ex.Message);
			}
		}
		#endregion

		#region Grabar_NotaGastos
		private bool Grabar_NotaGastos()
		{
			bool	resultado=true;
			int		iIdNota = this.ParamIdNota;
			string	sIdNotaTemp = "";
			int		bVisa = 0;
			int		Accion=Utiles.Transformar_TipoAcceso(this.ParamTipoAcceso);
			string sMensj="";

			if (this.chkVisa.Checked) bVisa = 1;
			else bVisa = 0;

            //---- GSG (10/09/2014)
            //sqlConn.Open();
            if (sqlConn.State == ConnectionState.Closed)
                sqlConn.Open();


			this.sqlTran = this.sqlConn.BeginTransaction();

			this.sqlCmdSetNotasGastos.Transaction = sqlTran;
			this.sqlCmdSetNotasDeGastosLineas.Transaction = sqlTran;
			this.sqlCmdSetAtencionesNotasGasto.Transaction = sqlTran;
			this.sqlCmdSetRutasNotasGastos.Transaction = sqlTran;

			try
			{
				//Grabar Nota de Gastos
				sqlCmdSetNotasGastos.Parameters["@iAccion"].Value = Accion;
				sqlCmdSetNotasGastos.Parameters["@iIdNota"].Value = iIdNota;							
				sqlCmdSetNotasGastos.Parameters["@sIdNotaTemp"].Value = sIdNotaTemp;
				sqlCmdSetNotasGastos.Parameters["@idDelegado"].Value = this.ParamiIdDelegado;
				sqlCmdSetNotasGastos.Parameters["@dFecha"].Value = this.dtpFecha.Value.ToShortDateString();
				sqlCmdSetNotasGastos.Parameters["@bVisa"].Value = bVisa;
				sqlCmdSetNotasGastos.Parameters["@tObservaciones"].Value = this.txtObservaciones.Text;
				sqlCmdSetNotasGastos.ExecuteNonQuery();

				if(Accion==0)
				{
					iIdNota=Int32.Parse(this.sqlCmdSetNotasGastos.Parameters["@iIdNota"].Value.ToString());
					sIdNotaTemp=this.sqlCmdSetNotasGastos.Parameters["@sIdNotaTemp"].Value.ToString();
				}


				//Borrar líneas de Notas de Gastos
				sqlCmdSetNotasDeGastosLineas.Parameters["@iAccion"].Value = 2;
				sqlCmdSetNotasDeGastosLineas.Parameters["@iIdNota"].Value = iIdNota;		
				sqlCmdSetNotasDeGastosLineas.ExecuteNonQuery();	

				//Grabar lineas de Notas de Gastos
                //---- GSG (26/03/2012)
				//CurrencyManager cm = (CurrencyManager)this.BindingContext[this.dtgLineasNotasDeGasto.DataSource,this.dtgLineasNotasDeGasto.DataMember];
                CurrencyManager cm = (CurrencyManager)this.BindingContext[this.dtgViewLineasNotasDeGasto.DataSource, this.dtgLineasNotasDeGasto.DataMember];
                //---- FI GSG
				DataView dvLG = (DataView)cm.List;

				for(int i=0;i<dvLG.Count;i++)
				{	
					sqlCmdSetNotasDeGastosLineas.Parameters["@iAccion"].Value = 0;
					sqlCmdSetNotasDeGastosLineas.Parameters["@iIdNota"].Value = iIdNota;
                    //---- GSG (26/03/2012) 
					//sqlCmdSetNotasDeGastosLineas.Parameters["@iIdGasto"].Value = Int32.Parse(dvLG[i]["IdGasto"].ToString());
                    sqlCmdSetNotasDeGastosLineas.Parameters["@iIdGasto"].Value = Int32.Parse(dvLG[i]["iIdGasto"].ToString());
					//
                    sqlCmdSetNotasDeGastosLineas.Parameters["@fCantidad"].Value = Int32.Parse(dvLG[i]["fCantidad"].ToString());
					sqlCmdSetNotasDeGastosLineas.Parameters["@fPrecio"].Value = Convert.ToDouble(dvLG[i]["fPrecio"].ToString());
                    //---- GSG (26/03/2012) 
                    //sqlCmdSetNotasDeGastosLineas.Parameters["@tDescripcion"].Value = dvLG[i]["tObservaciones"].ToString();
                    sqlCmdSetNotasDeGastosLineas.Parameters["@tDescripcion"].Value = dvLG[i]["DescripLinea"].ToString();
                    //
                    sqlCmdSetNotasDeGastosLineas.Parameters["@sIdCentroCoste"].Value = dvLG[i]["sIdCentroCoste"].ToString();		
					sqlCmdSetNotasDeGastosLineas.ExecuteNonQuery();	
				}

				//Borrar AtencionesComerciales asociadas a Notas de Gastos
				sqlCmdSetAtencionesNotasGasto.Parameters["@iAccion"].Value = 2;									
				sqlCmdSetAtencionesNotasGasto.Parameters["@iIdNota"].Value = iIdNota;				
				sqlCmdSetAtencionesNotasGasto.ExecuteNonQuery(); 

				//Grabar AtencionesComerciales asociadas a Notas de Gastos
				for(int i=0;i<this.dtAtenCom.Rows.Count;i++)
				{
					sqlCmdSetAtencionesNotasGasto.Parameters["@iAccion"].Value = 0;									
					sqlCmdSetAtencionesNotasGasto.Parameters["@iIdReport"].Value = Int32.Parse(this.dtAtenCom.Rows[i]["iIdReport"].ToString());				
					sqlCmdSetAtencionesNotasGasto.Parameters["@iIdCliente"].Value = Int32.Parse(this.dtAtenCom.Rows[i]["iIdCliente"].ToString());				
					sqlCmdSetAtencionesNotasGasto.Parameters["@idAtencion"].Value = Int32.Parse(this.dtAtenCom.Rows[i]["iIdAtencion"].ToString());				
					sqlCmdSetAtencionesNotasGasto.Parameters["@iNumAtencion"].Value = int.Parse(this.dtAtenCom.Rows[i]["iNumAtencion"].ToString());				
					sqlCmdSetAtencionesNotasGasto.Parameters["@iIdNota"].Value = iIdNota;				
					sqlCmdSetAtencionesNotasGasto.ExecuteNonQuery(); 
				}

				//Borrar Rutas asociadas a la Nota de Gastos
//				sqlCmdSetRutasNotasGastos.Parameters["@iAccion"].Value = 2;										
//				sqlCmdSetRutasNotasGastos.Parameters["@iIdNota"].Value = iIdNota;	
//				sqlCmdSetRutasNotasGastos.ExecuteNonQuery();
//
//				//Grabar Rutas asociadas a la Nota de Gastos
//				for(int i=0;i<this.dtRutas.Rows.Count;i++)
//				{
//					if (this.dtRutas.Rows[i][4].ToString() == "1")
//					{
//						sqlCmdSetRutasNotasGastos.Parameters["@iAccion"].Value = 0;										
//						sqlCmdSetRutasNotasGastos.Parameters["@iIdRuta"].Value = Int32.Parse(dtRutas.Rows[i][1].ToString());
//						sqlCmdSetRutasNotasGastos.Parameters["@iIdNota"].Value = iIdNota;	
//						sqlCmdSetRutasNotasGastos.ExecuteNonQuery();
//					}
//				}

				this.ParamIdNota=iIdNota;
				this.sqlTran.Commit();
				resultado=true;
			}
			catch(System.Data.SqlClient.SqlException ex)
			{
				sMensj ="Error al actualizar Nota de Gastos: ";
				foreach(System.Data.SqlClient.SqlError Err in ex.Errors)
				{
					sMensj +=Err.Number.ToString()+" - "+Err.Message.ToString();
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

		#region Validar_NotaGastos
		private bool Validar_NotaGastos()
		{
			try
			{
                //---- GSG (28/03/2012)
				//if(this.dtLineasGasto.Rows.Count==0)
                if (this.dtLineasViewGasto.Rows.Count == 0)
				{
					Mensajes.ShowError("Es obligatorio introducir como mínimo una línea en la Nota de Gastos.");
					return false;
				}

				if(this.ParamTipoAcceso=="A" && this.dtpFecha.CustomFormat==" ")
				{
					Mensajes.ShowError("Es obligatorio introducir la Fecha en la Nota de Gastos.");
					return false;
				}

                //---- GSG (23/09/2013)
                //Controla fechas inferiores al día de hoy porque las posteriores ya no se pueden introducir
                //Sólo se pueden introducir notas con fechas del mes actual o bien del mes anterior cuando la fecha actual no supera la fecha máxima
                DateTime fecMax = getFecMaxNota(); //Es un día concreto del mes actual o , a partir de GSG(07/03/2017) una fecha que supondrá no restringir 
                string[] meses = { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"};
                string mes = meses[0];
                if (fecMax.Month == 1)
                    mes = meses[11];
                else if (fecMax.Month == 2)
                    mes = meses[0];
                else
                    mes = meses[fecMax.Month - 2];

                string msg = "Ha terminado el plazo para crear la nota de gastos de " + mes + ".";
                bool bOk = true;


                //---- GSG (07/03/2017)
                int kdia = int.Parse(Comun.K_FECMAX_NOTAGASTO.Substring(0, 2));
                int kmes = int.Parse(Comun.K_FECMAX_NOTAGASTO.Substring(3, 2));
                int kanyo = int.Parse(Comun.K_FECMAX_NOTAGASTO.Substring(6, 4));

                if (fecMax.Day == kdia && fecMax.Month == kmes && fecMax.Year == kanyo) //---- GSG (07/03/2017)
                    bOk = true;
                else
                {

                    if (this.dtpFecha.Value.Year == fecMax.Year)
                    {
                        if (this.dtpFecha.Value.Month < fecMax.Month)
                        {
                            if (this.dtpFecha.Value.Month == fecMax.Month - 1)
                            {
                                if (DateTime.Today > fecMax)
                                    bOk = false;
                            }
                            else
                                bOk = false;
                        }
                    }
                    else if (dtpFecha.Value.Year == fecMax.Year - 1)
                    {
                        if (this.dtpFecha.Value.Month == 12 && fecMax.Month == 1)
                        {
                            if (DateTime.Today.Day > fecMax.Day)
                                bOk = false;
                        }
                        else
                            bOk = false;
                    }
                    else
                        bOk = false;

                }


                if (!bOk)
                {
                    Mensajes.ShowError(msg);
                    return false;
                }
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);return false;}
			return true;
		}
       
		#endregion

		private void dtpFecha_CloseUp(object sender, System.EventArgs e)
		{
			try
			{
				if(this.ParamTipoAcceso=="A")
				{
					if(this.dtpFecha.Value<DateTime.Today.AddDays(1))
					{
						this.dsGastos1.GetExisteNotaGastos.Rows.Clear();

						this.sqldaGetExisteNotaGastos.SelectCommand.Parameters["@dFecha"].Value = this.dtpFecha.Value.ToShortDateString();
						this.sqldaGetExisteNotaGastos.SelectCommand.Parameters["@iIdDelegado"].Value = this.ParamiIdDelegado;
						this.sqldaGetExisteNotaGastos.SelectCommand.Parameters["@bVisa"].Value = -1;

						this.sqldaGetExisteNotaGastos.Fill(this.dsGastos1);

						if(this.dsGastos1.GetExisteNotaGastos.Rows.Count==0)
						{
							this.dtpFecha.CustomFormat="";
							this.ParamFecha = DateTime.Parse(this.dtpFecha.Value.ToShortDateString());
							Cargar_AtencionesComerciales();
						}
						else
						{
							Mensajes.ShowError("Ya existe una Nota de Gastos para esta fecha.");
							this.Var_CambioFecha=false;
							this.dtpFecha.CustomFormat=" ";//.Value=this.ParamFecha.Date;
						}
					}
					else
					{
						this.dtpFecha.CustomFormat=" ";
						Mensajes.ShowError("No se pueden introducir Notas de Gastos con fecha superior al día de hoy.");
						//this.dtpFecha.Value=DateTime.Parse("01/01/1900");
							
					}
				}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}

		private void dtpFecha_Leave(object sender, System.EventArgs e)
		{
			try
			{
				if(this.ParamTipoAcceso=="A")
				{
					if(this.dtpFecha.Value<DateTime.Today.AddDays(1))
					{
						this.dsGastos1.GetExisteNotaGastos.Rows.Clear();

						this.sqldaGetExisteNotaGastos.SelectCommand.Parameters["@dFecha"].Value = this.dtpFecha.Value.ToShortDateString();
						this.sqldaGetExisteNotaGastos.SelectCommand.Parameters["@iIdDelegado"].Value = this.ParamiIdDelegado;
						this.sqldaGetExisteNotaGastos.SelectCommand.Parameters["@bVisa"].Value = -1;

						this.sqldaGetExisteNotaGastos.Fill(this.dsGastos1);

						if(this.dsGastos1.GetExisteNotaGastos.Rows.Count==0)
						{
							this.dtpFecha.CustomFormat="";
							this.ParamFecha = DateTime.Parse(this.dtpFecha.Value.ToShortDateString());
							Cargar_AtencionesComerciales();
						}
						else
						{
                            //---- GSG (15/09/2011)
							//Mensajes.ShowError("Ya existe una Nota de Gastos para esta fecha.");
							//---- FI GSG
                            this.Var_CambioFecha=false;
							this.dtpFecha.CustomFormat=" ";//.Value=this.ParamFecha.Date;
						}
					}
					else
					{
						if(this.dtpFecha.CustomFormat!=" ")
						{
							this.dtpFecha.CustomFormat=" ";
							Mensajes.ShowError("No se pueden introducir Notas de Gastos con fecha superior al día de hoy.");
						}
						//this.dtpFecha.Value=DateTime.Parse("01/01/1900");
							
					}
				}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}


        //---- GSG (26/03/2012)
        private void dtgViewLineasNotasDeGasto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Cargar_LineaViewNotaGastos();

                if (dtgViewLineasNotasDeGasto.CurrentCell.ReadOnly == false)
                    dtgViewLineasNotasDeGasto.BeginEdit(true);
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }

        private void dtgViewLineasNotasDeGasto_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            DefaultImportValue = double.Parse(dtgViewLineasNotasDeGasto.Rows[e.RowIndex].Cells["fPrecioDataGridViewTextBoxColumn"].Value.ToString());
            DefaultCantidadValue = int.Parse(dtgViewLineasNotasDeGasto.Rows[e.RowIndex].Cells["fCantidadDataGridViewTextBoxColumn"].Value.ToString());

            
            if (e.ColumnIndex == dtgViewLineasNotasDeGasto.Columns["fPrecioDataGridViewTextBoxColumn"].Index) //Precio
            {
                if (nupPrecio.Enabled == false)
                {
                    string tipText = "Modif. no permitida";
                    Mensajes.SetTip("Precio", tipText);
                    Mensajes.ShowTip(Cursor.Position.X, Cursor.Position.Y, this);

                    SetDefault = true;
                }
            }
            
        }

        private void dtgViewLineasNotasDeGasto_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (SetDefault == true)
            {
                Mensajes.HideTip();
                dtgViewLineasNotasDeGasto.Rows[e.RowIndex].Cells["fPrecioDataGridViewTextBoxColumn"].Value = DefaultImportValue;
                SetDefault = false;
            }

            if (Validar_Datos(dtgViewLineasNotasDeGasto.Rows[e.RowIndex].Cells["fCantidadDataGridViewTextBoxColumn"].Value.ToString(), dtgViewLineasNotasDeGasto.Rows[e.RowIndex].Cells["fPrecioDataGridViewTextBoxColumn"].Value.ToString()))
            {
                ActualizarImporteLinea(e.RowIndex);
                ActualizarCampos(e.RowIndex);
            }
            else
            {
                dtgViewLineasNotasDeGasto.Rows[e.RowIndex].Cells["fCantidadDataGridViewTextBoxColumn"].Value = DefaultCantidadValue;
                dtgViewLineasNotasDeGasto.Rows[e.RowIndex].Cells["fPrecioDataGridViewTextBoxColumn"].Value = DefaultImportValue;
            }

        }

        private void dtgViewLineasNotasDeGasto_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            try
            {
                DataGridViewCell cell = dtgViewLineasNotasDeGasto.CurrentCell;
                int IdGasto = int.Parse(dtgViewLineasNotasDeGasto.Rows[e.RowIndex].Cells["iIdGastoDataGridViewTextBoxColumn"].Value.ToString());

                e.ParsingApplied = false;
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }

        private void ActualizarImporteLinea(int RowIndex)
        {

            int iCantidad = int.Parse(dtgViewLineasNotasDeGasto.Rows[RowIndex].Cells["fCantidadDataGridViewTextBoxColumn"].Value.ToString());
            double PrecioUnitario = double.Parse(dtgViewLineasNotasDeGasto.Rows[RowIndex].Cells["fPrecioDataGridViewTextBoxColumn"].Value.ToString());
            double Importe = iCantidad * PrecioUnitario;

            dtgViewLineasNotasDeGasto.Rows[RowIndex].Cells["importeGastoDataGridViewTextBoxColumn"].Value = Importe;
        }

        private void ActualizarCampos(int RowIndex)
        {
            this.cboGasto.SelectedValue = Int32.Parse(dtgViewLineasNotasDeGasto.Rows[RowIndex].Cells["iIdGastoDataGridViewTextBoxColumn"].Value.ToString());
            this.nmrCantidad.Value = Int32.Parse(dtgViewLineasNotasDeGasto.Rows[RowIndex].Cells["fCantidadDataGridViewTextBoxColumn"].Value.ToString());
            this.nupPrecio.Value = Decimal.Parse(dtgViewLineasNotasDeGasto.Rows[RowIndex].Cells["fPrecioDataGridViewTextBoxColumn"].Value.ToString());
            this.cboCCoste.SelectedValue = dtgViewLineasNotasDeGasto.Rows[RowIndex].Cells["sIdCentroCosteDataGridViewTextBoxColumn"].Value.ToString();
            this.txbDescrip.Text = dtgViewLineasNotasDeGasto.Rows[RowIndex].Cells["descripLineaDataGridViewTextBoxColumn"].Value.ToString();		
        }

        private void dtgViewLineasNotasDeGasto_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                if (!bBorrando)
                {
                    //---- GSG (25/05/2012)
                    //Cargar_LineaViewNotaGastos();
                    //---- FI GSG
                    if (dtgViewLineasNotasDeGasto.SelectedRows.Count > 0)
                    {
                        this.TotalLineas = 0.0;
                        for (int i = 0; i < dtgViewLineasNotasDeGasto.Rows.Count; i++)
                            this.TotalLineas += double.Parse(dtgViewLineasNotasDeGasto.Rows[i].Cells["importeGastoDataGridViewTextBoxColumn"].Value.ToString());

                        this.lblLineas.Text = TotalLineas.ToString("N2");
                        this.lblTotLineas.Text = this.dtLineasViewGasto.Rows.Count.ToString();

                        this.TotalImporte = this.TotalAtts + this.TotalLineas;
                        this.lblTotImporte.Text = this.TotalImporte.ToString("N2");
                    }                    
                }
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }

        private bool Validar_Datos(string pCantidad, string pPrecio)
        {
            try
            {

                if (!Utiles.EsNumero(pCantidad))
                {
                    Mensajes.ShowError("La cantidad debe ser un número entero.");
                    return false;
                }
                else if (!Utiles.IsDecimal(pPrecio))
                {
                    Mensajes.ShowError("El precio debe ser un número.");
                    return false;
                }

            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); return false; }

            return true;
        }

        private void dtgViewLineasNotasDeGasto_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.ColumnIndex == dtgViewLineasNotasDeGasto.Columns["fPrecioDataGridViewTextBoxColumn"].Index) //Precio
                Mensajes.ShowError("El dato introducido no tiene el formato correcto.");
            else
                Mensajes.ShowError("Error: " + e.Exception);
        }


        //---- GSG (23/09/2013)
        private DateTime getFecMaxNota()
        {
            DateTime fec = DateTime.Today;

            this.dsGastos1.FecMaxNota.Rows.Clear();

            this.sqldaGetFecMaxNota.SelectCommand.Parameters["@iIdDelegado"].Value = this.ParamiIdDelegado;

            this.sqldaGetFecMaxNota.Fill(this.dsGastos1);

            if (this.dsGastos1.FecMaxNota.Rows.Count > 0)
            {
                fec = DateTime.Parse(dsGastos1.FecMaxNota.Rows[0]["dFecMaxNota"].ToString());

                //De la fecha que se ha indicado en el mantenimiento de delegado de central sólo cogemos el día para no tener que estar modificando cada mes el valor de la fecha
                //fec = DateTime.Parse(fec.Day.ToString() + "/" + DateTime.Today.Month.ToString() + "/" + DateTime.Today.Year.ToString());

                //---- GSG (07/03/2017)
                int kdia = int.Parse(Comun.K_FECMAX_NOTAGASTO.Substring(0, 2));
                int kmes = int.Parse(Comun.K_FECMAX_NOTAGASTO.Substring(3, 2));
                int kanyo = int.Parse(Comun.K_FECMAX_NOTAGASTO.Substring(6, 4));

                if (fec.Day != kdia || fec.Month != kmes || fec.Year != kanyo)
                    fec = DateTime.Parse(fec.Day.ToString() + "/" + DateTime.Today.Month.ToString() + "/" + DateTime.Today.Year.ToString());
            }


            return fec;
        }

        //---- FI GSG
	}
}
