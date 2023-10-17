using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace GESTCRM.Clases
{
	/// <summary>
	/// Descripción breve de Configuracion.
	/// </summary>
	public class Configuracion
	{
        public static int iIdDelegado;// 1 = int.Parse(ValorConf(1));
		public static string sIdDelegado_SAP;//2
		public static string sUsuario;//3
		public static string sClave;//4
		public static string sNombreDelegado;//7
		public static int iUIClienteCLI;//100
		public static int iUIPedidoCLI;//101
		public static int iUIVisitaCLI;//102
        public static int iUIAtencionCLI;//103
		public static int iUIGastosCLI;//104
		public static int iGClientesSAP;//31
		public static int iGClientesCOM;//32
		public static int iGPedidos;//33
		public static int iGGastos;//34
		public static int iGVisitas;//35
		public static int iGAtenciones;//38
		public static int iGCentros;//41
		public static int iCargoAprob1;//39
		public static int iCargoAprob2;//40
		public static DateTime dFUSPDA;//5
		public static DateTime dFUSCEN;//6
		public static float fImpMaxAtencion;//36
		public static int iNumRegCRM;//37
        //public static string sqlCadenaCon;//del app.config //---- GSG (10/09/2014)
		public static string sOrgVentasSAP;//8
		public static string sGrupoVendedorSAP;//12
		public static string sCanalSAP;//9
		public static string sSectorSAP;//10
        //---- GSG (31/05/2011)
		//public static string sPedTransfer;//42
        public static string[] asPedTransfer;       //42
        //---- FI GSG
		public static string sCentroSAP;//15
		public static string sAlmacenSAP;//16
		public static string sCentroDEL;//13
		public static string sAlmacenDEL;//14
		public static int iPeriodoPDA;// 105
		public static string sIdRed;//58
		public static int iTodasAtenciones;//59
		public static int iTodosClientes;//60
		public static int iGPresupuestos;//61
		public static int iTodosPedidos;//62
		public static int iTodosCentros;//63
		public static int iCreaMedicos;//64
		public static int iCreaCentros;//65
		public static int iTodasAcciones; //66
		public static int bMuestraResultadosSincro; //67
		public static int bTodosReports; //68
		public static bool bPromProductosOtrasRedes; //69
		public static bool bAsignarEspecPropias; //70 
		//LSR 15032005
		public static int iIdProviciaDefectoDelegado; //Indicara la provicia a la que pertenece el delegado.
		public static float fRentabilidadMinima;
		//Fin LSR 15032005 
		//RHE 12062009
		public static bool bObligarObsPedidoEnVerano=false;//108
		//fi RHE 12062009
        //---- GSG (10/07/2013)
        public static string iIdCampanya; //109
        //---- GSG (20/09/2013)
        public static string iMaxNumAccMark; //110
        //---- GSG (22/10/2013)
        public static string fDescLegAccMarkCamp; //111
        //---- GSG (14/01/2014)
        public static int iMesesInformeS; //111
        public static int iMesesPedidoTipo; //113
        //---- GSG (14/03/2014)
        public static int iGPedidosCrear; //114
        public static int iGPedidosCopiar; //115
        public static int iGPedidosPropuesta; //116
        public static int iGInformeVentas; //117
        public static int iGImportExcel; //118
        public static int iGImportUnycop; //119
        //---- GSG (02/06/2014)
        public static int iIndicadoresGlobales; //120
        //---- GSG (19/10/2015)
        public static string sIdCampanyaTarjetasCliente; //121
        //---- GSG CECL 19/05/2016
        public static int iGAccMarkPed; //122
        public static int iGAlarmVisit; //123
        public static int iGStock; //124
        public static int iGSincro; //125
        public static int iGCopiaSeg; //126
        //---- FI GSG CECL
        //---- GSG (07/10/2016)
        public static int fMinDirFinan; //127
        //---- GSG (11/07/2017)
        public static float fDescCofares; //128
        public static float fImpCofares; //129
        //---- GSG (26/02/2018)
        public static float fImpMinDIR; //130
        public static int iDiasRobo;    //131
        // el 132 es el usuario que va por otro lado
        //---- GSG (29/09/2020)
        public static int iPuntosDividePor;    //133
        public static int iPuntosMultiplicaPor;    //134
		//---- GSG (02/01/2023)
		public static int iDiasCompromiso;    //136
		public static int iDiasTransfer;    //137
		public static int iDiasDirecto;    //138
		public static string[] asTiposNoDescMedio;   //139

		public static string ValorConf(int idConf)
		{
			string Retorno = "";

            //---- GSG (10/09/2014)
            //SqlConnection sqlConn = new SqlConnection(ConfigurationManager.AppSettings["sConn"].ToString());
            SqlConnection sqlConn = new SqlConnection();
            sqlConn = Utiles._connection;

            //---- GSG (10/09/2014)
            //this.sqlConn.Open();
            if (sqlConn.State == ConnectionState.Closed)
                sqlConn.Open();


			SqlCommand sqlCmd = sqlConn.CreateCommand();


            //---- GSG CECL 
            //sqlCmd.CommandText = "ListaConfParametro";
            if (System.Configuration.ConfigurationManager.AppSettings["TipoDelegadoPedidosCentral"].ToString() == Comun.K_CECL)
                sqlCmd.CommandText = "ListaConfParametroCECL";
            else
                sqlCmd.CommandText = "ListaConfParametro";
            //---- FI GSG CECL 

			sqlCmd.CommandType=CommandType.StoredProcedure;
			sqlCmd.Parameters.Add("@idConfig",SqlDbType.Int);
			sqlCmd.Parameters["@idConfig"].Value=idConf;
			SqlDataReader drConf = sqlCmd.ExecuteReader();
			
			if (drConf.Read())
			{
				Retorno = drConf["sValor"].ToString();					
			}

			drConf.Close();
			sqlConn.Close();
            //sqlConn.Dispose(); //---- GSG (10/09/2014)
			return (Retorno);			
		}

		public static void GrabaValor(int idConf, string Valor)
		{
            //---- GSG (10/09/2014)
            //SqlConnection sqlConn = new SqlConnection(ConfigurationManager.AppSettings["sConn"].ToString());
            SqlConnection sqlConn = new SqlConnection();
            sqlConn = Utiles._connection;

            //---- GSG (10/09/2014)
            //this.sqlConn.Open();
            if (sqlConn.State == ConnectionState.Closed)
                sqlConn.Open();


			SqlTransaction sqlTran = sqlConn.BeginTransaction();
			SqlCommand sqlCmd = sqlConn.CreateCommand();
			sqlCmd.Transaction=sqlTran;
			sqlCmd.CommandText="SetConfiguracion";
			sqlCmd.CommandType=CommandType.StoredProcedure;
			sqlCmd.Parameters.Add("@iIdConfig",SqlDbType.Int);
			sqlCmd.Parameters.Add("@sValor",SqlDbType.VarChar,30);

			try
			{	
				sqlCmd.Parameters["@iIdConfig"].Value=idConf;
				sqlCmd.Parameters["@sValor"].Value=Valor;
				sqlCmd.ExecuteNonQuery();

				//Commit de la transacción.
				sqlTran.Commit();
				sqlTran.Dispose();
			}
			catch(Exception excConf)
			{
				sqlTran.Rollback();
				Mensajes.ShowErrorField(excConf.Message);
			}

			sqlConn.Close();
            //sqlConn.Dispose(); //---- GSG (10/09/2014)

		}
		
		public static void Carga()
		{
            //---- GSG (10/09/2014)
            //SqlConnection sqlConn = new SqlConnection(ConfigurationManager.AppSettings["sConn"].ToString());
            SqlConnection sqlConn = new SqlConnection();
            sqlConn = Utiles._connection;

            //---- GSG (10/09/2014)
            //this.sqlConn.Open();
            if (sqlConn.State == ConnectionState.Closed)
                sqlConn.Open();

            SqlCommand sqlCmd = sqlConn.CreateCommand();
			sqlCmd.CommandText="ListaConfiguracion";
			sqlCmd.CommandType=CommandType.StoredProcedure;


            //---- GSG CECL 19/05/2016
            sqlCmd.Parameters.Add("@sIdDelegadoSAP", SqlDbType.VarChar, 3);
            sqlCmd.Parameters["@sIdDelegadoSAP"].Value = System.Configuration.ConfigurationManager.AppSettings["TipoDelegadoPedidosCentral"].ToString();
            //---- FI GSG CECL


			SqlDataReader drConf = sqlCmd.ExecuteReader();


            while (drConf.Read())
			{                
                switch (int.Parse(drConf["iIdConfig"].ToString()))
				{
                    
					case 1:
						iIdDelegado=int.Parse(drConf["sValor"].ToString());
                        break;
					case 2:
						sIdDelegado_SAP=drConf["sValor"].ToString();
                        break;
					case 3:
						sUsuario=drConf["sValor"].ToString();
                        break;
					case 4:
						sClave=drConf["sValor"].ToString();
                        break;
					case 5:
						dFUSPDA=DateTime.Parse(drConf["sValor"].ToString());
                        break;
					case 6:
						dFUSCEN=DateTime.Parse(drConf["sValor"].ToString());
                        break;
					case 7:
						sNombreDelegado=drConf["sValor"].ToString();
                        break;
					case 8:
						sOrgVentasSAP=drConf["sValor"].ToString();
                        break;
					case 9:
						sCanalSAP=drConf["sValor"].ToString();
                        break;
					case 10:
						sSectorSAP=drConf["sValor"].ToString();
						break;
					case 12:
						sGrupoVendedorSAP=drConf["sValor"].ToString();
						break;
					case 13:
						sCentroDEL=drConf["sValor"].ToString();
						break;
					case 14:
						sAlmacenDEL=drConf["sValor"].ToString();
						break;
					case 15:
						sCentroSAP=drConf["sValor"].ToString();
						break;
					case 16:
						sAlmacenSAP=drConf["sValor"].ToString();
						break;
					case 31:
						iGClientesSAP=int.Parse(drConf["sValor"].ToString());
						break;
					case 32:
						iGClientesCOM=int.Parse(drConf["sValor"].ToString());
						break;
					case 33:
						iGPedidos=int.Parse(drConf["sValor"].ToString());
						break;
					case 34:
						iGGastos=int.Parse(drConf["sValor"].ToString());
						break;
					case 35:
						iGVisitas=int.Parse(drConf["sValor"].ToString());
						break;
					case 36:
						fImpMaxAtencion=float.Parse(drConf["sValor"].ToString());
						break;					
					case 37:
						iNumRegCRM=int.Parse(drConf["sValor"].ToString());
						break;			
					case 38:
						iGAtenciones=int.Parse(drConf["sValor"].ToString());
						break;
					case 39:
						iCargoAprob1=int.Parse(drConf["sValor"].ToString());
						break;
					case 40:
						iCargoAprob2=int.Parse(drConf["sValor"].ToString());
						break;
					case 41:
						iGCentros=int.Parse(drConf["sValor"].ToString());
						break;
					case 42:
                        //---- GSG (31/05/2011)
						//sPedTransfer=drConf["sValor"].ToString();
                        string aux = drConf["sValor"].ToString().Trim();
                        asPedTransfer = aux.Split(' ');
                        //---- FI GSG
						break;
					case 58:
						sIdRed=drConf["sValor"].ToString();
						break;
					case 59:
						iTodasAtenciones=int.Parse( drConf["sValor"].ToString());
						break;
					case 60:
						iTodosClientes=int.Parse(drConf["sValor"].ToString());
						break;
					case 61:
						iGPresupuestos=int.Parse(drConf["sValor"].ToString());
						break;
					case 62:
						iTodosPedidos=int.Parse(drConf["sValor"].ToString());
						break;
					case 63:
						iTodosCentros=int.Parse(drConf["sValor"].ToString());
						break;
					case 64:
						iCreaMedicos=int.Parse(drConf["sValor"].ToString());
						break;
					case 65:
						iCreaCentros=int.Parse(drConf["sValor"].ToString());
						break;
					case 66:
						iTodasAcciones=int.Parse(drConf["sValor"].ToString());
						break;
					case 67:
						 bMuestraResultadosSincro=int.Parse(drConf["sValor"].ToString());
						break;

					case 68:
						bTodosReports=int.Parse(drConf["sValor"].ToString());
						break;

					case 69:
						bPromProductosOtrasRedes =(int.Parse(drConf["sValor"].ToString())==1);
						break;
					
					case 70:
						bAsignarEspecPropias =(int.Parse(drConf["sValor"].ToString())==1);
						break;
					case 100:
						iUIClienteCLI=int.Parse(drConf["sValor"].ToString());
						break;
					case 101:
						iUIPedidoCLI=int.Parse(drConf["sValor"].ToString());
						break;
					case 102:
						iUIVisitaCLI=int.Parse(drConf["sValor"].ToString());
						break;
					case 103:
						iUIAtencionCLI=int.Parse(drConf["sValor"].ToString());
						break;
					case 104:
						iUIGastosCLI=int.Parse(drConf["sValor"].ToString());
						break;
					case 107:
						fRentabilidadMinima = float.Parse(drConf["sValor"].ToString());
						break;
					case 108:
						if (drConf["sValor"] != null)
						{
							bObligarObsPedidoEnVerano = ((int.Parse(drConf["sValor"].ToString())) == 1);
						}
						break;
                    case 109: 
                        iIdCampanya = drConf["sValor"].ToString(); //---- GSG (10/07/2013)
                        break;
                    case 110: 
                        iMaxNumAccMark = drConf["sValor"].ToString(); //---- GSG (20/09/2013)
                        break;
                    case 111:
                        fDescLegAccMarkCamp = drConf["sValor"].ToString(); //---- GSG (22/10/2013)
                        break;
                    case 112:
                        iMesesInformeS = int.Parse(drConf["sValor"].ToString()); //---- GSG (14/01/2014)
                        break;
                    case 113:
                        iMesesPedidoTipo = int.Parse(drConf["sValor"].ToString()); //---- GSG (14/01/2014)
                        break;
                    //---- GSG (14/03/2014)
                    case 114:
                        iGPedidosCrear = int.Parse(drConf["sValor"].ToString()); 
                        break;
                    case 115:
                        iGPedidosCopiar = int.Parse(drConf["sValor"].ToString());
                        break;
                    case 116:
                        iGPedidosPropuesta = int.Parse(drConf["sValor"].ToString());
                        break;
                    case 117:
                        iGInformeVentas = int.Parse(drConf["sValor"].ToString());
                        break;
                    case 118:
                        iGImportExcel = int.Parse(drConf["sValor"].ToString());
                        break;
                    case 119:
                        iGImportUnycop = int.Parse(drConf["sValor"].ToString());
                        break;
                    case 120: //---- GSG (02/06/2014)
                        iIndicadoresGlobales = int.Parse(drConf["sValor"].ToString());
                        break;
                    case 121: //---- GSG (19/10/2015)
                        sIdCampanyaTarjetasCliente = drConf["sValor"].ToString();
                        break;
                    //---- GSG CECL 19/05/2016
                    case 122:
                        iGAccMarkPed = int.Parse(drConf["sValor"].ToString());
                        break;
                    case 123:
                        iGAlarmVisit = int.Parse(drConf["sValor"].ToString());
                        break;
                    case 124:
                        iGStock = int.Parse(drConf["sValor"].ToString());
                        break;
                    case 125:
                        iGSincro = int.Parse(drConf["sValor"].ToString());
                        break;
                    case 126:
                        iGCopiaSeg = int.Parse(drConf["sValor"].ToString());
                        break;
                    //---- FI GSG CECL                    
                    case 127: //---- GSG (07/10/2016)
                        fMinDirFinan = int.Parse(drConf["sValor"].ToString());
                        break;
                    //---- GSG (11/07/2017)
                    case 128: 
                        fDescCofares = float.Parse(drConf["sValor"].ToString());
                        break;
                    case 129:
                        fImpCofares = float.Parse(drConf["sValor"].ToString());
                        break;
                    //---- GSG (26/02/2018)
                    case 130:
                        fImpMinDIR = float.Parse(drConf["sValor"].ToString());
                        break;
                    case 131:
                        iDiasRobo = int.Parse(drConf["sValor"].ToString());
                        break;
                    //---- GSG (29/09/2020)
                    case 133:
                        iPuntosDividePor = int.Parse(drConf["sValor"].ToString());
                        break;
                    case 134:
                        iPuntosMultiplicaPor = int.Parse(drConf["sValor"].ToString());
                        break;
					//---- GSG (02/01/2023)
					case 136:
						iDiasCompromiso = int.Parse(drConf["sValor"].ToString());
						break;
					case 137:
						iDiasTransfer = int.Parse(drConf["sValor"].ToString());
						break;
					case 138:
						iDiasDirecto = int.Parse(drConf["sValor"].ToString());
						break;
					case 139:						
						asTiposNoDescMedio = drConf["sValor"].ToString().Trim().Split(' ');   //---- VLP (27/07/2023)
						break;
					default: break;
				}
			}
			drConf.Close();

			 
            iIdProviciaDefectoDelegado = ObtenerProvinciaDefectoDelegado(sqlConn);
			sqlConn.Close();


            //---- GSG (10/09/2014)
            //sqlConn.Dispose();
            //Recupera del App.config
            //sqlCadenaCon = ConfigurationManager.AppSettings["sConn"].ToString();

            //---- GSG CECL 19/05/2016
            if (System.Configuration.ConfigurationManager.AppSettings["TipoDelegadoPedidosCentral"].ToString() == Comun.K_CECL)
            {
                sUsuario = System.Configuration.ConfigurationManager.AppSettings["UsuarioPedidosCentral"].ToString();
                iIdDelegado = int.Parse(System.Configuration.ConfigurationManager.AppSettings["DelegadoPedidosCentral"].ToString());
            }
            //---- FI GSG CECL

        }
		
		/// <summary>
		/// LSR 15032005
		/// Obtiene la primera provincia que corresponde al delegado por sus bricks
		/// ET 10052005
		/// Se pone el Try catch para cuando no devuelva nada poner 0 (debe pasar solo en caso de base de Datos vacía
		/// </summary>
		/// <param name="sqlConn">Conexion abierta</param>
		/// <returns>idProvincia</returns>
		public static int ObtenerProvinciaDefectoDelegado(SqlConnection sqlConn)
		{
			try
			{
				SqlCommand sqlCmd = sqlConn.CreateCommand();
				sqlCmd.CommandText = "GetProvinciaDelegado";
				sqlCmd.CommandType = CommandType.StoredProcedure;
				return (int) sqlCmd.ExecuteScalar();
			}
			catch
			{return 0;}
		}

		public static void Graba()
		{
            //---- GSG (10/09/2014)
            //SqlConnection sqlConn = new SqlConnection(ConfigurationManager.AppSettings["sConn"].ToString());
            SqlConnection sqlConn = new SqlConnection();
            sqlConn = Utiles._connection;

            //---- GSG (10/09/2014)
            //this.sqlConn.Open();
            if (sqlConn.State == ConnectionState.Closed)
                sqlConn.Open();


			SqlTransaction sqlTran = sqlConn.BeginTransaction();
			SqlCommand sqlCmd = sqlConn.CreateCommand();
			sqlCmd.Transaction=sqlTran;
			sqlCmd.CommandText="SetConfiguracion";
			sqlCmd.CommandType=CommandType.StoredProcedure;
			sqlCmd.Parameters.Add("@iIdConfig",SqlDbType.Int);
			sqlCmd.Parameters.Add("@sValor",SqlDbType.VarChar,30);

			try
			{
				//Grabamos iUIClienteCLI.
				sqlCmd.Parameters["@iIdConfig"].Value=100;
				sqlCmd.Parameters["@sValor"].Value=iUIClienteCLI.ToString();
				sqlCmd.ExecuteNonQuery();
				//Grabamos iUIPedidoCLI.
				sqlCmd.Parameters["@iIdConfig"].Value=101;
				sqlCmd.Parameters["@sValor"].Value=iUIPedidoCLI.ToString();
				sqlCmd.ExecuteNonQuery();
				//Grabamos iUIVisitaCLI.
				sqlCmd.Parameters["@iIdConfig"].Value=102;
				sqlCmd.Parameters["@sValor"].Value=iUIVisitaCLI.ToString();
				sqlCmd.ExecuteNonQuery();
				//Grabamos iUIAtencionCLI.
				sqlCmd.Parameters["@iIdConfig"].Value=103;
				sqlCmd.Parameters["@sValor"].Value=iUIAtencionCLI.ToString();
				sqlCmd.ExecuteNonQuery();

				//Grabamos iUIGastosCLI.
				sqlCmd.Parameters["@iIdConfig"].Value=104;
				sqlCmd.Parameters["@sValor"].Value=iUIAtencionCLI.ToString();
				sqlCmd.ExecuteNonQuery();

				//Commit de la transacción.
				sqlTran.Commit();
				sqlTran.Dispose();
			}
			catch(Exception excConf)
			{
				sqlTran.Rollback();
				Mensajes.ShowErrorField(excConf.Message);
			}

			sqlConn.Close();
            //---- GSG (10/09/2014)
            //sqlConn.Dispose();

		}
	}
}
