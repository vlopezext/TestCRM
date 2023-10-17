using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace GESTCRM
{	
	public class Datos
	{
		public static GESTCRM.Formularios.dsFormularios dsForms = new GESTCRM.Formularios.dsFormularios();

		public static void RellenaComboDatos(ComboBox cbox, SqlDataReader DataReader,int Columnna)
		{
			while(DataReader.Read())
			{					
				cbox.Items.Add(DataReader.GetValue(Columnna).ToString().Trim());
			}
		}



	}
}
