using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GESTCRM.Clases;
using System.IO;

namespace GESTCRM.Formularios
{
    public partial class frmImportarPedido : Form
    {
        #region constantes
        //private const string K_FARMATIC = "FARMATIC";
        private const string K_FARMATIC = "Excel"; //---- GSG (11/03/2014)
        private const string K_UNYCOP = "UNYCOP";

        private const int K_FARMATIC_POS_COD = 0;
        private const int K_FARMATIC_POS_UNI = 1;
        private const char K_FARMATIC_SEPARADOR = ';';
        private const int K_FARMATIC_LIN_INI = 1; //La 0 es la cabecera
        private const string K_FARMATIC_FILE_EXTENSION = "csv";
        private const string K_FARMATIC_CHAR_ELIMINAR = null; //Caracter a eliminar de la cadena porque no nos interesa. En Farmatic ninguno (he puesto espacio)
        private const string K_FARMATIC_CHAR_DESCARTARHASTAFINAL = ",";

        private const int K_UNYCOP_POS_COD = 1;
        private const int K_UNYCOP_POS_UNI = 2;
        private const char K_UNYCOP_SEPARADOR = ',';
        private const int K_UNYCOP_LIN_INI = 1; //La 0 es la cabecera
        private const string K_UNYCOP_FILE_EXTENSION = "txt";
        private const string K_UNYCOP_CHAR_ELIMINAR = "\""; //En Unycop no nos interesan la comillas dobles que vienen con el cóigo sap del material
        private const string K_UNYCOP_CHAR_DESCARTARHASTAFINAL = null;

        private const string K_LIN = "LIN"; //---- GSG (09/01/2013)

        #endregion

        #region variables globales

        private System.Data.SqlClient.SqlConnection sqlConn;
        private string _iIdCampanya = "";
        private string _sIdCliente = "";
        private int _iIdCliente = -1;
        private string _sNombreCliente = "";
        private int _iIdDelegado = -1;
        private string _sTipoImportacion = "";
        private int _iPosCod = -1;
        private int _iPosUni = -1;
        private char _cSeparador = ' ';
        private int _iLinIni = -1;
        private string _sFileExtension = "";
        private string _sCharEliminar = "";
        private string _sCharDescartarHastaFinal = "";
        //private bool _bEsClienteConAccMark = false; //---- GSG (05/07/2017)
        List<string[]> _carga = new List<string[]>();
        private bool _bCanario = false; //---- GSG (12/12/2014)

        private GESTCRM.Formularios.DataSets.dsAccionesMarketing dsAccionesMarketing1;
        private System.Data.SqlClient.SqlDataAdapter sqldaListaAccMarkCampByCli;
        private System.Data.SqlClient.SqlCommand sqlCmdListaAccMarkCampByCli;
        private System.Data.SqlClient.SqlCommand sqlCmdListaCampanyasNEW;
        private dsFormularios dsFormularios1;
        private dsMateriales dsMateriales1;
        private SqlDataAdapter sqldaListaCampanyas;
        private System.Data.SqlClient.SqlCommand sqlCmdListaCampanyas;
        private SqlDataAdapter sqlDaListaMateriales;
        private System.Data.SqlClient.SqlCommand sqlSelectListaMateriales;
        private System.Data.SqlClient.SqlCommand sqlGetDescripcionMat;
        private System.Data.SqlClient.SqlCommand sqlEsDelegadoCanarias; //---- GSG (12/12/2014)
        //---- GSG (08/04/2016)
        private System.Data.SqlClient.SqlDataAdapter sqldaListaMaterialesBloqueados;
        private System.Data.SqlClient.SqlCommand sqlCmdListaMaterialesBloqueados; 
        
        #endregion

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            System.Configuration.AppSettingsReader configurationAppSettings = new System.Configuration.AppSettingsReader();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImportarPedido));
            this.sqlConn = new System.Data.SqlClient.SqlConnection();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnImportar = new System.Windows.Forms.Button();
            this.lblImportando = new System.Windows.Forms.Label();
            this.dsAccionesMarketing1 = new GESTCRM.Formularios.DataSets.dsAccionesMarketing();
            this.dsFormularios1 = new GESTCRM.Formularios.dsFormularios();
            this.sqldaListaAccMarkCampByCli = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCmdListaAccMarkCampByCli = new System.Data.SqlClient.SqlCommand();
            this.sqldaListaCampanyas = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCmdListaCampanyasNEW = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdListaCampanyas = new System.Data.SqlClient.SqlCommand();
            this.gb1 = new System.Windows.Forms.GroupBox();
            this.chkBoxTipoPedido = new System.Windows.Forms.CheckBox();
            this.chkBoxDescuentos = new System.Windows.Forms.CheckBox();
            this.chkBoxCampanya = new System.Windows.Forms.CheckBox();
            this.chkBoxFlexible = new System.Windows.Forms.CheckBox();
            this.cboTipoPedido = new System.Windows.Forms.ComboBox();
            this.lblTipoPedido = new System.Windows.Forms.Label();
            this.lblComboC = new System.Windows.Forms.Label();
            this.cBoxCampanyas = new System.Windows.Forms.ComboBox();
            this.btBuscarFichero = new System.Windows.Forms.Button();
            this.txtFichero = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtClienteSAP = new System.Windows.Forms.TextBox();
            this.btBuscarCliente = new System.Windows.Forms.Button();
            this.txtsCliente = new System.Windows.Forms.TextBox();
            this.lblMissNoImportados = new System.Windows.Forms.Label();
            this.btnContinuar = new System.Windows.Forms.Button();
            this.sqlDaListaMateriales = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectListaMateriales = new System.Data.SqlClient.SqlCommand();
            this.sqlGetDescripcionMat = new System.Data.SqlClient.SqlCommand();
            this.dsMateriales1 = new GESTCRM.Formularios.dsMateriales();
            this.textBoxMaterialesNoImportados = new System.Windows.Forms.TextBox();
            this.gb2 = new System.Windows.Forms.GroupBox();
            this.lblMissSinStock = new System.Windows.Forms.Label();
            this.textBoxMaterialesSinStock = new System.Windows.Forms.TextBox();
            this.sqldaListaTiposPedidoSAP = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
            this.sqlEsDelegadoCanarias = new System.Data.SqlClient.SqlCommand();
            this.sqldaListaMaterialesBloqueados = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCmdListaMaterialesBloqueados = new System.Data.SqlClient.SqlCommand();
            ((System.ComponentModel.ISupportInitialize)(this.dsAccionesMarketing1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsFormularios1)).BeginInit();
            this.gb1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsMateriales1)).BeginInit();
            this.gb2.SuspendLayout();
            this.SuspendLayout();
            // 
            // sqlConn
            // 
            this.sqlConn.FireInfoMessageEventOnUserErrors = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.Black;
            this.btnCancelar.Image = global::GESTCRM.Properties.Resources.cancel_032x032;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(985, 63);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(111, 37);
            this.btnCancelar.TabIndex = 82;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnImportar
            // 
            this.btnImportar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnImportar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportar.ForeColor = System.Drawing.Color.Black;
            this.btnImportar.Image = ((System.Drawing.Image)(resources.GetObject("btnImportar.Image")));
            this.btnImportar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImportar.Location = new System.Drawing.Point(985, 19);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(112, 37);
            this.btnImportar.TabIndex = 81;
            this.btnImportar.Text = "Importar";
            this.btnImportar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImportar.UseVisualStyleBackColor = false;
            this.btnImportar.Click += new System.EventHandler(this.btnImportar_Click);
            // 
            // lblImportando
            // 
            this.lblImportando.AutoSize = true;
            this.lblImportando.BackColor = System.Drawing.Color.Transparent;
            this.lblImportando.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImportando.ForeColor = System.Drawing.Color.Black;
            this.lblImportando.Location = new System.Drawing.Point(331, 16);
            this.lblImportando.Name = "lblImportando";
            this.lblImportando.Size = new System.Drawing.Size(228, 20);
            this.lblImportando.TabIndex = 83;
            this.lblImportando.Text = "Importando datos del fichero ...";
            // 
            // dsAccionesMarketing1
            // 
            this.dsAccionesMarketing1.DataSetName = "dsAccionesMarketing";
            this.dsAccionesMarketing1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dsFormularios1
            // 
            this.dsFormularios1.DataSetName = "dsFormularios";
            this.dsFormularios1.Locale = new System.Globalization.CultureInfo("es-ES");
            this.dsFormularios1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            new System.Data.SqlClient.SqlParameter("@sIdTipoPedido", System.Data.SqlDbType.VarChar, 4)});
            // 
            // gb1
            // 
            this.gb1.Controls.Add(this.chkBoxTipoPedido);
            this.gb1.Controls.Add(this.chkBoxDescuentos);
            this.gb1.Controls.Add(this.chkBoxCampanya);
            this.gb1.Controls.Add(this.chkBoxFlexible);
            this.gb1.Controls.Add(this.cboTipoPedido);
            this.gb1.Controls.Add(this.lblTipoPedido);
            this.gb1.Controls.Add(this.lblComboC);
            this.gb1.Controls.Add(this.cBoxCampanyas);
            this.gb1.Controls.Add(this.btBuscarFichero);
            this.gb1.Controls.Add(this.txtFichero);
            this.gb1.Controls.Add(this.label3);
            this.gb1.Controls.Add(this.label2);
            this.gb1.Controls.Add(this.txtClienteSAP);
            this.gb1.Controls.Add(this.btBuscarCliente);
            this.gb1.Controls.Add(this.txtsCliente);
            this.gb1.Controls.Add(this.btnCancelar);
            this.gb1.Controls.Add(this.btnImportar);
            this.gb1.Location = new System.Drawing.Point(15, 2);
            this.gb1.Name = "gb1";
            this.gb1.Size = new System.Drawing.Size(1120, 108);
            this.gb1.TabIndex = 89;
            this.gb1.TabStop = false;
            // 
            // chkBoxTipoPedido
            // 
            this.chkBoxTipoPedido.AutoSize = true;
            this.chkBoxTipoPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBoxTipoPedido.ForeColor = System.Drawing.Color.Black;
            this.chkBoxTipoPedido.Location = new System.Drawing.Point(731, 80);
            this.chkBoxTipoPedido.Name = "chkBoxTipoPedido";
            this.chkBoxTipoPedido.Size = new System.Drawing.Size(193, 24);
            this.chkBoxTipoPedido.TabIndex = 131;
            this.chkBoxTipoPedido.Text = "Seleccionar tipo pedido";
            this.chkBoxTipoPedido.UseVisualStyleBackColor = true;
            this.chkBoxTipoPedido.CheckedChanged += new System.EventHandler(this.chkBoxTipoPedido_CheckedChanged);
            // 
            // chkBoxDescuentos
            // 
            this.chkBoxDescuentos.AutoSize = true;
            this.chkBoxDescuentos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBoxDescuentos.ForeColor = System.Drawing.Color.Black;
            this.chkBoxDescuentos.Location = new System.Drawing.Point(731, 59);
            this.chkBoxDescuentos.Name = "chkBoxDescuentos";
            this.chkBoxDescuentos.Size = new System.Drawing.Size(175, 24);
            this.chkBoxDescuentos.TabIndex = 130;
            this.chkBoxDescuentos.Text = "Importar descuentos";
            this.chkBoxDescuentos.UseVisualStyleBackColor = true;
            this.chkBoxDescuentos.CheckedChanged += new System.EventHandler(this.chkBoxDescuentos_CheckedChanged);
            // 
            // chkBoxCampanya
            // 
            this.chkBoxCampanya.AutoSize = true;
            this.chkBoxCampanya.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBoxCampanya.ForeColor = System.Drawing.Color.Black;
            this.chkBoxCampanya.Location = new System.Drawing.Point(731, 38);
            this.chkBoxCampanya.Name = "chkBoxCampanya";
            this.chkBoxCampanya.Size = new System.Drawing.Size(181, 24);
            this.chkBoxCampanya.TabIndex = 129;
            this.chkBoxCampanya.Text = "Seleccionar campaña";
            this.chkBoxCampanya.UseVisualStyleBackColor = true;
            this.chkBoxCampanya.CheckedChanged += new System.EventHandler(this.chkBoxCampanya_CheckedChanged);
            // 
            // chkBoxFlexible
            // 
            this.chkBoxFlexible.AutoSize = true;
            this.chkBoxFlexible.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBoxFlexible.ForeColor = System.Drawing.Color.Black;
            this.chkBoxFlexible.Location = new System.Drawing.Point(731, 17);
            this.chkBoxFlexible.Name = "chkBoxFlexible";
            this.chkBoxFlexible.Size = new System.Drawing.Size(223, 24);
            this.chkBoxFlexible.TabIndex = 128;
            this.chkBoxFlexible.Text = "Importar a campaña flexible";
            this.chkBoxFlexible.UseVisualStyleBackColor = true;
            this.chkBoxFlexible.CheckedChanged += new System.EventHandler(this.chkBoxFlexible_CheckedChanged);
            // 
            // cboTipoPedido
            // 
            this.cboTipoPedido.BackColor = System.Drawing.Color.White;
            this.cboTipoPedido.DataSource = this.dsFormularios1;
            this.cboTipoPedido.DisplayMember = "ListaTiposPedidoSAP.sLiteral";
            this.cboTipoPedido.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipoPedido.Location = new System.Drawing.Point(527, 76);
            this.cboTipoPedido.Name = "cboTipoPedido";
            this.cboTipoPedido.Size = new System.Drawing.Size(156, 28);
            this.cboTipoPedido.TabIndex = 99;
            this.cboTipoPedido.ValueMember = "ListaTiposPedidoSAP.sValor";
            this.cboTipoPedido.SelectedIndexChanged += new System.EventHandler(this.cboTipoPedido_SelectedIndexChanged);
            // 
            // lblTipoPedido
            // 
            this.lblTipoPedido.AutoSize = true;
            this.lblTipoPedido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(230)))), ((int)(((byte)(239)))));
            this.lblTipoPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoPedido.ForeColor = System.Drawing.Color.Black;
            this.lblTipoPedido.Location = new System.Drawing.Point(431, 80);
            this.lblTipoPedido.Name = "lblTipoPedido";
            this.lblTipoPedido.Size = new System.Drawing.Size(96, 20);
            this.lblTipoPedido.TabIndex = 100;
            this.lblTipoPedido.Text = "Tipo Pedido:";
            // 
            // lblComboC
            // 
            this.lblComboC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComboC.ForeColor = System.Drawing.Color.Black;
            this.lblComboC.Location = new System.Drawing.Point(26, 80);
            this.lblComboC.Name = "lblComboC";
            this.lblComboC.Size = new System.Drawing.Size(86, 19);
            this.lblComboC.TabIndex = 98;
            this.lblComboC.Text = "Campaña :";
            this.lblComboC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cBoxCampanyas
            // 
            this.cBoxCampanyas.BackColor = System.Drawing.Color.White;
            this.cBoxCampanyas.DisplayMember = "NombreCampanya";
            this.cBoxCampanyas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxCampanyas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cBoxCampanyas.ForeColor = System.Drawing.Color.Black;
            this.cBoxCampanyas.Location = new System.Drawing.Point(115, 76);
            this.cBoxCampanyas.Name = "cBoxCampanyas";
            this.cBoxCampanyas.Size = new System.Drawing.Size(297, 28);
            this.cBoxCampanyas.TabIndex = 96;
            this.cBoxCampanyas.ValueMember = "idCampanya";
            this.cBoxCampanyas.SelectedIndexChanged += new System.EventHandler(this.cBoxCampanyas_SelectedIndexChanged);
            // 
            // btBuscarFichero
            // 
            this.btBuscarFichero.Image = ((System.Drawing.Image)(resources.GetObject("btBuscarFichero.Image")));
            this.btBuscarFichero.Location = new System.Drawing.Point(579, 46);
            this.btBuscarFichero.Name = "btBuscarFichero";
            this.btBuscarFichero.Size = new System.Drawing.Size(26, 26);
            this.btBuscarFichero.TabIndex = 95;
            this.btBuscarFichero.TabStop = false;
            this.btBuscarFichero.UseVisualStyleBackColor = true;
            this.btBuscarFichero.Click += new System.EventHandler(this.btBuscarFichero_Click);
            // 
            // txtFichero
            // 
            this.txtFichero.BackColor = System.Drawing.Color.White;
            this.txtFichero.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFichero.ForeColor = System.Drawing.Color.Black;
            this.txtFichero.Location = new System.Drawing.Point(98, 46);
            this.txtFichero.MaxLength = 20;
            this.txtFichero.Name = "txtFichero";
            this.txtFichero.Size = new System.Drawing.Size(475, 26);
            this.txtFichero.TabIndex = 94;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(26, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 19);
            this.label3.TabIndex = 93;
            this.label3.Text = "Fichero :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(26, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 19);
            this.label2.TabIndex = 92;
            this.label2.Text = "Cliente :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtClienteSAP
            // 
            this.txtClienteSAP.BackColor = System.Drawing.Color.White;
            this.txtClienteSAP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClienteSAP.ForeColor = System.Drawing.Color.Black;
            this.txtClienteSAP.Location = new System.Drawing.Point(98, 18);
            this.txtClienteSAP.MaxLength = 20;
            this.txtClienteSAP.Name = "txtClienteSAP";
            this.txtClienteSAP.Size = new System.Drawing.Size(119, 26);
            this.txtClienteSAP.TabIndex = 90;
            // 
            // btBuscarCliente
            // 
            this.btBuscarCliente.Image = ((System.Drawing.Image)(resources.GetObject("btBuscarCliente.Image")));
            this.btBuscarCliente.Location = new System.Drawing.Point(579, 18);
            this.btBuscarCliente.Name = "btBuscarCliente";
            this.btBuscarCliente.Size = new System.Drawing.Size(26, 26);
            this.btBuscarCliente.TabIndex = 89;
            this.btBuscarCliente.TabStop = false;
            this.btBuscarCliente.UseVisualStyleBackColor = true;
            this.btBuscarCliente.Click += new System.EventHandler(this.btBuscarCliente_Click);
            // 
            // txtsCliente
            // 
            this.txtsCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtsCliente.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtsCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsCliente.ForeColor = System.Drawing.Color.Black;
            this.txtsCliente.Location = new System.Drawing.Point(220, 18);
            this.txtsCliente.Name = "txtsCliente";
            this.txtsCliente.ReadOnly = true;
            this.txtsCliente.Size = new System.Drawing.Size(353, 26);
            this.txtsCliente.TabIndex = 91;
            this.txtsCliente.TabStop = false;
            // 
            // lblMissNoImportados
            // 
            this.lblMissNoImportados.BackColor = System.Drawing.Color.Transparent;
            this.lblMissNoImportados.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMissNoImportados.ForeColor = System.Drawing.Color.Red;
            this.lblMissNoImportados.Location = new System.Drawing.Point(25, 39);
            this.lblMissNoImportados.Name = "lblMissNoImportados";
            this.lblMissNoImportados.Size = new System.Drawing.Size(1077, 41);
            this.lblMissNoImportados.TabIndex = 90;
            this.lblMissNoImportados.Text = resources.GetString("lblMissNoImportados.Text");
            // 
            // btnContinuar
            // 
            this.btnContinuar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnContinuar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContinuar.ForeColor = System.Drawing.Color.Black;
            this.btnContinuar.Image = ((System.Drawing.Image)(resources.GetObject("btnContinuar.Image")));
            this.btnContinuar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnContinuar.Location = new System.Drawing.Point(498, 520);
            this.btnContinuar.Name = "btnContinuar";
            this.btnContinuar.Size = new System.Drawing.Size(125, 45);
            this.btnContinuar.TabIndex = 92;
            this.btnContinuar.Text = "Continuar";
            this.btnContinuar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnContinuar.UseVisualStyleBackColor = false;
            this.btnContinuar.Click += new System.EventHandler(this.btnContinuar_Click);
            // 
            // sqlDaListaMateriales
            // 
            this.sqlDaListaMateriales.SelectCommand = this.sqlSelectListaMateriales;
            this.sqlDaListaMateriales.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaMateriales", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("sIdMaterial", "sIdMaterial"),
                        new System.Data.Common.DataColumnMapping("sMaterial", "sMaterial"),
                        new System.Data.Common.DataColumnMapping("sCodNacional", "sCodNacional"),
                        new System.Data.Common.DataColumnMapping("fPrecio", "fPrecio"),
                        new System.Data.Common.DataColumnMapping("selected", "selected"),
                        new System.Data.Common.DataColumnMapping("iStock", "iStock"),
                        new System.Data.Common.DataColumnMapping("dEntrega", "dEntrega"),
                        new System.Data.Common.DataColumnMapping("iPendientes", "iPendientes")})});
            // 
            // sqlSelectListaMateriales
            // 
            this.sqlSelectListaMateriales.CommandText = "ListaMaterialesDesCamp";
            this.sqlSelectListaMateriales.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectListaMateriales.Connection = this.sqlConn;
            this.sqlSelectListaMateriales.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@sIdMaterial", System.Data.SqlDbType.VarChar, 18),
            new System.Data.SqlClient.SqlParameter("@sMaterial", System.Data.SqlDbType.VarChar, 50),
            new System.Data.SqlClient.SqlParameter("@sCodNacional", System.Data.SqlDbType.VarChar, 6),
            new System.Data.SqlClient.SqlParameter("@fPrecio", System.Data.SqlDbType.Float, 8),
            new System.Data.SqlClient.SqlParameter("@sIdRed", System.Data.SqlDbType.VarChar, 4),
            new System.Data.SqlClient.SqlParameter("@iIdCamp", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@sidCampanya", System.Data.SqlDbType.VarChar, 10)});
            // 
            // sqlGetDescripcionMat
            // 
            this.sqlGetDescripcionMat.CommandText = "GetDescripcioMaterial";
            this.sqlGetDescripcionMat.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlGetDescripcionMat.Connection = this.sqlConn;
            this.sqlGetDescripcionMat.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@sCodNacional", System.Data.SqlDbType.VarChar, 6),
            new System.Data.SqlClient.SqlParameter("@Ret", System.Data.SqlDbType.VarChar, 50, System.Data.ParameterDirection.Output, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null)});
            // 
            // dsMateriales1
            // 
            this.dsMateriales1.DataSetName = "dsMateriales";
            this.dsMateriales1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // textBoxMaterialesNoImportados
            // 
            this.textBoxMaterialesNoImportados.AcceptsReturn = true;
            this.textBoxMaterialesNoImportados.AcceptsTab = true;
            this.textBoxMaterialesNoImportados.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMaterialesNoImportados.Location = new System.Drawing.Point(35, 84);
            this.textBoxMaterialesNoImportados.Multiline = true;
            this.textBoxMaterialesNoImportados.Name = "textBoxMaterialesNoImportados";
            this.textBoxMaterialesNoImportados.ReadOnly = true;
            this.textBoxMaterialesNoImportados.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxMaterialesNoImportados.Size = new System.Drawing.Size(1051, 202);
            this.textBoxMaterialesNoImportados.TabIndex = 93;
            // 
            // gb2
            // 
            this.gb2.Controls.Add(this.lblMissSinStock);
            this.gb2.Controls.Add(this.textBoxMaterialesSinStock);
            this.gb2.Controls.Add(this.lblImportando);
            this.gb2.Controls.Add(this.btnContinuar);
            this.gb2.Controls.Add(this.textBoxMaterialesNoImportados);
            this.gb2.Controls.Add(this.lblMissNoImportados);
            this.gb2.Location = new System.Drawing.Point(15, 109);
            this.gb2.Name = "gb2";
            this.gb2.Size = new System.Drawing.Size(1120, 574);
            this.gb2.TabIndex = 94;
            this.gb2.TabStop = false;
            // 
            // lblMissSinStock
            // 
            this.lblMissSinStock.BackColor = System.Drawing.Color.Transparent;
            this.lblMissSinStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMissSinStock.ForeColor = System.Drawing.Color.Red;
            this.lblMissSinStock.Location = new System.Drawing.Point(329, 296);
            this.lblMissSinStock.Name = "lblMissSinStock";
            this.lblMissSinStock.Size = new System.Drawing.Size(463, 23);
            this.lblMissSinStock.TabIndex = 95;
            this.lblMissSinStock.Text = "Materiales sin existencias (Se cargarán aunque no haya stock):";
            // 
            // textBoxMaterialesSinStock
            // 
            this.textBoxMaterialesSinStock.AcceptsReturn = true;
            this.textBoxMaterialesSinStock.AcceptsTab = true;
            this.textBoxMaterialesSinStock.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMaterialesSinStock.Location = new System.Drawing.Point(35, 321);
            this.textBoxMaterialesSinStock.Multiline = true;
            this.textBoxMaterialesSinStock.Name = "textBoxMaterialesSinStock";
            this.textBoxMaterialesSinStock.ReadOnly = true;
            this.textBoxMaterialesSinStock.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxMaterialesSinStock.Size = new System.Drawing.Size(1051, 181);
            this.textBoxMaterialesSinStock.TabIndex = 94;
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
            // sqlEsDelegadoCanarias
            // 
            this.sqlEsDelegadoCanarias.CommandText = "dbo.[EsDelegadoCanarias]";
            this.sqlEsDelegadoCanarias.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlEsDelegadoCanarias.Connection = this.sqlConn;
            this.sqlEsDelegadoCanarias.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdDelegado", System.Data.SqlDbType.Int, 4)});
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
            // frmImportarPedido
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(230)))), ((int)(((byte)(239)))));
            this.ClientSize = new System.Drawing.Size(1147, 695);
            this.Controls.Add(this.gb2);
            this.Controls.Add(this.gb1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmImportarPedido";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Importación de Pedidos";
            this.Load += new System.EventHandler(this.frmImportarPedido_Load);
            this.SizeChanged += new System.EventHandler(this.frmImportarPedido_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dsAccionesMarketing1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsFormularios1)).EndInit();
            this.gb1.ResumeLayout(false);
            this.gb1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsMateriales1)).EndInit();
            this.gb2.ResumeLayout(false);
            this.gb2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion


        public frmImportarPedido(string tipoImportacion)
        {
            InitializeComponent();


            //---- GSG (06/03/2021)
            Utiles.GetConfigConnection();
            this.sqlConn.ConnectionString = Utiles._connection.ConnectionString.ToString();

            

            _iIdDelegado = Clases.Configuracion.iIdDelegado;
            _iIdCampanya = Clases.Configuracion.iIdCampanya.ToString();
            _sTipoImportacion = tipoImportacion;

            this.Text = "Importación de Pedido " + _sTipoImportacion;

            switch (_sTipoImportacion)
            {
                case K_FARMATIC:
                    _iPosCod = K_FARMATIC_POS_COD;
                    _iPosUni = K_FARMATIC_POS_UNI;
                    _cSeparador = K_FARMATIC_SEPARADOR;
                    _iLinIni = K_FARMATIC_LIN_INI;
                    _sFileExtension = K_FARMATIC_FILE_EXTENSION;
                    _sCharEliminar = K_FARMATIC_CHAR_ELIMINAR;
                    _sCharDescartarHastaFinal = K_FARMATIC_CHAR_DESCARTARHASTAFINAL;
                    break;
                case K_UNYCOP:
                    _iPosCod = K_UNYCOP_POS_COD;
                    _iPosUni = K_UNYCOP_POS_UNI;
                    _cSeparador = K_UNYCOP_SEPARADOR;
                    _iLinIni = K_UNYCOP_LIN_INI;
                    _sFileExtension = K_UNYCOP_FILE_EXTENSION;
                    _sCharEliminar = K_UNYCOP_CHAR_ELIMINAR;
                    _sCharDescartarHastaFinal = K_UNYCOP_CHAR_DESCARTARHASTAFINAL;
                    break;
            }


            //---- GSG (12/12/2014)
            initComboTipoPedido();
            _bCanario = EsDelegadoCanarias(Clases.Configuracion.iIdDelegado);
        }

        //---- GSG (12/12/2014)
        private void initComboTipoPedido()
        {
            cboTipoPedido.Enabled = false;
            dsFormularios1.ListaTiposPedidoSAP.Rows.Clear();
            sqldaListaTiposPedidoSAP.Fill(dsFormularios1.ListaTiposPedidoSAP); //llena combo tipos pedido

        }


        private void frmImportarPedido_Load(object sender, EventArgs e)
        {
            //---- GSG (19/08/2019) para poder importar con descuentos a cualquier campaña
            chkBoxCampanya.Checked = false;
            if (GESTCRM.Clases.Configuracion.sIdRed == Comun.K_RED_CH)
                chkBoxFlexible.Visible = false;
            //---- FI gsg


            cBoxCampanyas.Enabled = false;
                        
            lblImportando.Visible = false;
            lblMissNoImportados.Visible = false;
            textBoxMaterialesNoImportados.Visible = false;
            btnContinuar.Visible = false;

            posicionar();            
        }

        private void posicionar()
        {
            gb1.Left = this.Left + (this.Width - gb1.Width) / 2;
            gb2.Left = gb1.Left;
        }

        private void btBuscarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                //---- GSG (26/01/2016)
                chkBoxFlexible.Checked = false;
                chkBoxCampanya.Checked = false;

                //---- GSG (24/10/2019)
                //chkBoxDescuentos.Checked = false; //---- GSG (15/06/2016)
                if (Clases.Configuracion.sIdRed == Comun.K_RED_CH)
                    chkBoxDescuentos.Checked = true;
                else
                    chkBoxDescuentos.Checked = false;


                chkBoxTipoPedido.Checked = false; //---- GSG (11/10/2016)

                //---- GSG (12/12/2014)
                initComboTipoPedido();


                txtClienteSAP.Text = txtClienteSAP.Text.Trim().ToUpper();

                GESTCRM.Formularios.Busquedas.frmMClientesSAP frmBCli = new GESTCRM.Formularios.Busquedas.frmMClientesSAP(false, "P");

                frmBCli.ParamI_sIdTipoCliente = "S";
                frmBCli.ParamIO_sIdCliente = "";
                frmBCli.ParamI_sIdCentro = "";
                frmBCli.ParamI_iIdDelegado = (_iIdDelegado != 0) ? _iIdDelegado : -1;
                frmBCli.ShowDialog(this);

                if (frmBCli.DialogResult == DialogResult.OK)
                {
                    txtClienteSAP.Text = frmBCli.ParamIO_sIdCliente;
                    txtsCliente.Text = frmBCli.ParamO_tNombre;
                    _sIdCliente = frmBCli.ParamIO_sIdCliente;
                    _iIdCliente = frmBCli.ParamO_iIdCliente;
                    _sNombreCliente = frmBCli.ParamO_tNombre;


                    //---- GSG (05/07/2017)
                    //---- GSG (09/01/2014)
                    //FormatBuscarCampanyas(_iIdCliente);
                    //FormatBuscarCampanyas(_iIdCliente, true);
                    //---- GSG (26/01/2016)
                    //if (_bEsClienteConAccMark)
                    //{
                    //    chkBoxFlexible.Visible = false;
                    //    chkBoxCampanya.Visible = false;
                    //    chkBoxDescuentos.Visible = false; //---- GSG (15/06/2016)
                    //    chkBoxTipoPedido.Visible = false; //---- GSG (11/10/2016)
                    //}
                    //else
                    //{
                    //    chkBoxFlexible.Visible = true;
                    //    chkBoxCampanya.Visible = true;
                    //    chkBoxDescuentos.Visible = true; //---- GSG (15/06/2016)
                    //    //---- GSG (11/10/2016)
                    //    chkBoxTipoPedido.Visible = true;
                    //    if (cboTipoPedido.Visible)
                    //        chkBoxTipoPedido.Checked = true;
                    //}

                    if (cboTipoPedido.Visible)
                        FormatBuscarCampanyas(_iIdCliente, true, cboTipoPedido.SelectedValue.ToString(), "XXXX");
                    else
                        FormatBuscarCampanyas(_iIdCliente, true, "ZDIR", "XXXX");
                   

                    Application.DoEvents();
                }
            }
            catch (Exception ev)
            {
                Mensajes.ShowError("Error en evento btBuscarCliente_Click: " + ev.Message);
            }	
        }
        
        private void btBuscarFichero_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Title = "Seleccione el fichero con los materiales del pedido.";
            openFileDialog.Filter = "Archivos de Excel (*." + _sFileExtension + ")|*." + _sFileExtension;

            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                txtFichero.Text = openFileDialog.FileName;
            }
        }


        private void btnImportar_Click(object sender, EventArgs e)
        {
            string fitxer = txtFichero.Text;

            //---- GSG (19/08/2019)
            textBoxMaterialesSinStock.Text = "";
            textBoxMaterialesNoImportados.Text = "";
            _carga.Clear();
            dsMateriales1.ListaMateriales.Clear();
            //----


            //---- GSG (19/08/2019)
            //if (fitxer.Trim() != "" && fitxer != null && _sIdCliente != null && _sIdCliente.Trim() != "")
            if (fitxer.Trim() != "" && fitxer != null && _sIdCliente != null && _sIdCliente.Trim() != "" && (cBoxCampanyas.Enabled || chkBoxFlexible.Checked))
            {
                lblImportando.Visible = true;

                using (TextReader reader = new StreamReader(fitxer))
                {
                    string strLinea;
                    int lin = _iLinIni;

                    //Carga datos fichero
                    while ((strLinea = reader.ReadLine()) != null)
                    {
                        if (lin > _iLinIni)
                        {
                            if (_sCharEliminar != null)
                                strLinea = strLinea.Replace(_sCharEliminar, "");

                            //---- GSG (09/12/2014)
                            if (_sCharDescartarHastaFinal != null)
                            {
                                int pos = strLinea.IndexOf(_sCharDescartarHastaFinal);
                                if (pos > -1)
                                    strLinea = strLinea.Substring(0, pos);
                            }

                            string uni = strLinea.Substring(strLinea.IndexOf(_cSeparador) + 1).Trim();
                            string cn = strLinea.Substring(0, strLinea.IndexOf(_cSeparador)).Trim();
                            //---- GSG (15/06/2016)
                            string desc = "0";
                            //---- GSG (19/08/2019) para poder importar con descuentos a cualquier campaña
                            //if (chkBoxDescuentos.Checked && chkBoxFlexible.Checked)
                            if (chkBoxDescuentos.Checked)
                            {
                                if (strLinea.IndexOf(_cSeparador, strLinea.IndexOf(_cSeparador) + 1) == -1) // Se han olvidado de poner los descuentos en el fichero
                                    //añadir a línea
                                    strLinea += ";0";
                                else
                                    desc = strLinea.Substring(strLinea.IndexOf(_cSeparador, strLinea.IndexOf(_cSeparador) + 1) + 1).Trim();
                            }
                            //---- FI GSG


                            if (uni != "" && uni != "0" && cn != "")
                                _carga.Add(strLinea.Split(_cSeparador));                           
                        }

                        lin++;
                    }

                    //---- GSG (14/05/2015)
                    // Si venen negatius els convertim a positius
                    foreach (string[] item in _carga)
                    {
                        int uni = int.Parse(item[_iPosUni]);
                        if (uni < 0)
                            uni *= -1;
                        item[_iPosUni] = uni.ToString();
                    }


                    // A vegades el codi nacional ve amb el dígit de control (NNNNNN.N). En aquest cas l'hem de treure 
                    // També pot passar que vingui amb el dígit de control però sense punt
                    foreach (string[] item in _carga)
                    {
                        string cn = item[_iPosCod];
                        if (cn.IndexOf('.') >= 0)
                        {
                            cn = cn.Substring(0, cn.IndexOf('.'));
                            item[_iPosCod] = cn;
                        }
                        else if (cn.Length > 6) //---- GSG (11/03/2014)
                        {
                            cn = cn.Substring(0, 6);
                            item[_iPosCod] = cn;
                        }
                    }


                    if (!GESTCRM.Utiles.MirarSiAbierto(this, "frmPedidos"))
                    {
                        //if (cBoxCampanyas.SelectedValue != null) //---- GSG (03/02/2015)                        
                        //if (cBoxCampanyas.SelectedValue != null || chkBoxFlexible.Checked == true) //---- GSG (28/10/2015)
                        if ((cBoxCampanyas.SelectedValue != null && cBoxCampanyas.Enabled ) || chkBoxFlexible.Checked) //---- GSG (19/08/2018)
                        {
                            // Es posible cargar en campaña flexible si el delegado lo quiere así
                            if (chkBoxFlexible.Checked == true) //---- GSG (28/10/2015)
                                _iIdCampanya = Utiles.CodigoCampanya("Flexible"); 
                            else
                                //---- GSG (26/01/2016)
                                //if (_bEsClienteConAccMark)
                                //---- GSG (05/07/2017)
                                //if (_bEsClienteConAccMark || (chkBoxCampanya.Checked && !chkBoxFlexible.Checked))
                                if (chkBoxCampanya.Checked && !chkBoxFlexible.Checked)
                                    _iIdCampanya = cBoxCampanyas.SelectedValue.ToString();

                            
                            //Carga materiales de la campanya seleccionada
                            this.sqlDaListaMateriales.SelectCommand.Parameters["@iIdCamp"].Value = _iIdCampanya;
                            this.sqlDaListaMateriales.Fill(dsMateriales1.ListaMateriales);

                            //Obtiene los materiales de la carga que no pertenecen a la campaña
                            string matsNoCampanya = MatsNoCampanya();
                            string matsBloqueados = MatsBloqueados(); //---- GSG (08/04/2016)

                            //---- GSG (08/04/2016)
                            //if (matsNoCampanya != "-1" && matsNoCampanya.Trim() != "")
                            if ((matsNoCampanya != "-1" && matsNoCampanya.Trim() != "") || (matsBloqueados != "-1" && matsBloqueados.Trim() != ""))
                            {
                                lblMissNoImportados.Visible = true;
                                textBoxMaterialesNoImportados.Visible = true;
                                //---- GSG (08/04/2016)
                                //textBoxMaterialesNoImportados.Text = matsNoCampanya;
                                if (matsNoCampanya != "-1" && matsNoCampanya.Trim() != "")
                                    textBoxMaterialesNoImportados.Text = matsNoCampanya;
                                if (matsBloqueados != "-1" && matsBloqueados.Trim() != "")
                                    textBoxMaterialesNoImportados.Text += matsBloqueados;
                                                               
                                
                                //btnContinuar.Visible = true; //---- GSG (13/05/2014)
                            }
                            else
                            {
                                lblMissNoImportados.Visible = false;
                                textBoxMaterialesNoImportados.Visible = false;
                                textBoxMaterialesNoImportados.Text = "";
                                //---- GSG (13/05/2014)
                                //btnContinuar.Visible = false;
                                //EnviarMatsAPedido(); 
                            }

                            //---- GSG (13/05/2014)
                            //También mostraremos los materiales que no tienen stock aunque estos sí se importarán

                            string matsSinStock = MatsSinStock();


                            //---- GSG (02/02/2021)
                            // Para evitar confusión en la interpretación de los mensajes, si un material sin stock también está en los bloqueados, no ponerlo en este segundo mensaje ya que no se importará por estar en el primero
                            string nuevaCadenamatsSinStock = "";

                            if (matsSinStock != "-1" && matsSinStock.Trim() != "")
                            {
                                string[] lMatsSinStock = matsSinStock.Split('\n');
                                string auxi = "";

                                foreach (string s in lMatsSinStock)
                                {
                                    if (s.Length > 0)
                                    {
                                        auxi = s.Substring(0, s.IndexOf('\t'));

                                        if (!matsNoCampanya.Contains(auxi) && !matsBloqueados.Contains(auxi))
                                        {
                                            nuevaCadenamatsSinStock += (s + "\n");
                                        }
                                    }
                                }
                            }

                            matsSinStock = nuevaCadenamatsSinStock;
                            //---- FI GSG

                            if (matsSinStock != "-1" && matsSinStock.Trim() != "")
                            {
                                lblMissSinStock.Visible = true;
                                textBoxMaterialesSinStock.Visible = true;
                                textBoxMaterialesSinStock.Text = matsSinStock;
                            }
                            else
                            {
                                lblMissSinStock.Visible = false;
                                textBoxMaterialesSinStock.Visible = false;
                                textBoxMaterialesSinStock.Text = "";
                            }

                            // Si no hay mensaje no esperar al botón para cargar
                            //---- GSG (25/06/2021)
                            //if ((matsNoCampanya == "-1" || matsNoCampanya.Trim() == "") && (matsSinStock == "-1" || matsSinStock.Trim() == ""))
                            if ((matsNoCampanya == "-1" || matsNoCampanya.Trim() == "") && (matsSinStock == "-1" || matsSinStock.Trim() == "") && (matsBloqueados == "-1" || matsBloqueados.Trim() == ""))
                            {
                                btnContinuar.Visible = false;
                                EnviarMatsAPedido();
                            }
                            else
                                btnContinuar.Visible = true;


                        }
                        else //---- GSG (03/02/2015)
                        {
                            Mensajes.ShowExclamation("No hay campañas para este tipo de pedido. El pedido no se cargará.");
                            textBoxMaterialesSinStock.Text = "";
                            textBoxMaterialesNoImportados.Text = "";
                        }

                    }
                    else
                    {
                        DialogResult dr = Mensajes.ShowQuestion("No se puede crear un Pedido porque ya hay uno abierto. ¿Desea ver el Pedido abierto?");
                        if (dr == DialogResult.Yes)
                        {
                            GESTCRM.Utiles.ActivaFormularioAbierto(this, "frmPedidos");
                        }
                    }
                }
            }
            else if (fitxer.Trim() == "" || fitxer == null )
                Mensajes.ShowError("No ha seleccionado el archivo.");
            else if (_sIdCliente == null || _sIdCliente.Trim() == "")
                Mensajes.ShowError("No ha seleccionado el cliente.");
            //---- GSG (19/08/2019)
            else if (!(cBoxCampanyas.Enabled || chkBoxFlexible.Checked))
                Mensajes.ShowError("No ha seleccionado ninguna campaña.");
        }


        private string MatsNoCampanya()
        {
            string sRet = "";
            string sFilter = "";
            bool bEsPrimeraLinea = true; //Para saltar la cabecera del fichero
            string sDescMat = "";

            foreach (string[] item in _carga)
            {
                if (!bEsPrimeraLinea)
                {
                    sFilter = "sCodNacional = '" + item[_iPosCod] + "'";
                    DataRow[] rows = dsMateriales1.ListaMateriales.Select(sFilter);
                    if (rows.Length == 0)
                    {
                        sDescMat = GetDescripcionMaterial(item[_iPosCod]);

                        sRet += item[_iPosCod] + "\t" + sDescMat + " ".PadRight(50 - sDescMat.Length) + "\t" + item[_iPosUni].ToString().PadLeft(4, ' ') + " Unid.\r\n";
                    }
                }

                bEsPrimeraLinea = false;
            }


            return sRet;
        }


        //---- GSG (08/04/2016)
        private string MatsBloqueados()
        {
            string sRet = "";
            string sFilter = "";
            bool bEsPrimeraLinea = true; //Para saltar la cabecera del fichero
            string sDescMat = "";

            string[] bloqueados = new string[2000];


            //---- GSG (15/11/2020)
            //-- Esto ya no es así 
            //bloqueados = GetMaterialesBloqueados("ZDIR"); //Al importar siempre lo hacemos a directo
            string IdTipoPedido = "ZDIR";
            if (cboTipoPedido.SelectedValue != null)
                IdTipoPedido = cboTipoPedido.SelectedValue.ToString();
            bloqueados = GetMaterialesBloqueados(IdTipoPedido);
            //--- FI GSG


            if (bloqueados.Length > 0)
            {
                foreach (string[] item in _carga)
                {
                    if (!bEsPrimeraLinea)
                    {
                        sFilter = "sCodNacional = '" + item[_iPosCod] + "'";
                        DataRow[] rows = dsMateriales1.ListaMateriales.Select(sFilter);
                        if (rows.Length != 0)
                        {
                            if (Comun.IsInTheArray(rows[0]["sIdMaterial"].ToString(), bloqueados))
                            {
                                sDescMat = GetDescripcionMaterial(item[_iPosCod]);
                                sRet += item[_iPosCod] + "\t" + sDescMat + " ".PadRight(50 - sDescMat.Length) + "\t" + item[_iPosUni].ToString().PadLeft(4, ' ') + " Unid.\r\n";
                            }
                        }
                    }

                    bEsPrimeraLinea = false;
                }
            }

            return sRet;
        }

        //---- GSG (08/04/2016)
        private string[] GetMaterialesBloqueados(string psTipoPedido)
        {
            string[] aRet = null;

            this.dsMateriales1.ListaMaterialesBloqueados.Rows.Clear();

            if (sqlConn.State == ConnectionState.Closed)
                this.sqlConn.Open();

            SqlTransaction sqlTran = this.sqlConn.BeginTransaction();
            this.sqlCmdListaMaterialesBloqueados.Transaction = sqlTran;

            try
            {

                //---- GSG CECL 29/06/2016
                if (System.Configuration.ConfigurationManager.AppSettings["TipoDelegadoPedidosCentral"].ToString() == Comun.K_CECL)
                    sqldaListaMaterialesBloqueados.SelectCommand.CommandText = "[ListaMaterialesBloqueadosCECL]";
                else
                    sqldaListaMaterialesBloqueados.SelectCommand.CommandText = "[ListaMaterialesBloqueados]";
                //---- FI GSG CECL



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


        // Si existe en Stada retorna la descripción del material
        // Si no existe retorna ""
        private string GetDescripcionMaterial(string sCodNacional)
        {
            string sRet = "";

            if (sqlConn.State == ConnectionState.Closed)
                this.sqlConn.Open();

            SqlTransaction sqlTran = this.sqlConn.BeginTransaction();

            this.sqlGetDescripcionMat.Transaction = sqlTran;

            try
			{
                this.sqlGetDescripcionMat.Parameters["@sCodNacional"].Value = sCodNacional;
                this.sqlGetDescripcionMat.ExecuteNonQuery();

                sRet = this.sqlGetDescripcionMat.Parameters["@Ret"].Value.ToString();

                if (sRet == "-1")
                    sRet = "";
            }
            catch (Exception e)
            {
                Mensajes.ShowError(e.Message);
            }


            this.sqlConn.Close();

            return sRet;
        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            EnviarMatsAPedido();
        }


        private void EnviarMatsAPedido()
        {
            //---- GSG (12/12/2014)
            //frmPedidos frmTemp = new Formularios.frmPedidos(_sIdCliente, _iIdCliente, _sNombreCliente, _iIdCampanya);
            string IdTipoPedido = "ZDIR";
            if (cboTipoPedido.SelectedValue != null)
                IdTipoPedido = cboTipoPedido.SelectedValue.ToString();
            frmPedidos frmTemp = new Formularios.frmPedidos(_sIdCliente, _iIdCliente, _sNombreCliente, _iIdCampanya, IdTipoPedido);
            
            
            frmTemp.MdiParent = this.MdiParent;
            frmTemp.Show();

            this.Close();

            if (frmTemp.cBoxCampanyas.SelectedIndex != -1) //---- GSG (04/07/2014)
            {
                //Abrir pantalla selección de materiales     
                DataRowView rowView;

                //---- GSG (05/07/2017)
                /*
                if (_bEsClienteConAccMark)
                {
                    //---- GSG (06/08/2014)
                    dsFormularios1.ListaCampanyasAux.DefaultView.RowFilter = "bSeleccionable = 1";
                    dsFormularios1.ListaCampanyasAux.DefaultView.Sort = "NombreCampanya";
                    cBoxCampanyas.DataSource = dsFormularios1.ListaCampanyasAux.DefaultView;
                    //---- FI GSG
                    rowView = dsFormularios1.ListaCampanyasAux.DefaultView[frmTemp.cBoxCampanyas.SelectedIndex];
                }
                else
                {
                    //---- GSG (06/08/2014)
                    dsFormularios1.ListaCampanyas.DefaultView.RowFilter = "bSeleccionable = 1";
                    dsFormularios1.ListaCampanyas.DefaultView.Sort = "NombreCampanya";
                    cBoxCampanyas.DataSource = dsFormularios1.ListaCampanyas.DefaultView;
                    //---- FI GSG
                    rowView = dsFormularios1.ListaCampanyas.DefaultView[frmTemp.cBoxCampanyas.SelectedIndex];
                }
                */

                dsFormularios1.ListaCampanyas.DefaultView.Sort = "NombreCampanya";
                cBoxCampanyas.DataSource = dsFormularios1.ListaCampanyas.DefaultView;
                rowView = dsFormularios1.ListaCampanyas.DefaultView[frmTemp.cBoxCampanyas.SelectedIndex];


                //---- GSG (21/01/2014)
                //frmTemp.BuscarMateriales(rowView.Row, _carga, _iPosCod, _iPosUni);
                //---- GSG (15/06/2016) si carga descuentos lo trataremos como si fuera propuesta en la pantalla de materiales
                //frmTemp.BuscarMateriales(rowView.Row, _carga, _iPosCod, _iPosUni, -1);
                //---- GSG (19/08/2019) para poder importar con descuentos a cualquier campaña
                //if (chkBoxDescuentos.Checked && chkBoxFlexible.Checked)
                if (chkBoxDescuentos.Checked)
                    frmTemp.BuscarMateriales(rowView.Row, _carga, _iPosCod, _iPosUni, 2); // En este caso el descuento va en la columna 2
                else
                    frmTemp.BuscarMateriales(rowView.Row, _carga, _iPosCod, _iPosUni, -1);
            }
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
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


        //---- GSG (05/07/2017)
        
        /*private bool FormatBuscarCampanyas(int cliente, bool activo)
        {
            bool bEsClienteConAccMark_Ant = _bEsClienteConAccMark;
            bool bRet = false;

            _bEsClienteConAccMark = false;
            cBoxCampanyas.Enabled = false;
            cBoxCampanyas.Visible = false;
            lblComboC.Visible = false;
            //---- GSG (12/12/2014)
            //lblTipoPedido.Visible = false; //---- GSG (11/10/2016)

 
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
                    cBoxCampanyas.Enabled = true;
                    cBoxCampanyas.Visible = true;
                    lblComboC.Visible = true;                    
                    //---- GSG (12/12/2014)
                    lblTipoPedido.Visible = true;
                    cboTipoPedido.Enabled = true;
                    cboTipoPedido.Visible = true;


                    // Para tener la lista igual que en el formulario de pedidos. Aquí la lista no tiene las campanyas extras y no cuadran los índices
                    llenarCampanyasAux(1, campanyas);
                }
                else
                    LlenarComboCampanyas(2, "-1");

            }
            else
                LlenarComboCampanyas(2, "-1");


            if (bEsClienteConAccMark_Ant != _bEsClienteConAccMark)
                bRet = true;


            return bRet;
        }
        */

        

/*

        //---- GSG (09/01/2014)

        private void LlenarComboCampanyas(int tipo, string campanya)
        {
            dsFormularios1.ListaCampanyas.Clear();

            sqldaListaCampanyas.SelectCommand.Parameters["@iTipo"].Value = tipo;
            sqldaListaCampanyas.SelectCommand.Parameters["@idCampanya"].Value = campanya;

            //---- GSG (19/11/2013)
            sqldaListaCampanyas.SelectCommand.Parameters["@tipoCampanya"].Value = K_LIN;
            sqldaListaCampanyas.SelectCommand.Parameters["@sIdDelegado"].Value = Clases.Configuracion.iIdDelegado.ToString();
            //---- GSG (12/12/2014)
            //sqldaListaCampanyas.SelectCommand.Parameters["@sIdTipoPedido"].Value = "ZDIR";
            if (cboTipoPedido.SelectedValue == null)
                sqldaListaCampanyas.SelectCommand.Parameters["@sIdTipoPedido"].Value = "ZDIR";
            else
                sqldaListaCampanyas.SelectCommand.Parameters["@sIdTipoPedido"].Value = cboTipoPedido.SelectedValue.ToString();
            //---- FI GSG

            sqldaListaCampanyas.Fill(dsFormularios1.ListaCampanyas);
            dsFormularios1.ListaCampanyas.DefaultView.RowFilter = "bSeleccionable = 1";
            dsFormularios1.ListaCampanyas.DefaultView.Sort = "NombreCampanya"; //---- GSG (14/07/2014)
            cBoxCampanyas.DataSource = dsFormularios1.ListaCampanyas.DefaultView;
        }


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
                //---- GSG (12/12/2014)
                //sqldaListaCampanyas.SelectCommand.Parameters["@sIdTipoPedido"].Value = "ZDIR";
                if (cboTipoPedido.SelectedValue == null)
                    sqldaListaCampanyas.SelectCommand.Parameters["@sIdTipoPedido"].Value = "ZDIR";
                else
                    sqldaListaCampanyas.SelectCommand.Parameters["@sIdTipoPedido"].Value = cboTipoPedido.SelectedValue.ToString();                
                //---- FI GSG

                sqldaListaCampanyas.Fill(dsFormularios1.ListaCampanyas);

                //cambio el tipo para que no rpite las campanyas extras
                tipo = 3;

            }

            dsFormularios1.ListaCampanyas.DefaultView.RowFilter = "bSeleccionable = 1";
            dsFormularios1.ListaCampanyas.DefaultView.Sort = "NombreCampanya"; //---- GSG (14/07/2014)
            cBoxCampanyas.DataSource = dsFormularios1.ListaCampanyas.DefaultView;
        }


        
*/

        private bool FormatBuscarCampanyas(int cliente, bool activo, string tipoPed, string mayorista)
        {
            bool bRet = false;
            bool bConCampanyas = true;

            if (!Comun.IsInTheArray(cboTipoPedido.SelectedValue.ToString(), Configuracion.asPedTransfer) || mayorista == "")
                mayorista = "XXXX";


            bConCampanyas = LlenarComboCampanyas(_iIdDelegado.ToString(), tipoPed, cliente, mayorista);

            if (bConCampanyas)
            {
                cBoxCampanyas.Enabled = activo;
                //---- GSG (19/08/2019) para poder importar con descuentos a cualquier campaña
                chkBoxCampanya.Checked = activo;
            }
            else
            {
                cBoxCampanyas.Enabled = false;
                //---- GSG (19/08/2019) para poder importar con descuentos a cualquier campaña
                chkBoxCampanya.Checked = false;
            }

            if (cBoxCampanyas.FindStringExact("FLEXIBLE") == -1)
                this.chkBoxFlexible.Visible = false;
            else
                this.chkBoxFlexible.Visible = true;


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
                Mensajes.ShowExclamation("No hay campañas disponibles para este pedido.");
                bRet = false;
            }

            return bRet;
        }

        //---- FI GSG



        private void cBoxCampanyas_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (_bEsClienteConAccMark) ---- GSG (05/07/2017)
                _iIdCampanya = cBoxCampanyas.SelectedValue.ToString();
        }


        //---- GSG (05/07/2017)
        /*private void llenarCampanyasAux(int tipo, string[] campanyas)
        {
            dsFormularios1.ListaCampanyasAux.Clear();

            for (int i = 0; i < campanyas.Length; i++)
            {
                sqldaListaCampanyas.SelectCommand.Parameters["@iTipo"].Value = tipo;
                sqldaListaCampanyas.SelectCommand.Parameters["@idCampanya"].Value = campanyas[i];

                sqldaListaCampanyas.Fill(dsFormularios1.ListaCampanyasAux);

                //cambio el tipo para que no rpite las campanyas extras
                tipo = 3;
            }

            dsFormularios1.ListaCampanyasAux.DefaultView.RowFilter = "bSeleccionable = 1";
        }
        */


        private void frmImportarPedido_SizeChanged(object sender, EventArgs e)
        {
            posicionar();
        }


        //---- GSG (13/15/2014)
        private string MatsSinStock()
        {
            string sRet = "";
            string sFilter = "";
            bool bEsPrimeraLinea = true; //Para saltar la cabecera del fichero
            string sDescMat = "";

            foreach (string[] item in _carga)
            {
                if (!bEsPrimeraLinea)
                {
                    sFilter = "sCodNacional = '" + item[_iPosCod] + "'";
                    DataRow[] rows = dsMateriales1.ListaMateriales.Select(sFilter);
                    if (rows.Length > 0)
                    {
                        int unidadesPedidas = int.Parse(item[_iPosUni].ToString().Replace(".",""));
                        //---- GSG (12/12/2014)
                        //int unidadesDisponibles = int.Parse(rows[0]["iStock"].ToString()) - int.Parse(rows[0]["iPendientes"].ToString());
                        int unidadesDisponibles = 0;
                        int stock = 0;
                        int pendientes = 0;
                        if (_bCanario)
                        {
                            if (rows[0]["iStockCanarias"] != null)
                                stock = int.Parse(rows[0]["iStockCanarias"].ToString());
                            if (rows[0]["iPendientesCanarias"] != null)
                                pendientes = int.Parse(rows[0]["iPendientesCanarias"].ToString());
                        }
                        else
                        {
                            if (rows[0]["iStock"] != null)
                                stock = int.Parse(rows[0]["iStock"].ToString());
                            if (rows[0]["iPendientes"] != null)
                                pendientes = int.Parse(rows[0]["iPendientes"].ToString());
                        }

                        unidadesDisponibles = stock - pendientes;
                        //---- FI GSG

                        if (unidadesPedidas > unidadesDisponibles || unidadesDisponibles <= 0)
                        {
                            sDescMat = GetDescripcionMaterial(item[_iPosCod]);

                            sRet += item[_iPosCod] + "\t" + sDescMat + " ".PadRight(50 - sDescMat.Length) + "    " + item[_iPosUni].ToString().PadLeft(4, ' ') + " Unid.     " + unidadesDisponibles.ToString().PadLeft(4, ' ') + " Unid. disp.\r\n";
                        }
                    }
                }

                bEsPrimeraLinea = false;
            }


            return sRet;
        }



        //---- GSG (12/12/2014)
        private void cboTipoPedido_SelectedIndexChanged(object sender, EventArgs e)
        {
            //---- GSG (05/07/2017)
            //FormatBuscarCampanyas(_iIdCliente, true);
            FormatBuscarCampanyas(_iIdCliente, true, cboTipoPedido.SelectedValue.ToString(), "XXXX");

        }


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


        //---- GSG (26/01/2016)
        private void chkBoxCampanya_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBoxCampanya.Checked)
            {
                //---- GSG (19/08/2019) para poder importar con descuentos a cualquier campaña
                //lblComboC.Visible = true;
                //cBoxCampanyas.Visible = true;
                



                if (chkBoxFlexible.Checked)
                    cBoxCampanyas.Enabled = false;
                else
                    cBoxCampanyas.Enabled = true;


            }
            else 
            {
                //---- GSG (19/08/2019) para poder importar con descuentos a cualquier campaña
                //lblComboC.Visible = false;
                //cBoxCampanyas.Visible = false;
                cBoxCampanyas.Enabled = false;
            }
        }

        private void chkBoxFlexible_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBoxFlexible.Checked)
            {
                cBoxCampanyas.Enabled = false;
                chkBoxCampanya.Checked = false; //---- GSG (19/08/2019)
            }
            else if (chkBoxCampanya.Checked)
                cBoxCampanyas.Enabled = true;
            else
            {
                cBoxCampanyas.Enabled = false;
                chkBoxCampanya.Checked = false; //---- GSG (19/08/2019)
            }
        }

        //---- GSG (15/06/2016)
        private void chkBoxDescuentos_CheckedChanged(object sender, EventArgs e)
        {
            //---- GSG (19/08/2019) para poder importar con descuentos a cualquier campaña
            //if (chkBoxDescuentos.Checked)
            //    chkBoxFlexible.Checked = true;
        }

        //---- GSG (11/10/2016)
        private void chkBoxTipoPedido_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBoxTipoPedido.Checked)
            {
                cboTipoPedido.Enabled = true;
                cboTipoPedido.Visible = true;
                lblTipoPedido.Visible = true;
            }
            else
            {
                cboTipoPedido.Enabled = false;
                cboTipoPedido.Visible = false;
                lblTipoPedido.Visible = false;
            }
        }
    }
}
