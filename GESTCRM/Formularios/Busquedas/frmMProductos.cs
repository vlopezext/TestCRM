using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace GESTCRM.Formularios.Busquedas
{
	/// <summary>
	/// Descripción breve de frmMCentros.
	/// </summary>
	public class frmMProductos : System.Windows.Forms.Form
	{
		public string	ParamIO_sIdProducto;
		public string	ParamIO_sDescripcion;

		private System.Windows.Forms.Panel pnlCentros;
		private System.Windows.Forms.Label lblDesc;
		private System.Data.SqlClient.SqlConnection sqlConn;
		private GESTCRM.Formularios.Busquedas.dsBuscar dsBuscar1;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
		private System.Windows.Forms.Button btBuscar;
		private System.Windows.Forms.TextBox txbsDescripcion;
		private System.Windows.Forms.Button btCancelar;
		private System.Windows.Forms.Button btAceptar;
		private System.Data.SqlClient.SqlDataAdapter sqldaListaBuscarProductos;
		private System.Windows.Forms.DataGrid dgProductos;
		private System.Windows.Forms.TextBox txbsIdProducto;
		private System.Windows.Forms.Label lblCodigo;
		private System.Windows.Forms.Panel pnBusqueda;
		private System.Windows.Forms.Label lblNumReg;
		private GESTCRM.Controles.LabelGradient labelGradient2;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		/// <summary>
		/// Variable del diseñador requerida.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmMProductos()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMProductos));
            this.dgProductos = new System.Windows.Forms.DataGrid();
            this.dsBuscar1 = new GESTCRM.Formularios.Busquedas.dsBuscar();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.pnlCentros = new System.Windows.Forms.Panel();
            this.btBuscar = new System.Windows.Forms.Button();
            this.txbsDescripcion = new System.Windows.Forms.TextBox();
            this.txbsIdProducto = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.lblDesc = new System.Windows.Forms.Label();
            this.sqlConn = new System.Data.SqlClient.SqlConnection();
            this.sqldaListaBuscarProductos = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
            this.btCancelar = new System.Windows.Forms.Button();
            this.btAceptar = new System.Windows.Forms.Button();
            this.pnBusqueda = new System.Windows.Forms.Panel();
            this.lblNumReg = new System.Windows.Forms.Label();
            this.labelGradient2 = new GESTCRM.Controles.LabelGradient();
            ((System.ComponentModel.ISupportInitialize)(this.dgProductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBuscar1)).BeginInit();
            this.pnlCentros.SuspendLayout();
            this.pnBusqueda.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgProductos
            // 
            this.dgProductos.BackgroundColor = System.Drawing.Color.White;
            this.dgProductos.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.dgProductos.CaptionVisible = false;
            this.dgProductos.DataMember = "ListaBuscarProductos";
            this.dgProductos.DataSource = this.dsBuscar1;
            this.dgProductos.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgProductos.Location = new System.Drawing.Point(0, 18);
            this.dgProductos.Name = "dgProductos";
            this.dgProductos.ReadOnly = true;
            this.dgProductos.RowHeaderWidth = 15;
            this.dgProductos.Size = new System.Drawing.Size(346, 322);
            this.dgProductos.TabIndex = 0;
            this.dgProductos.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            this.dgProductos.DoubleClick += new System.EventHandler(this.dgProductos_DoubleClick);
            this.dgProductos.CurrentCellChanged += new System.EventHandler(this.dgProductos_CurrentCellChanged);
            // 
            // dsBuscar1
            // 
            this.dsBuscar1.DataSetName = "dsBuscar";
            this.dsBuscar1.Locale = new System.Globalization.CultureInfo("es-ES");
            this.dsBuscar1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.DataGrid = this.dgProductos;
            this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn1,
            this.dataGridTextBoxColumn2});
            this.dataGridTableStyle1.HeaderBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle1.MappingName = "ListaBuscarProductos";
            this.dataGridTableStyle1.RowHeaderWidth = 15;
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "Código";
            this.dataGridTextBoxColumn1.MappingName = "sIdProducto";
            this.dataGridTextBoxColumn1.Width = 75;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "Nombre";
            this.dataGridTextBoxColumn2.MappingName = "sDescripcion";
            this.dataGridTextBoxColumn2.Width = 210;
            // 
            // pnlCentros
            // 
            this.pnlCentros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCentros.Controls.Add(this.btBuscar);
            this.pnlCentros.Controls.Add(this.txbsDescripcion);
            this.pnlCentros.Controls.Add(this.txbsIdProducto);
            this.pnlCentros.Controls.Add(this.lblCodigo);
            this.pnlCentros.Controls.Add(this.lblDesc);
            this.pnlCentros.Location = new System.Drawing.Point(3, 5);
            this.pnlCentros.Name = "pnlCentros";
            this.pnlCentros.Size = new System.Drawing.Size(350, 61);
            this.pnlCentros.TabIndex = 0;
            // 
            // btBuscar
            // 
            this.btBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btBuscar.Location = new System.Drawing.Point(264, 6);
            this.btBuscar.Name = "btBuscar";
            this.btBuscar.Size = new System.Drawing.Size(75, 23);
            this.btBuscar.TabIndex = 2;
            this.btBuscar.Text = "Buscar";
            this.btBuscar.UseVisualStyleBackColor = true;
            this.btBuscar.Click += new System.EventHandler(this.btBuscar_Click);
            // 
            // txbsDescripcion
            // 
            this.txbsDescripcion.Location = new System.Drawing.Point(56, 32);
            this.txbsDescripcion.MaxLength = 50;
            this.txbsDescripcion.Name = "txbsDescripcion";
            this.txbsDescripcion.Size = new System.Drawing.Size(288, 20);
            this.txbsDescripcion.TabIndex = 1;
            this.txbsDescripcion.TextChanged += new System.EventHandler(this.txbsDescripcion_TextChanged);
            // 
            // txbsIdProducto
            // 
            this.txbsIdProducto.Location = new System.Drawing.Point(56, 6);
            this.txbsIdProducto.MaxLength = 10;
            this.txbsIdProducto.Name = "txbsIdProducto";
            this.txbsIdProducto.Size = new System.Drawing.Size(128, 20);
            this.txbsIdProducto.TabIndex = 0;
            this.txbsIdProducto.TextChanged += new System.EventHandler(this.txbsIdProducto_TextChanged);
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodigo.Location = new System.Drawing.Point(8, 12);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(43, 13);
            this.lblCodigo.TabIndex = 3;
            this.lblCodigo.Text = "Código:";
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesc.Location = new System.Drawing.Point(8, 38);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(47, 13);
            this.lblDesc.TabIndex = 2;
            this.lblDesc.Text = "Nombre:";
            // 
            // sqlConn
            // 
            //this.sqlConn.ConnectionString = ((string)(configurationAppSettings.GetValue("sConn", typeof(string))));//---- GSG (10/09/2014)
            this.sqlConn = Utiles._connection;
            this.sqlConn.FireInfoMessageEventOnUserErrors = false;
            // 
            // sqldaListaBuscarProductos
            // 
            this.sqldaListaBuscarProductos.SelectCommand = this.sqlSelectCommand1;
            this.sqldaListaBuscarProductos.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaBuscarProductos", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("sIdProducto", "sIdProducto"),
                        new System.Data.Common.DataColumnMapping("sDescripcion", "sDescripcion")})});
            // 
            // sqlSelectCommand1
            // 
            this.sqlSelectCommand1.CommandText = "[ListaBuscarProductos]";
            this.sqlSelectCommand1.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand1.Connection = this.sqlConn;
            this.sqlSelectCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@sIdProducto", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@sDescripcion", System.Data.SqlDbType.VarChar, 50)});
            // 
            // btCancelar
            // 
            this.btCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btCancelar.Location = new System.Drawing.Point(272, 424);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(75, 23);
            this.btCancelar.TabIndex = 3;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // btAceptar
            // 
            this.btAceptar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btAceptar.Location = new System.Drawing.Point(192, 424);
            this.btAceptar.Name = "btAceptar";
            this.btAceptar.Size = new System.Drawing.Size(75, 23);
            this.btAceptar.TabIndex = 2;
            this.btAceptar.Text = "Aceptar";
            this.btAceptar.UseVisualStyleBackColor = true;
            this.btAceptar.Click += new System.EventHandler(this.btAceptar_Click);
            // 
            // pnBusqueda
            // 
            this.pnBusqueda.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnBusqueda.Controls.Add(this.lblNumReg);
            this.pnBusqueda.Controls.Add(this.labelGradient2);
            this.pnBusqueda.Controls.Add(this.dgProductos);
            this.pnBusqueda.Location = new System.Drawing.Point(3, 72);
            this.pnBusqueda.Name = "pnBusqueda";
            this.pnBusqueda.Size = new System.Drawing.Size(350, 344);
            this.pnBusqueda.TabIndex = 1;
            // 
            // lblNumReg
            // 
            this.lblNumReg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.lblNumReg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblNumReg.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumReg.ForeColor = System.Drawing.Color.Black;
            this.lblNumReg.Location = new System.Drawing.Point(288, 0);
            this.lblNumReg.Name = "lblNumReg";
            this.lblNumReg.Size = new System.Drawing.Size(60, 18);
            this.lblNumReg.TabIndex = 93;
            this.lblNumReg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.labelGradient2.Size = new System.Drawing.Size(346, 18);
            this.labelGradient2.TabIndex = 92;
            this.labelGradient2.Text = "Resultado de la Búsqueda";
            this.labelGradient2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmMProductos
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(230)))), ((int)(((byte)(239)))));
            this.ClientSize = new System.Drawing.Size(360, 453);
            this.Controls.Add(this.pnBusqueda);
            this.Controls.Add(this.btAceptar);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.pnlCentros);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMProductos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Búsqueda de Productos";
            this.Load += new System.EventHandler(this.frmMProductos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgProductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBuscar1)).EndInit();
            this.pnlCentros.ResumeLayout(false);
            this.pnlCentros.PerformLayout();
            this.pnBusqueda.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		#region frmMProductos_Load
		private void frmMProductos_Load(object sender, System.EventArgs e)
		{
			try
			{
				Utiles.Formatear_DataGrid(this,this.dgProductos,"C",true);
				this.txbsIdProducto.Text = this.ParamIO_sIdProducto;
				this.txbsDescripcion.Text = this.ParamIO_sDescripcion;

				for(int i=0;i<this.dgProductos.TableStyles[0].GridColumnStyles.Count;i++)
				{
					DataGridTextBoxColumn TextCol = (DataGridTextBoxColumn)this.dgProductos.TableStyles[0].GridColumnStyles[i];
					TextCol.TextBox.DoubleClick += new EventHandler(dgProductos_DoubleClick);
				}
				Buscar_Producto();
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
			Buscar_Producto();
		}
		#endregion

		#region Buscar_Producto
		private void Buscar_Producto()
		{
			try
			{
				this.Cursor = Cursors.WaitCursor;
				this.dsBuscar1.ListaBuscarProductos.Rows.Clear();

				this.sqldaListaBuscarProductos.SelectCommand.Parameters["@sIdProducto"].Value = this.txbsIdProducto.Text.ToString();
				this.sqldaListaBuscarProductos.SelectCommand.Parameters["@sDescripcion"].Value=this.txbsDescripcion.Text.ToString();

				this.sqldaListaBuscarProductos.Fill(this.dsBuscar1);

				if(this.dsBuscar1.ListaBuscarProductos.Rows.Count > 0)
				{
					this.dgProductos.CurrentCell = new DataGridCell(0,1);
					this.dgProductos.CurrentCell = new DataGridCell(0,0);
					this.lblNumReg.Text = this.dsBuscar1.ListaBuscarProductos.Rows.Count.ToString();
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
		#endregion

		#region btAceptar_Click
		private void btAceptar_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(this.dsBuscar1.ListaBuscarProductos.Rows.Count <= 0)
				{
					this.ParamIO_sIdProducto = "";
					this.ParamIO_sDescripcion = "";
				}
				this.DialogResult=System.Windows.Forms.DialogResult.OK;
				this.Close();
			}
			catch (Exception ex)
			{
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
			catch (Exception ex)
			{
				Mensajes.ShowError(ex.Message);
			}
		}
		#endregion

		#region dgProductos_CurrentCellChanged
		private void dgProductos_CurrentCellChanged(object sender, System.EventArgs e)
		{
			try 
			{
				Utiles.Seleccionar_UnaFilaDataGrid(this,this.dgProductos,this.dgProductos.CurrentRowIndex);
				this.ParamIO_sIdProducto = this.dgProductos[this.dgProductos.CurrentRowIndex,0].ToString();
				this.ParamIO_sDescripcion = this.dgProductos[this.dgProductos.CurrentRowIndex,1].ToString();
			}
			catch (Exception ex)
			{
				Mensajes.ShowError(ex.Message);
			}
		}
		#endregion

//		private void TextBoxDoubleClickHandler(object sender, EventArgs e)
//		{
//			this.ParamO_iIdCentro = int.Parse(this.dgCentros[this.dgCentros.CurrentRowIndex,2].ToString());
//			this.ParamIO_sIdCentro = this.dgCentros[this.dgCentros.CurrentRowIndex,0].ToString();
//			this.ParamIO_sDescripcion = this.dgCentros[this.dgCentros.CurrentRowIndex,1].ToString();
//			this.DialogResult=System.Windows.Forms.DialogResult.OK;
//			this.Close();
//		}

		#region Buscar_sProducto
		public void Buscar_sProducto()
		{
			try
			{
				this.dsBuscar1.ListaBuscarProductos.Rows.Clear();

				this.sqldaListaBuscarProductos.SelectCommand.Parameters["@sIdProducto"].Value = this.ParamIO_sIdProducto;
				this.sqldaListaBuscarProductos.SelectCommand.Parameters["@sDescripcion"].Value=this.ParamIO_sDescripcion;

				this.sqldaListaBuscarProductos.Fill(this.dsBuscar1);

				if(this.dsBuscar1.ListaBuscarProductos.Rows.Count==1)
				{
					this.ParamIO_sIdProducto= this.dsBuscar1.ListaBuscarProductos.Rows[0]["sIdProducto"].ToString();
					this.ParamIO_sDescripcion= this.dsBuscar1.ListaBuscarProductos.Rows[0]["sDescripcion"].ToString();
				}
				else
				{
					this.ParamIO_sIdProducto="";
					this.ParamIO_sDescripcion="";
				}
			}
			catch (Exception ex)
			{
				Mensajes.ShowError(ex.Message);
			}
		}
		#endregion

		#region dgProductos_DoubleClick
		private void dgProductos_DoubleClick(object sender, System.EventArgs e)
		{
			if(this.dsBuscar1.ListaBuscarProductos.Rows.Count > 0)
			{
				try
				{
					this.ParamIO_sIdProducto = this.dgProductos[this.dgProductos.CurrentRowIndex,0].ToString();
					this.ParamIO_sDescripcion = this.dgProductos[this.dgProductos.CurrentRowIndex,1].ToString();
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

		#region BorraDatosBusqueda
		private void BorraDatosBusqueda()
		{
			this.dsBuscar1.ListaBuscarProductos.Rows.Clear();
			this.lblNumReg.Text = "";
		}
		#endregion

		#region txbsIdProducto_TextChanged
		private void txbsIdProducto_TextChanged(object sender, System.EventArgs e)
		{
			BorraDatosBusqueda();
		}
		#endregion

		#region txbsDescripcion_TextChanged
		private void txbsDescripcion_TextChanged(object sender, System.EventArgs e)
		{
			BorraDatosBusqueda();
		}
		#endregion

	}
}
