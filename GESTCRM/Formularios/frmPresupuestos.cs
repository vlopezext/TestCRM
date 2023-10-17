using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace GESTCRM.Formularios
{
	/// <summary>
	/// Descripción breve de frmPresupuestos.
	/// </summary>
	public class frmPresupuestos : System.Windows.Forms.Form
	{

		private string		ParamTipoAcceso;	//Tipo de acceso al formulario A:Alta, M:Modificación, C:Consulta
		private int			ParamiIdDelegado;	//Identificador de delegado

		bool SalirDesdeGuardar;

		private System.Windows.Forms.DataGrid dgDelegados;
		private System.Windows.Forms.Label lblTotDelegados;
		private GESTCRM.Controles.LabelGradient lblDeledados;
		private System.Windows.Forms.Panel pnlDelegados;
		private GESTCRM.Controles.ucBotoneraSecundaria ucBotoneraSecundaria1;
		private System.Windows.Forms.Panel pnlBricks;
		private System.Windows.Forms.Label lblTotBricks;
		private GESTCRM.Controles.LabelGradient lblBricks;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label lblTotPresupuestos;
		private GESTCRM.Controles.LabelGradient lblPresupuestos;
		private System.Windows.Forms.Panel pnAsociarClientes;
		private System.Windows.Forms.Button btnActualizar;
		private System.Windows.Forms.Label lblDelegado;
		private System.Windows.Forms.TextBox txtDelegado;
		private System.Windows.Forms.TextBox txtPresupuesto;
		private System.Windows.Forms.ComboBox cboTipo;
		private System.Windows.Forms.Label lblTipoPresupuesto;
		private System.Windows.Forms.Label lblPresupuesto;
		private System.Data.SqlClient.SqlConnection sqlConn;
		private GESTCRM.Formularios.DataSets.dsPresupuesto dsPresupuesto;
		private System.Data.SqlClient.SqlDataAdapter sqldaListaPresupuestos;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		private System.Data.SqlClient.SqlDataAdapter sqldaDelegadosBrickPresupuestos;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn dtgtiIdDelegado;
		private System.Windows.Forms.DataGridTextBoxColumn dtgtsNombre;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle2;
		private System.Windows.Forms.DataGridTextBoxColumn dgtBrick;
		private System.Windows.Forms.DataGridTextBoxColumn dgtDescripcion;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle3;
		private System.Windows.Forms.DataGridTextBoxColumn dgtiIdDelegado;
		private System.Windows.Forms.DataGridTextBoxColumn dgtfPresupuesto;
		private System.Windows.Forms.DataGridTextBoxColumn dgtsTipoPresupuesto;
		private System.Windows.Forms.DataGridTextBoxColumn dgtiIdDelegadoBrick;
		private System.Windows.Forms.DataGrid dgBircks;
		private System.Windows.Forms.DataGridTextBoxColumn dgtLiteralTipoPresupuesto;
		private System.Windows.Forms.DataGrid dgPresupuestos;
		private System.Windows.Forms.DataGridTextBoxColumn dgtiIdPeriodo;
		private System.Windows.Forms.DataGridTextBoxColumn dgtPresupuestoBrick;
		private System.Data.SqlClient.SqlCommand sqlcomSetPresupuestos;
		/// <summary>
		/// Variable del diseñador requerida.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmPresupuestos()
		{
			//
			// Necesario para admitir el Diseñador de Windows Forms
			//
			InitializeComponent();

			//
			// TODO: agregar código de constructor después de llamar a InitializeComponent
			//
		}
		
		public frmPresupuestos(string TipoAcceso, int iIdDelegado)
		{
            InitializeComponent();

            //---- GSG (06/03/2021)
            Utiles.GetConfigConnection();
            this.sqlConn.ConnectionString = Utiles._connection.ConnectionString.ToString();

            

			this.ParamTipoAcceso=TipoAcceso;//A-> Alta; M->Modificación; C->Consulta
			this.ParamiIdDelegado=iIdDelegado;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPresupuestos));
            System.Configuration.AppSettingsReader configurationAppSettings = new System.Configuration.AppSettingsReader();
            this.pnlDelegados = new System.Windows.Forms.Panel();
            this.dgDelegados = new System.Windows.Forms.DataGrid();
            this.dsPresupuesto = new GESTCRM.Formularios.DataSets.dsPresupuesto();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dtgtiIdDelegado = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dtgtsNombre = new System.Windows.Forms.DataGridTextBoxColumn();
            this.lblTotDelegados = new System.Windows.Forms.Label();
            this.lblDeledados = new GESTCRM.Controles.LabelGradient();
            this.ucBotoneraSecundaria1 = new GESTCRM.Controles.ucBotoneraSecundaria();
            this.pnlBricks = new System.Windows.Forms.Panel();
            this.dgBircks = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
            this.dgtBrick = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dgtDescripcion = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dgtiIdDelegadoBrick = new System.Windows.Forms.DataGridTextBoxColumn();
            this.lblTotBricks = new System.Windows.Forms.Label();
            this.lblBricks = new GESTCRM.Controles.LabelGradient();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgPresupuestos = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle3 = new System.Windows.Forms.DataGridTableStyle();
            this.dgtiIdDelegado = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dgtsTipoPresupuesto = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dgtiIdPeriodo = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dgtLiteralTipoPresupuesto = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dgtfPresupuesto = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dgtPresupuestoBrick = new System.Windows.Forms.DataGridTextBoxColumn();
            this.lblTotPresupuestos = new System.Windows.Forms.Label();
            this.lblPresupuestos = new GESTCRM.Controles.LabelGradient();
            this.pnAsociarClientes = new System.Windows.Forms.Panel();
            this.lblPresupuesto = new System.Windows.Forms.Label();
            this.txtPresupuesto = new System.Windows.Forms.TextBox();
            this.cboTipo = new System.Windows.Forms.ComboBox();
            this.lblTipoPresupuesto = new System.Windows.Forms.Label();
            this.txtDelegado = new System.Windows.Forms.TextBox();
            this.lblDelegado = new System.Windows.Forms.Label();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.sqlConn = new System.Data.SqlClient.SqlConnection();
            this.sqldaListaPresupuestos = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqldaDelegadosBrickPresupuestos = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
            this.sqlcomSetPresupuestos = new System.Data.SqlClient.SqlCommand();
            this.pnlDelegados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDelegados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPresupuesto)).BeginInit();
            this.pnlBricks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgBircks)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPresupuestos)).BeginInit();
            this.pnAsociarClientes.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlDelegados
            // 
            this.pnlDelegados.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlDelegados.Controls.Add(this.dgDelegados);
            this.pnlDelegados.Controls.Add(this.lblTotDelegados);
            this.pnlDelegados.Controls.Add(this.lblDeledados);
            this.pnlDelegados.Location = new System.Drawing.Point(2, 42);
            this.pnlDelegados.Name = "pnlDelegados";
            this.pnlDelegados.Size = new System.Drawing.Size(506, 562);
            this.pnlDelegados.TabIndex = 2;
            // 
            // dgDelegados
            // 
            this.dgDelegados.AllowSorting = false;
            this.dgDelegados.BackgroundColor = System.Drawing.Color.White;
            this.dgDelegados.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.dgDelegados.CaptionText = "Delegados";
            this.dgDelegados.CaptionVisible = false;
            this.dgDelegados.DataMember = "";
            this.dgDelegados.DataSource = this.dsPresupuesto.Delegados;
            this.dgDelegados.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgDelegados.Location = new System.Drawing.Point(0, 18);
            this.dgDelegados.Name = "dgDelegados";
            this.dgDelegados.ReadOnly = true;
            this.dgDelegados.RowHeaderWidth = 15;
            this.dgDelegados.Size = new System.Drawing.Size(500, 540);
            this.dgDelegados.TabIndex = 0;
            this.dgDelegados.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            this.dgDelegados.CurrentCellChanged += new System.EventHandler(this.dgDelegados_CurrentCellChanged);
            // 
            // dsPresupuesto
            // 
            this.dsPresupuesto.DataSetName = "dsPresupuesto";
            this.dsPresupuesto.Locale = new System.Globalization.CultureInfo("en-US");
            this.dsPresupuesto.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.DataGrid = this.dgDelegados;
            this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dtgtiIdDelegado,
            this.dtgtsNombre});
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle1.MappingName = "Delegados";
            this.dataGridTableStyle1.RowHeaderWidth = 15;
            // 
            // dtgtiIdDelegado
            // 
            this.dtgtiIdDelegado.Format = "";
            this.dtgtiIdDelegado.FormatInfo = null;
            this.dtgtiIdDelegado.HeaderText = "iIdDelegado";
            this.dtgtiIdDelegado.MappingName = "iIdDelegado";
            this.dtgtiIdDelegado.Width = 0;
            // 
            // dtgtsNombre
            // 
            this.dtgtsNombre.Format = "";
            this.dtgtsNombre.FormatInfo = null;
            this.dtgtsNombre.HeaderText = "Delegado";
            this.dtgtsNombre.MappingName = "sNombre";
            this.dtgtsNombre.Width = 460;
            // 
            // lblTotDelegados
            // 
            this.lblTotDelegados.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.lblTotDelegados.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotDelegados.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotDelegados.ForeColor = System.Drawing.Color.Black;
            this.lblTotDelegados.Location = new System.Drawing.Point(442, 0);
            this.lblTotDelegados.Name = "lblTotDelegados";
            this.lblTotDelegados.Size = new System.Drawing.Size(60, 18);
            this.lblTotDelegados.TabIndex = 75;
            this.lblTotDelegados.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDeledados
            // 
            this.lblDeledados.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDeledados.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeledados.ForeColor = System.Drawing.Color.White;
            this.lblDeledados.GradientColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.lblDeledados.GradientColorTwo = System.Drawing.Color.White;
            this.lblDeledados.Location = new System.Drawing.Point(0, 0);
            this.lblDeledados.Name = "lblDeledados";
            this.lblDeledados.Size = new System.Drawing.Size(502, 18);
            this.lblDeledados.TabIndex = 0;
            this.lblDeledados.Text = "Delegados";
            this.lblDeledados.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ucBotoneraSecundaria1
            // 
            this.ucBotoneraSecundaria1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(117)))), ((int)(((byte)(1)))));
            this.ucBotoneraSecundaria1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucBotoneraSecundaria1.ForeColor = System.Drawing.Color.Black;
            this.ucBotoneraSecundaria1.Location = new System.Drawing.Point(0, 0);
            this.ucBotoneraSecundaria1.Name = "ucBotoneraSecundaria1";
            this.ucBotoneraSecundaria1.Size = new System.Drawing.Size(944, 38);
            this.ucBotoneraSecundaria1.TabIndex = 37;
            // 
            // pnlBricks
            // 
            this.pnlBricks.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlBricks.Controls.Add(this.dgBircks);
            this.pnlBricks.Controls.Add(this.lblTotBricks);
            this.pnlBricks.Controls.Add(this.lblBricks);
            this.pnlBricks.Location = new System.Drawing.Point(514, 42);
            this.pnlBricks.Name = "pnlBricks";
            this.pnlBricks.Size = new System.Drawing.Size(422, 348);
            this.pnlBricks.TabIndex = 38;
            // 
            // dgBircks
            // 
            this.dgBircks.AllowSorting = false;
            this.dgBircks.BackgroundColor = System.Drawing.Color.White;
            this.dgBircks.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.dgBircks.CaptionText = "Bricks";
            this.dgBircks.CaptionVisible = false;
            this.dgBircks.DataMember = "";
            this.dgBircks.DataSource = this.dsPresupuesto.Bricks;
            this.dgBircks.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgBircks.Location = new System.Drawing.Point(0, 18);
            this.dgBircks.Name = "dgBircks";
            this.dgBircks.ReadOnly = true;
            this.dgBircks.RowHeaderWidth = 15;
            this.dgBircks.Size = new System.Drawing.Size(418, 324);
            this.dgBircks.TabIndex = 0;
            this.dgBircks.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle2});
            // 
            // dataGridTableStyle2
            // 
            this.dataGridTableStyle2.DataGrid = this.dgBircks;
            this.dataGridTableStyle2.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dgtBrick,
            this.dgtDescripcion,
            this.dgtiIdDelegadoBrick});
            this.dataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle2.MappingName = "Bricks";
            this.dataGridTableStyle2.RowHeaderWidth = 15;
            // 
            // dgtBrick
            // 
            this.dgtBrick.Format = "";
            this.dgtBrick.FormatInfo = null;
            this.dgtBrick.HeaderText = "Brick";
            this.dgtBrick.MappingName = "sIdBrick";
            this.dgtBrick.Width = 75;
            // 
            // dgtDescripcion
            // 
            this.dgtDescripcion.Format = "";
            this.dgtDescripcion.FormatInfo = null;
            this.dgtDescripcion.HeaderText = "Descripción";
            this.dgtDescripcion.MappingName = "sDescripcion";
            this.dgtDescripcion.Width = 280;
            // 
            // dgtiIdDelegadoBrick
            // 
            this.dgtiIdDelegadoBrick.Format = "";
            this.dgtiIdDelegadoBrick.FormatInfo = null;
            this.dgtiIdDelegadoBrick.HeaderText = "iIdDelegado";
            this.dgtiIdDelegadoBrick.MappingName = "iIdDelegado";
            this.dgtiIdDelegadoBrick.Width = 0;
            // 
            // lblTotBricks
            // 
            this.lblTotBricks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.lblTotBricks.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotBricks.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotBricks.ForeColor = System.Drawing.Color.Black;
            this.lblTotBricks.Location = new System.Drawing.Point(358, 0);
            this.lblTotBricks.Name = "lblTotBricks";
            this.lblTotBricks.Size = new System.Drawing.Size(60, 18);
            this.lblTotBricks.TabIndex = 75;
            this.lblTotBricks.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBricks
            // 
            this.lblBricks.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblBricks.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBricks.ForeColor = System.Drawing.Color.White;
            this.lblBricks.GradientColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.lblBricks.GradientColorTwo = System.Drawing.Color.White;
            this.lblBricks.Location = new System.Drawing.Point(0, 0);
            this.lblBricks.Name = "lblBricks";
            this.lblBricks.Size = new System.Drawing.Size(418, 18);
            this.lblBricks.TabIndex = 0;
            this.lblBricks.Text = "Bricks";
            this.lblBricks.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.dgPresupuestos);
            this.panel1.Controls.Add(this.lblTotPresupuestos);
            this.panel1.Controls.Add(this.lblPresupuestos);
            this.panel1.Location = new System.Drawing.Point(514, 394);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(422, 210);
            this.panel1.TabIndex = 39;
            // 
            // dgPresupuestos
            // 
            this.dgPresupuestos.AllowSorting = false;
            this.dgPresupuestos.BackgroundColor = System.Drawing.Color.White;
            this.dgPresupuestos.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.dgPresupuestos.CaptionText = "Presupuestos";
            this.dgPresupuestos.CaptionVisible = false;
            this.dgPresupuestos.DataMember = "";
            this.dgPresupuestos.DataSource = this.dsPresupuesto.Presupuestos;
            this.dgPresupuestos.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgPresupuestos.Location = new System.Drawing.Point(0, 18);
            this.dgPresupuestos.Name = "dgPresupuestos";
            this.dgPresupuestos.ReadOnly = true;
            this.dgPresupuestos.RowHeaderWidth = 15;
            this.dgPresupuestos.Size = new System.Drawing.Size(418, 192);
            this.dgPresupuestos.TabIndex = 0;
            this.dgPresupuestos.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle3});
            // 
            // dataGridTableStyle3
            // 
            this.dataGridTableStyle3.DataGrid = this.dgPresupuestos;
            this.dataGridTableStyle3.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dgtiIdDelegado,
            this.dgtsTipoPresupuesto,
            this.dgtiIdPeriodo,
            this.dgtLiteralTipoPresupuesto,
            this.dgtfPresupuesto,
            this.dgtPresupuestoBrick});
            this.dataGridTableStyle3.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle3.MappingName = "Presupuestos";
            this.dataGridTableStyle3.RowHeaderWidth = 15;
            // 
            // dgtiIdDelegado
            // 
            this.dgtiIdDelegado.Format = "";
            this.dgtiIdDelegado.FormatInfo = null;
            this.dgtiIdDelegado.HeaderText = "iIdDelegado";
            this.dgtiIdDelegado.MappingName = "iIdDelegado";
            this.dgtiIdDelegado.Width = 0;
            // 
            // dgtsTipoPresupuesto
            // 
            this.dgtsTipoPresupuesto.Format = "";
            this.dgtsTipoPresupuesto.FormatInfo = null;
            this.dgtsTipoPresupuesto.HeaderText = "Tipo Presupuesto";
            this.dgtsTipoPresupuesto.MappingName = "sTipoPresupuesto";
            this.dgtsTipoPresupuesto.Width = 0;
            // 
            // dgtiIdPeriodo
            // 
            this.dgtiIdPeriodo.Format = "";
            this.dgtiIdPeriodo.FormatInfo = null;
            this.dgtiIdPeriodo.HeaderText = "iIdPeriodo";
            this.dgtiIdPeriodo.MappingName = "iIdPeriodo";
            this.dgtiIdPeriodo.Width = 0;
            // 
            // dgtLiteralTipoPresupuesto
            // 
            this.dgtLiteralTipoPresupuesto.Format = "";
            this.dgtLiteralTipoPresupuesto.FormatInfo = null;
            this.dgtLiteralTipoPresupuesto.HeaderText = "Tipo Presupuesto";
            this.dgtLiteralTipoPresupuesto.MappingName = "LiteralTipoPresupuesto";
            this.dgtLiteralTipoPresupuesto.Width = 200;
            // 
            // dgtfPresupuesto
            // 
            this.dgtfPresupuesto.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dgtfPresupuesto.Format = "N2";
            this.dgtfPresupuesto.FormatInfo = null;
            this.dgtfPresupuesto.HeaderText = "Presupuesto";
            this.dgtfPresupuesto.MappingName = "fImporte";
            this.dgtfPresupuesto.NullText = "";
            this.dgtfPresupuesto.ReadOnly = true;
            this.dgtfPresupuesto.Width = 75;
            // 
            // dgtPresupuestoBrick
            // 
            this.dgtPresupuestoBrick.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dgtPresupuestoBrick.Format = "N2";
            this.dgtPresupuestoBrick.FormatInfo = null;
            this.dgtPresupuestoBrick.HeaderText = "Pres. Birck";
            this.dgtPresupuestoBrick.MappingName = "PresupuestoBrick";
            this.dgtPresupuestoBrick.NullText = "";
            this.dgtPresupuestoBrick.ReadOnly = true;
            this.dgtPresupuestoBrick.Width = 75;
            // 
            // lblTotPresupuestos
            // 
            this.lblTotPresupuestos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.lblTotPresupuestos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotPresupuestos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotPresupuestos.ForeColor = System.Drawing.Color.Black;
            this.lblTotPresupuestos.Location = new System.Drawing.Point(358, 0);
            this.lblTotPresupuestos.Name = "lblTotPresupuestos";
            this.lblTotPresupuestos.Size = new System.Drawing.Size(60, 18);
            this.lblTotPresupuestos.TabIndex = 75;
            this.lblTotPresupuestos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPresupuestos
            // 
            this.lblPresupuestos.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPresupuestos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPresupuestos.ForeColor = System.Drawing.Color.White;
            this.lblPresupuestos.GradientColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.lblPresupuestos.GradientColorTwo = System.Drawing.Color.White;
            this.lblPresupuestos.Location = new System.Drawing.Point(0, 0);
            this.lblPresupuestos.Name = "lblPresupuestos";
            this.lblPresupuestos.Size = new System.Drawing.Size(418, 18);
            this.lblPresupuestos.TabIndex = 0;
            this.lblPresupuestos.Text = "Presupuestos";
            this.lblPresupuestos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnAsociarClientes
            // 
            this.pnAsociarClientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnAsociarClientes.Controls.Add(this.lblPresupuesto);
            this.pnAsociarClientes.Controls.Add(this.txtPresupuesto);
            this.pnAsociarClientes.Controls.Add(this.cboTipo);
            this.pnAsociarClientes.Controls.Add(this.lblTipoPresupuesto);
            this.pnAsociarClientes.Controls.Add(this.txtDelegado);
            this.pnAsociarClientes.Controls.Add(this.lblDelegado);
            this.pnAsociarClientes.Controls.Add(this.btnActualizar);
            this.pnAsociarClientes.Location = new System.Drawing.Point(6, 612);
            this.pnAsociarClientes.Name = "pnAsociarClientes";
            this.pnAsociarClientes.Size = new System.Drawing.Size(932, 36);
            this.pnAsociarClientes.TabIndex = 105;
            // 
            // lblPresupuesto
            // 
            this.lblPresupuesto.AutoSize = true;
            this.lblPresupuesto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblPresupuesto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblPresupuesto.ForeColor = System.Drawing.Color.Black;
            this.lblPresupuesto.Location = new System.Drawing.Point(624, 10);
            this.lblPresupuesto.Name = "lblPresupuesto";
            this.lblPresupuesto.Size = new System.Drawing.Size(69, 13);
            this.lblPresupuesto.TabIndex = 110;
            this.lblPresupuesto.Text = "Presupuesto:";
            // 
            // txtPresupuesto
            // 
            this.txtPresupuesto.BackColor = System.Drawing.Color.White;
            this.txtPresupuesto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtPresupuesto.Location = new System.Drawing.Point(714, 8);
            this.txtPresupuesto.MaxLength = 10;
            this.txtPresupuesto.Name = "txtPresupuesto";
            this.txtPresupuesto.Size = new System.Drawing.Size(102, 20);
            this.txtPresupuesto.TabIndex = 107;
            this.txtPresupuesto.Text = "0,00";
            this.txtPresupuesto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPresupuesto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPresupuesto_KeyPress);
            // 
            // cboTipo
            // 
            this.cboTipo.BackColor = System.Drawing.Color.White;
            this.cboTipo.DataSource = this.dsPresupuesto.ListaPresupuesto;
            this.cboTipo.DisplayMember = "sLiteral";
            this.cboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cboTipo.Location = new System.Drawing.Point(430, 6);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Size = new System.Drawing.Size(182, 21);
            this.cboTipo.TabIndex = 108;
            this.cboTipo.ValueMember = "sValor";
            // 
            // lblTipoPresupuesto
            // 
            this.lblTipoPresupuesto.AutoSize = true;
            this.lblTipoPresupuesto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblTipoPresupuesto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblTipoPresupuesto.ForeColor = System.Drawing.Color.Black;
            this.lblTipoPresupuesto.Location = new System.Drawing.Point(328, 10);
            this.lblTipoPresupuesto.Name = "lblTipoPresupuesto";
            this.lblTipoPresupuesto.Size = new System.Drawing.Size(93, 13);
            this.lblTipoPresupuesto.TabIndex = 109;
            this.lblTipoPresupuesto.Text = "Tipo Presupuesto:";
            // 
            // txtDelegado
            // 
            this.txtDelegado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtDelegado.ForeColor = System.Drawing.Color.Black;
            this.txtDelegado.Location = new System.Drawing.Point(70, 8);
            this.txtDelegado.Name = "txtDelegado";
            this.txtDelegado.ReadOnly = true;
            this.txtDelegado.Size = new System.Drawing.Size(252, 20);
            this.txtDelegado.TabIndex = 106;
            this.txtDelegado.TabStop = false;
            // 
            // lblDelegado
            // 
            this.lblDelegado.AutoSize = true;
            this.lblDelegado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblDelegado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblDelegado.ForeColor = System.Drawing.Color.Black;
            this.lblDelegado.Location = new System.Drawing.Point(10, 10);
            this.lblDelegado.Name = "lblDelegado";
            this.lblDelegado.Size = new System.Drawing.Size(56, 13);
            this.lblDelegado.TabIndex = 105;
            this.lblDelegado.Text = "Delegado:";
            // 
            // btnActualizar
            // 
            this.btnActualizar.ForeColor = System.Drawing.Color.Black;
            this.btnActualizar.Image = ((System.Drawing.Image)(resources.GetObject("btnActualizar.Image")));
            this.btnActualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnActualizar.Location = new System.Drawing.Point(844, 7);
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
            //this.sqlConn.ConnectionString = ((string)(configurationAppSettings.GetValue("sConn", typeof(string))));//---- GSG (10/09/2014)
            this.sqlConn = Utiles._connection;
            this.sqlConn.FireInfoMessageEventOnUserErrors = false;
            // 
            // sqldaListaPresupuestos
            // 
            this.sqldaListaPresupuestos.SelectCommand = this.sqlSelectCommand1;
            this.sqldaListaPresupuestos.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaPresupuesto", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("sValor", "sValor"),
                        new System.Data.Common.DataColumnMapping("sLiteral", "sLiteral")})});
            // 
            // sqlSelectCommand1
            // 
            this.sqlSelectCommand1.CommandText = "[ListaTipoPresupuesto]";
            this.sqlSelectCommand1.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand1.Connection = this.sqlConn;
            this.sqlSelectCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null)});
            // 
            // sqldaDelegadosBrickPresupuestos
            // 
            this.sqldaDelegadosBrickPresupuestos.SelectCommand = this.sqlSelectCommand2;
            this.sqldaDelegadosBrickPresupuestos.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaDelegadoBrickPresupuesto", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iIdDelegado", "iIdDelegado"),
                        new System.Data.Common.DataColumnMapping("sNombre", "sNombre")}),
            new System.Data.Common.DataTableMapping("Table1", "Table1", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iIdDelegado", "iIdDelegado"),
                        new System.Data.Common.DataColumnMapping("sIdBrick", "sIdBrick"),
                        new System.Data.Common.DataColumnMapping("dFAR", "dFAR"),
                        new System.Data.Common.DataColumnMapping("fPresupuesto", "fPresupuesto"),
                        new System.Data.Common.DataColumnMapping("sTipoPresupuesto", "sTipoPresupuesto")}),
            new System.Data.Common.DataTableMapping("Table2", "Table2", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("Expr1", "Expr1"),
                        new System.Data.Common.DataColumnMapping("sDescripcion", "sDescripcion")})});
            // 
            // sqlSelectCommand2
            // 
            this.sqlSelectCommand2.CommandText = "[ListaDelegadoBrickPresupuesto]";
            this.sqlSelectCommand2.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand2.Connection = this.sqlConn;
            this.sqlSelectCommand2.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null)});
            // 
            // sqlcomSetPresupuestos
            // 
            this.sqlcomSetPresupuestos.CommandText = "[SetPresupuestos]";
            this.sqlcomSetPresupuestos.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlcomSetPresupuestos.Connection = this.sqlConn;
            this.sqlcomSetPresupuestos.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdDelegado", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sTipoPresupuesto", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@iIdPeriodo", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@fImporte", System.Data.SqlDbType.Float, 8)});
            // 
            // frmPresupuestos
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(944, 654);
            this.Controls.Add(this.pnAsociarClientes);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlBricks);
            this.Controls.Add(this.ucBotoneraSecundaria1);
            this.Controls.Add(this.pnlDelegados);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPresupuestos";
            this.Text = "frmPresupuestos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPresupuestos_Load);
            this.pnlDelegados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgDelegados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPresupuesto)).EndInit();
            this.pnlBricks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgBircks)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgPresupuestos)).EndInit();
            this.pnAsociarClientes.ResumeLayout(false);
            this.pnAsociarClientes.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		#region InicializaCombos
		/// <summary>
		/// Inicializa Combo Tipos presupuesto.
		/// </summary>
		private void InicializaComboTipoPresupuesto()
		{
			try
			{
				sqldaListaPresupuestos.Fill(dsPresupuesto);
				cboTipo.SelectedValue = "C";//Delegado Medico
			}
			catch (Exception ex)
			{
				Mensajes.ShowError(ex.Message);
			}
		}
		#endregion

		private void frmPresupuestos_Load(object sender, System.EventArgs e)
		{
			InicilalizarFrmPresupuestos();
			FiltarBricks();
			FiltrarPresupuestos();
			BloqueaDesBloqueaActualizar();
			this.SalirDesdeGuardar=true;
			
		}
		private void InicilalizarFrmPresupuestos()
		{
			Utiles.Formato_Formulario(this);
			InicializaComboTipoPresupuesto();
			
			Inicializar_DataGrids();

			if( dsPresupuesto.PeriodosPresupuestos.Rows.Count == 0)
			{
				Mensajes.ShowInformation("No existe ningun periodo de presupuestos activo para fecha actual.");
				ParamTipoAcceso = "C";
			}
			if (ParamTipoAcceso == "C")
			{
				btnActualizar.Enabled = false;
				cboTipo.Enabled = false;
			}
			Inicializar_Botonera();
		}

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
	
		#region Inicializar_DataGrids
		private void Inicializar_DataGrids()
		{
			try
			{
				GESTCRM.Utiles.Formatear_DataGrid(dgDelegados ,null,null);
				GESTCRM.Utiles.Formatear_DataGrid(dgBircks ,null,null);
				GESTCRM.Utiles.Formatear_DataGrid(dgPresupuestos,null,null);
				//Regoge los Datos con un solo DataAdapter, haciendo los TableMappings Correspondientes

				dsPresupuesto.Bricks.Rows.Clear();
				dsPresupuesto.Delegados.Rows.Clear();
				dsPresupuesto.Presupuestos.Rows.Clear();
  
				sqldaDelegadosBrickPresupuestos.TableMappings.Clear();
				sqldaDelegadosBrickPresupuestos.TableMappings.Add("Table","Delegados");   
				sqldaDelegadosBrickPresupuestos.TableMappings.Add("Table1","Bricks");   
				sqldaDelegadosBrickPresupuestos.TableMappings.Add("Table2","Presupuestos");   
				sqldaDelegadosBrickPresupuestos.TableMappings.Add("Table3","PeriodosPresupuestos"); 

				sqldaDelegadosBrickPresupuestos.Fill(dsPresupuesto);
				dsPresupuesto.AcceptChanges();
				lblTotDelegados.Text = dsPresupuesto.Delegados.Count.ToString();
				
			}
			catch(Exception e)
			{
				Mensajes.ShowError(e.Message);
			}
		}
		#endregion

		#region Filtros datagrid
		private void FiltarBricks()
		{
			if( dgDelegados.CurrentRowIndex != -1)
			{
				txtDelegado.Text = dgDelegados[dgDelegados.CurrentRowIndex,1].ToString();
				string sIdDelegado = this.dgDelegados[this.dgDelegados.CurrentRowIndex,0].ToString();
				dsPresupuesto.Bricks.DefaultView.RowFilter = "iIdDelegado = " + sIdDelegado ;
				lblTotBricks.Text = dsPresupuesto.Bricks.DefaultView.Count.ToString();
			}
		}
		private void FiltrarPresupuestos()
		{
			if( dgDelegados.CurrentRowIndex != -1)// && dgBircks.CurrentRowIndex != -1)
			{
				string sIdDelegado = dgDelegados[dgDelegados.CurrentRowIndex,0].ToString();

				dsPresupuesto.Presupuestos.DefaultView.RowFilter = "iIdDelegado = " + sIdDelegado ;
				lblTotPresupuestos.Text = dsPresupuesto.Presupuestos.DefaultView.Count.ToString();
			}


		}
		#endregion

		#region btGrabar_Click
		private void btGrabar_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (Grabar_Presupuesto())
				{
					Mensajes.ShowInformation(3004);
					this.SalirDesdeGuardar=true;
					this.Close();
				}//del Grabar
			}//del try
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		private bool Grabar_Presupuesto()
		{
			bool bOk = true;
			if (this.sqlConn.State == ConnectionState.Closed ) sqlConn.Open(); 
			try
			{
				foreach( DataRow oRow in dsPresupuesto.Presupuestos.Rows)
				{
					sqlcomSetPresupuestos.Parameters["@iIdDelegado"].Value = oRow["iIdDelegado"].ToString();
					sqlcomSetPresupuestos.Parameters["@sTipoPresupuesto"].Value = oRow["sTipoPresupuesto"].ToString();
					sqlcomSetPresupuestos.Parameters["@iIdPeriodo"].Value = oRow["iIdPeriodo"].ToString();
					sqlcomSetPresupuestos.Parameters["@fImporte"].Value = oRow["fImporte"].ToString();
					sqlcomSetPresupuestos.ExecuteNonQuery();
				}
			}
			catch(Exception Ex)
			{
				Mensajes.ShowError(Ex.Message);
				bOk = false;
			}
			finally
			{
				sqlConn.Close();
			}

			return bOk;
		}

		#region btSalir_Click
		private void btSalir_Click(object sender, System.EventArgs e)
		{
			if (this.dsPresupuesto.PeriodosPresupuestos.Rows.Count>0)
			{
				DialogResult dr1=Mensajes.ShowQuestion(3002);
				if(dr1 == System.Windows.Forms.DialogResult.Yes)
				{
					if (Grabar_Presupuesto())
					{
						Mensajes.ShowInformation(3004);
						this.SalirDesdeGuardar=true;
						this.Close();
					}//del Grabar
				}
				else
				{
					this.SalirDesdeGuardar=true;
					this.Close();
				}
				//			this.SalirDesdeGuardar=true;
				//			this.Close();
			}
			else
			{
				this.SalirDesdeGuardar=true;
				this.Close();
			}
		}
		#endregion


		private void dgDelegados_CurrentCellChanged(object sender, System.EventArgs e)
		{
			FiltarBricks();
			FiltrarPresupuestos();
			BloqueaDesBloqueaActualizar();
		}

		private void BloqueaDesBloqueaActualizar()
		{
			if (dgBircks.CurrentRowIndex == -1)
			{	
				cboTipo.Enabled = false;
				txtPresupuesto.ReadOnly = true;
				btnActualizar.Enabled =false;
			}
			else
			{
				cboTipo.Enabled = true;
				txtPresupuesto.ReadOnly = false;
				btnActualizar.Enabled =true;
			}
		}

		private void btnActualizar_Click(object sender, System.EventArgs e)
		{
			try
			{
				string sDelegado = dgDelegados[dgDelegados.CurrentRowIndex,0].ToString();
				string sTipoPresupuesto = cboTipo.SelectedValue.ToString();
				string sLiteralTipoPresupuesto =  cboTipo.Text;

				int NumFilaDg = Utiles.Buscar_fila_dtTabla( dsPresupuesto.Presupuestos ,"iIdDelegado",sDelegado,"sTipoPresupuesto",sTipoPresupuesto);
				if(NumFilaDg==-1) //Insertar en pantalla
				{
					
					DataRow oRow = dsPresupuesto.Presupuestos.NewRow();
					oRow["iIdDelegado"]= sDelegado;
					oRow["sTipoPresupuesto"] = sTipoPresupuesto;
					oRow["iIdPeriodo"]= dsPresupuesto.PeriodosPresupuestos.Rows[0]["iIdPeriodo"].ToString();
					oRow["fImporte"] = Math.Round( Double.Parse(txtPresupuesto.Text),2);
					oRow["LiteralTipoPresupuesto"]= sLiteralTipoPresupuesto;
					oRow["PresupuestoBrick"]= Math.Round((Double.Parse(txtPresupuesto.Text)/Int32.Parse(lblTotBricks.Text)),2);

					dsPresupuesto.Presupuestos.Rows.Add(oRow);
					dsPresupuesto.Presupuestos.AcceptChanges();

					FiltrarPresupuestos();
				}
				else
				{
					dsPresupuesto.Presupuestos.Rows[NumFilaDg]["fImporte"]= Math.Round( Double.Parse(txtPresupuesto.Text),2);
					dsPresupuesto.Presupuestos.Rows[NumFilaDg]["sTipoPresupuesto"]= sTipoPresupuesto;
					dsPresupuesto.Presupuestos.Rows[NumFilaDg]["LiteralTipoPresupuesto"]= sLiteralTipoPresupuesto;
					dsPresupuesto.Presupuestos.Rows[NumFilaDg]["PresupuestoBrick"]= Math.Round((Double.Parse(txtPresupuesto.Text)/Int32.Parse(lblTotBricks.Text)),2);

				
				}
				txtPresupuesto.Text = "0,00";
				cboTipo.SelectedValue = "C";//Delegado Medico
			}
			catch(Exception ex)
			{
				Mensajes.ShowError(ex.Message);
			}
		}


		private void txtPresupuesto_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{	
			//Solo de aparecen numeros y una coma
			if( char.IsNumber(e.KeyChar))
			{
				e.Handled = false;
			}
			else if( char.IsControl(e.KeyChar))
			{
				e.Handled = false;
			}
			else if(e.KeyChar == char.Parse(",") )
			{
				if(txtPresupuesto.Text.IndexOf(",",0)>0)
				{
					e.Handled = true;	
				}
				else
				{
					e.Handled = false;
				}
			}
			else
			{
				e.Handled = true;
			}

		}

	
		
	}
}
