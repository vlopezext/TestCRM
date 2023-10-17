using System;
using System.Windows.Forms;
using GESTCRM.Formularios;
using System.Data.SqlClient;

namespace GESTCRM
{	
	public class Inicio
	{		
		public static SqlConnection sqlConn = new SqlConnection();

		[STAThread]
		static void Main()
		{
			try
			{
                //---- GSG (13/07/2015)
                // Si el servicio de SQLServer está detenido lo arranca

                string msg = Comun.servicioW("MSSQL$SQLEXPRESS");

                if (msg != "")
                    Application.Exit();

                
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
				//Application.Run(new frmSplash());
                Application.Run(new frmPrincipal());
			}
			catch (Exception e)
			{				
				//Error al iniciar la aplicación
//				Mensajes.ShowError(1002);
				Mensajes.ShowError(e.Message);
				//Clases.Configuracion.Graba();
				Application.Exit();
			}
		}		
	}
}
