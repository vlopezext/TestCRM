using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace GESTCRM.Formularios.Busquedas
{
	public class frmMClientesInterloc : System.Windows.Forms.Form
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
		private System.Data.SqlClient.SqlDataAdapter sqldaListaSolicitantes;
		private System.Windows.Forms.DataGrid dgClientes;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn iIdClienteMayorista;
		private System.Windows.Forms.DataGridTextBoxColumn sIdCliente;
		private System.Windows.Forms.DataGridTextBoxColumn sNombre;
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.TextBox txtsNombre;

		int ParamI_iIdDestinatario;
		string ParamI_sIdDestinatario;
		string ParamI_sNombreDestinatario;

		string vDestinatario = "";

		public int ParamO_iIdClientePagador;
		public string ParamO_sIdClientePagador;
        public string ParamO_sNombreClientePagador;

        private System.Data.SqlClient.SqlDataAdapter sqldaDevuelveMayorista;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		

        // Recibe como interlocutor el destinatario de pedidos directos, i.e. el cliente que seleccionamos primero
		public frmMClientesInterloc(int iIdDestinatario, string sIdDestinatario, string sNombreDestinatario)
		{
            Cursor.Current = Cursors.WaitCursor;
            InitializeComponent();


            //---- GSG (06/03/2021)
            Utiles.GetConfigConnection();
            this.sqlConn.ConnectionString = Utiles._connection.ConnectionString.ToString();


            
			this.ParamI_iIdDestinatario = iIdDestinatario;
			this.ParamI_sIdDestinatario = sIdDestinatario;
			this.ParamI_sNombreDestinatario = sNombreDestinatario;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMClientesInterloc));
            this.pnlAccion = new System.Windows.Forms.Panel();
            this.txtsNombre = new System.Windows.Forms.TextBox();
            this.lblsNombre = new System.Windows.Forms.Label();
            this.txtsIdCliente = new System.Windows.Forms.TextBox();
            this.btBuscar = new System.Windows.Forms.Button();
            this.lblsIdCliente = new System.Windows.Forms.Label();
            this.btCancelar = new System.Windows.Forms.Button();
            this.btAceptar = new System.Windows.Forms.Button();
            this.sqldaListaSolicitantes = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlConn = new System.Data.SqlClient.SqlConnection();
            this.pnBusqueda = new System.Windows.Forms.Panel();
            this.lblNumReg = new System.Windows.Forms.Label();
            this.labelGradient2 = new GESTCRM.Controles.LabelGradient();
            this.dgClientes = new System.Windows.Forms.DataGrid();
            this.dsBuscar1 = new GESTCRM.Formularios.Busquedas.dsBuscar();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.iIdClienteMayorista = new System.Windows.Forms.DataGridTextBoxColumn();
            this.sIdCliente = new System.Windows.Forms.DataGridTextBoxColumn();
            this.sNombre = new System.Windows.Forms.DataGridTextBoxColumn();
            this.sqldaDevuelveMayorista = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
            this.pnlAccion.SuspendLayout();
            this.pnBusqueda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgClientes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBuscar1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlAccion
            // 
            this.pnlAccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAccion.Controls.Add(this.txtsNombre);
            this.pnlAccion.Controls.Add(this.lblsNombre);
            this.pnlAccion.Controls.Add(this.txtsIdCliente);
            this.pnlAccion.Controls.Add(this.btBuscar);
            this.pnlAccion.Controls.Add(this.lblsIdCliente);
            this.pnlAccion.Location = new System.Drawing.Point(5, 8);
            this.pnlAccion.Name = "pnlAccion";
            this.pnlAccion.Size = new System.Drawing.Size(515, 76);
            this.pnlAccion.TabIndex = 0;
            // 
            // txtsNombre
            // 
            this.txtsNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsNombre.Location = new System.Drawing.Point(79, 39);
            this.txtsNombre.MaxLength = 50;
            this.txtsNombre.Name = "txtsNombre";
            this.txtsNombre.Size = new System.Drawing.Size(322, 26);
            this.txtsNombre.TabIndex = 1;
            this.txtsNombre.TextChanged += new System.EventHandler(this.txtsNombre_TextChanged);
            // 
            // lblsNombre
            // 
            this.lblsNombre.AutoSize = true;
            this.lblsNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsNombre.Location = new System.Drawing.Point(13, 41);
            this.lblsNombre.Name = "lblsNombre";
            this.lblsNombre.Size = new System.Drawing.Size(69, 20);
            this.lblsNombre.TabIndex = 86;
            this.lblsNombre.Text = "Nombre:";
            // 
            // txtsIdCliente
            // 
            this.txtsIdCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsIdCliente.Location = new System.Drawing.Point(79, 7);
            this.txtsIdCliente.MaxLength = 20;
            this.txtsIdCliente.Name = "txtsIdCliente";
            this.txtsIdCliente.Size = new System.Drawing.Size(121, 26);
            this.txtsIdCliente.TabIndex = 0;
            this.txtsIdCliente.TextChanged += new System.EventHandler(this.txtsIdCliente_TextChanged);
            // 
            // btBuscar
            // 
            this.btBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btBuscar.Location = new System.Drawing.Point(424, 38);
            this.btBuscar.Name = "btBuscar";
            this.btBuscar.Size = new System.Drawing.Size(70, 29);
            this.btBuscar.TabIndex = 2;
            this.btBuscar.Text = "&Buscar";
            this.btBuscar.UseVisualStyleBackColor = true;
            this.btBuscar.Click += new System.EventHandler(this.btBuscar_Click);
            // 
            // lblsIdCliente
            // 
            this.lblsIdCliente.AutoSize = true;
            this.lblsIdCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsIdCliente.Location = new System.Drawing.Point(13, 9);
            this.lblsIdCliente.Name = "lblsIdCliente";
            this.lblsIdCliente.Size = new System.Drawing.Size(63, 20);
            this.lblsIdCliente.TabIndex = 1;
            this.lblsIdCliente.Text = "Código:";
            // 
            // btCancelar
            // 
            this.btCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btCancelar.Location = new System.Drawing.Point(421, 482);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(83, 29);
            this.btCancelar.TabIndex = 3;
            this.btCancelar.Text = "&Cancelar";
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // btAceptar
            // 
            this.btAceptar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btAceptar.Location = new System.Drawing.Point(320, 482);
            this.btAceptar.Name = "btAceptar";
            this.btAceptar.Size = new System.Drawing.Size(83, 29);
            this.btAceptar.TabIndex = 2;
            this.btAceptar.Text = "&Aceptar";
            this.btAceptar.UseVisualStyleBackColor = true;
            this.btAceptar.Click += new System.EventHandler(this.btAceptar_Click);
            // 
            // sqldaListaSolicitantes
            // 
            this.sqldaListaSolicitantes.SelectCommand = this.sqlSelectCommand1;
            this.sqldaListaSolicitantes.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaBuscaClientesSAPInterlocutor", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iIdCliente", "iIdCliente"),
                        new System.Data.Common.DataColumnMapping("sIdCliente", "sIdCliente"),
                        new System.Data.Common.DataColumnMapping("sNombre", "sNombre")}),
            new System.Data.Common.DataTableMapping("Table1", "Table1", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iIdCliente", "iIdCliente"),
                        new System.Data.Common.DataColumnMapping("sIdCliente", "sIdCliente"),
                        new System.Data.Common.DataColumnMapping("sNombre", "sNombre")})});
            // 
            // sqlSelectCommand1
            // 
            this.sqlSelectCommand1.CommandText = "[ListaBuscaClientesSAPInterlocutor]";
            this.sqlSelectCommand1.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand1.Connection = this.sqlConn;
            this.sqlSelectCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sIdCliente", System.Data.SqlDbType.VarChar, 20),
            new System.Data.SqlClient.SqlParameter("@sNombre", System.Data.SqlDbType.VarChar, 50)});
            // 
            // sqlConn
            // 
            this.sqlConn.ConnectionString = Utiles._connection.ConnectionString.ToString();   //---- GSG (06/03/2021)
            this.sqlConn.FireInfoMessageEventOnUserErrors = false;
            // 
            // pnBusqueda
            // 
            this.pnBusqueda.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnBusqueda.Controls.Add(this.lblNumReg);
            this.pnBusqueda.Controls.Add(this.labelGradient2);
            this.pnBusqueda.Controls.Add(this.dgClientes);
            this.pnBusqueda.Location = new System.Drawing.Point(3, 90);
            this.pnBusqueda.Name = "pnBusqueda";
            this.pnBusqueda.Size = new System.Drawing.Size(517, 386);
            this.pnBusqueda.TabIndex = 1;
            // 
            // lblNumReg
            // 
            this.lblNumReg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.lblNumReg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblNumReg.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumReg.ForeColor = System.Drawing.Color.Black;
            this.lblNumReg.Location = new System.Drawing.Point(448, 0);
            this.lblNumReg.Name = "lblNumReg";
            this.lblNumReg.Size = new System.Drawing.Size(64, 21);
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
            this.labelGradient2.Size = new System.Drawing.Size(513, 21);
            this.labelGradient2.TabIndex = 84;
            this.labelGradient2.Text = "Resultado de la Búsqueda";
            this.labelGradient2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgClientes
            // 
            this.dgClientes.BackgroundColor = System.Drawing.Color.White;
            this.dgClientes.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.dgClientes.CaptionVisible = false;
            this.dgClientes.DataMember = "ListaBuscaClientesSAPInterlocutor";
            this.dgClientes.DataSource = this.dsBuscar1;
            this.dgClientes.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgClientes.Location = new System.Drawing.Point(0, 21);
            this.dgClientes.Name = "dgClientes";
            this.dgClientes.ReadOnly = true;
            this.dgClientes.RowHeaderWidth = 17;
            this.dgClientes.Size = new System.Drawing.Size(512, 360);
            this.dgClientes.TabIndex = 0;
            this.dgClientes.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            this.dgClientes.CurrentCellChanged += new System.EventHandler(this.dgClientes_CurrentCellChanged);
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
            this.iIdClienteMayorista,
            this.sIdCliente,
            this.sNombre});
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle1.MappingName = "ListaBuscaClientesSAPInterlocutor";
            this.dataGridTableStyle1.RowHeaderWidth = 17;
            // 
            // iIdClienteMayorista
            // 
            this.iIdClienteMayorista.Format = "";
            this.iIdClienteMayorista.FormatInfo = null;
            this.iIdClienteMayorista.HeaderText = "iId";
            this.iIdClienteMayorista.MappingName = "iIdCliente";
            this.iIdClienteMayorista.Width = 0;
            // 
            // sIdCliente
            // 
            this.sIdCliente.Format = "";
            this.sIdCliente.FormatInfo = null;
            this.sIdCliente.HeaderText = "Solicitante/Pagador";
            this.sIdCliente.MappingName = "sIdCliente";
            this.sIdCliente.Width = 150;
            // 
            // sNombre
            // 
            this.sNombre.Format = "";
            this.sNombre.FormatInfo = null;
            this.sNombre.HeaderText = "Nombre";
            this.sNombre.MappingName = "sNombre";
            this.sNombre.Width = 320;
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
            // frmMClientesInterloc
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 19);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(230)))), ((int)(((byte)(239)))));
            this.ClientSize = new System.Drawing.Size(526, 517);
            this.Controls.Add(this.pnBusqueda);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.btAceptar);
            this.Controls.Add(this.pnlAccion);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMClientesInterloc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Búsqueda de Clientes SAP Solicitante/Pagador";
            this.Load += new System.EventHandler(this.frmMClientesInterloc_Load);
            this.pnlAccion.ResumeLayout(false);
            this.pnlAccion.PerformLayout();
            this.pnBusqueda.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgClientes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBuscar1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region IniPantalla
		private void IniPantalla()
		{
			Utiles.Formatear_DataGrid(this,this.dgClientes,"C",true);
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
			
			Inicializa_Grid();
		}
		#endregion

		
        private void dgClientes_DoubleClick(object sender, EventArgs e)
        {
            if (this.dsBuscar1.ListaBuscaClientesSAPInterlocutor.Rows.Count > 0)
            {
                try
                {
                    if (this.dgClientes.CurrentRowIndex == -1) return;
                    this.ParamO_iIdClientePagador = int.Parse(this.dgClientes[this.dgClientes.CurrentRowIndex, 0].ToString());
                    this.ParamO_sIdClientePagador = this.dgClientes[this.dgClientes.CurrentRowIndex, 1].ToString();
                    this.ParamO_sNombreClientePagador = this.dgClientes[this.dgClientes.CurrentRowIndex, 2].ToString();
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    Mensajes.ShowError(ex.Message);
                }
            }
        }

        

        #region Inicializa_Grid
        private void Inicializa_Grid()
		{
			try
			{
				for(int i=0;i<this.dgClientes.TableStyles[0].GridColumnStyles.Count;i++)
				{
					DataGridTextBoxColumn TextCol1 = (DataGridTextBoxColumn)this.dgClientes.TableStyles[0].GridColumnStyles[i];
					TextCol1.TextBox.DoubleClick += new EventHandler(dgClientes_DoubleClick);
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
			BuscarClientePagador();
		}
		#endregion

		//public void DevuelveMayorista(string sIdMayorista)
		//{
		//	this.Cursor = Cursors.WaitCursor;
		//	this.dsBuscar1.ListaDevuelveMayoristas.Rows.Clear();
		//	this.sqldaDevuelveMayorista.SelectCommand.Parameters["@sIdMayorista"].Value = (sIdMayorista.ToString() == "")?null:sIdMayorista.ToString();
		//	//this.sqldaDevuelveMayorista.SelectCommand.Parameters["@Interlocutor"].Value = this.ParamI_TipoInterlocutor;
		//	this.sqldaDevuelveMayorista.Fill(this.dsBuscar1.ListaDevuelveMayoristas);
		//	if (this.dsBuscar1.ListaDevuelveMayoristas.Rows.Count == 1)
		//	{
		//		this.ParamO_iIdClienteMayorista = int.Parse(this.dsBuscar1.ListaDevuelveMayoristas.Rows[0]["iIdClienteMayorista"].ToString());
		//		this.ParamO_sNombreMayorista = this.dsBuscar1.ListaDevuelveMayoristas.Rows[0]["sNombre"].ToString();
		//		this.ParamO_sIdMayorista = this.dsBuscar1.ListaDevuelveMayoristas.Rows[0]["sIdCliente"].ToString();
		//	}
		//	else
		//	{
		//		this.ParamO_iIdClienteMayorista = -1;
		//		this.ParamO_sNombreMayorista = "";
		//	}
		//	this.Cursor = Cursors.Default;
			
		//}

		private void BuscarClientePagador()
		{
			try
			{
				this.Cursor = Cursors.WaitCursor;
				this.dsBuscar1.ListaBuscaClientesSAPInterlocutor.Rows.Clear();

                this.sqldaListaSolicitantes.SelectCommand.Parameters["@iIdCliente"].Value = (this.ParamI_iIdDestinatario.ToString() == "-1") ? null : ParamI_iIdDestinatario.ToString();
				this.sqldaListaSolicitantes.SelectCommand.Parameters["@sIdCliente"].Value = (this.txtsIdCliente.Text.ToString() == "")?null:this.txtsIdCliente.Text;
				this.sqldaListaSolicitantes.SelectCommand.Parameters["@sNombre"].Value = (this.txtsNombre.Text.ToString() == "")?null:this.txtsNombre.Text;

				this.sqldaListaSolicitantes.Fill(this.dsBuscar1);

                if (this.dsBuscar1.ListaBuscaClientesSAPInterlocutor.Rows.Count > 0)
				{
					this.dgClientes.CurrentCell = new DataGridCell(0,1);
					this.dgClientes.CurrentCell = new DataGridCell(0,0);
					this.lblNumReg.Text = this.dsBuscar1.ListaBuscaClientesSAPInterlocutor.Rows.Count.ToString();
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

		private void btAceptar_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(this.dsBuscar1.ListaBuscaClientesSAPInterlocutor.Rows.Count <= 0)
				{
					this.ParamO_iIdClientePagador = -1;
					this.ParamO_sIdClientePagador = "";
					this.ParamO_sNombreClientePagador = "";
				}
				this.DialogResult = System.Windows.Forms.DialogResult.OK;
				this.Close();
			}
			catch(Exception ex)
			{
				Mensajes.ShowError(ex.Message);
			}		
		}

        private void dgClientes_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                Utiles.Seleccionar_UnaFilaDataGrid(this, this.dgClientes, this.dgClientes.CurrentRowIndex);
                this.ParamO_iIdClientePagador = int.Parse(this.dgClientes[this.dgClientes.CurrentRowIndex, 0].ToString());
                this.ParamO_sIdClientePagador = this.dgClientes[this.dgClientes.CurrentRowIndex, 1].ToString();
                this.ParamO_sNombreClientePagador = this.dgClientes[this.dgClientes.CurrentRowIndex, 2].ToString();
            }
            catch (Exception ex)
            {
                Mensajes.ShowError(ex.Message);
            }
        }

        private void BorraDatosBusqueda()
		{
			this.dsBuscar1.ListaBuscaMayoristas.Rows.Clear();
			this.lblNumReg.Text = "";
		}

		private void txtsIdCliente_TextChanged(object sender, System.EventArgs e)
		{
			BorraDatosBusqueda();
		}

		private void txtsNombre_TextChanged(object sender, System.EventArgs e)
		{
			BorraDatosBusqueda();
		}

        private void frmMClientesInterloc_Load(object sender, EventArgs e)
        {
            Utiles.Formatear_DataGrid(this, this.dgClientes, "C", true);
            BuscarClientePagador();
        }
    }
}
