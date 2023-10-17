using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace GESTCRM.Formularios.Base
{
	/// <summary>
	/// Descripci�n breve de frmBase.
	/// </summary>
	public class frmBase : System.Windows.Forms.Form
	{
		/// <summary>
		/// Variable del dise�ador requerida.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmBase()
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
			// 
			// frmBase
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(238)), ((System.Byte)(243)), ((System.Byte)(246)));
			this.ClientSize = new System.Drawing.Size(752, 493);
			this.Name = "frmBase";
			this.ShowInTaskbar = false;
			this.Text = "frmBase";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

		}
		#endregion
	}
}
