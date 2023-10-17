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
	/// Descripción breve de frmMPoblaciones.
	/// </summary>
	public class frmMPoblaciones : System.Windows.Forms.Form
	{
		public int		ParamO_iIdPoblacion;
		public int		ParamO_iIdProvincia;
		public string	ParamO_sCodPostal;
		public string	ParamO_sProvincia;
		public string	ParamO_sPoblacion;
		public string   ParamO_sBrick;

        //private bool Cambio_CodPostal;
		private bool Cambio_Poblacion;
		private bool Cambio_Provincias;

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label lblProvincia;
		private System.Windows.Forms.Label lblCP;
		private System.Windows.Forms.Label lblPoblacion;
		private System.Windows.Forms.ComboBox cboProvincia;
		private System.Data.SqlClient.SqlConnection sqlConn;
		private System.Windows.Forms.ComboBox cboPoblacion;
		private System.Windows.Forms.DataGrid dgDatos;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		private GESTCRM.Formularios.Busquedas.dsBuscarPoblaciones dsBuscarPob;
		private System.Windows.Forms.ComboBox cboCodPostal;
		private System.Windows.Forms.Button btnAceptar;
		private System.Windows.Forms.Button btnCancelar;
	
		private System.ComponentModel.Container components = null;
		

		//Variables del usuario
		public Form frmOrigen;
		public static string VariableRet;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn5;
		private System.Data.SqlClient.SqlDataAdapter sqldaListaProvincias;
		private System.Data.SqlClient.SqlDataAdapter sqldaListaPoblaciones;
		private System.Data.DataView dvPob;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand2;
        private System.Data.SqlClient.SqlCommand sqlSelectCommand2CECL; //---- GSG CECL 19/05/2016
		private System.Windows.Forms.Button btBuscar;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label lblNumReg;
		private GESTCRM.Controles.LabelGradient labelGradient2;
		public string _ValorAceptar;

		public frmMPoblaciones()
		{
            InitializeComponent();

            //---- GSG (06/03/2021)
            Utiles.GetConfigConnection();
            this.sqlConn.ConnectionString = Utiles._connection.ConnectionString.ToString();

            
			
		}

		public frmMPoblaciones(Form FormularioOrigen, string VariableRetorno)
		{			
			InitializeComponent();
			
			frmOrigen = FormularioOrigen;
			VariableRet = VariableRetorno;

			//Inicializar();

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
            System.Configuration.AppSettingsReader configurationAppSettings = new System.Configuration.AppSettingsReader();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMPoblaciones));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btBuscar = new System.Windows.Forms.Button();
            this.cboCodPostal = new System.Windows.Forms.ComboBox();
            this.cboPoblacion = new System.Windows.Forms.ComboBox();
            this.cboProvincia = new System.Windows.Forms.ComboBox();
            this.dsBuscarPob = new GESTCRM.Formularios.Busquedas.dsBuscarPoblaciones();
            this.lblPoblacion = new System.Windows.Forms.Label();
            this.lblCP = new System.Windows.Forms.Label();
            this.lblProvincia = new System.Windows.Forms.Label();
            this.dgDatos = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn5 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.sqlConn = new System.Data.SqlClient.SqlConnection();
            this.sqldaListaProvincias = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.sqldaListaPoblaciones = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
            this.sqlSelectCommand2CECL = new System.Data.SqlClient.SqlCommand();
            this.dvPob = new System.Data.DataView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblNumReg = new System.Windows.Forms.Label();
            this.labelGradient2 = new GESTCRM.Controles.LabelGradient();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsBuscarPob)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgDatos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dvPob)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btBuscar);
            this.panel1.Controls.Add(this.cboCodPostal);
            this.panel1.Controls.Add(this.cboPoblacion);
            this.panel1.Controls.Add(this.cboProvincia);
            this.panel1.Controls.Add(this.lblPoblacion);
            this.panel1.Controls.Add(this.lblCP);
            this.panel1.Controls.Add(this.lblProvincia);
            this.panel1.Location = new System.Drawing.Point(5, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(579, 74);
            this.panel1.TabIndex = 0;
            // 
            // btBuscar
            // 
            this.btBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btBuscar.ForeColor = System.Drawing.Color.Black;
            this.btBuscar.Location = new System.Drawing.Point(497, 31);
            this.btBuscar.Name = "btBuscar";
            this.btBuscar.Size = new System.Drawing.Size(73, 35);
            this.btBuscar.TabIndex = 3;
            this.btBuscar.Text = "&Buscar";
            this.btBuscar.UseVisualStyleBackColor = true;
            this.btBuscar.Click += new System.EventHandler(this.btBuscar_Click);
            // 
            // cboCodPostal
            // 
            this.cboCodPostal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCodPostal.ItemHeight = 20;
            this.cboCodPostal.Location = new System.Drawing.Point(373, 5);
            this.cboCodPostal.Name = "cboCodPostal";
            this.cboCodPostal.Size = new System.Drawing.Size(100, 28);
            this.cboCodPostal.TabIndex = 1;
            this.cboCodPostal.SelectedIndexChanged += new System.EventHandler(this.cboCodPostal_SelectedIndexChanged);
            // 
            // cboPoblacion
            // 
            this.cboPoblacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPoblacion.Location = new System.Drawing.Point(87, 38);
            this.cboPoblacion.Name = "cboPoblacion";
            this.cboPoblacion.Size = new System.Drawing.Size(312, 28);
            this.cboPoblacion.TabIndex = 2;
            this.cboPoblacion.SelectedIndexChanged += new System.EventHandler(this.cboPoblacion_SelectedIndexChanged);
            // 
            // cboProvincia
            // 
            this.cboProvincia.DataSource = this.dsBuscarPob.ListaProvincias;
            this.cboProvincia.DisplayMember = "sProvincia";
            this.cboProvincia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboProvincia.Location = new System.Drawing.Point(89, 6);
            this.cboProvincia.Name = "cboProvincia";
            this.cboProvincia.Size = new System.Drawing.Size(226, 28);
            this.cboProvincia.TabIndex = 0;
            this.cboProvincia.ValueMember = "iIdProvincia";
            this.cboProvincia.SelectedIndexChanged += new System.EventHandler(this.cboProvincia_SelectedIndexChanged);
            // 
            // dsBuscarPob
            // 
            this.dsBuscarPob.DataSetName = "dsBuscarPoblaciones";
            this.dsBuscarPob.Locale = new System.Globalization.CultureInfo("es-ES");
            this.dsBuscarPob.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lblPoblacion
            // 
            this.lblPoblacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPoblacion.ForeColor = System.Drawing.Color.Black;
            this.lblPoblacion.Location = new System.Drawing.Point(6, 42);
            this.lblPoblacion.Name = "lblPoblacion";
            this.lblPoblacion.Size = new System.Drawing.Size(83, 20);
            this.lblPoblacion.TabIndex = 3;
            this.lblPoblacion.Text = "Población:";
            // 
            // lblCP
            // 
            this.lblCP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCP.ForeColor = System.Drawing.Color.Black;
            this.lblCP.Location = new System.Drawing.Point(327, 9);
            this.lblCP.Name = "lblCP";
            this.lblCP.Size = new System.Drawing.Size(47, 22);
            this.lblCP.TabIndex = 2;
            this.lblCP.Text = "C. P.:";
            // 
            // lblProvincia
            // 
            this.lblProvincia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProvincia.ForeColor = System.Drawing.Color.Black;
            this.lblProvincia.Location = new System.Drawing.Point(7, 9);
            this.lblProvincia.Name = "lblProvincia";
            this.lblProvincia.Size = new System.Drawing.Size(78, 24);
            this.lblProvincia.TabIndex = 1;
            this.lblProvincia.Text = "Provincia:";
            // 
            // dgDatos
            // 
            this.dgDatos.BackgroundColor = System.Drawing.Color.White;
            this.dgDatos.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.dgDatos.CaptionVisible = false;
            this.dgDatos.DataMember = "";
            this.dgDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgDatos.HeaderBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgDatos.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgDatos.Location = new System.Drawing.Point(0, 21);
            this.dgDatos.Name = "dgDatos";
            this.dgDatos.PreferredColumnWidth = 85;
            this.dgDatos.ReadOnly = true;
            this.dgDatos.RowHeaderWidth = 17;
            this.dgDatos.Size = new System.Drawing.Size(575, 362);
            this.dgDatos.TabIndex = 0;
            this.dgDatos.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            this.dgDatos.CurrentCellChanged += new System.EventHandler(this.dgDatos_CurrentCellChanged);
            this.dgDatos.DoubleClick += new System.EventHandler(this.dgDatos_DoubleClick);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.DataGrid = this.dgDatos;
            this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn1,
            this.dataGridTextBoxColumn5,
            this.dataGridTextBoxColumn3,
            this.dataGridTextBoxColumn2,
            this.dataGridTextBoxColumn4});
            this.dataGridTableStyle1.HeaderBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle1.RowHeaderWidth = 17;
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.MappingName = "iIdPoblacion";
            this.dataGridTextBoxColumn1.Width = 0;
            // 
            // dataGridTextBoxColumn5
            // 
            this.dataGridTextBoxColumn5.Format = "";
            this.dataGridTextBoxColumn5.FormatInfo = null;
            this.dataGridTextBoxColumn5.HeaderText = "Provincia";
            this.dataGridTextBoxColumn5.MappingName = "sProvincia";
            this.dataGridTextBoxColumn5.NullText = "";
            this.dataGridTextBoxColumn5.Width = 150;
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.HeaderText = "C. P.";
            this.dataGridTextBoxColumn3.MappingName = "CodPostal";
            this.dataGridTextBoxColumn3.NullText = "";
            this.dataGridTextBoxColumn3.Width = 70;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "Población";
            this.dataGridTextBoxColumn2.MappingName = "sPoblacion";
            this.dataGridTextBoxColumn2.NullText = "";
            this.dataGridTextBoxColumn2.Width = 300;
            // 
            // dataGridTextBoxColumn4
            // 
            this.dataGridTextBoxColumn4.Format = "";
            this.dataGridTextBoxColumn4.FormatInfo = null;
            this.dataGridTextBoxColumn4.MappingName = "iIdProvincia";
            this.dataGridTextBoxColumn4.Width = 0;
            // 
            // sqlConn
            // 
            this.sqlConn.ConnectionString = Utiles._connection.ConnectionString.ToString();   //---- GSG (06/03/2021)
            this.sqlConn.FireInfoMessageEventOnUserErrors = false;
            // 
            // sqldaListaProvincias
            // 
            this.sqldaListaProvincias.SelectCommand = this.sqlSelectCommand1;
            this.sqldaListaProvincias.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaProvincias", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iIdProvincia", "iIdProvincia"),
                        new System.Data.Common.DataColumnMapping("sProvincia", "sProvincia")})});
            // 
            // sqlSelectCommand1
            // 
            this.sqlSelectCommand1.CommandText = "[ListaProvincias]";
            this.sqlSelectCommand1.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand1.Connection = this.sqlConn;
            this.sqlSelectCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(10)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null)});
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.ForeColor = System.Drawing.Color.Black;
            this.btnAceptar.Location = new System.Drawing.Point(379, 482);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(82, 30);
            this.btnAceptar.TabIndex = 2;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.Black;
            this.btnCancelar.Location = new System.Drawing.Point(479, 482);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(82, 30);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // sqldaListaPoblaciones
            // 
            this.sqldaListaPoblaciones.SelectCommand = this.sqlSelectCommand2;
            this.sqldaListaPoblaciones.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaPoblaciones", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iIdPoblacion", "iIdPoblacion"),
                        new System.Data.Common.DataColumnMapping("Poblacion", "Poblacion"),
                        new System.Data.Common.DataColumnMapping("CodPostal", "CodPostal"),
                        new System.Data.Common.DataColumnMapping("iIdProvincia", "iIdProvincia"),
                        new System.Data.Common.DataColumnMapping("Provincia", "Provincia")})});
            // 
            // sqlSelectCommand2
            // 
            this.sqlSelectCommand2.CommandText = "[ListaPoblaciones]";
            this.sqlSelectCommand2.CommandTimeout = 60;
            this.sqlSelectCommand2.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand2.Connection = this.sqlConn;
            this.sqlSelectCommand2.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdProvincia", System.Data.SqlDbType.Int, 4)});
            // 
            // sqlSelectCommand2CECL
            // 
            this.sqlSelectCommand2CECL.CommandText = "[ListaPoblacionesCECL]";
            this.sqlSelectCommand2CECL.CommandTimeout = 60;
            this.sqlSelectCommand2CECL.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand2CECL.Connection = this.sqlConn;
            this.sqlSelectCommand2CECL.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdProvincia", System.Data.SqlDbType.Int, 4)});
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.lblNumReg);
            this.panel2.Controls.Add(this.labelGradient2);
            this.panel2.Controls.Add(this.dgDatos);
            this.panel2.Location = new System.Drawing.Point(5, 85);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(579, 387);
            this.panel2.TabIndex = 1;
            // 
            // lblNumReg
            // 
            this.lblNumReg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.lblNumReg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblNumReg.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumReg.ForeColor = System.Drawing.Color.Black;
            this.lblNumReg.Location = new System.Drawing.Point(497, 0);
            this.lblNumReg.Name = "lblNumReg";
            this.lblNumReg.Size = new System.Drawing.Size(79, 22);
            this.lblNumReg.TabIndex = 91;
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
            this.labelGradient2.Size = new System.Drawing.Size(575, 21);
            this.labelGradient2.TabIndex = 90;
            this.labelGradient2.Text = "Resultado de la Búsqueda";
            this.labelGradient2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmMPoblaciones
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(230)))), ((int)(((byte)(239)))));
            this.ClientSize = new System.Drawing.Size(588, 520);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMPoblaciones";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Búsqueda de Poblaciones";
            this.Load += new System.EventHandler(this.frmMPoblaciones_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dsBuscarPob)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgDatos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dvPob)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		#region Inicializar
		private void Inicializar()
		{
			this.Cursor = Cursors.WaitCursor;
			try
			{
				this.sqldaListaProvincias.Fill(this.dsBuscarPob);

                //---- GSG CECL 19/05/2016
                if (System.Configuration.ConfigurationManager.AppSettings["TipoDelegadoPedidosCentral"].ToString() == Comun.K_CECL)
                    sqldaListaPoblaciones.SelectCommand = sqlSelectCommand2CECL;
                else
                    sqldaListaPoblaciones.SelectCommand = sqlSelectCommand2;
                //---- FI GSG CECL

				this.sqldaListaPoblaciones.Fill(this.dsBuscarPob);
				
				dvPob = new DataView();
				dvPob.Table= this.dsBuscarPob.ListaPoblaciones;

				this.Cambio_Poblacion=false;

				DataGridTextBoxColumn TextCol1 = (DataGridTextBoxColumn)dgDatos.TableStyles[0].GridColumnStyles[1];
				TextCol1.TextBox.DoubleClick += new EventHandler(TextBoxDoubleClickHandler);

				DataGridTextBoxColumn TextCol2 = (DataGridTextBoxColumn)dgDatos.TableStyles[0].GridColumnStyles[2];
				TextCol2.TextBox.DoubleClick += new EventHandler(TextBoxDoubleClickHandler);

				DataGridTextBoxColumn TextCol3 = (DataGridTextBoxColumn)dgDatos.TableStyles[0].GridColumnStyles[3];
				TextCol3.TextBox.DoubleClick += new EventHandler(TextBoxDoubleClickHandler);

				Utiles.Formatear_DataGrid(this.dgDatos,"C",null);

				cboProvincia.SelectedValue = Clases.Configuracion.iIdProviciaDefectoDelegado;
				CambioProvincia();
				
				LanzarBusqueda();
			}
			catch(Exception ex)
			{
				Mensajes.ShowError(ex.Message);
			}
			finally
			{
				this.Cursor = Cursors.Default;
			}
		}
		#endregion

		#region cboProvincia_SelectedIndexChanged
		private void cboProvincia_SelectedIndexChanged(object sender, System.EventArgs e)
		{	
			CambioProvincia();
		}
		#endregion

		private void CambioProvincia()
		{
			try
			{
				this.Cambio_Provincias=true;
				ActualizaPoblaciones(cboProvincia.SelectedValue.ToString());
				this.Cambio_Provincias=false;
			}
			catch(Exception ex)
			{
				Mensajes.ShowError(ex.Message);
			}
		}
		
		#region cboPoblacion_SelectedIndexChanged
		private void cboPoblacion_SelectedIndexChanged(object sender, System.EventArgs e)
		{			
			try
			{
				this.Cambio_Poblacion=true;
				if(!this.Cambio_Provincias)
				{
					string IdProvincia = this.cboProvincia.SelectedValue.ToString();
					string sPoblacion = this.cboPoblacion.SelectedValue.ToString();
					string CodPostal = this.cboCodPostal.SelectedValue.ToString();

					DataTable dtCod = new DataTable();
					dtCod.Columns.Add("sCodPostal1");
					dtCod.Columns.Add("sCodPostal2");
					DataRow drCod0 = dtCod.NewRow();
					drCod0["sCodPostal1"]="-1";
					drCod0["sCodPostal2"]="";
					dtCod.Rows.Add(drCod0);

					for(int i=0;i<this.dvPob.Table.Rows.Count;i++)
					{
						if(this.dvPob.Table.Rows[i]["iIdProvincia"].ToString()==IdProvincia &&
							((sPoblacion=="-1")||(sPoblacion!="-1"&&this.dvPob.Table.Rows[i]["Poblacion"].ToString()==sPoblacion)))
						{
							if(-1==GESTCRM.Utiles.Buscar_fila_dtTabla(dtCod,"sCodPostal1",this.dvPob.Table.Rows[i]["CodPostal"].ToString()))
							{
								DataRow drCod = dtCod.NewRow();
								drCod["sCodPostal1"]=this.dvPob.Table.Rows[i]["CodPostal"];
								drCod["sCodPostal2"]=this.dvPob.Table.Rows[i]["CodPostal"];
								dtCod.Rows.Add(drCod);
							}
						}
					}
					this.cboCodPostal.DataSource=dtCod;
					this.cboCodPostal.DisplayMember = "sCodPostal2";
					this.cboCodPostal.ValueMember = "sCodPostal1";
					try{this.cboCodPostal.SelectedValue=CodPostal;}
					catch{}
				}
				this.Cambio_Poblacion=false;
			}
			catch(Exception ex)
			{
				Mensajes.ShowError(ex.Message);
			}
		}
		#endregion

		#region cboCodPostal_SelectedIndexChanged
		private void cboCodPostal_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				if(!this.Cambio_Provincias && !this.Cambio_Poblacion)
				{
					string IdProvincia = this.cboProvincia.SelectedValue.ToString();
					string sPoblacion = this.cboPoblacion.SelectedValue.ToString();
					string CodPostal = this.cboCodPostal.SelectedValue.ToString();

					DataTable dtPob = new DataTable();
					dtPob.Columns.Add("sPoblacion1");
					dtPob.Columns.Add("sPoblacion2");
					DataRow drPob0 = dtPob.NewRow();
					drPob0["sPoblacion1"]="-1";
					drPob0["sPoblacion2"]="";
					dtPob.Rows.Add(drPob0);

					for(int i=0;i<this.dvPob.Table.Rows.Count;i++)
					{
						if(this.dvPob.Table.Rows[i]["iIdProvincia"].ToString()==IdProvincia &&
							((CodPostal=="-1")||(CodPostal!="-1"&&this.dvPob.Table.Rows[i]["CodPostal"].ToString()==CodPostal)))
						{
							if(-1==GESTCRM.Utiles.Buscar_fila_dtTabla(dtPob,"sPoblacion1",this.dvPob.Table.Rows[i]["Poblacion"].ToString()))
							{
								DataRow drPob = dtPob.NewRow();
								drPob["sPoblacion1"]=this.dvPob.Table.Rows[i]["Poblacion"];
								drPob["sPoblacion2"]=this.dvPob.Table.Rows[i]["Poblacion"];
								dtPob.Rows.Add(drPob);
							}
						}
					}
					this.cboPoblacion.DataSource=dtPob;
					this.cboPoblacion.DisplayMember = "sPoblacion2";
					this.cboPoblacion.ValueMember = "sPoblacion1";

					try{this.cboPoblacion.SelectedValue=sPoblacion;}
					catch(Exception ex)
					{
						Mensajes.ShowError(ex.Message);
					}
				}
			}
			catch(Exception ex)
			{
				Mensajes.ShowError(ex.Message);
			}
		}
		#endregion

		#region ActualizaPoblaciones
		private void ActualizaPoblaciones(string IdProvincia)
		{
			try
			{
				DataTable dtPob = new DataTable();
				dtPob.Columns.Add("sPoblacion1");
				dtPob.Columns.Add("sPoblacion2");
				DataRow drPob0 = dtPob.NewRow();
				drPob0["sPoblacion1"]="-1";
				drPob0["sPoblacion2"]="";
				dtPob.Rows.Add(drPob0);

				DataTable dtCod = new DataTable();
				dtCod.Columns.Add("sCodPostal1");
				dtCod.Columns.Add("sCodPostal2");
				DataRow drCod0 = dtCod.NewRow();
				drCod0["sCodPostal1"]="-1";
				drCod0["sCodPostal2"]="";
				dtCod.Rows.Add(drCod0);

				for(int i=0;i<this.dvPob.Table.Rows.Count;i++)
				{
					if(this.dvPob.Table.Rows[i]["iIdProvincia"].ToString()==IdProvincia)
					{
						if(-1==GESTCRM.Utiles.Buscar_fila_dtTabla(dtPob,"sPoblacion1",this.dvPob.Table.Rows[i]["Poblacion"].ToString()))
						{
							DataRow drPob = dtPob.NewRow();
							drPob["sPoblacion1"]=this.dvPob.Table.Rows[i]["Poblacion"];
							drPob["sPoblacion2"]=this.dvPob.Table.Rows[i]["Poblacion"];
							dtPob.Rows.Add(drPob);
						}

						if(-1==GESTCRM.Utiles.Buscar_fila_dtTabla(dtCod,"sCodPostal1",this.dvPob.Table.Rows[i]["CodPostal"].ToString()))
						{
							DataRow drCod = dtCod.NewRow();
							drCod["sCodPostal1"]=this.dvPob.Table.Rows[i]["CodPostal"];
							drCod["sCodPostal2"]=this.dvPob.Table.Rows[i]["CodPostal"];
							dtCod.Rows.Add(drCod);
						}

					}
				}
				this.cboPoblacion.DataSource=dtPob;
				this.cboPoblacion.DisplayMember = "sPoblacion2";
				this.cboPoblacion.ValueMember = "sPoblacion1";

				this.cboCodPostal.DataSource=dtCod;
				this.cboCodPostal.DisplayMember = "sCodPostal2";
				this.cboCodPostal.ValueMember = "sCodPostal1";
			}
			catch 
			{
				Mensajes.ShowError(1005);
			}
		}
		#endregion

		#region btnAceptar_Click
		private void btnAceptar_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(this.dgDatos.CurrentRowIndex==-1)
				{
					this._ValorAceptar = null;

					this.ParamO_iIdPoblacion = 0;
					this.ParamO_iIdProvincia = 0;
					this.ParamO_sCodPostal = "";
					this.ParamO_sProvincia = "";
					this.ParamO_sPoblacion = "";
					this.ParamO_sBrick ="";
					this.DialogResult=System.Windows.Forms.DialogResult.OK;
					this.Close();
				}
				else
				{
					Aceptar_Valor();
				}
			}
			catch(Exception ex)
			{
				Mensajes.ShowError(ex.Message);
			}
		}
		#endregion

		#region btnCancelar_Click
		private void btnCancelar_Click(object sender, System.EventArgs e)
		{
			try 
			{
				this.DialogResult=System.Windows.Forms.DialogResult.Cancel;
				this.Close();
			}
			catch(Exception ex)
			{
				Mensajes.ShowError(ex.Message);
			}
		}
		#endregion

		#region TextBoxDoubleClickHandler
		private void TextBoxDoubleClickHandler(object sender, EventArgs e)
		{
			try 
			{
				Aceptar_Valor();
			}
			catch(Exception ex)
			{
				Mensajes.ShowError(ex.Message);
			}
		}
		#endregion

		// Retorna el valor seleccionado al formulario que lo ha llamado.
		#region Aceptar_Valor
		private void Aceptar_Valor()
		{
			try
			{
				if(this.dgDatos.CurrentRowIndex==-1)return;
				string ValorSeleccionado="";
				int linea = this.dgDatos.CurrentCell.RowNumber;
				ValorSeleccionado=this.dgDatos[linea,3].ToString();//sPoblación
				ValorSeleccionado+="/"+this.dgDatos[linea,2].ToString();//CodPostal
				ValorSeleccionado+="/"+this.dgDatos[linea,1].ToString();//sProvincia				
				//ValorSeleccionado+="/"+this.dgDatos[linea,5].ToString();//sIdBrick				
				//Valor de Retorno.
				this._ValorAceptar = ValorSeleccionado;

				this.ParamO_iIdPoblacion = int.Parse(this.dgDatos[linea,0].ToString());
				this.ParamO_iIdProvincia = int.Parse(this.dgDatos[linea,4].ToString());
				this.ParamO_sCodPostal = this.dgDatos[linea,2].ToString();
				this.ParamO_sProvincia = this.dgDatos[linea,1].ToString();
				this.ParamO_sPoblacion = this.dgDatos[linea,3].ToString();
				//this.ParamO_sBrick	= this.dgDatos[linea,5].ToString();			
				this.DialogResult=System.Windows.Forms.DialogResult.OK;
				this.Close();
			}
			catch 
			{
				Mensajes.ShowError(1005);
			}
		}
		#endregion

		public string ValorAceptar
		{
			get
			{
				return this._ValorAceptar;
			}
		}
		
//		#region KeyPresses del Formulario
//		private void dgDatos_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
//		{
//			try
//			{
//				if (e.KeyChar == 13)
//				{
//					Aceptar_Valor();
//				}
//			}
//			catch 
//			{
//				Mensajes.ShowError(1005);
//			}
//		}
//
//		private void cboProvincia_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
//		{
//			try
//			{
//				if (e.KeyChar == 13)
//				{
//					Aceptar_Valor();
//				}
//			}
//			catch 
//			{
//				Mensajes.ShowError(1005);
//			}
//		}
//
//		private void cboPoblacion_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
//		{
//			try
//			{
//				if (e.KeyChar == 13)
//				{
//					Aceptar_Valor();
//				}
//			}
//			catch 
//			{
//				Mensajes.ShowError(1005);
//			}
//		}
//
//		private void cboCodPostal_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
//		{
//			try
//			{
//				if (e.KeyChar == 13)
//				{
//					Aceptar_Valor();
//				}
//			}
//			catch 
//			{
//				Mensajes.ShowError(1005);
//			}
//		}
//		#endregion
//
		#region dgDatos_DoubleClick
		private void dgDatos_DoubleClick(object sender, System.EventArgs e)
		{
			if(this.dsBuscarPob.ListaPoblaciones.Rows.Count > 0)
			{
				try
				{
					Aceptar_Valor();
				}
				catch(Exception ex)
				{
					Mensajes.ShowError(ex.Message);
				}
			}
		}
		#endregion

		#region btBuscar_Click
		private void btBuscar_Click(object sender, System.EventArgs e)
		{
			LanzarBusqueda();
		}
		#endregion

		private void LanzarBusqueda()
		{
			this.Cursor = Cursors.WaitCursor;
			try
			{
				string IdProvincia="0";
				string sProvincia = "-1";
				string sPoblacion="-1";
				string CodPostal="-1";
				
				try	{IdProvincia = this.cboProvincia.SelectedValue.ToString();}
				catch
				{
					try{if(this.cboProvincia.Text.ToString().Length>0) sProvincia = this.cboProvincia.Text.ToString();}
					catch{}
				}
				try {sPoblacion = this.cboPoblacion.SelectedValue.ToString();}
				catch
				{
					try{if(this.cboPoblacion.Text.ToString().Length>0) sPoblacion = this.cboPoblacion.Text.ToString();}
					catch{}
				}
				try{CodPostal = this.cboCodPostal.SelectedValue.ToString();}
				catch
				{
					try{if(this.cboCodPostal.Text.ToString().Length>0) CodPostal= this.cboCodPostal.Text.ToString();}
					catch{}
				}

				DataTable dtBusca = new DataTable();
				dtBusca.Columns.Add("iIdPoblacion");
				dtBusca.Columns.Add("sPoblacion");
				dtBusca.Columns.Add("CodPostal");
				dtBusca.Columns.Add("iIdProvincia");
				dtBusca.Columns.Add("sProvincia");
				//dtBusca.Columns.Add("sIdBrick");
				
				int ContaResult=0;
				
				for(int i=0;i<this.dvPob.Table.Rows.Count;i++)
				{
					if(((IdProvincia=="0")||(IdProvincia!="0"&& this.dvPob.Table.Rows[i]["iIdProvincia"].ToString()==IdProvincia)) &&
						((sProvincia=="-1")||(sProvincia!="-1"&& this.dvPob.Table.Rows[i]["Provincia"].ToString()==sProvincia)) &&
						((sPoblacion=="-1")||(sPoblacion!="-1"&& this.dvPob.Table.Rows[i]["Poblacion"].ToString()==sPoblacion)) &&
						((CodPostal=="-1")||(CodPostal!="-1" && this.dvPob.Table.Rows[i]["CodPostal"].ToString()==CodPostal)))				  
					{
						DataRow drBusca = dtBusca.NewRow();
						drBusca["iIdPoblacion"]=this.dvPob.Table.Rows[i]["iIdPoblacion"];
						drBusca["sPoblacion"]=this.dvPob.Table.Rows[i]["Poblacion"];
						drBusca["CodPostal"]=this.dvPob.Table.Rows[i]["CodPostal"];
						drBusca["sProvincia"]=this.dvPob.Table.Rows[i]["Provincia"];
						drBusca["iIdProvincia"]=this.dvPob.Table.Rows[i]["iIdProvincia"];
						//drBusca["sIdBrick"]=this.dvPob.Table.Rows[i]["Brick"];
						dtBusca.Rows.Add(drBusca);
						ContaResult++;
					}
				}
				//			this.dgDatos.TableStyles[0].MappingName = "dtBusca";
				this.dgDatos.DataSource=dtBusca;
				this.dgDatos.CurrentCell = new DataGridCell(0,1);
				this.dgDatos.CurrentCell = new DataGridCell(0,0);
				this.lblNumReg.Text = ContaResult.ToString();
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
			this.Cursor = Cursors.Default;
		}

		#region dgDatos_CurrentCellChanged
		private void dgDatos_CurrentCellChanged(object sender, System.EventArgs e)
		{
			Utiles.Seleccionar_UnaFilaDataGrid(this,this.dgDatos,this.dgDatos.CurrentRowIndex);
		}
		#endregion

		private void frmMPoblaciones_Load(object sender, System.EventArgs e)
		{
			Cursor = Cursors.WaitCursor;
			Inicializar();
			Cursor = Cursors.Default;
		}

		
	}
}
