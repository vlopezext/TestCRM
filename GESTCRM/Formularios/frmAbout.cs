using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace GESTCRM.Formularios
{
	/// <summary>
	/// Descripción breve de frmAbout.
	/// </summary>
	public class frmAbout : System.Windows.Forms.Form
    {
		private System.Windows.Forms.PictureBox pbLogoGCRM;
		private System.Windows.Forms.Label lblTitulo;
		private System.Windows.Forms.Label lblVersion;
		private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.PictureBox pbLogoBV;
        private Button btnAceptar;
		/// <summary>
		/// Variable del diseñador requerida.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmAbout()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAbout));
            this.pbLogoGCRM = new System.Windows.Forms.PictureBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.pbLogoBV = new System.Windows.Forms.PictureBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogoGCRM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogoBV)).BeginInit();
            this.SuspendLayout();
            // 
            // pbLogoGCRM
            // 
            this.pbLogoGCRM.Image = ((System.Drawing.Image)(resources.GetObject("pbLogoGCRM.Image")));
            this.pbLogoGCRM.Location = new System.Drawing.Point(73, 30);
            this.pbLogoGCRM.Name = "pbLogoGCRM";
            this.pbLogoGCRM.Size = new System.Drawing.Size(64, 64);
            this.pbLogoGCRM.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbLogoGCRM.TabIndex = 2;
            this.pbLogoGCRM.TabStop = false;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.Navy;
            this.lblTitulo.Location = new System.Drawing.Point(228, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(182, 37);
            this.lblTitulo.TabIndex = 3;
            this.lblTitulo.Text = "GESTCRM";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblVersion
            // 
            this.lblVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.ForeColor = System.Drawing.Color.Navy;
            this.lblVersion.Location = new System.Drawing.Point(237, 54);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(230, 24);
            this.lblVersion.TabIndex = 4;
            this.lblVersion.Text = "label1";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescripcion.ForeColor = System.Drawing.Color.Navy;
            this.lblDescripcion.Location = new System.Drawing.Point(237, 95);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(299, 143);
            this.lblDescripcion.TabIndex = 5;
            this.lblDescripcion.Text = "lblDescripcion";
            this.lblDescripcion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pbLogoBV
            // 
            this.pbLogoBV.Image = global::GESTCRM.Properties.Resources.AF_stada_logo;
            this.pbLogoBV.Location = new System.Drawing.Point(4, 100);
            this.pbLogoBV.Name = "pbLogoBV";
            this.pbLogoBV.Size = new System.Drawing.Size(204, 141);
            this.pbLogoBV.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogoBV.TabIndex = 1;
            this.pbLogoBV.TabStop = false;
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.SystemColors.Window;
            this.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptar.Image")));
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAceptar.Location = new System.Drawing.Point(416, 257);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(100, 38);
            this.btnAceptar.TabIndex = 6;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAceptar.UseVisualStyleBackColor = true;
            // 
            // frmAbout
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 19);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(559, 307);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.pbLogoGCRM);
            this.Controls.Add(this.pbLogoBV);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAbout";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Acerca de GESTCRM";
            this.Load += new System.EventHandler(this.frmAbout_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogoGCRM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogoBV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmAbout_Load(object sender, System.EventArgs e)
		{
			//string crlf = "\x0d\x0a";

			this.lblVersion.Text = "Versión: " + Application.ProductVersion;

            this.lblDescripcion.Text = "Gestion de Fuerza de Ventas realizado por \n\n";// +crlf;
            this.lblDescripcion.Text += Application.CompanyName + "\n\n"; // +crlf;
			this.lblDescripcion.Text += "para Laboratorios STADA S.L.";
		}

	}
}
