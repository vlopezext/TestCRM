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
	/// Formulario que gestiona los gastos, consultándolos por fecha y delegado.
	/// </summary>
	public class frmConsultaGastos : System.Windows.Forms.Form
	{
		int Var_iIdNota;
		int Var_Fila;
		double TotalAttCom = 0;
		double TotalLinGast = 0;
        //---- GSG (12/09/2011)
        double TotalImpGast = 0;
        bool bEntrada = true;
        //---- FI GSG

		private System.Windows.Forms.Panel pnlNGasto;
		private System.Windows.Forms.Label lblFecha;
		private System.Windows.Forms.ComboBox cboDelegado;
		private System.Windows.Forms.Label lblDelegado;
		private System.Windows.Forms.Button btnBuscar;
		private System.Windows.Forms.ContextMenu cntxMnuGastos;
		private System.Windows.Forms.DataGrid dtgNotasGasto;
		private System.Data.SqlClient.SqlConnection sqlConn;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn5;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn6;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn7;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle2;
		private System.Windows.Forms.DataGrid dtgLineasGasto;
		private System.Data.SqlClient.SqlCommand sqlCmdSetNotasGasto;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn17;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn18;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle3;
		private System.Windows.Forms.DataGrid dtgAttCiales;
		private System.ComponentModel.IContainer components;
		private GESTCRM.Controles.ucBotoneraSecundaria ucBotoneraSecundaria1;
		private System.Windows.Forms.Label lblTotalAtts;
		private System.Windows.Forms.Label lblLineas;
		private GESTCRM.Controles.LabelGradient labelGradient1;
		private GESTCRM.Controles.LabelGradient labelGradient2;
		private GESTCRM.Controles.LabelGradient labelGradient3;
//		private DataTable dtAtenCom = new DataTable();
		private GESTCRM.Controles.LabelGradient lblGastos;
		private GESTCRM.Controles.LabelGradient labelGradient5;
		private GESTCRM.Controles.LabelGradient labelGradient6;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn22;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
//		private bool CambioDatos = false;
		private GESTCRM.Controles.LabelGradient labelGradient4;
		private GESTCRM.Controles.LabelGradient labelGradient7;
		private GESTCRM.Controles.LabelGradient labelGradient8;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.MenuItem menuEditar;
		private System.Windows.Forms.MenuItem menuEliminar;
		private System.Windows.Forms.MenuItem menuNuevo;
		private System.Windows.Forms.DateTimePicker dtpFechaFin;
		private System.Windows.Forms.DateTimePicker dtpFechaIni;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker dtpFechaLiqFin;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.DateTimePicker dtpFechaLiqIni;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ComboBox cbVisa;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn23;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn24;
		private System.Data.SqlClient.SqlDataAdapter sqldaListaDelegados;
		private System.Data.SqlClient.SqlDataAdapter sqldaListaGastos;
		private System.Data.SqlClient.SqlDataAdapter sqldaLineasNotasGasto;
		private System.Data.SqlClient.SqlDataAdapter sqldaListaAtencionesComerciales;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn25;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn26;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn27;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn28;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn29;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn8;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn9;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn10;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn11;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn12;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		private System.Windows.Forms.Label lblTotNotas;
		private System.Data.SqlClient.SqlDataAdapter sqldaGetExisteNotaGastos;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand5;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn13;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn14;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Label lblTotLineas;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private GESTCRM.Formularios.DataSets.dsGastos dsGastos1;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn15;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand4;
        private Label lblTotal;
        private TextBox txbTotal;
		private System.Windows.Forms.Label lblTotAtencion;
		
//		public static bool VengoNG = false;

		public frmConsultaGastos()
		{
            Cursor.Current = Cursors.WaitCursor;
            InitializeComponent();


            //---- GSG (06/03/2021)
            Utiles.GetConfigConnection();
            this.sqlConn.ConnectionString = Utiles._connection.ConnectionString.ToString();

            
			Cursor.Current = Cursors.Default;
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


		#region Código generado por el Diseñador de Windows Forms
		/// <summary>
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido del método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.Configuration.AppSettingsReader configurationAppSettings = new System.Configuration.AppSettingsReader();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsultaGastos));
            this.pnlNGasto = new System.Windows.Forms.Panel();
            this.txbTotal = new System.Windows.Forms.TextBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.cbVisa = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpFechaLiqFin = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaLiqIni = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.labelGradient8 = new GESTCRM.Controles.LabelGradient();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dtpFechaIni = new System.Windows.Forms.DateTimePicker();
            this.cboDelegado = new System.Windows.Forms.ComboBox();
            this.dsGastos1 = new GESTCRM.Formularios.DataSets.dsGastos();
            this.lblDelegado = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.labelGradient7 = new GESTCRM.Controles.LabelGradient();
            this.labelGradient4 = new GESTCRM.Controles.LabelGradient();
            this.labelGradient3 = new GESTCRM.Controles.LabelGradient();
            this.labelGradient2 = new GESTCRM.Controles.LabelGradient();
            this.labelGradient1 = new GESTCRM.Controles.LabelGradient();
            this.dtgNotasGasto = new System.Windows.Forms.DataGrid();
            this.cntxMnuGastos = new System.Windows.Forms.ContextMenu();
            this.menuNuevo = new System.Windows.Forms.MenuItem();
            this.menuEditar = new System.Windows.Forms.MenuItem();
            this.menuEliminar = new System.Windows.Forms.MenuItem();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn22 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn23 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn13 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn6 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn5 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn7 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn15 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn24 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.sqlConn = new System.Data.SqlClient.SqlConnection();
            this.sqldaListaDelegados = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqldaListaGastos = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
            this.dtgLineasGasto = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn25 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn26 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn27 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn28 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn29 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn14 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.sqldaLineasNotasGasto = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdSetNotasGasto = new System.Data.SqlClient.SqlCommand();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.sqldaListaAtencionesComerciales = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand4 = new System.Data.SqlClient.SqlCommand();
            this.dtgAttCiales = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle3 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn8 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn9 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn10 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn11 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn12 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn17 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn18 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.ucBotoneraSecundaria1 = new GESTCRM.Controles.ucBotoneraSecundaria();
            this.lblTotalAtts = new System.Windows.Forms.Label();
            this.lblLineas = new System.Windows.Forms.Label();
            this.lblGastos = new GESTCRM.Controles.LabelGradient();
            this.labelGradient5 = new GESTCRM.Controles.LabelGradient();
            this.labelGradient6 = new GESTCRM.Controles.LabelGradient();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTotNotas = new System.Windows.Forms.Label();
            this.sqldaGetExisteNotaGastos = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand5 = new System.Data.SqlClient.SqlCommand();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.lblTotAtencion = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.lblTotLineas = new System.Windows.Forms.Label();
            this.pnlNGasto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsGastos1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgNotasGasto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgLineasGasto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgAttCiales)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlNGasto
            // 
            this.pnlNGasto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnlNGasto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlNGasto.Controls.Add(this.txbTotal);
            this.pnlNGasto.Controls.Add(this.lblTotal);
            this.pnlNGasto.Controls.Add(this.cbVisa);
            this.pnlNGasto.Controls.Add(this.label6);
            this.pnlNGasto.Controls.Add(this.dtpFechaLiqFin);
            this.pnlNGasto.Controls.Add(this.dtpFechaLiqIni);
            this.pnlNGasto.Controls.Add(this.label5);
            this.pnlNGasto.Controls.Add(this.labelGradient8);
            this.pnlNGasto.Controls.Add(this.dtpFechaFin);
            this.pnlNGasto.Controls.Add(this.btnBuscar);
            this.pnlNGasto.Controls.Add(this.dtpFechaIni);
            this.pnlNGasto.Controls.Add(this.cboDelegado);
            this.pnlNGasto.Controls.Add(this.lblDelegado);
            this.pnlNGasto.Controls.Add(this.label2);
            this.pnlNGasto.Controls.Add(this.label3);
            this.pnlNGasto.Controls.Add(this.lblFecha);
            this.pnlNGasto.ForeColor = System.Drawing.Color.Black;
            this.pnlNGasto.Location = new System.Drawing.Point(1, 40);
            this.pnlNGasto.Name = "pnlNGasto";
            this.pnlNGasto.Size = new System.Drawing.Size(1492, 66);
            this.pnlNGasto.TabIndex = 33;
            // 
            // txbTotal
            // 
            this.txbTotal.Enabled = false;
            this.txbTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbTotal.Location = new System.Drawing.Point(1275, 30);
            this.txbTotal.Name = "txbTotal";
            this.txbTotal.Size = new System.Drawing.Size(106, 26);
            this.txbTotal.TabIndex = 42;
            // 
            // lblTotal
            // 
            this.lblTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.Black;
            this.lblTotal.Location = new System.Drawing.Point(1150, 33);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(121, 21);
            this.lblTotal.TabIndex = 41;
            this.lblTotal.Text = "Importe Total:";
            // 
            // cbVisa
            // 
            this.cbVisa.BackColor = System.Drawing.Color.White;
            this.cbVisa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbVisa.ForeColor = System.Drawing.Color.Black;
            this.cbVisa.Location = new System.Drawing.Point(1069, 30);
            this.cbVisa.Name = "cbVisa";
            this.cbVisa.Size = new System.Drawing.Size(77, 28);
            this.cbVisa.TabIndex = 40;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(1010, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 22);
            this.label6.TabIndex = 39;
            this.label6.Text = "¿Visa?:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpFechaLiqFin
            // 
            this.dtpFechaLiqFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaLiqFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaLiqFin.Location = new System.Drawing.Point(905, 30);
            this.dtpFechaLiqFin.Name = "dtpFechaLiqFin";
            this.dtpFechaLiqFin.Size = new System.Drawing.Size(102, 26);
            this.dtpFechaLiqFin.TabIndex = 37;
            // 
            // dtpFechaLiqIni
            // 
            this.dtpFechaLiqIni.CalendarForeColor = System.Drawing.Color.Black;
            this.dtpFechaLiqIni.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaLiqIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaLiqIni.Location = new System.Drawing.Point(754, 30);
            this.dtpFechaLiqIni.Name = "dtpFechaLiqIni";
            this.dtpFechaLiqIni.Size = new System.Drawing.Size(102, 26);
            this.dtpFechaLiqIni.TabIndex = 35;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(857, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 21);
            this.label5.TabIndex = 38;
            this.label5.Text = "entre";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelGradient8
            // 
            this.labelGradient8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGradient8.ForeColor = System.Drawing.Color.White;
            this.labelGradient8.GradientColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.labelGradient8.GradientColorTwo = System.Drawing.Color.White;
            this.labelGradient8.Location = new System.Drawing.Point(0, 0);
            this.labelGradient8.Name = "labelGradient8";
            this.labelGradient8.Size = new System.Drawing.Size(1492, 22);
            this.labelGradient8.TabIndex = 33;
            this.labelGradient8.Text = "Consulta de Notas de Gastos";
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new System.Drawing.Point(563, 30);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(101, 26);
            this.dtpFechaFin.TabIndex = 32;
            this.dtpFechaFin.ValueChanged += new System.EventHandler(this.dtpFechaEntre_ValueChanged);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.Color.Black;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBuscar.Location = new System.Drawing.Point(1393, 29);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(80, 28);
            this.btnBuscar.TabIndex = 30;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // dtpFechaIni
            // 
            this.dtpFechaIni.CalendarForeColor = System.Drawing.Color.Black;
            this.dtpFechaIni.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaIni.Location = new System.Drawing.Point(413, 30);
            this.dtpFechaIni.Name = "dtpFechaIni";
            this.dtpFechaIni.Size = new System.Drawing.Size(101, 26);
            this.dtpFechaIni.TabIndex = 6;
            this.dtpFechaIni.ValueChanged += new System.EventHandler(this.dtpFecha_ValueChanged);
            // 
            // cboDelegado
            // 
            this.cboDelegado.DataSource = this.dsGastos1.ListaDelegados;
            this.cboDelegado.DisplayMember = "sNombre";
            this.cboDelegado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDelegado.ForeColor = System.Drawing.Color.Black;
            this.cboDelegado.ItemHeight = 20;
            this.cboDelegado.Location = new System.Drawing.Point(77, 29);
            this.cboDelegado.Name = "cboDelegado";
            this.cboDelegado.Size = new System.Drawing.Size(275, 28);
            this.cboDelegado.TabIndex = 0;
            this.cboDelegado.ValueMember = "iIdDelegado";
            this.cboDelegado.Leave += new System.EventHandler(this.cboDelegado_Leave);
            // 
            // dsGastos1
            // 
            this.dsGastos1.DataSetName = "dsGastos";
            this.dsGastos1.Locale = new System.Globalization.CultureInfo("en-US");
            this.dsGastos1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lblDelegado
            // 
            this.lblDelegado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblDelegado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDelegado.ForeColor = System.Drawing.Color.Black;
            this.lblDelegado.Location = new System.Drawing.Point(-1, 33);
            this.lblDelegado.Name = "lblDelegado";
            this.lblDelegado.Size = new System.Drawing.Size(82, 22);
            this.lblDelegado.TabIndex = 1;
            this.lblDelegado.Text = "Delegado:";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(514, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 20);
            this.label2.TabIndex = 34;
            this.label2.Text = "entre";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(669, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 21);
            this.label3.TabIndex = 36;
            this.label3.Text = "Fecha Liq:";
            // 
            // lblFecha
            // 
            this.lblFecha.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.ForeColor = System.Drawing.Color.Black;
            this.lblFecha.Location = new System.Drawing.Point(355, 33);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(58, 20);
            this.lblFecha.TabIndex = 7;
            this.lblFecha.Text = "Fecha:";
            // 
            // labelGradient7
            // 
            this.labelGradient7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGradient7.ForeColor = System.Drawing.Color.White;
            this.labelGradient7.GradientColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.labelGradient7.GradientColorTwo = System.Drawing.Color.White;
            this.labelGradient7.Location = new System.Drawing.Point(0, 0);
            this.labelGradient7.Name = "labelGradient7";
            this.labelGradient7.Size = new System.Drawing.Size(936, 22);
            this.labelGradient7.TabIndex = 33;
            this.labelGradient7.Text = "Gastos";
            // 
            // labelGradient4
            // 
            this.labelGradient4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGradient4.ForeColor = System.Drawing.Color.White;
            this.labelGradient4.GradientColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.labelGradient4.GradientColorTwo = System.Drawing.Color.White;
            this.labelGradient4.Location = new System.Drawing.Point(0, 0);
            this.labelGradient4.Name = "labelGradient4";
            this.labelGradient4.Size = new System.Drawing.Size(944, 22);
            this.labelGradient4.TabIndex = 33;
            this.labelGradient4.Text = "Notas de Gasto";
            // 
            // labelGradient3
            // 
            this.labelGradient3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGradient3.ForeColor = System.Drawing.Color.White;
            this.labelGradient3.GradientColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.labelGradient3.GradientColorTwo = System.Drawing.Color.White;
            this.labelGradient3.Location = new System.Drawing.Point(0, 0);
            this.labelGradient3.Name = "labelGradient3";
            this.labelGradient3.Size = new System.Drawing.Size(936, 22);
            this.labelGradient3.TabIndex = 33;
            this.labelGradient3.Text = "Búsqueda de Gastos";
            // 
            // labelGradient2
            // 
            this.labelGradient2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGradient2.ForeColor = System.Drawing.Color.White;
            this.labelGradient2.GradientColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.labelGradient2.GradientColorTwo = System.Drawing.Color.White;
            this.labelGradient2.Location = new System.Drawing.Point(0, 0);
            this.labelGradient2.Name = "labelGradient2";
            this.labelGradient2.Size = new System.Drawing.Size(712, 22);
            this.labelGradient2.TabIndex = 33;
            this.labelGradient2.Text = "Notas de Gasto";
            // 
            // labelGradient1
            // 
            this.labelGradient1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGradient1.ForeColor = System.Drawing.Color.White;
            this.labelGradient1.GradientColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.labelGradient1.GradientColorTwo = System.Drawing.Color.White;
            this.labelGradient1.Location = new System.Drawing.Point(0, 0);
            this.labelGradient1.Name = "labelGradient1";
            this.labelGradient1.Size = new System.Drawing.Size(712, 23);
            this.labelGradient1.TabIndex = 33;
            this.labelGradient1.Text = "Notas de Gasto";
            // 
            // dtgNotasGasto
            // 
            this.dtgNotasGasto.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dtgNotasGasto.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.dtgNotasGasto.CaptionText = "Gastos";
            this.dtgNotasGasto.CaptionVisible = false;
            this.dtgNotasGasto.ContextMenu = this.cntxMnuGastos;
            this.dtgNotasGasto.DataMember = "ListaBuscaGastos";
            this.dtgNotasGasto.DataSource = this.dsGastos1;
            this.dtgNotasGasto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgNotasGasto.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dtgNotasGasto.Location = new System.Drawing.Point(-2, 18);
            this.dtgNotasGasto.Name = "dtgNotasGasto";
            this.dtgNotasGasto.ReadOnly = true;
            this.dtgNotasGasto.Size = new System.Drawing.Size(1492, 216);
            this.dtgNotasGasto.TabIndex = 34;
            this.dtgNotasGasto.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            this.dtgNotasGasto.CurrentCellChanged += new System.EventHandler(this.dtgNotasGasto_CurrentCellChanged);
            this.dtgNotasGasto.DoubleClick += new System.EventHandler(this.dtgNotasGasto_DoubleClick);
            // 
            // cntxMnuGastos
            // 
            this.cntxMnuGastos.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
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
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.DataGrid = this.dtgNotasGasto;
            this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn22,
            this.dataGridTextBoxColumn23,
            this.dataGridTextBoxColumn2,
            this.dataGridTextBoxColumn13,
            this.dataGridTextBoxColumn3,
            this.dataGridTextBoxColumn4,
            this.dataGridTextBoxColumn6,
            this.dataGridTextBoxColumn5,
            this.dataGridTextBoxColumn7,
            this.dataGridTextBoxColumn1,
            this.dataGridTextBoxColumn15,
            this.dataGridTextBoxColumn24});
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle1.MappingName = "ListaBuscaGastos";
            // 
            // dataGridTextBoxColumn22
            // 
            this.dataGridTextBoxColumn22.Format = "";
            this.dataGridTextBoxColumn22.FormatInfo = null;
            this.dataGridTextBoxColumn22.HeaderText = "Nº Nota Gasto";
            this.dataGridTextBoxColumn22.MappingName = "iIdNota";
            this.dataGridTextBoxColumn22.NullText = "";
            this.dataGridTextBoxColumn22.Width = 0;
            // 
            // dataGridTextBoxColumn23
            // 
            this.dataGridTextBoxColumn23.Format = "";
            this.dataGridTextBoxColumn23.FormatInfo = null;
            this.dataGridTextBoxColumn23.MappingName = "iIdDelegado";
            this.dataGridTextBoxColumn23.NullText = "";
            this.dataGridTextBoxColumn23.Width = 0;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "dd/MM/yyyy";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "F.Nota";
            this.dataGridTextBoxColumn2.MappingName = "dFecha";
            this.dataGridTextBoxColumn2.NullText = "";
            this.dataGridTextBoxColumn2.Width = 100;
            // 
            // dataGridTextBoxColumn13
            // 
            this.dataGridTextBoxColumn13.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.dataGridTextBoxColumn13.Format = "";
            this.dataGridTextBoxColumn13.FormatInfo = null;
            this.dataGridTextBoxColumn13.MappingName = "bVisa";
            this.dataGridTextBoxColumn13.NullText = "";
            this.dataGridTextBoxColumn13.Width = 0;
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.HeaderText = "¿Visa?";
            this.dataGridTextBoxColumn3.MappingName = "tVisa";
            this.dataGridTextBoxColumn3.NullText = "";
            this.dataGridTextBoxColumn3.Width = 75;
            // 
            // dataGridTextBoxColumn4
            // 
            this.dataGridTextBoxColumn4.Format = "dd/MM/yyyy";
            this.dataGridTextBoxColumn4.FormatInfo = null;
            this.dataGridTextBoxColumn4.HeaderText = "F. Aprob.";
            this.dataGridTextBoxColumn4.MappingName = "dFechaAprob";
            this.dataGridTextBoxColumn4.NullText = "";
            this.dataGridTextBoxColumn4.Width = 100;
            // 
            // dataGridTextBoxColumn6
            // 
            this.dataGridTextBoxColumn6.Format = "dd/MM/yyyy";
            this.dataGridTextBoxColumn6.FormatInfo = null;
            this.dataGridTextBoxColumn6.HeaderText = "F. Liq.";
            this.dataGridTextBoxColumn6.MappingName = "dFechaLiq";
            this.dataGridTextBoxColumn6.NullText = "";
            this.dataGridTextBoxColumn6.Width = 100;
            // 
            // dataGridTextBoxColumn5
            // 
            this.dataGridTextBoxColumn5.Format = "";
            this.dataGridTextBoxColumn5.FormatInfo = null;
            this.dataGridTextBoxColumn5.HeaderText = "Usuario Aprob";
            this.dataGridTextBoxColumn5.MappingName = "sUsuarioAprob";
            this.dataGridTextBoxColumn5.NullText = "";
            this.dataGridTextBoxColumn5.Width = 0;
            // 
            // dataGridTextBoxColumn7
            // 
            this.dataGridTextBoxColumn7.Format = "";
            this.dataGridTextBoxColumn7.FormatInfo = null;
            this.dataGridTextBoxColumn7.HeaderText = "Observaciones";
            this.dataGridTextBoxColumn7.MappingName = "tObservaciones";
            this.dataGridTextBoxColumn7.NullText = "";
            this.dataGridTextBoxColumn7.Width = 460;
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "EnviadoCentral";
            this.dataGridTextBoxColumn1.MappingName = "bEnviadoCEN";
            this.dataGridTextBoxColumn1.NullText = "";
            this.dataGridTextBoxColumn1.Width = 0;
            // 
            // dataGridTextBoxColumn15
            // 
            this.dataGridTextBoxColumn15.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn15.Format = "N4";
            this.dataGridTextBoxColumn15.FormatInfo = null;
            this.dataGridTextBoxColumn15.HeaderText = "Imp.Total";
            this.dataGridTextBoxColumn15.MappingName = "ImpTotal";
            this.dataGridTextBoxColumn15.NullText = "";
            this.dataGridTextBoxColumn15.Width = 75;
            // 
            // dataGridTextBoxColumn24
            // 
            this.dataGridTextBoxColumn24.Format = "";
            this.dataGridTextBoxColumn24.FormatInfo = null;
            this.dataGridTextBoxColumn24.HeaderText = "Delegado";
            this.dataGridTextBoxColumn24.MappingName = "sNombre";
            this.dataGridTextBoxColumn24.NullText = "";
            this.dataGridTextBoxColumn24.Width = 380;
            // 
            // sqlConn
            // 
            this.sqlConn.ConnectionString = Utiles._connection.ConnectionString.ToString();   //---- GSG (06/03/2021)
            this.sqlConn.FireInfoMessageEventOnUserErrors = false;
            // 
            // sqldaListaDelegados
            // 
            this.sqldaListaDelegados.SelectCommand = this.sqlSelectCommand1;
            this.sqldaListaDelegados.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
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
            // sqldaListaGastos
            // 
            this.sqldaListaGastos.SelectCommand = this.sqlSelectCommand2;
            this.sqldaListaGastos.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaBuscaGastos", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iIdNota", "iIdNota"),
                        new System.Data.Common.DataColumnMapping("iIdDelegado", "iIdDelegado"),
                        new System.Data.Common.DataColumnMapping("sNombre", "sNombre"),
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
                        new System.Data.Common.DataColumnMapping("bEnviadoCEN", "bEnviadoCEN"),
                        new System.Data.Common.DataColumnMapping("ImpLineas", "ImpLineas"),
                        new System.Data.Common.DataColumnMapping("ImpAtenciones", "ImpAtenciones"),
                        new System.Data.Common.DataColumnMapping("ImpTotal", "ImpTotal")})});
            // 
            // sqlSelectCommand2
            // 
            this.sqlSelectCommand2.CommandText = "[ListaBuscaGastos]";
            this.sqlSelectCommand2.CommandTimeout = 60;
            this.sqlSelectCommand2.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand2.Connection = this.sqlConn;
            this.sqlSelectCommand2.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdNota", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@dFechaIni", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@dFechaFin", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@dFechaLiqIni", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@dFechaLiqFin", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@iIdDelegado", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@bVisa", System.Data.SqlDbType.Int, 4)});
            // 
            // dtgLineasGasto
            // 
            this.dtgLineasGasto.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dtgLineasGasto.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.dtgLineasGasto.CaptionText = "Lineas de Gasto";
            this.dtgLineasGasto.CaptionVisible = false;
            this.dtgLineasGasto.DataMember = "ListaLineasNotasGasto";
            this.dtgLineasGasto.DataSource = this.dsGastos1;
            this.dtgLineasGasto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgLineasGasto.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dtgLineasGasto.Location = new System.Drawing.Point(0, 18);
            this.dtgLineasGasto.Name = "dtgLineasGasto";
            this.dtgLineasGasto.ReadOnly = true;
            this.dtgLineasGasto.Size = new System.Drawing.Size(1476, 171);
            this.dtgLineasGasto.TabIndex = 35;
            this.dtgLineasGasto.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle2});
            this.dtgLineasGasto.CurrentCellChanged += new System.EventHandler(this.dtgLineasGasto_CurrentCellChanged);
            // 
            // dataGridTableStyle2
            // 
            this.dataGridTableStyle2.DataGrid = this.dtgLineasGasto;
            this.dataGridTableStyle2.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn25,
            this.dataGridTextBoxColumn26,
            this.dataGridTextBoxColumn27,
            this.dataGridTextBoxColumn28,
            this.dataGridTextBoxColumn29,
            this.dataGridTextBoxColumn14});
            this.dataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle2.MappingName = "ListaLineasNotasGasto";
            // 
            // dataGridTextBoxColumn25
            // 
            this.dataGridTextBoxColumn25.Format = "";
            this.dataGridTextBoxColumn25.FormatInfo = null;
            this.dataGridTextBoxColumn25.HeaderText = "Gasto";
            this.dataGridTextBoxColumn25.MappingName = "DescripGasto";
            this.dataGridTextBoxColumn25.NullText = "";
            this.dataGridTextBoxColumn25.Width = 500;
            // 
            // dataGridTextBoxColumn26
            // 
            this.dataGridTextBoxColumn26.Format = "";
            this.dataGridTextBoxColumn26.FormatInfo = null;
            this.dataGridTextBoxColumn26.HeaderText = "Centro Coste";
            this.dataGridTextBoxColumn26.MappingName = "sCentroCoste";
            this.dataGridTextBoxColumn26.NullText = "";
            this.dataGridTextBoxColumn26.Width = 200;
            // 
            // dataGridTextBoxColumn27
            // 
            this.dataGridTextBoxColumn27.Format = "";
            this.dataGridTextBoxColumn27.FormatInfo = null;
            this.dataGridTextBoxColumn27.HeaderText = "Observaciones";
            this.dataGridTextBoxColumn27.MappingName = "DescripLinea";
            this.dataGridTextBoxColumn27.NullText = "";
            this.dataGridTextBoxColumn27.Width = 400;
            // 
            // dataGridTextBoxColumn28
            // 
            this.dataGridTextBoxColumn28.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn28.Format = "";
            this.dataGridTextBoxColumn28.FormatInfo = null;
            this.dataGridTextBoxColumn28.HeaderText = "Cantidad";
            this.dataGridTextBoxColumn28.MappingName = "fCantidad";
            this.dataGridTextBoxColumn28.NullText = "";
            this.dataGridTextBoxColumn28.Width = 75;
            // 
            // dataGridTextBoxColumn29
            // 
            this.dataGridTextBoxColumn29.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn29.Format = "N4";
            this.dataGridTextBoxColumn29.FormatInfo = null;
            this.dataGridTextBoxColumn29.HeaderText = "Precio";
            this.dataGridTextBoxColumn29.MappingName = "fPrecio";
            this.dataGridTextBoxColumn29.NullText = "";
            this.dataGridTextBoxColumn29.Width = 75;
            // 
            // dataGridTextBoxColumn14
            // 
            this.dataGridTextBoxColumn14.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn14.Format = "N4";
            this.dataGridTextBoxColumn14.FormatInfo = null;
            this.dataGridTextBoxColumn14.HeaderText = "Imp. Línea   ";
            this.dataGridTextBoxColumn14.MappingName = "ImporteGasto";
            this.dataGridTextBoxColumn14.NullText = "";
            this.dataGridTextBoxColumn14.Width = 110;
            // 
            // sqldaLineasNotasGasto
            // 
            this.sqldaLineasNotasGasto.SelectCommand = this.sqlSelectCommand3;
            this.sqldaLineasNotasGasto.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
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
            // sqlSelectCommand3
            // 
            this.sqlSelectCommand3.CommandText = "[ListaLineasNotasGastoConsulta]";
            this.sqlSelectCommand3.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand3.Connection = this.sqlConn;
            this.sqlSelectCommand3.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdNota", System.Data.SqlDbType.Int, 4)});
            // 
            // sqlCmdSetNotasGasto
            // 
            this.sqlCmdSetNotasGasto.CommandText = "[SetNotasDeGasto]";
            this.sqlCmdSetNotasGasto.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdSetNotasGasto.Connection = this.sqlConn;
            this.sqlCmdSetNotasGasto.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iAccion", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdNota", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.InputOutput, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@sIdNotaTemp", System.Data.SqlDbType.VarChar, 11, System.Data.ParameterDirection.Output, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@idDelegado", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@dFecha", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@bVisa", System.Data.SqlDbType.TinyInt, 1),
            new System.Data.SqlClient.SqlParameter("@tObservaciones", System.Data.SqlDbType.VarChar, 8000)});
            // 
            // sqldaListaAtencionesComerciales
            // 
            this.sqldaListaAtencionesComerciales.SelectCommand = this.sqlSelectCommand4;
            this.sqldaListaAtencionesComerciales.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaNotaGasto_AtenCom", new System.Data.Common.DataColumnMapping[] {
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
                        new System.Data.Common.DataColumnMapping("fImporte", "fImporte"),
                        new System.Data.Common.DataColumnMapping("sDescripcion", "sDescripcion")})});
            // 
            // sqlSelectCommand4
            // 
            this.sqlSelectCommand4.CommandText = "[ListaNotaGasto_AtenCom]";
            this.sqlSelectCommand4.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand4.Connection = this.sqlConn;
            this.sqlSelectCommand4.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdNota", System.Data.SqlDbType.Int, 4)});
            // 
            // dtgAttCiales
            // 
            this.dtgAttCiales.AlternatingBackColor = System.Drawing.Color.White;
            this.dtgAttCiales.BackgroundColor = System.Drawing.Color.White;
            this.dtgAttCiales.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.dtgAttCiales.CaptionForeColor = System.Drawing.Color.White;
            this.dtgAttCiales.CaptionText = "Atenciones Comerciales";
            this.dtgAttCiales.CaptionVisible = false;
            this.dtgAttCiales.DataMember = "ListaNotaGasto_AtenCom";
            this.dtgAttCiales.DataSource = this.dsGastos1;
            this.dtgAttCiales.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgAttCiales.ForeColor = System.Drawing.Color.White;
            this.dtgAttCiales.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dtgAttCiales.Location = new System.Drawing.Point(-2, 18);
            this.dtgAttCiales.Name = "dtgAttCiales";
            this.dtgAttCiales.ReadOnly = true;
            this.dtgAttCiales.SelectionForeColor = System.Drawing.Color.White;
            this.dtgAttCiales.Size = new System.Drawing.Size(1473, 110);
            this.dtgAttCiales.TabIndex = 36;
            this.dtgAttCiales.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle3});
            this.dtgAttCiales.CurrentCellChanged += new System.EventHandler(this.dtgAttCiales_CurrentCellChanged);
            // 
            // dataGridTableStyle3
            // 
            this.dataGridTableStyle3.DataGrid = this.dtgAttCiales;
            this.dataGridTableStyle3.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn8,
            this.dataGridTextBoxColumn9,
            this.dataGridTextBoxColumn10,
            this.dataGridTextBoxColumn11,
            this.dataGridTextBoxColumn12});
            this.dataGridTableStyle3.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle3.MappingName = "ListaNotaGasto_AtenCom";
            // 
            // dataGridTextBoxColumn8
            // 
            this.dataGridTextBoxColumn8.Format = "";
            this.dataGridTextBoxColumn8.FormatInfo = null;
            this.dataGridTextBoxColumn8.HeaderText = "Atención";
            this.dataGridTextBoxColumn8.MappingName = "sDescripcion";
            this.dataGridTextBoxColumn8.NullText = "";
            this.dataGridTextBoxColumn8.Width = 400;
            // 
            // dataGridTextBoxColumn9
            // 
            this.dataGridTextBoxColumn9.Format = "dd/MM/yyyy";
            this.dataGridTextBoxColumn9.FormatInfo = null;
            this.dataGridTextBoxColumn9.HeaderText = "F.Report";
            this.dataGridTextBoxColumn9.MappingName = "dFecha";
            this.dataGridTextBoxColumn9.NullText = "";
            this.dataGridTextBoxColumn9.Width = 110;
            // 
            // dataGridTextBoxColumn10
            // 
            this.dataGridTextBoxColumn10.Format = "";
            this.dataGridTextBoxColumn10.FormatInfo = null;
            this.dataGridTextBoxColumn10.HeaderText = "Cód. Cliente";
            this.dataGridTextBoxColumn10.MappingName = "sIdCliente";
            this.dataGridTextBoxColumn10.NullText = "";
            this.dataGridTextBoxColumn10.Width = 200;
            // 
            // dataGridTextBoxColumn11
            // 
            this.dataGridTextBoxColumn11.Format = "";
            this.dataGridTextBoxColumn11.FormatInfo = null;
            this.dataGridTextBoxColumn11.HeaderText = "Nombre Cliente";
            this.dataGridTextBoxColumn11.MappingName = "sNombreCli";
            this.dataGridTextBoxColumn11.NullText = "";
            this.dataGridTextBoxColumn11.Width = 500;
            // 
            // dataGridTextBoxColumn12
            // 
            this.dataGridTextBoxColumn12.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn12.Format = "N4";
            this.dataGridTextBoxColumn12.FormatInfo = null;
            this.dataGridTextBoxColumn12.HeaderText = "Imp. Cliente";
            this.dataGridTextBoxColumn12.MappingName = "fImporte";
            this.dataGridTextBoxColumn12.NullText = "";
            this.dataGridTextBoxColumn12.Width = 200;
            // 
            // dataGridTextBoxColumn17
            // 
            this.dataGridTextBoxColumn17.Format = "";
            this.dataGridTextBoxColumn17.FormatInfo = null;
            this.dataGridTextBoxColumn17.Width = 75;
            // 
            // dataGridTextBoxColumn18
            // 
            this.dataGridTextBoxColumn18.Format = "";
            this.dataGridTextBoxColumn18.FormatInfo = null;
            this.dataGridTextBoxColumn18.Width = 75;
            // 
            // ucBotoneraSecundaria1
            // 
            this.ucBotoneraSecundaria1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(117)))), ((int)(((byte)(1)))));
            this.ucBotoneraSecundaria1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucBotoneraSecundaria1.ForeColor = System.Drawing.Color.Black;
            this.ucBotoneraSecundaria1.Location = new System.Drawing.Point(0, 0);
            this.ucBotoneraSecundaria1.Name = "ucBotoneraSecundaria1";
            this.ucBotoneraSecundaria1.Size = new System.Drawing.Size(1497, 38);
            this.ucBotoneraSecundaria1.TabIndex = 37;
            // 
            // lblTotalAtts
            // 
            this.lblTotalAtts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.lblTotalAtts.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotalAtts.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAtts.ForeColor = System.Drawing.Color.Black;
            this.lblTotalAtts.Location = new System.Drawing.Point(1318, 132);
            this.lblTotalAtts.Name = "lblTotalAtts";
            this.lblTotalAtts.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblTotalAtts.Size = new System.Drawing.Size(111, 18);
            this.lblTotalAtts.TabIndex = 40;
            this.lblTotalAtts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLineas
            // 
            this.lblLineas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.lblLineas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLineas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLineas.ForeColor = System.Drawing.Color.Black;
            this.lblLineas.Location = new System.Drawing.Point(1318, 194);
            this.lblLineas.Name = "lblLineas";
            this.lblLineas.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblLineas.Size = new System.Drawing.Size(111, 18);
            this.lblLineas.TabIndex = 43;
            this.lblLineas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblGastos
            // 
            this.lblGastos.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblGastos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGastos.ForeColor = System.Drawing.Color.White;
            this.lblGastos.GradientColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.lblGastos.GradientColorTwo = System.Drawing.Color.White;
            this.lblGastos.Location = new System.Drawing.Point(0, 0);
            this.lblGastos.Name = "lblGastos";
            this.lblGastos.Size = new System.Drawing.Size(1488, 18);
            this.lblGastos.TabIndex = 44;
            this.lblGastos.Text = "Notas de Gastos";
            this.lblGastos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.labelGradient5.TabIndex = 45;
            this.labelGradient5.Text = "Atenciones Comerciales asociadas a una Nota de Gastos";
            this.labelGradient5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.labelGradient6.Size = new System.Drawing.Size(1479, 18);
            this.labelGradient6.TabIndex = 46;
            this.labelGradient6.Text = "Líneas de una Nota de Gasto";
            this.labelGradient6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(1433, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 18);
            this.label4.TabIndex = 47;
            this.label4.Text = "€";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(1433, 194);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 18);
            this.label1.TabIndex = 48;
            this.label1.Text = "€";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.lblTotNotas);
            this.panel1.Controls.Add(this.lblGastos);
            this.panel1.Controls.Add(this.dtgNotasGasto);
            this.panel1.Location = new System.Drawing.Point(1, 106);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1492, 240);
            this.panel1.TabIndex = 49;
            // 
            // lblTotNotas
            // 
            this.lblTotNotas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.lblTotNotas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotNotas.ForeColor = System.Drawing.Color.Black;
            this.lblTotNotas.Location = new System.Drawing.Point(1425, 0);
            this.lblTotNotas.Name = "lblTotNotas";
            this.lblTotNotas.Size = new System.Drawing.Size(60, 18);
            this.lblTotNotas.TabIndex = 45;
            this.lblTotNotas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sqldaGetExisteNotaGastos
            // 
            this.sqldaGetExisteNotaGastos.SelectCommand = this.sqlSelectCommand5;
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
            // sqlSelectCommand5
            // 
            this.sqlSelectCommand5.CommandText = "[GetExisteNotaGastos]";
            this.sqlSelectCommand5.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand5.Connection = this.sqlConn;
            this.sqlSelectCommand5.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@dFecha", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@iIdDelegado", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@bVisa", System.Data.SqlDbType.Int, 4)});
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.ForeColor = System.Drawing.Color.Black;
            this.panel2.Location = new System.Drawing.Point(1, 348);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1490, 402);
            this.panel2.TabIndex = 50;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.lblTotAtencion);
            this.panel4.Controls.Add(this.labelGradient5);
            this.panel4.Controls.Add(this.dtgAttCiales);
            this.panel4.Controls.Add(this.lblTotalAtts);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Location = new System.Drawing.Point(-1, 229);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1478, 165);
            this.panel4.TabIndex = 37;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(1186, 129);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(130, 21);
            this.label8.TabIndex = 53;
            this.label8.Text = "Total Importe:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotAtencion
            // 
            this.lblTotAtencion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.lblTotAtencion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotAtencion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotAtencion.ForeColor = System.Drawing.Color.Black;
            this.lblTotAtencion.Location = new System.Drawing.Point(1411, -1);
            this.lblTotAtencion.Name = "lblTotAtencion";
            this.lblTotAtencion.Size = new System.Drawing.Size(60, 18);
            this.lblTotAtencion.TabIndex = 48;
            this.lblTotAtencion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.lblLineas);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.dtgLineasGasto);
            this.panel3.Controls.Add(this.lblTotLineas);
            this.panel3.Controls.Add(this.labelGradient6);
            this.panel3.Location = new System.Drawing.Point(-1, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1483, 221);
            this.panel3.TabIndex = 36;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(1173, 194);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(141, 20);
            this.label7.TabIndex = 52;
            this.label7.Text = "Total Importe:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotLineas
            // 
            this.lblTotLineas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.lblTotLineas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotLineas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotLineas.ForeColor = System.Drawing.Color.Black;
            this.lblTotLineas.Location = new System.Drawing.Point(1411, 0);
            this.lblTotLineas.Name = "lblTotLineas";
            this.lblTotLineas.Size = new System.Drawing.Size(60, 18);
            this.lblTotLineas.TabIndex = 51;
            this.lblTotLineas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmConsultaGastos
            // 
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.ClientSize = new System.Drawing.Size(1497, 762);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ucBotoneraSecundaria1);
            this.Controls.Add(this.pnlNGasto);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmConsultaGastos";
            this.Text = "Consulta de Notas de Gastos";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.frmConsultaGastos_Load);
            this.pnlNGasto.ResumeLayout(false);
            this.pnlNGasto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsGastos1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgNotasGasto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgLineasGasto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgAttCiales)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion	

		#region frmConsultaGastos_Load
		private void frmConsultaGastos_Load(object sender, System.EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;
			try
			{
				Utiles.Formato_Formulario(this);		
				if(this.Parent == null) this.WindowState = FormWindowState.Normal;

				Inicializar_Combos();

				Inicializar_Fechas();

				Inicializar_DataGrid();

				Inicializar_Botonera();

				this.Var_Fila=-1;
				this.Var_iIdNota=-1;

				//Comprobar tipo de acceso a formulario
				if(GESTCRM.Clases.Configuracion.iGGastos!=0)
				{
					this.menuEliminar.Enabled=false;
					this.menuNuevo.Enabled=false;
				}

				this.dsGastos1.ListaBuscaGastos.Rows.Clear();
                Cargar_dtgLineasNotasGastos();
				Cargar_DtgAttCiales();

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
				//ComboBox cboDelegado
				this.sqldaListaDelegados.Fill(this.dsGastos1);
				DataRow fila1 = this.dsGastos1.ListaDelegados.NewRow();
				fila1["iIdDelegado"]=-1;
				fila1["sNombre"]="Todos";
				this.dsGastos1.ListaDelegados.Rows.InsertAt(fila1,0);
				this.cboDelegado.SelectedValue = Clases.Configuracion.iIdDelegado;

				//ComboBox cbVisa
				//Inicializar ComboBox cbLiqNotaGastos
				DataTable tabla = new DataTable();
				tabla.Columns.Add("sValor");
				tabla.Columns.Add("sLiteral");
				DataRow fila40 = tabla.NewRow();
				fila40["sValor"] = -1;
				fila40["sLiteral"] = "Todos";
				tabla.Rows.Add(fila40);
				DataRow fila41 = tabla.NewRow();
				fila41["sValor"] = 0;
				fila41["sLiteral"] = "NO";
				tabla.Rows.Add(fila41);
				DataRow fila42 = tabla.NewRow();
				fila42["sValor"] = 1;
				fila42["sLiteral"] = "SI";
				tabla.Rows.Add(fila42);

				this.cbVisa.DataSource = tabla;
				this.cbVisa.ValueMember = "sValor";
				this.cbVisa.DisplayMember = "sLiteral";
				this.cbVisa.SelectedValue = -1;
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region Inicializar_Fechas
		private void Inicializar_Fechas()
		{
			try
			{
				this.dtpFechaIni.Value = DateTime.Parse("01/01/"+DateTime.Today.Year.ToString());
				this.dtpFechaFin.Value = DateTime.Today.AddMonths(2);
				this.dtpFechaLiqIni.Value = DateTime.Parse("01/01/"+DateTime.Today.Year.ToString());
				this.dtpFechaLiqFin.Value = DateTime.Today.AddMonths(2);
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region Inicializar_DataGrid
		private void Inicializar_DataGrid()
		{
			try
			{
				Utiles.Formatear_DgConFilabEnviadoCEN(dtgNotasGasto,null,this.cntxMnuGastos);
				for(int i=0;i<this.dtgNotasGasto.TableStyles[0].GridColumnStyles.Count;i++)
				{
					DataGridTextBoxColumn TextCol0 = (DataGridTextBoxColumn)this.dtgNotasGasto.TableStyles[0].GridColumnStyles[i];
					TextCol0.TextBox.DoubleClick += new EventHandler(dtgNotasGasto_DoubleClick);
				}

				Utiles.Formatear_DataGrid(this.dtgLineasGasto,"C",null);
				Utiles.Formatear_DataGrid(this.dtgAttCiales,"C",null);
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion 

		#region Inicializar Botonera
		private void Inicializar_Botonera()
		{
			try
			{
				this.ucBotoneraSecundaria1.btSalir.Click += new EventHandler(btSalir_Click);			
				this.ucBotoneraSecundaria1.btEditar.Click += new EventHandler(btEditar_Click);
				this.ucBotoneraSecundaria1.btNuevo.Click += new EventHandler(btNuevo_Click);
				this.ucBotoneraSecundaria1.btEliminar.Click += new EventHandler(btEliminar_Click);
				//this.ucBotoneraSecundaria1.btImprimir.Click += new EventHandler(btImprimir_Click);			
				if(GESTCRM.Clases.Configuracion.iGGastos!=0)
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


		#region btSalir_Click
		private void btSalir_Click(object sender, System.EventArgs e)
		{
			this.Close();
			this.Dispose();
		}
		#endregion

		#region btNuevo_Click
		private void btNuevo_Click(object sender, System.EventArgs e)
		{
			AbrirNotasGasto();
		}
		#endregion

		#region btEditar_Click
		private void btEditar_Click(object sender, System.EventArgs e)
		{
			EditarNotasGasto();
		}
		#endregion

		#region btEliminar_Click
		private void btEliminar_Click(object sender, System.EventArgs e)
		{
			EliminarNotasGasto();
		}
		#endregion

		#region btImprimir_Click
		private void btImprimir_Click(object sender, System.EventArgs e)
		{
			//			DateTime dHasta;
			//			if (this.chkEntre.Checked)
			//			{
			//				dHasta=this.dtpFechaEntre.Value;
			//			}
			//			else
			//			{
			//				dHasta=this.dtpFecha.Value;
			//			}
			//			GESTCRM.Listados.frmLiqGastos frmLiqGastos = new GESTCRM.Listados.frmLiqGastos(int.Parse(this.cboDelegado.SelectedValue.ToString()),this.dtpFecha.Value,dHasta);
			//			frmLiqGastos.ShowDialog();			
		}

		#endregion

		#region menuNuevo_Click
		private void menuNuevo_Click(object sender, System.EventArgs e)
		{
			AbrirNotasGasto();
		}
		#endregion

		#region menuEditar_Click
		private void menuEditar_Click(object sender, System.EventArgs e)
		{
			EditarNotasGasto();
		}
		#endregion

		#region menuEliminar_Click 
		private void menuEliminar_Click(object sender, System.EventArgs e)
		{
			EliminarNotasGasto();
		}	
		#endregion

		#region Abrir Notas de Gasto
		private void AbrirNotasGasto()
		{
			try
			{
				if(GESTCRM.Clases.Configuracion.iGGastos==0)//tiene acceso de escritura
				{
					bool abierto = false;
					int iIdDelegado = Int32.Parse(this.cboDelegado.SelectedValue.ToString());
					string Fecha = DateTime.Today.ToShortDateString();

					if(this.ParentForm == null) abierto=Utiles.MirarSiFormAbierto("frmGastos",this.Owner);
					else abierto = Utiles.MirarSiFormAbierto("frmGastos",this.ParentForm);

					if(!abierto)
					{
						int idNota = -1;
						string Desc = "";

						if(iIdDelegado == GESTCRM.Clases.Configuracion.iIdDelegado)
						{
							
							this.dsGastos1.GetExisteNotaGastos.Rows.Clear();

							this.sqldaGetExisteNotaGastos.SelectCommand.Parameters["@dFecha"].Value = Fecha;
							this.sqldaGetExisteNotaGastos.SelectCommand.Parameters["@iIdDelegado"].Value = iIdDelegado;
							this.sqldaGetExisteNotaGastos.SelectCommand.Parameters["@bVisa"].Value = -1;				

							this.sqldaGetExisteNotaGastos.Fill(this.dsGastos1);

							if (this.dsGastos1.GetExisteNotaGastos.Rows.Count == 0)//No existe ninguna nota de Gastos para el día de hoy
							{
								Form frmTemp=new Formularios.frmGastos("A",-1,Fecha,iIdDelegado);
								frmTemp.MdiParent=this.ParentForm;
								frmTemp.Show();
							}
							else
							{
								DialogResult dr=Mensajes.ShowQuestion("Ya existe una nota de gasto para el dia de hoy.\n ¿Desea abrirla?");
		
								if(dr == System.Windows.Forms.DialogResult.Yes)
								{
									Desc = this.dsGastos1.ListaBuscaGastos.Rows[0]["tObservaciones"].ToString();
									idNota = Convert.ToInt32(this.dsGastos1.ListaBuscaGastos.Rows[0]["iIdNota"].ToString());
									
									Form frmTemp=new Formularios.frmGastos("M",idNota,Fecha,iIdDelegado);
									frmTemp.MdiParent=this.ParentForm;
									frmTemp.Show();
								}
								else
								{
									Form frmTemp=new Formularios.frmGastos("A",-1,null,iIdDelegado);
									frmTemp.MdiParent=this.ParentForm;
									frmTemp.Show();
								}
							}
						}
						else //else del delegado
						{
							Mensajes.ShowInformation("No se pueden crear Notas de Gastos de otro Delegado.");
						}
					}
					else //ya hay una Nota de Gastos Abierta
					{
						DialogResult dr=Mensajes.ShowQuestion("No se puede crear una nota de gastos porque ya hay una abierta. ¿Desea ver la nota de Gastos abierta?.");
						if(dr==System.Windows.Forms.DialogResult.Yes)
						{
							GESTCRM.Utiles.ActivaFormularioAbierto("frmGastos",this.MdiParent);
						}
					}
				}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}

		#endregion

		#region EditarNotasGasto
		private void EditarNotasGasto()
		{
			try
			{
				int idNota = 0;			
				string Fecha ;
				string EnvCEN = "";
				string Acceso="M";
				int iIdDelegado;
			

				bool abierto = false;

				if(this.ParentForm == null) abierto=Utiles.MirarSiFormAbierto("frmGastos",this.Owner);
				else abierto = Utiles.MirarSiFormAbierto("frmGastos",this.ParentForm);

				if(!abierto)
				{
					if (this.dtgNotasGasto.CurrentRowIndex != -1)
					{
						idNota = Convert.ToInt32(this.dtgNotasGasto[this.dtgNotasGasto.CurrentCell.RowNumber,0].ToString());				
						iIdDelegado = Convert.ToInt32(this.dtgNotasGasto[this.dtgNotasGasto.CurrentCell.RowNumber,1].ToString());				
						Fecha = this.dtgNotasGasto[this.dtgNotasGasto.CurrentCell.RowNumber,2].ToString();
						EnvCEN = this.dtgNotasGasto[this.dtgNotasGasto.CurrentCell.RowNumber,9].ToString();
					
						if (EnvCEN == "1") Acceso="C";
						if (iIdDelegado != Clases.Configuracion.iIdDelegado) Acceso="C";
						if (Clases.Configuracion.iGGastos != 0) Acceso ="C";

						Form frmTemp=new Formularios.frmGastos(Acceso,idNota,Fecha,iIdDelegado);
						frmTemp.MdiParent=this.ParentForm;
						frmTemp.Show();
					}
					else
					{
						Mensajes.ShowError("No hay ninguna nota de gasto seleccionada");
					}
				}
				else
				{
					DialogResult dr=Mensajes.ShowQuestion("No se puede modificar la Nota de Gastos porque ya hay una abierta. ¿Desea ver el la Nota de Gastos abierta?.");
					if(dr==System.Windows.Forms.DialogResult.Yes)
					{
						GESTCRM.Utiles.ActivaFormularioAbierto("frmGastos",this.MdiParent);
					}

				}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region EliminarNotasGasto
		private void EliminarNotasGasto()
		{
			try
			{
				//tiene acceso de escritura y hay una fila seleccionada
				if(GESTCRM.Clases.Configuracion.iGGastos==0 && this.dtgNotasGasto.CurrentRowIndex != -1) 
				{
					int Delegado = Convert.ToInt32(this.dtgNotasGasto[this.dtgNotasGasto.CurrentRowIndex,1].ToString());
					string Fecha = this.dtgNotasGasto[this.dtgNotasGasto.CurrentRowIndex,2].ToString();
					int idNota = Convert.ToInt32(this.dtgNotasGasto[this.dtgNotasGasto.CurrentRowIndex,0].ToString());
					bool EnviadoCen = Convert.ToBoolean(this.dtgNotasGasto[this.dtgNotasGasto.CurrentCell.RowNumber,9]);

					if(Delegado==Clases.Configuracion.iIdDelegado)
					{
						bool abierto = false;

						if(this.ParentForm == null) abierto=Utiles.MirarSiFormAbierto("frmGastos",this.Owner);
						else abierto = Utiles.MirarSiFormAbierto("frmGastos",this.ParentForm);

						if (!abierto)
						{
							DialogResult dresult=Mensajes.ShowQuestion("¿Desea borrar las Nota de Gasto con fecha: " + Fecha +" ?");
			
							if(dresult == System.Windows.Forms.DialogResult.Yes)
							{			
								if (sqlConn.State == System.Data.ConnectionState.Closed)
								{
									sqlConn.Open();
								}

								try
								{
									if (EnviadoCen == true)
									{
										Mensajes.ShowError("No se puede eliminar una Nota de Gastos enviada a Central");
									}
									else 
									{
										sqlCmdSetNotasGasto.Parameters["@iAccion"].Value = 2;
										sqlCmdSetNotasGasto.Parameters["@iIdNota"].Value = idNota;
										sqlCmdSetNotasGasto.ExecuteNonQuery();
									
										Realizar_Busqueda();
									}
								}
								catch(Exception excConf)
								{	
									Mensajes.ShowErrorField(excConf.Message);
									sqlConn.Close();
								}

								sqlConn.Close();
							}
						}
						else //existe una nota de Gastos abierta
						{
							DialogResult dr1=Mensajes.ShowQuestion("No se puede eliminar una Nota de Gastos porque ya hay una abierta. ¿Desea ver la Nota de Gastos abierta?.");
							if(dr1==System.Windows.Forms.DialogResult.Yes)
							{
								GESTCRM.Utiles.ActivaFormularioAbierto("frmGastos",this.MdiParent);
							}
						}
					}
					else //Else del delegado
					{
						Mensajes.ShowInformation(5002);
					}
				}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion


		
		#region dtpFecha_ValueChanged
		private void dtpFecha_ValueChanged(object sender, System.EventArgs e)
		{
            //---- GSG (14/09/2011)
            if (! bEntrada)
            //---- FI GSG
			    btnBuscar_Click(sender,e);
		}
		#endregion

		#region dtpFechaEntre_ValueChanged
		private void dtpFechaEntre_ValueChanged(object sender, System.EventArgs e)
		{
            //---- GSG (14/09/2011)
            if (!bEntrada)
            //---- FI GSG
			    btnBuscar_Click(sender,e);
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
		
		#region btnBuscar_Click
		private void btnBuscar_Click(object sender, System.EventArgs e)
		{
            //---- GSG (14/09/2011)
            bEntrada = false;
            //---- FI GSG
			Realizar_Busqueda();
		}
		#endregion

		#region Realizar_Busqueda
		private void Realizar_Busqueda()
		{
			Cursor.Current = Cursors.WaitCursor;
			try
			{	
				this.dsGastos1.ListaBuscaGastos.Rows.Clear();
				this.dsGastos1.ListaNotaGasto_AtenCom.Rows.Clear();
				this.dsGastos1.ListaLineasNotasGasto.Rows.Clear();
				
				this.sqldaListaGastos.SelectCommand.Parameters["@iIdNota"].Value = -1;
				this.sqldaListaGastos.SelectCommand.Parameters["@iIdDelegado"].Value = Int32.Parse(this.cboDelegado.SelectedValue.ToString());
				this.sqldaListaGastos.SelectCommand.Parameters["@bVisa"].Value = int.Parse(this.cbVisa.SelectedValue.ToString());
				this.sqldaListaGastos.SelectCommand.Parameters["@dFechaIni"].Value = this.dtpFechaIni.Value.ToShortDateString();
				this.sqldaListaGastos.SelectCommand.Parameters["@dFechaFin"].Value = this.dtpFechaFin.Value.ToShortDateString();
				this.sqldaListaGastos.SelectCommand.Parameters["@dFechaLiqIni"].Value = this.dtpFechaLiqIni.Value.ToShortDateString();
				this.sqldaListaGastos.SelectCommand.Parameters["@dFechaLiqFin"].Value = this.dtpFechaLiqFin.Value.ToShortDateString();

				
				this.sqldaListaGastos.Fill(this.dsGastos1);

				if (this.dsGastos1.ListaBuscaGastos.Rows.Count > 0)
				{
					this.Var_Fila=0;
					this.Var_iIdNota = Int32.Parse(this.dtgNotasGasto[this.Var_Fila,0].ToString());
					Utiles.Seleccionar_UnaFilaDataGrid(this,dtgNotasGasto,0);
				}
				else
				{
					this.Var_Fila=-1;
					this.Var_iIdNota = -1;
				}
			
				this.lblTotNotas.Text = this.dsGastos1.ListaBuscaGastos.Rows.Count.ToString();
				
				Cargar_dtgLineasNotasGastos();
				Cargar_DtgAttCiales();

                ActualizarImporteTotal();
				
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
			Cursor.Current = Cursors.Default;
		}
		#endregion



		#region dtgNotasGasto_DoubleClick
		private void dtgNotasGasto_DoubleClick(object sender, System.EventArgs e)
		{
			EditarNotasGasto();
		}
		#endregion

		#region dtgNotasGasto_CurrentCellChanged
		private void dtgNotasGasto_CurrentCellChanged(object sender, System.EventArgs e)
		{
			try
			{
				if(this.dtgNotasGasto.CurrentRowIndex>-1)
				{
					this.Var_Fila=this.dtgNotasGasto.CurrentRowIndex;
					Utiles.Seleccionar_UnaFilaDataGrid(this,this.dtgNotasGasto,this.Var_Fila);
					this.Var_iIdNota = Int32.Parse(this.dtgNotasGasto[this.Var_Fila,0].ToString());
				}
				else
				{
					this.Var_Fila=-1;
					this.Var_iIdNota=-1;
				}
				Cargar_dtgLineasNotasGastos();
				Cargar_DtgAttCiales();
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion


		#region Cargar_dtgLineasNotasGastos
		private void Cargar_dtgLineasNotasGastos()
		{
			try
			{
				this.TotalLinGast=0;

				this.dsGastos1.ListaLineasNotasGasto.Rows.Clear();			
				
				this.sqldaLineasNotasGasto.SelectCommand.Parameters["@iIdNota"].Value = this.Var_iIdNota;

				this.sqldaLineasNotasGasto.Fill(this.dsGastos1);
				
				for(int i=0;i<this.dsGastos1.ListaLineasNotasGasto.Rows.Count;i++)
				{		
					TotalLinGast += Convert.ToDouble(this.dsGastos1.ListaLineasNotasGasto.Rows[i]["ImporteGasto"].ToString());
				}

                //---- GSG (07/11/2011) Canvi de N4 a N2
                //---- GSG (26/01/2012) Canvi de N2 a N4 ho tornem a deixar com estava
				this.lblLineas.Text = TotalLinGast.ToString("N4");
                //this.lblLineas.Text = TotalLinGast.ToString("N2");
                //---- FI GSG
				this.lblTotLineas.Text=this.dsGastos1.ListaLineasNotasGasto.Rows.Count.ToString();
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region Cargar_DtgAttCiales
		private void Cargar_DtgAttCiales()
		{
			try
			{
				this.TotalAttCom=0;
				//Atenciones Comerciales
				this.dsGastos1.ListaNotaGasto_AtenCom.Rows.Clear();
				this.sqldaListaAtencionesComerciales.SelectCommand.Parameters["@iIdNota"].Value=this.Var_iIdNota;

				this.sqldaListaAtencionesComerciales.Fill(this.dsGastos1);

				for(int i=0;i<this.dsGastos1.ListaNotaGasto_AtenCom.Rows.Count;i++)
				{
					TotalAttCom += Convert.ToDouble(this.dsGastos1.ListaNotaGasto_AtenCom.Rows[i]["fImporte"].ToString());
				}
							
				this.lblTotalAtts.Text = TotalAttCom.ToString("N2");
				this.lblTotAtencion.Text = this.dsGastos1.ListaNotaGasto_AtenCom.Rows.Count.ToString();
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region dtgLineasGasto_CurrentCellChanged
		private void dtgLineasGasto_CurrentCellChanged(object sender, System.EventArgs e)
		{
			try
			{
				Utiles.Seleccionar_UnaFilaDataGrid(this,this.dtgLineasGasto,this.dtgLineasGasto.CurrentRowIndex);
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region dtgAttCiales_CurrentCellChanged
		private void dtgAttCiales_CurrentCellChanged(object sender, System.EventArgs e)
		{
			try
			{
				Utiles.Seleccionar_UnaFilaDataGrid(this,this.dtgAttCiales,this.dtgAttCiales.CurrentRowIndex);		
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

        //---- GSG (12/09/2011)
        private void ActualizarImporteTotal()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                this.TotalImpGast = 0;

                for (int i = 0; i < this.dsGastos1.ListaBuscaGastos.Rows.Count; i++)
                {
                    TotalImpGast += Convert.ToDouble(this.dsGastos1.ListaBuscaGastos.Rows[i]["ImpTotal"].ToString());
                }

                //---- GSG (12/09/2011)
                //txbTotal.Text = TotalImpGast.ToString();

                //txbTotal.Text = TotalImpGast.ToString("N2");
                txbTotal.Text = TotalImpGast.ToString("N4");
                //---- FI GSG
               
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
            Cursor.Current = Cursors.Default;
        }

	}
}
