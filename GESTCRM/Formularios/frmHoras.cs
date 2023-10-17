//---- GSG (28/07/2011) Crear Visita desde creación de pedidos

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GESTCRM.Formularios
{
    public partial class frmHoras : Form
    {
        private System.Data.SqlClient.SqlConnection sqlConn;
        SqlTransaction sqlTran;

        private System.Data.SqlClient.SqlCommand sqlcmdSetRepActividad_Cab;
        private System.Data.SqlClient.SqlCommand sqlcmdSetRepActividad_Cli;
        private System.Data.SqlClient.SqlCommand sqlcmdSetRepActividad_Ped;

        //Guardan el valor pasado como parámetro
        private string ParamTipoAcceso;	    //Tipo de acceso al formulario A:Alta, M:Modificación, C:Consulta
        private int ParamIdReport;		    //Identificador de Report, sólo en Modificaciones y Consultas. Si Nou --> -1
        private DateTime ParamFecha;		//sólo en Altas desde planificación
        private int ParamiIdDelegado;	    //Identificador de delegado
        private int ParamiIdCliente;	    //Identificador de cliente
        private string ParamIdPedido;       //Identificador de pedido


        public frmHoras(string TipoAcceso, int IdReport, DateTime Fecha, int iIdDelegado, int iIdCliente, string sIdPedido)
        {
            InitializeComponent();

            //---- GSG (06/03/2021)
            Utiles.GetConfigConnection();
            this.sqlConn.ConnectionString = Utiles._connection.ConnectionString.ToString();

            

            this.ParamTipoAcceso = TipoAcceso;  //A-> Alta; M->Modificación; C->Consulta
            this.ParamIdReport = IdReport;	    // Identificador del Report
            this.ParamFecha = Fecha;			// Fecha del Report, sólo se usa para el alta y cuando la llamada es desde Planificación			
            this.ParamiIdDelegado = iIdDelegado;
            this.ParamiIdCliente = iIdCliente;
            this.ParamIdPedido = sIdPedido;

            //---- GSG (13/03/2019)
            //---- GSG (19/09/2017)
            // Cargar objetivo
            //txbObjetivo.Text = GESTCRM.Utiles.ProximoObjetivoVisita(iIdCliente, IdReport);
            txbObjetivo.Text = GESTCRM.Utiles.ProximoObjetivoVisita(iIdCliente, IdReport, Fecha);

            //---- GSG (08/01/2017)
            this.dtpFechaVisita.Value = this.ParamFecha;
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Configuration.AppSettingsReader configurationAppSettings = new System.Configuration.AppSettingsReader();
            this.sqlConn = new System.Data.SqlClient.SqlConnection();
            this.sqlcmdSetRepActividad_Cab = new System.Data.SqlClient.SqlCommand();
            this.sqlcmdSetRepActividad_Cli = new System.Data.SqlClient.SqlCommand();
            this.sqlcmdSetRepActividad_Ped = new System.Data.SqlClient.SqlCommand();
            this.lblDesc = new System.Windows.Forms.Label();
            this.lblHoraIni = new System.Windows.Forms.Label();
            this.lblHoraFin = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.dtpHoraInicio = new System.Windows.Forms.DateTimePicker();
            this.dtpHoraFin = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtpFechaVisita = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txbObservaciones = new System.Windows.Forms.TextBox();
            this.lblSWIFT = new System.Windows.Forms.Label();
            this.txbProximoObjetivo = new System.Windows.Forms.TextBox();
            this.lblCuentaAnd = new System.Windows.Forms.Label();
            this.txbObjetivo = new System.Windows.Forms.TextBox();
            this.lblNIF = new System.Windows.Forms.Label();
            this.checkBoxTelefonica = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // sqlConn
            // 
            this.sqlConn.ConnectionString = Utiles._connection.ConnectionString.ToString();   //---- GSG (06/03/2021)
            this.sqlConn.FireInfoMessageEventOnUserErrors = false;
            // 
            // sqlcmdSetRepActividad_Cab
            // 
            this.sqlcmdSetRepActividad_Cab.CommandText = "[SetRepActividad_Cab]";
            this.sqlcmdSetRepActividad_Cab.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlcmdSetRepActividad_Cab.Connection = this.sqlConn;
            this.sqlcmdSetRepActividad_Cab.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@Accion", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdReport", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.InputOutput, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdDelegado", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sIdReportTemp", System.Data.SqlDbType.VarChar, 15, System.Data.ParameterDirection.Output, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@sTipoRActividad", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@sIdTipoCliente", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@iIdCentro", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@dFecha", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@iHorario", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@tObjetivo", System.Data.SqlDbType.VarChar, 2147483647),
            new System.Data.SqlClient.SqlParameter("@tProxObjetivo", System.Data.SqlDbType.VarChar, 2147483647),
            new System.Data.SqlClient.SqlParameter("@tObservaciones", System.Data.SqlDbType.VarChar, 2147483647),
            new System.Data.SqlClient.SqlParameter("@bPlanificacion", System.Data.SqlDbType.SmallInt, 2),
            new System.Data.SqlClient.SqlParameter("@iEstado", System.Data.SqlDbType.SmallInt, 2),
            new System.Data.SqlClient.SqlParameter("@dHoraInicio", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@dHoraFin", System.Data.SqlDbType.DateTime, 8)});
            // 
            // sqlcmdSetRepActividad_Cli
            // 
            this.sqlcmdSetRepActividad_Cli.CommandText = "[SetRepActividad_Cli]";
            this.sqlcmdSetRepActividad_Cli.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlcmdSetRepActividad_Cli.Connection = this.sqlConn;
            this.sqlcmdSetRepActividad_Cli.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@Accion", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdReport", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdCliente", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@tObservaciones", System.Data.SqlDbType.VarChar, 8000),
            new System.Data.SqlClient.SqlParameter("@tObjetivos", System.Data.SqlDbType.VarChar, 8000),
            new System.Data.SqlClient.SqlParameter("@tProxObj", System.Data.SqlDbType.VarChar, 8000),
            new System.Data.SqlClient.SqlParameter("@bSustituto", System.Data.SqlDbType.Bit, 1),
            new System.Data.SqlClient.SqlParameter("@sIdRed", System.Data.SqlDbType.VarChar, 4)});
            // 
            // sqlcmdSetRepActividad_Ped
            // 
            this.sqlcmdSetRepActividad_Ped.CommandText = "[SetRepActividad_Ped]";
            this.sqlcmdSetRepActividad_Ped.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlcmdSetRepActividad_Ped.Connection = this.sqlConn;
            this.sqlcmdSetRepActividad_Ped.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@Accion", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdReport", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sIdPedido", System.Data.SqlDbType.VarChar, 12)});
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.BackColor = System.Drawing.Color.Transparent;
            this.lblDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesc.Location = new System.Drawing.Point(11, 23);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(159, 16);
            this.lblDesc.TabIndex = 15;
            this.lblDesc.Text = "Fecha y Hora de la visita:";
            // 
            // lblHoraIni
            // 
            this.lblHoraIni.AutoSize = true;
            this.lblHoraIni.BackColor = System.Drawing.Color.Transparent;
            this.lblHoraIni.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHoraIni.Location = new System.Drawing.Point(24, 122);
            this.lblHoraIni.Name = "lblHoraIni";
            this.lblHoraIni.Size = new System.Drawing.Size(87, 16);
            this.lblHoraIni.TabIndex = 16;
            this.lblHoraIni.Text = "Hora Inicio:";
            // 
            // lblHoraFin
            // 
            this.lblHoraFin.AutoSize = true;
            this.lblHoraFin.BackColor = System.Drawing.Color.Transparent;
            this.lblHoraFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHoraFin.Location = new System.Drawing.Point(24, 158);
            this.lblHoraFin.Name = "lblHoraFin";
            this.lblHoraFin.Size = new System.Drawing.Size(71, 16);
            this.lblHoraFin.TabIndex = 17;
            this.lblHoraFin.Text = "Hora Fin:";
            // 
            // btnAceptar
            // 
            this.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Image = global::GESTCRM.Properties.Resources.ok_032x032;
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAceptar.Location = new System.Drawing.Point(300, 389);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(2);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(110, 40);
            this.btnAceptar.TabIndex = 74;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // dtpHoraInicio
            // 
            this.dtpHoraInicio.CustomFormat = "HH:mm";
            this.dtpHoraInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpHoraInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHoraInicio.Location = new System.Drawing.Point(123, 119);
            this.dtpHoraInicio.Name = "dtpHoraInicio";
            this.dtpHoraInicio.ShowUpDown = true;
            this.dtpHoraInicio.Size = new System.Drawing.Size(59, 22);
            this.dtpHoraInicio.TabIndex = 75;
            // 
            // dtpHoraFin
            // 
            this.dtpHoraFin.CustomFormat = "HH:mm";
            this.dtpHoraFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpHoraFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHoraFin.Location = new System.Drawing.Point(123, 155);
            this.dtpHoraFin.Name = "dtpHoraFin";
            this.dtpHoraFin.ShowUpDown = true;
            this.dtpHoraFin.Size = new System.Drawing.Size(59, 22);
            this.dtpHoraFin.TabIndex = 76;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dtpFechaVisita);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblDesc);
            this.panel1.Controls.Add(this.dtpHoraFin);
            this.panel1.Controls.Add(this.lblHoraIni);
            this.panel1.Controls.Add(this.dtpHoraInicio);
            this.panel1.Controls.Add(this.lblHoraFin);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(201, 228);
            this.panel1.TabIndex = 77;
            // 
            // dtpFechaVisita
            // 
            this.dtpFechaVisita.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.dtpFechaVisita.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaVisita.Location = new System.Drawing.Point(82, 69);
            this.dtpFechaVisita.Name = "dtpFechaVisita";
            this.dtpFechaVisita.Size = new System.Drawing.Size(100, 20);
            this.dtpFechaVisita.TabIndex = 78;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 16);
            this.label1.TabIndex = 77;
            this.label1.Text = "Fecha:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txbObservaciones);
            this.panel2.Controls.Add(this.lblSWIFT);
            this.panel2.Controls.Add(this.txbProximoObjetivo);
            this.panel2.Controls.Add(this.lblCuentaAnd);
            this.panel2.Controls.Add(this.txbObjetivo);
            this.panel2.Controls.Add(this.lblNIF);
            this.panel2.Location = new System.Drawing.Point(225, 11);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(472, 358);
            this.panel2.TabIndex = 78;
            // 
            // txbObservaciones
            // 
            this.txbObservaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbObservaciones.Location = new System.Drawing.Point(143, 215);
            this.txbObservaciones.Multiline = true;
            this.txbObservaciones.Name = "txbObservaciones";
            this.txbObservaciones.Size = new System.Drawing.Size(312, 119);
            this.txbObservaciones.TabIndex = 31;
            // 
            // lblSWIFT
            // 
            this.lblSWIFT.AutoSize = true;
            this.lblSWIFT.BackColor = System.Drawing.Color.Transparent;
            this.lblSWIFT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSWIFT.Location = new System.Drawing.Point(23, 213);
            this.lblSWIFT.Name = "lblSWIFT";
            this.lblSWIFT.Size = new System.Drawing.Size(117, 16);
            this.lblSWIFT.TabIndex = 34;
            this.lblSWIFT.Text = "Observaciones:";
            // 
            // txbProximoObjetivo
            // 
            this.txbProximoObjetivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbProximoObjetivo.Location = new System.Drawing.Point(144, 118);
            this.txbProximoObjetivo.Multiline = true;
            this.txbProximoObjetivo.Name = "txbProximoObjetivo";
            this.txbProximoObjetivo.Size = new System.Drawing.Size(311, 79);
            this.txbProximoObjetivo.TabIndex = 30;
            // 
            // lblCuentaAnd
            // 
            this.lblCuentaAnd.BackColor = System.Drawing.Color.Transparent;
            this.lblCuentaAnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCuentaAnd.Location = new System.Drawing.Point(23, 116);
            this.lblCuentaAnd.Name = "lblCuentaAnd";
            this.lblCuentaAnd.Size = new System.Drawing.Size(93, 45);
            this.lblCuentaAnd.TabIndex = 33;
            this.lblCuentaAnd.Text = "Próximo Objetivo:";
            // 
            // txbObjetivo
            // 
            this.txbObjetivo.Enabled = false;
            this.txbObjetivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbObjetivo.Location = new System.Drawing.Point(143, 24);
            this.txbObjetivo.Multiline = true;
            this.txbObjetivo.Name = "txbObjetivo";
            this.txbObjetivo.Size = new System.Drawing.Size(312, 79);
            this.txbObjetivo.TabIndex = 29;
            // 
            // lblNIF
            // 
            this.lblNIF.AutoSize = true;
            this.lblNIF.BackColor = System.Drawing.Color.Transparent;
            this.lblNIF.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNIF.Location = new System.Drawing.Point(23, 24);
            this.lblNIF.Name = "lblNIF";
            this.lblNIF.Size = new System.Drawing.Size(70, 16);
            this.lblNIF.TabIndex = 32;
            this.lblNIF.Text = "Objetivo:";
            // 
            // checkBoxTelefonica
            // 
            this.checkBoxTelefonica.AutoSize = true;
            this.checkBoxTelefonica.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxTelefonica.Location = new System.Drawing.Point(39, 257);
            this.checkBoxTelefonica.Name = "checkBoxTelefonica";
            this.checkBoxTelefonica.Size = new System.Drawing.Size(127, 20);
            this.checkBoxTelefonica.TabIndex = 79;
            this.checkBoxTelefonica.Text = "Visita Telefónica";
            this.checkBoxTelefonica.UseVisualStyleBackColor = true;
            // 
            // frmHoras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 444);
            this.Controls.Add(this.checkBoxTelefonica);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnAceptar);
            this.Name = "frmHoras";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Visita";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private bool Grabar_Visita()
        {
            bool resultado = true;
            int Accion = Utiles.Transformar_TipoAcceso(this.ParamTipoAcceso);
            int iIdReport = this.ParamIdReport;
            //string sIdReport = null;
            string sMensj = String.Empty;


            //---- GSG (10/09/2014)
            //sqlConn.Open();
            if (sqlConn.State == ConnectionState.Closed)
                sqlConn.Open();


            sqlTran = this.sqlConn.BeginTransaction();

            this.sqlcmdSetRepActividad_Cab.Transaction = sqlTran;
            this.sqlcmdSetRepActividad_Cli.Transaction = sqlTran;
            this.sqlcmdSetRepActividad_Ped.Transaction = sqlTran;

            try
            {               
                this.sqlcmdSetRepActividad_Cab.Parameters["@iIdReport"].Value = iIdReport;
                this.sqlcmdSetRepActividad_Cab.Parameters["@iIdDelegado"].Value = this.ParamiIdDelegado;
                //---- GSG (02/02/2021)
                //this.sqlcmdSetRepActividad_Cab.Parameters["@sTipoRActividad"].Value = "2"; // 1 = Report, 2 = Pedido

                if (checkBoxTelefonica.Checked)
                    this.sqlcmdSetRepActividad_Cab.Parameters["@sTipoRActividad"].Value = "3"; // 1 = Report, 2 = Pedido, 3 = Telefónica
                else
                    this.sqlcmdSetRepActividad_Cab.Parameters["@sTipoRActividad"].Value = "2"; // 1 = Report, 2 = Pedido, 3 = Telefónica

                this.sqlcmdSetRepActividad_Cab.Parameters["@sIdTipoCliente"].Value = "S";  // C = Cliente COM, S = Cliente SAP
                //---- GSG (0/01/2018)
                //this.sqlcmdSetRepActividad_Cab.Parameters["@dFecha"].Value = ParamFecha.ToString("dd/MM/yyyy");
                this.sqlcmdSetRepActividad_Cab.Parameters["@dFecha"].Value = dtpFechaVisita.Value.ToString("dd/MM/yyyy");
                this.sqlcmdSetRepActividad_Cab.Parameters["@iHorario"].Value = "1"; // 1 = Mañana, 2 = Tarde (tant fa el que li posi, sols importa l'hora)
                this.sqlcmdSetRepActividad_Cab.Parameters["@tObjetivo"].Value = null;
                this.sqlcmdSetRepActividad_Cab.Parameters["@tProxObjetivo"].Value = null;
                this.sqlcmdSetRepActividad_Cab.Parameters["@tObservaciones"].Value = null;
                this.sqlcmdSetRepActividad_Cab.Parameters["@bPlanificacion"].Value = 0; //0 pq és pedido, si no seria 1
                this.sqlcmdSetRepActividad_Cab.Parameters["@Accion"].Value = Accion;
                this.sqlcmdSetRepActividad_Cab.Parameters["@dHoraInicio"].Value = dtpHoraInicio.Value;
                this.sqlcmdSetRepActividad_Cab.Parameters["@dHoraFin"].Value = dtpHoraFin.Value;

                this.sqlcmdSetRepActividad_Cab.ExecuteNonQuery();

                if (Accion == 0)
                {
                    iIdReport = Int32.Parse(this.sqlcmdSetRepActividad_Cab.Parameters["@iIdReport"].Value.ToString());
                    //sIdReport = this.sqlcmdSetRepActividad_Cab.Parameters["@sIdReportTemp"].Value.ToString();
                }
                //Borrar RepActividad_Cli, RepActividad_Gad, , RepActividad_Aten
                //RepActividadCli_ProxObj
                //Pone a 0 el Importe Real de todas las Atenciones Comerciales Manuales
                //que tenía asignadas el Report

                this.sqlcmdSetRepActividad_Cli.Parameters["@iIdReport"].Value = iIdReport;
                this.sqlcmdSetRepActividad_Cli.Parameters["@Accion"].Value = 2;
                this.sqlcmdSetRepActividad_Cli.ExecuteNonQuery();

                //Insertar RepActividad_Cli
                this.sqlcmdSetRepActividad_Cli.Parameters["@iIdReport"].Value = iIdReport;
                this.sqlcmdSetRepActividad_Cli.Parameters["@iIdCliente"].Value = ParamiIdCliente;

                //---- GSG (19/09/2017)
                //this.sqlcmdSetRepActividad_Cli.Parameters["@tObservaciones"].Value = null;
                //this.sqlcmdSetRepActividad_Cli.Parameters["@tObjetivos"].Value = null;
                //this.sqlcmdSetRepActividad_Cli.Parameters["@tProxObj"].Value = null;
                this.sqlcmdSetRepActividad_Cli.Parameters["@tObjetivos"].Value = txbObjetivo.Text.Trim();
                this.sqlcmdSetRepActividad_Cli.Parameters["@tProxObj"].Value = txbProximoObjetivo.Text;
                this.sqlcmdSetRepActividad_Cli.Parameters["@tObservaciones"].Value = txbObservaciones.Text.Trim();


                this.sqlcmdSetRepActividad_Cli.Parameters["@bSustituto"].Value = 0;
                this.sqlcmdSetRepActividad_Cli.Parameters["@Accion"].Value = 0;
                sqlcmdSetRepActividad_Cli.Parameters["@sIdRed"].Value = Clases.Configuracion.sIdRed;
                this.sqlcmdSetRepActividad_Cli.ExecuteNonQuery();

                //Borrar Pedidos
                this.sqlcmdSetRepActividad_Ped.Parameters["@iIdReport"].Value = iIdReport;
                this.sqlcmdSetRepActividad_Ped.Parameters["@Accion"].Value = 2;

                this.sqlcmdSetRepActividad_Ped.ExecuteNonQuery();

                //Grabar Pedido
                this.sqlcmdSetRepActividad_Ped.Parameters["@iIdReport"].Value = iIdReport;
                this.sqlcmdSetRepActividad_Ped.Parameters["@sIdPedido"].Value = ParamIdPedido;
                this.sqlcmdSetRepActividad_Ped.Parameters["@Accion"].Value = 0;

                this.sqlcmdSetRepActividad_Ped.ExecuteNonQuery();


                //Grabar en el fichero de Configuración
                if (this.ParamIdReport == -1) //Segur que sí
                {
                    this.ParamIdReport = iIdReport;
                }

                this.sqlTran.Commit();
                resultado = true;
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                sMensj = "Error al generar la visita: ";
                foreach (System.Data.SqlClient.SqlError Err in ex.Errors)
                {
                    if (Err.Number == 2627)
                    {
                        sMensj += "Código ya existente";
                        break;
                    }
                    if (Err.Number != 3621)
                    {
                        sMensj += Err.Number.ToString() + " - " + Err.Message.ToString();
                    }
                }

                if (this.ParamIdReport == -1)
                {
                    GESTCRM.Clases.Configuracion.iGVisitas--;
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
            return resultado;
        }


        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Validar_Horas())
            {
                Grabar_Visita();    //Guarda visita 
                DialogResult = DialogResult.OK;
            }
            else
                DialogResult = DialogResult.Cancel;
        }


        private bool Validar_Horas()
        {
            StringBuilder ErrorMessage = new StringBuilder();
            char dot = (char)0x25CF;

            try
            {

                if (dtpHoraInicio.Value.ToString().Length == 0)
                {
                    ErrorMessage.AppendFormat("{0} Debe introducir la hora de inicio.", dot);
                }

                if (dtpHoraFin.Value.ToString().Length == 0)
                {
                    if (ErrorMessage.Length > 0)
                        ErrorMessage.Append("\n");
                    ErrorMessage.AppendFormat("{0} Debe introducir la hora de finalización.", dot);
                }

                if (dtpHoraInicio.Value >= dtpHoraFin.Value)
                {
                    if (ErrorMessage.Length > 0)
                        ErrorMessage.Append("\n");
                    ErrorMessage.AppendFormat("{0} La hora de inicio debe ser menor que la hora de finalización.", dot);
                }


                if (ErrorMessage.Length > 0)
                {
                    Mensajes.ShowError(ErrorMessage.ToString());
                    return false;
                }

                return true;
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); return false; }
        } 
    }
}
