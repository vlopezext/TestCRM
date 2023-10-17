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
    public partial class frmIndicadores_2 : Form
    {
        int _iPestanyaActiva;

        const int K_TAB_ZONA = 0;
        const int K_TAB_CLIENTE = 1;

        const int K_VALOR_DIF = 15;

        const string K_TITULO = "Indicadores";

        #region constantes y variables para pestaña ventas zona

        //Columnas grid ventas zona
        const int K_COL_CODNACIONAL = 0;
        const int K_COL_NOMMAT = 1;
        const int K_COL_UNITOTAL = 2;
        const int K_COL_UNIMES = 3;
        const int K_COL_TENDENCIA = 4;
        const int K_COL_TENDENCIA_DIBU = 5;
        const int K_COL_UNIDIR = 6;
        const int K_COL_BRUTODIR = 7;
        const int K_COL_DESCDIR = 8;
        const int K_COL_UNITRANS = 9;
        const int K_COL_BRUTOTRANS = 10;
        const int K_COL_DESCTRANS = 11;
        const int K_COL_UNICLUB = 12;
        const int K_COL_BRUTOCLUB = 13;
        const int K_COL_DESCCLUB = 14;
        const int K_COL_UNIAUTO = 15;
        const int K_COL_BRUTOAUTO = 16;
        const int K_COL_DESCAUTO = 17;

        int _fila_Ventas;

        Bitmap _imgUp;
        Bitmap _imgDown;
        Bitmap _imgEqual;

        #endregion


        #region constantes y variables para pestaña datos clientes

        //Columnas grid datos cliente
        const int K_COL2_CODSAPCLIENTE = 0;
        const int K_COL2_NOMCLI = 1;
        const int K_COL2_RENTACT = 2;        // Rentabilidad año actual
        const int K_COL2_CRENTACT = 3;       // Color rentabiliadad año actual 
        const int K_COL2_PRENTACT = 4;       // Para pintar Color rentabiliadad año actual 
        const int K_COL2_RENTULTPED = 5;     // Rentabilidad último pedido
        const int K_COL2_CRENTULTPED = 6;    // Color rentabilidad último pedido
        const int K_COL2_PRENTULTPED = 7;    // Para pintar Color rentabilidad último pedido
        const int K_COL2_VACT = 8;           // Ventas año actual (dir, trans, auto)
        const int K_COL2_VANT = 9;           // Ventas año anterior
        const int K_COL2_VCACT = 10;          // Ventas + clubs año actual
        const int K_COL2_VCANT = 11;          // Ventas + clubs año anterior
        const int K_COL2_FECULTVISITA = 12;  // Fecha última visita

        bool _bGridCargado = false;
        #endregion



        public frmIndicadores_2()
        {
            InitializeComponent();

            //---- GSG (06/03/2021)
            Utiles.GetConfigConnection();
            this.sqlConn.ConnectionString = Utiles._connection.ConnectionString.ToString();

            

            _iPestanyaActiva = K_TAB_ZONA;

            initImages();
        }

        private void frmIndicadores_2_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                lblTitulo.Text = "Indicadores de zona";
                lblAvisoVersion.Text = System.Configuration.ConfigurationManager.AppSettings["AvisoVersion"].ToString(); //---- GSG (14/02/2014)

                Utiles.Formato_Formulario(this);
                if (this.Parent == null) this.WindowState = FormWindowState.Normal;

                if (this.Parent == null)
                    this.WindowState = FormWindowState.Normal;

                tabControl1.SelectedIndex = _iPestanyaActiva;

                Inicializar_Botonera();
                initTabs();
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }

            Cursor.Current = Cursors.Default;
        }

        private void Inicializar_Botonera()
        {
            try
            {
                //this.ucBotoneraSecundaria1.btEditar.Click += new EventHandler(dGVVentas_DoubleClick);
                this.ucBotoneraSecundaria1.btSalir.Click += new EventHandler(btSalir_Click);
                ucBotoneraSecundaria1.btEliminar.Enabled = false;
                ucBotoneraSecundaria1.btGrabar.Enabled = false;
                ucBotoneraSecundaria1.btNuevo.Enabled = false;
                ucBotoneraSecundaria1.btEditar.Enabled = true;
                ucBotoneraSecundaria1.btSalir.Enabled = true;
                ucBotoneraSecundaria1.btAPedido.Enabled = false;
                ucBotoneraSecundaria1.btAIndicadores.Enabled = false;
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }

        private void btSalir_Click(object sender, System.EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ev)
            {
                Mensajes.ShowError("Error en evento pcbSalir_Click: " + ev.Message);
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _iPestanyaActiva = tabControl1.SelectedIndex;
            initTabs();
        }

        private void initTabs()
        {
            Inicializar_Pestanya_Ventas();
            Inicializar_Pestanya_Cliente();
            Inicializar_Pestanya_Impagos(); //---- GSG (13/03/2019)
        }

        private void Inicializar_Pestanya_Ventas()
        {
            Inicializar_Combos_Ventas();
            Inicializar_Fechas_Ventas(DateTime.Today);
            UpdateImgTendenciaGrid(); 

            this._fila_Ventas = -1;
        }

        private void Inicializar_Pestanya_Cliente()
        {
            Inicializar_Combos_DatosClientes();
            _bGridCargado = false;
        }


        //---- GSG (13/03/2019)
        private void Inicializar_Pestanya_Impagos()
        {
            CargarDatosImpagos();
        }
        

        private void initImages()
        {
            _imgUp = Properties.Resources.upgreen.ToBitmap();
            _imgDown = Properties.Resources.downred.ToBitmap();
            _imgEqual = Properties.Resources.igual.ToBitmap();
        }


        #region ventas

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarDatosVentas();
            this._fila_Ventas = -1;
        }


        private void Inicializar_Fechas_Ventas(DateTime fecha)
        {
            try
            {
                int daysInMonth = DateTime.DaysInMonth(fecha.Year, fecha.Month);
                this.dtpFechaFin.Value = DateTime.Parse(daysInMonth.ToString() + "/" + fecha.Month.ToString() + "/" + fecha.Year.ToString());

                this.dtpFechaIni.Value = this.dtpFechaFin.Value.AddMonths(-1 * Clases.Configuracion.iMesesInformeS);

                if (dtpFechaIni.Value.Month != 12)
                    this.dtpFechaIni.Value = DateTime.Parse("01/" + (dtpFechaIni.Value.Month + 1).ToString() + "/" + dtpFechaIni.Value.Year.ToString());
                else
                    this.dtpFechaIni.Value = DateTime.Parse("01/01/" + (dtpFechaIni.Value.Year + 1).ToString());

                chkbVDir.Checked = true;
                chkbVTrans.Checked = true;
                chkbVClub.Checked = true;
                chkbAutoped.Checked = true;
            }
            catch (Exception ex)
            {
                Mensajes.ShowError(ex.Message);
            }
        }
        
        private void Inicializar_Combos_Ventas()
        {
            try
            {
                //Inicializar ComboBox cbTipoMaterial
                this.dsMateriales1.ListaTipoMaterialInforme.Clear();
                this.sqldaListaTipoMaterialInforme.Fill(this.dsMateriales1);
                DataRow fila = this.dsMateriales1.ListaTipoMaterialInforme.NewRow();
                fila["sValor"] = "-1";
                fila["sLiteral"] = "Todos";
                this.dsMateriales1.ListaTipoMaterialInforme.Rows.InsertAt(fila, 0);
                this.cbTipoMaterial.SelectedValue = "-1";

                //Inicializar combo cbCrecimiento
                DataTable tablaC = new DataTable();
                tablaC.Columns.Add("sValor");
                tablaC.Columns.Add("sLiteral");
                DataRow filaC1 = tablaC.NewRow();
                filaC1["sValor"] = "-1";
                filaC1["sLiteral"] = "Todos";
                tablaC.Rows.Add(filaC1);
                DataRow filaC2 = tablaC.NewRow();
                filaC2["sValor"] = "+";
                filaC2["sLiteral"] = "Superior a " + K_VALOR_DIF.ToString() + "%";
                tablaC.Rows.Add(filaC2);
                DataRow filaC3 = tablaC.NewRow();
                filaC3["sValor"] = "-";
                filaC3["sLiteral"] = "Inferior a -" + K_VALOR_DIF.ToString() + "%";
                tablaC.Rows.Add(filaC3);
                DataRow filaC4 = tablaC.NewRow();
                filaC4["sValor"] = "=";
                filaC4["sLiteral"] = "Entre -" + K_VALOR_DIF.ToString() + "% y " + K_VALOR_DIF.ToString() + "%";
                tablaC.Rows.Add(filaC4);
                this.cbCrecimiento.DataSource = tablaC;
                this.cbCrecimiento.ValueMember = "sValor";
                this.cbCrecimiento.DisplayMember = "sLiteral";
                this.cbCrecimiento.SelectedValue = "-1";


                //Inicializar ComboBox cbProductos
                this.dsFormularios1.ListaProductos.Clear();
                this.sqldaListaProductos.Fill(this.dsFormularios1);
                DataRow fila1 = this.dsFormularios1.ListaProductos.NewRow();
                fila1["sIdProducto"] = "-1";
                fila1["sDescripcion"] = "Todos";
                this.dsFormularios1.ListaProductos.Rows.InsertAt(fila1, 0);
                this.cbProductos.SelectedValue = "-1";


                //Inicializar combo bricks
                this.dsBuscar1.ListaBricks.Clear();
                this.sqldaListaBricks.Fill(this.dsBuscar1);
                DataRow filaTodos = this.dsBuscar1.ListaBricks.NewRow();
                filaTodos["sIdBrick"] = "T";
                filaTodos["sDescripcion"] = "Todos";
                this.dsBuscar1.ListaBricks.Rows.InsertAt(filaTodos, 0);
                this.cboDescBrick.SelectedValue = "T";
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }

        }

        private void CargarDatosVentas()
        {
            //Datos de ventas
            CargarVentas();
            UpdateImgTendenciaGrid();
        }


        private void CargarVentas()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                this.dsMateriales1.ListaInformeSZona.Rows.Clear();


                this.sqldaInformeSZona.SelectCommand.Parameters["@iIdDelegado"].Value = Convert.ToInt32(Clases.Configuracion.ValorConf(1));
                try { this.sqldaInformeSZona.SelectCommand.Parameters["@dFechaIni"].Value = DateTime.Parse(this.dtpFechaIni.Value.ToString("dd/MM/yyyy")); }
                catch { }
                try { this.sqldaInformeSZona.SelectCommand.Parameters["@dFechaFin"].Value = DateTime.Parse(this.dtpFechaFin.Value.ToString("dd/MM/yyyy")); }
                catch { }
                this.sqldaInformeSZona.SelectCommand.Parameters["@sTipoMatInformes"].Value = this.cbTipoMaterial.SelectedValue.ToString();
                if (chkbSinVentas.Checked)
                    this.sqldaInformeSZona.SelectCommand.Parameters["@iConVentas"].Value = 0;
                else
                    this.sqldaInformeSZona.SelectCommand.Parameters["@iConVentas"].Value = -1;

                if (chkbVDir.Checked)
                    this.sqldaInformeSZona.SelectCommand.Parameters["@iConVentasDir"].Value = 1;
                else
                    this.sqldaInformeSZona.SelectCommand.Parameters["@iConVentasDir"].Value = -1;
                if (chkbVTrans.Checked)
                    this.sqldaInformeSZona.SelectCommand.Parameters["@iConVentasTrans"].Value = 1;
                else
                    this.sqldaInformeSZona.SelectCommand.Parameters["@iConVentasTrans"].Value = -1;
                if (chkbAutoped.Checked)
                    this.sqldaInformeSZona.SelectCommand.Parameters["@iConVentasAutoped"].Value = 1;
                else
                    this.sqldaInformeSZona.SelectCommand.Parameters["@iConVentasAutoped"].Value = -1;
                if (chkbVClub.Checked)
                    this.sqldaInformeSZona.SelectCommand.Parameters["@iConVentasClub"].Value = 1;
                else
                    this.sqldaInformeSZona.SelectCommand.Parameters["@iConVentasClub"].Value = -1;
                if (cbCrecimiento.SelectedValue.ToString() != "-1")
                    this.sqldaInformeSZona.SelectCommand.Parameters["@sTendencia"].Value = cbCrecimiento.SelectedValue.ToString();
                else
                    this.sqldaInformeSZona.SelectCommand.Parameters["@sTendencia"].Value = null;
                this.sqldaInformeSZona.SelectCommand.Parameters["@sIdProducto"].Value = this.cbProductos.SelectedValue.ToString();
                this.sqldaInformeSZona.SelectCommand.Parameters["@sIdBrick"].Value = this.cboDescBrick.SelectedValue.ToString();

                this.sqldaInformeSZona.Fill(this.dsMateriales1);


                this.lblNumReg.Text = this.dsMateriales1.ListaInformeSZona.Rows.Count.ToString();

            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
            Cursor.Current = Cursors.Default;
        }

        private void dtpFechaIni_ValueChanged(object sender, EventArgs e)
        {
            //El primer día del mes siempre
            this.dtpFechaIni.Value = DateTime.Parse("01/" + dtpFechaIni.Value.Month.ToString() + "/" + dtpFechaIni.Value.Year.ToString());
        }

        private void dtpFechaFin_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFechaFin.Text != "" && dtpFechaFin.Text != null)
                Inicializar_Fechas_Ventas(DateTime.Parse(dtpFechaFin.Text));
        }

        private void UpdateImgTendenciaGrid()
        {
            foreach (DataGridViewRow row in dGVVentas.Rows)
            {
                if (row.Cells[K_COL_TENDENCIA].Value.ToString() == "=")
                    row.Cells[K_COL_TENDENCIA_DIBU].Value = _imgEqual;
                else if (row.Cells[K_COL_TENDENCIA].Value.ToString() == "+")
                    row.Cells[K_COL_TENDENCIA_DIBU].Value = _imgUp;
                else if (row.Cells[K_COL_TENDENCIA].Value.ToString() == "-")
                    row.Cells[K_COL_TENDENCIA_DIBU].Value = _imgDown;
                else
                    row.Cells[K_COL_TENDENCIA_DIBU].Value = _imgEqual;
            }
        }

        private void chkbVDir_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbVDir.Checked)
                chkbSinVentas.Checked = false;
        }

        private void chkbVTrans_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbVTrans.Checked)
                chkbSinVentas.Checked = false;
        }

        private void chkbVClub_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbVClub.Checked)
                chkbSinVentas.Checked = false;
        }

        private void chkbAutoped_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbAutoped.Checked)
                chkbSinVentas.Checked = false;
        }

        private void chkbSinVentas_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbSinVentas.Checked)
            {
                chkbVClub.Checked = false;
                chkbVTrans.Checked = false;
                chkbVDir.Checked = false;
                chkbAutoped.Checked = false;
            }
        }

        private void dGVVentas_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            UpdateImgTendenciaGrid();
            this._fila_Ventas = -1;
        }

        #endregion

        #region datos cliente

        private void btnBuscar2_Click(object sender, EventArgs e)
        {
            string rentabilidad = cbRentabilidad.SelectedValue.ToString();
            if (rentabilidad == "-1")
                rentabilidad = null;

            if (!_bGridCargado)
            {
                CargarDatosCliente(rentabilidad);
                _bGridCargado = true;
            }
            else
            {
                string filtro = "";

                if (rentabilidad == null)
                    filtro = "1 = 1";
                else
                    filtro = "sColorRentAnyoAct = '" + rentabilidad + "'";

                string nombreFcia = txtbNombreFcia.Text.Trim();
                if (nombreFcia != "")
                    filtro += " and sNombre like '%" + nombreFcia + "%'";


                this.dsFormularios1.DatosGlobalesByCliente.DefaultView.RowFilter = filtro;
                dGVDatosClis.DataSource = this.dsFormularios1.DatosGlobalesByCliente.DefaultView;

                lblNumReg2.Text = this.dsFormularios1.DatosGlobalesByCliente.DefaultView.Count.ToString();
            }
            
            UpdateColorRentabilidadGrid();
        }


        private void CargarDatosCliente(string rentabilidad)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                this.dsFormularios1.DatosGlobalesByCliente.Rows.Clear();

                this.sqldaDatosClientes.SelectCommand.CommandTimeout = 60000;

                this.sqldaDatosClientes.SelectCommand.Parameters["@iIdCliente"].Value = -1;
                this.sqldaDatosClientes.SelectCommand.Parameters["@rentabilidad"].Value = rentabilidad;
                this.sqldaDatosClientes.Fill(this.dsFormularios1);

                this.lblNumReg2.Text = this.dsFormularios1.DatosGlobalesByCliente.Rows.Count.ToString();

            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
            Cursor.Current = Cursors.Default;
        }


        private void UpdateColorRentabilidadGrid()
        {
            foreach (DataGridViewRow row in dGVDatosClis.Rows)
            {
                if (row.Cells[K_COL2_CRENTACT].Value.ToString() != "")
                    row.Cells[K_COL2_PRENTACT].Style.BackColor = Color.FromName(row.Cells[K_COL2_CRENTACT].Value.ToString());
                if (row.Cells[K_COL2_CRENTULTPED].Value.ToString() != "")
                row.Cells[K_COL2_PRENTULTPED].Style.BackColor = Color.FromName(row.Cells[K_COL2_CRENTULTPED].Value.ToString());
            }
        }

        

        private void dGVDatosClis_Sorted(object sender, EventArgs e)
        {
            UpdateColorRentabilidadGrid();
        }



        private void Inicializar_Combos_DatosClientes()
        {
            try
            {
                //Inicializar ComboBox cbRentabilidad
                this.dsFormularios1.ListaTramosRentabilidad.Rows.Clear();
                this.sqldaTramosRentabilidad.SelectCommand.Parameters["@fecha"].Value = DateTime.Today; //---- GSG (11/11/2014)
                this.sqldaTramosRentabilidad.Fill(this.dsFormularios1);
                DataRow fila = this.dsFormularios1.ListaTramosRentabilidad.NewRow();
                fila["idTramo"] = "-1";
                fila["fValMinTramo"] = 0;
                fila["fValMaxTramo"] = 0;
                fila["sDescripcion"] = "Todos";
                fila["sColor"] = "-1";
                this.dsFormularios1.ListaTramosRentabilidad.Rows.InsertAt(fila, 0);
                this.cbRentabilidad.SelectedValue = "-1";
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }

        }

        #endregion


        //---- GSG (13/03/2019)
        #region Impagos

        private void CargarDatosImpagos()
        {
            Cursor.Current = Cursors.WaitCursor;

            CargarDatosImpagosCli();

            Cursor.Current = Cursors.Default;
        }


        private bool CargarDatosImpagosCli()
        {
            bool bRet = true;

            try
            {
                this.dsClientes.ListaImpagos.Rows.Clear();

                this.sqldaListaImpagos.SelectCommand.Parameters["@iIdDelegado"].Value = Clases.Configuracion.iIdDelegado;
                this.sqldaListaImpagos.SelectCommand.Parameters["@iIdCliente"].Value = -1;


                this.sqldaListaImpagos.Fill(this.dsClientes);

                this.lblNumImpagos.Text = this.dsClientes.ListaImpagos.Rows.Count.ToString();
            }
            catch (Exception ex) { bRet = false; Mensajes.ShowError(ex.Message); }

            return bRet;
        }

        #endregion
    }
}
