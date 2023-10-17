using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GESTCRM.Formularios
{
    public partial class frmGraphVentasProdFcia : Form
    {
        private DateTime _fecIni;
        private DateTime _fecFin;
        private int _iIdCliente;
        private string _sCodNacional;


        private System.Data.SqlClient.SqlConnection sqlConn;
        private System.Data.SqlClient.SqlDataAdapter sqldaGetVentasMatFciaPorCanal;
        private System.Data.SqlClient.SqlCommand sqlCmdGetVentasMatFciaPorCanal;



        public frmGraphVentasProdFcia(DateTime fecIni, DateTime fecFin, int iIdCliente, string sCodNacional, string sMaterial)
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


        private void frmGraphVentasProdFcia_Load(object sender, EventArgs e)
        {
            GraphVentasPorPedidoYCanal();
        }


        // Gráfica Ventas por Pedido y Canal
        //------------------------------------------
        private void GraphVentasPorPedidoYCanal()
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

            double[] yVals_1 = new double[iItems]; //Dir
            double[] yVals_2 = new double[iItems]; //Auto
            double[] yVals_3 = new double[iItems]; //Transfer
            double[] yVals_4 = new double[iItems]; //Club

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

                yVals_1[i] = double.Parse(dsGraphs1.VentasMatFciaPorCanal.Rows[0][0].ToString());
                yVals_2[i] = double.Parse(dsGraphs1.VentasMatFciaPorCanal.Rows[0][1].ToString());
                yVals_3[i] = double.Parse(dsGraphs1.VentasMatFciaPorCanal.Rows[0][2].ToString());
                yVals_4[i] = double.Parse(dsGraphs1.VentasMatFciaPorCanal.Rows[0][3].ToString());
            }

            chartVentasPedidoCanal.Series[0].Points.DataBindXY(xVals, yVals_1);
            chartVentasPedidoCanal.Series[1].Points.DataBindXY(xVals, yVals_2);
            chartVentasPedidoCanal.Series[2].Points.DataBindXY(xVals, yVals_3);
            chartVentasPedidoCanal.Series[3].Points.DataBindXY(xVals, yVals_4);

            chartVentasPedidoCanal.ChartAreas[0].AxisX.Interval = 1;



            // Gráfica Ventas Totales por Canal de Venta
            //------------------------------------------
            string[] xVals2 = { "Directo", "Transfer", "Club", "Autopedido" };

            double totalVentas = 0.0;
            double dVentasDir = 0.0;
            double dVentasTran = 0.0;
            double dVentasClub = 0.0;
            double dVentasAuto = 0.0;
            
            for (int i = 0; i < iItems; i++)
            {
                dVentasDir += yVals_1[i];
                dVentasTran += yVals_2[i];
                dVentasClub += yVals_3[i];
                dVentasAuto += yVals_4[i];
            }

            totalVentas = dVentasDir + dVentasTran + dVentasClub + dVentasAuto;

            double[] yVals2 = { (dVentasDir * 100) / totalVentas, (dVentasTran * 100) / totalVentas, (dVentasClub * 100) / totalVentas, (dVentasAuto * 100) / totalVentas };

            chartVentasCanal.Series[0].Points.DataBindXY(xVals2, yVals2);

        }



        private void CargarDatos(DateTime fecIni, DateTime fecFin)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                this.dsGraphs1.VentasMatFciaPorCanal.Rows.Clear();

                this.sqldaGetVentasMatFciaPorCanal.SelectCommand.Parameters["@iIdCliente"].Value = _iIdCliente;
                try { this.sqldaGetVentasMatFciaPorCanal.SelectCommand.Parameters["@dFechaIni"].Value = fecIni; }
                catch { }
                try { this.sqldaGetVentasMatFciaPorCanal.SelectCommand.Parameters["@dFechaFin"].Value = fecFin; }
                catch { }
                this.sqldaGetVentasMatFciaPorCanal.SelectCommand.Parameters["@sCodNacional"].Value = _sCodNacional;

                this.sqldaGetVentasMatFciaPorCanal.Fill(this.dsGraphs1);

            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
            Cursor.Current = Cursors.Default;
        }


    }

}
