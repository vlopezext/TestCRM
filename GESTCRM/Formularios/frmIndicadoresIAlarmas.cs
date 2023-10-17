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
    public partial class frmIndicadoresIAlarmas : Form
    {
        int _iIdCliente;
        int _iPestanyaActiva;

        const int K_TAB_ALARMAS = 0;
        const int K_TAB_VENTAS = 1;
        const int K_TAB_CLIENTE = 2;

        const int K_VALOR_DIF = 15;

        const string K_TITULO = "Indicadores y Alarmas del cliente";

        //---- GSG (08/03/2018)
        private const string K_CAMP_MIXABC = "32";  //Campaña Cliente MixABC para GX
        private const string K_CAMP_DA = "229";     //Campaña DESCUENTOS AUTORIZADOS para CH
        private const string K_GX = "GX";
        private const string K_CH = "CH";
        private const int K_POS_COD = 0;
        private const int K_POS_UNI = 1;
        private const int K_POS_DTO = 2;
        private const string K_LIN = "LIN";
        List<string[]> _propuesta = new List<string[]>();
        private bool _bEsClienteConAccMark = false;


        #region constantes y variables para pestaña ventas

        //Columnas grid ventas
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

        //---- GSG (01/04/2014)
        Bitmap _imgUp;
        Bitmap _imgDown;
        Bitmap _imgEqual;

        #endregion

        #region constantes y variables para pestaña alarmas

        //Columnas grid alarmas
        const int K_COLA_IDMATERIAL = 0;
        const int K_COLA_CODNACIONAL = 1;
        const int K_COLA_NOMMAT = 2;
        const int K_COLA_MHIST = 3;
        const int K_COLA_MTRIM = 4;
        const int K_COLA_DIFF = 5;
        const int K_COLA_BCANT = 6;
        const int K_COLA_BDESC = 7;
        
        int _fila_Alarmas;
        #endregion

        #region constantes y variables para pestaña clientes
        
        private const int K_TOP_RANKING = 5;
        
        #endregion


        public frmIndicadoresIAlarmas()
        {
            InitializeComponent();

            //---- GSG (06/03/2021)
            Utiles.GetConfigConnection();
            this.sqlConn.ConnectionString = Utiles._connection.ConnectionString.ToString();

            
            _iPestanyaActiva = K_TAB_ALARMAS;
            _iIdCliente = -1;

            //---- GSG (01/04/2014)
            initImages();
        }

        public frmIndicadoresIAlarmas(int pestanya, int cliente, string codSAP, string nombreCliente)
        {
            InitializeComponent();

            //---- GSG (06/03/2021)
            Utiles.GetConfigConnection();
            this.sqlConn.ConnectionString = Utiles._connection.ConnectionString.ToString();

            
            _iPestanyaActiva = pestanya;
            _iIdCliente = cliente;
            this.txtsIdCliente.Text = codSAP;
            this.txtsCliente.Text = nombreCliente;

            //---- GSG (01/04/2014)
            initImages();
        }

        private void frmIndicadoresIAlarmas_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                lblTitulo.Text = "Indicadores y Alarmas del cliente";
                lblAvisoVersion.Text = System.Configuration.ConfigurationManager.AppSettings["AvisoVersion"].ToString(); //---- GSG (14/02/2014)

                Utiles.Formato_Formulario(this);
                if (this.Parent == null) this.WindowState = FormWindowState.Normal;

                if (this.Parent == null)
                    this.WindowState = FormWindowState.Normal;

                tabControl1.SelectedIndex = _iPestanyaActiva;

                Inicializar_Botonera();
                initTabs();

                if (_iIdCliente != -1) //Viene de otro formulario
                    GetResultadoBuscar();

                chkbMasClub.Checked = false;
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }

            Cursor.Current = Cursors.Default;
        }

        private void Inicializar_Botonera()
        {
            try
            {
                this.ucBotoneraSecundaria1.btEditar.Click += new EventHandler(dGVVentas_DoubleClick);
                this.ucBotoneraSecundaria1.btSalir.Click += new EventHandler(btSalir_Click);
                ucBotoneraSecundaria1.btEliminar.Enabled = false;
                ucBotoneraSecundaria1.btGrabar.Enabled = false;
                ucBotoneraSecundaria1.btNuevo.Enabled = false;
                ucBotoneraSecundaria1.btEditar.Enabled = true;
                ucBotoneraSecundaria1.btSalir.Enabled = true;
                //---- GSG (02/04/2014)
                ucBotoneraSecundaria1.btAPedido.Click += new EventHandler(btAPedido_Click);
                ucBotoneraSecundaria1.btAPedido.Enabled = true;
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


        private void btAPedido_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (GESTCRM.Utiles.MirarSiAbierto(GESTCRM.Formularios.frmPedidos.ActiveForm, "frmPedidos"))
                {
                    GESTCRM.Utiles.ActivaFormularioAbierto("frmPedidos", this.MdiParent);
                }
                else
                {
                    //---- GSG (11/04/2014)
                    //Mensajes.ShowInformation("No hay ningún pedido abierto.");
                    Form frmTemp = new Formularios.frmPedidos();
                    frmTemp.MdiParent = this.MdiParent;
                    frmTemp.Show();	
                }
            }
            catch (Exception ev)
            {
                Mensajes.ShowError("Error en evento btAPedido_Click: " + ev.Message);
            }
        }


        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _iPestanyaActiva = tabControl1.SelectedIndex;
            initTabs();
        }

        private void initTabs()
        {
            Inicializar_Pestanya_Alarmas();
            Inicializar_Pestanya_Ventas();
            Inicializar_Pestanya_Cliente();
            Inicializar_Pestanya_AccMark();
        }

        private void Inicializar_Clubs()
        {
            //Datos clubs
            string[] clubs = new string[5];

            clubs = CargarClubs();

            txtGarantias.Text = clubs[0];
            txtGarantias1.Text = clubs[1];
            txtGarantias2.Text = clubs[2];
            txtGarantias3.Text = clubs[3];
            txtGarantias4.Text = clubs[4];
        }

        private void click_en_grid()
        {
            try
            {
                if (_iPestanyaActiva == K_TAB_ALARMAS)
                {
                    this._fila_Alarmas = this.dGVAlarmas.CurrentRow.Index;

                    if (_fila_Alarmas != -1)
                    {
                        string sCodNacional = dGVAlarmas.Rows[_fila_Alarmas].Cells[K_COLA_CODNACIONAL].Value.ToString();
                        string sMaterial = dGVAlarmas.Rows[_fila_Alarmas].Cells[K_COLA_NOMMAT].Value.ToString();

                        Form frmTemp = new Formularios.frmGraphVentasProdFcia(this.dtpFechaIniAlarma.Value, this.dtpFechaFinAlarma.Value, this._iIdCliente, sCodNacional, sMaterial);
                        frmTemp.ShowDialog();
                    }
                }
                else if (_iPestanyaActiva == K_TAB_VENTAS)
                {
                    this._fila_Ventas = this.dGVVentas.CurrentRow.Index;

                    if (_fila_Ventas != -1)
                    {
                        int iTotalUnidades = 0;
                        if (dGVVentas.Rows[_fila_Ventas].Cells[K_COL_UNITOTAL].Value.ToString() != "")
                            iTotalUnidades = int.Parse(dGVVentas.Rows[_fila_Ventas].Cells[K_COL_UNITOTAL].Value.ToString());

                        if (iTotalUnidades != 0)
                        {
                            string sCodNacional = dGVVentas.Rows[_fila_Ventas].Cells[K_COL_CODNACIONAL].Value.ToString();
                            string sMaterial = dGVVentas.Rows[_fila_Ventas].Cells[K_COL_NOMMAT].Value.ToString();

                            Form frmTemp = new Formularios.frmGraphVentasProdFcia(this.dtpFechaIni.Value, this.dtpFechaFin.Value, this._iIdCliente, sCodNacional, sMaterial);
                            frmTemp.ShowDialog();
                        }
                        else
                        {
                            GESTCRM.Mensajes.ShowInformation("El material seleccionado no tiene ventas.");
                        }
                    }
                }
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }

        private void btBuscarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                GESTCRM.Formularios.Busquedas.frmMClientesSAP frmBCli = new GESTCRM.Formularios.Busquedas.frmMClientesSAP(false, "A");

                frmBCli.ParamIO_sIdCliente = "";
                frmBCli.ParamI_sIdCentro = "";
                frmBCli.ParamI_sIdTipoCliente = "S";
                frmBCli.ParamI_iIdDelegado = Clases.Configuracion.iIdDelegado;

                frmBCli.ShowDialog(this);
                if (frmBCli.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    if (frmBCli.dtSeleccion.Rows.Count == 0)
                    {
                        this.txtsIdCliente.Text = frmBCli.ParamIO_sIdCliente;
                        this.txtsCliente.Text = frmBCli.ParamO_tNombre;
                        this._iIdCliente = frmBCli.ParamO_iIdCliente;
                    }
                }
                frmBCli.Dispose();
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }

        private void Inicializar_Pestanya_Alarmas()
        {
            //Porque las necesita para las gráficas
            Inicializar_Fechas_Alarmas(DateTime.Today);
           
            this._fila_Alarmas = -1;
        }

        private void Inicializar_Pestanya_Ventas()
        {
            Inicializar_Combos_Ventas();
            Inicializar_Fechas_Ventas(DateTime.Today);
            UpdateImgTendenciaGrid(); //---- GSG (01/04/2014)

            this._fila_Ventas = -1;
        }

        private void Inicializar_Pestanya_Cliente()
        {
        }

        //---- GSG (06/10/2015)
        private void Inicializar_Pestanya_AccMark()
        {
            pintaGridAccMarkCli();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            GetResultadoBuscar();
        }

        private void GetResultadoBuscar()
        {
            lblTitulo.Text = K_TITULO + " " + txtsCliente.Text;

            if (this._iIdCliente != -1)
            {
                

                CargarDatosAlarmas();
                this._fila_Alarmas = -1;

                CargarDatosVentas();
                this._fila_Ventas = -1;

    
                CargarDatosCliente();
    

                CargarDatosAccMark(); //---- GSG (06/10/2015)


                CargarDatosImpagos(); //---- GSG (13/03/2019)
                

                Inicializar_Clubs();

                //---- GSG (02/04/2014)
                int anyo = DateTime.Today.Year;
                txtCompraAnyoAnt.Text = CargaVentasAnuales(_iIdCliente, anyo-1).ToString("N2");
                txtCompraAnyoAct.Text = CargaVentasAnuales(_iIdCliente, anyo).ToString("N2");

                //---- GSG (04/06/2014)
                txtCompraAnyoAntClubs.Text = CargaVentasAnualesMasClubs(_iIdCliente, anyo-1).ToString("N2");
                txtCompraAnyoActClubs.Text = CargaVentasAnualesMasClubs(_iIdCliente, anyo).ToString("N2");
            }
            else
                Mensajes.ShowInformation("No se ha indicado el cliente. Seleccione un cliente e inténtelo de nuevo.");
        }

        //---- GSG (01/04/2014)
        private void initImages()
        {
            _imgUp = Properties.Resources.upgreen.ToBitmap();
            _imgDown = Properties.Resources.downred.ToBitmap();
            _imgEqual = Properties.Resources.igual.ToBitmap();
        }

        #region alarmas

        private void Inicializar_Fechas_Alarmas(DateTime fecha)
        {
            try
            {
                int daysInMonth = DateTime.DaysInMonth(fecha.Year, fecha.Month);
                this.dtpFechaFinAlarma.Value = DateTime.Parse(daysInMonth.ToString() + "/" + fecha.Month.ToString() + "/" + fecha.Year.ToString());

                this.dtpFechaIniAlarma.Value = this.dtpFechaFinAlarma.Value.AddMonths(-1 * Clases.Configuracion.iMesesInformeS);

                if (dtpFechaIniAlarma.Value.Month != 12)
                    this.dtpFechaIniAlarma.Value = DateTime.Parse("01/" + (dtpFechaIniAlarma.Value.Month + 1).ToString() + "/" + dtpFechaIniAlarma.Value.Year.ToString());
                else
                    this.dtpFechaIniAlarma.Value = DateTime.Parse("01/01/" + (dtpFechaIniAlarma.Value.Year + 1).ToString());
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }


        private void CargarDatosAlarmas()
        {
            CargarAlarmas();
        }

        private void CargarAlarmas()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                this.dsMateriales1.ListaAlarmas.Rows.Clear();

                this.sqldaAlarmas.SelectCommand.Parameters["@iIdCliente"].Value = this._iIdCliente;
                this.sqldaAlarmas.Fill(this.dsMateriales1);

                //sólo top N
                int numVer = 10;
                try
                {
                    numVer = int.Parse(txtbNumVer.Text);
                }
                catch(Exception e)
                {
                    numVer = 10;
                    txtbNumVer.Text = "10";
                }

                this.dGVAlarmas.DataSource = this.dsMateriales1.ListaAlarmas;

                if (this.dsMateriales1.ListaAlarmas.Rows.Count > 0)
                {
                    var records = this.dsMateriales1.ListaAlarmas.AsEnumerable().Take(numVer).CopyToDataTable();
                    this.dGVAlarmas.DataSource = records;
                }
                

                if (int.Parse(this.txtbNumVer.Text) <= this.dsMateriales1.ListaAlarmas.Rows.Count)
                    this.lblNumRegAlarmas.Text = this.txtbNumVer.Text + " / " + this.dsMateriales1.ListaAlarmas.Rows.Count.ToString();
                else
                    this.lblNumRegAlarmas.Text = this.dsMateriales1.ListaAlarmas.Rows.Count.ToString();

            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
            Cursor.Current = Cursors.Default;
        }


        private void btnBuscarAlarmas_Click(object sender, EventArgs e)
        {
            //if (this._iIdCliente != -1)
            //{
            //    CargarDatosAlarmas();
            //    this._fila_Alarmas = -1;
            //}
            //else
            //    Mensajes.ShowInformation("No se ha indicado el cliente. Seleccione un cliente e inténtelo de nuevo.");
        }


        private void dGVAlarmas_DoubleClick(object sender, EventArgs e)
        {
            click_en_grid();
        }

        #endregion


        #region ventas

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

                //---- GSG (01/04/2014)
                chkbVDir.Checked = true;
                chkbVTrans.Checked = true;
                chkbVClub.Checked = true;
                chkbAutoped.Checked = true;
                //---- GSG (12/07/2017)
                chkbAbono.Checked = true;
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
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }

        }

        
        private void CargarDatosVentas()
        {
            //Datos de ventas
            CargarVentas();
            UpdateImgTendenciaGrid(); //---- GSG (01/04/2014)
        }

        private void CargarVentas()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                this.dsMateriales1.ListaInformeS.Rows.Clear();


                this.sqldaInformeS.SelectCommand.Parameters["@iIdCliente"].Value = this._iIdCliente;
                try { this.sqldaInformeS.SelectCommand.Parameters["@dFechaIni"].Value = DateTime.Parse(this.dtpFechaIni.Value.ToString("dd/MM/yyyy")); }
                catch { }
                try { this.sqldaInformeS.SelectCommand.Parameters["@dFechaFin"].Value = DateTime.Parse(this.dtpFechaFin.Value.ToString("dd/MM/yyyy")); }
                catch { }
                this.sqldaInformeS.SelectCommand.Parameters["@sTipoMatInformes"].Value = this.cbTipoMaterial.SelectedValue.ToString();
                //---- GSG (14/04/2014)
                //this.sqldaInformeS.SelectCommand.Parameters["@iConVentas"].Value = -1;
                if (chkbSinVentas.Checked)
                    this.sqldaInformeS.SelectCommand.Parameters["@iConVentas"].Value = 0;
                else
                    this.sqldaInformeS.SelectCommand.Parameters["@iConVentas"].Value = -1;
                
                if (chkbVDir.Checked)
                    this.sqldaInformeS.SelectCommand.Parameters["@iConVentasDir"].Value = 1;
                else
                    this.sqldaInformeS.SelectCommand.Parameters["@iConVentasDir"].Value = -1;
                if (chkbVTrans.Checked)
                    this.sqldaInformeS.SelectCommand.Parameters["@iConVentasTrans"].Value = 1;
                else
                    this.sqldaInformeS.SelectCommand.Parameters["@iConVentasTrans"].Value = -1;
                if (chkbAutoped.Checked)
                    this.sqldaInformeS.SelectCommand.Parameters["@iConVentasAutoped"].Value = 1;
                else
                    this.sqldaInformeS.SelectCommand.Parameters["@iConVentasAutoped"].Value = -1;
                if (chkbVClub.Checked)
                    this.sqldaInformeS.SelectCommand.Parameters["@iConVentasClub"].Value = 1;
                else
                    this.sqldaInformeS.SelectCommand.Parameters["@iConVentasClub"].Value = -1;
                //---- GSG (12/07/2017)
                if (chkbAbono.Checked)
                    this.sqldaInformeS.SelectCommand.Parameters["@iConAbono"].Value = 1;
                else
                    this.sqldaInformeS.SelectCommand.Parameters["@iConAbono"].Value = -1;

                if (cbCrecimiento.SelectedValue.ToString() != "-1")
                    this.sqldaInformeS.SelectCommand.Parameters["@sTendencia"].Value = cbCrecimiento.SelectedValue.ToString();
                else
                    this.sqldaInformeS.SelectCommand.Parameters["@sTendencia"].Value = null;


                this.sqldaInformeS.Fill(this.dsMateriales1);


                this.lblNumReg.Text = this.dsMateriales1.ListaInformeS.Rows.Count.ToString();

            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
            Cursor.Current = Cursors.Default;
        }

        private string[] CargarClubs()
        {
            return Utiles.GetClubsCliente(_iIdCliente);
        }

        private void dGVVentas_DoubleClick(object sender, EventArgs e)
        {
            click_en_grid();
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

        private void btReloadVentas_Click(object sender, EventArgs e)
        {
            CargarDatosVentas();
            this._fila_Ventas = -1;
        }

        //---- GSG (01/04/2014)
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


        //---- GSG (14/04/2014)
        private void chkbSinVentas_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbSinVentas.Checked)
            {
                chkbVClub.Checked = false;
                chkbVTrans.Checked = false;
                chkbVDir.Checked = false;
                chkbAutoped.Checked = false;
                //---- GSG (12/07/2017)
                chkbAbono.Checked = false;
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

        //---- GSG (12/07/2017)
        private void chkbAbono_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbAbono.Checked)
                chkbSinVentas.Checked = false;
        }

        private void dGVVentas_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            UpdateImgTendenciaGrid();
            this._fila_Ventas = -1;
        }
        #endregion


        #region cliente

        private void CargarDatosCliente()
        {
            try
            {
                pintaRentabilidadAnual(_iIdCliente);
                pintaRentabilidadUltimoPedido(_iIdCliente);  // És la que dona el TimeOut a l'ordinador de l'Antoni Martí

                ////////////////////GraphUltimasVentas(_iIdCliente);
                GraphVentasPorPedidoYCanalBarras(_iIdCliente);

                GraphVentasPorPedidoYCanal(_iIdCliente);
                

                GraphsRanking(_iIdCliente);
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }



        #region rentabilidad 
        private void pintaRentabilidadAnual(int iIdCliente)
        {
            float rentAnual = Calcular_Rentabilidad_Anual(iIdCliente);
            txtRentAA.BackColor = CalcularColorRentabilidad(rentAnual, DateTime.Today); //---- GSG (11/11/2014) Añade fecha
        }

        private void pintaRentabilidadUltimoPedido(int iIdCliente)
        {
            txtRentUP.BackColor = GetColorUltPedCli(iIdCliente);
        }

        private float Calcular_Rentabilidad_Anual(int iIdCliente)
        {
            float rentabilitat = 0.0F;
            float denominador = 0.0F;
            float brutoLinsArrastre = 0.0F; //---- GSG (22/01/2015)

            //Obtener datos 
            dtLineasPedidoRentAnual = new dsMateriales.ListaLineasPedidoRentAnualDataTable();
            dsMateriales1.ListaLineasPedidoRentAnual.Rows.Clear();
            sqldaListaLineasPedidoRentAnual.SelectCommand.Parameters["@iIdCliente"].Value = iIdCliente;
            Application.DoEvents();
            sqldaListaLineasPedidoRentAnual.Fill(dtLineasPedidoRentAnual);
            Application.DoEvents();


            //Calclular rentabilidad
            //dtLineasPedidoRentAnual contiene todas las líneas a tener en cuenta (la consulta ya ha excluido las que no, también las de arrastre)
            for (int i = 0; i < dtLineasPedidoRentAnual.Rows.Count; i++)
            {
                int iCantidad = int.Parse(dtLineasPedidoRentAnual.Rows[i]["iCantidad"].ToString());
                float fPrecio = float.Parse(dtLineasPedidoRentAnual.Rows[i]["PrecioUnitario"].ToString());
                float fDescuento = float.Parse(dtLineasPedidoRentAnual.Rows[i]["fDescuento"].ToString());
                float fCoste = -1;
                if (dtLineasPedidoRentAnual.Rows[i]["fCoste"] != DBNull.Value)
                    fCoste = float.Parse(dtLineasPedidoRentAnual.Rows[i]["fCoste"].ToString());
                float fDescCab = float.Parse(dtLineasPedidoRentAnual.Rows[i]["fDescCab"].ToString());

                //Tenemos en cuenta el descuento de cabecera (fDescCab)
                rentabilitat += DameNominadorRentabilidad(iCantidad, fPrecio, fDescuento + fDescCab, fCoste);
                denominador += DameDenominadorRentabilidad(iCantidad, fPrecio);

            }

            //---- GSG (22/01/2015) Líneas pertenecientes a campañas arrastre (Ej. POLIMEDICADOS VENTA)
            dtLineasPedidoRentAnualArrastre = new dsMateriales.ListaLineasPedidoRentAnualArrastreDataTable();
            dsMateriales1.ListaLineasPedidoRentAnualArrastre.Rows.Clear();
            sqldaListaLineasPedidoRentAnualArrastre.SelectCommand.Parameters["@iIdCliente"].Value = iIdCliente;
            Application.DoEvents();
            sqldaListaLineasPedidoRentAnualArrastre.Fill(dtLineasPedidoRentAnualArrastre);
            Application.DoEvents();

            for (int i = 0; i < dtLineasPedidoRentAnualArrastre.Rows.Count; i++)
            {
                int iCantidad = int.Parse(dtLineasPedidoRentAnualArrastre.Rows[i]["iCantidad"].ToString());
                float fPrecio = float.Parse(dtLineasPedidoRentAnualArrastre.Rows[i]["PrecioUnitario"].ToString());

                brutoLinsArrastre += (iCantidad * fPrecio);
            }



            float res = 0.0F;
            if (denominador != 0)   //Aquest cas donaria -Infinity 
                //res = (rentabilitat / denominador) * 100.0F;
                res = ((rentabilitat - brutoLinsArrastre) / denominador) * 100.0F; //---- GSG (22/01/2015)

            return res;
        }

        private float DameNominadorRentabilidad(int iCantidad, float fPrecio, float fDescuento, float fCoste)
        {
            float fRentabilidad = 0.0F;
            float preu = (float)iCantidad * fPrecio;

            if (preu != 0)
            {
                if (fCoste != -1)
                {
                    float desc = preu * (fDescuento / 100.0F);
                    float ret = preu - desc - (iCantidad * fCoste);

                    fRentabilidad = ret;
                }
                else
                    fRentabilidad = preu - (preu * (fDescuento / 100.0F));
            }
            else
            {
                fRentabilidad = preu - (iCantidad * fCoste); // 0 - x = sempre negatiu
            }
            return fRentabilidad;
        }

        private float DameDenominadorRentabilidad(int iCantidad, float fPrecio)
        {
            return (float)iCantidad * fPrecio;
        }

        //---- GSG (11/11/2014) Añade fecha
        private Color CalcularColorRentabilidad(float Rentabilidad, DateTime fecha)
        {
            string sColor = "White";

            dsPedidos1.GetRentabilidadColor.Clear();
            sqlCmdGetRentabilidadColor.Parameters["@Rentabilidad"].Value = Rentabilidad;
            sqlCmdGetRentabilidadColor.Parameters["@fecha"].Value = fecha;

            using (SqlDataAdapter oDa = new SqlDataAdapter(sqlCmdGetRentabilidadColor))
            {
                oDa.Fill(dsPedidos1.GetRentabilidadColor);
            }

            if (dsPedidos1.GetRentabilidadColor != null && dsPedidos1.GetRentabilidadColor.Rows.Count > 0)
            {
                sColor = dsPedidos1.GetRentabilidadColor.Rows[0]["Color"].ToString();
            }

            return Color.FromName(sColor);
        }

        private Color GetColorUltPedCli(int iIdCliente)
        {
            string sColor = "White";

            dsPedidos1.GetRentUltPedCli.Clear();
            sqlCmdGetRentUltPedCli.Parameters["@iIdCliente"].Value = iIdCliente;

            using (SqlDataAdapter oDa = new SqlDataAdapter(sqlCmdGetRentUltPedCli))
            {
                oDa.Fill(dsPedidos1.GetRentUltPedCli);
            }

            if (dsPedidos1.GetRentUltPedCli != null && dsPedidos1.GetRentUltPedCli.Rows.Count > 0)
            {
                sColor = dsPedidos1.GetRentUltPedCli.Rows[0]["sColorRentabilidad"].ToString();
            }

            return Color.FromName(sColor);
        }

        #endregion
        
        #region ventas anuales
        //---- GSG (02/04/2014)
        private double CargaVentasAnuales(int iIdCliente, int anyo)
        {
            DateTime fecIni = DateTime.Parse("01/01/" + anyo.ToString());
            DateTime fecFin = DateTime.Parse("31/12/" + anyo.ToString());

            CargarDatosUltimasVentas(iIdCliente, fecIni, fecFin);
            if (dsGraphs1.ImporteVentasFcia.Rows[0][0].ToString() != "")
                return double.Parse(dsGraphs1.ImporteVentasFcia.Rows[0][0].ToString());
            else
                return 0;
        }
       
        //---- GSG (04/06/2014)
        private double CargaVentasAnualesMasClubs(int iIdCliente, int anyo)
        {
            DateTime fecIni = DateTime.Parse("01/01/" + anyo.ToString());
            DateTime fecFin = DateTime.Parse("31/12/" + anyo.ToString());

            CargarDatosUltimasVentasMasClubs(iIdCliente, fecIni, fecFin);
            if (dsGraphs1.ImporteVentasFciaMasClubs.Rows.Count > 0 && dsGraphs1.ImporteVentasFciaMasClubs.Rows[0][0].ToString() != "")
                return double.Parse(dsGraphs1.ImporteVentasFciaMasClubs.Rows[0][0].ToString());
            else
                return 0;
        }
        

        #endregion

        #region gráficas ventas

        #region Ultimas Ventas
        private void GraphUltimasVentas(int iIdCliente)
        {
            DateTime oFecIni;
            DateTime oFecFin;

            SetFechasGraphVentas(out oFecIni, out oFecFin);

            int mesIni = oFecIni.Month;
            int anyIni = oFecIni.Year;
            int mesFin = oFecFin.Month;
            int anyFin = oFecFin.Year;
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

            double[] yVals_1 = new double[iItems]; //qty

            DateTime fecIni;
            DateTime fecFin;

            mesIni = oFecIni.Month;
            anyIni = oFecIni.Year;

            for (int i = 0; i < iItems; i++)
            {
                fecIni = DateTime.Parse("01/" + mesIni.ToString() + "/" + anyIni.ToString());
                fecFin = DateTime.Parse(DateTime.DaysInMonth(anyIni, mesIni).ToString() + "/" + mesIni.ToString() + "/" + anyIni.ToString());

                CargarDatosUltimasVentas(iIdCliente, fecIni, fecFin);

                if (mesIni == 12)
                {
                    mesIni = 1;
                    anyIni += 1;
                }
                else
                    mesIni += 1;

                if (dsGraphs1.ImporteVentasFcia.Rows.Count > 0 && dsGraphs1.ImporteVentasFcia.Rows[0][0].ToString() != "")
                    yVals_1[i] = double.Parse(dsGraphs1.ImporteVentasFcia.Rows[0][0].ToString());
                else
                    yVals_1[i] = 0;
            }

            chartImporteVentas.Series[0].Points.DataBindXY(xVals, yVals_1); //Serie barras verticales
            chartImporteVentas.ChartAreas[0].AxisX.Interval = 1;

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


            chartImporteVentas.Series[1].Points.DataBindXY(xValsMedia, yValsMedia); //Serie línea de media
            chartImporteVentas.Series[1].LegendText = "Media/Mes: " + media.ToString("N2") + " €";


            //Cálculo de la media por pedido //---- GSG (02/04/2014)

            string[] xValsMediaPedido = new string[iItems];
            for (int i = 0; i < iItems; i++)
                xValsMediaPedido[i] = xVals[i];

            fecIni = DateTime.Parse("01/" + oFecIni.Month.ToString() + "/" + oFecIni.Year.ToString());
            fecFin = DateTime.Parse(DateTime.DaysInMonth(oFecFin.Year, oFecFin.Month).ToString() + "/" + oFecFin.Month.ToString() + "/" + oFecFin.Year.ToString());

            int numpeds = ObtenerNumPedidos(fecIni, fecFin);

            double totalImportes = 0;

            for (int i = 0; i < iItems; i++)
            {
                totalImportes += yVals_1[i];
            }

            double mediaPedido = 0.0;

            if (numpeds > 0)
                mediaPedido = totalImportes / numpeds;


            double[] yValsMediaPedido = new double[iItems];
            for (int i = 0; i < iItems; i++)
                yValsMediaPedido[i] = mediaPedido;


            chartImporteVentas.Series[2].Points.DataBindXY(xValsMediaPedido, yValsMediaPedido); //Serie línea de media pedido
            chartImporteVentas.Series[2].LegendText = "Media/Pedido: " + mediaPedido.ToString("N2") + " €";
        }

        private void CargarDatosUltimasVentas(int iIdCliente, DateTime fecIni, DateTime fecFin)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                this.dsGraphs1.ImporteVentasFcia.Rows.Clear();

                this.sqldaGetImporteVentas.SelectCommand.Parameters["@iIdCliente"].Value = iIdCliente;
                try { this.sqldaGetImporteVentas.SelectCommand.Parameters["@dFechaIni"].Value = fecIni; }
                catch { }
                try { this.sqldaGetImporteVentas.SelectCommand.Parameters["@dFechaFin"].Value = fecFin; }
                catch { }
                this.sqldaGetImporteVentas.SelectCommand.Parameters["@sCodNacional"].Value = null;

                this.sqldaGetImporteVentas.Fill(this.dsGraphs1);

            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
            Cursor.Current = Cursors.Default;
        }

        //---- GSG (04/06/2014)
        private void CargarDatosUltimasVentasMasClubs(int iIdCliente, DateTime fecIni, DateTime fecFin)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                this.dsGraphs1.ImporteVentasFciaMasClubs.Rows.Clear();

                this.sqldaGetImporteVentasMasClubs.SelectCommand.Parameters["@iIdCliente"].Value = iIdCliente;
                try { this.sqldaGetImporteVentasMasClubs.SelectCommand.Parameters["@dFechaIni"].Value = fecIni; }
                catch { }
                try { this.sqldaGetImporteVentasMasClubs.SelectCommand.Parameters["@dFechaFin"].Value = fecFin; }
                catch { }
                this.sqldaGetImporteVentasMasClubs.SelectCommand.Parameters["@sCodNacional"].Value = null;

                this.sqldaGetImporteVentasMasClubs.Fill(this.dsGraphs1);

            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
            Cursor.Current = Cursors.Default;
        }

        //---- GSG (02/04/2014)
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
                this.sqlCmdGetNumPedidosClienteConMaterial.Parameters["@sCodNacional"].Value = null;

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
        #endregion


        #region Ventas por canal

        private void GraphVentasPorPedidoYCanal(int iIdCliente)
        {
            DateTime oFecIni;
            DateTime oFecFin;

            SetFechasGraphVentas(out oFecIni, out oFecFin);

            int mesIni = oFecIni.Month;
            int anyIni = oFecIni.Year;
            int mesFin = oFecFin.Month;
            int anyFin = oFecFin.Year;
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



            // Valores para el eje Y

            double[] yVals_1 = new double[iItems]; //Dir
            double[] yVals_2 = new double[iItems]; //Auto
            double[] yVals_3 = new double[iItems]; //Transfer
            double[] yVals_4 = new double[iItems]; //Club

            DateTime fecIni;
            DateTime fecFin;

            mesIni = oFecIni.Month;
            anyIni = oFecIni.Year;

            for (int i = 0; i < iItems; i++)
            {
                fecIni = DateTime.Parse("01/" + mesIni.ToString() + "/" + anyIni.ToString());
                fecFin = DateTime.Parse(DateTime.DaysInMonth(anyIni, mesIni).ToString() + "/" + mesIni.ToString() + "/" + anyIni.ToString());

                CargarDatosVentasCanal(iIdCliente, fecIni, fecFin);

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


            // Valores para el eje X
            string[] xVals2 = { "Directo", "Transfer", "Club", "Autopedido" };

            // Valores para el eje Y queso
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

        private void CargarDatosVentasCanal(int iIdCliente, DateTime fecIni, DateTime fecFin)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                this.dsGraphs1.VentasMatFciaPorCanal.Rows.Clear();

                this.sqldaGetVentasMatFciaPorCanal.SelectCommand.Parameters["@iIdCliente"].Value = iIdCliente;
                try { this.sqldaGetVentasMatFciaPorCanal.SelectCommand.Parameters["@dFechaIni"].Value = fecIni; }
                catch { }
                try { this.sqldaGetVentasMatFciaPorCanal.SelectCommand.Parameters["@dFechaFin"].Value = fecFin; }
                catch { }
                this.sqldaGetVentasMatFciaPorCanal.SelectCommand.Parameters["@sCodNacional"].Value = null;

                this.sqldaGetVentasMatFciaPorCanal.Fill(this.dsGraphs1);

            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
            Cursor.Current = Cursors.Default;
        }

        private void CargarDatosImporteVentasCanal(int iIdCliente, DateTime fecIni, DateTime fecFin)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                this.dsGraphs1.ImporteVentasMatFciaPorCanal.Rows.Clear();

                this.sqldaGetImporteVentasMatFciaPorCanal.SelectCommand.Parameters["@iIdCliente"].Value = iIdCliente;
                try { this.sqldaGetImporteVentasMatFciaPorCanal.SelectCommand.Parameters["@dFechaIni"].Value = fecIni; }
                catch { }
                try { this.sqldaGetImporteVentasMatFciaPorCanal.SelectCommand.Parameters["@dFechaFin"].Value = fecFin; }
                catch { }
                this.sqldaGetImporteVentasMatFciaPorCanal.SelectCommand.Parameters["@sCodNacional"].Value = null;

                this.sqldaGetImporteVentasMatFciaPorCanal.Fill(this.dsGraphs1);

            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
            Cursor.Current = Cursors.Default;
        }

        //---- GSG (04/06/2014) 
        // En la gráfica de barras también divideremos por canal 
        private void GraphVentasPorPedidoYCanalBarras(int iIdCliente)
        {
            DateTime oFecIni;
            DateTime oFecFin;

            SetFechasGraphVentas(out oFecIni, out oFecFin);

            int mesIni = oFecIni.Month;
            int anyIni = oFecIni.Year;
            int mesFin = oFecFin.Month;
            int anyFin = oFecFin.Year;
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

            mesIni = oFecIni.Month;
            anyIni = oFecIni.Year;

            for (int i = 0; i < iItems; i++)
            {
                fecIni = DateTime.Parse("01/" + mesIni.ToString() + "/" + anyIni.ToString());
                fecFin = DateTime.Parse(DateTime.DaysInMonth(anyIni, mesIni).ToString() + "/" + mesIni.ToString() + "/" + anyIni.ToString());

                CargarDatosImporteVentasCanal(iIdCliente, fecIni, fecFin);

                if (mesIni == 12)
                {
                    mesIni = 1;
                    anyIni += 1;
                }
                else
                    mesIni += 1;

                yVals_1[i] = double.Parse(dsGraphs1.ImporteVentasMatFciaPorCanal.Rows[0][0].ToString());
                yVals_2[i] = double.Parse(dsGraphs1.ImporteVentasMatFciaPorCanal.Rows[0][1].ToString());
                if (chkbMasClub.Checked)
                    yVals_3[i] = double.Parse(dsGraphs1.ImporteVentasMatFciaPorCanal.Rows[0][2].ToString());
                else
                    yVals_3[i] = 0;
                yVals_4[i] = double.Parse(dsGraphs1.ImporteVentasMatFciaPorCanal.Rows[0][3].ToString());
            }

            chartImporteVentas.Series[1].Points.DataBindXY(xVals, yVals_1);
            chartImporteVentas.Series[2].Points.DataBindXY(xVals, yVals_2);
            chartImporteVentas.Series[3].Points.DataBindXY(xVals, yVals_3);
            chartImporteVentas.Series[4].Points.DataBindXY(xVals, yVals_4);

            chartImporteVentas.ChartAreas[0].AxisX.Interval = 1;


            //En caso de que se mostraran los valores etiquetas en las barrar podríamos ocultar los que valen 0 de la siguiente manera
            //foreach (System.Windows.Forms.DataVisualization.Charting.Series series in chartImporteVentas.Series)
            //{
            //    foreach (System.Windows.Forms.DataVisualization.Charting.DataPoint point in series.Points)
            //    {
            //        if (point.YValues.Length > 0 && (double)point.YValues.GetValue(0) == 0)
            //        {
            //            point.IsValueShownAsLabel = false;
            //        }
            //    }
            //}




            //Cálculo de la media por meses

            string[] xValsMedia = new string[iItems];
            for (int i = 0; i < iItems; i++)
                xValsMedia[i] = xVals[i];

            double media = 0.0;
            for (int i = 0; i < iItems; i++)
            {
                media += (yVals_1[i] + yVals_2[i] + yVals_3[i] + yVals_4[i]);
            }

            if (iItems != 0)
                media /= iItems;

            double[] yValsMedia = new double[iItems];
            for (int i = 0; i < iItems; i++)
                yValsMedia[i] = media;


            chartImporteVentas.Series[5].Points.DataBindXY(xValsMedia, yValsMedia); //Serie línea de media
            chartImporteVentas.Series[5].LegendText = "Media/Mes: " + media.ToString("N2") + " €";


            //Cálculo de la media por pedido //---- GSG (02/04/2014)

            string[] xValsMediaPedido = new string[iItems];
            for (int i = 0; i < iItems; i++)
                xValsMediaPedido[i] = xVals[i];

            fecIni = DateTime.Parse("01/" + oFecIni.Month.ToString() + "/" + oFecIni.Year.ToString());
            fecFin = DateTime.Parse(DateTime.DaysInMonth(oFecFin.Year, oFecFin.Month).ToString() + "/" + oFecFin.Month.ToString() + "/" + oFecFin.Year.ToString());

            int numpeds = ObtenerNumPedidos(fecIni, fecFin);

            double totalImportes = 0;

            for (int i = 0; i < iItems; i++)
            {
                totalImportes += (yVals_1[i] + yVals_2[i] + yVals_3[i] + yVals_4[i]);
            }

            double mediaPedido = 0.0;

            if (numpeds > 0)
                mediaPedido = totalImportes / numpeds;


            double[] yValsMediaPedido = new double[iItems];
            for (int i = 0; i < iItems; i++)
                yValsMediaPedido[i] = mediaPedido;


            chartImporteVentas.Series[6].Points.DataBindXY(xValsMediaPedido, yValsMediaPedido); //Serie línea de media pedido
            chartImporteVentas.Series[6].LegendText = "Media/Pedido: " + mediaPedido.ToString("N2") + " €";
        }

        private void chkbMasClub_CheckedChanged(object sender, EventArgs e)
        {
            GraphVentasPorPedidoYCanalBarras(_iIdCliente);
        }
        #endregion


        

        #region ranking
        private void GraphsRanking(int iIdCliente)
        {
            DateTime oFecIni;
            DateTime oFecFin;

            SetFechasGraphVentas(out oFecIni, out oFecFin);

            CargarDatosRanking(iIdCliente, oFecIni, oFecFin);

            #region total unidades

            //ordena según criterio ránking
            DataTable dtOutQty = null;
            dsGraphs1.RankingVentasMat.DefaultView.Sort = "totalQty DESC ";
            dtOutQty = dsGraphs1.RankingVentasMat.DefaultView.ToTable();

            // Valores para el eje X e Y

            int iItems = K_TOP_RANKING;
            if (dsGraphs1.RankingVentasMat.Rows.Count < K_TOP_RANKING)
                iItems = dsGraphs1.RankingVentasMat.Rows.Count;

            string[] xVals = new string[iItems];
            int[] yVals = new int[iItems]; //qty

            for (int i = 0; i < iItems; i++)
            {
                xVals[i] = dtOutQty.Rows[i]["sMaterial"].ToString().ToLower();
                if (dtOutQty.Rows[i]["totalQty"].ToString() != "" && dtOutQty.Rows[i]["totalQty"].ToString() != null)
                    yVals[i] = int.Parse(dtOutQty.Rows[i]["totalQty"].ToString());
                else
                    yVals[i] = 0;
            }

            chartRankingMaterialesQty.Series[0].Points.DataBindXY(xVals, yVals);

            #endregion

            #region total bruto
            //ordena según criterio ránking
            DataTable dtOutBruto = null;
            dsGraphs1.RankingVentasMat.DefaultView.Sort = "totalBruto DESC ";
            dtOutBruto = dsGraphs1.RankingVentasMat.DefaultView.ToTable();

            // Valores para el eje X e Y

            string[] xVals2 = new string[iItems];
            double[] yVals2 = new double[iItems]; //bruto

            for (int i = 0; i < iItems; i++)
            {
                xVals2[i] = dtOutBruto.Rows[i]["sMaterial"].ToString().ToLower();
                if (dtOutBruto.Rows[i]["totalBruto"].ToString() != "" && dtOutBruto.Rows[i]["totalBruto"].ToString() != null)
                    yVals2[i] = double.Parse(dtOutBruto.Rows[i]["totalBruto"].ToString());
                else
                    yVals2[i] = 0;
            }


            chartRankingMaterialesBruto.Series[0].Points.DataBindXY(xVals2, yVals2);
            #endregion

            #region club unidades
            //ordena según criterio ránking
            DataTable dtOutQtyClub = null;
            dsGraphs1.RankingVentasMat.DefaultView.Sort = "QtyClub DESC ";
            dtOutQtyClub = dsGraphs1.RankingVentasMat.DefaultView.ToTable();

            // Valores para el eje X e Y
            string[] xVals3 = new string[iItems];
            int[] yVals3 = new int[iItems]; //qty

            for (int i = 0; i < iItems; i++)
            {
                xVals3[i] = " ";

                if (dtOutQtyClub.Rows[i]["QtyClub"].ToString() != "" && dtOutQtyClub.Rows[i]["QtyClub"].ToString() != null)
                {
                    if (int.Parse(dtOutQtyClub.Rows[i]["QtyClub"].ToString()) != 0)
                    {
                        xVals3[i] = dtOutQtyClub.Rows[i]["sMaterial"].ToString().ToLower();
                        yVals3[i] = int.Parse(dtOutQtyClub.Rows[i]["QtyClub"].ToString());
                    }
                }
            }

            chartRankingMaterialesQtyClub.Series[0].Points.DataBindXY(xVals3, yVals3);
            #endregion

            #region club bruto

            //ordena según criterio ránking
            DataTable dtOutBrutoClub = null;
            dsGraphs1.RankingVentasMat.DefaultView.Sort = "brutoClub DESC ";
            dtOutBrutoClub = dsGraphs1.RankingVentasMat.DefaultView.ToTable();

            // Valores para el eje X e Y

            string[] xVals4 = new string[iItems];
            double[] yVals4 = new double[iItems]; //bruto

            for (int i = 0; i < iItems; i++)
            {
                xVals4[i] = " ";

                if (dtOutBrutoClub.Rows[i]["brutoClub"].ToString() != "" && dtOutBrutoClub.Rows[i]["brutoClub"].ToString() != null)
                {
                    if (int.Parse(dtOutBrutoClub.Rows[i]["brutoClub"].ToString()) != 0)
                    {
                        xVals4[i] = dtOutBrutoClub.Rows[i]["sMaterial"].ToString().ToLower();
                        yVals4[i] = double.Parse(dtOutBrutoClub.Rows[i]["brutoClub"].ToString());
                    }
                }
            }


            chartRankingMaterialesBrutoClub.Series[0].Points.DataBindXY(xVals4, yVals4);

            #endregion


        }

        private void CargarDatosRanking(int iIdCliente, DateTime fecIni, DateTime fecFin)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                this.dsGraphs1.RankingVentasMat.Rows.Clear();

                this.sqldaGetRankingVentasMat.SelectCommand.Parameters["@iIdCliente"].Value = iIdCliente;
                try { this.sqldaGetRankingVentasMat.SelectCommand.Parameters["@dFechaIni"].Value = fecIni; }
                catch { }
                try { this.sqldaGetRankingVentasMat.SelectCommand.Parameters["@dFechaFin"].Value = fecFin; }
                catch { }

                this.sqldaGetRankingVentasMat.Fill(this.dsGraphs1);

            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
            Cursor.Current = Cursors.Default;
        }
        #endregion

        private void SetFechasGraphVentas(out DateTime oFecIni, out DateTime oFecFin)
        {
            DateTime hoy = DateTime.Today;
            DateTime dFecIni = Comun.calculaFechaIni(hoy);
            DateTime dFecFin = DateTime.Parse(DateTime.DaysInMonth(hoy.Year, hoy.Month).ToString() + "/" + hoy.Month.ToString() + "/" + hoy.Year.ToString());

            oFecIni = dFecIni;
            oFecFin = dFecFin;
        }

        #endregion

        //---- GSG (11/04/2014)
        private void btReloadAlarmas_Click(object sender, EventArgs e)
        {
            GetResultadoBuscar();
        }

        

        #endregion

        //---- GSG (06/10/2015)
        #region Acciones Márketing
                
        private void CargarDatosAccMark()
        {
            Cursor.Current = Cursors.WaitCursor;

            if (CargarDatosAccMarkCli())
                pintaGridAccMarkCli();

            Cursor.Current = Cursors.Default;
        }

        private bool CargarDatosAccMarkCli()
        {
            bool bRet = true;

            try
            {
                this.dsAccionesMarketing1.GetAccMarkClientes.Rows.Clear();

                this.sqldaGetAccMarkClientes.SelectCommand.Parameters["@iIdCliente"].Value = this._iIdCliente;
                this.sqldaGetAccMarkClientes.SelectCommand.Parameters["@iIdDelegado"].Value = Clases.Configuracion.iIdDelegado;

                this.sqldaGetAccMarkClientes.Fill(this.dsAccionesMarketing1);

                this.lblNumRegAccMark.Text = this.dsAccionesMarketing1.GetAccMarkClientes.Rows.Count.ToString();
            }
            catch (Exception ex) { bRet = false;  Mensajes.ShowError(ex.Message); }

            return bRet;
        }

        private void pintaGridAccMarkCli()
        {
            DateTime fechaAnt = DateTime.MaxValue;
            DateTime fechaLin = DateTime.MaxValue;
            Color c1 = Color.White;
            Color c2 = Color.LightGray;
            Color cActual = c1;

            foreach (DataGridViewRow row in dGVAccMark.Rows)
            {
                fechaLin = DateTime.Parse(row.Cells["dFechaPedido"].Value.ToString());
                if (fechaLin != fechaAnt)
                    cActual = (cActual == c1 ? c2 : c1);

                for (int i = 0; i < row.Cells.Count; i++)
                    row.Cells[i].Style.BackColor = cActual;

                fechaAnt = fechaLin;
            }
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
                this.sqldaListaImpagos.SelectCommand.Parameters["@iIdCliente"].Value = this._iIdCliente;
                

                this.sqldaListaImpagos.Fill(this.dsClientes);

                this.lblNumImpagos.Text = this.dsClientes.ListaImpagos.Rows.Count.ToString();
            }
            catch (Exception ex) { bRet = false; Mensajes.ShowError(ex.Message); }

            return bRet;
        }

        #endregion



        //---- GSG (08/03/2018)
        private void btCrearPedido_Click(object sender, EventArgs e)
        {
            //if (!GESTCRM.Utiles.MirarSiAbierto(GESTCRM.Formularios.frmPedidos.ActiveForm, "frmPedidos"))
            if (!GESTCRM.Utiles.MirarSiAbierto(this, "frmPedidos")) //---- GSG (06/03/2021)
                {
                string iIdCampanya = K_CAMP_MIXABC;

                // DESCUENTOS AUTORIZADOS para CH - Cliente MixABC para GX
                if (System.Configuration.ConfigurationManager.AppSettings["RedVentas"].ToString() == K_CH)
                    iIdCampanya = K_CAMP_DA;


                //---- GSG (20/04/2018)

                // en genéricos si el cliente es espcial miraremos si tiene alguna de las siguientes porque no tiene MixABC
                //185  LINEAL 50
                //61   LINEAL 45
                //183  GENTE + SANA
                //167  FEDEFARMA - STAR
                //333  FEDEFARMA - JUNIOR
                //332  FEDEFARMA - PRIME ESTA NO PORQUE TIENE MUY POCOS MATERIALES


                /*if (ObtenerMateriales("ZDIR", iIdCampanya))
                {
                    int iRet = ObtenerCampanyas(Clases.Configuracion.iIdDelegado.ToString(), "ZDIR", iIdCampanya);
                    if (iRet == 0)
                    {
                        GuardarLins();
                        EnviarMatsAPedido(iIdCampanya);
                    }
                    else if (iRet == -1)
                        Mensajes.ShowError("Se ha producido un error al cargar las campañas.");
                }
                else
                    Mensajes.ShowError("Se ha producido un error al cargar los materiales.");*/

                // Este código es muy chapucero pero se va a quedar así. En principio, los códigos de campaña no cambian

                int iRet = ObtenerCampanyas(Clases.Configuracion.iIdDelegado.ToString(), "ZDIR", iIdCampanya);
                if (iRet == 1)
                {
                    iIdCampanya = "185";
                    iRet = ObtenerCampanyas(Clases.Configuracion.iIdDelegado.ToString(), "ZDIR", iIdCampanya);
                    if (iRet == 1)
                    {
                        iIdCampanya = "61";
                        iRet = ObtenerCampanyas(Clases.Configuracion.iIdDelegado.ToString(), "ZDIR", iIdCampanya);
                        if (iRet == 1)
                        {
                            iIdCampanya = "183";
                            iRet = ObtenerCampanyas(Clases.Configuracion.iIdDelegado.ToString(), "ZDIR", iIdCampanya);
                            if (iRet == 1)
                            {
                                iIdCampanya = "167";
                                iRet = ObtenerCampanyas(Clases.Configuracion.iIdDelegado.ToString(), "ZDIR", iIdCampanya);
                                if (iRet == 1)
                                {
                                    iIdCampanya = "333";
                                    iRet = ObtenerCampanyas(Clases.Configuracion.iIdDelegado.ToString(), "ZDIR", iIdCampanya);
                                }
                            }
                        }
                    }
                }

                if (iRet == -1)
                    Mensajes.ShowError("Se ha producido un error al cargar las campañas.");
                else
                {
                    if (ObtenerMateriales("ZDIR", iIdCampanya))
                    {
                        GuardarLins();
                        EnviarMatsAPedido(iIdCampanya);
                    }
                    else
                        Mensajes.ShowError("Se ha producido un error al cargar los materiales.");
                }
            }
            else
            {
                DialogResult dr = Mensajes.ShowQuestion("No se puede crear un Pedido porque ya hay uno abierto. ¿Desea ver el Pedido abierto?");
                if (dr == DialogResult.Yes)
                {
                    //GESTCRM.Utiles.ActivaFormularioAbierto(this, "frmPedidos");
                    GESTCRM.Utiles.ActivaFormularioAbierto("frmPedidos", this.MdiParent);
                }
            }
        }

        
        private void EnviarMatsAPedido(string iIdCampanya)
        {
            frmPedidos frmTemp = new Formularios.frmPedidos(txtsIdCliente.Text, _iIdCliente, txtsCliente.Text, iIdCampanya, "ZDIR");

            frmTemp.MdiParent = this.MdiParent;
            frmTemp.Show();            

            //Abrir pantalla selección de materiales     
            DataRowView rowView;

            rowView = dsFormularios1.ListaCampanyas.DefaultView[frmTemp.cBoxCampanyas.SelectedIndex]; 

            frmTemp.BuscarMateriales(rowView.Row, _propuesta, K_POS_COD, K_POS_UNI, K_POS_DTO);
        }


        private void GuardarLins()
        {
            char cSeparador = ';';
            _propuesta.Clear(); //---- GSG (08/06/2018)

            foreach (DataGridViewRow dr in dGVVentas.Rows)
            {
                DataRow[] lDr = dsMateriales1.ListaMateriales.Select("sCodNacional = '" + dr.Cells["sCodNacional1"].Value.ToString() + "'");
                
                string desc = "0";
                if (lDr.Length > 0)
                {
                    DataRow drSel = lDr[0];
                    desc = drSel["fDescuento"].ToString();
                }


                string strLinea = dr.Cells["sCodNacional1"].Value.ToString() + cSeparador + dr.Cells["totalVenta1"].Value.ToString() + cSeparador + desc;
                _propuesta.Add(strLinea.Split(cSeparador));
            }
        }


        private int ObtenerCampanyas(string sDelegado, string sTipoPed, string iIdCampanya)
        {
            int iRet = 1;

            try
            {
                dsFormularios1.ListaCampanyas.Clear();

                sqldaListaCampanyas.SelectCommand.Parameters["@sIdDelegado"].Value = sDelegado;
                sqldaListaCampanyas.SelectCommand.Parameters["@sIdTipoPedido"].Value = sTipoPed;
                sqldaListaCampanyas.SelectCommand.Parameters["@iIdCliente"].Value = _iIdCliente;
                sqldaListaCampanyas.SelectCommand.Parameters["@sIdMayorista"].Value = null;

                sqldaListaCampanyas.Fill(dsFormularios1.ListaCampanyas);

                int existe = dsFormularios1.ListaCampanyas.Select("idCampanya = '" + iIdCampanya + "'").Length;

                if (dsFormularios1.ListaCampanyas.Rows.Count > 0 && existe > 0)
                {
                    dsFormularios1.ListaCampanyas.DefaultView.Sort = "NombreCampanya";
                    iRet = 0;
                }
                //---- GSG (20/04/2018)
                //else if (existe == 0)
                //{
                //        Mensajes.ShowExclamation("El cliente no tiene una campaña disponible para poder crear el pedido. No se puede generar el pedido.");                    
                //}
                //else
                //    Mensajes.ShowExclamation("No hay campañas disponibles.");
            }
            catch (Exception err)
            {
                iRet = -1;
            }

            return iRet;
        }


        private bool ObtenerMateriales(string sTipoPed, string iIdCampanya)
        {
            bool bRet = true;

            try
            {
                if (System.Configuration.ConfigurationManager.AppSettings["TipoDelegadoPedidosCentral"].ToString() == Comun.K_CECL)
                    sqlDaListaMateriales.SelectCommand.CommandText = "[ListaMaterialesDesCampCECL]";
                else
                    sqlDaListaMateriales.SelectCommand.CommandText = "[ListaMaterialesDesCamp]";


                //Pasamos el parámetro
                this.sqlDaListaMateriales.SelectCommand.Parameters["@iIdCamp"].Value = iIdCampanya;
                this.sqlDaListaMateriales.SelectCommand.Parameters["@sIdTipoPedido"].Value = sTipoPed;
                this.sqlDaListaMateriales.SelectCommand.Parameters["@iIdDelegado"].Value = Clases.Configuracion.iIdDelegado;

                //Llenamos la lista de materiales
                dsMateriales1.ListaMateriales.Clear();
                this.sqlDaListaMateriales.Fill(dsMateriales1);
            }
            catch(Exception err)
            {
                bRet = false;
            }

            return bRet;

        }

        
        

    }
}
