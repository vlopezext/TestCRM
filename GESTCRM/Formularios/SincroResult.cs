using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace GESTCRM.Formularios
{
	/// <summary>
	/// Descripción breve de SincroResult.
	/// </summary>
	public class SincroResult : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button btClipBoard;
		private System.Windows.Forms.Button btGuardar;
		private System.Windows.Forms.SaveFileDialog saveFile;
		/// <summary>
		/// Variable del diseñador requerida.
		/// </summary>
		private System.ComponentModel.Container components = null;

		
		#region DataSets utilizados y Propiedades del formulario
		private WSSinCRM.dsRetorno _dsSubida;
		private WSSinCRM.dsRetorno _dsBajada;

		/// <summary>
		/// Establece el Dataset de Subida de Cliente a Central y configura el texto a mostrar
		/// </summary>
		public WSSinCRM.dsRetorno DataSetSubida
		{
			set
			{
				_dsSubida = value;
				textBox1.Text+=(_dsSubida.Filas.Rows.Count >0)?setText(_dsSubida,"Registros NO procesados en Central"):"";
				Application.DoEvents();
			}
		}
		/// <summary>
		/// Establece el Dataset de Bajada de Central a Cliente y configura el texto a mostrar
		/// </summary>
		public WSSinCRM.dsRetorno DataSetBajada
		{
			set
			{
				_dsBajada = value;
				textBox1.Text+=(_dsBajada.Filas.Rows.Count >0)?setText(_dsBajada,"Registros NO procesados en Cliente"):"";
				Application.DoEvents();
			}
		}
		#endregion

		#region Configurar Texto
		/// <summary>
		/// Convierte los datos del Dataser enviado a una cadena de caracteres con formato
		/// </summary>
		/// <param name="dsData">DataSet a Procesar</param>
		/// <param name="headerTitle">Mensaje para el encabezado de los registros</param>
		/// <returns></returns>
		private string setText(WSSinCRM.dsRetorno dsData,string headerTitle)
		{
			string sResult = headerTitle + Utiles.CrLf+Utiles.CrLf+Utiles.CrLf;
			WSSinCRM.dsRetorno.FilasRow[] drFilas;

			foreach (WSSinCRM.dsRetorno.TablaRow rwTabla in dsData.Tabla.Rows)
			{
				
				drFilas = (WSSinCRM.dsRetorno.FilasRow[])dsData.Filas.Select("sNombreTabla='"+rwTabla.sNombreTabla+"'");
				if (drFilas.Length>0)
				{
					sResult+=rwTabla.sNombreTabla+ Utiles.CrLf;
					foreach (WSSinCRM.dsRetorno.FilasRow rwFila in drFilas)
					{
						sResult +=getText(rwFila) + Utiles.CrLf;
					}
					sResult+=Utiles.CrLf+Utiles.CrLf;
				}
			}
			return sResult;
		}

		/// <summary>
		/// Convierte los datos XML de una Fila en un texto formateado con tabulaciones
		/// </summary>
		/// <param name="rwFila">Fila del Dataset a procesar</param>
		/// <returns></returns>
		private string getText (WSSinCRM.dsRetorno.FilasRow rwFila)
		{
			string sResult="";

			try
			{
				XmlDocument sDoc = new XmlDocument();
				sDoc.LoadXml(rwFila.sKey);
				XmlElement xRoot = sDoc.DocumentElement;
				foreach(XmlNode sitem in xRoot.ChildNodes)
				{
					sResult += "\x09\x09" + sitem.Name + " = " +sitem.InnerText + Utiles.CrLf;
				}
			}
			catch
			{
				sResult = "";
			}
			return sResult;	
		}
		#endregion

		public SincroResult()
		{
			//
			// Necesario para admitir el Diseñador de Windows Forms
			//
			InitializeComponent();

			//
			// TODO: agregar código de constructor después de llamar a InitializeComponent
			//
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

		#region Código generado por el Diseñador de Windows Forms
		/// <summary>
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido del método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(SincroResult));
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.btClipBoard = new System.Windows.Forms.Button();
			this.btGuardar = new System.Windows.Forms.Button();
			this.saveFile = new System.Windows.Forms.SaveFileDialog();
			this.SuspendLayout();
			// 
			// textBox1
			// 
			this.textBox1.AcceptsReturn = true;
			this.textBox1.AcceptsTab = true;
			this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.textBox1.Location = new System.Drawing.Point(8, 40);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox1.Size = new System.Drawing.Size(336, 280);
			this.textBox1.TabIndex = 0;
			this.textBox1.TabStop = false;
			this.textBox1.Text = "";
			// 
			// btClipBoard
			// 
			this.btClipBoard.Image = ((System.Drawing.Image)(resources.GetObject("btClipBoard.Image")));
			this.btClipBoard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btClipBoard.Location = new System.Drawing.Point(8, 8);
			this.btClipBoard.Name = "btClipBoard";
			this.btClipBoard.Size = new System.Drawing.Size(168, 24);
			this.btClipBoard.TabIndex = 1;
			this.btClipBoard.Text = "Copiar al Portapapeles";
			this.btClipBoard.Click += new System.EventHandler(this.btClipBoard_Click);
			// 
			// btGuardar
			// 
			this.btGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btGuardar.Image")));
			this.btGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btGuardar.Location = new System.Drawing.Point(184, 8);
			this.btGuardar.Name = "btGuardar";
			this.btGuardar.Size = new System.Drawing.Size(152, 24);
			this.btGuardar.TabIndex = 2;
			this.btGuardar.Text = "Grabar en archivo";
			this.btGuardar.Click += new System.EventHandler(this.btGuardar_Click);
			// 
			// SincroResult
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(346, 326);
			this.Controls.Add(this.btGuardar);
			this.Controls.Add(this.btClipBoard);
			this.Controls.Add(this.textBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SincroResult";
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Resultados de la Sincronización";
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.sincroResult_KeyPress);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos de botón
		private void btClipBoard_Click(object sender, System.EventArgs e)
		{
			try
			{
				// Guarda los datos del TextBox en el portapapeles
				Clipboard.SetDataObject(textBox1.Text);
			}
			catch (Exception Ex)
			{
				Mensajes.ShowError(Ex.Message);
			}
		}

		private void btGuardar_Click(object sender, System.EventArgs e)
		{
			
			try
			{
				// Guarda los datos del TextBox en un archivo
				System.IO.StreamWriter fContent;
				saveFile.Filter="Archivos de texto (*.txt)|*.txt|Todos los Archivos (*.*)|*.*" ;
				if (saveFile.ShowDialog(this)==DialogResult.OK && saveFile.FileName!="")
				{
					fContent=new StreamWriter(saveFile.FileName,false);
					fContent.Write(this.textBox1.Text);
					fContent.Close();
				}
			}
			catch (Exception Ex)
			{
				Mensajes.ShowError(Ex.Message);
			}
		}

		private void sincroResult_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (e.KeyChar ==(char)Keys.Escape) this.Close();
		}
		#endregion
	}
}
