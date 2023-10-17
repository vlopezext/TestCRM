using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using GESTCRM.CRMControles;

namespace GESTCRM.Formularios
{
	/// <summary>
	/// Descripción breve de ConsultaEncuestas.
	/// </summary>
	public class frmConsultaEncuestas : System.Windows.Forms.Form
	{
        private System.Data.SqlClient.SqlConnection sqlConn;

        private GESTCRM.Controles.ucBotoneraSecundaria ucBotoneraSecundaria1;

        private Panel pnlBClientes;
        private Panel pnResultados;
        private Panel pnHechas;
        private Panel pnPendientes;

        private System.Windows.Forms.Label lblDelegado;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblCodSAP;
        private System.Windows.Forms.Label lblClasificacion;
        private System.Windows.Forms.Label lblEncuesta;


        private System.Windows.Forms.ComboBox cbDelegado;
        private System.Windows.Forms.TextBox txtsIdCliente;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.ComboBox cbClasificacion;
        private ComboBox cbEncuesta;

        private GESTCRM.Controles.LabelGradient lblTitulo;
        private Controles.LabelGradient labelGradientPendientes;
        private Controles.LabelGradient lblGradientHechas;
        private Label lblNumPendientes;
        private Label lblNumRealizadas;

        private System.Windows.Forms.Button btBuscar;

        private GESTCRM.Formularios.DataSets.dsClientes dsClientes1;
        private DataSets.dsEncuestas dsEncuestas1;

        private System.Data.SqlClient.SqlDataAdapter sqldaListaDelegados;
        private System.Data.SqlClient.SqlCommand sqlSelectCmdDelegados;

        private System.Data.SqlClient.SqlDataAdapter sqldaListaTipoClasificacion;
        private System.Data.SqlClient.SqlCommand sqlSelectCmdClasificacion;

        private System.Data.SqlClient.SqlDataAdapter sqldaListaEstado;
        private System.Data.SqlClient.SqlCommand sqlCmdEstados;

        private System.Data.SqlClient.SqlDataAdapter sqldaListaEncuestasActivas;
        private System.Data.SqlClient.SqlCommand sqlCmdEncuestasActivas;

        private System.Data.SqlClient.SqlDataAdapter sqldaListaClientesRealizada;
        private System.Data.SqlClient.SqlCommand sqlSelectCmdRealizada;
        private DataGridView dGVRealizada;
        private DataGridViewTextBoxColumn idEncuestaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn sDescripcionDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn iIdDelegadoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn sIdClienteDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn sNombreDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn sClasificacionDataGridViewTextBoxColumn;
        private DataGridView dGVPendiente;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.ComponentModel.IContainer components;

        private string _sCodSAP = "";

        private Color _SelectionColor = Color.FromArgb(255, 90, 90);
        private Color _DefaultColor = Color.FromArgb(255, 255, 255);

        private const int _K_GRID_REALIZADA = 1;
        private Panel pnSeleccionado;
        private Label lblSeleccionado;
        private Label label1;
        private Label lblNombreSel;
        private const int _K_GRID_PENDIENTE = 2;

        public frmConsultaEncuestas()
		{
            InitializeComponent();


            //---- GSG (06/03/2021)
            Utiles.GetConfigConnection();
            this.sqlConn.ConnectionString = Utiles._connection.ConnectionString.ToString();

            
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsultaEncuestas));
            this.pnlBClientes = new System.Windows.Forms.Panel();
            this.pnSeleccionado = new System.Windows.Forms.Panel();
            this.lblSeleccionado = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbEncuesta = new System.Windows.Forms.ComboBox();
            this.dsEncuestas1 = new GESTCRM.Formularios.DataSets.dsEncuestas();
            this.lblEncuesta = new System.Windows.Forms.Label();
            this.lblTitulo = new GESTCRM.Controles.LabelGradient();
            this.cbClasificacion = new System.Windows.Forms.ComboBox();
            this.dsClientes1 = new GESTCRM.Formularios.DataSets.dsClientes();
            this.txtsIdCliente = new System.Windows.Forms.TextBox();
            this.lblClasificacion = new System.Windows.Forms.Label();
            this.cbDelegado = new System.Windows.Forms.ComboBox();
            this.btBuscar = new System.Windows.Forms.Button();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblDelegado = new System.Windows.Forms.Label();
            this.lblCodSAP = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.sqlConn = new System.Data.SqlClient.SqlConnection();
            this.sqldaListaDelegados = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCmdDelegados = new System.Data.SqlClient.SqlCommand();
            this.sqldaListaTipoClasificacion = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCmdClasificacion = new System.Data.SqlClient.SqlCommand();
            this.sqldaListaEncuestasActivas = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCmdEncuestasActivas = new System.Data.SqlClient.SqlCommand();
            this.sqldaListaClientesRealizada = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCmdRealizada = new System.Data.SqlClient.SqlCommand();
            this.ucBotoneraSecundaria1 = new GESTCRM.Controles.ucBotoneraSecundaria();
            this.sqldaListaEstado = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCmdEstados = new System.Data.SqlClient.SqlCommand();
            this.pnResultados = new System.Windows.Forms.Panel();
            this.pnPendientes = new System.Windows.Forms.Panel();
            this.dGVPendiente = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblNumPendientes = new System.Windows.Forms.Label();
            this.labelGradientPendientes = new GESTCRM.Controles.LabelGradient();
            this.pnHechas = new System.Windows.Forms.Panel();
            this.dGVRealizada = new System.Windows.Forms.DataGridView();
            this.idEncuestaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sDescripcionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iIdDelegadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sIdClienteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sNombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sClasificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblNumRealizadas = new System.Windows.Forms.Label();
            this.lblGradientHechas = new GESTCRM.Controles.LabelGradient();
            this.lblNombreSel = new System.Windows.Forms.Label();
            this.pnlBClientes.SuspendLayout();
            this.pnSeleccionado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsEncuestas1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsClientes1)).BeginInit();
            this.pnResultados.SuspendLayout();
            this.pnPendientes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVPendiente)).BeginInit();
            this.pnHechas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVRealizada)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBClientes
            // 
            this.pnlBClientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnlBClientes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBClientes.Controls.Add(this.pnSeleccionado);
            this.pnlBClientes.Controls.Add(this.cbEncuesta);
            this.pnlBClientes.Controls.Add(this.lblEncuesta);
            this.pnlBClientes.Controls.Add(this.lblTitulo);
            this.pnlBClientes.Controls.Add(this.cbClasificacion);
            this.pnlBClientes.Controls.Add(this.txtsIdCliente);
            this.pnlBClientes.Controls.Add(this.lblClasificacion);
            this.pnlBClientes.Controls.Add(this.cbDelegado);
            this.pnlBClientes.Controls.Add(this.btBuscar);
            this.pnlBClientes.Controls.Add(this.txtNombre);
            this.pnlBClientes.Controls.Add(this.lblDelegado);
            this.pnlBClientes.Controls.Add(this.lblCodSAP);
            this.pnlBClientes.Controls.Add(this.lblNombre);
            this.pnlBClientes.ForeColor = System.Drawing.Color.Black;
            this.pnlBClientes.Location = new System.Drawing.Point(0, 40);
            this.pnlBClientes.Name = "pnlBClientes";
            this.pnlBClientes.Size = new System.Drawing.Size(1489, 116);
            this.pnlBClientes.TabIndex = 0;
            // 
            // pnSeleccionado
            // 
            this.pnSeleccionado.Controls.Add(this.lblNombreSel);
            this.pnSeleccionado.Controls.Add(this.lblSeleccionado);
            this.pnSeleccionado.Controls.Add(this.label1);
            this.pnSeleccionado.Location = new System.Drawing.Point(1232, 25);
            this.pnSeleccionado.Name = "pnSeleccionado";
            this.pnSeleccionado.Size = new System.Drawing.Size(242, 86);
            this.pnSeleccionado.TabIndex = 107;
            // 
            // lblSeleccionado
            // 
            this.lblSeleccionado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeleccionado.ForeColor = System.Drawing.Color.Blue;
            this.lblSeleccionado.Location = new System.Drawing.Point(7, 32);
            this.lblSeleccionado.Name = "lblSeleccionado";
            this.lblSeleccionado.Size = new System.Drawing.Size(227, 23);
            this.lblSeleccionado.TabIndex = 1;
            this.lblSeleccionado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cliente seleccionado:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cbEncuesta
            // 
            this.cbEncuesta.DataSource = this.dsEncuestas1;
            this.cbEncuesta.DisplayMember = "EncuestasActivas.sDescripcion";
            this.cbEncuesta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbEncuesta.FormattingEnabled = true;
            this.cbEncuesta.Location = new System.Drawing.Point(558, 34);
            this.cbEncuesta.Name = "cbEncuesta";
            this.cbEncuesta.Size = new System.Drawing.Size(555, 28);
            this.cbEncuesta.TabIndex = 106;
            this.cbEncuesta.ValueMember = "EncuestasActivas.IdEncuesta";
            // 
            // dsEncuestas1
            // 
            this.dsEncuestas1.DataSetName = "dsEncuestas";
            this.dsEncuestas1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lblEncuesta
            // 
            this.lblEncuesta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblEncuesta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEncuesta.Location = new System.Drawing.Point(476, 36);
            this.lblEncuesta.Name = "lblEncuesta";
            this.lblEncuesta.Size = new System.Drawing.Size(81, 22);
            this.lblEncuesta.TabIndex = 105;
            this.lblEncuesta.Text = "Encuesta:";
            this.lblEncuesta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.GradientColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.lblTitulo.GradientColorTwo = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(1487, 22);
            this.lblTitulo.TabIndex = 104;
            this.lblTitulo.Text = "Consulta Estado de las Encuestas";
            // 
            // cbClasificacion
            // 
            this.cbClasificacion.DataSource = this.dsClientes1.ListaTipoClasificacion;
            this.cbClasificacion.DisplayMember = "sLiteral";
            this.cbClasificacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbClasificacion.ItemHeight = 20;
            this.cbClasificacion.Location = new System.Drawing.Point(780, 70);
            this.cbClasificacion.Name = "cbClasificacion";
            this.cbClasificacion.Size = new System.Drawing.Size(163, 28);
            this.cbClasificacion.TabIndex = 5;
            this.cbClasificacion.ValueMember = "sValor";
            // 
            // dsClientes1
            // 
            this.dsClientes1.DataSetName = "dsClientes";
            this.dsClientes1.Locale = new System.Globalization.CultureInfo("es-ES");
            this.dsClientes1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // txtsIdCliente
            // 
            this.txtsIdCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsIdCliente.Location = new System.Drawing.Point(147, 72);
            this.txtsIdCliente.MaxLength = 20;
            this.txtsIdCliente.Name = "txtsIdCliente";
            this.txtsIdCliente.Size = new System.Drawing.Size(141, 26);
            this.txtsIdCliente.TabIndex = 1;
            // 
            // lblClasificacion
            // 
            this.lblClasificacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblClasificacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClasificacion.Location = new System.Drawing.Point(674, 74);
            this.lblClasificacion.Name = "lblClasificacion";
            this.lblClasificacion.Size = new System.Drawing.Size(101, 22);
            this.lblClasificacion.TabIndex = 29;
            this.lblClasificacion.Text = "Clasificación:";
            this.lblClasificacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbDelegado
            // 
            this.cbDelegado.DataSource = this.dsClientes1.ListaDelegados;
            this.cbDelegado.DisplayMember = "sNombre";
            this.cbDelegado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDelegado.ItemHeight = 20;
            this.cbDelegado.Location = new System.Drawing.Point(89, 34);
            this.cbDelegado.Name = "cbDelegado";
            this.cbDelegado.Size = new System.Drawing.Size(373, 28);
            this.cbDelegado.TabIndex = 0;
            this.cbDelegado.ValueMember = "iIdDelegado";
            this.cbDelegado.Leave += new System.EventHandler(this.cbDelegado_Leave);
            // 
            // btBuscar
            // 
            this.btBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btBuscar.Location = new System.Drawing.Point(1139, 65);
            this.btBuscar.Name = "btBuscar";
            this.btBuscar.Size = new System.Drawing.Size(75, 36);
            this.btBuscar.TabIndex = 13;
            this.btBuscar.Text = "Buscar";
            this.btBuscar.UseVisualStyleBackColor = true;
            this.btBuscar.Click += new System.EventHandler(this.btBuscar_Click);
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(404, 72);
            this.txtNombre.MaxLength = 50;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(255, 26);
            this.txtNombre.TabIndex = 2;
            // 
            // lblDelegado
            // 
            this.lblDelegado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblDelegado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDelegado.Location = new System.Drawing.Point(8, 36);
            this.lblDelegado.Name = "lblDelegado";
            this.lblDelegado.Size = new System.Drawing.Size(82, 22);
            this.lblDelegado.TabIndex = 2;
            this.lblDelegado.Text = "Delegado:";
            this.lblDelegado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCodSAP
            // 
            this.lblCodSAP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodSAP.Location = new System.Drawing.Point(8, 74);
            this.lblCodSAP.Name = "lblCodSAP";
            this.lblCodSAP.Size = new System.Drawing.Size(137, 22);
            this.lblCodSAP.TabIndex = 42;
            this.lblCodSAP.Text = "Código SAP Fcia.:";
            this.lblCodSAP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNombre
            // 
            this.lblNombre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(300, 74);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(104, 22);
            this.lblNombre.TabIndex = 35;
            this.lblNombre.Text = "Nombre Fcia:";
            this.lblNombre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sqlConn
            // 
            this.sqlConn.ConnectionString = Utiles._connection.ConnectionString.ToString();   //---- GSG (06/03/2021)
            this.sqlConn.FireInfoMessageEventOnUserErrors = false;
            // 
            // sqldaListaDelegados
            // 
            this.sqldaListaDelegados.SelectCommand = this.sqlSelectCmdDelegados;
            this.sqldaListaDelegados.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaDelegados", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iIdDelegado", "iIdDelegado"),
                        new System.Data.Common.DataColumnMapping("sNombre", "sNombre")})});
            // 
            // sqlSelectCmdDelegados
            // 
            this.sqlSelectCmdDelegados.CommandText = "[ListaDelegados]";
            this.sqlSelectCmdDelegados.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCmdDelegados.Connection = this.sqlConn;
            this.sqlSelectCmdDelegados.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null)});
            // 
            // sqldaListaTipoClasificacion
            // 
            this.sqldaListaTipoClasificacion.SelectCommand = this.sqlSelectCmdClasificacion;
            this.sqldaListaTipoClasificacion.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaTipoClasificacion", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("sValor", "sValor"),
                        new System.Data.Common.DataColumnMapping("sLiteral", "sLiteral")})});
            // 
            // sqlSelectCmdClasificacion
            // 
            this.sqlSelectCmdClasificacion.CommandText = "[ListaTipoClasificacion]";
            this.sqlSelectCmdClasificacion.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCmdClasificacion.Connection = this.sqlConn;
            this.sqlSelectCmdClasificacion.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null)});
            // 
            // sqldaListaEncuestasActivas
            // 
            this.sqldaListaEncuestasActivas.SelectCommand = this.sqlCmdEncuestasActivas;
            this.sqldaListaEncuestasActivas.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "EncuestasActivas", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("IdEncuesta", "IdEncuesta"),
                        new System.Data.Common.DataColumnMapping("sDescripcion", "sDescripcion")})});
            // 
            // sqlCmdEncuestasActivas
            // 
            this.sqlCmdEncuestasActivas.CommandText = "[SRVYListaEncuestasActivas]";
            this.sqlCmdEncuestasActivas.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdEncuestasActivas.Connection = this.sqlConn;
            this.sqlCmdEncuestasActivas.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null)});
            // 
            // sqldaListaClientesRealizada
            // 
            this.sqldaListaClientesRealizada.SelectCommand = this.sqlSelectCmdRealizada;
            this.sqldaListaClientesRealizada.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ClientesEncuestaRealizada", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("IdEncuesta", "IdEncuesta"),
                        new System.Data.Common.DataColumnMapping("sDescripcion", "sDescripcion"),
                        new System.Data.Common.DataColumnMapping("iIdDelegado", "iIdDelegado"),
                        new System.Data.Common.DataColumnMapping("sIdCliente", "sIdCliente"),
                        new System.Data.Common.DataColumnMapping("sNombre", "sNombre"),
                        new System.Data.Common.DataColumnMapping("sClasificacion", "sClasificacion")})});
            // 
            // sqlSelectCmdRealizada
            // 
            this.sqlSelectCmdRealizada.CommandText = "[SRVYListaClientesEncuestaRealizada]";
            this.sqlSelectCmdRealizada.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCmdRealizada.Connection = this.sqlConn;
            this.sqlSelectCmdRealizada.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@IdEncuesta", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdDelegado", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sIdCliente", System.Data.SqlDbType.VarChar, 20),
            new System.Data.SqlClient.SqlParameter("@sNombre", System.Data.SqlDbType.VarChar, 50),
            new System.Data.SqlClient.SqlParameter("@sClasificacion", System.Data.SqlDbType.VarChar, 50),
            new System.Data.SqlClient.SqlParameter("@bRealizada", System.Data.SqlDbType.Bit, 1)});
            // 
            // ucBotoneraSecundaria1
            // 
            this.ucBotoneraSecundaria1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(117)))), ((int)(((byte)(1)))));
            this.ucBotoneraSecundaria1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucBotoneraSecundaria1.ForeColor = System.Drawing.Color.Black;
            this.ucBotoneraSecundaria1.Location = new System.Drawing.Point(0, 0);
            this.ucBotoneraSecundaria1.Name = "ucBotoneraSecundaria1";
            this.ucBotoneraSecundaria1.Size = new System.Drawing.Size(1604, 38);
            this.ucBotoneraSecundaria1.TabIndex = 41;
            // 
            // sqldaListaEstado
            // 
            this.sqldaListaEstado.SelectCommand = this.sqlCmdEstados;
            this.sqldaListaEstado.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaEstados", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("sValor", "sValor"),
                        new System.Data.Common.DataColumnMapping("sLiteral", "sLiteral")})});
            // 
            // sqlCmdEstados
            // 
            this.sqlCmdEstados.CommandText = "[ListaEstados]";
            this.sqlCmdEstados.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdEstados.Connection = this.sqlConn;
            this.sqlCmdEstados.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null)});
            // 
            // pnResultados
            // 
            this.pnResultados.Controls.Add(this.pnPendientes);
            this.pnResultados.Controls.Add(this.pnHechas);
            this.pnResultados.Location = new System.Drawing.Point(2, 160);
            this.pnResultados.Name = "pnResultados";
            this.pnResultados.Size = new System.Drawing.Size(1487, 622);
            this.pnResultados.TabIndex = 42;
            // 
            // pnPendientes
            // 
            this.pnPendientes.Controls.Add(this.dGVPendiente);
            this.pnPendientes.Controls.Add(this.lblNumPendientes);
            this.pnPendientes.Controls.Add(this.labelGradientPendientes);
            this.pnPendientes.Location = new System.Drawing.Point(748, 13);
            this.pnPendientes.Name = "pnPendientes";
            this.pnPendientes.Size = new System.Drawing.Size(730, 590);
            this.pnPendientes.TabIndex = 1;
            // 
            // dGVPendiente
            // 
            this.dGVPendiente.AllowUserToAddRows = false;
            this.dGVPendiente.AllowUserToDeleteRows = false;
            this.dGVPendiente.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGVPendiente.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dGVPendiente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVPendiente.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6});
            this.dGVPendiente.DataMember = "ClientesEncuestaPendiente";
            this.dGVPendiente.DataSource = this.dsEncuestas1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dGVPendiente.DefaultCellStyle = dataGridViewCellStyle2;
            this.dGVPendiente.Location = new System.Drawing.Point(4, 25);
            this.dGVPendiente.Name = "dGVPendiente";
            this.dGVPendiente.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dGVPendiente.Size = new System.Drawing.Size(721, 548);
            this.dGVPendiente.TabIndex = 108;
            this.dGVPendiente.DoubleClick += new System.EventHandler(this.dGVPendiente_DoubleClick);
            this.dGVPendiente.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dGVPendiente_MouseUp);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "IdEncuesta";
            this.dataGridViewTextBoxColumn1.HeaderText = "IdEncuesta";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "sDescripcion";
            this.dataGridViewTextBoxColumn2.HeaderText = "sDescripcion";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "iIdDelegado";
            this.dataGridViewTextBoxColumn3.HeaderText = "iIdDelegado";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Visible = false;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "sIdCliente";
            this.dataGridViewTextBoxColumn4.HeaderText = "Cód. SAP";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 120;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "sNombre";
            this.dataGridViewTextBoxColumn5.HeaderText = "Nombre Farmacia";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 410;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "sClasificacion";
            this.dataGridViewTextBoxColumn6.HeaderText = "Clasificación";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 120;
            // 
            // lblNumPendientes
            // 
            this.lblNumPendientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.lblNumPendientes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblNumPendientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumPendientes.ForeColor = System.Drawing.Color.Black;
            this.lblNumPendientes.Location = new System.Drawing.Point(661, 0);
            this.lblNumPendientes.Name = "lblNumPendientes";
            this.lblNumPendientes.Size = new System.Drawing.Size(67, 21);
            this.lblNumPendientes.TabIndex = 107;
            this.lblNumPendientes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelGradientPendientes
            // 
            this.labelGradientPendientes.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelGradientPendientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGradientPendientes.ForeColor = System.Drawing.Color.White;
            this.labelGradientPendientes.GradientColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.labelGradientPendientes.GradientColorTwo = System.Drawing.Color.White;
            this.labelGradientPendientes.Location = new System.Drawing.Point(0, 0);
            this.labelGradientPendientes.Name = "labelGradientPendientes";
            this.labelGradientPendientes.Size = new System.Drawing.Size(730, 22);
            this.labelGradientPendientes.TabIndex = 106;
            this.labelGradientPendientes.Text = "Farmacias Encuesta PENDIENTE";
            // 
            // pnHechas
            // 
            this.pnHechas.Controls.Add(this.dGVRealizada);
            this.pnHechas.Controls.Add(this.lblNumRealizadas);
            this.pnHechas.Controls.Add(this.lblGradientHechas);
            this.pnHechas.Location = new System.Drawing.Point(11, 13);
            this.pnHechas.Name = "pnHechas";
            this.pnHechas.Size = new System.Drawing.Size(730, 590);
            this.pnHechas.TabIndex = 0;
            // 
            // dGVRealizada
            // 
            this.dGVRealizada.AllowUserToAddRows = false;
            this.dGVRealizada.AllowUserToDeleteRows = false;
            this.dGVRealizada.AutoGenerateColumns = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGVRealizada.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dGVRealizada.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVRealizada.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idEncuestaDataGridViewTextBoxColumn,
            this.sDescripcionDataGridViewTextBoxColumn,
            this.iIdDelegadoDataGridViewTextBoxColumn,
            this.sIdClienteDataGridViewTextBoxColumn,
            this.sNombreDataGridViewTextBoxColumn,
            this.sClasificacionDataGridViewTextBoxColumn});
            this.dGVRealizada.DataMember = "ClientesEncuestaRealizada";
            this.dGVRealizada.DataSource = this.dsEncuestas1;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dGVRealizada.DefaultCellStyle = dataGridViewCellStyle4;
            this.dGVRealizada.Location = new System.Drawing.Point(4, 25);
            this.dGVRealizada.Name = "dGVRealizada";
            this.dGVRealizada.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dGVRealizada.Size = new System.Drawing.Size(721, 548);
            this.dGVRealizada.TabIndex = 107;
            this.dGVRealizada.DoubleClick += new System.EventHandler(this.dGVRealizada_DoubleClick);
            this.dGVRealizada.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dGVRealizada_MouseUp);
            // 
            // idEncuestaDataGridViewTextBoxColumn
            // 
            this.idEncuestaDataGridViewTextBoxColumn.DataPropertyName = "IdEncuesta";
            this.idEncuestaDataGridViewTextBoxColumn.HeaderText = "IdEncuesta";
            this.idEncuestaDataGridViewTextBoxColumn.Name = "idEncuestaDataGridViewTextBoxColumn";
            this.idEncuestaDataGridViewTextBoxColumn.Visible = false;
            // 
            // sDescripcionDataGridViewTextBoxColumn
            // 
            this.sDescripcionDataGridViewTextBoxColumn.DataPropertyName = "sDescripcion";
            this.sDescripcionDataGridViewTextBoxColumn.HeaderText = "sDescripcion";
            this.sDescripcionDataGridViewTextBoxColumn.Name = "sDescripcionDataGridViewTextBoxColumn";
            this.sDescripcionDataGridViewTextBoxColumn.Visible = false;
            // 
            // iIdDelegadoDataGridViewTextBoxColumn
            // 
            this.iIdDelegadoDataGridViewTextBoxColumn.DataPropertyName = "iIdDelegado";
            this.iIdDelegadoDataGridViewTextBoxColumn.HeaderText = "iIdDelegado";
            this.iIdDelegadoDataGridViewTextBoxColumn.Name = "iIdDelegadoDataGridViewTextBoxColumn";
            this.iIdDelegadoDataGridViewTextBoxColumn.Visible = false;
            // 
            // sIdClienteDataGridViewTextBoxColumn
            // 
            this.sIdClienteDataGridViewTextBoxColumn.DataPropertyName = "sIdCliente";
            this.sIdClienteDataGridViewTextBoxColumn.HeaderText = "Cód. SAP";
            this.sIdClienteDataGridViewTextBoxColumn.Name = "sIdClienteDataGridViewTextBoxColumn";
            this.sIdClienteDataGridViewTextBoxColumn.Width = 120;
            // 
            // sNombreDataGridViewTextBoxColumn
            // 
            this.sNombreDataGridViewTextBoxColumn.DataPropertyName = "sNombre";
            this.sNombreDataGridViewTextBoxColumn.HeaderText = "Nombre Farmacia";
            this.sNombreDataGridViewTextBoxColumn.Name = "sNombreDataGridViewTextBoxColumn";
            this.sNombreDataGridViewTextBoxColumn.Width = 410;
            // 
            // sClasificacionDataGridViewTextBoxColumn
            // 
            this.sClasificacionDataGridViewTextBoxColumn.DataPropertyName = "sClasificacion";
            this.sClasificacionDataGridViewTextBoxColumn.HeaderText = "Clasificación";
            this.sClasificacionDataGridViewTextBoxColumn.Name = "sClasificacionDataGridViewTextBoxColumn";
            this.sClasificacionDataGridViewTextBoxColumn.Width = 120;
            // 
            // lblNumRealizadas
            // 
            this.lblNumRealizadas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.lblNumRealizadas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblNumRealizadas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumRealizadas.ForeColor = System.Drawing.Color.Black;
            this.lblNumRealizadas.Location = new System.Drawing.Point(660, 0);
            this.lblNumRealizadas.Name = "lblNumRealizadas";
            this.lblNumRealizadas.Size = new System.Drawing.Size(67, 21);
            this.lblNumRealizadas.TabIndex = 106;
            this.lblNumRealizadas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblGradientHechas
            // 
            this.lblGradientHechas.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblGradientHechas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGradientHechas.ForeColor = System.Drawing.Color.White;
            this.lblGradientHechas.GradientColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.lblGradientHechas.GradientColorTwo = System.Drawing.Color.White;
            this.lblGradientHechas.Location = new System.Drawing.Point(0, 0);
            this.lblGradientHechas.Name = "lblGradientHechas";
            this.lblGradientHechas.Size = new System.Drawing.Size(730, 22);
            this.lblGradientHechas.TabIndex = 105;
            this.lblGradientHechas.Text = "Farmacias Encuesta REALIZADA";
            // 
            // lblNombreSel
            // 
            this.lblNombreSel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreSel.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblNombreSel.Location = new System.Drawing.Point(7, 55);
            this.lblNombreSel.Name = "lblNombreSel";
            this.lblNombreSel.Size = new System.Drawing.Size(227, 23);
            this.lblNombreSel.TabIndex = 2;
            this.lblNombreSel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmConsultaEncuestas
            // 
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.ClientSize = new System.Drawing.Size(1604, 787);
            this.Controls.Add(this.pnResultados);
            this.Controls.Add(this.ucBotoneraSecundaria1);
            this.Controls.Add(this.pnlBClientes);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmConsultaEncuestas";
            this.Text = "Consulta Encuestas";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Closed += new System.EventHandler(this.frmConsultaEncuestas_Closed);
            this.Load += new System.EventHandler(this.frmConsultaEncuestas_Load);
            this.pnlBClientes.ResumeLayout(false);
            this.pnlBClientes.PerformLayout();
            this.pnSeleccionado.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dsEncuestas1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsClientes1)).EndInit();
            this.pnResultados.ResumeLayout(false);
            this.pnPendientes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGVPendiente)).EndInit();
            this.pnHechas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGVRealizada)).EndInit();
            this.ResumeLayout(false);

		}
        #endregion

        #region frmConsultaEncuestas_Load
        private void frmConsultaEncuestas_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                GESTCRM.Utiles.Formato_Formulario(this);
                if (this.Parent == null) this.WindowState = FormWindowState.Normal;

                Application.DoEvents();
                Inicializar_Combos();


                Application.DoEvents();
                Inicializar_Botonera();

                Application.DoEvents();
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }

            Cursor.Current = Cursors.Default;
        }
        #endregion

        #region Inicializar_Combos
        private void Inicializar_Combos()
		{
			try
			{
				this.sqldaListaDelegados.Fill(this.dsClientes1);
				DataRow fila1 = this.dsClientes1.ListaDelegados.NewRow();
				fila1["iIdDelegado"]=-1;
				fila1["sNombre"]="Todos";
				this.dsClientes1.ListaDelegados.Rows.InsertAt(fila1,1);
				this.cbDelegado.SelectedValue=GESTCRM.Clases.Configuracion.iIdDelegado;

			
				this.sqldaListaTipoClasificacion.Fill(this.dsClientes1);
				DataRow fila3 = this.dsClientes1.ListaTipoClasificacion.NewRow();
				fila3["sValor"]="T";
				fila3["sLiteral"]="Todos";
				this.dsClientes1.ListaTipoClasificacion.Rows.InsertAt(fila3,1);
				this.cbClasificacion.SelectedValue="T";

                this.sqldaListaEncuestasActivas.Fill(this.dsEncuestas1.EncuestasActivas);
                //---- GSG (29/08/2019)
                //cbEncuesta.SelectedIndex = 0;
                if (this.dsEncuestas1.EncuestasActivas.Rows.Count > 0)
                    cbEncuesta.SelectedIndex = 0;

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
                this.ucBotoneraSecundaria1.Activar_botonera(true, false, true, false, false, false);

                this.ucBotoneraSecundaria1.btEditar.Click += new EventHandler(this.AEncuesta);
            }
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

        private void Inicializar_Grid(int grid)
        {
            if (grid == _K_GRID_REALIZADA)
            {
                //foreach (DataGridViewRow row in dGVRealizada.Rows)
                //{
                //    //if (row == dGVRealizada.Rows[dGVRealizada.CurrentRow.Index])
                //        for (int i = 0; i < row.Cells.Count; i++)
                //            row.Cells[i].Style.BackColor = _DefaultColor;
                //}

            }
            else if (grid == _K_GRID_PENDIENTE)
            {
                //foreach (DataGridViewRow row in dGVPendiente.Rows)
                //{
                //    for (int i = 0; i < row.Cells.Count; i++)
                //        row.Cells[i].Style.BackColor = _DefaultColor;
                //}
            }
        }

		#region btBuscar_Click
		private void btBuscar_Click(object sender, System.EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;
			try
			{
                if (cbEncuesta.Items.Count > 0) //---- GSG (29/08/2019)
                {
                    int idEncuesta = -1;
                    int idDelegado = GESTCRM.Clases.Configuracion.iIdDelegado;
                    string sIdCliente = null;
                    string sNombre = null;
                    string sClasificacion = null;

                    idEncuesta = int.Parse(cbEncuesta.SelectedValue.ToString());

                    if (int.Parse(this.cbDelegado.SelectedValue.ToString()) != -1)
                        idDelegado = int.Parse(this.cbDelegado.SelectedValue.ToString());

                    if (this.txtsIdCliente.Text.ToString().Trim().Length > 0)
                        sIdCliente = this.txtsIdCliente.Text.ToString();

                    if (this.txtNombre.Text.ToString().Trim().Length > 0)
                        sNombre = this.txtNombre.Text.ToString();

                    if (this.cbClasificacion.SelectedValue.ToString() != "T")
                        sClasificacion = this.cbClasificacion.Text;

                    this.dsEncuestas1.ClientesEncuestaRealizada.Rows.Clear();
                    this.dsEncuestas1.ClientesEncuestaPendiente.Rows.Clear();

                    // Obtiene las pendientes
                    this.sqldaListaClientesRealizada.SelectCommand.Parameters["@idEncuesta"].Value = idEncuesta;
                    this.sqldaListaClientesRealizada.SelectCommand.Parameters["@iIdDelegado"].Value = idDelegado;
                    this.sqldaListaClientesRealizada.SelectCommand.Parameters["@sIdCliente"].Value = sIdCliente;
                    this.sqldaListaClientesRealizada.SelectCommand.Parameters["@sNombre"].Value = sNombre;
                    this.sqldaListaClientesRealizada.SelectCommand.Parameters["@sClasificacion"].Value = sClasificacion;
                    this.sqldaListaClientesRealizada.SelectCommand.Parameters["@bRealizada"].Value = 0;

                    this.sqldaListaClientesRealizada.Fill(this.dsEncuestas1.ClientesEncuestaPendiente);

                    this.lblNumPendientes.Text = this.dsEncuestas1.ClientesEncuestaPendiente.Rows.Count.ToString();

                    // Obtiene las realizadas
                    this.sqldaListaClientesRealizada.SelectCommand.Parameters["@idEncuesta"].Value = idEncuesta;
                    this.sqldaListaClientesRealizada.SelectCommand.Parameters["@iIdDelegado"].Value = idDelegado;
                    this.sqldaListaClientesRealizada.SelectCommand.Parameters["@sIdCliente"].Value = sIdCliente;
                    this.sqldaListaClientesRealizada.SelectCommand.Parameters["@sNombre"].Value = sNombre;
                    this.sqldaListaClientesRealizada.SelectCommand.Parameters["@sClasificacion"].Value = sClasificacion;
                    this.sqldaListaClientesRealizada.SelectCommand.Parameters["@bRealizada"].Value = 1;

                    this.sqldaListaClientesRealizada.Fill(this.dsEncuestas1.ClientesEncuestaRealizada);

                    this.lblNumRealizadas.Text = this.dsEncuestas1.ClientesEncuestaRealizada.Rows.Count.ToString();

                }
                else
                    Mensajes.ShowInformation("No hay encuestas activas para esta selección."); //---- GSG (29/08/2019)
            }
            catch (Exception ex){Mensajes.ShowError(ex.Message);}
			Cursor.Current = Cursors.Default;
		}
		#endregion





		#region btSalir_Click
		private void btSalir_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
        #endregion

        #region frmClientes_Closed
        private void frmConsultaEncuestas_Closed(object sender, System.EventArgs e)
        {
            this.Dispose();
        }
        #endregion

        private void cbDelegado_Leave(object sender, System.EventArgs e)
		{
			if(this.cbDelegado.SelectedIndex==-1) this.cbDelegado.SelectedValue=-1;
		}

        private void dGVPendiente_MouseUp(object sender, MouseEventArgs e)
        {
            if (dGVPendiente.CurrentRow != null) //---- GSG (29/08/2019)
            {
                lblSeleccionado.Text = dGVPendiente.Rows[dGVPendiente.CurrentRow.Index].Cells[3].Value.ToString();
                lblNombreSel.Text = dGVPendiente.Rows[dGVPendiente.CurrentRow.Index].Cells[4].Value.ToString();
            }
            else
                Mensajes.ShowInformation("No hay encuestas activas para esta selección."); //---- GSG (29/08/2019)
        }

        private void dGVPendiente_DoubleClick(object sender, EventArgs e)
        {
            Encuestas(true);
        }
    
     
        private void dGVRealizada_MouseUp(object sender, MouseEventArgs e)
        {
            if (dGVRealizada.CurrentRow != null) //---- GSG (29/08/2019)
            {
                lblSeleccionado.Text = dGVRealizada.Rows[dGVRealizada.CurrentRow.Index].Cells[3].Value.ToString();
                lblNombreSel.Text = dGVRealizada.Rows[dGVRealizada.CurrentRow.Index].Cells[4].Value.ToString();
            }
            else
                Mensajes.ShowInformation("No hay encuestas activas para esta selección."); //---- GSG (29/08/2019)
        }

        private void dGVRealizada_DoubleClick(object sender, EventArgs e)
        {
            Encuestas(true);
        }

        private void AEncuesta(object sender, System.EventArgs e)
        {
            Encuestas(true);
        }

        private void Encuestas(bool abrir)
        {
            string codSAP = lblSeleccionado.Text;

            if (codSAP != "" && codSAP != "")
            {
                frmEncuesta frmEnc = new frmEncuesta(GESTCRM.Clases.Configuracion.iIdDelegado, codSAP);

                if (abrir)
                {
                    frmEnc.ShowDialog(this);                    
                }
             
            }
            else
            {
                Mensajes.ShowInformation("Para acceder a las encuestas es necesario seleccionar un cliente.");
            }
        }

       
    }
}
