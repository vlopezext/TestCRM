using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace GESTCRM.Formularios.Busquedas
{
	/// <summary>
	/// Descripci�n breve de frmSeleccionaBrick.
	/// </summary>
	public class frmSeleccionaBrick : System.Windows.Forms.Form
	{
		/// <summary>
		/// Variable del dise�ador requerida.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmSeleccionaBrick()
		{
			//
			// Necesario para admitir el Dise�ador de Windows Forms
			//
			InitializeComponent();

			//
			// TODO: agregar c�digo de constructor despu�s de llamar a InitializeComponent
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

		#region C�digo generado por el Dise�ador de Windows Forms
		/// <summary>
		/// M�todo necesario para admitir el Dise�ador. No se puede modificar
		/// el contenido del m�todo con el editor de c�digo.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.Size = new System.Drawing.Size(300,300);
			this.Text = "frmSeleccionaBrick";
		}
		#endregion
	}
}
