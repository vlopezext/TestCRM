namespace GESTCRM.Formularios
{
    partial class frmEncuesta
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Configuration.AppSettingsReader configurationAppSettings = new System.Configuration.AppSettingsReader();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEncuesta));
            this.sqlConn = new System.Data.SqlClient.SqlConnection();
            this.lblEncuesta = new System.Windows.Forms.Label();
            this.lblPregunta = new System.Windows.Forms.Label();
            this.cbRespuesta = new System.Windows.Forms.ComboBox();
            this.btAnterior = new System.Windows.Forms.Button();
            this.btSiguiente = new System.Windows.Forms.Button();
            this.pnEncuesta = new System.Windows.Forms.Panel();
            this.lblRespuestaDada = new System.Windows.Forms.Label();
            this.lblResultado = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblContador = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbEncuesta = new System.Windows.Forms.ComboBox();
            this.sqldaDatosEncuestasDisponibles = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCmdDatosEncuestasDisponibles = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdSetRespuestasDadas = new System.Data.SqlClient.SqlCommand();
            this.sqlCmdSetEncuestaContestada = new System.Data.SqlClient.SqlCommand();
            this.dsEnc = new GESTCRM.Formularios.DataSets.dsEncuestas();
            this.txtbIdEncuesta = new System.Windows.Forms.TextBox();
            this.txtbIdPregunta = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btGuardar = new System.Windows.Forms.Button();
            this.btAceptar = new System.Windows.Forms.Button();
            this.pnEncuesta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsEnc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // sqlConn
            // 
            this.sqlConn.ConnectionString = Utiles._connection.ConnectionString.ToString();   //---- GSG (06/03/2021)
            this.sqlConn.FireInfoMessageEventOnUserErrors = false;
            // 
            // lblEncuesta
            // 
            this.lblEncuesta.AutoSize = true;
            this.lblEncuesta.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEncuesta.Location = new System.Drawing.Point(13, 14);
            this.lblEncuesta.Name = "lblEncuesta";
            this.lblEncuesta.Size = new System.Drawing.Size(66, 24);
            this.lblEncuesta.TabIndex = 0;
            this.lblEncuesta.Text = "label1";
            // 
            // lblPregunta
            // 
            this.lblPregunta.AutoSize = true;
            this.lblPregunta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPregunta.ForeColor = System.Drawing.Color.Black;
            this.lblPregunta.Location = new System.Drawing.Point(38, 65);
            this.lblPregunta.Name = "lblPregunta";
            this.lblPregunta.Size = new System.Drawing.Size(51, 20);
            this.lblPregunta.TabIndex = 1;
            this.lblPregunta.Text = "label2";
            // 
            // cbRespuesta
            // 
            this.cbRespuesta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbRespuesta.FormattingEnabled = true;
            this.cbRespuesta.Location = new System.Drawing.Point(42, 106);
            this.cbRespuesta.Name = "cbRespuesta";
            this.cbRespuesta.Size = new System.Drawing.Size(637, 28);
            this.cbRespuesta.TabIndex = 2;
            // 
            // btAnterior
            // 
            this.btAnterior.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAnterior.Image = global::GESTCRM.Properties.Resources.left;
            this.btAnterior.Location = new System.Drawing.Point(235, 236);
            this.btAnterior.Name = "btAnterior";
            this.btAnterior.Size = new System.Drawing.Size(73, 43);
            this.btAnterior.TabIndex = 3;
            this.btAnterior.UseVisualStyleBackColor = true;
            this.btAnterior.Click += new System.EventHandler(this.btAnterior_Click);
            this.btAnterior.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btAnterior_MouseUp);
            // 
            // btSiguiente
            // 
            this.btSiguiente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSiguiente.Image = global::GESTCRM.Properties.Resources.right;
            this.btSiguiente.Location = new System.Drawing.Point(413, 236);
            this.btSiguiente.Name = "btSiguiente";
            this.btSiguiente.Size = new System.Drawing.Size(73, 43);
            this.btSiguiente.TabIndex = 4;
            this.btSiguiente.UseVisualStyleBackColor = true;
            this.btSiguiente.Click += new System.EventHandler(this.btSiguiente_Click);
            this.btSiguiente.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btSiguiente_MouseUp);
            // 
            // pnEncuesta
            // 
            this.pnEncuesta.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnEncuesta.Controls.Add(this.lblRespuestaDada);
            this.pnEncuesta.Controls.Add(this.lblResultado);
            this.pnEncuesta.Controls.Add(this.pictureBox2);
            this.pnEncuesta.Controls.Add(this.lblContador);
            this.pnEncuesta.Controls.Add(this.btAnterior);
            this.pnEncuesta.Controls.Add(this.cbRespuesta);
            this.pnEncuesta.Controls.Add(this.btSiguiente);
            this.pnEncuesta.Controls.Add(this.lblPregunta);
            this.pnEncuesta.Controls.Add(this.lblEncuesta);
            this.pnEncuesta.Location = new System.Drawing.Point(13, 83);
            this.pnEncuesta.Name = "pnEncuesta";
            this.pnEncuesta.Size = new System.Drawing.Size(723, 297);
            this.pnEncuesta.TabIndex = 5;
            // 
            // lblRespuestaDada
            // 
            this.lblRespuestaDada.AutoSize = true;
            this.lblRespuestaDada.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRespuestaDada.ForeColor = System.Drawing.Color.Black;
            this.lblRespuestaDada.Location = new System.Drawing.Point(272, 150);
            this.lblRespuestaDada.Name = "lblRespuestaDada";
            this.lblRespuestaDada.Size = new System.Drawing.Size(14, 20);
            this.lblRespuestaDada.TabIndex = 8;
            this.lblRespuestaDada.Text = " ";
            // 
            // lblResultado
            // 
            this.lblResultado.AutoSize = true;
            this.lblResultado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResultado.ForeColor = System.Drawing.Color.Black;
            this.lblResultado.Location = new System.Drawing.Point(38, 150);
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(234, 20);
            this.lblResultado.TabIndex = 7;
            this.lblResultado.Text = "Respuesta dada anteriormente:";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::GESTCRM.Properties.Resources.punto16x16blau;
            this.pictureBox2.Location = new System.Drawing.Point(20, 67);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(17, 17);
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // lblContador
            // 
            this.lblContador.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContador.ForeColor = System.Drawing.Color.Black;
            this.lblContador.Location = new System.Drawing.Point(314, 247);
            this.lblContador.Name = "lblContador";
            this.lblContador.Size = new System.Drawing.Size(93, 20);
            this.lblContador.TabIndex = 5;
            this.lblContador.Text = "0 / 0";
            this.lblContador.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(89, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 44);
            this.label1.TabIndex = 6;
            this.label1.Text = "Encuestas disponibles";
            // 
            // cbEncuesta
            // 
            this.cbEncuesta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbEncuesta.FormattingEnabled = true;
            this.cbEncuesta.Location = new System.Drawing.Point(184, 28);
            this.cbEncuesta.Name = "cbEncuesta";
            this.cbEncuesta.Size = new System.Drawing.Size(555, 28);
            this.cbEncuesta.TabIndex = 7;
            this.cbEncuesta.SelectedIndexChanged += new System.EventHandler(this.cbEncuesta_SelectedIndexChanged);
            // 
            // sqldaDatosEncuestasDisponibles
            // 
            this.sqldaDatosEncuestasDisponibles.SelectCommand = this.sqlCmdDatosEncuestasDisponibles;
            this.sqldaDatosEncuestasDisponibles.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "DatosEncuestasCliente", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("idEncuesta", "idEncuesta"),
                        new System.Data.Common.DataColumnMapping("sDescripcion", "sDescripcion"),
                        new System.Data.Common.DataColumnMapping("bObligatoria", "bObligatoria"),
                        new System.Data.Common.DataColumnMapping("idPregunta", "idPregunta"),
                        new System.Data.Common.DataColumnMapping("sPregunta", "sPregunta"),
                        new System.Data.Common.DataColumnMapping("idRespuesta", "idRespuesta"),
                        new System.Data.Common.DataColumnMapping("sRespuesta", "sRespuesta"),
                        new System.Data.Common.DataColumnMapping("bObligatoria1", "bObligatoria1"),
                        new System.Data.Common.DataColumnMapping("bContestada", "bContestada"),
                        new System.Data.Common.DataColumnMapping("iIdRespuesta", "iIdRespuesta")})});
            // 
            // sqlCmdDatosEncuestasDisponibles
            // 
            this.sqlCmdDatosEncuestasDisponibles.CommandText = "[GetEncuestaActivaCliente]";
            this.sqlCmdDatosEncuestasDisponibles.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdDatosEncuestasDisponibles.Connection = this.sqlConn;
            this.sqlCmdDatosEncuestasDisponibles.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@idDelegado", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sIdCliente", System.Data.SqlDbType.VarChar, 20)});
            // 
            // sqlCmdSetRespuestasDadas
            // 
            this.sqlCmdSetRespuestasDadas.CommandText = "[SetResultadoEncuesta]";
            this.sqlCmdSetRespuestasDadas.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdSetRespuestasDadas.Connection = this.sqlConn;
            this.sqlCmdSetRespuestasDadas.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@sIdCliente", System.Data.SqlDbType.VarChar, 20),
            new System.Data.SqlClient.SqlParameter("@idEncuesta", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@idPregunta", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@idRespuestaDada", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@iIdDelegado", System.Data.SqlDbType.Int, 4), //---- GSG (24/10/2019)
            new System.Data.SqlClient.SqlParameter("@sRed", System.Data.SqlDbType.VarChar, 4)});

      
            // 
            // sqlCmdSetEncuestaContestada
            // 
            this.sqlCmdSetEncuestaContestada.CommandText = "[SetEncuestaContestada]";
            this.sqlCmdSetEncuestaContestada.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdSetEncuestaContestada.Connection = this.sqlConn;
            this.sqlCmdSetEncuestaContestada.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@sIdCliente", System.Data.SqlDbType.VarChar, 20),
            new System.Data.SqlClient.SqlParameter("@idEncuesta", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@bContestada", System.Data.SqlDbType.Bit, 1)});
            // 
            // dsEnc
            // 
            this.dsEnc.DataSetName = "dsEncuestas";
            this.dsEnc.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // txtbIdEncuesta
            // 
            this.txtbIdEncuesta.Location = new System.Drawing.Point(530, 59);
            this.txtbIdEncuesta.Name = "txtbIdEncuesta";
            this.txtbIdEncuesta.Size = new System.Drawing.Size(100, 20);
            this.txtbIdEncuesta.TabIndex = 8;
            this.txtbIdEncuesta.Visible = false;
            // 
            // txtbIdPregunta
            // 
            this.txtbIdPregunta.Location = new System.Drawing.Point(639, 59);
            this.txtbIdPregunta.Name = "txtbIdPregunta";
            this.txtbIdPregunta.Size = new System.Drawing.Size(100, 20);
            this.txtbIdPregunta.TabIndex = 9;
            this.txtbIdPregunta.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::GESTCRM.Properties.Resources.Survey1;
            this.pictureBox1.Location = new System.Drawing.Point(12, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(65, 67);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // btGuardar
            // 
            this.btGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btGuardar.Image = global::GESTCRM.Properties.Resources.guardar;
            this.btGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btGuardar.Location = new System.Drawing.Point(530, 403);
            this.btGuardar.Name = "btGuardar";
            this.btGuardar.Size = new System.Drawing.Size(192, 36);
            this.btGuardar.TabIndex = 11;
            this.btGuardar.Text = "Guardar Respuestas";
            this.btGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btGuardar.UseVisualStyleBackColor = true;
            this.btGuardar.Click += new System.EventHandler(this.btGuardar_Click);
            // 
            // btAceptar
            // 
            this.btAceptar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAceptar.Image = global::GESTCRM.Properties.Resources.ok_032x032;
            this.btAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btAceptar.Location = new System.Drawing.Point(35, 403);
            this.btAceptar.Name = "btAceptar";
            this.btAceptar.Size = new System.Drawing.Size(110, 36);
            this.btAceptar.TabIndex = 12;
            this.btAceptar.Text = "&Terminar";
            this.btAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btAceptar.UseVisualStyleBackColor = true;
            this.btAceptar.Click += new System.EventHandler(this.btAceptar_Click);
            // 
            // frmEncuesta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 466);
            this.ControlBox = false;
            this.Controls.Add(this.btAceptar);
            this.Controls.Add(this.btGuardar);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtbIdPregunta);
            this.Controls.Add(this.txtbIdEncuesta);
            this.Controls.Add(this.cbEncuesta);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnEncuesta);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmEncuesta";
            this.Text = "Encuestas";
            this.pnEncuesta.ResumeLayout(false);
            this.pnEncuesta.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsEnc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblEncuesta;
        private System.Windows.Forms.Label lblPregunta;
        private System.Windows.Forms.ComboBox cbRespuesta;
        private System.Windows.Forms.Button btAnterior;
        private System.Windows.Forms.Button btSiguiente;
        private System.Windows.Forms.Panel pnEncuesta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbEncuesta;
        private DataSets.dsEncuestas dsEnc;
        private System.Windows.Forms.Label lblContador;
        private System.Windows.Forms.TextBox txtbIdEncuesta;
        private System.Windows.Forms.TextBox txtbIdPregunta;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btGuardar;
        private System.Windows.Forms.Label lblRespuestaDada;
        private System.Windows.Forms.Label lblResultado;
        private System.Windows.Forms.Button btAceptar;
    }
}