using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Collections.Generic;
using GESTCRM.Clases;

namespace GESTCRM.Formularios
{   

    /// <summary>
    /// Descripción breve de Form1.
    /// </summary>
    public class frmConsultaVisit : System.Windows.Forms.Form
    {
        //---- GSG (20/06/2016)
        const int _K_LOC_X = 269;
        const int _K_LOC_Y = 44;


        string Var_TipoAcceso;
        int Var_CambioFecha;
        DataTable dtDias;
        GESTCRM.MiDataGrid dgActivo;
        int diaActivo;
        int IdDelegado;

        int iIdDelegado_BuscarAgenda;
        DateTime Fecha_BuscarAgenda;

        

        protected System.Data.SqlClient.SqlTransaction sqlTran;

        private System.Windows.Forms.ContextMenu cntMnuReporteActividad;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Data.SqlClient.SqlConnection sqlConn;
        private System.Data.SqlClient.SqlDataAdapter sqldaListaRepActividad_Cab;
        private DateTime dFecha;
        private System.Windows.Forms.Panel pnSemana;
        private GESTCRM.MiDataGrid dgSemana1;
        private GESTCRM.MiDataGrid dgSemana3;
        private GESTCRM.MiDataGrid dgSemana2;
        private GESTCRM.MiDataGrid dgSemana6;
        private GESTCRM.MiDataGrid dgSemana5;
        private GESTCRM.MiDataGrid dgSemana4;
        private GESTCRM.MiDataGrid dgSemana7;
        private System.Windows.Forms.Panel pnDatos;
        private System.Windows.Forms.DateTimePicker dtpCalendario;
        private System.Windows.Forms.Label lblCalendario;
        private System.Windows.Forms.Button btMensual;
        private System.Windows.Forms.Button btSemanal;
        private System.Windows.Forms.Button btDiario;
        private System.Windows.Forms.Button btMas;
        private System.Windows.Forms.Button btMenos;
        private System.Windows.Forms.Panel pnMensual;
        private System.Windows.Forms.Label lblMes42;
        private System.Windows.Forms.Label lblMes32;
        private System.Windows.Forms.Label lblMes13;
        private System.Windows.Forms.Label lblMes22;
        private System.Windows.Forms.Label lblMes12;
        private System.Windows.Forms.Label lblMes21;
        private System.Windows.Forms.Label lblMes11;
        private System.Windows.Forms.Label lblMes14;
        private System.Windows.Forms.Label lblMes15;
        private System.Windows.Forms.Label lblMes31;
        private System.Windows.Forms.Label lblMes41;
        private System.Windows.Forms.Label lblMes51;
        private System.Windows.Forms.Label lblMes61;
        private System.Windows.Forms.Label lblMes52;
        private System.Windows.Forms.Label lblMes62;
        private System.Windows.Forms.Label lblMes23;
        private System.Windows.Forms.Label lblMes33;
        private System.Windows.Forms.Label lblMes43;
        private System.Windows.Forms.Label lblMes53;
        private System.Windows.Forms.Label lblMes63;
        private System.Windows.Forms.Label lblMes24;
        private System.Windows.Forms.Label lblMes34;
        private System.Windows.Forms.Label lblMes44;
        private System.Windows.Forms.Label lblMes54;
        private System.Windows.Forms.Label lblMes64;
        private System.Windows.Forms.Label lblMes25;
        private System.Windows.Forms.Label lblMes35;
        private System.Windows.Forms.Label lblMes45;
        private System.Windows.Forms.Label lblMes55;
        private System.Windows.Forms.Label lblMes65;
        private GESTCRM.MiDataGrid dgMes11;
        private GESTCRM.MiDataGrid dgMes22;
        private GESTCRM.MiDataGrid dgMes61;
        private GESTCRM.MiDataGrid dgMes15;
        private GESTCRM.MiDataGrid dgMes12;
        private GESTCRM.MiDataGrid dgMes45;
        private GESTCRM.MiDataGrid dgMes35;
        private GESTCRM.MiDataGrid dgMes25;
        private GESTCRM.MiDataGrid dgMes54;
        private GESTCRM.MiDataGrid dgMes44;
        private GESTCRM.MiDataGrid dgMes34;
        private GESTCRM.MiDataGrid dgMes24;
        private GESTCRM.MiDataGrid dgMes63;
        private GESTCRM.MiDataGrid dgMes33;
        private GESTCRM.MiDataGrid dgMes23;
        private GESTCRM.MiDataGrid dgMes62;
        private GESTCRM.MiDataGrid dgMes52;
        private GESTCRM.MiDataGrid dgMes51;
        private GESTCRM.MiDataGrid dgMes41;
        private GESTCRM.MiDataGrid dgMes31;
        private GESTCRM.MiDataGrid dgMes14;
        private GESTCRM.MiDataGrid dgMes42;
        private GESTCRM.MiDataGrid dgMes32;
        private GESTCRM.MiDataGrid dgMes21;
        private GESTCRM.MiDataGrid dgMes13;
        private GESTCRM.MiDataGrid dgMes65;
        private GESTCRM.MiDataGrid dgMes64;
        private GESTCRM.MiDataGrid dgMes53;
        private GESTCRM.MiDataGrid dgMes43;
        private GESTCRM.MiDataGrid dgMes55;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle7;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn19;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn20;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn21;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle8;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn22;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn23;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn24;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle9;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn25;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn26;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn27;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle10;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn28;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn29;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn30;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle11;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn31;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn32;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn33;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle2;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn5;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn6;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle4;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn10;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn11;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn12;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle5;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn13;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn14;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn15;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle12;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn34;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn35;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn36;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle13;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn37;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn38;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn39;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle14;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn40;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn41;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn42;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle3;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn7;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn8;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn9;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle16;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn46;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn47;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn48;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle15;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn43;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn44;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn45;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle17;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn49;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn50;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn51;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle18;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn52;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn53;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn54;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle19;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn55;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn56;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn57;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle20;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn58;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn59;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn60;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle21;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn61;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn62;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn63;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle22;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn64;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn65;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn66;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle23;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn67;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn68;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn69;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle24;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn70;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn71;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn72;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle25;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn73;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn74;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn75;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle26;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn76;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn77;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn78;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle27;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn79;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn80;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn81;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle28;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn82;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn83;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn84;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle29;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn85;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn86;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn87;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle31;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn91;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn92;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn93;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle32;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn94;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn95;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn96;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle34;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn100;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn101;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn102;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle35;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn103;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn104;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn105;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle36;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn106;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn107;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn108;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle37;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn109;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn110;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn111;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel pnDiario;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle33;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn97;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn98;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn99;
        //		private System.Windows.Forms.DataGrid dgDiario;
        private GESTCRM.MiDataGrid dgDiario;
        private System.Windows.Forms.Label lblDelegado;
        private System.Windows.Forms.ComboBox cbDelegado;
        private System.Data.SqlClient.SqlDataAdapter sqldaListaDelegados;
        private System.Data.SqlClient.SqlCommand sqlCommand1;
        private System.Windows.Forms.ContextMenu cntMnuDataGrid;
        private System.Windows.Forms.MenuItem cntMnuEditar;
        private System.Windows.Forms.MenuItem cntMnuNuevo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblMes66;
        private System.Windows.Forms.Label lblMes56;
        private System.Windows.Forms.Label lblMes46;
        private System.Windows.Forms.Label lblMes36;
        private System.Windows.Forms.Label lblMes26;
        private System.Windows.Forms.Label lblMes16;
        private GESTCRM.MiDataGrid dgMes16;
        private GESTCRM.MiDataGrid dgMes26;
        private GESTCRM.MiDataGrid dgMes36;
        private GESTCRM.MiDataGrid dgMes46;
        private GESTCRM.MiDataGrid dgMes56;
        private GESTCRM.MiDataGrid dgMes66;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle39;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn115;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn116;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn117;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle40;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn118;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn119;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn120;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle41;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn121;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn122;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn123;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle42;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn124;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn125;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn126;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle43;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn127;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn128;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn129;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle38;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn112;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn113;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn114;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle30;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn88;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn89;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn90;
        private System.Windows.Forms.Label lblPnMes;
        private System.Windows.Forms.MenuItem cntMnuEliminar;
        private System.Data.SqlClient.SqlCommand sqlcmdSetRepActividad_Cab;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn130;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn131;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn132;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn133;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn134;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn135;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn136;
        private GESTCRM.Controles.ucBotoneraSecundaria ucBotoneraSecundaria1;
        private System.Data.SqlClient.SqlDataAdapter sqldaListaRepActividad_ProxObj;
        private System.Windows.Forms.Label lblTotProxObj;
        private System.Windows.Forms.DataGrid dgClientesProxObj;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle6;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn16;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn17;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn18;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn137;
        private System.Data.SqlClient.SqlCommand sqlSelectCommand2;
        private GESTCRM.Controles.LabelGradient lblObjetivos;
        private GESTCRM.Controles.LabelGradient lblMes;
        private GESTCRM.Controles.LabelGradient lblMesLunes;
        private GESTCRM.Controles.LabelGradient lblMesMartes;
        private GESTCRM.Controles.LabelGradient lblMesMiercoles;
        private GESTCRM.Controles.LabelGradient lblMesJueves;
        private GESTCRM.Controles.LabelGradient lblMesViernes;
        private GESTCRM.Controles.LabelGradient lblSabDom;
        private GESTCRM.Controles.LabelGradient lblSemana1;
        private GESTCRM.Controles.LabelGradient lblSemana4;
        private GESTCRM.Controles.LabelGradient lblSemana7;
        private GESTCRM.Controles.LabelGradient lblSemana6;
        private GESTCRM.Controles.LabelGradient lblSemana3;
        private GESTCRM.Controles.LabelGradient lblSemana2;
        private GESTCRM.Controles.LabelGradient lblSemana5;
        private GESTCRM.Controles.LabelGradient lblDiario;
        private GESTCRM.Formularios.DataSets.dsReports dsReports1;
        private System.Data.SqlClient.SqlDataAdapter sqldaListaRepActividad_Obsevaciones;
        private System.Data.SqlClient.SqlCommand sqlSelectCommand3;
        private System.Windows.Forms.Panel pnDatosDiario;
        private System.Windows.Forms.Panel pnProxObj;
        private System.Windows.Forms.TextBox txtDiaObserv;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btGuardarObserv;
        private System.Windows.Forms.ImageList imageList1;
        private GESTCRM.Controles.LabelGradient labelGradient1;
        private System.Windows.Forms.DataGrid dgObservaciones;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle44;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn138;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn139;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn140;
        private System.Windows.Forms.TextBox txtObservRep;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnObservaciones;
        private System.Windows.Forms.Label lblTotObserv;
        private System.Data.SqlClient.SqlDataAdapter sqldaListaAgendaObserv;
        private System.Data.SqlClient.SqlCommand sqlSelectCommand4;
        private System.Data.SqlClient.SqlCommand sqlCmdSetAgendaObserv;
        private System.Data.SqlClient.SqlCommand sqlCmdGetPuedeBorrarReport;
        private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
        private System.Data.SqlClient.SqlCommand sqlCmdGetVisitaDePlanif; //---- GSG (13/03/2019)
        private PictureBox pictureBoxArrastro;
        public object origenes;

        //		private GESTCRM.Clases.Configuracion config;
        private System.ComponentModel.IContainer components;

        public frmConsultaVisit()
        {

            InitializeComponent();

            //---- GSG (06/03/2021)
            Utiles.GetConfigConnection(); 
            this.sqlConn.ConnectionString = Utiles._connection.ConnectionString.ToString();


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

        #region Código generado por el Diseñador de Windows Forms
        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsultaVisit));
            this.cntMnuReporteActividad = new System.Windows.Forms.ContextMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.cntMnuDataGrid = new System.Windows.Forms.ContextMenu();
            this.cntMnuEditar = new System.Windows.Forms.MenuItem();
            this.cntMnuNuevo = new System.Windows.Forms.MenuItem();
            this.cntMnuEliminar = new System.Windows.Forms.MenuItem();
            this.sqlConn = new System.Data.SqlClient.SqlConnection();
            this.sqldaListaRepActividad_Cab = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
            this.pnSemana = new System.Windows.Forms.Panel();
            this.dgSemana7 = new GESTCRM.MiDataGrid();
            this.dataGridTableStyle37 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn109 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn110 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn111 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn136 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dgSemana6 = new GESTCRM.MiDataGrid();
            this.dataGridTableStyle36 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn106 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn107 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn108 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn135 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dgSemana5 = new GESTCRM.MiDataGrid();
            this.dataGridTableStyle34 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn100 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn101 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn102 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn131 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dgSemana4 = new GESTCRM.MiDataGrid();
            this.dataGridTableStyle32 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn94 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn95 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn96 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn133 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dgSemana3 = new GESTCRM.MiDataGrid();
            this.dataGridTableStyle35 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn103 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn104 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn105 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn134 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dgSemana1 = new GESTCRM.MiDataGrid();
            this.dataGridTableStyle31 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn91 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn92 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn93 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn132 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dgSemana2 = new GESTCRM.MiDataGrid();
            this.dataGridTableStyle33 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn97 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn98 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn99 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn130 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.lblSemana1 = new GESTCRM.Controles.LabelGradient();
            this.lblSemana4 = new GESTCRM.Controles.LabelGradient();
            this.lblSemana2 = new GESTCRM.Controles.LabelGradient();
            this.lblSemana5 = new GESTCRM.Controles.LabelGradient();
            this.lblSemana3 = new GESTCRM.Controles.LabelGradient();
            this.lblSemana6 = new GESTCRM.Controles.LabelGradient();
            this.lblSemana7 = new GESTCRM.Controles.LabelGradient();
            this.dgDiario = new GESTCRM.MiDataGrid();
            this.pnDatos = new System.Windows.Forms.Panel();
            this.btMenos = new System.Windows.Forms.Button();
            this.btMas = new System.Windows.Forms.Button();
            this.btMensual = new System.Windows.Forms.Button();
            this.btSemanal = new System.Windows.Forms.Button();
            this.btDiario = new System.Windows.Forms.Button();
            this.lblDelegado = new System.Windows.Forms.Label();
            this.cbDelegado = new System.Windows.Forms.ComboBox();
            this.dsReports1 = new GESTCRM.Formularios.DataSets.dsReports();
            this.dtpCalendario = new System.Windows.Forms.DateTimePicker();
            this.lblCalendario = new System.Windows.Forms.Label();
            this.pnMensual = new System.Windows.Forms.Panel();
            this.lblMes42 = new System.Windows.Forms.Label();
            this.lblMes32 = new System.Windows.Forms.Label();
            this.lblMes12 = new System.Windows.Forms.Label();
            this.lblMes22 = new System.Windows.Forms.Label();
            this.lblMes61 = new System.Windows.Forms.Label();
            this.lblPnMes = new System.Windows.Forms.Label();
            this.dgMes66 = new GESTCRM.MiDataGrid();
            this.dataGridTableStyle42 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn124 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn125 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn126 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dgMes56 = new GESTCRM.MiDataGrid();
            this.dataGridTableStyle41 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn121 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn122 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn123 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dgMes46 = new GESTCRM.MiDataGrid();
            this.dataGridTableStyle40 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn118 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn119 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn120 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dgMes36 = new GESTCRM.MiDataGrid();
            this.dataGridTableStyle39 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn115 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn116 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn117 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dgMes26 = new GESTCRM.MiDataGrid();
            this.dataGridTableStyle38 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn112 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn113 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn114 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dgMes16 = new GESTCRM.MiDataGrid();
            this.dataGridTableStyle43 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn127 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn128 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn129 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.lblMes66 = new System.Windows.Forms.Label();
            this.lblMes56 = new System.Windows.Forms.Label();
            this.lblMes46 = new System.Windows.Forms.Label();
            this.lblMes36 = new System.Windows.Forms.Label();
            this.lblMes26 = new System.Windows.Forms.Label();
            this.lblMes16 = new System.Windows.Forms.Label();
            this.dgMes65 = new GESTCRM.MiDataGrid();
            this.dataGridTableStyle30 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn88 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn89 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn90 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.lblMes65 = new System.Windows.Forms.Label();
            this.dgMes55 = new GESTCRM.MiDataGrid();
            this.dataGridTableStyle29 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn85 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn86 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn87 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.lblMes55 = new System.Windows.Forms.Label();
            this.dgMes45 = new GESTCRM.MiDataGrid();
            this.dataGridTableStyle28 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn82 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn83 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn84 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.lblMes45 = new System.Windows.Forms.Label();
            this.dgMes35 = new GESTCRM.MiDataGrid();
            this.dataGridTableStyle27 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn79 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn80 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn81 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.lblMes35 = new System.Windows.Forms.Label();
            this.dgMes25 = new GESTCRM.MiDataGrid();
            this.dataGridTableStyle26 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn76 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn77 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn78 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.lblMes25 = new System.Windows.Forms.Label();
            this.dgMes64 = new GESTCRM.MiDataGrid();
            this.dataGridTableStyle24 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn70 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn71 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn72 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.lblMes64 = new System.Windows.Forms.Label();
            this.dgMes54 = new GESTCRM.MiDataGrid();
            this.dataGridTableStyle23 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn67 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn68 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn69 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.lblMes54 = new System.Windows.Forms.Label();
            this.dgMes44 = new GESTCRM.MiDataGrid();
            this.dataGridTableStyle22 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn64 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn65 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn66 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.lblMes44 = new System.Windows.Forms.Label();
            this.dgMes34 = new GESTCRM.MiDataGrid();
            this.dataGridTableStyle21 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn61 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn62 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn63 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.lblMes34 = new System.Windows.Forms.Label();
            this.dgMes24 = new GESTCRM.MiDataGrid();
            this.dataGridTableStyle20 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn58 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn59 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn60 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.lblMes24 = new System.Windows.Forms.Label();
            this.dgMes63 = new GESTCRM.MiDataGrid();
            this.dataGridTableStyle18 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn52 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn53 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn54 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.lblMes63 = new System.Windows.Forms.Label();
            this.dgMes53 = new GESTCRM.MiDataGrid();
            this.dataGridTableStyle17 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn49 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn50 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn51 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.lblMes53 = new System.Windows.Forms.Label();
            this.dgMes43 = new GESTCRM.MiDataGrid();
            this.dataGridTableStyle15 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn43 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn44 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn45 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.lblMes43 = new System.Windows.Forms.Label();
            this.dgMes33 = new GESTCRM.MiDataGrid();
            this.dataGridTableStyle16 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn46 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn47 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn48 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.lblMes33 = new System.Windows.Forms.Label();
            this.dgMes23 = new GESTCRM.MiDataGrid();
            this.dataGridTableStyle3 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn7 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn8 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn9 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.lblMes23 = new System.Windows.Forms.Label();
            this.dgMes62 = new GESTCRM.MiDataGrid();
            this.dataGridTableStyle13 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn37 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn38 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn39 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.lblMes62 = new System.Windows.Forms.Label();
            this.dgMes52 = new GESTCRM.MiDataGrid();
            this.dataGridTableStyle12 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn34 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn35 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn36 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.lblMes52 = new System.Windows.Forms.Label();
            this.dgMes61 = new GESTCRM.MiDataGrid();
            this.dataGridTableStyle10 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn28 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn29 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn30 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.lblMes51 = new System.Windows.Forms.Label();
            this.lblMes41 = new System.Windows.Forms.Label();
            this.lblMes31 = new System.Windows.Forms.Label();
            this.dgMes15 = new GESTCRM.MiDataGrid();
            this.dataGridTableStyle25 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn73 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn74 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn75 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.lblMes15 = new System.Windows.Forms.Label();
            this.dgMes14 = new GESTCRM.MiDataGrid();
            this.dataGridTableStyle19 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn55 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn56 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn57 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.lblMes14 = new System.Windows.Forms.Label();
            this.dgMes42 = new GESTCRM.MiDataGrid();
            this.dgMes32 = new GESTCRM.MiDataGrid();
            this.dataGridTableStyle5 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn13 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn14 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn15 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dgMes22 = new GESTCRM.MiDataGrid();
            this.dataGridTableStyle4 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn10 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn11 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn12 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dgMes13 = new GESTCRM.MiDataGrid();
            this.dataGridTableStyle14 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn40 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn41 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn42 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.lblMes13 = new System.Windows.Forms.Label();
            this.lblMes21 = new System.Windows.Forms.Label();
            this.lblMes11 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblMes = new GESTCRM.Controles.LabelGradient();
            this.lblMesLunes = new GESTCRM.Controles.LabelGradient();
            this.lblMesMartes = new GESTCRM.Controles.LabelGradient();
            this.lblMesMiercoles = new GESTCRM.Controles.LabelGradient();
            this.lblMesJueves = new GESTCRM.Controles.LabelGradient();
            this.lblMesViernes = new GESTCRM.Controles.LabelGradient();
            this.lblSabDom = new GESTCRM.Controles.LabelGradient();
            this.dgMes31 = new GESTCRM.MiDataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dgMes41 = new GESTCRM.MiDataGrid();
            this.dataGridTableStyle8 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn22 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn23 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn24 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dgMes51 = new GESTCRM.MiDataGrid();
            this.dataGridTableStyle9 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn25 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn26 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn27 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dgMes12 = new GESTCRM.MiDataGrid();
            this.dataGridTableStyle11 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn31 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn32 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn33 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dgMes21 = new GESTCRM.MiDataGrid();
            this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn5 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn6 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dgMes11 = new GESTCRM.MiDataGrid();
            this.dataGridTableStyle7 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn19 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn20 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn21 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pnDiario = new System.Windows.Forms.Panel();
            this.pnDatosDiario = new System.Windows.Forms.Panel();
            this.pnObservaciones = new System.Windows.Forms.Panel();
            this.lblTotObserv = new System.Windows.Forms.Label();
            this.txtObservRep = new System.Windows.Forms.TextBox();
            this.dgObservaciones = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle44 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn138 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn139 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn140 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.labelGradient1 = new GESTCRM.Controles.LabelGradient();
            this.label3 = new System.Windows.Forms.Label();
            this.btGuardarObserv = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.txtDiaObserv = new System.Windows.Forms.TextBox();
            this.pnProxObj = new System.Windows.Forms.Panel();
            this.dgClientesProxObj = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle6 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn16 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn17 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn18 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn137 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.lblTotProxObj = new System.Windows.Forms.Label();
            this.lblObjetivos = new GESTCRM.Controles.LabelGradient();
            this.label2 = new System.Windows.Forms.Label();
            this.lblDiario = new GESTCRM.Controles.LabelGradient();
            this.pictureBoxArrastro = new System.Windows.Forms.PictureBox();
            this.sqldaListaDelegados = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlcmdSetRepActividad_Cab = new System.Data.SqlClient.SqlCommand();
            this.ucBotoneraSecundaria1 = new GESTCRM.Controles.ucBotoneraSecundaria();
            this.sqldaListaRepActividad_ProxObj = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
            this.sqldaListaRepActividad_Obsevaciones = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
            this.sqldaListaAgendaObserv = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand4 = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdSetAgendaObserv = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdGetPuedeBorrarReport = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdGetVisitaDePlanif = new System.Data.SqlClient.SqlCommand();
            this.pnSemana.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgSemana7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgSemana6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgSemana5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgSemana4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgSemana3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgSemana1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgSemana2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgDiario)).BeginInit();
            this.pnDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsReports1)).BeginInit();
            this.pnMensual.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgMes66)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMes56)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMes46)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMes36)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMes26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMes16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMes65)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMes55)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMes45)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMes35)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMes25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMes64)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMes54)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMes44)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMes34)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMes24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMes63)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMes53)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMes43)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMes33)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMes23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMes62)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMes52)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMes61)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMes15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMes14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMes42)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMes32)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMes22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMes13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMes31)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMes41)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMes51)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMes12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMes21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMes11)).BeginInit();
            this.pnDiario.SuspendLayout();
            this.pnDatosDiario.SuspendLayout();
            this.pnObservaciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgObservaciones)).BeginInit();
            this.pnProxObj.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgClientesProxObj)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxArrastro)).BeginInit();
            this.SuspendLayout();
            // 
            // cntMnuReporteActividad
            // 
            this.cntMnuReporteActividad.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem2});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.Text = "Eliminar";
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 1;
            this.menuItem2.Text = "Actualizar";
            // 
            // cntMnuDataGrid
            // 
            this.cntMnuDataGrid.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.cntMnuEditar,
            this.cntMnuNuevo,
            this.cntMnuEliminar});
            // 
            // cntMnuEditar
            // 
            this.cntMnuEditar.Index = 0;
            this.cntMnuEditar.Text = "Editar";
            this.cntMnuEditar.Click += new System.EventHandler(this.cntMnuEditar_Click);
            // 
            // cntMnuNuevo
            // 
            this.cntMnuNuevo.Index = 1;
            this.cntMnuNuevo.Text = "Nuevo";
            this.cntMnuNuevo.Click += new System.EventHandler(this.cntMnuNuevo_Click);
            // 
            // cntMnuEliminar
            // 
            this.cntMnuEliminar.Index = 2;
            this.cntMnuEliminar.Text = "Eliminar";
            this.cntMnuEliminar.Click += new System.EventHandler(this.cntMnuEliminar_Click);
            // 
            // sqlConn
            // 
            this.sqlConn.FireInfoMessageEventOnUserErrors = false;
            // 
            // sqldaListaRepActividad_Cab
            // 
            this.sqldaListaRepActividad_Cab.SelectCommand = this.sqlSelectCommand1;
            this.sqldaListaRepActividad_Cab.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaRepActividad_Cab", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iIdReport", "iIdReport"),
                        new System.Data.Common.DataColumnMapping("iIdDelegado", "iIdDelegado"),
                        new System.Data.Common.DataColumnMapping("sIdReportTemp", "sIdReportTemp"),
                        new System.Data.Common.DataColumnMapping("sTipoRActividad", "sTipoRActividad"),
                        new System.Data.Common.DataColumnMapping("descTipoRActividad", "descTipoRActividad"),
                        new System.Data.Common.DataColumnMapping("sIdTipoCliente", "sIdTipoCliente"),
                        new System.Data.Common.DataColumnMapping("descTipoCliente", "descTipoCliente"),
                        new System.Data.Common.DataColumnMapping("iIdCentro", "iIdCentro"),
                        new System.Data.Common.DataColumnMapping("dFecha", "dFecha"),
                        new System.Data.Common.DataColumnMapping("iHorario", "iHorario"),
                        new System.Data.Common.DataColumnMapping("tHorario", "tHorario"),
                        new System.Data.Common.DataColumnMapping("tObservaciones", "tObservaciones"),
                        new System.Data.Common.DataColumnMapping("dFUM", "dFUM"),
                        new System.Data.Common.DataColumnMapping("iEstado", "iEstado"),
                        new System.Data.Common.DataColumnMapping("bEnviadoCEN", "bEnviadoCEN"),
                        new System.Data.Common.DataColumnMapping("sNombre", "sNombre"),
                        new System.Data.Common.DataColumnMapping("bPlanificacion", "bPlanificacion"),
                        new System.Data.Common.DataColumnMapping("Planif", "Planif"),
                        new System.Data.Common.DataColumnMapping("ProxObj", "ProxObj"),
                        new System.Data.Common.DataColumnMapping("sIdCentro", "sIdCentro"),
                        new System.Data.Common.DataColumnMapping("sDescripcion", "sDescripcion"),
                        new System.Data.Common.DataColumnMapping("iIdCliente", "iIdCliente"),
                        new System.Data.Common.DataColumnMapping("Orden", "Orden")})});
            // 
            // sqlSelectCommand1
            // 
            this.sqlSelectCommand1.CommandText = "[ListaRepActividad_Cab]";
            this.sqlSelectCommand1.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand1.Connection = this.sqlConn;
            this.sqlSelectCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdDelegado", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@dFechaIni", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@dFechaFin", System.Data.SqlDbType.DateTime, 8)});
            // 
            // pnSemana
            // 
            this.pnSemana.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnSemana.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnSemana.Controls.Add(this.dgSemana7);
            this.pnSemana.Controls.Add(this.dgSemana6);
            this.pnSemana.Controls.Add(this.dgSemana5);
            this.pnSemana.Controls.Add(this.dgSemana4);
            this.pnSemana.Controls.Add(this.dgSemana3);
            this.pnSemana.Controls.Add(this.dgSemana1);
            this.pnSemana.Controls.Add(this.dgSemana2);
            this.pnSemana.Controls.Add(this.lblSemana1);
            this.pnSemana.Controls.Add(this.lblSemana4);
            this.pnSemana.Controls.Add(this.lblSemana2);
            this.pnSemana.Controls.Add(this.lblSemana5);
            this.pnSemana.Controls.Add(this.lblSemana3);
            this.pnSemana.Controls.Add(this.lblSemana6);
            this.pnSemana.Controls.Add(this.lblSemana7);
            this.pnSemana.ForeColor = System.Drawing.Color.Black;
            this.pnSemana.Location = new System.Drawing.Point(1, 992);
            this.pnSemana.Name = "pnSemana";
            this.pnSemana.Size = new System.Drawing.Size(1492, 700);
            this.pnSemana.TabIndex = 2;
            this.pnSemana.Visible = false;
            // 
            // dgSemana7
            // 
            this.dgSemana7.BackgroundColor = System.Drawing.Color.White;
            this.dgSemana7.CaptionVisible = false;
            this.dgSemana7.ColumnHeadersVisible = false;
            this.dgSemana7.DataMember = "";
            this.dgSemana7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.dgSemana7.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dgSemana7.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgSemana7.Location = new System.Drawing.Point(7, 114);
            this.dgSemana7.Name = "dgSemana7";
            this.dgSemana7.ParentRowsVisible = false;
            this.dgSemana7.Size = new System.Drawing.Size(760, 105);
            this.dgSemana7.TabIndex = 6;
            this.dgSemana7.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle37});
            this.dgSemana7.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgSemana7_MouseUp);
            // 
            // dataGridTableStyle37
            // 
            this.dataGridTableStyle37.DataGrid = this.dgSemana7;
            this.dataGridTableStyle37.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn109,
            this.dataGridTextBoxColumn110,
            this.dataGridTextBoxColumn111,
            this.dataGridTextBoxColumn136});
            this.dataGridTableStyle37.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // dataGridTextBoxColumn109
            // 
            this.dataGridTextBoxColumn109.Format = "";
            this.dataGridTextBoxColumn109.FormatInfo = null;
            this.dataGridTextBoxColumn109.Width = 120;
            // 
            // dataGridTextBoxColumn110
            // 
            this.dataGridTextBoxColumn110.Format = "";
            this.dataGridTextBoxColumn110.FormatInfo = null;
            this.dataGridTextBoxColumn110.Width = 120;
            // 
            // dataGridTextBoxColumn111
            // 
            this.dataGridTextBoxColumn111.Format = "";
            this.dataGridTextBoxColumn111.FormatInfo = null;
            this.dataGridTextBoxColumn111.Width = 120;
            // 
            // dataGridTextBoxColumn136
            // 
            this.dataGridTextBoxColumn136.Format = "";
            this.dataGridTextBoxColumn136.FormatInfo = null;
            this.dataGridTextBoxColumn136.Width = 120;
            // 
            // dgSemana6
            // 
            this.dgSemana6.BackgroundColor = System.Drawing.Color.White;
            this.dgSemana6.CaptionVisible = false;
            this.dgSemana6.ColumnHeadersVisible = false;
            this.dgSemana6.DataMember = "";
            this.dgSemana6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.dgSemana6.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dgSemana6.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgSemana6.Location = new System.Drawing.Point(7, 18);
            this.dgSemana6.Name = "dgSemana6";
            this.dgSemana6.ParentRowsVisible = false;
            this.dgSemana6.Size = new System.Drawing.Size(760, 75);
            this.dgSemana6.TabIndex = 5;
            this.dgSemana6.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle36});
            this.dgSemana6.Scroll += new System.EventHandler(this.dgSemana6_Scroll);
            this.dgSemana6.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgSemana6_MouseUp);
            // 
            // dataGridTableStyle36
            // 
            this.dataGridTableStyle36.DataGrid = this.dgSemana6;
            this.dataGridTableStyle36.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn106,
            this.dataGridTextBoxColumn107,
            this.dataGridTextBoxColumn108,
            this.dataGridTextBoxColumn135});
            this.dataGridTableStyle36.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // dataGridTextBoxColumn106
            // 
            this.dataGridTextBoxColumn106.Format = "";
            this.dataGridTextBoxColumn106.FormatInfo = null;
            this.dataGridTextBoxColumn106.Width = 120;
            // 
            // dataGridTextBoxColumn107
            // 
            this.dataGridTextBoxColumn107.Format = "";
            this.dataGridTextBoxColumn107.FormatInfo = null;
            this.dataGridTextBoxColumn107.Width = 120;
            // 
            // dataGridTextBoxColumn108
            // 
            this.dataGridTextBoxColumn108.Format = "";
            this.dataGridTextBoxColumn108.FormatInfo = null;
            this.dataGridTextBoxColumn108.Width = 120;
            // 
            // dataGridTextBoxColumn135
            // 
            this.dataGridTextBoxColumn135.Format = "";
            this.dataGridTextBoxColumn135.FormatInfo = null;
            this.dataGridTextBoxColumn135.Width = 120;
            // 
            // dgSemana5
            // 
            this.dgSemana5.AllowDrop = true;
            this.dgSemana5.BackgroundColor = System.Drawing.Color.White;
            this.dgSemana5.CaptionVisible = false;
            this.dgSemana5.ColumnHeadersVisible = false;
            this.dgSemana5.DataMember = "";
            this.dgSemana5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.dgSemana5.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dgSemana5.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgSemana5.Location = new System.Drawing.Point(780, 457);
            this.dgSemana5.Name = "dgSemana5";
            this.dgSemana5.ParentRowsVisible = false;
            this.dgSemana5.Size = new System.Drawing.Size(760, 200);
            this.dgSemana5.TabIndex = 3;
            this.dgSemana5.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle34});
            this.dgSemana5.DragDrop += new System.Windows.Forms.DragEventHandler(this.dgSemana5_DragDrop);
            this.dgSemana5.DragEnter += new System.Windows.Forms.DragEventHandler(this.dgSemana5_DragEnter);
            this.dgSemana5.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgSemana5_MouseUp);
            // 
            // dataGridTableStyle34
            // 
            this.dataGridTableStyle34.DataGrid = this.dgSemana5;
            this.dataGridTableStyle34.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn100,
            this.dataGridTextBoxColumn101,
            this.dataGridTextBoxColumn102,
            this.dataGridTextBoxColumn131});
            this.dataGridTableStyle34.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // dataGridTextBoxColumn100
            // 
            this.dataGridTextBoxColumn100.Format = "";
            this.dataGridTextBoxColumn100.FormatInfo = null;
            this.dataGridTextBoxColumn100.Width = 120;
            // 
            // dataGridTextBoxColumn101
            // 
            this.dataGridTextBoxColumn101.Format = "";
            this.dataGridTextBoxColumn101.FormatInfo = null;
            this.dataGridTextBoxColumn101.Width = 120;
            // 
            // dataGridTextBoxColumn102
            // 
            this.dataGridTextBoxColumn102.Format = "";
            this.dataGridTextBoxColumn102.FormatInfo = null;
            this.dataGridTextBoxColumn102.Width = 120;
            // 
            // dataGridTextBoxColumn131
            // 
            this.dataGridTextBoxColumn131.Format = "";
            this.dataGridTextBoxColumn131.FormatInfo = null;
            this.dataGridTextBoxColumn131.Width = 120;
            // 
            // dgSemana4
            // 
            this.dgSemana4.AllowDrop = true;
            this.dgSemana4.BackgroundColor = System.Drawing.Color.White;
            this.dgSemana4.CaptionVisible = false;
            this.dgSemana4.ColumnHeadersVisible = false;
            this.dgSemana4.DataMember = "";
            this.dgSemana4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.dgSemana4.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dgSemana4.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgSemana4.Location = new System.Drawing.Point(780, 237);
            this.dgSemana4.Name = "dgSemana4";
            this.dgSemana4.ParentRowsVisible = false;
            this.dgSemana4.Size = new System.Drawing.Size(760, 200);
            this.dgSemana4.TabIndex = 1;
            this.dgSemana4.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle32});
            this.dgSemana4.DragDrop += new System.Windows.Forms.DragEventHandler(this.dgSemana4_DragDrop);
            this.dgSemana4.DragEnter += new System.Windows.Forms.DragEventHandler(this.dgSemana4_DragEnter);
            this.dgSemana4.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgSemana4_MouseUp);
            // 
            // dataGridTableStyle32
            // 
            this.dataGridTableStyle32.DataGrid = this.dgSemana4;
            this.dataGridTableStyle32.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn94,
            this.dataGridTextBoxColumn95,
            this.dataGridTextBoxColumn96,
            this.dataGridTextBoxColumn133});
            this.dataGridTableStyle32.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // dataGridTextBoxColumn94
            // 
            this.dataGridTextBoxColumn94.Format = "";
            this.dataGridTextBoxColumn94.FormatInfo = null;
            this.dataGridTextBoxColumn94.Width = 120;
            // 
            // dataGridTextBoxColumn95
            // 
            this.dataGridTextBoxColumn95.Format = "";
            this.dataGridTextBoxColumn95.FormatInfo = null;
            this.dataGridTextBoxColumn95.Width = 120;
            // 
            // dataGridTextBoxColumn96
            // 
            this.dataGridTextBoxColumn96.Format = "";
            this.dataGridTextBoxColumn96.FormatInfo = null;
            this.dataGridTextBoxColumn96.Width = 120;
            // 
            // dataGridTextBoxColumn133
            // 
            this.dataGridTextBoxColumn133.Format = "";
            this.dataGridTextBoxColumn133.FormatInfo = null;
            this.dataGridTextBoxColumn133.Width = 120;
            // 
            // dgSemana3
            // 
            this.dgSemana3.AllowDrop = true;
            this.dgSemana3.BackgroundColor = System.Drawing.Color.White;
            this.dgSemana3.CaptionVisible = false;
            this.dgSemana3.ColumnHeadersVisible = false;
            this.dgSemana3.DataMember = "";
            this.dgSemana3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.dgSemana3.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dgSemana3.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgSemana3.Location = new System.Drawing.Point(780, 18);
            this.dgSemana3.Name = "dgSemana3";
            this.dgSemana3.ParentRowsVisible = false;
            this.dgSemana3.Size = new System.Drawing.Size(760, 200);
            this.dgSemana3.TabIndex = 4;
            this.dgSemana3.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle35});
            this.dgSemana3.DragDrop += new System.Windows.Forms.DragEventHandler(this.dgSemana3_DragDrop);
            this.dgSemana3.DragEnter += new System.Windows.Forms.DragEventHandler(this.dgSemana3_DragEnter);
            this.dgSemana3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgSemana3_MouseUp);
            // 
            // dataGridTableStyle35
            // 
            this.dataGridTableStyle35.DataGrid = this.dgSemana3;
            this.dataGridTableStyle35.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn103,
            this.dataGridTextBoxColumn104,
            this.dataGridTextBoxColumn105,
            this.dataGridTextBoxColumn134});
            this.dataGridTableStyle35.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // dataGridTextBoxColumn103
            // 
            this.dataGridTextBoxColumn103.Format = "";
            this.dataGridTextBoxColumn103.FormatInfo = null;
            this.dataGridTextBoxColumn103.Width = 120;
            // 
            // dataGridTextBoxColumn104
            // 
            this.dataGridTextBoxColumn104.Format = "";
            this.dataGridTextBoxColumn104.FormatInfo = null;
            this.dataGridTextBoxColumn104.Width = 120;
            // 
            // dataGridTextBoxColumn105
            // 
            this.dataGridTextBoxColumn105.Format = "";
            this.dataGridTextBoxColumn105.FormatInfo = null;
            this.dataGridTextBoxColumn105.Width = 120;
            // 
            // dataGridTextBoxColumn134
            // 
            this.dataGridTextBoxColumn134.Format = "";
            this.dataGridTextBoxColumn134.FormatInfo = null;
            this.dataGridTextBoxColumn134.Width = 400;
            // 
            // dgSemana1
            // 
            this.dgSemana1.AllowDrop = true;
            this.dgSemana1.BackgroundColor = System.Drawing.Color.White;
            this.dgSemana1.CaptionVisible = false;
            this.dgSemana1.ColumnHeadersVisible = false;
            this.dgSemana1.DataMember = "";
            this.dgSemana1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgSemana1.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dgSemana1.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgSemana1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgSemana1.Location = new System.Drawing.Point(8, 237);
            this.dgSemana1.Name = "dgSemana1";
            this.dgSemana1.ParentRowsVisible = false;
            this.dgSemana1.RowHeadersVisible = false;
            this.dgSemana1.Size = new System.Drawing.Size(760, 200);
            this.dgSemana1.TabIndex = 0;
            this.dgSemana1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle31});
            this.dgSemana1.Tag = "";
            this.dgSemana1.DragDrop += new System.Windows.Forms.DragEventHandler(this.dgSemana1_DragDrop);
            this.dgSemana1.DragEnter += new System.Windows.Forms.DragEventHandler(this.dgSemana1_DragEnter);
            this.dgSemana1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgSemana1_MouseUp);
            // 
            // dataGridTableStyle31
            // 
            this.dataGridTableStyle31.DataGrid = this.dgSemana1;
            this.dataGridTableStyle31.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn91,
            this.dataGridTextBoxColumn92,
            this.dataGridTextBoxColumn93,
            this.dataGridTextBoxColumn132});
            this.dataGridTableStyle31.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // dataGridTextBoxColumn91
            // 
            this.dataGridTextBoxColumn91.Format = "";
            this.dataGridTextBoxColumn91.FormatInfo = null;
            this.dataGridTextBoxColumn91.Width = 120;
            // 
            // dataGridTextBoxColumn92
            // 
            this.dataGridTextBoxColumn92.Format = "";
            this.dataGridTextBoxColumn92.FormatInfo = null;
            this.dataGridTextBoxColumn92.Width = 120;
            // 
            // dataGridTextBoxColumn93
            // 
            this.dataGridTextBoxColumn93.Format = "";
            this.dataGridTextBoxColumn93.FormatInfo = null;
            this.dataGridTextBoxColumn93.Width = 120;
            // 
            // dataGridTextBoxColumn132
            // 
            this.dataGridTextBoxColumn132.Format = "";
            this.dataGridTextBoxColumn132.FormatInfo = null;
            this.dataGridTextBoxColumn132.Width = 400;
            // 
            // dgSemana2
            // 
            this.dgSemana2.AllowDrop = true;
            this.dgSemana2.BackgroundColor = System.Drawing.Color.White;
            this.dgSemana2.CaptionVisible = false;
            this.dgSemana2.ColumnHeadersVisible = false;
            this.dgSemana2.DataMember = "";
            this.dgSemana2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.dgSemana2.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dgSemana2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgSemana2.Location = new System.Drawing.Point(8, 457);
            this.dgSemana2.Name = "dgSemana2";
            this.dgSemana2.ParentRowsVisible = false;
            this.dgSemana2.Size = new System.Drawing.Size(760, 200);
            this.dgSemana2.TabIndex = 2;
            this.dgSemana2.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle33});
            this.dgSemana2.DragDrop += new System.Windows.Forms.DragEventHandler(this.dgSemana2_DragDrop);
            this.dgSemana2.DragEnter += new System.Windows.Forms.DragEventHandler(this.dgSemana2_DragEnter);
            this.dgSemana2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgSemana2_MouseUp);
            // 
            // dataGridTableStyle33
            // 
            this.dataGridTableStyle33.DataGrid = this.dgDiario;
            this.dataGridTableStyle33.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn97,
            this.dataGridTextBoxColumn98,
            this.dataGridTextBoxColumn99,
            this.dataGridTextBoxColumn130});
            this.dataGridTableStyle33.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // dataGridTextBoxColumn97
            // 
            this.dataGridTextBoxColumn97.Format = "";
            this.dataGridTextBoxColumn97.FormatInfo = null;
            this.dataGridTextBoxColumn97.Width = 120;
            // 
            // dataGridTextBoxColumn98
            // 
            this.dataGridTextBoxColumn98.Format = "";
            this.dataGridTextBoxColumn98.FormatInfo = null;
            this.dataGridTextBoxColumn98.Width = 120;
            // 
            // dataGridTextBoxColumn99
            // 
            this.dataGridTextBoxColumn99.Format = "";
            this.dataGridTextBoxColumn99.FormatInfo = null;
            this.dataGridTextBoxColumn99.Width = 120;
            // 
            // dataGridTextBoxColumn130
            // 
            this.dataGridTextBoxColumn130.Format = "";
            this.dataGridTextBoxColumn130.FormatInfo = null;
            this.dataGridTextBoxColumn130.Width = 400;
            // 
            // lblSemana1
            // 
            this.lblSemana1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSemana1.ForeColor = System.Drawing.Color.White;
            this.lblSemana1.GradientColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.lblSemana1.GradientColorTwo = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(223)))), ((int)(((byte)(236)))));
            this.lblSemana1.Location = new System.Drawing.Point(8, 221);
            this.lblSemana1.Name = "lblSemana1";
            this.lblSemana1.Size = new System.Drawing.Size(760, 16);
            this.lblSemana1.TabIndex = 46;
            this.lblSemana1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSemana1.DoubleClick += new System.EventHandler(this.lblSemana1_DoubleClick);
            // 
            // lblSemana4
            // 
            this.lblSemana4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSemana4.ForeColor = System.Drawing.Color.White;
            this.lblSemana4.GradientColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.lblSemana4.GradientColorTwo = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(223)))), ((int)(((byte)(236)))));
            this.lblSemana4.Location = new System.Drawing.Point(780, 221);
            this.lblSemana4.Name = "lblSemana4";
            this.lblSemana4.Size = new System.Drawing.Size(760, 16);
            this.lblSemana4.TabIndex = 45;
            this.lblSemana4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSemana4.DoubleClick += new System.EventHandler(this.lblSemana4_DoubleClick);
            // 
            // lblSemana2
            // 
            this.lblSemana2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSemana2.ForeColor = System.Drawing.Color.White;
            this.lblSemana2.GradientColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.lblSemana2.GradientColorTwo = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(223)))), ((int)(((byte)(236)))));
            this.lblSemana2.Location = new System.Drawing.Point(8, 440);
            this.lblSemana2.Name = "lblSemana2";
            this.lblSemana2.Size = new System.Drawing.Size(760, 16);
            this.lblSemana2.TabIndex = 43;
            this.lblSemana2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSemana2.DoubleClick += new System.EventHandler(this.lblSemana2_DoubleClick);
            // 
            // lblSemana5
            // 
            this.lblSemana5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSemana5.ForeColor = System.Drawing.Color.White;
            this.lblSemana5.GradientColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.lblSemana5.GradientColorTwo = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(223)))), ((int)(((byte)(236)))));
            this.lblSemana5.Location = new System.Drawing.Point(780, 441);
            this.lblSemana5.Name = "lblSemana5";
            this.lblSemana5.Size = new System.Drawing.Size(760, 16);
            this.lblSemana5.TabIndex = 44;
            this.lblSemana5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSemana5.DoubleClick += new System.EventHandler(this.lblSemana5_DoubleClick);
            // 
            // lblSemana3
            // 
            this.lblSemana3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSemana3.ForeColor = System.Drawing.Color.White;
            this.lblSemana3.GradientColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.lblSemana3.GradientColorTwo = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(223)))), ((int)(((byte)(236)))));
            this.lblSemana3.Location = new System.Drawing.Point(780, 2);
            this.lblSemana3.Name = "lblSemana3";
            this.lblSemana3.Size = new System.Drawing.Size(760, 16);
            this.lblSemana3.TabIndex = 42;
            this.lblSemana3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSemana3.DoubleClick += new System.EventHandler(this.lblSemana3_DoubleClick);
            // 
            // lblSemana6
            // 
            this.lblSemana6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSemana6.ForeColor = System.Drawing.Color.White;
            this.lblSemana6.GradientColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.lblSemana6.GradientColorTwo = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(223)))), ((int)(((byte)(236)))));
            this.lblSemana6.Location = new System.Drawing.Point(7, 2);
            this.lblSemana6.Name = "lblSemana6";
            this.lblSemana6.Size = new System.Drawing.Size(760, 16);
            this.lblSemana6.TabIndex = 41;
            this.lblSemana6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSemana6.DoubleClick += new System.EventHandler(this.lblSemana6_DoubleClick);
            // 
            // lblSemana7
            // 
            this.lblSemana7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSemana7.ForeColor = System.Drawing.Color.White;
            this.lblSemana7.GradientColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.lblSemana7.GradientColorTwo = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(223)))), ((int)(((byte)(236)))));
            this.lblSemana7.Location = new System.Drawing.Point(7, 98);
            this.lblSemana7.Name = "lblSemana7";
            this.lblSemana7.Size = new System.Drawing.Size(760, 16);
            this.lblSemana7.TabIndex = 40;
            this.lblSemana7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSemana7.DoubleClick += new System.EventHandler(this.lblSemana7_DoubleClick);
            // 
            // dgDiario
            // 
            this.dgDiario.BackgroundColor = System.Drawing.Color.White;
            this.dgDiario.CaptionVisible = false;
            this.dgDiario.ColumnHeadersVisible = false;
            this.dgDiario.DataMember = "";
            this.dgDiario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgDiario.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dgDiario.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgDiario.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgDiario.Location = new System.Drawing.Point(2, 21);
            this.dgDiario.Name = "dgDiario";
            this.dgDiario.ParentRowsVisible = false;
            this.dgDiario.Size = new System.Drawing.Size(1478, 277);
            this.dgDiario.TabIndex = 0;
            this.dgDiario.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle33});
            this.dgDiario.CurrentCellChanged += new System.EventHandler(this.dgDiario_CurrentCellChanged);
            this.dgDiario.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgDiario_MouseUp);
            // 
            // pnDatos
            // 
            this.pnDatos.BackColor = System.Drawing.Color.Transparent;
            this.pnDatos.Controls.Add(this.btMenos);
            this.pnDatos.Controls.Add(this.btMas);
            this.pnDatos.Controls.Add(this.btMensual);
            this.pnDatos.Controls.Add(this.btSemanal);
            this.pnDatos.Controls.Add(this.btDiario);
            this.pnDatos.ForeColor = System.Drawing.Color.Black;
            this.pnDatos.Location = new System.Drawing.Point(1, 64);
            this.pnDatos.Name = "pnDatos";
            this.pnDatos.Size = new System.Drawing.Size(1245, 32);
            this.pnDatos.TabIndex = 0;
            // 
            // btMenos
            // 
            this.btMenos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btMenos.Image = global::GESTCRM.Properties.Resources.left;
            this.btMenos.Location = new System.Drawing.Point(962, 1);
            this.btMenos.Name = "btMenos";
            this.btMenos.Size = new System.Drawing.Size(133, 28);
            this.btMenos.TabIndex = 2;
            this.btMenos.UseVisualStyleBackColor = true;
            this.btMenos.Click += new System.EventHandler(this.btMenos_Click);
            // 
            // btMas
            // 
            this.btMas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btMas.Image = global::GESTCRM.Properties.Resources.right;
            this.btMas.Location = new System.Drawing.Point(1097, 1);
            this.btMas.Name = "btMas";
            this.btMas.Size = new System.Drawing.Size(133, 28);
            this.btMas.TabIndex = 6;
            this.btMas.UseVisualStyleBackColor = true;
            this.btMas.Click += new System.EventHandler(this.btMas_Click);
            // 
            // btMensual
            // 
            this.btMensual.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btMensual.Location = new System.Drawing.Point(447, 1);
            this.btMensual.Name = "btMensual";
            this.btMensual.Size = new System.Drawing.Size(220, 28);
            this.btMensual.TabIndex = 5;
            this.btMensual.Text = "Vista mensual";
            this.btMensual.UseVisualStyleBackColor = true;
            this.btMensual.Click += new System.EventHandler(this.btMensual_Click);
            // 
            // btSemanal
            // 
            this.btSemanal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSemanal.Location = new System.Drawing.Point(225, 1);
            this.btSemanal.Name = "btSemanal";
            this.btSemanal.Size = new System.Drawing.Size(220, 28);
            this.btSemanal.TabIndex = 4;
            this.btSemanal.Text = "Visita semanal";
            this.btSemanal.UseVisualStyleBackColor = true;
            this.btSemanal.Click += new System.EventHandler(this.btSemanal_Click);
            // 
            // btDiario
            // 
            this.btDiario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDiario.Location = new System.Drawing.Point(3, 1);
            this.btDiario.Name = "btDiario";
            this.btDiario.Size = new System.Drawing.Size(220, 28);
            this.btDiario.TabIndex = 3;
            this.btDiario.Text = "Visita diaria";
            this.btDiario.UseVisualStyleBackColor = true;
            this.btDiario.Click += new System.EventHandler(this.btDiario_Click);
            // 
            // lblDelegado
            // 
            this.lblDelegado.BackColor = System.Drawing.Color.Transparent;
            this.lblDelegado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDelegado.Location = new System.Drawing.Point(424, 41);
            this.lblDelegado.Name = "lblDelegado";
            this.lblDelegado.Size = new System.Drawing.Size(97, 21);
            this.lblDelegado.TabIndex = 67;
            this.lblDelegado.Text = "Delegado:";
            this.lblDelegado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbDelegado
            // 
            this.cbDelegado.BackColor = System.Drawing.Color.White;
            this.cbDelegado.DataSource = this.dsReports1.ListaDelegados;
            this.cbDelegado.DisplayMember = "sNombre";
            this.cbDelegado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDelegado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDelegado.ItemHeight = 20;
            this.cbDelegado.Location = new System.Drawing.Point(527, 36);
            this.cbDelegado.Name = "cbDelegado";
            this.cbDelegado.Size = new System.Drawing.Size(328, 28);
            this.cbDelegado.TabIndex = 1;
            this.cbDelegado.ValueMember = "iIdDelegado";
            this.cbDelegado.SelectedIndexChanged += new System.EventHandler(this.cbDelegado_SelectedIndexChanged);
            this.cbDelegado.Leave += new System.EventHandler(this.cbDelegado_Leave);
            // 
            // dsReports1
            // 
            this.dsReports1.DataSetName = "dsReports";
            this.dsReports1.Locale = new System.Globalization.CultureInfo("en-US");
            this.dsReports1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dtpCalendario
            // 
            this.dtpCalendario.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpCalendario.CalendarForeColor = System.Drawing.Color.Black;
            this.dtpCalendario.CalendarMonthBackground = System.Drawing.Color.White;
            this.dtpCalendario.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.dtpCalendario.CalendarTitleForeColor = System.Drawing.Color.White;
            this.dtpCalendario.CalendarTrailingForeColor = System.Drawing.Color.Gray;
            this.dtpCalendario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpCalendario.Location = new System.Drawing.Point(69, 37);
            this.dtpCalendario.Name = "dtpCalendario";
            this.dtpCalendario.Size = new System.Drawing.Size(294, 26);
            this.dtpCalendario.TabIndex = 0;
            this.dtpCalendario.ValueChanged += new System.EventHandler(this.dtpCalendario_ValueChanged);
            // 
            // lblCalendario
            // 
            this.lblCalendario.BackColor = System.Drawing.Color.Transparent;
            this.lblCalendario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCalendario.Location = new System.Drawing.Point(4, 39);
            this.lblCalendario.Name = "lblCalendario";
            this.lblCalendario.Size = new System.Drawing.Size(60, 21);
            this.lblCalendario.TabIndex = 0;
            this.lblCalendario.Text = "Fecha:";
            this.lblCalendario.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnMensual
            // 
            this.pnMensual.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnMensual.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnMensual.Controls.Add(this.lblMes42);
            this.pnMensual.Controls.Add(this.lblMes32);
            this.pnMensual.Controls.Add(this.lblMes12);
            this.pnMensual.Controls.Add(this.lblMes22);
            this.pnMensual.Controls.Add(this.lblMes61);
            this.pnMensual.Controls.Add(this.lblPnMes);
            this.pnMensual.Controls.Add(this.dgMes66);
            this.pnMensual.Controls.Add(this.dgMes56);
            this.pnMensual.Controls.Add(this.dgMes46);
            this.pnMensual.Controls.Add(this.dgMes36);
            this.pnMensual.Controls.Add(this.dgMes26);
            this.pnMensual.Controls.Add(this.dgMes16);
            this.pnMensual.Controls.Add(this.lblMes66);
            this.pnMensual.Controls.Add(this.lblMes56);
            this.pnMensual.Controls.Add(this.lblMes46);
            this.pnMensual.Controls.Add(this.lblMes36);
            this.pnMensual.Controls.Add(this.lblMes26);
            this.pnMensual.Controls.Add(this.lblMes16);
            this.pnMensual.Controls.Add(this.dgMes65);
            this.pnMensual.Controls.Add(this.lblMes65);
            this.pnMensual.Controls.Add(this.dgMes55);
            this.pnMensual.Controls.Add(this.lblMes55);
            this.pnMensual.Controls.Add(this.dgMes45);
            this.pnMensual.Controls.Add(this.lblMes45);
            this.pnMensual.Controls.Add(this.dgMes35);
            this.pnMensual.Controls.Add(this.lblMes35);
            this.pnMensual.Controls.Add(this.dgMes25);
            this.pnMensual.Controls.Add(this.lblMes25);
            this.pnMensual.Controls.Add(this.dgMes64);
            this.pnMensual.Controls.Add(this.lblMes64);
            this.pnMensual.Controls.Add(this.dgMes54);
            this.pnMensual.Controls.Add(this.lblMes54);
            this.pnMensual.Controls.Add(this.dgMes44);
            this.pnMensual.Controls.Add(this.lblMes44);
            this.pnMensual.Controls.Add(this.dgMes34);
            this.pnMensual.Controls.Add(this.lblMes34);
            this.pnMensual.Controls.Add(this.dgMes24);
            this.pnMensual.Controls.Add(this.lblMes24);
            this.pnMensual.Controls.Add(this.dgMes63);
            this.pnMensual.Controls.Add(this.lblMes63);
            this.pnMensual.Controls.Add(this.dgMes53);
            this.pnMensual.Controls.Add(this.lblMes53);
            this.pnMensual.Controls.Add(this.dgMes43);
            this.pnMensual.Controls.Add(this.lblMes43);
            this.pnMensual.Controls.Add(this.dgMes33);
            this.pnMensual.Controls.Add(this.lblMes33);
            this.pnMensual.Controls.Add(this.dgMes23);
            this.pnMensual.Controls.Add(this.lblMes23);
            this.pnMensual.Controls.Add(this.dgMes62);
            this.pnMensual.Controls.Add(this.lblMes62);
            this.pnMensual.Controls.Add(this.dgMes52);
            this.pnMensual.Controls.Add(this.lblMes52);
            this.pnMensual.Controls.Add(this.dgMes61);
            this.pnMensual.Controls.Add(this.lblMes51);
            this.pnMensual.Controls.Add(this.lblMes41);
            this.pnMensual.Controls.Add(this.lblMes31);
            this.pnMensual.Controls.Add(this.dgMes15);
            this.pnMensual.Controls.Add(this.lblMes15);
            this.pnMensual.Controls.Add(this.dgMes14);
            this.pnMensual.Controls.Add(this.lblMes14);
            this.pnMensual.Controls.Add(this.dgMes42);
            this.pnMensual.Controls.Add(this.dgMes32);
            this.pnMensual.Controls.Add(this.dgMes22);
            this.pnMensual.Controls.Add(this.dgMes13);
            this.pnMensual.Controls.Add(this.lblMes13);
            this.pnMensual.Controls.Add(this.lblMes21);
            this.pnMensual.Controls.Add(this.lblMes11);
            this.pnMensual.Controls.Add(this.label1);
            this.pnMensual.Controls.Add(this.lblMes);
            this.pnMensual.Controls.Add(this.lblMesLunes);
            this.pnMensual.Controls.Add(this.lblMesMartes);
            this.pnMensual.Controls.Add(this.lblMesMiercoles);
            this.pnMensual.Controls.Add(this.lblMesJueves);
            this.pnMensual.Controls.Add(this.lblMesViernes);
            this.pnMensual.Controls.Add(this.lblSabDom);
            this.pnMensual.Controls.Add(this.dgMes31);
            this.pnMensual.Controls.Add(this.dgMes41);
            this.pnMensual.Controls.Add(this.dgMes51);
            this.pnMensual.Controls.Add(this.dgMes12);
            this.pnMensual.Controls.Add(this.dgMes21);
            this.pnMensual.Controls.Add(this.dgMes11);
            this.pnMensual.ForeColor = System.Drawing.Color.Black;
            this.pnMensual.Location = new System.Drawing.Point(1, 1616);
            this.pnMensual.Name = "pnMensual";
            this.pnMensual.Size = new System.Drawing.Size(1492, 760);
            this.pnMensual.TabIndex = 3;
            this.pnMensual.Visible = false;
            // 
            // lblMes42
            // 
            this.lblMes42.BackColor = System.Drawing.Color.LightGray;
            this.lblMes42.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMes42.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMes42.ForeColor = System.Drawing.Color.Black;
            this.lblMes42.Location = new System.Drawing.Point(710, 150);
            this.lblMes42.Name = "lblMes42";
            this.lblMes42.Size = new System.Drawing.Size(233, 20);
            this.lblMes42.TabIndex = 18;
            this.lblMes42.DoubleClick += new System.EventHandler(this.lblMes42_Click);
            // 
            // lblMes32
            // 
            this.lblMes32.BackColor = System.Drawing.Color.LightGray;
            this.lblMes32.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMes32.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMes32.ForeColor = System.Drawing.Color.Black;
            this.lblMes32.Location = new System.Drawing.Point(477, 150);
            this.lblMes32.Name = "lblMes32";
            this.lblMes32.Size = new System.Drawing.Size(233, 20);
            this.lblMes32.TabIndex = 5;
            this.lblMes32.DoubleClick += new System.EventHandler(this.lblMes32_Click);
            // 
            // lblMes12
            // 
            this.lblMes12.BackColor = System.Drawing.Color.LightGray;
            this.lblMes12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMes12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMes12.ForeColor = System.Drawing.Color.Black;
            this.lblMes12.Location = new System.Drawing.Point(8, 150);
            this.lblMes12.Name = "lblMes12";
            this.lblMes12.Size = new System.Drawing.Size(233, 20);
            this.lblMes12.TabIndex = 2;
            this.lblMes12.DoubleClick += new System.EventHandler(this.lblMes12_Click);
            // 
            // lblMes22
            // 
            this.lblMes22.BackColor = System.Drawing.Color.LightGray;
            this.lblMes22.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMes22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMes22.ForeColor = System.Drawing.Color.Black;
            this.lblMes22.Location = new System.Drawing.Point(244, 150);
            this.lblMes22.Name = "lblMes22";
            this.lblMes22.Size = new System.Drawing.Size(233, 20);
            this.lblMes22.TabIndex = 3;
            this.lblMes22.DoubleClick += new System.EventHandler(this.lblMes22_Click);
            // 
            // lblMes61
            // 
            this.lblMes61.BackColor = System.Drawing.Color.LightGray;
            this.lblMes61.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMes61.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMes61.ForeColor = System.Drawing.Color.Black;
            this.lblMes61.Location = new System.Drawing.Point(1176, 30);
            this.lblMes61.Name = "lblMes61";
            this.lblMes61.Size = new System.Drawing.Size(233, 20);
            this.lblMes61.TabIndex = 54;
            this.lblMes61.DoubleClick += new System.EventHandler(this.lblMes61_Click);
            // 
            // lblPnMes
            // 
            this.lblPnMes.BackColor = System.Drawing.SystemColors.Info;
            this.lblPnMes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPnMes.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPnMes.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblPnMes.Location = new System.Drawing.Point(0, 0);
            this.lblPnMes.Name = "lblPnMes";
            this.lblPnMes.Size = new System.Drawing.Size(12, 13);
            this.lblPnMes.TabIndex = 74;
            this.lblPnMes.Text = "O";
            // 
            // dgMes66
            // 
            this.dgMes66.BackgroundColor = System.Drawing.Color.White;
            this.dgMes66.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgMes66.CaptionVisible = false;
            this.dgMes66.ColumnHeadersVisible = false;
            this.dgMes66.DataMember = "";
            this.dgMes66.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgMes66.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dgMes66.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgMes66.Location = new System.Drawing.Point(1176, 650);
            this.dgMes66.Name = "dgMes66";
            this.dgMes66.ParentRowsVisible = false;
            this.dgMes66.Size = new System.Drawing.Size(233, 100);
            this.dgMes66.TabIndex = 84;
            this.dgMes66.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle42});
            this.dgMes66.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dgMes66_MouseMove);
            this.dgMes66.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgMes66_MouseUp);
            // 
            // dataGridTableStyle42
            // 
            this.dataGridTableStyle42.DataGrid = this.dgMes66;
            this.dataGridTableStyle42.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn124,
            this.dataGridTextBoxColumn125,
            this.dataGridTextBoxColumn126});
            this.dataGridTableStyle42.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // dataGridTextBoxColumn124
            // 
            this.dataGridTextBoxColumn124.Format = "";
            this.dataGridTextBoxColumn124.FormatInfo = null;
            this.dataGridTextBoxColumn124.Width = 120;
            // 
            // dataGridTextBoxColumn125
            // 
            this.dataGridTextBoxColumn125.Format = "";
            this.dataGridTextBoxColumn125.FormatInfo = null;
            this.dataGridTextBoxColumn125.Width = 120;
            // 
            // dataGridTextBoxColumn126
            // 
            this.dataGridTextBoxColumn126.Format = "";
            this.dataGridTextBoxColumn126.FormatInfo = null;
            this.dataGridTextBoxColumn126.Width = 120;
            // 
            // dgMes56
            // 
            this.dgMes56.BackgroundColor = System.Drawing.Color.White;
            this.dgMes56.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgMes56.CaptionVisible = false;
            this.dgMes56.ColumnHeadersVisible = false;
            this.dgMes56.DataMember = "";
            this.dgMes56.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgMes56.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dgMes56.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgMes56.Location = new System.Drawing.Point(943, 650);
            this.dgMes56.Name = "dgMes56";
            this.dgMes56.ParentRowsVisible = false;
            this.dgMes56.Size = new System.Drawing.Size(233, 100);
            this.dgMes56.TabIndex = 83;
            this.dgMes56.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle41});
            this.dgMes56.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dgMes56_MouseMove);
            this.dgMes56.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgMes56_MouseUp);
            // 
            // dataGridTableStyle41
            // 
            this.dataGridTableStyle41.DataGrid = this.dgMes56;
            this.dataGridTableStyle41.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn121,
            this.dataGridTextBoxColumn122,
            this.dataGridTextBoxColumn123});
            this.dataGridTableStyle41.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // dataGridTextBoxColumn121
            // 
            this.dataGridTextBoxColumn121.Format = "";
            this.dataGridTextBoxColumn121.FormatInfo = null;
            this.dataGridTextBoxColumn121.Width = 120;
            // 
            // dataGridTextBoxColumn122
            // 
            this.dataGridTextBoxColumn122.Format = "";
            this.dataGridTextBoxColumn122.FormatInfo = null;
            this.dataGridTextBoxColumn122.Width = 120;
            // 
            // dataGridTextBoxColumn123
            // 
            this.dataGridTextBoxColumn123.Format = "";
            this.dataGridTextBoxColumn123.FormatInfo = null;
            this.dataGridTextBoxColumn123.Width = 120;
            // 
            // dgMes46
            // 
            this.dgMes46.BackgroundColor = System.Drawing.Color.White;
            this.dgMes46.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgMes46.CaptionVisible = false;
            this.dgMes46.ColumnHeadersVisible = false;
            this.dgMes46.DataMember = "";
            this.dgMes46.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgMes46.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dgMes46.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgMes46.Location = new System.Drawing.Point(710, 650);
            this.dgMes46.Name = "dgMes46";
            this.dgMes46.ParentRowsVisible = false;
            this.dgMes46.Size = new System.Drawing.Size(233, 100);
            this.dgMes46.TabIndex = 82;
            this.dgMes46.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle40});
            this.dgMes46.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dgMes46_MouseMove);
            this.dgMes46.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgMes46_MouseUp);
            // 
            // dataGridTableStyle40
            // 
            this.dataGridTableStyle40.DataGrid = this.dgMes46;
            this.dataGridTableStyle40.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn118,
            this.dataGridTextBoxColumn119,
            this.dataGridTextBoxColumn120});
            this.dataGridTableStyle40.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // dataGridTextBoxColumn118
            // 
            this.dataGridTextBoxColumn118.Format = "";
            this.dataGridTextBoxColumn118.FormatInfo = null;
            this.dataGridTextBoxColumn118.Width = 120;
            // 
            // dataGridTextBoxColumn119
            // 
            this.dataGridTextBoxColumn119.Format = "";
            this.dataGridTextBoxColumn119.FormatInfo = null;
            this.dataGridTextBoxColumn119.Width = 120;
            // 
            // dataGridTextBoxColumn120
            // 
            this.dataGridTextBoxColumn120.Format = "";
            this.dataGridTextBoxColumn120.FormatInfo = null;
            this.dataGridTextBoxColumn120.Width = 120;
            // 
            // dgMes36
            // 
            this.dgMes36.BackgroundColor = System.Drawing.Color.White;
            this.dgMes36.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgMes36.CaptionVisible = false;
            this.dgMes36.ColumnHeadersVisible = false;
            this.dgMes36.DataMember = "";
            this.dgMes36.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgMes36.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dgMes36.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgMes36.Location = new System.Drawing.Point(477, 650);
            this.dgMes36.Name = "dgMes36";
            this.dgMes36.ParentRowsVisible = false;
            this.dgMes36.Size = new System.Drawing.Size(233, 100);
            this.dgMes36.TabIndex = 81;
            this.dgMes36.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle39});
            this.dgMes36.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dgMes36_MouseMove);
            this.dgMes36.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgMes36_MouseUp);
            // 
            // dataGridTableStyle39
            // 
            this.dataGridTableStyle39.DataGrid = this.dgMes36;
            this.dataGridTableStyle39.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn115,
            this.dataGridTextBoxColumn116,
            this.dataGridTextBoxColumn117});
            this.dataGridTableStyle39.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // dataGridTextBoxColumn115
            // 
            this.dataGridTextBoxColumn115.Format = "";
            this.dataGridTextBoxColumn115.FormatInfo = null;
            this.dataGridTextBoxColumn115.Width = 120;
            // 
            // dataGridTextBoxColumn116
            // 
            this.dataGridTextBoxColumn116.Format = "";
            this.dataGridTextBoxColumn116.FormatInfo = null;
            this.dataGridTextBoxColumn116.Width = 120;
            // 
            // dataGridTextBoxColumn117
            // 
            this.dataGridTextBoxColumn117.Format = "";
            this.dataGridTextBoxColumn117.FormatInfo = null;
            this.dataGridTextBoxColumn117.Width = 120;
            // 
            // dgMes26
            // 
            this.dgMes26.BackgroundColor = System.Drawing.Color.White;
            this.dgMes26.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgMes26.CaptionVisible = false;
            this.dgMes26.ColumnHeadersVisible = false;
            this.dgMes26.DataMember = "";
            this.dgMes26.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgMes26.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dgMes26.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgMes26.Location = new System.Drawing.Point(244, 650);
            this.dgMes26.Name = "dgMes26";
            this.dgMes26.ParentRowsVisible = false;
            this.dgMes26.Size = new System.Drawing.Size(233, 100);
            this.dgMes26.TabIndex = 80;
            this.dgMes26.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle38});
            this.dgMes26.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dgMes26_MouseMove);
            this.dgMes26.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgMes26_MouseUp);
            // 
            // dataGridTableStyle38
            // 
            this.dataGridTableStyle38.DataGrid = this.dgMes26;
            this.dataGridTableStyle38.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn112,
            this.dataGridTextBoxColumn113,
            this.dataGridTextBoxColumn114});
            this.dataGridTableStyle38.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // dataGridTextBoxColumn112
            // 
            this.dataGridTextBoxColumn112.Format = "";
            this.dataGridTextBoxColumn112.FormatInfo = null;
            this.dataGridTextBoxColumn112.Width = 120;
            // 
            // dataGridTextBoxColumn113
            // 
            this.dataGridTextBoxColumn113.Format = "";
            this.dataGridTextBoxColumn113.FormatInfo = null;
            this.dataGridTextBoxColumn113.Width = 120;
            // 
            // dataGridTextBoxColumn114
            // 
            this.dataGridTextBoxColumn114.Format = "";
            this.dataGridTextBoxColumn114.FormatInfo = null;
            this.dataGridTextBoxColumn114.Width = 120;
            // 
            // dgMes16
            // 
            this.dgMes16.BackgroundColor = System.Drawing.Color.White;
            this.dgMes16.CaptionVisible = false;
            this.dgMes16.ColumnHeadersVisible = false;
            this.dgMes16.DataMember = "";
            this.dgMes16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgMes16.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dgMes16.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgMes16.Location = new System.Drawing.Point(8, 650);
            this.dgMes16.Name = "dgMes16";
            this.dgMes16.ParentRowsVisible = false;
            this.dgMes16.Size = new System.Drawing.Size(233, 100);
            this.dgMes16.TabIndex = 79;
            this.dgMes16.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle43});
            this.dgMes16.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dgMes16_MouseMove);
            this.dgMes16.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgMes16_MouseUp);
            // 
            // dataGridTableStyle43
            // 
            this.dataGridTableStyle43.DataGrid = this.dgMes16;
            this.dataGridTableStyle43.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn127,
            this.dataGridTextBoxColumn128,
            this.dataGridTextBoxColumn129});
            this.dataGridTableStyle43.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // dataGridTextBoxColumn127
            // 
            this.dataGridTextBoxColumn127.Format = "";
            this.dataGridTextBoxColumn127.FormatInfo = null;
            this.dataGridTextBoxColumn127.Width = 120;
            // 
            // dataGridTextBoxColumn128
            // 
            this.dataGridTextBoxColumn128.Format = "";
            this.dataGridTextBoxColumn128.FormatInfo = null;
            this.dataGridTextBoxColumn128.Width = 120;
            // 
            // dataGridTextBoxColumn129
            // 
            this.dataGridTextBoxColumn129.Format = "";
            this.dataGridTextBoxColumn129.FormatInfo = null;
            this.dataGridTextBoxColumn129.Width = 120;
            // 
            // lblMes66
            // 
            this.lblMes66.BackColor = System.Drawing.Color.LightGray;
            this.lblMes66.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMes66.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblMes66.ForeColor = System.Drawing.Color.Black;
            this.lblMes66.Location = new System.Drawing.Point(1176, 630);
            this.lblMes66.Name = "lblMes66";
            this.lblMes66.Size = new System.Drawing.Size(233, 20);
            this.lblMes66.TabIndex = 78;
            this.lblMes66.DoubleClick += new System.EventHandler(this.lblMes66_Click);
            // 
            // lblMes56
            // 
            this.lblMes56.BackColor = System.Drawing.Color.LightGray;
            this.lblMes56.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMes56.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMes56.ForeColor = System.Drawing.Color.Black;
            this.lblMes56.Location = new System.Drawing.Point(943, 630);
            this.lblMes56.Name = "lblMes56";
            this.lblMes56.Size = new System.Drawing.Size(233, 20);
            this.lblMes56.TabIndex = 77;
            this.lblMes56.DoubleClick += new System.EventHandler(this.lblMes56_Click);
            // 
            // lblMes46
            // 
            this.lblMes46.BackColor = System.Drawing.Color.LightGray;
            this.lblMes46.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMes46.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMes46.ForeColor = System.Drawing.Color.Black;
            this.lblMes46.Location = new System.Drawing.Point(710, 630);
            this.lblMes46.Name = "lblMes46";
            this.lblMes46.Size = new System.Drawing.Size(233, 20);
            this.lblMes46.TabIndex = 76;
            this.lblMes46.DoubleClick += new System.EventHandler(this.lblMes46_Click);
            // 
            // lblMes36
            // 
            this.lblMes36.BackColor = System.Drawing.Color.LightGray;
            this.lblMes36.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMes36.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMes36.ForeColor = System.Drawing.Color.Black;
            this.lblMes36.Location = new System.Drawing.Point(477, 630);
            this.lblMes36.Name = "lblMes36";
            this.lblMes36.Size = new System.Drawing.Size(233, 20);
            this.lblMes36.TabIndex = 75;
            this.lblMes36.DoubleClick += new System.EventHandler(this.lblMes36_Click);
            // 
            // lblMes26
            // 
            this.lblMes26.BackColor = System.Drawing.Color.LightGray;
            this.lblMes26.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMes26.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMes26.ForeColor = System.Drawing.Color.Black;
            this.lblMes26.Location = new System.Drawing.Point(244, 630);
            this.lblMes26.Name = "lblMes26";
            this.lblMes26.Size = new System.Drawing.Size(233, 20);
            this.lblMes26.TabIndex = 74;
            this.lblMes26.DoubleClick += new System.EventHandler(this.lblMes26_Click);
            // 
            // lblMes16
            // 
            this.lblMes16.BackColor = System.Drawing.Color.LightGray;
            this.lblMes16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMes16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMes16.ForeColor = System.Drawing.Color.Black;
            this.lblMes16.Location = new System.Drawing.Point(8, 630);
            this.lblMes16.Name = "lblMes16";
            this.lblMes16.Size = new System.Drawing.Size(233, 20);
            this.lblMes16.TabIndex = 73;
            this.lblMes16.DoubleClick += new System.EventHandler(this.lblMes16_Click);
            // 
            // dgMes65
            // 
            this.dgMes65.BackgroundColor = System.Drawing.Color.White;
            this.dgMes65.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgMes65.CaptionVisible = false;
            this.dgMes65.ColumnHeadersVisible = false;
            this.dgMes65.DataMember = "";
            this.dgMes65.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgMes65.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dgMes65.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgMes65.Location = new System.Drawing.Point(1176, 530);
            this.dgMes65.Name = "dgMes65";
            this.dgMes65.ParentRowsVisible = false;
            this.dgMes65.Size = new System.Drawing.Size(233, 100);
            this.dgMes65.TabIndex = 29;
            this.dgMes65.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle30});
            this.dgMes65.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dgMes65_MouseMove);
            this.dgMes65.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgMes65_MouseUp);
            // 
            // dataGridTableStyle30
            // 
            this.dataGridTableStyle30.DataGrid = this.dgMes65;
            this.dataGridTableStyle30.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn88,
            this.dataGridTextBoxColumn89,
            this.dataGridTextBoxColumn90});
            this.dataGridTableStyle30.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // dataGridTextBoxColumn88
            // 
            this.dataGridTextBoxColumn88.Format = "";
            this.dataGridTextBoxColumn88.FormatInfo = null;
            this.dataGridTextBoxColumn88.Width = 120;
            // 
            // dataGridTextBoxColumn89
            // 
            this.dataGridTextBoxColumn89.Format = "";
            this.dataGridTextBoxColumn89.FormatInfo = null;
            this.dataGridTextBoxColumn89.Width = 120;
            // 
            // dataGridTextBoxColumn90
            // 
            this.dataGridTextBoxColumn90.Format = "";
            this.dataGridTextBoxColumn90.FormatInfo = null;
            this.dataGridTextBoxColumn90.Width = 120;
            // 
            // lblMes65
            // 
            this.lblMes65.BackColor = System.Drawing.Color.LightGray;
            this.lblMes65.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMes65.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblMes65.ForeColor = System.Drawing.Color.Black;
            this.lblMes65.Location = new System.Drawing.Point(1176, 510);
            this.lblMes65.Name = "lblMes65";
            this.lblMes65.Size = new System.Drawing.Size(233, 20);
            this.lblMes65.TabIndex = 64;
            this.lblMes65.DoubleClick += new System.EventHandler(this.lblMes65_Click);
            // 
            // dgMes55
            // 
            this.dgMes55.BackgroundColor = System.Drawing.Color.White;
            this.dgMes55.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgMes55.CaptionVisible = false;
            this.dgMes55.ColumnHeadersVisible = false;
            this.dgMes55.DataMember = "";
            this.dgMes55.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgMes55.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dgMes55.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgMes55.Location = new System.Drawing.Point(943, 530);
            this.dgMes55.Name = "dgMes55";
            this.dgMes55.ParentRowsVisible = false;
            this.dgMes55.Size = new System.Drawing.Size(233, 100);
            this.dgMes55.TabIndex = 28;
            this.dgMes55.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle29});
            this.dgMes55.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dgMes55_MouseMove);
            this.dgMes55.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgMes55_MouseUp);
            // 
            // dataGridTableStyle29
            // 
            this.dataGridTableStyle29.DataGrid = this.dgMes55;
            this.dataGridTableStyle29.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn85,
            this.dataGridTextBoxColumn86,
            this.dataGridTextBoxColumn87});
            this.dataGridTableStyle29.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // dataGridTextBoxColumn85
            // 
            this.dataGridTextBoxColumn85.Format = "";
            this.dataGridTextBoxColumn85.FormatInfo = null;
            this.dataGridTextBoxColumn85.Width = 120;
            // 
            // dataGridTextBoxColumn86
            // 
            this.dataGridTextBoxColumn86.Format = "";
            this.dataGridTextBoxColumn86.FormatInfo = null;
            this.dataGridTextBoxColumn86.Width = 120;
            // 
            // dataGridTextBoxColumn87
            // 
            this.dataGridTextBoxColumn87.Format = "";
            this.dataGridTextBoxColumn87.FormatInfo = null;
            this.dataGridTextBoxColumn87.Width = 120;
            // 
            // lblMes55
            // 
            this.lblMes55.BackColor = System.Drawing.Color.LightGray;
            this.lblMes55.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMes55.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMes55.ForeColor = System.Drawing.Color.Black;
            this.lblMes55.Location = new System.Drawing.Point(943, 510);
            this.lblMes55.Name = "lblMes55";
            this.lblMes55.Size = new System.Drawing.Size(233, 20);
            this.lblMes55.TabIndex = 62;
            this.lblMes55.DoubleClick += new System.EventHandler(this.lblMes55_Click);
            // 
            // dgMes45
            // 
            this.dgMes45.BackgroundColor = System.Drawing.Color.White;
            this.dgMes45.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgMes45.CaptionVisible = false;
            this.dgMes45.ColumnHeadersVisible = false;
            this.dgMes45.DataMember = "";
            this.dgMes45.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgMes45.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dgMes45.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgMes45.Location = new System.Drawing.Point(710, 530);
            this.dgMes45.Name = "dgMes45";
            this.dgMes45.ParentRowsVisible = false;
            this.dgMes45.Size = new System.Drawing.Size(233, 100);
            this.dgMes45.TabIndex = 27;
            this.dgMes45.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle28});
            this.dgMes45.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dgMes45_MouseMove);
            this.dgMes45.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgMes45_MouseUp);
            // 
            // dataGridTableStyle28
            // 
            this.dataGridTableStyle28.DataGrid = this.dgMes45;
            this.dataGridTableStyle28.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn82,
            this.dataGridTextBoxColumn83,
            this.dataGridTextBoxColumn84});
            this.dataGridTableStyle28.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // dataGridTextBoxColumn82
            // 
            this.dataGridTextBoxColumn82.Format = "";
            this.dataGridTextBoxColumn82.FormatInfo = null;
            this.dataGridTextBoxColumn82.Width = 120;
            // 
            // dataGridTextBoxColumn83
            // 
            this.dataGridTextBoxColumn83.Format = "";
            this.dataGridTextBoxColumn83.FormatInfo = null;
            this.dataGridTextBoxColumn83.Width = 120;
            // 
            // dataGridTextBoxColumn84
            // 
            this.dataGridTextBoxColumn84.Format = "";
            this.dataGridTextBoxColumn84.FormatInfo = null;
            this.dataGridTextBoxColumn84.Width = 120;
            // 
            // lblMes45
            // 
            this.lblMes45.BackColor = System.Drawing.Color.LightGray;
            this.lblMes45.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMes45.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMes45.ForeColor = System.Drawing.Color.Black;
            this.lblMes45.Location = new System.Drawing.Point(710, 510);
            this.lblMes45.Name = "lblMes45";
            this.lblMes45.Size = new System.Drawing.Size(233, 20);
            this.lblMes45.TabIndex = 60;
            this.lblMes45.DoubleClick += new System.EventHandler(this.lblMes45_Click);
            // 
            // dgMes35
            // 
            this.dgMes35.BackgroundColor = System.Drawing.Color.White;
            this.dgMes35.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgMes35.CaptionVisible = false;
            this.dgMes35.ColumnHeadersVisible = false;
            this.dgMes35.DataMember = "";
            this.dgMes35.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgMes35.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dgMes35.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgMes35.Location = new System.Drawing.Point(477, 530);
            this.dgMes35.Name = "dgMes35";
            this.dgMes35.ParentRowsVisible = false;
            this.dgMes35.Size = new System.Drawing.Size(233, 100);
            this.dgMes35.TabIndex = 26;
            this.dgMes35.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle27});
            this.dgMes35.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dgMes35_MouseMove);
            this.dgMes35.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgMes35_MouseUp);
            // 
            // dataGridTableStyle27
            // 
            this.dataGridTableStyle27.DataGrid = this.dgMes35;
            this.dataGridTableStyle27.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn79,
            this.dataGridTextBoxColumn80,
            this.dataGridTextBoxColumn81});
            this.dataGridTableStyle27.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // dataGridTextBoxColumn79
            // 
            this.dataGridTextBoxColumn79.Format = "";
            this.dataGridTextBoxColumn79.FormatInfo = null;
            this.dataGridTextBoxColumn79.Width = 120;
            // 
            // dataGridTextBoxColumn80
            // 
            this.dataGridTextBoxColumn80.Format = "";
            this.dataGridTextBoxColumn80.FormatInfo = null;
            this.dataGridTextBoxColumn80.Width = 120;
            // 
            // dataGridTextBoxColumn81
            // 
            this.dataGridTextBoxColumn81.Format = "";
            this.dataGridTextBoxColumn81.FormatInfo = null;
            this.dataGridTextBoxColumn81.Width = 120;
            // 
            // lblMes35
            // 
            this.lblMes35.BackColor = System.Drawing.Color.LightGray;
            this.lblMes35.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMes35.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMes35.ForeColor = System.Drawing.Color.Black;
            this.lblMes35.Location = new System.Drawing.Point(477, 510);
            this.lblMes35.Name = "lblMes35";
            this.lblMes35.Size = new System.Drawing.Size(233, 20);
            this.lblMes35.TabIndex = 58;
            this.lblMes35.DoubleClick += new System.EventHandler(this.lblMes35_Click);
            // 
            // dgMes25
            // 
            this.dgMes25.BackgroundColor = System.Drawing.Color.White;
            this.dgMes25.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgMes25.CaptionVisible = false;
            this.dgMes25.ColumnHeadersVisible = false;
            this.dgMes25.DataMember = "";
            this.dgMes25.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgMes25.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dgMes25.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgMes25.Location = new System.Drawing.Point(244, 530);
            this.dgMes25.Name = "dgMes25";
            this.dgMes25.ParentRowsVisible = false;
            this.dgMes25.Size = new System.Drawing.Size(233, 100);
            this.dgMes25.TabIndex = 25;
            this.dgMes25.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle26});
            this.dgMes25.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dgMes25_MouseMove);
            this.dgMes25.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgMes25_MouseUp);
            // 
            // dataGridTableStyle26
            // 
            this.dataGridTableStyle26.DataGrid = this.dgMes25;
            this.dataGridTableStyle26.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn76,
            this.dataGridTextBoxColumn77,
            this.dataGridTextBoxColumn78});
            this.dataGridTableStyle26.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // dataGridTextBoxColumn76
            // 
            this.dataGridTextBoxColumn76.Format = "";
            this.dataGridTextBoxColumn76.FormatInfo = null;
            this.dataGridTextBoxColumn76.Width = 120;
            // 
            // dataGridTextBoxColumn77
            // 
            this.dataGridTextBoxColumn77.Format = "";
            this.dataGridTextBoxColumn77.FormatInfo = null;
            this.dataGridTextBoxColumn77.Width = 120;
            // 
            // dataGridTextBoxColumn78
            // 
            this.dataGridTextBoxColumn78.Format = "";
            this.dataGridTextBoxColumn78.FormatInfo = null;
            this.dataGridTextBoxColumn78.Width = 120;
            // 
            // lblMes25
            // 
            this.lblMes25.BackColor = System.Drawing.Color.LightGray;
            this.lblMes25.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMes25.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMes25.ForeColor = System.Drawing.Color.Black;
            this.lblMes25.Location = new System.Drawing.Point(244, 510);
            this.lblMes25.Name = "lblMes25";
            this.lblMes25.Size = new System.Drawing.Size(233, 20);
            this.lblMes25.TabIndex = 56;
            this.lblMes25.DoubleClick += new System.EventHandler(this.lblMes25_Click);
            // 
            // dgMes64
            // 
            this.dgMes64.BackgroundColor = System.Drawing.Color.White;
            this.dgMes64.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgMes64.CaptionVisible = false;
            this.dgMes64.ColumnHeadersVisible = false;
            this.dgMes64.DataMember = "";
            this.dgMes64.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgMes64.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dgMes64.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgMes64.Location = new System.Drawing.Point(1176, 410);
            this.dgMes64.Name = "dgMes64";
            this.dgMes64.ParentRowsVisible = false;
            this.dgMes64.Size = new System.Drawing.Size(233, 100);
            this.dgMes64.TabIndex = 23;
            this.dgMes64.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle24});
            this.dgMes64.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dgMes64_MouseMove);
            this.dgMes64.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgMes64_MouseUp);
            // 
            // dataGridTableStyle24
            // 
            this.dataGridTableStyle24.DataGrid = this.dgMes64;
            this.dataGridTableStyle24.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn70,
            this.dataGridTextBoxColumn71,
            this.dataGridTextBoxColumn72});
            this.dataGridTableStyle24.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // dataGridTextBoxColumn70
            // 
            this.dataGridTextBoxColumn70.Format = "";
            this.dataGridTextBoxColumn70.FormatInfo = null;
            this.dataGridTextBoxColumn70.Width = 120;
            // 
            // dataGridTextBoxColumn71
            // 
            this.dataGridTextBoxColumn71.Format = "";
            this.dataGridTextBoxColumn71.FormatInfo = null;
            this.dataGridTextBoxColumn71.Width = 120;
            // 
            // dataGridTextBoxColumn72
            // 
            this.dataGridTextBoxColumn72.Format = "";
            this.dataGridTextBoxColumn72.FormatInfo = null;
            this.dataGridTextBoxColumn72.Width = 120;
            // 
            // lblMes64
            // 
            this.lblMes64.BackColor = System.Drawing.Color.LightGray;
            this.lblMes64.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMes64.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblMes64.ForeColor = System.Drawing.Color.Black;
            this.lblMes64.Location = new System.Drawing.Point(1176, 390);
            this.lblMes64.Name = "lblMes64";
            this.lblMes64.Size = new System.Drawing.Size(233, 20);
            this.lblMes64.TabIndex = 54;
            this.lblMes64.DoubleClick += new System.EventHandler(this.lblMes64_Click);
            // 
            // dgMes54
            // 
            this.dgMes54.BackgroundColor = System.Drawing.Color.White;
            this.dgMes54.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgMes54.CaptionVisible = false;
            this.dgMes54.ColumnHeadersVisible = false;
            this.dgMes54.DataMember = "";
            this.dgMes54.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgMes54.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dgMes54.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgMes54.Location = new System.Drawing.Point(943, 410);
            this.dgMes54.Name = "dgMes54";
            this.dgMes54.ParentRowsVisible = false;
            this.dgMes54.Size = new System.Drawing.Size(233, 100);
            this.dgMes54.TabIndex = 22;
            this.dgMes54.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle23});
            this.dgMes54.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dgMes54_MouseMove);
            this.dgMes54.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgMes54_MouseUp);
            // 
            // dataGridTableStyle23
            // 
            this.dataGridTableStyle23.DataGrid = this.dgMes54;
            this.dataGridTableStyle23.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn67,
            this.dataGridTextBoxColumn68,
            this.dataGridTextBoxColumn69});
            this.dataGridTableStyle23.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // dataGridTextBoxColumn67
            // 
            this.dataGridTextBoxColumn67.Format = "";
            this.dataGridTextBoxColumn67.FormatInfo = null;
            this.dataGridTextBoxColumn67.Width = 120;
            // 
            // dataGridTextBoxColumn68
            // 
            this.dataGridTextBoxColumn68.Format = "";
            this.dataGridTextBoxColumn68.FormatInfo = null;
            this.dataGridTextBoxColumn68.Width = 120;
            // 
            // dataGridTextBoxColumn69
            // 
            this.dataGridTextBoxColumn69.Format = "";
            this.dataGridTextBoxColumn69.FormatInfo = null;
            this.dataGridTextBoxColumn69.Width = 120;
            // 
            // lblMes54
            // 
            this.lblMes54.BackColor = System.Drawing.Color.LightGray;
            this.lblMes54.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMes54.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMes54.ForeColor = System.Drawing.Color.Black;
            this.lblMes54.Location = new System.Drawing.Point(943, 390);
            this.lblMes54.Name = "lblMes54";
            this.lblMes54.Size = new System.Drawing.Size(233, 20);
            this.lblMes54.TabIndex = 52;
            this.lblMes54.DoubleClick += new System.EventHandler(this.lblMes54_Click);
            // 
            // dgMes44
            // 
            this.dgMes44.BackgroundColor = System.Drawing.Color.White;
            this.dgMes44.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgMes44.CaptionVisible = false;
            this.dgMes44.ColumnHeadersVisible = false;
            this.dgMes44.DataMember = "";
            this.dgMes44.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgMes44.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dgMes44.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgMes44.Location = new System.Drawing.Point(710, 410);
            this.dgMes44.Name = "dgMes44";
            this.dgMes44.ParentRowsVisible = false;
            this.dgMes44.Size = new System.Drawing.Size(233, 100);
            this.dgMes44.TabIndex = 21;
            this.dgMes44.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle22});
            this.dgMes44.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dgMes44_MouseMove);
            this.dgMes44.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgMes44_MouseUp);
            // 
            // dataGridTableStyle22
            // 
            this.dataGridTableStyle22.DataGrid = this.dgMes44;
            this.dataGridTableStyle22.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn64,
            this.dataGridTextBoxColumn65,
            this.dataGridTextBoxColumn66});
            this.dataGridTableStyle22.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // dataGridTextBoxColumn64
            // 
            this.dataGridTextBoxColumn64.Format = "";
            this.dataGridTextBoxColumn64.FormatInfo = null;
            this.dataGridTextBoxColumn64.Width = 120;
            // 
            // dataGridTextBoxColumn65
            // 
            this.dataGridTextBoxColumn65.Format = "";
            this.dataGridTextBoxColumn65.FormatInfo = null;
            this.dataGridTextBoxColumn65.Width = 120;
            // 
            // dataGridTextBoxColumn66
            // 
            this.dataGridTextBoxColumn66.Format = "";
            this.dataGridTextBoxColumn66.FormatInfo = null;
            this.dataGridTextBoxColumn66.Width = 120;
            // 
            // lblMes44
            // 
            this.lblMes44.BackColor = System.Drawing.Color.LightGray;
            this.lblMes44.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMes44.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMes44.ForeColor = System.Drawing.Color.Black;
            this.lblMes44.Location = new System.Drawing.Point(710, 390);
            this.lblMes44.Name = "lblMes44";
            this.lblMes44.Size = new System.Drawing.Size(233, 20);
            this.lblMes44.TabIndex = 50;
            this.lblMes44.DoubleClick += new System.EventHandler(this.lblMes44_Click);
            // 
            // dgMes34
            // 
            this.dgMes34.BackgroundColor = System.Drawing.Color.White;
            this.dgMes34.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgMes34.CaptionVisible = false;
            this.dgMes34.ColumnHeadersVisible = false;
            this.dgMes34.DataMember = "";
            this.dgMes34.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgMes34.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dgMes34.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgMes34.Location = new System.Drawing.Point(477, 410);
            this.dgMes34.Name = "dgMes34";
            this.dgMes34.ParentRowsVisible = false;
            this.dgMes34.Size = new System.Drawing.Size(233, 100);
            this.dgMes34.TabIndex = 20;
            this.dgMes34.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle21});
            this.dgMes34.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dgMes34_MouseMove);
            this.dgMes34.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgMes34_MouseUp);
            // 
            // dataGridTableStyle21
            // 
            this.dataGridTableStyle21.DataGrid = this.dgMes34;
            this.dataGridTableStyle21.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn61,
            this.dataGridTextBoxColumn62,
            this.dataGridTextBoxColumn63});
            this.dataGridTableStyle21.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // dataGridTextBoxColumn61
            // 
            this.dataGridTextBoxColumn61.Format = "";
            this.dataGridTextBoxColumn61.FormatInfo = null;
            this.dataGridTextBoxColumn61.Width = 120;
            // 
            // dataGridTextBoxColumn62
            // 
            this.dataGridTextBoxColumn62.Format = "";
            this.dataGridTextBoxColumn62.FormatInfo = null;
            this.dataGridTextBoxColumn62.Width = 120;
            // 
            // dataGridTextBoxColumn63
            // 
            this.dataGridTextBoxColumn63.Format = "";
            this.dataGridTextBoxColumn63.FormatInfo = null;
            this.dataGridTextBoxColumn63.Width = 120;
            // 
            // lblMes34
            // 
            this.lblMes34.BackColor = System.Drawing.Color.LightGray;
            this.lblMes34.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMes34.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMes34.ForeColor = System.Drawing.Color.Black;
            this.lblMes34.Location = new System.Drawing.Point(477, 390);
            this.lblMes34.Name = "lblMes34";
            this.lblMes34.Size = new System.Drawing.Size(233, 20);
            this.lblMes34.TabIndex = 48;
            this.lblMes34.DoubleClick += new System.EventHandler(this.lblMes34_Click);
            // 
            // dgMes24
            // 
            this.dgMes24.BackgroundColor = System.Drawing.Color.White;
            this.dgMes24.CaptionVisible = false;
            this.dgMes24.ColumnHeadersVisible = false;
            this.dgMes24.DataMember = "";
            this.dgMes24.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgMes24.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dgMes24.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgMes24.Location = new System.Drawing.Point(244, 410);
            this.dgMes24.Name = "dgMes24";
            this.dgMes24.ParentRowsVisible = false;
            this.dgMes24.Size = new System.Drawing.Size(233, 100);
            this.dgMes24.TabIndex = 19;
            this.dgMes24.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle20});
            this.dgMes24.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dgMes24_MouseMove);
            this.dgMes24.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgMes24_MouseUp);
            // 
            // dataGridTableStyle20
            // 
            this.dataGridTableStyle20.DataGrid = this.dgMes24;
            this.dataGridTableStyle20.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn58,
            this.dataGridTextBoxColumn59,
            this.dataGridTextBoxColumn60});
            this.dataGridTableStyle20.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // dataGridTextBoxColumn58
            // 
            this.dataGridTextBoxColumn58.Format = "";
            this.dataGridTextBoxColumn58.FormatInfo = null;
            this.dataGridTextBoxColumn58.Width = 120;
            // 
            // dataGridTextBoxColumn59
            // 
            this.dataGridTextBoxColumn59.Format = "";
            this.dataGridTextBoxColumn59.FormatInfo = null;
            this.dataGridTextBoxColumn59.Width = 120;
            // 
            // dataGridTextBoxColumn60
            // 
            this.dataGridTextBoxColumn60.Format = "";
            this.dataGridTextBoxColumn60.FormatInfo = null;
            this.dataGridTextBoxColumn60.Width = 120;
            // 
            // lblMes24
            // 
            this.lblMes24.BackColor = System.Drawing.Color.LightGray;
            this.lblMes24.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMes24.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMes24.ForeColor = System.Drawing.Color.Black;
            this.lblMes24.Location = new System.Drawing.Point(244, 390);
            this.lblMes24.Name = "lblMes24";
            this.lblMes24.Size = new System.Drawing.Size(233, 20);
            this.lblMes24.TabIndex = 46;
            this.lblMes24.DoubleClick += new System.EventHandler(this.lblMes24_Click);
            // 
            // dgMes63
            // 
            this.dgMes63.BackgroundColor = System.Drawing.Color.White;
            this.dgMes63.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgMes63.CaptionVisible = false;
            this.dgMes63.ColumnHeadersVisible = false;
            this.dgMes63.DataMember = "";
            this.dgMes63.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgMes63.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dgMes63.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgMes63.Location = new System.Drawing.Point(1176, 290);
            this.dgMes63.Name = "dgMes63";
            this.dgMes63.ParentRowsVisible = false;
            this.dgMes63.Size = new System.Drawing.Size(233, 100);
            this.dgMes63.TabIndex = 17;
            this.dgMes63.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle18});
            this.dgMes63.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dgMes63_MouseMove);
            this.dgMes63.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgMes63_MouseUp);
            // 
            // dataGridTableStyle18
            // 
            this.dataGridTableStyle18.DataGrid = this.dgMes63;
            this.dataGridTableStyle18.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn52,
            this.dataGridTextBoxColumn53,
            this.dataGridTextBoxColumn54});
            this.dataGridTableStyle18.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // dataGridTextBoxColumn52
            // 
            this.dataGridTextBoxColumn52.Format = "";
            this.dataGridTextBoxColumn52.FormatInfo = null;
            this.dataGridTextBoxColumn52.Width = 120;
            // 
            // dataGridTextBoxColumn53
            // 
            this.dataGridTextBoxColumn53.Format = "";
            this.dataGridTextBoxColumn53.FormatInfo = null;
            this.dataGridTextBoxColumn53.Width = 120;
            // 
            // dataGridTextBoxColumn54
            // 
            this.dataGridTextBoxColumn54.Format = "";
            this.dataGridTextBoxColumn54.FormatInfo = null;
            this.dataGridTextBoxColumn54.Width = 120;
            // 
            // lblMes63
            // 
            this.lblMes63.BackColor = System.Drawing.Color.LightGray;
            this.lblMes63.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMes63.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblMes63.ForeColor = System.Drawing.Color.Black;
            this.lblMes63.Location = new System.Drawing.Point(1176, 270);
            this.lblMes63.Name = "lblMes63";
            this.lblMes63.Size = new System.Drawing.Size(233, 20);
            this.lblMes63.TabIndex = 44;
            this.lblMes63.DoubleClick += new System.EventHandler(this.lblMes63_Click);
            // 
            // dgMes53
            // 
            this.dgMes53.BackgroundColor = System.Drawing.Color.White;
            this.dgMes53.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgMes53.CaptionVisible = false;
            this.dgMes53.ColumnHeadersVisible = false;
            this.dgMes53.DataMember = "";
            this.dgMes53.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgMes53.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dgMes53.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgMes53.Location = new System.Drawing.Point(943, 290);
            this.dgMes53.Name = "dgMes53";
            this.dgMes53.ParentRowsVisible = false;
            this.dgMes53.Size = new System.Drawing.Size(233, 100);
            this.dgMes53.TabIndex = 16;
            this.dgMes53.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle17});
            this.dgMes53.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dgMes53_MouseMove);
            this.dgMes53.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgMes53_MouseUp);
            // 
            // dataGridTableStyle17
            // 
            this.dataGridTableStyle17.DataGrid = this.dgMes53;
            this.dataGridTableStyle17.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn49,
            this.dataGridTextBoxColumn50,
            this.dataGridTextBoxColumn51});
            this.dataGridTableStyle17.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // dataGridTextBoxColumn49
            // 
            this.dataGridTextBoxColumn49.Format = "";
            this.dataGridTextBoxColumn49.FormatInfo = null;
            this.dataGridTextBoxColumn49.Width = 120;
            // 
            // dataGridTextBoxColumn50
            // 
            this.dataGridTextBoxColumn50.Format = "";
            this.dataGridTextBoxColumn50.FormatInfo = null;
            this.dataGridTextBoxColumn50.Width = 120;
            // 
            // dataGridTextBoxColumn51
            // 
            this.dataGridTextBoxColumn51.Format = "";
            this.dataGridTextBoxColumn51.FormatInfo = null;
            this.dataGridTextBoxColumn51.Width = 120;
            // 
            // lblMes53
            // 
            this.lblMes53.BackColor = System.Drawing.Color.LightGray;
            this.lblMes53.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMes53.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMes53.ForeColor = System.Drawing.Color.Black;
            this.lblMes53.Location = new System.Drawing.Point(943, 270);
            this.lblMes53.Name = "lblMes53";
            this.lblMes53.Size = new System.Drawing.Size(233, 20);
            this.lblMes53.TabIndex = 42;
            this.lblMes53.DoubleClick += new System.EventHandler(this.lblMes53_Click);
            // 
            // dgMes43
            // 
            this.dgMes43.BackgroundColor = System.Drawing.Color.White;
            this.dgMes43.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgMes43.CaptionVisible = false;
            this.dgMes43.ColumnHeadersVisible = false;
            this.dgMes43.DataMember = "";
            this.dgMes43.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgMes43.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dgMes43.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgMes43.Location = new System.Drawing.Point(710, 290);
            this.dgMes43.Name = "dgMes43";
            this.dgMes43.ParentRowsVisible = false;
            this.dgMes43.Size = new System.Drawing.Size(233, 100);
            this.dgMes43.TabIndex = 15;
            this.dgMes43.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle15});
            this.dgMes43.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dgMes43_MouseMove);
            this.dgMes43.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgMes43_MouseUp);
            // 
            // dataGridTableStyle15
            // 
            this.dataGridTableStyle15.DataGrid = this.dgMes43;
            this.dataGridTableStyle15.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn43,
            this.dataGridTextBoxColumn44,
            this.dataGridTextBoxColumn45});
            this.dataGridTableStyle15.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // dataGridTextBoxColumn43
            // 
            this.dataGridTextBoxColumn43.Format = "";
            this.dataGridTextBoxColumn43.FormatInfo = null;
            this.dataGridTextBoxColumn43.Width = 120;
            // 
            // dataGridTextBoxColumn44
            // 
            this.dataGridTextBoxColumn44.Format = "";
            this.dataGridTextBoxColumn44.FormatInfo = null;
            this.dataGridTextBoxColumn44.Width = 120;
            // 
            // dataGridTextBoxColumn45
            // 
            this.dataGridTextBoxColumn45.Format = "";
            this.dataGridTextBoxColumn45.FormatInfo = null;
            this.dataGridTextBoxColumn45.Width = 120;
            // 
            // lblMes43
            // 
            this.lblMes43.BackColor = System.Drawing.Color.LightGray;
            this.lblMes43.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMes43.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMes43.ForeColor = System.Drawing.Color.Black;
            this.lblMes43.Location = new System.Drawing.Point(710, 270);
            this.lblMes43.Name = "lblMes43";
            this.lblMes43.Size = new System.Drawing.Size(233, 20);
            this.lblMes43.TabIndex = 40;
            this.lblMes43.DoubleClick += new System.EventHandler(this.lblMes43_Click);
            // 
            // dgMes33
            // 
            this.dgMes33.BackgroundColor = System.Drawing.Color.White;
            this.dgMes33.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgMes33.CaptionVisible = false;
            this.dgMes33.ColumnHeadersVisible = false;
            this.dgMes33.DataMember = "";
            this.dgMes33.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgMes33.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dgMes33.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgMes33.Location = new System.Drawing.Point(477, 290);
            this.dgMes33.Name = "dgMes33";
            this.dgMes33.ParentRowsVisible = false;
            this.dgMes33.Size = new System.Drawing.Size(233, 100);
            this.dgMes33.TabIndex = 14;
            this.dgMes33.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle16});
            this.dgMes33.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dgMes33_MouseMove);
            this.dgMes33.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgMes33_MouseUp);
            // 
            // dataGridTableStyle16
            // 
            this.dataGridTableStyle16.DataGrid = this.dgMes33;
            this.dataGridTableStyle16.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn46,
            this.dataGridTextBoxColumn47,
            this.dataGridTextBoxColumn48});
            this.dataGridTableStyle16.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // dataGridTextBoxColumn46
            // 
            this.dataGridTextBoxColumn46.Format = "";
            this.dataGridTextBoxColumn46.FormatInfo = null;
            this.dataGridTextBoxColumn46.Width = 120;
            // 
            // dataGridTextBoxColumn47
            // 
            this.dataGridTextBoxColumn47.Format = "";
            this.dataGridTextBoxColumn47.FormatInfo = null;
            this.dataGridTextBoxColumn47.Width = 120;
            // 
            // dataGridTextBoxColumn48
            // 
            this.dataGridTextBoxColumn48.Format = "";
            this.dataGridTextBoxColumn48.FormatInfo = null;
            this.dataGridTextBoxColumn48.Width = 120;
            // 
            // lblMes33
            // 
            this.lblMes33.BackColor = System.Drawing.Color.LightGray;
            this.lblMes33.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMes33.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMes33.ForeColor = System.Drawing.Color.Black;
            this.lblMes33.Location = new System.Drawing.Point(477, 270);
            this.lblMes33.Name = "lblMes33";
            this.lblMes33.Size = new System.Drawing.Size(233, 20);
            this.lblMes33.TabIndex = 38;
            this.lblMes33.DoubleClick += new System.EventHandler(this.lblMes33_Click);
            // 
            // dgMes23
            // 
            this.dgMes23.BackgroundColor = System.Drawing.Color.White;
            this.dgMes23.CaptionVisible = false;
            this.dgMes23.ColumnHeadersVisible = false;
            this.dgMes23.DataMember = "";
            this.dgMes23.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgMes23.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dgMes23.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgMes23.Location = new System.Drawing.Point(244, 290);
            this.dgMes23.Name = "dgMes23";
            this.dgMes23.ParentRowsVisible = false;
            this.dgMes23.Size = new System.Drawing.Size(233, 100);
            this.dgMes23.TabIndex = 13;
            this.dgMes23.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle3});
            this.dgMes23.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dgMes23_MouseMove);
            this.dgMes23.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgMes23_MouseUp);
            // 
            // dataGridTableStyle3
            // 
            this.dataGridTableStyle3.DataGrid = this.dgMes23;
            this.dataGridTableStyle3.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn7,
            this.dataGridTextBoxColumn8,
            this.dataGridTextBoxColumn9});
            this.dataGridTableStyle3.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // dataGridTextBoxColumn7
            // 
            this.dataGridTextBoxColumn7.Format = "";
            this.dataGridTextBoxColumn7.FormatInfo = null;
            this.dataGridTextBoxColumn7.Width = 120;
            // 
            // dataGridTextBoxColumn8
            // 
            this.dataGridTextBoxColumn8.Format = "";
            this.dataGridTextBoxColumn8.FormatInfo = null;
            this.dataGridTextBoxColumn8.Width = 120;
            // 
            // dataGridTextBoxColumn9
            // 
            this.dataGridTextBoxColumn9.Format = "";
            this.dataGridTextBoxColumn9.FormatInfo = null;
            this.dataGridTextBoxColumn9.Width = 120;
            // 
            // lblMes23
            // 
            this.lblMes23.BackColor = System.Drawing.Color.LightGray;
            this.lblMes23.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMes23.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMes23.ForeColor = System.Drawing.Color.Black;
            this.lblMes23.Location = new System.Drawing.Point(244, 270);
            this.lblMes23.Name = "lblMes23";
            this.lblMes23.Size = new System.Drawing.Size(233, 20);
            this.lblMes23.TabIndex = 36;
            this.lblMes23.DoubleClick += new System.EventHandler(this.lblMes23_Click);
            // 
            // dgMes62
            // 
            this.dgMes62.BackgroundColor = System.Drawing.Color.White;
            this.dgMes62.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgMes62.CaptionVisible = false;
            this.dgMes62.ColumnHeadersVisible = false;
            this.dgMes62.DataMember = "";
            this.dgMes62.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgMes62.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dgMes62.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgMes62.Location = new System.Drawing.Point(1176, 170);
            this.dgMes62.Name = "dgMes62";
            this.dgMes62.ParentRowsVisible = false;
            this.dgMes62.Size = new System.Drawing.Size(233, 100);
            this.dgMes62.TabIndex = 11;
            this.dgMes62.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle13});
            this.dgMes62.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dgMes62_MouseMove);
            this.dgMes62.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgMes62_MouseUp);
            // 
            // dataGridTableStyle13
            // 
            this.dataGridTableStyle13.DataGrid = this.dgMes62;
            this.dataGridTableStyle13.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn37,
            this.dataGridTextBoxColumn38,
            this.dataGridTextBoxColumn39});
            this.dataGridTableStyle13.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // dataGridTextBoxColumn37
            // 
            this.dataGridTextBoxColumn37.Format = "";
            this.dataGridTextBoxColumn37.FormatInfo = null;
            this.dataGridTextBoxColumn37.Width = 120;
            // 
            // dataGridTextBoxColumn38
            // 
            this.dataGridTextBoxColumn38.Format = "";
            this.dataGridTextBoxColumn38.FormatInfo = null;
            this.dataGridTextBoxColumn38.Width = 120;
            // 
            // dataGridTextBoxColumn39
            // 
            this.dataGridTextBoxColumn39.Format = "";
            this.dataGridTextBoxColumn39.FormatInfo = null;
            this.dataGridTextBoxColumn39.Width = 120;
            // 
            // lblMes62
            // 
            this.lblMes62.BackColor = System.Drawing.Color.LightGray;
            this.lblMes62.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMes62.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMes62.ForeColor = System.Drawing.Color.Black;
            this.lblMes62.Location = new System.Drawing.Point(1176, 150);
            this.lblMes62.Name = "lblMes62";
            this.lblMes62.Size = new System.Drawing.Size(233, 20);
            this.lblMes62.TabIndex = 34;
            this.lblMes62.DoubleClick += new System.EventHandler(this.lblMes62_Click);
            // 
            // dgMes52
            // 
            this.dgMes52.BackgroundColor = System.Drawing.Color.White;
            this.dgMes52.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgMes52.CaptionVisible = false;
            this.dgMes52.ColumnHeadersVisible = false;
            this.dgMes52.DataMember = "";
            this.dgMes52.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgMes52.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dgMes52.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgMes52.Location = new System.Drawing.Point(943, 170);
            this.dgMes52.Name = "dgMes52";
            this.dgMes52.ParentRowsVisible = false;
            this.dgMes52.Size = new System.Drawing.Size(233, 100);
            this.dgMes52.TabIndex = 10;
            this.dgMes52.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle12});
            this.dgMes52.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dgMes52_MouseMove);
            this.dgMes52.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgMes52_MouseUp);
            // 
            // dataGridTableStyle12
            // 
            this.dataGridTableStyle12.DataGrid = this.dgMes52;
            this.dataGridTableStyle12.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn34,
            this.dataGridTextBoxColumn35,
            this.dataGridTextBoxColumn36});
            this.dataGridTableStyle12.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // dataGridTextBoxColumn34
            // 
            this.dataGridTextBoxColumn34.Format = "";
            this.dataGridTextBoxColumn34.FormatInfo = null;
            this.dataGridTextBoxColumn34.Width = 120;
            // 
            // dataGridTextBoxColumn35
            // 
            this.dataGridTextBoxColumn35.Format = "";
            this.dataGridTextBoxColumn35.FormatInfo = null;
            this.dataGridTextBoxColumn35.Width = 120;
            // 
            // dataGridTextBoxColumn36
            // 
            this.dataGridTextBoxColumn36.Format = "";
            this.dataGridTextBoxColumn36.FormatInfo = null;
            this.dataGridTextBoxColumn36.Width = 120;
            // 
            // lblMes52
            // 
            this.lblMes52.BackColor = System.Drawing.Color.LightGray;
            this.lblMes52.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMes52.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMes52.ForeColor = System.Drawing.Color.Black;
            this.lblMes52.Location = new System.Drawing.Point(943, 150);
            this.lblMes52.Name = "lblMes52";
            this.lblMes52.Size = new System.Drawing.Size(233, 20);
            this.lblMes52.TabIndex = 32;
            this.lblMes52.DoubleClick += new System.EventHandler(this.lblMes52_Click);
            // 
            // dgMes61
            // 
            this.dgMes61.BackgroundColor = System.Drawing.Color.White;
            this.dgMes61.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgMes61.CaptionVisible = false;
            this.dgMes61.ColumnHeadersVisible = false;
            this.dgMes61.DataMember = "";
            this.dgMes61.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgMes61.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dgMes61.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgMes61.Location = new System.Drawing.Point(1176, 50);
            this.dgMes61.Name = "dgMes61";
            this.dgMes61.ParentRowsVisible = false;
            this.dgMes61.Size = new System.Drawing.Size(233, 100);
            this.dgMes61.TabIndex = 5;
            this.dgMes61.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle10});
            this.dgMes61.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dgMes61_MouseMove);
            this.dgMes61.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgMes61_MouseUp);
            // 
            // dataGridTableStyle10
            // 
            this.dataGridTableStyle10.DataGrid = this.dgMes61;
            this.dataGridTableStyle10.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn28,
            this.dataGridTextBoxColumn29,
            this.dataGridTextBoxColumn30});
            this.dataGridTableStyle10.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // dataGridTextBoxColumn28
            // 
            this.dataGridTextBoxColumn28.Format = "";
            this.dataGridTextBoxColumn28.FormatInfo = null;
            this.dataGridTextBoxColumn28.Width = 120;
            // 
            // dataGridTextBoxColumn29
            // 
            this.dataGridTextBoxColumn29.Format = "";
            this.dataGridTextBoxColumn29.FormatInfo = null;
            this.dataGridTextBoxColumn29.Width = 120;
            // 
            // dataGridTextBoxColumn30
            // 
            this.dataGridTextBoxColumn30.Format = "";
            this.dataGridTextBoxColumn30.FormatInfo = null;
            this.dataGridTextBoxColumn30.Width = 120;
            // 
            // lblMes51
            // 
            this.lblMes51.BackColor = System.Drawing.Color.LightGray;
            this.lblMes51.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMes51.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMes51.ForeColor = System.Drawing.Color.Black;
            this.lblMes51.Location = new System.Drawing.Point(943, 30);
            this.lblMes51.Name = "lblMes51";
            this.lblMes51.Size = new System.Drawing.Size(233, 20);
            this.lblMes51.TabIndex = 28;
            this.lblMes51.DoubleClick += new System.EventHandler(this.lblMes51_Click);
            // 
            // lblMes41
            // 
            this.lblMes41.BackColor = System.Drawing.Color.LightGray;
            this.lblMes41.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMes41.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMes41.ForeColor = System.Drawing.Color.Black;
            this.lblMes41.Location = new System.Drawing.Point(710, 30);
            this.lblMes41.Name = "lblMes41";
            this.lblMes41.Size = new System.Drawing.Size(233, 20);
            this.lblMes41.TabIndex = 26;
            this.lblMes41.DoubleClick += new System.EventHandler(this.lblMes41_Click);
            // 
            // lblMes31
            // 
            this.lblMes31.BackColor = System.Drawing.Color.LightGray;
            this.lblMes31.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMes31.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMes31.ForeColor = System.Drawing.Color.Black;
            this.lblMes31.Location = new System.Drawing.Point(477, 30);
            this.lblMes31.Name = "lblMes31";
            this.lblMes31.Size = new System.Drawing.Size(233, 20);
            this.lblMes31.TabIndex = 24;
            this.lblMes31.DoubleClick += new System.EventHandler(this.lblMes31_Click);
            // 
            // dgMes15
            // 
            this.dgMes15.BackgroundColor = System.Drawing.Color.White;
            this.dgMes15.CaptionVisible = false;
            this.dgMes15.ColumnHeadersVisible = false;
            this.dgMes15.DataMember = "";
            this.dgMes15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgMes15.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dgMes15.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgMes15.Location = new System.Drawing.Point(8, 530);
            this.dgMes15.Name = "dgMes15";
            this.dgMes15.ParentRowsVisible = false;
            this.dgMes15.Size = new System.Drawing.Size(233, 100);
            this.dgMes15.TabIndex = 24;
            this.dgMes15.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle25});
            this.dgMes15.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dgMes15_MouseMove);
            this.dgMes15.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgMes15_MouseUp);
            // 
            // dataGridTableStyle25
            // 
            this.dataGridTableStyle25.DataGrid = this.dgMes15;
            this.dataGridTableStyle25.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn73,
            this.dataGridTextBoxColumn74,
            this.dataGridTextBoxColumn75});
            this.dataGridTableStyle25.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // dataGridTextBoxColumn73
            // 
            this.dataGridTextBoxColumn73.Format = "";
            this.dataGridTextBoxColumn73.FormatInfo = null;
            this.dataGridTextBoxColumn73.Width = 120;
            // 
            // dataGridTextBoxColumn74
            // 
            this.dataGridTextBoxColumn74.Format = "";
            this.dataGridTextBoxColumn74.FormatInfo = null;
            this.dataGridTextBoxColumn74.Width = 120;
            // 
            // dataGridTextBoxColumn75
            // 
            this.dataGridTextBoxColumn75.Format = "";
            this.dataGridTextBoxColumn75.FormatInfo = null;
            this.dataGridTextBoxColumn75.Width = 120;
            // 
            // lblMes15
            // 
            this.lblMes15.BackColor = System.Drawing.Color.LightGray;
            this.lblMes15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMes15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMes15.ForeColor = System.Drawing.Color.Black;
            this.lblMes15.Location = new System.Drawing.Point(8, 510);
            this.lblMes15.Name = "lblMes15";
            this.lblMes15.Size = new System.Drawing.Size(233, 20);
            this.lblMes15.TabIndex = 22;
            this.lblMes15.DoubleClick += new System.EventHandler(this.lblMes15_Click);
            // 
            // dgMes14
            // 
            this.dgMes14.BackgroundColor = System.Drawing.Color.White;
            this.dgMes14.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Bold);
            this.dgMes14.CaptionVisible = false;
            this.dgMes14.ColumnHeadersVisible = false;
            this.dgMes14.DataMember = "";
            this.dgMes14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgMes14.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dgMes14.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgMes14.Location = new System.Drawing.Point(8, 410);
            this.dgMes14.Name = "dgMes14";
            this.dgMes14.ParentRowsVisible = false;
            this.dgMes14.Size = new System.Drawing.Size(233, 100);
            this.dgMes14.TabIndex = 18;
            this.dgMes14.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle19});
            this.dgMes14.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dgMes14_MouseMove);
            this.dgMes14.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgMes14_MouseUp);
            // 
            // dataGridTableStyle19
            // 
            this.dataGridTableStyle19.DataGrid = this.dgMes14;
            this.dataGridTableStyle19.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn55,
            this.dataGridTextBoxColumn56,
            this.dataGridTextBoxColumn57});
            this.dataGridTableStyle19.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // dataGridTextBoxColumn55
            // 
            this.dataGridTextBoxColumn55.Format = "";
            this.dataGridTextBoxColumn55.FormatInfo = null;
            this.dataGridTextBoxColumn55.Width = 120;
            // 
            // dataGridTextBoxColumn56
            // 
            this.dataGridTextBoxColumn56.Format = "";
            this.dataGridTextBoxColumn56.FormatInfo = null;
            this.dataGridTextBoxColumn56.Width = 120;
            // 
            // dataGridTextBoxColumn57
            // 
            this.dataGridTextBoxColumn57.Format = "";
            this.dataGridTextBoxColumn57.FormatInfo = null;
            this.dataGridTextBoxColumn57.Width = 120;
            // 
            // lblMes14
            // 
            this.lblMes14.BackColor = System.Drawing.Color.LightGray;
            this.lblMes14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMes14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMes14.ForeColor = System.Drawing.Color.Black;
            this.lblMes14.Location = new System.Drawing.Point(8, 390);
            this.lblMes14.Name = "lblMes14";
            this.lblMes14.Size = new System.Drawing.Size(233, 20);
            this.lblMes14.TabIndex = 20;
            this.lblMes14.DoubleClick += new System.EventHandler(this.lblMes14_Click);
            // 
            // dgMes42
            // 
            this.dgMes42.BackgroundColor = System.Drawing.Color.White;
            this.dgMes42.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgMes42.CaptionVisible = false;
            this.dgMes42.ColumnHeadersVisible = false;
            this.dgMes42.DataMember = "";
            this.dgMes42.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgMes42.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dgMes42.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgMes42.Location = new System.Drawing.Point(710, 170);
            this.dgMes42.Name = "dgMes42";
            this.dgMes42.ParentRowsVisible = false;
            this.dgMes42.Size = new System.Drawing.Size(233, 100);
            this.dgMes42.TabIndex = 9;
            this.dgMes42.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dgMes42_MouseMove);
            this.dgMes42.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgMes42_MouseUp);
            // 
            // dgMes32
            // 
            this.dgMes32.BackgroundColor = System.Drawing.Color.White;
            this.dgMes32.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgMes32.CaptionVisible = false;
            this.dgMes32.ColumnHeadersVisible = false;
            this.dgMes32.DataMember = "";
            this.dgMes32.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgMes32.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dgMes32.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgMes32.Location = new System.Drawing.Point(477, 170);
            this.dgMes32.Name = "dgMes32";
            this.dgMes32.ParentRowsVisible = false;
            this.dgMes32.Size = new System.Drawing.Size(233, 100);
            this.dgMes32.TabIndex = 8;
            this.dgMes32.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle5});
            this.dgMes32.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dgMes32_MouseMove);
            this.dgMes32.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgMes32_MouseUp);
            // 
            // dataGridTableStyle5
            // 
            this.dataGridTableStyle5.DataGrid = this.dgMes32;
            this.dataGridTableStyle5.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn13,
            this.dataGridTextBoxColumn14,
            this.dataGridTextBoxColumn15});
            this.dataGridTableStyle5.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // dataGridTextBoxColumn13
            // 
            this.dataGridTextBoxColumn13.Format = "";
            this.dataGridTextBoxColumn13.FormatInfo = null;
            this.dataGridTextBoxColumn13.Width = 120;
            // 
            // dataGridTextBoxColumn14
            // 
            this.dataGridTextBoxColumn14.Format = "";
            this.dataGridTextBoxColumn14.FormatInfo = null;
            this.dataGridTextBoxColumn14.Width = 120;
            // 
            // dataGridTextBoxColumn15
            // 
            this.dataGridTextBoxColumn15.Format = "";
            this.dataGridTextBoxColumn15.FormatInfo = null;
            this.dataGridTextBoxColumn15.Width = 120;
            // 
            // dgMes22
            // 
            this.dgMes22.BackgroundColor = System.Drawing.Color.White;
            this.dgMes22.CaptionVisible = false;
            this.dgMes22.ColumnHeadersVisible = false;
            this.dgMes22.DataMember = "";
            this.dgMes22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgMes22.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dgMes22.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgMes22.Location = new System.Drawing.Point(244, 170);
            this.dgMes22.Name = "dgMes22";
            this.dgMes22.ParentRowsVisible = false;
            this.dgMes22.Size = new System.Drawing.Size(233, 100);
            this.dgMes22.TabIndex = 7;
            this.dgMes22.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle4});
            this.dgMes22.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dgMes22_MouseMove);
            this.dgMes22.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgMes22_MouseUp);
            // 
            // dataGridTableStyle4
            // 
            this.dataGridTableStyle4.DataGrid = this.dgMes22;
            this.dataGridTableStyle4.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn10,
            this.dataGridTextBoxColumn11,
            this.dataGridTextBoxColumn12});
            this.dataGridTableStyle4.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // dataGridTextBoxColumn10
            // 
            this.dataGridTextBoxColumn10.Format = "";
            this.dataGridTextBoxColumn10.FormatInfo = null;
            this.dataGridTextBoxColumn10.Width = 120;
            // 
            // dataGridTextBoxColumn11
            // 
            this.dataGridTextBoxColumn11.Format = "";
            this.dataGridTextBoxColumn11.FormatInfo = null;
            this.dataGridTextBoxColumn11.Width = 120;
            // 
            // dataGridTextBoxColumn12
            // 
            this.dataGridTextBoxColumn12.Format = "";
            this.dataGridTextBoxColumn12.FormatInfo = null;
            this.dataGridTextBoxColumn12.Width = 120;
            // 
            // dgMes13
            // 
            this.dgMes13.BackgroundColor = System.Drawing.Color.White;
            this.dgMes13.CaptionVisible = false;
            this.dgMes13.ColumnHeadersVisible = false;
            this.dgMes13.DataMember = "";
            this.dgMes13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgMes13.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dgMes13.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgMes13.Location = new System.Drawing.Point(8, 290);
            this.dgMes13.Name = "dgMes13";
            this.dgMes13.ParentRowsVisible = false;
            this.dgMes13.Size = new System.Drawing.Size(233, 100);
            this.dgMes13.TabIndex = 12;
            this.dgMes13.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle14});
            this.dgMes13.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dgMes13_MouseMove);
            this.dgMes13.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgMes13_MouseUp);
            // 
            // dataGridTableStyle14
            // 
            this.dataGridTableStyle14.DataGrid = this.dgMes13;
            this.dataGridTableStyle14.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn40,
            this.dataGridTextBoxColumn41,
            this.dataGridTextBoxColumn42});
            this.dataGridTableStyle14.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // dataGridTextBoxColumn40
            // 
            this.dataGridTextBoxColumn40.Format = "";
            this.dataGridTextBoxColumn40.FormatInfo = null;
            this.dataGridTextBoxColumn40.Width = 120;
            // 
            // dataGridTextBoxColumn41
            // 
            this.dataGridTextBoxColumn41.Format = "";
            this.dataGridTextBoxColumn41.FormatInfo = null;
            this.dataGridTextBoxColumn41.Width = 120;
            // 
            // dataGridTextBoxColumn42
            // 
            this.dataGridTextBoxColumn42.Format = "";
            this.dataGridTextBoxColumn42.FormatInfo = null;
            this.dataGridTextBoxColumn42.Width = 120;
            // 
            // lblMes13
            // 
            this.lblMes13.BackColor = System.Drawing.Color.LightGray;
            this.lblMes13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMes13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMes13.ForeColor = System.Drawing.Color.Black;
            this.lblMes13.Location = new System.Drawing.Point(8, 270);
            this.lblMes13.Name = "lblMes13";
            this.lblMes13.Size = new System.Drawing.Size(233, 20);
            this.lblMes13.TabIndex = 4;
            this.lblMes13.DoubleClick += new System.EventHandler(this.lblMes13_Click);
            // 
            // lblMes21
            // 
            this.lblMes21.BackColor = System.Drawing.Color.LightGray;
            this.lblMes21.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMes21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMes21.ForeColor = System.Drawing.Color.Black;
            this.lblMes21.Location = new System.Drawing.Point(244, 30);
            this.lblMes21.Name = "lblMes21";
            this.lblMes21.Size = new System.Drawing.Size(233, 20);
            this.lblMes21.TabIndex = 1;
            this.lblMes21.DoubleClick += new System.EventHandler(this.lblMes21_Click);
            // 
            // lblMes11
            // 
            this.lblMes11.BackColor = System.Drawing.Color.LightGray;
            this.lblMes11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMes11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMes11.ForeColor = System.Drawing.Color.Black;
            this.lblMes11.Location = new System.Drawing.Point(8, 30);
            this.lblMes11.Name = "lblMes11";
            this.lblMes11.Size = new System.Drawing.Size(233, 20);
            this.lblMes11.TabIndex = 0;
            this.lblMes11.DoubleClick += new System.EventHandler(this.lblMes11_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.label1.Location = new System.Drawing.Point(0, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(9, 15);
            this.label1.TabIndex = 39;
            // 
            // lblMes
            // 
            this.lblMes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMes.ForeColor = System.Drawing.Color.White;
            this.lblMes.GradientColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.lblMes.GradientColorTwo = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(223)))), ((int)(((byte)(236)))));
            this.lblMes.Location = new System.Drawing.Point(0, 0);
            this.lblMes.Name = "lblMes";
            this.lblMes.Size = new System.Drawing.Size(1492, 14);
            this.lblMes.TabIndex = 40;
            this.lblMes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMesLunes
            // 
            this.lblMesLunes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMesLunes.ForeColor = System.Drawing.Color.White;
            this.lblMesLunes.GradientColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.lblMesLunes.GradientColorTwo = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(223)))), ((int)(((byte)(236)))));
            this.lblMesLunes.Location = new System.Drawing.Point(8, 14);
            this.lblMesLunes.Name = "lblMesLunes";
            this.lblMesLunes.Size = new System.Drawing.Size(233, 15);
            this.lblMesLunes.TabIndex = 40;
            this.lblMesLunes.Text = "Lunes";
            // 
            // lblMesMartes
            // 
            this.lblMesMartes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMesMartes.ForeColor = System.Drawing.Color.White;
            this.lblMesMartes.GradientColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.lblMesMartes.GradientColorTwo = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(223)))), ((int)(((byte)(236)))));
            this.lblMesMartes.Location = new System.Drawing.Point(244, 14);
            this.lblMesMartes.Name = "lblMesMartes";
            this.lblMesMartes.Size = new System.Drawing.Size(233, 15);
            this.lblMesMartes.TabIndex = 41;
            this.lblMesMartes.Text = "Martes";
            // 
            // lblMesMiercoles
            // 
            this.lblMesMiercoles.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMesMiercoles.ForeColor = System.Drawing.Color.White;
            this.lblMesMiercoles.GradientColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.lblMesMiercoles.GradientColorTwo = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(223)))), ((int)(((byte)(236)))));
            this.lblMesMiercoles.Location = new System.Drawing.Point(477, 14);
            this.lblMesMiercoles.Name = "lblMesMiercoles";
            this.lblMesMiercoles.Size = new System.Drawing.Size(233, 15);
            this.lblMesMiercoles.TabIndex = 42;
            this.lblMesMiercoles.Text = "Miércoles";
            // 
            // lblMesJueves
            // 
            this.lblMesJueves.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMesJueves.ForeColor = System.Drawing.Color.White;
            this.lblMesJueves.GradientColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.lblMesJueves.GradientColorTwo = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(223)))), ((int)(((byte)(236)))));
            this.lblMesJueves.Location = new System.Drawing.Point(710, 14);
            this.lblMesJueves.Name = "lblMesJueves";
            this.lblMesJueves.Size = new System.Drawing.Size(233, 15);
            this.lblMesJueves.TabIndex = 43;
            this.lblMesJueves.Text = "Jueves";
            // 
            // lblMesViernes
            // 
            this.lblMesViernes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMesViernes.ForeColor = System.Drawing.Color.White;
            this.lblMesViernes.GradientColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.lblMesViernes.GradientColorTwo = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(223)))), ((int)(((byte)(236)))));
            this.lblMesViernes.Location = new System.Drawing.Point(943, 14);
            this.lblMesViernes.Name = "lblMesViernes";
            this.lblMesViernes.Size = new System.Drawing.Size(233, 15);
            this.lblMesViernes.TabIndex = 44;
            this.lblMesViernes.Text = "Viernes";
            // 
            // lblSabDom
            // 
            this.lblSabDom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSabDom.ForeColor = System.Drawing.Color.White;
            this.lblSabDom.GradientColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.lblSabDom.GradientColorTwo = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(223)))), ((int)(((byte)(236)))));
            this.lblSabDom.Location = new System.Drawing.Point(1176, 14);
            this.lblSabDom.Name = "lblSabDom";
            this.lblSabDom.Size = new System.Drawing.Size(233, 15);
            this.lblSabDom.TabIndex = 45;
            this.lblSabDom.Text = "Sábado/Domingo";
            // 
            // dgMes31
            // 
            this.dgMes31.BackgroundColor = System.Drawing.Color.White;
            this.dgMes31.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgMes31.CaptionVisible = false;
            this.dgMes31.ColumnHeadersVisible = false;
            this.dgMes31.DataMember = "";
            this.dgMes31.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgMes31.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dgMes31.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgMes31.Location = new System.Drawing.Point(477, 50);
            this.dgMes31.Name = "dgMes31";
            this.dgMes31.ParentRowsVisible = false;
            this.dgMes31.Size = new System.Drawing.Size(233, 100);
            this.dgMes31.TabIndex = 2;
            this.dgMes31.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            this.dgMes31.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dgMes31_MouseMove);
            this.dgMes31.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgMes31_MouseUp);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.DataGrid = this.dgMes31;
            this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn1,
            this.dataGridTextBoxColumn2,
            this.dataGridTextBoxColumn3});
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.Width = 120;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.Width = 120;
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.Width = 120;
            // 
            // dgMes41
            // 
            this.dgMes41.BackgroundColor = System.Drawing.Color.White;
            this.dgMes41.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgMes41.CaptionVisible = false;
            this.dgMes41.ColumnHeadersVisible = false;
            this.dgMes41.DataMember = "";
            this.dgMes41.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgMes41.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dgMes41.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgMes41.Location = new System.Drawing.Point(710, 50);
            this.dgMes41.Name = "dgMes41";
            this.dgMes41.ParentRowsVisible = false;
            this.dgMes41.Size = new System.Drawing.Size(233, 100);
            this.dgMes41.TabIndex = 3;
            this.dgMes41.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle8});
            this.dgMes41.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dgMes41_MouseMove);
            this.dgMes41.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgMes41_MouseUp);
            // 
            // dataGridTableStyle8
            // 
            this.dataGridTableStyle8.DataGrid = this.dgMes41;
            this.dataGridTableStyle8.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn22,
            this.dataGridTextBoxColumn23,
            this.dataGridTextBoxColumn24});
            this.dataGridTableStyle8.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // dataGridTextBoxColumn22
            // 
            this.dataGridTextBoxColumn22.Format = "";
            this.dataGridTextBoxColumn22.FormatInfo = null;
            this.dataGridTextBoxColumn22.Width = 120;
            // 
            // dataGridTextBoxColumn23
            // 
            this.dataGridTextBoxColumn23.Format = "";
            this.dataGridTextBoxColumn23.FormatInfo = null;
            this.dataGridTextBoxColumn23.Width = 120;
            // 
            // dataGridTextBoxColumn24
            // 
            this.dataGridTextBoxColumn24.Format = "";
            this.dataGridTextBoxColumn24.FormatInfo = null;
            this.dataGridTextBoxColumn24.Width = 120;
            // 
            // dgMes51
            // 
            this.dgMes51.BackgroundColor = System.Drawing.Color.White;
            this.dgMes51.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgMes51.CaptionVisible = false;
            this.dgMes51.ColumnHeadersVisible = false;
            this.dgMes51.DataMember = "";
            this.dgMes51.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgMes51.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dgMes51.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgMes51.Location = new System.Drawing.Point(943, 50);
            this.dgMes51.Name = "dgMes51";
            this.dgMes51.ParentRowsVisible = false;
            this.dgMes51.Size = new System.Drawing.Size(233, 100);
            this.dgMes51.TabIndex = 4;
            this.dgMes51.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle9});
            this.dgMes51.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dgMes51_MouseMove);
            this.dgMes51.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgMes51_MouseUp);
            // 
            // dataGridTableStyle9
            // 
            this.dataGridTableStyle9.DataGrid = this.dgMes51;
            this.dataGridTableStyle9.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn25,
            this.dataGridTextBoxColumn26,
            this.dataGridTextBoxColumn27});
            this.dataGridTableStyle9.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // dataGridTextBoxColumn25
            // 
            this.dataGridTextBoxColumn25.Format = "";
            this.dataGridTextBoxColumn25.FormatInfo = null;
            this.dataGridTextBoxColumn25.Width = 120;
            // 
            // dataGridTextBoxColumn26
            // 
            this.dataGridTextBoxColumn26.Format = "";
            this.dataGridTextBoxColumn26.FormatInfo = null;
            this.dataGridTextBoxColumn26.Width = 120;
            // 
            // dataGridTextBoxColumn27
            // 
            this.dataGridTextBoxColumn27.Format = "";
            this.dataGridTextBoxColumn27.FormatInfo = null;
            this.dataGridTextBoxColumn27.Width = 120;
            // 
            // dgMes12
            // 
            this.dgMes12.BackgroundColor = System.Drawing.Color.White;
            this.dgMes12.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgMes12.CaptionVisible = false;
            this.dgMes12.ColumnHeadersVisible = false;
            this.dgMes12.DataMember = "";
            this.dgMes12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgMes12.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dgMes12.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgMes12.Location = new System.Drawing.Point(8, 170);
            this.dgMes12.Name = "dgMes12";
            this.dgMes12.ParentRowsVisible = false;
            this.dgMes12.Size = new System.Drawing.Size(233, 100);
            this.dgMes12.TabIndex = 6;
            this.dgMes12.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle11});
            this.dgMes12.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dgMes12_MouseMove);
            this.dgMes12.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgMes12_MouseUp);
            // 
            // dataGridTableStyle11
            // 
            this.dataGridTableStyle11.DataGrid = this.dgMes12;
            this.dataGridTableStyle11.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn31,
            this.dataGridTextBoxColumn32,
            this.dataGridTextBoxColumn33});
            this.dataGridTableStyle11.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // dataGridTextBoxColumn31
            // 
            this.dataGridTextBoxColumn31.Format = "";
            this.dataGridTextBoxColumn31.FormatInfo = null;
            this.dataGridTextBoxColumn31.Width = 120;
            // 
            // dataGridTextBoxColumn32
            // 
            this.dataGridTextBoxColumn32.Format = "";
            this.dataGridTextBoxColumn32.FormatInfo = null;
            this.dataGridTextBoxColumn32.Width = 120;
            // 
            // dataGridTextBoxColumn33
            // 
            this.dataGridTextBoxColumn33.Format = "";
            this.dataGridTextBoxColumn33.FormatInfo = null;
            this.dataGridTextBoxColumn33.Width = 120;
            // 
            // dgMes21
            // 
            this.dgMes21.BackgroundColor = System.Drawing.Color.White;
            this.dgMes21.CaptionVisible = false;
            this.dgMes21.ColumnHeadersVisible = false;
            this.dgMes21.DataMember = "";
            this.dgMes21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgMes21.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dgMes21.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgMes21.Location = new System.Drawing.Point(244, 50);
            this.dgMes21.Name = "dgMes21";
            this.dgMes21.ParentRowsVisible = false;
            this.dgMes21.Size = new System.Drawing.Size(233, 100);
            this.dgMes21.TabIndex = 1;
            this.dgMes21.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle2});
            this.dgMes21.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dgMes21_MouseMove);
            this.dgMes21.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgMes21_MouseUp);
            // 
            // dataGridTableStyle2
            // 
            this.dataGridTableStyle2.DataGrid = this.dgMes21;
            this.dataGridTableStyle2.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn4,
            this.dataGridTextBoxColumn5,
            this.dataGridTextBoxColumn6});
            this.dataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // dataGridTextBoxColumn4
            // 
            this.dataGridTextBoxColumn4.Format = "";
            this.dataGridTextBoxColumn4.FormatInfo = null;
            this.dataGridTextBoxColumn4.Width = 120;
            // 
            // dataGridTextBoxColumn5
            // 
            this.dataGridTextBoxColumn5.Format = "";
            this.dataGridTextBoxColumn5.FormatInfo = null;
            this.dataGridTextBoxColumn5.Width = 120;
            // 
            // dataGridTextBoxColumn6
            // 
            this.dataGridTextBoxColumn6.Format = "";
            this.dataGridTextBoxColumn6.FormatInfo = null;
            this.dataGridTextBoxColumn6.Width = 120;
            // 
            // dgMes11
            // 
            this.dgMes11.BackgroundColor = System.Drawing.Color.White;
            this.dgMes11.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgMes11.CaptionVisible = false;
            this.dgMes11.ColumnHeadersVisible = false;
            this.dgMes11.DataMember = "";
            this.dgMes11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgMes11.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dgMes11.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgMes11.Location = new System.Drawing.Point(8, 50);
            this.dgMes11.Name = "dgMes11";
            this.dgMes11.ParentRowsVisible = false;
            this.dgMes11.RowHeadersVisible = false;
            this.dgMes11.Size = new System.Drawing.Size(233, 100);
            this.dgMes11.TabIndex = 0;
            this.dgMes11.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle7});
            this.dgMes11.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dgMes11_MouseMove);
            this.dgMes11.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgMes11_MouseUp);
            // 
            // dataGridTableStyle7
            // 
            this.dataGridTableStyle7.DataGrid = this.dgMes11;
            this.dataGridTableStyle7.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn19,
            this.dataGridTextBoxColumn20,
            this.dataGridTextBoxColumn21});
            this.dataGridTableStyle7.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // dataGridTextBoxColumn19
            // 
            this.dataGridTextBoxColumn19.Format = "";
            this.dataGridTextBoxColumn19.FormatInfo = null;
            this.dataGridTextBoxColumn19.Width = 10;
            // 
            // dataGridTextBoxColumn20
            // 
            this.dataGridTextBoxColumn20.Format = "";
            this.dataGridTextBoxColumn20.FormatInfo = null;
            this.dataGridTextBoxColumn20.Width = 10;
            // 
            // dataGridTextBoxColumn21
            // 
            this.dataGridTextBoxColumn21.Format = "";
            this.dataGridTextBoxColumn21.FormatInfo = null;
            this.dataGridTextBoxColumn21.Width = 120;
            // 
            // pnDiario
            // 
            this.pnDiario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnDiario.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnDiario.Controls.Add(this.pnDatosDiario);
            this.pnDiario.Controls.Add(this.dgDiario);
            this.pnDiario.Controls.Add(this.lblDiario);
            this.pnDiario.ForeColor = System.Drawing.Color.Black;
            this.pnDiario.Location = new System.Drawing.Point(1, 96);
            this.pnDiario.Name = "pnDiario";
            this.pnDiario.Size = new System.Drawing.Size(1492, 760);
            this.pnDiario.TabIndex = 1;
            this.pnDiario.Visible = false;
            // 
            // pnDatosDiario
            // 
            this.pnDatosDiario.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnDatosDiario.Controls.Add(this.pnObservaciones);
            this.pnDatosDiario.Controls.Add(this.btGuardarObserv);
            this.pnDatosDiario.Controls.Add(this.txtDiaObserv);
            this.pnDatosDiario.Controls.Add(this.pnProxObj);
            this.pnDatosDiario.Controls.Add(this.label2);
            this.pnDatosDiario.Location = new System.Drawing.Point(5, 304);
            this.pnDatosDiario.Name = "pnDatosDiario";
            this.pnDatosDiario.Size = new System.Drawing.Size(1475, 449);
            this.pnDatosDiario.TabIndex = 1;
            // 
            // pnObservaciones
            // 
            this.pnObservaciones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnObservaciones.Controls.Add(this.lblTotObserv);
            this.pnObservaciones.Controls.Add(this.txtObservRep);
            this.pnObservaciones.Controls.Add(this.dgObservaciones);
            this.pnObservaciones.Controls.Add(this.labelGradient1);
            this.pnObservaciones.Controls.Add(this.label3);
            this.pnObservaciones.Location = new System.Drawing.Point(3, 264);
            this.pnObservaciones.Name = "pnObservaciones";
            this.pnObservaciones.Size = new System.Drawing.Size(1265, 150);
            this.pnObservaciones.TabIndex = 8;
            // 
            // lblTotObserv
            // 
            this.lblTotObserv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.lblTotObserv.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotObserv.Location = new System.Drawing.Point(1199, 0);
            this.lblTotObserv.Name = "lblTotObserv";
            this.lblTotObserv.Size = new System.Drawing.Size(60, 18);
            this.lblTotObserv.TabIndex = 4;
            this.lblTotObserv.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtObservRep
            // 
            this.txtObservRep.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtObservRep.Location = new System.Drawing.Point(0, 40);
            this.txtObservRep.Multiline = true;
            this.txtObservRep.Name = "txtObservRep";
            this.txtObservRep.ReadOnly = true;
            this.txtObservRep.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObservRep.Size = new System.Drawing.Size(233, 108);
            this.txtObservRep.TabIndex = 2;
            // 
            // dgObservaciones
            // 
            this.dgObservaciones.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgObservaciones.CaptionVisible = false;
            this.dgObservaciones.DataMember = "ListaRepActividad_Observaciones";
            this.dgObservaciones.DataSource = this.dsReports1;
            this.dgObservaciones.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgObservaciones.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgObservaciones.Location = new System.Drawing.Point(239, 18);
            this.dgObservaciones.Name = "dgObservaciones";
            this.dgObservaciones.ReadOnly = true;
            this.dgObservaciones.Size = new System.Drawing.Size(1021, 141);
            this.dgObservaciones.TabIndex = 1;
            this.dgObservaciones.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle44});
            // 
            // dataGridTableStyle44
            // 
            this.dataGridTableStyle44.DataGrid = this.dgObservaciones;
            this.dataGridTableStyle44.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn138,
            this.dataGridTextBoxColumn139,
            this.dataGridTextBoxColumn140});
            this.dataGridTableStyle44.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle44.MappingName = "ListaRepActividad_Observaciones";
            // 
            // dataGridTextBoxColumn138
            // 
            this.dataGridTextBoxColumn138.Format = "";
            this.dataGridTextBoxColumn138.FormatInfo = null;
            this.dataGridTextBoxColumn138.HeaderText = "Cód.Cliente";
            this.dataGridTextBoxColumn138.MappingName = "sIdCliente";
            this.dataGridTextBoxColumn138.NullText = "";
            this.dataGridTextBoxColumn138.Width = 120;
            // 
            // dataGridTextBoxColumn139
            // 
            this.dataGridTextBoxColumn139.Format = "";
            this.dataGridTextBoxColumn139.FormatInfo = null;
            this.dataGridTextBoxColumn139.HeaderText = "Nombre";
            this.dataGridTextBoxColumn139.MappingName = "sNombre";
            this.dataGridTextBoxColumn139.NullText = "";
            this.dataGridTextBoxColumn139.Width = 250;
            // 
            // dataGridTextBoxColumn140
            // 
            this.dataGridTextBoxColumn140.Format = "";
            this.dataGridTextBoxColumn140.FormatInfo = null;
            this.dataGridTextBoxColumn140.HeaderText = "Observaciones";
            this.dataGridTextBoxColumn140.MappingName = "tObservaciones_Cli";
            this.dataGridTextBoxColumn140.NullText = "";
            this.dataGridTextBoxColumn140.Width = 600;
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
            this.labelGradient1.Size = new System.Drawing.Size(1261, 18);
            this.labelGradient1.TabIndex = 0;
            this.labelGradient1.Text = "Observaciones Realizadas en la Visita";
            this.labelGradient1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(0, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 18);
            this.label3.TabIndex = 3;
            this.label3.Text = "Conjuntas:";
            // 
            // btGuardarObserv
            // 
            this.btGuardarObserv.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btGuardarObserv.ImageIndex = 0;
            this.btGuardarObserv.ImageList = this.imageList1;
            this.btGuardarObserv.Location = new System.Drawing.Point(1088, 24);
            this.btGuardarObserv.Name = "btGuardarObserv";
            this.btGuardarObserv.Size = new System.Drawing.Size(180, 64);
            this.btGuardarObserv.TabIndex = 7;
            this.btGuardarObserv.Text = "Grabar Observaciones";
            this.btGuardarObserv.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btGuardarObserv.UseVisualStyleBackColor = true;
            this.btGuardarObserv.Click += new System.EventHandler(this.btGuardarObserv_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            // 
            // txtDiaObserv
            // 
            this.txtDiaObserv.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiaObserv.Location = new System.Drawing.Point(8, 24);
            this.txtDiaObserv.MaxLength = 8000;
            this.txtDiaObserv.Multiline = true;
            this.txtDiaObserv.Name = "txtDiaObserv";
            this.txtDiaObserv.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDiaObserv.Size = new System.Drawing.Size(1070, 64);
            this.txtDiaObserv.TabIndex = 5;
            // 
            // pnProxObj
            // 
            this.pnProxObj.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnProxObj.Controls.Add(this.dgClientesProxObj);
            this.pnProxObj.Controls.Add(this.lblTotProxObj);
            this.pnProxObj.Controls.Add(this.lblObjetivos);
            this.pnProxObj.Location = new System.Drawing.Point(3, 96);
            this.pnProxObj.Name = "pnProxObj";
            this.pnProxObj.Size = new System.Drawing.Size(1265, 162);
            this.pnProxObj.TabIndex = 4;
            // 
            // dgClientesProxObj
            // 
            this.dgClientesProxObj.CaptionText = "Objetivos Fijados en la Ultima Visita";
            this.dgClientesProxObj.CaptionVisible = false;
            this.dgClientesProxObj.DataMember = "ListaRepActividadCli_ProxObj";
            this.dgClientesProxObj.DataSource = this.dsReports1;
            this.dgClientesProxObj.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgClientesProxObj.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgClientesProxObj.Location = new System.Drawing.Point(-2, 18);
            this.dgClientesProxObj.Name = "dgClientesProxObj";
            this.dgClientesProxObj.ReadOnly = true;
            this.dgClientesProxObj.RowHeaderWidth = 17;
            this.dgClientesProxObj.Size = new System.Drawing.Size(1263, 142);
            this.dgClientesProxObj.TabIndex = 2;
            this.dgClientesProxObj.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle6});
            // 
            // dataGridTableStyle6
            // 
            this.dataGridTableStyle6.DataGrid = this.dgClientesProxObj;
            this.dataGridTableStyle6.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn16,
            this.dataGridTextBoxColumn17,
            this.dataGridTextBoxColumn18,
            this.dataGridTextBoxColumn137});
            this.dataGridTableStyle6.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle6.MappingName = "ListaRepActividadCli_ProxObj";
            this.dataGridTableStyle6.RowHeaderWidth = 17;
            // 
            // dataGridTextBoxColumn16
            // 
            this.dataGridTextBoxColumn16.Format = "";
            this.dataGridTextBoxColumn16.FormatInfo = null;
            this.dataGridTextBoxColumn16.HeaderText = "Código";
            this.dataGridTextBoxColumn16.MappingName = "sIdCliente";
            this.dataGridTextBoxColumn16.NullText = "";
            this.dataGridTextBoxColumn16.Width = 120;
            // 
            // dataGridTextBoxColumn17
            // 
            this.dataGridTextBoxColumn17.Format = "";
            this.dataGridTextBoxColumn17.FormatInfo = null;
            this.dataGridTextBoxColumn17.HeaderText = "Nombre";
            this.dataGridTextBoxColumn17.MappingName = "sNombre";
            this.dataGridTextBoxColumn17.NullText = "";
            this.dataGridTextBoxColumn17.Width = 400;
            // 
            // dataGridTextBoxColumn18
            // 
            this.dataGridTextBoxColumn18.Format = "";
            this.dataGridTextBoxColumn18.FormatInfo = null;
            this.dataGridTextBoxColumn18.HeaderText = "Próximos Objetivos";
            this.dataGridTextBoxColumn18.MappingName = "tProxObj";
            this.dataGridTextBoxColumn18.NullText = "";
            this.dataGridTextBoxColumn18.Width = 580;
            // 
            // dataGridTextBoxColumn137
            // 
            this.dataGridTextBoxColumn137.Format = "dd/MM/yyyy";
            this.dataGridTextBoxColumn137.FormatInfo = null;
            this.dataGridTextBoxColumn137.HeaderText = "Ultima Visita";
            this.dataGridTextBoxColumn137.MappingName = "dFecha";
            this.dataGridTextBoxColumn137.NullText = "";
            this.dataGridTextBoxColumn137.Width = 120;
            // 
            // lblTotProxObj
            // 
            this.lblTotProxObj.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.lblTotProxObj.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotProxObj.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotProxObj.ForeColor = System.Drawing.Color.Black;
            this.lblTotProxObj.Location = new System.Drawing.Point(1200, 0);
            this.lblTotProxObj.Name = "lblTotProxObj";
            this.lblTotProxObj.Size = new System.Drawing.Size(60, 18);
            this.lblTotProxObj.TabIndex = 3;
            this.lblTotProxObj.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblObjetivos
            // 
            this.lblObjetivos.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblObjetivos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblObjetivos.ForeColor = System.Drawing.Color.White;
            this.lblObjetivos.GradientColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.lblObjetivos.GradientColorTwo = System.Drawing.Color.White;
            this.lblObjetivos.Location = new System.Drawing.Point(0, 0);
            this.lblObjetivos.Name = "lblObjetivos";
            this.lblObjetivos.Size = new System.Drawing.Size(1261, 18);
            this.lblObjetivos.TabIndex = 0;
            this.lblObjetivos.Text = "Objetivos fijados en la última visita";
            this.lblObjetivos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(218, 18);
            this.label2.TabIndex = 6;
            this.label2.Text = "Observaciones del día:";
            // 
            // lblDiario
            // 
            this.lblDiario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiario.ForeColor = System.Drawing.Color.White;
            this.lblDiario.GradientColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.lblDiario.GradientColorTwo = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(223)))), ((int)(((byte)(236)))));
            this.lblDiario.Location = new System.Drawing.Point(0, 0);
            this.lblDiario.Name = "lblDiario";
            this.lblDiario.Size = new System.Drawing.Size(1485, 21);
            this.lblDiario.TabIndex = 74;
            this.lblDiario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBoxArrastro
            // 
            this.pictureBoxArrastro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxArrastro.Image = global::GESTCRM.Properties.Resources.estrella;
            this.pictureBoxArrastro.Location = new System.Drawing.Point(369, 50);
            this.pictureBoxArrastro.Name = "pictureBoxArrastro";
            this.pictureBoxArrastro.Size = new System.Drawing.Size(19, 16);
            this.pictureBoxArrastro.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxArrastro.TabIndex = 75;
            this.pictureBoxArrastro.TabStop = false;
            this.pictureBoxArrastro.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxArrastro_MouseDown);
            // 
            // sqldaListaDelegados
            // 
            this.sqldaListaDelegados.SelectCommand = this.sqlCommand1;
            this.sqldaListaDelegados.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaDelegados", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iIdDelegado", "iIdDelegado"),
                        new System.Data.Common.DataColumnMapping("sNombre", "sNombre")})});
            // 
            // sqlCommand1
            // 
            this.sqlCommand1.CommandText = "[ListaDelegados]";
            this.sqlCommand1.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCommand1.Connection = this.sqlConn;
            this.sqlCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null)});
            // 
            // sqlcmdSetRepActividad_Cab
            // 
            this.sqlcmdSetRepActividad_Cab.CommandText = "[SetRepActividad_Cab]";
            this.sqlcmdSetRepActividad_Cab.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlcmdSetRepActividad_Cab.Connection = this.sqlConn;
            this.sqlcmdSetRepActividad_Cab.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@Accion", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdReport", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdDelegado", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sIdReportTemp", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@sTipoRActividad", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@sIdTipoCliente", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@iIdCentro", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@dFecha", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@iHorario", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@tObjetivo", System.Data.SqlDbType.VarChar, 2147483647),
            new System.Data.SqlClient.SqlParameter("@tProxObjetivo", System.Data.SqlDbType.VarChar, 2147483647),
            new System.Data.SqlClient.SqlParameter("@tObservaciones", System.Data.SqlDbType.VarChar, 2147483647),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt, 2)});
            // 
            // ucBotoneraSecundaria1
            // 
            this.ucBotoneraSecundaria1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(117)))), ((int)(((byte)(1)))));
            this.ucBotoneraSecundaria1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucBotoneraSecundaria1.ForeColor = System.Drawing.Color.Black;
            this.ucBotoneraSecundaria1.Location = new System.Drawing.Point(0, 0);
            this.ucBotoneraSecundaria1.Name = "ucBotoneraSecundaria1";
            this.ucBotoneraSecundaria1.Size = new System.Drawing.Size(1587, 38);
            this.ucBotoneraSecundaria1.TabIndex = 39;
            // 
            // sqldaListaRepActividad_ProxObj
            // 
            this.sqldaListaRepActividad_ProxObj.SelectCommand = this.sqlSelectCommand2;
            this.sqldaListaRepActividad_ProxObj.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaRepActividadCli_ProxObj", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iIdReport", "iIdReport"),
                        new System.Data.Common.DataColumnMapping("iIdCliente", "iIdCliente"),
                        new System.Data.Common.DataColumnMapping("sIdCliente", "sIdCliente"),
                        new System.Data.Common.DataColumnMapping("sNombre", "sNombre"),
                        new System.Data.Common.DataColumnMapping("tProxObj", "tProxObj"),
                        new System.Data.Common.DataColumnMapping("dFecha", "dFecha")})});
            // 
            // sqlSelectCommand2
            // 
            this.sqlSelectCommand2.CommandText = "[ListaRepActividadCli_ProxObj]";
            this.sqlSelectCommand2.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand2.Connection = this.sqlConn;
            this.sqlSelectCommand2.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdCentro", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4)});
            // 
            // sqldaListaRepActividad_Obsevaciones
            // 
            this.sqldaListaRepActividad_Obsevaciones.SelectCommand = this.sqlSelectCommand3;
            this.sqldaListaRepActividad_Obsevaciones.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaRepActividad_Observaciones", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iIdReport", "iIdReport"),
                        new System.Data.Common.DataColumnMapping("iIdCliente", "iIdCliente"),
                        new System.Data.Common.DataColumnMapping("sIdCliente", "sIdCliente"),
                        new System.Data.Common.DataColumnMapping("sNombre", "sNombre"),
                        new System.Data.Common.DataColumnMapping("tObservaciones_Rep", "tObservaciones_Rep"),
                        new System.Data.Common.DataColumnMapping("tObservaciones_Cli", "tObservaciones_Cli")})});
            // 
            // sqlSelectCommand3
            // 
            this.sqlSelectCommand3.CommandText = "[ListaRepActividad_Observaciones]";
            this.sqlSelectCommand3.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand3.Connection = this.sqlConn;
            this.sqlSelectCommand3.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdReport", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4)});
            // 
            // sqldaListaAgendaObserv
            // 
            this.sqldaListaAgendaObserv.SelectCommand = this.sqlSelectCommand4;
            this.sqldaListaAgendaObserv.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaAgendaObserv", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("dFecha", "dFecha"),
                        new System.Data.Common.DataColumnMapping("tObservaciones", "tObservaciones")})});
            // 
            // sqlSelectCommand4
            // 
            this.sqlSelectCommand4.CommandText = "[ListaAgendaObserv]";
            this.sqlSelectCommand4.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand4.Connection = this.sqlConn;
            this.sqlSelectCommand4.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdDelegado", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@dFecha", System.Data.SqlDbType.DateTime, 8)});
            // 
            // sqlCmdSetAgendaObserv
            // 
            this.sqlCmdSetAgendaObserv.CommandText = "[SetAgendaObserv]";
            this.sqlCmdSetAgendaObserv.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdSetAgendaObserv.Connection = this.sqlConn;
            this.sqlCmdSetAgendaObserv.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@Accion", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdDelegado", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@dFecha", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@tObservaciones", System.Data.SqlDbType.VarChar, 8000)});
            // 
            // sqlCmdGetPuedeBorrarReport
            // 
            this.sqlCmdGetPuedeBorrarReport.CommandText = "[GetPuedeBorrarReport]";
            this.sqlCmdGetPuedeBorrarReport.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdGetPuedeBorrarReport.Connection = this.sqlConn;
            this.sqlCmdGetPuedeBorrarReport.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdReport", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@Total", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Output, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null)});
            // 
            // sqlCmdGetVisitaDePlanif
            // 
            this.sqlCmdGetVisitaDePlanif.CommandText = "[GetVisitaDePlanif]";
            this.sqlCmdGetVisitaDePlanif.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdGetVisitaDePlanif.Connection = this.sqlConn;
            this.sqlCmdGetVisitaDePlanif.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@dFechaIni", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@dFechaFin", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@iIdReport", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Output, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null)});
            // 
            // frmConsultaVisit
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 19);
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.ClientSize = new System.Drawing.Size(1604, 781);
            this.Controls.Add(this.pictureBoxArrastro);
            this.Controls.Add(this.lblDelegado);
            this.Controls.Add(this.cbDelegado);
            this.Controls.Add(this.lblCalendario);
            this.Controls.Add(this.dtpCalendario);
            this.Controls.Add(this.ucBotoneraSecundaria1);
            this.Controls.Add(this.pnDiario);
            this.Controls.Add(this.pnMensual);
            this.Controls.Add(this.pnSemana);
            this.Controls.Add(this.pnDatos);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmConsultaVisit";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Planificación de Visitas";
            this.Activated += new System.EventHandler(this.frmConsultaVisit_Activated);
            this.Closed += new System.EventHandler(this.frmConsultaVisit_Closed);
            this.Load += new System.EventHandler(this.frmConsultaVisit_Load);
            this.pnSemana.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgSemana7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgSemana6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgSemana5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgSemana4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgSemana3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgSemana1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgSemana2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgDiario)).EndInit();
            this.pnDatos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dsReports1)).EndInit();
            this.pnMensual.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgMes66)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMes56)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMes46)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMes36)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMes26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMes16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMes65)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMes55)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMes45)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMes35)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMes25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMes64)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMes54)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMes44)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMes34)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMes24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMes63)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMes53)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMes43)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMes33)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMes23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMes62)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMes52)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMes61)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMes15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMes14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMes42)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMes32)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMes22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMes13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMes31)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMes41)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMes51)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMes12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMes21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMes11)).EndInit();
            this.pnDiario.ResumeLayout(false);
            this.pnDatosDiario.ResumeLayout(false);
            this.pnDatosDiario.PerformLayout();
            this.pnObservaciones.ResumeLayout(false);
            this.pnObservaciones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgObservaciones)).EndInit();
            this.pnProxObj.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgClientesProxObj)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxArrastro)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        #region frmConsultaVisit_Load
        private void frmConsultaVisit_Load(object sender, System.EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            //---- GSG (15/06/2016)
            pictureBoxArrastro.AllowDrop = true; 
            pictureBoxArrastro.Location = new System.Drawing.Point(_K_LOC_X, _K_LOC_Y);
            pictureBoxArrastro.Visible = false;

            try
            {
                GESTCRM.Utiles.Formato_Formulario(this);
                if (this.Parent == null) this.WindowState = FormWindowState.Normal;

                if (GESTCRM.Clases.Configuracion.iGVisitas == 1) this.Var_TipoAcceso = "C";
                else this.Var_TipoAcceso = "M";

                this.Var_CambioFecha = 0;
                this.dFecha = DateTime.Today;
                this.dtpCalendario.Value = this.dFecha;

                this.pnDiario.Location = new Point(1, 96);
                this.pnDiario.Visible = false;
                this.pnDiario.Height = 570;
                this.pnDatosDiario.Height = 256;
                this.pnProxObj.Location = new Point(3, 96);
                this.pnProxObj.Visible = false;
                this.pnObservaciones.Location = new Point(3, 96);
                this.pnObservaciones.Visible = false;

                this.pnSemana.Location = new Point(1, 96);
                this.pnSemana.Visible = false;

                this.pnMensual.Location = new Point(1, 96);
                this.pnMensual.Visible = false;
                this.lblPnMes.Visible = false;

                Inicializar_dtDias();
                Cargar_cbDelegado();
                Inicializar_Botonera();


                // ---- GSG (16/03/2015)
                //Inicializar_FormatoDataGrid(this.pnDiario,true,true,70,60,60,580);
                //Inicializar_FormatoDataGrid(this.pnSemana,false,false,70,20,50,290);
                //Inicializar_FormatoDataGrid(this.pnMensual,false,false,14,14,14,90);
                //---- GSG (13/03/2019)
                //Inicializar_FormatoDataGrid(this.pnDiario, true, true, 70, 60, 60, 580);
                //Inicializar_FormatoDataGrid(this.pnSemana, false, false, 70, 20, 50, 400);
                //Inicializar_FormatoDataGrid(this.pnMensual, false, false, 14, 14, 14, 162);
                Inicializar_FormatoDataGrid(this.pnDiario, true, true, 100, 90, 90, 700);                               
                Inicializar_FormatoDataGrid(this.pnSemana, false, false, 100, 80, 20, 500);
                Inicializar_FormatoDataGrid(this.pnMensual, false, false, 14, 14, 14, 182);
                //---- FI GSG



                Utiles.Formatear_DataGrid(this, this.dgClientesProxObj, "C", true, null);
                Utiles.Formatear_DataGrid(this, this.dgObservaciones, "C", true, null);

                if (this.Var_TipoAcceso == "C")
                {
                    this.cntMnuEliminar.Enabled = false;
                    this.cntMnuNuevo.Enabled = false;
                    Activar_AgendaObserv(false);
                }

                Ver_Semana();

                //---- GSG (01/02/2017)
                Comun._lNomsPlanificats.Clear(); 
                


            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }

            Cursor.Current = Cursors.Default;
        }
        #endregion

        #region Inicializar_Botonera
        private void Inicializar_Botonera()
        {
            try
            {
                this.ucBotoneraSecundaria1.btSalir.Click += new EventHandler(btSalir_Click);
                this.ucBotoneraSecundaria1.btNuevo.Click += new EventHandler(btNuevo_Click);
                this.ucBotoneraSecundaria1.btEditar.Click += new EventHandler(btEditar_Click);
                this.ucBotoneraSecundaria1.btEliminar.Click += new EventHandler(btEliminar_Click);

                if (this.Var_TipoAcceso == "M")
                {
                    this.ucBotoneraSecundaria1.Activar_botonera(true, true, true, true, false, false);
                }
                else
                {
                    this.ucBotoneraSecundaria1.Activar_botonera(true, false, true, false, false, false);
                }
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }
        #endregion

        #region Inicializar_dtDias
        private void Inicializar_dtDias()
        {
            try
            {
                dtDias = new DataTable();
                dtDias.Columns.Add("NumDia");
                dtDias.Columns.Add("FechaDia");
                dtDias.Columns.Add("FilaDg");
                dtDias.Columns.Add("iIdReport");
                dtDias.Columns.Add("bEnviadoCEN");
                //---- GSG (15/06/2016)
                dtDias.Columns.Add("dibu");
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }
        #endregion

        #region Cargar_cbDelegado
        private void Cargar_cbDelegado()
        {
            try
            {
                this.sqldaListaDelegados.Fill(this.dsReports1);
                try
                {
                    this.cbDelegado.SelectedValue = GESTCRM.Clases.Configuracion.iIdDelegado.ToString();
                    this.IdDelegado = int.Parse(this.cbDelegado.SelectedValue.ToString());
                }
                catch { }
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }
        #endregion

        #region FormatoDataGrid
        private void FormatoDataGrid(GESTCRM.MiDataGrid dg, bool VerCabecera, bool VerFila, int AnchoCol0, int AnchoCol1, int AnchoCol2, int AnchoCol3)
        {
            try
            {

                DataGridTableStyle ts = new DataGridTableStyle();


                ts.MappingName = "";

                //Columna Tipo de Report de Actividad
                DataGridColoredTextBoxColumn cs0 = new DataGridColoredTextBoxColumn();
                cs0.HeaderText = "Tipo";
                cs0.MappingName = "Tipo";
                cs0.NullText = "";
                cs0.Width = AnchoCol0;
                DataGridTextBoxColumn TextCol0 = (DataGridTextBoxColumn)cs0;
                TextCol0.TextBox.ContextMenu = this.cntMnuDataGrid;
                TextCol0.TextBox.DoubleClick += new EventHandler(TextBoxDoubleClickHandler);

                ts.GridColumnStyles.Add(cs0);

                //Columna Tiene Proximos Objetivos
                DataGridColoredTextBoxColumn cs1 = new DataGridColoredTextBoxColumn();
                cs1.HeaderText = "Prox.Obj.";
                cs1.MappingName = "ProxObj";
                cs1.NullText = "";
                cs1.Alignment = HorizontalAlignment.Center;
                cs1.Width = AnchoCol1;
                DataGridTextBoxColumn TextCol1 = (DataGridTextBoxColumn)cs1;
                TextCol1.TextBox.ContextMenu = this.cntMnuDataGrid;
                TextCol1.TextBox.DoubleClick += new EventHandler(TextBoxDoubleClickHandler);

                ts.GridColumnStyles.Add(cs1);

                //Columna Horario 
                DataGridColoredTextBoxColumn cs2 = new DataGridColoredTextBoxColumn();
                cs2.HeaderText = "Horario";
                cs2.MappingName = "Horario";
                cs2.NullText = "";
                cs2.Width = AnchoCol2;
                DataGridTextBoxColumn TextCol2 = (DataGridTextBoxColumn)cs2;
                TextCol2.TextBox.ContextMenu = this.cntMnuDataGrid;
                TextCol2.TextBox.DoubleClick += new EventHandler(TextBoxDoubleClickHandler);

                ts.GridColumnStyles.Add(cs2);

                //Columna Nombre
                DataGridColoredTextBoxColumn cs3 = new DataGridColoredTextBoxColumn();
                cs3.HeaderText = "Nombre";
                cs3.MappingName = "Nombre";
                cs3.NullText = "";
                cs3.Width = AnchoCol3;
                DataGridTextBoxColumn TextCol3 = (DataGridTextBoxColumn)cs3;
                TextCol3.TextBox.ContextMenu = this.cntMnuDataGrid;
                TextCol3.TextBox.DoubleClick += new EventHandler(TextBoxDoubleClickHandler);

                ts.GridColumnStyles.Add(cs3);



                ts.RowHeadersVisible = VerFila;
                ts.ColumnHeadersVisible = VerCabecera;
                ts.RowHeaderWidth = 17;
                ts.HeaderBackColor = Utiles.ColorFondoPanel;

                dg.TableStyles.Clear();
                dg.TableStyles.Add(ts);
                dg.RowHeadersVisible = VerFila;
                dg.RowHeaderWidth = 17;
                dg.ColumnHeadersVisible = VerCabecera;
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }

        #endregion

        #region TextBoxDoubleClickHandler
        private void TextBoxDoubleClickHandler(object sender, EventArgs e)
        {
            AccesoReportVisita(this.dgActivo, this.diaActivo);
        }
        #endregion

        #region Inicializar_FormatoDataGrid
        private void Inicializar_FormatoDataGrid(Panel pn, bool VerCabecera, bool VerFila, int AnchoCol0, int AnchoCol1, int AnchoCol2, int AnchoCol3)
        {
            try
            {
                string tipo = null;
                foreach (Control c in pn.Controls)
                {
                    tipo = c.GetType().ToString();
                    switch (tipo)
                    {
                        case "GESTCRM.MiDataGrid":
                            GESTCRM.MiDataGrid dg = (GESTCRM.MiDataGrid)c;
                            FormatoDataGrid(dg, VerCabecera, VerFila, AnchoCol0, AnchoCol1, AnchoCol2, AnchoCol3);
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }
        #endregion


        #region cbDelegado_SelectedIndexChanged
        private void cbDelegado_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                int iIdDelegado = int.Parse(this.cbDelegado.SelectedValue.ToString());
                if (this.IdDelegado != iIdDelegado)
                {
                    Pregunta_GuardarCambiosAgendaObserv();

                    this.IdDelegado = int.Parse(this.cbDelegado.SelectedValue.ToString());
                    this.pnDiario.Visible = false;
                    this.pnSemana.Visible = false;
                    this.pnMensual.Visible = false;
                }
                if (this.Var_TipoAcceso == "M")
                {
                    if (this.IdDelegado != GESTCRM.Clases.Configuracion.iIdDelegado) Activar_AgendaObserv(false);
                    else Activar_AgendaObserv(true);
                }
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }
        #endregion

        #region dtpCalendario_ValueChanged
        private void dtpCalendario_ValueChanged(object sender, System.EventArgs e)
        {
            try
            {
                this.dFecha = this.dtpCalendario.Value.Date;
                Pregunta_GuardarCambiosAgendaObserv();
                if (this.Var_CambioFecha == 1)
                {
                    Cargar_Pantalla();
                }

            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }
        #endregion


        #region Borrar_dtDias
        private void Borrar_dtDias()
        {
            try
            {
                if (dtDias.Rows.Count > 0)
                {
                    for (int i = dtDias.Rows.Count - 1; i >= 0; i--)
                    {
                        dtDias.Rows.RemoveAt(i);
                    }
                }
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }
        #endregion

        #region Cargar_Pantalla
        private void Cargar_Pantalla()
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                if (this.pnSemana.Visible == true)
                {
                    Cargar_Semana();
                }
                if (this.pnMensual.Visible == true)
                {
                    Cargar_Mes();
                }
                if (this.pnDiario.Visible == true)
                {
                    Cargar_Dia();
                }               
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }

            Cursor.Current = Cursors.Default;
        }
        #endregion


        #region texto_lblSemana
        private string texto_lblSemana(DateTime fecha, int dia)
        {
            string resultado = "";
            switch (dia)
            {
                case 1:
                    resultado = "Lunes " + fecha.Day.ToString() + "/" + fecha.Month.ToString() + "/" + fecha.Year.ToString();
                    break;
                case 2:
                    resultado = "Martes " + fecha.Day.ToString() + "/" + fecha.Month.ToString() + "/" + fecha.Year.ToString();
                    break;
                case 3:
                    resultado = "Miércoles " + fecha.Day.ToString() + "/" + fecha.Month.ToString() + "/" + fecha.Year.ToString();
                    break;
                case 4:
                    resultado = "Jueves " + fecha.Day.ToString() + "/" + fecha.Month.ToString() + "/" + fecha.Year.ToString();
                    break;
                case 5:
                    resultado = "Viernes " + fecha.Day.ToString() + "/" + fecha.Month.ToString() + "/" + fecha.Year.ToString();
                    break;
                case 6:
                    resultado = "Sábado " + fecha.Day.ToString() + "/" + fecha.Month.ToString() + "/" + fecha.Year.ToString();
                    break;
                case 7:
                    resultado = "Domingo " + fecha.Day.ToString() + "/" + fecha.Month.ToString() + "/" + fecha.Year.ToString();
                    break;
            }
            return resultado;
        }
        #endregion

        #region Convertir_Fecha
        private string Convertir_Fecha(DateTime fecha)
        {
            string resultado = fecha.Day.ToString() + "/" + fecha.Month.ToString() + "/" + fecha.Year.ToString();
            return resultado;
        }
        #endregion

        #region Convertir_Mes
        private string Convertir_Mes(DateTime fecha)
        {
            try
            {
                switch (fecha.Month)
                {
                    case 1: return ("ENERO");
                    case 2: return ("FEBRERO");
                    case 3: return ("MARZO");
                    case 4: return ("ABRIL");
                    case 5: return ("MAYO");
                    case 6: return ("JUNIO");
                    case 7: return ("JULIO");
                    case 8: return ("AGOSTO");
                    case 9: return ("SETIEMBRE");
                    case 10: return ("OCTUBRE");
                    case 11: return ("NOVIEMBRE");
                    case 12: return ("DICIEMBRE");
                    default: break;
                }
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }

            return "";
        }
        #endregion


        #region btMas_Click
        private void btMas_Click(object sender, System.EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            this.Var_CambioFecha = 0;

            try
            {
                if (this.pnDiario.Visible == true)
                {
                    this.dFecha = this.dFecha.AddDays(1);
                    this.dtpCalendario.Value = this.dFecha;
                    Cargar_Dia();
                }
                if (this.pnSemana.Visible == true)
                {
                    this.dFecha = this.dFecha.AddDays(7);
                    this.dtpCalendario.Value = this.dFecha;
                    Cargar_Semana();
                }
                if (this.pnMensual.Visible == true)
                {
                    this.dFecha = this.dFecha.AddMonths(1);
                    this.dtpCalendario.Value = this.dFecha;
                    Cargar_Mes();
                }
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }

            this.Var_CambioFecha = 1;

            Cursor.Current = Cursors.Default;

            //---- GSG (20/06/2016)
            pictureBoxArrastro.Location = new System.Drawing.Point(_K_LOC_X, _K_LOC_Y);
            pictureBoxArrastro.Visible = false;

        }
        #endregion

        #region btMenos_Click
        private void btMenos_Click(object sender, System.EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            this.Var_CambioFecha = 0;

            try
            {
                if (this.pnDiario.Visible == true)
                {
                    this.dFecha = this.dFecha.AddDays(-1);
                    this.dtpCalendario.Value = this.dFecha;
                    Cargar_Dia();
                }
                if (this.pnSemana.Visible == true)
                {
                    this.dFecha = this.dFecha.AddDays(-7);
                    this.dtpCalendario.Value = this.dFecha;
                    Cargar_Semana();
                }
                if (this.pnMensual.Visible == true)
                {
                    this.dFecha = this.dFecha.AddMonths(-1);
                    this.dtpCalendario.Value = this.dFecha;
                    Cargar_Mes();
                }
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }

            this.Var_CambioFecha = 1;

            Cursor.Current = Cursors.Default;

            //---- GSG (20/06/2016)
            pictureBoxArrastro.Location = new System.Drawing.Point(_K_LOC_X, _K_LOC_Y);
            pictureBoxArrastro.Visible = false;
        }
        #endregion

        #region btDiario_Click
        private void btDiario_Click(object sender, System.EventArgs e)
        {
            //---- GSG (20/06/2016)
            pictureBoxArrastro.Location = new System.Drawing.Point(_K_LOC_X, _K_LOC_Y); 
            pictureBoxArrastro.Visible = false;

            Ver_Diario();
        }
        #endregion

        #region btSemanal_Click
        private void btSemanal_Click(object sender, System.EventArgs e)
        {
            //---- GSG (20/06/2016)
            pictureBoxArrastro.Location = new System.Drawing.Point(_K_LOC_X, _K_LOC_Y);
            pictureBoxArrastro.Visible = false;

            if (this.pnDiario.Visible) Pregunta_GuardarCambiosAgendaObserv();
            Ver_Semana();
        }
        #endregion

        #region Ver_Semana
        private void Ver_Semana()
        {
            Cursor.Current = Cursors.WaitCursor;

            this.Var_CambioFecha = 0;

            try
            {
                this.pnSemana.Visible = true;
                this.pnMensual.Visible = false;
                this.pnDiario.Visible = false;
                //---- GSG (13/03/2019)
                //this.btDiario.Font = Utiles.fuenteNoBold;
                //this.btSemanal.Font = Utiles.fuenteBold;
                //this.btMensual.Font = Utiles.fuenteNoBold;
                this.btDiario.Font = Utiles.fuenteNoBoldBig;
                this.btSemanal.Font = Utiles.fuenteBoldBig;
                this.btMensual.Font = Utiles.fuenteNoBoldBig;

                Cargar_Semana();
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }

            this.Var_CambioFecha = 1;

            Cursor.Current = Cursors.Default;
        }
        #endregion

        #region btMensual_Click
        private void btMensual_Click(object sender, System.EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (this.pnDiario.Visible) Pregunta_GuardarCambiosAgendaObserv();
            this.Var_CambioFecha = 0;
            try
            {
                this.pnMensual.Visible = true;
                this.pnSemana.Visible = false;
                this.pnDiario.Visible = false;
                //---- GSG (13/03/2019)
                //this.btDiario.Font = Utiles.fuenteNoBold;
                //this.btSemanal.Font = Utiles.fuenteNoBold;
                //this.btMensual.Font = Utiles.fuenteBold;
                this.btDiario.Font = Utiles.fuenteNoBoldBig;
                this.btSemanal.Font = Utiles.fuenteNoBoldBig;
                this.btMensual.Font = Utiles.fuenteBoldBig;



                Cargar_Mes();
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
            this.Var_CambioFecha = 1;
            Cursor.Current = Cursors.Default;

            //---- GSG (20/06/2016)
            pictureBoxArrastro.Location = new System.Drawing.Point(_K_LOC_X, _K_LOC_Y);
            pictureBoxArrastro.Visible = false;
        }
        #endregion


        #region Ver_Diario
        private void Ver_Diario()
        {
            Cursor.Current = Cursors.WaitCursor;
            this.Var_CambioFecha = 0;

            try
            {
                this.dFecha = this.dtpCalendario.Value;
                this.pnDiario.Visible = true;
                this.pnSemana.Visible = false;
                this.pnMensual.Visible = false;
                //---- GSG (13/03/2019)
                //this.btDiario.Font = Utiles.fuenteBold;
                //this.btSemanal.Font = Utiles.fuenteNoBold;
                //this.btMensual.Font = Utiles.fuenteNoBold;
                this.btDiario.Font = Utiles.fuenteBoldBig;
                this.btSemanal.Font = Utiles.fuenteNoBoldBig;
                this.btMensual.Font = Utiles.fuenteNoBoldBig;
                


                Cargar_Dia();
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }

            this.Var_CambioFecha = 1;

            Cursor.Current = Cursors.Default;
        }
        #endregion

        #region Cargar_Dia
        private void Cargar_Dia()
        {
            try
            {
                //---- GSG (01/02/2017)
                Comun._lNomsPlanificats.Clear();

                int dia = -1;
                switch (dFecha.DayOfWeek)
                {
                    case DayOfWeek.Monday: dia = 1; break;
                    case DayOfWeek.Tuesday: dia = 2; break;
                    case DayOfWeek.Wednesday: dia = 3; break;
                    case DayOfWeek.Thursday: dia = 4; break;
                    case DayOfWeek.Friday: dia = 5; break;
                    case DayOfWeek.Saturday: dia = 6; break;
                    case DayOfWeek.Sunday: dia = 7; break;
                    default: break;
                }
                this.lblDiario.Text = texto_lblSemana(this.dFecha, dia);
                Borrar_dtDias();
                this.dsReports1.ListaRepActividad_Cab.Rows.Clear();
                Cargar_dgDia(this.dgDiario, dFecha, dia);
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }
        #endregion

        #region Cargar_dgDia
        private void Cargar_dgDia(MiDataGrid dgDia, DateTime dDia, int NumDia)
        {
            try
            {
                dgDia.Visible = true;
                dgDia.ReadOnly = false;

                this.sqldaListaRepActividad_Cab.SelectCommand.Parameters["@iIdDelegado"].Value = this.IdDelegado;
                this.sqldaListaRepActividad_Cab.SelectCommand.Parameters["@dFechaIni"].Value = dDia;
                this.sqldaListaRepActividad_Cab.SelectCommand.Parameters["@dFechaFin"].Value = dDia;
                this.sqldaListaRepActividad_Cab.Fill(this.dsReports1);

                DataTable dtVisitas = new DataTable();
                dtVisitas.Columns.Add("iIdReport");
                dtVisitas.Columns.Add("Tipo");
                dtVisitas.Columns.Add("ProxObj");
                dtVisitas.Columns.Add("Horario");
                dtVisitas.Columns.Add("Nombre");
                dtVisitas.Columns.Add("bPlanificacion");
                dtVisitas.Columns.Add("iIdCentro");
                dtVisitas.Columns.Add("iIdCliente");
                dtVisitas.Columns.Add("Orden");
                dtVisitas.Columns.Add("tObservaciones");
                dtVisitas.Columns.Add("dFecha");


                int NumFilas = 0;

                if (this.dsReports1.ListaRepActividad_Cab.Rows.Count > 0)
                {
                    for (int i = 0; i < this.dsReports1.ListaRepActividad_Cab.Rows.Count; i++)
                    {
                        if (DateTime.Parse(this.dsReports1.ListaRepActividad_Cab.Rows[i]["dFecha"].ToString()) == dDia &&
                            int.Parse(this.dsReports1.ListaRepActividad_Cab.Rows[i]["iIdDelegado"].ToString()) == this.IdDelegado)
                        {
                            DataRow fila = dtVisitas.NewRow();
                            fila["iIdReport"] = this.dsReports1.ListaRepActividad_Cab[i]["iIdReport"];
                            fila["ProxObj"] = this.dsReports1.ListaRepActividad_Cab[i]["ProxObj"];
                            fila["Nombre"] = this.dsReports1.ListaRepActividad_Cab[i]["sNombre"];
                            fila["bPlanificacion"] = this.dsReports1.ListaRepActividad_Cab[i]["bPlanificacion"].ToString();
                            fila["iIdCentro"] = this.dsReports1.ListaRepActividad_Cab[i]["iIdCentro"].ToString();
                            fila["iIdCliente"] = this.dsReports1.ListaRepActividad_Cab[i]["iIdCliente"].ToString();
                            fila["Orden"] = this.dsReports1.ListaRepActividad_Cab[i]["Orden"].ToString();
                            fila["tObservaciones"] = this.dsReports1.ListaRepActividad_Cab[i]["tObservaciones"].ToString();
                            fila["dFecha"] = this.dsReports1.ListaRepActividad_Cab[i]["dFecha"].ToString();
                            if (fila["Orden"].ToString() != "2")
                            {
                                //								fila["Tipo"] = this.dsReports1.ListaRepActividad_Cab[i]["Planif"];
                                fila["Tipo"] = this.dsReports1.ListaRepActividad_Cab[i]["descTipoCliente"];
                                //---- GSG (22/01/2015)
                                //fila["Horario"] = this.dsReports1.ListaRepActividad_Cab[i]["tHorario"];
                                fila["Horario"] = "  ";
                            }
                            dtVisitas.Rows.Add(fila);

                            DataRow filaSemana = dtDias.NewRow();
                            filaSemana["NumDia"] = 1;
                            filaSemana["FechaDia"] = dDia;
                            filaSemana["FilaDg"] = NumFilas;
                            filaSemana["iIdReport"] = this.dsReports1.ListaRepActividad_Cab[i]["iIdReport"];
                            filaSemana["bEnviadoCEN"] = this.dsReports1.ListaRepActividad_Cab[i]["bEnviadoCEN"];

                            dtDias.Rows.Add(filaSemana);
                            NumFilas = NumFilas + 1;

                            //---- GSG (13/03/2019)
                            
                            // Buscar los que están en la semana                            
                            if (fila["bPlanificacion"].ToString() == "1")
                            {
                                int cli = int.Parse(this.dsReports1.ListaRepActividad_Cab[i]["iIdCliente"].ToString());
                                DateTime fec = DateTime.Parse(this.dsReports1.ListaRepActividad_Cab[i]["dFecha"].ToString());
                                DateTime fIni = fec;
                                DateTime fFin = fec;
                                if (fec.DayOfWeek == DayOfWeek.Sunday)
                                {
                                    fIni = fec.AddDays(1);
                                    fFin = fec.AddDays(5);
                                }
                                else if (fec.DayOfWeek == DayOfWeek.Saturday)
                                {
                                    fIni = fec.AddDays(2);
                                    fFin = fec.AddDays(6);
                                }


                                if (GetVisitaDePlanif(cli, fIni, fFin) > 0) // ha encontrado una visita que corresponde a la planificación
                                {
                                    Comun._lNomsPlanificats.Add(fila["Nombre"].ToString());
                                }
                            }
                            


                        }
                    }
                }
                if (dtVisitas.Rows.Count <= 0)
                {
                    DataRow fila = dtVisitas.NewRow();
                    fila["Tipo"] = "  "; fila["Horario"] = "  "; fila["Nombre"] = "  ";
                    dtVisitas.Rows.Add(fila);
                }


                dgDia.DataMember = dtVisitas.DefaultView.Table.TableName;
                dgDia.DataSource = dtVisitas.DefaultView;


                dgDia.ReadOnly = true;

                Cargar_Datos();
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }
        #endregion

        #region dgDiario_MouseUp
        private void dgDiario_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            try
            {
                this.dgActivo = dgDiario;
                this.diaActivo = 1;
                Cargar_Datos();
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }
        #endregion

        #region dgDiario_CurrentCellChanged
        private void dgDiario_CurrentCellChanged(object sender, System.EventArgs e)
        {
            try
            {
                this.dgActivo = dgDiario;
                this.diaActivo = 1;
                Cargar_Datos();
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }
        #endregion

        #region Cargar_Datos()
        private void Cargar_Datos()
        {
            try
            {
                Cargar_AgendaObserv();

                int fila = this.dgDiario.CurrentRowIndex;
                if (fila > -1)
                {
                    CurrencyManager cm = (CurrencyManager)this.BindingContext[this.dgDiario.DataSource, this.dgDiario.DataMember]; ;
                    DataView dv = (DataView)cm.List;
                    DataTable dt = dv.Table;

                    if (dt.Rows[fila]["bPlanificacion"].ToString() == "1")
                    {
                        this.pnProxObj.Visible = true;
                        this.pnObservaciones.Visible = false;

                        int Centro = -1;
                        try { Centro = Int32.Parse(dt.Rows[fila]["iIdCentro"].ToString()); }
                        catch { Centro = -1; }

                        int Cliente = -1;
                        if (Centro == -1) Cliente = Int32.Parse(dt.Rows[fila]["iIdCliente"].ToString());

                        Cargar_dgProxObj(Centro, Cliente);

                    }
                    else if (dt.Rows[fila]["bPlanificacion"].ToString() == "0")
                    {
                        this.pnProxObj.Visible = false;
                        this.pnObservaciones.Visible = true;

                        this.txtObservRep.Text = dt.Rows[fila]["tObservaciones"].ToString();

                        int Report = -1;
                        try { Report = Int32.Parse(dt.Rows[fila]["iIdReport"].ToString()); }
                        catch { Report = -1; }

                        Cargar_dgObservaciones(Report, -1);
                    }
                    else
                    {
                        this.pnProxObj.Visible = false;
                        this.pnObservaciones.Visible = false;
                    }
                }
                else
                {
                    this.pnProxObj.Visible = false;
                    this.pnObservaciones.Visible = false;
                }
            }
            catch { }
        }
        #endregion

        #region Cargar_AgendaObserv
        private void Cargar_AgendaObserv()
        {
            int iIdDelegado = -1;
            try { iIdDelegado = Int32.Parse(this.cbDelegado.SelectedValue.ToString()); }
            catch { }
            DateTime Fecha = DateTime.Parse(this.dtpCalendario.Value.ToString("dd/MM/yyyy"));

            this.iIdDelegado_BuscarAgenda = iIdDelegado;
            this.Fecha_BuscarAgenda = Fecha;

            this.dsReports1.ListaAgendaObserv.Rows.Clear();

            if (iIdDelegado > -1)
            {
                this.sqldaListaAgendaObserv.SelectCommand.Parameters["@iIdDelegado"].Value = iIdDelegado;
                this.sqldaListaAgendaObserv.SelectCommand.Parameters["@dFecha"].Value = Fecha;

                this.sqldaListaAgendaObserv.Fill(this.dsReports1);
            }
            if (this.dsReports1.ListaAgendaObserv.Rows.Count > 0)
            {
                this.txtDiaObserv.Text = this.dsReports1.ListaAgendaObserv.Rows[0]["tObservaciones"].ToString();
            }
            else
            {
                this.txtDiaObserv.Text = null;
            }
        }
        #endregion

        #region Cargar_dgProxObj
        private void Cargar_dgProxObj(int iIdCentro, int iIdCliente)
        {
            try
            {
                this.dsReports1.ListaRepActividadCli_ProxObj.Rows.Clear();

                this.sqldaListaRepActividad_ProxObj.SelectCommand.Parameters["@iIdCentro"].Value = iIdCentro;
                this.sqldaListaRepActividad_ProxObj.SelectCommand.Parameters["@iIdCliente"].Value = iIdCliente;

                this.sqldaListaRepActividad_ProxObj.Fill(this.dsReports1);

                this.lblTotProxObj.Text = this.dsReports1.ListaRepActividadCli_ProxObj.Rows.Count.ToString();
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }
        #endregion

        #region Cargar_dgObservaciones
        private void Cargar_dgObservaciones(int iIdReport, int iIdCliente)
        {
            try
            {
                this.dsReports1.ListaRepActividad_Observaciones.Rows.Clear();

                this.sqldaListaRepActividad_Obsevaciones.SelectCommand.Parameters["@iIdReport"].Value = iIdReport;
                this.sqldaListaRepActividad_Obsevaciones.SelectCommand.Parameters["@iIdCliente"].Value = iIdCliente;

                this.sqldaListaRepActividad_Obsevaciones.Fill(this.dsReports1);

                this.lblTotObserv.Text = this.dsReports1.ListaRepActividad_Observaciones.Rows.Count.ToString();
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }
        #endregion

        #region btGuardarObserv_Click
        private void btGuardarObserv_Click(object sender, System.EventArgs e)
        {
            if (Grabar_AgendaObserv(0))
            {
                Mensajes.ShowInformation(3004);
            }
        }
        #endregion

        #region Grabar_AgendaObserv
        private bool Grabar_AgendaObserv(int Cambio)
        {
            bool resultado = true;
            string sMensj = "";

            int iIdDelegado = -1;
            DateTime Fecha;

            if (Cambio == 0)
            {
                try { iIdDelegado = Int32.Parse(this.cbDelegado.SelectedValue.ToString()); }
                catch { }
                string h = this.dtpCalendario.Value.ToString("dd/MM/yyyy");
                Fecha = DateTime.Parse(this.dtpCalendario.Value.ToString("dd/MM/yyyy"));
            }
            else
            {
                iIdDelegado = this.iIdDelegado_BuscarAgenda;
                Fecha = this.Fecha_BuscarAgenda;
            }

            if (iIdDelegado > -1)
            {
                Cursor.Current = Cursors.WaitCursor;

                //---- GSG (10/09/2014)
                //sqlConn.Open();
                if (sqlConn.State == ConnectionState.Closed)
                    sqlConn.Open();


                this.sqlTran = this.sqlConn.BeginTransaction();

                this.sqlCmdSetAgendaObserv.Transaction = this.sqlTran;

                try
                {
                    //Borrar Observacion existente
                    this.sqlCmdSetAgendaObserv.Parameters["@Accion"].Value = 2;
                    this.sqlCmdSetAgendaObserv.Parameters["@iIdDelegado"].Value = iIdDelegado;
                    this.sqlCmdSetAgendaObserv.Parameters["@dFecha"].Value = Fecha;
                    this.sqlCmdSetAgendaObserv.ExecuteNonQuery();

                    //Insertar Observacion existente
                    this.sqlCmdSetAgendaObserv.Parameters["@Accion"].Value = 0;
                    this.sqlCmdSetAgendaObserv.Parameters["@iIdDelegado"].Value = iIdDelegado;
                    this.sqlCmdSetAgendaObserv.Parameters["@dFecha"].Value = Fecha;
                    this.sqlCmdSetAgendaObserv.Parameters["@tObservaciones"].Value = this.txtDiaObserv.Text.ToString();
                    this.sqlCmdSetAgendaObserv.ExecuteNonQuery();

                    this.sqlTran.Commit();

                    if (Cambio == 0) Cargar_AgendaObserv();


                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    sMensj = "Error al actualizar Agenda: ";
                    foreach (System.Data.SqlClient.SqlError Err in ex.Errors)
                    {
                        if (Err.Number != 3621)
                        {
                            sMensj += Err.Number.ToString() + " - " + Err.Message.ToString();
                        }
                    }

                    Mensajes.ShowError(sMensj);
                    this.sqlTran.Rollback();
                    resultado = false;
                }
                catch (Exception e)
                {
                    Mensajes.ShowError(e.Message);
                    this.sqlTran.Rollback();
                    resultado = false;
                }

                this.sqlConn.Close();

                Cursor.Current = Cursors.Default;
            }
            return resultado;
        }
        #endregion

        #region Pregunta_GuardarCambiosAgendaObserv
        private void Pregunta_GuardarCambiosAgendaObserv()
        {
            if (Hay_CambiosAgendaObserv())
            {
                DialogResult dr = Mensajes.ShowQuestion("Se han modificado las observaciones diarias. ¿Desea guardar los cambios?");
                if (dr == DialogResult.Yes)
                {
                    if (Grabar_AgendaObserv(1))
                    {
                        Mensajes.ShowInformation(3004);
                    }
                }
            }
        }
        #endregion

        #region Hay_CambiosAgendaObserv
        private bool Hay_CambiosAgendaObserv()
        {
            int longitud = this.txtDiaObserv.Text.ToString().Trim().Length;

            if (this.dsReports1.ListaAgendaObserv.Rows.Count == 0 && longitud != 0)
            {
                return true;
            }
            if (this.dsReports1.ListaAgendaObserv.Rows.Count != 0 && longitud == 0)
            {
                return true;
            }
            if (this.dsReports1.ListaAgendaObserv.Rows.Count != 0 && this.dsReports1.ListaAgendaObserv.Rows[0]["tObservaciones"].ToString() != this.txtDiaObserv.Text.ToString())
            {
                return true;
            }

            return false;
        }
        #endregion

        #region Activar_AgendaObserv
        private void Activar_AgendaObserv(bool Activar)
        {
            Utiles.Activar_Control(this.txtDiaObserv, Activar);
            Utiles.Activar_Control(this.btGuardarObserv, Activar);
        }
        #endregion




        #region Cargar_Semana
        private void Cargar_Semana()
        {
            try
            {
                //---- GSG (01/02/2017)
                Comun._lNomsPlanificats.Clear();

                DateTime dLunes = dFecha;
                DateTime dMartes = dFecha;
                DateTime dMiercoles = dFecha;
                DateTime dJueves = dFecha;
                DateTime dViernes = dFecha;
                DateTime dSabado = dFecha;
                DateTime dDomingo = dFecha;
                switch (dFecha.DayOfWeek)
                {
                    case DayOfWeek.Monday:
                        dLunes = dFecha;
                        dMartes = dFecha.AddDays(1);
                        dMiercoles = dFecha.AddDays(2);
                        dJueves = dFecha.AddDays(3);
                        dViernes = dFecha.AddDays(4);
                        //---- GSG (15/06/2016)
                        //dSabado = dFecha.AddDays(5);
                        //dDomingo = dFecha.AddDays(6);
                        dSabado = dFecha.AddDays(-2);
                        dDomingo = dFecha.AddDays(-1);
                        break;
                    case DayOfWeek.Tuesday:
                        dLunes = dFecha.AddDays(-1);
                        dMartes = dFecha;
                        dMiercoles = dFecha.AddDays(1);
                        dJueves = dFecha.AddDays(2);
                        dViernes = dFecha.AddDays(3);
                        //---- GSG (15/06/2016)
                        //dSabado = dFecha.AddDays(4);
                        //dDomingo = dFecha.AddDays(5);
                        dSabado = dFecha.AddDays(-3);
                        dDomingo = dFecha.AddDays(-2);
                        break;
                    case DayOfWeek.Wednesday:
                        dLunes = dFecha.AddDays(-2);
                        dMartes = dFecha.AddDays(-1);
                        dMiercoles = dFecha;
                        dJueves = dFecha.AddDays(1);
                        dViernes = dFecha.AddDays(2);
                        //---- GSG (15/06/2016)
                        //dSabado = dFecha.AddDays(3);
                        //dDomingo = dFecha.AddDays(4);
                        dSabado = dFecha.AddDays(-4);
                        dDomingo = dFecha.AddDays(-3);
                        break;
                    case DayOfWeek.Thursday:
                        dLunes = dFecha.AddDays(-3);
                        dMartes = dFecha.AddDays(-2);
                        dMiercoles = dFecha.AddDays(-1);
                        dJueves = dFecha;
                        dViernes = dFecha.AddDays(1);
                        //---- GSG (15/06/2016)
                        //dSabado = dFecha.AddDays(2);
                        //dDomingo = dFecha.AddDays(3);
                        dSabado = dFecha.AddDays(-5);
                        dDomingo = dFecha.AddDays(-4);
                        break;
                    case DayOfWeek.Friday:
                        dLunes = dFecha.AddDays(-4);
                        dMartes = dFecha.AddDays(-3);
                        dMiercoles = dFecha.AddDays(-2);
                        dJueves = dFecha.AddDays(-1);
                        dViernes = dFecha;
                        //---- GSG (15/06/2016)
                        //dSabado = dFecha.AddDays(1);
                        //dDomingo = dFecha.AddDays(2);
                        dSabado = dFecha.AddDays(-6);
                        dDomingo = dFecha.AddDays(-5);
                        break;
                    case DayOfWeek.Saturday:
                        //---- GSG (15/06/2016)
                        //dLunes = dFecha.AddDays(-5);
                        //dMartes = dFecha.AddDays(-4);
                        //dMiercoles = dFecha.AddDays(-3);
                        //dJueves = dFecha.AddDays(-2);
                        //dViernes = dFecha.AddDays(-1);
                        dLunes = dFecha.AddDays(2);
                        dMartes = dFecha.AddDays(3);
                        dMiercoles = dFecha.AddDays(4);
                        dJueves = dFecha.AddDays(5);
                        dViernes = dFecha.AddDays(6);
                        //----

                        dSabado = dFecha;
                        dDomingo = dFecha.AddDays(1);

                        break;
                    case DayOfWeek.Sunday:
                        //---- GSG (15/06/2016)
                        //                  dLunes = dFecha.AddDays(-6);
                        //dMartes = dFecha.AddDays(-5);
                        //dMiercoles = dFecha.AddDays(-4);
                        //dJueves = dFecha.AddDays(-3);
                        //dViernes = dFecha.AddDays(-2);
                        dLunes = dFecha.AddDays(1);
                        dMartes = dFecha.AddDays(2);
                        dMiercoles = dFecha.AddDays(3);
                        dJueves = dFecha.AddDays(4);
                        dViernes = dFecha.AddDays(5);
                        //-----

                        dSabado = dFecha.AddDays(-1);
                        dDomingo = dFecha;
                        break;
                    default: break;
                }
                this.lblSemana1.Text = texto_lblSemana(dLunes, 1);
                this.lblSemana2.Text = texto_lblSemana(dMartes, 2);
                this.lblSemana3.Text = texto_lblSemana(dMiercoles, 3);
                this.lblSemana4.Text = texto_lblSemana(dJueves, 4);
                this.lblSemana5.Text = texto_lblSemana(dViernes, 5);
                this.lblSemana6.Text = texto_lblSemana(dSabado, 6);
                this.lblSemana7.Text = texto_lblSemana(dDomingo, 7);
                Borrar_dtDias();

                this.dsReports1.ListaRepActividad_Cab.Rows.Clear();
                this.sqldaListaRepActividad_Cab.SelectCommand.Parameters["@iIdDelegado"].Value = this.IdDelegado;

                //---- GSG (15/06/2016)
                //this.sqldaListaRepActividad_Cab.SelectCommand.Parameters["@dFechaIni"].Value=dLunes;
                //this.sqldaListaRepActividad_Cab.SelectCommand.Parameters["@dFechaFin"].Value=dDomingo;
                this.sqldaListaRepActividad_Cab.SelectCommand.Parameters["@dFechaIni"].Value = dSabado;
                this.sqldaListaRepActividad_Cab.SelectCommand.Parameters["@dFechaFin"].Value = dViernes;

                this.sqldaListaRepActividad_Cab.Fill(this.dsReports1);

                Cargar_dgSemana(this.dgSemana1, dLunes, 1);
                Cargar_dgSemana(this.dgSemana2, dMartes, 2);
                Cargar_dgSemana(this.dgSemana3, dMiercoles, 3);
                Cargar_dgSemana(this.dgSemana4, dJueves, 4);
                Cargar_dgSemana(this.dgSemana5, dViernes, 5);
                Cargar_dgSemana(this.dgSemana6, dSabado, 6);
                Cargar_dgSemana(this.dgSemana7, dDomingo, 7);
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }
        #endregion

        #region Cargar_dgSemana
        private void Cargar_dgSemana(MiDataGrid dgSemana, DateTime dDia, int NumDia)
        {
            try
            {
                dgSemana.Visible = true;
                dgSemana.ReadOnly = false;

                DataTable dtVisitas = new DataTable();
                dtVisitas.Columns.Add("Tipo");
                dtVisitas.Columns.Add("ProxObj");
                dtVisitas.Columns.Add("Horario");
                dtVisitas.Columns.Add("Nombre");
                dtVisitas.Columns.Add("bPlanificacion");
                dtVisitas.Columns.Add("Orden");
              


                int NumFilas = 0;

                if (this.dsReports1.ListaRepActividad_Cab.Rows.Count > 0)
                {
                    for (int i = 0; i < this.dsReports1.ListaRepActividad_Cab.Rows.Count; i++)
                    {
                        if (DateTime.Parse(this.dsReports1.ListaRepActividad_Cab.Rows[i]["dFecha"].ToString()) == dDia &&
                            int.Parse(this.dsReports1.ListaRepActividad_Cab.Rows[i]["iIdDelegado"].ToString()) == this.IdDelegado)
                        {
                            DataRow fila = dtVisitas.NewRow();
                            //							fila["Tipo"] = this.dsReports1.ListaRepActividad_Cab[i]["Planif"].ToString();//.Substring(0,1);
                            fila["ProxObj"] = this.dsReports1.ListaRepActividad_Cab[i]["ProxObj"].ToString();
                            //							fila["Horario"] = this.dsReports1.ListaRepActividad_Cab[i]["tHorario"].ToString();//.Substring(0,1);
                            fila["Nombre"] = this.dsReports1.ListaRepActividad_Cab[i]["sNombre"];
                            fila["bPlanificacion"] = this.dsReports1.ListaRepActividad_Cab[i]["bPlanificacion"].ToString();
                            fila["Orden"] = this.dsReports1.ListaRepActividad_Cab[i]["Orden"].ToString();
                            if (fila["Orden"].ToString() != "2")
                            {
                                //								fila["Tipo"] = this.dsReports1.ListaRepActividad_Cab[i]["Planif"].ToString();//.Substring(0,1);
                                fila["Tipo"] = this.dsReports1.ListaRepActividad_Cab[i]["descTipoCliente"].ToString();//.Substring(0,1);
                                                                                                                      //---- GSG (22/01/2015)
                                                                                                                      //fila["Horario"] = this.dsReports1.ListaRepActividad_Cab[i]["tHorario"].ToString();//.Substring(0,1);
                                fila["Horario"] = "  ";
                            }


                            dtVisitas.Rows.Add(fila);

                            DataRow filaSemana = dtDias.NewRow();
                            
                            filaSemana["NumDia"] = NumDia;
                            filaSemana["FechaDia"] = dDia;
                            filaSemana["FilaDg"] = NumFilas;
                            filaSemana["iIdReport"] = this.dsReports1.ListaRepActividad_Cab[i]["iIdReport"];
                            filaSemana["bEnviadoCEN"] = this.dsReports1.ListaRepActividad_Cab[i]["bEnviadoCEN"];

                            dtDias.Rows.Add(filaSemana);
                            NumFilas = NumFilas + 1;

                            //---- GSG (01/02/2017)
                            if (fila["bPlanificacion"].ToString() == "0")
                                Comun._lNomsPlanificats.Add(fila["Nombre"].ToString());
                        }
                    }
                }
                if (dtVisitas.Rows.Count <= 0)
                {
                    DataRow fila = dtVisitas.NewRow();
                    fila["Tipo"] = "  "; fila["Horario"] = "  "; fila["Nombre"] = "  "; fila["bPlanificacion"] = "  ";
                    dtVisitas.Rows.Add(fila);
                }

                dgSemana.DataSource = dtVisitas.DefaultView;
                dgSemana.DataMember = dtVisitas.DefaultView.Table.TableName;

                dgSemana.ReadOnly = true;
                dgSemana.CaptionText = dDia.ToString();

                //
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }
        #endregion

        #region dgSemana_MouseUp
        private void dgSemana1_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            try
            {
                this.dgActivo = dgSemana1;
                this.diaActivo = 1;
                this.Var_CambioFecha = 0;
                this.dtpCalendario.Value = DateTime.Parse(this.dgActivo.CaptionText.ToString());
                this.Var_CambioFecha = 1;
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }


        private void dgSemana2_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            try
            {
                this.dgActivo = dgSemana2;
                this.diaActivo = 2;
                this.Var_CambioFecha = 0;
                this.dtpCalendario.Value = DateTime.Parse(this.dgActivo.CaptionText.ToString());
                this.Var_CambioFecha = 1;
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }

        private void dgSemana3_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            try
            {
                this.dgActivo = dgSemana3;
                this.diaActivo = 3;
                this.Var_CambioFecha = 0;
                this.dtpCalendario.Value = DateTime.Parse(this.dgActivo.CaptionText.ToString());
                this.Var_CambioFecha = 1;
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }

        private void dgSemana4_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            try
            {
                this.dgActivo = dgSemana4;
                this.diaActivo = 4;
                this.Var_CambioFecha = 0;
                this.dtpCalendario.Value = DateTime.Parse(this.dgActivo.CaptionText.ToString());
                this.Var_CambioFecha = 1;
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }

        private void dgSemana5_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            try
            {
                this.dgActivo = dgSemana5;
                this.diaActivo = 5;
                this.Var_CambioFecha = 0;
                this.dtpCalendario.Value = DateTime.Parse(this.dgActivo.CaptionText.ToString());
                this.Var_CambioFecha = 1;
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }

        private void dgSemana6_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            try
            {
                this.dgActivo = dgSemana6;
                this.diaActivo = 6;
                this.Var_CambioFecha = 0;
                this.dtpCalendario.Value = DateTime.Parse(this.dgActivo.CaptionText.ToString());
                this.Var_CambioFecha = 1;

                //---- GSG (15/06/2016)
                pictureBoxArrastro.Visible = true;
                DataGrid dg = (DataGrid)sender;

                System.Data.DataView dw = (System.Data.DataView)dgSemana6.DataSource;
                if (dw.Table.Rows[dg.CurrentRowIndex][4].ToString().Trim() != "") //---- GSG (22/08/2016)
                {
                    if (int.Parse(dw.Table.Rows[dg.CurrentRowIndex][4].ToString()) == 1)
                    {
                        origenes = pictureBoxArrastro;
                        PictureBox pic = (PictureBox)origenes;                        
                        pic.Location = new System.Drawing.Point(dg.GetCellBounds(dg.CurrentRowIndex, 1).X + 10, pnSemana.Top + lblSemana6.Height + dg.GetCellBounds(dg.CurrentRowIndex, 1).Y + 4);                        
                    }
                }
                
                
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }

        private void dgSemana7_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            try
            {
                this.dgActivo = dgSemana7;
                this.diaActivo = 7;
                this.Var_CambioFecha = 0;
                this.dtpCalendario.Value = DateTime.Parse(this.dgActivo.CaptionText.ToString());
                this.Var_CambioFecha = 1;

                //---- GSG (15/06/2016)
                pictureBoxArrastro.Visible = true;
                DataGrid dg = (DataGrid)sender;

                System.Data.DataView dw = (System.Data.DataView)dgSemana7.DataSource;
                if (dw.Table.Rows[dg.CurrentRowIndex][4].ToString().Trim() != "") //---- GSG (22/08/2016)
                {
                    if (int.Parse(dw.Table.Rows[dg.CurrentRowIndex][4].ToString()) == 1)
                    {
                        origenes = pictureBoxArrastro;
                        PictureBox pic = (PictureBox)origenes;
                        //---- GSG (13/03/2019)
                        //pic.Location = new System.Drawing.Point(dg.GetCellBounds(dg.CurrentRowIndex, 1).X + 10, pnSemana.Top + lblSemana7.Top + lblSemana7.Height + dg.GetCellBounds(dg.CurrentRowIndex, 1).Y + 1);
                        pic.Location = new System.Drawing.Point(dg.GetCellBounds(dg.CurrentRowIndex, 1).X + 10, pnSemana.Top + lblSemana7.Top + lblSemana7.Height + dg.GetCellBounds(dg.CurrentRowIndex, 1).Y + 6);
                    }
                }
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }
        #endregion

        #region lblSemana_DoubleClick
        private void lblSemana1_DoubleClick(object sender, System.EventArgs e)
        {
            try
            {
                string fecha = this.lblSemana1.Text.ToString();
                int pos = fecha.IndexOf(" ");
                fecha = fecha.Substring(pos + 1, fecha.Length - (pos + 1));
                lblMes_Click(DateTime.Parse(fecha));
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }

        private void lblSemana4_DoubleClick(object sender, System.EventArgs e)
        {
            try
            {
                string fecha = this.lblSemana4.Text.ToString();
                int pos = fecha.IndexOf(" ");
                fecha = fecha.Substring(pos + 1, fecha.Length - (pos + 1));
                lblMes_Click(DateTime.Parse(fecha));
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }

        private void lblSemana2_DoubleClick(object sender, System.EventArgs e)
        {
            try
            {
                string fecha = this.lblSemana2.Text.ToString();
                int pos = fecha.IndexOf(" ");
                fecha = fecha.Substring(pos + 1, fecha.Length - (pos + 1));
                lblMes_Click(DateTime.Parse(fecha));
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }

        private void lblSemana5_DoubleClick(object sender, System.EventArgs e)
        {
            try
            {
                string fecha = this.lblSemana5.Text.ToString();
                int pos = fecha.IndexOf(" ");
                fecha = fecha.Substring(pos + 1, fecha.Length - (pos + 1));
                lblMes_Click(DateTime.Parse(fecha));
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }

        private void lblSemana3_DoubleClick(object sender, System.EventArgs e)
        {
            try
            {
                string fecha = this.lblSemana3.Text.ToString();
                int pos = fecha.IndexOf(" ");
                fecha = fecha.Substring(pos + 1, fecha.Length - (pos + 1));
                lblMes_Click(DateTime.Parse(fecha));
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }

        private void lblSemana6_DoubleClick(object sender, System.EventArgs e)
        {
            try
            {
                string fecha = this.lblSemana6.Text.ToString();
                int pos = fecha.IndexOf(" ");
                fecha = fecha.Substring(pos + 1, fecha.Length - (pos + 1));
                lblMes_Click(DateTime.Parse(fecha));
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }

        private void lblSemana7_DoubleClick(object sender, System.EventArgs e)
        {
            try
            {
                string fecha = this.lblSemana7.Text.ToString();
                int pos = fecha.IndexOf(" ");
                fecha = fecha.Substring(pos + 1, fecha.Length - (pos + 1));
                lblMes_Click(DateTime.Parse(fecha));
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }
        #endregion



        #region Cargar_Mes
        private void Cargar_Mes()
        {
            try
            {
                //---- GSG (01/02/2017)
                Comun._lNomsPlanificats.Clear();


                DateTime[] Fechas = new DateTime[42];
                int Mes = dFecha.Month;
                int DiasMes = DateTime.DaysInMonth(dFecha.Year, dFecha.Month);
                DateTime dFechaIni = dFecha;
                while (dFechaIni.Day != 1)
                {
                    dFechaIni = dFechaIni.AddDays(-1);
                }

                DayOfWeek Dia = dFechaIni.DayOfWeek;
                int IndiceIni = 0;
                switch (dFechaIni.DayOfWeek)
                {
                    case DayOfWeek.Monday: IndiceIni = 0; break;
                    case DayOfWeek.Tuesday: IndiceIni = 1; break;
                    case DayOfWeek.Wednesday: IndiceIni = 2; break;
                    case DayOfWeek.Thursday: IndiceIni = 3; break;
                    case DayOfWeek.Friday: IndiceIni = 4; break;
                    case DayOfWeek.Saturday: IndiceIni = 5; break;
                    case DayOfWeek.Sunday: IndiceIni = 6; break;
                }


                for (int i = 0; i < IndiceIni; i++)
                {
                    Fechas[i] = dFechaIni.AddDays(-(IndiceIni - i));
                }
                for (int i = IndiceIni; i < 42; i++)
                {
                    Fechas[i] = dFechaIni.AddDays(i - IndiceIni);
                }

                Borrar_dtDias();

                this.dsReports1.ListaRepActividad_Cab.Rows.Clear();
                this.sqldaListaRepActividad_Cab.SelectCommand.Parameters["@iIdDelegado"].Value = this.IdDelegado;
                this.sqldaListaRepActividad_Cab.SelectCommand.Parameters["@dFechaIni"].Value = Fechas[0].Date;
                this.sqldaListaRepActividad_Cab.SelectCommand.Parameters["@dFechaFin"].Value = Fechas[40].Date;
                this.sqldaListaRepActividad_Cab.Fill(this.dsReports1);

                this.lblMes.Text = Convertir_Mes(dFechaIni);
                this.lblMes11.Text = Convertir_Fecha(Fechas[0].Date);
                //Cargar_dgMes(dgMes11, Fechas[0].Date, 1, dFechaIni.Month);
                Cargar_dgMes(dgMes11, Fechas[0].Date, 1, dFechaIni.Month, false);
                this.lblMes21.Text = Convertir_Fecha(Fechas[1].Date);
                //Cargar_dgMes(dgMes21, Fechas[1].Date, 2, dFechaIni.Month);
                Cargar_dgMes(dgMes21, Fechas[1].Date, 2, dFechaIni.Month, false);
                this.lblMes31.Text = Convertir_Fecha(Fechas[2].Date);
                //Cargar_dgMes(dgMes31, Fechas[2].Date, 3, dFechaIni.Month);
                Cargar_dgMes(dgMes31, Fechas[2].Date, 3, dFechaIni.Month, false);
                this.lblMes41.Text = Convertir_Fecha(Fechas[3].Date);
                //Cargar_dgMes(dgMes41, Fechas[3].Date, 4, dFechaIni.Month);
                Cargar_dgMes(dgMes41, Fechas[3].Date, 4, dFechaIni.Month, false);
                this.lblMes51.Text = Convertir_Fecha(Fechas[4].Date);
                //Cargar_dgMes(dgMes51, Fechas[4].Date, 5, dFechaIni.Month);
                Cargar_dgMes(dgMes51, Fechas[4].Date, 5, dFechaIni.Month, false);
                this.lblMes61.Text = Convertir_Fecha(Fechas[5].Date) + "  " + Convertir_Fecha(Fechas[6].Date);
                //Cargar_dgMes(dgMes61, Fechas[5].Date, 6, dFechaIni.Month);
                Cargar_dgMes(dgMes61, Fechas[5].Date, 6, dFechaIni.Month, true);
                this.lblMes12.Text = Convertir_Fecha(Fechas[7].Date);
                //Cargar_dgMes(dgMes12, Fechas[7].Date, 8, dFechaIni.Month);
                Cargar_dgMes(dgMes12, Fechas[7].Date, 8, dFechaIni.Month, false);
                this.lblMes22.Text = Convertir_Fecha(Fechas[8].Date);
                //Cargar_dgMes(dgMes22, Fechas[8].Date, 9, dFechaIni.Month);
                Cargar_dgMes(dgMes22, Fechas[8].Date, 9, dFechaIni.Month, false);
                this.lblMes32.Text = Convertir_Fecha(Fechas[9].Date);
                //Cargar_dgMes(dgMes32, Fechas[9].Date, 10, dFechaIni.Month);
                Cargar_dgMes(dgMes32, Fechas[9].Date, 10, dFechaIni.Month, false);
                this.lblMes42.Text = Convertir_Fecha(Fechas[10].Date);
                //Cargar_dgMes(dgMes42, Fechas[10].Date, 11, dFechaIni.Month);
                Cargar_dgMes(dgMes42, Fechas[10].Date, 11, dFechaIni.Month, false);
                this.lblMes52.Text = Convertir_Fecha(Fechas[11].Date);
                //Cargar_dgMes(dgMes52, Fechas[11].Date, 12, dFechaIni.Month);
                Cargar_dgMes(dgMes52, Fechas[11].Date, 12, dFechaIni.Month, false);
                this.lblMes62.Text = Convertir_Fecha(Fechas[12].Date) + "  " + Convertir_Fecha(Fechas[13].Date);
                //Cargar_dgMes(dgMes62, Fechas[12].Date, 13, dFechaIni.Month);
                Cargar_dgMes(dgMes62, Fechas[12].Date, 13, dFechaIni.Month, true);
                this.lblMes13.Text = Convertir_Fecha(Fechas[14].Date);
                //Cargar_dgMes(dgMes13, Fechas[14].Date, 15, dFechaIni.Month);
                Cargar_dgMes(dgMes13, Fechas[14].Date, 15, dFechaIni.Month, false);
                this.lblMes23.Text = Convertir_Fecha(Fechas[15].Date);
                //Cargar_dgMes(dgMes23, Fechas[15].Date, 16, dFechaIni.Month);
                Cargar_dgMes(dgMes23, Fechas[15].Date, 16, dFechaIni.Month, false);
                this.lblMes33.Text = Convertir_Fecha(Fechas[16].Date);
                //Cargar_dgMes(dgMes33, Fechas[16].Date, 17, dFechaIni.Month);
                Cargar_dgMes(dgMes33, Fechas[16].Date, 17, dFechaIni.Month, false);
                this.lblMes43.Text = Convertir_Fecha(Fechas[17].Date);
                //Cargar_dgMes(dgMes43, Fechas[17].Date, 18, dFechaIni.Month);
                Cargar_dgMes(dgMes43, Fechas[17].Date, 18, dFechaIni.Month, false);
                this.lblMes53.Text = Convertir_Fecha(Fechas[18].Date);
                //Cargar_dgMes(dgMes53, Fechas[18].Date, 19, dFechaIni.Month);
                Cargar_dgMes(dgMes53, Fechas[18].Date, 19, dFechaIni.Month, false);
                this.lblMes63.Text = Convertir_Fecha(Fechas[19].Date) + "  " + Convertir_Fecha(Fechas[20].Date);
                //Cargar_dgMes(dgMes63, Fechas[19].Date, 20, dFechaIni.Month);
                Cargar_dgMes(dgMes63, Fechas[19].Date, 20, dFechaIni.Month, true);
                this.lblMes14.Text = Convertir_Fecha(Fechas[21].Date);
                //Cargar_dgMes(dgMes14, Fechas[21].Date, 22, dFechaIni.Month);
                Cargar_dgMes(dgMes14, Fechas[21].Date, 22, dFechaIni.Month, false);
                this.lblMes24.Text = Convertir_Fecha(Fechas[22].Date);
                //Cargar_dgMes(dgMes24, Fechas[22].Date, 23, dFechaIni.Month);
                Cargar_dgMes(dgMes24, Fechas[22].Date, 23, dFechaIni.Month, false);
                this.lblMes34.Text = Convertir_Fecha(Fechas[23].Date);
                //Cargar_dgMes(dgMes34, Fechas[23].Date, 24, dFechaIni.Month);
                Cargar_dgMes(dgMes34, Fechas[23].Date, 24, dFechaIni.Month, false);
                this.lblMes44.Text = Convertir_Fecha(Fechas[24].Date);
                //Cargar_dgMes(dgMes44, Fechas[24].Date, 25, dFechaIni.Month);
                Cargar_dgMes(dgMes44, Fechas[24].Date, 25, dFechaIni.Month, false);
                this.lblMes54.Text = Convertir_Fecha(Fechas[25].Date);
                //Cargar_dgMes(dgMes54, Fechas[25].Date, 26, dFechaIni.Month);
                Cargar_dgMes(dgMes54, Fechas[25].Date, 26, dFechaIni.Month, false);
                this.lblMes64.Text = Convertir_Fecha(Fechas[26].Date) + "  " + Convertir_Fecha(Fechas[27].Date);
                //Cargar_dgMes(dgMes64, Fechas[26].Date, 27, dFechaIni.Month);
                Cargar_dgMes(dgMes64, Fechas[26].Date, 27, dFechaIni.Month, true);
                this.lblMes15.Text = Convertir_Fecha(Fechas[28].Date);
                //Cargar_dgMes(dgMes15, Fechas[28].Date, 29, dFechaIni.Month);
                Cargar_dgMes(dgMes15, Fechas[28].Date, 29, dFechaIni.Month, false);
                this.lblMes25.Text = Convertir_Fecha(Fechas[29].Date);
                //Cargar_dgMes(dgMes25, Fechas[29].Date, 30, dFechaIni.Month);
                Cargar_dgMes(dgMes25, Fechas[29].Date, 30, dFechaIni.Month, false);
                this.lblMes35.Text = Convertir_Fecha(Fechas[30].Date);
                //Cargar_dgMes(dgMes35, Fechas[30].Date, 31, dFechaIni.Month);
                Cargar_dgMes(dgMes35, Fechas[30].Date, 31, dFechaIni.Month, false);
                this.lblMes45.Text = Convertir_Fecha(Fechas[31].Date);
                //Cargar_dgMes(dgMes45, Fechas[31].Date, 32, dFechaIni.Month);
                Cargar_dgMes(dgMes45, Fechas[31].Date, 32, dFechaIni.Month, false);
                this.lblMes55.Text = Convertir_Fecha(Fechas[32].Date);
                //Cargar_dgMes(dgMes55, Fechas[32].Date, 33, dFechaIni.Month);
                Cargar_dgMes(dgMes55, Fechas[32].Date, 33, dFechaIni.Month, false);
                this.lblMes65.Text = Convertir_Fecha(Fechas[33].Date) + "  " + Convertir_Fecha(Fechas[34].Date);
                //Cargar_dgMes(dgMes65, Fechas[33].Date, 34, dFechaIni.Month);
                Cargar_dgMes(dgMes65, Fechas[33].Date, 34, dFechaIni.Month, true);
                this.lblMes16.Text = Convertir_Fecha(Fechas[35].Date);
                //Cargar_dgMes(dgMes16, Fechas[35].Date, 36, dFechaIni.Month);
                Cargar_dgMes(dgMes16, Fechas[35].Date, 36, dFechaIni.Month, false);
                this.lblMes26.Text = Convertir_Fecha(Fechas[36].Date);
                //Cargar_dgMes(dgMes26, Fechas[36].Date, 37, dFechaIni.Month);
                Cargar_dgMes(dgMes26, Fechas[36].Date, 37, dFechaIni.Month, false);
                this.lblMes36.Text = Convertir_Fecha(Fechas[37].Date);
                //Cargar_dgMes(dgMes36, Fechas[37].Date, 38, dFechaIni.Month);
                Cargar_dgMes(dgMes36, Fechas[37].Date, 38, dFechaIni.Month, false);
                this.lblMes46.Text = Convertir_Fecha(Fechas[38].Date);
                //Cargar_dgMes(dgMes46, Fechas[38].Date, 39, dFechaIni.Month);
                Cargar_dgMes(dgMes46, Fechas[38].Date, 39, dFechaIni.Month, false);
                this.lblMes56.Text = Convertir_Fecha(Fechas[39].Date);
                //Cargar_dgMes(dgMes56, Fechas[39].Date, 40, dFechaIni.Month);
                Cargar_dgMes(dgMes56, Fechas[39].Date, 40, dFechaIni.Month, false);
                this.lblMes66.Text = Convertir_Fecha(Fechas[40].Date) + "  " + Convertir_Fecha(Fechas[41].Date);
                //Cargar_dgMes(dgMes66, Fechas[40].Date, 41, dFechaIni.Month);
                Cargar_dgMes(dgMes66, Fechas[40].Date, 41, dFechaIni.Month, true);
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }
        #endregion

        #region Cargar_dgMes
        //---- GSG (31/01/2017)
        //private void Cargar_dgMes(MiDataGrid dgMes, DateTime dDia, int NumDia, int Mes)
        private void Cargar_dgMes(MiDataGrid dgMes, DateTime dDia, int NumDia, int Mes, bool finde)
        {
            try
            {
                dgMes.Enabled = true;
                dgMes.Visible = true;
                dgMes.ReadOnly = false;

                DataTable dtVisitas = new DataTable();
                dtVisitas.Columns.Add("Tipo");
                dtVisitas.Columns.Add("ProxObj");
                dtVisitas.Columns.Add("Horario");
                dtVisitas.Columns.Add("Nombre");
                dtVisitas.Columns.Add("bPlanificacion");
                dtVisitas.Columns.Add("Orden");

                int NumFilas = 0;

                if (this.dsReports1.ListaRepActividad_Cab.Rows.Count > 0)
                {
                    for (int i = 0; i < this.dsReports1.ListaRepActividad_Cab.Rows.Count; i++)
                    {
                        DateTime domingo = DateTime.Today;
                        if (finde)
                            domingo = dDia.AddDays(1);

                        if (int.Parse(this.dsReports1.ListaRepActividad_Cab.Rows[i]["iIdDelegado"].ToString()) == this.IdDelegado &&
                            ((finde && (DateTime.Parse(this.dsReports1.ListaRepActividad_Cab.Rows[i]["dFecha"].ToString()) == dDia || DateTime.Parse(this.dsReports1.ListaRepActividad_Cab.Rows[i]["dFecha"].ToString()) == domingo)) ||
                             (!finde && (DateTime.Parse(this.dsReports1.ListaRepActividad_Cab.Rows[i]["dFecha"].ToString()) == dDia))))
                        //if (DateTime.Parse(this.dsReports1.ListaRepActividad_Cab.Rows[i]["dFecha"].ToString()) == dDia &&
                        //int.Parse(this.dsReports1.ListaRepActividad_Cab.Rows[i]["iIdDelegado"].ToString()) == this.IdDelegado)
                        {
                            DataRow fila = dtVisitas.NewRow();
                            //							fila["Tipo"] = this.dsReports1.ListaRepActividad_Cab[i]["Planif"].ToString().Substring(0,1);
                            fila["ProxObj"] = this.dsReports1.ListaRepActividad_Cab[i]["ProxObj"].ToString();
                            //							fila["Horario"] = this.dsReports1.ListaRepActividad_Cab[i]["tHorario"].ToString().Substring(0,1);
                            fila["Nombre"] = this.dsReports1.ListaRepActividad_Cab[i]["sNombre"];
                            fila["bPlanificacion"] = this.dsReports1.ListaRepActividad_Cab[i]["bPlanificacion"].ToString();
                            fila["Orden"] = this.dsReports1.ListaRepActividad_Cab[i]["Orden"].ToString();
                            if (fila["Orden"].ToString() != "2")
                            {
                                //								fila["Tipo"] = this.dsReports1.ListaRepActividad_Cab[i]["Planif"].ToString().Substring(0,1);
                                fila["Tipo"] = this.dsReports1.ListaRepActividad_Cab[i]["descTipoCliente"].ToString().Substring(0, 1);
                                //---- GSG (22/01/2015)
                                //fila["Horario"] = this.dsReports1.ListaRepActividad_Cab[i]["tHorario"].ToString().Substring(0,1);
                                fila["Horario"] = "  ";
                            }
                            dtVisitas.Rows.Add(fila);

                            DataRow filaMes = dtDias.NewRow();
                            filaMes["NumDia"] = NumDia;
                            filaMes["FechaDia"] = dDia;
                            filaMes["FilaDg"] = NumFilas;
                            filaMes["iIdReport"] = this.dsReports1.ListaRepActividad_Cab[i]["iIdReport"];
                            filaMes["bEnviadoCEN"] = this.dsReports1.ListaRepActividad_Cab[i]["bEnviadoCEN"];
                            dtDias.Rows.Add(filaMes);
                            NumFilas = NumFilas + 1;


                            //---- GSG (13/03/2019)
                            //---- GSG (01/02/2017)
                            //if (fila["bPlanificacion"].ToString() == "0")
                            //    Comun._lNomsPlanificats.Add(fila["Nombre"].ToString());

                            // Buscar los que están en la semana                            
                            if (fila["bPlanificacion"].ToString() == "1")
                            {
                                int cli = int.Parse(this.dsReports1.ListaRepActividad_Cab[i]["iIdCliente"].ToString());
                                DateTime fec = DateTime.Parse(this.dsReports1.ListaRepActividad_Cab[i]["dFecha"].ToString());
                                DateTime fIni = fec;
                                DateTime fFin = fec;
                                if (fec.DayOfWeek == DayOfWeek.Sunday)
                                {
                                    fIni = fec.AddDays(1);
                                    fFin = fec.AddDays(5);
                                }
                                else if (fec.DayOfWeek == DayOfWeek.Saturday)
                                {
                                    fIni = fec.AddDays(2);
                                    fFin = fec.AddDays(6);
                                }


                                if (GetVisitaDePlanif(cli, fIni, fFin) > 0) // ha encontrado una visita que corresponde a la planificación
                                {
                                    Comun._lNomsPlanificats.Add(fila["Nombre"].ToString());
                                }
                            }
                        }
                    }
                }
                if (dtVisitas.Rows.Count <= 0)
                {
                    DataRow fila = dtVisitas.NewRow();
                    fila["Tipo"] = "  "; fila["Horario"] = "  "; fila["Nombre"] = "  ";
                    dtVisitas.Rows.Add(fila);
                }

                dgMes.DataSource = dtVisitas.DefaultView;
                dgMes.DataMember = dtVisitas.DefaultView.Table.TableName;

                if (dFecha.Month != dDia.Month)
                {
                    dgMes.BackgroundColor = Utiles.ColorFondoPanel;
                    dgMes.TableStyles[0].BackColor = Utiles.ColorFondoPanel;
                    dgMes.TableStyles[0].AlternatingBackColor = Utiles.ColorFondoPanel;
                }
                else
                {
                    dgMes.BackgroundColor = Color.White;
                    dgMes.TableStyles[0].BackColor = Color.White;
                    dgMes.TableStyles[0].AlternatingBackColor = Color.White;
                }

                dgMes.ReadOnly = true;
                dgMes.CaptionText = dDia.ToString();
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }
        #endregion

        #region dgMes_MouseUp
        private void dgMes_MouseUp(MiDataGrid dgMes, int Dia)
        {
            try
            {
                this.dgActivo = dgMes;
                this.diaActivo = Dia;
                DateTime fecha = DateTime.Parse(this.dgActivo.CaptionText.ToString());
                if (fecha.Month == this.dtpCalendario.Value.Month)
                {
                    this.Var_CambioFecha = 0;
                    this.dtpCalendario.Value = DateTime.Parse(this.dgActivo.CaptionText.ToString());
                    this.Var_CambioFecha = 1;
                }
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }

        }

        private void dgMes11_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            dgMes_MouseUp(dgMes11, 1);
        }

        private void dgMes21_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            dgMes_MouseUp(dgMes21, 2);
        }

        private void dgMes31_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            dgMes_MouseUp(dgMes31, 3);
        }

        private void dgMes41_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            dgMes_MouseUp(dgMes41, 4);
        }

        private void dgMes51_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            dgMes_MouseUp(dgMes51, 5);
        }

        private void dgMes61_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            dgMes_MouseUp(dgMes61, 6);
        }

        private void dgMes12_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            dgMes_MouseUp(dgMes12, 8);
        }

        private void dgMes22_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            dgMes_MouseUp(dgMes22, 9);
        }

        private void dgMes32_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            dgMes_MouseUp(dgMes32, 10);
        }

        private void dgMes42_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            dgMes_MouseUp(dgMes42, 11);
        }

        private void dgMes52_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            dgMes_MouseUp(dgMes52, 12);
        }

        private void dgMes62_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            dgMes_MouseUp(dgMes62, 13);
        }

        private void dgMes13_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            dgMes_MouseUp(dgMes13, 15);
        }

        private void dgMes23_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            dgMes_MouseUp(dgMes23, 16);
        }

        private void dgMes33_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            dgMes_MouseUp(dgMes33, 17);
        }

        private void dgMes43_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            dgMes_MouseUp(dgMes43, 18);
        }

        private void dgMes53_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            dgMes_MouseUp(dgMes53, 19);
        }

        private void dgMes63_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            dgMes_MouseUp(dgMes63, 20);
        }

        private void dgMes14_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            dgMes_MouseUp(dgMes14, 22);
        }

        private void dgMes24_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            dgMes_MouseUp(dgMes24, 23);
        }

        private void dgMes34_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            dgMes_MouseUp(dgMes34, 24);
        }

        private void dgMes44_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            dgMes_MouseUp(dgMes44, 25);
        }

        private void dgMes54_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            dgMes_MouseUp(dgMes54, 26);
        }

        private void dgMes64_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            dgMes_MouseUp(dgMes64, 27);
        }

        private void dgMes15_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            dgMes_MouseUp(dgMes15, 29);
        }

        private void dgMes25_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            dgMes_MouseUp(dgMes25, 30);
        }

        private void dgMes35_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            dgMes_MouseUp(dgMes35, 31);
        }

        private void dgMes45_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            dgMes_MouseUp(dgMes45, 32);
        }

        private void dgMes55_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            dgMes_MouseUp(dgMes55, 33);
        }

        private void dgMes65_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            dgMes_MouseUp(dgMes65, 34);
        }

        private void dgMes16_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            dgMes_MouseUp(dgMes16, 36);
        }

        private void dgMes26_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            dgMes_MouseUp(dgMes26, 37);
        }

        private void dgMes36_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            dgMes_MouseUp(dgMes36, 38);
        }

        private void dgMes46_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            dgMes_MouseUp(dgMes46, 39);
        }

        private void dgMes56_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            dgMes_MouseUp(dgMes56, 40);
        }

        private void dgMes66_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            dgMes_MouseUp(dgMes66, 41);
        }
        #endregion

        #region dgMes_MouseMouve
        private void dgMes_ToolTip(MiDataGrid dg, int cx, int cy)
        {
            try
            {
                System.Windows.Forms.DataGrid.HitTestInfo myHitTest;
                myHitTest = dg.HitTest(cx, cy);
                int columna = myHitTest.Column;
                int fila = myHitTest.Row;

                if (fila > -1 && columna == 3 && dg[fila, columna].ToString().Replace(" ", "").Length > 0)
                {
                    this.lblPnMes.Visible = true;
                    int y = dg.Location.Y + cy;
                    int x = dg.Location.X + dg.TableStyles[0].GridColumnStyles[0].Width + dg.TableStyles[0].GridColumnStyles[2].Width;
                    System.Drawing.Point p = new Point(x + 10, y + 15);
                    this.lblPnMes.Location = p;
                    this.lblPnMes.Text = dg[fila, 3].ToString();
                    this.lblPnMes.AutoSize = true;
                }
                else
                {
                    this.lblPnMes.Visible = false;
                }
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }

        private void dgMes11_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            dgMes_ToolTip(dgMes11, e.X, e.Y);
        }

        private void dgMes21_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            dgMes_ToolTip(dgMes21, e.X, e.Y);
        }

        private void dgMes31_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            dgMes_ToolTip(dgMes31, e.X, e.Y);
        }

        private void dgMes41_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            dgMes_ToolTip(dgMes41, e.X, e.Y);
        }

        private void dgMes51_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            dgMes_ToolTip(dgMes51, e.X, e.Y);
        }

        private void dgMes61_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            dgMes_ToolTip(dgMes61, e.X, e.Y);
        }

        private void dgMes12_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            dgMes_ToolTip(dgMes12, e.X, e.Y);
        }

        private void dgMes22_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            dgMes_ToolTip(dgMes22, e.X, e.Y);
        }

        private void dgMes32_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            dgMes_ToolTip(dgMes32, e.X, e.Y);
        }

        private void dgMes42_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            dgMes_ToolTip(dgMes42, e.X, e.Y);
        }

        private void dgMes52_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            dgMes_ToolTip(dgMes52, e.X, e.Y);
        }

        private void dgMes62_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            dgMes_ToolTip(dgMes62, e.X, e.Y);
        }

        private void dgMes13_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            dgMes_ToolTip(dgMes13, e.X, e.Y);
        }

        private void dgMes23_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            dgMes_ToolTip(dgMes23, e.X, e.Y);
        }

        private void dgMes33_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            dgMes_ToolTip(dgMes33, e.X, e.Y);
        }

        private void dgMes43_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            dgMes_ToolTip(dgMes43, e.X, e.Y);
        }

        private void dgMes53_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            dgMes_ToolTip(dgMes53, e.X, e.Y);
        }

        private void dgMes63_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            dgMes_ToolTip(dgMes63, e.X, e.Y);
        }

        private void dgMes14_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            dgMes_ToolTip(dgMes14, e.X, e.Y);
        }

        private void dgMes24_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            dgMes_ToolTip(dgMes24, e.X, e.Y);
        }

        private void dgMes34_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            dgMes_ToolTip(dgMes34, e.X, e.Y);
        }

        private void dgMes44_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            dgMes_ToolTip(dgMes44, e.X, e.Y);
        }

        private void dgMes54_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            dgMes_ToolTip(dgMes54, e.X, e.Y);
        }

        private void dgMes64_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            dgMes_ToolTip(dgMes64, e.X, e.Y);
        }

        private void dgMes15_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            dgMes_ToolTip(dgMes15, e.X, e.Y);
        }

        private void dgMes25_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            dgMes_ToolTip(dgMes25, e.X, e.Y);
        }

        private void dgMes35_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            dgMes_ToolTip(dgMes35, e.X, e.Y);
        }

        private void dgMes45_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            dgMes_ToolTip(dgMes45, e.X, e.Y);
        }

        private void dgMes55_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            dgMes_ToolTip(dgMes55, e.X, e.Y);
        }

        private void dgMes65_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            dgMes_ToolTip(dgMes65, e.X, e.Y);
        }

        private void dgMes16_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            dgMes_ToolTip(dgMes16, e.X, e.Y);
        }

        private void dgMes26_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            dgMes_ToolTip(dgMes26, e.X, e.Y);
        }

        private void dgMes36_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            dgMes_ToolTip(dgMes36, e.X, e.Y);
        }

        private void dgMes46_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            dgMes_ToolTip(dgMes46, e.X, e.Y);
        }

        private void dgMes56_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            dgMes_ToolTip(dgMes56, e.X, e.Y);
        }

        private void dgMes66_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            dgMes_ToolTip(dgMes66, e.X, e.Y);
        }
        #endregion

        #region lblMes_Click

        private void lblMes_Click(DateTime dFecha)
        {
            try
            {
                this.Var_CambioFecha = 0;
                this.dtpCalendario.Value = dFecha;
                Ver_Diario();
                this.Var_CambioFecha = 1;
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }

        private void lblMes11_Click(object sender, System.EventArgs e)
        {
            try
            {
                lblMes_Click(DateTime.Parse(this.lblMes11.Text.ToString()));
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }

        private void lblMes21_Click(object sender, System.EventArgs e)
        {
            try
            {
                lblMes_Click(DateTime.Parse(this.lblMes21.Text.ToString()));
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }

        private void lblMes31_Click(object sender, System.EventArgs e)
        {
            try
            {
                lblMes_Click(DateTime.Parse(this.lblMes31.Text.ToString()));
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }

        private void lblMes41_Click(object sender, System.EventArgs e)
        {
            try
            {
                lblMes_Click(DateTime.Parse(this.lblMes41.Text.ToString()));
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }

        private void lblMes51_Click(object sender, System.EventArgs e)
        {
            try
            {
                lblMes_Click(DateTime.Parse(this.lblMes51.Text.ToString()));
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }

        private void lblMes61_Click(object sender, System.EventArgs e)
        {
            try
            {
                lblMes_Click(DateTime.Parse(this.lblMes51.Text.ToString()).AddDays(1));
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }

        private void lblMes12_Click(object sender, System.EventArgs e)
        {
            try
            {
                lblMes_Click(DateTime.Parse(this.lblMes12.Text.ToString()));
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }

        private void lblMes22_Click(object sender, System.EventArgs e)
        {
            try
            {
                lblMes_Click(DateTime.Parse(this.lblMes22.Text.ToString()));
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }

        private void lblMes32_Click(object sender, System.EventArgs e)
        {
            try
            {
                lblMes_Click(DateTime.Parse(this.lblMes32.Text.ToString()));
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }

        private void lblMes42_Click(object sender, System.EventArgs e)
        {
            try
            {
                lblMes_Click(DateTime.Parse(this.lblMes42.Text.ToString()));
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }

        private void lblMes52_Click(object sender, System.EventArgs e)
        {
            try
            {
                lblMes_Click(DateTime.Parse(this.lblMes52.Text.ToString()));
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }

        private void lblMes62_Click(object sender, System.EventArgs e)
        {
            try
            {
                lblMes_Click(DateTime.Parse(this.lblMes52.Text.ToString()).AddDays(1));
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }

        private void lblMes13_Click(object sender, System.EventArgs e)
        {
            try
            {
                lblMes_Click(DateTime.Parse(this.lblMes13.Text.ToString()));
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }

        private void lblMes23_Click(object sender, System.EventArgs e)
        {
            try
            {
                lblMes_Click(DateTime.Parse(this.lblMes23.Text.ToString()));
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }

        private void lblMes33_Click(object sender, System.EventArgs e)
        {
            try
            {
                lblMes_Click(DateTime.Parse(this.lblMes33.Text.ToString()));
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }

        private void lblMes43_Click(object sender, System.EventArgs e)
        {
            try
            {
                lblMes_Click(DateTime.Parse(this.lblMes43.Text.ToString()));
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }

        private void lblMes53_Click(object sender, System.EventArgs e)
        {
            try
            {
                lblMes_Click(DateTime.Parse(this.lblMes53.Text.ToString()));
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }

        private void lblMes63_Click(object sender, System.EventArgs e)
        {
            try
            {
                lblMes_Click(DateTime.Parse(this.lblMes53.Text.ToString()).AddDays(1));
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }

        private void lblMes14_Click(object sender, System.EventArgs e)
        {
            try
            {
                lblMes_Click(DateTime.Parse(this.lblMes14.Text.ToString()));
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }

        private void lblMes24_Click(object sender, System.EventArgs e)
        {
            try
            {
                lblMes_Click(DateTime.Parse(this.lblMes24.Text.ToString()));
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }

        private void lblMes34_Click(object sender, System.EventArgs e)
        {
            try
            {
                lblMes_Click(DateTime.Parse(this.lblMes34.Text.ToString()));
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }

        private void lblMes44_Click(object sender, System.EventArgs e)
        {
            try
            {
                lblMes_Click(DateTime.Parse(this.lblMes44.Text.ToString()));
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }
        private void lblMes54_Click(object sender, System.EventArgs e)
        {
            try
            {
                lblMes_Click(DateTime.Parse(this.lblMes54.Text.ToString()));
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }

        private void lblMes64_Click(object sender, System.EventArgs e)
        {
            try
            {
                lblMes_Click(DateTime.Parse(this.lblMes54.Text.ToString()).AddDays(1));
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }

        private void lblMes15_Click(object sender, System.EventArgs e)
        {
            try
            {
                lblMes_Click(DateTime.Parse(this.lblMes15.Text.ToString()));
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }

        private void lblMes25_Click(object sender, System.EventArgs e)
        {
            try
            {
                lblMes_Click(DateTime.Parse(this.lblMes25.Text.ToString()));
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }

        private void lblMes35_Click(object sender, System.EventArgs e)
        {
            try
            {
                lblMes_Click(DateTime.Parse(this.lblMes35.Text.ToString()));
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }

        private void lblMes45_Click(object sender, System.EventArgs e)
        {
            try
            {
                lblMes_Click(DateTime.Parse(this.lblMes45.Text.ToString()));
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }

        private void lblMes55_Click(object sender, System.EventArgs e)
        {
            try
            {
                lblMes_Click(DateTime.Parse(this.lblMes55.Text.ToString()));
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }

        private void lblMes65_Click(object sender, System.EventArgs e)
        {
            try
            {
                lblMes_Click(DateTime.Parse(this.lblMes55.Text.ToString()).AddDays(1));
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }

        private void lblMes16_Click(object sender, System.EventArgs e)
        {
            try
            {
                lblMes_Click(DateTime.Parse(this.lblMes16.Text.ToString()));
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }

        private void lblMes26_Click(object sender, System.EventArgs e)
        {
            try
            {
                lblMes_Click(DateTime.Parse(this.lblMes26.Text.ToString()));
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }

        private void lblMes36_Click(object sender, System.EventArgs e)
        {
            try
            {
                lblMes_Click(DateTime.Parse(this.lblMes36.Text.ToString()));
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }

        private void lblMes46_Click(object sender, System.EventArgs e)
        {
            try
            {
                lblMes_Click(DateTime.Parse(this.lblMes46.Text.ToString()));
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }

        private void lblMes56_Click(object sender, System.EventArgs e)
        {
            try
            {
                lblMes_Click(DateTime.Parse(this.lblMes56.Text.ToString()));
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }

        private void lblMes66_Click(object sender, System.EventArgs e)
        {
            try
            {
                lblMes_Click(DateTime.Parse(this.lblMes56.Text.ToString()).AddDays(1));
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }
        #endregion




        #region btNuevo_Click
        private void btNuevo_Click(object sender, System.EventArgs e)
        {
            Nuevo_Report();

            //---- GSG (20/06/2016)
            pictureBoxArrastro.Location = new System.Drawing.Point(_K_LOC_X, _K_LOC_Y);
            pictureBoxArrastro.Visible = false;
        }
        #endregion

        #region cntMnuNuevo_Click
        private void cntMnuNuevo_Click(object sender, System.EventArgs e)
        {
            Nuevo_Report();

            //---- GSG (20/06/2016)
            pictureBoxArrastro.Location = new System.Drawing.Point(_K_LOC_X, _K_LOC_Y);
            pictureBoxArrastro.Visible = false;
        }
        #endregion

        #region Nuevo_Report
        private void Nuevo_Report()
        {
            try
            {
                if (this.Var_TipoAcceso == "M")
                {
                    if (int.Parse(this.cbDelegado.SelectedValue.ToString()) == Configuracion.iIdDelegado)
                    {
                        bool abierto = false;

                        if (this.ParentForm == null) abierto = Utiles.MirarSiFormAbierto("frmReporting", this.Owner);
                        else abierto = Utiles.MirarSiFormAbierto("frmReporting", this.ParentForm);

                        if (!abierto)
                        {
                            Form frmTemp = new Formularios.frmReporting("A", -1, this.dFecha, GESTCRM.Clases.Configuracion.iIdDelegado);
                            frmTemp.MdiParent = this.ParentForm;
                            frmTemp.Show();
                        }
                        else
                        {
                            DialogResult dr = Mensajes.ShowQuestion("No se puede crear un Report porque ya hay uno abierto. ¿Desea ver el report abierto?");
                            if (dr == System.Windows.Forms.DialogResult.Yes)
                            {
                                GESTCRM.Utiles.ActivaFormularioAbierto("frmReporting", this.MdiParent);
                            }
                        }
                    }
                    else
                    {
                        GESTCRM.Mensajes.ShowError(2000);//Sólo crear Reports propios
                    }
                }
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }
        #endregion

        #region btEditar_Click
        private void btEditar_Click(object sender, System.EventArgs e)
        {
            Editar_Report();

            //---- GSG (20/06/2016)
            pictureBoxArrastro.Location = new System.Drawing.Point(_K_LOC_X, _K_LOC_Y);
            pictureBoxArrastro.Visible = false;
        }
        #endregion

        #region cntMnuEditar_Click
        private void cntMnuEditar_Click(object sender, System.EventArgs e)
        {
            Editar_Report();

            //---- GSG (20/06/2016)
            pictureBoxArrastro.Location = new System.Drawing.Point(_K_LOC_X, _K_LOC_Y);
            pictureBoxArrastro.Visible = false;
        }
        #endregion

        #region btEliminar_Click
        private void btEliminar_Click(object sender, System.EventArgs e)
        {
            Borrar_Report(this.dgActivo, this.diaActivo);
        }
        #endregion

        #region cntMnuEliminar_Click
        private void cntMnuEliminar_Click(object sender, System.EventArgs e)
        {
            Borrar_Report(this.dgActivo, this.diaActivo);
        }
        #endregion


        #region Editar_Report
        private void Editar_Report()
        {
            AccesoReportVisita(this.dgActivo, this.diaActivo);
            
        }
        #endregion

        #region AccesoReportVisita
        private void AccesoReportVisita(MiDataGrid dg, int Dia)
        {
            try
            {
                if (dtDias.Rows.Count > 0)
                {
                    for (int i = 0; i < dtDias.Rows.Count; i++)
                    {
                        if (int.Parse(dtDias.Rows[i]["NumDia"].ToString()) == Dia &&
                            int.Parse(dtDias.Rows[i]["FilaDg"].ToString()) == dg.CurrentRowIndex)
                        {

                            string Acceso = this.Var_TipoAcceso;
                            bool abierto = false;

                            if (Int32.Parse(this.cbDelegado.SelectedValue.ToString()) != Configuracion.iIdDelegado)
                            { Acceso = "C"; }

                            if (this.ParentForm == null) abierto = Utiles.MirarSiFormAbierto("frmReporting", this.Owner);
                            else abierto = Utiles.MirarSiFormAbierto("frmReporting", this.ParentForm);

                            if (!abierto)
                            {
                                int IdReport = Int32.Parse(this.dtDias.Rows[i]["iIdReport"].ToString());
                                Form frmTemp = new Formularios.frmReporting(Acceso, IdReport, this.dFecha, int.Parse(this.cbDelegado.SelectedValue.ToString()));
                                frmTemp.MdiParent = this.ParentForm;
                                frmTemp.Show();
                            }
                            else
                            {
                                DialogResult dr = Mensajes.ShowQuestion("No se puede modificar un Report porque ya hay uno abierto. ¿Desea ver el report abierto?");
                                if (dr == System.Windows.Forms.DialogResult.Yes)
                                {
                                    GESTCRM.Utiles.ActivaFormularioAbierto("frmReporting", this.MdiParent);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }

        //---- GSG (17/06/2016)
        private void AccesoReportVisita(MiDataGrid dg, int Dia, DateTime nuevaFecha)
        {
            try
            {
                if (dtDias.Rows.Count > 0)
                {
                    for (int i = 0; i < dtDias.Rows.Count; i++)
                    {
                        if (int.Parse(dtDias.Rows[i]["NumDia"].ToString()) == Dia &&
                            int.Parse(dtDias.Rows[i]["FilaDg"].ToString()) == dg.CurrentRowIndex)
                        {

                            string Acceso = this.Var_TipoAcceso;
                            bool abierto = false;

                            if (Int32.Parse(this.cbDelegado.SelectedValue.ToString()) != Configuracion.iIdDelegado)
                            { Acceso = "C"; }

                            if (this.ParentForm == null) abierto = Utiles.MirarSiFormAbierto("frmReporting", this.Owner);
                            else abierto = Utiles.MirarSiFormAbierto("frmReporting", this.ParentForm);

                            if (!abierto)
                            {
                                int IdReport = Int32.Parse(this.dtDias.Rows[i]["iIdReport"].ToString());
                                Form frmTemp = new Formularios.frmReporting(Acceso, IdReport, this.dFecha, int.Parse(this.cbDelegado.SelectedValue.ToString()), nuevaFecha);
                                frmTemp.MdiParent = this.ParentForm;
                                frmTemp.Show();
                            }
                            else
                            {
                                DialogResult dr = Mensajes.ShowQuestion("No se puede modificar un Report porque ya hay uno abierto. ¿Desea ver el report abierto?");
                                if (dr == System.Windows.Forms.DialogResult.Yes)
                                {
                                    GESTCRM.Utiles.ActivaFormularioAbierto("frmReporting", this.MdiParent);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }
        #endregion

        #region Borrar_Report
        private void Borrar_Report(MiDataGrid dg, int Dia)
        {
            try
            {
                string sMensj = "";

                if (this.Var_TipoAcceso == "M")
                {
                    DialogResult dr = Mensajes.ShowQuestion("¿Desea borrar el registro?");
                    if (dr == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (Int32.Parse(this.cbDelegado.SelectedValue.ToString()) == Configuracion.iIdDelegado)
                        {
                            bool abierto = false;

                            if (this.ParentForm == null) abierto = Utiles.MirarSiFormAbierto("frmReporting", this.Owner);
                            else abierto = Utiles.MirarSiFormAbierto("frmReporting", this.ParentForm);

                            if (!abierto)
                            {
                                if (dtDias.Rows.Count > 0)
                                {
                                    for (int i = 0; i < dtDias.Rows.Count; i++)
                                    {
                                        if (int.Parse(dtDias.Rows[i]["NumDia"].ToString()) == Dia &&
                                            int.Parse(dtDias.Rows[i]["FilaDg"].ToString()) == dg.CurrentRowIndex &&
                                            dtDias.Rows[i]["bEnviadoCEN"].ToString() == "False")
                                        {
                                            int IdReport = int.Parse(this.dtDias.Rows[i]["iIdReport"].ToString());
                                            //Borrar
                                            //---- GSG (10/09/2014)
                                            //sqlConn.Open();
                                            if (sqlConn.State == ConnectionState.Closed)
                                                sqlConn.Open();


                                            try
                                            {
                                                this.sqlCmdGetPuedeBorrarReport.Parameters["@iIdReport"].Value = IdReport;

                                                this.sqlCmdGetPuedeBorrarReport.ExecuteNonQuery();

                                                int Total = int.Parse(this.sqlCmdGetPuedeBorrarReport.Parameters["@Total"].Value.ToString());

                                                if (Total == 0)
                                                {
                                                    try
                                                    {
                                                        this.sqlcmdSetRepActividad_Cab.Parameters["@iIdReport"].Value = IdReport;
                                                        this.sqlcmdSetRepActividad_Cab.Parameters["@Accion"].Value = 2;

                                                        this.sqlcmdSetRepActividad_Cab.ExecuteNonQuery();

                                                        Cargar_Pantalla();

                                                        Mensajes.ShowInformation("Se ha eliminado el registro");

                                                    }
                                                    catch (System.Data.SqlClient.SqlException ex)
                                                    {
                                                        sMensj = "Error al eliminar Report de Actividad: ";
                                                        foreach (System.Data.SqlClient.SqlError Err in ex.Errors)
                                                        {
                                                            sMensj += Err.Number.ToString() + " - " + Err.Message.ToString();
                                                        }

                                                        Mensajes.ShowError(sMensj);
                                                    }
                                                    catch (Exception e)
                                                    {
                                                        Mensajes.ShowError(e.Message);
                                                    }
                                                }
                                                else
                                                {
                                                    Mensajes.ShowInformation("No se puede eliminar el Report porqué tiene Atenciones asignadas que están asociadas a una Nota de Gastos que ya se ha enviado a Central.");
                                                }
                                            }
                                            catch (System.Data.SqlClient.SqlException ex)
                                            {
                                                sMensj = "Error al eliminar Report de Actividad: ";
                                                foreach (System.Data.SqlClient.SqlError Err in ex.Errors)
                                                {
                                                    sMensj += Err.Number.ToString() + " - " + Err.Message.ToString();
                                                }

                                                Mensajes.ShowError(sMensj);
                                            }
                                            catch (Exception e)
                                            {
                                                Mensajes.ShowError(e.Message);
                                            }
                                            this.sqlConn.Close();

                                        }
                                    }
                                }
                            }
                            else
                            {
                                DialogResult dr1 = Mensajes.ShowQuestion("No se puede eliminar un Report porque hay uno abierto. ¿Desea ver el report abierto?");
                                if (dr1 == System.Windows.Forms.DialogResult.Yes)
                                {
                                    GESTCRM.Utiles.ActivaFormularioAbierto("frmReporting", this.MdiParent);
                                }
                            }
                        }
                        else
                        {
                            GESTCRM.Mensajes.ShowError("No se pueden borrar Reports de Visita de otro delegado");//Sólo modificar Reports propios
                        }
                    }
                }
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }
        #endregion

        #region btSalir_Click
        private void btSalir_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region frmConsultaVisit_Closed
        private void frmConsultaVisit_Closed(object sender, System.EventArgs e)
        {
            this.Dispose();
        }
        #endregion

        #region cbDelegado_Leave
        private void cbDelegado_Leave(object sender, System.EventArgs e)
        {
            if (this.cbDelegado.SelectedIndex == -1) this.cbDelegado.SelectedValue = Configuracion.iIdDelegado;
        }
        #endregion

        private void frmConsultaVisit_Activated(object sender, System.EventArgs e)
        {
            if (Utiles.Cargar_Planificacion)
            {
                this.pnDiario.Visible = false;
                this.pnSemana.Visible = false;
                this.pnMensual.Visible = false;
                Utiles.Cargar_Planificacion = false;
            }
        }



        //---- GSG (15/06/2016)

        private void pictureBoxArrastro_MouseDown(object sender, MouseEventArgs e)
        {
            PictureBox pic = (PictureBox)sender;
            origenes = sender;

            if (e.Button == MouseButtons.Left)
            {
                if (pic.Image != null)
                {
                    pic.DoDragDrop(pic.Image, DragDropEffects.Move);
                }

                //pic.Location = new System.Drawing.Point(PointToClient(MousePosition).X, PointToClient(MousePosition).Y);
            }
        }


        
        private void dgSemana1_DragDrop(object sender, DragEventArgs e)
        {
            if (this.dgActivo != null)
            {
                string fecha = this.lblSemana1.Text.ToString();
                int pos = fecha.IndexOf(" ");
                fecha = fecha.Substring(pos + 1, fecha.Length - (pos + 1));

                //---- GSG (20/06/2016)
                pictureBoxArrastro.Location = new System.Drawing.Point(_K_LOC_X, _K_LOC_Y);
                pictureBoxArrastro.Visible = false;

                Comun._lNomsPlanificats.Add(this.dgActivo[dgActivo.CurrentRowIndex, 3].ToString());

                AccesoReportVisita(this.dgActivo, this.diaActivo, DateTime.Parse(fecha));

                
            }
        }

        

        private void dgSemana2_DragDrop(object sender, DragEventArgs e)
        {
            if (this.dgActivo != null)
            {
                string fecha = this.lblSemana2.Text.ToString();
                int pos = fecha.IndexOf(" ");
                fecha = fecha.Substring(pos + 1, fecha.Length - (pos + 1));

                //---- GSG (20/06/2016)
                pictureBoxArrastro.Location = new System.Drawing.Point(_K_LOC_X, _K_LOC_Y);
                pictureBoxArrastro.Visible = false;

                AccesoReportVisita(this.dgActivo, this.diaActivo, DateTime.Parse(fecha));
            }
        }

        private void dgSemana3_DragDrop(object sender, DragEventArgs e)
        {
            

            if (this.dgActivo != null)
            {
                string fecha = this.lblSemana3.Text.ToString();
                int pos = fecha.IndexOf(" ");
                fecha = fecha.Substring(pos + 1, fecha.Length - (pos + 1));

                //---- GSG (20/06/2016)
                pictureBoxArrastro.Location = new System.Drawing.Point(_K_LOC_X, _K_LOC_Y);
                pictureBoxArrastro.Visible = false;

                AccesoReportVisita(this.dgActivo, this.diaActivo, DateTime.Parse(fecha));
            }
        }

        private void dgSemana4_DragDrop(object sender, DragEventArgs e)
        {
            if (this.dgActivo != null)
            {
                string fecha = this.lblSemana4.Text.ToString();
                int pos = fecha.IndexOf(" ");
                fecha = fecha.Substring(pos + 1, fecha.Length - (pos + 1));

                //---- GSG (20/06/2016)
                pictureBoxArrastro.Location = new System.Drawing.Point(_K_LOC_X, _K_LOC_Y);
                pictureBoxArrastro.Visible = false;

                AccesoReportVisita(this.dgActivo, this.diaActivo, DateTime.Parse(fecha));
            }
        }

        private void dgSemana5_DragDrop(object sender, DragEventArgs e)
        {
            

            if (this.dgActivo != null)
            {
                string fecha = this.lblSemana5.Text.ToString();
                int pos = fecha.IndexOf(" ");
                fecha = fecha.Substring(pos + 1, fecha.Length - (pos + 1));

                //---- GSG (20/06/2016)
                pictureBoxArrastro.Location = new System.Drawing.Point(_K_LOC_X, _K_LOC_Y);
                pictureBoxArrastro.Visible = false;

                AccesoReportVisita(this.dgActivo, this.diaActivo, DateTime.Parse(fecha));
            }
        }


        private void dgSemana1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
        private void dgSemana2_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void dgSemana3_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void dgSemana4_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void dgSemana5_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void dgSemana6_Scroll(object sender, EventArgs e)
        {
            //---- GSG (20/06/2016)
            pictureBoxArrastro.Location = new System.Drawing.Point(_K_LOC_X, _K_LOC_Y);
            pictureBoxArrastro.Visible = false;
        }




        //---- GSG (13/03/2019)
        private int GetVisitaDePlanif(int piIdCliente, DateTime pdIni, DateTime pdFin)
        {
            int idReport = 0; // no existe

            try
            {
                if (sqlConn.State == ConnectionState.Closed)
                    sqlConn.Open();

                this.sqlCmdGetVisitaDePlanif.Parameters["@iIdCliente"].Value = piIdCliente;
                this.sqlCmdGetVisitaDePlanif.Parameters["@dFechaIni"].Value = pdIni;
                this.sqlCmdGetVisitaDePlanif.Parameters["@dFechaFin"].Value = pdFin;

                this.sqlCmdGetVisitaDePlanif.ExecuteNonQuery();

                idReport = int.Parse(this.sqlCmdGetVisitaDePlanif.Parameters["@iIdReport"].Value.ToString());
            }
            catch(Exception e)
            {
                idReport = -1; // error
            }

            sqlConn.Close();

            return idReport;

        }


    }


    #region DataGridColoredTextBoxColumn
    public class DataGridColoredTextBoxColumn : DataGridTextBoxColumn
    {

        protected override void Paint(System.Drawing.Graphics g, System.Drawing.Rectangle bounds, System.Windows.Forms.CurrencyManager source, int rowNum, System.Drawing.Brush backBrush, System.Drawing.Brush foreBrush, bool alignToRight)
        {
                // Se condiciona el fondo del Color de una celda de un DataGrid
                // en función de si la fila (Visita) es una Planificación o no

                //---- GSG (01/02/2017)
                //Añado que si se arrastra la planificación a visita, la planificación cambie de color

                try
                {

                    CurrencyManager cm = (CurrencyManager)source;
                    DataView dv = (DataView)cm.List;
                    DataTable dt = dv.Table;

                    if (dv[rowNum]["bPlanificacion"].ToString() == "1")
                    {
                        if (dv[rowNum]["Orden"].ToString() == "2")
                        {
                            //blau
                            backBrush = new LinearGradientBrush(bounds,
                                Color.FromArgb(221, 233, 240),
                                Color.FromArgb(252, 253, 254),
                                LinearGradientMode.ForwardDiagonal);
                            foreBrush = new SolidBrush(Color.Black);
                        }
                        else
                        {                                                        
                            //---- GSG (01/02/2017) lo nuevo es este primer if
                            //---- GSG (13/03/2019) 
                            //if (Comun._lNomsPlanificats.IndexOf(dv[rowNum][3].ToString()) >= 0)
                            if (Comun._lNomsPlanificats.IndexOf(dv[rowNum][3].ToString()) >= 0 || Comun._lNomsPlanificats.IndexOf(dv[rowNum][4].ToString()) >= 0)
                            {
                                //groc
                                backBrush = new LinearGradientBrush(bounds,
                                    Color.FromArgb(234, 242, 79),
                                    Color.FromArgb(252, 253, 225),                                    
                                    LinearGradientMode.ForwardDiagonal);
                                foreBrush = new SolidBrush(Color.Black);
                            }                            
                            else
                            {                                
                                backBrush = new LinearGradientBrush(bounds,
                                    Color.FromArgb(106, 157, 191),
                                    Color.FromArgb(240, 245, 249),
                                    LinearGradientMode.ForwardDiagonal);
                                foreBrush = new SolidBrush(Color.Black);
                            }
                        }
                    }
                    else if (dv[rowNum]["bPlanificacion"].ToString() == "0")
                    {
                        if (dv[rowNum]["Orden"].ToString() == "2")
                        {
                            backBrush = new LinearGradientBrush(bounds,
                                Color.FromArgb(215, 245, 199),
                                Color.FromArgb(248, 253, 244),
                                LinearGradientMode.ForwardDiagonal);
                            foreBrush = new SolidBrush(Color.Black);
                        }
                        else
                        {
                            backBrush = new LinearGradientBrush(bounds,
                                Color.FromArgb(106, 218, 46),
                                Color.FromArgb(248, 253, 244),
                                LinearGradientMode.ForwardDiagonal);
                            foreBrush = new SolidBrush(Color.Black);
                        }
                    }
                }
                catch { }
                finally
                {
                    // make sure the base class gets called to do the drawing with
                    // the possibly changed brushes
                    base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight);

                }
            }
        }
        #endregion

    
}


