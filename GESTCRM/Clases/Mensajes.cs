using System;
using System.Windows.Forms;
using System.Media;
using GESTCRM.Formularios;

namespace GESTCRM
{
	public class Mensajes
	{
        private static frmTip tip = new frmTip();

        public static void ShowTip(int X, int Y, Form Owner)
        {
            if (tip.Visible)
                return;

            tip.Left = X + Owner.Left - tip.Width / 2;
            tip.Top = Y + Owner.Top - 30;

            if ((Owner.MdiParent == null) && Owner.Name == "frmPedidos")
                tip.Top -= 50;

            tip.Show(Owner);
            Owner.Focus();
        }

        public static void HideTip()
        {
            tip.Close();
        }

        public static void SetTip(string title, string text)
        {
            tip.tipCaption.Text = title;
            tip.tipText.Text = text;
        }


		/// <summary>
		/// Mensaje de error.
		/// </summary>
		/// <param name="code">Código del mensaje.</param>
		public static void ShowError(int code)
		{
			//MessageBox.Show(Text(code), Caption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            SystemSounds.Hand.Play();
            using (ShowError messageBox = new ShowError())
            {
                messageBox.Mensaje.Text = Text(code);
                messageBox.ShowDialog();
            }
		}

		/// <summary>
		/// Mensaje de error.
		/// </summary>
		/// <param name="code">String del mensaje.</param>
		public static void ShowError(string message)
		{
			//MessageBox.Show(message, Caption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            SystemSounds.Hand.Play();
            using (ShowError messageBox = new ShowError())
            {
                messageBox.Mensaje.Text = message;
                messageBox.ShowDialog();
            }
		}

		public static void ShowErrorField(string message)
		{
			//MessageBox.Show(Text(2003) + message, Caption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            SystemSounds.Hand.Play();
            using (ShowError messageBox = new ShowError())
            {
                messageBox.Mensaje.Text = Text(2003) + message;
                messageBox.ShowDialog();
            }
		}

		/// <summary>
		/// Mensaje de exclamación.
		/// </summary>
		/// <param name="code">Código del mensaje.</param>
		public static void ShowExclamation(int code)
		{
			//MessageBox.Show(Text(code), Caption(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            ShowInformation(code);
		}
		
		/// <summary>
		/// Mensaje de exclamación.
		/// </summary>
		/// <param name="code">Texto del mensaje.</param>
		public static void ShowExclamation(string Texto)
		{
			//MessageBox.Show(Texto, Caption(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            ShowInformation(Texto);
		}

		/// <summary>
		/// Mensaje de información.
		/// </summary>
		/// <param name="code">Código del mensaje.</param>
		public static void ShowInformation(int code)
		{
			//MessageBox.Show(Text(code), Caption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            SystemSounds.Asterisk.Play();
            using (ShowInfo messageBox = new ShowInfo())
            {
                messageBox.Mensaje.Text = Text(code);
                messageBox.ShowDialog();
            }
		}

		public static void ShowInformation(string message)
		{
			//MessageBox.Show(message, Caption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            SystemSounds.Asterisk.Play();
            using (ShowInfo messageBox = new ShowInfo())
            {
                messageBox.Mensaje.Text = message;
                messageBox.ShowDialog();
            }
		}

        //---- GSG (07/10/2013)
        public static DialogResult ShowInformation(string message, bool bTextInBox)
        {
            SystemSounds.Asterisk.Play();
            using (ShowInfo messageBox = new ShowInfo())
            {
                messageBox.Mensaje.Visible = false;
                messageBox.txtbMissScroll.Text = message;
                messageBox.txtbMissScroll.Visible = true;

                return messageBox.ShowDialog();
            }
        }

		/// <summary>
		/// Mensaje de pregunta.
		/// </summary>
		/// <param name="code">Código del mensaje.</param>
		/// <returns>
		/// Resultado de la interacción con el usuario (MessageBoxButtons.Yes / MessageBoxButtons.No).
		/// </returns>
		public static DialogResult ShowQuestion(int code)
		{
			//return MessageBox.Show(Text(code), Caption(), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            SystemSounds.Exclamation.Play();
            using (ShowQuestion messageBox = new ShowQuestion())
            {
                messageBox.Mensaje.Text = Text(code);
                return messageBox.ShowDialog();
            }
		}

		public static DialogResult ShowQuestion(string message)
		{
			//return MessageBox.Show(message, Caption(), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            SystemSounds.Exclamation.Play();
            using (ShowQuestion messageBox = new ShowQuestion())
            {
                messageBox.txtbMissScroll.Visible = false; //---- GSG (03/10/2013)
                messageBox.Mensaje.Text = message;
                return messageBox.ShowDialog();
            }
		}

        //---- GSG (03/10/2013)
        public static DialogResult ShowQuestion(string message, bool bTextInBox)
        {
            SystemSounds.Exclamation.Play();
            using (ShowQuestion messageBox = new ShowQuestion())
            {
                messageBox.Mensaje.Visible = false; 
                messageBox.txtbMissScroll.Text = message;
                messageBox.txtbMissScroll.Visible = true;

                return messageBox.ShowDialog();
            }
        }


        /// <summary>
		/// Texto del mensaje.
		/// </summary>
		/// <param name="code">Código del mensaje.</param>
		/// <returns>
		/// Texto del mensaje.
		/// </returns>
		private static string Text(int code)
		{
			string text = "";

			switch (code)
			{
				//Grupo de Errores 1
				case 1000: text = "Falta introducir el Usuario."; break;
				case 1001: text = "Falta introducir la Contraseña."; break;
				case 1002: text = "Error al iniciar la aplicación. Si el problema persiste póngase en contacto con el administrador del sistema."; break;
				case 1003: text = "No se ha podido establecer una conexión con la Base de Datos. La aplicación no funcionará correctamente."; break;
				case 1004: text = "El Usuario o la Contraseña son incorrectos. La aplicación se cerrará."; break;
				case 1005: text = "Error en el acceso a los datos."; break;
				case 1006: text = "Va a modificar los datos."; break;
				case 1007: text = "No se han podido borrar los datos."; break;
				case 1008: text = "El producto ya existe en la lista."; break;
				case 1009: text = "La especialidad ya existe en la lista."; break;
				case 1010: text = "El centro ya existe en la lista."; break;
				case 1011: text = "Es obligatorio introducir la descripción"; break;
				case 1012: text = "Es obligatorio introducir el importe previsto.";break;
				case 1013: text = "ATENCION: SE HA QUITADO EL CÓDIGO DE ERROR 1013. USE EL RANGO 300x."; break;	
				case 1014: text = "La Nota de Gasto se ha enviado a CENTRAL y no se puede editar.";break;
				
				//Grupo de Errores 2
				case 2000: text = "No se pueden crear 'Reports de Visita' de otro delegado."; break;
				case 2001: text = "No se pueden modificar 'Reports de Visita' de otro delegado."; break;
				case 2002: text = "No se pueden eliminar 'Reports de Visita' de otro delegado."; break;
				
				//Mensaje Despedida
				case 3000: text = "Va a salir sin guardar los cambios. ¿Desea salir?"; break;
				case 3001: text = "No se han podido guardar los cambios. ¿Desea salir?"; break;
				case 3002: text = "Va a salir. ¿Desea guardar los cambios?"; break;
				case 3003: text = "Los datos se han guardado correctamente. ¿Desea salir?"; break;
				case 3004: text = "Los datos se han guardado correctamente."; break;

		
				//Grupo de Errores 3
				case 4000: text = "No se puede crear 'Atención Comercial' de otro delegado."; break;
				case 4001: text = "No se puede modificar 'Atención Comercial' de otro delegado."; break;
				case 4002: text = "No se puede eliminar 'Atención Comercial' de otro delegado."; break;
				
				case 5000: text = "No se pueden crear 'Notas de Gastos' de otro delegado."; break;
				case 5001: text = "No se pueden modificar 'Notas de Gastos' de otro delegado."; break;
				case 5002: text = "No se pueden eliminar 'Notas de Gastos' de otro delegado."; break;

				default: break;
			}
			return text;
		}

		/// <summary>
		/// Texto para la barra del título.
		/// </summary>
		/// <returns>
		/// Texto para la barra del título.
		/// </returns>
		private static string Caption()
		{
			return "GESTCRM";
		}
	}
}
