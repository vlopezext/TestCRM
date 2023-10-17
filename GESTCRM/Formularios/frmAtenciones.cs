using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using GESTCRM.Clases;


namespace GESTCRM.Formularios
{
	/// <summary>
	/// Descripción breve de frmPedidos.
	/// </summary>
	public class frmAtenciones : System.Windows.Forms.Form
	{
		//"A","B","M","C"
		private string ParamI_TipoAcceso;
		private int ParamI_iIdAtencion;
		private int ParamI_iIdDelegado;

		private int		Var_CargoDelegado;
		private string	Var_TipoAtencion;
		private int		Var_iIdCliente;
		private int		Var_EnviadoCEN;
		private string	Var_EstadoAnterior;
		private string	Var_sUsuario;

		private bool SalirDesdeGuardar;

		protected System.Data.SqlClient.SqlTransaction sqlTran;

		private System.Windows.Forms.Label lblDelegado;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.Label lblDelegadoAprob;
		private System.Windows.Forms.Label lblDescripcion;
		private System.Windows.Forms.ToolTip toolTipAtenciones;
		private System.Data.SqlClient.SqlConnection sqlConn;
		private System.Windows.Forms.Label lblImportePrev;
		private System.Windows.Forms.Label lblImporteReal;
		private System.Windows.Forms.NumericUpDown nmrImportePrev;
		private System.Windows.Forms.NumericUpDown nmrImporterReal;
		private GESTCRM.Controles.ucBotoneraSecundaria ucBotoneraSecundaria1;
		private System.Windows.Forms.TextBox txbidAtencion;
		private System.Windows.Forms.Label lblFechaSolicitud;
		private System.Windows.Forms.DateTimePicker dtpFechaLiq;
		private System.Windows.Forms.Label lblFechaLiq;
		private System.Windows.Forms.Label lblFechaAprob;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lblFechaAJA;
		private System.Windows.Forms.Label lblFechaPrep;
		private GESTCRM.Controles.LabelGradient lblAtencionesCom;
		private System.Windows.Forms.CheckBox chkBolsaViaje;
		private System.Windows.Forms.ComboBox cbsIdEstAtencion;
		private System.Windows.Forms.TextBox txtObservaciones;
		private System.Windows.Forms.DateTimePicker dtpFechaReal;
		private System.Windows.Forms.DateTimePicker dtpFechaAprob2;
		private System.Windows.Forms.DateTimePicker dtpFechaAprob1;
		private System.Windows.Forms.DateTimePicker dtpFechaPrev;
		private System.Windows.Forms.TextBox txtDelegado;
		private System.Windows.Forms.DateTimePicker dtpFechaCierre;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtDescripcion;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox cbCentroCoste;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtsIdCliente;
		private System.Windows.Forms.Button btBuscarCliente;
		private System.Windows.Forms.TextBox txtsCliente;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox txttTipoAtencion;
		private System.Data.SqlClient.SqlDataAdapter sqldaEstadoAtencion;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		private System.Data.SqlClient.SqlDataAdapter sqldaTipoAtencion;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		private System.Data.SqlClient.SqlDataAdapter sqldaTipoCCoste;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		private System.Data.SqlClient.SqlDataAdapter sqldaGetAtencionComercial;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand5;
		private System.Windows.Forms.Panel pnAtencion;
		private System.Data.SqlClient.SqlCommand sqlCmdSetAtencionesComerciales;
		private System.Data.SqlClient.SqlDataAdapter sqldaGetCargoUsuarioDelegado;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand4;
		private System.Data.SqlClient.SqlDataAdapter sqldaGetDatosFiscalesCliente;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand6;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtFechaCreacion;
		private System.Windows.Forms.DateTimePicker dtpFechaAprob3;
		private System.Windows.Forms.DateTimePicker dtpFechaAprob4;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Data.SqlClient.SqlDataAdapter sqldaAtencionesProductos;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand7;
        private System.Data.SqlClient.SqlConnection sqlConnection1;
        private System.Data.SqlClient.SqlCommand sqlCommand1;
        private DataGridView dgProductosView;
        private DataGridViewCheckBoxColumn bSeleccionatDataGridViewCheckBoxColumn;
        private DataGridViewTextBoxColumn sIdProductoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn sDescripcionDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn iEstadoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn fPorcentajeDataGridViewTextBoxColumn;
        private GESTCRM.Formularios.DataSets.dsAtenciones dsAtenciones1;


		public frmAtenciones(string TipoAcceso,int iIdAtencion,int iIdDelegado)
		{
            InitializeComponent();

            //---- GSG (06/03/2021)
            Utiles.GetConfigConnection();
            this.sqlConn.ConnectionString = Utiles._connection.ConnectionString.ToString();

            
			this.ParamI_TipoAcceso=TipoAcceso;
			this.ParamI_iIdAtencion=iIdAtencion;
			this.ParamI_iIdDelegado=iIdDelegado;
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
            this.components = new System.ComponentModel.Container();
            GESTCRM.Controles.LabelGradient labelGradientProductosAtenciones;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAtenciones));
            System.Configuration.AppSettingsReader configurationAppSettings = new System.Configuration.AppSettingsReader();
            this.pnAtencion = new System.Windows.Forms.Panel();
            this.dgProductosView = new System.Windows.Forms.DataGridView();
            this.bSeleccionatDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.sIdProductoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sDescripcionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iEstadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fPorcentajeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsAtenciones1 = new GESTCRM.Formularios.DataSets.dsAtenciones();
            this.dtpFechaAprob3 = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaAprob4 = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtFechaCreacion = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txttTipoAtencion = new System.Windows.Forms.TextBox();
            this.txtsIdCliente = new System.Windows.Forms.TextBox();
            this.btBuscarCliente = new System.Windows.Forms.Button();
            this.txtsCliente = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cbCentroCoste = new System.Windows.Forms.ComboBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDelegado = new System.Windows.Forms.TextBox();
            this.chkBolsaViaje = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbsIdEstAtencion = new System.Windows.Forms.ComboBox();
            this.lblAtencionesCom = new GESTCRM.Controles.LabelGradient();
            this.txbidAtencion = new System.Windows.Forms.TextBox();
            this.nmrImporterReal = new System.Windows.Forms.NumericUpDown();
            this.nmrImportePrev = new System.Windows.Forms.NumericUpDown();
            this.lblImporteReal = new System.Windows.Forms.Label();
            this.lblImportePrev = new System.Windows.Forms.Label();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.lblDelegadoAprob = new System.Windows.Forms.Label();
            this.lblDelegado = new System.Windows.Forms.Label();
            this.dtpFechaCierre = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaReal = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaLiq = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaPrev = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaAprob1 = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaAprob2 = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblFechaAprob = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblFechaLiq = new System.Windows.Forms.Label();
            this.lblFechaSolicitud = new System.Windows.Forms.Label();
            this.lblFechaAJA = new System.Windows.Forms.Label();
            this.lblFechaPrep = new System.Windows.Forms.Label();
            this.toolTipAtenciones = new System.Windows.Forms.ToolTip(this.components);
            this.sqlConn = new System.Data.SqlClient.SqlConnection();
            this.sqlCmdSetAtencionesComerciales = new System.Data.SqlClient.SqlCommand();
            this.ucBotoneraSecundaria1 = new GESTCRM.Controles.ucBotoneraSecundaria();
            this.sqldaEstadoAtencion = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqldaTipoAtencion = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
            this.sqldaTipoCCoste = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
            this.sqldaGetCargoUsuarioDelegado = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand4 = new System.Data.SqlClient.SqlCommand();
            this.sqldaGetAtencionComercial = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand5 = new System.Data.SqlClient.SqlCommand();
            this.sqldaGetDatosFiscalesCliente = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand6 = new System.Data.SqlClient.SqlCommand();
            this.sqldaAtencionesProductos = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlSelectCommand7 = new System.Data.SqlClient.SqlCommand();
            this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
            labelGradientProductosAtenciones = new GESTCRM.Controles.LabelGradient();
            this.pnAtencion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgProductosView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAtenciones1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrImporterReal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrImportePrev)).BeginInit();
            this.SuspendLayout();
            // 
            // labelGradientProductosAtenciones
            // 
            labelGradientProductosAtenciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            labelGradientProductosAtenciones.ForeColor = System.Drawing.Color.White;
            labelGradientProductosAtenciones.GradientColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            labelGradientProductosAtenciones.GradientColorTwo = System.Drawing.Color.White;
            labelGradientProductosAtenciones.Location = new System.Drawing.Point(335, 300);
            labelGradientProductosAtenciones.Name = "labelGradientProductosAtenciones";
            labelGradientProductosAtenciones.Size = new System.Drawing.Size(652, 18);
            labelGradientProductosAtenciones.TabIndex = 130;
            labelGradientProductosAtenciones.Text = "Productos";
            labelGradientProductosAtenciones.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnAtencion
            // 
            this.pnAtencion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnAtencion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnAtencion.Controls.Add(labelGradientProductosAtenciones);
            this.pnAtencion.Controls.Add(this.dgProductosView);
            this.pnAtencion.Controls.Add(this.dtpFechaAprob3);
            this.pnAtencion.Controls.Add(this.dtpFechaAprob4);
            this.pnAtencion.Controls.Add(this.label7);
            this.pnAtencion.Controls.Add(this.label8);
            this.pnAtencion.Controls.Add(this.txtFechaCreacion);
            this.pnAtencion.Controls.Add(this.label6);
            this.pnAtencion.Controls.Add(this.txttTipoAtencion);
            this.pnAtencion.Controls.Add(this.txtsIdCliente);
            this.pnAtencion.Controls.Add(this.btBuscarCliente);
            this.pnAtencion.Controls.Add(this.txtsCliente);
            this.pnAtencion.Controls.Add(this.label9);
            this.pnAtencion.Controls.Add(this.cbCentroCoste);
            this.pnAtencion.Controls.Add(this.txtDescripcion);
            this.pnAtencion.Controls.Add(this.label3);
            this.pnAtencion.Controls.Add(this.txtDelegado);
            this.pnAtencion.Controls.Add(this.chkBolsaViaje);
            this.pnAtencion.Controls.Add(this.label1);
            this.pnAtencion.Controls.Add(this.cbsIdEstAtencion);
            this.pnAtencion.Controls.Add(this.lblAtencionesCom);
            this.pnAtencion.Controls.Add(this.txbidAtencion);
            this.pnAtencion.Controls.Add(this.nmrImporterReal);
            this.pnAtencion.Controls.Add(this.nmrImportePrev);
            this.pnAtencion.Controls.Add(this.lblImporteReal);
            this.pnAtencion.Controls.Add(this.lblImportePrev);
            this.pnAtencion.Controls.Add(this.txtObservaciones);
            this.pnAtencion.Controls.Add(this.lblDelegadoAprob);
            this.pnAtencion.Controls.Add(this.lblDelegado);
            this.pnAtencion.Controls.Add(this.dtpFechaCierre);
            this.pnAtencion.Controls.Add(this.dtpFechaReal);
            this.pnAtencion.Controls.Add(this.dtpFechaLiq);
            this.pnAtencion.Controls.Add(this.dtpFechaPrev);
            this.pnAtencion.Controls.Add(this.dtpFechaAprob1);
            this.pnAtencion.Controls.Add(this.dtpFechaAprob2);
            this.pnAtencion.Controls.Add(this.label4);
            this.pnAtencion.Controls.Add(this.label5);
            this.pnAtencion.Controls.Add(this.lblDescripcion);
            this.pnAtencion.Controls.Add(this.lblFechaAprob);
            this.pnAtencion.Controls.Add(this.label2);
            this.pnAtencion.Controls.Add(this.lblFechaLiq);
            this.pnAtencion.Controls.Add(this.lblFechaSolicitud);
            this.pnAtencion.Controls.Add(this.lblFechaAJA);
            this.pnAtencion.Controls.Add(this.lblFechaPrep);
            this.pnAtencion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.pnAtencion.ForeColor = System.Drawing.Color.Black;
            this.pnAtencion.Location = new System.Drawing.Point(1, 40);
            this.pnAtencion.Name = "pnAtencion";
            this.pnAtencion.Size = new System.Drawing.Size(1492, 668);
            this.pnAtencion.TabIndex = 0;
            // 
            // dgProductosView
            // 
            this.dgProductosView.AllowUserToAddRows = false;
            this.dgProductosView.AllowUserToDeleteRows = false;
            this.dgProductosView.AutoGenerateColumns = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgProductosView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgProductosView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgProductosView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.bSeleccionatDataGridViewCheckBoxColumn,
            this.sIdProductoDataGridViewTextBoxColumn,
            this.sDescripcionDataGridViewTextBoxColumn,
            this.iEstadoDataGridViewTextBoxColumn,
            this.fPorcentajeDataGridViewTextBoxColumn});
            this.dgProductosView.DataMember = "GetAtencionesAllProducto";
            this.dgProductosView.DataSource = this.dsAtenciones1;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgProductosView.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgProductosView.Location = new System.Drawing.Point(335, 317);
            this.dgProductosView.Name = "dgProductosView";
            this.dgProductosView.Size = new System.Drawing.Size(652, 335);
            this.dgProductosView.TabIndex = 129;
            // 
            // bSeleccionatDataGridViewCheckBoxColumn
            // 
            this.bSeleccionatDataGridViewCheckBoxColumn.DataPropertyName = "bSeleccionat";
            this.bSeleccionatDataGridViewCheckBoxColumn.HeaderText = " ";
            this.bSeleccionatDataGridViewCheckBoxColumn.Name = "bSeleccionatDataGridViewCheckBoxColumn";
            this.bSeleccionatDataGridViewCheckBoxColumn.Width = 30;
            // 
            // sIdProductoDataGridViewTextBoxColumn
            // 
            this.sIdProductoDataGridViewTextBoxColumn.DataPropertyName = "sIdProducto";
            this.sIdProductoDataGridViewTextBoxColumn.HeaderText = "sIdProducto";
            this.sIdProductoDataGridViewTextBoxColumn.Name = "sIdProductoDataGridViewTextBoxColumn";
            this.sIdProductoDataGridViewTextBoxColumn.Visible = false;
            // 
            // sDescripcionDataGridViewTextBoxColumn
            // 
            this.sDescripcionDataGridViewTextBoxColumn.DataPropertyName = "sDescripcion";
            this.sDescripcionDataGridViewTextBoxColumn.HeaderText = "Producto";
            this.sDescripcionDataGridViewTextBoxColumn.Name = "sDescripcionDataGridViewTextBoxColumn";
            this.sDescripcionDataGridViewTextBoxColumn.Width = 450;
            // 
            // iEstadoDataGridViewTextBoxColumn
            // 
            this.iEstadoDataGridViewTextBoxColumn.DataPropertyName = "iEstado";
            this.iEstadoDataGridViewTextBoxColumn.HeaderText = "iEstado";
            this.iEstadoDataGridViewTextBoxColumn.Name = "iEstadoDataGridViewTextBoxColumn";
            this.iEstadoDataGridViewTextBoxColumn.Visible = false;
            // 
            // fPorcentajeDataGridViewTextBoxColumn
            // 
            this.fPorcentajeDataGridViewTextBoxColumn.DataPropertyName = "fPorcentaje";
            this.fPorcentajeDataGridViewTextBoxColumn.HeaderText = "Porcentaje";
            this.fPorcentajeDataGridViewTextBoxColumn.Name = "fPorcentajeDataGridViewTextBoxColumn";
            // 
            // dsAtenciones1
            // 
            this.dsAtenciones1.DataSetName = "dsAtenciones";
            this.dsAtenciones1.Locale = new System.Globalization.CultureInfo("en-US");
            this.dsAtenciones1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dtpFechaAprob3
            // 
            this.dtpFechaAprob3.CalendarForeColor = System.Drawing.Color.Black;
            this.dtpFechaAprob3.CalendarMonthBackground = System.Drawing.Color.White;
            this.dtpFechaAprob3.CalendarTitleBackColor = System.Drawing.Color.Navy;
            this.dtpFechaAprob3.CalendarTitleForeColor = System.Drawing.Color.White;
            this.dtpFechaAprob3.CalendarTrailingForeColor = System.Drawing.Color.Gray;
            this.dtpFechaAprob3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaAprob3.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaAprob3.Location = new System.Drawing.Point(1342, 69);
            this.dtpFechaAprob3.Name = "dtpFechaAprob3";
            this.dtpFechaAprob3.Size = new System.Drawing.Size(107, 26);
            this.dtpFechaAprob3.TabIndex = 124;
            // 
            // dtpFechaAprob4
            // 
            this.dtpFechaAprob4.CalendarForeColor = System.Drawing.Color.Black;
            this.dtpFechaAprob4.CalendarMonthBackground = System.Drawing.Color.White;
            this.dtpFechaAprob4.CalendarTitleBackColor = System.Drawing.Color.Navy;
            this.dtpFechaAprob4.CalendarTitleForeColor = System.Drawing.Color.White;
            this.dtpFechaAprob4.CalendarTrailingForeColor = System.Drawing.Color.Gray;
            this.dtpFechaAprob4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaAprob4.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaAprob4.Location = new System.Drawing.Point(1342, 97);
            this.dtpFechaAprob4.Name = "dtpFechaAprob4";
            this.dtpFechaAprob4.Size = new System.Drawing.Size(107, 26);
            this.dtpFechaAprob4.TabIndex = 125;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(1203, 70);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(127, 23);
            this.label7.TabIndex = 126;
            this.label7.Text = "Fecha Aprob3:";
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(1203, 98);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(114, 21);
            this.label8.TabIndex = 127;
            this.label8.Text = "Fecha Aprob4:";
            // 
            // txtFechaCreacion
            // 
            this.txtFechaCreacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtFechaCreacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFechaCreacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaCreacion.ForeColor = System.Drawing.Color.Black;
            this.txtFechaCreacion.Location = new System.Drawing.Point(1066, 40);
            this.txtFechaCreacion.MaxLength = 20;
            this.txtFechaCreacion.Name = "txtFechaCreacion";
            this.txtFechaCreacion.ReadOnly = true;
            this.txtFechaCreacion.Size = new System.Drawing.Size(107, 26);
            this.txtFechaCreacion.TabIndex = 123;
            this.txtFechaCreacion.TabStop = false;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(937, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(129, 20);
            this.label6.TabIndex = 122;
            this.label6.Text = "Fecha Creación:";
            // 
            // txttTipoAtencion
            // 
            this.txttTipoAtencion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txttTipoAtencion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttTipoAtencion.ForeColor = System.Drawing.Color.Black;
            this.txttTipoAtencion.Location = new System.Drawing.Point(116, 96);
            this.txttTipoAtencion.MaxLength = 50;
            this.txttTipoAtencion.Name = "txttTipoAtencion";
            this.txttTipoAtencion.ReadOnly = true;
            this.txttTipoAtencion.Size = new System.Drawing.Size(200, 26);
            this.txttTipoAtencion.TabIndex = 119;
            this.txttTipoAtencion.TabStop = false;
            // 
            // txtsIdCliente
            // 
            this.txtsIdCliente.BackColor = System.Drawing.Color.White;
            this.txtsIdCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsIdCliente.ForeColor = System.Drawing.Color.Black;
            this.txtsIdCliente.Location = new System.Drawing.Point(335, 199);
            this.txtsIdCliente.Name = "txtsIdCliente";
            this.txtsIdCliente.Size = new System.Drawing.Size(200, 26);
            this.txtsIdCliente.TabIndex = 5;
            this.txtsIdCliente.Leave += new System.EventHandler(this.txtsIdCliente_Leave);
            // 
            // btBuscarCliente
            // 
            this.btBuscarCliente.Image = ((System.Drawing.Image)(resources.GetObject("btBuscarCliente.Image")));
            this.btBuscarCliente.Location = new System.Drawing.Point(965, 199);
            this.btBuscarCliente.Name = "btBuscarCliente";
            this.btBuscarCliente.Size = new System.Drawing.Size(24, 26);
            this.btBuscarCliente.TabIndex = 117;
            this.btBuscarCliente.TabStop = false;
            this.toolTipAtenciones.SetToolTip(this.btBuscarCliente, "Buscar Cliente");
            this.btBuscarCliente.UseVisualStyleBackColor = true;
            this.btBuscarCliente.Click += new System.EventHandler(this.btBuscarCliente_Click);
            // 
            // txtsCliente
            // 
            this.txtsCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtsCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsCliente.ForeColor = System.Drawing.Color.Black;
            this.txtsCliente.Location = new System.Drawing.Point(535, 199);
            this.txtsCliente.Name = "txtsCliente";
            this.txtsCliente.ReadOnly = true;
            this.txtsCliente.Size = new System.Drawing.Size(424, 26);
            this.txtsCliente.TabIndex = 116;
            this.txtsCliente.TabStop = false;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(255, 199);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 19);
            this.label9.TabIndex = 118;
            this.label9.Text = "Cliente:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbCentroCoste
            // 
            this.cbCentroCoste.BackColor = System.Drawing.Color.White;
            this.cbCentroCoste.DataSource = this.dsAtenciones1.ListaTipoCCoste;
            this.cbCentroCoste.DisplayMember = "sLiteral";
            this.cbCentroCoste.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCentroCoste.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCentroCoste.ForeColor = System.Drawing.Color.Black;
            this.cbCentroCoste.Location = new System.Drawing.Point(138, 125);
            this.cbCentroCoste.Name = "cbCentroCoste";
            this.cbCentroCoste.Size = new System.Drawing.Size(284, 28);
            this.cbCentroCoste.TabIndex = 2;
            this.cbCentroCoste.ValueMember = "sValor";
            this.cbCentroCoste.Leave += new System.EventHandler(this.cbCentroCoste_Leave);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.BackColor = System.Drawing.Color.White;
            this.txtDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.ForeColor = System.Drawing.Color.Black;
            this.txtDescripcion.Location = new System.Drawing.Point(605, 43);
            this.txtDescripcion.MaxLength = 50;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(298, 26);
            this.txtDescripcion.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(504, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 21);
            this.label3.TabIndex = 87;
            this.label3.Text = "Descripción:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDelegado
            // 
            this.txtDelegado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtDelegado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDelegado.ForeColor = System.Drawing.Color.Black;
            this.txtDelegado.Location = new System.Drawing.Point(116, 40);
            this.txtDelegado.Name = "txtDelegado";
            this.txtDelegado.ReadOnly = true;
            this.txtDelegado.Size = new System.Drawing.Size(360, 26);
            this.txtDelegado.TabIndex = 86;
            this.txtDelegado.TabStop = false;
            // 
            // chkBolsaViaje
            // 
            this.chkBolsaViaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBolsaViaje.ForeColor = System.Drawing.Color.Black;
            this.chkBolsaViaje.Location = new System.Drawing.Point(854, 126);
            this.chkBolsaViaje.Name = "chkBolsaViaje";
            this.chkBolsaViaje.Size = new System.Drawing.Size(55, 18);
            this.chkBolsaViaje.TabIndex = 12;
            this.chkBolsaViaje.Text = "AP";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(504, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 18);
            this.label1.TabIndex = 83;
            this.label1.Text = "Estado:";
            // 
            // cbsIdEstAtencion
            // 
            this.cbsIdEstAtencion.BackColor = System.Drawing.Color.White;
            this.cbsIdEstAtencion.DataSource = this.dsAtenciones1.ListaTipoEstadoAtencion;
            this.cbsIdEstAtencion.DisplayMember = "sLiteral";
            this.cbsIdEstAtencion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbsIdEstAtencion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbsIdEstAtencion.ForeColor = System.Drawing.Color.Black;
            this.cbsIdEstAtencion.Location = new System.Drawing.Point(605, 72);
            this.cbsIdEstAtencion.Name = "cbsIdEstAtencion";
            this.cbsIdEstAtencion.Size = new System.Drawing.Size(200, 28);
            this.cbsIdEstAtencion.TabIndex = 1;
            this.cbsIdEstAtencion.ValueMember = "sValor";
            this.cbsIdEstAtencion.SelectedIndexChanged += new System.EventHandler(this.cbsIdEstAtencion_SelectedIndexChanged);
            this.cbsIdEstAtencion.Leave += new System.EventHandler(this.cbsIdEstAtencion_Leave);
            // 
            // lblAtencionesCom
            // 
            this.lblAtencionesCom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAtencionesCom.ForeColor = System.Drawing.Color.White;
            this.lblAtencionesCom.GradientColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.lblAtencionesCom.GradientColorTwo = System.Drawing.Color.White;
            this.lblAtencionesCom.Location = new System.Drawing.Point(0, 0);
            this.lblAtencionesCom.Name = "lblAtencionesCom";
            this.lblAtencionesCom.Size = new System.Drawing.Size(1487, 22);
            this.lblAtencionesCom.TabIndex = 81;
            this.lblAtencionesCom.Text = "Atenciones Comerciales";
            // 
            // txbidAtencion
            // 
            this.txbidAtencion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txbidAtencion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txbidAtencion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbidAtencion.ForeColor = System.Drawing.Color.Black;
            this.txbidAtencion.Location = new System.Drawing.Point(116, 68);
            this.txbidAtencion.MaxLength = 20;
            this.txbidAtencion.Name = "txbidAtencion";
            this.txbidAtencion.ReadOnly = true;
            this.txbidAtencion.Size = new System.Drawing.Size(200, 26);
            this.txbidAtencion.TabIndex = 0;
            this.txbidAtencion.TabStop = false;
            // 
            // nmrImporterReal
            // 
            this.nmrImporterReal.BackColor = System.Drawing.Color.White;
            this.nmrImporterReal.DecimalPlaces = 2;
            this.nmrImporterReal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nmrImporterReal.ForeColor = System.Drawing.Color.Black;
            this.nmrImporterReal.Location = new System.Drawing.Point(743, 123);
            this.nmrImporterReal.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.nmrImporterReal.Name = "nmrImporterReal";
            this.nmrImporterReal.Size = new System.Drawing.Size(88, 26);
            this.nmrImporterReal.TabIndex = 4;
            this.nmrImporterReal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nmrImportePrev
            // 
            this.nmrImportePrev.BackColor = System.Drawing.Color.White;
            this.nmrImportePrev.DecimalPlaces = 2;
            this.nmrImportePrev.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nmrImportePrev.ForeColor = System.Drawing.Color.Black;
            this.nmrImportePrev.Location = new System.Drawing.Point(552, 124);
            this.nmrImportePrev.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.nmrImportePrev.Name = "nmrImportePrev";
            this.nmrImportePrev.Size = new System.Drawing.Size(88, 26);
            this.nmrImportePrev.TabIndex = 3;
            this.nmrImportePrev.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblImporteReal
            // 
            this.lblImporteReal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImporteReal.ForeColor = System.Drawing.Color.Black;
            this.lblImporteReal.Location = new System.Drawing.Point(660, 124);
            this.lblImporteReal.Name = "lblImporteReal";
            this.lblImporteReal.Size = new System.Drawing.Size(81, 27);
            this.lblImporteReal.TabIndex = 71;
            this.lblImporteReal.Text = "Imp. Real:";
            // 
            // lblImportePrev
            // 
            this.lblImportePrev.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImportePrev.ForeColor = System.Drawing.Color.Black;
            this.lblImportePrev.Location = new System.Drawing.Point(446, 125);
            this.lblImportePrev.Name = "lblImportePrev";
            this.lblImportePrev.Size = new System.Drawing.Size(104, 23);
            this.lblImportePrev.TabIndex = 70;
            this.lblImportePrev.Text = "Imp. Previsto:";
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.BackColor = System.Drawing.Color.White;
            this.txtObservaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObservaciones.ForeColor = System.Drawing.Color.Black;
            this.txtObservaciones.Location = new System.Drawing.Point(335, 231);
            this.txtObservaciones.MaxLength = 1000;
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObservaciones.Size = new System.Drawing.Size(652, 63);
            this.txtObservaciones.TabIndex = 14;
            this.txtObservaciones.TabStop = false;
            // 
            // lblDelegadoAprob
            // 
            this.lblDelegadoAprob.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblDelegadoAprob.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDelegadoAprob.ForeColor = System.Drawing.Color.Black;
            this.lblDelegadoAprob.Location = new System.Drawing.Point(29, 74);
            this.lblDelegadoAprob.Name = "lblDelegadoAprob";
            this.lblDelegadoAprob.Size = new System.Drawing.Size(64, 23);
            this.lblDelegadoAprob.TabIndex = 67;
            this.lblDelegadoAprob.Text = "Código:";
            // 
            // lblDelegado
            // 
            this.lblDelegado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblDelegado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDelegado.ForeColor = System.Drawing.Color.Black;
            this.lblDelegado.Location = new System.Drawing.Point(29, 42);
            this.lblDelegado.Name = "lblDelegado";
            this.lblDelegado.Size = new System.Drawing.Size(82, 21);
            this.lblDelegado.TabIndex = 13;
            this.lblDelegado.Text = "Delegado:";
            // 
            // dtpFechaCierre
            // 
            this.dtpFechaCierre.CalendarForeColor = System.Drawing.Color.Black;
            this.dtpFechaCierre.CalendarMonthBackground = System.Drawing.Color.White;
            this.dtpFechaCierre.CalendarTitleBackColor = System.Drawing.Color.Navy;
            this.dtpFechaCierre.CalendarTitleForeColor = System.Drawing.Color.White;
            this.dtpFechaCierre.CalendarTrailingForeColor = System.Drawing.Color.Gray;
            this.dtpFechaCierre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaCierre.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaCierre.Location = new System.Drawing.Point(1342, 152);
            this.dtpFechaCierre.Name = "dtpFechaCierre";
            this.dtpFechaCierre.Size = new System.Drawing.Size(107, 26);
            this.dtpFechaCierre.TabIndex = 11;
            // 
            // dtpFechaReal
            // 
            this.dtpFechaReal.CalendarForeColor = System.Drawing.Color.Black;
            this.dtpFechaReal.CalendarMonthBackground = System.Drawing.Color.White;
            this.dtpFechaReal.CalendarTitleBackColor = System.Drawing.Color.Navy;
            this.dtpFechaReal.CalendarTitleForeColor = System.Drawing.Color.White;
            this.dtpFechaReal.CalendarTrailingForeColor = System.Drawing.Color.Gray;
            this.dtpFechaReal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaReal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaReal.Location = new System.Drawing.Point(1342, 41);
            this.dtpFechaReal.Name = "dtpFechaReal";
            this.dtpFechaReal.Size = new System.Drawing.Size(105, 26);
            this.dtpFechaReal.TabIndex = 9;
            // 
            // dtpFechaLiq
            // 
            this.dtpFechaLiq.CalendarForeColor = System.Drawing.Color.Black;
            this.dtpFechaLiq.CalendarMonthBackground = System.Drawing.Color.White;
            this.dtpFechaLiq.CalendarTitleBackColor = System.Drawing.Color.Navy;
            this.dtpFechaLiq.CalendarTitleForeColor = System.Drawing.Color.White;
            this.dtpFechaLiq.CalendarTrailingForeColor = System.Drawing.Color.Gray;
            this.dtpFechaLiq.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaLiq.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaLiq.Location = new System.Drawing.Point(1342, 125);
            this.dtpFechaLiq.Name = "dtpFechaLiq";
            this.dtpFechaLiq.Size = new System.Drawing.Size(107, 26);
            this.dtpFechaLiq.TabIndex = 10;
            // 
            // dtpFechaPrev
            // 
            this.dtpFechaPrev.CalendarForeColor = System.Drawing.Color.Black;
            this.dtpFechaPrev.CalendarMonthBackground = System.Drawing.Color.White;
            this.dtpFechaPrev.CalendarTitleBackColor = System.Drawing.Color.Navy;
            this.dtpFechaPrev.CalendarTitleForeColor = System.Drawing.Color.White;
            this.dtpFechaPrev.CalendarTrailingForeColor = System.Drawing.Color.Gray;
            this.dtpFechaPrev.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaPrev.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaPrev.Location = new System.Drawing.Point(1066, 68);
            this.dtpFechaPrev.Name = "dtpFechaPrev";
            this.dtpFechaPrev.Size = new System.Drawing.Size(107, 26);
            this.dtpFechaPrev.TabIndex = 6;
            // 
            // dtpFechaAprob1
            // 
            this.dtpFechaAprob1.CalendarForeColor = System.Drawing.Color.Black;
            this.dtpFechaAprob1.CalendarMonthBackground = System.Drawing.Color.White;
            this.dtpFechaAprob1.CalendarTitleBackColor = System.Drawing.Color.Navy;
            this.dtpFechaAprob1.CalendarTitleForeColor = System.Drawing.Color.White;
            this.dtpFechaAprob1.CalendarTrailingForeColor = System.Drawing.Color.Gray;
            this.dtpFechaAprob1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaAprob1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaAprob1.Location = new System.Drawing.Point(1066, 96);
            this.dtpFechaAprob1.Name = "dtpFechaAprob1";
            this.dtpFechaAprob1.Size = new System.Drawing.Size(107, 26);
            this.dtpFechaAprob1.TabIndex = 7;
            // 
            // dtpFechaAprob2
            // 
            this.dtpFechaAprob2.CalendarForeColor = System.Drawing.Color.Black;
            this.dtpFechaAprob2.CalendarMonthBackground = System.Drawing.Color.White;
            this.dtpFechaAprob2.CalendarTitleBackColor = System.Drawing.Color.Navy;
            this.dtpFechaAprob2.CalendarTitleForeColor = System.Drawing.Color.White;
            this.dtpFechaAprob2.CalendarTrailingForeColor = System.Drawing.Color.Gray;
            this.dtpFechaAprob2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaAprob2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaAprob2.Location = new System.Drawing.Point(1066, 124);
            this.dtpFechaAprob2.Name = "dtpFechaAprob2";
            this.dtpFechaAprob2.Size = new System.Drawing.Size(107, 26);
            this.dtpFechaAprob2.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(29, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 22);
            this.label4.TabIndex = 100;
            this.label4.Text = "Tipo:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(29, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 25);
            this.label5.TabIndex = 102;
            this.label5.Text = "Centro Coste:";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescripcion.ForeColor = System.Drawing.Color.Black;
            this.lblDescripcion.Location = new System.Drawing.Point(214, 231);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(118, 24);
            this.lblDescripcion.TabIndex = 69;
            this.lblDescripcion.Text = "Observaciones:";
            // 
            // lblFechaAprob
            // 
            this.lblFechaAprob.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblFechaAprob.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaAprob.ForeColor = System.Drawing.Color.Black;
            this.lblFechaAprob.Location = new System.Drawing.Point(937, 100);
            this.lblFechaAprob.Name = "lblFechaAprob";
            this.lblFechaAprob.Size = new System.Drawing.Size(128, 24);
            this.lblFechaAprob.TabIndex = 83;
            this.lblFechaAprob.Text = "Fecha Aprob1:";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(1203, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 20);
            this.label2.TabIndex = 96;
            this.label2.Text = "Fecha Cierre:";
            // 
            // lblFechaLiq
            // 
            this.lblFechaLiq.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblFechaLiq.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaLiq.ForeColor = System.Drawing.Color.Black;
            this.lblFechaLiq.Location = new System.Drawing.Point(1203, 125);
            this.lblFechaLiq.Name = "lblFechaLiq";
            this.lblFechaLiq.Size = new System.Drawing.Size(149, 23);
            this.lblFechaLiq.TabIndex = 84;
            this.lblFechaLiq.Text = "Fecha Liquidación:";
            // 
            // lblFechaSolicitud
            // 
            this.lblFechaSolicitud.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblFechaSolicitud.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaSolicitud.ForeColor = System.Drawing.Color.Black;
            this.lblFechaSolicitud.Location = new System.Drawing.Point(937, 71);
            this.lblFechaSolicitud.Name = "lblFechaSolicitud";
            this.lblFechaSolicitud.Size = new System.Drawing.Size(131, 21);
            this.lblFechaSolicitud.TabIndex = 85;
            this.lblFechaSolicitud.Text = "Fecha Prevista:";
            // 
            // lblFechaAJA
            // 
            this.lblFechaAJA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblFechaAJA.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaAJA.ForeColor = System.Drawing.Color.Black;
            this.lblFechaAJA.Location = new System.Drawing.Point(936, 126);
            this.lblFechaAJA.Name = "lblFechaAJA";
            this.lblFechaAJA.Size = new System.Drawing.Size(133, 23);
            this.lblFechaAJA.TabIndex = 92;
            this.lblFechaAJA.Text = "Fecha Aprob2:";
            // 
            // lblFechaPrep
            // 
            this.lblFechaPrep.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblFechaPrep.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaPrep.ForeColor = System.Drawing.Color.Black;
            this.lblFechaPrep.Location = new System.Drawing.Point(1203, 44);
            this.lblFechaPrep.Name = "lblFechaPrep";
            this.lblFechaPrep.Size = new System.Drawing.Size(107, 16);
            this.lblFechaPrep.TabIndex = 91;
            this.lblFechaPrep.Text = "Fecha Real:";
            // 
            // sqlConn
            // 
            this.sqlConn.ConnectionString = Utiles._connection.ConnectionString.ToString();   //---- GSG (06/03/2021)
            this.sqlConn.FireInfoMessageEventOnUserErrors = false;
            // 
            // sqlCmdSetAtencionesComerciales
            // 
            this.sqlCmdSetAtencionesComerciales.CommandText = "[SetAtencionesComerciales]";
            this.sqlCmdSetAtencionesComerciales.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdSetAtencionesComerciales.Connection = this.sqlConn;
            this.sqlCmdSetAtencionesComerciales.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iAccion", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdAtencion", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.InputOutput, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@sIdAtencionTemp", System.Data.SqlDbType.VarChar, 15, System.Data.ParameterDirection.Output, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@sIdAtencion", System.Data.SqlDbType.VarChar, 20),
            new System.Data.SqlClient.SqlParameter("@iIdDelegado", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sIdEstAtencion", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@sIdTipoAtencion", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@sIdCentroCoste", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@sDescripcion", System.Data.SqlDbType.VarChar, 50),
            new System.Data.SqlClient.SqlParameter("@tObservaciones", System.Data.SqlDbType.VarChar, 8000),
            new System.Data.SqlClient.SqlParameter("@dFechaPrev", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@dFechaAprob1", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@dFechaAprob2", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@dFechaReal", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@dFechaLiq", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@fImportePrev", System.Data.SqlDbType.Float, 8),
            new System.Data.SqlClient.SqlParameter("@bBolsaViaje", System.Data.SqlDbType.Bit, 1),
            new System.Data.SqlClient.SqlParameter("@sUsuAprob1", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@sUsuAprob2", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@bEnviadoCEN", System.Data.SqlDbType.Bit, 1),
            new System.Data.SqlClient.SqlParameter("@Res", System.Data.SqlDbType.VarChar, 10, System.Data.ParameterDirection.Output, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@dFechaAprob3", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@dFechaAprob4", System.Data.SqlDbType.DateTime, 8)});
            // 
            // ucBotoneraSecundaria1
            // 
            this.ucBotoneraSecundaria1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(117)))), ((int)(((byte)(1)))));
            this.ucBotoneraSecundaria1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucBotoneraSecundaria1.ForeColor = System.Drawing.Color.Black;
            this.ucBotoneraSecundaria1.Location = new System.Drawing.Point(0, 0);
            this.ucBotoneraSecundaria1.Name = "ucBotoneraSecundaria1";
            this.ucBotoneraSecundaria1.Size = new System.Drawing.Size(1496, 38);
            this.ucBotoneraSecundaria1.TabIndex = 1;
            // 
            // sqldaEstadoAtencion
            // 
            this.sqldaEstadoAtencion.SelectCommand = this.sqlSelectCommand1;
            this.sqldaEstadoAtencion.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaTipoEstadoAtencion", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("sValor", "sValor"),
                        new System.Data.Common.DataColumnMapping("sLiteral", "sLiteral")})});
            // 
            // sqlSelectCommand1
            // 
            this.sqlSelectCommand1.CommandText = "[ListaTipoEstadoAtencion]";
            this.sqlSelectCommand1.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand1.Connection = this.sqlConn;
            this.sqlSelectCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null)});
            // 
            // sqldaTipoAtencion
            // 
            this.sqldaTipoAtencion.SelectCommand = this.sqlSelectCommand2;
            this.sqldaTipoAtencion.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaTipoAtencionComercial", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("sValor", "sValor"),
                        new System.Data.Common.DataColumnMapping("sLiteral", "sLiteral")})});
            // 
            // sqlSelectCommand2
            // 
            this.sqlSelectCommand2.CommandText = "[ListaTipoAtencionComercial]";
            this.sqlSelectCommand2.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand2.Connection = this.sqlConn;
            this.sqlSelectCommand2.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null)});
            // 
            // sqldaTipoCCoste
            // 
            this.sqldaTipoCCoste.SelectCommand = this.sqlSelectCommand3;
            this.sqldaTipoCCoste.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaTipoCCoste", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("sValor", "sValor"),
                        new System.Data.Common.DataColumnMapping("sLiteral", "sLiteral")})});
            // 
            // sqlSelectCommand3
            // 
            this.sqlSelectCommand3.CommandText = "[ListaTipoCCoste]";
            this.sqlSelectCommand3.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand3.Connection = this.sqlConn;
            this.sqlSelectCommand3.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null)});
            // 
            // sqldaGetCargoUsuarioDelegado
            // 
            this.sqldaGetCargoUsuarioDelegado.SelectCommand = this.sqlSelectCommand4;
            this.sqldaGetCargoUsuarioDelegado.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "GetCargoUsuarioDelegado", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iIdCargo", "iIdCargo"),
                        new System.Data.Common.DataColumnMapping("sUsuario", "sUsuario")})});
            // 
            // sqlSelectCommand4
            // 
            this.sqlSelectCommand4.CommandText = "[GetCargoUsuarioDelegado]";
            this.sqlSelectCommand4.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand4.Connection = this.sqlConn;
            this.sqlSelectCommand4.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdDelegado", System.Data.SqlDbType.Int, 4)});
            // 
            // sqldaGetAtencionComercial
            // 
            this.sqldaGetAtencionComercial.SelectCommand = this.sqlSelectCommand5;
            this.sqldaGetAtencionComercial.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "GetAtencionComercial", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iIdAtencion", "iIdAtencion"),
                        new System.Data.Common.DataColumnMapping("sIdAtencionTemp", "sIdAtencionTemp"),
                        new System.Data.Common.DataColumnMapping("sIdAtencion", "sIdAtencion"),
                        new System.Data.Common.DataColumnMapping("sDescripcion", "sDescripcion"),
                        new System.Data.Common.DataColumnMapping("tObservaciones", "tObservaciones"),
                        new System.Data.Common.DataColumnMapping("sIdTipoAtencion", "sIdTipoAtencion"),
                        new System.Data.Common.DataColumnMapping("sTipoAtencion", "sTipoAtencion"),
                        new System.Data.Common.DataColumnMapping("bBolsaViaje", "bBolsaViaje"),
                        new System.Data.Common.DataColumnMapping("bLiqNotaGastos", "bLiqNotaGastos"),
                        new System.Data.Common.DataColumnMapping("sIdCentroCoste", "sIdCentroCoste"),
                        new System.Data.Common.DataColumnMapping("sCentroCoste", "sCentroCoste"),
                        new System.Data.Common.DataColumnMapping("iIdDelegado", "iIdDelegado"),
                        new System.Data.Common.DataColumnMapping("sIdEstAtencion", "sIdEstAtencion"),
                        new System.Data.Common.DataColumnMapping("sEstAtencion", "sEstAtencion"),
                        new System.Data.Common.DataColumnMapping("iIdCliente", "iIdCliente"),
                        new System.Data.Common.DataColumnMapping("sIdCliente", "sIdCliente"),
                        new System.Data.Common.DataColumnMapping("sNombreCli", "sNombreCli"),
                        new System.Data.Common.DataColumnMapping("fImportePrev", "fImportePrev"),
                        new System.Data.Common.DataColumnMapping("fImporteReal", "fImporteReal"),
                        new System.Data.Common.DataColumnMapping("dFechaPrev", "dFechaPrev"),
                        new System.Data.Common.DataColumnMapping("dFechaAprob1", "dFechaAprob1"),
                        new System.Data.Common.DataColumnMapping("dFechaAprob2", "dFechaAprob2"),
                        new System.Data.Common.DataColumnMapping("dFechaReal", "dFechaReal"),
                        new System.Data.Common.DataColumnMapping("dFechaLiq", "dFechaLiq"),
                        new System.Data.Common.DataColumnMapping("dFechaCierre", "dFechaCierre"),
                        new System.Data.Common.DataColumnMapping("sUsuAprob1", "sUsuAprob1"),
                        new System.Data.Common.DataColumnMapping("sUsuAprob2", "sUsuAprob2"),
                        new System.Data.Common.DataColumnMapping("sUsuLiq", "sUsuLiq"),
                        new System.Data.Common.DataColumnMapping("dFUM", "dFUM"),
                        new System.Data.Common.DataColumnMapping("iEstado", "iEstado"),
                        new System.Data.Common.DataColumnMapping("bEnviadoPDA", "bEnviadoPDA"),
                        new System.Data.Common.DataColumnMapping("bEnviadoCEN", "bEnviadoCEN")})});
            // 
            // sqlSelectCommand5
            // 
            this.sqlSelectCommand5.CommandText = "[GetAtencionComercial]";
            this.sqlSelectCommand5.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand5.Connection = this.sqlConn;
            this.sqlSelectCommand5.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdAtencion", System.Data.SqlDbType.Int, 4)});
            // 
            // sqldaGetDatosFiscalesCliente
            // 
            this.sqldaGetDatosFiscalesCliente.SelectCommand = this.sqlSelectCommand6;
            this.sqldaGetDatosFiscalesCliente.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "GetDatosFiscalesCliente", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("sNIF", "sNIF"),
                        new System.Data.Common.DataColumnMapping("sDireccion", "sDireccion"),
                        new System.Data.Common.DataColumnMapping("sCodPostal", "sCodPostal"),
                        new System.Data.Common.DataColumnMapping("sProvincia", "sProvincia"),
                        new System.Data.Common.DataColumnMapping("sPoblacion", "sPoblacion")})});
            // 
            // sqlSelectCommand6
            // 
            this.sqlSelectCommand6.CommandText = "[GetDatosFiscalesCliente]";
            this.sqlSelectCommand6.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand6.Connection = this.sqlConn;
            this.sqlSelectCommand6.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4)});
            // 
            // sqldaAtencionesProductos
            // 
            this.sqldaAtencionesProductos.InsertCommand = this.sqlCommand1;
            this.sqldaAtencionesProductos.SelectCommand = this.sqlSelectCommand7;
            this.sqldaAtencionesProductos.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "GetAtencionesAllProducto", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("sIdProducto", "sIdProducto"),
                        new System.Data.Common.DataColumnMapping("sDescripcion", "sDescripcion"),
                        new System.Data.Common.DataColumnMapping("iEstado", "iEstado"),
                        new System.Data.Common.DataColumnMapping("fPorcentaje", "fPorcentaje")})});
            // 
            // sqlCommand1
            // 
            this.sqlCommand1.CommandText = "SetAtencionesProducto";
            this.sqlCommand1.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCommand1.Connection = this.sqlConn;
            this.sqlCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@piIdAtencion", System.Data.SqlDbType.Int),
            new System.Data.SqlClient.SqlParameter("@psIdProducto", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@fPorcentaje", System.Data.SqlDbType.Float)});
            // 
            // sqlSelectCommand7
            // 
            this.sqlSelectCommand7.CommandText = "[GetAtencionesAllProducto]";
            this.sqlSelectCommand7.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand7.Connection = this.sqlConn;
            this.sqlSelectCommand7.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@piIdAtencion", System.Data.SqlDbType.Int, 4)});
            // 
            // sqlConnection1
            // 
            this.sqlConnection1.ConnectionString = "workstation id=08CPO0111;packet size=4096;user id=sa;data source=\"08CPO0111\\SQLPR" +
    "OVA\";persist security info=False;initial catalog=GESTCRMCL";
            this.sqlConnection1.FireInfoMessageEventOnUserErrors = false;
            // 
            // frmAtenciones
            // 
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.ClientSize = new System.Drawing.Size(1496, 720);
            this.Controls.Add(this.ucBotoneraSecundaria1);
            this.Controls.Add(this.pnAtencion);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAtenciones";
            this.Text = "Atenciones Comerciales";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmAtenciones_Closing);
            this.Closed += new System.EventHandler(this.frmAtenciones_Closed);
            this.Load += new System.EventHandler(this.frmAtenciones_Load);
            this.pnAtencion.ResumeLayout(false);
            this.pnAtencion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgProductosView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAtenciones1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrImporterReal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrImportePrev)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region frmAtenciones_Load
		private void frmAtenciones_Load(object sender, System.EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;	
			try
			{
				Utiles.Formato_Formulario( this );
				if(this.Parent == null) this.WindowState = FormWindowState.Normal;

				

				//El acceso 0 es el único que permite grabar datos
				if(GESTCRM.Clases.Configuracion.iGAtenciones!=0) this.ParamI_TipoAcceso="C";

				Obtener_CargoUsuarioDelegado();

			
				//Si no se encuentra el cargo, sólo se permite consulta
				if(this.Var_CargoDelegado==-1) this.ParamI_TipoAcceso="C";

				Inicializar_Combos();
			
				Cargar_Grid_De_Productos();

				if(this.ParamI_TipoAcceso!="A") 
				{
					//En altas el delegado viene fijado de configuración 
					this.txtDelegado.Text = GESTCRM.Utiles.NombreDeleg(this.ParamI_iIdDelegado);
					
					Recupera_Atencion_Comercial(); //Sinó es un alta recupera de Base de Datos
					
					if(this.Var_EnviadoCEN==1 && this.ParamI_TipoAcceso=="M") 
					{
						//Creada y usuario Aprobador1 puede Modificarla aunque esté enviada a Central
						//Aprobada1 y usuario Aprobador2 puede Modificarla aunque esté enviada a Central
						//Aprobada2 y usuario Delegado puede Modificarla aunque esté enviada a Central
						if(this.cbsIdEstAtencion.SelectedValue.ToString()=="0" && this.Var_CargoDelegado==Configuracion.iCargoAprob1)
						{this.Var_EnviadoCEN=0;}
						else if(this.cbsIdEstAtencion.SelectedValue.ToString()=="1" && this.Var_CargoDelegado==Configuracion.iCargoAprob2) 
						{this.Var_EnviadoCEN=0;}
						else if(this.cbsIdEstAtencion.SelectedValue.ToString()=="2" && this.Var_CargoDelegado!=Configuracion.iCargoAprob1 && this.Var_CargoDelegado!=Configuracion.iCargoAprob2)
						{this.Var_EnviadoCEN=0;}
						else if(this.cbsIdEstAtencion.SelectedValue.ToString()=="3" && this.Var_CargoDelegado==Configuracion.iCargoAprob1)
						{this.Var_EnviadoCEN=0;}
						else if(this.cbsIdEstAtencion.SelectedValue.ToString()=="31" && this.Var_CargoDelegado==Configuracion.iCargoAprob2)
						{this.Var_EnviadoCEN=0;}
						else if(this.cbsIdEstAtencion.SelectedValue.ToString()=="4" && this.Var_CargoDelegado!=Configuracion.iCargoAprob1 && this.Var_CargoDelegado!=Configuracion.iCargoAprob2)
						{this.Var_EnviadoCEN=0;}
						else
						{this.ParamI_TipoAcceso="C";}
					}
					if(this.ParamI_TipoAcceso=="M")
					{
						//Estado=Creada, pueden modificar Delegado y Aprobador1
						//Estado=Aprobada1, pueden modificar Aprobador1 y Aprobador 2
						//Estado=Aprobada2, pueden modificar Delegado y Aprobador2
						//Estado=Realizada, sólo puede modificar el delegado
						//Estado=Aprobada3, pueden modificar Aprobador3 y Aprobador 4
						//Estado=Aprobada4, pueden modificar Delegado y Aprobador4
						//Estado=Liquidada, sólo puede modificar el delegado
						//Estado=Cerrada,Anulada
						switch(this.cbsIdEstAtencion.SelectedValue.ToString())
						{
								//case "0": if(this.Var_CargoDelegado==Configuracion.iCargoAprob1) 
							case "0": 

								if(this.Var_CargoDelegado!=Configuracion.iCargoAprob1) // es el delegat
								{
									if (Var_EnviadoCEN.ToString() == "1")
									{
										this.ParamI_TipoAcceso="C";
									}
									else 
									{
										this.ParamI_TipoAcceso="M"; 
									}
								}
								else //this.Var_CargoDelegado == Configuracion.iCargoAprob1  --> es el jefe
								{
									this.ParamI_TipoAcceso="M"; 
								}

//									  if(this.Var_CargoDelegado!=Configuracion.iCargoAprob1) 
//											this.ParamI_TipoAcceso="C";

								break;
								//case "1": if(this.Var_CargoDelegado!=Configuracion.iCargoAprob1 && this.Var_CargoDelegado!=Configuracion.iCargoAprob2) 
							case "1": if( this.Var_CargoDelegado!=Configuracion.iCargoAprob2) 
										  this.ParamI_TipoAcceso="C";
								break;
							case "2": if(this.Var_CargoDelegado==Configuracion.iCargoAprob1) 
										  this.ParamI_TipoAcceso="C";
								break;
							case "3": 
								if(this.Var_CargoDelegado!=Configuracion.iCargoAprob1)
									this.ParamI_TipoAcceso="C";
								break;
							case "31": if( this.Var_CargoDelegado!=Configuracion.iCargoAprob2) 
										   this.ParamI_TipoAcceso="C";
								break;
							case "32": 
								this.ParamI_TipoAcceso="C";
								break;
							case "4": 
								//if(this.Var_CargoDelegado==Configuracion.iCargoAprob1 && this.Var_CargoDelegado==Configuracion.iCargoAprob2) 
								this.ParamI_TipoAcceso="C";
								break;
							case "6": ObtenerModoAcceso_Anulada();
								break;
							default: this.ParamI_TipoAcceso="C"; break;
						}
					}
				}
				else
				{
					Inicializa_TipoAtencion();
					this.txtFechaCreacion.Text = DateTime.Today.ToString("dd/MM/yyyy");
					this.Var_iIdCliente=-1;
					this.Var_EnviadoCEN=0;
				}

				Inicializa_Formulario();

				Inicializar_Botonera();

				this.SalirDesdeGuardar=false;

			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}

			Cursor.Current = Cursors.Default;
		}
		#endregion

		private void Cargar_Grid_De_Productos()
		{
			this.sqldaAtencionesProductos.SelectCommand.Parameters["@piIdAtencion"].Value=this.ParamI_iIdAtencion;
			this.sqldaAtencionesProductos.Fill(this.dsAtenciones1);
		}

		#region Obtener_CargoUsuarioDelegado
		private void Obtener_CargoUsuarioDelegado()
		{
			try
			{
				this.sqldaGetCargoUsuarioDelegado.SelectCommand.Parameters["@iIdDelegado"].Value=this.ParamI_iIdDelegado;
				this.sqldaGetCargoUsuarioDelegado.Fill(this.dsAtenciones1);

				if(this.dsAtenciones1.GetCargoUsuarioDelegado.Rows.Count==1)
				{
					this.Var_CargoDelegado= int.Parse(this.dsAtenciones1.GetCargoUsuarioDelegado.Rows[0]["iIdCargo"].ToString());
					this.Var_sUsuario= this.dsAtenciones1.GetCargoUsuarioDelegado.Rows[0]["sUsuario"].ToString();
				}
				else
				{
					this.Var_CargoDelegado = -1;
					this.Var_sUsuario = null;
				}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region Inicializar_Combos
		private void Inicializar_Combos()
		{
			try
			{
				//ComboBox cbsIdEstAtencion
				this.sqldaEstadoAtencion.Fill(this.dsAtenciones1);
			
				//ComboBox cbCentroCoste
				this.sqldaTipoCCoste.Fill(this.dsAtenciones1);
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region ObtenerModoAcceso_Anulada
		private void ObtenerModoAcceso_Anulada()
		{
			try
			{
				this.Var_EstadoAnterior="-1";

				if(this.dtpFechaLiq.Checked)			this.Var_EstadoAnterior="4";
				else if(this.dtpFechaAprob4.Checked)	this.Var_EstadoAnterior="32";
				else if(this.dtpFechaAprob3.Checked)	this.Var_EstadoAnterior="31";
				else if(this.dtpFechaReal.Checked)		this.Var_EstadoAnterior="3";
				else if(this.dtpFechaAprob2.Checked)	this.Var_EstadoAnterior="2";
				else if(this.dtpFechaAprob1.Checked)	this.Var_EstadoAnterior="1";
				else if(this.dtpFechaPrev.Checked)		this.Var_EstadoAnterior="0";

				switch(this.Var_EstadoAnterior)
				{
					case "0": if(this.Var_CargoDelegado==Configuracion.iCargoAprob2) 
								  this.ParamI_TipoAcceso="C";
						break;
					case "1": if(this.Var_CargoDelegado!=Configuracion.iCargoAprob1 && this.Var_CargoDelegado!=Configuracion.iCargoAprob2) 
								  this.ParamI_TipoAcceso="C";
						break;
					case "2": if(this.Var_CargoDelegado==Configuracion.iCargoAprob1) 
								  this.ParamI_TipoAcceso="C";
						break;
					case "3": if(this.Var_CargoDelegado==Configuracion.iCargoAprob1 && this.Var_CargoDelegado==Configuracion.iCargoAprob2) 
								  this.ParamI_TipoAcceso="C";
						break;
					case "31": if(this.Var_CargoDelegado!=Configuracion.iCargoAprob1 && this.Var_CargoDelegado!=Configuracion.iCargoAprob2) 
								   this.ParamI_TipoAcceso="C";
						break;
					case "32": if(this.Var_CargoDelegado==Configuracion.iCargoAprob1) 
								   this.ParamI_TipoAcceso="C";
						break;
					case "4": if(this.Var_CargoDelegado==Configuracion.iCargoAprob1 && this.Var_CargoDelegado==Configuracion.iCargoAprob2) 
								  this.ParamI_TipoAcceso="C";
						break;
					default: this.ParamI_TipoAcceso="C"; break;
				}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region Inicializa_TipoAtencion
		private void Inicializa_TipoAtencion()
		{
			try
			{
				this.Var_TipoAtencion="2";//Sólo se pueden dar de Alta Atenciones Manuales
				this.sqldaTipoAtencion.Fill(this.dsAtenciones1);
				for(int i=0;i<this.dsAtenciones1.ListaTipoAtencionComercial.Rows.Count;i++)
				{
					if(this.Var_TipoAtencion==this.dsAtenciones1.ListaTipoAtencionComercial.Rows[i]["sValor"].ToString())
					{
						this.txttTipoAtencion.Text=this.dsAtenciones1.ListaTipoAtencionComercial.Rows[i]["sLiteral"].ToString();
						break;
					}
				}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region Inicializar_Botonera
		private void Inicializar_Botonera()
		{
			try
			{
				this.ucBotoneraSecundaria1.btSalir.Click += new EventHandler(btSalir_Click);
				this.ucBotoneraSecundaria1.btGrabar.Click += new EventHandler(btGrabar_Click);

				if(this.ParamI_TipoAcceso=="C")//Sólo Consulta
				{
					this.ucBotoneraSecundaria1.Activar_botonera(true,false,false,false,false,false);
				}
				else
				{
					this.ucBotoneraSecundaria1.Activar_botonera(true,false,false,false,true,false);
				}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region Recuperacion de la Atención Comercial
		private void Recupera_Atencion_Comercial()
		{
			try
			{
				this.dsAtenciones1.GetAtencionComercial.Rows.Clear();

				this.sqldaGetAtencionComercial.SelectCommand.Parameters["@iIdAtencion"].Value=this.ParamI_iIdAtencion;
				this.sqldaGetAtencionComercial.Fill(this.dsAtenciones1);

				if(this.dsAtenciones1.GetAtencionComercial.Rows.Count==1)
				{
					//En altas el delegado viene fijado de configuración 
					this.txtDelegado.Text = this.dsAtenciones1.GetAtencionComercial.Rows[0]["sNombreDelegado"].ToString();

					this.txbidAtencion.Text = this.dsAtenciones1.GetAtencionComercial.Rows[0]["sIdAtencion"].ToString();
					this.txtDescripcion.Text = this.dsAtenciones1.GetAtencionComercial.Rows[0]["sDescripcion"].ToString();
					this.txtObservaciones.Text = this.dsAtenciones1.GetAtencionComercial.Rows[0]["tObservaciones"].ToString();
					this.Var_TipoAtencion= this.dsAtenciones1.GetAtencionComercial.Rows[0]["sIdTipoAtencion"].ToString();
					this.txttTipoAtencion.Text = this.dsAtenciones1.GetAtencionComercial.Rows[0]["sTipoAtencion"].ToString();
					this.cbsIdEstAtencion.SelectedValue = this.dsAtenciones1.GetAtencionComercial.Rows[0]["sIdEstAtencion"].ToString();
					this.cbCentroCoste.SelectedValue = this.dsAtenciones1.GetAtencionComercial.Rows[0]["sIdCentroCoste"].ToString();
					this.chkBolsaViaje.Checked = (bool)this.dsAtenciones1.GetAtencionComercial.Rows[0]["bBolsaViaje"];
					this.Var_iIdCliente = Int32.Parse(this.dsAtenciones1.GetAtencionComercial.Rows[0]["iIdCliente"].ToString());
					this.txtsIdCliente.Text = this.dsAtenciones1.GetAtencionComercial.Rows[0]["sIdCliente"].ToString();
					this.txtsCliente.Text = this.dsAtenciones1.GetAtencionComercial.Rows[0]["sNombreCli"].ToString();
					
					if(this.dsAtenciones1.GetAtencionComercial.Rows[0]["fImportePrev"].ToString().Length==0) this.nmrImportePrev.Value=0;
					else this.nmrImportePrev.Value = Convert.ToDecimal(Convert.ToDouble(this.dsAtenciones1.GetAtencionComercial.Rows[0]["fImportePrev"].ToString()).ToString("N2"));
					if(this.dsAtenciones1.GetAtencionComercial.Rows[0]["fImporteReal"].ToString().Length==0) this.nmrImporterReal.Value=0;
					else this.nmrImporterReal.Value = Convert.ToDecimal(Convert.ToDouble(this.dsAtenciones1.GetAtencionComercial.Rows[0]["fImporteReal"].ToString()).ToString("N2"));
					
					try{this.txtFechaCreacion.Text = ((DateTime)this.dsAtenciones1.GetAtencionComercial.Rows[0]["dFechaCreacion"]).ToString("dd/MM/yyyy");}
					catch{}

					if(this.dsAtenciones1.GetAtencionComercial.Rows[0]["dFechaPrev"].ToString().Length==0) Poner_Fecha_Nula(this.dtpFechaPrev,true);
					else this.dtpFechaPrev.Value = (DateTime)this.dsAtenciones1.GetAtencionComercial.Rows[0]["dFechaPrev"];
					if(this.dsAtenciones1.GetAtencionComercial.Rows[0]["dFechaAprob1"].ToString().Length==0) Poner_Fecha_Nula(this.dtpFechaAprob1,true);
					else this.dtpFechaAprob1.Value = (DateTime)this.dsAtenciones1.GetAtencionComercial.Rows[0]["dFechaAprob1"];
					if(this.dsAtenciones1.GetAtencionComercial.Rows[0]["dFechaAprob2"].ToString().Length==0) Poner_Fecha_Nula(this.dtpFechaAprob2,true);
					else this.dtpFechaAprob2.Value = (DateTime)this.dsAtenciones1.GetAtencionComercial.Rows[0]["dFechaAprob2"];
					if(this.dsAtenciones1.GetAtencionComercial.Rows[0]["dFechaReal"].ToString().Length==0) Poner_Fecha_Nula(this.dtpFechaReal,true);
					else this.dtpFechaReal.Value = (DateTime)this.dsAtenciones1.GetAtencionComercial.Rows[0]["dFechaReal"];
					if(this.dsAtenciones1.GetAtencionComercial.Rows[0]["dFechaAprob3"].ToString().Length==0) Poner_Fecha_Nula(this.dtpFechaAprob3,true);
					else this.dtpFechaAprob3.Value = (DateTime)this.dsAtenciones1.GetAtencionComercial.Rows[0]["dFechaAprob3"];
					if(this.dsAtenciones1.GetAtencionComercial.Rows[0]["dFechaAprob4"].ToString().Length==0) Poner_Fecha_Nula(this.dtpFechaAprob4,true);
					else this.dtpFechaAprob4.Value = (DateTime)this.dsAtenciones1.GetAtencionComercial.Rows[0]["dFechaAprob4"];
					if(this.dsAtenciones1.GetAtencionComercial.Rows[0]["dFechaLiq"].ToString().Length==0) Poner_Fecha_Nula(this.dtpFechaLiq,true);
					else this.dtpFechaLiq.Value = (DateTime)this.dsAtenciones1.GetAtencionComercial.Rows[0]["dFechaLiq"];
					if(this.dsAtenciones1.GetAtencionComercial.Rows[0]["dFechaCierre"].ToString().Length==0) Poner_Fecha_Nula(this.dtpFechaCierre,true);
					else this.dtpFechaCierre.Value = (DateTime)this.dsAtenciones1.GetAtencionComercial.Rows[0]["dFechaCierre"];
					if((bool)this.dsAtenciones1.GetAtencionComercial.Rows[0]["bEnviadoCEN"]) this.Var_EnviadoCEN=1;
					else this.Var_EnviadoCEN=0;
				}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region cbsIdEstAtencion_Leave
		private void cbsIdEstAtencion_Leave(object sender, System.EventArgs e)
		{
			try
			{
				if(this.cbsIdEstAtencion.SelectedIndex==-1)
				{
					if(this.dsAtenciones1.GetAtencionComercial.Rows.Count==1)
					{
						this.cbsIdEstAtencion.SelectedValue= this.dsAtenciones1.GetAtencionComercial.Rows[0]["sIdEstAtencion"].ToString();
					}
				}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion
	
		#region cbsIdEstAtencion_SelectedIndexChanged
		private void cbsIdEstAtencion_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				if(this.ParamI_TipoAcceso=="M")
				{
					if(this.cbsIdEstAtencion.SelectedIndex!=-1)
					{
						string Estado = this.cbsIdEstAtencion.SelectedValue.ToString();
						switch(Estado)
						{
							case "0":
								if(!this.dtpFechaPrev.Checked)Poner_Fecha_Nula(this.dtpFechaPrev,false);
								Poner_Fecha_Nula(this.dtpFechaAprob1,true);
								Poner_Fecha_Nula(this.dtpFechaAprob2,true);
								Poner_Fecha_Nula(this.dtpFechaReal,true);
								Poner_Fecha_Nula(this.dtpFechaAprob3,true);
								Poner_Fecha_Nula(this.dtpFechaAprob4,true);
								Poner_Fecha_Nula(this.dtpFechaLiq,true);
								Poner_Fecha_Nula(this.dtpFechaCierre,true);
								break;
							case "1":
								this.dtpFechaAprob1.Checked = true;
								Poner_Fecha_Nula(this.dtpFechaAprob2,true);
								Poner_Fecha_Nula(this.dtpFechaReal,true);
								Poner_Fecha_Nula(this.dtpFechaAprob3,true);
								Poner_Fecha_Nula(this.dtpFechaAprob4,true);
								Poner_Fecha_Nula(this.dtpFechaLiq,true);
								Poner_Fecha_Nula(this.dtpFechaCierre,true);
								break;
							case "2":
								this.dtpFechaAprob1.Checked = true;
								this.dtpFechaAprob2.Checked = true;
								Poner_Fecha_Nula(this.dtpFechaReal,true);
								Poner_Fecha_Nula(this.dtpFechaAprob3,true);
								Poner_Fecha_Nula(this.dtpFechaAprob4,true);
								Poner_Fecha_Nula(this.dtpFechaLiq,true);
								Poner_Fecha_Nula(this.dtpFechaCierre,true);
								break;
							case "3":
								//if(!this.dtpFechaReal.Checked) Poner_Fecha_Nula(this.dtpFechaReal,false);
								this.dtpFechaReal.Checked = true; 
								this.dtpFechaAprob1.Checked = true;
								this.dtpFechaAprob2.Checked = true;
								Poner_Fecha_Nula(this.dtpFechaAprob3,true);
								Poner_Fecha_Nula(this.dtpFechaAprob4,true);
								Poner_Fecha_Nula(this.dtpFechaLiq,true);
								Poner_Fecha_Nula(this.dtpFechaCierre,true);

								break;
							case "31":
								this.dtpFechaAprob3.Checked=true;
								this.dtpFechaReal.Checked = true; 
								this.dtpFechaAprob1.Checked = true;
								this.dtpFechaAprob2.Checked = true;
								Poner_Fecha_Nula(this.dtpFechaAprob4,true);
								Poner_Fecha_Nula(this.dtpFechaLiq,true);
								Poner_Fecha_Nula(this.dtpFechaCierre,true);

								break;
							case "32":
								this.dtpFechaAprob4.Checked=true;
								this.dtpFechaAprob3.Checked=true;
								this.dtpFechaReal.Checked = true; 
								this.dtpFechaAprob1.Checked = true;
								this.dtpFechaAprob2.Checked = true;
								Poner_Fecha_Nula(this.dtpFechaLiq,true);
								Poner_Fecha_Nula(this.dtpFechaCierre,true);

								break;
							case "4":
								if(!this.dtpFechaLiq.Checked) Poner_Fecha_Nula(this.dtpFechaLiq,false);
								this.dtpFechaAprob1.Checked = true;
								this.dtpFechaAprob2.Checked = true;
								this.dtpFechaReal.Checked = true;
								this.dtpFechaAprob3.Checked = true;
								this.dtpFechaAprob4.Checked = true;
								Poner_Fecha_Nula(this.dtpFechaCierre,true);
								break;
							case "6":
								if(this.dtpFechaReal.Enabled) Poner_Fecha_Nula(this.dtpFechaReal,true);
								if(!this.dtpFechaCierre.Checked) Poner_Fecha_Nula(this.dtpFechaCierre,false);
								this.dtpFechaAprob1.Checked = true;
								this.dtpFechaAprob2.Checked = true;
								this.dtpFechaAprob3.Checked = true;
								this.dtpFechaAprob4.Checked = true;
								this.dtpFechaLiq.Checked = true;
								break;
							default:break;
						}

					}
				}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region cbCentroCoste_Leave
		private void cbCentroCoste_Leave(object sender, System.EventArgs e)
		{
			try
			{
				if(this.cbCentroCoste.SelectedIndex==-1)
				{
					this.cbCentroCoste.SelectedValue="0";
				}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region txtsIdCliente_Leave
		private void txtsIdCliente_Leave(object sender, System.EventArgs e)
		{
			try
			{
				GESTCRM.Formularios.Busquedas.frmMClientesSAP frmBCli = new GESTCRM.Formularios.Busquedas.frmMClientesSAP(false,"A");
				
				frmBCli.ParamI_iIdDelegado = this.ParamI_iIdDelegado;
				frmBCli.ParamI_sIdCentro= "";
				frmBCli.ParamI_sIdTipoCliente="T";
				frmBCli.ParamIO_sIdCliente = this.txtsIdCliente.Text.ToString();
				
				frmBCli.Buscar_tNombre();
				
				if(this.txtsIdCliente.Text.ToString().Length>0 && frmBCli.ParamO_iIdCliente==-1) Mensajes.ShowError("Este código de Cliente no existe.");
				this.txtsIdCliente.Text=frmBCli.ParamIO_sIdCliente;
				this.txtsCliente.Text=frmBCli.ParamO_tNombre;
				this.Var_iIdCliente = frmBCli.ParamO_iIdCliente;

				frmBCli.Dispose();
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region btBuscarCliente_Click
		private void btBuscarCliente_Click(object sender, System.EventArgs e)
		{
			try
			{
				GESTCRM.Formularios.Busquedas.frmMClientesSAP frmBCli = new GESTCRM.Formularios.Busquedas.frmMClientesSAP(false,"A");
				
				frmBCli.ParamIO_sIdCliente = "";
				frmBCli.ParamI_sIdCentro = "";
				frmBCli.ParamI_sIdTipoCliente="T";
				frmBCli.ParamI_iIdDelegado = this.ParamI_iIdDelegado;

				frmBCli.ShowDialog(this);
				if (frmBCli.DialogResult==System.Windows.Forms.DialogResult.OK)
				{
					if(frmBCli.dtSeleccion.Rows.Count==0)
					{
						this.txtsIdCliente.Text=frmBCli.ParamIO_sIdCliente;
						this.txtsCliente.Text = frmBCli.ParamO_tNombre;
						this.Var_iIdCliente = frmBCli.ParamO_iIdCliente;
					}
				}
				frmBCli.Dispose();
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion
		
		//Sólo pueden crear atenciones los delegados => Cargo!=iCargoAprob1 y iCargoAprob2
		//Modificaciones
		//Cargo != iCargoApro1 y iCargoAprob2
		//	Puede Modificar si EstadoAtencion = Creada y no se ha enviado a Central 
		//		Obligatorio Informar FechaPrev, por defecto sysdate (resto de fechas no modificables)
		//		Obligatorio Informar Código (Campo sIdAtencion)
		//		Obligatorio Informar Cliente, Centro de Coste,Importe Previsto
		//		Opcionales Descripción y Observaciones
		//		Importe Real no modificable
		//	Puede Modificar si EstadoAtencion = Aprobada2/Realizada/Liquidada y no se ha enviado a Central 
		//	     Modificar el estado de Aprobada2 a Realizada 
		//			Obligatorio Informar FechaReal, por defecto sysdate (resto de fechas no modificables)
		//			Si bolsa de Viaje 
		//				Comprobar que el Cliente tiene informados los datos fiscales(NIF, dirección,CódigoPostal,Población,Provincia)
		//				si los tiene informados sacar mensaje diciendo que todo está bien
		//				sino sacar mensaje informativo
		//			Resto de campos no modificables
		//	     Modificar el estado de Aprobada2 a Anulada, Realizada a Anulada,Liquidada a Anulada
		//	         Automáticamente FechaCierre = sysdate
		//		
		//Cargo = iCargoAprob1
		//	Puede Modificar si EstadoAtencion = Creada/Aprobada1 y no se ha enviado a Central 
		//     Modificar el estado de Creada a Aprobada1
		//         Automáticamente FechaAprob1 = sysdate
		//     Modificar el estado de Creada a Anulada, Aprobada1 a Anulada
		//         Automáticamente FechaCierre = sysdate
		//		
		//Cargo = iCargoAprob2
		//	Puede Modificar si EstadoAtencion = Aprobada1/Aprobada2 y no se ha enviado a Central 
		//     Modificar el estado de Aprobada1 a Aprobada2
		//         Automáticamente FechaAprob2 = sysdate
		//     Modificar el estado de Aprobada1 a Anulada, Aprobada2 a Anulada
		//         Automáticamente FechaCierre = sysdate
		#region Inicializa_Formulario
		private void Inicializa_Formulario()
		{
			try
			{
				switch(this.ParamI_TipoAcceso)
				{
					case "A": 
						this.lblAtencionesCom.Text="Alta de una Atención Comercial";
						Inicializar_Alta();
						break;
					case "M": 
						this.lblAtencionesCom.Text="Modificación de una Atención Comercial";
						Inicializar_Modificacion();
						break;
					case "C": 
						this.lblAtencionesCom.Text="Consulta de una Atención Comercial";
						Inicializar_Consulta();
						break;
					default: break;
				}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region Poner_Fecha_Nula
		private void Poner_Fecha_Nula(DateTimePicker dtp,bool nulo)
		{
			try
			{
				if(nulo)
				{
					dtp.Format= DateTimePickerFormat.Custom;
					dtp.CustomFormat=" ";
					dtp.Checked=false;
				}
				else
				{
					dtp.CustomFormat="";
					dtp.Checked=true;
				}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region Inicializar_Alta
		private void Inicializar_Alta()
		{
			try
			{
				Poner_Fecha_Nula(this.dtpFechaAprob1,true);
				Poner_Fecha_Nula(this.dtpFechaAprob2,true);
				Poner_Fecha_Nula(this.dtpFechaReal,true);
				Poner_Fecha_Nula(this.dtpFechaAprob3,true);
				Poner_Fecha_Nula(this.dtpFechaAprob4,true);
				Poner_Fecha_Nula(this.dtpFechaLiq,true);
				Poner_Fecha_Nula(this.dtpFechaCierre,true);
				Utiles.Activar_Control(this.dtpFechaAprob1,false);
				Utiles.Activar_Control(this.dtpFechaAprob2,false);
				Utiles.Activar_Control(this.dtpFechaReal,false);
				Utiles.Activar_Control(this.dtpFechaAprob3,false);
				Utiles.Activar_Control(this.dtpFechaAprob4,false);
				Utiles.Activar_Control(this.dtpFechaLiq,false);
				Utiles.Activar_Control(this.dtpFechaCierre,false);

				this.chkBolsaViaje.Checked=false;

				this.cbsIdEstAtencion.SelectedValue="0";
				Utiles.Activar_Control(this.cbsIdEstAtencion,false);


				Utiles.Activar_Control(this.nmrImporterReal,false);
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region Inicializar_Modificacion

		private void Inicializar_Modificacion()
		{
			try
			{
				if(this.ParamI_TipoAcceso=="M")
				{
					switch(this.cbsIdEstAtencion.SelectedValue.ToString())
					{
						case "0": Inicializa_Modif_Creada();break;
						case "1": Inicializa_Modif_Aprobada1();break;
						case "2": Inicializa_Modif_Aprobada2();break;
						case "3": Inicializa_Modif_Realizada();break;
						case "31": Inicializa_Modif_Aprobada3();break;
						case "32": Inicializa_Modif_Aprobada4();break;
						case "4": Inicializa_Modif_Liquidada();break;
						case "6": Inicializa_Modif_Anulada();break;
						default: break;
					}
				}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#region Inicializa_Modif_Creada
		private void Inicializa_Modif_Creada()
		{
			try
			{
				if(this.Var_CargoDelegado == Configuracion.iCargoAprob1)
				{
					for(int i=this.dsAtenciones1.ListaTipoEstadoAtencion.Rows.Count-1;i>=0;i--)
					{
						if(this.dsAtenciones1.ListaTipoEstadoAtencion.Rows[i]["sValor"].ToString()!="0" &&
							this.dsAtenciones1.ListaTipoEstadoAtencion.Rows[i]["sValor"].ToString()!="1" &&
							this.dsAtenciones1.ListaTipoEstadoAtencion.Rows[i]["sValor"].ToString()!="6")
						{
							this.dsAtenciones1.ListaTipoEstadoAtencion.Rows.RemoveAt(i);
						}
					}

					Utiles.Activar_Panel(this.pnAtencion,false);
					//ricky
                    //---- GSG (11/04/2012)
					//dgProductos.ReadOnly = true;
                    dgProductosView.ReadOnly = true;
                    //---- GSG (25/05/2012)
                    dgProductosView.Enabled = true;
                    dgProductosView.Sort(dgProductosView.Columns[0], ListSortDirection.Descending); 
					//---- FI GSG
                    Utiles.Activar_Control(this.cbsIdEstAtencion,true);
				}
				else //Delegado
				{
					Utiles.Activar_Control(this.dtpFechaAprob1,false);
					Utiles.Activar_Control(this.dtpFechaAprob2,false);
					Utiles.Activar_Control(this.dtpFechaReal,false);
					Utiles.Activar_Control(this.dtpFechaAprob3,false);
					Utiles.Activar_Control(this.dtpFechaAprob4,false);
					Utiles.Activar_Control(this.dtpFechaLiq,false);
					Utiles.Activar_Control(this.dtpFechaCierre,false);

					Utiles.Activar_Control(this.txbidAtencion,false);

					Utiles.Activar_Control(this.cbsIdEstAtencion,false);

					Utiles.Activar_Control(this.nmrImporterReal,false);
				}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion
		
		#region Inicializa_Modif_Aprobada1
		private void Inicializa_Modif_Aprobada1()
		{
			try
			{
				//				if(this.Var_CargoDelegado == Configuracion.iCargoAprob1)
				//				{
				//					for(int i=this.dsAtenciones1.ListaTipoEstadoAtencion.Rows.Count-1;i>=0;i--)
				//					{
				//						if(	this.dsAtenciones1.ListaTipoEstadoAtencion.Rows[i]["sValor"].ToString()!="0" &&
				//							this.dsAtenciones1.ListaTipoEstadoAtencion.Rows[i]["sValor"].ToString()!="1" &&
				//							this.dsAtenciones1.ListaTipoEstadoAtencion.Rows[i]["sValor"].ToString()!="6")
				//						{
				//							this.dsAtenciones1.ListaTipoEstadoAtencion.Rows.RemoveAt(i);
				//						}
				//					}
				//				
				//					Utiles.Activar_Panel(this.pnAtencion,false);
				//					Utiles.Activar_Control(this.cbsIdEstAtencion,true);
				//				}
				//				else //Aprobador2
				//				{
				for(int i=this.dsAtenciones1.ListaTipoEstadoAtencion.Rows.Count-1;i>=0;i--)
				{
					if(this.dsAtenciones1.ListaTipoEstadoAtencion.Rows[i]["sValor"].ToString()!="1" &&
						this.dsAtenciones1.ListaTipoEstadoAtencion.Rows[i]["sValor"].ToString()!="2" &&
						this.dsAtenciones1.ListaTipoEstadoAtencion.Rows[i]["sValor"].ToString()!="6")
					{
						this.dsAtenciones1.ListaTipoEstadoAtencion.Rows.RemoveAt(i);
					}
				}

				Utiles.Activar_Panel(this.pnAtencion,false);
				//ricky
                //---- GSG (11/04/2012)
                //dgProductos.ReadOnly = true;
                dgProductosView.ReadOnly = true;
                //---- GSG (25/05/2012)
                dgProductosView.Enabled = true;
                dgProductosView.Sort(dgProductosView.Columns[0], ListSortDirection.Descending); 
                //---- FI GSG
				Utiles.Activar_Control(this.cbsIdEstAtencion,true);
				//				}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region Inicializa_Modif_Aprobada2
		private void Inicializa_Modif_Aprobada2()
		{
			try
			{
				//				if(this.Var_CargoDelegado == Configuracion.iCargoAprob2)
				//				{
				//					for(int i=this.dsAtenciones1.ListaTipoEstadoAtencion.Rows.Count-1;i>=0;i--)
				//					{
				//						if(	this.dsAtenciones1.ListaTipoEstadoAtencion.Rows[i]["sValor"].ToString()!="1" &&
				//							this.dsAtenciones1.ListaTipoEstadoAtencion.Rows[i]["sValor"].ToString()!="2" &&
				//							this.dsAtenciones1.ListaTipoEstadoAtencion.Rows[i]["sValor"].ToString()!="6")
				//						{
				//							this.dsAtenciones1.ListaTipoEstadoAtencion.Rows.RemoveAt(i);
				//						}
				//					}
				//
				//					Utiles.Activar_Panel(this.pnAtencion,false);
				//					Utiles.Activar_Control(this.cbsIdEstAtencion,true);
				//				}
				//				else //Delegado
				//				{
				for(int i=this.dsAtenciones1.ListaTipoEstadoAtencion.Rows.Count-1;i>=0;i--)
				{
					if(this.dsAtenciones1.ListaTipoEstadoAtencion.Rows[i]["sValor"].ToString()!="2" &&
						this.dsAtenciones1.ListaTipoEstadoAtencion.Rows[i]["sValor"].ToString()!="3" &&
						this.dsAtenciones1.ListaTipoEstadoAtencion.Rows[i]["sValor"].ToString()!="6")
					{
						this.dsAtenciones1.ListaTipoEstadoAtencion.Rows.RemoveAt(i);
					}
				}
				
				Utiles.Activar_Panel(this.pnAtencion,false);
				//ricky
                //---- GSG (11/04/2012)
                //dgProductos.ReadOnly = true;
                dgProductosView.ReadOnly = true;
                //---- GSG (25/05/2012)
                dgProductosView.Enabled = true;
                dgProductosView.Sort(dgProductosView.Columns[0], ListSortDirection.Descending); 
                //---- FI GSG
				Utiles.Activar_Control(this.cbsIdEstAtencion,true);
				Utiles.Activar_Control(this.dtpFechaReal,false);
				//				}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion
		
		#region Inicializa_Modif_Realizada
		private void Inicializa_Modif_Realizada()
		{
			try
			{
				//Sólo delegados
				for(int i=this.dsAtenciones1.ListaTipoEstadoAtencion.Rows.Count-1;i>=0;i--)
				{
					if(	this.dsAtenciones1.ListaTipoEstadoAtencion.Rows[i]["sValor"].ToString()!="3" &&
						this.dsAtenciones1.ListaTipoEstadoAtencion.Rows[i]["sValor"].ToString()!="31" &&
						this.dsAtenciones1.ListaTipoEstadoAtencion.Rows[i]["sValor"].ToString()!="6")
					{
						this.dsAtenciones1.ListaTipoEstadoAtencion.Rows.RemoveAt(i);
					}
				}

				Utiles.Activar_Panel(this.pnAtencion,false);
				//ricky
                //---- GSG (11/04/2012)
                //dgProductos.ReadOnly = true;
                dgProductosView.ReadOnly = true;
                //---- GSG (25/05/2012)
                dgProductosView.Enabled = true;
                dgProductosView.Sort(dgProductosView.Columns[0], ListSortDirection.Descending); 
                //---- FI GSG
				Utiles.Activar_Control(this.cbsIdEstAtencion,true);
				Utiles.Activar_Control(this.dtpFechaReal,false);
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region Inicializa_Modif_Aprobada3
		private void Inicializa_Modif_Aprobada3()
		{
			try
			{
				//				if(this.Var_CargoDelegado == Configuracion.iCargoAprob1)
				//				{
				//					for(int i=this.dsAtenciones1.ListaTipoEstadoAtencion.Rows.Count-1;i>=0;i--)
				//					{
				//						if(	this.dsAtenciones1.ListaTipoEstadoAtencion.Rows[i]["sValor"].ToString()!="0" &&
				//							this.dsAtenciones1.ListaTipoEstadoAtencion.Rows[i]["sValor"].ToString()!="1" &&
				//							this.dsAtenciones1.ListaTipoEstadoAtencion.Rows[i]["sValor"].ToString()!="6")
				//						{
				//							this.dsAtenciones1.ListaTipoEstadoAtencion.Rows.RemoveAt(i);
				//						}
				//					}
				//				
				//					Utiles.Activar_Panel(this.pnAtencion,false);
				//					Utiles.Activar_Control(this.cbsIdEstAtencion,true);
				//				}
				//				else //Aprobador2
				//				{
				for(int i=this.dsAtenciones1.ListaTipoEstadoAtencion.Rows.Count-1;i>=0;i--)
				{
					if(this.dsAtenciones1.ListaTipoEstadoAtencion.Rows[i]["sValor"].ToString()!="31" &&
						this.dsAtenciones1.ListaTipoEstadoAtencion.Rows[i]["sValor"].ToString()!="32" &&
						this.dsAtenciones1.ListaTipoEstadoAtencion.Rows[i]["sValor"].ToString()!="6")
					{
						this.dsAtenciones1.ListaTipoEstadoAtencion.Rows.RemoveAt(i);
					}
				}

				Utiles.Activar_Panel(this.pnAtencion,false);
				//ricky
                //---- GSG (11/04/2012)
                //dgProductos.ReadOnly = true;
                dgProductosView.ReadOnly = true;
                //---- GSG (25/05/2012)
                dgProductosView.Enabled = true;
                dgProductosView.Sort(dgProductosView.Columns[0], ListSortDirection.Descending); 
                //---- FI GSG
				Utiles.Activar_Control(this.cbsIdEstAtencion,true);
				//				}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region Inicializa_Modif_Aprobada4
		private void Inicializa_Modif_Aprobada4()
		{
			try
			{
				//				if(this.Var_CargoDelegado == Configuracion.iCargoAprob2)
				//				{
				//					for(int i=this.dsAtenciones1.ListaTipoEstadoAtencion.Rows.Count-1;i>=0;i--)
				//					{
				//						if(	this.dsAtenciones1.ListaTipoEstadoAtencion.Rows[i]["sValor"].ToString()!="1" &&
				//							this.dsAtenciones1.ListaTipoEstadoAtencion.Rows[i]["sValor"].ToString()!="2" &&
				//							this.dsAtenciones1.ListaTipoEstadoAtencion.Rows[i]["sValor"].ToString()!="6")
				//						{
				//							this.dsAtenciones1.ListaTipoEstadoAtencion.Rows.RemoveAt(i);
				//						}
				//					}
				//
				//					Utiles.Activar_Panel(this.pnAtencion,false);
				//					Utiles.Activar_Control(this.cbsIdEstAtencion,true);
				//				}
				//				else //Delegado
				//				{
				for(int i=this.dsAtenciones1.ListaTipoEstadoAtencion.Rows.Count-1;i>=0;i--)
				{
					if(this.dsAtenciones1.ListaTipoEstadoAtencion.Rows[i]["sValor"].ToString()!="32" &&						
						this.dsAtenciones1.ListaTipoEstadoAtencion.Rows[i]["sValor"].ToString()!="6")
					{
						this.dsAtenciones1.ListaTipoEstadoAtencion.Rows.RemoveAt(i);
					}
				}
				
				Utiles.Activar_Panel(this.pnAtencion,false);
				//ricky
                //---- GSG (11/04/2012)
                //dgProductos.ReadOnly = true;
                dgProductosView.ReadOnly = true;
                //---- GSG (25/05/2012)
                dgProductosView.Enabled = true;
                dgProductosView.Sort(dgProductosView.Columns[0], ListSortDirection.Descending); 
                //---- FI GSG
				Utiles.Activar_Control(this.cbsIdEstAtencion,true);
				Utiles.Activar_Control(this.dtpFechaReal,false);
				//				}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region Inicializa_Modif_Liquidada
		private void Inicializa_Modif_Liquidada()
		{
			try
			{
				//Sólo Delegados
				for(int i=this.dsAtenciones1.ListaTipoEstadoAtencion.Rows.Count-1;i>=0;i--)
				{
					if(this.dsAtenciones1.ListaTipoEstadoAtencion.Rows[i]["sValor"].ToString()!="4" &&
						this.dsAtenciones1.ListaTipoEstadoAtencion.Rows[i]["sValor"].ToString()!="6")
					{
						this.dsAtenciones1.ListaTipoEstadoAtencion.Rows.RemoveAt(i);
					}
				}

				Utiles.Activar_Panel(this.pnAtencion,false);
				//ricky
                //---- GSG (11/04/2012)
                //dgProductos.ReadOnly = true;
                dgProductosView.ReadOnly = true;
                //---- GSG (25/05/2012)
                dgProductosView.Enabled = true;
                dgProductosView.Sort(dgProductosView.Columns[0], ListSortDirection.Descending); 
                //---- FI GSG
				Utiles.Activar_Control(this.cbsIdEstAtencion,true);
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region Inicializa_Modif_Anulada
		private void Inicializa_Modif_Anulada()
		{
//			switch(this.Var_EstadoAnterior)
//			{
//				case "0": Inicializa_Modif_Creada();break;
//				case "1": Inicializa_Modif_Aprobada1();break;
//				case "2": Inicializa_Modif_Aprobada2();break;
//				case "3": Inicializa_Modif_Realizada();break;
//				case "31": Inicializa_Modif_Aprobada3();break;
//				case "32": Inicializa_Modif_Aprobada4();break;
//				case "4": Inicializa_Modif_Liquidada();break;
//				default: Utiles.Activar_Panel(this.pnAtencion,false);
//						 //ricky
//						 dgProductos.ReadOnly = true;
//					break;
//			}

			try
			{
				//Sólo Delegados
				for(int i=this.dsAtenciones1.ListaTipoEstadoAtencion.Rows.Count-1;i>=0;i--)
				{
					if(this.dsAtenciones1.ListaTipoEstadoAtencion.Rows[i]["sValor"].ToString()!="6") 
					{
						this.dsAtenciones1.ListaTipoEstadoAtencion.Rows.RemoveAt(i);
					}
				}

				Utiles.Activar_Panel(this.pnAtencion,false);
				//ricky
                //---- GSG (11/04/2012)
                //dgProductos.ReadOnly = true;
                dgProductosView.ReadOnly = true;
                //---- FI GSG
				Utiles.Activar_Control(this.cbsIdEstAtencion,true);
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
			#endregion

		}
		#endregion

		#region Inicializar_Consulta()
		private void Inicializar_Consulta()
		{
			try
			{
				Utiles.Activar_Panel(this.pnAtencion,false);
				//ricky
				//---- GSG (11/04/2012)
				//dgProductos.ReadOnly = true;
                dgProductosView.ReadOnly = true;
                //---- GSG (25/05/2012)
                dgProductosView.Enabled = true;
                dgProductosView.Sort(dgProductosView.Columns[0], ListSortDirection.Descending); 
				//---- FI GSG
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion
		
		#region btSalir_Click
		private void btSalir_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
		#endregion

		#region frmAtenciones_Closing
		private void frmAtenciones_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			try
			{
				if(this.ParamI_TipoAcceso!="C" && !SalirDesdeGuardar)
				{
					DialogResult dr1=Mensajes.ShowQuestion(3002);
					if(dr1 == System.Windows.Forms.DialogResult.Yes)
					{
						if(Validar_Atencion())
						{
							if (Grabar_Atencion())
							{
								Mensajes.ShowInformation(3004);
							}
							else
							{
								e.Cancel=true;
							}
						}
						else
						{
							e.Cancel=true;
						}
					}
				}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region frmAtenciones_Closed
		private void frmAtenciones_Closed(object sender, System.EventArgs e)
		{
			this.Dispose();
		}
		#endregion
		
		#region btGrabar_Click
		private void btGrabar_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(Validar_Atencion())
				{
					if (Grabar_Atencion())
					{

						GrabarProductos();


						//						DialogResult dr;
						//						if(this.ParamI_TipoAcceso=="A")
						//						{
						//							dr=Mensajes.ShowQuestion("Se ha dado de alta correctamente la Atención Comercial con código: "+this.txbidAtencion.Text.ToString()+". ¿Desea salir?");
						//						}
						//						else
						//						{
						//							dr = Mensajes.ShowQuestion(3003);
						//						}
						//						if(dr == System.Windows.Forms.DialogResult.No)
						//						{
						//							if(this.ParamI_TipoAcceso=="A")
						//							{
						//								this.ParamI_TipoAcceso="M";
						//								Recupera_Atencion_Comercial(); 
						//							}
						//						}
						//						else//Quiere Salir
						//						{
						this.SalirDesdeGuardar=true;
						this.Close();
						//						}
					}//del Grabar
				}//del Validar
			}//del try
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}

		private void GrabarProductos()
		{

			if (sqlConn.State != ConnectionState.Open)
				sqlConn.Open();

			foreach(GESTCRM.Formularios.DataSets.dsAtenciones.GetAtencionesAllProductoRow Row in dsAtenciones1.GetAtencionesAllProducto.Rows)
			{
				
				sqldaAtencionesProductos.InsertCommand.Parameters["@piIdAtencion"].Value = ParamI_iIdAtencion;
				sqldaAtencionesProductos.InsertCommand.Parameters["@psIdProducto"].Value = Row.sIdProducto;

				if (Row.IsbSeleccionatNull() || !Row.bSeleccionat)
				{
					sqldaAtencionesProductos.InsertCommand.Parameters["@fPorcentaje"].Value = DBNull.Value;
				}
				else 
				{
					if (Row.IsfPorcentajeNull())
						sqldaAtencionesProductos.InsertCommand.Parameters["@fPorcentaje"].Value = DBNull.Value;
					else 
						sqldaAtencionesProductos.InsertCommand.Parameters["@fPorcentaje"].Value = Row.fPorcentaje;
				}

				sqldaAtencionesProductos.InsertCommand.ExecuteNonQuery();

			}

		}

		#endregion

		#region Validar_Atencion

		private bool SonCorrectosLosProductos()
		{
			bool bRet = true;

			foreach(GESTCRM.Formularios.DataSets.dsAtenciones.GetAtencionesAllProductoRow Row in dsAtenciones1.GetAtencionesAllProducto.Rows)
			{
				if (Row.bSeleccionat && Row.IsfPorcentajeNull())
				{
					bRet = false;
					break;
				}	
			}

			return bRet;

		}

		private bool SonCorrectosLosPorcentajesDeLosProductos()
		{
			bool bRet = true;

			foreach(GESTCRM.Formularios.DataSets.dsAtenciones.GetAtencionesAllProductoRow Row in dsAtenciones1.GetAtencionesAllProducto.Rows)
			{
				if (!Row.IsfPorcentajeNull() && (Row.fPorcentaje > 100 || Row.fPorcentaje < 0))
				{
					bRet = false;
					break;
				}	
			}

			return bRet;

		}

		private bool Validar_Atencion()
		{
			try
			{
				if(this.cbsIdEstAtencion.SelectedIndex==-1)
				{
					Mensajes.ShowError("Estado de Atención Obligatorio");
					return false;
				}
				if(this.cbCentroCoste.SelectedIndex==-1)
				{
					Mensajes.ShowError("Centro de Coste de Atención Obligatorio");
					return false;
				}
				if(this.Var_iIdCliente==-1)
				{
					Mensajes.ShowError("Cliente de Atención Obligatorio");
					return false;
				}
				if(!this.dtpFechaPrev.Checked)
				{
					Mensajes.ShowError("Fecha Prevista de Atención Obligatorio");
					return false;
				}

				if (!SonCorrectosLosProductos())
				{
					Mensajes.ShowError("Ha seleccionado algun producto sin asignarle un porcentaje.");
					return false;
				}
				if (!SonCorrectosLosPorcentajesDeLosProductos())
				{
					Mensajes.ShowError("Ha puesto algun porcentaje superior a 100 o inferior a 0.");
					return false;
				}

				if(this.cbsIdEstAtencion.SelectedValue.ToString()=="3")
				{
					if(!this.dtpFechaReal.Checked)
					{
						Mensajes.ShowError("Fecha Real de Atención Obligatorio");
						return false;
					}
					if(this.chkBolsaViaje.Checked)
					{
						this.dsAtenciones1.GetDatosFiscalesCliente.Rows.Clear();
						this.sqldaGetDatosFiscalesCliente.SelectCommand.Parameters["@iIdCliente"].Value=this.Var_iIdCliente;
						this.sqldaGetDatosFiscalesCliente.Fill(this.dsAtenciones1);
						if(this.dsAtenciones1.GetDatosFiscalesCliente.Rows.Count==1)
						{
							string sNIF = this.dsAtenciones1.GetDatosFiscalesCliente.Rows[0]["sNIF"].ToString();
							string sCodPostal = this.dsAtenciones1.GetDatosFiscalesCliente.Rows[0]["sCodPostal"].ToString();
							string sProvincia = this.dsAtenciones1.GetDatosFiscalesCliente.Rows[0]["sProvincia"].ToString();
							string sPoblacion = this.dsAtenciones1.GetDatosFiscalesCliente.Rows[0]["sPoblacion"].ToString();

							int lNIF = sNIF.Length;
							int lCodPostal = sCodPostal.Length;
							int lProvincia = sProvincia.Length;
							int lPoblacion = sPoblacion.Length;

							if(lNIF>0 && lCodPostal>0 && lProvincia >0 && lPoblacion >0)
							{
								Mensajes.ShowInformation("Datos fiscales de Cliente encontrados. NIF = "+sNIF+" , C.P. = "+sCodPostal+" , Provincia = "+sProvincia+" , Poblacion = "+sPoblacion+". Atención Comercial lista para aprobación final.");
								return true;
							}
							else
							{
								Mensajes.ShowInformation("Datos fiscales de Cliente no están completos. NIF = "+sNIF+" , C.P. = "+sCodPostal+" , Provincia = "+sProvincia+" , Poblacion = "+sPoblacion+". Informe a Central vía correo electrónico de los datos fiscales que falten.");
								return true;
							}
						}
						else
						{
							Mensajes.ShowInformation("Datos fiscales de Cliente no están completos. NIF =  , C.P. =  , Provincia =  , Poblacion = . Informe a Central vía correo electrónico de los datos fiscales que falten.");
							return true;
						}
					}
				}
			}

			catch(Exception ex){Mensajes.ShowError(ex.Message);return false;}

			return true;
		}
		#endregion

		#region Grabar_Atencion
		private bool Grabar_Atencion()
		{
			bool	 resultado		= true;
			int		 Accion			= Utiles.Transformar_TipoAcceso(this.ParamI_TipoAcceso);
			int		 iIdAtencion	= this.ParamI_iIdAtencion;
			string	 sIdAtencionTemp= null;
			string	 sUsuAprob1		= null;
			string	 sUsuAprob2		= null;
			string	 sUsuAprob3		= null;
			string	 sUsuAprob4		= null;
			string   dFechaPrev		= null;
			string   dFechaAprob1	= null;
			string   dFechaAprob2	= null;
			string   dFechaReal		= null;
			string   dFechaAprob3	= null;
			string   dFechaAprob4	= null;
			string   dFechaLiq		= null;
			string	 sMensj			= "";
			string   sResultado		= "";

			if(this.ParamI_iIdAtencion!=-1)
			{
				sIdAtencionTemp = this.dsAtenciones1.GetAtencionComercial.Rows[0]["sIdAtencion"].ToString();
			}
			
			if(this.dtpFechaPrev.Checked) dFechaPrev = this.dtpFechaPrev.Value.ToString("dd/MM/yyyy");
			if(this.dtpFechaAprob1.Checked) dFechaAprob1 = this.dtpFechaAprob1.Value.ToString("dd/MM/yyyy");
			if(this.dtpFechaAprob2.Checked) dFechaAprob2 = this.dtpFechaAprob2.Value.ToString("dd/MM/yyyy");
			if(this.dtpFechaReal.Checked) dFechaReal = this.dtpFechaReal.Value.ToString("dd/MM/yyyy");
			if(this.dtpFechaAprob3.Checked) dFechaAprob3 = this.dtpFechaAprob3.Value.ToString("dd/MM/yyyy");
			if(this.dtpFechaAprob4.Checked) dFechaAprob4 = this.dtpFechaAprob4.Value.ToString("dd/MM/yyyy");
			if(this.dtpFechaLiq.Checked) dFechaLiq = this.dtpFechaLiq.Value.ToString("dd/MM/yyyy");

			if(this.cbsIdEstAtencion.SelectedValue.ToString()=="0")
			{
				sUsuAprob1=null;
				sUsuAprob2=null;
				sUsuAprob3=null;
				sUsuAprob4=null;
			}
			else if(this.cbsIdEstAtencion.SelectedValue.ToString()=="1")
			{
				sUsuAprob1 = this.Var_sUsuario;
			}
			else if(this.cbsIdEstAtencion.SelectedValue.ToString()=="2")
			{
				sUsuAprob1 = this.dsAtenciones1.GetAtencionComercial.Rows[0]["sUsuAprob1"].ToString();
				sUsuAprob2 = this.Var_sUsuario;
			}
			else if(this.cbsIdEstAtencion.SelectedValue.ToString()=="31")
			{
				sUsuAprob1 = this.dsAtenciones1.GetAtencionComercial.Rows[0]["sUsuAprob1"].ToString();
				sUsuAprob2 = this.dsAtenciones1.GetAtencionComercial.Rows[0]["sUsuAprob2"].ToString();;
				sUsuAprob3 = this.Var_sUsuario;
			}
			else if(this.cbsIdEstAtencion.SelectedValue.ToString()=="32")
			{
				sUsuAprob1 = this.dsAtenciones1.GetAtencionComercial.Rows[0]["sUsuAprob1"].ToString();
				sUsuAprob2 = this.dsAtenciones1.GetAtencionComercial.Rows[0]["sUsuAprob2"].ToString();;
				sUsuAprob3 = this.dsAtenciones1.GetAtencionComercial.Rows[0]["sUsuAprob3"].ToString();;
				sUsuAprob4 = this.Var_sUsuario;
			}
			else
			{
				sUsuAprob1 = this.dsAtenciones1.GetAtencionComercial.Rows[0]["sUsuAprob1"].ToString();
				sUsuAprob2 = this.dsAtenciones1.GetAtencionComercial.Rows[0]["sUsuAprob2"].ToString();
				sUsuAprob3 = this.dsAtenciones1.GetAtencionComercial.Rows[0]["sUsuAprob3"].ToString();;
				sUsuAprob4 = this.dsAtenciones1.GetAtencionComercial.Rows[0]["sUsuAprob4"].ToString();;
			}


            //---- GSG (10/09/2014)
            //sqlConn.Open();
            if (sqlConn.State == ConnectionState.Closed)
                sqlConn.Open();



			this.sqlTran = this.sqlConn.BeginTransaction();

			this.sqlCmdSetAtencionesComerciales.Transaction = this.sqlTran;
			
			try
			{
				this.sqlCmdSetAtencionesComerciales.Parameters["@iAccion"].Value		= Accion;
				this.sqlCmdSetAtencionesComerciales.Parameters["@iIdAtencion"].Value	= this.ParamI_iIdAtencion;
				this.sqlCmdSetAtencionesComerciales.Parameters["@sIdAtencionTemp"].Value= sIdAtencionTemp;
				this.sqlCmdSetAtencionesComerciales.Parameters["@sIdAtencion"].Value	= this.txbidAtencion.Text.ToString();
				this.sqlCmdSetAtencionesComerciales.Parameters["@iIdDelegado"].Value	= this.ParamI_iIdDelegado;
				this.sqlCmdSetAtencionesComerciales.Parameters["@sIdEstAtencion"].Value	= this.cbsIdEstAtencion.SelectedValue.ToString();
				this.sqlCmdSetAtencionesComerciales.Parameters["@sIdTipoAtencion"].Value= this.Var_TipoAtencion;
				this.sqlCmdSetAtencionesComerciales.Parameters["@sIdCentroCoste"].Value	= this.cbCentroCoste.SelectedValue.ToString();
				this.sqlCmdSetAtencionesComerciales.Parameters["@sDescripcion"].Value	= this.txtDescripcion.Text.ToString();
				this.sqlCmdSetAtencionesComerciales.Parameters["@tObservaciones"].Value	= this.txtObservaciones.Text.ToString();
				this.sqlCmdSetAtencionesComerciales.Parameters["@dFechaPrev"].Value		= dFechaPrev;
				this.sqlCmdSetAtencionesComerciales.Parameters["@dFechaAprob1"].Value	= dFechaAprob1;	
				this.sqlCmdSetAtencionesComerciales.Parameters["@dFechaAprob2"].Value	= dFechaAprob2;
				this.sqlCmdSetAtencionesComerciales.Parameters["@dFechaReal"].Value		= dFechaReal;
				this.sqlCmdSetAtencionesComerciales.Parameters["@dFechaLiq"].Value		= dFechaLiq;
				this.sqlCmdSetAtencionesComerciales.Parameters["@dFechaAprob3"].Value	= dFechaAprob3;	
				this.sqlCmdSetAtencionesComerciales.Parameters["@dFechaAprob4"].Value	= dFechaAprob4;
				this.sqlCmdSetAtencionesComerciales.Parameters["@fImportePrev"].Value	= this.nmrImportePrev.Value;
				this.sqlCmdSetAtencionesComerciales.Parameters["@bBolsaViaje"].Value	= this.chkBolsaViaje.Checked;
				this.sqlCmdSetAtencionesComerciales.Parameters["@sUsuAprob1"].Value		= sUsuAprob1;
				this.sqlCmdSetAtencionesComerciales.Parameters["@sUsuAprob2"].Value		= sUsuAprob2;
				this.sqlCmdSetAtencionesComerciales.Parameters["@iIdCliente"].Value		= this.Var_iIdCliente;
				this.sqlCmdSetAtencionesComerciales.Parameters["@bEnviadoCEN"].Value	= this.Var_EnviadoCEN;
				
				this.sqlCmdSetAtencionesComerciales.ExecuteNonQuery();
 				
				if(Accion==0) 
				{
					sResultado = this.sqlCmdSetAtencionesComerciales.Parameters["@Res"].Value.ToString();
					if(sResultado=="Existe")
					{
						Mensajes.ShowError("Código de Atención Comercial ya existe");
						this.sqlTran.Rollback();
						resultado=false;
					}
					else
					{
						iIdAtencion = Int32.Parse(this.sqlCmdSetAtencionesComerciales.Parameters["@iIdAtencion"].Value.ToString());
						sIdAtencionTemp = this.sqlCmdSetAtencionesComerciales.Parameters["@sIdAtencionTemp"].Value.ToString();
						this.ParamI_iIdAtencion = iIdAtencion;
						this.txbidAtencion.Text = sIdAtencionTemp;
						this.sqlTran.Commit();
						resultado=true;
					}
				}
				else
				{
					this.sqlTran.Commit();
					resultado=true;
				}
			}
			catch(System.Data.SqlClient.SqlException ex)
			{
				sMensj ="Error al actualizar Atención Comercial: ";
				foreach(System.Data.SqlClient.SqlError Err in ex.Errors)
				{
					if (Err.Number == 2627)
					{
						sMensj += "Código ya existente";
						break;
					}
					if (Err.Number != 3621)
					{
						sMensj +=Err.Number.ToString()+" - "+Err.Message.ToString();
					}
				}

				Mensajes.ShowError(sMensj);
				this.sqlTran.Rollback();
				resultado=false;
			}
			catch(Exception e)
			{
				Mensajes.ShowError(e.Message);
				this.sqlTran.Rollback();
				resultado=false;
			}


			this.sqlConn.Close();
			return resultado;
		}

		#endregion

	}
}

