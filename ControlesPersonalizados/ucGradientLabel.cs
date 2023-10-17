using System;
using System.Collections;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace GESTCRM.Controles
{
	/// <summary>
	/// Es un label con fondo de color gradiente
	/// </summary>

	public class LabelGradient : Label
	{	
		protected Color gradientColorOne = Color.FromArgb(18, 84, 132);
		protected Color gradientColorTwo = Color.White;
		protected LinearGradientMode lgm = LinearGradientMode.Horizontal;
		protected Border3DStyle b3dstyle = Border3DStyle.Bump;		
		
		
		[
		DefaultValue(typeof(Color),"Azul Oscuro"),
		System.ComponentModel.Description("El Primer color del Gradiente"),
		System.ComponentModel.Category("Appearance"),
		]

			//GradientColorOne Properties
		public Color GradientColorOne
		{
			get
			{
				return gradientColorOne;				
			}
			set
			{
				gradientColorOne = value;
				Invalidate();
			}
		}
		
		[
		DefaultValue(typeof(Color),"Blanco"),
		Description("El Segundo color del Gradiente"),
		Category("Appearance"),
		]

			//GradientColorTwo Properties
		public Color GradientColorTwo
		{
			get
			{
				return gradientColorTwo;
			}
			set
			{
				gradientColorTwo = value;
				Invalidate();
			}
		}
		

		
		//LinearGradientMode Properties
		[
		DefaultValue(typeof(LinearGradientMode),"Horizontal"),
		Description("Gradient Mode"),
		Category("Appearance"),
		]

		public LinearGradientMode GradientMode
		{
			get
			{
				return lgm;
			}

			set
			{
				lgm = value;
				Invalidate();
			}
		}		

		#region Borde3D
		//Border3DStyle Properties
		[
		DefaultValue(typeof(Border3DStyle),"Bump"),
		Description("BorderStyle"),
		Category("Appearance"),
		]

			// hide BorderStyle inherited from the base class
		new public Border3DStyle BorderStyle
		{
			get
			{
				return b3dstyle;
			}
			set
			{
				b3dstyle = value;
				Invalidate();
			}
		}
		#endregion		

		// Remove BackColor Property
		[
		Browsable(false),
		EditorBrowsable(EditorBrowsableState.Never)
		]
		public override System.Drawing.Color BackColor
		{
			get
			{
				return new System.Drawing.Color();
			}
			set {;}
		}		

		public LabelGradient()
		{
			InitializeComponent();			
		}

		private void InitializeComponent()
		{
			// 
			// LabelGradient
			// 
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ForeColor = System.Drawing.Color.White;
			this.Size = new System.Drawing.Size(100, 22);

		}

		protected override void 
			OnPaintBackground(System.Windows.Forms.PaintEventArgs pevent)
		{
			Graphics gfx = pevent.Graphics;

			Rectangle rect = new Rectangle (0,0,this.Width,this.Height);

			// Dispose of brush resources after use
			using (LinearGradientBrush lgb = new 
					   LinearGradientBrush(rect, 
					   gradientColorOne,gradientColorTwo,lgm))

				gfx.FillRectangle(lgb,rect);
			

			//ControlPaint.DrawBorder3D(gfx,rect,b3dstyle);
		}
	}
}