namespace GESTCRM.Formularios
{
    partial class frmImportarPedido
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
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnImportar;
        private System.Windows.Forms.Label lblImportando;
        private System.Windows.Forms.GroupBox gb1;
        private System.Windows.Forms.ComboBox cBoxCampanyas;
        private System.Windows.Forms.Button btBuscarFichero;
        public System.Windows.Forms.TextBox txtFichero;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtClienteSAP;
        private System.Windows.Forms.Button btBuscarCliente;
        private System.Windows.Forms.TextBox txtsCliente;
        private System.Windows.Forms.Label lblMissNoImportados;
        private System.Windows.Forms.Label lblComboC;
        private System.Windows.Forms.Button btnContinuar;
        private System.Windows.Forms.TextBox textBoxMaterialesNoImportados;
        private System.Windows.Forms.GroupBox gb2;
        private System.Windows.Forms.Label lblMissSinStock;
        private System.Windows.Forms.TextBox textBoxMaterialesSinStock;
        private System.Data.SqlClient.SqlDataAdapter sqldaListaTiposPedidoSAP;
        private System.Data.SqlClient.SqlCommand sqlSelectCommand3;
        private System.Windows.Forms.ComboBox cboTipoPedido;
        private System.Windows.Forms.Label lblTipoPedido;
        private System.Windows.Forms.CheckBox chkBoxFlexible;
        private System.Windows.Forms.CheckBox chkBoxCampanya;
        private System.Windows.Forms.CheckBox chkBoxDescuentos;
        private System.Windows.Forms.CheckBox chkBoxTipoPedido;
    }
}