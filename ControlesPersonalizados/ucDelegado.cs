using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace GESTCRM
{
	/// <summary>
	/// Descripción breve de ucDelegado.
	/// </summary>
	public class ucDelegado : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.Label lblDelegado;
		private System.Windows.Forms.ComboBox cbDelegado;
        private ControlesPersonalizados.dsUserControl dsUserControl1;
		private System.Data.SqlClient.SqlConnection sqlConn;
		private System.Data.SqlClient.SqlDataAdapter sqldaListaDelegados;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand1;

		/// <summary> 
		/// Variable del diseñador requerida.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ucDelegado()
		{
			// Llamada necesaria para el Diseñador de formularios Windows.Forms.
			InitializeComponent();

			// TODO: agregar cualquier inicialización después de llamar a InitializeComponent

			Cargar_cbDelegado();
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
			this.lblDelegado = new System.Windows.Forms.Label();
			this.cbDelegado = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// lblDelegado
			// 
			this.lblDelegado.Location = new System.Drawing.Point(0, 0);
			this.lblDelegado.Name = "lblDelegado";
			this.lblDelegado.Size = new System.Drawing.Size(56, 23);
			this.lblDelegado.TabIndex = 0;
			this.lblDelegado.Text = "Delegado:";
			this.lblDelegado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cbDelegado
			// 
			this.cbDelegado.DisplayMember = "sNombre";
			this.cbDelegado.Location = new System.Drawing.Point(56, 0);
			this.cbDelegado.Name = "cbDelegado";
			this.cbDelegado.Size = new System.Drawing.Size(300, 21);
			this.cbDelegado.TabIndex = 1;
			this.cbDelegado.ValueMember = "iIdDelegado";
			// 
			// ucDelegado
			// 
			this.Controls.Add(this.lblDelegado);
			this.Controls.Add(this.cbDelegado);
			this.Name = "ucDelegado";
			this.Size = new System.Drawing.Size(360, 24);
			this.ResumeLayout(false);

		}
		#endregion

	
		protected void Cargar_cbDelegado()
		{
            this.dsUserControl1 = new ControlesPersonalizados.dsUserControl();
			this.sqlConn = new System.Data.SqlClient.SqlConnection(GESTCRM.GESTCRMUtilidades.sConn);
			this.sqldaListaDelegados = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
//			this.sqlConn.Open();

			this.sqldaListaDelegados.SelectCommand = this.sqlSelectCommand1;
			this.sqldaListaDelegados.TableMappings.AddRange((new System.Data.Common.DataTableMapping[] 
				{
					new System.Data.Common.DataTableMapping("Table", 
															"ListaDelegados", 
															new System.Data.Common.DataColumnMapping[] 
															{
																new System.Data.Common.DataColumnMapping("iIdDelegado", "iIdDelegado"),
																new System.Data.Common.DataColumnMapping("sNombre", "sNombre")
															}
														   )
				}));


			this.sqlSelectCommand1.CommandText = "[ListaDelegados]";
			this.sqlSelectCommand1.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelectCommand1.Connection = this.sqlConn;
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));


			this.dsUserControl1.DataSetName = "dsUserControl";
			this.dsUserControl1.Locale = new System.Globalization.CultureInfo("es-ES");


			this.cbDelegado.DataSource = this.dsUserControl1.ListaDelegados;
			this.cbDelegado.ValueMember = "iIdDelegado";
			this.cbDelegado.DisplayMember="sNombre";
			this.sqldaListaDelegados.Fill(this.dsUserControl1);
//			
//			this.sqlConn.Close();

//			this.sqlDataAdapter1.Fill(this.dsUserControl1);

		}

		public void Set_Valor(string valor)
		{
			this.cbDelegado.SelectedValue=valor;
		}

		public string Get_Valor()
		{
			return cbDelegado.SelectedValue.ToString();
		}

	}
}
