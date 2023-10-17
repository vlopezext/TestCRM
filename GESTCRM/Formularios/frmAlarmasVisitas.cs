using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GESTCRM.Formularios
{
    public partial class frmAlarmasVisitas : Form
    {
        const int K_GRUPO_ROJO = 1;
        const int K_GRUPO_AMARILLO = 2;
        const int K_GRUPO_SINCOLOR = 3;

        ColorBlend colorBlend = null;

        public frmAlarmasVisitas()
        {
            InitializeComponent();


            //---- GSG (06/03/2021)
            Utiles.GetConfigConnection();
            this.sqlConn.ConnectionString = Utiles._connection.ConnectionString.ToString();

            
            this.dataGridViewAlarmas.RowsDefaultCellStyle.SelectionBackColor = Utiles.ColorSelecionFilaDataGrid;
            this.dataGridViewBricks.RowsDefaultCellStyle.SelectionBackColor = Utiles.ColorSelecionFilaDataGrid;
        }

        private void frmAlarmasVisitas_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                lblTitulo.Text = "Alarmas Visitas";
                lblAvisoVersion.Text = System.Configuration.ConfigurationManager.AppSettings["AvisoVersion"].ToString(); //---- GSG (14/02/2014)

                Utiles.Formato_Formulario(this);
                if (this.Parent == null) this.WindowState = FormWindowState.Normal;

                if (this.Parent == null)
                    this.WindowState = FormWindowState.Normal;

                CargaGridBricks();
                //CreaTablaBricks(); //Wonderfull but not in SQLSERVER 2000

                

            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }

            Cursor.Current = Cursors.Default;
        }


              
        private void CargaGridBricks()
        {
            try
            {
                this.sqldaListaBricks.Fill(this.dsBuscar1);
                lblNumRegBricks.Text = dsBuscar1.ListaBricks.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                Mensajes.ShowError(ex.Message);
            }
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

        private void CreaTablaBricks()
        {
            DataColumn idColumn = new DataColumn();
            idColumn.DataType = System.Type.GetType("System.String");
            idColumn.ColumnName = "sIdBrick";
            bricksTable.Columns.Add(idColumn);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            GetResultadoBuscar();
        }

        private void GetResultadoBuscar()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Obtener los bricks seleccionados

                //Esto es maravilloso pero para SQLSERVER 2000 no funciona --> insertaremos en tabla temporal
                //bricksTable.Clear();

                if (sqlConn.State.ToString() == "Closed")
                    sqlConn.Open();
                //Borrar tabla
                sqlCmdSetBrickTemp.Parameters["@Action"].Value = 0;
                sqlCmdSetBrickTemp.Parameters["@brick"].Value = null;
                sqlCmdSetBrickTemp.ExecuteNonQuery();

                int nSel = 0;

                foreach (DataGridViewRow row in dataGridViewBricks.Rows)
                {
                    if (row.Cells["selected"].Value != null && row.Cells["selected"].Value.ToString() != "")
                    {
                        if (bool.Parse(row.Cells["selected"].Value.ToString()) == true)
                        {
                            //Esto es maravilloso pero para SQLSERVER 2000 no funciona --> insertaremos en tabla temporal
                            //DataRow rowBrick = bricksTable.NewRow();
                            //rowBrick["sIdBrick"] = row.Cells["sIdBrick"].Value.ToString();
                            //bricksTable.Rows.Add(rowBrick);

                            //Insertar brick en tabla temporal
                            if (sqlConn.State.ToString() == "Closed")
                                sqlConn.Open();

                            sqlCmdSetBrickTemp.Parameters["@Action"].Value = 1;
                            sqlCmdSetBrickTemp.Parameters["@brick"].Value = row.Cells["sIdBrick"].Value.ToString();
                            sqlCmdSetBrickTemp.ExecuteNonQuery();

                            nSel++;
                        }
                    }
                }

                //if (this.bricksTable.Rows.Count > 0)
                if (nSel > 0)
                {
                    if (sqlConn.State.ToString() == "Closed")
                        sqlConn.Open();

                    // Llenar tabla temporal con resultados según bricks escogidos

                    //Esto es maravilloso pero para SQLSERVER 2000 no funciona --> insertaremos en tabla temporal
                    //sqlCmdSetAlarmasVisitas.Parameters["@LBricks"].Value = bricksTable;
                    sqlCmdSetAlarmasVisitas.ExecuteNonQuery();

                    //Obtener la lista de alarmas para mostrarlas en el grid
                    dsClientes.AlarmasVisitas.Clear();
                    sqldaAlarmasVisitas.Fill(dsClientes);

                    lblNumRegAlarmas.Text = dsClientes.AlarmasVisitas.Rows.Count.ToString();

                    sqlConn.Close();

                }
                else
                    Mensajes.ShowExclamation("No ha seleccionado ningún brick.\r\nSeleccione uno o varios bricks e inténtelo de nuevo.");
            }
            catch (Exception ex) { Mensajes.ShowError(ex.Message); }
            Cursor.Current = Cursors.Default;
        }

       
        private void dataGridViewAlarmas_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            e.PaintParts = DataGridViewPaintParts.ContentForeground;

            Color colorFila = new Color();
            int grupo = int.Parse(this.dataGridViewAlarmas.Rows[e.RowIndex].Cells["grupo"].Value.ToString());

            if (grupo == K_GRUPO_ROJO)
                colorFila = Color.OrangeRed;
            else if (grupo == K_GRUPO_AMARILLO)
                colorFila = Color.Yellow;
            else colorFila = Color.White;


            if ((e.State & DataGridViewElementStates.Selected) == DataGridViewElementStates.Selected)
            {
                colorBlend = new ColorBlend();
                colorBlend.Colors = new Color[] { Utiles.ColorSelecionFilaDataGrid, colorFila, Utiles.ColorSelecionFilaDataGrid};
                colorBlend.Positions = new float[] { 0.0f, 0.8f, 1.0f };

                using (LinearGradientBrush lgb = new LinearGradientBrush(e.RowBounds, Utiles.ColorSelecionFilaDataGrid, colorFila, 0F))
                {
                    lgb.InterpolationColors = colorBlend;

                    e.Graphics.FillRectangle(lgb, e.RowBounds);
                    e.PaintCells(e.RowBounds, DataGridViewPaintParts.Border | DataGridViewPaintParts.ContentForeground);
                    //no default painting 
                    e.Handled = true;
                }
            }
            else
            {
                using (LinearGradientBrush lgb = new LinearGradientBrush(e.RowBounds, colorFila, colorFila, 0F))
                {
                    e.Graphics.FillRectangle(lgb, e.RowBounds);
                    e.PaintCells(e.RowBounds, DataGridViewPaintParts.Border | DataGridViewPaintParts.ContentForeground);
                    e.Handled = true;
                }
            }
        }

        


        private void dataGridViewAlarmas_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
           
        }

        private void dataGridViewAlarmas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!GESTCRM.Utiles.MirarSiAbierto(this, "frmIndicadoresIAlarmas"))
            {
                int iIdCliente = int.Parse(dataGridViewAlarmas.Rows[e.RowIndex].Cells["iIdCliente"].Value.ToString());
                string sIdCliente = dataGridViewAlarmas.Rows[e.RowIndex].Cells["sIdCliente"].Value.ToString();
                string sNombre = dataGridViewAlarmas.Rows[e.RowIndex].Cells["sNombre"].Value.ToString();

                Form frmTemp = new Formularios.frmIndicadoresIAlarmas(2, iIdCliente, sIdCliente, sNombre); //2 = pestanya clientes
                frmTemp.Cursor = Cursors.WaitCursor;
                frmTemp.MdiParent = this.MdiParent;
                frmTemp.Show();
                frmTemp.Cursor = Cursors.Default;
            }
            else
            {
                GESTCRM.Utiles.ActivaFormularioAbierto(this, "frmIndicadoresIAlarmas");
            }
        }

    }


    
}


