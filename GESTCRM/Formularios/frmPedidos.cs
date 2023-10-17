using System;
using System.Text;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using GESTCRM.Clases;

using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.IO.Image;

using System.Linq;




namespace GESTCRM.Formularios
{

    public class frmPedidos : System.Windows.Forms.Form
    {
        #region declaraciones

        #region constantes

        private const int DELEGADO = 1;
        private const string K_CAB = "CAB";
        private const string K_LIN = "LIN";
        private const string K_TODOS = "XXXX";
        private const string K_ZMKT = "ZMKT";

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
        const int K_COL_CAJACOMPLETA = 28;
        const int K_COL_UNIDENFAJADO = 29;

        #endregion

        #region variables

        private int iIdCliente;
        private int iIdDestinatario;
        private GESTCRM.Clases.Pedido oPedido;
        private bool _bEncuesta = false;//---- GSG (03/07/2019)
        private bool _bErrorMostrat = false; //---- GSG (22/08/2019)

        enum acceso : byte { INSERCION = 1, MODIFICACION = 2, CONSULTA = 3 }

        private int TipoAcceso;
        private bool deleg;
        private bool mensaje_al_salir = false; //a true cuando haya alguna modificación
        private int iIdDelegado;
        private string sIdPedido;
        private string v_sIdCampanya = null;

        private dsMateriales.ListaLineasPedidoDataTable dtLineasPedido;
        private dsMateriales.ListaLineasPedidoRentAnualDataTable dtLineasPedidoRentAnual;
        private dsMateriales.ListaAvisoMUVDataTable dtLineasAvisoMUV;
        private dsMateriales.ListaLineasPedidoRentAnualArrastreDataTable dtLineasPedidoRentAnualArrastre;
        private dsFormularios.ListaCampanyasCabeceraDataTable dtCampanyasCabeceraCompletas;
        private System.Data.SqlClient.SqlCommand sqlCmdSetContactosClientesSAP;

        private frmProcesando frmP = null;

        private bool SetDefault = false;
        private string DefaultValue = "0";
        private Color DefaultValueColor = Color.FromArgb(128, 255, 128);
        private static string obligatorioSi = "Sí"; //Equivale a True        

        private double ImporteMinPedido = 0.0;
        private double ImportePedido = 0.0;
        private double ImportePedidoBruto = 0.0;
        private bool bEsBrut = false;
        private int iMinimUnitatsPedido = 0;
        private int iUnitatsPedido = 0;

        private double DescuentoMedio = 0.0;
        private double DtoGeneral = 0.0;

        private Font BoldFont = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
        private Font RegularFont = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));

        private int NewIdGrupoMat = 0;
        private int NewIdLinea = 0;

        private Keys PressedKey = Keys.None; //Se utiliza para controlar la salida de numericUpDownA

        List<ArrayList> _taulaTotalsProd = new List<ArrayList>();
        private string _sDataVencCanviada = "";
        private bool _bDataVencCanviada = false;
        private bool _bEsCeldaMG = false;
        private double _fDescMGInicial = 0;
        private List<QtyMat> _tMatQtyOriginal = new List<QtyMat>();
        private int _iClientOriginal = -1;
        private bool _bEsDirectoZMAY = false;
        //---- GSG (02/02/2021)
        //private string _iEmailConfOriginal = "";
        //private string _iEmailFactOriginal = "";
        private bool _bEsCopia = false;
        private bool _bEsFlexible = false;
        private string _sTipoPedido = "";
        private string _sTipoPedidoOld = "";
        private string _sTipoPedidoNew = "";
        private int _iTipoCampanyaOld = -1;
        private bool _bVerCondPago = false;
        private DateTime _dFecFact = DateTime.Parse("31/12/9998");
        private string _sCodPagoFija = "";
        private DateTime _dFecFactPedidoCargado = DateTime.Parse("31/12/9998");
        private string _sNIF = "";
        private string _sCC = "";
        private string _sSWIFT = "";
        private System.Data.SqlClient.SqlCommand sqlCmdGetRegionClienteSAP;
        private System.Data.SqlClient.SqlDataAdapter sqldaRegion;
        private static string _sTipoSumaUnidades = "0";
        private string _sTipoPedidoSumaUnidades = "XXXX"; //---- GSG (29/03/2022)
        private static string _sCondPago = "";
        private ExportToExcel oExportExcel;
        private bool _bGuardandoPedido = false;
        private List<RegaloEspecial> _lRegaloEspecial = new List<RegaloEspecial>();
        private List<string> _lTarjetasClientePedidoOriginal = new List<string>();
        private List<KeyValuePair<string, string>> _lPairsMatCampEnPed = new List<KeyValuePair<string, string>>();
        //---- GSG (13/09/2016)
        private List<ValuesProd> _tValuesProdEnPed = new List<ValuesProd>();
        private List<ParejasExclusion> _listaExclusion = new List<ParejasExclusion>();
        //---- GSG (06/03/2021)
        // Se llama ProfitPlus la lista, porque la usa para hacer cálculos y simular como afectan las acciones de mkt a los puntos del pedido 
        private List<string> _listaAccMarkProfitPlus = new List<string>();

        //---- GSG (13/03/2019)
        private string _importeAnteriorMKT = "";
        private bool _recuperaAccMarkPedido = true;

        //---- GSG (02/01/2023)
        private bool _bClickMinimos = false;
        private int _iMinimos = 0;

        //---- GSG (03/03/2017)
        private System.Data.SqlClient.SqlCommand sqlCmdGetCPClienteSAP;
        private System.Data.SqlClient.SqlDataAdapter sqldaCP;

        private System.Windows.Forms.TextBox txbDelegado;
        private System.Windows.Forms.Panel pnlCabeceraPedido;
        private System.Data.SqlClient.SqlDataAdapter sqldaListaLineasPedido;
        private System.Data.SqlClient.SqlDataAdapter sqldaListaLineasPedidoRentAnual;
        private System.Data.SqlClient.SqlCommand sqlSelectLineasPedidoRentAnual;
        private System.Data.SqlClient.SqlDataAdapter sqldaListaLineasPedidoRentAnualArrastre;
        private System.Data.SqlClient.SqlCommand sqlSelectLineasPedidoRentAnualArrastre;
        private System.Data.SqlClient.SqlDataAdapter sqldaProgInf;
        private System.Data.SqlClient.SqlCommand sqlCmdProgInf;
        private System.Data.SqlClient.SqlConnection sqlConn;
        private System.Data.SqlClient.SqlCommand sqlCmdSetPedidosCab;
        private System.Data.SqlClient.SqlCommand sqlCmdSetPedAcciones;
        private System.Data.SqlClient.SqlCommand sqlCmdGetPedAcciones;
        private GESTCRM.Formularios.DataSets.dsClientes dsClientes1;
        private System.Data.SqlClient.SqlDataAdapter sqldaListaClubsAviso;
        private System.Data.SqlClient.SqlCommand sqlSelectListaClubsAviso;
        private System.Data.SqlClient.SqlCommand sqlCmdGetValorsProdCamp;
        private System.Data.SqlClient.SqlDataAdapter sqldaListaTiposPedidoSAP;
        private System.Data.SqlClient.SqlCommand sqlSelectCommand3;
        private System.Data.SqlClient.SqlDataAdapter sqldaListaCondPago;
        private System.Data.SqlClient.SqlCommand sqlCmdCondPago;
        private System.Data.SqlClient.SqlDataAdapter sqldaListaPrioridad;
        private System.Data.SqlClient.SqlCommand sqlCmdPrioridad;
        private System.Data.SqlClient.SqlDataAdapter sqldaListaTiposPosPedidoSAP;
        private System.Data.SqlClient.SqlCommand sqlCmdGetClientesSAP;
        private System.Data.SqlClient.SqlCommand sqlSelectCommand2;
        private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
        private System.Data.SqlClient.SqlCommand sqlCmdGetCampanyasPedido;
        private System.Data.SqlClient.SqlCommand sqlCmdGetIsCampanyaMultiple;
        private System.Data.SqlClient.SqlCommand sqlCmdSetCampanyaPedido;
        private System.Data.SqlClient.SqlCommand sqlCmdDeleteCampanyasPedido;
        private System.Data.SqlClient.SqlCommand sqlCmdGetIsDescuentoMaxInformed;
        private System.Data.SqlClient.SqlDataAdapter sqlDaListaMateriales;
        private System.Data.SqlClient.SqlCommand sqlCommand2;
        private System.Data.SqlClient.SqlCommand sqlCmdGetIsDescuentoMinGarInformed;
        private GESTCRM.Formularios.DataSets.dsPedidos dsPedidos1;
        private System.Data.SqlClient.SqlCommand sqlCmdGetRentabilidadDescripcion;
        private System.Data.SqlClient.SqlCommand sqlCmdGetRentabilidadColor;
        private System.Data.SqlClient.SqlCommand sqlCmdGetMaterialesNoRentabilidad;
        private System.Data.SqlClient.SqlCommand sqlCmdGetDescuentoMayoristaClub;
        private System.Data.SqlClient.SqlCommand sqlCmdGetFechaVencimiento;
        private System.Data.SqlClient.SqlCommand sqlCmdSetCondicionesComercialesTemp;
        private System.Data.SqlClient.SqlCommand sqlCmdDelCondicionesComercialesTemp;
        private SqlCommand sqlCmdGrupoVencimientoMaterial;
        private System.Data.SqlClient.SqlCommand sqlCmdGetCampanyasNoRentabilidad;
        private System.Data.SqlClient.SqlDataAdapter sqldaListaAccionesMarkCli;
        private System.Data.SqlClient.SqlCommand sqlSelectCommandListaAccionesMarkCli;
        private System.Data.SqlClient.SqlCommand sqlGetNumAcckMarkADescartar;
        private System.Data.SqlClient.SqlCommand sqlGetRentMinCampCab;
        private System.Data.SqlClient.SqlCommand sqlGetRentMinCamp;
        private System.Data.SqlClient.SqlDataAdapter sqldaListaAccMarkCamp;
        private System.Data.SqlClient.SqlCommand sqlCmdListaAccMarkCamp;
        private System.Data.SqlClient.SqlCommand sqlCmdListaCampanyas;
        private System.Data.SqlClient.SqlCommand sqlCmdListaCampanyasNEW;
        private System.Data.SqlClient.SqlCommand sqlCmdListaCampanyasPedInactivo;
        private System.Data.SqlClient.SqlCommand sqlCmdListaCampanyasPedInactivoNEW;
        private System.Data.SqlClient.SqlDataAdapter sqldaListaAccMarkCampByCli;
        private System.Data.SqlClient.SqlCommand sqlCmdListaAccMarkCampByCli;
        private System.Data.SqlClient.SqlCommand sqlGetCondPagoCampCab;
        private System.Data.SqlClient.SqlCommand sqlGetFecFact;
        private System.Data.SqlClient.SqlCommand sqlGetCondPagoFijaCampCab;
        private System.Data.SqlClient.SqlDataAdapter sqldaGetMatsConVale;
        private System.Data.SqlClient.SqlCommand sqlCmdGetMatsConVale;
        private System.Data.SqlClient.SqlDataAdapter sqldaListaMatsConVale;
        private System.Data.SqlClient.SqlCommand sqlCmdListaMatsConVale;
        private System.Data.SqlClient.SqlCommand sqlCmdSetVale;
        private System.Data.SqlClient.SqlDataAdapter sqldaDescMax;
        private System.Data.SqlClient.SqlCommand sqlSelectListaDescMax;
        private bool _bEsClienteConAccMark = false;
        private System.Data.SqlClient.SqlDataAdapter sqldaListaAvisoMUV;
        private System.Data.SqlClient.SqlCommand sqlCmdListaAvisoMUV;
        protected System.Data.SqlClient.SqlDataAdapter sqldaListaMUV;
        protected System.Data.SqlClient.SqlCommand sqlCmdListaMUV;
        private System.Data.SqlClient.SqlCommand sqlcmdExisteCampInAccMarkCamp;
        private System.Data.SqlClient.SqlCommand sqlCmdSetUltimosAvisos;
        private System.Data.SqlClient.SqlCommand sqlCmdSetEmailsCliente;
        private System.Data.SqlClient.SqlDataAdapter sqldaListaEmailsCliente;
        private System.Data.SqlClient.SqlCommand sqlCmdListaEmailsCliente;
        private System.Data.SqlClient.SqlCommand sqlCmdSetRetenido;
        private System.Data.SqlClient.SqlCommand sqlGetRetenido;
        private System.Data.SqlClient.SqlDataAdapter sqldaListaProgInfCliente_SAP;
        private System.Data.SqlClient.SqlCommand sqlSelectCommandListaProgInfporCliente_SAP;
        private System.Data.SqlClient.SqlCommand sqlGetImporteMedioPedido;
        private System.Data.SqlClient.SqlCommand sqlCmdSetProgInfClientesSAP;
        private System.Data.SqlClient.SqlDataAdapter sqldaMatsEspeciales;
        private System.Data.SqlClient.SqlCommand sqlCmdMatsEspeciales;
        private System.Data.SqlClient.SqlDataAdapter sqldaListaTarjetasCliente;
        private System.Data.SqlClient.SqlCommand sqlCmdListaTarjetasCliente;
        private System.Data.SqlClient.SqlCommand sqlCmdSetUsoTarjetasCliente;
        private System.Data.SqlClient.SqlDataAdapter sqldaListaProductos;
        private System.Data.SqlClient.SqlCommand sqlCmdListaProductos;
        private SqlDataAdapter sqldaListaCampanyas;
        private SqlCommand sqlCommand3;
        private System.Data.SqlClient.SqlCommand sqlCmdListaContactosClientes_SAP;
        private System.Data.SqlClient.SqlCommand sqlGetSumaUnidades;
        private System.Data.SqlClient.SqlDataAdapter sqldaListaMaterialesBloqueados;
        private System.Data.SqlClient.SqlCommand sqlCmdListaMaterialesBloqueados;
        private System.Data.SqlClient.SqlDataAdapter sqldaAccMarkExcluidas;
        private System.Data.SqlClient.SqlCommand sqlCmdAccMarkExcluidas;
        private SqlCommand sqlCmdMaxAccMark; //---- GSG (13/09/2016)
        //---- GSG (10/10/2016)
        private System.Data.SqlClient.SqlDataAdapter sqldaCampsDup;
        private SqlCommand sqlCmdCampsDup;
        //---- GSG (14/10/2016)
        private System.Data.SqlClient.SqlDataAdapter sqldaListaTiposPedidoCompromiso;
        private System.Data.SqlClient.SqlCommand sqlCmdListaTiposPedidoCompromiso;
        private System.Data.SqlClient.SqlDataAdapter sqldaListaTiposGestionCompromiso;
        private System.Data.SqlClient.SqlCommand sqlCmdListaTiposGestionCompromiso;
        //---- GSG (17/10/2016)
        private System.Data.SqlClient.SqlCommand sqlCmdListaMatsZMKT;
        private System.Data.SqlClient.SqlDataAdapter sqldaListaMatsZMKT;
        //---- GSG (13/03/2019)
        private System.Data.SqlClient.SqlDataAdapter sqldaListaAccionesAbiertasClientee;
        private System.Data.SqlClient.SqlCommand sqlCmdListaAccionesAbiertasCliente;
        //---- GSG (06/03/2021)
        private System.Data.SqlClient.SqlDataAdapter sqldaCodsAccMark;
        private System.Data.SqlClient.SqlCommand sqlCmdListaCodsAccMark;
        //---- GSG (29/03/2022)
        private System.Data.SqlClient.SqlCommand sqlGetTipoPedidoSumaUnidades;


        private string[] lMatsNoRenta;
        float gfRenta = 0;
        private int idGrupMatSelected = -1;
        const int K_MAX_GARANTIES = 5;
        private string[] garanties = new string[K_MAX_GARANTIES];
        private static string[] _lCampanyasNoRenta;
        private static string[] _lMatsNoRenta;
        List<string> _lMatsConVale = new List<string>();
        List<string> _lMatsConValePedido = new List<string>();
        DateTime _initialSelectedDateVigencia = DateTime.Today;

        //----GSG (29/09/2020) PUNTOS
        private static string[] lMatsNoMargen;
        private System.Data.SqlClient.SqlCommand sqlCmdGetMaterialesNoMargen;
        #endregion

        #region Controles

        private System.Windows.Forms.Label lblDelegado;
        private System.Windows.Forms.Label lblTipoPedido;
        private System.Windows.Forms.Label lblFechaPref;
        private System.Windows.Forms.Label lblFechaFijada;
        private System.Windows.Forms.Label lblObservaciones;
        private System.Windows.Forms.TextBox txbObservaciones;
        private System.Windows.Forms.DateTimePicker dtpFechaPref;
        private System.Windows.Forms.DateTimePicker dtpFechaFij;
        private System.Windows.Forms.Label lblImporte;
        private System.Windows.Forms.Label lblImporteBruto;
        private System.Windows.Forms.ComboBox cboTipoPedido;
        private System.Windows.Forms.ToolTip toolTipPedidos;
        public Button btnBuscarMaterial;
        private System.ComponentModel.IContainer components;
        public System.Windows.Forms.ComboBox cBoxCampanyas;
        private System.Windows.Forms.DateTimePicker dtpFechaPedido;
        private System.Windows.Forms.Label lblFechaPedido;
        private System.Windows.Forms.Panel pnlLineaPedido;
        private System.Windows.Forms.Button btBuscarCliente;
        private System.Windows.Forms.TextBox txtsCliente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Label lblDestinatario;
        private System.Windows.Forms.Button btBuscarDestinatario;
        private System.Windows.Forms.Label lblPedido;
        private System.Data.SqlClient.SqlCommand sqlCmdCargaPedido;
        private System.Windows.Forms.TextBox txbImporte;
        private System.Windows.Forms.TextBox txbImporteBruto;
        private System.Windows.Forms.TextBox txbIdPedido;
        public System.Windows.Forms.TextBox txtDestinatarioSAP;
        private System.Windows.Forms.TextBox txtsDestinatario;
        public System.Windows.Forms.TextBox txtClienteSAP;
        private System.Windows.Forms.Label lblDescGen;
        private System.Windows.Forms.ContextMenu contextMenu1;
        private System.Windows.Forms.MenuItem menuEliminar;
        private System.Windows.Forms.MenuItem menuNuevo;
        private System.Data.DataView dvLineasPedido;
        private System.Data.DataView dvTipoPedido;
        private System.Windows.Forms.TextBox txbDtoGeneral;
        private System.Windows.Forms.TextBox txbDto;
        private System.Data.DataView dvTiposPosPedidoSAP;
        private GESTCRM.Controles.ucBotoneraSecundaria ucBotoneraSecundaria1;
        private GESTCRM.Controles.LabelGradient labelGradient6;
        private System.Windows.Forms.Label lblCounter;
        private GESTCRM.Controles.LabelGradient lblTitulo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCodPago;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtGarantias;
        private System.Windows.Forms.TextBox txtEncComercial;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txbRentabilidad;
        private Label label10;
        private ComboBox cboTipoCampana;
        private DataGridView dataGridViewLineas;
        private DataGridViewTextBoxColumn iIdLinea;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn NombreCampanya;
        private DataGridViewTextBoxColumn sObligatorio;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn ImporteLin;
        private DataGridViewTextBoxColumn fDescuentoMaximo;
        private DataGridViewTextBoxColumn fCoste;
        private DataGridViewTextBoxColumn UnidMinimas;
        private TextBox txtRentabilidad;
        private SqlCommand sqlCmdSetPedidosLin;
        private Panel pnlSeleccionMateriales;
        private dsMateriales dsMateriales1;
        private BindingSource dsMateriales1BindingSource;
        private dsFormularios dsFormularios1;
        private BindingSource listaCampanyasBindingSource;
        private NumericUpDown numericUpDownA;
        private Label label1;
        private GESTCRM.Controles.LabelGradient labelGradient1;
        private SqlDataAdapter sqldaListaCampCabecera;
        private GESTCRM.Controles.LabelGradient labelGradientAccMark;
        private DataGridView dataGridViewAccMark;
        private BindingSource listaAccionesMarketingBindingSource;
        private GESTCRM.Formularios.DataSets.dsAccionesMarketing dsAccionesMarketing1;
        private SqlDataAdapter sqlDataListaAccionesMarketing;
        private SqlCommand sqlCommand1;
        private SqlCommand sqlCommand1CECL; //---- GSG CECL 19/05/2016
        private Label lblNumReg;
        private SqlCommand sqlCommand4;
        private SqlCommand sqlCommand4CECL; //---- GSG CECL 19/05/2016
        private SqlCommand sqlCmdProductoMaterial;
        private SqlCommand sqlCmdTipoMat;
        private TextBox txtGarantias1;
        private Label label12;
        private Label label11;
        private Label label8;
        private Label label7;
        private TextBox txtGarantias4;
        private TextBox txtGarantias3;
        private TextBox txtGarantias2;
        private CheckBox chkVisita;
        private Label label13;
        private TextBox txbDescExtra;
        private TextBox txbDescExtraRestante;
        private Label label14;
        private Label label15;
        private DateTimePicker dtpFechaVenci;
        private TextBox txbDecil;
        private Label label16;
        private TextBox txtbRentAnual;
        private TextBox txtMailFact;
        private TextBox txtMailConf;
        private Label label17;
        private Label label18;
        private Panel panel3;
        private CheckBox chkRetenido;
        private TextBox txtProgInf;
        private Label label20;
        private Label lblAvisoVersion;
        private ComboBox cboCondicionPago;
        private Label lblCondPago;
        private ComboBox cboPrioridad;
        private Label label22;
        private DateTimePicker dtpFechaFacturacion;
        private Label lblFechaFacturacion;
        private Label label21;
        private Label label23;
        private Label label24;
        private TextBox txbControl;
        private TextBox txbOficina;
        private TextBox txbEntidad;
        private TextBox txbCC;
        private Button btActRent;
        private ComboBox cboProgInf;
        private TextBox txbIBAN;
        private TextBox txbCCAndorra;
        private TextBox txbSPais;
        private TextBox txbSOficina;
        private TextBox txbSLocalidad;
        private TextBox txbSBanco;
        private Label label27;
        private TextBox txbPVPIVA;
        private TextBox txbPVP;
        private Label lblPVPIVA;
        private Label lblPVP;
        private TextBox txbMargen;
        private Label lblMargen;
        private Button btExport;
        private TextBox txbDecilP;
        private Label label28;
        private TextBox txbCodPagoFija;
        private Label label31;
        private Label label32;
        private Label label34;
        private TextBox txbImporteNetoNF;
        private TextBox txbImporteNetoF;
        private Label label33;
        private Label label30;
        private Label label29;
        private TextBox txbImporteBrutoNF;
        private TextBox txbImporteBrutoF;
        private TextBox txbDtoMedioNF;
        private TextBox txbDtoMedioF;
        private Label label35;
        private Label label36;
        private TextBox txbDescFacturaNF;
        private TextBox txbDescFacturaF;
        private Label label38;
        private Label label39;
        private Label label40;
        private Label label37;
        private TextBox txbMargenNF;
        private Label label41;
        private Button btCompetencia;
        private TabControl tabPedido;
        private TabPage tabPageLineasPedido;
        private TabPage tabPageAccMark;
        private Label lblCodPagoFija;
        private Panel panel4;
        private Label label3;
        private TextBox txtbBrutoPedAM;
        private Label label42;
        private TextBox txtbDescMedioAM;
        private TextBox txtbRentabilidadAM;
        private Label label43;
        private TextBox txtbCosteTotalAM;
        private Label label44;
        private Label lblMissAM;
        private DataGridViewCheckBoxColumn selected;
        private DataGridViewTextBoxColumn iIdAccionDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn sIdAccionDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn sDescAccionDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn sIdTipoAccionDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn UnidadesAEntregar;
        private DataGridViewTextBoxColumn iUnidades;
        private DataGridViewTextBoxColumn fImpMin;
        private DataGridViewTextBoxColumn fImpMax;
        private DataGridViewTextBoxColumn fRentabilidad;
        private DataGridViewCheckBoxColumn bIndepe;
        private DataGridViewTextBoxColumn iActivoPara;
        private DataGridViewTextBoxColumn sIdProducto;
        private DataGridViewTextBoxColumn producto;
        private DataGridViewTextBoxColumn fCosteUnitarioDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn bSuma;
        private DataGridViewTextBoxColumn iNumElemEntregar;
        private DataGridViewTextBoxColumn fCosteTotalDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn iMaxAEntregar;
        private DataGridViewTextBoxColumn dFechaCreacionDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dFechaIniDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dFechaFinDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn sObservacionesDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn sIdTipoImputacionDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dFUMDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn iEstadoDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn bEnviadoPDADataGridViewCheckBoxColumn;
        private Panel pnCompromiso;
        private ComboBox cboIndividual;
        private ComboBox cboClasico;
        private Button btEncuestas;
        private Button button1;
        private TextBox txbMargenLab;
        private Label label25;
        private GroupBox groupBox1;
        private TextBox txtImpMedio;
        private Label label19;
        private TextBox txtMediaPuntos;
        private Label label46;
        private TextBox txtImpMedioNeto;
        private Label label45;
        private Button btGrafPuntos;
        private Label label26;
        private TextBox txtbPuntosPedAM;
        private TextBox txtbPuntosPedConAM;
        private Label label47;
        private Label label48;
        private TextBox txbDtoExcluidos;
        private TextBox txbDtoCuentan;
        private Label label49;
        private DataGridViewTextBoxColumn ColiIdLinea;
        private DataGridViewTextBoxColumn sCodNacional;
        private DataGridViewTextBoxColumn sIdMaterialDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn ColProducto;
        private DataGridViewTextBoxColumn ColCampanya;
        private DataGridViewTextBoxColumn ColObligatorio;
        private DataGridViewTextBoxColumn ColCantidad;
        private DataGridViewTextBoxColumn ColPrecioBruto;
        private DataGridViewTextBoxColumn ColPrecio;
        private DataGridViewTextBoxColumn ColDescuento;
        private DataGridViewTextBoxColumn ColImporteLin;
        private DataGridViewTextBoxColumn ColDescuentoMaximo;
        private DataGridViewTextBoxColumn fRentabilidadDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn fCosteDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn ColidCampanya;
        private DataGridViewTextBoxColumn ColidArrastre;
        private DataGridViewTextBoxColumn ColUnidMinimas;
        private DataGridViewTextBoxColumn ColIdGrupoMat;
        private DataGridViewTextBoxColumn ordre;
        private DataGridViewTextBoxColumn ColfDescExtra;
        private DataGridViewTextBoxColumn ColfDescMat;
        private DataGridViewCheckBoxColumn ColbDescExtra;
        private DataGridViewTextBoxColumn sCodVale;
        private DataGridViewTextBoxColumn sSerie;
        private DataGridViewCheckBoxColumn bFinanciado;
        private DataGridViewCheckBoxColumn bMedicamento;
        private DataGridViewTextBoxColumn ColCajaCompleta;
        private DataGridViewTextBoxColumn ColUnidadesEnfajado;
        private DataGridViewTextBoxColumn ColfDescuentoMaximoTRA;
        private DataGridViewTextBoxColumn ColfPVP;
        private DataGridViewTextBoxColumn ColfPVPIVA;
        private DataGridViewTextBoxColumn ColiStockCanarias;
        private DataGridViewTextBoxColumn ColfDescuentoMaximoDIR;
        private DataGridViewImageColumn ColBorrar;
        private DataGridViewTextBoxColumn ColCantidadBase;
        private DataGridViewTextBoxColumn ColTipoMat;
        private DataGridViewTextBoxColumn iBloc;
        private DataGridViewTextBoxColumn iUnidadesDataGridViewTextBoxColumn;



        #endregion

        public string IdPedido
        {
            get
            {
                return sIdPedido;
            }
        }

        #endregion

        #region construtores

        public frmPedidos()
        {
            // PEDIDO NUEVO //

            try
            {

                TipoAcceso = (int)acceso.INSERCION;

                InitializeComponent();

                //---- GSG (06/03/2021)
                Utiles.GetConfigConnection();
                this.sqlConn.ConnectionString = Utiles._connection.ConnectionString.ToString();


                frmP = new frmProcesando();
                frmP.Show();

                sIdPedido = "";
                iIdDelegado = Clases.Configuracion.iIdDelegado;
                txbDelegado.Text = GESTCRM.Utiles.NombreDeleg(iIdDelegado);

                deleg = true;

                Application.DoEvents();

                init();

                Application.DoEvents();
            }
            catch (Exception e)
            {
                Cursor.Current = Cursors.Default;
                Mensajes.ShowError("Error en constructor frmpedidos(): " + e);
            }
        }

        public frmPedidos(string Cliente)
        {
            // PEDIDO NUEVO Pero calculando previamente el cliente

            try
            {


                TipoAcceso = (int)acceso.INSERCION;

                oPedido = new GESTCRM.Clases.Pedido();
                InitializeComponent();

                //---- GSG (06/03/2021)
                Utiles.GetConfigConnection();
                this.sqlConn.ConnectionString = Utiles._connection.ConnectionString.ToString();


                frmP = new frmProcesando();
                frmP.Show();

                Application.DoEvents();

                sIdPedido = "";
                iIdDelegado = Clases.Configuracion.iIdDelegado;
                this.txbDelegado.Text = GESTCRM.Utiles.NombreDeleg(iIdDelegado);
                deleg = true;

                init();

                Application.DoEvents();

                //Informar Cliente y Destinatario
                this.txtClienteSAP.Text = this.txtDestinatarioSAP.Text = Cliente;

                txtClienteSAP_Leave(this, null);
                Application.DoEvents();
                txtDestinatarioSAP_Leave(this, null);

                if (txtClienteSAP.Text.Trim() != "")
                {
                    //FormatBuscarCampanyas(iIdCliente, true, "");
                    FormatBuscarCampanyas(iIdCliente, true, "", Cliente); //---- GSG (05/07/2017) Aquí Cliente tiene el cliente no el mayorista. Como el tipo de pedido es "" en format le pondrá XXXX
                    pintaRentabilidadAnual(false, DateTime.Today);
                }
            }
            catch (Exception e)
            {
                Mensajes.ShowError("Error en constructor frmpedidos(): " + e);
            }
        }

        public frmPedidos(string sIP, int IdDelegado, char cTipoAcceso)
        {
            try
            {


                if (cTipoAcceso != 'C' && cTipoAcceso != 'M')
                    return;

                sIdPedido = sIP;

                InitializeComponent();


                //---- GSG (06/03/2021)
                Utiles.GetConfigConnection();
                this.sqlConn.ConnectionString = Utiles._connection.ConnectionString.ToString();



                frmP = new frmProcesando();
                frmP.Show();

                Application.DoEvents();

                //Si El delegado  es el actual, entonces se puede modificar el pedido o borrarlo.

                iIdDelegado = Clases.Configuracion.iIdDelegado;

                deleg = true;
                if (iIdDelegado != IdDelegado)
                {
                    TipoAcceso = (int)acceso.CONSULTA;
                    deleg = false;
                }
                else
                    TipoAcceso = (int)acceso.MODIFICACION;

                if (cTipoAcceso == 'C')
                    TipoAcceso = (int)acceso.CONSULTA;

                this.txbDelegado.Text = GESTCRM.Utiles.NombreDeleg(iIdDelegado);

                Application.DoEvents();

                Configuracion.Carga();

                Application.DoEvents();

                init();

                Application.DoEvents();

            }
            catch (Exception ev)
            {
                Mensajes.ShowError("Error en constructor frmpedidos(string sIP, int iIdDelegado): " + ev.ToString().ToString());
            }
        }

        public frmPedidos(string Cliente, int IdCliente, string NombreCliente, string Campanya, string IdTipoPedido) //---- GSG (12/12/2014) añade IdTipoPedido
        {
            // PEDIDO NUEVO Pero calculando previamente el cliente y la campaña
            // Lo usamos al importar el fichero de pedido

            try
            {


                TipoAcceso = (int)acceso.INSERCION;

                oPedido = new GESTCRM.Clases.Pedido();
                InitializeComponent();

                //---- GSG (06/03/2021)
                Utiles.GetConfigConnection();
                this.sqlConn.ConnectionString = Utiles._connection.ConnectionString.ToString();

                frmP = new frmProcesando();
                frmP.Show();

                Application.DoEvents();

                sIdPedido = "";
                iIdDelegado = Clases.Configuracion.iIdDelegado;
                this.txbDelegado.Text = GESTCRM.Utiles.NombreDeleg(iIdDelegado);
                deleg = true;

                init();

                Application.DoEvents();

                //Cosas a hacer que en las llamadas normales al formulario se hacen al seleccionar el cliente.
                //En este caso lo tenemos que hacer aquí porqué entramos de forma anormal con el cliente ya seleccionado

                //Informar Cliente y Destinatario
                this.txtClienteSAP.Text = this.txtDestinatarioSAP.Text = Cliente;
                this.txtsCliente.Text = this.txtsDestinatario.Text = NombreCliente;
                iIdCliente = IdCliente;
                iIdDestinatario = iIdCliente;
                _bEsDirectoZMAY = EsDirectoZMAY(iIdDestinatario); //Un mayorista es ZMAY si pertenece a un club que está en la tabla DirectoZMAY

                Application.DoEvents();


                //---- GSG (27/09/2017)
                if (dtLineasPedido == null)
                {
                    dtLineasPedido = new dsMateriales.ListaLineasPedidoDataTable();
                    dsMateriales1.ListaLineasPedido.Rows.Clear();
                    sqldaListaLineasPedido.SelectCommand.Parameters["@sIdPedido"].Value = "";

                    Application.DoEvents();
                    sqldaListaLineasPedido.Fill(dtLineasPedido);
                    Application.DoEvents();
                }
                //---- FI GSG



                if (IdTipoPedido != "")
                    cboTipoPedido.SelectedValue = IdTipoPedido;


                dto_general();
                txbDecil.Text = GESTCRM.Utiles.DecilCliente(iIdCliente);
                txbDecilP.Text = GESTCRM.Utiles.DecilProvincialCliente(iIdCliente);

                //---- GSG (06/03/2021)
                //if (GESTCRM.Utiles.DeudaVencida(iIdCliente))
                //    Mensajes.ShowInformation("Mientras no se liquide la deuda vencida este pedido no se servirá.");

                int ret = GESTCRM.Utiles.DeudaVencida(iIdCliente);
                switch (ret)
                {
                    case 1:
                        Mensajes.ShowInformation("Mientras no se liquide la deuda vencida este pedido no se servirá.");
                        break;
                    case 2:
                        Mensajes.ShowInformation("Un cliente Intrum solo puede pasar pedidos Transfer/Compromiso.");
                        break;
                    case 3:
                        Mensajes.ShowInformation("Mientras no se liquide la deuda vencida este pedido no se servirá.\r\nUn cliente Intrum solo puede pasar pedidos Transfer/Compromiso.");
                        break;

                }



                if (txtClienteSAP.Text.Trim() != "")
                {
                    //FormatBuscarCampanyas(IdCliente, true, cboTipoPedido.SelectedValue.ToString());
                    FormatBuscarCampanyas(iIdCliente, true, cboTipoPedido.SelectedValue.ToString(), Cliente); //---- GSG (05/07/2017)                    
                    pintaRentabilidadAnual(false, DateTime.Today);
                }

                string value = "-1";
                bool bExists = false;

                for (int i = 0; i < cBoxCampanyas.Items.Count; i++)
                {
                    cBoxCampanyas.SelectedIndex = i;
                    cBoxCampanyas.SelectedItem = cBoxCampanyas.Items[cBoxCampanyas.SelectedIndex];
                    value = cBoxCampanyas.SelectedValue.ToString();

                    if (value == Campanya)
                    {
                        bExists = true;
                        break;
                    }
                }

                if (bExists)
                    cBoxCampanyas.SelectedValue = Campanya;
                else
                {
                    //---- GSG (06/03/2018)
                    //cBoxCampanyas.SelectedIndex = 0;
                    if (cBoxCampanyas.Items.Count > 0)
                        cBoxCampanyas.SelectedIndex = 0;
                    else
                        cBoxCampanyas.Enabled = false;
                }

                if (IdTipoPedido != "")
                    cboTipoPedido.SelectedValue = IdTipoPedido;

            }
            catch (Exception e)
            {
                Mensajes.ShowError("Error en constructor frmpedidos(): " + e);
            }
        }

        //---- GSG (05/07/2017)
        //public frmPedidos(string sIP, int Cliente, bool esCopia, string tipoPedido, bool bFlexible)
        public frmPedidos(string sIP, int Cliente, bool esCopia, string tipoPedido, bool bFlexible, string sIdMayorista)
        {
            try
            {


                if (esCopia)
                {
                    TipoAcceso = (int)acceso.INSERCION;

                    sIdPedido = sIP;  //De momento para poder recuperar datos, después se reseteará el código del pedido por ser nuevo
                    _bEsCopia = esCopia;
                    iIdCliente = Cliente;
                    _sTipoPedido = tipoPedido;
                    _bEsFlexible = bFlexible;

                    InitializeComponent();

                    //---- GSG (06/03/2021)
                    Utiles.GetConfigConnection();
                    this.sqlConn.ConnectionString = Utiles._connection.ConnectionString.ToString();

                    frmP = new frmProcesando();
                    frmP.Show();

                    Application.DoEvents();

                    iIdDelegado = Clases.Configuracion.iIdDelegado;
                    this.txbDelegado.Text = GESTCRM.Utiles.NombreDeleg(iIdDelegado);

                    Application.DoEvents();

                    Configuracion.Carga();

                    Application.DoEvents();

                    init();

                    Application.DoEvents();

                    //FormatBuscarCampanyas(iIdCliente, true, tipoPedido);
                    FormatBuscarCampanyas(iIdCliente, true, tipoPedido, sIdMayorista); //---- GSG (05/07/2017)


                    pintaRentabilidadAnual(false, DateTime.Today);

                    Application.DoEvents();
                }
            }
            catch (Exception ev)
            {
                Mensajes.ShowError("Error en constructor frmpedidos(string sIP, int iIdDelegado): " + ev.ToString().ToString());
            }
        }

        protected override void Dispose(bool disposing)
        {
            try
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
            catch (Exception ev)
            {
                Mensajes.ShowError("Error en destructor: " + ev.Message);
            }
        }

        #endregion

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPedidos));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlLineaPedido = new System.Windows.Forms.Panel();
            this.tabPedido = new System.Windows.Forms.TabControl();
            this.tabPageLineasPedido = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txbDtoExcluidos = new System.Windows.Forms.TextBox();
            this.txbDtoCuentan = new System.Windows.Forms.TextBox();
            this.label49 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.txbMargenLab = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.txtGarantias = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btEncuestas = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridViewLineas = new System.Windows.Forms.DataGridView();
            this.ColiIdLinea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sCodNacional = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sIdMaterialDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCampanya = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColObligatorio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPrecioBruto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDescuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColImporteLin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDescuentoMaximo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fRentabilidadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fCosteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColidCampanya = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColidArrastre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColUnidMinimas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColIdGrupoMat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ordre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColfDescExtra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColfDescMat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColbDescExtra = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.sCodVale = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sSerie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bFinanciado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.bMedicamento = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColCajaCompleta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColUnidadesEnfajado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColfDescuentoMaximoTRA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColfPVP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColfPVPIVA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColiStockCanarias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColfDescuentoMaximoDIR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColBorrar = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColCantidadBase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTipoMat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iBloc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsMateriales1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsMateriales1 = new GESTCRM.Formularios.dsMateriales();
            this.btExport = new System.Windows.Forms.Button();
            this.numericUpDownA = new System.Windows.Forms.NumericUpDown();
            this.lblCounter = new System.Windows.Forms.Label();
            this.labelGradient6 = new GESTCRM.Controles.LabelGradient();
            this.txtGarantias2 = new System.Windows.Forms.TextBox();
            this.btCompetencia = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtGarantias4 = new System.Windows.Forms.TextBox();
            this.pnlSeleccionMateriales = new System.Windows.Forms.Panel();
            this.labelGradient1 = new GESTCRM.Controles.LabelGradient();
            this.cBoxCampanyas = new System.Windows.Forms.ComboBox();
            this.listaCampanyasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsFormularios1 = new GESTCRM.Formularios.dsFormularios();
            this.lblCliente = new System.Windows.Forms.Label();
            this.btnBuscarMaterial = new System.Windows.Forms.Button();
            this.txtGarantias3 = new System.Windows.Forms.TextBox();
            this.txbMargenNF = new System.Windows.Forms.TextBox();
            this.label41 = new System.Windows.Forms.Label();
            this.txtGarantias1 = new System.Windows.Forms.TextBox();
            this.txbDescFacturaNF = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txbDescFacturaF = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.txbDtoMedioNF = new System.Windows.Forms.TextBox();
            this.txbDtoMedioF = new System.Windows.Forms.TextBox();
            this.txbDto = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.lblImporteBruto = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.txbImporteBruto = new System.Windows.Forms.TextBox();
            this.lblImporte = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.txbImporteBrutoNF = new System.Windows.Forms.TextBox();
            this.txbImporte = new System.Windows.Forms.TextBox();
            this.txbImporteBrutoF = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.txbImporteNetoNF = new System.Windows.Forms.TextBox();
            this.txbImporteNetoF = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.txbMargen = new System.Windows.Forms.TextBox();
            this.lblMargen = new System.Windows.Forms.Label();
            this.txbPVPIVA = new System.Windows.Forms.TextBox();
            this.txbPVP = new System.Windows.Forms.TextBox();
            this.lblPVPIVA = new System.Windows.Forms.Label();
            this.lblPVP = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txbDescExtraRestante = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txbDescExtra = new System.Windows.Forms.TextBox();
            this.txbRentabilidad = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtRentabilidad = new System.Windows.Forms.TextBox();
            this.tabPageAccMark = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtbPuntosPedConAM = new System.Windows.Forms.TextBox();
            this.label47 = new System.Windows.Forms.Label();
            this.txtbPuntosPedAM = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.lblMissAM = new System.Windows.Forms.Label();
            this.txtbCosteTotalAM = new System.Windows.Forms.TextBox();
            this.label44 = new System.Windows.Forms.Label();
            this.txtbRentabilidadAM = new System.Windows.Forms.TextBox();
            this.label43 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.txtbDescMedioAM = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtbBrutoPedAM = new System.Windows.Forms.TextBox();
            this.lblNumReg = new System.Windows.Forms.Label();
            this.labelGradientAccMark = new GESTCRM.Controles.LabelGradient();
            this.dataGridViewAccMark = new System.Windows.Forms.DataGridView();
            this.selected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.iIdAccionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sIdAccionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sDescAccionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sIdTipoAccionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnidadesAEntregar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iUnidades = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fImpMin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fImpMax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fRentabilidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bIndepe = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.iActivoPara = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sIdProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fCosteUnitarioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bSuma = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.iNumElemEntregar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fCosteTotalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iMaxAEntregar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dFechaCreacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dFechaIniDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dFechaFinDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sObservacionesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sIdTipoImputacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dFUMDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iEstadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bEnviadoPDADataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.iUnidadesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsAccionesMarketing1 = new GESTCRM.Formularios.DataSets.dsAccionesMarketing();
            this.txbDecil = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.dvTiposPosPedidoSAP = new System.Data.DataView();
            this.dvLineasPedido = new System.Data.DataView();
            this.pnlCabeceraPedido = new System.Windows.Forms.Panel();
            this.btGrafPuntos = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtImpMedio = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtMediaPuntos = new System.Windows.Forms.TextBox();
            this.label46 = new System.Windows.Forms.Label();
            this.txtImpMedioNeto = new System.Windows.Forms.TextBox();
            this.label45 = new System.Windows.Forms.Label();
            this.cboProgInf = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.pnCompromiso = new System.Windows.Forms.Panel();
            this.cboIndividual = new System.Windows.Forms.ComboBox();
            this.cboClasico = new System.Windows.Forms.ComboBox();
            this.txbCodPagoFija = new System.Windows.Forms.TextBox();
            this.lblCodPagoFija = new System.Windows.Forms.Label();
            this.txbDecilP = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.txbSPais = new System.Windows.Forms.TextBox();
            this.txbSOficina = new System.Windows.Forms.TextBox();
            this.txbSLocalidad = new System.Windows.Forms.TextBox();
            this.txbSBanco = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.txbCCAndorra = new System.Windows.Forms.TextBox();
            this.txbIBAN = new System.Windows.Forms.TextBox();
            this.btActRent = new System.Windows.Forms.Button();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.txbControl = new System.Windows.Forms.TextBox();
            this.txbOficina = new System.Windows.Forms.TextBox();
            this.txbEntidad = new System.Windows.Forms.TextBox();
            this.txbCC = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.dtpFechaFacturacion = new System.Windows.Forms.DateTimePicker();
            this.cboPrioridad = new System.Windows.Forms.ComboBox();
            this.lblFechaFacturacion = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.cboCondicionPago = new System.Windows.Forms.ComboBox();
            this.lblCondPago = new System.Windows.Forms.Label();
            this.lblAvisoVersion = new System.Windows.Forms.Label();
            this.chkRetenido = new System.Windows.Forms.CheckBox();
            this.txtProgInf = new System.Windows.Forms.TextBox();
            this.txtMailFact = new System.Windows.Forms.TextBox();
            this.txtMailConf = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txbDtoGeneral = new System.Windows.Forms.TextBox();
            this.lblDescGen = new System.Windows.Forms.Label();
            this.txtCodPago = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtbRentAnual = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.dtpFechaVenci = new System.Windows.Forms.DateTimePicker();
            this.chkVisita = new System.Windows.Forms.CheckBox();
            this.cboTipoCampana = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtEncComercial = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTitulo = new GESTCRM.Controles.LabelGradient();
            this.txtDestinatarioSAP = new System.Windows.Forms.TextBox();
            this.txtClienteSAP = new System.Windows.Forms.TextBox();
            this.txbObservaciones = new System.Windows.Forms.TextBox();
            this.txtsDestinatario = new System.Windows.Forms.TextBox();
            this.txbIdPedido = new System.Windows.Forms.TextBox();
            this.txbDelegado = new System.Windows.Forms.TextBox();
            this.btBuscarDestinatario = new System.Windows.Forms.Button();
            this.btBuscarCliente = new System.Windows.Forms.Button();
            this.txtsCliente = new System.Windows.Forms.TextBox();
            this.dtpFechaPedido = new System.Windows.Forms.DateTimePicker();
            this.lblFechaPedido = new System.Windows.Forms.Label();
            this.cboTipoPedido = new System.Windows.Forms.ComboBox();
            this.dtpFechaFij = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaPref = new System.Windows.Forms.DateTimePicker();
            this.lblObservaciones = new System.Windows.Forms.Label();
            this.lblFechaFijada = new System.Windows.Forms.Label();
            this.lblFechaPref = new System.Windows.Forms.Label();
            this.lblTipoPedido = new System.Windows.Forms.Label();
            this.lblDelegado = new System.Windows.Forms.Label();
            this.lblPedido = new System.Windows.Forms.Label();
            this.lblDestinatario = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.toolTipPedidos = new System.Windows.Forms.ToolTip(this.components);
            this.sqlConn = new System.Data.SqlClient.SqlConnection();
            this.sqlCmdSetPedidosCab = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdSetPedAcciones = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdGetPedAcciones = new System.Data.SqlClient.SqlCommand();
            this.sqldaListaLineasPedido = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqldaListaLineasPedidoRentAnual = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectLineasPedidoRentAnual = new System.Data.SqlClient.SqlCommand();
            this.sqldaListaLineasPedidoRentAnualArrastre = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectLineasPedidoRentAnualArrastre = new System.Data.SqlClient.SqlCommand();
            this.sqldaProgInf = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCmdProgInf = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdCargaPedido = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdGetValorsProdCamp = new System.Data.SqlClient.SqlCommand();
            this.sqldaListaTiposPosPedidoSAP = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
            this.sqldaListaClubsAviso = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectListaClubsAviso = new System.Data.SqlClient.SqlCommand();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.menuNuevo = new System.Windows.Forms.MenuItem();
            this.menuEliminar = new System.Windows.Forms.MenuItem();
            this.dvTipoPedido = new System.Data.DataView();
            this.sqldaListaTiposPedidoSAP = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
            this.sqldaListaCondPago = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCmdCondPago = new System.Data.SqlClient.SqlCommand();
            this.sqldaListaPrioridad = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCmdPrioridad = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdGetClientesSAP = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdGetCampanyasPedido = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdGetIsCampanyaMultiple = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdSetCampanyaPedido = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdDeleteCampanyasPedido = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdGetIsDescuentoMaxInformed = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdGetIsDescuentoMinGarInformed = new System.Data.SqlClient.SqlCommand();
            this.sqlDaListaMateriales = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCommand2 = new System.Data.SqlClient.SqlCommand();
            this.dsPedidos1 = new GESTCRM.Formularios.DataSets.dsPedidos();
            this.sqlCmdGetRentabilidadDescripcion = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdGetRentabilidadColor = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdGetMaterialesNoRentabilidad = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdGetCampanyasNoRentabilidad = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdGetMaterialesNoMargen = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdGetFechaVencimiento = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdSetCondicionesComercialesTemp = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdDelCondicionesComercialesTemp = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdGetDescuentoMayoristaClub = new System.Data.SqlClient.SqlCommand();
            this.sqldaListaCampanyas = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCmdListaCampanyasNEW = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdListaCampanyas = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdListaCampanyasPedInactivo = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdListaCampanyasPedInactivoNEW = new System.Data.SqlClient.SqlCommand();
            this.sqlCommand3 = new System.Data.SqlClient.SqlCommand();
            this.iIdLinea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreCampanya = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sObligatorio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ImporteLin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fDescuentoMaximo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fCoste = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnidMinimas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sqlCmdSetPedidosLin = new System.Data.SqlClient.SqlCommand();
            this.sqldaListaCampCabecera = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCommand4 = new System.Data.SqlClient.SqlCommand();
            this.sqlCommand4CECL = new System.Data.SqlClient.SqlCommand();
            this.listaAccionesMarketingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sqlDataListaAccionesMarketing = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlCommand1CECL = new System.Data.SqlClient.SqlCommand();
            this.ucBotoneraSecundaria1 = new GESTCRM.Controles.ucBotoneraSecundaria();
            this.sqlCmdProductoMaterial = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdMaxAccMark = new System.Data.SqlClient.SqlCommand();
            this.sqldaCampsDup = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCmdCampsDup = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdGrupoVencimientoMaterial = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdTipoMat = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdListaContactosClientes_SAP = new System.Data.SqlClient.SqlCommand();
            this.sqldaListaAccionesMarkCli = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommandListaAccionesMarkCli = new System.Data.SqlClient.SqlCommand();
            this.sqlGetNumAcckMarkADescartar = new System.Data.SqlClient.SqlCommand();
            this.sqlGetRentMinCampCab = new System.Data.SqlClient.SqlCommand();
            this.sqlGetCondPagoCampCab = new System.Data.SqlClient.SqlCommand();
            this.sqlGetCondPagoFijaCampCab = new System.Data.SqlClient.SqlCommand();
            this.sqlGetFecFact = new System.Data.SqlClient.SqlCommand();
            this.sqldaGetMatsConVale = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCmdGetMatsConVale = new System.Data.SqlClient.SqlCommand();
            this.sqldaListaMatsConVale = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCmdListaMatsConVale = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdSetVale = new System.Data.SqlClient.SqlCommand();
            this.sqlGetRentMinCamp = new System.Data.SqlClient.SqlCommand();
            this.sqldaListaAccMarkCamp = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCmdListaAccMarkCamp = new System.Data.SqlClient.SqlCommand();
            this.sqldaListaAccMarkCampByCli = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCmdListaAccMarkCampByCli = new System.Data.SqlClient.SqlCommand();
            this.sqldaListaAvisoMUV = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCmdListaAvisoMUV = new System.Data.SqlClient.SqlCommand();
            this.sqldaListaMUV = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCmdListaMUV = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdSetUltimosAvisos = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdSetEmailsCliente = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdSetRetenido = new System.Data.SqlClient.SqlCommand();
            this.sqlGetRetenido = new System.Data.SqlClient.SqlCommand();
            this.sqldaListaEmailsCliente = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCmdListaEmailsCliente = new System.Data.SqlClient.SqlCommand();
            this.sqldaDescMax = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectListaDescMax = new System.Data.SqlClient.SqlCommand();
            this.sqlcmdExisteCampInAccMarkCamp = new System.Data.SqlClient.SqlCommand();
            this.sqldaListaProgInfCliente_SAP = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommandListaProgInfporCliente_SAP = new System.Data.SqlClient.SqlCommand();
            this.sqlGetImporteMedioPedido = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdSetContactosClientesSAP = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdSetProgInfClientesSAP = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdGetRegionClienteSAP = new System.Data.SqlClient.SqlCommand();
            this.sqldaRegion = new System.Data.SqlClient.SqlDataAdapter();
            this.dsClientes1 = new GESTCRM.Formularios.DataSets.dsClientes();
            this.sqlGetSumaUnidades = new System.Data.SqlClient.SqlCommand();
            this.sqlGetTipoPedidoSumaUnidades = new System.Data.SqlClient.SqlCommand();
            this.sqldaMatsEspeciales = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCmdMatsEspeciales = new System.Data.SqlClient.SqlCommand();
            this.sqldaListaTarjetasCliente = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCmdListaTarjetasCliente = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdSetUsoTarjetasCliente = new System.Data.SqlClient.SqlCommand();
            this.sqldaListaProductos = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCmdListaProductos = new System.Data.SqlClient.SqlCommand();
            this.sqldaAccMarkExcluidas = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCmdAccMarkExcluidas = new System.Data.SqlClient.SqlCommand();
            this.sqldaListaMaterialesBloqueados = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCmdListaMaterialesBloqueados = new System.Data.SqlClient.SqlCommand();
            this.sqldaListaTiposPedidoCompromiso = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCmdListaTiposPedidoCompromiso = new System.Data.SqlClient.SqlCommand();
            this.sqldaListaTiposGestionCompromiso = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCmdListaTiposGestionCompromiso = new System.Data.SqlClient.SqlCommand();
            this.sqldaListaMatsZMKT = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCmdListaMatsZMKT = new System.Data.SqlClient.SqlCommand();
            this.sqldaCP = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCmdGetCPClienteSAP = new System.Data.SqlClient.SqlCommand();
            this.sqldaListaAccionesAbiertasClientee = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCmdListaAccionesAbiertasCliente = new System.Data.SqlClient.SqlCommand();
            this.sqldaCodsAccMark = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCmdListaCodsAccMark = new System.Data.SqlClient.SqlCommand();
            this.pnlLineaPedido.SuspendLayout();
            this.tabPedido.SuspendLayout();
            this.tabPageLineasPedido.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLineas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsMateriales1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsMateriales1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownA)).BeginInit();
            this.pnlSeleccionMateriales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listaCampanyasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsFormularios1)).BeginInit();
            this.tabPageAccMark.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAccMark)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAccionesMarketing1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dvTiposPosPedidoSAP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dvLineasPedido)).BeginInit();
            this.pnlCabeceraPedido.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.pnCompromiso.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvTipoPedido)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPedidos1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listaAccionesMarketingBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsClientes1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlLineaPedido
            // 
            this.pnlLineaPedido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnlLineaPedido.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlLineaPedido.Controls.Add(this.tabPedido);
            this.pnlLineaPedido.ForeColor = System.Drawing.Color.Black;
            this.pnlLineaPedido.Location = new System.Drawing.Point(2, 203);
            this.pnlLineaPedido.Name = "pnlLineaPedido";
            this.pnlLineaPedido.Size = new System.Drawing.Size(1492, 585);
            this.pnlLineaPedido.TabIndex = 1;
            // 
            // tabPedido
            // 
            this.tabPedido.Controls.Add(this.tabPageLineasPedido);
            this.tabPedido.Controls.Add(this.tabPageAccMark);
            this.tabPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPedido.Location = new System.Drawing.Point(-3, 2);
            this.tabPedido.Name = "tabPedido";
            this.tabPedido.SelectedIndex = 0;
            this.tabPedido.Size = new System.Drawing.Size(1492, 587);
            this.tabPedido.TabIndex = 109;
            this.tabPedido.SelectedIndexChanged += new System.EventHandler(this.tabPedido_SelectedIndexChanged);
            // 
            // tabPageLineasPedido
            // 
            this.tabPageLineasPedido.Controls.Add(this.panel1);
            this.tabPageLineasPedido.Location = new System.Drawing.Point(4, 29);
            this.tabPageLineasPedido.Name = "tabPageLineasPedido";
            this.tabPageLineasPedido.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLineasPedido.Size = new System.Drawing.Size(1484, 554);
            this.tabPageLineasPedido.TabIndex = 0;
            this.tabPageLineasPedido.Text = "Líneas Pedido";
            this.tabPageLineasPedido.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.txbDtoExcluidos);
            this.panel1.Controls.Add(this.txbDtoCuentan);
            this.panel1.Controls.Add(this.label49);
            this.panel1.Controls.Add(this.label48);
            this.panel1.Controls.Add(this.txbMargenLab);
            this.panel1.Controls.Add(this.label25);
            this.panel1.Controls.Add(this.txtGarantias);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btEncuestas);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.txtGarantias2);
            this.panel1.Controls.Add(this.btCompetencia);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtGarantias4);
            this.panel1.Controls.Add(this.pnlSeleccionMateriales);
            this.panel1.Controls.Add(this.txtGarantias3);
            this.panel1.Controls.Add(this.txbMargenNF);
            this.panel1.Controls.Add(this.label41);
            this.panel1.Controls.Add(this.txtGarantias1);
            this.panel1.Controls.Add(this.txbDescFacturaNF);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.txbDescFacturaF);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label38);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label39);
            this.panel1.Controls.Add(this.label40);
            this.panel1.Controls.Add(this.txbDtoMedioNF);
            this.panel1.Controls.Add(this.txbDtoMedioF);
            this.panel1.Controls.Add(this.txbDto);
            this.panel1.Controls.Add(this.label35);
            this.panel1.Controls.Add(this.lblImporteBruto);
            this.panel1.Controls.Add(this.label36);
            this.panel1.Controls.Add(this.txbImporteBruto);
            this.panel1.Controls.Add(this.lblImporte);
            this.panel1.Controls.Add(this.label37);
            this.panel1.Controls.Add(this.txbImporteBrutoNF);
            this.panel1.Controls.Add(this.txbImporte);
            this.panel1.Controls.Add(this.txbImporteBrutoF);
            this.panel1.Controls.Add(this.label31);
            this.panel1.Controls.Add(this.label32);
            this.panel1.Controls.Add(this.label34);
            this.panel1.Controls.Add(this.txbImporteNetoNF);
            this.panel1.Controls.Add(this.txbImporteNetoF);
            this.panel1.Controls.Add(this.label33);
            this.panel1.Controls.Add(this.label30);
            this.panel1.Controls.Add(this.label29);
            this.panel1.Controls.Add(this.txbMargen);
            this.panel1.Controls.Add(this.lblMargen);
            this.panel1.Controls.Add(this.txbPVPIVA);
            this.panel1.Controls.Add(this.txbPVP);
            this.panel1.Controls.Add(this.lblPVPIVA);
            this.panel1.Controls.Add(this.lblPVP);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txbDescExtraRestante);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.txbDescExtra);
            this.panel1.Controls.Add(this.txbRentabilidad);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.txtRentabilidad);
            this.panel1.Location = new System.Drawing.Point(-1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1492, 560);
            this.panel1.TabIndex = 88;
            // 
            // txbDtoExcluidos
            // 
            this.txbDtoExcluidos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txbDtoExcluidos.Cursor = System.Windows.Forms.Cursors.Default;
            this.txbDtoExcluidos.Enabled = false;
            this.txbDtoExcluidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbDtoExcluidos.Location = new System.Drawing.Point(1403, 463);
            this.txbDtoExcluidos.Margin = new System.Windows.Forms.Padding(2);
            this.txbDtoExcluidos.Name = "txbDtoExcluidos";
            this.txbDtoExcluidos.ReadOnly = true;
            this.txbDtoExcluidos.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txbDtoExcluidos.Size = new System.Drawing.Size(72, 26);
            this.txbDtoExcluidos.TabIndex = 192;
            this.txbDtoExcluidos.TabStop = false;
            this.txbDtoExcluidos.Text = "0%";
            // 
            // txbDtoCuentan
            // 
            this.txbDtoCuentan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txbDtoCuentan.Cursor = System.Windows.Forms.Cursors.Default;
            this.txbDtoCuentan.Enabled = false;
            this.txbDtoCuentan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbDtoCuentan.Location = new System.Drawing.Point(1403, 433);
            this.txbDtoCuentan.Margin = new System.Windows.Forms.Padding(2);
            this.txbDtoCuentan.Name = "txbDtoCuentan";
            this.txbDtoCuentan.ReadOnly = true;
            this.txbDtoCuentan.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txbDtoCuentan.Size = new System.Drawing.Size(72, 26);
            this.txbDtoCuentan.TabIndex = 191;
            this.txbDtoCuentan.TabStop = false;
            this.txbDtoCuentan.Text = "0%";
            // 
            // label49
            // 
            this.label49.Enabled = false;
            this.label49.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label49.ForeColor = System.Drawing.Color.Red;
            this.label49.Location = new System.Drawing.Point(1211, 462);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(194, 28);
            this.label49.TabIndex = 190;
            this.label49.Text = "Desc. Medio Excluidos:";
            this.label49.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label48
            // 
            this.label48.Enabled = false;
            this.label48.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label48.ForeColor = System.Drawing.Color.Red;
            this.label48.Location = new System.Drawing.Point(1211, 431);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(197, 28);
            this.label48.TabIndex = 189;
            this.label48.Text = "Desc. Medio Mats Cuentan:";
            this.label48.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txbMargenLab
            // 
            this.txbMargenLab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txbMargenLab.Cursor = System.Windows.Forms.Cursors.Default;
            this.txbMargenLab.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbMargenLab.Location = new System.Drawing.Point(1351, 504);
            this.txbMargenLab.Margin = new System.Windows.Forms.Padding(2);
            this.txbMargenLab.Name = "txbMargenLab";
            this.txbMargenLab.ReadOnly = true;
            this.txbMargenLab.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txbMargenLab.Size = new System.Drawing.Size(124, 26);
            this.txbMargenLab.TabIndex = 188;
            this.txbMargenLab.TabStop = false;
            this.txbMargenLab.Text = "0";
            // 
            // label25
            // 
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.Red;
            this.label25.Location = new System.Drawing.Point(1215, 506);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(134, 24);
            this.label25.TabIndex = 187;
            this.label25.Text = "Puntos Pedido:";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtGarantias
            // 
            this.txtGarantias.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtGarantias.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtGarantias.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGarantias.Location = new System.Drawing.Point(1029, 425);
            this.txtGarantias.Name = "txtGarantias";
            this.txtGarantias.ReadOnly = true;
            this.txtGarantias.Size = new System.Drawing.Size(180, 24);
            this.txtGarantias.TabIndex = 97;
            this.txtGarantias.TabStop = false;
            // 
            // button1
            // 
            this.button1.Image = global::GESTCRM.Properties.Resources.Mail;
            this.button1.Location = new System.Drawing.Point(42, 425);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(52, 52);
            this.button1.TabIndex = 158;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btEncuestas
            // 
            this.btEncuestas.Image = global::GESTCRM.Properties.Resources.Survey1;
            this.btEncuestas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btEncuestas.Location = new System.Drawing.Point(125, 425);
            this.btEncuestas.Name = "btEncuestas";
            this.btEncuestas.Size = new System.Drawing.Size(147, 52);
            this.btEncuestas.TabIndex = 89;
            this.btEncuestas.Text = "Encuestas";
            this.btEncuestas.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btEncuestas.UseVisualStyleBackColor = true;
            this.btEncuestas.Click += new System.EventHandler(this.btEncuestas_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.dataGridViewLineas);
            this.panel2.Controls.Add(this.btExport);
            this.panel2.Controls.Add(this.numericUpDownA);
            this.panel2.Controls.Add(this.lblCounter);
            this.panel2.Controls.Add(this.labelGradient6);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1477, 311);
            this.panel2.TabIndex = 0;
            // 
            // dataGridViewLineas
            // 
            this.dataGridViewLineas.AllowUserToAddRows = false;
            this.dataGridViewLineas.AllowUserToDeleteRows = false;
            this.dataGridViewLineas.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridViewLineas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewLineas.AutoGenerateColumns = false;
            this.dataGridViewLineas.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewLineas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewLineas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewLineas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLineas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColiIdLinea,
            this.sCodNacional,
            this.sIdMaterialDataGridViewTextBoxColumn,
            this.ColProducto,
            this.ColCampanya,
            this.ColObligatorio,
            this.ColCantidad,
            this.ColPrecioBruto,
            this.ColPrecio,
            this.ColDescuento,
            this.ColImporteLin,
            this.ColDescuentoMaximo,
            this.fRentabilidadDataGridViewTextBoxColumn,
            this.fCosteDataGridViewTextBoxColumn,
            this.ColidCampanya,
            this.ColidArrastre,
            this.ColUnidMinimas,
            this.ColIdGrupoMat,
            this.ordre,
            this.ColfDescExtra,
            this.ColfDescMat,
            this.ColbDescExtra,
            this.sCodVale,
            this.sSerie,
            this.bFinanciado,
            this.bMedicamento,
            this.ColCajaCompleta,
            this.ColUnidadesEnfajado,
            this.ColfDescuentoMaximoTRA,
            this.ColfPVP,
            this.ColfPVPIVA,
            this.ColiStockCanarias,
            this.ColfDescuentoMaximoDIR,
            this.ColBorrar,
            this.ColCantidadBase,
            this.ColTipoMat,
            this.iBloc});
            this.dataGridViewLineas.DataMember = "ListaLineasPedido";
            this.dataGridViewLineas.DataSource = this.dsMateriales1BindingSource;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewLineas.DefaultCellStyle = dataGridViewCellStyle13;
            this.dataGridViewLineas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewLineas.Location = new System.Drawing.Point(0, 20);
            this.dataGridViewLineas.MultiSelect = false;
            this.dataGridViewLineas.Name = "dataGridViewLineas";
            this.dataGridViewLineas.RowHeadersVisible = false;
            this.dataGridViewLineas.RowHeadersWidth = 25;
            this.dataGridViewLineas.RowTemplate.Height = 21;
            this.dataGridViewLineas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewLineas.Size = new System.Drawing.Size(1475, 289);
            this.dataGridViewLineas.TabIndex = 91;
            this.dataGridViewLineas.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridViewLineas_CellBeginEdit);
            this.dataGridViewLineas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewLineas_CellClick);
            this.dataGridViewLineas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewLineas_CellDoubleClick);
            this.dataGridViewLineas.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewLineas_CellEndEdit);
            this.dataGridViewLineas.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewLineas_CellLeave);
            this.dataGridViewLineas.CellParsing += new System.Windows.Forms.DataGridViewCellParsingEventHandler(this.dataGridViewLineas_CellParsing);
            this.dataGridViewLineas.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridViewLineas_DataError);
            this.dataGridViewLineas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dataGridViewLineas_MouseUp);
            // 
            // ColiIdLinea
            // 
            this.ColiIdLinea.DataPropertyName = "iIdLinea";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColiIdLinea.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColiIdLinea.HeaderText = "Línea";
            this.ColiIdLinea.MinimumWidth = 8;
            this.ColiIdLinea.Name = "ColiIdLinea";
            this.ColiIdLinea.ReadOnly = true;
            this.ColiIdLinea.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColiIdLinea.Width = 75;
            // 
            // sCodNacional
            // 
            this.sCodNacional.DataPropertyName = "sCodNacional";
            this.sCodNacional.HeaderText = "C.Nacional";
            this.sCodNacional.MinimumWidth = 8;
            this.sCodNacional.Name = "sCodNacional";
            this.sCodNacional.Width = 120;
            // 
            // sIdMaterialDataGridViewTextBoxColumn
            // 
            this.sIdMaterialDataGridViewTextBoxColumn.DataPropertyName = "sIdMaterial";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.sIdMaterialDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.sIdMaterialDataGridViewTextBoxColumn.HeaderText = "Cod. Prod.";
            this.sIdMaterialDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.sIdMaterialDataGridViewTextBoxColumn.Name = "sIdMaterialDataGridViewTextBoxColumn";
            this.sIdMaterialDataGridViewTextBoxColumn.ReadOnly = true;
            this.sIdMaterialDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.sIdMaterialDataGridViewTextBoxColumn.Visible = false;
            this.sIdMaterialDataGridViewTextBoxColumn.Width = 73;
            // 
            // ColProducto
            // 
            this.ColProducto.DataPropertyName = "sMaterial";
            this.ColProducto.HeaderText = "Producto";
            this.ColProducto.MinimumWidth = 8;
            this.ColProducto.Name = "ColProducto";
            this.ColProducto.ReadOnly = true;
            this.ColProducto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColProducto.Width = 400;
            // 
            // ColCampanya
            // 
            this.ColCampanya.DataPropertyName = "NombreCampanya";
            this.ColCampanya.HeaderText = "Campaña";
            this.ColCampanya.MinimumWidth = 8;
            this.ColCampanya.Name = "ColCampanya";
            this.ColCampanya.ReadOnly = true;
            this.ColCampanya.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColCampanya.Width = 350;
            // 
            // ColObligatorio
            // 
            this.ColObligatorio.DataPropertyName = "sObligatorio";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColObligatorio.DefaultCellStyle = dataGridViewCellStyle5;
            this.ColObligatorio.HeaderText = "Oblig.";
            this.ColObligatorio.MinimumWidth = 8;
            this.ColObligatorio.Name = "ColObligatorio";
            this.ColObligatorio.ReadOnly = true;
            this.ColObligatorio.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColObligatorio.Width = 60;
            // 
            // ColCantidad
            // 
            this.ColCantidad.DataPropertyName = "iCantidad";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColCantidad.DefaultCellStyle = dataGridViewCellStyle6;
            this.ColCantidad.HeaderText = "Cantidad";
            this.ColCantidad.MinimumWidth = 8;
            this.ColCantidad.Name = "ColCantidad";
            this.ColCantidad.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColCantidad.Width = 150;
            // 
            // ColPrecioBruto
            // 
            this.ColPrecioBruto.DataPropertyName = "fPrecio";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "C2";
            dataGridViewCellStyle7.NullValue = null;
            this.ColPrecioBruto.DefaultCellStyle = dataGridViewCellStyle7;
            this.ColPrecioBruto.HeaderText = "PrecioBruto";
            this.ColPrecioBruto.MinimumWidth = 8;
            this.ColPrecioBruto.Name = "ColPrecioBruto";
            this.ColPrecioBruto.ReadOnly = true;
            this.ColPrecioBruto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColPrecioBruto.Visible = false;
            this.ColPrecioBruto.Width = 150;
            // 
            // ColPrecio
            // 
            this.ColPrecio.DataPropertyName = "PrecioUnitario";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "C2";
            this.ColPrecio.DefaultCellStyle = dataGridViewCellStyle8;
            this.ColPrecio.HeaderText = "Precio";
            this.ColPrecio.MinimumWidth = 8;
            this.ColPrecio.Name = "ColPrecio";
            this.ColPrecio.ReadOnly = true;
            this.ColPrecio.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColPrecio.Width = 150;
            // 
            // ColDescuento
            // 
            this.ColDescuento.DataPropertyName = "fDescuento";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.Format = "N2";
            dataGridViewCellStyle9.NullValue = null;
            this.ColDescuento.DefaultCellStyle = dataGridViewCellStyle9;
            this.ColDescuento.HeaderText = "Descuento";
            this.ColDescuento.MinimumWidth = 8;
            this.ColDescuento.Name = "ColDescuento";
            this.ColDescuento.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColDescuento.Width = 150;
            // 
            // ColImporteLin
            // 
            this.ColImporteLin.DataPropertyName = "ImporteLin";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "C2";
            dataGridViewCellStyle10.NullValue = null;
            this.ColImporteLin.DefaultCellStyle = dataGridViewCellStyle10;
            this.ColImporteLin.HeaderText = "Importe";
            this.ColImporteLin.MinimumWidth = 8;
            this.ColImporteLin.Name = "ColImporteLin";
            this.ColImporteLin.ReadOnly = true;
            this.ColImporteLin.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColImporteLin.Width = 110;
            // 
            // ColDescuentoMaximo
            // 
            this.ColDescuentoMaximo.DataPropertyName = "fDescuentoMaximo";
            this.ColDescuentoMaximo.HeaderText = "fDescuentoMaximo";
            this.ColDescuentoMaximo.MinimumWidth = 8;
            this.ColDescuentoMaximo.Name = "ColDescuentoMaximo";
            this.ColDescuentoMaximo.ReadOnly = true;
            this.ColDescuentoMaximo.Visible = false;
            this.ColDescuentoMaximo.Width = 150;
            // 
            // fRentabilidadDataGridViewTextBoxColumn
            // 
            this.fRentabilidadDataGridViewTextBoxColumn.DataPropertyName = "fRentabilidad";
            this.fRentabilidadDataGridViewTextBoxColumn.HeaderText = "fRentabilidad";
            this.fRentabilidadDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.fRentabilidadDataGridViewTextBoxColumn.Name = "fRentabilidadDataGridViewTextBoxColumn";
            this.fRentabilidadDataGridViewTextBoxColumn.ReadOnly = true;
            this.fRentabilidadDataGridViewTextBoxColumn.Visible = false;
            this.fRentabilidadDataGridViewTextBoxColumn.Width = 150;
            // 
            // fCosteDataGridViewTextBoxColumn
            // 
            this.fCosteDataGridViewTextBoxColumn.DataPropertyName = "fCoste";
            this.fCosteDataGridViewTextBoxColumn.HeaderText = "fCoste";
            this.fCosteDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.fCosteDataGridViewTextBoxColumn.Name = "fCosteDataGridViewTextBoxColumn";
            this.fCosteDataGridViewTextBoxColumn.ReadOnly = true;
            this.fCosteDataGridViewTextBoxColumn.Visible = false;
            this.fCosteDataGridViewTextBoxColumn.Width = 150;
            // 
            // ColidCampanya
            // 
            this.ColidCampanya.DataPropertyName = "idCampanya";
            this.ColidCampanya.HeaderText = "idCampanya";
            this.ColidCampanya.MinimumWidth = 8;
            this.ColidCampanya.Name = "ColidCampanya";
            this.ColidCampanya.ReadOnly = true;
            this.ColidCampanya.Visible = false;
            this.ColidCampanya.Width = 150;
            // 
            // ColidArrastre
            // 
            this.ColidArrastre.DataPropertyName = "idArrastre";
            this.ColidArrastre.HeaderText = "idArrastre";
            this.ColidArrastre.MinimumWidth = 8;
            this.ColidArrastre.Name = "ColidArrastre";
            this.ColidArrastre.ReadOnly = true;
            this.ColidArrastre.Visible = false;
            this.ColidArrastre.Width = 150;
            // 
            // ColUnidMinimas
            // 
            this.ColUnidMinimas.DataPropertyName = "UnidMinimas";
            this.ColUnidMinimas.HeaderText = "UnidMinimas";
            this.ColUnidMinimas.MinimumWidth = 8;
            this.ColUnidMinimas.Name = "ColUnidMinimas";
            this.ColUnidMinimas.ReadOnly = true;
            this.ColUnidMinimas.Visible = false;
            this.ColUnidMinimas.Width = 150;
            // 
            // ColIdGrupoMat
            // 
            this.ColIdGrupoMat.DataPropertyName = "idGrupoMat";
            this.ColIdGrupoMat.HeaderText = "idGrupoMat";
            this.ColIdGrupoMat.MinimumWidth = 8;
            this.ColIdGrupoMat.Name = "ColIdGrupoMat";
            this.ColIdGrupoMat.ReadOnly = true;
            this.ColIdGrupoMat.Visible = false;
            this.ColIdGrupoMat.Width = 150;
            // 
            // ordre
            // 
            this.ordre.DataPropertyName = "ordre";
            this.ordre.HeaderText = "ordre";
            this.ordre.MinimumWidth = 8;
            this.ordre.Name = "ordre";
            this.ordre.Visible = false;
            this.ordre.Width = 150;
            // 
            // ColfDescExtra
            // 
            this.ColfDescExtra.DataPropertyName = "fDescExtra";
            dataGridViewCellStyle11.Format = "N2";
            dataGridViewCellStyle11.NullValue = null;
            this.ColfDescExtra.DefaultCellStyle = dataGridViewCellStyle11;
            this.ColfDescExtra.HeaderText = "fDescExtra";
            this.ColfDescExtra.MinimumWidth = 8;
            this.ColfDescExtra.Name = "ColfDescExtra";
            this.ColfDescExtra.Visible = false;
            this.ColfDescExtra.Width = 150;
            // 
            // ColfDescMat
            // 
            this.ColfDescMat.DataPropertyName = "fDescMat";
            dataGridViewCellStyle12.Format = "N2";
            dataGridViewCellStyle12.NullValue = null;
            this.ColfDescMat.DefaultCellStyle = dataGridViewCellStyle12;
            this.ColfDescMat.HeaderText = "fDescMat";
            this.ColfDescMat.MinimumWidth = 8;
            this.ColfDescMat.Name = "ColfDescMat";
            this.ColfDescMat.Visible = false;
            this.ColfDescMat.Width = 150;
            // 
            // ColbDescExtra
            // 
            this.ColbDescExtra.DataPropertyName = "bDescExtra";
            this.ColbDescExtra.HeaderText = "bDescExtra";
            this.ColbDescExtra.MinimumWidth = 8;
            this.ColbDescExtra.Name = "ColbDescExtra";
            this.ColbDescExtra.Visible = false;
            this.ColbDescExtra.Width = 150;
            // 
            // sCodVale
            // 
            this.sCodVale.DataPropertyName = "sCodVale";
            this.sCodVale.HeaderText = "sCodVale";
            this.sCodVale.MinimumWidth = 8;
            this.sCodVale.Name = "sCodVale";
            this.sCodVale.ReadOnly = true;
            this.sCodVale.Visible = false;
            this.sCodVale.Width = 150;
            // 
            // sSerie
            // 
            this.sSerie.DataPropertyName = "sSerie";
            this.sSerie.HeaderText = "sSerie";
            this.sSerie.MinimumWidth = 8;
            this.sSerie.Name = "sSerie";
            this.sSerie.ReadOnly = true;
            this.sSerie.Visible = false;
            this.sSerie.Width = 150;
            // 
            // bFinanciado
            // 
            this.bFinanciado.DataPropertyName = "bFinanciado";
            this.bFinanciado.FalseValue = "false";
            this.bFinanciado.HeaderText = "bFinanciado";
            this.bFinanciado.IndeterminateValue = "false";
            this.bFinanciado.MinimumWidth = 8;
            this.bFinanciado.Name = "bFinanciado";
            this.bFinanciado.ReadOnly = true;
            this.bFinanciado.TrueValue = "true";
            this.bFinanciado.Visible = false;
            this.bFinanciado.Width = 150;
            // 
            // bMedicamento
            // 
            this.bMedicamento.DataPropertyName = "bMedicamento";
            this.bMedicamento.FalseValue = "false";
            this.bMedicamento.HeaderText = "bMedicamento";
            this.bMedicamento.IndeterminateValue = "false";
            this.bMedicamento.MinimumWidth = 8;
            this.bMedicamento.Name = "bMedicamento";
            this.bMedicamento.ReadOnly = true;
            this.bMedicamento.TrueValue = "true";
            this.bMedicamento.Visible = false;
            this.bMedicamento.Width = 150;
            // 
            // ColCajaCompleta
            // 
            this.ColCajaCompleta.DataPropertyName = "iCajaCompleta";
            this.ColCajaCompleta.HeaderText = "iCajaCompleta";
            this.ColCajaCompleta.MinimumWidth = 8;
            this.ColCajaCompleta.Name = "ColCajaCompleta";
            this.ColCajaCompleta.ReadOnly = true;
            this.ColCajaCompleta.Visible = false;
            this.ColCajaCompleta.Width = 150;
            // 
            // ColUnidadesEnfajado
            // 
            this.ColUnidadesEnfajado.DataPropertyName = "iUnidadesEnfajado";
            this.ColUnidadesEnfajado.HeaderText = "iUnidadesEnfajado";
            this.ColUnidadesEnfajado.MinimumWidth = 8;
            this.ColUnidadesEnfajado.Name = "ColUnidadesEnfajado";
            this.ColUnidadesEnfajado.ReadOnly = true;
            this.ColUnidadesEnfajado.Visible = false;
            this.ColUnidadesEnfajado.Width = 150;
            // 
            // ColfDescuentoMaximoTRA
            // 
            this.ColfDescuentoMaximoTRA.DataPropertyName = "fDescuentoMaximoTRA";
            this.ColfDescuentoMaximoTRA.HeaderText = "fDescuentoMaximoTRA";
            this.ColfDescuentoMaximoTRA.MinimumWidth = 8;
            this.ColfDescuentoMaximoTRA.Name = "ColfDescuentoMaximoTRA";
            this.ColfDescuentoMaximoTRA.ReadOnly = true;
            this.ColfDescuentoMaximoTRA.Visible = false;
            this.ColfDescuentoMaximoTRA.Width = 150;
            // 
            // ColfPVP
            // 
            this.ColfPVP.DataPropertyName = "fPVP";
            this.ColfPVP.HeaderText = "fPVP";
            this.ColfPVP.MinimumWidth = 8;
            this.ColfPVP.Name = "ColfPVP";
            this.ColfPVP.ReadOnly = true;
            this.ColfPVP.Visible = false;
            this.ColfPVP.Width = 150;
            // 
            // ColfPVPIVA
            // 
            this.ColfPVPIVA.DataPropertyName = "fPVPIVA";
            this.ColfPVPIVA.HeaderText = "fPVPIVA";
            this.ColfPVPIVA.MinimumWidth = 8;
            this.ColfPVPIVA.Name = "ColfPVPIVA";
            this.ColfPVPIVA.ReadOnly = true;
            this.ColfPVPIVA.Visible = false;
            this.ColfPVPIVA.Width = 150;
            // 
            // ColiStockCanarias
            // 
            this.ColiStockCanarias.DataPropertyName = "iStockCanarias";
            this.ColiStockCanarias.HeaderText = "iStockCanarias";
            this.ColiStockCanarias.MinimumWidth = 8;
            this.ColiStockCanarias.Name = "ColiStockCanarias";
            this.ColiStockCanarias.ReadOnly = true;
            this.ColiStockCanarias.Visible = false;
            this.ColiStockCanarias.Width = 150;
            // 
            // ColfDescuentoMaximoDIR
            // 
            this.ColfDescuentoMaximoDIR.DataPropertyName = "fDescuentoMaximoDIR";
            this.ColfDescuentoMaximoDIR.HeaderText = "fDescuentoMaximoDIR";
            this.ColfDescuentoMaximoDIR.MinimumWidth = 8;
            this.ColfDescuentoMaximoDIR.Name = "ColfDescuentoMaximoDIR";
            this.ColfDescuentoMaximoDIR.ReadOnly = true;
            this.ColfDescuentoMaximoDIR.Visible = false;
            this.ColfDescuentoMaximoDIR.Width = 150;
            // 
            // ColBorrar
            // 
            this.ColBorrar.HeaderText = "";
            this.ColBorrar.Image = ((System.Drawing.Image)(resources.GetObject("ColBorrar.Image")));
            this.ColBorrar.MinimumWidth = 8;
            this.ColBorrar.Name = "ColBorrar";
            this.ColBorrar.ReadOnly = true;
            this.ColBorrar.ToolTipText = "Borrar";
            this.ColBorrar.Width = 20;
            // 
            // ColCantidadBase
            // 
            this.ColCantidadBase.DataPropertyName = "iCantidadBase";
            this.ColCantidadBase.HeaderText = "iCantidadBase";
            this.ColCantidadBase.MinimumWidth = 8;
            this.ColCantidadBase.Name = "ColCantidadBase";
            this.ColCantidadBase.Visible = false;
            this.ColCantidadBase.Width = 150;
            // 
            // ColTipoMat
            // 
            this.ColTipoMat.DataPropertyName = "sTipoMat";
            this.ColTipoMat.HeaderText = "sTipoMat";
            this.ColTipoMat.MinimumWidth = 8;
            this.ColTipoMat.Name = "ColTipoMat";
            this.ColTipoMat.Visible = false;
            this.ColTipoMat.Width = 150;
            // 
            // iBloc
            // 
            this.iBloc.DataPropertyName = "iBloc";
            this.iBloc.HeaderText = "iBloc";
            this.iBloc.MinimumWidth = 8;
            this.iBloc.Name = "iBloc";
            this.iBloc.Visible = false;
            this.iBloc.Width = 150;
            // 
            // dsMateriales1BindingSource
            // 
            this.dsMateriales1BindingSource.DataSource = this.dsMateriales1;
            this.dsMateriales1BindingSource.Position = 0;
            // 
            // dsMateriales1
            // 
            this.dsMateriales1.DataSetName = "dsMateriales";
            this.dsMateriales1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btExport
            // 
            this.btExport.Image = global::GESTCRM.Properties.Resources.icoexcel;
            this.btExport.Location = new System.Drawing.Point(1386, -3);
            this.btExport.Name = "btExport";
            this.btExport.Size = new System.Drawing.Size(23, 23);
            this.btExport.TabIndex = 159;
            this.btExport.UseVisualStyleBackColor = true;
            this.btExport.Click += new System.EventHandler(this.btExport_Click);
            // 
            // numericUpDownA
            // 
            this.numericUpDownA.BackColor = System.Drawing.Color.White;
            this.numericUpDownA.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericUpDownA.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownA.Location = new System.Drawing.Point(426, 106);
            this.numericUpDownA.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numericUpDownA.Name = "numericUpDownA";
            this.numericUpDownA.ReadOnly = true;
            this.numericUpDownA.Size = new System.Drawing.Size(69, 20);
            this.numericUpDownA.TabIndex = 92;
            this.numericUpDownA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownA.Visible = false;
            this.numericUpDownA.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numericUpDownA_KeyDown);
            this.numericUpDownA.Leave += new System.EventHandler(this.numericUpDownA_Leave);
            // 
            // lblCounter
            // 
            this.lblCounter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.lblCounter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCounter.ForeColor = System.Drawing.Color.Black;
            this.lblCounter.Location = new System.Drawing.Point(1415, 0);
            this.lblCounter.Name = "lblCounter";
            this.lblCounter.Size = new System.Drawing.Size(60, 18);
            this.lblCounter.TabIndex = 87;
            this.lblCounter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelGradient6
            // 
            this.labelGradient6.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelGradient6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGradient6.ForeColor = System.Drawing.Color.White;
            this.labelGradient6.GradientColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.labelGradient6.GradientColorTwo = System.Drawing.Color.White;
            this.labelGradient6.Location = new System.Drawing.Point(0, 0);
            this.labelGradient6.Name = "labelGradient6";
            this.labelGradient6.Size = new System.Drawing.Size(1475, 20);
            this.labelGradient6.TabIndex = 86;
            this.labelGradient6.Text = "Líneas del pedido";
            this.labelGradient6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtGarantias2
            // 
            this.txtGarantias2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtGarantias2.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtGarantias2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGarantias2.Location = new System.Drawing.Point(1029, 473);
            this.txtGarantias2.Name = "txtGarantias2";
            this.txtGarantias2.ReadOnly = true;
            this.txtGarantias2.Size = new System.Drawing.Size(180, 24);
            this.txtGarantias2.TabIndex = 105;
            this.txtGarantias2.TabStop = false;
            // 
            // btCompetencia
            // 
            this.btCompetencia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btCompetencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCompetencia.Image = ((System.Drawing.Image)(resources.GetObject("btCompetencia.Image")));
            this.btCompetencia.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btCompetencia.Location = new System.Drawing.Point(23, 490);
            this.btCompetencia.Name = "btCompetencia";
            this.btCompetencia.Size = new System.Drawing.Size(192, 40);
            this.btCompetencia.TabIndex = 108;
            this.btCompetencia.TabStop = false;
            this.btCompetencia.Text = "Comparar Competencia";
            this.btCompetencia.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btCompetencia.UseVisualStyleBackColor = true;
            this.btCompetencia.Visible = false;
            this.btCompetencia.Click += new System.EventHandler(this.btCompetencia_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(977, 427);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 20);
            this.label5.TabIndex = 96;
            this.label5.Text = "Club0:";
            // 
            // txtGarantias4
            // 
            this.txtGarantias4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtGarantias4.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtGarantias4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGarantias4.Location = new System.Drawing.Point(1029, 521);
            this.txtGarantias4.Name = "txtGarantias4";
            this.txtGarantias4.ReadOnly = true;
            this.txtGarantias4.Size = new System.Drawing.Size(180, 24);
            this.txtGarantias4.TabIndex = 107;
            this.txtGarantias4.TabStop = false;
            // 
            // pnlSeleccionMateriales
            // 
            this.pnlSeleccionMateriales.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlSeleccionMateriales.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSeleccionMateriales.Controls.Add(this.labelGradient1);
            this.pnlSeleccionMateriales.Controls.Add(this.cBoxCampanyas);
            this.pnlSeleccionMateriales.Controls.Add(this.lblCliente);
            this.pnlSeleccionMateriales.Controls.Add(this.btnBuscarMaterial);
            this.pnlSeleccionMateriales.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlSeleccionMateriales.Location = new System.Drawing.Point(329, 443);
            this.pnlSeleccionMateriales.Name = "pnlSeleccionMateriales";
            this.pnlSeleccionMateriales.Size = new System.Drawing.Size(630, 102);
            this.pnlSeleccionMateriales.TabIndex = 92;
            // 
            // labelGradient1
            // 
            this.labelGradient1.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelGradient1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGradient1.ForeColor = System.Drawing.Color.White;
            this.labelGradient1.GradientColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.labelGradient1.GradientColorTwo = System.Drawing.Color.White;
            this.labelGradient1.Location = new System.Drawing.Point(0, 0);
            this.labelGradient1.Name = "labelGradient1";
            this.labelGradient1.Size = new System.Drawing.Size(628, 18);
            this.labelGradient1.TabIndex = 87;
            this.labelGradient1.Text = "Selección de materiales";
            this.labelGradient1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cBoxCampanyas
            // 
            this.cBoxCampanyas.BackColor = System.Drawing.Color.White;
            this.cBoxCampanyas.DataSource = this.listaCampanyasBindingSource;
            this.cBoxCampanyas.DisplayMember = "NombreCampanya";
            this.cBoxCampanyas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxCampanyas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cBoxCampanyas.ForeColor = System.Drawing.Color.Black;
            this.cBoxCampanyas.Location = new System.Drawing.Point(16, 46);
            this.cBoxCampanyas.Name = "cBoxCampanyas";
            this.cBoxCampanyas.Size = new System.Drawing.Size(488, 28);
            this.cBoxCampanyas.TabIndex = 1;
            this.cBoxCampanyas.ValueMember = "idCampanya";
            // 
            // listaCampanyasBindingSource
            // 
            this.listaCampanyasBindingSource.DataMember = "ListaCampanyas";
            this.listaCampanyasBindingSource.DataSource = this.dsFormularios1;
            // 
            // dsFormularios1
            // 
            this.dsFormularios1.DataSetName = "dsFormularios";
            this.dsFormularios1.Locale = new System.Globalization.CultureInfo("es-ES");
            this.dsFormularios1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lblCliente
            // 
            this.lblCliente.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCliente.ForeColor = System.Drawing.Color.Black;
            this.lblCliente.Location = new System.Drawing.Point(13, 22);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(107, 21);
            this.lblCliente.TabIndex = 52;
            this.lblCliente.Text = "Campaña:";
            // 
            // btnBuscarMaterial
            // 
            this.btnBuscarMaterial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnBuscarMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarMaterial.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscarMaterial.Image")));
            this.btnBuscarMaterial.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscarMaterial.Location = new System.Drawing.Point(518, 42);
            this.btnBuscarMaterial.Name = "btnBuscarMaterial";
            this.btnBuscarMaterial.Size = new System.Drawing.Size(90, 36);
            this.btnBuscarMaterial.TabIndex = 11;
            this.btnBuscarMaterial.TabStop = false;
            this.btnBuscarMaterial.Text = "&Buscar";
            this.btnBuscarMaterial.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscarMaterial.UseVisualStyleBackColor = true;
            this.btnBuscarMaterial.Click += new System.EventHandler(this.btnBuscarMaterial_Click);
            // 
            // txtGarantias3
            // 
            this.txtGarantias3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtGarantias3.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtGarantias3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGarantias3.Location = new System.Drawing.Point(1029, 497);
            this.txtGarantias3.Name = "txtGarantias3";
            this.txtGarantias3.ReadOnly = true;
            this.txtGarantias3.Size = new System.Drawing.Size(180, 24);
            this.txtGarantias3.TabIndex = 106;
            this.txtGarantias3.TabStop = false;
            // 
            // txbMargenNF
            // 
            this.txbMargenNF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txbMargenNF.Cursor = System.Windows.Forms.Cursors.Default;
            this.txbMargenNF.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbMargenNF.Location = new System.Drawing.Point(603, 394);
            this.txbMargenNF.Margin = new System.Windows.Forms.Padding(2);
            this.txbMargenNF.Name = "txbMargenNF";
            this.txbMargenNF.ReadOnly = true;
            this.txbMargenNF.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txbMargenNF.Size = new System.Drawing.Size(97, 26);
            this.txbMargenNF.TabIndex = 182;
            this.txbMargenNF.TabStop = false;
            this.txbMargenNF.Text = "0 €";
            // 
            // label41
            // 
            this.label41.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label41.ForeColor = System.Drawing.Color.Red;
            this.label41.Location = new System.Drawing.Point(490, 387);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(109, 50);
            this.label41.TabIndex = 181;
            this.label41.Text = "Margen No Financiado:";
            this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtGarantias1
            // 
            this.txtGarantias1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtGarantias1.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtGarantias1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGarantias1.Location = new System.Drawing.Point(1029, 449);
            this.txtGarantias1.Name = "txtGarantias1";
            this.txtGarantias1.ReadOnly = true;
            this.txtGarantias1.Size = new System.Drawing.Size(180, 24);
            this.txtGarantias1.TabIndex = 104;
            this.txtGarantias1.TabStop = false;
            // 
            // txbDescFacturaNF
            // 
            this.txbDescFacturaNF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txbDescFacturaNF.Cursor = System.Windows.Forms.Cursors.Default;
            this.txbDescFacturaNF.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbDescFacturaNF.Location = new System.Drawing.Point(840, 368);
            this.txbDescFacturaNF.Margin = new System.Windows.Forms.Padding(2);
            this.txbDescFacturaNF.Name = "txbDescFacturaNF";
            this.txbDescFacturaNF.ReadOnly = true;
            this.txbDescFacturaNF.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txbDescFacturaNF.Size = new System.Drawing.Size(98, 26);
            this.txbDescFacturaNF.TabIndex = 180;
            this.txbDescFacturaNF.TabStop = false;
            this.txbDescFacturaNF.Text = "0 €";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(978, 522);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(54, 20);
            this.label12.TabIndex = 103;
            this.label12.Text = "Club4:";
            // 
            // txbDescFacturaF
            // 
            this.txbDescFacturaF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txbDescFacturaF.Cursor = System.Windows.Forms.Cursors.Default;
            this.txbDescFacturaF.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbDescFacturaF.Location = new System.Drawing.Point(840, 342);
            this.txbDescFacturaF.Margin = new System.Windows.Forms.Padding(2);
            this.txbDescFacturaF.Name = "txbDescFacturaF";
            this.txbDescFacturaF.ReadOnly = true;
            this.txbDescFacturaF.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txbDescFacturaF.Size = new System.Drawing.Size(98, 26);
            this.txbDescFacturaF.TabIndex = 179;
            this.txbDescFacturaF.TabStop = false;
            this.txbDescFacturaF.Text = "0 €";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(977, 451);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 20);
            this.label7.TabIndex = 100;
            this.label7.Text = "Club1:";
            // 
            // label38
            // 
            this.label38.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label38.ForeColor = System.Drawing.Color.Red;
            this.label38.Location = new System.Drawing.Point(725, 343);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(108, 20);
            this.label38.TabIndex = 178;
            this.label38.Text = "Financiado:";
            this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(977, 499);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(54, 20);
            this.label11.TabIndex = 102;
            this.label11.Text = "Club3:";
            // 
            // label1
            // 
            this.label1.Enabled = false;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(1257, 395);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 26);
            this.label1.TabIndex = 93;
            this.label1.Text = "Total Desc. medio:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(978, 475);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 20);
            this.label8.TabIndex = 101;
            this.label8.Text = "Club2:";
            // 
            // label39
            // 
            this.label39.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label39.ForeColor = System.Drawing.Color.Red;
            this.label39.Location = new System.Drawing.Point(725, 368);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(113, 20);
            this.label39.TabIndex = 177;
            this.label39.Text = "No Financi.:";
            this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label40
            // 
            this.label40.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label40.ForeColor = System.Drawing.Color.DarkBlue;
            this.label40.Location = new System.Drawing.Point(724, 317);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(214, 22);
            this.label40.TabIndex = 176;
            this.label40.Text = "Descuento factura";
            this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txbDtoMedioNF
            // 
            this.txbDtoMedioNF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txbDtoMedioNF.Cursor = System.Windows.Forms.Cursors.Default;
            this.txbDtoMedioNF.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbDtoMedioNF.Location = new System.Drawing.Point(603, 368);
            this.txbDtoMedioNF.Margin = new System.Windows.Forms.Padding(2);
            this.txbDtoMedioNF.Name = "txbDtoMedioNF";
            this.txbDtoMedioNF.ReadOnly = true;
            this.txbDtoMedioNF.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txbDtoMedioNF.Size = new System.Drawing.Size(97, 26);
            this.txbDtoMedioNF.TabIndex = 175;
            this.txbDtoMedioNF.TabStop = false;
            this.txbDtoMedioNF.Text = "0 €";
            // 
            // txbDtoMedioF
            // 
            this.txbDtoMedioF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txbDtoMedioF.Cursor = System.Windows.Forms.Cursors.Default;
            this.txbDtoMedioF.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbDtoMedioF.Location = new System.Drawing.Point(603, 342);
            this.txbDtoMedioF.Margin = new System.Windows.Forms.Padding(2);
            this.txbDtoMedioF.Name = "txbDtoMedioF";
            this.txbDtoMedioF.ReadOnly = true;
            this.txbDtoMedioF.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txbDtoMedioF.Size = new System.Drawing.Size(97, 26);
            this.txbDtoMedioF.TabIndex = 174;
            this.txbDtoMedioF.TabStop = false;
            this.txbDtoMedioF.Text = "0 €";
            // 
            // txbDto
            // 
            this.txbDto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txbDto.Cursor = System.Windows.Forms.Cursors.Default;
            this.txbDto.Enabled = false;
            this.txbDto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbDto.Location = new System.Drawing.Point(1403, 394);
            this.txbDto.Margin = new System.Windows.Forms.Padding(2);
            this.txbDto.Name = "txbDto";
            this.txbDto.ReadOnly = true;
            this.txbDto.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txbDto.Size = new System.Drawing.Size(72, 26);
            this.txbDto.TabIndex = 84;
            this.txbDto.TabStop = false;
            this.txbDto.Text = "0%";
            // 
            // label35
            // 
            this.label35.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label35.ForeColor = System.Drawing.Color.Red;
            this.label35.Location = new System.Drawing.Point(490, 343);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(104, 20);
            this.label35.TabIndex = 173;
            this.label35.Text = "Financiado:";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblImporteBruto
            // 
            this.lblImporteBruto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImporteBruto.ForeColor = System.Drawing.Color.Red;
            this.lblImporteBruto.Location = new System.Drawing.Point(37, 394);
            this.lblImporteBruto.Name = "lblImporteBruto";
            this.lblImporteBruto.Size = new System.Drawing.Size(108, 20);
            this.lblImporteBruto.TabIndex = 42;
            this.lblImporteBruto.Text = "Total Bruto:";
            this.lblImporteBruto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label36
            // 
            this.label36.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.ForeColor = System.Drawing.Color.Red;
            this.label36.Location = new System.Drawing.Point(490, 368);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(106, 20);
            this.label36.TabIndex = 172;
            this.label36.Text = "No Financi.:";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txbImporteBruto
            // 
            this.txbImporteBruto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txbImporteBruto.Cursor = System.Windows.Forms.Cursors.Default;
            this.txbImporteBruto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbImporteBruto.Location = new System.Drawing.Point(150, 394);
            this.txbImporteBruto.Margin = new System.Windows.Forms.Padding(2);
            this.txbImporteBruto.Name = "txbImporteBruto";
            this.txbImporteBruto.ReadOnly = true;
            this.txbImporteBruto.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txbImporteBruto.Size = new System.Drawing.Size(97, 26);
            this.txbImporteBruto.TabIndex = 97;
            this.txbImporteBruto.TabStop = false;
            this.txbImporteBruto.Text = "0 €";
            this.txbImporteBruto.TextChanged += new System.EventHandler(this.txbImporteBruto_TextChanged);
            this.txbImporteBruto.MouseEnter += new System.EventHandler(this.txbImporteBruto_MouseEnter);
            this.txbImporteBruto.MouseLeave += new System.EventHandler(this.txbImporteBruto_MouseLeave);
            // 
            // lblImporte
            // 
            this.lblImporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImporte.ForeColor = System.Drawing.Color.Red;
            this.lblImporte.Location = new System.Drawing.Point(267, 394);
            this.lblImporte.Name = "lblImporte";
            this.lblImporte.Size = new System.Drawing.Size(104, 20);
            this.lblImporte.TabIndex = 42;
            this.lblImporte.Text = "Total Neto:";
            this.lblImporte.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label37
            // 
            this.label37.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label37.ForeColor = System.Drawing.Color.DarkBlue;
            this.label37.Location = new System.Drawing.Point(489, 317);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(184, 22);
            this.label37.TabIndex = 171;
            this.label37.Text = "Descuento medio";
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txbImporteBrutoNF
            // 
            this.txbImporteBrutoNF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txbImporteBrutoNF.Cursor = System.Windows.Forms.Cursors.Default;
            this.txbImporteBrutoNF.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbImporteBrutoNF.Location = new System.Drawing.Point(150, 368);
            this.txbImporteBrutoNF.Margin = new System.Windows.Forms.Padding(2);
            this.txbImporteBrutoNF.Name = "txbImporteBrutoNF";
            this.txbImporteBrutoNF.ReadOnly = true;
            this.txbImporteBrutoNF.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txbImporteBrutoNF.Size = new System.Drawing.Size(97, 26);
            this.txbImporteBrutoNF.TabIndex = 170;
            this.txbImporteBrutoNF.TabStop = false;
            this.txbImporteBrutoNF.Text = "0 €";
            // 
            // txbImporte
            // 
            this.txbImporte.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txbImporte.Cursor = System.Windows.Forms.Cursors.Default;
            this.txbImporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbImporte.Location = new System.Drawing.Point(375, 394);
            this.txbImporte.Margin = new System.Windows.Forms.Padding(2);
            this.txbImporte.Name = "txbImporte";
            this.txbImporte.ReadOnly = true;
            this.txbImporte.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txbImporte.Size = new System.Drawing.Size(97, 26);
            this.txbImporte.TabIndex = 81;
            this.txbImporte.TabStop = false;
            this.txbImporte.Text = "0 €";
            this.txbImporte.MouseEnter += new System.EventHandler(this.txbImporte_MouseEnter);
            this.txbImporte.MouseLeave += new System.EventHandler(this.txbImporte_MouseLeave);
            // 
            // txbImporteBrutoF
            // 
            this.txbImporteBrutoF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txbImporteBrutoF.Cursor = System.Windows.Forms.Cursors.Default;
            this.txbImporteBrutoF.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbImporteBrutoF.Location = new System.Drawing.Point(150, 342);
            this.txbImporteBrutoF.Margin = new System.Windows.Forms.Padding(2);
            this.txbImporteBrutoF.Name = "txbImporteBrutoF";
            this.txbImporteBrutoF.ReadOnly = true;
            this.txbImporteBrutoF.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txbImporteBrutoF.Size = new System.Drawing.Size(97, 26);
            this.txbImporteBrutoF.TabIndex = 169;
            this.txbImporteBrutoF.TabStop = false;
            this.txbImporteBrutoF.Text = "0 €";
            // 
            // label31
            // 
            this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.ForeColor = System.Drawing.Color.Red;
            this.label31.Location = new System.Drawing.Point(269, 343);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(104, 20);
            this.label31.TabIndex = 168;
            this.label31.Text = "Financiado:";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label32
            // 
            this.label32.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.ForeColor = System.Drawing.Color.Red;
            this.label32.Location = new System.Drawing.Point(269, 368);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(104, 20);
            this.label32.TabIndex = 167;
            this.label32.Text = "No Financi.:";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label34
            // 
            this.label34.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.ForeColor = System.Drawing.Color.DarkBlue;
            this.label34.Location = new System.Drawing.Point(36, 317);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(135, 22);
            this.label34.TabIndex = 166;
            this.label34.Text = "Importe bruto";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txbImporteNetoNF
            // 
            this.txbImporteNetoNF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txbImporteNetoNF.Cursor = System.Windows.Forms.Cursors.Default;
            this.txbImporteNetoNF.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbImporteNetoNF.Location = new System.Drawing.Point(375, 368);
            this.txbImporteNetoNF.Margin = new System.Windows.Forms.Padding(2);
            this.txbImporteNetoNF.Name = "txbImporteNetoNF";
            this.txbImporteNetoNF.ReadOnly = true;
            this.txbImporteNetoNF.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txbImporteNetoNF.Size = new System.Drawing.Size(97, 26);
            this.txbImporteNetoNF.TabIndex = 165;
            this.txbImporteNetoNF.TabStop = false;
            this.txbImporteNetoNF.Text = "0 €";
            // 
            // txbImporteNetoF
            // 
            this.txbImporteNetoF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txbImporteNetoF.Cursor = System.Windows.Forms.Cursors.Default;
            this.txbImporteNetoF.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbImporteNetoF.Location = new System.Drawing.Point(375, 342);
            this.txbImporteNetoF.Margin = new System.Windows.Forms.Padding(2);
            this.txbImporteNetoF.Name = "txbImporteNetoF";
            this.txbImporteNetoF.ReadOnly = true;
            this.txbImporteNetoF.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txbImporteNetoF.Size = new System.Drawing.Size(97, 26);
            this.txbImporteNetoF.TabIndex = 164;
            this.txbImporteNetoF.TabStop = false;
            this.txbImporteNetoF.Text = "0 €";
            // 
            // label33
            // 
            this.label33.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.ForeColor = System.Drawing.Color.Red;
            this.label33.Location = new System.Drawing.Point(38, 343);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(107, 20);
            this.label33.TabIndex = 163;
            this.label33.Text = "Financiado:";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label30
            // 
            this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.ForeColor = System.Drawing.Color.Red;
            this.label30.Location = new System.Drawing.Point(38, 368);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(115, 20);
            this.label30.TabIndex = 160;
            this.label30.Text = "No Financi.:";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label29
            // 
            this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.ForeColor = System.Drawing.Color.DarkBlue;
            this.label29.Location = new System.Drawing.Point(268, 317);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(135, 22);
            this.label29.TabIndex = 159;
            this.label29.Text = "Importe neto";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txbMargen
            // 
            this.txbMargen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txbMargen.Cursor = System.Windows.Forms.Cursors.Default;
            this.txbMargen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbMargen.Location = new System.Drawing.Point(1381, 368);
            this.txbMargen.Margin = new System.Windows.Forms.Padding(2);
            this.txbMargen.Name = "txbMargen";
            this.txbMargen.ReadOnly = true;
            this.txbMargen.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txbMargen.Size = new System.Drawing.Size(94, 26);
            this.txbMargen.TabIndex = 158;
            this.txbMargen.TabStop = false;
            this.txbMargen.Text = "0 €";
            // 
            // lblMargen
            // 
            this.lblMargen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMargen.ForeColor = System.Drawing.Color.Red;
            this.lblMargen.Location = new System.Drawing.Point(1267, 368);
            this.lblMargen.Name = "lblMargen";
            this.lblMargen.Size = new System.Drawing.Size(77, 20);
            this.lblMargen.TabIndex = 157;
            this.lblMargen.Text = "Margen:";
            this.lblMargen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txbPVPIVA
            // 
            this.txbPVPIVA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txbPVPIVA.Cursor = System.Windows.Forms.Cursors.Default;
            this.txbPVPIVA.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbPVPIVA.Location = new System.Drawing.Point(1146, 393);
            this.txbPVPIVA.Margin = new System.Windows.Forms.Padding(2);
            this.txbPVPIVA.Name = "txbPVPIVA";
            this.txbPVPIVA.ReadOnly = true;
            this.txbPVPIVA.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txbPVPIVA.Size = new System.Drawing.Size(97, 26);
            this.txbPVPIVA.TabIndex = 156;
            this.txbPVPIVA.TabStop = false;
            this.txbPVPIVA.Text = "0 €";
            this.txbPVPIVA.TextChanged += new System.EventHandler(this.txbPVPIVA_TextChanged);
            // 
            // txbPVP
            // 
            this.txbPVP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txbPVP.Cursor = System.Windows.Forms.Cursors.Default;
            this.txbPVP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbPVP.Location = new System.Drawing.Point(841, 393);
            this.txbPVP.Margin = new System.Windows.Forms.Padding(2);
            this.txbPVP.Name = "txbPVP";
            this.txbPVP.ReadOnly = true;
            this.txbPVP.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txbPVP.Size = new System.Drawing.Size(97, 26);
            this.txbPVP.TabIndex = 155;
            this.txbPVP.TabStop = false;
            this.txbPVP.Text = "0 €";
            // 
            // lblPVPIVA
            // 
            this.lblPVPIVA.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPVPIVA.ForeColor = System.Drawing.Color.Red;
            this.lblPVPIVA.Location = new System.Drawing.Point(961, 393);
            this.lblPVPIVA.Name = "lblPVPIVA";
            this.lblPVPIVA.Size = new System.Drawing.Size(165, 20);
            this.lblPVPIVA.TabIndex = 154;
            this.lblPVPIVA.Text = "PVP IVA Pedido:";
            this.lblPVPIVA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPVP
            // 
            this.lblPVP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPVP.ForeColor = System.Drawing.Color.Red;
            this.lblPVP.Location = new System.Drawing.Point(725, 393);
            this.lblPVP.Name = "lblPVP";
            this.lblPVP.Size = new System.Drawing.Size(113, 20);
            this.lblPVP.TabIndex = 153;
            this.lblPVP.Text = "PVP Pedido:";
            this.lblPVP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(1267, 343);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(125, 20);
            this.label9.TabIndex = 88;
            this.label9.Text = "Rentabilidad:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txbDescExtraRestante
            // 
            this.txbDescExtraRestante.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txbDescExtraRestante.Cursor = System.Windows.Forms.Cursors.Default;
            this.txbDescExtraRestante.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbDescExtraRestante.Location = new System.Drawing.Point(1146, 368);
            this.txbDescExtraRestante.Margin = new System.Windows.Forms.Padding(2);
            this.txbDescExtraRestante.Name = "txbDescExtraRestante";
            this.txbDescExtraRestante.ReadOnly = true;
            this.txbDescExtraRestante.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txbDescExtraRestante.Size = new System.Drawing.Size(97, 26);
            this.txbDescExtraRestante.TabIndex = 101;
            this.txbDescExtraRestante.TabStop = false;
            this.txbDescExtraRestante.Text = "0";
            this.txbDescExtraRestante.TextChanged += new System.EventHandler(this.txbDescExtraRestante_TextChanged);
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Red;
            this.label14.Location = new System.Drawing.Point(960, 369);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(197, 20);
            this.label14.TabIndex = 100;
            this.label14.Text = "Desc. Extra Restante:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txbDescExtra
            // 
            this.txbDescExtra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txbDescExtra.Cursor = System.Windows.Forms.Cursors.Default;
            this.txbDescExtra.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbDescExtra.Location = new System.Drawing.Point(1146, 342);
            this.txbDescExtra.Margin = new System.Windows.Forms.Padding(2);
            this.txbDescExtra.Name = "txbDescExtra";
            this.txbDescExtra.ReadOnly = true;
            this.txbDescExtra.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txbDescExtra.Size = new System.Drawing.Size(97, 26);
            this.txbDescExtra.TabIndex = 99;
            this.txbDescExtra.TabStop = false;
            this.txbDescExtra.Text = "0";
            this.txbDescExtra.TextChanged += new System.EventHandler(this.txbDescExtra_TextChanged);
            // 
            // txbRentabilidad
            // 
            this.txbRentabilidad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txbRentabilidad.Cursor = System.Windows.Forms.Cursors.Default;
            this.txbRentabilidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbRentabilidad.ForeColor = System.Drawing.Color.White;
            this.txbRentabilidad.Location = new System.Drawing.Point(1414, 342);
            this.txbRentabilidad.Margin = new System.Windows.Forms.Padding(2);
            this.txbRentabilidad.Name = "txbRentabilidad";
            this.txbRentabilidad.ReadOnly = true;
            this.txbRentabilidad.Size = new System.Drawing.Size(61, 26);
            this.txbRentabilidad.TabIndex = 89;
            this.txbRentabilidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(961, 343);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(170, 20);
            this.label13.TabIndex = 98;
            this.label13.Text = "Desc. Extra Total:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtRentabilidad
            // 
            this.txtRentabilidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRentabilidad.Location = new System.Drawing.Point(1119, 322);
            this.txtRentabilidad.Name = "txtRentabilidad";
            this.txtRentabilidad.Size = new System.Drawing.Size(10, 26);
            this.txtRentabilidad.TabIndex = 91;
            this.txtRentabilidad.Visible = false;
            // 
            // tabPageAccMark
            // 
            this.tabPageAccMark.Controls.Add(this.panel3);
            this.tabPageAccMark.Location = new System.Drawing.Point(4, 29);
            this.tabPageAccMark.Name = "tabPageAccMark";
            this.tabPageAccMark.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAccMark.Size = new System.Drawing.Size(1484, 554);
            this.tabPageAccMark.TabIndex = 1;
            this.tabPageAccMark.Text = "Acciones de Marketing";
            this.tabPageAccMark.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.lblNumReg);
            this.panel3.Controls.Add(this.labelGradientAccMark);
            this.panel3.Controls.Add(this.dataGridViewAccMark);
            this.panel3.Location = new System.Drawing.Point(7, 6);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1471, 343);
            this.panel3.TabIndex = 96;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.txtbPuntosPedConAM);
            this.panel4.Controls.Add(this.label47);
            this.panel4.Controls.Add(this.txtbPuntosPedAM);
            this.panel4.Controls.Add(this.label26);
            this.panel4.Controls.Add(this.lblMissAM);
            this.panel4.Controls.Add(this.txtbCosteTotalAM);
            this.panel4.Controls.Add(this.label44);
            this.panel4.Controls.Add(this.txtbRentabilidadAM);
            this.panel4.Controls.Add(this.label43);
            this.panel4.Controls.Add(this.label42);
            this.panel4.Controls.Add(this.txtbDescMedioAM);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.txtbBrutoPedAM);
            this.panel4.Location = new System.Drawing.Point(797, 22);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(510, 301);
            this.panel4.TabIndex = 96;
            // 
            // txtbPuntosPedConAM
            // 
            this.txtbPuntosPedConAM.BackColor = System.Drawing.Color.White;
            this.txtbPuntosPedConAM.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtbPuntosPedConAM.Enabled = false;
            this.txtbPuntosPedConAM.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbPuntosPedConAM.Location = new System.Drawing.Point(362, 169);
            this.txtbPuntosPedConAM.Margin = new System.Windows.Forms.Padding(2);
            this.txtbPuntosPedConAM.Name = "txtbPuntosPedConAM";
            this.txtbPuntosPedConAM.ReadOnly = true;
            this.txtbPuntosPedConAM.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtbPuntosPedConAM.Size = new System.Drawing.Size(97, 23);
            this.txtbPuntosPedConAM.TabIndex = 111;
            this.txtbPuntosPedConAM.TabStop = false;
            this.txtbPuntosPedConAM.Text = "0";
            // 
            // label47
            // 
            this.label47.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label47.ForeColor = System.Drawing.Color.DarkRed;
            this.label47.Location = new System.Drawing.Point(49, 170);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(310, 20);
            this.label47.TabIndex = 110;
            this.label47.Text = "Puntos con Acciones de Marketing:";
            this.label47.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtbPuntosPedAM
            // 
            this.txtbPuntosPedAM.BackColor = System.Drawing.Color.White;
            this.txtbPuntosPedAM.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtbPuntosPedAM.Enabled = false;
            this.txtbPuntosPedAM.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbPuntosPedAM.Location = new System.Drawing.Point(362, 79);
            this.txtbPuntosPedAM.Margin = new System.Windows.Forms.Padding(2);
            this.txtbPuntosPedAM.Name = "txtbPuntosPedAM";
            this.txtbPuntosPedAM.ReadOnly = true;
            this.txtbPuntosPedAM.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtbPuntosPedAM.Size = new System.Drawing.Size(97, 23);
            this.txtbPuntosPedAM.TabIndex = 109;
            this.txtbPuntosPedAM.TabStop = false;
            this.txtbPuntosPedAM.Text = "0";
            // 
            // label26
            // 
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.Black;
            this.label26.Location = new System.Drawing.Point(49, 81);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(310, 20);
            this.label26.TabIndex = 108;
            this.label26.Text = "Total Puntos Pedido:";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMissAM
            // 
            this.lblMissAM.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMissAM.ForeColor = System.Drawing.Color.Red;
            this.lblMissAM.Location = new System.Drawing.Point(57, 197);
            this.lblMissAM.Margin = new System.Windows.Forms.Padding(0);
            this.lblMissAM.Name = "lblMissAM";
            this.lblMissAM.Size = new System.Drawing.Size(402, 100);
            this.lblMissAM.TabIndex = 107;
            this.lblMissAM.Text = "miss";
            this.lblMissAM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtbCosteTotalAM
            // 
            this.txtbCosteTotalAM.BackColor = System.Drawing.Color.White;
            this.txtbCosteTotalAM.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtbCosteTotalAM.Enabled = false;
            this.txtbCosteTotalAM.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbCosteTotalAM.Location = new System.Drawing.Point(362, 109);
            this.txtbCosteTotalAM.Margin = new System.Windows.Forms.Padding(2);
            this.txtbCosteTotalAM.Name = "txtbCosteTotalAM";
            this.txtbCosteTotalAM.ReadOnly = true;
            this.txtbCosteTotalAM.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtbCosteTotalAM.Size = new System.Drawing.Size(97, 23);
            this.txtbCosteTotalAM.TabIndex = 105;
            this.txtbCosteTotalAM.TabStop = false;
            this.txtbCosteTotalAM.Text = "0 €";
            // 
            // label44
            // 
            this.label44.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label44.ForeColor = System.Drawing.Color.Navy;
            this.label44.Location = new System.Drawing.Point(49, 110);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(310, 20);
            this.label44.TabIndex = 104;
            this.label44.Text = "Total Coste Acciones de Marketing:";
            this.label44.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtbRentabilidadAM
            // 
            this.txtbRentabilidadAM.BackColor = System.Drawing.Color.White;
            this.txtbRentabilidadAM.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtbRentabilidadAM.Enabled = false;
            this.txtbRentabilidadAM.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbRentabilidadAM.Location = new System.Drawing.Point(362, 139);
            this.txtbRentabilidadAM.Margin = new System.Windows.Forms.Padding(2);
            this.txtbRentabilidadAM.Name = "txtbRentabilidadAM";
            this.txtbRentabilidadAM.ReadOnly = true;
            this.txtbRentabilidadAM.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtbRentabilidadAM.Size = new System.Drawing.Size(97, 23);
            this.txtbRentabilidadAM.TabIndex = 103;
            this.txtbRentabilidadAM.TabStop = false;
            // 
            // label43
            // 
            this.label43.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label43.ForeColor = System.Drawing.Color.DarkRed;
            this.label43.Location = new System.Drawing.Point(49, 139);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(310, 20);
            this.label43.TabIndex = 102;
            this.label43.Text = "Rentabilidad con Acciones de Marketing:";
            this.label43.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label42
            // 
            this.label42.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label42.ForeColor = System.Drawing.Color.Black;
            this.label42.Location = new System.Drawing.Point(49, 51);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(310, 20);
            this.label42.TabIndex = 101;
            this.label42.Text = "Total Descuento Medio Pedido:";
            this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtbDescMedioAM
            // 
            this.txtbDescMedioAM.BackColor = System.Drawing.Color.White;
            this.txtbDescMedioAM.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtbDescMedioAM.Enabled = false;
            this.txtbDescMedioAM.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbDescMedioAM.Location = new System.Drawing.Point(362, 49);
            this.txtbDescMedioAM.Margin = new System.Windows.Forms.Padding(2);
            this.txtbDescMedioAM.Name = "txtbDescMedioAM";
            this.txtbDescMedioAM.ReadOnly = true;
            this.txtbDescMedioAM.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtbDescMedioAM.Size = new System.Drawing.Size(97, 23);
            this.txtbDescMedioAM.TabIndex = 100;
            this.txtbDescMedioAM.TabStop = false;
            this.txtbDescMedioAM.Text = "0%";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(49, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(310, 20);
            this.label3.TabIndex = 98;
            this.label3.Text = "Total Bruto Pedido:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtbBrutoPedAM
            // 
            this.txtbBrutoPedAM.BackColor = System.Drawing.Color.White;
            this.txtbBrutoPedAM.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtbBrutoPedAM.Enabled = false;
            this.txtbBrutoPedAM.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbBrutoPedAM.Location = new System.Drawing.Point(362, 19);
            this.txtbBrutoPedAM.Margin = new System.Windows.Forms.Padding(2);
            this.txtbBrutoPedAM.Name = "txtbBrutoPedAM";
            this.txtbBrutoPedAM.ReadOnly = true;
            this.txtbBrutoPedAM.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtbBrutoPedAM.Size = new System.Drawing.Size(97, 23);
            this.txtbBrutoPedAM.TabIndex = 99;
            this.txtbBrutoPedAM.TabStop = false;
            this.txtbBrutoPedAM.Text = "0 €";
            // 
            // lblNumReg
            // 
            this.lblNumReg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.lblNumReg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblNumReg.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumReg.ForeColor = System.Drawing.Color.Black;
            this.lblNumReg.Location = new System.Drawing.Point(701, 3);
            this.lblNumReg.Name = "lblNumReg";
            this.lblNumReg.Size = new System.Drawing.Size(64, 18);
            this.lblNumReg.TabIndex = 95;
            this.lblNumReg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelGradientAccMark
            // 
            this.labelGradientAccMark.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGradientAccMark.ForeColor = System.Drawing.Color.White;
            this.labelGradientAccMark.GradientColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.labelGradientAccMark.GradientColorTwo = System.Drawing.Color.White;
            this.labelGradientAccMark.Location = new System.Drawing.Point(3, 3);
            this.labelGradientAccMark.Name = "labelGradientAccMark";
            this.labelGradientAccMark.Size = new System.Drawing.Size(767, 18);
            this.labelGradientAccMark.TabIndex = 93;
            this.labelGradientAccMark.Text = "Acciones de Marketing";
            this.labelGradientAccMark.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dataGridViewAccMark
            // 
            this.dataGridViewAccMark.AllowUserToAddRows = false;
            this.dataGridViewAccMark.AllowUserToDeleteRows = false;
            this.dataGridViewAccMark.AllowUserToResizeRows = false;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridViewAccMark.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle14;
            this.dataGridViewAccMark.AutoGenerateColumns = false;
            this.dataGridViewAccMark.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewAccMark.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewAccMark.ColumnHeadersHeight = 25;
            this.dataGridViewAccMark.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewAccMark.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.selected,
            this.iIdAccionDataGridViewTextBoxColumn,
            this.sIdAccionDataGridViewTextBoxColumn,
            this.sDescAccionDataGridViewTextBoxColumn,
            this.sIdTipoAccionDataGridViewTextBoxColumn,
            this.UnidadesAEntregar,
            this.iUnidades,
            this.fImpMin,
            this.fImpMax,
            this.fRentabilidad,
            this.bIndepe,
            this.iActivoPara,
            this.sIdProducto,
            this.producto,
            this.fCosteUnitarioDataGridViewTextBoxColumn,
            this.bSuma,
            this.iNumElemEntregar,
            this.fCosteTotalDataGridViewTextBoxColumn,
            this.iMaxAEntregar,
            this.dFechaCreacionDataGridViewTextBoxColumn,
            this.dFechaIniDataGridViewTextBoxColumn,
            this.dFechaFinDataGridViewTextBoxColumn,
            this.sObservacionesDataGridViewTextBoxColumn,
            this.sIdTipoImputacionDataGridViewTextBoxColumn,
            this.dFUMDataGridViewTextBoxColumn,
            this.iEstadoDataGridViewTextBoxColumn,
            this.bEnviadoPDADataGridViewCheckBoxColumn,
            this.iUnidadesDataGridViewTextBoxColumn});
            this.dataGridViewAccMark.DataMember = "ListaAccionesMarketing";
            this.dataGridViewAccMark.DataSource = this.dsAccionesMarketing1;
            this.dataGridViewAccMark.GridColor = System.Drawing.Color.White;
            this.dataGridViewAccMark.Location = new System.Drawing.Point(4, 22);
            this.dataGridViewAccMark.Name = "dataGridViewAccMark";
            this.dataGridViewAccMark.RowHeadersVisible = false;
            this.dataGridViewAccMark.RowHeadersWidth = 25;
            this.dataGridViewAccMark.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewAccMark.Size = new System.Drawing.Size(760, 318);
            this.dataGridViewAccMark.TabIndex = 94;
            this.dataGridViewAccMark.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dataGridViewAccMark_MouseUp);
            // 
            // selected
            // 
            this.selected.DataPropertyName = "selected";
            this.selected.FalseValue = "false";
            this.selected.HeaderText = "";
            this.selected.IndeterminateValue = "false";
            this.selected.MinimumWidth = 8;
            this.selected.Name = "selected";
            this.selected.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.selected.TrueValue = "true";
            this.selected.Width = 20;
            // 
            // iIdAccionDataGridViewTextBoxColumn
            // 
            this.iIdAccionDataGridViewTextBoxColumn.DataPropertyName = "iIdAccion";
            this.iIdAccionDataGridViewTextBoxColumn.HeaderText = "iIdAccion";
            this.iIdAccionDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.iIdAccionDataGridViewTextBoxColumn.Name = "iIdAccionDataGridViewTextBoxColumn";
            this.iIdAccionDataGridViewTextBoxColumn.Visible = false;
            this.iIdAccionDataGridViewTextBoxColumn.Width = 55;
            // 
            // sIdAccionDataGridViewTextBoxColumn
            // 
            this.sIdAccionDataGridViewTextBoxColumn.DataPropertyName = "sIdAccion";
            this.sIdAccionDataGridViewTextBoxColumn.HeaderText = "Codigo";
            this.sIdAccionDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.sIdAccionDataGridViewTextBoxColumn.Name = "sIdAccionDataGridViewTextBoxColumn";
            this.sIdAccionDataGridViewTextBoxColumn.ReadOnly = true;
            this.sIdAccionDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.sIdAccionDataGridViewTextBoxColumn.Visible = false;
            this.sIdAccionDataGridViewTextBoxColumn.Width = 55;
            // 
            // sDescAccionDataGridViewTextBoxColumn
            // 
            this.sDescAccionDataGridViewTextBoxColumn.DataPropertyName = "sDescAccion";
            this.sDescAccionDataGridViewTextBoxColumn.HeaderText = "Descripción";
            this.sDescAccionDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.sDescAccionDataGridViewTextBoxColumn.Name = "sDescAccionDataGridViewTextBoxColumn";
            this.sDescAccionDataGridViewTextBoxColumn.ReadOnly = true;
            this.sDescAccionDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.sDescAccionDataGridViewTextBoxColumn.Width = 300;
            // 
            // sIdTipoAccionDataGridViewTextBoxColumn
            // 
            this.sIdTipoAccionDataGridViewTextBoxColumn.DataPropertyName = "sIdTipoAccion";
            this.sIdTipoAccionDataGridViewTextBoxColumn.HeaderText = "sIdTipoAccion";
            this.sIdTipoAccionDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.sIdTipoAccionDataGridViewTextBoxColumn.Name = "sIdTipoAccionDataGridViewTextBoxColumn";
            this.sIdTipoAccionDataGridViewTextBoxColumn.Visible = false;
            this.sIdTipoAccionDataGridViewTextBoxColumn.Width = 150;
            // 
            // UnidadesAEntregar
            // 
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.UnidadesAEntregar.DefaultCellStyle = dataGridViewCellStyle15;
            this.UnidadesAEntregar.HeaderText = "Unidades";
            this.UnidadesAEntregar.MinimumWidth = 8;
            this.UnidadesAEntregar.Name = "UnidadesAEntregar";
            this.UnidadesAEntregar.ReadOnly = true;
            this.UnidadesAEntregar.Width = 60;
            // 
            // iUnidades
            // 
            this.iUnidades.DataPropertyName = "iUnidades";
            this.iUnidades.HeaderText = "Filtro Unidades";
            this.iUnidades.MinimumWidth = 8;
            this.iUnidades.Name = "iUnidades";
            this.iUnidades.ReadOnly = true;
            this.iUnidades.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.iUnidades.Visible = false;
            this.iUnidades.Width = 90;
            // 
            // fImpMin
            // 
            this.fImpMin.DataPropertyName = "fImpMin";
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.fImpMin.DefaultCellStyle = dataGridViewCellStyle16;
            this.fImpMin.HeaderText = "Min. Imp.";
            this.fImpMin.MinimumWidth = 8;
            this.fImpMin.Name = "fImpMin";
            this.fImpMin.ReadOnly = true;
            this.fImpMin.Width = 90;
            // 
            // fImpMax
            // 
            this.fImpMax.DataPropertyName = "fImpMax";
            this.fImpMax.HeaderText = "Filtro Max. Imp";
            this.fImpMax.MinimumWidth = 8;
            this.fImpMax.Name = "fImpMax";
            this.fImpMax.ReadOnly = true;
            this.fImpMax.Visible = false;
            this.fImpMax.Width = 90;
            // 
            // fRentabilidad
            // 
            this.fRentabilidad.DataPropertyName = "fRentabilidad";
            this.fRentabilidad.HeaderText = "Filtro Rentabilidad";
            this.fRentabilidad.MinimumWidth = 8;
            this.fRentabilidad.Name = "fRentabilidad";
            this.fRentabilidad.ReadOnly = true;
            this.fRentabilidad.Visible = false;
            this.fRentabilidad.Width = 150;
            // 
            // bIndepe
            // 
            this.bIndepe.DataPropertyName = "bIndepe";
            this.bIndepe.HeaderText = "Filtro Indepe";
            this.bIndepe.MinimumWidth = 8;
            this.bIndepe.Name = "bIndepe";
            this.bIndepe.ReadOnly = true;
            this.bIndepe.Visible = false;
            this.bIndepe.Width = 80;
            // 
            // iActivoPara
            // 
            this.iActivoPara.DataPropertyName = "iActivoPara";
            this.iActivoPara.HeaderText = "Filtro ActivoPara";
            this.iActivoPara.MinimumWidth = 8;
            this.iActivoPara.Name = "iActivoPara";
            this.iActivoPara.Visible = false;
            this.iActivoPara.Width = 90;
            // 
            // sIdProducto
            // 
            this.sIdProducto.DataPropertyName = "sIdProducto";
            this.sIdProducto.HeaderText = "Producto asociado";
            this.sIdProducto.MinimumWidth = 8;
            this.sIdProducto.Name = "sIdProducto";
            this.sIdProducto.Visible = false;
            this.sIdProducto.Width = 80;
            // 
            // producto
            // 
            this.producto.DataPropertyName = "producto";
            this.producto.HeaderText = "Producto";
            this.producto.MinimumWidth = 8;
            this.producto.Name = "producto";
            this.producto.Width = 200;
            // 
            // fCosteUnitarioDataGridViewTextBoxColumn
            // 
            this.fCosteUnitarioDataGridViewTextBoxColumn.DataPropertyName = "fCosteUnitario";
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.fCosteUnitarioDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle17;
            this.fCosteUnitarioDataGridViewTextBoxColumn.HeaderText = "Coste";
            this.fCosteUnitarioDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.fCosteUnitarioDataGridViewTextBoxColumn.Name = "fCosteUnitarioDataGridViewTextBoxColumn";
            this.fCosteUnitarioDataGridViewTextBoxColumn.ReadOnly = true;
            this.fCosteUnitarioDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.fCosteUnitarioDataGridViewTextBoxColumn.Width = 60;
            // 
            // bSuma
            // 
            this.bSuma.DataPropertyName = "bSuma";
            this.bSuma.HeaderText = "Suma";
            this.bSuma.MinimumWidth = 8;
            this.bSuma.Name = "bSuma";
            this.bSuma.ReadOnly = true;
            this.bSuma.Visible = false;
            this.bSuma.Width = 80;
            // 
            // iNumElemEntregar
            // 
            this.iNumElemEntregar.DataPropertyName = "iNumElemEntregar";
            this.iNumElemEntregar.HeaderText = "Unid. acc.";
            this.iNumElemEntregar.MinimumWidth = 8;
            this.iNumElemEntregar.Name = "iNumElemEntregar";
            this.iNumElemEntregar.Visible = false;
            this.iNumElemEntregar.Width = 60;
            // 
            // fCosteTotalDataGridViewTextBoxColumn
            // 
            this.fCosteTotalDataGridViewTextBoxColumn.DataPropertyName = "fCosteTotal";
            this.fCosteTotalDataGridViewTextBoxColumn.HeaderText = "fCosteTotal";
            this.fCosteTotalDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.fCosteTotalDataGridViewTextBoxColumn.Name = "fCosteTotalDataGridViewTextBoxColumn";
            this.fCosteTotalDataGridViewTextBoxColumn.ReadOnly = true;
            this.fCosteTotalDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.fCosteTotalDataGridViewTextBoxColumn.Visible = false;
            this.fCosteTotalDataGridViewTextBoxColumn.Width = 65;
            // 
            // iMaxAEntregar
            // 
            this.iMaxAEntregar.DataPropertyName = "iMaxAEntregar";
            this.iMaxAEntregar.HeaderText = "iMaxAEntregar";
            this.iMaxAEntregar.MinimumWidth = 8;
            this.iMaxAEntregar.Name = "iMaxAEntregar";
            this.iMaxAEntregar.ReadOnly = true;
            this.iMaxAEntregar.Visible = false;
            this.iMaxAEntregar.Width = 80;
            // 
            // dFechaCreacionDataGridViewTextBoxColumn
            // 
            this.dFechaCreacionDataGridViewTextBoxColumn.DataPropertyName = "dFechaCreacion";
            this.dFechaCreacionDataGridViewTextBoxColumn.HeaderText = "dFechaCreacion";
            this.dFechaCreacionDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.dFechaCreacionDataGridViewTextBoxColumn.Name = "dFechaCreacionDataGridViewTextBoxColumn";
            this.dFechaCreacionDataGridViewTextBoxColumn.Visible = false;
            this.dFechaCreacionDataGridViewTextBoxColumn.Width = 150;
            // 
            // dFechaIniDataGridViewTextBoxColumn
            // 
            this.dFechaIniDataGridViewTextBoxColumn.DataPropertyName = "dFechaIni";
            this.dFechaIniDataGridViewTextBoxColumn.HeaderText = "dFechaIni";
            this.dFechaIniDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.dFechaIniDataGridViewTextBoxColumn.Name = "dFechaIniDataGridViewTextBoxColumn";
            this.dFechaIniDataGridViewTextBoxColumn.Visible = false;
            this.dFechaIniDataGridViewTextBoxColumn.Width = 150;
            // 
            // dFechaFinDataGridViewTextBoxColumn
            // 
            this.dFechaFinDataGridViewTextBoxColumn.DataPropertyName = "dFechaFin";
            this.dFechaFinDataGridViewTextBoxColumn.HeaderText = "dFechaFin";
            this.dFechaFinDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.dFechaFinDataGridViewTextBoxColumn.Name = "dFechaFinDataGridViewTextBoxColumn";
            this.dFechaFinDataGridViewTextBoxColumn.Visible = false;
            this.dFechaFinDataGridViewTextBoxColumn.Width = 150;
            // 
            // sObservacionesDataGridViewTextBoxColumn
            // 
            this.sObservacionesDataGridViewTextBoxColumn.DataPropertyName = "sObservaciones";
            this.sObservacionesDataGridViewTextBoxColumn.HeaderText = "sObservaciones";
            this.sObservacionesDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.sObservacionesDataGridViewTextBoxColumn.Name = "sObservacionesDataGridViewTextBoxColumn";
            this.sObservacionesDataGridViewTextBoxColumn.Visible = false;
            this.sObservacionesDataGridViewTextBoxColumn.Width = 150;
            // 
            // sIdTipoImputacionDataGridViewTextBoxColumn
            // 
            this.sIdTipoImputacionDataGridViewTextBoxColumn.DataPropertyName = "sIdTipoImputacion";
            this.sIdTipoImputacionDataGridViewTextBoxColumn.HeaderText = "sIdTipoImputacion";
            this.sIdTipoImputacionDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.sIdTipoImputacionDataGridViewTextBoxColumn.Name = "sIdTipoImputacionDataGridViewTextBoxColumn";
            this.sIdTipoImputacionDataGridViewTextBoxColumn.Visible = false;
            this.sIdTipoImputacionDataGridViewTextBoxColumn.Width = 150;
            // 
            // dFUMDataGridViewTextBoxColumn
            // 
            this.dFUMDataGridViewTextBoxColumn.DataPropertyName = "dFUM";
            this.dFUMDataGridViewTextBoxColumn.HeaderText = "dFUM";
            this.dFUMDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.dFUMDataGridViewTextBoxColumn.Name = "dFUMDataGridViewTextBoxColumn";
            this.dFUMDataGridViewTextBoxColumn.Visible = false;
            this.dFUMDataGridViewTextBoxColumn.Width = 150;
            // 
            // iEstadoDataGridViewTextBoxColumn
            // 
            this.iEstadoDataGridViewTextBoxColumn.DataPropertyName = "iEstado";
            this.iEstadoDataGridViewTextBoxColumn.HeaderText = "iEstado";
            this.iEstadoDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.iEstadoDataGridViewTextBoxColumn.Name = "iEstadoDataGridViewTextBoxColumn";
            this.iEstadoDataGridViewTextBoxColumn.Visible = false;
            this.iEstadoDataGridViewTextBoxColumn.Width = 150;
            // 
            // bEnviadoPDADataGridViewCheckBoxColumn
            // 
            this.bEnviadoPDADataGridViewCheckBoxColumn.DataPropertyName = "bEnviadoPDA";
            this.bEnviadoPDADataGridViewCheckBoxColumn.HeaderText = "bEnviadoPDA";
            this.bEnviadoPDADataGridViewCheckBoxColumn.MinimumWidth = 8;
            this.bEnviadoPDADataGridViewCheckBoxColumn.Name = "bEnviadoPDADataGridViewCheckBoxColumn";
            this.bEnviadoPDADataGridViewCheckBoxColumn.Visible = false;
            this.bEnviadoPDADataGridViewCheckBoxColumn.Width = 150;
            // 
            // iUnidadesDataGridViewTextBoxColumn
            // 
            this.iUnidadesDataGridViewTextBoxColumn.DataPropertyName = "iUnidades";
            this.iUnidadesDataGridViewTextBoxColumn.HeaderText = "iUnidades";
            this.iUnidadesDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.iUnidadesDataGridViewTextBoxColumn.Name = "iUnidadesDataGridViewTextBoxColumn";
            this.iUnidadesDataGridViewTextBoxColumn.ReadOnly = true;
            this.iUnidadesDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.iUnidadesDataGridViewTextBoxColumn.Visible = false;
            this.iUnidadesDataGridViewTextBoxColumn.Width = 65;
            // 
            // dsAccionesMarketing1
            // 
            this.dsAccionesMarketing1.DataSetName = "dsAccionesMarketing";
            this.dsAccionesMarketing1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // txbDecil
            // 
            this.txbDecil.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txbDecil.Cursor = System.Windows.Forms.Cursors.Default;
            this.txbDecil.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbDecil.Location = new System.Drawing.Point(1146, 58);
            this.txbDecil.Margin = new System.Windows.Forms.Padding(2);
            this.txbDecil.Name = "txbDecil";
            this.txbDecil.ReadOnly = true;
            this.txbDecil.Size = new System.Drawing.Size(101, 21);
            this.txbDecil.TabIndex = 105;
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(1085, 56);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(63, 26);
            this.label16.TabIndex = 104;
            this.label16.Text = "Decil N:";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dvTiposPosPedidoSAP
            // 
            this.dvTiposPosPedidoSAP.AllowDelete = false;
            this.dvTiposPosPedidoSAP.AllowEdit = false;
            this.dvTiposPosPedidoSAP.AllowNew = false;
            // 
            // pnlCabeceraPedido
            // 
            this.pnlCabeceraPedido.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlCabeceraPedido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCabeceraPedido.Controls.Add(this.btGrafPuntos);
            this.pnlCabeceraPedido.Controls.Add(this.groupBox1);
            this.pnlCabeceraPedido.Controls.Add(this.cboProgInf);
            this.pnlCabeceraPedido.Controls.Add(this.label20);
            this.pnlCabeceraPedido.Controls.Add(this.pnCompromiso);
            this.pnlCabeceraPedido.Controls.Add(this.txbCodPagoFija);
            this.pnlCabeceraPedido.Controls.Add(this.lblCodPagoFija);
            this.pnlCabeceraPedido.Controls.Add(this.txbDecilP);
            this.pnlCabeceraPedido.Controls.Add(this.label28);
            this.pnlCabeceraPedido.Controls.Add(this.txbSPais);
            this.pnlCabeceraPedido.Controls.Add(this.txbSOficina);
            this.pnlCabeceraPedido.Controls.Add(this.txbSLocalidad);
            this.pnlCabeceraPedido.Controls.Add(this.txbSBanco);
            this.pnlCabeceraPedido.Controls.Add(this.label27);
            this.pnlCabeceraPedido.Controls.Add(this.txbCCAndorra);
            this.pnlCabeceraPedido.Controls.Add(this.txbIBAN);
            this.pnlCabeceraPedido.Controls.Add(this.btActRent);
            this.pnlCabeceraPedido.Controls.Add(this.label23);
            this.pnlCabeceraPedido.Controls.Add(this.txbDecil);
            this.pnlCabeceraPedido.Controls.Add(this.label16);
            this.pnlCabeceraPedido.Controls.Add(this.label24);
            this.pnlCabeceraPedido.Controls.Add(this.txbControl);
            this.pnlCabeceraPedido.Controls.Add(this.txbOficina);
            this.pnlCabeceraPedido.Controls.Add(this.txbEntidad);
            this.pnlCabeceraPedido.Controls.Add(this.txbCC);
            this.pnlCabeceraPedido.Controls.Add(this.label21);
            this.pnlCabeceraPedido.Controls.Add(this.dtpFechaFacturacion);
            this.pnlCabeceraPedido.Controls.Add(this.cboPrioridad);
            this.pnlCabeceraPedido.Controls.Add(this.lblFechaFacturacion);
            this.pnlCabeceraPedido.Controls.Add(this.label22);
            this.pnlCabeceraPedido.Controls.Add(this.cboCondicionPago);
            this.pnlCabeceraPedido.Controls.Add(this.lblCondPago);
            this.pnlCabeceraPedido.Controls.Add(this.lblAvisoVersion);
            this.pnlCabeceraPedido.Controls.Add(this.chkRetenido);
            this.pnlCabeceraPedido.Controls.Add(this.txtProgInf);
            this.pnlCabeceraPedido.Controls.Add(this.txtMailFact);
            this.pnlCabeceraPedido.Controls.Add(this.txtMailConf);
            this.pnlCabeceraPedido.Controls.Add(this.label17);
            this.pnlCabeceraPedido.Controls.Add(this.label18);
            this.pnlCabeceraPedido.Controls.Add(this.txbDtoGeneral);
            this.pnlCabeceraPedido.Controls.Add(this.lblDescGen);
            this.pnlCabeceraPedido.Controls.Add(this.txtCodPago);
            this.pnlCabeceraPedido.Controls.Add(this.label4);
            this.pnlCabeceraPedido.Controls.Add(this.txtbRentAnual);
            this.pnlCabeceraPedido.Controls.Add(this.label15);
            this.pnlCabeceraPedido.Controls.Add(this.dtpFechaVenci);
            this.pnlCabeceraPedido.Controls.Add(this.chkVisita);
            this.pnlCabeceraPedido.Controls.Add(this.cboTipoCampana);
            this.pnlCabeceraPedido.Controls.Add(this.label10);
            this.pnlCabeceraPedido.Controls.Add(this.txtEncComercial);
            this.pnlCabeceraPedido.Controls.Add(this.label6);
            this.pnlCabeceraPedido.Controls.Add(this.lblTitulo);
            this.pnlCabeceraPedido.Controls.Add(this.txtDestinatarioSAP);
            this.pnlCabeceraPedido.Controls.Add(this.txtClienteSAP);
            this.pnlCabeceraPedido.Controls.Add(this.txbObservaciones);
            this.pnlCabeceraPedido.Controls.Add(this.txtsDestinatario);
            this.pnlCabeceraPedido.Controls.Add(this.txbIdPedido);
            this.pnlCabeceraPedido.Controls.Add(this.txbDelegado);
            this.pnlCabeceraPedido.Controls.Add(this.btBuscarDestinatario);
            this.pnlCabeceraPedido.Controls.Add(this.btBuscarCliente);
            this.pnlCabeceraPedido.Controls.Add(this.txtsCliente);
            this.pnlCabeceraPedido.Controls.Add(this.dtpFechaPedido);
            this.pnlCabeceraPedido.Controls.Add(this.lblFechaPedido);
            this.pnlCabeceraPedido.Controls.Add(this.cboTipoPedido);
            this.pnlCabeceraPedido.Controls.Add(this.dtpFechaFij);
            this.pnlCabeceraPedido.Controls.Add(this.dtpFechaPref);
            this.pnlCabeceraPedido.Controls.Add(this.lblObservaciones);
            this.pnlCabeceraPedido.Controls.Add(this.lblFechaFijada);
            this.pnlCabeceraPedido.Controls.Add(this.lblFechaPref);
            this.pnlCabeceraPedido.Controls.Add(this.lblTipoPedido);
            this.pnlCabeceraPedido.Controls.Add(this.lblDelegado);
            this.pnlCabeceraPedido.Controls.Add(this.lblPedido);
            this.pnlCabeceraPedido.Controls.Add(this.lblDestinatario);
            this.pnlCabeceraPedido.Controls.Add(this.label2);
            this.pnlCabeceraPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlCabeceraPedido.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlCabeceraPedido.Location = new System.Drawing.Point(3, 38);
            this.pnlCabeceraPedido.Name = "pnlCabeceraPedido";
            this.pnlCabeceraPedido.Size = new System.Drawing.Size(1489, 168);
            this.pnlCabeceraPedido.TabIndex = 0;
            // 
            // btGrafPuntos
            // 
            this.btGrafPuntos.BackColor = System.Drawing.Color.White;
            this.btGrafPuntos.Image = global::GESTCRM.Properties.Resources.quesu;
            this.btGrafPuntos.Location = new System.Drawing.Point(1443, 126);
            this.btGrafPuntos.Name = "btGrafPuntos";
            this.btGrafPuntos.Size = new System.Drawing.Size(35, 33);
            this.btGrafPuntos.TabIndex = 164;
            this.btGrafPuntos.UseVisualStyleBackColor = false;
            this.btGrafPuntos.Click += new System.EventHandler(this.btGrafPuntos_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtImpMedio);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.txtMediaPuntos);
            this.groupBox1.Controls.Add(this.label46);
            this.groupBox1.Controls.Add(this.txtImpMedioNeto);
            this.groupBox1.Controls.Add(this.label45);
            this.groupBox1.ForeColor = System.Drawing.Color.Navy;
            this.groupBox1.Location = new System.Drawing.Point(819, 117);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(613, 48);
            this.groupBox1.TabIndex = 163;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Medias/mes en Pedidos Anteriores:";
            this.groupBox1.Visible = false;
            // 
            // txtImpMedio
            // 
            this.txtImpMedio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtImpMedio.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtImpMedio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImpMedio.Location = new System.Drawing.Point(162, 18);
            this.txtImpMedio.Name = "txtImpMedio";
            this.txtImpMedio.ReadOnly = true;
            this.txtImpMedio.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtImpMedio.Size = new System.Drawing.Size(105, 26);
            this.txtImpMedio.TabIndex = 168;
            this.txtImpMedio.TabStop = false;
            this.txtImpMedio.DoubleClick += new System.EventHandler(this.txtImpMedio_DoubleClick);
            // 
            // label19
            // 
            this.label19.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.MediumBlue;
            this.label19.Location = new System.Drawing.Point(110, 20);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(57, 20);
            this.label19.TabIndex = 167;
            this.label19.Text = "Bruto:";
            // 
            // txtMediaPuntos
            // 
            this.txtMediaPuntos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtMediaPuntos.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtMediaPuntos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMediaPuntos.Location = new System.Drawing.Point(498, 17);
            this.txtMediaPuntos.Name = "txtMediaPuntos";
            this.txtMediaPuntos.ReadOnly = true;
            this.txtMediaPuntos.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtMediaPuntos.Size = new System.Drawing.Size(105, 26);
            this.txtMediaPuntos.TabIndex = 166;
            this.txtMediaPuntos.TabStop = false;
            // 
            // label46
            // 
            this.label46.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label46.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label46.ForeColor = System.Drawing.Color.MediumBlue;
            this.label46.Location = new System.Drawing.Point(435, 19);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(64, 20);
            this.label46.TabIndex = 165;
            this.label46.Text = "Puntos:";
            // 
            // txtImpMedioNeto
            // 
            this.txtImpMedioNeto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtImpMedioNeto.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtImpMedioNeto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImpMedioNeto.Location = new System.Drawing.Point(322, 16);
            this.txtImpMedioNeto.Name = "txtImpMedioNeto";
            this.txtImpMedioNeto.ReadOnly = true;
            this.txtImpMedioNeto.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtImpMedioNeto.Size = new System.Drawing.Size(105, 26);
            this.txtImpMedioNeto.TabIndex = 164;
            this.txtImpMedioNeto.TabStop = false;
            // 
            // label45
            // 
            this.label45.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label45.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label45.ForeColor = System.Drawing.Color.MediumBlue;
            this.label45.Location = new System.Drawing.Point(276, 19);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(57, 20);
            this.label45.TabIndex = 163;
            this.label45.Text = "Neto:";
            // 
            // cboProgInf
            // 
            this.cboProgInf.BackColor = System.Drawing.Color.White;
            this.cboProgInf.DataSource = this.dsFormularios1;
            this.cboProgInf.DisplayMember = "ListaProgInf.sLiteral";
            this.cboProgInf.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProgInf.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cboProgInf.ForeColor = System.Drawing.Color.Black;
            this.cboProgInf.Location = new System.Drawing.Point(1206, 31);
            this.cboProgInf.Name = "cboProgInf";
            this.cboProgInf.Size = new System.Drawing.Size(153, 21);
            this.cboProgInf.TabIndex = 145;
            this.cboProgInf.ValueMember = "ListaProgInf.sValor";
            this.cboProgInf.SelectedIndexChanged += new System.EventHandler(this.cboProgInf_SelectedIndexChanged);
            // 
            // label20
            // 
            this.label20.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.Black;
            this.label20.Location = new System.Drawing.Point(1082, 31);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(124, 23);
            this.label20.TabIndex = 120;
            this.label20.Text = "Progr. Informático:";
            // 
            // pnCompromiso
            // 
            this.pnCompromiso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnCompromiso.Controls.Add(this.cboIndividual);
            this.pnCompromiso.Controls.Add(this.cboClasico);
            this.pnCompromiso.Location = new System.Drawing.Point(1244, 81);
            this.pnCompromiso.Name = "pnCompromiso";
            this.pnCompromiso.Size = new System.Drawing.Size(236, 36);
            this.pnCompromiso.TabIndex = 157;
            // 
            // cboIndividual
            // 
            this.cboIndividual.DataSource = this.dsFormularios1;
            this.cboIndividual.DisplayMember = "ListaTiposGestionCompromiso.sLiteral";
            this.cboIndividual.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboIndividual.FormattingEnabled = true;
            this.cboIndividual.Location = new System.Drawing.Point(120, 6);
            this.cboIndividual.Name = "cboIndividual";
            this.cboIndividual.Size = new System.Drawing.Size(108, 24);
            this.cboIndividual.TabIndex = 1;
            this.cboIndividual.ValueMember = "ListaTiposGestionCompromiso.sValor";
            // 
            // cboClasico
            // 
            this.cboClasico.DataSource = this.dsFormularios1;
            this.cboClasico.DisplayMember = "ListaTiposPedidoCompromiso.sLiteral";
            this.cboClasico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboClasico.FormattingEnabled = true;
            this.cboClasico.Location = new System.Drawing.Point(6, 6);
            this.cboClasico.Name = "cboClasico";
            this.cboClasico.Size = new System.Drawing.Size(108, 24);
            this.cboClasico.TabIndex = 0;
            this.cboClasico.ValueMember = "ListaTiposPedidoCompromiso.sValor";
            this.cboClasico.SelectedIndexChanged += new System.EventHandler(this.cboClasico_SelectedIndexChanged);
            this.cboClasico.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cboClasico_MouseClick);
            // 
            // txbCodPagoFija
            // 
            this.txbCodPagoFija.Enabled = false;
            this.txbCodPagoFija.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbCodPagoFija.Location = new System.Drawing.Point(802, 84);
            this.txbCodPagoFija.Name = "txbCodPagoFija";
            this.txbCodPagoFija.Size = new System.Drawing.Size(158, 26);
            this.txbCodPagoFija.TabIndex = 156;
            // 
            // lblCodPagoFija
            // 
            this.lblCodPagoFija.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblCodPagoFija.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodPagoFija.ForeColor = System.Drawing.Color.Black;
            this.lblCodPagoFija.Location = new System.Drawing.Point(635, 89);
            this.lblCodPagoFija.Name = "lblCodPagoFija";
            this.lblCodPagoFija.Size = new System.Drawing.Size(123, 23);
            this.lblCodPagoFija.TabIndex = 155;
            this.lblCodPagoFija.Text = "Cond. Pago Fija:";
            // 
            // txbDecilP
            // 
            this.txbDecilP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txbDecilP.Cursor = System.Windows.Forms.Cursors.Default;
            this.txbDecilP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbDecilP.Location = new System.Drawing.Point(1308, 60);
            this.txbDecilP.Margin = new System.Windows.Forms.Padding(2);
            this.txbDecilP.Name = "txbDecilP";
            this.txbDecilP.ReadOnly = true;
            this.txbDecilP.Size = new System.Drawing.Size(107, 21);
            this.txbDecilP.TabIndex = 154;
            // 
            // label28
            // 
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.Color.Black;
            this.label28.Location = new System.Drawing.Point(1249, 57);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(62, 26);
            this.label28.TabIndex = 153;
            this.label28.Text = "Decil P:";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txbSPais
            // 
            this.txbSPais.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbSPais.Location = new System.Drawing.Point(965, -15);
            this.txbSPais.MaxLength = 2;
            this.txbSPais.Name = "txbSPais";
            this.txbSPais.Size = new System.Drawing.Size(26, 23);
            this.txbSPais.TabIndex = 152;
            this.txbSPais.Visible = false;
            // 
            // txbSOficina
            // 
            this.txbSOficina.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbSOficina.Location = new System.Drawing.Point(1023, -15);
            this.txbSOficina.MaxLength = 3;
            this.txbSOficina.Name = "txbSOficina";
            this.txbSOficina.Size = new System.Drawing.Size(43, 23);
            this.txbSOficina.TabIndex = 151;
            this.txbSOficina.Visible = false;
            // 
            // txbSLocalidad
            // 
            this.txbSLocalidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbSLocalidad.Location = new System.Drawing.Point(994, -15);
            this.txbSLocalidad.MaxLength = 2;
            this.txbSLocalidad.Name = "txbSLocalidad";
            this.txbSLocalidad.Size = new System.Drawing.Size(26, 23);
            this.txbSLocalidad.TabIndex = 150;
            this.txbSLocalidad.Visible = false;
            // 
            // txbSBanco
            // 
            this.txbSBanco.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbSBanco.Location = new System.Drawing.Point(922, -15);
            this.txbSBanco.MaxLength = 4;
            this.txbSBanco.Name = "txbSBanco";
            this.txbSBanco.Size = new System.Drawing.Size(40, 23);
            this.txbSBanco.TabIndex = 149;
            this.txbSBanco.Visible = false;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.Color.Black;
            this.label27.Location = new System.Drawing.Point(874, -12);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(54, 17);
            this.label27.TabIndex = 148;
            this.label27.Text = "SWIFT:";
            this.label27.Visible = false;
            // 
            // txbCCAndorra
            // 
            this.txbCCAndorra.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbCCAndorra.Location = new System.Drawing.Point(224, 141);
            this.txbCCAndorra.Name = "txbCCAndorra";
            this.txbCCAndorra.Size = new System.Drawing.Size(285, 23);
            this.txbCCAndorra.TabIndex = 147;
            // 
            // txbIBAN
            // 
            this.txbIBAN.Enabled = false;
            this.txbIBAN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbIBAN.Location = new System.Drawing.Point(224, 141);
            this.txbIBAN.MaxLength = 4;
            this.txbIBAN.Name = "txbIBAN";
            this.txbIBAN.Size = new System.Drawing.Size(46, 23);
            this.txbIBAN.TabIndex = 146;
            // 
            // btActRent
            // 
            this.btActRent.Image = global::GESTCRM.Properties.Resources.reload_032x032;
            this.btActRent.Location = new System.Drawing.Point(1450, 56);
            this.btActRent.Name = "btActRent";
            this.btActRent.Size = new System.Drawing.Size(31, 26);
            this.btActRent.TabIndex = 144;
            this.btActRent.UseVisualStyleBackColor = true;
            this.btActRent.Click += new System.EventHandler(this.btActRent_Click);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.BackColor = System.Drawing.Color.Transparent;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(412, 144);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(13, 17);
            this.label23.TabIndex = 143;
            this.label23.Text = "-";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.BackColor = System.Drawing.Color.Transparent;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(368, 144);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(13, 17);
            this.label24.TabIndex = 142;
            this.label24.Text = "-";
            // 
            // txbControl
            // 
            this.txbControl.Enabled = false;
            this.txbControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbControl.Location = new System.Drawing.Point(382, 141);
            this.txbControl.MaxLength = 2;
            this.txbControl.Name = "txbControl";
            this.txbControl.Size = new System.Drawing.Size(30, 23);
            this.txbControl.TabIndex = 140;
            // 
            // txbOficina
            // 
            this.txbOficina.Enabled = false;
            this.txbOficina.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbOficina.Location = new System.Drawing.Point(321, 141);
            this.txbOficina.MaxLength = 4;
            this.txbOficina.Name = "txbOficina";
            this.txbOficina.Size = new System.Drawing.Size(46, 23);
            this.txbOficina.TabIndex = 139;
            // 
            // txbEntidad
            // 
            this.txbEntidad.Enabled = false;
            this.txbEntidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbEntidad.Location = new System.Drawing.Point(273, 141);
            this.txbEntidad.MaxLength = 4;
            this.txbEntidad.Name = "txbEntidad";
            this.txbEntidad.Size = new System.Drawing.Size(46, 23);
            this.txbEntidad.TabIndex = 138;
            // 
            // txbCC
            // 
            this.txbCC.Enabled = false;
            this.txbCC.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbCC.Location = new System.Drawing.Point(426, 141);
            this.txbCC.MaxLength = 10;
            this.txbCC.Name = "txbCC";
            this.txbCC.Size = new System.Drawing.Size(85, 23);
            this.txbCC.TabIndex = 141;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.Black;
            this.label21.Location = new System.Drawing.Point(193, 141);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(35, 20);
            this.label21.TabIndex = 137;
            this.label21.Text = "CC:";
            // 
            // dtpFechaFacturacion
            // 
            this.dtpFechaFacturacion.Enabled = false;
            this.dtpFechaFacturacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaFacturacion.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFacturacion.Location = new System.Drawing.Point(759, 85);
            this.dtpFechaFacturacion.Name = "dtpFechaFacturacion";
            this.dtpFechaFacturacion.Size = new System.Drawing.Size(100, 26);
            this.dtpFechaFacturacion.TabIndex = 136;
            this.dtpFechaFacturacion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtpFechaFacturacion_KeyPress);
            // 
            // cboPrioridad
            // 
            this.cboPrioridad.BackColor = System.Drawing.Color.White;
            this.cboPrioridad.DataSource = this.dsFormularios1;
            this.cboPrioridad.DisplayMember = "ListaTiposPrioridad.sLiteral";
            this.cboPrioridad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPrioridad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPrioridad.ForeColor = System.Drawing.Color.Black;
            this.cboPrioridad.Location = new System.Drawing.Point(1142, 86);
            this.cboPrioridad.Name = "cboPrioridad";
            this.cboPrioridad.Size = new System.Drawing.Size(100, 24);
            this.cboPrioridad.TabIndex = 134;
            this.cboPrioridad.ValueMember = "ListaTiposPrioridad.sValor";
            this.cboPrioridad.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cboPrioridad_MouseClick);
            // 
            // lblFechaFacturacion
            // 
            this.lblFechaFacturacion.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblFechaFacturacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaFacturacion.ForeColor = System.Drawing.Color.Black;
            this.lblFechaFacturacion.Location = new System.Drawing.Point(835, 89);
            this.lblFechaFacturacion.Name = "lblFechaFacturacion";
            this.lblFechaFacturacion.Size = new System.Drawing.Size(126, 23);
            this.lblFechaFacturacion.TabIndex = 135;
            this.lblFechaFacturacion.Text = "Fecha Vencimiento:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.Black;
            this.label22.Location = new System.Drawing.Point(1077, 89);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(66, 16);
            this.label22.TabIndex = 133;
            this.label22.Text = "Prioridad:";
            // 
            // cboCondicionPago
            // 
            this.cboCondicionPago.BackColor = System.Drawing.Color.White;
            this.cboCondicionPago.DataSource = this.dsFormularios1;
            this.cboCondicionPago.DisplayMember = "ListaTiposCondicionesPago.sLiteral";
            this.cboCondicionPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCondicionPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCondicionPago.ForeColor = System.Drawing.Color.Black;
            this.cboCondicionPago.Location = new System.Drawing.Point(759, 85);
            this.cboCondicionPago.Name = "cboCondicionPago";
            this.cboCondicionPago.Size = new System.Drawing.Size(186, 26);
            this.cboCondicionPago.TabIndex = 132;
            this.cboCondicionPago.ValueMember = "ListaTiposCondicionesPago.sValor";
            this.cboCondicionPago.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cboCondicionPago_MouseClick);
            // 
            // lblCondPago
            // 
            this.lblCondPago.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblCondPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCondPago.ForeColor = System.Drawing.Color.Black;
            this.lblCondPago.Location = new System.Drawing.Point(635, 89);
            this.lblCondPago.Name = "lblCondPago";
            this.lblCondPago.Size = new System.Drawing.Size(125, 25);
            this.lblCondPago.TabIndex = 131;
            this.lblCondPago.Text = "Condición de pago:";
            // 
            // lblAvisoVersion
            // 
            this.lblAvisoVersion.AutoSize = true;
            this.lblAvisoVersion.BackColor = System.Drawing.Color.Yellow;
            this.lblAvisoVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvisoVersion.ForeColor = System.Drawing.Color.Red;
            this.lblAvisoVersion.Location = new System.Drawing.Point(360, 12);
            this.lblAvisoVersion.Name = "lblAvisoVersion";
            this.lblAvisoVersion.Size = new System.Drawing.Size(57, 20);
            this.lblAvisoVersion.TabIndex = 130;
            this.lblAvisoVersion.Text = "label1";
            this.lblAvisoVersion.Visible = false;
            // 
            // chkRetenido
            // 
            this.chkRetenido.AutoSize = true;
            this.chkRetenido.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRetenido.Location = new System.Drawing.Point(8, 142);
            this.chkRetenido.Name = "chkRetenido";
            this.chkRetenido.Size = new System.Drawing.Size(146, 24);
            this.chkRetenido.TabIndex = 117;
            this.chkRetenido.Text = "Pedido Retenido";
            this.chkRetenido.UseVisualStyleBackColor = true;
            this.chkRetenido.CheckedChanged += new System.EventHandler(this.chkRetenido_CheckedChanged);
            this.chkRetenido.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chkRetenido_MouseClick);
            // 
            // txtProgInf
            // 
            this.txtProgInf.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtProgInf.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtProgInf.Location = new System.Drawing.Point(1195, 28);
            this.txtProgInf.Name = "txtProgInf";
            this.txtProgInf.ReadOnly = true;
            this.txtProgInf.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtProgInf.Size = new System.Drawing.Size(164, 23);
            this.txtProgInf.TabIndex = 121;
            this.txtProgInf.TabStop = false;
            this.txtProgInf.Visible = false;
            // 
            // txtMailFact
            // 
            this.txtMailFact.BackColor = System.Drawing.Color.White;
            this.txtMailFact.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtMailFact.Enabled = false;
            this.txtMailFact.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMailFact.Location = new System.Drawing.Point(394, 114);
            this.txtMailFact.Name = "txtMailFact";
            this.txtMailFact.Size = new System.Drawing.Size(231, 24);
            this.txtMailFact.TabIndex = 116;
            this.txtMailFact.TabStop = false;
            this.txtMailFact.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMailFact_KeyPress);
            // 
            // txtMailConf
            // 
            this.txtMailConf.BackColor = System.Drawing.Color.White;
            this.txtMailConf.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtMailConf.Enabled = false;
            this.txtMailConf.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMailConf.Location = new System.Drawing.Point(87, 114);
            this.txtMailConf.Name = "txtMailConf";
            this.txtMailConf.Size = new System.Drawing.Size(213, 24);
            this.txtMailConf.TabIndex = 115;
            this.txtMailConf.TabStop = false;
            this.txtMailConf.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMailConf_KeyPress);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(305, 116);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(88, 20);
            this.label17.TabIndex = 114;
            this.label17.Text = "Fact. Elec.:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.Black;
            this.label18.Location = new System.Drawing.Point(2, 116);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(87, 20);
            this.label18.TabIndex = 113;
            this.label18.Text = "Conf. Ped.:";
            // 
            // txbDtoGeneral
            // 
            this.txbDtoGeneral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txbDtoGeneral.Cursor = System.Windows.Forms.Cursors.Default;
            this.txbDtoGeneral.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbDtoGeneral.Location = new System.Drawing.Point(1022, 85);
            this.txbDtoGeneral.Name = "txbDtoGeneral";
            this.txbDtoGeneral.ReadOnly = true;
            this.txbDtoGeneral.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txbDtoGeneral.Size = new System.Drawing.Size(49, 26);
            this.txbDtoGeneral.TabIndex = 90;
            this.txbDtoGeneral.TabStop = false;
            this.txbDtoGeneral.Text = "0%";
            // 
            // lblDescGen
            // 
            this.lblDescGen.AutoSize = true;
            this.lblDescGen.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblDescGen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescGen.ForeColor = System.Drawing.Color.Black;
            this.lblDescGen.Location = new System.Drawing.Point(959, 85);
            this.lblDescGen.Name = "lblDescGen";
            this.lblDescGen.Size = new System.Drawing.Size(64, 20);
            this.lblDescGen.TabIndex = 87;
            this.lblDescGen.Text = "Dto. G.:";
            // 
            // txtCodPago
            // 
            this.txtCodPago.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtCodPago.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtCodPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodPago.Location = new System.Drawing.Point(475, 85);
            this.txtCodPago.Name = "txtCodPago";
            this.txtCodPago.ReadOnly = true;
            this.txtCodPago.Size = new System.Drawing.Size(153, 26);
            this.txtCodPago.TabIndex = 93;
            this.txtCodPago.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(408, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 20);
            this.label4.TabIndex = 92;
            this.label4.Text = "C.Pago:";
            // 
            // txtbRentAnual
            // 
            this.txtbRentAnual.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtbRentAnual.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtbRentAnual.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbRentAnual.Location = new System.Drawing.Point(1427, 58);
            this.txtbRentAnual.Margin = new System.Windows.Forms.Padding(2);
            this.txtbRentAnual.Name = "txtbRentAnual";
            this.txtbRentAnual.ReadOnly = true;
            this.txtbRentAnual.Size = new System.Drawing.Size(24, 23);
            this.txtbRentAnual.TabIndex = 111;
            this.txtbRentAnual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(425, 85);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(102, 20);
            this.label15.TabIndex = 110;
            this.label15.Text = "Fecha venci.:";
            this.label15.Visible = false;
            // 
            // dtpFechaVenci
            // 
            this.dtpFechaVenci.Enabled = false;
            this.dtpFechaVenci.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaVenci.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaVenci.Location = new System.Drawing.Point(528, 85);
            this.dtpFechaVenci.Name = "dtpFechaVenci";
            this.dtpFechaVenci.Size = new System.Drawing.Size(100, 26);
            this.dtpFechaVenci.TabIndex = 109;
            this.dtpFechaVenci.Visible = false;
            this.dtpFechaVenci.CloseUp += new System.EventHandler(this.dtpFechaVenci_CloseUp);
            // 
            // chkVisita
            // 
            this.chkVisita.AutoSize = true;
            this.chkVisita.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkVisita.Location = new System.Drawing.Point(1369, 30);
            this.chkVisita.Name = "chkVisita";
            this.chkVisita.Size = new System.Drawing.Size(110, 24);
            this.chkVisita.TabIndex = 108;
            this.chkVisita.Text = "Crear Visita";
            this.chkVisita.UseVisualStyleBackColor = true;
            // 
            // cboTipoCampana
            // 
            this.cboTipoCampana.BackColor = System.Drawing.Color.White;
            this.cboTipoCampana.DataSource = this.dsFormularios1;
            this.cboTipoCampana.DisplayMember = "ListaCampanyasCabecera.NombreCampanya";
            this.cboTipoCampana.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoCampana.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipoCampana.ForeColor = System.Drawing.Color.Black;
            this.cboTipoCampana.Location = new System.Drawing.Point(86, 85);
            this.cboTipoCampana.Name = "cboTipoCampana";
            this.cboTipoCampana.Size = new System.Drawing.Size(262, 26);
            this.cboTipoCampana.TabIndex = 99;
            this.cboTipoCampana.ValueMember = "ListaCampanyasCabecera.IdCampanya";
            this.cboTipoCampana.SelectedValueChanged += new System.EventHandler(this.cboTipoCampana_SelectedValueChanged);
            this.cboTipoCampana.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cboTipoCampana_MouseClick);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(2, 85);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(82, 20);
            this.label10.TabIndex = 98;
            this.label10.Text = "Campaña:";
            // 
            // txtEncComercial
            // 
            this.txtEncComercial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtEncComercial.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtEncComercial.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEncComercial.Location = new System.Drawing.Point(725, 115);
            this.txtEncComercial.Name = "txtEncComercial";
            this.txtEncComercial.ReadOnly = true;
            this.txtEncComercial.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtEncComercial.Size = new System.Drawing.Size(83, 24);
            this.txtEncComercial.TabIndex = 95;
            this.txtEncComercial.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(635, 116);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 20);
            this.label6.TabIndex = 94;
            this.label6.Text = "Impagados:";
            // 
            // lblTitulo
            // 
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.GradientColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.lblTitulo.GradientColorTwo = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(1487, 23);
            this.lblTitulo.TabIndex = 91;
            this.lblTitulo.Text = "Edición de pedido";
            // 
            // txtDestinatarioSAP
            // 
            this.txtDestinatarioSAP.BackColor = System.Drawing.Color.White;
            this.txtDestinatarioSAP.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDestinatarioSAP.ForeColor = System.Drawing.Color.Black;
            this.txtDestinatarioSAP.Location = new System.Drawing.Point(759, 57);
            this.txtDestinatarioSAP.MaxLength = 20;
            this.txtDestinatarioSAP.Name = "txtDestinatarioSAP";
            this.txtDestinatarioSAP.Size = new System.Drawing.Size(103, 24);
            this.txtDestinatarioSAP.TabIndex = 6;
            this.txtDestinatarioSAP.TextChanged += new System.EventHandler(this.txtDestinatarioSAP_TextChanged);
            this.txtDestinatarioSAP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDestinatarioSAP_KeyPress);
            this.txtDestinatarioSAP.Leave += new System.EventHandler(this.txtDestinatarioSAP_Leave);
            // 
            // txtClienteSAP
            // 
            this.txtClienteSAP.BackColor = System.Drawing.Color.White;
            this.txtClienteSAP.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClienteSAP.ForeColor = System.Drawing.Color.Black;
            this.txtClienteSAP.Location = new System.Drawing.Point(759, 29);
            this.txtClienteSAP.MaxLength = 20;
            this.txtClienteSAP.Name = "txtClienteSAP";
            this.txtClienteSAP.Size = new System.Drawing.Size(104, 24);
            this.txtClienteSAP.TabIndex = 5;
            this.txtClienteSAP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtClienteSAP_KeyPress);
            this.txtClienteSAP.Leave += new System.EventHandler(this.txtClienteSAP_Leave);
            // 
            // txbObservaciones
            // 
            this.txbObservaciones.BackColor = System.Drawing.Color.White;
            this.txbObservaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txbObservaciones.Location = new System.Drawing.Point(1176, 0);
            this.txbObservaciones.MaxLength = 8000;
            this.txbObservaciones.Multiline = true;
            this.txbObservaciones.Name = "txbObservaciones";
            this.txbObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txbObservaciones.Size = new System.Drawing.Size(288, 44);
            this.txbObservaciones.TabIndex = 7;
            this.txbObservaciones.Visible = false;
            this.txbObservaciones.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbObservaciones_KeyPress);
            // 
            // txtsDestinatario
            // 
            this.txtsDestinatario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtsDestinatario.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtsDestinatario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsDestinatario.ForeColor = System.Drawing.Color.Black;
            this.txtsDestinatario.Location = new System.Drawing.Point(865, 58);
            this.txtsDestinatario.Name = "txtsDestinatario";
            this.txtsDestinatario.ReadOnly = true;
            this.txtsDestinatario.Size = new System.Drawing.Size(192, 21);
            this.txtsDestinatario.TabIndex = 86;
            this.txtsDestinatario.TabStop = false;
            // 
            // txbIdPedido
            // 
            this.txbIdPedido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txbIdPedido.Cursor = System.Windows.Forms.Cursors.Default;
            this.txbIdPedido.ForeColor = System.Drawing.Color.Black;
            this.txbIdPedido.Location = new System.Drawing.Point(64, 57);
            this.txbIdPedido.Name = "txbIdPedido";
            this.txbIdPedido.ReadOnly = true;
            this.txbIdPedido.Size = new System.Drawing.Size(112, 23);
            this.txbIdPedido.TabIndex = 83;
            this.txbIdPedido.TabStop = false;
            // 
            // txbDelegado
            // 
            this.txbDelegado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txbDelegado.Cursor = System.Windows.Forms.Cursors.Default;
            this.txbDelegado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbDelegado.ForeColor = System.Drawing.Color.Black;
            this.txbDelegado.Location = new System.Drawing.Point(86, 29);
            this.txbDelegado.Name = "txbDelegado";
            this.txbDelegado.ReadOnly = true;
            this.txbDelegado.Size = new System.Drawing.Size(320, 26);
            this.txbDelegado.TabIndex = 82;
            this.txbDelegado.TabStop = false;
            // 
            // btBuscarDestinatario
            // 
            this.btBuscarDestinatario.Image = ((System.Drawing.Image)(resources.GetObject("btBuscarDestinatario.Image")));
            this.btBuscarDestinatario.Location = new System.Drawing.Point(1058, 56);
            this.btBuscarDestinatario.Name = "btBuscarDestinatario";
            this.btBuscarDestinatario.Size = new System.Drawing.Size(23, 23);
            this.btBuscarDestinatario.TabIndex = 3;
            this.btBuscarDestinatario.TabStop = false;
            this.btBuscarDestinatario.UseVisualStyleBackColor = true;
            this.btBuscarDestinatario.Click += new System.EventHandler(this.btBuscarDestinatario_Click);
            // 
            // btBuscarCliente
            // 
            this.btBuscarCliente.Image = ((System.Drawing.Image)(resources.GetObject("btBuscarCliente.Image")));
            this.btBuscarCliente.Location = new System.Drawing.Point(1058, 29);
            this.btBuscarCliente.Name = "btBuscarCliente";
            this.btBuscarCliente.Size = new System.Drawing.Size(23, 23);
            this.btBuscarCliente.TabIndex = 1;
            this.btBuscarCliente.TabStop = false;
            this.btBuscarCliente.UseVisualStyleBackColor = true;
            this.btBuscarCliente.Click += new System.EventHandler(this.btBuscarCliente_Click);
            // 
            // txtsCliente
            // 
            this.txtsCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtsCliente.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtsCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsCliente.ForeColor = System.Drawing.Color.Black;
            this.txtsCliente.Location = new System.Drawing.Point(865, 30);
            this.txtsCliente.Name = "txtsCliente";
            this.txtsCliente.ReadOnly = true;
            this.txtsCliente.Size = new System.Drawing.Size(192, 21);
            this.txtsCliente.TabIndex = 76;
            this.txtsCliente.TabStop = false;
            // 
            // dtpFechaPedido
            // 
            this.dtpFechaPedido.Enabled = false;
            this.dtpFechaPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaPedido.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaPedido.Location = new System.Drawing.Point(524, 29);
            this.dtpFechaPedido.Name = "dtpFechaPedido";
            this.dtpFechaPedido.Size = new System.Drawing.Size(100, 26);
            this.dtpFechaPedido.TabIndex = 2;
            // 
            // lblFechaPedido
            // 
            this.lblFechaPedido.AutoSize = true;
            this.lblFechaPedido.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblFechaPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaPedido.ForeColor = System.Drawing.Color.Black;
            this.lblFechaPedido.Location = new System.Drawing.Point(464, 32);
            this.lblFechaPedido.Name = "lblFechaPedido";
            this.lblFechaPedido.Size = new System.Drawing.Size(58, 20);
            this.lblFechaPedido.TabIndex = 65;
            this.lblFechaPedido.Text = "Fecha:";
            this.lblFechaPedido.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboTipoPedido
            // 
            this.cboTipoPedido.BackColor = System.Drawing.Color.White;
            this.cboTipoPedido.DataSource = this.dsFormularios1;
            this.cboTipoPedido.DisplayMember = "ListaTiposPedidoSAP.sLiteral";
            this.cboTipoPedido.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipoPedido.Location = new System.Drawing.Point(273, 57);
            this.cboTipoPedido.Name = "cboTipoPedido";
            this.cboTipoPedido.Size = new System.Drawing.Size(130, 26);
            this.cboTipoPedido.TabIndex = 0;
            this.toolTipPedidos.SetToolTip(this.cboTipoPedido, "Seleccione el tipo de pedido.");
            this.cboTipoPedido.ValueMember = "ListaTiposPedidoSAP.sValor";
            this.cboTipoPedido.SelectedIndexChanged += new System.EventHandler(this.cboTipoPedido_SelectedIndexChanged);
            this.cboTipoPedido.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cboTipoPedido_MouseClick);
            // 
            // dtpFechaFij
            // 
            this.dtpFechaFij.Enabled = false;
            this.dtpFechaFij.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaFij.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFij.Location = new System.Drawing.Point(527, 85);
            this.dtpFechaFij.Name = "dtpFechaFij";
            this.dtpFechaFij.Size = new System.Drawing.Size(100, 26);
            this.dtpFechaFij.TabIndex = 4;
            this.dtpFechaFij.Visible = false;
            // 
            // dtpFechaPref
            // 
            this.dtpFechaPref.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaPref.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaPref.Location = new System.Drawing.Point(523, 57);
            this.dtpFechaPref.Name = "dtpFechaPref";
            this.dtpFechaPref.Size = new System.Drawing.Size(100, 26);
            this.dtpFechaPref.TabIndex = 3;
            // 
            // lblObservaciones
            // 
            this.lblObservaciones.AutoSize = true;
            this.lblObservaciones.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblObservaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblObservaciones.ForeColor = System.Drawing.Color.Black;
            this.lblObservaciones.Location = new System.Drawing.Point(1082, -2);
            this.lblObservaciones.Name = "lblObservaciones";
            this.lblObservaciones.Size = new System.Drawing.Size(46, 20);
            this.lblObservaciones.TabIndex = 34;
            this.lblObservaciones.Text = "Obs.:";
            this.lblObservaciones.Visible = false;
            // 
            // lblFechaFijada
            // 
            this.lblFechaFijada.AutoSize = true;
            this.lblFechaFijada.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblFechaFijada.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaFijada.ForeColor = System.Drawing.Color.Black;
            this.lblFechaFijada.Location = new System.Drawing.Point(445, 84);
            this.lblFechaFijada.Name = "lblFechaFijada";
            this.lblFechaFijada.Size = new System.Drawing.Size(82, 20);
            this.lblFechaFijada.TabIndex = 24;
            this.lblFechaFijada.Text = "Fecha Fij.:";
            this.lblFechaFijada.Visible = false;
            // 
            // lblFechaPref
            // 
            this.lblFechaPref.AutoSize = true;
            this.lblFechaPref.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblFechaPref.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaPref.ForeColor = System.Drawing.Color.Black;
            this.lblFechaPref.Location = new System.Drawing.Point(405, 57);
            this.lblFechaPref.Name = "lblFechaPref";
            this.lblFechaPref.Size = new System.Drawing.Size(117, 20);
            this.lblFechaPref.TabIndex = 21;
            this.lblFechaPref.Text = "Fecha entrega:";
            this.lblFechaPref.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTipoPedido
            // 
            this.lblTipoPedido.AutoSize = true;
            this.lblTipoPedido.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblTipoPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoPedido.ForeColor = System.Drawing.Color.Black;
            this.lblTipoPedido.Location = new System.Drawing.Point(178, 59);
            this.lblTipoPedido.Name = "lblTipoPedido";
            this.lblTipoPedido.Size = new System.Drawing.Size(96, 20);
            this.lblTipoPedido.TabIndex = 15;
            this.lblTipoPedido.Text = "Tipo Pedido:";
            // 
            // lblDelegado
            // 
            this.lblDelegado.AutoSize = true;
            this.lblDelegado.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblDelegado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDelegado.ForeColor = System.Drawing.Color.Black;
            this.lblDelegado.Location = new System.Drawing.Point(3, 30);
            this.lblDelegado.Name = "lblDelegado";
            this.lblDelegado.Size = new System.Drawing.Size(82, 20);
            this.lblDelegado.TabIndex = 13;
            this.lblDelegado.Text = "Delegado:";
            // 
            // lblPedido
            // 
            this.lblPedido.AutoSize = true;
            this.lblPedido.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPedido.ForeColor = System.Drawing.Color.Black;
            this.lblPedido.Location = new System.Drawing.Point(3, 57);
            this.lblPedido.Name = "lblPedido";
            this.lblPedido.Size = new System.Drawing.Size(62, 20);
            this.lblPedido.TabIndex = 11;
            this.lblPedido.Text = "Pedido:";
            // 
            // lblDestinatario
            // 
            this.lblDestinatario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDestinatario.ForeColor = System.Drawing.Color.Black;
            this.lblDestinatario.Location = new System.Drawing.Point(621, 57);
            this.lblDestinatario.Name = "lblDestinatario";
            this.lblDestinatario.Size = new System.Drawing.Size(138, 22);
            this.lblDestinatario.TabIndex = 77;
            this.lblDestinatario.Text = "Dest. Mercancia:";
            this.lblDestinatario.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(613, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 20);
            this.label2.TabIndex = 73;
            this.label2.Text = "Sol./Pagador:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // toolTipPedidos
            // 
            this.toolTipPedidos.AutoPopDelay = 30000;
            this.toolTipPedidos.InitialDelay = 500;
            this.toolTipPedidos.IsBalloon = true;
            this.toolTipPedidos.ReshowDelay = 100;
            this.toolTipPedidos.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTipPedidos.ToolTipTitle = "Información";
            // 
            // sqlConn
            // 
            this.sqlConn.FireInfoMessageEventOnUserErrors = false;
            // 
            // sqlCmdSetPedidosCab
            // 
            this.sqlCmdSetPedidosCab.CommandText = "[SetPedidosCab]";
            this.sqlCmdSetPedidosCab.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdSetPedidosCab.Connection = this.sqlConn;
            this.sqlCmdSetPedidosCab.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iAccion", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sIdPedido", System.Data.SqlDbType.VarChar, 12, System.Data.ParameterDirection.InputOutput, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@sIdPedidoTemp", System.Data.SqlDbType.VarChar, 15, System.Data.ParameterDirection.InputOutput, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdDelegado", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sIdTipoPedido", System.Data.SqlDbType.VarChar, 4),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdDestinatario", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@dFechaPedido", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@dFechaPreferente", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@dFechaFijada", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@sOrgVentas", System.Data.SqlDbType.VarChar, 4),
            new System.Data.SqlClient.SqlParameter("@sGrupoVendedor", System.Data.SqlDbType.VarChar, 3),
            new System.Data.SqlClient.SqlParameter("@sCanal", System.Data.SqlDbType.VarChar, 2),
            new System.Data.SqlClient.SqlParameter("@sSector", System.Data.SqlDbType.VarChar, 2),
            new System.Data.SqlClient.SqlParameter("@fImporte", System.Data.SqlDbType.Float, 8),
            new System.Data.SqlClient.SqlParameter("@fDescuento", System.Data.SqlDbType.Float, 8),
            new System.Data.SqlClient.SqlParameter("@sIdTipoCampanya", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@tObservaciones", System.Data.SqlDbType.Text, 2147483647),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt, 2),
            new System.Data.SqlClient.SqlParameter("@fFUM", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@bEnviadoCEN", System.Data.SqlDbType.Bit, 1),
            new System.Data.SqlClient.SqlParameter("@bEnviadoPDA", System.Data.SqlDbType.Bit, 1),
            new System.Data.SqlClient.SqlParameter("@fDescuentoCampanya", System.Data.SqlDbType.Float, 8),
            new System.Data.SqlClient.SqlParameter("@fDescuentoAdicional", System.Data.SqlDbType.Float, 8),
            new System.Data.SqlClient.SqlParameter("@fRentabilidad", System.Data.SqlDbType.Float, 8),
            new System.Data.SqlClient.SqlParameter("@iIdAccion", System.Data.SqlDbType.Int),
            new System.Data.SqlClient.SqlParameter("@sFechaVencimiento", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@sCondPago", System.Data.SqlDbType.VarChar, 4),
            new System.Data.SqlClient.SqlParameter("@sPrioridad", System.Data.SqlDbType.VarChar, 2),
            new System.Data.SqlClient.SqlParameter("@dFechaFacturacion", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@sTipoPedidoCompromiso", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@sTipoGestionCompromiso", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@sCPCompra", System.Data.SqlDbType.VarChar, 5)});
            // 
            // sqlCmdSetPedAcciones
            // 
            this.sqlCmdSetPedAcciones.CommandText = "[SetPedAcciones]";
            this.sqlCmdSetPedAcciones.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdSetPedAcciones.Connection = this.sqlConn;
            this.sqlCmdSetPedAcciones.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iAccion", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sIdPedido", System.Data.SqlDbType.VarChar, 12),
            new System.Data.SqlClient.SqlParameter("@iIdAccion", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iUnidades", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@Destino", System.Data.SqlDbType.VarChar, 1),
            new System.Data.SqlClient.SqlParameter("@Bruto", System.Data.SqlDbType.Float, 8)});
            // 
            // sqlCmdGetPedAcciones
            // 
            this.sqlCmdGetPedAcciones.CommandText = "[GetPedAcciones]";
            this.sqlCmdGetPedAcciones.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdGetPedAcciones.Connection = this.sqlConn;
            this.sqlCmdGetPedAcciones.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@sIdPedido", System.Data.SqlDbType.VarChar, 12)});
            // 
            // sqldaListaLineasPedido
            // 
            this.sqldaListaLineasPedido.SelectCommand = this.sqlSelectCommand1;
            this.sqldaListaLineasPedido.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaLineasPedido", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iIdLinea", "iIdLinea"),
                        new System.Data.Common.DataColumnMapping("sIdMaterial", "sIdMaterial"),
                        new System.Data.Common.DataColumnMapping("sMaterial", "sMaterial"),
                        new System.Data.Common.DataColumnMapping("iCantidad", "iCantidad"),
                        new System.Data.Common.DataColumnMapping("fPrecio", "fPrecio"),
                        new System.Data.Common.DataColumnMapping("fDescuento", "fDescuento"),
                        new System.Data.Common.DataColumnMapping("ImporteLin", "ImporteLin"),
                        new System.Data.Common.DataColumnMapping("PrecioUnitario", "PrecioUnitario"),
                        new System.Data.Common.DataColumnMapping("fDescuentoMaximo", "fDescuentoMaximo"),
                        new System.Data.Common.DataColumnMapping("fRentabilidad", "fRentabilidad"),
                        new System.Data.Common.DataColumnMapping("fCoste", "fCoste"),
                        new System.Data.Common.DataColumnMapping("idCampanya", "idCampanya"),
                        new System.Data.Common.DataColumnMapping("idArrastre", "idArrastre"),
                        new System.Data.Common.DataColumnMapping("NombreCampanya", "NombreCampanya"),
                        new System.Data.Common.DataColumnMapping("UnidMinimas", "UnidMinimas"),
                        new System.Data.Common.DataColumnMapping("sObligatorio", "sObligatorio"),
                        new System.Data.Common.DataColumnMapping("idGrupoMat", "idGrupoMat"),
                        new System.Data.Common.DataColumnMapping("sTipoMat", "sTipoMat"),
                        new System.Data.Common.DataColumnMapping("fDescExtra", "fDescExtra"),
                        new System.Data.Common.DataColumnMapping("fDescMat", "fDescMat"),
                        new System.Data.Common.DataColumnMapping("bDescExtra", "bDescExtra"),
                        new System.Data.Common.DataColumnMapping("sCodNacional", "sCodNacional"),
                        new System.Data.Common.DataColumnMapping("sSerie", "sSerie"),
                        new System.Data.Common.DataColumnMapping("sCodVale", "sCodVale"),
                        new System.Data.Common.DataColumnMapping("bFinanciado", "bFinanciado"),
                        new System.Data.Common.DataColumnMapping("bMedicamento", "bMedicamento"),
                        new System.Data.Common.DataColumnMapping("iCajaCompleta", "iCajaCompleta"),
                        new System.Data.Common.DataColumnMapping("iUnidadesEnfajado", "iUnidadesEnfajado"),
                        new System.Data.Common.DataColumnMapping("fDescuentoMaximoTRA", "fDescuentoMaximoTRA"),
                        new System.Data.Common.DataColumnMapping("fPVP", "fPVP"),
                        new System.Data.Common.DataColumnMapping("fPVPIVA", "fPVPIVA"),
                        new System.Data.Common.DataColumnMapping("iStockCanarias", "iStockCanarias"),
                        new System.Data.Common.DataColumnMapping("iPendientesCanarias", "iPendientesCanarias"),
                        new System.Data.Common.DataColumnMapping("fDescuentoMaximoDIR", "fDescuentoMaximoDIR")})});
            // 
            // sqlSelectCommand1
            // 
            this.sqlSelectCommand1.CommandText = "[ListaLineasPedido]";
            this.sqlSelectCommand1.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand1.Connection = this.sqlConn;
            this.sqlSelectCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@sIdPedido", System.Data.SqlDbType.VarChar, 12)});
            // 
            // sqldaListaLineasPedidoRentAnual
            // 
            this.sqldaListaLineasPedidoRentAnual.SelectCommand = this.sqlSelectLineasPedidoRentAnual;
            this.sqldaListaLineasPedidoRentAnual.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaLineasPedidoRentAnual", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("sCodSAP", "sCodSAP"),
                        new System.Data.Common.DataColumnMapping("dFecIni", "dFecIni"),
                        new System.Data.Common.DataColumnMapping("dFecFin", "dFecFin"),
                        new System.Data.Common.DataColumnMapping("fCoste", "fCoste"),
                        new System.Data.Common.DataColumnMapping("iCuenta", "iCuenta")})});
            // 
            // sqlSelectLineasPedidoRentAnual
            // 
            this.sqlSelectLineasPedidoRentAnual.CommandText = "[ListaLineasPedidoRentAnual]";
            this.sqlSelectLineasPedidoRentAnual.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectLineasPedidoRentAnual.Connection = this.sqlConn;
            this.sqlSelectLineasPedidoRentAnual.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4)});
            // 
            // sqldaListaLineasPedidoRentAnualArrastre
            // 
            this.sqldaListaLineasPedidoRentAnualArrastre.SelectCommand = this.sqlSelectLineasPedidoRentAnualArrastre;
            this.sqldaListaLineasPedidoRentAnualArrastre.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaLineasPedidoRentAnualArrastre", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("sCodSAP", "sCodSAP"),
                        new System.Data.Common.DataColumnMapping("dFecIni", "dFecIni"),
                        new System.Data.Common.DataColumnMapping("dFecFin", "dFecFin"),
                        new System.Data.Common.DataColumnMapping("fCoste", "fCoste"),
                        new System.Data.Common.DataColumnMapping("iCuenta", "iCuenta")})});
            // 
            // sqlSelectLineasPedidoRentAnualArrastre
            // 
            this.sqlSelectLineasPedidoRentAnualArrastre.CommandText = "[ListaLineasPedidoRentAnualArrastre]";
            this.sqlSelectLineasPedidoRentAnualArrastre.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectLineasPedidoRentAnualArrastre.Connection = this.sqlConn;
            this.sqlSelectLineasPedidoRentAnualArrastre.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4)});
            // 
            // sqldaProgInf
            // 
            this.sqldaProgInf.SelectCommand = this.sqlCmdProgInf;
            this.sqldaProgInf.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaProgInf", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("sValor", "sValor"),
                        new System.Data.Common.DataColumnMapping("sLiteral", "sLiteral")})});
            // 
            // sqlCmdProgInf
            // 
            this.sqlCmdProgInf.CommandText = "[ListaProgInf]";
            this.sqlCmdProgInf.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdProgInf.Connection = this.sqlConn;
            this.sqlCmdProgInf.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null)});
            // 
            // sqlCmdCargaPedido
            // 
            this.sqlCmdCargaPedido.CommandText = "[ListaBuscaPedidos]";
            this.sqlCmdCargaPedido.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdCargaPedido.Connection = this.sqlConn;
            this.sqlCmdCargaPedido.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdDelegado", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sIdCliente", System.Data.SqlDbType.VarChar, 20),
            new System.Data.SqlClient.SqlParameter("@sIdDestinatario", System.Data.SqlDbType.VarChar, 20),
            new System.Data.SqlClient.SqlParameter("@sIdTipoCampanya", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@dFechaPedido", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@sIdPedido", System.Data.SqlDbType.VarChar, 12),
            new System.Data.SqlClient.SqlParameter("@sIdTipoPedido", System.Data.SqlDbType.VarChar, 4),
            new System.Data.SqlClient.SqlParameter("@counter", System.Data.SqlDbType.Int, 4)});
            // 
            // sqlCmdGetValorsProdCamp
            // 
            this.sqlCmdGetValorsProdCamp.CommandText = "GetValorsProdCamp";
            this.sqlCmdGetValorsProdCamp.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdGetValorsProdCamp.Connection = this.sqlConn;
            this.sqlCmdGetValorsProdCamp.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@sIdProducto", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@idCampanya", System.Data.SqlDbType.VarChar, 10)});
            // 
            // sqldaListaTiposPosPedidoSAP
            // 
            this.sqldaListaTiposPosPedidoSAP.SelectCommand = this.sqlSelectCommand2;
            this.sqldaListaTiposPosPedidoSAP.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaTiposPosPedidoSAP", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("sIdTipoPedido", "sIdTipoPedido"),
                        new System.Data.Common.DataColumnMapping("sIdTipoPosicion", "sIdTipoPosicion"),
                        new System.Data.Common.DataColumnMapping("sLiteral", "sLiteral"),
                        new System.Data.Common.DataColumnMapping("bEntregado", "bEntregado"),
                        new System.Data.Common.DataColumnMapping("bGratis", "bGratis"),
                        new System.Data.Common.DataColumnMapping("bEntregadoOpt", "bEntregadoOpt")})});
            // 
            // sqlSelectCommand2
            // 
            this.sqlSelectCommand2.CommandText = "[ListaTiposPosPedidoSAP]";
            this.sqlSelectCommand2.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand2.Connection = this.sqlConn;
            this.sqlSelectCommand2.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null)});
            // 
            // sqldaListaClubsAviso
            // 
            this.sqldaListaClubsAviso.SelectCommand = this.sqlSelectListaClubsAviso;
            this.sqldaListaClubsAviso.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaClubsAviso", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("sGarantia", "sGarantia"),
                        new System.Data.Common.DataColumnMapping("iEstado", "iEstado")})});
            // 
            // sqlSelectListaClubsAviso
            // 
            this.sqlSelectListaClubsAviso.CommandText = "[ListaClubsAviso]";
            this.sqlSelectListaClubsAviso.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectListaClubsAviso.Connection = this.sqlConn;
            this.sqlSelectListaClubsAviso.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@sGarantia", System.Data.SqlDbType.VarChar, 4)});
            // 
            // contextMenu1
            // 
            this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuNuevo,
            this.menuEliminar});
            // 
            // menuNuevo
            // 
            this.menuNuevo.Index = 0;
            this.menuNuevo.Shortcut = System.Windows.Forms.Shortcut.CtrlN;
            this.menuNuevo.Text = "Nuevo";
            // 
            // menuEliminar
            // 
            this.menuEliminar.Index = 1;
            this.menuEliminar.Shortcut = System.Windows.Forms.Shortcut.CtrlX;
            this.menuEliminar.Text = "Eliminar";
            // 
            // dvTipoPedido
            // 
            this.dvTipoPedido.AllowDelete = false;
            this.dvTipoPedido.AllowEdit = false;
            this.dvTipoPedido.AllowNew = false;
            this.dvTipoPedido.RowFilter = "sIdTipoPosicion = \'TAN\'";
            // 
            // sqldaListaTiposPedidoSAP
            // 
            this.sqldaListaTiposPedidoSAP.SelectCommand = this.sqlSelectCommand3;
            this.sqldaListaTiposPedidoSAP.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaTiposPedidoSAP", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("sValor", "sValor"),
                        new System.Data.Common.DataColumnMapping("sLiteral", "sLiteral")})});
            // 
            // sqlSelectCommand3
            // 
            this.sqlSelectCommand3.CommandText = "[ListaTiposPedidoSAP]";
            this.sqlSelectCommand3.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand3.Connection = this.sqlConn;
            this.sqlSelectCommand3.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null)});
            // 
            // sqldaListaCondPago
            // 
            this.sqldaListaCondPago.SelectCommand = this.sqlCmdCondPago;
            this.sqldaListaCondPago.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaTiposCondicionesPago", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("sValor", "sValor"),
                        new System.Data.Common.DataColumnMapping("sLiteral", "sLiteral")})});
            // 
            // sqlCmdCondPago
            // 
            this.sqlCmdCondPago.CommandText = "[ListaTiposCondicionesPago]";
            this.sqlCmdCondPago.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdCondPago.Connection = this.sqlConn;
            this.sqlCmdCondPago.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null)});
            // 
            // sqldaListaPrioridad
            // 
            this.sqldaListaPrioridad.SelectCommand = this.sqlCmdPrioridad;
            this.sqldaListaPrioridad.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaTiposPrioridad", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("sValor", "sValor"),
                        new System.Data.Common.DataColumnMapping("sLiteral", "sLiteral")})});
            // 
            // sqlCmdPrioridad
            // 
            this.sqlCmdPrioridad.CommandText = "[ListaTiposPrioridad]";
            this.sqlCmdPrioridad.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdPrioridad.Connection = this.sqlConn;
            this.sqlCmdPrioridad.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null)});
            // 
            // sqlCmdGetClientesSAP
            // 
            this.sqlCmdGetClientesSAP.CommandText = "[GetCliente_SAP]";
            this.sqlCmdGetClientesSAP.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdGetClientesSAP.Connection = this.sqlConn;
            this.sqlCmdGetClientesSAP.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4)});
            // 
            // sqlCmdGetCampanyasPedido
            // 
            this.sqlCmdGetCampanyasPedido.CommandText = "dbo.[GetCampanyasPedidos]";
            this.sqlCmdGetCampanyasPedido.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdGetCampanyasPedido.Connection = this.sqlConn;
            this.sqlCmdGetCampanyasPedido.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@sIdPedido", System.Data.SqlDbType.VarChar, 12)});
            // 
            // sqlCmdGetIsCampanyaMultiple
            // 
            this.sqlCmdGetIsCampanyaMultiple.CommandText = "dbo.[GetIsCampanyaMultiple]";
            this.sqlCmdGetIsCampanyaMultiple.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdGetIsCampanyaMultiple.Connection = this.sqlConn;
            this.sqlCmdGetIsCampanyaMultiple.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@sIdCampanya", System.Data.SqlDbType.VarChar, 10)});
            // 
            // sqlCmdSetCampanyaPedido
            // 
            this.sqlCmdSetCampanyaPedido.CommandText = "dbo.[SetCamapanyaPedidos]";
            this.sqlCmdSetCampanyaPedido.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdSetCampanyaPedido.Connection = this.sqlConn;
            this.sqlCmdSetCampanyaPedido.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@sIdPedido", System.Data.SqlDbType.VarChar, 12),
            new System.Data.SqlClient.SqlParameter("@sIdCampanya", System.Data.SqlDbType.VarChar, 10)});
            // 
            // sqlCmdDeleteCampanyasPedido
            // 
            this.sqlCmdDeleteCampanyasPedido.CommandText = "dbo.[DeleteCampanyasPedido]";
            this.sqlCmdDeleteCampanyasPedido.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdDeleteCampanyasPedido.Connection = this.sqlConn;
            this.sqlCmdDeleteCampanyasPedido.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@sIdPedido", System.Data.SqlDbType.VarChar, 12)});
            // 
            // sqlCmdGetIsDescuentoMaxInformed
            // 
            this.sqlCmdGetIsDescuentoMaxInformed.CommandText = "GetIsDescuentoCampanyaInformed";
            this.sqlCmdGetIsDescuentoMaxInformed.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdGetIsDescuentoMaxInformed.Connection = this.sqlConn;
            this.sqlCmdGetIsDescuentoMaxInformed.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdCamp", System.Data.SqlDbType.VarChar, 10)});
            // 
            // sqlCmdGetIsDescuentoMinGarInformed
            // 
            this.sqlCmdGetIsDescuentoMinGarInformed.CommandText = "[GetDescMinGar]";
            this.sqlCmdGetIsDescuentoMinGarInformed.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdGetIsDescuentoMinGarInformed.Connection = this.sqlConn;
            this.sqlCmdGetIsDescuentoMinGarInformed.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@idCampanya", System.Data.SqlDbType.VarChar, 10)});
            // 
            // sqlDaListaMateriales
            // 
            this.sqlDaListaMateriales.SelectCommand = this.sqlCommand2;
            this.sqlDaListaMateriales.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaMateriales", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("sIdMaterial", "sIdMaterial"),
                        new System.Data.Common.DataColumnMapping("sMaterial", "sMaterial"),
                        new System.Data.Common.DataColumnMapping("sCodNacional", "sCodNacional"),
                        new System.Data.Common.DataColumnMapping("fPrecio", "fPrecio"),
                        new System.Data.Common.DataColumnMapping("selected", "selected")})});
            // 
            // sqlCommand2
            // 
            this.sqlCommand2.CommandText = "[ListaMaterialesDesCamp]";
            this.sqlCommand2.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCommand2.Connection = this.sqlConn;
            this.sqlCommand2.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@sIdMaterial", System.Data.SqlDbType.VarChar, 18),
            new System.Data.SqlClient.SqlParameter("@sMaterial", System.Data.SqlDbType.VarChar, 50),
            new System.Data.SqlClient.SqlParameter("@sCodNacional", System.Data.SqlDbType.VarChar, 6),
            new System.Data.SqlClient.SqlParameter("@fPrecio", System.Data.SqlDbType.Float, 8),
            new System.Data.SqlClient.SqlParameter("@sIdRed", System.Data.SqlDbType.VarChar, 4),
            new System.Data.SqlClient.SqlParameter("@iIdCamp", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@sidCampanya", System.Data.SqlDbType.VarChar, 10)});
            // 
            // dsPedidos1
            // 
            this.dsPedidos1.DataSetName = "dsPedidos";
            this.dsPedidos1.Locale = new System.Globalization.CultureInfo("en-US");
            this.dsPedidos1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            // sqlCmdGetMaterialesNoRentabilidad
            // 
            this.sqlCmdGetMaterialesNoRentabilidad.CommandText = "[GetMaterialesNoRentabilidad]";
            this.sqlCmdGetMaterialesNoRentabilidad.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdGetMaterialesNoRentabilidad.Connection = this.sqlConn;
            this.sqlCmdGetMaterialesNoRentabilidad.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@sIdPedido", System.Data.SqlDbType.VarChar, 12)});
            // 
            // sqlCmdGetCampanyasNoRentabilidad
            // 
            this.sqlCmdGetCampanyasNoRentabilidad.CommandText = "[GetCampanyasNoRentabilidad]";
            this.sqlCmdGetCampanyasNoRentabilidad.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdGetCampanyasNoRentabilidad.Connection = this.sqlConn;
            // 
            // sqlCmdGetMaterialesNoMargen
            // 
            this.sqlCmdGetMaterialesNoMargen.CommandText = "[GetMaterialesNoMargen]";
            this.sqlCmdGetMaterialesNoMargen.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdGetMaterialesNoMargen.Connection = this.sqlConn;
            this.sqlCmdGetMaterialesNoMargen.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null)});
            // 
            // sqlCmdGetFechaVencimiento
            // 
            this.sqlCmdGetFechaVencimiento.CommandText = "[GetFechaVencimientoPedido]";
            this.sqlCmdGetFechaVencimiento.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdGetFechaVencimiento.Connection = this.sqlConn;
            // 
            // sqlCmdSetCondicionesComercialesTemp
            // 
            this.sqlCmdSetCondicionesComercialesTemp.CommandText = "[SetCondicionesComercialesTemp]";
            this.sqlCmdSetCondicionesComercialesTemp.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdSetCondicionesComercialesTemp.Connection = this.sqlConn;
            this.sqlCmdSetCondicionesComercialesTemp.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@sIdSubProducto", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@iIdProvincia", System.Data.SqlDbType.Int),
            new System.Data.SqlClient.SqlParameter("@iUnidades", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@fImporte", System.Data.SqlDbType.Float, 8)});
            // 
            // sqlCmdDelCondicionesComercialesTemp
            // 
            this.sqlCmdDelCondicionesComercialesTemp.CommandText = "[DelCondicionesComercialesTemp]";
            this.sqlCmdDelCondicionesComercialesTemp.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdDelCondicionesComercialesTemp.Connection = this.sqlConn;
            // 
            // sqlCmdGetDescuentoMayoristaClub
            // 
            this.sqlCmdGetDescuentoMayoristaClub.CommandText = "[GetDescuentoMayoristaClub]";
            this.sqlCmdGetDescuentoMayoristaClub.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdGetDescuentoMayoristaClub.Connection = this.sqlConn;
            this.sqlCmdGetDescuentoMayoristaClub.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdDestinatario", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sGarantias", System.Data.SqlDbType.VarChar, 4)});
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
                        new System.Data.Common.DataColumnMapping("fDescMinGar", "fDescMinGar")})});
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
            // sqlCmdListaCampanyasPedInactivo
            // 
            this.sqlCmdListaCampanyasPedInactivo.CommandText = "ListaCampanyasSegunClientePedEnviadoCEN";
            this.sqlCmdListaCampanyasPedInactivo.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdListaCampanyasPedInactivo.Connection = this.sqlConn;
            this.sqlCmdListaCampanyasPedInactivo.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iTipo", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@idCampanya", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@tipoCampanya", System.Data.SqlDbType.VarChar, 3),
            new System.Data.SqlClient.SqlParameter("@sIdDelegado", System.Data.SqlDbType.VarChar, 4),
            new System.Data.SqlClient.SqlParameter("@sIdTipoPedido", System.Data.SqlDbType.VarChar, 4),
            new System.Data.SqlClient.SqlParameter("@idCampanyaCab", System.Data.SqlDbType.VarChar, 10)});
            // 
            // sqlCmdListaCampanyasPedInactivoNEW
            // 
            this.sqlCmdListaCampanyasPedInactivoNEW.CommandText = "ListaCampanyasVerPedEnviadoCEN";
            this.sqlCmdListaCampanyasPedInactivoNEW.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdListaCampanyasPedInactivoNEW.Connection = this.sqlConn;
            this.sqlCmdListaCampanyasPedInactivoNEW.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@sIdDelegado", System.Data.SqlDbType.VarChar, 4),
            new System.Data.SqlClient.SqlParameter("@sIdTipoPedido", System.Data.SqlDbType.VarChar, 4),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sIdMayorista", System.Data.SqlDbType.VarChar, 20)});
            // 
            // sqlCommand3
            // 
            this.sqlCommand3.CommandText = "ListaCampanyas";
            this.sqlCommand3.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCommand3.Connection = this.sqlConn;
            this.sqlCommand3.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null)});
            // 
            // iIdLinea
            // 
            this.iIdLinea.DataPropertyName = "iIdLinea";
            this.iIdLinea.HeaderText = "Línea";
            this.iIdLinea.MinimumWidth = 8;
            this.iIdLinea.Name = "iIdLinea";
            this.iIdLinea.ReadOnly = true;
            this.iIdLinea.Width = 150;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "sIdMaterial";
            this.dataGridViewTextBoxColumn2.HeaderText = "Cod. Prod.";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 70;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "sMaterial";
            this.dataGridViewTextBoxColumn1.HeaderText = "Producto";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 280;
            // 
            // NombreCampanya
            // 
            this.NombreCampanya.DataPropertyName = "NombreCampanya";
            this.NombreCampanya.HeaderText = "Campaña";
            this.NombreCampanya.MinimumWidth = 8;
            this.NombreCampanya.Name = "NombreCampanya";
            this.NombreCampanya.ReadOnly = true;
            this.NombreCampanya.Width = 150;
            // 
            // sObligatorio
            // 
            this.sObligatorio.DataPropertyName = "sObligatorio";
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.sObligatorio.DefaultCellStyle = dataGridViewCellStyle18;
            this.sObligatorio.HeaderText = "Obligatorio";
            this.sObligatorio.MinimumWidth = 8;
            this.sObligatorio.Name = "sObligatorio";
            this.sObligatorio.ReadOnly = true;
            this.sObligatorio.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.sObligatorio.Width = 75;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "iCantidad";
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle19;
            this.dataGridViewTextBoxColumn4.HeaderText = "Cantidad";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn4.Width = 70;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "fPrecio";
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle20;
            this.dataGridViewTextBoxColumn3.HeaderText = "Precio";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 70;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "fDescuento";
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle21.NullValue = null;
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle21;
            this.dataGridViewTextBoxColumn5.HeaderText = "Descuento";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn5.Width = 75;
            // 
            // ImporteLin
            // 
            this.ImporteLin.DataPropertyName = "ImporteLin";
            this.ImporteLin.HeaderText = "Importe";
            this.ImporteLin.MinimumWidth = 8;
            this.ImporteLin.Name = "ImporteLin";
            this.ImporteLin.ReadOnly = true;
            this.ImporteLin.Width = 150;
            // 
            // fDescuentoMaximo
            // 
            this.fDescuentoMaximo.DataPropertyName = "fDescuentoMaximo";
            this.fDescuentoMaximo.HeaderText = "Desc. Max.";
            this.fDescuentoMaximo.MinimumWidth = 8;
            this.fDescuentoMaximo.Name = "fDescuentoMaximo";
            this.fDescuentoMaximo.ReadOnly = true;
            this.fDescuentoMaximo.Visible = false;
            this.fDescuentoMaximo.Width = 70;
            // 
            // fCoste
            // 
            this.fCoste.DataPropertyName = "fCoste";
            this.fCoste.HeaderText = "fCoste";
            this.fCoste.MinimumWidth = 8;
            this.fCoste.Name = "fCoste";
            this.fCoste.Visible = false;
            this.fCoste.Width = 150;
            // 
            // UnidMinimas
            // 
            this.UnidMinimas.DataPropertyName = "UnidMinimas";
            this.UnidMinimas.HeaderText = "UnidMinimas";
            this.UnidMinimas.MinimumWidth = 8;
            this.UnidMinimas.Name = "UnidMinimas";
            this.UnidMinimas.ReadOnly = true;
            this.UnidMinimas.Visible = false;
            this.UnidMinimas.Width = 150;
            // 
            // sqlCmdSetPedidosLin
            // 
            this.sqlCmdSetPedidosLin.CommandText = "SetPedidosLin";
            this.sqlCmdSetPedidosLin.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdSetPedidosLin.Connection = this.sqlConn;
            this.sqlCmdSetPedidosLin.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iAccion", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sIdPedido", System.Data.SqlDbType.VarChar, 12),
            new System.Data.SqlClient.SqlParameter("@iIdLinea", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sIdMaterial", System.Data.SqlDbType.VarChar, 18),
            new System.Data.SqlClient.SqlParameter("@iCantidad", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@fPrecio", System.Data.SqlDbType.Float, 8),
            new System.Data.SqlClient.SqlParameter("@sidTipoPosicion", System.Data.SqlDbType.VarChar, 4),
            new System.Data.SqlClient.SqlParameter("@bEntregado", System.Data.SqlDbType.Bit, 1),
            new System.Data.SqlClient.SqlParameter("@dFechaPreferente", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@fDescuento", System.Data.SqlDbType.Float, 8),
            new System.Data.SqlClient.SqlParameter("@iBonificacion", System.Data.SqlDbType.Bit, 1),
            new System.Data.SqlClient.SqlParameter("@idCampanya", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@idArrastre", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@idGrupoMat", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@idPaquete", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sSerie", System.Data.SqlDbType.VarChar, 7),
            new System.Data.SqlClient.SqlParameter("@sCodVale", System.Data.SqlDbType.VarChar, 15),
            new System.Data.SqlClient.SqlParameter("@sRechazo", System.Data.SqlDbType.VarChar, 4)});
            // 
            // sqldaListaCampCabecera
            // 
            this.sqldaListaCampCabecera.SelectCommand = this.sqlCommand4;
            this.sqldaListaCampCabecera.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaCampanyasCabecera", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("IdCampanya", "IdCampanya"),
                        new System.Data.Common.DataColumnMapping("NombreCampanya", "NombreCampanya")}),
            new System.Data.Common.DataTableMapping("Table1", "Table1", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("IdCampanya", "IdCampanya"),
                        new System.Data.Common.DataColumnMapping("NombreCampanya", "NombreCampanya"),
                        new System.Data.Common.DataColumnMapping("Descuento", "Descuento"),
                        new System.Data.Common.DataColumnMapping("sIdTipoPedido", "sIdTipoPedido"),
                        new System.Data.Common.DataColumnMapping("fImporteMinObli", "fImporteMinObli"),
                        new System.Data.Common.DataColumnMapping("fImporteMinObliBruto", "fImporteMinObliBruto"),
                        new System.Data.Common.DataColumnMapping("iNumMinUnidades", "iNumMinUnidades")})});
            // 
            // sqlCommand4
            // 
            this.sqlCommand4.CommandText = "dbo.ListaCampanyasCabecera";
            this.sqlCommand4.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCommand4.Connection = this.sqlConn;
            this.sqlCommand4.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@distinct", System.Data.SqlDbType.Bit, 1),
            new System.Data.SqlClient.SqlParameter("@tipoCampanya", System.Data.SqlDbType.VarChar, 3),
            new System.Data.SqlClient.SqlParameter("@sIdDelegado", System.Data.SqlDbType.VarChar, 4),
            new System.Data.SqlClient.SqlParameter("@sIdTipoPedido", System.Data.SqlDbType.VarChar, 4)});
            // 
            // sqlCommand4CECL
            // 
            this.sqlCommand4CECL.CommandText = "dbo.ListaCampanyasCabeceraCECL";
            this.sqlCommand4CECL.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCommand4CECL.Connection = this.sqlConn;
            this.sqlCommand4CECL.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@distinct", System.Data.SqlDbType.Bit, 1),
            new System.Data.SqlClient.SqlParameter("@tipoCampanya", System.Data.SqlDbType.VarChar, 3),
            new System.Data.SqlClient.SqlParameter("@sIdDelegado", System.Data.SqlDbType.VarChar, 4),
            new System.Data.SqlClient.SqlParameter("@sIdTipoPedido", System.Data.SqlDbType.VarChar, 4)});
            // 
            // listaAccionesMarketingBindingSource
            // 
            this.listaAccionesMarketingBindingSource.DataSource = this.dsFormularios1;
            this.listaAccionesMarketingBindingSource.Position = 0;
            // 
            // sqlDataListaAccionesMarketing
            // 
            this.sqlDataListaAccionesMarketing.SelectCommand = this.sqlCommand1;
            this.sqlDataListaAccionesMarketing.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaAccionesMarketing", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iIdAccion", "iIdAccion"),
                        new System.Data.Common.DataColumnMapping("sIdAccion", "sIdAccion"),
                        new System.Data.Common.DataColumnMapping("sDescAccion", "sDescAccion"),
                        new System.Data.Common.DataColumnMapping("sIdTipoAccion", "sIdTipoAccion"),
                        new System.Data.Common.DataColumnMapping("dFechaCreacion", "dFechaCreacion"),
                        new System.Data.Common.DataColumnMapping("dFechaIni", "dFechaIni"),
                        new System.Data.Common.DataColumnMapping("dFechaFin", "dFechaFin"),
                        new System.Data.Common.DataColumnMapping("iUnidades", "iUnidades"),
                        new System.Data.Common.DataColumnMapping("fCosteUnitario", "fCosteUnitario"),
                        new System.Data.Common.DataColumnMapping("fCosteTotal", "fCosteTotal"),
                        new System.Data.Common.DataColumnMapping("sObservaciones", "sObservaciones"),
                        new System.Data.Common.DataColumnMapping("sIdTipoImputacion", "sIdTipoImputacion"),
                        new System.Data.Common.DataColumnMapping("dFUM", "dFUM"),
                        new System.Data.Common.DataColumnMapping("iEstado", "iEstado"),
                        new System.Data.Common.DataColumnMapping("bEnviadoPDA", "bEnviadoPDA"),
                        new System.Data.Common.DataColumnMapping("iNumElemEntregar", "iNumElemEntregar"),
                        new System.Data.Common.DataColumnMapping("fImpMin", "fImpMin"),
                        new System.Data.Common.DataColumnMapping("fImpMax", "fImpMax"),
                        new System.Data.Common.DataColumnMapping("iMaxAEntregar", "iMaxAEntregar"),
                        new System.Data.Common.DataColumnMapping("bIndepe", "bIndepe"),
                        new System.Data.Common.DataColumnMapping("sIdProducto", "sIdProducto"),
                        new System.Data.Common.DataColumnMapping("sProducto", "sProducto"),
                        new System.Data.Common.DataColumnMapping("bSuma", "bSuma"),
                        new System.Data.Common.DataColumnMapping("iActivoPara", "iActivoPara")})});
            // 
            // sqlCommand1
            // 
            this.sqlCommand1.CommandText = "ListaAccionesMarketing";
            this.sqlCommand1.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCommand1.Connection = this.sqlConn;
            this.sqlCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@sIdTipoAccion", System.Data.SqlDbType.NVarChar, 10),
            new System.Data.SqlClient.SqlParameter("@sIdProducto", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@iUnidadesSel", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@fImporteSel", System.Data.SqlDbType.Float, 8),
            new System.Data.SqlClient.SqlParameter("@fRentabSel", System.Data.SqlDbType.Float, 8),
            new System.Data.SqlClient.SqlParameter("@bIndepe", System.Data.SqlDbType.Bit, 1),
            new System.Data.SqlClient.SqlParameter("@iActivoPara", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sIdTipoPedido", System.Data.SqlDbType.VarChar, 4)});
            // 
            // sqlCommand1CECL
            // 
            this.sqlCommand1CECL.CommandText = "ListaAccionesMarketingCECL";
            this.sqlCommand1CECL.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCommand1CECL.Connection = this.sqlConn;
            this.sqlCommand1CECL.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@sIdTipoAccion", System.Data.SqlDbType.NVarChar, 10),
            new System.Data.SqlClient.SqlParameter("@sIdProducto", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@iUnidadesSel", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@fImporteSel", System.Data.SqlDbType.Float, 8),
            new System.Data.SqlClient.SqlParameter("@fRentabSel", System.Data.SqlDbType.Float, 8),
            new System.Data.SqlClient.SqlParameter("@bIndepe", System.Data.SqlDbType.Bit, 1),
            new System.Data.SqlClient.SqlParameter("@iActivoPara", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sIdTipoPedido", System.Data.SqlDbType.VarChar, 4)});
            // 
            // ucBotoneraSecundaria1
            // 
            this.ucBotoneraSecundaria1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(117)))), ((int)(((byte)(1)))));
            this.ucBotoneraSecundaria1.ForeColor = System.Drawing.Color.Black;
            this.ucBotoneraSecundaria1.Location = new System.Drawing.Point(1, 2);
            this.ucBotoneraSecundaria1.Name = "ucBotoneraSecundaria1";
            this.ucBotoneraSecundaria1.Size = new System.Drawing.Size(1495, 36);
            this.ucBotoneraSecundaria1.TabIndex = 6;
            this.ucBotoneraSecundaria1.Click += new System.EventHandler(this.opcion_guardar);
            // 
            // sqlCmdProductoMaterial
            // 
            this.sqlCmdProductoMaterial.CommandText = "GetProductoMaterial";
            this.sqlCmdProductoMaterial.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdProductoMaterial.Connection = this.sqlConn;
            this.sqlCmdProductoMaterial.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@sIdMaterial", System.Data.SqlDbType.VarChar, 18)});
            // 
            // sqlCmdMaxAccMark
            // 
            this.sqlCmdMaxAccMark.CommandText = "GetNumMaxAccMarkSel";
            this.sqlCmdMaxAccMark.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdMaxAccMark.Connection = this.sqlConn;
            this.sqlCmdMaxAccMark.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@fImporte", System.Data.SqlDbType.Float, 8)});
            // 
            // sqldaCampsDup
            // 
            this.sqldaCampsDup.SelectCommand = this.sqlCmdCampsDup;
            this.sqldaCampsDup.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "CampsKeAdmitenDups", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("idCampanya", "idCampanya"),
                        new System.Data.Common.DataColumnMapping("NombreCampanya", "NombreCampanya")})});
            // 
            // sqlCmdCampsDup
            // 
            this.sqlCmdCampsDup.CommandText = "[GetCampsKeAdmitenDups]";
            this.sqlCmdCampsDup.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdCampsDup.Connection = this.sqlConn;
            this.sqlCmdCampsDup.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null)});
            // 
            // sqlCmdGrupoVencimientoMaterial
            // 
            this.sqlCmdGrupoVencimientoMaterial.CommandText = "GetGrupoVencimientoMaterial";
            this.sqlCmdGrupoVencimientoMaterial.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdGrupoVencimientoMaterial.Connection = this.sqlConn;
            this.sqlCmdGrupoVencimientoMaterial.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@sIdProducto", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@sIdMaterial", System.Data.SqlDbType.VarChar, 18)});
            // 
            // sqlCmdTipoMat
            // 
            this.sqlCmdTipoMat.CommandText = "GetTipoMat";
            this.sqlCmdTipoMat.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdTipoMat.Connection = this.sqlConn;
            this.sqlCmdTipoMat.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@sIdMaterial", System.Data.SqlDbType.VarChar, 18)});
            // 
            // sqlCmdListaContactosClientes_SAP
            // 
            this.sqlCmdListaContactosClientes_SAP.CommandText = "[ListaContactosClientes_SAP]";
            this.sqlCmdListaContactosClientes_SAP.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdListaContactosClientes_SAP.Connection = this.sqlConn;
            this.sqlCmdListaContactosClientes_SAP.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4)});
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
            // sqlGetNumAcckMarkADescartar
            // 
            this.sqlGetNumAcckMarkADescartar.CommandText = "[GetNumAccMarkSel]";
            this.sqlGetNumAcckMarkADescartar.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlGetNumAcckMarkADescartar.Connection = this.sqlConn;
            this.sqlGetNumAcckMarkADescartar.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@codsAccMark", System.Data.SqlDbType.VarChar, 500)});
            // 
            // sqlGetRentMinCampCab
            // 
            this.sqlGetRentMinCampCab.CommandText = "[GetRentMinCampCab]";
            this.sqlGetRentMinCampCab.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlGetRentMinCampCab.Connection = this.sqlConn;
            this.sqlGetRentMinCampCab.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@idCampanya", System.Data.SqlDbType.VarChar, 10)});
            // 
            // sqlGetCondPagoCampCab
            // 
            this.sqlGetCondPagoCampCab.CommandText = "[GetCondPagoCampCab]";
            this.sqlGetCondPagoCampCab.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlGetCondPagoCampCab.Connection = this.sqlConn;
            this.sqlGetCondPagoCampCab.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@idCampanya", System.Data.SqlDbType.VarChar, 10)});
            // 
            // sqlGetCondPagoFijaCampCab
            // 
            this.sqlGetCondPagoFijaCampCab.CommandText = "[GetCondPagoFijaCampCab]";
            this.sqlGetCondPagoFijaCampCab.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlGetCondPagoFijaCampCab.Connection = this.sqlConn;
            this.sqlGetCondPagoFijaCampCab.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@idCampanya", System.Data.SqlDbType.VarChar, 10)});
            // 
            // sqlGetFecFact
            // 
            this.sqlGetFecFact.CommandText = "[GetFecFactCampCab]";
            this.sqlGetFecFact.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlGetFecFact.Connection = this.sqlConn;
            this.sqlGetFecFact.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@idCampanya", System.Data.SqlDbType.VarChar, 10)});
            // 
            // sqldaGetMatsConVale
            // 
            this.sqldaGetMatsConVale.SelectCommand = this.sqlCmdGetMatsConVale;
            this.sqldaGetMatsConVale.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "MatsConVale", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("sIdMaterial", "sIdMaterial")})});
            // 
            // sqlCmdGetMatsConVale
            // 
            this.sqlCmdGetMatsConVale.CommandText = "[GetMatsConVale]";
            this.sqlCmdGetMatsConVale.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdGetMatsConVale.Connection = this.sqlConn;
            this.sqlCmdGetMatsConVale.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null)});
            // 
            // sqldaListaMatsConVale
            // 
            this.sqldaListaMatsConVale.SelectCommand = this.sqlCmdListaMatsConVale;
            this.sqldaListaMatsConVale.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaMatsConVale", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("sIdMaterial", "sIdMaterial"),
                        new System.Data.Common.DataColumnMapping("sCodNacional", "sCodNacional"),
                        new System.Data.Common.DataColumnMapping("sMaterial", "sMaterial"),
                        new System.Data.Common.DataColumnMapping("bConVale", "bConVale"),
                        new System.Data.Common.DataColumnMapping("sSerie", "sSerie"),
                        new System.Data.Common.DataColumnMapping("sCodVale", "sCodVale"),
                        new System.Data.Common.DataColumnMapping("sIdPedido", "sIdPedido")})});
            // 
            // sqlCmdListaMatsConVale
            // 
            this.sqlCmdListaMatsConVale.CommandText = "[ListaMatsConVale]";
            this.sqlCmdListaMatsConVale.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdListaMatsConVale.Connection = this.sqlConn;
            this.sqlCmdListaMatsConVale.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@sIdPedido", System.Data.SqlDbType.VarChar, 12)});
            // 
            // sqlCmdSetVale
            // 
            this.sqlCmdSetVale.CommandText = "[SetVale]";
            this.sqlCmdSetVale.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdSetVale.Connection = this.sqlConn;
            this.sqlCmdSetVale.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@sIdPedido", System.Data.SqlDbType.VarChar, 12),
            new System.Data.SqlClient.SqlParameter("@sIdMaterial", System.Data.SqlDbType.VarChar, 18),
            new System.Data.SqlClient.SqlParameter("@sSerie", System.Data.SqlDbType.VarChar, 7),
            new System.Data.SqlClient.SqlParameter("@sCodVale", System.Data.SqlDbType.VarChar, 15)});
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
            // sqldaListaAvisoMUV
            // 
            this.sqldaListaAvisoMUV.SelectCommand = this.sqlCmdListaAvisoMUV;
            this.sqldaListaAvisoMUV.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaAvisoMUV", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("sIdProducto", "sIdProducto"),
                        new System.Data.Common.DataColumnMapping("sDescProducto", "sDescProducto"),
                        new System.Data.Common.DataColumnMapping("sIdMaterial", "sIdMaterial"),
                        new System.Data.Common.DataColumnMapping("sMaterial", "sMaterial"),
                        new System.Data.Common.DataColumnMapping("iMinQty", "iMinQty"),
                        new System.Data.Common.DataColumnMapping("sumaCantidad", "sumaCantidad"),
                        new System.Data.Common.DataColumnMapping("sObservaciones", "sObservaciones"),
                        new System.Data.Common.DataColumnMapping("sObservaciones2", "sObservaciones2")})});
            // 
            // sqlCmdListaAvisoMUV
            // 
            this.sqlCmdListaAvisoMUV.CommandText = "[ListaAvisoMUV]";
            this.sqlCmdListaAvisoMUV.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdListaAvisoMUV.Connection = this.sqlConn;
            this.sqlCmdListaAvisoMUV.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdDelegado", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@dFec", System.Data.SqlDbType.DateTime)});
            // 
            // sqldaListaMUV
            // 
            this.sqldaListaMUV.SelectCommand = this.sqlCmdListaMUV;
            this.sqldaListaMUV.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaMinUniVen", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("sIdMaterial", "sIdMaterial"),
                        new System.Data.Common.DataColumnMapping("sMaterial", "sMaterial"),
                        new System.Data.Common.DataColumnMapping("dFecIni", "dFecIni"),
                        new System.Data.Common.DataColumnMapping("dFecFin", "dFecFin"),
                        new System.Data.Common.DataColumnMapping("iMinQty", "iMinQty")})});
            // 
            // sqlCmdListaMUV
            // 
            this.sqlCmdListaMUV.CommandText = "[ListaMinUniVen]";
            this.sqlCmdListaMUV.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdListaMUV.Connection = this.sqlConn;
            this.sqlCmdListaMUV.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@sIdMaterial", System.Data.SqlDbType.VarChar, 18),
            new System.Data.SqlClient.SqlParameter("@dFec", System.Data.SqlDbType.DateTime),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt)});
            // 
            // sqlCmdSetUltimosAvisos
            // 
            this.sqlCmdSetUltimosAvisos.CommandText = "[SetUltimosAvisos]";
            this.sqlCmdSetUltimosAvisos.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdSetUltimosAvisos.Connection = this.sqlConn;
            this.sqlCmdSetUltimosAvisos.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iAccion", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sIdProducto", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@sDescripcion", System.Data.SqlDbType.VarChar, 50),
            new System.Data.SqlClient.SqlParameter("@sIdMaterial", System.Data.SqlDbType.VarChar, 18),
            new System.Data.SqlClient.SqlParameter("@sMaterial", System.Data.SqlDbType.VarChar, 50)});
            // 
            // sqlCmdSetEmailsCliente
            // 
            this.sqlCmdSetEmailsCliente.CommandText = "[SetEmailsCliente]";
            this.sqlCmdSetEmailsCliente.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdSetEmailsCliente.Connection = this.sqlConn;
            this.sqlCmdSetEmailsCliente.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@dFecha", System.Data.SqlDbType.DateTime),
            new System.Data.SqlClient.SqlParameter("@sEmailConf", System.Data.SqlDbType.VarChar, 50),
            new System.Data.SqlClient.SqlParameter("@sEmailFact", System.Data.SqlDbType.VarChar, 50)});
            // 
            // sqlCmdSetRetenido
            // 
            this.sqlCmdSetRetenido.CommandText = "[SetPedidoRetenido]";
            this.sqlCmdSetRetenido.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdSetRetenido.Connection = this.sqlConn;
            this.sqlCmdSetRetenido.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@sIdPedido", System.Data.SqlDbType.VarChar, 12),
            new System.Data.SqlClient.SqlParameter("@bRetenido", System.Data.SqlDbType.Bit, 1),
            new System.Data.SqlClient.SqlParameter("@iIdDelegado", System.Data.SqlDbType.Int, 4)});
            // 
            // sqlGetRetenido
            // 
            this.sqlGetRetenido.CommandText = "dbo.[GetPedidoRetenido]";
            this.sqlGetRetenido.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlGetRetenido.Connection = this.sqlConn;
            this.sqlGetRetenido.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@sIdPedido", System.Data.SqlDbType.VarChar, 12)});
            // 
            // sqldaListaEmailsCliente
            // 
            this.sqldaListaEmailsCliente.SelectCommand = this.sqlCmdListaEmailsCliente;
            this.sqldaListaEmailsCliente.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaEmailsCliente", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iIdCliente", "iIdCliente"),
                        new System.Data.Common.DataColumnMapping("dFecha", "dFecha"),
                        new System.Data.Common.DataColumnMapping("sEmailConf", "sEmailConf"),
                        new System.Data.Common.DataColumnMapping("sEmailFact", "sEmailFact"),
                        new System.Data.Common.DataColumnMapping("bTratado", "bTratado"),
                        new System.Data.Common.DataColumnMapping("dFUM", "dFUM"),
                        new System.Data.Common.DataColumnMapping("bEnviadoCEN", "bEnviadoCEN")})});
            // 
            // sqlCmdListaEmailsCliente
            // 
            this.sqlCmdListaEmailsCliente.CommandText = "[ListaEmailsCliente]";
            this.sqlCmdListaEmailsCliente.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdListaEmailsCliente.Connection = this.sqlConn;
            this.sqlCmdListaEmailsCliente.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4)});
            // 
            // sqldaDescMax
            // 
            this.sqldaDescMax.SelectCommand = this.sqlSelectListaDescMax;
            this.sqldaDescMax.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaMDescMax", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iIdCliente", "iIdCliente"),
                        new System.Data.Common.DataColumnMapping("sIdCliente", "sIdCliente"),
                        new System.Data.Common.DataColumnMapping("sNombre", "sNombre"),
                        new System.Data.Common.DataColumnMapping("sIdMaterial", "sIdMaterial"),
                        new System.Data.Common.DataColumnMapping("sMaterial", "sMaterial"),
                        new System.Data.Common.DataColumnMapping("fDescuentoMaximo", "fDescuentoMaximo"),
                        new System.Data.Common.DataColumnMapping("iEstado", "iEstado")})});
            // 
            // sqlSelectListaDescMax
            // 
            this.sqlSelectListaDescMax.CommandText = "[ListaMDescMax]";
            this.sqlSelectListaDescMax.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectListaDescMax.Connection = this.sqlConn;
            this.sqlSelectListaDescMax.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sIdCliente", System.Data.SqlDbType.VarChar, 20),
            new System.Data.SqlClient.SqlParameter("@sNombre", System.Data.SqlDbType.VarChar, 50),
            new System.Data.SqlClient.SqlParameter("@sIdMaterial", System.Data.SqlDbType.VarChar, 18),
            new System.Data.SqlClient.SqlParameter("@sMaterial", System.Data.SqlDbType.VarChar, 50),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt)});
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
            // sqldaListaProgInfCliente_SAP
            // 
            this.sqldaListaProgInfCliente_SAP.SelectCommand = this.sqlSelectCommandListaProgInfporCliente_SAP;
            this.sqldaListaProgInfCliente_SAP.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaProgInf_porCliente_SAP", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iIdCliente", "iIdCliente"),
                        new System.Data.Common.DataColumnMapping("iIdCentro", "iIdCentro"),
                        new System.Data.Common.DataColumnMapping("sNombre", "sNombre")})});
            // 
            // sqlSelectCommandListaProgInfporCliente_SAP
            // 
            this.sqlSelectCommandListaProgInfporCliente_SAP.CommandText = "[ListaProgInf_porCliente_SAP]";
            this.sqlSelectCommandListaProgInfporCliente_SAP.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommandListaProgInfporCliente_SAP.Connection = this.sqlConn;
            this.sqlSelectCommandListaProgInfporCliente_SAP.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4)});
            // 
            // sqlGetImporteMedioPedido
            // 
            this.sqlGetImporteMedioPedido.CommandText = "GetImporteMedioPedidos";
            this.sqlGetImporteMedioPedido.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlGetImporteMedioPedido.Connection = this.sqlConn;
            this.sqlGetImporteMedioPedido.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@dFechaIni", System.Data.SqlDbType.DateTime),
            new System.Data.SqlClient.SqlParameter("@dFechaFin", System.Data.SqlDbType.DateTime),
            new System.Data.SqlClient.SqlParameter("@Ret", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Output, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@Ret2", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Output, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@Ret3", System.Data.SqlDbType.Float, 8, System.Data.ParameterDirection.Output, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null)});
            // 
            // sqlCmdSetContactosClientesSAP
            // 
            this.sqlCmdSetContactosClientesSAP.CommandText = "[SetContactosClientesSAP]";
            this.sqlCmdSetContactosClientesSAP.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdSetContactosClientesSAP.Connection = this.sqlConn;
            this.sqlCmdSetContactosClientesSAP.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdContacto", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sNombre", System.Data.SqlDbType.VarChar, 100),
            new System.Data.SqlClient.SqlParameter("@sIdCargoContacto", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@dFAR", System.Data.SqlDbType.VarChar, 20),
            new System.Data.SqlClient.SqlParameter("@dFBR", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt, 2),
            new System.Data.SqlClient.SqlParameter("@sSWIFT", System.Data.SqlDbType.VarChar, 100)});
            // 
            // sqlCmdSetProgInfClientesSAP
            // 
            this.sqlCmdSetProgInfClientesSAP.CommandText = "[SetProgInfClientesSAP]";
            this.sqlCmdSetProgInfClientesSAP.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdSetProgInfClientesSAP.Connection = this.sqlConn;
            this.sqlCmdSetProgInfClientesSAP.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdCentro", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@dFAR", System.Data.SqlDbType.VarChar, 20),
            new System.Data.SqlClient.SqlParameter("@dFBR", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt, 2)});
            // 
            // sqlCmdGetRegionClienteSAP
            // 
            this.sqlCmdGetRegionClienteSAP.CommandText = "[GetRegionClienteSAP]";
            this.sqlCmdGetRegionClienteSAP.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdGetRegionClienteSAP.Connection = this.sqlConn;
            this.sqlCmdGetRegionClienteSAP.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sRegion", System.Data.SqlDbType.VarChar, 50, System.Data.ParameterDirection.Output, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null)});
            // 
            // sqldaRegion
            // 
            this.sqldaRegion.SelectCommand = this.sqlCmdGetRegionClienteSAP;
            this.sqldaRegion.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Region", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("spais", "spais")})});
            // 
            // dsClientes1
            // 
            this.dsClientes1.DataSetName = "dsClientes";
            this.dsClientes1.Locale = new System.Globalization.CultureInfo("en-US");
            this.dsClientes1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            // sqldaListaTarjetasCliente
            // 
            this.sqldaListaTarjetasCliente.SelectCommand = this.sqlCmdListaTarjetasCliente;
            this.sqldaListaTarjetasCliente.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaTarjetasCliente", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("sIdCliente", "sIdCliente"),
                        new System.Data.Common.DataColumnMapping("iIdCliente", "iIdCliente"),
                        new System.Data.Common.DataColumnMapping("sNombre", "sNombre"),
                        new System.Data.Common.DataColumnMapping("sIdMaterial", "sIdMaterial"),
                        new System.Data.Common.DataColumnMapping("sMaterial", "sMaterial"),
                        new System.Data.Common.DataColumnMapping("dFecAsignacion", "dFecAsignacion"),
                        new System.Data.Common.DataColumnMapping("dFecUso", "dFecUso"),
                        new System.Data.Common.DataColumnMapping("sIdProducto", "sIdProducto"),
                        new System.Data.Common.DataColumnMapping("producto", "producto"),
                        new System.Data.Common.DataColumnMapping("iUnidadesMin", "iUnidadesMin"),
                        new System.Data.Common.DataColumnMapping("fBrutoMin", "fBrutoMin"),
                        new System.Data.Common.DataColumnMapping("dIniValidez", "dIniValidez"),
                        new System.Data.Common.DataColumnMapping("dFinValidez", "dFinValidez"),
                        new System.Data.Common.DataColumnMapping("NombreCampanya", "NombreCampanya")})});
            // 
            // sqlCmdListaTarjetasCliente
            // 
            this.sqlCmdListaTarjetasCliente.CommandText = "[ListaTarjetasCliente]";
            this.sqlCmdListaTarjetasCliente.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdListaTarjetasCliente.Connection = this.sqlConn;
            this.sqlCmdListaTarjetasCliente.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@sIdCliente", System.Data.SqlDbType.VarChar, 20)});
            // 
            // sqlCmdSetUsoTarjetasCliente
            // 
            this.sqlCmdSetUsoTarjetasCliente.CommandText = "[SetUsoTarjetasCliente]";
            this.sqlCmdSetUsoTarjetasCliente.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdSetUsoTarjetasCliente.Connection = this.sqlConn;
            this.sqlCmdSetUsoTarjetasCliente.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@sIdCliente", System.Data.SqlDbType.VarChar, 20),
            new System.Data.SqlClient.SqlParameter("@sIdMaterial", System.Data.SqlDbType.VarChar, 18),
            new System.Data.SqlClient.SqlParameter("@dFecAsignacion", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@dFecUso", System.Data.SqlDbType.DateTime, 8)});
            // 
            // sqldaListaProductos
            // 
            this.sqldaListaProductos.SelectCommand = this.sqlCmdListaProductos;
            this.sqldaListaProductos.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaProductos", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("sIdProducto", "sIdProducto"),
                        new System.Data.Common.DataColumnMapping("sDescripcion", "sDescripcion")})});
            // 
            // sqlCmdListaProductos
            // 
            this.sqlCmdListaProductos.CommandText = "ListaProductos";
            this.sqlCmdListaProductos.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdListaProductos.Connection = this.sqlConn;
            // 
            // sqldaAccMarkExcluidas
            // 
            this.sqldaAccMarkExcluidas.SelectCommand = this.sqlCmdAccMarkExcluidas;
            this.sqldaAccMarkExcluidas.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "AccMarkExcluidas", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iIdAccion1", "iIdAccion1"),
                        new System.Data.Common.DataColumnMapping("iIdAccion2", "iIdAccion2"),
                        new System.Data.Common.DataColumnMapping("iEstado", "iEstado")})});
            // 
            // sqlCmdAccMarkExcluidas
            // 
            this.sqlCmdAccMarkExcluidas.CommandText = "GetAccMarkExcluidas";
            this.sqlCmdAccMarkExcluidas.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdAccMarkExcluidas.Connection = this.sqlConn;
            this.sqlCmdAccMarkExcluidas.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null)});
            // 
            // sqldaListaMaterialesBloqueados
            // 
            this.sqldaListaMaterialesBloqueados.SelectCommand = this.sqlCmdListaMaterialesBloqueados;
            this.sqldaListaMaterialesBloqueados.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaMaterialesBloqueados", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("sIdMaterial", "sIdMaterial")})});
            // 
            // sqlCmdListaMaterialesBloqueados
            // 
            this.sqlCmdListaMaterialesBloqueados.CommandText = "[ListaMaterialesBloqueados]";
            this.sqlCmdListaMaterialesBloqueados.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdListaMaterialesBloqueados.Connection = this.sqlConn;
            this.sqlCmdListaMaterialesBloqueados.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@sIdTipoPedido", System.Data.SqlDbType.VarChar, 4),
            new System.Data.SqlClient.SqlParameter("@iIdDelegado", System.Data.SqlDbType.Int, 4)});
            // 
            // sqldaListaTiposPedidoCompromiso
            // 
            this.sqldaListaTiposPedidoCompromiso.SelectCommand = this.sqlCmdListaTiposPedidoCompromiso;
            this.sqldaListaTiposPedidoCompromiso.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaTiposPedidoCompromiso", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("sValor", "sValor"),
                        new System.Data.Common.DataColumnMapping("sLiteral", "sLiteral")})});
            // 
            // sqlCmdListaTiposPedidoCompromiso
            // 
            this.sqlCmdListaTiposPedidoCompromiso.CommandText = "[ListaTiposPedidoCompromiso]";
            this.sqlCmdListaTiposPedidoCompromiso.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdListaTiposPedidoCompromiso.Connection = this.sqlConn;
            this.sqlCmdListaTiposPedidoCompromiso.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null)});
            // 
            // sqldaListaTiposGestionCompromiso
            // 
            this.sqldaListaTiposGestionCompromiso.SelectCommand = this.sqlCmdListaTiposGestionCompromiso;
            this.sqldaListaTiposGestionCompromiso.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaTiposGestionCompromiso", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("sValor", "sValor"),
                        new System.Data.Common.DataColumnMapping("sLiteral", "sLiteral")})});
            // 
            // sqlCmdListaTiposGestionCompromiso
            // 
            this.sqlCmdListaTiposGestionCompromiso.CommandText = "[ListaTiposGestionCompromiso]";
            this.sqlCmdListaTiposGestionCompromiso.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdListaTiposGestionCompromiso.Connection = this.sqlConn;
            this.sqlCmdListaTiposGestionCompromiso.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null)});
            // 
            // sqldaListaMatsZMKT
            // 
            this.sqldaListaMatsZMKT.SelectCommand = this.sqlCmdListaMatsZMKT;
            this.sqldaListaMatsZMKT.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaMatsZMKT", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("sIdMaterial", "sIdMaterial"),
                        new System.Data.Common.DataColumnMapping("sMaterial", "sMaterial"),
                        new System.Data.Common.DataColumnMapping("sCodNacional", "sCodNacional")})});
            // 
            // sqlCmdListaMatsZMKT
            // 
            this.sqlCmdListaMatsZMKT.CommandText = "[ListaMatsZMKT]";
            this.sqlCmdListaMatsZMKT.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdListaMatsZMKT.Connection = this.sqlConn;
            this.sqlCmdListaMatsZMKT.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null)});
            // 
            // sqldaCP
            // 
            this.sqldaCP.SelectCommand = this.sqlCmdGetCPClienteSAP;
            this.sqldaCP.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "CP", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("sCP", "sCP")})});
            // 
            // sqlCmdGetCPClienteSAP
            // 
            this.sqlCmdGetCPClienteSAP.CommandText = "[GetCPClienteSAP]";
            this.sqlCmdGetCPClienteSAP.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdGetCPClienteSAP.Connection = this.sqlConn;
            this.sqlCmdGetCPClienteSAP.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sCP", System.Data.SqlDbType.VarChar, 5, System.Data.ParameterDirection.Output, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null)});
            // 
            // sqldaListaAccionesAbiertasClientee
            // 
            this.sqldaListaAccionesAbiertasClientee.SelectCommand = this.sqlCmdListaAccionesAbiertasCliente;
            this.sqldaListaAccionesAbiertasClientee.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaAccionesAbiertasCliente", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iIdCliente", "iIdCliente"),
                        new System.Data.Common.DataColumnMapping("sIdCliente", "sIdCliente"),
                        new System.Data.Common.DataColumnMapping("sNombre", "sNombre"),
                        new System.Data.Common.DataColumnMapping("sIdAccion", "sIdAccion"),
                        new System.Data.Common.DataColumnMapping("sDescAccion", "sDescAccion"),
                        new System.Data.Common.DataColumnMapping("iUnidades", "iUnidades")})});
            // 
            // sqlCmdListaAccionesAbiertasCliente
            // 
            this.sqlCmdListaAccionesAbiertasCliente.CommandText = "[ListaAccionesAbiertasCliente]";
            this.sqlCmdListaAccionesAbiertasCliente.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdListaAccionesAbiertasCliente.Connection = this.sqlConn;
            this.sqlCmdListaAccionesAbiertasCliente.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@sIdCliente", System.Data.SqlDbType.VarChar, 20)});
            // 
            // sqldaCodsAccMark
            // 
            this.sqldaCodsAccMark.SelectCommand = this.sqlCmdListaCodsAccMark;
            this.sqldaCodsAccMark.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaCodigosAccMarkPicking", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iIdAccion", "iIdAccion"),
                        new System.Data.Common.DataColumnMapping("sIdAccion", "sIdAccion")})});
            // 
            // sqlCmdListaCodsAccMark
            // 
            this.sqlCmdListaCodsAccMark.CommandText = "[ListaCodigosAccMarkPicking]";
            this.sqlCmdListaCodsAccMark.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdListaCodsAccMark.Connection = this.sqlConn;
            this.sqlCmdListaCodsAccMark.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@sIdTipoPedido", System.Data.SqlDbType.VarChar, 4)});
            // 
            // frmPedidos
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 19);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.ClientSize = new System.Drawing.Size(1510, 792);
            this.Controls.Add(this.ucBotoneraSecundaria1);
            this.Controls.Add(this.pnlCabeceraPedido);
            this.Controls.Add(this.pnlLineaPedido);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPedidos";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestión de pedidos";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmPedidos_Closing);
            this.Load += new System.EventHandler(this.frmPedidos_Load);
            this.pnlLineaPedido.ResumeLayout(false);
            this.tabPedido.ResumeLayout(false);
            this.tabPageLineasPedido.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLineas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsMateriales1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsMateriales1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownA)).EndInit();
            this.pnlSeleccionMateriales.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listaCampanyasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsFormularios1)).EndInit();
            this.tabPageAccMark.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAccMark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAccionesMarketing1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dvTiposPosPedidoSAP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dvLineasPedido)).EndInit();
            this.pnlCabeceraPedido.ResumeLayout(false);
            this.pnlCabeceraPedido.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnCompromiso.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dvTipoPedido)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPedidos1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listaAccionesMarketingBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsClientes1)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private void frmPedidos_Load(object sender, System.EventArgs e)
        {
            //lblAvisoVersion.Text = System.Configuration.ConfigurationManager.AppSettings["AvisoVersion"].ToString(); 

            GESTCRM.Utiles.Formato_Formulario(this);

            if (this.Parent == null)
                this.WindowState = FormWindowState.Normal;

            _initialSelectedDateVigencia = dtpFechaPref.Value;

            dtLineasPedido = new dsMateriales.ListaLineasPedidoDataTable();
            dtLineasAvisoMUV = new dsMateriales.ListaAvisoMUVDataTable();

            //---- GSG (13/09/2016) Todo esto ahora al seleccionar pestaña
            /*
            //---- GSG CECL 19/05/2016
            if (System.Configuration.ConfigurationManager.AppSettings["TipoDelegadoPedidosCentral"].ToString() == Comun.K_CECL)
            {
                sqlDataListaAccionesMarketing.SelectCommand = sqlCommand1CECL;
                chkVisita.Enabled = false;
            }
            else
            {
                sqlDataListaAccionesMarketing.SelectCommand = sqlCommand1;
                chkVisita.Enabled = true;
            }
            //---- FI GSG CECL

            //Inicialitza grid Acciones Marketing
            this.sqlDataListaAccionesMarketing.SelectCommand.Parameters["@sIdTipoAccion"].Value = "3";
            this.sqlDataListaAccionesMarketing.Fill(dsAccionesMarketing1);
            UpdateDataGridView("");
            */

            //---- GSG CECL 19/05/2016
            if (System.Configuration.ConfigurationManager.AppSettings["TipoDelegadoPedidosCentral"].ToString() == Comun.K_CECL)
                sqldaListaLineasPedido.SelectCommand.CommandText = "[ListaLineasPedidoCECL]";
            else
                sqldaListaLineasPedido.SelectCommand.CommandText = "[ListaLineasPedido]";
            //---- FI GSG CECL

            ObtenirMaterialsNoRentabilitat();

            ObtenirCampanyasNoRentabilitat();

            ObtenirMaterialsNoMargen(); //---- GSG (29/09/2020) PUNTOS


            _sTipoPedidoOld = cboTipoPedido.SelectedValue.ToString();

            //---- GSG (13/09/2016)
            GetListaProductos();
            _listaExclusion = GetAccMarkExcluidas();

            //---- GSG (06/03/2021)
            _listaAccMarkProfitPlus = GetCodsAccMarkPedido(_sTipoPedidoOld);



            if (TipoAcceso == (int)acceso.CONSULTA || TipoAcceso == (int)acceso.MODIFICACION)
            {
                lblTitulo.Text = "Edición de pedido";

                dsMateriales1.ListaLineasPedido.Rows.Clear();
                sqldaListaLineasPedido.SelectCommand.Parameters["@sIdPedido"].Value = sIdPedido;

                Application.DoEvents();
                sqldaListaLineasPedido.Fill(dtLineasPedido);
                Application.DoEvents();

                dataGridViewLineas.DataSource = dtLineasPedido;

                //Inicializar NewIdGrupoMat y NewIdLinea
                if (dtLineasPedido.Rows.Count > 0)
                {
                    dsMateriales.ListaLineasPedidoRow row = (dsMateriales.ListaLineasPedidoRow)dtLineasPedido.Rows[dtLineasPedido.Rows.Count - 1];
                    NewIdLinea = row.iIdLinea;
                    NewIdGrupoMat = row.idGrupoMat;
                }

                Application.DoEvents();
                FormatDataGridLineas();
                Application.DoEvents();

                cargar_datos();

                lblCounter.Text = this.dtLineasPedido.DefaultView.Count.ToString();

                // Guarda la cantidad inicial de cada material del pedido para poder controlar correctamente si se superan las unidades mínimas requeridas de cada material
                if (TipoAcceso == (int)acceso.MODIFICACION)
                {
                    GetLineasPedidoOriginal();

                    // Si el pedido ya estaba guardado y se ha eliminado una tarjeta en el pedido, hay que reactivar la tarjeta como no usada
                    // Al cargar los datos iniciales guardamos las tarjetas que lleva el pedido
                    _lTarjetasClientePedidoOriginal.Clear();
                    _lTarjetasClientePedidoOriginal = GetTargetasClienteEnOriginal();

                    AvisoTarjetasCliente(this.txtClienteSAP.Text);
                    //---- GSG (13/03/2019)
                    //---- GSG (19/09/2017)
                    //AvisoProximoObjetivo(this.txtClienteSAP.Text);
                    AvisoProximoObjetivo(this.txtClienteSAP.Text, dtpFechaPedido.Value);
                    AvisoAccionesAbiertasCliente(this.txtClienteSAP.Text); //---- GSG (19/09/2017)
                }
                else
                {
                    Utiles.pintaLineasGrid(dataGridViewLineas, Color.FromArgb(255, 180, 255), "ColCantidad");
                }
            }
            else
            {
                NewIdGrupoMat = 0;
                NewIdLinea = 0;

                lblTitulo.Text = "Creación de pedido";

                if (_bEsCopia)
                {
                    dsMateriales1.ListaLineasPedido.Rows.Clear();
                    sqldaListaLineasPedido.SelectCommand.Parameters["@sIdPedido"].Value = sIdPedido;

                    Application.DoEvents();
                    sqldaListaLineasPedido.Fill(dtLineasPedido);
                    Application.DoEvents();

                    if (_bEsFlexible)
                    {
                        // Mirar si la campaña flexible está en el combo de campañas                    
                        if (cBoxCampanyas.FindStringExact("Flexible") >= 0)
                        {
                            //---- GSG CECL 19/05/2016
                            if (System.Configuration.ConfigurationManager.AppSettings["TipoDelegadoPedidosCentral"].ToString() == Comun.K_CECL)
                                sqlDaListaMateriales.SelectCommand.CommandText = "[ListaMaterialesDesCampCECL]";
                            else
                                sqlDaListaMateriales.SelectCommand.CommandText = "[ListaMaterialesDesCamp]";
                            //---- FI GSG CECL

                            // Obtener código de la campaña
                            string sidCampFlexible = Utiles.CodigoCampanya("Flexible");
                            // Cargar los materiales de la flexible
                            this.sqlDaListaMateriales.SelectCommand.Parameters["@iIdCamp"].Value = sidCampFlexible;
                            this.sqlDaListaMateriales.Fill(dsMateriales1);
                            // Poner campanya flexible a todas las líneas y descuentos a 0 (Mantener descuento a partir de GSG (10/03/2016))
                            // Si un material no está en la flexible quitarlo del pedido
                            for (int i = dtLineasPedido.Rows.Count - 1; i >= 0; i--)
                            {
                                dsMateriales.ListaLineasPedidoRow row = (dsMateriales.ListaLineasPedidoRow)dtLineasPedido.Rows[i];
                                if (dsMateriales1.ListaMateriales.Select("sIdMaterial = '" + row.sIdMaterial + "'").Length == 0)
                                    dtLineasPedido.Rows.Remove(row);
                                else
                                {
                                    //---- GSG (10/03/2016) A partir de ahora sí cargamos los descuentos en este caso (no recordamos el motivo por el cual lo hicimos así)
                                    //row.fDescuento = "0";
                                    row.idCampanya = sidCampFlexible;
                                    row.NombreCampanya = "FLEXIBLE";
                                }
                            }
                        }
                        else
                            dtLineasPedido.Clear();
                        Application.DoEvents();
                    }

                    // Eliminar los materiales bloqueados
                    string[] bloqueados = new string[2000];

                    //---- GSG (02/02/2021)
                    //bloqueados = GetMaterialesBloqueados(_sTipoPedidoNew);
                    if (_sTipoPedidoNew != null && _sTipoPedidoNew != "")
                        bloqueados = GetMaterialesBloqueados(_sTipoPedidoNew);
                    else
                        bloqueados = GetMaterialesBloqueados(_sTipoPedido);


                    if (bloqueados.Length > 0)
                    {
                        bool bBorradas = false;

                        for (int i = dtLineasPedido.Rows.Count - 1; i >= 0; i--)
                        {
                            dsMateriales.ListaLineasPedidoRow row = (dsMateriales.ListaLineasPedidoRow)dtLineasPedido.Rows[i];
                            if (Comun.IsInTheArray(row.sIdMaterial, bloqueados))
                            {
                                dtLineasPedido.Rows.Remove(row);
                                bBorradas = true;
                            }
                        }

                        dtLineasPedido.AcceptChanges();

                        //---- GSG (02/02/2021)
                        // Aviso de que se han eliminado algunos materiales porque actualmente están bloqueados
                        if (bBorradas)
                            Mensajes.ShowInformation("Se han eliminado algunas líneas del pedido por estar actualmente bloqueadas.");
                    }


                    //----- GSG (05/07/2017)
                    // Eliminar líneas duplicadas 
                    // (en principio no pasa pero se pueden estar copiando pedidos antiguos o puede haberse generado un pedido con campañas que admiten duplicidad y después haber cambiado la campaña)

                    // Puede pasar que las unidades o el descuento del material duplicado sea distinto, nos quedaremos con el primero que llegue

                    dtLineasPedido.DefaultView.Sort = "sIdMaterial";

                    string codiAnt = "";

                    for (int i = dtLineasPedido.Rows.Count - 1; i >= 0; i--)
                    {
                        dsMateriales.ListaLineasPedidoRow row = (dsMateriales.ListaLineasPedidoRow)dtLineasPedido.Rows[i];
                        if (row.sIdMaterial == codiAnt)
                            dtLineasPedido.Rows.Remove(row);
                        else
                            codiAnt = row.sIdMaterial;
                    }

                    dtLineasPedido.AcceptChanges();


                    dataGridViewLineas.DataSource = dtLineasPedido;

                    //Inicializar NewIdGrupoMat y NewIdLinea
                    if (dtLineasPedido.Rows.Count > 0)
                    {
                        dsMateriales.ListaLineasPedidoRow row = (dsMateriales.ListaLineasPedidoRow)dtLineasPedido.Rows[dtLineasPedido.Rows.Count - 1];
                        NewIdLinea = row.iIdLinea;
                        NewIdGrupoMat = row.idGrupoMat;
                    }

                    Application.DoEvents();
                    FormatDataGridLineas();
                    Application.DoEvents();

                    cargar_datos();

                    lblCounter.Text = this.dtLineasPedido.DefaultView.Count.ToString();

                    // Guarda la cantidad inicial de cada material del pedido para poder controlar correctamente si se superan las unidades mínimas requeridas de cada material
                    GetLineasPedidoOriginal();

                    //Cambia el código del pedido puesto que es nuevo
                    sIdPedido = "";

                    GetTarjetasCliente(txtClienteSAP.Text);
                }
                else
                {
                    //---- GSG (05/07/2017)
                    if (txtClienteSAP.Text == "") //---- GSG (27/09/2017)
                    {
                        cBoxCampanyas.Enabled = false;
                        btnBuscarMaterial.Enabled = false;
                    }
                    else //---- GSG (27/09/2017)
                    {
                        cBoxCampanyas.Enabled = true;
                        btnBuscarMaterial.Enabled = true;
                    }

                    foreach (DataGridViewRow row in dataGridViewAccMark.Rows)
                    {
                        row.Cells["selected"].Value = false;
                    }

                    if (cboTipoCampana.SelectedValue != null)
                    {
                        string sIdCampCab = cboTipoCampana.SelectedValue.ToString();
                        _bVerCondPago = GetVerCondPagoCampCab(sIdCampCab);
                        _dFecFact = GetFechaFactSegunCampanyaCab(sIdCampCab);
                        dtpFechaFacturacion.Value = _dFecFact;

                        _sCodPagoFija = GetCondPagoFijaCampCab(sIdCampCab);
                    }

                    ActivarComboCondicionesPago();

                    getDatosClienteIndep();

                    if (txtClienteSAP.Text != "" && txtClienteSAP.Text != null)
                        GetTarjetasCliente(txtClienteSAP.Text);
                }
            }

            if (TipoAcceso == (int)acceso.CONSULTA)
            {
                ColBorrar.Visible = false;
                dataGridViewLineas.ReadOnly = true;
            }


            Inicializar_Botonera();
            Application.DoEvents();

            frmP.Close();

            dataGridViewLineas.Focus();

            if (Comun.IsInTheArray(cboTipoPedido.SelectedValue.ToString(), Configuracion.asPedTransfer))
            {
                label2.Text = "Solicitante:";
                lblDestinatario.Text = "Mayorista:";
            }
            else //directo
            {
                label2.Text = "Dest. Mercancía:";
                lblDestinatario.Text = "Solic./Pagador:";
            }

            //---- GSG (02/02/2021)
            //_iEmailConfOriginal = txtMailConf.Text.Trim();
            //_iEmailFactOriginal = txtMailFact.Text.Trim();



            // Si hay materiales en el pedido que deben llevar el código de vale, perdirlo
            _lMatsConVale = GetMatsConVale();

            //---- GSG (14/10/2016)
            if (cboTipoPedido.SelectedValue.ToString() == Comun.K_TIPOPED_COMPROMISO)
            {
                pnCompromiso.Visible = true;
            }
            else
                pnCompromiso.Visible = false;
        }

        private void Inicializar_Botonera()
        {
            //this.ucBotoneraSecundaria1.btSalir.Click += new EventHandler(btSalir_Click);
            this.ucBotoneraSecundaria1.btSalir.Click += new EventHandler(this.opcion_guardar); //---- GSG (03/07/2019)


            this.ucBotoneraSecundaria1.btGrabar.Click += new EventHandler(this.opcion_guardar);

            if (TipoAcceso == (int)acceso.CONSULTA)
            {
                this.contextMenu1.Dispose();
                this.ucBotoneraSecundaria1.Activar_botonera(true, false, false, false, false, false);
                Utiles.Activar_Panel(this.pnlCabeceraPedido, false);

                this.dataGridViewLineas.Enabled = true;
                Utiles.Activar_Panel(pnlSeleccionMateriales, false);

                btEncuestas.Enabled = false; //---- GSG (03/09/2019)
            }
            else
            {
                this.ucBotoneraSecundaria1.Activar_botonera(true, false, false, false, true, false);

                ucBotoneraSecundaria1.btAPedido.Enabled = false;

                //---- GSG CECL 19/05/2016
                if (System.Configuration.ConfigurationManager.AppSettings["TipoDelegadoPedidosCentral"].ToString() == Comun.K_CECL)
                    ucBotoneraSecundaria1.btAIndicadores.Enabled = false;
                else
                {
                    ucBotoneraSecundaria1.btAIndicadores.Enabled = true;
                    ucBotoneraSecundaria1.btAIndicadores.Click += new EventHandler(btAIndicadores_Click);
                }
            }
        }

        private void init()
        {
            try
            {
                dataGridViewLineas.RowsDefaultCellStyle.SelectionBackColor = Utiles.ColorSelecionFilaDataGrid;

                LlenarCombos();

                if (!_bEsCopia)
                    txbIdPedido.Text = sIdPedido;
                else
                    txbIdPedido.Text = "";

                this.dtpFechaPedido.Value = DateTime.Today;
                this.dtpFechaPref.Value = this.dtpFechaPedido.Value;
                this.dtpFechaFij.Value = this.dtpFechaPref.Value;

                _sDataVencCanviada = "";
                _bDataVencCanviada = false;

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
            catch (Exception ev)
            {
                Mensajes.ShowError("Error en evento frmPedidos_Load " + ev.ToString());
            }
        }

        #region llenar combos
        private void LlenarCombos()
        {
            //Adaptadores llenan los datasets
            dsFormularios1.ListaTiposPedidoSAP.Rows.Clear();
            dsFormularios1.ListaTiposPosPedidoSAP.Rows.Clear();
            dsFormularios1.ListaCampanyas.Rows.Clear();
            //---- GSG (14/10/2016)
            dsFormularios1.ListaTiposPedidoCompromiso.Rows.Clear();
            dsFormularios1.ListaTiposGestionCompromiso.Rows.Clear();

            sqldaListaTiposPedidoSAP.Fill(dsFormularios1.ListaTiposPedidoSAP);
            sqldaListaTiposPosPedidoSAP.Fill(dsFormularios1.ListaTiposPosPedidoSAP);
            //---- GSG (05/07/2017)
            // No hace falta porque si no hay cliente no hay campañas
            //FormatBuscarCampanyas(-1, false, cboTipoPedido.SelectedValue.ToString()); 

            //---- GSG (14/10/2016)
            sqldaListaTiposPedidoCompromiso.Fill(dsFormularios1.ListaTiposPedidoCompromiso);
            sqldaListaTiposGestionCompromiso.Fill(dsFormularios1.ListaTiposGestionCompromiso);


            btnBuscarMaterial.Enabled = cBoxCampanyas.Enabled;

            LlenarComboCampanyasCab();

            this.sqldaListaCondPago.Fill(dsFormularios1.ListaTiposCondicionesPago);
            this.sqldaListaPrioridad.Fill(dsFormularios1.ListaTiposPrioridad);

            dsFormularios1.ListaProgInf.Clear();
            sqldaProgInf.Fill(dsFormularios1.ListaProgInf);
            DataRow fila = dsFormularios1.ListaProgInf.NewRow();
            fila["sValor"] = "-1";
            fila["sLiteral"] = "";
            this.dsFormularios1.ListaProgInf.Rows.InsertAt(fila, 0);
            this.cboProgInf.SelectedValue = "-1";

            //---- GSG (14/10/2016)
            // Llenar combos para pedidos compromiso
            //cboClasico.Items.Add()
        }

        private void LlenarComboCampanyasCab()
        {
            //---- GSG CECL 19/05/2016
            if (System.Configuration.ConfigurationManager.AppSettings["TipoDelegadoPedidosCentral"].ToString() == Comun.K_CECL)
                sqldaListaCampCabecera.SelectCommand = sqlCommand4CECL;
            else
                sqldaListaCampCabecera.SelectCommand = sqlCommand4;
            //---- FI GSG CECL

            dsFormularios1.ListaCampanyasCabecera.Clear();

            sqldaListaCampCabecera.SelectCommand.Parameters["@distinct"].Value = 1;
            sqldaListaCampCabecera.SelectCommand.Parameters["@tipoCampanya"].Value = K_CAB;
            sqldaListaCampCabecera.SelectCommand.Parameters["@sIdDelegado"].Value = iIdDelegado.ToString();
            sqldaListaCampCabecera.SelectCommand.Parameters["@sIdTipoPedido"].Value = cboTipoPedido.SelectedValue.ToString();

            sqldaListaCampCabecera.Fill(dsFormularios1.ListaCampanyasCabecera);

            dtCampanyasCabeceraCompletas = new dsFormularios.ListaCampanyasCabeceraDataTable();
            dtCampanyasCabeceraCompletas.Clear();

            sqldaListaCampCabecera.SelectCommand.Parameters["@distinct"].Value = 0;
            sqldaListaCampCabecera.SelectCommand.Parameters["@tipoCampanya"].Value = K_CAB;
            sqldaListaCampCabecera.SelectCommand.Parameters["@sIdDelegado"].Value = iIdDelegado.ToString();
            sqldaListaCampCabecera.SelectCommand.Parameters["@sIdTipoPedido"].Value = cboTipoPedido.SelectedValue.ToString();

            sqldaListaCampCabecera.Fill(dtCampanyasCabeceraCompletas);
            cboTipoCampana_SelectedIndexChanged(null, null);
        }


        //---- GSG (05/07/2017)
        /*
        private bool LlenarComboCampanyas(int tipo, string campanya, string sIdCampCab, string sTipoPed)
        {
            bool bRet = true; 

            dsFormularios1.ListaCampanyas.Clear();

            if (TipoAcceso == (int)acceso.CONSULTA)
                sqldaListaCampanyas.SelectCommand = sqlCmdListaCampanyasPedInactivo;
            else
                sqldaListaCampanyas.SelectCommand = sqlCmdListaCampanyas;

            sqldaListaCampanyas.SelectCommand.Parameters["@iTipo"].Value = tipo;
            sqldaListaCampanyas.SelectCommand.Parameters["@idCampanya"].Value = campanya;
            sqldaListaCampanyas.SelectCommand.Parameters["@tipoCampanya"].Value = K_LIN;
            sqldaListaCampanyas.SelectCommand.Parameters["@sIdDelegado"].Value = iIdDelegado.ToString();

            if (_bEsCopia && _sTipoPedido != "" && _sTipoPedidoNew == _sTipoPedidoOld) //---- GSG (25/03/2015)
                sqldaListaCampanyas.SelectCommand.Parameters["@sIdTipoPedido"].Value = _sTipoPedido;
            else if (sTipoPed != "")
                    sqldaListaCampanyas.SelectCommand.Parameters["@sIdTipoPedido"].Value = sTipoPed;
                else
                    sqldaListaCampanyas.SelectCommand.Parameters["@sIdTipoPedido"].Value = cboTipoPedido.SelectedValue.ToString();

            sqldaListaCampanyas.SelectCommand.Parameters["@idCampanyaCab"].Value = sIdCampCab;

            sqldaListaCampanyas.Fill(dsFormularios1.ListaCampanyas);

            if (dsFormularios1.ListaCampanyas.Rows.Count > 0) 
            {
                dsFormularios1.ListaCampanyas.DefaultView.RowFilter = "bSeleccionable = 1";
                dsFormularios1.ListaCampanyas.DefaultView.Sort = "NombreCampanya"; 
                cBoxCampanyas.DataSource = dsFormularios1.ListaCampanyas.DefaultView;
                cBoxCampanyas.SelectedIndex = 0; 
            }
            else
            {
                Mensajes.ShowExclamation("No hay campañas disponibles para este tipo de pedido.");
                bRet = false;
            }

            return bRet;
        }

        private bool LlenarComboCampanyas(int tipo, string[] campanyas, string sTipoPed)
        {
            bool bRet = true;

            dsFormularios1.ListaCampanyas.Clear();

            if (TipoAcceso == (int)acceso.CONSULTA)
                sqldaListaCampanyas.SelectCommand = sqlCmdListaCampanyasPedInactivo;
            else
                sqldaListaCampanyas.SelectCommand = sqlCmdListaCampanyas;

            for (int i = 0; i < campanyas.Length; i++)
            {
                sqldaListaCampanyas.SelectCommand.Parameters["@iTipo"].Value = tipo;
                sqldaListaCampanyas.SelectCommand.Parameters["@idCampanya"].Value = campanyas[i];

                sqldaListaCampanyas.SelectCommand.Parameters["@tipoCampanya"].Value = K_LIN;
                sqldaListaCampanyas.SelectCommand.Parameters["@sIdDelegado"].Value = iIdDelegado.ToString();

                if (_bEsCopia && _sTipoPedido != "" && _sTipoPedidoNew == _sTipoPedidoOld)
                    sqldaListaCampanyas.SelectCommand.Parameters["@sIdTipoPedido"].Value = _sTipoPedido;
                else if (sTipoPed != "")
                    sqldaListaCampanyas.SelectCommand.Parameters["@sIdTipoPedido"].Value = sTipoPed;
                else
                    sqldaListaCampanyas.SelectCommand.Parameters["@sIdTipoPedido"].Value = cboTipoPedido.SelectedValue.ToString();


                sqldaListaCampanyas.Fill(dsFormularios1.ListaCampanyas);

                //cambio el tipo para que no rpite las campanyas extras
                tipo = 3;
            }

            if (dsFormularios1.ListaCampanyas.Rows.Count > 0) 
            {
                dsFormularios1.ListaCampanyas.DefaultView.RowFilter = "bSeleccionable = 1";
                dsFormularios1.ListaCampanyas.DefaultView.Sort = "NombreCampanya"; 
                cBoxCampanyas.DataSource = dsFormularios1.ListaCampanyas.DefaultView;

                cBoxCampanyas.SelectedIndex = 0; 
            }
            else
            {
                Mensajes.ShowExclamation("No hay campañas disponibles para este tipo de pedido.");
                bRet = false;
            }

            return bRet;
        }

        */

        private bool LlenarComboCampanyas(string sDelegado, string sTipoPed, int iCliente, string sMayorista)
        {
            bool bRet = true;

            dsFormularios1.ListaCampanyas.Clear();

            if (TipoAcceso == (int)acceso.CONSULTA)
                sqldaListaCampanyas.SelectCommand = sqlCmdListaCampanyasPedInactivoNEW;
            else
                sqldaListaCampanyas.SelectCommand = sqlCmdListaCampanyasNEW;


            sqldaListaCampanyas.SelectCommand.Parameters["@sIdDelegado"].Value = sDelegado;

            if (_bEsCopia && _sTipoPedido != "" && _sTipoPedidoNew == _sTipoPedidoOld)
                sqldaListaCampanyas.SelectCommand.Parameters["@sIdTipoPedido"].Value = _sTipoPedido;
            else if (sTipoPed != "")
                sqldaListaCampanyas.SelectCommand.Parameters["@sIdTipoPedido"].Value = sTipoPed;
            else
                sqldaListaCampanyas.SelectCommand.Parameters["@sIdTipoPedido"].Value = cboTipoPedido.SelectedValue.ToString();

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
                Mensajes.ShowExclamation("No hay campañas disponibles para este pedido.");
                bRet = false;
            }

            return bRet;
        }


        #endregion

        private void cargar_datos()
        {
            if (sqlConn.State.ToString() == "Closed")
                sqlConn.Open();

            SqlDataReader drCabPedido;
            drCabPedido = null;

            try
            {


                //---- GSG CECL 19/05/2016
                if (System.Configuration.ConfigurationManager.AppSettings["TipoDelegadoPedidosCentral"].ToString() == Comun.K_CECL)
                    sqlCmdCargaPedido.CommandText = "[ListaBuscaPedidosCECL]";
                else
                    sqlCmdCargaPedido.CommandText = "[ListaBuscaPedidos]";
                //---- FI GSG CECL 

                try
                {
                    sqlCmdCargaPedido.Parameters["@iIdDelegado"].Value = -1;
                    sqlCmdCargaPedido.Parameters["@sIdCliente"].Value = null;
                    sqlCmdCargaPedido.Parameters["@sIdDestinatario"].Value = null;
                    sqlCmdCargaPedido.Parameters["@sIdTipoCampanya"].Value = "-2";
                    sqlCmdCargaPedido.Parameters["@dFechaPedido"].Value = null;
                    sqlCmdCargaPedido.Parameters["@sIdPedido"].Value = sIdPedido;
                    sqlCmdCargaPedido.Parameters["@sIdTipoPedido"].Value = null;
                    sqlCmdCargaPedido.Parameters["@counter"].Value = 0;
                    drCabPedido = sqlCmdCargaPedido.ExecuteReader();
                    Application.DoEvents();
                }
                catch (Exception excConf)
                {
                    Mensajes.ShowErrorField(excConf.Message);
                    sqlConn.Close();
                    return;
                }

                string pedido = "";

                if (drCabPedido.Read())
                {
                    if (!_bEsCopia)
                    {
                        dtpFechaPedido.Value = Convert.ToDateTime(drCabPedido[7].ToString());
                        dtpFechaPref.Value = Convert.ToDateTime(drCabPedido[8].ToString());
                        dtpFechaFij.Value = Convert.ToDateTime(drCabPedido[9].ToString());
                    }
                    else
                    {
                        dtpFechaPedido.Value = DateTime.Today;
                        dtpFechaPref.Value = this.dtpFechaPedido.Value;
                        dtpFechaFij.Value = this.dtpFechaPref.Value;
                    }

                    txbObservaciones.Text = drCabPedido[14].ToString();

                    string sDataVencPedido = drCabPedido[34].ToString();

                    string TipoPedido = drCabPedido[1].ToString();
                    if (TipoPedido == "ZTRW")
                        TipoPedido = "ZTRA";
                    else if (TipoPedido == "ZDIW")
                        TipoPedido = "ZDIR";

                    if (!_bEsCopia) // Añade condición para mantener el estado de pedido nuevo
                    {
                        //bEnviadoCEN
                        if (drCabPedido[19].ToString() == "1")
                            TipoAcceso = (int)acceso.CONSULTA;
                    }

                    Application.DoEvents();

                    v_sIdCampanya = Convert.ToString((drCabPedido[12] == null) ? "0" : drCabPedido[12]);

                    cboTipoPedido.SelectedIndexChanged -= new System.EventHandler(this.cboTipoPedido_SelectedIndexChanged);

                    cboTipoPedido.SelectedValue = TipoPedido;

                    if (cboTipoPedido.SelectedValue == null)
                        cboTipoPedido.SelectedIndex = 0;

                    cboTipoPedido.SelectedIndexChanged += new System.EventHandler(this.cboTipoPedido_SelectedIndexChanged);


                    txtDestinatarioSAP.TextChanged -= new System.EventHandler(this.txtDestinatarioSAP_TextChanged); //---- GSG (05/07/2017)

                    if (Comun.IsInTheArray(TipoPedido, Configuracion.asPedTransfer))
                    {
                        txtClienteSAP.Text = drCabPedido[3].ToString();
                        txtDestinatarioSAP.Text = drCabPedido[5].ToString();
                        txtsCliente.Text = drCabPedido[4].ToString();
                        this.txtsDestinatario.Text = drCabPedido[6].ToString();
                        this.iIdCliente = Convert.ToInt32(drCabPedido[16].ToString());
                        this.iIdDestinatario = Convert.ToInt32(drCabPedido[17].ToString());
                    }
                    else
                    {
                        txtClienteSAP.Text = drCabPedido[5].ToString();
                        txtDestinatarioSAP.Text = drCabPedido[3].ToString();
                        txtsCliente.Text = drCabPedido[6].ToString();
                        this.txtsDestinatario.Text = drCabPedido[4].ToString();
                        this.iIdCliente = Convert.ToInt32(drCabPedido[17].ToString());
                        this.iIdDestinatario = Convert.ToInt32(drCabPedido[16].ToString());
                    }

                    txtDestinatarioSAP.TextChanged += new System.EventHandler(this.txtDestinatarioSAP_TextChanged); //---- GSG (05/07/2017)

                    DataRow[] rows = dtCampanyasCabeceraCompletas.Select(
                        String.Format("idCampanya='{0}' AND sIdTipoPedido='{1}'", v_sIdCampanya, TipoPedido));

                    if (rows.Length > 0) //Hay al menos una fila
                    {
                        dsFormularios.ListaCampanyasCabeceraRow row = (dsFormularios.ListaCampanyasCabeceraRow)rows[0];
                        bEsBrut = false;
                        ImporteMinPedido = row.fImporteMinObli;
                        //si hi ha brut mana, mai els dos serán 0 però "Sin campanya" té els dos a 0 i ha de ser net
                        if (row.fImporteMinObliBruto > 0)
                        {
                            ImporteMinPedido = row.fImporteMinObliBruto;
                            bEsBrut = true;
                        }

                        //Mínim unitats
                        iMinimUnitatsPedido = row.iNumMinUnidades;
                    }
                    else
                    {
                        ImporteMinPedido = 0.0;
                        iMinimUnitatsPedido = 0;
                    }

                    DtoGeneral = Convert.ToDouble(drCabPedido["fDescuentoCampanya"].ToString());
                    txbDtoGeneral.Text = String.Format("{0:#,0.##}%", DtoGeneral);

                    if (DtoGeneral > 0)
                    {
                        lblDescGen.ForeColor = Color.Red;
                        txbDtoGeneral.ForeColor = Color.Red;
                        txbDtoGeneral.Font = BoldFont;
                    }
                    else
                    {
                        lblDescGen.ForeColor = Color.Black;
                        txbDtoGeneral.ForeColor = Color.Black;
                        txbDtoGeneral.Font = RegularFont;
                    }

                    ImportePedido = Convert.ToDouble(drCabPedido["fImporte"].ToString());
                    ImportePedidoBruto = Convert.ToDouble(drCabPedido["fImporteBruto"].ToString());
                    DescuentoMedio = Convert.ToDouble(drCabPedido["fDescuento"].ToString());

                    txbImporte.Text = ImportePedido.ToString("C2");
                    txbDto.Text = String.Format("{0:#,0.##}%", DescuentoMedio);
                    txbImporteBruto.Text = ImportePedidoBruto.ToString("C2");

                    //Actualitza acció marketing
                    //---- GSG (08/10/2012)
                    //Ara hi pot haber més d'una acció i no està a la capçalera sino a la taula PedAcciones
                    //Obtindré les accions més tard quan ja estigui tancat el datareader actual
                    //if (drCabPedido["iIdAccion"] != DBNull.Value)
                    //{
                    //    UpdateDataGridView(drCabPedido["iIdAccion"].ToString()); 
                    //}                    
                    if (TipoAcceso == (int)acceso.CONSULTA)
                    {
                        dataGridViewAccMark.ReadOnly = true;
                    }

                    txtRentabilidad.Text = drCabPedido["fRentabilidad"].ToString();
                    txbRentabilidad.Text = drCabPedido["sDescripcionRentabilidad"].ToString();


                    pedido = drCabPedido["sIdPedido"].ToString();

                    string prioridad = drCabPedido["sPrioridad"].ToString();

                    if (prioridad != null && prioridad != "")
                    {
                        int index = 0;
                        foreach (DataRowView dr in cboPrioridad.Items)
                        {
                            if (dr["sValor"].ToString() == prioridad)
                            {
                                cboPrioridad.SelectedIndex = index;
                                break;
                            }
                            index++;
                        }
                    }
                    else
                        cboPrioridad.SelectedIndex = 0;

                    //Antes de cerrar datareader para después poder establecer el valor 
                    string condPago = null;
                    if (drCabPedido["sCondPago"] != null)
                        condPago = drCabPedido["sCondPago"].ToString();

                    //DateTime fechaFacturacion = DateTime.MaxValue;
                    DateTime fechaFacturacion = DateTime.Parse("31/12/9998");

                    if (drCabPedido["dFechaFacturacion"].GetType().Name != "DBNull")
                        fechaFacturacion = Convert.ToDateTime(drCabPedido["dFechaFacturacion"].ToString());
                    _dFecFactPedidoCargado = fechaFacturacion;

                    //---- GSG (14/10/2016)
                    if (drCabPedido["sTipoPedidoCompromiso"] != null && drCabPedido["sTipoPedidoCompromiso"] != System.DBNull.Value)
                        cboClasico.SelectedValue = drCabPedido["sTipoPedidoCompromiso"].ToString();
                    if (drCabPedido["sTipoGestionCompromiso"] != null && drCabPedido["sTipoPedidoCompromiso"] != System.DBNull.Value)
                        cboIndividual.SelectedValue = drCabPedido["sTipoGestionCompromiso"].ToString();


                    drCabPedido.Close();
                    Application.DoEvents();


                    //---- ho poso aquí perquè LlenarComboCampanyasCab necessita el combo correcte de campanyes
                    //--- GSG (05/07/2017) -- ja no, però ho deixo aquí

                    if (TipoAcceso != (int)acceso.INSERCION)
                    {
                        //--- GSG (05/07/2017)
                        //FormatBuscarCampanyas(iIdCliente, true, cboTipoPedido.SelectedValue.ToString());
                        FormatBuscarCampanyas(iIdCliente, true, cboTipoPedido.SelectedValue.ToString(), txtDestinatarioSAP.Text.Trim());


                        pintaRentabilidadAnual(false, DateTime.Today);
                    }

                    //---- Necessito el datareader tancat
                    LlenarComboCampanyasCab();
                    this.cboTipoCampana.SelectedIndexChanged -= new System.EventHandler(this.cboTipoCampana_SelectedIndexChanged);
                    this.cboTipoCampana.SelectedValueChanged -= new System.EventHandler(this.cboTipoCampana_SelectedValueChanged);
                    cboTipoCampana.SelectedValue = v_sIdCampanya;
                    this.cboTipoCampana.SelectedIndexChanged += new System.EventHandler(this.cboTipoCampana_SelectedIndexChanged);
                    this.cboTipoCampana.SelectedValueChanged += new System.EventHandler(this.cboTipoCampana_SelectedValueChanged);

                    //Aquí perquè necesito que el datareader estigui tancat
                    if (!(Comun.IsInTheArray(cboTipoPedido.SelectedValue.ToString(), Configuracion.asPedTransfer) || cboTipoPedido.SelectedValue.ToString() == "ZCR")) //No Tranfer o abono
                    {
                        _bVerCondPago = GetVerCondPagoCampCab(v_sIdCampanya);
                        _dFecFact = GetFechaFactSegunCampanyaCab(v_sIdCampanya);
                        _sCodPagoFija = GetCondPagoFijaCampCab(v_sIdCampanya);

                        if (_bVerCondPago)
                        {
                            if (condPago != null && condPago != "")
                                cboCondicionPago.SelectedValue = condPago;
                            else
                                cboCondicionPago.SelectedValue = "-1";
                        }
                        else if (_sCodPagoFija != "")
                        {
                            txbCodPagoFija.Text = _sCodPagoFija;
                        }
                        else
                            dtpFechaFacturacion.Value = _dFecFactPedidoCargado;
                    }
                    //---- GSG (11/11/2016)
                    else if (cboTipoPedido.SelectedValue.ToString() == "ZTRA")
                    {
                        _sCodPagoFija = GetCondPagoFijaCampCab(v_sIdCampanya);
                        if (_sCodPagoFija != "")
                        {
                            txbCodPagoFija.Text = _sCodPagoFija;
                        }
                    }

                    ActivarComboCondicionesPago();

                    _bEsDirectoZMAY = EsDirectoZMAY(iIdDestinatario); //Un mayorista es ZMAY si pertenece a un club que está en la tabla DirectoZMAY


                    //---- GSG (13/09/2016)
                    /*
                    //Actualitza acció marketing
                    //---- GSG (08/10/2012)
                    //Ara hi pot haber més d'una acció i no està a la capçalera sino a la taula PedAcciones
                    UpdateDataGridView(pedido);
                    */

                    //Aquí el datareader segur que està tancat
                    Color cColor = Color.FromArgb(238, 243, 246);
                    //---- GSG (23/06/2017)
                    //if (txtRentabilidad.Text.Trim() != "" && txbRentabilidad.Text.Trim() != "Sin catalogar")
                    if (txtRentabilidad.Text.Trim() != "" && txbRentabilidad.Text.Trim() != "No cuenta")
                        cColor = CalcularColorRentabilidad(float.Parse(txtRentabilidad.Text), dtpFechaPedido.Value);
                    txbRentabilidad.BackColor = cColor;


                    dto_general();


                    txbDecil.Text = GESTCRM.Utiles.DecilCliente(iIdCliente);
                    txbDecilP.Text = GESTCRM.Utiles.DecilProvincialCliente(iIdCliente);

                    Application.DoEvents();


                    ActualizarTotales();
                }

                sqlConn.Close();
                if (!drCabPedido.IsClosed)
                    drCabPedido.Close();


                chkRetenido.Checked = GetRetenido(pedido);


                Application.DoEvents();

                getDatosClienteIndep();
            }
            catch (Exception e)
            {
                Mensajes.ShowError("Error en evento cargar_datos: " + e.Message);
            }

            drCabPedido.Close();
        }

        #region eventos

        private void cboTipoCampana_MouseClick(object sender, MouseEventArgs e)
        {
            mensaje_al_salir = true;
            _iTipoCampanyaOld = cboTipoCampana.SelectedIndex;
            if (_iTipoCampanyaOld != -1)
                v_sIdCampanya = cboTipoCampana.SelectedValue.ToString();
        }

        private void txtMailConf_KeyPress(object sender, KeyPressEventArgs e)
        {
            mensaje_al_salir = true;
        }

        private void txtMailFact_KeyPress(object sender, KeyPressEventArgs e)
        {
            mensaje_al_salir = true;
        }

        private void cboTipoPedido_MouseClick(object sender, MouseEventArgs e)
        {
            mensaje_al_salir = true;
            _sTipoPedidoOld = cboTipoPedido.SelectedValue.ToString();
        }

        private void chkRetenido_MouseClick(object sender, MouseEventArgs e)
        {
            mensaje_al_salir = true;
        }

        private void dtpFechaFacturacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            mensaje_al_salir = true;
        }

        private void cboCondicionPago_MouseClick(object sender, MouseEventArgs e)
        {
            mensaje_al_salir = true;
        }

        private void cboPrioridad_MouseClick(object sender, MouseEventArgs e)
        {
            mensaje_al_salir = true;
        }

        private void txbObservaciones_KeyPress(object sender, KeyPressEventArgs e)
        {
            mensaje_al_salir = true;
        }

        private void txtClienteSAP_KeyPress(object sender, KeyPressEventArgs e)
        {
            mensaje_al_salir = true;
        }

        private void txtDestinatarioSAP_KeyPress(object sender, KeyPressEventArgs e)
        {
            mensaje_al_salir = true;
        }

        //Actualiza la rentabilidad anual añadiendo los datos del pedido en curso
        private void btActRent_Click(object sender, EventArgs e)
        {
            pintaRentabilidadAnual(true, DateTime.Today);
        }

        private void cboProgInf_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtProgInf.Text = cboProgInf.Text;
        }

        private void cboTipoCampana_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboTipoCampana.SelectedValue != null)
                {
                    string sIdCampCab = cboTipoCampana.SelectedValue.ToString();

                    if (sIdCampCab != v_sIdCampanya)
                    {
                        _dFecFact = GetFechaFactSegunCampanyaCab(sIdCampCab);
                        dtpFechaFacturacion.Value = _dFecFact;

                        _bVerCondPago = GetVerCondPagoCampCab(sIdCampCab);
                        _sCodPagoFija = GetCondPagoFijaCampCab(sIdCampCab);
                        txbCodPagoFija.Text = _sCodPagoFija;

                        ActivarComboCondicionesPago();

                        //Cambia el combo de campañas de línea?
                        string[] llista = new string[cBoxCampanyas.Items.Count]; // Lista Original de campañas
                        for (int i = 0; i < cBoxCampanyas.Items.Count; i++)
                            llista[i] = cBoxCampanyas.GetItemText(cBoxCampanyas.Items[i]);

                        //---- GSG (05/07/2017)
                        // las campañas de capçalera ja no determinen les de línia
                        /*
                        bool bCambioCombo = FormatBuscarCampanyas(iIdCliente, true, cboTipoPedido.SelectedValue.ToString());

                        if (bCambioCombo)
                        {
                            if (lblCounter.Text.Trim() == "")
                                lblCounter.Text = "0";

                            if (int.Parse(lblCounter.Text) > 0)
                            {
                                string[] llista2 = new string[cBoxCampanyas.Items.Count]; // Lista según cambio (ha d'estar aquí per saber la dimensió del array)

                                for (int i = 0; i < cBoxCampanyas.Items.Count; i++)
                                    llista2[i] = cBoxCampanyas.GetItemText(cBoxCampanyas.Items[i]);

                                if (!Comun.bEquals(llista, llista2)) // Las campañas de línea han cambiado
                                {
                                    string[] diffs = Comun.GetDifferenceOfArrays(llista, llista2);

                                    if (diffs.Length > 0)
                                    {
                                        if (Mensajes.ShowQuestion("Con el cambio de campanya de cabecera las campañas de línea permitidas han cambiado.\n\nSi acepta, las líneas del pedido seleccionadas pueden ser borradas si no pertecen a una campaña ahora posible, si cancela el pedido quedará como estaba.\n\n¿Desea continuar con el cambio de campaña de cabecera?") == DialogResult.Yes)
                                        {
                                             v_sIdCampanya = sIdCampCab;

                                            // Borrar líneas del pedido que no pertenecen a campañas comunes
                                            for (int i = dataGridViewLineas.Rows.Count - 1; i >= 0; i--)
                                            {
                                                if (Comun.IsInTheArray(dataGridViewLineas.Rows[i].Cells["ColCampanya"].Value.ToString(), diffs))
                                                    dataGridViewLineas.Rows.RemoveAt(i);
                                            }

                                            dtLineasPedido.AcceptChanges();
                                            lblCounter.Text = this.dtLineasPedido.DefaultView.Count.ToString();
                                            FormatDataGridLineas();
                                            ActualizarTotales();
                                        }
                                        else
                                        {
                                            cboTipoCampana.SelectedIndex = _iTipoCampanyaOld;
                                            FormatBuscarCampanyas(iIdCliente, true, cboTipoPedido.SelectedValue.ToString()); // Cambia el combo de campañas
                                        }
                                    }
                                }
                            }

                            cboTipoCampana_SelectedIndexChanged(sender, e);
                        }
                        */
                    }
                    else
                        dtpFechaFacturacion.Value = _dFecFactPedidoCargado;
                }
            }
            catch (Exception ev)
            {
                Mensajes.ShowError("Error en evento cboTipoCampana_SelectedValueChanged: " + ev.ToString());
            }
        }

        private void cboTipoPedido_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            bool bDejarComoEstaba = false;
            bool bComboCampActivo = true; //---- GSG (27/09/2017)

            ucBotoneraSecundaria1.btGrabar.Enabled = false; //---- GSG (02/02/2021)


            try
            {
                _iMinimos = 0;  //---- GSG (02/01/2023)

                _sTipoPedidoNew = cboTipoPedido.SelectedValue.ToString();//---- VLP (26/07/2023)//---- VLP (26/07/2023)
                if (_sTipoPedidoNew != _sTipoPedidoOld && txtClienteSAP.Text.Trim() != "")
                {
                    //---- VLP (26/07/2023). Tipo campaña No descuento Medio        
                     if (!CambiarTipoPedido())
                    {
                        //Mensajes.ShowExclamation("La campaña seleccionada es especial para descuentos en línea y es incompatible con el uso de otras campañas. El pedido solo puede tener esta campaña.");
                        Mensajes.ShowExclamation("No se puede cambiar el tipo de pedido debido a que existen líneas de una campaña que no permite combinarse con otras. Si realmente desea cambiar el tipo, elimine las líneas de dicha campaña.");

                        cboTipoPedido.SelectedIndexChanged -= cboTipoPedido_SelectedIndexChanged;
                        _sTipoPedidoNew = _sTipoPedidoOld;
                        cboTipoPedido.SelectedValue = _sTipoPedidoNew;                        
                        cboTipoPedido.SelectedIndexChanged += cboTipoPedido_SelectedIndexChanged;
                        ucBotoneraSecundaria1.btGrabar.Enabled = true;

                        return;
                    }


                    // Lista Original de campañas
                    string[] llista = new string[cBoxCampanyas.Items.Count];
                    for (int i = 0; i < cBoxCampanyas.Items.Count; i++)
                        llista[i] = cBoxCampanyas.GetItemText(cBoxCampanyas.Items[i]);

                    // Lista de campañas según cambio
                    FormatBuscarCampanyas(iIdCliente, bComboCampActivo, _sTipoPedidoNew, txtDestinatarioSAP.Text.Trim());
                    string[] llista2 = new string[cBoxCampanyas.Items.Count]; //(ha d'estar aquí per saber la dimensió del array)
                    for (int i = 0; i < cBoxCampanyas.Items.Count; i++)
                        llista2[i] = cBoxCampanyas.GetItemText(cBoxCampanyas.Items[i]);

                    // Materiales bloqueados
                    string[] bloqueados = new string[500];
                    bloqueados = GetMaterialesBloqueados(_sTipoPedidoNew);

                    // Materiales ZMKT (podrían tener que eliminarse con las nuevas condiciones de tipo de pedido)
                    string[] zmkts = new string[500];
                    if (_sTipoPedidoNew == Comun.K_TIPOPED_COMPROMISO || Comun.IsInTheArray(_sTipoPedidoNew, Configuracion.asPedTransfer))
                        zmkts = MatsZMKTEnPedido(); // Materiales ZMKT que contiene el pedido

                    if (!Comun.bEquals(llista, llista2) || bloqueados.Length > 0 || zmkts.Length > 0) // Las campañas de línea han cambiado o hay que comprobar materiales bloqueados
                    {
                        if (Mensajes.ShowQuestion("Con el cambio en el tipo de pedido las campañas permitidas han cambiado así como también pueden cambiar los materiales bloqueados.\n\nSi acepta, algunas las líneas del pedido pueden ser borradas por no pertenecer a una campaña activa o por estar bloqueados, si cancela, el pedido quedará como estaba.\n\n¿Desea continuar con el cambio en el tipo de pedido?") == DialogResult.Yes)
                        {
                            if (llista2.Length > 0)
                            {
                                // Borrar líneas del pedido que no pertenecen a campañas comunes
                                string[] diffs = Comun.GetDifferenceOfArrays(llista, llista2);

                                if (diffs.Length > 0)
                                {
                                    for (int i = dataGridViewLineas.Rows.Count - 1; i >= 0; i--)
                                    {
                                        if (Comun.IsInTheArray(dataGridViewLineas.Rows[i].Cells["ColCampanya"].Value.ToString(), diffs))
                                            dataGridViewLineas.Rows.RemoveAt(i);
                                    }

                                    dtLineasPedido.AcceptChanges();
                                }

                                // Borrar líneas del pedido si el material está bloqueado.
                                if (bloqueados.Length > 0)
                                {
                                    for (int i = dataGridViewLineas.Rows.Count - 1; i >= 0; i--)
                                    {
                                        if (Comun.IsInTheArray(dataGridViewLineas.Rows[i].Cells["sIdMaterialDataGridViewTextBoxColumn"].Value.ToString(), bloqueados))
                                            dataGridViewLineas.Rows.RemoveAt(i);
                                    }

                                    dtLineasPedido.AcceptChanges();
                                }

                                // Borrar líneas ZMKT
                                if (zmkts.Length > 0)
                                {
                                    for (int i = dataGridViewLineas.Rows.Count - 1; i >= 0; i--)
                                    {
                                        if (Comun.IsInTheArray(dataGridViewLineas.Rows[i].Cells["sIdMaterialDataGridViewTextBoxColumn"].Value.ToString(), zmkts))
                                            dataGridViewLineas.Rows.RemoveAt(i);
                                    }

                                    dtLineasPedido.AcceptChanges();
                                }

                                // Actualizar datos 

                                lblCounter.Text = this.dtLineasPedido.DefaultView.Count.ToString();
                                FormatDataGridLineas();

                                // Al cambiar el tipo de pedido tenemos que recalcular el valor de la columna fDescMat porque depende de ello
                                // La stored ha cargado un valor según su tipo original pero si cambiamos hay que modificarlo, en caso contrario
                                // los extras no se calculan bien                                
                                for (int i = 0; i < dataGridViewLineas.Rows.Count; i++)
                                    ActualizarImporteLinea(i);  //Esta función me sirve aquí para recalcular fDescMat y el extra de la línea

                                LlenarComboCampanyasCab(); // Cambia el combo de campañas de cabecera

                                ActualizarTotales();

                                //  Otros cambios en el formulario si cambia el tipo de pedido

                                pnCompromiso.Visible = false;
                                lblFechaPref.Text = "Fecha entrega:";

                                if (Comun.IsInTheArray(_sTipoPedidoNew, Configuracion.asPedTransfer))
                                {
                                    label2.Text = "Solicitante:";
                                    lblDestinatario.Text = "Mayorista";

                                    iIdDestinatario = -1;
                                    _bEsDirectoZMAY = false; //Un mayorista es ZMAY si pertenece a un club que está en la tabla DirectoZMAY
                                    txtDestinatarioSAP.Text = "";
                                    txtsDestinatario.Text = "";

                                    if (_sTipoPedidoNew == Comun.K_TIPOPED_COMPROMISO)
                                    {
                                        pnCompromiso.Visible = true;
                                        cboClasico.SelectedIndex = 0;
                                        cboIndividual.SelectedIndex = 0;
                                        lblFechaPref.Text = "Fecha vigencia:";
                                    }
                                }
                                else //directo
                                {
                                    label2.Text = "Dest. Mercancía";
                                    lblDestinatario.Text = "Solic./Pagador:";

                                    //Poner él mismo como destinatario
                                    txtDestinatarioSAP.Text = txtClienteSAP.Text;
                                    txtsDestinatario.Text = txtsCliente.Text;
                                    iIdDestinatario = iIdCliente;
                                    _bEsDirectoZMAY = EsDirectoZMAY(iIdDestinatario); //Un mayorista es ZMAY si pertenece a un club que está en la tabla DirectoZMAY

                                    //---- GSG (06/03/2021)
                                    //if (GESTCRM.Utiles.DeudaVencida(iIdCliente))
                                    //    Mensajes.ShowInformation("Mientras no se liquide la deuda vencida este pedido no se servirá.");

                                    int ret = GESTCRM.Utiles.DeudaVencida(iIdCliente);
                                    switch (ret)
                                    {
                                        case 1:
                                            Mensajes.ShowInformation("Mientras no se liquide la deuda vencida este pedido no se servirá.");
                                            break;
                                        case 2:
                                            Mensajes.ShowInformation("Un cliente Intrum solo puede pasar pedidos Transfer/Compromiso.");
                                            break;
                                        case 3:
                                            Mensajes.ShowInformation("Mientras no se liquide la deuda vencida este pedido no se servirá.\r\nUn cliente Intrum solo puede pasar pedidos Transfer/Compromiso.");
                                            break;

                                    }
                                }

                                cargarNIFyCC();
                            }
                            else
                            {
                                // Borrar todas las líneas del pedido ya que el combo de campanyas queda vacío

                                dtLineasPedido.Rows.Clear();
                                dtLineasPedido.AcceptChanges();
                            }
                        }
                        else //Dejar el pedido como estaba
                            bDejarComoEstaba = true;
                    }
                    else //Dejar el pedido como estaba
                        bDejarComoEstaba = true;
                }
                else
                {
                    bDejarComoEstaba = true;
                    if (_sTipoPedidoNew != _sTipoPedidoOld && txtClienteSAP.Text.Trim() == "")
                    {
                        Mensajes.ShowError(String.Format("No ha seleccionado ningún cliente. Deberá indicar el cliente antes de cambiar el tipo de pedido."));
                        bComboCampActivo = false; //---- GSG (27/09/2017)
                    }
                    else if (txtClienteSAP.Text.Trim() == "") //---- GSG (27/09/2017)
                        bComboCampActivo = false;

                    //else if (_sTipoPedidoNew != _sTipoPedidoOld && txtDestinatarioSAP.Text.Trim() == "" && Comun.IsInTheArray(_sTipoPedidoNew, Configuracion.asPedTransfer))
                    //    Mensajes.ShowError(String.Format("No ha seleccionado ningún mayorista. Deberá indicar el Mayorista antes de seleccionar los materiales."));
                }

                if (bDejarComoEstaba)
                {
                    //FormatBuscarCampanyas(iIdCliente, true, _sTipoPedidoOld, txtDestinatarioSAP.Text.Trim());
                    FormatBuscarCampanyas(iIdCliente, bComboCampActivo, _sTipoPedidoOld, txtDestinatarioSAP.Text.Trim()); //---- GSG (27/09/2017)
                    _sTipoPedidoNew = _sTipoPedidoOld;
                }
                else //---- GSG (06/03/2021)
                {
                    _listaAccMarkProfitPlus = GetCodsAccMarkPedido(_sTipoPedidoNew);
                }


                cboTipoPedido.SelectedValue = _sTipoPedidoNew;
            }
            catch (Exception ev)
            {
                Mensajes.ShowError("Error en evento cboTipoPedido_SelectedIndexChanged: " + ev.ToString());
            }




            /*
            try
            {
                _sTipoPedidoNew = cboTipoPedido.SelectedValue.ToString();
                string tipoPed = _sTipoPedidoNew;
                bool bCancel = false;

                if (tipoPed == Comun.K_TIPOPED_COMPROMISO)
                    lblFechaPref.Text = "Fecha vigencia:";
                else
                    lblFechaPref.Text = "Fecha entrega:";

                //Cambia el combo de campañas de línea?

                string[] llista = new string[cBoxCampanyas.Items.Count]; // Lista Original de campañas

                for (int i = 0; i < cBoxCampanyas.Items.Count; i++)
                    llista[i] = cBoxCampanyas.GetItemText(cBoxCampanyas.Items[i]);

                bool bActivo = true;
                if (iIdCliente == -1 || iIdCliente == 0)
                    bActivo = false;

                //---- GSG (05/07/2017)
                //FormatBuscarCampanyas(iIdCliente, bActivo, _sTipoPedidoNew); // Cambia el combo de campañas
                FormatBuscarCampanyas(iIdCliente, bActivo, _sTipoPedidoNew, txtDestinatarioSAP.Text.Trim()); //---- GSG (05/07/2017)


                LlenarComboCampanyasCab(); // Cambia el combo de campañas de cabecera

                string[] llista2 = new string[cBoxCampanyas.Items.Count]; // Lista según cambio (ha d'estar aquí per saber la dimensió del array)


                string[] bloqueados = new string[500];
                string[] zmkts = new string[500]; //---- GSG (17/10/2016)

                if (dataGridViewLineas.Rows.Count > 0)
                {                    
                    for (int i = 0; i < cBoxCampanyas.Items.Count; i++)
                        llista2[i] = cBoxCampanyas.GetItemText(cBoxCampanyas.Items[i]);

                    bloqueados = GetMaterialesBloqueados(_sTipoPedidoNew);

                    //---- GSG (17/10/2016)
                    // Otra comporbación que hay que hacer con el cambio de pedido, es que si hay materiales ZMKT, podrían tener que eliminarse con las nuevas condiciones
                    if (tipoPed == Comun.K_TIPOPED_COMPROMISO || Comun.IsInTheArray(tipoPed, Configuracion.asPedTransfer))
                        zmkts = MatsZMKTEnPedido();


                    if (!Comun.bEquals(llista, llista2) || bloqueados != null || zmkts != null) // Las campañas de línea han cambiado o hay que comprobar materiales bloqueados
                    {
                        string[] diffs = Comun.GetDifferenceOfArrays(llista, llista2);

                        if (diffs.Length > 0 || bloqueados.Length > 0 || zmkts.Length > 0)
                        {
                            if (Mensajes.ShowQuestion("Con el cambio en el tipo de pedido las campañas permitidas han cambiado así como también pueden cambiar los materiales bloqueados.\n\nSi acepta, algunas las líneas del pedido pueden ser borradas por no pertenecer a una campaña activa o por estar bloqueados, si cancela, el pedido quedará como estaba.\n\n¿Desea continuar con el cambio en el tipo de pedido?") == DialogResult.Yes)
                            {
                                if (diffs.Length > 0)
                                {
                                    // Borrar líneas del pedido que no pertenecen a campañas comunes
                                    for (int i = dataGridViewLineas.Rows.Count - 1; i >= 0; i--)
                                    {
                                        if (Comun.IsInTheArray(dataGridViewLineas.Rows[i].Cells["ColCampanya"].Value.ToString(), diffs))
                                            dataGridViewLineas.Rows.RemoveAt(i);
                                    }

                                    dtLineasPedido.AcceptChanges();
                                }

                                // Borrar líneas del pedido si el material está bloqueado.
                                if (bloqueados.Length > 0)
                                {
                                    for (int i = dataGridViewLineas.Rows.Count - 1; i >= 0; i--)
                                    {
                                        if (Comun.IsInTheArray(dataGridViewLineas.Rows[i].Cells["sIdMaterialDataGridViewTextBoxColumn"].Value.ToString(), bloqueados))
                                            dataGridViewLineas.Rows.RemoveAt(i);
                                    }

                                    dtLineasPedido.AcceptChanges();
                                }

                                // Borrar líneas ZMKT si es transfer o compromiso
                                if (zmkts.Length > 0)
                                {
                                    for (int i = dataGridViewLineas.Rows.Count - 1; i >= 0; i--)
                                    {
                                        if (Comun.IsInTheArray(dataGridViewLineas.Rows[i].Cells["sIdMaterialDataGridViewTextBoxColumn"].Value.ToString(), zmkts))
                                            dataGridViewLineas.Rows.RemoveAt(i);
                                    }

                                    dtLineasPedido.AcceptChanges();
                                }

                                lblCounter.Text = this.dtLineasPedido.DefaultView.Count.ToString();
                                FormatDataGridLineas();

                                // Al cambiar el tipo de pedido tenemos que recalcular el valor de la columna fDescMat porque depende de ello
                                // La stored ha cargado un valor según su tipo original pero si cambiamos hay que modificarlo, en caso contrario
                                // los extras no se calculan bien                                
                                for (int i = 0; i < dataGridViewLineas.Rows.Count; i++)
                                { 
                                    ActualizarImporteLinea(i);  //Esta función me sirve aquí para recalcular fDescMat y el extra de la línea
                                }

                                ActualizarTotales();
                            }
                            else //Dejar el pedido como estaba
                            {
                                bCancel = true;
                                //---- GSG (05/07/2017)
                                //FormatBuscarCampanyas(iIdCliente, bActivo, _sTipoPedidoOld); // Cambia el combo de campañas
                                FormatBuscarCampanyas(iIdCliente, bActivo, _sTipoPedidoOld, txtDestinatarioSAP.Text.Trim()); 


                                tipoPed = _sTipoPedidoOld;
                            }
                        } 
                    }
                }

                if (Comun.IsInTheArray(tipoPed, Configuracion.asPedTransfer))
                {
                    label2.Text = "Solicitante:";
                    lblDestinatario.Text = "Mayorista";
                }
                else //directo
                {
                    label2.Text = "Dest. Mercancía";
                    lblDestinatario.Text = "Solic./Pagador:";
                }


                // Amb el càlcul d'extres cal que hi hagi el destinatari triat quan és transfer
                if (Comun.IsInTheArray(tipoPed, Configuracion.asPedTransfer) && txtsDestinatario.Text.Trim() == "")
                    Mensajes.ShowError(String.Format("No ha seleccionado ningún mayorista. Deberá indicar el Mayorista antes de seleccionar los materiales."));
                else
                {
                    if (Comun.IsInTheArray(tipoPed, Configuracion.asPedTransfer))
                    {
                        if (!bCancel && _sTipoPedidoOld != _sTipoPedidoNew)
                        {
                            iIdDestinatario = -1;
                            _bEsDirectoZMAY = false; //Un mayorista es ZMAY si pertenece a un club que está en la tabla DirectoZMAY
                            txtDestinatarioSAP.Text = "";
                            this.txtsDestinatario.Text = "";
                        }
                    }
                    else
                    {
                        //Poner él mismo como destinatario
                        txtDestinatarioSAP.Text = txtClienteSAP.Text;
                        txtsDestinatario.Text = txtsCliente.Text;
                        iIdDestinatario = iIdCliente;
                        _bEsDirectoZMAY = EsDirectoZMAY(iIdDestinatario); //Un mayorista es ZMAY si pertenece a un club que está en la tabla DirectoZMAY

                        if (GESTCRM.Utiles.DeudaVencida(iIdCliente))
                            Mensajes.ShowInformation("Mientras no se liquide la deuda vencida este pedido no se servirá.");
                    }

                    //Verificar si hay que aplicar el descuento general
                    cboTipoCampana_SelectedIndexChanged(sender, e);
                }

                cboTipoPedido.SelectedValue = tipoPed;

                cargarNIFyCC();


                //---- GSG (14/10/2016)
                if (tipoPed == Comun.K_TIPOPED_COMPROMISO)
                {
                    pnCompromiso.Visible = true;
                    cboClasico.SelectedIndex = 0;
                    cboIndividual.SelectedIndex = 0;
                }
                else
                    pnCompromiso.Visible = false;
            }
            catch (Exception ev)
            {
                Mensajes.ShowError("Error en evento cboTipoPedido_SelectedIndexChanged: " + ev.ToString());
            }
            */

            ucBotoneraSecundaria1.btGrabar.Enabled = true; //---- GSG (02/02/2021)
        }

        private void dataGridViewLineas_MouseUp(object sender, MouseEventArgs e)
        {
            DataGridView dgv = dataGridViewLineas;
            NumericUpDown nud = numericUpDownA;

            if (dgv.IsCurrentCellInEditMode)
            {
                Mensajes.ShowTip(dgv.Left + e.X + 70, dgv.Top + e.Y + 220, this);

                DataGridView.HitTestInfo hti = dgv.HitTest(e.X, e.Y);

                int iCantidadIndex = dgv.Columns["ColCantidad"].Index;
                int UnidMinimasIndex = dgv.Columns["ColUnidMinimas"].Index;
            }

            if (MdiParent != null)
                this.MdiParent.Focus();


        }

        private void dataGridViewLineas_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            DataGridViewCell cell = dataGridViewLineas.CurrentCell;
            int IdGrupoMat = (int)dataGridViewLineas.Rows[e.RowIndex].Cells["ColIdGrupoMat"].Value;

            //Validacions individuals material
            if (e.ColumnIndex == dataGridViewLineas.Columns["ColCantidad"].Index) //Validar Cantidad
            {
                string sUnidMinimas = dataGridViewLineas.Rows[e.RowIndex].Cells["ColUnidMinimas"].Value.ToString();
                int iUnidMinimas = int.Parse(sUnidMinimas);

                string sCantidad = e.Value.ToString();
                int iCantidad;

                int.TryParse(sCantidad, out iCantidad);
                if (iCantidad < 1)
                {
                    cell.Style.BackColor = DefaultValueColor;
                    cell.Style.SelectionBackColor = DefaultValueColor;

                    Mensajes.ShowError(String.Format("Valor de cantidad incorrecto ({0}). Debe introducir un número entero mayor o igual que 1.", sCantidad));

                    e.ParsingApplied = false;
                    SetDefault = true;
                    DefaultValue = dataGridViewLineas.Rows[e.RowIndex].Cells["ColCantidad"].Value.ToString();

                    return;
                }

                //---- GSG (02/01/2023)
                if (_iMinimos == 1)
                {
                    if (iCantidad != 1)
                    {
                        cell.Style.BackColor = DefaultValueColor;
                        cell.Style.SelectionBackColor = DefaultValueColor;

                        Mensajes.ShowError(String.Format("La cantidad en un compromiso de mínimos debe ser de 1 unidad."));

                        e.ParsingApplied = false;
                        DefaultValue = "1";

                        return;
                    }
                    else
                    {
                        e.ParsingApplied = true;
                    }
                } //---- FI GSG
                else
                {
                    if (iCantidad < iUnidMinimas) //Aquesta comprovació sols és per la línia, no pel grup
                    {
                        cell.Style.BackColor = DefaultValueColor;
                        cell.Style.SelectionBackColor = DefaultValueColor;

                        Mensajes.ShowError(String.Format("La cantidad ({0}) debe igualar o supera a las unidades mínimas ({1}).", sCantidad, sUnidMinimas));

                        e.ParsingApplied = false;
                        SetDefault = true;
                        DefaultValue = dataGridViewLineas.Rows[e.RowIndex].Cells["ColCantidad"].Value.ToString();

                        return;
                    }

                    string idC = dataGridViewLineas.Rows[e.RowIndex].Cells["ColidCampanya"].Value.ToString();
                    string idM = dataGridViewLineas.Rows[e.RowIndex].Cells["sIdMaterialDataGridViewTextBoxColumn"].Value.ToString();

                    _sTipoSumaUnidades = GetTipoSumaUnidadesCampanya(idM, idC);

                    //---- GSG (29/03/2022)
                    _sTipoPedidoSumaUnidades = GetTipoPedidoSumaUnidadesCampanya(idM, idC);
                    string tipoPed = cboTipoPedido.SelectedValue.ToString();
                    bool bCumple = false;
                    if ((_sTipoPedidoSumaUnidades == "XXXX") ||
                        (Comun.IsInTheArray(tipoPed, Configuracion.asPedTransfer) && (_sTipoPedidoSumaUnidades == tipoPed || _sTipoPedidoSumaUnidades == "T")) ||
                        (!Comun.IsInTheArray(tipoPed, Configuracion.asPedTransfer) && (_sTipoPedidoSumaUnidades == tipoPed || _sTipoPedidoSumaUnidades == "D"))
                        )
                        bCumple = true;

                    //-- Valida suma unidades
                    //if (_sTipoSumaUnidades == Comun.K_CAJA)//---- GSG (29/03/2022)
                    if (_sTipoSumaUnidades == Comun.K_CAJA && bCumple)
                    {
                        int iNum = 0;
                        if (dataGridViewLineas.Rows[e.RowIndex].Cells["ColCajaCompleta"].Value != null && dataGridViewLineas.Rows[e.RowIndex].Cells["ColCajaCompleta"].Value.ToString().Trim() != "")
                            iNum = int.Parse(dataGridViewLineas.Rows[e.RowIndex].Cells["ColCajaCompleta"].Value.ToString());
                        if (iNum != 0 && (iCantidad % iNum != 0))
                        {
                            cell.Style.BackColor = DefaultValueColor;
                            cell.Style.SelectionBackColor = DefaultValueColor;

                            Mensajes.ShowError(String.Format("Valor de cantidad incorrecto ({0}). Debe introducir un número múltiplo de las unidades de caja completa ({1}).", iCantidad.ToString(), iNum.ToString()));

                            e.ParsingApplied = false;
                            SetDefault = true;
                            DefaultValue = dataGridViewLineas.Rows[e.RowIndex].Cells["ColCantidad"].Value.ToString();

                            return;
                        }
                    }
                    //else if (_sTipoSumaUnidades == Comun.K_EMBALAJE) //---- GSG (29/03/2022)
                    else if (_sTipoSumaUnidades == Comun.K_EMBALAJE && bCumple)
                    {
                        int iNum = 0;
                        if (dataGridViewLineas.Rows[e.RowIndex].Cells["ColUnidadesEnfajado"].Value != null && dataGridViewLineas.Rows[e.RowIndex].Cells["ColUnidadesEnfajado"].Value.ToString().Trim() != "")
                            iNum = int.Parse(dataGridViewLineas.Rows[e.RowIndex].Cells["ColUnidadesEnfajado"].Value.ToString());
                        if (iNum != 0 && (iCantidad % iNum != 0))
                        {
                            cell.Style.BackColor = DefaultValueColor;
                            cell.Style.SelectionBackColor = DefaultValueColor;

                            Mensajes.ShowError(String.Format("Valor de cantidad incorrecto ({0}). Debe introducir un número múltiplo de las unidades de enfajado ({1}).", iCantidad.ToString(), iNum.ToString()));

                            e.ParsingApplied = false;
                            SetDefault = true;
                            DefaultValue = dataGridViewLineas.Rows[e.RowIndex].Cells["ColCantidad"].Value.ToString();

                            return;
                        }
                    }

                    bool bEsEsp = esCampanyaRegaloEspecial(e);
                    if (bEsEsp)
                    {
                        double descMaxRegaloEspecial = valorDescMaxRegaloEspecial(e);
                        string IdCampanya = dataGridViewLineas.Rows[e.RowIndex].Cells["ColIdCampanya"].Value.ToString();
                        double fDescuento = 0;

                        foreach (RegaloEspecial re in _lRegaloEspecial)
                        {
                            if (IdCampanya == re.codCamp)
                            {
                                double brutoRegalos = 0;
                                double brutoTotal = 0;
                                string idMat = "";
                                int index = 0;

                                foreach (DataGridViewRow dr in dataGridViewLineas.Rows)
                                {
                                    if (dr.Cells["ColidCampanya"].Value.ToString() == IdCampanya)
                                    {
                                        idMat = dr.Cells["sIdMaterialDataGridViewTextBoxColumn"].Value.ToString();
                                        if (re.EsRegalo(idMat))
                                        {
                                            int qty = 0;
                                            if (e.RowIndex == index)
                                                qty = int.Parse(e.Value.ToString());
                                            else
                                                qty = int.Parse(dr.Cells["ColCantidad"].Value.ToString());

                                            double precio = double.Parse(dr.Cells["ColPrecio"].Value.ToString());
                                            brutoRegalos += (qty * precio);
                                            brutoTotal += (qty * precio);
                                        }
                                        else if (re.EsEspecial(idMat))
                                        {
                                            int qty = 0;
                                            if (e.RowIndex == index)
                                                qty = int.Parse(e.Value.ToString());
                                            else
                                                qty = int.Parse(dr.Cells["ColCantidad"].Value.ToString());

                                            double precio = double.Parse(dr.Cells["ColPrecio"].Value.ToString());
                                            brutoTotal += (qty * precio);
                                        }
                                    }
                                    index++;
                                }

                                fDescuento = (brutoRegalos / brutoTotal) * 100;

                                if (fDescuento > descMaxRegaloEspecial)
                                {
                                    Mensajes.ShowError(String.Format("El descuento medio calculado ({0:C}) supera el máximo permitido por la campaña ({1:C}).", fDescuento, descMaxRegaloEspecial));
                                    e.ParsingApplied = false;
                                    SetDefault = true;
                                    DefaultValue = dataGridViewLineas.Rows[e.RowIndex].Cells["ColCantidad"].Value.ToString();
                                    return;
                                }
                            }
                        }
                    }

                    //Actualizamos el valor por defecto por si viola el importe mínimo
                    DefaultValue = dataGridViewLineas.Rows[e.RowIndex].Cells["ColCantidad"].Value.ToString();

                }//---- GSG (02/01/2023)


            }
            else if (e.ColumnIndex == dataGridViewLineas.Columns["ColDescuento"].Index) //Validar Descuento máximo permitido en este material por la campaña a la que pertenece
            {
                string sDescuentoMaximo = dataGridViewLineas.Rows[e.RowIndex].Cells["ColDescuentoMaximo"].Value.ToString();
                float fDescuentoMaximo = float.Parse(sDescuentoMaximo);

                string sDescuento = e.Value.ToString();
                float fDescuento;

                float.TryParse(sDescuento, out fDescuento);


                if ((fDescuento <= 0) && sDescuento != "0")
                {
                    cell.Style.BackColor = DefaultValueColor;
                    cell.Style.SelectionBackColor = DefaultValueColor;

                    //---- GSG (22/08/2019)
                    //Mensajes.ShowError(String.Format("Valor de descuento incorrecto ({0}). Debe introducir un número mayor o igual que 0.", sDescuento));
                    if (!_bErrorMostrat)
                    {
                        Mensajes.ShowError(String.Format("Valor de descuento incorrecto ({0}). Debe introducir un número mayor o igual que 0.", sDescuento));
                        _bErrorMostrat = true;
                    }


                    e.ParsingApplied = false;
                    SetDefault = true;
                    DefaultValue = dataGridViewLineas.Rows[e.RowIndex].Cells["ColDescuento"].Value.ToString(); //Descuento introducido

                    return;

                }


                if (fDescuento > fDescuentoMaximo)
                {
                    cell.Style.BackColor = DefaultValueColor;
                    cell.Style.SelectionBackColor = DefaultValueColor;

                    //---- GSG (22/08/2019)
                    //Mensajes.ShowError(String.Format("El descuento aplicado ({0}%) supera al descuento máximo ({1}%).", sDescuento, sDescuentoMaximo));
                    if (!_bErrorMostrat)
                    {
                        Mensajes.ShowError(String.Format("El descuento aplicado ({0}%) supera al descuento máximo ({1}%).", sDescuento, sDescuentoMaximo));

                        _bErrorMostrat = true;
                    }

                    e.ParsingApplied = false;
                    SetDefault = true;


                    DefaultValue = dataGridViewLineas.Rows[e.RowIndex].Cells["ColDescuento"].Value.ToString();



                    return;
                }

                //Actualizamos el valor por defecto
                DefaultValue = dataGridViewLineas.Rows[e.RowIndex].Cells["ColDescuento"].Value.ToString();
                _bErrorMostrat = false; //---- GSG (22/08/2019)
            }


            if (_iMinimos == 0) //---- GSG (02/01/2023)
            {

                bool bImpN, bImpB, bQuan;
                double fImpReal, fImpMin;
                int iQuanReal, iQuanMin;

                SeViolaMinimosCampanya(IdGrupoMat, e, out bImpN, out bImpB, out bQuan, out fImpReal, out fImpMin, out iQuanReal, out iQuanMin);

                if (bImpN || bImpB || bQuan)
                {
                    cell.Style.BackColor = DefaultValueColor;
                    cell.Style.SelectionBackColor = DefaultValueColor;

                    if (bImpN)
                        Mensajes.ShowError(String.Format("El nuevo importe neto total de la campaña ({0:C}) no puede ser menor que {1:C}.", fImpReal, fImpMin));
                    else if (bImpB)
                        Mensajes.ShowError(String.Format("El nuevo importe bruto total de la campaña ({0:C}) no puede ser menor que {1:C}.", fImpReal, fImpMin));
                    else if (bQuan)
                        Mensajes.ShowError(String.Format("La nueva cantidad total de la campaña ({0}) no puede ser menor que {1}.", iQuanReal, iQuanMin));

                    e.ParsingApplied = false;
                    SetDefault = true;
                    //El valor por defecto ya se actualizó previamente

                    return;
                }


                //Validacions presentacions (grups dins la campanya)
                string retMessage = SeViolaMinimosPresentacion(e);
                if (retMessage.Length > 0)
                {
                    cell.Style.BackColor = DefaultValueColor;
                    cell.Style.SelectionBackColor = DefaultValueColor;
                    Mensajes.ShowError(retMessage);
                    e.ParsingApplied = false;
                    SetDefault = true;
                    return;
                }


            } //---- GSG (02/01/2023)

            e.ParsingApplied = true;
            SetDefault = false;
            cell.Style.BackColor = dataGridViewLineas.Rows[e.RowIndex].Cells["ColUnidMinimas"].Style.BackColor;
            cell.Style.SelectionBackColor = dataGridViewLineas.Rows[e.RowIndex].Cells["ColUnidMinimas"].Style.SelectionBackColor;
        }

        private void numericUpDownA_Leave(object sender, EventArgs e)
        {
            Mensajes.HideTip();
            numericUpDownA.Visible = false;

            if (PressedKey == Keys.Escape)
            {
                PressedKey = Keys.None;
                return;
            }

            object idGrupoMateriales = dataGridViewLineas.CurrentRow.Cells["ColIdGrupoMat"].Value;
            decimal MultiplicadorCantidadesArrastre = numericUpDownA.Value / numericUpDownA.Increment;

            foreach (DataGridViewRow row in dataGridViewLineas.Rows)
                if (row.Cells["ColIdGrupoMat"].Value.Equals(idGrupoMateriales))
                {
                    int iUnidMinimas = int.Parse(row.Cells["ColUnidMinimas"].Value.ToString());
                    row.Cells["ColCantidad"].Value = (iUnidMinimas * MultiplicadorCantidadesArrastre).ToString();
                    ActualizarImporteLinea(row.Index);
                }

            ActualizarTotales();
        }

        private void numericUpDownA_KeyDown(object sender, KeyEventArgs e)
        {
            PressedKey = e.KeyCode;

            if ((PressedKey == Keys.Enter) || (PressedKey == Keys.Escape))
                dataGridViewLineas.Focus();
        }

        private void cboTipoCampana_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoCampana.SelectedValue == null)
                return;

            string IdCampanya = cboTipoCampana.SelectedValue.ToString();
            string TipoPedido = cboTipoPedido.SelectedValue.ToString();

            DataRow[] rows = dtCampanyasCabeceraCompletas.Select(
                String.Format("idCampanya='{0}' AND sIdTipoPedido='{1}'", IdCampanya, TipoPedido));

            if (rows.Length > 0) //Hay al menos una fila
            {
                dsFormularios.ListaCampanyasCabeceraRow row = (dsFormularios.ListaCampanyasCabeceraRow)rows[0];

                bEsBrut = false;
                ImporteMinPedido = row.fImporteMinObli;
                //si hi ha brut mana
                if (row.fImporteMinObliBruto > 0)
                {
                    ImporteMinPedido = row.fImporteMinObliBruto;
                    bEsBrut = true;
                }

                //Nombre mínim unitats
                iMinimUnitatsPedido = row.iNumMinUnidades;

                DtoGeneral = row.Descuento;
            }
            else
            {
                ImporteMinPedido = 0.0;
                DtoGeneral = 0.0;
                iMinimUnitatsPedido = 0;
            }

            txbDtoGeneral.Text = String.Format("{0:#,0.##}%", DtoGeneral);

            if (DtoGeneral > 0)
            {
                lblDescGen.ForeColor = Color.Red;
                txbDtoGeneral.ForeColor = Color.Red;
                txbDtoGeneral.Font = BoldFont;
            }
            else
            {
                lblDescGen.ForeColor = Color.Black;
                txbDtoGeneral.ForeColor = Color.Black;
                txbDtoGeneral.Font = RegularFont;
            }

            AplicarDescuentoGeneral();

            _bVerCondPago = GetVerCondPagoCampCab(IdCampanya);

            _dFecFact = GetFechaFactSegunCampanyaCab(IdCampanya);
            _sCodPagoFija = GetCondPagoFijaCampCab(IdCampanya);
            txbCodPagoFija.Text = _sCodPagoFija;
            dtpFechaFacturacion.Value = _dFecFact;

            ActivarComboCondicionesPago();
        }

        private void txbImporte_MouseEnter(object sender, EventArgs e)
        {
            if (!dataGridViewLineas.IsCurrentCellInEditMode && !bEsBrut)
            {
                Mensajes.SetTip("Importe mínimo", ImporteMinPedido.ToString("C"));
                Mensajes.ShowTip(pnlLineaPedido.Left + txbImporte.Left + 120, pnlLineaPedido.Top + txbImporte.Top + 55, this);
            }
        }

        private void txbImporte_MouseLeave(object sender, EventArgs e)
        {
            if (!dataGridViewLineas.IsCurrentCellInEditMode)
            {
                Mensajes.HideTip();
            }
        }

        private void txbImporteBruto_MouseEnter(object sender, EventArgs e)
        {
            if (!dataGridViewLineas.IsCurrentCellInEditMode && bEsBrut)
            {
                Mensajes.SetTip("Imp. bruto mínimo", ImporteMinPedido.ToString("C"));
                Mensajes.ShowTip(pnlLineaPedido.Left + txbImporteBruto.Left + 120, pnlLineaPedido.Top + txbImporteBruto.Top + 55, this);
            }
        }

        private void txbImporteBruto_MouseLeave(object sender, EventArgs e)
        {
            if (!dataGridViewLineas.IsCurrentCellInEditMode)
            {
                Mensajes.HideTip();
            }
        }

        private void dataGridViewAccMark_MouseUp(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hti = dataGridViewAccMark.HitTest(e.X, e.Y);

            if (hti.RowIndex < 0) //Se hizo click en la cabecera
                return;

            if (hti.ColumnIndex == 0)
            {
                // Ara es pot seleccionar més d'una acció
                if (TipoAcceso != (int)acceso.CONSULTA)
                {
                    if (bool.Parse(dataGridViewAccMark.Rows[hti.RowIndex].Cells["selected"].Value.ToString())) // checked --> uncheked
                    {
                        dataGridViewAccMark.Rows[hti.RowIndex].Cells["selected"].Value = false;
                        this.dataGridViewAccMark.RefreshEdit();
                        this.dataGridViewAccMark.NotifyCurrentCellDirty(true);

                        dataGridViewAccMark.Rows[hti.RowIndex].Cells["UnidadesAEntregar"].Value = 1;
                        this.dataGridViewAccMark.RefreshEdit();
                        this.dataGridViewAccMark.NotifyCurrentCellDirty(true);

                        if (_listaExclusion.Count > 0)
                        {
                            // acción deseleccionada
                            int idAccionUnSel = int.Parse(dataGridViewAccMark.Rows[hti.RowIndex].Cells["iIdAccionDataGridViewTextBoxColumn"].Value.ToString());

                            // Mirar si el deseleccionado está en la lista de exclusión y buscar parejas para dejar en blanco. 
                            // Después revisar todos los checks por si alguna selección implica tener en gris alguna de las que acabamos de poner en blanco 
                            foreach (ParejasExclusion pe in _listaExclusion)
                            {
                                if (pe.miembro_1 == idAccionUnSel || pe.miembro_2 == idAccionUnSel)
                                {
                                    // Identificar la pareja de la acción seleccionada
                                    int idAccionPareja = pe.miembro_1; // por defecto
                                    if (pe.miembro_1 == idAccionUnSel)
                                        idAccionPareja = pe.miembro_2;

                                    // Devolver la pareja al estado normal para que se pueda seleccionar ahora que ya no tiene la restricción
                                    // siempre y cuando no haya otra acción seleccionada que implique que continue en gris.
                                    foreach (DataGridViewRow row in dataGridViewAccMark.Rows)
                                    {
                                        // mira si alguna otra acción seleccionada la debe mantener en gris
                                        bool bRetornoABlanco = true;
                                        foreach (DataGridViewRow row2 in dataGridViewAccMark.Rows)
                                        {
                                            if (bool.Parse(row2.Cells["selected"].Value.ToString()))
                                            {
                                                int accioAux = int.Parse(row2.Cells["iIdAccionDataGridViewTextBoxColumn"].Value.ToString());
                                                if (accioAux != idAccionUnSel && accioAux != idAccionPareja)
                                                {
                                                    ParejasExclusion lpeAux = _listaExclusion.Find(x => (x.miembro_1 == idAccionPareja && x.miembro_2 == accioAux) || (x.miembro_1 == accioAux && x.miembro_2 == idAccionPareja));
                                                    if (lpeAux != null)
                                                    {
                                                        bRetornoABlanco = false;
                                                        break;
                                                    }
                                                }
                                            }
                                        }


                                        // la deja en blanco si es necesario
                                        if (bRetornoABlanco && int.Parse(row.Cells["iIdAccionDataGridViewTextBoxColumn"].Value.ToString()) == idAccionPareja)
                                        {
                                            for (int i = 0; i < row.Cells.Count; i++)
                                                row.Cells[i].Style.BackColor = Color.White;

                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else // unchecked --> checked
                    {
                        if (_listaExclusion.Count > 0)
                        {
                            // acción seleccionada
                            int idAccionSel = int.Parse(dataGridViewAccMark.Rows[hti.RowIndex].Cells["iIdAccionDataGridViewTextBoxColumn"].Value.ToString());
                            bool bApta = true;

                            // Mirar si el seleccionado está en la lista de exclusión  
                            int iPos = _listaExclusion.FindIndex(x => (x.miembro_1 == idAccionSel || x.miembro_2 == idAccionSel));
                            if (iPos >= 0)
                            {
                                // Si está en gris no se puede seleccionar
                                foreach (DataGridViewRow row in dataGridViewAccMark.Rows)
                                {
                                    if (int.Parse(row.Cells["iIdAccionDataGridViewTextBoxColumn"].Value.ToString()) == idAccionSel && row.Cells[0].Style.BackColor == Color.Gray)
                                    {
                                        Mensajes.ShowInformation("Esta acción no se puede seleccionar si previamente no desmarca la acción que la inhabilita.");

                                        row.Cells["selected"].Value = false;
                                        this.dataGridViewAccMark.RefreshEdit();
                                        this.dataGridViewAccMark.NotifyCurrentCellDirty(true);

                                        bApta = false;
                                        break;
                                    }
                                }

                                if (bApta)
                                {
                                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dataGridViewAccMark.Rows[hti.RowIndex].Cells["selected"];
                                    chk.Value = chk.TrueValue;
                                    dataGridViewAccMark.Rows[hti.RowIndex].Cells["selected"].Value = true;
                                    this.dataGridViewAccMark.RefreshEdit();
                                    this.dataGridViewAccMark.NotifyCurrentCellDirty(true);

                                    foreach (ParejasExclusion pe in _listaExclusion)
                                    {
                                        if (pe.miembro_1 == idAccionSel || pe.miembro_2 == idAccionSel)
                                        {
                                            // Identificar la pareja de la acción seleccionada
                                            int idAccionPareja = pe.miembro_1; // por defecto
                                            if (pe.miembro_1 == idAccionSel)
                                                idAccionPareja = pe.miembro_2;

                                            // Pintar la pareja en gris
                                            foreach (DataGridViewRow row in dataGridViewAccMark.Rows)
                                            {
                                                if (int.Parse(row.Cells["iIdAccionDataGridViewTextBoxColumn"].Value.ToString()) == idAccionPareja)
                                                    for (int i = 0; i < row.Cells.Count; i++)
                                                        row.Cells[i].Style.BackColor = Color.Gray;
                                            }
                                        }
                                    }
                                }
                            }

                            dataGridViewAccMark.Rows[hti.RowIndex].Cells["selected"].Value = true;
                            this.dataGridViewAccMark.RefreshEdit();
                            this.dataGridViewAccMark.NotifyCurrentCellDirty(true);

                        }
                        else
                        {
                            dataGridViewAccMark.Rows[hti.RowIndex].Cells["selected"].Value = true;
                            this.dataGridViewAccMark.RefreshEdit();
                            this.dataGridViewAccMark.NotifyCurrentCellDirty(true);
                        }


                    }

                    SetUnidadesAccMark();
                    GetDatosSeleccionAM();
                }
            }

        }

        private void dataGridViewLineas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    double fDescMG = 0;

                    //La campanya de la línia és amb mínim garantitzat?
                    string Campanya = dataGridViewLineas.Rows[e.RowIndex].Cells["ColidCampanya"].Value.ToString();
                    fDescMG = IsDescMinGarInformed(Campanya);

                    //---- GSG (13/03/2019)
                    //if (fDescMG == 0) // Es pot editar
                    //{
                    if (TipoAcceso != (int)acceso.CONSULTA) // En consulta queremos mantener el scroll pero no modificar
                    {
                        if (e.ColumnIndex == dataGridViewLineas.Columns["ColiIdLinea"].Index ||
                                e.ColumnIndex == dataGridViewLineas.Columns["sIdMaterialDataGridViewTextBoxColumn"].Index ||
                                e.ColumnIndex == dataGridViewLineas.Columns["ColProducto"].Index ||
                                e.ColumnIndex == dataGridViewLineas.Columns["ColCampanya"].Index)
                        {
                            //Selecciona la campanya del producte seleccionat al grid i automàticament canvia el SelectedIndex
                            cBoxCampanyas.SelectedValue = dataGridViewLineas.SelectedCells[K_COL_IDCAMP].Value; //"ColidCampanya"

                            DataRowView rowView = dsFormularios1.ListaCampanyas.DefaultView[cBoxCampanyas.SelectedIndex];

                            // amb el càlcul d'extres cal que hi hagi el destinatari triat quan és transfer
                            if (Comun.IsInTheArray(this.cboTipoPedido.SelectedValue.ToString(), Configuracion.asPedTransfer) && txtsDestinatario.Text.Trim() == "")
                                Mensajes.ShowError(String.Format("Debe indicar el Mayorista antes de continuar seleccionando materiales."));
                            else
                                BuscarMaterialesGrupo(rowView.Row, dataGridViewLineas.SelectedCells[K_COL_IDGRUPOMAT].Value.ToString()); //"ColIdGrupoMat"
                        }
                    }
                    //}
                    //---- GSG (13/03/2019)
                    //else 
                    //{
                    //    string NomCampanya = dataGridViewLineas.Rows[e.RowIndex].Cells["ColCampanya"].Value.ToString();
                    //    string msg = String.Format("Las líneas de la campaña {0} no pueden editarse por ser campaña con descuento mínimo garantizado.\r\nSi elige continuar las líneas de esta campaña se borrarán y deberá editarlas de nuevo.\r\n\r\n¿Desea continuar?", NomCampanya);
                    //    if (Mensajes.ShowQuestion(msg) == DialogResult.Yes)
                    //    {
                    //        int IdGrupoMat = (int)dataGridViewLineas.Rows[e.RowIndex].Cells["ColIdGrupoMat"].Value;
                    //        int firstIndex = -1;
                    //        do
                    //        {
                    //            firstIndex++;
                    //        } while ((int)dataGridViewLineas.Rows[firstIndex].Cells["ColIdGrupoMat"].Value != IdGrupoMat);

                    //        do
                    //        {
                    //            dataGridViewLineas.Rows.RemoveAt(firstIndex);
                    //        } while ((firstIndex < dataGridViewLineas.Rows.Count) &&
                    //            ((int)dataGridViewLineas.Rows[firstIndex].Cells["ColIdGrupoMat"].Value == IdGrupoMat));

                    //        dtLineasPedido.AcceptChanges();
                    //        lblCounter.Text = this.dtLineasPedido.DefaultView.Count.ToString();
                    //        ActualizarTotales();
                    //        FormatDataGridLineas();
                    //        Mensajes.ShowInformation(String.Format("La campaña {0} se ha borrado de las líneas del pedido.", NomCampanya));
                    //    }
                    //}
                }
            }
            catch (Exception ev)
            {
                Mensajes.ShowError("Error en función dataGridViewLineas_DoubleClick(): " + ev.ToString());
            }
        }

        private void dataGridViewLineas_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewLineas.EndEdit();
        }

        private void txbDescExtraRestante_TextChanged(object sender, EventArgs e)
        {
            if (double.Parse(txbDescExtraRestante.Text) < 0)
                Mensajes.ShowError("Se ha gastado más extra del disponible. El pedido no se guardará si no se modifican los materiales adecuadamente.");
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

        private void btAIndicadores_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (GESTCRM.Utiles.MirarSiAbierto(GESTCRM.Formularios.frmIndicadoresIAlarmas.ActiveForm, "frmIndicadoresIAlarmas"))
                {
                    GESTCRM.Utiles.ActivaFormularioAbierto("frmIndicadoresIAlarmas", this.MdiParent);
                }
                else
                {
                    Form frmTemp = new Formularios.frmIndicadoresIAlarmas();
                    frmTemp.MdiParent = this.MdiParent;
                    frmTemp.Show();
                }
            }
            catch (Exception ev)
            {
                Mensajes.ShowError("Error en evento btAPedido_Click: " + ev.Message);
            }
        }

        private void dtpFechaVenci_CloseUp(object sender, EventArgs e)
        {
            //_bDataVencCanviada = true;
            //_sDataVencCanviada = dtpFechaVenci.Text;
        }

        // Cerrar
        private void frmPedidos_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (TipoAcceso == (int)acceso.CONSULTA)
                return;

            //Si ya se ha guardado el pedido y no ha habido modificaciones posteriores, nos saltaremos la pregunta de salida.
            if (mensaje_al_salir)
            {
                // desea guardar?
                DialogResult dr = Mensajes.ShowQuestion(3002);

                if (dr == DialogResult.Yes)
                {
                    opcion_guardar(sender, e);
                }
            }
            else
                e.Cancel = false;


        }


        #region BuscarCliente
        private void btBuscarCliente_Click(object sender, System.EventArgs e)
        {
            try
            {
                txtDestinatarioSAP.Text = txtDestinatarioSAP.Text.Trim().ToUpper();
                txtClienteSAP.Text = txtClienteSAP.Text.Trim().ToUpper();

                GESTCRM.Formularios.Busquedas.frmMClientesSAP frmBCli = new GESTCRM.Formularios.Busquedas.frmMClientesSAP(false, "P");

                frmBCli.ParamI_sIdTipoCliente = "S";
                frmBCli.ParamIO_sIdCliente = "";
                frmBCli.ParamI_sIdCentro = "";
                frmBCli.ParamI_iIdDelegado = (iIdDelegado != 0) ? iIdDelegado : -1;
                frmBCli.ShowDialog(this);

                if (frmBCli.DialogResult == DialogResult.OK)
                {
                    txtClienteSAP.Text = frmBCli.ParamIO_sIdCliente;
                    txtsCliente.Text = frmBCli.ParamO_tNombre;
                    iIdCliente = frmBCli.ParamO_iIdCliente;

                    Application.DoEvents();

                    siCambioSocio(true);
                }

                mensaje_al_salir = true;
            }
            catch (Exception ev)
            {
                Mensajes.ShowError("Error en evento btBuscarCliente_Click: " + ev.Message);
            }
        }

        private void siCambioSocio(bool bTotales)
        {
            //---- GSG (27/09/2017)
            bool bComboCampActivo = true;

            if (txtClienteSAP.Text == "")
                bComboCampActivo = false;


            dto_general();

            txbDecil.Text = GESTCRM.Utiles.DecilCliente(iIdCliente);
            txbDecilP.Text = GESTCRM.Utiles.DecilProvincialCliente(iIdCliente);

            //Poner él mismo como destinatario
            if (!Comun.IsInTheArray(cboTipoPedido.SelectedValue.ToString(), Configuracion.asPedTransfer))
            {
                txtDestinatarioSAP.Text = txtClienteSAP.Text;
                txtsDestinatario.Text = txtsCliente.Text;
                iIdDestinatario = iIdCliente;

                _bEsDirectoZMAY = EsDirectoZMAY(iIdDestinatario); //Un mayorista es ZMAY si pertenece a un club que está en la tabla DirectoZMAY

                //---- GSG (06/03/2021)
                //if (GESTCRM.Utiles.DeudaVencida(iIdCliente))
                //    Mensajes.ShowInformation("Mientras no se liquide la deuda vencida este pedido no se servirá.");

                int ret = GESTCRM.Utiles.DeudaVencida(iIdCliente);
                switch (ret)
                {
                    case 1:
                        Mensajes.ShowInformation("Mientras no se liquide la deuda vencida este pedido no se servirá.");
                        break;
                    case 2:
                        Mensajes.ShowInformation("Un cliente Intrum solo puede pasar pedidos Transfer/Compromiso.");
                        break;
                    case 3:
                        Mensajes.ShowInformation("Mientras no se liquide la deuda vencida este pedido no se servirá.\r\nUn cliente Intrum solo puede pasar pedidos Transfer/Compromiso.");
                        break;

                }
            }
            else
            {
                if (this.txtDestinatarioSAP.Text != "")
                    Mensajes.ShowInformation("Posiblemente el Mayorista seleccionado no esté relacionado con el Solicitante");
            }

            //Cambia el combo de campañas de línea?
            string[] llista = new string[cBoxCampanyas.Items.Count]; // Lista Original de campañas
            for (int i = 0; i < cBoxCampanyas.Items.Count; i++)
                llista[i] = cBoxCampanyas.GetItemText(cBoxCampanyas.Items[i]);

            //---- GSG (05/07/2017)
            //bool bCambioCombo = FormatBuscarCampanyas(iIdCliente, true, cboTipoPedido.SelectedValue.ToString());
            //---- GSG (27/09/2017)
            //bool bCambioCombo = FormatBuscarCampanyas(iIdCliente, true, cboTipoPedido.SelectedValue.ToString(), txtDestinatarioSAP.Text.Trim());
            bool bCambioCombo = FormatBuscarCampanyas(iIdCliente, bComboCampActivo, cboTipoPedido.SelectedValue.ToString(), txtDestinatarioSAP.Text.Trim());


            if (bCambioCombo)
            {
                if (lblCounter.Text.Trim() == "")
                    lblCounter.Text = "0";

                if (int.Parse(lblCounter.Text) > 0)
                {
                    string[] llista2 = new string[cBoxCampanyas.Items.Count]; // Lista según cambio (ha d'estar aquí per saber la dimensió del array)

                    for (int i = 0; i < cBoxCampanyas.Items.Count; i++)
                        llista2[i] = cBoxCampanyas.GetItemText(cBoxCampanyas.Items[i]);

                    if (!Comun.bEquals(llista, llista2)) // Las campañas de línea han cambiado
                    {
                        string[] diffs = Comun.GetDifferenceOfArrays(llista, llista2);

                        if (diffs.Length > 0)
                        {
                            if (Mensajes.ShowQuestion("Con el cambio de cliente las campañas de línea permitidas han cambiado.\n\nSi acepta, las líneas del pedido seleccionadas pueden ser borradas si no pertecen a una campaña ahora posible, si cancela el pedido quedará como estaba.\n\n¿Desea continuar con el cambio de cliente?") == DialogResult.Yes)
                            {
                                // Borrar líneas del pedido
                                for (int i = dataGridViewLineas.Rows.Count - 1; i >= 0; i--)
                                {
                                    if (Comun.IsInTheArray(dataGridViewLineas.Rows[i].Cells["ColCampanya"].Value.ToString(), diffs))
                                        dataGridViewLineas.Rows.RemoveAt(i);
                                }

                                dtLineasPedido.AcceptChanges();
                                lblCounter.Text = this.dtLineasPedido.DefaultView.Count.ToString();
                                ActualizarTotales();
                                FormatDataGridLineas();
                            }
                            else { }
                        }
                    }
                }
            }


            //---- GSG (03/07/2019)
            if (ProponerEncuesta())
                Mensajes.ShowInformation("El cliente tiene una encuesta pendiente de realizar.");



            btnBuscarMaterial.Enabled = cBoxCampanyas.Enabled;

            AvisoUVM(1);

            pintaRentabilidadAnual(false, DateTime.Today);

            if (bTotales)
                ActualizarTotales();

            txtProgInf.Text = GetProgramaInformatico(this.iIdCliente);
            ActualizarImporteMedioPedido(this.iIdCliente);
            cboProgInf.SelectedIndex = cboProgInf.FindString(txtProgInf.Text);

            if (cboProgInf.SelectedIndex == -1)
                cboProgInf.SelectedIndex = 0;

            // Obtiene los datos de contactos clientes o bien de clientes SAP
            cargarNIFyCC();

            AvisoTarjetasCliente(this.txtClienteSAP.Text);
            //---- GSG (13/03/2019)
            //---- GSG (19/09/2017)
            //AvisoProximoObjetivo(this.txtClienteSAP.Text);
            AvisoProximoObjetivo(this.txtClienteSAP.Text, dtpFechaPedido.Value);
            AvisoAccionesAbiertasCliente(this.txtClienteSAP.Text);
        }

        private void txtClienteSAP_Leave(object sender, System.EventArgs e)
        {
            try
            {
                if (TipoAcceso != (int)acceso.CONSULTA)
                {
                    txtDestinatarioSAP.Text = txtDestinatarioSAP.Text.Trim().ToUpper();
                    txtClienteSAP.Text = txtClienteSAP.Text.Trim().ToUpper();

                    GESTCRM.Formularios.Busquedas.frmMClientesSAP frmBCli = new GESTCRM.Formularios.Busquedas.frmMClientesSAP("P");

                    frmBCli.ParamI_iIdDelegado = (iIdDelegado != 0) ? iIdDelegado : -1;
                    frmBCli.ParamI_sIdCentro = "";
                    frmBCli.ParamI_sIdTipoCliente = "";
                    frmBCli.ParamIO_sIdCliente = this.txtClienteSAP.Text.ToString();
                    frmBCli.Buscar_tNombre();

                    string sIdClienteAntiguo = this.txtClienteSAP.Text.ToString();


                    this.txtClienteSAP.Text = frmBCli.ParamIO_sIdCliente;
                    this.txtsCliente.Text = frmBCli.ParamO_tNombre;
                    this.iIdCliente = frmBCli.ParamO_iIdCliente;

                    siCambioSocio(false);
                }
            }
            catch (Exception ev)
            {
                Mensajes.ShowError("Error en evento txtClienteSAP_Leave: " + ev.ToString());
            }

        }

        #endregion

        #region BuscarDestinatario
        private void btBuscarDestinatario_Click(object sender, System.EventArgs e)
        {
            try
            {
                if ((this.txtClienteSAP.Text == "") && (!Comun.IsInTheArray(cboTipoPedido.SelectedValue.ToString(), Configuracion.asPedTransfer)))
                {
                    if (this.txtDestinatarioSAP.Text != "")
                    {
                        iIdDestinatario = -1;
                        this.txtsDestinatario.Text = "";
                        this.txtDestinatarioSAP.Text = "";
                        Mensajes.ShowError("No se puede buscar el pagador si no se introduce previamente el solicitante.");
                    }
                }
                else if (!Comun.IsInTheArray(cboTipoPedido.SelectedValue.ToString(), Configuracion.asPedTransfer))
                {
                    // Cuando el solicitante y el pagador son distintos el cuadro de búsqueda para destinatario debe mostrar todos los clientes igual que al buscar cliente

                    //---- GSG (07/10/2016)

                    /*
                    GESTCRM.Formularios.Busquedas.frmMClientesSAP frmBCli = new GESTCRM.Formularios.Busquedas.frmMClientesSAP(false, "P");

                    frmBCli.ParamI_sIdTipoCliente = "S";
                    frmBCli.ParamIO_sIdCliente = "";
                    frmBCli.ParamI_sIdCentro = "";
                    frmBCli.ParamI_iIdDelegado = (iIdDelegado != 0) ? iIdDelegado : -1;

                    frmBCli.ShowDialog(this);

                    if (frmBCli.DialogResult == DialogResult.OK)
                    {
                        txtDestinatarioSAP.Text = frmBCli.ParamIO_sIdCliente;
                        txtsDestinatario.Text = frmBCli.ParamO_tNombre;
                        iIdDestinatario = frmBCli.ParamO_iIdCliente;

                        Application.DoEvents();
                    }

                    */

                    txtDestinatarioSAP.Text = txtDestinatarioSAP.Text.Trim().ToUpper();
                    int iIdCliente = -1;
                    string sIdCliente = "";
                    string sNombre = "";

                    if (this.txtClienteSAP.Text != "")
                    {
                        iIdCliente = this.iIdCliente;
                        sIdCliente = this.txtClienteSAP.Text.ToString();
                        sNombre = this.txtsCliente.Text.ToString();
                    }

                    GESTCRM.Formularios.Busquedas.frmMClientesInterloc frmMClientesInterloc;
                    frmMClientesInterloc = new GESTCRM.Formularios.Busquedas.frmMClientesInterloc(iIdCliente, sIdCliente, sNombre);
                    frmMClientesInterloc.ShowDialog();

                    if (frmMClientesInterloc.DialogResult == System.Windows.Forms.DialogResult.OK)
                    {
                        txtDestinatarioSAP.Text = frmMClientesInterloc.ParamO_sIdClientePagador;
                        txtsDestinatario.Text = frmMClientesInterloc.ParamO_sNombreClientePagador;
                        iIdDestinatario = frmMClientesInterloc.ParamO_iIdClientePagador;

                        Application.DoEvents();
                    }



                    if (this.iIdCliente != this.iIdDestinatario)
                        cargarNIFyCC();
                }
                else //TRANSFER
                {
                    txtDestinatarioSAP.Text = txtDestinatarioSAP.Text.Trim().ToUpper();
                    int Interlocutor;
                    int iIdCliente = -1;
                    string sIdCliente = "";
                    string sNombre = "";

                    if (Comun.IsInTheArray(cboTipoPedido.SelectedValue.ToString(), Configuracion.asPedTransfer))
                        Interlocutor = 0;
                    else
                        Interlocutor = 1;

                    if (this.txtClienteSAP.Text != "")
                    {
                        iIdCliente = this.iIdCliente;
                        sIdCliente = this.txtClienteSAP.Text.ToString();
                        sNombre = this.txtsCliente.Text.ToString();
                    }

                    GESTCRM.Formularios.Busquedas.frmMMayoristas frmMayorista;
                    frmMayorista = new GESTCRM.Formularios.Busquedas.frmMMayoristas(iIdCliente, sIdCliente, sNombre, Interlocutor);
                    frmMayorista.ShowDialog();

                    if (frmMayorista.DialogResult == System.Windows.Forms.DialogResult.OK)
                    {
                        txtDestinatarioSAP.Text = frmMayorista.ParamO_sIdMayorista;
                        txtsDestinatario.Text = frmMayorista.ParamO_sNombreMayorista;
                        iIdDestinatario = frmMayorista.ParamO_iIdClienteMayorista;

                        _bEsDirectoZMAY = EsDirectoZMAY(iIdDestinatario); //Un mayorista es ZMAY si pertenece a un club que está en la tabla DirectoZMAY

                        ActualizarTotales();
                    }
                }

                mensaje_al_salir = true;
            }
            catch (Exception ev)
            {
                Mensajes.ShowError("Error en evento btBuscarDestinatario_Click: " + ev.ToString());
            }
        }

        private void txtDestinatarioSAP_Leave(object sender, System.EventArgs e)
        {
            try
            {
                if (TipoAcceso != (int)acceso.CONSULTA)
                {
                    if ((this.txtClienteSAP.Text == "") && (!Comun.IsInTheArray(cboTipoPedido.SelectedValue.ToString(), Configuracion.asPedTransfer)))
                    {
                        if (this.txtDestinatarioSAP.Text != "")
                        {
                            iIdDestinatario = -1;
                            this.txtsDestinatario.Text = "";
                            this.txtDestinatarioSAP.Text = "";
                            Mensajes.ShowError("No se puede introducir el pagador si no se introduce previamente el solicitante.");
                        }
                    }
                    else
                    {
                        txtDestinatarioSAP.Text = txtDestinatarioSAP.Text.Trim().ToUpper();

                        int Interlocutor;
                        int iIdCliente = -1;
                        string sIdCliente = "";
                        string sNombre = "";

                        if (Comun.IsInTheArray(cboTipoPedido.SelectedValue.ToString(), Configuracion.asPedTransfer)) Interlocutor = 0;
                        else Interlocutor = 1;

                        if (this.txtClienteSAP.Text != "")
                        {
                            iIdCliente = this.iIdCliente;
                            sIdCliente = this.txtClienteSAP.Text.ToString();
                            sNombre = this.txtsCliente.Text.ToString();
                        }

                        if (this.txtDestinatarioSAP.Text != "")
                        {
                            GESTCRM.Formularios.Busquedas.frmMMayoristas frmMayorista;
                            frmMayorista = new GESTCRM.Formularios.Busquedas.frmMMayoristas(iIdCliente, sIdCliente, sNombre, Interlocutor);
                            frmMayorista.DevuelveMayorista(txtDestinatarioSAP.Text);

                            txtsDestinatario.Text = frmMayorista.ParamO_sNombreMayorista;
                            this.txtDestinatarioSAP.Text = frmMayorista.ParamO_sIdMayorista;
                            iIdDestinatario = frmMayorista.ParamO_iIdClienteMayorista;
                            if (iIdDestinatario == -1)
                            {
                                this.txtsDestinatario.Text = "";
                                this.txtDestinatarioSAP.Text = "";
                                _bEsDirectoZMAY = false;
                            }
                            else
                            {
                                _bEsDirectoZMAY = EsDirectoZMAY(iIdDestinatario); //Un mayorista es ZMAY si pertenece a un club que está en la tabla DirectoZMAY
                            }

                            bool bActivo = true;
                            if (iIdCliente == -1 || iIdCliente == 0)
                                bActivo = false;
                            //---- GSG (05/07/2017)
                            //FormatBuscarCampanyas(iIdCliente, bActivo, _sTipoPedidoNew); // Cambia el combo de campañas
                            FormatBuscarCampanyas(iIdCliente, true, cboTipoPedido.SelectedValue.ToString(), txtDestinatarioSAP.Text.Trim());
                        }
                        else
                        {
                            this.iIdDestinatario = -1;
                            this.txtsDestinatario.Text = "";
                            _bEsDirectoZMAY = false;
                        }
                    }

                    if (!Comun.IsInTheArray(cboTipoPedido.SelectedValue.ToString(), Configuracion.asPedTransfer) && this.iIdCliente != this.iIdDestinatario)
                        cargarNIFyCC();
                }
            }
            catch (Exception ev)
            {
                Mensajes.ShowError("Error en evento txtDestinatarioSAP_Leave: " + ev.ToString());
            }
        }


        //---- GSG (05/07/2017)
        private void txtDestinatarioSAP_TextChanged(object sender, EventArgs e)
        {
            if (TipoAcceso != (int)acceso.CONSULTA && Comun.IsInTheArray(cboTipoPedido.SelectedValue.ToString(), Configuracion.asPedTransfer))
            {
                // Lista Original de campañas
                string[] llista = new string[cBoxCampanyas.Items.Count];
                for (int i = 0; i < cBoxCampanyas.Items.Count; i++)
                    llista[i] = cBoxCampanyas.GetItemText(cBoxCampanyas.Items[i]);

                // Lista de campañas según cambio
                FormatBuscarCampanyas(iIdCliente, true, cboTipoPedido.SelectedValue.ToString(), txtDestinatarioSAP.Text.Trim());
                string[] llista2 = new string[cBoxCampanyas.Items.Count]; //(ha d'estar aquí per saber la dimensió del array)
                for (int i = 0; i < cBoxCampanyas.Items.Count; i++)
                    llista2[i] = cBoxCampanyas.GetItemText(cBoxCampanyas.Items[i]);

                if (!Comun.bEquals(llista, llista2)) // Las campañas de línea han cambiado 
                {
                    if (Mensajes.ShowQuestion("Con el cambio de mayorista las campañas permitidas han cambiado.\n\nSi acepta, algunas las líneas del pedido pueden ser borradas por no pertenecer a una campaña activa, si cancela, el pedido quedará como estaba.\n\n¿Desea continuar con el cambio de mayorista?") == DialogResult.Yes)
                    {
                        // Borrar líneas del pedido que no pertenecen a campañas comunes
                        string[] diffs = Comun.GetDifferenceOfArrays(llista, llista2);

                        if (diffs.Length > 0)
                        {
                            for (int i = dataGridViewLineas.Rows.Count - 1; i >= 0; i--)
                            {
                                if (Comun.IsInTheArray(dataGridViewLineas.Rows[i].Cells["ColCampanya"].Value.ToString(), diffs))
                                    dataGridViewLineas.Rows.RemoveAt(i);
                            }
                            dtLineasPedido.AcceptChanges();
                        }


                        // Actualizar datos 
                        lblCounter.Text = this.dtLineasPedido.DefaultView.Count.ToString();
                        FormatDataGridLineas();
                        ActualizarTotales();
                    }
                }


            }
        }
        #endregion

        #region grid

        bool _bFin = true;        

        private void dataGridViewLineas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewLineas.CurrentCell != null)
            {
                if (e.ColumnIndex == dataGridViewLineas.Columns["ColBorrar"].Index && _bFin == true)
                {
                    _bFin = false;

                    if (dataGridViewLineas.CurrentCell.ReadOnly == false)
                        dataGridViewLineas.BeginEdit(true);
                    else
                    {
                        if (e.ColumnIndex == dataGridViewLineas.Columns["ColBorrar"].Index) //Se quiere borrar la línea
                        {
                            int IdGrupoMat = (int)dataGridViewLineas.Rows[e.RowIndex].Cells["ColIdGrupoMat"].Value;
                            string campanya = dataGridViewLineas.Rows[e.RowIndex].Cells["ColCampanya"].Value.ToString();
                            string producto = dataGridViewLineas.Rows[e.RowIndex].Cells["ColProducto"].Value.ToString();
                            char dot = (char)0x25CF;

                            if (EsObligatorio(e.RowIndex))
                            {
                                string msg = String.Format("No puede borrar esta línea.\n\n {2} Este producto ({0})" +
                                    " es obligatorio en la campaña {1}.\n\n¿Desea borrar la campaña completa?", producto, campanya, dot);

                                if (Mensajes.ShowQuestion(msg) == DialogResult.Yes)
                                {
                                    int firstIndex = -1;
                                    do
                                    {
                                        firstIndex++;
                                    } while ((int)dataGridViewLineas.Rows[firstIndex].Cells["ColIdGrupoMat"].Value != IdGrupoMat);

                                    do
                                    {
                                        dataGridViewLineas.Rows.RemoveAt(firstIndex);
                                    } while ((firstIndex < dataGridViewLineas.Rows.Count) &&
                                        ((int)dataGridViewLineas.Rows[firstIndex].Cells["ColIdGrupoMat"].Value == IdGrupoMat));

                                    dtLineasPedido.AcceptChanges();
                                    lblCounter.Text = this.dtLineasPedido.DefaultView.Count.ToString();
                                    ActualizarTotales();
                                    FormatDataGridLineas();
                                    Mensajes.ShowInformation(String.Format("La campaña {0} se ha borrado de las líneas del pedido.", campanya));
                                }
                            }
                            else
                            {
                                string msg = String.Format("¿Está segura/o de querer borrar esta línea?.\n\n");
                                if (Mensajes.ShowQuestion(msg) == DialogResult.Yes)
                                {
                                    string IdCampanya = dataGridViewLineas.Rows[e.RowIndex].Cells["ColIdCampanya"].Value.ToString();

                                    dsFormularios.ListaCampanyasRow row = GetCampanyaById(IdCampanya);

                                    int NumMinOblis = row.iNumMinOblis;
                                    double ImporteMinObli = 0;

                                    if (row.fImporteMinObliBruto > 0)
                                        ImporteMinObli = row.fImporteMinObliBruto;
                                    else
                                        ImporteMinObli = row.fImporteMinObli;

                                    int CantidadMinObli = row.iNumMinOblisTotal;
                                    int CantidadTotal = 0;

                                    //Calcular importe del grupo y número de líneas
                                    int NumLineas = 0;
                                    double ImporteTotal = 0.0;
                                    double ImporteTotalBruto = 0.0;

                                    foreach (dsMateriales.ListaLineasPedidoRow dr in dtLineasPedido.Rows)
                                    {
                                        if (dr.idGrupoMat == IdGrupoMat)
                                        {
                                            NumLineas++;
                                            ImporteTotal += dr.ImporteLin;
                                            ImporteTotalBruto += dr.fPrecio;
                                            CantidadTotal += int.Parse(dr.iCantidad);
                                        }
                                    }

                                    NumLineas -= 1;
                                    ImporteTotal -= (double)dataGridViewLineas.Rows[e.RowIndex].Cells["ColImporteLin"].Value;
                                    ImporteTotalBruto -= (double)dataGridViewLineas.Rows[e.RowIndex].Cells["ColPrecioBruto"].Value;
                                    CantidadTotal -= int.Parse(dataGridViewLineas.Rows[e.RowIndex].Cells["ColCantidad"].Value.ToString());

                                    StringBuilder ErrorMessage = new StringBuilder();

                                    if (NumLineas < NumMinOblis)
                                        ErrorMessage.AppendFormat(" {2} Para la campaña {0} debe seleccionar al menos {1} materiales.", campanya, NumMinOblis, dot);

                                    if (CantidadTotal < CantidadMinObli)
                                        ErrorMessage.AppendFormat(" {2} Para la campaña {0} debe tener al menos {1} unidades.", campanya, CantidadMinObli, dot);

                                    if (row.fImporteMinObliBruto > 0)
                                    {
                                        if (ImporteTotalBruto < ImporteMinObli)
                                        {
                                            if (ErrorMessage.Length > 0)
                                                ErrorMessage.Append("\n");
                                            ErrorMessage.AppendFormat(" {2} El nuevo importe bruto total de la campaña ({0:C}) no puede ser menor que {1:C}.", ImporteTotalBruto, ImporteMinObli, dot);
                                        }
                                    }
                                    else
                                    {
                                        if (ImporteTotal < ImporteMinObli)
                                        {
                                            if (ErrorMessage.Length > 0)
                                                ErrorMessage.Append("\n");
                                            ErrorMessage.AppendFormat(" {2} El nuevo importe total de la campaña ({0:C}) no puede ser menor que {1:C}.", ImporteTotal, ImporteMinObli, dot);
                                        }
                                    }

                                    // Si no hi ha error en aquest punt encara falta mirar les validacions per presentacions
                                    // Si hi ha un error anterior no ho mirarem
                                    if (ErrorMessage.Length == 0)
                                    {
                                        ErrorMessage.Insert(0, SeViolaMinimosPresentacionAlBorrar(e));
                                    }

                                    if (ErrorMessage.Length > 0)
                                    {
                                        ErrorMessage.Insert(0, "No puede borrar esta línea.\n\n");
                                        ErrorMessage.Append("\n\n¿Desea borrar la campaña completa?");

                                        if (Mensajes.ShowQuestion(ErrorMessage.ToString()) == DialogResult.Yes)
                                        {
                                            int firstIndex = -1;
                                            do
                                            {
                                                firstIndex++;
                                            } while ((int)dataGridViewLineas.Rows[firstIndex].Cells["ColIdGrupoMat"].Value != IdGrupoMat);


                                            for (int i = dataGridViewLineas.Rows.Count - 1; i >= firstIndex; i--)
                                            {
                                                if ((int)dataGridViewLineas.Rows[i].Cells["ColIdGrupoMat"].Value == IdGrupoMat)
                                                    dataGridViewLineas.Rows.RemoveAt(i);
                                            }

                                            dtLineasPedido.AcceptChanges();
                                            lblCounter.Text = this.dtLineasPedido.DefaultView.Count.ToString();
                                            ActualizarTotales();
                                            FormatDataGridLineas();
                                            Mensajes.ShowInformation(String.Format("La campaña {0} se ha borrado de las líneas del pedido.", campanya));
                                        }
                                    }
                                    else
                                    {
                                        dataGridViewLineas.Rows.RemoveAt(e.RowIndex);
                                        dtLineasPedido.AcceptChanges();
                                        lblCounter.Text = this.dtLineasPedido.DefaultView.Count.ToString();
                                        ActualizarTotales();
                                        FormatDataGridLineas();
                                        Mensajes.ShowInformation(String.Format("El producto {0} de la campaña {1} se ha borrado de las líneas del pedido.", producto, campanya));
                                    }
                                }
                            }
                        }
                    }

                    _bFin = true;
                }
            }
        }

        private void dataGridViewLineas_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            double fDescMG = 0;

            if (e.ColumnIndex == dataGridViewLineas.Columns["ColDescuento"].Index)
            {
                //La campanya de la línia és amb mínim garantitzat?
                string Campanya = dataGridViewLineas.Rows[e.RowIndex].Cells["ColidCampanya"].Value.ToString();
                fDescMG = IsDescMinGarInformed(Campanya);
            }

            // Si la campaña té un mínim descompte garantitzat no es pot editar
            if (fDescMG == 0)
            {
                _bEsCeldaMG = false;

                if (e.ColumnIndex == dataGridViewLineas.Columns["ColCantidad"].Index) //Cantidad
                {
                    string tipText = dataGridViewLineas.Rows[e.RowIndex].Cells["ColUnidMinimas"].Value.ToString();
                    Mensajes.SetTip("Unidades mínimas", tipText);
                }
                else
                    if (e.ColumnIndex == dataGridViewLineas.Columns["ColDescuento"].Index) //Descuento
                {
                    string tipText = dataGridViewLineas.Rows[e.RowIndex].Cells["ColDescuentoMaximo"].Value.ToString() + "%"; // Descuento máximo permitido para el material según la campaña a la que pertenece
                    Mensajes.SetTip("Descuento máximo", tipText);
                }

                mensaje_al_salir = true;
            }
            else
            {
                _bEsCeldaMG = true;
                _fDescMGInicial = double.Parse(dataGridViewLineas.Rows[e.RowIndex].Cells["ColDescuento"].Value.ToString());
                string NomCampanya = dataGridViewLineas.Rows[e.RowIndex].Cells["ColCampanya"].Value.ToString();
                Mensajes.ShowInformation(String.Format("Las líneas de la campaña {0} no pueden editarse por ser campaña con descuento mínimo garantizado.", NomCampanya));
            }
        }

        private void dataGridViewLineas_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (!_bEsCeldaMG)
            {
                if (numericUpDownA.Visible == false)
                {
                    Mensajes.HideTip();

                    if (SetDefault == true)
                    {
                        dataGridViewLineas.CurrentCell.Value = DefaultValue;
                        SetDefault = false;
                    }

                    ActualizarImporteLinea(e.RowIndex);

                    if (valorsCampanya(sender, e))
                        ActualizarTotales();
                }
            }
            else
                dataGridViewLineas.CurrentCell.Value = _fDescMGInicial;
        }

        #endregion

        //---- GSG (13/09/2016)
        #region pestanyas
        private void tabPedido_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabPedido.SelectedIndex == 1)
            {
                if (_importeAnteriorMKT != txbImporteBruto.Text || (_importeAnteriorMKT == txbImporteBruto.Text && _importeAnteriorMKT == "0.00 €"))
                {
                    ResetValuesProdEnPedido();
                    ResetAccMark();
                    ResetGridAccMark();

                    GetValuesProdEnPedido();
                    CargarAccMark();
                    UpdateDataGridView(sIdPedido); //Actualiza el grid de acciones de márketing
                    GetDatosPedParaAM();
                    GetDatosSeleccionAM();
                }
                //---- FI GSG



                _importeAnteriorMKT = txbImporteBruto.Text; //---- GSG (13/03/2019)
            }
            else
            {
                //---- GSG (13/03/2019)

                //ResetValuesProdEnPedido();
                //ResetAccMark(); 
                //ResetGridAccMark();
            }
        }
        #endregion

        #endregion

        private static bool isInList(string s, string value)
        {
            if (s == value)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #region Guardar Pedido

        private void opcion_guardar(object sender, System.EventArgs e)
        {


            // ret = -2 --> error chungo al guardar el pedido
            // ret = -1 --> no se ha guardado el pedido por no pasar las validaciones
            // ret = 0 --> pedido guardado 
            int ret = -1;

            if (!_bGuardandoPedido)
            {
                _bGuardandoPedido = true;


                //---- GSG (03/07/2019)
                //-- Si hay encuesta obligatoria y no se ha contestado no se puede guardar el pedido
                if (btEncuestas.Enabled)
                    Encuestas(false);

                if (!_bEncuesta && btEncuestas.Enabled)
                {
                    Mensajes.ShowError("No se guardará el pedido hasta que haya contestado la encuesta.");
                    mensaje_al_salir = true;
                    ret = -1;
                }
                else if (btEncuestas.Enabled) //---- GSG (03/07/2019)
                {
                    if (controlClienteCondicionEspecialFactura()) //---- GSG (23/06/2017)
                    {
                        //if (TratarNIFyCC())
                        //{
                        ret = guardar_pedido();

                        if (ret == 0)
                        {
                            if (TipoAcceso == (int)acceso.INSERCION)
                            {
                                Mensajes.ShowInformation("Se ha creado el pedido " + sIdPedido + " correctamente.");
                                this.txbIdPedido.Text = sIdPedido;

                                TipoAcceso = (int)acceso.MODIFICACION;
                                mensaje_al_salir = false;
                                this.Close();
                            }
                            else
                            {
                                Mensajes.ShowInformation("El pedido " + sIdPedido + " se ha guardado correctamente.");
                                mensaje_al_salir = false;
                                this.Close();
                            }
                        }
                        else if (ret == -2)
                        {
                            Mensajes.ShowInformation("El pedido no se ha podido guardar. Póngase en contacto con HelpDesk.");
                            mensaje_al_salir = true;
                        }
                        else if (ret == -3) //---- GSG (13/03/2019)
                        {
                            // No hacer nada. Para no salir si se ha pulsado no salir cuando no hay acciones de márketing
                        }
                        //else if (ret == -1) 
                        // Si retorna -1 no cal fer res pq ja haurà mostrat el missatge a la funció guardar_pedido o a TratarNIFyCC
                        else if (ret != -1)
                        {
                            Mensajes.ShowInformation("Error desconocido. Póngase en contacto con HelpDesk.");
                            mensaje_al_salir = true;
                        }
                        //}
                    }
                }
                else //---- GSG (03/07/2019)
                {
                    ret = 0;
                    mensaje_al_salir = false;
                    this.Close();
                }

                _bGuardandoPedido = false;
            }
        }

        private int guardar_pedido()
        {
            // 0 -> guardado ok
            //-1 -> no pasa validacion
            //-2 -> ha habido un error al intentar guardar

            //int iMinMaterialsAccMark = 0;
            //int iMinUnitatsAccMark = 0;                
            //float fMinPreuAccMark = 0;
            //float fMinPreuAccMarkNet = 0; 
            string sMaterialsComptats = "";
            string sMaterial = "";
            int iNumMaterials = 0;
            int iIdAccion = 0;




            //---- GSG (13/03/2019)

            ////---- GSG (13/09/2016)
            //// ATENCIÓN: Por el momento, Si se pulsa guardar desde la pestaña pedidos no se va a guardar ninguna acción de márketing ya que se resetean al entrar en ella porque el pedido puede canviar y ya no tendríamos las mismas condiciones

            //if (tabPedido.SelectedIndex == 1)
            //{
            //    List<string> lMiss = ValidaSeleccionAcckMark();
            //    if (lMiss.Count > 0)
            //    {
            //        // Eliminar posibles mensajes repetidos (en la actual versión esto puede suceder ya que simplificamos los mensajes y si por ejemplo, para un mismo producto tenemos un grupo que suma y otras acciones individuales, pueden provocar el mismo mensaje exacto)
            //        List<string> lResult = new List<string>();
            //        lResult = Utiles.eliminarDuplicadosListString(lMiss);
            //        string miss = "";

            //        foreach (string val in lResult)
            //            miss += (val + "\r\n");

            //        Mensajes.ShowError(miss);
            //        return -1;
            //    }
            //}
            //else
            //    Mensajes.ShowInformation("El pedido se guardará sin acciones de márketing.");


            //----  VLP (10/10/2023)
            if (!CambiarTipoPedido())
            {
                Mensajes.ShowExclamation("La campaña seleccionada es especial para descuentos en línea y es incompatible con el uso de otras campañas. El pedido solo puede tener esta campaña.");
                return -1;
            }

            //---- GSG (02/01/2023)
            // Validación de fechas
            int daysDiff = Comun.GetWorkingDays(dtpFechaPedido.Value, dtpFechaPref.Value);

            if (cboTipoPedido.SelectedValue.ToString() == Comun.K_TIPOPED_COMPROMISO && daysDiff <= 0)
            {
                Mensajes.ShowError("La fecha del pedido debe ser inferior a la fecha vigencia para pedido compromiso.");
                return -1;
            }
            else if (cboTipoPedido.SelectedValue.ToString() == Comun.K_TIPOPED_COMPROMISO && daysDiff > 0 && Clases.Configuracion.iDiasCompromiso > 0 && daysDiff > Clases.Configuracion.iDiasCompromiso)
            {
                Mensajes.ShowError("La fecha de vigencia supera el valor máximo permitido. Para el pedido compromiso no puede exceder en " + Clases.Configuracion.iDiasCompromiso + " días laborables a la fecha del pedido.");
                return -1;
            }
            else if (cboTipoPedido.SelectedValue.ToString() == Comun.K_TIPOPED_TRANSFER && daysDiff > 0 && Clases.Configuracion.iDiasTransfer > 0 && daysDiff > Clases.Configuracion.iDiasTransfer)
            {
                Mensajes.ShowError("La fecha de entrega supera el valor máximo permitido. Para el pedido transfer no puede exceder en " + Clases.Configuracion.iDiasTransfer + " días laborables a la fecha del pedido.");
                return -1;
            }
            else if (cboTipoPedido.SelectedValue.ToString() == Comun.K_TIPOPED_DIRECTO && daysDiff > 0 && Clases.Configuracion.iDiasDirecto > 0 && daysDiff > Clases.Configuracion.iDiasDirecto)
            {
                Mensajes.ShowError("La fecha de entrega supera el valor máximo permitido. Para el pedido directo no puede exceder en " + Clases.Configuracion.iDiasDirecto + " días laborables a la fecha del pedido.");
                return -1;
            }
            //---- FI GSG



            //---- GSG (06/03/2021)
            int ret = GESTCRM.Utiles.DeudaVencida(iIdCliente);
            if (ret == 2 && !Comun.IsInTheArray(cboTipoPedido.SelectedValue.ToString(), Configuracion.asPedTransfer)) // Cliente intrum y Directos
            {
                Mensajes.ShowError("El pedido no se puede guardar porque un cliente Intrum solo puede pasar pedidos Transfer/Compromiso.");
                return -1;
            }


            string datosBanc = txbIBAN.Text + txbEntidad.Text + txbOficina.Text + "-" + txbControl.Text + "-" + txbCC.Text;
            int iPagador = this.iIdCliente;
            if (!Comun.IsInTheArray(cboTipoPedido.SelectedValue.ToString(), Configuracion.asPedTransfer) && this.iIdCliente != this.iIdDestinatario) //DIR
                iPagador = this.iIdDestinatario;

            //---- GSG (07/01/2022)
            // Los clientes que pagan en metálico no necesitan tener CC. Caso ejemplo: Centro penitenciario de Céuta de Núria Pérez

            //if (datosBanc.Trim() == "--" && !Comun.IsInTheArray(cboTipoPedido.SelectedValue.ToString(), Configuracion.asPedTransfer) && !EsAndorrano(iPagador))
            if (datosBanc.Trim() == "--" && !Comun.IsInTheArray(cboTipoPedido.SelectedValue.ToString(), Configuracion.asPedTransfer) && !EsAndorrano(iPagador) && _sCondPago != Comun.K_ENMETALICO)
            {
                Mensajes.ShowError("El pedido no se puede guardar porque el cliente no tiene los datos bancarios informados. Para hacer un pedido directo la información bancaria es necesaria.");
                return -1;
            }



            //---- GSG (02/01/2023)
            // Assegurar que no se quería hacer un pedido clásico
            // Validar que si es de mínimos lleva una unidad en cada SKU
            if (pnCompromiso.Visible)
            {
                int iCuentaUnidades = 0;

                for (int i = 0; i < dtLineasPedido.DefaultView.Count; i++)
                {
                    iCuentaUnidades += dtLineasPedido.DefaultView[i]["iCantidad"] == DBNull.Value ? 0 : int.Parse(dtLineasPedido.DefaultView[i]["iCantidad"].ToString());
                }

                if (_iMinimos == 1)
                {
                    if (iCuentaUnidades != dtLineasPedido.DefaultView.Count)
                    {
                        Mensajes.ShowError("La cantidad en un compromiso de mínimos debe ser de 1 unidad por cada SKU. El pedido no se guardará.");
                        return -1;
                    }
                }
                else if (iCuentaUnidades == dtLineasPedido.DefaultView.Count)
                {
                    if (Mensajes.ShowQuestion("Está guardando un compromiso clásico y todas las SKU tienen 1 unidad.\r\n\r\n¿Está seguro que desea realizar un compromiso clásico en lugar de un compromiso de mínimos?") == DialogResult.No)
                    {
                        return -1;
                    }
                }

            } //---- FI GSG




            bool bAccMarkSel = false;
            foreach (DataGridViewRow row in dataGridViewAccMark.Rows)
            {
                if (bool.Parse(row.Cells["selected"].Value.ToString()))
                {
                    bAccMarkSel = true;
                    break;
                }
            }

            if (bAccMarkSel)
            {
                List<string> lMiss = ValidaSeleccionAcckMark();
                if (lMiss.Count > 0)
                {
                    // Eliminar posibles mensajes repetidos (en la actual versión esto puede suceder ya que simplificamos los mensajes y si por ejemplo, para un mismo producto tenemos un grupo que suma y otras acciones individuales, pueden provocar el mismo mensaje exacto)
                    List<string> lResult = new List<string>();
                    lResult = Utiles.eliminarDuplicadosListString(lMiss);
                    string miss = "";

                    foreach (string val in lResult)
                        miss += (val + "\r\n");

                    Mensajes.ShowError(miss);
                    return -1;
                }
            }
            else
            {
                if (Mensajes.ShowQuestion("El pedido se guardará sin acciones de márketing.\r\n\r\n¿Está seguro de querer guardar el pedido sin acciones de márketing?") == DialogResult.No)
                    return -3;
            }


            //Actualiza los totales según los materiales y datos introducidos
            ActualizarTotales();

            // Validaciones 

            //---- GSG (02/01/2023)
            //if (cboTipoPedido.SelectedValue.ToString() == Comun.K_TIPOPED_COMPROMISO && dtpFechaPedido.Value >= dtpFechaPref.Value) 
            //{
            //    Mensajes.ShowError("La fecha del pedido debe ser inferior a la fecha vigencia para pedido compromiso.");
            //    return -1;
            //}
            //---- FI GSG

            if (double.Parse(txbDescExtraRestante.Text) < 0)
            {
                Mensajes.ShowError("Se ha gastado más extra del disponible. El pedido no se guardará.");
                return -1;
            }

            if (dtLineasPedido.DefaultView.Count <= 0)
            {
                Mensajes.ShowError("No hay líneas de pedido. El pedido no se guardará.");
                return -1;
            }

            if (txtClienteSAP.Text == "" || txtDestinatarioSAP.Text == "")
            {
                Mensajes.ShowError("Es obligatorio entrar un cliente y un destinatario");
                return -1;
            }

            if (TipoAcceso == (int)acceso.CONSULTA)
            {
                if (!deleg)
                    Mensajes.ShowError("No puedes realizar cambios sobre este delegado.");
                else
                    Mensajes.ShowError("El pedido está enviado a Central y no puede ser modificado.");

                return -1;
            }

            //Busca el nombre de materials (<> del número de línies)
            foreach (DataGridViewRow row in dataGridViewLineas.Rows)
            {
                if (!bool.Parse(row.Cells["ColbDescExtra"].Value.ToString()))
                {
                    sMaterial = row.Cells[K_COL_IDMAT].Value.ToString() + ","; //id del material
                    if (sMaterialsComptats.IndexOf(sMaterial) == -1)
                    {
                        sMaterialsComptats += sMaterial;
                        iNumMaterials++;
                    }
                }
            }

            //A partir d'ara el valor que ve amb la campanya no limitarà el nombre d'unitats si no el nombre de presentacions
            //Nombre mínim de presentacions segons campanya
            if (iNumMaterials < iMinimUnitatsPedido) //iMinimUnitatsPedido : malgrat el nom fa referencia a les presentacions (materials)
            {
                Mensajes.ShowError(String.Format("El número de presentaciones del pedido ({0}) debe ser superior a {1}.", iNumMaterials, iMinimUnitatsPedido));
                return -1;
            }

            //---- GSG (13/09/2016)
            /*
             
            //Validacions segons Acció de Márketing seleccionada.
            int iNumAccMarkSel = 0;
            int iNumMaxAccMark = int.Parse(Clases.Configuracion.iMaxNumAccMark);
            string codsAccMark = "";

            foreach (DataGridViewRow row in dataGridViewAccMark.Rows) 
            {
                if (bool.Parse(row.Cells["selected"].Value.ToString()) == true) 
                {
                    iMinMaterialsAccMark += int.Parse(row.Cells["iUnidadesDataGridViewTextBoxColumn"].Value.ToString());
                    iMinUnitatsAccMark += int.Parse(row.Cells["iNumElemEntregarDataGridViewTextBoxColumn"].Value.ToString());
                    fMinPreuAccMarkNet += float.Parse(row.Cells["fCosteUnitarioDataGridViewTextBoxColumn"].Value.ToString());
                    fMinPreuAccMark += float.Parse(row.Cells["fCosteTotalDataGridViewTextBoxColumn"].Value.ToString());

                    iNumAccMarkSel++; 
                    codsAccMark += "'" + row.Cells["sIdAccionDataGridViewTextBoxColumn"].Value.ToString() + "',";
                }
            }
            // Hay algunas acciones de márketing que deben excluirse del contador. Para hacerlo rápido y fácil, llamaremos a una stored
            // que retornará el valor iNumAccMarkSel modificado si se ha contabilizado alguna de dichas acciones.
            if (codsAccMark.Length > 0)
            {
                codsAccMark = codsAccMark.Remove(codsAccMark.Length - 1);
                int numADescartar = GetAccsMarkADescartar(codsAccMark);
                iNumAccMarkSel -= numADescartar;
            }

            //En la tabla de configuración está establecido el número máximo de acciones de márketing que se pueden seleccionar (depende del delegado en particular)
            if (iNumAccMarkSel > iNumMaxAccMark)
            {
                Mensajes.ShowError(String.Format("El número de acciones de márketing (no especiales) seleccionadas ({0}) no puede ser superior a {1}.", iNumAccMarkSel, iNumMaxAccMark));
                return -1;
            }

            //Nombre mínim de materials segons acció márketing
            if (iNumMaterials < iMinMaterialsAccMark)
            {
                Mensajes.ShowError(String.Format("El número de materiales del pedido ({0}) debe ser superior a {1} debido a la acción de márketing seleccionada.", iNumMaterials, iMinMaterialsAccMark));
                return -1;
            }

            //Nombre mínim d'unitats segons acció márketing
            if (iUnitatsPedido < iMinUnitatsAccMark)
            {
                Mensajes.ShowError(String.Format("El número de unidades del pedido ({0}) debe ser superior a {1} debido a las acciones de márketing seleccionadas.", iUnitatsPedido, iMinUnitatsAccMark));
                return -1;
            }

            //Preu mínim (net o brut) segons acció márketing
            if (ImportePedido < fMinPreuAccMarkNet)
            {
                Mensajes.ShowError(String.Format("El importe neto del pedido ({0:C}) debe ser superior a {1:C} debido a las acciones de márketing seleccionadas.", ImportePedido, fMinPreuAccMarkNet));
                return -1;
            }

            if (ImportePedidoBruto < fMinPreuAccMark)
            {
                Mensajes.ShowError(String.Format("El importe bruto del pedido ({0:C}) debe ser superior a {1:C} debido a las acciones de márketing seleccionadas.", ImportePedidoBruto, fMinPreuAccMark));
                return -1;
            }


            */

            Configuracion.Carga();

            if (Utiles.IsDecimal(txtRentabilidad.Text) && txtRentabilidad.Text != "")
            {
                if (float.Parse(txtRentabilidad.Text) < Configuracion.fRentabilidadMinima)
                {
                    Mensajes.ShowError("El pedido no supera o iguala la rentabilidad mínima (" + Configuracion.fRentabilidadMinima.ToString() + "%). No se puede guardar.");
                    return -1;
                }
            }

            //---- GSG (07/10/2016)
            if (!Comun.IsInTheArray(cboTipoPedido.SelectedValue.ToString(), Configuracion.asPedTransfer)) // Directos
            {
                float brutoFinan = float.Parse(txbImporteBrutoF.Text.Replace('€', ' ').Trim());

                if (Configuracion.fMinDirFinan > brutoFinan && brutoFinan > 0)
                {
                    Mensajes.ShowError("En un pedido directo, el bruto financiado debe superar los " + Configuracion.fMinDirFinan.ToString() + "€.");
                    return -1;
                }


                //---- GSG (26/02/2018)
                // En pedidos DIRECTOS habrá un mínimo importe para las líneas que no dividen
                //---- GSG (26/03/2020) Posem el tope a les que se separen

                DataTable dtDivisiones;
                double brutoNoDivide = 0;
                if (BBDD.GetConfDivisionesPedidos(out dtDivisiones))
                {
                    foreach (DataGridViewRow row in dataGridViewLineas.Rows)
                    {
                        //---- GSG (26/03/2020) Posem el tope a les que se separen
                        // Si no divide suma al bruto
                        //if (!BBDD.EsSAP(row.Cells["ColidCampanya"].Value.ToString(), row.Cells["sIdMaterialDataGridViewTextBoxColumn"].Value.ToString(), cboTipoPedido.SelectedValue.ToString(), dtDivisiones))
                        if (BBDD.EsSAP(row.Cells["ColidCampanya"].Value.ToString(), row.Cells["sIdMaterialDataGridViewTextBoxColumn"].Value.ToString(), cboTipoPedido.SelectedValue.ToString(), dtDivisiones))
                        {
                            // Si no divide sumamos
                            int unidades = int.Parse(row.Cells["ColCantidad"].Value.ToString());
                            double precio = double.Parse(row.Cells["ColPrecio"].Value.ToString());

                            brutoNoDivide += (unidades * precio);
                        }
                    }

                    //---- GSG (26/03/2020) Posem el tope a les que se separen
                    //if (brutoNoDivide < Configuracion.fImpMinDIR)
                    if (brutoNoDivide < Configuracion.fImpMinDIR && brutoNoDivide != 0) //el significado de brutoNoDivide es brutoDivide ahora
                    {
                        //---- GSG (26/03/2020) Posem el tope a les que se separen
                        //Mensajes.ShowError("En un pedido directo el importe bruto de las líneas que no se separan (" + brutoNoDivide.ToString() + "), tiene que ser superior a " + Configuracion.fImpMinDIR.ToString() + " €.");
                        Mensajes.ShowError("En un pedido directo el importe bruto de las líneas que se separan (" + brutoNoDivide.ToString() + "), tiene que ser superior a " + Configuracion.fImpMinDIR.ToString() + " €.");
                        return -1;
                    }
                }
            }



            if (Configuracion.bObligarObsPedidoEnVerano && txbObservaciones.Text.Trim() == "")
            {
                Mensajes.ShowError("Debe indicar una observación para poder grabar el pedido.");
                return -1;
            }

            if (cboTipoCampana.SelectedValue != null)
            {
                //Comporbación importe min por campaña cabecera
                DataRow[] rows = dtCampanyasCabeceraCompletas.Select(
                        String.Format("idCampanya='{0}' AND sIdTipoPedido='{1}'", cboTipoCampana.SelectedValue.ToString(), cboTipoPedido.SelectedValue));

                if (rows.Length > 0) //Hay al menos una fila
                {
                    dsFormularios.ListaCampanyasCabeceraRow row = (dsFormularios.ListaCampanyasCabeceraRow)rows[0];
                    bEsBrut = false;
                    ImporteMinPedido = row.fImporteMinObli;
                    //si hi ha brut mana, mai els dos serán 0 però "Sin campanya" té els dos a 0 i ha de ser net
                    if (row.fImporteMinObliBruto > 0)
                    {
                        ImporteMinPedido = row.fImporteMinObliBruto;
                        bEsBrut = true;
                    }

                    //Mínim unitats
                    iMinimUnitatsPedido = row.iNumMinUnidades;
                }
                else
                {
                    ImporteMinPedido = 0.0;
                    iMinimUnitatsPedido = 0;
                }

                if (!bEsBrut)
                {
                    if (ImportePedido < ImporteMinPedido)
                    {
                        Mensajes.ShowError(String.Format("El importe del pedido ({0:C}) debe ser superior a {1:C} según la campaña de cabecera.", ImportePedido, ImporteMinPedido));
                        return -1;
                    }
                }
                else
                {
                    if (ImportePedidoBruto < ImporteMinPedido)
                    {
                        Mensajes.ShowError(String.Format("El importe bruto del pedido ({0:C}) debe ser superior a {1:C} según la campaña de cabecera.", ImportePedidoBruto, ImporteMinPedido));
                        return -1;
                    }
                }

                //Comprobación rentabilidad por campaña cabecera
                string sIdCampCab = cboTipoCampana.SelectedValue.ToString();
                float fRentMin = GetRentMinCampCab(sIdCampCab);
                float fRentPedido = float.Parse(txtRentabilidad.Text);
                if (fRentPedido < fRentMin)
                {
                    Mensajes.ShowError("La rentabilidad del pedido no supera el mínimo requerido por la campaña " + cboTipoCampana.Text + ".");
                    return -1;
                }
            }
            else
            {
                Mensajes.ShowError("No se pueden obtener los datos de la campaña de cabecera, actualmente no existe o está inactiva.");
                return -1;
            }


            if (!AvisoUVM(0))
                return -1;



            //---- GSG (23/08/2017)
            // Comprobaciones complejas ej: 
            // Preventa Etoricoxib
            //-Pedido mínimo para  aplazamiento e ir en directo 50 % dto. 10 uds surtidas; para transfer, desde la primera unidad puede ir al 50 %.Cuentan para rentabilidad.  
            //-Si piden 16 o más uds surtidas, podrán ir en directo o transfer y, además del dto. del 50 % un regalo de 2 ator de 40 y 2 de 80.Este regalo sólo se hará con 16uds o múltiplos.Exenta de rentabilidad.
            //- Aplazamiento para el directo hasta diciembre.                
            List<GESTCRM.Comun.TripletLinPed> lTLP = new List<GESTCRM.Comun.TripletLinPed>();
            int iUnitats = 0;
            int iUnitatsBase = 0;
            //foreach (dsMateriales.ListaMaterialesRow rw in dsMateriales1.ListaMateriales.Rows)

            // Obtener todas las campañas usadas y hacer la llamada para cada una de ellas.
            List<string> lCodsCamp = new List<string>();
            List<string> lCampanyas = new List<string>();
            foreach (DataGridViewRow row in dataGridViewLineas.Rows)
            {
                string idcamp = row.Cells["ColidCampanya"].Value.ToString();
                string camp = row.Cells["ColCampanya"].Value.ToString();

                if (!lCodsCamp.Contains(idcamp))
                {
                    lCodsCamp.Add(idcamp);
                    lCampanyas.Add(camp);
                }

            }

            foreach (string c in lCodsCamp)
            {
                lTLP.Clear(); //---- GSG (04/01/2019) este cambio está también el la versión 51 y es la única diferencia respecto a la 50

                foreach (DataGridViewRow row in dataGridViewLineas.Rows)
                {
                    if (row.Cells["ColidCampanya"].Value.ToString() == c)
                    {
                        iUnitats = int.Parse(row.Cells["ColCantidad"].Value.ToString());
                        iUnitatsBase = int.Parse(row.Cells["ColCantidadBase"].Value.ToString()); //---- GSG (11/01/2018)

                        GESTCRM.Comun.TripletLinPed tlp = null;
                        //tlp = new GESTCRM.Comun.TripletLinPed(row.Cells["sIdMaterialDataGridViewTextBoxColumn"].Value.ToString(), iUnitats, iUnitats * float.Parse(row.Cells["ColPrecio"].Value.ToString()));
                        tlp = new GESTCRM.Comun.TripletLinPed(row.Cells["sIdMaterialDataGridViewTextBoxColumn"].Value.ToString(), iUnitatsBase * iUnitats, iUnitats * float.Parse(row.Cells["ColPrecio"].Value.ToString()));

                        lTLP.Add(tlp);
                    }
                }

                GESTCRM.BBDD.InitsGrupoCampanya();
                if (!GESTCRM.BBDD.ValidaGrupoCamp(c, cboTipoPedido.SelectedValue.ToString(), lTLP))
                {
                    Mensajes.ShowError("Error en condiciones de la campaña " + lCampanyas[lCodsCamp.IndexOf(c)]);
                    return -1;
                }
            }
            //---- FI GSG





            //Comprobaciones tarjetas regalo

            //Buscar tarjetas del pedido en curso que se va a guardar
            List<string> lT = new List<string>();
            lT = GetTargetasClientPedidoEnCurso();
            string avisosT = "";

            //---- GSG (13/09/2016) Lo voy a poner en el load ya que voy a necesitar la lista de productos en otras ocasiones
            // para obtener la descripción del producto (necesario para el mensaje)
            //this.dsFormularios1.ListaProductos.Clear();
            //this.sqldaListaProductos.Fill(this.dsFormularios1);


            // Si hay, mirar una a una si se cumplen los requisitos
            //Para poder usar esa tarjeta deberá haber producto indicado por importe y/o unidades

            if (dsClientes1.ListaTarjetasCliente.Rows.Count > 0)
            {
                foreach (string tarjeta in lT)
                {
                    //Requisitos de la tarjeta
                    DataRow[] datosT = dsClientes1.ListaTarjetasCliente.Select("sIdMaterial = '" + tarjeta + "'"); //no busco por cliente porque sólo hay las del cliente actual

                    if (datosT.Length > 0)
                    {
                        string sIdProductoT = datosT[0][7].ToString(); // columna 'sIdProducto'
                        DataRow[] sNombresProducto = dsFormularios1.ListaProductos.Select("sIdProducto = '" + sIdProductoT + "'");
                        int iUnidadesMinT = datosT[0][9] == DBNull.Value || datosT[0][9].ToString() == "" ? 0 : int.Parse(datosT[0][9].ToString()); // columna 'iUnidadesMin'
                        double fBrutoMinT = datosT[0][10] == DBNull.Value || datosT[0][10].ToString() == "" ? 0 : double.Parse(datosT[0][10].ToString()); // columna 'fBrutoMin'

                        //Buscar si se cumplen los requisitos de la tarjeta en el resto de línea

                        if (sIdProductoT != "" && sIdProductoT != null)
                        {
                            int cuentaUnidades = 0;
                            double cuentaBruto = 0;
                            string producto = "";

                            for (int i = 0; i < dtLineasPedido.DefaultView.Count; i++)
                            {
                                producto = ObtenirProductoMaterial(dtLineasPedido.DefaultView[i]["sIdMaterial"].ToString());
                                if (producto == sIdProductoT)
                                {
                                    int unidades = dtLineasPedido.DefaultView[i]["iCantidad"] == DBNull.Value ? 0 : int.Parse(dtLineasPedido.DefaultView[i]["iCantidad"].ToString());
                                    double bruto = dtLineasPedido.DefaultView[i]["PrecioUnitario"] == DBNull.Value ? 0 : double.Parse(dtLineasPedido.DefaultView[i]["PrecioUnitario"].ToString());
                                    cuentaUnidades += unidades;
                                    cuentaBruto += (bruto * unidades);
                                }
                            }

                            if (cuentaUnidades < iUnidadesMinT)
                                avisosT += String.Format("No se puede dar la tarjeta {0} debido a que las unidades de {1} en el pedido son inferiores a {2}.\r\n\r\n", datosT[0][4].ToString(), sNombresProducto[0][1].ToString(), iUnidadesMinT);
                            if (cuentaBruto < fBrutoMinT)
                                avisosT += String.Format("No se puede dar la tarjeta {0} debido a que el importe bruto de {1} en el pedido es inferior a {2:C}.\r\n\r\n", datosT[0][4].ToString(), sNombresProducto[0][1].ToString(), fBrutoMinT);
                        }
                        // else no hay condición
                    }
                    else
                        avisosT += String.Format("No se puede dar la tarjeta a este cliente.");
                }
            }

            if (avisosT.Length > 0)
            {
                Mensajes.ShowError(avisosT);
                return -1;
            }


            //---- GSG (11/07/2017)
            // Comprobación pedidos COFARES            
            //if (Comun.IsInTheArray(cboTipoPedido.SelectedValue.ToString(), Configuracion.asPedTransfer) && txtDestinatarioSAP.Text == "S0000000080" && ImportePedidoBruto >= Configuracion.fImpCofares && DescuentoMedio < Configuracion.fDescCofares)
            if (Comun.IsInTheArray(cboTipoPedido.SelectedValue.ToString(), Configuracion.asPedTransfer) && txtDestinatarioSAP.Text == "S0000000080" && ImportePedidoBruto >= Configuracion.fImpCofares && DescuentoMedio < Configuracion.fDescCofares - 0.5) //---- GSG (08/01/2018)
            {
                avisosT = String.Format("En pedidos de COFARES con importe igual o superior a  {0:C}, el descuento medio tiene que ser como mínimo del {1}%.\r\n\r\nEl pedido se modificará de forma automática.\r\nObserve los cambios y guarde de nuevo el pedido.", Configuracion.fImpCofares, Configuracion.fDescCofares);
                Mensajes.ShowError(avisosT);
                AplicarDescuentoCofares();
                return -1;
            }




            Cursor.Current = Cursors.WaitCursor;

            dsFormularios1.ListaTiposPosPedidoSAP.DefaultView.RowFilter = String.Format("sIdTipoPedido = '{0}'", cboTipoPedido.SelectedValue);
            string TipoPosPedidoSAP = dsFormularios1.ListaTiposPosPedidoSAP.DefaultView[0]["sIdTipoPosicion"].ToString();


            string cpCompra = BuscaCPClienteSAP(this.iIdCliente); //---- GSG (06/03/2017)


            SqlTransaction sqlTran;

            if (sqlConn.State.ToString() == "Closed")
                sqlConn.Open();

            //Transaccional ya que si falla la insercion se ha de cancelar el borrado previo.
            sqlTran = sqlConn.BeginTransaction();
            sqlCmdSetPedidosLin.Transaction = sqlTran;
            sqlCmdSetPedidosCab.Transaction = sqlTran;
            sqlCmdDeleteCampanyasPedido.Transaction = sqlTran;
            sqlCmdSetCampanyaPedido.Transaction = sqlTran;

            //---- GSG CECL 19/05/2016
            if (System.Configuration.ConfigurationManager.AppSettings["TipoDelegadoPedidosCentral"].ToString() == Comun.K_CECL)
            {
                sqlCmdSetPedidosCab.CommandText = "[SetPedidosCabCECL]";
                sqlCmdSetPedidosLin.CommandText = "[SetPedidosLinCECL]";
            }
            else
            {
                sqlCmdSetPedidosCab.CommandText = "[SetPedidosCab]";
                sqlCmdSetPedidosLin.CommandText = "[SetPedidosLin]";
            }
            //---- FI GSG CECL

            try
            {
                if (TipoAcceso != (int)acceso.INSERCION)
                {
                    //Borrar Lineas del Pedido
                    sqlCmdSetPedidosLin.Parameters["@iAccion"].Value = 2;
                    sqlCmdSetPedidosLin.Parameters["@iIdLinea"].Value = -1;
                    sqlCmdSetPedidosLin.Parameters["@sIdPedido"].Value = sIdPedido;
                    sqlCmdSetPedidosLin.ExecuteNonQuery();

                    //Borrar Cabecera del Pedido
                    sqlCmdSetPedidosCab.Parameters["@iAccion"].Value = 2;
                    sqlCmdSetPedidosCab.Parameters["@sIdPedido"].Value = sIdPedido;
                    sqlCmdSetPedidosCab.ExecuteNonQuery();
                }

                try
                {
                    //---- GSG (08/01/2018)
                    // Si la fecha preferente (fecha preferente de entrega) es anterior a la del pedido, poner la fecha del pedido
                    //---- GSG (02/01/2023)
                    //if (dtpFechaPref.Value < dtpFechaPedido.Value)
                    //    dtpFechaPref.Value = dtpFechaPedido.Value;
                    CorregirFechasPedido();

                    //Insertar Cabecera del Pedido
                    sqlCmdSetPedidosCab.Parameters["@iAccion"].Value = 0;
                    sqlCmdSetPedidosCab.Parameters["@sIdPedido"].Value = sIdPedido;
                    sqlCmdSetPedidosCab.Parameters["@sIdPedidoTemp"].Value = sIdPedido;
                    sqlCmdSetPedidosCab.Parameters["@iIdDelegado"].Value = iIdDelegado;
                    sqlCmdSetPedidosCab.Parameters["@sIdTipoPedido"].Value = cboTipoPedido.SelectedValue.ToString();

                    //---- GSG (06/03/2021) 
                    // Error poco común pero que alguién consigue provocar:
                    // Si un delegado cambia de transfer a directo y le da a guardar, se crea un pedido con el solicitante con el código de mayorista
                    // la variable _sTipoPedidoNew toma el valor de la selección en el evento. Consultar esta variable en lugar del combo puede resultar mejor

                    bool esTransfer = true;
                    if (_sTipoPedidoNew != null && _sTipoPedidoNew != "")
                        esTransfer = Comun.IsInTheArray(_sTipoPedidoNew, Configuracion.asPedTransfer);
                    else
                        esTransfer = Comun.IsInTheArray(this.cboTipoPedido.SelectedValue.ToString(), Configuracion.asPedTransfer);


                    //if (Comun.IsInTheArray(this.cboTipoPedido.SelectedValue.ToString(), Configuracion.asPedTransfer))  // Transfer
                    if (esTransfer)
                    {
                        sqlCmdSetPedidosCab.Parameters["@iIdCliente"].Value = this.iIdCliente;
                        sqlCmdSetPedidosCab.Parameters["@iIdDestinatario"].Value = this.iIdDestinatario;
                    }
                    else
                    {
                        sqlCmdSetPedidosCab.Parameters["@iIdCliente"].Value = this.iIdDestinatario;
                        sqlCmdSetPedidosCab.Parameters["@iIdDestinatario"].Value = this.iIdCliente;
                    }


                    sqlCmdSetPedidosCab.Parameters["@dFechaPedido"].Value = dtpFechaPedido.Value;
                    sqlCmdSetPedidosCab.Parameters["@dFechaPreferente"].Value = dtpFechaPref.Value;
                    sqlCmdSetPedidosCab.Parameters["@dFechaFijada"].Value = dtpFechaFij.Value;
                    sqlCmdSetPedidosCab.Parameters["@sOrgVentas"].Value = Configuracion.sOrgVentasSAP;
                    sqlCmdSetPedidosCab.Parameters["@sGrupoVendedor"].Value = Configuracion.sGrupoVendedorSAP;
                    sqlCmdSetPedidosCab.Parameters["@sCanal"].Value = Configuracion.sCanalSAP;
                    sqlCmdSetPedidosCab.Parameters["@sSector"].Value = Configuracion.sSectorSAP;
                    sqlCmdSetPedidosCab.Parameters["@fImporte"].Value = ImportePedido;
                    sqlCmdSetPedidosCab.Parameters["@fDescuento"].Value = DescuentoMedio;
                    sqlCmdSetPedidosCab.Parameters["@sIdTipoCampanya"].Value = cboTipoCampana.SelectedValue.ToString();
                    sqlCmdSetPedidosCab.Parameters["@tObservaciones"].Value = txbObservaciones.Text;
                    sqlCmdSetPedidosCab.Parameters["@iEstado"].Value = 0;
                    sqlCmdSetPedidosCab.Parameters["@fFUM"].Value = DateTime.Now;
                    sqlCmdSetPedidosCab.Parameters["@bEnviadoCEN"].Value = 0;
                    sqlCmdSetPedidosCab.Parameters["@bEnviadoPDA"].Value = 0;
                    sqlCmdSetPedidosCab.Parameters["@fDescuentoCampanya"].Value = DtoGeneral;
                    sqlCmdSetPedidosCab.Parameters["@fDescuentoAdicional"].Value = 0; // No lo estamos utilizando y además ahora el campo fDescImpNeto de la campaña, que influia aquí, lo utilizaremos para otra cosa

                    //Rendabilitat de la comanda
                    if (!float.IsNaN(gfRenta))
                        sqlCmdSetPedidosCab.Parameters["@fRentabilidad"].Value = gfRenta;
                    else
                        sqlCmdSetPedidosCab.Parameters["@fRentabilidad"].Value = 999;

                    sqlCmdSetPedidosCab.Parameters["@iIdAccion"].Value = iIdAccion;
                    sqlCmdSetPedidosCab.Parameters["@sFechaVencimiento"].Value = System.DBNull.Value;

                    if (cboCondicionPago.Visible)
                        sqlCmdSetPedidosCab.Parameters["@sCondPago"].Value = cboCondicionPago.SelectedValue.ToString();
                    else if (txbCodPagoFija.Visible == true)
                    {
                        int pos = cboCondicionPago.FindString(txbCodPagoFija.Text, 0);
                        cboCondicionPago.SelectedIndex = pos;
                        sqlCmdSetPedidosCab.Parameters["@sCondPago"].Value = cboCondicionPago.SelectedValue.ToString();
                    }
                    else
                        sqlCmdSetPedidosCab.Parameters["@sCondPago"].Value = System.DBNull.Value;

                    sqlCmdSetPedidosCab.Parameters["@sPrioridad"].Value = cboPrioridad.SelectedValue.ToString();
                    if (dtpFechaFacturacion.Visible)
                        sqlCmdSetPedidosCab.Parameters["@dFechaFacturacion"].Value = dtpFechaFacturacion.Value;
                    else
                        sqlCmdSetPedidosCab.Parameters["@dFechaFacturacion"].Value = System.DBNull.Value;
                    //---- GSG (14/10/2016)
                    if (pnCompromiso.Visible)
                    {
                        sqlCmdSetPedidosCab.Parameters["@sTipoPedidoCompromiso"].Value = cboClasico.SelectedValue.ToString();
                        sqlCmdSetPedidosCab.Parameters["@sTipoGestionCompromiso"].Value = cboIndividual.SelectedValue.ToString();
                    }
                    else
                    {
                        sqlCmdSetPedidosCab.Parameters["@sTipoPedidoCompromiso"].Value = System.DBNull.Value;
                        sqlCmdSetPedidosCab.Parameters["@sTipoGestionCompromiso"].Value = System.DBNull.Value;
                    }
                    //---- GSG (06/03/2017)
                    if (cpCompra != null)
                        sqlCmdSetPedidosCab.Parameters["@sCPCompra"].Value = cpCompra;
                    else
                        sqlCmdSetPedidosCab.Parameters["@sCPCompra"].Value = System.DBNull.Value;


                    sqlCmdSetPedidosCab.ExecuteNonQuery();
                }
                catch (Exception err)
                {
                    Mensajes.ShowError("Error cabecera pedido. Consulte con informática e indique el siguiente error: " + err.Message);
                }

                sIdPedido = sqlCmdSetPedidosCab.Parameters["@sIdPedido"].Value.ToString();

                //Guarda las acciones seleccionadas en la tabla PedAcciones ya que en la cabecera del pedido
                //sólo se puede guardar una acción. Ahora en la cabecera pondremos 0 y las acciones van a tabla.

                try
                {
                    //---- GSG (17/11/2016)
                    // Determinar el valor del campo Destino.
                    // Si no hay indepes                --> F
                    // Si solo indepe Entrega Delegado  --> D
                    // Si solo indepe Entrega Farmacia  --> F
                    // Si las dos indepes               --> F

                    // 1970    ENTREGA A FARMACIA
                    // 1971    ENTREGA A DELEGADO


                    string entrega = "";
                    int accion = -1;
                    foreach (DataGridViewRow row in dataGridViewAccMark.Rows)
                    {
                        if (bool.Parse(row.Cells["selected"].Value.ToString()) == true)
                        {
                            accion = int.Parse(row.Cells["iIdAccionDataGridViewTextBoxColumn"].Value.ToString());
                            if (accion == 1970)
                                entrega += "F";
                            else if (accion == 1971)
                                entrega += "D";
                        }
                    }

                    if (entrega.Contains("D") && !entrega.Contains("F"))
                        entrega = "D";
                    else
                        entrega = "F";

                    //---- FI GSG


                    sqlCmdSetPedAcciones.Transaction = sqlTran;

                    sqlCmdSetPedAcciones.Parameters["@iAccion"].Value = 2;
                    sqlCmdSetPedAcciones.Parameters["@sIdPedido"].Value = sIdPedido;
                    sqlCmdSetPedAcciones.ExecuteNonQuery();

                    foreach (DataGridViewRow row in dataGridViewAccMark.Rows)
                    {
                        if (bool.Parse(row.Cells["selected"].Value.ToString()) == true)
                        {
                            //---- GSG (06/03/2021)
                            // si la acción de mkt está en las que van a picking, marcar los siguientes campos
                            //sqlCmdSetPedAcciones.Parameters["@iAccion"].Value = 0;
                            if (_listaAccMarkProfitPlus.Contains(row.Cells["sIdAccionDataGridViewTextBoxColumn"].Value.ToString()))
                                sqlCmdSetPedAcciones.Parameters["@iAccion"].Value = 3;
                            else
                                sqlCmdSetPedAcciones.Parameters["@iAccion"].Value = 0;



                            sqlCmdSetPedAcciones.Parameters["@sIdPedido"].Value = sIdPedido;
                            sqlCmdSetPedAcciones.Parameters["@iIdAccion"].Value = int.Parse(row.Cells["iIdAccionDataGridViewTextBoxColumn"].Value.ToString());
                            //---- GSG (13/09/2016)
                            sqlCmdSetPedAcciones.Parameters["@iUnidades"].Value = int.Parse(row.Cells["UnidadesAEntregar"].Value.ToString());
                            //---- GSG (17/11/2016)
                            sqlCmdSetPedAcciones.Parameters["@Destino"].Value = entrega;
                            //---- GSG (01/02/2017)
                            sqlCmdSetPedAcciones.Parameters["@Bruto"].Value = ImportePedidoBruto;


                            sqlCmdSetPedAcciones.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception err)
                {
                    Mensajes.ShowError("Error acciones pedido. Consulte con informática e indique el siguiente error: " + err.Message);
                }

                string sProducte = "";

                //Insertar Lineas del Pedido
                try
                {
                    for (int i = 0; i < dtLineasPedido.DefaultView.Count; i++)
                    {
                        sqlCmdSetPedidosLin.Parameters["@iAccion"].Value = 0;
                        sqlCmdSetPedidosLin.Parameters["@sIdPedido"].Value = sIdPedido;
                        sqlCmdSetPedidosLin.Parameters["@iIdLinea"].Value = dtLineasPedido.DefaultView[i]["iIdLinea"];
                        sqlCmdSetPedidosLin.Parameters["@sIdMaterial"].Value = dtLineasPedido.DefaultView[i]["sIdMaterial"].ToString();
                        sqlCmdSetPedidosLin.Parameters["@iCantidad"].Value = dtLineasPedido.DefaultView[i]["iCantidad"];
                        sqlCmdSetPedidosLin.Parameters["@fPrecio"].Value = dtLineasPedido.DefaultView[i]["PrecioUnitario"];

                        string tipoMat = ObtenirTipoMat(dtLineasPedido.DefaultView[i]["sIdMaterial"].ToString(), sqlTran);
                        if (tipoMat != null && tipoMat.Trim() != "")
                        {
                            sqlCmdSetPedidosLin.Parameters["@sidTipoPosicion"].Value = tipoMat;
                        }
                        else
                        {
                            sProducte = ObtenirProductoMaterial(dtLineasPedido.DefaultView[i]["sIdMaterial"].ToString(), sqlTran);
                            if (sProducte == K_ZMKT)
                                sqlCmdSetPedidosLin.Parameters["@sidTipoPosicion"].Value = K_ZMKT;
                            else
                                sqlCmdSetPedidosLin.Parameters["@sidTipoPosicion"].Value = TipoPosPedidoSAP;
                        }

                        sqlCmdSetPedidosLin.Parameters["@bEntregado"].Value = 0; // (dtLineasPedido.DefaultView[i]["bEntregado"].ToString() == "Si") ? -1 : 0;
                        sqlCmdSetPedidosLin.Parameters["@dFechaPreferente"].Value = DateTime.Today;
                        //sqlCmdSetPedidosLin.Parameters["@sCentro"].Value = Configuracion.sCentroSAP; //(dtLineasPedido.DefaultView[i]["bEntregado"].ToString() == "Si") ? Configuracion.sCentroDEL : Configuracion.sCentroSAP;
                        //sqlCmdSetPedidosLin.Parameters["@sAlmacen"].Value = Configuracion.sAlmacenSAP; //(dtLineasPedido.DefaultView[i]["bEntregado"].ToString() == "Si") ? Configuracion.sAlmacenDEL : Configuracion.sAlmacenSAP;
                        sqlCmdSetPedidosLin.Parameters["@fDescuento"].Value = dtLineasPedido.DefaultView[i]["fDescuento"]; // Descuento aplicado
                        sqlCmdSetPedidosLin.Parameters["@iBonificacion"].Value = 0;//dtLineasPedido.Rows[i]["fDescuento"];
                        sqlCmdSetPedidosLin.Parameters["@idCampanya"].Value = dtLineasPedido.DefaultView[i]["idCampanya"];
                        sqlCmdSetPedidosLin.Parameters["@idArrastre"].Value = dtLineasPedido.DefaultView[i]["idArrastre"];
                        sqlCmdSetPedidosLin.Parameters["@idGrupoMat"].Value = dtLineasPedido.DefaultView[i]["idGrupoMat"];
                        sqlCmdSetPedidosLin.Parameters["@idPaquete"].Value = dtLineasPedido.DefaultView[i]["idPaquete"];
                        sqlCmdSetPedidosLin.Parameters["@sSerie"].Value = dtLineasPedido.DefaultView[i]["sSerie"];
                        sqlCmdSetPedidosLin.Parameters["@sCodVale"].Value = dtLineasPedido.DefaultView[i]["sCodVale"];
                        //---- GSG (20/03/2017)
                        sqlCmdSetPedidosLin.Parameters["@sRechazo"].Value = dtLineasPedido.DefaultView[i]["sRechazo"];

                        sqlCmdSetPedidosLin.ExecuteNonQuery();
                    }
                }
                catch (Exception err)
                {
                    Mensajes.ShowError("Error lineas pedido. Consulte con informática e indique el siguiente error: " + err.Message);
                }

                // Guardar programa informático
                if (cboProgInf.SelectedValue != null)
                {
                    try
                    {
                        sqlCmdSetProgInfClientesSAP.Transaction = sqlTran;
                        sqlCmdSetProgInfClientesSAP.Parameters["@iIdCliente"].Value = this.iIdCliente;
                        sqlCmdSetProgInfClientesSAP.Parameters["@iIdCentro"].Value = cboProgInf.SelectedValue.ToString();
                        sqlCmdSetProgInfClientesSAP.Parameters["@dFAR"].Value = System.Data.SqlTypes.SqlDateTime.Null;
                        sqlCmdSetProgInfClientesSAP.Parameters["@dFBR"].Value = System.Data.SqlTypes.SqlDateTime.Null;
                        sqlCmdSetProgInfClientesSAP.Parameters["@iEstado"].Value = 0;

                        this.sqlCmdSetProgInfClientesSAP.ExecuteScalar();
                    }
                    catch (Exception err)
                    {
                        Mensajes.ShowError("Error programa informático. Consulte con informática e indique el siguiente error: " + err.Message);
                    }
                }

                // Campos Vale
                // Si hay materiales en el pedido que deben llevar el código de vale, perdirlo
                bool bContinuar = true;
                List<string>[] arrVal = null;
                bool bEditarVales = false;

                if (HayMatsConVale()) //En crm, existe algún material con vale?
                {
                    try
                    {
                        int iVales = GetMatsConValeEnPedido(sqlTran); //Materiales que tienen vale y que se han incluido en el pedido
                        arrVal = new List<string>[iVales];

                        if (iVales > 0)
                        {
                            bool bQuedanValesSinValor = false; //En un pedido nuevo el vale aún no se ha introducido pero si es modificación sí

                            for (int i = 0; i < dsMateriales1.ListaMatsConVale.Rows.Count; i++)
                            {
                                dsMateriales.ListaMatsConValeRow dr = (dsMateriales.ListaMatsConValeRow)dsMateriales1.ListaMatsConVale.Rows[i];

                                if (dr.IssSerieNull() || dr.IssCodValeNull() || dr.sSerie.Trim() == "" || dr.sCodVale.Trim() == "")
                                    bQuedanValesSinValor = true;
                            }

                            if (!bQuedanValesSinValor)
                            {   // Quizá queremos poder modificar un vale ya introducido en pedidos que se están modificando
                                if (Mensajes.ShowQuestion("En el pedido hay materiales que requieren vale pero este ya se ha introducido. ¿Desea editar los vales de todos modos?") == DialogResult.Yes)
                                    bEditarVales = true;
                            }
                            else
                                bEditarVales = true;

                            if (bEditarVales)
                            {
                                //Pop-up amb llista per poder-los editar
                                frmMatsConVale frmVale = new frmMatsConVale(dsMateriales1.ListaMatsConVale);
                                frmVale.ShowDialog(this);

                                if (frmVale.DialogResult == DialogResult.OK)
                                {
                                    bContinuar = true;
                                    arrVal = frmVale._arrVal;
                                }
                                else
                                    bContinuar = false;
                            }
                        }
                    }
                    catch (Exception err)
                    {
                        Mensajes.ShowError("Error gestión vales. Consulte con informática e indique el siguiente error: " + err.Message);
                    }
                }

                if (bContinuar)
                {
                    try
                    {
                        this.sqlCmdSetVale.Transaction = sqlTran;

                        //Guardar vale
                        if (bEditarVales)
                        {
                            for (int i = 0; i < arrVal.Length; i++)
                            {
                                this.sqlCmdSetVale.Parameters["@sIdPedido"].Value = sIdPedido;
                                this.sqlCmdSetVale.Parameters["@sIdMaterial"].Value = arrVal[i][0];
                                this.sqlCmdSetVale.Parameters["@sSerie"].Value = arrVal[i][1];
                                this.sqlCmdSetVale.Parameters["@sCodVale"].Value = arrVal[i][2];

                                this.sqlCmdSetVale.ExecuteScalar();
                            }
                        }
                    }
                    catch (Exception err)
                    {
                        Mensajes.ShowError("Error vales. Consulte con informática e indique el siguiente error: " + err.Message);
                    }

                    GetLineasPedidoOriginal();

                    sqlTran.Commit();
                    sqlTran.Dispose();
                    sqlConn.Close();

                    pintaRentabilidadAnual(false, DateTime.Today);


                    //---- GSG (02/02/2021)
                    /*
                    try
                    { 
                        //Si se han modificado los emails también se guardarán
                        if (_iEmailConfOriginal != txtMailConf.Text.Trim() || _iEmailFactOriginal != txtMailFact.Text.Trim())
                            guardarEmailsCliente(this.iIdCliente);
                    }
                    catch (Exception err) 
                    {
                        Mensajes.ShowError("guardarEmailsCliente. Consulte con informática e indique el siguiente error: " + err.Message);
                        Cursor.Current = Cursors.Default;
                        return -2;
                    }
                    */

                    try
                    {
                        guardarRetenido(sIdPedido, chkRetenido.Checked, iIdDelegado);
                    }
                    catch (Exception err)
                    {
                        Mensajes.ShowError("guardarRetenido. Consulte con informática e indique el siguiente error: " + err.Message);
                        Cursor.Current = Cursors.Default;
                        return -2;
                    }

                    // Crear Visita
                    if (chkVisita.Checked)
                    {
                        bool ok = false;
                        while (!ok)
                            ok = guardar_visita();
                    }

                    try
                    {
                        // Si se ha asignado una tarjeta hay que cambiar la fecha de uso y actualizar dFUM
                        ActualizaTarjetasCliente(txtClienteSAP.Text);
                        // Si el pedido ya estaba guardado y se ha eliminado una tarjeta en el pedido, hay que reactivar la tarjeta como no usada
                        // 1.- Explorar si el pedido tenía tarjetas
                        // 2.- Si sí, 
                        // 3.-     Mirar para cada uno, si el pedido actual también las tiene
                        // 4.-     Para cada una, Poner a null dFecUso y actualizar dFUM en tabla TarjetasCliente si antes estaban y ahora no
                        if (_lTarjetasClientePedidoOriginal.Count > 0)
                        {
                            ActualizaTarjetasClienteBorrado(txtClienteSAP.Text);
                        }
                    }
                    catch (Exception err)
                    {
                        Mensajes.ShowError("tarjetasCliente. Consulte con informática e indique el siguiente error: " + err.Message);
                        Cursor.Current = Cursors.Default;
                        return -2;
                    }

                    Cursor.Current = Cursors.Default;
                    return 0;
                }
                else
                {
                    sqlTran.Rollback();
                    sqlTran.Dispose();
                    Cursor.Current = Cursors.Default;


                    // Per aquí entra quan ha demanat vales i s'ha cancelat o tancat per creu la finestra. Al no guardar queda pendent el tema vale i no deixa guardar la comanda. Ya està ok


                    return -1; //Ho tracto com si no passes una validació
                }

            }
            catch (Exception ev)
            {
                sqlTran.Rollback();
                sqlTran.Dispose();
                Cursor.Current = Cursors.Default;
                return -2;
            }
            finally
            {
                sqlTran.Dispose();
            }
        }

        //---- GSG (23/06/2017)
        private bool controlClienteCondicionEspecialFactura()
        {
            bool bRet = true;
            string cliUp = txtClienteSAP.Text.Trim();
            string cliDown = txtDestinatarioSAP.Text.Trim();

            if (!Comun.IsInTheArray(cboTipoPedido.SelectedValue.ToString(), Configuracion.asPedTransfer)) // Directo
            {
                // El pagador no puede ser un 61
                //if (txtDestinatarioSAP.Text.Substring(0, 8) == "S0000061")
                if (txtDestinatarioSAP.Text.Length >= 8 && txtDestinatarioSAP.Text.Substring(0, 8) == "S0000061")
                {
                    bRet = false;
                    Mensajes.ShowInformation("El código de pagador no es correcto. Abra la lista de pagadores para seleccionar el correcto.");
                }
            }
            else
            {
                //if (txtClienteSAP.Text.Substring(0, 8) == "S0000061")
                if (txtClienteSAP.Text.Length >= 8 && txtClienteSAP.Text.Substring(0, 8) == "S0000061")
                {
                    // El solicitante no puede ser un 61
                    bRet = false;
                    Mensajes.ShowInformation("El solicitante no es correcto. Abra la lista de solicitantes para seleccionar el correcto.");
                }
            }

            return bRet;
        }

        #endregion

        #region Guardar Visita
        // Crear Visita
        private bool guardar_visita()
        {
            //Demana hora inici i fi de la visita

            frmHoras frmH = new frmHoras("A", -1, DateTime.Parse(dtpFechaPedido.Text), iIdDelegado, iIdCliente, sIdPedido);

            frmH.ShowDialog(this);

            if (frmH.DialogResult == DialogResult.OK)
            {
                return true;
            }
            else
            {
                Mensajes.ShowError("No se ha podido guardar la visita. Modifique las horas de visita e inténtelo de nuevo.");
            }

            return false;
        }

        #endregion

        #region rentabilidad

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

        private float Calcular_Rentabilidad()
        {
            float rentabilitat = 0.0F;
            float denominador = 0.0F;
            float brutoLinsArrastre = 0.0F;

            for (int i = 0; i < dtLineasPedido.Rows.Count; i++)
            {
                if (dtLineasPedido.Rows[i].RowState != DataRowState.Deleted && !bool.Parse(dtLineasPedido.Rows[i]["bDescExtra"].ToString()))
                {
                    if (!Comun.IsInTheArray(dtLineasPedido.Rows[i]["sIdMaterial"].ToString().Trim(), lMatsNoRenta) && !Comun.IsInTheArray(dtLineasPedido.Rows[i]["idCampanya"].ToString().Trim(), _lCampanyasNoRenta))
                    {
                        // Si la campaña es arrastre la rentabilidad de la línea será negativa.
                        // Pondremos poner el bruto de la línea en el descuento y el bruto a 0 en el cálculo de la rentabilidad
                        // Primero calculamos la rentabilidad como siempre para todas las líneas que no són bArrastre 
                        // Después sumaremos el bruto de todas las líneas de arrastre i lo restaremos al numerador al final (porque en el númerador restamos el descuento al bruto i estamos tomando el bruto como el descuento en estas líneas)
                        // en el denominador no cuentan porque es la suma del bruto

                        int iCantidad = int.Parse(dtLineasPedido.Rows[i]["iCantidad"].ToString());
                        float fPrecio = float.Parse(dtLineasPedido.Rows[i]["PrecioUnitario"].ToString());

                        bool bArrastre = false;
                        if (int.Parse(dtLineasPedido.Rows[i]["idArrastre"].ToString()) == 1)
                            bArrastre = true;
                        if (!bArrastre)
                        {
                            float fDescuento = float.Parse(dtLineasPedido.Rows[i]["fDescuento"].ToString());
                            float fCoste = -1;
                            if (dtLineasPedido.Rows[i]["fCoste"] != DBNull.Value)
                                fCoste = float.Parse(dtLineasPedido.Rows[i]["fCoste"].ToString());

                            // tenemos en cuenta el descuento de cabecera (DtoGeneral)
                            rentabilitat += DameNominadorRentabilidad(iCantidad, fPrecio, fDescuento + (float)DtoGeneral, fCoste);
                            denominador += DameDenominadorRentabilidad(iCantidad, fPrecio);
                        }
                        else
                        {
                            brutoLinsArrastre += (iCantidad * fPrecio);
                        }
                    }
                }
            }


            float res = 0.0F;

            if (rentabilitat == 0 && denominador == 0 && brutoLinsArrastre == 0)
                res = float.NaN;
            if (denominador != 0)
                res = ((rentabilitat - brutoLinsArrastre) / denominador) * 100.0F; //---- GSG (22/01/2015)

            return res;
        }

        //---- Añade fecha vigencia de tramos
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

        private void pintaRentabilidadAnual(bool bMasPedidoEnCurso, DateTime fecha)
        {
            float rentAnual = Calcular_Rentabilidad_Anual(bMasPedidoEnCurso);
            txtbRentAnual.BackColor = CalcularColorRentabilidad(rentAnual, fecha);
        }

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

        #endregion

        //----GSG (29/09/2020) PUNTOS
        private float Calcular_MargenLab()
        {
            float margen = 0.0F;

            for (int i = 0; i < dtLineasPedido.Rows.Count; i++)
            {
                if (dtLineasPedido.Rows[i].RowState != DataRowState.Deleted)
                {
                    if (!Comun.IsInTheArray(dtLineasPedido.Rows[i]["sIdMaterial"].ToString().Trim(), lMatsNoMargen))
                    {

                        int iCantidad = int.Parse(dtLineasPedido.Rows[i]["iCantidad"].ToString());
                        float fPrecio = float.Parse(dtLineasPedido.Rows[i]["PrecioUnitario"].ToString());
                        float fDescuento = float.Parse(dtLineasPedido.Rows[i]["fDescuento"].ToString());
                        float fCoste = -1;

                        //---- GSG (02/01/2023)
                        //if (dtLineasPedido.Rows[i]["fCoste"] != DBNull.Value)
                        //    fCoste = float.Parse(dtLineasPedido.Rows[i]["fCoste"].ToString());

                        if (dtLineasPedido.Rows[i]["fCoste"] != DBNull.Value)
                            fCoste = float.Parse(dtLineasPedido.Rows[i]["fCoste"].ToString());
                        else
                            fCoste = float.Parse(dtLineasPedido.Rows[i]["PrecioUnitario"].ToString());
                        //---- FI GSG


                        margen += DameNominadorRentabilidad(iCantidad, fPrecio, fDescuento, fCoste);
                    }
                }
            }

            if (Clases.Configuracion.iPuntosDividePor != 0)
                margen = (margen / Clases.Configuracion.iPuntosDividePor) * Clases.Configuracion.iPuntosMultiplicaPor;


            return margen;
        }

        #region NIF y CC

        private void cargarNIFyCC()
        {
            txbIBAN.Text = "";
            txbEntidad.Text = "";
            txbOficina.Text = "";
            txbControl.Text = "";
            txbCC.Text = "";
            txbCCAndorra.Text = "";
            txbSBanco.Text = "";
            txbSPais.Text = "";
            txbSLocalidad.Text = "";
            txbSOficina.Text = "";


            // Cuando un pedido es directo pero el destinatario es distinto del pagador, el NIF y la CC que hay que considerar son los del
            // pagador, que internamente en el programa se llama destinatario (mal nombrado !!!!)
            int iPagador = this.iIdCliente;
            if (!Comun.IsInTheArray(cboTipoPedido.SelectedValue.ToString(), Configuracion.asPedTransfer) && this.iIdCliente != this.iIdDestinatario) //DIR
                iPagador = this.iIdDestinatario;

            bool bEsClienteAndorrano = EsAndorrano(iPagador);

            // Obtiene los datos de contactos clientes o bien de clientes SAP

            // Si hoy se han modificado, los coge de contactos, si no los coge de clientes SAP

            bool deHoy = datosNCDeHoy(out _sNIF, out _sCC, out _sSWIFT, bEsClienteAndorrano, iPagador);
            if (!deHoy)
                datosNC(out _sNIF, out _sCC, out _sSWIFT, iPagador);

            if (!bEsClienteAndorrano)
            {
                txbIBAN.Visible = true;
                txbEntidad.Visible = true;
                txbOficina.Visible = true;
                txbControl.Visible = true;
                txbCC.Visible = true;
                txbCCAndorra.Visible = false;

                if (_sCC != null && _sCC.Length == 26)
                {
                    txbIBAN.Text = _sCC.Substring(0, 4);
                    txbEntidad.Text = _sCC.Substring(4, 4);
                    txbOficina.Text = _sCC.Substring(8, 4);
                    txbControl.Text = _sCC.Substring(13, 2);
                    txbCC.Text = _sCC.Substring(16, 10);
                }
                else if (_sCC != null && _sCC.Length == 22)
                {
                    txbIBAN.Text = "    "; //4 espacios en blanco 
                    txbEntidad.Text = _sCC.Substring(0, 4);
                    txbOficina.Text = _sCC.Substring(4, 4);
                    txbControl.Text = _sCC.Substring(9, 2);
                    txbCC.Text = _sCC.Substring(12, 10);
                }
            }
            else
            {
                txbIBAN.Visible = false;
                txbEntidad.Visible = false;
                txbOficina.Visible = false;
                txbControl.Visible = false;
                txbCC.Visible = false;
                txbCCAndorra.Visible = true;

                txbCCAndorra.Text = _sCC;
            }

            if (_sSWIFT.Length >= 10)
            {
                txbSBanco.Text = _sSWIFT.Substring(0, 4);
                txbSPais.Text = _sSWIFT.Substring(4, 2);
                txbSLocalidad.Text = _sSWIFT.Substring(6, 2);
                txbSOficina.Text = _sSWIFT.Substring(8, 3);
            }
        }

        private bool TratarNIFyCC()
        {
            bool ret = true;
            string sNIF = "";
            string sCC = "";
            string sSWIFT = "";
            string sCCEnForm = "";

            //Los valores que llegan son los de SAP o bien los intoducidos hoy (estos últimos tienen preferencia)
            sNIF = _sNIF;
            sCC = _sCC;
            sSWIFT = _sSWIFT;

            // Cuando un pedido es directo pero el destinatario es distinto del pagador, el NIF y la CC que hay que considerar son los del
            // pagador, que internamente en el programa se llama destinatario (mal nombrado !!!!)
            int iPagador = this.iIdCliente;
            if (!Comun.IsInTheArray(cboTipoPedido.SelectedValue.ToString(), Configuracion.asPedTransfer) && this.iIdCliente != this.iIdDestinatario) //DIR
                iPagador = this.iIdDestinatario;

            bool bEsClienteAndorrano = EsAndorrano(iPagador);

            if (txbIBAN.Text.Trim() == "")
                txbIBAN.Text = "    ";

            if (!bEsClienteAndorrano)
            {
                sCCEnForm = txbIBAN.Text + txbEntidad.Text + txbOficina.Text + "-" + txbControl.Text + "-" + txbCC.Text;
            }
            else
                sCCEnForm = txbCCAndorra.Text;

            bool bCambioCC = false;
            if (sCC.Trim() != sCCEnForm.Trim()) //Se ha modificado la CC después de la carga inicial
            {
                bCambioCC = true;
                sCC = sCCEnForm;
            }

            if (sCC.Trim() == "--")
                sCC = "";

            // Si la condición de pago es ZB00 no hay que pedir la CC en ningún caso
            if (sNIF == null || sNIF.Trim() == "" || ((sCC == null || sCC.Trim() == "") && _sCondPago != Comun.K_ENMETALICO))
            {
                frmNIFCC frmNC = new frmNIFCC(iPagador, cboTipoPedido.SelectedValue.ToString(), sNIF, sCC, sSWIFT, bEsClienteAndorrano, _sCondPago);
                frmNC.ShowDialog(this);

                if (frmNC.DialogResult == DialogResult.OK)
                    ret = true;
                else
                    ret = false;
            }
            else if (_sCondPago == Comun.K_ENMETALICO)
            {
                //No fer res
            }
            else
            {
                bool Ok = true;

                if (!Comun.IsInTheArray(cboTipoPedido.SelectedValue.ToString(), Configuracion.asPedTransfer) || (Comun.IsInTheArray(cboTipoPedido.SelectedValue.ToString(), Configuracion.asPedTransfer) && sCCEnForm != "")) //DIR o transfer con datos  
                {
                    if (!bEsClienteAndorrano)
                    {
                        if (txbIBAN.Text.Trim() != "")
                            Ok = Comun.Comprueba_IBAN_Espanya(txbIBAN.Text, txbEntidad.Text, txbOficina.Text, txbControl.Text, txbCC.Text);
                        else
                            Ok = Comun.Comprueba_CC(txbEntidad.Text, txbOficina.Text, txbControl.Text, txbCC.Text); //---- GSG (11/06/2015)
                    }
                    else
                        Ok = Comun.Comprueba_CC_Andorra(txbCCAndorra.Text);
                }

                if (!Ok)
                {
                    ret = false;
                    Mensajes.ShowError("La cuenta bancaria es incorrecta. Los datos no se guardarán.");
                }

                if (bCambioCC && Ok)
                {
                    //Si se ha cambiado la CC guardarla
                    ret = guardarNIFyCCEnContacto(iPagador, sNIF, sCC, sSWIFT, bEsClienteAndorrano);
                }
            }

            return ret;
        }

        private bool guardarNIFyCCEnContacto(int pIdCliente, string psNIF, string psCC, string psSWIFT, bool pbEsClienteAndorrano)
        {
            bool ret = false;
            bool Ok = true;

            if (!Comun.IsInTheArray(cboTipoPedido.SelectedValue.ToString(), Configuracion.asPedTransfer)) //DIR
            {
                if (!pbEsClienteAndorrano)
                {
                    //En este caso no permitiremos el truco de poner toda la cuenta a 0

                    // Dejaremos que puedan dejar en blanco el IBAN aquí (no lo hemos dejado en la pantalla frmNIFFCC donde sí obligamos a ponerlo)
                    // Lo que haremos es calcularlo si lo dejan en blanco
                    if (txbEntidad.Text.Trim() != "" && txbOficina.Text.Trim() != "" && txbControl.Text.Trim() != "" && txbCC.Text.Trim() != "" && txbIBAN.Text.Trim() == "")
                    {
                        txbIBAN.Text = Comun.calcula_IBAN_Espanya(txbEntidad.Text.Trim(), txbOficina.Text.Trim(), txbControl.Text.Trim(), txbCC.Text.Trim());
                    }

                    if (txbIBAN.Text.Trim() != "")
                        Ok = Comun.Comprueba_IBAN_Espanya(txbIBAN.Text.Trim(), txbEntidad.Text.Trim(), txbOficina.Text.Trim(), txbControl.Text.Trim(), txbCC.Text.Trim());
                }
                else
                    Ok = Comun.Comprueba_CC_Andorra(txbCCAndorra.Text.Trim());
            }

            if (psCC.Length == 22)
            {
                txbIBAN.Text = Comun.calcula_IBAN_Espanya(txbEntidad.Text.Trim(), txbOficina.Text.Trim(), txbControl.Text.Trim(), txbCC.Text.Trim());
                psCC = txbIBAN.Text.Trim() + psCC;
            }

            if (Ok)
            {
                //Guarda
                SqlTransaction sqlTran;

                if (sqlConn.State.ToString() == "Closed")
                    sqlConn.Open();

                sqlTran = sqlConn.BeginTransaction();
                sqlCmdSetContactosClientesSAP.Transaction = sqlTran;

                try
                {
                    this.sqlCmdSetContactosClientesSAP.Parameters["@iIdCliente"].Value = pIdCliente;
                    this.sqlCmdSetContactosClientesSAP.Parameters["@sNombre"].Value = psCC;
                    this.sqlCmdSetContactosClientesSAP.Parameters["@dFAR"].Value = psNIF;
                    this.sqlCmdSetContactosClientesSAP.Parameters["@iEstado"].Value = -2;
                    this.sqlCmdSetContactosClientesSAP.Parameters["@sSWIFT"].Value = psSWIFT;


                    this.sqlCmdSetContactosClientesSAP.ExecuteScalar();

                    sqlTran.Commit();

                    ret = true;
                }
                catch (Exception ex)
                {
                    ret = false;
                }
                finally
                {
                    sqlTran.Dispose();
                    sqlConn.Close();
                }
            }
            else
            {
                Mensajes.ShowError("La cuenta bancaria es incorrecta.");
            }

            return ret;
        }

        private bool datosNCDeHoy(out string oNIF, out string oCC, out string oSWIFT, bool pbEsClienteAndorrano, int pagador)
        {
            bool ret = false;
            bool condicio = false;

            oNIF = "";
            oCC = "";
            oSWIFT = "";


            SqlDataReader dr;

            if (sqlConn.State.ToString() == "Closed")
                sqlConn.Open();

            sqlCmdListaContactosClientes_SAP.Parameters["@iIdCliente"].Value = pagador;

            dr = sqlCmdListaContactosClientes_SAP.ExecuteReader();

            try
            {
                if (dr.Read())
                {
                    //Diferentes usos de la tabla según el valor de este campo
                    condicio = (int.Parse(dr["sIdCargoContacto"].ToString()) == 4);
                    //Los datos se han entrado hoy?
                    condicio = condicio && (dr["dFUM"].ToString().Substring(0, 10) == DateTime.Today.ToString().Substring(0, 6) + DateTime.Today.Year.ToString());
                    //Se han introcido los datos necesarios?
                    //Los andorranos pueden no tener nif
                    if (!pbEsClienteAndorrano)
                        condicio = condicio && dr["dFAR"] != null && dr["dFAR"].ToString().Trim() != ""; //En dFAR está el NIF
                    if (!Comun.IsInTheArray(cboTipoPedido.SelectedValue.ToString(), Configuracion.asPedTransfer))
                    {
                        condicio = condicio && dr["sNombre"] != null && dr["sNombre"].ToString().Trim() != "" && dr["sNombre"].ToString().Trim() != "--"; //En sNombre está la CC
                    }

                    if (condicio)
                    {
                        oNIF = dr["dFAR"].ToString().Trim();
                        oCC = dr["sNombre"].ToString().Trim();
                        oSWIFT = dr["sSWIFT"].ToString().Trim();

                        ret = true;
                    }
                }
            }
            catch (Exception err)
            {
                Mensajes.ShowError(err.ToString());
            }

            dr.Close();

            sqlConn.Close();
            return ret;
        }

        private void datosNC(out string pNif, out string pCC, out string pSWIFT, int pagador)
        {
            //Coger el NIF y la cuenta bancaria de Clientes_SAP del Solicitante seleccionado, y el SWIFT a partir de octubre de 2014
            pNif = "";
            pCC = "";
            pSWIFT = "";

            SqlDataReader drDto;

            if (sqlConn.State.ToString() == "Closed")
                sqlConn.Open();

            sqlCmdGetClientesSAP.Parameters["@iIdCliente"].Value = pagador;

            drDto = sqlCmdGetClientesSAP.ExecuteReader();

            try
            {


                if (drDto.Read())
                {
                    if (drDto["sNIF_SAP"] != null)
                        pNif = drDto["sNIF_SAP"].ToString().Trim();
                    if (drDto["sDatosBancarios_SAP"] != null)
                        pCC = drDto["sDatosBancarios_SAP"].ToString().Trim();
                    if (drDto["sSWIFT"] != null)
                        pSWIFT = drDto["sSWIFT"].ToString().Trim();
                }


            }
            catch (Exception err)
            {
                Mensajes.ShowError(err.ToString());
            }

            drDto.Close();
            sqlConn.Close();
        }

        #endregion


        #region Buscar Material

        private int GetNewIdLinea()
        {
            NewIdLinea += 10;
            return NewIdLinea;
        }

        private int GetNewIdGrupoMat()
        {
            NewIdGrupoMat++;
            return NewIdGrupoMat;
        }

        private void btnBuscarMaterial_Click(object sender, System.EventArgs e)
        {
            if (!AnyadirCampanya())
            {
                Mensajes.ShowExclamation("La campaña seleccionada es especial para descuentos en línea y es incompatible con el uso de otras campañas. El pedido solo puede tener esta campaña.");
                return;
            }

            // amb el càlcul d'extres cal que hi hagi el destinatari triat quan és transfer
            if (Comun.IsInTheArray(this.cboTipoPedido.SelectedValue.ToString(), Configuracion.asPedTransfer) && txtsDestinatario.Text.Trim() == "")
            {
                Mensajes.ShowError(String.Format("Debe indicar el Mayorista antes de seleccionar los materiales."));
            }
            else
            {
                DataRowView rowView = dsFormularios1.ListaCampanyas.DefaultView[cBoxCampanyas.SelectedIndex];
                //Si la campanya seleccionada ja existeix a la comanda haurem de fer com si fos una modificació
                int idGrup = HiHaCampanyaAPedido(cBoxCampanyas.SelectedValue.ToString());
                if (idGrup != -1)
                    BuscarMaterialesGrupo(rowView.Row, idGrup.ToString());
                else
                    BuscarMateriales(rowView.Row);
            }
        }
        

        private void BuscarMateriales(DataRow row)
        {
            idGrupMatSelected = -1;

            string TipoPedido = cboTipoPedido.SelectedValue.ToString();
            string sIdCampCab = "-1";
            if (cboTipoCampana.SelectedValue != null)
                sIdCampCab = cboTipoCampana.SelectedValue.ToString();


            _lPairsMatCampEnPed.Clear();
            _lPairsMatCampEnPed = getPairsMatCampEnPed();

            //---- GSG (05/07/2017)
            //Busquedas.frmMMateriales frmBMat = new Busquedas.frmMMateriales(row, cBoxCampanyas.SelectedIndex, txbDescExtra.Text, txbDescExtraRestante.Text, iIdCliente, TipoPedido, sIdCampCab, _lPairsMatCampEnPed);

            string mayorista = txtsDestinatario.Text.Trim();
            if (!Comun.IsInTheArray(cboTipoPedido.SelectedValue.ToString(), Configuracion.asPedTransfer) || mayorista == "")
                mayorista = "XXXX";

            //---- GSG (02/01/2023)
            //Busquedas.frmMMateriales frmBMat = new Busquedas.frmMMateriales(row, cBoxCampanyas.SelectedIndex, txbDescExtra.Text, txbDescExtraRestante.Text, iIdCliente, TipoPedido, sIdCampCab, _lPairsMatCampEnPed, mayorista);            
            Busquedas.frmMMateriales frmBMat = new Busquedas.frmMMateriales(row, cBoxCampanyas.SelectedIndex, txbDescExtra.Text, txbDescExtraRestante.Text, iIdCliente, TipoPedido, sIdCampCab, _lPairsMatCampEnPed, mayorista, _iMinimos);

            frmBMat.ShowDialog(this);

            if (frmBMat.DialogResult == DialogResult.OK)
            {                
                GetMaterialesToDataGridView(frmBMat.MaterialesLinea);               
            }
        }

        //---- VLP (26/07/2023)
        //Comprueba si se puede añadir una campaña. Se podrá añadir si los productos del pedido y el tipo de pedido son Tipo No Decuento Medio, o si ninguno
        //de los productos del pedido es del Tipo No Descuento Medio y el tipo de pedido tampoco está en la lista de tipos de pedido No Descuento Medio.
        private bool AnyadirCampanya()
        {
            bool ret = true;
            
            if (dataGridViewLineas.Rows.Count == 0)
            {
                return ret;
            }


            if (EsPedidoNoDecsMedio())
            {
                List<KeyValuePair<string, string>> matPedido = getPairsMatCampEnPed();            
                ret =  matPedido.First().Value == cBoxCampanyas.SelectedValue.ToString();
            }
            else
            {
                var campanyaCombo = dsFormularios1.ListaCampanyas.First(x => x.idCampanya == cBoxCampanyas.SelectedValue.ToString());
                bool cboCampanyaEsArrastre = campanyaCombo.bArrastre && Comun.IsInTheArray(cboTipoPedido.SelectedValue.ToString(), Configuracion.asTiposNoDescMedio); 
                ret = !cboCampanyaEsArrastre;
            }


            return ret;
        }

        //---- VLP (26/07/2023)
        //Comprueba si los todos los mateiales del pedido son de Tipo No Descuento Medio
        private bool EsPedidoNoDecsMedio()
        {
            if (dataGridViewLineas.Rows.Count == 0)
            {
                return false;
            }

            List<KeyValuePair<string, string>> matPedido = getPairsMatCampEnPed();
            var idsCampanyas = matPedido.Select(x => x.Value).Distinct();            
            
            var campanyaPrimerElemento = dsFormularios1.ListaCampanyas.First(x => x.idCampanya == idsCampanyas.First());
            bool primerElementoEsArrastre = campanyaPrimerElemento.bArrastre && Comun.IsInTheArray(cboTipoPedido.SelectedValue.ToString(), Configuracion.asTiposNoDescMedio);

            return idsCampanyas.Count() == 1 ? primerElementoEsArrastre : false;
        }

        //---- VLP (26/07/2023)
        //Comprueba si se puede cambiar el tipo de pedido. No se podrá cambiar si es un pedido con todos los materiales de Tipo No descuento Medio y
        //se selecciona un tipo de pedido que no está en la lista de Tipos No descuento Medio.
        private bool CambiarTipoPedido()
        {
            if (dataGridViewLineas.Rows.Count > 0)
            {
                List<KeyValuePair<string, string>> matPedido = getPairsMatCampEnPed();
                List<string> idsCampanyas = matPedido.Select(x => x.Value).Distinct().ToList();
                List<dsFormularios.ListaCampanyasRow> campanyas = new List<dsFormularios.ListaCampanyasRow>(); 

                foreach (string id in idsCampanyas)
                {
                    campanyas.Add(GetCampanyaById(id));   
                }
                
                string tipoPedido = cboTipoPedido.SelectedValue.ToString();
                if (!Comun.IsInTheArray(tipoPedido, Configuracion.asTiposNoDescMedio))
                {
                    return true;
                }

                if (campanyas.All(x => x.bArrastre == true))
                {
                    return true;
                }

                if (campanyas.All(x => x.bArrastre == false))
                {
                    return true;
                }


                return false;

            }

            return true;
        }


        // De entrada seleccionará los materiales de la lista y asignará las unidades que también vienen en la lista
        public void BuscarMateriales(DataRow row, List<string[]> listaMats, int posCod, int posUni, int posDto)
        {
            idGrupMatSelected = -1;

            string TipoPedido = cboTipoPedido.SelectedValue.ToString();
            string sIdCampCab = "-1";
            if (cboTipoCampana.SelectedValue != null)
                sIdCampCab = cboTipoCampana.SelectedValue.ToString();

            _lPairsMatCampEnPed.Clear();
            _lPairsMatCampEnPed = getPairsMatCampEnPed();
            //---- GSG (07/07/2017)
            //Busquedas.frmMMateriales frmBMat = new Busquedas.frmMMateriales(row, cBoxCampanyas.SelectedIndex, txbDescExtra.Text, txbDescExtraRestante.Text, iIdCliente, TipoPedido, sIdCampCab, _lPairsMatCampEnPed);

            string mayorista = txtsDestinatario.Text.Trim();
            if (!Comun.IsInTheArray(cboTipoPedido.SelectedValue.ToString(), Configuracion.asPedTransfer) || mayorista == "")
                mayorista = "XXXX";

            //---- GSG (02/01/2023)
            //Busquedas.frmMMateriales frmBMat = new Busquedas.frmMMateriales(row, cBoxCampanyas.SelectedIndex, txbDescExtra.Text, txbDescExtraRestante.Text, iIdCliente, TipoPedido, sIdCampCab, _lPairsMatCampEnPed, mayorista);
            Busquedas.frmMMateriales frmBMat = new Busquedas.frmMMateriales(row, cBoxCampanyas.SelectedIndex, txbDescExtra.Text, txbDescExtraRestante.Text, iIdCliente, TipoPedido, sIdCampCab, _lPairsMatCampEnPed, mayorista, _iMinimos);



            frmBMat._cargaMateriales = listaMats;
            frmBMat._V_POS_COD = posCod;
            frmBMat._V_POS_UNI = posUni;
            frmBMat._V_POS_DTO = posDto;
            frmBMat.ShowDialog(this);

            if (frmBMat.DialogResult == DialogResult.OK)
            {
                GetMaterialesToDataGridView(frmBMat.MaterialesLinea);
                if (frmBMat._bCampanyaExtra)
                {
                    double fDER = frmBMat._fDescExtraRestante;
                    txbDescExtraRestante.Text = fDER.ToString();
                }
            }
        }

        private void BuscarMaterialesGrupo(DataRow row, string idGrup)
        {
            idGrupMatSelected = int.Parse(idGrup);

            string TipoPedido = cboTipoPedido.SelectedValue.ToString();
            string sIdCampCab = "-1";
            if (cboTipoCampana.SelectedValue != null)
                sIdCampCab = cboTipoCampana.SelectedValue.ToString();
            _lPairsMatCampEnPed.Clear();
            _lPairsMatCampEnPed = getPairsMatCampEnPed();
            //---- GSG (07/07/2017)
            //Busquedas.frmMMateriales frmBMat = new Busquedas.frmMMateriales(row, dataGridViewLineas, idGrup, cBoxCampanyas.SelectedIndex, txbDescExtra.Text, txbDescExtraRestante.Text, iIdCliente, TipoPedido, sIdCampCab, _lPairsMatCampEnPed);
            string mayorista = txtsDestinatario.Text.Trim();
            if (!Comun.IsInTheArray(cboTipoPedido.SelectedValue.ToString(), Configuracion.asPedTransfer) || mayorista == "")
                mayorista = "XXXX";
            //---- GSG (02/01/2023)
            //Busquedas.frmMMateriales frmBMat = new Busquedas.frmMMateriales(row, dataGridViewLineas, idGrup, cBoxCampanyas.SelectedIndex, txbDescExtra.Text, txbDescExtraRestante.Text, iIdCliente, TipoPedido, sIdCampCab, _lPairsMatCampEnPed, mayorista);
            Busquedas.frmMMateriales frmBMat = new Busquedas.frmMMateriales(row, dataGridViewLineas, idGrup, cBoxCampanyas.SelectedIndex, txbDescExtra.Text, txbDescExtraRestante.Text, iIdCliente, TipoPedido, sIdCampCab, _lPairsMatCampEnPed, mayorista, _iMinimos); 
            
            frmBMat.ShowDialog(this);

            if (frmBMat.DialogResult == DialogResult.OK)
            {
                ModifMaterialesToDataGridView(frmBMat.MaterialesLinea);

                if (frmBMat._bCampanyaExtra)
                {
                    double fDER = frmBMat._fDescExtraRestante;
                    txbDescExtraRestante.Text = fDER.ToString();
                }
            }
        }

        private void BuscarMaterialesConArrastre(DataRow row)
        {
            idGrupMatSelected = -1;

            Busquedas.frmMMaterialesArrastres frmBMat = new Busquedas.frmMMaterialesArrastres(row);
            frmBMat.ShowDialog(this);

            if (frmBMat.DialogResult == DialogResult.OK)
                GetMaterialesToDataGridView(frmBMat.MaterialesLinea);
        }

        private void GetMaterialesToDataGridView(List<dsMateriales.ListaLineasPedidoRow> MaterialesLinea)
        {
            if (MaterialesLinea.Count == 0) // Si se pasa una lista vacía no se hace nada
                return;

            int IdGrupoMat = GetNewIdGrupoMat();

            // Realiza la inserción de las lineas seleccionadas
            foreach (dsMateriales.ListaLineasPedidoRow rowLinea in MaterialesLinea)
            {
                rowLinea.iIdLinea = GetNewIdLinea();
                rowLinea.idGrupoMat = IdGrupoMat;

                dsMateriales.ListaLineasPedidoRow nuevaLinea = dtLineasPedido.NewListaLineasPedidoRow();

                for (int i = 0; i < nuevaLinea.ItemArray.Length; i++)
                    nuevaLinea[i] = rowLinea[i];

                if (nuevaLinea.NombreCampanya == String.Empty)
                    nuevaLinea.NombreCampanya = GetCampanyaById(nuevaLinea.idCampanya).NombreCampanya;

                dtLineasPedido.Rows.Add(nuevaLinea);
            }

            dataGridViewLineas.DataSource = dtLineasPedido;
            FormatDataGridLineas();

            lblCounter.Text = this.dtLineasPedido.DefaultView.Count.ToString();

            AplicarDescuentoGeneral();
        }

        private void ModifMaterialesToDataGridView(List<dsMateriales.ListaLineasPedidoRow> MaterialesLinea)
        {
            if (MaterialesLinea.Count == 0) // Si se pasa una lista vacía no se hace nada
                return;

            int IdGrupoMat = idGrupMatSelected;
            int iLin = -1;

            //Realiza la modificación del grupo seleccionado
            foreach (dsMateriales.ListaLineasPedidoRow rowLinea in MaterialesLinea)
            {
                //Buscar si el material existeix per al grup
                iLin = HiHaMaterialAlGrup(IdGrupoMat, rowLinea.sIdMaterial);
                if (iLin != -1)
                {
                    //si existeix modificar
                    foreach (DataGridViewRow row in dataGridViewLineas.Rows)
                    {
                        if (iLin == int.Parse(row.Cells[0].Value.ToString()))
                        {
                            row.Cells[K_COL_CANT].Value = rowLinea["iCantidad"];
                            row.Cells[K_COL_DTO].Value = rowLinea["fDescuento"]; // Descuento aplicado
                            row.Cells[K_COL_NOMCAMP].Value = rowLinea["NombreCampanya"];
                            row.Cells[K_COL_IDCAMP].Value = rowLinea["idCampanya"];
                            //falta canviar més coses que no s'han de mantenir de la campanya anterior
                            //si no que cal actualitzar amb la nova
                            row.Cells[K_COL_BRUTO].Value = rowLinea["fPrecio"];
                            row.Cells[K_COL_IMPORTE].Value = rowLinea["ImporteLin"];
                            row.Cells[K_COL_DTOMAX].Value = rowLinea["fDescuentoMaximo"]; //Descuento máximo material según campaña
                            row.Cells[K_COL_RENT].Value = rowLinea["fRentabilidad"];
                            row.Cells[K_COL_COSTE].Value = rowLinea["fCoste"];
                            row.Cells[K_COL_UNIMIN].Value = rowLinea["UnidMinimas"];
                            break;

                        }
                    }
                }
                else
                {
                    //si no existeix afegir
                    rowLinea.iIdLinea = GetNewIdLinea();
                    rowLinea.idGrupoMat = IdGrupoMat;

                    dsMateriales.ListaLineasPedidoRow nuevaLinea = dtLineasPedido.NewListaLineasPedidoRow();

                    for (int i = 0; i < nuevaLinea.ItemArray.Length; i++)
                        nuevaLinea[i] = rowLinea[i];

                    if (nuevaLinea.NombreCampanya == String.Empty)
                        nuevaLinea.NombreCampanya = GetCampanyaById(nuevaLinea.idCampanya).NombreCampanya;

                    dtLineasPedido.Rows.Add(nuevaLinea);

                    dataGridViewLineas.DataSource = dtLineasPedido;
                }
            }

            //També cal mirar si algun material ha desaparegut del grup per un canvi de campanya --> eliminar-lo
            int nIndex = 0, comptador = 0;
            int[] indexAEliminar = new int[1000];
            foreach (DataGridViewRow row in dataGridViewLineas.Rows)
            {
                if (BorrarMaterial(int.Parse(row.Cells[K_COL_IDGRUPOMAT].Value.ToString()), row.Cells[K_COL_IDCAMP].Value.ToString(), row.Cells[K_COL_IDMAT].Value.ToString(), MaterialesLinea))
                {
                    indexAEliminar[comptador] = nIndex;
                    comptador++;
                }
                nIndex++;
            }
            if (comptador > 0)
            {
                for (int i = comptador - 1; i >= 0; i--)
                    dataGridViewLineas.Rows.RemoveAt(indexAEliminar[i]);
                dtLineasPedido.AcceptChanges();
            }

            FormatDataGridLineas();

            lblCounter.Text = this.dtLineasPedido.DefaultView.Count.ToString();

            AplicarDescuentoGeneral();
        }

        private int HiHaMaterialAlGrup(int IdGrupoMat, string sIdMaterial)
        {
            string sIdMat = "";
            string sIdGrup = "";

            foreach (DataGridViewRow row in dataGridViewLineas.Rows)
            {
                sIdMat = row.Cells[K_COL_IDMAT].Value.ToString();
                sIdGrup = row.Cells[K_COL_IDGRUPOMAT].Value.ToString();
                if (sIdMat == sIdMaterial && int.Parse(sIdGrup) == IdGrupoMat)
                {
                    return int.Parse(row.Cells[K_COL_LIN].Value.ToString());
                }
            }

            return -1;
        }

        private bool BorrarMaterial(int idGrup, string IdCampanya, string sIdMaterial, List<dsMateriales.ListaLineasPedidoRow> MaterialesLinea)
        {
            string sIdMat = "";
            string sIdCampanya = "";
            int iGrupo = -1;
            bool ret = false;

            foreach (dsMateriales.ListaLineasPedidoRow rowLinea in MaterialesLinea)
            {
                sIdCampanya = rowLinea["idCampanya"].ToString();
                iGrupo = int.Parse(rowLinea["idGrupoMat"].ToString());
                sIdMat = rowLinea["sIdMaterial"].ToString();

                if (idGrup == iGrupo)
                {
                    if (sIdMat == sIdMaterial)
                        return false;
                    else
                        ret = true;
                }
            }

            return ret;
        }

        int HiHaCampanyaAPedido(string sIdCampanya)
        {
            foreach (DataGridViewRow row in dataGridViewLineas.Rows)
            {
                if (sIdCampanya == row.Cells[K_COL_IDCAMP].Value.ToString())
                    return int.Parse(row.Cells[K_COL_IDGRUPOMAT].Value.ToString());
            }

            return -1;
        }

        #endregion



        //--- GSG (13/09/2016)
        private void UpdateDataGridView(string sIdPedido)
        {
            try
            {
                List<QtyAccMark> lAccMarkGrabades = new List<QtyAccMark>(); // Guardarà les que venen de gravació anterior quan la comanda ya existeix

                // carrega al grid les accions obtingudes segons filtres
                dataGridViewAccMark.DataSource = dsAccionesMarketing1.ListaAccionesMarketing;

                // Reset selected per deixar-les totes a no seleccionades
                foreach (DataGridViewRow row in dataGridViewAccMark.Rows)
                    row.Cells["selected"].Value = false;

                //busca accions de la comanda (quan es guarden les comandes a la taula PedAcciones es guarden les accions seleccionades per a la comanda)

                //---- GSG (13/03/2019) Sols fer-ho al carregar per primera vegada una comanda guardada
                //if (sIdPedido != "") // Si comanda ja existeix agafa les que ja té guardades
                if (sIdPedido != "" && _recuperaAccMarkPedido) // Si comanda ja existeix agafa les que ja té guardades
                {
                    lAccMarkGrabades = ObtenirAccionsPed(sIdPedido);
                    _recuperaAccMarkPedido = false; //---- GSG (13/03/2019)
                }

                foreach (DataGridViewRow row in dataGridViewAccMark.Rows)
                {
                    // inicializado los checks antes de nada 
                    QtyAccMark item = lAccMarkGrabades.Find(delegate (QtyAccMark qm) { return qm.idAccion == row.Cells["iIdAccionDataGridViewTextBoxColumn"].Value.ToString(); });
                    if (item != null)
                    {
                        row.Cells["selected"].Value = true;
                        row.Cells["UnidadesAEntregar"].Value = item.iUnidades;


                        // Pintar en gris las que queden inactivas debido a este check
                        int accionSeleccionada = int.Parse(row.Cells["iIdAccionDataGridViewTextBoxColumn"].Value.ToString());
                        foreach (ParejasExclusion pe in _listaExclusion)
                        {
                            // La seleccionada tiene excluidas?
                            if (pe.miembro_1 == accionSeleccionada || pe.miembro_2 == accionSeleccionada)
                            {
                                // Identificar la pareja de la acción seleccionada
                                int idAccionPareja = pe.miembro_1; // por defecto
                                if (pe.miembro_1 == accionSeleccionada)
                                    idAccionPareja = pe.miembro_2;

                                foreach (DataGridViewRow row2 in dataGridViewAccMark.Rows)
                                {
                                    if (int.Parse(row2.Cells["iIdAccionDataGridViewTextBoxColumn"].Value.ToString()) == idAccionPareja)
                                        // Pintar la pareja en gris
                                        for (int i = 0; i < row.Cells.Count; i++)
                                            row2.Cells[i].Style.BackColor = Color.Gray;

                                }
                            }
                        }

                    }
                    else
                        row.Cells["UnidadesAEntregar"].Value = 1; // Por defecto ponemos 1
                }


                this.lblNumReg.Text = lAccMarkGrabades.Count.ToString() + " / " + dataGridViewAccMark.Rows.Count.ToString();

                dataGridViewAccMark.Refresh();
            }
            catch (Exception ex)
            {
                Mensajes.ShowError(ex.Message);
            }
        }



        // Analizar las acciones seleccionadas para ver que valor hay que poner en las unidades que se solicitarán
        // Si para un producto se ha seleccionado una sola acción relacionada --> = Todas las unidades van a esta acción
        // Si más de una acción --> = 1 en cada acción
        private void SetUnidadesAccMark()
        {
            foreach (DataGridViewRow row in dataGridViewAccMark.Rows)
            {
                bool bMesDuna = false;

                if (bool.Parse(row.Cells["selected"].Value.ToString()) && !bool.Parse(row.Cells["bIndepe"].Value.ToString()))
                {
                    int idAccMark = int.Parse(row.Cells["iIdAccionDataGridViewTextBoxColumn"].Value.ToString());
                    string prod = row.Cells["sIdProducto"].Value.ToString();

                    foreach (DataGridViewRow row2 in dataGridViewAccMark.Rows)
                    {
                        int idAccMark2 = int.Parse(row2.Cells["iIdAccionDataGridViewTextBoxColumn"].Value.ToString());

                        if (bool.Parse(row2.Cells["selected"].Value.ToString()) && idAccMark != idAccMark2 && !bool.Parse(row2.Cells["bIndepe"].Value.ToString()))
                        {
                            string prod2 = row2.Cells["sIdProducto"].Value.ToString();
                            if (prod == prod2)
                            {
                                bMesDuna = true;
                                break;
                            }
                        }
                    }

                    // Si n'hi ha més d'una hi posem 1 i continuem amb la següent
                    // no cal que actualitzem les que estan amb elles perquè ja ho farem quan arribi el seu torn en el bucle superior
                    if (bMesDuna)
                    {
                        //---- GSG (29/03/2022)
                        //row.Cells["UnidadesAEntregar"].Value = 1;
                        row.Cells["UnidadesAEntregar"].Value = int.Parse(row.Cells["iNumElemEntregar"].Value.ToString());

                        this.dataGridViewAccMark.RefreshEdit();
                        this.dataGridViewAccMark.NotifyCurrentCellDirty(true);
                    }
                    else
                    {
                        // Buscar el valor que depèn del import de la comanda
                        // Si(coste unitario acción / importe total pedido) >= iNumMaxEntregar-- > iNumMaxEntregar
                        // Si no --> Valor entero de la división
                        float fBrutoPedido = float.Parse(txbImporteBruto.Text.Replace('€', ' ').Trim());
                        //float fCoste = float.Parse(row.Cells["fCosteUnitarioDataGridViewTextBoxColumn"].Value.ToString());
                        float fImpMinAcc = float.Parse(row.Cells["fImpMin"].Value.ToString());
                        int unidades = 0;

                        if (fImpMinAcc <= 1)
                            unidades = 1;
                        else
                        {
                            //---- GSG (29/03/2022)
                            //unidades = (int)(fBrutoPedido / fImpMinAcc);
                            unidades = (int)(fBrutoPedido / fImpMinAcc) * int.Parse(row.Cells["iNumElemEntregar"].Value.ToString());

                            int maximo = int.Parse(row.Cells["iMaxAEntregar"].Value.ToString());

                            if (unidades >= maximo)
                                row.Cells["UnidadesAEntregar"].Value = maximo;
                            else
                                row.Cells["UnidadesAEntregar"].Value = unidades;

                            this.dataGridViewAccMark.RefreshEdit();
                            this.dataGridViewAccMark.NotifyCurrentCellDirty(true);
                        }

                    }
                }


            }
        }

        private List<string> ValidaSeleccionAcckMark()
        {
            // Repasso taula accions i si están seleccionades miro producte y creo taula amb producte o "" y quantitats mínimes necesaries (sumant o no segons bSuma)
            // i.e. creo grups per comparar amb comanda

            List<ValuesProd> tSeleccion = new List<ValuesProd>(); // Valores por grupos o individuales preparados para comparar
            float fBrutoPedido = 0;
            int iCantidadPedido = 0;
            float fRentabilidadPedido = 0;
            int numMaxAccMark = 0;
            int numAccMarkSel = 0;
            string missatge = "";
            List<string> lMissatges = new List<string>();


            // 1.- Obtener valores según selección

            tSeleccion = GetValuesSeleccionAccMArk();


            // 2.- Comparar lo seleccionado con lo que hay en el pedido

            fBrutoPedido = float.Parse(txbImporteBruto.Text.Replace('€', ' ').Trim());
            foreach (ValuesProd val in _tValuesProdEnPed)
                iCantidadPedido += val.iCantidad;
            fRentabilidadPedido = float.Parse(txtRentabilidad.Text);

            // 1ª COMPROBACIÓN : Número máximo de acciones que se pueden seleccionar
            //                   Esto viene, ahora, en la tabla AccMarkRangos que determina el máximo en función de rangos de importe

            numMaxAccMark = GetMaxAccMark(fBrutoPedido);
            foreach (DataGridViewRow row in dataGridViewAccMark.Rows)
            {
                if (bool.Parse(row.Cells["selected"].Value.ToString()) && !bool.Parse(row.Cells["bIndepe"].Value.ToString()))
                    numAccMarkSel++;
            }

            if (numAccMarkSel > numMaxAccMark)
            {
                missatge = String.Format("El número de acciones seleccionado ({0}) es superior al permitido ({1}) según el importe del pedido.", numAccMarkSel, numMaxAccMark);
                lMissatges.Add(missatge);
            }


            // 2ª COMPROBACIÓN : Acciones excluidas por la selección de otras
            //                   Esto viene, ahora, en la tabla AccMarkExclusion que determina la relación de exclusión entre acciones


            if (_listaExclusion.Count > 0)
            {
                foreach (ParejasExclusion pe in _listaExclusion)
                {
                    int numCheckeds = 0;
                    string[] pareja = new string[] { "", "" };

                    foreach (DataGridViewRow row in dataGridViewAccMark.Rows)
                    {
                        if (bool.Parse(row.Cells["selected"].Value.ToString()) && (int.Parse(row.Cells["iIdAccionDataGridViewTextBoxColumn"].Value.ToString()) == pe.miembro_1 || int.Parse(row.Cells["iIdAccionDataGridViewTextBoxColumn"].Value.ToString()) == pe.miembro_2))
                        {
                            pareja[numCheckeds] = row.Cells["sDescAccionDataGridViewTextBoxColumn"].Value.ToString();
                            numCheckeds++;
                        }
                    }

                    if (numCheckeds > 1)
                    {
                        missatge = String.Format("Las acciones {0} y {1} no pueden seleccionarse a la vez.", pareja[0], pareja[1]);
                        lMissatges.Add(missatge);
                    }
                }
            }


            // 3ª COMPROBACIÓN : Rentabilidad mínima requerida según configuración de acciones de márketing

            foreach (ValuesProd val in tSeleccion)
            {
                if (val.sIdProducto != "") // Comparar con parte del pedido correspondiente a este producto
                {
                    string codProd = val.sIdProducto;
                    int pos = codProd.IndexOf("_"); // para contemplar los que no sumaban y a los que he añadido un guión bajo seguido de un número
                    if (pos >= 0)
                        codProd = codProd.Substring(0, pos);

                    ValuesProd valPed = _tValuesProdEnPed.Find(x => x.sIdProducto == val.sIdProducto);
                    if (valPed != null)
                    {
                        if (valPed.fRentabilidad < val.fRentabilidad)
                        {
                            missatge = String.Format("La rentabilidad del pedido para el producto {0} es inferior a la requerida por las acciones de márketing seleccionadas.", valPed.sProducto);
                            lMissatges.Add(missatge);
                        }
                    }
                }
                else // Comparar con el total del pedido porque son acciones que no tienen producto asociado
                {
                    if (fRentabilidadPedido < val.fRentabilidad)
                    {
                        missatge = String.Format("La rentabilidad del pedido es inferior a la requerida por las acciones de márketing seleccionadas.");
                        lMissatges.Add(missatge);
                    }
                }
            }


            // 4ª COMPROBACIÓN : Unidades mínimas requeridas según configuración de acciones de márketing

            foreach (ValuesProd val in tSeleccion)
            {
                if (val.sIdProducto != "")
                {
                    string codProd = val.sIdProducto;
                    int pos = codProd.IndexOf("_");
                    if (pos >= 0)
                        codProd = codProd.Substring(0, pos);

                    ValuesProd valPed = _tValuesProdEnPed.Find(x => x.sIdProducto == val.sIdProducto);
                    if (valPed != null)
                    {
                        if (valPed.iCantidad < val.iCantidad)
                        {
                            missatge = String.Format("Las unidades del pedido para el producto {0} es inferior a la requerida por las acciones de márketing seleccionadas.", valPed.sProducto);
                            lMissatges.Add(missatge);
                        }
                    }
                }
                else // Comparar con el total del pedido porque son acciones que no tienen producto asociado
                {
                    if (iCantidadPedido < val.iCantidad)
                    {
                        missatge = String.Format("Las unidades del pedido no llegan a las requeridas por las acciones de márketing seleccionadas.");
                        lMissatges.Add(missatge);
                    }
                }
            }


            // 5ª COMPROBACIÓN : importe mínimo requerido según configuración de acciones de márketing

            foreach (ValuesProd val in tSeleccion)
            {
                if (val.sIdProducto != "")
                {
                    string codProd = val.sIdProducto;
                    int pos = codProd.IndexOf("_");
                    if (pos >= 0)
                        codProd = codProd.Substring(0, pos);

                    ValuesProd valPed = _tValuesProdEnPed.Find(x => x.sIdProducto == val.sIdProducto);
                    if (valPed != null)
                    {
                        if (valPed.fImporte < val.fImporte)
                        {
                            missatge = String.Format("El importe del pedido para el producto {0} es inferior al requerido por las acciones de márketing seleccionadas.", valPed.sProducto);
                            lMissatges.Add(missatge);
                        }
                    }
                }
                else // Comparar con el total del pedido porque son acciones que no tienen producto asociado
                {
                    if (fBrutoPedido < val.fImporte)
                    {
                        missatge = String.Format("El importe del pedido es inferior al requerido por las acciones de márketing seleccionadas.");
                        lMissatges.Add(missatge);
                    }
                }
            }

            return lMissatges;

        }

        // Repasa el grid de acciones de márketing y para los seleccionados crea grupos (excluye los independientes ya que no cuentan para hacer ninguna comprobación)
        private List<ValuesProd> GetValuesSeleccionAccMArk()
        {
            List<ValuesProd> tSeleccion = new List<ValuesProd>();
            string idProd = "";
            string nombreProd = "";
            int cantidad = 0;
            float importe = 0;
            float rentabilidad = 0;
            bool bSuma = false;
            int contador = 1;

            foreach (DataGridViewRow row in dataGridViewAccMark.Rows)
            {
                bool bSel = bool.Parse(row.Cells["selected"].Value.ToString());
                if (bSel && !bool.Parse(row.Cells["bIndepe"].Value.ToString()))
                {
                    if (row.Cells["sIdProducto"].Value != null && row.Cells["sIdProducto"].Value != System.DBNull.Value)
                        idProd = row.Cells["sIdProducto"].Value.ToString();
                    else
                        idProd = "";
                    nombreProd = row.Cells["sDescAccionDataGridViewTextBoxColumn"].Value.ToString();
                    //---- GSG (29/03/2022)
                    //cantidad = int.Parse(row.Cells["iUnidades"].Value.ToString());
                    cantidad = int.Parse(row.Cells["UnidadesAEntregar"].Value.ToString());

                    //importe = float.Parse(row.Cells["fCosteUnitarioDataGridViewTextBoxColumn"].Value.ToString()); 
                    importe = float.Parse(row.Cells["fImpMin"].Value.ToString());
                    rentabilidad = float.Parse(row.Cells["fRentabilidad"].Value.ToString());

                    if (row.Cells["bSuma"].Value != null && row.Cells["bSuma"].Value != System.DBNull.Value)
                        bSuma = bool.Parse(row.Cells["bSuma"].Value.ToString());
                    else
                        bSuma = false;

                    if (bSuma)
                    {
                        ValuesProd val = tSeleccion.Find(delegate (ValuesProd val1) { return val1.sIdProducto == idProd; });

                        if (val == null)
                            tSeleccion.Add(new ValuesProd(idProd, nombreProd, cantidad, importe, rentabilidad));
                        else
                        {
                            tSeleccion.Find(x => x.sIdProducto == idProd).iCantidad += cantidad;
                            tSeleccion.Find(x => x.sIdProducto == idProd).fImporte += importe;
                            // la rentabilidad no suma (entiendo que será la misma en todos los del grupo)
                        }
                    }
                    else
                    {
                        // Para que no se le sumen después los del mismo producto que sí van agrupados añado a idProd un texto que lo distinga y también del resto que puedan ir sin agrupar del mismo producto
                        tSeleccion.Add(new ValuesProd(idProd + "_" + contador.ToString(), nombreProd, cantidad, importe, rentabilidad));
                        contador++;
                    }
                }
            }

            return tSeleccion;
        }


        /*
        private void UpdateDataGridView(string sIdPedido)
        {
            try
            {
                //actualitza el grid
                dataGridViewAccMark.DataSource = dsAccionesMarketing1.ListaAccionesMarketing;


                //busca accions de la comanda (quan es guarden les comandes a la taula PedAcciones es guarden les accions seleccionades per a la comanda)
                string accions = "";

                if (sIdPedido != "") // Si comanda ja existeix agafa les que ja té
                    accions = ObtenirAccionsPed(sIdPedido);
                else // Si comanda és nova, agafa les seleccionades al grid
                {
                    foreach (DataGridViewRow row in dataGridViewAccMark.Rows)
                    {
                        if (row.Cells["selected"].Value != null && bool.Parse(row.Cells["selected"].Value.ToString()) == true)
                            accions += (row.Cells["iIdAccionDataGridViewTextBoxColumn"].Value.ToString() + ",");
                    }
                }

                // Torna a deixar totes a no 
                foreach (DataGridViewRow row in dataGridViewAccMark.Rows)
                    row.Cells["selected"].Value = false;

                
                //actualitza el grid
                dataGridViewAccMark.DataSource = dsAccionesMarketing1.ListaAccionesMarketing;

                float fBrutoPedido = 0;
                fBrutoPedido = float.Parse(txbImporteBruto.Text.Replace('€', ' ').Trim());


                foreach (DataGridViewRow row in dataGridViewAccMark.Rows)
                {
                    if (accions.IndexOf(row.Cells["iIdAccionDataGridViewTextBoxColumn"].Value.ToString() + ",") >= 0)
                        row.Cells["selected"].Value = true;

                    int iNumMaxEntrega = 0;
                    float fBrutoMin = 0;
                    float fBrutoMax = 0;
                    float fCosteAccMark = 0;

                    if (row.Cells["iMaxAEntregar"].Value != null && row.Cells["iMaxAEntregar"].Value.ToString() != "")
                        iNumMaxEntrega = int.Parse(row.Cells["iMaxAEntregar"].Value.ToString());

                    if (row.Cells["fImpMin"].Value != null && row.Cells["fImpMin"].Value.ToString() != "")
                        fBrutoMin = float.Parse(row.Cells["fImpMin"].Value.ToString());

                    if (row.Cells["fImpMax"].Value != null && row.Cells["fImpMax"].Value.ToString() != "")
                        fBrutoMax = float.Parse(row.Cells["fImpMax"].Value.ToString());

                    fCosteAccMark = float.Parse(row.Cells["fCosteTotal"].Value.ToString());

                    if (fCosteAccMark != 0)
                    {
                        int iUnidadesEntrega = (int)(fBrutoPedido / fCosteAccMark);
                        if (iUnidadesEntrega <= iNumMaxEntrega)
                            row.Cells["UnidadesAEntregar"].Value = iUnidadesEntrega;
                        else
                            row.Cells["UnidadesAEntregar"].Value = iNumMaxEntrega;
                    }
                    else
                        row.Cells["UnidadesAEntregar"].Value = 0;
                }

                //Filtrar el grid para que sólo se vean las acciones que incluyen el bruto en sus márgenes
                DataRow[] rows = dsAccionesMarketing1.ListaAccionesMarketing.Select("fImpMin <= " + fBrutoPedido.ToString().Replace(',', '.') + " and fImpMax >= " + fBrutoPedido.ToString().Replace(',', '.'));
                string accsVisibles = "";
                foreach (DataRow dr in rows)
                {
                    accsVisibles += dr["iIdAccion"].ToString() + ",";
                }

                foreach (DataGridViewRow row in dataGridViewAccMark.Rows)
                {
                    dataGridViewAccMark.CurrentCell = null;

                    if (accsVisibles.IndexOf(row.Cells["iIdAccionDataGridViewTextBoxColumn"].Value.ToString() + ",") >= 0)
                        row.Visible = true;
                    else
                    {
                        row.Visible = false;
                        row.Cells["selected"].Value = false;
                    }
                }

                int nFilasVisibles = 0;
                if (rows != null)
                    nFilasVisibles = rows.Length;

                this.lblNumReg.Text = nFilasVisibles.ToString() + " / " + dataGridViewAccMark.Rows.Count.ToString();

                dataGridViewAccMark.Refresh();

                
            }
            catch (Exception ex)
            {
                Mensajes.ShowError(ex.Message);
            }
        }
        */

        //GSG: Este método actualiza los clubs del cliente.       
        private void dto_general()
        {
            //Coger el dto_general y el código pago de Clientes_SAP del Solicitante seleccionado

            SqlDataReader drDto;
            string idG = "", idG1 = "", idG2 = "", idG3 = "", idG4 = "";


            if (sqlConn.State.ToString() == "Closed")
                sqlConn.Open();

            sqlCmdGetClientesSAP.Parameters["@iIdCliente"].Value = this.iIdCliente;
            drDto = sqlCmdGetClientesSAP.ExecuteReader();


            try
            {


                if (drDto.Read())
                {
                    // Guardar sCodPago_SAP. Si la condición es ZB00 no hay que pedir la CC en ningún caso
                    _sCondPago = drDto["sCodPago_SAP"].ToString();

                    txtCodPago.Text = drDto["tCodPago_SAP"].ToString();
                    txtGarantias.Text = drDto["sGarantias_SAP"].ToString();
                    txtGarantias1.Text = drDto["sGarantias_SAP_1"].ToString();
                    txtGarantias2.Text = drDto["sGarantias_SAP_2"].ToString();
                    txtGarantias3.Text = drDto["sGarantias_SAP_3"].ToString();
                    txtGarantias4.Text = drDto["sGarantias_SAP_4"].ToString();
                    txtMailConf.Text = drDto["sEmailConf"].ToString();
                    txtMailFact.Text = drDto["sEmailFact"].ToString();

                    if (drDto["sEncComercial_SAP"].ToString().ToUpper() == "SIN ASIGNAR")
                        txtEncComercial.Text = "0";
                    else
                        txtEncComercial.Text = drDto["sEncComercial_SAP"].ToString();

                    idG = drDto["idGarantias_SAP"].ToString();
                    idG1 = drDto["idGarantias_SAP_1"].ToString();
                    idG2 = drDto["idGarantias_SAP_2"].ToString();
                    idG3 = drDto["idGarantias_SAP_3"].ToString();
                    idG4 = drDto["idGarantias_SAP_4"].ToString();
                }



                //---- GSG (02/02/2021)
                /*

                //Permitir modificar los emails sólo si los últimos introducidos ya están tratados
                //---- GSG (24/10/2019) También se puede modificar si si no está tratado y no se ha enviado a central --> (Cambio en EmailsTratados)
                string oEmailConf;
                string oEmailFact;
                bool oExiste;
                //---- GSG (24/10/2019) 
                bool oEnviadoCEN;
                //if (EmailsTratados(this.iIdCliente, out oEmailConf, out oEmailFact, out oExiste))
                if (EmailsTratados(this.iIdCliente, out oEmailConf, out oEmailFact, out oExiste, out oEnviadoCEN))
                {
                    if (oExiste)
                    {
                        //Coger el valor de la tabla EmailsClientes y no de ClientesSAP
                        txtMailConf.Text = oEmailConf;
                        txtMailFact.Text = oEmailFact;
                    }
                    else
                    {
                        //Coger el valor de la tabla ClientesSAP
                        // En este caso ya lo hemos asignado unas líneas más arriba cuando el dto estaba abierto
                        //txtMailConf.Text = drDto["sEmailConf"].ToString();
                        //txtMailFact.Text = drDto["sEmailFact"].ToString();
                    }

                    txtMailConf.Enabled = true;
                    txtMailFact.Enabled = true;
                }
                else if (!oEnviadoCEN && oExiste) //---- GSG (24/10/2019) 
                {
                    txtMailConf.Text = oEmailConf;
                    txtMailFact.Text = oEmailFact;

                    txtMailConf.Enabled = true;
                    txtMailFact.Enabled = true;
                }
                else
                {
                    //Coger el valor de la tabla EmailsClientes y no de ClientesSAP
                    txtMailConf.Text = oEmailConf;
                    txtMailFact.Text = oEmailFact;
                    //Desactivar porqué no está tratado
                    txtMailConf.Enabled = false;
                    txtMailFact.Enabled = false;
                }

                */


                string backCol = "#EEF3F6";
                Color cBackCol = System.Drawing.ColorTranslator.FromHtml(backCol);
                txtGarantias.BackColor = cBackCol; //blau clar
                txtGarantias1.BackColor = cBackCol;
                txtGarantias2.BackColor = cBackCol;
                txtGarantias3.BackColor = cBackCol;
                txtGarantias4.BackColor = cBackCol;


                drDto.Close(); //---- GSG (20/03/2023)

                //Tractem els clubs: si estan a la taula ClubAviso --> mostrar avís
                if (idG != "" || idG1 != "" || idG2 != "" || idG3 != "" || idG4 != "")
                {
                    string AlertMessage = String.Empty;

                    sqldaListaClubsAviso.Fill(dsFormularios1.ListaClubsAviso);
                    foreach (dsFormularios.ListaClubsAvisoRow rowLinea in dsFormularios1.ListaClubsAviso)
                    {
                        bool bMiss = false;

                        if (idG == rowLinea.sGarantia.ToString())
                        {
                            txtGarantias.BackColor = Color.Orange;
                            bMiss = true;
                        }
                        else if (idG1 == rowLinea.sGarantia.ToString())
                        {
                            txtGarantias1.BackColor = Color.Orange;
                            bMiss = true;
                        }
                        else if (idG2 == rowLinea.sGarantia.ToString())
                        {
                            txtGarantias2.BackColor = Color.Orange;
                            bMiss = true;
                        }
                        else if (idG3 == rowLinea.sGarantia.ToString())
                        {
                            txtGarantias3.BackColor = Color.Orange;
                            bMiss = true;
                        }
                        else if (idG4 == rowLinea.sGarantia.ToString())
                        {
                            txtGarantias4.BackColor = Color.Orange;
                            bMiss = true;
                        }

                        if (bMiss)
                            AlertMessage = String.Format("El cliente {0} tiene negociada una condición especial.", txtsCliente.Text);
                    }

                    if (AlertMessage.Length > 0)
                    {
                        Mensajes.ShowInformation(AlertMessage);
                    }
                    else
                    {
                        DialogResult = DialogResult.OK;
                    }
                }

                garanties[0] = idG;
                garanties[1] = idG1;
                garanties[2] = idG2;
                garanties[3] = idG3;
                garanties[4] = idG4;
            }
            catch (Exception err)
            {
                Mensajes.ShowError(err.ToString());
            }

            //---- GSG (20/03/2023)
            //drDto.Close();

            sqlConn.Close();
        }

        private void getDatosClienteIndep()
        {
            txtProgInf.Text = GetProgramaInformatico(this.iIdCliente);
            cboProgInf.SelectedIndex = cboProgInf.FindString(txtProgInf.Text);
            ActualizarImporteMedioPedido(this.iIdCliente);
            // Obtiene los datos de contactos clientes o bien de clientes SAP            
            cargarNIFyCC();
        }

        private void ActualizarImporteLinea(int RowIndex)
        {

            int iCantidad = int.Parse(dataGridViewLineas.Rows[RowIndex].Cells["ColCantidad"].Value.ToString());
            double fDescuento = double.Parse(dataGridViewLineas.Rows[RowIndex].Cells["ColDescuento"].Value.ToString()); //descuento aplicado
            double PrecioUnitario = (double)dataGridViewLineas.Rows[RowIndex].Cells["ColPrecio"].Value;

            //Sumamos el descuento general
            fDescuento += DtoGeneral;

            double PrecioBruto = iCantidad * PrecioUnitario;
            double Descuento = PrecioBruto * fDescuento / 100;

            double ImporteNeto = Math.Round(PrecioBruto - Descuento, 2); //Aquí tenemos el importe con el descuento de línea

            dataGridViewLineas.Rows[RowIndex].Cells["ColPrecioBruto"].Value = PrecioBruto;
            dataGridViewLineas.Rows[RowIndex].Cells["ColImporteLin"].Value = ImporteNeto;

            // fDescMat = 
            //            Si el material es financiado -->  Min(desc aplicado, desc en factura para el cliente)
            //            No financialdo -->  Si DIR --> Min(desc aplicado, desc max material dir)
            //                                Si TRA --> Min(desc aplicado, desc max material tra)
            double fDescMat = double.Parse(dataGridViewLineas.Rows[RowIndex].Cells["ColfDescMat"].Value.ToString());
            // Pondremos en variable fDescMat el valor adecuado para el cálculo del extra pero no lo cambiamos 

            if (bool.Parse(dataGridViewLineas.Rows[RowIndex].Cells["bFinanciado"].Value.ToString()))
            {
                double descFactura = double.Parse(GetDescuentoFactura(this.iIdCliente));
                if (descFactura > 0)
                {
                    if (descFactura > fDescuento)
                        fDescMat = double.Parse(dataGridViewLineas.Rows[RowIndex].Cells["ColDescuento"].Value.ToString());
                    else
                        fDescMat = descFactura;
                }
                else //igual que no finan
                {
                    double descuento = 0;
                    if (Comun.IsInTheArray(cboTipoPedido.SelectedValue.ToString(), Configuracion.asPedTransfer))
                        descuento = double.Parse(dataGridViewLineas.Rows[RowIndex].Cells["ColfDescuentoMaximoTRA"].Value.ToString());
                    else //DIR
                        descuento = double.Parse(dataGridViewLineas.Rows[RowIndex].Cells["ColfDescuentoMaximoDIR"].Value.ToString());

                    if (descuento > fDescuento)
                        fDescMat = fDescuento;
                    else
                        fDescMat = descuento;
                }
            }
            else //No financiado
            {
                double descuento = 0;
                if (Comun.IsInTheArray(cboTipoPedido.SelectedValue.ToString(), Configuracion.asPedTransfer))
                    descuento = double.Parse(dataGridViewLineas.Rows[RowIndex].Cells["ColfDescuentoMaximoTRA"].Value.ToString());
                else //DIR
                    descuento = double.Parse(dataGridViewLineas.Rows[RowIndex].Cells["ColfDescuentoMaximoDIR"].Value.ToString());

                if (descuento > fDescuento)
                    fDescMat = fDescuento;
                else
                    fDescMat = descuento;
            }

            dataGridViewLineas.Rows[RowIndex].Cells["ColfDescMat"].Value = fDescMat;

            // CÁLCULO DEL EXTRA
            // NO LO VOY A TOCAR AQUÍ YA QUE COMO TAMPOCO VIENE BIEN DE LA STORED, YA LO CALCULARÉ EN EL TOTAL DEL PEDIDO

            ActualizarImporteMedioPedido(this.iIdCliente);
        }

        private void AplicarDescuentoGeneral()
        {
            if (dataGridViewLineas.Rows.Count == 0)
                return;

            for (int i = 0; i < dataGridViewLineas.Rows.Count; i++)
            {
                ActualizarImporteLinea(i);
                Application.DoEvents();
            }

            ActualizarTotales();
        }

        private void ActualizarTotales()
        {
            activarForm(false);

            double Neto = 0.0;
            double Bruto = 0.0;
            int iNumUnitatsPedido = 0;
            double fDescExtra = 0.0;
            double fDescExtraGastados = 0.0;
            double fPVP = 0.0;
            double fPVPIVA = 0.0;
            double fMargen = 0.0;
            double NetoArrastre = 0.0;
            double BrutoArrastre = 0.0;
            double BrutoF = 0.0;
            double BrutoNF = 0.0;
            double NetoF = 0.0;
            double NetoNF = 0.0;
            double DescMedioF = 0.0;
            double DescMedioNF = 0.0;
            double DescFacturaF = 0.0;
            double DescFacturaNF = 0.0;
            double brutoDeLin = 0;
            double netoFacturaDeLin = 0;
            double fDescMatLin = 0; // En ColfDescMat tenemos siempre el descuento bueno independientemente del aplicado. Si hay factura lo tiene en cuenta igual que si es F o NF
            double descFacEnLin = 0;
            double pvpNF = 0;
            double margenNF = 0;
            double Descuento;
            //----  GSG (02/01/2023)
            double BrutoCuentan = 0.0;
            double BrutoExcluidos = 0.0;
            double NetoCuentan = 0.0;
            double NetoExcluidos = 0.0;
            double DescMedioCuentan = 0.0;
            double DescMedioExcluidos = 0.0;




            // Antes de actualizar, si existen materiales de regalo especiales tenemos que actualizar sus descuentos
            foreach (RegaloEspecial re in _lRegaloEspecial)
            {
                string codc = re.codCamp;
                double brutoRegalos = 0;
                double brutoTotal = 0;
                string idMat = "";

                foreach (DataGridViewRow dr in dataGridViewLineas.Rows)
                {
                    if (dr.Cells["ColidCampanya"].Value.ToString() == codc)
                    {
                        idMat = dr.Cells["sIdMaterialDataGridViewTextBoxColumn"].Value.ToString();
                        if (re.EsRegalo(idMat))
                        {
                            int qty = int.Parse(dr.Cells["ColCantidad"].Value.ToString());
                            double precio = double.Parse(dr.Cells["ColPrecio"].Value.ToString());
                            brutoRegalos += (qty * precio);
                            brutoTotal += (qty * precio);
                        }
                        else if (re.EsEspecial(idMat))
                        {
                            int qty = int.Parse(dr.Cells["ColCantidad"].Value.ToString());
                            double precio = double.Parse(dr.Cells["ColPrecio"].Value.ToString());
                            brutoTotal += (qty * precio);
                        }
                    }
                }

                double descMedio = brutoRegalos / brutoTotal;

                //Actualizar los descuentos de los materiales implicados
                foreach (DataGridViewRow dr in dataGridViewLineas.Rows)
                {
                    if (dr.Cells["ColidCampanya"].Value.ToString() == codc)
                    {
                        dr.Cells["ColDescuento"].Value = Math.Round(descMedio * 100, 2);
                        dr.Cells["ColImporteLin"].Value = double.Parse(dr.Cells["ColPrecioBruto"].Value.ToString()) - ((double.Parse(dr.Cells["ColPrecioBruto"].Value.ToString()) * double.Parse(dr.Cells["ColDescuento"].Value.ToString()) / 100));
                    }
                }
            }


            foreach (DataGridViewRow dr in dataGridViewLineas.Rows)
            {
                // Cuando una línea pertence a una campaña con bArrastre = 1 no debe contar para el importe del pedido 
                dsFormularios.ListaCampanyasRow Campanya = GetCampanyaById(dr.Cells["ColidCampanya"].Value.ToString());

                if (Campanya != null)
                {
                    //if (bool.Parse(dr.Cells["ColbDescExtra"].Value.ToString()) == false && !Campanya.bArrastre) //---- VLP (26/07/2023) sustituida por la de abajo
                    if (bool.Parse(dr.Cells["ColbDescExtra"].Value.ToString()) == false)
                    {
                        Neto += (double)dr.Cells["ColImporteLin"].Value; //dr.ImporteLin;
                        Bruto += (double)dr.Cells["ColPrecioBruto"].Value; //dr.fPrecio;

                        iNumUnitatsPedido += int.Parse(dr.Cells["ColCantidad"].Value.ToString());

                        // Actualizar PVP, PVPIVA
                        fPVP += (double.Parse(dr.Cells["ColfPVP"].Value.ToString()) * int.Parse(dr.Cells["ColCantidad"].Value.ToString()));
                        fPVPIVA += (double.Parse(dr.Cells["ColfPVPIVA"].Value.ToString()) * int.Parse(dr.Cells["ColCantidad"].Value.ToString()));

                        Application.DoEvents();

                        // Al actualizar el importe de línea se ha actualizado también el extra por lo que aquí no hace falta calcularlo en cada línea
                        // y sólo habrá que sumarlos
                        double brutoLin = (double)dr.Cells["ColPrecioBruto"].Value;
                        double fDescMat = double.Parse(dr.Cells["ColfDescMat"].Value.ToString());

                        //Nota: aunque el código es el mismo el valor de fDescMat es distinto. Mantengo los ifs para tener claros los casos

                        if (dr.Cells["bFinanciado"].Value == System.DBNull.Value || !bool.Parse(dr.Cells["bFinanciado"].Value.ToString()))
                        {
                            //No financiados

                            if (Comun.IsInTheArray(cboTipoPedido.SelectedValue.ToString(), Configuracion.asPedTransfer)) //TRA
                            {
                                double desc = GetDescuentoMayoristaClub();
                                if (desc > 0)
                                {
                                    desc = fDescMat - desc;  // descuento que queda 
                                    if (desc < 0)
                                        desc = 100; //Se lo queda todo el mayorista --> no acumula extra

                                    fDescExtra += (brutoLin - ((brutoLin * desc) / 100));
                                }
                            }
                            else //DIR
                                fDescExtra += (brutoLin - ((brutoLin * fDescMat) / 100)); // En fDescMat está el mínimo entre el dado y el máximo por material 
                        }
                        else
                        {
                            // Financiados

                            if (Comun.IsInTheArray(cboTipoPedido.SelectedValue.ToString(), Configuracion.asPedTransfer)) //TRA
                            {
                                double desc = GetDescuentoMayoristaClub();
                                if (desc > 0)
                                {
                                    desc = fDescMat - desc;  // descuento que queda 
                                    if (desc < 0)
                                        desc = 100; //Se lo queda todo el mayorista --> no acumula extra

                                    fDescExtra += (brutoLin - ((brutoLin * desc) / 100));
                                }
                            }
                            else // DIR
                            {
                                fDescExtra += (brutoLin - ((brutoLin * fDescMat) / 100)); // En fDescMat está el mínimo entre el dado y el máximo por material teniendo en cuenta el descuento en factura (tanto si es directo como transfer)
                            }
                        }

                        if (dr.Cells["bFinanciado"].Value == System.DBNull.Value || !bool.Parse(dr.Cells["bFinanciado"].Value.ToString()))
                        {
                            //No financiados
                            BrutoNF += (double)dr.Cells["ColPrecioBruto"].Value;
                            // Para que los decimales del descuento medio sean más exactos
                            NetoNF += brutoLin - (brutoLin * double.Parse(dr.Cells["ColDescuento"].Value.ToString()) / 100);


                        }
                        else
                        {
                            // Financiados
                            BrutoF += (double)dr.Cells["ColPrecioBruto"].Value;
                            // Para que los decimales del descuento medio sean más exactos
                            //NetoF += (double)dr.Cells["ColImporteLin"].Value;
                            NetoF += brutoLin - (brutoLin * double.Parse(dr.Cells["ColDescuento"].Value.ToString()) / 100);


                            //----  GSG (02/01/2023)
                            if (int.Parse(dr.Cells["iBloc"].Value.ToString()) == 0)
                            {
                                BrutoCuentan += (double)dr.Cells["ColPrecioBruto"].Value;
                                NetoCuentan += brutoLin - (brutoLin * double.Parse(dr.Cells["ColDescuento"].Value.ToString()) / 100);
                            }
                            else if (int.Parse(dr.Cells["iBloc"].Value.ToString()) == 1 &&
                                (cboTipoPedido.SelectedValue.ToString() == Comun.K_TIPOPED_TRANSFER || (cboTipoPedido.SelectedValue.ToString() == Comun.K_TIPOPED_COMPROMISO)))
                            {
                                BrutoExcluidos += (double)dr.Cells["ColPrecioBruto"].Value;
                                NetoExcluidos += brutoLin - (brutoLin * double.Parse(dr.Cells["ColDescuento"].Value.ToString()) / 100);
                            }
                            else if (int.Parse(dr.Cells["iBloc"].Value.ToString()) == 2 &&
                                cboTipoPedido.SelectedValue.ToString() == Comun.K_TIPOPED_COMPROMISO && _iMinimos == 1)
                            {
                                BrutoExcluidos += (double)dr.Cells["ColPrecioBruto"].Value;
                                NetoExcluidos += brutoLin - (brutoLin * double.Parse(dr.Cells["ColDescuento"].Value.ToString()) / 100);
                            }
                            else
                            {
                                BrutoCuentan += (double)dr.Cells["ColPrecioBruto"].Value;
                                NetoCuentan += brutoLin - (brutoLin * double.Parse(dr.Cells["ColDescuento"].Value.ToString()) / 100);
                            }




                            //---- FI GSG

                        }

                    }
                    else if (!Campanya.bArrastre)
                    {
                        fDescExtraGastados += int.Parse(dr.Cells["ColCantidad"].Value.ToString()) * double.Parse(dr.Cells["ColPrecio"].Value.ToString());
                    }                        
                    // ---- VLP (26/07/2023). Comentado 
                    //else if (Campanya.bArrastre && bool.Parse(dr.Cells["ColbDescExtra"].Value.ToString()) == false)
                    //{
                        //NetoArrastre += (double)dr.Cells["ColImporteLin"].Value; //dr.ImporteLin;
                        //BrutoArrastre += (double)dr.Cells["ColPrecioBruto"].Value; //dr.fPrecio;
                    //}
                }
            }


            if (BrutoNF != 0.0)
                DescMedioNF = ((BrutoNF - NetoNF) / BrutoNF) * 100;
            else
                DescMedioNF = 0.0;

            if (BrutoF != 0.0)
                DescMedioF = ((BrutoF - NetoF) / BrutoF) * 100;
            else
                DescMedioF = 0.0;


            foreach (DataGridViewRow dr in dataGridViewLineas.Rows)
            {
                fDescMatLin = double.Parse(dr.Cells["ColfDescMat"].Value.ToString());
                brutoDeLin = (double)dr.Cells["ColPrecioBruto"].Value;
                netoFacturaDeLin = brutoDeLin - (brutoDeLin * fDescMatLin) / 100;
                //descMedioFacEnLin = (brutoDeLin - netoFacturaDeLin) / brutoDeLin; //en valor
                descFacEnLin = brutoDeLin - netoFacturaDeLin; // el valor

                if (bool.Parse(dr.Cells["bFinanciado"].Value.ToString()))
                    DescFacturaF += descFacEnLin;
                else
                {
                    DescFacturaNF += descFacEnLin;
                    pvpNF += (double.Parse(dr.Cells["ColfPVP"].Value.ToString()) * int.Parse(dr.Cells["ColCantidad"].Value.ToString()));
                }
            }

            if (BrutoF != 0.0)
                DescFacturaF = (DescFacturaF / BrutoF) * 100;
            if (BrutoNF != 0.0)
                DescFacturaNF = (DescFacturaNF / BrutoNF) * 100;
            if (pvpNF != 0.0)
                //margenNF = ((pvpNF - NetoNF) / pvpNF) * 100; //porcentaje de margen
                margenNF = pvpNF - NetoNF; //valor del margen



            //----  GSG (02/01/2023)
            if (BrutoCuentan != 0.0)
                DescMedioCuentan = ((BrutoCuentan - NetoCuentan) / BrutoCuentan) * 100;
            else
                DescMedioCuentan = 0.0;

            if (BrutoExcluidos != 0.0)
                DescMedioExcluidos = ((BrutoExcluidos - NetoExcluidos) / BrutoExcluidos) * 100;
            else
                DescMedioExcluidos = 0.0;


            txbDtoCuentan.Text = String.Format("{0:#,0.##}%", DescMedioCuentan);
            txbDtoExcluidos.Text = String.Format("{0:#,0.##}%", DescMedioExcluidos);
            //---- FI GSG




            txbMargenNF.Text = margenNF.ToString("C2");
            txbImporteBrutoF.Text = BrutoF.ToString("C2");
            txbImporteBrutoNF.Text = BrutoNF.ToString("C2");
            txbImporteNetoF.Text = NetoF.ToString("C2");
            txbImporteNetoNF.Text = NetoNF.ToString("C2");
            txbDtoMedioF.Text = String.Format("{0:#,0.##}%", DescMedioF);
            txbDtoMedioNF.Text = String.Format("{0:#,0.##}%", DescMedioNF);
            txbDescFacturaF.Text = String.Format("{0:#,0.##}%", DescFacturaF);
            txbDescFacturaNF.Text = String.Format("{0:#,0.##}%", DescFacturaNF);

            if (Bruto != 0.0)
                Descuento = (((Bruto - Neto) + BrutoArrastre) / Bruto) * 100;
            else
                Descuento = 0.0;


            txbImporte.Text = Neto.ToString("C2");

            // Actualizar PVP, PVPIVA y margen del pedido
            // Neto = (PVL - descuento)
            // Margen = ((PVP - (PVL - descuento)) / PVP) * 100
            fMargen = 0.0;
            if (fPVP != 0)
                fMargen = ((fPVP - Neto) / fPVP) * 100;

            txbPVP.Text = fPVP.ToString("C2");
            txbPVPIVA.Text = fPVPIVA.ToString("C2");
            txbMargen.Text = String.Format("{0:#,0.##}%", fMargen);

            ImportePedido = Neto;
            // Si Directo y ZMAY no hay extra
            if (_bEsDirectoZMAY && !Comun.IsInTheArray(cboTipoPedido.SelectedValue.ToString(), Configuracion.asPedTransfer))
            {
                fDescExtra = 0;
                fDescExtraGastados = 0;
            }
            else
                fDescExtra = fDescExtra - ImportePedido;





            if (fDescExtra < 0) fDescExtra = 0.0;
            this.txbDescExtra.Text = fDescExtra.ToString("N2");
            this.txbDescExtraRestante.Text = (fDescExtra - fDescExtraGastados).ToString("N2");

            bool bCambiaBruto = (double.Parse(txbImporteBruto.Text.Replace('€', ' ').Trim()) != Bruto);

            txbImporteBruto.Text = Bruto.ToString("C2");
            //txbMinimUnitats.Text = iNumUnitatsPedido.ToString();  //---- GSG (15/05/2019) Lo quito porque este dato ya no se muestra
            txbDto.Text = String.Format("{0:#,0.##}%", Descuento);

            //Actualizar variables globales
            ImportePedido = Neto;
            ImportePedidoBruto = Bruto;
            iUnitatsPedido = iNumUnitatsPedido;
            DescuentoMedio = Descuento;

            ActualizarRentabilidad();

            ActualizarMargenLab(); //----GSG (29709/2020) PUNTOS

            //---- GSG (13/09/2016)
            //if (bCambiaBruto)
            //    UpdateDataGridView("");

            //---- GSG (15/05/2019) Lo quito porque creo que ya no se utiliza
            //getDatosFinanciacion(); 

            activarForm(true);


        }

        private void ActualizarRentabilidad()
        {
            Color cColor = Color.FromArgb(238, 243, 246);

            float Renta = Calcular_Rentabilidad();

            if (!float.IsNaN(Renta))
            {
                txtRentabilidad.Text = Renta.ToString("N2");
                txbRentabilidad.Text = CalcularDescripcionRentabilidad(Renta, dtpFechaPedido.Value);
                cColor = CalcularColorRentabilidad(Renta, dtpFechaPedido.Value);
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

            txbRentabilidad.BackColor = cColor;

            gfRenta = Renta;
        }

        //----GSG (29/09/2020) PUNTOS
        private void ActualizarMargenLab()
        {
            float margen = Calcular_MargenLab();

            txbMargenLab.Text = margen.ToString("N2");

        }

        private void FormatDataGridLineas()
        {
            int NumLinea = 0;

            dataGridViewLineas.DefaultCellStyle.ForeColor = Color.Black;

            // Omple la columna amb el criteri d'ordenació i ordena            
            //ordena per grup
            dataGridViewLineas.Sort(dataGridViewLineas.Columns["ColIdGrupoMat"], 0);
            //estableix ordre desitjat
            for (int i = 0; i < dataGridViewLineas.Rows.Count - 1; i++)
            {
                if ((dataGridViewLineas.Rows[i].Cells["ColIdGrupoMat"].Value != DBNull.Value) &&
                    (dataGridViewLineas.Rows[i + 1].Cells["ColIdGrupoMat"].Value != DBNull.Value))
                {
                    dataGridViewLineas.Rows[i].Cells["ordre"].Value = dataGridViewLineas.Rows[i].Cells["ColIdGrupoMat"].Value.ToString() + dataGridViewLineas.Rows[i].Cells["ColProducto"].Value.ToString();
                }
            }
            if (dataGridViewLineas.Rows.Count > 0)
            {
                dataGridViewLineas.Rows[dataGridViewLineas.Rows.Count - 1].Cells["ordre"].Value = dataGridViewLineas.Rows[dataGridViewLineas.Rows.Count - 1].Cells["ColIdGrupoMat"].Value.ToString() + dataGridViewLineas.Rows[dataGridViewLineas.Rows.Count - 1].Cells["ColProducto"].Value.ToString();
            }
            //ordena
            dataGridViewLineas.Sort(dataGridViewLineas.Columns["ordre"], 0);


            for (int i = 0; i < dataGridViewLineas.Rows.Count - 1; i++)
            {
                NumLinea += 10;
                dataGridViewLineas.Rows[i].Cells["ColiIdLinea"].Value = NumLinea;

                if ((dataGridViewLineas.Rows[i].Cells["ColIdGrupoMat"].Value != DBNull.Value) &&
                    (dataGridViewLineas.Rows[i + 1].Cells["ColIdGrupoMat"].Value != DBNull.Value))
                {
                    if ((int)dataGridViewLineas.Rows[i].Cells["ColIdGrupoMat"].Value !=
                        (int)dataGridViewLineas.Rows[i + 1].Cells["ColIdGrupoMat"].Value)
                        dataGridViewLineas.Rows[i].DividerHeight = 1;
                }

                Application.DoEvents();
            }

            if (dataGridViewLineas.Rows.Count > 0)
            {
                NumLinea += 10;
                dataGridViewLineas.Rows[dataGridViewLineas.Rows.Count - 1].Cells["ColiIdLinea"].Value = NumLinea;
            }


            //Aquí tendremos el último número de línea asignado
            NewIdLinea = NumLinea;
        }

        private bool valorsCampanya(object sender, DataGridViewCellEventArgs e)
        {
            bool ret = false;

            string IdCampanya = dataGridViewLineas.Rows[e.RowIndex].Cells["ColIdCampanya"].Value.ToString();
            int IdGrupoMat = (int)dataGridViewLineas.Rows[e.RowIndex].Cells["ColIdGrupoMat"].Value;
            char dot = (char)0x25CF;

            dsFormularios.ListaCampanyasRow row = GetCampanyaById(IdCampanya);

            int iTotalProductos = 0;
            double dImporteTotalBruto = 0.0;
            int iCantidadTotalMinObli = row.iNumMinOblisTotal;
            double dImporteBrutoMinObli = row.fImporteMinObliBruto;

            //----- GSG (13/01/2017)
            //foreach (dsMateriales.ListaLineasPedidoRow dr in dtLineasPedido.Rows)
            //    if (dr.idGrupoMat == IdGrupoMat)
            //    {
            //        iTotalProductos += int.Parse(dr.iCantidad);
            //        dImporteTotalBruto += dr.fPrecio;
            //    }

            foreach (dsMateriales.ListaLineasPedidoRow dr in dtLineasPedido.Rows)
                if (dr.idGrupoMat == IdGrupoMat && dr.sTipoMat != K_ZMKT)
                {
                    iTotalProductos += int.Parse(dr.iCantidad) * dr.iCantidadBase;
                    dImporteTotalBruto += dr.fPrecio;
                }



            StringBuilder ErrorMessage = new StringBuilder();

            if (iTotalProductos < iCantidadTotalMinObli)
                ErrorMessage.AppendFormat(" {2} La cantidad total ({0}) del grupo no puede ser menor que {1} según campaña.", iTotalProductos, iCantidadTotalMinObli, dot);

            if (dImporteTotalBruto < dImporteBrutoMinObli)
                ErrorMessage.AppendFormat(" {2} El importe bruto total ({0:C}) del grupo no puede ser menor que {1}€ según campaña.", dImporteTotalBruto, dImporteBrutoMinObli, dot);


            float fRentMin = GetRentMinCamp(IdCampanya);
            float fRentSeleccion = GetRentCamp(IdCampanya);
            if (fRentSeleccion < fRentMin)
            {
                ErrorMessage.AppendFormat("La rentabilidad no supera el mínimo requerido por la campaña " + dataGridViewLineas.Rows[e.RowIndex].Cells["ColCampanya"].Value.ToString() + ".");
            }

            if (ErrorMessage.Length > 0)
            {
                ErrorMessage.Insert(0, "No puede modificar esta línea con estos valores.\n\n");
                Mensajes.ShowError(ErrorMessage.ToString());

                dataGridViewLineas.CancelEdit();
            }
            else
            {
                ret = true;
            }


            return ret;
        }

        private float GetRentCamp(string IdCampanya)
        {
            float rent = 0;
            float denom = 0;

            foreach (DataGridViewRow row in dataGridViewLineas.Rows)
            {
                //---- GSG (13/01/2017) K_ZMKT
                // if (row.Cells["ColidCampanya"].Value.Equals(IdCampanya) && !Comun.IsInTheArray(row.Cells["ColidCampanya"].Value.ToString(), _lCampanyasNoRenta))
                if (row.Cells["ColTipoMat"].Value != null && row.Cells["ColTipoMat"].Value.ToString() != K_ZMKT && row.Cells["ColidCampanya"].Value.Equals(IdCampanya) && !Comun.IsInTheArray(row.Cells["ColidCampanya"].Value.ToString(), _lCampanyasNoRenta))
                {
                    int iCantidad = int.Parse(row.Cells["ColCantidad"].Value.ToString());
                    float fPrecio = float.Parse(row.Cells["ColPrecio"].Value.ToString());
                    float fDescuento = float.Parse(row.Cells["ColDescuento"].Value.ToString());
                    float fCoste = -1;
                    if (row.Cells["fCosteDataGridViewTextBoxColumn"].Value != DBNull.Value)
                        fCoste = float.Parse(row.Cells["fCosteDataGridViewTextBoxColumn"].Value.ToString());

                    rent += DameNominadorRentabilidad(iCantidad, fPrecio, fDescuento + (float)DtoGeneral, fCoste);
                    denom += DameDenominadorRentabilidad(iCantidad, fPrecio);
                }
            }

            float res = 0.0F;
            if (!(denom == 0 && rent != 0))   //Aquest cas donaria -Infinity i al retorna no queda controlat per float.isNAN
                res = (rent / denom) * 100.0F;

            return res;
        }

        private bool EsObligatorio(int RowNumber)
        {
            return dataGridViewLineas.Rows[RowNumber].Cells["ColObligatorio"].Value.ToString() == obligatorioSi;
        }

        private bool EsArrastre(int RowNumber)
        {
            bool ret = false;
            if (int.Parse(dataGridViewLineas.Rows[RowNumber].Cells["ColidArrastre"].Value.ToString()) == 1)
                ret = true;

            return ret;
        }

        private bool SeViolaImporteMinimo(int IdGrupoMat, DataGridViewCellParsingEventArgs e, out double ImporteTotal, out double ImporteMinObli)
        {
            string IdCampanya = dataGridViewLineas.Rows[e.RowIndex].Cells["ColIdCampanya"].Value.ToString();

            dsFormularios.ListaCampanyasRow row = GetCampanyaById(IdCampanya);

            ImporteMinObli = row.fImporteMinObli;

            //Calcular importe del grupo. Sumamos todas las filas menos la que se ha cambiado
            ImporteTotal = 0.0;
            for (int i = 0; i < dataGridViewLineas.Rows.Count; i++)
                if ((i != e.RowIndex) &&
                    ((int)dataGridViewLineas.Rows[i].Cells["ColIdGrupoMat"].Value == IdGrupoMat))
                {
                    ImporteTotal += (double)dataGridViewLineas.Rows[i].Cells["ColImporteLin"].Value;
                }

            int iCantidad = int.Parse(dataGridViewLineas.Rows[e.RowIndex].Cells["ColCantidad"].EditedFormattedValue.ToString());
            double fDescuento = double.Parse(dataGridViewLineas.Rows[e.RowIndex].Cells["ColDescuento"].EditedFormattedValue.ToString());
            double PrecioUnitario = (double)dataGridViewLineas.Rows[e.RowIndex].Cells["ColPrecio"].Value;

            double PrecioBruto = iCantidad * PrecioUnitario;
            double Descuento = PrecioBruto * fDescuento / 100;

            double ImporteNeto = PrecioBruto - Descuento;

            ImporteTotal += ImporteNeto; //Sumamos la fila que faltaba

            return ImporteTotal < ImporteMinObli;
        }

        private void SeViolaMinimosCampanya(int IdGrupoMat, DataGridViewCellParsingEventArgs e, out bool bImporteMinNeto, out bool bImporteMinBruto, out bool bCantidadMinTotal, out double fImpReal, out double fImpObli, out int iQuanReal, out int iQuanObli)
        {
            string IdCampanya = dataGridViewLineas.Rows[e.RowIndex].Cells["ColIdCampanya"].Value.ToString();

            dsFormularios.ListaCampanyasRow row = GetCampanyaById(IdCampanya);

            double ImporteMinObli = 0.0;
            double ImporteMinObliBruto = 0.0;

            if (row.fImporteMinObliBruto > 0) //Mana el brut
                ImporteMinObliBruto = row.fImporteMinObliBruto;
            else //Mana el net
                ImporteMinObli = row.fImporteMinObli;


            int CantidadMinObli = row.iNumMinOblisTotal;


            //Calcular importe del grupo. Sumamos todas las filas menos la que se ha cambiado
            double ImporteTotal = 0.0;
            int CantidadTotal = 0;

            int iCantidad = 0;
            double fDescuento = 0;
            double fPrecioUnitario = 0;
            double ImporteNeto = 0;
            double PrecioBruto = 0;
            double Descuento = 0;
            int iCantidadBase = 1; //---- GSG (13/01/2017)

            for (int i = 0; i < dataGridViewLineas.Rows.Count; i++)
            {
                //---- GSG (13/01/2017)
                //if ((i != e.RowIndex) && ((int)dataGridViewLineas.Rows[i].Cells["ColIdGrupoMat"].Value == IdGrupoMat))
                if ((i != e.RowIndex) && (dataGridViewLineas.Rows[i].Cells["ColTipoMat"].Value != null) && (dataGridViewLineas.Rows[i].Cells["ColTipoMat"].Value.ToString() != K_ZMKT) && ((int)dataGridViewLineas.Rows[i].Cells["ColIdGrupoMat"].Value == IdGrupoMat))
                {
                    iCantidad = int.Parse(dataGridViewLineas.Rows[i].Cells["ColCantidad"].EditedFormattedValue.ToString());
                    fDescuento = double.Parse(dataGridViewLineas.Rows[i].Cells["ColDescuento"].EditedFormattedValue.ToString());
                    fPrecioUnitario = (double)dataGridViewLineas.Rows[i].Cells["ColPrecio"].Value;

                    iCantidadBase = int.Parse(dataGridViewLineas.Rows[i].Cells["ColCantidadBase"].EditedFormattedValue.ToString()); //---- GSG (13/01/2017)

                    PrecioBruto = iCantidad * fPrecioUnitario;
                    Descuento = PrecioBruto * fDescuento / 100;
                    ImporteNeto = PrecioBruto - Descuento;

                    if (row.fImporteMinObliBruto > 0)
                        ImporteTotal += PrecioBruto;
                    else
                        ImporteTotal += ImporteNeto;

                    //---- GSG (13/01/2017)
                    //CantidadTotal += iCantidad;
                    CantidadTotal += (iCantidad * iCantidadBase);
                }
            }

            if ((dataGridViewLineas.Rows[e.RowIndex].Cells["ColTipoMat"].EditedFormattedValue != null) && (dataGridViewLineas.Rows[e.RowIndex].Cells["ColTipoMat"].EditedFormattedValue.ToString() != K_ZMKT)) //---- GSG (13/01/2017)
            {
                //Afegim la fila que ha cambiat
                iCantidad = int.Parse(dataGridViewLineas.Rows[e.RowIndex].Cells["ColCantidad"].EditedFormattedValue.ToString());
                fDescuento = double.Parse(dataGridViewLineas.Rows[e.RowIndex].Cells["ColDescuento"].EditedFormattedValue.ToString());
                fPrecioUnitario = (double)dataGridViewLineas.Rows[e.RowIndex].Cells["ColPrecio"].Value;
                iCantidadBase = int.Parse(dataGridViewLineas.Rows[e.RowIndex].Cells["ColCantidadBase"].EditedFormattedValue.ToString()); //---- GSG (13/01/2017)

                PrecioBruto = iCantidad * fPrecioUnitario;
                Descuento = PrecioBruto * fDescuento / 100;
                ImporteNeto = PrecioBruto - Descuento;

                //Sumamos la fila que faltaba
                if (row.fImporteMinObliBruto > 0)
                    ImporteTotal += PrecioBruto;
                else
                    ImporteTotal += ImporteNeto;

                //---- GSG (13/01/2017)
                //CantidadTotal += iCantidad;
                CantidadTotal += (iCantidad * iCantidadBase);

            }

            //Valors de retorn

            bImporteMinNeto = false; //inicialment tot ok
            bImporteMinBruto = false;
            bCantidadMinTotal = false;

            if (row.fImporteMinObliBruto > 0)
            {
                if (ImporteTotal < ImporteMinObliBruto)
                    bImporteMinBruto = true; //problemes amb el brut
            }

            else
            {
                if (ImporteTotal < ImporteMinObli)
                    bImporteMinNeto = true; //problemes amb el net
            }

            if (CantidadTotal < CantidadMinObli)
                bCantidadMinTotal = true; //problemes amb la quantitat


            fImpReal = ImporteTotal;
            if (row.fImporteMinObliBruto > 0) fImpObli = ImporteMinObliBruto;
            else fImpObli = ImporteMinObli;
            iQuanReal = CantidadTotal;
            iQuanObli = CantidadMinObli;

            return;
        }

        private string SeViolaMinimosPresentacion(DataGridViewCellParsingEventArgs e)
        {
            //ATENCIÓN: la función SeViolaMinimosPresentacionAlBorrar es muy parecida 
            //Si se hacen cambios qizá haya que replicarlos.
            SqlTransaction sqlTran = null;
            if (sqlConn.State.ToString() == "Closed")
                sqlConn.Open();
            sqlTran = sqlConn.BeginTransaction();

            //Sabré quins materials he de sumar perquè tenen la mateixa campanya i producte (no material)
            string sIdCampanyaSel = dataGridViewLineas.Rows[e.RowIndex].Cells["ColIdCampanya"].Value.ToString();
            string sProducteSel = ObtenirProductoMaterial(dtLineasPedido.DefaultView[e.RowIndex]["sIdMaterial"].ToString(), sqlTran);
            string sProducte = "";
            string sNomProducteSel = dataGridViewLineas.Rows[e.RowIndex].Cells["ColProducto"].Value.ToString();
            double descompteSel = double.Parse(dataGridViewLineas.Rows[e.RowIndex].Cells["ColDescuento"].EditedFormattedValue.ToString());
            int iNumMatsSel = 0; //Cal acumular-hi totes les quantitats de la presentació, no sols la que s'està modificant
            int numMatsPC = 0;
            double importNetPC = 0, importNetPCAcum = 0;
            double importBrutPC = 0, importBrutPCAcum = 0;
            double descomptePC = 0;
            string ErrorMessage = "";

            //Del material seleccionat treiem els valors per comparar

            SqlDataReader drProdCamp;
            drProdCamp = null;

            try
            {


                sqlCmdGetValorsProdCamp.Parameters["@sIdProducto"].Value = sProducteSel;
                sqlCmdGetValorsProdCamp.Parameters["@idCampanya"].Value = sIdCampanyaSel;
                sqlCmdGetValorsProdCamp.Transaction = sqlTran;
                drProdCamp = sqlCmdGetValorsProdCamp.ExecuteReader();
                Application.DoEvents();
            }
            catch (Exception ex)
            {
                drProdCamp.Close();
                sqlConn.Close();
                return "SeViolaMinimosPresentacion. Error: " + ex.Message;
            }

            if (drProdCamp.Read())
            {
                numMatsPC = int.Parse(drProdCamp[0].ToString());
                importNetPC = double.Parse(drProdCamp[1].ToString());
                importBrutPC = double.Parse(drProdCamp[2].ToString());
                descomptePC = double.Parse(drProdCamp[3].ToString());
            }

            drProdCamp.Close();

            //Si s'ha modificat la qty cal sumar totes les del grup. També cal recalcular si s'ha modificat el descompte
            for (int i = 0; i < dataGridViewLineas.Rows.Count; i++)
            {
                //---- GSG (13/01/2017) K_ZMKT
                //if (int.Parse(dataGridViewLineas.Rows[i].Cells["ColidCampanya"].Value.ToString()) == int.Parse(sIdCampanyaSel))
                if (dataGridViewLineas.Rows[i].Cells["ColTipoMat"].Value != null && dataGridViewLineas.Rows[i].Cells["ColTipoMat"].Value.ToString() != K_ZMKT && int.Parse(dataGridViewLineas.Rows[i].Cells["ColidCampanya"].Value.ToString()) == int.Parse(sIdCampanyaSel))
                {
                    sProducte = ObtenirProductoMaterial(dtLineasPedido.DefaultView[i]["sIdMaterial"].ToString(), sqlTran);
                    if (sProducte == sProducteSel)
                    {
                        double preuBrut = int.Parse(dataGridViewLineas.Rows[i].Cells["ColCantidad"].EditedFormattedValue.ToString()) * double.Parse(dataGridViewLineas.Rows[i].Cells["ColPrecio"].Value.ToString());
                        double desc = preuBrut * (double.Parse(dataGridViewLineas.Rows[i].Cells["ColDescuento"].EditedFormattedValue.ToString()) / 100);
                        double preu = preuBrut - desc;
                        importNetPCAcum += preu;
                        importBrutPCAcum += preuBrut;

                        iNumMatsSel += int.Parse(dataGridViewLineas.Rows[i].Cells["ColCantidad"].EditedFormattedValue.ToString());
                    }
                }
            }
            if (importBrutPC != 0) //mana el brut
            {
                if (importBrutPCAcum < importBrutPC)
                    ErrorMessage += String.Format("El importe bruto total ({0:C}) para esta presentación no puede ser menor que {1:C}." + '\n', importBrutPCAcum, importBrutPC);
            }
            else //mana el net
            {
                if (importNetPCAcum < importNetPC)
                    ErrorMessage += String.Format("El importe neto total ({0:C}) para esta presentación no puede ser menor que {1:C}." + '\n', importNetPCAcum, importNetPC);
            }

            //Un cop tenim els valors per comparar:
            double descLin = 0;
            if (iNumMatsSel < numMatsPC)
            {
                for (int i = 0; i < dataGridViewLineas.Rows.Count; i++)
                {
                    if (int.Parse(dataGridViewLineas.Rows[i].Cells["ColidCampanya"].Value.ToString()) == int.Parse(sIdCampanyaSel))
                    {
                        sProducte = ObtenirProductoMaterial(dtLineasPedido.DefaultView[i]["sIdMaterial"].ToString(), sqlTran);
                        if (sProducte == sProducteSel)
                        {
                            descLin = double.Parse(dataGridViewLineas.Rows[i].Cells["ColDescuento"].EditedFormattedValue.ToString());
                            if (descLin > descomptePC)
                            {
                                ErrorMessage += String.Format("En el producto {0} el descuento no puede ser superior a {1} si no hay un mínimo de {2} unidades en esta presentación.", sNomProducteSel, descomptePC, numMatsPC);
                                break;
                            }
                        }
                    }
                }
            } //Si passem del mínim ja no cal comprobar el descompte

            sqlTran.Commit();
            sqlConn.Close();

            return ErrorMessage;
        }

        //ATENCIÓN: la función SeViolaMinimosPresentacion es muy parecida
        //Si se hacen cambios quizá haya que replicarlos.
        private string SeViolaMinimosPresentacionAlBorrar(DataGridViewCellEventArgs e)
        {
            SqlTransaction sqlTran = null;
            if (sqlConn.State.ToString() == "Closed")
                sqlConn.Open();
            sqlTran = sqlConn.BeginTransaction();

            //Sabré quins materials he de sumar perquè tenen la mateixa campanya i producte (no material)
            string sIdCampanyaSel = dataGridViewLineas.Rows[e.RowIndex].Cells["ColIdCampanya"].Value.ToString();
            string sProducteSel = ObtenirProductoMaterial(dtLineasPedido.DefaultView[e.RowIndex]["sIdMaterial"].ToString(), sqlTran);
            string sProducte = "";
            string sNomProducteSel = dataGridViewLineas.Rows[e.RowIndex].Cells["ColProducto"].Value.ToString();
            double descompteSel = double.Parse(dataGridViewLineas.Rows[e.RowIndex].Cells["ColDescuento"].EditedFormattedValue.ToString());
            int iNumMatsSel = 0; //Cal acumular-hi totes les quantitats de la presentació, no sols la que s'està modificant

            int numMatsPC = 0;
            double importNetPC = 0, importNetPCAcum = 0;
            double importBrutPC = 0, importBrutPCAcum = 0;
            double descomptePC = 0;
            string ErrorMessage = "";

            //Del material seleccionat treiem els valors per comparar

            SqlDataReader drProdCamp;
            drProdCamp = null;

            try
            {
                sqlCmdGetValorsProdCamp.Parameters["@sIdProducto"].Value = sProducteSel;
                sqlCmdGetValorsProdCamp.Parameters["@idCampanya"].Value = sIdCampanyaSel;
                sqlCmdGetValorsProdCamp.Transaction = sqlTran;
                drProdCamp = sqlCmdGetValorsProdCamp.ExecuteReader();
                Application.DoEvents();
            }
            catch (Exception ex)
            {
                drProdCamp.Close();
                sqlConn.Close();
                return ex.Message;
            }

            if (drProdCamp.Read())
            {
                numMatsPC = int.Parse(drProdCamp[0].ToString());
                importNetPC = double.Parse(drProdCamp[1].ToString());
                importBrutPC = double.Parse(drProdCamp[2].ToString());
                descomptePC = double.Parse(drProdCamp[3].ToString());
            }

            drProdCamp.Close();

            //Si s'ha modificat la qty cal sumar totes les del grup. També cal recalcular si s'ha modificat el descompte
            for (int i = 0; i < dataGridViewLineas.Rows.Count; i++)
            {
                if (i != e.RowIndex) //No tenim en compte la que borrem
                {
                    //---- GSG (13/01/2017)
                    //if (int.Parse(dataGridViewLineas.Rows[i].Cells["ColidCampanya"].Value.ToString()) == int.Parse(sIdCampanyaSel))
                    if (dataGridViewLineas.Rows[i].Cells["ColTipoMat"].Value != null && dataGridViewLineas.Rows[i].Cells["ColTipoMat"].Value.ToString() != K_ZMKT && int.Parse(dataGridViewLineas.Rows[i].Cells["ColidCampanya"].Value.ToString()) == int.Parse(sIdCampanyaSel))
                    {
                        sProducte = ObtenirProductoMaterial(dtLineasPedido.DefaultView[i]["sIdMaterial"].ToString(), sqlTran);
                        if (sProducte == sProducteSel)
                        {
                            double preuBrut = int.Parse(dataGridViewLineas.Rows[i].Cells["ColCantidad"].EditedFormattedValue.ToString()) * double.Parse(dataGridViewLineas.Rows[i].Cells["ColPrecio"].Value.ToString());
                            double desc = preuBrut * (double.Parse(dataGridViewLineas.Rows[i].Cells["ColDescuento"].EditedFormattedValue.ToString()) / 100);
                            double preu = preuBrut - desc;
                            importNetPCAcum += preu;
                            importBrutPCAcum += preuBrut;

                            iNumMatsSel += int.Parse(dataGridViewLineas.Rows[i].Cells["ColCantidad"].EditedFormattedValue.ToString());
                        }
                    }
                }
            }

            if (importBrutPC != 0) //mana el brut
            {
                if (importBrutPCAcum < importBrutPC)
                    ErrorMessage += String.Format("El importe bruto total ({0:C}) para esta presentación no puede ser menor que {1:C}." + '\n', importBrutPCAcum, importBrutPC);
            }
            else //mana el net
            {
                if (importNetPCAcum < importNetPC)
                    ErrorMessage += String.Format("El importe neto total ({0:C}) para esta presentación no puede ser menor que {1:C}." + '\n', importNetPCAcum, importNetPC);
            }

            //Un cop tenim els valors per comparar:
            double descLin = 0;
            if (iNumMatsSel < numMatsPC)
            {
                for (int i = 0; i < dataGridViewLineas.Rows.Count; i++)
                {
                    if (i != e.RowIndex) //No tenim en compte la que borrem
                    {
                        if (int.Parse(dataGridViewLineas.Rows[i].Cells["ColidCampanya"].Value.ToString()) == int.Parse(sIdCampanyaSel))
                        {
                            sProducte = ObtenirProductoMaterial(dtLineasPedido.DefaultView[i]["sIdMaterial"].ToString(), sqlTran);
                            if (sProducte == sProducteSel)
                            {
                                descLin = double.Parse(dataGridViewLineas.Rows[i].Cells["ColDescuento"].EditedFormattedValue.ToString());
                                if (descLin > descomptePC)
                                {
                                    ErrorMessage += String.Format("En el producto {0} el descuento no puede ser superior a {1} si no hay un mínimo de {2} unidades en esta presentación.", sNomProducteSel, descomptePC, numMatsPC);
                                    break;
                                }
                            }
                        }
                    }
                }
            } //Si passem del mínim ja no cal comprobar el descompte

            sqlTran.Commit();
            sqlConn.Close();

            return ErrorMessage;
        }

        dsFormularios.ListaCampanyasRow GetCampanyaById(string IdCampanya)
        {
            DataRow[] rws = dsFormularios1.ListaCampanyas.Select(String.Format("idCampanya='{0}'", IdCampanya));
            if (rws.Length > 0)
                return (dsFormularios.ListaCampanyasRow)rws[0];
            else
                return null;
        }

        dsFormularios.ListaCampanyasCabeceraRow GetCampanyaCabeceraById(string IdCampanya)
        {
            return (dsFormularios.ListaCampanyasCabeceraRow)dsFormularios1.ListaCampanyasCabecera.Select(
                String.Format("idCampanya='{0}'", IdCampanya))[0];
        }


        //Valor del descuento máximo para las campañas de regalo especiales
        private float valorDescMaxRegaloEspecial(DataGridViewCellParsingEventArgs e)
        {
            string IdCampanya = dataGridViewLineas.Rows[e.RowIndex].Cells["ColIdCampanya"].Value.ToString();

            dsFormularios.ListaCampanyasRow row = GetCampanyaById(IdCampanya);
            return float.Parse(row.fDescImpNeto.ToString());
        }

        private bool esCampanyaRegaloEspecial(DataGridViewCellParsingEventArgs e)
        {
            bool bRet = false;

            string IdCampanya = dataGridViewLineas.Rows[e.RowIndex].Cells["ColIdCampanya"].Value.ToString();

            foreach (RegaloEspecial re in _lRegaloEspecial)
            {
                string codc = re.codCamp;

                if (IdCampanya == codc)
                {
                    bRet = true;
                    break;
                }
            }

            return bRet;
        }

        private string ObtenirProductoMaterial(string sIdMaterial)
        {
            string ret = "";

            SqlDataReader drPM;
            drPM = null;

            try
            {


                if (sqlConn.State.ToString() == "Closed")
                    sqlConn.Open();

                sqlCmdProductoMaterial.Parameters["@sIdMaterial"].Value = sIdMaterial;
                drPM = sqlCmdProductoMaterial.ExecuteReader();

                if (drPM.Read())
                {
                    ret = drPM["sIdProducto"].ToString();
                }


            }
            catch (Exception e)
            {
                Mensajes.ShowError(e.ToString());
            }
            finally
            {
            }

            drPM.Close();
            return ret;
        }

        private string ObtenirProductoMaterial(string sIdMaterial, SqlTransaction psqlTran)
        {
            string ret = "";

            SqlDataReader drPM;
            drPM = null;

            try
            {


                sqlCmdProductoMaterial.Transaction = psqlTran;

                sqlCmdProductoMaterial.Parameters["@sIdMaterial"].Value = sIdMaterial;
                drPM = sqlCmdProductoMaterial.ExecuteReader();

                if (drPM.Read())
                {
                    ret = drPM["sIdProducto"].ToString();
                }


            }
            catch (Exception e)
            {
                Mensajes.ShowError(e.ToString());
            }

            drPM.Close();
            return ret;
        }


        private string ObtenirGrupVencimentMaterial(string sIdMaterial)
        {
            string ret = "";

            SqlDataReader drGVM;
            drGVM = null;

            try
            {
                string idProd = ObtenirProductoMaterial(sIdMaterial);



                if (sqlConn.State.ToString() == "Closed")
                    sqlConn.Open();

                sqlCmdGrupoVencimientoMaterial.Parameters["@sIdProducto"].Value = idProd;
                sqlCmdGrupoVencimientoMaterial.Parameters["@sIdMaterial"].Value = sIdMaterial;

                drGVM = sqlCmdGrupoVencimientoMaterial.ExecuteReader();

                if (drGVM.Read())
                {
                    ret = drGVM["sIdSubProducto"].ToString();
                }


            }
            catch (Exception e)
            {
                Mensajes.ShowError(e.ToString());
            }
            finally
            {
            }

            drGVM.Close();
            return ret;
        }

        private string ObtenirRegioFarmacia(int iIdCliente)
        {
            string ret = "";

            SqlDataReader drDto;
            drDto = null;

            try
            {


                if (sqlConn.State.ToString() == "Closed")
                    sqlConn.Open();

                sqlCmdGetClientesSAP.Parameters["@iIdCliente"].Value = iIdCliente;
                drDto = sqlCmdGetClientesSAP.ExecuteReader();

                if (drDto.Read())
                {
                    ret = drDto["iIdProvincia"].ToString();
                }


            }
            catch (Exception e)
            {
                Mensajes.ShowError(e.ToString());
            }
            finally
            {
            }

            drDto.Close();
            return ret;
        }

        private string ObtenirTipoMat(string sIdMaterial, SqlTransaction psqlTran)
        {
            string ret = "";

            SqlDataReader drTM;
            drTM = null;

            try
            {


                sqlCmdTipoMat.Transaction = psqlTran;

                sqlCmdTipoMat.Parameters["@sIdMaterial"].Value = sIdMaterial;
                drTM = sqlCmdTipoMat.ExecuteReader();

                if (drTM.Read())
                {
                    if (drTM.GetValue(0) != null)
                        ret = drTM["sTipoMat"].ToString();
                    else
                        ret = "";
                }


            }
            catch (Exception e)
            {
                Mensajes.ShowError(e.ToString());
            }

            drTM.Close();
            return ret;
        }

        //---- GSG (13/09/2016)
        private List<QtyAccMark> ObtenirAccionsPed(string sIdPedido)
        {
            List<QtyAccMark> ret = new List<QtyAccMark>();

            SqlDataReader dr;
            dr = null;

            try
            {


                if (sqlConn.State.ToString() == "Closed")
                    sqlConn.Open();

                sqlCmdGetPedAcciones.Parameters["@sIdPedido"].Value = sIdPedido;
                dr = sqlCmdGetPedAcciones.ExecuteReader();

                while (dr.Read())
                {
                    QtyAccMark item = new QtyAccMark(dr["iIdAccion"].ToString(), int.Parse(dr["Unidades"].ToString()));
                    ret.Add(item);
                }


            }
            catch (Exception e)
            {
                Mensajes.ShowError(e.ToString());
            }
            finally
            {
            }

            dr.Close();
            return ret;
        }

        /*
        private string ObtenirAccionsPed(string sIdPedido)
        {
            string ret = "";

            try
            {
                SqlDataReader dr;

                if (sqlConn.State.ToString() == "Closed")
                    sqlConn.Open();

                sqlCmdGetPedAcciones.Parameters["@sIdPedido"].Value = sIdPedido;
                dr = sqlCmdGetPedAcciones.ExecuteReader();

                while (dr.Read())
                {
                    ret += (dr["iIdAccion"].ToString() + ",");
                }

                dr.Close();

                //if (ret.Length > 0)
                //    ret = ret.Substring(0, ret.Length - 1); //per treure la última coma
            }
            catch (Exception e)
            {
                Mensajes.ShowError(e.ToString());
            }
            finally
            {
            }

            return ret;
        }
        */

        private int ObtenirMaterialsNoRentabilitat()
        {
            string mat = "";
            int comptador = 0;
            SqlDataReader dr;
            dr = null;

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


                sqlCmdGetMaterialesNoRentabilidad.Parameters["@sIdPedido"].Value = sIdPedido;

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


            }
            catch (Exception e)
            {
                Mensajes.ShowError(e.ToString());
            }

            dr.Close();
            return comptador;
        }

        //----GSG (29/09/2020) PUNTOS
        private int ObtenirMaterialsNoMargen()
        {
            string mat = "";
            int comptador = 0;
            SqlDataReader dr;
            dr = null;

            try
            {
                if (sqlConn.State.ToString() == "Closed")
                    sqlConn.Open();

                lMatsNoMargen = new string[5000];

                if (System.Configuration.ConfigurationManager.AppSettings["TipoDelegadoPedidosCentral"].ToString() == Comun.K_CECL)
                    sqlCmdGetMaterialesNoMargen.CommandText = "[GetMaterialesNoMargenCECL]";
                else
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


            }
            catch (Exception e)
            {
                Mensajes.ShowError(e.ToString());
            }

            dr.Close();
            return comptador;
        }


        //Hi haurà campanyes que no influiran en el càlcul de la rendabilitat de la comanda
        private int ObtenirCampanyasNoRentabilitat()
        {
            string camp = "";
            int comptador = 0;
            SqlDataReader dr;
            dr = null;

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


            }
            catch (Exception e)
            {
                Mensajes.ShowError(e.ToString());
            }

            dr.Close();
            return comptador;
        }

        private double GetDescuentoMayoristaClub()
        {
            double ret = 0.0;
            bool trobat = false;
            SqlDataReader dr;

            try
            {
                if (sqlConn.State.ToString() == "Closed")
                    sqlConn.Open();

                for (int i = 0; i < 5; i++) //hi ha com a molt 5 garantíes
                {
                    if (garanties[i] != "" && garanties[i] != null)
                    {
                        sqlCmdGetDescuentoMayoristaClub.Parameters["@iIdDestinatario"].Value = this.iIdDestinatario;
                        sqlCmdGetDescuentoMayoristaClub.Parameters["@sGarantias"].Value = garanties[i];
                        dr = sqlCmdGetDescuentoMayoristaClub.ExecuteReader();

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ret = double.Parse(dr["fDescMayAvanzado"].ToString());
                                trobat = true;
                                dr.Close();
                                break;
                            }
                        }
                        dr.Close();
                    }
                    if (trobat) break;
                }
            }
            catch (Exception e)
            {
                Mensajes.ShowError(e.ToString());
            }


            return ret;
        }

        private DateTime ObtenirFechaVencimientoPedido()
        {
            DateTime dFecha = DateTime.MinValue;
            SqlDataReader dr;
            dr = null;

            try
            {
                if (sqlConn.State.ToString() == "Closed")
                    sqlConn.Open();

                dr = sqlCmdGetFechaVencimiento.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        dFecha = DateTime.Parse(dr["dFecha"].ToString());
                    }
                }


            }
            catch (Exception e)
            {
                Mensajes.ShowError(e.ToString());
            }

            dr.Close();
            return dFecha;
        }

        private void guardarDatosTempFechaVencimiento()
        {
            try
            {
                if (sqlConn.State.ToString() == "Closed")
                    sqlConn.Open();

                sqlCmdDelCondicionesComercialesTemp.ExecuteNonQuery();

                foreach (ArrayList lin in _taulaTotalsProd)
                {
                    sqlCmdSetCondicionesComercialesTemp.Parameters["@sIdSubProducto"].Value = lin[0].ToString();
                    sqlCmdSetCondicionesComercialesTemp.Parameters["@iIdProvincia"].Value = int.Parse(lin[1].ToString());
                    sqlCmdSetCondicionesComercialesTemp.Parameters["@iUnidades"].Value = int.Parse(lin[2].ToString());
                    sqlCmdSetCondicionesComercialesTemp.Parameters["@fImporte"].Value = double.Parse(lin[3].ToString());
                    sqlCmdSetCondicionesComercialesTemp.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                Mensajes.ShowError(e.ToString());
            }
        }

        private void calculaFechaVencimiento()
        {
            _taulaTotalsProd.Clear();

            foreach (DataGridViewRow dr in dataGridViewLineas.Rows)
            {
                // Carreguem la taula temporal amb les dades necessàries per calcular la data de venciment
                // Valors de la línia

                string sProd = ObtenirGrupVencimentMaterial(dr.Cells["sIdMaterialDataGridViewTextBoxColumn"].Value.ToString());

                if (sProd != "")
                {
                    string sProv = ObtenirRegioFarmacia(iIdCliente);
                    int iIdProvincia = 0;
                    if (sProv != "") iIdProvincia = int.Parse(sProv);

                    int iUnidades = int.Parse(dr.Cells["ColCantidad"].Value.ToString());
                    double fImporte = double.Parse(dr.Cells["ColPrecio"].Value.ToString()) * int.Parse(dr.Cells["ColCantidad"].Value.ToString());

                    int result = _taulaTotalsProd.FindIndex(
                        delegate (ArrayList lin)
                        {
                            return lin.IndexOf(sProd) > -1;
                        }
                    );

                    //Valors totals
                    if (result == -1) // és nou      
                    {
                        ArrayList linTotalsProd = new ArrayList();
                        linTotalsProd.Clear();

                        linTotalsProd.Add(sProd);
                        linTotalsProd.Add(iIdProvincia);
                        linTotalsProd.Add(iUnidades);
                        linTotalsProd.Add(fImporte);

                        _taulaTotalsProd.Add(linTotalsProd);
                    }
                    else // existeix --> acumula valors
                    {
                        _taulaTotalsProd[result][2] = (int)_taulaTotalsProd[result][2] + iUnidades;
                        _taulaTotalsProd[result][3] = (double)_taulaTotalsProd[result][3] + fImporte;
                    }
                }
            }

            Application.DoEvents();

            try
            {
                //Insereix els valors a la taula temporal en BD
                guardarDatosTempFechaVencimiento();

                //Obté la data de venciment
                DateTime dataV = dtpFechaVenci.MinDate;
                dataV = ObtenirFechaVencimientoPedido();
                if (dataV == DateTime.MinValue)
                {
                    dataV = dtpFechaVenci.MinDate;
                    dtpFechaVenci.Enabled = false;
                }
                else
                {
                    if (!_bDataVencCanviada)
                        dtpFechaVenci.Text = dataV.ToString().Substring(0, 10);
                    else
                    {
                        dtpFechaVenci.Text = _sDataVencCanviada;
                        Mensajes.ShowInformation(String.Format("El cálculo de la fecha de vencimiento según los materiales seleccionados ({0}) es distinta a la introducida manualmente ({1}). No se almacenará la fecha calculada puesto que prevalece la fecha indicada de forma manual.", dataV.ToString().Substring(0, 10), _sDataVencCanviada));
                    }

                    dtpFechaVenci.Enabled = true;
                }
            }
            catch (Exception ex)
            {
            }
        }

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


        //---- GSG (05/07/2017)
        /*
        private bool FormatBuscarCampanyas(int cliente, bool activo, string tipoPed)
        {
            bool bEsClienteConAccMark_Ant = _bEsClienteConAccMark;
            bool bRet = false;
            bool bConCampanyas = true; 

            _bEsClienteConAccMark = false;

            string sIdCampCab = "-1";
            if (cboTipoCampana.SelectedValue != null)
                sIdCampCab = cboTipoCampana.SelectedValue.ToString();

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

                    bConCampanyas = LlenarComboCampanyas(1, campanyas, tipoPed);                    

                    _bEsClienteConAccMark = true;
                }
                else
                    bConCampanyas = LlenarComboCampanyas(2, "-1", sIdCampCab, tipoPed);
            }
            else
                bConCampanyas = LlenarComboCampanyas(0, "-1", sIdCampCab, tipoPed);

            if (bConCampanyas)
            {
                cBoxCampanyas.Enabled = activo;
                btnBuscarMaterial.Enabled = activo;

                if (bEsClienteConAccMark_Ant != _bEsClienteConAccMark)
                    bRet = true;

                if (!bRet && cBoxCampanyas.Items.Count == 1)
                    bRet = true;

                _sTipoSumaUnidades = cBoxCampanyas.SelectedValue.ToString();
            }
            else 
            {
                cBoxCampanyas.Enabled = false;
                btnBuscarMaterial.Enabled = cBoxCampanyas.Enabled;
            }

            return bRet;
        }
        */


        private bool FormatBuscarCampanyas(int cliente, bool activo, string tipoPed, string mayorista)
        {
            bool bRet = false;
            bool bConCampanyas = true;

            if (!Comun.IsInTheArray(cboTipoPedido.SelectedValue.ToString(), Configuracion.asPedTransfer) || mayorista == "")
                mayorista = "XXXX";

            bConCampanyas = LlenarComboCampanyas(iIdDelegado.ToString(), tipoPed, cliente, mayorista);

            if (bConCampanyas)
            {
                cBoxCampanyas.Enabled = activo;
                btnBuscarMaterial.Enabled = activo;

                _sTipoSumaUnidades = cBoxCampanyas.SelectedValue.ToString();
            }
            else
            {
                cBoxCampanyas.Enabled = false;
                btnBuscarMaterial.Enabled = cBoxCampanyas.Enabled;
            }

            return bRet;
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

        private float Calcular_Rentabilidad_Anual(bool bMasPedidoEnCurso)
        {
            float rentabilitat = 0.0F;
            float denominador = 0.0F;
            float brutoLinsArrastre = 0.0F;

            //Obtener datos 
            dtLineasPedidoRentAnual = new dsMateriales.ListaLineasPedidoRentAnualDataTable();
            dsMateriales1.ListaLineasPedidoRentAnual.Rows.Clear();
            sqldaListaLineasPedidoRentAnual.SelectCommand.Parameters["@iIdCliente"].Value = iIdCliente;
            Application.DoEvents();
            sqldaListaLineasPedidoRentAnual.Fill(dtLineasPedidoRentAnual);
            Application.DoEvents();

            //Calclular rentabilidad
            //dtLineasPedidoRentAnual contiene todas las líneas a tener en cuenta (la consulta ya ha excluido las que no, también las de arrastre)

            // Si un pedido estaba grabado previamente y no sincronizado, tenemos que eliminar las líneas de dtLineasPedidoRentAnual 
            // cuando bMasPedidoEnCurso antes de calcular la rentabilidad para que no las cuente dos veces
            // También hay que hacerlo para los arrastre //---- GSG (30/03/2016)
            if (bMasPedidoEnCurso && sIdPedido != null && sIdPedido != "" && sIdPedido != "-1")
            {
                for (int i = dtLineasPedidoRentAnual.Rows.Count - 1; i >= 0; i--)
                {
                    if (dtLineasPedidoRentAnual.Rows[i]["sIdPedido"].ToString() == sIdPedido)
                        dtLineasPedidoRentAnual.DefaultView.Delete(i);
                }

                for (int i = dtLineasPedidoRentAnualArrastre.Rows.Count - 1; i >= 0; i--)
                {
                    if (dtLineasPedidoRentAnualArrastre.Rows[i]["sIdPedido"].ToString() == sIdPedido)
                        dtLineasPedidoRentAnualArrastre.DefaultView.Delete(i);
                }

            }


            for (int i = 0; i < dtLineasPedidoRentAnual.Rows.Count; i++)
            {
                if (dtLineasPedidoRentAnual.Rows[i].RowState != DataRowState.Deleted)
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
            }

            // Líneas pertenecientes a campañas arrastre (Ej. POLIMEDICADOS VENTA)
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

            if (bMasPedidoEnCurso)
            {
                int lin = 0;
                foreach (DataGridViewRow row in dataGridViewLineas.Rows)
                {
                    // Si la campaña es arrastre la rentabilidad de la línea será negativa.
                    // Pondremos poner el bruto de la línea en el descuento y el bruto a 0 en el cálculo de la rentabilidad
                    // Primero calculamos la rentabilidad como siempre para todas las líneas que no són bArrastre 
                    // Después sumaremos el bruto de todas las líneas de arrastre i lo restaremos al numerador al final (porque en el númerador restamos el descuento al bruto i estamos tomando el bruto como el descuento en estas líneas)
                    // en el denominador no cuentan porque es la suma del bruto

                    // En el pedido en curso hay que determinar la campanya de cada línia para saber cómo será el calculo de la rentabilidad
                    //---- GSG (08/01/2018)
                    //if (!Comun.IsInTheArray(row.Cells["ColidCampanya"].Value.ToString(), _lCampanyasNoRenta)) 
                    if (!Comun.IsInTheArray(row.Cells["ColidCampanya"].Value.ToString(), _lCampanyasNoRenta) && !Comun.IsInTheArray(row.Cells["sIdMaterialDataGridViewTextBoxColumn"].Value.ToString().Trim(), lMatsNoRenta))
                    {
                        int iCantidad = int.Parse(row.Cells["ColCantidad"].Value.ToString());
                        float fPrecio = float.Parse(row.Cells["ColPrecio"].Value.ToString());

                        if (!EsArrastre(lin))
                        {
                            float fDescuento = float.Parse(row.Cells["ColDescuento"].Value.ToString());
                            float fCoste = -1;
                            if (row.Cells["fCosteDataGridViewTextBoxColumn"].Value != DBNull.Value)
                                fCoste = float.Parse(row.Cells["fCosteDataGridViewTextBoxColumn"].Value.ToString());

                            rentabilitat += DameNominadorRentabilidad(iCantidad, fPrecio, fDescuento, fCoste);
                            denominador += DameDenominadorRentabilidad(iCantidad, fPrecio);
                        }
                        else
                            brutoLinsArrastre += (iCantidad * fPrecio);
                    }

                    lin++;
                }
            }


            float res = 0.0F;
            if (denominador != 0)   //Aquest cas donaria -Infinity 
                res = ((rentabilitat - brutoLinsArrastre) / denominador) * 100.0F;

            return res;
        }

        private int GetAccsMarkADescartar(string seleccio)
        {
            int ret = 0;
            SqlDataReader dr;
            dr = null;

            try
            {
                if (sqlConn.State.ToString() == "Closed")
                    sqlConn.Open();

                sqlGetNumAcckMarkADescartar.Parameters["@codsAccMark"].Value = seleccio;
                dr = sqlGetNumAcckMarkADescartar.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ret = int.Parse(dr[0].ToString());
                        break;
                    }
                }


            }
            catch (Exception e)
            {
                Mensajes.ShowError(e.ToString());
            }

            dr.Close();
            return ret;
        }

        private float GetRentMinCampCab(string sIdCampCab)
        {
            float ret = 0;
            SqlDataReader dr;
            dr = null;

            try
            {

                if (sqlConn.State.ToString() == "Closed")
                    sqlConn.Open();

                sqlGetRentMinCampCab.Parameters["@idCampanya"].Value = sIdCampCab;
                dr = sqlGetRentMinCampCab.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ret = float.Parse(dr[0].ToString());
                        break;
                    }
                }


            }
            catch (Exception e)
            {
                Mensajes.ShowError(e.ToString());
            }

            dr.Close();
            return ret;
        }

        private float GetRentMinCamp(string sIdCamp)
        {
            float ret = 0;
            SqlDataReader dr;
            dr = null;

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

        private bool GetListaAvisoUVM(int delegado, int cliente, DateTime fec)
        {
            bool bRet = false;

            if (sqlConn.State.ToString() == "Closed")
                sqlConn.Open();

            this.dsMateriales1.ListaAvisoMUV.Rows.Clear();

            this.sqldaListaAvisoMUV.SelectCommand.Parameters["@iIdDelegado"].Value = delegado;
            this.sqldaListaAvisoMUV.SelectCommand.Parameters["@iIdCliente"].Value = cliente;
            this.sqldaListaAvisoMUV.SelectCommand.Parameters["@dFec"].Value = fec;

            this.sqldaListaAvisoMUV.Fill(this.dsMateriales1);

            if (this.dsMateriales1.ListaAvisoMUV.Rows.Count > 0)
                bRet = true;

            return bRet;
        }

        private dsMateriales.ListaMinUniVenRow GetValorUVM(string sIdMaterial, int iIdCliente, DateTime fec) //this.txtClienteSAP.Text.ToString()
        {
            dsMateriales.ListaMinUniVenRow row = null;

            try
            {
                dsMateriales1.ListaMinUniVen.Rows.Clear();

                sqldaListaMUV.SelectCommand.Parameters["@sIdMaterial"].Value = sIdMaterial;
                sqldaListaMUV.SelectCommand.Parameters["@iIdCliente"].Value = iIdCliente;
                sqldaListaMUV.SelectCommand.Parameters["@dFec"].Value = fec;
                sqldaListaMUV.SelectCommand.Parameters["@iEstado"].Value = 0;

                this.sqldaListaMUV.Fill(this.dsMateriales1);

                if (dsMateriales1.ListaMinUniVen.Rows.Count > 0)
                    row = (dsMateriales.ListaMinUniVenRow)dsMateriales1.ListaMinUniVen.Rows[0];
            }
            catch (Exception e)
            {
                Mensajes.ShowError(e.ToString());
            }

            return row;
        }


        // Buscar la llista dels materials MUV amb el mínim i el total de les comandes en el període
        // Modificar els total de la llista si el material de la comanda en curs hi és i/o si hi és el producte al que pertany
        // piModo = 0 --> Mostrar avís i donar possibilitat de guardar o bé de continuar fent la comanda abans de guardar.
        //                  Retorna true si guardar , false si no guardar (guardar comanda)
        // piModo = 1 --> Mostrar avís 2 i acceptar (canvi client)
        //                  El retorno no tiene importancia

        private bool AvisoUVM(int piModo)
        {
            bool bSalida = true;
            bool ret = GetListaAvisoUVM(iIdDelegado, iIdCliente, DateTime.Today);

            if (ret) //Hay materiales y/o productos en MUV
            {
                // A la llista tenim els materials de MUV amb el mínimi i el total de les comandes en el període 

                //Pueden darse tres casos:
                //1.- Pedido nuevo: línea no está en Pedidos_Lin --> Sumar la cantidad de la lin actual a material/producto
                //2.- Pedido existente:  
                //  2.1.- La linia es nueva en el pedido --> Sumar la cantidad de la lin actual a material/producto 
                //  2.2.- La línea existia en el pedido --> Restar la cantidad original y sumar la nueva a material/producto

                foreach (DataGridViewRow row in dataGridViewLineas.Rows)
                {
                    //material del pedido
                    string mat = row.Cells["sIdMaterialDataGridViewTextBoxColumn"].Value.ToString();
                    //Obtener producto del material
                    string prod = ObtenirProductoMaterial(mat);

                    //Obtner la cantidad original del material en el pedido (si existía)
                    int qtyOriginal = 0;
                    if (_tMatQtyOriginal.Count > 0 && _iClientOriginal == this.iIdCliente) //El pedido no es nuevo i pertenece al mismo cliente (no cambiado)
                    {
                        QtyMat qm = _tMatQtyOriginal.Find(delegate (QtyMat qm1) { return qm1.sIdMaterial == mat; });
                        if (qm != null)
                            qtyOriginal = qm.iCantidad;
                    }

                    //Obtener la cantidad actual del material en el pedido
                    int qtyComanda = int.Parse(row.Cells["ColCantidad"].Value.ToString());

                    //Material en lista?
                    string[] claus = new string[2];
                    claus[0] = "";
                    claus[1] = mat;
                    dsMateriales.ListaAvisoMUVRow rowMat = (dsMateriales.ListaAvisoMUVRow)dsMateriales1.ListaAvisoMUV.Rows.Find(claus);
                    if (rowMat != null)
                    {
                        int index = dsMateriales1.ListaAvisoMUV.Rows.IndexOf(rowMat);
                        //Sumar la cantidad del pedido actual a material y en caso de que ya tubiera un valor, restarlo primero
                        dsMateriales1.ListaAvisoMUV.Rows[index].SetField("sumaCantidad", rowMat.sumaCantidad - qtyOriginal + qtyComanda);
                    }

                    //Producto en lista?                    
                    claus[0] = prod;
                    claus[1] = "";
                    dsMateriales.ListaAvisoMUVRow rowProd = (dsMateriales.ListaAvisoMUVRow)dsMateriales1.ListaAvisoMUV.Rows.Find(claus);
                    if (rowProd != null)
                    {
                        int index = dsMateriales1.ListaAvisoMUV.Rows.IndexOf(rowProd);
                        dsMateriales1.ListaAvisoMUV.Rows[index].SetField("sumaCantidad", rowProd.sumaCantidad - qtyOriginal + qtyComanda);
                    }
                }

                //Si algún material o producto no cumple los mínimos lo mostraremos en el mensaje de aviso
                //Construcción del mensaje
                string msgPart1 = " Tenga en cuenta las siguientes recomendaciones:" + Environment.NewLine + Environment.NewLine;
                msgPart1 += " Producto o Material".PadRight(39, ' ') + "   " + "Mínimo".PadLeft(8, ' ') + "   " + "Cantidad".PadLeft(8, ' ') + "   " + "Observaciones".PadRight(50, ' ') + Environment.NewLine;
                msgPart1 += "-".PadRight(131, '-') + Environment.NewLine;
                string msgPart2 = "";
                string msgPart3 = Environment.NewLine + " ¿Desea guardar el pedido igualmente?";

                //Limpia la tabla UltimosAvisos
                sqlCmdSetUltimosAvisos.Parameters["@iAccion"].Value = 2;
                sqlCmdSetUltimosAvisos.ExecuteNonQuery();


                foreach (dsMateriales.ListaAvisoMUVRow aviso in dsMateriales1.ListaAvisoMUV.Rows)
                {
                    if (aviso.iMinQty > aviso.sumaCantidad)
                    {
                        //Sols agafem els que no compleixen
                        msgPart2 += ' ';
                        if (aviso.sDescProducto.Trim() == "")
                            msgPart2 += aviso.sMaterial.PadRight(39, ' ').Substring(0, 39) + "   ";
                        else
                            msgPart2 += aviso.sDescProducto.PadRight(39, ' ').Substring(0, 39) + "   ";

                        msgPart2 += aviso.iMinQty.ToString().PadLeft(8, ' ') + "   ";
                        msgPart2 += aviso.sumaCantidad.ToString().PadLeft(8, ' ') + "   ";
                        if (piModo == 1) //Cambio cliente
                            msgPart2 += aviso.sObservaciones.PadRight(50, ' ');
                        else if (piModo == 0) //Guardar pedido
                            msgPart2 += aviso.sObservaciones2.PadRight(50, ' ');
                        msgPart2 += Environment.NewLine;

                        //Inserta el aviso en la tabla UltimosAvisos
                        sqlCmdSetUltimosAvisos.Parameters["@iAccion"].Value = 0;
                        sqlCmdSetUltimosAvisos.Parameters["@sIdProducto"].Value = aviso.sIdProducto;
                        sqlCmdSetUltimosAvisos.Parameters["@sDescripcion"].Value = aviso.sDescProducto;
                        sqlCmdSetUltimosAvisos.Parameters["@sIdMaterial"].Value = aviso.sIdMaterial;
                        sqlCmdSetUltimosAvisos.Parameters["@sMaterial"].Value = aviso.sMaterial;
                        sqlCmdSetUltimosAvisos.ExecuteNonQuery();
                    }
                }

                if (msgPart2.Length > 0) //Sólo mostrar mensaje si hay líneas que no cumplen
                {
                    if (piModo == 0)
                    {
                        if (Mensajes.ShowQuestion(msgPart1 + msgPart2 + msgPart3, true) == DialogResult.No)
                            bSalida = false;
                    }
                    else //if (piModo == 1)
                        Mensajes.ShowInformation(msgPart1 + msgPart2, true);
                }
            }

            return bSalida;
        }

        private void GetLineasPedidoOriginal()
        {
            // Guarda la cantidad actual després de grabar per a tenir-la actualitzada com a original si no sortim del formulari i continuem modificant
            _tMatQtyOriginal.Clear();

            foreach (dsMateriales.ListaLineasPedidoRow row in dtLineasPedido)
            {
                _tMatQtyOriginal.Add(new QtyMat(row.sIdMaterial, int.Parse(row.iCantidad.ToString())));
            }

            _iClientOriginal = this.iIdCliente;
        }

        private string GetDescuentoMaximoMaterial(string sIdMaterial, string tipoPedido, int iIdMayorista)
        {
            string sRet = "0";

            try
            {
                DataTable dtDescMax = new DataTable();

                sqlSelectListaDescMax.Parameters["@iIdCliente"].Value = iIdMayorista;
                sqlSelectListaDescMax.Parameters["@sIdCliente"].Value = null;
                sqlSelectListaDescMax.Parameters["@sNombre"].Value = null;
                sqlSelectListaDescMax.Parameters["@sIdMaterial"].Value = sIdMaterial;
                sqlSelectListaDescMax.Parameters["@sMaterial"].Value = null;
                sqlSelectListaDescMax.Parameters["@iEstado"].Value = 0;

                sqldaDescMax.Fill(dtDescMax);

                if (dtDescMax.Rows.Count > 0)
                {
                    DataRow dr = dtDescMax.NewRow();
                    dr = dtDescMax.Rows[0];

                    sRet = dr["fDescuentoMaximo"].ToString();
                }
                else
                {
                    // Si el mayorista no está en la tabla cogemos el descuento como antes (lo indicamos con -1)
                    sRet = "-1";
                }
            }
            catch (Exception e)
            {
                string err = e.Message;
            }


            return sRet;
        }

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

        private void guardarEmailsCliente(int piIdCliente)
        {
            try
            {
                if (sqlConn.State.ToString() == "Closed")
                    sqlConn.Open();

                sqlCmdSetEmailsCliente.Parameters["@iIdCliente"].Value = piIdCliente;
                sqlCmdSetEmailsCliente.Parameters["@dFecha"].Value = DateTime.Today;
                sqlCmdSetEmailsCliente.Parameters["@sEmailConf"].Value = txtMailConf.Text.Trim();
                sqlCmdSetEmailsCliente.Parameters["@sEmailFact"].Value = txtMailFact.Text.Trim();

                sqlCmdSetEmailsCliente.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Mensajes.ShowError(e.ToString());
            }
        }

        //Retorna true si todos están tratado, si el primero es false es que no lo están todos (sólo el primero puede ser no tratado)
        //---- GSG (24/10/2019) También se puede modificar si si no está tratado y no se ha enviado a central 
        //private bool EmailsTratados(int piIdCliente, out string oEmailConf, out string oEmailFact, out bool oExiste)
        private bool EmailsTratados(int piIdCliente, out string oEmailConf, out string oEmailFact, out bool oExiste, out bool oEnviadoCEN)
        {
            bool bTratado = true; //Si no hay ningún registro tratar como si estubieran tratados
            oEmailConf = "";
            oEmailFact = "";
            oExiste = false;
            oEnviadoCEN = false; //---- GSG (24/10/2019) 

            this.dsClientes1.ListaEmailsCliente.Rows.Clear();

            //---- GSG CECL 19/05/2016
            if (System.Configuration.ConfigurationManager.AppSettings["TipoDelegadoPedidosCentral"].ToString() == Comun.K_CECL)
                sqldaListaEmailsCliente.SelectCommand.CommandText = "[ListaEmailsClienteCECL]";
            else
                sqldaListaEmailsCliente.SelectCommand.CommandText = "[ListaEmailsCliente]";
            //---- FI GSG CECL

            sqldaListaEmailsCliente.SelectCommand.Parameters["@iIdCliente"].Value = piIdCliente;

            this.sqldaListaEmailsCliente.Fill(this.dsClientes1.ListaEmailsCliente);

            if (this.dsClientes1.ListaEmailsCliente.Rows.Count > 0)
            {
                GESTCRM.Formularios.DataSets.dsClientes.ListaEmailsClienteRow row = (GESTCRM.Formularios.DataSets.dsClientes.ListaEmailsClienteRow)dsClientes1.ListaEmailsCliente.Rows[0];
                bTratado = row.bTratado;
                oEmailConf = row.sEmailConf;
                oEmailFact = row.sEmailFact;
                oEnviadoCEN = row.bEnviadoCEN; //---- GSG (24/10/2019) 
                oExiste = true;
            }

            return bTratado;
        }

        private void guardarRetenido(string psIdPedido, bool pbRetenido, int piIdDelegado)
        {
            try
            {
                if (sqlConn.State.ToString() == "Closed")
                    sqlConn.Open();

                sqlCmdSetRetenido.Parameters["@sIdPedido"].Value = psIdPedido;
                sqlCmdSetRetenido.Parameters["@bRetenido"].Value = pbRetenido;
                sqlCmdSetRetenido.Parameters["@iIdDelegado"].Value = piIdDelegado;


                sqlCmdSetRetenido.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Mensajes.ShowError(e.ToString());
            }
        }

        private bool GetRetenido(string psIdPedido)
        {
            bool ret = false;
            SqlDataReader dr;
            dr = null;

            try
            {

                if (sqlConn.State.ToString() == "Closed")
                    sqlConn.Open();

                sqlGetRetenido.Parameters["@sIdPedido"].Value = psIdPedido;
                dr = sqlGetRetenido.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ret = bool.Parse(dr[0].ToString());
                        break;
                    }
                }


            }
            catch (Exception e)
            {
                Mensajes.ShowError(e.ToString());
            }

            dr.Close();
            return ret;
        }

        private string GetProgramaInformatico(int piIdCliente)
        {
            string sRet = "";

            this.dsClientes1.ListaProgInf_porCliente_SAP.Rows.Clear();

            this.sqldaListaProgInfCliente_SAP.SelectCommand.Parameters["@iIdCliente"].Value = piIdCliente;
            this.sqldaListaProgInfCliente_SAP.Fill(this.dsClientes1);

            if (this.dsClientes1.ListaProgInf_porCliente_SAP.Rows.Count > 0)
            {
                GESTCRM.Formularios.DataSets.dsClientes.ListaProgInf_porCliente_SAPRow row = (GESTCRM.Formularios.DataSets.dsClientes.ListaProgInf_porCliente_SAPRow)dsClientes1.ListaProgInf_porCliente_SAP.Rows[0];
                sRet = row.sNombre;
            }

            return sRet;
        }

        //---- GSG (02/02/2021)
        //private double GetImporteMedioPedidos(int piIdCliente, DateTime pdFecIni, DateTime pdFecFin)
        private double GetImporteMedioPedidos(int piIdCliente, DateTime pdFecIni, DateTime pdFecFin, out double fNeto, out double fPuntos)
        {
            double fRet = 0;
            //---- GSG (02/02/2021)
            double fRet2 = 0;
            double fRet3 = 0;

            if (sqlConn.State == ConnectionState.Closed)
                this.sqlConn.Open();

            SqlTransaction sqlTran = this.sqlConn.BeginTransaction();

            this.sqlGetImporteMedioPedido.Transaction = sqlTran;

            try
            {
                this.sqlGetImporteMedioPedido.Parameters["@iIdCliente"].Value = piIdCliente;
                this.sqlGetImporteMedioPedido.Parameters["@dFechaIni"].Value = pdFecIni;
                this.sqlGetImporteMedioPedido.Parameters["@dFechaFin"].Value = pdFecFin;

                this.sqlGetImporteMedioPedido.ExecuteNonQuery();

                fRet = double.Parse(this.sqlGetImporteMedioPedido.Parameters["@Ret"].Value.ToString()); // Bruto

                //---- GSG (02/02/2021)
                fRet2 = double.Parse(this.sqlGetImporteMedioPedido.Parameters["@Ret2"].Value.ToString()); // Neto
                fRet3 = double.Parse(this.sqlGetImporteMedioPedido.Parameters["@Ret3"].Value.ToString()); // Puntos

            }
            catch (Exception e)
            {
                Mensajes.ShowError(e.Message);
            }

            this.sqlConn.Close();

            //---- GSG (02/02/2021)
            fNeto = fRet2;
            fPuntos = fRet3;


            return fRet;
        }

        private void ActualizarImporteMedioPedido(int piIdCliente)
        {
            DateTime hoy = DateTime.Today;
            DateTime dFecIni = Comun.calculaFechaIni(hoy);
            DateTime dFecFin = DateTime.Parse(DateTime.DaysInMonth(hoy.Year, hoy.Month).ToString() + "/" + hoy.Month.ToString() + "/" + hoy.Year.ToString());

            //---- GSG (02/02/2021)
            //txtImpMedio.Text = GetImporteMedioPedidos(this.iIdCliente, dFecIni, dFecFin).ToString("0.##");
            double netoMedio = 0;
            double puntosMedio = 0;
            txtImpMedio.Text = GetImporteMedioPedidos(this.iIdCliente, dFecIni, dFecFin, out netoMedio, out puntosMedio).ToString("0.##");
            txtImpMedioNeto.Text = netoMedio.ToString("0.##");
            txtMediaPuntos.Text = puntosMedio.ToString("0.##");
        }

        private void ActivarComboCondicionesPago()
        {
            if (Comun.IsInTheArray(cboTipoPedido.SelectedValue.ToString(), Configuracion.asPedTransfer) || cboTipoPedido.SelectedValue.ToString() == "ZCR") //Tranfer o abono o ZLOG (compromiso)
            {
                if (cboTipoPedido.SelectedValue.ToString() == "ZLOG")
                {
                    lblCondPago.Visible = true;
                    cboCondicionPago.Visible = true;

                    lblFechaFacturacion.Visible = false;
                    dtpFechaFacturacion.Visible = false;

                    // ---- GSG (11/11/2016)                    
                    lblCodPagoFija.Visible = false;
                    txbCodPagoFija.Visible = false;
                }
                else
                {
                    lblCondPago.Visible = false;
                    cboCondicionPago.Visible = false;

                    lblFechaFacturacion.Visible = false;
                    dtpFechaFacturacion.Visible = false;

                    // ---- GSG (11/11/2016)      
                    if (cboTipoPedido.SelectedValue.ToString() == "ZTRA" && _sCodPagoFija != "")
                    {
                        lblCodPagoFija.Visible = true;
                        txbCodPagoFija.Visible = true;
                    }
                    else // factura depósito, abono y envío producto
                    {
                        lblCodPagoFija.Visible = false;
                        txbCodPagoFija.Visible = false;
                    }
                }

                // NOTA Para transfers no tiene sentido la condición de pago fija
                // ---- GSG (11/11/2016)
                // Aunque no tenga sentido, a partir de ahora parece que debe poder salir en algún caso
                //lblCodPagoFija.Visible = false;
                //txbCodPagoFija.Visible = false;
            }
            else // SI DIR 
            {
                if (_bVerCondPago)
                {
                    lblCondPago.Visible = true;
                    cboCondicionPago.Visible = true;

                    lblFechaFacturacion.Visible = false;
                    dtpFechaFacturacion.Visible = false;

                    lblCodPagoFija.Visible = false;
                    txbCodPagoFija.Visible = false;
                }
                else
                {
                    lblCondPago.Visible = false;
                    cboCondicionPago.Visible = false;

                    if (_sCodPagoFija == "")
                    {
                        lblFechaFacturacion.Visible = true;
                        dtpFechaFacturacion.Visible = true;

                        lblCodPagoFija.Visible = false;
                        txbCodPagoFija.Visible = false;
                    }
                    else
                    {
                        lblFechaFacturacion.Visible = false;
                        dtpFechaFacturacion.Visible = false;

                        lblCodPagoFija.Visible = true;
                        txbCodPagoFija.Visible = true;
                    }
                }
            }
        }

        private bool GetVerCondPagoCampCab(string sIdCampCab)
        {
            bool ret = false;
            SqlDataReader dr;
            dr = null;

            try
            {
                if (sqlConn.State.ToString() == "Closed")
                    sqlConn.Open();

                sqlGetCondPagoCampCab.Parameters["@idCampanya"].Value = sIdCampCab;
                dr = sqlGetCondPagoCampCab.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ret = bool.Parse(dr[0].ToString());
                        break;
                    }
                }


            }
            catch (Exception e)
            {
                Mensajes.ShowError(e.ToString());
            }

            dr.Close();
            return ret;
        }

        private string GetCondPagoFijaCampCab(string sIdCampCab)
        {
            string ret = "";
            SqlDataReader dr;
            dr = null;

            try
            {
                if (sqlConn.State.ToString() == "Closed")
                    sqlConn.Open();

                sqlGetCondPagoFijaCampCab.Parameters["@idCampanya"].Value = sIdCampCab;
                dr = sqlGetCondPagoFijaCampCab.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        if (dr[0] != null && dr[0] != DBNull.Value)
                            ret = dr[1].ToString(); // Descripción
                        break;
                    }
                }


            }
            catch (Exception e)
            {
                Mensajes.ShowError(e.ToString());
            }

            dr.Close();
            return ret;
        }

        private List<string> GetMatsConVale()
        {
            List<string> lRet = new List<string>();

            this.dsMateriales1.MatsConVale.Rows.Clear();

            this.sqldaGetMatsConVale.Fill(this.dsMateriales1);

            if (this.dsMateriales1.MatsConVale.Rows.Count > 0)
            {

                foreach (dsMateriales.MatsConValeRow row in dsMateriales1.MatsConVale)
                {
                    lRet.Add(row.sIdMaterial);
                }
            }

            return lRet;
        }

        private int GetMatsConValeEnPedido(SqlTransaction sqlT)
        {
            this.dsMateriales1.ListaMatsConVale.Rows.Clear();

            this.sqlCmdListaMatsConVale.Transaction = sqlT;
            this.sqldaListaMatsConVale.SelectCommand.Parameters["@sIdPedido"].Value = IdPedido;

            this.sqldaListaMatsConVale.Fill(this.dsMateriales1);

            for (int i = dsMateriales1.ListaMatsConVale.Rows.Count - 1; i >= 0; i--)
            {
                dsMateriales.ListaMatsConValeRow dr = (dsMateriales.ListaMatsConValeRow)dsMateriales1.ListaMatsConVale.Rows[i];
                if (dr.IssIdPedidoNull())
                    dsMateriales1.ListaMatsConVale.Rows.Remove(dr);
            }

            return dsMateriales1.ListaMatsConVale.Rows.Count;
        }

        private bool HayMatsConVale()
        {
            bool bRet = false;
            string mat = "";

            _lMatsConValePedido.Clear();

            foreach (DataGridViewRow row in dataGridViewLineas.Rows)
            {
                mat = row.Cells[K_COL_IDMAT].Value.ToString();

                int result = _lMatsConVale.FindIndex(
                                                        delegate (string s)
                                                        {
                                                            return s == mat;
                                                        }
                                                    );

                if (result >= 0)
                {
                    bRet = true;
                    break;
                }
            }

            return bRet;
        }

        private DateTime GetFechaFactSegunCampanyaCab(string sIdCampCab)
        {
            DateTime ret = DateTime.Today;
            SqlDataReader dr;
            dr = null;

            try
            {
                if (sqlConn.State.ToString() == "Closed")
                    sqlConn.Open();

                sqlGetFecFact.Parameters["@idCampanya"].Value = sIdCampCab;
                dr = sqlGetFecFact.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        if (dr[0] != System.DBNull.Value)
                            ret = DateTime.Parse(dr[0].ToString());
                        else
                            ret = DateTime.Parse("31/12/9998");
                        break;
                    }
                }


            }
            catch (Exception e)
            {
                Mensajes.ShowError(e.ToString());
            }

            dr.Close();
            return ret;
        }

        //---- GSG (15/05/2019) Lo quito porque creo que ya no se utiliza
        //private void getDatosFinanciacion()
        //{
        //    float oMedFin = 0;
        //    float oMedNoFin = 0;

        //    //---- GSG (05/09/2014) Reutilización de los campos para otro fin
        //    //Calcular_DescuentosFinanciados(out oMedFin, out oMedNoFin);
        //    Calcular_DescuentosFacturaYFinan(out oMedFin, out oMedNoFin);

        //    txbDescFinan.Text = oMedFin.ToString("C2");
        //    txbDescNoFinan.Text = oMedNoFin.ToString("C2");
        //}

        private void Calcular_DescuentosFinanciados(out float oMedFin, out float oMedNoFin)
        {
            float fMFin = 0.0F;
            float fMNoFin = 0.0F;
            int quantsMFin = 0;
            int quantsMNoFin = 0;

            int iCantidad = 0;
            float fPrecio = 0;
            float fDescuento = 0;
            float valorDesc = 0;

            oMedFin = 0;
            oMedNoFin = 0;

            for (int i = 0; i < dtLineasPedido.Rows.Count; i++)
            {
                if (dtLineasPedido.Rows[i].RowState != DataRowState.Deleted && !bool.Parse(dtLineasPedido.Rows[i]["bDescExtra"].ToString()))
                {
                    if (dtLineasPedido.Rows[i]["bMedicamento"] != System.DBNull.Value && bool.Parse(dtLineasPedido.Rows[i]["bMedicamento"].ToString()))
                    {
                        iCantidad = int.Parse(dtLineasPedido.Rows[i]["iCantidad"].ToString());
                        fPrecio = float.Parse(dtLineasPedido.Rows[i]["PrecioUnitario"].ToString());
                        fDescuento = float.Parse(dtLineasPedido.Rows[i]["fDescuento"].ToString());

                        valorDesc = (fPrecio * iCantidad * fDescuento) / 100;

                        if (dtLineasPedido.Rows[i]["bFinanciado"] != System.DBNull.Value && bool.Parse(dtLineasPedido.Rows[i]["bFinanciado"].ToString()))
                        {
                            fMFin += valorDesc;
                            quantsMFin++;
                        }
                        else
                        {
                            fMNoFin += valorDesc;
                            quantsMNoFin++;
                        }
                    }
                }
            }

            // Pondremos el importe total y no el importe medio
            oMedFin = fMFin;
            oMedNoFin = fMNoFin;
        }

        private void Calcular_DescuentosFacturaYFinan(out float oMedFin, out float oMedNoFin)
        {
            float fDescFactura = 0.0F;
            float fDescTraNoFin = 0.0F;

            int iCantidad = 0;
            float fPrecio = 0;
            float fDescuento = 0;
            float valorDesc = 0;
            float NetoTraNoFinan = 0;

            oMedFin = 0;
            oMedNoFin = 0;

            if (!Comun.IsInTheArray(cboTipoPedido.SelectedValue.ToString(), Configuracion.asPedTransfer) && cboTipoPedido.SelectedValue.ToString() != "ZCR") //Directo
            { //dir
                for (int i = 0; i < dtLineasPedido.Rows.Count; i++)
                {
                    if (dtLineasPedido.Rows[i].RowState != DataRowState.Deleted && !bool.Parse(dtLineasPedido.Rows[i]["bDescExtra"].ToString()) && int.Parse(dtLineasPedido.Rows[i]["idArrastre"].ToString()) != 1)
                    {
                        iCantidad = int.Parse(dtLineasPedido.Rows[i]["iCantidad"].ToString());
                        fPrecio = float.Parse(dtLineasPedido.Rows[i]["PrecioUnitario"].ToString());

                        if (dtLineasPedido.Rows[i]["bMedicamento"] != System.DBNull.Value && bool.Parse(dtLineasPedido.Rows[i]["bMedicamento"].ToString()) &&
                            dtLineasPedido.Rows[i]["bFinanciado"] != System.DBNull.Value && !bool.Parse(dtLineasPedido.Rows[i]["bFinanciado"].ToString()))
                            //Medicamentos no financiados
                            fDescuento = float.Parse(dtLineasPedido.Rows[i]["fDescuento"].ToString()); // desc aplicado
                        else // Medicamentos financiados + no medicamentos
                            fDescuento = float.Parse(dtLineasPedido.Rows[i]["fDescMat"].ToString()); // desc legal

                        valorDesc = (fPrecio * iCantidad * fDescuento) / 100;
                        fDescFactura += valorDesc;
                    }
                }
            }
            else if (Comun.IsInTheArray(cboTipoPedido.SelectedValue.ToString(), Configuracion.asPedTransfer) && cboTipoPedido.SelectedValue.ToString() != "ZCR") //Tranfer 
            { //transfer
                for (int i = 0; i < dtLineasPedido.Rows.Count; i++)
                {
                    if (dtLineasPedido.Rows[i].RowState != DataRowState.Deleted && !bool.Parse(dtLineasPedido.Rows[i]["bDescExtra"].ToString()) && int.Parse(dtLineasPedido.Rows[i]["idArrastre"].ToString()) != 1)
                    {
                        iCantidad = int.Parse(dtLineasPedido.Rows[i]["iCantidad"].ToString());
                        fPrecio = float.Parse(dtLineasPedido.Rows[i]["PrecioUnitario"].ToString());

                        //legal de todos
                        fDescuento = float.Parse(dtLineasPedido.Rows[i]["fDescMat"].ToString()); // legal
                        valorDesc = (fPrecio * iCantidad * fDescuento) / 100;
                        fDescFactura += valorDesc;

                        //extra de los no financiados
                        if (dtLineasPedido.Rows[i]["bMedicamento"] != System.DBNull.Value && bool.Parse(dtLineasPedido.Rows[i]["bMedicamento"].ToString()) &&
                            (dtLineasPedido.Rows[i]["bFinanciado"] == System.DBNull.Value || !bool.Parse(dtLineasPedido.Rows[i]["bFinanciado"].ToString())))
                        {
                            NetoTraNoFinan += float.Parse(dtLineasPedido.Rows[i]["ImporteLin"].ToString());

                            //sols el cálcul per transfer perque en aquest cas només afecta tranfer (no cal fer la comprovació) (si fos directa agafariem la columna "fDescExtra" i ja està, però no)

                            //Descuento máximo según cliente (tabla DescuentoMax)
                            string sDescMaxMaterial = GetDescuentoMaximoMaterial(dtLineasPedido.Rows[i]["sIdMaterial"].ToString(), cboTipoPedido.SelectedValue.ToString(), iIdDestinatario);
                            float auxiD = 0;

                            if (sDescMaxMaterial != "-1")
                                auxiD = float.Parse(sDescMaxMaterial) + (float)GetDescuentoMayoristaClub(); //máximo + mayorista
                            else
                                auxiD = fDescuento + (float)GetDescuentoMayoristaClub(); //legal + mayorista

                            if (auxiD <= fDescuento)
                                valorDesc = (fPrecio * iCantidad * auxiD) / 100;      //extra
                            else
                                valorDesc = (fPrecio * iCantidad * fDescuento) / 100;

                            fDescTraNoFin += (fPrecio * iCantidad) - valorDesc;
                        }
                    }
                }

                if (fDescTraNoFin - NetoTraNoFinan < 0)
                    fDescTraNoFin = 0;
                else
                    fDescTraNoFin = fDescTraNoFin - (float)NetoTraNoFinan;
            }

            oMedFin = fDescFactura;
            oMedNoFin = fDescTraNoFin;
        }


        //Retorna true si el cliente pertenece a la región Andorra
        private bool EsAndorrano(int iIdCliente)
        {
            bool bRet = false;

            string region = BuscaRegionClienteSAP(iIdCliente);

            if (region == Comun.K_COD_ANDORRA)
                bRet = true;

            return bRet;
        }

        public string BuscaRegionClienteSAP(int iIdCliente)
        {
            string resul = "";

            try
            {
                DataTable dtRegion = new DataTable();

                this.sqlCmdGetRegionClienteSAP.Parameters["@iIdCliente"].Value = iIdCliente;
                sqldaRegion.Fill(dtRegion);

                if (dtRegion.Rows.Count > 0)
                {
                    DataRow dr = dtRegion.NewRow();
                    dr = dtRegion.Rows[0];

                    resul = dr[0].ToString();
                }
                else
                {
                    resul = "";
                }
            }
            catch (Exception E)
            {
                resul = "";
            }
            finally
            {

            }

            return resul;
        }

        //---- GSG (06/03/2017)
        public string BuscaCPClienteSAP(int iIdCliente)
        {
            string resul = "";

            try
            {
                DataTable dtCP = new DataTable();

                this.sqlCmdGetCPClienteSAP.Parameters["@iIdCliente"].Value = iIdCliente;
                sqldaCP.Fill(dtCP);

                if (dtCP.Rows.Count > 0)
                {
                    DataRow dr = dtCP.NewRow();
                    dr = dtCP.Rows[0];

                    resul = dr[0].ToString();
                }
                else
                {
                    resul = "";
                }
            }
            catch (Exception E)
            {
                resul = "";
            }
            finally
            {

            }

            return resul;
        }




        private string GetTipoSumaUnidadesCampanya(string sIdMat, string sIdCamp)
        {
            string ret = "0";
            SqlDataReader dr;
            dr = null;

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



            }
            catch (Exception err)
            {
                Mensajes.ShowError("GetTipoSumaUnidadesCampanya. Error: " + err.ToString());
            }

            dr.Close();
            return ret;
        }

        //---- GSG (29/03/2022)
        private string GetTipoPedidoSumaUnidadesCampanya(string sIdMat, string sIdCamp)
        {
            string ret = "XXXX";
            SqlDataReader dr;
            dr = null;

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



            }
            catch (Exception err)
            {
                Mensajes.ShowError(err.ToString());
            }

            dr.Close();
            return ret;
        }


        private void btExport_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            string folder = System.Configuration.ConfigurationManager.AppSettings["TargetFolderExcel"].ToString();
            string fitxerXLSX = folder + "pedido_" + sIdPedido + ".xlsx";
            // "{0:#,0.##}%"
            List<string> cabecera = new List<string>();
            List<string[]> lineas = new List<string[]>();

            string sTitulo = this.sIdPedido + "  -  " + dtpFechaPedido.Text;
            string sSubTitulo = this.txtClienteSAP.Text + "     " + this.txtsCliente.Text;


            string sSubTitulo2 = "Tipo de pedido " + cboTipoPedido.Text;
            if (Comun.IsInTheArray(cboTipoPedido.SelectedValue.ToString(), Configuracion.asPedTransfer) && cboTipoPedido.SelectedValue.ToString() != "ZCR") //Tranfer 
                sSubTitulo2 += " - Mayorista " + txtsDestinatario.Text;

            cabecera.Add("Cod. Nacional");
            cabecera.Add("Descripción");
            cabecera.Add("Unidades");

            foreach (DataGridViewRow row in dataGridViewLineas.Rows)
            {
                string[] lin = new string[3];

                lin[0] = row.Cells["sCodNacional"].Value.ToString();
                lin[1] = row.Cells["ColProducto"].Value.ToString();
                if (row.Cells["ColCantidad"].Value.ToString() != "")
                    lin[2] = row.Cells["ColCantidad"].Value.ToString();
                else
                    lin[2] = "0";

                lineas.Add(lin);
            }

            DirectoryInfo dir = new DirectoryInfo(folder);
            if (!dir.Exists)
            {
                dir.Create();
            }

            oExportExcel = new ExportToExcel(fitxerXLSX, "Pedido", sTitulo, sSubTitulo, sSubTitulo2, cabecera, lineas);

            Mensajes.ShowInformation("Ha finalizado la exportación a Excel.");

            Cursor.Current = Cursors.Default;

            FileInfo fit = new FileInfo(fitxerXLSX);
            if (fit.Exists)
            {
                System.Diagnostics.Process.Start(fitxerXLSX);
            }
            else
                Mensajes.ShowError("No se puede abrir el fichero excel.");
        }


        //---- GSG (13/03/2019)
        //private void AvisoProximoObjetivo(string sIdCliente)
        private void AvisoProximoObjetivo(string sIdCliente, DateTime dFecha)
        {
            int idCliente = Utiles.CodigoCliente(sIdCliente);
            string obj = "";

            if (idCliente > 0)
            {
                string msg = "El próximo obetivo en la visita para este cliente es:" + Environment.NewLine + Environment.NewLine;

                //---- GSG (13/03/2019)
                //obj = GESTCRM.Utiles.ProximoObjetivoVisita(iIdCliente, -1);
                obj = GESTCRM.Utiles.ProximoObjetivoVisita(iIdCliente, -1, dFecha);

                if (obj != "")
                {
                    msg += obj;
                    Mensajes.ShowInformation(msg, true);
                }
            }
        }

        //---- GSG (13/03/2019)
        private void AvisoAccionesAbiertasCliente(string sIdCliente)
        {
            int iNum = GetAccionesAbiertas(sIdCliente);

            if (iNum > 0)
            {
                string msg = "El cliente tiene acciones de márketing abiertas:" + Environment.NewLine + Environment.NewLine;

                foreach (GESTCRM.Formularios.DataSets.dsClientes.ListaAccionesAbiertasClienteRow row in dsClientes1.ListaAccionesAbiertasCliente.Rows)
                {
                    msg += row.sDescAccion.PadRight(50) + row.iUnidades.ToString() + " unidades";
                    msg += Environment.NewLine + Environment.NewLine;
                }

                Mensajes.ShowInformation(msg, true);
            }
        }

        private int GetAccionesAbiertas(string psIdCliente)
        {
            int iRet = 0;

            this.dsClientes1.ListaAccionesAbiertasCliente.Rows.Clear();

            if (sqlConn.State == ConnectionState.Closed)
                this.sqlConn.Open();

            try
            {
                this.sqlCmdListaAccionesAbiertasCliente.Parameters["@sIdCliente"].Value = psIdCliente;
                this.sqldaListaAccionesAbiertasClientee.Fill(this.dsClientes1);

                iRet = dsClientes1.ListaAccionesAbiertasCliente.Rows.Count;
            }
            catch (Exception e)
            {
                Mensajes.ShowError(e.Message);
            }

            this.sqlConn.Close();

            return iRet;
        }





        private int GetTarjetasCliente(string psIdCliente)
        {
            int iRet = 0;

            this.dsClientes1.ListaTarjetasCliente.Rows.Clear();

            if (sqlConn.State == ConnectionState.Closed)
                this.sqlConn.Open();

            SqlTransaction sqlTran = this.sqlConn.BeginTransaction();
            this.sqlCmdListaTarjetasCliente.Transaction = sqlTran;

            try
            {
                this.sqlCmdListaTarjetasCliente.Parameters["@sIdCliente"].Value = psIdCliente;
                this.sqldaListaTarjetasCliente.Fill(this.dsClientes1);

                iRet = dsClientes1.ListaTarjetasCliente.Rows.Count;
            }
            catch (Exception e)
            {
                Mensajes.ShowError(e.Message);
            }

            this.sqlConn.Close();

            return iRet;
        }

        private void AvisoTarjetasCliente(string sIdCliente)
        {
            int iNumTarj = GetTarjetasCliente(sIdCliente);
            bool bShowMiss = false;

            if (iNumTarj > 0)
            {
                string msg = "El cliente tiene asociadas las siguientes tarjetas:" + Environment.NewLine + Environment.NewLine;

                List<string> campanyasTarjeta = new List<string>();

                foreach (GESTCRM.Formularios.DataSets.dsClientes.ListaTarjetasClienteRow row in dsClientes1.ListaTarjetasCliente.Rows)
                {
                    if (row.IsdFecUsoNull())
                    {
                        if (row.IsdIniValidezNull() && row.IsdFinValidezNull())
                        {
                            string producto = row.IsproductoNull() ? "" : row.producto;
                            int unidades = row.IsiUnidadesMinNull() ? 0 : row.iUnidadesMin;
                            double bruto = row.IsfBrutoMinNull() ? 0 : row.fBrutoMin;

                            msg += row.sIdMaterial.PadRight(10, ' ') + row.sMaterial.PadRight(50, ' ') + " asignada el " + row.dFecAsignacion.ToShortDateString() + Environment.NewLine;
                            msg += " - Requerimientos: " + producto + ", " + unidades.ToString() + " unidades mínimas y " + bruto.ToString() + " bruto mínimo";
                            msg += Environment.NewLine + Environment.NewLine;

                            bShowMiss = true;
                        }
                        else
                        {
                            if (!campanyasTarjeta.Contains(row.NombreCampanya))
                            {
                                campanyasTarjeta.Add(row.NombreCampanya);
                                msg += row.NombreCampanya.PadRight(40, ' ') + " asignada el " + row.dFecAsignacion.ToShortDateString();
                                string inival = row.dIniValidez.ToShortDateString();
                                string finval = row.dFinValidez.ToShortDateString();
                                msg += ", vigencia de " + inival + " a " + finval;
                                msg += Environment.NewLine + Environment.NewLine;

                                bShowMiss = true;
                            }
                        }
                    }
                }

                if (bShowMiss)
                    Mensajes.ShowInformation(msg, true);
            }
        }

        private void SetUsoTarjetasCliente(string psIdCliente, string psIdMaterial, DateTime pdFecAsignacion, DateTime pdFecUso)
        {
            try
            {
                if (sqlConn.State.ToString() == "Closed")
                    sqlConn.Open();

                sqlCmdSetUsoTarjetasCliente.Parameters["@sIdCliente"].Value = psIdCliente;
                sqlCmdSetUsoTarjetasCliente.Parameters["@sIdMaterial"].Value = psIdMaterial;
                sqlCmdSetUsoTarjetasCliente.Parameters["@dFecAsignacion"].Value = pdFecAsignacion;
                if (pdFecUso != DateTime.MinValue)
                    sqlCmdSetUsoTarjetasCliente.Parameters["@dFecUso"].Value = pdFecUso;

                sqlCmdSetUsoTarjetasCliente.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Mensajes.ShowError(e.ToString());
            }
        }

        private void ActualizaTarjetasCliente(string sIdCliente)
        {
            foreach (DataGridViewRow row in dataGridViewLineas.Rows)
            {
                string mat = row.Cells[K_COL_IDMAT].Value.ToString();
                string filtro = "sIdCliente = '" + sIdCliente + "' AND sIdMaterial = '" + mat + "' AND dFecAsignacion is not null AND dFecUso is null";
                DateTime fechaUso = DateTime.Now;
                DataRow[] result = this.dsClientes1.ListaTarjetasCliente.Select(filtro);

                if (result.Length > 0)
                {
                    DateTime fecAsign = DateTime.Parse(result[0]["dFecAsignacion"].ToString());
                    SetUsoTarjetasCliente(sIdCliente, mat, fecAsign, fechaUso);
                }
            }
        }

        private List<string> GetTargetasClienteEnOriginal()
        {
            List<string> llista = new List<string>();
            String[] sTarj = Configuracion.sIdCampanyaTarjetasCliente.Split(',');

            foreach (dsMateriales.ListaLineasPedidoRow row in dtLineasPedido)
            {
                for (int i = 0; i < sTarj.Length; i++)
                {
                    if (row.idCampanya == sTarj[i])
                    {
                        llista.Add(row.sIdMaterial);
                        break;
                    }
                }
            }

            return llista;
        }

        private void ActualizaTarjetasClienteBorrado(string sIdCliente)
        {
            foreach (string tc in _lTarjetasClientePedidoOriginal)
            {
                // Mirar si la tarjeta continua en el pedido
                DataRow[] result = dtLineasPedido.Select("sIdMaterial = '" + tc + "'");
                if (result.Length == 0) // Ya no está
                {
                    // Actualizar la tarjeta
                    string filtro = "sIdCliente = '" + sIdCliente + "' AND sIdMaterial = '" + tc + "'";
                    DataRow[] resultTC = this.dsClientes1.ListaTarjetasCliente.Select(filtro);
                    DateTime fecAsign = DateTime.Parse(resultTC[0]["dFecAsignacion"].ToString());
                    DateTime fecUso = DateTime.MinValue;
                    SetUsoTarjetasCliente(sIdCliente, tc, fecAsign, fecUso);
                }
            }
        }

        private List<string> GetTargetasClientPedidoEnCurso()
        {
            List<string> llista = new List<string>();
            String[] sTarj = Configuracion.sIdCampanyaTarjetasCliente.Split(',');

            foreach (DataGridViewRow row in dataGridViewLineas.Rows)
            {
                for (int i = 0; i < sTarj.Length; i++)
                {
                    if (row.Cells[K_COL_IDCAMP].Value.ToString() == sTarj[i])
                    {
                        llista.Add(row.Cells[K_COL_IDMAT].Value.ToString());
                        break;
                    }
                }
            }

            return llista;
        }

        // Retorna el descuento que el cliente quiere ver en factura 
        private string GetDescuentoFactura(int iIdCliente)
        {
            DataTable dtDescFactura = new DataTable();
            string sDescFactura = "0";

            try
            {
                if (sqlConn.State == ConnectionState.Closed)
                    this.sqlConn.Open();

                using (SqlCommand cmd = new SqlCommand("GetDescuentoFactura", sqlConn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@iIdMayorista", System.Data.SqlDbType.Int, 4);
                    cmd.Parameters["@iIdMayorista"].Value = iIdCliente;

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dtDescFactura);
                    }
                }

                if (dtDescFactura.Rows.Count > 0)
                {
                    DataRow drDescFactura = dtDescFactura.NewRow();
                    drDescFactura = dtDescFactura.Rows[0];
                    sDescFactura = drDescFactura["fDescuentoMayorista"].ToString();

                    if (sDescFactura == "0")
                        sDescFactura = "100";
                }
                else
                    sDescFactura = "100";

                this.sqlConn.Close();
            }
            catch (Exception e)
            {
                string err = e.Message;
            }

            return sDescFactura;
        }

        // Uso los paneles y no this.Enabled ya que en caso de haber otro formulario abierto, deja el activo en primer plano
        private void activarForm(bool bActivar)
        {
            this.pnlCabeceraPedido.Enabled = bActivar;
            this.pnlLineaPedido.Enabled = bActivar;

            if (bActivar)
                dataGridViewLineas.Focus();
        }

        private void btCompetencia_Click(object sender, EventArgs e)
        {
            //Pop-up amb comparativa de la comanda amb les diferents empreses de la competència
            if (sIdPedido != "")
            {
                txtbLeyenda frmC = new txtbLeyenda(dataGridViewLineas, sIdPedido);
                frmC.ShowDialog(this);
            }
            else
            {
                Mensajes.ShowInformation("Para comparar este pedido, antes debe guardarlo.");
            }
        }

        private string[] GetMaterialesBloqueados(string psTipoPedido)
        {
            string[] aRet = null;

            this.dsMateriales1.ListaMaterialesBloqueados.Rows.Clear();

            if (sqlConn.State == ConnectionState.Closed)
                this.sqlConn.Open();

            SqlTransaction sqlTran = this.sqlConn.BeginTransaction();
            this.sqlCmdListaMaterialesBloqueados.Transaction = sqlTran;

            //---- GSG CECL 23/08/2016
            if (System.Configuration.ConfigurationManager.AppSettings["TipoDelegadoPedidosCentral"].ToString() == Comun.K_CECL)
                sqlCmdListaMaterialesBloqueados.CommandText = "[ListaMaterialesBloqueadosCECL]";
            else
                sqlCmdListaMaterialesBloqueados.CommandText = "[ListaMaterialesBloqueados]";
            //---- FI GSG CECL 

            try
            {
                this.sqlCmdListaMaterialesBloqueados.Parameters["@sIdTipoPedido"].Value = psTipoPedido;
                this.sqlCmdListaMaterialesBloqueados.Parameters["@iIdDelegado"].Value = Clases.Configuracion.iIdDelegado;

                this.sqldaListaMaterialesBloqueados.Fill(this.dsMateriales1);

                int iMats = dsMateriales1.ListaMaterialesBloqueados.Rows.Count;

                aRet = new string[iMats];

                for (int i = 0; i < dsMateriales1.ListaMaterialesBloqueados.Rows.Count; i++)
                {
                    aRet[i] = dsMateriales1.ListaMaterialesBloqueados.Rows[i].ItemArray[0].ToString();
                }
            }
            catch (Exception e)
            {
                Mensajes.ShowError(e.Message);
            }

            this.sqlConn.Close();

            return aRet;
        }

        private List<KeyValuePair<string, string>> getPairsMatCampEnPed()
        {
            var list = new List<KeyValuePair<string, string>>();

            //---- GSG (10/10/2016)
            // Si la campaña lo permite, dejaremos duplicar un material para varias campañas   

            //foreach (DataGridViewRow row in dataGridViewLineas.Rows)
            //{
            //if (row.Cells["ColCampanya"].Value.ToString().Trim().ToLower().IndexOf("entrega") >= 0)
            //    list.Add(new KeyValuePair<string, string>(row.Cells["sIdMaterialDataGridViewTextBoxColumn"].Value.ToString(), "entrega-" + row.Cells["ColidCampanya"].Value.ToString()));
            //else
            //    list.Add(new KeyValuePair<string, string>(row.Cells["sIdMaterialDataGridViewTextBoxColumn"].Value.ToString(), row.Cells["ColidCampanya"].Value.ToString()));                
            //}



            // Al formulario de selección de materiales, pasaremos una lista que contendrá parejas (material, campaña) que ya no puedan seleccionarse

            this.dsMateriales1.CampsKeAdmitenDups.Rows.Clear();
            this.sqldaCampsDup.Fill(dsMateriales1);

            //---- GSG (01/03/2017)
            //if (this.dsMateriales1.CampsKeAdmitenDups.Rows.Count > 0)
            //{
            foreach (DataGridViewRow row in dataGridViewLineas.Rows)
            {
                if (this.dsMateriales1.CampsKeAdmitenDups.Rows.Count > 0)
                {
                    DataRow[] ldr = dsMateriales1.CampsKeAdmitenDups.Select("idCampanya = '" + row.Cells["ColidCampanya"].Value.ToString() + "'");
                    if (ldr.Length == 0) // sólo las que no se pueden duplicar
                        list.Add(new KeyValuePair<string, string>(row.Cells["sIdMaterialDataGridViewTextBoxColumn"].Value.ToString(), row.Cells["ColidCampanya"].Value.ToString()));
                }
                else
                    list.Add(new KeyValuePair<string, string>(row.Cells["sIdMaterialDataGridViewTextBoxColumn"].Value.ToString(), row.Cells["ColidCampanya"].Value.ToString()));
            }
            //}

            return list;
        }


        //---- GSG (13/09/2016)
        private void GetValuesProdEnPedido()
        {
            string idProd = "";
            string nombreProd = "";
            int cantidad = 0;
            int cantidadBruta = 0;
            float importe = 0;
            float numeradoRent = 0;
            float fDescuento = 0;
            float fCoste = -1;

            // Guarda unidades, importes y rentabilidad del pedido agrupados por productos existentes en el pedido
            _tValuesProdEnPed.Clear();

            foreach (dsMateriales.ListaLineasPedidoRow row in dtLineasPedido)
            {
                idProd = ObtenirProductoMaterial(row.sIdMaterial);
                DataRow[] sNombresProducto = dsFormularios1.ListaProductos.Select("sIdProducto = '" + idProd + "'");
                if (sNombresProducto.Length > 0)
                    nombreProd = sNombresProducto[0][1].ToString();

                cantidad = int.Parse(row.iCantidad.ToString());
                cantidadBruta = int.Parse(row.iCantidad.ToString()) * int.Parse(row.iCantidadBase.ToString());

                importe = cantidad * float.Parse(row.PrecioUnitario.ToString());
                fDescuento = importe * (float.Parse(row.fDescuento.ToString()) / 100);  // valor del descuento
                try { fCoste = float.Parse(row.fCoste.ToString()); }
                catch (Exception e) { fCoste = 0; }
                numeradoRent = importe - fDescuento - (int.Parse(row.iCantidad.ToString()) * fCoste);

                if (_tValuesProdEnPed.Count > 0)
                {
                    ValuesProd val = _tValuesProdEnPed.Find(delegate (ValuesProd val1) { return val1.sIdProducto == idProd; });

                    if (val == null)
                        //_tValuesProdEnPed.Add(new ValuesProd(idProd, nombreProd, cantidad, importe, numeradoRent));
                        _tValuesProdEnPed.Add(new ValuesProd(idProd, nombreProd, cantidadBruta, importe, numeradoRent));
                    else
                    {
                        //_tValuesProdEnPed.Find(x => x.sIdProducto == idProd).iCantidad += cantidad;
                        _tValuesProdEnPed.Find(x => x.sIdProducto == idProd).iCantidad += cantidadBruta;
                        _tValuesProdEnPed.Find(x => x.sIdProducto == idProd).fImporte += importe;
                        // la rentabilidad no suma
                    }
                }
                else
                    //_tValuesProdEnPed.Add(new ValuesProd(idProd, nombreProd, cantidad, importe, numeradoRent));
                    _tValuesProdEnPed.Add(new ValuesProd(idProd, nombreProd, cantidadBruta, importe, numeradoRent));
            }

            // Para tener bien la rentabilidad de cada grupo falta dividir por el bruto
            foreach (ValuesProd val in _tValuesProdEnPed)
            {
                if (val.fImporte != 0)
                    val.fRentabilidad = (val.fRentabilidad / val.fImporte) * 100;
                else
                    val.fRentabilidad = 0;
            }
        }
        private void ResetValuesProdEnPedido()
        {
            _tValuesProdEnPed.Clear();
        }

        //Inicialitza grid Acciones Marketing
        private void CargarAccMark()
        {
            try
            {
                //---- GSG CECL 19/05/2016
                if (System.Configuration.ConfigurationManager.AppSettings["TipoDelegadoPedidosCentral"].ToString() == Comun.K_CECL)
                {
                    sqlDataListaAccionesMarketing.SelectCommand = sqlCommand1CECL;
                    chkVisita.Enabled = false;
                }
                else
                {
                    sqlDataListaAccionesMarketing.SelectCommand = sqlCommand1;
                    chkVisita.Enabled = true;
                }
                //---- FI GSG CECL

                dsAccionesMarketing1.ListaAccionesMarketing.Clear();

                // En cada vuelta añade las acciones que se pueden mostrar para cada producto existente en el pedido
                // @sIdTipoAccion varchar(10) = null, --la acción tipo 3 es la que está afectada por los siguientes filtros.El resto continuará como siempre
                // @sIdProducto    varchar(10) = null, --acciones asociadas al producto o acciones no asociadas a ningún producto si null
                // @iUnidadesSel   int = 0, --unidades totales del pedido si @sIdProducto = null o unidades del producto en caso contrario
                // @fImporteSel    float = 0, --importe total del pedido o importe del producto
                // @fRentabSel     float = 0, --rentabilidad total o producto
                // @bIndepe        bit = null, --si 1 especiales, 0 no-- si null estamos llamando desde otros sitios que no son la creación o consulta de pedido para acciones tipo 3

                //---- GSG (06/03/2021)
                // @iActivoPara    int = 0-- 0 cualquier formulario, 1 pedidos, 2 autopedidos
                //Cambio:
                // @iActivoPara nunca es 0 -- puede tener hasta 18 valores distintos en tabla per solo se le pasa 1 pedidos, 2 autopedidos a la stored que no coinciden con estos 18
                // HAy que añadir el tipo de pedido en los parámetros pues ahora condiciona el que salga o no


                string sTipoPedido = cboTipoPedido.SelectedValue.ToString(); //---- GSG (06/03/2021)

                // 1.- añade acciones para líneas cuyo producto tiene acciones asociadas
                foreach (ValuesProd val in _tValuesProdEnPed)
                {
                    this.sqlDataListaAccionesMarketing.SelectCommand.Parameters["@sIdTipoAccion"].Value = "3";
                    this.sqlDataListaAccionesMarketing.SelectCommand.Parameters["@sIdProducto"].Value = val.sIdProducto;
                    this.sqlDataListaAccionesMarketing.SelectCommand.Parameters["@iUnidadesSel"].Value = val.iCantidad;
                    this.sqlDataListaAccionesMarketing.SelectCommand.Parameters["@fImporteSel"].Value = val.fImporte;
                    this.sqlDataListaAccionesMarketing.SelectCommand.Parameters["@fRentabSel"].Value = val.fRentabilidad;
                    this.sqlDataListaAccionesMarketing.SelectCommand.Parameters["@bIndepe"].Value = 0;
                    this.sqlDataListaAccionesMarketing.SelectCommand.Parameters["@iActivoPara"].Value = 1;
                    this.sqlDataListaAccionesMarketing.SelectCommand.Parameters["@sIdTipoPedido"].Value = sTipoPedido; //---- GSG (06/03/2021)

                    this.sqlDataListaAccionesMarketing.Fill(dsAccionesMarketing1);
                }

                // 2.- Añade acciones que no están asociadas a ningún producto
                float fBrutoPedido = float.Parse(txbImporteBruto.Text.Replace('€', ' ').Trim());
                float fRentPedido = 0;
                if (Utiles.IsDecimal(txtRentabilidad.Text))
                    fRentPedido = float.Parse(txtRentabilidad.Text);
                int iCantidadPedido = 0;
                foreach (ValuesProd val in _tValuesProdEnPed)
                    iCantidadPedido += val.iCantidad;

                this.sqlDataListaAccionesMarketing.SelectCommand.Parameters["@sIdTipoAccion"].Value = "3";
                this.sqlDataListaAccionesMarketing.SelectCommand.Parameters["@sIdProducto"].Value = null;
                this.sqlDataListaAccionesMarketing.SelectCommand.Parameters["@iUnidadesSel"].Value = iCantidadPedido;
                this.sqlDataListaAccionesMarketing.SelectCommand.Parameters["@fImporteSel"].Value = fBrutoPedido;
                this.sqlDataListaAccionesMarketing.SelectCommand.Parameters["@fRentabSel"].Value = fRentPedido;
                this.sqlDataListaAccionesMarketing.SelectCommand.Parameters["@bIndepe"].Value = 0;
                this.sqlDataListaAccionesMarketing.SelectCommand.Parameters["@iActivoPara"].Value = 1;
                this.sqlDataListaAccionesMarketing.SelectCommand.Parameters["@sIdTipoPedido"].Value = sTipoPedido; //---- GSG (06/03/2021)

                this.sqlDataListaAccionesMarketing.Fill(dsAccionesMarketing1);

                // 3.- Añade las acciones especiales (independientes de todo filtro)
                this.sqlDataListaAccionesMarketing.SelectCommand.Parameters["@sIdTipoAccion"].Value = "3";
                this.sqlDataListaAccionesMarketing.SelectCommand.Parameters["@sIdProducto"].Value = null;
                this.sqlDataListaAccionesMarketing.SelectCommand.Parameters["@iUnidadesSel"].Value = 0;
                this.sqlDataListaAccionesMarketing.SelectCommand.Parameters["@fImporteSel"].Value = 0;
                this.sqlDataListaAccionesMarketing.SelectCommand.Parameters["@fRentabSel"].Value = 0;
                this.sqlDataListaAccionesMarketing.SelectCommand.Parameters["@bIndepe"].Value = 1;
                this.sqlDataListaAccionesMarketing.SelectCommand.Parameters["@iActivoPara"].Value = 1;
                this.sqlDataListaAccionesMarketing.SelectCommand.Parameters["@sIdTipoPedido"].Value = sTipoPedido; //---- GSG (06/03/2021)

                this.sqlDataListaAccionesMarketing.Fill(dsAccionesMarketing1);
            }
            catch (Exception e)
            {
                Mensajes.ShowError(e.ToString());
            }
        }


        private void GetDatosPedParaAM()
        {
            txtbBrutoPedAM.Text = txbImporteBruto.Text;
            txtbDescMedioAM.Text = txbDto.Text; //%
            lblMissAM.Text = "";
            txtbPuntosPedAM.Text = txbMargenLab.Text; //---- GSG (06/03/2021)

            float fBrutoPedido = float.Parse(txbImporteBruto.Text.Replace('€', ' ').Trim());
            int numMaxAccMark = GetMaxAccMark(fBrutoPedido);

            if (numMaxAccMark < 100)
                lblMissAM.Text = "Según el importe del pedido, el número máximo de acciones de márketing que se pueden seleccionar es: " + numMaxAccMark.ToString();
        }

        private void GetDatosSeleccionAM()
        {
            // Cálculo del coste de las acciones de márketing seleccionadas                       
            float rentabilidadPedido = 0;
            if (Utiles.IsDecimal(txtRentabilidad.Text))
                rentabilidadPedido = float.Parse(txtRentabilidad.Text);

            float costeAM = 0;

            foreach (DataGridViewRow row in dataGridViewAccMark.Rows)
            {

                //---- GSG (06/03/2021) TIRO PARA ATRÁS PORQUE EN EL CÁLCULO SEGÚN COSTE DE ACCIONES DEBEN CONTAR TODAS. TODAS TIENEN COSTE 
                if (bool.Parse(row.Cells["selected"].Value.ToString()) && !bool.Parse(row.Cells["bIndepe"].Value.ToString()))
                    ////if (bool.Parse(row.Cells["selected"].Value.ToString()) && !bool.Parse(row.Cells["bIndepe"].Value.ToString()) && _listaAccMarkProfitPlus.Contains(row.Cells["sIdAccionDataGridViewTextBoxColumn"].Value.ToString()))
                    costeAM += (float.Parse(row.Cells["fCosteUnitarioDataGridViewTextBoxColumn"].Value.ToString()) * int.Parse(row.Cells["UnidadesAEntregar"].Value.ToString()));
            }

            txtbCosteTotalAM.Text = costeAM.ToString("C2");

            float rentabilidad = rentabilidadPedido - costeAM;
            // Busco el color de la rentabilidad
            Color cColor = Color.FromArgb(238, 243, 246);
            cColor = CalcularColorRentabilidad(rentabilidad, dtpFechaPedido.Value);
            txtbRentabilidadAM.BackColor = cColor;

            //---- GSG (06/03/2021)

            float margenAM = 0;

            if (Clases.Configuracion.iPuntosDividePor != 0)
                margenAM = (costeAM / Clases.Configuracion.iPuntosDividePor) * Clases.Configuracion.iPuntosMultiplicaPor;

            txtbPuntosPedConAM.Text = (float.Parse(txbMargenLab.Text) - margenAM).ToString("N2");
        }

        private void ResetAccMark()
        {
            dsAccionesMarketing1.ListaAccionesMarketing.Clear();
        }

        private void ResetGridAccMark()
        {
            try
            {
                if (dataGridViewAccMark.Rows.Count > 0)
                    dataGridViewAccMark.Rows.Clear();
                this.lblNumReg.Text = "0 / 0";
            }
            catch (Exception e)
            {
                string error = e.Message;
            }
        }


        /*
        private void CargarAccMark()
        {
            //---- GSG CECL 19/05/2016
            if (System.Configuration.ConfigurationManager.AppSettings["TipoDelegadoPedidosCentral"].ToString() == Comun.K_CECL)
            {
                sqlDataListaAccionesMarketing.SelectCommand = sqlCommand1CECL;
                chkVisita.Enabled = false;
            }
            else
            {
                sqlDataListaAccionesMarketing.SelectCommand = sqlCommand1;
                chkVisita.Enabled = true;
            }
            //---- FI GSG CECL

            //Inicialitza grid Acciones Marketing
            this.sqlDataListaAccionesMarketing.SelectCommand.Parameters["@sIdTipoAccion"].Value = "3";

            this.sqlDataListaAccionesMarketing.Fill(dsAccionesMarketing1);
            UpdateDataGridView("");
        }
        */

        public int GetMaxAccMark(float val)
        {
            int iRet = 0;
            SqlDataReader dr;
            dr = null;

            try
            {


                if (sqlConn.State.ToString() == "Closed")
                    sqlConn.Open();

                sqlCmdMaxAccMark.Parameters["@fImporte"].Value = val;
                dr = sqlCmdMaxAccMark.ExecuteReader();

                if (dr.Read())
                {
                    iRet = int.Parse(dr["iMaxNumAccMark"].ToString());
                }


            }
            catch (Exception e)
            {
                Mensajes.ShowError(e.ToString());
            }
            finally
            {
            }

            dr.Close();
            return iRet;
        }

        private List<ParejasExclusion> GetAccMarkExcluidas()
        {
            List<ParejasExclusion> lRet = new List<ParejasExclusion>();

            this.dsAccionesMarketing1.AccMarkExcluidas.Rows.Clear();

            this.sqldaAccMarkExcluidas.Fill(this.dsAccionesMarketing1);

            if (this.dsAccionesMarketing1.AccMarkExcluidas.Rows.Count > 0)
            {
                foreach (GESTCRM.Formularios.DataSets.dsAccionesMarketing.AccMarkExcluidasRow row in dsAccionesMarketing1.AccMarkExcluidas.Rows)
                {
                    ParejasExclusion pe = new ParejasExclusion(row.iIdAccion1, row.iIdAccion2);
                    lRet.Add(pe);
                }
            }

            return lRet;
        }


        //---- GSG (06/03/2021)
        private List<string> GetCodsAccMarkPedido(string sTipoPedido)
        {
            List<string> lRet = new List<string>();

            try
            {
                this.dsAccionesMarketing1.ListaCodigosAccMarkPicking.Rows.Clear();
                this.sqldaCodsAccMark.SelectCommand.Parameters["@sIdTipoPedido"].Value = sTipoPedido;

                this.sqldaCodsAccMark.Fill(this.dsAccionesMarketing1);

                if (this.dsAccionesMarketing1.ListaCodigosAccMarkPicking.Rows.Count > 0)
                {
                    foreach (GESTCRM.Formularios.DataSets.dsAccionesMarketing.ListaCodigosAccMarkPickingRow row in dsAccionesMarketing1.ListaCodigosAccMarkPicking.Rows)
                    {
                        lRet.Add(row.sIdAccion);
                    }
                }
            }
            catch (Exception error) { }

            return lRet;
        }





        private bool GetListaProductos()
        {
            bool bRet = false;

            this.dsFormularios1.ListaProductos.Rows.Clear();

            this.sqldaListaProductos.Fill(this.dsFormularios1);

            if (this.dsFormularios1.ListaProductos.Rows.Count > 0)
                bRet = true;

            return bRet;
        }

        //---- GSG (17/10/2016)
        private List<string> GetMaterialesZMKT()
        {
            List<string> lsRet = new List<string>();

            this.dsMateriales1.ListaMatsZMKT.Rows.Clear();

            if (sqlConn.State == ConnectionState.Closed)
                this.sqlConn.Open();

            SqlTransaction sqlTran = this.sqlConn.BeginTransaction();
            this.sqlCmdListaMatsZMKT.Transaction = sqlTran;

            try
            {
                this.sqldaListaMatsZMKT.Fill(this.dsMateriales1);

                int iMats = dsMateriales1.ListaMatsZMKT.Rows.Count;

                for (int i = 0; i < dsMateriales1.ListaMatsZMKT.Rows.Count; i++)
                {
                    lsRet.Add(dsMateriales1.ListaMatsZMKT.Rows[i].ItemArray[0].ToString());
                }
            }
            catch (Exception e)
            {
                Mensajes.ShowError(e.Message);
            }

            this.sqlConn.Close();

            return lsRet;
        }

        private string[] MatsZMKTEnPedido()
        {
            List<string> ls = GetMaterialesZMKT();
            List<string> lsPed = new List<string>();

            for (int i = 0; i < dataGridViewLineas.Rows.Count; i++)
            {
                lsPed.Add(ls.Find(x => x == dataGridViewLineas.Rows[i].Cells["sIdMaterialDataGridViewTextBoxColumn"].Value.ToString()));
            }

            return lsPed.ToArray();
        }

        //---- GSG (11/07/2017)
        private void AplicarDescuentoCofares()
        {
            if (dataGridViewLineas.Rows.Count == 0)
                return;

            for (int i = 0; i < dataGridViewLineas.Rows.Count; i++)
            {
                ActualizarImporteLineaCofares(i);
                Application.DoEvents();
            }

            ActualizarTotales();
        }


        private void ActualizarImporteLineaCofares(int RowIndex)
        {
            // ver si hay que cambiar el descuento
            // si es más grande que el de cofares no lo tocamos
            // si es menor, ver si puede llevar ese descuento y si sí, cambiarlo

            double fDescuentoAplicado = double.Parse(dataGridViewLineas.Rows[RowIndex].Cells["ColDescuento"].Value.ToString()); //descuento aplicado            

            if (fDescuentoAplicado < Configuracion.fDescCofares)
            {
                double descuentoMAX = double.Parse(dataGridViewLineas.Rows[RowIndex].Cells["ColDescuentoMaximo"].Value.ToString()); // Descuento máximo permitido para el material según la campaña a la que pertenece

                if (Configuracion.fDescCofares <= descuentoMAX)
                {
                    // cambiar el descuento por el de cofares
                    dataGridViewLineas.Rows[RowIndex].Cells["ColDescuento"].Value = Configuracion.fDescCofares;

                    // actualizar el resto de campos de la línea 
                    int iCantidad = int.Parse(dataGridViewLineas.Rows[RowIndex].Cells["ColCantidad"].Value.ToString());
                    double fDescuento = double.Parse(dataGridViewLineas.Rows[RowIndex].Cells["ColDescuento"].Value.ToString()); //descuento recalculado
                    double PrecioUnitario = (double)dataGridViewLineas.Rows[RowIndex].Cells["ColPrecio"].Value;

                    //Sumamos el descuento general
                    fDescuento += DtoGeneral;

                    double PrecioBruto = iCantidad * PrecioUnitario;
                    double Descuento = PrecioBruto * fDescuento / 100;

                    double ImporteNeto = Math.Round(PrecioBruto - Descuento, 2); //Aquí tenemos el importe con el descuento de línea

                    dataGridViewLineas.Rows[RowIndex].Cells["ColPrecioBruto"].Value = PrecioBruto;
                    dataGridViewLineas.Rows[RowIndex].Cells["ColImporteLin"].Value = ImporteNeto;

                    // fDescMat = 
                    //            Si el material es financiado -->  Min(desc aplicado, desc en factura para el cliente)
                    //            No financialdo -->  Si DIR --> Min(desc aplicado, desc max material dir)
                    //                                Si TRA --> Min(desc aplicado, desc max material tra)
                    double fDescMat = double.Parse(dataGridViewLineas.Rows[RowIndex].Cells["ColfDescMat"].Value.ToString());
                    // Pondremos en variable fDescMat el valor adecuado para el cálculo del extra pero no lo cambiamos 

                    if (bool.Parse(dataGridViewLineas.Rows[RowIndex].Cells["bFinanciado"].Value.ToString()))
                    {
                        double descFactura = double.Parse(GetDescuentoFactura(this.iIdCliente));
                        if (descFactura > 0)
                        {
                            if (descFactura > fDescuento)
                                fDescMat = double.Parse(dataGridViewLineas.Rows[RowIndex].Cells["ColDescuento"].Value.ToString());
                            else
                                fDescMat = descFactura;
                        }
                        else //igual que no finan
                        {
                            double descuento = 0;
                            descuento = double.Parse(dataGridViewLineas.Rows[RowIndex].Cells["ColfDescuentoMaximoTRA"].Value.ToString());

                            if (descuento > fDescuento)
                                fDescMat = fDescuento;
                            else
                                fDescMat = descuento;
                        }
                    }
                    else //No financiado
                    {
                        double descuento = 0;
                        descuento = double.Parse(dataGridViewLineas.Rows[RowIndex].Cells["ColfDescuentoMaximoTRA"].Value.ToString());

                        if (descuento > fDescuento)
                            fDescMat = fDescuento;
                        else
                            fDescMat = descuento;
                    }

                    dataGridViewLineas.Rows[RowIndex].Cells["ColfDescMat"].Value = fDescMat;

                    // CÁLCULO DEL EXTRA
                    // NO LO VOY A TOCAR AQUÍ YA QUE COMO TAMPOCO VIENE BIEN DE LA STORED, YA LO CALCULARÉ EN EL TOTAL DEL PEDIDO

                    ActualizarImporteMedioPedido(this.iIdCliente);
                }
            }


        }

        //---- GSG (13/03/2019)
        // Si cambia este valor ha habido un cambio en el pedido
        private void txbImporteBruto_TextChanged(object sender, EventArgs e)
        {
            //ResetAccMark();
        }

        private void txbDescExtra_TextChanged(object sender, EventArgs e)
        {

        }

        private void txbPVPIVA_TextChanged(object sender, EventArgs e)
        {

        }

        //---- GSG (03/07/2019)
        private void btEncuestas_Click(object sender, EventArgs e)
        {
            Encuestas(true);
        }


        private void Encuestas(bool abrir)
        {
            _bEncuesta = false;

            if (this.txtClienteSAP.Text.Trim() != "")
            {
                frmEncuesta frmEnc = new frmEncuesta(iIdDelegado, this.txtClienteSAP.Text);

                if (frmEnc.HayQueHacerlaSiOSi() || abrir)
                {
                    frmEnc.ShowDialog(this);

                    if (frmEnc.DialogResult == DialogResult.OK)
                    {
                        _bEncuesta = true;
                    }
                }
                else
                    _bEncuesta = true;
            }
            else
            {
                Mensajes.ShowInformation("Para acceder a las encuestas es necesario seleccionar un cliente.");
            }
        }


        private bool ProponerEncuesta()
        {
            bool bRet = false;

            if (this.txtClienteSAP.Text.Trim() != "")
            {
                frmEncuesta frmEnc = new frmEncuesta(iIdDelegado, this.txtClienteSAP.Text);

                if (frmEnc.EncuestaPendiente())
                {
                    bRet = true;
                }
            }

            return bRet;
        }

        //---- GSG (22/08/2019)
        private void dataGridViewLineas_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (_bErrorMostrat)
            {
                if (numericUpDownA.Visible == false)
                {
                    Mensajes.HideTip();

                    if (SetDefault == true)
                    {
                        dataGridViewLineas.CurrentCell.Value = DefaultValue;
                        SetDefault = false;
                    }

                    ActualizarImporteLinea(e.RowIndex);

                    //if (valorsCampanya(sender, e))
                    //    ActualizarTotales();
                }
            }
        }


        // En la v54 no activaremos esta funcionalidad. Lo dejamos para la siguiente
        private void button1_Click(object sender, EventArgs e)
        {
            /*
            if (txbIdPedido.Text.Trim() != "")
            {
                try
                {
                    //Document pdfDoc = new Document();
                    string fit = "c://stada//_temp//pdfGSG.pdf";
                    const String LOGO = "logo.jpg";

                    PdfWriter writer = new PdfWriter(fit);
                    PdfDocument pdfDoc = new PdfDocument(writer);
                    Document doc = new Document(pdfDoc);
                
                    string TextToPDF = "";
                    iText.Layout.Element.Image logo = new iText.Layout.Element.Image(ImageDataFactory.Create(LOGO));


                    foreach (DataGridViewRow row in dataGridViewLineas.Rows)
                    {
                        TextToPDF += row.Cells["sCodNacional"].Value.ToString();
                        TextToPDF += "\t";
                        TextToPDF += row.Cells["ColProducto"].Value.ToString();
                        TextToPDF += "\t";
                        TextToPDF += row.Cells["ColCantidad"].Value.ToString();
                        TextToPDF += "\n";
                    }

                    //doc.Add(new iText.Layout.Element.Paragraph(TextToPDF));

                    iText.Layout.Element.Paragraph p = new iText.Layout.Element.Paragraph("Pedido")
                    .Add(logo)
                    .Add(TextToPDF);

                    doc.Add(p);

                    doc.Close();


                }
                catch (Exception err)
                {
                    Mensajes.ShowError("Error al generar el PDF: " + err.Message);
                }


                
            }
            */
        }

        //---- GSG (02/02/2021)
        private void txtImpMedio_DoubleClick(object sender, EventArgs e)
        {
            /*
            if (txtClienteSAP.Text != "" && System.Configuration.ConfigurationManager.AppSettings["TipoDelegadoPedidosCentral"].ToString() != Comun.K_CECL)
            {
                Comun.showGraphPuntos(iIdCliente);
            }*/
        }

        private void btGrafPuntos_Click(object sender, EventArgs e)
        {

            if (txtClienteSAP.Text != "" && System.Configuration.ConfigurationManager.AppSettings["TipoDelegadoPedidosCentral"].ToString() != Comun.K_CECL)
            {
                Comun.showGraphPuntos(iIdCliente);
            }
        }


        //---- GSG (02/01/2023)
        private void cboClasico_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool bCambios = false;

            _iMinimos = cboClasico.SelectedValue.ToString() == null ? 0 : int.Parse(cboClasico.SelectedValue.ToString());  //0: clásico   1: mínimos

            if (_iMinimos == 1 && _bClickMinimos)
            {
                //Actualizar las cantidades a 1
                foreach (DataGridViewRow row in dataGridViewLineas.Rows)
                {
                    if (row.Cells["ColCantidad"].Value.ToString() != "1")
                    {
                        bCambios = true;
                        row.Cells["ColCantidad"].Value = 1;
                        ActualizarImporteLinea(row.Index);
                    }
                }

                if (bCambios)
                    ActualizarTotales();

                _bClickMinimos = false;
            }
        }


        private void cboClasico_MouseClick(object sender, MouseEventArgs e)
        {

            _bClickMinimos = true;
        }

        private void chkRetenido_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkRetenido.Checked)
                CorregirFechasPedido();
        }


        private void CorregirFechasPedido()
        {
            dtpFechaPedido.Value = DateTime.Today;
            string sTipoPedidoAux = _sTipoPedidoNew;

            if (sTipoPedidoAux == null || sTipoPedidoAux == "")
                sTipoPedidoAux = _sTipoPedido;

            if (sTipoPedidoAux == null || sTipoPedidoAux == "")
                sTipoPedidoAux = _sTipoPedidoOld;



            if ((sTipoPedidoAux == Comun.K_TIPOPED_DIRECTO || sTipoPedidoAux == Comun.K_TIPOPED_TRANSFER) && dtpFechaPref.Value < dtpFechaPedido.Value)
                dtpFechaPref.Value = dtpFechaPedido.Value;
            else if (sTipoPedidoAux == Comun.K_TIPOPED_COMPROMISO)
            {
                int daysDiff = Comun.GetWorkingDays(dtpFechaPedido.Value, dtpFechaPref.Value);

                if ((daysDiff > 0 && Clases.Configuracion.iDiasCompromiso > 0 && daysDiff > Clases.Configuracion.iDiasCompromiso) || daysDiff <= 0)
                {
                    dtpFechaPref.Value = dtpFechaPedido.Value.AddDays(Double.Parse(Clases.Configuracion.iDiasCompromiso.ToString()));
                    Mensajes.ShowInformation("Se ha modificado la fecha del compromiso. Revise que es la correcta");
                }




            }




        }

        //---- FI GSG 
    }





    //Mantiene los valores iniciales de cada línea del pedido original 
    public class QtyMat
    {
        public string sIdMaterial { get; set; }

        public int iCantidad { get; set; }

        public QtyMat(string mat, int qty)
        {
            this.sIdMaterial = mat;
            this.iCantidad = qty;
        }
    }

    //---- GSG (13/09/2016)
    // para decidir qué acciones de márketing aparecen en grid
    public class ValuesProd
    {
        public string sIdProducto { get; set; }
        public string sProducto { get; set; }
        public int iCantidad { get; set; }
        public float fImporte { get; set; }
        public float fRentabilidad { get; set; }

        public ValuesProd(string prod, string nombreProd, int qty, float imp, float renta)
        {
            this.sIdProducto = prod;
            this.sProducto = nombreProd;
            this.iCantidad = qty;
            this.fImporte = imp;
            this.fRentabilidad = renta;
        }
    }

    public class QtyAccMark
    {
        // Aunque el id de la acción es un entero lo guardo como una cadena
        public string idAccion { get; set; }

        public int iUnidades { get; set; }

        public QtyAccMark(string acc, int qty)
        {
            this.idAccion = acc;
            this.iUnidades = qty;
        }
    }

    public class ParejasExclusion
    {
        public int miembro_1 { get; set; }

        public int miembro_2 { get; set; }

        public ParejasExclusion(int m1, int m2)
        {
            this.miembro_1 = m1;
            this.miembro_2 = m2;
        }
    }

}

