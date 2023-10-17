using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace GESTCRM.Formularios
{
	/// <summary>
	/// Descripción breve de frmActualiza.
	/// </summary>
	public class frmActualiza : System.Windows.Forms.Form
	{
		private System.Data.SqlClient.SqlConnection sqlConn;
		private System.Data.SqlClient.SqlCommand sqlCmdAct;
		private System.Data.SqlClient.SqlTransaction sqlTrans;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button btnFin;
		private System.Windows.Forms.Label lblTitulo;
		private System.Windows.Forms.Label lblTiulo2;
		private System.Windows.Forms.Label lblSubTitulo;
		private System.Windows.Forms.TextBox tbProceso;
		private System.Windows.Forms.TextBox tbCmdText;
		/// <summary>
		/// Variable del diseñador requerida.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmActualiza()
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
			System.Configuration.AppSettingsReader configurationAppSettings = new System.Configuration.AppSettingsReader();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmActualiza));
			this.sqlConn = new System.Data.SqlClient.SqlConnection();
			this.sqlCmdAct = new System.Data.SqlClient.SqlCommand();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.lblTitulo = new System.Windows.Forms.Label();
			this.btnFin = new System.Windows.Forms.Button();
			this.lblTiulo2 = new System.Windows.Forms.Label();
			this.lblSubTitulo = new System.Windows.Forms.Label();
			this.tbProceso = new System.Windows.Forms.TextBox();
			this.tbCmdText = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// sqlConn
			// 
			this.sqlConn.ConnectionString = ((string)(configurationAppSettings.GetValue("sConn", typeof(string))));
			// 
			// sqlCmdAct
			// 
			this.sqlCmdAct.Connection = this.sqlConn;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(8, 8);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(112, 136);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// lblTitulo
			// 
			this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblTitulo.Location = new System.Drawing.Point(128, 8);
			this.lblTitulo.Name = "lblTitulo";
			this.lblTitulo.Size = new System.Drawing.Size(216, 16);
			this.lblTitulo.TabIndex = 1;
			this.lblTitulo.Text = "Se está actualizando GESTCRM";
			// 
			// btnFin
			// 
			this.btnFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnFin.Location = new System.Drawing.Point(8, 152);
			this.btnFin.Name = "btnFin";
			this.btnFin.Size = new System.Drawing.Size(112, 48);
			this.btnFin.TabIndex = 2;
			this.btnFin.Text = "Salir";
			this.btnFin.Visible = false;
			this.btnFin.Click += new System.EventHandler(this.btnFin_Click);
			// 
			// lblTiulo2
			// 
			this.lblTiulo2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblTiulo2.Location = new System.Drawing.Point(128, 32);
			this.lblTiulo2.Name = "lblTiulo2";
			this.lblTiulo2.Size = new System.Drawing.Size(216, 24);
			this.lblTiulo2.TabIndex = 3;
			this.lblTiulo2.Text = "Procesando el Fichero:";
			// 
			// lblSubTitulo
			// 
			this.lblSubTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblSubTitulo.Location = new System.Drawing.Point(8, 208);
			this.lblSubTitulo.Name = "lblSubTitulo";
			this.lblSubTitulo.Size = new System.Drawing.Size(336, 32);
			this.lblSubTitulo.TabIndex = 4;
			this.lblSubTitulo.Text = "¡¡ Ha finalizado la actualización!! ";
			this.lblSubTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblSubTitulo.Visible = false;
			// 
			// tbProceso
			// 
			this.tbProceso.AcceptsReturn = true;
			this.tbProceso.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tbProceso.CausesValidation = false;
			this.tbProceso.Location = new System.Drawing.Point(128, 56);
			this.tbProceso.Multiline = true;
			this.tbProceso.Name = "tbProceso";
			this.tbProceso.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbProceso.Size = new System.Drawing.Size(216, 144);
			this.tbProceso.TabIndex = 5;
			this.tbProceso.Text = "tbProceso";
			this.tbProceso.WordWrap = false;
			// 
			// tbCmdText
			// 
			this.tbCmdText.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.tbCmdText.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tbCmdText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tbCmdText.Location = new System.Drawing.Point(352, 8);
			this.tbCmdText.Multiline = true;
			this.tbCmdText.Name = "tbCmdText";
			this.tbCmdText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.tbCmdText.Size = new System.Drawing.Size(320, 232);
			this.tbCmdText.TabIndex = 6;
			this.tbCmdText.Text = "SQL";
			// 
			// frmActualiza
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(688, 254);
			this.ControlBox = false;
			this.Controls.Add(this.tbCmdText);
			this.Controls.Add(this.tbProceso);
			this.Controls.Add(this.lblSubTitulo);
			this.Controls.Add(this.lblTiulo2);
			this.Controls.Add(this.btnFin);
			this.Controls.Add(this.lblTitulo);
			this.Controls.Add(this.pictureBox1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmActualiza";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Actualización de GESTCRM";
			this.Activated += new System.EventHandler(this.frmActualiza_Activated);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnFin_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void Actualizar()
		{
			Cursor.Current=Cursors.WaitCursor;
			
			string sRaiz = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
			string regS="";
			this.sqlConn.Open();
			this.sqlTrans = this.sqlConn.BeginTransaction();
			this.sqlCmdAct.Transaction=this.sqlTrans;
			this.sqlCmdAct.CommandTimeout=1800;
			this.tbProceso.Text="";

			try
			{
				this.tbProceso.Text="Iniciando proceso de ficheros. "+DateTime.Now.ToString()+Utiles.CrLf;
				foreach(string sF in System.IO.Directory.GetFiles(sRaiz,"*.sql"))
				{
					this.tbProceso.Text+="Fichero: "+System.IO.Path.GetFileName(sF)+Utiles.CrLf;
					this.tbProceso.Text+="Inicio Fichero: "+DateTime.Now.ToString()+Utiles.CrLf;
					this.Refresh();
					this.sqlCmdAct.CommandText="";
					this.tbCmdText.Text="";

					System.IO.StreamReader srF = new System.IO.StreamReader(sF,System.Text.Encoding.Default);
					while((regS=srF.ReadLine())!=null)
					{
						this.tbCmdText.Text+=regS;
						this.tbCmdText.Text=this.tbCmdText.Text.Replace("\r","")+Utiles.CrLf;
						this.tbCmdText.Text=this.tbCmdText.Text.Replace("\n","")+Utiles.CrLf;
						this.tbCmdText.Text=this.tbCmdText.Text.Replace("\t"," ");
						this.Refresh();
						regS=regS.Replace("\t"," ");
						regS=regS.Replace("\r","");
						regS=regS.Replace("\n","");
						regS=regS.Trim()+" ";
						if (regS.Trim()!="") this.sqlCmdAct.CommandText+=regS;
					}
					this.sqlCmdAct.ExecuteNonQuery();
					srF.Close();

					System.IO.File.Copy(sF,sRaiz+@"\Actualizaciones\"+System.IO.Path.GetFileName(sF),true);
					System.IO.File.Delete(sF);
					this.tbProceso.Text+="Fin Fichero: "+DateTime.Now.ToString()+Utiles.CrLf;
					this.Refresh();
				}
				this.tbProceso.Text+="Fin proceso de ficheros. "+DateTime.Now.ToString()+Utiles.CrLf;
				this.Refresh();

				this.sqlTrans.Commit();
			}
			catch(Exception excAct)
			{
				this.sqlTrans.Rollback();
				Mensajes.ShowError("Contacte con HelpDesk e indique el siguiente error:\n"+excAct.Message);
			}

			this.sqlConn.Close();
			this.sqlConn.Dispose();

			this.lblSubTitulo.Visible=true;
			this.btnFin.Visible=true;
			Cursor.Current=Cursors.Default;
		}

		private void frmActualiza_Activated(object sender, System.EventArgs e)
		{
			if (Cursor.Current!=Cursors.WaitCursor)
			{
				this.Actualizar();
			}
		}
	}
}
