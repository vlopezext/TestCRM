namespace GESTCRM.Formularios
{
    partial class frmTip
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
            this.pnlShadow = new System.Windows.Forms.Panel();
            this.pnlMyTip = new System.Windows.Forms.Panel();
            this.tipCaption = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tipText = new System.Windows.Forms.Label();
            this.pnlMyTip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlShadow
            // 
            this.pnlShadow.BackColor = System.Drawing.Color.LightGray;
            this.pnlShadow.Location = new System.Drawing.Point(2, 2);
            this.pnlShadow.Name = "pnlShadow";
            this.pnlShadow.Size = new System.Drawing.Size(198, 49);
            this.pnlShadow.TabIndex = 17;
            // 
            // pnlMyTip
            // 
            this.pnlMyTip.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.pnlMyTip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMyTip.Controls.Add(this.tipCaption);
            this.pnlMyTip.Controls.Add(this.pictureBox1);
            this.pnlMyTip.Controls.Add(this.tipText);
            this.pnlMyTip.Location = new System.Drawing.Point(0, 0);
            this.pnlMyTip.Name = "pnlMyTip";
            this.pnlMyTip.Size = new System.Drawing.Size(198, 49);
            this.pnlMyTip.TabIndex = 93;
            // 
            // tipCaption
            // 
            this.tipCaption.AutoEllipsis = true;
            this.tipCaption.AutoSize = true;
            this.tipCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tipCaption.Location = new System.Drawing.Point(55, 7);
            this.tipCaption.MaximumSize = new System.Drawing.Size(150, 0);
            this.tipCaption.Name = "tipCaption";
            this.tipCaption.Size = new System.Drawing.Size(61, 16);
            this.tipCaption.TabIndex = 16;
            this.tipCaption.Text = "Caption";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.pictureBox1.Image = global::GESTCRM.Properties.Resources.info_048x048;
            this.pictureBox1.Location = new System.Drawing.Point(1, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 50);
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // tipText
            // 
            this.tipText.AutoEllipsis = true;
            this.tipText.AutoSize = true;
            this.tipText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tipText.Location = new System.Drawing.Point(55, 23);
            this.tipText.MaximumSize = new System.Drawing.Size(150, 0);
            this.tipText.Name = "tipText";
            this.tipText.Size = new System.Drawing.Size(60, 16);
            this.tipText.TabIndex = 14;
            this.tipText.Text = "Mensaje";
            // 
            // frmTip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(200, 51);
            this.Controls.Add(this.pnlMyTip);
            this.Controls.Add(this.pnlShadow);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmTip";
            this.Opacity = 0;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frmTip";
            this.TransparencyKey = System.Drawing.Color.Silver;
            this.pnlMyTip.ResumeLayout(false);
            this.pnlMyTip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlShadow;
        private System.Windows.Forms.Panel pnlMyTip;
        public System.Windows.Forms.Label tipCaption;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Label tipText;

    }
}