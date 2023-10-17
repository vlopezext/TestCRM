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
    public partial class frmGraphPuntos : Form
    {
        private DateTime _fecIni;
        private DateTime _fecFin;
        private int _iIdCliente;

        public frmGraphPuntos(DateTime fecIni, DateTime fecFin, int iIdCliente)
        {
            InitializeComponent();

            //---- GSG (06/03/2021)
            Utiles.GetConfigConnection();
            this.sqlConn.ConnectionString = Utiles._connection.ConnectionString.ToString();

            
            _fecIni = fecIni;
            _fecFin = fecFin;
            _iIdCliente = iIdCliente;
        }

        private void frmGraphPuntos_Load(object sender, EventArgs e)
        {
            GraphPuntos();
        }



        // Gráfica bruto, neto y puntos medios en los últimos pedidos por meses
        //---------------------------------------------------------------------------------
        private void GraphPuntos()
        {
            int mesIni = _fecIni.Month;
            int anyIni = _fecIni.Year;
            int mesFin = _fecFin.Month;
            int anyFin = _fecFin.Year;
            int iItems = 0;


            // Cargar Datos
            DateTime fecIni;
            DateTime fecFin;

            fecIni = DateTime.Parse("01/" + mesIni.ToString() + "/" + anyIni.ToString());
            fecFin = DateTime.Parse(DateTime.DaysInMonth(anyFin, mesFin).ToString() + "/" + mesFin.ToString() + "/" + anyFin.ToString());

            CargarDatos(fecIni, fecFin);


            // Valores para el eje X
            
            if (anyFin == anyIni)
                iItems = mesFin - mesIni + 1;
            else
            {
                int numYears = anyFin - anyIni - 1;
                iItems = 12 - mesIni + 1;      //primer año
                iItems += mesFin;              //último año
                iItems += (numYears * 12);     //años intermedios
            }

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

            double[] yVals_1 = new double[iItems]; // valores para brutos 
            double[] yVals_2 = new double[iItems]; // valores para netos 
            double[] yVals_3 = new double[iItems]; // valores para puntos 
            double[] yVals_4 = new double[iItems]; // media bruto
            double[] yVals_5 = new double[iItems]; // media neto
            double[] yVals_6 = new double[iItems]; // media puntos

            double brutoMedio = 0;
            double netoMedio = 0;
            double puntosMedio = 0;

            if (dsGraphs1.DatosMediosPedidos.Count > 0)
            {
                brutoMedio = double.Parse(dsGraphs1.DatosMediosPedidos.Rows[0][1].ToString()); // bruto medio
                netoMedio = double.Parse(dsGraphs1.DatosMediosPedidos.Rows[0][2].ToString()); // neto medio
                puntosMedio = double.Parse(dsGraphs1.DatosMediosPedidos.Rows[0][3].ToString()); // media puntos
            }



            mesIni = _fecIni.Month;
            anyIni = _fecIni.Year;

            int index = 0; // El número de registros devuelto puede ser menor que el número de meses en el período porque no puede haber meses sin ventas

            for (int i = 0; i < iItems; i++)
            {
                DataRow[] dr = dsGraphs1.DatosPedidosMes.Select("anyo = " + anyIni + " AND mes = " + mesIni);

                if (dr.Length > 0)
                {
                    yVals_1[i] = double.Parse(dsGraphs1.DatosPedidosMes.Rows[index][1].ToString()); // bruto
                    yVals_2[i] = double.Parse(dsGraphs1.DatosPedidosMes.Rows[index][2].ToString()); // neto
                    yVals_3[i] = double.Parse(dsGraphs1.DatosPedidosMes.Rows[index][3].ToString()); // puntos

                    index++;
                }
                else
                {
                    yVals_1[i] = 0;
                    yVals_2[i] = 0;
                    yVals_3[i] = 0;
                }

                yVals_4[i] = brutoMedio; // bruto medio
                yVals_5[i] = netoMedio; // neto medio
                yVals_6[i] = puntosMedio; // neto medio

                if (mesIni == 12)
                {
                    mesIni = 1;
                    anyIni += 1;
                }
                else
                    mesIni += 1;
            }

            


            // GRAFICA IMPORTES

            chartImportes.Series[0].Points.DataBindXY(xVals, yVals_1); //Serie línea de brutos
            chartImportes.Series[1].Points.DataBindXY(xVals, yVals_2); //Serie línea de netos
            chartImportes.Series[2].Points.DataBindXY(xVals, yVals_4); //Serie línea de bruto medio
            chartImportes.Series[3].Points.DataBindXY(xVals, yVals_5); //Serie línea de neto medio

            chartImportes.Series[0].LegendText = "Bruto";
            chartImportes.Series[1].LegendText = "Neto";
            chartImportes.Series[2].LegendText = "Media Importe Bruto";
            chartImportes.Series[3].LegendText = "Media Importe Neto";

            chartImportes.ChartAreas[0].AxisX.Interval = 1;


            // GRAFICA PUNTOS

            chartPuntos.Series[0].Points.DataBindXY(xVals, yVals_3);
            chartPuntos.Series[1].Points.DataBindXY(xVals, yVals_6);

            chartPuntos.Series[0].LegendText = "Puntos";
            chartPuntos.Series[1].LegendText = "Media Puntos";

            chartPuntos.ChartAreas[0].AxisX.Interval = 1;


        }


        private void CargarDatos(DateTime fecIni, DateTime fecFin)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                // Valores medios

                this.dsGraphs1.DatosMediosPedidos.Rows.Clear();

                this.sqldaGetDatosMediosPedidos.SelectCommand.Parameters["@iIdCliente"].Value = _iIdCliente;
                try { this.sqldaGetDatosMediosPedidos.SelectCommand.Parameters["@dFechaIni"].Value = fecIni; }
                catch { }
                try { this.sqldaGetDatosMediosPedidos.SelectCommand.Parameters["@dFechaFin"].Value = fecFin; }
                catch { }
               
                this.sqldaGetDatosMediosPedidos.Fill(this.dsGraphs1);

                // Valores por meses

                this.dsGraphs1.DatosPedidosMes.Rows.Clear();

                this.sqldaGetDatosPedidosMes.SelectCommand.Parameters["@iIdCliente"].Value = _iIdCliente;
                try { this.sqldaGetDatosPedidosMes.SelectCommand.Parameters["@dFechaIni"].Value = fecIni; }
                catch { }
                try { this.sqldaGetDatosPedidosMes.SelectCommand.Parameters["@dFechaFin"].Value = fecFin; }
                catch { }

                this.sqldaGetDatosPedidosMes.Fill(this.dsGraphs1);
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
            Cursor.Current = Cursors.Default;
        }

        
    }
}
