using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace GESTCRM.Controles
{
	/// <summary>
	/// Descripción breve de ucBotoneraSecundaria.
	/// </summary>
	public class ucBotoneraSecundaria : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.ImageList imlBotones;
		private System.Windows.Forms.ToolTip toolTip1;
		private GESTCRM.Controles.PanelGradient panelGradient1;
		public System.Windows.Forms.Button btEditar;
		public System.Windows.Forms.Button btGrabar;
		public System.Windows.Forms.Button btEliminar;
		public System.Windows.Forms.Button btNuevo;
		public System.Windows.Forms.Button btSalir;
        public Button btAIndicadores;
        public Button btAPedido;
		private System.ComponentModel.IContainer components;

		public ucBotoneraSecundaria()
		{
			// Llamada necesaria para el Diseñador de formularios Windows.Forms.
			InitializeComponent();

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucBotoneraSecundaria));
            this.imlBotones = new System.Windows.Forms.ImageList(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btEditar = new System.Windows.Forms.Button();
            this.btGrabar = new System.Windows.Forms.Button();
            this.btEliminar = new System.Windows.Forms.Button();
            this.btNuevo = new System.Windows.Forms.Button();
            this.btSalir = new System.Windows.Forms.Button();
            this.btAPedido = new System.Windows.Forms.Button();
            this.btAIndicadores = new System.Windows.Forms.Button();
            this.panelGradient1 = new GESTCRM.Controles.PanelGradient();
            this.panelGradient1.SuspendLayout();
            this.SuspendLayout();
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
            // 
            // btEditar
            // 
            this.btEditar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btEditar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btEditar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btEditar.ImageIndex = 8;
            this.btEditar.ImageList = this.imlBotones;
            this.btEditar.Location = new System.Drawing.Point(40, 1);
            this.btEditar.Name = "btEditar";
            this.btEditar.Size = new System.Drawing.Size(32, 32);
            this.btEditar.TabIndex = 12;
            this.btEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.btEditar, "Editar");
            this.btEditar.UseVisualStyleBackColor = true;
            // 
            // btGrabar
            // 
            this.btGrabar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btGrabar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btGrabar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btGrabar.ImageIndex = 10;
            this.btGrabar.ImageList = this.imlBotones;
            this.btGrabar.Location = new System.Drawing.Point(120, 1);
            this.btGrabar.Name = "btGrabar";
            this.btGrabar.Size = new System.Drawing.Size(32, 32);
            this.btGrabar.TabIndex = 16;
            this.btGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.btGrabar, "Grabar");
            this.btGrabar.UseVisualStyleBackColor = true;
            // 
            // btEliminar
            // 
            this.btEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btEliminar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btEliminar.ImageIndex = 9;
            this.btEliminar.ImageList = this.imlBotones;
            this.btEliminar.Location = new System.Drawing.Point(72, 1);
            this.btEliminar.Name = "btEliminar";
            this.btEliminar.Size = new System.Drawing.Size(32, 32);
            this.btEliminar.TabIndex = 13;
            this.btEliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.btEliminar, "Eliminar");
            this.btEliminar.UseVisualStyleBackColor = true;
            // 
            // btNuevo
            // 
            this.btNuevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btNuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btNuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btNuevo.ImageIndex = 12;
            this.btNuevo.ImageList = this.imlBotones;
            this.btNuevo.Location = new System.Drawing.Point(8, 1);
            this.btNuevo.Name = "btNuevo";
            this.btNuevo.Size = new System.Drawing.Size(32, 32);
            this.btNuevo.TabIndex = 14;
            this.btNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.btNuevo, "Nuevo");
            this.btNuevo.UseVisualStyleBackColor = true;
            // 
            // btSalir
            // 
            this.btSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btSalir.Dock = System.Windows.Forms.DockStyle.Right;
            this.btSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btSalir.ImageIndex = 13;
            this.btSalir.ImageList = this.imlBotones;
            this.btSalir.Location = new System.Drawing.Point(564, 0);
            this.btSalir.Name = "btSalir";
            this.btSalir.Size = new System.Drawing.Size(32, 34);
            this.btSalir.TabIndex = 17;
            this.btSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.btSalir, "Salir");
            this.btSalir.UseVisualStyleBackColor = true;
            // 
            // btAPedido
            // 
            this.btAPedido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btAPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAPedido.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btAPedido.ImageIndex = 14;
            this.btAPedido.ImageList = this.imlBotones;
            this.btAPedido.Location = new System.Drawing.Point(172, 1);
            this.btAPedido.Name = "btAPedido";
            this.btAPedido.Size = new System.Drawing.Size(32, 32);
            this.btAPedido.TabIndex = 18;
            this.btAPedido.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.btAPedido, "Pedido");
            this.btAPedido.UseVisualStyleBackColor = true;
            // 
            // btAIndicadores
            // 
            this.btAIndicadores.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btAIndicadores.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAIndicadores.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btAIndicadores.ImageIndex = 15;
            this.btAIndicadores.ImageList = this.imlBotones;
            this.btAIndicadores.Location = new System.Drawing.Point(205, 1);
            this.btAIndicadores.Name = "btAIndicadores";
            this.btAIndicadores.Size = new System.Drawing.Size(32, 32);
            this.btAIndicadores.TabIndex = 19;
            this.btAIndicadores.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.btAIndicadores, "Indicadores y Alarmas");
            this.btAIndicadores.UseVisualStyleBackColor = true;
            // 
            // panelGradient1
            // 
            this.panelGradient1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelGradient1.Controls.Add(this.btAIndicadores);
            this.panelGradient1.Controls.Add(this.btAPedido);
            this.panelGradient1.Controls.Add(this.btSalir);
            this.panelGradient1.Controls.Add(this.btEditar);
            this.panelGradient1.Controls.Add(this.btGrabar);
            this.panelGradient1.Controls.Add(this.btEliminar);
            this.panelGradient1.Controls.Add(this.btNuevo);
            this.panelGradient1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelGradient1.GradientColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(117)))), ((int)(((byte)(1)))));
            this.panelGradient1.Location = new System.Drawing.Point(0, 0);
            this.panelGradient1.Name = "panelGradient1";
            this.panelGradient1.Size = new System.Drawing.Size(600, 38);
            this.panelGradient1.TabIndex = 0;
            // 
            // ucBotoneraSecundaria
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(117)))), ((int)(((byte)(1)))));
            this.Controls.Add(this.panelGradient1);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "ucBotoneraSecundaria";
            this.Size = new System.Drawing.Size(600, 38);
            this.Load += new System.EventHandler(this.ucBotoneraSecundaria_Load);
            this.panelGradient1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		public void Activar_botonera(bool AbtSalir,bool AbtNuevo,bool AbtEditar,bool AbtEliminar,bool AbtGrabar,bool AbtImprimir)
		{
			this.btSalir.Enabled=AbtSalir;
			this.btNuevo.Enabled=AbtNuevo;
			this.btEditar.Enabled=AbtEditar;
			this.btEliminar.Enabled=AbtEliminar;
			this.btGrabar.Enabled=AbtGrabar;
            //---- GSG (02/04/2014)
            this.btAPedido.Enabled = false;
            this.btAIndicadores.Enabled = false;
		}

        //---- GSG (02/04/2014)
        public void Activar_botonera(bool AbtSalir,bool AbtNuevo,bool AbtEditar,bool AbtEliminar,bool AbtGrabar,bool AbtImprimir, bool AbtPedidos, bool AbtIndicadores)
		{
			this.btSalir.Enabled=AbtSalir;
			this.btNuevo.Enabled=AbtNuevo;
			this.btEditar.Enabled=AbtEditar;
			this.btEliminar.Enabled=AbtEliminar;
			this.btGrabar.Enabled=AbtGrabar;
            this.btAPedido.Enabled = AbtPedidos;
            this.btAIndicadores.Enabled = AbtIndicadores;
		}

		private void ucBotoneraSecundaria_Load(object sender, System.EventArgs e)
		{	
			//this.btSalir.Left = this.Width -50;
			PanelColoredForeColor ColorDeFondo;			
			ColorDeFondo = new PanelColoredForeColor();	
		}
		
		public class  PanelColoredForeColor : Panel
		{
			protected override void OnPaintBackground(System.Windows.Forms.PaintEventArgs pevent)
			{
				Graphics gfx = pevent.Graphics;

				Rectangle rect = new Rectangle (0,0,this.Width,this.Height);

				// Dispose of brush resources after use
				using (LinearGradientBrush lgb = new 
						   LinearGradientBrush(rect, 
						   Color.FromArgb(255, 200, 200),Color.FromArgb(128, 20, 20),LinearGradientMode.BackwardDiagonal))

					gfx.FillRectangle(lgb,rect);
				
				ControlPaint.DrawBorder3D(gfx,rect,Border3DStyle.Bump);				
			}

		}
	}
}
