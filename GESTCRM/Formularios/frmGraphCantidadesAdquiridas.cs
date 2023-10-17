using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GESTCRM.Formularios
{
    public partial class frmGraphCantidadesAdquiridas : Form
    {
        private DateTime _fecIni;
        private DateTime _fecFin;
        private int _iIdCliente;
        private string _sCodNacional;

        public frmGraphCantidadesAdquiridas(DateTime fecIni, DateTime fecFin, int iIdCliente, string sCodNacional, string sMaterial)
        {
            InitializeComponent();


            //---- GSG (06/03/2021)
            Utiles.GetConfigConnection();
            this.sqlConn.ConnectionString = Utiles._connection.ConnectionString.ToString();

           
            _fecIni = fecIni;
            _fecFin = fecFin;
            _iIdCliente = iIdCliente;
            _sCodNacional = sCodNacional;

            lblMaterial.Text = sMaterial;
        }

        private void frmGraphCantidadesAdquiridas_Load(object sender, EventArgs e)
        {
            GraphCantidadesAdquiridas();
        }


        // Gráfica Cantidades adquiridas en los últimos pedidos
        //------------------------------------------
        private void GraphCantidadesAdquiridas()
        {
            int mesIni = _fecIni.Month;
            int anyIni = _fecIni.Year;
            int mesFin = _fecFin.Month;
            int anyFin = _fecFin.Year;
            int iItems = 0;

            if (anyFin == anyIni)
                iItems = mesFin - mesIni + 1;
            else
            {
                int numYears = anyFin - anyIni - 1;
                iItems = 12 - mesIni + 1;      //primer año
                iItems += mesFin;              //último año
                iItems += (numYears * 12);     //años intermedios
            }


            // Valores para el eje X

            string[] xVals = new string[iItems];

            for (int i = 0; i < iItems; i++)
            {
                xVals[i] = mesIni.ToString() + " / " + anyIni.ToString().Substring(2);

                if (mesIni == 12)
                {
                    mesIni = 1;
                    anyIni += 1;
                }
                else
                    mesIni += 1;
            }


            // Valores para el eje Y

            int[] yVals_1 = new int[iItems]; //qty


            DateTime fecIni;
            DateTime fecFin;

            mesIni = _fecIni.Month;
            anyIni = _fecIni.Year;

            for (int i = 0; i < iItems; i++)
            {
                fecIni = DateTime.Parse("01/" + mesIni.ToString() + "/" + anyIni.ToString());
                fecFin = DateTime.Parse(DateTime.DaysInMonth(anyIni, mesIni).ToString() + "/" + mesIni.ToString() + "/" + anyIni.ToString());

                CargarDatos(fecIni, fecFin);


                if (mesIni == 12)
                {
                    mesIni = 1;
                    anyIni += 1;
                }
                else
                    mesIni += 1;
                

                if (dsGraphs1.CantidadesAdquiridasFcia.Rows.Count > 0 && dsGraphs1.CantidadesAdquiridasFcia.Rows[0][0].ToString() != "")
                    yVals_1[i] = int.Parse(dsGraphs1.CantidadesAdquiridasFcia.Rows[0][0].ToString());
                else
                    yVals_1[i] = 0;
            }

            chartCantidadesVendidas.Series[0].Points.DataBindXY(xVals, yVals_1); //Serie barras verticales
            chartCantidadesVendidas.ChartAreas[0].AxisX.Interval = 1;

            //Cálculo de la media por meses

            string[] xValsMedia = new string[iItems]; 
            for (int i = 0; i < iItems; i++)
                xValsMedia[i] = xVals[i];

            double media = 0.0;
            for (int i = 0; i < iItems; i++)
            {
                media += yVals_1[i];
            }

            if (iItems != 0)
                media /= iItems;

            double[] yValsMedia = new double[iItems];
            for (int i = 0; i < iItems; i++)
                yValsMedia[i] = media;
         

            chartCantidadesVendidas.Series[1].Points.DataBindXY(xValsMedia, yValsMedia); //Serie línea de media
            chartCantidadesVendidas.Series[1].LegendText = "Media por meses: " + media.ToString("0.##") + " Unidades";


            //Cálculo de la media por pedido //---- GSG (11/03/2014)

            string[] xValsMediaPedido = new string[iItems];
            for (int i = 0; i < iItems; i++)
                xValsMediaPedido[i] = xVals[i];

            fecIni = DateTime.Parse("01/" + _fecIni.Month.ToString() + "/" + _fecIni.Year.ToString());
            fecFin = DateTime.Parse(DateTime.DaysInMonth(_fecFin.Year, _fecFin.Month).ToString() + "/" + _fecFin.Month.ToString() + "/" + _fecFin.Year.ToString());
            
            int numpeds = ObtenerNumPedidos(fecIni, fecFin); 

            int totalCantidades = 0;

            for (int i = 0; i < iItems; i++)
            {
                totalCantidades += yVals_1[i];
            }

            double mediaPedido = 0.0;

            if (numpeds > 0)
                mediaPedido = double.Parse(totalCantidades.ToString()) / numpeds;


            double[] yValsMediaPedido = new double[iItems];
            for (int i = 0; i < iItems; i++)
                yValsMediaPedido[i] = mediaPedido;

            chartCantidadesVendidas.Series[2].Points.DataBindXY(xValsMediaPedido, yValsMediaPedido); //Serie línea de media pedido
            chartCantidadesVendidas.Series[2].LegendText = "Media por pedido: " + mediaPedido.ToString("0.##") + " Unidades";
        }


        private void CargarDatos(DateTime fecIni, DateTime fecFin)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                this.dsGraphs1.CantidadesAdquiridasFcia.Rows.Clear();

                this.sqldaGetCantidadesAdquiridas.SelectCommand.Parameters["@iIdCliente"].Value = _iIdCliente;
                try { this.sqldaGetCantidadesAdquiridas.SelectCommand.Parameters["@dFechaIni"].Value = fecIni; }
                catch { }
                try { this.sqldaGetCantidadesAdquiridas.SelectCommand.Parameters["@dFechaFin"].Value = fecFin; }
                catch { }
                this.sqldaGetCantidadesAdquiridas.SelectCommand.Parameters["@sCodNacional"].Value = _sCodNacional;

                this.sqldaGetCantidadesAdquiridas.Fill(this.dsGraphs1);

            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }

            Cursor.Current = Cursors.Default;
        }


        //---- GSG (11/03/2014)
        private int ObtenerNumPedidos(DateTime fecIni, DateTime fecFin)
        {
            int bRet = 0;
            SqlDataReader dr;

            try
            {
                if (sqlConn.State.ToString() == "Closed")
                    sqlConn.Open();

                this.sqlCmdGetNumPedidosClienteConMaterial.Parameters["@iIdCliente"].Value = _iIdCliente;
                try { this.sqlCmdGetNumPedidosClienteConMaterial.Parameters["@dFechaIni"].Value = fecIni; }
                catch { }
                try { this.sqlCmdGetNumPedidosClienteConMaterial.Parameters["@dFechaFin"].Value = fecFin; }
                catch { }
                this.sqlCmdGetNumPedidosClienteConMaterial.Parameters["@sCodNacional"].Value = _sCodNacional;

                dr = sqlCmdGetNumPedidosClienteConMaterial.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        bRet = int.Parse(dr["numpeds"].ToString());
                        break;
                    }
                }

                dr.Close();
            }
            catch (Exception e)
            {
                Mensajes.ShowError(e.ToString());
            }

            return bRet;
        }
    }
}
