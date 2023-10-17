using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GESTCRM.Formularios.Mantenimientos
{
	public class frmMConfiguracion : GESTCRM.Formularios.Base.frmMantenimientos
	{
		private System.Data.SqlClient.SqlConnection sqlConn;
		private System.Data.SqlClient.SqlDataAdapter sqlDAConf;
		private System.Data.SqlClient.SqlCommand sqlSCmdConf;
		private System.Data.SqlClient.SqlCommand sqlICmdConf;
		private System.Data.SqlClient.SqlCommand sqlUCmdConf;
		private System.Data.SqlClient.SqlCommand sqlDCmdConf;
		private GESTCRM.Formularios.Mantenimientos.dsMantenimientos dsMantConf;
		private System.Windows.Forms.DataGrid dgConf;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
		private System.Windows.Forms.Button btnGrabar;
		private System.Windows.Forms.Button btnCancelar;
		private System.ComponentModel.IContainer components = null;

		public frmMConfiguracion()
		{
            // Llamada necesaria para el Diseñador de Windows Forms.
            InitializeComponent();


            //---- GSG (06/03/2021)
            Utiles.GetConfigConnection();
            this.sqlConn.ConnectionString = Utiles._connection.ConnectionString.ToString();
            

			// TODO: agregar cualquier inicialización después de llamar a InitializeComponent
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

		#region Código generado por el diseñador
		/// <summary>
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido del método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{
			System.Configuration.AppSettingsReader configurationAppSettings = new System.Configuration.AppSettingsReader();
            this.sqlConn = new System.Data.SqlClient.SqlConnection();
			this.sqlDAConf = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDCmdConf = new System.Data.SqlClient.SqlCommand();
			this.sqlICmdConf = new System.Data.SqlClient.SqlCommand();
			this.sqlSCmdConf = new System.Data.SqlClient.SqlCommand();
			this.sqlUCmdConf = new System.Data.SqlClient.SqlCommand();
			this.dsMantConf = new GESTCRM.Formularios.Mantenimientos.dsMantenimientos();
			this.dgConf = new System.Windows.Forms.DataGrid();
			this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
			this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.btnGrabar = new System.Windows.Forms.Button();
			this.btnCancelar = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dsMantConf)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgConf)).BeginInit();
			this.SuspendLayout();
            // 
            // sqlConn
            // 
            //this.sqlConn.ConnectionString = ((string)(configurationAppSettings.GetValue("sConn", typeof(string)))); //---- GSG (10/09/2014)
            this.sqlConn = Utiles._connection;
            // 
			// sqlDAConf
			// 
			this.sqlDAConf.DeleteCommand = this.sqlDCmdConf;
			this.sqlDAConf.InsertCommand = this.sqlICmdConf;
			this.sqlDAConf.SelectCommand = this.sqlSCmdConf;
			this.sqlDAConf.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																								new System.Data.Common.DataTableMapping("Table", "Configuracion", new System.Data.Common.DataColumnMapping[] {
																																																				 new System.Data.Common.DataColumnMapping("sConfig", "sConfig"),
																																																				 new System.Data.Common.DataColumnMapping("sValor", "sValor"),
																																																				 new System.Data.Common.DataColumnMapping("iIdConfig", "iIdConfig")})});
			this.sqlDAConf.UpdateCommand = this.sqlUCmdConf;
			// 
			// sqlDCmdConf
			// 
			this.sqlDCmdConf.CommandText = "DELETE FROM Configuracion WHERE (iIdConfig = @Original_iIdConfig)";
			this.sqlDCmdConf.Connection = this.sqlConn;
			this.sqlDCmdConf.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_iIdConfig", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iIdConfig", System.Data.DataRowVersion.Original, null));
			// 
			// sqlICmdConf
			// 
			this.sqlICmdConf.CommandText = "INSERT INTO Configuracion(sConfig, sValor, iIdConfig) VALUES (@sConfig, @sValor, " +
				"@iIdConfig); SELECT sConfig, sValor, iIdConfig FROM Configuracion WHERE (iIdConf" +
				"ig = @iIdConfig)";
			this.sqlICmdConf.Connection = this.sqlConn;
			this.sqlICmdConf.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sConfig", System.Data.SqlDbType.VarChar, 25, "sConfig"));
			this.sqlICmdConf.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sValor", System.Data.SqlDbType.VarChar, 30, "sValor"));
			this.sqlICmdConf.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iIdConfig", System.Data.SqlDbType.Int, 4, "iIdConfig"));
			// 
			// sqlSCmdConf
			// 
			this.sqlSCmdConf.CommandText = "SELECT sConfig, sValor, iIdConfig FROM Configuracion";
			this.sqlSCmdConf.Connection = this.sqlConn;
			// 
			// sqlUCmdConf
			// 
			this.sqlUCmdConf.CommandText = "UPDATE Configuracion SET sConfig = @sConfig, sValor = @sValor, iIdConfig = @iIdCo" +
				"nfig WHERE (iIdConfig = @Original_iIdConfig); SELECT sConfig, sValor, iIdConfig " +
				"FROM Configuracion WHERE (iIdConfig = @iIdConfig)";
			this.sqlUCmdConf.Connection = this.sqlConn;
			this.sqlUCmdConf.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sConfig", System.Data.SqlDbType.VarChar, 25, "sConfig"));
			this.sqlUCmdConf.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sValor", System.Data.SqlDbType.VarChar, 30, "sValor"));
			this.sqlUCmdConf.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iIdConfig", System.Data.SqlDbType.Int, 4, "iIdConfig"));
			this.sqlUCmdConf.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_iIdConfig", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iIdConfig", System.Data.DataRowVersion.Original, null));
			// 
			// dsMantConf
			// 
			this.dsMantConf.DataSetName = "dsMantenimientos";
			this.dsMantConf.Locale = new System.Globalization.CultureInfo("es-ES");
			// 
			// dgConf
			// 
			this.dgConf.DataMember = "Configuracion";
			this.dgConf.DataSource = this.dsMantConf;
			this.dgConf.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgConf.Location = new System.Drawing.Point(8, 8);
			this.dgConf.Name = "dgConf";
			this.dgConf.Size = new System.Drawing.Size(544, 256);
			this.dgConf.TabIndex = 0;
			this.dgConf.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																							   this.dataGridTableStyle1});
			// 
			// dataGridTableStyle1
			// 
			this.dataGridTableStyle1.DataGrid = this.dgConf;
			this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.dataGridTextBoxColumn1,
																												  this.dataGridTextBoxColumn2});
			this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle1.MappingName = "Configuracion";
			// 
			// dataGridTextBoxColumn1
			// 
			this.dataGridTextBoxColumn1.Format = "";
			this.dataGridTextBoxColumn1.FormatInfo = null;
			this.dataGridTextBoxColumn1.HeaderText = "Descripción";
			this.dataGridTextBoxColumn1.MappingName = "sConfig";
			this.dataGridTextBoxColumn1.ReadOnly = true;
			this.dataGridTextBoxColumn1.Width = 300;
			// 
			// dataGridTextBoxColumn2
			// 
			this.dataGridTextBoxColumn2.Format = "";
			this.dataGridTextBoxColumn2.FormatInfo = null;
			this.dataGridTextBoxColumn2.HeaderText = "Valor";
			this.dataGridTextBoxColumn2.MappingName = "sValor";
			this.dataGridTextBoxColumn2.Width = 150;
			// 
			// btnGrabar
			// 
			this.btnGrabar.Location = new System.Drawing.Point(8, 272);
			this.btnGrabar.Name = "btnGrabar";
			this.btnGrabar.TabIndex = 1;
			this.btnGrabar.Text = "Grabar";
			this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
			// 
			// btnCancelar
			// 
			this.btnCancelar.Location = new System.Drawing.Point(88, 272);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.TabIndex = 2;
			this.btnCancelar.Text = "Cancelar";
			this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
			// 
			// frmMConfiguracion
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(560, 310);
			this.Controls.Add(this.btnCancelar);
			this.Controls.Add(this.btnGrabar);
			this.Controls.Add(this.dgConf);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmMConfiguracion";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Mantenimineto de la Configuración";
			this.Load += new System.EventHandler(this.frmMConfiguracion_Load);
			((System.ComponentModel.ISupportInitialize)(this.dsMantConf)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgConf)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void frmMConfiguracion_Load(object sender, System.EventArgs e)
		{
			this.sqlDAConf.Fill(this.dsMantConf);
		}

		private void btnGrabar_Click(object sender, System.EventArgs e)
		{
			this.sqlDAConf.Update(this.dsMantConf);
			this.Close();
		}

		private void btnCancelar_Click(object sender, System.EventArgs e)
		{
			this.dsMantConf.Configuracion.RejectChanges();
			this.Close();
		}
	}
}

