using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace GESTCRM.Formularios
{
    public partial class frmConsultaVentas : Form
    {
        const int K_COL_CODNACIONAL = 0;
        const int K_COL_NOMMAT = 1;
        const int K_COL_UNITOTAL = 2;
        const int K_COL_UNIMES = 3;
        const int K_COL_TENDENCIA = 4;
        const int K_COL_UNIDIR = 5;
        const int K_COL_BRUTODIR = 6;
        const int K_COL_DESCDIR = 7;
        const int K_COL_UNITRANS = 8;
        const int K_COL_BRUTOTRANS = 9;
        const int K_COL_DESCTRANS = 10;
        const int K_COL_UNICLUB = 11;
        const int K_COL_BRUTOCLUB = 12;
        const int K_COL_DESCCLUB = 13;
        const int K_COL_UNIAUTO = 14;
        const int K_COL_BRUTOAUTO = 15;
        const int K_COL_DESCAUTO = 16;
        


        int Var_iIdCliente;
        int Var_fila;

        private System.Data.SqlClient.SqlConnection sqlConn;
        private System.Data.SqlClient.SqlDataAdapter sqldaListaTipoMaterialInforme;
        private System.Data.SqlClient.SqlCommand sqlCmdListaTipoMaterialInforme;
        private System.Data.SqlClient.SqlDataAdapter sqldaInformeS;
        private System.Data.SqlClient.SqlCommand sqlCmdListaInformeS;
        

        public frmConsultaVentas()
        {
            InitializeComponent();
        }

        private void frmConsultaVentas_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                lblAvisoVersion.Text = System.Configuration.ConfigurationManager.AppSettings["AvisoVersion"].ToString(); //---- GSG (14/02/2014)

                Utiles.Formato_Formulario(this);
                if (this.Parent == null) this.WindowState = FormWindowState.Normal;

                if (this.Parent == null)
                    this.WindowState = FormWindowState.Normal;

                Inicializar_Botonera();

                Inicializar_Combos(); 
                Inicializar_Fechas();

                this.Var_iIdCliente = -1;
                this.Var_fila = -1;

   

            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }

            Cursor.Current = Cursors.Default;
        }


        
        #region inits

        private void Inicializar_Fechas()
        {
            calculaFechas(DateTime.Today);            
        }

        private void Inicializar_Combos()
        {
            try
            {
                //Inicializar ComboBox cbTipoMaterial
                this.sqldaListaTipoMaterialInforme.Fill(this.dsMateriales1);
                DataRow fila = this.dsMateriales1.ListaTipoMaterialInforme.NewRow();
                fila["sValor"] = "-1";
                fila["sLiteral"] = "Todos";
                this.dsMateriales1.ListaTipoMaterialInforme.Rows.InsertAt(fila, 0);
                this.cbTipoMaterial.SelectedValue = "-1";


                //Inicializar ComboBox cbTotalVenta
                DataTable tabla = new DataTable();
                tabla.Columns.Add("sValor");
                tabla.Columns.Add("sLiteral");
                DataRow fila1 = tabla.NewRow();
                fila1["sValor"] = "-1";
                fila1["sLiteral"] = "Todos";
                tabla.Rows.Add(fila1);
                DataRow fila2 = tabla.NewRow();
                fila2["sValor"] = "0";
                fila2["sLiteral"] = "Sin Ventas";
                tabla.Rows.Add(fila2);
                DataRow fila3 = tabla.NewRow();
                fila3["sValor"] = "1";
                fila3["sLiteral"] = "Con Ventas";
                tabla.Rows.Add(fila3);
                this.cbTotalVenta.DataSource = tabla;
                this.cbTotalVenta.ValueMember = "sValor";
                this.cbTotalVenta.DisplayMember = "sLiteral";
                this.cbTotalVenta.SelectedValue = "-1";


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
                filaC2["sLiteral"] = "Superior a 10%";
                tablaC.Rows.Add(filaC2);
                DataRow filaC3 = tablaC.NewRow();
                filaC3["sValor"] = "-";
                filaC3["sLiteral"] = "Inferior a -10%";
                tablaC.Rows.Add(filaC3);
                DataRow filaC4 = tablaC.NewRow();
                filaC4["sValor"] = "=";
                filaC4["sLiteral"] = "Entre -10% y 10%";
                tablaC.Rows.Add(filaC4);
                this.cbCrecimiento.DataSource = tablaC;
                this.cbCrecimiento.ValueMember = "sValor";
                this.cbCrecimiento.DisplayMember = "sLiteral";
                this.cbCrecimiento.SelectedValue = "-1";
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }

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
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }

        #endregion


        private void calculaFechas(DateTime fecha)
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
                        this.Var_iIdCliente = frmBCli.ParamO_iIdCliente;
                    }
                }
                frmBCli.Dispose();
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }

        private void dtpFechaFin_ValueChanged(object sender, EventArgs e)
        {
            calculaFechas(DateTime.Parse(dtpFechaFin.Text)); 
        }

        private void dtpFechaIni_ValueChanged(object sender, EventArgs e)
        {
            //El primer día del mes siempre
            this.dtpFechaIni.Value = DateTime.Parse("01/" + dtpFechaIni.Value.Month.ToString() + "/" + dtpFechaIni.Value.Year.ToString());
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //Datos de ventas
            CargarDatos();

            //Datos clubs
            string[] clubs = new string[5];

            clubs = CargarClubs();

            txtGarantias.Text = clubs[0];
            txtGarantias1.Text = clubs[1];
            txtGarantias2.Text = clubs[2];
            txtGarantias3.Text = clubs[3];
            txtGarantias4.Text = clubs[4];
        }


        private void CargarDatos()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                this.dsMateriales1.ListaInformeS.Rows.Clear();

                if (this.Var_iIdCliente != -1)
                {
                    this.sqldaInformeS.SelectCommand.Parameters["@iIdCliente"].Value = this.Var_iIdCliente;
                    try { this.sqldaInformeS.SelectCommand.Parameters["@dFechaIni"].Value = DateTime.Parse(this.dtpFechaIni.Value.ToString("dd/MM/yyyy")); }
                    catch { }
                    try { this.sqldaInformeS.SelectCommand.Parameters["@dFechaFin"].Value = DateTime.Parse(this.dtpFechaFin.Value.ToString("dd/MM/yyyy")); }
                    catch { }
                    this.sqldaInformeS.SelectCommand.Parameters["@sTipoMatInformes"].Value = this.cbTipoMaterial.SelectedValue.ToString();
                    //---- GSG (07/03/2014)
                    //this.sqldaInformeS.SelectCommand.Parameters["@iConVentas"].Value = int.Parse(this.cbTotalVenta.SelectedValue.ToString());
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
                    if (cbCrecimiento.SelectedValue.ToString() != "-1")
                        this.sqldaInformeS.SelectCommand.Parameters["@sTendencia"].Value = cbCrecimiento.SelectedValue.ToString();
                    else
                        this.sqldaInformeS.SelectCommand.Parameters["@sTendencia"].Value = null;
                    //---- FI GSG

                    this.sqldaInformeS.Fill(this.dsMateriales1);
                }
                else
                {
                    Mensajes.ShowInformation("No se ha indicado el cliente. Seleccione un cliente e inténtelo de nuevo.");
                }

                this.lblNumReg.Text = this.dsMateriales1.ListaInformeS.Rows.Count.ToString();
                
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
            Cursor.Current = Cursors.Default;
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

        private void dGVVentas_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.Var_fila = this.dGVVentas.CurrentRow.Index;

                if (Var_fila != -1)
                {
                    int iTotalUnidades = 0;
                    if (dGVVentas.Rows[Var_fila].Cells[K_COL_UNITOTAL].Value.ToString() != "")
                        iTotalUnidades = int.Parse(dGVVentas.Rows[Var_fila].Cells[K_COL_UNITOTAL].Value.ToString());

                    if (iTotalUnidades != 0)
                    {
                        string sCodNacional = dGVVentas.Rows[Var_fila].Cells[K_COL_CODNACIONAL].Value.ToString();
                        string sMaterial = dGVVentas.Rows[Var_fila].Cells[K_COL_NOMMAT].Value.ToString();

                        Form frmTemp = new Formularios.frmGraphVentasProdFcia(this.dtpFechaIni.Value, this.dtpFechaFin.Value, this.Var_iIdCliente, sCodNacional, sMaterial);
                        frmTemp.ShowDialog();
                    }
                    else
                    {
                        GESTCRM.Mensajes.ShowInformation("El material seleccionado no tiene ventas.");
                    }
                }
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }


        private string[] CargarClubs()
        {
            return Utiles.GetClubsCliente(Var_iIdCliente);
        }

    }
}
