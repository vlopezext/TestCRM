using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data.SqlClient;
using System.ComponentModel;



namespace GESTCRM
{	
	public class Utiles
	{
		//		private static int FilaSeleccionada;
		//		private static int NumColumnas;

		public static System.Drawing.Font fuenteBold = new System.Drawing.Font("Microsoft Sans Serif",8.25F,FontStyle.Bold); 
		public static System.Drawing.Font fuenteNoBold = new System.Drawing.Font("Microsoft Sans Serif",8.25F);
        //---- GSG (13/03/2019)
        public static System.Drawing.Font fuenteBoldBig = new System.Drawing.Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
        public static System.Drawing.Font fuenteNoBoldBig = new System.Drawing.Font("Microsoft Sans Serif", 12F);

        public static Color ColorFondoFormulario =		Color.FromArgb(238,243,246);
		public static Color ColorFondoTituloDataGrid  = Color.FromArgb(18,84,132);
		public static Color ColorSelecionFilaDataGrid = Color.FromArgb(221,255,221);//(192,255,192);
		public static Color ColorFondoPanel			  = Color.FromArgb(224,224,224);
		public static string CrLf = "\x0d\x0a";

		public static string sPatternTelNumber =@"\A((\(\d{2}\) ?)|(\d{2}))?-{0,1}\d{3}-{0,1}\d{4}\z";
		public static string sPatternTelGuide = "(XX)-YYY-ZZZZ\n\nXX-YYY-ZZZZ\n\nXXYYYZZZZ";
		public static string sPatternCelNumber =@"\A((\(\d{2}\) ?)|(\d{2}))?-{0,1}\d{3}-{0,1}\d{3}-{0,1}\d{3}\z";
		public static string sPatternCelGuide = "(XX)-YYY-ZZZ-ZZZ\n\nXX-YYY-ZZZ-VVZ\n\nXXYYYZZZZZZ";
		public static string sPatternEmailPat = @"\A\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*\z";
		public static string sPattrenEmailGuide = "Ejemplo@domain.com\n\nEjemplo-dos@domain.com";
		public static string sPattrenNIFPat = @"\AX{0,1}\d{7,8}-{0,1}((\d{1})|(\D{1}))\z";
		public static string sPattrenNIFGuide = "21345678-A\n\nX6357676V";
		public static string sPatternOnlyCharsAndSpace =@"[a-zA-Z,\s]";
		public static string sPatternOnlyCharsAndSpaceGuide = "Sólo Caracteres Alfanuméricos, Espacios y Comas.";
		public static string sPatternNumCol = @"\d{2}";
		public static string sPatternNumCol2 = @"\d{5}";
		public static string sPatternNumColGuide = "Introducir toda la información. Sólo Caracteres numéricos";

		public static bool Cargar_Planificacion = false;

		//		ColorFondoFormulario = Color.FromArgb(238,243,246);

		#region Funciones Numéricas
		/// <summary>
		/// Función que sirve para determinar si un string es número o no.
		/// </summary>
		/// <param name="number">string que le pasamos para ver si es un número o no.</param>
		/// <returns></returns>
		public static bool EsNumero(string number)
		{
			try
			{
				number = number.Trim();

				if (number.Length != 0)
				{
					int i = 0;
					foreach (char c in number)
					{
						if (c == '.')
						{
							i ++;
						}
					}

					if (i <= 1)
					{
						number = number.Replace(".", "");

						foreach (char c in number)
						{
							if (!char.IsNumber(c))
							{
								return false;
							}
						}

						return true;
					}

					return false;
				}

				return true;
			}
			catch
			{
				return false;
			}
		}

		public static bool IsDecimal(string number)
		{
			try
			{
				decimal.Parse(number);
				return true;
			}
			catch
			{
				return false;
			}
		}
		#endregion


        #region conexión

        //---- GSG (10/09/2014)

        public static SqlConnection _connection = new SqlConnection();
        public static string _connectionString = "";

        public static void GetConfigConnection()
        {
            SqlConnection sqlConn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["sConn"].ToString());
            _connectionString = System.Configuration.ConfigurationManager.AppSettings["sConn"].ToString();

            //---- GSG (06/03/2021)
			_connectionString = _connectionString.Replace("sNfcp3A3GPChmdaRdkyMaPq2OMw=", "Bayvit2409");
			_connectionString = _connectionString.Replace("o8FWg/8plXMYIhwTUwAY9f/6n8s=", "Bayvit240900000"); //---- GSG (2023 canvi sql local sols per a mi)
	
			sqlConn.ConnectionString = _connectionString;


            try
            {
                sqlConn.Open();
                sqlConn.Close();
            }
            catch (Exception err)
            {
                sqlConn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["sConn2"].ToString());
                _connectionString = System.Configuration.ConfigurationManager.AppSettings["sConn2"].ToString();

            }

            _connection = sqlConn;

            _connection.ConnectionString = _connectionString; //---- GSG (06/03/2021)
        }

        #endregion


        #region Funciones Datos

        public static string NombreDeleg(int idDeleg)
		{
			string Retorno = "";
            //---- GSG (10/09/2014)
            //SqlConnection sqlConn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["sConn"].ToString());
            SqlConnection sqlConn = new SqlConnection();
            sqlConn = Utiles._connection;


            //---- GSG (10/09/2014)
            //this.sqlConn.Open();
            if (sqlConn.State == ConnectionState.Closed)
                sqlConn.Open();

			//			SqlTransaction sqlTran = sqlConn.BeginTransaction();
			SqlCommand sqlCmd = sqlConn.CreateCommand();
			sqlCmd.CommandText="GetNombreDeleg";
			sqlCmd.CommandType=CommandType.StoredProcedure;
			sqlCmd.Parameters.Add("@iIdDelegado",SqlDbType.Int);
			sqlCmd.Parameters["@iIdDelegado"].Value=idDeleg;
			SqlDataReader drDeleg = sqlCmd.ExecuteReader();
			if (drDeleg.Read())
			{
				Retorno = drDeleg["sNombre"].ToString();					
			}
			drDeleg.Close();
			sqlConn.Close();
            //---- GSG (10/09/2014)
            //sqlConn.Dispose();

			return (Retorno);			
		}


        //---- GSG (18/09/2012)
        public static string DecilCliente(int iIdCliente)
        {
            string Retorno = "";
            //---- GSG (10/09/2014)
            //SqlConnection sqlConn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["sConn"].ToString());
            SqlConnection sqlConn = new SqlConnection();
            sqlConn = Utiles._connection;

            //---- GSG (10/09/2014)
            //this.sqlConn.Open();
            if (sqlConn.State == ConnectionState.Closed)
                sqlConn.Open();

            SqlCommand sqlCmd = sqlConn.CreateCommand();
            sqlCmd.CommandText = "GetDecilCliente";
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.Add("@iIdCliente", SqlDbType.Int);
            sqlCmd.Parameters["@iIdCliente"].Value = iIdCliente;
            SqlDataReader drDecil = sqlCmd.ExecuteReader();
            if (drDecil.Read())
            {
                Retorno = drDecil["sDescAccion"].ToString();
            }
            drDecil.Close();
            sqlConn.Close();
            //---- GSG (10/09/2014)
            //sqlConn.Dispose();
            return (Retorno);
        }

        //---- GSG (06/05/205)
        public static string DecilProvincialCliente(int iIdCliente)
        {
            string Retorno = "";
            SqlConnection sqlConn = new SqlConnection();
            sqlConn = Utiles._connection;

            if (sqlConn.State == ConnectionState.Closed)
                sqlConn.Open();

            SqlCommand sqlCmd = sqlConn.CreateCommand();
            sqlCmd.CommandText = "GetDecilProvincialCliente";
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.Add("@iIdCliente", SqlDbType.Int);
            sqlCmd.Parameters["@iIdCliente"].Value = iIdCliente;
            SqlDataReader drDecil = sqlCmd.ExecuteReader();
            if (drDecil.Read())
            {
                Retorno = drDecil["sDescAccion"].ToString();
            }
            drDecil.Close();
            sqlConn.Close();

            return (Retorno);
        }


        //---- GSG (06/03/2021)
        // El mensaje tendrá que ser diferente en cada caso
        // 0: no hay mensaje (el false de antes)
        // 1: deuda vencida
        // 2: Enc comercial
        // 3: las dos cosas
        //public static bool DeudaVencida(int iIdCliente)
        public static int DeudaVencida(int iIdCliente)
        {
            //---- GSG (06/03/2021)
            //bool Retorno = false;
            int Retorno = 0;


            //---- GSG (10/09/2014)
            //SqlConnection sqlConn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["sConn"].ToString());
            SqlConnection sqlConn = new SqlConnection();
            sqlConn = Utiles._connection;

            //---- GSG (10/09/2014)
            //this.sqlConn.Open();
            if (sqlConn.State == ConnectionState.Closed)
                sqlConn.Open();

            SqlCommand sqlCmd = sqlConn.CreateCommand();
            sqlCmd.CommandText = "GetDeudaVencida";
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.Add("@iIdCliente", SqlDbType.Int);
            sqlCmd.Parameters["@iIdCliente"].Value = iIdCliente;
            SqlDataReader drDeuda = sqlCmd.ExecuteReader();
            if (drDeuda.Read())
            {
                //---- GSG (15/10/2012)
                //Retorno = (double.Parse(drDeuda["fDeudaVenc"].ToString()) > 0);
                //---- GSG (06/03/2021)
                //Retorno = (double.Parse(drDeuda["fDeudaVenc"].ToString()) > 0 || drDeuda["sEncComercial"].ToString().ToUpper() == "X");

                if (double.Parse(drDeuda["fDeudaVenc"].ToString()) > 0 && drDeuda["sEncComercial"].ToString().ToUpper() == "X")
                    Retorno = 3;
                else if (double.Parse(drDeuda["fDeudaVenc"].ToString()) > 0)
                    Retorno = 1;
                else if (drDeuda["sEncComercial"].ToString().ToUpper() == "X")
                    Retorno = 2;

            }
            drDeuda.Close();
            sqlConn.Close();
            //---- GSG (10/09/2014)
            //sqlConn.Dispose();
            return (Retorno);
        }

        //---- GSG (12/03/2014)
        public static string[] GetClubsCliente(int iIdCliente)
        {
            string[] garanties = new string[5];

            //---- GSG (10/09/2014)
            //SqlConnection sqlConn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["sConn"].ToString());
            SqlConnection sqlConn = new SqlConnection();
            sqlConn = Utiles._connection;

            try
            {
                if (sqlConn.State.ToString() == "Closed")
                    sqlConn.Open();

                SqlCommand sqlCmd = sqlConn.CreateCommand();
                sqlCmd.CommandText = "GetCliente_SAP";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.Add("@iIdCliente", SqlDbType.Int, 4);
                sqlCmd.Parameters["@iIdCliente"].Value = iIdCliente;

                SqlDataReader dr = sqlCmd.ExecuteReader();

                if (dr.Read())
                {
                    garanties[0] = dr["sGarantias_SAP"].ToString();
                    garanties[1] = dr["sGarantias_SAP_1"].ToString();
                    garanties[2] = dr["sGarantias_SAP_2"].ToString();
                    garanties[3] = dr["sGarantias_SAP_3"].ToString();
                    garanties[4] = dr["sGarantias_SAP_4"].ToString();
                }

                dr.Close();
            }
            catch (Exception err)
            {
                Mensajes.ShowError(err.ToString());
            }

            sqlConn.Close();

            return garanties;
        }

        //---- GSG (28/10/2015) 
        // Obtener el código de una campaña a partir de su descripción o parte de ella.
        public static string CodigoCampanya(string nombre)
        {
            string Retorno = "";
            SqlConnection sqlConn = new SqlConnection();
            sqlConn = Utiles._connection;

            try
            {
                if (sqlConn.State == ConnectionState.Closed)
                    sqlConn.Open();

                SqlCommand sqlCmd = sqlConn.CreateCommand();
                sqlCmd.CommandText = "GetCodCampanya";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.Add("@NombreCampanya", SqlDbType.VarChar, 100);

                sqlCmd.Parameters["@NombreCampanya"].Value = nombre;

                SqlDataReader dr = sqlCmd.ExecuteReader();
                if (dr.Read())
                {
                    Retorno = dr[0].ToString();
                }
                dr.Close();                           
            }
            catch(Exception e)
            {
                string error = e.Message;
            }

            sqlConn.Close();
            return (Retorno);
        }


        //---- GSG (19/09/2017)
        public static int CodigoCliente(string cliente)
        {
            int Retorno = -1;
            SqlConnection sqlConn = new SqlConnection();
            sqlConn = Utiles._connection;

            try
            {
                if (sqlConn.State == ConnectionState.Closed)
                    sqlConn.Open();

                SqlCommand sqlCmd = sqlConn.CreateCommand();
                sqlCmd.CommandText = "GetIdCliente";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.Add("@sIdCliente", SqlDbType.VarChar, 20);


                sqlCmd.Parameters["@sIdCliente"].Value = cliente;

                SqlDataReader dr = sqlCmd.ExecuteReader();
                if (dr.Read())
                {
                    Retorno = int.Parse(dr[0].ToString());
                }
                dr.Close();
            }
            catch (Exception e)
            {
                string error = e.Message;
            }

            sqlConn.Close();
            return (Retorno);
        }


        //---- GSG (13/03/2019)
        //---- GSG (19/09/2017)
        //public static string ProximoObjetivoVisita(int iIdCliente, int IdReport)
        public static string ProximoObjetivoVisita(int iIdCliente, int IdReport, DateTime dFecha)
        {
            string Retorno = "";
            SqlConnection sqlConn = new SqlConnection();
            sqlConn = Utiles._connection;

            if (sqlConn.State == ConnectionState.Closed)
                sqlConn.Open();

            SqlCommand sqlCmd = sqlConn.CreateCommand();
            sqlCmd.CommandText = "GetObjetivoVisita";
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.Add("@iIdCliente", SqlDbType.Int);
            sqlCmd.Parameters["@iIdCliente"].Value = iIdCliente;
            sqlCmd.Parameters.Add("@IdReport", SqlDbType.Int);
            sqlCmd.Parameters["@IdReport"].Value = IdReport;
            //---- GSG (13/03/2019)
            sqlCmd.Parameters.Add("@dFecha", SqlDbType.DateTime);
            sqlCmd.Parameters["@dFecha"].Value = dFecha;



            SqlDataReader dr = sqlCmd.ExecuteReader();
            if (dr.Read())
            {
                Retorno = dr["tProxObj"].ToString();
            }
            dr.Close();
            sqlConn.Close();

            return (Retorno);
        }



       
        #endregion


        #region Mirar Si está abierto algún formulario MDI
        public static bool MirarSiFormAbierto(string Formulario,Form Padre)
		{
			bool EstaAbierto = false;

			int NumeroFormsAbiertos =   Padre.MdiChildren.Length;
			string NombreFormulario = "";
			if (NumeroFormsAbiertos == 0)
			{
				EstaAbierto = false;
			}
			else
			{
				for (int i=0; i<NumeroFormsAbiertos;i++)
				{					
					NombreFormulario=Padre.MdiChildren.GetValue(i).ToString();
					NombreFormulario=NombreFormulario.Substring(NombreFormulario.LastIndexOf(".")+1);
					NombreFormulario=NombreFormulario.Substring(0,NombreFormulario.IndexOf(","));
					if (Formulario == NombreFormulario)
					{
						EstaAbierto = true;
						break;
					}					
				}
			}
			return(EstaAbierto);
		}

		#endregion

		#region Formato_Formulario: Da Formato al Formulario segun se abre como Dialogo o no
		public static void Formato_Formulario(Form Formulario)
		{
			if (Formulario.Parent == null)
			{
				Formulario.Visible = false;
				Formulario.WindowState = FormWindowState.Maximized;
				Formulario.WindowState = FormWindowState.Normal;
				Formulario.FormBorderStyle = FormBorderStyle.Sizable;
				Formulario.Top = 28;//48;		//0;					|
				Formulario.Left = 57;       //55;					|
                Formulario.Height = 582; //710;//666;	//656;//560;			| //--- GSG (13/03/2019)
				Formulario.Width =	964;	//936;//775;	<--------
				Formulario.BackColor = Color.FromArgb(238,243,246);
				Formulario.MaximizeBox = false;
				Formulario.MinimizeBox = false;
				Formulario.BringToFront();
				Formulario.AutoScroll = true;
				//Formulario.Focus();
				//Formulario.Activate();

				Formulario.Visible= true;
				//				Formulario.Left = (Screen.PrimaryScreen.WorkingArea.Width - Formulario.Width) /2;
				//				Formulario.Top = (Screen.PrimaryScreen.WorkingArea.Height - Formulario.Height) /2;

			}
			else
			{
				Formulario.AutoScroll = true;
				Formulario.WindowState = FormWindowState.Maximized;
			}
		}
		#endregion

		#region Inicio_Formulario
		public static void Inicio_Formulario(Form Formulario)
		{
			/*	Formulario.WindowState = FormWindowState.Maximized;
				Formulario.Height=520;
				Formulario.Width=760;
				Formulario.AutoScroll=true;
				Formulario.BackColor = Color.FromArgb(238,243,246);
			*/
			Formulario.Height=494;
			Formulario.Width=796;
			Formulario.AutoScroll=true;
			Formulario.BackColor = Color.FromArgb(238,243,246);
			Formulario.WindowState = FormWindowState.Maximized;
		}	
		#endregion

		#region ActivarBotonesBarraAcciones
		// Si se pasa una "A"				-> activa el boton de la botonera 
		// Si se pasa otro caracter ("D")	-> desactiva el boton de la botonera 
		public static void ActivarBotonesBarraAcciones(Panel pn, string Acciones)
		{
			if (Acciones.Length == 6)
			{
				foreach(Control c in pn.Controls)
				{
					string tipo=null;
					tipo = c.GetType().ToString();
					switch(tipo)
					{
						case "System.Windows.Forms.Button":
							Button bt = (Button) c;
						switch (c.Name.ToString())
						{
							case "btbNuevo":
								// Nuevo
								if (Acciones.Substring(0,1).ToString() == "A")
								{
									c.Enabled = true;
								}	
								else
								{
									c.Enabled = false;
								}
								break;

							case "btbEditar":
								// Editar
								if (Acciones.Substring(1,1).ToString() == "A")
								{
									c.Enabled = true;
								}	
								else
								{
									c.Enabled = false;
								}
								break;
							case "btbEliminar":
								// Eliminar
								if (Acciones.Substring(2,1).ToString() == "A")
								{
									c.Enabled = true;
								}	
								else
								{
									c.Enabled = false;
								}
								break;
							case "btbGuardar":
								// Guardar
								if (Acciones.Substring(3,1).ToString() == "A")
								{
									c.Enabled = true;
								}	
								else
								{
									c.Enabled = false;
								}
								break;
							case "btbImprimir":
								// Imprimir
								if (Acciones.Substring(4,1).ToString() == "A")
								{
									c.Enabled = true;
								}	
								else
								{
									c.Enabled = false;
								}
								break;
							case "btbSalir":
								// Salir
								if (Acciones.Substring(5,1).ToString() == "A")
								{
									c.Enabled = true;
								}	
								else
								{
									c.Enabled = false;
								}
								break;
							default:break;
						}
							break;
						default: break;
					}
				}
			}
		}
		#endregion

		//Formatear_DataGrid
		//Da color al Título y a la cabecera de columnas
		//parámetro Acceso
		// "C" -> Sólo Consulta, color de fondo el del formulario
		// Otros Valores -> color de fondo del DataGrid Blanco
		#region Formatear_DataGrid
		public static void Formatear_DataGrid(Form Formulario,DataGrid dg, string Acceso, bool SoloLectura,ContextMenu menu)
		{
			Color ColorFondo = new Color();
			if(Acceso=="C") ColorFondo = ColorFondoFormulario;
			else ColorFondo=Color.White;

			dg.AlternatingBackColor = ColorFondo;
			dg.BackColor = ColorFondo;
			dg.BackgroundColor = ColorFondo;
			dg.CaptionBackColor = ColorFondoTituloDataGrid;//Color.FromArgb(18,84,132);
			dg.CaptionForeColor = Color.White; 
			dg.RowHeaderWidth = 17;
			dg.SelectionBackColor = ColorSelecionFilaDataGrid;//Color.FromArgb(192,255,192);
			dg.SelectionForeColor = Color.Black;

			try
			{
				dg.TableStyles[0].AlternatingBackColor = ColorFondo;
				dg.TableStyles[0].BackColor = ColorFondo;
				dg.TableStyles[0].HeaderBackColor = ColorFondoPanel;
				dg.TableStyles[0].RowHeaderWidth = 17;
				dg.TableStyles[0].SelectionBackColor = ColorSelecionFilaDataGrid;//Color.FromArgb(192,255,192);
				dg.TableStyles[0].SelectionForeColor = Color.Black;
				for(int i=0;i<dg.TableStyles[0].GridColumnStyles.Count;i++)
				{
					dg.TableStyles[0].GridColumnStyles[i].ReadOnly=true;
					DataGridTextBoxColumn TextCol0 = (DataGridTextBoxColumn)dg.TableStyles[0].GridColumnStyles[i];
					TextCol0.TextBox.ContextMenu = menu;
					if(!SoloLectura)
					{
						TextCol0.TextBox.Enabled=false;
						TextCol0.TextBox.BackColor=dg.TableStyles[0].SelectionBackColor;
						//						TextCol0.TextBox.Font= new System.Drawing.Font("Microsoft Sans Serif",8.25F,FontStyle.Bold);
					}
				}

			}
			catch{}

			dg.ContextMenu = menu;
			dg.ReadOnly=SoloLectura;
			dg.BorderStyle = BorderStyle.Fixed3D;
			dg.TableStyles[0].ReadOnly=true;
			CurrencyManager cm = (CurrencyManager)Formulario.BindingContext[dg.DataSource,dg.DataMember];
			DataView dv = (DataView)cm.List;
			dv.AllowDelete=false;
			dv.AllowEdit=false;
		}

		public static void Formatear_DataGrid(Form Formulario,MiDataGrid dg, string Acceso,bool SoloLectura,ContextMenu menu)
		{
			Color ColorFondo = new Color();
			if(Acceso=="C") ColorFondo = ColorFondoFormulario;
			else ColorFondo=Color.White;

			dg.AlternatingBackColor = ColorFondo;
			dg.BackColor = ColorFondo;
			dg.BackgroundColor = ColorFondo;
			dg.CaptionBackColor = ColorFondoTituloDataGrid;
			dg.CaptionForeColor = Color.White; 
			dg.RowHeaderWidth = 17;
			dg.SelectionBackColor = ColorSelecionFilaDataGrid;
			dg.SelectionForeColor = Color.Black;

			try
			{
				dg.TableStyles[0].AlternatingBackColor = ColorFondo;
				dg.TableStyles[0].BackColor = ColorFondo;
				dg.TableStyles[0].HeaderBackColor = ColorFondoPanel;
				dg.TableStyles[0].RowHeaderWidth = 17;
				dg.TableStyles[0].SelectionBackColor = ColorSelecionFilaDataGrid;
				dg.TableStyles[0].SelectionForeColor = Color.Black;
				for(int i=0;i<dg.TableStyles[0].GridColumnStyles.Count;i++)
				{
					dg.TableStyles[0].GridColumnStyles[i].ReadOnly=true;
					DataGridTextBoxColumn TextCol0 = (DataGridTextBoxColumn)dg.TableStyles[0].GridColumnStyles[i];
					TextCol0.TextBox.ContextMenu = menu;
					if(!SoloLectura)
					{
						TextCol0.TextBox.Enabled=false;
						TextCol0.TextBox.BackColor=dg.TableStyles[0].SelectionBackColor;
						//						TextCol0.TextBox.Font= new System.Drawing.Font("Microsoft Sans Serif",8.25F,FontStyle.Bold);
					}
				}
			}
			catch{}

			dg.ContextMenu = menu;
			dg.ReadOnly=SoloLectura;
			dg.BorderStyle = BorderStyle.Fixed3D;
			dg.TableStyles[0].ReadOnly=SoloLectura;
			CurrencyManager cm = (CurrencyManager)Formulario.BindingContext[dg.DataSource,dg.DataMember];
			DataView dv = (DataView)cm.List;
			dv.AllowDelete=true;
			dv.AllowEdit=false;
		}


		public static void Formatear_DataGrid(Form Formulario,DataGrid dg, string Acceso, bool SoloLectura)
		{
			Color ColorFondo = new Color();
			if(Acceso=="C") ColorFondo = ColorFondoFormulario;
			else ColorFondo=Color.White;

			dg.AlternatingBackColor = ColorFondo;
			dg.BackColor = ColorFondo;
			dg.BackgroundColor = ColorFondo;
			dg.CaptionBackColor = ColorFondoTituloDataGrid;
			dg.CaptionForeColor = Color.White; 
			dg.RowHeaderWidth = 17;
			dg.SelectionBackColor = ColorSelecionFilaDataGrid;
			dg.SelectionForeColor = Color.Black;

			try
			{
				dg.TableStyles[0].AlternatingBackColor = ColorFondo;
				dg.TableStyles[0].BackColor = ColorFondo;
				dg.TableStyles[0].HeaderBackColor = ColorFondoPanel;
				dg.TableStyles[0].RowHeaderWidth = 17;
				dg.TableStyles[0].SelectionBackColor = ColorSelecionFilaDataGrid;
				dg.TableStyles[0].SelectionForeColor = Color.Black;
				for(int i=0;i<dg.TableStyles[0].GridColumnStyles.Count;i++)
				{
					dg.TableStyles[0].GridColumnStyles[i].ReadOnly=true;
					DataGridTextBoxColumn TextCol0 = (DataGridTextBoxColumn)dg.TableStyles[0].GridColumnStyles[i];
					
					if(!SoloLectura)
					{
						TextCol0.TextBox.Enabled=false;
						TextCol0.TextBox.BackColor=dg.TableStyles[0].SelectionBackColor;
					}
				}

			}
			catch{}
			
			dg.ReadOnly=SoloLectura;
			dg.BorderStyle = BorderStyle.Fixed3D;
			dg.TableStyles[0].ReadOnly=true;
			CurrencyManager cm = (CurrencyManager)Formulario.BindingContext[dg.DataSource,dg.DataMember];
			DataView dv = (DataView)cm.List;
			dv.AllowDelete=false;
			dv.AllowEdit=false;
		}


		public static void Formatear_DataGrid(DataGrid dg, string Acceso, ContextMenu menu)
		{
			Color ColorFondo = new Color();
			if(Acceso=="C") ColorFondo = ColorFondoFormulario;
			else ColorFondo=Color.White;

			dg.AlternatingBackColor = ColorFondo;
			dg.BackColor = ColorFondo;
			dg.BackgroundColor = ColorFondo;
			dg.CaptionBackColor = ColorFondoTituloDataGrid;
			dg.CaptionForeColor = Color.White; 
			dg.RowHeaderWidth = 17;
			dg.SelectionBackColor = ColorSelecionFilaDataGrid;
			dg.SelectionForeColor = Color.Black;

			try
			{
				dg.TableStyles[0].AlternatingBackColor = ColorFondo;
				dg.TableStyles[0].BackColor = ColorFondo;
				dg.TableStyles[0].HeaderBackColor = ColorFondoPanel;
				dg.TableStyles[0].RowHeaderWidth = 17;
				dg.TableStyles[0].SelectionBackColor = ColorSelecionFilaDataGrid;
				dg.TableStyles[0].SelectionForeColor = Color.Black;
				for(int i=0;i<dg.TableStyles[0].GridColumnStyles.Count;i++)
				{
					dg.TableStyles[0].GridColumnStyles[i].ReadOnly=true;
					DataGridTextBoxColumn TextCol0 = (DataGridTextBoxColumn)dg.TableStyles[0].GridColumnStyles[i];
					TextCol0.TextBox.ContextMenu = menu;
				}

			}
			catch{}

			dg.BorderStyle = BorderStyle.Fixed3D;
			dg.ContextMenu = menu;
			dg.ReadOnly=true;
			dg.TableStyles[0].ReadOnly=true;
		}

        //---- GSG (11/07/2016)
        public static void pintaLineasGrid(DataGridView dg, Color miColor, string nombreCol)
        {
            for (int i = 0; i < dg.Rows.Count - 1; i++)
            {
                if (int.Parse(dg.Rows[i].Cells[nombreCol].Value.ToString()) == 0)
                {
                    for (int j = 0; j < dg.ColumnCount; j++)
                    {
                        dg.Rows[i].Cells[j].Style.BackColor = Color.FromArgb(255, 180, 255);
                    }
                }
            }
        }
        #endregion

        #region Formatear_DgConColumnaBoton
        public static void Formatear_DgConColumnaBoton(DataGrid dg,string Acceso,ContextMenu menu,int col)
		{
			try
			{
				Color ColorFondo = new Color();
				if(Acceso=="C") ColorFondo = ColorFondoFormulario;
				else ColorFondo=Color.White;

				dg.AlternatingBackColor = ColorFondo;
				dg.BackColor = ColorFondo;
				dg.BackgroundColor = ColorFondo;
				dg.CaptionBackColor = ColorFondoTituloDataGrid;
				dg.CaptionForeColor = Color.White; 
				dg.RowHeaderWidth = 17;
				dg.SelectionBackColor = ColorSelecionFilaDataGrid;
				dg.SelectionForeColor = Color.Black;

				int columna = dg.TableStyles[0].GridColumnStyles.Count;

				DataGridTableStyle tableStyle = new DataGridTableStyle();
				tableStyle.MappingName = dg.TableStyles[0].MappingName;
				tableStyle.AlternatingBackColor= ColorFondo;
				tableStyle.BackColor= ColorFondo;
				tableStyle.HeaderBackColor= ColorFondoPanel;
				tableStyle.RowHeaderWidth= 17;
				tableStyle.SelectionBackColor= ColorSelecionFilaDataGrid;
				tableStyle.SelectionForeColor=Color.Black;
				tableStyle.ReadOnly = true;


				for(int i=0;i<dg.TableStyles[0].GridColumnStyles.Count;i++)
				{
					if(i==col)
					{
						GESTCRM.DataGridButtonColumn buttonColStyle = new GESTCRM.DataGridButtonColumn(i); //pass the column#
						buttonColStyle.HeaderText = "";
						buttonColStyle.MappingName =  dg.TableStyles[0].GridColumnStyles[i].MappingName;
                        buttonColStyle.Width = 40;
						buttonColStyle.TextBox.ContextMenu=null;
						tableStyle.GridColumnStyles.Add(buttonColStyle);

						//hook the mouse handlers
						dg.MouseDown += new MouseEventHandler(buttonColStyle.HandleMouseDown);
						dg.MouseUp += new MouseEventHandler(buttonColStyle.HandleMouseUp);
					}
					else
					{
						// add standard textbox columns for the other columns
						DataGridTextBoxColumn aColumnTextColumn = new DataGridTextBoxColumn();
						DataGridTextBoxColumn Columna =  (DataGridTextBoxColumn)dg.TableStyles[0].GridColumnStyles[i];

						aColumnTextColumn.HeaderText = Columna.HeaderText;
						aColumnTextColumn.MappingName = Columna.MappingName;
						aColumnTextColumn.Width  = Columna.Width;
						aColumnTextColumn.NullText = Columna.NullText;
						aColumnTextColumn.Alignment = Columna.Alignment;
						aColumnTextColumn.Format = Columna.Format;
						aColumnTextColumn.ReadOnly = true;
						aColumnTextColumn.TextBox.ContextMenu = menu;
						tableStyle.GridColumnStyles.Add(aColumnTextColumn);
					}
				}

				dg.ContextMenu = menu;
				dg.ReadOnly=true;
				dg.BorderStyle = BorderStyle.Fixed3D;

				dg.TableStyles.Clear();
				dg.TableStyles.Add(tableStyle);
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
		#endregion


		#region Formatear_DgConFilabEnviadoCEN
		public static void Formatear_DgConFilabEnviadoCEN(DataGrid dg,string Acceso,ContextMenu menu)
		{
			try
			{
				Color ColorFondo = new Color();
				if(Acceso=="C") ColorFondo = ColorFondoFormulario;
				else ColorFondo=Color.White;

				dg.AlternatingBackColor = ColorFondo;
				dg.BackColor = ColorFondo;
				dg.BackgroundColor = ColorFondo;
				dg.CaptionBackColor = ColorFondoTituloDataGrid;
				dg.CaptionForeColor = Color.White; 
				dg.RowHeaderWidth = 17;
				dg.SelectionBackColor = ColorSelecionFilaDataGrid;
				dg.SelectionForeColor = Color.Black;

				int columna = dg.TableStyles[0].GridColumnStyles.Count;

				DataGridTableStyle tableStyle = new DataGridTableStyle();
				tableStyle.MappingName = dg.TableStyles[0].MappingName;
				tableStyle.AlternatingBackColor= ColorFondo;
				tableStyle.BackColor= ColorFondo;
				tableStyle.HeaderBackColor= ColorFondoPanel;
				tableStyle.RowHeaderWidth= 17;
				tableStyle.SelectionBackColor= ColorSelecionFilaDataGrid;
				tableStyle.SelectionForeColor=Color.Black;
				tableStyle.ReadOnly = true;


				for(int i=0;i<dg.TableStyles[0].GridColumnStyles.Count;i++)
				{
					DataGridColoredTextBoxColumn_bEnviadoCEN aColumnTextColumn = new DataGridColoredTextBoxColumn_bEnviadoCEN();
					DataGridTextBoxColumn Columna =  (DataGridTextBoxColumn)dg.TableStyles[0].GridColumnStyles[i];
					
					aColumnTextColumn.HeaderText = Columna.HeaderText;
					aColumnTextColumn.MappingName = Columna.MappingName;
					aColumnTextColumn.Width  = Columna.Width;
					aColumnTextColumn.NullText = Columna.NullText;
					aColumnTextColumn.Alignment = Columna.Alignment;
					aColumnTextColumn.Format = Columna.Format;
					aColumnTextColumn.TextBox.ContextMenu = menu;
					aColumnTextColumn.ReadOnly = true;
					tableStyle.GridColumnStyles.Add(aColumnTextColumn);
                }

				dg.ContextMenu = menu;
				dg.ReadOnly=true;
				dg.BorderStyle = BorderStyle.Fixed3D;

				dg.TableStyles.Clear();
				dg.TableStyles.Add(tableStyle);
			}
			catch(Exception ex){Mensajes.ShowError(ex.Message);}
		}
        #endregion


              


        #region Seleccionar_UnaFilaDataGrid
        public static void Seleccionar_UnaFilaDataGrid(Form Formulario,DataGrid dg,int fila)
		{
			try
			{
				CurrencyManager cm = (CurrencyManager)Formulario.BindingContext[dg.DataSource,dg.DataMember];
				DataView dv = (DataView)cm.List;

				for(int i=0;i<dv.Count;i++)
				{
					if(dg.IsSelected(i))
					{
						dg.UnSelect(i);
					}
				}
				if(fila>-1) dg.Select(fila);
			}
			catch{}
		}

		public static void Seleccionar_UnaFilaDataGrid(DataGrid dg,int filaSel, int TotalFilasDg)
		{
			try
			{
				for(int i=0;i<TotalFilasDg;i++)
				{
					if(dg.IsSelected(i))
					{
						dg.UnSelect(i);
					}
				}
				if(filaSel>-1) dg.Select(filaSel);
			}
			catch{}
		}

		public static void Seleccionar_UnaFilaDataGrid(Form Formulario,MiDataGrid dg,int fila)
		{
			try
			{
				CurrencyManager cm = (CurrencyManager)Formulario.BindingContext[dg.DataSource,dg.DataMember];
				DataView dv = (DataView)cm.List;

				for(int i=0;i<dv.Count;i++)
				{
					if(dg.IsSelected(i))
					{
						dg.UnSelect(i);
					}
				}
				if(fila>-1) dg.Select(fila);
			}
			catch{}
		}
		#endregion

		#region Buscar_filaDataGrid
		public static int Buscar_filaDataGrid(Form Formulario,DataGrid dg,string columna,string valor)
		{
			try
			{
				int fila=-1;
				CurrencyManager cm = (CurrencyManager)Formulario.BindingContext[dg.DataSource,dg.DataMember];
				DataView dv = (DataView)cm.List;

				for(int i=0;i<dv.Count;i++)
				{
					if(dv[i][columna].ToString()==valor)
					{
						fila=i;
						break;
					}
				}
				return fila;
			}
			catch{return -1;}
		}

		public static int Buscar_filaDataGrid(Form Formulario,DataGrid dg,string columna1,string valor1,string columna2,string valor2)
		{
			try
			{
				CurrencyManager cm = (CurrencyManager)Formulario.BindingContext[dg.DataSource,dg.DataMember];
				DataView dv = (DataView)cm.List;

				int fila=-1;

				for(int i=0;i<dv.Count;i++)
				{
					if(dv[i][columna1].ToString()==valor1 && 
						dv[i][columna2].ToString()==valor2)
					{
						fila=i;
						break;
					}
				}
				return fila;
			}
			catch{return -1;}
		}

		public static int Buscar_filaDataGrid(Form Formulario,DataGrid dg,string columna1,string valor1,string columna2,string valor2,string columna3,string valor3)
		{
			try
			{
				CurrencyManager cm = (CurrencyManager)Formulario.BindingContext[dg.DataSource,dg.DataMember];
				DataView dv = (DataView)cm.List;

				int fila=-1;

				for(int i=0;i<dv.Count;i++)
				{
					if(dv[i][columna1].ToString()==valor1 && 
						dv[i][columna2].ToString()==valor2 &&
						dv[i][columna3].ToString()==valor3)
					{
						fila=i;
						break;
					}
				}
				return fila;
			}
			catch{return -1;}
		}
		#endregion

		#region Buscar_fila_dtTabla
		public static int Buscar_fila_dtTabla(DataTable dt,string columna,string valor)
		{
			try
			{
				int fila = -1;
				for (int i=0;i<dt.Rows.Count;i++)
				{
					if(dt.Rows[i][columna].ToString()==valor)
					{
						fila=i;
						break;
					}
				}
				return fila;
			}
			catch{return -1;}
		}

		public static int Buscar_fila_dtTabla(DataTable dt,string columna1,string valor1,string columna2,string valor2)
		{
			try
			{
				int fila = -1;
				for (int i=0;i<dt.Rows.Count;i++)
				{
					if(dt.Rows[i][columna1].ToString()==valor1 && dt.Rows[i][columna2].ToString()==valor2)
					{
						fila=i;
						break;
					}
				}
				return fila;
			}
			catch{return -1;}
		}

		public static int Buscar_fila_dtTabla(DataTable dt,string columna1,string valor1,string columna2,string valor2,string columna3,string valor3)
		{
			try
			{
				int fila = -1;
				for (int i=0;i<dt.Rows.Count;i++)
				{
					if(dt.Rows[i][columna1].ToString()==valor1 && dt.Rows[i][columna2].ToString()==valor2 && dt.Rows[i][columna3].ToString()==valor3)
					{
						fila=i;
						break;
					}
				}
				return fila;
			}
			catch{return -1;}
		}		
		#endregion

		#region Borrar_filaDataGrid
		public static void Borrar_filaDataGrid(Form Formulario,DataGrid dg,int fila)
		{
			CurrencyManager cm = (CurrencyManager)Formulario.BindingContext[dg.DataSource,dg.DataMember];
			DataView dv = (DataView)cm.List;
			if(fila > -1)
			{
				dv.AllowDelete=true;
				dv[fila].Delete();
				dv.AllowDelete=false;
			}
		}
		#endregion

		#region Row Count 
		public static void Row_Count (Form Formulario, DataGrid dg, int Registros)
		{
			CurrencyManager cm = (CurrencyManager)Formulario.BindingContext[dg.DataSource,dg.DataMember];
			DataView dv = (DataView)cm.List;

			dv.AllowDelete=true;
			for (int i=Registros-1; i < dv.Count; i++)
			{
				dv[i].Delete();
			}
			dv.AllowDelete=false;
		}
		public static void Row_Count (System.Windows.Forms.UserControl Formulario, DataGrid dg, int Registros)
		{
			CurrencyManager cm = (CurrencyManager)Formulario.BindingContext[dg.DataSource,dg.DataMember];
			DataView dv = (DataView)cm.List;

			dv.AllowDelete=true;
			while (Registros < dv.Count) 
			{
				dv[Registros].Delete();
			}
			dv.AllowDelete=false;
		}
		#endregion

		#region DataTable Inicializar_Tabla
		public static DataTable Inicializar_Tabla(DataTable dtOrigen)
		{
			DataTable dtDestino = new DataTable();
			for(int i=0;i < dtOrigen.Columns.Count;i++)
			{
				dtDestino.Columns.Add(dtOrigen.Columns[i].ColumnName,dtOrigen.Columns[i].DataType);
			}

			for(int i=0; i<dtOrigen.Rows.Count;i++)
			{
				DataRow fila = dtDestino.NewRow();
				for(int j=0;j< dtOrigen.Columns.Count;j++)
				{
					fila[j]= dtOrigen.Rows[i][j];
				}
				dtDestino.Rows.Add(fila);
			}
			return dtDestino;
		}
		#endregion

		#region Activar_Panel
		public static void Activar_Panel(Panel pn,bool Activar)
		{
			try
			{
				string tipo=null;
				foreach(Control c in pn.Controls)
				{
					tipo = c.GetType().ToString();
					switch(tipo)
					{
						case "System.Windows.Forms.Panel":
							Panel pnl = (Panel) c;
							Activar_Panel(pnl,Activar);
							break;
						default: 
							Activar_Control(c,Activar);
							break;
					}
				}
			}
			catch{}
		}
		#endregion

		#region Activar_UserControl
		public static void Activar_UserControl(GESTCRM.CRMControles.ucUltimasVisitas uc,bool Activar)
		{
			try
			{
				string tipo=null;
				foreach(Control c in uc.Controls)
				{
					tipo = c.GetType().ToString();
					switch(tipo)
					{
						case "System.Windows.Forms.Panel":
							Panel pnl = (Panel) c;
							Activar_Panel(pnl,Activar);
							break;
						default: 
							Activar_Control(c,Activar);
							break;
					}
				}
			}
			catch{}
		}
		public static void Activar_UserControl(GESTCRM.CRMControles.ucRankingMatCli uc,bool Activar)
		{
			try
			{
				string tipo=null;
				foreach(Control c in uc.Controls)
				{
					tipo = c.GetType().ToString();
					switch(tipo)
					{
						case "System.Windows.Forms.Panel":
							Panel pnl = (Panel) c;
							Activar_Panel(pnl,Activar);
							break;
						default: 
							Activar_Control(c,Activar);
							break;
					}
				}
			}
			catch{}
		}
		public static void Activar_UserControl(GESTCRM.CRMControles.ucUltimoPedido uc,bool Activar)
		{
			try
			{
				string tipo=null;
				foreach(Control c in uc.Controls)
				{
					tipo = c.GetType().ToString();
					switch(tipo)
					{
						case "System.Windows.Forms.Panel":
							Panel pnl = (Panel) c;
							Activar_Panel(pnl,Activar);
							break;
						default: 
							Activar_Control(c,Activar);
							break;
					}
				}
			}
			catch{}
		}
		#endregion

		#region Activar_Control
		public static void Activar_Control(Control c, bool Activar)
		{
			try
			{
				string	tipo = c.GetType().ToString();
				switch(tipo)
				{
					case "System.Windows.Forms.Label":
						break;
					case "GESTCRM.Controles.LabelGradient":
						break;
					case "System.Windows.Forms.DataGrid":
						DataGrid dg = (DataGrid) c;
						if(Activar)
						{
							dg.TableStyles[0].BackColor=Color.White;
							dg.TableStyles[0].AlternatingBackColor=Color.White;
							dg.BackgroundColor=Color.White;
						}
						else
						{
							dg.TableStyles[0].BackColor=ColorFondoFormulario;
							dg.TableStyles[0].AlternatingBackColor=ColorFondoFormulario;
							dg.BackgroundColor=ColorFondoFormulario;
						}
						break;
					case "System.Windows.Forms.Button":
						Button bt = (Button) c;
						c.Enabled=Activar;
						break;
					case "System.Windows.Forms.TextBox":
						TextBox tb = (TextBox) c;
						tb.ReadOnly = !Activar;
						if(Activar) tb.BackColor = Color.White;
						else tb.BackColor = ColorFondoPanel;
						break;
					case "System.Windows.Forms.NumericUpDown":
						NumericUpDown nup = (NumericUpDown) c;
						nup.ReadOnly = !Activar;
						if(Activar) nup.BackColor = Color.White;
						else nup.BackColor = ColorFondoPanel;
						break;
					case "System.Windows.Forms.ComboBox":
						ComboBox cb = (ComboBox) c;
						if(Activar) cb.BackColor = Color.White;
						else cb.BackColor = ColorFondoPanel;
						c.Enabled=Activar;
						break;
					case "GESTCRM.CRMControles.ucUltimasVisitas":
						GESTCRM.CRMControles.ucUltimasVisitas uc1 = (GESTCRM.CRMControles.ucUltimasVisitas) c;
						Activar_UserControl(uc1,Activar);
						break;
					case "GESTCRM.CRMControles.ucRankingMatCli":
						GESTCRM.CRMControles.ucRankingMatCli uc2 = (GESTCRM.CRMControles.ucRankingMatCli) c;
						Activar_UserControl(uc2,Activar);
						break;
					case "GESTCRM.CRMControles.ucUltimoPedido":
						GESTCRM.CRMControles.ucUltimoPedido uc3 = (GESTCRM.CRMControles.ucUltimoPedido) c;
						Activar_UserControl(uc3,Activar);
						break;
					default: 
						c.Enabled=Activar;
						break;
				}
			}
			catch{}
		}
		#endregion

		#region Transformar_TipoAcceso
		public static int Transformar_TipoAcceso(string TipoAcceso)
		{
			switch(TipoAcceso)
			{
				case "A":return(0);
				case "I":return(0);
				case "M":return(1);
				case "B":return(2);
				default:return(-1);
			}
		}
		#endregion

		#region DevuelveSI_NO
		public static string DevuelveSI_NO(string bParametro)
		{
			// Parametro de Entrada: bParametro	(cadena string que se pasa 'True' o 'False')
			// Devuelve "SI" o "NO" en funcion del parámetro de entrada.
			// Práctico para valores de campo booleanos que se tienen que mostrar por pantalla.
			if(bParametro.ToUpper() == "TRUE" || bParametro.ToUpper() == "VERDADERO")
			{
				return "SI";
			}
			else
			{
				return "NO";
			}
		}
		#endregion

		#region ActivaFormularioAbierto
		public static void ActivaFormularioAbierto(string Formulario, Form Padre)
		{
			for (int x =0; x < Padre.MdiChildren.Length;x++)
			{
				Form tempChild = (Form)Padre.MdiChildren[x];
				string NombreFormulario = Padre.MdiChildren.GetValue(x).ToString();
				NombreFormulario=NombreFormulario.Substring(NombreFormulario.LastIndexOf(".")+1);
				NombreFormulario=NombreFormulario.Substring(0,NombreFormulario.IndexOf(","));
				if (Formulario == NombreFormulario)
				{
					//tempChild.WindowState = FormWindowState.Maximized;
					tempChild.Focus();
					break;
				}					
			}
		}
		#endregion

		#region CierraFormularioActivo
		public static void CierraFormularioActivo(string Formulario, Form Padre)
		{
			for (int x =0; x < Padre.MdiChildren.Length;x++)
			{
				Form tempChild = (Form)Padre.MdiChildren[x];
				string NombreFormulario = Padre.MdiChildren.GetValue(x).ToString();
				NombreFormulario=NombreFormulario.Substring(NombreFormulario.LastIndexOf(".")+1);
				NombreFormulario=NombreFormulario.Substring(0,NombreFormulario.IndexOf(","));
				if (Formulario == NombreFormulario)
				{
					tempChild.Close();
					tempChild.Dispose();
					break;
				}					
			}
		}
		#endregion

		#region Bloquear controles de un panel
		/// <summary>
		/// Bloquea los controles de un panel.
		/// </summary>
		/// <param name="oPanel">Panel a bloquear</param>
		public static void BloquearPanel(Panel oPanel)
		{
			Color   ColorBloqueo = Color.FromArgb(238, 243, 246);

			foreach ( Control oControl in oPanel.Controls)
			{
				if (oControl is TextBox) 
				{
					((TextBox)oControl).ReadOnly = true;
					((TextBox)oControl).BackColor = ColorBloqueo;
				}
				else if ( oControl is ComboBox)
				{
					((ComboBox)oControl).Enabled = false;
				}
				else if ( oControl is Button)
				{
					((Button)oControl).Enabled = false;
				}
				else if (oControl is Panel)
				{
					BloquearPanel((Panel)oControl);
				}
			}
		}
		#endregion

		#region Chequear NIF
		#region Calc_NIF
		/// <summary>
		/// Calcula el utimo valor (Letra) del NIF
		/// </summary>
		/// <param name="valor">String con el NIF hasta eh penultimo carácter</param>
		/// <returns></returns>
		private static string Calc_NIF(string valor)
		{
			int resto;
			int numero;
			string letra_NIF="";
   
			if (valor.Length>0 && valor.Length<=8)
			{
		   
				try
				{
					numero=Int32.Parse(valor); 
					
					resto= numero % 23;

					switch (resto)
					{
						case 0:letra_NIF = "T";break;
						case 1:letra_NIF = "R";break;
						case 2:letra_NIF = "W";break;
						case 3:letra_NIF = "A";break;
						case 4:letra_NIF = "G";break;
						case 5:letra_NIF = "M";break;
						case 6:letra_NIF = "Y";break;
						case 7:letra_NIF = "F";break;
						case 8:letra_NIF = "P";break;
						case 9:letra_NIF = "D";break;
						case 10:letra_NIF = "X";break;
						case 11:letra_NIF = "B";break;
						case 12:letra_NIF = "N";break;
						case 13:letra_NIF = "J";break;
						case 14:letra_NIF = "Z";break;
						case 15:letra_NIF = "S";break;
						case 16:letra_NIF = "Q";break;
						case 17:letra_NIF = "V";break;
						case 18:letra_NIF = "H";break;
						case 19:letra_NIF = "L";break;
						case 20:letra_NIF = "C";break;
						case 21:letra_NIF = "K";break; 
						case 22:letra_NIF = "E";break;
					}  
				}
				catch
				{
					return "";
				}
				return  (valor + letra_NIF);
			}
			else
			{
				return "";
			}
	   }
		#endregion
		#region NifCorrecto
		/// <summary>
		/// Valida si el NIF suministrado es correcto
		/// </summary>
		/// <param name="sNIF">NIF</param>
		/// <returns></returns>
		public static bool  NifCorrecto (string sNIF)
		{
			string NIFsinX;

			NIFsinX = (sNIF.IndexOf("X")>0 && sNIF.IndexOf("X")<2)?sNIF.Substring(sNIF.IndexOf("X")+1):sNIF; 
			return (NIFsinX==Calc_NIF(NIFsinX.Trim().Substring(0,NIFsinX.Trim().Length -1)  ));
		}
		#endregion
		#endregion

		#region ValidaCampo()
		/// <summary>
		/// Busca el primer Control con nombre igual al especificado y compara su contenido con el patron
		/// regular especificado
		/// Por el momento solo se puede usar esta funcion con controles textbox
		/// </summary>
		/// <param name="FieldName">Nombre del Campo</param>
		/// <param name="Pattern">Patron de comparacion</param>
		/// <returns>True si el campo cumple con el patron o esta vacío, False en caso conrario</returns>
		public static bool ValidaCampo(string FieldName, string LogicalName, string Pattern, string PatternGuide,Control croot)
		{
			bool bResult = true;
			Control auxControl=null;
			System.Text.RegularExpressions.Regex Reg = new System.Text.RegularExpressions.Regex(Pattern   );
			auxControl = GetControlByName(FieldName,croot);
			if (auxControl != null && auxControl is TextBox && auxControl.Text.ToString().Trim().Length >0 )
			{
				bResult = Reg.IsMatch(auxControl.Text.ToString());
				if (!bResult)
				{
					Mensajes.ShowError(@"Formato del Campo " + LogicalName.ToString()+ "incorrecto.\n\nConsidere las siguientes alternativas:\n\n"+PatternGuide.ToString()); 
					auxControl.Focus(); 
				}
			}
			return bResult;
		}
		#endregion
		#region GetControlByName
		/// <summary>
		/// Retorna el Objeto Control con el nombre especificado a partir de un Control Padre
		/// </summary>
		/// <param name="controlName">Nombre del Control</param>
		/// <param name="ctrlRoot">Control Padre</param>
		/// <remarks>Este procedimiento es Recursivo y puede emplearse en todos los formularios</remarks> 
		/// <returns>Objeto de tipo System.Windows.Forms.Control</returns>
		public static Control GetControlByName(string controlName, Control ctrlRoot)
		{
			
			Control auxControl;

			if (ctrlRoot.Name.ToString().ToUpper().Trim()== controlName.ToUpper().Trim()      ) return ctrlRoot;

			if (ctrlRoot.HasChildren)
			{
				foreach(Control ctrlChild in ctrlRoot.Controls  )
				{
					auxControl=GetControlByName(controlName,ctrlChild);
					if (auxControl!=null) 
					{
						return auxControl;
					}
				}
				return null;
			}
			else
			{
				return null;
			}
		}
		#endregion

		#region Activa un Formulario ya Abierto
		/// <summary>
		/// Activa un formulario ya abierto
		/// </summary>
		/// <param name="frm">objeto Form a partiir del cual se buscará </param>
		/// <param name="Formulario">Nombre el Formulario a Activar</param>
		public static void ActivaFormularioAbierto(System.Windows.Forms.Form  frm, string Formulario)
		{
			for (int x =0; x < frm.MdiChildren.Length;x++)
			{
				Form tempChild = (Form)frm.MdiChildren[x];
				string NombreFormulario = frm.MdiChildren.GetValue(x).ToString();
				NombreFormulario=NombreFormulario.Substring(NombreFormulario.LastIndexOf(".")+1);
				NombreFormulario=NombreFormulario.Substring(0,NombreFormulario.IndexOf(","));
				if (Formulario == NombreFormulario)
				{
					//tempChild.WindowState = FormWindowState.Maximized;
					tempChild.Focus();
					break;
				}					
			}
		}
		#endregion

		#region Mirar Si está abierto algún formulario MDI
		/// <summary>
		/// Mirar Si está abierto algún formulario MDI
		/// </summary>
		/// <param name="frm">objeto Form a partiir del cual se buscará </param>
		/// <param name="Formulario">Nombre el Formulario a Buscar</param>
		/// <returns></returns>
		public  static bool MirarSiAbierto(System.Windows.Forms.Form frm, string Formulario)
		{
			bool EstaAbierto = false;
			int NumeroFormsAbiertos = frm.MdiChildren.Length;
			string NombreFormulario = "";
			if (NumeroFormsAbiertos == 0)
			{
				EstaAbierto = false;
			}
			else
			{
				for (int i=0; i<NumeroFormsAbiertos;i++)
				{					
					NombreFormulario=frm.MdiChildren.GetValue(i).ToString();
					NombreFormulario=NombreFormulario.Substring(NombreFormulario.LastIndexOf(".")+1);
					NombreFormulario=NombreFormulario.Substring(0,NombreFormulario.IndexOf(","));
					if (Formulario == NombreFormulario)
					{
						EstaAbierto = true;
						break;
					}					
				}
			}
			return(EstaAbierto);
		}

		#endregion

        //---- GSG (09/05/2011)
        public static bool ValidaCIF(string sCIF)
        {
            bool ret = false;

            if (sCIF.Length == 9)
            {

            }

            return ret;
        }
        //---- FI GSG

        
        //---- GSG (22/09/2016)
        public static List<string> eliminarDuplicadosListString(List<string> plLista)
        {
            Dictionary<string, int> dicc = new Dictionary<string, int>();

            List<string> lRet = new List<string>();

            foreach (string val in plLista)
            {
                if (!dicc.ContainsKey(val))
                {
                    dicc.Add(val, 0);
                    lRet.Add(val);
                }
            }
            return lRet;
        }



        #region ficheros

        //---- GSS (24/10/2019)
        //private void CrearPDF()
        //{
        //    Document document = new Document();

        //    Page page = new Page(PageSize.Letter, PageOrientation.Portrait, 54.0f);
        //    document.Pages.Add(page);

        //    string labelText = "Hello World...\nFrom DynamicPDF Generator for .NET\nDynamicPDF.com";
        //    Label label = new Label(labelText, 0, 0, 504, 100, Font.Helvetica, 18, TextAlign.Center);
        //    page.Elements.Add(label);

        //    document.Draw("output.pdf");

        //}

        #endregion



    }

    #region public class MiDataGrid: DataGrid
    public class MiDataGrid: DataGrid
	{
		public MiDataGrid()
		{
			//			this.VertScrollBar.Visible=true;
			this.VertScrollBar.Width=12;
			this.HorizScrollBar.Visible=false;
			this.HorizScrollBar.VisibleChanged += new EventHandler(NoShowScrollBars);
			//			this.VertScrollBar.VisibleChanged += new EventHandler(ShowScrollBars);
		}

        //private int oldSelectedRow = -1;
		//		private int CAPTIONHEIGTH = 0;
		//		private int BORDERWIDTH = 2;

		//		private void ShowScrollBars(object sender, EventArgs e)
		//		{
		//			if (!this.VertScrollBar.Visible)
		//			{
		//				int width = this.VertScrollBar.Width;
		//				this.VertScrollBar.Location = new Point(this.ClientRectangle.Width - width - BORDERWIDTH,CAPTIONHEIGTH);
		//				this.VertScrollBar.Size = new Size(width,this.ClientRectangle.Height - CAPTIONHEIGTH - BORDERWIDTH);
		//				this.VertScrollBar.Show();
		//			}
		//		}

		private void NoShowScrollBars(object sender, EventArgs e)
		{
			if(this.HorizScrollBar.Visible)
			{
				this.HorizScrollBar.Visible=false;
			}
		}
	}
	#endregion


	#region derived columnstyle that shows Button only

	public class DataGridButtonColumn : DataGridTextBoxColumn
	{
		public event DataGridCellButtonClickEventHandler CellButtonClicked;

		private Bitmap _buttonFace;
		private Bitmap _buttonFacePressed;
		private int _columnNum;
		private int _pressedRow;

		public DataGridButtonColumn(int colNum)
		{
			_columnNum = colNum;
			_pressedRow = -1;

			try
			{
                _buttonFace = global::GESTCRM.Properties.Resources.btn40x16; //.fullbuttonface; //new Bitmap("Misc\\fullbuttonface.bmp");
                _buttonFacePressed = global::GESTCRM.Properties.Resources.btn40x16; //.fullbuttonfacepressed; // new Bitmap("Misc\\fullbuttonfacepressed.bmp");
			}
			catch{}
		}

		protected override void Edit(System.Windows.Forms.CurrencyManager source, int rowNum, System.Drawing.Rectangle bounds, bool readOnly, string instantText, bool cellIsVisible) 
		{ 
			// dont call the baseclass so no editing done...
			//	base.Edit(source, rowNum, bounds, readOnly, instantText, cellIsVisible); 
		} 

		private void DrawButton(Graphics g, Bitmap bm, Rectangle bounds, int row)
		{
			DataGrid dg = this.DataGridTableStyle.DataGrid;
			string s = dg[row, this._columnNum].ToString();

            //bounds.Width = bm.Width;
            //bounds.Height = bm.Height;

			SizeF sz = g.MeasureString(s, dg.Font, bounds.Width - 4, StringFormat.GenericTypographic);

			int x = bounds.Left + Math.Max(0, (bounds.Width - (int)sz.Width)/2);
			g.DrawImage(bm, bounds, 0, 0, bm.Width, bm.Height,GraphicsUnit.Pixel);
			
			if(sz.Height < bounds.Height)
			{
				int y = bounds.Top + (bounds.Height - (int) sz.Height) / 2;
				if(_buttonFacePressed == bm)
				{
					x++;
				}

				g.DrawString(s, dg.Font, new SolidBrush(dg.ForeColor), x, y);
			}

		}

		public void HandleMouseUp(object sender, MouseEventArgs e)
		{
			DataGrid dg = this.DataGridTableStyle.DataGrid;
			DataGrid.HitTestInfo hti = dg.HitTest(new Point(e.X, e.Y));
			bool isClickInCell = (hti.Column == this._columnNum
				&& hti.Row > -1);

			_pressedRow = -1;

            Rectangle rect = new Rectangle(0, 0, 0, 0);

            if (isClickInCell)
            {
                rect = dg.GetCellBounds(hti.Row, hti.Column);
                //isClickInCell = (e.X > rect.Right - this._buttonFace.Width);
            }

			if(isClickInCell)
			{
				Graphics g = Graphics.FromHwnd(dg.Handle);
				//	g.DrawImage(this._buttonFace, rect.Right - this._buttonFace.Width, rect.Y);
				DrawButton(g, this._buttonFace, rect, hti.Row);
				g.Dispose();
				if(CellButtonClicked != null)
					CellButtonClicked(this, new DataGridCellButtonClickEventArgs(hti.Row, hti.Column));
			}
		}

		public void HandleMouseDown(object sender, MouseEventArgs e)
		{
			DataGrid dg = this.DataGridTableStyle.DataGrid;
			DataGrid.HitTestInfo hti = dg.HitTest(new Point(e.X, e.Y));
			bool isClickInCell = (hti.Column == this._columnNum
				&& hti.Row > -1);

            Rectangle rect = new Rectangle(0, 0, 0, 0);
            if (isClickInCell)
            {
                rect = dg.GetCellBounds(hti.Row, hti.Column);
                //isClickInCell = (e.X > rect.Right - this._buttonFace.Width);
            }

			if(isClickInCell)
			{
				//Console.WriteLine("HandleMouseDown " + hti.Row.ToString());
				Graphics g = Graphics.FromHwnd(dg.Handle);
				//g.DrawImage(this._buttonFacePressed, rect.Right - this._buttonFacePressed.Width, rect.Y);
				DrawButton(g, _buttonFacePressed, rect, hti.Row);
				g.Dispose();
				_pressedRow = hti.Row;
			}
		}

		protected override void Paint(System.Drawing.Graphics g, System.Drawing.Rectangle bounds, System.Windows.Forms.CurrencyManager source, int rowNum, System.Drawing.Brush backBrush, System.Drawing.Brush foreBrush, bool alignToRight)
		{
			//base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight);
	
			DataGrid parent = this.DataGridTableStyle.DataGrid;
			bool current = parent.IsSelected(rowNum) ||
				( parent.CurrentRowIndex == rowNum && 
				parent.CurrentCell.ColumnNumber == this._columnNum);

			
		
			//draw the button
			Bitmap bm = _pressedRow == rowNum ? this._buttonFacePressed : this._buttonFace;
			this.DrawButton(g, bm, bounds, rowNum);
			
			//font.Dispose();
		
		}
	
	
	}
	#endregion

	#region GridCellButton click event
	public delegate void DataGridCellButtonClickEventHandler(object sender, DataGridCellButtonClickEventArgs e);

	public class DataGridCellButtonClickEventArgs : EventArgs
	{
		private int _row;
		private int _col;

		public DataGridCellButtonClickEventArgs(int row, int col)
		{
			_row = row;
			_col = col;
		}

		public int RowIndex	{get{return _row;}}
		public int ColIndex	{get{return _col;}}
	}
	#endregion


	#region DataGridColoredTextBoxColumn_bEnviadoCEN
	public class DataGridColoredTextBoxColumn_bEnviadoCEN : DataGridTextBoxColumn
	{

		protected override void Paint(System.Drawing.Graphics g, System.Drawing.Rectangle bounds, System.Windows.Forms.CurrencyManager source, int rowNum, System.Drawing.Brush backBrush, System.Drawing.Brush foreBrush, bool alignToRight)
		{
			// Se condiciona el fondo del Color de una celda de un DataGrid
			// en función de si la fila está Enviada a Central o no
			try
			{

				CurrencyManager cm = (CurrencyManager)source;
				DataView  dv = (DataView) cm.List;
				DataTable dt = dv.Table;

				//if(dt.Rows[rowNum]["bEnviadoCEN"].ToString()=="1")
				if(dv[rowNum]["bEnviadoCEN"].ToString()=="1")
				{
					if(this.DataGridTableStyle.DataGrid.IsSelected(rowNum))
					{
						backBrush = new LinearGradientBrush(bounds, 
							Color.FromArgb(184,216,192),
							Color.FromArgb(237,245,239), 
							LinearGradientMode.ForwardDiagonal);
						foreBrush = new SolidBrush(Color.Black);
					}
					else
					{
						backBrush = new LinearGradientBrush(bounds, 
							Color.FromArgb(224,165,220),
							Color.FromArgb(252,245,252), 
							LinearGradientMode.ForwardDiagonal);
						foreBrush = new SolidBrush(Color.Black);
					}
				}
			}
			catch{}
			finally
			{
				// make sure the base class gets called to do the drawing with
				// the possibly changed brushes
				base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight);

			}
		}
    }
    #endregion


}
