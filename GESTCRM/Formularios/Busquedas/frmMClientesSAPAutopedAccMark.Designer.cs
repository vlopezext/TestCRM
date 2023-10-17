namespace GESTCRM.Formularios.Busquedas
{
    partial class frmMClientesSAPAutopedAccMark
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMClientesSAPAutopedAccMark));
            System.Configuration.AppSettingsReader configurationAppSettings = new System.Configuration.AppSettingsReader();
            this.dsBuscar1 = new GESTCRM.Formularios.Busquedas.dsBuscar();
            this.sqlConn = new System.Data.SqlClient.SqlConnection();
            this.sqlSelectCommandClientesSAPConAutopedsSinAccMark = new System.Data.SqlClient.SqlCommand();
            this.sqldaListaBuscaClientesSAPConAutopedsSinAccMark = new System.Data.SqlClient.SqlDataAdapter();
            this.pnBusqueda = new System.Windows.Forms.Panel();
            this.lblNumReg = new System.Windows.Forms.Label();
            this.labelGradient2 = new GESTCRM.Controles.LabelGradient();
            this.dgClientes = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.btCancelar = new System.Windows.Forms.Button();
            this.btAceptar = new System.Windows.Forms.Button();
            this.pnlClientes = new System.Windows.Forms.Panel();
            this.btBuscar = new System.Windows.Forms.Button();
            this.txtsIdCliente = new System.Windows.Forms.TextBox();
            this.txbNombre = new System.Windows.Forms.TextBox();
            this.lblsIdCliente = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dsBuscar1)).BeginInit();
            this.pnBusqueda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgClientes)).BeginInit();
            this.pnlClientes.SuspendLayout();
            this.SuspendLayout();
            // 
            // dsBuscar1
            // 
            this.dsBuscar1.DataSetName = "dsBuscar";
            this.dsBuscar1.Locale = new System.Globalization.CultureInfo("es-ES");
            this.dsBuscar1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sqlConn
            // 
            this.sqlConn.FireInfoMessageEventOnUserErrors = false;
            // 
            // sqlSelectCommandClientesSAPConAutopedsSinAccMark
            // 
            this.sqlSelectCommandClientesSAPConAutopedsSinAccMark.CommandText = "[ListaBuscaClientesSAPConAutopedsSinAccMark]";
            this.sqlSelectCommandClientesSAPConAutopedsSinAccMark.CommandTimeout = 60;
            this.sqlSelectCommandClientesSAPConAutopedsSinAccMark.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommandClientesSAPConAutopedsSinAccMark.Connection = this.sqlConn;
            this.sqlSelectCommandClientesSAPConAutopedsSinAccMark.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@iIdDelegado", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@sIdCliente", System.Data.SqlDbType.VarChar, 20),
            new System.Data.SqlClient.SqlParameter("@sNombre", System.Data.SqlDbType.VarChar, 50)});
            // 
            // sqldaListaBuscaClientesSAPConAutopedsSinAccMark
            // 
            this.sqldaListaBuscaClientesSAPConAutopedsSinAccMark.SelectCommand = this.sqlSelectCommandClientesSAPConAutopedsSinAccMark;
            this.sqldaListaBuscaClientesSAPConAutopedsSinAccMark.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaBuscaClientesSAPConAutopedsSinAccMark", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("iIdDelegado", "iIdDelegado"),
                        new System.Data.Common.DataColumnMapping("NombreDel", "NombreDel"),
                        new System.Data.Common.DataColumnMapping("iIdCliente", "iIdCliente"),
                        new System.Data.Common.DataColumnMapping("sIdCliente", "sIdCliente"),
                        new System.Data.Common.DataColumnMapping("sTipoCliente", "sTipoCliente"),
                        new System.Data.Common.DataColumnMapping("tTipoCliente", "tTipoCliente"),
                        new System.Data.Common.DataColumnMapping("sIdTipoClasificacion", "sIdTipoClasificacion"),
                        new System.Data.Common.DataColumnMapping("tTipoClasificacion", "tTipoClasificacion"),
                        new System.Data.Common.DataColumnMapping("sNombre", "sNombre"),
                        new System.Data.Common.DataColumnMapping("sApellidos1", "sApellidos1"),
                        new System.Data.Common.DataColumnMapping("sApellidos2", "sApellidos2"),
                        new System.Data.Common.DataColumnMapping("tNombre", "tNombre"),
                        new System.Data.Common.DataColumnMapping("bPotencial_SAP", "bPotencial_SAP"),
                        new System.Data.Common.DataColumnMapping("xPotencial_SAP", "xPotencial_SAP"),
                        new System.Data.Common.DataColumnMapping("tProxObj", "tProxObj"),
                        new System.Data.Common.DataColumnMapping("GrupoClientes", "GrupoClientes"),
                        new System.Data.Common.DataColumnMapping("iIdArea", "iIdArea"),
                        new System.Data.Common.DataColumnMapping("sNombreArea", "sNombreArea")})});
            // 
            // pnBusqueda
            // 
            this.pnBusqueda.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnBusqueda.Controls.Add(this.lblNumReg);
            this.pnBusqueda.Controls.Add(this.labelGradient2);
            this.pnBusqueda.Controls.Add(this.dgClientes);
            this.pnBusqueda.Location = new System.Drawing.Point(-2, 80);
            this.pnBusqueda.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnBusqueda.Name = "pnBusqueda";
            this.pnBusqueda.Size = new System.Drawing.Size(805, 565);
            this.pnBusqueda.TabIndex = 14;
            // 
            // lblNumReg
            // 
            this.lblNumReg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.lblNumReg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblNumReg.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumReg.ForeColor = System.Drawing.Color.Black;
            this.lblNumReg.Location = new System.Drawing.Point(711, 0);
            this.lblNumReg.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNumReg.Name = "lblNumReg";
            this.lblNumReg.Size = new System.Drawing.Size(90, 28);
            this.lblNumReg.TabIndex = 89;
            this.lblNumReg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelGradient2
            // 
            this.labelGradient2.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelGradient2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGradient2.ForeColor = System.Drawing.Color.White;
            this.labelGradient2.GradientColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.labelGradient2.GradientColorTwo = System.Drawing.Color.White;
            this.labelGradient2.Location = new System.Drawing.Point(0, 0);
            this.labelGradient2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelGradient2.Name = "labelGradient2";
            this.labelGradient2.Size = new System.Drawing.Size(801, 28);
            this.labelGradient2.TabIndex = 88;
            this.labelGradient2.Text = "Resultado de la Búsqueda";
            this.labelGradient2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgClientes
            // 
            this.dgClientes.BackgroundColor = System.Drawing.Color.White;
            this.dgClientes.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.dgClientes.CaptionVisible = false;
            this.dgClientes.DataMember = "ListaBuscaClientesSAPConAutopedsSinAccMark";
            this.dgClientes.DataSource = this.dsBuscar1;
            this.dgClientes.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgClientes.Location = new System.Drawing.Point(0, 28);
            this.dgClientes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgClientes.Name = "dgClientes";
            this.dgClientes.ReadOnly = true;
            this.dgClientes.RowHeaderWidth = 15;
            this.dgClientes.Size = new System.Drawing.Size(799, 532);
            this.dgClientes.TabIndex = 10;
            this.dgClientes.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.dataGridTableStyle1});
            this.dgClientes.CurrentCellChanged += new System.EventHandler(this.dgClientes_CurrentCellChanged);
            this.dgClientes.Click += new System.EventHandler(this.dgClientes_Click);
            this.dgClientes.Paint += new System.Windows.Forms.PaintEventHandler(this.dgClientes_Paint);
            this.dgClientes.DoubleClick += new System.EventHandler(this.dgClientes_DoubleClick);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.DataGrid = this.dgClientes;
            this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.dataGridTextBoxColumn1,
            this.dataGridTextBoxColumn2,
            this.dataGridTextBoxColumn3});
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle1.MappingName = "ListaBuscaClientesSAPConAutopedsSinAccMark";
            this.dataGridTableStyle1.RowHeaderWidth = 15;
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "Código";
            this.dataGridTextBoxColumn1.MappingName = "sIdCliente";
            this.dataGridTextBoxColumn1.Width = 110;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "Nombre";
            this.dataGridTextBoxColumn2.MappingName = "tNombre";
            this.dataGridTextBoxColumn2.Width = 480;
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.MappingName = "iIdCliente";
            this.dataGridTextBoxColumn3.Width = 0;
            // 
            // btCancelar
            // 
            this.btCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btCancelar.Location = new System.Drawing.Point(675, 654);
            this.btCancelar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(112, 35);
            this.btCancelar.TabIndex = 16;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // btAceptar
            // 
            this.btAceptar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btAceptar.Location = new System.Drawing.Point(557, 654);
            this.btAceptar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btAceptar.Name = "btAceptar";
            this.btAceptar.Size = new System.Drawing.Size(112, 35);
            this.btAceptar.TabIndex = 15;
            this.btAceptar.Text = "Aceptar";
            this.btAceptar.UseVisualStyleBackColor = true;
            this.btAceptar.Click += new System.EventHandler(this.btAceptar_Click);
            // 
            // pnlClientes
            // 
            this.pnlClientes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlClientes.Controls.Add(this.btBuscar);
            this.pnlClientes.Controls.Add(this.txtsIdCliente);
            this.pnlClientes.Controls.Add(this.txbNombre);
            this.pnlClientes.Controls.Add(this.lblsIdCliente);
            this.pnlClientes.Controls.Add(this.lblNombre);
            this.pnlClientes.Location = new System.Drawing.Point(2, 9);
            this.pnlClientes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlClientes.Name = "pnlClientes";
            this.pnlClientes.Size = new System.Drawing.Size(801, 60);
            this.pnlClientes.TabIndex = 17;
            // 
            // btBuscar
            // 
            this.btBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btBuscar.Location = new System.Drawing.Point(673, 11);
            this.btBuscar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btBuscar.Name = "btBuscar";
            this.btBuscar.Size = new System.Drawing.Size(112, 35);
            this.btBuscar.TabIndex = 12;
            this.btBuscar.Text = "Buscar";
            this.btBuscar.UseVisualStyleBackColor = true;
            this.btBuscar.Click += new System.EventHandler(this.btBuscar_Click);
            // 
            // txtsIdCliente
            // 
            this.txtsIdCliente.BackColor = System.Drawing.Color.White;
            this.txtsIdCliente.ForeColor = System.Drawing.Color.Black;
            this.txtsIdCliente.Location = new System.Drawing.Point(79, 14);
            this.txtsIdCliente.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtsIdCliente.MaxLength = 20;
            this.txtsIdCliente.Name = "txtsIdCliente";
            this.txtsIdCliente.Size = new System.Drawing.Size(166, 26);
            this.txtsIdCliente.TabIndex = 0;
            this.txtsIdCliente.TextChanged += new System.EventHandler(this.txtsIdCliente_TextChanged);
            // 
            // txbNombre
            // 
            this.txbNombre.BackColor = System.Drawing.Color.White;
            this.txbNombre.ForeColor = System.Drawing.Color.Black;
            this.txbNombre.Location = new System.Drawing.Point(331, 14);
            this.txbNombre.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txbNombre.MaxLength = 50;
            this.txbNombre.Name = "txbNombre";
            this.txbNombre.Size = new System.Drawing.Size(322, 26);
            this.txbNombre.TabIndex = 3;
            this.txbNombre.TextChanged += new System.EventHandler(this.txbNombre_TextChanged);
            // 
            // lblsIdCliente
            // 
            this.lblsIdCliente.AutoSize = true;
            this.lblsIdCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblsIdCliente.Location = new System.Drawing.Point(15, 17);
            this.lblsIdCliente.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblsIdCliente.Name = "lblsIdCliente";
            this.lblsIdCliente.Size = new System.Drawing.Size(63, 20);
            this.lblsIdCliente.TabIndex = 10;
            this.lblsIdCliente.Text = "Código:";
            this.lblsIdCliente.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblNombre.Location = new System.Drawing.Point(259, 18);
            this.lblNombre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(69, 20);
            this.lblNombre.TabIndex = 3;
            this.lblNombre.Text = "Nombre:";
            this.lblNombre.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // frmMClientesSAPAutopedAccMark
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(230)))), ((int)(((byte)(239)))));
            this.ClientSize = new System.Drawing.Size(811, 693);
            this.Controls.Add(this.pnlClientes);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.btAceptar);
            this.Controls.Add(this.pnBusqueda);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMClientesSAPAutopedAccMark";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Búsqueda de Clientes con autopedidos sin asociar a acciones de márketing";
            this.Load += new System.EventHandler(this.frmMClientesSAPAutopedAccMark_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsBuscar1)).EndInit();
            this.pnBusqueda.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgClientes)).EndInit();
            this.pnlClientes.ResumeLayout(false);
            this.pnlClientes.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private dsBuscar dsBuscar1;
        private System.Data.SqlClient.SqlConnection sqlConn;
        private System.Data.SqlClient.SqlCommand sqlSelectCommandClientesSAPConAutopedsSinAccMark;
        private System.Data.SqlClient.SqlDataAdapter sqldaListaBuscaClientesSAPConAutopedsSinAccMark;
        private System.Windows.Forms.Panel pnBusqueda;
        private System.Windows.Forms.Label lblNumReg;
        private Controles.LabelGradient labelGradient2;
        private System.Windows.Forms.DataGrid dgClientes;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.Button btAceptar;
        private System.Windows.Forms.Panel pnlClientes;
        private System.Windows.Forms.Button btBuscar;
        private System.Windows.Forms.TextBox txtsIdCliente;
        private System.Windows.Forms.TextBox txbNombre;
        private System.Windows.Forms.Label lblsIdCliente;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
    }
}