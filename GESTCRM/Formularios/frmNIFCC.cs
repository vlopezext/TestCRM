//---- GSG 2011
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GESTCRM.Clases;

namespace GESTCRM.Formularios
{
    public partial class frmNIFCC : Form
    {
        private System.Data.SqlClient.SqlCommand sqlCmdSetContactosClientesSAP;
        private System.Data.SqlClient.SqlCommand sqlCmdGetClientesSAP;
        private System.Data.SqlClient.SqlCommand sqlCmdListaContactosClientes_SAP;
        private System.Data.SqlClient.SqlConnection sqlConn;
        private int clientSAP;
        private string NIF;
        private string CC;
        private string SWIFT;
        private string sTipoPedido;
        private bool sortidaCreu = true;
        private bool transferJaEraOK = false;
        private bool esAndorrano = false; //---- GSG (10/10/2014)
        //////private bool DirCliNotLikeDest = false; //---- GSG (25/11/2014)
        private string _sCondPago = ""; //---- GSG (26/11/2014)

        //---- GSG (10/10/2014)
        //public frmNIFCC(int iIdCliente, string tipoPedido, string psNif, string psCC)
        //public frmNIFCC(int iIdCliente, string tipoPedido, string psNif, string psCC, string psSWIFT, bool bEsAndorrano)
        //////public frmNIFCC(int iIdCliente, string tipoPedido, string psNif, string psCC, string psSWIFT, bool bEsAndorrano, int iIdDestinatario)
        public frmNIFCC(int iIdCliente, string tipoPedido, string psNif, string psCC, string psSWIFT, bool bEsAndorrano, string sCondPago)
        {
            InitializeComponent();


            //---- GSG (06/03/2021)
            Utiles.GetConfigConnection();
            this.sqlConn.ConnectionString = Utiles._connection.ConnectionString.ToString();

            clientSAP = iIdCliente;
            NIF = psNif;
            CC = psCC;
            sTipoPedido = tipoPedido;
            esAndorrano = bEsAndorrano;
            SWIFT = psSWIFT;
            _sCondPago = sCondPago;

            
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNIFCC));
            System.Configuration.AppSettingsReader configurationAppSettings = new System.Configuration.AppSettingsReader();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.txbCC = new System.Windows.Forms.TextBox();
            this.txbNIF = new System.Windows.Forms.TextBox();
            this.lblCuenta = new System.Windows.Forms.Label();
            this.lblNIF = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txbEntidad = new System.Windows.Forms.TextBox();
            this.txbOficina = new System.Windows.Forms.TextBox();
            this.txbControl = new System.Windows.Forms.TextBox();
            this.lblEntidad = new System.Windows.Forms.Label();
            this.lblOficina = new System.Windows.Forms.Label();
            this.lblControl = new System.Windows.Forms.Label();
            this.lblCC = new System.Windows.Forms.Label();
            this.lblGuio1 = new System.Windows.Forms.Label();
            this.lblGuio2 = new System.Windows.Forms.Label();
            this.sqlConn = new System.Data.SqlClient.SqlConnection();
            this.sqlCmdSetContactosClientesSAP = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdGetClientesSAP = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdListaContactosClientes_SAP = new System.Data.SqlClient.SqlCommand();
            this.lblCuentaAnd = new System.Windows.Forms.Label();
            this.txbCCAndorra = new System.Windows.Forms.TextBox();
            this.txbIBAN = new System.Windows.Forms.TextBox();
            this.lblIBAN = new System.Windows.Forms.Label();
            this.lblSWIFT = new System.Windows.Forms.Label();
            this.lblSBanco = new System.Windows.Forms.Label();
            this.lblSLocalidad = new System.Windows.Forms.Label();
            this.lblSOficina = new System.Windows.Forms.Label();
            this.lblSPais = new System.Windows.Forms.Label();
            this.txbSBanco = new System.Windows.Forms.TextBox();
            this.txbSLocalidad = new System.Windows.Forms.TextBox();
            this.txbSOficina = new System.Windows.Forms.TextBox();
            this.txbSPais = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = global::GESTCRM.Properties.Resources.cancel_032x032;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(382, 371);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(118, 45);
            this.btnCancelar.TabIndex = 13;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.Image = ((System.Drawing.Image)(resources.GetObject("btnGrabar.Image")));
            this.btnGrabar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGrabar.Location = new System.Drawing.Point(237, 371);
            this.btnGrabar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(118, 45);
            this.btnGrabar.TabIndex = 12;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // txbCC
            // 
            this.txbCC.Enabled = false;
            this.txbCC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbCC.Location = new System.Drawing.Point(516, 171);
            this.txbCC.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txbCC.MaxLength = 10;
            this.txbCC.Name = "txbCC";
            this.txbCC.Size = new System.Drawing.Size(172, 26);
            this.txbCC.TabIndex = 6;
            // 
            // txbNIF
            // 
            this.txbNIF.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbNIF.Location = new System.Drawing.Point(188, 92);
            this.txbNIF.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txbNIF.Name = "txbNIF";
            this.txbNIF.Size = new System.Drawing.Size(266, 26);
            this.txbNIF.TabIndex = 1;
            // 
            // lblCuenta
            // 
            this.lblCuenta.AutoSize = true;
            this.lblCuenta.BackColor = System.Drawing.Color.Transparent;
            this.lblCuenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCuenta.Location = new System.Drawing.Point(39, 171);
            this.lblCuenta.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCuenta.Name = "lblCuenta";
            this.lblCuenta.Size = new System.Drawing.Size(38, 20);
            this.lblCuenta.TabIndex = 12;
            this.lblCuenta.Text = "CC:";
            // 
            // lblNIF
            // 
            this.lblNIF.AutoSize = true;
            this.lblNIF.BackColor = System.Drawing.Color.Transparent;
            this.lblNIF.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNIF.Location = new System.Drawing.Point(36, 97);
            this.lblNIF.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNIF.Name = "lblNIF";
            this.lblNIF.Size = new System.Drawing.Size(112, 20);
            this.lblNIF.TabIndex = 10;
            this.lblNIF.Text = "NIF/CIF/NIE:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(30, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(428, 20);
            this.label1.TabIndex = 14;
            this.label1.Text = "Introduzca la identificación y los datos bancarios del cliente:";
            // 
            // txbEntidad
            // 
            this.txbEntidad.Enabled = false;
            this.txbEntidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbEntidad.Location = new System.Drawing.Point(272, 171);
            this.txbEntidad.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txbEntidad.MaxLength = 4;
            this.txbEntidad.Name = "txbEntidad";
            this.txbEntidad.Size = new System.Drawing.Size(72, 26);
            this.txbEntidad.TabIndex = 3;
            // 
            // txbOficina
            // 
            this.txbOficina.Enabled = false;
            this.txbOficina.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbOficina.Location = new System.Drawing.Point(352, 171);
            this.txbOficina.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txbOficina.MaxLength = 4;
            this.txbOficina.Name = "txbOficina";
            this.txbOficina.Size = new System.Drawing.Size(72, 26);
            this.txbOficina.TabIndex = 4;
            // 
            // txbControl
            // 
            this.txbControl.Enabled = false;
            this.txbControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbControl.Location = new System.Drawing.Point(446, 171);
            this.txbControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txbControl.MaxLength = 2;
            this.txbControl.Name = "txbControl";
            this.txbControl.Size = new System.Drawing.Size(46, 26);
            this.txbControl.TabIndex = 5;
            // 
            // lblEntidad
            // 
            this.lblEntidad.AutoSize = true;
            this.lblEntidad.BackColor = System.Drawing.Color.Transparent;
            this.lblEntidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEntidad.Location = new System.Drawing.Point(278, 149);
            this.lblEntidad.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEntidad.Name = "lblEntidad";
            this.lblEntidad.Size = new System.Drawing.Size(57, 18);
            this.lblEntidad.TabIndex = 18;
            this.lblEntidad.Text = "Entidad";
            // 
            // lblOficina
            // 
            this.lblOficina.AutoSize = true;
            this.lblOficina.BackColor = System.Drawing.Color.Transparent;
            this.lblOficina.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOficina.Location = new System.Drawing.Point(361, 149);
            this.lblOficina.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOficina.Name = "lblOficina";
            this.lblOficina.Size = new System.Drawing.Size(54, 18);
            this.lblOficina.TabIndex = 19;
            this.lblOficina.Text = "Oficina";
            // 
            // lblControl
            // 
            this.lblControl.AutoSize = true;
            this.lblControl.BackColor = System.Drawing.Color.Transparent;
            this.lblControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblControl.Location = new System.Drawing.Point(441, 149);
            this.lblControl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblControl.Name = "lblControl";
            this.lblControl.Size = new System.Drawing.Size(61, 18);
            this.lblControl.TabIndex = 20;
            this.lblControl.Text = "Dig.Ctrl.";
            // 
            // lblCC
            // 
            this.lblCC.AutoSize = true;
            this.lblCC.BackColor = System.Drawing.Color.Transparent;
            this.lblCC.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCC.Location = new System.Drawing.Point(534, 149);
            this.lblCC.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCC.Name = "lblCC";
            this.lblCC.Size = new System.Drawing.Size(130, 18);
            this.lblCC.TabIndex = 21;
            this.lblCC.Text = "Número de cuenta";
            // 
            // lblGuio1
            // 
            this.lblGuio1.AutoSize = true;
            this.lblGuio1.BackColor = System.Drawing.Color.Transparent;
            this.lblGuio1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGuio1.Location = new System.Drawing.Point(428, 175);
            this.lblGuio1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGuio1.Name = "lblGuio1";
            this.lblGuio1.Size = new System.Drawing.Size(12, 16);
            this.lblGuio1.TabIndex = 22;
            this.lblGuio1.Text = "-";
            // 
            // lblGuio2
            // 
            this.lblGuio2.AutoSize = true;
            this.lblGuio2.BackColor = System.Drawing.Color.Transparent;
            this.lblGuio2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGuio2.Location = new System.Drawing.Point(498, 175);
            this.lblGuio2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGuio2.Name = "lblGuio2";
            this.lblGuio2.Size = new System.Drawing.Size(12, 16);
            this.lblGuio2.TabIndex = 23;
            this.lblGuio2.Text = "-";
            // 
            // sqlConn
            // 
            this.sqlConn.ConnectionString = Utiles._connection.ConnectionString.ToString();   //---- GSG (06/03/2021)
            this.sqlConn.FireInfoMessageEventOnUserErrors = false;
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
            // sqlCmdGetClientesSAP
            // 
            this.sqlCmdGetClientesSAP.CommandText = "[GetCliente_SAP]";
            this.sqlCmdGetClientesSAP.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdGetClientesSAP.Connection = this.sqlConn;
            this.sqlCmdGetClientesSAP.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4)});
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
            // lblCuentaAnd
            // 
            this.lblCuentaAnd.AutoSize = true;
            this.lblCuentaAnd.BackColor = System.Drawing.Color.Transparent;
            this.lblCuentaAnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCuentaAnd.Location = new System.Drawing.Point(39, 195);
            this.lblCuentaAnd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCuentaAnd.Name = "lblCuentaAnd";
            this.lblCuentaAnd.Size = new System.Drawing.Size(38, 20);
            this.lblCuentaAnd.TabIndex = 24;
            this.lblCuentaAnd.Text = "CC:";
            // 
            // txbCCAndorra
            // 
            this.txbCCAndorra.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbCCAndorra.Location = new System.Drawing.Point(188, 186);
            this.txbCCAndorra.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txbCCAndorra.Name = "txbCCAndorra";
            this.txbCCAndorra.Size = new System.Drawing.Size(498, 26);
            this.txbCCAndorra.TabIndex = 7;
            // 
            // txbIBAN
            // 
            this.txbIBAN.Enabled = false;
            this.txbIBAN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbIBAN.Location = new System.Drawing.Point(188, 171);
            this.txbIBAN.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txbIBAN.MaxLength = 4;
            this.txbIBAN.Name = "txbIBAN";
            this.txbIBAN.Size = new System.Drawing.Size(72, 26);
            this.txbIBAN.TabIndex = 2;
            // 
            // lblIBAN
            // 
            this.lblIBAN.AutoSize = true;
            this.lblIBAN.BackColor = System.Drawing.Color.Transparent;
            this.lblIBAN.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIBAN.Location = new System.Drawing.Point(200, 149);
            this.lblIBAN.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIBAN.Name = "lblIBAN";
            this.lblIBAN.Size = new System.Drawing.Size(41, 18);
            this.lblIBAN.TabIndex = 27;
            this.lblIBAN.Text = "IBAN";
            // 
            // lblSWIFT
            // 
            this.lblSWIFT.AutoSize = true;
            this.lblSWIFT.BackColor = System.Drawing.Color.Transparent;
            this.lblSWIFT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSWIFT.Location = new System.Drawing.Point(39, 265);
            this.lblSWIFT.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSWIFT.Name = "lblSWIFT";
            this.lblSWIFT.Size = new System.Drawing.Size(69, 20);
            this.lblSWIFT.TabIndex = 28;
            this.lblSWIFT.Text = "SWIFT:";
            this.lblSWIFT.Visible = false;
            // 
            // lblSBanco
            // 
            this.lblSBanco.AutoSize = true;
            this.lblSBanco.BackColor = System.Drawing.Color.Transparent;
            this.lblSBanco.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSBanco.Location = new System.Drawing.Point(197, 256);
            this.lblSBanco.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSBanco.Name = "lblSBanco";
            this.lblSBanco.Size = new System.Drawing.Size(51, 18);
            this.lblSBanco.TabIndex = 32;
            this.lblSBanco.Text = "Banco";
            this.lblSBanco.Visible = false;
            // 
            // lblSLocalidad
            // 
            this.lblSLocalidad.AutoSize = true;
            this.lblSLocalidad.BackColor = System.Drawing.Color.Transparent;
            this.lblSLocalidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSLocalidad.Location = new System.Drawing.Point(334, 256);
            this.lblSLocalidad.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSLocalidad.Name = "lblSLocalidad";
            this.lblSLocalidad.Size = new System.Drawing.Size(71, 18);
            this.lblSLocalidad.TabIndex = 31;
            this.lblSLocalidad.Text = "Localidad";
            this.lblSLocalidad.Visible = false;
            // 
            // lblSOficina
            // 
            this.lblSOficina.AutoSize = true;
            this.lblSOficina.BackColor = System.Drawing.Color.Transparent;
            this.lblSOficina.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSOficina.Location = new System.Drawing.Point(425, 256);
            this.lblSOficina.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSOficina.Name = "lblSOficina";
            this.lblSOficina.Size = new System.Drawing.Size(54, 18);
            this.lblSOficina.TabIndex = 30;
            this.lblSOficina.Text = "Oficina";
            this.lblSOficina.Visible = false;
            // 
            // lblSPais
            // 
            this.lblSPais.AutoSize = true;
            this.lblSPais.BackColor = System.Drawing.Color.Transparent;
            this.lblSPais.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSPais.Location = new System.Drawing.Point(277, 256);
            this.lblSPais.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSPais.Name = "lblSPais";
            this.lblSPais.Size = new System.Drawing.Size(37, 18);
            this.lblSPais.TabIndex = 29;
            this.lblSPais.Text = "País";
            this.lblSPais.Visible = false;
            // 
            // txbSBanco
            // 
            this.txbSBanco.Enabled = false;
            this.txbSBanco.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbSBanco.Location = new System.Drawing.Point(188, 278);
            this.txbSBanco.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txbSBanco.MaxLength = 4;
            this.txbSBanco.Name = "txbSBanco";
            this.txbSBanco.Size = new System.Drawing.Size(72, 26);
            this.txbSBanco.TabIndex = 8;
            this.txbSBanco.Visible = false;
            // 
            // txbSLocalidad
            // 
            this.txbSLocalidad.Enabled = false;
            this.txbSLocalidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbSLocalidad.Location = new System.Drawing.Point(344, 278);
            this.txbSLocalidad.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txbSLocalidad.MaxLength = 2;
            this.txbSLocalidad.Name = "txbSLocalidad";
            this.txbSLocalidad.Size = new System.Drawing.Size(49, 26);
            this.txbSLocalidad.TabIndex = 10;
            this.txbSLocalidad.Visible = false;
            // 
            // txbSOficina
            // 
            this.txbSOficina.Enabled = false;
            this.txbSOficina.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbSOficina.Location = new System.Drawing.Point(418, 278);
            this.txbSOficina.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txbSOficina.MaxLength = 3;
            this.txbSOficina.Name = "txbSOficina";
            this.txbSOficina.Size = new System.Drawing.Size(67, 26);
            this.txbSOficina.TabIndex = 11;
            this.txbSOficina.Visible = false;
            // 
            // txbSPais
            // 
            this.txbSPais.Enabled = false;
            this.txbSPais.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbSPais.Location = new System.Drawing.Point(272, 278);
            this.txbSPais.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txbSPais.MaxLength = 2;
            this.txbSPais.Name = "txbSPais";
            this.txbSPais.Size = new System.Drawing.Size(46, 26);
            this.txbSPais.TabIndex = 9;
            this.txbSPais.Visible = false;
            // 
            // frmNIFCC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.ClientSize = new System.Drawing.Size(736, 471);
            this.Controls.Add(this.txbSPais);
            this.Controls.Add(this.txbSOficina);
            this.Controls.Add(this.txbSLocalidad);
            this.Controls.Add(this.txbSBanco);
            this.Controls.Add(this.lblSBanco);
            this.Controls.Add(this.lblSLocalidad);
            this.Controls.Add(this.lblSOficina);
            this.Controls.Add(this.lblSPais);
            this.Controls.Add(this.lblSWIFT);
            this.Controls.Add(this.lblIBAN);
            this.Controls.Add(this.txbIBAN);
            this.Controls.Add(this.txbCCAndorra);
            this.Controls.Add(this.lblCuentaAnd);
            this.Controls.Add(this.lblGuio2);
            this.Controls.Add(this.lblGuio1);
            this.Controls.Add(this.lblCC);
            this.Controls.Add(this.lblControl);
            this.Controls.Add(this.lblOficina);
            this.Controls.Add(this.lblEntidad);
            this.Controls.Add(this.txbControl);
            this.Controls.Add(this.txbOficina);
            this.Controls.Add(this.txbEntidad);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txbCC);
            this.Controls.Add(this.txbNIF);
            this.Controls.Add(this.lblCuenta);
            this.Controls.Add(this.lblNIF);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmNIFCC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Datos Cliente";
            this.TopMost = true;
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmNIFCC_Closing);
            this.Load += new System.EventHandler(this.frmNIFCC_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        // NOTA: Tanto el NIF como la CC sólo se dejarán modificar si no están informados
        //       Obligatoriedad: El NIF siempre es obligatorio menos para los andorranos
        //                       La CC es obligatoria si el pedido es dir

        private void frmNIFCC_Load(object sender, EventArgs e)
        {
            // NIF: Si el NIF ya está informado, el campo estará inactivo (no se puede modificar)
            
            txbNIF.Text = NIF;

            if (txbNIF.Text == "" || txbNIF == null)
            {
                txbNIF.Enabled = true;
                txbNIF.BackColor = Color.White;
            }
            else
            {
                txbNIF.Enabled = false;
                txbNIF.BackColor = Color.FromArgb(238, 243, 246);
            }

            // CC: La cuenta corriente ya está informada, los campos estarán inactivos (no se puede modificar) SE PUEDE MODIFICAR DESDE LA PANTALLA DE PEDIDOS           
            //if (CC == "" || CC == null)
            if ((CC == "" || CC == null) && _sCondPago != Comun.K_ENMETALICO)
            {
                if (!esAndorrano)
                {
                    txbCCAndorra.Visible = false;

                    lblCuentaAnd.Visible = false;

                    txbIBAN.Visible = true;
                    txbCC.Visible = true;
                    txbEntidad.Visible = true;
                    txbOficina.Visible = true;
                    txbControl.Visible = true;

                    lblCuenta.Visible = true;
                    lblIBAN.Visible = true;
                    lblCC.Visible = true;
                    lblEntidad.Visible = true;
                    lblOficina.Visible = true;
                    lblControl.Visible = true;


                    txbIBAN.Text = "";
                    txbEntidad.Text = "";
                    txbOficina.Text = "";
                    txbControl.Text = "";
                    txbCC.Text = "";


                    //---- GSG (06/03/2021) Para evitar que llegue a finanzas un pedido directo cuando aún no se ha aprobado la modificación del SEPA en SAP
                    //txbIBAN.Enabled = true;
                    //txbCC.Enabled = true;
                    //txbEntidad.Enabled = true;
                    //txbOficina.Enabled = true;
                    //txbControl.Enabled = true;



                    //---- GSG (12/01/2015)
                    lblGuio1.Visible = true;
                    lblGuio2.Visible = true;


                    txbIBAN.BackColor = Color.White;
                    txbCC.BackColor = Color.White;
                    txbEntidad.BackColor = Color.White;
                    txbOficina.BackColor = Color.White;
                    txbControl.BackColor = Color.White;
                }
                else
                {
                    txbCCAndorra.Visible = true;

                    lblCuentaAnd.Visible = true;

                    txbIBAN.Visible = false;
                    txbCC.Visible = false;
                    txbEntidad.Visible = false;
                    txbOficina.Visible = false;
                    txbControl.Visible = false;
                    //---- GSG (12/01/2015)
                    lblGuio1.Visible = false;
                    lblGuio2.Visible = false;


                    lblCuenta.Visible = false;
                    lblIBAN.Visible = false;
                    lblCC.Visible = false;
                    lblEntidad.Visible = false;
                    lblOficina.Visible = false;
                    lblControl.Visible = false;

                    txbCCAndorra.Text = "";

                    txbCCAndorra.Enabled = true;

                    txbCCAndorra.BackColor = Color.White;
                }

            }
            else if (_sCondPago == Comun.K_ENMETALICO) 
            {
                txbCCAndorra.Visible = false;
                lblCuentaAnd.Visible = false;
                txbIBAN.Visible = false;
                txbCC.Visible = false;
                txbEntidad.Visible = false;
                txbOficina.Visible = false;
                txbControl.Visible = false;
                //---- GSG (12/01/2015)
                lblGuio1.Visible = false;
                lblGuio2.Visible = false;

                txbSBanco.Visible = false;
                txbSPais.Visible = false;
                txbSLocalidad.Visible = false;
                txbSOficina.Visible = false;

                lblCuenta.Visible = false;
                lblIBAN.Visible = false;
                lblCC.Visible = false;
                lblEntidad.Visible = false;
                lblOficina.Visible = false;
                lblControl.Visible = false;
                lblCuentaAnd.Visible = false;
                lblSWIFT.Visible = false;
                lblSBanco.Visible = false;
                lblSPais.Visible = false;
                lblSLocalidad.Visible = false;
                lblSOficina.Visible = false;

                txbCCAndorra.Enabled = false;
                lblCuentaAnd.Enabled = false;
                txbIBAN.Enabled = false;
                txbCC.Enabled = false;
                txbEntidad.Enabled = false;
                txbOficina.Enabled = false;
                txbControl.Enabled = false;

                txbSBanco.Enabled = false;
                txbSPais.Enabled = false;
                txbSLocalidad.Enabled = false;
                txbSOficina.Enabled = false;

            }
            else
            {
                if (!esAndorrano)
                {
                    txbCCAndorra.Visible = false;

                    lblCuentaAnd.Visible = false;

                    txbIBAN.Visible = true;
                    txbCC.Visible = true;
                    txbEntidad.Visible = true;
                    txbOficina.Visible = true;
                    txbControl.Visible = true;
                    //---- GSG (12/01/2015)
                    lblGuio1.Visible = true;
                    lblGuio2.Visible = true;

                    lblCuenta.Visible = true;
                    lblIBAN.Visible = true;
                    lblCC.Visible = true;
                    lblEntidad.Visible = true;
                    lblOficina.Visible = true;
                    lblControl.Visible = true;

                    txbIBAN.Text = CC.Substring(0, 4);
                    txbEntidad.Text = CC.Substring(4, 4);
                    txbOficina.Text = CC.Substring(8, 4);
                    txbControl.Text = CC.Substring(13, 2);
                    txbCC.Text = CC.Substring(16, 10);

                    txbIBAN.Enabled = false;
                    txbCC.Enabled = false;
                    txbEntidad.Enabled = false;
                    txbOficina.Enabled = false;
                    txbControl.Enabled = false;

                    txbIBAN.BackColor = Color.FromArgb(238, 243, 246);
                    txbCC.BackColor = Color.FromArgb(238, 243, 246);
                    txbEntidad.BackColor = Color.FromArgb(238, 243, 246);
                    txbOficina.BackColor = Color.FromArgb(238, 243, 246);
                    txbControl.BackColor = Color.FromArgb(238, 243, 246);
                }
                else 
                {
                    txbCCAndorra.Visible = true;

                    lblCuentaAnd.Visible = true;

                    txbIBAN.Visible = false;
                    txbCC.Visible = false;
                    txbEntidad.Visible = false;
                    txbOficina.Visible = false;
                    txbControl.Visible = false;
                    //---- GSG (12/01/2015)
                    lblGuio1.Visible = false;
                    lblGuio2.Visible = false;

                    lblCuenta.Visible = false;
                    lblIBAN.Visible = false;
                    lblCC.Visible = false;
                    lblEntidad.Visible = false;
                    lblOficina.Visible = false;
                    lblControl.Visible = false;

                    txbCCAndorra.Text = CC;

                    txbCCAndorra.Enabled = false;

                    txbCCAndorra.BackColor = Color.FromArgb(238, 243, 246);
                }
            }


            // Código SWIFT. No haremos controles pero si está lo veremos tanto para españoles como andorranos
            if (SWIFT == "" || SWIFT == null)
            {
                txbSBanco.Text = "";
                txbSPais.Text = "";
                txbSLocalidad.Text = "";
                txbSOficina.Text = "";

                txbSBanco.BackColor = Color.White;
                txbSPais.BackColor = Color.White;
                txbSLocalidad.BackColor = Color.White;
                txbSOficina.BackColor = Color.White;
            }
            else
            {
                txbSBanco.Text = SWIFT.Substring(0, 4);
                txbSPais.Text = SWIFT.Substring(4, 2);
                txbSLocalidad.Text = SWIFT.Substring(6, 2);
                txbSOficina.Text = SWIFT.Substring(8, 3);

                txbSBanco.BackColor = Color.FromArgb(238, 243, 246);
                txbSPais.BackColor = Color.FromArgb(238, 243, 246);
                txbSLocalidad.BackColor = Color.FromArgb(238, 243, 246);
                txbSOficina.BackColor = Color.FromArgb(238, 243, 246);
            }


            //Si és transfer i ja venia ok al tancar per creu cal que la comanda també es guardi (és un cancel però les dades originals ja eren bones)
            if (!txbNIF.Enabled && (Comun.IsInTheArray(sTipoPedido, Configuracion.asPedTransfer) && (CC == "" || CC == null)))
                transferJaEraOK = true;                      

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            sortidaCreu = false;
            DialogResult = DialogResult.Cancel;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            sortidaCreu = false;
            guardar();
        }

        //Cerrar
        private void frmNIFCC_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
            if (sortidaCreu && !Comun.IsInTheArray(sTipoPedido, Configuracion.asPedTransfer))
            { //DIR
                DialogResult = DialogResult.Cancel;
            }
            else if (sortidaCreu)
            { //TRANSFER
                if (transferJaEraOK)
                    DialogResult = DialogResult.OK;
                else
                    DialogResult = DialogResult.Cancel;
            }
        }


        private void guardar()
        {
            bool ret;
            bool bOk = true;

            DialogResult = DialogResult.OK; //---- GSG (20/05/2015)


            

            


            //---- GSG (13/10/2014) Añade IBAN en CC españolas y la condición de andorrano

            //El NIF siempre es obligatorio menos para los andorranos i en el caso de pedidos directos en que el cliente es distinto al destinatario
            if (txbNIF.Enabled && !esAndorrano ) //&& !DirCliNotLikeDest)
            {
                ret = Comun.Comprueba_NIF(txbNIF.Text) || Comun.Comprueba_CIF(txbNIF.Text) || Comun.Comprueba_NIE(txbNIF.Text);
                if (ret == false)
                {
                    Mensajes.ShowExclamation("El código de identificación (NIF/CIF/NIE) es incorrecto.");
                    bOk = false;
                }
            }

            
            
            if (bOk == true) // Si el NIF es correcto comprueba CC
            {
                // La CC es obligatoria si el pedido es directo. Las CC andorranas son distintas a las españolas

                //---- GSG (06/03/2021) Para evitar que llegue a finanzas un pedido directo cuando aún no se ha aprobado la modificación del SEPA en SAP
                //if (txbCC.Enabled)
                //{
                    //Si DIR --> es comproba sempre
                    //Si TRANSFER --> es comproba si no s'ha deixat en blanc. NO és obligatori el CC

                    if (_sCondPago == Comun.K_ENMETALICO)
                    {
                        //No hacer nada
                    }
                    else if (!esAndorrano)
                    {
                        bool CCEnBlanc = (txbIBAN.Text.Trim() == "" && txbEntidad.Text.Trim() == "" && txbOficina.Text.Trim() == "" && txbControl.Text.Trim() == "" && txbCC.Text.Trim() == "");
                    
                        if ((!Comun.IsInTheArray(sTipoPedido, Configuracion.asPedTransfer)) || (Comun.IsInTheArray(sTipoPedido, Configuracion.asPedTransfer) && !CCEnBlanc))
                        {
                            //---- GSG (12/01/2015) Dejaremos que puedan dejar en blanco el IBAN aquí (no lo hemos dejado en la pantalla frmNIFFCC donde sí obligamos a ponerlo)
                            // Lo que haremos es calcularlo si lo dejan en blanco
                            if (txbEntidad.Text != "" && txbOficina.Text != "" && txbControl.Text != "" && txbCC.Text != "" && txbIBAN.Text.Trim() == "")
                                txbIBAN.Text = Comun.calcula_IBAN_Espanya(txbEntidad.Text, txbOficina.Text, txbControl.Text, txbCC.Text);
                            //---- FI GSG

                            //ret = Comun.Comprueba_CC(txbEntidad.Text, txbOficina.Text, txbControl.Text, txbCC.Text);
                            //---- GSG (06/05/2015)
                            //ret = Comun.Comprueba_IBAN_Espanya(txbIBAN.Text, txbEntidad.Text, txbOficina.Text, txbControl.Text, txbCC.Text);
                            if (txbIBAN.Text.Trim() != "")
                                ret = Comun.Comprueba_IBAN_Espanya(txbIBAN.Text, txbEntidad.Text, txbOficina.Text, txbControl.Text, txbCC.Text);
                            else
                                //ret = true;
                                ret = Comun.Comprueba_CC(txbEntidad.Text, txbOficina.Text, txbControl.Text, txbCC.Text);
                            if (ret == false)
                            {
                                //---- GSG (06/03/2021) Para evitar que llegue a finanzas un pedido directo cuando aún no se ha aprobado la modificación del SEPA en SAP
                                // Mensajes.ShowExclamation("Los datos bancarios son incorrectos.");
                                if (txbIBAN.Text.Trim() != "")
                                Mensajes.ShowExclamation("Los datos bancarios son incorrectos.");
                                else if ((txbIBAN.Text.Trim() == "") && !Comun.IsInTheArray(sTipoPedido, Configuracion.asPedTransfer))
                                Mensajes.ShowExclamation("No se puede hacer un pedido directo cuando el cliente no tiene los datos bancarios informados.");
                                else
                                Mensajes.ShowExclamation("Los datos bancarios son incorrectos.");

                            bOk = false;
                            }
                        }
                    }
                    else 
                    {
                        bool CCEnBlanc = (txbCCAndorra.Text.Trim() == "");

                        if ((!Comun.IsInTheArray(sTipoPedido, Configuracion.asPedTransfer)) || (Comun.IsInTheArray(sTipoPedido, Configuracion.asPedTransfer) && !CCEnBlanc))
                        {
                            ret = Comun.Comprueba_CC_Andorra(txbCCAndorra.Text);
                            if (ret == false)
                            {
                                Mensajes.ShowExclamation("Los datos bancarios son incorrectos.");
                                bOk = false;
                            }
                        }
                    }
                //}


                if (bOk == true) // Si el NIF y la CC son correctos guarda los datos (incluyendo SWIFT a partir de octubre de 2014)
                {
                    //---- GSG (06/05/2015)
                    // Solo guardará los datos si son distintos a los que ya había
                    string oNIF;
                    string oCC;
                    string oSWIFT;
                    bool bGuarda = true;

                    bool deHoy = datosNCDeHoy(out oNIF, out oCC, out oSWIFT, esAndorrano, clientSAP);
                    if (!deHoy)
                        datosNC(out oNIF, out oCC, out oSWIFT, clientSAP);

                    if (!esAndorrano)
                    {
                        if (txbNIF.Text.Trim() == oNIF.Trim() &&
                            txbIBAN.Text.Trim() + txbEntidad.Text.Trim() + txbOficina.Text.Trim() + "-" + txbControl.Text.Trim() + "-" + txbCC.Text.Trim() == oCC.Trim() &&
                            txbSBanco.Text.Trim() + txbSPais.Text.Trim() + txbSLocalidad.Text.Trim() + txbSOficina.Text.Trim() == oSWIFT.Trim())
                            bGuarda = false;
                    }
                    else
                    {
                        if (txbNIF.Text.Trim() == oNIF.Trim() &&
                            txbCCAndorra.Text.Trim() == oCC.Trim() &&
                            txbSBanco.Text.Trim() + txbSPais.Text.Trim() + txbSLocalidad.Text.Trim() + txbSOficina.Text.Trim() == oSWIFT.Trim())
                            bGuarda = false;
                    }

                    if (bGuarda)
                    {
                        //---- FI GSG

                        SqlTransaction sqlTran;

                        if (sqlConn.State.ToString() == "Closed")
                            sqlConn.Open();

                        sqlTran = sqlConn.BeginTransaction();
                        sqlCmdSetContactosClientesSAP.Transaction = sqlTran;

                        try
                        {
                            this.sqlCmdSetContactosClientesSAP.Parameters["@iIdCliente"].Value = clientSAP;
                            if (!esAndorrano)
                                this.sqlCmdSetContactosClientesSAP.Parameters["@sNombre"].Value = txbIBAN.Text + txbEntidad.Text + txbOficina.Text + "-" + txbControl.Text + "-" + txbCC.Text;
                            else
                                this.sqlCmdSetContactosClientesSAP.Parameters["@sNombre"].Value = txbCCAndorra.Text;
                            this.sqlCmdSetContactosClientesSAP.Parameters["@dFAR"].Value = txbNIF.Text;
                            this.sqlCmdSetContactosClientesSAP.Parameters["@iEstado"].Value = -2;
                            this.sqlCmdSetContactosClientesSAP.Parameters["@sSWIFT"].Value = txbSBanco.Text + txbSPais.Text + txbSLocalidad.Text + txbSOficina.Text;

                            this.sqlCmdSetContactosClientesSAP.ExecuteScalar();

                            sqlTran.Commit();

                            DialogResult = DialogResult.OK;
                        }
                        catch (Exception ex)
                        {
                            sqlTran.Rollback();

                            DialogResult = DialogResult.Cancel;
                        }
                        finally
                        {
                            sqlTran.Dispose();
                            sqlConn.Close();
                        }
                    }
                }
                else
                    DialogResult = DialogResult.Cancel; //---- GSG (11/06/2015)                    
            }
            else
                DialogResult = DialogResult.Cancel; //---- GSG (04/02/2016)     
            
            

        }


        private bool datosNCDeHoy(out string oNIF, out string oCC, out string oSWIFT, bool pbEsClienteAndorrano, int pagador)
        {
            bool ret = false;
            bool condicio = false;

            oNIF = "";
            oCC = "";
            oSWIFT = "";

            try
            {
                SqlDataReader dr;

                if (sqlConn.State.ToString() == "Closed")
                    sqlConn.Open();

                sqlCmdListaContactosClientes_SAP.Parameters["@iIdCliente"].Value = pagador;

                dr = sqlCmdListaContactosClientes_SAP.ExecuteReader();

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
                    if (!Comun.IsInTheArray(sTipoPedido, Configuracion.asPedTransfer))
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

                dr.Close();

            }
            catch (Exception err)
            {
                Mensajes.ShowError(err.ToString());
            }

            sqlConn.Close();
            return ret;
        }


        //---- GSG (06/05/2015)
        private void datosNC(out string pNif, out string pCC, out string pSWIFT, int pagador)
        {
            pNif = "";
            pCC = "";
            pSWIFT = "";

            try
            {
                SqlDataReader drDto;

                if (sqlConn.State.ToString() == "Closed")
                    sqlConn.Open();

                sqlCmdGetClientesSAP.Parameters["@iIdCliente"].Value = pagador;


                drDto = sqlCmdGetClientesSAP.ExecuteReader();

                if (drDto.Read())
                {
                    if (drDto["sNIF_SAP"] != null)
                        pNif = drDto["sNIF_SAP"].ToString().Trim();
                    if (drDto["sDatosBancarios_SAP"] != null)
                        pCC = drDto["sDatosBancarios_SAP"].ToString().Trim();
                    if (drDto["sSWIFT"] != null)
                        pSWIFT = drDto["sSWIFT"].ToString().Trim();
                }

                drDto.Close();
            }
            catch (Exception err)
            {
                Mensajes.ShowError(err.ToString());
            }

            sqlConn.Close();
        }
    }
}
