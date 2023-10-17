using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;   

namespace GESTCRM.Formularios.Busquedas
{
	/// <summary>
	/// Descripción breve de frmMMateriales.
	/// </summary>
	public class frmMAcciones : System.Windows.Forms.Form
	{
		public string	ParamIO_iIdAccion;
		public string	ParamIO_sIdAccion;

		private System.Windows.Forms.Button btBuscar;
		private System.Windows.Forms.Button btCancelar;
		private System.Windows.Forms.Button btAceptar;
		private System.Windows.Forms.TextBox txbsIdAccion;
		private System.Windows.Forms.Label lblsAccion;
		private System.Windows.Forms.DataGrid dgAcciones;
		private System.Windows.Forms.Panel pnlAccion;
		private System.Windows.Forms.PictureBox pcbFechaCreacion;
		private System.Windows.Forms.DateTimePicker dtpFechaCreacion;
		private System.Windows.Forms.Label lblFechaCreacion;
		private System.Data.SqlClient.SqlDataAdapter sqlDaAccionesMarketing;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
		private System.Windows.Forms.Panel pnBusqueda;
		private GESTCRM.Controles.LabelGradient labelGradient2;
		private System.Windows.Forms.Label lblNumReg;
		private System.Data.SqlClient.SqlConnection sqlConn;
		private GESTCRM.Formularios.Busquedas.dsBuscar dsBuscar1;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cmbRed;
		private System.Data.SqlClient.SqlDataAdapter sqlDARed;
		private System.Data.SqlClient.SqlCommand sqlSCmdRed;
		/// <summary>
		/// Variable del diseñador requerida.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmMAcciones()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMAcciones));
            this.dgAcciones = new System.Windows.Forms.DataGrid();
            this.dsBuscar1 = new GESTCRM.Formularios.Busquedas.dsBuscar();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.pnlAccion = new System.Windows.Forms.Panel();
            this.cmbRed = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblFechaCreacion = new System.Windows.Forms.Label();
            this.pcbFechaCreacion = new System.Windows.Forms.PictureBox();
            this.dtpFechaCreacion = new System.Windows.Forms.DateTimePicker();
            this.txbsIdAccion = new System.Windows.Forms.TextBox();
            this.btBuscar = new System.Windows.Forms.Button();
            this.lblsAccion = new System.Windows.Forms.Label();
            this.btCancelar = new System.Windows.Forms.Button();
            this.btAceptar = new System.Windows.Forms.Button();
            this.sqlDaAccionesMarketing = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlConn = new System.Data.SqlClient.SqlConnection();
            this.pnBusqueda = new System.Windows.Forms.Panel();
            this.lblNumReg = new System.Windows.Forms.Label();
            this.labelGradient2 = new GESTCRM.Controles.LabelGradient();
            this.sqlDARed = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSCmdRed = new System.Data.SqlClient.SqlCommand();
            ((System.ComponentModel.ISupportInitialize)(this.dgAcciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBuscar1)).BeginInit();
            this.pnlAccion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbFechaCreacion)).BeginInit();
            this.pnBusqueda.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgAcciones
            // 
            this.dgAcciones.BackgroundColor = System.Drawing.Color.White;
            this.dgAcciones.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.dgAcciones.CaptionVisible = false;
            this.dgAcciones.DataMember = "ListaBuscarAccionesMarketing";
            this.dgAcciones.DataSource = this.dsBuscar1;
            this.dgAcciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgAcciones.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgAcciones.Location = new System.Drawing.Point(0, 21);
            this.dgAcciones.Name = "dgAcciones";
            this.dgAcciones.ReadOnly = true;
            this.dgAcciones.RowHeaderWidth = 17;
            this.dgAcciones.Size = new System.Drawing.Size(460, 301);
            this.dgAcciones.TabIndex = 0;
            this.dgAcciones.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            this.dgAcciones.CurrentCellChanged += new System.EventHandler(this.dgAcciones_CurrentCellChanged);
            this.dgAcciones.DoubleClick += new System.EventHandler(this.dgAcciones_DoubleClick);
            // 
            // dsBuscar1
            // 
            this.dsBuscar1.DataSetName = "dsBuscar";
            this.dsBuscar1.Locale = new System.Globalization.CultureInfo("es-ES");
            this.dsBuscar1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.DataGrid = this.dgAcciones;
            this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn1,
            this.dataGridTextBoxColumn2,
            this.dataGridTextBoxColumn3});
            this.dataGridTableStyle1.HeaderBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle1.MappingName = "ListaBuscarAccionesMarketing";
            this.dataGridTableStyle1.ReadOnly = true;
            this.dataGridTableStyle1.RowHeaderWidth = 17;
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "Acción";
            this.dataGridTextBoxColumn1.MappingName = "sIdAccion";
            this.dataGridTextBoxColumn1.ReadOnly = true;
            this.dataGridTextBoxColumn1.Width = 280;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.dataGridTextBoxColumn2.Format = "dd/MM/yyyy";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "Fecha Creación";
            this.dataGridTextBoxColumn2.MappingName = "dFechaCreacion";
            this.dataGridTextBoxColumn2.ReadOnly = true;
            this.dataGridTextBoxColumn2.Width = 130;
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.MappingName = "iIdAccion";
            this.dataGridTextBoxColumn3.ReadOnly = true;
            this.dataGridTextBoxColumn3.Width = 0;
            // 
            // pnlAccion
            // 
            this.pnlAccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAccion.Controls.Add(this.cmbRed);
            this.pnlAccion.Controls.Add(this.label1);
            this.pnlAccion.Controls.Add(this.lblFechaCreacion);
            this.pnlAccion.Controls.Add(this.pcbFechaCreacion);
            this.pnlAccion.Controls.Add(this.dtpFechaCreacion);
            this.pnlAccion.Controls.Add(this.txbsIdAccion);
            this.pnlAccion.Controls.Add(this.btBuscar);
            this.pnlAccion.Controls.Add(this.lblsAccion);
            this.pnlAccion.Location = new System.Drawing.Point(5, 8);
            this.pnlAccion.Name = "pnlAccion";
            this.pnlAccion.Size = new System.Drawing.Size(464, 106);
            this.pnlAccion.TabIndex = 0;
            // 
            // cmbRed
            // 
            this.cmbRed.DataSource = this.dsBuscar1.ListaRedes;
            this.cmbRed.DisplayMember = "sLiteral";
            this.cmbRed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRed.Location = new System.Drawing.Point(125, 68);
            this.cmbRed.Name = "cmbRed";
            this.cmbRed.Size = new System.Drawing.Size(147, 28);
            this.cmbRed.TabIndex = 88;
            this.cmbRed.ValueMember = "sValor";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 20);
            this.label1.TabIndex = 87;
            this.label1.Text = "Red Comercial:";
            // 
            // lblFechaCreacion
            // 
            this.lblFechaCreacion.AutoSize = true;
            this.lblFechaCreacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaCreacion.Location = new System.Drawing.Point(8, 41);
            this.lblFechaCreacion.Name = "lblFechaCreacion";
            this.lblFechaCreacion.Size = new System.Drawing.Size(125, 20);
            this.lblFechaCreacion.TabIndex = 86;
            this.lblFechaCreacion.Text = "Fecha Creación:";
            // 
            // pcbFechaCreacion
            // 
            this.pcbFechaCreacion.Image = ((System.Drawing.Image)(resources.GetObject("pcbFechaCreacion.Image")));
            this.pcbFechaCreacion.Location = new System.Drawing.Point(244, 41);
            this.pcbFechaCreacion.Name = "pcbFechaCreacion";
            this.pcbFechaCreacion.Size = new System.Drawing.Size(21, 22);
            this.pcbFechaCreacion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbFechaCreacion.TabIndex = 85;
            this.pcbFechaCreacion.TabStop = false;
            this.pcbFechaCreacion.Click += new System.EventHandler(this.pcbFechaCreacion_Click);
            // 
            // dtpFechaCreacion
            // 
            this.dtpFechaCreacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaCreacion.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaCreacion.Location = new System.Drawing.Point(134, 38);
            this.dtpFechaCreacion.Name = "dtpFechaCreacion";
            this.dtpFechaCreacion.Size = new System.Drawing.Size(108, 26);
            this.dtpFechaCreacion.TabIndex = 1;
            this.dtpFechaCreacion.ValueChanged += new System.EventHandler(this.dtpFechaCreacion_ValueChanged);
            // 
            // txbsIdAccion
            // 
            this.txbsIdAccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbsIdAccion.Location = new System.Drawing.Point(76, 8);
            this.txbsIdAccion.MaxLength = 50;
            this.txbsIdAccion.Name = "txbsIdAccion";
            this.txbsIdAccion.Size = new System.Drawing.Size(196, 26);
            this.txbsIdAccion.TabIndex = 0;
            this.txbsIdAccion.TextChanged += new System.EventHandler(this.txbsIdAccion_TextChanged);
            // 
            // btBuscar
            // 
            this.btBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btBuscar.Location = new System.Drawing.Point(362, 63);
            this.btBuscar.Name = "btBuscar";
            this.btBuscar.Size = new System.Drawing.Size(75, 33);
            this.btBuscar.TabIndex = 3;
            this.btBuscar.Text = "&Buscar";
            this.btBuscar.UseVisualStyleBackColor = true;
            this.btBuscar.Click += new System.EventHandler(this.btBuscar_Click);
            // 
            // lblsAccion
            // 
            this.lblsAccion.AutoSize = true;
            this.lblsAccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsAccion.Location = new System.Drawing.Point(9, 14);
            this.lblsAccion.Name = "lblsAccion";
            this.lblsAccion.Size = new System.Drawing.Size(61, 20);
            this.lblsAccion.TabIndex = 1;
            this.lblsAccion.Text = "Acción:";
            // 
            // btCancelar
            // 
            this.btCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCancelar.Location = new System.Drawing.Point(256, 456);
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
            this.btAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAceptar.Location = new System.Drawing.Point(136, 456);
            this.btAceptar.Name = "btAceptar";
            this.btAceptar.Size = new System.Drawing.Size(80, 31);
            this.btAceptar.TabIndex = 2;
            this.btAceptar.Text = "&Aceptar";
            this.btAceptar.UseVisualStyleBackColor = true;
            this.btAceptar.Click += new System.EventHandler(this.btAceptar_Click);
            // 
            // sqlDaAccionesMarketing
            // 
            this.sqlDaAccionesMarketing.SelectCommand = this.sqlSelectCommand1;
            this.sqlDaAccionesMarketing.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaBuscarAccionesMarketing", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iIdAccion", "iIdAccion"),
                        new System.Data.Common.DataColumnMapping("sIdAccion", "sIdAccion"),
                        new System.Data.Common.DataColumnMapping("dFechaCreacion", "dFechaCreacion")})});
            // 
            // sqlSelectCommand1
            // 
            this.sqlSelectCommand1.CommandText = "[ListaBuscarAccionesMarketing]";
            this.sqlSelectCommand1.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand1.Connection = this.sqlConn;
            this.sqlSelectCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@sIdAccion", System.Data.SqlDbType.VarChar, 50),
            new System.Data.SqlClient.SqlParameter("@dFechaCreacion", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@sIdRed", System.Data.SqlDbType.VarChar, 5)});
            // 
            // sqlConn
            // 
            this.sqlConn.FireInfoMessageEventOnUserErrors = false;
            // 
            // pnBusqueda
            // 
            this.pnBusqueda.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnBusqueda.Controls.Add(this.lblNumReg);
            this.pnBusqueda.Controls.Add(this.labelGradient2);
            this.pnBusqueda.Controls.Add(this.dgAcciones);
            this.pnBusqueda.Location = new System.Drawing.Point(3, 120);
            this.pnBusqueda.Name = "pnBusqueda";
            this.pnBusqueda.Size = new System.Drawing.Size(464, 329);
            this.pnBusqueda.TabIndex = 1;
            // 
            // lblNumReg
            // 
            this.lblNumReg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.lblNumReg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblNumReg.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumReg.ForeColor = System.Drawing.Color.Black;
            this.lblNumReg.Location = new System.Drawing.Point(393, 0);
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
            this.labelGradient2.Size = new System.Drawing.Size(460, 21);
            this.labelGradient2.TabIndex = 84;
            this.labelGradient2.Text = "Resultado de la Búsqueda";
            this.labelGradient2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sqlDARed
            // 
            this.sqlDARed.SelectCommand = this.sqlSCmdRed;
            this.sqlDARed.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaRedes", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("sValor", "sValor"),
                        new System.Data.Common.DataColumnMapping("sLiteral", "sLiteral")})});
            // 
            // sqlSCmdRed
            // 
            this.sqlSCmdRed.CommandText = "[ListaRedes]";
            this.sqlSCmdRed.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSCmdRed.Connection = this.sqlConn;
            this.sqlSCmdRed.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null)});
            // 
            // frmMAcciones
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(230)))), ((int)(((byte)(239)))));
            this.ClientSize = new System.Drawing.Size(470, 496);
            this.Controls.Add(this.pnBusqueda);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.btAceptar);
            this.Controls.Add(this.pnlAccion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMAcciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Búsqueda de Acciones Marketing";
            this.Load += new System.EventHandler(this.frmMAcciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgAcciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBuscar1)).EndInit();
            this.pnlAccion.ResumeLayout(false);
            this.pnlAccion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbFechaCreacion)).EndInit();
            this.pnBusqueda.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		#region frmMAcciones_Load
		private void frmMAcciones_Load(object sender, System.EventArgs e)
		{
			try
			{
				Utiles.Formatear_DataGrid(this,this.dgAcciones,"C",true);
				this.dtpFechaCreacion.CustomFormat = " ";
				this.dtpFechaCreacion.Format = DateTimePickerFormat.Custom;

				this.txbsIdAccion.Text = ParamIO_sIdAccion;

				Inicializa_Grig();

				this.sqlDARed.Fill(this.dsBuscar1);    
				DataRow filaTodos = this.dsBuscar1.ListaRedes.NewRow();
				filaTodos["sValor"]="T";
				filaTodos["sLiteral"]="Todas";
				this.dsBuscar1.ListaRedes.Rows.InsertAt(filaTodos,0);

				this.cmbRed.SelectedValue= Clases.Configuracion.sIdRed ;
				if(Clases.Configuracion.iTodasAcciones ==0 ) this.cmbRed.Enabled=false;//La red queda Fijada

				
				Hacer_Busqueda();
			}
			catch (Exception ex)
			{
				Mensajes.ShowError(ex.Message);
			}		
		}
		#endregion

		#region dgAcciones_DoubleClick
		private void dgAcciones_DoubleClick(object sender, System.EventArgs e)
		{
			if(this.dsBuscar1.ListaBuscarAccionesMarketing.Rows.Count > 0)
			{
				try
				{
					if(this.dgAcciones.CurrentRowIndex==-1)return;
					ParamIO_iIdAccion = this.dgAcciones[this.dgAcciones.CurrentRowIndex,2].ToString();
					ParamIO_sIdAccion = this.dgAcciones[this.dgAcciones.CurrentRowIndex,0].ToString();
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

		#region Inicializa_Grig
		private void Inicializa_Grig()
		{
			try
			{
				for(int i=0;i<this.dgAcciones.TableStyles[0].GridColumnStyles.Count;i++)
				{
					DataGridTextBoxColumn TextCol1 = (DataGridTextBoxColumn)this.dgAcciones.TableStyles[0].GridColumnStyles[i];
					TextCol1.TextBox.DoubleClick += new EventHandler(dgAcciones_DoubleClick);
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
			Hacer_Busqueda();
		}
		#endregion

		#region Hacer_Busqueda
		private void Hacer_Busqueda()
		{
			try
			{
				this.Cursor = Cursors.WaitCursor;
				this.dsBuscar1.ListaBuscarAccionesMarketing.Rows.Clear();
				if(this.txbsIdAccion.Text.Trim()!="")
				{
					this.sqlDaAccionesMarketing.SelectCommand.Parameters["@sIdAccion"].Value = this.txbsIdAccion.Text.Trim();
				}
				else
				{
					this.sqlDaAccionesMarketing.SelectCommand.Parameters["@sIdAccion"].Value = DBNull.Value;
				}
				if(this.dtpFechaCreacion.Text!=" ")
				{
					this.sqlDaAccionesMarketing.SelectCommand.Parameters["@dFechaCreacion"].Value = this.dtpFechaCreacion.Text;
				}
				else
				{
					this.sqlDaAccionesMarketing.SelectCommand.Parameters["@dFechaCreacion"].Value = DBNull.Value;
				}
				if (this.cmbRed.SelectedValue.ToString() =="T" )
				{
					this.sqlDaAccionesMarketing.SelectCommand.Parameters["@sIdRed"].Value = DBNull.Value;
				}
				else
				{
					this.sqlDaAccionesMarketing.SelectCommand.Parameters["@sIdRed"].Value = this.cmbRed.SelectedValue.ToString() ;
				}
				this.sqlDaAccionesMarketing.Fill(this.dsBuscar1);
				if (this.dsBuscar1.ListaBuscarAccionesMarketing.Rows.Count>0)
				{
					this.dgAcciones.CurrentCell = new DataGridCell(0,1);
					this.dgAcciones.CurrentCell = new DataGridCell(0,0);
					this.lblNumReg.Text = this.dsBuscar1.ListaBuscarAccionesMarketing.Rows.Count.ToString();
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
				if(this.dsBuscar1.ListaBuscarAccionesMarketing.Rows.Count <= 0)
				{
					ParamIO_iIdAccion = "-1";
					ParamIO_sIdAccion = "";
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

		#region dgAcciones_CurrentCellChanged
		private void dgAcciones_CurrentCellChanged(object sender, System.EventArgs e)
		{
			try
			{
				Utiles.Seleccionar_UnaFilaDataGrid(this,this.dgAcciones,this.dgAcciones.CurrentRowIndex);
				ParamIO_iIdAccion = this.dgAcciones[this.dgAcciones.CurrentRowIndex,2].ToString();
				ParamIO_sIdAccion = this.dgAcciones[this.dgAcciones.CurrentRowIndex,0].ToString();
			}
			catch (Exception ex)
			{
				Mensajes.ShowError(ex.Message);
			}		
		}
		#endregion

		#region DatosAccion
		public void DatosAccion()
		{
			try
			{
				ParamIO_iIdAccion = "-1";
				if(this.ParamIO_sIdAccion.Trim()!="")
				{
					this.dsBuscar1.ListaBuscarAccionesMarketing.Rows.Clear();
					this.sqlDaAccionesMarketing.SelectCommand.Parameters["@sIdAccion"].Value = this.ParamIO_sIdAccion;
					this.sqlDaAccionesMarketing.Fill(this.dsBuscar1);
					if(this.dsBuscar1.ListaBuscarAccionesMarketing.Rows.Count==1)
					{
						ParamIO_iIdAccion = this.dsBuscar1.ListaBuscarAccionesMarketing.Rows[0]["iIdAccion"].ToString();
						ParamIO_sIdAccion = this.dsBuscar1.ListaBuscarAccionesMarketing.Rows[0]["sIdAccion"].ToString();
					}
					else
					{
						ParamIO_sIdAccion = "";
					}
				}
			}
			catch (Exception ex)
			{
				Mensajes.ShowError(ex.Message);
			}		
		}
		#endregion 

		#region dtpFechaCreacion_ValueChanged
		private void dtpFechaCreacion_ValueChanged(object sender, System.EventArgs e)
		{
			try
			{
				this.dtpFechaCreacion.CustomFormat = "";
			}
			catch (Exception ex)
			{
				Mensajes.ShowError(ex.Message);
			}		
		}
		#endregion

		#region pcbFechaCreacion_Click
		private void pcbFechaCreacion_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.dtpFechaCreacion.CustomFormat = " ";
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
			this.dsBuscar1.ListaBuscarAccionesMarketing.Rows.Clear();
			this.lblNumReg.Text = "";
		}
		#endregion

		#region txbsIdAccion_TextChanged
		private void txbsIdAccion_TextChanged(object sender, System.EventArgs e)
		{
			BorraDatosBusqueda();
		}
		#endregion
	}
}
