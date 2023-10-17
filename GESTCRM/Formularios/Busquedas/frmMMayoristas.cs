using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace GESTCRM.Formularios.Busquedas
{
	/// <summary>
	/// Descripción breve de frmMMateriales.
	/// </summary>
	public class frmMMayoristas : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btBuscar;
		private System.Windows.Forms.Button btCancelar;
		private System.Windows.Forms.Button btAceptar;
		private System.Windows.Forms.Panel pnlAccion;
		private System.Windows.Forms.Panel pnBusqueda;
		private GESTCRM.Controles.LabelGradient labelGradient2;
		private System.Windows.Forms.Label lblNumReg;
		private System.Data.SqlClient.SqlConnection sqlConn;
		private GESTCRM.Formularios.Busquedas.dsBuscar dsBuscar1;
		private System.Windows.Forms.Label lblsNombre;
		private System.Windows.Forms.TextBox txtsIdCliente;
		private System.Windows.Forms.Label lblsIdCliente;
		private System.Data.SqlClient.SqlDataAdapter sqldaListaMayoristas;
		private System.Windows.Forms.DataGrid dgMayoristas;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn iIdClienteMayorista;
		private System.Windows.Forms.DataGridTextBoxColumn sIdCliente;
		private System.Windows.Forms.DataGridTextBoxColumn sNombre;
		/// <summary>
		/// Variable del diseñador requerida.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.TextBox txtsNombre;

		int ParamI_iIdDestinatario;
		int ParamI_TipoInterlocutor;
		string ParamI_sIdDestinatario;
		string ParamI_sNombreDestinatario;

		string vDestinatario = "";

		public int ParamO_iIdClienteMayorista;
		public string ParamO_sIdMayorista;
		private System.Data.SqlClient.SqlDataAdapter sqldaDevuelveMayorista;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
        private System.Data.SqlClient.SqlCommand sqlSelectCommand1CECL; //---- GSG CECL 19/05/2016
        private CheckBox chkTodos;
		public string ParamO_sNombreMayorista;

		public frmMMayoristas(int iIdDestinatario, string sIdDestinatario, string sNombreDestinatario,int TipoInterlocutor)
		{
            InitializeComponent();

            //---- GSG (06/03/2021)
            Utiles.GetConfigConnection();
            this.sqlConn.ConnectionString = Utiles._connection.ConnectionString.ToString();

            Cursor.Current = Cursors.WaitCursor;
			
			this.ParamI_iIdDestinatario = iIdDestinatario;
			this.ParamI_sIdDestinatario = sIdDestinatario;
			this.ParamI_sNombreDestinatario = sNombreDestinatario;
			this.ParamI_TipoInterlocutor = TipoInterlocutor;
			IniPantalla();
			Cursor.Current = Cursors.Default;
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
            System.Configuration.AppSettingsReader configurationAppSettings = new System.Configuration.AppSettingsReader();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMMayoristas));
            this.pnlAccion = new System.Windows.Forms.Panel();
            this.chkTodos = new System.Windows.Forms.CheckBox();
            this.txtsNombre = new System.Windows.Forms.TextBox();
            this.lblsNombre = new System.Windows.Forms.Label();
            this.txtsIdCliente = new System.Windows.Forms.TextBox();
            this.btBuscar = new System.Windows.Forms.Button();
            this.lblsIdCliente = new System.Windows.Forms.Label();
            this.btCancelar = new System.Windows.Forms.Button();
            this.btAceptar = new System.Windows.Forms.Button();
            this.sqldaListaMayoristas = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlConn = new System.Data.SqlClient.SqlConnection();
            this.sqlSelectCommand1CECL = new System.Data.SqlClient.SqlCommand();
            this.pnBusqueda = new System.Windows.Forms.Panel();
            this.lblNumReg = new System.Windows.Forms.Label();
            this.labelGradient2 = new GESTCRM.Controles.LabelGradient();
            this.dgMayoristas = new System.Windows.Forms.DataGrid();
            this.dsBuscar1 = new GESTCRM.Formularios.Busquedas.dsBuscar();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.iIdClienteMayorista = new System.Windows.Forms.DataGridTextBoxColumn();
            this.sIdCliente = new System.Windows.Forms.DataGridTextBoxColumn();
            this.sNombre = new System.Windows.Forms.DataGridTextBoxColumn();
            this.sqldaDevuelveMayorista = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
            this.pnlAccion.SuspendLayout();
            this.pnBusqueda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgMayoristas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBuscar1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlAccion
            // 
            this.pnlAccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAccion.Controls.Add(this.chkTodos);
            this.pnlAccion.Controls.Add(this.txtsNombre);
            this.pnlAccion.Controls.Add(this.lblsNombre);
            this.pnlAccion.Controls.Add(this.txtsIdCliente);
            this.pnlAccion.Controls.Add(this.btBuscar);
            this.pnlAccion.Controls.Add(this.lblsIdCliente);
            this.pnlAccion.Location = new System.Drawing.Point(5, 8);
            this.pnlAccion.Name = "pnlAccion";
            this.pnlAccion.Size = new System.Drawing.Size(564, 64);
            this.pnlAccion.TabIndex = 0;
            // 
            // chkTodos
            // 
            this.chkTodos.AutoSize = true;
            this.chkTodos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTodos.Location = new System.Drawing.Point(223, 6);
            this.chkTodos.Name = "chkTodos";
            this.chkTodos.Size = new System.Drawing.Size(258, 24);
            this.chkTodos.TabIndex = 109;
            this.chkTodos.Text = "Mostrar todos los mayoristas";
            this.chkTodos.UseVisualStyleBackColor = true;
            // 
            // txtsNombre
            // 
            this.txtsNombre.Location = new System.Drawing.Point(81, 32);
            this.txtsNombre.MaxLength = 50;
            this.txtsNombre.Name = "txtsNombre";
            this.txtsNombre.Size = new System.Drawing.Size(340, 26);
            this.txtsNombre.TabIndex = 1;
            this.txtsNombre.TextChanged += new System.EventHandler(this.txtsNombre_TextChanged);
            // 
            // lblsNombre
            // 
            this.lblsNombre.AutoSize = true;
            this.lblsNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsNombre.Location = new System.Drawing.Point(12, 34);
            this.lblsNombre.Name = "lblsNombre";
            this.lblsNombre.Size = new System.Drawing.Size(69, 20);
            this.lblsNombre.TabIndex = 86;
            this.lblsNombre.Text = "Nombre:";
            // 
            // txtsIdCliente
            // 
            this.txtsIdCliente.Location = new System.Drawing.Point(80, 6);
            this.txtsIdCliente.MaxLength = 20;
            this.txtsIdCliente.Name = "txtsIdCliente";
            this.txtsIdCliente.Size = new System.Drawing.Size(121, 26);
            this.txtsIdCliente.TabIndex = 0;
            this.txtsIdCliente.TextChanged += new System.EventHandler(this.txtsIdCliente_TextChanged);
            // 
            // btBuscar
            // 
            this.btBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btBuscar.Location = new System.Drawing.Point(483, 29);
            this.btBuscar.Name = "btBuscar";
            this.btBuscar.Size = new System.Drawing.Size(69, 29);
            this.btBuscar.TabIndex = 2;
            this.btBuscar.Text = "&Buscar";
            this.btBuscar.UseVisualStyleBackColor = true;
            this.btBuscar.Click += new System.EventHandler(this.btBuscar_Click);
            // 
            // lblsIdCliente
            // 
            this.lblsIdCliente.AutoSize = true;
            this.lblsIdCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsIdCliente.Location = new System.Drawing.Point(12, 8);
            this.lblsIdCliente.Name = "lblsIdCliente";
            this.lblsIdCliente.Size = new System.Drawing.Size(63, 20);
            this.lblsIdCliente.TabIndex = 1;
            this.lblsIdCliente.Text = "Código:";
            // 
            // btCancelar
            // 
            this.btCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btCancelar.Location = new System.Drawing.Point(439, 490);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(82, 31);
            this.btCancelar.TabIndex = 3;
            this.btCancelar.Text = "&Cancelar";
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // btAceptar
            // 
            this.btAceptar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btAceptar.Location = new System.Drawing.Point(335, 490);
            this.btAceptar.Name = "btAceptar";
            this.btAceptar.Size = new System.Drawing.Size(82, 31);
            this.btAceptar.TabIndex = 2;
            this.btAceptar.Text = "&Aceptar";
            this.btAceptar.UseVisualStyleBackColor = true;
            this.btAceptar.Click += new System.EventHandler(this.btAceptar_Click);
            // 
            // sqldaListaMayoristas
            // 
            this.sqldaListaMayoristas.SelectCommand = this.sqlSelectCommand1;
            this.sqldaListaMayoristas.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaBuscaMayoristas", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iIdClienteMayorista", "iIdClienteMayorista"),
                        new System.Data.Common.DataColumnMapping("sIdCliente", "sIdCliente"),
                        new System.Data.Common.DataColumnMapping("sNombre", "sNombre")}),
            new System.Data.Common.DataTableMapping("Table1", "Table1", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iIdClienteMayorista", "iIdClienteMayorista"),
                        new System.Data.Common.DataColumnMapping("sIdCliente", "sIdCliente"),
                        new System.Data.Common.DataColumnMapping("sNombre", "sNombre")})});
            // 
            // sqlSelectCommand1
            // 
            this.sqlSelectCommand1.CommandText = "[ListaBuscaMayoristas]";
            this.sqlSelectCommand1.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand1.Connection = this.sqlConn;
            this.sqlSelectCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdDestinatario", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sIdCliente", System.Data.SqlDbType.VarChar, 20),
            new System.Data.SqlClient.SqlParameter("@sNombre", System.Data.SqlDbType.VarChar, 50),
            new System.Data.SqlClient.SqlParameter("@Interlocutor", System.Data.SqlDbType.Int, 4)});
            // 
            // sqlConn
            // 
            this.sqlConn.ConnectionString = Utiles._connection.ConnectionString.ToString();   //---- GSG (06/03/2021)
            this.sqlConn.FireInfoMessageEventOnUserErrors = false;
            // 
            // sqlSelectCommand1CECL
            // 
            this.sqlSelectCommand1CECL.CommandText = "[ListaBuscaMayoristasCECL]";
            this.sqlSelectCommand1CECL.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand1CECL.Connection = this.sqlConn;
            this.sqlSelectCommand1CECL.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdDestinatario", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sIdCliente", System.Data.SqlDbType.VarChar, 20),
            new System.Data.SqlClient.SqlParameter("@sNombre", System.Data.SqlDbType.VarChar, 50),
            new System.Data.SqlClient.SqlParameter("@Interlocutor", System.Data.SqlDbType.Int, 4)});
            // 
            // pnBusqueda
            // 
            this.pnBusqueda.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnBusqueda.Controls.Add(this.lblNumReg);
            this.pnBusqueda.Controls.Add(this.labelGradient2);
            this.pnBusqueda.Controls.Add(this.dgMayoristas);
            this.pnBusqueda.Location = new System.Drawing.Point(3, 80);
            this.pnBusqueda.Name = "pnBusqueda";
            this.pnBusqueda.Size = new System.Drawing.Size(566, 400);
            this.pnBusqueda.TabIndex = 1;
            // 
            // lblNumReg
            // 
            this.lblNumReg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.lblNumReg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblNumReg.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumReg.ForeColor = System.Drawing.Color.Black;
            this.lblNumReg.Location = new System.Drawing.Point(495, -1);
            this.lblNumReg.Name = "lblNumReg";
            this.lblNumReg.Size = new System.Drawing.Size(67, 24);
            this.lblNumReg.TabIndex = 85;
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
            this.labelGradient2.Size = new System.Drawing.Size(562, 22);
            this.labelGradient2.TabIndex = 84;
            this.labelGradient2.Text = "Resultado de la Búsqueda";
            this.labelGradient2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgMayoristas
            // 
            this.dgMayoristas.BackgroundColor = System.Drawing.Color.White;
            this.dgMayoristas.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.dgMayoristas.CaptionVisible = false;
            this.dgMayoristas.DataMember = "ListaBuscaMayoristas";
            this.dgMayoristas.DataSource = this.dsBuscar1;
            this.dgMayoristas.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgMayoristas.Location = new System.Drawing.Point(0, 22);
            this.dgMayoristas.Name = "dgMayoristas";
            this.dgMayoristas.ReadOnly = true;
            this.dgMayoristas.RowHeaderWidth = 17;
            this.dgMayoristas.Size = new System.Drawing.Size(562, 374);
            this.dgMayoristas.TabIndex = 0;
            this.dgMayoristas.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            this.dgMayoristas.CurrentCellChanged += new System.EventHandler(this.dgMayoristas_CurrentCellChanged);
            this.dgMayoristas.DoubleClick += new System.EventHandler(this.dgMayoristas_DoubleClick);
            // 
            // dsBuscar1
            // 
            this.dsBuscar1.DataSetName = "dsBuscar";
            this.dsBuscar1.Locale = new System.Globalization.CultureInfo("es-ES");
            this.dsBuscar1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.DataGrid = this.dgMayoristas;
            this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.iIdClienteMayorista,
            this.sIdCliente,
            this.sNombre});
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle1.MappingName = "ListaBuscaMayoristas";
            this.dataGridTableStyle1.RowHeaderWidth = 17;
            // 
            // iIdClienteMayorista
            // 
            this.iIdClienteMayorista.Format = "";
            this.iIdClienteMayorista.FormatInfo = null;
            this.iIdClienteMayorista.HeaderText = "iId";
            this.iIdClienteMayorista.MappingName = "iIdClienteMayorista";
            this.iIdClienteMayorista.Width = 0;
            // 
            // sIdCliente
            // 
            this.sIdCliente.Format = "";
            this.sIdCliente.FormatInfo = null;
            this.sIdCliente.HeaderText = "Mayorista";
            this.sIdCliente.MappingName = "sIdCliente";
            this.sIdCliente.Width = 150;
            // 
            // sNombre
            // 
            this.sNombre.Format = "";
            this.sNombre.FormatInfo = null;
            this.sNombre.HeaderText = "Nombre";
            this.sNombre.MappingName = "sNombre";
            this.sNombre.Width = 360;
            // 
            // sqldaDevuelveMayorista
            // 
            this.sqldaDevuelveMayorista.SelectCommand = this.sqlSelectCommand2;
            this.sqldaDevuelveMayorista.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaDevuelveMayoristas", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iIdClienteMayorista", "iIdClienteMayorista"),
                        new System.Data.Common.DataColumnMapping("sIdCliente", "sIdCliente"),
                        new System.Data.Common.DataColumnMapping("sNombre", "sNombre")})});
            // 
            // sqlSelectCommand2
            // 
            this.sqlSelectCommand2.CommandText = "[ListaDevuelveMayoristas]";
            this.sqlSelectCommand2.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand2.Connection = this.sqlConn;
            this.sqlSelectCommand2.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@sIdMayorista", System.Data.SqlDbType.VarChar, 20),
            new System.Data.SqlClient.SqlParameter("@Interlocutor", System.Data.SqlDbType.Int, 4)});
            // 
            // frmMMayoristas
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 19);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(230)))), ((int)(((byte)(239)))));
            this.ClientSize = new System.Drawing.Size(574, 533);
            this.Controls.Add(this.pnBusqueda);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.btAceptar);
            this.Controls.Add(this.pnlAccion);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMMayoristas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Búsqueda de Mayoristas";
            this.Load += new System.EventHandler(this.frmMMayoristas_Load);
            this.pnlAccion.ResumeLayout(false);
            this.pnlAccion.PerformLayout();
            this.pnBusqueda.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgMayoristas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBuscar1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region IniPantalla
		private void IniPantalla()
		{
			Utiles.Formatear_DataGrid(this,this.dgMayoristas,"C",true);
			this.txtsIdCliente.Text ="";
			this.txtsNombre.Text = "";

			if(ParamI_sIdDestinatario != "")
			{
				vDestinatario = "[" + ParamI_sIdDestinatario.ToString() + "] ";
			}
			if(ParamI_sNombreDestinatario !="")
			{
				vDestinatario +=  ParamI_sNombreDestinatario.ToString();
			}
			if(this.ParamI_TipoInterlocutor==0)
			{
				this.dgMayoristas.TableStyles[0].GridColumnStyles[1].HeaderText="Mayoristas";
				if(vDestinatario != "") this.Text = "Mayoristas del Cliente " + vDestinatario.ToString();
				else this.Text = "Búsqueda de Mayoristas";
			}
			else if(this.ParamI_TipoInterlocutor==1)
			{
				this.dgMayoristas.TableStyles[0].GridColumnStyles[1].HeaderText="Pagadores";
				if(vDestinatario != "") this.Text = "Pagadores del Cliente " + vDestinatario.ToString();
				else this.Text = "Búsqueda de Pagadores";
			}
			else
			{
				this.dgMayoristas.TableStyles[0].GridColumnStyles[1].HeaderText="Interlocutores";
				if(vDestinatario != "") this.Text = "Interlocutores del Cliente " + vDestinatario.ToString();
				else this.Text = "Búsqueda de Interlocutores";
			}

            //---- GSG (29/08/2011)
            if (this.ParamI_TipoInterlocutor == 1)
                chkTodos.Visible = false;
            else
                chkTodos.Visible = true;
            //---- FI GSG

			Inicializa_Grid();
			//BuscarMayorista();
		}
		#endregion

		#region dgMayoristas_DoubleClick
		private void dgMayoristas_DoubleClick(object sender, System.EventArgs e)
		{
			if(this.dsBuscar1.ListaBuscaMayoristas.Rows.Count > 0)
			{
				try
				{
					if(this.dgMayoristas.CurrentRowIndex==-1)return;
					this.ParamO_iIdClienteMayorista = int.Parse(this.dgMayoristas[this.dgMayoristas.CurrentRowIndex,0].ToString());
					this.ParamO_sIdMayorista = this.dgMayoristas[this.dgMayoristas.CurrentRowIndex,1].ToString();
					this.ParamO_sNombreMayorista = this.dgMayoristas[this.dgMayoristas.CurrentRowIndex,2].ToString();
					this.DialogResult=System.Windows.Forms.DialogResult.OK;
					this.Close();
				}
				catch (Exception ex)
				{
					Mensajes.ShowError(ex.Message);
				}
			}
		}
		#endregion

		#region Inicializa_Grid
		private void Inicializa_Grid()
		{
			try
			{
				for(int i=0;i<this.dgMayoristas.TableStyles[0].GridColumnStyles.Count;i++)
				{
					DataGridTextBoxColumn TextCol1 = (DataGridTextBoxColumn)this.dgMayoristas.TableStyles[0].GridColumnStyles[i];
					TextCol1.TextBox.DoubleClick += new EventHandler(dgMayoristas_DoubleClick);
				}
			}
			catch (Exception ex)
			{
				Mensajes.ShowError(ex.Message);
			}		
		}
		#endregion

		#region btBuscar_Click
		private void btBuscar_Click(object sender, System.EventArgs e)
		{
			BuscarMayorista();
		}
		#endregion

		public void DevuelveMayorista(string sIdMayorista)
		{
			this.Cursor = Cursors.WaitCursor;
			this.dsBuscar1.ListaDevuelveMayoristas.Rows.Clear();
			this.sqldaDevuelveMayorista.SelectCommand.Parameters["@sIdMayorista"].Value = (sIdMayorista.ToString() == "")?null:sIdMayorista.ToString();
			this.sqldaDevuelveMayorista.SelectCommand.Parameters["@Interlocutor"].Value = this.ParamI_TipoInterlocutor;
			this.sqldaDevuelveMayorista.Fill(this.dsBuscar1.ListaDevuelveMayoristas);
			if (this.dsBuscar1.ListaDevuelveMayoristas.Rows.Count == 1)
			{
				this.ParamO_iIdClienteMayorista = int.Parse(this.dsBuscar1.ListaDevuelveMayoristas.Rows[0]["iIdClienteMayorista"].ToString());
				this.ParamO_sNombreMayorista = this.dsBuscar1.ListaDevuelveMayoristas.Rows[0]["sNombre"].ToString();
				this.ParamO_sIdMayorista = this.dsBuscar1.ListaDevuelveMayoristas.Rows[0]["sIdCliente"].ToString();
			}
			else
			{
				this.ParamO_iIdClienteMayorista = -1;
				this.ParamO_sNombreMayorista = "";
			}
			this.Cursor = Cursors.Default;
			
		}

		#region BuscarMayorista
		private void BuscarMayorista()
		{
			try
			{
				this.Cursor = Cursors.WaitCursor;
				this.dsBuscar1.ListaBuscaMayoristas.Rows.Clear();

                //---- GSG CECL 19/05/2016
                if (System.Configuration.ConfigurationManager.AppSettings["TipoDelegadoPedidosCentral"].ToString() == Comun.K_CECL)
                    sqldaListaMayoristas.SelectCommand = sqlSelectCommand1CECL;
                else
                    sqldaListaMayoristas.SelectCommand = sqlSelectCommand1;
                //---- FI GSG CECL


                //---- GSG (29/08/2011)
                //this.sqldaListaMayoristas.SelectCommand.Parameters["@iIdDestinatario"].Value = (this.ParamI_iIdDestinatario.ToString() == "-1") ? null : ParamI_iIdDestinatario.ToString();
                if (chkTodos.Checked)
                    this.sqldaListaMayoristas.SelectCommand.Parameters["@iIdDestinatario"].Value = null;
                else
                    this.sqldaListaMayoristas.SelectCommand.Parameters["@iIdDestinatario"].Value = (this.ParamI_iIdDestinatario.ToString() == "-1") ? null : ParamI_iIdDestinatario.ToString();
                //---- FI GSG

				this.sqldaListaMayoristas.SelectCommand.Parameters["@sIdCliente"].Value = (this.txtsIdCliente.Text.ToString() == "")?null:this.txtsIdCliente.Text;
				this.sqldaListaMayoristas.SelectCommand.Parameters["@sNombre"].Value = (this.txtsNombre.Text.ToString() == "")?null:this.txtsNombre.Text;
				this.sqldaListaMayoristas.SelectCommand.Parameters["@Interlocutor"].Value = this.ParamI_TipoInterlocutor;
				this.sqldaListaMayoristas.Fill(this.dsBuscar1);
				if (this.dsBuscar1.ListaBuscaMayoristas.Rows.Count>0)
				{
					this.dgMayoristas.CurrentCell = new DataGridCell(0,1);
					this.dgMayoristas.CurrentCell = new DataGridCell(0,0);
					this.lblNumReg.Text = this.dsBuscar1.ListaBuscaMayoristas.Rows.Count.ToString();
				}
				else
				{
					this.lblNumReg.Text = "0";
				}

				this.Cursor = Cursors.Default;
			}
			catch(Exception ex)
			{
				this.Cursor = Cursors.Default;
				Mensajes.ShowError(ex.Message);
			}
		}
		#endregion

		#region btCancelar_Click
		private void btCancelar_Click(object sender, System.EventArgs e)
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

		#region btAceptar_Click
		private void btAceptar_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(this.dsBuscar1.ListaBuscaMayoristas.Rows.Count <= 0)
				{
					this.ParamO_iIdClienteMayorista = -1;
					this.ParamO_sIdMayorista = "";
					this.ParamO_sNombreMayorista = "";
				}
				this.DialogResult=System.Windows.Forms.DialogResult.OK;
				this.Close();
			}
			catch(Exception ex)
			{
				Mensajes.ShowError(ex.Message);
			}		
		}
		#endregion

		#region dgMayoristas_CurrentCellChanged
		private void dgMayoristas_CurrentCellChanged(object sender, System.EventArgs e)
		{
			try
			{
				Utiles.Seleccionar_UnaFilaDataGrid(this,this.dgMayoristas,this.dgMayoristas.CurrentRowIndex);
				this.ParamO_iIdClienteMayorista = int.Parse(this.dgMayoristas[this.dgMayoristas.CurrentRowIndex,0].ToString());
				this.ParamO_sIdMayorista = this.dgMayoristas[this.dgMayoristas.CurrentRowIndex,1].ToString();
				this.ParamO_sNombreMayorista = this.dgMayoristas[this.dgMayoristas.CurrentRowIndex,2].ToString();
			}
			catch (Exception ex)
			{
				Mensajes.ShowError(ex.Message);
			}		
		}
		#endregion

		#region BorraDatosBusqueda
		private void BorraDatosBusqueda()
		{
			this.dsBuscar1.ListaBuscaMayoristas.Rows.Clear();
			this.lblNumReg.Text = "";
		}
		#endregion

		private void txtsIdCliente_TextChanged(object sender, System.EventArgs e)
		{
			BorraDatosBusqueda();
		}

		private void txtsNombre_TextChanged(object sender, System.EventArgs e)
		{
			BorraDatosBusqueda();
		}

		private void frmMMayoristas_Load(object sender, System.EventArgs e)
		{
			Utiles.Formatear_DataGrid(this,this.dgMayoristas,"C",true);
			BuscarMayorista();
		}

/*		private void frmMMayoristas_Activated(object sender, System.EventArgs e)
		{
			Utiles.Formatear_DataGrid(this,this.dgMayoristas,"C",true);
			BuscarMayorista();
		}
*/
	}
}
