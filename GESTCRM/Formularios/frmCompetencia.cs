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
    public partial class txtbLeyenda : Form
    {
        const int K_MAX_COMP = 6;
        const int K_POS_COMP = 7;
        const int K_POS_STADA = 6;

        private System.Data.SqlClient.SqlCommand sqlCmdDatosComp;
        private DataGridView _dataGridViewPedido;
        private string _sIdPedido = "";
        private int _NumCampos = 0;
        private int _IndexDesc = K_POS_STADA;
        private double[] _netosComp = new double[K_MAX_COMP];
        private double[] _descMediosComp = new double[K_MAX_COMP];
        private string[] _nombresComp = new string[K_MAX_COMP];
        private int _iNumCompReal = 0;
        private double _netoStada = 0.0;
        private double _descMedioStada = 0.0;
        private Color _cSinDescComp = Color.LightCoral;

        public txtbLeyenda()
        {
            InitializeComponent();
        }

        public txtbLeyenda(DataGridView dg, string sIdPedido)
        {
            InitializeComponent();

            _dataGridViewPedido = dg;
            _sIdPedido = sIdPedido;

            Inits();
        }


        private void frmCompetencia_Load(object sender, EventArgs e)
        {
            txtbLeyenda1.BackColor = _cSinDescComp;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }


        private void Inits()
        {
            GetValoresCompetencia(_sIdPedido);
            GetTotales();
        }


        private void GetValoresCompetencia(string pedido)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataReader dr;

                if (sqlConn.State.ToString() == "Closed")
                    sqlConn.Open();

                sqlCmdDatosComp.Parameters["@sIdPedido"].Value = pedido;

                dr = sqlCmdDatosComp.ExecuteReader();

                // sCodNacional, sMaterial, PRECIO, Unidades, BRUTO, NETO, NombreCampanya (STADA), [campcomp 1], [campcomp 2], [campcomp 3], [campcomp 4], [campcomp 5], [campcomp 6]

                DataTable schemaTable = dr.GetSchemaTable();
                int index = 0;

                foreach (DataRow row in schemaTable.Rows)
                {
                    DataGridViewColumn dc = new DataGridViewColumn();
                    dc.Name = row.Field<String>("ColumnName");
                    dc.CellTemplate = new DataGridViewTextBoxCell();
                    dc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                    switch (index)
                    {
                        case 0: dc.HeaderText = "Cód. Nacional";
                                dc.Width = 80;
                                break;
                        case 1: dc.HeaderText = "Material";
                                dc.Width = 300;
                                break;
                        case 2: dc.Visible = false;                                
                                break;
                        case 3: dc.HeaderText = "Unidades";
                                dc.Width = 80;
                                dc.DefaultCellStyle.Format = "N";
                                break;
                        case 4: dc.Visible = false;
                                break;
                        case 5: dc.Visible = false;
                                break;
                        case 6: dc.HeaderText = "STADA";
                                dc.Width = 80;
                                dc.DefaultCellStyle.Format = "N2";
                                break;
                        default: dc.HeaderText = row.Field<String>("ColumnName");
                                 dc.Width = 80;
                                 dc.DefaultCellStyle.Format = "N2";                                 
                                 _nombresComp[index - K_POS_COMP] = row.Field<String>("ColumnName");
                                 _iNumCompReal++;
                                break;
                    }

                    dGVDatos.Columns.Add(dc);

                    index++; // columna
                }

                
                if (dr.HasRows)
                {                    
                    // El máximo será 13 ya que permitimos 6 competencias y como mínimo los 7 primeros
                    // Las celdas que vienen a null las pintaremos para indicar que que la presentación no existe en la competencia 
                    // (no es lo mismo que tengan descuento 0 a que no tengan la presentación)

                    _NumCampos = dr.FieldCount;
                    index = 0;

                    while (dr.Read())
                    {
                        switch (_NumCampos)
                        {
                            case 7: dGVDatos.Rows.Add(dr.GetString(0), dr.GetString(1), dr.IsDBNull(2) ? 0 : dr.GetDouble(2), dr.IsDBNull(3) ? 0 : dr.GetInt32(3), dr.IsDBNull(4) ? 0 : dr.GetDouble(4), dr.IsDBNull(5) ? 0 : dr.GetDouble(5), dr.IsDBNull(_IndexDesc) ? 0 : dr.GetDouble(_IndexDesc));
                                break;
                            case 8: dGVDatos.Rows.Add(dr.GetString(0), dr.GetString(1), dr.IsDBNull(2) ? 0 : dr.GetDouble(2), dr.IsDBNull(3) ? 0 : dr.GetInt32(3), dr.IsDBNull(4) ? 0 : dr.GetDouble(4), dr.IsDBNull(5) ? 0 : dr.GetDouble(5), dr.IsDBNull(_IndexDesc) ? 0 : dr.GetDouble(_IndexDesc), dr.IsDBNull(_IndexDesc + 1) ? 0 : dr.GetDouble(_IndexDesc + 1));
                                    if (dr.IsDBNull(_IndexDesc + 1))
                                        dGVDatos.Rows[index].Cells[_IndexDesc + 1].Style.BackColor = _cSinDescComp;
                                    break;
                            case 9: dGVDatos.Rows.Add(dr.GetString(0), dr.GetString(1), dr.IsDBNull(2) ? 0 : dr.GetDouble(2), dr.IsDBNull(3) ? 0 : dr.GetInt32(3), dr.IsDBNull(4) ? 0 : dr.GetDouble(4), dr.IsDBNull(5) ? 0 : dr.GetDouble(5), dr.IsDBNull(_IndexDesc) ? 0 : dr.GetDouble(_IndexDesc), dr.IsDBNull(_IndexDesc + 1) ? 0 : dr.GetDouble(_IndexDesc + 1), dr.IsDBNull(_IndexDesc + 2) ? 0 : dr.GetDouble(_IndexDesc + 2));
                                    if (dr.IsDBNull(_IndexDesc + 1))
                                        dGVDatos.Rows[index].Cells[_IndexDesc + 1].Style.BackColor = _cSinDescComp;
                                    if (dr.IsDBNull(_IndexDesc + 2))
                                        dGVDatos.Rows[index].Cells[_IndexDesc + 2].Style.BackColor = _cSinDescComp;
                                break;
                            case 10: dGVDatos.Rows.Add(dr.GetString(0), dr.GetString(1), dr.IsDBNull(2) ? 0 : dr.GetDouble(2), dr.IsDBNull(3) ? 0 : dr.GetInt32(3), dr.IsDBNull(4) ? 0 : dr.GetDouble(4), dr.IsDBNull(5) ? 0 : dr.GetDouble(5), dr.IsDBNull(_IndexDesc) ? 0 : dr.GetDouble(_IndexDesc), dr.IsDBNull(_IndexDesc + 1) ? 0 : dr.GetDouble(_IndexDesc + 1), dr.IsDBNull(_IndexDesc + 2) ? 0 : dr.GetDouble(_IndexDesc + 2), dr.IsDBNull(_IndexDesc + 3) ? 0 : dr.GetDouble(_IndexDesc + 3));
                                    if (dr.IsDBNull(_IndexDesc + 1))
                                        dGVDatos.Rows[index].Cells[_IndexDesc + 1].Style.BackColor = _cSinDescComp;
                                    if (dr.IsDBNull(_IndexDesc + 2))
                                        dGVDatos.Rows[index].Cells[_IndexDesc + 2].Style.BackColor = _cSinDescComp;
                                    if (dr.IsDBNull(_IndexDesc + 3))
                                        dGVDatos.Rows[index].Cells[_IndexDesc + 3].Style.BackColor = _cSinDescComp;
                                break;
                            case 11: dGVDatos.Rows.Add(dr.GetString(0), dr.GetString(1), dr.IsDBNull(2) ? 0 : dr.GetDouble(2), dr.IsDBNull(3) ? 0 : dr.GetInt32(3), dr.IsDBNull(4) ? 0 : dr.GetDouble(4), dr.IsDBNull(5) ? 0 : dr.GetDouble(5), dr.IsDBNull(_IndexDesc) ? 0 : dr.GetDouble(_IndexDesc), dr.IsDBNull(_IndexDesc + 1) ? 0 : dr.GetDouble(_IndexDesc + 1), dr.IsDBNull(_IndexDesc + 2) ? 0 : dr.GetDouble(_IndexDesc + 2), dr.IsDBNull(_IndexDesc + 3) ? 0 : dr.GetDouble(_IndexDesc + 3), dr.IsDBNull(_IndexDesc + 4) ? 0 : dr.GetDouble(_IndexDesc + 4));
                                    if (dr.IsDBNull(_IndexDesc + 1))
                                        dGVDatos.Rows[index].Cells[_IndexDesc + 1].Style.BackColor = _cSinDescComp;
                                    if (dr.IsDBNull(_IndexDesc + 2))
                                        dGVDatos.Rows[index].Cells[_IndexDesc + 2].Style.BackColor = _cSinDescComp;
                                    if (dr.IsDBNull(_IndexDesc + 3))
                                        dGVDatos.Rows[index].Cells[_IndexDesc + 3].Style.BackColor = _cSinDescComp;
                                    if (dr.IsDBNull(_IndexDesc + 4))
                                        dGVDatos.Rows[index].Cells[_IndexDesc + 4].Style.BackColor = _cSinDescComp;
                                break;
                            case 12: dGVDatos.Rows.Add(dr.GetString(0), dr.GetString(1), dr.IsDBNull(2) ? 0 : dr.GetDouble(2), dr.IsDBNull(3) ? 0 : dr.GetInt32(3), dr.IsDBNull(4) ? 0 : dr.GetDouble(4), dr.IsDBNull(5) ? 0 : dr.GetDouble(5), dr.IsDBNull(_IndexDesc) ? 0 : dr.GetDouble(_IndexDesc), dr.IsDBNull(_IndexDesc + 1) ? 0 : dr.GetDouble(_IndexDesc + 1), dr.IsDBNull(_IndexDesc + 2) ? 0 : dr.GetDouble(_IndexDesc + 2), dr.IsDBNull(_IndexDesc + 3) ? 0 : dr.GetDouble(_IndexDesc + 3), dr.IsDBNull(_IndexDesc + 4) ? 0 : dr.GetDouble(_IndexDesc + 4), dr.IsDBNull(_IndexDesc + 5) ? 0 : dr.GetDouble(_IndexDesc + 5));
                                    if (dr.IsDBNull(_IndexDesc + 1))
                                        dGVDatos.Rows[index].Cells[_IndexDesc + 1].Style.BackColor = _cSinDescComp;
                                    if (dr.IsDBNull(_IndexDesc + 2))
                                        dGVDatos.Rows[index].Cells[_IndexDesc + 2].Style.BackColor = _cSinDescComp;
                                    if (dr.IsDBNull(_IndexDesc + 3))
                                        dGVDatos.Rows[index].Cells[_IndexDesc + 3].Style.BackColor = _cSinDescComp;
                                    if (dr.IsDBNull(_IndexDesc + 4))
                                        dGVDatos.Rows[index].Cells[_IndexDesc + 4].Style.BackColor = _cSinDescComp;
                                    if (dr.IsDBNull(_IndexDesc + 5))
                                        dGVDatos.Rows[index].Cells[_IndexDesc + 5].Style.BackColor = _cSinDescComp;
                                break;
                            case 13: dGVDatos.Rows.Add(dr.GetString(0), dr.GetString(1), dr.IsDBNull(2) ? 0 : dr.GetDouble(2), dr.IsDBNull(3) ? 0 : dr.GetInt32(3), dr.IsDBNull(4) ? 0 : dr.GetDouble(4), dr.IsDBNull(5) ? 0 : dr.GetDouble(5), dr.IsDBNull(_IndexDesc) ? 0 : dr.GetDouble(_IndexDesc), dr.IsDBNull(_IndexDesc + 1) ? 0 : dr.GetDouble(_IndexDesc + 1), dr.IsDBNull(_IndexDesc + 2) ? 0 : dr.GetDouble(_IndexDesc + 2), dr.IsDBNull(_IndexDesc + 3) ? 0 : dr.GetDouble(_IndexDesc + 3), dr.IsDBNull(_IndexDesc + 4) ? 0 : dr.GetDouble(_IndexDesc + 4), dr.IsDBNull(_IndexDesc + 5) ? 0 : dr.GetDouble(_IndexDesc + 5), dr.IsDBNull(_IndexDesc + 6) ? 0 : dr.GetDouble(_IndexDesc + 6));
                                    if (dr.IsDBNull(_IndexDesc + 1))
                                        dGVDatos.Rows[index].Cells[_IndexDesc + 1].Style.BackColor = _cSinDescComp;
                                    if (dr.IsDBNull(_IndexDesc + 2))
                                        dGVDatos.Rows[index].Cells[_IndexDesc + 2].Style.BackColor = _cSinDescComp;
                                    if (dr.IsDBNull(_IndexDesc + 3))
                                        dGVDatos.Rows[index].Cells[_IndexDesc + 3].Style.BackColor = _cSinDescComp;
                                    if (dr.IsDBNull(_IndexDesc + 4))
                                        dGVDatos.Rows[index].Cells[_IndexDesc + 4].Style.BackColor = _cSinDescComp;
                                    if (dr.IsDBNull(_IndexDesc + 5))
                                        dGVDatos.Rows[index].Cells[_IndexDesc + 5].Style.BackColor = _cSinDescComp;
                                    if (dr.IsDBNull(_IndexDesc + 6))
                                        dGVDatos.Rows[index].Cells[_IndexDesc + 6].Style.BackColor = _cSinDescComp;
                                break;
                        }
                        
                        index++; //fila
                    }
                }

                dr.Close();

            }
            catch (Exception e)
            {
                string err = e.Message;
            }
        }


        private void GetTotales()
        {
            try
            {
                Calcular();
                MostrarCalculos();
            }
            catch (Exception e)
            {
                string err = e.Message;
            }
        }


        private void Calcular()
        {
            // sCodNacional, sMaterial, PRECIO, Unidades, BRUTO, NETO, NombreCampanya (STADA), [campcomp 1], [campcomp 2], [campcomp 3], [campcomp 4], [campcomp 5], [campcomp 6]

            double precio = 0.0;
            int unidades = 0;
            double bruto = 0.0;
            double brutoTotal = 0.0;

            try
            {

                for (int j = 0; j < K_MAX_COMP; j++)
                {
                    _netosComp[j] = 0.0;
                }

                // Cálculo Netos

                for (int i = 0; i < dGVDatos.Rows.Count; i++)
                {
                    precio = double.Parse(dGVDatos.Rows[i].Cells["PRECIO"].Value.ToString());
                    unidades = int.Parse(dGVDatos.Rows[i].Cells["Unidades"].Value.ToString());
                    bruto = precio * unidades;
                    brutoTotal += bruto;

                    _netoStada += double.Parse(dGVDatos.Rows[i].Cells["NETO"].Value.ToString());

                    for (int j = 0; j < _iNumCompReal; j++)
                    {
                        _netosComp[j] += bruto - (bruto * double.Parse(dGVDatos.Rows[i].Cells[_IndexDesc + 1 + j].Value.ToString()) / 100);
                    }
                }


                // Calculo Descuentos Medios
                _descMedioStada = (1 - (_netoStada / brutoTotal)) * 100;

                for (int j = 0; j < _iNumCompReal; j++)
                {
                    _descMediosComp[j] += (1 - (_netosComp[j] / brutoTotal)) * 100;
                }
            }
            catch (Exception e)
            {
                string err = e.Message;
            }
            
        }


        private void MostrarCalculos()
        {
            // sCodNacional, sMaterial, PRECIO, Unidades, BRUTO, NETO, NombreCampanya (STADA), [campcomp 1], [campcomp 2], [campcomp 3], [campcomp 4], [campcomp 5], [campcomp 6]

            // Afegir columnes a taula de totals

            DataGridViewColumn dcDetalle = new DataGridViewColumn();
            dcDetalle.CellTemplate = new DataGridViewTextBoxCell();
            dcDetalle.Name = "detalle";
            dcDetalle.HeaderText = "  ";
            dcDetalle.Width = 172;

            dGVTotales.Columns.Add(dcDetalle);

            DataGridViewColumn dcS = new DataGridViewColumn();
            dcS.CellTemplate = new DataGridViewTextBoxCell();
            dcS.Name = "Stada";
            dcS.HeaderText = "STADA";
            dcS.Width = 80;     

            dGVTotales.Columns.Add(dcS);

            for (int i = 0; i < _iNumCompReal; i++)
            {
                DataGridViewColumn dc = new DataGridViewColumn();
                dc.Name = _nombresComp[i];
                dc.CellTemplate = new DataGridViewTextBoxCell();
                dc.HeaderText = _nombresComp[i];
                dc.Width = 80;

                dGVTotales.Columns.Add(dc);
            }

            object[] arrayValores = new object[_iNumCompReal + 2];

            arrayValores[0] = "Importe Neto";
            arrayValores[1] = _netoStada;
    
            for (int i = 0; i < _iNumCompReal; i++)
            {
                arrayValores[i+2] = _netosComp[i];
            }

            dGVTotales.Rows.Add(arrayValores);
            

            arrayValores[0] = "Descuento Medio";
            arrayValores[1] = _descMedioStada;

            for (int i = 0; i < _iNumCompReal; i++)
            {
                arrayValores[i+2] = _descMediosComp[i];
            }

            dGVTotales.Rows.Add(arrayValores);

            dGVTotales.Rows[0].DefaultCellStyle.Format = "C";
            dGVTotales.Rows[1].DefaultCellStyle.Format = "0.00\\%";
            
        }

        
        private string GetListaMaterialesPedido()
        {
            string lista = "";

            for (int i = 0; i < _dataGridViewPedido.Rows.Count; i++)
                lista += _dataGridViewPedido.Rows[i].Cells["sIdMaterialDataGridViewTextBoxColumn"].Value.ToString() + ",";

            if (lista.Length >= 1)
                lista = lista.Substring(0, lista.Length - 1);

            return lista;

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
