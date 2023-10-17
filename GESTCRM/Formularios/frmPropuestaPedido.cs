using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.IO;
using GESTCRM.Clases;


namespace GESTCRM.Formularios
{
    public partial class frmPropuestaPedido : Form
    {
        private const string K_CAMP_FLE = "24"; //flexible
        private const string K_CAMP_L45 = "61"; //lineal45
        private const string K_LIN = "LIN";

        private const int K_POS_COD = 0;
        private const int K_POS_UNI = 1;
        private const int K_POS_DTO = 2;

        private SqlDataAdapter sqldaPropuestaMateriales;
        private SqlCommand sqlCmdPropuestaMateriales;
        private SqlCommand sqlGetCosteMat;
        private SqlCommand sqlCmdGetMaterialesNoRentabilidad;
        private SqlCommand sqlCmdGetRentabilidadDescripcion;
        private SqlCommand sqlCmdGetRentabilidadColor;
        private SqlDataAdapter sqldaListaAccMarkCampByCli;
        private SqlCommand sqlCmdListaAccMarkCampByCli;
        private SqlDataAdapter sqlDaListaMateriales;
        private SqlCommand sqlSelectListaMateriales;
        private SqlDataAdapter sqldaListaCampanyas;
        private SqlCommand sqlCmdListaCampanyas;
        private SqlCommand sqlCmdListaCampanyasNEW; //---- GSG (05/07/2017)
        


        private int Var_iIdCliente;
        private string[] _lMatsNoRenta;
        private bool _bEsClienteConAccMark = false;
        List<string[]> _propuesta = new List<string[]>();
        private string _iIdCampanya = K_CAMP_FLE; //Campaña por defecto. Sólo se modifica en el caso de clientes con AccMark
        private bool _bTodos = false;

        private ExportToExcel oExportExcel; //---- GSG (12/03/2014)
        private bool _bCeldaModificada = false; //---- GSG (01/04/2014)
        

        public frmPropuestaPedido()
        {
            InitializeComponent();


            //---- GSG (06/03/2021)
            Utiles.GetConfigConnection();
            this.sqlConn.ConnectionString = Utiles._connection.ConnectionString.ToString();

            
            this.dgvMats.RowsDefaultCellStyle.SelectionBackColor = Utiles.ColorSelecionFilaDataGrid;
        }

        private void frmPropuestaPedido_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                lblAvisoVersion.Text = System.Configuration.ConfigurationManager.AppSettings["AvisoVersion"].ToString(); //---- GSG (14/02/2014)

                Utiles.Formato_Formulario(this);
                if (this.Parent == null) this.WindowState = FormWindowState.Normal;

                if (this.Parent == null)
                    this.WindowState = FormWindowState.Normal;

                this.Var_iIdCliente = -1;

                txtbCobertura.Text = "1";

                ObtenirMaterialsNoRentabilitat();

            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }

            Cursor.Current = Cursors.Default;
            
        }


        private void CargarDatos()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                this.dsMateriales1.PropuestaPedido.Rows.Clear();

                if (this.Var_iIdCliente != -1 && int.Parse(txtbCobertura.Text) > 0)
                {
                    this.sqldaPropuestaMateriales.SelectCommand.Parameters["@iIdCliente"].Value = this.Var_iIdCliente;
                    this.sqldaPropuestaMateriales.SelectCommand.Parameters["@iDiasCobertura"].Value = int.Parse(txtbCobertura.Text);

                    this.sqldaPropuestaMateriales.Fill(dsMateriales1);
                }
                else if (this.Var_iIdCliente == -1)
                    Mensajes.ShowInformation("No se ha indicado el cliente. Seleccione un cliente e inténtelo de nuevo.");
                else if (int.Parse(txtbCobertura.Text) <= 0)
                    Mensajes.ShowInformation("La cobertura debe tener un valor superior a 0.");

                this.lblNumReg.Text = this.dsMateriales1.PropuestaPedido.Rows.Count.ToString();
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
            Cursor.Current = Cursors.Default;
        }

        
        private void CalcularTotales()
        {
            double Neto = 0.0;
            double Bruto = 0.0;
            double Descuento = 0.0;
            int iNumUnitatsPedido = 0;


            foreach (DataGridViewRow dr in dgvMats.Rows)
            {
                if (dr.Cells["selected"].Value != null && dr.Cells["selected"].Value.ToString().Trim() != "") //---- GSG (06/06/2014)
                {
                    if (bool.Parse(dr.Cells["selected"].Value.ToString()) == true) //---- GSG (06/06/2014)
                    {
                        int iCant = 0;
                        double fDesc = 0;

                        if (dr.Cells["cantidad"].Value.ToString() != "")
                            iCant = int.Parse(dr.Cells["cantidad"].Value.ToString());

                        if (dr.Cells["descmedio"].Value.ToString() != "")
                            fDesc = double.Parse(dr.Cells["descmedio"].Value.ToString());

                        double brulin = double.Parse(dr.Cells["fPrecio"].Value.ToString()) * iCant;
                        Bruto += brulin;
                        Neto += (brulin - ((brulin * fDesc) / 100));
                        iNumUnitatsPedido += iCant;
                    }
                }
            }

            if (Bruto != 0.0)
                Descuento = (1 - (Neto / Bruto)) * 100;
            else
                Descuento = 0.0;

            txbImporte.Text = Neto.ToString("C2");
            txbImporteBruto.Text = Bruto.ToString("C2");
            txbDto.Text = String.Format("{0:#,0.##}%", Descuento);

            ActualizarRentabilidad();

            //---- GSG (01/04/2014)
            pintaRentabilidadAnual(Var_iIdCliente, DateTime.Today);
        }


        private void ActualizarRentabilidad()
        {
            Color cColor = Color.FromArgb(238, 243, 246);
            float Renta = Calcular_Rentabilidad();

            if (!float.IsNaN(Renta))
            {
                //---- GSG (11/11/2014) Añade fecha para vigencia tramos
                txbRentabilidad.Text = CalcularDescripcionRentabilidad(Renta, DateTime.Today);
                cColor = CalcularColorRentabilidad(Renta, DateTime.Today);
                txbRentabilidad.ForeColor = cColor; //---- GSG (23/06/2017)
            }
            else
            {
                //---- GSG (23/06/2017)
                //txbRentabilidad.Text = "Sin catalogar";
                txbRentabilidad.Text = "No cuenta";
                cColor = Color.Black;
                txbRentabilidad.ForeColor = Color.White;
            }

            txbRentabilidad.BackColor = cColor;
        }

        private float Calcular_Rentabilidad()
        {
            float rentabilitat = 0.0F;
            float denominador = 0.0F;
            int quants = 0;

            foreach (DataGridViewRow dr in dgvMats.Rows)
            {
                if (dr.Cells["selected"].Value != null && bool.Parse(dr.Cells["selected"].Value.ToString()) && dr.Cells["cantidad"].Value.ToString() != "") //Sólo los materiales seleccionados y que tienen cantidad, el resto no estarán en la propuesta de pedido
                {
                    if (!Comun.IsInTheArray(dr.Cells["sIdMaterial"].Value.ToString(), _lMatsNoRenta))
                    {
                        int iCantidad = int.Parse(dr.Cells["cantidad"].Value.ToString());
                        float fPrecio = float.Parse(dr.Cells["fPrecio"].Value.ToString());
                        float fDescuento = 0;
                        if (dr.Cells["descmedio"].Value != System.DBNull.Value)
                            fDescuento = float.Parse(dr.Cells["descmedio"].Value.ToString());
                        float fCoste = GetCosteMaterial(dr.Cells["sIdMaterial"].Value.ToString());

                        rentabilitat += DameNominadorRentabilidad(iCantidad, fPrecio, fDescuento, fCoste);
                        denominador += DameDenominadorRentabilidad(iCantidad, fPrecio);

                        quants++;
                    }
                }
            }

            float res = 0.0F;
            if (!(denominador == 0 && rentabilitat != 0))   //Aquest cas donaria -Infinity i al retorna no queda controlat per float.isNAN
                res = (rentabilitat / denominador) * 100.0F;

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
                //_lMatsNoRenta = new string[200];
                _lMatsNoRenta = new string[2000];

                //---- GSG CECL 19/05/2016
                if (System.Configuration.ConfigurationManager.AppSettings["TipoDelegadoPedidosCentral"].ToString() == Comun.K_CECL)
                    sqlCmdGetMaterialesNoRentabilidad.CommandText = "[GetMaterialesNoRentabilidadCECL]";
                else
                    sqlCmdGetMaterialesNoRentabilidad.CommandText = "[GetMaterialesNoRentabilidad]";
                //---- FI GSG CECL 


                sqlCmdGetMaterialesNoRentabilidad.Parameters["@sIdPedido"].Value = ""; //---- GSG (01/04/2016)
                dr = sqlCmdGetMaterialesNoRentabilidad.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        mat = dr["sIdMaterial"].ToString().Trim();
                        _lMatsNoRenta[comptador] = mat;
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

        //---- GSG (11/11/2014) Añade fecha vigencia de tramos
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

        //---- GSG (11/11/2014) Añade fecha vigencia de tramos
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

        private float GetCosteMaterial(string sCodSAP)
        {
            float fRet = 0;

            if (sqlConn.State == ConnectionState.Closed)
                this.sqlConn.Open();

            SqlTransaction sqlTran = this.sqlConn.BeginTransaction();

            this.sqlGetCosteMat.Transaction = sqlTran;

            try
            {
                this.sqlGetCosteMat.Parameters["@sIdMaterial"].Value = sCodSAP;
                this.sqlGetCosteMat.ExecuteNonQuery();

                fRet = float.Parse(this.sqlGetCosteMat.Parameters["@Ret"].Value.ToString());
            }
            catch (Exception e)
            {
                Mensajes.ShowError(e.Message);
            }


            this.sqlConn.Close();

            return fRet;
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


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //---- GSG (01/04/2014)
            //CargarDatos();
            //CalcularTotales();
            //FormatBuscarCampanyas(this.Var_iIdCliente, true);

            bool bCarga = true;
           
            if (_bCeldaModificada)
            {
                DialogResult dr = Mensajes.ShowQuestion("Ha modificado la cantidad de algún material, si continúa los cambios se perderán. ¿Desea continuar?");
                if (dr == DialogResult.No)
                    bCarga = false;
            }

            if (bCarga)
            {
                CargarDatos();
                CalcularTotales();
                //---- GSG (05/07/2017)
                //FormatBuscarCampanyas(this.Var_iIdCliente, true);
                FormatBuscarCampanyas();

                chkbMarcar.Checked = false;
                chkbMarcar.Checked = true;
                _bCeldaModificada = false;
            }
        }


        private void btAceptar_Click(object sender, EventArgs e)
        {
            if (!GESTCRM.Utiles.MirarSiAbierto(this, "frmPedidos"))
            {
                GuardarLins();

                if (_bEsClienteConAccMark)
                    _iIdCampanya = cBoxCampanyas.SelectedValue.ToString();

                //Carga materiales de la campanya seleccionada
                this.sqlDaListaMateriales.SelectCommand.Parameters["@iIdCamp"].Value = _iIdCampanya;
                this.sqlDaListaMateriales.Fill(dsMateriales1.ListaMateriales);

                EnviarMatsAPedido();
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

        private void btCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ev)
            {
                Mensajes.ShowError("Error al salir: " + ev.Message);
            }
        }

        private void GuardarLins()
        {
            char cSeparador = ';';

            foreach (DataGridViewRow dr in dgvMats.Rows)
            {
                if (dr.Cells["selected"].Value != null && dr.Cells["selected"].Value.ToString().Trim() != "") //---- GSG (27/03/2014)
                {
                    if (bool.Parse(dr.Cells["selected"].Value.ToString()) == true) //---- GSG (27/03/2014)
                    {
                        if (dr.Cells["cantidad"].Value.ToString() != "") //Sólo los materiales que tienen cantidad el resto no estarán en la propuesta de pedido
                        {
                            string strLinea = dr.Cells["sCodNacional"].Value.ToString() + cSeparador + dr.Cells["cantidad"].Value.ToString() + cSeparador + dr.Cells["descmedio"].Value.ToString();
                            _propuesta.Add(strLinea.Split(cSeparador));
                        }
                    }
                }
            }
        }

        private void EnviarMatsAPedido()
        {
            //---- GSG (12/12/2014)
            //frmPedidos frmTemp = new Formularios.frmPedidos(txtsIdCliente.Text, Var_iIdCliente, txtsCliente.Text, _iIdCampanya);
            frmPedidos frmTemp = new Formularios.frmPedidos(txtsIdCliente.Text, Var_iIdCliente, txtsCliente.Text, _iIdCampanya, "");
            
            frmTemp.MdiParent = this.MdiParent;
            frmTemp.Show();

            this.Close();


            if (frmTemp.cBoxCampanyas.Items.Count > 0) //---- GSG (06/03/2018)
            {
                //Abrir pantalla selección de materiales     
                DataRowView rowView;

                dsFormularios1.ListaCampanyasAux.DefaultView.Sort = "NombreCampanya";

                if (_bEsClienteConAccMark)
                    rowView = dsFormularios1.ListaCampanyasAux.DefaultView[frmTemp.cBoxCampanyas.SelectedIndex];
                else
                    rowView = dsFormularios1.ListaCampanyas.DefaultView[frmTemp.cBoxCampanyas.SelectedIndex];

                frmTemp.BuscarMateriales(rowView.Row, _propuesta, K_POS_COD, K_POS_UNI, K_POS_DTO);
            }
            else //---- GSG (06/03/2018)
            {
                frmTemp.cBoxCampanyas.Enabled = false;
                frmTemp.btnBuscarMaterial.Enabled = false;
            }
        }


        //---- GSG (05/07/2017)
        /*
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


        private void LlenarComboCampanyas(int tipo, string campanya)
        {
            dsFormularios1.ListaCampanyas.Clear();

            sqldaListaCampanyas.SelectCommand.Parameters["@iTipo"].Value = tipo;
            sqldaListaCampanyas.SelectCommand.Parameters["@idCampanya"].Value = campanya;
            sqldaListaCampanyas.SelectCommand.Parameters["@tipoCampanya"].Value = K_LIN;
            sqldaListaCampanyas.SelectCommand.Parameters["@sIdDelegado"].Value = Clases.Configuracion.iIdDelegado.ToString();
            sqldaListaCampanyas.SelectCommand.Parameters["@sIdTipoPedido"].Value = "ZDIR";

            sqldaListaCampanyas.Fill(dsFormularios1.ListaCampanyas);
            dsFormularios1.ListaCampanyas.DefaultView.RowFilter = "bSeleccionable = 1";
            dsFormularios1.ListaCampanyas.DefaultView.Sort = "NombreCampanya"; //---- GSG (14/07/2014)
            cBoxCampanyas.DataSource = dsFormularios1.ListaCampanyas.DefaultView;
            cBoxCampanyas.SelectedIndex = 0; //---- GSG (14/07/2014)
        }

        private void LlenarComboCampanyas(int tipo, string[] campanyas)
        {
            dsFormularios1.ListaCampanyas.Clear();

            for (int i = 0; i < campanyas.Length; i++)
            {
                sqldaListaCampanyas.SelectCommand.Parameters["@iTipo"].Value = tipo;
                sqldaListaCampanyas.SelectCommand.Parameters["@idCampanya"].Value = campanyas[i];
                sqldaListaCampanyas.SelectCommand.Parameters["@tipoCampanya"].Value = K_LIN;
                sqldaListaCampanyas.SelectCommand.Parameters["@sIdDelegado"].Value = Clases.Configuracion.iIdDelegado.ToString();
                sqldaListaCampanyas.SelectCommand.Parameters["@sIdTipoPedido"].Value = "ZDIR";

                sqldaListaCampanyas.Fill(dsFormularios1.ListaCampanyas);

                //cambio el tipo para que no rpite las campanyas extras
                tipo = 3;

            }

            dsFormularios1.ListaCampanyas.DefaultView.RowFilter = "bSeleccionable = 1";
            dsFormularios1.ListaCampanyas.DefaultView.Sort = "NombreCampanya"; //---- GSG (14/07/2014)
            cBoxCampanyas.DataSource = dsFormularios1.ListaCampanyas.DefaultView;
            cBoxCampanyas.SelectedIndex = 0; //---- GSG (14/07/2014)
        }


        private void llenarCampanyasAux(int tipo, string[] campanyas)
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
            dsFormularios1.ListaCampanyas.DefaultView.Sort = "NombreCampanya"; //---- GSG (14/07/2014)
        }

        */

        private bool FormatBuscarCampanyas()
        {
            bool bRet = false;

            LlenarComboCampanyas(Clases.Configuracion.iIdDelegado.ToString(), "ZDIR", Var_iIdCliente, "XXXX");

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
                bRet = false;

            return bRet;
        }



        //---- GSG (12/03/2014)
        private void btExportar_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            string folder = System.Configuration.ConfigurationManager.AppSettings["TargetFolderExcel"].ToString();
            string fitxerXLSX = folder + "datos_" + DateTime.Now.Year.ToString() + String.Format("{00}", DateTime.Now.Month.ToString()) + DateTime.Now.Day.ToString() + "_" + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".xlsx";
           // "{0:#,0.##}%"
            List<string> cabecera = new List<string>();
            List<string[]> lineas = new List<string[]>();

            cabecera.Add("Cod. Nacional");
            cabecera.Add("Descripción");
            cabecera.Add("Unidades");

            foreach (DataGridViewRow row in dgvMats.Rows)
            {
                if (row.Cells["selected"].Value != null && row.Cells["selected"].Value.ToString().Trim() != "") //---- GSG (27/03/2014)
                {
                    if (bool.Parse(row.Cells["selected"].Value.ToString()) == true) //---- GSG (27/03/2014)
                    {
                        string[] lin = new string[3];

                        lin[0] = row.Cells["sCodNacional"].Value.ToString();
                        lin[1] = row.Cells["sMaterial"].Value.ToString();
                        if (row.Cells["cantidad"].Value.ToString() != "")
                            lin[2] = row.Cells["cantidad"].Value.ToString();
                        else
                            lin[2] = "0";

                        lineas.Add(lin);
                    }
                }
            }

            DirectoryInfo dir = new DirectoryInfo(folder);
            if (!dir.Exists)
            {
                dir.Create();
            }

            oExportExcel = new ExportToExcel(fitxerXLSX, "Ventas", "", "", "", cabecera, lineas);

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

        //---- GSG (27/03/2014)
        private void chkbMarcar_CheckedChanged(object sender, EventArgs e)
        {
            _bTodos = !_bTodos;

            foreach (DataGridViewRow dr in dgvMats.Rows)
            {
                dr.Cells["selected"].Value = _bTodos;
            }
            
            CalcularTotales();
        }

        //---- GSG (01/04/2014)
        //---- GSG (11/11/2014) Añade fecha tramos
        private void pintaRentabilidadAnual(int iIdCliente, DateTime fecha)
        {
            float rentAnual = Calcular_Rentabilidad_Anual(iIdCliente);
            txtRentAA.BackColor = CalcularColorRentabilidad(rentAnual, fecha);
        }

        private float Calcular_Rentabilidad_Anual(int iIdCliente)
        {
            float rentabilitat = 0.0F;
            float denominador = 0.0F;
            int quants = 0;

            //Obtener datos 
            dtLineasPedidoRentAnual = new dsMateriales.ListaLineasPedidoRentAnualDataTable();
            dsMateriales1.ListaLineasPedidoRentAnual.Rows.Clear();
            sqldaListaLineasPedidoRentAnual.SelectCommand.Parameters["@iIdCliente"].Value = iIdCliente;
            Application.DoEvents();
            sqldaListaLineasPedidoRentAnual.Fill(dtLineasPedidoRentAnual);
            Application.DoEvents();


            //Calclular rentabilidad
            //dtLineasPedidoRentAnual contiene todas las líneas a tener en cuenta (la consulta ya ha excluido las que no)
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

                quants++;
            }

            float res = 0.0F;
            if (denominador != 0)   //Aquest cas donaria -Infinity 
                res = (rentabilitat / denominador) * 100.0F;

            return res;
        }

        private void dgvMats_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            if (e.ColumnIndex == dgvMats.Rows[e.RowIndex].Cells["cantidad"].ColumnIndex)
            {
                if (!Utiles.EsNumero(e.Value.ToString()))
                {
                    dgvMats.RefreshEdit();
                }
                else
                    dgvMats.Rows[e.RowIndex].Cells["selected"].Value = true;
            }
            
        }

        private void dgvMats_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.ColumnIndex == dgvMats.Columns["cantidad"].Index) //Unidades
                Mensajes.ShowError("El dato introducido no tiene el formato correcto.\r\nLa cantidad debe ser un número entero. No se guardará el valor introducido.");
            else
                Mensajes.ShowError("Error: " + e.Exception);
        }


        //---- GSG (13/05/2014)
        private void dgvMats_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string sCodNacional = dgvMats.Rows[e.RowIndex].Cells["sCodNacional"].Value.ToString();
            string sMaterial = dgvMats.Rows[e.RowIndex].Cells["sMaterial"].Value.ToString();

            if (e.ColumnIndex == dgvMats.Columns["cantidad"].Index)
            {
                Comun.showGraphQty(Var_iIdCliente, sCodNacional, sMaterial);
            }
            else if (e.ColumnIndex == dgvMats.Columns["descmedio"].Index)
            {
                //No tenemos campaña por lo que no podemos tener el descuento máximo.
                double fDescMaxCamp = -1;

                Comun.showGraphDesc(Var_iIdCliente, sCodNacional, sMaterial, fDescMaxCamp);
            }
        }

        private void dgvMats_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > 0)
            {
                if (e.ColumnIndex == dgvMats.Rows[e.RowIndex].Cells["selected"].ColumnIndex)
                {
                    //---- GSG (06/03/2021)
                    //gvMats.Rows[e.RowIndex].Cells["selected"].Value = !bool.Parse(dgvMats.Rows[e.RowIndex].Cells["selected"].Value.ToString());
                    if (dgvMats.Rows[e.RowIndex].Cells["selected"].Value == null)
                        dgvMats.Rows[e.RowIndex].Cells["selected"].Value = true;
                    else
                        dgvMats.Rows[e.RowIndex].Cells["selected"].Value = !bool.Parse(dgvMats.Rows[e.RowIndex].Cells["selected"].Value.ToString());


                    CalcularTotales();
                }
            }
        }

        private void dgvMats_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvMats.Rows[e.RowIndex].Cells["cantidad"].ColumnIndex)
            {
                CalcularTotales();
            }
        }
      
    }
}
