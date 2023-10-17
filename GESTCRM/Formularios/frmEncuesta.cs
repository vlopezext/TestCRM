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
    public partial class frmEncuesta : Form
    {
        private System.Data.SqlClient.SqlConnection sqlConn;

        private System.Data.SqlClient.SqlDataAdapter sqldaDatosEncuestasDisponibles;
        private System.Data.SqlClient.SqlCommand sqlCmdDatosEncuestasDisponibles;
        private System.Data.SqlClient.SqlCommand sqlCmdSetRespuestasDadas;
        private System.Data.SqlClient.SqlCommand sqlCmdSetEncuestaContestada;


        private List<Formularios.DataSets.dsEncuestas.DatosEncuestasClienteRow> _lDatosEncuestasCliente = new List<DataSets.dsEncuestas.DatosEncuestasClienteRow>();
        private List<string> _lPreguntas = new List<string>();
        private List<string> _lRespuestas = new List<string>();
        private int _iPreguntaActiva = 0;
        private int[] _aiRespuestasDadas = new int[10];
        private string _sCliente = "";
        private bool _bGuardada = false; //---- GSG (24/10/2019)

        public frmEncuesta(int delegado, string cliente)
        {
            InitializeComponent();

            //---- GSG (06/03/2021)
            Utiles.GetConfigConnection();
            this.sqlConn.ConnectionString = Utiles._connection.ConnectionString.ToString();

            
            _sCliente = cliente;

            _bGuardada = false; //---- GSG (24/10/2019)

            ObtenerDatosEncuestas(delegado, cliente);

            if (_lDatosEncuestasCliente != null && _lDatosEncuestasCliente.Count > 0)
            {
                ActivarControles(true);
                CargaComboEncuestasDisponibles();
            }
            else
            {
                ActivarControles(false);
            }
        }


        public bool HayQueHacerlaSiOSi()
        {
            bool bRet = false;

            if (cbEncuesta.Items.Count > 0)
            {
                foreach (Formularios.DataSets.dsEncuestas.DatosEncuestasClienteRow r in _lDatosEncuestasCliente)
                {
                    if ((r.bObligatoria || r.bObligatoria1) && r.iIdRespuesta == -1)
                    {
                        bRet = true;
                        break;
                    }
                }
            }

            return bRet;
        }

        public bool EncuestaPendiente()
        {
            return !estaContestada();
        }


        private void ActivarControles(bool activar)
        {
            label1.Visible = activar;
            cbEncuesta.Visible = activar;
            lblPregunta.Visible = activar;
            cbRespuesta.Visible = activar;
            btAnterior.Visible = activar;
            btSiguiente.Visible = activar;
            btGuardar.Visible = activar;
            pictureBox2.Visible = activar;
            lblResultado.Visible = activar;
            lblContador.Visible = activar;

            if (activar)
            {
                lblEncuesta.Text = "";
            }
            else
            {
                lblEncuesta.Text = "No hay encuestas activas para este cliente.";
            }
        }


        private void CargaComboEncuestasDisponibles()
        {
            try
            {
                List<string> lista = new List<string>();
                lista = GetTituloEncuestas();
                cbEncuesta.Items.Clear();

                if (lista.Count > 0)
                {
                    for (int i = 0; i < lista.Count; i++)
                    {

                        cbEncuesta.Items.Add(lista[i]);
                    }

                    cbEncuesta.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                Mensajes.ShowError(ex.Message);
            }
        }

        private void CargaComboRespuestas()
        {
            try
            {
                _lRespuestas.Clear();
                _lRespuestas = GetRespuestas(int.Parse(txtbIdEncuesta.Text), int.Parse(txtbIdPregunta.Text));
                cbRespuesta.Items.Clear();

                if (_lRespuestas.Count > 0)
                {
                    for (int i = 0; i < _lRespuestas.Count; i++)
                    {
                        cbRespuesta.Items.Add(_lRespuestas[i]);
                    }

                    // Mira si ya se había respondido, en tal caso mostrar la última respuesta


                    cbRespuesta.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                Mensajes.ShowError(ex.Message);
            }
        }

        private void muestraPreguntaActiva(int encuesta, int pregunta)
        {
            lblContador.Text = _iPreguntaActiva.ToString() + " / " + _lPreguntas.Count.ToString();
            lblPregunta.Text = _lPreguntas[_iPreguntaActiva - 1];
            txtbIdPregunta.Text = pregunta.ToString();

            _lRespuestas.Clear();
            _lRespuestas = GetRespuestas(encuesta, pregunta);

            CargaComboRespuestas();
        }


        #region leer de carga

        private List<string> GetTituloEncuestas()
        {
            List<string> lista = new List<string>();

            foreach (Formularios.DataSets.dsEncuestas.DatosEncuestasClienteRow r in _lDatosEncuestasCliente)
            {
                if (!lista.Contains(r.sDescripcion))
                    lista.Add(r.sDescripcion);
            }

            return lista;
        }

        private int GetIdEncuesta(string tituloEncuesta)
        {
            int Id = -1;

            foreach (Formularios.DataSets.dsEncuestas.DatosEncuestasClienteRow r in _lDatosEncuestasCliente)
            {
                if (r.sDescripcion == tituloEncuesta)
                {
                    Id = r.idEncuesta;
                    break;
                }
            }

            return Id;
        }

        private bool EsEncuestaObligatoria(int encuesta)
        {
            bool bRet = false;

            foreach (Formularios.DataSets.dsEncuestas.DatosEncuestasClienteRow r in _lDatosEncuestasCliente)
            {
                if (r.idEncuesta == encuesta && (r.bObligatoria || r.bObligatoria1))
                {
                    bRet = true;
                    break;
                }
            }

            return bRet;
        }


        private List<string> GetPreguntas(int encuesta)
        {
            List<string> lista = new List<string>();

            foreach (Formularios.DataSets.dsEncuestas.DatosEncuestasClienteRow r in _lDatosEncuestasCliente)
            {
                if (r.idEncuesta == encuesta && !lista.Contains(r.sPregunta))
                    lista.Add(r.sPregunta);
            }

            return lista;
        }

        private int GetIdPregunta(int encuesta, string pregunta)
        {
            int Id = -1;

            foreach (Formularios.DataSets.dsEncuestas.DatosEncuestasClienteRow r in _lDatosEncuestasCliente)
            {
                if (r.idEncuesta == encuesta && r.sPregunta == pregunta)
                {
                    Id = r.idPregunta;
                    break;
                }
            }

            return Id;
        }


        private List<string> GetRespuestas(int encuesta, int pregunta)
        {
            List<string> lista = new List<string>();

            foreach (Formularios.DataSets.dsEncuestas.DatosEncuestasClienteRow r in _lDatosEncuestasCliente)
            {
                if (r.idEncuesta == encuesta && r.idPregunta == pregunta && !lista.Contains(r.sRespuesta))
                    lista.Add(r.sRespuesta);
            }

            return lista;
        }


        private void GetRespuestasDadaEnAnteriorGrabacion(int encuesta)
        {
            List<string> lista = new List<string>();
            int index = 0;
            int preguntaAnt = -1;

            foreach (Formularios.DataSets.dsEncuestas.DatosEncuestasClienteRow r in _lDatosEncuestasCliente)
            {
                if (r.idEncuesta == encuesta)
                {
                    if (preguntaAnt != r.idPregunta)
                    {
                        _aiRespuestasDadas[index] = r.iIdRespuesta;
                        index++;
                        preguntaAnt = r.idPregunta;
                    }
                }
            }
        }


        private int GetIdRespuesta(int encuesta, int pregunta, string respuesta)
        {
            int Id = -1;

            foreach (Formularios.DataSets.dsEncuestas.DatosEncuestasClienteRow r in _lDatosEncuestasCliente)
            {
                if (r.idEncuesta == encuesta && r.idPregunta == pregunta && r.sRespuesta == respuesta)
                {
                    Id = r.idRespuesta;
                    break;
                }
            }

            return Id;
        }

        private string GetTextoRespuesta(int encuesta, int pregunta, int respuesta)
        {
            string descripcion = "";

            foreach (Formularios.DataSets.dsEncuestas.DatosEncuestasClienteRow r in _lDatosEncuestasCliente)
            {
                if (r.idEncuesta == encuesta && r.idPregunta == pregunta && r.idRespuesta == respuesta)
                {
                    descripcion = r.sRespuesta;
                    break;
                }
            }

            return descripcion;
        }

        private bool estaContestada()
        {
            bool bRet = true;

            for (int i = 0; i < _lPreguntas.Count; i++)
            {
                if (_aiRespuestasDadas[i] == -1)
                {
                    bRet = false;
                    break;
                }
            }

            return bRet;
        }




        #endregion


        #region BBDD

        private bool ObtenerDatosEncuestas(int iIdDelegado, string sIdCliente)
        {
            bool bRet = true;

            try
            {
                if (sqlConn.State.ToString() == "Closed")
                    sqlConn.Open();

                _lDatosEncuestasCliente.Clear();

                sqlCmdDatosEncuestasDisponibles.Parameters["@idDelegado"].Value = iIdDelegado;
                sqlCmdDatosEncuestasDisponibles.Parameters["@sIdCliente"].Value = sIdCliente;


                this.sqldaDatosEncuestasDisponibles.Fill(this.dsEnc);

                foreach (Formularios.DataSets.dsEncuestas.DatosEncuestasClienteRow rw in dsEnc.DatosEncuestasCliente.Rows)
                {
                    _lDatosEncuestasCliente.Add(rw);
                }
            }
            catch (Exception e)
            {
                Mensajes.ShowError(e.ToString());
                bRet = false;
            }

            return bRet;
        }


        //---- GSG (24/10/2019)
        //private bool guardarRespuestasDadas(string cliente, int encuesta, int pregunta, int respuestaDada)
        private bool guardarRespuestasDadas(string cliente, int encuesta, int pregunta, int respuestaDada, int delegado, string red)
        {
            bool bRet = true;

            try
            {
                if (sqlConn.State.ToString() == "Closed")
                    sqlConn.Open();

                sqlCmdSetRespuestasDadas.Parameters["@sIdCliente"].Value = cliente;
                sqlCmdSetRespuestasDadas.Parameters["@idEncuesta"].Value = encuesta;
                sqlCmdSetRespuestasDadas.Parameters["@idPregunta"].Value = pregunta;
                sqlCmdSetRespuestasDadas.Parameters["@idRespuestaDada"].Value = respuestaDada;
                //---- GSG (24/10/2019)
                sqlCmdSetRespuestasDadas.Parameters["@iIdDelegado"].Value = delegado;
                sqlCmdSetRespuestasDadas.Parameters["@sRed"].Value = red;

                sqlCmdSetRespuestasDadas.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                bRet = false;
                Mensajes.ShowError(e.ToString());
            }

            return bRet;
        }

        private bool guardarEstadoContestada(string cliente, int encuesta, bool contestada)
        {
            bool bRet = true;

            try
            {
                if (sqlConn.State.ToString() == "Closed")
                    sqlConn.Open();

                sqlCmdSetEncuestaContestada.Parameters["@sIdCliente"].Value = cliente;
                sqlCmdSetEncuestaContestada.Parameters["@idEncuesta"].Value = encuesta;
                sqlCmdSetEncuestaContestada.Parameters["@bContestada"].Value = contestada;

                sqlCmdSetEncuestaContestada.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                bRet = false;
                Mensajes.ShowError(e.ToString());
            }

            return bRet;
        }



        #region eventos
        private void cbEncuesta_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idEncuesta = GetIdEncuesta(cbEncuesta.Text);
            lblEncuesta.Text = cbEncuesta.Text;
            txtbIdEncuesta.Text = idEncuesta.ToString();

            _lPreguntas.Clear();
            _lPreguntas = GetPreguntas(idEncuesta);

            _iPreguntaActiva = 1;
            btAnterior.Visible = false;
            btSiguiente.Visible = true;

            _lRespuestas.Clear();



            int idPregunta = GetIdPregunta(idEncuesta, _lPreguntas[_iPreguntaActiva - 1]);
            muestraPreguntaActiva(idEncuesta, idPregunta);

            GetRespuestasDadaEnAnteriorGrabacion(idEncuesta);

            lblRespuestaDada.Text = GetTextoRespuesta(idEncuesta, idPregunta, _aiRespuestasDadas[_iPreguntaActiva - 1]);
            cbRespuesta.Text = lblRespuestaDada.Text;


        }

        private void btSiguiente_Click(object sender, EventArgs e)
        {
            int encuesta = int.Parse(txtbIdEncuesta.Text);
            int idPregunta = GetIdPregunta(encuesta, _lPreguntas[_iPreguntaActiva - 1]); // anterior

            if (!btAnterior.Visible)
                btAnterior.Visible = true;

            // Antes de siguiente guardar respuesta anterior pregunta
            _aiRespuestasDadas[_iPreguntaActiva - 1] = GetIdRespuesta(encuesta, idPregunta, cbRespuesta.Text);

            // Siguiente pregunta
            if (_iPreguntaActiva < _lPreguntas.Count)
            {
                _iPreguntaActiva++;
                idPregunta = GetIdPregunta(encuesta, _lPreguntas[_iPreguntaActiva - 1]); //en curso
                muestraPreguntaActiva(encuesta, idPregunta);
                lblRespuestaDada.Text = GetTextoRespuesta(encuesta, idPregunta, _aiRespuestasDadas[_iPreguntaActiva - 1]);
                cbRespuesta.Text = lblRespuestaDada.Text;
            }
        }



        private void btAnterior_Click(object sender, EventArgs e)
        {
            int encuesta = int.Parse(txtbIdEncuesta.Text);
            int idPregunta = GetIdPregunta(encuesta, _lPreguntas[_iPreguntaActiva - 1]); //previa

            if (!btSiguiente.Visible)
                btSiguiente.Visible = true;

            // Antes de anterior guardar respuesta anterior pregunta
            _aiRespuestasDadas[_iPreguntaActiva - 1] = GetIdRespuesta(encuesta, idPregunta, cbRespuesta.Text);

            // siguiente pregunta
            if (_iPreguntaActiva > 1)
            {
                _iPreguntaActiva--;
                idPregunta = GetIdPregunta(encuesta, _lPreguntas[_iPreguntaActiva - 1]); //actual
                muestraPreguntaActiva(encuesta, idPregunta);
                lblRespuestaDada.Text = GetTextoRespuesta(encuesta, idPregunta, _aiRespuestasDadas[_iPreguntaActiva - 1]);
                cbRespuesta.Text = lblRespuestaDada.Text;
            }
        }

        private void btSiguiente_MouseUp(object sender, MouseEventArgs e)
        {
            if (_iPreguntaActiva == _lPreguntas.Count)
                btSiguiente.Visible = false;
        }

        private void btAnterior_MouseUp(object sender, MouseEventArgs e)
        {
            if (_iPreguntaActiva == 1)
                btAnterior.Visible = false;
        }

        private void btGuardar_Click(object sender, EventArgs e)
        {
            int encuesta = int.Parse(txtbIdEncuesta.Text);
            int idPregunta = -1;

            // Si está en la última pregunta o se pulsa guardar antes de cambiar de pregunta ai que guardar la respuesta
            idPregunta = GetIdPregunta(encuesta, _lPreguntas[_iPreguntaActiva - 1]);
            _aiRespuestasDadas[_iPreguntaActiva - 1] = GetIdRespuesta(encuesta, idPregunta, cbRespuesta.Text);


            string miss = "Los datos que se van a guardar de la encuenta " + lblEncuesta.Text + " son los siguientes:\r\r";
            for (int i = 0; i < _lPreguntas.Count; i++)
            {
                idPregunta = GetIdPregunta(encuesta, _lPreguntas[i]);
                miss += " - ";
                miss += GetTextoRespuesta(encuesta, idPregunta, _aiRespuestasDadas[i]) + "\r";
            }

            miss += "\r¿Es seguro que quiere guardar estas respuestas?";

            if (Mensajes.ShowQuestion(miss) == DialogResult.Yes)
            {
                for (int i = 0; i < _lPreguntas.Count; i++)
                {
                    idPregunta = GetIdPregunta(encuesta, _lPreguntas[i]);

                    //---- GSG (24/10/2019)
                    //guardarRespuestasDadas(_sCliente, encuesta, idPregunta, _aiRespuestasDadas[i]);
                    guardarRespuestasDadas(_sCliente, encuesta, idPregunta, _aiRespuestasDadas[i], Clases.Configuracion.iIdDelegado, Clases.Configuracion.sIdRed);
                }

                _bGuardada = true; //---- GSG (24/10/2019)
            }
            else
            {
                _bGuardada = false; //---- GSG (24/10/2019)
                CerrarEncuesta();
            }
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
            CerrarEncuesta();
        }



        private void CerrarEncuesta()
        {
            bool bCierra = false;
            int encuesta = -1;

            // this.DialogResult = DialogResult.Cancel;  //---- GSG (24/10/2019)

            if (txtbIdEncuesta.Text != "")
            {
                encuesta = int.Parse(txtbIdEncuesta.Text);

                if (EsEncuestaObligatoria(encuesta))
                {
                    if (!estaContestada())
                        Mensajes.ShowExclamation("La encuesta es de obligado cumplimiento.");
                    else
                        bCierra = true;
                }
                else
                    bCierra = true;

                if (bCierra)
                {
                    //---- GSG (24/10/2019)
                    //guardarEstadoContestada(_sCliente, encuesta, true); // Sólo actualizará el estado de la línea SRVYClienteEncuesta.bContestada cuando se trate de una encuesta activa para el cliente en conreto
                    //this.DialogResult = DialogResult.OK;
                    //this.Close();

                    if (!_bGuardada)
                    {
                        string miss = "Va salir sin guardar los datos. ¿Seguro que quiere terminar la encuesta?";
                        if (Mensajes.ShowQuestion(miss) == DialogResult.Yes)
                            this.Close();

                    }
                    else
                    {
                        guardarEstadoContestada(_sCliente, encuesta, true); // Sólo actualizará el estado de la línea SRVYClienteEncuesta.bContestada cuando se trate de una encuesta activa para el cliente en conreto
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    
                }
            }
            else
                this.Close();
            

            #endregion
        }

        #endregion
    }
}
