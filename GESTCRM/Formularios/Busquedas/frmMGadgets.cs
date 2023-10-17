using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace GESTCRM.Formularios.Busquedas
{
	/// <summary>
	/// Descripción breve de frmMGadgets.
	/// </summary>
	public class frmMGadgets : System.Windows.Forms.Form
	{
		public int	ParamIO_iIdGadget;
		public string	ParamIO_sDescripcion;
		private System.Windows.Forms.Panel pnlGadgets;
		private System.Data.SqlClient.SqlConnection sqlConn;
		private System.Windows.Forms.DataGrid dgGadgets;
		private System.Data.SqlClient.SqlDataAdapter sqldaListaGadgets;
		private GESTCRM.Formularios.Busquedas.dsBuscar dsBuscar1;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
		private System.Windows.Forms.Button btBuscar;
		private System.Windows.Forms.Button btCancelar;
		private System.Windows.Forms.Button btAceptar;
		private System.Windows.Forms.TextBox txtsDescripcion;
		private System.Windows.Forms.Label lblsDescripcion;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		private System.Windows.Forms.Panel pnBusqueda;
		private System.Windows.Forms.Label lblNumReg;
		private GESTCRM.Controles.LabelGradient labelGradient2;
		/// <summary>
		/// Variable del diseñador requerida.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmMGadgets()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMGadgets));
            System.Configuration.AppSettingsReader configurationAppSettings = new System.Configuration.AppSettingsReader();
            this.dgGadgets = new System.Windows.Forms.DataGrid();
            this.dsBuscar1 = new GESTCRM.Formularios.Busquedas.dsBuscar();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.pnlGadgets = new System.Windows.Forms.Panel();
            this.btBuscar = new System.Windows.Forms.Button();
            this.txtsDescripcion = new System.Windows.Forms.TextBox();
            this.lblsDescripcion = new System.Windows.Forms.Label();
            this.sqlConn = new System.Data.SqlClient.SqlConnection();
            this.sqldaListaGadgets = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
            this.btCancelar = new System.Windows.Forms.Button();
            this.btAceptar = new System.Windows.Forms.Button();
            this.pnBusqueda = new System.Windows.Forms.Panel();
            this.lblNumReg = new System.Windows.Forms.Label();
            this.labelGradient2 = new GESTCRM.Controles.LabelGradient();
            ((System.ComponentModel.ISupportInitialize)(this.dgGadgets)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBuscar1)).BeginInit();
            this.pnlGadgets.SuspendLayout();
            this.pnBusqueda.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgGadgets
            // 
            this.dgGadgets.BackgroundColor = System.Drawing.Color.White;
            this.dgGadgets.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.dgGadgets.CaptionVisible = false;
            this.dgGadgets.DataMember = "ListaGadgets";
            this.dgGadgets.DataSource = this.dsBuscar1;
            this.dgGadgets.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgGadgets.Location = new System.Drawing.Point(0, 22);
            this.dgGadgets.Name = "dgGadgets";
            this.dgGadgets.ReadOnly = true;
            this.dgGadgets.RowHeaderWidth = 15;
            this.dgGadgets.Size = new System.Drawing.Size(448, 312);
            this.dgGadgets.TabIndex = 0;
            this.dgGadgets.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            this.dgGadgets.CurrentCellChanged += new System.EventHandler(this.dgGadgets_CurrentCellChanged);
            this.dgGadgets.DoubleClick += new System.EventHandler(this.dgGadgets_DoubleClick);
            // 
            // dsBuscar1
            // 
            this.dsBuscar1.DataSetName = "dsBuscar";
            this.dsBuscar1.Locale = new System.Globalization.CultureInfo("es-ES");
            this.dsBuscar1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.DataGrid = this.dgGadgets;
            this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn1});
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle1.MappingName = "ListaGadgets";
            this.dataGridTableStyle1.RowHeaderWidth = 15;
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "Descripción";
            this.dataGridTextBoxColumn1.MappingName = "sDescripcion";
            this.dataGridTextBoxColumn1.Width = 400;
            // 
            // pnlGadgets
            // 
            this.pnlGadgets.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(230)))), ((int)(((byte)(239)))));
            this.pnlGadgets.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlGadgets.Controls.Add(this.btBuscar);
            this.pnlGadgets.Controls.Add(this.txtsDescripcion);
            this.pnlGadgets.Controls.Add(this.lblsDescripcion);
            this.pnlGadgets.Location = new System.Drawing.Point(5, 5);
            this.pnlGadgets.Name = "pnlGadgets";
            this.pnlGadgets.Size = new System.Drawing.Size(453, 67);
            this.pnlGadgets.TabIndex = 0;
            // 
            // btBuscar
            // 
            this.btBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btBuscar.Location = new System.Drawing.Point(356, 17);
            this.btBuscar.Name = "btBuscar";
            this.btBuscar.Size = new System.Drawing.Size(75, 28);
            this.btBuscar.TabIndex = 1;
            this.btBuscar.Text = "Buscar";
            this.btBuscar.UseVisualStyleBackColor = true;
            this.btBuscar.Click += new System.EventHandler(this.btBuscar_Click);
            // 
            // txtsDescripcion
            // 
            this.txtsDescripcion.Location = new System.Drawing.Point(102, 18);
            this.txtsDescripcion.MaxLength = 50;
            this.txtsDescripcion.Name = "txtsDescripcion";
            this.txtsDescripcion.Size = new System.Drawing.Size(248, 26);
            this.txtsDescripcion.TabIndex = 0;
            this.txtsDescripcion.TextChanged += new System.EventHandler(this.txtsDescripcion_TextChanged);
            // 
            // lblsDescripcion
            // 
            this.lblsDescripcion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(230)))), ((int)(((byte)(239)))));
            this.lblsDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsDescripcion.Location = new System.Drawing.Point(1, 20);
            this.lblsDescripcion.Name = "lblsDescripcion";
            this.lblsDescripcion.Size = new System.Drawing.Size(96, 20);
            this.lblsDescripcion.TabIndex = 3;
            this.lblsDescripcion.Text = "Descipción:";
            this.lblsDescripcion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sqlConn
            // 
            this.sqlConn.ConnectionString = Utiles._connection.ConnectionString.ToString();   //---- GSG (06/03/2021)
            this.sqlConn.FireInfoMessageEventOnUserErrors = false;
            // 
            // sqldaListaGadgets
            // 
            this.sqldaListaGadgets.SelectCommand = this.sqlSelectCommand1;
            this.sqldaListaGadgets.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaGadgets", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iIdGadget", "iIdGadget"),
                        new System.Data.Common.DataColumnMapping("sDescripcion", "sDescripcion")})});
            // 
            // sqlSelectCommand1
            // 
            this.sqlSelectCommand1.CommandText = "[ListaGadgets]";
            this.sqlSelectCommand1.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand1.Connection = this.sqlConn;
            this.sqlSelectCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdGadget", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sDescripcion", System.Data.SqlDbType.VarChar, 50)});
            // 
            // btCancelar
            // 
            this.btCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btCancelar.Location = new System.Drawing.Point(251, 428);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(80, 31);
            this.btCancelar.TabIndex = 3;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // btAceptar
            // 
            this.btAceptar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btAceptar.Location = new System.Drawing.Point(131, 428);
            this.btAceptar.Name = "btAceptar";
            this.btAceptar.Size = new System.Drawing.Size(80, 31);
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
            this.pnBusqueda.Controls.Add(this.dgGadgets);
            this.pnBusqueda.Location = new System.Drawing.Point(5, 76);
            this.pnBusqueda.Name = "pnBusqueda";
            this.pnBusqueda.Size = new System.Drawing.Size(453, 340);
            this.pnBusqueda.TabIndex = 1;
            // 
            // lblNumReg
            // 
            this.lblNumReg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.lblNumReg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblNumReg.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumReg.ForeColor = System.Drawing.Color.Black;
            this.lblNumReg.Location = new System.Drawing.Point(384, -1);
            this.lblNumReg.Name = "lblNumReg";
            this.lblNumReg.Size = new System.Drawing.Size(65, 22);
            this.lblNumReg.TabIndex = 89;
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
            this.labelGradient2.Size = new System.Drawing.Size(449, 22);
            this.labelGradient2.TabIndex = 88;
            this.labelGradient2.Text = "Resultado de la Búsqueda";
            this.labelGradient2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmMGadgets
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 19);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(230)))), ((int)(((byte)(239)))));
            this.ClientSize = new System.Drawing.Size(470, 475);
            this.Controls.Add(this.pnBusqueda);
            this.Controls.Add(this.btAceptar);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.pnlGadgets);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMGadgets";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Búsqueda de Materiales";
            this.Load += new System.EventHandler(this.frmMGadgets_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgGadgets)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBuscar1)).EndInit();
            this.pnlGadgets.ResumeLayout(false);
            this.pnlGadgets.PerformLayout();
            this.pnBusqueda.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void frmMGadgets_Load(object sender, System.EventArgs e)
		{
			try
			{
				GESTCRM.Utiles.Formatear_DataGrid(this,this.dgGadgets,"C",true);
				this.txtsDescripcion.Text = this.ParamIO_sDescripcion;
				DataGridTextBoxColumn TextCol0 = (DataGridTextBoxColumn)dgGadgets.TableStyles[0].GridColumnStyles[0];
				//TextCol0.TextBox.DoubleClick += new EventHandler(TextBoxDoubleClickHandler);		
				TextCol0.TextBox.DoubleClick += new EventHandler(dgGadgets_DoubleClick);						
				HacerBusqueda();

			}
			catch (Exception ex)
			{
				Mensajes.ShowError(ex.Message);
			}
		}

		private void btBuscar_Click(object sender, System.EventArgs e)
		{
			HacerBusqueda();
		}

		private void HacerBusqueda()
		{
			try
			{
				this.Cursor = Cursors.WaitCursor;
				this.dsBuscar1.ListaGadgets.Rows.Clear();

				string sDescripcion = null;
				//			this.sqldaListaGadgets.SelectCommand.Parameters["@iIdGadget"].Value=this.ParamIO_iIdGadget;
				if(this.txtsDescripcion.Text.ToString().Trim().Length>0) sDescripcion =this.txtsDescripcion.Text.ToString();
	
				this.sqldaListaGadgets.SelectCommand.Parameters["@sDescripcion"].Value=sDescripcion;
		
				this.sqldaListaGadgets.Fill(this.dsBuscar1);
				if (this.dsBuscar1.ListaGadgets.Rows.Count > 0)
				{
					this.lblNumReg.Text = this.dsBuscar1.ListaGadgets.Rows.Count.ToString();
				}
				else
				{
					this.lblNumReg.Text = "0";
				}
				if(this.dsBuscar1.ListaGadgets.Rows.Count > 0)
				{
					this.dgGadgets.Select(0);
					this.dgGadgets.Focus();
				}
				this.Cursor = Cursors.Default;
			}			
			catch (Exception ex)
			{
				this.Cursor = Cursors.Default;
				Mensajes.ShowError(ex.Message);
			}
		}

		private void btAceptar_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(this.dsBuscar1.ListaGadgets.Rows.Count <= 0)
				{
					this.ParamIO_iIdGadget= -1;
					this.ParamIO_sDescripcion = "";
				}
				else
				{
					this.ParamIO_iIdGadget= int.Parse(this.dsBuscar1.ListaGadgets.Rows[this.dgGadgets.CurrentRowIndex]["iIdGadget"].ToString());
					this.ParamIO_sDescripcion = this.dgGadgets[this.dgGadgets.CurrentRowIndex,0].ToString();
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

		private void dgGadgets_CurrentCellChanged(object sender, System.EventArgs e)
		{
			try
			{
				Utiles.Seleccionar_UnaFilaDataGrid(this,this.dgGadgets,this.dgGadgets.CurrentRowIndex);
				this.ParamIO_iIdGadget= int.Parse(this.dsBuscar1.ListaGadgets.Rows[this.dgGadgets.CurrentRowIndex]["iIdGadget"].ToString());
				this.ParamIO_sDescripcion = this.dgGadgets[this.dgGadgets.CurrentRowIndex,0].ToString();
			}
			catch (Exception ex)
			{
				Mensajes.ShowError(ex.Message);
			}
		}

//		private void TextBoxDoubleClickHandler(object sender, EventArgs e)
//		{
//			try
//			{
//				this.ParamIO_iIdGadget= int.Parse(this.dsBuscar1.ListaGadgets.Rows[this.dgGadgets.CurrentRowIndex]["iIdGadget"].ToString());
//				this.ParamIO_sDescripcion = this.dgGadgets[this.dgGadgets.CurrentRowIndex,0].ToString();
//				this.DialogResult=System.Windows.Forms.DialogResult.OK;
//				this.Close();
//			}
//			catch (Exception ex)
//			{
//				Mensajes.ShowError(ex.Message);
//			}
//		}

		public void Buscar_Gadget()
		{
			try
			{
				this.ParamIO_iIdGadget = -1;

				this.dsBuscar1.ListaGadgets.Rows.Clear();

				this.sqldaListaGadgets.SelectCommand.Parameters["@iIdGadget"].Value=this.ParamIO_iIdGadget;
				this.sqldaListaGadgets.SelectCommand.Parameters["@sDescripcion"].Value=this.ParamIO_sDescripcion;

				this.sqldaListaGadgets.Fill(this.dsBuscar1);

				if(this.dsBuscar1.ListaGadgets.Rows.Count==1)
				{
					this.ParamIO_sDescripcion= this.dsBuscar1.ListaGadgets.Rows[0]["sDescripcion"].ToString();
					this.ParamIO_iIdGadget= Int32.Parse(this.dsBuscar1.ListaGadgets.Rows[0]["iIdGadget"].ToString());
				}
				else
				{
					this.ParamIO_sDescripcion= "";
					this.ParamIO_iIdGadget= -1;
				}
			}
			catch (Exception ex)
			{
				//Mensajes.ShowError(ex.Message);
			}
		}

		private void dgGadgets_DoubleClick(object sender, System.EventArgs e)
		{
			if(this.dsBuscar1.ListaGadgets.Rows.Count > 0)
			{
				try
				{
					this.ParamIO_iIdGadget= int.Parse(this.dsBuscar1.ListaGadgets.Rows[this.dgGadgets.CurrentRowIndex]["iIdGadget"].ToString());
					this.ParamIO_sDescripcion = this.dgGadgets[this.dgGadgets.CurrentRowIndex,0].ToString();
					this.DialogResult=System.Windows.Forms.DialogResult.OK;
					this.Close();
				}
				catch (Exception ex)
				{
					Mensajes.ShowError(ex.Message);
				}
			}
		}

		private void BorraDatosBusqueda()
		{
			this.dsBuscar1.ListaGadgets.Rows.Clear();
			this.lblNumReg.Text = "";
		}

		private void txtsDescripcion_TextChanged(object sender, System.EventArgs e)
		{
			BorraDatosBusqueda();
		}

	}
}
