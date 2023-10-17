using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace GESTCRM.Formularios.Busquedas
{
    /// <summary>
    /// Descripción breve de frmMMaterialesArrastres.
    /// </summary>
    public class frmMMaterialesArrastres : System.Windows.Forms.Form
    {
        #region controles

        private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
        private System.Data.SqlClient.SqlDataAdapter sqlDaListaMaterialesA;
        private System.Data.SqlClient.SqlDataAdapter sqlDaListaMaterialesB;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.Button btAceptar;
        private System.Windows.Forms.Panel pnBusqueda;
        private System.Windows.Forms.Label lblNumRegA;
        private GESTCRM.Controles.LabelGradient labelGradient2;
        private System.Data.SqlClient.SqlConnection sqlConn;
        private IContainer components;
        private DataGridView dataGridView1;
        private DataGridView dataGridView2;
        private Label lblCampanya;
        private Label label1;
        private Panel panel1;
        private Label lblNumRegB;
        private NumericUpDown numericUpDownA;
        private NumericUpDown numericUpDownB;
        private dsMateriales dsMateriales1;
        private SqlCommand sqlCommand1;
        private Button btnClear;
        private SqlDataAdapter sqlDaGetIdArrastre;
        private SqlCommand sqlCommand2;
        private DataGridViewCheckBoxColumn ColSelected;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn ColCantidad;
        private DataGridViewTextBoxColumn ColDescuento;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private DataGridViewTextBoxColumn ColUnidMinimas;
        private DataGridViewTextBoxColumn ColidPaqueteB;
        private DataGridViewCheckBoxColumn selected;
        private DataGridViewTextBoxColumn sObligatorio;
        private DataGridViewTextBoxColumn sCodNacional;
        private DataGridViewTextBoxColumn sMaterial;
        private DataGridViewTextBoxColumn sIdMaterial;
        private DataGridViewTextBoxColumn fPrecio;
        private DataGridViewTextBoxColumn iCantidad;
        private DataGridViewTextBoxColumn fDescuento;
        private DataGridViewTextBoxColumn fDescuentoMaximo;
        private DataGridViewTextBoxColumn fCoste;
        private DataGridViewTextBoxColumn UnidMinimas;
        private DataGridViewTextBoxColumn ColidPaqueteA;
        private DataGridViewTextBoxColumn ColidCampanyaArrastrada;
        private GESTCRM.Controles.LabelGradient labelGradient1;

        #endregion

        public frmMMaterialesArrastres(DataRow row)
        {
            InitializeComponent();

            //---- GSG (06/03/2021)
            Utiles.GetConfigConnection();
            this.sqlConn.ConnectionString = Utiles._connection.ConnectionString.ToString();

            dataGridView1.RowsDefaultCellStyle.SelectionBackColor = Utiles.ColorSelecionFilaDataGrid;
            dataGridView2.RowsDefaultCellStyle.SelectionBackColor = Utiles.ColorSelecionFilaDataGrid;

            idCampanyaA = row["idCampanya"].ToString();
            NombreCampanyaA = row["NombreCampanya"].ToString();

            dtMaterialesA = new dsMateriales.ListaMaterialesArrastreDataTable();
            dtMaterialesB = new dsMateriales.ListaMaterialesArrastreDataTable();
        }

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Método necesario para admitir el Diseñador, no se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Configuration.AppSettingsReader configurationAppSettings = new System.Configuration.AppSettingsReader();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMMaterialesArrastres));
            this.sqlDaListaMaterialesA = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlConn = new System.Data.SqlClient.SqlConnection();
            this.btCancelar = new System.Windows.Forms.Button();
            this.btAceptar = new System.Windows.Forms.Button();
            this.pnBusqueda = new System.Windows.Forms.Panel();
            this.numericUpDownA = new System.Windows.Forms.NumericUpDown();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.selected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.sObligatorio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sCodNacional = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sMaterial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sIdMaterial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fDescuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fDescuentoMaximo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fCoste = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnidMinimas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColidPaqueteA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColidCampanyaArrastrada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsMateriales1 = new GESTCRM.Formularios.dsMateriales();
            this.lblNumRegA = new System.Windows.Forms.Label();
            this.labelGradient2 = new GESTCRM.Controles.LabelGradient();
            this.lblCampanya = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.numericUpDownB = new System.Windows.Forms.NumericUpDown();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.ColSelected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDescuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColUnidMinimas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColidPaqueteB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblNumRegB = new System.Windows.Forms.Label();
            this.labelGradient1 = new GESTCRM.Controles.LabelGradient();
            this.sqlDaListaMaterialesB = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCommand1 = new System.Data.SqlClient.SqlCommand();
            this.btnClear = new System.Windows.Forms.Button();
            this.sqlDaGetIdArrastre = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCommand2 = new System.Data.SqlClient.SqlCommand();
            this.pnBusqueda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsMateriales1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();

            // 
            // sqlConn
            // 
            //this.sqlConn.ConnectionString = ((string)(configurationAppSettings.GetValue("sConn", typeof(string))));//---- GSG (10/09/2014)
            this.sqlConn = Utiles._connection;
            this.sqlConn.FireInfoMessageEventOnUserErrors = false;


            // 
            // sqlDaListaMaterialesA
            // 
            this.sqlDaListaMaterialesA.SelectCommand = this.sqlSelectCommand1;
            this.sqlDaListaMaterialesA.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaMaterialesDesCampA", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("sIdMaterial", "sIdMaterial"),
                        new System.Data.Common.DataColumnMapping("sMaterial", "sMaterial"),
                        new System.Data.Common.DataColumnMapping("sCodNacional", "sCodNacional"),
                        new System.Data.Common.DataColumnMapping("fPrecio", "fPrecio"),
                        new System.Data.Common.DataColumnMapping("selected", "selected"),
                        new System.Data.Common.DataColumnMapping("iCantidad", "iCantidad"),
                        new System.Data.Common.DataColumnMapping("fDescuento", "fDescuento"),
                        new System.Data.Common.DataColumnMapping("fDescuentoMaximo", "fDescuentoMaximo"),
                        new System.Data.Common.DataColumnMapping("fCoste", "fCoste"),
                        new System.Data.Common.DataColumnMapping("UnidMinimas", "UnidMinimas"),
                        new System.Data.Common.DataColumnMapping("sObligatorio", "sObligatorio"),
                        new System.Data.Common.DataColumnMapping("idPaquete", "idPaquete"),
                        new System.Data.Common.DataColumnMapping("idCampanyaArrastrada", "idCampanyaArrastrada")})});
            // 
            // sqlSelectCommand1
            // 
            this.sqlSelectCommand1.CommandText = "dbo.ListaMaterialesDesCampA";
            this.sqlSelectCommand1.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectCommand1.Connection = this.sqlConn;
            this.sqlSelectCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@sidCampanyaA", System.Data.SqlDbType.VarChar, 10, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, "4")});
            
            // 
            // btCancelar
            // 
            this.btCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCancelar.Image = global::GESTCRM.Properties.Resources.cancel_032x032;
            this.btCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btCancelar.Location = new System.Drawing.Point(683, 493);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(100, 36);
            this.btCancelar.TabIndex = 3;
            this.btCancelar.Text = "&Cancelar";
            this.btCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // btAceptar
            // 
            this.btAceptar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btAceptar.Enabled = false;
            this.btAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAceptar.Image = global::GESTCRM.Properties.Resources.ok_032x032;
            this.btAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btAceptar.Location = new System.Drawing.Point(519, 493);
            this.btAceptar.Name = "btAceptar";
            this.btAceptar.Size = new System.Drawing.Size(100, 36);
            this.btAceptar.TabIndex = 2;
            this.btAceptar.Text = "&Aceptar ";
            this.btAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btAceptar.UseVisualStyleBackColor = true;
            this.btAceptar.Click += new System.EventHandler(this.btAceptar_Click);
            // 
            // pnBusqueda
            // 
            this.pnBusqueda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnBusqueda.Controls.Add(this.numericUpDownA);
            this.pnBusqueda.Controls.Add(this.dataGridView1);
            this.pnBusqueda.Controls.Add(this.lblNumRegA);
            this.pnBusqueda.Controls.Add(this.labelGradient2);
            this.pnBusqueda.Location = new System.Drawing.Point(12, 35);
            this.pnBusqueda.Name = "pnBusqueda";
            this.pnBusqueda.Size = new System.Drawing.Size(770, 230);
            this.pnBusqueda.TabIndex = 1;
            // 
            // numericUpDownA
            // 
            this.numericUpDownA.BackColor = System.Drawing.Color.White;
            this.numericUpDownA.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericUpDownA.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownA.Location = new System.Drawing.Point(349, 97);
            this.numericUpDownA.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numericUpDownA.Name = "numericUpDownA";
            this.numericUpDownA.ReadOnly = true;
            this.numericUpDownA.Size = new System.Drawing.Size(69, 20);
            this.numericUpDownA.TabIndex = 91;
            this.numericUpDownA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownA.Visible = false;
            this.numericUpDownA.Leave += new System.EventHandler(this.numericUpDownA_Leave);
            this.numericUpDownA.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numericUpDownA_KeyDown);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.selected,
            this.sObligatorio,
            this.sCodNacional,
            this.sMaterial,
            this.sIdMaterial,
            this.fPrecio,
            this.iCantidad,
            this.fDescuento,
            this.fDescuentoMaximo,
            this.fCoste,
            this.UnidMinimas,
            this.ColidPaqueteA,
            this.ColidCampanyaArrastrada});
            this.dataGridView1.DataMember = "ListaMaterialesArrastre";
            this.dataGridView1.DataSource = this.dsMateriales1;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 18);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 25;
            this.dataGridView1.RowTemplate.Height = 21;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(768, 210);
            this.dataGridView1.TabIndex = 90;
            this.dataGridView1.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView1_CellBeginEdit);
            this.dataGridView1.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowEnter);
            this.dataGridView1.CellParsing += new System.Windows.Forms.DataGridViewCellParsingEventHandler(this.dataGridView1_CellParsing);
            this.dataGridView1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseUp);
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // selected
            // 
            this.selected.DataPropertyName = "selected";
            this.selected.FalseValue = "False";
            this.selected.HeaderText = "";
            this.selected.IndeterminateValue = "False";
            this.selected.Name = "selected";
            this.selected.ReadOnly = true;
            this.selected.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.selected.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.selected.TrueValue = "True";
            this.selected.Width = 20;
            // 
            // sObligatorio
            // 
            this.sObligatorio.DataPropertyName = "sObligatorio";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.sObligatorio.DefaultCellStyle = dataGridViewCellStyle3;
            this.sObligatorio.HeaderText = "Obligatorio";
            this.sObligatorio.Name = "sObligatorio";
            this.sObligatorio.ReadOnly = true;
            this.sObligatorio.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.sObligatorio.Width = 75;
            // 
            // sCodNacional
            // 
            this.sCodNacional.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.sCodNacional.DataPropertyName = "sCodNacional";
            this.sCodNacional.HeaderText = "Cod Nacional";
            this.sCodNacional.MinimumWidth = 70;
            this.sCodNacional.Name = "sCodNacional";
            this.sCodNacional.ReadOnly = true;
            this.sCodNacional.Width = 90;
            // 
            // sMaterial
            // 
            this.sMaterial.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.sMaterial.DataPropertyName = "sMaterial";
            this.sMaterial.HeaderText = "Descripción";
            this.sMaterial.Name = "sMaterial";
            this.sMaterial.ReadOnly = true;
            this.sMaterial.Width = 280;
            // 
            // sIdMaterial
            // 
            this.sIdMaterial.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.sIdMaterial.DataPropertyName = "sIdMaterial";
            this.sIdMaterial.HeaderText = "Material";
            this.sIdMaterial.Name = "sIdMaterial";
            this.sIdMaterial.ReadOnly = true;
            this.sIdMaterial.Width = 70;
            // 
            // fPrecio
            // 
            this.fPrecio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.fPrecio.DataPropertyName = "fPrecio";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.fPrecio.DefaultCellStyle = dataGridViewCellStyle4;
            this.fPrecio.HeaderText = "Precio";
            this.fPrecio.Name = "fPrecio";
            this.fPrecio.ReadOnly = true;
            this.fPrecio.Width = 70;
            // 
            // iCantidad
            // 
            this.iCantidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.iCantidad.DataPropertyName = "iCantidad";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iCantidad.DefaultCellStyle = dataGridViewCellStyle5;
            this.iCantidad.HeaderText = "Cantidad";
            this.iCantidad.Name = "iCantidad";
            this.iCantidad.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.iCantidad.Width = 70;
            // 
            // fDescuento
            // 
            this.fDescuento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.fDescuento.DataPropertyName = "fDescuento";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.NullValue = null;
            this.fDescuento.DefaultCellStyle = dataGridViewCellStyle6;
            this.fDescuento.HeaderText = "Descuento";
            this.fDescuento.Name = "fDescuento";
            this.fDescuento.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.fDescuento.Width = 75;
            // 
            // fDescuentoMaximo
            // 
            this.fDescuentoMaximo.DataPropertyName = "fDescuentoMaximo";
            this.fDescuentoMaximo.HeaderText = "Desc. Max.";
            this.fDescuentoMaximo.Name = "fDescuentoMaximo";
            this.fDescuentoMaximo.ReadOnly = true;
            this.fDescuentoMaximo.Visible = false;
            this.fDescuentoMaximo.Width = 70;
            // 
            // fCoste
            // 
            this.fCoste.DataPropertyName = "fCoste";
            this.fCoste.HeaderText = "fCoste";
            this.fCoste.Name = "fCoste";
            this.fCoste.Visible = false;
            // 
            // UnidMinimas
            // 
            this.UnidMinimas.DataPropertyName = "UnidMinimas";
            this.UnidMinimas.HeaderText = "UnidMinimas";
            this.UnidMinimas.Name = "UnidMinimas";
            this.UnidMinimas.ReadOnly = true;
            this.UnidMinimas.Visible = false;
            // 
            // ColidPaqueteA
            // 
            this.ColidPaqueteA.DataPropertyName = "idPaquete";
            this.ColidPaqueteA.HeaderText = "idPaquete";
            this.ColidPaqueteA.Name = "ColidPaqueteA";
            this.ColidPaqueteA.ReadOnly = true;
            this.ColidPaqueteA.Visible = false;
            // 
            // ColidCampanyaArrastrada
            // 
            this.ColidCampanyaArrastrada.DataPropertyName = "idCampanyaArrastrada";
            this.ColidCampanyaArrastrada.HeaderText = "idCampanyaArrastrada";
            this.ColidCampanyaArrastrada.Name = "ColidCampanyaArrastrada";
            this.ColidCampanyaArrastrada.ReadOnly = true;
            this.ColidCampanyaArrastrada.Visible = false;
            // 
            // dsMateriales1
            // 
            this.dsMateriales1.DataSetName = "dsMateriales";
            this.dsMateriales1.EnforceConstraints = false;
            this.dsMateriales1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lblNumRegA
            // 
            this.lblNumRegA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.lblNumRegA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblNumRegA.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumRegA.ForeColor = System.Drawing.Color.Black;
            this.lblNumRegA.Location = new System.Drawing.Point(706, 0);
            this.lblNumRegA.Name = "lblNumRegA";
            this.lblNumRegA.Size = new System.Drawing.Size(64, 18);
            this.lblNumRegA.TabIndex = 89;
            this.lblNumRegA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelGradient2
            // 
            this.labelGradient2.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelGradient2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGradient2.ForeColor = System.Drawing.Color.White;
            this.labelGradient2.GradientColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.labelGradient2.GradientColorTwo = System.Drawing.Color.White;
            this.labelGradient2.Location = new System.Drawing.Point(0, 0);
            this.labelGradient2.Name = "labelGradient2";
            this.labelGradient2.Size = new System.Drawing.Size(768, 18);
            this.labelGradient2.TabIndex = 88;
            this.labelGradient2.Text = "Campaña principal";
            this.labelGradient2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCampanya
            // 
            this.lblCampanya.AutoSize = true;
            this.lblCampanya.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCampanya.Location = new System.Drawing.Point(111, 5);
            this.lblCampanya.Name = "lblCampanya";
            this.lblCampanya.Size = new System.Drawing.Size(257, 25);
            this.lblCampanya.TabIndex = 6;
            this.lblCampanya.Text = "Campaña seleccionada";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 25);
            this.label1.TabIndex = 8;
            this.label1.Text = "Campaña:";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.numericUpDownB);
            this.panel1.Controls.Add(this.dataGridView2);
            this.panel1.Controls.Add(this.lblNumRegB);
            this.panel1.Controls.Add(this.labelGradient1);
            this.panel1.Location = new System.Drawing.Point(12, 273);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(770, 209);
            this.panel1.TabIndex = 9;
            // 
            // numericUpDownB
            // 
            this.numericUpDownB.BackColor = System.Drawing.Color.White;
            this.numericUpDownB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericUpDownB.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownB.Location = new System.Drawing.Point(350, 86);
            this.numericUpDownB.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numericUpDownB.Name = "numericUpDownB";
            this.numericUpDownB.ReadOnly = true;
            this.numericUpDownB.Size = new System.Drawing.Size(69, 20);
            this.numericUpDownB.TabIndex = 92;
            this.numericUpDownB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownB.Visible = false;
            this.numericUpDownB.Leave += new System.EventHandler(this.numericUpDownB_Leave);
            this.numericUpDownB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numericUpDownB_KeyDown);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AllowUserToResizeRows = false;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridView2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColSelected,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.ColCantidad,
            this.ColDescuento,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.ColUnidMinimas,
            this.ColidPaqueteB});
            this.dataGridView2.DataMember = "ListaMaterialesArrastre";
            this.dataGridView2.DataSource = this.dsMateriales1;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView2.DefaultCellStyle = dataGridViewCellStyle14;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(0, 18);
            this.dataGridView2.MultiSelect = false;
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.RowHeadersWidth = 25;
            this.dataGridView2.RowTemplate.Height = 21;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(768, 189);
            this.dataGridView2.TabIndex = 90;
            this.dataGridView2.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView2_CellBeginEdit);
            this.dataGridView2.CellParsing += new System.Windows.Forms.DataGridViewCellParsingEventHandler(this.dataGridView2_CellParsing);
            this.dataGridView2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dataGridView2_MouseUp);
            this.dataGridView2.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellEndEdit);
            this.dataGridView2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellClick);
            // 
            // ColSelected
            // 
            this.ColSelected.DataPropertyName = "selected";
            this.ColSelected.FalseValue = "False";
            this.ColSelected.HeaderText = "";
            this.ColSelected.IndeterminateValue = "False";
            this.ColSelected.Name = "ColSelected";
            this.ColSelected.ReadOnly = true;
            this.ColSelected.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColSelected.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColSelected.TrueValue = "True";
            this.ColSelected.Width = 20;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "sObligatorio";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridViewTextBoxColumn1.HeaderText = "Obligatorio";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn1.Width = 75;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "sCodNacional";
            this.dataGridViewTextBoxColumn2.HeaderText = "Cod Nacional";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 70;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 90;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "sMaterial";
            this.dataGridViewTextBoxColumn3.HeaderText = "Descripción";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 280;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "sIdMaterial";
            this.dataGridViewTextBoxColumn4.HeaderText = "Material";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 70;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "fPrecio";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle11;
            this.dataGridViewTextBoxColumn5.HeaderText = "Precio";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 70;
            // 
            // ColCantidad
            // 
            this.ColCantidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColCantidad.DataPropertyName = "iCantidad";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColCantidad.DefaultCellStyle = dataGridViewCellStyle12;
            this.ColCantidad.HeaderText = "Cantidad";
            this.ColCantidad.Name = "ColCantidad";
            this.ColCantidad.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColCantidad.Width = 70;
            // 
            // ColDescuento
            // 
            this.ColDescuento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColDescuento.DataPropertyName = "fDescuento";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.NullValue = null;
            this.ColDescuento.DefaultCellStyle = dataGridViewCellStyle13;
            this.ColDescuento.HeaderText = "Descuento";
            this.ColDescuento.Name = "ColDescuento";
            this.ColDescuento.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColDescuento.Width = 75;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "fDescuentoMaximo";
            this.dataGridViewTextBoxColumn8.HeaderText = "Desc. Max.";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Visible = false;
            this.dataGridViewTextBoxColumn8.Width = 70;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "fCoste";
            this.dataGridViewTextBoxColumn9.HeaderText = "fCoste";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Visible = false;
            // 
            // ColUnidMinimas
            // 
            this.ColUnidMinimas.DataPropertyName = "UnidMinimas";
            this.ColUnidMinimas.HeaderText = "UnidMinimas";
            this.ColUnidMinimas.Name = "ColUnidMinimas";
            this.ColUnidMinimas.ReadOnly = true;
            this.ColUnidMinimas.Visible = false;
            // 
            // ColidPaqueteB
            // 
            this.ColidPaqueteB.DataPropertyName = "idPaquete";
            this.ColidPaqueteB.HeaderText = "idPaquete";
            this.ColidPaqueteB.Name = "ColidPaqueteB";
            this.ColidPaqueteB.ReadOnly = true;
            this.ColidPaqueteB.Visible = false;
            // 
            // lblNumRegB
            // 
            this.lblNumRegB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.lblNumRegB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblNumRegB.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumRegB.ForeColor = System.Drawing.Color.Black;
            this.lblNumRegB.Location = new System.Drawing.Point(706, 0);
            this.lblNumRegB.Name = "lblNumRegB";
            this.lblNumRegB.Size = new System.Drawing.Size(64, 18);
            this.lblNumRegB.TabIndex = 89;
            this.lblNumRegB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelGradient1
            // 
            this.labelGradient1.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelGradient1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGradient1.ForeColor = System.Drawing.Color.White;
            this.labelGradient1.GradientColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(84)))), ((int)(((byte)(132)))));
            this.labelGradient1.GradientColorTwo = System.Drawing.Color.White;
            this.labelGradient1.Location = new System.Drawing.Point(0, 0);
            this.labelGradient1.Name = "labelGradient1";
            this.labelGradient1.Size = new System.Drawing.Size(768, 18);
            this.labelGradient1.TabIndex = 88;
            this.labelGradient1.Text = "Campaña secundaria";
            this.labelGradient1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sqlDaListaMaterialesB
            // 
            this.sqlDaListaMaterialesB.SelectCommand = this.sqlCommand1;
            this.sqlDaListaMaterialesB.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ListaMaterialesDesCampB", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("sIdMaterial", "sIdMaterial"),
                        new System.Data.Common.DataColumnMapping("sMaterial", "sMaterial"),
                        new System.Data.Common.DataColumnMapping("sCodNacional", "sCodNacional"),
                        new System.Data.Common.DataColumnMapping("fPrecio", "fPrecio"),
                        new System.Data.Common.DataColumnMapping("selected", "selected"),
                        new System.Data.Common.DataColumnMapping("iCantidad", "iCantidad"),
                        new System.Data.Common.DataColumnMapping("fDescuento", "fDescuento"),
                        new System.Data.Common.DataColumnMapping("fDescuentoMaximo", "fDescuentoMaximo"),
                        new System.Data.Common.DataColumnMapping("fCoste", "fCoste"),
                        new System.Data.Common.DataColumnMapping("UnidMinimas", "UnidMinimas"),
                        new System.Data.Common.DataColumnMapping("sObligatorio", "sObligatorio"),
                        new System.Data.Common.DataColumnMapping("idPaquete", "idPaquete"),
                        new System.Data.Common.DataColumnMapping("idCampanyaArrastrada", "idCampanyaArrastrada")}),
            new System.Data.Common.DataTableMapping("Table1", "Table1", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("sIdMaterial", "sIdMaterial"),
                        new System.Data.Common.DataColumnMapping("sMaterial", "sMaterial"),
                        new System.Data.Common.DataColumnMapping("sCodNacional", "sCodNacional"),
                        new System.Data.Common.DataColumnMapping("fPrecio", "fPrecio"),
                        new System.Data.Common.DataColumnMapping("selected", "selected"),
                        new System.Data.Common.DataColumnMapping("iCantidad", "iCantidad"),
                        new System.Data.Common.DataColumnMapping("fDescuento", "fDescuento"),
                        new System.Data.Common.DataColumnMapping("fDescuentoMaximo", "fDescuentoMaximo"),
                        new System.Data.Common.DataColumnMapping("fCoste", "fCoste"),
                        new System.Data.Common.DataColumnMapping("UnidMinimas", "UnidMinimas"),
                        new System.Data.Common.DataColumnMapping("sObligatorio", "sObligatorio"),
                        new System.Data.Common.DataColumnMapping("idPaquete", "idPaquete"),
                        new System.Data.Common.DataColumnMapping("idCampanyaArrastrada", "idCampanyaArrastrada")})});
            // 
            // sqlCommand1
            // 
            this.sqlCommand1.CommandText = "dbo.ListaMaterialesDesCampB";
            this.sqlCommand1.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCommand1.Connection = this.sqlConn;
            this.sqlCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@sidCampanyaB", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@idPaqueteA", System.Data.SqlDbType.Int, 4)});
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Image = global::GESTCRM.Properties.Resources.reload_032x032;
            this.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClear.Location = new System.Drawing.Point(11, 493);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 36);
            this.btnClear.TabIndex = 10;
            this.btnClear.Text = "&Inicializar";
            this.btnClear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // sqlDaGetIdArrastre
            // 
            this.sqlDaGetIdArrastre.SelectCommand = this.sqlCommand2;
            this.sqlDaGetIdArrastre.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "GetIdArrastre", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("idArrastre", "idArrastre")})});
            // 
            // sqlCommand2
            // 
            this.sqlCommand2.CommandText = "dbo.GetIdArrastre";
            this.sqlCommand2.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlCommand2.Connection = this.sqlConn;
            this.sqlCommand2.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@idCampanyaA", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@idPaqueteA", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@idCampanyaB", System.Data.SqlDbType.VarChar, 10),
            new System.Data.SqlClient.SqlParameter("@idPaqueteB", System.Data.SqlDbType.Int, 4)});
            // 
            // frmMMaterialesArrastres
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(230)))), ((int)(((byte)(239)))));
            this.ClientSize = new System.Drawing.Size(794, 538);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblCampanya);
            this.Controls.Add(this.pnBusqueda);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.btAceptar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMMaterialesArrastres";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Buscar materiales de arrastre";
            this.Load += new System.EventHandler(this.frmMMateriales_Load);
            this.pnBusqueda.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsMateriales1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private void frmMMateriales_Load(object sender, System.EventArgs e)
        {
            try
            {
                lblCampanya.Text = NombreCampanyaA;

                UpdateDataGridViewA(idCampanyaA);

                //El dataGridViewB se actualizará automáticamente cuando el A seleccione la primera fila

                if (dataGridView1.Rows.Count > 0)
                {
                    string idCampanyaB = dataGridView1.Rows[0].Cells["ColidCampanyaArrastrada"].Value.ToString();
                    UpdateDataGridViewB(idCampanyaB);
                }
            }
            catch (Exception ex)
            {
                Mensajes.ShowError(ex.Message);
            }
        }

        private void btCancelar_Click(object sender, System.EventArgs e)
        {
            try
            {
                dataGridView1.EndEdit();
                this.DialogResult = DialogResult.Cancel;
            }
            catch (Exception ex)
            {
                Mensajes.ShowError(ex.Message);
            }
        }

        //Mis campos
        public List<dsMateriales.ListaLineasPedidoRow> MaterialesLinea = null;

        dsMateriales.ListaMaterialesArrastreDataTable dtMaterialesA;
        dsMateriales.ListaMaterialesArrastreDataTable dtMaterialesB;

        private static string obligatorioSi = "Sí"; //Equivale a True

        private Color ErrorColor = Color.FromArgb(255, 90, 90);
        private Color DefaultValueColor = Color.FromArgb(128, 255, 128);
        private Color DisabledColor = Color.Gainsboro;
        private new Color DefaultForeColor = Color.Black;
        private bool paqueteAEstaSeleccionado = false;
        private bool paqueteBEstaSeleccionado = false;

        private string DefaultValue = "0";
        private string filter = String.Empty;

        private string NombreCampanyaA;
        private string NombreCampanyaB = String.Empty;

        private string idCampanyaA = "-1";
        private string idCampanyaB = "-1";
        private string idPaqueteA = "-1";
        private string idPaqueteB = "-1";
        private int idArrastre = -1;
        private decimal MultiplicadorCantidadesArrastre = 1;

        private Keys PressedKey = Keys.None; //Se utiliza para controlar la salida de numericUpDownA y numericUpDownB


        private void btAceptar_Click(object sender, System.EventArgs e)
        {
            try
            {
                MaterialesLinea = new List<dsMateriales.ListaLineasPedidoRow>();

                idArrastre = GetIdArrastre();

                if (idArrastre != -1)
                {
                    InsertLineas(dtMaterialesA, idCampanyaA, NombreCampanyaA);

                    //NombreCampanyaB es String.Empty. frmPedidos la recuparerá del idCampanya
                    InsertLineas(dtMaterialesB, idCampanyaB, NombreCampanyaB);

                    DialogResult = DialogResult.OK;
                }
                else
                    Mensajes.ShowError("No se pudo recuperar el Id de arrastre. Póngase en contacto con el administrador.");

            }
            catch (Exception ex)
            {
                Mensajes.ShowError(ex.Message);
            }
        }

        private int GetIdArrastre()
        {
            string retValue = "-1";

            try
            {
                sqlDaGetIdArrastre.SelectCommand.Parameters["@idCampanyaA"].Value = idCampanyaA;
                sqlDaGetIdArrastre.SelectCommand.Parameters["@idPaqueteA"].Value = int.Parse(idPaqueteA);
                sqlDaGetIdArrastre.SelectCommand.Parameters["@idCampanyaB"].Value = idCampanyaB;
                sqlDaGetIdArrastre.SelectCommand.Parameters["@idPaqueteB"].Value = int.Parse(idPaqueteB);

                sqlDaGetIdArrastre.SelectCommand.Connection.Open();

                //---- GSG (10/09/2014)
                //sqlDaGetIdArrastre.SelectCommand.Connection.Open();
                if (sqlDaGetIdArrastre.SelectCommand.Connection.State == ConnectionState.Closed)
                    sqlDaGetIdArrastre.SelectCommand.Connection.Open();

                retValue = sqlDaGetIdArrastre.SelectCommand.ExecuteScalar().ToString();                
            }
            catch (Exception ex)
            {
                //Mensajes.ShowError(ex.Message);
            }
            finally
            {
                sqlDaGetIdArrastre.SelectCommand.Connection.Close();
            }

            return int.Parse(retValue);
        }

        private void InsertLineas(dsMateriales.ListaMaterialesArrastreDataTable dt, string idCampanya, string nombreCampanya)
        {
            dsMateriales.ListaLineasPedidoDataTable dtMaterialesLinea = new dsMateriales.ListaLineasPedidoDataTable();

            foreach (dsMateriales.ListaMaterialesArrastreRow rw in dt.Rows)
            {
                if (rw.selected)
                {
                    dsMateriales.ListaLineasPedidoRow rowLinea = dtMaterialesLinea.NewListaLineasPedidoRow();

                    rowLinea["sIdMaterial"] = rw.sIdMaterial;
                    rowLinea["sMaterial"] = rw.sMaterial;
                    rowLinea["iCantidad"] = rw.iCantidad;
                    rowLinea["PrecioUnitario"] = rw.fPrecio;
                    rowLinea["fDescuento"] = rw.fDescuento;
                    rowLinea["fDescuentoMaximo"] = rw.fDescuentoMaximo;
                    rowLinea["idCampanya"] = idCampanya;
                    rowLinea["NombreCampanya"] = nombreCampanya;
                    rowLinea["UnidMinimas"] = rw.UnidMinimas;
                    rowLinea["sObligatorio"] = rw.sObligatorio;

                    double preu = double.Parse((double.Parse(rw.iCantidad) * rw.fPrecio).ToString());
                    rowLinea["fPrecio"] = preu;

                    if (preu != 0)
                    {
                        double desc = preu * (double.Parse(rw.fDescuento) / 100);

                        rowLinea["ImporteLin"] = preu - desc;

                        if (!rw.IsfCosteNull())
                        {
                            double ret = preu - desc - (double.Parse(rw.iCantidad) * rw.fCoste);

                            ret = (ret / preu) * 100;

                            rowLinea["fRentabilidad"] = ret;

                        }
                        else
                            rowLinea["fRentabilidad"] = 100;
                    }
                    else
                    {
                        rowLinea["fRentabilidad"] = 0;
                        rowLinea["ImporteLin"] = 0;
                    }

                    if (!rw.IsfCosteNull())
                    {
                        rowLinea["fCoste"] = rw.fCoste;
                    }

                    rowLinea["idArrastre"] = idArrastre;
                    rowLinea["iIdLinea"] = 0;
                    rowLinea["idGrupoMat"] = 0;
                    rowLinea["idPaquete"] = rw.idPaquete;

                    MaterialesLinea.Add(rowLinea);
                }
            }
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            DataGridView_CellBeginEdit(dataGridView1, e);
        }

        private void dataGridView2_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            DataGridView_CellBeginEdit(dataGridView2, e);
        }

        private void DataGridView_CellBeginEdit(DataGridView dgv, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["iCantidad"].Index) //Cantidad
            {
                int UnidMinimasIndex = dataGridView1.Columns["UnidMinimas"].Index;

                string tipText = dgv.Rows[e.RowIndex].Cells[UnidMinimasIndex].Value.ToString();
                Mensajes.SetTip("Unidades mínimas", tipText);
            }
            else
                if (e.ColumnIndex == dataGridView1.Columns["fDescuento"].Index) //Descuento
                {
                    int fDescuentoMaximoIndex = dataGridView1.Columns["fDescuentoMaximo"].Index;

                    string tipText = dgv.Rows[e.RowIndex].Cells[fDescuentoMaximoIndex].Value.ToString() + "%";
                    Mensajes.SetTip("Descuento máximo", tipText);
                }
        }

        private bool EsObligatorio(int RowNumber)
        {
            return dataGridView1.Rows[RowNumber].Cells["sObligatorio"].Value.ToString() == obligatorioSi;
        }

        private void dataGridView1_MouseUp(object sender, MouseEventArgs e)
        {
            DataGridView dgv = dataGridView1;
            NumericUpDown nud = numericUpDownA;

            DataGridView.HitTestInfo hti = dgv.HitTest(e.X, e.Y);

            if (hti.RowIndex < 0) //Se hizo click en la cabecera
                return;

            if ((hti.ColumnIndex == 0) && (paqueteAEstaSeleccionado == false))
            {
                paqueteAEstaSeleccionado = true;
                int selectedIndex = dgv.Columns["selected"].Index;
                dgv.Rows[hti.RowIndex].Cells[selectedIndex].Value = true; //!(bool)dgv.Rows[hti.RowIndex].Cells[selectedIndex].Value;
                idPaqueteA = dgv.Rows[hti.RowIndex].Cells["ColidPaqueteA"].Value.ToString();

                foreach (DataGridViewRow row in dgv.Rows)
                {
                    row.Cells[selectedIndex].Value = row.Cells["ColidPaqueteA"].Value.ToString() == idPaqueteA;
                    if ((bool)row.Cells[selectedIndex].Value == false)
                    {
                        row.DefaultCellStyle.ForeColor = DisabledColor;
                        row.DefaultCellStyle.SelectionForeColor = DisabledColor;
                        row.ReadOnly = true;
                    }
                }

                UpdateDataGridViewB(idCampanyaB);
            }
            else
                if (dgv.IsCurrentCellInEditMode)
                {
                    Mensajes.ShowTip(dgv.Parent.Left + e.X, dgv.Parent.Top + e.Y, this);

                    int iCantidadIndex = dataGridView1.Columns["iCantidad"].Index;
                    int UnidMinimasIndex = dataGridView1.Columns["UnidMinimas"].Index;

                    if (hti.ColumnIndex == iCantidadIndex)
                    {
                        string sUnidMinimas = dgv.Rows[hti.RowIndex].Cells[UnidMinimasIndex].Value.ToString();
                        int iUnidMinimas = int.Parse(sUnidMinimas);

                        nud.Minimum = nud.Increment = iUnidMinimas;
                        nud.Value = int.Parse(dgv.Rows[hti.RowIndex].Cells[iCantidadIndex].Value.ToString());
                        nud.Left = hti.ColumnX;
                        nud.Top = hti.RowY + nud.Height - 2;
                        nud.Visible = true;
                        nud.Focus();
                    }
                }
        }

        private void dataGridView2_MouseUp(object sender, MouseEventArgs e)
        {
            DataGridView dgv = dataGridView2;
            NumericUpDown nud = numericUpDownB;

            DataGridView.HitTestInfo hti = dgv.HitTest(e.X, e.Y);

            if (hti.RowIndex < 0) //Se hizo click en la cabecera
                return;

            if ((hti.ColumnIndex == 0) &&
                (paqueteAEstaSeleccionado == true)) // && 
                //(paqueteBEstaSeleccionado == false))
            {
                paqueteBEstaSeleccionado = true;
                int selectedIndex = dgv.Columns["ColSelected"].Index;
                dgv.Rows[hti.RowIndex].Cells[selectedIndex].Value = true; //!(bool)dgv.Rows[hti.RowIndex].Cells[selectedIndex].Value;
                idPaqueteB = dgv.Rows[hti.RowIndex].Cells["ColidPaqueteB"].Value.ToString();
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    row.Cells[selectedIndex].Value = row.Cells["ColidPaqueteB"].Value.ToString() == idPaqueteB;
                    //if ((bool)row.Cells[selectedIndex].Value == false)
                    //{
                    //    row.DefaultCellStyle.ForeColor = DisabledColor;
                    //    row.DefaultCellStyle.SelectionForeColor = DisabledColor;
                    //    row.ReadOnly = true;
                    //}
                }

                btAceptar.Enabled = true;
            }
            else
                if (dgv.IsCurrentCellInEditMode)
                {
                    Mensajes.ShowTip(dgv.Parent.Left + e.X, dgv.Parent.Top + e.Y, this);

                    int iCantidadIndex = dataGridView1.Columns["iCantidad"].Index;
                    int UnidMinimasIndex = dataGridView1.Columns["UnidMinimas"].Index;

                    if (hti.ColumnIndex == iCantidadIndex)
                    {
                        string sUnidMinimas = dgv.Rows[hti.RowIndex].Cells[UnidMinimasIndex].Value.ToString();
                        int iUnidMinimas = int.Parse(sUnidMinimas);

                        nud.Minimum = nud.Increment = iUnidMinimas;
                        nud.Value = int.Parse(dgv.Rows[hti.RowIndex].Cells[iCantidadIndex].Value.ToString());
                        nud.Left = hti.ColumnX;
                        nud.Top = hti.RowY + nud.Height - 2;
                        nud.Visible = true;
                        nud.Focus();
                    }
                }
        }        

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView_CellClick(dataGridView1);
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView_CellClick(dataGridView2);
        }

        private void DataGridView_CellClick(DataGridView dgv)
        {
            if (dgv.CurrentCell.ReadOnly == false)
                dgv.BeginEdit(true);
        }

        private void dataGridView1_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            DataGridView_CellParsing(dataGridView1, e);
        }

        private void dataGridView2_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            DataGridView_CellParsing(dataGridView2, e);
        }

        private void DataGridView_CellParsing(DataGridView dgv, DataGridViewCellParsingEventArgs e)
        {
            DataGridViewCell cell = dgv.CurrentCell;

            int fDescuentoIndex = dataGridView1.Columns["fDescuento"].Index;
            int fDescuentoMaximoIndex = dataGridView1.Columns["fDescuentoMaximo"].Index;

            if (e.ColumnIndex == fDescuentoIndex) //Validar Descuento
            {
                string sDescuentoMaximo = dgv.Rows[e.RowIndex].Cells[fDescuentoMaximoIndex].Value.ToString();
                float fDescuentoMaximo = float.Parse(sDescuentoMaximo);

                string sDescuento = e.Value.ToString();
                float fDescuento;

                float.TryParse(sDescuento, out fDescuento);
                if ((fDescuento <= 0) && sDescuento != "0")
                {
                    cell.Style.BackColor = DefaultValueColor;
                    cell.Style.SelectionBackColor = DefaultValueColor;
                    DefaultValue = dgv.Rows[e.RowIndex].Cells[fDescuentoIndex].Value.ToString();
                    //dataGridView1.Rows[e.RowIndex].Cells["selected"].Value = false;

                    Mensajes.ShowError(String.Format("Valor de descuento incorrecto ({0}). Debe introducir un número mayor o igual que 0.", sDescuento));
                    e.ParsingApplied = false;

                    return;
                }

                if (fDescuento > fDescuentoMaximo)
                {
                    cell.Style.BackColor = DefaultValueColor;
                    cell.Style.SelectionBackColor = DefaultValueColor;
                    DefaultValue = dgv.Rows[e.RowIndex].Cells[fDescuentoIndex].Value.ToString();

                    e.ParsingApplied = false;

                    Mensajes.ShowError(String.Format("El descuento aplicado ({0}%) supera al descuento máximo ({1}%).", sDescuento, sDescuentoMaximo));
                }
                else
                {
                    e.ParsingApplied = true;
                }
            }

            if (e.ParsingApplied == true)
            {
                cell.Style.BackColor = dgv.Rows[e.RowIndex].Cells[0].Style.BackColor;
                cell.Style.SelectionBackColor = dgv.Rows[e.RowIndex].Cells[0].Style.SelectionBackColor;
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView_CellEndEdit(dataGridView1, numericUpDownA);
        }

        private void dataGridView2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView_CellEndEdit(dataGridView2, numericUpDownB);
        }

        private void DataGridView_CellEndEdit(DataGridView dgv, NumericUpDown nud)
        {
            if (nud.Visible == false)
                Mensajes.HideTip();

            if (dgv.CurrentCell.Style.BackColor == DefaultValueColor)
            {
                dgv.CurrentCell.Value = DefaultValue;
            }
        }

        private void UpdateDataGridViewA(string idCampanya)
        {
            try
            {
                this.sqlDaListaMaterialesA.SelectCommand.Parameters["@sidCampanyaA"].Value = idCampanya;
                dtMaterialesA.Clear();
                this.sqlDaListaMaterialesA.Fill(dtMaterialesA);
                dataGridView1.DataSource = dtMaterialesA;
                this.lblNumRegA.Text = dataGridView1.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                Mensajes.ShowError(ex.Message);
            }
        }

        private void UpdateDataGridViewB(string idCampanya)
        {
            try
            {
                this.sqlDaListaMaterialesB.SelectCommand.Parameters["@sidCampanyaB"].Value = idCampanya;

                if (paqueteAEstaSeleccionado == true)
                {
                    this.sqlDaListaMaterialesB.SelectCommand.Parameters["@idPaqueteA"].Value = idPaqueteA;
                }
                else
                {
                    this.sqlDaListaMaterialesB.SelectCommand.Parameters["@idPaqueteA"].Value = DBNull.Value;
                }

                dtMaterialesB.Clear();
                this.sqlDaListaMaterialesB.Fill(dtMaterialesB);
                dataGridView2.DataSource = dtMaterialesB;
                this.lblNumRegB.Text = dataGridView2.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                Mensajes.ShowError(ex.Message);
            }
        }

        private void numericUpDownA_Leave(object sender, EventArgs e)
        {
            Mensajes.HideTip();
            numericUpDownA.Visible = false;

            if (PressedKey == Keys.Escape)
            {
                PressedKey = Keys.None;
                return;
            }

            MultiplicadorCantidadesArrastre = numericUpDownA.Value / numericUpDownA.Increment;
            ActualizaCantidadesA();
            ActualizaCantidadesB();
            //dataGridView1.CurrentCell.Value = numericUpDownA.Value.ToString();
        }

        private void numericUpDownA_KeyDown(object sender, KeyEventArgs e)
        {
            PressedKey = e.KeyCode;

            if ((PressedKey == Keys.Enter) || (PressedKey == Keys.Escape))
                dataGridView1.Focus();
        }

        private void numericUpDownB_Leave(object sender, EventArgs e)
        {
            Mensajes.HideTip();
            numericUpDownB.Visible = false;

            if (PressedKey == Keys.Escape)
            {
                PressedKey = Keys.None;
                return;
            }

            MultiplicadorCantidadesArrastre = numericUpDownB.Value / numericUpDownB.Increment;
            ActualizaCantidadesA();
            ActualizaCantidadesB();
            //dataGridView2.CurrentCell.Value = numericUpDownB.Value.ToString();
        }

        private void numericUpDownB_KeyDown(object sender, KeyEventArgs e)
        {
            PressedKey = e.KeyCode;

            if ((PressedKey == Keys.Enter) || (PressedKey == Keys.Escape))
                dataGridView2.Focus();
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if ((dataGridView1.Rows.Count > 1) && (paqueteAEstaSeleccionado == false))
            {
                idCampanyaB = dataGridView1.Rows[e.RowIndex].Cells["ColidCampanyaArrastrada"].Value.ToString();
                if (e.ColumnIndex > 0)
                {
                    UpdateDataGridViewB(idCampanyaB);
                    ActualizaCantidadesB();
                }
            }            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            paqueteAEstaSeleccionado = false;
            paqueteBEstaSeleccionado = false;            

            int selectedIndex = dataGridView1.Columns["selected"].Index;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells[selectedIndex].Value = false;
                row.ReadOnly = false;
                row.DefaultCellStyle.ForeColor = DefaultForeColor;
                row.DefaultCellStyle.SelectionForeColor = DefaultForeColor;
                row.Cells["fDescuento"].Style.BackColor = row.Cells[0].Style.BackColor;
                row.Cells["fDescuento"].Style.SelectionBackColor = row.Cells[0].Style.SelectionBackColor;
                row.Cells["iCantidad"].Value = row.Cells["UnidMinimas"].Value;
            }

            if (dataGridView1.Rows.Count > 0)
            {
                string idCampanyaB = dataGridView1.Rows[0].Cells["ColidCampanyaArrastrada"].Value.ToString();
                UpdateDataGridViewB(idCampanyaB);
            }

            //selectedIndex = dataGridView2.Columns["ColSelected"].Index;
            //foreach (DataGridViewRow row in dataGridView2.Rows)
            //{
            //    row.Cells[selectedIndex].Value = false;
            //    row.Cells["ColDescuento"].Style.BackColor = row.Cells[0].Style.BackColor;
            //    row.Cells["ColDescuento"].Style.SelectionBackColor = row.Cells[0].Style.SelectionBackColor;
            //    row.Cells["ColCantidad"].Value = row.Cells["ColUnidMinimas"].Value;
            //}

            btAceptar.Enabled = false;
        }

        private void ActualizaCantidadesA()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {                
                int iUnidMinimas = int.Parse(row.Cells["UnidMinimas"].Value.ToString());
                row.Cells["iCantidad"].Value = (iUnidMinimas * MultiplicadorCantidadesArrastre).ToString();                
            }
        }

        private void ActualizaCantidadesB()
        {
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                int iUnidMinimas = int.Parse(row.Cells["ColUnidMinimas"].Value.ToString());
                row.Cells["ColCantidad"].Value = (iUnidMinimas * MultiplicadorCantidadesArrastre).ToString();
            }
        }
    }
}
