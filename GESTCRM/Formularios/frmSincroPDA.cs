using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlTypes;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;  
using GESTCRM.PDA.CFUtils; 
using GESTCRM;
using GESTCRM.DataSets;
using GESTCRM.Formularios.DataSets;

namespace GESTCRM.Formularios
{
	/// <summary>
	/// Descripción breve de Form1.
	/// </summary>
	public class frmSincroPDA : System.Windows.Forms.Form
	{
		#region Controles y Constantes

        private System.Data.SqlClient.SqlConnection sqlConn;
        private System.Windows.Forms.Button btnIniciar;
		private System.Windows.Forms.Panel pnlSincro;
		private System.Windows.Forms.Label lblPaso;
		private System.Windows.Forms.Label lblTotal;
		private System.Windows.Forms.ProgressBar pgbPaso;
		private System.Windows.Forms.ProgressBar pgbTotal;
		private System.Windows.Forms.Panel pnlCabSincro;
		private System.Windows.Forms.Label lblCabSincro;
		private System.Windows.Forms.Label lblPaso2;
		private System.Windows.Forms.Label lblPaso1;
		private System.Data.SqlClient.SqlCommand sqlCmdFUSPDA;
		private System.Windows.Forms.PictureBox pcbPaso2;
		private System.Windows.Forms.PictureBox pcbPaso1;
		private Config Config;
		private System.Windows.Forms.Button btSalir;
		private RAPI PDAConnect = new RAPI() ;
		private System.Windows.Forms.Label lblPaso5;
		private System.Windows.Forms.PictureBox pcbPaso5;
		private System.Windows.Forms.Label lblPaso4;
		private System.Windows.Forms.Label lblPaso3;
		private System.Windows.Forms.PictureBox pcbPaso3;
		private System.Windows.Forms.PictureBox pcbPaso4;
		private System.Data.SqlClient.SqlCommand sqlCmdUpdPedidosLin;
		private System.Data.SqlClient.SqlCommand sqlCmdUpdProxObj;
		private System.Data.SqlClient.SqlCommand sqlCmdUpdRepActAten;
		private System.Data.SqlClient.SqlCommand sqlCmdUpdRepPed;
		private System.Data.SqlClient.SqlCommand sqlCmdUpdRepCab;
		private System.Data.SqlClient.SqlCommand sqlCmdUpdRepGad;
		private System.Data.SqlClient.SqlCommand sqlCmdUpdPedidosCab;
		private System.Data.SqlClient.SqlCommand sqlCmdUpdRepActCli;
		private dsDatosCLI dsDatosCLI;
		private dsDatosPDA dsDatosPDA;
		private System.Data.SqlClient.SqlCommand sqlCmdUpdConfig;
		private System.Data.SqlClient.SqlCommand sqlCmdFinSincro;
		private System.Data.SqlClient.SqlCommand sqlCmdUpdAtencionesNotasGastos;
		private System.Data.SqlClient.SqlCommand sqlCmdUpdNotasGastosCab;
		private System.Data.SqlClient.SqlCommand sqlCmdUpdaNotasGastosLin;
		private System.Data.SqlClient.SqlCommand sqlCmdUpdAccionesMktCliente;
		private System.Data.SqlClient.SqlCommand sqlCmdUpdAtencionesComerciales;
        private System.Data.SqlClient.SqlCommand sqlCmdUpdAtencionesProductos;
		private System.Data.SqlClient.SqlCommand SqlCmdGetSincroEstructuraBDPDA;
        //---- GSG (26/05/2011)
        private System.Data.SqlClient.SqlCommand sqlCmdUpdContactosClientesSAP;
        //---- FI GSG
        private SqlCommand sqlCmdResetSincroPDA;
		/// <summary>
		/// Variable del diseñador requerida.
		/// </summary>
		private System.ComponentModel.Container components = null;

		#endregion 

		public frmSincroPDA()
		{
			InitializeComponent();

            SaveXMLSchemas();
		}


		/// <summary>
		/// Limpiar los recursos que se estén utilizando.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}


		#region Código generado por el Diseñador de Windows Forms
		/// <summary>
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido del método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{
            System.Configuration.AppSettingsReader configurationAppSettings = new System.Configuration.AppSettingsReader();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSincroPDA));
            this.sqlConn = new System.Data.SqlClient.SqlConnection();
            this.btSalir = new System.Windows.Forms.Button();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.pnlSincro = new System.Windows.Forms.Panel();
            this.lblPaso4 = new System.Windows.Forms.Label();
            this.pcbPaso4 = new System.Windows.Forms.PictureBox();
            this.lblPaso3 = new System.Windows.Forms.Label();
            this.pcbPaso3 = new System.Windows.Forms.PictureBox();
            this.lblPaso = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.pgbPaso = new System.Windows.Forms.ProgressBar();
            this.pgbTotal = new System.Windows.Forms.ProgressBar();
            this.lblPaso5 = new System.Windows.Forms.Label();
            this.lblPaso2 = new System.Windows.Forms.Label();
            this.lblPaso1 = new System.Windows.Forms.Label();
            this.pcbPaso5 = new System.Windows.Forms.PictureBox();
            this.pcbPaso2 = new System.Windows.Forms.PictureBox();
            this.pcbPaso1 = new System.Windows.Forms.PictureBox();
            this.pnlCabSincro = new System.Windows.Forms.Panel();
            this.lblCabSincro = new System.Windows.Forms.Label();
            this.sqlCmdFUSPDA = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdPedidosLin = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdProxObj = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdRepActAten = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdRepPed = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdRepCab = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdRepGad = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdPedidosCab = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdRepActCli = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdConfig = new System.Data.SqlClient.SqlCommand();
            //---- GSG (26/05/2011)
            this.sqlCmdUpdContactosClientesSAP = new System.Data.SqlClient.SqlCommand();
            //---- FI GSG
            this.sqlCmdFinSincro = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdAtencionesNotasGastos = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdNotasGastosCab = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdaNotasGastosLin = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdAccionesMktCliente = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdAtencionesComerciales = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdAtencionesProductos = new System.Data.SqlClient.SqlCommand();
            this.SqlCmdGetSincroEstructuraBDPDA = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdResetSincroPDA = new System.Data.SqlClient.SqlCommand();
            this.pnlSincro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbPaso4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbPaso3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbPaso5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbPaso2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbPaso1)).BeginInit();
            this.pnlCabSincro.SuspendLayout();
            this.SuspendLayout();
            // 
            // sqlConn
            // 
            //this.sqlConn.ConnectionString = ((string)(configurationAppSettings.GetValue("sConn", typeof(string))));//---- GSG (10/09/2014)
            this.sqlConn = Utiles._connection;
            this.sqlConn.FireInfoMessageEventOnUserErrors = false;
            // 
            // btSalir
            // 
            this.btSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSalir.Image = global::GESTCRM.Properties.Resources.cancel_032x032;
            this.btSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btSalir.Location = new System.Drawing.Point(315, 275);
            this.btSalir.Name = "btSalir";
            this.btSalir.Size = new System.Drawing.Size(110, 40);
            this.btSalir.TabIndex = 40;
            this.btSalir.Text = "Cancelar";
            this.btSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btSalir.UseVisualStyleBackColor = true;
            this.btSalir.Click += new System.EventHandler(this.btSalir_Click);
            // 
            // btnIniciar
            // 
            this.btnIniciar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIniciar.Image = global::GESTCRM.Properties.Resources.reload_032x032;
            this.btnIniciar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIniciar.Location = new System.Drawing.Point(105, 275);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(100, 40);
            this.btnIniciar.TabIndex = 39;
            this.btnIniciar.Text = "Iniciar  ";
            this.btnIniciar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnIniciar.UseVisualStyleBackColor = true;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // pnlSincro
            // 
            this.pnlSincro.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlSincro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSincro.Controls.Add(this.lblPaso4);
            this.pnlSincro.Controls.Add(this.pcbPaso4);
            this.pnlSincro.Controls.Add(this.lblPaso3);
            this.pnlSincro.Controls.Add(this.pcbPaso3);
            this.pnlSincro.Controls.Add(this.lblPaso);
            this.pnlSincro.Controls.Add(this.lblTotal);
            this.pnlSincro.Controls.Add(this.pgbPaso);
            this.pnlSincro.Controls.Add(this.pgbTotal);
            this.pnlSincro.Controls.Add(this.lblPaso5);
            this.pnlSincro.Controls.Add(this.lblPaso2);
            this.pnlSincro.Controls.Add(this.lblPaso1);
            this.pnlSincro.Controls.Add(this.pcbPaso5);
            this.pnlSincro.Controls.Add(this.pcbPaso2);
            this.pnlSincro.Controls.Add(this.pcbPaso1);
            this.pnlSincro.Controls.Add(this.pnlCabSincro);
            this.pnlSincro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlSincro.Location = new System.Drawing.Point(0, 0);
            this.pnlSincro.Name = "pnlSincro";
            this.pnlSincro.Size = new System.Drawing.Size(531, 262);
            this.pnlSincro.TabIndex = 31;
            this.pnlSincro.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlSincro_Paint);
            // 
            // lblPaso4
            // 
            this.lblPaso4.AutoSize = true;
            this.lblPaso4.Location = new System.Drawing.Point(32, 110);
            this.lblPaso4.Name = "lblPaso4";
            this.lblPaso4.Size = new System.Drawing.Size(245, 16);
            this.lblPaso4.TabIndex = 40;
            this.lblPaso4.Text = "4. Intercambiando información con PDA.";
            // 
            // pcbPaso4
            // 
            this.pcbPaso4.Image = ((System.Drawing.Image)(resources.GetObject("pcbPaso4.Image")));
            this.pcbPaso4.Location = new System.Drawing.Point(8, 110);
            this.pcbPaso4.Name = "pcbPaso4";
            this.pcbPaso4.Size = new System.Drawing.Size(16, 16);
            this.pcbPaso4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbPaso4.TabIndex = 41;
            this.pcbPaso4.TabStop = false;
            this.pcbPaso4.Visible = false;
            // 
            // lblPaso3
            // 
            this.lblPaso3.AutoSize = true;
            this.lblPaso3.Location = new System.Drawing.Point(32, 84);
            this.lblPaso3.Name = "lblPaso3";
            this.lblPaso3.Size = new System.Drawing.Size(153, 16);
            this.lblPaso3.TabIndex = 38;
            this.lblPaso3.Text = "3. Conectando con PDA.";
            // 
            // pcbPaso3
            // 
            this.pcbPaso3.Image = ((System.Drawing.Image)(resources.GetObject("pcbPaso3.Image")));
            this.pcbPaso3.Location = new System.Drawing.Point(8, 84);
            this.pcbPaso3.Name = "pcbPaso3";
            this.pcbPaso3.Size = new System.Drawing.Size(16, 16);
            this.pcbPaso3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbPaso3.TabIndex = 39;
            this.pcbPaso3.TabStop = false;
            this.pcbPaso3.Visible = false;
            // 
            // lblPaso
            // 
            this.lblPaso.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.lblPaso.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaso.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblPaso.Location = new System.Drawing.Point(7, 168);
            this.lblPaso.Name = "lblPaso";
            this.lblPaso.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.lblPaso.Size = new System.Drawing.Size(515, 20);
            this.lblPaso.TabIndex = 37;
            this.lblPaso.Text = "Progreso del Paso";
            this.lblPaso.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotal
            // 
            this.lblTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTotal.Location = new System.Drawing.Point(8, 214);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.lblTotal.Size = new System.Drawing.Size(514, 20);
            this.lblTotal.TabIndex = 36;
            this.lblTotal.Text = "Progreso Total";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pgbPaso
            // 
            this.pgbPaso.Location = new System.Drawing.Point(7, 189);
            this.pgbPaso.Name = "pgbPaso";
            this.pgbPaso.Size = new System.Drawing.Size(515, 16);
            this.pgbPaso.TabIndex = 35;
            // 
            // pgbTotal
            // 
            this.pgbTotal.Location = new System.Drawing.Point(8, 235);
            this.pgbTotal.Maximum = 600;
            this.pgbTotal.Name = "pgbTotal";
            this.pgbTotal.Size = new System.Drawing.Size(514, 16);
            this.pgbTotal.Step = 100;
            this.pgbTotal.TabIndex = 34;
            // 
            // lblPaso5
            // 
            this.lblPaso5.AutoSize = true;
            this.lblPaso5.Location = new System.Drawing.Point(32, 136);
            this.lblPaso5.Name = "lblPaso5";
            this.lblPaso5.Size = new System.Drawing.Size(272, 16);
            this.lblPaso5.TabIndex = 32;
            this.lblPaso5.Text = "5. Procesando informacion recibida de PDA.";
            // 
            // lblPaso2
            // 
            this.lblPaso2.AutoSize = true;
            this.lblPaso2.Location = new System.Drawing.Point(32, 58);
            this.lblPaso2.Name = "lblPaso2";
            this.lblPaso2.Size = new System.Drawing.Size(257, 16);
            this.lblPaso2.TabIndex = 26;
            this.lblPaso2.Text = "2. Generando información a enviar a PDA.";
            // 
            // lblPaso1
            // 
            this.lblPaso1.AutoSize = true;
            this.lblPaso1.Location = new System.Drawing.Point(32, 32);
            this.lblPaso1.Name = "lblPaso1";
            this.lblPaso1.Size = new System.Drawing.Size(303, 16);
            this.lblPaso1.TabIndex = 24;
            this.lblPaso1.Text = "1. Obteniendo la fecha de la última sincronización.";
            // 
            // pcbPaso5
            // 
            this.pcbPaso5.Image = ((System.Drawing.Image)(resources.GetObject("pcbPaso5.Image")));
            this.pcbPaso5.Location = new System.Drawing.Point(8, 136);
            this.pcbPaso5.Name = "pcbPaso5";
            this.pcbPaso5.Size = new System.Drawing.Size(16, 16);
            this.pcbPaso5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbPaso5.TabIndex = 33;
            this.pcbPaso5.TabStop = false;
            this.pcbPaso5.Visible = false;
            // 
            // pcbPaso2
            // 
            this.pcbPaso2.Image = ((System.Drawing.Image)(resources.GetObject("pcbPaso2.Image")));
            this.pcbPaso2.Location = new System.Drawing.Point(8, 58);
            this.pcbPaso2.Name = "pcbPaso2";
            this.pcbPaso2.Size = new System.Drawing.Size(16, 16);
            this.pcbPaso2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbPaso2.TabIndex = 27;
            this.pcbPaso2.TabStop = false;
            this.pcbPaso2.Visible = false;
            // 
            // pcbPaso1
            // 
            this.pcbPaso1.Image = ((System.Drawing.Image)(resources.GetObject("pcbPaso1.Image")));
            this.pcbPaso1.Location = new System.Drawing.Point(8, 32);
            this.pcbPaso1.Name = "pcbPaso1";
            this.pcbPaso1.Size = new System.Drawing.Size(16, 16);
            this.pcbPaso1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbPaso1.TabIndex = 25;
            this.pcbPaso1.TabStop = false;
            this.pcbPaso1.Visible = false;
            // 
            // pnlCabSincro
            // 
            this.pnlCabSincro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.pnlCabSincro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCabSincro.Controls.Add(this.lblCabSincro);
            this.pnlCabSincro.Location = new System.Drawing.Point(-1, -1);
            this.pnlCabSincro.Name = "pnlCabSincro";
            this.pnlCabSincro.Size = new System.Drawing.Size(531, 24);
            this.pnlCabSincro.TabIndex = 21;
            // 
            // lblCabSincro
            // 
            this.lblCabSincro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCabSincro.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblCabSincro.Location = new System.Drawing.Point(8, 1);
            this.lblCabSincro.Name = "lblCabSincro";
            this.lblCabSincro.Size = new System.Drawing.Size(320, 23);
            this.lblCabSincro.TabIndex = 0;
            this.lblCabSincro.Text = "Proceso de sincronización con PDA";
            // 
            // sqlCmdFUSPDA
            // 
            this.sqlCmdFUSPDA.CommandText = "[SincroFUSPDA]";
            this.sqlCmdFUSPDA.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdFUSPDA.Connection = this.sqlConn;
            this.sqlCmdFUSPDA.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@dFUS", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Output, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null)});
            // 
            // sqlCmdUpdPedidosLin
            // 
            this.sqlCmdUpdPedidosLin.CommandText = "[WSCliUpdPedidos_Lin]";
            this.sqlCmdUpdPedidosLin.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdPedidosLin.Connection = this.sqlConn;
            this.sqlCmdUpdPedidosLin.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@sIdPedido", System.Data.SqlDbType.VarChar, 12),
            new System.Data.SqlClient.SqlParameter("@iIdLinea", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sIdMaterial", System.Data.SqlDbType.VarChar, 18),
            new System.Data.SqlClient.SqlParameter("@iCantidad", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@fPrecio", System.Data.SqlDbType.Float, 8),
            new System.Data.SqlClient.SqlParameter("@sidTipoPosicion", System.Data.SqlDbType.VarChar, 4),
            new System.Data.SqlClient.SqlParameter("@bEntregado", System.Data.SqlDbType.Bit, 1),
            new System.Data.SqlClient.SqlParameter("@dFechaPreferente", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@sCentro", System.Data.SqlDbType.VarChar, 4),
            new System.Data.SqlClient.SqlParameter("@sAlmacen", System.Data.SqlDbType.VarChar, 4),
            new System.Data.SqlClient.SqlParameter("@fDescuento", System.Data.SqlDbType.Float, 8),
            new System.Data.SqlClient.SqlParameter("@iBonificacion", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@idCampanya", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@idArrastre", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@idGrupoMat", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@idPaquete", System.Data.SqlDbType.Int, 4)});
            // 
            // sqlCmdUpdProxObj
            // 
            this.sqlCmdUpdProxObj.CommandText = "[WSCliUpdProxObj]";
            this.sqlCmdUpdProxObj.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdProxObj.Connection = this.sqlConn;
            this.sqlCmdUpdProxObj.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdCentro", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdReport", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@tProxObj", System.Data.SqlDbType.VarChar, 300),
            new System.Data.SqlClient.SqlParameter("@dFecha", System.Data.SqlDbType.DateTime, 8)});
            // 
            // sqlCmdUpdRepActAten
            // 
            this.sqlCmdUpdRepActAten.CommandText = "[WSCliUpdRepActAten]";
            this.sqlCmdUpdRepActAten.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdRepActAten.Connection = this.sqlConn;
            this.sqlCmdUpdRepActAten.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdReport", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdAtencion", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iNumAtencion", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@fImporte", System.Data.SqlDbType.Float, 8)});
            // 
            // sqlCmdUpdRepPed
            // 
            this.sqlCmdUpdRepPed.CommandText = "[WSCliUpdRepPed]";
            this.sqlCmdUpdRepPed.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdRepPed.Connection = this.sqlConn;
            this.sqlCmdUpdRepPed.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdReport", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sIdPedido", System.Data.SqlDbType.VarChar, 12)});
            // 
            // sqlCmdUpdRepCab
            // 
            this.sqlCmdUpdRepCab.CommandText = "[WSCliUpdRepCab]";
            this.sqlCmdUpdRepCab.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdRepCab.Connection = this.sqlConn;
            this.sqlCmdUpdRepCab.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdReport", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdDelegado", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sIdReportTemp", System.Data.SqlDbType.VarChar, 15),
            new System.Data.SqlClient.SqlParameter("@sTipoRActividad", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@sIdTipoCliente", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@iIdCentro", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@dFecha", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@iHorario", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@tObjetivo", System.Data.SqlDbType.VarChar, 300),
            new System.Data.SqlClient.SqlParameter("@tProxObjetivo", System.Data.SqlDbType.VarChar, 300),
            new System.Data.SqlClient.SqlParameter("@tObservaciones", System.Data.SqlDbType.VarChar, 300),
            new System.Data.SqlClient.SqlParameter("@bPlanificacion", System.Data.SqlDbType.SmallInt, 2),
            new System.Data.SqlClient.SqlParameter("@dFUM", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt, 2),
            new System.Data.SqlClient.SqlParameter("@bEnviadoPDA", System.Data.SqlDbType.Bit),
            new System.Data.SqlClient.SqlParameter("@bEnviadoCEN", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, ""),
            new System.Data.SqlClient.SqlParameter("@dHoraInicio", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@dHoraFin", System.Data.SqlDbType.DateTime, 8)});
            // 
            // sqlCmdUpdRepGad
            // 
            this.sqlCmdUpdRepGad.CommandText = "[WSCliUpdRepGad]";
            this.sqlCmdUpdRepGad.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdRepGad.Connection = this.sqlConn;
            this.sqlCmdUpdRepGad.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdReport", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdAccion", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iCantidad", System.Data.SqlDbType.Int, 4)});
            // 
            // sqlCmdUpdPedidosCab
            // 
            this.sqlCmdUpdPedidosCab.CommandText = "[WSCliUpdPedidos_Cab]";
            this.sqlCmdUpdPedidosCab.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdPedidosCab.Connection = this.sqlConn;
            this.sqlCmdUpdPedidosCab.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@sIdPedido", System.Data.SqlDbType.VarChar, 12),
            new System.Data.SqlClient.SqlParameter("@sIdPedidoTemp", System.Data.SqlDbType.VarChar, 15),
            new System.Data.SqlClient.SqlParameter("@iIdDelegado", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sIdTipoPedido", System.Data.SqlDbType.VarChar, 4),
            new System.Data.SqlClient.SqlParameter("@sIdEstEntPedido", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@sIdEstFacPedido", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdDestinatario", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@dFechaPedido", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@dFechaPreferente", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@dFechaFijada", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@sOrgVentas", System.Data.SqlDbType.VarChar, 4),
            new System.Data.SqlClient.SqlParameter("@sGrupoVendedor", System.Data.SqlDbType.VarChar, 3),
            new System.Data.SqlClient.SqlParameter("@sCanal", System.Data.SqlDbType.VarChar, 2),
            new System.Data.SqlClient.SqlParameter("@sSector", System.Data.SqlDbType.VarChar, 2),
            new System.Data.SqlClient.SqlParameter("@fImporte", System.Data.SqlDbType.Float, 8),
            new System.Data.SqlClient.SqlParameter("@fDescuento", System.Data.SqlDbType.Float, 8),
            new System.Data.SqlClient.SqlParameter("@sIdTipoCampanya", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@tObservaciones", System.Data.SqlDbType.VarChar, 300),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt, 2),
            new System.Data.SqlClient.SqlParameter("@fFUM", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@bEnviadoPDA", System.Data.SqlDbType.Bit),
            new System.Data.SqlClient.SqlParameter("@bEnviadoCEN", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, "0"),
            new System.Data.SqlClient.SqlParameter("@fDescuentoCampanya", System.Data.SqlDbType.Float, 8),
            new System.Data.SqlClient.SqlParameter("@fDescuentoAdicional", System.Data.SqlDbType.Float, 8),
            new System.Data.SqlClient.SqlParameter("@fRentabilidad", System.Data.SqlDbType.Float, 8),
            new System.Data.SqlClient.SqlParameter("@iIdAccion", System.Data.SqlDbType.Int, 4)});
            // 
            // sqlCmdUpdRepActCli
            // 
            this.sqlCmdUpdRepActCli.CommandText = "[WSCliUpdRepActCli]";
            this.sqlCmdUpdRepActCli.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdRepActCli.Connection = this.sqlConn;
            this.sqlCmdUpdRepActCli.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdReport", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@tObservaciones", System.Data.SqlDbType.VarChar, 300),
            new System.Data.SqlClient.SqlParameter("@tObjetivos", System.Data.SqlDbType.VarChar, 300),
            new System.Data.SqlClient.SqlParameter("@tProxObj", System.Data.SqlDbType.VarChar, 300),
            new System.Data.SqlClient.SqlParameter("@bSustituto", System.Data.SqlDbType.Bit, 1)});
            // 
            // sqlCmdUpdConfig
            // 
            this.sqlCmdUpdConfig.CommandText = "[WSCliUpdConfig]";
            this.sqlCmdUpdConfig.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdConfig.Connection = this.sqlConn;
            this.sqlCmdUpdConfig.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdConfig", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sValor", System.Data.SqlDbType.VarChar, 50)});
            // 
            // sqlCmdFinSincro
            // 
            this.sqlCmdFinSincro.CommandText = "[SincroFIN]";
            this.sqlCmdFinSincro.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdFinSincro.Connection = this.sqlConn;
            this.sqlCmdFinSincro.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null)});
            // 
            // sqlCmdUpdAtencionesNotasGastos
            // 
            this.sqlCmdUpdAtencionesNotasGastos.CommandText = "WSCliUpdAtencionesNotasGastos_LinPDA";
            this.sqlCmdUpdAtencionesNotasGastos.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdAtencionesNotasGastos.Connection = this.sqlConn;
            this.sqlCmdUpdAtencionesNotasGastos.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@sIdNotaTemp", System.Data.SqlDbType.VarChar, 15),
            new System.Data.SqlClient.SqlParameter("@sIdReportTemp", System.Data.SqlDbType.VarChar, 15),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdAtencion", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iNumAtencion", System.Data.SqlDbType.Int, 4)});
            // 
            // sqlCmdUpdNotasGastosCab
            // 
            this.sqlCmdUpdNotasGastosCab.CommandText = "dbo.[WSCliUpdNotasGastos_Cab]";
            this.sqlCmdUpdNotasGastosCab.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdNotasGastosCab.Connection = this.sqlConn;
            this.sqlCmdUpdNotasGastosCab.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@sIdNotaTemp", System.Data.SqlDbType.VarChar, 15),
            new System.Data.SqlClient.SqlParameter("@iIdDelegado", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@dFecha", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@bVisa", System.Data.SqlDbType.TinyInt, 1),
            new System.Data.SqlClient.SqlParameter("@dFechaAprob", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@sUsuarioAprob", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@dFechaLiq", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@tObservaciones", System.Data.SqlDbType.VarChar, 2147483647),
            new System.Data.SqlClient.SqlParameter("@dFUM", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt, 2),
            new System.Data.SqlClient.SqlParameter("@bEnviadoPDA", System.Data.SqlDbType.Bit, 1),
            new System.Data.SqlClient.SqlParameter("@bEnviadoCEN", System.Data.SqlDbType.Bit, 1)});
            // 
            // sqlCmdUpdaNotasGastosLin
            // 
            this.sqlCmdUpdaNotasGastosLin.CommandText = "dbo.[WSCliUpdNotasGastos_Lin]";
            this.sqlCmdUpdaNotasGastosLin.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdaNotasGastosLin.Connection = this.sqlConn;
            this.sqlCmdUpdaNotasGastosLin.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@sIdNotaTemp", System.Data.SqlDbType.VarChar, 15),
            new System.Data.SqlClient.SqlParameter("@iIdGasto", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@fCantidad", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@fPrecio", System.Data.SqlDbType.Float, 8),
            new System.Data.SqlClient.SqlParameter("@tDescripcion", System.Data.SqlDbType.VarChar, 2147483647),
            new System.Data.SqlClient.SqlParameter("@sIdCentroCoste", System.Data.SqlDbType.VarChar, 10)});
            // 
            // sqlCmdUpdAccionesMktCliente
            // 
            this.sqlCmdUpdAccionesMktCliente.CommandText = "dbo.[WSCliUpdAccionesMarkClienteFromPDA]";
            this.sqlCmdUpdAccionesMktCliente.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdAccionesMktCliente.Connection = this.sqlConn;
            this.sqlCmdUpdAccionesMktCliente.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdAccion", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@dFechaEntrega", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@fCantidad", System.Data.SqlDbType.Float, 8),
            new System.Data.SqlClient.SqlParameter("@tObservaciones", System.Data.SqlDbType.VarChar, 2147483647),
            new System.Data.SqlClient.SqlParameter("@sCCoste", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@dFUM", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@bEnviadoCLI", System.Data.SqlDbType.Bit, 1),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt, 2),
            new System.Data.SqlClient.SqlParameter("@iIdDelegado", System.Data.SqlDbType.Int, 4)});
            // 
            // sqlCmdUpdAtencionesComerciales
            // 
            this.sqlCmdUpdAtencionesComerciales.CommandText = "WSCliUpdAtencionesComercialesFromPDA";
            this.sqlCmdUpdAtencionesComerciales.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdAtencionesComerciales.Connection = this.sqlConn;
            this.sqlCmdUpdAtencionesComerciales.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdAtencion", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sIdAtencionTemp", System.Data.SqlDbType.VarChar, 15),
            new System.Data.SqlClient.SqlParameter("@sIdAtencion", System.Data.SqlDbType.VarChar, 20),
            new System.Data.SqlClient.SqlParameter("@sDescripcion", System.Data.SqlDbType.VarChar, 50),
            new System.Data.SqlClient.SqlParameter("@tObservaciones", System.Data.SqlDbType.VarChar, 8000),
            new System.Data.SqlClient.SqlParameter("@sIdTipoAtencion", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@iIdDelegado", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sIdEstAtencion", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@fImportePrev", System.Data.SqlDbType.Float, 8),
            new System.Data.SqlClient.SqlParameter("@fImporteReal", System.Data.SqlDbType.Float, 8),
            new System.Data.SqlClient.SqlParameter("@dFechaCreacion", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@dFechaPrev", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@dFechaAprob1", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@dFechaAprob2", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@dFechaReal", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@dFechaLiq", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@dFechaCierre", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@dFUM", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt, 2),
            new System.Data.SqlClient.SqlParameter("@dFechaAprob3", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@dFechaAprob4", System.Data.SqlDbType.DateTime, 8)});
            // 
            // sqlCmdUpdAtencionesProductos
            // 
            this.sqlCmdUpdAtencionesProductos.CommandText = "[WSCliUpdAtencionesProductosFromPDA]";
            this.sqlCmdUpdAtencionesProductos.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdAtencionesProductos.Connection = this.sqlConn;
            this.sqlCmdUpdAtencionesProductos.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdAtencion", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sIdProducto", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@fPorcentaje", System.Data.SqlDbType.Float, 8)});
            // 
            // SqlCmdGetSincroEstructuraBDPDA
            // 
            this.SqlCmdGetSincroEstructuraBDPDA.CommandText = "dbo.[GetSincroEstructuraBDPDA]";
            this.SqlCmdGetSincroEstructuraBDPDA.CommandType = System.Data.CommandType.StoredProcedure;
            this.SqlCmdGetSincroEstructuraBDPDA.Connection = this.sqlConn;
            this.SqlCmdGetSincroEstructuraBDPDA.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null)});
            // 
            // sqlCmdResetSincroPDA
            // 
            this.sqlCmdResetSincroPDA.CommandText = "ResetSincroPDA";
            this.sqlCmdResetSincroPDA.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdResetSincroPDA.Connection = this.sqlConn;
            this.sqlCmdResetSincroPDA.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null)});

            //---- GSG (26/05/2011)
            // 
            // sqlCmdUpdContactosClientesSAP
            // 
            this.sqlCmdUpdContactosClientesSAP.CommandText = "dbo.[WSCliUpdContactosClientesSAP]";
            this.sqlCmdUpdContactosClientesSAP.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdContactosClientesSAP.Connection = this.sqlConn;
            this.sqlCmdUpdContactosClientesSAP.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdContacto", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sNombre", System.Data.SqlDbType.VarChar, 100),
            new System.Data.SqlClient.SqlParameter("@sIdCargoContacto", System.Data.SqlDbType.VarChar, 10),            
            new System.Data.SqlClient.SqlParameter("@dFAR", System.Data.SqlDbType.VarChar, 20),
            new System.Data.SqlClient.SqlParameter("@dFBR", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt, 2),
            new System.Data.SqlClient.SqlParameter("@dFUM", System.Data.SqlDbType.DateTime)});
            //---- FI GSG
            
            
            // 
            // frmSincroPDA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(531, 327);
            this.ControlBox = false;
            this.Controls.Add(this.btnIniciar);
            this.Controls.Add(this.btSalir);
            this.Controls.Add(this.pnlSincro);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmSincroPDA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sincronización con PDA";
            this.pnlSincro.ResumeLayout(false);
            this.pnlSincro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbPaso4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbPaso3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbPaso5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbPaso2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbPaso1)).EndInit();
            this.pnlCabSincro.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

        //RH
        private void SaveXMLSchemas()
        {           
            Config dsConfig = new Config();
            dsConfig.WriteXmlSchema(Application.StartupPath + "\\Config.xsd");

            dsDatosCLI dsDatosCLI = new dsDatosCLI();
            dsDatosCLI.WriteXmlSchema(Application.StartupPath + "\\dsDatosCLI.xsd");

            dsDatosPDA dsDatosPDA = new dsDatosPDA();
            dsDatosPDA.WriteXmlSchema(Application.StartupPath + "\\dsDatosPDA.xsd");
        }

		private bool TraspasoFicheros(string sRutaCli, string sRutaPDA,string sRutaRaizPDA)
		{
            // Copia los Archivos que hay en la PDA al Cliente
            PDAConnect.CopyFileFromDevice(sRutaCli + @"\dsDatosCLI.xml", sRutaPDA + @"\dsDatosCLI.xml", true);

			// Copia los Archivos que hay en SyncFolder a la PDA
			if(!PDAConnect.DeviceFileExists(sRutaPDA+@"\dsDatosPDA.xml"))
			{ 
				PDAConnect.CopyFileToDevice(sRutaCli+@"\dsDatosPDA.xml",sRutaPDA+@"\dsDatosPDA.xml",true);
			}
			else
			{
				//Mensaje de Error de Ruta de PDA no encontrada
				//MessageBox.Show("Tiene pendiente una sincronización en PDA.\n\n Ejecute GESTCRM-PDA.","Error de Sincronización PDA", System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information );
                Mensajes.ShowError("Error de Sincronización PDA.\nTiene pendiente una sincronización en PDA.\n\n Ejecute GESTCRM-PDA.");
				return false;
			}
			if(!PDAConnect.DeviceFileExists(sRutaPDA+@"\Config.xml"))
			{
				PDAConnect.CopyFileToDevice(sRutaCli+@"\Config.xml",sRutaPDA+@"\Config.xml",true);
			}
			else
			{
				//MessageBox.Show("Tiene pendientes una sincronización en PDA.\n Ejecute GESTCRM-PDA.","Error de Sincronización PDA",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information  );
                Mensajes.ShowError("Error de Sincronización PDA.\nTiene pendiente una sincronización en PDA.\n\n Ejecute GESTCRM-PDA.");
				return false;
			}

            //CopiarXSD("dsDatosCLI.xsd", Application.StartupPath, sRutaRaizPDA);
            //CopiarXSD("dsDatosPDA.xsd", Application.StartupPath, sRutaRaizPDA);
            //CopiarXSD("Config.xsd", Application.StartupPath, sRutaRaizPDA);

            CopiarXSD("dsDatosCLI.xsd", Application.StartupPath, sRutaPDA);
            CopiarXSD("dsDatosPDA.xsd", Application.StartupPath, sRutaPDA);
            CopiarXSD("Config.xsd", Application.StartupPath, sRutaPDA);	
		
			ComprobarCambiosEstructuraBDPDA(sRutaCli,sRutaPDA);
		
			return true;
		}
		
		private void CopiarXSD(string FitxerName,string sRutaCli, string sRutaPDA)
		{
			if (PDAConnect.DeviceFileExists( sRutaPDA+@"\" + FitxerName ))
			{
				PDAConnect.DeleteDeviceFile( sRutaPDA+@"\" + FitxerName );				
			}
			PDAConnect.CopyFileToDevice( sRutaCli+@"\" + FitxerName , sRutaPDA+@"\"+FitxerName ,true);
		}

		private void btnIniciar_Click(object sender, System.EventArgs e)
		{
			string Entitat = "";
			Cursor.Current=Cursors.WaitCursor;

			this.btnIniciar.Enabled=false;
			this.btSalir.Enabled = false;
			DateTime dFIni = DateTime.Now;
			DateTime dFUS ;
			Font fPaso = new Font("Microsoft Sans Serif", float.Parse("9,75"), FontStyle.Bold);
			string sRutaPDA = null;
			string sRutaCli = String.Empty;


			// Inincializacion Datasets
			dsDatosPDA = new dsDatosPDA();			

			this.dsDatosPDA.Clear();

			this.pgbPaso.Value=0;
			this.pgbTotal.Value=0;
			this.pgbTotal.Step =20;
			this.pgbTotal.Maximum =100; 

			// Paso 1 : Obtener  Fecha de sincronizacion de la tabla de configuracion
			try
			{
				this.pgbPaso.Step=25;
				this.Refresh();
				this.lblPaso.Text=this.lblPaso1.Text;
				this.pgbPaso.PerformStep();
				this.Refresh();
				this.lblPaso1.Font=fPaso;
				this.pgbPaso.PerformStep();
				this.Refresh();
                System.Windows.Forms.Application.DoEvents();

                //RH: Si la aplicación de PDA ha creado la BD desde cero, se debe forzar una sincronización completa
                if (ConectarPDA())
                {
                    string senyal = ObtenerRutaRaizAPP() + "resetportatildb.log";
                    if (PDAConnect.DeviceFileExists(senyal))
                    {
                        //---- GSG (10/09/2014)
                        //this.sqlConn.Open();
                        if (sqlConn.State == ConnectionState.Closed)
                            this.sqlConn.Open();

                        sqlCmdResetSincroPDA.ExecuteNonQuery();
                        sqlConn.Close();

                        //La borramos porque ya la utilizamos
                        PDAConnect.DeleteDeviceFile(senyal);
                    }
                }
                else
                {
                    Close();
                    return;
                }

                //---- GSG (10/09/2014)
                //this.sqlConn.Open();
                if (sqlConn.State == ConnectionState.Closed)
                    this.sqlConn.Open();


				this.sqlCmdFUSPDA.ExecuteNonQuery();
				dFUS = (DateTime)sqlCmdFUSPDA.Parameters["@dFUS"].Value ;
				this.sqlConn.Close(); 
				
				this.lblPaso1.Text+=" "+dFUS.ToString();


				this.pgbPaso.PerformStep();
				this.Refresh();
				this.pcbPaso1.Visible=true;
				this.pgbPaso.PerformStep();
				this.Refresh();
				this.pgbTotal.PerformStep();
				this.Refresh();
				System.Windows.Forms.Application.DoEvents();

			}
			catch (System.Data.SqlClient.SqlException syncError )
			{
				if (this.sqlConn.State == ConnectionState.Open ) this.sqlConn.Close();
			}

			// Paso 2 : Generar Datos para PDA
			try
			{
				this.pgbPaso.Step=50;
				this.Refresh();
				this.lblPaso.Text=this.lblPaso1.Text;
				this.lblPaso2.Font=fPaso;
				this.pgbPaso.PerformStep();
				this.Refresh();
				System.Windows.Forms.Application.DoEvents();

                sRutaCli = Application.StartupPath + ConfigurationManager.AppSettings["SyncFolder"];

				
				//Borra los Archivos de Datos
				if (System.IO.File.Exists(sRutaCli+@"\dsDatosPDA.xml"))
				{
					System.IO.File.Delete (sRutaCli+@"\dsDatosPDA.xml");
				}

				if (System.IO.File.Exists(sRutaCli+@"\Config.xml"))
				{
					System.IO.File.Delete (sRutaCli+@"\Config.xml");
				}

				if (this.sqlConn.State == ConnectionState.Closed ) this.sqlConn.Open();

				SqlDataAdapter da = null;

				//sqlDAGeneral.TableMappings.Add("Table","SincroTiposPDA");
				Entitat = "SincroTiposPDA";
				da = new SqlDataAdapter("SincroTiposPDA",sqlConn);
				da.SelectCommand.CommandTimeout = 360; 				
				da.Fill(dsDatosPDA,"SincroTiposPDA");			
			
				//sqlDAGeneral.TableMappings.Add("Table1","SincroLineasTiposPDA");
				Entitat = "SincroLineasTiposPDA";
				da = new SqlDataAdapter("SincroLineasTiposPDA",sqlConn);
				da.SelectCommand.CommandTimeout = 360;
				da.Fill(dsDatosPDA,"SincroLineasTiposPDA");

				//sqlDAGeneral.TableMappings.Add("Table2","SincroTiposPosPedidosSAPPDA");
				Entitat = "SincroTiposPosPedidosSAPPDA";
				da = new SqlDataAdapter("SincroTiposPosPedidosSAPPDA",sqlConn);
				da.SelectCommand.CommandTimeout = 360;
				da.Fill(dsDatosPDA,"SincroTiposPosPedidosSAPPDA");

				//sqlDAGeneral.TableMappings.Add("Table3","SincroAtencionesComercialesPDA");
				Entitat = "SincroAtencionesComercialesPDA";
				da = new SqlDataAdapter("SincroAtencionesComercialesPDA",sqlConn);
				da.SelectCommand.CommandTimeout = 360;
				da.Fill(dsDatosPDA,"SincroAtencionesComercialesPDA");

				//sqlDAGeneral.TableMappings.Add("Table4","SincroProductosPDA");
				Entitat = "SincroProductosPDA";
				da = new SqlDataAdapter("SincroProductosPDA",sqlConn);
				da.SelectCommand.CommandTimeout = 360;
				da.Fill(dsDatosPDA,"SincroProductosPDA");

				//sqlDAGeneral.TableMappings.Add("Table5","SincroMaterialesPDA");
				Entitat = "SincroMaterialesPDA";
				da = new SqlDataAdapter("SincroMaterialesPDA",sqlConn);
				da.SelectCommand.CommandTimeout = 360;
				da.Fill(dsDatosPDA,"SincroMaterialesPDA");

				//sqlDAGeneral.TableMappings.Add("Table6","SincroDelegadosPDA");
				Entitat = "SincroDelegadosPDA";
				da = new SqlDataAdapter("SincroDelegadosPDA",sqlConn);
				da.SelectCommand.CommandTimeout = 360;
				da.Fill(dsDatosPDA,"SincroDelegadosPDA");

				//sqlDAGeneral.TableMappings.Add("Table7","SincroCentrosPDA");
				Entitat = "SincroCentrosPDA";
				da = new SqlDataAdapter("SincroCentrosPDA",sqlConn);
				da.SelectCommand.CommandTimeout = 360;
				da.Fill(dsDatosPDA,"SincroCentrosPDA");

				//sqlDAGeneral.TableMappings.Add("Table8","SincroClientesPDA"); 
				Entitat = "SincroClientesPDA";
				da = new SqlDataAdapter("SincroClientesPDA",sqlConn);
				da.SelectCommand.CommandTimeout = 360;
				da.Fill(dsDatosPDA,"SincroClientesPDA");

				//sqlDAGeneral.TableMappings.Add("Table9","SincroClientes_COMPDA");
				Entitat = "SincroClientes_COMPDA";
				da = new SqlDataAdapter("SincroClientes_COMPDA",sqlConn);
				da.SelectCommand.CommandTimeout = 360;
				da.Fill(dsDatosPDA,"SincroClientes_COMPDA");

				//sqlDAGeneral.TableMappings.Add("Table10","SincroCentrosClientes_COMPDA");
				Entitat = "SincroCentrosClientes_COMPDA";
				da = new SqlDataAdapter("SincroCentrosClientes_COMPDA",sqlConn);
				da.SelectCommand.CommandTimeout = 360;
				da.Fill(dsDatosPDA,"SincroCentrosClientes_COMPDA");

				//sqlDAGeneral.TableMappings.Add("Table11","SincroClientes_SAPPDA");  
				Entitat = "SincroClientes_SAPPDA";
				da = new SqlDataAdapter("SincroClientes_SAPPDA",sqlConn);
				da.SelectCommand.CommandTimeout = 360;
				da.Fill(dsDatosPDA,"SincroClientes_SAPPDA");

				//sqlDAGeneral.TableMappings.Add("Table12","SincroPedidos_CabPDA");
				Entitat = "SincroPedidos_CabPDA";
				da = new SqlDataAdapter("SincroPedidos_CabPDA",sqlConn);
				da.SelectCommand.CommandTimeout = 360;
				da.Fill(dsDatosPDA,"SincroPedidos_CabPDA");

				//sqlDAGeneral.TableMappings.Add("Table13","SincroPedidos_LinPDA");
				Entitat = "SincroPedidos_LinPDA";
				da = new SqlDataAdapter("SincroPedidos_LinPDA",sqlConn);
				da.SelectCommand.CommandTimeout = 360;
				da.Fill(dsDatosPDA,"SincroPedidos_LinPDA");

				//sqlDAGeneral.TableMappings.Add("Table14","SincroRepActividad_CabPDA");
				Entitat = "SincroRepActividad_CabPDA";
				da = new SqlDataAdapter("SincroRepActividad_CabPDA",sqlConn);
				da.SelectCommand.CommandTimeout = 360;
				da.Fill(dsDatosPDA,"SincroRepActividad_CabPDA");

				//sqlDAGeneral.TableMappings.Add("Table15","SincroRepActividad_CliPDA");
				Entitat = "SincroRepActividad_CliPDA";
				da = new SqlDataAdapter("SincroRepActividad_CliPDA",sqlConn);
				da.SelectCommand.CommandTimeout = 360;
				da.Fill(dsDatosPDA,"SincroRepActividad_CliPDA");

				//sqlDAGeneral.TableMappings.Add("Table16","SincroRepActividad_AtenPDA");
				Entitat = "SincroRepActividad_AtenPDA";
				da = new SqlDataAdapter("SincroRepActividad_AtenPDA",sqlConn);
				da.SelectCommand.CommandTimeout = 360;
				da.Fill(dsDatosPDA,"SincroRepActividad_AtenPDA");

				//sqlDAGeneral.TableMappings.Add("Table17","SincroRepActividadCli_ProxObjPDA");
				Entitat = "SincroRepActividadCli_ProxObjPDA";
				da = new SqlDataAdapter("SincroRepActividadCli_ProxObjPDA",sqlConn);
				da.SelectCommand.CommandTimeout = 360;
				da.Fill(dsDatosPDA,"SincroRepActividadCli_ProxObjPDA");

				//sqlDAGeneral.TableMappings.Add("Table18","SincroRepActividad_PedPDA");
				Entitat = "SincroRepActividad_PedPDA";
				da = new SqlDataAdapter("SincroRepActividad_PedPDA",sqlConn);
				da.SelectCommand.CommandTimeout = 360;
				da.Fill(dsDatosPDA,"SincroRepActividad_PedPDA");

				//sqlDAGeneral.TableMappings.Add("Table19","SincroAccionesMarketingPDA");
				Entitat = "SincroAccionesMarketingPDA";
				da = new SqlDataAdapter("SincroAccionesMarketingPDA",sqlConn);
				da.SelectCommand.CommandTimeout = 360;
				da.Fill(dsDatosPDA,"SincroAccionesMarketingPDA");

				//sqlDAGeneral.TableMappings.Add("Table20","SincroRepActividad_GadPDA");
				Entitat = "SincroRepActividad_GadPDA";
				da = new SqlDataAdapter("SincroRepActividad_GadPDA",sqlConn);
				da.SelectCommand.CommandTimeout = 360;
				da.Fill(dsDatosPDA,"SincroRepActividad_GadPDA");


                //RH: Ya no se utiliza
                ////sqlDAGeneral.TableMappings.Add("Table21","SincroDescuento_CampanyasPDA");
                //Entitat = "SincroDescuento_CampanyasPDA";
                //da = new SqlDataAdapter("SincroDescuentoCampanyas",sqlConn);
                //da.SelectCommand.CommandTimeout = 360;
                //da.Fill(dsDatosPDA,"SincroDescuento_CampanyasPDA");

				//sqlDAGeneral.TableMappings.Add("Table22","SincroMaterialCampPDA");
				Entitat = "SincroMaterialCampPDA";
				da = new SqlDataAdapter("SincroMaterialCampPDA",sqlConn);
				da.SelectCommand.CommandTimeout = 360;
				da.Fill(dsDatosPDA,"SincroMaterialCampPDA");

				//sqlDAGeneral.TableMappings.Add("Table23","SincroGastosPDA");
				Entitat = "SincroGastosPDA";
				da = new SqlDataAdapter("SincroGastosPDA",sqlConn);
				da.SelectCommand.CommandTimeout = 360;
				da.Fill(dsDatosPDA,"SincroGastosPDA");

				//sqlDAGeneral.TableMappings.Add("Table24","SincroNotasGastosPDA");
				Entitat = "SincroNotasGastosPDA";
				da = new SqlDataAdapter("SincroNotasGastosPDA",sqlConn);
				da.SelectCommand.CommandTimeout = 360;
				da.Fill(dsDatosPDA,"SincroNotasGastosPDA");

				//sqlDAGeneral.TableMappings.Add("Table25","SincroNotasGastos_LinPDA");
				Entitat = "SincroNotasGastos_LinPDA";
				da = new SqlDataAdapter("SincroNotasGastos_LinPDA",sqlConn);
				da.SelectCommand.CommandTimeout = 360;
				da.Fill(dsDatosPDA,"SincroNotasGastos_LinPDA");

				//sqlDAGeneral.TableMappings.Add("Table26","SincroAtencionesNotasGastosPDA");
				Entitat = "SincroAtencionesNotasGastosPDA";
				da = new SqlDataAdapter("SincroAtencionesNotasGastosPDA",sqlConn);
				da.SelectCommand.CommandTimeout = 360;
				da.Fill(dsDatosPDA,"SincroAtencionesNotasGastosPDA");

				//sqlDAGeneral.TableMappings.Add("Table27","SincroAccionesMarkClientesPDA");
				Entitat = "SincroAccionesMarkClientesPDA";
				da = new SqlDataAdapter("SincroAccionesMarkClientesPDA",sqlConn);
				da.SelectCommand.CommandTimeout = 360;
				da.Fill(dsDatosPDA,"SincroAccionesMarkClientesPDA");

				//sqlDAGeneral.TableMappings.Add("Table28","SincroAtencionesProductosPDA");
				Entitat = "SincroAtencionesProductosPDA";
				da = new SqlDataAdapter("SincroAtencionesProductosPDA",sqlConn);
				da.SelectCommand.CommandTimeout = 360;
				da.Fill(dsDatosPDA,"SincroAtencionesProductosPDA");

				//sqlDAGeneral.TableMappings.Add("Table29","SincroInterlocutorClientes_SAPPDA");
				Entitat = "SincroInterlocutorClientes_SAPPDA";
				da = new SqlDataAdapter("SincroInterlocutorClientes_SAPPDA",sqlConn);
				da.SelectCommand.CommandTimeout = 360;
				da.Fill(dsDatosPDA,"SincroInterlocutorClientes_SAPPDA");

                //RH: Las quitamos porque ya no se usan
                ////sqlDAGeneral.TableMappings.Add("Table30","SincroCampanyasPedidoPDA");
                //Entitat = "SincroCampanyasPedidoPDA";
                //da = new SqlDataAdapter("SincroCampanyasPedidoPDA",sqlConn);
                //da.SelectCommand.CommandTimeout = 360;
                //da.Fill(dsDatosPDA,"SincroCampanyasPedidoPDA");

                //RH: CampanyasMultiples - Las quitamos porque ya no se usan
                ////sqlDAGeneral.TableMappings.Add("Table31","SincroCampanyasMultiplesPDA");
                //Entitat = "SincroCampanyasMultiplesPDA";
                //da = new SqlDataAdapter("SincroCampanyasMultiplesPDA",sqlConn);
                //da.SelectCommand.CommandTimeout = 360;
                //da.Fill(dsDatosPDA,"SincroCampanyasMultiplesPDA");	

				Entitat = "SincroMaterialRentabilidadPDA";
				da = new SqlDataAdapter("SincroMaterialRentabilidadPDA",sqlConn);
				da.SelectCommand.CommandTimeout = 360;
				da.Fill(dsDatosPDA,"SincroMaterialRentabilidadPDA");
	
				Entitat = "SincroTramosRentabilidad";
				da = new SqlDataAdapter("SincroTramosRentabilidad",sqlConn);
				da.SelectCommand.CommandTimeout = 360;
                da.Fill(dsDatosPDA, "SincroTramosRentabilidadPDA");

                Entitat = "SincroCampanyasPDA";
                da = new SqlDataAdapter("SincroCampanyasPDA", sqlConn);
                da.SelectCommand.CommandTimeout = 360;
                da.Fill(dsDatosPDA, "SincroCampanyasPDA");

                Entitat = "SincroMaterialCampPDA";
                da = new SqlDataAdapter("SincroMaterialCampPDA", sqlConn);
                da.SelectCommand.CommandTimeout = 360;
                da.Fill(dsDatosPDA, "SincroMaterialCampPDA");

                Entitat = "SincroArrastresPDA";
                da = new SqlDataAdapter("SincroArrastresPDA", sqlConn);
                da.SelectCommand.CommandTimeout = 360;
                da.Fill(dsDatosPDA, "SincroArrastresPDA");

                Entitat = "SincroPaquetesPDA";
                da = new SqlDataAdapter("SincroPaquetesPDA", sqlConn);
                da.SelectCommand.CommandTimeout = 360;
                da.Fill(dsDatosPDA, "SincroPaquetesPDA");

                Entitat = "SincroCampanyasCabeceraPDA";
                da = new SqlDataAdapter("SincroCampanyasCabeceraPDA", sqlConn);
                da.SelectCommand.CommandTimeout = 360;
                da.Fill(dsDatosPDA, "SincroCampanyasCabeceraPDA");
				
                //---- GSG (06/05/2011)
                Entitat = "SincroProductosCampanyaPDA";
                da = new SqlDataAdapter("SincroProductosCampanyaPDA", sqlConn);
                da.SelectCommand.CommandTimeout = 360;
                da.Fill(dsDatosPDA, "SincroProductosCampanyaPDA");

                Entitat = "SincroClubsAvisoPDA";
                da = new SqlDataAdapter("SincroClubsAvisoPDA", sqlConn);
                da.SelectCommand.CommandTimeout = 360;
                da.Fill(dsDatosPDA, "SincroClubsAvisoPDA");

                //---- FI GSG

				Entitat = "";

				//sqlDAGeneral.Fill(this.dsDatosPDA);

                //RH: Verificamos preventivamente si el subdirectorio existe
                DirectoryInfo diXml = new DirectoryInfo(sRutaCli);
                if (!diXml.Exists)
                {
                    diXml.Create();
                }

				if (dsDatosPDA != null)
				{
					// Escribe el XML en la carpeta especificada pot el valor "SyncFolder" del app.ini
					this.dsDatosPDA.WriteXml(sRutaCli+"dsDatosPDA.xml"); 
				}

				this.pgbPaso.PerformStep();
				this.Refresh();
				this.pcbPaso2.Visible=true;
				this.Refresh();
				System.Windows.Forms.Application.DoEvents();

				//CONFIGURACION

				Config = new Config();

				da = new SqlDataAdapter("SincroConfigPDA", sqlConn);
				da.Fill(this.Config, "Configuracion");

				//Por el momento el password sera desencriptado en texto plano, hasta tanto
				//no se agregue en cliente la funfigcionalidad de cambiar el password
				foreach (Config.ConfiguracionRow rwLine in Config.Configuracion.Rows)   
				{
					if (rwLine.iIdConfig == 4)
					{
						rwLine.sValor = "stada";
					}
				}

				// Escribe el XML en la carpeta especificada pot el valor "SyncFolder" del app.ini
				this.Config.WriteXml(sRutaCli+"Config.xml"); 

				da.Dispose();

				this.pgbPaso.PerformStep();
				this.Refresh();
				this.pgbTotal.PerformStep();
				this.Refresh();
				System.Windows.Forms.Application.DoEvents();

				// PASO 3 : Conectar con PDA
				this.pgbPaso.Step=50;
				this.Refresh();
				this.lblPaso.Text=this.lblPaso3.Text;
				this.lblPaso3.Font=fPaso;
				this.Refresh();

				System.Windows.Forms.Application.DoEvents();

				this.pgbTotal.PerformStep();
				this.pcbPaso3.Visible=true;
				this.Refresh();
				this.pgbTotal.PerformStep();
				this.Refresh();

				System.Windows.Forms.Application.DoEvents();

				this.pgbPaso.Step=50;
				this.Refresh();
				this.lblPaso.Text=this.lblPaso4.Text;
				this.lblPaso4.Font=fPaso;
				this.Refresh();

				System.Windows.Forms.Application.DoEvents();

            if (PDAConnect.Connected)
				{
               sRutaPDA = ObtenerRutaPDA(PDAConnect);

					string RutaPDABD = 	ObtenerRutaPDABD(PDAConnect);				

					if (!PDAConnect.DeviceFileExists(RutaPDABD + "\\GESTCRM_PDA.SDF"))
					{
						//MessageBox.Show("Debe Ejecutar primero la aplicación de la PDA para poder sincronizar con el portátil. Por el momento no se sincronizará ningún dato.","Error de Sincronización PDA",System.Windows.Forms.MessageBoxButtons.OK );
                        Mensajes.ShowError("Debe ejecutar primero la aplicación de la PDA para poder sincronizar con el portátil. Por el momento no se sincronizará ningún dato.");
					}
					else 
					{
					
						if(this.TraspasoFicheros(sRutaCli, sRutaPDA, ObtenerRutaRaizAPP()))
						{
							this.pgbTotal.PerformStep();
							this.pcbPaso4.Visible=true;
							this.Refresh();
							this.pgbTotal.PerformStep();
							this.Refresh();
							System.Windows.Forms.Application.DoEvents();

							// PASO 5 : Insertar informacion en Cliente
							this.pgbPaso.Step=50;
							this.Refresh();
							this.lblPaso.Text=this.lblPaso5.Text;
							this.lblPaso5.Font=fPaso;

							if (System.IO.File.Exists(sRutaCli+@"\dsDatosCLI.xml"))
							{
								dsDatosCLI = new dsDatosCLI();
								dsDatosCLI.ReadXml(sRutaCli+@"\dsDatosCLI.xml",XmlReadMode.IgnoreSchema);

								ActualizarDatos(dsDatosCLI);
							}

							this.pgbTotal.PerformStep();
							this.pcbPaso5.Visible=true;
							this.Refresh();
							this.pgbTotal.PerformStep();
							this.Refresh();
							System.Windows.Forms.Application.DoEvents();


							// PASO 6 : actualizar fecha de ultima Sincronizacion con PDA y borrar /mover
							//          los archivos procesados

							//Borra el Archivo de PDA si existe
							if (PDAConnect.DeviceFileExists(sRutaPDA+@"\dsDatosCLI.xml"))
							{
								PDAConnect.DeleteDeviceFile(sRutaPDA+@"\dsDatosCLI.xml"); 
							}

							//Mueve el Archivo a la carpeta Backup con el nombre original y la fecha del día
							if (System.IO.File.Exists(sRutaCli+@"\dsDatosCLI.xml"))
							{
								System.IO.File.Move (sRutaCli+@"\dsDatosCLI.xml",sRutaCli+@"dsDatosCLI"+DateTime.Now.Year.ToString()+DateTime.Now.Month.ToString()+DateTime.Now.Day.ToString()+DateTime.Now.Hour.ToString()+DateTime.Now.Minute.ToString()  +".xml");
							}

							//Actualiza las fechas en la tabla de configuracion y los bEnviadoPDA de los objetos
							if (this.sqlConn.State == ConnectionState.Closed ) this.sqlConn.Open();

							this.sqlCmdFinSincro.ExecuteNonQuery();  

							//Ejecuta el proceso de Actualización de la Aplicacion si es Necesario
							UpdateApp(sRutaPDA);
						}
					}
				}
				else
				{						
					//Mensaje de Error de Ruta de PDA no encontrada
					//MessageBox.Show("No se puede conectar con PDA para transferir los archivos.\n\nSalga de la aplicacion y vuelva a intentarlo.","Error de Sincronización PDA",System.Windows.Forms.MessageBoxButtons.OK );
                    Mensajes.ShowError("Error de Sincronización PDA. \nNo se puede conectar con la PDA para transferir los archivos. Salga de la aplicacion y vuelva a intentarlo.");
				}
			}
			catch (Exception syncError )
			{

				string misEntitat = "";
				if (Entitat != "")
				{
					misEntitat = "\n\nSe estaba tratando la entidad : " + Entitat;
				}

				Mensajes.ShowError("Error en Sincronización con PDA\n\n"+syncError.Message+misEntitat); 
				this.btSalir.Enabled = true;
			}
			finally
			{
				if (this.sqlConn.State == ConnectionState.Open ) this.sqlConn.Close();
				if (PDAConnect!=null)  PDAConnect.Dispose(); 
			}
			

			if (this.sqlConn.State == System.Data.ConnectionState.Open) this.sqlConn.Close();

			this.sqlConn.Dispose();
			PDAConnect.Dispose(); 
			System.Windows.Forms.Application.DoEvents();

			Mensajes.ShowInformation ("Ha finalizado el proceso de Sincronización con PDA.");

			Cursor.Current=Cursors.Default;
			this.btSalir.Enabled = true;
			Application.DoEvents();
			this.Close();

		}
		private void UpdateApp(string sRutaPDA)
		{
			string Linea;
			string[] Partes;
			string Origen;
			string Destino;

			if (System.IO.File.Exists(Application.StartupPath + @"\Actualizaciones\Pendientes\PDA\Update.txt" ))
			{
				//MessageBox.Show("Existe una Actualización para la Aplicación PDA\n\nAsegúrese que el Programa de PDA\n\nNo se está Ejecutando y Presione Aceptar" ,"Actualización PDA", System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information   );
                Mensajes.ShowError("Actualización PDA.\nExiste una actualización para la aplicación de PDA. " +
                    "Asegúrese de que el programa de PDA no se esté ejecutando y presione Aceptar.");

				StreamReader freader = File.OpenText( Application.StartupPath + @"\Actualizaciones\Pendientes\PDA\Update.txt" );
				while (( Linea = freader.ReadLine() ) != null )
				{
					Partes=Linea.Split('|');
					if (Partes.Length >1)
					{
						try
						{
							Origen=Partes.GetValue(0).ToString();
							Destino = Partes.GetValue(1).ToString(); 
							if (Destino.Trim() ==".") Destino="";
							Destino = sRutaPDA.Replace(@"\SincroFiles","")  + Destino +@"\"+Origen;
							if (PDAConnect.DeviceFileExists(Destino))PDAConnect.SetDeviceFileAttributes(Destino,GESTCRM.PDA.CFUtils.RAPI.RAPIFileAttributes.Archive);   
							PDAConnect.CopyFileToDevice(Application.StartupPath + @"\Actualizaciones\Pendientes\PDA\"+Origen,Destino,true);

						}
						catch (Exception E)
						{
							//MessageBox.Show("Han Ocurrido Errores en la Actualización\n De la Aplicación\n\n"+E.Message ,"Error de Actualización PDA", System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error  );
                            Mensajes.ShowError("Error de actualización PDA:\n\n" + E.Message);
							break;
						}
					}
				}


				freader.Close();
				System.IO.File.Delete(Application.StartupPath + @"\Actualizaciones\Pendientes\PDA\Update.txt");   
   
			}


//			try
//			{
//
//				string destdatospda = sRutaPDA +@"\dsDatosPDA.xsd";
//				if (PDAConnect.DeviceFileExists(destdatospda))PDAConnect.DeleteDeviceFile(destdatospda);
//				PDAConnect.CopyFileToDevice(System.Windows.Forms.Application.StartupPath + @"\dsDatosPDA.xsd",destdatospda);
//
//				string destconfig = sRutaPDA +@"\Config.xsd";
//				if (PDAConnect.DeviceFileExists(destconfig))PDAConnect.DeleteDeviceFile(destconfig);
//				PDAConnect.CopyFileToDevice(System.Windows.Forms.Application.StartupPath + @"\Config.xsd",destconfig);
//
//			}
//			catch(Exception ex)
//			{
//
//			}
		}

		/// <summary>
		/// Intenta establecer conexion con la PDA
		/// </summary>
		/// <returns>Retorna Verdadero si se establece conexion</returns>
		private bool ConectarPDA()
		{
			try
        
			{
				while (! PDAConnect.DevicePresent)
				{
					//if (System.Windows.Forms.DialogResult.Cancel == MessageBox.Show("Asegurese que la base de la PDA esta conectada al ordenador\nPresiones OK para Reintentar la conexion\nPresione Cancelar si no desea sincronizar en este momento.\n\nSi el Error persiste Contacte a HelpDesk\n", 
					//	"No se encuentra Dispositivo",System.Windows.Forms.MessageBoxButtons.OKCancel,System.Windows.Forms.MessageBoxIcon.Warning))
                    Mensajes.ShowError("No se encuentra el dispositivo PDA. Asegúrese de que esté conectado al ordenador");
                    if (Mensajes.ShowQuestion("¿Desea intentar nuevamente la conexión?\n\nSi el error persiste contacte a HelpDesk.") == DialogResult.No)
					{
						return false;
					}
				}
				//PDAConnect.Connect(false,10);
				PDAConnect.Connect(true,10);
				return true;
			}
			catch (Exception ex)
			{
				//MessageBox.Show("Se ha producido el siguiente error al conectarse a la PDA"+ ex.Message);
                Mensajes.ShowError("Se ha producido el siguiente error al conectarse a la PDA: " + ex.Message);
				return false;
			}			
		}

		private string InitialPDAPath
		{
			get 
			{   
				//return "\\Archivos de programa";
				//return "\\Storage Card\\Archivos de programa";
                string path = ConfigurationManager.AppSettings["InitialPDAPath"].ToString();
                return path;
			}
		}

		private string ObtenerRutaRaizAPP()
		{
			return InitialPDAPath + @"\GESTCRMPDA\";
		}

		/// <summary>
		/// Obtiene la Ruta del Dispositivo Remoto para copiar los archivos
		/// </summary>
		/// <param name="RAPI">Objeto de Conexion a PDA</param>
		/// <returns></returns>
		private string ObtenerRutaPDA(GESTCRM.PDA.CFUtils.RAPI RAPI)
		{
//			GESTCRM.PDA.CFUtils.RegistryKey   PDAReg = GESTCRM.PDA.CFUtils.Registry.LocalMachine;
//			string sPathPDA=null;
//			try
//			{
//				if (RAPI.Connected)
//				{
//					PDAReg = PDAReg.OpenSubKey("SOFTWARE\\Strategy\\GESTCRMPDA"); 
//					if (PDAReg!=null)
//					{
//						sPathPDA= PDAReg.GetValue("SyncFolder").ToString() ; 
//					}
//				}
//				else
//				{
//					sPathPDA = null;
//				}
//			}
//			catch 
//			{
//				return null;
//			}
			string sPathPDA= InitialPDAPath + "\\GESTCRMPDA\\SincroFiles";
			//string sPathPDA= "\\Storage Card\\Archivos de programa\\GESTCRMPDA\\SincroFiles";
			return sPathPDA;
		}

		private string ObtenerRutaPDABD(GESTCRM.PDA.CFUtils.RAPI RAPI)
		{
			//			GESTCRM.PDA.CFUtils.RegistryKey   PDAReg = GESTCRM.PDA.CFUtils.Registry.LocalMachine;
			//			string sPathPDA=null;
			//			try
			//			{
			//				if (RAPI.Connected)
			//				{
			//					PDAReg = PDAReg.OpenSubKey("SOFTWARE\\Strategy\\GESTCRMPDA"); 
			//					if (PDAReg!=null)
			//					{
			//						sPathPDA= PDAReg.GetValue("SyncFolder").ToString() ; 
			//					}
			//				}
			//				else
			//				{
			//					sPathPDA = null;
			//				}
			//			}
			//			catch 
			//			{
			//				return null;
			//			}

			string sPathPDA= InitialPDAPath + "\\GESTCRMPDA\\Datos";

			//string sPathPDA= "\\Storage Card\\Archivos de programa\\GESTCRMPDA\\SincroFiles";
			return sPathPDA;
		}
		/// <summary>
		/// Llamada a la actualizacion de datos en Cliente
		/// </summary>
		/// <param name="dsRec">DataSet con la definicion de datos de PDA</param>
		private void ActualizarDatos(dsDatosCLI dsRec)
		{
			System.Data.SqlClient.SqlTransaction thisTran=null;
			try
			{
				this.pgbPaso.Step = 11;
				this.pgbPaso.Value = 0;
				this.Refresh();
				ActualizaPedidos(dsRec);
				ActualizaReportes(dsRec);
				ActualizaNotasGastos(dsRec);
				ActualizaAtencionesComerciales(dsRec);
				ActualizaAccionesMktClientes(dsRec);
				ActualizaConfig(dsRec);
                //---- GSG (26/05/2011)
                ActualizaContactosClientesSAP(dsRec);
                //---- FI GSG
				this.pgbPaso.Value =100;
				this.Refresh();
			}
			catch (Exception MyExc)
			{
				if (thisTran!=null)  thisTran.Rollback();  
				throw(MyExc);
			}

		}
		/// <summary>
		/// Inserta en la BBDD de Cliente los Reportes que vienen de PDA
		/// </summary>
		/// <param name="dsRec">Dataset con la Definicion de Datos de PDA</param>
		private void ActualizaReportes(dsDatosCLI dsRec)
		{
			System.Data.SqlClient.SqlTransaction thisTran=null;
			string sElemento="";
			try
			{
				if (this.sqlConn.State == System.Data.ConnectionState.Closed)
                    this.sqlConn.Open();

				thisTran=sqlConn.BeginTransaction();

				#region RepActividadCab
				if (dsRec != null && dsRec.RepActividad_Cab.Rows.Count > 0)
				{
					sqlCmdUpdRepCab.Transaction = thisTran;
					sqlCmdUpdRepActCli.Transaction = thisTran;
					sqlCmdUpdRepActAten.Transaction = thisTran;
					sqlCmdUpdProxObj.Transaction = thisTran;
					sqlCmdUpdRepPed.Transaction = thisTran;
					sqlCmdUpdRepGad.Transaction = thisTran;
				
					foreach (dsDatosCLI.RepActividad_CabRow rwRCab in dsRec.RepActividad_Cab.Rows)
					{
						sElemento="RepActividadCab " + rwRCab.iIdReport;
						sqlCmdUpdRepCab.Parameters["@iIdReport"].Value = rwRCab.iIdReport; 
						sqlCmdUpdRepCab.Parameters["@iIdDelegado"].Value = rwRCab.iIdDelegado ; 
						sqlCmdUpdRepCab.Parameters["@sIdReportTemp"].Value = rwRCab.IssIdReportTempNull()?SqlString.Null:rwRCab.sIdReportTemp;
						sqlCmdUpdRepCab.Parameters["@sTipoRActividad"].Value = rwRCab.IssTipoRActividadNull()?SqlString.Null:rwRCab.sTipoRActividad;
						sqlCmdUpdRepCab.Parameters["@sIdTipoCliente"].Value = rwRCab.IssIdTipoClienteNull()?SqlString.Null:rwRCab.sIdTipoCliente; 
						sqlCmdUpdRepCab.Parameters["@iIdCentro"].Value = rwRCab.IsiIdCentroNull()?SqlInt32.Null:rwRCab.iIdCentro;
						sqlCmdUpdRepCab.Parameters["@dFecha"].Value = rwRCab.dFecha; 
						sqlCmdUpdRepCab.Parameters["@iHorario"].Value = rwRCab.IsiHorarioNull()?SqlString.Null:rwRCab.iHorario; 
						sqlCmdUpdRepCab.Parameters["@tObjetivo"].Value = rwRCab.IstObjetivoNull()?SqlString.Null:rwRCab.tObjetivo; 
						sqlCmdUpdRepCab.Parameters["@tProxObjetivo"].Value = rwRCab.IstProxObjetivoNull()?SqlString.Null:rwRCab.tProxObjetivo; 
						sqlCmdUpdRepCab.Parameters["@tObservaciones"].Value = rwRCab.IstObservacionesNull()?SqlString.Null:rwRCab.tObservaciones; 
						sqlCmdUpdRepCab.Parameters["@bPlanificacion"].Value = rwRCab.bPlanificacion; 
						//sqlCmdUpdRepCab.Parameters["@dFUM"].Value = rwRCab.dFUM; 
						// Se pone la fecha actual para garantizar la sincronización
						sqlCmdUpdRepCab.Parameters["@dFUM"].Value = DateTime.Now ; 
						sqlCmdUpdRepCab.Parameters["@iEstado"].Value = rwRCab.iEstado;
						sqlCmdUpdRepCab.Parameters["@bEnviadoCEN"].Value = 0; 
						sqlCmdUpdRepCab.Parameters["@bEnviadoPDA"].Value = 1;
                        sqlCmdUpdRepCab.Parameters["@dHoraInicio"].Value = rwRCab.dHoraInicio;
                        sqlCmdUpdRepCab.Parameters["@dHoraFin"].Value = rwRCab.dHoraFin; 

						this.sqlCmdUpdRepCab.ExecuteNonQuery();
					}
					#region RepActividad_cli
					foreach(dsDatosCLI.RepActividad_CliRow  rwRCli in dsRec.RepActividad_Cli.Rows  ) 
					{
						sElemento="RepActividadCli " + rwRCli.iIdReport;
						sqlCmdUpdRepActCli.Parameters["@iIdReport"].Value = rwRCli.iIdReport;
						sqlCmdUpdRepActCli.Parameters["@iIdCliente"].Value = rwRCli.iIdCliente;
						sqlCmdUpdRepActCli.Parameters["@tObservaciones"].Value = rwRCli.IstObservacionesNull()?SqlString.Null:rwRCli.tObservaciones; 
						sqlCmdUpdRepActCli.Parameters["@tObjetivos"].Value = rwRCli.IstObjetivosNull()?SqlString.Null:rwRCli.tObjetivos;
						sqlCmdUpdRepActCli.Parameters["@tProxObj"].Value = rwRCli.IstProxObjNull()?SqlString.Null:rwRCli.tProxObj;
						sqlCmdUpdRepActCli.Parameters["@bSustituto"].Value = rwRCli.bSustituto; 

						this.sqlCmdUpdRepActCli.ExecuteNonQuery();
					}

					#endregion
					#region RepActividadAten
					foreach(dsDatosCLI.RepActividad_AtenRow  rwRAten in dsRec.RepActividad_Aten.Rows  )
					{
						sElemento="RepActividadAten " + rwRAten.iIdReport;

						sqlCmdUpdRepActAten.Parameters["@iIdReport"].Value = rwRAten.iIdReport;
						sqlCmdUpdRepActAten.Parameters["@iIdCliente"].Value = rwRAten.iIdCliente;
						sqlCmdUpdRepActAten.Parameters["@iIdAtencion"].Value = rwRAten.iIdAtencion;
						sqlCmdUpdRepActAten.Parameters["@iNumAtencion"].Value = rwRAten.iNumAtencion; 
						sqlCmdUpdRepActAten.Parameters["@fImporte"].Value = rwRAten.fimporte; 

						this.sqlCmdUpdRepActAten.ExecuteNonQuery();
					}

					#endregion
					#region RepActividadCli_ProxObj
					foreach(dsDatosCLI.RepActividadCli_ProxObjRow  rwRObj in dsRec.RepActividadCli_ProxObj.Rows   )
					{
						sElemento="RepActividadCab " + rwRObj.iIdReport;

						sqlCmdUpdProxObj.Parameters["@iIdCentro"].Value = rwRObj.iIdCentro ;
						sqlCmdUpdProxObj.Parameters["@iIdCliente"].Value = rwRObj.iIdCliente ;
						sqlCmdUpdProxObj.Parameters["@iIdReport"].Value = rwRObj.iIdReport;
						sqlCmdUpdProxObj.Parameters["@tProxObj"].Value = rwRObj.tProxObj;
						sqlCmdUpdProxObj.Parameters["@dFecha"].Value = rwRObj.dFecha;

						this.sqlCmdUpdProxObj.ExecuteNonQuery();

					}
					#endregion
					#region Repactividad_Ped
					foreach(dsDatosCLI.RepActividad_PedRow  rwRPed in dsRec.RepActividad_Ped.Rows  )
					{
						sElemento="RepActividadPed " + rwRPed.iIdReport;

						sqlCmdUpdRepPed.Parameters["@iIdReport"].Value = rwRPed.iIdReport;
						sqlCmdUpdRepPed.Parameters["@sIdPedido"].Value = rwRPed.sIdPedido;  

						//Ricard 22 septembre 2008, el david m'ha demanat que tregui aquesta actualització, d'aquesta manera
						//els pedidos com que ara pujaran per GPRS no estiguin enllaçats mitjançant les activitats, ja que aquests
						//es consideraran ja com a pujats (pedidos)
						

						//Ricard 24 març 2009, ho descomento, he tret la FK de la BD de CL, per tal que pugin sense petar.
						this.sqlCmdUpdRepPed.ExecuteNonQuery();

					}

					#endregion					
					#region RepActividad_Gad
					foreach(dsDatosCLI.RepActividad_GadRow rwRGad in dsRec.RepActividad_Gad.Rows  )
					{
						sElemento="RepActividadGad " + rwRGad.iIdReport;
						sqlCmdUpdRepGad.Parameters["@iIdReport"].Value = rwRGad.iIdReport;
						sqlCmdUpdRepGad.Parameters["@iIdCliente"].Value = rwRGad.iIdCliente;
						sqlCmdUpdRepGad.Parameters["@iIdAccion"].Value = rwRGad.iIdAccion;
						sqlCmdUpdRepGad.Parameters["@iCantidad"].Value = rwRGad.iCantidad;

						this.sqlCmdUpdRepGad.ExecuteNonQuery();

					}
					#endregion
				}
				#endregion
				thisTran.Commit();

				this.pgbPaso.PerformStep();
				this.Refresh();
			}
			catch (Exception MyExc)
			{
				if (thisTran!=null)  thisTran.Rollback();  
				if (this.sqlConn.State == System.Data.ConnectionState.Open) this.sqlConn.Close();
				Mensajes.ShowError("Contacte con HelpDesk e indique el siguiente error de Sincronización:\n\n"+MyExc.Message+"\n\nEl error se ha producido en Actualizacion de Reportes, elemento " +sElemento.ToString());
				throw(MyExc);
			}

		}
		/// <summary>
		/// Inserta en la BBDD de Cliente los Pedidos recibidos de PDA
		/// </summary>
		/// <param name="dsRec">DataSet con la definicion de Datos de PDA</param>
		private void ActualizaPedidos(dsDatosCLI dsRec )
		{
			System.Data.SqlClient.SqlTransaction thisTran = null;
			string sElemento = "";
			try
			{
				if (this.sqlConn.State == System.Data.ConnectionState.Closed)
                    this.sqlConn.Open();

				#region Pedidos_Cab

				if (dsRec.Pedidos_Cab.Rows.Count > 0)
				{
					thisTran=sqlConn.BeginTransaction();
					
					sqlCmdUpdPedidosCab.Transaction = thisTran;
					sqlCmdUpdPedidosLin.Transaction = thisTran;
 
                    //sqlCmdUpdDelCampanyasPedido.Transaction = thisTran;
                    //sqlCmdUpdCampanyasPedido.Transaction = thisTran;

					foreach(dsDatosCLI.Pedidos_CabRow  rwPedC in dsRec.Pedidos_Cab.Rows  )
					{
						sElemento="PedidoCab "+rwPedC.sIdPedido;
						sqlCmdUpdPedidosCab.Parameters["@sIdPedido"].Value = rwPedC.sIdPedido;
						sqlCmdUpdPedidosCab.Parameters["@sIdPedidoTemp"].Value = rwPedC.IssIdPedidoTempNull()?SqlString.Null:rwPedC.sIdPedidoTemp; 
						sqlCmdUpdPedidosCab.Parameters["@iIdDelegado"].Value = rwPedC.iIdDelegado; 
						sqlCmdUpdPedidosCab.Parameters["@sIdTipoPedido"].Value = rwPedC.sIdTipoPedido;
                        sqlCmdUpdPedidosCab.Parameters["@sIdEstEntPedido"].Value = rwPedC.IssIdEstEntPedidoNull() ? SqlString.Null : rwPedC.sIdEstEntPedido;
                        sqlCmdUpdPedidosCab.Parameters["@sIdEstFacPedido"].Value = rwPedC.IssIdEstFacPedidoNull() ? SqlString.Null : rwPedC.sIdEstFacPedido;
						sqlCmdUpdPedidosCab.Parameters["@iIdCliente"].Value = rwPedC.iIdCliente;
						sqlCmdUpdPedidosCab.Parameters["@iIdDestinatario"].Value = rwPedC.iIdDestinatario;
						sqlCmdUpdPedidosCab.Parameters["@dFechaPedido"].Value = rwPedC.dFechaPedido; 
						sqlCmdUpdPedidosCab.Parameters["@dFechaPreferente"].Value = rwPedC.dFechaPreferente;
						sqlCmdUpdPedidosCab.Parameters["@dFechaFijada"].Value = rwPedC.dFechaFijada; 
						sqlCmdUpdPedidosCab.Parameters["@sOrgVentas"].Value = rwPedC.sOrgVentas;
						sqlCmdUpdPedidosCab.Parameters["@sGrupoVendedor"].Value = rwPedC.sGrupoVendedor;
						sqlCmdUpdPedidosCab.Parameters["@sCanal"].Value = rwPedC.sCanal;
						sqlCmdUpdPedidosCab.Parameters["@sSector"].Value = rwPedC.sSector;
						sqlCmdUpdPedidosCab.Parameters["@fImporte"].Value = rwPedC.fImporte; 
						// a O para que el calculo cuando lo muestra vaya bien sqlCmdUpdPedidosCab.Parameters["@fDescuento"].Value = rwPedC.fDescuento;
                        sqlCmdUpdPedidosCab.Parameters["@fDescuento"].Value = rwPedC.fDescuento; //0;
						sqlCmdUpdPedidosCab.Parameters["@sIdTipoCampanya"].Value = rwPedC.IssIdTipoCampanyaNull()?SqlString.Null:rwPedC.sIdTipoCampanya; 
						sqlCmdUpdPedidosCab.Parameters["@tObservaciones"].Value = rwPedC.IstObservacionesNull()?SqlString.Null:rwPedC.tObservaciones;
						sqlCmdUpdPedidosCab.Parameters["@iEstado"].Value = rwPedC.iEstado;
						//sqlCmdUpdPedidosCab.Parameters["@fFUM"].Value = rwPedC.fFUM;
						// Se pone con la fecha actual para garantizar la sincronizcion
						sqlCmdUpdPedidosCab.Parameters["@fFUM"].Value = DateTime.Now;
						sqlCmdUpdPedidosCab.Parameters["@bEnviadoCEN"].Value = 0;
						sqlCmdUpdPedidosCab.Parameters["@bEnviadoPDA"].Value = 1;
                        sqlCmdUpdPedidosCab.Parameters["@fDescuentoCampanya"].Value = rwPedC.fDescuentoCampanya;
                        sqlCmdUpdPedidosCab.Parameters["@fDescuentoAdicional"].Value = rwPedC.fDescuentoAdicional;
					    //---- GSG (24/05/2011)
                        sqlCmdUpdPedidosCab.Parameters["@fRentabilidad"].Value = rwPedC.fRentabilidad;
                        sqlCmdUpdPedidosCab.Parameters["@iIdAccion"].Value = rwPedC.iIdAccion;
                        //---- FI GSG

						sqlCmdUpdPedidosCab.ExecuteNonQuery();

                        //sqlCmdUpdDelCampanyasPedido.Parameters["@sIdPedido"].Value = rwPedC.sIdPedido;
                        //sqlCmdUpdDelCampanyasPedido.ExecuteNonQuery();
			
                        //foreach(dsDatosCLI.CampanyasPedidoRow rwPed in dsRec.CampanyasPedido.Select("sIdPedido = '" + rwPedC.sIdPedido + "'"))
                        //{
                        //    sqlCmdUpdCampanyasPedido.Parameters["@sIdPedido"].Value = rwPed.sIdPedido;
                        //    sqlCmdUpdCampanyasPedido.Parameters["@sIdCampanya"].Value = rwPed.sIdCampanya;
                        //    sqlCmdUpdCampanyasPedido.ExecuteNonQuery();
                        //}
					}

					#region Pedidos_Lin

					foreach(dsDatosCLI.Pedidos_LinRow rwLin in dsRec.Pedidos_Lin.Rows  )
					{
						sElemento="PedidoLin "+rwLin.sIdPedido;
						this.sqlCmdUpdPedidosLin.Parameters["@sIdPedido"].Value =rwLin.sIdPedido;  
						this.sqlCmdUpdPedidosLin.Parameters["@iIdLinea"].Value =rwLin.iIdLinea; 
						this.sqlCmdUpdPedidosLin.Parameters["@sIdMaterial"].Value =rwLin.sIdMaterial; 
						this.sqlCmdUpdPedidosLin.Parameters["@iCantidad"].Value =rwLin.iCantidad; 
						this.sqlCmdUpdPedidosLin.Parameters["@fPrecio"].Value =rwLin.fPrecio;
						this.sqlCmdUpdPedidosLin.Parameters["@sIdTipoPosicion"].Value =rwLin.sidTipoPosicion;
						this.sqlCmdUpdPedidosLin.Parameters["@bEntregado"].Value =rwLin.bEntregado; 
						this.sqlCmdUpdPedidosLin.Parameters["@dFechaPreferente"].Value =rwLin.dFechaPreferente; 
						this.sqlCmdUpdPedidosLin.Parameters["@sCentro"].Value =rwLin.sCentro; 
						this.sqlCmdUpdPedidosLin.Parameters["@sAlmacen"].Value =rwLin.sAlmacen; 
						this.sqlCmdUpdPedidosLin.Parameters["@fDescuento"].Value =rwLin.fDescuento;
                        this.sqlCmdUpdPedidosLin.Parameters["@iBonificacion"].Value = rwLin.iBonificacion;
                        this.sqlCmdUpdPedidosLin.Parameters["@idCampanya"].Value = rwLin.idCampanya;
                        this.sqlCmdUpdPedidosLin.Parameters["@idArrastre"].Value = rwLin.idArrastre;
                        this.sqlCmdUpdPedidosLin.Parameters["@idGrupoMat"].Value = rwLin.idGrupoMat;
                        this.sqlCmdUpdPedidosLin.Parameters["@idPaquete"].Value = rwLin.idPaquete;
						
						sqlCmdUpdPedidosLin.ExecuteNonQuery();

					}
					 
					#endregion

					thisTran.Commit();
				}

				#endregion

				this.pgbPaso.PerformStep();
				this.Refresh();
			}
			catch (Exception MyExc)
			{
				if (thisTran!=null) thisTran.Rollback();  
				if (this.sqlConn.State == System.Data.ConnectionState.Open ) this.sqlConn.Close();
				Mensajes.ShowError("Contacte con HelpDesk e indique el siguiente error de Sincronización:\n\n"+MyExc.Message+"\n\nEl error se ha producido en Actualización de Pedidos, elemento " +sElemento.ToString());
				throw(MyExc);
			}
		}

		private void ActualizaAccionesMktClientes(dsDatosCLI dsRec )
		{
			System.Data.SqlClient.SqlTransaction thisTran=null;
			string sElemento="";
			try
			{
				if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
				#region Acciones MMKT Cliente
				if (dsRec.AccionesMarkClientes.Rows.Count >0 )
				{
					thisTran=sqlConn.BeginTransaction();
					this.sqlCmdUpdAccionesMktCliente.Transaction = thisTran;
					
					
					foreach(dsDatosCLI.AccionesMarkClientesRow row in dsRec.AccionesMarkClientes.Rows )
					{
						sElemento="Acciones MKT de clientes "+row.iIdAccion.ToString() + " cli : " + row.iIdCliente.ToString() + " fechentr:" + row.dFechaEntrega.ToShortDateString();
						
						sqlCmdUpdAccionesMktCliente.Parameters["@iIdAccion"].Value = row.iIdAccion;
						sqlCmdUpdAccionesMktCliente.Parameters["@iIdCliente"].Value = row.iIdCliente;
						sqlCmdUpdAccionesMktCliente.Parameters["@dFechaEntrega"].Value = row.dFechaEntrega;
						sqlCmdUpdAccionesMktCliente.Parameters["@fCantidad"].Value = row.fCantidad;
						if (!row.IstObservacionesNull())
							sqlCmdUpdAccionesMktCliente.Parameters["@tObservaciones"].Value = row.tObservaciones;
						else 
							sqlCmdUpdAccionesMktCliente.Parameters["@tObservaciones"].Value = DBNull.Value;
					
						if (!row.IssCCosteNull())
							sqlCmdUpdAccionesMktCliente.Parameters["@sCCoste"].Value = row.sCCoste;
						else 
							sqlCmdUpdAccionesMktCliente.Parameters["@sCCoste"].Value = DBNull.Value;

						sqlCmdUpdAccionesMktCliente.Parameters["@dFUM"].Value = row.dFUM;
						sqlCmdUpdAccionesMktCliente.Parameters["@bEnviadoCLI"].Value = row.bEnviadoCLI;
						sqlCmdUpdAccionesMktCliente.Parameters["@iEstado"].Value = row.iEstado;
						sqlCmdUpdAccionesMktCliente.Parameters["@iIdDelegado"].Value = row.iIdDelegado;				 						
					
					
						sqlCmdUpdAccionesMktCliente.ExecuteNonQuery();
					}

					thisTran.Commit();
				}
				#endregion
				this.pgbPaso.PerformStep();
				this.Refresh();
			}
			catch (Exception MyExc)
			{
				if (thisTran!=null) thisTran.Rollback();  
				if (this.sqlConn.State == System.Data.ConnectionState.Open ) this.sqlConn.Close();
				Mensajes.ShowError("Contacte con HelpDesk e indique el siguiente error de Sincronización:\n\n"+MyExc.Message+"\n\nEl error se ha producido en Actualizacion de acciones de marketing de clientes, elemento " +sElemento.ToString());
				throw(MyExc);
			}
		}

		private void ActualizaAtencionesComerciales(dsDatosCLI dsRec )
		{
			System.Data.SqlClient.SqlTransaction thisTran=null;
			string sElemento="";
			
			try
			{

				if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
									
				#region Atenciones Comerciales			
		
				if (dsRec.AtencionesComerciales.Rows.Count >0 )
				{
					thisTran=sqlConn.BeginTransaction();
		
					this.sqlCmdUpdAtencionesComerciales.Transaction = thisTran;
					this.sqlCmdUpdAtencionesProductos.Transaction = thisTran;
							
					foreach(dsDatosCLI.AtencionesComercialesRow  rwAte in dsRec.AtencionesComerciales.Rows)
					{
						sElemento="AtencioensComerciales " + rwAte.iIdAtencion;

						sqlCmdUpdAtencionesComerciales.Parameters["@iIdAtencion"].Value = rwAte.iIdAtencion;
						sqlCmdUpdAtencionesComerciales.Parameters["@sIdAtencionTemp"].Value = rwAte.sIdAtencionTemp; 
						sqlCmdUpdAtencionesComerciales.Parameters["@sIdAtencion"].Value = rwAte.sIdAtencion;
						sqlCmdUpdAtencionesComerciales.Parameters["@sDescripcion"].Value = rwAte.IssDescripcionNull()?SqlString.Null:rwAte.sDescripcion;
						sqlCmdUpdAtencionesComerciales.Parameters["@tObservaciones"].Value = rwAte.IstObservacionesNull()?SqlString.Null:rwAte.tObservaciones;
						sqlCmdUpdAtencionesComerciales.Parameters["@sIdTipoAtencion"].Value = rwAte.IssIdTipoAtencionNull()?SqlString.Null:rwAte.sIdTipoAtencion;
						sqlCmdUpdAtencionesComerciales.Parameters["@iIdDelegado"].Value = rwAte.IsiIdDelegadoNull()?SqlInt32.Null:rwAte.iIdDelegado;
						sqlCmdUpdAtencionesComerciales.Parameters["@sIdEstAtencion"].Value = rwAte.IssIdEstAtencionNull()?SqlString.Null:rwAte.sIdEstAtencion;
						sqlCmdUpdAtencionesComerciales.Parameters["@iIdCliente"].Value = rwAte.IsiIdClienteNull()?SqlInt32.Null:rwAte.iIdCliente;
						sqlCmdUpdAtencionesComerciales.Parameters["@fImportePrev"].Value = rwAte.fImportePrev;
						sqlCmdUpdAtencionesComerciales.Parameters["@fImporteReal"].Value = rwAte.IsfImporteRealNull()?SqlDouble.Null:rwAte.fImporteReal;
						sqlCmdUpdAtencionesComerciales.Parameters["@dFechaCreacion"].Value = rwAte.dFechaCreacion; 
						sqlCmdUpdAtencionesComerciales.Parameters["@dFechaPrev"].Value = rwAte.IsdFechaPrevNull()?SqlDateTime.Null:rwAte.dFechaPrev; 
						sqlCmdUpdAtencionesComerciales.Parameters["@dFechaAprob1"].Value = rwAte.IsdFechaAprob1Null()?SqlDateTime.Null:rwAte.dFechaAprob1; 
						sqlCmdUpdAtencionesComerciales.Parameters["@dFechaAprob2"].Value = rwAte.IsdFechaAprob2Null()?SqlDateTime.Null:rwAte.dFechaAprob2; 
						sqlCmdUpdAtencionesComerciales.Parameters["@dFechaAprob3"].Value = rwAte.IsdFechaAprob3Null()?SqlDateTime.Null:rwAte.dFechaAprob3; 
						sqlCmdUpdAtencionesComerciales.Parameters["@dFechaAprob4"].Value = rwAte.IsdFechaAprob4Null()?SqlDateTime.Null:rwAte.dFechaAprob4; 
						sqlCmdUpdAtencionesComerciales.Parameters["@dFechaReal"].Value = rwAte.IsdFechaRealNull()?SqlDateTime.Null:rwAte.dFechaReal; 
						sqlCmdUpdAtencionesComerciales.Parameters["@dFechaLiq"].Value = rwAte.IsdFechaLiqNull()?SqlDateTime.Null:rwAte.dFechaLiq; 
						sqlCmdUpdAtencionesComerciales.Parameters["@dFechaCierre"].Value = rwAte.IsdFechaCierreNull()?SqlDateTime.Null:rwAte.dFechaCierre; 
						sqlCmdUpdAtencionesComerciales.Parameters["@dFUM"].Value = rwAte.dFUM; 
						sqlCmdUpdAtencionesComerciales.Parameters["@iEstado"].Value = rwAte.iEstado;

						sqlCmdUpdAtencionesComerciales.ExecuteNonQuery();
					}

					#region Atenciones Productos

					foreach(dsDatosCLI.AtencionesProductosRow row in dsRec.AtencionesProductos.Rows)
					{

						sqlCmdUpdAtencionesProductos.Parameters["@iIdAtencion"].Value = row.iIdAtencion;	
						sqlCmdUpdAtencionesProductos.Parameters["@sIdProducto"].Value = row.sIdProducto;
						sqlCmdUpdAtencionesProductos.Parameters["@fPorcentaje"].Value = row.fPorcentaje;
						sqlCmdUpdAtencionesProductos.ExecuteNonQuery();

					}

					#endregion
		
					thisTran.Commit();
				}

				#endregion

				this.pgbPaso.PerformStep();
				this.Refresh();
			}
			catch (Exception MyExc)
			{
				if (thisTran!=null) thisTran.Rollback();  
				if (this.sqlConn.State == System.Data.ConnectionState.Open ) this.sqlConn.Close();
				Mensajes.ShowError("Contacte con HelpDesk e indique el siguiente error de Sincronización:\n\n"+MyExc.Message+"\n\nEl error se ha producido en Actualizacion Atenciones Comerciales, elemento " +sElemento.ToString());
				throw(MyExc);
			}

		}
	
		private void ActualizaNotasGastos(dsDatosCLI dsRec )
		{
			System.Data.SqlClient.SqlTransaction thisTran=null;
			string sElemento="";
			try
			{
				if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();

				#region NotasGastos_Cab				

				if (dsRec.NotasGastos.Rows.Count >0 )
				{

					thisTran=sqlConn.BeginTransaction();

					this.sqlCmdUpdNotasGastosCab.Transaction = thisTran;
					this.sqlCmdUpdaNotasGastosLin.Transaction = thisTran; 
					this.sqlCmdUpdAtencionesNotasGastos.Transaction = thisTran; 

					foreach(dsDatosCLI.NotasGastosRow  rwCab in dsRec.NotasGastos.Rows  )
					{
						sElemento="NotasGastos "+rwCab.sIdNotaTemp;
						
						sqlCmdUpdNotasGastosCab.Parameters["@sIdNotaTemp"].Value= rwCab.sIdNotaTemp;
						sqlCmdUpdNotasGastosCab.Parameters["@iIdDelegado"].Value= rwCab.iIdDelegado;
						sqlCmdUpdNotasGastosCab.Parameters["@dFecha"].Value=rwCab.dFecha;
						sqlCmdUpdNotasGastosCab.Parameters["@bVisa"].Value=rwCab.bVisa;
						
						if (!rwCab.IsdFechaAprobNull())
							sqlCmdUpdNotasGastosCab.Parameters["@dFechaAprob"].Value= rwCab.dFechaAprob;
						else 
							sqlCmdUpdNotasGastosCab.Parameters["@dFechaAprob"].Value= DBNull.Value;

						if (!rwCab.IssUsuarioAprobNull())
							sqlCmdUpdNotasGastosCab.Parameters["@sUsuarioAprob"].Value=rwCab.sUsuarioAprob;
						else 
							sqlCmdUpdNotasGastosCab.Parameters["@sUsuarioAprob"].Value= DBNull.Value;

						if (!rwCab.IsdFechaLiqNull())
							sqlCmdUpdNotasGastosCab.Parameters["@dFechaLiq"].Value=rwCab.dFechaLiq;
						else 
							sqlCmdUpdNotasGastosCab.Parameters["@dFechaLiq"].Value= DBNull.Value;

						if (!rwCab.IstObservacionesNull())
							sqlCmdUpdNotasGastosCab.Parameters["@tObservaciones"].Value= rwCab.tObservaciones;
						else 
							sqlCmdUpdNotasGastosCab.Parameters["@tObservaciones"].Value= DBNull.Value;

						sqlCmdUpdNotasGastosCab.Parameters["@iEstado"].Value=rwCab.iEstado;
						sqlCmdUpdNotasGastosCab.Parameters["@dFUM"].Value = DateTime.Now;
						sqlCmdUpdNotasGastosCab.Parameters["@bEnviadoPDA"].Value = 1;
						sqlCmdUpdNotasGastosCab.Parameters["@bEnviadoCEN"].Value = 0;
					
						sqlCmdUpdNotasGastosCab.ExecuteNonQuery();

						#region NotasGastos_Lin

						foreach(dsDatosCLI.NotasGastos_LinRow  rwLin in (dsDatosCLI.NotasGastos_LinRow[])dsRec.NotasGastos_Lin.Select("iidnota = " + rwCab.iIdNota.ToString()))
						{
							sElemento="NotasGastosLin "+rwLin.iIdNota;

							sqlCmdUpdaNotasGastosLin.Parameters["@sIdNotaTemp"].Value = rwCab.sIdNotaTemp;
							sqlCmdUpdaNotasGastosLin.Parameters["@iIdGasto"].Value = rwLin.iIdGasto;
							sqlCmdUpdaNotasGastosLin.Parameters["@fCantidad"].Value = rwLin.fCantidad;
							sqlCmdUpdaNotasGastosLin.Parameters["@fPrecio"].Value = rwLin.fPrecio;
							if (!rwLin.IstDescripcionNull())
								sqlCmdUpdaNotasGastosLin.Parameters["@tDescripcion"].Value = rwLin.tDescripcion;
							else 
								sqlCmdUpdaNotasGastosLin.Parameters["@tDescripcion"].Value = DBNull.Value;

							if (!rwLin.IssIdCentroCosteNull())
								sqlCmdUpdaNotasGastosLin.Parameters["@sIdCentroCoste"].Value = rwLin.sIdCentroCoste;						
							else 
								sqlCmdUpdaNotasGastosLin.Parameters["@sIdCentroCoste"].Value = DBNull.Value;	

							sqlCmdUpdaNotasGastosLin.ExecuteNonQuery();

						}

						#endregion

						#region Atenciones

						foreach(dsDatosCLI.AtencionesNotasGastosRow rwAtt in  (dsDatosCLI.AtencionesNotasGastosRow[])dsRec.AtencionesNotasGastos.Select("iidnota = " + rwCab.iIdNota.ToString()))
						{
							
							sqlCmdUpdAtencionesNotasGastos.Parameters["@sIdNotaTemp"].Value = rwCab.sIdNotaTemp;
							sqlCmdUpdAtencionesNotasGastos.Parameters["@sIdReportTemp"].Value = rwAtt.sIdReportTemp;
							sqlCmdUpdAtencionesNotasGastos.Parameters["@iIdCliente"].Value = rwAtt.iIdCliente;
							sqlCmdUpdAtencionesNotasGastos.Parameters["@iIdAtencion"].Value = rwAtt.iIdAtencion;
							sqlCmdUpdAtencionesNotasGastos.Parameters["@iNumAtencion"].Value = rwAtt.iNumAtencion;
							sqlCmdUpdAtencionesNotasGastos.ExecuteNonQuery();
						}						

						#endregion

					}

					thisTran.Commit();
				}
				#endregion
				this.pgbPaso.PerformStep();
				this.Refresh();
			}
			catch (Exception MyExc)
			{
				if (thisTran!=null) thisTran.Rollback();  
				if (this.sqlConn.State == System.Data.ConnectionState.Open ) this.sqlConn.Close();
				Mensajes.ShowError("Contacte con HelpDesk e indique el siguiente error de Sincronización:\n\n"+MyExc.Message+"\n\nEl error se ha producido en Actualizacion de Pedidos, elemento " +sElemento.ToString());
				throw(MyExc);
			}
		}

		/// <summary>
		/// Actualiza la tabla de configuracion
		/// </summary>
		/// <param name="dsRec">DataSet con la definicion de Datos de PDA</param>
		private void ActualizaConfig(dsDatosCLI dsRec )
		{
			System.Data.SqlClient.SqlTransaction thisTran=null;
			string sElemento="";
			try
			{
				if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
				#region Configuracion
				if (dsRec.Configuracion.Rows.Count    >0 )
				{
					thisTran=sqlConn.BeginTransaction();
					this.sqlCmdUpdConfig.Transaction = thisTran;

					foreach(dsDatosCLI.ConfiguracionRow   rwConf in dsRec.Configuracion.Rows    )
					{
						sElemento="IdConfig "+rwConf.iIdConfig; 
						sqlCmdUpdConfig.Parameters["@iIdConfig"].Value = rwConf.iIdConfig; 
						sqlCmdUpdConfig.Parameters["@sValor"].Value = rwConf.sValor ; 
					
						sqlCmdUpdConfig.ExecuteNonQuery();
					}
					thisTran.Commit();
				}
				#endregion
				this.pgbPaso.PerformStep();
				this.Refresh();
			}
			catch (Exception MyExc)
			{
				thisTran.Rollback();  
				if (this.sqlConn.State == System.Data.ConnectionState.Open ) this.sqlConn.Close();
				Mensajes.ShowError("Contacte con HelpDesk e indique el siguiente error de Sincronización:\n\n"+MyExc.Message+"\n\nEl error se ha producido en Actualizacion de Configuracion, elemento " +sElemento.ToString());
				throw(MyExc);
			}
		}

        //---- GSG (26/05/2011)
        private void ActualizaContactosClientesSAP(dsDatosCLI dsRec)
		{
			System.Data.SqlClient.SqlTransaction thisTran = null;
			string sElemento = "";

			try
			{
				if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();

				if (dsRec.ContactosClientes_SAP.Rows.Count > 0 )
				{
					thisTran = sqlConn.BeginTransaction();
					this.sqlCmdUpdContactosClientesSAP.Transaction = thisTran;

					foreach(dsDatosCLI.ContactosClientes_SAPRow rwCCS in dsRec.ContactosClientes_SAP.Rows)
					{
                        sElemento = "iIdCliente " + rwCCS.iIdCliente; 

                        sqlCmdUpdContactosClientesSAP.Parameters["@iIdCliente"].Value = rwCCS.iIdCliente;
                        sqlCmdUpdContactosClientesSAP.Parameters["@iIdContacto"].Value = rwCCS.iIdContacto;
                        sqlCmdUpdContactosClientesSAP.Parameters["@sNombre"].Value = rwCCS.sNombre;
                        sqlCmdUpdContactosClientesSAP.Parameters["@sIdCargoContacto"].Value = rwCCS.sIdCargoContacto;
                        sqlCmdUpdContactosClientesSAP.Parameters["@dFAR"].Value = rwCCS.dFAR;
                        sqlCmdUpdContactosClientesSAP.Parameters["@dFBR"].Value = rwCCS.dFBR;
                        sqlCmdUpdContactosClientesSAP.Parameters["@iEstado"].Value = rwCCS.iEstado;
                        sqlCmdUpdContactosClientesSAP.Parameters["@dFUM"].Value = rwCCS.dFUM;

                        sqlCmdUpdContactosClientesSAP.ExecuteNonQuery();
					}
					thisTran.Commit();
				}

				this.pgbPaso.PerformStep();
				this.Refresh();
			}
			catch (Exception MyExc)
			{
				thisTran.Rollback();  
				if (this.sqlConn.State == System.Data.ConnectionState.Open ) this.sqlConn.Close();
				Mensajes.ShowError("Contacte con HelpDesk e indique el siguiente error de Sincronización:\n\n"+MyExc.Message+"\n\nEl error se ha producido en Actualizacion de ContactosClientes_SAP, elemento " +sElemento.ToString());
				throw(MyExc);
			}
		}
        //---- FI GSG



		private void btSalir_Click(object sender, System.EventArgs e)
		{
			this.Close();
			this.Dispose(); 
		}

		private void pnlSincro_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
		
		}


		private string GetCambiosEstructuraBDPDA()
		{
			dsSincroEstructura.SincroEstructuraPDADataTable dt = new dsSincroEstructura.SincroEstructuraPDADataTable();
			SqlDataAdapter da = new SqlDataAdapter(SqlCmdGetSincroEstructuraBDPDA);
			da.Fill(dt);

			string sentencies = "";

			foreach(dsSincroEstructura.SincroEstructuraPDARow row in dt.Rows)
			{
				if (!row.IssCommandNull())
				{
					sentencies += row.sCommand + "    " + Environment.NewLine + "GO" + Environment.NewLine;
				}				
			}

			return sentencies;			
		}


		private void ComprobarCambiosEstructuraBDPDA(string sRutaCli, string sRutaPDA)
		{
			string sentencias = GetCambiosEstructuraBDPDA();

			try
			{

				if (sentencias != "")
				{
                    string path = Application.StartupPath + ConfigurationManager.AppSettings["SyncFolder"] + @"CambioEstructura.sql";
	
					if (File.Exists(path))
						File.Delete(path);

					StreamWriter oStr = new StreamWriter(path);
				
					oStr.WriteLine(sentencias);
					oStr.Flush();
					oStr.Close();
				
					string DirectoriPDA = sRutaPDA + @"\Estructura\";

					try
					{
						PDAConnect.CreateDeviceDirectory(DirectoriPDA);
					}
					catch(Exception ex)
					{
						System.Diagnostics.Debug.WriteLine(ex.Message);
					}

					string FileName= "Estructura.sql";
					
					if (PDAConnect.DeviceFileExists(DirectoriPDA + @"\" + FileName))
					{
						FileName = GetFileEstructuraName(DirectoriPDA);
					}
				
					PDAConnect.CopyFileToDevice(path,DirectoriPDA + @"\" + FileName);	
			
				}

			}
			catch(Exception ex)
			{
				//MessageBox.Show("Atención, ha sucedido un error grave al actualizar la estructura de la base de datos de la PDA, por favor, ponte en contacto con el departamento de informatica en cuanto sea posible.","Error Grave",MessageBoxButtons.OK,MessageBoxIcon.Error);
                Mensajes.ShowError("¡Atención!, ha sucedido un error grave al actualizar la estructura de la base de datos de la PDA. " + 
                    "Por favor, ponte en contacto con el departamento de informática.");
				System.Diagnostics.Debug.WriteLine(ex.Message);
			}

		}

		private string GetFileEstructuraName(string DirectoriPDA)
		{
			bool bJa = false;
			int i = 0;
			string name="";
				
			while(!bJa)
			{
				if (!PDAConnect.DeviceFileExists(DirectoriPDA + @"\Estructura"+ i.ToString() +".sql"))
				{
					name =  "Estructura"+ i.ToString() +".sql";
					bJa = true;
				}
				i++;
			}

			return name;
		}

	}
}