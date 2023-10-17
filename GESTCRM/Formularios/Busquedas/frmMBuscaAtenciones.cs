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
	public class frmMBuscaAtenciones: System.Windows.Forms.Form
	{
		public int		ParamIO_iIdAtencion;
		public string	ParamIO_sIdAtencion;
		public string	ParamIO_sIdTipoAtencion;
		public string	ParamIO_sTipoAtencion;
		public float    ParamO_fImportePrev;
		public float    ParamO_fImporteReal;
		public int		ParamI_iIdDelegado;
		public int		ParamI_iIdCliente;

		private System.Windows.Forms.Button btBuscar;
		private System.Windows.Forms.Button btCancelar;
		private System.Windows.Forms.Button btAceptar;
		private System.Windows.Forms.Label lblsAccion;
		private System.Windows.Forms.Panel pnlAccion;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
		private System.Data.SqlClient.SqlConnection sqlConn;
		private GESTCRM.Formularios.Busquedas.dsBuscar dsBuscar1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
		private System.Windows.Forms.TextBox txbsIdAtencion;
		private System.Windows.Forms.DataGrid dgAtenciones;
		private System.Data.SqlClient.SqlDataAdapter sqldaListaAtencionesAsignables;
		private System.Windows.Forms.Panel pnBusqueda;
		private System.Windows.Forms.Label lblNumReg;
		private GESTCRM.Controles.LabelGradient labelGradient2;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn5;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn6;
		/// <summary>
		/// Variable del diseñador requerida.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmMBuscaAtenciones()
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
            System.Configuration.AppSettingsReader configurationAppSettings = new System.Configuration.AppSettingsReader();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMBuscaAtenciones));
            this.dgAtenciones = new System.Windows.Forms.DataGrid();
            this.dsBuscar1 = new GESTCRM.Formularios.Busquedas.dsBuscar();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn5 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn6 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.pnlAccion = new System.Windows.Forms.Panel();
            this.txbsIdAtencion = new System.Windows.Forms.TextBox();
            this.btBuscar = new System.Windows.Forms.Button();
            this.lblsAccion = new System.Windows.Forms.Label();
            this.btCancelar = new System.Windows.Forms.Button();
            this.btAceptar = new System.Windows.Forms.Button();
            this.sqlConn = new System.Data.SqlClient.SqlConnection();
            this.sqldaListaAtencionesAsignables = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
            this.pnBusqueda = new System.Windows.Forms.Panel();
            this.lblNumReg = new System.Windows.Forms.Label();
            this.labelGradient2 = new GESTCRM.Controles.LabelGradient();
            ((System.ComponentModel.ISupportInitialize)(this.dgAtenciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBuscar1)).BeginInit();
            this.pnlAccion.SuspendLayout();
            this.pnBusqueda.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgAtenciones
            // 
            this.dgAtenciones.BackgroundColor = System.Drawing.Color.White;
            this.dgAtenciones.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.dgAtenciones.CaptionVisible = false;
            this.dgAtenciones.DataMember = "ListaAtencionesAsignables";
            this.dgAtenciones.DataSource = this.dsBuscar1;
            this.dgAtenciones.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgAtenciones.Location = new System.Drawing.Point(0, 23);
            this.dgAtenciones.Name = "dgAtenciones";
            this.dgAtenciones.ReadOnly = true;
            this.dgAtenciones.RowHeaderWidth = 17;
            this.dgAtenciones.Size = new System.Drawing.Size(552, 318);
            this.dgAtenciones.TabIndex = 0;
            this.dgAtenciones.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            this.dgAtenciones.CurrentCellChanged += new System.EventHandler(this.dgAtenciones_CurrentCellChanged);
            this.dgAtenciones.DoubleClick += new System.EventHandler(this.dgAtenciones_DoubleClick);
            // 
            // dsBuscar1
            // 
            this.dsBuscar1.DataSetName = "dsBuscar";
            this.dsBuscar1.Locale = new System.Globalization.CultureInfo("es-ES");
            this.dsBuscar1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.DataGrid = this.dgAtenciones;
            this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn1,
            this.dataGridTextBoxColumn2,
            this.dataGridTextBoxColumn4,
            this.dataGridTextBoxColumn3,
            this.dataGridTextBoxColumn5,
            this.dataGridTextBoxColumn6});
            this.dataGridTableStyle1.HeaderBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle1.MappingName = "ListaAtencionesAsignables";
            this.dataGridTableStyle1.ReadOnly = true;
            this.dataGridTableStyle1.RowHeaderWidth = 17;
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "Código";
            this.dataGridTextBoxColumn1.MappingName = "sIdAtencion";
            this.dataGridTextBoxColumn1.NullText = "";
            this.dataGridTextBoxColumn1.ReadOnly = true;
            this.dataGridTextBoxColumn1.Width = 120;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "Importe Previsto";
            this.dataGridTextBoxColumn2.MappingName = "fImportePrev";
            this.dataGridTextBoxColumn2.NullText = "";
            this.dataGridTextBoxColumn2.ReadOnly = true;
            this.dataGridTextBoxColumn2.Width = 130;
            // 
            // dataGridTextBoxColumn4
            // 
            this.dataGridTextBoxColumn4.Format = "";
            this.dataGridTextBoxColumn4.FormatInfo = null;
            this.dataGridTextBoxColumn4.HeaderText = "Importe Real";
            this.dataGridTextBoxColumn4.MappingName = "fImporteReal";
            this.dataGridTextBoxColumn4.NullText = "";
            this.dataGridTextBoxColumn4.Width = 130;
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.MappingName = "iIdAtencion";
            this.dataGridTextBoxColumn3.NullText = "";
            this.dataGridTextBoxColumn3.ReadOnly = true;
            this.dataGridTextBoxColumn3.Width = 0;
            // 
            // dataGridTextBoxColumn5
            // 
            this.dataGridTextBoxColumn5.Format = "";
            this.dataGridTextBoxColumn5.FormatInfo = null;
            this.dataGridTextBoxColumn5.MappingName = "sIdTipoAtencion";
            this.dataGridTextBoxColumn5.NullText = "";
            this.dataGridTextBoxColumn5.Width = 0;
            // 
            // dataGridTextBoxColumn6
            // 
            this.dataGridTextBoxColumn6.Format = "";
            this.dataGridTextBoxColumn6.FormatInfo = null;
            this.dataGridTextBoxColumn6.HeaderText = "Tipo";
            this.dataGridTextBoxColumn6.MappingName = "sTipoAtencion";
            this.dataGridTextBoxColumn6.NullText = "";
            this.dataGridTextBoxColumn6.Width = 125;
            // 
            // pnlAccion
            // 
            this.pnlAccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAccion.Controls.Add(this.txbsIdAtencion);
            this.pnlAccion.Controls.Add(this.btBuscar);
            this.pnlAccion.Controls.Add(this.lblsAccion);
            this.pnlAccion.Location = new System.Drawing.Point(3, 2);
            this.pnlAccion.Name = "pnlAccion";
            this.pnlAccion.Size = new System.Drawing.Size(555, 67);
            this.pnlAccion.TabIndex = 0;
            // 
            // txbsIdAtencion
            // 
            this.txbsIdAtencion.BackColor = System.Drawing.Color.White;
            this.txbsIdAtencion.ForeColor = System.Drawing.Color.Black;
            this.txbsIdAtencion.Location = new System.Drawing.Point(132, 21);
            this.txbsIdAtencion.MaxLength = 20;
            this.txbsIdAtencion.Name = "txbsIdAtencion";
            this.txbsIdAtencion.Size = new System.Drawing.Size(234, 26);
            this.txbsIdAtencion.TabIndex = 0;
            this.txbsIdAtencion.TextChanged += new System.EventHandler(this.txbsIdAtencion_TextChanged);
            // 
            // btBuscar
            // 
            this.btBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btBuscar.ForeColor = System.Drawing.Color.Black;
            this.btBuscar.Location = new System.Drawing.Point(436, 19);
            this.btBuscar.Name = "btBuscar";
            this.btBuscar.Size = new System.Drawing.Size(75, 28);
            this.btBuscar.TabIndex = 1;
            this.btBuscar.Text = "&Buscar";
            this.btBuscar.UseVisualStyleBackColor = true;
            this.btBuscar.Click += new System.EventHandler(this.btBuscar_Click);
            // 
            // lblsAccion
            // 
            this.lblsAccion.AutoSize = true;
            this.lblsAccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsAccion.ForeColor = System.Drawing.Color.Black;
            this.lblsAccion.Location = new System.Drawing.Point(17, 23);
            this.lblsAccion.Name = "lblsAccion";
            this.lblsAccion.Size = new System.Drawing.Size(113, 20);
            this.lblsAccion.TabIndex = 1;
            this.lblsAccion.Text = "Cód. Atención:";
            // 
            // btCancelar
            // 
            this.btCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btCancelar.Location = new System.Drawing.Point(304, 432);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(80, 31);
            this.btCancelar.TabIndex = 3;
            this.btCancelar.Text = "&Cancelar";
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // btAceptar
            // 
            this.btAceptar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btAceptar.Location = new System.Drawing.Point(186, 432);
            this.btAceptar.Name = "btAceptar";
            this.btAceptar.Size = new System.Drawing.Size(80, 31);
            this.btAceptar.TabIndex = 2;
            this.btAceptar.Text = "&Aceptar";
            this.btAceptar.UseVisualStyleBackColor = true;
            this.btAceptar.Click += new System.EventHandler(this.btAceptar_Click);
            // 
            // sqlConn
            // 
            this.sqlConn.ConnectionString = Utiles._connection.ConnectionString.ToString();   //---- GSG (06/03/2021)
            this.sqlConn.FireInfoMessageEventOnUserErrors = false;
            // 
            // sqldaListaAtencionesAsignables
            // 
            this.sqldaListaAtencionesAsignables.SelectCommand = this.sqlSelectCommand1;
            this.sqldaListaAtencionesAsignables.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaAtencionesAsignables", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iIdAtencion", "iIdAtencion"),
                        new System.Data.Common.DataColumnMapping("sIdAtencion", "sIdAtencion"),
                        new System.Data.Common.DataColumnMapping("sIdTipoAtencion", "sIdTipoAtencion"),
                        new System.Data.Common.DataColumnMapping("sTipoAtencion", "sTipoAtencion"),
                        new System.Data.Common.DataColumnMapping("fImportePrev", "fImportePrev"),
                        new System.Data.Common.DataColumnMapping("fImporteReal", "fImporteReal")})});
            // 
            // sqlSelectCommand1
            // 
            this.sqlSelectCommand1.CommandText = "[ListaAtencionesAsignables]";
            this.sqlSelectCommand1.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand1.Connection = this.sqlConn;
            this.sqlSelectCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdDelegado", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sIdAtencion", System.Data.SqlDbType.VarChar, 20)});
            // 
            // pnBusqueda
            // 
            this.pnBusqueda.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnBusqueda.Controls.Add(this.lblNumReg);
            this.pnBusqueda.Controls.Add(this.labelGradient2);
            this.pnBusqueda.Controls.Add(this.dgAtenciones);
            this.pnBusqueda.Location = new System.Drawing.Point(3, 74);
            this.pnBusqueda.Name = "pnBusqueda";
            this.pnBusqueda.Size = new System.Drawing.Size(555, 345);
            this.pnBusqueda.TabIndex = 1;
            // 
            // lblNumReg
            // 
            this.lblNumReg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.lblNumReg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblNumReg.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumReg.ForeColor = System.Drawing.Color.Black;
            this.lblNumReg.Location = new System.Drawing.Point(484, 0);
            this.lblNumReg.Name = "lblNumReg";
            this.lblNumReg.Size = new System.Drawing.Size(65, 22);
            this.lblNumReg.TabIndex = 2;
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
            this.labelGradient2.Size = new System.Drawing.Size(551, 22);
            this.labelGradient2.TabIndex = 1;
            this.labelGradient2.Text = "Resultado de la Búsqueda";
            this.labelGradient2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmMBuscaAtenciones
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 19);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(230)))), ((int)(((byte)(239)))));
            this.ClientSize = new System.Drawing.Size(562, 475);
            this.Controls.Add(this.pnBusqueda);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.btAceptar);
            this.Controls.Add(this.pnlAccion);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMBuscaAtenciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Búsqueda de Atenciones Comerciales";
            this.Load += new System.EventHandler(this.frmMBuscaAtenciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgAtenciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBuscar1)).EndInit();
            this.pnlAccion.ResumeLayout(false);
            this.pnlAccion.PerformLayout();
            this.pnBusqueda.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void frmMBuscaAtenciones_Load(object sender, System.EventArgs e)
		{
			try
			{
				Utiles.Formatear_DataGrid(this,this.dgAtenciones,"C",true);
				this.txbsIdAtencion.Text = this.ParamIO_sIdAtencion;
			
				Inicializa_Grig();

				Boton_Buscar();
			}
			catch (Exception ex)
			{
				Mensajes.ShowError(ex.Message);
			}		
		}

		private void dgAtenciones_DoubleClick(object sender, System.EventArgs e)
		{
			if(this.dsBuscar1.ListaAtencionesAsignables.Rows.Count > 0)
			{
				try
				{
					if(this.dgAtenciones.CurrentRowIndex==-1)return;
					this.ParamIO_iIdAtencion = int.Parse(this.dgAtenciones[this.dgAtenciones.CurrentRowIndex,3].ToString());
					this.ParamIO_sIdAtencion = this.dgAtenciones[this.dgAtenciones.CurrentRowIndex,0].ToString();
					this.ParamIO_sIdTipoAtencion = this.dgAtenciones[this.dgAtenciones.CurrentRowIndex,4].ToString();
					this.ParamIO_sTipoAtencion = this.dgAtenciones[this.dgAtenciones.CurrentRowIndex,5].ToString();
					this.ParamO_fImportePrev = float.Parse(this.dgAtenciones[this.dgAtenciones.CurrentRowIndex,1].ToString());
					this.ParamO_fImporteReal = float.Parse(this.dgAtenciones[this.dgAtenciones.CurrentRowIndex,2].ToString());

					this.DialogResult=System.Windows.Forms.DialogResult.OK;
					this.Close();
				}
				catch (Exception ex)
				{
					Mensajes.ShowError(ex.Message);
				}
			}
		}

		private void Inicializa_Grig()
		{
			try
			{
				for(int i=0;i<this.dgAtenciones.TableStyles[0].GridColumnStyles.Count;i++)
				{
					DataGridTextBoxColumn TextCol1 = (DataGridTextBoxColumn)this.dgAtenciones.TableStyles[0].GridColumnStyles[i];
					TextCol1.TextBox.DoubleClick += new EventHandler(dgAtenciones_DoubleClick);
				}
			}
			catch (Exception ex)
			{
				Mensajes.ShowError(ex.Message);
			}		
		}

		private void btBuscar_Click(object sender, System.EventArgs e)
		{
			Boton_Buscar();
		}

		private void Boton_Buscar()
		{
			try
			{
				this.Cursor = Cursors.WaitCursor;
				this.dsBuscar1.ListaAtencionesAsignables.Rows.Clear();
				if(this.txbsIdAtencion.Text.Trim()!="")
				{
					this.sqldaListaAtencionesAsignables.SelectCommand.Parameters["@sIdAtencion"].Value = this.txbsIdAtencion.Text.Trim();
				}
				else
				{
					this.sqldaListaAtencionesAsignables.SelectCommand.Parameters["@sIdAtencion"].Value  = null;
				}
				this.sqldaListaAtencionesAsignables.SelectCommand.Parameters["@iIdDelegado"].Value = this.ParamI_iIdDelegado;
				this.sqldaListaAtencionesAsignables.SelectCommand.Parameters["@iIdCliente"].Value = this.ParamI_iIdCliente;

				this.sqldaListaAtencionesAsignables.Fill(this.dsBuscar1);
				if(this.dsBuscar1.ListaAtencionesAsignables.Rows.Count > 0)
				{
					this.dgAtenciones.CurrentCell = new DataGridCell(0,1);
					this.dgAtenciones.CurrentCell = new DataGridCell(0,0);
					this.lblNumReg.Text = this.dsBuscar1.ListaAtencionesAsignables.Rows.Count.ToString();
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
				if(this.dsBuscar1.ListaAtencionesAsignables.Rows.Count <= 0)
				{
					this.ParamIO_iIdAtencion = 0;
					this.ParamIO_sIdAtencion = "";
					this.ParamIO_sIdTipoAtencion = "-1";
					this.ParamIO_sTipoAtencion = "";
					this.ParamO_fImportePrev = 0;
					this.ParamO_fImporteReal = 0;
				}
				this.DialogResult=System.Windows.Forms.DialogResult.OK;
				this.Close();
			}
			catch(Exception ex)
			{
				Mensajes.ShowError(ex.Message);
			}		
		}

		private void dgAtenciones_CurrentCellChanged(object sender, System.EventArgs e)
		{
			try
			{
				Utiles.Seleccionar_UnaFilaDataGrid(this,this.dgAtenciones,this.dgAtenciones.CurrentRowIndex);
				this.ParamIO_iIdAtencion = int.Parse(this.dgAtenciones[this.dgAtenciones.CurrentRowIndex,3].ToString());
				this.ParamIO_sIdAtencion = this.dgAtenciones[this.dgAtenciones.CurrentRowIndex,0].ToString();
				this.ParamIO_sIdTipoAtencion = this.dgAtenciones[this.dgAtenciones.CurrentRowIndex,4].ToString();
				this.ParamIO_sTipoAtencion = this.dgAtenciones[this.dgAtenciones.CurrentRowIndex,5].ToString();
				this.ParamO_fImportePrev = float.Parse(this.dgAtenciones[this.dgAtenciones.CurrentRowIndex,1].ToString());
				this.ParamO_fImporteReal = float.Parse(this.dgAtenciones[this.dgAtenciones.CurrentRowIndex,2].ToString());
			}
			catch (Exception ex)
			{
				Mensajes.ShowError(ex.Message);
			}		
		}

		public void Buscar_Atencion()
		{
			try
			{
				this.ParamIO_iIdAtencion = -1;
				this.ParamO_fImportePrev=0;
				this.ParamO_fImporteReal=0;
				if(this.ParamIO_sIdAtencion.Trim()!="")
				{
					this.sqldaListaAtencionesAsignables.SelectCommand.Parameters["@sIdAtencion"].Value = this.ParamIO_sIdAtencion;
					this.sqldaListaAtencionesAsignables.SelectCommand.Parameters["@iIdDelegado"].Value = this.ParamI_iIdDelegado;
					this.sqldaListaAtencionesAsignables.SelectCommand.Parameters["@iIdCliente"].Value = this.ParamI_iIdCliente;

					this.sqldaListaAtencionesAsignables.Fill(this.dsBuscar1);

					if(this.dsBuscar1.ListaAtencionesAsignables.Rows.Count==1)
					{
						this.ParamIO_iIdAtencion = int.Parse(this.dsBuscar1.ListaAtencionesAsignables.Rows[0]["iIdAtencion"].ToString());
						this.ParamIO_sIdAtencion = this.dsBuscar1.ListaAtencionesAsignables.Rows[0]["sIdAtencion"].ToString();
						this.ParamIO_sIdTipoAtencion = this.dsBuscar1.ListaAtencionesAsignables.Rows[0]["sIdTipoAtencion"].ToString();
						this.ParamIO_sTipoAtencion = this.dsBuscar1.ListaAtencionesAsignables.Rows[0]["sTipoAtencion"].ToString();
						this.ParamO_fImportePrev = float.Parse(this.dsBuscar1.ListaAtencionesAsignables.Rows[0]["fImportePrev"].ToString());
						this.ParamO_fImporteReal = float.Parse(this.dsBuscar1.ListaAtencionesAsignables.Rows[0]["fImporteReal"].ToString());
						this.lblNumReg.Text = this.dsBuscar1.ListaAtencionesAsignables.Rows.Count.ToString();
					}
					else
					{
						this.ParamIO_iIdAtencion = -1;
						this.ParamIO_sIdAtencion = "";
						this.ParamIO_sIdTipoAtencion = "-1";
						this.ParamIO_sTipoAtencion = "";
						this.ParamO_fImportePrev = 0;
						this.ParamO_fImporteReal = 0;
						this.lblNumReg.Text = "0";
					}
				}
			}
			catch (Exception ex)
			{
				Mensajes.ShowError(ex.Message);
			}		
		}

		private void BorraDatosGrid()
		{
			this.dsBuscar1.ListaAtencionesAsignables.Rows.Clear();
			this.lblNumReg.Text = "";
		}

		private void txbsIdAtencion_TextChanged(object sender, System.EventArgs e)
		{
			BorraDatosGrid();
		}

	}
}
