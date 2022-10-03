namespace WinForms
{
    partial class frmMostrarDocumentos
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
            this.label1 = new System.Windows.Forms.Label();
            this.lbljunta = new System.Windows.Forms.Label();
            this.dgMarcas = new System.Windows.Forms.DataGridView();
            this.txtDato = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgMarcas)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(297, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "DOCUMENTOS ESCANEADOS:";
            // 
            // lbljunta
            // 
            this.lbljunta.AutoSize = true;
            this.lbljunta.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbljunta.Location = new System.Drawing.Point(326, 9);
            this.lbljunta.Name = "lbljunta";
            this.lbljunta.Size = new System.Drawing.Size(60, 22);
            this.lbljunta.TabIndex = 2;
            this.lbljunta.Text = "junta:";
            // 
            // dgMarcas
            // 
            this.dgMarcas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgMarcas.Location = new System.Drawing.Point(16, 45);
            this.dgMarcas.Name = "dgMarcas";
            this.dgMarcas.Size = new System.Drawing.Size(921, 159);
            this.dgMarcas.TabIndex = 3;
            this.dgMarcas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgMarcas_CellContentClick);
            // 
            // txtDato
            // 
            this.txtDato.Location = new System.Drawing.Point(16, 232);
            this.txtDato.Name = "txtDato";
            this.txtDato.Size = new System.Drawing.Size(810, 20);
            this.txtDato.TabIndex = 4;
            // 
            // frmMostrarDocumentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 273);
            this.Controls.Add(this.txtDato);
            this.Controls.Add(this.dgMarcas);
            this.Controls.Add(this.lbljunta);
            this.Controls.Add(this.label1);
            this.Name = "frmMostrarDocumentos";
            this.Text = "frmMostrarDocumentos";
            this.Load += new System.EventHandler(this.frmMostrarDocumentos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgMarcas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbljunta;
        private System.Windows.Forms.DataGridView dgMarcas;
        private System.Windows.Forms.TextBox txtDato;
    }
}