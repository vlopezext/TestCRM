using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlTypes;
using System.Xml;
using System.Data;
using System.Threading; 
using System.IO;
using ICSharpCode.SharpZipLib.Zip.Compression;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Checksums; 
using System.Text; 
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace GESTCRM.Formularios
{
	/// <summary>
	/// Descripción breve de frmSincro.
	/// </summary>
	public class frmSincro : System.Windows.Forms.Form
	{
		#region Variables

        private System.Windows.Forms.Panel pnlSincro;
		private System.Windows.Forms.Panel pnlCabSincro;
		private System.Windows.Forms.Label lblCabSincro;
		private System.Windows.Forms.Label lblPaso1;
		private System.Windows.Forms.PictureBox pcbPaso1;
		private System.Windows.Forms.Label lblPaso2;
		private System.Windows.Forms.PictureBox pcbPaso2;
		private System.Windows.Forms.PictureBox pcbPaso3;
		private System.Windows.Forms.PictureBox pcbPaso4;
		private System.Windows.Forms.PictureBox pcbPaso5;
		private System.Windows.Forms.Label lblPaso6;
		private System.Windows.Forms.Label lblTotal;
		private System.Windows.Forms.PictureBox pcbPaso6;
		private System.Data.SqlClient.SqlConnection sqlConn;
		private System.Data.SqlClient.SqlCommand sqlCmdFUS;
		private System.ComponentModel.IContainer components;
		private System.Data.SqlClient.SqlCommand sqlCmdSincro;
		private WSSinCRM.dsCliente dsEnviarCEN;
		private WSSinCRM.dsRetorno dsRetorno;
		private WSSinCRM.dsRetorno dsBajada;
		private WSSinCRM.dsCentral dsRecibirCEN;
		private System.Windows.Forms.Button btnIniciar;
		private System.Windows.Forms.Button button1;
		private System.Data.SqlClient.SqlCommand sqlCmdSincroActEstado;
		private System.Data.SqlClient.SqlCommand sqlCmdUpdTipos;
		private System.Data.SqlClient.SqlCommand sqlCmdUpdLineasTipos;
		private System.Data.SqlClient.SqlCommand sqlCmdUpdMateriales;
		private System.Data.SqlClient.SqlCommand sqlCmdUpdProductos;
		private System.Data.SqlClient.SqlCommand sqlCmdUpdAccionesMark;
		private System.Data.SqlClient.SqlCommand sqlCmdUpdAtencionesComerciales;
		private System.Data.SqlClient.SqlCommand sqlCmdUpdPedidosCab;
		private System.Data.SqlClient.SqlCommand sqlCmdUpdPedidosLin;
        private System.Data.SqlClient.SqlCommand sqlCmdUpdPedAcciones; //---- GSG (08/10/2012)
		private System.Data.SqlClient.SqlCommand sqlCmdUpdClientes;
		private System.Data.SqlClient.SqlCommand sqlCmdUpdClientesSAP;
		private System.Data.SqlClient.SqlCommand sqlCmdUpdBricks;
		private System.Data.SqlClient.SqlCommand sqlCmdUpdDelegadoBrick;
		private System.Data.SqlClient.SqlCommand sqlCmdUpdBrickCP;
		private System.Data.SqlClient.SqlCommand sqlCmdUpdBrickClientes;
		private System.Data.SqlClient.SqlCommand sqlCmdUpdCPCLientes;
		private System.Data.SqlClient.SqlCommand sqlCmdUpdRepCab;
		private System.Data.SqlClient.SqlCommand sqlCmdUpdRepActCli;
		private System.Data.SqlClient.SqlCommand sqlCmdUpdRepActAten;
		private System.Data.SqlClient.SqlCommand sqlCmdUpdProxObj;
		private System.Data.SqlClient.SqlCommand sqlCmdUpdRepPed;
		private System.Data.SqlClient.SqlCommand sqlCmdUpdRepGad;
		private System.Data.SqlClient.SqlCommand sqlCmdSetNotaGasto;
		private System.Data.SqlClient.SqlCommand sqlCmdSetNotaGastoLin;
		private System.Data.SqlClient.SqlCommand sqlCmdSetAtenNG;
		private System.Data.SqlClient.SqlCommand sqlCmdUpdGastos;
		private System.Data.SqlClient.SqlCommand sqlCmdUpdPeriodosPresupuestos;
		private System.Data.SqlClient.SqlCommand sqlCmdUpdTipoCargoDelegado;
		private System.Data.SqlClient.SqlCommand sqlCmdUpdTiposPosPedidosSAP;
		private System.Data.SqlClient.SqlCommand sqlCmdUpdPromociones;
		private System.Data.SqlClient.SqlCommand sqlCmdUpdPromocionesProd;
		private System.Data.SqlClient.SqlCommand sqlCmdUpdDelegados;
		private System.Data.SqlClient.SqlCommand sqlCmdUpdCentros;
		private System.Data.SqlClient.SqlCommand sqlCmdUpdContactosClientesSAP;
		private System.Data.SqlClient.SqlCommand sqlCmdUpdCentrosClientesSAP;
		private System.Data.SqlClient.SqlCommand sqlCmdUpdInterlocutorClienteSAP;
		private System.Data.SqlClient.SqlCommand sqlCmdUpdClientesCOM;
		private System.Data.SqlClient.SqlCommand sqlCmdUpdEspecClientesCOM;
		private System.Data.SqlClient.SqlCommand sqlCmdUpdAficClientesCOM;
		private System.Data.SqlClient.SqlCommand sqlCmdUpdCentrosClientesCOM;
		private System.Data.SqlClient.SqlCommand sqlCmdUpdProdClientesCOM;
		private System.Data.SqlClient.SqlCommand sqlCmdUpdAccionesMarkClientes;
		private System.Data.SqlClient.SqlCommand sqlCmdUpdCentrosHorariosVisitas;
		private System.Data.SqlClient.SqlCommand sqlCmdUpdCodPostal;
		private System.Data.SqlClient.SqlCommand sqlCmdUpdPoblaciones;
		private System.Data.SqlClient.SqlCommand sqlCmdUpdPresupuestos;
		private System.Data.SqlClient.SqlTransaction sqlTran;
		private System.Data.SqlClient.SqlCommand sqlCmdAct;
		private System.Data.SqlClient.SqlCommand sqlCmdUpdAgenda;
		private System.Data.SqlClient.SqlDataAdapter sqlDADatosCliente;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
        private System.Data.SqlClient.SqlCommand sqlSelectCommand1CECL; //---- GSG CECL 19/05/2016
		private System.Data.SqlClient.SqlCommand sqlCmdUpdRedes;
		private System.Data.SqlClient.SqlCommand sqlCmdUpdDivisiones;
		private System.Data.SqlClient.SqlCommand sqlCmdUpdAccionesRedes;
		private System.Data.SqlClient.SqlCommand sqlCmdUpdCentrosRedes;
		private System.Data.SqlClient.SqlCommand sqlCmdUpdClientesRedes;
		private System.Data.SqlClient.SqlCommand sqlCmdUpdRepActProm;
		private System.Windows.Forms.Label lblpaso7;
		private System.Windows.Forms.PictureBox pcbPaso7;
		private System.Data.SqlClient.SqlCommand sqlCmdCompacta;
		private System.Data.SqlClient.SqlCommand sqlCmdUpdSolGad;
		private System.Windows.Forms.PictureBox pcbFinish7;
		private System.Windows.Forms.PictureBox pcbFinish6;
		private System.Windows.Forms.PictureBox pcbFinish5;
		private System.Windows.Forms.PictureBox pcbFinish4;
		private System.Windows.Forms.PictureBox pcbFinish3;
		private System.Windows.Forms.PictureBox pcbFinish2;
		private System.Windows.Forms.PictureBox pcbFinish1;
		private int iCurrentPaso=0;
		private System.Windows.Forms.Timer tmrStatus;
		private System.Windows.Forms.Label lblPaso3;
		private System.Windows.Forms.Label lblPaso5;
		private System.Windows.Forms.Label lblPaso4;
		private System.Windows.Forms.ProgressBar pgbPaso;
		private System.Windows.Forms.Label lblPaso8;
		private System.Windows.Forms.PictureBox pcbPaso8;
		private System.Windows.Forms.PictureBox pcbFinish8;
		private System.Data.SqlClient.SqlCommand sqlCmdEspecialidadesDelegado;
		private System.Data.SqlClient.SqlCommand sqlCmdEspecialidadesRedes;
		private System.Data.SqlClient.SqlCommand sqlCmdPromocionesRedes;
		private System.Data.SqlClient.SqlCommand sqlCmdUpdEstrucCom;
		private System.Data.SqlClient.SqlCommand sqlCmdUpdParrilla;
		private System.Data.SqlClient.SqlCommand sqlCmdUpdMaterialParrilla;
		private System.Data.SqlClient.SqlCommand sqlCmdUpdMaterialCamp;
		private System.Data.SqlClient.SqlCommand sqlCmdUpdAccionesComercialesProductos;
        private System.Data.SqlClient.SqlCommand sqlCmdUpdDescuento_Campanyas;
		private System.Data.SqlClient.SqlCommand sqlCmdUpdCampanyaMultiple;
		private System.Data.SqlClient.SqlCommand sqlCmdUpdMaterialesRentabilidad;
		private System.Data.SqlClient.SqlCommand sqlCmdUpdSincroEstructuraPDA;
		private System.Data.SqlClient.SqlCommand sqlCmdUpdTramosRentabilidad;
        private System.Data.SqlClient.SqlCommand sqlCmdUpdCampanyas;
        private System.Data.SqlClient.SqlCommand sqlCmdUpdArrastres;
        private System.Data.SqlClient.SqlCommand sqlCmdUpdPaquetes;
        private System.Data.SqlClient.SqlCommand sqlCmdUpdCampanyasCabecera;
        //---- GSG (08/04/2011)
        private System.Data.SqlClient.SqlCommand sqlCmdUpdProductosCampanya;
        private System.Data.SqlClient.SqlCommand sqlCmdUpdClubsAviso;
        //---- GSG (04/01/2012)
        private System.Data.SqlClient.SqlCommand sqlCmdUpdDescuento_Mayoristas;
        //---- GSG (22/03/2012)
        private System.Data.SqlClient.SqlCommand sqlCmdUpdCondicionesComercialesProductos;
        private System.Data.SqlClient.SqlCommand sqlCmdUpdCondicionesComercialesMateriales;
        private System.Data.SqlClient.SqlCommand sqlCmdUpdCondicionesComercialesGrupos;
        private System.Data.SqlClient.SqlCommand sqlCmdUpdCondicionesComerciales;
        //---- GSG (05/06/2013)
        private System.Data.SqlClient.SqlCommand sqlCmdUpdAccMarkCamp;
        //---- GSG (19/09/2013)
        private System.Data.SqlClient.SqlCommand sqlCmdUpdCostes;
        //---- GSG (08/05/2019)
        private System.Data.SqlClient.SqlCommand sqlCmdUpdComponentes;
        //---- GSG (01/10/2013)
        private System.Data.SqlClient.SqlCommand sqlCmdUpdMUV;
        //---- GSG (18/10/2013)
        private System.Data.SqlClient.SqlCommand sqlCmdUpdDescuentoMax;
        //---- GSG (23/10/2013)
        private System.Data.SqlClient.SqlCommand sqlCmdUpdDirectoZMAY;
        //---- GSG (18/11/2013)
        private System.Data.SqlClient.SqlCommand sqlCmdUpdCampanyasVisibles;
        //---- GSG (21/11/2013)
        private System.Data.SqlClient.SqlCommand sqlCmdUpdClientesOnLine;
        //---- GSG (09/01/2014)
        private System.Data.SqlClient.SqlCommand sqlCmdUpdEmailsClientes;
        //---- GSG (25/02/2014)
        private System.Data.SqlClient.SqlCommand sqlCmdUpdPedidosCentral;
        //---- GSG (15/10/2015)
        private System.Data.SqlClient.SqlCommand sqlCmdUpdTarjetasCliente;
        //---- GSG (04/11/2015)
        private System.Data.SqlClient.SqlCommand sqlCmdUpdAccMarkProd;
        //---- GSG (26/09/2016)
        private System.Data.SqlClient.SqlCommand sqlCmdUpdAccMarkRangos;
        private System.Data.SqlClient.SqlCommand sqlCmdUpdAccMarkExclusion;
        //---- GSG (24/08/2017)
        private System.Data.SqlClient.SqlCommand sqlCmdUpdGrupoCampanya;
        private System.Data.SqlClient.SqlCommand sqlCmdUpdReglasGruposCamp;
        //---- GSG (05/10/2017)
        private System.Data.SqlClient.SqlCommand sqlCmdUpdUbicaciones;
        //---- GSG (26/02/2018)
        private System.Data.SqlClient.SqlCommand sqlCmdUpdDivsPedidos;
        //---- GSG (03/07/2019)
        private System.Data.SqlClient.SqlCommand sqlCmdUpdSRVYEncuesta;
        private System.Data.SqlClient.SqlCommand sqlCmdUpdSRVYPregunta;
        private System.Data.SqlClient.SqlCommand sqlCmdUpdSRVYRespuesta;
        private System.Data.SqlClient.SqlCommand sqlCmdUpdSRVYClienteEncuesta;
        private System.Data.SqlClient.SqlCommand sqlCmdUpdSRVYClienteRespuesta;
        //---- GSG (06/03/2021)
        private System.Data.SqlClient.SqlCommand sqlCmdUpdGrupoHomogeneo;
        //---- GSG (03/01/2023)
        private System.Data.SqlClient.SqlCommand sqlCmdUpdMaterialBloquoDescuento;


        //---- FI GSG
        private IAsyncResult pAsync=null;
		private System.Data.SqlClient.SqlCommand sqlCmdUpdDatos_CRM_CLUB;
		#endregion

		public frmSincro()
		{
            InitializeComponent();


            //---- GSG (06/03/2021)
            Utiles.GetConfigConnection();
            this.sqlConn.ConnectionString = Utiles._connection.ConnectionString.ToString();

            

			this.dsEnviarCEN = new WSSinCRM.dsCliente(); 
			this.dsEnviarCEN.EnforceConstraints = false; 
			this.pcbFinish1.Image = SetImage("Stop.ico"); 
			this.pcbFinish1.Visible = true;
			this.pcbFinish2.Image = SetImage("Stop.ico");  
			this.pcbFinish2.Visible = true;
			this.pcbFinish3.Image = SetImage("Stop.ico");  
			this.pcbFinish3.Visible = true;
			this.pcbFinish4.Image = SetImage("Stop.ico");   
			this.pcbFinish4.Visible = true;
			this.pcbFinish5.Image = SetImage("Stop.ico");  
			this.pcbFinish5.Visible = true;
			this.pcbFinish6.Image = SetImage("Stop.ico");  
			this.pcbFinish6.Visible = true;
			this.pcbFinish7.Image = SetImage("Stop.ico");  
			this.pcbFinish7.Visible = true;
		}

		private Image SetImage(string image)
		{
			//return System.Drawing.Image.FromFile(Application.StartupPath + @"\Misc\"  + Image);
            image = image.Replace(".ico", String.Empty);
            Icon icono = (Icon)global::GESTCRM.Properties.Resources.ResourceManager.GetObject(image);
            return (Image)icono.ToBitmap();
		}

		/// <summary>
		/// Limpiar los recursos que se estén utilizando.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Código generado por el Diseñador de Windows Forms
		/// <summary>
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido del método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSincro));
            System.Configuration.AppSettingsReader configurationAppSettings = new System.Configuration.AppSettingsReader();
            this.button1 = new System.Windows.Forms.Button();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.pnlSincro = new System.Windows.Forms.Panel();
            this.pcbFinish8 = new System.Windows.Forms.PictureBox();
            this.pcbPaso8 = new System.Windows.Forms.PictureBox();
            this.lblPaso8 = new System.Windows.Forms.Label();
            this.pcbFinish7 = new System.Windows.Forms.PictureBox();
            this.pcbFinish6 = new System.Windows.Forms.PictureBox();
            this.pcbFinish5 = new System.Windows.Forms.PictureBox();
            this.pcbFinish4 = new System.Windows.Forms.PictureBox();
            this.pcbFinish3 = new System.Windows.Forms.PictureBox();
            this.pcbFinish2 = new System.Windows.Forms.PictureBox();
            this.pcbFinish1 = new System.Windows.Forms.PictureBox();
            this.pcbPaso7 = new System.Windows.Forms.PictureBox();
            this.lblpaso7 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.pgbPaso = new System.Windows.Forms.ProgressBar();
            this.pcbPaso6 = new System.Windows.Forms.PictureBox();
            this.lblPaso6 = new System.Windows.Forms.Label();
            this.pcbPaso5 = new System.Windows.Forms.PictureBox();
            this.lblPaso3 = new System.Windows.Forms.Label();
            this.pcbPaso4 = new System.Windows.Forms.PictureBox();
            this.lblPaso5 = new System.Windows.Forms.Label();
            this.pcbPaso3 = new System.Windows.Forms.PictureBox();
            this.lblPaso4 = new System.Windows.Forms.Label();
            this.pcbPaso2 = new System.Windows.Forms.PictureBox();
            this.lblPaso2 = new System.Windows.Forms.Label();
            this.pcbPaso1 = new System.Windows.Forms.PictureBox();
            this.lblPaso1 = new System.Windows.Forms.Label();
            this.pnlCabSincro = new System.Windows.Forms.Panel();
            this.lblCabSincro = new System.Windows.Forms.Label();
            this.sqlConn = new System.Data.SqlClient.SqlConnection();
            this.sqlCmdFUS = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdSincro = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdSincroActEstado = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdTipos = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdLineasTipos = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdMateriales = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdProductos = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdAccionesMark = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdAtencionesComerciales = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdPedidosCab = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdPedidosLin = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdPedAcciones = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdClientes = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdClientesSAP = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdBricks = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdDelegadoBrick = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdBrickCP = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdBrickClientes = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdCPCLientes = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdRepCab = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdRepActCli = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdRepActProm = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdRepActAten = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdProxObj = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdRepPed = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdRepGad = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdSetNotaGasto = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdSetNotaGastoLin = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdSetAtenNG = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdGastos = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdPeriodosPresupuestos = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdTipoCargoDelegado = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdTiposPosPedidosSAP = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdPromociones = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdPromocionesProd = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdDelegados = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdCentros = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdContactosClientesSAP = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdCentrosClientesSAP = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdInterlocutorClienteSAP = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdClientesCOM = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdEspecClientesCOM = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdAficClientesCOM = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdCentrosClientesCOM = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdProdClientesCOM = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdAccionesMarkClientes = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdCentrosHorariosVisitas = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdCodPostal = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdPoblaciones = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdPresupuestos = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdAct = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdAgenda = new System.Data.SqlClient.SqlCommand();
            this.sqlDADatosCliente = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlSelectCommand1CECL = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdRedes = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdDivisiones = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdAccionesRedes = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdCentrosRedes = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdClientesRedes = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdCompacta = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdSolGad = new System.Data.SqlClient.SqlCommand();
            this.tmrStatus = new System.Windows.Forms.Timer(this.components);
            this.sqlCmdEspecialidadesDelegado = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdEspecialidadesRedes = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdPromocionesRedes = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdEstrucCom = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdParrilla = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdMaterialParrilla = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdMaterialCamp = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdAccionesComercialesProductos = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdDescuento_Campanyas = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdCampanyaMultiple = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdMaterialesRentabilidad = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdSincroEstructuraPDA = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdTramosRentabilidad = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdCampanyas = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdArrastres = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdPaquetes = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdCampanyasCabecera = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdDatos_CRM_CLUB = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdProductosCampanya = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdClubsAviso = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdDescuento_Mayoristas = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdCondicionesComercialesProductos = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdCondicionesComercialesMateriales = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdCondicionesComercialesGrupos = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdCondicionesComerciales = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdAccMarkCamp = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdCostes = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdComponentes = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdMUV = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdDescuentoMax = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdDirectoZMAY = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdCampanyasVisibles = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdClientesOnLine = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdEmailsClientes = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdPedidosCentral = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdTarjetasCliente = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdAccMarkProd = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdAccMarkRangos = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdAccMarkExclusion = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdGrupoCampanya = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdReglasGruposCamp = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdUbicaciones = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdDivsPedidos = new System.Data.SqlClient.SqlCommand();
            //---- GSG (03/07/2019)
            this.sqlCmdUpdSRVYEncuesta = new System.Data.SqlClient.SqlCommand(); 
            this.sqlCmdUpdSRVYPregunta = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdSRVYRespuesta = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdSRVYClienteEncuesta = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdUpdSRVYClienteRespuesta = new System.Data.SqlClient.SqlCommand();
            //---- GSG (06/03/2021)
            this.sqlCmdUpdGrupoHomogeneo = new System.Data.SqlClient.SqlCommand();
            //---- GSG (03/01/2023)
            this.sqlCmdUpdMaterialBloquoDescuento = new System.Data.SqlClient.SqlCommand();


            this.pnlSincro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbFinish8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbPaso8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbFinish7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbFinish6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbFinish5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbFinish4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbFinish3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbFinish2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbFinish1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbPaso7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbPaso6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbPaso5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbPaso4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbPaso3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbPaso2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbPaso1)).BeginInit();
            this.pnlCabSincro.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::GESTCRM.Properties.Resources.cancel_032x032;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(335, 304);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 40);
            this.button1.TabIndex = 40;
            this.button1.Text = "Cancelar";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.pcbSalir_Click);
            // 
            // btnIniciar
            // 
            this.btnIniciar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIniciar.Image = global::GESTCRM.Properties.Resources.reload_032x032;
            this.btnIniciar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIniciar.Location = new System.Drawing.Point(146, 304);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(100, 40);
            this.btnIniciar.TabIndex = 39;
            this.btnIniciar.Text = "Iniciar  ";
            this.btnIniciar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnIniciar.UseVisualStyleBackColor = true;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // pnlSincro
            // 
            this.pnlSincro.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlSincro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSincro.Controls.Add(this.pcbFinish8);
            this.pnlSincro.Controls.Add(this.pcbPaso8);
            this.pnlSincro.Controls.Add(this.lblPaso8);
            this.pnlSincro.Controls.Add(this.pcbFinish7);
            this.pnlSincro.Controls.Add(this.pcbFinish6);
            this.pnlSincro.Controls.Add(this.pcbFinish5);
            this.pnlSincro.Controls.Add(this.pcbFinish4);
            this.pnlSincro.Controls.Add(this.pcbFinish3);
            this.pnlSincro.Controls.Add(this.pcbFinish2);
            this.pnlSincro.Controls.Add(this.pcbFinish1);
            this.pnlSincro.Controls.Add(this.pcbPaso7);
            this.pnlSincro.Controls.Add(this.lblpaso7);
            this.pnlSincro.Controls.Add(this.lblTotal);
            this.pnlSincro.Controls.Add(this.pgbPaso);
            this.pnlSincro.Controls.Add(this.pcbPaso6);
            this.pnlSincro.Controls.Add(this.lblPaso6);
            this.pnlSincro.Controls.Add(this.pcbPaso5);
            this.pnlSincro.Controls.Add(this.lblPaso3);
            this.pnlSincro.Controls.Add(this.pcbPaso4);
            this.pnlSincro.Controls.Add(this.lblPaso5);
            this.pnlSincro.Controls.Add(this.pcbPaso3);
            this.pnlSincro.Controls.Add(this.lblPaso4);
            this.pnlSincro.Controls.Add(this.pcbPaso2);
            this.pnlSincro.Controls.Add(this.lblPaso2);
            this.pnlSincro.Controls.Add(this.pcbPaso1);
            this.pnlSincro.Controls.Add(this.lblPaso1);
            this.pnlSincro.Controls.Add(this.pnlCabSincro);
            this.pnlSincro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlSincro.Location = new System.Drawing.Point(0, 0);
            this.pnlSincro.Name = "pnlSincro";
            this.pnlSincro.Size = new System.Drawing.Size(578, 286);
            this.pnlSincro.TabIndex = 30;
            // 
            // pcbFinish8
            // 
            this.pcbFinish8.Image = ((System.Drawing.Image)(resources.GetObject("pcbFinish8.Image")));
            this.pcbFinish8.Location = new System.Drawing.Point(43, 202);
            this.pcbFinish8.Name = "pcbFinish8";
            this.pcbFinish8.Size = new System.Drawing.Size(16, 16);
            this.pcbFinish8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbFinish8.TabIndex = 49;
            this.pcbFinish8.TabStop = false;
            this.pcbFinish8.Visible = false;
            // 
            // pcbPaso8
            // 
            this.pcbPaso8.Image = ((System.Drawing.Image)(resources.GetObject("pcbPaso8.Image")));
            this.pcbPaso8.Location = new System.Drawing.Point(19, 202);
            this.pcbPaso8.Name = "pcbPaso8";
            this.pcbPaso8.Size = new System.Drawing.Size(16, 16);
            this.pcbPaso8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbPaso8.TabIndex = 48;
            this.pcbPaso8.TabStop = false;
            this.pcbPaso8.Visible = false;
            // 
            // lblPaso8
            // 
            this.lblPaso8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaso8.Location = new System.Drawing.Point(64, 200);
            this.lblPaso8.Name = "lblPaso8";
            this.lblPaso8.Size = new System.Drawing.Size(491, 20);
            this.lblPaso8.TabIndex = 47;
            this.lblPaso8.Text = "8 . Recibiendo Actualizaciones de la Aplicación";
            this.lblPaso8.Visible = false;
            // 
            // pcbFinish7
            // 
            this.pcbFinish7.Image = ((System.Drawing.Image)(resources.GetObject("pcbFinish7.Image")));
            this.pcbFinish7.Location = new System.Drawing.Point(43, 178);
            this.pcbFinish7.Name = "pcbFinish7";
            this.pcbFinish7.Size = new System.Drawing.Size(16, 16);
            this.pcbFinish7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbFinish7.TabIndex = 46;
            this.pcbFinish7.TabStop = false;
            this.pcbFinish7.Visible = false;
            // 
            // pcbFinish6
            // 
            this.pcbFinish6.Image = ((System.Drawing.Image)(resources.GetObject("pcbFinish6.Image")));
            this.pcbFinish6.Location = new System.Drawing.Point(43, 154);
            this.pcbFinish6.Name = "pcbFinish6";
            this.pcbFinish6.Size = new System.Drawing.Size(16, 16);
            this.pcbFinish6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbFinish6.TabIndex = 45;
            this.pcbFinish6.TabStop = false;
            this.pcbFinish6.Visible = false;
            // 
            // pcbFinish5
            // 
            this.pcbFinish5.Image = ((System.Drawing.Image)(resources.GetObject("pcbFinish5.Image")));
            this.pcbFinish5.Location = new System.Drawing.Point(43, 130);
            this.pcbFinish5.Name = "pcbFinish5";
            this.pcbFinish5.Size = new System.Drawing.Size(16, 16);
            this.pcbFinish5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbFinish5.TabIndex = 44;
            this.pcbFinish5.TabStop = false;
            this.pcbFinish5.Visible = false;
            // 
            // pcbFinish4
            // 
            this.pcbFinish4.Image = ((System.Drawing.Image)(resources.GetObject("pcbFinish4.Image")));
            this.pcbFinish4.Location = new System.Drawing.Point(43, 106);
            this.pcbFinish4.Name = "pcbFinish4";
            this.pcbFinish4.Size = new System.Drawing.Size(16, 16);
            this.pcbFinish4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbFinish4.TabIndex = 43;
            this.pcbFinish4.TabStop = false;
            this.pcbFinish4.Visible = false;
            // 
            // pcbFinish3
            // 
            this.pcbFinish3.Image = ((System.Drawing.Image)(resources.GetObject("pcbFinish3.Image")));
            this.pcbFinish3.Location = new System.Drawing.Point(43, 82);
            this.pcbFinish3.Name = "pcbFinish3";
            this.pcbFinish3.Size = new System.Drawing.Size(16, 16);
            this.pcbFinish3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbFinish3.TabIndex = 42;
            this.pcbFinish3.TabStop = false;
            this.pcbFinish3.Visible = false;
            // 
            // pcbFinish2
            // 
            this.pcbFinish2.Image = ((System.Drawing.Image)(resources.GetObject("pcbFinish2.Image")));
            this.pcbFinish2.Location = new System.Drawing.Point(43, 58);
            this.pcbFinish2.Name = "pcbFinish2";
            this.pcbFinish2.Size = new System.Drawing.Size(16, 16);
            this.pcbFinish2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbFinish2.TabIndex = 41;
            this.pcbFinish2.TabStop = false;
            this.pcbFinish2.Visible = false;
            // 
            // pcbFinish1
            // 
            this.pcbFinish1.Image = ((System.Drawing.Image)(resources.GetObject("pcbFinish1.Image")));
            this.pcbFinish1.Location = new System.Drawing.Point(43, 34);
            this.pcbFinish1.Name = "pcbFinish1";
            this.pcbFinish1.Size = new System.Drawing.Size(16, 16);
            this.pcbFinish1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbFinish1.TabIndex = 40;
            this.pcbFinish1.TabStop = false;
            this.pcbFinish1.Visible = false;
            // 
            // pcbPaso7
            // 
            this.pcbPaso7.Image = ((System.Drawing.Image)(resources.GetObject("pcbPaso7.Image")));
            this.pcbPaso7.Location = new System.Drawing.Point(19, 178);
            this.pcbPaso7.Name = "pcbPaso7";
            this.pcbPaso7.Size = new System.Drawing.Size(16, 16);
            this.pcbPaso7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbPaso7.TabIndex = 39;
            this.pcbPaso7.TabStop = false;
            // 
            // lblpaso7
            // 
            this.lblpaso7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblpaso7.Location = new System.Drawing.Point(65, 176);
            this.lblpaso7.Name = "lblpaso7";
            this.lblpaso7.Size = new System.Drawing.Size(503, 20);
            this.lblpaso7.TabIndex = 38;
            this.lblpaso7.Text = "7. Actualizando la Base de Datos y enviando los resultados a Central.";
            // 
            // lblTotal
            // 
            this.lblTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTotal.Location = new System.Drawing.Point(16, 234);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(539, 20);
            this.lblTotal.TabIndex = 36;
            this.lblTotal.Text = "Progreso Total de la Sincronización.";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTotal.Visible = false;
            // 
            // pgbPaso
            // 
            this.pgbPaso.Location = new System.Drawing.Point(16, 255);
            this.pgbPaso.Maximum = 750;
            this.pgbPaso.Name = "pgbPaso";
            this.pgbPaso.Size = new System.Drawing.Size(539, 18);
            this.pgbPaso.Step = 100;
            this.pgbPaso.TabIndex = 34;
            this.pgbPaso.Visible = false;
            // 
            // pcbPaso6
            // 
            this.pcbPaso6.Image = ((System.Drawing.Image)(resources.GetObject("pcbPaso6.Image")));
            this.pcbPaso6.Location = new System.Drawing.Point(19, 154);
            this.pcbPaso6.Name = "pcbPaso6";
            this.pcbPaso6.Size = new System.Drawing.Size(16, 16);
            this.pcbPaso6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbPaso6.TabIndex = 33;
            this.pcbPaso6.TabStop = false;
            // 
            // lblPaso6
            // 
            this.lblPaso6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaso6.Location = new System.Drawing.Point(64, 152);
            this.lblPaso6.Name = "lblPaso6";
            this.lblPaso6.Size = new System.Drawing.Size(344, 20);
            this.lblPaso6.TabIndex = 32;
            this.lblPaso6.Text = "6. Procesando informacion recibida de Central.";
            // 
            // pcbPaso5
            // 
            this.pcbPaso5.Image = ((System.Drawing.Image)(resources.GetObject("pcbPaso5.Image")));
            this.pcbPaso5.Location = new System.Drawing.Point(19, 82);
            this.pcbPaso5.Name = "pcbPaso5";
            this.pcbPaso5.Size = new System.Drawing.Size(16, 16);
            this.pcbPaso5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbPaso5.TabIndex = 31;
            this.pcbPaso5.TabStop = false;
            // 
            // lblPaso3
            // 
            this.lblPaso3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaso3.Location = new System.Drawing.Point(64, 80);
            this.lblPaso3.Name = "lblPaso3";
            this.lblPaso3.Size = new System.Drawing.Size(344, 21);
            this.lblPaso3.TabIndex = 30;
            this.lblPaso3.Text = "3. Obteniendo información de Central.";
            // 
            // pcbPaso4
            // 
            this.pcbPaso4.Image = ((System.Drawing.Image)(resources.GetObject("pcbPaso4.Image")));
            this.pcbPaso4.Location = new System.Drawing.Point(19, 130);
            this.pcbPaso4.Name = "pcbPaso4";
            this.pcbPaso4.Size = new System.Drawing.Size(16, 16);
            this.pcbPaso4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbPaso4.TabIndex = 29;
            this.pcbPaso4.TabStop = false;
            // 
            // lblPaso5
            // 
            this.lblPaso5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaso5.Location = new System.Drawing.Point(64, 128);
            this.lblPaso5.Name = "lblPaso5";
            this.lblPaso5.Size = new System.Drawing.Size(336, 20);
            this.lblPaso5.TabIndex = 28;
            this.lblPaso5.Text = "5. Enviando información a Central.";
            // 
            // pcbPaso3
            // 
            this.pcbPaso3.Image = ((System.Drawing.Image)(resources.GetObject("pcbPaso3.Image")));
            this.pcbPaso3.Location = new System.Drawing.Point(19, 106);
            this.pcbPaso3.Name = "pcbPaso3";
            this.pcbPaso3.Size = new System.Drawing.Size(16, 16);
            this.pcbPaso3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbPaso3.TabIndex = 27;
            this.pcbPaso3.TabStop = false;
            // 
            // lblPaso4
            // 
            this.lblPaso4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaso4.Location = new System.Drawing.Point(64, 104);
            this.lblPaso4.Name = "lblPaso4";
            this.lblPaso4.Size = new System.Drawing.Size(344, 20);
            this.lblPaso4.TabIndex = 26;
            this.lblPaso4.Text = "4. Generando información a enviar a Central.";
            // 
            // pcbPaso2
            // 
            this.pcbPaso2.Image = ((System.Drawing.Image)(resources.GetObject("pcbPaso2.Image")));
            this.pcbPaso2.Location = new System.Drawing.Point(19, 58);
            this.pcbPaso2.Name = "pcbPaso2";
            this.pcbPaso2.Size = new System.Drawing.Size(16, 16);
            this.pcbPaso2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbPaso2.TabIndex = 25;
            this.pcbPaso2.TabStop = false;
            // 
            // lblPaso2
            // 
            this.lblPaso2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaso2.Location = new System.Drawing.Point(64, 56);
            this.lblPaso2.Name = "lblPaso2";
            this.lblPaso2.Size = new System.Drawing.Size(376, 20);
            this.lblPaso2.TabIndex = 24;
            this.lblPaso2.Text = "2. Obteniendo parámetros de sincronización.";
            // 
            // pcbPaso1
            // 
            this.pcbPaso1.Image = ((System.Drawing.Image)(resources.GetObject("pcbPaso1.Image")));
            this.pcbPaso1.Location = new System.Drawing.Point(19, 34);
            this.pcbPaso1.Name = "pcbPaso1";
            this.pcbPaso1.Size = new System.Drawing.Size(16, 16);
            this.pcbPaso1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbPaso1.TabIndex = 23;
            this.pcbPaso1.TabStop = false;
            // 
            // lblPaso1
            // 
            this.lblPaso1.AutoSize = true;
            this.lblPaso1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaso1.Location = new System.Drawing.Point(64, 32);
            this.lblPaso1.Name = "lblPaso1";
            this.lblPaso1.Size = new System.Drawing.Size(202, 20);
            this.lblPaso1.TabIndex = 22;
            this.lblPaso1.Text = "1. Conectando con Central.";
            // 
            // pnlCabSincro
            // 
            this.pnlCabSincro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.pnlCabSincro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCabSincro.Controls.Add(this.lblCabSincro);
            this.pnlCabSincro.Location = new System.Drawing.Point(-1, -1);
            this.pnlCabSincro.Name = "pnlCabSincro";
            this.pnlCabSincro.Size = new System.Drawing.Size(578, 24);
            this.pnlCabSincro.TabIndex = 21;
            // 
            // lblCabSincro
            // 
            this.lblCabSincro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCabSincro.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblCabSincro.Location = new System.Drawing.Point(8, 0);
            this.lblCabSincro.Name = "lblCabSincro";
            this.lblCabSincro.Size = new System.Drawing.Size(320, 23);
            this.lblCabSincro.TabIndex = 0;
            this.lblCabSincro.Text = "Proceso de sincronización con Central";
            // 
            // sqlConn
            // 
            this.sqlConn.ConnectionString = Utiles._connection.ConnectionString.ToString();   //---- GSG (06/03/2021)
            this.sqlConn.FireInfoMessageEventOnUserErrors = false;
            // 
            // sqlCmdFUS
            // 
            this.sqlCmdFUS.CommandText = "[SetConfiguracion]";
            this.sqlCmdFUS.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdFUS.Connection = this.sqlConn;
            this.sqlCmdFUS.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdConfig", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sValor", System.Data.SqlDbType.VarChar, 30)});
            // 
            // sqlCmdSincro
            // 
            this.sqlCmdSincro.Connection = this.sqlConn;
            // 
            // sqlCmdSincroActEstado
            // 
            this.sqlCmdSincroActEstado.CommandText = "[SincroActEstado]";
            this.sqlCmdSincroActEstado.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdSincroActEstado.Connection = this.sqlConn;
            this.sqlCmdSincroActEstado.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdTable", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@dInitDate", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@dEndDate", System.Data.SqlDbType.VarChar, 20)});
            // 
            // sqlCmdUpdTipos
            // 
            this.sqlCmdUpdTipos.CommandText = "[WSCliUpdTipos]";
            this.sqlCmdUpdTipos.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdTipos.Connection = this.sqlConn;
            this.sqlCmdUpdTipos.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdTipo", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sTipo", System.Data.SqlDbType.VarChar, 50),
            new System.Data.SqlClient.SqlParameter("@dFUM", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt, 2)});
            // 
            // sqlCmdUpdLineasTipos
            // 
            this.sqlCmdUpdLineasTipos.CommandText = "[WSCliUpdLineasTipos]";
            this.sqlCmdUpdLineasTipos.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdLineasTipos.Connection = this.sqlConn;
            this.sqlCmdUpdLineasTipos.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdTipo", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iOrden", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sValor", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@sLiteral", System.Data.SqlDbType.VarChar, 50),
            new System.Data.SqlClient.SqlParameter("@dFUM", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt, 2)});
            // 
            // sqlCmdUpdMateriales
            // 
            this.sqlCmdUpdMateriales.CommandText = "[WSCliUpdMateriales]";
            this.sqlCmdUpdMateriales.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdMateriales.Connection = this.sqlConn;
            this.sqlCmdUpdMateriales.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@sIdMaterial", System.Data.SqlDbType.VarChar, 18),
            new System.Data.SqlClient.SqlParameter("@sOrgVentas", System.Data.SqlDbType.VarChar, 4),
            new System.Data.SqlClient.SqlParameter("@sCanalDistrib", System.Data.SqlDbType.VarChar, 2),
            new System.Data.SqlClient.SqlParameter("@sMaterial", System.Data.SqlDbType.VarChar, 50),
            new System.Data.SqlClient.SqlParameter("@sCodNacional", System.Data.SqlDbType.VarChar, 6),
            new System.Data.SqlClient.SqlParameter("@fPrecio", System.Data.SqlDbType.Float, 8),
            new System.Data.SqlClient.SqlParameter("@sMoneda", System.Data.SqlDbType.VarChar, 5),
            new System.Data.SqlClient.SqlParameter("@iCantidadBase", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sUnidadBase", System.Data.SqlDbType.VarChar, 3),
            new System.Data.SqlClient.SqlParameter("@dFechaIni", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@dFechaFin", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@dFUM", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt, 2),
            new System.Data.SqlClient.SqlParameter("@sIdProducto", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@sIdDivision", System.Data.SqlDbType.VarChar, 2),
            new System.Data.SqlClient.SqlParameter("@sIdRed", System.Data.SqlDbType.VarChar, 4),
            new System.Data.SqlClient.SqlParameter("@fDescuentoMaximo", System.Data.SqlDbType.Float, 8),
            new System.Data.SqlClient.SqlParameter("@sTipoMat", System.Data.SqlDbType.VarChar, 4),
            new System.Data.SqlClient.SqlParameter("@iStock", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@dEntrega", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@iPendientes", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iUnidadesEnfajado", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iCajaCompleta", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sTipoMatInformes", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@bActivoInformes", System.Data.SqlDbType.Bit, 1),
            new System.Data.SqlClient.SqlParameter("@bConVale", System.Data.SqlDbType.Bit, 1),
            new System.Data.SqlClient.SqlParameter("@bFinanciado", System.Data.SqlDbType.Bit, 1),
            new System.Data.SqlClient.SqlParameter("@bMedicamento", System.Data.SqlDbType.Bit, 1),
            new System.Data.SqlClient.SqlParameter("@fDescuentoMaximoTRA", System.Data.SqlDbType.Float, 8),
            new System.Data.SqlClient.SqlParameter("@fPVP", System.Data.SqlDbType.Float, 8),
            new System.Data.SqlClient.SqlParameter("@fPVPIVA", System.Data.SqlDbType.Float, 8),
            new System.Data.SqlClient.SqlParameter("@iStockCanarias", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iPendientesCanarias", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iBlockTipoPedido", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iBlockCanarias", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iBlockTipoPedidoDIR", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iBlockTipoPedidoTRA", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iBlockTipoPedidoKE", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iBlockTipoPedidoKB", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iBlockTipoPedidoZCR", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sTipoProdInformes", System.Data.SqlDbType.VarChar, 10)});
            // 
            // sqlCmdUpdProductos
            // 
            this.sqlCmdUpdProductos.CommandText = "[WSCliUpdProductos]";
            this.sqlCmdUpdProductos.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdProductos.Connection = this.sqlConn;
            this.sqlCmdUpdProductos.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@sIdProducto", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@sDescripcion", System.Data.SqlDbType.VarChar, 50),
            new System.Data.SqlClient.SqlParameter("@dFUM", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt, 2)});
            // 
            // sqlCmdUpdAccionesMark
            // 
            this.sqlCmdUpdAccionesMark.CommandText = "[WSCliUpdAccionesMark]";
            this.sqlCmdUpdAccionesMark.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdAccionesMark.Connection = this.sqlConn;
            this.sqlCmdUpdAccionesMark.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdAccion", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sIdAccion", System.Data.SqlDbType.VarChar, 15),
            new System.Data.SqlClient.SqlParameter("@sDescAccion", System.Data.SqlDbType.VarChar, 50),
            new System.Data.SqlClient.SqlParameter("@sIdTipoAccion", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@dFechaCreacion", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@dFechaIni", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@dFechaFin", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@iUnidades", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@fCosteUnitario", System.Data.SqlDbType.Float, 8),
            new System.Data.SqlClient.SqlParameter("@fCosteTotal", System.Data.SqlDbType.Float, 8),
            new System.Data.SqlClient.SqlParameter("@sObservaciones", System.Data.SqlDbType.VarChar, 300),
            new System.Data.SqlClient.SqlParameter("@sIdTipoImputacion", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@dFUM", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt, 2),
            new System.Data.SqlClient.SqlParameter("@iNumElemEntregar", System.Data.SqlDbType.Int),
            new System.Data.SqlClient.SqlParameter("@fImpMin", System.Data.SqlDbType.Float, 8),
            new System.Data.SqlClient.SqlParameter("@fImpMax", System.Data.SqlDbType.Float, 8),
            new System.Data.SqlClient.SqlParameter("@iMaxAEntregar", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@Multiplicador", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@bIndepe", System.Data.SqlDbType.Bit, 1),
            new System.Data.SqlClient.SqlParameter("@sIdProducto", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@bSuma", System.Data.SqlDbType.Bit, 1),
            new System.Data.SqlClient.SqlParameter("@iActivoPara", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@fRentabilidad", System.Data.SqlDbType.Float, 8)});
            // 
            // sqlCmdUpdAtencionesComerciales
            // 
            this.sqlCmdUpdAtencionesComerciales.CommandText = "[WSCliUpdAtencionesComerciales]";
            this.sqlCmdUpdAtencionesComerciales.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdAtencionesComerciales.Connection = this.sqlConn;
            this.sqlCmdUpdAtencionesComerciales.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdAtencion", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sIdAtencionTemp", System.Data.SqlDbType.VarChar, 15),
            new System.Data.SqlClient.SqlParameter("@sIdAtencion", System.Data.SqlDbType.VarChar, 20),
            new System.Data.SqlClient.SqlParameter("@sDescripcion", System.Data.SqlDbType.VarChar, 50),
            new System.Data.SqlClient.SqlParameter("@tObservaciones", System.Data.SqlDbType.VarChar, 8000),
            new System.Data.SqlClient.SqlParameter("@sIdTipoAtencion", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@bBolsaViaje", System.Data.SqlDbType.Bit, 1),
            new System.Data.SqlClient.SqlParameter("@bLiqNotaGastos", System.Data.SqlDbType.Bit, 1),
            new System.Data.SqlClient.SqlParameter("@sIdCentroCoste", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@iIdDelegado", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sIdEstAtencion", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@fImportePrev", System.Data.SqlDbType.Float, 8),
            new System.Data.SqlClient.SqlParameter("@fImporteReal", System.Data.SqlDbType.Float, 8),
            new System.Data.SqlClient.SqlParameter("@dFechaCreacion", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@dFechaPrev", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@dFechaAprob1", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@dFechaAprob2", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@dFechaReal", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@dFechaLiq", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@dFechaCierre", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@sUsuAprob1", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@sUsuAprob2", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@sUsuLiq", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@dFUM", System.Data.SqlDbType.DateTime, 8), 
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt, 2),
            new System.Data.SqlClient.SqlParameter("@bEnviadoCEN", System.Data.SqlDbType.Bit, 1),
            new System.Data.SqlClient.SqlParameter("@dFechaAprob3", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@dFechaAprob4", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@sUsuAprob3", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@sUsuAprob4", System.Data.SqlDbType.VarChar, 10)});
            // 
            // sqlCmdUpdPedidosCab
            // 
            this.sqlCmdUpdPedidosCab.CommandText = "[WSCliUpdPedidos_Cab]";
            this.sqlCmdUpdPedidosCab.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdPedidosCab.Connection = this.sqlConn;
            this.sqlCmdUpdPedidosCab.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@sIdPedido", System.Data.SqlDbType.VarChar, 12),
            new System.Data.SqlClient.SqlParameter("@sIdPedidoTemp", System.Data.SqlDbType.VarChar, 15),
            new System.Data.SqlClient.SqlParameter("@iIdDelegado", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sIdTipoPedido", System.Data.SqlDbType.VarChar, 4),
            new System.Data.SqlClient.SqlParameter("@sIdEstEntPedido", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@sIdEstFacPedido", System.Data.SqlDbType.VarChar, 10),
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
            new System.Data.SqlClient.SqlParameter("@tObservaciones", System.Data.SqlDbType.VarChar, 300),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt, 2),
            new System.Data.SqlClient.SqlParameter("@fFUM", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@fDescuentoCampanya", System.Data.SqlDbType.Float, 8),
            new System.Data.SqlClient.SqlParameter("@fDescuentoAdicional", System.Data.SqlDbType.Float, 8),
            new System.Data.SqlClient.SqlParameter("@fRentabilidad", System.Data.SqlDbType.Float, 8),
            new System.Data.SqlClient.SqlParameter("@iIdAccion", System.Data.SqlDbType.Int),
            new System.Data.SqlClient.SqlParameter("@sCondPago", System.Data.SqlDbType.VarChar, 4),
            new System.Data.SqlClient.SqlParameter("@sPrioridad", System.Data.SqlDbType.VarChar, 2),
            new System.Data.SqlClient.SqlParameter("@dFechaFacturacion", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@sTipoPedidoCompromiso", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@sTipoGestionCompromiso", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@sCPCompra", System.Data.SqlDbType.VarChar, 5),
            new System.Data.SqlClient.SqlParameter("@idUbicacion", System.Data.SqlDbType.Int)});
            // 
            // sqlCmdUpdPedidosLin
            // 
            this.sqlCmdUpdPedidosLin.CommandText = "[WSCliUpdPedidos_Lin]";
            this.sqlCmdUpdPedidosLin.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdPedidosLin.Connection = this.sqlConn;
            this.sqlCmdUpdPedidosLin.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@sIdPedido", System.Data.SqlDbType.VarChar, 12),
            new System.Data.SqlClient.SqlParameter("@iIdLinea", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sIdMaterial", System.Data.SqlDbType.VarChar, 18),
            new System.Data.SqlClient.SqlParameter("@iCantidad", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@fPrecio", System.Data.SqlDbType.Float, 8),
            new System.Data.SqlClient.SqlParameter("@sidTipoPosicion", System.Data.SqlDbType.VarChar, 4),
            new System.Data.SqlClient.SqlParameter("@bEntregado", System.Data.SqlDbType.Bit, 1),
            new System.Data.SqlClient.SqlParameter("@dFechaPreferente", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@sCentro", System.Data.SqlDbType.VarChar, 4),
            new System.Data.SqlClient.SqlParameter("@sAlmacen", System.Data.SqlDbType.VarChar, 4),
            new System.Data.SqlClient.SqlParameter("@fDescuento", System.Data.SqlDbType.Float, 8),
            new System.Data.SqlClient.SqlParameter("@iBonificacion", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@idCampanya", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@idArrastre", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@idGrupoMat", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@idPaquete", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sSerie", System.Data.SqlDbType.VarChar, 7),
            new System.Data.SqlClient.SqlParameter("@sCodVale", System.Data.SqlDbType.VarChar, 15),
            new System.Data.SqlClient.SqlParameter("@sRechazo", System.Data.SqlDbType.VarChar, 4),
            new System.Data.SqlClient.SqlParameter("@fDescImplicito", System.Data.SqlDbType.Decimal, 10, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null)});
            // 
            // sqlCmdUpdPedAcciones
            // 
            this.sqlCmdUpdPedAcciones.CommandText = "[WSCliUpdPedAcciones]";
            this.sqlCmdUpdPedAcciones.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdPedAcciones.Connection = this.sqlConn;
            this.sqlCmdUpdPedAcciones.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@sIdPedido", System.Data.SqlDbType.VarChar, 12),
            new System.Data.SqlClient.SqlParameter("@iIdAccion", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@bEnviado", System.Data.SqlDbType.Bit, 1),
            new System.Data.SqlClient.SqlParameter("@dFecEnvio", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@Unidades", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@Estado", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@dAsignacion", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@dFUM", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@Destino", System.Data.SqlDbType.VarChar, 1),
            new System.Data.SqlClient.SqlParameter("@Bruto", System.Data.SqlDbType.Float, 8)});
            // 
            // sqlCmdUpdClientes
            // 
            this.sqlCmdUpdClientes.CommandText = "[WSCliUpdClientes]";
            this.sqlCmdUpdClientes.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdClientes.Connection = this.sqlConn;
            this.sqlCmdUpdClientes.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sIdCliente", System.Data.SqlDbType.VarChar, 20),
            new System.Data.SqlClient.SqlParameter("@sTipoCliente", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@sIdClienteTemp", System.Data.SqlDbType.VarChar, 15),
            new System.Data.SqlClient.SqlParameter("@sNombre", System.Data.SqlDbType.VarChar, 50),
            new System.Data.SqlClient.SqlParameter("@sApellidos1", System.Data.SqlDbType.VarChar, 100),
            new System.Data.SqlClient.SqlParameter("@sApellidos2", System.Data.SqlDbType.VarChar, 100),
            new System.Data.SqlClient.SqlParameter("@sTelefono", System.Data.SqlDbType.VarChar, 15),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt, 2),
            new System.Data.SqlClient.SqlParameter("@dFUM", System.Data.SqlDbType.DateTime, 8)});
            // 
            // sqlCmdUpdClientesSAP
            // 
            this.sqlCmdUpdClientesSAP.CommandText = "[WSCliUpdClientesSAP]";
            this.sqlCmdUpdClientesSAP.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdClientesSAP.Connection = this.sqlConn;
            this.sqlCmdUpdClientesSAP.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sNIF", System.Data.SqlDbType.VarChar, 20),
            new System.Data.SqlClient.SqlParameter("@sDatosBancarios", System.Data.SqlDbType.VarChar, 30),
            new System.Data.SqlClient.SqlParameter("@sDireccion", System.Data.SqlDbType.VarChar, 100),
            new System.Data.SqlClient.SqlParameter("@sPoblacion", System.Data.SqlDbType.VarChar, 100),
            new System.Data.SqlClient.SqlParameter("@sCP", System.Data.SqlDbType.VarChar, 5),
            new System.Data.SqlClient.SqlParameter("@sPais", System.Data.SqlDbType.VarChar, 50),
            new System.Data.SqlClient.SqlParameter("@sRegion", System.Data.SqlDbType.VarChar, 50),
            new System.Data.SqlClient.SqlParameter("@sTeles", System.Data.SqlDbType.VarChar, 15),
            new System.Data.SqlClient.SqlParameter("@sTelefono2", System.Data.SqlDbType.VarChar, 15),
            new System.Data.SqlClient.SqlParameter("@sTelefax", System.Data.SqlDbType.VarChar, 15),
            new System.Data.SqlClient.SqlParameter("@sCodPago", System.Data.SqlDbType.VarChar, 4),
            new System.Data.SqlClient.SqlParameter("@sZonaCliente", System.Data.SqlDbType.VarChar, 6),
            new System.Data.SqlClient.SqlParameter("@sOficinaVentas", System.Data.SqlDbType.VarChar, 4),
            new System.Data.SqlClient.SqlParameter("@sGrupoVendedores", System.Data.SqlDbType.VarChar, 3),
            new System.Data.SqlClient.SqlParameter("@sGrupoClientes", System.Data.SqlDbType.VarChar, 2),
            new System.Data.SqlClient.SqlParameter("@sOrgVentas", System.Data.SqlDbType.VarChar, 4),
            new System.Data.SqlClient.SqlParameter("@sSector", System.Data.SqlDbType.VarChar, 2),
            new System.Data.SqlClient.SqlParameter("@sCanal", System.Data.SqlDbType.VarChar, 2),
            new System.Data.SqlClient.SqlParameter("@sMoneda", System.Data.SqlDbType.VarChar, 3),
            new System.Data.SqlClient.SqlParameter("@sCondExp", System.Data.SqlDbType.VarChar, 2),
            new System.Data.SqlClient.SqlParameter("@sCentroSuministro", System.Data.SqlDbType.VarChar, 4),
            new System.Data.SqlClient.SqlParameter("@sIncoterms1", System.Data.SqlDbType.VarChar, 3),
            new System.Data.SqlClient.SqlParameter("@sIncoterms2", System.Data.SqlDbType.VarChar, 9),
            new System.Data.SqlClient.SqlParameter("@sAreaControlCred", System.Data.SqlDbType.VarChar, 2),
            new System.Data.SqlClient.SqlParameter("@sGarantias", System.Data.SqlDbType.VarChar, 4),
            new System.Data.SqlClient.SqlParameter("@sEncComercial", System.Data.SqlDbType.VarChar, 3),
            new System.Data.SqlClient.SqlParameter("@sRespPedido", System.Data.SqlDbType.VarChar, 3),
            new System.Data.SqlClient.SqlParameter("@sCiaTransporte", System.Data.SqlDbType.VarChar, 6),
            new System.Data.SqlClient.SqlParameter("@fDescuento", System.Data.SqlDbType.Float, 8),
            new System.Data.SqlClient.SqlParameter("@fBonificacion", System.Data.SqlDbType.Float, 8),
            new System.Data.SqlClient.SqlParameter("@fRappel", System.Data.SqlDbType.Float, 8),
            new System.Data.SqlClient.SqlParameter("@sTR", System.Data.SqlDbType.VarChar, 6),
            new System.Data.SqlClient.SqlParameter("@bPotencial", System.Data.SqlDbType.Bit, 1),
            new System.Data.SqlClient.SqlParameter("@sGarantias_1", System.Data.SqlDbType.VarChar, 4),
            new System.Data.SqlClient.SqlParameter("@sGarantias_2", System.Data.SqlDbType.VarChar, 4),
            new System.Data.SqlClient.SqlParameter("@sGarantias_3", System.Data.SqlDbType.VarChar, 4),
            new System.Data.SqlClient.SqlParameter("@sGarantias_4", System.Data.SqlDbType.VarChar, 4),
            new System.Data.SqlClient.SqlParameter("@fDeudaVenc", System.Data.SqlDbType.Float, 8),
            new System.Data.SqlClient.SqlParameter("@sEmailConf", System.Data.SqlDbType.VarChar, 50),
            new System.Data.SqlClient.SqlParameter("@sEmailFact", System.Data.SqlDbType.VarChar, 50),
            new System.Data.SqlClient.SqlParameter("@sSWIFT", System.Data.SqlDbType.VarChar, 100),
            new System.Data.SqlClient.SqlParameter("@idUbicacion", System.Data.SqlDbType.Int, 4)});
            // 
            // sqlCmdUpdBricks
            // 
            this.sqlCmdUpdBricks.CommandText = "[WSCliUpdBricks]";
            this.sqlCmdUpdBricks.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdBricks.Connection = this.sqlConn;
            this.sqlCmdUpdBricks.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@sIdBrick", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@sDescripcion", System.Data.SqlDbType.VarChar, 50),
            new System.Data.SqlClient.SqlParameter("@bTipoBrick", System.Data.SqlDbType.Bit, 1),
            new System.Data.SqlClient.SqlParameter("@iIdProvincia", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@dFAR", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@dFBR", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt, 2)});
            // 
            // sqlCmdUpdDelegadoBrick
            // 
            this.sqlCmdUpdDelegadoBrick.CommandText = "[WSCliUpdDelegadoBrick]";
            this.sqlCmdUpdDelegadoBrick.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdDelegadoBrick.Connection = this.sqlConn;
            this.sqlCmdUpdDelegadoBrick.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdDelegado", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sIdBrick", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@dFAR", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@dFBR", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt, 2)});
            // 
            // sqlCmdUpdBrickCP
            // 
            this.sqlCmdUpdBrickCP.CommandText = "[WSCliUpdBrickCP]";
            this.sqlCmdUpdBrickCP.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdBrickCP.Connection = this.sqlConn;
            this.sqlCmdUpdBrickCP.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@sIdBrick", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@sCodPostal", System.Data.SqlDbType.VarChar, 5),
            new System.Data.SqlClient.SqlParameter("@dFAR", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@dFBR", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt, 2)});
            // 
            // sqlCmdUpdBrickClientes
            // 
            this.sqlCmdUpdBrickClientes.CommandText = "[WSCliUpdBrickClientes]";
            this.sqlCmdUpdBrickClientes.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdBrickClientes.Connection = this.sqlConn;
            this.sqlCmdUpdBrickClientes.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sIdBrick", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@dFAR", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@dFBR", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt, 2),
            new System.Data.SqlClient.SqlParameter("@dFUM", System.Data.SqlDbType.DateTime)});
            // 
            // sqlCmdUpdCPCLientes
            // 
            this.sqlCmdUpdCPCLientes.CommandText = "[WSCliUpdCPCLientes]";
            this.sqlCmdUpdCPCLientes.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdCPCLientes.Connection = this.sqlConn;
            this.sqlCmdUpdCPCLientes.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sCodPostal", System.Data.SqlDbType.VarChar, 5),
            new System.Data.SqlClient.SqlParameter("@dFAR", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@dFBR", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt, 2)});
            // 
            // sqlCmdUpdRepCab
            // 
            this.sqlCmdUpdRepCab.CommandText = "[WSCliUpdRepCab]";
            this.sqlCmdUpdRepCab.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdRepCab.Connection = this.sqlConn;
            this.sqlCmdUpdRepCab.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdReport", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdDelegado", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sIdReportTemp", System.Data.SqlDbType.VarChar, 15),
            new System.Data.SqlClient.SqlParameter("@sTipoRActividad", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@sIdTipoCliente", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@iIdCentro", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@dFecha", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@iHorario", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@tObjetivo", System.Data.SqlDbType.VarChar, 300),
            new System.Data.SqlClient.SqlParameter("@tProxObjetivo", System.Data.SqlDbType.VarChar, 300),
            new System.Data.SqlClient.SqlParameter("@tObservaciones", System.Data.SqlDbType.VarChar, 300),
            new System.Data.SqlClient.SqlParameter("@bPlanificacion", System.Data.SqlDbType.SmallInt, 2),
            new System.Data.SqlClient.SqlParameter("@dFUM", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt, 2),
            new System.Data.SqlClient.SqlParameter("@dHoraInicio", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@dHoraFin", System.Data.SqlDbType.DateTime, 8)});
            // 
            // sqlCmdUpdRepActCli
            // 
            this.sqlCmdUpdRepActCli.CommandText = "[WSCliUpdRepActCli]";
            this.sqlCmdUpdRepActCli.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdRepActCli.Connection = this.sqlConn;
            this.sqlCmdUpdRepActCli.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdReport", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@tObservaciones", System.Data.SqlDbType.VarChar, 300),
            new System.Data.SqlClient.SqlParameter("@tObjetivos", System.Data.SqlDbType.VarChar, 300),
            new System.Data.SqlClient.SqlParameter("@tProxObj", System.Data.SqlDbType.VarChar, 300),
            new System.Data.SqlClient.SqlParameter("@bSustituto", System.Data.SqlDbType.Bit, 1)});
            // 
            // sqlCmdUpdRepActProm
            // 
            this.sqlCmdUpdRepActProm.CommandText = "[WSCliUpdRepActProm]";
            this.sqlCmdUpdRepActProm.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdRepActProm.Connection = this.sqlConn;
            this.sqlCmdUpdRepActProm.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdReport", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sIdProducto", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@iCantidad", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iOrden", System.Data.SqlDbType.SmallInt, 2)});
            // 
            // sqlCmdUpdRepActAten
            // 
            this.sqlCmdUpdRepActAten.CommandText = "[WSCliUpdRepActAten]";
            this.sqlCmdUpdRepActAten.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdRepActAten.Connection = this.sqlConn;
            this.sqlCmdUpdRepActAten.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdReport", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdAtencion", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iNumAtencion", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@fImporte", System.Data.SqlDbType.Float, 8)});
            // 
            // sqlCmdUpdProxObj
            // 
            this.sqlCmdUpdProxObj.CommandText = "[WSCliUpdProxObj]";
            this.sqlCmdUpdProxObj.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdProxObj.Connection = this.sqlConn;
            this.sqlCmdUpdProxObj.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdCentro", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdReport", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@tProxObj", System.Data.SqlDbType.VarChar, 300),
            new System.Data.SqlClient.SqlParameter("@dFecha", System.Data.SqlDbType.DateTime, 8)});
            // 
            // sqlCmdUpdRepPed
            // 
            this.sqlCmdUpdRepPed.CommandText = "[WSCliUpdRepPed]";
            this.sqlCmdUpdRepPed.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdRepPed.Connection = this.sqlConn;
            this.sqlCmdUpdRepPed.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdReport", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sIdPedido", System.Data.SqlDbType.VarChar, 12)});
            // 
            // sqlCmdUpdRepGad
            // 
            this.sqlCmdUpdRepGad.CommandText = "[WSCliUpdRepGad]";
            this.sqlCmdUpdRepGad.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdRepGad.Connection = this.sqlConn;
            this.sqlCmdUpdRepGad.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdReport", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdAccion", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iCantidad", System.Data.SqlDbType.Int, 4)});
            // 
            // sqlCmdSetNotaGasto
            // 
            this.sqlCmdSetNotaGasto.CommandText = "[WSCliSetNotaGasto]";
            this.sqlCmdSetNotaGasto.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdSetNotaGasto.Connection = this.sqlConn;
            this.sqlCmdSetNotaGasto.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdNota", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sIdNotaTemp", System.Data.SqlDbType.VarChar, 15),
            new System.Data.SqlClient.SqlParameter("@iIdDelegado", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@dFecha", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@bVisa", System.Data.SqlDbType.TinyInt, 1),
            new System.Data.SqlClient.SqlParameter("@dFechaAprob", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@sUsuarioAprob", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@dFechaLiq", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@tObservaciones", System.Data.SqlDbType.VarChar, 300),
            new System.Data.SqlClient.SqlParameter("@dFUM", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt, 2)});
            // 
            // sqlCmdSetNotaGastoLin
            // 
            this.sqlCmdSetNotaGastoLin.CommandText = "[WSCliSetNotaGastoLin]";
            this.sqlCmdSetNotaGastoLin.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdSetNotaGastoLin.Connection = this.sqlConn;
            this.sqlCmdSetNotaGastoLin.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdNota", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdGasto", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@fCantidad", System.Data.SqlDbType.Float, 8),
            new System.Data.SqlClient.SqlParameter("@fPrecio", System.Data.SqlDbType.Float, 8),
            new System.Data.SqlClient.SqlParameter("@tDescripcion", System.Data.SqlDbType.VarChar, 300),
            new System.Data.SqlClient.SqlParameter("@sIdCentroCoste", System.Data.SqlDbType.VarChar, 10)});
            // 
            // sqlCmdSetAtenNG
            // 
            this.sqlCmdSetAtenNG.CommandText = "[WSCliSetAtenNG]";
            this.sqlCmdSetAtenNG.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdSetAtenNG.Connection = this.sqlConn;
            this.sqlCmdSetAtenNG.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdNota", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdReport", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdAtencion", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iNumAtencion", System.Data.SqlDbType.Int, 4)});
            // 
            // sqlCmdUpdGastos
            // 
            this.sqlCmdUpdGastos.CommandText = "[WSCliUpdGastos]";
            this.sqlCmdUpdGastos.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdGastos.Connection = this.sqlConn;
            this.sqlCmdUpdGastos.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdGasto", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sDescripcion", System.Data.SqlDbType.VarChar, 100),
            new System.Data.SqlClient.SqlParameter("@fPrecio", System.Data.SqlDbType.Float, 8),
            new System.Data.SqlClient.SqlParameter("@sCuentaSAP", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@sCosteSAP", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@bSistema", System.Data.SqlDbType.Int),
            new System.Data.SqlClient.SqlParameter("@bImputaPresup", System.Data.SqlDbType.Bit, 1),
            new System.Data.SqlClient.SqlParameter("@sIdCategGasto", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@sIdTipCentroCoste", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@sIdTipoGasto", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@iNumLimite", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@dFUM", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt, 2)});
            // 
            // sqlCmdUpdPeriodosPresupuestos
            // 
            this.sqlCmdUpdPeriodosPresupuestos.CommandText = "[WSCliUpdPeriodosPresupuestos]";
            this.sqlCmdUpdPeriodosPresupuestos.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdPeriodosPresupuestos.Connection = this.sqlConn;
            this.sqlCmdUpdPeriodosPresupuestos.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdPeriodo", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@dFechaIni", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@dFechaFin", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@sDescripcion", System.Data.SqlDbType.VarChar, 50),
            new System.Data.SqlClient.SqlParameter("@dFUM", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt, 2)});
            // 
            // sqlCmdUpdTipoCargoDelegado
            // 
            this.sqlCmdUpdTipoCargoDelegado.CommandText = "[WSCliUpdTipoCargoDelegado]";
            this.sqlCmdUpdTipoCargoDelegado.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdTipoCargoDelegado.Connection = this.sqlConn;
            this.sqlCmdUpdTipoCargoDelegado.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdCargo", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sCargo", System.Data.SqlDbType.VarChar, 50),
            new System.Data.SqlClient.SqlParameter("@bTieneBricks", System.Data.SqlDbType.Bit, 1),
            new System.Data.SqlClient.SqlParameter("@IGClientesCOM", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@IGClientesSAP", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@IGPedidos", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@IGGastos", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@IGVisitas", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@IGAtenciones", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@IGAccionesMark", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@IGCentros", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sDirImagen", System.Data.SqlDbType.VarChar, 300),
            new System.Data.SqlClient.SqlParameter("@dFUM", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt, 2)});
            // 
            // sqlCmdUpdTiposPosPedidosSAP
            // 
            this.sqlCmdUpdTiposPosPedidosSAP.CommandText = "[WSCliUpdTiposPosPedidosSAP]";
            this.sqlCmdUpdTiposPosPedidosSAP.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdTiposPosPedidosSAP.Connection = this.sqlConn;
            this.sqlCmdUpdTiposPosPedidosSAP.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@sIdTipoPedido", System.Data.SqlDbType.VarChar, 4),
            new System.Data.SqlClient.SqlParameter("@sIdTipoPosicion", System.Data.SqlDbType.VarChar, 4),
            new System.Data.SqlClient.SqlParameter("@bEntregado", System.Data.SqlDbType.Bit, 1),
            new System.Data.SqlClient.SqlParameter("@bGratis", System.Data.SqlDbType.Bit, 1),
            new System.Data.SqlClient.SqlParameter("@bEntregadoOpt", System.Data.SqlDbType.Bit, 1),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt, 2)});
            // 
            // sqlCmdUpdPromociones
            // 
            this.sqlCmdUpdPromociones.CommandText = "[WSCliUpdPromociones]";
            this.sqlCmdUpdPromociones.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdPromociones.Connection = this.sqlConn;
            this.sqlCmdUpdPromociones.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdPromocion", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sDescripcion", System.Data.SqlDbType.VarChar, 50),
            new System.Data.SqlClient.SqlParameter("@dFIni", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@dFFin", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@dFUM", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt, 2)});
            // 
            // sqlCmdUpdPromocionesProd
            // 
            this.sqlCmdUpdPromocionesProd.CommandText = "[WsCliUpdPromocionesProd]";
            this.sqlCmdUpdPromocionesProd.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdPromocionesProd.Connection = this.sqlConn;
            this.sqlCmdUpdPromocionesProd.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdPromocion", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sIdProducto", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@iOrden", System.Data.SqlDbType.Int, 4)});
            // 
            // sqlCmdUpdDelegados
            // 
            this.sqlCmdUpdDelegados.CommandText = "[WSCliUpdDelegados]";
            this.sqlCmdUpdDelegados.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdDelegados.Connection = this.sqlConn;
            this.sqlCmdUpdDelegados.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdDelegado", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sNombre", System.Data.SqlDbType.VarChar, 100),
            new System.Data.SqlClient.SqlParameter("@sIdDelegadoSAP", System.Data.SqlDbType.VarChar, 3),
            new System.Data.SqlClient.SqlParameter("@sIdCentroSAP", System.Data.SqlDbType.VarChar, 4),
            new System.Data.SqlClient.SqlParameter("@sIdAlmacenSAP", System.Data.SqlDbType.VarChar, 4),
            new System.Data.SqlClient.SqlParameter("@bVisa", System.Data.SqlDbType.Bit, 1),
            new System.Data.SqlClient.SqlParameter("@sObservaciones", System.Data.SqlDbType.VarChar, 8000),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt, 2),
            new System.Data.SqlClient.SqlParameter("@dFUM", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@sUsuario", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@iIdCargo", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdParrilla", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@nmedicos", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdGastoKMS", System.Data.SqlDbType.Int),
            new System.Data.SqlClient.SqlParameter("@dFecMaxNota", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@iIdGastoDiet", System.Data.SqlDbType.Int)});
            // 
            // sqlCmdUpdCentros
            // 
            this.sqlCmdUpdCentros.CommandText = "[WSCliUpdCentros]";
            this.sqlCmdUpdCentros.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdCentros.Connection = this.sqlConn;
            this.sqlCmdUpdCentros.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdCentro", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sIdCentro", System.Data.SqlDbType.VarChar, 20),
            new System.Data.SqlClient.SqlParameter("@sIdCentroTemp", System.Data.SqlDbType.VarChar, 20),
            new System.Data.SqlClient.SqlParameter("@sIdTipoCentro", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@sDescripcion", System.Data.SqlDbType.VarChar, 100),
            new System.Data.SqlClient.SqlParameter("@sDireccion", System.Data.SqlDbType.VarChar, 100),
            new System.Data.SqlClient.SqlParameter("@iIdPoblacion", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sFax", System.Data.SqlDbType.VarChar, 15),
            new System.Data.SqlClient.SqlParameter("@sTelefono", System.Data.SqlDbType.VarChar, 15),
            new System.Data.SqlClient.SqlParameter("@sIdPolPrescripcion", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@sIdTipoClasificacion", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@sIdSistInformatico", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@bPactoPrescripcion", System.Data.SqlDbType.Bit, 1),
            new System.Data.SqlClient.SqlParameter("@bVisitaColectiva", System.Data.SqlDbType.Bit, 1),
            new System.Data.SqlClient.SqlParameter("@dFUM", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt, 2)});
            // 
            // sqlCmdUpdContactosClientesSAP
            // 
            this.sqlCmdUpdContactosClientesSAP.CommandText = "[WSCliUpdContactosClientesSAP]";
            this.sqlCmdUpdContactosClientesSAP.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdContactosClientesSAP.Connection = this.sqlConn;
            this.sqlCmdUpdContactosClientesSAP.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdContacto", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sNombre", System.Data.SqlDbType.VarChar, 100),
            new System.Data.SqlClient.SqlParameter("@sIdCargoContacto", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@dFAR", System.Data.SqlDbType.VarChar, 20),
            new System.Data.SqlClient.SqlParameter("@dFBR", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt, 2),
            new System.Data.SqlClient.SqlParameter("@dFUM", System.Data.SqlDbType.DateTime),
            new System.Data.SqlClient.SqlParameter("@sSWIFT", System.Data.SqlDbType.VarChar, 100)});
            // 
            // sqlCmdUpdCentrosClientesSAP
            // 
            this.sqlCmdUpdCentrosClientesSAP.CommandText = "[WSCliUpdCentrosClientesSAP]";
            this.sqlCmdUpdCentrosClientesSAP.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdCentrosClientesSAP.Connection = this.sqlConn;
            this.sqlCmdUpdCentrosClientesSAP.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdCentro", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@dFAR", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@dFBR", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt, 2),
            new System.Data.SqlClient.SqlParameter("@dFUM", System.Data.SqlDbType.DateTime)});
            // 
            // sqlCmdUpdInterlocutorClienteSAP
            // 
            this.sqlCmdUpdInterlocutorClienteSAP.CommandText = "[WSCliUpdInterlocutorClienteSAP]";
            this.sqlCmdUpdInterlocutorClienteSAP.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdInterlocutorClienteSAP.Connection = this.sqlConn;
            this.sqlCmdUpdInterlocutorClienteSAP.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdInterlocutor", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sIdCodClientedelMay", System.Data.SqlDbType.VarChar, 20),
            new System.Data.SqlClient.SqlParameter("@dFAR", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@dFBR", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt, 2),
            new System.Data.SqlClient.SqlParameter("@dFUM", System.Data.SqlDbType.DateTime)});
            // 
            // sqlCmdUpdClientesCOM
            // 
            this.sqlCmdUpdClientesCOM.CommandText = "[WSCliUpdClientesCOM]";
            this.sqlCmdUpdClientesCOM.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdClientesCOM.Connection = this.sqlConn;
            this.sqlCmdUpdClientesCOM.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sTipoCliente_COM", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@sNumColegiado", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@tObservaciones", System.Data.SqlDbType.VarChar, 8000),
            new System.Data.SqlClient.SqlParameter("@sEMail", System.Data.SqlDbType.VarChar, 50),
            new System.Data.SqlClient.SqlParameter("@sFax", System.Data.SqlDbType.VarChar, 16),
            new System.Data.SqlClient.SqlParameter("@sTelMovil", System.Data.SqlDbType.VarChar, 16),
            new System.Data.SqlClient.SqlParameter("@sDireccion", System.Data.SqlDbType.VarChar, 100),
            new System.Data.SqlClient.SqlParameter("@iIdPoblacion", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@dFecNacimiento", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@dFecAniversario", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@sNIF", System.Data.SqlDbType.VarChar, 20),
            new System.Data.SqlClient.SqlParameter("@bAsignado", System.Data.SqlDbType.Bit, 1),
            new System.Data.SqlClient.SqlParameter("@bOcasional", System.Data.SqlDbType.Bit, 1),
            new System.Data.SqlClient.SqlParameter("@dFUM", System.Data.SqlDbType.DateTime, 8)});
            // 
            // sqlCmdUpdEspecClientesCOM
            // 
            this.sqlCmdUpdEspecClientesCOM.CommandText = "[WSCliUpdEspecClientesCOM]";
            this.sqlCmdUpdEspecClientesCOM.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdEspecClientesCOM.Connection = this.sqlConn;
            this.sqlCmdUpdEspecClientesCOM.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sIdEspecialidad", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@dFUM", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt, 2)});
            // 
            // sqlCmdUpdAficClientesCOM
            // 
            this.sqlCmdUpdAficClientesCOM.CommandText = "[WSCliUpdAficCLientesCOM]";
            this.sqlCmdUpdAficClientesCOM.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdAficClientesCOM.Connection = this.sqlConn;
            this.sqlCmdUpdAficClientesCOM.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sIdAficion", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@dFUM", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt, 2)});
            // 
            // sqlCmdUpdCentrosClientesCOM
            // 
            this.sqlCmdUpdCentrosClientesCOM.CommandText = "[WSCliUpdCentrosClientesCOM]";
            this.sqlCmdUpdCentrosClientesCOM.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdCentrosClientesCOM.Connection = this.sqlConn;
            this.sqlCmdUpdCentrosClientesCOM.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdCentro", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sIdTipoRelacionCliCen", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@dFAR", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@dFBR", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt, 2),
            new System.Data.SqlClient.SqlParameter("@sIdRed", System.Data.SqlDbType.VarChar, 4),
            new System.Data.SqlClient.SqlParameter("@dFUM", System.Data.SqlDbType.DateTime)});
            // 
            // sqlCmdUpdProdClientesCOM
            // 
            this.sqlCmdUpdProdClientesCOM.CommandText = "[WSCliUpdProdClientesCOM]";
            this.sqlCmdUpdProdClientesCOM.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdProdClientesCOM.Connection = this.sqlConn;
            this.sqlCmdUpdProdClientesCOM.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sIdProducto", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@iPrioridad", System.Data.SqlDbType.SmallInt, 2),
            new System.Data.SqlClient.SqlParameter("@dFUM", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt, 2)});
            // 
            // sqlCmdUpdAccionesMarkClientes
            // 
            this.sqlCmdUpdAccionesMarkClientes.CommandText = "[WSCliUpdAccionesMarkClientes]";
            this.sqlCmdUpdAccionesMarkClientes.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdAccionesMarkClientes.Connection = this.sqlConn;
            this.sqlCmdUpdAccionesMarkClientes.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdAccion", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@dFechaEntrega", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@fCantidad", System.Data.SqlDbType.Float, 8),
            new System.Data.SqlClient.SqlParameter("@tObservaciones", System.Data.SqlDbType.VarChar, 8000),
            new System.Data.SqlClient.SqlParameter("@sCCoste", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@dFUM", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt, 2),
            new System.Data.SqlClient.SqlParameter("@iIdDelegado", System.Data.SqlDbType.Int, 4)});
            // 
            // sqlCmdUpdCentrosHorariosVisitas
            // 
            this.sqlCmdUpdCentrosHorariosVisitas.CommandText = "[WSCliUpdCentrosHorariosVisitas]";
            this.sqlCmdUpdCentrosHorariosVisitas.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdCentrosHorariosVisitas.Connection = this.sqlConn;
            this.sqlCmdUpdCentrosHorariosVisitas.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdHorario", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdCentro", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sDia", System.Data.SqlDbType.VarChar, 100),
            new System.Data.SqlClient.SqlParameter("@sIdServicio", System.Data.SqlDbType.VarChar, 100),
            new System.Data.SqlClient.SqlParameter("@sManTarde", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@sHoraManIni", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@sHoraManFin", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@sHoraTarIni", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@sHoraTarFin", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@tObservaciones", System.Data.SqlDbType.VarChar, 8000)});
            // 
            // sqlCmdUpdCodPostal
            // 
            this.sqlCmdUpdCodPostal.CommandText = "[WSCliUpdCodPostal]";
            this.sqlCmdUpdCodPostal.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdCodPostal.Connection = this.sqlConn;
            this.sqlCmdUpdCodPostal.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@sCodPostal", System.Data.SqlDbType.VarChar, 5)});
            // 
            // sqlCmdUpdPoblaciones
            // 
            this.sqlCmdUpdPoblaciones.CommandText = "[WSCliUpdPoblaciones]";
            this.sqlCmdUpdPoblaciones.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdPoblaciones.Connection = this.sqlConn;
            this.sqlCmdUpdPoblaciones.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdPoblacion", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sCodPostal", System.Data.SqlDbType.VarChar, 5),
            new System.Data.SqlClient.SqlParameter("@sDescripcion", System.Data.SqlDbType.VarChar, 50),
            new System.Data.SqlClient.SqlParameter("@iIdProvincia", System.Data.SqlDbType.Int, 4)});
            // 
            // sqlCmdUpdPresupuestos
            // 
            this.sqlCmdUpdPresupuestos.CommandText = "[WSCliUpdPresupuestos]";
            this.sqlCmdUpdPresupuestos.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdPresupuestos.Connection = this.sqlConn;
            this.sqlCmdUpdPresupuestos.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdDelegado", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sTipoPresupuesto", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@iIdPeriodo", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@fImporte", System.Data.SqlDbType.Float, 8),
            new System.Data.SqlClient.SqlParameter("@fImporteActual", System.Data.SqlDbType.Float, 8),
            new System.Data.SqlClient.SqlParameter("@dFUM", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt, 2)});
            // 
            // sqlCmdAct
            // 
            this.sqlCmdAct.Connection = this.sqlConn;
            // 
            // sqlCmdUpdAgenda
            // 
            this.sqlCmdUpdAgenda.CommandText = "[WSCliUpdAgenda]";
            this.sqlCmdUpdAgenda.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdAgenda.Connection = this.sqlConn;
            this.sqlCmdUpdAgenda.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdDelegado", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@dFecha", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@tObservaciones", System.Data.SqlDbType.VarChar, 8000)});
            // 
            // sqlDADatosCliente
            // 
            this.sqlDADatosCliente.SelectCommand = this.sqlSelectCommand1;
            this.sqlDADatosCliente.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "DatosSincro", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iIdCliente", "iIdCliente"),
                        new System.Data.Common.DataColumnMapping("sIdCliente", "sIdCliente"),
                        new System.Data.Common.DataColumnMapping("sTipoCliente", "sTipoCliente"),
                        new System.Data.Common.DataColumnMapping("sIdClienteTemp", "sIdClienteTemp"),
                        new System.Data.Common.DataColumnMapping("sNombre", "sNombre"),
                        new System.Data.Common.DataColumnMapping("sApellidos1", "sApellidos1"),
                        new System.Data.Common.DataColumnMapping("sApellidos2", "sApellidos2"),
                        new System.Data.Common.DataColumnMapping("sTelefono", "sTelefono"),
                        new System.Data.Common.DataColumnMapping("iEstado", "iEstado"),
                        new System.Data.Common.DataColumnMapping("dFUM", "dFUM")}),
            new System.Data.Common.DataTableMapping("Table1", "Table1", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iIdCliente", "iIdCliente"),
                        new System.Data.Common.DataColumnMapping("sIdRed", "sIdRed"),
                        new System.Data.Common.DataColumnMapping("sIdClasificacion", "sIdClasificacion"),
                        new System.Data.Common.DataColumnMapping("dFAR", "dFAR"),
                        new System.Data.Common.DataColumnMapping("dFBR", "dFBR"),
                        new System.Data.Common.DataColumnMapping("iEstado", "iEstado")}),
            new System.Data.Common.DataTableMapping("Table2", "Table2", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iIdCliente", "iIdCliente"),
                        new System.Data.Common.DataColumnMapping("sTipoCliente_COM", "sTipoCliente_COM"),
                        new System.Data.Common.DataColumnMapping("sNumColegiado", "sNumColegiado"),
                        new System.Data.Common.DataColumnMapping("tObservaciones", "tObservaciones"),
                        new System.Data.Common.DataColumnMapping("sEMail", "sEMail"),
                        new System.Data.Common.DataColumnMapping("sFax", "sFax"),
                        new System.Data.Common.DataColumnMapping("sTelMovil", "sTelMovil"),
                        new System.Data.Common.DataColumnMapping("sDireccion", "sDireccion"),
                        new System.Data.Common.DataColumnMapping("iIdPoblacion", "iIdPoblacion"),
                        new System.Data.Common.DataColumnMapping("dFecNacimiento", "dFecNacimiento"),
                        new System.Data.Common.DataColumnMapping("dFecAniversario", "dFecAniversario"),
                        new System.Data.Common.DataColumnMapping("sNIF", "sNIF"),
                        new System.Data.Common.DataColumnMapping("bAsignado", "bAsignado"),
                        new System.Data.Common.DataColumnMapping("bOcasional", "bOcasional"),
                        new System.Data.Common.DataColumnMapping("dFUM", "dFUM")}),
            new System.Data.Common.DataTableMapping("Table3", "Table3", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iIdCliente", "iIdCliente"),
                        new System.Data.Common.DataColumnMapping("sIdProducto", "sIdProducto"),
                        new System.Data.Common.DataColumnMapping("iPrioridad", "iPrioridad"),
                        new System.Data.Common.DataColumnMapping("iEstado", "iEstado")}),
            new System.Data.Common.DataTableMapping("Table4", "Table4", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iIdCliente", "iIdCliente"),
                        new System.Data.Common.DataColumnMapping("sIdEspecialidad", "sIdEspecialidad"),
                        new System.Data.Common.DataColumnMapping("dFUM", "dFUM"),
                        new System.Data.Common.DataColumnMapping("iEstado", "iEstado")}),
            new System.Data.Common.DataTableMapping("Table5", "Table5", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iIdCliente", "iIdCliente"),
                        new System.Data.Common.DataColumnMapping("sIdAficion", "sIdAficion"),
                        new System.Data.Common.DataColumnMapping("dFUM", "dFUM"),
                        new System.Data.Common.DataColumnMapping("iEstado", "iEstado")}),
            new System.Data.Common.DataTableMapping("Table6", "Table6", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iIdCliente", "iIdCliente"),
                        new System.Data.Common.DataColumnMapping("iIdCentro", "iIdCentro"),
                        new System.Data.Common.DataColumnMapping("sIdTipoRelacionCliCen", "sIdTipoRelacionCliCen"),
                        new System.Data.Common.DataColumnMapping("dFAR", "dFAR"),
                        new System.Data.Common.DataColumnMapping("dFBR", "dFBR"),
                        new System.Data.Common.DataColumnMapping("iEstado", "iEstado"),
                        new System.Data.Common.DataColumnMapping("sIdRed", "sIdRed")}),
            new System.Data.Common.DataTableMapping("Table7", "Table7", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iIdCliente", "iIdCliente"),
                        new System.Data.Common.DataColumnMapping("iIdContacto", "iIdContacto"),
                        new System.Data.Common.DataColumnMapping("sNombre", "sNombre"),
                        new System.Data.Common.DataColumnMapping("sIdCargoContacto", "sIdCargoContacto"),
                        new System.Data.Common.DataColumnMapping("dFAR", "dFAR"),
                        new System.Data.Common.DataColumnMapping("dFBR", "dFBR"),
                        new System.Data.Common.DataColumnMapping("iEstado", "iEstado")}),
            new System.Data.Common.DataTableMapping("Table8", "Table8", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iIdCliente", "iIdCliente"),
                        new System.Data.Common.DataColumnMapping("iIdCentro", "iIdCentro"),
                        new System.Data.Common.DataColumnMapping("dFAR", "dFAR"),
                        new System.Data.Common.DataColumnMapping("dFBR", "dFBR"),
                        new System.Data.Common.DataColumnMapping("iEstado", "iEstado")}),
            new System.Data.Common.DataTableMapping("Table9", "Table9", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iIdCentro", "iIdCentro"),
                        new System.Data.Common.DataColumnMapping("sIdCentro", "sIdCentro"),
                        new System.Data.Common.DataColumnMapping("sIdCentroTemp", "sIdCentroTemp"),
                        new System.Data.Common.DataColumnMapping("sIdTipoCentro", "sIdTipoCentro"),
                        new System.Data.Common.DataColumnMapping("sDescripcion", "sDescripcion"),
                        new System.Data.Common.DataColumnMapping("sDireccion", "sDireccion"),
                        new System.Data.Common.DataColumnMapping("iIdPoblacion", "iIdPoblacion"),
                        new System.Data.Common.DataColumnMapping("sFax", "sFax"),
                        new System.Data.Common.DataColumnMapping("sTelefono", "sTelefono"),
                        new System.Data.Common.DataColumnMapping("sIdPolPrescripcion", "sIdPolPrescripcion"),
                        new System.Data.Common.DataColumnMapping("sIdTipoClasificacion", "sIdTipoClasificacion"),
                        new System.Data.Common.DataColumnMapping("sIdSistInformatico", "sIdSistInformatico"),
                        new System.Data.Common.DataColumnMapping("bPactoPrescripcion", "bPactoPrescripcion"),
                        new System.Data.Common.DataColumnMapping("bVisitaColectiva", "bVisitaColectiva"),
                        new System.Data.Common.DataColumnMapping("dFUM", "dFUM"),
                        new System.Data.Common.DataColumnMapping("iEstado", "iEstado")}),
            new System.Data.Common.DataTableMapping("Table10", "Table10", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iIdCentro", "iIdCentro"),
                        new System.Data.Common.DataColumnMapping("sIdRed", "sIdRed"),
                        new System.Data.Common.DataColumnMapping("dFAR", "dFAR"),
                        new System.Data.Common.DataColumnMapping("dFBR", "dFBR"),
                        new System.Data.Common.DataColumnMapping("iEstado", "iEstado")}),
            new System.Data.Common.DataTableMapping("Table11", "Table11", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iIdCliente", "iIdCliente"),
                        new System.Data.Common.DataColumnMapping("sCodPostal", "sCodPostal"),
                        new System.Data.Common.DataColumnMapping("dFAR", "dFAR"),
                        new System.Data.Common.DataColumnMapping("dFBR", "dFBR"),
                        new System.Data.Common.DataColumnMapping("iEstado", "iEstado")}),
            new System.Data.Common.DataTableMapping("Table12", "Table12", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iIdCliente", "iIdCliente"),
                        new System.Data.Common.DataColumnMapping("sIdBrick", "sIdBrick"),
                        new System.Data.Common.DataColumnMapping("dFAR", "dFAR"),
                        new System.Data.Common.DataColumnMapping("dFBR", "dFBR"),
                        new System.Data.Common.DataColumnMapping("iEstado", "iEstado")}),
            new System.Data.Common.DataTableMapping("Table13", "Table13", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iIdAccion", "iIdAccion"),
                        new System.Data.Common.DataColumnMapping("iIdCliente", "iIdCliente"),
                        new System.Data.Common.DataColumnMapping("dFechaEntrega", "dFechaEntrega"),
                        new System.Data.Common.DataColumnMapping("fCantidad", "fCantidad"),
                        new System.Data.Common.DataColumnMapping("tObservaciones", "tObservaciones"),
                        new System.Data.Common.DataColumnMapping("sCCoste", "sCCoste"),
                        new System.Data.Common.DataColumnMapping("dFUM", "dFUM"),
                        new System.Data.Common.DataColumnMapping("iEstado", "iEstado")}),
            new System.Data.Common.DataTableMapping("Table32", "Table32", new System.Data.Common.DataColumnMapping[0]),
            new System.Data.Common.DataTableMapping("Table31", "Table31", new System.Data.Common.DataColumnMapping[0]),
            new System.Data.Common.DataTableMapping("Table27", "Table27", new System.Data.Common.DataColumnMapping[0]),
            new System.Data.Common.DataTableMapping("Table25", "Table25", new System.Data.Common.DataColumnMapping[0]),
            new System.Data.Common.DataTableMapping("Table24", "Table24", new System.Data.Common.DataColumnMapping[0]),
            new System.Data.Common.DataTableMapping("Table23", "Table23", new System.Data.Common.DataColumnMapping[0]),
            new System.Data.Common.DataTableMapping("Table22", "Table22", new System.Data.Common.DataColumnMapping[0]),
            new System.Data.Common.DataTableMapping("Table21", "Table21", new System.Data.Common.DataColumnMapping[0]),
            new System.Data.Common.DataTableMapping("Table20", "Table20", new System.Data.Common.DataColumnMapping[0]),
            new System.Data.Common.DataTableMapping("Table19", "Table19", new System.Data.Common.DataColumnMapping[0]),
            new System.Data.Common.DataTableMapping("Table18", "Table18", new System.Data.Common.DataColumnMapping[0]),
            new System.Data.Common.DataTableMapping("Table17", "Table17", new System.Data.Common.DataColumnMapping[0]),
            new System.Data.Common.DataTableMapping("Table16", "Table16", new System.Data.Common.DataColumnMapping[0]),
            new System.Data.Common.DataTableMapping("Table15", "Table15", new System.Data.Common.DataColumnMapping[0]),
            new System.Data.Common.DataTableMapping("Table14", "Table14", new System.Data.Common.DataColumnMapping[0]),
            new System.Data.Common.DataTableMapping("Table26", "Table26", new System.Data.Common.DataColumnMapping[0]),
            new System.Data.Common.DataTableMapping("Table28", "Table28", new System.Data.Common.DataColumnMapping[0]),
            new System.Data.Common.DataTableMapping("Table29", "Table29", new System.Data.Common.DataColumnMapping[0]),
            new System.Data.Common.DataTableMapping("Table30", "Table30", new System.Data.Common.DataColumnMapping[0]),
            new System.Data.Common.DataTableMapping("Table33", "Table33", new System.Data.Common.DataColumnMapping[0]),
            new System.Data.Common.DataTableMapping("Table34", "Table34", new System.Data.Common.DataColumnMapping[0]),
            new System.Data.Common.DataTableMapping("Table35", "Table35", new System.Data.Common.DataColumnMapping[0]),
            new System.Data.Common.DataTableMapping("Table36", "Table36", new System.Data.Common.DataColumnMapping[0]),
            new System.Data.Common.DataTableMapping("Table37", "Table37", new System.Data.Common.DataColumnMapping[0]),
            new System.Data.Common.DataTableMapping("Table38", "Table38", new System.Data.Common.DataColumnMapping[0]),
            new System.Data.Common.DataTableMapping("Table39", "Table39", new System.Data.Common.DataColumnMapping[0]),
            new System.Data.Common.DataTableMapping("Table40", "Table40", new System.Data.Common.DataColumnMapping[0]),
            new System.Data.Common.DataTableMapping("Table41", "Table41", new System.Data.Common.DataColumnMapping[0])});
            // 
            // sqlSelectCommand1
            // 
            this.sqlSelectCommand1.CommandText = "[DatosSincro]";
            this.sqlSelectCommand1.CommandTimeout = 300;
            this.sqlSelectCommand1.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand1.Connection = this.sqlConn;
            this.sqlSelectCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@dFUS", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@dFUSClientes", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@dFUSPedidos", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@dFUSVisitas", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@dFUSAtenciones", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@dFUSGastos", System.Data.SqlDbType.DateTime, 8)});
            // 
            // sqlSelectCommand1CECL
            // 
            this.sqlSelectCommand1CECL.CommandText = "[DatosSincroCECL]";
            this.sqlSelectCommand1CECL.CommandTimeout = 300;
            this.sqlSelectCommand1CECL.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand1CECL.Connection = this.sqlConn;
            this.sqlSelectCommand1CECL.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@dFUS", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@dFUSClientes", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@dFUSPedidos", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@dFUSVisitas", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@dFUSAtenciones", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@dFUSGastos", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@iIdDelegado", System.Data.SqlDbType.Int, 4)});
            // 
            // sqlCmdUpdRedes
            // 
            this.sqlCmdUpdRedes.CommandText = "[WSCliUpdRedes]";
            this.sqlCmdUpdRedes.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdRedes.Connection = this.sqlConn;
            this.sqlCmdUpdRedes.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@sIdRed", System.Data.SqlDbType.VarChar, 4),
            new System.Data.SqlClient.SqlParameter("@sNombre", System.Data.SqlDbType.VarChar, 30),
            new System.Data.SqlClient.SqlParameter("@dFUM", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt, 2)});
            // 
            // sqlCmdUpdDivisiones
            // 
            this.sqlCmdUpdDivisiones.CommandText = "[WSCliUpdDivisiones]";
            this.sqlCmdUpdDivisiones.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdDivisiones.Connection = this.sqlConn;
            this.sqlCmdUpdDivisiones.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@sIdDivision", System.Data.SqlDbType.VarChar, 2),
            new System.Data.SqlClient.SqlParameter("@sNombre", System.Data.SqlDbType.VarChar, 30),
            new System.Data.SqlClient.SqlParameter("@dFUM", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt, 2)});
            // 
            // sqlCmdUpdAccionesRedes
            // 
            this.sqlCmdUpdAccionesRedes.CommandText = "[WSCliUpdAccionesRedes]";
            this.sqlCmdUpdAccionesRedes.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdAccionesRedes.Connection = this.sqlConn;
            this.sqlCmdUpdAccionesRedes.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@sIdRed", System.Data.SqlDbType.VarChar, 4),
            new System.Data.SqlClient.SqlParameter("@iIdAccion", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@dFAR", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@dFBR", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt, 2)});
            // 
            // sqlCmdUpdCentrosRedes
            // 
            this.sqlCmdUpdCentrosRedes.CommandText = "[WSCliUpdCentrosRedes]";
            this.sqlCmdUpdCentrosRedes.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdCentrosRedes.Connection = this.sqlConn;
            this.sqlCmdUpdCentrosRedes.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdCentro", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sIdRed", System.Data.SqlDbType.VarChar, 4),
            new System.Data.SqlClient.SqlParameter("@dFAR", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@dFBR", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt, 2),
            new System.Data.SqlClient.SqlParameter("@dFUM", System.Data.SqlDbType.DateTime)});
            // 
            // sqlCmdUpdClientesRedes
            // 
            this.sqlCmdUpdClientesRedes.CommandText = "[WSCliUpdClientesRedes]";
            this.sqlCmdUpdClientesRedes.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdClientesRedes.Connection = this.sqlConn;
            this.sqlCmdUpdClientesRedes.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sIdRed", System.Data.SqlDbType.VarChar, 4),
            //new System.Data.SqlClient.SqlParameter("@sIdClasificacion", System.Data.SqlDbType.VarChar, 1),
            new System.Data.SqlClient.SqlParameter("@sIdClasificacion", System.Data.SqlDbType.VarChar, 10), //---- GSG (02/03/2022)
            new System.Data.SqlClient.SqlParameter("@dFAR", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@dFBR", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt, 2),
            new System.Data.SqlClient.SqlParameter("@dFUM", System.Data.SqlDbType.DateTime)});
            // 
            // sqlCmdCompacta
            // 
            this.sqlCmdCompacta.CommandText = "[ResizeDB]";
            this.sqlCmdCompacta.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdCompacta.Connection = this.sqlConn;
            this.sqlCmdCompacta.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@sDatabase", System.Data.SqlDbType.NVarChar, 100)});
            // 
            // sqlCmdUpdSolGad
            // 
            this.sqlCmdUpdSolGad.CommandText = "[WSCLIUpdSolGadget]";
            this.sqlCmdUpdSolGad.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdSolGad.Connection = this.sqlConn;
            this.sqlCmdUpdSolGad.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@sIdSolicitud", System.Data.SqlDbType.VarChar, 15),
            new System.Data.SqlClient.SqlParameter("@iIdDelegado", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@Fecha", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@iIdGadget", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iCantidadSol", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iCantidadServ", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sStatus", System.Data.SqlDbType.VarChar, 1),
            new System.Data.SqlClient.SqlParameter("@tObservaciones", System.Data.SqlDbType.VarChar, 2147483647),
            new System.Data.SqlClient.SqlParameter("@dFUM", System.Data.SqlDbType.DateTime, 8)});
            // 
            // tmrStatus
            // 
            this.tmrStatus.Interval = 1000;
            this.tmrStatus.Tick += new System.EventHandler(this.tmrStatus_Tick);
            // 
            // sqlCmdEspecialidadesDelegado
            // 
            this.sqlCmdEspecialidadesDelegado.CommandText = "[WSCliUpdEspecialidadesDelegado]";
            this.sqlCmdEspecialidadesDelegado.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdEspecialidadesDelegado.Connection = this.sqlConn;
            this.sqlCmdEspecialidadesDelegado.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdDelegado", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sIdEspecialidad", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt, 2),
            new System.Data.SqlClient.SqlParameter("@dFUM", System.Data.SqlDbType.DateTime, 8)});
            // 
            // sqlCmdEspecialidadesRedes
            // 
            this.sqlCmdEspecialidadesRedes.CommandText = "[WSCliUpdEspecialidadesRedes]";
            this.sqlCmdEspecialidadesRedes.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdEspecialidadesRedes.Connection = this.sqlConn;
            this.sqlCmdEspecialidadesRedes.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@sIdEspecialidad", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@sIdRed", System.Data.SqlDbType.VarChar, 4),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt, 2),
            new System.Data.SqlClient.SqlParameter("@dFUM", System.Data.SqlDbType.DateTime, 8)});
            // 
            // sqlCmdPromocionesRedes
            // 
            this.sqlCmdPromocionesRedes.CommandText = "[WSCliUpdPromocionesRedes]";
            this.sqlCmdPromocionesRedes.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdPromocionesRedes.Connection = this.sqlConn;
            this.sqlCmdPromocionesRedes.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@sIdProducto", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@sIdRed", System.Data.SqlDbType.VarChar, 4),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt, 2),
            new System.Data.SqlClient.SqlParameter("@dFUM", System.Data.SqlDbType.DateTime, 8)});
            // 
            // sqlCmdUpdEstrucCom
            // 
            this.sqlCmdUpdEstrucCom.CommandText = "[WSCliUpdEstrucCom]";
            this.sqlCmdUpdEstrucCom.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdEstrucCom.Connection = this.sqlConn;
            this.sqlCmdUpdEstrucCom.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdDelegado", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdDelegadoResp", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@dFUM", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt, 2)});
            // 
            // sqlCmdUpdParrilla
            // 
            this.sqlCmdUpdParrilla.CommandText = "[WSCliUpdParrilla]";
            this.sqlCmdUpdParrilla.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdParrilla.Connection = this.sqlConn;
            this.sqlCmdUpdParrilla.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdParrilla", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sparrilla", System.Data.SqlDbType.VarChar, 200),
            new System.Data.SqlClient.SqlParameter("@dFUM", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt, 2)});
            // 
            // sqlCmdUpdMaterialParrilla
            // 
            this.sqlCmdUpdMaterialParrilla.CommandText = "[WSCliUpdMaterialParrilla]";
            this.sqlCmdUpdMaterialParrilla.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdMaterialParrilla.Connection = this.sqlConn;
            this.sqlCmdUpdMaterialParrilla.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdParrilla", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@IidAccion", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@dFUM", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt, 2)});
            // 
            // sqlCmdUpdMaterialCamp
            // 
            this.sqlCmdUpdMaterialCamp.CommandText = "[WSCliUpdMaterialCamp]";
            this.sqlCmdUpdMaterialCamp.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdMaterialCamp.Connection = this.sqlConn;
            this.sqlCmdUpdMaterialCamp.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdMaterial", System.Data.SqlDbType.VarChar, 18),
            new System.Data.SqlClient.SqlParameter("@iIdCamp", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@DescuentoMaximo", System.Data.SqlDbType.Float, 8),
            new System.Data.SqlClient.SqlParameter("@dFUM", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt, 2),
            new System.Data.SqlClient.SqlParameter("@UnidMinimas", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@bObligatorio", System.Data.SqlDbType.Bit, 1),
            new System.Data.SqlClient.SqlParameter("@idPaquete", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sSumaUnidades", System.Data.SqlDbType.VarChar, 4),
            new System.Data.SqlClient.SqlParameter("@iDeCampRegalo", System.Data.SqlDbType.SmallInt, 2),
            new System.Data.SqlClient.SqlParameter("@sSumaPara", System.Data.SqlDbType.VarChar, 4)});
            // 
            // sqlCmdUpdAccionesComercialesProductos
            // 
            this.sqlCmdUpdAccionesComercialesProductos.CommandText = "dbo.[WSCliUpdAtencionesComercialesProductos]";
            this.sqlCmdUpdAccionesComercialesProductos.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdAccionesComercialesProductos.Connection = this.sqlConn;
            this.sqlCmdUpdAccionesComercialesProductos.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdAtencion", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sIdProducto", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@fPorcentaje", System.Data.SqlDbType.Float),
            new System.Data.SqlClient.SqlParameter("@bEnviadoPDA", System.Data.SqlDbType.Bit, 1),
            new System.Data.SqlClient.SqlParameter("@bEnviadoCEN", System.Data.SqlDbType.Bit, 1)});
            // 
            // sqlCmdUpdDescuento_Campanyas
            // 
            this.sqlCmdUpdDescuento_Campanyas.CommandText = "SetDescuentoCampanya";
            this.sqlCmdUpdDescuento_Campanyas.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdDescuento_Campanyas.Connection = this.sqlConn;
            this.sqlCmdUpdDescuento_Campanyas.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@sIdCampanya", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@bInformarDescuentoMaximo", System.Data.SqlDbType.Bit)});
            // 
            // sqlCmdUpdCampanyaMultiple
            // 
            this.sqlCmdUpdCampanyaMultiple.CommandText = "dbo.[SetCampanyaMultiple]";
            this.sqlCmdUpdCampanyaMultiple.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdCampanyaMultiple.Connection = this.sqlConn;
            this.sqlCmdUpdCampanyaMultiple.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@sIdCampanya", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@bEsDeSeleccionMultiple", System.Data.SqlDbType.Bit, 1)});
            // 
            // sqlCmdUpdMaterialesRentabilidad
            // 
            this.sqlCmdUpdMaterialesRentabilidad.CommandText = "dbo.[WSCliUpdMaterialesRentabilidad]";
            this.sqlCmdUpdMaterialesRentabilidad.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdMaterialesRentabilidad.Connection = this.sqlConn;
            this.sqlCmdUpdMaterialesRentabilidad.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@sIdMaterial", System.Data.SqlDbType.VarChar, 18),
            new System.Data.SqlClient.SqlParameter("@fCoste", System.Data.SqlDbType.Decimal, 9, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@dFum", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt, 2)});
            // 
            // sqlCmdUpdSincroEstructuraPDA
            // 
            this.sqlCmdUpdSincroEstructuraPDA.CommandText = "dbo.[WSCliUpdSincroEstructuraPDA]";
            this.sqlCmdUpdSincroEstructuraPDA.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdSincroEstructuraPDA.Connection = this.sqlConn;
            this.sqlCmdUpdSincroEstructuraPDA.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdDelegado", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sCommand", System.Data.SqlDbType.VarChar, 2147483647),
            new System.Data.SqlClient.SqlParameter("@dFechaEjecucion", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@dfecha", System.Data.SqlDbType.DateTime, 8)});
            // 
            // sqlCmdUpdTramosRentabilidad
            // 
            this.sqlCmdUpdTramosRentabilidad.CommandText = "dbo.[WSCliUpdTramosRentabilidad]";
            this.sqlCmdUpdTramosRentabilidad.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdTramosRentabilidad.Connection = this.sqlConn;
            this.sqlCmdUpdTramosRentabilidad.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@idTramo", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@fValMinTramo", System.Data.SqlDbType.Float, 8),
            new System.Data.SqlClient.SqlParameter("@fValMaxTramo", System.Data.SqlDbType.Float, 8),
            new System.Data.SqlClient.SqlParameter("@sDescripcion", System.Data.SqlDbType.VarChar, 50),
            new System.Data.SqlClient.SqlParameter("@sColor", System.Data.SqlDbType.VarChar, 50),
            new System.Data.SqlClient.SqlParameter("@bActivo", System.Data.SqlDbType.Bit, 1),
            new System.Data.SqlClient.SqlParameter("@dIniVig", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@dFinVig", System.Data.SqlDbType.DateTime, 8)});
            // 
            // sqlCmdUpdCampanyas
            // 
            this.sqlCmdUpdCampanyas.CommandText = "WSCliUpdCampanyas";
            this.sqlCmdUpdCampanyas.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdCampanyas.Connection = this.sqlConn;
            this.sqlCmdUpdCampanyas.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@idCampanya", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@NombreCampanya", System.Data.SqlDbType.VarChar, 100),
            new System.Data.SqlClient.SqlParameter("@bSeleccionable", System.Data.SqlDbType.Bit, 1),
            new System.Data.SqlClient.SqlParameter("@iNumMinOblis", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@fImporteMinObli", System.Data.SqlDbType.Float, 8),
            new System.Data.SqlClient.SqlParameter("@fDescImpNeto", System.Data.SqlDbType.Float, 8),
            new System.Data.SqlClient.SqlParameter("@bArrastre", System.Data.SqlDbType.Bit, 1),
            new System.Data.SqlClient.SqlParameter("@dFUM", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt, 2),
            new System.Data.SqlClient.SqlParameter("@fImporteMinObliBruto", System.Data.SqlDbType.Float, 8),
            new System.Data.SqlClient.SqlParameter("@iNumMinOblisTotal", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@bInfDesc", System.Data.SqlDbType.Bit, 1),
            new System.Data.SqlClient.SqlParameter("@bDescExtra", System.Data.SqlDbType.Bit, 1),
            new System.Data.SqlClient.SqlParameter("@bAfectaRentabilidad", System.Data.SqlDbType.Bit, 1),
            new System.Data.SqlClient.SqlParameter("@fDescMinGar", System.Data.SqlDbType.Float, 8),
            new System.Data.SqlClient.SqlParameter("@sObservaciones", System.Data.SqlDbType.VarChar, 250),
            new System.Data.SqlClient.SqlParameter("@fRentMin", System.Data.SqlDbType.Float, 8),
            new System.Data.SqlClient.SqlParameter("@dVigenciaIni", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@dVigenciaFin", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@sSumaUnidades", System.Data.SqlDbType.VarChar, 4),
            new System.Data.SqlClient.SqlParameter("@bSoloNoVendidos", System.Data.SqlDbType.Bit, 1),
            new System.Data.SqlClient.SqlParameter("@bCompetencia", System.Data.SqlDbType.Bit, 1),
            new System.Data.SqlClient.SqlParameter("@bDuplicados", System.Data.SqlDbType.Bit, 1)});
            // 
            // sqlCmdUpdArrastres
            // 
            this.sqlCmdUpdArrastres.CommandText = "WSCliUpdArrastres";
            this.sqlCmdUpdArrastres.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdArrastres.Connection = this.sqlConn;
            this.sqlCmdUpdArrastres.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@idArrastre", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@idCampanyaA", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@idPaqueteA", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@idCampanyaB", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@idPaqueteB", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@dFUM", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt, 2)});
            // 
            // sqlCmdUpdPaquetes
            // 
            this.sqlCmdUpdPaquetes.CommandText = "WSCliUpdPaquetes";
            this.sqlCmdUpdPaquetes.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdPaquetes.Connection = this.sqlConn;
            this.sqlCmdUpdPaquetes.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@idPaquete", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@NombrePaquete", System.Data.SqlDbType.VarChar, 100),
            new System.Data.SqlClient.SqlParameter("@dFUM", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt, 2)});
            // 
            // sqlCmdUpdCampanyasCabecera
            // 
            this.sqlCmdUpdCampanyasCabecera.CommandText = "WSCliUpdCampanyasCabecera";
            this.sqlCmdUpdCampanyasCabecera.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdCampanyasCabecera.Connection = this.sqlConn;
            this.sqlCmdUpdCampanyasCabecera.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@IdCampanya", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@NombreCampanya", System.Data.SqlDbType.VarChar, 100),
            new System.Data.SqlClient.SqlParameter("@Descuento", System.Data.SqlDbType.Float, 8),
            new System.Data.SqlClient.SqlParameter("@sIdTipoPedido", System.Data.SqlDbType.VarChar, 4),
            new System.Data.SqlClient.SqlParameter("@fImporteMinObli", System.Data.SqlDbType.Float, 8),
            new System.Data.SqlClient.SqlParameter("@dFUM", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt, 2),
            new System.Data.SqlClient.SqlParameter("@fImporteMinObliBruto", System.Data.SqlDbType.Float, 8),
            new System.Data.SqlClient.SqlParameter("@iNumMinUnidades", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@fRentMin", System.Data.SqlDbType.Float, 8),
            new System.Data.SqlClient.SqlParameter("@dVigenciaIni", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@dVigenciaFin", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@bCondPago", System.Data.SqlDbType.Bit, 1),
            new System.Data.SqlClient.SqlParameter("@dFechaFacturacion", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@bSoloFlex", System.Data.SqlDbType.Bit, 1),
            new System.Data.SqlClient.SqlParameter("@sCodPagoFija", System.Data.SqlDbType.VarChar, 4)});
            // 
            // sqlCmdUpdDatos_CRM_CLUB
            // 
            this.sqlCmdUpdDatos_CRM_CLUB.CommandText = "WSUpdDatos_CRM_CLUB";
            this.sqlCmdUpdDatos_CRM_CLUB.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdDatos_CRM_CLUB.Connection = this.sqlConn;
            this.sqlCmdUpdDatos_CRM_CLUB.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@Cliente", System.Data.SqlDbType.VarChar, 11),
            new System.Data.SqlClient.SqlParameter("@Tipo", System.Data.SqlDbType.VarChar, 1),
            new System.Data.SqlClient.SqlParameter("@Anyo", System.Data.SqlDbType.VarChar, 4),
            new System.Data.SqlClient.SqlParameter("@Mes", System.Data.SqlDbType.VarChar, 2),
            new System.Data.SqlClient.SqlParameter("@Importe", System.Data.SqlDbType.Float, 8),
            new System.Data.SqlClient.SqlParameter("@SidMaterial", System.Data.SqlDbType.VarChar, 18),
            new System.Data.SqlClient.SqlParameter("@VKGRP", System.Data.SqlDbType.VarChar, 3),
            new System.Data.SqlClient.SqlParameter("@Unidades", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@Sincronizado", System.Data.SqlDbType.VarChar, 1),
            new System.Data.SqlClient.SqlParameter("@ImporteBruto", System.Data.SqlDbType.Float, 8),
            new System.Data.SqlClient.SqlParameter("@Desc1", System.Data.SqlDbType.Float, 8),
            new System.Data.SqlClient.SqlParameter("@Desc2", System.Data.SqlDbType.Float, 8),
            new System.Data.SqlClient.SqlParameter("@Desc3", System.Data.SqlDbType.Float, 8),
            new System.Data.SqlClient.SqlParameter("@Desc4", System.Data.SqlDbType.Float, 8),
            new System.Data.SqlClient.SqlParameter("@Desc5", System.Data.SqlDbType.Float, 8),
            new System.Data.SqlClient.SqlParameter("@sReferencia", System.Data.SqlDbType.VarChar, 10)});
            // 
            // sqlCmdUpdProductosCampanya
            // 
            this.sqlCmdUpdProductosCampanya.CommandText = "WSCliUpdProductosCampanya";
            this.sqlCmdUpdProductosCampanya.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdProductosCampanya.Connection = this.sqlConn;
            this.sqlCmdUpdProductosCampanya.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@sIdProducto", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@idCampanya", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@iNumMinOblis", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@fImporteMinObli", System.Data.SqlDbType.Float, 8),
            new System.Data.SqlClient.SqlParameter("@fImporteMinObliBruto", System.Data.SqlDbType.Float, 8),
            new System.Data.SqlClient.SqlParameter("@fDescuentoMax", System.Data.SqlDbType.Float, 8),
            new System.Data.SqlClient.SqlParameter("@dFUM", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt, 2)});
            // 
            // sqlCmdUpdClubsAviso
            // 
            this.sqlCmdUpdClubsAviso.CommandText = "WSCliUpdClubsAviso";
            this.sqlCmdUpdClubsAviso.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdClubsAviso.Connection = this.sqlConn;
            this.sqlCmdUpdClubsAviso.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@sGarantia", System.Data.SqlDbType.VarChar, 4),
            new System.Data.SqlClient.SqlParameter("@dFUM", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt, 2)});
            // 
            // sqlCmdUpdDescuento_Mayoristas
            // 
            this.sqlCmdUpdDescuento_Mayoristas.CommandText = "WSCliUpdDescuento_Mayoristas";
            this.sqlCmdUpdDescuento_Mayoristas.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdDescuento_Mayoristas.Connection = this.sqlConn;
            this.sqlCmdUpdDescuento_Mayoristas.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdDestinatario", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sGarantias", System.Data.SqlDbType.VarChar, 4),
            new System.Data.SqlClient.SqlParameter("@fDescuentoMayorista", System.Data.SqlDbType.Float, 8),
            new System.Data.SqlClient.SqlParameter("@dFUM", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@fDescMayAvanzado", System.Data.SqlDbType.Float, 8)});
            // 
            // sqlCmdUpdCondicionesComercialesProductos
            // 
            this.sqlCmdUpdCondicionesComercialesProductos.CommandText = "WSCliUpdCondicionesComercialesProductos";
            this.sqlCmdUpdCondicionesComercialesProductos.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdCondicionesComercialesProductos.Connection = this.sqlConn;
            this.sqlCmdUpdCondicionesComercialesProductos.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@sIdProducto", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@sIdSubProducto", System.Data.SqlDbType.VarChar, 50),
            new System.Data.SqlClient.SqlParameter("@sDescSubProducto", System.Data.SqlDbType.VarChar, 100),
            new System.Data.SqlClient.SqlParameter("@dFUM", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt, 2)});
            // 
            // sqlCmdUpdCondicionesComercialesMateriales
            // 
            this.sqlCmdUpdCondicionesComercialesMateriales.CommandText = "WSCliUpdCondicionesComercialesMateriales";
            this.sqlCmdUpdCondicionesComercialesMateriales.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdCondicionesComercialesMateriales.Connection = this.sqlConn;
            this.sqlCmdUpdCondicionesComercialesMateriales.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@sIdSubProducto", System.Data.SqlDbType.VarChar, 50),
            new System.Data.SqlClient.SqlParameter("@sIdMaterial", System.Data.SqlDbType.VarChar, 18),
            new System.Data.SqlClient.SqlParameter("@dFUM", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt, 2)});
            // 
            // sqlCmdUpdCondicionesComercialesGrupos
            // 
            this.sqlCmdUpdCondicionesComercialesGrupos.CommandText = "WSCliUpdCondicionesComercialesGrupos";
            this.sqlCmdUpdCondicionesComercialesGrupos.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdCondicionesComercialesGrupos.Connection = this.sqlConn;
            this.sqlCmdUpdCondicionesComercialesGrupos.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@IdGrupo", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sDescGrupo", System.Data.SqlDbType.VarChar, 200),
            new System.Data.SqlClient.SqlParameter("@iIdProvincia", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@dFechaVencimiento", System.Data.SqlDbType.DateTime),
            new System.Data.SqlClient.SqlParameter("@iDiasVencimiento", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@fImporte", System.Data.SqlDbType.Float, 8),
            new System.Data.SqlClient.SqlParameter("@dFUM", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt, 2)});
            // 
            // sqlCmdUpdCondicionesComerciales
            // 
            this.sqlCmdUpdCondicionesComerciales.CommandText = "WSCliUpdCondicionesComerciales";
            this.sqlCmdUpdCondicionesComerciales.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdCondicionesComerciales.Connection = this.sqlConn;
            this.sqlCmdUpdCondicionesComerciales.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@IdGrupo", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sIdSubProducto", System.Data.SqlDbType.VarChar, 50),
            new System.Data.SqlClient.SqlParameter("@iUnidades", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@dFUM", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt, 2)});
            // 
            // sqlCmdUpdAccMarkCamp
            // 
            this.sqlCmdUpdAccMarkCamp.CommandText = "[WSCliUpdAccMarkCamp]";
            this.sqlCmdUpdAccMarkCamp.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdAccMarkCamp.Connection = this.sqlConn;
            this.sqlCmdUpdAccMarkCamp.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@sIdAccion", System.Data.SqlDbType.VarChar, 15),
            new System.Data.SqlClient.SqlParameter("@IdCampanya", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@fDescuento", System.Data.SqlDbType.Float),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt, 2),
            new System.Data.SqlClient.SqlParameter("@dFUM", System.Data.SqlDbType.DateTime, 8)});
            // 
            // sqlCmdUpdCostes
            // 
            this.sqlCmdUpdCostes.CommandText = "[WSCliUpdCostes]";
            this.sqlCmdUpdCostes.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdCostes.Connection = this.sqlConn;
            this.sqlCmdUpdCostes.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@sCodSAP", System.Data.SqlDbType.VarChar, 18),
            new System.Data.SqlClient.SqlParameter("@dFecIni", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@dFecFin", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@fCoste", System.Data.SqlDbType.Float),
            new System.Data.SqlClient.SqlParameter("@iCuenta", System.Data.SqlDbType.SmallInt)});
            // 
            // sqlCmdUpdComponentes
            // 
            this.sqlCmdUpdComponentes.CommandText = "[WSCliUpdComponentes]";
            this.sqlCmdUpdComponentes.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdComponentes.Connection = this.sqlConn;
            this.sqlCmdUpdComponentes.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@sIdMaterialPack", System.Data.SqlDbType.VarChar, 50),
            new System.Data.SqlClient.SqlParameter("@sIdMaterial", System.Data.SqlDbType.VarChar, 50),
            new System.Data.SqlClient.SqlParameter("@iUnidades", System.Data.SqlDbType.Int, 4)});
            // 
            // sqlCmdUpdMUV
            // 
            this.sqlCmdUpdMUV.CommandText = "[WSCliUpdMinimoUnidadesVenta]";
            this.sqlCmdUpdMUV.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdMUV.Connection = this.sqlConn;
            this.sqlCmdUpdMUV.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@sIdProducto", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@sIdMaterial", System.Data.SqlDbType.VarChar, 18),
            new System.Data.SqlClient.SqlParameter("@dFecIni", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@dFecFin", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@sIdCliente", System.Data.SqlDbType.VarChar, 20),
            new System.Data.SqlClient.SqlParameter("@iMinQty", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sObservaciones", System.Data.SqlDbType.VarChar, 100),
            new System.Data.SqlClient.SqlParameter("@sObservaciones2", System.Data.SqlDbType.VarChar, 100),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt),
            new System.Data.SqlClient.SqlParameter("@dFUM", System.Data.SqlDbType.DateTime, 8)});
            // 
            // sqlCmdUpdDescuentoMax
            // 
            this.sqlCmdUpdDescuentoMax.CommandText = "[WSCliUpdDescuentoMax]";
            this.sqlCmdUpdDescuentoMax.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdDescuentoMax.Connection = this.sqlConn;
            this.sqlCmdUpdDescuentoMax.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sIdCliente", System.Data.SqlDbType.VarChar, 20),
            new System.Data.SqlClient.SqlParameter("@sIdMaterial", System.Data.SqlDbType.VarChar, 18),
            new System.Data.SqlClient.SqlParameter("@fDescuentoMaximo", System.Data.SqlDbType.Float),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt)});
            // 
            // sqlCmdUpdDirectoZMAY
            // 
            this.sqlCmdUpdDirectoZMAY.CommandText = "[WSCliUpdDirectoZMAY]";
            this.sqlCmdUpdDirectoZMAY.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdDirectoZMAY.Connection = this.sqlConn;
            this.sqlCmdUpdDirectoZMAY.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@sGarantia", System.Data.SqlDbType.VarChar, 4),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt),
            new System.Data.SqlClient.SqlParameter("@dFUM", System.Data.SqlDbType.DateTime, 8)});
            // 
            // sqlCmdUpdCampanyasVisibles
            // 
            this.sqlCmdUpdCampanyasVisibles.CommandText = "[WSCliUpdCampanyasVisibles]";
            this.sqlCmdUpdCampanyasVisibles.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdCampanyasVisibles.Connection = this.sqlConn;
            this.sqlCmdUpdCampanyasVisibles.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@sTipoCampanya", System.Data.SqlDbType.VarChar, 3),
            new System.Data.SqlClient.SqlParameter("@IdCampanya", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@sIdDelegado", System.Data.SqlDbType.VarChar, 4),
            new System.Data.SqlClient.SqlParameter("@sIdTipoPedido", System.Data.SqlDbType.VarChar, 4),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt),
            new System.Data.SqlClient.SqlParameter("@dFUM", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@sIdMayorista", System.Data.SqlDbType.VarChar, 20)});
            // 
            // sqlCmdUpdClientesOnLine
            // 
            this.sqlCmdUpdClientesOnLine.CommandText = "[WSCliUpdClientesOnLine]";
            this.sqlCmdUpdClientesOnLine.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdClientesOnLine.Connection = this.sqlConn;
            this.sqlCmdUpdClientesOnLine.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sNombre", System.Data.SqlDbType.VarChar, 100),
            new System.Data.SqlClient.SqlParameter("@bOperativa", System.Data.SqlDbType.Bit),
            new System.Data.SqlClient.SqlParameter("@bLinkLadival", System.Data.SqlDbType.Bit),
            new System.Data.SqlClient.SqlParameter("@sURL", System.Data.SqlDbType.VarChar, 50),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt, 2),
            new System.Data.SqlClient.SqlParameter("@dFUM", System.Data.SqlDbType.DateTime, 8)});
            // 
            // sqlCmdUpdEmailsClientes
            // 
            this.sqlCmdUpdEmailsClientes.CommandText = "[WSCliUpdEmailsClientes]";
            this.sqlCmdUpdEmailsClientes.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdEmailsClientes.Connection = this.sqlConn;
            this.sqlCmdUpdEmailsClientes.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@dFecha", System.Data.SqlDbType.DateTime),
            new System.Data.SqlClient.SqlParameter("@sEmailConf", System.Data.SqlDbType.VarChar, 50),
            new System.Data.SqlClient.SqlParameter("@sEmailFact", System.Data.SqlDbType.VarChar, 50),
            new System.Data.SqlClient.SqlParameter("@bTratado", System.Data.SqlDbType.Bit, 1),
            new System.Data.SqlClient.SqlParameter("@dFUM", System.Data.SqlDbType.DateTime, 8)});
            // 
            // sqlCmdUpdPedidosCentral
            // 
            this.sqlCmdUpdPedidosCentral.CommandText = "[WSCliUpdPedidosCentral]";
            this.sqlCmdUpdPedidosCentral.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdPedidosCentral.Connection = this.sqlConn;
            this.sqlCmdUpdPedidosCentral.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@sIdPedido", System.Data.SqlDbType.VarChar, 12),
            new System.Data.SqlClient.SqlParameter("@iIdDelegado", System.Data.SqlDbType.Int, 4)});
            // 
            // sqlCmdUpdTarjetasCliente
            // 
            this.sqlCmdUpdTarjetasCliente.CommandText = "[WSCliUpdTarjetasCliente]";
            this.sqlCmdUpdTarjetasCliente.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdTarjetasCliente.Connection = this.sqlConn;
            this.sqlCmdUpdTarjetasCliente.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@sIdCliente", System.Data.SqlDbType.VarChar, 20),
            new System.Data.SqlClient.SqlParameter("@sIdMaterial", System.Data.SqlDbType.VarChar, 18),
            new System.Data.SqlClient.SqlParameter("@dFecAsignacion", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@dFecUso", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@dFUM", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt),
            new System.Data.SqlClient.SqlParameter("@sIdProducto", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@iUnidadesMin", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@fBrutoMin", System.Data.SqlDbType.Float, 8),
            new System.Data.SqlClient.SqlParameter("@dIniValidez", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@dFinValidez", System.Data.SqlDbType.DateTime, 8)});
            // 
            // sqlCmdUpdAccMarkProd
            // 
            this.sqlCmdUpdAccMarkProd.CommandText = "[WSCliUpdAccMarkProductos]";
            this.sqlCmdUpdAccMarkProd.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdAccMarkProd.Connection = this.sqlConn;
            this.sqlCmdUpdAccMarkProd.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@sIdAccion", System.Data.SqlDbType.VarChar, 15),
            new System.Data.SqlClient.SqlParameter("@sIdProducto", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@dFUM", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt)});
            // 
            // sqlCmdUpdAccMarkRangos
            // 
            this.sqlCmdUpdAccMarkRangos.CommandText = "[WSCliUpdAccMarkRangos]";
            this.sqlCmdUpdAccMarkRangos.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdAccMarkRangos.Connection = this.sqlConn;
            this.sqlCmdUpdAccMarkRangos.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@Id", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@fImporteMin", System.Data.SqlDbType.Float, 8),
            new System.Data.SqlClient.SqlParameter("@fImporteMax", System.Data.SqlDbType.Float, 8),
            new System.Data.SqlClient.SqlParameter("@iMaxNumAccMark", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt),
            new System.Data.SqlClient.SqlParameter("@dFUM", System.Data.SqlDbType.DateTime, 8)});
            // 
            // sqlCmdUpdAccMarkExclusion
            // 
            this.sqlCmdUpdAccMarkExclusion.CommandText = "[WSCliUpdAccMarkExclusion]";
            this.sqlCmdUpdAccMarkExclusion.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdAccMarkExclusion.Connection = this.sqlConn;
            this.sqlCmdUpdAccMarkExclusion.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdAccion1", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdAccion2", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt),
            new System.Data.SqlClient.SqlParameter("@dFUM", System.Data.SqlDbType.DateTime, 8)});
            // 
            // sqlCmdUpdGrupoCampanya
            // 
            this.sqlCmdUpdGrupoCampanya.CommandText = "[WSCliUpdGrupoCampanya]";
            this.sqlCmdUpdGrupoCampanya.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdGrupoCampanya.Connection = this.sqlConn;
            this.sqlCmdUpdGrupoCampanya.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@idGrupo", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@idCampanya", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@sMateriales", System.Data.SqlDbType.VarChar, 500),
            new System.Data.SqlClient.SqlParameter("@iMinUnidades", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@fMinImporte", System.Data.SqlDbType.Float, 8),
            new System.Data.SqlClient.SqlParameter("@sIdTipoPedido", System.Data.SqlDbType.VarChar, 4),
            new System.Data.SqlClient.SqlParameter("@dFUM", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@iMaxUnidades", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@fMaxImporte", System.Data.SqlDbType.Float, 8),
            new System.Data.SqlClient.SqlParameter("@bObligatorio", System.Data.SqlDbType.Bit, 1)});
            // 
            // sqlCmdUpdReglasGruposCamp
            // 
            this.sqlCmdUpdReglasGruposCamp.CommandText = "[WSCliUpdReglasGruposCamp]";
            this.sqlCmdUpdReglasGruposCamp.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdReglasGruposCamp.Connection = this.sqlConn;
            this.sqlCmdUpdReglasGruposCamp.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@idGrupoM", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@idGrupoS", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@sTipoCalculo", System.Data.SqlDbType.VarChar, 1),
            new System.Data.SqlClient.SqlParameter("@iUBaseM", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iUBaseS", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@dFUM", System.Data.SqlDbType.DateTime, 8)});
            // 
            // sqlCmdUpdUbicaciones
            // 
            this.sqlCmdUpdUbicaciones.CommandText = "[WSCliUpdUbicaciones]";
            this.sqlCmdUpdUbicaciones.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdUbicaciones.Connection = this.sqlConn;
            this.sqlCmdUpdUbicaciones.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@Id", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sDireccion", System.Data.SqlDbType.VarChar, 100),
            new System.Data.SqlClient.SqlParameter("@sPoblacion", System.Data.SqlDbType.VarChar, 100),
            new System.Data.SqlClient.SqlParameter("@sCP", System.Data.SqlDbType.VarChar, 5),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@dFUM", System.Data.SqlDbType.DateTime, 8)});
            // 
            // sqlCmdUpdDivsPedidos
            // 
            this.sqlCmdUpdDivsPedidos.CommandText = "[WSCliUpdDivsPedido]";
            this.sqlCmdUpdDivsPedidos.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdDivsPedidos.Connection = this.sqlConn;
            this.sqlCmdUpdDivsPedidos.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@sIdCampanya", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@sIdMaterial", System.Data.SqlDbType.VarChar, 18),
            new System.Data.SqlClient.SqlParameter("@sIdRed", System.Data.SqlDbType.VarChar, 4),
            new System.Data.SqlClient.SqlParameter("@sIdTipoPedido", System.Data.SqlDbType.VarChar, 4),
            new System.Data.SqlClient.SqlParameter("@sTipoSAP", System.Data.SqlDbType.VarChar, 2),
            new System.Data.SqlClient.SqlParameter("@bFechaPreferente", System.Data.SqlDbType.Bit, 1),
            new System.Data.SqlClient.SqlParameter("@sIdTipoPedidoNuevo", System.Data.SqlDbType.VarChar, 4),
            new System.Data.SqlClient.SqlParameter("@sIdTipoPosicion", System.Data.SqlDbType.VarChar, 4),
            new System.Data.SqlClient.SqlParameter("@dFecEntrega", System.Data.SqlDbType.DateTime, 10),
            new System.Data.SqlClient.SqlParameter("@dFechaFacturacion", System.Data.SqlDbType.DateTime, 10),
            new System.Data.SqlClient.SqlParameter("@sCodPagoFija", System.Data.SqlDbType.VarChar, 4),
            new System.Data.SqlClient.SqlParameter("@bNoDivide", System.Data.SqlDbType.Bit, 1),
            new System.Data.SqlClient.SqlParameter("@sCampCab", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@dFUM", System.Data.SqlDbType.DateTime, 8)});


            //---- GSG (03/07/2019)
            // 
            // sqlCmdUpdSRVYEncuesta
            // 
            this.sqlCmdUpdSRVYEncuesta.CommandText = "[WSCliUpdSRVYEncuesta]";
            this.sqlCmdUpdSRVYEncuesta.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdSRVYEncuesta.Connection = this.sqlConn;
            this.sqlCmdUpdSRVYEncuesta.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@IdEncuesta", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sDescripcion", System.Data.SqlDbType.VarChar, 250),
            new System.Data.SqlClient.SqlParameter("@dFecIni", System.Data.SqlDbType.DateTime, 10),
            new System.Data.SqlClient.SqlParameter("@dFecFin", System.Data.SqlDbType.DateTime, 10),
            new System.Data.SqlClient.SqlParameter("@bObligatoria", System.Data.SqlDbType.Bit, 1),
            new System.Data.SqlClient.SqlParameter("@dFUM", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt, 2)});

            // 
            // sqlCmdUpdSRVYPregunta
            // 
            this.sqlCmdUpdSRVYPregunta.CommandText = "[WSCliUpdSRVYPregunta]";
            this.sqlCmdUpdSRVYPregunta.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdSRVYPregunta.Connection = this.sqlConn;
            this.sqlCmdUpdSRVYPregunta.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@IdPregunta", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@IdEncuesta", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sPregunta", System.Data.SqlDbType.VarChar, 250),
            new System.Data.SqlClient.SqlParameter("@dFUM", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt, 2)});

            // 
            // sqlCmdUpdSRVYRespuesta
            // 
            this.sqlCmdUpdSRVYRespuesta.CommandText = "[WSCliUpdSRVYRespuesta]";
            this.sqlCmdUpdSRVYRespuesta.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdSRVYRespuesta.Connection = this.sqlConn;
            this.sqlCmdUpdSRVYRespuesta.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@IdRespuesta", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@IdPregunta", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@IdEncuesta", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sRespuesta", System.Data.SqlDbType.VarChar, 250),
            new System.Data.SqlClient.SqlParameter("@dFUM", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt, 2)});

            // 
            // sqlCmdUpdSRVYClienteEncuesta
            // 
            this.sqlCmdUpdSRVYClienteEncuesta.CommandText = "[WSCliUpdSRVYClienteEncuesta]";
            this.sqlCmdUpdSRVYClienteEncuesta.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdSRVYClienteEncuesta.Connection = this.sqlConn;
            this.sqlCmdUpdSRVYClienteEncuesta.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdDelegado", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sClasificacion", System.Data.SqlDbType.VarChar, 4),
            new System.Data.SqlClient.SqlParameter("@sIdCliente", System.Data.SqlDbType.VarChar, 20),
            new System.Data.SqlClient.SqlParameter("@IdEncuesta", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@dFecIni", System.Data.SqlDbType.DateTime, 10),
            new System.Data.SqlClient.SqlParameter("@dFecFin", System.Data.SqlDbType.DateTime, 10),
            new System.Data.SqlClient.SqlParameter("@bObligatoria", System.Data.SqlDbType.Bit, 1),
            new System.Data.SqlClient.SqlParameter("@bContestada", System.Data.SqlDbType.Bit, 1),
            new System.Data.SqlClient.SqlParameter("@dFUM", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt, 2)});

            // 
            // sqlCmdUpdSRVYClienteRespuesta
            // 
            this.sqlCmdUpdSRVYClienteRespuesta.CommandText = "[WSCliUpdSRVYClienteRespuesta]";
            this.sqlCmdUpdSRVYClienteRespuesta.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdSRVYClienteRespuesta.Connection = this.sqlConn;
            this.sqlCmdUpdSRVYClienteRespuesta.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@sIdCliente", System.Data.SqlDbType.VarChar, 20),
            new System.Data.SqlClient.SqlParameter("@iIdEncuesta", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdPregunta", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdRespuesta", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@dFUM", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt, 2),
            new System.Data.SqlClient.SqlParameter("@sDelegado", System.Data.SqlDbType.VarChar, 8)}); //---- GSG (24/10/2019)


            //---- GSG (06/03/2021)
            // 
            // sqlCmdUpdGrupoHomogeneo
            // 
            this.sqlCmdUpdGrupoHomogeneo.CommandText = "[WSCliUpdGrupoHomogeneo]";
            this.sqlCmdUpdGrupoHomogeneo.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdGrupoHomogeneo.Connection = this.sqlConn;
            this.sqlCmdUpdGrupoHomogeneo.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@IdAgrupacion", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sCodNacional", System.Data.SqlDbType.VarChar, 8),
            new System.Data.SqlClient.SqlParameter("@sAgrupacionName", System.Data.SqlDbType.VarChar, 100),
            new System.Data.SqlClient.SqlParameter("@sNombreSNS", System.Data.SqlDbType.VarChar, 100),
            new System.Data.SqlClient.SqlParameter("@fPVL", System.Data.SqlDbType.Decimal, 10),
            new System.Data.SqlClient.SqlParameter("@fPVPIVA", System.Data.SqlDbType.Decimal, 10),
            new System.Data.SqlClient.SqlParameter("@fPrecioMenor", System.Data.SqlDbType.Decimal, 10),
            new System.Data.SqlClient.SqlParameter("@fPVPIVAMenor", System.Data.SqlDbType.Decimal, 10),
            new System.Data.SqlClient.SqlParameter("@dFUM", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.Int, 4)});


            //---- GSG (03/01/2023)
            this.sqlCmdUpdMaterialBloquoDescuento.CommandText = "[WSCliUpdMaterialesBloqueoDescuento]";
            this.sqlCmdUpdMaterialBloquoDescuento.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdUpdMaterialBloquoDescuento.Connection = this.sqlConn;
            this.sqlCmdUpdMaterialBloquoDescuento.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@sIdMaterial", System.Data.SqlDbType.VarChar, 18),
            new System.Data.SqlClient.SqlParameter("@dFecIni", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@dFecFin", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@bEsPuro", System.Data.SqlDbType.Bit, 1),
            new System.Data.SqlClient.SqlParameter("@dFUM", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.Int, 4)});

            // 
            // frmSincro
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 19);
            this.ClientSize = new System.Drawing.Size(578, 357);
            this.ControlBox = false;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pnlSincro);
            this.Controls.Add(this.btnIniciar);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSincro";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sincronización con Central";
            this.pnlSincro.ResumeLayout(false);
            this.pnlSincro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbFinish8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbPaso8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbFinish7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbFinish6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbFinish5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbFinish4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbFinish3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbFinish2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbFinish1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbPaso7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbPaso6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbPaso5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbPaso4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbPaso3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbPaso2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbPaso1)).EndInit();
            this.pnlCabSincro.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void btnIniciar_Click(object sender, System.EventArgs e)
		{
			// Solamente se realizará el proceso de sincronizacion 
			// si no hay actualizaciones pendientes de la aplicación
			if (!UpdatePending())
            {

                //if (MessageBox.Show("Si no ha realizado la sincronización con PDA anteriormente\nlos Pedidos y Reportes Generados en ls PDA no se enviarán\na Central.\n\n¿Está seguro que desea iniciar la sincronización con Central?","GESTCRM",MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes)
            //---- GSG (07/11/2011)
            //if (Mensajes.ShowQuestion("Si no ha realizado anteriormente la sincronización con PDA, los pedidos y reportes generados " +
            //        "en la PDA no se enviarán a Central.\n\n¿Está seguro de que desea iniciar la sincronización con Central?") == DialogResult.Yes)
			//	{
            //---- FI GSG
				    Cursor.Current=Cursors.WaitCursor;

				    bool Ok = true;
				    this.btnIniciar.Enabled=false;
				    int iIdSincro = 0 ;
				    string VersionAvailable="";
				    byte[] compressedUpdate = null;
				    byte[] uncompressedUpdate = null;
				    DateTime dFIni = DateTime.Now;
				    Array dFUS= Array.CreateInstance (typeof(DateTime),6);
				    Array updateData = Array.CreateInstance(typeof(string),4); 
				    Array Permisos = Array.CreateInstance(typeof(bool),5); 
                    //---- GSG (13/03/2019)
				    //Font fPaso = new Font("Microsoft Sans Serif",float.Parse("9,75"),System.Drawing.FontStyle.Bold);
                    Font fPaso = new Font("Microsoft Sans Serif", float.Parse("12"), System.Drawing.FontStyle.Bold);


                    WSSinCRM.SincroCRM Sync = new WSSinCRM.SincroCRM();
				    //Deshabilita el timeout del webservice
				    Sync.Timeout = -1;
					
                    this.dsRecibirCEN =null;

				    this.pgbPaso.Value=0;

                    //Paso 1. Conectamos con central.
                    #region paso 1
                
				    try
				    {
					    this.pcbFinish1.Image = SetImage("Run.ico"); 
					    this.lblPaso1.Font=fPaso;
					    this.Refresh(); 
				
					    Sync.Discover();

					    this.pcbFinish1.Image = SetImage("Ok.ico");  
					    this.Refresh(); 
				    }
				    catch (Exception ex)
				    {
					    //MessageBox.Show("No se ha podido conectar con central.\nAsegúrese de tener puesto el cable telefónico y de tener libre la linea.", "Error al conectar");
                        Mensajes.ShowError("Error al conectar.\n\nNo se ha podido conectar con Central. Asegúrese de disponer de conexión a Internet en su ordenador.");
					    Ok = false;
                    }

                    #endregion

                    //Paso 2. Obtenemos la Fecha de Última Sincronización y los permisos de subida.
                    #region paso 2
                    if (Ok)
					{
						try
						{

							this.pcbFinish2.Image = SetImage("Run.ico");  
							this.lblPaso2.Font=fPaso;
							this.Refresh(); 

					
							dFUS=(Array)Sync.IniSincro(GESTCRM.Clases.Configuracion.iIdDelegado,dFIni,Application.ProductVersion.ToString());

							Permisos = (Array)Sync.PermisosSubida(GESTCRM.Clases.Configuracion.iIdDelegado);

							iIdSincro = (int)dFUS.GetValue(6) ;

							VersionAvailable = (string)dFUS.GetValue(7); 
							this.pcbFinish2.Image = SetImage("Ok.ico");  
							this.Refresh(); 

							System.Windows.Forms.Application.DoEvents();
						}
						catch (Exception ex)
						{
							//MessageBox.Show("No se ha podido obtener la información de central.\nPor favor contacte con el departamento de Help Desk.","Error al obtener FUS");
                            Mensajes.ShowError("Error al obtener FUS.\nNo se ha podido obtener la información de Central. Por favor, contacte con el departamento de Help Desk.");
							Ok=false;
						}
                    }

                    #endregion

                    //Paso 3. Recogiendo el Fichero de Central.
                    #region paso 3
                    if (Ok)
					{
						try
						{
							this.pcbFinish3.Image = SetImage("Run.ico"); 
							this.lblPaso3.Font=fPaso;
							this.Refresh(); 

							//Revisa si existe algun archivo XML de Datos no procesados y lo procesa
							//this.dsBajada = ProcesaArchivoDatos();

							this.lblPaso3.Font=fPaso;
							this.lblPaso3.ForeColor = System.Drawing.Color.Black ;  

							//this.dsRecibirCEN=Sync.RecibirDeCentral(GESTCRM.Clases.Configuracion.iIdDelegado);
							
							System.Windows.Forms.Application.DoEvents();
							// Crea las llamadas asíncronas
							pAsync =  Sync.BeginRecibirDeCentral(GESTCRM.Clases.Configuracion.iIdDelegado,null,null); 

							iCurrentPaso = 3;
							this.tmrStatus.Enabled = true; 
							System.Windows.Forms.Application.DoEvents();

						}
						catch (Exception E)
						{
							//MessageBox.Show("Error al obtener la información de Central.\nPor favor contacte con el departamento de Help Desk\ne informe del siguiente error\n\n"+E.Message ,"Error al Recibir Información");
                            Mensajes.ShowError("Error al obtener la información de Central. Por favor, contacte con el departamento de Help Desk e informe del siguiente error:\n" + E.Message);
							Ok=false;
						}
                    }

                    #endregion

                    //Paso 4. Generando el Fichero a enviar a Central.
                    #region paso 4
                    if (Ok)
					{
						try
						{
							this.pcbFinish4.Image = SetImage("Run.ico"); 
							this.lblPaso4.Font=fPaso;
							this.Refresh();

                            //---- GSG CECL 19/05/2016 Debido a los permisos sólo sincronizará pedidos de subida (necesario para fichero SAP)
                            if (System.Configuration.ConfigurationManager.AppSettings["TipoDelegadoPedidosCentral"].ToString() == Comun.K_CECL)
                            {
                                this.sqlDADatosCliente.SelectCommand = sqlSelectCommand1CECL; //"[DatosSincroCECL]"
                                this.sqlDADatosCliente.SelectCommand.Parameters["@iIdDelegado"].Value = GESTCRM.Clases.Configuracion.iIdDelegado;
                            }
                            else
                                this.sqlDADatosCliente.SelectCommand = sqlSelectCommand1; //"[DatosSincro]"
                            //---- FI GSG CECL

					
							//Genera el Dataset para subida en base a un solo DataAdapter
							//Hace los TableMappings

							int tableOrder=0;

							this.sqlDADatosCliente.TableMappings.Clear();

                            //SP DatosSincro
							if ((bool)Permisos.GetValue(0))
							{
								this.sqlDADatosCliente.TableMappings.Add("Table" + (tableOrder==0?"":tableOrder.ToString().Trim())  ,"Clientes");
								tableOrder ++;
								this.sqlDADatosCliente.TableMappings.Add("Table" + (tableOrder==0?"":(tableOrder).ToString().Trim()),"ClientesRedes");
								tableOrder ++;
								this.sqlDADatosCliente.TableMappings.Add("Table" + (tableOrder==0?"":(tableOrder).ToString().Trim()),"ClientesCOM");
								tableOrder ++;
								this.sqlDADatosCliente.TableMappings.Add("Table" + (tableOrder==0?"":(tableOrder).ToString().Trim()),"ProdClientesCOM");
								tableOrder ++;
								this.sqlDADatosCliente.TableMappings.Add("Table" + (tableOrder==0?"":(tableOrder).ToString().Trim()),"EspecClientesCOM");
								tableOrder ++;
								this.sqlDADatosCliente.TableMappings.Add("Table" + (tableOrder==0?"":(tableOrder).ToString().Trim()),"AficClientesCOM");
								tableOrder ++;
								this.sqlDADatosCliente.TableMappings.Add("Table" + (tableOrder==0?"":(tableOrder).ToString().Trim()),"CentrosClientesCOM");
								tableOrder ++;
                                //---- GSG (10/05/2011) finalment no ho elimino
                                this.sqlDADatosCliente.TableMappings.Add("Table" + (tableOrder==0?"":(tableOrder).ToString().Trim()),"ContactosClientesSAP");
                                tableOrder ++;
								//---- FI GSG
                                this.sqlDADatosCliente.TableMappings.Add("Table" + (tableOrder==0?"":(tableOrder).ToString().Trim()),"CentrosClientesSAP");
								tableOrder ++;
								this.sqlDADatosCliente.TableMappings.Add("Table" + (tableOrder==0?"":(tableOrder).ToString().Trim()),"Centros");
								tableOrder ++;
								this.sqlDADatosCliente.TableMappings.Add("Table" + (tableOrder==0?"":(tableOrder).ToString().Trim()),"CentrosRedes");
								tableOrder ++;
								this.sqlDADatosCliente.TableMappings.Add("Table" + (tableOrder==0?"":(tableOrder).ToString().Trim()),"CPClientes");
								tableOrder ++;
								this.sqlDADatosCliente.TableMappings.Add("Table" + (tableOrder==0?"":(tableOrder).ToString().Trim()),"BrickClientes");
								tableOrder ++;
								this.sqlDADatosCliente.TableMappings.Add("Table" + (tableOrder==0?"":(tableOrder).ToString().Trim()),"AccionesMarkClientes");
								tableOrder ++;
								//Modificado en fecha: 12/12/2007 Usuario: VCS -Como no se envia a central lo comento.
								//this.sqlDADatosCliente.TableMappings.Add("Table" + (tableOrder==0?"":(tableOrder).ToString().Trim()),"EstructuraComercial");
								//tableOrder ++;
                                //---- GSG (05/12/2013)
                                this.sqlDADatosCliente.TableMappings.Add("Table" + (tableOrder == 0 ? "" : (tableOrder).ToString().Trim()), "Clientes_OnLine");
                                tableOrder++;
							}

							if ((bool)Permisos.GetValue(1))
							{
								this.sqlDADatosCliente.TableMappings.Add("Table" + (tableOrder==0?"":(tableOrder).ToString().Trim()),"Pedidos_Cab");
								tableOrder ++;
								this.sqlDADatosCliente.TableMappings.Add("Table" + (tableOrder==0?"":(tableOrder).ToString().Trim()),"Pedidos_Lin");
								tableOrder ++;
                                //---- GSG (08/10/2012)
                                this.sqlDADatosCliente.TableMappings.Add("Table" + (tableOrder == 0 ? "" : (tableOrder).ToString().Trim()), "PedAcciones");
                                tableOrder++;
                                //---- GSG (09/01/2014)
                                this.sqlDADatosCliente.TableMappings.Add("Table" + (tableOrder == 0 ? "" : (tableOrder).ToString().Trim()), "EmailsClientes");
                                tableOrder++;
                                //---- GSG (18/03/2014)
                                this.sqlDADatosCliente.TableMappings.Add("Table" + (tableOrder == 0 ? "" : (tableOrder).ToString().Trim()), "AutoPedAccMark");
                                tableOrder++;

                                //RH: Esta tabla ya no se usa. ATENCIÓN: Cuando se quitan tablas de aquí hay que actualizar el SP DatosSincro
                                //this.sqlDADatosCliente.TableMappings.Add("Table" + (tableOrder==0?"":(tableOrder).ToString().Trim()),"CampanyasPedido");
                                //tableOrder ++;
							}

							if ((bool)Permisos.GetValue(2))
							{
								this.sqlDADatosCliente.TableMappings.Add("Table" + (tableOrder==0?"":(tableOrder).ToString().Trim()),"Atencionescomerciales");
								tableOrder ++;
								this.sqlDADatosCliente.TableMappings.Add("Table" + (tableOrder==0?"":(tableOrder).ToString().Trim()),"AtencionesProductos");
								tableOrder ++;
							}

							if ((bool)Permisos.GetValue(3))
							{
								this.sqlDADatosCliente.TableMappings.Add("Table" + (tableOrder==0?"":(tableOrder).ToString().Trim()),"RepActividadCab");
								tableOrder ++;
								this.sqlDADatosCliente.TableMappings.Add("Table" + (tableOrder==0?"":(tableOrder).ToString().Trim()),"RepActividadCli");
								tableOrder ++;
								this.sqlDADatosCliente.TableMappings.Add("Table" + (tableOrder==0?"":(tableOrder).ToString().Trim()),"RepActividadAten");
								tableOrder ++;
								this.sqlDADatosCliente.TableMappings.Add("Table" + (tableOrder==0?"":(tableOrder).ToString().Trim()),"RepActividadProxObj");
								tableOrder ++;
								this.sqlDADatosCliente.TableMappings.Add("Table" + (tableOrder==0?"":(tableOrder).ToString().Trim()),"RepActGAD");
								tableOrder ++;
								this.sqlDADatosCliente.TableMappings.Add("Table" + (tableOrder==0?"":(tableOrder).ToString().Trim()),"RepActividadPed");
								tableOrder ++;
								this.sqlDADatosCliente.TableMappings.Add("Table" + (tableOrder==0?"":(tableOrder).ToString().Trim()),"RepActividadProm");
								tableOrder ++;
							}

							if ((bool)Permisos.GetValue(4) )
							{
								this.sqlDADatosCliente.TableMappings.Add("Table" + (tableOrder==0?"":(tableOrder).ToString().Trim()),"NotasGastos");
								tableOrder ++;
								this.sqlDADatosCliente.TableMappings.Add("Table" + (tableOrder==0?"":(tableOrder).ToString().Trim()),"NotasGastos_Lin");
								tableOrder ++;
								this.sqlDADatosCliente.TableMappings.Add("Table" + (tableOrder==0?"":(tableOrder).ToString().Trim()),"AtencionesNG");
								tableOrder ++;
							}

                            //---- GSG CECL 19/05/2016 Debido a los permisos sólo sincronizará pedidos de subida (necesario para fichero SAP)
                            if (System.Configuration.ConfigurationManager.AppSettings["TipoDelegadoPedidosCentral"].ToString() != Comun.K_CECL)
                            {
                                //---- FI GSG CECL
                                //this.sqlDADatosCliente.TableMappings.Add("Table" + (tableOrder==0?"":(tableOrder).ToString().Trim()),"DelegadoBrick");
                                //tableOrder ++;
                                this.sqlDADatosCliente.TableMappings.Add("Table" + (tableOrder == 0 ? "" : (tableOrder).ToString().Trim()), "Presupuestos");
                                tableOrder++;
                                this.sqlDADatosCliente.TableMappings.Add("Table" + (tableOrder == 0 ? "" : (tableOrder).ToString().Trim()), "Agenda");
                                tableOrder++;
                                this.sqlDADatosCliente.TableMappings.Add("Table" + (tableOrder == 0 ? "" : (tableOrder).ToString().Trim()), "SolicitudGadget");
                                tableOrder++;
                                this.sqlDADatosCliente.TableMappings.Add("Table" + (tableOrder == 0 ? "" : (tableOrder).ToString().Trim()), "SincroEstructuraPDA");
                                //---- GSG (15/10/2015)
                                tableOrder++;
                                this.sqlDADatosCliente.TableMappings.Add("Table" + (tableOrder == 0 ? "" : (tableOrder).ToString().Trim()), "TarjetasCliente");

                                //---- GSG (03/07/2019)
                                tableOrder++;
                                this.sqlDADatosCliente.TableMappings.Add("Table" + (tableOrder == 0 ? "" : (tableOrder).ToString().Trim()), "SRVYClienteRespuesta");
                            }

							this.sqlDADatosCliente.SelectCommand.Parameters["@dFUS"].Value= dFUS.GetValue(0);
							this.sqlDADatosCliente.SelectCommand.Parameters["@dFUSClientes"].Value=((bool)Permisos.GetValue(0)?dFUS.GetValue(4):System.Data.SqlTypes.SqlDateTime.Null )    ;
							this.sqlDADatosCliente.SelectCommand.Parameters["@dFUSPedidos"].Value=((bool)Permisos.GetValue(1)?dFUS.GetValue(5):System.Data.SqlTypes.SqlDateTime.Null )    ;
							this.sqlDADatosCliente.SelectCommand.Parameters["@dFUSVisitas"].Value=((bool)Permisos.GetValue(3)?dFUS.GetValue(2):System.Data.SqlTypes.SqlDateTime.Null )    ;
							this.sqlDADatosCliente.SelectCommand.Parameters["@dFUSAtenciones"].Value=((bool)Permisos.GetValue(2)?dFUS.GetValue(3):System.Data.SqlTypes.SqlDateTime.Null )    ;
							this.sqlDADatosCliente.SelectCommand.Parameters["@dFUSGastos"].Value=((bool)Permisos.GetValue(4)?dFUS.GetValue(1):System.Data.SqlTypes.SqlDateTime.Null )    ;

							System.Windows.Forms.Application.DoEvents();
							this.sqlDADatosCliente.Fill(this.dsEnviarCEN);
							System.Windows.Forms.Application.DoEvents();

							this.pcbFinish4.Image = SetImage("Ok.ico");
							this.Refresh(); 
  
							// Espera por el termino del paso 3
							pAsync.AsyncWaitHandle.WaitOne();
  
							this.dsRecibirCEN=Sync.EndRecibirDeCentral(pAsync); 
							this.pcbFinish3.Image = SetImage("Ok.ico");
							this.Refresh(); 
							
						}
						catch (Exception E)
						{
//							if (dsRecibirCEN!=null)
//							{
//								this.GrabaArchivoDatos(dsRecibirCEN);
//							}
							if (this.sqlConn.State == System.Data.ConnectionState.Open) this.sqlConn.Close();
							//MessageBox.Show("No se ha podido generar la información.\nPor favor contacte con el departamento de Help Desk\ne informe del siguiente error\n\n"+E.Message,"Error al generar la información");
                            MessageBox.Show("No se ha podido generar la información. Por favor, contacte con el departamento de Help Desk e informe del siguiente error:\n" + E.Message);
							Ok=false;
						}
                    }

                    #endregion

                    //Paso 5. Enviando el Fichero a Central.
                    #region paso 5
                    if (Ok)
					{
						try
						{
							this.pcbFinish5.Image = SetImage("Run.ico");
							this.lblPaso5.Font=fPaso;
							this.Refresh();
 
							System.Windows.Forms.Application.DoEvents();

							// Crea las llamadas asíncronas
							pAsync =  Sync.BeginEnviarACentral(GESTCRM.Clases.Configuracion.iIdDelegado,this.dsEnviarCEN,null,null); 
							//dsRetorno=Sync.EnviarACentral(GESTCRM.Clases.Configuracion.iIdDelegado,this.dsEnviarCEN);
	
							System.Windows.Forms.Application.DoEvents();

							iCurrentPaso = 5;
							this.tmrStatus.Enabled = true; 

						}
						catch (System.Exception E)
						{
							if (dsRecibirCEN!=null)
							{
								this.GrabaArchivoDatos(dsRecibirCEN);
							}
							//MessageBox.Show("No se ha podido enviar la información a Central.\nPor favor contacte con el departamento de Help Desk.\n y comunique el siguiente Error\n\n"+E.Message,"Error al enviar Información");
                            Mensajes.ShowError("No se ha podido enviar la información a Central. Por favor, contacte con el departamento de Help Desk y comunique el siguiente error:\n" + E.Message);
							Ok=false;
						}
                    }

                    #endregion

                    //Paso 6. Procesando el Fichero a recibido de Central.
                    #region paso 6
                    if (Ok)
					{
						try
						{

							this.pcbFinish6.Image = SetImage("Run.ico");
							this.lblPaso6.Font=fPaso;
							this.Refresh();
 
							System.Windows.Forms.Application.DoEvents();

							// Procesar Comandos enviados desde Central
							ProcesaComandos(this.dsRecibirCEN);

							int pCounter = 0;
							if (dsRecibirCEN!=null)
							{
								foreach (DataTable td in dsRecibirCEN.Tables)
								{
									if (td.TableName.ToUpper()!="GETSINCROUPDATES" && td.TableName.ToUpper()!="ERRORES" && td.TableName.ToUpper()!="GETFECHASBAJADA")
									{
										pCounter +=1;
									}
								}
							}
							this.pgbPaso.Maximum = pCounter;
							this.pgbPaso.Step=1;
							this.pgbPaso.Value =0;
							this.pgbPaso.Visible = true;
							this.lblTotal.Visible = true; 
					
				
							this.dsBajada = this.ActualizarDatos(this.dsRecibirCEN);
							System.Windows.Forms.Application.DoEvents();

							this.pgbPaso.Visible = false;
							this.lblTotal.Visible = false; 

							this.Refresh();

							// Espera por el termino del paso 5
							pAsync.AsyncWaitHandle.WaitOne();
  
							this.dsRetorno = Sync.EndEnviarACentral(pAsync); 
							this.pcbFinish6.Image = SetImage("Ok.ico");
							this.Refresh(); 

						}
						catch (Exception E)
						{
							//MessageBox.Show("No se ha podido procesar la información obtenida de Central.\nPor favor contacte con el departamento de Help Desk\ne informe del siguiente error\n\n"+E.Message,"Error al procesar Información");
                            Mensajes.ShowError("No se ha podido procesar la información obtenida de Central. Por favor, contacte con el departamento de Help Desk y comunique el siguiente error:\n" + E.Message);
							//					Ok=false;
						}
                    }

                    #endregion

                    //Paso 7. Grabando fecha de última sincronización (FUS).
                    #region paso 7
                    if (Ok)
					{
						try
						{

							this.pcbFinish7.Image = SetImage("Run.ico");
							this.lblpaso7.Font=fPaso;
							this.Refresh(); 

							int pCounter7 =0;
							if (dsRetorno!=null && dsBajada.Definiciones.Rows.Count>0)
							{
								pCounter7 = dsBajada.Definiciones.Rows.Count;
							}
							this.pgbPaso.Maximum = pCounter7+3;

							// Muestra la pantalla de resultados de la sincronizacion
							if ((dsRetorno!=null && dsRetorno.Filas.Rows.Count>0) ||(dsBajada!=null && dsBajada.Filas.Rows.Count>0))
							{
								if (Clases.Configuracion.bMuestraResultadosSincro==1)
								{
									Mensajes.ShowExclamation("Han ocurrido Errores durante la sincronización.\nA continuacion se mostrará el resumen de los mismos.\nEstos errores no impiden el normal funcionamiento\nde la aplicación.\n\nPara Cerrar el formulario que aparecerá, Presione la tecla ESC\no Cierre el fomulario de la forma habitual");
									Formularios.SincroResult frmResult = new SincroResult();
									frmResult.DataSetSubida = dsRetorno;
									frmResult.DataSetBajada = dsBajada;
									frmResult.ShowDialog(this);
								}
							}

							//Mezclar la tabla de errores dE bajada con la de subida
							if (dsRecibirCEN.Errores!=null && dsRecibirCEN.Errores.Rows.Count>0)
							{
								WSSinCRM.dsCentral.ErroresDataTable rwD = (WSSinCRM.dsCentral.ErroresDataTable)dsRecibirCEN.Errores.Copy();
								this.dsBajada.Merge(rwD);
							}


							// Marca la tabla de configuracion con la fecha de la ultima sincronizacion 
							// con Central
							if (this.sqlConn.State==System.Data.ConnectionState.Closed) this.sqlConn.Open();
							this.sqlCmdFUS.Parameters["@iIdConfig"].Value=6;
							this.sqlCmdFUS.Parameters["@sValor"].Value=DateTime.Now.ToString();
							this.sqlCmdFUS.Transaction=this.sqlTran;
							this.sqlCmdFUS.ExecuteNonQuery();

                            //---- GSG CECL 19/05/2016
                            if (System.Configuration.ConfigurationManager.AppSettings["TipoDelegadoPedidosCentral"].ToString() != Comun.K_CECL)
                            {
                                //---- FI GSG CECL 
                                //Actualiza los campos bEnviadoCEN de las Tablas principales y adelanta
                                //las fechas de los elementos que no han sido insertados
                                ProcesaResultados(dsRetorno);

                                //Ejecuta el comando para compactar la base de Datos
                                if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
                                this.sqlCmdCompacta.Parameters["@sDatabase"].Value = sqlConn.Database.ToString().Trim();
                                this.sqlCmdCompacta.ExecuteNonQuery();
                            }





							// Marca el final de la sincronizacion, enviando
							// los Datasets de resultados
							Sync.FinSincro(GESTCRM.Clases.Configuracion.iIdDelegado,dFIni,dsRetorno,dsBajada,iIdSincro);

							this.pcbFinish7.Image = SetImage("Ok.ico");
							this.Refresh(); 

							Ok = true;
						}
						catch (Exception E)
						{
							Mensajes.ShowError("No se ha podido actualizar la información de sincronización.\n\nEl Error originado es:\n\n"+E.Message);
						}

                    }

                    #endregion

                    if (Ok)
					{
						try
						{
                            //---- GSG CECL 19/05/2016
                            if (System.Configuration.ConfigurationManager.AppSettings["TipoDelegadoPedidosCentral"].ToString() != Comun.K_CECL)
                            {
                                //---- FI GSG CECL 
                                // si hay actualizaciones, las descarga y prepara el Registro para actualizar
                                // la aplicacion cuando se reinicie
                                if (VersionAvailable.CompareTo(Application.ProductVersion.ToString()) > 0)
                                {
                                    Mensajes.ShowInformation("Existe una nueva versión del programa\nque será descargada al cerrar esta ventana\n\nEste proceso puede tardar varios minutos.");
                                    this.pcbFinish8.Image = SetImage("Run.ico");
                                    this.pcbPaso8.Visible = true;
                                    this.lblPaso8.Font = fPaso;
                                    this.lblPaso8.Visible = true;
                                    this.pcbFinish8.Visible = true;
                                    this.Refresh();

                                    updateData = Sync.GetProgramUpdateData(VersionAvailable);
                                    compressedUpdate = Sync.GetProgramUpdateImage(VersionAvailable);
                                    uncompressedUpdate = Unzip(compressedUpdate);

                                    if (!System.IO.Directory.Exists(Application.StartupPath + @"\Actualizaciones\Pendientes"))
                                    {
                                        System.IO.Directory.CreateDirectory(Application.StartupPath + @"\Actualizaciones\Pendientes");

                                    }

                                    if (System.IO.File.Exists(Application.StartupPath + @"\" + updateData.GetValue(2).ToString()) && !System.IO.Directory.Exists(Application.StartupPath + @"\Actualizaciones\" + Application.ProductVersion.ToString()))
                                    {
                                        System.IO.Directory.CreateDirectory(Application.StartupPath + @"\Actualizaciones\" + Application.ProductVersion.ToString());
                                    }
                                    //								  Application.DoEvents(); 
                                    //System.IO.File.Copy(Application.StartupPath + @"\"+updateData.GetValue(2).ToString(),Application.StartupPath + @"\Actualizaciones\"+Application.ProductVersion.ToString() + @"\"+updateData.GetValue(2).ToString()) ;  

                                    if (uncompressedUpdate != null)
                                    {
                                        System.IO.FileStream fs = new FileStream(Application.StartupPath + @"\Actualizaciones\Pendientes\" + updateData.GetValue(2).ToString(), FileMode.Create);
                                        fs.Write(uncompressedUpdate, 0, uncompressedUpdate.Length);
                                        fs.Close();

                                        // Marca LA DESCARGA ok DE LA ACTUALIZACION
                                        Sync.ProgramUpdateOK(GESTCRM.Clases.Configuracion.iIdDelegado, VersionAvailable);

                                        if (updateData.GetValue(3) != null && updateData.GetValue(3).ToString().Trim().Length > 0)
                                        {
                                            SetRegistryKey("GESTCRMBACKUP", "cmd /c copy " + Application.StartupPath + @"\" + updateData.GetValue(2).ToString() + " " + Application.StartupPath + @"\Actualizaciones\" + Application.ProductVersion.ToString() + @"\" + updateData.GetValue(2).ToString());
                                            SetRegistryKey("GESTCRMUPDATE", "cmd /c " + updateData.GetValue(3).ToString());
                                        }
                                        else
                                        {
                                            //SetRegistryKey("GESTCRMUPDATE", Application.StartupPath + @"\Actualizaciones\Pendientes\" + updateData.GetValue(2).ToString());
                                        }
                                    }


                                    this.pcbFinish8.Image = SetImage("Ok.ico");
                                    this.pcbPaso8.Visible = false;
                                    this.lblPaso8.Visible = false;
                                    this.pcbFinish8.Visible = false;
                                    this.Refresh();

                                    Mensajes.ShowInformation("Se ha descargado la actualización del programa.\n\nREINICIE EL ORDENADOR PARA COMPLETAR LA ACTUALIZACION.\n\nSi se produce algún error durante el reinicio póngase en contacto con HelpDesk.");
                                }
                            }
						}
						catch (Exception E)
						{
							Mensajes.ShowError("Ha ocurrido un error en le actualización del programa.\n\nEl Error originado es:\n\n"+E.Message);
						}

					}
					if (this.sqlConn.State == System.Data.ConnectionState.Open) this.sqlConn.Close();

                    //---- GSG (10/09/2014)
                    //this.sqlConn.Dispose();

					Mensajes.ShowExclamation("Ha finalizado el proceso de Sincronización con Central.");

					Sync.Dispose();
					Cursor.Current=Cursors.Default;
					Application.DoEvents();
					this.Close();
				//---- GSG (07/11/2011)
                //}
                //else
                //{
                //    pcbSalir_Click(sender,e);
                //}
                //---- FI GSG
			}
			else
			{
				Mensajes.ShowInformation("EXISTEN ACTUALIZACIONES DEL PROGRAMA QUE NO HAN SIDO INSTALADAS.\n\nREINICIE EL ORDENADOR PARA REALIZAR LA ACTUALIZACION\n\nSi se produce algún error durante el reinicio póngase en contacto con HelpDesk.") ;
				pcbSalir_Click(sender,e);
			}
		}

		private void pcbSalir_Click(object sender, System.EventArgs e)
		{
			this.Close();
			this.Dispose();
		}

		private WSSinCRM.dsRetorno ActualizarDatos(WSSinCRM.dsCentral dsRec)
		{

			WSSinCRM.dsRetorno dsRet = new WSSinCRM.dsRetorno();
			WSSinCRM.dsRetorno dsRetFuncion; 

			try
			{

				this.lblTotal.Text = "Tablas Maestras";
				this.Refresh(); 
				dsRetFuncion = ActualizaTablasMaestras(dsRec);
				dsRet.Merge(dsRetFuncion,true);
				dsRetFuncion.Clear();

				this.lblTotal.Text = "Clientes y Centros";
				this.Refresh(); 
				dsRetFuncion = ActualizaClientes(dsRec);
				dsRet.Merge(dsRetFuncion,true);
				dsRetFuncion.Clear();

				this.lblTotal.Text = "Pedidos";
				this.Refresh(); 
				dsRetFuncion = ActualizaPedidos(dsRec);
				dsRet.Merge(dsRetFuncion,true);
				
				this.lblTotal.Text = "Reportes de Actividad";
				this.Refresh(); 
				dsRetFuncion.Clear();
				dsRetFuncion = ActualizaReportes(dsRec);
				dsRet.Merge(dsRetFuncion,true);
				dsRetFuncion.Clear();

				this.lblTotal.Text = "Notas de Gasto";
				this.Refresh(); 
				dsRetFuncion = ActualizaGastos(dsRec);
				dsRet.Merge(dsRetFuncion,true);
				dsRetFuncion.Clear();


				this.pgbPaso.Value =pgbPaso.Maximum;
				this.Refresh();
			}
			catch (Exception MyExc)
			{
				return dsRet;
			}
			return dsRet;

		}
		private WSSinCRM.dsRetorno ActualizaReportes(WSSinCRM.dsCentral dsRec)
		{
			System.Data.SqlClient.SqlTransaction thisTran=null;
			WSSinCRM.dsRetorno dsRet = new WSSinCRM.dsRetorno();
			string sKey="";
			string sElemento="";

			bool someError = false;
			try
			{

				if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();

				#region AtencionesComerciales
				sElemento="AtencionesComerciales";
				if (dsRec.AtencionesComerciales.Rows.Count >0 )
				{
					AddDefRow(dsRet,"AtencionesComerciales","dFUM","dFUM",false,true);

					foreach(WSSinCRM.dsCentral.AtencionesComercialesRow rwAte in dsRec.AtencionesComerciales.Rows)
					{
						try
						{
							sKey = BuildXMLKey(dsRec.AtencionesComerciales,rwAte);
							sqlCmdUpdAtencionesComerciales.Parameters["@iIdAtencion"].Value = rwAte.iIdAtencion;
							sqlCmdUpdAtencionesComerciales.Parameters["@sIdAtencionTemp"].Value = rwAte.sIdAtencionTemp; 
							sqlCmdUpdAtencionesComerciales.Parameters["@sIdAtencion"].Value = rwAte.sIdAtencion;
							sqlCmdUpdAtencionesComerciales.Parameters["@sDescripcion"].Value = rwAte.IssDescripcionNull()?SqlString.Null:rwAte.sDescripcion;
							sqlCmdUpdAtencionesComerciales.Parameters["@tObservaciones"].Value = rwAte.IstObservacionesNull()?SqlString.Null:rwAte.tObservaciones;
							sqlCmdUpdAtencionesComerciales.Parameters["@sIdTipoAtencion"].Value = rwAte.IssIdTipoAtencionNull()?SqlString.Null:rwAte.sIdTipoAtencion;
							sqlCmdUpdAtencionesComerciales.Parameters["@bBolsaViaje"].Value = rwAte.bBolsaViaje;
							sqlCmdUpdAtencionesComerciales.Parameters["@bLiqNotaGastos"].Value = rwAte.bLiqNotaGastos;
							sqlCmdUpdAtencionesComerciales.Parameters["@sIdCentroCoste"].Value = rwAte.IssIdCentroCosteNull()?SqlString.Null:rwAte.sIdCentroCoste;
							sqlCmdUpdAtencionesComerciales.Parameters["@iIdDelegado"].Value = rwAte.IsiIdDelegadoNull()?SqlInt32.Null:rwAte.iIdDelegado;
							sqlCmdUpdAtencionesComerciales.Parameters["@sIdEstAtencion"].Value = rwAte.IssIdEstAtencionNull()?SqlString.Null:rwAte.sIdEstAtencion;
							sqlCmdUpdAtencionesComerciales.Parameters["@iIdCliente"].Value = rwAte.IsiIdClienteNull()?SqlInt32.Null:rwAte.iIdCliente;
							sqlCmdUpdAtencionesComerciales.Parameters["@fImportePrev"].Value = rwAte.fImportePrev;
							sqlCmdUpdAtencionesComerciales.Parameters["@fImporteReal"].Value = rwAte.IsfImporteRealNull()?SqlDouble.Null:rwAte.fImporteReal;
							sqlCmdUpdAtencionesComerciales.Parameters["@dFechaCreacion"].Value = rwAte.dFechaCreacion; 
							sqlCmdUpdAtencionesComerciales.Parameters["@dFechaPrev"].Value = rwAte.IsdFechaPrevNull()?SqlDateTime.Null:rwAte.dFechaPrev; 
							sqlCmdUpdAtencionesComerciales.Parameters["@dFechaAprob1"].Value = rwAte.IsdFechaAprob1Null()?SqlDateTime.Null:rwAte.dFechaAprob1; 
							sqlCmdUpdAtencionesComerciales.Parameters["@dFechaAprob2"].Value = rwAte.IsdFechaAprob2Null()?SqlDateTime.Null:rwAte.dFechaAprob2; 
							sqlCmdUpdAtencionesComerciales.Parameters["@dFechaAprob3"].Value = rwAte.IsdFechaAprob3Null()?SqlDateTime.Null:rwAte.dFechaAprob3; 
							sqlCmdUpdAtencionesComerciales.Parameters["@dFechaAprob4"].Value = rwAte.IsdFechaAprob4Null()?SqlDateTime.Null:rwAte.dFechaAprob4; 
							sqlCmdUpdAtencionesComerciales.Parameters["@dFechaReal"].Value = rwAte.IsdFechaRealNull()?SqlDateTime.Null:rwAte.dFechaReal; 
							sqlCmdUpdAtencionesComerciales.Parameters["@dFechaLiq"].Value = rwAte.IsdFechaLiqNull()?SqlDateTime.Null:rwAte.dFechaLiq; 
							sqlCmdUpdAtencionesComerciales.Parameters["@dFechaCierre"].Value = rwAte.IsdFechaCierreNull()?SqlDateTime.Null:rwAte.dFechaCierre; 
							sqlCmdUpdAtencionesComerciales.Parameters["@sUsuAprob1"].Value = rwAte.IssUsuAprob1Null()?SqlString.Null:rwAte.sUsuAprob1;
							sqlCmdUpdAtencionesComerciales.Parameters["@sUsuAprob2"].Value = rwAte.IssUsuAprob2Null()?SqlString.Null:rwAte.sUsuAprob2; 
							sqlCmdUpdAtencionesComerciales.Parameters["@sUsuAprob3"].Value = rwAte.IssUsuAprob3Null()?SqlString.Null:rwAte.sUsuAprob3;
							sqlCmdUpdAtencionesComerciales.Parameters["@sUsuAprob4"].Value = rwAte.IssUsuAprob4Null()?SqlString.Null:rwAte.sUsuAprob4; 
							sqlCmdUpdAtencionesComerciales.Parameters["@sUsuLiq"].Value = rwAte.IssUsuLiqNull()?SqlString.Null:rwAte.sUsuLiq; 
							sqlCmdUpdAtencionesComerciales.Parameters["@dFUM"].Value = rwAte.dFUM; 
							sqlCmdUpdAtencionesComerciales.Parameters["@iEstado"].Value = rwAte.iEstado;

							sqlCmdUpdAtencionesComerciales.ExecuteNonQuery();

                            WSSinCRM.dsCentral.AtencionesProductosRow[] oRowsProds = (WSSinCRM.dsCentral.AtencionesProductosRow[])dsRec.AtencionesProductos.Select("iIdAtencion = " + rwAte.iIdAtencion.ToString());

                            //---- GSG (12/04/2012)

                            
							
                            //string XMLProd = "<ROOT>";
                            //int numProds = 0;
							
                            //foreach(WSSinCRM.dsCentral.AtencionesProductosRow RowProd in oRowsProds)
                            //{
                            //    XMLProd += " <PROD sIdProducto = \"" + RowProd.sIdProducto + "\"  fPorcentaje= \"" + RowProd.fPorcentaje.ToString().Replace(",",".") + "\" />";
                            //    numProds++;
                            //}

                            //XMLProd += "</ROOT>";
						
                            //sqlCmdUpdAccionesComercialesProductos.Parameters["@iIdAtencion"].Value = rwAte.iIdAtencion;
                            //sqlCmdUpdAccionesComercialesProductos.Parameters["@xmlProductes"].Value = XMLProd;
                            //sqlCmdUpdAccionesComercialesProductos.ExecuteNonQuery();                            

                            foreach (WSSinCRM.dsCentral.AtencionesProductosRow RowProd in oRowsProds)
                            {
                                try
                                {
                                    sqlCmdUpdAccionesComercialesProductos.Parameters["@iIdAtencion"].Value = rwAte.iIdAtencion;
                                    sqlCmdUpdAccionesComercialesProductos.Parameters["@sIdProducto"].Value = RowProd.sIdProducto.ToString();
                                    sqlCmdUpdAccionesComercialesProductos.Parameters["@fPorcentaje"].Value = RowProd.fPorcentaje.ToString().Replace(",", ".");
                                    sqlCmdUpdAccionesComercialesProductos.Parameters["@bEnviadoPDA"].Value = RowProd.bEnviadoPDA.ToString();
                                    sqlCmdUpdAccionesComercialesProductos.Parameters["@bEnviadoCEN"].Value = RowProd.bEnviadoCEN.ToString();

                                    this.sqlCmdUpdAccionesComercialesProductos.ExecuteNonQuery();

                                    int retValue = (int)sqlCmdUpdAccionesComercialesProductos.Parameters["@RETURN_VALUE"].Value;
                                }
                                catch
                                {
                                    AddErrorRow(dsRet, dsRec.AtencionesProductos.TableName, sKey);
                                    break;
                                }
                            }

                            //---- FI GSG
		
						}
                        catch
                        {
                            AddErrorRow(dsRet, dsRec.AtencionesComerciales.TableName, sKey);
                        }
                        //catch (Exception e)
                        //{
                        //    AddErrorRow(dsRet,dsRec.AtencionesComerciales.TableName,sKey);
                        //    StreamWriter fileErrors = new StreamWriter("C:\\GESTCRMCL\\errors.txt", false, Encoding.Default);
                        //    fileErrors.Write("1.- " + e.Message + " 2.- " + sqlCmdUpdAccionesComercialesProductos.CommandText);
                        //    fileErrors.Close();
                        //}

					}
				}
				#endregion
				UpdatePaso();

				#region RepActividadCab

				if (dsRec.RepActividad_Cab  != null && dsRec.RepActividad_Cab.Rows.Count > 0)
				{

					AddDefRow(dsRet,"RepActividad_Cab","dFUM","dFUM",false,true);


					foreach(WSSinCRM.dsCentral.RepActividad_CabRow  rwRCab in dsRec.RepActividad_Cab.Rows  )
					{
						someError = false;
						try
						{
							thisTran=sqlConn.BeginTransaction();
						
							sqlCmdUpdRepCab.Transaction = thisTran;
							sqlCmdUpdRepActCli.Transaction = thisTran;
							sqlCmdUpdRepActProm.Transaction = thisTran;
							sqlCmdUpdRepActAten.Transaction = thisTran;
							sqlCmdUpdProxObj.Transaction = thisTran;
							sqlCmdUpdRepPed.Transaction = thisTran;
							sqlCmdUpdRepGad.Transaction = thisTran;

							sElemento="RepActividadCab " + rwRCab.iIdReport;

							sKey = BuildXMLKey(dsRec.RepActividad_Cab,rwRCab);

							sqlCmdUpdRepCab.Parameters["@iIdReport"].Value = rwRCab.iIdReport; 
							sqlCmdUpdRepCab.Parameters["@iIdDelegado"].Value = rwRCab.iIdDelegado ; 
							sqlCmdUpdRepCab.Parameters["@sIdReportTemp"].Value = rwRCab.IssIdReportTempNull()?SqlString.Null:rwRCab.sIdReportTemp;
							sqlCmdUpdRepCab.Parameters["@sTipoRActividad"].Value = rwRCab.IssTipoRActividadNull()?SqlString.Null:rwRCab.sTipoRActividad;
							sqlCmdUpdRepCab.Parameters["@sIdTipoCliente"].Value = rwRCab.IssIdTipoClienteNull()?SqlString.Null:rwRCab.sIdTipoCliente; 
							sqlCmdUpdRepCab.Parameters["@iIdCentro"].Value = rwRCab.IsiIdCentroNull()?SqlInt32.Null:rwRCab.iIdCentro;
							sqlCmdUpdRepCab.Parameters["@dFecha"].Value = rwRCab.dFecha; 
							sqlCmdUpdRepCab.Parameters["@iHorario"].Value = rwRCab.IsiHorarioNull()?SqlString.Null:rwRCab.iHorario; 
							sqlCmdUpdRepCab.Parameters["@tObjetivo"].Value = rwRCab.IstObjetivoNull()?SqlString.Null:rwRCab.tObjetivo; 
							sqlCmdUpdRepCab.Parameters["@tProxObjetivo"].Value = rwRCab.IstProxObjetivoNull()?SqlString.Null:rwRCab.tProxObjetivo; 
							sqlCmdUpdRepCab.Parameters["@tObservaciones"].Value = rwRCab.IstObservacionesNull()?SqlString.Null:rwRCab.tObservaciones; 
							sqlCmdUpdRepCab.Parameters["@bPlanificacion"].Value = rwRCab.bPlanificacion; 
							sqlCmdUpdRepCab.Parameters["@dFUM"].Value = rwRCab.dFUM; 
							sqlCmdUpdRepCab.Parameters["@iEstado"].Value = rwRCab.iEstado;
 
                            //RH
                            sqlCmdUpdRepCab.Parameters["@dHoraInicio"].Value = rwRCab.dHoraInicio;
                            sqlCmdUpdRepCab.Parameters["@dHoraFin"].Value = rwRCab.dHoraFin;
                            //---- GSG ()

							this.sqlCmdUpdRepCab.ExecuteNonQuery();

							#region RepActividad_cli
							if (!someError)
							{
								foreach(WSSinCRM.dsCentral.RepActividad_CliRow rwRCli in rwRCab.GetChildRows("RepActividad_CabRepActividad_Cli")) 
								{
									try
									{
										sElemento="RepActividadCli " + rwRCli.iIdReport;
										sqlCmdUpdRepActCli.Parameters["@iIdReport"].Value = rwRCli.iIdReport;
										sqlCmdUpdRepActCli.Parameters["@iIdCliente"].Value = rwRCli.iIdCliente;
										sqlCmdUpdRepActCli.Parameters["@tObservaciones"].Value = rwRCli.IstObservacionesNull()?SqlString.Null:rwRCli.tObservaciones; 
										sqlCmdUpdRepActCli.Parameters["@tObjetivos"].Value = rwRCli.IstObjetivosNull()?SqlString.Null:rwRCli.tObjetivos;
										sqlCmdUpdRepActCli.Parameters["@tProxObj"].Value = rwRCli.IstProxObjNull()?SqlString.Null:rwRCli.tProxObj;
										sqlCmdUpdRepActCli.Parameters["@bSustituto"].Value = rwRCli.bSustituto; 

										this.sqlCmdUpdRepActCli.ExecuteNonQuery();
									}
									catch
									{
										if (thisTran!=null)thisTran.Rollback();
										AddErrorRow(dsRet,dsRec.RepActividad_Cab.TableName,sKey);
										someError = true;
										break;
									}
								}
							}
							#endregion
							#region RepActividadAten
							if (!someError)
							{
								foreach(WSSinCRM.dsCentral.RepActividad_AtenRow rwRAten in rwRCab.GetChildRows("RepActividad_CabRepActividad_Aten"))
								{
									try
									{
										sElemento="RepActividadAten " + rwRAten.iIdReport;

										sqlCmdUpdRepActAten.Parameters["@iIdReport"].Value = rwRAten.iIdReport;
										sqlCmdUpdRepActAten.Parameters["@iIdCliente"].Value = rwRAten.iIdCliente;
										sqlCmdUpdRepActAten.Parameters["@iIdAtencion"].Value = rwRAten.iIdAtencion;
										sqlCmdUpdRepActAten.Parameters["@iNumAtencion"].Value = rwRAten.iNumAtencion; 
										sqlCmdUpdRepActAten.Parameters["@fImporte"].Value = rwRAten.fImporte;

										this.sqlCmdUpdRepActAten.ExecuteNonQuery();
									}
									catch
									{
										if (thisTran!=null)thisTran.Rollback();
										AddErrorRow(dsRet,dsRec.RepActividad_Cab.TableName,sKey);
										someError = true;
										break;
									}
								}
							}
							#endregion
							#region RepActividadCli_ProxObj
							if (!someError)
							{
								foreach(WSSinCRM.dsCentral.RepActividadCli_ProxObjRow  rwRObj in rwRCab.GetChildRows("RepActividad_CabRepActividadCli_ProxObj") )
								{
									try
									{
										sElemento="RepActividadCab " + rwRObj.iIdReport;
 
										sqlCmdUpdProxObj.Parameters["@iIdCentro"].Value = rwRObj.iIdCentro ;
										sqlCmdUpdProxObj.Parameters["@iIdCliente"].Value = rwRObj.iIdCliente ;
										sqlCmdUpdProxObj.Parameters["@iIdReport"].Value = rwRObj.iIdReport;
										sqlCmdUpdProxObj.Parameters["@tProxObj"].Value = rwRObj.tProxObj;
										sqlCmdUpdProxObj.Parameters["@dFecha"].Value = rwRObj.dFecha;

										this.sqlCmdUpdProxObj.ExecuteNonQuery();
									}
									catch
									{
										if (thisTran!=null)thisTran.Rollback();
										AddErrorRow(dsRet,dsRec.RepActividad_Cab.TableName,sKey);
										someError = true;
										break;
									}

								}
							}
							#endregion
							#region Repactividad_Ped
							if (!someError)
							{
								foreach(WSSinCRM.dsCentral.RepActividad_PedRow  rwRPed in rwRCab.GetChildRows("RepActividad_CabRepActividad_Ped"))
								{
									try
									{
										sElemento="RepActividadPed " + rwRPed.iIdReport;

										sqlCmdUpdRepPed.Parameters["@iIdReport"].Value = rwRPed.iIdReport;
										sqlCmdUpdRepPed.Parameters["@sIdPedido"].Value = rwRPed.sIdPedido;  

										this.sqlCmdUpdRepPed.ExecuteNonQuery();
									}
									catch
									{
										if (thisTran!=null)thisTran.Rollback();
										AddErrorRow(dsRet,dsRec.RepActividad_Cab.TableName,sKey);
										someError = true;
										break;
									}

								}
							}
							#endregion					
							#region RepActividad_Gad
							if (!someError)
							{
								foreach(WSSinCRM.dsCentral.RepActividad_GadRow rwRGad in rwRCab.GetChildRows("RepActividad_CabRepActividad_Gad"))
								{
									try
									{
										sElemento="RepActividadGad " + rwRGad.iIdReport;
										sqlCmdUpdRepGad.Parameters["@iIdReport"].Value = rwRGad.iIdReport;
										sqlCmdUpdRepGad.Parameters["@iIdCliente"].Value = rwRGad.iIdCliente;
										sqlCmdUpdRepGad.Parameters["@iIdAccion"].Value = rwRGad.iIdAccion;
										sqlCmdUpdRepGad.Parameters["@iCantidad"].Value = rwRGad.iCantidad;

										this.sqlCmdUpdRepGad.ExecuteNonQuery();
									}
									catch
									{
										if (thisTran!=null)thisTran.Rollback();
										AddErrorRow(dsRet,dsRec.RepActividad_Cab.TableName,sKey);
										someError = true;
										break;
									}

								}
							}
							#endregion
							#region RepActividad_Prom
							if (!someError)
							{
								foreach(WSSinCRM.dsCentral.RepActividad_PromRow rwRProd in rwRCab.GetChildRows("RepActividad_CabRepActividad_Prom"))
								{

									try
									{
										sElemento="RepActividadProd " + rwRProd.iIdReport;
										sqlCmdUpdRepActProm.Parameters["@iIdReport"].Value = rwRProd.iIdReport; 
										sqlCmdUpdRepActProm.Parameters["@iIdCliente"].Value = rwRProd.iIdCliente;
										sqlCmdUpdRepActProm.Parameters["@sIdProducto"].Value = rwRProd.sIdProducto;
										sqlCmdUpdRepActProm.Parameters["@iCantidad"].Value = rwRProd.iCantidad;
										sqlCmdUpdRepActProm.Parameters["@iOrden"].Value = rwRProd.Orden;
								
										this.sqlCmdUpdRepActProm.ExecuteNonQuery();
									}
									catch
									{
										if (thisTran!=null)thisTran.Rollback();
										AddErrorRow(dsRet,dsRec.RepActividad_Cab.TableName,sKey);
										someError = true;
										break;
									}

								}
							}
							#endregion

							if (!someError) thisTran.Commit();
						}
						catch (Exception E)
						{
							if (thisTran!=null)thisTran.Rollback();
							AddErrorRow(dsRet,dsRec.RepActividad_Cab.TableName,sKey);
							someError = true;
						}
					}
				}
				#endregion
				UpdatePaso();
				
				UpdatePaso();
				
				UpdatePaso();
					
				UpdatePaso();
					
				UpdatePaso();
					
				UpdatePaso();
					
				UpdatePaso();
					
			}
			catch (Exception MyExc)
			{
				if (thisTran!=null)thisTran.Rollback();  
				foreach (WSSinCRM.dsCentral.AtencionesComercialesRow rwCab in dsRec.AtencionesComerciales.Rows)
				{
					sKey = BuildXMLKey(dsRec.AtencionesComerciales,rwCab);
					AddErrorRow(dsRet,"AtencionesComerciales",sKey);
				}
				foreach (WSSinCRM.dsCentral.RepActividad_CabRow rwCab in dsRec.RepActividad_Cab.Rows)
				{
					sKey = BuildXMLKey(dsRec.RepActividad_Cab,rwCab);
					AddErrorRow(dsRet,"RepActividad_Cab",sKey);
				}
				Mensajes.ShowError("Contacte con HelpDesk e indique el siguiente error de Sincronización:\n\n"+MyExc.Message+"\n\nEl error se ha producido en Actualizacion de Reportes, elemento " +sElemento.ToString());
			}
			finally
			{
				if (this.sqlConn.State == System.Data.ConnectionState.Open ) this.sqlConn.Close();
			}

			return dsRet;
		}

		private WSSinCRM.dsRetorno ActualizaGastos(WSSinCRM.dsCentral dsRec)
		{
			System.Data.SqlClient.SqlTransaction thisTran=null;
			string sElemento="";
			string sKey = "";

			bool someError = false;

			WSSinCRM.dsRetorno dsRet = new WSSinCRM.dsRetorno();
			try 
			{
				if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
				#region NotasGastos
				if (dsRec.NotasGastos  != null && dsRec.NotasGastos.Rows.Count >0   )
				{

					foreach (WSSinCRM.dsCentral.NotasGastosRow rwGastos in dsRec.NotasGastos.Rows )

					{

						someError = false;

						try
						{
							thisTran=sqlConn.BeginTransaction();
							sqlCmdSetNotaGasto.Transaction = thisTran;
							sqlCmdSetNotaGastoLin.Transaction = thisTran;
							sqlCmdSetAtenNG.Transaction = thisTran;

							//NotasGastos
							sElemento="NotasGastos "+rwGastos.iIdNota;
							sKey = BuildXMLKey(dsRec.NotasGastos,rwGastos);
							this.sqlCmdSetNotaGasto.Parameters["@iIdNota"].Value  = rwGastos.iIdNota; 
							this.sqlCmdSetNotaGasto.Parameters["@sIdNotaTemp"].Value  = rwGastos.sIdNotaTemp;
							this.sqlCmdSetNotaGasto.Parameters["@iIdDelegado"].Value= rwGastos.iIdDelegado ;
							this.sqlCmdSetNotaGasto.Parameters["@dFecha"].Value= rwGastos.dFecha ;
							this.sqlCmdSetNotaGasto.Parameters["@bVisa"].Value= rwGastos.bVisa; 
							this.sqlCmdSetNotaGasto.Parameters["@dFechaAprob"].Value= rwGastos.IsdFechaAprobNull()?SqlDateTime.Null:rwGastos.dFechaAprob ;
							this.sqlCmdSetNotaGasto.Parameters["@sUsuarioAprob"].Value= rwGastos.IssUsuarioAprobNull()?SqlString.Null:rwGastos.sUsuarioAprob ;
							this.sqlCmdSetNotaGasto.Parameters["@dFechaLiq"].Value=  rwGastos.IsdFechaLiqNull()?SqlDateTime.Null:rwGastos.dFechaLiq ;
							this.sqlCmdSetNotaGasto.Parameters["@tObservaciones"].Value= rwGastos.IstObservacionesNull()?SqlString.Null:rwGastos.tObservaciones ;
							this.sqlCmdSetNotaGasto.Parameters["@dFUM"].Value= rwGastos.dFUM ;
							this.sqlCmdSetNotaGasto.Parameters["@iEstado"].Value= rwGastos.iEstado;

							this.sqlCmdSetNotaGasto.ExecuteNonQuery();

							#region NotasGastos_Lin
							//NotasGastos_Lin
							if (!someError)
							{
								foreach (WSSinCRM.dsCentral.NotasGastos_LinRow  rwLin in rwGastos.GetChildRows("NotasGastosNotasGastos_Lin"))
								{

									try
									{
										sElemento="NotasGastosLin "+rwLin.iIdNota;
										sqlCmdSetNotaGastoLin.Parameters["@iIdNota"].Value= rwGastos.iIdNota;
										sqlCmdSetNotaGastoLin.Parameters["@iIdGasto"].Value=rwLin.iIdGasto; 
										sqlCmdSetNotaGastoLin.Parameters["@fCantidad"].Value=rwLin.fCantidad; 
										sqlCmdSetNotaGastoLin.Parameters["@fPrecio"].Value=rwLin.fPrecio; 
										sqlCmdSetNotaGastoLin.Parameters["@tDescripcion"].Value= rwLin.IstDescripcionNull()?SqlString.Null:rwLin.tDescripcion;
										sqlCmdSetNotaGastoLin.Parameters["@sIdCentroCoste"].Value= rwLin.IssIdCentroCosteNull()?SqlString.Null:rwLin.sIdCentroCoste;

										this.sqlCmdSetNotaGastoLin.ExecuteNonQuery();
									}
									catch
									{
										if (thisTran!=null)thisTran.Rollback();
										AddErrorRow(dsRet,dsRec.NotasGastos.TableName,sKey);
										someError = true;
										break;
									}

								}
							}
							#endregion
							#region AtencionesNotasGastos
							if (!someError)
							{
								//AtencionesNotasGastos
								foreach (WSSinCRM.dsCentral.AtencionesNotasGastosRow  rwAte in rwGastos.GetChildRows("NotasGastosAtencionesNotasGastos") )
								{
									try
									{
										sKey = BuildXMLKey(dsRec.AtencionesNotasGastos,rwAte);

										sElemento = "Report: "+rwAte.iIdReport.ToString()+"Nota: "+rwAte.iIdNota.ToString()+"Atencion: "+rwAte.iIdAtencion.ToString()+"Cliente: "+rwAte.iIdCliente.ToString();
										sqlCmdSetAtenNG.Parameters["@iIdNota"].Value= rwAte.iIdNota;
										sqlCmdSetAtenNG.Parameters["@iIdReport"].Value=rwAte.iIdReport; 
										sqlCmdSetAtenNG.Parameters["@iIdCliente"].Value=rwAte.iIdCliente; 
										sqlCmdSetAtenNG.Parameters["@iIdAtencion"].Value=rwAte.iIdAtencion; 
										sqlCmdSetAtenNG.Parameters["@iNumAtencion"].Value=rwAte.iNumAtencion; 

										sqlCmdSetAtenNG.ExecuteNonQuery();
									}
									catch (Exception E)
									{
										if (thisTran!=null)thisTran.Rollback();
										AddErrorRow(dsRet,dsRec.NotasGastos.TableName,sKey);
										AddErrorRow(dsRet,dsRec.AtencionesNotasGastos.TableName,sKey);
										someError = true;
										break;
									}

								}
							}
							#endregion
							if (!someError)	thisTran.Commit();

						}
						catch
						{
							if (thisTran!=null)thisTran.Rollback();
							AddErrorRow(dsRet,dsRec.NotasGastos.TableName,sKey);
							someError = true;
							break;

						}
					}

				}
				#endregion
				UpdatePaso();
				
				UpdatePaso();
				
				UpdatePaso();
					
			}
			catch (Exception myExc)
			{
				if (this.sqlConn.State == System.Data.ConnectionState.Open ) this.sqlConn.Close();
				foreach (WSSinCRM.dsCentral.NotasGastosRow rwCab in dsRec.NotasGastos.Rows)
				{
					sKey = BuildXMLKey(dsRec.NotasGastos,rwCab);
					AddErrorRow(dsRet,"NotasGastos",sKey);
				}
				Mensajes.ShowError("Contacte con HelpDesk e indique el siguiente error de Sincronización:\n\n"+myExc.Message+"\n\nEl error se ha producido en Actualizacion de Nots de Gasto, elemento " +sElemento.ToString());
			}
			finally
			{
				if (this.sqlConn.State == System.Data.ConnectionState.Open) this.sqlConn.Close();
			}
			return dsRet;
		}


		private WSSinCRM.dsRetorno ActualizaTablasMaestras(WSSinCRM.dsCentral dsRec )
		{
			string sElemento="";

			WSSinCRM.dsRetorno dsRet = new WSSinCRM.dsRetorno();

			string sKey="";
			try
			{
				if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();


				#region Tipos
				sElemento="Tipos";
				if (dsRec.Tipos != null && dsRec.Tipos.Rows.Count >0  )
				{
					//Tipos
					AddDefRow(dsRet,"Tipos","dFUM","dFUM",false,true);
					foreach(WSSinCRM.dsCentral.TiposRow rwTipo in dsRec.Tipos.Rows)
					{
						try
						{
							sKey = BuildXMLKey(dsRec.Tipos,rwTipo);

							sqlCmdUpdTipos.Parameters["@iIdTipo"].Value = rwTipo.iIdTipo;
							sqlCmdUpdTipos.Parameters["@sTipo"].Value = rwTipo.sTipo; 
							sqlCmdUpdTipos.Parameters["@dFUM"].Value = rwTipo.dFUM; 
							sqlCmdUpdTipos.Parameters["@iEstado"].Value= rwTipo.iEstado;
 
							sqlCmdUpdTipos.ExecuteNonQuery();
						}
						catch
						{
							AddErrorRow(dsRet,"Tipos",sKey);
						}
					}
				}
				#endregion
				UpdatePaso();
					
				#region LineasTipos
				sElemento="LineasTipos";
				if (dsRec.LineasTipos != null &&  dsRec.LineasTipos.Rows.Count >0  )
				{
					//LineasTipos
					AddDefRow(dsRet,"LineasTipos","dFUM","dFUM",false,true);
					foreach (WSSinCRM.dsCentral.LineasTiposRow rwLtipo in dsRec.LineasTipos.Rows)
					{
						try
						{
							sKey = BuildXMLKey(dsRec.LineasTipos,rwLtipo);

							sqlCmdUpdLineasTipos.Parameters["@iIdTipo"].Value = rwLtipo.iIdTipo;
							sqlCmdUpdLineasTipos.Parameters["@iOrden"].Value = rwLtipo.iOrden;
							sqlCmdUpdLineasTipos.Parameters["@sValor"].Value = rwLtipo.sValor;
							sqlCmdUpdLineasTipos.Parameters["@sLiteral"].Value = rwLtipo.sLiteral;
							sqlCmdUpdLineasTipos.Parameters["@dFUM"].Value = rwLtipo.dFUM;
							sqlCmdUpdLineasTipos.Parameters["@iEstado"].Value = rwLtipo.iEstado;
 
							sqlCmdUpdLineasTipos.ExecuteNonQuery();
						}
						catch
						{
							AddErrorRow(dsRet,"LineasTipos",sKey);
						}
					}
				}
				#endregion
				UpdatePaso();
					
				#region RedesComerciales
				sElemento="RedesComerciales";
				if (dsRec.RedesComerciales != null &&  dsRec.RedesComerciales.Rows.Count >0  )
				{
					AddDefRow(dsRet,"RedesComerciales","dFUM","dFUM",false,true);
					//LineasTipos
					foreach (WSSinCRM.dsCentral.RedesComercialesRow rwLtipo in dsRec.RedesComerciales.Rows)
					{
						try
						{
							sKey = BuildXMLKey(dsRec.RedesComerciales,rwLtipo);

							sqlCmdUpdRedes.Parameters["@sIdRed"].Value = rwLtipo.sIdRed;
							sqlCmdUpdRedes.Parameters["@sNombre"].Value = rwLtipo.sNombre;
							sqlCmdUpdRedes.Parameters["@dFUM"].Value = rwLtipo.dFUM;
							sqlCmdUpdRedes.Parameters["@iEstado"].Value = rwLtipo.iEstado;

							sqlCmdUpdRedes.ExecuteNonQuery();
						}
						catch
						{
							AddErrorRow(dsRet,"RedesComerciales",sKey);
						}
					}
				}
				#endregion
					UpdatePaso();
					
				#region Divisiones
				sElemento="Divisiones";
				if (dsRec.Divisiones != null &&  dsRec.Divisiones.Rows.Count >0)
				{
					AddDefRow(dsRet,"Divisiones","dFUM","dFUM",false,true);
					foreach (WSSinCRM.dsCentral.DivisionesRow  rwProd in dsRec.Divisiones.Rows)
					{
						try
						{

							sKey = BuildXMLKey(dsRec.Divisiones,rwProd);

							sqlCmdUpdDivisiones.Parameters["@sIdDivision"].Value = rwProd.sIdDivision;
							sqlCmdUpdDivisiones.Parameters["@sNombre"].Value = rwProd.sNombre;
							sqlCmdUpdDivisiones.Parameters["@dFUM"].Value = rwProd.dFUM;
							sqlCmdUpdDivisiones.Parameters["@iEstado"].Value = rwProd.iEstado;

							sqlCmdUpdDivisiones.ExecuteNonQuery();
						}
						catch
						{
							AddErrorRow(dsRet,"Divisiones",sKey);
						}
					}
				}
				#endregion
				UpdatePaso();
					
				#region Productos
				sElemento="Productos";
				if (dsRec.Productos != null &&  dsRec.Productos.Rows.Count >0)
				{
					AddDefRow(dsRet,"Productos","dFUM","dFUM",false,true);
					foreach (WSSinCRM.dsCentral.ProductosRow  rwProd in dsRec.Productos.Rows)
					{
						try
						{

							sKey = BuildXMLKey(dsRec.Productos,rwProd);

							sqlCmdUpdProductos.Parameters["@sIdProducto"].Value = rwProd.sIdProducto;
							sqlCmdUpdProductos.Parameters["@sDescripcion"].Value = rwProd.sDescripcion;
							sqlCmdUpdProductos.Parameters["@dFUM"].Value = rwProd.dFUM;
							sqlCmdUpdProductos.Parameters["@iEstado"].Value = rwProd.iEstado;

							sqlCmdUpdProductos.ExecuteNonQuery();
						}
						catch
						{
							AddErrorRow(dsRet,"Productos",sKey);
						}
					}
				}
				#endregion
				UpdatePaso();
					
				#region Materiales
				sElemento="Materiales";
				if (dsRec.Materiales  != null &&  dsRec.Materiales.Rows.Count  >0 )
				{
					//Materiales
					AddDefRow(dsRet,"Materiales","dFUM","dFUM",false,true);
					foreach (WSSinCRM.dsCentral.MaterialesRow  rwMat in dsRec.Materiales.Rows)
					{
						try
						{

							sKey = BuildXMLKey(dsRec.Materiales,rwMat);

							sqlCmdUpdMateriales.Parameters["@sIdMaterial"].Value =rwMat.sIdMaterial ; 
							sqlCmdUpdMateriales.Parameters["@sOrgVentas"].Value = rwMat.sOrgVentas  ;
							sqlCmdUpdMateriales.Parameters["@sCanalDistrib"].Value = rwMat.sCanalDistrib ;
							sqlCmdUpdMateriales.Parameters["@sMaterial"].Value = rwMat.IssMaterialNull()?SqlString.Null:rwMat.sMaterial; 
							sqlCmdUpdMateriales.Parameters["@sCodNacional"].Value = rwMat.IssCodNacionalNull()?SqlString.Null:rwMat.sCodNacional; 
							sqlCmdUpdMateriales.Parameters["@fPrecio"].Value = rwMat.IsfPrecioNull()?SqlDouble.Null:rwMat.fPrecio; 
							sqlCmdUpdMateriales.Parameters["@sMoneda"].Value = rwMat.IssMonedaNull()?SqlString.Null:rwMat.sMoneda;
							sqlCmdUpdMateriales.Parameters["@iCantidadBase"].Value = rwMat.iCantidadBase; 
							sqlCmdUpdMateriales.Parameters["@sUnidadBase"].Value = rwMat.IssUnidadBaseNull()?SqlString.Null:rwMat.sUnidadBase;
							sqlCmdUpdMateriales.Parameters["@dFechaIni"].Value = rwMat.IsdFechaIniNull()?SqlDateTime.Null:rwMat.dFechaIni;
							sqlCmdUpdMateriales.Parameters["@dFechaFin"].Value = rwMat.IsdFechaFinNull()?SqlDateTime.Null:rwMat.dFechaFin;
							sqlCmdUpdMateriales.Parameters["@dFUM"].Value = rwMat.dFUM; 
							sqlCmdUpdMateriales.Parameters["@iEstado"].Value = rwMat.iEstado;
							sqlCmdUpdMateriales.Parameters["@sIdProducto"].Value = rwMat.sIdProducto;
							sqlCmdUpdMateriales.Parameters["@sIdDivision"].Value = rwMat.sIdDivision;
							sqlCmdUpdMateriales.Parameters["@sIdRed"].Value = rwMat.sIdRed;
							sqlCmdUpdMateriales.Parameters["@fDescuentoMaximo"].Value = rwMat.fDescuentoMaximo;
                            //---- GSG (11/10/2011)
                            sqlCmdUpdMateriales.Parameters["@sTipoMat"].Value = rwMat.sTipoMat;
                            //---- GSG (20/10/2011) (08/11/2011 comparació amb null)
                            sqlCmdUpdMateriales.Parameters["@iStock"].Value = rwMat.iStock;
                            if (!rwMat.IsdEntregaNull())
                                sqlCmdUpdMateriales.Parameters["@dEntrega"].Value = rwMat.dEntrega;
                            else
                                sqlCmdUpdMateriales.Parameters["@dEntrega"].Value = null;
                            //---- GSG (20/10/2011)
                            sqlCmdUpdMateriales.Parameters["@iPendientes"].Value = rwMat.iPendientes;
                            //---- GSG (20/07/2012)
                            if (rwMat.IsiUnidadesEnfajadoNull())
                                sqlCmdUpdMateriales.Parameters["@iUnidadesEnfajado"].Value = 0;
                            else
                                sqlCmdUpdMateriales.Parameters["@iUnidadesEnfajado"].Value = rwMat.iUnidadesEnfajado;
                            //---- GSG (04/09/2012)
                            if (rwMat.IsiCajaCompletaNull())
                                sqlCmdUpdMateriales.Parameters["@iCajaCompleta"].Value = 0;
                            else
                                sqlCmdUpdMateriales.Parameters["@iCajaCompleta"].Value = rwMat.iCajaCompleta; 
                            //---- GSG (22/01/2014)
                            sqlCmdUpdMateriales.Parameters["@sTipoMatInformes"].Value = rwMat.sTipoMatInformes;
                            sqlCmdUpdMateriales.Parameters["@bActivoInformes"].Value = rwMat.bActivoInformes; 
                            //---- GSG (21/05/2014)
                            if (!rwMat.IsbConValeNull())
                                sqlCmdUpdMateriales.Parameters["@bConVale"].Value = rwMat.bConVale;
                            else
                                sqlCmdUpdMateriales.Parameters["@bConVale"].Value = false;
                            //---- GSG (04/08/2014)
                            if (!rwMat.IsbFinanciadoNull()) 
                                sqlCmdUpdMateriales.Parameters["@bFinanciado"].Value = rwMat.bFinanciado;
                            else
                                sqlCmdUpdMateriales.Parameters["@bFinanciado"].Value = false;
                            if (!rwMat.IsbMedicamentoNull())
                                sqlCmdUpdMateriales.Parameters["@bMedicamento"].Value = rwMat.bMedicamento;
                            else
                                sqlCmdUpdMateriales.Parameters["@bMedicamento"].Value = false;
                            //--- GSG (08/09/2014)
                            if (rwMat.IsfDescuentoMaximoTRANull())
                                sqlCmdUpdMateriales.Parameters["@fDescuentoMaximoTRA"].Value = 0;
                            else
                                sqlCmdUpdMateriales.Parameters["@fDescuentoMaximoTRA"].Value = rwMat.fDescuentoMaximoTRA;
                            //---- GSG (25/11/2014)
                            if (rwMat.IsfPVPNull())
                                sqlCmdUpdMateriales.Parameters["@fPVP"].Value = 0;
                            else
                                sqlCmdUpdMateriales.Parameters["@fPVP"].Value = rwMat.fPVP;
                            if (rwMat.IsfPVPIVANull())
                                sqlCmdUpdMateriales.Parameters["@fPVPIVA"].Value = 0;
                            else
                                sqlCmdUpdMateriales.Parameters["@fPVPIVA"].Value = rwMat.fPVPIVA;
                            if (rwMat.IsiStockCanariasNull())
                                sqlCmdUpdMateriales.Parameters["@iStockCanarias"].Value = 0;
                            else
                                sqlCmdUpdMateriales.Parameters["@iStockCanarias"].Value = rwMat.iStockCanarias;
                            //---- GSG (03/02/2015)
                            if (rwMat.IsiPendientesCanariasNull())
                                sqlCmdUpdMateriales.Parameters["@iPendientesCanarias"].Value = 0;
                            else
                                sqlCmdUpdMateriales.Parameters["@iPendientesCanarias"].Value = rwMat.iPendientesCanarias;
                            //---- GSG (08/04/2016)
                            if (rwMat.IsiBlockTipoPedidoNull())
                                sqlCmdUpdMateriales.Parameters["@iBlockTipoPedido"].Value = 0;
                            else
                                sqlCmdUpdMateriales.Parameters["@iBlockTipoPedido"].Value = rwMat.iBlockTipoPedido;
                            if (rwMat.IsiBlockCanariasNull())
                                sqlCmdUpdMateriales.Parameters["@iBlockCanarias"].Value = 0;
                            else
                                sqlCmdUpdMateriales.Parameters["@iBlockCanarias"].Value = rwMat.iBlockCanarias;
                            //---- GSG (13/10/2016)
                            if (rwMat.IsiBlockTipoPedidoDIRNull())
                                sqlCmdUpdMateriales.Parameters["@iBlockTipoPedidoDIR"].Value = 0;
                            else
                                sqlCmdUpdMateriales.Parameters["@iBlockTipoPedidoDIR"].Value = rwMat.iBlockTipoPedidoDIR;
                            if (rwMat.IsiBlockTipoPedidoTRANull())
                                sqlCmdUpdMateriales.Parameters["@iBlockTipoPedidoTRA"].Value = 0;
                            else
                                sqlCmdUpdMateriales.Parameters["@iBlockTipoPedidoTRA"].Value = rwMat.iBlockTipoPedidoTRA;
                            if (rwMat.IsiBlockTipoPedidoKENull())
                                sqlCmdUpdMateriales.Parameters["@iBlockTipoPedidoKE"].Value = 0;
                            else
                                sqlCmdUpdMateriales.Parameters["@iBlockTipoPedidoKE"].Value = rwMat.iBlockTipoPedidoKE;
                            if (rwMat.IsiBlockTipoPedidoKBNull())
                                sqlCmdUpdMateriales.Parameters["@iBlockTipoPedidoKB"].Value = 0;
                            else
                                sqlCmdUpdMateriales.Parameters["@iBlockTipoPedidoKB"].Value = rwMat.iBlockTipoPedidoKB;
                            if (rwMat.IsiBlockTipoPedidoZCRNull())
                                sqlCmdUpdMateriales.Parameters["@iBlockTipoPedidoZCR"].Value = 0;
                            else
                                sqlCmdUpdMateriales.Parameters["@iBlockTipoPedidoZCR"].Value = rwMat.iBlockTipoPedidoZCR;
                            //---- GSG (13/03/2019)
                            if (rwMat.IssTipoProdInformesNull())
                                sqlCmdUpdMateriales.Parameters["@sTipoProdInformes"].Value = "";
                            else
                                sqlCmdUpdMateriales.Parameters["@sTipoProdInformes"].Value = rwMat.sTipoProdInformes;

                            sqlCmdUpdMateriales.ExecuteNonQuery();
						}
						catch
						{
							AddErrorRow(dsRet,"Materiales",sKey);
						}

					}
				}
				#endregion
				UpdatePaso();
					
				#region MaterialCamp
				sElemento="MaterialCamp";
				if (dsRec.MaterialCamp != null &&  dsRec.MaterialCamp.Rows.Count > 0)
				{
					//MaterialParrilla
                    AddDefRow(dsRet, "MaterialCamp", "dFum", "dFum", false, true);
					foreach(WSSinCRM.dsCentral.MaterialCampRow rwMaterialCamp in dsRec.MaterialCamp.Rows)
					{
						try
						{
							sKey = BuildXMLKey(dsRec.MaterialCamp,rwMaterialCamp);

							sqlCmdUpdMaterialCamp.Parameters["@iIdMaterial"].Value = rwMaterialCamp.iIdMaterial;
							sqlCmdUpdMaterialCamp.Parameters["@iIdCamp"].Value = rwMaterialCamp.iIdCamp; 
							sqlCmdUpdMaterialCamp.Parameters["@DescuentoMaximo"].Value = rwMaterialCamp.DescuentoMaximo; 
							sqlCmdUpdMaterialCamp.Parameters["@dFUM"].Value = rwMaterialCamp.dFum; 
							sqlCmdUpdMaterialCamp.Parameters["@iEstado"].Value = rwMaterialCamp.iEstado; 

                            //RH
                            sqlCmdUpdMaterialCamp.Parameters["@UnidMinimas"].Value = rwMaterialCamp.UnidMinimas;
                            sqlCmdUpdMaterialCamp.Parameters["@bObligatorio"].Value = rwMaterialCamp.bObligatorio;
                            sqlCmdUpdMaterialCamp.Parameters["@idPaquete"].Value = rwMaterialCamp.idPaquete; 
                            //---- GSG (19/01/2015)
                            sqlCmdUpdMaterialCamp.Parameters["@sSumaUnidades"].Value = rwMaterialCamp.sSumaUnidades; 
                            //---- GSG (04/09/2015)
                            sqlCmdUpdMaterialCamp.Parameters["@iDeCampRegalo"].Value = rwMaterialCamp.iDeCampRegalo;
                            //---- GSG (29/03/2022)
                            sqlCmdUpdMaterialCamp.Parameters["@sSumaPara"].Value = rwMaterialCamp.sSumaPara;

                            sqlCmdUpdMaterialCamp.ExecuteNonQuery();
						}
						catch
						{
							AddErrorRow(dsRet,"MaterialCamp",sKey);
						}
					}
				}
				#endregion
				UpdatePaso();

                #region Campanyas
                //RH
                sElemento = "Campanyas";
                if (dsRec.Campanyas != null && dsRec.Campanyas.Rows.Count > 0)
                {
                    AddDefRow(dsRet, "Campanyas", "dFUM", "dFUM", false, true);
                    foreach (WSSinCRM.dsCentral.CampanyasRow rwCampanyas in dsRec.Campanyas.Rows)
                    {
                        try
                        {
                            sKey = BuildXMLKey(dsRec.Campanyas, rwCampanyas);

                            sqlCmdUpdCampanyas.Parameters["@idCampanya"].Value = rwCampanyas.idCampanya;
                            sqlCmdUpdCampanyas.Parameters["@NombreCampanya"].Value = rwCampanyas.NombreCampanya;
                            sqlCmdUpdCampanyas.Parameters["@bSeleccionable"].Value = rwCampanyas.bSeleccionable;
                            sqlCmdUpdCampanyas.Parameters["@iNumMinOblis"].Value = rwCampanyas.iNumMinOblis;
                            sqlCmdUpdCampanyas.Parameters["@fImporteMinObli"].Value = rwCampanyas.fImporteMinObli;
                            sqlCmdUpdCampanyas.Parameters["@fDescImpNeto"].Value = rwCampanyas.fDescImpNeto;
                            sqlCmdUpdCampanyas.Parameters["@bArrastre"].Value = rwCampanyas.bArrastre;
                            sqlCmdUpdCampanyas.Parameters["@dFUM"].Value = rwCampanyas.dFUM;
                            sqlCmdUpdCampanyas.Parameters["@iEstado"].Value = rwCampanyas.iEstado;
                            //---- GSG (07/02/2011)
                            sqlCmdUpdCampanyas.Parameters["@fImporteMinObliBruto"].Value = rwCampanyas.fImporteMinObliBruto;
                            sqlCmdUpdCampanyas.Parameters["@iNumMinOblisTotal"].Value = rwCampanyas.iNumMinOblisTotal;
                            //---- GSG (08/04/2011)
                            sqlCmdUpdCampanyas.Parameters["@bInfDesc"].Value = rwCampanyas.bInfDesc;
                            //---- GSG (05/01/2012)
                            sqlCmdUpdCampanyas.Parameters["@bDescExtra"].Value = rwCampanyas.bDescExtra;
                            //---- GSG (12/04/2012)
                            sqlCmdUpdCampanyas.Parameters["@bAfectaRentabilidad"].Value = rwCampanyas.bAfectaRentabilidad;
                            //---- GSG (23/04/2013)
                            sqlCmdUpdCampanyas.Parameters["@fDescMinGar"].Value = rwCampanyas.fDescMinGar;
                            //---- GSG (25/09/2013)
                            sqlCmdUpdCampanyas.Parameters["@sObservaciones"].Value = rwCampanyas.sObservaciones;
                            //---- GSG (30/09/2013)
                            sqlCmdUpdCampanyas.Parameters["@fRentMin"].Value = rwCampanyas.fRentMin;
                            //---- GSG (06/02/2014)
                            sqlCmdUpdCampanyas.Parameters["@dVigenciaIni"].Value = rwCampanyas.dVigenciaIni;
                            sqlCmdUpdCampanyas.Parameters["@dVigenciaFin"].Value = rwCampanyas.dVigenciaFin;
                            //---- GSG (17/11/2014)
                            sqlCmdUpdCampanyas.Parameters["@sSumaUnidades"].Value = rwCampanyas.sSumaUnidades;
                            //---- GSG (22/06/2015)
                            sqlCmdUpdCampanyas.Parameters["@bSoloNoVendidos"].Value = rwCampanyas.bSoloNoVendidos;
                            //---- GSG (07/04/2016)
                            sqlCmdUpdCampanyas.Parameters["@bCompetencia"].Value = rwCampanyas.bCompetencia;
                            //---- GSG (10/10/2016)
                            sqlCmdUpdCampanyas.Parameters["@bDuplicados"].Value = rwCampanyas.bDuplicados;

                            sqlCmdUpdCampanyas.ExecuteNonQuery();
                        }
                        catch (Exception e)
                        {
                            AddErrorRow(dsRet, "Campanyas", sKey);
                        }
                    }
                }
                #endregion
                UpdatePaso();

                #region Arrastres
                //RH
                sElemento = "Arrastres";
                if (dsRec.Arrastres != null && dsRec.Arrastres.Rows.Count > 0)
                {
                    AddDefRow(dsRet, "Arrastres", "dFUM", "dFUM", false, true);
                    foreach (WSSinCRM.dsCentral.ArrastresRow rwArrastres in dsRec.Arrastres.Rows)
                    {
                        try
                        {
                            sKey = BuildXMLKey(dsRec.Arrastres, rwArrastres);

                            sqlCmdUpdArrastres.Parameters["@idArrastre"].Value = rwArrastres.idArrastre;
                            sqlCmdUpdArrastres.Parameters["@idCampanyaA"].Value = rwArrastres.idCampanyaA;
                            sqlCmdUpdArrastres.Parameters["@idPaqueteA"].Value = rwArrastres.idPaqueteA;
                            sqlCmdUpdArrastres.Parameters["@idCampanyaB"].Value = rwArrastres.idCampanyaB;
                            sqlCmdUpdArrastres.Parameters["@idPaqueteB"].Value = rwArrastres.idPaqueteB;
                            sqlCmdUpdArrastres.Parameters["@dFUM"].Value = rwArrastres.dFUM;
                            sqlCmdUpdArrastres.Parameters["@iEstado"].Value = rwArrastres.iEstado;

                            sqlCmdUpdArrastres.ExecuteNonQuery();
                        }
                        catch
                        {
                            AddErrorRow(dsRet, "Arrastres", sKey);
                        }
                    }
                }
                #endregion
                UpdatePaso();

                #region Paquetes
                //RH
                sElemento = "Paquetes";
                if (dsRec.Paquetes != null && dsRec.Paquetes.Rows.Count > 0)
                {
                    AddDefRow(dsRet, "Paquetes", "dFUM", "dFUM", false, true);
                    foreach (WSSinCRM.dsCentral.PaquetesRow rwPaquetes in dsRec.Paquetes.Rows)
                    {
                        try
                        {
                            sKey = BuildXMLKey(dsRec.Paquetes, rwPaquetes);

                            sqlCmdUpdPaquetes.Parameters["@idPaquete"].Value = rwPaquetes.idPaquete;
                            sqlCmdUpdPaquetes.Parameters["@NombrePaquete"].Value = rwPaquetes.NombrePaquete;
                            sqlCmdUpdPaquetes.Parameters["@dFUM"].Value = rwPaquetes.dFUM;
                            sqlCmdUpdPaquetes.Parameters["@iEstado"].Value = rwPaquetes.iEstado;

                            sqlCmdUpdPaquetes.ExecuteNonQuery();
                        }
                        catch
                        {
                            AddErrorRow(dsRet, "Paquetes", sKey);
                        }
                    }
                }
                #endregion
                UpdatePaso();

                #region CampanyasCabecera
                //RH
                sElemento = "CampanyasCabecera";
                if (dsRec.CampanyasCabecera != null && dsRec.CampanyasCabecera.Rows.Count > 0)
                {
                    AddDefRow(dsRet, "CampanyasCabecera", "dFUM", "dFUM", false, true);
                    foreach (WSSinCRM.dsCentral.CampanyasCabeceraRow rwCampanyasCabecera in dsRec.CampanyasCabecera.Rows)
                    {
                        try
                        {
                            sKey = BuildXMLKey(dsRec.CampanyasCabecera, rwCampanyasCabecera);

                            sqlCmdUpdCampanyasCabecera.Parameters["@IdCampanya"].Value = rwCampanyasCabecera.IdCampanya;
                            sqlCmdUpdCampanyasCabecera.Parameters["@NombreCampanya"].Value = rwCampanyasCabecera.NombreCampanya;
                            sqlCmdUpdCampanyasCabecera.Parameters["@Descuento"].Value = rwCampanyasCabecera.Descuento;
                            sqlCmdUpdCampanyasCabecera.Parameters["@sIdTipoPedido"].Value = rwCampanyasCabecera.sIdTipoPedido;
                            sqlCmdUpdCampanyasCabecera.Parameters["@fImporteMinObli"].Value = rwCampanyasCabecera.fImporteMinObli;
                            sqlCmdUpdCampanyasCabecera.Parameters["@dFUM"].Value = rwCampanyasCabecera.dFUM;
                            sqlCmdUpdCampanyasCabecera.Parameters["@iEstado"].Value = rwCampanyasCabecera.iEstado;
                            //---- GSG (07/02/2011)
                            sqlCmdUpdCampanyasCabecera.Parameters["@fImporteMinObliBruto"].Value = rwCampanyasCabecera.fImporteMinObliBruto;
                            //---- GSG (21/05/2012)
                            sqlCmdUpdCampanyasCabecera.Parameters["@iNumMinUnidades"].Value = rwCampanyasCabecera.iNumMinUnidades;
                            //---- GSG (30/09/2013)
                            sqlCmdUpdCampanyasCabecera.Parameters["@fRentMin"].Value = rwCampanyasCabecera.fRentMin;
                            //---- GSG (06/02/2014)
                            sqlCmdUpdCampanyasCabecera.Parameters["@dVigenciaIni"].Value = rwCampanyasCabecera.dVigenciaIni;
                            sqlCmdUpdCampanyasCabecera.Parameters["@dVigenciaFin"].Value = rwCampanyasCabecera.dVigenciaFin;
                            //---- GSG (12/05/2014)
                            sqlCmdUpdCampanyasCabecera.Parameters["@bCondPago"].Value = rwCampanyasCabecera.bCondPago;
                            if (!rwCampanyasCabecera.IsdFechaFacturacionNull())
                                sqlCmdUpdCampanyasCabecera.Parameters["@dFechaFacturacion"].Value = rwCampanyasCabecera.dFechaFacturacion;
                            else
                                sqlCmdUpdCampanyasCabecera.Parameters["@dFechaFacturacion"].Value = System.DBNull.Value;
                            //---- GSG (16/06/2014)
                            sqlCmdUpdCampanyasCabecera.Parameters["@bSoloFlex"].Value = rwCampanyasCabecera.bSoloFlex;
                            //---- GSG (28/08/2015)
                            if (!rwCampanyasCabecera.IssCodPagoFijaNull())
                                sqlCmdUpdCampanyasCabecera.Parameters["@sCodPagoFija"].Value = rwCampanyasCabecera.sCodPagoFija;
                            else
                                sqlCmdUpdCampanyasCabecera.Parameters["@sCodPagoFija"].Value = "";

                            sqlCmdUpdCampanyasCabecera.ExecuteNonQuery();
                        }
                        catch( Exception e)
                        {
                            AddErrorRow(dsRet, "CampanyasCabecera", sKey);
                        }
                    }
                }
                #endregion
                UpdatePaso();

				#region PeriodosPresupuestos
				sElemento="PeriodosPresupuestos";
				AddDefRow(dsRet,"PeriodosPresupuestos","dFUM","dFUM",false,true);
				if (dsRec.PeriodosPresupuestos !=  null &&  dsRec.PeriodosPresupuestos.Rows.Count >0 )
				{

					foreach(WSSinCRM.dsCentral.PeriodosPresupuestosRow rwPer in dsRec.PeriodosPresupuestos.Rows )
					{
						try
						{
							sKey = BuildXMLKey(dsRec.PeriodosPresupuestos,rwPer);

							sqlCmdUpdPeriodosPresupuestos.Parameters["@iIdPeriodo"].Value= rwPer.iIdPeriodo; 
							sqlCmdUpdPeriodosPresupuestos.Parameters["@dFechaIni"].Value= rwPer.dFechaIni; 
							sqlCmdUpdPeriodosPresupuestos.Parameters["@dFechaFin"].Value= rwPer.dFechaFin;
							sqlCmdUpdPeriodosPresupuestos.Parameters["@sDescripcion"].Value= rwPer.sDescripcion; 
							sqlCmdUpdPeriodosPresupuestos.Parameters["@dFUM"].Value= rwPer.dFUM;
							sqlCmdUpdPeriodosPresupuestos.Parameters["@iEstado"].Value= rwPer.iEstado; 

							sqlCmdUpdPeriodosPresupuestos.ExecuteNonQuery();
						}
						catch
						{
							AddErrorRow(dsRet,"PeriodosPresupuestos",sKey);
						}

					}

				}
				#endregion
				UpdatePaso();
					
				#region Gastos
				sElemento="Gastos";
				if (dsRec.Gastos != null &&  dsRec.Gastos.Rows.Count >0 )
				{
					//Gastos
					AddDefRow(dsRet,"Gastos","dFUM","dFUM",false,true);
					foreach (WSSinCRM.dsCentral.GastosRow rwGas in dsRec.Gastos.Rows)
					{
						try
						{
							sKey = BuildXMLKey(dsRec.Gastos,rwGas);

							sqlCmdUpdGastos.Parameters["@iIdGasto"].Value = rwGas.iIdGasto;
							sqlCmdUpdGastos.Parameters["@sDescripcion"].Value = rwGas.sDescripcion;
							sqlCmdUpdGastos.Parameters["@fPrecio"].Value = rwGas.fPrecio;
							sqlCmdUpdGastos.Parameters["@sCuentaSAP"].Value = rwGas.IssCuentaSAPNull()?SqlString.Null:rwGas.sCuentaSAP;
							sqlCmdUpdGastos.Parameters["@sCosteSAP"].Value = rwGas.IssCosteSAPNull()?SqlString.Null:rwGas.sCosteSAP;
							sqlCmdUpdGastos.Parameters["@bSistema"].Value = rwGas.bSistema;
							sqlCmdUpdGastos.Parameters["@bImputaPresup"].Value = rwGas.bImputaPresup;
							sqlCmdUpdGastos.Parameters["@sIdCategGasto"].Value = rwGas.IssIdCategGastoNull()?SqlString.Null:rwGas.sIdCategGasto;
							sqlCmdUpdGastos.Parameters["@sIdTipCentroCoste"].Value = rwGas.IssIdTipCentroCosteNull()?SqlString.Null:rwGas.sIdTipCentroCoste;
							sqlCmdUpdGastos.Parameters["@sIdTipoGasto"].Value = rwGas.IssIdTipoGastoNull()?SqlString.Null:rwGas.sIdTipoGasto;
							sqlCmdUpdGastos.Parameters["@iNumLimite"].Value = rwGas.IsiNumLimiteNull()?SqlInt32.Null:rwGas.iNumLimite;
							sqlCmdUpdGastos.Parameters["@dFUM"].Value = rwGas.dFUM;
							sqlCmdUpdGastos.Parameters["@iEstado"].Value = rwGas.iEstado;

							sqlCmdUpdGastos.ExecuteNonQuery();
						}
						catch
						{
							AddErrorRow(dsRet,"Gastos",sKey);
						}

					}
				}
				#endregion
				UpdatePaso();
					
				#region TiposPosPedidosSAP
				sElemento="TiposPosPedidosSAP";
				if (dsRec.TiposPosPedidosSAP != null &&  dsRec.TiposPosPedidosSAP.Rows.Count >0 )
				{

					AddDefRow(dsRet,"TiposPosPedidosSAP","dFUM","dFUM",false,true);
					foreach(WSSinCRM.dsCentral.TiposPosPedidosSAPRow  rwTS in dsRec.TiposPosPedidosSAP.Rows )
					{

						try
						{

							sKey = BuildXMLKey(dsRec.TiposPosPedidosSAP,rwTS);

							sqlCmdUpdTiposPosPedidosSAP.Parameters["@sIdTipoPedido"].Value =rwTS.sIdTipoPedido;
							sqlCmdUpdTiposPosPedidosSAP.Parameters["@sIdTipoPosicion"].Value=rwTS.sIdTipoPosicion ;
							sqlCmdUpdTiposPosPedidosSAP.Parameters["@bEntregado"].Value=rwTS.bEntregado ;
							sqlCmdUpdTiposPosPedidosSAP.Parameters["@bGratis"].Value=rwTS.bGratis ;
							sqlCmdUpdTiposPosPedidosSAP.Parameters["@bEntregadoOpt"].Value=rwTS.bEntregadoOpt;
                            //---- GSG (06/03/2012)
                            sqlCmdUpdTiposPosPedidosSAP.Parameters["@iEstado"].Value = rwTS.iEstado;

							sqlCmdUpdTiposPosPedidosSAP.ExecuteNonQuery();
						}

						catch
						{
							AddErrorRow(dsRet,"TiposPosPedidosSAP",sKey);
						}
					}


				}
				#endregion
				UpdatePaso();
					
				#region Bricks
				sElemento="Bricks";
				if (dsRec.Bricks != null && dsRec.Bricks.Rows.Count >0 )
				{
					AddDefRow(dsRet,"Bricks","dFUM","dFUM",false,true);
					//AddDefRow(dsRet,"Bricks","dFAR","dFAR",false,true);
					foreach(WSSinCRM.dsCentral.BricksRow rwBr in dsRec.Bricks.Rows)
					{
						try
						{
							sKey = BuildXMLKey(dsRec.Bricks,rwBr);

							sqlCmdUpdBricks.Parameters["@sIdBrick"].Value = rwBr.sIdBrick; 
							sqlCmdUpdBricks.Parameters["@sDescripcion"].Value = rwBr.sDescripcion;
							sqlCmdUpdBricks.Parameters["@bTipoBrick"].Value = rwBr.bTipoBrick;
							sqlCmdUpdBricks.Parameters["@iIdProvincia"].Value = rwBr.IsiIdProvinciaNull()?SqlInt32.Null:rwBr.iIdProvincia;
							sqlCmdUpdBricks.Parameters["@dFAR"].Value = rwBr.dFAR;
							sqlCmdUpdBricks.Parameters["@dFBR"].Value = rwBr.IsdFBRNull()?SqlDateTime.Null:rwBr.dFBR; 
							sqlCmdUpdBricks.Parameters["@iEstado"].Value = rwBr.iEstado; 

							sqlCmdUpdBricks.ExecuteNonQuery();
						}
						catch
						{
							AddErrorRow(dsRet,"Bricks",sKey);
						}

					}

				}
				#endregion
				UpdatePaso();
					
				#region TipoCargoDelegado
				sElemento="TipoCargoDelegado";
				if (dsRec.TipoCargoDelegado!=null && dsRec.TipoCargoDelegado.Rows.Count>0)
				{
					AddDefRow(dsRet,"TipoCargoDelegado","dFUM","dFUM",false,true);
					foreach(WSSinCRM.dsCentral.TipoCargoDelegadoRow rwTC in dsRec.TipoCargoDelegado.Rows)
					{
						try
						{
							sKey = BuildXMLKey(dsRec.TipoCargoDelegado,rwTC);

							sqlCmdUpdTipoCargoDelegado.Parameters["@iIdCargo"].Value = rwTC.iIdCargo;
							sqlCmdUpdTipoCargoDelegado.Parameters["@sCargo"].Value = rwTC.sCargo;
							sqlCmdUpdTipoCargoDelegado.Parameters["@bTieneBricks"].Value = rwTC.bTieneBricks;
							sqlCmdUpdTipoCargoDelegado.Parameters["@IGClientesCOM"].Value = rwTC.IGClientesCOM;
							sqlCmdUpdTipoCargoDelegado.Parameters["@iGCLientesSAP"].Value = rwTC.iGCLientesSAP;
							sqlCmdUpdTipoCargoDelegado.Parameters["@IGPedidos"].Value = rwTC.IGPedidos ;
							sqlCmdUpdTipoCargoDelegado.Parameters["@IGGastos"].Value =rwTC.IGGastos ;
							sqlCmdUpdTipoCargoDelegado.Parameters["@IGVisitas"].Value = rwTC.IGVisitas;
							sqlCmdUpdTipoCargoDelegado.Parameters["@IGAtenciones"].Value = rwTC.IGAtenciones;
							sqlCmdUpdTipoCargoDelegado.Parameters["@IGAccionesMark"].Value =rwTC.IGAccionesMark ;
							sqlCmdUpdTipoCargoDelegado.Parameters["@IGCentros"].Value = rwTC.IGCentros;
							sqlCmdUpdTipoCargoDelegado.Parameters["@sDirImagen"].Value = !rwTC.IssDirImagenNull()?rwTC.sDirImagen:SqlString.Null;
							sqlCmdUpdTipoCargoDelegado.Parameters["@dFUM"].Value = rwTC.dFUM;
							sqlCmdUpdTipoCargoDelegado.Parameters["@iEstado"].Value = rwTC.iEstado;


							sqlCmdUpdTipoCargoDelegado.ExecuteNonQuery();
						}
						catch
						{
							AddErrorRow(dsRet,"TipoCargoDelegado",sKey);
						}
					}
				}
				#endregion
				UpdatePaso();
					
				#region Delegados
				sElemento="Delegados";
				AddDefRow(dsRet,"Delegados","dFUM","dFUM",false,true);
				if (dsRec.Delegados != null &&  dsRec.Delegados.Rows.Count >0 )
				{

					foreach(WSSinCRM.dsCentral.DelegadosRow  rwDl in dsRec.Delegados.Rows )
					{

						try
						{
							sKey = BuildXMLKey(dsRec.Delegados,rwDl);

							sqlCmdUpdDelegados.Parameters["@iIdDelegado"].Value = rwDl.iIdDelegado ;
							sqlCmdUpdDelegados.Parameters["@sNombre"].Value = rwDl.sNombre ;
							sqlCmdUpdDelegados.Parameters["@sIdDelegadoSAP"].Value = rwDl.IssIdDelegadoSAPNull()?SqlString.Null:rwDl.sIdDelegadoSAP ;
							sqlCmdUpdDelegados.Parameters["@sIdCentroSAP"].Value = rwDl.IssIdCentroSAPNull()?SqlString.Null:rwDl.sIdCentroSAP ;
							sqlCmdUpdDelegados.Parameters["@sIdAlmacenSAP"].Value = rwDl.IssIdAlmacenSAPNull()?SqlString.Null:rwDl.sIdAlmacenSAP ;
							sqlCmdUpdDelegados.Parameters["@bVisa"].Value = rwDl.bVisa ;
							sqlCmdUpdDelegados.Parameters["@sObservaciones"].Value = rwDl.IssObservacionesNull()?SqlString.Null:rwDl.sObservaciones ;
							sqlCmdUpdDelegados.Parameters["@iEstado"].Value = rwDl.iEstado ;
							sqlCmdUpdDelegados.Parameters["@dFUM"].Value = rwDl.dFUM ;
							sqlCmdUpdDelegados.Parameters["@sUsuario"].Value = rwDl.IssUsuarioNull()?SqlString.Null:rwDl.sUsuario ;
							sqlCmdUpdDelegados.Parameters["@iIdCargo"].Value = rwDl.IsiIdCargoNull()?SqlInt32.Null:rwDl.iIdCargo ;
							sqlCmdUpdDelegados.Parameters["@iIdParrilla"].Value = rwDl.IsiIdParrillaNull()?SqlInt32.Null:rwDl.iIdParrilla ;
							sqlCmdUpdDelegados.Parameters["@nmedicos"].Value = rwDl.IsnmedicosNull()?SqlInt32.Null:rwDl.nmedicos ;
							if (rwDl.IsiIdGastoKMSNull())
								sqlCmdUpdDelegados.Parameters["@iIdGastoKMS"].Value = DBNull.Value;
							else 
								sqlCmdUpdDelegados.Parameters["@iIdGastoKMS"].Value =rwDl.iIdGastoKMS;
                            //---- GSG (23/09/2013)
                            if (rwDl.IsdFecMaxNotaNull())
                                sqlCmdUpdDelegados.Parameters["@dFecMaxNota"].Value = DBNull.Value;
                            else
                                sqlCmdUpdDelegados.Parameters["@dFecMaxNota"].Value = rwDl.dFecMaxNota;
                            if (rwDl.IsiIdGastoDietNull())
                                sqlCmdUpdDelegados.Parameters["@iIdGastoDiet"].Value = DBNull.Value;
                            else
                                sqlCmdUpdDelegados.Parameters["@iIdGastoDiet"].Value = rwDl.iIdGastoDiet;

                            //---- FI GSG


							sqlCmdUpdDelegados.ExecuteNonQuery();
						}
						catch
						{
							AddErrorRow(dsRet,"Delegados",sKey);
						}



					}

				}
				#endregion
				UpdatePaso();
					
				#region Presupuestos
				sElemento="Presupuestos";
				if (dsRec.Presupuestos != null &&  dsRec.Presupuestos.Rows.Count >0)
				{
 
					AddDefRow(dsRet,"Presupuestos","dFUM","dFUM",false,true);
					foreach(WSSinCRM.dsCentral.PresupuestosRow rwPre in dsRec.Presupuestos.Rows)
					{
						try
						{

							sKey = BuildXMLKey(dsRec.Presupuestos,rwPre);

							sqlCmdUpdPresupuestos.Parameters["@iIdDelegado"].Value = rwPre.iIdDelegado ;
							sqlCmdUpdPresupuestos.Parameters["@sTipoPresupuesto"].Value = rwPre.sTipoPresupuesto ;
							sqlCmdUpdPresupuestos.Parameters["@iIdPeriodo"].Value = rwPre.iIdPeriodo ;
							sqlCmdUpdPresupuestos.Parameters["@fImporte"].Value = rwPre.fImporte ;
							sqlCmdUpdPresupuestos.Parameters["@fImporteActual"].Value = rwPre.fImporteActual ;
							sqlCmdUpdPresupuestos.Parameters["@dFUM"].Value = rwPre.dFUM ;
							sqlCmdUpdPresupuestos.Parameters["@iEstado"].Value = rwPre.iEstado ;

							sqlCmdUpdPresupuestos.ExecuteNonQuery();
						}
						catch
						{
							AddErrorRow(dsRet,"Presupuestos",sKey);
						}
					}
					
				}
				#endregion
				UpdatePaso();
					
				#region CodigosPostales
				sElemento="CodigosPostales";
				if (dsRec.CodigosPostales != null &&  dsRec.CodigosPostales.Rows.Count>0)
				{
					AddDefRow(dsRet,"CodigosPostales","dFUM","dFUM",false,true);

					foreach(WSSinCRM.dsCentral.CodigosPostalesRow rwCP in dsRec.CodigosPostales.Rows)
					{
						try
						{
							sKey = BuildXMLKey(dsRec.CodigosPostales,rwCP);

							this.sqlCmdUpdCodPostal.Parameters["@sCodPostal"].Value = rwCP.sCodPostal;
						
							sqlCmdUpdCodPostal.ExecuteNonQuery();
						}
						catch
						{
							AddErrorRow(dsRet,"CodigosPostales",sKey);
						}
					}
				}
				#endregion
				UpdatePaso();
					
				#region Poblaciones
				sElemento="Poblaciones";
				if (dsRec.Poblaciones != null &&  dsRec.Poblaciones.Rows.Count>0)
				{
					AddDefRow(dsRet,"Poblaciones","dFUM","dFUM",false,true);
					foreach(WSSinCRM.dsCentral.PoblacionesRow rwPob in dsRec.Poblaciones.Rows)
					{
						try
						{
							sKey =	BuildXMLKey(dsRec.Poblaciones,rwPob);

							this.sqlCmdUpdPoblaciones.Parameters["@iIdPoblacion"].Value = rwPob.iIdPoblacion ;
							this.sqlCmdUpdPoblaciones.Parameters["@sCodPostal"].Value = rwPob.sCodPostal ;
							this.sqlCmdUpdPoblaciones.Parameters["@sDescripcion"].Value = rwPob.sDescripcion ;
							this.sqlCmdUpdPoblaciones.Parameters["@iIdProvincia"].Value = rwPob.iIdProvincia ;

							sqlCmdUpdPoblaciones.ExecuteNonQuery();
						}
						catch
						{
							AddErrorRow(dsRet,"Poblaciones",sKey);
						}
					}
				}
				#endregion
				UpdatePaso();
					
				#region DelegadoBrick
				sElemento="DelegadoBrick";
				if (dsRec.DelegadoBrick != null &&  dsRec.DelegadoBrick.Rows.Count>0 )
				{
					AddDefRow(dsRet,"DelegadoBrick","dFUM","dFUM",false,true);
					//AddDefRow(dsRet,"DelegadoBrick","dFAR","dFAR",false,true);
					foreach(WSSinCRM.dsCentral.DelegadoBrickRow rwDBr in dsRec.DelegadoBrick.Rows)
					{
						try
						{

							sKey = BuildXMLKey(dsRec.DelegadoBrick,rwDBr);

							sqlCmdUpdDelegadoBrick.Parameters["@iIdDelegado"].Value = rwDBr.iIdDelegado; 
							sqlCmdUpdDelegadoBrick.Parameters["@sIdBrick"].Value = rwDBr.sIdBrick;
							sqlCmdUpdDelegadoBrick.Parameters["@dFAR"].Value = rwDBr.dFAR;
							sqlCmdUpdDelegadoBrick.Parameters["@dFBR"].Value = rwDBr.IsdFBRNull()?SqlDateTime.Null:rwDBr.dFBR; 
							sqlCmdUpdDelegadoBrick.Parameters["@iEstado"].Value = rwDBr.iEstado;

							sqlCmdUpdDelegadoBrick.ExecuteNonQuery();
						}
						catch
						{
							AddErrorRow(dsRet,"DelegadoBrick",sKey);
						}
					}
				}
				#endregion
				UpdatePaso();
					
				#region Agenda
				sElemento="Agenda";
				if (dsRec.AgendaObserv !=null && dsRec.AgendaObserv.Rows.Count >0  )
				{
					AddDefRow(dsRet,"AgendaObserv","dFecha","dFecha",false,true);
					foreach(WSSinCRM.dsCentral.AgendaObservRow rwAg in dsRec.AgendaObserv.Rows)
					{
						try
						{
							sKey = BuildXMLKey(dsRec.AgendaObserv,rwAg);
							this.sqlCmdUpdAgenda.Parameters["@iIdDelegado"].Value = rwAg.iIdDelegado; 
							this.sqlCmdUpdAgenda.Parameters["@dFecha"].Value = rwAg.dFecha; 
							this.sqlCmdUpdAgenda.Parameters["@tObservaciones"].Value = rwAg.IstObservacionesNull()?SqlString.Null:rwAg.tObservaciones;

							this.sqlCmdUpdAgenda.ExecuteNonQuery();
						}
						catch
						{
							AddErrorRow(dsRet,"AgendaObservaciones",sKey);
						}
					}
				}
				#endregion
				UpdatePaso();
					
				#region BrickCodigoPostal
				sElemento="BrickCodigoPostal";
				if (dsRec.BrickCodigoPostal != null &&  dsRec.BrickCodigoPostal.Rows.Count >0 )
				{
					AddDefRow(dsRet,"BrickCodigoPostal","dFUM","dFUM",false,true);
					//AddDefRow(dsRet,"BrickCodigoPostal","dFAR","dFAR",false,true);
					foreach(WSSinCRM.dsCentral.BrickCodigoPostalRow rwCp in dsRec.BrickCodigoPostal.Rows)
					{
						try
						{
							sKey = BuildXMLKey (dsRec.BrickCodigoPostal,rwCp);

							sqlCmdUpdBrickCP.Parameters["@sIdBrick"].Value = rwCp.sIdBrick;
							sqlCmdUpdBrickCP.Parameters["@sCodPostal"].Value = rwCp.sCodPostal;
							sqlCmdUpdBrickCP.Parameters["@dFAR"].Value = rwCp.dFAR;
							sqlCmdUpdBrickCP.Parameters["@dFBR"].Value = rwCp.IsdFBRNull()?SqlDateTime.Null:rwCp.dFBR;
							sqlCmdUpdBrickCP.Parameters["@iEstado"].Value = rwCp.iEstado; 
 
							sqlCmdUpdBrickCP.ExecuteNonQuery();
						}
						catch
						{
							AddErrorRow(dsRet,"BrickCodigoPostal",sKey);
						}
					}

				}
				#endregion
				UpdatePaso();
				
				#region AccionesMarketing
				sElemento="AccionesMarketing";
				if (dsRec.AccionesMarketing !=  null &&  dsRec.AccionesMarketing.Rows.Count >0 )
				{
					AddDefRow(dsRet,"AccionesMarketing","dFUM","dFUM",false,true);
					foreach(WSSinCRM.dsCentral.AccionesMarketingRow  rwAcM in dsRec.AccionesMarketing.Rows)
					{
						try
						{
							sKey = BuildXMLKey(dsRec.AccionesMarketing,rwAcM);

							sqlCmdUpdAccionesMark.Parameters["@iIdAccion"].Value = rwAcM.iIdAccion; 
							sqlCmdUpdAccionesMark.Parameters["@sIdAccion"].Value = rwAcM.sIdAccion;
							sqlCmdUpdAccionesMark.Parameters["@sDescAccion"].Value = rwAcM.IssDescAccionNull()?SqlString.Null:rwAcM.sDescAccion; 
							sqlCmdUpdAccionesMark.Parameters["@sIdTipoAccion"].Value = rwAcM.sIdTipoAccion; 
							sqlCmdUpdAccionesMark.Parameters["@dFechaCreacion"].Value = rwAcM.dFechaCreacion;
							sqlCmdUpdAccionesMark.Parameters["@dFechaIni"].Value = rwAcM.dFechaIni; 
							sqlCmdUpdAccionesMark.Parameters["@dFechaFin"].Value = rwAcM.dFechaFin; 
							sqlCmdUpdAccionesMark.Parameters["@iUnidades"].Value = rwAcM.iUnidades;
							sqlCmdUpdAccionesMark.Parameters["@fCosteUnitario"].Value = rwAcM.fCosteUnitario; 
							sqlCmdUpdAccionesMark.Parameters["@fCosteTotal"].Value = rwAcM.fCosteTotal; 
							sqlCmdUpdAccionesMark.Parameters["@sObservaciones"].Value = rwAcM.IssObservacionesNull()?SqlString.Null:rwAcM.sObservaciones;
							sqlCmdUpdAccionesMark.Parameters["@sIdTipoImputacion"].Value = rwAcM.IssIdTipoImputacionNull()?SqlString.Null:rwAcM.sIdTipoImputacion; 
							sqlCmdUpdAccionesMark.Parameters["@dFUM"].Value = rwAcM.dFUM;
							sqlCmdUpdAccionesMark.Parameters["@iEstado"].Value = rwAcM.iEstado;
							if (!rwAcM.IsiNumElemEntregarNull())
								sqlCmdUpdAccionesMark.Parameters["@iNumElemEntregar"].Value = rwAcM.iNumElemEntregar;
							else 
								sqlCmdUpdAccionesMark.Parameters["@iNumElemEntregar"].Value = DBNull.Value;
							//---- GSG (10/12/2013)
                            sqlCmdUpdAccionesMark.Parameters["@fImpMin"].Value = rwAcM.fImpMin;
                            sqlCmdUpdAccionesMark.Parameters["@fImpMax"].Value = rwAcM.fImpMax;
                            sqlCmdUpdAccionesMark.Parameters["@iMaxAEntregar"].Value = rwAcM.iMaxAEntregar;
                            //---- GSG (26/09/2016)
                            sqlCmdUpdAccionesMark.Parameters["@Multiplicador"].Value = rwAcM.IsMultiplicadorNull() ? 0 : rwAcM.Multiplicador;
                            sqlCmdUpdAccionesMark.Parameters["@bIndepe"].Value = rwAcM.IsbIndepeNull() ? false : rwAcM.bIndepe;
                            sqlCmdUpdAccionesMark.Parameters["@sIdProducto"].Value = rwAcM.IssIdProductoNull() ? SqlString.Null : rwAcM.sIdProducto;
                            sqlCmdUpdAccionesMark.Parameters["@bSuma"].Value = rwAcM.IsbSumaNull() ? false : rwAcM.bSuma;
                            sqlCmdUpdAccionesMark.Parameters["@iActivoPara"].Value = rwAcM.IsiActivoParaNull() ? 0 : rwAcM.iActivoPara;
                            sqlCmdUpdAccionesMark.Parameters["@fRentabilidad"].Value = rwAcM.IsfRentabilidadNull() ? 0 : rwAcM.fRentabilidad;



                            sqlCmdUpdAccionesMark.ExecuteNonQuery();
						}
						catch(Exception ex)
						{
							System.Diagnostics.Debug.WriteLine(ex.Message);
							AddErrorRow(dsRet,"AccionesMarketing",sKey);
						}
					}
				}
				#endregion
				UpdatePaso();

				#region AccionesRedes
				sElemento="AccionesRedes";
				if (dsRec.AccionesRedes != null &&  dsRec.AccionesRedes.Rows.Count >0 )
				{
					AddDefRow(dsRet,"AccionesRedes","dFUM","dFUM",false,true);
					//AddDefRow(dsRet,"AccionesRedes","dFAR","dFAR",false,true);
					foreach(WSSinCRM.dsCentral.AccionesRedesRow  rwAcM in dsRec.AccionesRedes.Rows)
					{
						try
						{
							sKey = BuildXMLKey(dsRec.AccionesRedes,rwAcM);

							sqlCmdUpdAccionesRedes.Parameters["@iIdAccion"].Value = rwAcM.iIdAccion; 
							sqlCmdUpdAccionesRedes.Parameters["@sIdRed"].Value = rwAcM.sIdRed;
							sqlCmdUpdAccionesRedes.Parameters["@dFBR"].Value = rwAcM.IsdFBRNull()?SqlDateTime.Null:rwAcM.dFBR;
							sqlCmdUpdAccionesRedes.Parameters["@dFAR"].Value = rwAcM.dFAR;
							sqlCmdUpdAccionesRedes.Parameters["@iEstado"].Value = rwAcM.iEstado;

							sqlCmdUpdAccionesRedes.ExecuteNonQuery();
						}
						catch
						{
							AddErrorRow(dsRet,"AccionesRedes",sKey);
						}
					}
				}
				#endregion
				UpdatePaso();

				#region Solicitud Gadget
				sElemento="SolicitudGadget";
				if (dsRec.SolicitudGadget !=  null &&  dsRec.SolicitudGadget.Rows.Count>0)
				{
					AddDefRow(dsRet,"SolicitudGadget","dFUM","dFUM",false,true);
					foreach(WSSinCRM.dsCentral.SolicitudGadgetRow rwG in dsRec.SolicitudGadget.Rows)
					{
						try
						{
							sKey = BuildXMLKey(dsRec.SolicitudGadget,rwG);

							sqlCmdUpdSolGad.Parameters["@sIdSolicitud"].Value = rwG.sIdSolicitud;
							sqlCmdUpdSolGad.Parameters["@iIdDelegado"].Value = rwG.iIdDelegado;
							sqlCmdUpdSolGad.Parameters["@Fecha"].Value = rwG.Fecha;
							sqlCmdUpdSolGad.Parameters["@iIdGadget"].Value = rwG.iIdGadget;
							sqlCmdUpdSolGad.Parameters["@iCantidadSol"].Value = rwG.iCantidadSol;
							sqlCmdUpdSolGad.Parameters["@iCantidadServ"].Value = rwG.iCantidadServ;
							sqlCmdUpdSolGad.Parameters["@sStatus"].Value = rwG.IssStatusNull()?System.Data.SqlTypes.SqlString.Null:rwG.sStatus;
							sqlCmdUpdSolGad.Parameters["@tObservaciones"].Value = rwG.IstObservacionesNull()?System.Data.SqlTypes.SqlString.Null:rwG.tObservaciones;
							sqlCmdUpdSolGad.Parameters["@dFUM"].Value = rwG.dFUM;

							sqlCmdUpdSolGad.ExecuteNonQuery();

						}
						catch
						{
							AddErrorRow(dsRet,"SolicitudGadget",sKey);
						}
					}
				}
				#endregion
				UpdatePaso();

				#region EspecialidadesDelegado
				sElemento="EspecialidadesDelegado";
				if (dsRec.EspecialidadesDelegado != null &&  dsRec.EspecialidadesDelegado.Rows.Count>0)
				{
					AddDefRow(dsRet,"EspecialidadesDelegado","dFUM","dFUM",false,true);
					foreach(WSSinCRM.dsCentral.EspecialidadesDelegadoRow  rwEG in dsRec.EspecialidadesDelegado.Rows)
					{
						try
						{
							sKey = BuildXMLKey(dsRec.EspecialidadesDelegado,rwEG);

							sqlCmdEspecialidadesDelegado.Parameters["@iIdDelegado"].Value = rwEG.iIdDelegado; 
							sqlCmdEspecialidadesDelegado.Parameters["@sIdEspecialidad"].Value = rwEG.sIdEspecialidad; 
							sqlCmdEspecialidadesDelegado.Parameters["@iEstado"].Value = rwEG.iEstado; 
							sqlCmdEspecialidadesDelegado.Parameters["@dFUM"].Value = rwEG.dFUM; 

							sqlCmdEspecialidadesDelegado.ExecuteNonQuery();

						}
						catch
						{
							AddErrorRow(dsRet,"EspecialidadesDelegado",sKey);
						}
					}
				}
				#endregion
				UpdatePaso();

				#region EspecialidadesRedes
				sElemento="EspecialidadesRedes";
				if (dsRec.EspecialidadesRedes != null &&  dsRec.EspecialidadesRedes.Rows.Count>0)
				{
					AddDefRow(dsRet,"EspecialidadesRedes","dFUM","dFUM",false,true);
					foreach(WSSinCRM.dsCentral.EspecialidadesRedesRow  rwER in dsRec.EspecialidadesRedes.Rows)
					{
						try
						{
							sKey = BuildXMLKey(dsRec.EspecialidadesRedes,rwER);

							sqlCmdEspecialidadesRedes.Parameters["@sIdRed"].Value = rwER.sIdRed ; 
							sqlCmdEspecialidadesRedes.Parameters["@sIdEspecialidad"].Value = rwER.sIdEspecialidad; 
							sqlCmdEspecialidadesRedes.Parameters["@iEstado"].Value = rwER.iEstado; 
							sqlCmdEspecialidadesRedes.Parameters["@dFUM"].Value = rwER.dFUM; 

							sqlCmdEspecialidadesRedes.ExecuteNonQuery();

						}
						catch
						{
							AddErrorRow(dsRet,"EspecialidadesRedes",sKey);
						}
					}
				}
				#endregion
				UpdatePaso();

				#region PromocionesRedes
				sElemento="PromocionesRedes";
				if (dsRec.PromocionesRedes != null &&  dsRec.PromocionesRedes.Rows.Count>0)
				{
					AddDefRow(dsRet,"PromocionesRedes","dFUM","dFUM",false,true);
					foreach(WSSinCRM.dsCentral.PromocionesRedesRow  rwPR in dsRec.PromocionesRedes.Rows)
					{
						try
						{
							sKey = BuildXMLKey(dsRec.PromocionesRedes,rwPR);

							sqlCmdPromocionesRedes.Parameters["@sIdRed"].Value = rwPR.sIdRed ; 
							sqlCmdPromocionesRedes.Parameters["@sIdProducto"].Value = rwPR.sIdProducto ; 
							sqlCmdPromocionesRedes.Parameters["@iEstado"].Value = rwPR.iEstado; 
							sqlCmdPromocionesRedes.Parameters["@dFUM"].Value = rwPR.dFUM; 

							sqlCmdPromocionesRedes.ExecuteNonQuery();

						}
						catch
						{
							AddErrorRow(dsRet,"PromocionesRedes",sKey);
						}
					}
				}
				#endregion
				UpdatePaso();

				#region Estructura Comercial
				sElemento="EstructuraComercial";
				if (dsRec.EstructuraComercial != null &&  dsRec.EstructuraComercial.Rows.Count>0)
				{
					AddDefRow(dsRet,"EstrucCom","dFUM","dFUM",false,true);
					foreach(WSSinCRM.dsCentral.EstructuraComercialRow rwPR in dsRec.EstructuraComercial.Rows)
					{
						try
						{
							sKey = BuildXMLKey(dsRec.EstructuraComercial,rwPR);
							
							sqlCmdUpdEstrucCom.Parameters["@iIdDelegado"].Value = rwPR.iIdDelegado;							
							sqlCmdUpdEstrucCom.Parameters["@iIdDelegadoResp"].Value = rwPR.IsiIdDelegadoRespNull()?SqlInt32.Null:rwPR.iIdDelegadoResp; 							 
							sqlCmdUpdEstrucCom.Parameters["@dFUM"].Value = rwPR.dFUM; 
							sqlCmdUpdEstrucCom.Parameters["@iEstado"].Value = rwPR.iEstado;

							sqlCmdUpdEstrucCom.ExecuteNonQuery();

						}
						catch (Exception ex)
						{
							AddErrorRow(dsRet,"EstructuraComercial",sKey);
						}
					}
				}
				#endregion
				UpdatePaso();

				#region Parrilla
				sElemento="Parrilla";
				if (dsRec.Parrilla != null && dsRec.Parrilla.Rows.Count >0  )
				{
					//Parrilla
					AddDefRow(dsRet,"Parrilla","dFUM","dFUM",false,true);
					foreach(WSSinCRM.dsCentral.ParrillaRow rwParrilla in dsRec.Parrilla.Rows)
					{
						try
						{
							sKey = BuildXMLKey(dsRec.Parrilla,rwParrilla);

							sqlCmdUpdParrilla.Parameters["@iIdParrilla"].Value = rwParrilla.IidParrilla;
							sqlCmdUpdParrilla.Parameters["@sparrilla"].Value = rwParrilla.Sparrilla; 
							sqlCmdUpdParrilla.Parameters["@dFUM"].Value = rwParrilla.dFUM; 
							sqlCmdUpdParrilla.Parameters["@iEstado"].Value = rwParrilla.iEstado; 

							sqlCmdUpdParrilla.ExecuteNonQuery();
						}
						catch
						{
							AddErrorRow(dsRet,"Parrilla",sKey);
						}
					}
				}
				#endregion
				UpdatePaso();					

				#region MaterialParrilla
				sElemento="MaterialParrilla";
				if (dsRec.MaterialParrilla  != null && dsRec.MaterialParrilla.Rows.Count >0  )
				{
					//MaterialParrilla
					AddDefRow(dsRet,"MaterialParrilla","dFUM","dFUM",false,true);
					foreach(WSSinCRM.dsCentral.MaterialParrillaRow rwMaterialParrilla in dsRec.MaterialParrilla.Rows)
					{
						try
						{
							sKey = BuildXMLKey(dsRec.MaterialParrilla,rwMaterialParrilla);

							sqlCmdUpdMaterialParrilla.Parameters["@IidParrilla"].Value = rwMaterialParrilla.IidParrilla;
							sqlCmdUpdMaterialParrilla.Parameters["@IidAccion"].Value = rwMaterialParrilla.IidAccion; 
							sqlCmdUpdMaterialParrilla.Parameters["@dFUM"].Value = rwMaterialParrilla.dFUM; 
							sqlCmdUpdMaterialParrilla.Parameters["@iEstado"].Value = rwMaterialParrilla.iEstado; 
 
							sqlCmdUpdMaterialParrilla.ExecuteNonQuery();
						}
						catch
						{
							AddErrorRow(dsRet,"MaterialParrilla",sKey);
						}
					}
				}
				#endregion
				UpdatePaso();	
				
				#region MaterialRentabilidad
				sElemento="MaterialRentabilidad";
				if (dsRec.MaterialRentabilidad != null && dsRec.MaterialRentabilidad.Rows.Count > 0)
				{
					
					foreach(WSSinCRM.dsCentral.MaterialRentabilidadRow rwRenta in dsRec.MaterialRentabilidad.Rows)
					{

						try
						{
							sKey = BuildXMLKey(dsRec.MaterialRentabilidad,rwRenta);

							sqlCmdUpdMaterialesRentabilidad.Parameters["@sIdMaterial"].Value = rwRenta.sIdMaterial;
							sqlCmdUpdMaterialesRentabilidad.Parameters["@fCoste"].Value = rwRenta.fCoste;
							sqlCmdUpdMaterialesRentabilidad.Parameters["@dFum"].Value = rwRenta.dFum;
							sqlCmdUpdMaterialesRentabilidad.Parameters["@iEstado"].Value = rwRenta.iEstado;
							
							sqlCmdUpdMaterialesRentabilidad.ExecuteNonQuery();
						}
						catch(Exception ex)
						{
						  AddErrorRow(dsRet,"MaterialRentabilidad",sKey);
						}

					}									
				}				
				#endregion
				UpdatePaso();

				#region SincroEstructuraPDA
				sElemento = "SincroEstructuraPDA";
				if (dsRec.SincroEstructuraPDA != null && dsRec.SincroEstructuraPDA.Rows.Count > 0)
				{
					foreach(WSSinCRM.dsCentral.SincroEstructuraPDARow rwSincro in dsRec.SincroEstructuraPDA.Rows)
					{
						try
						{
							sKey = "idDelegado = " + rwSincro.iIdDelegado.ToString() + " dFecha = " + rwSincro.dfecha.ToShortDateString();
							
							sqlCmdUpdSincroEstructuraPDA.Parameters["@iIdDelegado"].Value = rwSincro.iIdDelegado;

							if (rwSincro.IssCommandNull())
								sqlCmdUpdSincroEstructuraPDA.Parameters["@sCommand"].Value = DBNull.Value;
							else 
								sqlCmdUpdSincroEstructuraPDA.Parameters["@sCommand"].Value = rwSincro.sCommand;

							if (rwSincro.IsdFechaEjecucionNull())
								sqlCmdUpdSincroEstructuraPDA.Parameters["@dFechaEjecucion"].Value = DBNull.Value;
							else
								sqlCmdUpdSincroEstructuraPDA.Parameters["@dFechaEjecucion"].Value = rwSincro.dFechaEjecucion;
							
							sqlCmdUpdSincroEstructuraPDA.Parameters["@dfecha"].Value = rwSincro.dfecha;

							sqlCmdUpdSincroEstructuraPDA.ExecuteNonQuery();
						}
						catch(Exception ex)
						{
							
						}
					}					
				}				
				#endregion
				UpdatePaso();

                #region TramosRentabilidad
                sElemento = "TramosRentabilidad";
				if (dsRec.TramosRentabilidad != null && dsRec.TramosRentabilidad.Rows.Count > 0)
				{
					foreach(WSSinCRM.dsCentral.TramosRentabilidadRow rwTramo in dsRec.TramosRentabilidad.Rows)
					{
						try
						{
							sqlCmdUpdTramosRentabilidad.Parameters["@idTramo"].Value = rwTramo.idTramo;
							sqlCmdUpdTramosRentabilidad.Parameters["@fValMinTramo"].Value = rwTramo.fValMinTramo;
							sqlCmdUpdTramosRentabilidad.Parameters["@fValMaxTramo"].Value = rwTramo.fValMaxTramo;
							sqlCmdUpdTramosRentabilidad.Parameters["@sDescripcion"].Value = rwTramo.sDescripcion;
							
							if (rwTramo.IssColorNull())
								sqlCmdUpdTramosRentabilidad.Parameters["@sColor"].Value = DBNull.Value;
							else 
								sqlCmdUpdTramosRentabilidad.Parameters["@sColor"].Value = rwTramo.sColor;

							sqlCmdUpdTramosRentabilidad.Parameters["@bActivo"].Value = rwTramo.bActivo;

                            //---- GSG (12/11/2014)
                            sqlCmdUpdTramosRentabilidad.Parameters["@dIniVig"].Value = rwTramo.dIniVig;
                            sqlCmdUpdTramosRentabilidad.Parameters["@dFinVig"].Value = rwTramo.dFinVig;
                            //---- FI GSG

							sqlCmdUpdTramosRentabilidad.ExecuteNonQuery();
						}
						catch(Exception ex)
						{
							System.Diagnostics.Debug.WriteLine(ex.Message);
						}
					}
				}

				#endregion 

                //---- GSG (08/04/2011)
                UpdatePaso();

                #region ProductosCampanya
                sElemento = "ProductosCampanya";
                if (dsRec.ProductosCampanya != null && dsRec.ProductosCampanya.Rows.Count > 0)
                {
                    AddDefRow(dsRet, "ProductosCampanya", "dFUM", "dFUM", false, true);
                    foreach (WSSinCRM.dsCentral.ProductosCampanyaRow rwProductosCampanya in dsRec.ProductosCampanya.Rows)
                    {
                        try
                        {
                            sKey = BuildXMLKey(dsRec.ProductosCampanya, rwProductosCampanya);

                            sqlCmdUpdProductosCampanya.Parameters["@sIdProducto"].Value = rwProductosCampanya.sIdProducto;
                            sqlCmdUpdProductosCampanya.Parameters["@idCampanya"].Value = rwProductosCampanya.idCampanya;
                            sqlCmdUpdProductosCampanya.Parameters["@iNumMinOblis"].Value = rwProductosCampanya.iNumMinOblis;
                            sqlCmdUpdProductosCampanya.Parameters["@fImporteMinObli"].Value = rwProductosCampanya.fImporteMinObli;
                            sqlCmdUpdProductosCampanya.Parameters["@fImporteMinObliBruto"].Value = rwProductosCampanya.fImporteMinObliBruto;
                            sqlCmdUpdProductosCampanya.Parameters["@fDescuentoMax"].Value = rwProductosCampanya.fDescuentoMax;
                            sqlCmdUpdProductosCampanya.Parameters["@dFUM"].Value = rwProductosCampanya.dFUM;
                            sqlCmdUpdProductosCampanya.Parameters["@iEstado"].Value = rwProductosCampanya.iEstado;

                            sqlCmdUpdProductosCampanya.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            AddErrorRow(dsRet, "ProductosCampanya", sKey);
                        }
                    }
                }
                #endregion

                UpdatePaso();

                #region ClubsAviso
                sElemento = "ClubsAviso";
                if (dsRec.ClubsAviso != null && dsRec.ClubsAviso.Rows.Count > 0)
                {
                    AddDefRow(dsRet, "ClubsAviso", "dFUM", "dFUM", false, true);
                    foreach (WSSinCRM.dsCentral.ClubsAvisoRow rwClubsAviso in dsRec.ClubsAviso.Rows)
                    {
                        try
                        {
                            sKey = BuildXMLKey(dsRec.ClubsAviso, rwClubsAviso);

                            sqlCmdUpdClubsAviso.Parameters["@sGarantia"].Value = rwClubsAviso.sGarantia;
                            sqlCmdUpdClubsAviso.Parameters["@dFUM"].Value = rwClubsAviso.dFUM;
                            sqlCmdUpdClubsAviso.Parameters["@iEstado"].Value = rwClubsAviso.iEstado;

                            sqlCmdUpdClubsAviso.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            AddErrorRow(dsRet, "ClubsAviso", sKey);
                        }
                    }
                }
                #endregion

                UpdatePaso();

                #region Descuento_Mayoristas
                sElemento = "Descuento_Mayoristas";
                if (dsRec.Descuento_Mayoristas != null && dsRec.Descuento_Mayoristas.Rows.Count > 0)
                {
                    AddDefRow(dsRet, "Descuento_Mayoristas", "dFUM", "dFUM", false, true);
                    foreach (WSSinCRM.dsCentral.Descuento_MayoristasRow rwDescuento_Mayoristas in dsRec.Descuento_Mayoristas.Rows)
                    {
                        try
                        {
                            sKey = BuildXMLKey(dsRec.Descuento_Mayoristas, rwDescuento_Mayoristas);

                            sqlCmdUpdDescuento_Mayoristas.Parameters["@iIdDestinatario"].Value = rwDescuento_Mayoristas.iIdDestinatario;
                            sqlCmdUpdDescuento_Mayoristas.Parameters["@sGarantias"].Value = rwDescuento_Mayoristas.sGarantias;
                            sqlCmdUpdDescuento_Mayoristas.Parameters["@fDescuentoMayorista"].Value = rwDescuento_Mayoristas.fDescuentoMayorista;
                            sqlCmdUpdDescuento_Mayoristas.Parameters["@dFUM"].Value = rwDescuento_Mayoristas.dFUM;
                            sqlCmdUpdDescuento_Mayoristas.Parameters["@fDescMayAvanzado"].Value = rwDescuento_Mayoristas.fDescMayAvanzado; //---- GSG (01/12/2014)

                            sqlCmdUpdDescuento_Mayoristas.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            AddErrorRow(dsRet, "Descuento_Mayoristas", sKey);
                        }
                    }
                }
                #endregion

                UpdatePaso();

                //---- GSG (22/03/2012)
                #region CondicionesComercialesProductos
                sElemento = "CondicionesComercialesProductos";
                if (dsRec.CondicionesComercialesProductos != null && dsRec.CondicionesComercialesProductos.Rows.Count > 0)
                {
                    AddDefRow(dsRet, "CondicionesComercialesProductos", "dFUM", "dFUM", false, true);
                    foreach (WSSinCRM.dsCentral.CondicionesComercialesProductosRow rwCondicionesComercialesProductos in dsRec.CondicionesComercialesProductos.Rows)
                    {
                        try
                        {
                            sKey = BuildXMLKey(dsRec.CondicionesComercialesProductos, rwCondicionesComercialesProductos);

                            sqlCmdUpdCondicionesComercialesProductos.Parameters["@sIdProducto"].Value = rwCondicionesComercialesProductos.sIdProducto;
                            sqlCmdUpdCondicionesComercialesProductos.Parameters["@sIdSubProducto"].Value = rwCondicionesComercialesProductos.sIdSubProducto;
                            sqlCmdUpdCondicionesComercialesProductos.Parameters["@sDescSubProducto"].Value = rwCondicionesComercialesProductos.sDescSubProducto;
                            sqlCmdUpdCondicionesComercialesProductos.Parameters["@dFUM"].Value = rwCondicionesComercialesProductos.dFUM;
                            sqlCmdUpdCondicionesComercialesProductos.Parameters["@iEstado"].Value = rwCondicionesComercialesProductos.iEstado;

                            sqlCmdUpdCondicionesComercialesProductos.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            AddErrorRow(dsRet, "CondicionesComercialesProductos", sKey);
                        }
                    }
                }
                #endregion

                UpdatePaso();

                #region CondicionesComercialesMateriales
                sElemento = "CondicionesComercialesMateriales";
                if (dsRec.CondicionesComercialesMateriales != null && dsRec.CondicionesComercialesMateriales.Rows.Count > 0)
                {
                    AddDefRow(dsRet, "CondicionesComercialesMateriales", "dFUM", "dFUM", false, true);
                    foreach (WSSinCRM.dsCentral.CondicionesComercialesMaterialesRow rwCondicionesComercialesMateriales in dsRec.CondicionesComercialesMateriales.Rows)
                    {
                        try
                        {
                            sKey = BuildXMLKey(dsRec.CondicionesComercialesMateriales, rwCondicionesComercialesMateriales);

                            sqlCmdUpdCondicionesComercialesMateriales.Parameters["@sIdSubProducto"].Value = rwCondicionesComercialesMateriales.sIdSubProducto;
                            sqlCmdUpdCondicionesComercialesMateriales.Parameters["@sIdMaterial"].Value = rwCondicionesComercialesMateriales.sIdMaterial;
                            sqlCmdUpdCondicionesComercialesMateriales.Parameters["@dFUM"].Value = rwCondicionesComercialesMateriales.dFUM;
                            sqlCmdUpdCondicionesComercialesMateriales.Parameters["@iEstado"].Value = rwCondicionesComercialesMateriales.iEstado;

                            sqlCmdUpdCondicionesComercialesMateriales.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            AddErrorRow(dsRet, "CondicionesComercialesMateriales", sKey);
                        }
                    }
                }
                #endregion

                UpdatePaso();

                #region CondicionesComercialesGrupos
                sElemento = "CondicionesComercialesGrupos";
                if (dsRec.CondicionesComercialesGrupos != null && dsRec.CondicionesComercialesGrupos.Rows.Count > 0)
                {
                    AddDefRow(dsRet, "CondicionesComercialesGrupos", "dFUM", "dFUM", false, true);
                    foreach (WSSinCRM.dsCentral.CondicionesComercialesGruposRow rwCondicionesComercialesGrupos in dsRec.CondicionesComercialesGrupos.Rows)
                    {
                        try
                        {
                            sKey = BuildXMLKey(dsRec.CondicionesComercialesGrupos, rwCondicionesComercialesGrupos);

                            sqlCmdUpdCondicionesComercialesGrupos.Parameters["@IdGrupo"].Value = rwCondicionesComercialesGrupos.IdGrupo;
                            sqlCmdUpdCondicionesComercialesGrupos.Parameters["@sDescGrupo"].Value = rwCondicionesComercialesGrupos.sDescGrupo;
                            sqlCmdUpdCondicionesComercialesGrupos.Parameters["@iIdProvincia"].Value = rwCondicionesComercialesGrupos.iIdProvincia;
                            try {sqlCmdUpdCondicionesComercialesGrupos.Parameters["@dFechaVencimiento"].Value = rwCondicionesComercialesGrupos.dFechaVencimiento;}
                            catch (Exception e) { sqlCmdUpdCondicionesComercialesGrupos.Parameters["@dFechaVencimiento"].Value = null;}
                            try { sqlCmdUpdCondicionesComercialesGrupos.Parameters["@iDiasVencimiento"].Value = rwCondicionesComercialesGrupos.iDiasVencimiento; }
                            catch (Exception e) { sqlCmdUpdCondicionesComercialesGrupos.Parameters["@iDiasVencimiento"].Value = null; }
                            try { sqlCmdUpdCondicionesComercialesGrupos.Parameters["@fImporte"].Value = rwCondicionesComercialesGrupos.fImporte; }
                            catch (Exception e) { sqlCmdUpdCondicionesComercialesGrupos.Parameters["@fImporte"].Value = null; }
                           
                            sqlCmdUpdCondicionesComercialesGrupos.Parameters["@dFUM"].Value = rwCondicionesComercialesGrupos.dFUM;
                            sqlCmdUpdCondicionesComercialesGrupos.Parameters["@iEstado"].Value = rwCondicionesComercialesGrupos.iEstado;

                            sqlCmdUpdCondicionesComercialesGrupos.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            AddErrorRow(dsRet, "CondicionesComercialesGrupos", sKey);
                        }
                    }
                } 
                #endregion

                UpdatePaso();

                #region CondicionesComerciales
                sElemento = "CondicionesComerciales";
                if (dsRec.CondicionesComerciales != null && dsRec.CondicionesComerciales.Rows.Count > 0)
                {
                    AddDefRow(dsRet, "CondicionesComerciales", "dFUM", "dFUM", false, true);
                    foreach (WSSinCRM.dsCentral.CondicionesComercialesRow rwCondicionesComerciales in dsRec.CondicionesComerciales.Rows)
                    {
                        try
                        {
                            sKey = BuildXMLKey(dsRec.CondicionesComerciales, rwCondicionesComerciales);

                            sqlCmdUpdCondicionesComerciales.Parameters["@IdGrupo"].Value = rwCondicionesComerciales.IdGrupo;
                            sqlCmdUpdCondicionesComerciales.Parameters["@sIdSubProducto"].Value = rwCondicionesComerciales.sIdSubProducto;
                            sqlCmdUpdCondicionesComerciales.Parameters["@iUnidades"].Value = rwCondicionesComerciales.iUnidades;
                            sqlCmdUpdCondicionesComerciales.Parameters["@dFUM"].Value = rwCondicionesComerciales.dFUM;
                            sqlCmdUpdCondicionesComerciales.Parameters["@iEstado"].Value = rwCondicionesComerciales.iEstado;

                            sqlCmdUpdCondicionesComerciales.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            AddErrorRow(dsRet, "CondicionesComerciales", sKey);
                        }
                    }
                }
                #endregion

                UpdatePaso();

                //---- GSG (05/06/2013) sqlCmdUpdAccMarkCamp

                #region Acciones Márketing / Campañas
                sElemento = "AccionesMarkCampanyas";
                if (dsRec.AccionesMarkCampanyas != null && dsRec.AccionesMarkCampanyas.Rows.Count > 0)
                {
                    AddDefRow(dsRet, "AccionesMarkCampanyas", "dFUM", "dFUM", false, true);
                    foreach (WSSinCRM.dsCentral.AccionesMarkCampanyasRow rwAccionesMarkCampanyas in dsRec.AccionesMarkCampanyas.Rows)
                    {
                        try
                        {
                            sKey = BuildXMLKey(dsRec.AccionesMarkCampanyas, rwAccionesMarkCampanyas);

                            sqlCmdUpdAccMarkCamp.Parameters["@sIdAccion"].Value = rwAccionesMarkCampanyas.sIdAccion;
                            sqlCmdUpdAccMarkCamp.Parameters["@IdCampanya"].Value = rwAccionesMarkCampanyas.idCampanya;
                            sqlCmdUpdAccMarkCamp.Parameters["@fDescuento"].Value = rwAccionesMarkCampanyas.fDescuento;
                            sqlCmdUpdAccMarkCamp.Parameters["@iEstado"].Value = rwAccionesMarkCampanyas.iEstado;
                            sqlCmdUpdAccMarkCamp.Parameters["@dFUM"].Value = rwAccionesMarkCampanyas.dFUM;

                            sqlCmdUpdAccMarkCamp.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            AddErrorRow(dsRet, "AccionesMarkCampanyas", sKey);
                        }
                    }
                }
                #endregion

                UpdatePaso();


                //---- GSG (19/09/2013)
                #region Costes
                sElemento = "Costes";
                if (dsRec.Costes != null && dsRec.Costes.Rows.Count > 0)
                {
                    AddDefRow(dsRet, "Costes", "dFUM", "dFUM", false, true);
                    foreach (WSSinCRM.dsCentral.CostesRow rwCostes in dsRec.Costes.Rows)
                    {
                        try
                        {
                            sKey = BuildXMLKey(dsRec.Costes, rwCostes);

                            sqlCmdUpdCostes.Parameters["@sCodSAP"].Value = rwCostes.sCodSAP;
                            sqlCmdUpdCostes.Parameters["@dFecIni"].Value = rwCostes.dFecIni;
                            //sqlCmdUpdCostes.Parameters["@dFecFin"].Value = rwCostes.dFecFin;
                            try { sqlCmdUpdCostes.Parameters["@dFecFin"].Value = rwCostes.dFecFin; }
                            catch (Exception e) { sqlCmdUpdCostes.Parameters["@dFecFin"].Value = null; }
                            sqlCmdUpdCostes.Parameters["@fCoste"].Value = rwCostes.fCoste;
                            sqlCmdUpdCostes.Parameters["@iCuenta"].Value = rwCostes.iCuenta;

                            sqlCmdUpdCostes.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            AddErrorRow(dsRet, "Costes", sKey);
                        }
                    }
                }
                #endregion


                UpdatePaso();

                //---- GSG (01/10/2013)
                #region MinimoUnidadesVenta
                sElemento = "MinimoUnidadesVenta";
                if (dsRec.MinimoUnidadesVenta != null && dsRec.MinimoUnidadesVenta.Rows.Count > 0)
                {
                    AddDefRow(dsRet, "MinimoUnidadesVenta", "dFUM", "dFUM", false, true);
                    foreach (WSSinCRM.dsCentral.MinimoUnidadesVentaRow rwMUV in dsRec.MinimoUnidadesVenta.Rows)
                    {
                        try
                        {
                            sKey = BuildXMLKey(dsRec.MinimoUnidadesVenta, rwMUV);

                            sqlCmdUpdMUV.Parameters["@sIdProducto"].Value = rwMUV.sIdProducto;
                            sqlCmdUpdMUV.Parameters["@sIdMaterial"].Value = rwMUV.sIdMaterial;
                            sqlCmdUpdMUV.Parameters["@dFecIni"].Value = rwMUV.dFecIni;
                            sqlCmdUpdMUV.Parameters["@dFecFin"].Value = rwMUV.dFecFin;
                            sqlCmdUpdMUV.Parameters["@sIdCliente"].Value = rwMUV.sIdCliente;
                            sqlCmdUpdMUV.Parameters["@iMinQty"].Value = rwMUV.iMinQty;
                            sqlCmdUpdMUV.Parameters["@sObservaciones"].Value = rwMUV.sObservaciones;
                            sqlCmdUpdMUV.Parameters["@sObservaciones2"].Value = rwMUV.sObservaciones2;
                            sqlCmdUpdMUV.Parameters["@iEstado"].Value = rwMUV.iEstado;
                            sqlCmdUpdMUV.Parameters["@dFUM"].Value = rwMUV.dFUM;

                            sqlCmdUpdMUV.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            AddErrorRow(dsRet, "MinimoUnidadesVenta", sKey);
                        }
                    }
                }
                #endregion


                UpdatePaso();

                //---- GSG (18/10/2013)
                #region DescuentoMax (mayorista-material)
                sElemento = "DescuentoMax";
                if (dsRec.DescuentoMax != null && dsRec.DescuentoMax.Rows.Count > 0)
                {
                    AddDefRow(dsRet, "DescuentoMax", "dFUM", "dFUM", false, true);
                    foreach (WSSinCRM.dsCentral.DescuentoMaxRow rwDM in dsRec.DescuentoMax.Rows)
                    {
                        try
                        {
                            sKey = BuildXMLKey(dsRec.DescuentoMax, rwDM);

                            sqlCmdUpdDescuentoMax.Parameters["@iIdCliente"].Value = rwDM.iIdCliente;
                            sqlCmdUpdDescuentoMax.Parameters["@sIdCliente"].Value = rwDM.sIdCliente;
                            sqlCmdUpdDescuentoMax.Parameters["@sIdMaterial"].Value = rwDM.sIdMaterial;
                            sqlCmdUpdDescuentoMax.Parameters["@fDescuentoMaximo"].Value = rwDM.fDescuentoMaximo;
                            sqlCmdUpdDescuentoMax.Parameters["@iEstado"].Value = rwDM.iEstado;

                            sqlCmdUpdDescuentoMax.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            AddErrorRow(dsRet, "DescuentoMax", sKey);
                        }
                    }
                }
                #endregion


                UpdatePaso();

                //---- GSG (23/10/2013)
                #region DirectoZMAY

                sElemento = "DirectoZMAY";
                if (dsRec.DirectoZMAY != null && dsRec.DirectoZMAY.Rows.Count > 0)
                {
                    AddDefRow(dsRet, "DirectoZMAY", "dFUM", "dFUM", false, true);
                    foreach (WSSinCRM.dsCentral.DirectoZMAYRow rwDZMAY in dsRec.DirectoZMAY.Rows)
                    {
                        try
                        {
                            sKey = BuildXMLKey(dsRec.DirectoZMAY, rwDZMAY);

                            sqlCmdUpdDirectoZMAY.Parameters["@sGarantia"].Value = rwDZMAY.sGarantia;
                            sqlCmdUpdDirectoZMAY.Parameters["@iEstado"].Value = rwDZMAY.iEstado;
                            sqlCmdUpdDirectoZMAY.Parameters["@dFUM"].Value = rwDZMAY.dFUM;

                            sqlCmdUpdDirectoZMAY.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            AddErrorRow(dsRet, "DirectoZMAY", sKey);
                        }
                    }
                }

                #endregion

                UpdatePaso();
               

                //---- GSG (18/11/2013)
                #region CampanyasVisibles

                sElemento = "CampanyasVisibles";
                if (dsRec.CampanyasVisibles != null && dsRec.CampanyasVisibles.Rows.Count > 0)
                {
                    AddDefRow(dsRet, "CampanyasVisibles", "dFUM", "dFUM", false, true);
                    foreach (WSSinCRM.dsCentral.CampanyasVisiblesRow rw in dsRec.CampanyasVisibles.Rows)
                    {
                        try
                        {
                            sKey = BuildXMLKey(dsRec.CampanyasVisibles, rw);

                            sqlCmdUpdCampanyasVisibles.Parameters["@sTipoCampanya"].Value = rw.sTipoCampanya;
                            sqlCmdUpdCampanyasVisibles.Parameters["@idCampanya"].Value = rw.IdCampanya;
                            sqlCmdUpdCampanyasVisibles.Parameters["@sIdDelegado"].Value = rw.sIdDelegado;
                            sqlCmdUpdCampanyasVisibles.Parameters["@sIdTipoPedido"].Value = rw.sIdTipoPedido;
                            sqlCmdUpdCampanyasVisibles.Parameters["@iEstado"].Value = rw.iEstado;
                            sqlCmdUpdCampanyasVisibles.Parameters["@dFUM"].Value = rw.dFUM;
                            sqlCmdUpdCampanyasVisibles.Parameters["@sIdMayorista"].Value = rw.sIdMayorista; //---- GSG (05/07/2017)
                            

                            sqlCmdUpdCampanyasVisibles.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            AddErrorRow(dsRet, "CampanyasVisibles", sKey);
                        }
                    }
                }

                #endregion

                UpdatePaso();

                //---- GSG (06/10/2015) La tabla PedAcciones deja de bajar con el pedido y pasa a bajar como lo hacen las maestras independientemente del pedido
                #region PedAcciones Indep
                sElemento = "PedAcciones";
                if (dsRec.PedAcciones != null && dsRec.PedAcciones.Rows.Count > 0)
                {
                    AddDefRow(dsRet, "PedAcciones", "dFUM", "dFUM", false, true);
                    foreach (WSSinCRM.dsCentral.PedAccionesRow rwPA in dsRec.PedAcciones.Rows)
                    {
                        try
                        {
                            sKey = BuildXMLKey(dsRec.PedAcciones, rwPA);

                            sqlCmdUpdPedAcciones.Parameters["@sIdPedido"].Value = rwPA.sIdPedido;
                            sqlCmdUpdPedAcciones.Parameters["@iIdAccion"].Value = rwPA.iIdAccion;
                            sqlCmdUpdPedAcciones.Parameters["@bEnviado"].Value = rwPA.bEnviado;
                            sqlCmdUpdPedAcciones.Parameters["@dFecEnvio"].Value = rwPA.IsdFecEnvioNull() ? SqlDateTime.Null : rwPA.dFecEnvio;
                            sqlCmdUpdPedAcciones.Parameters["@Unidades"].Value = rwPA.Unidades;
                            sqlCmdUpdPedAcciones.Parameters["@Estado"].Value = rwPA.Estado;
                            //---- GSG (21/09/2016)
                            sqlCmdUpdPedAcciones.Parameters["@dAsignacion"].Value = rwPA.IsdAsignacionNull() ? SqlDateTime.Null : rwPA.dAsignacion;
                            sqlCmdUpdPedAcciones.Parameters["@dFUM"].Value = rwPA.IsdFUMNull() ? SqlDateTime.Null : rwPA.dFUM;
                            sqlCmdUpdPedAcciones.Parameters["@Destino"].Value = rwPA.Destino;
                            sqlCmdUpdPedAcciones.Parameters["@Bruto"].Value = rwPA.Bruto;

                            sqlCmdUpdPedAcciones.ExecuteNonQuery();
                        }
                        catch (Exception e)
                        {
                            AddErrorRow(dsRet, "PedAcciones", sKey);
                        }
                    }
                }

                #endregion

                UpdatePaso();

                //---- GSG (15/10/2015)
                #region TarjetasCliente

                sElemento = "TarjetasCliente";
                if (dsRec.TarjetasCliente != null && dsRec.TarjetasCliente.Rows.Count > 0)
                {
                    AddDefRow(dsRet, "TarjetasCliente", "dFUM", "dFUM", false, true);
                    foreach (WSSinCRM.dsCentral.TarjetasClienteRow rw in dsRec.TarjetasCliente.Rows)
                    {
                        try
                        {
                            sKey = BuildXMLKey(dsRec.TarjetasCliente, rw);

                            sqlCmdUpdTarjetasCliente.Parameters["@sIdCliente"].Value = rw.sIdCliente;
                            sqlCmdUpdTarjetasCliente.Parameters["@sIdMaterial"].Value = rw.sIdMaterial;
                            try { sqlCmdUpdTarjetasCliente.Parameters["@dFecAsignacion"].Value = rw.dFecAsignacion; }
                            catch (Exception e) { sqlCmdUpdTarjetasCliente.Parameters["@dFecAsignacion"].Value = null; }
                            try { sqlCmdUpdTarjetasCliente.Parameters["@dFecUso"].Value = rw.dFecUso; }
                            catch (Exception e) { sqlCmdUpdTarjetasCliente.Parameters["@dFecUso"].Value = null; }
                            sqlCmdUpdTarjetasCliente.Parameters["@dFUM"].Value = rw.dFUM;
                            sqlCmdUpdTarjetasCliente.Parameters["@iEstado"].Value = rw.iEstado;
                            try { sqlCmdUpdTarjetasCliente.Parameters["@sIdProducto"].Value = rw.sIdProducto; }
                            catch (Exception e) { sqlCmdUpdTarjetasCliente.Parameters["@sIdProducto"].Value = null; }
                            sqlCmdUpdTarjetasCliente.Parameters["@iUnidadesMin"].Value = rw.iUnidadesMin;
                            sqlCmdUpdTarjetasCliente.Parameters["@fBrutoMin"].Value = rw.fBrutoMin;
                            //---- GSG (23/11/2015)
                            try { sqlCmdUpdTarjetasCliente.Parameters["@dIniValidez"].Value = rw.dIniValidez; }
                            catch (Exception e) { sqlCmdUpdTarjetasCliente.Parameters["@dIniValidez"].Value = null; }
                            try { sqlCmdUpdTarjetasCliente.Parameters["@dFinValidez"].Value = rw.dFinValidez; }
                            catch (Exception e) { sqlCmdUpdTarjetasCliente.Parameters["@dFinValidez"].Value = null; }


                            sqlCmdUpdTarjetasCliente.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            AddErrorRow(dsRet, "TarjetasCliente", sKey);
                        }
                    }
                }

                #endregion

                UpdatePaso();

                //---- GSG (04/11/2015)

                #region AccMarkProductos

                sElemento = "AccMarkProductos";
                if (dsRec.AccMarkProductos != null && dsRec.AccMarkProductos.Rows.Count > 0)
                {
                    AddDefRow(dsRet, "AccMarkProductos", "dFUM", "dFUM", false, true);
                    foreach (WSSinCRM.dsCentral.AccMarkProductosRow rw in dsRec.AccMarkProductos.Rows)
                    {
                        try
                        {
                            sKey = BuildXMLKey(dsRec.AccMarkProductos, rw);

                            sqlCmdUpdAccMarkProd.Parameters["@sIdAccion"].Value = rw.sIdAccion;
                            sqlCmdUpdAccMarkProd.Parameters["@sIdProducto"].Value = rw.sIdProducto;
                            sqlCmdUpdAccMarkProd.Parameters["@dFUM"].Value = rw.dFUM;
                            sqlCmdUpdAccMarkProd.Parameters["@iEstado"].Value = rw.iEstado;

                            sqlCmdUpdAccMarkProd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            AddErrorRow(dsRet, "AccMarkProductos", sKey);
                        }
                    }
                }

                #endregion

                UpdatePaso();

                //---- GSG (26/09/2016)

                #region AccMarkRangos

                sElemento = "AccMarkRangos";
                if (dsRec.AccMarkRangos != null && dsRec.AccMarkRangos.Rows.Count > 0)
                {
                    AddDefRow(dsRet, "AccMarkRangos", "dFUM", "dFUM", false, true);
                    foreach (WSSinCRM.dsCentral.AccMarkRangosRow rw in dsRec.AccMarkRangos.Rows)
                    {
                        try
                        {
                            sKey = BuildXMLKey(dsRec.AccMarkRangos, rw);

                            sqlCmdUpdAccMarkRangos.Parameters["@Id"].Value = rw.Id;
                            sqlCmdUpdAccMarkRangos.Parameters["@fImporteMin"].Value = rw.fImporteMin;
                            sqlCmdUpdAccMarkRangos.Parameters["@fImporteMax"].Value = rw.fImporteMax;
                            sqlCmdUpdAccMarkRangos.Parameters["@iMaxNumAccMark"].Value = rw.iMaxNumAccMark;
                            sqlCmdUpdAccMarkRangos.Parameters["@iEstado"].Value = rw.iEstado;
                            sqlCmdUpdAccMarkRangos.Parameters["@dFUM"].Value = rw.dFUM;

                            sqlCmdUpdAccMarkRangos.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            AddErrorRow(dsRet, "AccMarkRangos", sKey);
                        }
                    }
                }

                #endregion

                UpdatePaso();

                #region AccMarkExclusion

                sElemento = "AccMarkExclusion";
                if (dsRec.AccMarkExclusion != null && dsRec.AccMarkExclusion.Rows.Count > 0)
                {
                    AddDefRow(dsRet, "AccMarkExclusion", "dFUM", "dFUM", false, true);
                    foreach (WSSinCRM.dsCentral.AccMarkExclusionRow rw in dsRec.AccMarkExclusion.Rows)
                    {
                        try
                        {
                            sKey = BuildXMLKey(dsRec.AccMarkExclusion, rw);

                            sqlCmdUpdAccMarkExclusion.Parameters["@iIdAccion1"].Value = rw.iIdAccion1;
                            sqlCmdUpdAccMarkExclusion.Parameters["@iIdAccion2"].Value = rw.iIdAccion2;
                            sqlCmdUpdAccMarkExclusion.Parameters["@iEstado"].Value = rw.iEstado;
                            sqlCmdUpdAccMarkExclusion.Parameters["@dFUM"].Value = rw.dFUM;


                            sqlCmdUpdAccMarkExclusion.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            AddErrorRow(dsRet, "AccMarkExclusion", sKey);
                        }
                    }
                }

                #endregion

                UpdatePaso();

                //---- GSG (24/08/2017)

                #region GrupoCampanya

                sElemento = "GrupoCampanya";
                if (dsRec.GrupoCampanya != null && dsRec.GrupoCampanya.Rows.Count > 0)
                {
                    AddDefRow(dsRet, "GrupoCampanya", "dFUM", "dFUM", false, true);
                    foreach (WSSinCRM.dsCentral.GrupoCampanyaRow rw in dsRec.GrupoCampanya.Rows)
                    {
                        try
                        {
                            sKey = BuildXMLKey(dsRec.GrupoCampanya, rw);

                            sqlCmdUpdGrupoCampanya.Parameters["@idGrupo"].Value = rw.idGrupo;
                            sqlCmdUpdGrupoCampanya.Parameters["@idCampanya"].Value = rw.idCampanya;
                            sqlCmdUpdGrupoCampanya.Parameters["@sMateriales"].Value = rw.sMateriales;
                            sqlCmdUpdGrupoCampanya.Parameters["@iMinUnidades"].Value = rw.iMinUnidades;
                            sqlCmdUpdGrupoCampanya.Parameters["@fMinImporte"].Value = rw.fMinImporte;
                            sqlCmdUpdGrupoCampanya.Parameters["@sIdTipoPedido"].Value = rw.sIdTipoPedido;
                            sqlCmdUpdGrupoCampanya.Parameters["@dFUM"].Value = rw.dFUM;
                            //---- GSG (11/01/2018)
                            sqlCmdUpdGrupoCampanya.Parameters["@iMaxUnidades"].Value = rw.iMaxUnidades;
                            sqlCmdUpdGrupoCampanya.Parameters["@fMaxImporte"].Value = rw.fMaxImporte;
                            //---- GSG (14/05/2018)
                            sqlCmdUpdGrupoCampanya.Parameters["@bObligatorio"].Value = rw.bObligatorio;

                            sqlCmdUpdGrupoCampanya.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            AddErrorRow(dsRet, "GrupoCampanya", sKey);
                        }
                    }
                }

                #endregion

                UpdatePaso();

                #region ReglasGruposCamp

                sElemento = "ReglasGruposCamp";
                if (dsRec.ReglasGruposCamp != null && dsRec.ReglasGruposCamp.Rows.Count > 0)
                {
                    AddDefRow(dsRet, "ReglasGruposCamp", "dFUM", "dFUM", false, true);
                    foreach (WSSinCRM.dsCentral.ReglasGruposCampRow rw in dsRec.ReglasGruposCamp.Rows)
                    {
                        try
                        {
                            sKey = BuildXMLKey(dsRec.ReglasGruposCamp, rw);

                            sqlCmdUpdReglasGruposCamp.Parameters["@idGrupoM"].Value = rw.idGrupoM;
                            sqlCmdUpdReglasGruposCamp.Parameters["@idGrupoS"].Value = rw.idGrupoS;
                            sqlCmdUpdReglasGruposCamp.Parameters["@sTipoCalculo"].Value = rw.sTipoCalculo;
                            sqlCmdUpdReglasGruposCamp.Parameters["@iUBaseM"].Value = rw.iUBaseM;
                            sqlCmdUpdReglasGruposCamp.Parameters["@iUBaseS"].Value = rw.iUBaseS;
                            sqlCmdUpdReglasGruposCamp.Parameters["@dFUM"].Value = rw.dFUM;

                            sqlCmdUpdReglasGruposCamp.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            AddErrorRow(dsRet, "ReglasGruposCamp", sKey);
                        }
                    }
                }


                #endregion

                UpdatePaso();

                #region Ubicaciones

                sElemento = "Ubicaciones";
                if (dsRec.Ubicaciones != null && dsRec.Ubicaciones.Rows.Count > 0)
                {
                    AddDefRow(dsRet, "Ubicaciones", "dFUM", "dFUM", false, true);
                    foreach (WSSinCRM.dsCentral.UbicacionesRow rw in dsRec.Ubicaciones.Rows)
                    {
                        try
                        {
                            sKey = BuildXMLKey(dsRec.Ubicaciones, rw);

                            sqlCmdUpdUbicaciones.Parameters["@Id"].Value = rw.Id;
                            sqlCmdUpdUbicaciones.Parameters["@sDireccion"].Value = rw.sDireccion;
                            sqlCmdUpdUbicaciones.Parameters["@sPoblacion"].Value = rw.sPoblacion;
                            sqlCmdUpdUbicaciones.Parameters["@sCP"].Value = rw.sCP;
                            sqlCmdUpdUbicaciones.Parameters["@iEstado"].Value = rw.iEstado;
                            sqlCmdUpdUbicaciones.Parameters["@dFUM"].Value = rw.dFUM;

                            sqlCmdUpdUbicaciones.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            AddErrorRow(dsRet, "Ubicaciones", sKey);
                        }
                    }
                }

                #endregion

                UpdatePaso();

                #region DivsPedido

                sElemento = "DivsPedido";
                if (dsRec.DivsPedido != null && dsRec.DivsPedido.Rows.Count > 0)
                {
                    AddDefRow(dsRet, "DivsPedido", "dFUM", "dFUM", false, true);
                    foreach (WSSinCRM.dsCentral.DivsPedidoRow rw in dsRec.DivsPedido.Rows)
                    {
                        try
                        {
                            sKey = BuildXMLKey(dsRec.DivsPedido, rw);

                            sqlCmdUpdDivsPedidos.Parameters["@sIdCampanya"].Value = rw.IssIdCampanyaNull() ? null : rw.sIdCampanya;
                            sqlCmdUpdDivsPedidos.Parameters["@sIdMaterial"].Value = rw.IssIdMaterialNull() ? null : rw.sIdMaterial;
                            sqlCmdUpdDivsPedidos.Parameters["@sIdRed"].Value = rw.IssIdRedNull() ? null : rw.sIdRed;
                            sqlCmdUpdDivsPedidos.Parameters["@sIdTipoPedido"].Value = rw.IssIdTipoPedidoNull() ? null : rw.sIdTipoPedido;
                            sqlCmdUpdDivsPedidos.Parameters["@sTipoSAP"].Value = rw.sTipoSAP;
                            sqlCmdUpdDivsPedidos.Parameters["@bFechaPreferente"].Value = rw.bFechaPreferente;
                            sqlCmdUpdDivsPedidos.Parameters["@sIdTipoPedidoNuevo"].Value = rw.IssIdTipoPedidoNuevoNull() ? null : rw.sIdTipoPedidoNuevo;
                            sqlCmdUpdDivsPedidos.Parameters["@sIdTipoPosicion"].Value = rw.IssIdTipoPosicionNull() ? null : rw.sIdTipoPosicion;
                            sqlCmdUpdDivsPedidos.Parameters["@dFecEntrega"].Value = rw.IsdFecEntregaNull() ? DateTime.Today  : rw.dFecEntrega;
                            sqlCmdUpdDivsPedidos.Parameters["@dFechaFacturacion"].Value = rw.IsdFechaFacturacionNull() ? DateTime.Today : rw.dFechaFacturacion;
                            sqlCmdUpdDivsPedidos.Parameters["@sCodPagoFija"].Value = rw.IssCodPagoFijaNull() ? null : rw.sCodPagoFija;
                            sqlCmdUpdDivsPedidos.Parameters["@bNoDivide"].Value = rw.bNoDivide;
                            sqlCmdUpdDivsPedidos.Parameters["@sCampCab"].Value = rw.IssCampCabNull() ? null : rw.sCampCab;
                            sqlCmdUpdDivsPedidos.Parameters["@iEstado"].Value = rw.iEstado;
                            sqlCmdUpdDivsPedidos.Parameters["@dFUM"].Value = rw.dFUM;

                            sqlCmdUpdDivsPedidos.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            AddErrorRow(dsRet, "DivsPedido", sKey);
                        }
                    }
                }

                #endregion

                UpdatePaso();


                //---- GSG (08/05/2019)
                #region Componentes
                sElemento = "Componentes";
                if (dsRec.Componentes != null && dsRec.Componentes.Rows.Count > 0)
                {
                    AddDefRow(dsRet, "Componentes", "dFUM", "dFUM", false, true);
                    foreach (WSSinCRM.dsCentral.ComponentesRow rwComponentes in dsRec.Componentes.Rows)
                    {
                        try
                        {
                            sKey = BuildXMLKey(dsRec.Costes, rwComponentes);

                            sqlCmdUpdComponentes.Parameters["@sIdMaterialPack"].Value = rwComponentes.sidmaterialPack;
                            sqlCmdUpdComponentes.Parameters["@sIdMaterial"].Value = rwComponentes.sidmaterial;
                            sqlCmdUpdComponentes.Parameters["@iUnidades"].Value = rwComponentes.unidades;

                            sqlCmdUpdComponentes.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            AddErrorRow(dsRet, "Componentes", sKey);
                        }
                    }
                }
                #endregion


                UpdatePaso();


                //---- GSG (03/07/2019)

                #region SRVYEncuesta

                sElemento = "SRVYEncuesta";
                if (dsRec.SRVYEncuesta != null && dsRec.SRVYEncuesta.Rows.Count > 0)
                {
                    AddDefRow(dsRet, "SRVYEncuesta", "dFUM", "dFUM", false, true);
                    foreach (WSSinCRM.dsCentral.SRVYEncuestaRow rw in dsRec.SRVYEncuesta.Rows)
                    {
                        try
                        {
                            sKey = BuildXMLKey(dsRec.SRVYEncuesta, rw);

                            sqlCmdUpdSRVYEncuesta.Parameters["@IdEncuesta"].Value = rw.IdEncuesta;
                            sqlCmdUpdSRVYEncuesta.Parameters["@sDescripcion"].Value = rw.sDescripcion;
                            sqlCmdUpdSRVYEncuesta.Parameters["@dFecIni"].Value = rw.dFecIni;
                            sqlCmdUpdSRVYEncuesta.Parameters["@dFecFin"].Value = rw.dFecFin;
                            sqlCmdUpdSRVYEncuesta.Parameters["@bObligatoria"].Value = rw.bObligatoria;
                            sqlCmdUpdSRVYEncuesta.Parameters["@dFUM"].Value = rw.dFUM;
                            sqlCmdUpdSRVYEncuesta.Parameters["@iEstado"].Value = rw.iEstado;

                            sqlCmdUpdSRVYEncuesta.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            AddErrorRow(dsRet, "SRVYEncuesta", sKey);
                        }
                    }
                }

                #endregion

                UpdatePaso();

                #region SRVYPregunta

                sElemento = "SRVYPregunta";
                if (dsRec.SRVYPregunta != null && dsRec.SRVYPregunta.Rows.Count > 0)
                {
                    AddDefRow(dsRet, "SRVYPregunta", "dFUM", "dFUM", false, true);
                    foreach (WSSinCRM.dsCentral.SRVYPreguntaRow rw in dsRec.SRVYPregunta.Rows)
                    {
                        try
                        {
                            sKey = BuildXMLKey(dsRec.SRVYPregunta, rw);

                            sqlCmdUpdSRVYPregunta.Parameters["@IdPregunta"].Value = rw.IdPregunta;
                            sqlCmdUpdSRVYPregunta.Parameters["@IdEncuesta"].Value = rw.IdEncuesta;
                            sqlCmdUpdSRVYPregunta.Parameters["@sPregunta"].Value = rw.sPregunta;
                            sqlCmdUpdSRVYPregunta.Parameters["@dFUM"].Value = rw.dFUM;
                            sqlCmdUpdSRVYPregunta.Parameters["@iEstado"].Value = rw.iEstado;

                            sqlCmdUpdSRVYPregunta.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            AddErrorRow(dsRet, "SRVYPregunta", sKey);
                        }
                    }
                }

                #endregion

                UpdatePaso();

                #region SRVYRespuesta

                sElemento = "SRVYRespuesta";
                if (dsRec.SRVYRespuesta != null && dsRec.SRVYRespuesta.Rows.Count > 0)
                {
                    AddDefRow(dsRet, "SRVYRespuesta", "dFUM", "dFUM", false, true);
                    foreach (WSSinCRM.dsCentral.SRVYRespuestaRow rw in dsRec.SRVYRespuesta.Rows)
                    {
                        try
                        {
                            sKey = BuildXMLKey(dsRec.SRVYRespuesta, rw);

                            sqlCmdUpdSRVYRespuesta.Parameters["@IdRespuesta"].Value = rw.IdRespuesta;
                            sqlCmdUpdSRVYRespuesta.Parameters["@IdPregunta"].Value = rw.IdPregunta;
                            sqlCmdUpdSRVYRespuesta.Parameters["@IdEncuesta"].Value = rw.IdEncuesta;
                            sqlCmdUpdSRVYRespuesta.Parameters["@sRespuesta"].Value = rw.sRespuesta;
                            sqlCmdUpdSRVYRespuesta.Parameters["@dFUM"].Value = rw.dFUM;
                            sqlCmdUpdSRVYRespuesta.Parameters["@iEstado"].Value = rw.iEstado;

                            sqlCmdUpdSRVYRespuesta.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            AddErrorRow(dsRet, "SRVYRespuesta", sKey);
                        }
                    }
                }

                #endregion

                UpdatePaso();

                #region SRVYClienteEncuesta

                sElemento = "SRVYClienteEncuesta";
                if (dsRec.SRVYClienteEncuesta != null && dsRec.SRVYClienteEncuesta.Rows.Count > 0)
                {
                    AddDefRow(dsRet, "SRVYClienteEncuesta", "dFUM", "dFUM", false, true);
                    foreach (WSSinCRM.dsCentral.SRVYClienteEncuestaRow rw in dsRec.SRVYClienteEncuesta.Rows)
                    {
                        try
                        {
                            sKey = BuildXMLKey(dsRec.SRVYClienteEncuesta, rw);

                            if (rw.iIdDelegado == -1)
                                sqlCmdUpdSRVYClienteEncuesta.Parameters["@iIdDelegado"].Value = Clases.Configuracion.iIdDelegado;
                            else
                                sqlCmdUpdSRVYClienteEncuesta.Parameters["@iIdDelegado"].Value = rw.iIdDelegado;
                            sqlCmdUpdSRVYClienteEncuesta.Parameters["@sClasificacion"].Value = rw.sClasificacion;                            
                            sqlCmdUpdSRVYClienteEncuesta.Parameters["@sIdCliente"].Value = rw.sIdCliente;
                            sqlCmdUpdSRVYClienteEncuesta.Parameters["@IdEncuesta"].Value = rw.IdEncuesta;
                            sqlCmdUpdSRVYClienteEncuesta.Parameters["@dFecIni"].Value = rw.dFecIni;
                            sqlCmdUpdSRVYClienteEncuesta.Parameters["@dFecFin"].Value = rw.dfecFin;
                            sqlCmdUpdSRVYClienteEncuesta.Parameters["@bObligatoria"].Value = rw.bObligatoria;
                            sqlCmdUpdSRVYClienteEncuesta.Parameters["@bContestada"].Value = rw.bContestada;
                            sqlCmdUpdSRVYClienteEncuesta.Parameters["@dFUM"].Value = rw.dFUM;
                            sqlCmdUpdSRVYClienteEncuesta.Parameters["@iEstado"].Value = rw.iEstado;

                            sqlCmdUpdSRVYClienteEncuesta.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            AddErrorRow(dsRet, "SRVYClienteEncuesta", sKey);
                        }
                    }
                }

                #endregion

                UpdatePaso();

                #region SRVYClienteRespuesta

                sElemento = "SRVYClienteRespuesta";
                if (dsRec.SRVYClienteRespuesta != null && dsRec.SRVYClienteRespuesta.Rows.Count > 0)
                {
                    AddDefRow(dsRet, "SRVYClienteRespuesta", "dFUM", "dFUM", false, true);
                    foreach (WSSinCRM.dsCentral.SRVYClienteRespuestaRow rw in dsRec.SRVYClienteRespuesta.Rows)
                    {
                        try
                        {
                            sKey = BuildXMLKey(dsRec.SRVYClienteRespuesta, rw);
                            sqlCmdUpdSRVYClienteRespuesta.Parameters["@sIdCliente"].Value = rw.sIdCliente;
                            sqlCmdUpdSRVYClienteRespuesta.Parameters["@iIdEncuesta"].Value = rw.iIdEncuesta;
                            sqlCmdUpdSRVYClienteRespuesta.Parameters["@iIdPregunta"].Value = rw.iIdPregunta;
                            sqlCmdUpdSRVYClienteRespuesta.Parameters["@iIdRespuesta"].Value = rw.iIdRespuesta;
                            sqlCmdUpdSRVYClienteRespuesta.Parameters["@dFUM"].Value = rw.dFUM;
                            sqlCmdUpdSRVYClienteRespuesta.Parameters["@iEstado"].Value = rw.iEstado;
                            sqlCmdUpdSRVYClienteRespuesta.Parameters["@sDelegado"].Value = rw.sDelegado; //---- GSG (24/10/2019)

                            sqlCmdUpdSRVYClienteRespuesta.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            AddErrorRow(dsRet, "SRVYClienteRespuesta", sKey);
                        }
                    }
                }
                
                #endregion

                UpdatePaso();

                //---- GSG (06/03/2021
                #region GrupoHomogeneo

                // 
                // sqlCmdUpdGrupoHomogeneo
                sElemento = "GrupoHomogeneo";
                if (dsRec.GrupoHomogeneo != null && dsRec.GrupoHomogeneo.Rows.Count > 0)
                {
                    AddDefRow(dsRet, "GrupoHomogeneo", "dFUM", "dFUM", false, true);
                    foreach (WSSinCRM.dsCentral.GrupoHomogeneoRow rw in dsRec.GrupoHomogeneo.Rows)
                    {
                        try
                        {
                            sKey = BuildXMLKey(dsRec.GrupoHomogeneo, rw);

                            sqlCmdUpdGrupoHomogeneo.Parameters["@IdAgrupacion"].Value = rw.IdAgrupacion;
                            sqlCmdUpdGrupoHomogeneo.Parameters["@sCodNacional"].Value = rw.sCodNacional;
                            sqlCmdUpdGrupoHomogeneo.Parameters["@sAgrupacionName"].Value = rw.sAgrupacionName;
                            sqlCmdUpdGrupoHomogeneo.Parameters["@sNombreSNS"].Value = rw.sNombreSNS;
                            sqlCmdUpdGrupoHomogeneo.Parameters["@fPVL"].Value = rw.fPVL;
                            sqlCmdUpdGrupoHomogeneo.Parameters["@fPVPIVA"].Value = rw.fPVPIVA;
                            sqlCmdUpdGrupoHomogeneo.Parameters["@fPrecioMenor"].Value = rw.fPrecioMenor;
                            sqlCmdUpdGrupoHomogeneo.Parameters["@fPVPIVAMenor"].Value = rw.fPVPIVAMenor;
                            sqlCmdUpdGrupoHomogeneo.Parameters["@dFUM"].Value = rw.dFUM;
                            sqlCmdUpdGrupoHomogeneo.Parameters["@iEstado"].Value = rw.iEstado;

                            sqlCmdUpdGrupoHomogeneo.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            AddErrorRow(dsRet, "GrupoHomogeneo", sKey);
                        }
                    }
                }


                UpdatePaso();

                #endregion





                //---- GSG (03/01/2023)
                #region MaterialesBloqueoDescuento

                // 
                // sqlCmdUpdMaterialesBloqueoDescuento
                sElemento = "MaterialesBloqueoDescuento";
                if (dsRec.MaterialesBloqueoDescuento != null && dsRec.MaterialesBloqueoDescuento.Rows.Count > 0)
                {
                    AddDefRow(dsRet, "MaterialesBloqueoDescuento", "dFUM", "dFUM", false, true);
                    foreach (WSSinCRM.dsCentral.MaterialesBloqueoDescuentoRow rw in dsRec.MaterialesBloqueoDescuento.Rows)
                    {
                        try
                        {
                            sKey = BuildXMLKey(dsRec.MaterialesBloqueoDescuento, rw);

                            sqlCmdUpdMaterialBloquoDescuento.Parameters["@sIdMaterial"].Value = rw.sIdMaterial;
                            sqlCmdUpdMaterialBloquoDescuento.Parameters["@dFecIni"].Value = rw.dFecIni;
                            sqlCmdUpdMaterialBloquoDescuento.Parameters["@dFecFin"].Value = rw.dFecFin;
                            sqlCmdUpdMaterialBloquoDescuento.Parameters["@bEsPuro"].Value = rw.bEsPuro;
                            sqlCmdUpdMaterialBloquoDescuento.Parameters["@dFUM"].Value = rw.dFUM;
                            sqlCmdUpdMaterialBloquoDescuento.Parameters["@iEstado"].Value = rw.iEstado;

                            sqlCmdUpdMaterialBloquoDescuento.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            AddErrorRow(dsRet, "MaterialesBloqueoDescuento", sKey);
                        }
                    }
                }


                UpdatePaso();

                #endregion


            }
            catch (Exception MyExc)
			{
				Mensajes.ShowError("Contacte con HelpDesk e indique el siguiente error de Sincronización:\n\n"+MyExc.Message+"\n\nEl error se ha producido en Actualizacion de Tablas Maestras, elemento " +sElemento.ToString());
				#region Pone en los Errores toda la informacion
				if (dsRec.Tipos.Rows.Count >0  )
				{
					foreach(WSSinCRM.dsCentral.TiposRow rwTipo in dsRec.Tipos.Rows)
					{
							sKey = BuildXMLKey(dsRec.Tipos,rwTipo);

							AddErrorRow(dsRet,"Tipos",sKey);
					}
				}
				if (dsRec.LineasTipos.Rows.Count >0  )
				{
					foreach (WSSinCRM.dsCentral.LineasTiposRow rwLtipo in dsRec.LineasTipos.Rows)
					{
							sKey = BuildXMLKey(dsRec.LineasTipos,rwLtipo);

							AddErrorRow(dsRet,"LineasTipos",sKey);
					}
				}
				if (dsRec.RedesComerciales.Rows.Count >0  )
				{
					foreach (WSSinCRM.dsCentral.RedesComercialesRow rwLtipo in dsRec.RedesComerciales.Rows)
					{
							sKey = BuildXMLKey(dsRec.RedesComerciales,rwLtipo);

							AddErrorRow(dsRet,"RedesComerciales",sKey);
					}
				}
				if (dsRec.Productos.Rows.Count >0)
				{
					AddDefRow(dsRet,"Divisiones","dFUM","dFUM",false,true);
					foreach (WSSinCRM.dsCentral.DivisionesRow  rwProd in dsRec.Divisiones.Rows)
					{
						sKey = BuildXMLKey(dsRec.Divisiones,rwProd);
						AddErrorRow(dsRet,"Divisiones",sKey);
					}
				}
				if (dsRec.Productos.Rows.Count >0)
				{
					foreach (WSSinCRM.dsCentral.ProductosRow  rwProd in dsRec.Productos.Rows)
					{
							sKey = BuildXMLKey(dsRec.Productos,rwProd);
							AddErrorRow(dsRet,"Productos",sKey);
					}
				}
				if (dsRec.Materiales.Rows.Count  >0 )
				{
					foreach (WSSinCRM.dsCentral.MaterialesRow  rwMat in dsRec.Materiales.Rows)
					{
							sKey = BuildXMLKey(dsRec.Materiales,rwMat);
							AddErrorRow(dsRet,"Materiales",sKey);
					}
				}
				if (dsRec.PeriodosPresupuestos.Rows.Count >0 )
				{
					foreach(WSSinCRM.dsCentral.PeriodosPresupuestosRow rwPer in dsRec.PeriodosPresupuestos.Rows )
					{
							sKey = BuildXMLKey(dsRec.PeriodosPresupuestos,rwPer);
							AddErrorRow(dsRet,"PeriodosPresupuestos",sKey);
					}
				}
				if (dsRec.Gastos.Rows.Count >0 )
				{
					foreach (WSSinCRM.dsCentral.GastosRow rwGas in dsRec.Gastos.Rows)
					{
							sKey = BuildXMLKey(dsRec.Gastos,rwGas);
							AddErrorRow(dsRet,"Gastos",sKey);
					}
				}
				if (dsRec.TiposPosPedidosSAP.Rows.Count >0 )
				{
					foreach(WSSinCRM.dsCentral.TiposPosPedidosSAPRow  rwTS in dsRec.TiposPosPedidosSAP.Rows )
					{
							sKey = BuildXMLKey(dsRec.TiposPosPedidosSAP,rwTS);
							AddErrorRow(dsRet,"TiposPosPedidosSAP",sKey);
					}
				}
				if (dsRec.Bricks.Rows.Count >0 )
				{
					foreach(WSSinCRM.dsCentral.BricksRow rwBr in dsRec.Bricks.Rows)
					{
							sKey = BuildXMLKey(dsRec.Bricks,rwBr);
    						AddErrorRow(dsRet,"Bricks",sKey);
					}
				}
				if (dsRec.TipoCargoDelegado!=null && dsRec.TipoCargoDelegado.Rows.Count>0)
				{
					foreach(WSSinCRM.dsCentral.TipoCargoDelegadoRow rwTC in dsRec.TipoCargoDelegado.Rows)
					{
							sKey = BuildXMLKey(dsRec.TipoCargoDelegado,rwTC);
							AddErrorRow(dsRet,"TipoCargoDelegado",sKey);
					}
				}
				if (dsRec.Delegados.Rows.Count >0 )
				{
					foreach(WSSinCRM.dsCentral.DelegadosRow  rwDl in dsRec.Delegados.Rows )
					{
							sKey = BuildXMLKey(dsRec.Delegados,rwDl);
							AddErrorRow(dsRet,"Delegados",sKey);
					}
				}
				if (dsRec.Presupuestos.Rows.Count >0)
				{
					foreach(WSSinCRM.dsCentral.PresupuestosRow rwPre in dsRec.Presupuestos.Rows)
					{
							sKey = BuildXMLKey(dsRec.Presupuestos,rwPre);
							AddErrorRow(dsRet,"Presupuestos",sKey);
					}
				}
				if (dsRec.CodigosPostales.Rows.Count>0)
				{
					foreach(WSSinCRM.dsCentral.CodigosPostalesRow rwCP in dsRec.CodigosPostales.Rows)
					{
							sKey = BuildXMLKey(dsRec.CodigosPostales,rwCP);
							AddErrorRow(dsRet,"CodigosPostales",sKey);
					}
				}
				if (dsRec.Poblaciones.Rows.Count>0)
				{
					foreach(WSSinCRM.dsCentral.PoblacionesRow rwPob in dsRec.Poblaciones.Rows)
					{
							sKey =	BuildXMLKey(dsRec.Poblaciones,rwPob);
							AddErrorRow(dsRet,"Poblaciones",sKey);
					}
				}
				if (dsRec.DelegadoBrick.Rows.Count>0 )
				{
					foreach(WSSinCRM.dsCentral.DelegadoBrickRow rwDBr in dsRec.DelegadoBrick.Rows)
					{
							sKey = BuildXMLKey(dsRec.DelegadoBrick,rwDBr);
							AddErrorRow(dsRet,"DelegadoBrick",sKey);
					}
				}
				if (dsRec.AgendaObserv !=null && dsRec.AgendaObserv.Rows.Count >0  )
				{
					foreach(WSSinCRM.dsCentral.AgendaObservRow rwAg in dsRec.AgendaObserv.Rows)
					{
							sKey = BuildXMLKey(dsRec.AgendaObserv,rwAg);
							AddErrorRow(dsRet,"AgendaObservaciones",sKey);
					}
				}
				if (dsRec.BrickCodigoPostal.Rows.Count >0 )
				{
					foreach(WSSinCRM.dsCentral.BrickCodigoPostalRow rwCp in dsRec.BrickCodigoPostal.Rows)
					{
							sKey = BuildXMLKey (dsRec.BrickCodigoPostal,rwCp);
							AddErrorRow(dsRet,"BrickCodigoPostal",sKey);
					}
				}
				if (dsRec.AccionesMarketing.Rows.Count >0 )
				{
					foreach(WSSinCRM.dsCentral.AccionesMarketingRow  rwAcM in dsRec.AccionesMarketing.Rows)
					{
							sKey = BuildXMLKey(dsRec.AccionesMarketing,rwAcM);
							AddErrorRow(dsRet,"AccionesMarketing",sKey);
					}
				}
				if (dsRec.AccionesRedes.Rows.Count >0 )
				{
					foreach(WSSinCRM.dsCentral.AccionesRedesRow  rwAcM in dsRec.AccionesRedes.Rows)
					{
							sKey = BuildXMLKey(dsRec.AccionesRedes,rwAcM);
							AddErrorRow(dsRet,"AccionesRedes",sKey);
					}
				}

                //---- GSG (15/10/2015)

                if (dsRec.SolicitudGadget.Rows.Count > 0)
                {
                    foreach (WSSinCRM.dsCentral.SolicitudGadgetRow rw in dsRec.SolicitudGadget.Rows)
                    {
                        sKey = BuildXMLKey(dsRec.SolicitudGadget, rw);
                        AddErrorRow(dsRet, "SolicitudGadget", sKey);
                    }
                }

                if (dsRec.EspecialidadesDelegado.Rows.Count > 0)
                {
                    foreach (WSSinCRM.dsCentral.EspecialidadesDelegadoRow rw in dsRec.EspecialidadesDelegado.Rows)
                    {
                        sKey = BuildXMLKey(dsRec.EspecialidadesDelegado, rw);
                        AddErrorRow(dsRet, "EspecialidadesDelegado", sKey);
                    }
                }

                if (dsRec.EspecialidadesRedes.Rows.Count > 0)
                {
                    foreach (WSSinCRM.dsCentral.EspecialidadesRedesRow rw in dsRec.EspecialidadesRedes.Rows)
                    {
                        sKey = BuildXMLKey(dsRec.EspecialidadesRedes, rw);
                        AddErrorRow(dsRet, "EspecialidadesRedes", sKey);
                    }
                }

                if (dsRec.PromocionesRedes.Rows.Count > 0)
                {
                    foreach (WSSinCRM.dsCentral.PromocionesRedesRow rw in dsRec.PromocionesRedes.Rows)
                    {
                        sKey = BuildXMLKey(dsRec.PromocionesRedes, rw);
                        AddErrorRow(dsRet, "PromocionesRedes", sKey);
                    }
                }

                if (dsRec.EstructuraComercial.Rows.Count > 0)
                {
                    foreach (WSSinCRM.dsCentral.EstructuraComercialRow rw in dsRec.EstructuraComercial.Rows)
                    {
                        sKey = BuildXMLKey(dsRec.EstructuraComercial, rw);
                        AddErrorRow(dsRet, "EstructuraComercial", sKey);
                    }
                }

                if (dsRec.Parrilla.Rows.Count > 0)
                {
                    foreach (WSSinCRM.dsCentral.ParrillaRow rw in dsRec.Parrilla.Rows)
                    {
                        sKey = BuildXMLKey(dsRec.Parrilla, rw);
                        AddErrorRow(dsRet, "Parrilla", sKey);
                    }
                }

                if (dsRec.MaterialParrilla.Rows.Count > 0)
                {
                    foreach (WSSinCRM.dsCentral.MaterialParrillaRow rw in dsRec.MaterialParrilla.Rows)
                    {
                        sKey = BuildXMLKey(dsRec.MaterialParrilla, rw);
                        AddErrorRow(dsRet, "MaterialParrilla", sKey);
                    }
                }

                if (dsRec.MaterialRentabilidad.Rows.Count > 0)
                {
                    foreach (WSSinCRM.dsCentral.MaterialRentabilidadRow rw in dsRec.MaterialRentabilidad.Rows)
                    {
                        sKey = BuildXMLKey(dsRec.MaterialRentabilidad, rw);
                        AddErrorRow(dsRet, "MaterialRentabilidad", sKey);
                    }
                }

                if (dsRec.SincroEstructuraPDA.Rows.Count > 0)
                {
                    foreach (WSSinCRM.dsCentral.SincroEstructuraPDARow rw in dsRec.SincroEstructuraPDA.Rows)
                    {
                        sKey = BuildXMLKey(dsRec.SincroEstructuraPDA, rw);
                        AddErrorRow(dsRet, "SincroEstructuraPDA", sKey);
                    }
                }

                if (dsRec.TramosRentabilidad.Rows.Count > 0)
                {
                    foreach (WSSinCRM.dsCentral.TramosRentabilidadRow rw in dsRec.TramosRentabilidad.Rows)
                    {
                        sKey = BuildXMLKey(dsRec.TramosRentabilidad, rw);
                        AddErrorRow(dsRet, "TramosRentabilidad", sKey);
                    }
                }

                if (dsRec.ProductosCampanya.Rows.Count > 0)
                {
                    foreach (WSSinCRM.dsCentral.ProductosCampanyaRow rw in dsRec.ProductosCampanya.Rows)
                    {
                        sKey = BuildXMLKey(dsRec.ProductosCampanya, rw);
                        AddErrorRow(dsRet, "ProductosCampanya", sKey);
                    }
                }

                if (dsRec.ClubsAviso.Rows.Count > 0)
                {
                    foreach (WSSinCRM.dsCentral.ClubsAvisoRow rw in dsRec.ClubsAviso.Rows)
                    {
                        sKey = BuildXMLKey(dsRec.ClubsAviso, rw);
                        AddErrorRow(dsRet, "ClubsAviso", sKey);
                    }
                }

                if (dsRec.Descuento_Mayoristas.Rows.Count > 0)
                {
                    foreach (WSSinCRM.dsCentral.Descuento_MayoristasRow rw in dsRec.Descuento_Mayoristas.Rows)
                    {
                        sKey = BuildXMLKey(dsRec.Descuento_Mayoristas, rw);
                        AddErrorRow(dsRet, "Descuento_Mayoristas", sKey);
                    }
                }

                if (dsRec.CondicionesComercialesProductos.Rows.Count > 0)
                {
                    foreach (WSSinCRM.dsCentral.CondicionesComercialesProductosRow rw in dsRec.CondicionesComercialesProductos.Rows)
                    {
                        sKey = BuildXMLKey(dsRec.CondicionesComercialesProductos, rw);
                        AddErrorRow(dsRet, "CondicionesComercialesProductos", sKey);
                    }
                }

                if (dsRec.CondicionesComercialesMateriales.Rows.Count > 0)
                {
                    foreach (WSSinCRM.dsCentral.CondicionesComercialesMaterialesRow rw in dsRec.CondicionesComercialesMateriales.Rows)
                    {
                        sKey = BuildXMLKey(dsRec.CondicionesComercialesMateriales, rw);
                        AddErrorRow(dsRet, "CondicionesComercialesMateriales", sKey);
                    }
                }

                if (dsRec.CondicionesComercialesGrupos.Rows.Count > 0)
                {
                    foreach (WSSinCRM.dsCentral.CondicionesComercialesGruposRow rw in dsRec.CondicionesComercialesGrupos.Rows)
                    {
                        sKey = BuildXMLKey(dsRec.CondicionesComercialesGrupos, rw);
                        AddErrorRow(dsRet, "CondicionesComercialesGrupos", sKey);
                    }
                }

                if (dsRec.CondicionesComerciales.Rows.Count > 0)
                {
                    foreach (WSSinCRM.dsCentral.CondicionesComercialesRow rw in dsRec.CondicionesComerciales.Rows)
                    {
                        sKey = BuildXMLKey(dsRec.CondicionesComerciales, rw);
                        AddErrorRow(dsRet, "CondicionesComerciales", sKey);
                    }
                }

                if (dsRec.AccionesMarkCampanyas.Rows.Count > 0)
                {
                    foreach (WSSinCRM.dsCentral.AccionesMarkCampanyasRow rw in dsRec.AccionesMarkCampanyas.Rows)
                    {
                        sKey = BuildXMLKey(dsRec.AccionesMarkCampanyas, rw);
                        AddErrorRow(dsRet, "AccionesMarkCampanyas", sKey);
                    }
                }

                if (dsRec.Costes.Rows.Count > 0)
                {
                    foreach (WSSinCRM.dsCentral.CostesRow rw in dsRec.Costes.Rows)
                    {
                        sKey = BuildXMLKey(dsRec.Costes, rw);
                        AddErrorRow(dsRet, "Costes", sKey);
                    }
                }

                if (dsRec.MinimoUnidadesVenta.Rows.Count > 0)
                {
                    foreach (WSSinCRM.dsCentral.MinimoUnidadesVentaRow rw in dsRec.MinimoUnidadesVenta.Rows)
                    {
                        sKey = BuildXMLKey(dsRec.MinimoUnidadesVenta, rw);
                        AddErrorRow(dsRet, "MinimoUnidadesVenta", sKey);
                    }
                }

                if (dsRec.DescuentoMax.Rows.Count > 0)
                {
                    foreach (WSSinCRM.dsCentral.DescuentoMaxRow rw in dsRec.DescuentoMax.Rows)
                    {
                        sKey = BuildXMLKey(dsRec.DescuentoMax, rw);
                        AddErrorRow(dsRet, "DescuentoMax", sKey);
                    }
                }

                if (dsRec.DirectoZMAY.Rows.Count > 0)
                {
                    foreach (WSSinCRM.dsCentral.DirectoZMAYRow rw in dsRec.DirectoZMAY.Rows)
                    {
                        sKey = BuildXMLKey(dsRec.DirectoZMAY, rw);
                        AddErrorRow(dsRet, "DirectoZMAY", sKey);
                    }
                }

                if (dsRec.CampanyasVisibles.Rows.Count > 0)
                {
                    foreach (WSSinCRM.dsCentral.CampanyasVisiblesRow rw in dsRec.CampanyasVisibles.Rows)
                    {
                        sKey = BuildXMLKey(dsRec.CampanyasVisibles, rw);
                        AddErrorRow(dsRet, "CampanyasVisibles", sKey);
                    }
                }

                if (dsRec.PedAcciones.Rows.Count > 0)
                {
                    foreach (WSSinCRM.dsCentral.PedAccionesRow rw in dsRec.PedAcciones.Rows)
                    {
                        sKey = BuildXMLKey(dsRec.PedAcciones, rw);
                        AddErrorRow(dsRet, "PedAcciones", sKey);
                    }
                }

                if (dsRec.TarjetasCliente.Rows.Count > 0)
                {
                    foreach (WSSinCRM.dsCentral.TarjetasClienteRow rw in dsRec.TarjetasCliente.Rows)
                    {
                        sKey = BuildXMLKey(dsRec.TarjetasCliente, rw);
                        AddErrorRow(dsRet, "TarjetasCliente", sKey);
                    }
                }


                if (dsRec.AccMarkProductos.Rows.Count > 0)
                {
                    foreach (WSSinCRM.dsCentral.AccMarkProductosRow rw in dsRec.AccMarkProductos.Rows)
                    {
                        sKey = BuildXMLKey(dsRec.AccMarkProductos, rw);
                        AddErrorRow(dsRet, "AccMarkProductos", sKey);
                    }
                }

                //---- GSG (26/09/2016)

                if (dsRec.AccMarkRangos.Rows.Count > 0)
                {
                    foreach (WSSinCRM.dsCentral.AccMarkRangosRow rw in dsRec.AccMarkRangos.Rows)
                    {
                        sKey = BuildXMLKey(dsRec.AccMarkRangos, rw);
                        AddErrorRow(dsRet, "AccMarkRangos", sKey);
                    }
                }

                if (dsRec.AccMarkExclusion.Rows.Count > 0)
                {
                    foreach (WSSinCRM.dsCentral.AccMarkExclusionRow rw in dsRec.AccMarkExclusion.Rows)
                    {
                        sKey = BuildXMLKey(dsRec.AccMarkExclusion, rw);
                        AddErrorRow(dsRet, "AccMarkExclusion", sKey);
                    }
                }

                //---- GSG (24/08/2017)

                if (dsRec.GrupoCampanya.Rows.Count > 0)
                {
                    foreach (WSSinCRM.dsCentral.GrupoCampanyaRow rw in dsRec.GrupoCampanya.Rows)
                    {
                        sKey = BuildXMLKey(dsRec.GrupoCampanya, rw);
                        AddErrorRow(dsRet, "GrupoCampanya", sKey);
                    }
                }

                if (dsRec.ReglasGruposCamp.Rows.Count > 0)
                {
                    foreach (WSSinCRM.dsCentral.ReglasGruposCampRow rw in dsRec.ReglasGruposCamp.Rows)
                    {
                        sKey = BuildXMLKey(dsRec.ReglasGruposCamp, rw);
                        AddErrorRow(dsRet, "ReglasGruposCamp", sKey);
                    }
                }

                //---- GSG (05/10/2017)
                if (dsRec.Ubicaciones.Rows.Count > 0)
                {
                    foreach (WSSinCRM.dsCentral.UbicacionesRow rw in dsRec.Ubicaciones.Rows)
                    {
                        sKey = BuildXMLKey(dsRec.Ubicaciones, rw);
                        AddErrorRow(dsRet, "Ubicaciones", sKey);
                    }
                }

                //---- GSG (26/02/2018)
                if (dsRec.DivsPedido.Rows.Count > 0)
                {
                    foreach (WSSinCRM.dsCentral.DivsPedidoRow rw in dsRec.DivsPedido.Rows)
                    {
                        sKey = BuildXMLKey(dsRec.DivsPedido, rw);
                        AddErrorRow(dsRet, "DivsPedido", sKey);
                    }
                }

                //---- GSG (08/05/2019)
                if (dsRec.Componentes.Rows.Count > 0)
                {
                    foreach (WSSinCRM.dsCentral.ComponentesRow rw in dsRec.Componentes.Rows)
                    {
                        sKey = BuildXMLKey(dsRec.Componentes, rw);
                        AddErrorRow(dsRet, "Componentes", sKey);
                    }
                }

                //---- GSG (03/09/2019)
                if (dsRec.SRVYEncuesta.Rows.Count > 0)
                {
                    foreach (WSSinCRM.dsCentral.SRVYEncuestaRow rw in dsRec.SRVYEncuesta.Rows)
                    {
                        sKey = BuildXMLKey(dsRec.SRVYEncuesta, rw);
                        AddErrorRow(dsRet, "SRVYEncuesta", sKey);
                    }
                }

                if (dsRec.SRVYPregunta.Rows.Count > 0)
                {
                    foreach (WSSinCRM.dsCentral.SRVYPreguntaRow rw in dsRec.SRVYPregunta.Rows)
                    {
                        sKey = BuildXMLKey(dsRec.SRVYPregunta, rw);
                        AddErrorRow(dsRet, "SRVYPregunta", sKey);
                    }
                }


                if (dsRec.SRVYRespuesta.Rows.Count > 0)
                {
                    foreach (WSSinCRM.dsCentral.SRVYRespuestaRow rw in dsRec.SRVYRespuesta.Rows)
                    {
                        sKey = BuildXMLKey(dsRec.SRVYRespuesta, rw);
                        AddErrorRow(dsRet, "SRVYRespuesta", sKey);
                    }
                }

                if (dsRec.SRVYClienteEncuesta.Rows.Count > 0)
                {
                    foreach (WSSinCRM.dsCentral.SRVYClienteEncuestaRow rw in dsRec.SRVYClienteEncuesta.Rows)
                    {
                        sKey = BuildXMLKey(dsRec.SRVYClienteEncuesta, rw);
                        AddErrorRow(dsRet, "SRVYClienteEncuesta", sKey);
                    }
                }

                if (dsRec.SRVYClienteRespuesta.Rows.Count > 0)
                {
                    foreach (WSSinCRM.dsCentral.SRVYClienteRespuestaRow rw in dsRec.SRVYClienteRespuesta.Rows)
                    {
                        sKey = BuildXMLKey(dsRec.SRVYClienteRespuesta, rw);
                        AddErrorRow(dsRet, "SRVYClienteRespuesta", sKey);
                    }
                }


                //---- GSG (06/03/2021
                if (dsRec.GrupoHomogeneo.Rows.Count > 0)
                {
                    foreach (WSSinCRM.dsCentral.GrupoHomogeneoRow rw in dsRec.GrupoHomogeneo.Rows)
                    {
                        sKey = BuildXMLKey(dsRec.GrupoHomogeneo, rw);
                        AddErrorRow(dsRet, "GrupoHomogeneo", sKey);
                    }
                }


                //---- GSG (03/01/2023)
                if (dsRec.MaterialesBloqueoDescuento.Rows.Count > 0)
                {
                    foreach (WSSinCRM.dsCentral.MaterialesBloqueoDescuentoRow rw in dsRec.MaterialesBloqueoDescuento.Rows)
                    {
                        sKey = BuildXMLKey(dsRec.MaterialesBloqueoDescuento, rw);
                        AddErrorRow(dsRet, "MaterialesBloqueoDescuento", sKey);
                    }
                }

           




                #endregion

            }
            finally
			{
				if (this.sqlConn.State == System.Data.ConnectionState.Open) this.sqlConn.Close();
			}

			return dsRet;
		}
		
        private WSSinCRM.dsRetorno ActualizaClientes(WSSinCRM.dsCentral dsRec )
		{
			string sElemento="";
			WSSinCRM.dsRetorno dsRet = new WSSinCRM.dsRetorno();

			string sKey = "";
			try
			{
				if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();

				#region Centros
				if (dsRec.Centros.Rows.Count >0  )
				{

					AddDefRow(dsRet,"Centros","dFUM","dFUM",false,true);
					foreach(WSSinCRM.dsCentral.CentrosRow rwCen in dsRec.Centros.Rows)
					{
						try
						{
							sKey = BuildXMLKey(dsRec.Centros,rwCen);

							sElemento="Centro " + rwCen.iIdCentro.ToString();
							sqlCmdUpdCentros.Parameters["@iIdCentro"].Value = rwCen.iIdCentro ;
							sqlCmdUpdCentros.Parameters["@sIdCentro"].Value = rwCen.sIdCentro ;
							sqlCmdUpdCentros.Parameters["@sIdCentroTemp"].Value = rwCen.sIdCentroTemp ;
							sqlCmdUpdCentros.Parameters["@sIdTipoCentro"].Value = rwCen.IssIdTipoCentroNull()?SqlString.Null:rwCen.sIdTipoCentro ;
							sqlCmdUpdCentros.Parameters["@sDescripcion"].Value = rwCen.sDescripcion ;
							sqlCmdUpdCentros.Parameters["@sDireccion"].Value = rwCen.sDireccion ;
							sqlCmdUpdCentros.Parameters["@iIdPoblacion"].Value = rwCen.iIdPoblacion ;
							sqlCmdUpdCentros.Parameters["@sFax"].Value = rwCen.IssFaxNull()?SqlString.Null:rwCen.sFax ;
							sqlCmdUpdCentros.Parameters["@sTelefono"].Value = rwCen.IssTelefonoNull()?SqlString.Null:rwCen.sTelefono ;
							sqlCmdUpdCentros.Parameters["@sIdPolPrescripcion"].Value = rwCen.IssIdPolPrescripcionNull()?SqlString.Null:rwCen.sIdPolPrescripcion ;
							sqlCmdUpdCentros.Parameters["@sIdTipoClasificacion"].Value = rwCen.IssIdTipoClasificacionNull()?SqlString.Null:rwCen.sIdTipoClasificacion ;
							sqlCmdUpdCentros.Parameters["@sIdSistInformatico"].Value = rwCen.IssIdSistInformaticoNull()?SqlString.Null:rwCen.sIdSistInformatico ;
							sqlCmdUpdCentros.Parameters["@bPactoPrescripcion"].Value = rwCen.bPactoPrescripcion ;
							sqlCmdUpdCentros.Parameters["@bVisitaColectiva"].Value = rwCen.bVisitaColectiva ;
							sqlCmdUpdCentros.Parameters["@dFUM"].Value = rwCen.dFUM ;
							sqlCmdUpdCentros.Parameters["@iEstado"].Value = rwCen.iEstado ;

							sqlCmdUpdCentros.ExecuteNonQuery();
						}
						catch
						{
							AddErrorRow(dsRet,"Centros",sKey);
						}
						UpdatePaso();
					}
				}
				#endregion
				UpdatePaso();
					
				#region CentrosRedes
				if (dsRec.CentrosRedes.Rows.Count >0  )
				{
					AddDefRow(dsRet,"CentrosRedes","dFUM","dFUM",false,true);
					//AddDefRow(dsRet,"CentrosRedes","dFAR","dFAR",false,true);
					foreach(WSSinCRM.dsCentral.CentrosRedesRow rwCR in dsRec.CentrosRedes.Rows ) 
					{
						try
						{
							sKey = BuildXMLKey(dsRec.CentrosRedes,rwCR);
							sElemento="CentrosRedes " + rwCR.iIdCentro.ToString();
							this.sqlCmdUpdCentrosRedes.Parameters["@iIdCentro"].Value = rwCR.iIdCentro;
							this.sqlCmdUpdCentrosRedes.Parameters["@sIdRed"].Value = rwCR.sIdRed;
							this.sqlCmdUpdCentrosRedes.Parameters["@dFAR"].Value = SqlDateTime.Null;
							this.sqlCmdUpdCentrosRedes.Parameters["@dFBR"].Value = rwCR.IsdFBRNull()?SqlDateTime.Null:rwCR.dFBR;
							this.sqlCmdUpdCentrosRedes.Parameters["@iEstado"].Value = rwCR.iEstado;
							this.sqlCmdUpdCentrosRedes.Parameters["@dFUM"].Value = rwCR.dFUM;

							sqlCmdUpdCentrosRedes.ExecuteNonQuery();
						}
						catch
						{
							AddErrorRow(dsRet,"CentrosRedes",sKey);
						}

					}


				}
				#endregion
				UpdatePaso();
					
				#region Clientes
				if (dsRec.Clientes!=null && dsRec.Clientes.Rows.Count>0)
				{
					AddDefRow(dsRet,"Clientes","dFUM","dFUM",false,true);
					foreach (WSSinCRM.dsCentral.ClientesRow rwCli in dsRec.Clientes.Rows)
					{
						try
						{
							sKey = BuildXMLKey(dsRec.Clientes,rwCli);

							sElemento="Cliente " + rwCli.iIdCliente.ToString();
							sqlCmdUpdClientes.Parameters["@iIdCliente"].Value = rwCli.iIdCliente;
                            sqlCmdUpdClientes.Parameters["@sIdCliente"].Value = rwCli.sIdCliente;
                            sqlCmdUpdClientes.Parameters["@sTipoCliente"].Value = rwCli.IssTipoClienteNull() ? SqlString.Null : rwCli.sTipoCliente;
                            sqlCmdUpdClientes.Parameters["@sIdClienteTemp"].Value = rwCli.IssIdClienteTempNull() ? SqlString.Null : rwCli.sIdClienteTemp;
                            sqlCmdUpdClientes.Parameters["@sNombre"].Value = rwCli.IssNombreNull() ? SqlString.Null : rwCli.sNombre;
                            sqlCmdUpdClientes.Parameters["@sApellidos1"].Value = rwCli.IssApellidos1Null() ? SqlString.Null : rwCli.sApellidos1;
                            sqlCmdUpdClientes.Parameters["@sApellidos2"].Value = rwCli.IssApellidos2Null() ? SqlString.Null : rwCli.sApellidos2;
                            sqlCmdUpdClientes.Parameters["@sTelefono"].Value = rwCli.IssTelefonoNull() ? SqlString.Null : rwCli.sTelefono;
                            sqlCmdUpdClientes.Parameters["@iEstado"].Value = rwCli.iEstado;
                            sqlCmdUpdClientes.Parameters["@dFUM"].Value = rwCli.dFUM;

                            sqlCmdUpdClientes.ExecuteNonQuery();
							UpdatePaso();
						}
						catch
						{
							AddErrorRow(dsRet,"Clientes",sKey);
						}
					}
				}
				#endregion
				UpdatePaso();
					
				#region ClientesRedes
				if (dsRec.ClientesRedes!=null && dsRec.ClientesRedes.Rows.Count>0)
				{
					AddDefRow(dsRet,"ClientesRedes","dFUM","dFUM",false,true);
					//AddDefRow(dsRet,"ClientesRedes","dFAR","dFAR",false,true);
					foreach(WSSinCRM.dsCentral.ClientesRedesRow rwCLR in dsRec.ClientesRedes.Rows)
					{
						try
						{
							sKey = BuildXMLKey(dsRec.ClientesRedes,rwCLR);

							sElemento="ClientesRedes " + rwCLR.iIdCliente.ToString();
							sqlCmdUpdClientesRedes.Parameters["@iIdCliente"].Value = rwCLR.iIdCliente;
							sqlCmdUpdClientesRedes.Parameters["@sIdRed"].Value = rwCLR.sIdRed;
							sqlCmdUpdClientesRedes.Parameters["@sIdClasificacion"].Value = !rwCLR.IssIdClasificacionNull()?rwCLR.sIdClasificacion:System.Data.SqlTypes.SqlString.Null;
							sqlCmdUpdClientesRedes.Parameters["@dFAR"].Value = SqlDateTime.Null;
							sqlCmdUpdClientesRedes.Parameters["@dFBR"].Value = rwCLR.IsdFBRNull()?SqlDateTime.Null:rwCLR.dFBR;
							sqlCmdUpdClientesRedes.Parameters["@iEstado"].Value = rwCLR.iEstado ;
							sqlCmdUpdClientesRedes.Parameters["@dFUM"].Value = rwCLR.dFUM;

							sqlCmdUpdClientesRedes.ExecuteNonQuery();
						}
						catch (Exception E)
						{
							AddErrorRow(dsRet,"ClientesRedes",sKey);
						}
					}
				}
				#endregion
				UpdatePaso();
					
				#region BrickClientes
				if (dsRec.BrickClientes!=null && dsRec.BrickClientes.Rows.Count>0)
				{
					AddDefRow(dsRet,"BrickClientes","dFBR","dFBR",false,true);
					AddDefRow(dsRet,"BrickClientes","dFAR","dFAR",false,true);
					foreach(WSSinCRM.dsCentral.BrickClientesRow rwBrcl in dsRec.BrickClientes.Rows)
					{

						try
						{
							sKey = BuildXMLKey(dsRec.BrickClientes,rwBrcl);

							sElemento="BrickCliente " + rwBrcl.iIdCliente.ToString();
							sqlCmdUpdBrickClientes.Parameters["@iIdCliente"].Value = rwBrcl.iIdCliente;
							sqlCmdUpdBrickClientes.Parameters["@sIdBrick"].Value = rwBrcl.sIdBrick;
							sqlCmdUpdBrickClientes.Parameters["@dFAR"].Value = SqlDateTime.Null;
							sqlCmdUpdBrickClientes.Parameters["@dFBR"].Value = rwBrcl.IsdFBRNull()?SqlDateTime.Null:rwBrcl .dFBR;
							sqlCmdUpdBrickClientes.Parameters["@iEstado"].Value = rwBrcl.iEstado ;
							sqlCmdUpdBrickClientes.Parameters["@dFUM"].Value = rwBrcl.dFUM;

							sqlCmdUpdBrickClientes.ExecuteNonQuery();
						
						}
						catch
						{
							AddErrorRow(dsRet,"BrickClientes",sKey);
						}
					}
				}
				#endregion
				UpdatePaso();
					
				#region CPCLientes
				if (dsRec.CPClientes!=null && dsRec.CPClientes.Rows.Count>0)
				{
					AddDefRow(dsRet,"CPCLientes","dFUM","dFUM",false,true);
					//AddDefRow(dsRet,"CPCLientes","dFAR","dFAR",false,true);
					foreach(WSSinCRM.dsCentral.CPClientesRow rwCPcl in dsRec.CPClientes.Rows)  
					{
						try
						{
							sKey = BuildXMLKey(dsRec.CPClientes,rwCPcl);

							sElemento="CPCliente " + rwCPcl.iIdCliente.ToString();
							sqlCmdUpdCPCLientes.Parameters["@iIdCliente"].Value = rwCPcl.iIdCliente;
							sqlCmdUpdCPCLientes.Parameters["@sCodPostal"].Value = rwCPcl.sCodPostal; 
							sqlCmdUpdCPCLientes.Parameters["@dFAR"].Value = SqlDateTime.Null;
							sqlCmdUpdCPCLientes.Parameters["@dFBR"].Value = rwCPcl.IsdFBRNull()?SqlDateTime.Null:rwCPcl.dFBR;
							sqlCmdUpdCPCLientes.Parameters["@iEstado"].Value = rwCPcl.iEstado;

							sqlCmdUpdCPCLientes.ExecuteNonQuery();
						}
						catch
						{
							AddErrorRow(dsRet,"CPCLientes",sKey);
						}
					}
				}
				#endregion
				UpdatePaso();
					
				#region AccionesMarkClientes
				if (dsRec.AccionesMarkClientes!=null && dsRec.AccionesMarkClientes.Rows.Count>0)
				{
					AddDefRow(dsRet,"AccionesMarkClientes","dFUM","dFUM",false,true);
					foreach(WSSinCRM.dsCentral.AccionesMarkClientesRow rwAcc in dsRec.AccionesMarkClientes.Rows)
					{
						try
						{
							sElemento="AccionesMarkCliente " + rwAcc.iIdCliente.ToString();

							sKey = BuildXMLKey(dsRec.AccionesMarkClientes,rwAcc);

							this.sqlCmdUpdAccionesMarkClientes.Parameters["@iIdAccion"].Value = rwAcc.iIdAccion ;
							this.sqlCmdUpdAccionesMarkClientes.Parameters["@iIdCliente"].Value = rwAcc.iIdCliente ;
							this.sqlCmdUpdAccionesMarkClientes.Parameters["@dFechaEntrega"].Value = rwAcc.dFechaEntrega ;
							this.sqlCmdUpdAccionesMarkClientes.Parameters["@fCantidad"].Value = rwAcc.fCantidad ;
							this.sqlCmdUpdAccionesMarkClientes.Parameters["@tObservaciones"].Value = rwAcc.IstObservacionesNull()?SqlString.Null:rwAcc.tObservaciones ;
							this.sqlCmdUpdAccionesMarkClientes.Parameters["@sCCoste"].Value = rwAcc.IssCCosteNull()?SqlString.Null:rwAcc.sCCoste ;
							this.sqlCmdUpdAccionesMarkClientes.Parameters["@dFUM"].Value = rwAcc.dFUM;
							this.sqlCmdUpdAccionesMarkClientes.Parameters["@iEstado"].Value = rwAcc.iEstado;
							this.sqlCmdUpdAccionesMarkClientes.Parameters["@iIdDelegado"].Value = rwAcc.IsiIdDelegadoNull()?System.Data.SqlTypes.SqlInt32.Null:rwAcc.iIdDelegado;

							this.sqlCmdUpdAccionesMarkClientes.ExecuteNonQuery();
						}
						catch
						{
							AddErrorRow(dsRet,dsRec.AccionesMarkClientes.TableName,sKey);
						}
					}
				}
				#endregion
				UpdatePaso();
					
				#region ClientesSAP
				if (dsRec.Clientes_SAP!=null && dsRec.Clientes_SAP.Rows.Count>0)
				{
					AddDefRow(dsRet,"Clientes","dFUM","dFUM",false,true);
					foreach(WSSinCRM.dsCentral.Clientes_SAPRow rwCSAP in dsRec.Clientes_SAP.Rows)
					{
						try
						{
							sElemento="ClienteSAP " + rwCSAP.iIdCliente.ToString();
							sKey = BuildXMLKey(dsRec.Clientes_SAP,rwCSAP);

							sqlCmdUpdClientesSAP.Parameters["@iIdCliente"].Value = rwCSAP.iIdCliente;
							sqlCmdUpdClientesSAP.Parameters["@sNIF"].Value = rwCSAP.IssNIFNull()?SqlString.Null:rwCSAP.sNIF;
							sqlCmdUpdClientesSAP.Parameters["@sDatosBancarios"].Value = rwCSAP.IssDatosBancariosNull()?SqlString.Null:rwCSAP.sDatosBancarios;
							sqlCmdUpdClientesSAP.Parameters["@sDireccion"].Value = rwCSAP.IssDireccionNull()?SqlString.Null:rwCSAP.sDireccion;
							sqlCmdUpdClientesSAP.Parameters["@sPoblacion"].Value = rwCSAP.IssPoblacionNull()?SqlString.Null:rwCSAP.sPoblacion;
							sqlCmdUpdClientesSAP.Parameters["@sCP"].Value = rwCSAP.sCP; 
							sqlCmdUpdClientesSAP.Parameters["@sPais"].Value = rwCSAP.sPais;
							sqlCmdUpdClientesSAP.Parameters["@sRegion"].Value = rwCSAP.IssRegionNull()?SqlString.Null:rwCSAP.sRegion;
							sqlCmdUpdClientesSAP.Parameters["@sTeles"].Value = rwCSAP.IssTelesNull()?SqlString.Null:rwCSAP.sTeles;
							sqlCmdUpdClientesSAP.Parameters["@sTelefono2"].Value = rwCSAP.IssTelefono2Null()?SqlString.Null:rwCSAP.sTelefono2;
							sqlCmdUpdClientesSAP.Parameters["@sTelefax"].Value = rwCSAP.IssTelefaxNull()?SqlString.Null:rwCSAP.sTelefax;
							sqlCmdUpdClientesSAP.Parameters["@sCodPago"].Value = rwCSAP.IssCodPagoNull()?SqlString.Null:rwCSAP.sCodPago;
							sqlCmdUpdClientesSAP.Parameters["@sZonaCliente"].Value = rwCSAP.IssZonaClienteNull()?SqlString.Null:rwCSAP.sZonaCliente;
							sqlCmdUpdClientesSAP.Parameters["@sOficinaVentas"].Value = rwCSAP.IssOficinaVentasNull()?SqlString.Null:rwCSAP.sOficinaVentas;
							sqlCmdUpdClientesSAP.Parameters["@sGrupoVendedores"].Value = rwCSAP.IssGrupoVendedoresNull()?SqlString.Null:rwCSAP.sGrupoVendedores;
							sqlCmdUpdClientesSAP.Parameters["@sGrupoClientes"].Value = rwCSAP.IssGrupoClientesNull()?SqlString.Null:rwCSAP.sGrupoClientes;
							sqlCmdUpdClientesSAP.Parameters["@sOrgVentas"].Value = rwCSAP.IssOrgVentasNull()?SqlString.Null:rwCSAP.sOrgVentas;
							sqlCmdUpdClientesSAP.Parameters["@sSector"].Value = rwCSAP.IssSectorNull()?SqlString.Null:rwCSAP.sSector;
							sqlCmdUpdClientesSAP.Parameters["@sCanal"].Value = rwCSAP.IssCanalNull()?SqlString.Null:rwCSAP.sCanal;
							sqlCmdUpdClientesSAP.Parameters["@sMoneda"].Value = rwCSAP.IssMonedaNull()?SqlString.Null:rwCSAP.sMoneda;
							sqlCmdUpdClientesSAP.Parameters["@sCondExp"].Value = rwCSAP.IssCondExpNull()?SqlString.Null:rwCSAP.sCondExp;
							sqlCmdUpdClientesSAP.Parameters["@sCentroSuministro"].Value = rwCSAP.IssCentroSuministroNull()?SqlString.Null:rwCSAP.sCentroSuministro;
							sqlCmdUpdClientesSAP.Parameters["@sIncoterms1"].Value = rwCSAP.IssIncoterms1Null()?SqlString.Null:rwCSAP.sIncoterms1;
							sqlCmdUpdClientesSAP.Parameters["@sIncoterms2"].Value = rwCSAP.IssIncoterms2Null()?SqlString.Null:rwCSAP.sIncoterms2;
							sqlCmdUpdClientesSAP.Parameters["@sAreaControlCred"].Value = rwCSAP.IssAreaControlCredNull()?SqlString.Null:rwCSAP.sAreaControlCred;
							sqlCmdUpdClientesSAP.Parameters["@sGarantias"].Value = rwCSAP.IssGarantiasNull()?SqlString.Null:rwCSAP.sGarantias;
							sqlCmdUpdClientesSAP.Parameters["@sEncComercial"].Value = rwCSAP.IssEncComercialNull()?SqlString.Null:rwCSAP.sEncComercial;
							sqlCmdUpdClientesSAP.Parameters["@sRespPedido"].Value = rwCSAP.IssRespPedidoNull()?SqlString.Null:rwCSAP.sRespPedido;
							sqlCmdUpdClientesSAP.Parameters["@sCiaTransporte"].Value = rwCSAP.IssCiaTransporteNull()?SqlString.Null:rwCSAP.sCiaTransporte;
							sqlCmdUpdClientesSAP.Parameters["@fDescuento"].Value = rwCSAP.fDescuento;
							sqlCmdUpdClientesSAP.Parameters["@fBonificacion"].Value = rwCSAP.fBonificacion;
							sqlCmdUpdClientesSAP.Parameters["@fRappel"].Value = rwCSAP.fRappel;
							sqlCmdUpdClientesSAP.Parameters["@sTR"].Value = rwCSAP.IssTRNull()?SqlString.Null:rwCSAP.sTR;
							sqlCmdUpdClientesSAP.Parameters["@bPotencial"].Value = rwCSAP.bPotencial;
							//CAR
							sqlCmdUpdClientesSAP.Parameters["@sGarantias_1"].Value = rwCSAP.IssGarantias_1Null() ? SqlString.Null : rwCSAP.sGarantias_1;
							sqlCmdUpdClientesSAP.Parameters["@sGarantias_2"].Value = rwCSAP.IssGarantias_2Null() ? SqlString.Null : rwCSAP.sGarantias_2;
							sqlCmdUpdClientesSAP.Parameters["@sGarantias_3"].Value = rwCSAP.IssGarantias_3Null() ? SqlString.Null : rwCSAP.sGarantias_3;
							sqlCmdUpdClientesSAP.Parameters["@sGarantias_4"].Value = rwCSAP.IssGarantias_4Null() ? SqlString.Null : rwCSAP.sGarantias_4;
                            //---- GSG (18/09/2012)
                            sqlCmdUpdClientesSAP.Parameters["@fDeudaVenc"].Value = rwCSAP.fDeudaVenc;
                            //---- GSG (20/11/2013)
                            sqlCmdUpdClientesSAP.Parameters["@sEmailConf"].Value = rwCSAP.IssEmailConfNull() ? SqlString.Null : rwCSAP.sEmailConf;
                            sqlCmdUpdClientesSAP.Parameters["@sEmailFact"].Value = rwCSAP.IssEmailFactNull() ? SqlString.Null : rwCSAP.sEmailFact;  
                            //---- GSG (17/10/2014)
                            sqlCmdUpdClientesSAP.Parameters["@sSWIFT"].Value = rwCSAP.IssSWIFTNull() ? SqlString.Null : rwCSAP.sSWIFT;
                            //---- GSG (05/10/2017)
                            sqlCmdUpdClientesSAP.Parameters["@idUbicacion"].Value = rwCSAP.idUbicacion;

                            sqlCmdUpdClientesSAP.ExecuteNonQuery();
							UpdatePaso();
						}
						catch (Exception e)
						{
							AddErrorRow(dsRet,"Clientes_SAP",sKey);
						}

					}
				}
				#endregion
				UpdatePaso();
				
	           
				#region ContactosClientes_SAP
                
                if (dsRec.ContactosClientes_SAP != null && dsRec.ContactosClientes_SAP.Rows.Count > 0)
                {
                    AddDefRow(dsRet, "ContactosClientes_SAP", "dFUM", "dFUM", false, true);
                    //AddDefRow(dsRet,"ContactosClientes_SAP","dFAR","dFAR",false,true);
                    foreach (WSSinCRM.dsCentral.ContactosClientes_SAPRow rwCoSAP in dsRec.ContactosClientes_SAP.Rows)
                    {
                        try
                        {
                            sKey = BuildXMLKey(dsRec.ContactosClientes_SAP, rwCoSAP);

                            sElemento = "ContactoClienteSAP " + rwCoSAP.iIdCliente.ToString();
                            sqlCmdUpdContactosClientesSAP.Parameters["@iIdCliente"].Value = rwCoSAP.iIdCliente;
                            sqlCmdUpdContactosClientesSAP.Parameters["@iIdContacto"].Value = rwCoSAP.iIdContacto;
                            sqlCmdUpdContactosClientesSAP.Parameters["@sNombre"].Value = rwCoSAP.sNombre;
                            sqlCmdUpdContactosClientesSAP.Parameters["@sIdCargoContacto"].Value = rwCoSAP.IssIdCargoContactoNull() ? SqlString.Null : rwCoSAP.sIdCargoContacto;
                            //---- GSG (10/05/2011)
                            //sqlCmdUpdContactosClientesSAP.Parameters["@dFAR"].Value = SqlDateTime.Null;
                            sqlCmdUpdContactosClientesSAP.Parameters["@dFAR"].Value = rwCoSAP.IsdFARNull() ? SqlString.Null : rwCoSAP.dFAR;
                            //---- FI GSG
                            sqlCmdUpdContactosClientesSAP.Parameters["@dFBR"].Value = rwCoSAP.IsdFBRNull() ? SqlDateTime.Null : rwCoSAP.dFBR;
                            sqlCmdUpdContactosClientesSAP.Parameters["@iEstado"].Value = rwCoSAP.iestado;
                            sqlCmdUpdContactosClientesSAP.Parameters["@dFUM"].Value = rwCoSAP.dFUM;
                            sqlCmdUpdContactosClientesSAP.Parameters["@sSWIFT"].Value = rwCoSAP.IssSWIFTNull() ? SqlString.Null : rwCoSAP.sSWIFT; //---- GSG (17/10/2014)

                            sqlCmdUpdContactosClientesSAP.ExecuteNonQuery();
                        }
                        catch
                        {
                            AddErrorRow(dsRet, "ContactosClientes_SAP", sKey);
                        }

                    }
                }
                
				#endregion
				UpdatePaso();
					
				#region CentrosClientesSAP
				if (dsRec.CentrosClientes_SAP!=null && dsRec.CentrosClientes_SAP.Rows.Count>0)
				{
					AddDefRow(dsRet,"CentrosClientes_SAP","dFUM","dFUM",false,true);
					//AddDefRow(dsRet,"CentrosClientes_SAP","dFAR","dFAR",false,true);
					foreach(WSSinCRM.dsCentral.CentrosClientes_SAPRow rwCeSAP in dsRec.CentrosClientes_SAP.Rows)
					{
						try
						{
							sElemento="CentroClienteSAP " + rwCeSAP.iIdCliente.ToString();

							sKey = BuildXMLKey(dsRec.CentrosClientes_SAP,rwCeSAP);

							sqlCmdUpdCentrosClientesSAP.Parameters["@iIdCliente"].Value = rwCeSAP.iIdCliente ;
							sqlCmdUpdCentrosClientesSAP.Parameters["@iIdCentro"].Value = rwCeSAP.iIdCentro ;
							sqlCmdUpdCentrosClientesSAP.Parameters["@dFAR"].Value = SqlDateTime.Null ;
							sqlCmdUpdCentrosClientesSAP.Parameters["@dFBR"].Value = rwCeSAP.IsdFBRNull()?SqlDateTime.Null:rwCeSAP.dFBR ;
							sqlCmdUpdCentrosClientesSAP.Parameters["@iEstado"].Value = rwCeSAP.iEstado ;
							sqlCmdUpdCentrosClientesSAP.Parameters["@dFUM"].Value = rwCeSAP.dFUM ;

							sqlCmdUpdCentrosClientesSAP.ExecuteNonQuery();
						}
						catch
						{
							AddErrorRow(dsRet,"CentrosClientes_SAP",sKey);
						}

					}
				}
				#endregion
				UpdatePaso();
				#region InterlocutoresClientesSAP
				if (dsRec.InterlocutorClientes_SAP!=null && dsRec.InterlocutorClientes_SAP.Rows.Count >0  )
				{
					AddDefRow(dsRet,"InterlocutorClientes_SAP","dFUM","dFUM",false,true);
					//AddDefRow(dsRet,"InterlocutorClientes_SAP","dFAR","dFAR",false,true);
					foreach(WSSinCRM.dsCentral.InterlocutorClientes_SAPRow rwISAP in dsRec.InterlocutorClientes_SAP.Rows)
					{
						try
						{
							sKey = BuildXMLKey(dsRec.InterlocutorClientes_SAP,rwISAP);
							sElemento="InterlocutorSAP " + rwISAP.iIdInterlocutor.ToString();
							sqlCmdUpdInterlocutorClienteSAP.Parameters["@iIdInterlocutor"].Value = rwISAP.iIdInterlocutor ;
							sqlCmdUpdInterlocutorClienteSAP.Parameters["@iIdCliente"].Value = rwISAP.iIdCliente ;
							sqlCmdUpdInterlocutorClienteSAP.Parameters["@sIdCodClientedelMay"].Value = rwISAP.IssIdCodClientedelMayNull()?SqlString.Null:rwISAP.sIdCodClientedelMay ;
							sqlCmdUpdInterlocutorClienteSAP.Parameters["@dFAR"].Value = SqlDateTime.Null ;
							sqlCmdUpdInterlocutorClienteSAP.Parameters["@dFBR"].Value = rwISAP.IsdFBRNull()?SqlDateTime.Null:rwISAP.dFBR ;
							sqlCmdUpdInterlocutorClienteSAP.Parameters["@iEstado"].Value = rwISAP.iEstado ;
							sqlCmdUpdInterlocutorClienteSAP.Parameters["@dFUM"].Value = rwISAP.dFUM;

							sqlCmdUpdInterlocutorClienteSAP.ExecuteNonQuery();
						}
						catch
						{
							AddErrorRow(dsRet,dsRec.InterlocutorClientes_SAP.TableName,sKey);
						}

					}
				}
				#endregion
				UpdatePaso();
				#region ClientesCOM
				if (dsRec.Clientes_COM!=null && dsRec.Clientes_COM.Rows.Count>0)
				{
					AddDefRow(dsRet,"Clientes_COM","dFUM","dFUM",false,true);
					foreach(WSSinCRM.dsCentral.Clientes_COMRow rwCCOM in dsRec.Clientes_COM.Rows)
					{
						try
						{
							sElemento="ClienteCOM " + rwCCOM.iIdCliente.ToString();

							sKey = BuildXMLKey(dsRec.Clientes_COM,rwCCOM);

							sqlCmdUpdClientesCOM.Parameters["@iIdCliente"].Value = rwCCOM.iIdCliente;
							sqlCmdUpdClientesCOM.Parameters["@sTipoCliente_COM"].Value = rwCCOM.IssTipoCliente_COMNull()?SqlString.Null:rwCCOM.sTipoCliente_COM;
							sqlCmdUpdClientesCOM.Parameters["@sNumColegiado"].Value = rwCCOM.IssNumColegiadoNull()?SqlString.Null:rwCCOM.sNumColegiado ;
							sqlCmdUpdClientesCOM.Parameters["@tObservaciones"].Value = rwCCOM.IstObservacionesNull()?SqlString.Null:rwCCOM.tObservaciones ;
							sqlCmdUpdClientesCOM.Parameters["@sEMail"].Value = rwCCOM.IssEMailNull()?SqlString.Null:rwCCOM.sEMail ;
							sqlCmdUpdClientesCOM.Parameters["@sFax"].Value = rwCCOM.IssFaxNull()?SqlString.Null:rwCCOM.sFax ;
							sqlCmdUpdClientesCOM.Parameters["@sTelMovil"].Value = rwCCOM.IssTelMovilNull()?SqlString.Null:rwCCOM.sTelMovil ;
							sqlCmdUpdClientesCOM.Parameters["@sDireccion"].Value = rwCCOM.IssDireccionNull()?SqlString.Null:rwCCOM.sDireccion ;
							sqlCmdUpdClientesCOM.Parameters["@iIdPoblacion"].Value = rwCCOM.IsiIdPoblacionNull()?SqlInt32.Null:rwCCOM.iIdPoblacion ;
							sqlCmdUpdClientesCOM.Parameters["@dFecNacimiento"].Value = rwCCOM.IsdFecNacimientoNull()?SqlDateTime.Null:rwCCOM.dFecNacimiento ;
							sqlCmdUpdClientesCOM.Parameters["@dFecAniversario"].Value = rwCCOM.IsdFecAniversarioNull()?SqlDateTime.Null:rwCCOM.dFecAniversario ;
							sqlCmdUpdClientesCOM.Parameters["@sNIF"].Value = rwCCOM.IssNIFNull()?SqlString.Null:rwCCOM.sNIF;
							sqlCmdUpdClientesCOM.Parameters["@bAsignado"].Value = rwCCOM.bAsignado ;
							sqlCmdUpdClientesCOM.Parameters["@bOcasional"].Value = rwCCOM.bOcasional ;
							sqlCmdUpdClientesCOM.Parameters["@dFUM"].Value = rwCCOM.dFUM;

							sqlCmdUpdClientesCOM.ExecuteNonQuery();
						}
						catch
						{
							AddErrorRow(dsRet,dsRec.Clientes_COM.TableName,sKey);
						}
					}
				}
				#endregion
				UpdatePaso();
				#region EspecClientesCOM
				if (dsRec.EspecClientes_COM!=null && dsRec.EspecClientes_COM.Rows.Count>0)
				{
					AddDefRow(dsRet,"EspecCLientes_COM","dFUM","dFUM",false,true);
					foreach(WSSinCRM.dsCentral.EspecClientes_COMRow rwEsp in dsRec.EspecClientes_COM.Rows)
					{
						try
						{
							sElemento="EspecClienteCOM " + rwEsp.iIdCliente.ToString();

							sKey = BuildXMLKey(dsRec.EspecClientes_COM,rwEsp);

							this.sqlCmdUpdEspecClientesCOM.Parameters["@iIdCliente"].Value = rwEsp.iIdCliente; 
							this.sqlCmdUpdEspecClientesCOM.Parameters["@sIdEspecialidad"].Value = rwEsp.sIdEspecialidad;
							this.sqlCmdUpdEspecClientesCOM.Parameters["@dFUM"].Value = rwEsp.dFUM;
							this.sqlCmdUpdEspecClientesCOM.Parameters["@iEstado"].Value = rwEsp.iEstado;

							sqlCmdUpdEspecClientesCOM.ExecuteNonQuery();
						}
						catch
						{
							AddErrorRow(dsRet,dsRec.EspecClientes_COM.TableName,sKey);
						}

					}
				}
				#endregion
				UpdatePaso();
				#region AficClientesCOM
				if (dsRec.AficClientes_COM!=null && dsRec.AficClientes_COM.Rows.Count>0)
				{
					AddDefRow(dsRet,"AficClientes_COM","dFUM","dFUM",false,true);
					foreach(WSSinCRM.dsCentral.AficClientes_COMRow  rwAf in dsRec.AficClientes_COM.Rows)
					{
						try
						{
							sElemento="AficClienteCOM " + rwAf.iIdCliente.ToString();

							sKey = BuildXMLKey(dsRec.AficClientes_COM,rwAf);

							this.sqlCmdUpdAficClientesCOM.Parameters["@iIdCliente"].Value = rwAf.iIdCliente; 
							this.sqlCmdUpdAficClientesCOM.Parameters["@sIdAficion"].Value = rwAf.sIdAficion; 
							this.sqlCmdUpdAficClientesCOM.Parameters["@dFUM"].Value = rwAf.dFUM;
							this.sqlCmdUpdAficClientesCOM.Parameters["@iEstado"].Value = rwAf.iEstado;

							sqlCmdUpdAficClientesCOM.ExecuteNonQuery();
						}
						catch
						{
							AddErrorRow(dsRet,dsRec.AficClientes_COM.TableName,sKey);
						}

					}
				}
				#endregion
				UpdatePaso();
				#region CentrosClientesCOM
				if (dsRec.CentrosClientes_COM!=null && dsRec.CentrosClientes_COM.Rows.Count>0)
				{
					AddDefRow(dsRet,"CentrosClientes_COM","dFUM","dFUM",false,true);
					//AddDefRow(dsRet,"CentrosClientes_COM","dFAR","dFAR",false,true);
					foreach(WSSinCRM.dsCentral.CentrosClientes_COMRow rwCeCOM in dsRec.CentrosClientes_COM.Rows)
					{
						try
						{
							sElemento="CentroClienteCOM " + rwCeCOM.iIdCliente.ToString();

							sKey = BuildXMLKey(dsRec.CentrosClientes_COM,rwCeCOM);

							this.sqlCmdUpdCentrosClientesCOM.Parameters["@iIdCliente"].Value = rwCeCOM.iIdCliente ;
							this.sqlCmdUpdCentrosClientesCOM.Parameters["@iIdCentro"].Value = rwCeCOM.iIdCentro ;
							this.sqlCmdUpdCentrosClientesCOM.Parameters["@sIdTipoRelacionCliCen"].Value = rwCeCOM.IssIdTipoRelacionCliCenNull()?SqlString.Null:rwCeCOM.sIdTipoRelacionCliCen ;
							this.sqlCmdUpdCentrosClientesCOM.Parameters["@dFAR"].Value = SqlDateTime.Null ;
							this.sqlCmdUpdCentrosClientesCOM.Parameters["@dFBR"].Value = rwCeCOM.IsdFBRNull()?SqlDateTime.Null:rwCeCOM.dFBR;
							this.sqlCmdUpdCentrosClientesCOM.Parameters["@iEstado"].Value = rwCeCOM.iEstado ;
							this.sqlCmdUpdCentrosClientesCOM.Parameters["@sIdRed"].Value = rwCeCOM.sIdRed;
							this.sqlCmdUpdCentrosClientesCOM.Parameters["@dFUM"].Value = rwCeCOM.dFUM;

							sqlCmdUpdCentrosClientesCOM.ExecuteNonQuery();
						}
						catch
						{
							AddErrorRow(dsRet,dsRec.CentrosClientes_COM.TableName,sKey);
						}
					}
				}
				#endregion
				UpdatePaso();
				#region ProdClientesCOM
				if (dsRec.ProdClientes_COM!=null && dsRec.ProdClientes_COM.Rows.Count>0)
				{
					AddDefRow(dsRet,"ProdClientes_COM","dFUM","dFUM",false,true);
					foreach(WSSinCRM.dsCentral.ProdClientes_COMRow rwPC in dsRec.ProdClientes_COM.Rows)
					{
						try
						{
							sElemento="ProdClienteCOM " + rwPC.iIdCliente.ToString();
							sKey = BuildXMLKey(dsRec.ProdClientes_COM,rwPC);
							this.sqlCmdUpdProdClientesCOM.Parameters["@iIdCliente"].Value = rwPC.iIdCliente ;
							this.sqlCmdUpdProdClientesCOM.Parameters["@sIdProducto"].Value = rwPC.sIdProducto ;
							this.sqlCmdUpdProdClientesCOM.Parameters["@iPrioridad"].Value = rwPC.iPrioridad ;
							this.sqlCmdUpdProdClientesCOM.Parameters["@dFUM"].Value = rwPC.dFUM ;
							this.sqlCmdUpdProdClientesCOM.Parameters["@iEstado"].Value = rwPC.iEstado ;

							this.sqlCmdUpdProdClientesCOM.ExecuteNonQuery();
						}
						catch
						{
							AddErrorRow(dsRet,dsRec.ProdClientes_COM.TableName,sKey);
						}

					}
				}
				#endregion
				UpdatePaso();

                //---- GSG (21/11/2013)
                #region Clientes_OnLine
                if (dsRec.Clientes_OnLine != null && dsRec.Clientes_OnLine.Rows.Count > 0)
                {
                    AddDefRow(dsRet, "Clientes_OnLine", "dFUM", "dFUM", false, true);
                    foreach (WSSinCRM.dsCentral.Clientes_OnLineRow rwCli in dsRec.Clientes_OnLine.Rows)
                    {
                        try
                        {
                            sKey = BuildXMLKey(dsRec.Clientes_OnLine, rwCli);

                            sElemento = "Clientes_OnLine " + rwCli.iIdCliente.ToString();
                            sqlCmdUpdClientesOnLine.Parameters["@iIdCliente"].Value = rwCli.iIdCliente;
                            sqlCmdUpdClientesOnLine.Parameters["@sNombre"].Value = rwCli.IssNombreNull() ? SqlString.Null : rwCli.sNombre;
                            sqlCmdUpdClientesOnLine.Parameters["@bOperativa"].Value = rwCli.bOperativa;
                            sqlCmdUpdClientesOnLine.Parameters["@bLinkLadival"].Value = rwCli.bLinkLadival;
                            sqlCmdUpdClientesOnLine.Parameters["@sUrl"].Value = rwCli.IssUrlNull() ? SqlString.Null : rwCli.sUrl;
                            sqlCmdUpdClientesOnLine.Parameters["@iEstado"].Value = rwCli.iEstado;
                            sqlCmdUpdClientesOnLine.Parameters["@dFUM"].Value = rwCli.dFUM;

                            sqlCmdUpdClientesOnLine.ExecuteNonQuery();
                            UpdatePaso();
                        }
                        catch
                        {
                            AddErrorRow(dsRet, "Clientes_OnLine", sKey);
                        }
                    }
                }
                #endregion
                UpdatePaso();



				#region CampanyasMultiples

                ////eliminem totes les campanyes multiples, ja que al fer la sincronització sempre es baixen totes
                ////tenir en compte qe sempre { molt pocs registre i amb poca variabilitat, de l'ordre de 1 a 5.
                ////sqlCmdDelca.ExecuteNonQuery();
                //sqCmdDelCampanyaMultiple.ExecuteNonQuery();

                //if (dsRec.CampanyasMultiples != null && dsRec.CampanyasMultiples.Rows.Count > 0 )
                //{
                //    foreach(WSSinCRM.dsCentral.CampanyasMultiplesRow rwCampMult in dsRec.CampanyasMultiples.Rows)
                //    {
                //        try
                //        {

                //            sElemento="CampanyaMultiple " + rwCampMult.sIdCampanya;
                //            sKey = BuildXMLKey(dsRec.CampanyasMultiples,rwCampMult);
							
                //            sqlCmdUpdCampanyaMultiple.Parameters["@sIdCampanya"].Value = rwCampMult.sIdCampanya;
                //            sqlCmdUpdCampanyaMultiple.Parameters["@bEsDeSeleccionMultiple"].Value = rwCampMult.bEsDeSeleccionMultiple;
								
                //            sqlCmdUpdCampanyaMultiple.ExecuteNonQuery();
							
                //        }
                //        catch(Exception ex)
                //        {
                //            AddErrorRow(dsRet,dsRec.CampanyasMultiples.TableName,sKey);
                //        }


                //    }
                //}
                //UpdatePaso();

				#endregion 
                			
			}
			catch (Exception MyExc)
			{
				Mensajes.ShowError("Contacte con HelpDesk e indique el siguiente error de Sincronización:\n\n"+MyExc.Message+"\n\nEl error se ha producido en Actualizacion de Tablas Maestras, elemento " +sElemento.ToString());
				#region Pone en los Errores toda la informacion
				if (dsRec.Centros.Rows.Count >0  )
				{
					foreach(WSSinCRM.dsCentral.CentrosRow rwCen in dsRec.Centros.Rows)
					{
							sKey = BuildXMLKey(dsRec.Centros,rwCen);
							AddErrorRow(dsRet,"Centros",sKey);
					}
				}
				if (dsRec.CentrosRedes.Rows.Count >0  )
				{
					foreach(WSSinCRM.dsCentral.CentrosRedesRow rwCR in dsRec.CentrosRedes.Rows ) 
					{
						sKey = BuildXMLKey(dsRec.CentrosRedes,rwCR);
						AddErrorRow(dsRet,"CentrosRedes",sKey);
					}
				}
				if (dsRec.Clientes!=null && dsRec.Clientes.Rows.Count>0)
				{
					foreach (WSSinCRM.dsCentral.ClientesRow rwCli in dsRec.Clientes.Rows)
					{
							sKey = BuildXMLKey(dsRec.Clientes,rwCli);
							AddErrorRow(dsRet,"Clientes",sKey);
					}
				}
				if (dsRec.ClientesRedes!=null && dsRec.ClientesRedes.Rows.Count>0)
				{
					foreach(WSSinCRM.dsCentral.ClientesRedesRow rwCLR in dsRec.ClientesRedes.Rows)
					{
							sKey = BuildXMLKey(dsRec.ClientesRedes,rwCLR);
							AddErrorRow(dsRet,"ClientesRedes",sKey);
					}
				}
				if (dsRec.BrickClientes!=null && dsRec.BrickClientes.Rows.Count>0)
				{
					foreach(WSSinCRM.dsCentral.BrickClientesRow rwBrcl in dsRec.BrickClientes.Rows)
					{
							sKey = BuildXMLKey(dsRec.BrickClientes,rwBrcl);
							AddErrorRow(dsRet,"BrickClientes",sKey);
					}
				}
				if (dsRec.CPClientes!=null && dsRec.CPClientes.Rows.Count>0)
				{
					foreach(WSSinCRM.dsCentral.CPClientesRow rwCPcl in dsRec.CPClientes.Rows)  
					{
							sKey = BuildXMLKey(dsRec.CPClientes,rwCPcl);
							AddErrorRow(dsRet,"CPCLientes",sKey);
					}
				}
				if (dsRec.AccionesMarkClientes!=null && dsRec.AccionesMarkClientes.Rows.Count>0)
				{
					foreach(WSSinCRM.dsCentral.AccionesMarkClientesRow rwAcc in dsRec.AccionesMarkClientes.Rows)
					{
							sKey = BuildXMLKey(dsRec.AccionesMarkClientes,rwAcc);
							AddErrorRow(dsRet,dsRec.AccionesMarkClientes.TableName,sKey);
					}
				}
				if (dsRec.Clientes_SAP!=null && dsRec.Clientes_SAP.Rows.Count>0)
				{
					foreach(WSSinCRM.dsCentral.Clientes_SAPRow rwCSAP in dsRec.Clientes_SAP.Rows)
					{
							sKey = BuildXMLKey(dsRec.Clientes_SAP,rwCSAP);
							AddErrorRow(dsRet,"Clientes_SAP",sKey);
					}
				}

                //---- GSG (10/05/2011) no ho comento
                if (dsRec.ContactosClientes_SAP != null && dsRec.ContactosClientes_SAP.Rows.Count > 0)
                {
                    foreach (WSSinCRM.dsCentral.ContactosClientes_SAPRow rwCoSAP in dsRec.ContactosClientes_SAP.Rows)
                    {
                        sKey = BuildXMLKey(dsRec.ContactosClientes_SAP, rwCoSAP);
                        AddErrorRow(dsRet, "ContactosClientes_SAP", sKey);
                    }
                }
                //---- FI GSG

				if (dsRec.CentrosClientes_SAP!=null && dsRec.CentrosClientes_SAP.Rows.Count>0)
				{
					foreach(WSSinCRM.dsCentral.CentrosClientes_SAPRow rwCeSAP in dsRec.CentrosClientes_SAP.Rows)
					{
							sKey = BuildXMLKey(dsRec.CentrosClientes_SAP,rwCeSAP);
							AddErrorRow(dsRet,"CentrosClientes_SAP",sKey);
	
					}
				}
				if (dsRec.InterlocutorClientes_SAP!=null && dsRec.InterlocutorClientes_SAP.Rows.Count >0  )
				{
					foreach(WSSinCRM.dsCentral.InterlocutorClientes_SAPRow rwISAP in dsRec.InterlocutorClientes_SAP.Rows)
					{
							sKey = BuildXMLKey(dsRec.InterlocutorClientes_SAP,rwISAP);
							AddErrorRow(dsRet,dsRec.InterlocutorClientes_SAP.TableName,sKey);
					}
				}
				if (dsRec.Clientes_COM!=null && dsRec.Clientes_COM.Rows.Count>0)
				{
					foreach(WSSinCRM.dsCentral.Clientes_COMRow rwCCOM in dsRec.Clientes_COM.Rows)
					{
							sKey = BuildXMLKey(dsRec.Clientes_COM,rwCCOM);
							AddErrorRow(dsRet,dsRec.Clientes_COM.TableName,sKey);
					}
				}
				if (dsRec.EspecClientes_COM!=null && dsRec.EspecClientes_COM.Rows.Count>0)
				{
					foreach(WSSinCRM.dsCentral.EspecClientes_COMRow rwEsp in dsRec.EspecClientes_COM.Rows)
					{
							sKey = BuildXMLKey(dsRec.EspecClientes_COM,rwEsp);
							AddErrorRow(dsRet,dsRec.EspecClientes_COM.TableName,sKey);
					}
				}
				if (dsRec.AficClientes_COM!=null && dsRec.AficClientes_COM.Rows.Count>0)
				{
					foreach(WSSinCRM.dsCentral.AficClientes_COMRow  rwAf in dsRec.AficClientes_COM.Rows)
					{
							sKey = BuildXMLKey(dsRec.AficClientes_COM,rwAf);
							AddErrorRow(dsRet,dsRec.AficClientes_COM.TableName,sKey);
					}
				}
				if (dsRec.CentrosClientes_COM!=null && dsRec.Clientes_COM.Rows.Count>0)
				{
					foreach(WSSinCRM.dsCentral.CentrosClientes_COMRow rwCeCOM in dsRec.CentrosClientes_COM.Rows)
					{
							sKey = BuildXMLKey(dsRec.CentrosClientes_COM,rwCeCOM);
							AddErrorRow(dsRet,dsRec.CentrosClientes_COM.TableName,sKey);
					}
				}
				if (dsRec.ProdClientes_COM!=null && dsRec.ProdClientes_COM.Rows.Count>0)
				{
					foreach(WSSinCRM.dsCentral.ProdClientes_COMRow rwPC in dsRec.ProdClientes_COM.Rows)
					{
							sKey = BuildXMLKey(dsRec.ProdClientes_COM,rwPC);
							AddErrorRow(dsRet,dsRec.ProdClientes_COM.TableName,sKey);
					}
				}
					#endregion
			}
			finally
			{
				if (this.sqlConn.State == System.Data.ConnectionState.Open ) this.sqlConn.Close();
			}
			return dsRet;
		}

		private WSSinCRM.dsRetorno ActualizaPedidos(WSSinCRM.dsCentral dsRec )
		{
			System.Data.SqlClient.SqlTransaction thisTran=null;
			string sElemento="";
			string sKey = "";

			bool someError = false;

			WSSinCRM.dsRetorno dsRet = new WSSinCRM.dsRetorno();
			try
			{
				if (this.sqlConn.State == System.Data.ConnectionState.Closed) this.sqlConn.Open();
				
                #region Pedidos_Cab
				if (dsRec.Pedidos_Cab!=null && dsRec.Pedidos_Cab.Rows.Count >0 )
				{

					AddDefRow(dsRet,"Pedidos_Cab","fFUM","fFUM",false,true);

					foreach(WSSinCRM.dsCentral.Pedidos_CabRow rwPedC in dsRec.Pedidos_Cab.Rows)
					{
						someError = false;

						try
						{
							thisTran=sqlConn.BeginTransaction();
							this.sqlCmdUpdPedidosCab.Transaction = thisTran;
							this.sqlCmdUpdPedidosLin.Transaction = thisTran;
                            //this.sqlCmdUpdPedAcciones.Transaction = thisTran; //---- GSG (08/10/2012) la pongo //---- GSG (06/10/2015) La quito

							sKey = BuildXMLKey(dsRec.Pedidos_Cab,rwPedC);

							sElemento="PedidoCab "+rwPedC.sIdPedido;
							sqlCmdUpdPedidosCab.Parameters["@sIdPedido"].Value = rwPedC.sIdPedido;
							sqlCmdUpdPedidosCab.Parameters["@sIdPedidoTemp"].Value = rwPedC.IssIdPedidoTempNull()?SqlString.Null:rwPedC.sIdPedidoTemp; 
							sqlCmdUpdPedidosCab.Parameters["@iIdDelegado"].Value = rwPedC.iIdDelegado; 
							sqlCmdUpdPedidosCab.Parameters["@sIdTipoPedido"].Value = rwPedC.sIdTipoPedido; 
							sqlCmdUpdPedidosCab.Parameters["@iIdCliente"].Value = rwPedC.iIdCliente;
							sqlCmdUpdPedidosCab.Parameters["@iIdDestinatario"].Value = rwPedC.iIdDestinatario;
							sqlCmdUpdPedidosCab.Parameters["@dFechaPedido"].Value = rwPedC.dFechaPedido; 
							sqlCmdUpdPedidosCab.Parameters["@dFechaPreferente"].Value = rwPedC.dFechaPreferente;
							sqlCmdUpdPedidosCab.Parameters["@dFechaFijada"].Value = rwPedC.dFechaFijada; 
							sqlCmdUpdPedidosCab.Parameters["@sOrgVentas"].Value = rwPedC.sOrgVentas;
							sqlCmdUpdPedidosCab.Parameters["@sGrupoVendedor"].Value = rwPedC.sGrupoVendedor;
							sqlCmdUpdPedidosCab.Parameters["@sCanal"].Value = rwPedC.sCanal;
							sqlCmdUpdPedidosCab.Parameters["@sSector"].Value = rwPedC.sSector;
							sqlCmdUpdPedidosCab.Parameters["@fImporte"].Value = rwPedC.fImporte; 
							sqlCmdUpdPedidosCab.Parameters["@fDescuento"].Value = rwPedC.fDescuento;
							sqlCmdUpdPedidosCab.Parameters["@sIdEstEntPedido"].Value = rwPedC.IssIdEstEntPedidoNull()?SqlString.Null:rwPedC.sIdEstEntPedido;
							sqlCmdUpdPedidosCab.Parameters["@sIdEstFacPedido"].Value = rwPedC.IssIdEstFacPedidoNull()?SqlString.Null:rwPedC.sIdEstFacPedido;
							sqlCmdUpdPedidosCab.Parameters["@sIdTipoCampanya"].Value = rwPedC.IssIdTipoCampanyaNull()?SqlString.Null:rwPedC.sIdTipoCampanya; 
							sqlCmdUpdPedidosCab.Parameters["@tObservaciones"].Value = rwPedC.IstObservacionesNull()?SqlString.Null:rwPedC.tObservaciones;
							sqlCmdUpdPedidosCab.Parameters["@iEstado"].Value = rwPedC.iEstado;
							sqlCmdUpdPedidosCab.Parameters["@fFUM"].Value = rwPedC.fFUM;

                            //RH
                            sqlCmdUpdPedidosCab.Parameters["@fDescuentoCampanya"].Value = rwPedC.fDescuentoCampanya;
                            sqlCmdUpdPedidosCab.Parameters["@fDescuentoAdicional"].Value = rwPedC.fDescuentoAdicional;
                            //---- GSG (03/02/2011)
                            //---- GSG (12/09/2012)
                            //sqlCmdUpdPedidosCab.Parameters["@fRentabilidad"].Value = rwPedC.fRentabilidad;
                            if (rwPedC.fRentabilidad == -999)
                                sqlCmdUpdPedidosCab.Parameters["@fRentabilidad"].Value = DBNull.Value;
                            else
                                sqlCmdUpdPedidosCab.Parameters["@fRentabilidad"].Value = rwPedC.fRentabilidad;
                            //---- FI GSG
                            sqlCmdUpdPedidosCab.Parameters["@iIdAccion"].Value = rwPedC.iIdAccion;
                            //---- GSG (06/05/2014)
                            sqlCmdUpdPedidosCab.Parameters["@sCondPago"].Value = rwPedC.IssCondPagoNull() ? SqlString.Null : rwPedC.sCondPago;
                            sqlCmdUpdPedidosCab.Parameters["@sPrioridad"].Value = rwPedC.IssPrioridadNull() ? SqlString.Null : rwPedC.sPrioridad;
                            try
                            {
                                sqlCmdUpdPedidosCab.Parameters["@dFechaFacturacion"].Value = rwPedC.dFechaFacturacion;
                            }
                            catch (Exception ex)
                            {
                                sqlCmdUpdPedidosCab.Parameters["@dFechaFacturacion"].Value = null;
                            }
                            //---- GSG (14/10/2016)
                            sqlCmdUpdPedidosCab.Parameters["@sTipoPedidoCompromiso"].Value = rwPedC.IssTipoPedidoCompromisoNull() ? SqlString.Null : rwPedC.sTipoPedidoCompromiso;
                            sqlCmdUpdPedidosCab.Parameters["@sTipoGestionCompromiso"].Value = rwPedC.IssTipoGestionCompromisoNull() ? SqlString.Null : rwPedC.sTipoGestionCompromiso;
                            //---- GSG (06/03/2017)
                            sqlCmdUpdPedidosCab.Parameters["@sCPCompra"].Value = rwPedC.IssCPCompraNull() ? SqlString.Null : rwPedC.sCPCompra;
                            //---- GSG (05/10/2017)
                            sqlCmdUpdPedidosCab.Parameters["@idUbicacion"].Value = rwPedC.idUbicacion;

                            sqlCmdUpdPedidosCab.ExecuteNonQuery();
					
							#region Pedidos_Lin

							foreach(WSSinCRM.dsCentral.Pedidos_LinRow rwLin in rwPedC.GetChildRows("Pedidos_CabPedidos_Lin"))
							{
								if (!someError)
								{
									try
									{
										sElemento="PedidoLin "+rwLin.sIdPedido;
										this.sqlCmdUpdPedidosLin.Parameters["@sIdPedido"].Value =rwLin.sIdPedido;  
										this.sqlCmdUpdPedidosLin.Parameters["@iIdLinea"].Value =rwLin.iIdLinea; 
										this.sqlCmdUpdPedidosLin.Parameters["@sIdMaterial"].Value =rwLin.sIdMaterial; 
										this.sqlCmdUpdPedidosLin.Parameters["@iCantidad"].Value =rwLin.iCantidad; 
										this.sqlCmdUpdPedidosLin.Parameters["@fPrecio"].Value =rwLin.fPrecio; 
										this.sqlCmdUpdPedidosLin.Parameters["@sIdTipoPosicion"].Value =rwLin.sIdTipoPosicion;  
										this.sqlCmdUpdPedidosLin.Parameters["@bEntregado"].Value =rwLin.bEntregado; 
										this.sqlCmdUpdPedidosLin.Parameters["@dFechaPreferente"].Value =rwLin.dFechaPreferente; 
										this.sqlCmdUpdPedidosLin.Parameters["@sCentro"].Value =rwLin.sCentro; 
										this.sqlCmdUpdPedidosLin.Parameters["@sAlmacen"].Value =rwLin.sAlmacen; 
										this.sqlCmdUpdPedidosLin.Parameters["@fDescuento"].Value =rwLin.fDescuento; 
										this.sqlCmdUpdPedidosLin.Parameters["@iBonificacion"].Value =rwLin.iBonificacion;

                                        //RH
                                        this.sqlCmdUpdPedidosLin.Parameters["@idCampanya"].Value = rwLin.idCampanya;
                                        this.sqlCmdUpdPedidosLin.Parameters["@idArrastre"].Value = rwLin.idArrastre;
                                        this.sqlCmdUpdPedidosLin.Parameters["@idGrupoMat"].Value = rwLin.idGrupoMat;
                                        this.sqlCmdUpdPedidosLin.Parameters["@idPaquete"].Value = rwLin.idPaquete;

                                        //---- GSG (21/05/2014)
                                        try
                                        {
                                            this.sqlCmdUpdPedidosLin.Parameters["@sSerie"].Value = rwLin.sSerie;
                                        }
                                        catch(Exception ex)
                                        {
                                            this.sqlCmdUpdPedidosLin.Parameters["@sSerie"].Value = null;
                                        }

                                        try
                                        {
                                            this.sqlCmdUpdPedidosLin.Parameters["@sCodVale"].Value = rwLin.sCodVale;
                                        }
                                        catch (Exception ex)
                                        {
                                            this.sqlCmdUpdPedidosLin.Parameters["@sCodVale"].Value = null;
                                        }

                                        //---- GSG (20/03/2017)
                                        try
                                        {
                                            this.sqlCmdUpdPedidosLin.Parameters["@sRechazo"].Value = rwLin.sRechazo;
                                        }
                                        catch (Exception ex)
                                        {
                                            this.sqlCmdUpdPedidosLin.Parameters["@sRechazo"].Value = "0000";
                                        }

                                        //---- GSG (21/08/2017)
                                        try
                                        {
                                            this.sqlCmdUpdPedidosLin.Parameters["@fDescImplicito"].Value = rwLin.fDescImplicito;
                                        }
                                        catch (Exception ex)
                                        {
                                            this.sqlCmdUpdPedidosLin.Parameters["@fDescImplicito"].Value = null;
                                        }


                                        sqlCmdUpdPedidosLin.ExecuteNonQuery();
									}
                                    catch (Exception ex)
									{
										AddErrorRow(dsRet,dsRec.Pedidos_Cab.TableName,sKey);
										if (thisTran!=null) thisTran.Rollback();
										someError = true;
									}
								}

							}
							#endregion

                            //---- GSG (06/10/2015) La tabla PedAcciones deja de bajar con el pedido y pasa a bajar como lo hacen las maestras independientemente del pedido
                            //---- GSG (08/10/2012)                            
                            #region PedAcciones
                            //foreach (WSSinCRM.dsCentral.PedAccionesRow rwLin in rwPedC.GetChildRows("Pedidos_Cab_PedAcciones"))
                            //{
                            //    if (!someError)
                            //    {
                            //        try
                            //        {
                            //            sqlCmdUpdPedAcciones.Parameters["@sIdPedido"].Value = rwLin.sIdPedido;
                            //            sqlCmdUpdPedAcciones.Parameters["@iIdAccion"].Value = rwLin.iIdAccion;
                            //            sqlCmdUpdPedAcciones.ExecuteNonQuery();
                            //        }
                            //        catch
                            //        {
                            //            AddErrorRow(dsRet, dsRec.Pedidos_Cab.TableName, sKey);
                            //            if (thisTran != null) thisTran.Rollback();
                            //            someError = true;
                            //        }
                            //    }
                            //}
                            
                            #endregion
                            //---- FI GSG

                            #region Campanya Pedido

                            //sqlCmdDeleteCampanyasPedido.Parameters["@sIdPedido"].Value = rwPedC.sIdPedido;
                            //sqlCmdDeleteCampanyasPedido.ExecuteNonQuery();

                            //foreach(WSSinCRM.dsCentral.CampanyasPedidoRow RowCamp in dsRec.CampanyasPedido.Select("sIdPedido = '" + rwPedC.sIdPedido + "'"))
                            //{
                            //    sqlCmdUpdCamapanyaPedidos.Parameters["@sIdPedido"].Value = RowCamp.sIdPedido;
                            //    sqlCmdUpdCamapanyaPedidos.Parameters["@sIdCampanya"].Value = RowCamp.sIdCampanya;
                            //    sqlCmdUpdCamapanyaPedidos.ExecuteNonQuery();								
                            //}

							#endregion

							if (! someError) thisTran.Commit();
						}
                        catch (Exception ex)
						{
							AddErrorRow(dsRet,dsRec.Pedidos_Cab.TableName,sKey);
							if (thisTran!=null) thisTran.Rollback();
						}
					}
				}
				#endregion

				#region Actualizar Descuento Campanyas 

            //if (dsRec.Descuento_Campanyas != null)
            //{			
            //    thisTran=sqlConn.BeginTransaction();
            //    sqlCmdUpdDescuento_Campanyas.Transaction = thisTran;

            //    foreach(GESTCRM.WSSinCRM.dsCentral.Descuento_CampanyasRow oRowCamp in dsRec.Descuento_Campanyas.Rows)
            //    {
            //        //sqlCmdUpdDescuento_Campanyas.Parameters.Clear();
            //        sqlCmdUpdDescuento_Campanyas.Parameters["@sIdCampanya"].Value = oRowCamp.sIdCampanya;
            //        sqlCmdUpdDescuento_Campanyas.Parameters["@bInformarDescuentoMaximo"].Value = oRowCamp.bInformarDescuentoMaximo;
            //        sqlCmdUpdDescuento_Campanyas.ExecuteNonQuery();
            //    }
            //    thisTran.Commit();

            //}
				#endregion 

				#region Ventas directas, transfers y Club
				//CAR - (16-07-2010)
				if (dsRec.Datos_CRM_CLUB != null)
				{
					thisTran = sqlConn.BeginTransaction();
					sqlCmdUpdDatos_CRM_CLUB.Transaction = thisTran;
					foreach (GESTCRM.WSSinCRM.dsCentral.Datos_CRM_CLUBRow oRowDatosCLUB in dsRec.Datos_CRM_CLUB.Rows)
					{
						sqlCmdUpdDatos_CRM_CLUB.Parameters["@Cliente"].Value = oRowDatosCLUB.Cliente;
						sqlCmdUpdDatos_CRM_CLUB.Parameters["@Tipo"].Value = oRowDatosCLUB.Tipo;
						sqlCmdUpdDatos_CRM_CLUB.Parameters["@Anyo"].Value = oRowDatosCLUB.Anyo;
						sqlCmdUpdDatos_CRM_CLUB.Parameters["@Mes"].Value = oRowDatosCLUB.Mes;
						sqlCmdUpdDatos_CRM_CLUB.Parameters["@Importe"].Value = oRowDatosCLUB.Importe;
						sqlCmdUpdDatos_CRM_CLUB.Parameters["@SidMaterial"].Value = oRowDatosCLUB.SidMaterial;
						sqlCmdUpdDatos_CRM_CLUB.Parameters["@VKGRP"].Value = oRowDatosCLUB.VKGRP;
						sqlCmdUpdDatos_CRM_CLUB.Parameters["@Unidades"].Value = oRowDatosCLUB.Unidades;
						sqlCmdUpdDatos_CRM_CLUB.Parameters["@Sincronizado"].Value = oRowDatosCLUB.Sincronizado;
                        //---- GSG (18/04/2011)
                        sqlCmdUpdDatos_CRM_CLUB.Parameters["@ImporteBruto"].Value = oRowDatosCLUB.ImporteBruto;
                        sqlCmdUpdDatos_CRM_CLUB.Parameters["@Desc1"].Value = oRowDatosCLUB.Desc1;
                        sqlCmdUpdDatos_CRM_CLUB.Parameters["@Desc2"].Value = oRowDatosCLUB.Desc2;
                        sqlCmdUpdDatos_CRM_CLUB.Parameters["@Desc3"].Value = oRowDatosCLUB.Desc3;
                        sqlCmdUpdDatos_CRM_CLUB.Parameters["@Desc4"].Value = oRowDatosCLUB.Desc4;
                        sqlCmdUpdDatos_CRM_CLUB.Parameters["@Desc5"].Value = oRowDatosCLUB.Desc5;
                        //---- GSG (04/09/2012)
                        sqlCmdUpdDatos_CRM_CLUB.Parameters["@sReferencia"].Value = oRowDatosCLUB.sReferencia;
                        //---- FI GSG
						sqlCmdUpdDatos_CRM_CLUB.ExecuteNonQuery();
					}
					thisTran.Commit();
				}
				#endregion

				UpdatePaso();

                //---- GSG (09/01/2014)                            
                #region EmailsClientes
                if (dsRec.EmailsClientes != null)
                {
                    thisTran = sqlConn.BeginTransaction();
                    sqlCmdUpdEmailsClientes.Transaction = thisTran;
                    foreach (GESTCRM.WSSinCRM.dsCentral.EmailsClientesRow oRowEmc in dsRec.EmailsClientes.Rows)
                    {
                        sqlCmdUpdEmailsClientes.Parameters["@iIdCliente"].Value = oRowEmc.iIdCliente;
                        sqlCmdUpdEmailsClientes.Parameters["@dFecha"].Value = oRowEmc.dFecha;
                        sqlCmdUpdEmailsClientes.Parameters["@sEmailConf"].Value = oRowEmc.sEmailConf;
                        sqlCmdUpdEmailsClientes.Parameters["@sEmailFact"].Value = oRowEmc.sEmailFact;
                        sqlCmdUpdEmailsClientes.Parameters["@bTratado"].Value = oRowEmc.bTratado;
                        sqlCmdUpdEmailsClientes.Parameters["@dFUM"].Value = oRowEmc.dFUM;

                        sqlCmdUpdEmailsClientes.ExecuteNonQuery();
                    }
                    thisTran.Commit();
                }

                #endregion


                //---- GSG (09/01/2014)   
                UpdatePaso();

                //En central indicamos qué pedidos constant como sincronizados en cliente pero realmente no se han subido por algún fallo. 
                //Bajamos esta tabla para que vuelvan a sincronizarse
                #region Pedidos Central
                if (dsRec.PedidosCentral != null)
                {
                    thisTran = sqlConn.BeginTransaction();
                    sqlCmdUpdPedidosCentral.Transaction = thisTran;
                    foreach (GESTCRM.WSSinCRM.dsCentral.PedidosCentralRow oRowPc in dsRec.PedidosCentral.Rows)
                    {
                        sqlCmdUpdPedidosCentral.Parameters["@sIdPedido"].Value = oRowPc.sIdPedido;
                        sqlCmdUpdPedidosCentral.Parameters["@iIdDelegado"].Value = oRowPc.iIdDelegado;

                        sqlCmdUpdPedidosCentral.ExecuteNonQuery();
                    }
                    thisTran.Commit();
                }

                #endregion

                //---- FI GSG

				UpdatePaso();
			}
			catch (Exception MyExc)
			{
				if (thisTran!=null) thisTran.Rollback();
				foreach (WSSinCRM.dsCentral.Pedidos_CabRow rwCab in dsRec.Pedidos_Cab.Rows)
				{
					sKey = BuildXMLKey(dsRec.Pedidos_Cab,rwCab);
					AddErrorRow(dsRet,"Pedidos_Cab",sKey);
				}
				Mensajes.ShowError("Contacte con HelpDesk e indique el siguiente error de Sincronización:\n\n"+MyExc.Message+"\n\nEl error se ha producido en Actualizacion de Pedidos, elemento " +sElemento.ToString());
			}
			finally
			{
				if (this.sqlConn.State == System.Data.ConnectionState.Open ) this.sqlConn.Close();
			}
			return dsRet;
		}

		private string GrabaArchivoDatos(WSSinCRM.dsCentral dsREC)
		{
			// Generacion del archivo .XML para al Dataset Obtenido
			string sXmlData = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\XmlSincro" + DateTime.Now.Year.ToString() +
                DateTime.Now.Month.ToString().PadLeft(2,'0') + DateTime.Now.Day.ToString().PadLeft(2,'0') + DateTime.Now.Hour.ToString().PadLeft(2,'0') +
                DateTime.Now.Minute.ToString().PadLeft(2,'0') + DateTime.Now.Second.ToString().PadLeft(2,'0') + ".XML";

			try
			{
				dsREC.WriteXml(sXmlData, System.Data.XmlWriteMode.IgnoreSchema);
			}
			catch (System.IO.IOException)
			{
				sXmlData = "";
			}

			return sXmlData;
		}

		private WSSinCRM.dsRetorno ProcesaArchivoDatos()
		{

			WSSinCRM.dsRetorno dsRet = new WSSinCRM.dsRetorno();

			WSSinCRM.dsCentral dsRec=null;
			System.IO.StreamReader srF=null;
			Font fPaso = new Font("Microsoft Sans Serif",float.Parse("8,25"),System.Drawing.FontStyle.Bold);

			try
			{

				string sXmlData = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
					
				foreach(string sF in System.IO.Directory.GetFiles(sXmlData,"*.XML"))
				{
					
					this.lblPaso3.Text ="3. Procesando Archivos de Sincronizaciones Anteriores.";
					this.lblPaso3.ForeColor = System.Drawing.Color.Red; 
					this.lblPaso3.Font = fPaso; 
					this.Refresh();

					srF= new System.IO.StreamReader(sF,System.Text.Encoding.Default);

					dsRec = new WSSinCRM.dsCentral();
					dsRec.EnforceConstraints = false;
					dsRec.ReadXml(sF,System.Data.XmlReadMode.IgnoreSchema );

					dsRet = ActualizarDatos(dsRec);


					srF.Close();
					dsRec.Dispose();

					System.IO.File.Copy(sF,sXmlData+@"\Actualizaciones\"+System.IO.Path.GetFileName(sF),true);
					System.IO.File.Delete(sF);

				}
				this.lblPaso3.Text = "3. Obteniendo informacion de Central." ;
			}
			catch (System.IO.IOException ActExc)
			{
				srF.Close();
				dsRec.Dispose();
				
			}
			catch (Exception ActE)
			{
				srF.Close();
				dsRec.Dispose();
			}
			return dsRet;

		}

		private bool ProcesaComandos(WSSinCRM.dsCentral dsREC)
		{
			Cursor.Current=Cursors.WaitCursor;
			string regS="";

			if (this.sqlConn.State == System.Data.ConnectionState.Closed  ) this.sqlConn.Open();
			this.sqlTran = this.sqlConn.BeginTransaction();
			this.sqlCmdAct.Transaction=this.sqlTran;
			this.sqlCmdAct.CommandTimeout=1800;

			try
			{
				foreach(WSSinCRM.dsCentral.GetSincroUpdatesRow rwUpd in dsREC.GetSincroUpdates.Rows)
				{
					this.sqlCmdAct.CommandText="";

					regS=rwUpd.sCommand;
					regS=regS.Replace("\t"," ");
					regS=regS.Replace("\r"," ");
					regS=regS.Replace("\n"," ");
					regS=regS.Trim()+" ";
					if (regS.Trim()!="") this.sqlCmdAct.CommandText+=regS;

					this.sqlCmdAct.ExecuteNonQuery();

				}

				this.sqlTran.Commit();
			}
			catch(Exception excAct)
			{
				this.sqlTran.Rollback();
				Mensajes.ShowError("Contacte con HelpDesk e indique el siguiente error:\n"+excAct.Message);
				return false;
			}

			this.sqlConn.Close();

			Cursor.Current=Cursors.Default;
			return true;

		}
		
		#region ActualizaResultadosSincro
		/// <summary>
		/// Actualiza la informacion enviada a Central, marcando como enviados los elementos
		/// que han sido insertados o actualizados y marcando con fecha actual los registros
		/// no procesados para subir en la prooxima sinconozacion,
		/// </summary>
		/// <param name="dsRet">DataSet de Retorno definido en el Web Service</param>
		private void ProcesaResultados (WSSinCRM.dsRetorno dsRet)
		{
			
			System.Data.SqlClient.SqlCommand sqlUpdRes = new System.Data.SqlClient.SqlCommand();

			sqlUpdRes.Connection = this.sqlConn;
			sqlUpdRes.CommandType = System.Data.CommandType.Text;

			// Marca la nueva fecha a asignar a los registros
			// Adiciona 12 horas para evitar la posible diferencia entre cliente y servidor
			DateTime dNuevaFecha = DateTime.Now.AddHours(1);

			string TableName;

			XmlDocument XMLData = new XmlDocument();
			XmlElement  XMLElem;

			System.Data.DataRow[] rwDef;
			System.Data.DataRow rwRow;
			
			int RowsAffected = 0;

			try
			{
				if (this.sqlConn.State == System.Data.ConnectionState.Closed ) this.sqlConn.Open();

				foreach (WSSinCRM.dsRetorno.TablaRow rwTabla in dsRet.Tabla.Rows)
				{
					TableName = rwTabla.sNombreTabla;

					// Obtiene un DataRow con la Definición de la tabla
					rwDef = dsRet.Definiciones.Select("sNombreTabla='"+TableName.Trim()+"'");
					if (rwDef.Length>0)
					{
						// Busca si existen filas de errores para la fila de la tabla especificada
						foreach(WSSinCRM.dsRetorno.FilasRow rwFila in rwTabla.GetChildRows("TablaFilas"))
						{  
							for(int i=0;i<rwDef.Length;i++)
							{
								rwRow = rwDef[i];
								RowsAffected = 0;
								// Limpia el SqlParameter para generarlo nuevamente
								sqlUpdRes.Parameters.Clear();
								// Carga en XMLDocument el campo Key y construye una cadena de caracteres con el filtro
								// para el update
								XMLData.LoadXml(rwFila.sKey.ToString());
								XMLElem = XMLData.DocumentElement;

								// Construye la cadena para la consulta de Update en
								// dependencia de la definicion de la tabla
								sqlUpdRes.CommandText="Update "+TableName.Trim()+" set ";
								if (bool.Parse(rwRow[4].ToString().Trim()))
								{
									sqlUpdRes.CommandText += rwRow[2].ToString().Trim()+"=@dFecha ";	

								}
								else
								{
									if (bool.Parse(rwRow[3].ToString().Trim()))
									{
										sqlUpdRes.CommandText += rwRow[1].ToString().Trim()+"=@dFecha ";	
									}
								}
								sqlUpdRes.Parameters.Add("@dFecha",System.Data.SqlDbType.DateTime);
								sqlUpdRes.Parameters["@dFecha"].Value = dNuevaFecha;

								sqlUpdRes.CommandText += " where ";

								if (bool.Parse(rwRow[4].ToString().Trim()))
								{
									sqlUpdRes.CommandText += rwRow[2].ToString().Trim()+" is not null ";							
								}
								else
								{
									if (bool.Parse(rwRow[3].ToString().Trim()))
									{
										sqlUpdRes.CommandText += rwRow[2].ToString().Trim()+"=0 ";	
									}
								}

								foreach (System.Xml.XmlNode XNode in XMLElem.ChildNodes)
								{

									if (sqlUpdRes.CommandText.Length>0) sqlUpdRes.CommandText += " AND ";
								
//									sqlUpdRes.CommandText += XNode.Name + " = @"+XNode.Name.Trim();


									switch (XNode.Name.Substring(0,1).ToUpper())
									{
										case "I":sqlUpdRes.Parameters.Add("@"+XNode.Name.Trim(),System.Data.SqlDbType.Int); 
												sqlUpdRes.Parameters["@"+XNode.Name.Trim()].Value=int.Parse(XNode.InnerText);
												sqlUpdRes.CommandText += XNode.Name + " = @"+XNode.Name.Trim();
												break;
										case "F":sqlUpdRes.Parameters.Add("@"+XNode.Name.Trim(),System.Data.SqlDbType.DateTime); 
												sqlUpdRes.Parameters["@"+XNode.Name.Trim()].Value=DateTime.Parse(XNode.InnerText);
												sqlUpdRes.CommandText += XNode.Name + " >= @"+XNode.Name.Trim();
												break;
										case "D":sqlUpdRes.Parameters.Add("@"+XNode.Name.Trim(),System.Data.SqlDbType.DateTime); 
												sqlUpdRes.Parameters["@"+XNode.Name.Trim()].Value=DateTime.Parse(XNode.InnerText);
												sqlUpdRes.CommandText += XNode.Name + " >= @"+XNode.Name.Trim();
												break;
										case "S":sqlUpdRes.Parameters.Add("@"+XNode.Name.Trim(),System.Data.SqlDbType.VarChar); 
												sqlUpdRes.Parameters["@"+XNode.Name.Trim()].Value=XNode.InnerText.Trim();
												sqlUpdRes.CommandText += XNode.Name + " = @"+XNode.Name.Trim();
												break;
									}
								
								}
								sqlUpdRes.CommandText +=" SELECT @@ROWCOUNT";

								RowsAffected = int.Parse(sqlUpdRes.ExecuteScalar().ToString());
								if (RowsAffected>0) break;
							}
						}

						for(int i=0;i<rwDef.Length;i++)
						{
							//Marca como enviados los elementos que tienen campo bool para marcar el envío
							//Las tablas que no tienen campo bool no se marcan, pues la unica osibilidad
							//de marcarlas es adelantando la fecha en caso de que no hayan podido ser insertadas

							rwRow = rwDef[i];
							if (bool.Parse(rwRow[3].ToString()))
							{
								sqlUpdRes.Parameters.Clear();
								sqlUpdRes.CommandText="Update "+TableName.Trim()+" set "+rwRow[2].ToString().Trim()+"=1 where "+
									rwRow[1].ToString().Trim()+" < @dFecha ";


                                //---- GSG (24/01/2014)
                                if (TableName.Trim() == "Pedidos_Cab")
                                {
                                    sqlUpdRes.CommandText += " and sIdPedido collate database_default not in (select sIdPedido from PedidosRetenidos where bretenido = 1)";
                                }
                                //---- FI GSG


								sqlUpdRes.Parameters.Add("@dFecha",System.Data.SqlDbType.DateTime);
								sqlUpdRes.Parameters["@dFecha"].Value = dNuevaFecha;

								sqlUpdRes.ExecuteNonQuery();
							}
						}
					}
					this.UpdatePaso();

				}
			}
			catch (Exception e)
			{
				Mensajes.ShowError("Error en actualización de Resultados de Sincronización\n"+e.Message.ToString());
			}
			finally
			{
				if (this.sqlConn.State == System.Data.ConnectionState.Open ) this.sqlConn.Close();
				sqlUpdRes.Dispose();
			}
		}
		#endregion

		#region AddErrorRow
		private void AddErrorRow (WSSinCRM.dsRetorno rsRet,string TableName, string Key)
		{
			if(rsRet.Tabla.Select("sNombreTabla='"+TableName+"'").Length==0)
			{
				DataRow rt = rsRet.Tabla.NewRow();
				rt[0]= TableName;
				rsRet.Tabla.Rows.Add(rt);
			}
			if (Key.Trim().Length>0)
			{
				DataRow rw = rsRet.Filas.NewRow();
				rw[0]=TableName;
				rw[1]=Key;
				rsRet.Filas.Rows.Add(rw);
			}

		}
		#endregion
		
		#region AddDefRow
		private void AddDefRow (WSSinCRM.dsRetorno rsRet,string TableName, string sCampoFecha, string sCampoMarca,bool bMarcaBool,bool bMarcaDate)
		{
			if(rsRet.Tabla.Select("sNombreTabla='"+TableName+"'").Length==0)
			{
				WSSinCRM.dsRetorno.TablaRow rt = (WSSinCRM.dsRetorno.TablaRow)rsRet.Tabla.NewRow();
				rt.sNombreTabla= TableName;
				rsRet.Tabla.Rows.Add(rt);
			}

			WSSinCRM.dsRetorno.DefinicionesRow rw = (WSSinCRM.dsRetorno.DefinicionesRow)rsRet.Definiciones.NewRow();
			rw.sNombreTabla=TableName;
			rw.sCampoFecha=sCampoFecha;
			rw.sCampoMarca=sCampoMarca;
			rw.bMarcaBool=bMarcaBool;
			rw.bMarcaDate=bMarcaDate;
			rsRet.Definiciones.Rows.Add(rw);

		}
		#endregion

		#region BuildXMLKey
		private string BuildXMLKey(DataTable theTable, DataRow theRow)
		{
			XmlDocument sDetail;
			try
			{
				sDetail = new System.Xml.XmlDocument();
				XmlNode xElementroot = sDetail.CreateNode(XmlNodeType.Element,theTable.TableName.ToString(),"");
				sDetail.AppendChild(xElementroot);

				XmlNode theElement;

				foreach(DataColumn columnas in theTable.PrimaryKey)
				{
					theElement = sDetail.CreateNode(XmlNodeType.Element,columnas.ColumnName,"");
					theElement.InnerText = theRow[columnas.ColumnName].ToString();
					xElementroot.AppendChild(theElement);
					//sDetail.AppendChild(theElement);
				}
			}
			catch
			{
				return "";
			}

			return sDetail.InnerXml;
		}
		#endregion

		#region UpdatePaso
		private void UpdatePaso()
		{
			if (this.pgbPaso.Value+this.pgbPaso.Step > this.pgbPaso.Maximum)
			{
				this.pgbPaso.Value=this.pgbPaso.Maximum;
			}
			else
			{
				this.pgbPaso.PerformStep();
			}
			this.Refresh();
			Application.DoEvents();
		}
		#endregion

		private void UpdateStatus()
		{
			if (this.iCurrentPaso != 0)
			{
				if (pAsync != null)
				{
					pAsync.AsyncWaitHandle.WaitOne();
					switch (this.iCurrentPaso )
					{
						case 3: 
                            this.pcbFinish3.Image = SetImage("Ok.ico");
                            this.Refresh();
                            iCurrentPaso=0;
                            break; 
						case 5: 
                            this.pcbFinish5.Image = SetImage("Ok.ico");
                            this.Refresh();
                            iCurrentPaso=0;
                            break;
					}
				}
			}

		}

		
		private void tmrStatus_Tick(object sender, System.EventArgs e)
		{
			if (this.iCurrentPaso == 0)
			{
				tmrStatus.Enabled = false;
			}
			else
			{
				UpdateStatus();
			}
		}
		
		
		#region Unzip
		private byte[] Unzip(byte[] sequence)
		{
			// Decode the Base64 encoding
//			byte[] inputByteArray = Convert.FromBase64String( stringToUnzip ) ;
			byte[] inputByteArray = sequence ;
			MemoryStream ms = new MemoryStream(inputByteArray) ;
			MemoryStream ret = new MemoryStream();

			// Refer to #ziplib documentation for more info on this
			ZipInputStream zipIn = new ZipInputStream(ms);
			ZipEntry theEntry = zipIn.GetNextEntry();
			Byte[] buffer = new Byte[2048] ;
			int size = 2048;
			while (true)
			{
				size = zipIn.Read(buffer, 0, buffer.Length);
				if (size > 0)
				{
					ret.Write(buffer, 0, size);
				}
				else
				{
					break;
				}
			}
			return ret.ToArray();
		}
		#endregion

		#region Registry Access
		private bool SetRegistryKey(string name,string command)
		{
			try
			{
                //---- GSG (16/05/2011) Canviem la clau
                //RegistryKey rk = Registry.LocalMachine;
                RegistryKey rk = Registry.CurrentUser; //HKEY_CURRENT_USER
                //---- FI GSG
                
                RegistryKey rk1;

                //---- GSG (26/04/2011)   
                //RegistryKey rk1 = rk.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\RunOnce", true);
                Process p = Process.GetCurrentProcess();

                if (!IsWin64(p))
                    //rk1 = rk.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\RunOnce", true);
                    rk1 = rk.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\RunOnce", true);
                else
                    rk1 = rk.OpenSubKey("SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\RunOnce", true);
                //---- FI GSG

                if (rk1.GetValue(name) == null)
                {
                    rk1.SetValue(name, command);
                }

                rk1.Close();
			}
			catch (Exception E)
			{
				return false;
			}

			return true;
		}

		private bool UpdatePending()
		{
            //---- GSG (23/05/2011) Canviem la clau
            
            ////---- GSG (26/04/2011)
            ////RegistryKey rk = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\RunOnce");
            //RegistryKey rk;
            //Process p = Process.GetCurrentProcess();

            //if (!IsWin64(p))
            //    rk = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\RunOnce");
            //else
            //    rk = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\RunOnce");               
            
            ////---- FI GSG
            //return (rk.GetValue("GESTCRMUPDATE") != null );
           
            RegistryKey rk = Registry.CurrentUser; //HKEY_CURRENT_USER
            RegistryKey rk1;
            Process p = Process.GetCurrentProcess();


            if (!IsWin64(p))            
                rk1 = rk.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\RunOnce", true);
            else
                rk1 = rk.OpenSubKey("SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\RunOnce", true);

            return (rk1.GetValue("GESTCRMUPDATE") != null);


        }


        //---- GSG (26/04/2011) 
        //public string GetOSVersion()
        //{
        //    int _MajorVersion = Environment.OSVersion.Version.Major;

        //    Environment.OSVersion.Version.P
        //    IntPtr a = Environment.OSVersion.Platform
        //    switch (_MajorVersion)
        //    {
        //        case 5:
        //            return "Windows XP";
        //        case 6:
        //            switch (Environment.OSVersion.Version.Minor)
        //            {
        //                case 0:
        //                    return "Windows Vista";
        //                case 1:
        //                    return "Windows 7";
        //                default:
        //                    return "Windows Vista & above";
        //            }
        //        default:
        //            return "Unknown";
        //    }
        //}

        //---- GSG (12/11/2019) HA DEJADO DE FUNCIONAR IsWow64Process
        
        private static bool IsWin64(Process process)
        {
            if ((Environment.OSVersion.Version.Major > 5) || 
                ((Environment.OSVersion.Version.Major == 5) && (Environment.OSVersion.Version.Minor >= 1)))
            {
                IntPtr processHandle;
                bool retVal = false;
                try
                {
                    processHandle = Process.GetProcessById(process.Id).Handle;
                }
                catch 
                {
                    return false; // access is denied to the process 
                }


                //---- GSG (12/11/2019) HA DEJADO DE FUNCIONAR IsWow64Process
                
                //retVal is set to TRUE if the process is running under WOW64 on an Intel64 or x64 processor. 
                //retVal is set to FALSE if the process is running under 32 - bit Windows. 
                //retVal is set to FALSE if the process is a 32 - bit application running under 64 - bit Windows 10 on ARM. 
                //retVal is set to FALSE if the process is a 64 - bit application running under 64 - bit Windows.
                if (!IsWow64Process(processHandle, out retVal))
                {
                    return false; // function failed 
                }
                
                return retVal;

            }
            return false; // not on 64-bit Windows
        }
        
               
        [DllImport("kernel32.dll", SetLastError = true, CallingConvention = CallingConvention.Winapi)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsWow64Process(
            [In] IntPtr hProcess,
            [Out] out bool wow64Process
        );


        #endregion

    }
}
