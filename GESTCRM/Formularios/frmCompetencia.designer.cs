namespace GESTCRM.Formularios
{
    partial class txtbLeyenda
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.sqlCmdDatosComp = new System.Data.SqlClient.SqlCommand();
            this.sqlConn = new System.Data.SqlClient.SqlConnection();
            this.dGVDatos = new System.Windows.Forms.DataGridView();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.dGVTotales = new System.Windows.Forms.DataGridView();
            this.txtbLeyenda1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dGVDatos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGVTotales)).BeginInit();
            this.SuspendLayout();
            // 
            // sqlCmdDatosComp
            // 
            this.sqlCmdDatosComp.CommandText = "[GetComparaComp]";
            this.sqlCmdDatosComp.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCmdDatosComp.Connection = this.sqlConn;
            this.sqlCmdDatosComp.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@sIdPedido", System.Data.SqlDbType.VarChar, 12)});
            // 
            // sqlConn
            // 
            this.sqlConn.ConnectionString = Utiles._connection.ConnectionString.ToString();   //---- GSG (06/03/2021)
            this.sqlConn.FireInfoMessageEventOnUserErrors = false;
            // 
            // dGVDatos
            // 
            this.dGVDatos.AllowUserToAddRows = false;
            this.dGVDatos.AllowUserToDeleteRows = false;
            this.dGVDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVDatos.Location = new System.Drawing.Point(23, 73);
            this.dGVDatos.Name = "dGVDatos";
            this.dGVDatos.ReadOnly = true;
            this.dGVDatos.RowHeadersWidth = 20;
            this.dGVDatos.Size = new System.Drawing.Size(1157, 407);
            this.dGVDatos.TabIndex = 0;
            // 
            // btnAceptar
            // 
            this.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Image = global::GESTCRM.Properties.Resources.ok_032x032;
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAceptar.Location = new System.Drawing.Point(546, 507);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(2);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(110, 40);
            this.btnAceptar.TabIndex = 10;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // dGVTotales
            // 
            this.dGVTotales.AllowUserToAddRows = false;
            this.dGVTotales.AllowUserToDeleteRows = false;
            this.dGVTotales.AllowUserToResizeColumns = false;
            this.dGVTotales.AllowUserToResizeRows = false;
            this.dGVTotales.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dGVTotales.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dGVTotales.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGVTotales.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dGVTotales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = "0";
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dGVTotales.DefaultCellStyle = dataGridViewCellStyle2;
            this.dGVTotales.Location = new System.Drawing.Point(330, 12);
            this.dGVTotales.MultiSelect = false;
            this.dGVTotales.Name = "dGVTotales";
            this.dGVTotales.ReadOnly = true;
            this.dGVTotales.RowHeadersVisible = false;
            this.dGVTotales.RowHeadersWidth = 20;
            this.dGVTotales.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.dGVTotales.Size = new System.Drawing.Size(850, 61);
            this.dGVTotales.TabIndex = 11;
            // 
            // txtbLeyenda1
            // 
            this.txtbLeyenda1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtbLeyenda1.Location = new System.Drawing.Point(997, 496);
            this.txtbLeyenda1.Name = "txtbLeyenda1";
            this.txtbLeyenda1.ReadOnly = true;
            this.txtbLeyenda1.Size = new System.Drawing.Size(35, 20);
            this.txtbLeyenda1.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1038, 499);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "No existe presentación";
            // 
            // txtbLeyenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1204, 564);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtbLeyenda1);
            this.Controls.Add(this.dGVTotales);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.dGVDatos);
            this.Name = "txtbLeyenda";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Comparativa del pedido con la competencia";
            this.Load += new System.EventHandler(this.frmCompetencia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dGVDatos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGVTotales)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dGVDatos;
        private System.Data.SqlClient.SqlConnection sqlConn;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.DataGridView dGVTotales;
        private System.Windows.Forms.TextBox txtbLeyenda1;
        private System.Windows.Forms.Label label1;

        
    }
}