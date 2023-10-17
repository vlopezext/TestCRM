using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GESTCRM.Clases;

namespace GESTCRM.Formularios
{
    public partial class frmCopiarPedido : Form
    {
        int Var_iIdCliente;
        //private bool _bEsClienteConAccMark = false;   //---- GSG (05/07/2017)
        //private const string K_LIN = "LIN";           //---- GSG (05/07/2017)
        string _sTipoPedido = null;
        string _sIdMayorista = null;
        string _sIdDelegado = null;

        public frmCopiarPedido()
        {
            InitializeComponent();


            //---- GSG (06/03/2021)
            Utiles.GetConfigConnection(); 
            this.sqlConn.ConnectionString = Utiles._connection.ConnectionString.ToString();   


           
        }

        private void frmCopiarPedido_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                lblAvisoVersion.Text = System.Configuration.ConfigurationManager.AppSettings["AvisoVersion"].ToString(); //---- GSG (14/02/2014)

                GESTCRM.Utiles.Formato_Formulario(this);
                if (this.Parent == null)
                    this.WindowState = FormWindowState.Normal;

                Inicializar_Botonera();

                this.Var_iIdCliente = -1;
                _sIdDelegado = Clases.Configuracion.iIdDelegado.ToString();

                this.cargar_eventos();
            }
            catch (Exception ev)
            {
                Mensajes.ShowError("Falla evento load: " + ev.ToString());
            }

            Cursor.Current = Cursors.Default;
        }


        private void cargar_eventos()
        {
            try
            {
                for (int i = 0; i < dgCabeceraPedidos.TableStyles[0].GridColumnStyles.Count; i++)
                {
                    DataGridTextBoxColumn TextCol = (DataGridTextBoxColumn)dgCabeceraPedidos.TableStyles[0].GridColumnStyles[i];
                    TextCol.TextBox.DoubleClick += new EventHandler(dgCabeceraPedidos_DobleClick);
                }
            }
            catch (Exception ev)
            {
                Mensajes.ShowError("Error en función cargar_eventos(): " + ev.ToString());
            }
        }


        private void Inicializar_Botonera()
        {
            try
            {
                this.ucBotoneraSecundaria1.btEditar.Click += new EventHandler(dgCabeceraPedidos_DobleClick);
                this.ucBotoneraSecundaria1.btSalir.Click += new EventHandler(btSalir_Click);
                ucBotoneraSecundaria1.btEliminar.Enabled = false;
                ucBotoneraSecundaria1.btGrabar.Enabled = false;
                ucBotoneraSecundaria1.btNuevo.Enabled = false;
                ucBotoneraSecundaria1.btEditar.Enabled = true;
                ucBotoneraSecundaria1.btSalir.Enabled = true;
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }


        private void dgCabeceraPedidos_DobleClick(object sender, EventArgs e)
        {
            string sIdPedido = dgCabeceraPedidos[dgCabeceraPedidos.CurrentCell.RowNumber, 0].ToString();
            _sTipoPedido = dgCabeceraPedidos[dgCabeceraPedidos.CurrentCell.RowNumber, 3].ToString();

            //---- GSG (14/12/2016)
            // Para poder copiar autopedidos a pedidos de delegado
            if (_sTipoPedido == "ZTRW")
                _sTipoPedido = "ZTRA";
            else if (_sTipoPedido == "ZDIW")
                _sTipoPedido = "ZDIR";

            _sIdMayorista = dgCabeceraPedidos[dgCabeceraPedidos.CurrentCell.RowNumber, 5].ToString(); //---- GSG (05/07/2017)

            bool bNoPuedeSer = false;
            string[] campanyasPed = null; 

            //Campanyas que actualmente puede tener el cliente
            //FormatBuscarCampanyas(this.Var_iIdCliente, true);
            FormatBuscarCampanyas(); //---- GSG (05/07/2017)

            //Ahora el combo tiene las campanyas que puede tener el cliente
            //Si alguna de las campanyas del pedido no coincide --> no se puede hacer la copia

            //Obtener campañas del pedido seleccionado
            int num = 0;
            if (GetCampanyasPedido(sIdPedido))
            {
                num = dsFormularios1.ListaCampanyasPedido.Rows.Count;
                campanyasPed = new string[num];

                for (int i = 0; i < num; i++)
                {
                    GESTCRM.Formularios.dsFormularios.ListaCampanyasPedidoRow row = (GESTCRM.Formularios.dsFormularios.ListaCampanyasPedidoRow)dsFormularios1.ListaCampanyasPedido.Rows[i];
                    campanyasPed[i] = row.idCampanya.ToString();
                }
            }


            int cont = 0;
            bool bTrobat = false;
            if (num > 0)
            {
                for (int i = 0; i < campanyasPed.Length; i++)
                {
                    cont = 0;
                    bTrobat = false;
                    foreach (var item in cBoxCampanyas.Items)
                    {
                        cBoxCampanyas.SelectedIndex = cont;

                        if (cBoxCampanyas.SelectedValue.ToString() == campanyasPed[i])
                        {
                            bTrobat = true;
                            break;
                        }
                        cont++;
                    }

                    if (!bTrobat)
                    {
                        bNoPuedeSer = true;
                        break;
                    }
                }
            }
            else
                bNoPuedeSer = true;

            //---- GSG (28/10/2015))
            //if (bNoPuedeSer) //NO se puede realizar la copia
            if (bNoPuedeSer && chkBoxFlexible.Checked == false)
            {
                //---- GSG (28/10/2015)
                //Mensajes.ShowInformation("No se puede realizar la copia del pedido debido a que las campañas posibles han cambiado. Puede que las campañas utilizadas en el pedido ya no existan o bien han cambiado las acciones de márketing asociadas al cliente.");
                Mensajes.ShowInformation("No se puede realizar la copia del pedido debido a que las campañas posibles han cambiado. Puede que las campañas utilizadas en el pedido ya no existan o bien han cambiado las acciones de márketing asociadas al cliente.\r\n\r\nPuede marcar la casilla 'Importar a campaña flexible' y volver a solicitar la copia. En este este caso se hará una copia del pedido enviando todas líneas a la campaña Flexible.");
            }
            else if (chkBoxFlexible.Checked == true) //---- GSG (28/10/2015)
            {
                // Se realiza la copia pero las líneas se llevan a la flexible
                Form frmTemp = new Formularios.frmPedidos(sIdPedido, Var_iIdCliente, true, _sTipoPedido, true, _sIdMayorista); //El último indicará si flexible
                frmTemp.MdiParent = this.MdiParent;
                frmTemp.Show();
            }
            else //Se puede realizar la copia normalmente
            {
                //---- GSG (05/02/2015)
                //Form frmTemp = new Formularios.frmPedidos(sIdPedido, Var_iIdCliente, true);                
                //---- GSG (28/10/2015)
                //Form frmTemp = new Formularios.frmPedidos(sIdPedido, Var_iIdCliente, true, _sTipoPedido);
                //---- GSG (05/07/2017)
                //Form frmTemp = new Formularios.frmPedidos(sIdPedido, Var_iIdCliente, true, _sTipoPedido, false);
                Form frmTemp = new Formularios.frmPedidos(sIdPedido, Var_iIdCliente, true, _sTipoPedido, false, _sIdMayorista);

                frmTemp.MdiParent = this.MdiParent;
                frmTemp.Show();
            }

            //---- FI GSG

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
            if (this.Var_iIdCliente != -1)
            {
                CargarDatos();
            }
            else
            {
                Mensajes.ShowInformation("No se ha indicado el cliente. Seleccione un cliente e inténtelo de nuevo.");
            }

            
        }


        private void CargarDatos()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                if (sqlConn.State.ToString() == "Closed")
                    sqlConn.Open();

                //---- GSG CECL 19/05/2016
                if (System.Configuration.ConfigurationManager.AppSettings["TipoDelegadoPedidosCentral"].ToString() == Comun.K_CECL)
                    sqldaListaBuscaPedidos.SelectCommand = sqlSelectCommand4CECL;
                else
                    sqldaListaBuscaPedidos.SelectCommand = sqlSelectCommand4;
                //---- FI GSG CECL 


                //Buscar Clientes
                this.dsFormularios1.ListaBuscaPedidos.Rows.Clear();

                this.sqldaListaBuscaPedidos.SelectCommand.Parameters["@iIdDelegado"].Value = -1;
                this.sqldaListaBuscaPedidos.SelectCommand.Parameters["@sIdCliente"].Value = (txtsIdCliente.Text.ToString() == "") ? null : txtsIdCliente.Text.ToString();
                this.sqldaListaBuscaPedidos.SelectCommand.Parameters["@sIdDestinatario"].Value = null;
                this.sqldaListaBuscaPedidos.SelectCommand.Parameters["@sIdTipoCampanya"].Value = null;
                this.sqldaListaBuscaPedidos.SelectCommand.Parameters["@dFechaPedido"].Value = null;
                this.sqldaListaBuscaPedidos.SelectCommand.Parameters["@dFechaPedidoEntre"].Value = null;
                this.sqldaListaBuscaPedidos.SelectCommand.Parameters["@sIdPedido"].Value = null;
                this.sqldaListaBuscaPedidos.SelectCommand.Parameters["@sIdTipoPedido"].Value = null;
                this.sqldaListaBuscaPedidos.SelectCommand.Parameters["@counter"].Value = 0;
                this.sqldaListaBuscaPedidos.SelectCommand.Parameters["@EstEntPedido"].Value = "T";
                this.sqldaListaBuscaPedidos.SelectCommand.Parameters["@EstFacPedido"].Value = "T";

                this.sqldaListaBuscaPedidos.Fill(this.dsFormularios1);

                this.lblCuentaPedidos.Text = dsFormularios1.ListaBuscaPedidos.Rows.Count.ToString();
            }
            catch (Exception ev)
            {
                Mensajes.ShowError("Error en CargarDatos: " + ev.ToString());
            }

            Cursor.Current = Cursors.Default;
        }


        //---- GSG (05/07/2017)
        /*private bool GetAccMarkConCampanyaCli(int cliente)
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

        private bool GetCampanyasPedido(string sIdPedido)
        {
            bool bRet = false;

            this.dsFormularios1.ListaCampanyasPedido.Rows.Clear();

            this.sqldaListaCampanyasPedido.SelectCommand.Parameters["@sIdPedido"].Value = sIdPedido;
            this.sqldaListaCampanyasPedido.Fill(this.dsFormularios1);

            if (this.dsFormularios1.ListaCampanyasPedido.Rows.Count > 0)
                bRet = true;

            return bRet;
        }


        
        //---- GSG (05/07/2017)
        /*private bool FormatBuscarCampanyas(int cliente, bool activo)
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

        private bool FormatBuscarCampanyas()
        {
            bool bRet = false;

            if (!Comun.IsInTheArray(_sTipoPedido, Configuracion.asPedTransfer))
                _sIdMayorista = "XXXX";

            LlenarComboCampanyas(_sIdDelegado, _sTipoPedido, Var_iIdCliente, _sIdMayorista);

            return bRet;
        }

        //---- GSG (05/07/2017)
        /*
        private void LlenarComboCampanyas(int tipo, string campanya)
        {
            dsFormularios1.ListaCampanyas.Clear();

            sqldaListaCampanyas.SelectCommand.Parameters["@iTipo"].Value = tipo;
            sqldaListaCampanyas.SelectCommand.Parameters["@idCampanya"].Value = campanya;
            sqldaListaCampanyas.SelectCommand.Parameters["@tipoCampanya"].Value = K_LIN;
            sqldaListaCampanyas.SelectCommand.Parameters["@sIdDelegado"].Value = Clases.Configuracion.iIdDelegado.ToString();
            sqldaListaCampanyas.SelectCommand.Parameters["@sIdTipoPedido"].Value = _sTipoPedido;

            sqldaListaCampanyas.Fill(dsFormularios1.ListaCampanyas);
            dsFormularios1.ListaCampanyas.DefaultView.RowFilter = "bSeleccionable = 1";
            cBoxCampanyas.DataSource = dsFormularios1.ListaCampanyas.DefaultView;
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
                sqldaListaCampanyas.SelectCommand.Parameters["@sIdTipoPedido"].Value = _sTipoPedido;

                sqldaListaCampanyas.Fill(dsFormularios1.ListaCampanyas);

                //cambio el tipo para que no rpite las campanyas extras
                tipo = 3;

            }

            dsFormularios1.ListaCampanyas.DefaultView.RowFilter = "bSeleccionable = 1";
            cBoxCampanyas.DataSource = dsFormularios1.ListaCampanyas.DefaultView;
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
        }

        */


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
    }
}
