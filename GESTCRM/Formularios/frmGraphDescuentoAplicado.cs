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
    public partial class frmGraphDescuentoAplicado : Form
    {
        private DateTime _fecIni;
        private DateTime _fecFin;
        private int _iIdCliente;
        private string _sCodNacional;
        private double _fDescMax;

        public frmGraphDescuentoAplicado(DateTime fecIni, DateTime fecFin, int iIdCliente, string sCodNacional, string sMaterial, double fDescMax)
        {
            InitializeComponent();

            //---- GSG (06/03/2021)
            Utiles.GetConfigConnection();
            this.sqlConn.ConnectionString = Utiles._connection.ConnectionString.ToString();

            
            _fecIni = fecIni;
            _fecFin = fecFin;
            _iIdCliente = iIdCliente;
            _sCodNacional = sCodNacional;
            _fDescMax = fDescMax;
            lblMaterial.Text = sMaterial;
        }

        private void frmGraphDescuentoAplicado_Load(object sender, EventArgs e)
        {
            GraphDescuentosAplicados();
        }



        // Gráfica Descuentos aplicados en los últimos pedidos
        //------------------------------------------
        private void GraphDescuentosAplicados()
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

            double[] yVals_1 = new double[iItems]; //descuento

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
                

                if (dsGraphs1.DescuentosAplicadosFcia.Rows.Count > 0 && dsGraphs1.DescuentosAplicadosFcia.Rows[0][1].ToString() != "")
                    yVals_1[i] = (double.Parse(dsGraphs1.DescuentosAplicadosFcia.Rows[0][0].ToString()) / double.Parse(dsGraphs1.DescuentosAplicadosFcia.Rows[0][1].ToString())) * 100; // % descuento
                else
                    yVals_1[i] = 0;
            }

            chartDescuentosAplicados.Series[0].Points.DataBindXY(xVals, yVals_1); //Serie línea descuentos
            chartDescuentosAplicados.ChartAreas[0].AxisX.Interval = 1;

            //Cálculo de la media

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


            chartDescuentosAplicados.Series[1].Points.DataBindXY(xValsMedia, yValsMedia); //Serie línea de media
            chartDescuentosAplicados.Series[1].LegendText = "Media por meses: " + media.ToString("0.##") + " %";


            //Cálculo del máximo
            // descuento máx = MAX(desc max material, desc max campanya)

            if (_fDescMax != -1) //---- GSG (14/05/2014)
            {
                string[] xValsMax = new string[iItems];
                for (int i = 0; i < iItems; i++)
                    xValsMax[i] = xVals[i];

                double[] yValsMax = new double[iItems];
                for (int i = 0; i < iItems; i++)
                    yValsMax[i] = _fDescMax;

                chartDescuentosAplicados.Series[2].Points.DataBindXY(xValsMax, yValsMax); //Serie línea de máximo
                chartDescuentosAplicados.Series[2].LegendText = "Dto. Máximo: " + _fDescMax.ToString("0.##") + " %";
            }
            else
            {
                chartDescuentosAplicados.Series[2].IsVisibleInLegend = false;
                chartDescuentosAplicados.Series[2].Enabled = false;
            }

            //Cálculo de la media por pedido //---- GSG (11/03/2014)

            string[] xValsMediaPedido = new string[iItems];
            for (int i = 0; i < iItems; i++)
                xValsMediaPedido[i] = xVals[i];

            fecIni = DateTime.Parse("01/" + _fecIni.Month.ToString() + "/" + _fecIni.Year.ToString());
            fecFin = DateTime.Parse(DateTime.DaysInMonth(_fecFin.Year, _fecFin.Month).ToString() + "/" + _fecFin.Month.ToString() + "/" + _fecFin.Year.ToString());

            int numpeds = ObtenerNumPedidos(fecIni, fecFin);

            double totalDescuento = 0.0;

            for (int i = 0; i < iItems; i++)
            {
                totalDescuento += yVals_1[i];
            }
           
            double mediaPedido = 0.0;

            if (numpeds > 0)
                mediaPedido = totalDescuento / numpeds;


            double[] yValsMediaPedido = new double[iItems];
            for (int i = 0; i < iItems; i++)
                yValsMediaPedido[i] = mediaPedido;


            chartDescuentosAplicados.Series[3].Points.DataBindXY(xValsMediaPedido, yValsMediaPedido); //Serie línea de media pedido
            chartDescuentosAplicados.Series[3].LegendText = "Media por pedido: " + mediaPedido.ToString("0.##") + " %";

        }


        private void CargarDatos(DateTime fecIni, DateTime fecFin)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                this.dsGraphs1.DescuentosAplicadosFcia.Rows.Clear();

                this.sqldaGetDescuentosAplicados.SelectCommand.Parameters["@iIdCliente"].Value = _iIdCliente;
                try { this.sqldaGetDescuentosAplicados.SelectCommand.Parameters["@dFechaIni"].Value = fecIni; }
                catch { }
                try { this.sqldaGetDescuentosAplicados.SelectCommand.Parameters["@dFechaFin"].Value = fecFin; }
                catch { }
                this.sqldaGetDescuentosAplicados.SelectCommand.Parameters["@sCodNacional"].Value = _sCodNacional;

                this.sqldaGetDescuentosAplicados.Fill(this.dsGraphs1);

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
