using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace GESTCRM.Formularios.Base
{
	/// <summary>
	/// Descripci�n breve de frmMantenimientos.
	/// </summary>
	public class frmMantenimientos : System.Windows.Forms.Form
	{
		/// <summary>
		/// Variable del dise�ador requerida.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmMantenimientos()
		{
			//
			// Necesario para admitir el Dise�ador de Windows Forms
			//
			InitializeComponent();

			//
			// TODO: Agregar c�digo de constructor despu�s de llamar a InitializeComponent
			//
		}

		/// <summary>
		/// Limpiar los recursos que se est�n utilizando.
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
		/// M�todo necesario para admitir el Dise�ador, no se puede modificar
		/// el contenido del m�todo con el editor de c�digo.
		/// </summary>
		private void InitializeComponent()
		{
//			// 
//			// frmMantenimientos
//			// 
//			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
//			this.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(238)), ((System.Byte)(243)), ((System.Byte)(246)));
//			this.ClientSize = new System.Drawing.Size(608, 349);
//			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
//			this.MaximizeBox = false;
//			this.MinimizeBox = false;
//			this.Name = "frmMantenimientos";
//			this.ShowInTaskbar = false;
//			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
//			this.Text = "frmMantenimientos";

		}
		#endregion
	}
}
