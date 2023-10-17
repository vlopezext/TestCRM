using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace GESTCRM.Formularios.Busquedas
{
	/// <summary>
	/// Descripción breve de frmMCentros.
	/// </summary>
	public class frmMCentros : System.Windows.Forms.Form
	{
		public int		ParamI_iIdDelegado;
		public int		ParamO_iIdCentro;
		public string	ParamIO_sIdCentro;
		public string	ParamIO_sDescripcion;
		public string   ParamIO_sIdRed;
		public string   ParamO_tRed;
		public bool	    ParamI_BloquearRed= false;

		private System.Windows.Forms.Panel pnlCentros;
		private System.Windows.Forms.Label lblCodCentro;
		private System.Windows.Forms.Label lblDesc;
		private System.Data.SqlClient.SqlConnection sqlConn;
		private GESTCRM.Formularios.Busquedas.dsBuscar dsBuscar1;
		private System.Data.SqlClient.SqlDataAdapter sqldaListaBuscaCentros;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
		private System.Windows.Forms.Button btBuscar;
		private System.Windows.Forms.TextBox txbsDescripcion;
		private System.Windows.Forms.TextBox txbsIdCentro;
		private System.Windows.Forms.Button btCancelar;
		private System.Windows.Forms.Button btAceptar;
		private System.Windows.Forms.DataGrid dgCentros;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label lblNumReg;
		private GESTCRM.Controles.LabelGradient labelGradient2;
		private System.Windows.Forms.TextBox txtCodPostal;
		private System.Windows.Forms.Label lblCodPostal;
		private System.Windows.Forms.Button btnBuscPob;
		private System.Windows.Forms.TextBox txbBPoblacion;
		private System.Windows.Forms.Label lblCliente;
		private System.Windows.Forms.TextBox txbIdPoblacion;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
		private System.Windows.Forms.ComboBox cboRed;
		private System.Windows.Forms.Label label1;
		private System.Data.SqlClient.SqlDataAdapter sqldaListaRedes;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand4;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn5;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn6;
		/// <summary>
		/// Variable del diseñador requerida.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmMCentros()
		{
            InitializeComponent();

            //---- GSG (06/03/2021)
            Utiles.GetConfigConnection();
            this.sqlConn.ConnectionString = Utiles._connection.ConnectionString.ToString();

            

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMCentros));
            System.Configuration.AppSettingsReader configurationAppSettings = new System.Configuration.AppSettingsReader();
            this.dgCentros = new System.Windows.Forms.DataGrid();
            this.dsBuscar1 = new GESTCRM.Formularios.Busquedas.dsBuscar();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn5 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn6 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.pnlCentros = new System.Windows.Forms.Panel();
            this.cboRed = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodPostal = new System.Windows.Forms.TextBox();
            this.lblCodPostal = new System.Windows.Forms.Label();
            this.btnBuscPob = new System.Windows.Forms.Button();
            this.txbBPoblacion = new System.Windows.Forms.TextBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.btBuscar = new System.Windows.Forms.Button();
            this.txbsDescripcion = new System.Windows.Forms.TextBox();
            this.txbsIdCentro = new System.Windows.Forms.TextBox();
            this.lblCodCentro = new System.Windows.Forms.Label();
            this.lblDesc = new System.Windows.Forms.Label();
            this.txbIdPoblacion = new System.Windows.Forms.TextBox();
            this.sqlConn = new System.Data.SqlClient.SqlConnection();
            this.sqldaListaBuscaCentros = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
            this.btCancelar = new System.Windows.Forms.Button();
            this.btAceptar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblNumReg = new System.Windows.Forms.Label();
            this.labelGradient2 = new GESTCRM.Controles.LabelGradient();
            this.sqldaListaRedes = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand4 = new System.Data.SqlClient.SqlCommand();
            ((System.ComponentModel.ISupportInitialize)(this.dgCentros)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBuscar1)).BeginInit();
            this.pnlCentros.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgCentros
            // 
            this.dgCentros.BackgroundColor = System.Drawing.Color.White;
            this.dgCentros.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.dgCentros.CaptionVisible = false;
            this.dgCentros.DataMember = "ListaBuscaCentros";
            this.dgCentros.DataSource = this.dsBuscar1;
            this.dgCentros.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgCentros.Location = new System.Drawing.Point(-2, 18);
            this.dgCentros.Name = "dgCentros";
            this.dgCentros.ReadOnly = true;
            this.dgCentros.RowHeaderWidth = 17;
            this.dgCentros.Size = new System.Drawing.Size(798, 326);
            this.dgCentros.TabIndex = 0;
            this.dgCentros.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            this.dgCentros.CurrentCellChanged += new System.EventHandler(this.dgCentros_CurrentCellChanged);
            this.dgCentros.DoubleClick += new System.EventHandler(this.dgCentros_DoubleClick);
            // 
            // dsBuscar1
            // 
            this.dsBuscar1.DataSetName = "dsBuscar";
            this.dsBuscar1.Locale = new System.Globalization.CultureInfo("es-ES");
            this.dsBuscar1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.DataGrid = this.dgCentros;
            this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn1,
            this.dataGridTextBoxColumn2,
            this.dataGridTextBoxColumn3,
            this.dataGridTextBoxColumn4,
            this.dataGridTextBoxColumn5,
            this.dataGridTextBoxColumn6});
            this.dataGridTableStyle1.HeaderBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle1.MappingName = "ListaBuscaCentros";
            this.dataGridTableStyle1.RowHeaderWidth = 17;
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "Código";
            this.dataGridTextBoxColumn1.MappingName = "Codigo";
            this.dataGridTextBoxColumn1.Width = 70;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "Nombre";
            this.dataGridTextBoxColumn2.MappingName = "Nombre";
            this.dataGridTextBoxColumn2.Width = 300;
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.MappingName = "iIdCentro";
            this.dataGridTextBoxColumn3.Width = 0;
            // 
            // dataGridTextBoxColumn4
            // 
            this.dataGridTextBoxColumn4.Format = "";
            this.dataGridTextBoxColumn4.FormatInfo = null;
            this.dataGridTextBoxColumn4.HeaderText = "Tipo Centro";
            this.dataGridTextBoxColumn4.MappingName = "sTipoCentro";
            this.dataGridTextBoxColumn4.NullText = "";
            this.dataGridTextBoxColumn4.Width = 180;
            // 
            // dataGridTextBoxColumn5
            // 
            this.dataGridTextBoxColumn5.Format = "";
            this.dataGridTextBoxColumn5.FormatInfo = null;
            this.dataGridTextBoxColumn5.MappingName = "sIdRed";
            this.dataGridTextBoxColumn5.ReadOnly = true;
            this.dataGridTextBoxColumn5.Width = 0;
            // 
            // dataGridTextBoxColumn6
            // 
            this.dataGridTextBoxColumn6.Format = "";
            this.dataGridTextBoxColumn6.FormatInfo = null;
            this.dataGridTextBoxColumn6.HeaderText = "Red";
            this.dataGridTextBoxColumn6.MappingName = "tRed";
            this.dataGridTextBoxColumn6.Width = 80;
            // 
            // pnlCentros
            // 
            this.pnlCentros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCentros.Controls.Add(this.cboRed);
            this.pnlCentros.Controls.Add(this.label1);
            this.pnlCentros.Controls.Add(this.txtCodPostal);
            this.pnlCentros.Controls.Add(this.lblCodPostal);
            this.pnlCentros.Controls.Add(this.btnBuscPob);
            this.pnlCentros.Controls.Add(this.txbBPoblacion);
            this.pnlCentros.Controls.Add(this.lblCliente);
            this.pnlCentros.Controls.Add(this.btBuscar);
            this.pnlCentros.Controls.Add(this.txbsDescripcion);
            this.pnlCentros.Controls.Add(this.txbsIdCentro);
            this.pnlCentros.Controls.Add(this.lblCodCentro);
            this.pnlCentros.Controls.Add(this.lblDesc);
            this.pnlCentros.Controls.Add(this.txbIdPoblacion);
            this.pnlCentros.Location = new System.Drawing.Point(3, 5);
            this.pnlCentros.Name = "pnlCentros";
            this.pnlCentros.Size = new System.Drawing.Size(811, 71);
            this.pnlCentros.TabIndex = 0;
            // 
            // cboRed
            // 
            this.cboRed.BackColor = System.Drawing.Color.White;
            this.cboRed.DataSource = this.dsBuscar1.ListaRedes;
            this.cboRed.DisplayMember = "sLiteral";
            this.cboRed.ForeColor = System.Drawing.Color.Black;
            this.cboRed.Location = new System.Drawing.Point(566, 8);
            this.cboRed.Name = "cboRed";
            this.cboRed.Size = new System.Drawing.Size(121, 28);
            this.cboRed.TabIndex = 96;
            this.cboRed.ValueMember = "sValor";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(524, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 20);
            this.label1.TabIndex = 97;
            this.label1.Text = "Red:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtCodPostal
            // 
            this.txtCodPostal.BackColor = System.Drawing.Color.White;
            this.txtCodPostal.ForeColor = System.Drawing.Color.Black;
            this.txtCodPostal.Location = new System.Drawing.Point(50, 38);
            this.txtCodPostal.MaxLength = 5;
            this.txtCodPostal.Name = "txtCodPostal";
            this.txtCodPostal.Size = new System.Drawing.Size(78, 26);
            this.txtCodPostal.TabIndex = 2;
            this.txtCodPostal.TextChanged += new System.EventHandler(this.txtCodPostal_TextChanged);
            this.txtCodPostal.Leave += new System.EventHandler(this.txtCodPostal_Leave);
            // 
            // lblCodPostal
            // 
            this.lblCodPostal.ForeColor = System.Drawing.Color.Black;
            this.lblCodPostal.Location = new System.Drawing.Point(8, 41);
            this.lblCodPostal.Name = "lblCodPostal";
            this.lblCodPostal.Size = new System.Drawing.Size(42, 20);
            this.lblCodPostal.TabIndex = 86;
            this.lblCodPostal.Text = "C.P.:";
            this.lblCodPostal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnBuscPob
            // 
            this.btnBuscPob.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscPob.Image")));
            this.btnBuscPob.Location = new System.Drawing.Point(493, 38);
            this.btnBuscPob.Name = "btnBuscPob";
            this.btnBuscPob.Size = new System.Drawing.Size(25, 26);
            this.btnBuscPob.TabIndex = 4;
            this.btnBuscPob.UseVisualStyleBackColor = true;
            this.btnBuscPob.Click += new System.EventHandler(this.btnBuscPob_Click);
            // 
            // txbBPoblacion
            // 
            this.txbBPoblacion.BackColor = System.Drawing.SystemColors.Window;
            this.txbBPoblacion.ForeColor = System.Drawing.Color.Black;
            this.txbBPoblacion.Location = new System.Drawing.Point(228, 37);
            this.txbBPoblacion.MaxLength = 50;
            this.txbBPoblacion.Name = "txbBPoblacion";
            this.txbBPoblacion.Size = new System.Drawing.Size(259, 26);
            this.txbBPoblacion.TabIndex = 3;
            this.txbBPoblacion.TextChanged += new System.EventHandler(this.txbBPoblacion_TextChanged);
            this.txbBPoblacion.Leave += new System.EventHandler(this.txbBPoblacion_Leave);
            // 
            // lblCliente
            // 
            this.lblCliente.ForeColor = System.Drawing.Color.Black;
            this.lblCliente.Location = new System.Drawing.Point(147, 40);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(82, 20);
            this.lblCliente.TabIndex = 85;
            this.lblCliente.Text = "Poblacion:";
            this.lblCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btBuscar
            // 
            this.btBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btBuscar.Location = new System.Drawing.Point(722, 23);
            this.btBuscar.Name = "btBuscar";
            this.btBuscar.Size = new System.Drawing.Size(75, 29);
            this.btBuscar.TabIndex = 5;
            this.btBuscar.Text = "&Buscar";
            this.btBuscar.UseVisualStyleBackColor = true;
            this.btBuscar.Click += new System.EventHandler(this.btBuscar_Click);
            // 
            // txbsDescripcion
            // 
            this.txbsDescripcion.Location = new System.Drawing.Point(247, 8);
            this.txbsDescripcion.MaxLength = 100;
            this.txbsDescripcion.Name = "txbsDescripcion";
            this.txbsDescripcion.Size = new System.Drawing.Size(271, 26);
            this.txbsDescripcion.TabIndex = 1;
            this.txbsDescripcion.TextChanged += new System.EventHandler(this.txbsDescripcion_TextChanged);
            // 
            // txbsIdCentro
            // 
            this.txbsIdCentro.Location = new System.Drawing.Point(70, 8);
            this.txbsIdCentro.MaxLength = 20;
            this.txbsIdCentro.Name = "txbsIdCentro";
            this.txbsIdCentro.Size = new System.Drawing.Size(102, 26);
            this.txbsIdCentro.TabIndex = 0;
            this.txbsIdCentro.TextChanged += new System.EventHandler(this.txbsIdCentro_TextChanged);
            // 
            // lblCodCentro
            // 
            this.lblCodCentro.AutoSize = true;
            this.lblCodCentro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodCentro.Location = new System.Drawing.Point(7, 10);
            this.lblCodCentro.Name = "lblCodCentro";
            this.lblCodCentro.Size = new System.Drawing.Size(63, 20);
            this.lblCodCentro.TabIndex = 3;
            this.lblCodCentro.Text = "Código:";
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesc.Location = new System.Drawing.Point(178, 11);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(69, 20);
            this.lblDesc.TabIndex = 2;
            this.lblDesc.Text = "Nombre:";
            // 
            // txbIdPoblacion
            // 
            this.txbIdPoblacion.BackColor = System.Drawing.Color.White;
            this.txbIdPoblacion.ForeColor = System.Drawing.Color.Black;
            this.txbIdPoblacion.Location = new System.Drawing.Point(310, 39);
            this.txbIdPoblacion.Name = "txbIdPoblacion";
            this.txbIdPoblacion.Size = new System.Drawing.Size(72, 26);
            this.txbIdPoblacion.TabIndex = 87;
            this.txbIdPoblacion.Visible = false;
            // 
            // sqlConn
            // 
            this.sqlConn.ConnectionString = Utiles._connection.ConnectionString.ToString();   //---- GSG (06/03/2021)
            this.sqlConn.FireInfoMessageEventOnUserErrors = false;
            // 
            // sqldaListaBuscaCentros
            // 
            this.sqldaListaBuscaCentros.SelectCommand = this.sqlSelectCommand1;
            this.sqldaListaBuscaCentros.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaBuscaCentros", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iIdCentro", "iIdCentro"),
                        new System.Data.Common.DataColumnMapping("Codigo", "Codigo"),
                        new System.Data.Common.DataColumnMapping("Nombre", "Nombre"),
                        new System.Data.Common.DataColumnMapping("sIdTipoCentro", "sIdTipoCentro"),
                        new System.Data.Common.DataColumnMapping("sTipoCentro", "sTipoCentro"),
                        new System.Data.Common.DataColumnMapping("iOrden", "iOrden")})});
            // 
            // sqlSelectCommand1
            // 
            this.sqlSelectCommand1.CommandText = "[ListaBuscaCentros]";
            this.sqlSelectCommand1.CommandTimeout = 60;
            this.sqlSelectCommand1.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand1.Connection = this.sqlConn;
            this.sqlSelectCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdDelegado", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sIdCentro", System.Data.SqlDbType.VarChar, 20),
            new System.Data.SqlClient.SqlParameter("@sDescripcion", System.Data.SqlDbType.VarChar, 100),
            new System.Data.SqlClient.SqlParameter("@iIdPoblacion", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sCodPostal", System.Data.SqlDbType.VarChar, 5),
            new System.Data.SqlClient.SqlParameter("@iIdProvincia", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sPoblacion", System.Data.SqlDbType.VarChar, 50),
            new System.Data.SqlClient.SqlParameter("@sIdRed", System.Data.SqlDbType.VarChar, 4)});
            // 
            // btCancelar
            // 
            this.btCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btCancelar.Location = new System.Drawing.Point(626, 444);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(80, 29);
            this.btCancelar.TabIndex = 3;
            this.btCancelar.Text = "&Cancelar";
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // btAceptar
            // 
            this.btAceptar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btAceptar.Location = new System.Drawing.Point(516, 444);
            this.btAceptar.Name = "btAceptar";
            this.btAceptar.Size = new System.Drawing.Size(80, 29);
            this.btAceptar.TabIndex = 2;
            this.btAceptar.Text = "&Aceptar";
            this.btAceptar.UseVisualStyleBackColor = true;
            this.btAceptar.Click += new System.EventHandler(this.btAceptar_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.lblNumReg);
            this.panel1.Controls.Add(this.labelGradient2);
            this.panel1.Controls.Add(this.dgCentros);
            this.panel1.Location = new System.Drawing.Point(3, 82);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(811, 346);
            this.panel1.TabIndex = 1;
            // 
            // lblNumReg
            // 
            this.lblNumReg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.lblNumReg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblNumReg.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumReg.ForeColor = System.Drawing.Color.Black;
            this.lblNumReg.Location = new System.Drawing.Point(608, 0);
            this.lblNumReg.Name = "lblNumReg";
            this.lblNumReg.Size = new System.Drawing.Size(60, 18);
            this.lblNumReg.TabIndex = 87;
            this.lblNumReg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelGradient2
            // 
            this.labelGradient2.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelGradient2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGradient2.ForeColor = System.Drawing.Color.White;
            this.labelGradient2.GradientColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.labelGradient2.GradientColorTwo = System.Drawing.Color.White;
            this.labelGradient2.Location = new System.Drawing.Point(0, 0);
            this.labelGradient2.Name = "labelGradient2";
            this.labelGradient2.Size = new System.Drawing.Size(807, 18);
            this.labelGradient2.TabIndex = 86;
            this.labelGradient2.Text = "Resultado de la Búsqueda";
            this.labelGradient2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sqldaListaRedes
            // 
            this.sqldaListaRedes.SelectCommand = this.sqlSelectCommand4;
            this.sqldaListaRedes.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaRedes", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("sValor", "sValor"),
                        new System.Data.Common.DataColumnMapping("sLiteral", "sLiteral")})});
            // 
            // sqlSelectCommand4
            // 
            this.sqlSelectCommand4.CommandText = "[ListaRedes]";
            this.sqlSelectCommand4.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand4.Connection = this.sqlConn;
            // 
            // frmMCentros
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 19);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(230)))), ((int)(((byte)(239)))));
            this.ClientSize = new System.Drawing.Size(826, 485);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btAceptar);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.pnlCentros);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMCentros";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Búsqueda de Centros";
            this.Activated += new System.EventHandler(this.frmMCentros_Activate);
            this.Load += new System.EventHandler(this.frmMCentros_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgCentros)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBuscar1)).EndInit();
            this.pnlCentros.ResumeLayout(false);
            this.pnlCentros.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion
		private void frmMCentros_Activate(object sender, System.EventArgs e)
		{
			if (ParamI_BloquearRed)this.cboRed.Enabled=false;//La red queda Fijada

		}
		private void frmMCentros_Load(object sender, System.EventArgs e)
		{
			try
			{
				Cursor.Current = Cursors.WaitCursor;
				GESTCRM.Utiles.Formatear_DataGrid(this,this.dgCentros,"C",true);

				Inicializa_cboRed();
				this.cboRed.SelectedValue= Clases.Configuracion.sIdRed ;
				if(Clases.Configuracion.iTodosCentros==0   ) this.cboRed.Enabled=false;//La red queda Fijada

				this.txbsIdCentro.Text = this.ParamIO_sIdCentro;
				this.txbsDescripcion.Text = this.ParamIO_sDescripcion;

				for(int i=0; i< this.dgCentros.TableStyles[0].GridColumnStyles.Count;i++)
				{
					DataGridTextBoxColumn TextCol0 = (DataGridTextBoxColumn)dgCentros.TableStyles[0].GridColumnStyles[i];
					TextCol0.TextBox.DoubleClick += new EventHandler(dgCentros_DoubleClick);
				}

				BuscarCentros();

				Cursor.Current = Cursors.Default;
			}			
			catch (Exception ex)
			{
				Mensajes.ShowError(ex.Message);
			}		
		}

		private void BuscarCentros()
		{
			try
			{
				this.Cursor = Cursors.WaitCursor;
				this.dsBuscar1.ListaBuscaCentros.Rows.Clear();

				this.sqldaListaBuscaCentros.SelectCommand.Parameters["@iIdDelegado"].Value=this.ParamI_iIdDelegado;
				this.sqldaListaBuscaCentros.SelectCommand.Parameters["@sIdCentro"].Value = this.txbsIdCentro.Text.ToString();
				this.sqldaListaBuscaCentros.SelectCommand.Parameters["@sDescripcion"].Value=this.txbsDescripcion.Text.ToString();

				this.sqldaListaBuscaCentros.SelectCommand.Parameters["@iIdPoblacion"].Value = (this.txbIdPoblacion.Text.ToString() == "")?null:txbIdPoblacion.Text;
				this.sqldaListaBuscaCentros.SelectCommand.Parameters["@sCodPostal"].Value=(this.txtCodPostal.Text.ToString() == "-1")?null:txtCodPostal.Text;
				this.sqldaListaBuscaCentros.SelectCommand.Parameters["@sPoblacion"].Value=(this.txbBPoblacion.Text.ToString() == "-1")?null:txbBPoblacion.Text;
				this.sqldaListaBuscaCentros.SelectCommand.Parameters["@sIdRed"].Value=this.cboRed.SelectedValue.ToString();
				//this.sqldaListaBuscaCentros.SelectCommand.Parameters["@iIdProvincia"].Value=(this.txbNomCentro.Text.ToString() == "")?null:txbNomCentro.Text;

				this.sqldaListaBuscaCentros.Fill(this.dsBuscar1);

				if (this.dsBuscar1.ListaBuscaCentros.Rows.Count>0)
				{
					this.dgCentros.CurrentCell = new DataGridCell(0,1);
					this.dgCentros.CurrentCell = new DataGridCell(0,0);
					this.lblNumReg.Text = this.dsBuscar1.ListaBuscaCentros.Rows.Count.ToString();
				}
				else
				{
					this.lblNumReg.Text = "0";
				}
				
				this.Cursor = Cursors.Default;
			}
			catch (Exception ex)
			{
				this.Cursor = Cursors.Default;
				Mensajes.ShowError(ex.Message);
			}

		}
		private void btBuscar_Click(object sender, System.EventArgs e)
		{
			BuscarCentros();
		}

		private void btAceptar_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (this.dsBuscar1.ListaBuscaCentros.Rows.Count <= 0)
				{
					this.ParamO_iIdCentro = 0; 
					this.ParamIO_sIdCentro = ""; 
					this.ParamIO_sDescripcion = ""; 
					this.ParamIO_sIdRed = "";
				}
				this.DialogResult=System.Windows.Forms.DialogResult.OK;
				this.Close();
			}
			catch (Exception ex)
			{
				Mensajes.ShowError(ex.Message);
			}
		}

		private void btCancelar_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.DialogResult=System.Windows.Forms.DialogResult.Cancel;
				this.Close();
			}
			catch (Exception ex)
			{
				Mensajes.ShowError(ex.Message);
			}
		}

		private void dgCentros_CurrentCellChanged(object sender, System.EventArgs e)
		{
			try 
			{
				Utiles.Seleccionar_UnaFilaDataGrid(this,this.dgCentros,this.dgCentros.CurrentRowIndex);
				this.ParamO_iIdCentro = int.Parse(this.dgCentros[this.dgCentros.CurrentRowIndex,2].ToString());
				this.ParamIO_sIdCentro = this.dgCentros[this.dgCentros.CurrentRowIndex,0].ToString();
				this.ParamIO_sDescripcion = this.dgCentros[this.dgCentros.CurrentRowIndex,1].ToString();
				this.ParamIO_sIdRed = this.dgCentros[this.dgCentros.CurrentRowIndex,4].ToString();
				ParamO_tRed = this.dgCentros[this.dgCentros.CurrentRowIndex,5].ToString();
			}
			catch (Exception ex)
			{
				Mensajes.ShowError(ex.Message);
			}
		}

//		private void TextBoxDoubleClickHandler(object sender, EventArgs e)
//		{
//			this.ParamO_iIdCentro = int.Parse(this.dgCentros[this.dgCentros.CurrentRowIndex,2].ToString());
//			this.ParamIO_sIdCentro = this.dgCentros[this.dgCentros.CurrentRowIndex,0].ToString();
//			this.ParamIO_sDescripcion = this.dgCentros[this.dgCentros.CurrentRowIndex,1].ToString();
//			this.DialogResult=System.Windows.Forms.DialogResult.OK;
//			this.Close();
//		}

		public void Buscar_sCentro()
		{
			try
			{
				this.dsBuscar1.ListaBuscaCentros.Rows.Clear();

				this.sqldaListaBuscaCentros.SelectCommand.Parameters["@iIdDelegado"].Value=this.ParamI_iIdDelegado;
				this.sqldaListaBuscaCentros.SelectCommand.Parameters["@sIdCentro"].Value = this.ParamIO_sIdCentro;
				this.sqldaListaBuscaCentros.SelectCommand.Parameters["@sDescripcion"].Value=this.ParamIO_sDescripcion;

				this.sqldaListaBuscaCentros.Fill(this.dsBuscar1);

				if(this.dsBuscar1.ListaBuscaCentros.Rows.Count>0)
				{
					this.ParamO_iIdCentro = int.Parse(this.dsBuscar1.ListaBuscaCentros.Rows[0]["iIdCentro"].ToString());
					this.ParamIO_sDescripcion= this.dsBuscar1.ListaBuscaCentros.Rows[0]["Nombre"].ToString();
                    //RH
                    this.ParamIO_sIdRed = String.Empty; // this.dgCentros[this.dgCentros.CurrentRowIndex, 4].ToString();
				}
				else
				{
					this.ParamIO_sIdCentro="";
					this.ParamIO_sDescripcion="";
					this.ParamO_iIdCentro=-1;
					this.ParamIO_sIdRed = "";
				}
				if(this.dsBuscar1.ListaBuscaCentros.Rows.Count > 0)
				{
					this.lblNumReg.Text = this.dsBuscar1.ListaBuscaCentros.Rows.Count.ToString();
				}
				else
				{
					this.lblNumReg.Text = "0";
				}
			}
			catch (Exception ex)
			{
				Mensajes.ShowError(ex.Message);
			}
		}

		private void dgCentros_DoubleClick(object sender, System.EventArgs e)
		{
			if (this.dsBuscar1.ListaBuscaCentros.Rows.Count>0)
			{
				try
				{
					this.ParamO_iIdCentro = int.Parse(this.dgCentros[this.dgCentros.CurrentRowIndex,2].ToString());
					this.ParamIO_sIdCentro = this.dgCentros[this.dgCentros.CurrentRowIndex,0].ToString();
					this.ParamIO_sDescripcion = this.dgCentros[this.dgCentros.CurrentRowIndex,1].ToString();
					this.ParamIO_sIdRed = this.dgCentros[this.dgCentros.CurrentRowIndex,4].ToString();

					this.DialogResult=System.Windows.Forms.DialogResult.OK;
					this.Close();		
				}
				catch (Exception ex)
				{
					Mensajes.ShowError(ex.Message);
				}
			}
		}

		#region BorraDatosBusqueda
		private void BorraDatosBusqueda()
		{
			this.dsBuscar1.ListaBuscaCentros.Rows.Clear();
			this.lblNumReg.Text = "";
		}
		private void txbsIdCentro_TextChanged(object sender, System.EventArgs e)
		{
			BorraDatosBusqueda();
		}

		private void txbsDescripcion_TextChanged(object sender, System.EventArgs e)
		{
			BorraDatosBusqueda();
		}

		private void txtCodPostal_TextChanged(object sender, System.EventArgs e)
		{
			BorraDatosBusqueda();
		}

		private void txbBPoblacion_TextChanged(object sender, System.EventArgs e)
		{
			BorraDatosBusqueda();
		}

		private void txtCodPostal_Leave(object sender, System.EventArgs e)
		{
			this.txbIdPoblacion.Text  = "";
		}

		private void txbBPoblacion_Leave(object sender, System.EventArgs e)
		{
			// Quita el iIdPoblacion cuando no hay descripcion de esta
			if(this.txbBPoblacion.Text == "")
			{
				this.txbIdPoblacion.Text  = "";
			}
		}
		#endregion

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
                    //this.sqlConn.Open();
                    if (sqlConn.State == ConnectionState.Closed)
                        this.sqlConn.Open();


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
		#region Inicializa_cboRed
		private void Inicializa_cboRed()
		{
			try
			{
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


	}
}
