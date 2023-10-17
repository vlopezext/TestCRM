//---- GSG (maig 2011)
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.ServiceProcess;


namespace GESTCRM
{
    public class Comun
    {
        public const string K_COD_ESPANYA = "ES";
        public const string K_COD_ANDORRA = "AD";

        //---- GSG (17/11/2014)
        public const string K_CAJA = "1";       // CAJA
        public const string K_EMBALAJE = "2";   // EMBALAJE

        //---- GSG (26/11/2014)
        public const string K_ENMETALICO = "ZB00";

        //---- GSG (29/06/2015)
        public const string K_RED_GEN = "0440";
        public const string K_RED_CH = "0446";

        //---- GSG (14/01/2016)
        public const string K_TIPOPED_COMPROMISO = "ZLOG";
        //---- GSG (02/01/2023)
        public const string K_TIPOPED_TRANSFER = "ZTRA";
        public const string K_TIPOPED_DIRECTO = "ZDIR";

        //---- GSG CECL 19/05/2016
        public const string K_CECL = "CEN";

        //---- GSG (01/02/2017)
        public static List<string> _lNomsPlanificats = new List<string>();

        //---- GSG (07/03/2017)
        public const string K_FECMAX_NOTAGASTO = "01/01/2200";
        


        #region Código de identificación fiscal (CIF)
        public static bool Comprueba_CIF(string sCIF)
        {           
            string lletres = "ABCDEFGHJNPQRSUVW";
            string lletraIni = "";
            string lletraFi = ""; //Dígit de control
            string sNum = "";          
            bool ret = false;

            if (sCIF.Length == 9)
            {
                sNum = sCIF.Substring(1, 7);
                if (Utiles.IsDecimal(sNum))
                {
                    sCIF = sCIF.ToUpper();
                    //valida letra inicial --> Tipo de organización
                    lletraIni = sCIF.Substring(0,1);
                    if (lletres.IndexOf(lletraIni) != -1)
                    {
                        //valida letra final --> letra de control
                        int sumaPar = 0;
                        int sumaImpar = 0;
                        int dobleImpar = 0;

                        for (int i = 0; i < sNum.Length-1; i += 2)
                        {
                            //Suma posicions parells
                            if (i < 6)
                                sumaPar += int.Parse(sNum[i + 1].ToString());
                            //Doble de les posicions senars
                            dobleImpar = (int.Parse(sNum[i].ToString()) * 2);
                            //Suma els dos dígits de cada producte i acumula el resultat
                            sumaImpar += (dobleImpar % 10) + (dobleImpar / 10);
                        }

                        //Doble de la última posició senar
                        dobleImpar = (int.Parse(sNum[sNum.Length - 1].ToString()) * 2);
                        //Suma els dos dígits del producte de la última posició senar i acumula el resultat
                        sumaImpar += (dobleImpar % 10) + (dobleImpar / 10);

                        int sumaTotal = sumaPar + sumaImpar;
                        sumaTotal = (10 - (sumaTotal % 10)) % 10;

                        switch (lletraIni)
                        {
                            case "C":
                            case "K":
                            case "L":
                            case "M":
                            case "N":
                            case "P":
                            case "Q":
                            case "R":
                            case "S":
                            case "W":
                                // NIF de entidades cuyo dígito de control se corresponde con una letra (C,K, L,M, N, P, Q, R, S, W).
                                char[] controls = { 'J', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I' };
                                lletraFi = controls[sumaTotal].ToString();
                                break;
                            default:
                                // NIF de las restantes entidades, cuyo dígito de control es un número . 
                                lletraFi = sumaTotal.ToString();
                                break;
                        }

                        if (lletraFi == sCIF.Substring(8, 1))
                            ret = true;
                    }
                }
            }

            return ret;
        }
        #endregion


        #region número de identificación fiscal NIF
        public static bool Comprueba_NIF(string sNIF)
        {
            bool ret = false;
            string sNum = "";

            sNIF = sNIF.ToUpper();

            if (sNIF.Length == 9)
            {
                sNum = sNIF.Substring(0, 8);
                if (Utiles.IsDecimal(sNum))
                {
                    char lletra = LetraNIF(sNIF.Substring(0, 8));

                    if (lletra == sNIF[8])
                        ret = true;
                }
            }

            return ret;
        }

        public static char LetraNIF(string dni)
        {
            int numDNI;
            string lletres = "TRWAGMYFPDXBNJZSQVHLCKE";

            numDNI = int.Parse(dni);
            return lletres[numDNI % 23];
        }
        #endregion


        #region Número de Identificación de Extranjeros (NIE)
        public static bool Comprueba_NIE(string sNIE)
        {
            bool ret = false;
            string sNum = "";

            sNIE = sNIE.ToUpper();

            if (sNIE.Length == 9 && (sNIE[0] == 'X' || sNIE[0] == 'Y' || sNIE[0] == 'Z'))
            {
                sNum = sNIE.Substring(1, 7); //part numèrica del NIE

                if (Utiles.IsDecimal(sNum))
                {
                    char lletraFinal = LetraNIE(sNIE);

                    if (lletraFinal == sNIE[8])
                        ret = true;
                }
            }

            return ret;
        }

        public static char LetraNIE(string nie)
        {
            string lletres = "ABCDEFGHJNPQRSUVW";
            int numNIE = int.Parse(nie.Substring(1,7)); //part numèrica

            switch (char.ToUpper(nie[0])) //primera lletra
            {
                case 'X':
                    return lletres[numNIE % 23];
                case 'Y':
                    return lletres[(10000000 + numNIE) % 23];
                case 'Z':
                    return lletres[(20000000 + numNIE) % 23];
                default:
                    return '\0';
            }
        }
        #endregion


        #region Datos bancarios
        public static bool Comprueba_CC(string sEntidad, string sOficina, string sControl, string sCC)
        {
            bool ret = false;
            string strEO = "";

            sEntidad = sEntidad.Trim();
            sOficina = sOficina.Trim();
            sControl = sControl.Trim();
            sCC = sCC.Trim();
            
            //Valida entidad
            if (sEntidad.Length == 4 && Utiles.IsDecimal(sEntidad))
            {
                //Valida oficina
                if (sOficina.Length == 4 && Utiles.IsDecimal(sOficina))
                {
                    //Valida número de cuenta
                    if (sCC.Length == 10 && Utiles.IsDecimal(sCC))
                    {
                        //Valida dígitos de control
                        strEO = sEntidad + sOficina;
                        if (validaDigitosControlCC(strEO, sControl, sCC))
                            ret = true;                        
                    }                     
                }
            }

            return ret;
        }

        public static bool validaDigitosControlCC(string psEO, string psDigControl, string psCuenta)
        {
            int[] valoresD1 = new int[] { 4, 8, 5, 10, 9, 7, 3, 6 };
            int[] valoresD2 = new int[] { 1, 2, 4, 8, 5, 10, 9, 7, 3, 6 };
            int control = 0;
            bool ret = false;
            
            //Comprueba dígito 1
            for (int i = 0; i <= 7; i++)
                control += int.Parse(psEO.Substring(i, 1)) * valoresD1[i];
            control = 11 - (control % 11);
            if (control == 10) control = 1;
            else if (control == 11) control = 0;

            if (control == int.Parse(psDigControl.Substring(0, 1)))
            {
                //Comprueba dígito 2
                control = 0;
                for (int i = 0; i <= 9; i++)
                    control += int.Parse(psCuenta.Substring(i, 1)) * valoresD2[i];
                control = 11 - (control % 11);
                if (control == 10) control = 1;
                else if (control == 11) control = 0;
                if (control == int.Parse(psDigControl.Substring(1, 1)))
                    ret = true;
            }

            return ret;
        }


        public static bool Comprueba_CC_Andorra(string sCuenta)
        {
            bool ret = false;

            sCuenta = sCuenta.Trim();

            if (sCuenta.Length >= 6 && sCuenta.Length <= 20)
            {
                ret = true;
            }

            return ret;
        }

        public static bool Comprueba_IBAN_Espanya(string sIban, string sEntidad, string sOficina, string sControl, string sCC)
        {
            bool ret = false;

            sIban = sIban.Trim();
            sEntidad = sEntidad.Trim();
            sOficina = sOficina.Trim();
            sControl = sControl.Trim();
            sCC = sCC.Trim();


            if (Comprueba_CC(sEntidad, sOficina, sControl, sCC)) // Valida CC
                //---- GSG (06/05/2015)
                //if (sIban.Substring(0, 2) == K_COD_ESPANYA) // El dígits de pais estan bé?
                if (sIban.Length > 2 && sIban.Substring(0, 2) == K_COD_ESPANYA) // El dígits de pais estan bé?
                    if (validaDigitosControlIBAN(K_COD_ESPANYA, sIban, sEntidad, sOficina, sControl, sCC)) // Valida dígitos de control IBAN
                        ret = true;

            return ret;
        }


        public static bool validaDigitosControlIBAN(string sPais, string sIban, string sEntidad, string sOficina, string sControl, string sCC)
        {
            bool ret = false;

            List<char> alfabet = new List<char>{ 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 
                                                 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 
                                                 'U', 'V', 'W', 'X', 'Y', 'Z'};

            sIban = sIban.Trim();
            sEntidad = sEntidad.Trim();
            sOficina = sOficina.Trim();
            sControl = sControl.Trim();
            sCC = sCC.Trim();

            // Método de cálculo de los dígitos de control:
            // 1.- Afegir el codi del pais i dos zeros al final del compte corrent local;
            // 2.- Convertir les lletres A a Z que contingui el resultat anterior en els valors 10 a 35;
            // 3.- Calcular el mòdul 97 (reste de la divisió entera per 97) del número anterior;
            // 4.- Restar aquest valor de 98, i
            // 5.- aquest darrer resultat, amb un zero a l'esquerra si és inferior a 10, són els dígits de control

            string all = "";
            string allModificat = "";
            char lletra = ' ';
            int posLletra = -1;           
            string digitsControlCalculats = "";


            // 1.-
            all = sEntidad + sOficina + sControl + sCC + sPais + "00";

            // 2.-
            for (int i = 0; i < all.Length; i++)
            {
                lletra = all[i];
                posLletra = alfabet.BinarySearch(lletra);
                
                if (posLletra != -1)
                {
                    posLletra = posLletra + 10;
                    allModificat += posLletra.ToString(); 
                }
                else
                {
                    allModificat += lletra;
                }
            }

            // 3.-
            int val = (int)(decimal.Parse(allModificat) % 97);

            // 4.-
            val = 98 - val;

            // 5.-
            if (val < 10)
                digitsControlCalculats = "0" + val.ToString();
            else
                digitsControlCalculats = val.ToString();

            if (digitsControlCalculats == sIban.Substring(2, 2))
                ret = true;


            return ret;
        }


        public static string calcula_IBAN_Espanya(string sEntidad, string sOficina, string sControl, string sCC)
        {
            string ret = "";

            List<char> alfabet = new List<char>{ 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 
                                                 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 
                                                 'U', 'V', 'W', 'X', 'Y', 'Z'};

            sEntidad = sEntidad.Trim();
            sOficina = sOficina.Trim();
            sControl = sControl.Trim();
            sCC = sCC.Trim();

            string all = "";
            string allModificat = "";
            char lletra = ' ';
            int posLletra = -1;
            string digitsControlCalculats = "";


            // 1.-
            all = sEntidad + sOficina + sControl + sCC + K_COD_ESPANYA + "00";

            // 2.-
            for (int i = 0; i < all.Length; i++)
            {
                lletra = all[i];
                posLletra = alfabet.BinarySearch(lletra);

                if (posLletra != -1)
                {
                    posLletra = posLletra + 10;
                    allModificat += posLletra.ToString();
                }
                else
                {
                    allModificat += lletra;
                }
            }

            // 3.-
            int val = (int)(decimal.Parse(allModificat) % 97);

            // 4.-
            val = 98 - val;

            // 5.-
            if (val < 10)
                digitsControlCalculats = "0" + val.ToString();
            else
                digitsControlCalculats = val.ToString();

            ret = "ES" + digitsControlCalculats;

            return ret;
        }



        #endregion


        #region Arrays

        public static bool IsInTheArray(string valor, string[] arr)
        {
            bool ret = false;

            //---- GSG (26/07/2011) afegeix condició
            if (arr != null)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (valor == arr[i])
                    {
                        ret = true;
                        break;
                    }
                }
            }

            return ret;
        }
        
        public static bool bEquals(string[] arr1, string[] arr2)
        {
            bool bRet = true;

            if (arr1.Length != arr2.Length)
                bRet = false;
            else
            {
                int len  = Math.Min(arr1.Length, arr2.Length);

                for (int i = 0; i < len; i++)
                {
                    if (arr1[i] != arr2[i])
                    {
                        bRet = false;
                        break;
                    }
                }
            }

            return bRet;
        }

        public static string[] GetDifferenceOfArrays(string[] arr1, string[] arr2)
        {
            string result = "";

            if (arr1.Length == 0)
                return arr2;
            else if (arr2.Length == 0)
                return arr1;
            else
            {
                for (int i = 0; i < arr1.Length; i++)
                {
                    if (!IsInTheArray(arr1[i], arr2))
                        result += (arr1[i] + ",");
                }

                for (int i = 0; i < arr2.Length; i++)
                {
                    if (!IsInTheArray(arr2[i], arr1))
                        result += (arr2[i] + ",");
                }
            }

            return result.Split(',');

        }

        #endregion

        #region Fechas

        public static DateTime calculaFechaIni(DateTime fecha)
        {
            DateTime dRet = DateTime.MinValue;

            try
            {
                int daysInMonth = DateTime.DaysInMonth(fecha.Year, fecha.Month);
                DateTime dAux = DateTime.Parse(daysInMonth.ToString() + "/" + fecha.Month.ToString() + "/" + fecha.Year.ToString());

                dRet = dAux.AddMonths(-1 * Clases.Configuracion.iMesesInformeS);

                if (dRet.Month != 12)
                    dRet = DateTime.Parse("01/" + (dRet.Month + 1).ToString() + "/" + dRet.Year.ToString());
                else
                    dRet = DateTime.Parse("01/01/" + (dRet.Year + 1).ToString());
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }

            return dRet;
        }


        //---- GSG (02/01/2023)
        // Días laborables entre dos fechas eliminando solo fines de semana
        public static int GetWorkingDays(DateTime from, DateTime to) 
        { 
            var totalDays = 0; 

            for (var date = from; date < to; date = date.AddDays(1)) 
            { 
                if (date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday) 
                    totalDays++; 
            } 
            
            return totalDays; 
        }




         #endregion

            #region graficas

            public static void showGraphQty(int iIdCliente, string sCodNacional, string sMaterial)
        {
            DateTime hoy = DateTime.Today;
            DateTime dFecIni = Comun.calculaFechaIni(hoy);
            //En dFecFin pongo 01 porque no me importa el día a la hora de dibujar el gráfico, sino tendría que calcularlo en función del año y el mes
            DateTime dFecFin = DateTime.Parse("01/" + hoy.Month.ToString() + "/" + hoy.Year.ToString());

            Form frmTemp = new Formularios.frmGraphCantidadesAdquiridas(dFecIni, dFecFin, iIdCliente, sCodNacional, sMaterial);
            frmTemp.ShowDialog();
        }


        public static void showGraphDesc(int iIdCliente, string sCodNacional, string sMaterial, double fDescMaxCamp)
        {
            DateTime hoy = DateTime.Today;
            DateTime dFecIni = Comun.calculaFechaIni(hoy);
            DateTime dFecFin = DateTime.Parse("01/" + hoy.Month.ToString() + "/" + hoy.Year.ToString());

            Form frmTemp = new Formularios.frmGraphDescuentoAplicado(dFecIni, dFecFin, iIdCliente, sCodNacional, sMaterial, fDescMaxCamp);
            frmTemp.ShowDialog();
        }

        //---- GSG (02/02/2021)
        public static void showGraphPuntos(int iIdCliente)
        {
            DateTime hoy = DateTime.Today;
            DateTime dFecIni = Comun.calculaFechaIni(hoy);
            DateTime dFecFin = DateTime.Parse("01/" + hoy.Month.ToString() + "/" + hoy.Year.ToString());

            Form frmTemp = new Formularios.frmGraphPuntos(dFecIni, dFecFin, iIdCliente);
            frmTemp.ShowDialog();
        }


        #endregion

        //---- GSG (13/07/2015)
        public static string servicioW(string myServiceName)
        {
            //myServiceName = "MSSQL$SQLEXPRESS"; //service name of SQL Server Express
            string status; //service status (For example, Running or Stopped)
            string msg = "";

            ServiceController mySC = new ServiceController(myServiceName);

            try
            {
                status = mySC.Status.ToString();

                //if service is Stopped or StopPending, you can run it with the following code.
                if (mySC.Status.Equals(ServiceControllerStatus.Stopped) | mySC.Status.Equals(ServiceControllerStatus.StopPending))
                {
                    try
                    {
                        mySC.Start();
                        mySC.WaitForStatus(ServiceControllerStatus.Running);
                    }
                    catch (Exception ex)
                    {
                        msg = "Error al arrancar el servicio " + myServiceName + ": " + ex.Message;
                    }

                }
            }
            catch (Exception ex)
            {
                msg = "No se ha encontrado el servicio " + myServiceName + ". Probablemente no está instalado. [exception = " + ex.Message + "]";
            }

            return msg;
        }



        //---- GSG (23/08/2017)
        // Classe per a contenir valors necessaris per a les comprobacions dels grups de materials a les campanyes
        public class TripletLinPed
        {
            public string material { get; set; }

            public int iUnidades { get; set; }

            public double fImporte { get; set; }

            public TripletLinPed(string mat, int qty, double imp)
            {
                this.material = mat;
                this.iUnidades = qty;
                this.fImporte = imp;
            }
        }

    }
}
