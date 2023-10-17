using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace GESTCRM.Controles
{
	/// <summary>
	/// Descripción breve de ucBotoneraPrincipal.
	/// </summary>
	public class ucBotoneraPrincipal : System.Windows.Forms.UserControl
	{
		public System.Windows.Forms.Button btPedidos;
		public System.Windows.Forms.Button btClientes;
		public System.Windows.Forms.Button btGastos;
		public System.Windows.Forms.Button btReporting;
		public System.Windows.Forms.Button btCliCOM;
		public System.Windows.Forms.Button btCliSAP;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.ImageList imlBotones;
		private System.Windows.Forms.Panel panel1;
		public System.Windows.Forms.Button btSalir;
		public System.Windows.Forms.Button btPlanificacion;
		public System.Windows.Forms.Button btCentros;
		public System.Windows.Forms.Button btNAtenciones;
		public System.Windows.Forms.Button btNPedidos;
		public System.Windows.Forms.Button btNGastos;
		public System.Windows.Forms.Button btNReporting;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.PictureBox pictureBox3;
		public System.Windows.Forms.Button btListaAtenciones;
		private GESTCRM.Controles.PanelGradient panelGradient1;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.PictureBox pictureBox4;
		private System.Windows.Forms.Panel pnSalir;
		private System.Windows.Forms.Panel pnConsultas;
		private System.Windows.Forms.Panel pnNuevos;
		public System.Windows.Forms.Button btnPresupuestos;
		public System.Windows.Forms.Button btCrearMedico;
		public System.Windows.Forms.Button btCrearCentro;
		private System.ComponentModel.IContainer components;

		public ucBotoneraPrincipal()
		{
			// Llamada necesaria para el Diseñador de formularios Windows.Forms.
			InitializeComponent();
			this.btSalir.Top = this.Height - 50; 
			// TODO: agregar cualquier inicialización después de llamar a InitializeComponent

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

		#region Código generado por el Diseñador de componentes
		/// <summary> 
		/// Método necesario para admitir el Diseñador. No se puede modificar 
		/// el contenido del método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucBotoneraPrincipal));
            this.btPedidos = new System.Windows.Forms.Button();
            this.imlBotones = new System.Windows.Forms.ImageList(this.components);
            this.btClientes = new System.Windows.Forms.Button();
            this.btCliCOM = new System.Windows.Forms.Button();
            this.btCliSAP = new System.Windows.Forms.Button();
            this.btGastos = new System.Windows.Forms.Button();
            this.btReporting = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btSalir = new System.Windows.Forms.Button();
            this.btPlanificacion = new System.Windows.Forms.Button();
            this.btCentros = new System.Windows.Forms.Button();
            this.btNAtenciones = new System.Windows.Forms.Button();
            this.btNPedidos = new System.Windows.Forms.Button();
            this.btNGastos = new System.Windows.Forms.Button();
            this.btNReporting = new System.Windows.Forms.Button();
            this.btListaAtenciones = new System.Windows.Forms.Button();
            this.btnPresupuestos = new System.Windows.Forms.Button();
            this.btCrearMedico = new System.Windows.Forms.Button();
            this.btCrearCentro = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.panelGradient1 = new GESTCRM.Controles.PanelGradient();
            this.pnNuevos = new System.Windows.Forms.Panel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pnConsultas = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pnSalir = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panelGradient1.SuspendLayout();
            this.pnNuevos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.pnConsultas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.pnSalir.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btPedidos
            // 
            this.btPedidos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btPedidos.ImageIndex = 0;
            this.btPedidos.ImageList = this.imlBotones;
            this.btPedidos.Location = new System.Drawing.Point(18, 30);
            this.btPedidos.Name = "btPedidos";
            this.btPedidos.Size = new System.Drawing.Size(30, 30);
            this.btPedidos.TabIndex = 1;
            this.toolTip1.SetToolTip(this.btPedidos, "Consulta de Pedidos - F3");
            this.btPedidos.UseVisualStyleBackColor = true;
            // 
            // imlBotones
            // 
            this.imlBotones.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlBotones.ImageStream")));
            this.imlBotones.TransparentColor = System.Drawing.Color.Transparent;
            this.imlBotones.Images.SetKeyName(0, "");
            this.imlBotones.Images.SetKeyName(1, "");
            this.imlBotones.Images.SetKeyName(2, "");
            this.imlBotones.Images.SetKeyName(3, "");
            this.imlBotones.Images.SetKeyName(4, "");
            this.imlBotones.Images.SetKeyName(5, "");
            this.imlBotones.Images.SetKeyName(6, "");
            this.imlBotones.Images.SetKeyName(7, "");
            this.imlBotones.Images.SetKeyName(8, "");
            this.imlBotones.Images.SetKeyName(9, "");
            this.imlBotones.Images.SetKeyName(10, "");
            this.imlBotones.Images.SetKeyName(11, "");
            this.imlBotones.Images.SetKeyName(12, "");
            this.imlBotones.Images.SetKeyName(13, "");
            this.imlBotones.Images.SetKeyName(14, "");
            this.imlBotones.Images.SetKeyName(15, "");
            this.imlBotones.Images.SetKeyName(16, "");
            this.imlBotones.Images.SetKeyName(17, "");
            // 
            // btClientes
            // 
            this.btClientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btClientes.ImageIndex = 10;
            this.btClientes.ImageList = this.imlBotones;
            this.btClientes.Location = new System.Drawing.Point(18, 180);
            this.btClientes.Name = "btClientes";
            this.btClientes.Size = new System.Drawing.Size(30, 30);
            this.btClientes.TabIndex = 6;
            this.toolTip1.SetToolTip(this.btClientes, "Consulta de Clientes  - F6");
            this.btClientes.UseVisualStyleBackColor = true;
            // 
            // btCliCOM
            // 
            this.btCliCOM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btCliCOM.ImageIndex = 6;
            this.btCliCOM.ImageList = this.imlBotones;
            this.btCliCOM.Location = new System.Drawing.Point(18, 150);
            this.btCliCOM.Name = "btCliCOM";
            this.btCliCOM.Size = new System.Drawing.Size(30, 30);
            this.btCliCOM.TabIndex = 5;
            this.toolTip1.SetToolTip(this.btCliCOM, "Consulta de Clientes Persona/s  - F8");
            this.btCliCOM.UseVisualStyleBackColor = true;
            // 
            // btCliSAP
            // 
            this.btCliSAP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btCliSAP.ImageIndex = 3;
            this.btCliSAP.ImageList = this.imlBotones;
            this.btCliSAP.Location = new System.Drawing.Point(18, 120);
            this.btCliSAP.Name = "btCliSAP";
            this.btCliSAP.Size = new System.Drawing.Size(30, 30);
            this.btCliSAP.TabIndex = 4;
            this.toolTip1.SetToolTip(this.btCliSAP, "Consulta de Clientes SAP - F7");
            this.btCliSAP.UseVisualStyleBackColor = true;
            // 
            // btGastos
            // 
            this.btGastos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btGastos.ImageIndex = 4;
            this.btGastos.ImageList = this.imlBotones;
            this.btGastos.Location = new System.Drawing.Point(18, 60);
            this.btGastos.Name = "btGastos";
            this.btGastos.Size = new System.Drawing.Size(30, 30);
            this.btGastos.TabIndex = 2;
            this.toolTip1.SetToolTip(this.btGastos, "Consulta de Gastos - F4");
            this.btGastos.UseVisualStyleBackColor = true;
            // 
            // btReporting
            // 
            this.btReporting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btReporting.ImageIndex = 16;
            this.btReporting.ImageList = this.imlBotones;
            this.btReporting.Location = new System.Drawing.Point(18, 0);
            this.btReporting.Name = "btReporting";
            this.btReporting.Size = new System.Drawing.Size(30, 30);
            this.btReporting.TabIndex = 0;
            this.toolTip1.SetToolTip(this.btReporting, "Consulta de Reporting Actividad - F2");
            this.btReporting.UseVisualStyleBackColor = true;
            // 
            // btSalir
            // 
            this.btSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btSalir.Dock = System.Windows.Forms.DockStyle.Right;
            this.btSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btSalir.ImageIndex = 13;
            this.btSalir.ImageList = this.imlBotones;
            this.btSalir.Location = new System.Drawing.Point(16, 0);
            this.btSalir.Name = "btSalir";
            this.btSalir.Size = new System.Drawing.Size(32, 32);
            this.btSalir.TabIndex = 0;
            this.btSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.btSalir, "Salir - Ctrl+S");
            this.btSalir.UseVisualStyleBackColor = true;
            // 
            // btPlanificacion
            // 
            this.btPlanificacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btPlanificacion.ImageIndex = 15;
            this.btPlanificacion.ImageList = this.imlBotones;
            this.btPlanificacion.Location = new System.Drawing.Point(18, 210);
            this.btPlanificacion.Name = "btPlanificacion";
            this.btPlanificacion.Size = new System.Drawing.Size(30, 30);
            this.btPlanificacion.TabIndex = 7;
            this.toolTip1.SetToolTip(this.btPlanificacion, "Consulta de Planificación - F9");
            this.btPlanificacion.UseVisualStyleBackColor = true;
            // 
            // btCentros
            // 
            this.btCentros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btCentros.ImageIndex = 12;
            this.btCentros.ImageList = this.imlBotones;
            this.btCentros.Location = new System.Drawing.Point(18, 240);
            this.btCentros.Name = "btCentros";
            this.btCentros.Size = new System.Drawing.Size(30, 30);
            this.btCentros.TabIndex = 8;
            this.toolTip1.SetToolTip(this.btCentros, "Consulta de Centros - F10");
            this.btCentros.UseVisualStyleBackColor = true;
            // 
            // btNAtenciones
            // 
            this.btNAtenciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btNAtenciones.ImageIndex = 14;
            this.btNAtenciones.ImageList = this.imlBotones;
            this.btNAtenciones.Location = new System.Drawing.Point(18, 90);
            this.btNAtenciones.Name = "btNAtenciones";
            this.btNAtenciones.Size = new System.Drawing.Size(30, 30);
            this.btNAtenciones.TabIndex = 3;
            this.toolTip1.SetToolTip(this.btNAtenciones, "Nueva Atención - Ctrl + A");
            this.btNAtenciones.UseVisualStyleBackColor = true;
            // 
            // btNPedidos
            // 
            this.btNPedidos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btNPedidos.ImageIndex = 0;
            this.btNPedidos.ImageList = this.imlBotones;
            this.btNPedidos.Location = new System.Drawing.Point(18, 30);
            this.btNPedidos.Name = "btNPedidos";
            this.btNPedidos.Size = new System.Drawing.Size(30, 30);
            this.btNPedidos.TabIndex = 1;
            this.toolTip1.SetToolTip(this.btNPedidos, "Nuevo Pedido - Ctrl + P");
            this.btNPedidos.UseVisualStyleBackColor = true;
            // 
            // btNGastos
            // 
            this.btNGastos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btNGastos.ImageIndex = 4;
            this.btNGastos.ImageList = this.imlBotones;
            this.btNGastos.Location = new System.Drawing.Point(18, 60);
            this.btNGastos.Name = "btNGastos";
            this.btNGastos.Size = new System.Drawing.Size(30, 30);
            this.btNGastos.TabIndex = 2;
            this.toolTip1.SetToolTip(this.btNGastos, "Nuevo Gasto - Ctrl + G");
            this.btNGastos.UseVisualStyleBackColor = true;
            // 
            // btNReporting
            // 
            this.btNReporting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btNReporting.ImageIndex = 16;
            this.btNReporting.ImageList = this.imlBotones;
            this.btNReporting.Location = new System.Drawing.Point(18, 0);
            this.btNReporting.Name = "btNReporting";
            this.btNReporting.Size = new System.Drawing.Size(30, 30);
            this.btNReporting.TabIndex = 0;
            this.toolTip1.SetToolTip(this.btNReporting, "Nuevo Reporting Actividad - Ctrl + V");
            this.btNReporting.UseVisualStyleBackColor = true;
            // 
            // btListaAtenciones
            // 
            this.btListaAtenciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btListaAtenciones.ImageIndex = 14;
            this.btListaAtenciones.ImageList = this.imlBotones;
            this.btListaAtenciones.Location = new System.Drawing.Point(18, 90);
            this.btListaAtenciones.Name = "btListaAtenciones";
            this.btListaAtenciones.Size = new System.Drawing.Size(30, 30);
            this.btListaAtenciones.TabIndex = 3;
            this.toolTip1.SetToolTip(this.btListaAtenciones, "Consulta de Atenciones - F5");
            this.btListaAtenciones.UseVisualStyleBackColor = true;
            // 
            // btnPresupuestos
            // 
            this.btnPresupuestos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnPresupuestos.ImageIndex = 17;
            this.btnPresupuestos.ImageList = this.imlBotones;
            this.btnPresupuestos.Location = new System.Drawing.Point(18, 120);
            this.btnPresupuestos.Name = "btnPresupuestos";
            this.btnPresupuestos.Size = new System.Drawing.Size(30, 30);
            this.btnPresupuestos.TabIndex = 4;
            this.toolTip1.SetToolTip(this.btnPresupuestos, "Asignación de Presupuestos Ctrl+P");
            this.btnPresupuestos.UseVisualStyleBackColor = true;
            // 
            // btCrearMedico
            // 
            this.btCrearMedico.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btCrearMedico.ImageIndex = 6;
            this.btCrearMedico.ImageList = this.imlBotones;
            this.btCrearMedico.Location = new System.Drawing.Point(18, 150);
            this.btCrearMedico.Name = "btCrearMedico";
            this.btCrearMedico.Size = new System.Drawing.Size(30, 30);
            this.btCrearMedico.TabIndex = 6;
            this.toolTip1.SetToolTip(this.btCrearMedico, "Nuevo Cliente Personas Ctrl+M");
            this.btCrearMedico.UseVisualStyleBackColor = true;
            // 
            // btCrearCentro
            // 
            this.btCrearCentro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btCrearCentro.ImageIndex = 12;
            this.btCrearCentro.ImageList = this.imlBotones;
            this.btCrearCentro.Location = new System.Drawing.Point(18, 180);
            this.btCrearCentro.Name = "btCrearCentro";
            this.btCrearCentro.Size = new System.Drawing.Size(30, 30);
            this.btCrearCentro.TabIndex = 9;
            this.toolTip1.SetToolTip(this.btCrearCentro, "Nuevo Centro de Salud Ctrl+S");
            this.btCrearCentro.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panelGradient1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(52, 576);
            this.panel1.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(230)))), ((int)(((byte)(239)))));
            this.panel2.Controls.Add(this.pictureBox3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(48, 35);
            this.panel2.TabIndex = 0;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(8, 2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(32, 32);
            this.pictureBox3.TabIndex = 25;
            this.pictureBox3.TabStop = false;
            // 
            // panelGradient1
            // 
            this.panelGradient1.Controls.Add(this.pnNuevos);
            this.panelGradient1.Controls.Add(this.pnConsultas);
            this.panelGradient1.Controls.Add(this.pnSalir);
            this.panelGradient1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGradient1.GradientColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.panelGradient1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.panelGradient1.Location = new System.Drawing.Point(0, 0);
            this.panelGradient1.Name = "panelGradient1";
            this.panelGradient1.Size = new System.Drawing.Size(48, 572);
            this.panelGradient1.TabIndex = 27;
            this.panelGradient1.Paint += new System.Windows.Forms.PaintEventHandler(this.panelGradient1_Paint);
            // 
            // pnNuevos
            // 
            this.pnNuevos.Controls.Add(this.btCrearCentro);
            this.pnNuevos.Controls.Add(this.btCrearMedico);
            this.pnNuevos.Controls.Add(this.btnPresupuestos);
            this.pnNuevos.Controls.Add(this.pictureBox4);
            this.pnNuevos.Controls.Add(this.btNReporting);
            this.pnNuevos.Controls.Add(this.btNGastos);
            this.pnNuevos.Controls.Add(this.btNPedidos);
            this.pnNuevos.Controls.Add(this.btNAtenciones);
            this.pnNuevos.Location = new System.Drawing.Point(0, 39);
            this.pnNuevos.Name = "pnNuevos";
            this.pnNuevos.Size = new System.Drawing.Size(48, 224);
            this.pnNuevos.TabIndex = 1;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(0, 0);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(17, 224);
            this.pictureBox4.TabIndex = 2;
            this.pictureBox4.TabStop = false;
            // 
            // pnConsultas
            // 
            this.pnConsultas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.pnConsultas.Controls.Add(this.btCentros);
            this.pnConsultas.Controls.Add(this.btPlanificacion);
            this.pnConsultas.Controls.Add(this.btReporting);
            this.pnConsultas.Controls.Add(this.btGastos);
            this.pnConsultas.Controls.Add(this.btCliSAP);
            this.pnConsultas.Controls.Add(this.btCliCOM);
            this.pnConsultas.Controls.Add(this.btClientes);
            this.pnConsultas.Controls.Add(this.pictureBox2);
            this.pnConsultas.Controls.Add(this.btListaAtenciones);
            this.pnConsultas.Controls.Add(this.btPedidos);
            this.pnConsultas.Location = new System.Drawing.Point(0, 272);
            this.pnConsultas.Name = "pnConsultas";
            this.pnConsultas.Size = new System.Drawing.Size(48, 264);
            this.pnConsultas.TabIndex = 2;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(17, 272);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pnSalir
            // 
            this.pnSalir.Controls.Add(this.btSalir);
            this.pnSalir.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnSalir.Location = new System.Drawing.Point(0, 540);
            this.pnSalir.Name = "pnSalir";
            this.pnSalir.Size = new System.Drawing.Size(48, 32);
            this.pnSalir.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // ucBotoneraPrincipal
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(230)))), ((int)(((byte)(239)))));
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "ucBotoneraPrincipal";
            this.Size = new System.Drawing.Size(52, 576);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panelGradient1.ResumeLayout(false);
            this.pnNuevos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.pnConsultas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.pnSalir.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void panelGradient1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
		
		}

	}
}
