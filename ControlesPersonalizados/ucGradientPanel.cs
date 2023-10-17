using System;
using System.Collections;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace GESTCRM.Controles
{
	/// <summary>
	/// Panel Con Gradiente
	/// </summary>
	public class PanelGradient : Panel
	{
		protected Color gradientColorOne = Color.Orange;
		protected Color gradientColorTwo = Color.White;
		protected LinearGradientMode lgm = LinearGradientMode.Horizontal;
		//protected Border3DStyle b3dstyle = Border3DStyle.Bump;	
		
		[
		DefaultValue(typeof(Color),"ColorNaranja"),
		System.ComponentModel.Description("Primer color del gradiente"),
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
		DefaultValue(typeof(Color),"White"),
		Description("Segundo color del Gradiente."),
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
		

		
//		//Border3DStyle Properties
//		[
//		DefaultValue(typeof(Border3DStyle),"Bump"),
//		Description("BorderStyle"),
//		Category("Appearance"),
//		]
//
//			// hide BorderStyle inherited from the base class
//		new public Border3DStyle BorderStyle
//		{
//			get
//			{
//				return b3dstyle;
//			}
//			set
//			{
//				b3dstyle = value;
//				Invalidate();
//			}
//		}
		

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

		public PanelGradient()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		protected override void 
			OnPaintBackground(System.Windows.Forms.PaintEventArgs pevent)
		{
			int h = 0;
			int w = 0;

			Graphics gfx = pevent.Graphics;
			
			//Para el caso en que minimizen los formularios que contienen el control y 
			//no falle el With o el Height ya que si están a 0 no funciona el gradiente
			if (this.Height == 0)
			{
				h = 688;
			}
			else
			{
				h = this.Height;
			}

			if (this.Width == 0)
			{
				w = 51;
			}
			else
			{
				w = this.Width;
			}
			
			Rectangle rect = new Rectangle (0,0,w,h);

			// Dispose of brush resources after use
			using (LinearGradientBrush lgb = new 
					   LinearGradientBrush(rect, 
					   gradientColorOne,gradientColorTwo,lgm))

				gfx.FillRectangle(lgb,rect);

			//ControlPaint.DrawBorder3D(gfx,rect,b3dstyle);
		}
	}
}
