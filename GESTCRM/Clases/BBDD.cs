using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace GESTCRM
{
	
	public class BBDD
	{
        //private GESTCRM.Comun.TripletLinPed oTLP;

        private static GESTCRM.Formularios.dsMateriales _dsMateriales;
        private static System.Data.SqlClient.SqlConnection _sqlConn;
        private static SqlDataAdapter _sqlDaListaGruposCamp;
        private static SqlCommand _sqlCmdListaGruposCamp;
        private static SqlDataAdapter _sqlDaListaReglas;
        private static SqlCommand _sqlCmdListaReglas;

        private BBDD()
        {
            
        }

        #region GrupoCampanya
        public static void InitsGrupoCampanya()
        {
            System.Configuration.AppSettingsReader configurationAppSettings = new System.Configuration.AppSettingsReader();

            _dsMateriales = new GESTCRM.Formularios.dsMateriales();
            _sqlDaListaGruposCamp = new System.Data.SqlClient.SqlDataAdapter();
            _sqlCmdListaGruposCamp = new System.Data.SqlClient.SqlCommand();
            _sqlDaListaReglas = new System.Data.SqlClient.SqlDataAdapter();
            _sqlCmdListaReglas = new System.Data.SqlClient.SqlCommand();
            _sqlConn = new System.Data.SqlClient.SqlConnection();

            ((System.ComponentModel.ISupportInitialize)(_dsMateriales)).BeginInit();
            _dsMateriales.DataSetName = "dsMateriales";
            _dsMateriales.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;

            // Grupos Campaña

            _sqlDaListaGruposCamp.SelectCommand = _sqlCmdListaGruposCamp;
            _sqlDaListaGruposCamp.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaGruposCampanya", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("idGrupo", "idGrupo"),
                        new System.Data.Common.DataColumnMapping("idCampanya", "idCampanya"),
                        new System.Data.Common.DataColumnMapping("sMateriales", "sMateriales"),
                        new System.Data.Common.DataColumnMapping("iMinUnidades", "iMinUnidades"),
                        new System.Data.Common.DataColumnMapping("fMinImporte", "fMinImporte"),
                        new System.Data.Common.DataColumnMapping("sIdTipoPedido", "sIdTipoPedido"),
                        new System.Data.Common.DataColumnMapping("iMaxUnidades", "iMaxUnidades"),   //---- GSG (11/01/2018)
                        new System.Data.Common.DataColumnMapping("fMaxImporte", "fMaxImporte"),
                        new System.Data.Common.DataColumnMapping("bObligatorio", "bObligatorio")   //---- GSG (14/05/2018)
            })});
            

            _sqlCmdListaGruposCamp.CommandText = "ListaGruposCampanya";
            _sqlCmdListaGruposCamp.CommandType = System.Data.CommandType.StoredProcedure;
            _sqlCmdListaGruposCamp.Connection = _sqlConn;
            _sqlCmdListaGruposCamp.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@idGrupo", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@idCampanya", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@sIdTipoPedido", System.Data.SqlDbType.VarChar, 4)});


            // Reglas

            _sqlDaListaReglas.SelectCommand = _sqlCmdListaReglas;
            _sqlDaListaReglas.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaReglasCampanyas", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("idGrupoM", "idGrupoM"),
                        new System.Data.Common.DataColumnMapping("idGrupoS", "idGrupoS"),
                        new System.Data.Common.DataColumnMapping("sTipoCalculo", "sTipoCalculo"),
                        new System.Data.Common.DataColumnMapping("iUBaseM", "iUBaseM"),
                        new System.Data.Common.DataColumnMapping("iUBaseS", "iUBaseS")})});


            _sqlCmdListaReglas.CommandText = "ListaReglasCampanyas";
            _sqlCmdListaReglas.CommandType = System.Data.CommandType.StoredProcedure;
            _sqlCmdListaReglas.Connection = _sqlConn;
            _sqlCmdListaReglas.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@idGrupoM", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@idGrupoS", System.Data.SqlDbType.VarChar, 10),});


            ((System.ComponentModel.ISupportInitialize)(_dsMateriales)).EndInit();



             //---- GSG (06/03/2021)
            //_sqlConn.ConnectionString = ((string)(configurationAppSettings.GetValue("sConn", typeof(string))));
            Utiles.GetConfigConnection();
            _sqlConn.ConnectionString = Utiles._connection.ConnectionString.ToString();
            //---- FI GSG

            _sqlConn.FireInfoMessageEventOnUserErrors = false;
        }


       

        public static bool ValidaGrupoCamp(string camp, string tp, List<GESTCRM.Comun.TripletLinPed> tlp)
        {
            List<string> lGrupos = new List<string>();
            List<string> lGruposSdeM = new List<string>();
            bool bRet = true;
            bool bSalir = false; //---- GSG (14/05/2018)
            
            CargaDatosGrupoCamp();

            if (hayGrupos(camp, tp, out lGrupos))
            {
                // Mirar si se cumplen las condiciones de mínimos

                foreach (string grupo in lGrupos)
                {
                    if (!bSalir)
                    {
                        // coger materiales pertenecientes al grupo y mirar si en las líneas del pedido (vienen sólo las de la campaña) están y sumar unidades e importe

                        string sConsulta = "idGrupo = '" + grupo + "'";
                        DataRow[] dr = _dsMateriales.ListaGruposCampanya.Select(sConsulta); // seguro que está la fila

                        int iMinUnidades = int.Parse(dr[0]["iMinUnidades"].ToString());
                        float fMinImporte = float.Parse(dr[0]["fMinImporte"].ToString());
                        string materiales = dr[0]["sMateriales"].ToString();
                        //---- GSG (11/01/2018)
                        int iMaxUnidades = int.Parse(dr[0]["iMaxUnidades"].ToString());
                        float fMaxImporte = float.Parse(dr[0]["fMaxImporte"].ToString());
                        //---- GSG (14/05/2018)
                        bool bObligatorio = bool.Parse(dr[0]["bObligatorio"].ToString());

                        int iUnidades = 0;
                        double fImporte = 0;
                        string material = "";
                        GESTCRM.Comun.TripletLinPed itemTLP;
                        int posComa = 0;

                        while (materiales.Length > 0)
                        {
                            posComa = materiales.IndexOf(",");
                            if (posComa != -1)
                                material = materiales.Substring(0, posComa);
                            else
                                material = materiales;

                            itemTLP = tlp.Find(x => x.material == material);

                            if (itemTLP != null)
                            {
                                iUnidades += itemTLP.iUnidades;
                                fImporte += itemTLP.fImporte;
                            }

                            if (posComa != -1)
                            {
                                posComa++;
                                if (posComa < materiales.Length)
                                    materiales = materiales.Substring(posComa);
                                else
                                    materiales = "";
                            }
                            else
                                materiales = "";
                        }

                        // Mirar si se cumplen las condiciones de mínimos

                        //---- GSG (14/05/2018)
                        bool bComprueba = true; // Comprobar
                        bool bCondiciones = (iUnidades >= iMinUnidades && fImporte >= fMinImporte && (iMaxUnidades == 0 || iUnidades <= iMaxUnidades) && (fMaxImporte == 0 || fImporte <= fMaxImporte));

                        // Si no es obligatorio hay que mirar las condiciones si existe alguno de los materiales implicados
                        if (!bObligatorio && iUnidades == 0) // no hay ningún material del grupo y no es obligatorio que esten
                            bComprueba = false;


                        //if (iUnidades >= iMinUnidades && fImporte >= fMinImporte)
                        //if (iUnidades >= iMinUnidades && fImporte >= fMinImporte && (iMaxUnidades == 0 || iUnidades <= iMaxUnidades) && (fMaxImporte == 0 || fImporte <= fMaxImporte)) //---- GSG (11/01/2018)                    
                        if (bComprueba && bCondiciones) //---- GSG (14/05/2018)
                        {
                            // mirar si el grupo es M o S
                            // si es M --> mirar sus S y ver que se cumplen las reglas con cada S
                            // si es S --> no hacer nada

                            string tipo = GetTipoGrupoCamp(grupo);

                            if (tipo == "M")
                            {
                                if (getGruposSdeM(grupo, out lGruposSdeM))
                                {
                                    foreach (string grupoS in lGruposSdeM)
                                    {
                                        // Buscar materiales del grupo S
                                        sConsulta = "idGrupo = '" + grupoS + "'";
                                        DataRow[] drs = _dsMateriales.ListaGruposCampanya.Select(sConsulta);
                                        materiales = drs[0]["sMateriales"].ToString();

                                        // Buscar en pedido las unidades de materiales del grupo S
                                        int iUnidadesPedS = 0;
                                        while (materiales.Length > 0)
                                        {
                                            posComa = materiales.IndexOf(",");
                                            if (posComa != -1)
                                                material = materiales.Substring(0, posComa);
                                            else
                                                material = materiales;

                                            itemTLP = tlp.Find(x => x.material == material);

                                            if (itemTLP != null)
                                                iUnidadesPedS += itemTLP.iUnidades;


                                            if (posComa != -1)
                                            {
                                                posComa++;
                                                if (posComa < materiales.Length)
                                                    materiales = materiales.Substring(posComa);
                                                else
                                                    materiales = "";
                                            }
                                            else
                                                materiales = "";
                                        }

                                        // Buscar reglas del grupo S con el M que se está tratando
                                        sConsulta = "idGrupoM = '" + grupo + "' AND idGrupoS = '" + grupoS + "'";
                                        DataRow[] drsR = _dsMateriales.ListaReglasCampanyas.Select(sConsulta);
                                        string sTipoCalculo = drsR[0]["sTipoCalculo"].ToString();
                                        int iUBaseM = int.Parse(drsR[0]["iUBaseM"].ToString());
                                        int iUBaseS = int.Parse(drsR[0]["iUBaseS"].ToString());
                                        int iUCalculadas = 0;

                                        if (sTipoCalculo == "M") // Múltiplo
                                            iUCalculadas = (iUnidades / iUBaseM) * iUBaseS;
                                        else if (sTipoCalculo == "P") // Proporcional
                                        {
                                            //---- GSG (14/05/2018)
                                            //iUCalculadas = iUnidades / (iUBaseM / iUBaseS);
                                            if ((iUBaseM / iUBaseS) != 0)
                                                iUCalculadas = iUnidades / (iUBaseM / iUBaseS);
                                            else
                                                iUCalculadas = 50000;
                                        }

                                        if (iUnidades < iUBaseM && iUnidadesPedS != 0) // En este caso no se pueden coger regalos
                                        {
                                            bRet = false;
                                            break;
                                        }
                                        //else if (iUnidades >= iUBaseM && (iUnidadesPedS == 0 || iUnidadesPedS != iUCalculadas)) // se pueden coger pero en la cantidad adequada
                                        //{
                                        //    bRet = false;
                                        //    break;
                                        //}
                                        else if (iUnidades >= iUBaseM && iUnidadesPedS > iUCalculadas) // se pueden coger pero en la cantidad adequada (no es obligatorio paro hay un máximo)                                    
                                        {
                                            bRet = false;
                                            break;
                                        }
                                        else if (iUnidades >= iUBaseM && (iUnidadesPedS == 0 && iUCalculadas != 0)) //---- GSG (14/05/2018)
                                        {
                                            bRet = false;
                                            bSalir = true; // Para que también salga del bucle superior
                                            break;
                                        }
                                    }
                                }
                            }
                        }

                        //---- GSG (14/05/2018)

                        //else
                        //{
                        //    bRet = false;
                        //    break;
                        //}

                        else if (bComprueba && !bCondiciones)
                        {
                            bRet = false;
                            break;
                        }
                        else if (!bComprueba)
                        {
                            bRet = true;
                        }

                    }
                }
            }

            return bRet;
        }


        private static void CargaDatosGrupoCamp()
        {
            try
            {
                SqlConnection sqlConn = new SqlConnection();
                sqlConn = Utiles._connection;

                if (sqlConn.State == ConnectionState.Closed)
                    sqlConn.Open();


                _dsMateriales.ListaGruposCampanya.Clear();
                _dsMateriales.ListaReglasCampanyas.Clear();

                // Carga los grupos existentes

                _sqlDaListaGruposCamp.SelectCommand.Parameters["@idGrupo"].Value = null;
                _sqlDaListaGruposCamp.SelectCommand.Parameters["@idCampanya"].Value = null;
                _sqlDaListaGruposCamp.SelectCommand.Parameters["@sIdTipoPedido"].Value = null;

                _sqlDaListaGruposCamp.Fill(_dsMateriales.ListaGruposCampanya);

                // Carga las reglas existentes

                if (_dsMateriales.ListaGruposCampanya.Rows.Count > 0)
                {
                    _sqlDaListaReglas.SelectCommand.Parameters["@idGrupoM"].Value = null;
                    _sqlDaListaReglas.SelectCommand.Parameters["@idGrupoS"].Value = null;

                    _sqlDaListaReglas.Fill(_dsMateriales.ListaReglasCampanyas);
                }
            }
            catch (Exception ex)
            {
                Mensajes.ShowError(ex.Message);
            }
        }
     

        // Devuelve true si hay que realizar comprobaciones de grupo. 
        // En tal caso, puede que haya uno o más grupos para camp+tp 
        // Retorna el nombre de los grupos que cumplen
        private static bool hayGrupos(string camp, string tp, out List<string> olGrupos)
        {
            bool bRet = false;
            string sConsulta = "";
            List<string> listaGrupos = new List<string>();

            olGrupos = null;

            if (camp != null && tp != null && camp != "" && tp != "")
                sConsulta = "idCampanya = '" + camp + "' AND (sIdTipoPedido = '" + tp + "' OR sIdTipoPedido = 'XXXX')";
            else if (camp != null && camp != "")
                sConsulta = "idCampanya = '" + camp + "'";
            else if (tp != null && tp != "")
                sConsulta = "sIdTipoPedido = '" + tp + "' OR sIdTipoPedido = 'XXXX'";

            DataRow[] dr = _dsMateriales.ListaGruposCampanya.Select(sConsulta);
            if (dr.Length > 0)
            {
                bRet = true;

                foreach (DataRow row in dr)
                {
                    listaGrupos.Add(row["idGrupo"].ToString());                     
                }
            }

            olGrupos = listaGrupos;

            return bRet;
        }

        // Devuelve los grupos S para un determinado grupo M
        private static bool getGruposSdeM(string grupo, out List<string> olGrupos)
        {
            bool bRet = false;
            List<string> listaGrupos = new List<string>();
            string sConsulta = "idGrupoM = '" + grupo + "'";

            olGrupos = null;

            DataRow[] dr = _dsMateriales.ListaReglasCampanyas.Select(sConsulta);
            if (dr.Length > 0)
            {
                bRet = true;

                foreach (DataRow row in dr)
                {
                    listaGrupos.Add(row["idGrupoS"].ToString());
                }
            }

            olGrupos = listaGrupos;

            return bRet;
        }
       
        private static string GetTipoGrupoCamp(string sGrupo)
        {
            string sRet = "";

            string sConsulta = "idGrupoM = '" + sGrupo + "'";

            DataRow[] dr = _dsMateriales.ListaReglasCampanyas.Select(sConsulta);
            if (dr.Length > 0)
                sRet = "M";
            else
            {
                sConsulta = "idGrupoS = '" + sGrupo + "'";
                dr = _dsMateriales.ListaReglasCampanyas.Select(sConsulta);
                if (dr.Length > 0)
                    sRet = "S";
            }

            return sRet;
        }


        //--- GSG (26/02/2018)

        //Obtiene la configuración establecida en la tabla DivionesPedido 
        public static bool GetConfDivisionesPedidos(out DataTable dtDivisiones)
        {
            bool bRet = true;
            dtDivisiones = new DataTable();

            try
            {
                SqlConnection sqlConn = new SqlConnection();
                sqlConn = Utiles._connection;

                if (sqlConn.State == ConnectionState.Closed)
                    sqlConn.Open();

                
                using (SqlCommand cmd = new SqlCommand("ListaDivisionesPedido", sqlConn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dtDivisiones);
                    }
                }
            }
            catch (Exception e)
            {
                string err = e.Message;
                bRet = false;
            }

            return bRet;
        }


        // Determina si una campanya divide el pedido o no
        private static bool EsCampanyaSAP(string idCampanya, string TipoPedido, DataTable dtDivisiones)
        {
            bool bRet = false;

            foreach (DataRow dr in dtDivisiones.Rows)
            {
                if (dr["sIdCampanya"].ToString() == idCampanya && dr["sIdTipoPedido"].ToString() == TipoPedido && bool.Parse(dr["bNoDivide"].ToString()) == false)
                {
                    bRet = true;
                    break;
                }
            }

            return bRet;
        }



        // Determina si un material divide el pedido o no
        private static bool EsMaterialSAP(string idMaterial, string TipoPedido, DataTable dtDivisiones)
        {
            bool bRet = false;

            foreach (DataRow dr in dtDivisiones.Rows)
            {
                // Pongo aquí la condición extra aunque realmente el sistema bNoDivide está pensado para la separación por campañas. Lo dejo por si queremos aplicarlo a material en algún momento
                if (dr["sIdMaterial"].ToString() == idMaterial && dr["sIdTipoPedido"].ToString() == TipoPedido && bool.Parse(dr["bNoDivide"].ToString()) == false)
                {
                    bRet = true;
                    break;
                }
            }

            return bRet;
        }


        // Determina si el material o la campaña dividen el pedido 
        public static bool EsSAP(string idCampanya, string idMaterial, string TipoPedido, DataTable dtDivisiones)
        {
            bool bRet = false;

            bRet = EsMaterialSAP(idMaterial, TipoPedido, dtDivisiones) || EsCampanyaSAP(idCampanya, TipoPedido, dtDivisiones);

            return bRet;
        }

        #endregion

        

    }
}
