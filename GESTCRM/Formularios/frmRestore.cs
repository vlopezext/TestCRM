using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace GESTCRM.Formularios
{
	/// <summary>
	/// Descripción breve de frmRestore.
	/// </summary>
	public class frmRestore : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnRestaura;
		private System.Windows.Forms.Button btnCancelar;
		private System.Windows.Forms.Label lblInfoFichCab;
		private System.Windows.Forms.Label lblInfoFichDet;
		private System.Windows.Forms.ListBox lbFichBackup;
		private System.Data.SqlClient.SqlConnection sqlConn;
		/// <summary>
		/// Variable del diseñador requerida.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmRestore()
		{
            InitializeComponent();

            //---- GSG (06/03/2021)
            Utiles.GetConfigConnection();
            this.sqlConn.ConnectionString = Utiles._connection.ConnectionString.ToString();

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
            this.btnRestaura = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblInfoFichCab = new System.Windows.Forms.Label();
            this.lblInfoFichDet = new System.Windows.Forms.Label();
            this.lbFichBackup = new System.Windows.Forms.ListBox();
            this.sqlConn = new System.Data.SqlClient.SqlConnection();
            this.SuspendLayout();
            // 
            // btnRestaura
            // 
            this.btnRestaura.Enabled = false;
            this.btnRestaura.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRestaura.Location = new System.Drawing.Point(264, 201);
            this.btnRestaura.Name = "btnRestaura";
            this.btnRestaura.Size = new System.Drawing.Size(128, 32);
            this.btnRestaura.TabIndex = 1;
            this.btnRestaura.Text = "Restaurar";
            this.btnRestaura.Click += new System.EventHandler(this.btnRestaura_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(416, 201);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(120, 32);
            this.btnCancelar.TabIndex = 0;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblInfoFichCab
            // 
            this.lblInfoFichCab.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfoFichCab.Location = new System.Drawing.Point(264, 4);
            this.lblInfoFichCab.Name = "lblInfoFichCab";
            this.lblInfoFichCab.Size = new System.Drawing.Size(272, 40);
            this.lblInfoFichCab.TabIndex = 3;
            this.lblInfoFichCab.Text = "Información de la Copia de Seguridad";
            this.lblInfoFichCab.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblInfoFichDet
            // 
            this.lblInfoFichDet.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfoFichDet.Location = new System.Drawing.Point(264, 46);
            this.lblInfoFichDet.Name = "lblInfoFichDet";
            this.lblInfoFichDet.Size = new System.Drawing.Size(272, 150);
            this.lblInfoFichDet.TabIndex = 4;
            this.lblInfoFichDet.Text = "Info";
            // 
            // lbFichBackup
            // 
            this.lbFichBackup.Location = new System.Drawing.Point(8, 8);
            this.lbFichBackup.Name = "lbFichBackup";
            this.lbFichBackup.Size = new System.Drawing.Size(248, 225);
            this.lbFichBackup.TabIndex = 5;
            this.lbFichBackup.SelectedIndexChanged += new System.EventHandler(this.lbFichBackup_SelectedIndexChanged);
            // 
            // sqlConn
            // 
            //this.sqlConn.ConnectionString = ((string)(configurationAppSettings.GetValue("sConn", typeof(string))));//---- GSG (10/09/2014)
            this.sqlConn = Utiles._connection;
            this.sqlConn.FireInfoMessageEventOnUserErrors = false;
            // 
            // frmRestore
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(544, 246);
            this.Controls.Add(this.lbFichBackup);
            this.Controls.Add(this.lblInfoFichDet);
            this.Controls.Add(this.lblInfoFichCab);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnRestaura);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRestore";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Restaurar Copia de Seguridad de GESTCRM";
            this.Load += new System.EventHandler(this.frmRestore_Load);
            this.ResumeLayout(false);

		}
		#endregion

		private void btnCancelar_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void frmRestore_Load(object sender, System.EventArgs e)
		{
			foreach(string sRest in System.IO.Directory.GetFiles(Application.StartupPath + @"\Backup\","*.BAK"))
			{
				this.lbFichBackup.Items.Add(System.IO.Path.GetFileNameWithoutExtension(sRest.ToUpper()));
			}
		}

		private void lbFichBackup_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.lbFichBackup.SelectedIndex>=0)
			{
				string sFile = Application.StartupPath+@"\Backup\"+this.lbFichBackup.Text+".BAK";
				if (System.IO.File.Exists(sFile))
				{
					this.lblInfoFichDet.Text="Nombre: "+System.IO.Path.GetFileName(sFile)+Utiles.CrLf;
					this.lblInfoFichDet.Text+="Fecha: "+System.IO.File.GetCreationTime(sFile).ToLongDateString()+Utiles.CrLf;
					this.lblInfoFichDet.Text+="Hora: "+System.IO.File.GetCreationTime(sFile).ToLongTimeString()+Utiles.CrLf;
				}

				this.btnRestaura.Enabled=true;
			}
			else
			{
				this.btnRestaura.Enabled=false;
			}
		}

		private void btnRestaura_Click(object sender, System.EventArgs e)
		{
			DialogResult dr=Mensajes.ShowQuestion("¿Seguro que desea restaurar "+this.lbFichBackup.Text+"?");
			if (dr==DialogResult.Yes)
			{
				try
				{
//					System.Data.SqlClient.SqlCommand sqlBack = new System.Data.SqlClient.SqlCommand();
//					this.sqlConn.Open();
//					sqlBack.Connection=this.sqlConn;
//					sqlBack.CommandTimeout=1800;
//					sqlBack.CommandText="RESTORE DATABASE GESTCRMCL FROM DISK='"+Application.StartupPath+@"\Backup\"+this.lbFichBackup.Text+".BAK' WITH REPLACE";
//					sqlBack.ExecuteNonQuery();
//					this.sqlConn.Close();

					Mensajes.ShowExclamation("La Restauración de la Copia de Seguridad "+this.lbFichBackup.Text+" se ha realizado con éxito.");
					this.Close();
				}
				catch (Exception excRest)
				{
					Mensajes.ShowError("La Restauración de la Copia de Seguridad "+this.lbFichBackup.Text+" no se ha realizado correctamente.\n"+excRest.Message);
				}
			}
		}
	}
}
