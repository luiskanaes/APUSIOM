namespace WinForms
{
    partial class FotoCheckId
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
            this.imgFoto = new System.Windows.Forms.PictureBox();
            this.txtDNI = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPaterno = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMaterno = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.btnFoto = new System.Windows.Forms.Button();
            this.txtFileToImport = new System.Windows.Forms.TextBox();
            this.lblFoto = new System.Windows.Forms.Label();
            this.lblFotoCheck = new System.Windows.Forms.Label();
            this.imgQR = new System.Windows.Forms.PictureBox();
            this.btnQr = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.imgFoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgQR)).BeginInit();
            this.SuspendLayout();
            // 
            // imgFoto
            // 
            this.imgFoto.Location = new System.Drawing.Point(2, 8);
            this.imgFoto.Name = "imgFoto";
            this.imgFoto.Size = new System.Drawing.Size(132, 162);
            this.imgFoto.TabIndex = 0;
            this.imgFoto.TabStop = false;
            // 
            // txtDNI
            // 
            this.txtDNI.Location = new System.Drawing.Point(140, 22);
            this.txtDNI.Name = "txtDNI";
            this.txtDNI.Size = new System.Drawing.Size(158, 20);
            this.txtDNI.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(141, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "DNI";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(141, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "APELLIDO PATERNO";
            // 
            // txtPaterno
            // 
            this.txtPaterno.Location = new System.Drawing.Point(140, 60);
            this.txtPaterno.Name = "txtPaterno";
            this.txtPaterno.Size = new System.Drawing.Size(158, 20);
            this.txtPaterno.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(141, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "APELLIDO MATERNO";
            // 
            // txtMaterno
            // 
            this.txtMaterno.Location = new System.Drawing.Point(140, 99);
            this.txtMaterno.Name = "txtMaterno";
            this.txtMaterno.Size = new System.Drawing.Size(158, 20);
            this.txtMaterno.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(141, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "NOMBRES";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(140, 136);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(158, 20);
            this.txtNombre.TabIndex = 7;
            // 
            // btnFoto
            // 
            this.btnFoto.Location = new System.Drawing.Point(2, 176);
            this.btnFoto.Name = "btnFoto";
            this.btnFoto.Size = new System.Drawing.Size(132, 23);
            this.btnFoto.TabIndex = 9;
            this.btnFoto.Text = "Subir foto";
            this.btnFoto.UseVisualStyleBackColor = true;
            this.btnFoto.Click += new System.EventHandler(this.btnFoto_Click);
            // 
            // txtFileToImport
            // 
            this.txtFileToImport.Location = new System.Drawing.Point(240, 333);
            this.txtFileToImport.Name = "txtFileToImport";
            this.txtFileToImport.Size = new System.Drawing.Size(67, 20);
            this.txtFileToImport.TabIndex = 10;
            this.txtFileToImport.Visible = false;
            // 
            // lblFoto
            // 
            this.lblFoto.AutoSize = true;
            this.lblFoto.Location = new System.Drawing.Point(-1, 356);
            this.lblFoto.Name = "lblFoto";
            this.lblFoto.Size = new System.Drawing.Size(38, 13);
            this.lblFoto.TabIndex = 11;
            this.lblFoto.Text = "lblFoto";
            this.lblFoto.Visible = false;
            // 
            // lblFotoCheck
            // 
            this.lblFotoCheck.AutoSize = true;
            this.lblFotoCheck.Location = new System.Drawing.Point(240, 356);
            this.lblFotoCheck.Name = "lblFotoCheck";
            this.lblFotoCheck.Size = new System.Drawing.Size(69, 13);
            this.lblFotoCheck.TabIndex = 12;
            this.lblFotoCheck.Text = "lblFotoCheck";
            this.lblFotoCheck.Visible = false;
            // 
            // imgQR
            // 
            this.imgQR.Location = new System.Drawing.Point(62, 205);
            this.imgQR.Name = "imgQR";
            this.imgQR.Size = new System.Drawing.Size(172, 161);
            this.imgQR.TabIndex = 13;
            this.imgQR.TabStop = false;
            // 
            // btnQr
            // 
            this.btnQr.Location = new System.Drawing.Point(140, 176);
            this.btnQr.Name = "btnQr";
            this.btnQr.Size = new System.Drawing.Size(158, 23);
            this.btnQr.TabIndex = 14;
            this.btnQr.Text = "Generar QR";
            this.btnQr.UseVisualStyleBackColor = true;
            this.btnQr.Click += new System.EventHandler(this.btnQr_Click);
            // 
            // FotoCheckId
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 378);
            this.Controls.Add(this.btnQr);
            this.Controls.Add(this.imgQR);
            this.Controls.Add(this.lblFotoCheck);
            this.Controls.Add(this.lblFoto);
            this.Controls.Add(this.txtFileToImport);
            this.Controls.Add(this.btnFoto);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtMaterno);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPaterno);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDNI);
            this.Controls.Add(this.imgFoto);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FotoCheckId";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FotoCheckId";
            this.Load += new System.EventHandler(this.FotoCheckId_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgFoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgQR)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox imgFoto;
        private System.Windows.Forms.TextBox txtDNI;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPaterno;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMaterno;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Button btnFoto;
        private System.Windows.Forms.TextBox txtFileToImport;
        private System.Windows.Forms.Label lblFoto;
        private System.Windows.Forms.Label lblFotoCheck;
        private System.Windows.Forms.PictureBox imgQR;
        private System.Windows.Forms.Button btnQr;
    }
}