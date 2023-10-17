using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using GESTCRM.Clases;
using System.Linq;

//---- GSG (12/04/2012)
// En aquesta pantalla la rendabilitat es calcula per a totes les campanyes, encara que sigui una campanya
// que no influeix en la rendabilitat total de la comanda. Cal però mostrar un text que ho indiqui.



namespace GESTCRM.Formularios.Busquedas
{

    /// <summary>
    /// Descripción breve de frmMMateriales.
    /// </summary>
    public class frmMMateriales : System.Windows.Forms.Form
    {       
        private const string K_ZMKT = "ZMKT"; //---- GSG (13/01/2017)

        public string ParamIO_sIdMaterial;
        public string ParamIO_sDescripcion;
        public string ParamIO_sCodNacional;
        public string ParamIO_sPrecio;

        public List<dsMateriales.ListaLineasPedidoRow> MaterialesLinea = null;
        //---- GSG (03/01/2012)
        public bool _bCampanyaExtra = false;
        public double _fDescExtra = 0.0;
        public double _fDescExtraRestante = 0.0;
        //---- GSG (24/02/2012)
        private static string[] lMatsNoRenta;
        private System.Data.SqlClient.SqlCommand sqlCmdGetMaterialesNoRentabilidad;
        private System.Data.SqlClient.SqlCommand sqlCmdGetRentabilidadDescripcion;
        private GESTCRM.Formularios.DataSets.dsPedidos dsPedidos1;
        int _preRowSelected = -1;
        //---- GSG (26/05/2015)
        public bool _bCampanyaMatsNoVenta = false;

        //---- GSG (12/04/2012)
        private string[] _lCampanyasNoRenta;
        //---- GSG (23/04/2012)
        private System.Data.SqlClient.SqlCommand sqlCmdGetRentabilidadColor;
        //---- GSG (30/09/2013)
        private System.Data.SqlClient.SqlCommand sqlGetRentMinCamp;
        //---- GSG (27/03/2014)
        private static string[] _lMatsSoloClub;
        private bool _bEditTxtDesc;
        //---- GSG (15/07/2014)
        private System.Data.SqlClient.SqlCommand sqlGetPaquete;
        //---- GSG (17/11/2014)
        private System.Data.SqlClient.SqlCommand sqlGetSumaUnidades;
        private System.Data.SqlClient.SqlCommand sqlEsDelegadoCanarias;
        //---- GSG (29/03/2022)
        private System.Data.SqlClient.SqlCommand sqlGetTipoPedidoSumaUnidades;

        //---- GSG (29/09/2020) PUNTOS
        private static string[] lMatsNoMargen;
        private System.Data.SqlClient.SqlCommand sqlCmdGetMaterialesNoMargen;
        private static string _sMatsARARnoCli;
        private static string _sMatsMRARnoCli;
        private System.Data.SqlClient.SqlCommand sqlCmdGetMatsARARnoCli;
        private System.Data.SqlClient.SqlCommand sqlCmdGetMatsMRARnoCli;
        //---- GSG (02/02/2021)
        private System.Data.SqlClient.SqlCommand sqlCmdGetTiposMatAPintar;
        private static string[] _lTipusAPintar;

        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblCNacional;
        private System.Windows.Forms.Label lblCMaterial;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.Button btBuscar;
        private System.Windows.Forms.TextBox txbsIdMaterial;
        private System.Windows.Forms.TextBox txbsDescripcion;
        private System.Windows.Forms.TextBox txbsCodNacional;
        private System.Windows.Forms.TextBox txbsPrecio;
        private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.Button btAceptar;
        private System.Windows.Forms.Panel pnBusqueda;
        private System.Windows.Forms.Label lblNumReg;
        private GESTCRM.Controles.LabelGradient labelGradient2;
        private System.Data.SqlClient.SqlConnection sqlConn;
        private IContainer components;


        private DataGridView dataGridView1;
        private GroupBox groupBox2;
        private ComboBox cmBoxMostrar;
        private Label label2;

        private string sIdCampCab = "-1"; //---- GSG (17/06/2014)
        private string sIdCampanya = "0";
        private string NombreCampanya;
        private string NumMinOblis = "0";
        private string sObservaciones = ""; //---- GSG (25/09/2013)
        private string _sTipoSumaUnidades = "0"; //---- GSG (17/11/2014)
        private string _sTipoPedidoSumaUnidades = "XXXX"; //---- GSG (29/03/2022)
        private bool _bArrastre = false; //---- GSG (22/01/2015) Campo reutilizado para indicar POLIMEDICADOS VENTA
        private string _iIdCampanyaPedidoNoDescMedio = "";  //---- VLP (26/07/2023)
        private Label lblCampanya;
        private Label lblCantidadMinima;
        private Label label1;
        private string ImporteMinObli = "0";
        private dsMateriales dsMateriales1;
        private static string obligatorioSi = "Sí"; //Equivale a True
        //---- GSG (04/02/2011)
        private double dImporteBrutoMinObli = 0.0;
        private Button btCambiar;
        private ComboBox cBoxCampanyas;
        private SqlDataAdapter sqldaListaCampanyas;
        private SqlCommand sqlCommand3;
        private dsFormularios dsFormularios1;
        private int iCantidadTotalMinObli = 0;
        //---- GSG (04/04/2011)
        private DataGridView dataGridViewPedido;
        int idGrupMat = -1;
        private TextBox txbDescExtra;
        private Label lblDescExtra;
        private TextBox txbDescExtraRestante;
        private Label lblDescExtraRestante;
        private TextBox txbDto;
        private TextBox txbImporte;
        private Label lblImporte;
        private TextBox txbImporteBruto;
        private Label lblImporteBruto;
        private TextBox txbRentabilidad;
        private TextBox txtRentabilidad;
        private Label label3;
        private Label label9;
        private System.Data.SqlClient.SqlCommand sqlCmdGetIsDescuentoMaxInformed;
        private Label lblAfectaRentabilidad;
        private SqlDataAdapter sqlDaListaMateriales;
        //---- GSG (31/07/2012)
        private SqlDataAdapter sqldaListaMatsCliLastYear;
        private System.Data.SqlClient.SqlCommand sqlCmdListaMatsCliLastYear;
        private int _iIdCliente;
        //---- GSG (22/10/2013)
        private string _sTipoPedido; 
        private string sCodsMatsCliLastYear;
        private Label label4;
        private TextBox txbMG;
        //---- GSG (12/04/2012)
        private System.Data.SqlClient.SqlCommand sqlCmdGetCampanyasNoRentabilidad;

        //---- GSG (05/06/2013)
        private System.Data.SqlClient.SqlDataAdapter sqldaListaAccionesMarkCli;
        private System.Data.SqlClient.SqlCommand sqlSelectCommandListaAccionesMarkCli;
        private System.Data.SqlClient.SqlDataAdapter sqldaListaAccMarkCamp;
        private System.Data.SqlClient.SqlCommand sqlCmdListaAccMarkCamp;
        private System.Data.SqlClient.SqlCommand sqlCmdListaCampanyas;
        private System.Data.SqlClient.SqlCommand sqlCmdListaCampanyasNEW; //----- GSG (05/07/2017)
        private System.Data.SqlClient.SqlDataAdapter sqldaListaAccMarkCampByCli;
        private System.Data.SqlClient.SqlCommand sqlCmdListaAccMarkCampByCli;
        private System.Data.SqlClient.SqlCommand sqlcmdExisteCampInAccMarkCamp; //---- GSG (23/10/2013)
        private GESTCRM.Formularios.DataSets.dsClientes dsClientes1;
        private GESTCRM.Formularios.DataSets.dsAccionesMarketing dsAccionesMarketing1;
        private bool _bEsClienteConAccMark = false;
        //private string _sCampanyaClienteConAccMark = "";
        //---- GSG (13/11/2013)
        private System.Data.SqlClient.SqlDataAdapter sqldaListaUltimosAvisos;
        private System.Data.SqlClient.SqlCommand sqlCmdListaUltimosAvisos;
        //---- GSG (22/01/2014)
        private System.Data.SqlClient.SqlDataAdapter sqldaListaTipoMaterialInforme;
        private System.Data.SqlClient.SqlCommand sqlCmdListaTipoMaterialInforme;
        private System.Data.SqlClient.SqlCommand sqlCmdGetMatsSoloClub; //---- GSG (27/03/2014)
        //---- GSG (19/10/2015)
        private System.Data.SqlClient.SqlDataAdapter sqldaListaTarjetasClienteActivas;
        private System.Data.SqlClient.SqlCommand sqlCmdListaTarjetasClienteActivas;
        //---- GSG (12/07/2018)
        private System.Data.SqlClient.SqlCommand sqlCmdGetIsDescuentoMinGarInformed;
        //---- GSG (13/03/2016)
        private System.Data.SqlClient.SqlDataAdapter sqldaListaTipoProductoInforme;
        private System.Data.SqlClient.SqlCommand sqlCmdListaTipoProductoInforme;


        //---- GSG (10/07/2013)
        public int _V_POS_COD = -1;
        public int _V_POS_UNI = -1;
        public int _V_POS_DTO = -1; //---- GSG (21/01/2014)
        private Label lblObservaciones;
        private TextBox txtObservaciones;
        public List<string[]> _cargaMateriales;


        //---- GSG (19/11/2013)
        private const string K_CAB = "CAB";
        private const string K_LIN = "LIN";
        private const string K_TODOS = "XXXX";

        //---- GSG (21/01/2014)
        private const int K_ORIGEN_IMPORTACION = 0;
        private const int K_ORIGEN_PROPUESTA = 1;
        private const int K_ORIGEN_IMPORTACION_CON_DESC = 2; //---- GSG (15/06/2016)
        private ComboBox cbTipoMaterial;
        private Label label5;
        private BindingSource listaTipoMaterialInformeBindingSource;
        private Button btQtyAdquiridas;

        //---- GSG (29/09/2020) PUNTOS
        //private const int K_COL_CODNACIONAL = 3;
        //private const int K_COL_NOMMAT = 4;
        //private const int K_COL_DESCMAXMAT = 19;
        //private const int K_COL_DESCMAXCAMP = 9;
        private const int K_COL_CODNACIONAL = 5;
        private const int K_COL_NOMMAT = 6;
        private const int K_COL_DESCMAXMAT = 21;
        private const int K_COL_DESCMAXCAMP = 11;

        //---- GSG (10/03/2014)
        private const double K_DIF_ENFAJADOCAJA = 5;

        private Button btDescsAplicados; //---- GSG (22/01/2014)

        //---- GSG (11/03/2014)
        const int K_COL_LIN = 0;
        const int K_COL_CODNAC = 1;
        const int K_COL_IDMAT = 2;
        const int K_COL_DESCMAT = 3;
        const int K_COL_NOMCAMP = 4;
        const int K_COL_OBLIG = 5;
        const int K_COL_CANT = 6;
        const int K_COL_BRUTO = 7;
        const int K_COL_PRECIO = 8;
        const int K_COL_DTO = 9;
        const int K_COL_IMPORTE = 10;
        const int K_COL_DTOMAX = 11;
        const int K_COL_RENT = 12;
        const int K_COL_COSTE = 13;
        const int K_COL_IDCAMP = 14;
        const int K_COL_IDARRASTRE = 15;
        const int K_COL_UNIMIN = 16;
        const int K_COL_IDGRUPOMAT = 17;
        const int K_COL_IMGBORRA = 18;
        const int K_COL_ORDEN = 19;
        const int K_COL_DTOEXTRA = 20;
        const int K_COL_DTOMAT = 21;
        const int K_COL_ESEXTRA = 22;



        private TextBox txbsDescripcionParaGrid;

        private Color ErrorColor = Color.FromArgb(255, 90, 90);
        private Color DefaultValueColor = Color.FromArgb(128, 255, 128);
        private Color EnfajadoCajaColor = Color.FromArgb(71, 191, 250); //---- GSG (10/03/2014)
        private Color MatsSoloClubColor = Color.FromArgb(71, 191, 250); //---- GSG (27/03/2014)

        private string DefaultValue = "0";
        private string filter = String.Empty;

        //---- GSG (29/09/2015)        
        private List<RegaloEspecial> _lRegaloEspecial = new List<RegaloEspecial>();
        //---- GSG (04/09/2015)
        private System.Data.SqlClient.SqlDataAdapter sqldaMatsEspeciales;
        private System.Data.SqlClient.SqlCommand sqlCmdMatsEspeciales;
        private double _descMaxRegaloEspecial = 0;
        private bool _bEsEsp = false;
        private Label lblVigencia;
        private Label lblValorVigencia;

        //---- GSG (08/07/2016)
        private List<KeyValuePair<string, string>> _lPairsMatCampEnPed = new List<KeyValuePair<string, string>>();
        private ComboBox cbTipoProd; //----GSG (13/03/2019)
        private Label label6;
        private BindingSource listaTipoProductoInformeBindingSource;
        private Label label7;
        private TextBox txbTotalUnidades;
        private TextBox txtMargen;
        private Label label8;

        //---- GSG (06/10/2016)
        private int _indexCampanyaSelected = -1;
        private CheckBox cbSelTodo;
        private TextBox txbTotalUnidadesConBase;
        private Label label10;
        private DataGridViewCheckBoxColumn selected;
        private DataGridViewTextBoxColumn Rendabilitat;
        private DataGridViewTextBoxColumn margen;
        private DataGridViewTextBoxColumn MargenLin;
        private DataGridViewTextBoxColumn sObligatorio;
        private DataGridViewTextBoxColumn sCodNacional;
        private DataGridViewTextBoxColumn sMaterial;
        private DataGridViewTextBoxColumn sIdMaterial;
        private DataGridViewTextBoxColumn fPrecio;
        private DataGridViewTextBoxColumn iCantidad;
        private DataGridViewTextBoxColumn fDescuento;
        private DataGridViewTextBoxColumn fDescuentoMaximo;
        private DataGridViewTextBoxColumn fCoste;
        private DataGridViewTextBoxColumn UnidMinimas;
        private DataGridViewTextBoxColumn Ordre;
        private DataGridViewTextBoxColumn sTipoMat;
        private DataGridViewTextBoxColumn iStock;
        private DataGridViewTextBoxColumn dEntrega;
        private DataGridViewTextBoxColumn iPendientes;
        private DataGridViewTextBoxColumn iUnidadesEnfajado;
        private DataGridViewTextBoxColumn iCajaCompleta;
        private DataGridViewTextBoxColumn fDescMat;
        private DataGridViewTextBoxColumn fDescMatTRA;
        private DataGridViewTextBoxColumn fPVP;
        private DataGridViewTextBoxColumn fPVPIVA;
        private DataGridViewTextBoxColumn iStockCanarias;
        private DataGridViewTextBoxColumn iPendientesCanarias;
        private DataGridViewTextBoxColumn unisPedidas;
        private DataGridViewTextBoxColumn TipoClasificacion;
        private DataGridViewTextBoxColumn sTipoProdInformes;
        private DataGridViewTextBoxColumn iCantidadBase;

        //---- GSG (02/01/2023)
        private int _iMinimos = 0; //0: clásico   1: mínimos


        //---- GSG (31/07/2012)
        //public frmMMateriales(DataRow row, int indexCampanyaSelected, string sDescExtra, string sDescExtraRestante)
        //---- GSG (22/10/2013)
        //public frmMMateriales(DataRow row, int indexCampanyaSelected, string sDescExtra, string sDescExtraRestante, int iIdCliente)
        //---- GSG (17/06/2014)
        //public frmMMateriales(DataRow row, int indexCampanyaSelected, string sDescExtra, string sDescExtraRestante, int iIdCliente, string TipoPedido)
        //---- GSG (08/07/2016)
        //public frmMMateriales(DataRow row, int indexCampanyaSelected, string sDescExtra, string sDescExtraRestante, int iIdCliente, string TipoPedido, string psIdCampCab)
        //---- GSG (07/07/2017)
        //public frmMMateriales(DataRow row, int indexCampanyaSelected, string sDescExtra, string sDescExtraRestante, int iIdCliente, string TipoPedido, string psIdCampCab, List<KeyValuePair<string,string>> pList)
        //---- GSG (02/01/2023)
        //public frmMMateriales(DataRow row, int indexCampanyaSelected, string sDescExtra, string sDescExtraRestante, int iIdCliente, string TipoPedido, string psIdCampCab, List<KeyValuePair<string, string>> pList, string mayorista)
        public frmMMateriales(DataRow row, int indexCampanyaSelected, string sDescExtra, string sDescExtraRestante, int iIdCliente, string TipoPedido, string psIdCampCab, List<KeyValuePair<string, string>> pList, string mayorista, int iMinimos)
        {
            InitializeComponent();


            //---- GSG (06/03/2021)
            Utiles.GetConfigConnection();
            this.sqlConn.ConnectionString = Utiles._connection.ConnectionString.ToString();

            //---- GSG (17/06/2014)
            if (psIdCampCab.Trim() == "")
                psIdCampCab = "-1";

            _indexCampanyaSelected = indexCampanyaSelected; //---- GSG (06/10/2016)
            _iMinimos = iMinimos; //---- GSG (02/01/2023)

            dataGridView1.RowsDefaultCellStyle.SelectionBackColor = Utiles.ColorSelecionFilaDataGrid;

            sIdCampanya = row["idCampanya"].ToString();
            NombreCampanya = row["NombreCampanya"].ToString();
            NumMinOblis = row["iNumMinOblis"].ToString();
            ImporteMinObli = row["fImporteMinObli"].ToString();

            //---- GSG (04/02/2011)
            dImporteBrutoMinObli = double.Parse(row["fImporteMinObliBruto"].ToString());
            iCantidadTotalMinObli = int.Parse(row["iNumMinOblisTotal"].ToString());
            sObservaciones = row["sObservaciones"].ToString(); //---- GSG (25/09/2013)
            //_bArrastre = bool.Parse(row["bArrastre"].ToString()); //---- GSG (22/01/2015)
            
            //---- GSG (22/10/2013)
            _sTipoPedido = TipoPedido;

            //---- GSG (17/06/2014)
            sIdCampCab = psIdCampCab;

            //---- GSG (01/04/2011)(04/04/2011)
            //LlenarCombos();
            //---- GSG (07/07/2017)
            //LlenarCombos(iIdCliente); //---- GSG (06/06/2013)
            LlenarCombos(iIdCliente, mayorista);
            dataGridViewPedido = null;
            
            //---- GSG (03/01/2012)
            _bCampanyaExtra = esDescExtra(indexCampanyaSelected);
            _fDescExtra = double.Parse(sDescExtra);
            _fDescExtraRestante = double.Parse(sDescExtraRestante);
            if (_bCampanyaExtra)
            {
                txbDescExtra.Text = sDescExtra;
                txbDescExtraRestante.Text = sDescExtraRestante;
                lblDescExtra.Visible = true;
                txbDescExtra.Visible = true;
                lblDescExtraRestante.Visible = true;
                txbDescExtraRestante.Visible = true;
                //---- GSG (23/04/2013)
                txbMG.Text = "0%";
            }
            else
            {
                lblDescExtra.Visible = false;
                txbDescExtra.Visible = false;
                lblDescExtraRestante.Visible = false;
                txbDescExtraRestante.Visible = false;
                txbMG.Text = String.Format("{0:#,0.##}%", row["fDescMinGar"].ToString());
            }

            //---- GSG (31/07/2012)
            _iIdCliente = iIdCliente;
            
            //---- GSG (26/05/2015)
            _bCampanyaMatsNoVenta = esCampanyaMatsNoVenta(indexCampanyaSelected);

            //---- GSG (29/09/2015)
            initRegalosEspeciales();
            _descMaxRegaloEspecial = (double)valorDescMaxRegaloEspecial(indexCampanyaSelected);
            _bEsEsp = esCampanyaRegaloEspecial(indexCampanyaSelected);

            //---- GSG (08/07/2016)
            _lPairsMatCampEnPed = pList;

            if (_lPairsMatCampEnPed.Count > 0)
            {
                _bArrastre = PedidoEsNoDecsMedio(out _iIdCampanyaPedidoNoDescMedio);  //---- VLP (26/07/2023)
            }

            comprobaCompromisoMinimos(); //---- GSG (02/01/2023)
        }

        //---- GSG (04/04/2011)
        //---- GSG (31/07/2012) iIdCliente
        //public frmMMateriales(DataRow row, DataGridView dg, string idGrup, int indexCampanyaSelected, string sDescExtra, string sDescExtraRestante)
        //---- GSG (22/10/2013)
        //public frmMMateriales(DataRow row, DataGridView dg, string idGrup, int indexCampanyaSelected, string sDescExtra, string sDescExtraRestante, int iIdCliente) 
        //---- GSG (17/06/2014)
        //public frmMMateriales(DataRow row, DataGridView dg, string idGrup, int indexCampanyaSelected, string sDescExtra, string sDescExtraRestante, int iIdCliente, string TipoPedido)        
        //---- GSG (08/07/2016)
        //public frmMMateriales(DataRow row, DataGridView dg, string idGrup, int indexCampanyaSelected, string sDescExtra, string sDescExtraRestante, int iIdCliente, string TipoPedido, string psIdCampCab)
        //---- GSG (07/07/2017)
        //public frmMMateriales(DataRow row, DataGridView dg, string idGrup, int indexCampanyaSelected, string sDescExtra, string sDescExtraRestante, int iIdCliente, string TipoPedido, string psIdCampCab, List<KeyValuePair<string, string>> pList)
        //---- GSG (02/01/2023)
        //public frmMMateriales(DataRow row, DataGridView dg, string idGrup, int indexCampanyaSelected, string sDescExtra, string sDescExtraRestante, int iIdCliente, string TipoPedido, string psIdCampCab, List<KeyValuePair<string, string>> pList, string mayorista)
        public frmMMateriales(DataRow row, DataGridView dg, string idGrup, int indexCampanyaSelected, string sDescExtra, string sDescExtraRestante, int iIdCliente, string TipoPedido, string psIdCampCab, List<KeyValuePair<string, string>> pList, string mayorista, int iMinimos)
        {
            InitializeComponent();


            //---- GSG (06/03/2021)
            Utiles.GetConfigConnection();
            this.sqlConn.ConnectionString = Utiles._connection.ConnectionString.ToString();

            //---- GSG (17/06/2014)
            if (psIdCampCab.Trim() == "")
                psIdCampCab = "-1";

            _indexCampanyaSelected = indexCampanyaSelected; //---- GSG (06/10/2016)


            dataGridView1.RowsDefaultCellStyle.SelectionBackColor = Utiles.ColorSelecionFilaDataGrid;

            sIdCampanya = row["idCampanya"].ToString();
            NombreCampanya = row["NombreCampanya"].ToString();
            NumMinOblis = row["iNumMinOblis"].ToString();
            ImporteMinObli = row["fImporteMinObli"].ToString();
            dImporteBrutoMinObli = double.Parse(row["fImporteMinObliBruto"].ToString());
            iCantidadTotalMinObli = int.Parse(row["iNumMinOblisTotal"].ToString());
            //_bArrastre = bool.Parse(row["bArrastre"].ToString()); //---- GSG (22/01/2015)
            
            //---- GSG (22/10/2013)
            _sTipoPedido = TipoPedido;

            //---- GSG (17/06/2014)
            sIdCampCab = psIdCampCab;

            //---- GSG (02/01/2023)
            _iMinimos = iMinimos;

            //---- GSG (06/06/2013)
            //LlenarCombos();
            //---- GSG (07/07/2017)
            //LlenarCombos(iIdCliente);
            LlenarCombos(iIdCliente, mayorista);

            dataGridViewPedido = dg;
            idGrupMat = int.Parse(idGrup);

            //---- GSG (03/01/2012)
            _bCampanyaExtra = esDescExtra(indexCampanyaSelected);
            _fDescExtra = double.Parse(sDescExtra);
            _fDescExtraRestante = double.Parse(sDescExtraRestante);
            if (_bCampanyaExtra)
            {
                txbDescExtra.Text = sDescExtra;
                txbDescExtraRestante.Text = sDescExtraRestante;
                lblDescExtra.Visible = true;
                txbDescExtra.Visible = true;
                lblDescExtraRestante.Visible = true;
                txbDescExtraRestante.Visible = true;
                //---- GSG (23/04/2013)
                txbMG.Text = "0%";
            }
            else
            {
                lblDescExtra.Visible = false;
                txbDescExtra.Visible = false;
                lblDescExtraRestante.Visible = false;
                txbDescExtraRestante.Visible = false;
                //---- GSG (23/04/2013)
                txbMG.Text = String.Format("{0:#,0.##}%", row["fDescMinGar"].ToString());
            }

            //---- GSG (31/07/2012)
            _iIdCliente = iIdCliente;
            //---- GSG (26/05/2015)
            _bCampanyaMatsNoVenta = esCampanyaMatsNoVenta(indexCampanyaSelected);

            //---- GSG (29/09/2015)
            initRegalosEspeciales();
            _descMaxRegaloEspecial = (double)valorDescMaxRegaloEspecial(indexCampanyaSelected);
            _bEsEsp = esCampanyaRegaloEspecial(indexCampanyaSelected);

            //---- GSG (08/07/2016)
            _lPairsMatCampEnPed = pList;

            if (_lPairsMatCampEnPed.Count > 0)
            {
                _bArrastre = PedidoEsNoDecsMedio(out _iIdCampanyaPedidoNoDescMedio);  //---- VLP (26/07/2023)
            }

            comprobaCompromisoMinimos(); //---- GSG (02/01/2023)
        }

        //---- GSG (29/09/2015)
        private void initRegalosEspeciales()
        {
            // Obtenemos los regalos especiales
            this.sqldaMatsEspeciales.Fill(this.dsPedidos1);
            if (dsPedidos1.RegalosEspeciales.Rows.Count > 0)
            {
                string sIdAnt = "";
                string sId = "";
                RegaloEspecial regEsp = null;
                for (int i = 0; i <= dsPedidos1.RegalosEspeciales.Rows.Count - 1; i++)
                {
                    sId = dsPedidos1.RegalosEspeciales.Rows[i]["iIdCamp"].ToString();
                    if (sId != sIdAnt)
                    {
                        regEsp = new RegaloEspecial();
                        regEsp.codCamp = sId;
                        sIdAnt = sId;
                    }

                    if (int.Parse(dsPedidos1.RegalosEspeciales.Rows[i]["iDeCampRegalo"].ToString()) == 1)
                        regEsp.matsRegalo.Add(dsPedidos1.RegalosEspeciales.Rows[i]["iIdMaterial"].ToString());
                    else
                        regEsp.matsEsp.Add(dsPedidos1.RegalosEspeciales.Rows[i]["iIdMaterial"].ToString());

                    //Después de leer el último lo insertamos en la lista
                    if ((i + 1 < dsPedidos1.RegalosEspeciales.Rows.Count - 1 && dsPedidos1.RegalosEspeciales.Rows[i + 1]["iIdCamp"].ToString() != sId) ||
                        (i + 1 == dsPedidos1.RegalosEspeciales.Rows.Count))
                        _lRegaloEspecial.Add(regEsp);
                }
            }

        }


        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Método necesario para admitir el Diseñador, no se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMMateriales));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.txbsCodNacional = new System.Windows.Forms.TextBox();
            this.txbsDescripcion = new System.Windows.Forms.TextBox();
            this.txbsIdMaterial = new System.Windows.Forms.TextBox();
            this.btBuscar = new System.Windows.Forms.Button();
            this.txbsPrecio = new System.Windows.Forms.TextBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblCNacional = new System.Windows.Forms.Label();
            this.lblCMaterial = new System.Windows.Forms.Label();
            this.sqlDaListaMateriales = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlConn = new System.Data.SqlClient.SqlConnection();
            this.sqlCmdGetIsDescuentoMaxInformed = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdGetMaterialesNoRentabilidad = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdGetMaterialesNoMargen = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdGetMatsARARnoCli = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdGetMatsMRARnoCli = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdGetTiposMatAPintar = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdGetMatsSoloClub = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdGetRentabilidadDescripcion = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdGetRentabilidadColor = new System.Data.SqlClient.SqlCommand();
            this.sqlGetRentMinCamp = new System.Data.SqlClient.SqlCommand();
            this.sqlGetPaquete = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdGetCampanyasNoRentabilidad = new System.Data.SqlClient.SqlCommand();
            this.dsPedidos1 = new GESTCRM.Formularios.DataSets.dsPedidos();
            this.btCancelar = new System.Windows.Forms.Button();
            this.btAceptar = new System.Windows.Forms.Button();
            this.pnBusqueda = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dsMateriales1 = new GESTCRM.Formularios.dsMateriales();
            this.lblNumReg = new System.Windows.Forms.Label();
            this.labelGradient2 = new GESTCRM.Controles.LabelGradient();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbSelTodo = new System.Windows.Forms.CheckBox();
            this.cbTipoProd = new System.Windows.Forms.ComboBox();
            this.listaTipoProductoInformeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.txbsDescripcionParaGrid = new System.Windows.Forms.TextBox();
            this.cbTipoMaterial = new System.Windows.Forms.ComboBox();
            this.listaTipoMaterialInformeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.cmBoxMostrar = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCampanya = new System.Windows.Forms.Label();
            this.lblCantidadMinima = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btCambiar = new System.Windows.Forms.Button();
            this.cBoxCampanyas = new System.Windows.Forms.ComboBox();
            this.sqldaListaCampanyas = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCmdListaCampanyasNEW = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdListaCampanyas = new System.Data.SqlClient.SqlCommand();
            this.sqlCommand3 = new System.Data.SqlClient.SqlCommand();
            this.txbDescExtra = new System.Windows.Forms.TextBox();
            this.lblDescExtra = new System.Windows.Forms.Label();
            this.dsFormularios1 = new GESTCRM.Formularios.dsFormularios();
            this.txbDescExtraRestante = new System.Windows.Forms.TextBox();
            this.lblDescExtraRestante = new System.Windows.Forms.Label();
            this.txbDto = new System.Windows.Forms.TextBox();
            this.txbImporte = new System.Windows.Forms.TextBox();
            this.lblImporte = new System.Windows.Forms.Label();
            this.txbImporteBruto = new System.Windows.Forms.TextBox();
            this.lblImporteBruto = new System.Windows.Forms.Label();
            this.txbRentabilidad = new System.Windows.Forms.TextBox();
            this.txtRentabilidad = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblAfectaRentabilidad = new System.Windows.Forms.Label();
            this.sqldaListaMatsCliLastYear = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCmdListaMatsCliLastYear = new System.Data.SqlClient.SqlCommand();
            this.label4 = new System.Windows.Forms.Label();
            this.txbMG = new System.Windows.Forms.TextBox();
            this.sqldaListaAccionesMarkCli = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommandListaAccionesMarkCli = new System.Data.SqlClient.SqlCommand();
            this.sqldaListaAccMarkCamp = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCmdListaAccMarkCamp = new System.Data.SqlClient.SqlCommand();
            this.dsClientes1 = new GESTCRM.Formularios.DataSets.dsClientes();
            this.dsAccionesMarketing1 = new GESTCRM.Formularios.DataSets.dsAccionesMarketing();
            this.sqldaListaAccMarkCampByCli = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCmdListaAccMarkCampByCli = new System.Data.SqlClient.SqlCommand();
            this.sqlcmdExisteCampInAccMarkCamp = new System.Data.SqlClient.SqlCommand();
            this.sqldaListaUltimosAvisos = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCmdListaUltimosAvisos = new System.Data.SqlClient.SqlCommand();
            this.sqldaListaTipoMaterialInforme = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCmdListaTipoMaterialInforme = new System.Data.SqlClient.SqlCommand();
            this.sqldaListaTipoProductoInforme = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCmdListaTipoProductoInforme = new System.Data.SqlClient.SqlCommand();
            this.lblObservaciones = new System.Windows.Forms.Label();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.btQtyAdquiridas = new System.Windows.Forms.Button();
            this.btDescsAplicados = new System.Windows.Forms.Button();
            this.sqlGetSumaUnidades = new System.Data.SqlClient.SqlCommand();
            this.sqlGetTipoPedidoSumaUnidades = new System.Data.SqlClient.SqlCommand();
            this.sqlEsDelegadoCanarias = new System.Data.SqlClient.SqlCommand();
            this.sqldaMatsEspeciales = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCmdMatsEspeciales = new System.Data.SqlClient.SqlCommand();
            this.sqldaListaTarjetasClienteActivas = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCmdListaTarjetasClienteActivas = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdGetIsDescuentoMinGarInformed = new System.Data.SqlClient.SqlCommand();
            this.lblVigencia = new System.Windows.Forms.Label();
            this.lblValorVigencia = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txbTotalUnidades = new System.Windows.Forms.TextBox();
            this.txtMargen = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txbTotalUnidadesConBase = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.selected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Rendabilitat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.margen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MargenLin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sObligatorio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sCodNacional = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sMaterial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sIdMaterial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fDescuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fDescuentoMaximo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fCoste = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnidMinimas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ordre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sTipoMat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dEntrega = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iPendientes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iUnidadesEnfajado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iCajaCompleta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fDescMat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fDescMatTRA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fPVP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fPVPIVA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iStockCanarias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iPendientesCanarias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unisPedidas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoClasificacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sTipoProdInformes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iCantidadBase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dsPedidos1)).BeginInit();
            this.pnBusqueda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsMateriales1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listaTipoProductoInformeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listaTipoMaterialInformeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsFormularios1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsClientes1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAccionesMarketing1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecio.Location = new System.Drawing.Point(224, 50);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(57, 20);
            this.lblPrecio.TabIndex = 12;
            this.lblPrecio.Text = "Precio:";
            // 
            // txbsCodNacional
            // 
            this.txbsCodNacional.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbsCodNacional.Location = new System.Drawing.Point(116, 18);
            this.txbsCodNacional.Name = "txbsCodNacional";
            this.txbsCodNacional.Size = new System.Drawing.Size(106, 26);
            this.txbsCodNacional.TabIndex = 0;
            // 
            // txbsDescripcion
            // 
            this.txbsDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbsDescripcion.Location = new System.Drawing.Point(318, 18);
            this.txbsDescripcion.Name = "txbsDescripcion";
            this.txbsDescripcion.Size = new System.Drawing.Size(337, 26);
            this.txbsDescripcion.TabIndex = 1;
            this.txbsDescripcion.TextChanged += new System.EventHandler(this.txbsDescripcion_TextChanged);
            // 
            // txbsIdMaterial
            // 
            this.txbsIdMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbsIdMaterial.Location = new System.Drawing.Point(115, 47);
            this.txbsIdMaterial.Name = "txbsIdMaterial";
            this.txbsIdMaterial.Size = new System.Drawing.Size(106, 26);
            this.txbsIdMaterial.TabIndex = 2;
            // 
            // btBuscar
            // 
            this.btBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btBuscar.Image = global::GESTCRM.Properties.Resources.search_032x032;
            this.btBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btBuscar.Location = new System.Drawing.Point(1321, 21);
            this.btBuscar.Name = "btBuscar";
            this.btBuscar.Size = new System.Drawing.Size(104, 38);
            this.btBuscar.TabIndex = 4;
            this.btBuscar.Text = "&Buscar ";
            this.btBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btBuscar.UseVisualStyleBackColor = true;
            this.btBuscar.Click += new System.EventHandler(this.btBuscar_Click);
            // 
            // txbsPrecio
            // 
            this.txbsPrecio.CausesValidation = false;
            this.txbsPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbsPrecio.Location = new System.Drawing.Point(281, 47);
            this.txbsPrecio.Name = "txbsPrecio";
            this.txbsPrecio.Size = new System.Drawing.Size(69, 26);
            this.txbsPrecio.TabIndex = 3;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescripcion.Location = new System.Drawing.Point(224, 21);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(96, 20);
            this.lblDescripcion.TabIndex = 3;
            this.lblDescripcion.Text = "Descripción:";
            // 
            // lblCNacional
            // 
            this.lblCNacional.AutoSize = true;
            this.lblCNacional.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCNacional.Location = new System.Drawing.Point(6, 21);
            this.lblCNacional.Name = "lblCNacional";
            this.lblCNacional.Size = new System.Drawing.Size(111, 20);
            this.lblCNacional.TabIndex = 2;
            this.lblCNacional.Text = "Cód. Nacional:";
            // 
            // lblCMaterial
            // 
            this.lblCMaterial.AutoSize = true;
            this.lblCMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCMaterial.Location = new System.Drawing.Point(6, 50);
            this.lblCMaterial.Name = "lblCMaterial";
            this.lblCMaterial.Size = new System.Drawing.Size(102, 20);
            this.lblCMaterial.TabIndex = 1;
            this.lblCMaterial.Text = "Cód Material:";
            // 
            // sqlDaListaMateriales
            // 
            this.sqlDaListaMateriales.SelectCommand = this.sqlSelectCommand1;
            this.sqlDaListaMateriales.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaMateriales", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("sIdMaterial", "sIdMaterial"),
                        new System.Data.Common.DataColumnMapping("sMaterial", "sMaterial"),
                        new System.Data.Common.DataColumnMapping("sCodNacional", "sCodNacional"),
                        new System.Data.Common.DataColumnMapping("fPrecio", "fPrecio"),
                        new System.Data.Common.DataColumnMapping("selected", "selected"),
                        new System.Data.Common.DataColumnMapping("iStock", "iStock"),
                        new System.Data.Common.DataColumnMapping("dEntrega", "dEntrega"),
                        new System.Data.Common.DataColumnMapping("iPendientes", "iPendientes"),
                        new System.Data.Common.DataColumnMapping("sTipoMatInformes", "sTipoMatInformes")})});
            // 
            // sqlSelectCommand1
            // 
            this.sqlSelectCommand1.CommandText = "ListaMaterialesDesCamp";
            this.sqlSelectCommand1.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand1.Connection = this.sqlConn;
            this.sqlSelectCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@sIdMaterial", System.Data.SqlDbType.VarChar, 18),
            new System.Data.SqlClient.SqlParameter("@sMaterial", System.Data.SqlDbType.VarChar, 50),
            new System.Data.SqlClient.SqlParameter("@sCodNacional", System.Data.SqlDbType.VarChar, 6),
            new System.Data.SqlClient.SqlParameter("@fPrecio", System.Data.SqlDbType.Float, 8),
            new System.Data.SqlClient.SqlParameter("@sIdRed", System.Data.SqlDbType.VarChar, 4),
            new System.Data.SqlClient.SqlParameter("@iIdCamp", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@sidCampanya", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@sIdTipoPedido", System.Data.SqlDbType.VarChar, 4),
            new System.Data.SqlClient.SqlParameter("@iIdDelegado", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4)});
            // 
            // sqlConn
            // 
            this.sqlConn.FireInfoMessageEventOnUserErrors = false;
            // 
            // sqlCmdGetIsDescuentoMaxInformed
            // 
            this.sqlCmdGetIsDescuentoMaxInformed.CommandText = "GetInformaDesc";
            this.sqlCmdGetIsDescuentoMaxInformed.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdGetIsDescuentoMaxInformed.Connection = this.sqlConn;
            this.sqlCmdGetIsDescuentoMaxInformed.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@idCampanya", System.Data.SqlDbType.VarChar, 10)});
            // 
            // sqlCmdGetMaterialesNoRentabilidad
            // 
            this.sqlCmdGetMaterialesNoRentabilidad.CommandText = "[GetMaterialesNoRentabilidad]";
            this.sqlCmdGetMaterialesNoRentabilidad.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdGetMaterialesNoRentabilidad.Connection = this.sqlConn;
            this.sqlCmdGetMaterialesNoRentabilidad.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@sIdPedido", System.Data.SqlDbType.VarChar, 12)});
            // 
            // sqlCmdGetMaterialesNoMargen
            // 
            this.sqlCmdGetMaterialesNoMargen.CommandText = "[GetMaterialesNoMargen]";
            this.sqlCmdGetMaterialesNoMargen.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdGetMaterialesNoMargen.Connection = this.sqlConn;
            this.sqlCmdGetMaterialesNoMargen.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null)});
            // 
            // sqlCmdGetMatsARARnoCli
            // 
            this.sqlCmdGetMatsARARnoCli.CommandText = "[ListaMatsARARnoCli]";
            this.sqlCmdGetMatsARARnoCli.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdGetMatsARARnoCli.Connection = this.sqlConn;
            this.sqlCmdGetMatsARARnoCli.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4)});
            // 
            // sqlCmdGetMatsMRARnoCli
            // 
            this.sqlCmdGetMatsMRARnoCli.CommandText = "[ListaMatsMRARnoCli]";
            this.sqlCmdGetMatsMRARnoCli.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdGetMatsMRARnoCli.Connection = this.sqlConn;
            this.sqlCmdGetMatsMRARnoCli.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4)});
            // 
            // sqlCmdGetTiposMatAPintar
            // 
            this.sqlCmdGetTiposMatAPintar.CommandText = "[GetTiposMatAPintar]";
            this.sqlCmdGetTiposMatAPintar.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdGetTiposMatAPintar.Connection = this.sqlConn;
            this.sqlCmdGetTiposMatAPintar.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@tipo", System.Data.SqlDbType.Int, 4)});
            // 
            // sqlCmdGetMatsSoloClub
            // 
            this.sqlCmdGetMatsSoloClub.CommandText = "[ListaMatsSoloClubByCli]";
            this.sqlCmdGetMatsSoloClub.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdGetMatsSoloClub.Connection = this.sqlConn;
            this.sqlCmdGetMatsSoloClub.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4)});
            // 
            // sqlCmdGetRentabilidadDescripcion
            // 
            this.sqlCmdGetRentabilidadDescripcion.CommandText = "dbo.[GetRentabilidadDescripcion]";
            this.sqlCmdGetRentabilidadDescripcion.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdGetRentabilidadDescripcion.Connection = this.sqlConn;
            this.sqlCmdGetRentabilidadDescripcion.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@Rentabilidad", System.Data.SqlDbType.Float, 8),
            new System.Data.SqlClient.SqlParameter("@fecha", System.Data.SqlDbType.DateTime, 8)});
            // 
            // sqlCmdGetRentabilidadColor
            // 
            this.sqlCmdGetRentabilidadColor.CommandText = "dbo.[GetRentabilidadColor]";
            this.sqlCmdGetRentabilidadColor.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdGetRentabilidadColor.Connection = this.sqlConn;
            this.sqlCmdGetRentabilidadColor.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@Rentabilidad", System.Data.SqlDbType.Float, 8),
            new System.Data.SqlClient.SqlParameter("@fecha", System.Data.SqlDbType.DateTime, 8)});
            // 
            // sqlGetRentMinCamp
            // 
            this.sqlGetRentMinCamp.CommandText = "dbo.[GetRentMinCamp]";
            this.sqlGetRentMinCamp.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlGetRentMinCamp.Connection = this.sqlConn;
            this.sqlGetRentMinCamp.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@idCampanya", System.Data.SqlDbType.VarChar, 10)});
            // 
            // sqlGetPaquete
            // 
            this.sqlGetPaquete.CommandText = "dbo.[GetPaquete]";
            this.sqlGetPaquete.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlGetPaquete.Connection = this.sqlConn;
            this.sqlGetPaquete.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdMaterial", System.Data.SqlDbType.VarChar, 18),
            new System.Data.SqlClient.SqlParameter("@iIdCamp", System.Data.SqlDbType.VarChar, 10)});
            // 
            // sqlCmdGetCampanyasNoRentabilidad
            // 
            this.sqlCmdGetCampanyasNoRentabilidad.CommandText = "[GetCampanyasNoRentabilidad]";
            this.sqlCmdGetCampanyasNoRentabilidad.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdGetCampanyasNoRentabilidad.Connection = this.sqlConn;
            // 
            // dsPedidos1
            // 
            this.dsPedidos1.DataSetName = "dsPedidos";
            this.dsPedidos1.Locale = new System.Globalization.CultureInfo("en-US");
            this.dsPedidos1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btCancelar
            // 
            this.btCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCancelar.Image = global::GESTCRM.Properties.Resources.cancel_032x032;
            this.btCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btCancelar.Location = new System.Drawing.Point(130, 652);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(110, 36);
            this.btCancelar.TabIndex = 3;
            this.btCancelar.Text = "&Cancelar";
            this.btCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // btAceptar
            // 
            this.btAceptar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAceptar.Image = global::GESTCRM.Properties.Resources.ok_032x032;
            this.btAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btAceptar.Location = new System.Drawing.Point(1233, 652);
            this.btAceptar.Name = "btAceptar";
            this.btAceptar.Size = new System.Drawing.Size(110, 36);
            this.btAceptar.TabIndex = 2;
            this.btAceptar.Text = "&Aceptar ";
            this.btAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btAceptar.UseVisualStyleBackColor = true;
            this.btAceptar.Click += new System.EventHandler(this.btAceptar_Click);
            // 
            // pnBusqueda
            // 
            this.pnBusqueda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnBusqueda.Controls.Add(this.dataGridView1);
            this.pnBusqueda.Controls.Add(this.lblNumReg);
            this.pnBusqueda.Controls.Add(this.labelGradient2);
            this.pnBusqueda.Location = new System.Drawing.Point(12, 211);
            this.pnBusqueda.Name = "pnBusqueda";
            this.pnBusqueda.Size = new System.Drawing.Size(1444, 427);
            this.pnBusqueda.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.selected,
            this.Rendabilitat,
            this.margen,
            this.MargenLin,
            this.sObligatorio,
            this.sCodNacional,
            this.sMaterial,
            this.sIdMaterial,
            this.fPrecio,
            this.iCantidad,
            this.fDescuento,
            this.fDescuentoMaximo,
            this.fCoste,
            this.UnidMinimas,
            this.Ordre,
            this.sTipoMat,
            this.iStock,
            this.dEntrega,
            this.iPendientes,
            this.iUnidadesEnfajado,
            this.iCajaCompleta,
            this.fDescMat,
            this.fDescMatTRA,
            this.fPVP,
            this.fPVPIVA,
            this.iStockCanarias,
            this.iPendientesCanarias,
            this.unisPedidas,
            this.TipoClasificacion,
            this.sTipoProdInformes,
            this.iCantidadBase});
            this.dataGridView1.DataMember = "ListaMateriales";
            this.dataGridView1.DataSource = this.dsMateriales1;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle14;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 18);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 25;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1442, 407);
            this.dataGridView1.TabIndex = 90;
            this.dataGridView1.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView1_CellBeginEdit);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            this.dataGridView1.CellParsing += new System.Windows.Forms.DataGridViewCellParsingEventHandler(this.dataGridView1_CellParsing);
            this.dataGridView1.Sorted += new System.EventHandler(this.dataGridView1_Sorted);
            this.dataGridView1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dataGridView1_KeyPress);
            this.dataGridView1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseUp);
            // 
            // dsMateriales1
            // 
            this.dsMateriales1.DataSetName = "dsMateriales";
            this.dsMateriales1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lblNumReg
            // 
            this.lblNumReg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.lblNumReg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblNumReg.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumReg.ForeColor = System.Drawing.Color.Black;
            this.lblNumReg.Location = new System.Drawing.Point(1377, 0);
            this.lblNumReg.Name = "lblNumReg";
            this.lblNumReg.Size = new System.Drawing.Size(64, 18);
            this.lblNumReg.TabIndex = 89;
            this.lblNumReg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelGradient2
            // 
            this.labelGradient2.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelGradient2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGradient2.ForeColor = System.Drawing.Color.White;
            this.labelGradient2.GradientColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.labelGradient2.GradientColorTwo = System.Drawing.Color.White;
            this.labelGradient2.Location = new System.Drawing.Point(0, 0);
            this.labelGradient2.Name = "labelGradient2";
            this.labelGradient2.Size = new System.Drawing.Size(1442, 18);
            this.labelGradient2.TabIndex = 88;
            this.labelGradient2.Text = "Resultado de la búsqueda";
            this.labelGradient2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbSelTodo);
            this.groupBox2.Controls.Add(this.cbTipoProd);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txbsDescripcionParaGrid);
            this.groupBox2.Controls.Add(this.cbTipoMaterial);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cmBoxMostrar);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.lblCNacional);
            this.groupBox2.Controls.Add(this.lblDescripcion);
            this.groupBox2.Controls.Add(this.txbsDescripcion);
            this.groupBox2.Controls.Add(this.txbsCodNacional);
            this.groupBox2.Controls.Add(this.btBuscar);
            this.groupBox2.Controls.Add(this.lblPrecio);
            this.groupBox2.Controls.Add(this.lblCMaterial);
            this.groupBox2.Controls.Add(this.txbsIdMaterial);
            this.groupBox2.Controls.Add(this.txbsPrecio);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 87);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1444, 76);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filtros";
            // 
            // cbSelTodo
            // 
            this.cbSelTodo.AutoSize = true;
            this.cbSelTodo.Location = new System.Drawing.Point(1070, 21);
            this.cbSelTodo.Name = "cbSelTodo";
            this.cbSelTodo.Size = new System.Drawing.Size(135, 20);
            this.cbSelTodo.TabIndex = 123;
            this.cbSelTodo.Text = "Seleccionar Todo";
            this.cbSelTodo.UseVisualStyleBackColor = true;
            this.cbSelTodo.Visible = false;
            this.cbSelTodo.CheckStateChanged += new System.EventHandler(this.cbSelTodo_CheckStateChanged);
            // 
            // cbTipoProd
            // 
            this.cbTipoProd.DataSource = this.listaTipoProductoInformeBindingSource;
            this.cbTipoProd.DisplayMember = "sLiteral";
            this.cbTipoProd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoProd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTipoProd.FormattingEnabled = true;
            this.cbTipoProd.Location = new System.Drawing.Point(813, 47);
            this.cbTipoProd.Name = "cbTipoProd";
            this.cbTipoProd.Size = new System.Drawing.Size(232, 28);
            this.cbTipoProd.TabIndex = 122;
            this.cbTipoProd.ValueMember = "sValor";
            // 
            // listaTipoProductoInformeBindingSource
            // 
            this.listaTipoProductoInformeBindingSource.DataMember = "ListaTipoProductoInforme";
            this.listaTipoProductoInformeBindingSource.DataSource = this.dsMateriales1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(733, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 20);
            this.label6.TabIndex = 121;
            this.label6.Text = "Tipo Prod.:";
            // 
            // txbsDescripcionParaGrid
            // 
            this.txbsDescripcionParaGrid.Location = new System.Drawing.Point(664, 21);
            this.txbsDescripcionParaGrid.Name = "txbsDescripcionParaGrid";
            this.txbsDescripcionParaGrid.Size = new System.Drawing.Size(33, 22);
            this.txbsDescripcionParaGrid.TabIndex = 120;
            this.txbsDescripcionParaGrid.Visible = false;
            // 
            // cbTipoMaterial
            // 
            this.cbTipoMaterial.DataSource = this.listaTipoMaterialInformeBindingSource;
            this.cbTipoMaterial.DisplayMember = "sLiteral";
            this.cbTipoMaterial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTipoMaterial.FormattingEnabled = true;
            this.cbTipoMaterial.Location = new System.Drawing.Point(428, 47);
            this.cbTipoMaterial.Name = "cbTipoMaterial";
            this.cbTipoMaterial.Size = new System.Drawing.Size(299, 28);
            this.cbTipoMaterial.TabIndex = 16;
            this.cbTipoMaterial.ValueMember = "sValor";
            // 
            // listaTipoMaterialInformeBindingSource
            // 
            this.listaTipoMaterialInformeBindingSource.DataMember = "ListaTipoMaterialInforme";
            this.listaTipoMaterialInformeBindingSource.DataSource = this.dsMateriales1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(350, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 20);
            this.label5.TabIndex = 15;
            this.label5.Text = "Tipo Mat.:";
            // 
            // cmBoxMostrar
            // 
            this.cmBoxMostrar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmBoxMostrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmBoxMostrar.FormattingEnabled = true;
            this.cmBoxMostrar.Items.AddRange(new object[] {
            "Todos",
            "Seleccionados",
            "Aviso",
            "Robos"});
            this.cmBoxMostrar.Location = new System.Drawing.Point(863, 17);
            this.cmBoxMostrar.Name = "cmBoxMostrar";
            this.cmBoxMostrar.Size = new System.Drawing.Size(182, 28);
            this.cmBoxMostrar.TabIndex = 14;
            this.cmBoxMostrar.SelectedIndexChanged += new System.EventHandler(this.cmBoxMostrar_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(796, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 20);
            this.label2.TabIndex = 13;
            this.label2.Text = "Mostrar:";
            // 
            // lblCampanya
            // 
            this.lblCampanya.AutoSize = true;
            this.lblCampanya.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCampanya.Location = new System.Drawing.Point(111, 5);
            this.lblCampanya.Name = "lblCampanya";
            this.lblCampanya.Size = new System.Drawing.Size(257, 25);
            this.lblCampanya.TabIndex = 6;
            this.lblCampanya.Text = "Campaña seleccionada";
            // 
            // lblCantidadMinima
            // 
            this.lblCantidadMinima.AutoSize = true;
            this.lblCantidadMinima.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidadMinima.Location = new System.Drawing.Point(10, 69);
            this.lblCantidadMinima.Name = "lblCantidadMinima";
            this.lblCantidadMinima.Size = new System.Drawing.Size(123, 16);
            this.lblCantidadMinima.TabIndex = 7;
            this.lblCantidadMinima.Text = "Cantidad mínima";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 25);
            this.label1.TabIndex = 8;
            this.label1.Text = "Campaña:";
            // 
            // btCambiar
            // 
            this.btCambiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btCambiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCambiar.Image = global::GESTCRM.Properties.Resources.reload_032x032;
            this.btCambiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btCambiar.Location = new System.Drawing.Point(1334, 16);
            this.btCambiar.Name = "btCambiar";
            this.btCambiar.Size = new System.Drawing.Size(103, 36);
            this.btCambiar.TabIndex = 9;
            this.btCambiar.Text = "Ca&mbiar";
            this.btCambiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btCambiar.UseVisualStyleBackColor = true;
            this.btCambiar.Click += new System.EventHandler(this.btCambiar_Click);
            // 
            // cBoxCampanyas
            // 
            this.cBoxCampanyas.BackColor = System.Drawing.Color.White;
            this.cBoxCampanyas.DisplayMember = "NombreCampanya";
            this.cBoxCampanyas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxCampanyas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cBoxCampanyas.ForeColor = System.Drawing.Color.Black;
            this.cBoxCampanyas.Location = new System.Drawing.Point(923, 18);
            this.cBoxCampanyas.Name = "cBoxCampanyas";
            this.cBoxCampanyas.Size = new System.Drawing.Size(401, 28);
            this.cBoxCampanyas.TabIndex = 10;
            this.cBoxCampanyas.ValueMember = "idCampanya";
            // 
            // sqldaListaCampanyas
            // 
            this.sqldaListaCampanyas.SelectCommand = this.sqlCmdListaCampanyasNEW;
            this.sqldaListaCampanyas.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaTipoCampPedido", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("idCampanya", "idCampanya"),
                        new System.Data.Common.DataColumnMapping("NombreCampanya", "NombreCampanya"),
                        new System.Data.Common.DataColumnMapping("bSeleccionable", "bSeleccionable"),
                        new System.Data.Common.DataColumnMapping("iNumMinOblis", "iNumMinOblis"),
                        new System.Data.Common.DataColumnMapping("fImporteMinObli", "fImporteMinObli"),
                        new System.Data.Common.DataColumnMapping("fDescImpNeto", "fDescImpNeto"),
                        new System.Data.Common.DataColumnMapping("bArrastre", "bArrastre"),
                        new System.Data.Common.DataColumnMapping("sObservaciones", "sObservaciones")})});
            // 
            // sqlCmdListaCampanyasNEW
            // 
            this.sqlCmdListaCampanyasNEW.CommandText = "ListaCampanyasVer";
            this.sqlCmdListaCampanyasNEW.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdListaCampanyasNEW.Connection = this.sqlConn;
            this.sqlCmdListaCampanyasNEW.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@sIdDelegado", System.Data.SqlDbType.VarChar, 4),
            new System.Data.SqlClient.SqlParameter("@sIdTipoPedido", System.Data.SqlDbType.VarChar, 4),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sIdMayorista", System.Data.SqlDbType.VarChar, 20)});
            // 
            // sqlCmdListaCampanyas
            // 
            this.sqlCmdListaCampanyas.CommandText = "ListaCampanyasSegunClienteYVisibles";
            this.sqlCmdListaCampanyas.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdListaCampanyas.Connection = this.sqlConn;
            this.sqlCmdListaCampanyas.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iTipo", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@idCampanya", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@tipoCampanya", System.Data.SqlDbType.VarChar, 3),
            new System.Data.SqlClient.SqlParameter("@sIdDelegado", System.Data.SqlDbType.VarChar, 4),
            new System.Data.SqlClient.SqlParameter("@sIdTipoPedido", System.Data.SqlDbType.VarChar, 4),
            new System.Data.SqlClient.SqlParameter("@idCampanyaCab", System.Data.SqlDbType.VarChar, 10)});
            // 
            // sqlCommand3
            // 
            this.sqlCommand3.CommandText = "ListaCampanyas";
            this.sqlCommand3.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCommand3.Connection = this.sqlConn;
            this.sqlCommand3.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null)});
            // 
            // txbDescExtra
            // 
            this.txbDescExtra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txbDescExtra.Cursor = System.Windows.Forms.Cursors.Default;
            this.txbDescExtra.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbDescExtra.Location = new System.Drawing.Point(876, 64);
            this.txbDescExtra.Margin = new System.Windows.Forms.Padding(2);
            this.txbDescExtra.Name = "txbDescExtra";
            this.txbDescExtra.ReadOnly = true;
            this.txbDescExtra.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txbDescExtra.Size = new System.Drawing.Size(97, 26);
            this.txbDescExtra.TabIndex = 101;
            this.txbDescExtra.TabStop = false;
            this.txbDescExtra.Text = "0";
            // 
            // lblDescExtra
            // 
            this.lblDescExtra.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescExtra.ForeColor = System.Drawing.Color.Red;
            this.lblDescExtra.Location = new System.Drawing.Point(723, 65);
            this.lblDescExtra.Name = "lblDescExtra";
            this.lblDescExtra.Size = new System.Drawing.Size(152, 26);
            this.lblDescExtra.TabIndex = 100;
            this.lblDescExtra.Text = "Desc. Extra Total:";
            this.lblDescExtra.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dsFormularios1
            // 
            this.dsFormularios1.DataSetName = "dsFormularios";
            this.dsFormularios1.Locale = new System.Globalization.CultureInfo("es-ES");
            this.dsFormularios1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // txbDescExtraRestante
            // 
            this.txbDescExtraRestante.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txbDescExtraRestante.Cursor = System.Windows.Forms.Cursors.Default;
            this.txbDescExtraRestante.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbDescExtraRestante.Location = new System.Drawing.Point(1162, 65);
            this.txbDescExtraRestante.Margin = new System.Windows.Forms.Padding(2);
            this.txbDescExtraRestante.Name = "txbDescExtraRestante";
            this.txbDescExtraRestante.ReadOnly = true;
            this.txbDescExtraRestante.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txbDescExtraRestante.Size = new System.Drawing.Size(97, 26);
            this.txbDescExtraRestante.TabIndex = 103;
            this.txbDescExtraRestante.TabStop = false;
            this.txbDescExtraRestante.Text = "0";
            // 
            // lblDescExtraRestante
            // 
            this.lblDescExtraRestante.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescExtraRestante.ForeColor = System.Drawing.Color.Red;
            this.lblDescExtraRestante.Location = new System.Drawing.Point(977, 63);
            this.lblDescExtraRestante.Name = "lblDescExtraRestante";
            this.lblDescExtraRestante.Size = new System.Drawing.Size(186, 31);
            this.lblDescExtraRestante.TabIndex = 102;
            this.lblDescExtraRestante.Text = "Desc. Extra Restante:";
            this.lblDescExtraRestante.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txbDto
            // 
            this.txbDto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txbDto.Cursor = System.Windows.Forms.Cursors.Default;
            this.txbDto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbDto.Location = new System.Drawing.Point(498, 165);
            this.txbDto.Margin = new System.Windows.Forms.Padding(2);
            this.txbDto.Name = "txbDto";
            this.txbDto.ReadOnly = true;
            this.txbDto.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txbDto.Size = new System.Drawing.Size(66, 26);
            this.txbDto.TabIndex = 107;
            this.txbDto.TabStop = false;
            this.txbDto.Text = "0%";
            // 
            // txbImporte
            // 
            this.txbImporte.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txbImporte.Cursor = System.Windows.Forms.Cursors.Default;
            this.txbImporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbImporte.Location = new System.Drawing.Point(105, 165);
            this.txbImporte.Margin = new System.Windows.Forms.Padding(2);
            this.txbImporte.Name = "txbImporte";
            this.txbImporte.ReadOnly = true;
            this.txbImporte.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txbImporte.Size = new System.Drawing.Size(97, 26);
            this.txbImporte.TabIndex = 106;
            this.txbImporte.TabStop = false;
            this.txbImporte.Text = "0 €";
            // 
            // lblImporte
            // 
            this.lblImporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImporte.ForeColor = System.Drawing.Color.Red;
            this.lblImporte.Location = new System.Drawing.Point(18, 168);
            this.lblImporte.Name = "lblImporte";
            this.lblImporte.Size = new System.Drawing.Size(90, 19);
            this.lblImporte.TabIndex = 104;
            this.lblImporte.Text = "Imp. neto:";
            this.lblImporte.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txbImporteBruto
            // 
            this.txbImporteBruto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txbImporteBruto.Cursor = System.Windows.Forms.Cursors.Default;
            this.txbImporteBruto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbImporteBruto.Location = new System.Drawing.Point(297, 165);
            this.txbImporteBruto.Margin = new System.Windows.Forms.Padding(2);
            this.txbImporteBruto.Name = "txbImporteBruto";
            this.txbImporteBruto.ReadOnly = true;
            this.txbImporteBruto.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txbImporteBruto.Size = new System.Drawing.Size(97, 26);
            this.txbImporteBruto.TabIndex = 112;
            this.txbImporteBruto.TabStop = false;
            this.txbImporteBruto.Text = "0 €";
            // 
            // lblImporteBruto
            // 
            this.lblImporteBruto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImporteBruto.ForeColor = System.Drawing.Color.Red;
            this.lblImporteBruto.Location = new System.Drawing.Point(203, 168);
            this.lblImporteBruto.Name = "lblImporteBruto";
            this.lblImporteBruto.Size = new System.Drawing.Size(96, 19);
            this.lblImporteBruto.TabIndex = 105;
            this.lblImporteBruto.Text = "Imp. bruto:";
            this.lblImporteBruto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txbRentabilidad
            // 
            this.txbRentabilidad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txbRentabilidad.Cursor = System.Windows.Forms.Cursors.Default;
            this.txbRentabilidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbRentabilidad.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txbRentabilidad.Location = new System.Drawing.Point(1126, 166);
            this.txbRentabilidad.Margin = new System.Windows.Forms.Padding(2);
            this.txbRentabilidad.Name = "txbRentabilidad";
            this.txbRentabilidad.ReadOnly = true;
            this.txbRentabilidad.Size = new System.Drawing.Size(70, 26);
            this.txbRentabilidad.TabIndex = 109;
            this.txbRentabilidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtRentabilidad
            // 
            this.txtRentabilidad.Location = new System.Drawing.Point(1126, 165);
            this.txtRentabilidad.Name = "txtRentabilidad";
            this.txtRentabilidad.Size = new System.Drawing.Size(10, 26);
            this.txtRentabilidad.TabIndex = 110;
            this.txtRentabilidad.Visible = false;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(396, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 19);
            this.label3.TabIndex = 111;
            this.label3.Text = "Des. medio:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(988, 169);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(141, 19);
            this.label9.TabIndex = 108;
            this.label9.Text = "Rent. Selección:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAfectaRentabilidad
            // 
            this.lblAfectaRentabilidad.AutoSize = true;
            this.lblAfectaRentabilidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAfectaRentabilidad.Location = new System.Drawing.Point(989, 192);
            this.lblAfectaRentabilidad.Name = "lblAfectaRentabilidad";
            this.lblAfectaRentabilidad.Size = new System.Drawing.Size(271, 16);
            this.lblAfectaRentabilidad.TabIndex = 113;
            this.lblAfectaRentabilidad.Text = "No afecta a la rentabilidad del pedido";
            // 
            // sqldaListaMatsCliLastYear
            // 
            this.sqldaListaMatsCliLastYear.SelectCommand = this.sqlCmdListaMatsCliLastYear;
            // 
            // sqlCmdListaMatsCliLastYear
            // 
            this.sqlCmdListaMatsCliLastYear.CommandText = "ListaMatsCliLastYear";
            this.sqlCmdListaMatsCliLastYear.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdListaMatsCliLastYear.Connection = this.sqlConn;
            this.sqlCmdListaMatsCliLastYear.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int)});
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(566, 168);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 19);
            this.label4.TabIndex = 114;
            this.label4.Text = "Min. Gar.:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txbMG
            // 
            this.txbMG.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txbMG.Cursor = System.Windows.Forms.Cursors.Default;
            this.txbMG.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbMG.Location = new System.Drawing.Point(650, 165);
            this.txbMG.Margin = new System.Windows.Forms.Padding(2);
            this.txbMG.Name = "txbMG";
            this.txbMG.ReadOnly = true;
            this.txbMG.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txbMG.Size = new System.Drawing.Size(66, 26);
            this.txbMG.TabIndex = 115;
            this.txbMG.TabStop = false;
            this.txbMG.Text = "0%";
            // 
            // sqldaListaAccionesMarkCli
            // 
            this.sqldaListaAccionesMarkCli.SelectCommand = this.sqlSelectCommandListaAccionesMarkCli;
            this.sqldaListaAccionesMarkCli.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaAccionesMarkClientes", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iIdAccion", "iIdAccion"),
                        new System.Data.Common.DataColumnMapping("sIdAccion", "sIdAccion"),
                        new System.Data.Common.DataColumnMapping("dFechaEntrega", "dFechaEntrega"),
                        new System.Data.Common.DataColumnMapping("tFechaEntrega", "tFechaEntrega"),
                        new System.Data.Common.DataColumnMapping("fCantidad", "fCantidad"),
                        new System.Data.Common.DataColumnMapping("sCCoste", "sCCoste"),
                        new System.Data.Common.DataColumnMapping("tObservEntrega", "tObservEntrega")})});
            // 
            // sqlSelectCommandListaAccionesMarkCli
            // 
            this.sqlSelectCommandListaAccionesMarkCli.CommandText = "[ListaAccionesMarkClientesCodigoOK]";
            this.sqlSelectCommandListaAccionesMarkCli.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommandListaAccionesMarkCli.Connection = this.sqlConn;
            this.sqlSelectCommandListaAccionesMarkCli.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4)});
            // 
            // sqldaListaAccMarkCamp
            // 
            this.sqldaListaAccMarkCamp.SelectCommand = this.sqlCmdListaAccMarkCamp;
            this.sqldaListaAccMarkCamp.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaMAccMarkCamp", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iIdAccion", "iIdAccion"),
                        new System.Data.Common.DataColumnMapping("sIdAccion", "sIdAccion"),
                        new System.Data.Common.DataColumnMapping("sDescAccion", "sDescAccion"),
                        new System.Data.Common.DataColumnMapping("idCampanya", "idCampanya"),
                        new System.Data.Common.DataColumnMapping("NombreCampanya", "NombreCampanya"),
                        new System.Data.Common.DataColumnMapping("fDescuento", "fDescuento"),
                        new System.Data.Common.DataColumnMapping("iEstado", "iEstado"),
                        new System.Data.Common.DataColumnMapping("Estado", "Estado"),
                        new System.Data.Common.DataColumnMapping("dFUM", "dFUM")})});
            // 
            // sqlCmdListaAccMarkCamp
            // 
            this.sqlCmdListaAccMarkCamp.CommandText = "[ListaMAccMarkCamp]";
            this.sqlCmdListaAccMarkCamp.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdListaAccMarkCamp.Connection = this.sqlConn;
            this.sqlCmdListaAccMarkCamp.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@sIdAccion", System.Data.SqlDbType.VarChar, 15),
            new System.Data.SqlClient.SqlParameter("@sDescAccion", System.Data.SqlDbType.VarChar, 50),
            new System.Data.SqlClient.SqlParameter("@IdCampanya", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@NombreCampanya", System.Data.SqlDbType.VarChar, 100),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt)});
            // 
            // dsClientes1
            // 
            this.dsClientes1.DataSetName = "dsClientes";
            this.dsClientes1.Locale = new System.Globalization.CultureInfo("en-US");
            this.dsClientes1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dsAccionesMarketing1
            // 
            this.dsAccionesMarketing1.DataSetName = "dsAccionesMarketing";
            this.dsAccionesMarketing1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sqldaListaAccMarkCampByCli
            // 
            this.sqldaListaAccMarkCampByCli.SelectCommand = this.sqlCmdListaAccMarkCampByCli;
            this.sqldaListaAccMarkCampByCli.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaMAccMarkCampSolsCods", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("sIdAccion", "sIdAccion"),
                        new System.Data.Common.DataColumnMapping("idCampanya", "idCampanya")})});
            // 
            // sqlCmdListaAccMarkCampByCli
            // 
            this.sqlCmdListaAccMarkCampByCli.CommandText = "[ListaAccMarkCampByCli]";
            this.sqlCmdListaAccMarkCampByCli.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdListaAccMarkCampByCli.Connection = this.sqlConn;
            this.sqlCmdListaAccMarkCampByCli.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4)});
            // 
            // sqlcmdExisteCampInAccMarkCamp
            // 
            this.sqlcmdExisteCampInAccMarkCamp.CommandText = "[ExisteCampInAccMarkCamp]";
            this.sqlcmdExisteCampInAccMarkCamp.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlcmdExisteCampInAccMarkCamp.Connection = this.sqlConn;
            this.sqlcmdExisteCampInAccMarkCamp.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@idCampanya", System.Data.SqlDbType.VarChar, 10)});
            // 
            // sqldaListaUltimosAvisos
            // 
            this.sqldaListaUltimosAvisos.SelectCommand = this.sqlCmdListaUltimosAvisos;
            this.sqldaListaUltimosAvisos.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaUltimosAvisos", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("sIdProducto", "sIdProducto"),
                        new System.Data.Common.DataColumnMapping("sDescripcion", "sDescripcion"),
                        new System.Data.Common.DataColumnMapping("sIdMaterial", "sIdMaterial"),
                        new System.Data.Common.DataColumnMapping("sMaterial", "sMaterial")})});
            // 
            // sqlCmdListaUltimosAvisos
            // 
            this.sqlCmdListaUltimosAvisos.CommandText = "[ListaUltimosAvisos]";
            this.sqlCmdListaUltimosAvisos.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdListaUltimosAvisos.Connection = this.sqlConn;
            this.sqlCmdListaUltimosAvisos.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@sIdProducto", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@sDescripcion", System.Data.SqlDbType.VarChar, 50),
            new System.Data.SqlClient.SqlParameter("@sIdMaterial", System.Data.SqlDbType.VarChar, 18),
            new System.Data.SqlClient.SqlParameter("@sMaterial", System.Data.SqlDbType.VarChar, 50)});
            // 
            // sqldaListaTipoMaterialInforme
            // 
            this.sqldaListaTipoMaterialInforme.SelectCommand = this.sqlCmdListaTipoMaterialInforme;
            this.sqldaListaTipoMaterialInforme.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaTipoMaterialInforme", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("sValor", "sValor"),
                        new System.Data.Common.DataColumnMapping("sLiteral", "sLiteral")})});
            // 
            // sqlCmdListaTipoMaterialInforme
            // 
            this.sqlCmdListaTipoMaterialInforme.CommandText = "[ListaTipoMaterialInforme]";
            this.sqlCmdListaTipoMaterialInforme.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdListaTipoMaterialInforme.Connection = this.sqlConn;
            this.sqlCmdListaTipoMaterialInforme.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null)});
            // 
            // sqldaListaTipoProductoInforme
            // 
            this.sqldaListaTipoProductoInforme.SelectCommand = this.sqlCmdListaTipoProductoInforme;
            this.sqldaListaTipoProductoInforme.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaTipoProductoInforme", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("sValor", "sValor"),
                        new System.Data.Common.DataColumnMapping("sLiteral", "sLiteral")})});
            // 
            // sqlCmdListaTipoProductoInforme
            // 
            this.sqlCmdListaTipoProductoInforme.CommandText = "[ListaTipoProductoInforme]";
            this.sqlCmdListaTipoProductoInforme.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdListaTipoProductoInforme.Connection = this.sqlConn;
            this.sqlCmdListaTipoProductoInforme.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null)});
            // 
            // lblObservaciones
            // 
            this.lblObservaciones.AutoSize = true;
            this.lblObservaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblObservaciones.Location = new System.Drawing.Point(10, 38);
            this.lblObservaciones.Name = "lblObservaciones";
            this.lblObservaciones.Size = new System.Drawing.Size(122, 20);
            this.lblObservaciones.TabIndex = 116;
            this.lblObservaciones.Text = "Observaciones :";
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(230)))), ((int)(((byte)(239)))));
            this.txtObservaciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtObservaciones.ForeColor = System.Drawing.Color.Red;
            this.txtObservaciones.Location = new System.Drawing.Point(130, 33);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.ReadOnly = true;
            this.txtObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtObservaciones.Size = new System.Drawing.Size(469, 37);
            this.txtObservaciones.TabIndex = 117;
            // 
            // btQtyAdquiridas
            // 
            this.btQtyAdquiridas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btQtyAdquiridas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btQtyAdquiridas.Image = ((System.Drawing.Image)(resources.GetObject("btQtyAdquiridas.Image")));
            this.btQtyAdquiridas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btQtyAdquiridas.Location = new System.Drawing.Point(475, 652);
            this.btQtyAdquiridas.Name = "btQtyAdquiridas";
            this.btQtyAdquiridas.Size = new System.Drawing.Size(192, 29);
            this.btQtyAdquiridas.TabIndex = 118;
            this.btQtyAdquiridas.Text = "Ca&ntidades Adquiridas";
            this.btQtyAdquiridas.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btQtyAdquiridas.UseVisualStyleBackColor = true;
            this.btQtyAdquiridas.Visible = false;
            this.btQtyAdquiridas.Click += new System.EventHandler(this.btQtyAdquiridas_Click);
            // 
            // btDescsAplicados
            // 
            this.btDescsAplicados.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btDescsAplicados.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDescsAplicados.Image = ((System.Drawing.Image)(resources.GetObject("btDescsAplicados.Image")));
            this.btDescsAplicados.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btDescsAplicados.Location = new System.Drawing.Point(684, 652);
            this.btDescsAplicados.Name = "btDescsAplicados";
            this.btDescsAplicados.Size = new System.Drawing.Size(191, 29);
            this.btDescsAplicados.TabIndex = 119;
            this.btDescsAplicados.Text = "&Descuentos Aplicados";
            this.btDescsAplicados.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btDescsAplicados.UseVisualStyleBackColor = true;
            this.btDescsAplicados.Visible = false;
            this.btDescsAplicados.Click += new System.EventHandler(this.btDescsAplicados_Click);
            // 
            // sqlGetSumaUnidades
            // 
            this.sqlGetSumaUnidades.CommandText = "dbo.[GetSumaUnidades]";
            this.sqlGetSumaUnidades.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlGetSumaUnidades.Connection = this.sqlConn;
            this.sqlGetSumaUnidades.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdMaterial", System.Data.SqlDbType.VarChar, 18),
            new System.Data.SqlClient.SqlParameter("@iIdCamp", System.Data.SqlDbType.VarChar, 10)});
            // 
            // sqlGetTipoPedidoSumaUnidades
            // 
            this.sqlGetTipoPedidoSumaUnidades.CommandText = "dbo.[GetTipoSumaUnidades]";
            this.sqlGetTipoPedidoSumaUnidades.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlGetTipoPedidoSumaUnidades.Connection = this.sqlConn;
            this.sqlGetTipoPedidoSumaUnidades.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdMaterial", System.Data.SqlDbType.VarChar, 18),
            new System.Data.SqlClient.SqlParameter("@iIdCamp", System.Data.SqlDbType.VarChar, 10)});
            // 
            // sqlEsDelegadoCanarias
            // 
            this.sqlEsDelegadoCanarias.CommandText = "dbo.[EsDelegadoCanarias]";
            this.sqlEsDelegadoCanarias.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlEsDelegadoCanarias.Connection = this.sqlConn;
            this.sqlEsDelegadoCanarias.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdDelegado", System.Data.SqlDbType.Int, 4)});
            // 
            // sqldaMatsEspeciales
            // 
            this.sqldaMatsEspeciales.SelectCommand = this.sqlCmdMatsEspeciales;
            this.sqldaMatsEspeciales.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "RegalosEspeciales", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iIdCamp", "iIdCamp"),
                        new System.Data.Common.DataColumnMapping("iIdMaterial", "iIdMaterial"),
                        new System.Data.Common.DataColumnMapping("iDeCampRegalo", "iDeCampRegalo")})});
            // 
            // sqlCmdMatsEspeciales
            // 
            this.sqlCmdMatsEspeciales.CommandText = "[ListaRegalosEspeciales]";
            this.sqlCmdMatsEspeciales.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdMatsEspeciales.Connection = this.sqlConn;
            this.sqlCmdMatsEspeciales.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null)});
            // 
            // sqldaListaTarjetasClienteActivas
            // 
            this.sqldaListaTarjetasClienteActivas.SelectCommand = this.sqlCmdListaTarjetasClienteActivas;
            this.sqldaListaTarjetasClienteActivas.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaTarjetasClienteActivas", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("sIdMaterial", "sIdMaterial")})});
            // 
            // sqlCmdListaTarjetasClienteActivas
            // 
            this.sqlCmdListaTarjetasClienteActivas.CommandText = "[ListaTarjetasClienteActivas]";
            this.sqlCmdListaTarjetasClienteActivas.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdListaTarjetasClienteActivas.Connection = this.sqlConn;
            this.sqlCmdListaTarjetasClienteActivas.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4)});
            // 
            // sqlCmdGetIsDescuentoMinGarInformed
            // 
            this.sqlCmdGetIsDescuentoMinGarInformed.CommandText = "[GetDescMinGar]";
            this.sqlCmdGetIsDescuentoMinGarInformed.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdGetIsDescuentoMinGarInformed.Connection = this.sqlConn;
            this.sqlCmdGetIsDescuentoMinGarInformed.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@idCampanya", System.Data.SqlDbType.VarChar, 10)});
            // 
            // lblVigencia
            // 
            this.lblVigencia.AutoSize = true;
            this.lblVigencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVigencia.Location = new System.Drawing.Point(605, 34);
            this.lblVigencia.Name = "lblVigencia";
            this.lblVigencia.Size = new System.Drawing.Size(95, 18);
            this.lblVigencia.TabIndex = 120;
            this.lblVigencia.Text = "Fin Vigencia :";
            // 
            // lblValorVigencia
            // 
            this.lblValorVigencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorVigencia.ForeColor = System.Drawing.Color.Red;
            this.lblValorVigencia.Location = new System.Drawing.Point(605, 53);
            this.lblValorVigencia.Name = "lblValorVigencia";
            this.lblValorVigencia.Size = new System.Drawing.Size(103, 19);
            this.lblValorVigencia.TabIndex = 121;
            this.lblValorVigencia.Text = "01/01/2000";
            this.lblValorVigencia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(717, 168);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(128, 19);
            this.label7.TabIndex = 122;
            this.label7.Text = "Tot. Unid.:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txbTotalUnidades
            // 
            this.txbTotalUnidades.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txbTotalUnidades.Cursor = System.Windows.Forms.Cursors.Default;
            this.txbTotalUnidades.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbTotalUnidades.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txbTotalUnidades.Location = new System.Drawing.Point(804, 165);
            this.txbTotalUnidades.Margin = new System.Windows.Forms.Padding(2);
            this.txbTotalUnidades.Name = "txbTotalUnidades";
            this.txbTotalUnidades.ReadOnly = true;
            this.txbTotalUnidades.Size = new System.Drawing.Size(72, 26);
            this.txbTotalUnidades.TabIndex = 123;
            this.txbTotalUnidades.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtMargen
            // 
            this.txtMargen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtMargen.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtMargen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMargen.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtMargen.Location = new System.Drawing.Point(1333, 168);
            this.txtMargen.Margin = new System.Windows.Forms.Padding(2);
            this.txtMargen.Name = "txtMargen";
            this.txtMargen.ReadOnly = true;
            this.txtMargen.Size = new System.Drawing.Size(104, 26);
            this.txtMargen.TabIndex = 127;
            this.txtMargen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMargen.DoubleClick += new System.EventHandler(this.txtMargen_DoubleClick);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(1200, 164);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(159, 30);
            this.label8.TabIndex = 126;
            this.label8.Text = "Puntos Selecc.:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txbTotalUnidadesConBase
            // 
            this.txbTotalUnidadesConBase.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txbTotalUnidadesConBase.Cursor = System.Windows.Forms.Cursors.Default;
            this.txbTotalUnidadesConBase.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbTotalUnidadesConBase.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txbTotalUnidadesConBase.Location = new System.Drawing.Point(880, 165);
            this.txbTotalUnidadesConBase.Margin = new System.Windows.Forms.Padding(2);
            this.txbTotalUnidadesConBase.Name = "txbTotalUnidadesConBase";
            this.txbTotalUnidadesConBase.ReadOnly = true;
            this.txbTotalUnidadesConBase.Size = new System.Drawing.Size(72, 26);
            this.txbTotalUnidadesConBase.TabIndex = 128;
            this.txbTotalUnidadesConBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(767, 192);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(178, 16);
            this.label10.TabIndex = 129;
            this.label10.Text = "Seleccionadas    Reales";
            // 
            // selected
            // 
            this.selected.DataPropertyName = "selected";
            this.selected.FalseValue = "False";
            this.selected.Frozen = true;
            this.selected.HeaderText = "";
            this.selected.IndeterminateValue = "False";
            this.selected.MinimumWidth = 8;
            this.selected.Name = "selected";
            this.selected.ReadOnly = true;
            this.selected.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.selected.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.selected.TrueValue = "True";
            this.selected.Width = 20;
            // 
            // Rendabilitat
            // 
            this.Rendabilitat.Frozen = true;
            this.Rendabilitat.HeaderText = "_";
            this.Rendabilitat.MinimumWidth = 8;
            this.Rendabilitat.Name = "Rendabilitat";
            this.Rendabilitat.ReadOnly = true;
            this.Rendabilitat.Width = 40;
            // 
            // margen
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            this.margen.DefaultCellStyle = dataGridViewCellStyle3;
            this.margen.Frozen = true;
            this.margen.HeaderText = "Puntos";
            this.margen.MinimumWidth = 8;
            this.margen.Name = "margen";
            this.margen.ReadOnly = true;
            this.margen.Width = 80;
            // 
            // MargenLin
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            this.MargenLin.DefaultCellStyle = dataGridViewCellStyle4;
            this.MargenLin.Frozen = true;
            this.MargenLin.HeaderText = "Puntos Línea";
            this.MargenLin.MinimumWidth = 8;
            this.MargenLin.Name = "MargenLin";
            this.MargenLin.ReadOnly = true;
            this.MargenLin.Width = 120;
            // 
            // sObligatorio
            // 
            this.sObligatorio.DataPropertyName = "sObligatorio";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.sObligatorio.DefaultCellStyle = dataGridViewCellStyle5;
            this.sObligatorio.Frozen = true;
            this.sObligatorio.HeaderText = "Obligatorio";
            this.sObligatorio.MinimumWidth = 8;
            this.sObligatorio.Name = "sObligatorio";
            this.sObligatorio.ReadOnly = true;
            this.sObligatorio.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.sObligatorio.Visible = false;
            this.sObligatorio.Width = 75;
            // 
            // sCodNacional
            // 
            this.sCodNacional.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.sCodNacional.DataPropertyName = "sCodNacional";
            this.sCodNacional.Frozen = true;
            this.sCodNacional.HeaderText = "C. Nacional";
            this.sCodNacional.MinimumWidth = 70;
            this.sCodNacional.Name = "sCodNacional";
            this.sCodNacional.ReadOnly = true;
            this.sCodNacional.Width = 150;
            // 
            // sMaterial
            // 
            this.sMaterial.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.sMaterial.DataPropertyName = "sMaterial";
            this.sMaterial.Frozen = true;
            this.sMaterial.HeaderText = "Descripción";
            this.sMaterial.MinimumWidth = 8;
            this.sMaterial.Name = "sMaterial";
            this.sMaterial.ReadOnly = true;
            this.sMaterial.Width = 400;
            // 
            // sIdMaterial
            // 
            this.sIdMaterial.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.sIdMaterial.DataPropertyName = "sIdMaterial";
            this.sIdMaterial.Frozen = true;
            this.sIdMaterial.HeaderText = "Material";
            this.sIdMaterial.MinimumWidth = 8;
            this.sIdMaterial.Name = "sIdMaterial";
            this.sIdMaterial.ReadOnly = true;
            this.sIdMaterial.Width = 80;
            // 
            // fPrecio
            // 
            this.fPrecio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.fPrecio.DataPropertyName = "fPrecio";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.fPrecio.DefaultCellStyle = dataGridViewCellStyle6;
            this.fPrecio.Frozen = true;
            this.fPrecio.HeaderText = "Precio";
            this.fPrecio.MinimumWidth = 8;
            this.fPrecio.Name = "fPrecio";
            this.fPrecio.ReadOnly = true;
            this.fPrecio.Width = 70;
            // 
            // iCantidad
            // 
            this.iCantidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.iCantidad.DataPropertyName = "iCantidad";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iCantidad.DefaultCellStyle = dataGridViewCellStyle7;
            this.iCantidad.Frozen = true;
            this.iCantidad.HeaderText = "Cantidad";
            this.iCantidad.MinimumWidth = 8;
            this.iCantidad.Name = "iCantidad";
            this.iCantidad.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.iCantidad.Width = 80;
            // 
            // fDescuento
            // 
            this.fDescuento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.fDescuento.DataPropertyName = "fDescuento";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.NullValue = null;
            this.fDescuento.DefaultCellStyle = dataGridViewCellStyle8;
            this.fDescuento.Frozen = true;
            this.fDescuento.HeaderText = "Desc.";
            this.fDescuento.MinimumWidth = 8;
            this.fDescuento.Name = "fDescuento";
            this.fDescuento.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.fDescuento.Width = 60;
            // 
            // fDescuentoMaximo
            // 
            this.fDescuentoMaximo.DataPropertyName = "fDescuentoMaximo";
            this.fDescuentoMaximo.Frozen = true;
            this.fDescuentoMaximo.HeaderText = "Desc. Max.";
            this.fDescuentoMaximo.MinimumWidth = 8;
            this.fDescuentoMaximo.Name = "fDescuentoMaximo";
            this.fDescuentoMaximo.ReadOnly = true;
            this.fDescuentoMaximo.Visible = false;
            this.fDescuentoMaximo.Width = 90;
            // 
            // fCoste
            // 
            this.fCoste.DataPropertyName = "fCoste";
            this.fCoste.Frozen = true;
            this.fCoste.HeaderText = "fCoste";
            this.fCoste.MinimumWidth = 8;
            this.fCoste.Name = "fCoste";
            this.fCoste.ReadOnly = true;
            this.fCoste.Visible = false;
            this.fCoste.Width = 150;
            // 
            // UnidMinimas
            // 
            this.UnidMinimas.DataPropertyName = "UnidMinimas";
            this.UnidMinimas.Frozen = true;
            this.UnidMinimas.HeaderText = "UnidMinimas";
            this.UnidMinimas.MinimumWidth = 8;
            this.UnidMinimas.Name = "UnidMinimas";
            this.UnidMinimas.ReadOnly = true;
            this.UnidMinimas.Visible = false;
            this.UnidMinimas.Width = 150;
            // 
            // Ordre
            // 
            this.Ordre.DataPropertyName = "Ordre";
            this.Ordre.Frozen = true;
            this.Ordre.HeaderText = "Ordre";
            this.Ordre.MinimumWidth = 8;
            this.Ordre.Name = "Ordre";
            this.Ordre.ReadOnly = true;
            this.Ordre.Visible = false;
            this.Ordre.Width = 150;
            // 
            // sTipoMat
            // 
            this.sTipoMat.DataPropertyName = "sTipoMat";
            this.sTipoMat.Frozen = true;
            this.sTipoMat.HeaderText = "sTipoMat";
            this.sTipoMat.MinimumWidth = 8;
            this.sTipoMat.Name = "sTipoMat";
            this.sTipoMat.ReadOnly = true;
            this.sTipoMat.Visible = false;
            this.sTipoMat.Width = 150;
            // 
            // iStock
            // 
            this.iStock.DataPropertyName = "iStock";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "N0";
            dataGridViewCellStyle9.NullValue = null;
            this.iStock.DefaultCellStyle = dataGridViewCellStyle9;
            this.iStock.Frozen = true;
            this.iStock.HeaderText = "Stock";
            this.iStock.MinimumWidth = 8;
            this.iStock.Name = "iStock";
            this.iStock.ReadOnly = true;
            this.iStock.Width = 90;
            // 
            // dEntrega
            // 
            this.dEntrega.DataPropertyName = "dEntrega";
            this.dEntrega.Frozen = true;
            this.dEntrega.HeaderText = "Entrega";
            this.dEntrega.MinimumWidth = 8;
            this.dEntrega.Name = "dEntrega";
            this.dEntrega.ReadOnly = true;
            this.dEntrega.Visible = false;
            this.dEntrega.Width = 80;
            // 
            // iPendientes
            // 
            this.iPendientes.DataPropertyName = "iPendientes";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "N0";
            dataGridViewCellStyle10.NullValue = null;
            this.iPendientes.DefaultCellStyle = dataGridViewCellStyle10;
            this.iPendientes.Frozen = true;
            this.iPendientes.HeaderText = "Pendientes";
            this.iPendientes.MinimumWidth = 8;
            this.iPendientes.Name = "iPendientes";
            this.iPendientes.ReadOnly = true;
            this.iPendientes.Visible = false;
            this.iPendientes.Width = 80;
            // 
            // iUnidadesEnfajado
            // 
            this.iUnidadesEnfajado.DataPropertyName = "iUnidadesEnfajado";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.iUnidadesEnfajado.DefaultCellStyle = dataGridViewCellStyle11;
            this.iUnidadesEnfajado.Frozen = true;
            this.iUnidadesEnfajado.HeaderText = "Enfajado";
            this.iUnidadesEnfajado.MinimumWidth = 8;
            this.iUnidadesEnfajado.Name = "iUnidadesEnfajado";
            this.iUnidadesEnfajado.ReadOnly = true;
            this.iUnidadesEnfajado.Width = 80;
            // 
            // iCajaCompleta
            // 
            this.iCajaCompleta.DataPropertyName = "iCajaCompleta";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.iCajaCompleta.DefaultCellStyle = dataGridViewCellStyle12;
            this.iCajaCompleta.Frozen = true;
            this.iCajaCompleta.HeaderText = "Caja Compl.";
            this.iCajaCompleta.MinimumWidth = 8;
            this.iCajaCompleta.Name = "iCajaCompleta";
            this.iCajaCompleta.ReadOnly = true;
            this.iCajaCompleta.Width = 150;
            // 
            // fDescMat
            // 
            this.fDescMat.DataPropertyName = "fDescMat";
            this.fDescMat.Frozen = true;
            this.fDescMat.HeaderText = "fDescMat";
            this.fDescMat.MinimumWidth = 8;
            this.fDescMat.Name = "fDescMat";
            this.fDescMat.ReadOnly = true;
            this.fDescMat.Visible = false;
            this.fDescMat.Width = 150;
            // 
            // fDescMatTRA
            // 
            this.fDescMatTRA.DataPropertyName = "fDescMatTRA";
            this.fDescMatTRA.Frozen = true;
            this.fDescMatTRA.HeaderText = "fDescMatTRA";
            this.fDescMatTRA.MinimumWidth = 8;
            this.fDescMatTRA.Name = "fDescMatTRA";
            this.fDescMatTRA.ReadOnly = true;
            this.fDescMatTRA.Visible = false;
            this.fDescMatTRA.Width = 150;
            // 
            // fPVP
            // 
            this.fPVP.DataPropertyName = "fPVP";
            this.fPVP.Frozen = true;
            this.fPVP.HeaderText = "fPVP";
            this.fPVP.MinimumWidth = 8;
            this.fPVP.Name = "fPVP";
            this.fPVP.ReadOnly = true;
            this.fPVP.Visible = false;
            this.fPVP.Width = 150;
            // 
            // fPVPIVA
            // 
            this.fPVPIVA.DataPropertyName = "fPVPIVA";
            this.fPVPIVA.Frozen = true;
            this.fPVPIVA.HeaderText = "fPVPIVA";
            this.fPVPIVA.MinimumWidth = 8;
            this.fPVPIVA.Name = "fPVPIVA";
            this.fPVPIVA.ReadOnly = true;
            this.fPVPIVA.Visible = false;
            this.fPVPIVA.Width = 150;
            // 
            // iStockCanarias
            // 
            this.iStockCanarias.DataPropertyName = "iStockCanarias";
            this.iStockCanarias.Frozen = true;
            this.iStockCanarias.HeaderText = "iStockCanarias";
            this.iStockCanarias.MinimumWidth = 8;
            this.iStockCanarias.Name = "iStockCanarias";
            this.iStockCanarias.ReadOnly = true;
            this.iStockCanarias.Visible = false;
            this.iStockCanarias.Width = 150;
            // 
            // iPendientesCanarias
            // 
            this.iPendientesCanarias.DataPropertyName = "iPendientesCanarias";
            this.iPendientesCanarias.Frozen = true;
            this.iPendientesCanarias.HeaderText = "iPendientesCanarias";
            this.iPendientesCanarias.MinimumWidth = 8;
            this.iPendientesCanarias.Name = "iPendientesCanarias";
            this.iPendientesCanarias.ReadOnly = true;
            this.iPendientesCanarias.Visible = false;
            this.iPendientesCanarias.Width = 150;
            // 
            // unisPedidas
            // 
            this.unisPedidas.DataPropertyName = "unisPedidas";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.unisPedidas.DefaultCellStyle = dataGridViewCellStyle13;
            this.unisPedidas.Frozen = true;
            this.unisPedidas.HeaderText = "Pedidas";
            this.unisPedidas.MinimumWidth = 8;
            this.unisPedidas.Name = "unisPedidas";
            this.unisPedidas.Visible = false;
            this.unisPedidas.Width = 80;
            // 
            // TipoClasificacion
            // 
            this.TipoClasificacion.DataPropertyName = "TipoClasificacion";
            this.TipoClasificacion.Frozen = true;
            this.TipoClasificacion.HeaderText = "Tipo Material";
            this.TipoClasificacion.MinimumWidth = 8;
            this.TipoClasificacion.Name = "TipoClasificacion";
            this.TipoClasificacion.Width = 150;
            // 
            // sTipoProdInformes
            // 
            this.sTipoProdInformes.DataPropertyName = "sTipoProdInformes";
            this.sTipoProdInformes.Frozen = true;
            this.sTipoProdInformes.HeaderText = "Tipo Producto";
            this.sTipoProdInformes.MinimumWidth = 8;
            this.sTipoProdInformes.Name = "sTipoProdInformes";
            this.sTipoProdInformes.Visible = false;
            this.sTipoProdInformes.Width = 160;
            // 
            // iCantidadBase
            // 
            this.iCantidadBase.DataPropertyName = "iCantidadBase";
            this.iCantidadBase.Frozen = true;
            this.iCantidadBase.HeaderText = "iCantidadBase";
            this.iCantidadBase.MinimumWidth = 8;
            this.iCantidadBase.Name = "iCantidadBase";
            this.iCantidadBase.ReadOnly = true;
            this.iCantidadBase.Visible = false;
            this.iCantidadBase.Width = 150;
            // 
            // frmMMateriales
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 19);
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(230)))), ((int)(((byte)(239)))));
            this.ClientSize = new System.Drawing.Size(1467, 716);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txbTotalUnidadesConBase);
            this.Controls.Add(this.txtMargen);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txbTotalUnidades);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblValorVigencia);
            this.Controls.Add(this.lblVigencia);
            this.Controls.Add(this.btDescsAplicados);
            this.Controls.Add(this.btQtyAdquiridas);
            this.Controls.Add(this.txtObservaciones);
            this.Controls.Add(this.lblObservaciones);
            this.Controls.Add(this.txbMG);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblAfectaRentabilidad);
            this.Controls.Add(this.txbDto);
            this.Controls.Add(this.txbImporte);
            this.Controls.Add(this.lblImporte);
            this.Controls.Add(this.txbImporteBruto);
            this.Controls.Add(this.lblImporteBruto);
            this.Controls.Add(this.txtRentabilidad);
            this.Controls.Add(this.txbRentabilidad);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txbDescExtra);
            this.Controls.Add(this.txbDescExtraRestante);
            this.Controls.Add(this.lblDescExtraRestante);
            this.Controls.Add(this.lblDescExtra);
            this.Controls.Add(this.cBoxCampanyas);
            this.Controls.Add(this.btCambiar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblCantidadMinima);
            this.Controls.Add(this.lblCampanya);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.pnBusqueda);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.btAceptar);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMMateriales";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Buscar materiales";
            this.Load += new System.EventHandler(this.frmMMateriales_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsPedidos1)).EndInit();
            this.pnBusqueda.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsMateriales1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listaTipoProductoInformeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listaTipoMaterialInformeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsFormularios1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsClientes1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAccionesMarketing1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private void frmMMateriales_Load(object sender, System.EventArgs e)
        {
            try
            {
                lblCampanya.Text = NombreCampanya;

                if (int.Parse(NumMinOblis) > 0)
                {
                    lblCantidadMinima.Text = String.Format("(Debe seleccionar al menos {0} materiales)", NumMinOblis);
                    lblCantidadMinima.Visible = true;
                }
                else
                    lblCantidadMinima.Visible = false;

                txtObservaciones.Text = sObservaciones; //---- GSG (25/09/2013)

                cmBoxMostrar.SelectedIndex = 0;

                cbSelTodo.Checked = false; //---- GSG (02/01/2023)
                if (_iMinimos == 1)
                    cbSelTodo.Visible = true;
                else
                    cbSelTodo.Visible = false;

                //---- GSG (06/10/2016)
                formatFinVigencia(_indexCampanyaSelected);



                //---- GSG CECL 19/05/2016
                if (System.Configuration.ConfigurationManager.AppSettings["TipoDelegadoPedidosCentral"].ToString() == Comun.K_CECL)
                    sqlDaListaMateriales.SelectCommand.CommandText = "[ListaMaterialesDesCampCECL]";
                else
                    sqlDaListaMateriales.SelectCommand.CommandText = "[ListaMaterialesDesCamp]";
                //---- FI GSG CECL



                //Pasamos el parámetro
                this.sqlDaListaMateriales.SelectCommand.Parameters["@iIdCamp"].Value = sIdCampanya;
                //---- GSG (08/04/2016)
                this.sqlDaListaMateriales.SelectCommand.Parameters["@sIdTipoPedido"].Value = _sTipoPedido;
                this.sqlDaListaMateriales.SelectCommand.Parameters["@iIdDelegado"].Value = Clases.Configuracion.iIdDelegado;

                //---- GSG (26/02/2018)
                this.sqlDaListaMateriales.SelectCommand.Parameters["@iIdCliente"].Value = _iIdCliente;
                


                //Llenamos la lista de materiales
                this.sqlDaListaMateriales.Fill(dsMateriales1);


                //---- GSG (19/10/2015)
                // Si la campaña es de tarjetas mostrar sólo las activas

                //---- GSG (23/11/2015)
                String[] sTarj = Configuracion.sIdCampanyaTarjetasCliente.Split(',');
                bool bTrobada = false;
                for (int i = 0; i < sTarj.Length; i++)
                {
                    if (sIdCampanya == sTarj[i])
                    {
                        bTrobada = true;
                        break;
                    }
                }

                //if (sIdCampanya == GESTCRM.Clases.Configuracion.sIdCampanyaTarjetasCliente)
                if (bTrobada)
                {
                    int numActivas = GetTarjetasClienteActivas(_iIdCliente);
                    string listaMats = "";

                    if (numActivas > 0)
                    {
                        foreach (GESTCRM.Formularios.DataSets.dsClientes.ListaTarjetasClienteActivasRow row in dsClientes1.ListaTarjetasClienteActivas.Rows)
                        {
                            listaMats += row.sIdMaterial;
                            listaMats += ",";
                        }

                        for (int i = dsMateriales1.ListaMateriales.Rows.Count - 1; i >= 0; i--)
                        {
                            dsMateriales.ListaMaterialesRow row = (dsMateriales.ListaMaterialesRow)dsMateriales1.ListaMateriales.Rows[i];
                            if (listaMats.IndexOf(row.sIdMaterial) < 0)
                                dsMateriales1.ListaMateriales.Rows.Remove(row);
                        }
                    }
                    else
                        dsMateriales1.ListaMateriales.Clear();
                }


                //---- GSG (25/11/2014)
                bool bCanario = EsDelegadoCanarias(Clases.Configuracion.iIdDelegado);


                foreach (DataGridViewRow rowM in dataGridView1.Rows)
                {

                    if (bCanario)
                    {
                        rowM.Cells["iStock"].Value = rowM.Cells["iStockCanarias"].Value;
                        rowM.Cells["iPendientes"].Value = rowM.Cells["iPendientesCanarias"].Value;
                    }
                }


                //---- GSG (21/01/2014)
                // Establece materiales seleccionados (se usa en la importación de pedidos y en la propuesta de pedido)
                ////---- GSG (10/07/2013)
                //// Establece materiales seleccionados (se usa en la importación de pedidos)
                //if (_V_POS_COD != -1 && _V_POS_UNI != -1)
                //    cargaMaterialesFichero();

                if (_V_POS_COD != -1 && _V_POS_UNI != -1)
                {
                    if (_V_POS_DTO == -1)
                        cargaMaterialesFichero(K_ORIGEN_IMPORTACION);
                    else if (_V_POS_DTO == 2) //---- GSG (15/06/2016)
                        cargaMaterialesFichero(K_ORIGEN_IMPORTACION_CON_DESC);
                    else
                        cargaMaterialesFichero(K_ORIGEN_PROPUESTA);
                }
                //---- FI GSG


                //---- GSG (26/05/2015)
                // Si la campaña tiene bEnviadoPDA (campo reutilizado) a 1, se trata de una campaña en la que tenemos que ver sólo los materiales 
                // que no se han comprado en el último año
                // Como he modificado UpdateDataGridView() según el tipo de campanya también tengo que adelantar la búsqueda de los materiales vendidos
                dsMateriales1.ListaMatsCliLastYear.Clear();
                this.sqldaListaMatsCliLastYear.SelectCommand.Parameters["@iIdCliente"].Value = _iIdCliente;
                //Llenamos la lista de materiales que ha comprado el cliente en el último año
                this.sqldaListaMatsCliLastYear.Fill(dsMateriales1.ListaMatsCliLastYear);
                sCodsMatsCliLastYear = "";
                foreach (dsMateriales.ListaMatsCliLastYearRow rw in dsMateriales1.ListaMatsCliLastYear.Rows)
                {
                    sCodsMatsCliLastYear += (rw.sIdMaterial + ",");
                }


                //---- GSG (23/06/2017)
                ObtenirMaterialsNoRentabilitat();                
                ObtenirCampanyasNoRentabilitat();
                if (Comun.IsInTheArray(sIdCampanya, _lCampanyasNoRenta))
                    lblAfectaRentabilidad.Visible = true;
                else
                    lblAfectaRentabilidad.Visible = false;

                //---- GSG (29/09/2020) PUNTOS
                ObtenirMaterialsNoMargen();
                ObtenirMaterialsARARNoCli();
                ObtenirMaterialsMRARNoCli();
                //---- GSG (02/02/2021)
                ObtenirMaterialsClassificatsConAGrocs();

                //Y actualizamos el DataGridView
                UpdateDataGridView();

                //---- GSG (26/05/2015)
                if (!_bCampanyaMatsNoVenta)
                    updateColorsMatsCliLastYear();


                if (dataGridViewPedido != null)
                {
                    foreach (DataGridViewRow row in dataGridViewPedido.Rows)
                    {
                        if (int.Parse(row.Cells["ColIdGrupoMat"].Value.ToString()) == idGrupMat)
                        {
                            //Busca a la llista complerta de materials de la campanya
                            foreach (DataGridViewRow rowM in dataGridView1.Rows)
                            {
                                if (rowM.Cells["sIdMaterial"].Value.ToString() == row.Cells["sIdMaterialDataGridViewTextBoxColumn"].Value.ToString())
                                {
                                    rowM.Cells["selected"].Value = true;
                                    rowM.Cells["iCantidad"].Value = row.Cells[K_COL_CANT].Value; //"ColCantidad"
                                    rowM.Cells["fDescuento"].Value = row.Cells[K_COL_DTO].Value; //"ColDescuento"                                   
                                    break;
                                }

                                
                            }
                        }                       
                    }

                    dataGridViewPedido.Refresh();
                }

                //---- GSG (19/06/2015)
                //---- GSG (17/05/2011)
                //dataGridView1.Sort(dataGridView1.Columns["sMaterial"], 0);
                if (GESTCRM.Clases.Configuracion.sIdRed == Comun.K_RED_GEN)
                    dataGridView1.Sort(dataGridView1.Columns["sMaterial"], 0);
                else
                    dataGridView1.Sort(dataGridView1.Columns["sCodNacional"], 0);

                dataGridView1.Refresh();

                if (dataGridView1.Rows.Count > 0) //---- GSG (26/05/2015)
                {
                    //---- GSG (24/02/2012)
                    ActualizarTotalesSeleccion();
                    updateColorsRentabilidad(-1, false); //Els pinta tots
                    updateColorsRentabilidad(0, true);
                    _preRowSelected = 0;
                }

                //---- GSG (23/06/2017) puesto mas arriba
                //---- GSG (08/03/2012)
                //ObtenirMaterialsNoRentabilitat();
                ////---- GSG (12/04/2012)
                //ObtenirCampanyasNoRentabilitat();
                //if (Comun.IsInTheArray(sIdCampanya, _lCampanyasNoRenta))
                //    lblAfectaRentabilidad.Visible = true;
                //else
                //    lblAfectaRentabilidad.Visible = false;


                //---- GSG (26/05/2015) puesto más arriba
                ////---- GSG (31/07/2012)
                //dsMateriales1.ListaMatsCliLastYear.Clear();
                //this.sqldaListaMatsCliLastYear.SelectCommand.Parameters["@iIdCliente"].Value = _iIdCliente;
                ////Llenamos la lista de materiales que ha comprado el cliente en el último año
                //this.sqldaListaMatsCliLastYear.Fill(dsMateriales1.ListaMatsCliLastYear);
                //sCodsMatsCliLastYear = "";
                //foreach (dsMateriales.ListaMatsCliLastYearRow rw in dsMateriales1.ListaMatsCliLastYear.Rows)
                //{
                //    sCodsMatsCliLastYear += (rw.sIdMaterial + ",");
                //}                             
                //updateColorsMatsCliLastYear();

                //---- GSG (27/03/2014)
                int numMatsSoloClub = ObtenirMaterialsSolsClub(_iIdCliente);
                if (numMatsSoloClub > 0)
                    updateColorsSoloClub();


                comprobaCompromisoMinimos(); //---- GSG (02/01/2023)

            }
            catch (Exception ex)
            {
                Mensajes.ShowError(ex.Message);
            }
        }

        //---- GSG (21/01/2014)
        private void cargaMaterialesFichero(int origen)
        {
            foreach (DataGridViewRow rowGrid in dataGridView1.Rows)
            {
                string valorBuscar = rowGrid.Cells["sCodNacional"].Value.ToString();
                int index = ContieneMat(valorBuscar);
                if (index >= 0)
                {
                    rowGrid.Cells["selected"].Value = true;
                    rowGrid.Cells["iCantidad"].Value = _cargaMateriales[index][_V_POS_UNI].Replace(".","");
                    //if (origen == K_ORIGEN_PROPUESTA)                    
                    if (origen == K_ORIGEN_PROPUESTA || origen == K_ORIGEN_IMPORTACION_CON_DESC) //---- GSG (15/06/2016)
                    {
                        //---- GSG (19/08/2019) para poder importar con descuentos a cualquier campaña
                        // Hay que mirar que el descuento importado no sea mayor que el perm8tido en MaterialCamp. En tal caso se queda el de la campaña y no el importado
                        //rowGrid.Cells["fDescuento"].Value = double.Parse(_cargaMateriales[index][_V_POS_DTO]).ToString("0.##");
                        double descImp = double.Parse(_cargaMateriales[index][_V_POS_DTO]);
                        //double descImp = double.TryParse(_cargaMateriales[index][_V_POS_DTO], out double tmp) ? tmp : 0; // VLP error
                        double descMax = double.Parse(rowGrid.Cells["fDescuentoMaximo"].Value.ToString());
                        if (descImp > descMax)
                            rowGrid.Cells["fDescuento"].Value = descMax;
                        else
                            rowGrid.Cells["fDescuento"].Value = double.Parse(_cargaMateriales[index][_V_POS_DTO]).ToString("0.##");
                            //rowGrid.Cells["fDescuento"].Value = descImp.ToString("0.##");  // VLP error
                    }
                }
            }
        }



        private int ContieneMat(string sCodNacional)
        {
            int iRet = -1;
            int index = 0;

            foreach (string[] item in _cargaMateriales)
            {
                if (sCodNacional == item[_V_POS_COD])
                {
                    iRet = index;
                    break;
                }

                index++;
            }

            return iRet;
        }
        //---- FI GSG

        private void btBuscar_Click(object sender, System.EventArgs e)
        {
            UpdateDataGridView();
            //---- GSG (24/02/2012)
            _preRowSelected = -1;
            updateColorsRentabilidad(-1, false);
            if (dataGridView1.CurrentRow != null)
                updateColorsRentabilidad(dataGridView1.CurrentRow.Index, true);

            //---- GSG (31/07/2012)
            updateColorsMatsCliLastYear();
            //---- GSG (27/03/014)
            updateColorsSoloClub();
            //---- GSG (14/04/2014)
            txbsDescripcionParaGrid.Text = "";
        }

        private void btCancelar_Click(object sender, System.EventArgs e)
        {
            try
            {
                dataGridView1.EndEdit();
                this.DialogResult = DialogResult.Cancel;
                //---- GSG (25/10/2011)
                SetDefaultColorLinSel(false);
                //---- FI GSG
            }
            catch (Exception ex)
            {
                Mensajes.ShowError(ex.Message);
            }
        }

        public void DatosMaterialN()
        {
            try
            {
                this.ParamIO_sDescripcion = "";
                this.ParamIO_sIdMaterial = "";
                this.ParamIO_sPrecio = "";

                if (ParamIO_sCodNacional.Trim() != "")
                {
                    //---- GSG CECL 19/05/2016
                    if (System.Configuration.ConfigurationManager.AppSettings["TipoDelegadoPedidosCentral"].ToString() == Comun.K_CECL)
                        sqlDaListaMateriales.SelectCommand.CommandText = "[ListaMaterialesDesCampCECL]";
                    else
                        sqlDaListaMateriales.SelectCommand.CommandText = "[ListaMaterialesDesCamp]";
                    //---- FI GSG CECL

                    this.sqlDaListaMateriales.SelectCommand.Parameters["@sCodNacional"].Value = ParamIO_sCodNacional.Trim();
                    this.sqlDaListaMateriales.SelectCommand.Parameters["@iIdCamp"].Value = this.Tag;
                    this.sqlDaListaMateriales.Fill(dsMateriales1.ListaMateriales);
                    if (dsMateriales1.ListaMateriales.Rows.Count == 1)
                    {
                        ParamIO_sDescripcion = dsMateriales1.ListaMateriales.Rows[0][1].ToString().Trim();
                        ParamIO_sIdMaterial = dsMateriales1.ListaMateriales.Rows[0]["sIdMaterial"].ToString().Trim();

                        //ParamIO_sCodNacional = dsMateriales1.ListaMateriales.Rows[0][2].ToString().Trim();
                        ParamIO_sPrecio = dsMateriales1.ListaMateriales.Rows[0][3].ToString().Trim();
                    }
                }
            }
            catch (Exception ex)
            {
                Mensajes.ShowError(ex.Message);
            }

        }

        public void DatosMaterial()
        {
            try
            {
                this.ParamIO_sDescripcion = "";
                this.ParamIO_sCodNacional = "";
                this.ParamIO_sPrecio = "";
                if (this.ParamIO_sIdMaterial.Trim() != "")
                {
                    //---- GSG CECL 19/05/2016
                    if (System.Configuration.ConfigurationManager.AppSettings["TipoDelegadoPedidosCentral"].ToString() == Comun.K_CECL)
                        sqlDaListaMateriales.SelectCommand.CommandText = "[ListaMaterialesDesCampCECL]";
                    else
                        sqlDaListaMateriales.SelectCommand.CommandText = "[ListaMaterialesDesCamp]";
                    //---- FI GSG CECL

                    this.sqlDaListaMateriales.SelectCommand.Parameters["@sIdMaterial"].Value = ParamIO_sIdMaterial.Trim();
                    this.sqlDaListaMateriales.SelectCommand.Parameters["@iIdCamp"].Value = this.Tag;
                    this.sqlDaListaMateriales.Fill(dsMateriales1);
                    if (dsMateriales1.ListaMateriales.Rows.Count == 1)
                    {
                        this.ParamIO_sDescripcion = dsMateriales1.ListaMateriales.Rows[0][1].ToString().Trim();
                        this.ParamIO_sCodNacional = dsMateriales1.ListaMateriales.Rows[0][2].ToString().Trim();
                        this.ParamIO_sPrecio = dsMateriales1.ListaMateriales.Rows[0][3].ToString().Trim();
                        this.Tag = dsMateriales1.ListaMateriales.Rows[0][7].ToString().Trim();
                    }
                }
            }
            catch (Exception ex)
            {
                Mensajes.ShowError(ex.Message);
            }
        }


        // RH --------------------------------------------------------------------------------------------------

        

        private void btAceptar_Click(object sender, System.EventArgs e)
        {
            try
            {
                int Seleccionados = 0;
                double ImporteTotal = 0.0;
                int iTotalProductos = 0;
                double dImporteTotalBruto = 0.0;
                List<ArrayList> taulaProdCamp = new List<ArrayList>();
                string idProductePC = "", idProductePCAnterior = "";
                string nomProductePC = "", nomProductePCAnterior = "";
                string idProducteAntPC = "";
                string idCampanyaPC = "", idCampanyaPCAnterior = "";
                string nomCampanyaPC = "", nomCampanyaPCAnterior = "";
                string idCampanyaAntPC = "";
                int numMatsPC = 0, numMatsPCAnterior = 0;
                double importNetPC = 0, importNetPCAnterior = 0;
                double importBrutPC = 0, importBrutPCAnterior = 0;
                int numMatsPCAcum = 0, numMatsPCAcumAnterior = 0; 
                double importNetPCAcum = 0, importNetPCAcumAnterior = 0;
                double importBrutPCAcum = 0, importBrutPCAcumAnterior = 0;
                double descomptePC = 0, descomptePCAnterior = 0;
                bool canviLin = false;
                bool compruebaGrupo = false;
                string ErrorMessage = String.Empty;


                MaterialesLinea = new List<dsMateriales.ListaLineasPedidoRow>();

                dsMateriales.ListaLineasPedidoDataTable dtMaterialesLinea = new dsMateriales.ListaLineasPedidoDataTable();

                dataGridView1.Sort(dataGridView1.Columns["Ordre"], 0); //---- GSG (17/05/2011)

                /////////////comprobaCompromisoMinimos(); //---- GSG (02/01/2023)
                ///

                // ---- VLP (26/07/2023)
                bool campanyaSeleccionada = EsCampanayaNoDesMedio_FromBtnAcpetar();                
                if (_lPairsMatCampEnPed.Count() > 0 && (((_bArrastre && !campanyaSeleccionada) || (!_bArrastre && campanyaSeleccionada)) || (_bArrastre && _iIdCampanyaPedidoNoDescMedio != sIdCampanya)))
                {
                    Mensajes.ShowExclamation("La campaña seleccionada es especial para descuentos en línea y es incompatible con el uso de otras campañas. El pedido solo puede tener esta campaña.");                    
                    return;
                }


                //---- GSG (29/09/2015)
                // En caso de que sea una campaña de regalo especial el campo txbDto quedará cambiado pero si no lo es mantendrá el calculado en la selección
                _bEsEsp = ActualizarTotalesSiCampanyaRegaloEspecial(sIdCampanya);
                double fDescMedio = double.Parse(txbDto.Text.Replace('%', ' ').Trim());
                //Actualizar los descuentos de los materiales implicados

                if (_bEsEsp)
                {
                    if (fDescMedio > _descMaxRegaloEspecial)
                    {
                        ErrorMessage += String.Format("El descuento medio calculado ({0:C}) supera el máximo permitido por la campaña ({1:C}).", fDescMedio, _descMaxRegaloEspecial);
                    }
                    else
                    {
                        // Sólo lo cambio si todo va bien para que este descuento se tenga en cuenta en las posteriores comprobaciones
                        foreach (DataGridViewRow dr in dataGridView1.Rows)
                        {
                            if ((bool)dr.Cells["selected"].Value == true)
                            {
                                dr.Cells["fDescuento"].Value = Math.Round(fDescMedio, 2);
                            }
                        }
                    }
                    
                }

                //---- GSG (10/10/2016)
                // Si un material ya está en el pedido con otra compaña, no se puede poner A NO SER QUE SE LE PERMITA A LA CAMPAÑA (en tal caso no estará en _lPairsMatCampEnPed)

                //---- GSG (08/07/2016)
                // Si un material ya está en el pedido con otra compaña, no se puede poner
                if (_lPairsMatCampEnPed.Count > 0) //lineas ya existentes en el pedido
                {
                    foreach (DataGridViewRow dr in dataGridView1.Rows) //grid actual de campaña seleccionada
                    {
                        if ((bool)dr.Cells["selected"].Value == true)
                        {
                            var index = _lPairsMatCampEnPed.FindIndex(x => x.Key == dr.Cells["sIdMaterial"].Value.ToString());
                            if (index >= 0)
                            {
                                KeyValuePair<string, string> item = _lPairsMatCampEnPed.Find(x => x.Key == dr.Cells["sIdMaterial"].Value.ToString());
                                if (item.Value != sIdCampanya)
                                {
                                    //---- GSG (10/10/2016)

                                    ////if (item.Value != sIdCampanya)
                                    //if (!(item.Value.ToLower().IndexOf("entrega") >= 0 && lblCampanya.Text.ToLower().IndexOf("entrega") >= 0))
                                    //{
                                    //    if (item.Value != sIdCampanya)
                                    //    {
                                    //        if (lblCampanya.Text.ToLower().IndexOf("entrega") == -1 || item.Value.ToLower().IndexOf("entrega") == -1 || (lblCampanya.Text.ToLower().IndexOf("entrega") >= 0 && item.Value.ToLower().IndexOf("entrega") >= 0))
                                    //            ErrorMessage += String.Format("El material ({0}) ya está en el pedido con otra campaña. \r\n\r\nModifique la selección para continuar.", dr.Cells["sMaterial"].Value.ToString());
                                    //    }
                                    //}

                                    ErrorMessage += String.Format("El material ({0}) ya está en el pedido con otra campaña. \r\n\r\nModifique la selección para continuar.", dr.Cells["sMaterial"].Value.ToString());
                                }
                            }  
                        }
                    }
                }


                //---- GSG (23/04/2013)
                //double fDescMedio = double.Parse(txbDto.Text.Replace('%', ' ').Trim()); //---- GSG (29/09/2015)
                double fDescMinGar = double.Parse(txbMG.Text.Replace('%', ' ').Trim());
                //Sols s'ha de fer si estem editant una comanda amb mínim garantitzat i.e. fDescMinGar > 0
                if (fDescMinGar > 0 && fDescMedio < fDescMinGar)
                {
                    string msg = String.Format("El descuento medio ({0:C})% es inferior al descuento mínimo garantizado ({1:C})%. \r\nSe aplicará el descuento mínimo garantizado a las líneas del pedido si elige continuar.\r\n\r\n¿Desea continuar?", fDescMedio, fDescMinGar);
                    if (Mensajes.ShowQuestion(msg) == DialogResult.Yes)
                    {
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            if (bool.Parse(row.Cells["selected"].Value.ToString()))
                            {
                                row.Cells["fDescuento"].Value = fDescMinGar.ToString();
                            }
                        }
                    }
                    else
                    {
                        //Nos quedamos por si queremos modificar
                        return;
                    }
                }

                //---- GSG (11/07/2014)
                foreach (dsMateriales.ListaMaterialesRow rw in dsMateriales1.ListaMateriales.Rows)
                {
                    if (rw.selected && int.Parse(rw.iCantidad) == 0)
                    {
                        ErrorMessage = String.Format("Hay materiales seleccionades con 0 unidades." + '\n' + "Debe modificar la selección o las cantidades para poder continuar.", NumMinOblis, Seleccionados);
                        break;
                    }
                }


                foreach (dsMateriales.ListaMaterialesRow rw in dsMateriales1.ListaMateriales.Rows)
                {
                    //if (rw.selected) //---- GSG (02/07/2014)
                    if (rw.selected && int.Parse(rw.iCantidad) != 0)
                    {
                        //---- GSG (13/01/2017)
                        //Seleccionados++; //Contamos los seleccionados
                        if (rw.sTipoMat != K_ZMKT)
                            Seleccionados++; //Contamos los seleccionados sin tener en cuenta los ZMKT

                        dsMateriales.ListaLineasPedidoRow rowLinea = dtMaterialesLinea.NewListaLineasPedidoRow();

                        rowLinea["sCodNacional"] = rw.sCodNacional; //---- GSG (11/03/2014)
                        rowLinea["sIdMaterial"] = rw.sIdMaterial;
                        rowLinea["sMaterial"] = rw.sMaterial;
                        rowLinea["iCantidad"] = rw.iCantidad;
                        rowLinea["PrecioUnitario"] = rw.fPrecio;
                        rowLinea["fDescuento"] = rw.fDescuento;
                        rowLinea["fDescuentoMaximo"] = rw.fDescuentoMaximo;                       
                        rowLinea["idCampanya"] = sIdCampanya;
                        rowLinea["NombreCampanya"] = NombreCampanya;
                        rowLinea["UnidMinimas"] = rw.UnidMinimas;
                        rowLinea["sObligatorio"] = rw.sObligatorio;
                        
                        double preu = double.Parse((double.Parse(rw.iCantidad) * rw.fPrecio).ToString());
                        rowLinea["fPrecio"] = preu;


                        rowLinea["bDescExtra"] = _bCampanyaExtra; //---- GSG (03/01/2012)
  
                        if (preu != 0)
                        {
                            double desc = preu * (double.Parse(rw.fDescuento) / 100);

                            rowLinea["ImporteLin"] = preu - desc;

                            ImporteTotal += preu - desc;

                            if (!rw.IsfCosteNull())
                            {
                                double ret = preu - desc - (double.Parse(rw.iCantidad) * rw.fCoste);

                                ret = (ret / preu) * 100;

                                rowLinea["fRentabilidad"] = ret;
                            }
                            else
                                rowLinea["fRentabilidad"] = 100;
                        }
                        else
                        {
                            rowLinea["fRentabilidad"] = 0;
                            rowLinea["ImporteLin"] = 0;
                        }

                        if (!rw.IsfCosteNull())
                        {
                            rowLinea["fCoste"] = rw.fCoste;
                        }

                        //---- GSG (22/01/2015)
                        // Utilizaré este campo para indicar a la línea del pedido si pertenece a una campaña de arrastre o no (POLIMEDICADIS VENTA)
                        //rowLinea["idArrastre"] = -1;

                        //if (_bArrastre)  //---- VLP (26/07/2023). Comentado
                        //    rowLinea["idArrastre"] = 1;
                        //else
                        //    rowLinea["idArrastre"] = 0;
                        rowLinea["idArrastre"] = 0;

                        rowLinea["iIdLinea"] = 0;
                        //---- GSG (06/04/2011)
                        //rowLinea["idGrupoMat"] = 0;
                        if (idGrupMat == -1)
                            rowLinea["idGrupoMat"] = 0;
                        else
                            rowLinea["idGrupoMat"] = idGrupMat;
                        //---- GSG (15/07/2014)
                        //rowLinea["idPaquete"] = -1;
                        rowLinea["idPaquete"] = GetPaquete(rw.sIdMaterial, sIdCampanya);


                        rowLinea["sTipoMat"] = rw.sTipoMat; //---- GSG (10/10/2011)

                        //---- GSG (08/09/2014)
                        //---- GSG (03/01/2012)
                        //rowLinea["fDescMat"] = rw.fDescMat;
                        if (!Comun.IsInTheArray(_sTipoPedido, Configuracion.asPedTransfer)) //DIR
                            rowLinea["fDescMat"] = rw.fDescMat;
                        else
                            rowLinea["fDescMat"] = rw.fDescMatTRA;


                        //---- GSG (12/01/2015)
                        rowLinea["fDescuentoMaximoTRA"] = rw.fDescMatTRA;

                        double fDescExtra = 0.0;

                        //---- GSG (21/11/2014)
                        // No fa falta calcular fDescExtra perque a la pantalla de comandes ja faig el cálcul, no cal que l'arrossegui a la línia
                        

                        rowLinea["fDescExtra"] = fDescExtra;

                        //---- GSG (06/08/2014)
                        // A la línea añadimos los campos para financiación
                        if (rw.IsbFinanciadoNull())
                            rowLinea["bFinanciado"] = false;
                        else
                            rowLinea["bFinanciado"] = rw.bFinanciado;

                        if (rw.IsbMedicamentoNull())
                            rowLinea["bMedicamento"] = false;
                        else
                            rowLinea["bMedicamento"] = rw.bMedicamento;
                        
                        //---- GSG (17/11/2014)
                        if (rw.IsiCajaCompletaNull())
                            rowLinea["iCajaCompleta"] = 0;
                        else
                            rowLinea["iCajaCompleta"] = rw.iCajaCompleta;

                        if (rw.IsiUnidadesEnfajadoNull())
                            rowLinea["iUnidadesEnfajado"] = 0;
                        else
                            rowLinea["iUnidadesEnfajado"] = rw.iUnidadesEnfajado;

                        //---- GSG (21/11/2014)
                        if (rw.IsfPVPNull())
                            rowLinea["fPVP"] = 0;
                        else
                            rowLinea["fPVP"] = rw.fPVP;
                        if (rw.IsfPVPIVANull())
                            rowLinea["fPVPIVA"] = 0;
                        else
                            rowLinea["fPVPIVA"] = rw.fPVPIVA;
                        if (rw.IsiStockCanariasNull())
                            rowLinea["iStockCanarias"] = 0;
                        else
                            rowLinea["iStockCanarias"] = rw.iStockCanarias;
                        if (rw.IsiPendientesCanariasNull())
                            rowLinea["iPendientesCanarias"] = 0;
                        else
                            rowLinea["iPendientesCanarias"] = rw.iPendientesCanarias;

                        //---- GSG (18/12/2015)
                        rowLinea["fDescuentoMaximoDIR"] = rw.fDescMat;

                        //---- GSG (17/11/2016)
                        rowLinea["iCantidadBase"] = rw.iCantidadBase;

                        //---- GSG (02/01/2023)
                        rowLinea["iBloc"] = rw.iBloc;


                        MaterialesLinea.Add(rowLinea);


                        //---- GSG (13/01/2017)
                        // es necesario que todas las líneas estén en MaterialesLinea porque lo necesita la pantalla de pedidos
                        // pero las líneas ZMKT no se deben tener en cuenta para las comprobaciones

                        if (rw.sTipoMat != K_ZMKT)
                        {

                            //---- GSG (13/01/2017)
                            //---- GSG (04/02/2011)
                            //iTotalProductos += int.Parse(rw.iCantidad);
                            iTotalProductos += (int.Parse(rw.iCantidad) * rw.iCantidadBase);

                            dImporteTotalBruto += preu;


                            //---- GSG (05/04/2011)
                            //Agafa valors per Comprobacions de Producte-Campanya i els guarda a la taula (presentacions)

                            if (rw.sIdProducto != "" && rw.idCampanya != "")
                            {
                                idProductePCAnterior = idProductePC;
                                nomProductePCAnterior = nomProductePC;
                                idCampanyaPCAnterior = idCampanyaPC;
                                nomCampanyaPCAnterior = nomCampanyaPC;
                                numMatsPCAnterior = numMatsPC;
                                importNetPCAnterior = importNetPC;
                                importBrutPCAnterior = importBrutPC;
                                numMatsPCAcumAnterior = numMatsPCAcum;
                                importNetPCAcumAnterior = importNetPCAcum;
                                importBrutPCAcumAnterior = importBrutPCAcum;
                                descomptePCAnterior = descomptePC;

                                compruebaGrupo = true;
                                idProductePC = rw.sIdProducto;
                                nomProductePC = rw.sDescripcion;
                                idCampanyaPC = rw.idCampanya;
                                nomCampanyaPC = rw.NombreCampanya;
                                numMatsPC = int.Parse(rw.iNumMinOblis.ToString());
                                importNetPC = rw.fImporteMinObli;
                                importBrutPC = rw.fImporteMinObliBruto;
                                descomptePC = rw.fDescuentoMaxProd;


                                //Guarda els valors del grup anterior 
                                if ((idProductePC != idProducteAntPC || idCampanyaPC != idCampanyaAntPC) && idProducteAntPC != "" && idCampanyaAntPC != "")
                                {
                                    ArrayList linProdCamp = new ArrayList();

                                    linProdCamp.Clear();

                                    linProdCamp.Add(idProductePCAnterior);      //Producte
                                    linProdCamp.Add(nomProductePCAnterior);     //nom Producte
                                    linProdCamp.Add(idCampanyaPCAnterior);      //Campanya
                                    linProdCamp.Add(nomCampanyaPCAnterior);     //nom Campanya
                                    linProdCamp.Add(numMatsPCAnterior);         //Nombre de materials mínim del grup
                                    linProdCamp.Add(importNetPCAnterior);       //Preu mínim del grup
                                    linProdCamp.Add(importBrutPCAnterior);      //Preu brut mínim del grup
                                    linProdCamp.Add(numMatsPCAcumAnterior);     //Quantitat acumulada
                                    linProdCamp.Add(importNetPCAcumAnterior);   //Preu acumulat
                                    linProdCamp.Add(importBrutPCAcumAnterior);  //Preu brut acumulat
                                    linProdCamp.Add(descomptePCAnterior);       //Descompte màxim a aplicar en cas de no superase les unitats mínimes

                                    taulaProdCamp.Add(linProdCamp);
                                }

                                canviLin = false;

                                //Això ho puc fer perquè estan ordenats producte-campanya-material
                                if (idProductePC != idProducteAntPC || idCampanyaPC != idCampanyaAntPC)
                                    canviLin = true;

                                if (canviLin)
                                {
                                    if (idProductePC != idProducteAntPC) idProducteAntPC = idProductePC;
                                    if (idCampanyaPC != idCampanyaAntPC) idCampanyaAntPC = idCampanyaPC;

                                    numMatsPCAcum = int.Parse(rw.iCantidad);
                                    importNetPCAcum = double.Parse(rowLinea["ImporteLin"].ToString());
                                    importBrutPCAcum = preu;
                                }
                                else
                                {
                                    numMatsPCAcum += int.Parse(rw.iCantidad);
                                    importNetPCAcum += double.Parse(rowLinea["ImporteLin"].ToString());
                                    importBrutPCAcum += preu;
                                }
                            }
                            //---- FI GSG
                        } // no zmkt
           
                    }
                }

                //---- GSG (05/04/2011)
                if (compruebaGrupo)
                {
                    //Guarda els valors del darrer grup 
                    ArrayList linProdCamp = new ArrayList();

                    linProdCamp.Clear();

                    linProdCamp.Add(idProductePC);      //Producte
                    linProdCamp.Add(nomProductePC);     //nom Producte
                    linProdCamp.Add(idCampanyaPC);      //Campanya
                    linProdCamp.Add(nomCampanyaPC);     //nom Campanya
                    linProdCamp.Add(numMatsPC);         //Nombre de materials mínim del grup
                    linProdCamp.Add(importNetPC);       //Preu mínim del grup
                    linProdCamp.Add(importBrutPC);      //Preu brut mínim del grup
                    linProdCamp.Add(numMatsPCAcum);     //Quantitat acumulada
                    linProdCamp.Add(importNetPCAcum);   //Preu acumulat
                    linProdCamp.Add(importBrutPCAcum);  //Preu brut acumulat
                    linProdCamp.Add(descomptePC);       //Descompte màxim a aplicar en cas de no superase les unitats mínimes

                    taulaProdCamp.Add(linProdCamp);
                }
                //---- FI GSG

                

                if (Seleccionados < int.Parse(NumMinOblis))
                    ErrorMessage = String.Format("Debe seleccionar al menos {0} materiales.\nSólo seleccionó {1}." + '\n', NumMinOblis, Seleccionados);

                if (ImporteTotal < double.Parse(ImporteMinObli))
                    ErrorMessage += String.Format("El importe total ({0:C}) no puede ser menor que {1}€." + '\n', ImporteTotal, ImporteMinObli);



                //---- GSG (04/02/2011)
                if (iTotalProductos < iCantidadTotalMinObli)
                    ErrorMessage += String.Format("La cantidad total ({0}) no puede ser menor que {1}." + '\n', iTotalProductos, iCantidadTotalMinObli);

                if (dImporteTotalBruto < dImporteBrutoMinObli)
                    ErrorMessage += String.Format("El importe bruto total ({0:C}) no puede ser menor que {1}€." + '\n', dImporteTotalBruto, dImporteBrutoMinObli);
                //---- FI GSG

                //---- GSG (05/04/2011)
                //Comproba que es compleixen els requisits mínims de Producte-Campanya
                if (compruebaGrupo)
                {
                    int iNumMatMin = 0;
                    double fPreuMin = 0;
                    double fPreuBrutMin = 0;
                    int iNumMat = 0;
                    double fPreu = 0;
                    double fPreuBrut = 0;
                    Object[] linia = new Object[10];
                    

                    foreach (ArrayList lin in taulaProdCamp)
                    {
                        lin.ToArray();

                        linia = lin.ToArray();

                        //materials mínims
                        iNumMatMin = int.Parse(linia[4].ToString());
                        iNumMat = int.Parse(linia[7].ToString());
                        if (iNumMat < iNumMatMin)
                        {
                            //ErrorMessage += String.Format("La cantidad total ({0}) del grupo {1} - {2} no puede ser menor que {3}.", iNumMat, linia[1].ToString(), linia[3].ToString(), iNumMatMin);

                            //parelles IdMaterial, descompte
                            Dictionary<string, double> MatDes = new Dictionary<string, double>();
                            
                            foreach (dsMateriales.ListaMaterialesRow rw in dsMateriales1.ListaMateriales.Rows)
                            {
                                if (rw.selected)
                                    if (rw.idCampanya == linia[2].ToString() && rw.sIdProducto == linia[0].ToString())
                                        //MatDes.Add(rw.sIdMaterial.ToString(), double.Parse(rw.fDescuento));
                                        MatDes.Add(rw.sMaterial.ToString(), double.Parse(rw.fDescuento));
                            }

                            foreach (KeyValuePair<string, double> parella in MatDes)
                            { 
                                if (parella.Value > double.Parse(linia[10].ToString()))
                                {
                                    //Això ho canvio per a que sols es mostri una línia per grup enlloc de per a cada material que es passi. 
                                    //ErrorMessage += String.Format("El material {0} del grupo {1} - {2} no puede tener un descuento superior a {3}." + '\n', parella.Key, linia[1].ToString(), linia[3].ToString(), linia[10].ToString());
                                    //ErrorMessage += String.Format("El material {0} no puede tener un descuento superior a {1}." + '\n', parella.Key, linia[10].ToString());
                                    ErrorMessage += String.Format("En el producto {0} el descuento no puede ser superior a {1}." + '\n', linia[1].ToString(), linia[10].ToString());
                                    break;
                                }
                            }
                        }

                        //preus mínims
                        fPreuMin = double.Parse(linia[5].ToString());
                        fPreu = double.Parse(linia[8].ToString());
                        fPreuBrutMin = double.Parse(linia[6].ToString());
                        fPreuBrut = double.Parse(linia[9].ToString());

                        if (fPreuMin != 0 && fPreuBrutMin != 0)
                            ErrorMessage += String.Format("Los precios netos y brutos no son compatibles. Consulte con el administrador." + '\n');
                        else
                        {
                            if (fPreuMin != 0 && fPreu < fPreuMin)
                                ErrorMessage += String.Format("El importe total ({0:C})  del grupo {1} - {2} no puede ser menor que {3}€." + '\n', fPreu, linia[1].ToString(), linia[3].ToString(), fPreuMin);
                            if (fPreuBrutMin != 0 && fPreuBrut < fPreuBrutMin)
                                ErrorMessage += String.Format("El importe bruto total ({0:C})  del grupo {1} - {2} no puede ser menor que {3}€." + '\n', fPreuBrut, linia[1].ToString(), linia[3].ToString(), fPreuBrutMin);
                        }
                    }
                }
                //---- FI GSG

                //---- GSG (19/05/2011)
                if (double.Parse(txbDescExtraRestante.Text) < 0)
                {
                    ErrorMessage += "Se ha gastado más extra del disponible." + '\n';
                }


                //---- GSG (30/09/2013)
                float fRentMin = GetRentMinCamp(sIdCampanya);
                if (txtRentabilidad.Text.Trim() != "") //---- GSG (21/04/2016)
                {
                    float fRentSeleccion = float.Parse(txtRentabilidad.Text);
                    if (fRentSeleccion < fRentMin)
                    {
                        ErrorMessage += "La rentabilidad de la selección no supera el mínimo requerido por la campaña " + lblCampanya.Text + "." + '\n';
                    }
                }

                //---- GSG (23/08/2017)
                // Comprobaciones complejas ej: 
                // Preventa Etoricoxib
                //-Pedido mínimo para  aplazamiento e ir en directo 50 % dto. 10 uds surtidas; para transfer, desde la primera unidad puede ir al 50 %.Cuentan para rentabilidad.  
                //-Si piden 16 o más uds surtidas, podrán ir en directo o transfer y, además del dto. del 50 % un regalo de 2 ator de 40 y 2 de 80.Este regalo sólo se hará con 16uds o múltiplos.Exenta de rentabilidad.
                //- Aplazamiento para el directo hasta diciembre.                
                List<GESTCRM.Comun.TripletLinPed> lTLP = new List<GESTCRM.Comun.TripletLinPed>();

                foreach (dsMateriales.ListaMaterialesRow rw in dsMateriales1.ListaMateriales.Rows)
                {
                    if (rw.selected && int.Parse(rw.iCantidad) != 0)
                    {
                        GESTCRM.Comun.TripletLinPed tlp = null;
                        //---- GSG (05/01/2018)
                        //tlp = new GESTCRM.Comun.TripletLinPed(rw.sIdMaterial, int.Parse(rw.iCantidad), double.Parse(rw.iCantidad) * rw.fPrecio);
                        tlp = new GESTCRM.Comun.TripletLinPed(rw.sIdMaterial, rw.iCantidadBase * int.Parse(rw.iCantidad), double.Parse(rw.iCantidad) * rw.fPrecio);

                        lTLP.Add(tlp);
                    }
                }

                GESTCRM.BBDD.InitsGrupoCampanya();
                if (! GESTCRM.BBDD.ValidaGrupoCamp(sIdCampanya, _sTipoPedido, lTLP))
                    ErrorMessage += "Error en condiciones de la campaña " + lblCampanya.Text + '\n';

                //---- FI GSG

                if (ErrorMessage.Length > 0)
                {
                    Mensajes.ShowError(ErrorMessage);
                    dtMaterialesLinea.Rows.Clear();
                }
                else
                {
                    DialogResult = DialogResult.OK;
                }

                //---- GSG (17/05/2011)
                //dataGridView1.Sort(dataGridView1.Columns["sMaterial"], 0);
                //---- GSG (19/06/2015)
                if (GESTCRM.Clases.Configuracion.sIdRed == Comun.K_RED_GEN)
                    dataGridView1.Sort(dataGridView1.Columns["sMaterial"], 0);
                else
                    dataGridView1.Sort(dataGridView1.Columns["sCodNacional"], 0);

                dataGridView1.Refresh();

                //---- GSG (25/10/2011)
                SetDefaultColorLinSel(false);
                //---- FI GSG
            }
            catch (Exception ex)
            {
                Mensajes.ShowError(ex.Message);
            }
        }


        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["iCantidad"].Index) //Cantidad
            {
                string tipText = dataGridView1.Rows[e.RowIndex].Cells["UnidMinimas"].Value.ToString();
                Mensajes.SetTip("Unidades mínimas", tipText);
                //---- GSG (16/05/2014)
                if (dataGridView1.Rows[e.RowIndex].Cells["iCantidad"].Value.ToString() == "0")
                    dataGridView1.Rows[e.RowIndex].Cells["iCantidad"].Value = "";
            }
            else
                if (e.ColumnIndex == dataGridView1.Columns["fDescuento"].Index) //Descuento
                {
                    string tipText = dataGridView1.Rows[e.RowIndex].Cells["fDescuentoMaximo"].Value.ToString() + "%";
                    Mensajes.SetTip("Descuento máximo", tipText);
                }


        }

        private bool EsObligatorio(int RowNumber)
        {
            return dataGridView1.Rows[RowNumber].Cells["sObligatorio"].Value.ToString() == obligatorioSi;
        }

        private void dataGridView1_MouseUp(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hti = dataGridView1.HitTest(e.X, e.Y);

            if (hti.RowIndex < 0) //Se hizo click en la cabecera
                return;

            if (hti.ColumnIndex == 0)
            {
                if (EsObligatorio(hti.RowIndex))
                    return;

                if ((dataGridView1.Rows[hti.RowIndex].Cells["fDescuento"].Style.BackColor != ErrorColor) &&
                        (dataGridView1.Rows[hti.RowIndex].Cells["iCantidad"].Style.BackColor != ErrorColor))
                    dataGridView1.Rows[hti.RowIndex].Cells["selected"].Value =
                        !(bool)dataGridView1.Rows[hti.RowIndex].Cells["selected"].Value;

                //---- GSG (03/01/2012)
                if (_bCampanyaExtra)
                {
                    _fDescExtraRestante = _fDescExtra - CalculaDescExtraGastados();
                    txbDescExtraRestante.Text = _fDescExtraRestante.ToString();
                }

                //---- GSG (24/02/2012)
                ActualizarTotalesSeleccion();
                //UpdateDataGridColors();
                //---- FI GSG
            }
            else
                if (dataGridView1.IsCurrentCellInEditMode)
                    Mensajes.ShowTip(dataGridView1.Parent.Left + e.X, dataGridView1.Parent.Top + e.Y, this);
                else
                {
                    //---- GSG (25/10/2011)
                    int iQty = 0;
                    if (dataGridView1.Rows[hti.RowIndex].Cells["iCantidad"].Value.ToString() != "")
                        iQty = int.Parse(dataGridView1.Rows[hti.RowIndex].Cells["iCantidad"].Value.ToString());
                    if (UpdateDataGridColorPendiente(int.Parse(dataGridView1.Rows[hti.RowIndex].Cells["iStock"].Value.ToString()), iQty, int.Parse(dataGridView1.Rows[hti.RowIndex].Cells["iPendientes"].Value.ToString())))
                        SetDefaultColorLinSel(true);
                    else
                        SetDefaultColorLinSel(false);
                    //---- FI GSG
                }
           
        }


        private void dataGridView1_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            DataGridViewCell cell = dataGridView1.CurrentCell;

            if (e.ColumnIndex == dataGridView1.Columns["iCantidad"].Index) //Validar Cantidad
            {
                string sUnidMinimas = dataGridView1.Rows[e.RowIndex].Cells["UnidMinimas"].Value.ToString();
                int iUnidMinimas = int.Parse(sUnidMinimas);

                string sCantidad = e.Value.ToString();
                int iCantidad;

                int.TryParse(sCantidad, out iCantidad);
                if (iCantidad < 1)
                {
                    cell.Style.BackColor = DefaultValueColor;
                    cell.Style.SelectionBackColor = DefaultValueColor;
                    DefaultValue = dataGridView1.Rows[e.RowIndex].Cells["iCantidad"].Value.ToString();

                    Mensajes.ShowError(String.Format("Valor de cantidad incorrecto ({0}). Debe introducir un número entero mayor o igual que 1.", sCantidad));
                    e.ParsingApplied = false;

                    return;
                }

                //---- GSG (02/01/2023)
                if (_iMinimos == 1)
                {
                    if (iCantidad != 1)
                    {
                        cell.Style.BackColor = DefaultValueColor;
                        cell.Style.SelectionBackColor = DefaultValueColor;
                        DefaultValue = "1";

                        e.ParsingApplied = false;

                        Mensajes.ShowError(String.Format("La cantidad en un compromiso de mínimos debe ser de 1 unidad)."));
                    }
                    else
                    {
                        e.ParsingApplied = true;
                    }
                }
                else //---- FI GSG
                {
                    if (iCantidad < iUnidMinimas)
                    {
                        cell.Style.BackColor = DefaultValueColor;
                        cell.Style.SelectionBackColor = DefaultValueColor;
                        DefaultValue = dataGridView1.Rows[e.RowIndex].Cells["iCantidad"].Value.ToString();

                        e.ParsingApplied = false;

                        Mensajes.ShowError(String.Format("La cantidad ({0}) debe igualar o supera a las unidades mínimas ({1}).", sCantidad, sUnidMinimas));
                    }
                    else
                    {
                        e.ParsingApplied = true;
                    }

                    //---- GSG (17/11/2014)
                    //-- Valida suma unidades                
                    _sTipoSumaUnidades = GetTipoSumaUnidadesCampanya(dataGridView1.Rows[e.RowIndex].Cells["sIdMaterial"].Value.ToString(), sIdCampanya);

                    //---- GSG (29/03/2022)
                    _sTipoPedidoSumaUnidades = GetTipoPedidoSumaUnidadesCampanya(dataGridView1.Rows[e.RowIndex].Cells["sIdMaterial"].Value.ToString(), sIdCampanya);
                    bool bCumple = false;
                    if ((_sTipoPedidoSumaUnidades == "XXXX") ||
                        (Comun.IsInTheArray(_sTipoPedido, Configuracion.asPedTransfer) && (_sTipoPedidoSumaUnidades == _sTipoPedido || _sTipoPedidoSumaUnidades == "T")) ||
                        (!Comun.IsInTheArray(_sTipoPedido, Configuracion.asPedTransfer) && (_sTipoPedidoSumaUnidades == _sTipoPedido || _sTipoPedidoSumaUnidades == "D"))
                        )
                        bCumple = true;




                    //if (_sTipoSumaUnidades == Comun.K_CAJA) //---- GSG (29/03/2022)
                    if (_sTipoSumaUnidades == Comun.K_CAJA && bCumple)
                    {
                        int iNum = 0;
                        if (dataGridView1.Rows[e.RowIndex].Cells["iCajaCompleta"].Value != null && dataGridView1.Rows[e.RowIndex].Cells["iCajaCompleta"].Value.ToString().Trim() != "")
                            iNum = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["iCajaCompleta"].Value.ToString());
                        if (iNum != 0 && (iCantidad % iNum != 0))
                        {
                            cell.Style.BackColor = DefaultValueColor;
                            cell.Style.SelectionBackColor = DefaultValueColor;
                            DefaultValue = dataGridView1.Rows[e.RowIndex].Cells["iCantidad"].Value.ToString();

                            e.ParsingApplied = false;

                            Mensajes.ShowError(String.Format("Valor de cantidad incorrecto ({0}). Debe introducir un número múltiplo de las unidades de caja completa ({1}).", iCantidad.ToString(), iNum.ToString()));
                            return;
                        }
                    }
                    //else if (_sTipoSumaUnidades == Comun.K_EMBALAJE) //---- GSG (29/03/2022)
                    else if (_sTipoSumaUnidades == Comun.K_EMBALAJE && bCumple)
                    {
                        int iNum = 0;
                        if (dataGridView1.Rows[e.RowIndex].Cells["iUnidadesEnfajado"].Value != null && dataGridView1.Rows[e.RowIndex].Cells["iUnidadesEnfajado"].Value.ToString().Trim() != "")
                            iNum = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["iUnidadesEnfajado"].Value.ToString());
                        if (iNum != 0 && (iCantidad % iNum != 0))
                        {
                            cell.Style.BackColor = DefaultValueColor;
                            cell.Style.SelectionBackColor = DefaultValueColor;
                            DefaultValue = dataGridView1.Rows[e.RowIndex].Cells["iCantidad"].Value.ToString();

                            e.ParsingApplied = false;

                            Mensajes.ShowError(String.Format("Valor de cantidad incorrecto ({0}). Debe introducir un número múltiplo de las unidades de enfajado ({1}).", iCantidad.ToString(), iNum.ToString()));

                            return;
                        }
                    }



                    //---- GSG (25/10/2011)
                    if (UpdateDataGridColorPendiente(int.Parse(dataGridView1.Rows[e.RowIndex].Cells["iStock"].Value.ToString()), iCantidad, int.Parse(dataGridView1.Rows[e.RowIndex].Cells["iPendientes"].Value.ToString())))
                    {
                        for (int i = 0; i < dataGridView1.Rows[e.RowIndex].Cells.Count; i++)
                            dataGridView1.Rows[e.RowIndex].Cells[i].Style.ForeColor = Color.Red;
                    }


                    //---- GSG (10/03/2014)
                    if (UpdateDataGridColorEnfajadoCaja(iCantidad, int.Parse(dataGridView1.Rows[e.RowIndex].Cells["iUnidadesEnfajado"].Value.ToString()), int.Parse(dataGridView1.Rows[e.RowIndex].Cells["iCajaCompleta"].Value.ToString())))
                    {
                        dataGridView1.Rows[e.RowIndex].Cells["iUnidadesEnfajado"].Style.BackColor = EnfajadoCajaColor;
                        dataGridView1.Rows[e.RowIndex].Cells["iCajaCompleta"].Style.BackColor = EnfajadoCajaColor;
                    }
                    else
                    {
                        dataGridView1.Rows[e.RowIndex].Cells["iUnidadesEnfajado"].Style.BackColor = dataGridView1.Rows[e.RowIndex].Cells["iCantidad"].Style.BackColor;
                        dataGridView1.Rows[e.RowIndex].Cells["iCajaCompleta"].Style.BackColor = dataGridView1.Rows[e.RowIndex].Cells["iCantidad"].Style.BackColor;
                    }
                    
                }

            }
            else
                if (e.ColumnIndex == dataGridView1.Columns["fDescuento"].Index) //Validar Descuento
                {
                    string sDescuentoMaximo = dataGridView1.Rows[e.RowIndex].Cells["fDescuentoMaximo"].Value.ToString();
                    float fDescuentoMaximo = float.Parse(sDescuentoMaximo);

                    string sDescuento = e.Value.ToString();
                    float fDescuento;

                    float.TryParse(sDescuento, out fDescuento);
                    if ((fDescuento <= 0) && sDescuento != "0")
                    {
                        cell.Style.BackColor = DefaultValueColor;
                        cell.Style.SelectionBackColor = DefaultValueColor;
                        DefaultValue = dataGridView1.Rows[e.RowIndex].Cells["fDescuento"].Value.ToString();

                        Mensajes.ShowError(String.Format("Valor de descuento incorrecto ({0}). Debe introducir un número mayor o igual que 0.", sDescuento));
                        e.ParsingApplied = false;

                        return;
                    }

                    if (fDescuento > fDescuentoMaximo)                    
                    {
                        cell.Style.BackColor = DefaultValueColor;
                        cell.Style.SelectionBackColor = DefaultValueColor;
                        DefaultValue = dataGridView1.Rows[e.RowIndex].Cells["fDescuento"].Value.ToString();

                        e.ParsingApplied = false;

                        Mensajes.ShowError(String.Format("El descuento aplicado ({0}%) supera al descuento máximo ({1}%).", sDescuento, sDescuentoMaximo));
                    }
                    else
                    {
                        e.ParsingApplied = true;
                    }

                }

            if (e.ParsingApplied == true)
            {
                cell.Style.BackColor = dataGridView1.Rows[e.RowIndex].Cells["selected"].Style.BackColor;
                cell.Style.SelectionBackColor = dataGridView1.Rows[e.RowIndex].Cells["selected"].Style.SelectionBackColor;

                if ((dataGridView1.Rows[e.RowIndex].Cells["iCantidad"].Style.BackColor != ErrorColor) && // Si ninguna de las dos celdas está en error
                    (dataGridView1.Rows[e.RowIndex].Cells["fDescuento"].Style.BackColor != ErrorColor))  // se puede seleccionar
                {
                    dataGridView1.Rows[e.RowIndex].Cells["selected"].Value = true;
                }
            }

            
        }

        //---- GSG (25/10/2011)
        private bool UpdateDataGridColorPendiente(int iStock, int iCantidad, int iPendiente)
        {
            if (iStock <= 0 || iCantidad > iStock - iPendiente)
                return true;

            return false;
        }

        private void SetDefaultColorLinSel(bool nok)
        {
            if (nok)
                dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Red;
            else
                dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;
        }

        //---- GSG (10/03/2014)
        private bool UpdateDataGridColorEnfajadoCaja(int iCantidad, int iEnfajado, int iCaja)
        {
            bool bRet = false;

            //---- GSG (07/05/2014) Para que no haga nada cuando las unidades son 0 (por defecto ahora hay 0 unidades en lugar de 1)
            //if (iEnfajado != 1)
            if (iEnfajado != 1 && iCantidad != 0)
            {
                //Calcula el 5% del enfajado
                double percentEnfajado = Math.Ceiling((iEnfajado * K_DIF_ENFAJADOCAJA) / 100);

                //Calcula el 5% de la caja completa
                double percentCaja = Math.Ceiling((iCaja * K_DIF_ENFAJADOCAJA) / 100);


                //---- GSG (06/06/2014)
                // Para evitar el caso en que se ha pasado en que la condición es cierta pero no debería serlo y en todo caso tenerlo en cuenta en los múltiplos

                //if (Math.Abs(iCantidad - iEnfajado) <= percentEnfajado || Math.Abs(iCantidad - iCaja) <= percentCaja)
                //    bRet = true;

                bool bPorEnfajado = false;
                bool bPorCaja = false;

                if (Math.Abs(iCantidad - iEnfajado) <= percentEnfajado)
                {
                    bRet = true;
                    bPorEnfajado = true;
                }

                if (Math.Abs(iCantidad - iCaja) <= percentCaja)
                {
                    bRet = true;
                    bPorCaja = true;
                }

                if (bPorEnfajado && !bPorCaja && bRet && iCantidad > iEnfajado)
                    bRet = false;
                else if (!bPorEnfajado && bPorCaja && bRet && iCantidad > iCaja)
                    bRet = false;
                else if (bPorEnfajado && bPorCaja && bRet && iCantidad > iCaja && iCantidad > iCaja)
                    bRet = false;


                // También debe funcionar para los mútiplos (tendremos en cuenta hasta 99 múltiplos)
                if (!bRet)
                {
                    for (int i = 2; i <= 100; i++)
                    {
                        percentEnfajado = Math.Ceiling((iEnfajado * i * K_DIF_ENFAJADOCAJA) / 100);

                        //Calcula el 5% de la caja completa
                        percentCaja = Math.Ceiling((iCaja * i * K_DIF_ENFAJADOCAJA) / 100);


                        bPorEnfajado = false;
                        bPorCaja = false;

                        if (Math.Abs(iCantidad - (iEnfajado * i)) <= percentEnfajado)
                        {
                            bRet = true;
                            bPorEnfajado = true;
                        }

                        if (Math.Abs(iCantidad - (iCaja * i)) <= percentCaja)
                        {
                            bRet = true;
                            bPorCaja = true;
                        }

                        if (bPorEnfajado && !bPorCaja && bRet && iCantidad > iEnfajado * i)
                            bRet = false;
                        else if (!bPorEnfajado && bPorCaja && bRet && iCantidad > iCaja * i)
                            bRet = false;
                        else if (bPorEnfajado && bPorCaja && bRet && iCantidad > iEnfajado * i && iCantidad > iCaja * i)
                            bRet = false;
                    }
                }
            }

            return bRet;
        }


        //---- FI GSG

        private void UpdateDataGridColors()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                string sUnidMinimas = row.Cells["UnidMinimas"].Value.ToString();
                int iUnidMinimas = int.Parse(sUnidMinimas);

                string sCantidad = row.Cells["iCantidad"].Value.ToString();
                int iCantidad;

                int.TryParse(sCantidad, out iCantidad);

                //---- GSG (07/05/2014)
                //-- Por defecto ahora las unidades son 0 en lugar de 1
                //if ((iCantidad < iUnidMinimas) || (iCantidad < 1))
                if (iCantidad < iUnidMinimas && iCantidad > 0)
                {
                    row.Cells["iCantidad"].Style.BackColor = ErrorColor;
                    row.Cells["iCantidad"].Style.SelectionBackColor = ErrorColor;
                    row.Cells["selected"].Value = false;
                }

                string sDescuentoMaximo = row.Cells["fDescuentoMaximo"].Value.ToString();
                float fDescuentoMaximo = float.Parse(sDescuentoMaximo);

                string sDescuento = row.Cells["fDescuento"].Value.ToString();
                float fDescuento;

                float.TryParse(sDescuento, out fDescuento);

                if (_bEsEsp == false) //---- GSG (29/09/2015)
                {
                    if ((fDescuento > fDescuentoMaximo) || ((fDescuento <= 0) && sDescuento != "0"))
                    {
                        row.Cells["fDescuento"].Style.BackColor = ErrorColor;
                        row.Cells["fDescuento"].Style.SelectionBackColor = ErrorColor;
                        row.Cells["selected"].Value = false;
                    }
                }

                //---- GSG (25/10/2011)
                if (UpdateDataGridColorPendiente(int.Parse(row.Cells["iStock"].Value.ToString()), iCantidad, int.Parse(row.Cells["iPendientes"].Value.ToString())))
                {
                    for (int i = 0; i < row.Cells.Count; i++)
                    {
                        row.Cells[i].Style.ForeColor = Color.Red;
                    }
                    if (row.Selected)
                        SetDefaultColorLinSel(true);
                }

                //---- GSG (10/03/2014)
                if (UpdateDataGridColorEnfajadoCaja(iCantidad, int.Parse(row.Cells["iUnidadesEnfajado"].Value.ToString()), int.Parse(row.Cells["iCajaCompleta"].Value.ToString())))
                {
                    row.Cells["iUnidadesEnfajado"].Style.BackColor = EnfajadoCajaColor;
                    row.Cells["iCajaCompleta"].Style.BackColor = EnfajadoCajaColor;
                }
                else
                {
                    row.Cells["iUnidadesEnfajado"].Style.BackColor = row.Cells["iCantidad"].Style.BackColor;
                    row.Cells["iCajaCompleta"].Style.BackColor = row.Cells["iCantidad"].Style.BackColor;
                }

            }
        }

        private void updateColorsRentabilidad(int filaSel, bool esClick)
        {
            //---- GSG (23/04/2012)
            Color cColor = Color.FromArgb(238, 243, 246);

            if (filaSel < 0)
            {
                int fila = 0;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    //Color segons la rendabilitat de la fila
                    string val = "";

                    //---- GSG (29/09/2020) PUNTOS
                    //string colorin = ActualizarRentabilidadFila(fila, out val, out cColor);
                    float margenFila;
                    string colorin = ActualizarRentabilidadFila(fila, out val, out cColor, out margenFila);
                    row.Cells["Rendabilitat"].Style.BackColor = cColor;
                    //---- FI GSG

                    //---- GSG (06/03/2012)
                    //Ho amago pq ja no volen que es vegi el valor, sols el color
                    val = "";
                    //---- 


                    row.Cells["Rendabilitat"].Value = val;


                    //---- GSG (229/09/2020) PUNTOS
                    double margen = 0;

                    if (row.Cells["iCantidad"].Value.ToString() != "" && int.Parse(row.Cells["iCantidad"].Value.ToString()) != 0)
                    {
                        // Margen del laboratorio por unidad independientemente de si está o no en el pedido
                        margen = margenFila / int.Parse(row.Cells["iCantidad"].Value.ToString());
                        //lo convierto a puntos
                        if (Clases.Configuracion.iPuntosDividePor != 0)
                            margen = (margen / Clases.Configuracion.iPuntosDividePor) * Clases.Configuracion.iPuntosMultiplicaPor;
                        // lo llevo a grid
                        row.Cells["margen"].Value = margen;

                        // Margen del lab de la línea del pedido 
                        margen = margenFila;
                        //lo convierto a puntos
                        if (Clases.Configuracion.iPuntosDividePor != 0)
                            margen = (margen / Clases.Configuracion.iPuntosDividePor) * Clases.Configuracion.iPuntosMultiplicaPor;
                        // lo llevo a grid
                        row.Cells["MargenLin"].Value = margen;
                    }
                    else
                    {
                        margen = margenFila;
                        if (Clases.Configuracion.iPuntosDividePor != 0)
                            margen = (margen / Clases.Configuracion.iPuntosDividePor) * Clases.Configuracion.iPuntosMultiplicaPor;
                        row.Cells["margen"].Value = margen;  // Margen del laboratorio por unidad independientemente de si está o no en el pedido
                        row.Cells["MargenLin"].Value = 0; // Margen del lab de la línea del pedido
                    }




                    fila++;
                }
            }
            else
            {
                string val = "";
                //---- GSG (23/04/2012)
                //string colorin = ActualizarRentabilidadFila(filaSel, out val);
                //---- GSG (29/09/2020) PUNTOS
                //string colorin = ActualizarRentabilidadFila(filaSel, out val, out cColor);
                float margenFila;
                string colorin = ActualizarRentabilidadFila(filaSel, out val, out cColor, out margenFila);
                //---- FI GSG


                if (esClick)
                {
                    dataGridView1.Rows[filaSel].Cells["Rendabilitat"].Value = colorin;
                }
                else
                {
                    //Color segons la rendabilitat de la fila

                    //---- GSG (23/04/2012)
                    //switch (colorin)
                    //{
                    //    case "ROJO":
                    //        dataGridView1.Rows[filaSel].Cells["Rendabilitat"].Style.BackColor = Color.Red;
                    //        break;
                    //    case "NARANJA":
                    //        dataGridView1.Rows[filaSel].Cells["Rendabilitat"].Style.BackColor = Color.Orange;
                    //        break;
                    //    case "VERDE":
                    //        dataGridView1.Rows[filaSel].Cells["Rendabilitat"].Style.BackColor = Color.Green;
                    //        break;
                    //    default:
                    //        dataGridView1.Rows[filaSel].Cells["Rendabilitat"].Style.BackColor = Color.FromArgb(238, 243, 246);
                    //        break;
                    //}

                    dataGridView1.Rows[filaSel].Cells["Rendabilitat"].Style.BackColor = cColor;
                    //---- FI GSG

                    //---- GSG (06/03/2012)
                    //Ho amago pq ja no volen que es vegi el valor, sols el color
                    val = "";
                    //---- 

                    dataGridView1.Rows[filaSel].Cells["Rendabilitat"].Value = val;

                    //---- GSG (29/09/2020) PUNTOS
                    double margen = 0;

                    if (dataGridView1.Rows[filaSel].Cells["iCantidad"].Value.ToString() != "" && int.Parse(dataGridView1.Rows[filaSel].Cells["iCantidad"].Value.ToString()) != 0)
                    {
                        // Margen del laboratorio por unidad independientemente de si está o no en el pedido
                        margen = margenFila / int.Parse(dataGridView1.Rows[filaSel].Cells["iCantidad"].Value.ToString());
                        //lo convierto a puntos
                        if (Clases.Configuracion.iPuntosDividePor != 0)
                            margen = (margen / Clases.Configuracion.iPuntosDividePor) * Clases.Configuracion.iPuntosMultiplicaPor;
                        // lo llevo a grid
                        dataGridView1.Rows[filaSel].Cells["margen"].Value = margen;

                        // Margen del lab de la línea del pedido 
                        margen = margenFila;
                        //lo convierto a puntos
                        if (Clases.Configuracion.iPuntosDividePor != 0)
                            margen = (margen / Clases.Configuracion.iPuntosDividePor) * Clases.Configuracion.iPuntosMultiplicaPor;
                        // lo llevo a grid
                        dataGridView1.Rows[filaSel].Cells["MargenLin"].Value = margen;

                    }
                    else
                    {
                        margen = margenFila;
                        if (Clases.Configuracion.iPuntosDividePor != 0)
                            margen = (margen / Clases.Configuracion.iPuntosDividePor) * Clases.Configuracion.iPuntosMultiplicaPor;
                        dataGridView1.Rows[filaSel].Cells["margen"].Value = margen;  // Margen del laboratorio por unidad independientemente de si está o no en el pedido
                        dataGridView1.Rows[filaSel].Cells["MargenLin"].Value = 0; // Margen del lab de la línea del pedido
                    }
                }
            }

            //---- GSG (29/09/2020) PUNTOS
            txtMargen.Text = Calcular_MargenSeleccion().ToString("N2");
        }


        //---- GSG (31/07/2012)
        //private void updateColorsMatsCliLastYear()
        //{
        //    int index = 0;

        //    if (sCodsMatsCliLastYear != "" && sCodsMatsCliLastYear != null)
        //    {
        //        foreach (DataGridViewRow row in dataGridView1.Rows)
        //        {
        //            if (sCodsMatsCliLastYear.IndexOf(row.Cells["sIdMaterial"].Value.ToString() + ",") >= 0)
        //            {
        //                //Cal pintar
        //                dataGridView1.Rows[index].Cells["sCodNacional"].Style.BackColor = Color.LightGray;
        //                dataGridView1.Rows[index].Cells["sMaterial"].Style.BackColor = Color.LightGray;
        //                dataGridView1.Rows[index].Cells["sIdMaterial"].Style.BackColor = Color.LightGray;
        //                dataGridView1.Rows[index].Cells["fPrecio"].Style.BackColor = Color.LightGray;
        //                dataGridView1.Rows[index].Cells["iCantidad"].Style.BackColor = Color.LightGray;
        //                dataGridView1.Rows[index].Cells["fDescuento"].Style.BackColor = Color.LightGray;
        //                dataGridView1.Rows[index].Cells["iStock"].Style.BackColor = Color.LightGray;
        //                dataGridView1.Rows[index].Cells["iUnidadesEnfajado"].Style.BackColor = Color.LightGray;
        //                dataGridView1.Rows[index].Cells["iCajaCompleta"].Style.BackColor = Color.LightGray;
        //                dataGridView1.Rows[index].Cells["unisPedidas"].Style.BackColor = Color.LightGray; //---- GSG (26/02/2018)
        //                dataGridView1.Rows[index].Cells["TipoClasificacion"].Style.BackColor = Color.LightGray; //---- GSG (13/03/2019)
        //            }

        //            index++;
        //        }
        //    }
        //}


        //---- GSG (02/0272021)
        // Modificación para que además de pintar en gris los que ha comprado la farmacia en el último periodo establecido, también pinte los
        // que pertenecen a los grupos AR+AR, AR+MR y LANZAMIENTOS.
        // Para evitar que el solapamiento de estos, no muestre el primer grupo, un tercer color permitirá identificar los vendidos y a la vez en esta clasificación
        private void updateColorsMatsCliLastYear()
        {
            int index = 0;

            if ((sCodsMatsCliLastYear != "" && sCodsMatsCliLastYear != null) || (_lTipusAPintar != null && _lTipusAPintar[0] != null))
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (sCodsMatsCliLastYear.IndexOf(row.Cells["sIdMaterial"].Value.ToString() + ",") >= 0 && Comun.IsInTheArray(row.Cells["TipoClasificacion"].Value.ToString(), _lTipusAPintar))
                    {
                        //Cal pintar els dos estats gris+groc = demanats + classificats
                        dataGridView1.Rows[index].Cells["margen"].Style.BackColor = Color.Khaki;
                        dataGridView1.Rows[index].Cells["MargenLin"].Style.BackColor = Color.Khaki;
                        dataGridView1.Rows[index].Cells["sCodNacional"].Style.BackColor = Color.Khaki;
                        dataGridView1.Rows[index].Cells["sMaterial"].Style.BackColor = Color.Khaki;
                        dataGridView1.Rows[index].Cells["sIdMaterial"].Style.BackColor = Color.Khaki;
                        dataGridView1.Rows[index].Cells["fPrecio"].Style.BackColor = Color.Khaki;
                        dataGridView1.Rows[index].Cells["iCantidad"].Style.BackColor = Color.Khaki;
                        dataGridView1.Rows[index].Cells["fDescuento"].Style.BackColor = Color.Khaki;
                        dataGridView1.Rows[index].Cells["iStock"].Style.BackColor = Color.Khaki;
                        dataGridView1.Rows[index].Cells["iUnidadesEnfajado"].Style.BackColor = Color.Khaki;
                        dataGridView1.Rows[index].Cells["iCajaCompleta"].Style.BackColor = Color.Khaki;
                        dataGridView1.Rows[index].Cells["unisPedidas"].Style.BackColor = Color.Khaki; 
                        dataGridView1.Rows[index].Cells["TipoClasificacion"].Style.BackColor = Color.Khaki; 
                    }
                    else if (sCodsMatsCliLastYear.IndexOf(row.Cells["sIdMaterial"].Value.ToString() + ",") >= 0) //GRIS
                    {
                        dataGridView1.Rows[index].Cells["margen"].Style.BackColor = Color.LightGray;
                        dataGridView1.Rows[index].Cells["MargenLin"].Style.BackColor = Color.LightGray;
                        dataGridView1.Rows[index].Cells["sCodNacional"].Style.BackColor = Color.LightGray;
                        dataGridView1.Rows[index].Cells["sMaterial"].Style.BackColor = Color.LightGray;
                        dataGridView1.Rows[index].Cells["sIdMaterial"].Style.BackColor = Color.LightGray;
                        dataGridView1.Rows[index].Cells["fPrecio"].Style.BackColor = Color.LightGray;
                        dataGridView1.Rows[index].Cells["iCantidad"].Style.BackColor = Color.LightGray;
                        dataGridView1.Rows[index].Cells["fDescuento"].Style.BackColor = Color.LightGray;
                        dataGridView1.Rows[index].Cells["iStock"].Style.BackColor = Color.LightGray;
                        dataGridView1.Rows[index].Cells["iUnidadesEnfajado"].Style.BackColor = Color.LightGray;
                        dataGridView1.Rows[index].Cells["iCajaCompleta"].Style.BackColor = Color.LightGray;
                        dataGridView1.Rows[index].Cells["unisPedidas"].Style.BackColor = Color.LightGray;
                        dataGridView1.Rows[index].Cells["TipoClasificacion"].Style.BackColor = Color.LightGray;
                    }
                    else if (Comun.IsInTheArray(row.Cells["TipoClasificacion"].Value.ToString(), _lTipusAPintar)) //GROC
                    {
                        dataGridView1.Rows[index].Cells["margen"].Style.BackColor = Color.LightYellow;
                        dataGridView1.Rows[index].Cells["MargenLin"].Style.BackColor = Color.LightYellow;
                        dataGridView1.Rows[index].Cells["sCodNacional"].Style.BackColor = Color.LightYellow;
                        dataGridView1.Rows[index].Cells["sMaterial"].Style.BackColor = Color.LightYellow;
                        dataGridView1.Rows[index].Cells["sIdMaterial"].Style.BackColor = Color.LightYellow;
                        dataGridView1.Rows[index].Cells["fPrecio"].Style.BackColor = Color.LightYellow;
                        dataGridView1.Rows[index].Cells["iCantidad"].Style.BackColor = Color.LightYellow;
                        dataGridView1.Rows[index].Cells["fDescuento"].Style.BackColor = Color.LightYellow;
                        dataGridView1.Rows[index].Cells["iStock"].Style.BackColor = Color.LightYellow;
                        dataGridView1.Rows[index].Cells["iUnidadesEnfajado"].Style.BackColor = Color.LightYellow;
                        dataGridView1.Rows[index].Cells["iCajaCompleta"].Style.BackColor = Color.LightYellow;
                        dataGridView1.Rows[index].Cells["unisPedidas"].Style.BackColor = Color.LightYellow;
                        dataGridView1.Rows[index].Cells["TipoClasificacion"].Style.BackColor = Color.LightYellow;
                    }

                    index++;
                }
            }
        }





        //---- FI GSG


        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Mensajes.HideTip();

            if (dataGridView1.CurrentCell.Style.BackColor == DefaultValueColor)
            {
                //---- GSG (12/07/2021)
                //dataGridView1.CurrentCell.Value = DefaultValue;

                if (DefaultValue == "")
                    dataGridView1.CurrentCell.Value = "0";
                else
                    dataGridView1.CurrentCell.Value = DefaultValue;
            }
            

            //---- GSG (03/01/2012)
            if (_bCampanyaExtra)
            {
                _fDescExtraRestante = _fDescExtra - CalculaDescExtraGastados();
                txbDescExtraRestante.Text = _fDescExtraRestante.ToString();
            }



            //---- GSG (24/02/2012)
            ActualizarTotalesSeleccion();            
            //UpdateDataGridColors();
            updateColorsRentabilidad(e.RowIndex, false);

            


            //---- GSG (05/09/2012)
            int iQty = 0;
            if (dataGridView1.Rows[e.RowIndex].Cells["iCantidad"].Value.ToString() != "")
                iQty = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["iCantidad"].Value.ToString());
            else
                dataGridView1.Rows[e.RowIndex].Cells["iCantidad"].Value = iQty; //Para que no quede vacío
            if (!UpdateDataGridColorPendiente(int.Parse(dataGridView1.Rows[e.RowIndex].Cells["iStock"].Value.ToString()), iQty, int.Parse(dataGridView1.Rows[e.RowIndex].Cells["iPendientes"].Value.ToString())))
            {
                for (int i = 0; i < dataGridView1.Rows[e.RowIndex].Cells.Count; i++)
                    dataGridView1.Rows[e.RowIndex].Cells[i].Style.ForeColor = Color.Black;
            }

            //---- GSG (10/03/2014)
            if (UpdateDataGridColorEnfajadoCaja(iQty, int.Parse(dataGridView1.Rows[e.RowIndex].Cells["iUnidadesEnfajado"].Value.ToString()), int.Parse(dataGridView1.Rows[e.RowIndex].Cells["iCajaCompleta"].Value.ToString())))
            {
                dataGridView1.Rows[e.RowIndex].Cells["iUnidadesEnfajado"].Style.BackColor = EnfajadoCajaColor;
                dataGridView1.Rows[e.RowIndex].Cells["iCajaCompleta"].Style.BackColor = EnfajadoCajaColor;
            }
            else
            {
                dataGridView1.Rows[e.RowIndex].Cells["iUnidadesEnfajado"].Style.BackColor = dataGridView1.Rows[e.RowIndex].Cells["iCantidad"].Style.BackColor;
                dataGridView1.Rows[e.RowIndex].Cells["iCajaCompleta"].Style.BackColor = dataGridView1.Rows[e.RowIndex].Cells["iCantidad"].Style.BackColor;
            }
            //---- FI GSG

            

            
        }

        private void cmBoxMostrar_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDataGridView();
            //---- GSG (27/02/2012)
            _preRowSelected = -1;
            updateColorsRentabilidad(-1, false);

            if (dataGridView1.CurrentRow != null)
                updateColorsRentabilidad(dataGridView1.CurrentRow.Index, true);

            //---- GSG (31/07/2012)
            updateColorsMatsCliLastYear();

            //---- GSG (27/03/014)
            updateColorsSoloClub();
        }


        private void UpdateDataGridView()
        {
            try
            {
                filter = String.Empty;

                if (txbsIdMaterial.Text.Trim().Length > 0)
                    AddFilter("sIdMaterial LIKE '" + txbsIdMaterial.Text.Trim() + "%'");

                if (txbsDescripcion.Text.Trim().Length > 0)
                    AddFilter("sMaterial LIKE '" + txbsDescripcion.Text.Trim() + "%'");

                if (txbsCodNacional.Text.Trim().Length > 0)
                    AddFilter("sCodNacional LIKE '" + txbsCodNacional.Text.Trim() + "%'");

                if (txbsPrecio.Text.Trim().Length > 0)
                    AddFilter("fPrecio='" + txbsPrecio.Text.Trim() + "'");

                //---- GSG (22/01/2014)

                string filtro = "";

                //Filtra por tipo de material 
                if (cbTipoMaterial.SelectedIndex != 0) //Filtra por tipo
                {
                    //AddFilter("sTipoMatInformes = '" + cbTipoMaterial.SelectedValue.ToString() + "'");
                    filtro = "sTipoMatInformes = '" + cbTipoMaterial.SelectedValue.ToString() + "'";
                }

                //---- GSG (26/05/2015)
                string sLista = "";
                if (_bCampanyaMatsNoVenta)
                {
                    sLista = sCodsMatsCliLastYear;
                    if (sLista != null && sLista != "")
                    {
                        sLista = sLista.Remove(sLista.LastIndexOf(","), 1);
                        sLista = sLista.Replace(",", "','");                    
                        if (filtro == "")
                            filtro += " sIdMaterial not in ('" + sLista + "')";
                        else
                            filtro += " AND sIdMaterial not in ('" + sLista + "')";                        
                    }

                }

                //---- GSG (13/03/2019)
                //Filtra por tipo de producto
                if (cbTipoProd.SelectedIndex != 0) //Filtra por tipo
                {
                    filtro = "sTipoProdInformes = '" + cbTipoProd.SelectedValue.ToString() + "'";
                }




                //---- GSG (13/11/2013) 
                //if (cmBoxMostrar.SelectedIndex > 0)
                //    AddFilter("selected=1");

                if (cmBoxMostrar.SelectedIndex == 2) //Avisos
                {
                    GetListaUltimosAvisos();
                    if (dsMateriales1.ListaUltimosAvisos.Rows.Count > 0)
                    {
                        string mats = "";
                        string prods = "";
                        foreach (dsMateriales.ListaUltimosAvisosRow row in dsMateriales1.ListaUltimosAvisos.Rows)
                        {
                            if (row.sIdProducto != "" && row.sIdProducto != null)
                                prods += "'" + row.sDescripcion + "',"; //Cojo la descripción porque en la tabla de materiales es lo que tenemos (sorprendentemente no estáel código) 
                            else if (row.sIdMaterial != "" && row.sIdMaterial != null)
                                mats += "'" + row.sIdMaterial + "',";
                        }
                        //Eliminar la última coma
                        if (prods.Length > 0)
                            prods = prods.Substring(0, prods.Length - 1);
                        if (mats.Length > 0)
                            mats = mats.Substring(0, mats.Length - 1);

                        string sf = "";
                        if (mats.Length > 0 && prods.Length > 0)
                            sf = "sIdMaterial IN (" + mats + ") OR sDescripcion IN (" + prods + ")";
                        else if (mats.Length > 0)
                            sf = "sIdMaterial IN (" + mats + ")";
                        else if (prods.Length > 0)
                            sf = "sDescripcion IN (" + prods + ")";

                        //---- GSG (22/01/2014)
                        //AddFilter(sf);
                        if (filtro == "")
                            filtro = sf;
                        else
                            filtro += (" AND (" + sf + ")");
                    }
                }
                else if (cmBoxMostrar.SelectedIndex == 1)
                {
                    //---- GSG (22/01/2014)
                    //AddFilter("selected=1"); // si 0 son todos --> no filtro
                    if (filtro == "")
                        filtro = "selected = 1";
                    else
                        filtro += (" AND selected = 1");
                }
                else if (cmBoxMostrar.SelectedIndex == 3) //---- GSG (26/02/2018)
                {
                    if (filtro == "")
                        filtro = "iCantidad = 0 AND unisPedidas > 0";
                    else
                        filtro += (" AND iCantidad = 0 AND unisPedidas > 0");
                }


                if (filtro != "")
                    AddFilter(filtro);
                //---- FI GSG

                dsMateriales1.ListaMateriales.DefaultView.RowFilter = filter;


                //---- GSG (26/05/2015) probar con expositor crema adhesiva
                if (dsMateriales1.ListaMateriales.DefaultView.Count == 0)
                {
                    //Volver a dejar todos los materiales
                    if (filtro != "")
                        RemoveFilter(filtro);

                    filtro = filtro.Replace(" sIdMaterial not in ('" + sLista + "')", "");
                    filtro = filtro.Replace(" AND sIdMaterial not in ('" + sLista + "')", "");

                    if (filtro != "")
                    {
                        if (filtro.Substring(0, 4) == " AND")
                            filtro = filtro.Substring(4, filtro.Length - 4);
                        AddFilter(filtro);
                    }

                    dsMateriales1.ListaMateriales.DefaultView.RowFilter = filter;
                }
                //---- FI GSG


                dataGridView1.DataSource = dsMateriales1.ListaMateriales;

                UpdateDataGridColors();

                //despré de update pq poden desseleccionar-se per descompte
                this.lblNumReg.Text = dataGridView1.Rows.Count.ToString();

                
            }
            catch (Exception ex)
            {
                Mensajes.ShowError(ex.Message);
            }
        }

        private void AddFilter(string f)
        {
            if (filter.Length > 0)
                filter = String.Format("{0} AND {1}", filter, f);
            else
                filter = f;
        }

        private void RemoveFilter(string f)
        {
            //if (filter.Length > 0)
            //    filter = filter.Replace(f, "");
            
            if (filter.Length > 0)  //VLP Corregido error en filtro
            {
                filter = filter.Replace(f, "");

                if (filter.EndsWith(" AND ")) 
                {
                    filter = filter.Remove(filter.Length - 5);
                }
            }
        }

        private void dataGridView1_Sorted(object sender, EventArgs e)
        {
            UpdateDataGridColors();
            //---- GSG (27/02/2012)
            _preRowSelected = -1;
            updateColorsRentabilidad(-1, false);
            if (dataGridView1.CurrentRow != null)
                updateColorsRentabilidad(dataGridView1.CurrentRow.Index, true);

            //---- GSG (31/07/2012)
            updateColorsMatsCliLastYear();

            //---- GSG (27/03/014)
            updateColorsSoloClub();
        }


        //---- GSG (01/04/2011)
        private void btCambiar_Click(object sender, EventArgs e)
        {
            int iNumMats = 0;
            string idMat = "";
            int iUnitats = 0;
            double fDescompte = 0;
            string sIdCampanyaInicial = sIdCampanya; //---- GSG (26/08/2016)

            
            //---- VLP (26/07/2023)
            bool campanyaSeleccionadaEsDescMed = EsCampanyaNoDecMedio_FromBtnCambiar();
            string idCampanyaSeleccionada = cBoxCampanyas.SelectedValue.ToString();
            if (_lPairsMatCampEnPed.Count() > 0 && ((_bArrastre && !campanyaSeleccionadaEsDescMed) || (!_bArrastre && campanyaSeleccionadaEsDescMed) || (_bArrastre && _iIdCampanyaPedidoNoDescMedio != idCampanyaSeleccionada)))
            {                
                Mensajes.ShowExclamation("La campaña seleccionada es especial para descuentos en línea y es incompatible con el uso de otras campañas. El pedido solo puede tener esta campaña.");
                return;
            }

            //Mostrar missatge
            string msg = "¿Está seguro que quiere cambiar la campaña?";
            
            if (Mensajes.ShowQuestion(msg) == DialogResult.Yes)
            {
                formatFinVigencia(cBoxCampanyas.SelectedIndex); //---- GSG (06/10/2016)                

                if (dsMateriales1.ListaMateriales.Count > 0) //---- GSG (20/01/2016) Se ha cargado una campaña que no tiene líneas por no haber conseguido tarjeta con otra campaña (ej. salud ocular 40) --> no dejar cambiar para evitar error
                {
                    //---- GSG (03/01/2012)
                    bool bCanpanyaAnteriorExtra = _bCampanyaExtra;
                    bool bCanpanyaActualExtra = esDescExtra(cBoxCampanyas.SelectedIndex);

                    if (!bCanpanyaAnteriorExtra && !bCanpanyaActualExtra)
                    {
                        

                        //---- GSG (26/05/2015)
                        _bCampanyaMatsNoVenta = esCampanyaMatsNoVenta(cBoxCampanyas.SelectedIndex);

                        //---- GSG (25/10/2011)
                        SetDefaultColorLinSel(false);


                        //lblCampanya.Text = cBoxCampanyas.SelectedText; 
                        DataRowView rowView = dsFormularios1.ListaCampanyas.DefaultView[cBoxCampanyas.SelectedIndex];
                        lblCampanya.Text = rowView.Row["NombreCampanya"].ToString();


                        sIdCampanya = cBoxCampanyas.SelectedValue.ToString();
                        //////////////////---- GSG (17/11/2014)
                        ////////////////_sTipoSumaUnidades = GetTipoSumaUnidadesCampanya(sIdCampanya);

                        txtObservaciones.Text = rowView.Row["sObservaciones"].ToString(); //---- GSG (29/05/2013)


                        //---- GSG (12/07/2018)
                        txbMG.Text = String.Format("{0:#,0.##}%", IsDescMinGarInformed(sIdCampanya).ToString());
                        
                        //-----------------------




                        //Actalitza els valors de control segons la campanya seleccionada
                        actualitzaRestriccions();

                        //---- GSG (11/03/2014)
                        // Antes de recoger los seleccionados eliminar filtros para que no se pierda ningún material
                        txbsIdMaterial.Text = "";
                        txbsDescripcion.Text = "";
                        txbsCodNacional.Text = "";
                        txbsPrecio.Text = "";
                        cbTipoMaterial.SelectedIndex = 0;
                        cmBoxMostrar.SelectedIndex = 0;

                        UpdateDataGridView();
                        //---- FI GSG

                        //Recollir selecció
                        string[,] seleccionats = new string[dataGridView1.Rows.Count, 3];
                        iNumMats = GuardaMaterialsSeleccionats(ref seleccionats);

                        //Omple el grid amb els materials de la nova campanya seleccionada
                        cmBoxMostrar.SelectedIndex = 0; //---- GSG (01/02/2012)
                        CanviaGrid();

                        //Actualitza les unitats segons les dades (unitats) de la campanya anterior
                        //Si un material no hi és en aquesta campanya es perdrà la informació
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            idMat = row.Cells["sIdMaterial"].Value.ToString();
                            iUnitats = recuperaUnitatsiDescompte(ref fDescompte, idMat, iNumMats, seleccionats);
                            if (iUnitats != 0)
                            {
                                row.Cells["iCantidad"].Value = iUnitats;
                                //---- GSG (23/05/2011)
                                //Si el descompte no compleix les condicions de la nova campanya --> posar el màxim descompte de la nova
                                //row.Cells["fDescuento"].Value = fDescompte;
                                string sDescuentoMaximo = row.Cells["fDescuentoMaximo"].Value.ToString();
                                if (fDescompte > float.Parse(sDescuentoMaximo)) //fDescompte = valor introduit previament quan el material pertanyia a una altra campanya
                                    row.Cells["fDescuento"].Value = float.Parse(sDescuentoMaximo);
                                else
                                    row.Cells["fDescuento"].Value = fDescompte;
                                //---- FI GSG
                                //Si està a la llista segur que està seleccionat i les unitats són majors de 0 (mínim 1)
                                row.Cells["selected"].Value = true;
                            }
                            //Es té en compte el descompte? En aquest cas cal cotrolar que no s'hagi modificat ja anteriorment (això no és la càrrega inicial de la comanda)
                            if (!IsDescMaxInformed(sIdCampanya) && iUnitats == 0)
                                row.Cells["fDescuento"].Value = "0";

                        }

                        if (iNumMats > 0)
                        {
                            UpdateDataGridView();

                            
                            //---- GSG (26/08/2016)
                            // Cambiar la campaña de los materiales sin tocar los que pueda haber de otras campañas
                            List<KeyValuePair<string, string>> matsCampEnPedAux = new List<KeyValuePair<string, string>>();

                            foreach (KeyValuePair<string, string> val in _lPairsMatCampEnPed)
                            {
                                if (val.Value != sIdCampanyaInicial)
                                    matsCampEnPedAux.Add(val);
                                else
                                    matsCampEnPedAux.Add(new KeyValuePair<string, string>(val.Key, sIdCampanya));
                            }

                            _lPairsMatCampEnPed.Clear();
                            _lPairsMatCampEnPed = matsCampEnPedAux;
                            //---- FI GSG
                        }

                        //---- GSG (19/06/2015)
                        //---- GSG (17/05/2011)
                        //dataGridView1.Sort(dataGridView1.Columns["sMaterial"], 0);
                        if (GESTCRM.Clases.Configuracion.sIdRed == Comun.K_RED_GEN)
                            dataGridView1.Sort(dataGridView1.Columns["sMaterial"], 0);
                        else
                            dataGridView1.Sort(dataGridView1.Columns["sCodNacional"], 0);
                        dataGridView1.Refresh();
                        //---- FI GSG

                        ActualizarTotalesSeleccion(); //---- GSG (02/01/2023)

                    }
                    else if (!bCanpanyaAnteriorExtra && bCanpanyaActualExtra)//---- GSG (03/01/2012)
                    {
                        Mensajes.ShowExclamation("No se puede cambiar a una campaña del tipo Extra");
                    }
                    else if (bCanpanyaAnteriorExtra && !bCanpanyaActualExtra)
                    {
                        Mensajes.ShowExclamation("La actual campaña es de tipo Extra. No se puede cambiar a otra campaña.");
                    }
                    else //de extra a extra
                    {
                        Mensajes.ShowExclamation("La actual campaña es de tipo Extra. No se puede cambiar a otra campaña.");
                    }

                    //---- GSG (24/02/2012)
                    _preRowSelected = -1;
                    updateColorsRentabilidad(-1, false);
                    //---- GSG (31/07/2012)
                    updateColorsMatsCliLastYear();
                    //---- GSG (27/03/014)
                    updateColorsSoloClub();

                }
                else //---- GSG (20/01/2016)
                {
                    Mensajes.ShowExclamation("No se puede cambiar de campaña ya que la original no tiene líneas. Cierre la ventana y seleccione otra campaña en la ventana de pedidos.");
                    this.Close();
                }
            }
        }

        // ---- VLP (26/07/2023)
        // Comprueba si la campaña seleccionada en el combo cBoxCampanyas es una campaña a la que aplica el No Descuento Medio (tipoNoDescMedio) cuando se llama desde el boton Aceptar
        private bool EsCampanayaNoDesMedio_FromBtnAcpetar()
        {            
            bool esArrastre = dsFormularios1.ListaCampanyas.First(x => x.idCampanya == sIdCampanya).bArrastre;            
            return (esArrastre && Comun.IsInTheArray(_sTipoPedido, Configuracion.asTiposNoDescMedio));                        
        }

        
        // ---- VLP (26/07/2023)
        // Retorna si la campaña del PEDIDO es tipo no descuento medio cuando se llama desde el boton Cambiar
        private bool EsCampanyaNoDecMedio_FromBtnCambiar() 
        {
            string idCampanya = cBoxCampanyas.SelectedValue.ToString();
            bool esArrastre = dsFormularios1.ListaCampanyas.First(x => x.idCampanya == idCampanya).bArrastre;
            return (esArrastre && Comun.IsInTheArray(_sTipoPedido, Configuracion.asTiposNoDescMedio));
        }

        // ---- VLP (26/07/2023)
        // Retorna si la campaña del PEDIDO es tipoNoDescuentoMedio
        private bool PedidoEsNoDecsMedio(out string idCampanya)
        {
            bool ret = false;
            idCampanya = "";

            var idsCampanyas = _lPairsMatCampEnPed.Select(x => x.Value).Distinct();
            if (idsCampanyas.Count() == 1)
            {                
                //bool esArrastre = dsFormularios1.ListaCampanyas.First(x => x.idCampanya == idsCampanyas.First()).bArrastre;
                //ret = esArrastre && Comun.IsInTheArray(_sTipoPedido, Configuracion.asTiposNoDescMedio);

                var campanya = dsFormularios1.ListaCampanyas.First(x => x.idCampanya == idsCampanyas.First());
                bool esArrastre = campanya.bArrastre;
                idCampanya = campanya.idCampanya;
                ret = esArrastre && Comun.IsInTheArray(_sTipoPedido, Configuracion.asTiposNoDescMedio);
            }
                        
            return ret;
        }

        private int GuardaMaterialsSeleccionats(ref string[,] sel)
        {
            int nIndex = 0;

            sel.Initialize();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (bool.Parse(row.Cells["selected"].Value.ToString()) == true) 
                {
                    sel[nIndex, 0] = row.Cells["sIdMaterial"].Value.ToString();
                    sel[nIndex, 1] = row.Cells["iCantidad"].Value.ToString();
                    sel[nIndex, 2] = row.Cells["fDescuento"].Value.ToString();

                    nIndex++;
                }
            }

            //Retorna el nombre de materials a traspassar de campanya
            return nIndex;
        }

        private void CanviaGrid()
        {
            //---- GSG CECL 19/05/2016
            if (System.Configuration.ConfigurationManager.AppSettings["TipoDelegadoPedidosCentral"].ToString() == Comun.K_CECL)
                sqlDaListaMateriales.SelectCommand.CommandText = "[ListaMaterialesDesCampCECL]";
            else
                sqlDaListaMateriales.SelectCommand.CommandText = "[ListaMaterialesDesCamp]";
            //---- FI GSG CECL

            //Pasamos el parámetro
            this.sqlDaListaMateriales.SelectCommand.Parameters["@iIdCamp"].Value = sIdCampanya;
            //---- GSG (08/04/2016)
            this.sqlDaListaMateriales.SelectCommand.Parameters["@sIdTipoPedido"].Value = _sTipoPedido;
            this.sqlDaListaMateriales.SelectCommand.Parameters["@iIdDelegado"].Value = Clases.Configuracion.iIdDelegado;

            //Llenamos la lista de materiales
            dsMateriales1.ListaMateriales.Clear();
            this.sqlDaListaMateriales.Fill(dsMateriales1);

            //Y actualizamos el DataGridView
            UpdateDataGridView();
        }

        private int recuperaUnitatsiDescompte(ref double fDesc, string idMat, int iDim, string[,] sel)
        {
            for (int i = 0; i < iDim; i++)
            {
                if (idMat == sel[i, 0])
                {
                    fDesc = double.Parse(sel[i, 2]);
                    return int.Parse(sel[i, 1]);
                }
            }

            //Retorna 0 unitats si el material no hi és
            return 0;
        }

        //---- GSG (06/06/2013)
        //private void LlenarCombos()
        //---- GSG (07/07/2017)
        //private void LlenarCombos(int iIdCliente)
        private void LlenarCombos(int iIdCliente, string mayorista)
        {
            try
            {
                //Omple el combo amb les campanyes
                dsFormularios1.ListaCampanyas.Clear();

                //---- GSG (05/06/2013)
                //sqldaListaCampanyas.Fill(dsFormularios1.ListaCampanyas);
                //dsFormularios1.ListaCampanyas.DefaultView.RowFilter = "bSeleccionable=1";
                //cBoxCampanyas.DataSource = dsFormularios1.ListaCampanyas.DefaultView;
                //---- GSG (07/07/2017)
                //FormatBuscarCampanyas(iIdCliente, true, _sTipoPedido);
                FormatBuscarCampanyas(iIdCliente, true, _sTipoPedido, mayorista);


                //---- GSG (22/01/2014)
                //Inicializar ComboBox cbTipoMaterial
                this.sqldaListaTipoMaterialInforme.Fill(this.dsMateriales1);
                DataRow fila = this.dsMateriales1.ListaTipoMaterialInforme.NewRow();
                fila["sValor"] = "-1";
                fila["sLiteral"] = "Todos";
                this.dsMateriales1.ListaTipoMaterialInforme.Rows.InsertAt(fila, 0);
                this.cbTipoMaterial.SelectedValue = "-1";

                //---- GSG (13/06/2019)
                //Inicializar ComboBox cbTipoProd
                this.sqldaListaTipoProductoInforme.Fill(this.dsMateriales1);
                DataRow fila2 = this.dsMateriales1.ListaTipoProductoInforme.NewRow();
                fila2["sValor"] = "-1";
                fila2["sLiteral"] = "Todos";
                this.dsMateriales1.ListaTipoProductoInforme.Rows.InsertAt(fila2, 0);
                this.cbTipoProd.SelectedValue = "-1";


            }
            catch (Exception ex)
            {
                Mensajes.ShowError(ex.Message);
            }
        }

        //---- GSG (03/01/2012)
        //Detectar si la campanya és sensible al descompte extra
        private bool esDescExtra(int indexCampanyaSelected)
        {
            DataRowView rowView = dsFormularios1.ListaCampanyas.DefaultView[indexCampanyaSelected];
            return bool.Parse(rowView.Row["bDescExtra"].ToString());
        }
       
        //---- GSG (26/05/2015)
        private bool esCampanyaMatsNoVenta(int indexCampanyaSelected)
        {
            DataRowView rowView = dsFormularios1.ListaCampanyas.DefaultView[indexCampanyaSelected];
            if (rowView.Row["bEnviadoPDA"] == System.DBNull.Value)
                return false;
            
            return bool.Parse(rowView.Row["bEnviadoPDA"].ToString());
        }

        //---- GSG (29/09/2015)
        //Valor del descuento máximo para las campañas de regalo especiales
        private float valorDescMaxRegaloEspecial(int indexCampanyaSelected)
        {
            DataRowView rowView = dsFormularios1.ListaCampanyas.DefaultView[indexCampanyaSelected];
            return float.Parse(rowView.Row["fDescImpNeto"].ToString());
        }

        //---- GSG (06/10/2016)
        private string valorFechaFinVigencia(int indexCampanyaSelected)
        {
            DataRowView rowView = dsFormularios1.ListaCampanyas.DefaultView[indexCampanyaSelected];
            return rowView.Row["dVigenciaFin"].ToString().Substring(0, 10);
        }

        private void formatFinVigencia(int indexCampanyaSelected)
        {
            // Mostrar la fecha de fin de vigencia de la campaña si es menor a dos años vista
            string fecha = valorFechaFinVigencia(indexCampanyaSelected);
            if (DateTime.Today.AddYears(2) >= DateTime.Parse(fecha))
            {
                lblVigencia.Visible = true;
                lblValorVigencia.Text = fecha;
                lblValorVigencia.Visible = true;
            }
            else
            {
                lblVigencia.Visible = false;
                lblValorVigencia.Visible = false;
            }
        }

        private void actualitzaRestriccions()
        {
            //Restriccions campanya
            DataRowView rowView = dsFormularios1.ListaCampanyas.DefaultView[cBoxCampanyas.SelectedIndex];
            
            sIdCampanya = rowView.Row["idCampanya"].ToString();
            NombreCampanya = rowView.Row["NombreCampanya"].ToString();
            NumMinOblis = rowView.Row["iNumMinOblis"].ToString();
            ImporteMinObli = rowView.Row["fImporteMinObli"].ToString();
            dImporteBrutoMinObli = double.Parse(rowView.Row["fImporteMinObliBruto"].ToString());
            iCantidadTotalMinObli = int.Parse(rowView.Row["iNumMinOblisTotal"].ToString());
        }


        private bool IsDescMaxInformed(string sIdCampanya)
        {
            bool ret = false;

            this.dsFormularios1.GetInformaDesc.Clear();
            this.sqlCmdGetIsDescuentoMaxInformed.Parameters["@idCampanya"].Value = sIdCampanya;

            using (SqlDataAdapter oDa = new SqlDataAdapter(sqlCmdGetIsDescuentoMaxInformed))
            {
                oDa.Fill(dsFormularios1.GetInformaDesc);
            }

            if (dsFormularios1.GetInformaDesc != null)
            {
                ret = bool.Parse(dsFormularios1.GetInformaDesc.Rows[0]["bInfDesc"].ToString());
            }

            return ret; 
        }


        //---- GSG (03/01/2012)
        private double CalculaDescExtraGastados()
        {
            double ret = 0.0;

            //if (!_bArrastre) //---- VLP (26/07/2023). Comentado
            //{
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if ((bool)row.Cells["selected"].Value == true)
                    {
                        int iQty = 0;
                        if (row.Cells["iCantidad"].Value.ToString() != "")
                            iQty = int.Parse(row.Cells["iCantidad"].Value.ToString());
                        ret += iQty * double.Parse(row.Cells["fPrecio"].Value.ToString());
                    }
                }
            //}

            return ret;
        }


        //---- GSG (24/02/2012)
        private void ActualizarTotalesSeleccion()
        {
            double Neto = 0.0;
            double Bruto = 0.0;
            int TotalUnidadesCamp = 0; //---- GSG (24/10/2019)
            int TotalUnidadesCampConBase = 0; //---- GSG (02/01/2023)

            //if (!_bArrastre) //---- GSG (22/01/2015) //---- VLP (26/07/2023). Comentado
            //{ 
                foreach (DataGridViewRow dr in dataGridView1.Rows)
                {
                    if ((bool)dr.Cells["selected"].Value == true)
                    {
                        int iQty = 0;
                        if (dr.Cells["iCantidad"].Value.ToString() != "")
                            iQty = int.Parse(dr.Cells["iCantidad"].Value.ToString());

                        double brulin = double.Parse(dr.Cells["fPrecio"].Value.ToString()) * iQty;
                        Bruto += brulin;
                        Neto += (brulin - ((brulin * double.Parse(dr.Cells["fDescuento"].Value.ToString())) / 100));

                        
                        TotalUnidadesCamp += iQty; //---- GSG (24/10/2019)
                        //---- GSG (02/01/2023)
                        if (dr.Cells["sTipoMat"].Value.ToString() != K_ZMKT)
                            TotalUnidadesCampConBase += iQty * int.Parse(dr.Cells["iCantidadBase"].Value.ToString()); 

                    }
                }

                double Descuento;
                if (Bruto != 0.0)
                    Descuento = (1 - (Neto / Bruto)) * 100;
                else
                    Descuento = 0.0;


                txbImporte.Text = Neto.ToString("C2");
                txbImporteBruto.Text = Bruto.ToString("C2");
                txbDto.Text = String.Format("{0:#,0.##}%", Descuento);

                
                txbTotalUnidades.Text = TotalUnidadesCamp.ToString(); //---- GSG (24/10/2019)
                txbTotalUnidadesConBase.Text = TotalUnidadesCampConBase.ToString(); //---- GSG (02/01/2023)
            //}


            ActualizarRentabilidadSeleccion();

        }

        //---- GSG (29/09/2015)
        private bool ActualizarTotalesSiCampanyaRegaloEspecial(string idCampanya)
        {
            bool ret = false;

            foreach (RegaloEspecial re in _lRegaloEspecial)
            {
                string codc = re.codCamp;
                double brutoRegalos = 0;
                double brutoTotal = 0;
                string idMat = "";                
                int TotalUnidadesCamp = 0; //---- GSG (24/10/2019)
                int TotalUnidadesCampConBase = 0; //---- GSG (02/01/2023)

                if (idCampanya == codc)
                {
                    foreach (DataGridViewRow dr in dataGridView1.Rows)
                    {
                        if ((bool)dr.Cells["selected"].Value == true)
                        {
                            idMat = dr.Cells["sIdMaterial"].Value.ToString();
                            if (re.EsRegalo(idMat))
                            {
                                int qty = int.Parse(dr.Cells["iCantidad"].Value.ToString());
                                double precio = double.Parse(dr.Cells["fPrecio"].Value.ToString());
                                brutoRegalos += (qty * precio);
                                brutoTotal += (qty * precio);
                                TotalUnidadesCamp += qty; //---- GSG (24/10/2019)
                                //---- GSG (02/01/2023)
                                if (dr.Cells["sTipoMat"].Value.ToString() != K_ZMKT)
                                    TotalUnidadesCampConBase += qty * int.Parse(dr.Cells["iCantidadBase"].Value.ToString()); 

                            }
                            else if (re.EsEspecial(idMat))
                            {
                                int qty = int.Parse(dr.Cells["iCantidad"].Value.ToString());
                                double precio = double.Parse(dr.Cells["fPrecio"].Value.ToString());
                                brutoTotal += (qty * precio);
                                TotalUnidadesCamp += qty; //---- GSG (24/10/2019)
                                //---- GSG (02/01/2023)
                                if (dr.Cells["sTipoMat"].Value.ToString() != K_ZMKT)
                                    TotalUnidadesCampConBase += qty * int.Parse(dr.Cells["iCantidadBase"].Value.ToString()); 
                            }
                        }
                    }

                    double descMedio = brutoRegalos / brutoTotal;
                    
                    txbImporteBruto.Text = brutoTotal.ToString("C2");
                    txbDto.Text = String.Format("{0:#,0.##}%", descMedio * 100);
                    txbImporte.Text = (brutoTotal - (brutoTotal * descMedio / 100)).ToString("C2"); //Neto


                    
                    txbTotalUnidades.Text = TotalUnidadesCamp.ToString(); //---- GSG (24/10/2019)
                    txbTotalUnidadesConBase.Text = TotalUnidadesCampConBase.ToString(); //---- GSG (02/01/2023)



                    ret = true;
                    break; //Aquí todas las líneas son de la misma campaña
                }
            }

            return ret;
        }

        private bool esCampanyaRegaloEspecial(int indexCampanyaSelected)
        {
            bool bRet = false;

            DataRowView rowView = dsFormularios1.ListaCampanyas.DefaultView[indexCampanyaSelected];
            string idCampanya = rowView.Row["idCampanya"].ToString();

            foreach (RegaloEspecial re in _lRegaloEspecial)
            {
                string codc = re.codCamp;

                if (idCampanya == codc)
                {
                    bRet = true;
                    break;
                }
            }

            return bRet;

            

        }





        #region rentabilidad
        private void ActualizarRentabilidadSeleccion()
        {
            //---- GSG (23/04/2012)
            Color cColor = Color.FromArgb(238, 243, 246);
            //---- FI GSG
            float Renta = Calcular_RentabilidadSeleccion();

            if (!float.IsNaN(Renta))
            {
                txtRentabilidad.Text = Renta.ToString("N2");
                //---- GSG (11/11/2014) Añade fecha
                txbRentabilidad.Text = CalcularDescripcionRentabilidad(Renta, DateTime.Today);
                cColor = CalcularColorRentabilidad(Renta, DateTime.Today);
                txbRentabilidad.ForeColor = cColor; //---- GSG (23/06/2017)
            }
            else
            {
                txtRentabilidad.Text = "0";
                //---- GSG (23/06/2017)
                //txbRentabilidad.Text = "Sin catalogar";
                txbRentabilidad.Text = "No cuenta";
                cColor = Color.Black;
                txbRentabilidad.ForeColor = Color.White;
            }

            //---- GSG (23/04/2012)
            //switch (txbRentabilidad.Text)
            //{
            //    case "ROJO":
            //        txbRentabilidad.BackColor = Color.Red;
            //        break;
            //    case "NARANJA":
            //        txbRentabilidad.BackColor = Color.Orange;
            //        break;
            //    case "VERDE":
            //        txbRentabilidad.BackColor = Color.Green;
            //        break;
            //    default:
            //        txbRentabilidad.BackColor = Color.FromArgb(238, 243, 246);
            //        break;
            //}

            txbRentabilidad.BackColor = cColor;

            //---- FI GSG
            

            //---- GSG (29/09/2020) PUNTOS
            txtMargen.Text = Calcular_MargenSeleccion().ToString("N2");
        }


        private float Calcular_RentabilidadSeleccion()
        {
            float rentabilitat = 0.0F;
            float denominador = 0.0F;

            //if (!_bArrastre) //---- VLP (26/07/2023). Comentado
            //{
                foreach (DataGridViewRow dr in dataGridView1.Rows)
                {
                    if ((bool)dr.Cells["selected"].Value == true)
                    {
                        //if (!Comun.IsInTheArray(dr.Cells["sIdMaterial"].Value.ToString().Trim(), lMatsNoRenta))
                        if (!Comun.IsInTheArray(dr.Cells["sIdMaterial"].Value.ToString().Trim(), lMatsNoRenta) && !Comun.IsInTheArray(sIdCampanya, _lCampanyasNoRenta))
                        {
                            int iCantidad = 0;
                            if (dr.Cells["iCantidad"].Value.ToString() != "")
                                iCantidad = int.Parse(dr.Cells["iCantidad"].Value.ToString());
                            float fPrecio = float.Parse(dr.Cells["fPrecio"].Value.ToString());

                            float fDescuento = float.Parse(dr.Cells["fDescuento"].Value.ToString());
                            float fCoste = -1;

                            if (dr.Cells["fCoste"].Value != DBNull.Value)
                                fCoste = float.Parse(dr.Cells["fCoste"].Value.ToString());

                            rentabilitat += DameNominadorRentabilidad(iCantidad, fPrecio, fDescuento, fCoste);
                            denominador += DameDenominadorRentabilidad(iCantidad, fPrecio);
                        }
                    }
                }
            //}

            float res = 0.0F;
            //if (!(denominador == 0 && rentabilitat != 0))   //Aquest cas donaria -Infinity i al retorna no queda controlat per float.isNAN


            if (rentabilitat == 0 && denominador == 0)
                res = float.NaN;
            //else if (!(denominador == 0 && rentabilitat != 0) && !_bArrastre)   //Aquest cas donaria -Infinity i al retorna no queda controlat per float.isNAN
            else if (!(denominador == 0 && rentabilitat != 0))  //---- VLP (26/07/2023). Comentada la linea de arriba y añadida esta.
                res = (rentabilitat / denominador) * 100.0F;

            return res;
        }


        private float DameNominadorRentabilidad(int iCantidad, float fPrecio,float fDescuento, float fCoste )
		{
			float fRentabilidad = 0.0F;				
            float preu = (float)iCantidad * fPrecio;
							
			if (preu != 0)
			{
				if (fCoste != -1)		
				{								
					float desc =  preu * (fDescuento / 100.0F);									
					float ret  =  preu - desc - (iCantidad * fCoste);

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
        private string CalcularDescripcionRentabilidad(float Rentabilidad, DateTime fecha)
        {
            string Descripcion = "No catalogada";

            dsPedidos1.GetRentabilidadDescripcion.Clear();
            sqlCmdGetRentabilidadDescripcion.Parameters["@Rentabilidad"].Value = Rentabilidad;
            sqlCmdGetRentabilidadDescripcion.Parameters["@fecha"].Value = fecha;

            using (SqlDataAdapter oDa = new SqlDataAdapter(sqlCmdGetRentabilidadDescripcion))
            {
                oDa.Fill(dsPedidos1.GetRentabilidadDescripcion);
            }

            if (dsPedidos1.GetRentabilidadDescripcion != null && dsPedidos1.GetRentabilidadDescripcion.Rows.Count > 0)
            {
                Descripcion = dsPedidos1.GetRentabilidadDescripcion.Rows[0]["DescRentabilidad"].ToString();
            }

            return Descripcion;
        }

        //---- GSG (11/11/2014) Añade fecha
        //---- GSG (23/04/2012)
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
        //---- FI GSG

        private int ObtenirMaterialsNoRentabilitat()
        {
            string mat = "";
            int comptador = 0;
            SqlDataReader dr;

            try
            {
                if (sqlConn.State.ToString() == "Closed")
                    sqlConn.Open();

                //---- GSG (02/02/2021)
                //lMatsNoRenta = new string[200];
                lMatsNoRenta = new string[2000];

                //---- GSG CECL 19/05/2016
                if (System.Configuration.ConfigurationManager.AppSettings["TipoDelegadoPedidosCentral"].ToString() == Comun.K_CECL)
                    sqlCmdGetMaterialesNoRentabilidad.CommandText = "[GetMaterialesNoRentabilidadCECL]";
                else
                    sqlCmdGetMaterialesNoRentabilidad.CommandText = "[GetMaterialesNoRentabilidad]";
                //---- FI GSG CECL 


                sqlCmdGetMaterialesNoRentabilidad.Parameters["@sIdPedido"].Value =  " "; //---- GSG (01/04/2016)

                dr = sqlCmdGetMaterialesNoRentabilidad.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        mat = dr["sIdMaterial"].ToString().Trim();
                        lMatsNoRenta[comptador] = mat;
                        comptador++;
                    }
                }

                dr.Close();
            }
            catch (Exception e)
            {
                Mensajes.ShowError(e.ToString());
            }

            return comptador;
        }

        //---- GSG (29/09/2020) PUNTOS
        private int ObtenirMaterialsNoMargen()
        {
            string mat = "";
            int comptador = 0;
            SqlDataReader dr;

            try
            {
                if (sqlConn.State.ToString() == "Closed")
                    sqlConn.Open();

                lMatsNoMargen = new string[5000];


                sqlCmdGetMaterialesNoMargen.CommandText = "[GetMaterialesNoMargen]";

                dr = sqlCmdGetMaterialesNoMargen.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        mat = dr["sIdMaterial"].ToString().Trim();
                        lMatsNoMargen[comptador] = mat;
                        comptador++;
                    }
                }

                dr.Close();
            }
            catch (Exception e)
            {
                Mensajes.ShowError(e.ToString());
            }

            return comptador;
        }


        private string ObtenirMaterialsARARNoCli()
        {
            SqlDataReader dr;

            _sMatsARARnoCli = "";

            try
            {
                if (sqlConn.State.ToString() == "Closed")
                    sqlConn.Open();


                sqlCmdGetMatsARARnoCli.CommandText = "[ListaMatsARARnoCli]";
                sqlCmdGetMatsARARnoCli.Parameters["@iIdCliente"].Value = _iIdCliente;


                dr = sqlCmdGetMatsARARnoCli.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        _sMatsARARnoCli += dr["sIdMaterial"].ToString().Trim() + " - " + dr["sMaterial"].ToString().Trim() + "\r\n";
                    }
                }

                dr.Close();
            }
            catch (Exception e)
            {
                Mensajes.ShowError(e.ToString());
            }

            return _sMatsARARnoCli;
        }



        private string ObtenirMaterialsMRARNoCli()
        {
            SqlDataReader dr;

            _sMatsMRARnoCli = "";

            try
            {
                if (sqlConn.State.ToString() == "Closed")
                    sqlConn.Open();


                sqlCmdGetMatsMRARnoCli.CommandText = "[ListaMatsMRARnoCli]";
                sqlCmdGetMatsMRARnoCli.Parameters["@iIdCliente"].Value = _iIdCliente;

                dr = sqlCmdGetMatsMRARnoCli.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        _sMatsMRARnoCli += dr["sIdMaterial"].ToString().Trim() + " - " + dr["sMaterial"].ToString().Trim() + "\r\n";
                    }
                }

                dr.Close();
            }
            catch (Exception e)
            {
                Mensajes.ShowError(e.ToString());
            }

            return _sMatsMRARnoCli;
        }

        private float Calcular_MargenFila(int fila)
        {
            float margen = 0.0F;

            if (!Comun.IsInTheArray(dataGridView1.Rows[fila].Cells["sIdMaterial"].Value.ToString().Trim(), lMatsNoMargen))
            {
                int iCantidad = 0;
                if (dataGridView1.Rows[fila].Cells["iCantidad"].Value.ToString() != "")
                    iCantidad = int.Parse(dataGridView1.Rows[fila].Cells["iCantidad"].Value.ToString());
                if (iCantidad == 0)
                    iCantidad = 1;
                float fPrecio = float.Parse(dataGridView1.Rows[fila].Cells["fPrecio"].Value.ToString());
                float fDescuento = float.Parse(dataGridView1.Rows[fila].Cells["fDescuento"].Value.ToString());
                float fCoste = -1;




                //---- GSG (02/01/2023)
                //if (dataGridView1.Rows[fila].Cells["fCoste"].Value != DBNull.Value)
                //    fCoste = float.Parse(dataGridView1.Rows[fila].Cells["fCoste"].Value.ToString());

                float fPrecioUnitario = fPrecio / iCantidad;

                if (dataGridView1.Rows[fila].Cells["fCoste"].Value != DBNull.Value)
                    fCoste = float.Parse(dataGridView1.Rows[fila].Cells["fCoste"].Value.ToString());
                else
                    fCoste = fPrecioUnitario;
                //---- FI GSG

                margen += DameNominadorRentabilidad(iCantidad, fPrecio, fDescuento, fCoste);

            }

            return margen;
        }

        //---- GSG (02/02/2021)
        private int ObtenirMaterialsClassificatsConAGrocs()
        {
            SqlDataReader dr;
            int comptador = 0;

            _lTipusAPintar = new string[2000];

            try
            {
                if (sqlConn.State.ToString() == "Closed")
                    sqlConn.Open();


                sqlCmdGetTiposMatAPintar.CommandText = "[GetTiposMatAPintar]";
                sqlCmdGetTiposMatAPintar.Parameters["@tipo"].Value = 0;

                dr = sqlCmdGetTiposMatAPintar.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        _lTipusAPintar[comptador] = dr["descTipo"].ToString().Trim();
                        comptador++;
                    }
                }

                dr.Close();
            }
            catch (Exception e)
            {
                Mensajes.ShowError(e.ToString());
            }

            return comptador;
        }

        
        //---- FI GSG PUNTOS

        private float Calcular_RentabilidadFila(int fila)
        {
            float rentabilitat = 0.0F;
            float denominador = 0.0F;

            if (!Comun.IsInTheArray(dataGridView1.Rows[fila].Cells["sIdMaterial"].Value.ToString().Trim(), lMatsNoRenta))
            {
                int iCantidad = 0;
                if (dataGridView1.Rows[fila].Cells["iCantidad"].Value.ToString() != "") 
                    iCantidad = int.Parse(dataGridView1.Rows[fila].Cells["iCantidad"].Value.ToString());
                //---- GSG (07/05/2014) Para que calcule igualmente la rentabilidad para una unidad 
                // ---------------------(hemos hecho que por defecto se muestren 0 unidades en lugar de 1 por defecto)
                if (iCantidad == 0)
                    iCantidad = 1;
                //---- FI GSG
                float fPrecio = float.Parse(dataGridView1.Rows[fila].Cells["fPrecio"].Value.ToString());
                float fDescuento = float.Parse(dataGridView1.Rows[fila].Cells["fDescuento"].Value.ToString());
                float fCoste = -1;

                if (dataGridView1.Rows[fila].Cells["fCoste"].Value != DBNull.Value)
                    fCoste = float.Parse(dataGridView1.Rows[fila].Cells["fCoste"].Value.ToString());

                rentabilitat += DameNominadorRentabilidad(iCantidad, fPrecio, fDescuento, fCoste);
                denominador += DameDenominadorRentabilidad(iCantidad, fPrecio);
            }


            float res = 0.0F;
            if (!(denominador == 0 && rentabilitat != 0))   //Aquest cas donaria -Infinity i al retorna no queda controlat per float.isNAN
                res = (rentabilitat / denominador) * 100.0F;

            return res;
        }



        //---- GSG (23/04/2012) 
        //private string ActualizarRentabilidadFila(int fila, out string valorR)
        //---- GSG (29/09/2020) PUNTOS
        //private string ActualizarRentabilidadFila(int fila, out string valorR, out Color cColor)
        private string ActualizarRentabilidadFila(int fila, out string valorR, out Color cColor, out float margenFila)
        {
            float Renta = Calcular_RentabilidadFila(fila);
            string textRenta = "";
            string textbRenta = "";
            float margen = Calcular_MargenFila(fila); //---- GSG (29/09/2020) PUNTOS

            if (!float.IsNaN(Renta))
            {
                textRenta = Renta.ToString("N2");
                //---- GSG (11/11/2014) 
                //textbRenta = CalcularDescripcionRentabilidad(Renta);
                //cColor = CalcularColorRentabilidad(Renta);
                textbRenta = CalcularDescripcionRentabilidad(Renta, DateTime.Today);
                cColor = CalcularColorRentabilidad(Renta, DateTime.Today);
            }
            else
            {
                textRenta = "0";
                //---- GSG (23/06/2017)
                //textbRenta = "Sin catalogar";
                ////---- GSG (23/04/2012)
                //cColor = Color.FromArgb(238, 243, 246);
                textbRenta = "No cuenta";
                cColor = Color.FromArgb(0, 0, 0);
            }

            valorR = textRenta;

            margenFila = margen; //---- GSG (29/09/2020) PUNTOS

            return textbRenta;
        }

        #endregion


        //---- GSG (29/09/2020) PUNTOS
        private float Calcular_MargenSeleccion()
        {
            float margen = 0.0F;

            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                if ((bool)dr.Cells["selected"].Value == true)
                {
                    if (!Comun.IsInTheArray(dr.Cells["sIdMaterial"].Value.ToString().Trim(), lMatsNoMargen))
                    {
                        //margen += float.Parse(dr.Cells["margenLin"].Value.ToString()); no puc agafar margenlin perquè encara no s'ha calculat
                        // Aquí ya se están sumando puntos directamente
                        margen += (float.Parse(dr.Cells["margen"].Value.ToString()) * int.Parse(dr.Cells["iCantidad"].Value.ToString()));
                    }
                }
            }

            return margen;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentCell.ReadOnly == false)
                dataGridView1.BeginEdit(true);

            //---- GSG (25/10/2011)
            SetDefaultColorLinSel(false);
            //---- GSG (27/02/2012)            
            updateColorsRentabilidad(e.RowIndex, true);
            if (_preRowSelected > -1)
                updateColorsRentabilidad(_preRowSelected, false);
            _preRowSelected = e.RowIndex;


            //---- FI GSG
        }


        //---- GSG (12/04/2011)
        //Hi haurà campanyes que no influiran en el càlcul de la rendabilitat de la comanda
        private int ObtenirCampanyasNoRentabilitat()
        {
            string camp = "";
            int comptador = 0;
            SqlDataReader dr;

            try
            {
                if (sqlConn.State.ToString() == "Closed")
                    sqlConn.Open();

                //---- GSG (02/02/2021)
                //_lCampanyasNoRenta = new string[200];
                _lCampanyasNoRenta = new string[2000];

                dr = sqlCmdGetCampanyasNoRentabilidad.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        camp = dr["idCampanya"].ToString().Trim();
                        _lCampanyasNoRenta[comptador] = camp;
                        comptador++;
                    }
                }

                dr.Close();
            }
            catch (Exception e)
            {
                Mensajes.ShowError(e.ToString());
            }

            return comptador;
        }

        //---- GSG (05/07/2017)

        /*
        //---- GSG (05/06/2013)
        private bool FormatBuscarCampanyas(int cliente, bool activo)
        {
            bool bEsClienteConAccMark_Ant = _bEsClienteConAccMark;
            bool bRet = false;

            _bEsClienteConAccMark = false;


            if (activo)
            {
                if (GetAccMarkConCampanyaCli(cliente))
                {
                    int num = dsAccionesMarketing1.ListaMAccMarkCampSolsCods.Rows.Count;
                    string[] campanyas = new string[num];

                    for (int i = 0; i < num; i++)
                    {
                        GESTCRM.Formularios.DataSets.dsAccionesMarketing.ListaMAccMarkCampSolsCodsRow row = (GESTCRM.Formularios.DataSets.dsAccionesMarketing.ListaMAccMarkCampSolsCodsRow)dsAccionesMarketing1.ListaMAccMarkCampSolsCods.Rows[i];
                        campanyas[i] = row.idCampanya.ToString();
                    }

                    LlenarComboCampanyas(1, campanyas);
                    _bEsClienteConAccMark = true;

                }
                else
                    LlenarComboCampanyas(2, "-1");
            }
            else
                    LlenarComboCampanyas(2, "-1");

            cBoxCampanyas.Enabled = activo;


            if (bEsClienteConAccMark_Ant != _bEsClienteConAccMark)
                bRet = true;

            //---- GSG (17/06/2014)
            if (!bRet && cBoxCampanyas.Items.Count == 1)
                bRet = true;

            return bRet;
        }

        private bool GetAccMarkConCampanyaCli(int cliente)
        {
            bool bRet = false;

            this.dsAccionesMarketing1.ListaMAccMarkCampSolsCods.Rows.Clear();

            this.sqldaListaAccMarkCampByCli.SelectCommand.Parameters["@iIdCliente"].Value = cliente;
            this.sqldaListaAccMarkCampByCli.Fill(this.dsAccionesMarketing1);

            if (this.dsAccionesMarketing1.ListaMAccMarkCampSolsCods.Rows.Count > 0)
                bRet = true;

            return bRet;
        }

        */



        /*
        private void LlenarComboCampanyas(int tipo, string[] campanyas)
        {
            dsFormularios1.ListaCampanyas.Clear();

            for (int i = 0; i < campanyas.Length; i++)
            {
                sqldaListaCampanyas.SelectCommand.Parameters["@iTipo"].Value = tipo;
                sqldaListaCampanyas.SelectCommand.Parameters["@idCampanya"].Value = campanyas[i];

                //---- GSG (19/11/2013)
                sqldaListaCampanyas.SelectCommand.Parameters["@tipoCampanya"].Value = K_LIN;
                sqldaListaCampanyas.SelectCommand.Parameters["@sIdDelegado"].Value = Clases.Configuracion.iIdDelegado.ToString(); 
                sqldaListaCampanyas.SelectCommand.Parameters["@sIdTipoPedido"].Value = _sTipoPedido;
                //---- FI GSG

                sqldaListaCampanyas.Fill(dsFormularios1.ListaCampanyas);

                //cambio el tipo para que no rpite las campanyas extras
                tipo = 3;

            }

            dsFormularios1.ListaCampanyas.DefaultView.RowFilter = "bSeleccionable = 1";
            dsFormularios1.ListaCampanyas.DefaultView.Sort = "NombreCampanya"; //---- GSG (14/07/2014)
            cBoxCampanyas.DataSource = dsFormularios1.ListaCampanyas.DefaultView;


        }


        private bool EsClienteConAccMark(int cliente)
        {
            bool bRet = false;

            this.dsClientes1.ListaAccionesMarkClientes.Rows.Clear();
            this.sqldaListaAccionesMarkCli.SelectCommand.Parameters["@iIdCliente"].Value = cliente;
            this.sqldaListaAccionesMarkCli.Fill(this.dsClientes1);

            if (this.dsClientes1.ListaAccionesMarkClientes.Rows.Count > 0)
                bRet = true;

            return bRet;
        }


        private string EsAccMarkConCampanya(string accmark)
        {
            string codCampanya = "";

            this.dsAccionesMarketing1.ListaMAccMarkCamp.Rows.Clear();

            sqldaListaAccMarkCamp.SelectCommand.Parameters["@sIdAccion"].Value = accmark;
            sqldaListaAccMarkCamp.SelectCommand.Parameters["@sDescAccion"].Value = "-1";
            sqldaListaAccMarkCamp.SelectCommand.Parameters["@IdCampanya"].Value = "-1";
            sqldaListaAccMarkCamp.SelectCommand.Parameters["@NombreCampanya"].Value = "-1";
            sqldaListaAccMarkCamp.SelectCommand.Parameters["@iEstado"].Value = 0;

            this.sqldaListaAccMarkCamp.Fill(this.dsAccionesMarketing1.ListaMAccMarkCamp);

            if (this.dsAccionesMarketing1.ListaMAccMarkCamp.Rows.Count > 0)
            {
                GESTCRM.Formularios.DataSets.dsAccionesMarketing.ListaMAccMarkCampRow row = (GESTCRM.Formularios.DataSets.dsAccionesMarketing.ListaMAccMarkCampRow)dsAccionesMarketing1.ListaMAccMarkCamp.Rows[0];
                codCampanya = row.idCampanya;
            }

            return codCampanya;
        }


        private void LlenarComboCampanyas(int tipo, string campanya)
        {
            dsFormularios1.ListaCampanyas.Clear();

            sqldaListaCampanyas.SelectCommand.Parameters["@iTipo"].Value = tipo;
            sqldaListaCampanyas.SelectCommand.Parameters["@idCampanya"].Value = campanya;

            //---- GSG (19/11/2013)
            sqldaListaCampanyas.SelectCommand.Parameters["@tipoCampanya"].Value = K_LIN;
            sqldaListaCampanyas.SelectCommand.Parameters["@sIdDelegado"].Value = Clases.Configuracion.iIdDelegado.ToString();
            sqldaListaCampanyas.SelectCommand.Parameters["@sIdTipoPedido"].Value = _sTipoPedido;
            //---- GSG (16/06/2014)
            sqldaListaCampanyas.SelectCommand.Parameters["@idCampanyaCab"].Value = sIdCampCab;

            sqldaListaCampanyas.Fill(dsFormularios1.ListaCampanyas);
            dsFormularios1.ListaCampanyas.DefaultView.RowFilter = "bSeleccionable = 1";
            dsFormularios1.ListaCampanyas.DefaultView.Sort = "NombreCampanya"; //---- GSG (14/07/2014)
            cBoxCampanyas.DataSource = dsFormularios1.ListaCampanyas.DefaultView;
            
        }

        */

        private bool FormatBuscarCampanyas(int cliente, bool activo, string tipoPed, string mayorista)
        {
            bool bRet = false;
            bool bConCampanyas = true;

            bConCampanyas = LlenarComboCampanyas(Clases.Configuracion.iIdDelegado.ToString(), tipoPed, cliente, mayorista);

            if (bConCampanyas)
            {
                cBoxCampanyas.Enabled = activo;

                _sTipoSumaUnidades = cBoxCampanyas.SelectedValue.ToString();
            }
            else
            {
                cBoxCampanyas.Enabled = false;
            }

            return bRet;
        }

        private bool LlenarComboCampanyas(string sDelegado, string sTipoPed, int iCliente, string sMayorista)
        {
            bool bRet = true;

            dsFormularios1.ListaCampanyas.Clear();

            sqldaListaCampanyas.SelectCommand.Parameters["@sIdDelegado"].Value = sDelegado;
            sqldaListaCampanyas.SelectCommand.Parameters["@sIdTipoPedido"].Value = sTipoPed;
            sqldaListaCampanyas.SelectCommand.Parameters["@iIdCliente"].Value = iCliente;
            sqldaListaCampanyas.SelectCommand.Parameters["@sIdMayorista"].Value = sMayorista;

            sqldaListaCampanyas.Fill(dsFormularios1.ListaCampanyas);

            if (dsFormularios1.ListaCampanyas.Rows.Count > 0)
            {
                dsFormularios1.ListaCampanyas.DefaultView.Sort = "NombreCampanya";
                cBoxCampanyas.DataSource = dsFormularios1.ListaCampanyas.DefaultView;
                cBoxCampanyas.SelectedIndex = 0;
            }
            else
            {
                Mensajes.ShowExclamation("No hay campañas disponibles.");
                bRet = false;
            }

            return bRet;
        }


        //---- GSG (30/09/2013)
        private float GetRentMinCamp(string sIdCamp)
        {
            float ret = 0;
            SqlDataReader dr;

            try
            {

                if (sqlConn.State.ToString() == "Closed")
                    sqlConn.Open();

                sqlGetRentMinCamp.Parameters["@idCampanya"].Value = sIdCamp;
                dr = sqlGetRentMinCamp.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ret = float.Parse(dr[0].ToString());
                        break;
                    }
                }

                dr.Close();
            }
            catch (Exception e)
            {
                Mensajes.ShowError(e.ToString());
            }

            return ret;
        }

        //---- GSG (23/10/2013)
        bool ExisteCampInAccMarkCamp(string campanya)
        {
            bool bExiste = false;

            try
            {
                if (sqlConn.State.ToString() == "Closed")
                    sqlConn.Open();

                sqlcmdExisteCampInAccMarkCamp.Parameters["@idCampanya"].Value = campanya;
                if ((int)sqlcmdExisteCampInAccMarkCamp.ExecuteScalar() > 0)
                    bExiste = true;
            }
            catch (Exception Ex)
            {
                Mensajes.ShowError("Error en ExisteCampInAccMarkCamp: " + Ex.ToString());
            }

            return bExiste;
        }


        // Un mayorista es ZMAY si pertenece a un club que está en la tabla DirectoZMAY
        // En la generación del fichero SAP influye en que el descuento que iría a desc2 lo ponemos en desc3
        private bool EsDirectoZMAY(int piIdCliente)
        {
            bool bRet = false;
            DataTable dtClubsMayoristaDirectoZMAY;
            DataTable dtClubsDirectoZMAY;

            try
            {
                if (sqlConn.State.ToString() == "Closed")
                    sqlConn.Open();
               

                dtClubsMayoristaDirectoZMAY = new DataTable();

                using (SqlCommand cmdClubs = new SqlCommand("ListaClubsMayorista", sqlConn))
                {
                    cmdClubs.CommandType = CommandType.StoredProcedure;

                    cmdClubs.Parameters.Add("@iIdMayorista", System.Data.SqlDbType.Int, 4);
                    cmdClubs.Parameters["@iIdMayorista"].Value = piIdCliente;

                    using (SqlDataAdapter daClubs = new SqlDataAdapter(cmdClubs))
                    {
                        daClubs.Fill(dtClubsMayoristaDirectoZMAY);
                    }
                }


                if (dtClubsMayoristaDirectoZMAY.Rows.Count > 0)
                {
                    DataRow drClubs = dtClubsMayoristaDirectoZMAY.NewRow();
                    drClubs = dtClubsMayoristaDirectoZMAY.Rows[0];

                    dtClubsDirectoZMAY = new DataTable();

                    for (int i = 0; i < 5; i++) //Un majorista pot tenir fins a 5 garanties (clubs)
                    {
                        //cal mirar si algun dels que té està a la taula DirectoZMAY
                        using (SqlCommand cmdClubsDirectoZMAY = new SqlCommand("ListaClubsDirectoZMAY", sqlConn))
                        {
                            if (drClubs[i].ToString().Trim() != "")
                            {
                                cmdClubsDirectoZMAY.CommandType = CommandType.StoredProcedure;

                                cmdClubsDirectoZMAY.Parameters.Add("@sGarantia", System.Data.SqlDbType.VarChar, 4);
                                cmdClubsDirectoZMAY.Parameters["@sGarantia"].Value = drClubs[i].ToString();

                                dtClubsDirectoZMAY.Clear();

                                using (SqlDataAdapter daClubsDirectoZMAY = new SqlDataAdapter(cmdClubsDirectoZMAY))
                                {
                                    daClubsDirectoZMAY.Fill(dtClubsDirectoZMAY);
                                    if (dtClubsDirectoZMAY.Rows.Count > 0)
                                    {
                                        bRet = true;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                string err = e.Message;
            }

            return bRet;
        }


        //---- GSG (13/11/2013)
        private bool GetListaUltimosAvisos()
        {
            bool bRet = false;

            dsMateriales1.ListaUltimosAvisos.Rows.Clear();

            sqldaListaUltimosAvisos.SelectCommand.Parameters["@sIdProducto"].Value = "-1";
            sqldaListaUltimosAvisos.SelectCommand.Parameters["@sDescripcion"].Value = null;
            sqldaListaUltimosAvisos.SelectCommand.Parameters["@sIdMaterial"].Value = "-1";
            sqldaListaUltimosAvisos.SelectCommand.Parameters["@sMaterial"].Value = null;

            sqldaListaUltimosAvisos.Fill(this.dsMateriales1);

            if (dsMateriales1.ListaUltimosAvisos.Rows.Count > 0)
                bRet = true;

            return bRet;
        }


        //---- GSG (22/01/2014)
        private void btQtyAdquiridas_Click(object sender, EventArgs e)
        {
            //showGraphQty();
            string sCodNacional = dataGridView1[K_COL_CODNACIONAL, dataGridView1.CurrentRow.Index].Value.ToString();
            string sMaterial = dataGridView1[K_COL_NOMMAT, dataGridView1.CurrentRow.Index].Value.ToString();
            Comun.showGraphQty(_iIdCliente, sCodNacional, sMaterial);
        }


        private void btDescsAplicados_Click(object sender, EventArgs e)
        {
            //showGraphDesc();
            string sCodNacional = dataGridView1[K_COL_CODNACIONAL, dataGridView1.CurrentRow.Index].Value.ToString();
            string sMaterial = dataGridView1[K_COL_NOMMAT, dataGridView1.CurrentRow.Index].Value.ToString();
            double fDescMaxCamp = double.Parse(dataGridView1[K_COL_DESCMAXCAMP, dataGridView1.CurrentRow.Index].Value.ToString());
            Comun.showGraphDesc(_iIdCliente, sCodNacional, sMaterial, fDescMaxCamp);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //---- GSG CECL 19/05/2016
            if (System.Configuration.ConfigurationManager.AppSettings["TipoDelegadoPedidosCentral"].ToString() != Comun.K_CECL)
            {

                DataGridViewCell cell = dataGridView1.CurrentCell;

                string sCodNacional = dataGridView1[K_COL_CODNACIONAL, dataGridView1.CurrentRow.Index].Value.ToString();
                string sMaterial = dataGridView1[K_COL_NOMMAT, dataGridView1.CurrentRow.Index].Value.ToString();

                if (e.ColumnIndex == dataGridView1.Columns["iCantidad"].Index)
                {
                    Comun.showGraphQty(_iIdCliente, sCodNacional, sMaterial);

                }
                else if (e.ColumnIndex == dataGridView1.Columns["fDescuento"].Index)
                {
                    //Damos por bueno que el descuento máximo es el de la campaña que estamos utilizando aunque sabemos que este material puede 
                    //estar en otra campaña con descuento distinto
                    double fDescMaxCamp = double.Parse(dataGridView1[K_COL_DESCMAXCAMP, dataGridView1.CurrentRow.Index].Value.ToString());

                    Comun.showGraphDesc(_iIdCliente, sCodNacional, sMaterial, fDescMaxCamp);
                }
            }
        }


        private void txbsDescripcion_TextChanged(object sender, EventArgs e)
        {
            _bEditTxtDesc = true;

            if (txbsDescripcion.Text == "")
                _bEditTxtDesc = false; 

            int pos = GetRowIndex(txbsDescripcion.Text);

            if (pos > -1)
                dataGridView1.FirstDisplayedScrollingRowIndex = pos;
        }


        private int GetRowIndex(string SearchValue)
        {
            int rowIndex = -1;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["sMaterial"].Value.ToString().ToUpper().StartsWith(SearchValue.ToUpper()))
                {
                    rowIndex = row.Index;
                    break;
                }
            }

            return rowIndex;
        }

        private int ObtenirMaterialsSolsClub(int piIdCliente)
        {
            string mat = "";
            int comptador = 0;
            SqlDataReader dr;

            try
            {
                if (sqlConn.State.ToString() == "Closed")
                    sqlConn.Open();

                _lMatsSoloClub = new string[500];

                sqlCmdGetMatsSoloClub.Parameters["@iIdCliente"].Value = piIdCliente;
                dr = sqlCmdGetMatsSoloClub.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        mat = dr["sIdMaterial"].ToString().Trim();
                        _lMatsSoloClub[comptador] = mat;
                        comptador++;
                    }
                }

                dr.Close();
            }
            catch (Exception e)
            {
                Mensajes.ShowError(e.ToString());
            }

            return comptador;
        }


        private void updateColorsSoloClub()
        {
            if (_lMatsSoloClub != null && _lMatsSoloClub[0] != null) //---- GSG (02/02/2021) per estalviar temps si no hi ha cap material
            {

                int index = 0;

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (Comun.IsInTheArray(row.Cells["sIdMaterial"].Value.ToString(), _lMatsSoloClub))
                    {
                        //Cal pintar
                        dataGridView1.Rows[index].Cells["sIdMaterial"].Style.BackColor = MatsSoloClubColor;
                    }

                    index++;
                }
            }
        }


        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {           
            bool bLetraODigito = char.IsLetterOrDigit((char) e.KeyChar);

            if (bLetraODigito && !_bEditTxtDesc)
            {
                int pos = GetRowIndex(e.KeyChar.ToString());

                if (pos > -1)
                    dataGridView1.FirstDisplayedScrollingRowIndex = pos;
            }


            //e.KeyChar == (char)8  // <--
            //e.KeyChar == (char)32 // Espacio
            //e.KeyChar == (char)27 //esc
            //e.KeyChar == (char)13 //intro

        }


        //---- GSG (15/07/2014)
        private int GetPaquete(string sIdMaterial, string sIdCamp)
        {
            int ret = -1;
            SqlDataReader dr;

            try
            {
                if (sqlConn.State.ToString() == "Closed")
                    sqlConn.Open();

                sqlGetPaquete.Parameters["@iIdMaterial"].Value = sIdMaterial;
                sqlGetPaquete.Parameters["@iIdCamp"].Value = sIdCamp;

                dr = sqlGetPaquete.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ret = int.Parse(dr[0].ToString());
                        break;
                    }
                }

                dr.Close();
            }
            catch (Exception e)
            {
                Mensajes.ShowError(e.ToString());
            }

            return ret;
        }

        //---- GSG (17/11/2014)
        private string GetTipoSumaUnidadesCampanya(string sIdMat, string sIdCamp)
        {
            string ret = "0";
            SqlDataReader dr;

            try
            {
                if (sqlConn.State.ToString() == "Closed")
                    sqlConn.Open();

                sqlGetSumaUnidades.Parameters["@iIdMaterial"].Value = sIdMat;
                sqlGetSumaUnidades.Parameters["@iIdCamp"].Value = sIdCamp;

                dr = sqlGetSumaUnidades.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ret = dr[0].ToString();
                        break;
                    }
                }

                dr.Close();

            }
            catch (Exception err)
            {
                Mensajes.ShowError(err.ToString());
            }

            return ret;
        }


        //---- GSG (29/03/2022)
        private string GetTipoPedidoSumaUnidadesCampanya(string sIdMat, string sIdCamp)
        {
            string ret = "XXXX";
            SqlDataReader dr;

            try
            {
                if (sqlConn.State.ToString() == "Closed")
                    sqlConn.Open();

                sqlGetTipoPedidoSumaUnidades.Parameters["@iIdMaterial"].Value = sIdMat;
                sqlGetTipoPedidoSumaUnidades.Parameters["@iIdCamp"].Value = sIdCamp;

                dr = sqlGetTipoPedidoSumaUnidades.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ret = dr[0].ToString();
                        break;
                    }
                }

                dr.Close();

            }
            catch (Exception err)
            {
                Mensajes.ShowError(err.ToString());
            }

            return ret;
        }


        //---- GSG (25/11/2014)
        private bool EsDelegadoCanarias(int iIdDelegado)
        {
            bool ret = false;
            SqlDataReader dr;

            try
            {
                if (sqlConn.State.ToString() == "Closed")
                    sqlConn.Open();

                sqlEsDelegadoCanarias.Parameters["@iIdDelegado"].Value = iIdDelegado;

                dr = sqlEsDelegadoCanarias.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ret = bool.Parse(dr[0].ToString());
                        break;
                    }
                }

                dr.Close();

            }
            catch (Exception err)
            {
                Mensajes.ShowError(err.ToString());
            }

            return ret;
        }

        //---- GSG (19/10/2015)
        private int GetTarjetasClienteActivas(int piIdCliente)
        {
            int iRet = 0;

            this.dsClientes1.ListaTarjetasClienteActivas.Rows.Clear();

            if (sqlConn.State == ConnectionState.Closed)
                this.sqlConn.Open();

            SqlTransaction sqlTran = this.sqlConn.BeginTransaction();
            this.sqlCmdListaTarjetasClienteActivas.Transaction = sqlTran;

            try
            {
                this.sqlCmdListaTarjetasClienteActivas.Parameters["@iIdCliente"].Value = piIdCliente;
                this.sqldaListaTarjetasClienteActivas.Fill(this.dsClientes1);

                iRet = dsClientes1.ListaTarjetasClienteActivas.Rows.Count;
            }
            catch (Exception e)
            {
                Mensajes.ShowError(e.Message);
            }

            this.sqlConn.Close();

            return iRet;
        }



        //---- GSG (12/07/2018)
        private double IsDescMinGarInformed(string sIdCampanya)
        {
            double ret = 0;

            this.dsFormularios1.GetDescMinGar.Clear();
            this.sqlCmdGetIsDescuentoMinGarInformed.Parameters["@idCampanya"].Value = sIdCampanya;

            using (SqlDataAdapter oDa = new SqlDataAdapter(sqlCmdGetIsDescuentoMinGarInformed))
            {
                oDa.Fill(dsFormularios1.GetDescMinGar);
            }

            if (dsFormularios1.GetDescMinGar != null)
            {
                ret = double.Parse(dsFormularios1.GetDescMinGar.Rows[0]["fDescMinGar"].ToString());
            }

            return ret;
        }

        //---- GSG (29/09/2020) PUNTOS
        private void txtMargen_DoubleClick(object sender, EventArgs e)
        {
            string mensaje = "Alta Rotación + Alta Rentabilidad No Comprados Este Año\r\nPedido Delegado\r\n-------------------------------------------------------------------------\r\n\r\n" + _sMatsARARnoCli;



            if (Mensajes.ShowInformation(mensaje, true) == DialogResult.OK)
            {
                mensaje = "Media Rotación + Alta Rentabilidad No Comprados Este Año\r\nPedido Delegado + Clubs\r\n-------------------------------------------------------------------------\r\n\r\n" + _sMatsMRARnoCli;
                Mensajes.ShowInformation(mensaje, true);
            }
        }


        //---- GSG (02/01/2023)
        private void comprobaCompromisoMinimos()
        { 
            bool bCanvi = false;
            
            if (_iMinimos == 1)
            {
                //Actualizar las cantidades a 1
                foreach (DataGridViewRow dr in dataGridView1.Rows)
                {
                    if ((bool)dr.Cells["selected"].Value == true && int.Parse(dr.Cells["iCantidad"].Value.ToString()) != 1)
                    {
                        dr.Cells["iCantidad"].Value = 1;
                        if (!bCanvi) bCanvi = true;
                    }
                }

                if (bCanvi)
                    Mensajes.ShowInformation(String.Format("En un pedido compromiso de mínimos todas las referencias seleccionadas deben llevar 1 unidad.\r\nSe ha modificado la cantidad en algunas líneas que no cumplían este requisito"));
            }
        }


        //---- GSG (02/01/2023)
        private void cbSelTodo_CheckStateChanged(object sender, EventArgs e)
        {
            int qty = 0;

            if (cbSelTodo.Checked)
                qty = 1;

            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                dr.Cells["selected"].Value = cbSelTodo.Checked;
                dr.Cells["iCantidad"].Value = qty;                
            }

            ActualizarTotalesSeleccion();
        }
    }

}




