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
    public partial class frmStocks : Form
    {
        const int K_COL_CODSAP = 0;
        const int K_COL_CODNACIONAL = 1;
        const int K_COL_NOMMAT = 2;
        const int K_COL_STOCK = 3;

        public frmStocks()
        {
            InitializeComponent();


            //---- GSG (06/03/2021)
            Utiles.GetConfigConnection();
            this.sqlConn.ConnectionString = Utiles._connection.ConnectionString.ToString();

            
        }

        private void frmStocks_Load(object sender, EventArgs e)
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

                CargarDatos();
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }

            Cursor.Current = Cursors.Default;
        }

        private void Inicializar_Botonera()
        {
            try
            {
                this.ucBotoneraSecundaria1.btSalir.Click += new EventHandler(btSalir_Click);
                ucBotoneraSecundaria1.btEliminar.Enabled = false;
                ucBotoneraSecundaria1.btGrabar.Enabled = false;
                ucBotoneraSecundaria1.btNuevo.Enabled = false;
                ucBotoneraSecundaria1.btEditar.Enabled = false;
                ucBotoneraSecundaria1.btAIndicadores.Enabled = false;
                ucBotoneraSecundaria1.btAPedido.Enabled = false;
                ucBotoneraSecundaria1.btSalir.Enabled = true;
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            
        }

        private void CargarDatos()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                this.dsMateriales1.ListaStocks.Rows.Clear();

                this.sqldaListaStocks.SelectCommand.Parameters["@sIdMaterial"].Value = null;
                this.sqldaListaStocks.Fill(this.dsMateriales1);

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

        private void dGVStocks_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool bLetraODigito = char.IsLetterOrDigit((char)e.KeyChar);

            if (bLetraODigito)
                txbsDescripcion.Text += e.KeyChar.ToString();
            else
            {
                if (e.KeyChar == (char)8) // <--
                {
                    if (txbsDescripcion.Text.Length > 0)
                        txbsDescripcion.Text = txbsDescripcion.Text.Substring(0, txbsDescripcion.Text.Length - 1);
                }
                else if (e.KeyChar == (char)32) // Espacio
                    txbsDescripcion.Text += e.KeyChar.ToString();
            }
        }

        private void txbsDescripcion_TextChanged(object sender, EventArgs e)
        {
            int pos = GetRowIndex(txbsDescripcion.Text);

            if (pos > -1)
                this.dGVStocks.FirstDisplayedScrollingRowIndex = pos;
        }

        private int GetRowIndex(string SearchValue)
        {
            int rowIndex = -1;

            foreach (DataGridViewRow row in dGVStocks.Rows)
            {
                if (row.Cells["sMaterial"].Value.ToString().ToUpper().StartsWith(SearchValue.ToUpper()))
                {
                    rowIndex = row.Index;
                    break;
                }
            }

            return rowIndex;
        }
    }
}
