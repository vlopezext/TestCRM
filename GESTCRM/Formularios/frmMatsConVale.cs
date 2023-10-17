using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GESTCRM.Formularios
{
    public partial class frmMatsConVale : Form
    {
        private dsMateriales.ListaMatsConValeDataTable _dtMatsConVale;
        private bool _sortidaCreu = true;
        public List<string>[] _arrVal = null;

        private const int K_maxX = 5;
        private const int K_minX = 4;



        public frmMatsConVale()
        {
            InitializeComponent();
        }

        public frmMatsConVale(dsMateriales.ListaMatsConValeDataTable dt)
        {
            InitializeComponent();

            _dtMatsConVale = new dsMateriales.ListaMatsConValeDataTable();
            _dtMatsConVale = dt;

            _arrVal = new List<string>[_dtMatsConVale.Rows.Count];
        }

        private void frmMatsConVale_Load(object sender, EventArgs e)
        {
            dGVMatsConVale.DataSource = _dtMatsConVale;

            //---- GSG (03/07/2014)
            dGVMatsConVale.Focus();
            DataGridViewCell nextCell = dGVMatsConVale.Rows[0].Cells[K_minX];
            if (nextCell != null && nextCell.Visible)
                dGVMatsConVale.CurrentCell = nextCell;
            dGVMatsConVale.Refresh();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            _sortidaCreu = false;
            DialogResult = DialogResult.Cancel;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            _sortidaCreu = false;
            
            int iRet = guardar();

            switch (iRet)
            {
                case 1:  Mensajes.ShowExclamation("La serie y el código de vale no pueden estar vacíos para estos materiales del pedido.");
                         break;
                case 0:  DialogResult = DialogResult.OK;
                         break;
                case -1: Mensajes.ShowError("Se ha producido un error al guardar los datos. Consulte con HelpDesk.");
                         DialogResult = DialogResult.Cancel;
                         break;
            }
        }

        private void frmMatsConVale_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_sortidaCreu)
            { 
                DialogResult = DialogResult.Cancel;
            }
        }


        private int guardar()
        {
            int iRet = 0;
            
            string valorCeldaSerie = "";
            string valorCeldaVale = "";

            //Comprobaciones
            for (int i = 0; i < dGVMatsConVale.Rows.Count; i++)
            {
                if (dGVMatsConVale.Rows[i].Cells["sSerie"].IsInEditMode)
                {
                    valorCeldaSerie = dGVMatsConVale.Rows[i].Cells["sSerie"].EditedFormattedValue.ToString();
                    dGVMatsConVale.Rows[i].Cells["sSerie"].Value = valorCeldaSerie;
                }
                else
                    valorCeldaSerie = dGVMatsConVale.Rows[i].Cells["sSerie"].Value.ToString().Trim();

                if (dGVMatsConVale.Rows[i].Cells["sCodVale"].IsInEditMode)
                {
                    valorCeldaVale = dGVMatsConVale.Rows[i].Cells["sCodVale"].EditedFormattedValue.ToString();
                    dGVMatsConVale.Rows[i].Cells["sCodVale"].Value = valorCeldaVale;
                }
                else
                    valorCeldaVale = dGVMatsConVale.Rows[i].Cells["sCodVale"].Value.ToString().Trim();


                // ----- GSG (29/06/2017)
                // Ahorta se puede introducir únicamente uno de los dos valores

                //if (valorCeldaSerie == null || valorCeldaSerie == "" ||
                //    valorCeldaVale == null || valorCeldaVale == "")
                //{
                //    //---- GSG (05/02/2015)
                //    // Ahora no es obligatorio introducir los valores.
                //    //iRet = 1;                    
                //    //break;

                //    valorCeldaSerie = " ";
                //    valorCeldaVale = " ";

                //    List<string> linVal = new List<string>();

                //    linVal.Add(dGVMatsConVale.Rows[i].Cells["sIdMaterial"].Value.ToString());
                //    linVal.Add(valorCeldaSerie);
                //    linVal.Add(valorCeldaVale);

                //    _arrVal.SetValue(linVal, i);
                //}
                //else
                //{
                //    List<string> linVal = new List<string>();

                //    linVal.Add(dGVMatsConVale.Rows[i].Cells["sIdMaterial"].Value.ToString());
                //    linVal.Add(valorCeldaSerie);
                //    linVal.Add(valorCeldaVale);

                //    _arrVal.SetValue(linVal, i);
                //}


                if (valorCeldaSerie == null)
                    valorCeldaSerie = " ";

                if (valorCeldaVale == null)
                    valorCeldaVale = " ";


                List<string> linVal = new List<string>();

                linVal.Add(dGVMatsConVale.Rows[i].Cells["sIdMaterial"].Value.ToString());
                linVal.Add(valorCeldaSerie);
                linVal.Add(valorCeldaVale);

                _arrVal.SetValue(linVal, i);


            }

            return iRet;
        }

        private void frmMatsConVale_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_sortidaCreu)
            {
                _sortidaCreu = false;
                DialogResult = DialogResult.Cancel;
            }
        }

        //---- GSG (03/07/2014)

        private void dGVMatsConVale_KeyDown(object sender, KeyEventArgs e)
        {
            char keyCharLeft = Convert.ToChar(Keys.Left);
            char keyCharRight = Convert.ToChar(Keys.Right);
            char keyCharUp = Convert.ToChar(Keys.Up);
            char keyCharDown = Convert.ToChar(Keys.Down);
            char keyCharTab = Convert.ToChar(Keys.Tab);

            DataGridViewCell currentCell = dGVMatsConVale.CurrentCell;

            if (currentCell != null)
            {
                int nextRow = 0;
                int nextCol = K_minX;

                if (e.KeyValue == keyCharLeft)
                {
                    nextRow = currentCell.RowIndex;
                    nextCol = currentCell.ColumnIndex - 1;
                }
                else if (e.KeyValue == keyCharRight)
                {
                    nextRow = currentCell.RowIndex;
                    nextCol = currentCell.ColumnIndex + 1;
                }
                else if (e.KeyValue == keyCharUp)
                {
                    nextRow = currentCell.RowIndex - 1;
                    nextCol = currentCell.ColumnIndex;
                }
                else if (e.KeyValue == keyCharDown)
                {
                    nextRow = currentCell.RowIndex + 1;
                    nextCol = currentCell.ColumnIndex;
                }
                else if (e.KeyValue == keyCharTab)
                {
                    nextRow = currentCell.RowIndex;
                    nextCol = currentCell.ColumnIndex + 1;
                }

                if (nextCol > K_maxX)
                {
                    nextCol = K_minX;
                    nextRow++;
                }

                if (nextCol < K_minX)
                {
                    if (nextRow > 0)
                        nextCol = K_maxX;

                    nextRow--;
                }

                if (nextRow >= dGVMatsConVale.RowCount || nextRow < 0)
                {
                    nextRow = 0;
                }

                DataGridViewCell nextCell = dGVMatsConVale.Rows[nextRow].Cells[nextCol];

                if (nextCell != null && nextCell.Visible)
                {
                    dGVMatsConVale.CurrentCell = nextCell;
                }

                e.Handled = true;
            }
        }

        private void dGVMatsConVale_MouseClick(object sender, MouseEventArgs e)
        {
            if (dGVMatsConVale.CurrentCell.ColumnIndex < K_minX || dGVMatsConVale.CurrentCell.ColumnIndex > K_maxX)
            {
                DataGridViewCell nextCell = dGVMatsConVale.Rows[0].Cells[K_minX];
                if (nextCell != null && nextCell.Visible)
                {
                    dGVMatsConVale.CurrentCell = nextCell;
                }
            }
        }


    }
}
