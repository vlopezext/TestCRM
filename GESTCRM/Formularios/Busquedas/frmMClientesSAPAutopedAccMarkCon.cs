using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using GESTCRM.Controles;

namespace GESTCRM.Formularios.Busquedas
{
    public partial class frmMClientesSAPAutopedAccMarkCon : Form
    {
        public int ParamI_iIdDelegado;
        public string ParamIO_sIdCliente;
        public int ParamO_iIdCliente;
        public string ParamO_tNombre;
        public DataTable dtSeleccion;

        private int Var_filaDg;


        public frmMClientesSAPAutopedAccMarkCon()
        {
            InitializeComponent();

            //---- GSG (06/03/2021)
            Utiles.GetConfigConnection();
            this.sqlConn.ConnectionString = Utiles._connection.ConnectionString.ToString();
        }

        private void frmMClientesSAPAutopedAccMarkCon_Load(object sender, EventArgs e)
        {
            try
            {
                GESTCRM.Utiles.Formatear_DataGrid(this, this.dgClientes, "C", true);
                this.txtsIdCliente.Text = this.ParamIO_sIdCliente;
                Formatear_dgClientes();

                Crear_dtSeleccion();
            }
            catch (Exception ex)
            {
                Mensajes.ShowError(ex.Message);
            }
        }

        private void Formatear_dgClientes()
        {
            try
            {
                for (int i = 0; i < this.dgClientes.TableStyles[0].GridColumnStyles.Count; i++)
                {
                    DataGridTextBoxColumn TextCol = (DataGridTextBoxColumn)dgClientes.TableStyles[0].GridColumnStyles[i];
                    TextCol.TextBox.DoubleClick += new EventHandler(dgClientes_DoubleClick);
                }
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
        }


        private void BuscarClientes()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                string tsIdCliente = null;
                string tsNombre = null;

                if (this.txtsIdCliente.Text.ToString().Trim().Length > 0) tsIdCliente = this.txtsIdCliente.Text.ToString();
                if (this.txbNombre.Text.ToString().Trim().Length > 0) tsNombre = this.txbNombre.Text.ToString();

                this.dsBuscar1.ListaBuscaClientesSAPConAutopedsConAccMark.Rows.Clear();

                this.sqldaListaBuscaClientesSAPConAutopedsConAccMark.SelectCommand.Parameters["@iIdDelegado"].Value = this.ParamI_iIdDelegado;
                this.sqldaListaBuscaClientesSAPConAutopedsConAccMark.SelectCommand.Parameters["@sIdCliente"].Value = tsIdCliente;
                this.sqldaListaBuscaClientesSAPConAutopedsConAccMark.SelectCommand.Parameters["@sNombre"].Value = tsNombre;

                Application.DoEvents();

                this.sqldaListaBuscaClientesSAPConAutopedsConAccMark.Fill(this.dsBuscar1.ListaBuscaClientesSAPConAutopedsConAccMark);
                if (this.dsBuscar1.ListaBuscaClientesSAPConAutopedsConAccMark.Rows.Count > 0)
                {
                    this.dgClientes.CurrentCell = new DataGridCell(0, 1);
                    this.dgClientes.CurrentCell = new DataGridCell(0, 0);
                    this.lblNumReg.Text = this.dsBuscar1.ListaBuscaClientesSAPConAutopedsConAccMark.Rows.Count.ToString();
                }
                else
                    this.lblNumReg.Text = "0";
                
                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                Mensajes.ShowError(ex.Message);
            }
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            this.Var_filaDg = -1;
            BuscarClientes();
        }

        private void dgClientes_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                int fila = this.dgClientes.CurrentRowIndex;

                this.ParamIO_sIdCliente = this.dgClientes[fila, 0].ToString();
                this.ParamO_tNombre = this.dgClientes[fila, 1].ToString();
                this.ParamO_iIdCliente = int.Parse(this.dgClientes[fila, 2].ToString());

            }
            catch (Exception ex)
            {
                Mensajes.ShowError(ex.Message);
            }
        }


        private void btAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dsBuscar1.ListaBuscaClientes.Rows.Count <= 0)
                {
                    this.ParamIO_sIdCliente = "";
                    this.ParamO_tNombre = "";
                    this.ParamO_iIdCliente = -1;
                }

                dgClientes_CurrentCellChanged(sender, e);

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();

            }
            catch (Exception ex)
            {
                Mensajes.ShowError(ex.Message);
            }
        }


        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }


        private void dgClientes_Click(object sender, EventArgs e)
        {
            this.Var_filaDg = this.dgClientes.CurrentRowIndex;
            Utiles.Seleccionar_UnaFilaDataGrid(this, this.dgClientes, this.Var_filaDg);
        }


        private void dgClientes_DoubleClick(object sender, EventArgs e)
        {
            if (this.dsBuscar1.ListaBuscaClientes.Rows.Count > 0)
            {
                try
                {
                    this.ParamIO_sIdCliente = this.dgClientes[this.dgClientes.CurrentRowIndex, 0].ToString();
                    this.ParamO_tNombre = this.dgClientes[this.dgClientes.CurrentRowIndex, 1].ToString();
                    this.ParamO_iIdCliente = int.Parse(this.dgClientes[this.dgClientes.CurrentRowIndex, 2].ToString());

                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    Mensajes.ShowError(ex.Message);
                }
            }
        }


        private void dgClientes_Paint(object sender, PaintEventArgs e)
        {
            if (this.dgClientes.CurrentRowIndex != -1 && this.dgClientes.CurrentRowIndex != this.Var_filaDg)
            {
                this.Var_filaDg = this.dgClientes.CurrentRowIndex;
                Utiles.Seleccionar_UnaFilaDataGrid(this, this.dgClientes, this.Var_filaDg);
            }
        }


        private void BorraDatosBusqueda()
        {
            this.dsBuscar1.ListaBuscaClientesSAPConAutopedsConAccMark.Rows.Clear();
            Application.DoEvents();
            this.dgClientes.Refresh();
            this.lblNumReg.Text = "";
        }


        private void txtsIdCliente_TextChanged(object sender, EventArgs e)
        {
            BorraDatosBusqueda();
        }

        private void txbNombre_TextChanged(object sender, EventArgs e)
        {
            BorraDatosBusqueda();
        }

        private void Crear_dtSeleccion()
        {
            this.dtSeleccion = new DataTable();
            this.dtSeleccion.Columns.Add("iIdCliente");
            this.dtSeleccion.Columns.Add("sIdCliente");
            this.dtSeleccion.Columns.Add("tNombre");
        }

        private void Recuperar_Seleccion()
        {
            for (int i = 0; i < this.dsBuscar1.ListaBuscaClientesSAPConAutopedsConAccMark.Rows.Count; i++)
            {
                if (this.dgClientes.IsSelected(i))
                {
                    DataRow fila = this.dtSeleccion.NewRow();
                    fila["iIdCliente"] = this.dgClientes[i, 3];
                    fila["sIdCliente"] = this.dgClientes[i, 0];
                    fila["tNombre"] = this.dgClientes[i, 2];

                    this.dtSeleccion.Rows.Add(fila);
                }
            }
        }
    }
}
