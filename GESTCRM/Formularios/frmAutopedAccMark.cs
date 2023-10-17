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
    public partial class frmAutopedAccMark : Form
    {
        private int Var_iIdCliente;
        //---- GSG (23/11/2016)
        private List<ValuesProd> _tValuesProdEnPed = new List<ValuesProd>();
        private List<ParejasExclusion> _listaExclusion = new List<ParejasExclusion>();
        private DataSets.dsAccionesMarketing.ListaLinsAutoPedsSinAccMarkDataTable dtLineasPedido;
        double _rentabilidadPedido = 0;
        //---- GSG (06/03/2021)
        private List<ParejasAccionesMKT> _listaAccMarkProfitPlus = new List<ParejasAccionesMKT>();
        private List<ParejasAccionesMKT> _listaAccMarkAPicking = new List<ParejasAccionesMKT>();

        public frmAutopedAccMark()
        {
            InitializeComponent();


            //---- GSG (06/03/2021)
            Utiles.GetConfigConnection();
            this.sqlConn.ConnectionString = Utiles._connection.ConnectionString.ToString();

            
            this.dataGridViewAccMark.RowsDefaultCellStyle.SelectionBackColor = Utiles.ColorSelecionFilaDataGrid;
            this.dgvPeds.RowsDefaultCellStyle.SelectionBackColor = Utiles.ColorSelecionFilaDataGrid;
            //---- GSG (13/07/2015)
            this.dataGridViewImportes.RowsDefaultCellStyle.SelectionBackColor = Utiles.ColorSelecionFilaDataGrid;
            this.dataGridViewAsignaciones.RowsDefaultCellStyle.SelectionBackColor = Utiles.ColorSelecionFilaDataGrid;
        }


        private void frmAutopedAccMark_Load(object sender, EventArgs e)
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

                //---- GSG (23/11/2016)
                dtLineasPedido = new DataSets.dsAccionesMarketing.ListaLinsAutoPedsSinAccMarkDataTable(); 
                _listaExclusion = GetAccMarkExcluidas();
                foreach (DataGridViewRow row in dataGridViewAccMark.Rows)
                {
                    row.Cells["selected"].Value = false;
                }

                //---- GSG (06/03/2021)
                _listaAccMarkProfitPlus = GetCodsAccMarkPedido();
                _listaAccMarkAPicking = GetCodsAccMarkPedidoPicking();
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }

            Cursor.Current = Cursors.Default;
        }


        //---- GSG (23/11/2016)
        //private void CargarAccMark()
        //{
        //    //Inicialitza grid Acciones Marketing
        //    this.sqldaListaAccionesMarketing.SelectCommand.Parameters["@sIdTipoAccion"].Value = "3";


        //    //---- GSG (19/09/2016)
        //    this.sqldaListaAccionesMarketing.SelectCommand.Parameters["@sIdProducto"].Value = null;
        //    this.sqldaListaAccionesMarketing.SelectCommand.Parameters["@iUnidadesSel"].Value = -1;
        //    this.sqldaListaAccionesMarketing.SelectCommand.Parameters["@fImporteSel"].Value = -1;
        //    this.sqldaListaAccionesMarketing.SelectCommand.Parameters["@fRentabSel"].Value = -1;
        //    this.sqldaListaAccionesMarketing.SelectCommand.Parameters["@bIndepe"].Value = null;
        //    this.sqldaListaAccionesMarketing.SelectCommand.Parameters["@iActivoPara"].Value = 2;
        //    //---- FI GSG

        //    this.sqldaListaAccionesMarketing.Fill(dsAccMark);
        //    UpdateDataGridView();
        //    //---- GSG (18/06/2015)
        //    CargarImportes();
        //    CargarAsignaciones();
        //}


        private void CargarAccMark()
        {
            try
            {
                dsAccMark.ListaAccionesMarketing.Clear();

                // En cada vuelta añade las acciones que se pueden mostrar para cada producto existente en el pedido
                // @sIdTipoAccion varchar(10) = null, --la acción tipo 3 es la que está afectada por los siguientes filtros.El resto continuará como siempre
                // @sIdProducto    varchar(10) = null, --acciones asociadas al producto o acciones no asociadas a ningún producto si null
                // @iUnidadesSel   int = 0, --unidades totales del pedido si @sIdProducto = null o unidades del producto en caso contrario
                // @fImporteSel    float = 0, --importe total del pedido o importe del producto
                // @fRentabSel     float = 0, --rentabilidad total o producto
                // @bIndepe        bit = null, --si 1 especiales, 0 no-- si null estamos llamando desde otros sitios que no son la creación o consulta de pedido para acciones tipo 3
                // @iActivoPara    int = 0-- 0 cualquier formulario, 1 pedidos, 2 autopedidos


                // 1.- añade acciones para líneas cuyo producto tiene acciones asociadas
                foreach (ValuesProd val in _tValuesProdEnPed)
                {
                    this.sqldaListaAccionesMarketing.SelectCommand.Parameters["@sIdTipoAccion"].Value = "3";
                    this.sqldaListaAccionesMarketing.SelectCommand.Parameters["@sIdProducto"].Value = val.sIdProducto;
                    this.sqldaListaAccionesMarketing.SelectCommand.Parameters["@iUnidadesSel"].Value = val.iCantidad;
                    this.sqldaListaAccionesMarketing.SelectCommand.Parameters["@fImporteSel"].Value = val.fImporte;
                    this.sqldaListaAccionesMarketing.SelectCommand.Parameters["@fRentabSel"].Value = val.fRentabilidad;
                    this.sqldaListaAccionesMarketing.SelectCommand.Parameters["@bIndepe"].Value = 0;
                    this.sqldaListaAccionesMarketing.SelectCommand.Parameters["@iActivoPara"].Value = 2;

                    this.sqldaListaAccionesMarketing.Fill(dsAccMark);
                }

                // 2.- Añade acciones que no están asociadas a ningún producto
                float fBrutoPedido = float.Parse(txtbBrutoPedAM.Text.Replace('€', ' ').Trim());
                float fRentPedido = float.Parse(_rentabilidadPedido.ToString());
                if (float.IsNaN(fRentPedido))
                    fRentPedido = 0;

                int iCantidadPedido = 0;
                foreach (ValuesProd val in _tValuesProdEnPed)
                    iCantidadPedido += val.iCantidad;

                this.sqldaListaAccionesMarketing.SelectCommand.Parameters["@sIdTipoAccion"].Value = "3";
                this.sqldaListaAccionesMarketing.SelectCommand.Parameters["@sIdProducto"].Value = null;
                this.sqldaListaAccionesMarketing.SelectCommand.Parameters["@iUnidadesSel"].Value = iCantidadPedido;
                this.sqldaListaAccionesMarketing.SelectCommand.Parameters["@fImporteSel"].Value = fBrutoPedido;
                this.sqldaListaAccionesMarketing.SelectCommand.Parameters["@fRentabSel"].Value = fRentPedido;
                this.sqldaListaAccionesMarketing.SelectCommand.Parameters["@bIndepe"].Value = 0;
                this.sqldaListaAccionesMarketing.SelectCommand.Parameters["@iActivoPara"].Value = 2;

                this.sqldaListaAccionesMarketing.Fill(dsAccMark);

                // 3.- Añade las acciones especiales (independientes de todo filtro)
                this.sqldaListaAccionesMarketing.SelectCommand.Parameters["@sIdTipoAccion"].Value = "3";
                this.sqldaListaAccionesMarketing.SelectCommand.Parameters["@sIdProducto"].Value = null;
                this.sqldaListaAccionesMarketing.SelectCommand.Parameters["@iUnidadesSel"].Value = 0;
                this.sqldaListaAccionesMarketing.SelectCommand.Parameters["@fImporteSel"].Value = 0;
                this.sqldaListaAccionesMarketing.SelectCommand.Parameters["@fRentabSel"].Value = 0;
                this.sqldaListaAccionesMarketing.SelectCommand.Parameters["@bIndepe"].Value = 1;
                this.sqldaListaAccionesMarketing.SelectCommand.Parameters["@iActivoPara"].Value = 2;

                this.sqldaListaAccionesMarketing.Fill(dsAccMark);

                UpdateDataGridView();
                CargarImportes();
                CargarAsignaciones();
            }
            catch (Exception e)
            {
                Mensajes.ShowError(e.ToString());
            }
        }


        //---- GSG (06/03/2021)
        private List<ParejasAccionesMKT> GetCodsAccMarkPedido()
        {
            List<ParejasAccionesMKT> lRet = new List<ParejasAccionesMKT>();
            try
            {
                this.dsAccMark.ListaCodigosAccMark.Rows.Clear();

                this.sqldaCodsAccMark.Fill(this.dsAccMark);

                if (this.dsAccMark.ListaCodigosAccMark.Rows.Count > 0)
                {
                    foreach (GESTCRM.Formularios.DataSets.dsAccionesMarketing.ListaCodigosAccMarkRow row in dsAccMark.ListaCodigosAccMark.Rows)
                    {
                        ParejasAccionesMKT pe = new ParejasAccionesMKT(row.iIdAccion, row.sIdAccion);
                        lRet.Add(pe);
                    }
                }
            }
            catch (Exception error) { }

            return lRet;
        }

        private List<ParejasAccionesMKT> GetCodsAccMarkPedidoPicking()
        {
            List<ParejasAccionesMKT> lRet = new List<ParejasAccionesMKT>();
            try
            {
                this.dsAccMark.ListaCodigosAccMarkPicking.Rows.Clear();

                this.sqldaCodsAccMarkPicking.SelectCommand.Parameters["@sIdTipoPedido"].Value = "ZDIW";  // Serviría también poner ZTRW

                this.sqldaCodsAccMarkPicking.Fill(this.dsAccMark);

                if (this.dsAccMark.ListaCodigosAccMarkPicking.Rows.Count > 0)
                {
                    foreach (GESTCRM.Formularios.DataSets.dsAccionesMarketing.ListaCodigosAccMarkPickingRow row in dsAccMark.ListaCodigosAccMarkPicking.Rows)
                    {
                        ParejasAccionesMKT pe = new ParejasAccionesMKT(row.iIdAccion, row.sIdAccion);
                        lRet.Add(pe);
                    }
                }
            }
            catch (Exception error) { }

            return lRet;
        }


        #region pestanya Asignar

        private void btBuscarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                //GESTCRM.Formularios.Busquedas.frmMClientesSAP frmBCli = new GESTCRM.Formularios.Busquedas.frmMClientesSAP(false, "A");
                GESTCRM.Formularios.Busquedas.frmMClientesSAPAutopedAccMark frmBCli = new GESTCRM.Formularios.Busquedas.frmMClientesSAPAutopedAccMark();

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
            CargarPedidos();

            //---- GSG (23/11/2016)
            CargarLinsPedidos(); 
            GetValuesProdEnPedido();
            //---- FI GSG 


            CalcularTotales();

            if (this.dsAccMark.ListaAutoPedsSinAccMark.Rows.Count > 0)
                CargarAccMark();
            else
                foreach (DataGridViewRow row in dataGridViewAccMark.Rows)
                {
                    dataGridViewAccMark.CurrentCell = null;

                    row.Visible = false;
                    row.Cells["selected"].Value = false;
                }
        }


        private void CargarPedidos()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                this.dsAccMark.ListaAutoPedsSinAccMark.Rows.Clear();

                if (this.Var_iIdCliente != -1)
                {
                    this.sqldaListaAutoPedsSinAccMark.SelectCommand.Parameters["@iIdDelegado"].Value = Convert.ToInt32(Clases.Configuracion.ValorConf(1)); 
                    this.sqldaListaAutoPedsSinAccMark.SelectCommand.Parameters["@iIdCliente"].Value = this.Var_iIdCliente;

                    this.sqldaListaAutoPedsSinAccMark.Fill(dsAccMark);
                }
                else if (this.Var_iIdCliente == -1)
                    Mensajes.ShowInformation("No se ha indicado el cliente. Seleccione un cliente e inténtelo de nuevo.");

                this.lblNumReg.Text = this.dsAccMark.ListaAutoPedsSinAccMark.Rows.Count.ToString();
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
            Cursor.Current = Cursors.Default;
        }

        //---- GSG (23/11/2016)
        private void CargarLinsPedidos()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                this.dsAccMark.ListaLinsAutoPedsSinAccMark.Rows.Clear();
                dtLineasPedido.Clear();

                if (dgvPeds.Rows.Count > 0) // Si no hay pedidos no hace falta
                {
                    this.sqldaListaLinsAutoPedsSinAccMark.SelectCommand.Parameters["@iIdDelegado"].Value = Convert.ToInt32(Clases.Configuracion.ValorConf(1));
                    this.sqldaListaLinsAutoPedsSinAccMark.SelectCommand.Parameters["@iIdCliente"].Value = this.Var_iIdCliente;

                    this.sqldaListaLinsAutoPedsSinAccMark.Fill(dsAccMark);
                    this.sqldaListaLinsAutoPedsSinAccMark.Fill(dtLineasPedido);
                }
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
            Cursor.Current = Cursors.Default;
        }



        //---- GSG (23/11/2016)
        //private void CalcularTotales()
        //{
        //    double BrutoTotal = 0.0;

        //    foreach (DataGridViewRow dr in dgvPeds.Rows)
        //    {
        //        BrutoTotal += double.Parse(dr.Cells["fImporteBruto"].Value.ToString());
        //    }

        //    txbImporteBruto.Text = String.Format("{0:#,0.##} €", BrutoTotal);
        //}

        private void CalcularTotales()
        {
            double BrutoTotal = 0.0;
            double NetoTotal = 0.0;
            double Descuento = 0.0;
            float costeAM = 0;

            foreach (DataGridViewRow dr in dgvPeds.Rows)
            {
                BrutoTotal += double.Parse(dr.Cells["fImporteBruto"].Value.ToString());
                NetoTotal += double.Parse(dr.Cells["fImporteNeto"].Value.ToString());
            }

            txtbBrutoPedAM.Text = String.Format("{0:#,0.##} €", BrutoTotal);
            if (BrutoTotal != 0.0)
                Descuento = ((BrutoTotal - NetoTotal) / BrutoTotal) * 100;
            else
                Descuento = 0.0;

            txtbDescMedioAM.Text = String.Format("{0:#,0.##}%", Descuento);

            int numMaxAccMark = GetMaxAccMark(float.Parse(BrutoTotal.ToString()));

            if (numMaxAccMark < 100)
                lblMissAM.Text = "Según el importe del pedido, el número máximo de acciones de márketing que se pueden seleccionar es: " + numMaxAccMark.ToString();
        


            foreach (DataGridViewRow row in dataGridViewAccMark.Rows)
            {
                
                if (row.Cells["selected"].Value != null && row.Cells["selected"].Value.ToString() != "")
                {
                    //---- GSG (06/03/2021)  TIRO PARA ATRÁS PORQUE EN EL CÁLCULO SEGÚN COSTE DE ACCIONES DEBEN CONTAR TODAS. TODAS TIENEN COSTE 
                    if (bool.Parse(row.Cells["selected"].Value.ToString()) && !bool.Parse(row.Cells["bIndepe"].Value.ToString()))

                   // ParejasAccionesMKT lpeAux = _listaAccMarkProfitPlus.Find(x => (x.miembro_2 == row.Cells["sIdAccionDataGridViewTextBoxColumn"].Value.ToString()));

                    //if (bool.Parse(row.Cells["selected"].Value.ToString()) && 
                    //    !bool.Parse(row.Cells["bIndepe"].Value.ToString()) &&
                    //    lpeAux != null)
                        costeAM += (float.Parse(row.Cells["fCosteUnitarioDataGridViewTextBoxColumn"].Value.ToString()) * int.Parse(row.Cells["UnidadesAEntregar"].Value.ToString()));
                }
            }

            txtbCosteTotalAM.Text = costeAM.ToString("C2");



            //---- GSG (06/03/2021)
            float margenLab = 0;
            _rentabilidadPedido = 0;


            double brutoTotalRentabilidad = 0;

            for (int i = 0; i < dsAccMark.ListaLinsAutoPedsSinAccMark.Rows.Count - 1; i++)
            {
                // numerador
                DataSets.dsAccionesMarketing.ListaLinsAutoPedsSinAccMarkRow row = (DataSets.dsAccionesMarketing.ListaLinsAutoPedsSinAccMarkRow)dsAccMark.ListaLinsAutoPedsSinAccMark.Rows[i];
                if (row.fBrutoRent > 0)
                {
                    _rentabilidadPedido += (row.fBrutoRent - row.vdesc - row.fCoste);  // El coste ya viene multiplicado por las unidades
                    brutoTotalRentabilidad += row.fBrutoRent;
                }
            }

            margenLab = (float)_rentabilidadPedido; //---- GSG (06/03/2021) el numerador en el cálculo de la rentabilidad es el margen



            if (double.IsNaN(_rentabilidadPedido))
                _rentabilidadPedido = 0;

            if (brutoTotalRentabilidad != 0)
                _rentabilidadPedido = (_rentabilidadPedido / brutoTotalRentabilidad) * 100;

            float rentabilidad =  float.Parse(_rentabilidadPedido.ToString().Replace('.', ',')) - costeAM;

            // Busco el color de la rentabilidad
            Color cColor = Color.FromArgb(238, 243, 246);
            cColor = CalcularColorRentabilidad(rentabilidad, DateTime.Today); // En otras partes del programa ponemos la fecha del pedido pero aquí tenemos una suma de pedidos por lo que pongo fecha de hoy
            txtbRentabilidadAM.BackColor = cColor;

            //---- GSG (06/03/2021)
            float puntosAM = 0;

            if (Clases.Configuracion.iPuntosDividePor != 0)
                margenLab = (margenLab / Clases.Configuracion.iPuntosDividePor) * Clases.Configuracion.iPuntosMultiplicaPor;  // Puntos del pedido

            if (Clases.Configuracion.iPuntosDividePor != 0)
                puntosAM = (costeAM / Clases.Configuracion.iPuntosDividePor) * Clases.Configuracion.iPuntosMultiplicaPor;  //Puntos de las acciones seleccionadas

            txtbPuntosPedAM.Text = margenLab.ToString("N2");
            txtbPuntosPedConAM.Text = (margenLab - puntosAM).ToString("N2"); //Añadir acciones de mkt resta puntos porque tienen un coste
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


        //Selecciona las acciones que le tocarían por suma importes de pedidos que no tienen acciones de márketing asociadas
        //private void UpdateDataGridView()
        //{
        //    try
        //    {
        //        //actualitza el grid
        //        dataGridViewAccMark.DataSource = dsAccMark.ListaAccionesMarketing;

        //        foreach (DataGridViewRow row in dataGridViewAccMark.Rows)
        //            row.Cells["selected"].Value = false;


        //        float fBrutoTotalPedidos = 0;
        //        fBrutoTotalPedidos = float.Parse(txbImporteBruto.Text.Replace('€', ' ').Trim());

        //        foreach (DataGridViewRow row in dataGridViewAccMark.Rows)
        //        {
        //            int iNumMaxEntrega = 0;
        //            float fBrutoMin = 0;
        //            float fBrutoMax = 0;
        //            float fCosteAccMark = 0;

        //            if (row.Cells["iMaxAEntregar"].Value != null && row.Cells["iMaxAEntregar"].Value.ToString() != "")
        //                iNumMaxEntrega = int.Parse(row.Cells["iMaxAEntregar"].Value.ToString());

        //            if (row.Cells["fImpMin"].Value != null && row.Cells["fImpMin"].Value.ToString() != "")
        //                fBrutoMin = float.Parse(row.Cells["fImpMin"].Value.ToString());

        //            if (row.Cells["fImpMax"].Value != null && row.Cells["fImpMax"].Value.ToString() != "")
        //                fBrutoMax = float.Parse(row.Cells["fImpMax"].Value.ToString());

        //            fCosteAccMark = float.Parse(row.Cells["fCosteTotal"].Value.ToString());

        //            if (fCosteAccMark != 0)
        //            {
        //                int iUnidadesEntrega = (int)(fBrutoTotalPedidos / fCosteAccMark);
        //                if (iUnidadesEntrega <= iNumMaxEntrega)
        //                    row.Cells["UnidadesAEntregar"].Value = iUnidadesEntrega;
        //                else
        //                    row.Cells["UnidadesAEntregar"].Value = iNumMaxEntrega;
        //            }
        //            else
        //                row.Cells["UnidadesAEntregar"].Value = 0;
        //        }

        //        //Filtrar el grid para que sólo se vean las acciones que incluyen el bruto en sus márgenes
        //        DataRow[] rows = dsAccMark.ListaAccionesMarketing.Select("fImpMin <= " + fBrutoTotalPedidos.ToString().Replace(',', '.') + " and fImpMax >= " + fBrutoTotalPedidos.ToString().Replace(',', '.'));
        //        string accsVisibles = "";
        //        foreach (DataRow dr in rows)
        //        {
        //            accsVisibles += dr["iIdAccion"].ToString() + ",";
        //        }

        //        foreach (DataGridViewRow row in dataGridViewAccMark.Rows)
        //        {
        //            dataGridViewAccMark.CurrentCell = null;

        //            if (accsVisibles.IndexOf(row.Cells["iIdAccionDataGridViewTextBoxColumn"].Value.ToString() + ",") >= 0)
        //                row.Visible = true;
        //            else
        //            {
        //                row.Visible = false;
        //                row.Cells["selected"].Value = false;
        //            }
        //        }

        //        int nFilasVisibles = 0;
        //        if (rows != null)
        //            nFilasVisibles = rows.Length;

        //        this.lblNumRegAccMark.Text = nFilasVisibles.ToString() + " / " + dataGridViewAccMark.Rows.Count.ToString();

        //        dataGridViewAccMark.Refresh();

        //    }
        //    catch (Exception ex)
        //    {
        //        Mensajes.ShowError(ex.Message);
        //    }
        //}

        private void UpdateDataGridView()
        {
            try
            {
                //actualitza el grid
                dataGridViewAccMark.DataSource = dsAccMark.ListaAccionesMarketing;

                foreach (DataGridViewRow row in dataGridViewAccMark.Rows)
                    row.Cells["selected"].Value = false;
             

                float fBrutoTotalPedidos = 0;
                fBrutoTotalPedidos = float.Parse(txtbBrutoPedAM.Text.Replace('€', ' ').Trim());

                foreach (DataGridViewRow row in dataGridViewAccMark.Rows)
                {
                    row.Cells["UnidadesAEntregar"].Value = 1; // Por defecto ponemos 1
                }

                this.lblNumRegAccMark.Text = "0 / " + dataGridViewAccMark.Rows.Count.ToString();

                dataGridViewAccMark.Refresh();

            }
            catch (Exception ex)
            {
                Mensajes.ShowError(ex.Message);
            }
        }


        


        private void btAceptar_Click(object sender, EventArgs e)
        {
            //---- GSG (23/11/2016)
            //int iNumAccMarkSel = 0;
            //int iNumMaxAccMark = int.Parse(Clases.Configuracion.iMaxNumAccMark); //màximo número de selecciones
            //string codsAccMark = "";

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
                return;
            }
            //---- FI GSG
            else
            { 
                //---- GSG (23/11/2016)
                ////Guarda las seleccionadas
                //foreach (DataGridViewRow row in dataGridViewAccMark.Rows) 
                //{
                //    if (row.Cells["selected"].Value != null && row.Cells["selected"].Value.ToString() != "")
                //    {
                //        if (bool.Parse(row.Cells["selected"].Value.ToString()) == true)
                //        {
                //            iNumAccMarkSel++;
                //            codsAccMark += "'" + row.Cells["sIdAccionDataGridViewTextBoxColumn"].Value.ToString() + "',";
                //        }
                //    }
                //}

                //// Hay algunas acciones de márketing que deben excluirse del contador. Para hacerlo rápido y fácil, llamaremos a una stored
                //// que retornará el valor iNumAccMarkSel modificado si se ha contabilizado alguna de dichas acciones.
                //if (codsAccMark.Length > 0)
                //{
                //    codsAccMark = codsAccMark.Remove(codsAccMark.Length - 1);
                //    int numADescartar = GetAccsMarkADescartar(codsAccMark);
                //    iNumAccMarkSel -= numADescartar;
                //}

                ////En la tabla de configuración está establecido el número máximo de acciones de márketing que se pueden seleccionar (depende del delegado en particular)
                //if (iNumAccMarkSel > iNumMaxAccMark)
                //{
                //    Mensajes.ShowError(String.Format("El número de acciones de márketing (no especiales) seleccionadas ({0}) no puede ser superior a {1}.", iNumAccMarkSel, iNumMaxAccMark));
                //}
                //else
                //{

                // 1.- Obtener nuevo id para grupo (GetNewIdGrupoAtoPedAcciones)
                string sNewID = GetNewIdGrupoAutoPedAcciones();

                SqlTransaction sqlTran;
                if (sqlConn.State.ToString() == "Closed")
                    sqlConn.Open();

                sqlTran = sqlConn.BeginTransaction();
                sqlCmdSetAutoPedAcciones.Transaction = sqlTran;
                sqlCmdSetPedAcciones.Transaction = sqlTran;
                //---- GSG (06/03/2021)
                sqlCmdSetPedidosCab.Transaction = sqlTran;
                sqlCmdSetPedidosLin.Transaction = sqlTran;


                //---- GSG (23/11/2016)
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
                    if (row.Cells["selected"].Value != null && bool.Parse(row.Cells["selected"].Value.ToString()) == true)
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


                List<ParejasAccionesMKT> lEnviarPicking = new List<ParejasAccionesMKT>();

                try
                {
                    float fBrutoPedido = float.Parse(txtbBrutoPedAM.Text.Replace('€', ' ').Trim()); //---- GSG (06/03/2021) traslladat aquí fora


                    // 2.- Insertar en tabla AutoPedAccMark los pedidos 
                    foreach (DataGridViewRow row in dgvPeds.Rows)
                    {
                        sqlCmdSetAutoPedAcciones.Parameters["@sIdGrupoAutoPedido"].Value = sNewID;
                        sqlCmdSetAutoPedAcciones.Parameters["@sIdPedido"].Value = row.Cells["sIdPedido"].Value.ToString();
                        sqlCmdSetAutoPedAcciones.ExecuteNonQuery();

                        // 3.- Insertar en tabla PedAcciones

                        //---- GSG (01/02/2017)
                        //Tiene que ser la suma de todos los autopedidos que quedarán agrupados en una sola AutoPed
                        //float fBrutoPedido = float.Parse(row.Cells["fImporteBruto"].Value.ToString()); 
                        //float fBrutoPedido = float.Parse(txtbBrutoPedAM.Text.Replace('€', ' ').Trim()); //---- GSG (06/03/2021) traslladat


                        foreach (DataGridViewRow rowA in dataGridViewAccMark.Rows)
                        {
                            if (rowA.Cells["selected"].Value != null && rowA.Cells["selected"].Value.ToString() != "")
                            {
                                if (bool.Parse(rowA.Cells["selected"].Value.ToString()) == true)
                                {
                                    //---- GSG (06/03/2021)
                                    ParejasAccionesMKT lpedAux = _listaAccMarkAPicking.Find(x => (x.miembro_2 == rowA.Cells["sIdAccionDataGridViewTextBoxColumn"].Value.ToString()));


                                    //---- GSG (06/03/2021)
                                    // si la acción de mkt está en las que van a picking, marcar los siguientes campos
                                    //sqlCmdSetPedAcciones.Parameters["@iAccion"].Value = 0;
                                    if (lpedAux != null)
                                        sqlCmdSetPedAcciones.Parameters["@iAccion"].Value = 3;
                                    else
                                        sqlCmdSetPedAcciones.Parameters["@iAccion"].Value = 0;




                                    sqlCmdSetPedAcciones.Parameters["@sIdPedido"].Value = sNewID;
                                    sqlCmdSetPedAcciones.Parameters["@iIdAccion"].Value = int.Parse(rowA.Cells["iIdAccionDataGridViewTextBoxColumn"].Value.ToString());
                                    //---- GSG (23/10/2016)
                                    sqlCmdSetPedAcciones.Parameters["@iUnidades"].Value = int.Parse(rowA.Cells["UnidadesAEntregar"].Value.ToString());
                                    sqlCmdSetPedAcciones.Parameters["@Destino"].Value = entrega;
                                    //---- GSG (01/02/2017)
                                    sqlCmdSetPedAcciones.Parameters["@Bruto"].Value = fBrutoPedido;

                                    sqlCmdSetPedAcciones.ExecuteNonQuery();


                                    //---- GSG (06/03/2021)
                                    if (lpedAux != null)
                                    {
                                        lEnviarPicking.Add(lpedAux);
                                    }
                                     
                                }
                            }
                        }
                    }

                    //---- GSG (06/03/2021)
                    // 4.- Crear los pedidos con las líneas de mkt

                    // Esta parte solo se va a hacer si las acciones de mkt seleccionadas tienen iActivoPara con el valor adecuado i.e. 

                    /*
                        ----110 --> activo para pedidos y autopedidos y ENVIALIA todo tipo
----111 --> activo para pedidos y ENVIALIA todo tipo
----112 --> activo para autopedidos y ENVIALIA todo tipo (EN AUTOPEDIDOS SIEMPRE ES TODO TIPO)

----120 --> activo para pedidos y autopedidos y ENVIALIA pedidos Directos
----121 --> activo para pedidos y ENVIALIA pedidos Directos
----122 --> activo para autopedidos y ENVIALIA (EN AUTOPEDIDOS SIEMPRE ES TODO TIPO)

----130 --> activo para pedidos y autopedidos y ENVIALIA pedidos Transfer
----131 --> activo para pedidos y ENVIALIA pedidos Transfer
----132 --> activo para autopedidos y ENVIALIA  (EN AUTOPEDIDOS SIEMPRE ES TODO TIPO) 

----210 --> activo para pedidos y autopedidos y PICKING todo tipo
----211 --> activo para pedidos y PICKING todo tipo
----212 --> activo para autopedidos y PICKING todo tipo (EN AUTOPEDIDOS SIEMPRE ES TODO TIPO)

----220 --> activo para pedidos y autopedidos y PICKING pedidos Directos
----221 --> activo para pedidos y PICKING pedidos Directos
----222 --> activo para autopedidos y PICKING  (EN AUTOPEDIDOS SIEMPRE ES TODO TIPO)

----230 --> activo para pedidos y autopedidos y PICKING pedidos Transfer
----231 --> activo para pedidos y PICKING pedidos Transfer
----232 --> activo para autopedidos y PICKING  (EN AUTOPEDIDOS SIEMPRE ES TODO TIPO)

                     */


                    if (lEnviarPicking.Count > 0)
                    {


                        int iIdDelegado = int.Parse(sNewID.Substring(1, 4));


                        //Insertar Cabecera del Pedido

                        sqlCmdSetPedidosCab.Parameters["@iAccion"].Value = 0;
                        sqlCmdSetPedidosCab.Parameters["@sIdPedido"].Value = sNewID; // Código agrupador
                        sqlCmdSetPedidosCab.Parameters["@sIdPedidoTemp"].Value = sNewID;
                        sqlCmdSetPedidosCab.Parameters["@iIdDelegado"].Value = iIdDelegado;
                        sqlCmdSetPedidosCab.Parameters["@sIdTipoPedido"].Value = "ZDIR"; // Siempe directo
                        sqlCmdSetPedidosCab.Parameters["@iIdCliente"].Value = this.Var_iIdCliente;
                        sqlCmdSetPedidosCab.Parameters["@iIdDestinatario"].Value = this.Var_iIdCliente;

                        sqlCmdSetPedidosCab.Parameters["@dFechaPedido"].Value = DateTime.Now;
                        sqlCmdSetPedidosCab.Parameters["@dFechaPreferente"].Value = DateTime.Now;
                        sqlCmdSetPedidosCab.Parameters["@dFechaFijada"].Value = DateTime.Now;

                        sqlCmdSetPedidosCab.Parameters["@sOrgVentas"].Value = Clases.Configuracion.sOrgVentasSAP;
                        sqlCmdSetPedidosCab.Parameters["@sGrupoVendedor"].Value = Clases.Configuracion.sGrupoVendedorSAP;
                        sqlCmdSetPedidosCab.Parameters["@sCanal"].Value = Clases.Configuracion.sCanalSAP;
                        sqlCmdSetPedidosCab.Parameters["@sSector"].Value = Clases.Configuracion.sSectorSAP;

                        // pienso que debo poner 0 en el importe
                        //sqlCmdSetPedidosCab.Parameters["@fImporte"].Value = fBrutoPedido;
                        sqlCmdSetPedidosCab.Parameters["@fImporte"].Value = 0;

                        sqlCmdSetPedidosCab.Parameters["@fDescuento"].Value = 0;
                        sqlCmdSetPedidosCab.Parameters["@sIdTipoCampanya"].Value = "";
                        sqlCmdSetPedidosCab.Parameters["@tObservaciones"].Value = "";
                        sqlCmdSetPedidosCab.Parameters["@iEstado"].Value = 0;
                        sqlCmdSetPedidosCab.Parameters["@fFUM"].Value = DateTime.Now;
                        sqlCmdSetPedidosCab.Parameters["@bEnviadoCEN"].Value = 0;
                        sqlCmdSetPedidosCab.Parameters["@bEnviadoPDA"].Value = 0;
                        sqlCmdSetPedidosCab.Parameters["@fDescuentoCampanya"].Value = 0;
                        sqlCmdSetPedidosCab.Parameters["@fDescuentoAdicional"].Value = 0; // No lo estamos utilizando y además ahora el campo fDescImpNeto de la campaña, que influia aquí, lo utilizaremos para otra cosa

                        //Rendabilitat de la comanda
                        sqlCmdSetPedidosCab.Parameters["@fRentabilidad"].Value = 0;

                        sqlCmdSetPedidosCab.Parameters["@iIdAccion"].Value = 0; // insert
                        sqlCmdSetPedidosCab.Parameters["@sFechaVencimiento"].Value = System.DBNull.Value;
                        sqlCmdSetPedidosCab.Parameters["@sCondPago"].Value = System.DBNull.Value;
                        sqlCmdSetPedidosCab.Parameters["@sPrioridad"].Value = System.DBNull.Value;
                        sqlCmdSetPedidosCab.Parameters["@sTipoPedidoCompromiso"].Value = System.DBNull.Value;
                        sqlCmdSetPedidosCab.Parameters["@sTipoGestionCompromiso"].Value = System.DBNull.Value;
                        sqlCmdSetPedidosCab.Parameters["@sCPCompra"].Value = System.DBNull.Value;

                        sqlCmdSetPedidosCab.ExecuteNonQuery();


                        // Insertar Líneas del pedido
                        int iLin = 0;

                        foreach (DataGridViewRow rowA in dataGridViewAccMark.Rows)
                        {
                            if (rowA.Cells["selected"].Value != null && rowA.Cells["selected"].Value.ToString() != "")
                            {
                                if (bool.Parse(rowA.Cells["selected"].Value.ToString()) == true)
                                {
                                    iLin += 10;

                                    sqlCmdSetPedidosLin.Parameters["@iAccion"].Value = 0;
                                    sqlCmdSetPedidosLin.Parameters["@sIdPedido"].Value = sNewID;
                                    sqlCmdSetPedidosLin.Parameters["@iIdLinea"].Value = iLin.ToString();

                                    int idAccion = int.Parse(rowA.Cells["iIdAccionDataGridViewTextBoxColumn"].Value.ToString());
                                    ParejasAccionesMKT lpeAux = lEnviarPicking.Find(x => (x.miembro_1 == idAccion));
                                    sqlCmdSetPedidosLin.Parameters["@sIdMaterial"].Value = lpeAux.miembro_2;

                                    int cantidad = int.Parse(rowA.Cells["UnidadesAEntregar"].Value.ToString());
                                    sqlCmdSetPedidosLin.Parameters["@iCantidad"].Value = cantidad;

                                    // esoy poniendo el coste pero quizá tenga que poner 0 que es lo que hago en los pedidos normales para las acciones
                                    sqlCmdSetPedidosLin.Parameters["@fPrecio"].Value = 0;
                                    //sqlCmdSetPedidosLin.Parameters["@fPrecio"].Value = double.Parse(rowA.Cells["fCosteUnitarioDataGridViewTextBoxColumn"].Value.ToString());

                                    sqlCmdSetPedidosLin.Parameters["@sidTipoPosicion"].Value = "ZMKT";

                                    sqlCmdSetPedidosLin.Parameters["@bEntregado"].Value = 0;
                                    sqlCmdSetPedidosLin.Parameters["@dFechaPreferente"].Value = DateTime.Today;

                                    sqlCmdSetPedidosLin.Parameters["@fDescuento"].Value = 0; // Descuento aplicado
                                    sqlCmdSetPedidosLin.Parameters["@iBonificacion"].Value = 0;
                                    sqlCmdSetPedidosLin.Parameters["@idCampanya"].Value = "0";
                                    sqlCmdSetPedidosLin.Parameters["@idArrastre"].Value = null;
                                    sqlCmdSetPedidosLin.Parameters["@idGrupoMat"].Value = null;
                                    sqlCmdSetPedidosLin.Parameters["@idPaquete"].Value = null;
                                    sqlCmdSetPedidosLin.Parameters["@sSerie"].Value = null;
                                    sqlCmdSetPedidosLin.Parameters["@sCodVale"].Value = null;
                                    sqlCmdSetPedidosLin.Parameters["@sRechazo"].Value = null;

                                    sqlCmdSetPedidosLin.ExecuteNonQuery();
                                }
                            }
                        }

                        //---- FI GSG

                        
                    }


                    sqlTran.Commit();

                }
                catch (Exception err)
                {
                    sqlTran.Rollback();
                    Mensajes.ShowError(err.ToString());
                }
                finally
                {
                    sqlTran.Dispose();
                    sqlConn.Close();

                    ResetForm();
                    Mensajes.ShowInformation("Ha finalizado la asignación de acciones de marketing a los pedidos.");
                }
                //}
            }
        }


        private int GetAccsMarkADescartar(string seleccio)
        {
            int ret = 0;
            SqlDataReader dr;

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

                dr.Close();
            }
            catch (Exception e)
            {
                Mensajes.ShowError(e.ToString());
            }

            return ret;
        }


        private string GetNewIdGrupoAutoPedAcciones()
        {
            string ret = "";

            try
            {
                if (sqlConn.State.ToString() == "Closed")
                    sqlConn.Open();

                sqlGetNewIdGrupoAutoPedAcciones.ExecuteNonQuery();

                ret = this.sqlGetNewIdGrupoAutoPedAcciones.Parameters["@Ret"].Value.ToString();

                this.sqlConn.Close();
            }
            catch (Exception e)
            {
                Mensajes.ShowError(e.ToString());
            }

            return ret;
        }


        private void ResetForm()
        {
            dsAccMark.ListaAutoPedsSinAccMark.Rows.Clear();
            dsAccMark.ListaAccionesMarketing.Rows.Clear();

            dataGridViewAccMark.DataSource = dsAccMark.ListaAccionesMarketing;
            dgvPeds.DataSource = dsAccMark.ListaAutoPedsSinAccMark;
            lblNumReg.Text = "";
            lblNumRegAccMark.Text = "";

            //---- GSG (23/11/2016)
            //txbImporteBruto.Text = String.Format("{0:#,0.##} €", 0);
            txtbBrutoPedAM.Text = String.Format("{0:#,0.##} €", 0);

            this.txtsIdCliente.Text = "";
            this.txtsCliente.Text = "";
            this.Var_iIdCliente = -1;
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            ResetForm();
        }


        //---- GSG (23/10/2016)
        private void GetValuesProdEnPedido()
        {
            string idProd = "";
            string nombreProd = "";
            int cantidad = 0;
            float importe = 0;
            float numeradoRent = 0;
            float fDescuento = 0;
            float fCoste = -1;

            // Guarda unidades, importes y rentabilidad del pedido agrupados por productos existentes en el pedido
            _tValuesProdEnPed.Clear();

            foreach (DataSets.dsAccionesMarketing.ListaLinsAutoPedsSinAccMarkRow row in dtLineasPedido)
            {
                idProd = row.sIdProducto;
                DataRow[] sNombresProducto = dsFormularios1.ListaProductos.Select("sIdProducto = '" + idProd + "'");
                if (sNombresProducto.Length > 0)
                    nombreProd = sNombresProducto[0][1].ToString();
                cantidad = int.Parse(row.iCantidad.ToString()) * int.Parse(row.iCantidadBase.ToString());
                importe = float.Parse(row.fBruto.ToString());
                fDescuento = float.Parse(row.vdesc.ToString());  // valor del descuento                
                try { fCoste = float.Parse(row.fCoste.ToString()); }
                catch (Exception e) { fCoste = 0; }

                numeradoRent = importe - fDescuento - fCoste; // En la tabla obtenida ya tenemos los valores según el número de unidades

                if (_tValuesProdEnPed.Count > 0)
                {
                    ValuesProd val = _tValuesProdEnPed.Find(delegate (ValuesProd val1) { return val1.sIdProducto == idProd; });

                    if (val == null)
                        _tValuesProdEnPed.Add(new ValuesProd(idProd, nombreProd, cantidad, importe, numeradoRent));
                    else
                    {
                        _tValuesProdEnPed.Find(x => x.sIdProducto == idProd).iCantidad += cantidad;
                        _tValuesProdEnPed.Find(x => x.sIdProducto == idProd).fImporte += importe;
                        // la rentabilidad no suma
                    }
                }
                else
                    _tValuesProdEnPed.Add(new ValuesProd(idProd, nombreProd, cantidad, importe, numeradoRent));
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


        private void dataGridViewAccMark_MouseUp(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hti = dataGridViewAccMark.HitTest(e.X, e.Y);

            if (hti.RowIndex < 0) //Se hizo click en la cabecera
                return;

            if (hti.ColumnIndex == 0)
            {
                if (dataGridViewAccMark.Rows[hti.RowIndex].Cells["selected"].Value != null && bool.Parse(dataGridViewAccMark.Rows[hti.RowIndex].Cells["selected"].Value.ToString())) // checked --> uncheked
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
                                        if (row2.Cells["selected"].Value != null && bool.Parse(row2.Cells["selected"].Value.ToString()))
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

        private List<ParejasExclusion> GetAccMarkExcluidas()
        {
            List<ParejasExclusion> lRet = new List<ParejasExclusion>();

            this.dsAccMark.AccMarkExcluidas.Rows.Clear();

            this.sqldaAccMarkExcluidas.Fill(this.dsAccMark);

            if (this.dsAccMark.AccMarkExcluidas.Rows.Count > 0)
            {
                foreach (GESTCRM.Formularios.DataSets.dsAccionesMarketing.AccMarkExcluidasRow row in dsAccMark.AccMarkExcluidas.Rows)
                {
                    ParejasExclusion pe = new ParejasExclusion(row.iIdAccion1, row.iIdAccion2);
                    lRet.Add(pe);
                }
            }

            return lRet;
        }


        // Analizar las acciones seleccionadas para ver que valor hay que poner en las unidades que se solicitarán
        // Si para un producto se ha seleccionado una sola acción relacionada --> = Todas las unidades van a esta acción
        // Si más de una acción --> = 1 en cada acción
        private void SetUnidadesAccMark()
        {
            foreach (DataGridViewRow row in dataGridViewAccMark.Rows)
            {
                bool bMesDuna = false;

                if (row.Cells["selected"].Value != null && bool.Parse(row.Cells["selected"].Value.ToString()) && !bool.Parse(row.Cells["bIndepe"].Value.ToString()))
                {
                    int idAccMark = int.Parse(row.Cells["iIdAccionDataGridViewTextBoxColumn"].Value.ToString());
                    string prod = row.Cells["sIdProducto"].Value.ToString();

                    foreach (DataGridViewRow row2 in dataGridViewAccMark.Rows)
                    {
                        int idAccMark2 = int.Parse(row2.Cells["iIdAccionDataGridViewTextBoxColumn"].Value.ToString());

                        if (row2.Cells["selected"].Value != null && bool.Parse(row2.Cells["selected"].Value.ToString()) && idAccMark != idAccMark2 && !bool.Parse(row2.Cells["bIndepe"].Value.ToString()))
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
                        row.Cells["UnidadesAEntregar"].Value = 1;

                        //---- GSG (29/03/2022)
                        //row.Cells["UnidadesAEntregar"].Value = 1;
                        row.Cells["UnidadesAEntregar"].Value = int.Parse(row.Cells["iNumElemEntregarDataGridViewTextBoxColumn"].Value.ToString());


                        this.dataGridViewAccMark.RefreshEdit();
                        this.dataGridViewAccMark.NotifyCurrentCellDirty(true);
                    }
                    else
                    {
                        // Buscar el valor que depèn del import de la comanda
                        // Si(coste unitario acción / importe total pedido) >= iNumMaxEntregar-- > iNumMaxEntregar
                        // Si no --> Valor entero de la división
                        float fBrutoPedido = float.Parse(txtbBrutoPedAM.Text.Replace('€', ' ').Trim());
                        float fImpMinAcc = float.Parse(row.Cells["fImpMin"].Value.ToString());
                        int unidades = 0;

                        if (fImpMinAcc <= 1)
                            unidades = 1;
                        else
                        {
                            unidades = (int)(fBrutoPedido / fImpMinAcc);
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

        private void GetDatosSeleccionAM()
        {
            // Cálculo del coste de las acciones de márketing seleccionadas                   
            float rentabilidadPedido = float.Parse(_rentabilidadPedido.ToString());
            float costeAM = 0;

            foreach (DataGridViewRow row in dataGridViewAccMark.Rows)
            {
                if (row.Cells["selected"].Value != null && row.Cells["selected"].Value.ToString() != "")
                {
                    //---- GSG (06/03/2021) 
                    //if (bool.Parse(row.Cells["selected"].Value.ToString()) && !bool.Parse(row.Cells["bIndepe"].Value.ToString()))

                    ParejasAccionesMKT lpeAux = _listaAccMarkProfitPlus.Find(x => (x.miembro_2 == row.Cells["sIdAccionDataGridViewTextBoxColumn"].Value.ToString()));

                    if (bool.Parse(row.Cells["selected"].Value.ToString()) && !bool.Parse(row.Cells["bIndepe"].Value.ToString()) 
                        && lpeAux != null)
                        costeAM += (float.Parse(row.Cells["fCosteUnitarioDataGridViewTextBoxColumn"].Value.ToString()) * int.Parse(row.Cells["UnidadesAEntregar"].Value.ToString()));
                }
            }

            txtbCosteTotalAM.Text = costeAM.ToString("C2");

            float rentabilidad = float.Parse(_rentabilidadPedido.ToString().Replace('.', ',')) - costeAM;
            // Busco el color de la rentabilidad
            Color cColor = Color.FromArgb(238, 243, 246);
            cColor = CalcularColorRentabilidad(rentabilidad, DateTime.Today); // En otras partes del programa ponemos la fecha del pedido pero aquí tenemos una suma de pedidos por lo que pongo fecha de hoy
            txtbRentabilidadAM.BackColor = cColor;


            //---- GSG (06/03/2021)
            float puntosAM = 0;

            if (Clases.Configuracion.iPuntosDividePor != 0)
                puntosAM = (costeAM / Clases.Configuracion.iPuntosDividePor) * Clases.Configuracion.iPuntosMultiplicaPor;

            txtbPuntosPedConAM.Text = (float.Parse(txtbPuntosPedAM.Text) - puntosAM).ToString("N2");
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

            //---- GSG (07/03/2017)
            //tSeleccion = GetValuesSeleccionAccMArk();
            bool bAnySelected = false;
            tSeleccion = GetValuesSeleccionAccMArk(out bAnySelected);


            if (bAnySelected) //---- GSG (07/03/2017)
            {

                // 2.- Comparar lo seleccionado con lo que hay en el pedido

                fBrutoPedido = float.Parse(txtbBrutoPedAM.Text.Replace('€', ' ').Trim());
                foreach (ValuesProd val in _tValuesProdEnPed)
                    iCantidadPedido += val.iCantidad;
                fRentabilidadPedido = float.Parse(_rentabilidadPedido.ToString());

                // 1ª COMPROBACIÓN : Número máximo de acciones que se pueden seleccionar
                //                   Esto viene, ahora, en la tabla AccMarkRangos que determina el máximo en función de rangos de importe

                numMaxAccMark = GetMaxAccMark(fBrutoPedido);
                foreach (DataGridViewRow row in dataGridViewAccMark.Rows)
                {
                    if (row.Cells["selected"].Value != null && bool.Parse(row.Cells["selected"].Value.ToString()) && !bool.Parse(row.Cells["bIndepe"].Value.ToString()))
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
                            if (row.Cells["selected"].Value != null && bool.Parse(row.Cells["selected"].Value.ToString()) && (int.Parse(row.Cells["iIdAccionDataGridViewTextBoxColumn"].Value.ToString()) == pe.miembro_1 || int.Parse(row.Cells["iIdAccionDataGridViewTextBoxColumn"].Value.ToString()) == pe.miembro_2))
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

            }
            else //---- GSG (07/03/2017)
            {
                missatge = String.Format("No hay ninguna acción de márketing seleccionada. La asignación no se puede llevar a cabo.");
                lMissatges.Add(missatge);
            }

            return lMissatges;

        }


        // Repasa el grid de acciones de márketing y para los seleccionados crea grupos (excluye los independientes ya que no cuentan para hacer ninguna comprobación)
        //private List<ValuesProd> GetValuesSeleccionAccMArk()
        private List<ValuesProd> GetValuesSeleccionAccMArk(out bool obAnySelected) //---- GSG (07/03/2017)
        {
            List<ValuesProd> tSeleccion = new List<ValuesProd>();
            string idProd = "";
            string nombreProd = "";
            int cantidad = 0;
            float importe = 0;
            float rentabilidad = 0;
            bool bSuma = false;
            int contador = 1;

            obAnySelected = false; //---- GSG (07/03/2017)

            foreach (DataGridViewRow row in dataGridViewAccMark.Rows)
            {
                bool bSel = false;
                if (row.Cells["selected"].Value != null)
                    bSel = bool.Parse(row.Cells["selected"].Value.ToString());

                if (bSel && !bool.Parse(row.Cells["bIndepe"].Value.ToString()))
                {
                    if (row.Cells["sIdProducto"].Value != null && row.Cells["sIdProducto"].Value != System.DBNull.Value)
                        idProd = row.Cells["sIdProducto"].Value.ToString();
                    else
                        idProd = "";
                    nombreProd = row.Cells["sDescAccionDataGridViewTextBoxColumn"].Value.ToString();
                    

                    //---- GSG (29/03/2022)
                    //cantidad = int.Parse(row.Cells["iUnidadesDataGridViewTextBoxColumn"].Value.ToString());
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

                if (bSel && !obAnySelected) //---- GSG (07/03/2017))
                    obAnySelected = true;
            }

            return tSeleccion;
        }

        public int GetMaxAccMark(float val)
        {
            int iRet = 0;

            try
            {
                SqlDataReader dr;

                if (sqlConn.State.ToString() == "Closed")
                    sqlConn.Open();

                sqlCmdMaxAccMark.Parameters["@fImporte"].Value = val;
                dr = sqlCmdMaxAccMark.ExecuteReader();

                if (dr.Read())
                {
                    iRet = int.Parse(dr["iMaxNumAccMark"].ToString());
                }

                dr.Close();
            }
            catch (Exception e)
            {
                Mensajes.ShowError(e.ToString());
            }
            finally
            {
            }

            return iRet;
        }

        


        #endregion

        //---- GSG (18/06/2015)
        #region pestanya importes

        private void UpdateDataGridViewImportes()
        {
            try
            {
                //actualitza el grid
                dataGridViewImportes.DataSource = dsAccMark.ListaImportesClientesSAPConAutopedsSinAccMark;
                this.lblNumImportes.Text = dataGridViewImportes.Rows.Count.ToString();

                dataGridViewImportes.Refresh();
            }
            catch (Exception ex)
            {
                Mensajes.ShowError(ex.Message);
            }
        }


        private void GetImportes()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                int codDelegado = Convert.ToInt32(Clases.Configuracion.ValorConf(1));
                string codCli = txbCodCliente.Text.Trim();
                string nombreCli = txbNombreCliente.Text.Trim();

                if (codCli == "") codCli = null;
                if (nombreCli == "") nombreCli = null;

                this.dsAccMark.ListaImportesClientesSAPConAutopedsSinAccMark.Rows.Clear();

                this.sqldaListaImportes.SelectCommand.Parameters["@iIdDelegado"].Value = codDelegado;
                this.sqldaListaImportes.SelectCommand.Parameters["@sIdCliente"].Value = codCli;
                this.sqldaListaImportes.SelectCommand.Parameters["@sNombre"].Value = nombreCli;

                this.sqldaListaImportes.Fill(dsAccMark);
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
            Cursor.Current = Cursors.Default;
        }


        private void btBuscarImportes_Click(object sender, EventArgs e)
        {
            CargarImportes();
        }

        private void CargarImportes()
        {
            GetImportes();
            UpdateDataGridViewImportes();
        }

        #endregion



        #region pestanya assignaciones

        private void UpdateDataGridViewAsignaciones()
        {
            try
            {
                //actualitza el grid
                dataGridViewAsignaciones.DataSource = null;
                dataGridViewAsignaciones.DataSource = dsAccMark.ListaAsignacionesAutopedsSinAccMark;
                this.lblNumAsignaciones.Text = dataGridViewAsignaciones.Rows.Count.ToString();

                dataGridViewAsignaciones.Refresh();
            }
            catch (Exception ex)
            {
                Mensajes.ShowError(ex.Message);
            }
        }


        private void GetAsignaciones()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                int codDelegado = Convert.ToInt32(Clases.Configuracion.ValorConf(1));
                string codCli = txtsIdClienteConsulta.Text.Trim();
                string nombreCli = txtsClienteConsulta.Text.Trim();

                if (codCli == "") codCli = null;
                if (nombreCli == "") nombreCli = null;

                this.dsAccMark.ListaAsignacionesAutopedsSinAccMark.Rows.Clear();

                this.sqldaListaAsignaciones.SelectCommand.Parameters["@iIdDelegado"].Value = codDelegado;
                this.sqldaListaAsignaciones.SelectCommand.Parameters["@sIdCliente"].Value = codCli;
                this.sqldaListaAsignaciones.SelectCommand.Parameters["@sNombre"].Value = nombreCli;

                this.sqldaListaAsignaciones.Fill(dsAccMark);
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
            Cursor.Current = Cursors.Default;
        }

        private void btBuscarClienteConsulta_Click(object sender, EventArgs e)
        {
            try
            {
                //---- GSG (13/07/2015)
                //GESTCRM.Formularios.Busquedas.frmMClientesSAPAutopedAccMark frmBCli = new GESTCRM.Formularios.Busquedas.frmMClientesSAPAutopedAccMark();
                GESTCRM.Formularios.Busquedas.frmMClientesSAPAutopedAccMarkCon frmBCli = new GESTCRM.Formularios.Busquedas.frmMClientesSAPAutopedAccMarkCon();

                frmBCli.ParamI_iIdDelegado = Clases.Configuracion.iIdDelegado;

                frmBCli.ShowDialog(this);

                if (frmBCli.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    if (frmBCli.dtSeleccion.Rows.Count == 0)
                    {
                        this.txtsIdClienteConsulta.Text = frmBCli.ParamIO_sIdCliente;
                        this.txtsClienteConsulta.Text = frmBCli.ParamO_tNombre;
                    }
                }
                frmBCli.Dispose();
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }


        private void btnBuscarAsignaciones_Click(object sender, EventArgs e)
        {
            CargarAsignaciones();
        }

        private void CargarAsignaciones()
        {
            GetAsignaciones();
            UpdateDataGridViewAsignaciones();
        }






        #endregion

        private void tabPageAsignacion_Click(object sender, EventArgs e)
        {

        }
    }


    //---- GSG (06/03/2021)
    // códigos de laa acciones de mkt
    public class ParejasAccionesMKT
    {
        public int miembro_1 { get; set; }

        public string miembro_2 { get; set; }

        public ParejasAccionesMKT(int m1, string m2)
        {
            this.miembro_1 = m1;
            this.miembro_2 = m2;
        }
    }
}
