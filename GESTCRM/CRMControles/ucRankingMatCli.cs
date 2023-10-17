using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using GESTCRM.Controles;

namespace GESTCRM.CRMControles
{
	/// <summary>
	/// Descripción breve de UserControl1.
	/// </summary>
	public class ucRankingMatCli : System.Windows.Forms.UserControl
	{
		private System.Data.SqlClient.SqlConnection Conn;
		private bool bConectado = false;
		private int Var_iIdCliente;
		private int Var_NumFila;

		private System.Windows.Forms.Panel panelRAnkingMatCli;
		private System.Data.SqlClient.SqlDataAdapter sqldaListaRankingMateriales;
		private GESTCRM.CRMControles.DataSets.dsCRMControles dsCRMControles1;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
		private System.Windows.Forms.DateTimePicker dtpFechaFin;
		private System.Windows.Forms.DateTimePicker dtpFechaIni;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private GESTCRM.Controles.LabelGradient labelGradient2;
		private System.Windows.Forms.Button btActualizar;
		private System.Windows.Forms.DataGrid dgRanking;
		/// <summary> 
		/// Variable del diseñador requerida.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ucRankingMatCli()
		{
			// Llamada necesaria para el Diseñador de formularios Windows.Forms.
			InitializeComponent();
			try
			{
				this.labelGradient2.Text = "Rankig de los "+ GESTCRM.Clases.Configuracion.iNumRegCRM.ToString()+" Materiales más vendidos.";
				this.dtpFechaFin.Value = DateTime.Today;
				this.dtpFechaIni.Value = DateTime.Parse("01/01/"+DateTime.Today.Year.ToString());
				Utiles.Formatear_DataGrid(this.dgRanking,"C",null);
				this.Var_NumFila=-1;
				this.Var_iIdCliente=-1;
				this.dgRanking.TableStyles[0].GridColumnStyles[2].Width=120;
			}
			catch(Exception ex) {Mensajes.ShowError(ex.Message);}
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

		#region Código generado por el Diseñador de componentes
		/// <summary> 
		/// Método necesario para admitir el Diseñador. No se puede modificar 
		/// el contenido del método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{
            this.panelRAnkingMatCli = new System.Windows.Forms.Panel();
            this.dtpFechaIni = new System.Windows.Forms.DateTimePicker();
            this.btActualizar = new System.Windows.Forms.Button();
            this.labelGradient2 = new GESTCRM.Controles.LabelGradient();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.dgRanking = new System.Windows.Forms.DataGrid();
            this.dsCRMControles1 = new GESTCRM.CRMControles.DataSets.dsCRMControles();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.sqldaListaRankingMateriales = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
            this.panelRAnkingMatCli.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgRanking)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsCRMControles1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelRAnkingMatCli
            // 
            this.panelRAnkingMatCli.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelRAnkingMatCli.Controls.Add(this.dtpFechaIni);
            this.panelRAnkingMatCli.Controls.Add(this.btActualizar);
            this.panelRAnkingMatCli.Controls.Add(this.labelGradient2);
            this.panelRAnkingMatCli.Controls.Add(this.label2);
            this.panelRAnkingMatCli.Controls.Add(this.label1);
            this.panelRAnkingMatCli.Controls.Add(this.dtpFechaFin);
            this.panelRAnkingMatCli.Controls.Add(this.dgRanking);
            this.panelRAnkingMatCli.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRAnkingMatCli.Location = new System.Drawing.Point(0, 0);
            this.panelRAnkingMatCli.Name = "panelRAnkingMatCli";
            this.panelRAnkingMatCli.Size = new System.Drawing.Size(400, 145);
            this.panelRAnkingMatCli.TabIndex = 0;
            // 
            // dtpFechaIni
            // 
            this.dtpFechaIni.CalendarForeColor = System.Drawing.Color.Black;
            this.dtpFechaIni.CalendarMonthBackground = System.Drawing.Color.White;
            this.dtpFechaIni.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.dtpFechaIni.CalendarTitleForeColor = System.Drawing.Color.White;
            this.dtpFechaIni.CalendarTrailingForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dtpFechaIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaIni.Location = new System.Drawing.Point(77, 22);
            this.dtpFechaIni.Name = "dtpFechaIni";
            this.dtpFechaIni.Size = new System.Drawing.Size(88, 20);
            this.dtpFechaIni.TabIndex = 2;
            // 
            // btActualizar
            // 
            this.btActualizar.Location = new System.Drawing.Point(320, 20);
            this.btActualizar.Name = "btActualizar";
            this.btActualizar.Size = new System.Drawing.Size(75, 23);
            this.btActualizar.TabIndex = 6;
            this.btActualizar.Text = "Actualizar";
            this.btActualizar.UseVisualStyleBackColor = true;
            this.btActualizar.Click += new System.EventHandler(this.btActualizar_Click);
            // 
            // labelGradient2
            // 
            this.labelGradient2.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelGradient2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGradient2.ForeColor = System.Drawing.Color.White;
            this.labelGradient2.GradientColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.labelGradient2.GradientColorTwo = System.Drawing.Color.White;
            this.labelGradient2.Location = new System.Drawing.Point(0, 0);
            this.labelGradient2.Name = "labelGradient2";
            this.labelGradient2.Size = new System.Drawing.Size(396, 18);
            this.labelGradient2.TabIndex = 5;
            this.labelGradient2.Text = "labelGradient2";
            this.labelGradient2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(165, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "entre";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(2, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Fecha Pedido:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.CalendarForeColor = System.Drawing.Color.Black;
            this.dtpFechaFin.CalendarMonthBackground = System.Drawing.Color.White;
            this.dtpFechaFin.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.dtpFechaFin.CalendarTitleForeColor = System.Drawing.Color.White;
            this.dtpFechaFin.CalendarTrailingForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new System.Drawing.Point(195, 22);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(88, 20);
            this.dtpFechaFin.TabIndex = 1;
            // 
            // dgRanking
            // 
            this.dgRanking.CaptionForeColor = System.Drawing.Color.White;
            this.dgRanking.CaptionText = "Ranking de Materiales";
            this.dgRanking.CaptionVisible = false;
            this.dgRanking.DataMember = "ListaRankingMateriales";
            this.dgRanking.DataSource = this.dsCRMControles1;
            this.dgRanking.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgRanking.Location = new System.Drawing.Point(-2, 44);
            this.dgRanking.Name = "dgRanking";
            this.dgRanking.ReadOnly = true;
            this.dgRanking.RowHeaderWidth = 17;
            this.dgRanking.Size = new System.Drawing.Size(400, 99);
            this.dgRanking.TabIndex = 0;
            this.dgRanking.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            this.dgRanking.Paint += new System.Windows.Forms.PaintEventHandler(this.dgRanking_Paint);
            // 
            // dsCRMControles1
            // 
            this.dsCRMControles1.DataSetName = "dsCRMControles";
            this.dsCRMControles1.Locale = new System.Globalization.CultureInfo("en-US");
            this.dsCRMControles1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.DataGrid = this.dgRanking;
            this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn1,
            this.dataGridTextBoxColumn2,
            this.dataGridTextBoxColumn3,
            this.dataGridTextBoxColumn4});
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle1.MappingName = "ListaRankingMateriales";
            this.dataGridTableStyle1.RowHeaderWidth = 17;
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "Cód.SAP";
            this.dataGridTextBoxColumn1.MappingName = "sIdMaterial";
            this.dataGridTextBoxColumn1.NullText = "";
            this.dataGridTextBoxColumn1.Width = 75;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "Cód.Nacional";
            this.dataGridTextBoxColumn2.MappingName = "sCodNacional";
            this.dataGridTextBoxColumn2.NullText = "";
            this.dataGridTextBoxColumn2.Width = 75;
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.HeaderText = "Descripción";
            this.dataGridTextBoxColumn3.MappingName = "sMaterial";
            this.dataGridTextBoxColumn3.NullText = "";
            this.dataGridTextBoxColumn3.Width = 120;
            // 
            // dataGridTextBoxColumn4
            // 
            this.dataGridTextBoxColumn4.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.dataGridTextBoxColumn4.Format = "";
            this.dataGridTextBoxColumn4.FormatInfo = null;
            this.dataGridTextBoxColumn4.HeaderText = "Tot.Cantidad";
            this.dataGridTextBoxColumn4.MappingName = "Suma";
            this.dataGridTextBoxColumn4.NullText = "";
            this.dataGridTextBoxColumn4.Width = 75;
            // 
            // sqldaListaRankingMateriales
            // 
            this.sqldaListaRankingMateriales.SelectCommand = this.sqlSelectCommand1;
            this.sqldaListaRankingMateriales.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaRankingMateriales", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("sIdMaterial", "sIdMaterial"),
                        new System.Data.Common.DataColumnMapping("sCodNacional", "sCodNacional"),
                        new System.Data.Common.DataColumnMapping("sMaterial", "sMaterial"),
                        new System.Data.Common.DataColumnMapping("Suma", "Suma")})});
            // 
            // sqlSelectCommand1
            // 
            this.sqlSelectCommand1.CommandText = "[ListaRankingMateriales]";
            this.sqlSelectCommand1.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@dFechaIni", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@dFechaFin", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@NumReg", System.Data.SqlDbType.Int, 4)});
            // 
            // ucRankingMatCli
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Controls.Add(this.panelRAnkingMatCli);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "ucRankingMatCli";
            this.Size = new System.Drawing.Size(400, 145);
            this.Load += new System.EventHandler(this.ucRankingMatCli_Load);
            this.panelRAnkingMatCli.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgRanking)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsCRMControles1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region ucRankingMatCli_Load
		private void ucRankingMatCli_Load(object sender, System.EventArgs e)
		{
		}
		#endregion

		#region Establecer_ConexionBD
		private void Establecer_ConexionBD() 
		{
			if (bConectado)
				return;

			try
			{
                //---- GSG (10/09/2014)
                Conn = new System.Data.SqlClient.SqlConnection();
                //Conn.ConnectionString = GESTCRM.Clases.Configuracion.sqlCadenaCon;
                Conn = Utiles._connection;

				this.sqldaListaRankingMateriales.SelectCommand.Connection = Conn;
				bConectado = true;
			}
			catch(Exception ex) {Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region RankingPorCliente
		public void RankingPorCliente(int iIdCliente)
		{
			try
			{
				Establecer_ConexionBD();

				Var_iIdCliente = iIdCliente;
				this.dsCRMControles1.ListaRankingMateriales.Rows.Clear();
				this.sqldaListaRankingMateriales.SelectCommand.Parameters["@iIdCliente"].Value = iIdCliente;
				this.sqldaListaRankingMateriales.SelectCommand.Parameters["@dFechaIni"].Value = this.dtpFechaIni.Value;
				this.sqldaListaRankingMateriales.SelectCommand.Parameters["@dFechaFin"].Value = this.dtpFechaFin.Value;
				//this.sqldaListaRankingMateriales.SelectCommand.Parameters["@NumReg"].Value = GESTCRM.Clases.Configuracion.iNumRegCRM;

				this.sqldaListaRankingMateriales.Fill(this.dsCRMControles1);

				//Como solo queremos ver los n primeros:
				GESTCRM.Utiles.Row_Count (this, dgRanking, (int)GESTCRM.Clases.Configuracion.iNumRegCRM);

				

				if(this.dsCRMControles1.ListaRankingMateriales.Rows.Count>0)
				{
					this.dgRanking.CurrentRowIndex=0;
					this.Var_NumFila= this.dgRanking.CurrentRowIndex;
					Utiles.Seleccionar_UnaFilaDataGrid(this.dgRanking,this.Var_NumFila,this.dsCRMControles1.ListaRankingMateriales.Rows.Count);
				}
			}
			catch(Exception ex) {Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region btActualizar_Click
		private void btActualizar_Click(object sender, System.EventArgs e)
		{
			RankingPorCliente(Var_iIdCliente);
		}
		#endregion

		#region dgRanking_Paint
		private void dgRanking_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			try
			{
				if(this.dgRanking.CurrentRowIndex!=-1 && this.Var_NumFila != this.dgRanking.CurrentRowIndex)
				{
					this.Var_NumFila= this.dgRanking.CurrentRowIndex;
					Utiles.Seleccionar_UnaFilaDataGrid(this.dgRanking,this.Var_NumFila,this.dsCRMControles1.ListaRankingMateriales.Rows.Count);
				}
			}		
			catch(Exception ex) {Mensajes.ShowError(ex.Message);}
		}
		#endregion
	}
}
