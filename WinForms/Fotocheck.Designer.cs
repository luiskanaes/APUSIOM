namespace WinForms
{
    partial class Fotocheck
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
            this.btnReporte = new System.Windows.Forms.Button();
            this.imgQR = new System.Windows.Forms.PictureBox();
            this.btnQR = new System.Windows.Forms.Button();
            this.dgvPersonal = new System.Windows.Forms.DataGridView();
            this.btnlistarPersonal = new System.Windows.Forms.Button();
            this.btnListarObreros = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cboCentroCosto = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboEmpresa = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imgQR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonal)).BeginInit();
            this.SuspendLayout();
            // 
            // btnReporte
            // 
            this.btnReporte.Location = new System.Drawing.Point(673, 60);
            this.btnReporte.Name = "btnReporte";
            this.btnReporte.Size = new System.Drawing.Size(114, 30);
            this.btnReporte.TabIndex = 34;
            this.btnReporte.Text = "Exportar Fotocheck";
            this.btnReporte.UseVisualStyleBackColor = true;
            this.btnReporte.Click += new System.EventHandler(this.btnReporte_Click);
            // 
            // imgQR
            // 
            this.imgQR.Location = new System.Drawing.Point(117, 60);
            this.imgQR.Name = "imgQR";
            this.imgQR.Size = new System.Drawing.Size(52, 30);
            this.imgQR.TabIndex = 33;
            this.imgQR.TabStop = false;
            this.imgQR.Visible = false;
            // 
            // btnQR
            // 
            this.btnQR.Location = new System.Drawing.Point(567, 60);
            this.btnQR.Name = "btnQR";
            this.btnQR.Size = new System.Drawing.Size(100, 30);
            this.btnQR.TabIndex = 32;
            this.btnQR.Text = "Generar QR";
            this.btnQR.UseVisualStyleBackColor = true;
            this.btnQR.Click += new System.EventHandler(this.btnQR_Click);
            // 
            // dgvPersonal
            // 
            this.dgvPersonal.AllowUserToAddRows = false;
            this.dgvPersonal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPersonal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPersonal.Location = new System.Drawing.Point(4, 96);
            this.dgvPersonal.Name = "dgvPersonal";
            this.dgvPersonal.Size = new System.Drawing.Size(1293, 456);
            this.dgvPersonal.TabIndex = 31;
            this.dgvPersonal.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPersonal_CellClick);
            // 
            // btnlistarPersonal
            // 
            this.btnlistarPersonal.Image = global::WinForms.Properties.Resources.botonEmpleados;
            this.btnlistarPersonal.Location = new System.Drawing.Point(301, 60);
            this.btnlistarPersonal.Name = "btnlistarPersonal";
            this.btnlistarPersonal.Size = new System.Drawing.Size(125, 30);
            this.btnlistarPersonal.TabIndex = 28;
            this.btnlistarPersonal.UseVisualStyleBackColor = true;
            this.btnlistarPersonal.Click += new System.EventHandler(this.btnlistarPersonal_Click);
            // 
            // btnListarObreros
            // 
            this.btnListarObreros.Image = global::WinForms.Properties.Resources.botonObreros;
            this.btnListarObreros.Location = new System.Drawing.Point(435, 60);
            this.btnListarObreros.Name = "btnListarObreros";
            this.btnListarObreros.Size = new System.Drawing.Size(125, 30);
            this.btnListarObreros.TabIndex = 30;
            this.btnListarObreros.UseVisualStyleBackColor = true;
            this.btnListarObreros.Click += new System.EventHandler(this.btnListarObreros_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(230, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "PERSONAL";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // cboCentroCosto
            // 
            this.cboCentroCosto.FormattingEnabled = true;
            this.cboCentroCosto.Location = new System.Drawing.Point(301, 35);
            this.cboCentroCosto.Name = "cboCentroCosto";
            this.cboCentroCosto.Size = new System.Drawing.Size(609, 21);
            this.cboCentroCosto.TabIndex = 27;
            this.cboCentroCosto.SelectedIndexChanged += new System.EventHandler(this.cboCentroCosto_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(238, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "C. COSTO";
            // 
            // cboEmpresa
            // 
            this.cboEmpresa.FormattingEnabled = true;
            this.cboEmpresa.Location = new System.Drawing.Point(71, 35);
            this.cboEmpresa.Name = "cboEmpresa";
            this.cboEmpresa.Size = new System.Drawing.Size(161, 21);
            this.cboEmpresa.TabIndex = 25;
            this.cboEmpresa.SelectedIndexChanged += new System.EventHandler(this.cboEmpresa_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "EMPRESA";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(1, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1296, 23);
            this.label2.TabIndex = 23;
            this.label2.Text = "Impresion de Fotocheck";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Fotocheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1309, 560);
            this.Controls.Add(this.btnReporte);
            this.Controls.Add(this.imgQR);
            this.Controls.Add(this.btnQR);
            this.Controls.Add(this.dgvPersonal);
            this.Controls.Add(this.btnListarObreros);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnlistarPersonal);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cboEmpresa);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboCentroCosto);
            this.Controls.Add(this.label2);
            this.Name = "Fotocheck";
            this.Text = "Fotocheck";
            this.Load += new System.EventHandler(this.Fotocheck_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgQR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReporte;
        private System.Windows.Forms.PictureBox imgQR;
        private System.Windows.Forms.Button btnQR;
        private System.Windows.Forms.DataGridView dgvPersonal;
        private System.Windows.Forms.Button btnlistarPersonal;
        private System.Windows.Forms.Button btnListarObreros;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboCentroCosto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboEmpresa;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
    }
}