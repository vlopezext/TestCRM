using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace GESTCRM.Formularios
{
	/// <summary>
	/// Descripción breve de frmPopup.
	/// </summary>
	public class frmPopup : System.Windows.Forms.Form
	{
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.Timer tmrPopup;


		public static string TextoInfo = "";
		public static int cordX = 0;
		private System.Windows.Forms.Label lblInfo;
		public static int cordY = 0;


		public frmPopup()
		{			
			InitializeComponent();
		}

		public frmPopup(string Info, int x, int y)
		{			
			InitializeComponent();
			TextoInfo = Info;
			cordX = x;
			cordY = y;
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Método necesario para admitir el Diseñador, no se puede modificar
		/// el contenido del método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.tmrPopup = new System.Windows.Forms.Timer(this.components);
			this.lblInfo = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// tmrPopup
			// 
			this.tmrPopup.Interval = 10;
			this.tmrPopup.Tick += new System.EventHandler(this.tmrPopup_Tick);
			// 
			// lblInfo
			// 
			this.lblInfo.Font = new System.Drawing.Font("Verdana", 8.25F, (System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic), System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblInfo.Name = "lblInfo";
			this.lblInfo.Size = new System.Drawing.Size(224, 56);
			this.lblInfo.TabIndex = 1;
			this.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// frmPopup
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.SystemColors.Info;
			this.ClientSize = new System.Drawing.Size(216, 32);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.lblInfo});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Location = new System.Drawing.Point(100, 100);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmPopup";
			this.Load += new System.EventHandler(this.frmPopup_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmPopup_Load(object sender, System.EventArgs e)
		{
			this.lblInfo.Text = TextoInfo;
			this.tmrPopup.Interval = 2000;
			this.tmrPopup.Start();			
			this.Left = cordY + 10;
			this.Top = cordX + 10;
		}

		private void tmrPopup_Tick(object sender, System.EventArgs e)
		{
			this.Close();
		}
	}
}
