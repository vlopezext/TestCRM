using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

using System.Windows.Forms;


namespace GESTCRM.Formularios.Mantenimientos
{
	public class frmMAccMarketing : GESTCRM.Formularios.Base.frmMantenimientos
	{
		private System.Data.SqlClient.SqlConnection sqlConn;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtsIdCliente;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtTipo;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtsNombre;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private GESTCRM.Controles.LabelGradient labelGradient1;
		private System.Windows.Forms.Label lblTotAcciones;
		private System.Windows.Forms.DataGrid dgAcciones;
		private System.Windows.Forms.Button btEliminarAcc;
		private System.Windows.Forms.Button btActualizarAcc;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.Button btBuscaAccion;
		private System.Windows.Forms.TextBox txtAccObservEntrega;
		private System.Windows.Forms.NumericUpDown nupAccCantidad;
		private System.Windows.Forms.DateTimePicker dtpAccFEntrega;
		private System.Windows.Forms.TextBox txtAccsIdAccion;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Button btCancelar;
		private GESTCRM.Controles.ucBotoneraSecundaria ucBotoneraSecundaria1;
		private System.ComponentModel.IContainer components = null;

		public frmMAccMarketing()
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
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Designer generated code
		/// <summary>
		/// Método necesario para admitir el Diseñador, no se puede modificar
		/// el contenido del método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{
            System.Configuration.AppSettingsReader configurationAppSettings = new System.Configuration.AppSettingsReader();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMAccMarketing));
            this.sqlConn = new System.Data.SqlClient.SqlConnection();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtsNombre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTipo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtsIdCliente = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btEliminarAcc = new System.Windows.Forms.Button();
            this.btActualizarAcc = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btBuscaAccion = new System.Windows.Forms.Button();
            this.txtAccObservEntrega = new System.Windows.Forms.TextBox();
            this.nupAccCantidad = new System.Windows.Forms.NumericUpDown();
            this.dtpAccFEntrega = new System.Windows.Forms.DateTimePicker();
            this.txtAccsIdAccion = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblTotAcciones = new System.Windows.Forms.Label();
            this.labelGradient1 = new GESTCRM.Controles.LabelGradient();
            this.dgAcciones = new System.Windows.Forms.DataGrid();
            this.btCancelar = new System.Windows.Forms.Button();
            this.ucBotoneraSecundaria1 = new GESTCRM.Controles.ucBotoneraSecundaria();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupAccCantidad)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgAcciones)).BeginInit();
            this.SuspendLayout();
            // 
            // sqlConn
            // 
            //this.sqlConn.ConnectionString = ((string)(configurationAppSettings.GetValue("sConn", typeof(string))));//---- GSG (10/09/2014)
            this.sqlConn = Utiles._connection;
            this.sqlConn.FireInfoMessageEventOnUserErrors = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtsNombre);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtTipo);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtsIdCliente);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(736, 40);
            this.panel1.TabIndex = 0;
            // 
            // txtsNombre
            // 
            this.txtsNombre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtsNombre.Location = new System.Drawing.Point(240, 8);
            this.txtsNombre.Name = "txtsNombre";
            this.txtsNombre.ReadOnly = true;
            this.txtsNombre.Size = new System.Drawing.Size(328, 20);
            this.txtsNombre.TabIndex = 5;
            this.txtsNombre.TabStop = false;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(184, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "Nombre:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTipo
            // 
            this.txtTipo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtTipo.Location = new System.Drawing.Point(608, 8);
            this.txtTipo.Name = "txtTipo";
            this.txtTipo.ReadOnly = true;
            this.txtTipo.Size = new System.Drawing.Size(120, 20);
            this.txtTipo.TabIndex = 3;
            this.txtTipo.TabStop = false;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(576, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tipo:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtsIdCliente
            // 
            this.txtsIdCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtsIdCliente.Location = new System.Drawing.Point(56, 8);
            this.txtsIdCliente.Name = "txtsIdCliente";
            this.txtsIdCliente.ReadOnly = true;
            this.txtsIdCliente.Size = new System.Drawing.Size(120, 20);
            this.txtsIdCliente.TabIndex = 1;
            this.txtsIdCliente.TabStop = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Código:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.btEliminarAcc);
            this.panel2.Controls.Add(this.btActualizarAcc);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(1, 80);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(736, 336);
            this.panel2.TabIndex = 1;
            // 
            // btEliminarAcc
            // 
            this.btEliminarAcc.Image = ((System.Drawing.Image)(resources.GetObject("btEliminarAcc.Image")));
            this.btEliminarAcc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btEliminarAcc.Location = new System.Drawing.Point(88, 240);
            this.btEliminarAcc.Name = "btEliminarAcc";
            this.btEliminarAcc.Size = new System.Drawing.Size(75, 23);
            this.btEliminarAcc.TabIndex = 6;
            this.btEliminarAcc.Text = "Eli&minar";
            this.btEliminarAcc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btEliminarAcc.UseVisualStyleBackColor = true;
            // 
            // btActualizarAcc
            // 
            this.btActualizarAcc.Image = ((System.Drawing.Image)(resources.GetObject("btActualizarAcc.Image")));
            this.btActualizarAcc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btActualizarAcc.Location = new System.Drawing.Point(8, 240);
            this.btActualizarAcc.Name = "btActualizarAcc";
            this.btActualizarAcc.Size = new System.Drawing.Size(80, 23);
            this.btActualizarAcc.TabIndex = 5;
            this.btActualizarAcc.Text = "Act&ualizar";
            this.btActualizarAcc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btActualizarAcc.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel5.Controls.Add(this.btBuscaAccion);
            this.panel5.Controls.Add(this.txtAccObservEntrega);
            this.panel5.Controls.Add(this.nupAccCantidad);
            this.panel5.Controls.Add(this.dtpAccFEntrega);
            this.panel5.Controls.Add(this.txtAccsIdAccion);
            this.panel5.Controls.Add(this.label17);
            this.panel5.Controls.Add(this.label16);
            this.panel5.Controls.Add(this.label15);
            this.panel5.Controls.Add(this.label14);
            this.panel5.Location = new System.Drawing.Point(4, 264);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(722, 64);
            this.panel5.TabIndex = 4;
            // 
            // btBuscaAccion
            // 
            this.btBuscaAccion.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btBuscaAccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btBuscaAccion.Image = ((System.Drawing.Image)(resources.GetObject("btBuscaAccion.Image")));
            this.btBuscaAccion.Location = new System.Drawing.Point(112, 16);
            this.btBuscaAccion.Name = "btBuscaAccion";
            this.btBuscaAccion.Size = new System.Drawing.Size(21, 21);
            this.btBuscaAccion.TabIndex = 4;
            this.btBuscaAccion.UseVisualStyleBackColor = true;
            // 
            // txtAccObservEntrega
            // 
            this.txtAccObservEntrega.Location = new System.Drawing.Point(392, 16);
            this.txtAccObservEntrega.MaxLength = 8000;
            this.txtAccObservEntrega.Multiline = true;
            this.txtAccObservEntrega.Name = "txtAccObservEntrega";
            this.txtAccObservEntrega.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAccObservEntrega.Size = new System.Drawing.Size(328, 40);
            this.txtAccObservEntrega.TabIndex = 3;
            // 
            // nupAccCantidad
            // 
            this.nupAccCantidad.Location = new System.Drawing.Point(336, 16);
            this.nupAccCantidad.Name = "nupAccCantidad";
            this.nupAccCantidad.Size = new System.Drawing.Size(56, 20);
            this.nupAccCantidad.TabIndex = 2;
            // 
            // dtpAccFEntrega
            // 
            this.dtpAccFEntrega.Location = new System.Drawing.Point(136, 16);
            this.dtpAccFEntrega.Name = "dtpAccFEntrega";
            this.dtpAccFEntrega.Size = new System.Drawing.Size(200, 20);
            this.dtpAccFEntrega.TabIndex = 1;
            // 
            // txtAccsIdAccion
            // 
            this.txtAccsIdAccion.Location = new System.Drawing.Point(4, 16);
            this.txtAccsIdAccion.MaxLength = 10;
            this.txtAccsIdAccion.Name = "txtAccsIdAccion";
            this.txtAccsIdAccion.Size = new System.Drawing.Size(108, 20);
            this.txtAccsIdAccion.TabIndex = 0;
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(392, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(168, 18);
            this.label17.TabIndex = 7;
            this.label17.Text = "Observaciones de la Entrega:";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(136, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(100, 18);
            this.label16.TabIndex = 6;
            this.label16.Text = "Fecha Entrega:";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(336, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(60, 18);
            this.label15.TabIndex = 5;
            this.label15.Text = "Cantidad:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(100, 18);
            this.label14.TabIndex = 4;
            this.label14.Text = "Cód.Accion:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.lblTotAcciones);
            this.panel3.Controls.Add(this.labelGradient1);
            this.panel3.Controls.Add(this.dgAcciones);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(732, 232);
            this.panel3.TabIndex = 0;
            // 
            // lblTotAcciones
            // 
            this.lblTotAcciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.lblTotAcciones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotAcciones.Location = new System.Drawing.Point(668, 0);
            this.lblTotAcciones.Name = "lblTotAcciones";
            this.lblTotAcciones.Size = new System.Drawing.Size(60, 18);
            this.lblTotAcciones.TabIndex = 1;
            this.lblTotAcciones.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelGradient1
            // 
            this.labelGradient1.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelGradient1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGradient1.ForeColor = System.Drawing.Color.White;
            this.labelGradient1.GradientColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.labelGradient1.GradientColorTwo = System.Drawing.Color.White;
            this.labelGradient1.Location = new System.Drawing.Point(0, 0);
            this.labelGradient1.Name = "labelGradient1";
            this.labelGradient1.Size = new System.Drawing.Size(728, 18);
            this.labelGradient1.TabIndex = 0;
            this.labelGradient1.Text = "Acciones de Marketing";
            this.labelGradient1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgAcciones
            // 
            this.dgAcciones.CaptionVisible = false;
            this.dgAcciones.DataMember = "";
            this.dgAcciones.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgAcciones.Location = new System.Drawing.Point(0, 16);
            this.dgAcciones.Name = "dgAcciones";
            this.dgAcciones.Size = new System.Drawing.Size(728, 212);
            this.dgAcciones.TabIndex = 2;
            // 
            // btCancelar
            // 
            this.btCancelar.Location = new System.Drawing.Point(0, 0);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(75, 23);
            this.btCancelar.TabIndex = 0;
            // 
            // ucBotoneraSecundaria1
            // 
            this.ucBotoneraSecundaria1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(117)))), ((int)(((byte)(1)))));
            this.ucBotoneraSecundaria1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucBotoneraSecundaria1.ForeColor = System.Drawing.Color.Black;
            this.ucBotoneraSecundaria1.Location = new System.Drawing.Point(0, 0);
            this.ucBotoneraSecundaria1.Name = "ucBotoneraSecundaria1";
            this.ucBotoneraSecundaria1.Size = new System.Drawing.Size(738, 38);
            this.ucBotoneraSecundaria1.TabIndex = 7;
            // 
            // frmMAccMarketing
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(738, 415);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.ucBotoneraSecundaria1);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "frmMAccMarketing";
            this.Text = "Acciones de Marketing de un Cliente";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupAccCantidad)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgAcciones)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion


	}
}

