namespace GESTCRM.Formularios
{
    partial class frmMatsConVale
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMatsConVale));
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.dGVMatsConVale = new System.Windows.Forms.DataGridView();
            this.sIdMaterial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sCodNacional = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sMaterial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bConVale = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.sSerie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sCodVale = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sIdPedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsMateriales1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsMateriales1 = new GESTCRM.Formularios.dsMateriales();
            ((System.ComponentModel.ISupportInitialize)(this.dGVMatsConVale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsMateriales1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsMateriales1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = global::GESTCRM.Properties.Resources.cancel_032x032;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(439, 352);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(108, 37);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.TabStop = false;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.Image = ((System.Drawing.Image)(resources.GetObject("btnGrabar.Image")));
            this.btnGrabar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGrabar.Location = new System.Drawing.Point(248, 352);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(108, 37);
            this.btnGrabar.TabIndex = 8;
            this.btnGrabar.TabStop = false;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // dGVMatsConVale
            // 
            this.dGVMatsConVale.AllowUserToAddRows = false;
            this.dGVMatsConVale.AllowUserToDeleteRows = false;
            this.dGVMatsConVale.AutoGenerateColumns = false;
            this.dGVMatsConVale.CausesValidation = false;
            this.dGVMatsConVale.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVMatsConVale.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sIdMaterial,
            this.sCodNacional,
            this.sMaterial,
            this.bConVale,
            this.sSerie,
            this.sCodVale,
            this.sIdPedido});
            this.dGVMatsConVale.DataMember = "ListaMatsConVale";
            this.dGVMatsConVale.DataSource = this.dsMateriales1BindingSource;
            this.dGVMatsConVale.Location = new System.Drawing.Point(12, 21);
            this.dGVMatsConVale.Name = "dGVMatsConVale";
            this.dGVMatsConVale.RowHeadersWidth = 25;
            this.dGVMatsConVale.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dGVMatsConVale.Size = new System.Drawing.Size(766, 308);
            this.dGVMatsConVale.TabIndex = 10;
            this.dGVMatsConVale.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dGVMatsConVale_KeyDown);
            this.dGVMatsConVale.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dGVMatsConVale_MouseClick);
            // 
            // sIdMaterial
            // 
            this.sIdMaterial.DataPropertyName = "sIdMaterial";
            this.sIdMaterial.HeaderText = "Cod. SAP";
            this.sIdMaterial.Name = "sIdMaterial";
            this.sIdMaterial.ReadOnly = true;
            this.sIdMaterial.Width = 80;
            // 
            // sCodNacional
            // 
            this.sCodNacional.DataPropertyName = "sCodNacional";
            this.sCodNacional.HeaderText = "Cod. Nacional";
            this.sCodNacional.Name = "sCodNacional";
            this.sCodNacional.ReadOnly = true;
            // 
            // sMaterial
            // 
            this.sMaterial.DataPropertyName = "sMaterial";
            this.sMaterial.HeaderText = "Material";
            this.sMaterial.Name = "sMaterial";
            this.sMaterial.ReadOnly = true;
            this.sMaterial.Width = 300;
            // 
            // bConVale
            // 
            this.bConVale.DataPropertyName = "bConVale";
            this.bConVale.HeaderText = "bConVale";
            this.bConVale.Name = "bConVale";
            this.bConVale.ReadOnly = true;
            this.bConVale.Visible = false;
            // 
            // sSerie
            // 
            this.sSerie.DataPropertyName = "sSerie";
            this.sSerie.HeaderText = "Serie";
            this.sSerie.MaxInputLength = 7;
            this.sSerie.Name = "sSerie";
            this.sSerie.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.sSerie.Width = 90;
            // 
            // sCodVale
            // 
            this.sCodVale.DataPropertyName = "sCodVale";
            this.sCodVale.HeaderText = "Código Vale";
            this.sCodVale.MaxInputLength = 15;
            this.sCodVale.Name = "sCodVale";
            this.sCodVale.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.sCodVale.Width = 140;
            // 
            // sIdPedido
            // 
            this.sIdPedido.DataPropertyName = "sIdPedido";
            this.sIdPedido.HeaderText = "sIdPedido";
            this.sIdPedido.Name = "sIdPedido";
            this.sIdPedido.ReadOnly = true;
            this.sIdPedido.Visible = false;
            // 
            // dsMateriales1BindingSource
            // 
            this.dsMateriales1BindingSource.DataSource = this.dsMateriales1;
            this.dsMateriales1BindingSource.Position = 0;
            // 
            // dsMateriales1
            // 
            this.dsMateriales1.DataSetName = "dsMateriales";
            this.dsMateriales1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // frmMatsConVale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 411);
            this.Controls.Add(this.dGVMatsConVale);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.Name = "frmMatsConVale";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Materiales con Vale";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmMatsConVale_Closing);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMatsConVale_FormClosing);
            this.Load += new System.EventHandler(this.frmMatsConVale_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dGVMatsConVale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsMateriales1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsMateriales1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.DataGridView dGVMatsConVale;
        private dsMateriales dsMateriales1;
        private System.Windows.Forms.BindingSource dsMateriales1BindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn sIdMaterial;
        private System.Windows.Forms.DataGridViewTextBoxColumn sCodNacional;
        private System.Windows.Forms.DataGridViewTextBoxColumn sMaterial;
        private System.Windows.Forms.DataGridViewCheckBoxColumn bConVale;
        private System.Windows.Forms.DataGridViewTextBoxColumn sSerie;
        private System.Windows.Forms.DataGridViewTextBoxColumn sCodVale;
        private System.Windows.Forms.DataGridViewTextBoxColumn sIdPedido;
    }
}