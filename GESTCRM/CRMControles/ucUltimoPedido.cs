using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace GESTCRM.CRMControles
{
	/// <summary>
	/// Descripción breve de UltimoPedido.
	/// </summary>
	public class ucUltimoPedido : System.Windows.Forms.UserControl
	{
		private System.Data.SqlClient.SqlDataAdapter sqldaListaLineasPedidos;
        private System.Windows.Forms.DataGrid dgLineasPedidos;
		private System.Windows.Forms.DataGrid dgCabecerasPedidos;
		private System.Data.SqlClient.SqlDataAdapter sqldaListaBuscaPedidos;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn dFechaPedido;
		private System.Windows.Forms.DataGridTextBoxColumn dFechaPreferente;
		private System.Windows.Forms.DataGridTextBoxColumn sIdTipoPedido;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle2;
		private System.Windows.Forms.DataGridTextBoxColumn sIdMaterial;
        private System.Windows.Forms.DataGridTextBoxColumn sMaterial;
		private System.Windows.Forms.DataGridTextBoxColumn iCantidad;
		private System.Windows.Forms.DataGridTextBoxColumn fPrecio;
		/// <summary> 
		/// Variable del diseñador requerida.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private Form frmMyForm;
		private ContextMenu menu;
		private System.Windows.Forms.DataGridTextBoxColumn sIdPedido;
		private int row_dgCabecerasPedidos = -1;
		private System.Windows.Forms.DataGridTextBoxColumn Importe;
        //---- GSG (27/01/2011)
        private System.Windows.Forms.DataGridTextBoxColumn ImporteBruto;
        //---- FI GSG
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label lblCounterLineas;
		private System.Windows.Forms.DataGridTextBoxColumn fDescuento;
		private System.Windows.Forms.DataGridTextBoxColumn Descuento;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		private System.Windows.Forms.DataGridTextBoxColumn fRentabilidad;
		private System.Windows.Forms.DataGridTextBoxColumn sDescripcionRentabilidad;
		private GESTCRM.Controles.LabelGradient labelGradient111;
		private GESTCRM.Controles.LabelGradient labelGradient2222;
		private GESTCRM.Controles.LabelGradient labelGradient1;
        private GESTCRM.Controles.LabelGradient labelGradient2;
        private DataGridTextBoxColumn Campanya;
        private GESTCRM.CRMControles.DataSets.dsPedidos dsPedidos;
		

        //---- GSG (08/11/2011)
        //private bool bConectado = false;
        private System.Data.SqlClient.SqlConnection Conn;
        //---- FI GSG


		#region constructores
		public ucUltimoPedido()
		{
			this.frmMyForm = null;
			this.menu = null;

			// Llamada necesaria para el Diseñador de formularios Windows.Forms.
			InitializeComponent();
		}

		public ucUltimoPedido(Form frm, ContextMenu mnu)
		{
			this.frmMyForm = frm;
			this.menu = mnu;

			// Llamada necesaria para el Diseñador de formularios Windows.Forms.
			InitializeComponent();
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

		#endregion 

		#region Código generado por el Diseñador de componentes
		/// <summary> 
		/// Método necesario para admitir el Diseñador. No se puede modificar 
		/// el contenido del método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{
            this.sqldaListaLineasPedidos = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
            this.dgLineasPedidos = new System.Windows.Forms.DataGrid();
            this.dsPedidos = new GESTCRM.CRMControles.DataSets.dsPedidos();
            this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
            this.sIdMaterial = new System.Windows.Forms.DataGridTextBoxColumn();
            this.sMaterial = new System.Windows.Forms.DataGridTextBoxColumn();
            this.Campanya = new System.Windows.Forms.DataGridTextBoxColumn();
            this.iCantidad = new System.Windows.Forms.DataGridTextBoxColumn();
            this.fPrecio = new System.Windows.Forms.DataGridTextBoxColumn();
            this.fDescuento = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dgCabecerasPedidos = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.sIdPedido = new System.Windows.Forms.DataGridTextBoxColumn();
            this.sIdTipoPedido = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dFechaPedido = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dFechaPreferente = new System.Windows.Forms.DataGridTextBoxColumn();
            this.Importe = new System.Windows.Forms.DataGridTextBoxColumn();
            this.ImporteBruto = new System.Windows.Forms.DataGridTextBoxColumn();
            this.Descuento = new System.Windows.Forms.DataGridTextBoxColumn();
            this.fRentabilidad = new System.Windows.Forms.DataGridTextBoxColumn();
            this.sDescripcionRentabilidad = new System.Windows.Forms.DataGridTextBoxColumn();
            this.sqldaListaBuscaPedidos = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
            this.labelGradient111 = new GESTCRM.Controles.LabelGradient();
            this.labelGradient2222 = new GESTCRM.Controles.LabelGradient();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelGradient1 = new GESTCRM.Controles.LabelGradient();
            this.lblCounterLineas = new System.Windows.Forms.Label();
            this.labelGradient2 = new GESTCRM.Controles.LabelGradient();

            
            Conn = new System.Data.SqlClient.SqlConnection();
            //---- GSG (10/09/2014)
            Conn = Utiles._connection;

            System.Configuration.AppSettingsReader configurationAppSettings = new System.Configuration.AppSettingsReader();
            //Conn.ConnectionString = Clases.Configuracion.sqlCadenaCon; //---- GSG (10/09/2014)
            Conn.FireInfoMessageEventOnUserErrors = false;
            

            ((System.ComponentModel.ISupportInitialize)(this.dgLineasPedidos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPedidos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgCabecerasPedidos)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // sqldaListaLineasPedidos
            // 
            this.sqldaListaLineasPedidos.SelectCommand = this.sqlSelectCommand1;
            this.sqldaListaLineasPedidos.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaLineasPedido", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iIdLinea", "iIdLinea"),
                        new System.Data.Common.DataColumnMapping("sIdMaterial", "sIdMaterial"),
                        new System.Data.Common.DataColumnMapping("sMaterial", "sMaterial"),
                        new System.Data.Common.DataColumnMapping("iCantidad", "iCantidad"),
                        new System.Data.Common.DataColumnMapping("fPrecio", "fPrecio"),
                        new System.Data.Common.DataColumnMapping("fDescuento", "fDescuento"),
                        new System.Data.Common.DataColumnMapping("ImporteLin", "ImporteLin"),
                        new System.Data.Common.DataColumnMapping("PrecioUnitario", "PrecioUnitario"),
                        new System.Data.Common.DataColumnMapping("fDescuentoMaximo", "fDescuentoMaximo"),
                        new System.Data.Common.DataColumnMapping("fRentabilidad", "fRentabilidad"),
                        new System.Data.Common.DataColumnMapping("fCoste", "fCoste"),
                        new System.Data.Common.DataColumnMapping("idCampanya", "idCampanya"),
                        new System.Data.Common.DataColumnMapping("idArrastre", "idArrastre"),
                        new System.Data.Common.DataColumnMapping("NombreCampanya", "NombreCampanya"),
                        new System.Data.Common.DataColumnMapping("UnidMinimas", "UnidMinimas"),
                        new System.Data.Common.DataColumnMapping("sObligatorio", "sObligatorio"),
                        new System.Data.Common.DataColumnMapping("idGrupoMat", "idGrupoMat")})});
            // 
            // sqlSelectCommand1
            // 
            this.sqlSelectCommand1.CommandText = "[ListaLineasPedido]";
            this.sqlSelectCommand1.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand1.Connection = this.Conn;
            this.sqlSelectCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@sIdPedido", System.Data.SqlDbType.VarChar, 12)});
            // 
            // dgLineasPedidos
            // 
            this.dgLineasPedidos.BackgroundColor = System.Drawing.Color.White;
            this.dgLineasPedidos.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.dgLineasPedidos.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgLineasPedidos.CaptionText = "Lineas de pedido";
            this.dgLineasPedidos.CaptionVisible = false;
            this.dgLineasPedidos.DataMember = "ListaLineasPedido";
            this.dgLineasPedidos.DataSource = this.dsPedidos;
            this.dgLineasPedidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.dgLineasPedidos.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgLineasPedidos.Location = new System.Drawing.Point(4, 144);
            this.dgLineasPedidos.Name = "dgLineasPedidos";
            this.dgLineasPedidos.ReadOnly = true;
            this.dgLineasPedidos.RowHeaderWidth = 30;
            this.dgLineasPedidos.Size = new System.Drawing.Size(496, 92);
            this.dgLineasPedidos.TabIndex = 34;
            this.dgLineasPedidos.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle2});
            // 
            // dsPedidos
            // 
            this.dsPedidos.DataSetName = "dsPedidos";
            this.dsPedidos.Locale = new System.Globalization.CultureInfo("en-US");
            this.dsPedidos.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataGridTableStyle2
            // 
            this.dataGridTableStyle2.DataGrid = this.dgLineasPedidos;
            this.dataGridTableStyle2.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.sIdMaterial,
            this.sMaterial,
            this.Campanya,
            this.iCantidad,
            this.fPrecio,
            this.fDescuento});
            this.dataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle2.MappingName = "ListaLineasPedido";
            this.dataGridTableStyle2.RowHeaderWidth = 30;
            // 
            // sIdMaterial
            // 
            this.sIdMaterial.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.sIdMaterial.Format = "";
            this.sIdMaterial.FormatInfo = null;
            this.sIdMaterial.HeaderText = "CodProducto";
            this.sIdMaterial.MappingName = "sIdMaterial";
            this.sIdMaterial.NullText = "";
            this.sIdMaterial.Width = 70;
            // 
            // sMaterial
            // 
            this.sMaterial.Format = "";
            this.sMaterial.FormatInfo = null;
            this.sMaterial.HeaderText = "Producto";
            this.sMaterial.MappingName = "sMaterial";
            this.sMaterial.NullText = "";
            this.sMaterial.Width = 125;
            // 
            // Campanya
            // 
            this.Campanya.Format = "";
            this.Campanya.FormatInfo = null;
            this.Campanya.HeaderText = "Campaña";
            this.Campanya.MappingName = "NombreCampanya";
            this.Campanya.Width = 75;
            // 
            // iCantidad
            // 
            this.iCantidad.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.iCantidad.Format = "";
            this.iCantidad.FormatInfo = null;
            this.iCantidad.HeaderText = "Cantidad";
            this.iCantidad.MappingName = "iCantidad";
            this.iCantidad.NullText = "";
            this.iCantidad.Width = 55;
            // 
            // fPrecio
            // 
            this.fPrecio.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.fPrecio.Format = "N2";
            this.fPrecio.FormatInfo = null;
            this.fPrecio.HeaderText = "Precio";
            this.fPrecio.MappingName = "fPrecio";
            this.fPrecio.NullText = "";
            this.fPrecio.Width = 60;
            // 
            // fDescuento
            // 
            this.fDescuento.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.fDescuento.Format = "N2";
            this.fDescuento.FormatInfo = null;
            this.fDescuento.HeaderText = "Dto.";
            this.fDescuento.MappingName = "fDescuento";
            this.fDescuento.NullText = "";
            this.fDescuento.Width = 50;
            // 
            // dgCabecerasPedidos
            // 
            this.dgCabecerasPedidos.BackgroundColor = System.Drawing.Color.White;
            this.dgCabecerasPedidos.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.dgCabecerasPedidos.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgCabecerasPedidos.CaptionText = "Ultimos Pedidos";
            this.dgCabecerasPedidos.CaptionVisible = false;
            this.dgCabecerasPedidos.DataMember = "ListaBuscaPedidos";
            this.dgCabecerasPedidos.DataSource = this.dsPedidos;
            this.dgCabecerasPedidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.dgCabecerasPedidos.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgCabecerasPedidos.Location = new System.Drawing.Point(4, 18);
            this.dgCabecerasPedidos.Name = "dgCabecerasPedidos";
            this.dgCabecerasPedidos.ReadOnly = true;
            this.dgCabecerasPedidos.RowHeaderWidth = 30;
            this.dgCabecerasPedidos.Size = new System.Drawing.Size(496, 102);
            this.dgCabecerasPedidos.TabIndex = 35;
            this.dgCabecerasPedidos.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            this.dgCabecerasPedidos.Paint += new System.Windows.Forms.PaintEventHandler(this.dgCabecerasPedidos_Paint);
            this.dgCabecerasPedidos.CurrentCellChanged += new System.EventHandler(this.dgCabecerasPedidos_CurrentCellChanged);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.DataGrid = this.dgCabecerasPedidos;
            this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.sIdPedido,
            this.sIdTipoPedido,
            this.dFechaPedido,
            this.dFechaPreferente,
            this.Importe,
            this.ImporteBruto,
            this.Descuento,
            this.fRentabilidad,
            this.sDescripcionRentabilidad});
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle1.MappingName = "ListaBuscaPedidos";
            this.dataGridTableStyle1.RowHeaderWidth = 30;
            // 
            // sIdPedido
            // 
            this.sIdPedido.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.sIdPedido.Format = "";
            this.sIdPedido.FormatInfo = null;
            this.sIdPedido.HeaderText = "Pedido";
            this.sIdPedido.MappingName = "sIdPedido";
            this.sIdPedido.NullText = "";
            this.sIdPedido.Width = 85;
            // 
            // sIdTipoPedido
            // 
            this.sIdTipoPedido.Format = "";
            this.sIdTipoPedido.FormatInfo = null;
            this.sIdTipoPedido.HeaderText = "Tipo Pedido";
            this.sIdTipoPedido.MappingName = "sLiteral";
            this.sIdTipoPedido.NullText = "";
            this.sIdTipoPedido.Width = 90;
            // 
            // dFechaPedido
            // 
            this.dFechaPedido.Format = "dd/MM/yyyy";
            this.dFechaPedido.FormatInfo = null;
            this.dFechaPedido.HeaderText = "Fecha Pedido";
            this.dFechaPedido.MappingName = "dFechaPedido";
            this.dFechaPedido.NullText = "";
            this.dFechaPedido.Width = 75;
            // 
            // dFechaPreferente
            // 
            this.dFechaPreferente.Format = "dd/MM/yyyy";
            this.dFechaPreferente.FormatInfo = null;
            this.dFechaPreferente.HeaderText = "Fecha Entrega";
            this.dFechaPreferente.MappingName = "dFechaPreferente";
            this.dFechaPreferente.NullText = "";
            this.dFechaPreferente.Width = 0;
            // 
            // Importe
            // 
            this.Importe.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.Importe.Format = "N2";
            this.Importe.FormatInfo = null;
            this.Importe.HeaderText = "Importe";
            this.Importe.MappingName = "fImporte";
            this.Importe.NullText = "";
            this.Importe.Width = 75;
            // 
            // ImporteBruto
            // 
            this.ImporteBruto.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.ImporteBruto.Format = "N2";
            this.ImporteBruto.FormatInfo = null;
            this.ImporteBruto.HeaderText = "Imp. Bruto";
            this.ImporteBruto.MappingName = "fImporteBruto";
            this.ImporteBruto.NullText = "";
            this.ImporteBruto.Width = 75;
            // 
            // Descuento
            // 
            this.Descuento.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.Descuento.Format = "N2";
            this.Descuento.FormatInfo = null;
            this.Descuento.HeaderText = "Dto.";
            this.Descuento.MappingName = "dto";
            this.Descuento.NullText = "";
            this.Descuento.Width = 50;
            // 
            // fRentabilidad
            // 
            this.fRentabilidad.Format = "N2";
            this.fRentabilidad.FormatInfo = null;
            this.fRentabilidad.HeaderText = "Rentabilidad";
            this.fRentabilidad.MappingName = "fRentabilidad";
            this.fRentabilidad.Width = 0;
            // 
            // sDescripcionRentabilidad
            // 
            this.sDescripcionRentabilidad.Format = "";
            this.sDescripcionRentabilidad.FormatInfo = null;
            this.sDescripcionRentabilidad.HeaderText = "Rentabilidad";
            this.sDescripcionRentabilidad.MappingName = "sDescripcionRentabilidad";
            this.sDescripcionRentabilidad.Width = 75;
            // 
            // sqldaListaBuscaPedidos
            // 
            this.sqldaListaBuscaPedidos.SelectCommand = this.sqlSelectCommand2;
            this.sqldaListaBuscaPedidos.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaBuscaPedidos", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("sIdPedido", "sIdPedido"),
                        new System.Data.Common.DataColumnMapping("sIdTipoPedido", "sIdTipoPedido"),
                        new System.Data.Common.DataColumnMapping("sLiteral", "sLiteral"),
                        new System.Data.Common.DataColumnMapping("sIdCliente", "sIdCliente"),
                        new System.Data.Common.DataColumnMapping("sNombre", "sNombre"),
                        new System.Data.Common.DataColumnMapping("sIdCliente1", "sIdCliente1"),
                        new System.Data.Common.DataColumnMapping("sNombre1", "sNombre1"),
                        new System.Data.Common.DataColumnMapping("dFechaPedido", "dFechaPedido"),
                        new System.Data.Common.DataColumnMapping("dFechaPreferente", "dFechaPreferente"),
                        new System.Data.Common.DataColumnMapping("dFechaFijada", "dFechaFijada"),
                        new System.Data.Common.DataColumnMapping("fImporte", "fImporte"),
                        new System.Data.Common.DataColumnMapping("fImporteBruto", "fImporteBruto"),
                        new System.Data.Common.DataColumnMapping("fDescuento", "fDescuento"),
                        new System.Data.Common.DataColumnMapping("sIdTipoCampanya", "sIdTipoCampanya"),
                        new System.Data.Common.DataColumnMapping("sLiteral1", "sLiteral1"),
                        new System.Data.Common.DataColumnMapping("tObservaciones", "tObservaciones"),
                        new System.Data.Common.DataColumnMapping("iIdDelegado", "iIdDelegado"),
                        new System.Data.Common.DataColumnMapping("iIdCliente", "iIdCliente"),
                        new System.Data.Common.DataColumnMapping("iIdCliente1", "iIdCliente1"),
                        new System.Data.Common.DataColumnMapping("sNombre2", "sNombre2"),
                        new System.Data.Common.DataColumnMapping("bEnviadoCEN", "bEnviadoCEN"),
                        new System.Data.Common.DataColumnMapping("dto", "dto")})});
            // 
            // sqlSelectCommand2
            // 
            this.sqlSelectCommand2.CommandText = "[ListaBuscaPedidosCincoPrimeros]";
            this.sqlSelectCommand2.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand2.Connection = this.Conn;
            this.sqlSelectCommand2.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdDelegado", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sIdCliente", System.Data.SqlDbType.VarChar, 20),
            new System.Data.SqlClient.SqlParameter("@sIdDestinatario", System.Data.SqlDbType.VarChar, 20),
            new System.Data.SqlClient.SqlParameter("@sIdTipoCampanya", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@dFechaPedido", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@sIdPedido", System.Data.SqlDbType.VarChar, 12),
            new System.Data.SqlClient.SqlParameter("@sIdTipoPedido", System.Data.SqlDbType.VarChar, 4),
            new System.Data.SqlClient.SqlParameter("@counter", System.Data.SqlDbType.Int, 4)});
            // 
            // labelGradient111
            // 
            this.labelGradient111.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelGradient111.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGradient111.ForeColor = System.Drawing.Color.White;
            this.labelGradient111.GradientColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.labelGradient111.GradientColorTwo = System.Drawing.Color.White;
            this.labelGradient111.Location = new System.Drawing.Point(4, 18);
            this.labelGradient111.Name = "labelGradient111";
            this.labelGradient111.Size = new System.Drawing.Size(505, 18);
            this.labelGradient111.TabIndex = 38;
            this.labelGradient111.Text = "Ultimos pedidos                                  0";
            this.labelGradient111.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelGradient2222
            // 
            this.labelGradient2222.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGradient2222.ForeColor = System.Drawing.Color.White;
            this.labelGradient2222.GradientColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.labelGradient2222.GradientColorTwo = System.Drawing.Color.White;
            this.labelGradient2222.Location = new System.Drawing.Point(4, 128);
            this.labelGradient2222.Name = "labelGradient2222";
            this.labelGradient2222.Size = new System.Drawing.Size(496, 18);
            this.labelGradient2222.TabIndex = 39;
            this.labelGradient2222.Text = "Lineas del  Pedido Seleccionado";
            this.labelGradient2222.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.labelGradient1);
            this.panel1.Controls.Add(this.lblCounterLineas);
            this.panel1.Controls.Add(this.dgCabecerasPedidos);
            this.panel1.Controls.Add(this.dgLineasPedidos);
            this.panel1.Controls.Add(this.labelGradient2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(509, 245);
            this.panel1.TabIndex = 40;
            // 
            // labelGradient1
            // 
            this.labelGradient1.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelGradient1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGradient1.ForeColor = System.Drawing.Color.White;
            this.labelGradient1.GradientColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.labelGradient1.GradientColorTwo = System.Drawing.Color.White;
            this.labelGradient1.Location = new System.Drawing.Point(0, 0);
            this.labelGradient1.Name = "labelGradient1";
            this.labelGradient1.Size = new System.Drawing.Size(505, 18);
            this.labelGradient1.TabIndex = 41;
            this.labelGradient1.Text = "Ultimos pedidos                                  0";
            this.labelGradient1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCounterLineas
            // 
            this.lblCounterLineas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.lblCounterLineas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCounterLineas.ForeColor = System.Drawing.Color.Black;
            this.lblCounterLineas.Location = new System.Drawing.Point(440, 128);
            this.lblCounterLineas.Name = "lblCounterLineas";
            this.lblCounterLineas.Size = new System.Drawing.Size(60, 18);
            this.lblCounterLineas.TabIndex = 40;
            this.lblCounterLineas.Text = "0";
            this.lblCounterLineas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelGradient2
            // 
            this.labelGradient2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGradient2.ForeColor = System.Drawing.Color.White;
            this.labelGradient2.GradientColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.labelGradient2.GradientColorTwo = System.Drawing.Color.White;
            this.labelGradient2.Location = new System.Drawing.Point(0, 128);
            this.labelGradient2.Name = "labelGradient2";
            this.labelGradient2.Size = new System.Drawing.Size(496, 18);
            this.labelGradient2.TabIndex = 42;
            this.labelGradient2.Text = "Lineas del  Pedido Seleccionado";
            this.labelGradient2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ucUltimoPedido
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Controls.Add(this.panel1);
            this.Name = "ucUltimoPedido";
            this.Size = new System.Drawing.Size(509, 245);
            this.Load += new System.EventHandler(this.UltimoPedido_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgLineasPedidos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPedidos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgCabecerasPedidos)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void cargar_grids ()
		{
			//Refrescar Contador de registros
			try
			{
				this.labelGradient1.Text = "Ultimos "+Clases.Configuracion.iNumRegCRM+" pedidos";
				refrescar_lineas ();
			}
			catch(Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex.Message);
			}
		}

		private void UltimoPedido_Load(object sender, System.EventArgs e)
		{
			GESTCRM.Utiles.Formatear_DataGrid(dgCabecerasPedidos,"C",null);
			GESTCRM.Utiles.Formatear_DataGrid(dgLineasPedidos,"C",null);

			cargar_grids ();
		}

		private void dgCabecerasPedidos_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			if (dgCabecerasPedidos.CurrentRowIndex != -1 && dgCabecerasPedidos.CurrentRowIndex != row_dgCabecerasPedidos)
			{
				row_dgCabecerasPedidos = dgCabecerasPedidos.CurrentRowIndex;
				Utiles.Seleccionar_UnaFilaDataGrid(dgCabecerasPedidos,row_dgCabecerasPedidos,int.Parse(dsPedidos.ListaBuscaPedidos.Rows.Count.ToString()));
			}
		}

		private void dgCabecerasPedidos_CurrentCellChanged(object sender, System.EventArgs e)
		{
			//Estilo datagrid
			GESTCRM.Utiles.Seleccionar_UnaFilaDataGrid (dgCabecerasPedidos,dgCabecerasPedidos.CurrentRowIndex,dsPedidos.ListaBuscaPedidos.Rows.Count);

			//Limpiar
			this.dsPedidos.ListaLineasPedido.Rows.Clear();

			//Continuara solo si hay registros de cabecera
			if (dsPedidos.ListaBuscaPedidos.Rows.Count > 0)
				refrescar_lineas ();
		}


		private void refrescar_lineas()
		{
			if (this.dsPedidos.ListaBuscaPedidos.Rows.Count > 0)
			{
				this.dsPedidos.ListaLineasPedido.Rows.Clear();
                if (dgCabecerasPedidos.CurrentRowIndex > -1) //---- GSG (31/05/2013)
                {
                    sqldaListaLineasPedidos.SelectCommand.Parameters["@sIdPedido"].Value = dgCabecerasPedidos[dgCabecerasPedidos.CurrentRowIndex, 0].ToString();
                    sqldaListaLineasPedidos.Fill(dsPedidos.ListaLineasPedido);
                    lblCounterLineas.Text = dsPedidos.ListaLineasPedido.Rows.Count.ToString();
                }
			}
		}

        //---- GSG (08/11/2011)
        /*private void init_connection()
        {
            if (bConectado)
                return;

            Clases.Configuracion.Carga();

            try
            {
                Conn.ConnectionString = Clases.Configuracion.sqlCadenaCon;

                //"data source=NETDC;initial catalog=GESTCRMCL;persist security info=False;user id=sa;packet size=4096";
                sqldaListaBuscaPedidos.SelectCommand.Connection = Conn;
                sqldaListaLineasPedidos.SelectCommand.Connection = Conn;

                bConectado = true;
            }
            catch (Exception ev)
            {
                //MessageBox.Show ("Error en evento txtDestinatarioSAP_Leave"+ev.ToString());
                Mensajes.ShowError("Error en evento txtDestinatarioSAP_Leave: " + ev.ToString());
            }
        }
        */
        //private void init_connection()
        //{
        //    System.Data.SqlClient.SqlConnection Conn;

        //    System.Configuration.AppSettingsReader configurationAppSettings = new System.Configuration.AppSettingsReader();
        //    Conn = new System.Data.SqlClient.SqlConnection();
        //    Conn.ConnectionString = ((string)(configurationAppSettings.GetValue("sConn", typeof(string))));

        //    //this.Conn.ConnectionString = GESTCRM.Clases.Configuracion.sqlCadenaCon;
        //    Conn.FireInfoMessageEventOnUserErrors = false;

        //    this.sqlSelectCommand1.Connection = Conn;
        //    this.sqlSelectCommand2.Connection = Conn;
        //}
        //---- FI GSG

        public void ultimos_pedidos_de(string sIdCliente)
        {
            if (sIdCliente == "")
            {
                this.dsPedidos.ListaBuscaPedidos.Rows.Clear();
                this.dsPedidos.ListaLineasPedido.Rows.Clear();
                this.lblCounterLineas.Text = "0";
                return;
            }

            //---- GSG (08/11/2011)
            //init_connection();
            
            //---- FI GSG

            //Buscar los pedidos de este año para sIdCliente ordenados por fecha pedido.
            this.dsPedidos.ListaBuscaPedidos.Rows.Clear();
            this.dsPedidos.ListaLineasPedido.Rows.Clear();
            sqldaListaBuscaPedidos.SelectCommand.Parameters["@iIdDelegado"].Value = -1;  //Clases.Configuracion.iIdDelegado;
            sqldaListaBuscaPedidos.SelectCommand.Parameters["@sIdCliente"].Value = sIdCliente;
            sqldaListaBuscaPedidos.SelectCommand.Parameters["@sIdDestinatario"].Value = null;
            sqldaListaBuscaPedidos.SelectCommand.Parameters["@sIdTipoCampanya"].Value = "-2";
            sqldaListaBuscaPedidos.SelectCommand.Parameters["@dFechaPedido"].Value = null;
            sqldaListaBuscaPedidos.SelectCommand.Parameters["@sIdPedido"].Value = null;
            sqldaListaBuscaPedidos.SelectCommand.Parameters["@sIdTipoPedido"].Value = null;
            //Modificado por VCS fecha:31/01/2008
            sqldaListaBuscaPedidos.SelectCommand.Parameters["@counter"].Value = Clases.Configuracion.iNumRegCRM;
            sqldaListaBuscaPedidos.Fill(dsPedidos.ListaBuscaPedidos);
            //---- GSG (08/11/2011)
            //conn.Close();
            //---- FI GSG



            //Como solo queremos ver los n primeros:
            //GESTCRM.Utiles.Row_Count (this, dgCabecerasPedidos, (int)Clases.Configuracion.iNumRegCRM); //Ya vienen acotados por el SP

            refrescar_lineas();
        }


        
		

	}
}