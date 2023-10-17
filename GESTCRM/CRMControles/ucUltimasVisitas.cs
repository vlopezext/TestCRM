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
	public class ucUltimasVisitas : System.Windows.Forms.UserControl
	{
		private System.Data.SqlClient.SqlConnection Conn;
		private bool bConectado = false;
		private int Var_iIdCliente;
		private int Var_NumFila;
		private int Var_iIdReport;
		private int Var_iIdDelegado;
		private string Var_TipoAcceso;

		private System.Windows.Forms.Panel panelRAnkingMatCli;
		private GESTCRM.CRMControles.DataSets.dsCRMControles dsCRMControles1;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
		private GESTCRM.Controles.LabelGradient labelGradient2;
		private System.Windows.Forms.DataGrid dgVisitas;
		private System.Data.SqlClient.SqlDataAdapter sqldaListaUltimasVisitas;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn5;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn6;
		private System.Windows.Forms.Label lblToolTipBoton;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		private System.ComponentModel.IContainer components;

		public ucUltimasVisitas()
		{
			// Llamada necesaria para el Diseñador de formularios Windows.Forms.
			InitializeComponent();

			try
			{
				this.labelGradient2.Text = "Ultimas "+ GESTCRM.Clases.Configuracion.iNumRegCRM.ToString()+" Visitas realizadas al Cliente.";
				Utiles.Formatear_DgConColumnaBoton(this.dgVisitas,"C",null,5);
				this.Var_NumFila=-1;
				this.Var_iIdCliente=-1;
				this.Var_iIdDelegado=-1;
				this.dgVisitas.TableStyles[0].GridColumnStyles[0].Width=0;
				this.dgVisitas.TableStyles[0].GridColumnStyles[1].Width=65;
				this.dgVisitas.TableStyles[0].GridColumnStyles[2].Width=50;
				this.dgVisitas.TableStyles[0].GridColumnStyles[3].Width=200;
				this.dgVisitas.TableStyles[0].GridColumnStyles[4].Width=0;
				if(GESTCRM.Clases.Configuracion.iGVisitas==2)//no tiene acceso a Reports
				{
					this.dgVisitas.TableStyles[0].GridColumnStyles[5].Width=0;
				}
				else
				{
					this.dgVisitas.TableStyles[0].GridColumnStyles[5].Width=40;
					GESTCRM.DataGridButtonColumn clboton1 = (GESTCRM.DataGridButtonColumn)this.dgVisitas.TableStyles[0].GridColumnStyles[5];
					clboton1.CellButtonClicked += 
						new DataGridCellButtonClickEventHandler(HandleCellbtVerReportClick);
				}
				for(int i=0;i<this.dgVisitas.TableStyles[0].GridColumnStyles.Count-1;i++)
				{
					DataGridTextBoxColumn TextCol = (DataGridTextBoxColumn)this.dgVisitas.TableStyles[0].GridColumnStyles[i];
					TextCol.TextBox.DoubleClick += new EventHandler(dgVisitas_DoubleClick);			
				}
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
			this.components = new System.ComponentModel.Container();
			this.panelRAnkingMatCli = new System.Windows.Forms.Panel();
			this.lblToolTipBoton = new System.Windows.Forms.Label();
			this.labelGradient2 = new GESTCRM.Controles.LabelGradient();
			this.dgVisitas = new System.Windows.Forms.DataGrid();
			this.dsCRMControles1 = new GESTCRM.CRMControles.DataSets.dsCRMControles();
			this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
			this.dataGridTextBoxColumn5 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn6 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.sqldaListaUltimasVisitas = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.panelRAnkingMatCli.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgVisitas)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsCRMControles1)).BeginInit();
			this.SuspendLayout();
			// 
			// panelRAnkingMatCli
			// 
			this.panelRAnkingMatCli.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panelRAnkingMatCli.Controls.Add(this.lblToolTipBoton);
			this.panelRAnkingMatCli.Controls.Add(this.labelGradient2);
			this.panelRAnkingMatCli.Controls.Add(this.dgVisitas);
			this.panelRAnkingMatCli.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelRAnkingMatCli.Location = new System.Drawing.Point(0, 0);
			this.panelRAnkingMatCli.Name = "panelRAnkingMatCli";
			this.panelRAnkingMatCli.Size = new System.Drawing.Size(400, 135);
			this.panelRAnkingMatCli.TabIndex = 0;
			// 
			// lblToolTipBoton
			// 
			this.lblToolTipBoton.BackColor = System.Drawing.SystemColors.Info;
			this.lblToolTipBoton.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblToolTipBoton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblToolTipBoton.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblToolTipBoton.Location = new System.Drawing.Point(0, 0);
			this.lblToolTipBoton.Name = "lblToolTipBoton";
			this.lblToolTipBoton.Size = new System.Drawing.Size(12, 13);
			this.lblToolTipBoton.TabIndex = 77;
			this.lblToolTipBoton.Text = "O";
			this.lblToolTipBoton.Visible = false;
			// 
			// labelGradient2
			// 
			this.labelGradient2.Dock = System.Windows.Forms.DockStyle.Top;
			this.labelGradient2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.labelGradient2.ForeColor = System.Drawing.Color.White;
			this.labelGradient2.GradientColorOne = System.Drawing.Color.FromArgb(((System.Byte)(18)), ((System.Byte)(84)), ((System.Byte)(132)));
			this.labelGradient2.GradientColorTwo = System.Drawing.Color.White;
			this.labelGradient2.Location = new System.Drawing.Point(0, 0);
			this.labelGradient2.Name = "labelGradient2";
			this.labelGradient2.Size = new System.Drawing.Size(396, 18);
			this.labelGradient2.TabIndex = 5;
			this.labelGradient2.Text = "labelGradient2";
			this.labelGradient2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// dgVisitas
			// 
			this.dgVisitas.CaptionForeColor = System.Drawing.Color.White;
			this.dgVisitas.CaptionText = "Ranking de Materiales";
			this.dgVisitas.CaptionVisible = false;
			this.dgVisitas.DataMember = "ListaUltimasVisitas";
			this.dgVisitas.DataSource = this.dsCRMControles1;
			this.dgVisitas.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgVisitas.Location = new System.Drawing.Point(-2, 18);
			this.dgVisitas.Name = "dgVisitas";
			this.dgVisitas.ReadOnly = true;
			this.dgVisitas.RowHeaderWidth = 17;
			this.dgVisitas.Size = new System.Drawing.Size(400, 115);
			this.dgVisitas.TabIndex = 0;
			this.dgVisitas.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																								  this.dataGridTableStyle1});
			this.dgVisitas.DoubleClick += new System.EventHandler(this.dgVisitas_DoubleClick);
			this.dgVisitas.CurrentCellChanged += new System.EventHandler(this.dgVisitas_CurrentCellChanged);
			this.dgVisitas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dgVisitas_MouseMove);
			// 
			// dsCRMControles1
			// 
			this.dsCRMControles1.DataSetName = "dsCRMControles";
			this.dsCRMControles1.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// dataGridTableStyle1
			// 
			this.dataGridTableStyle1.DataGrid = this.dgVisitas;
			this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.dataGridTextBoxColumn5,
																												  this.dataGridTextBoxColumn1,
																												  this.dataGridTextBoxColumn2,
																												  this.dataGridTextBoxColumn3,
																												  this.dataGridTextBoxColumn4,
																												  this.dataGridTextBoxColumn6});
			this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle1.MappingName = "ListaUltimasVisitas";
			this.dataGridTableStyle1.RowHeaderWidth = 17;
			// 
			// dataGridTextBoxColumn5
			// 
			this.dataGridTextBoxColumn5.Format = "";
			this.dataGridTextBoxColumn5.FormatInfo = null;
			this.dataGridTextBoxColumn5.MappingName = "iIdReport";
			this.dataGridTextBoxColumn5.NullText = "";
			this.dataGridTextBoxColumn5.Width = 0;
			// 
			// dataGridTextBoxColumn1
			// 
			this.dataGridTextBoxColumn1.Format = "dd/MM/yyyy";
			this.dataGridTextBoxColumn1.FormatInfo = null;
			this.dataGridTextBoxColumn1.HeaderText = "Fecha";
			this.dataGridTextBoxColumn1.MappingName = "dFecha";
			this.dataGridTextBoxColumn1.NullText = "";
			this.dataGridTextBoxColumn1.Width = 60;
			// 
			// dataGridTextBoxColumn2
			// 
			this.dataGridTextBoxColumn2.Format = "";
			this.dataGridTextBoxColumn2.FormatInfo = null;
			this.dataGridTextBoxColumn2.HeaderText = "Horario";
			this.dataGridTextBoxColumn2.MappingName = "tHorario";
			this.dataGridTextBoxColumn2.NullText = "";
			this.dataGridTextBoxColumn2.Width = 50;
			// 
			// dataGridTextBoxColumn3
			// 
			this.dataGridTextBoxColumn3.Format = "";
			this.dataGridTextBoxColumn3.FormatInfo = null;
			this.dataGridTextBoxColumn3.HeaderText = "Centro";
			this.dataGridTextBoxColumn3.MappingName = "Centro";
			this.dataGridTextBoxColumn3.NullText = "";
			this.dataGridTextBoxColumn3.Width = 200;
			// 
			// dataGridTextBoxColumn4
			// 
			this.dataGridTextBoxColumn4.Format = "";
			this.dataGridTextBoxColumn4.FormatInfo = null;
			this.dataGridTextBoxColumn4.HeaderText = "Prox.Obj";
			this.dataGridTextBoxColumn4.MappingName = "tProxObj";
			this.dataGridTextBoxColumn4.NullText = "";
			this.dataGridTextBoxColumn4.Width = 0;
			// 
			// dataGridTextBoxColumn6
			// 
			this.dataGridTextBoxColumn6.Format = "";
			this.dataGridTextBoxColumn6.FormatInfo = null;
			this.dataGridTextBoxColumn6.MappingName = "Boton";
			this.dataGridTextBoxColumn6.NullText = "";
			this.dataGridTextBoxColumn6.Width = 40;
			// 
			// sqldaListaUltimasVisitas
			// 
			this.sqldaListaUltimasVisitas.SelectCommand = this.sqlSelectCommand1;
			this.sqldaListaUltimasVisitas.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																											   new System.Data.Common.DataTableMapping("Table", "ListaUltimasVisitas", new System.Data.Common.DataColumnMapping[] {
																																																									  new System.Data.Common.DataColumnMapping("iIdReport", "iIdReport"),
																																																									  new System.Data.Common.DataColumnMapping("dFecha", "dFecha"),
																																																									  new System.Data.Common.DataColumnMapping("tFecha", "tFecha"),
																																																									  new System.Data.Common.DataColumnMapping("Centro", "Centro"),
																																																									  new System.Data.Common.DataColumnMapping("iHorario", "iHorario"),
																																																									  new System.Data.Common.DataColumnMapping("tHorario", "tHorario"),
																																																									  new System.Data.Common.DataColumnMapping("tProxObj", "tProxObj"),
																																																									  new System.Data.Common.DataColumnMapping("Boton", "Boton"),
																																																									  new System.Data.Common.DataColumnMapping("bEnviadoCEN", "bEnviadoCEN")})});
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = "[ListaUltimasVisitas]";
			this.sqlSelectCommand1.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@NumReg", System.Data.SqlDbType.Int, 4));
			// 
			// ucUltimasVisitas
			// 
			this.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.Controls.Add(this.panelRAnkingMatCli);
			this.ForeColor = System.Drawing.Color.Black;
			this.Name = "ucUltimasVisitas";
			this.Size = new System.Drawing.Size(400, 135);
			this.Load += new System.EventHandler(this.ucUltimasVisitas_Load);
			this.panelRAnkingMatCli.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgVisitas)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsCRMControles1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region ucUltimasVisitas_Load
		private void ucUltimasVisitas_Load(object sender, System.EventArgs e)
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
                Conn = new System.Data.SqlClient.SqlConnection();
                //---- GSG (10/09/2014)
                //Conn.ConnectionString = GESTCRM.Clases.Configuracion.sqlCadenaCon;
                Conn = Utiles._connection;
                


				this.sqldaListaUltimasVisitas.SelectCommand.Connection = Conn;
				bConectado = true;
			}
			catch(Exception ex) {Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region UltimasVisitasPorCliente
		public void UltimasVisitasPorCliente(int iIdCliente,int iIdDelegado,string TipoAcceso)
		{
			try
			{
				Establecer_ConexionBD();

				Var_iIdCliente = iIdCliente;
				Var_iIdDelegado = iIdDelegado;
				Var_TipoAcceso= TipoAcceso;
				this.dsCRMControles1.ListaUltimasVisitas.Rows.Clear();
				this.sqldaListaUltimasVisitas.SelectCommand.Parameters["@iIdCliente"].Value = iIdCliente;
				//this.sqldaListaUltimasVisitas.SelectCommand.Parameters["@NumReg"].Value = GESTCRM.Clases.Configuracion.iNumRegCRM;

				this.sqldaListaUltimasVisitas.Fill(this.dsCRMControles1);

				//Como solo queremos ver los n primeros:
				GESTCRM.Utiles.Row_Count (this, dgVisitas, (int)GESTCRM.Clases.Configuracion.iNumRegCRM);

				if(this.dsCRMControles1.ListaUltimasVisitas.Rows.Count>0)
				{
					this.dgVisitas.CurrentRowIndex=0;
					this.Var_NumFila= this.dgVisitas.CurrentRowIndex;
					Utiles.Seleccionar_UnaFilaDataGrid(this.dgVisitas,this.Var_NumFila,this.dsCRMControles1.ListaUltimasVisitas.Rows.Count);
					this.Var_iIdReport = Int32.Parse(this.dgVisitas[0,0].ToString());
				}
			}
			catch(Exception ex) {Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region dgVisitas_DoubleClick
		private void dgVisitas_DoubleClick(object sender, System.EventArgs e)
		{
			Acceso_FormularioReport(this.Var_iIdReport);
		}
		#endregion

		#region dgVisitas_CurrentCellChanged
		private void dgVisitas_CurrentCellChanged(object sender, System.EventArgs e)
		{
			try
			{
				this.Var_NumFila= this.dgVisitas.CurrentRowIndex;
				Utiles.Seleccionar_UnaFilaDataGrid(this.dgVisitas,this.Var_NumFila,this.dsCRMControles1.ListaUltimasVisitas.Rows.Count);
				this.Var_iIdReport = Int32.Parse(this.dgVisitas[this.Var_NumFila,0].ToString());
			}
			catch(Exception ex) {Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region dgVisitas_MouseMouve
		private void dgVisitas_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			dgVisitas_ToolTip(this.dgVisitas,e.X,e.Y);
		}

		private void dgVisitas_ToolTip(DataGrid dg, int cx, int cy)
		{
			try
			{
				System.Windows.Forms.DataGrid.HitTestInfo myHitTest;
				myHitTest = dg.HitTest(cx,cy);
				int columna = myHitTest.Column;
				int fila = myHitTest.Row;


				if(fila>-1 && columna==5)
					//			if(fila>-1)
				{
					this.lblToolTipBoton.Visible=true;
					int y = dg.Location.Y + cy;
					int x = dg.Location.X + dg.Width-100;
					System.Drawing.Point p = new Point(x+10,y+15);
					this.lblToolTipBoton.Location =p;
					this.lblToolTipBoton.Text = "Acceso al Report";
					this.lblToolTipBoton.AutoSize=true;
				}
				else
				{
					this.lblToolTipBoton.Visible=false;
				}
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion

		#region btVerReport_Click
		private void btVerReport_Click(object sender, System.EventArgs e)
		{
			Acceso_FormularioReport(this.Var_iIdReport);
		}
		#endregion

		#region Acceso_FormularioReport
		private void Acceso_FormularioReport(int fila)
		{
			try
			{
				if(GESTCRM.Clases.Configuracion.iGVisitas<2)//tiene acceso a Reports
				{
					this.Var_iIdReport = Int32.Parse(this.dgVisitas[fila,0].ToString());

					string Acceso;

					if(this.Var_TipoAcceso == "C") Acceso="C";
					else Acceso="M";
					if(GESTCRM.Clases.Configuracion.iGVisitas==1) Acceso="C";

					if(this.Var_iIdReport > -1)
					{
						bool abierto=false;
						if(this.ParentForm.Owner==null && this.ParentForm.ParentForm == null)
						{
							Mensajes.ShowInformation("No se puede abrir el formulario. Demasiadas ventanas abiertas.");
						}
						else
						{
							if(this.ParentForm.ParentForm == null) abierto=Utiles.MirarSiFormAbierto("frmReporting",this.ParentForm.Owner);
							else abierto = Utiles.MirarSiFormAbierto("frmReporting",this.ParentForm.ParentForm);
							if (abierto && Acceso!="C")
							{
								DialogResult dr=Mensajes.ShowQuestion("No se puede modificar el report porque ya hay uno abierto. Si quiere modificar un cliente report el que ya está abierto. ¿Desea abrirlo en modo consulta?");
								if(dr==System.Windows.Forms.DialogResult.Yes)
								{
									abierto=false;
									Acceso="C";
								}
							}
							if (!abierto)
							{
								Form frmTemp=new Formularios.frmReporting(Acceso,this.Var_iIdReport,DateTime.Today,this.Var_iIdDelegado);
								frmTemp.MdiParent = this.ParentForm.MdiParent;
								//frmTemp.ShowDialog(this);
								frmTemp.Show();
							}
						}
					}
				}
			}
			catch(Exception ex) {Mensajes.ShowError(ex.Message);}
		}
		#endregion
		
		// handler for a click on one of the gridcell buttons
		#region HandleCellbtVerReportClick
		private void HandleCellbtVerReportClick(object sender, DataGridCellButtonClickEventArgs e)
		{
			Acceso_FormularioReport(e.RowIndex);
		}
		#endregion

	
	}
}
