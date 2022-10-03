namespace WinForms
{
    partial class frmRegistroNuevaJunta
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
            this.txtServicio = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTrain = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLine = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUnit = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtNroJunta = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dgJunta = new System.Windows.Forms.DataGridView();
            this.txtNuevaJunta = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dgJuntaNueva = new System.Windows.Forms.DataGridView();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cboTipoJunta = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cboUbicacion = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtDiametro = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgJunta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgJuntaNueva)).BeginInit();
            this.SuspendLayout();
            // 
            // txtServicio
            // 
            this.txtServicio.Location = new System.Drawing.Point(365, 59);
            this.txtServicio.Name = "txtServicio";
            this.txtServicio.Size = new System.Drawing.Size(100, 20);
            this.txtServicio.TabIndex = 29;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(299, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 35;
            this.label5.Text = "SERVICIO:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(124, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(314, 25);
            this.label4.TabIndex = 34;
            this.label4.Text = "REGISTRO DE NUEVA JUNTA";
            // 
            // txtTrain
            // 
            this.txtTrain.Location = new System.Drawing.Point(701, 59);
            this.txtTrain.Name = "txtTrain";
            this.txtTrain.Size = new System.Drawing.Size(100, 20);
            this.txtTrain.TabIndex = 33;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(652, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 32;
            this.label3.Text = "TRAIN:";
            // 
            // txtLine
            // 
            this.txtLine.Location = new System.Drawing.Point(527, 59);
            this.txtLine.Name = "txtLine";
            this.txtLine.Size = new System.Drawing.Size(100, 20);
            this.txtLine.TabIndex = 31;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(487, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "LINE:";
            // 
            // txtUnit
            // 
            this.txtUnit.Location = new System.Drawing.Point(176, 59);
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.Size = new System.Drawing.Size(100, 20);
            this.txtUnit.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(126, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "UNIT:";
            // 
            // btnGrabar
            // 
            this.btnGrabar.Location = new System.Drawing.Point(1055, 343);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(110, 33);
            this.btnGrabar.TabIndex = 26;
            this.btnGrabar.Text = "GRABAR";
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(973, 53);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(110, 33);
            this.btnBuscar.TabIndex = 24;
            this.btnBuscar.Text = "BUSCAR";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtNroJunta
            // 
            this.txtNroJunta.Location = new System.Drawing.Point(895, 60);
            this.txtNroJunta.Name = "txtNroJunta";
            this.txtNroJunta.Size = new System.Drawing.Size(100, 20);
            this.txtNroJunta.TabIndex = 37;
            this.txtNroJunta.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(817, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 36;
            this.label6.Text = "NRO JUNTA:";
            this.label6.Visible = false;
            // 
            // dgJunta
            // 
            this.dgJunta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgJunta.Location = new System.Drawing.Point(54, 92);
            this.dgJunta.Name = "dgJunta";
            this.dgJunta.Size = new System.Drawing.Size(1161, 234);
            this.dgJunta.TabIndex = 25;
            // 
            // txtNuevaJunta
            // 
            this.txtNuevaJunta.Location = new System.Drawing.Point(212, 349);
            this.txtNuevaJunta.MaxLength = 5;
            this.txtNuevaJunta.Name = "txtNuevaJunta";
            this.txtNuevaJunta.Size = new System.Drawing.Size(72, 20);
            this.txtNuevaJunta.TabIndex = 39;
            this.txtNuevaJunta.TextChanged += new System.EventHandler(this.txtNuevaJunta_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(93, 353);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 13);
            this.label7.TabIndex = 38;
            this.label7.Text = "NUEVO NRO JUNTA:";
            // 
            // dgJuntaNueva
            // 
            this.dgJuntaNueva.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgJuntaNueva.Location = new System.Drawing.Point(54, 387);
            this.dgJuntaNueva.Name = "dgJuntaNueva";
            this.dgJuntaNueva.Size = new System.Drawing.Size(1161, 100);
            this.dgJuntaNueva.TabIndex = 40;
            // 
            // btnGenerar
            // 
            this.btnGenerar.Location = new System.Drawing.Point(939, 344);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(110, 33);
            this.btnGenerar.TabIndex = 41;
            this.btnGenerar.Text = "GENERAR";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(300, 38);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(234, 12);
            this.label8.TabIndex = 42;
            this.label8.Text = "***INGRESAR DATOS DEL FILTROS COMPLETOS***";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(290, 353);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(91, 13);
            this.label9.TabIndex = 43;
            this.label9.Text = "TIPO DE JUNTA:";
            // 
            // cboTipoJunta
            // 
            this.cboTipoJunta.FormattingEnabled = true;
            this.cboTipoJunta.Location = new System.Drawing.Point(381, 349);
            this.cboTipoJunta.Name = "cboTipoJunta";
            this.cboTipoJunta.Size = new System.Drawing.Size(121, 21);
            this.cboTipoJunta.TabIndex = 44;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(520, 353);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 13);
            this.label10.TabIndex = 45;
            this.label10.Text = "UBICACION:";
            // 
            // cboUbicacion
            // 
            this.cboUbicacion.FormattingEnabled = true;
            this.cboUbicacion.Location = new System.Drawing.Point(589, 349);
            this.cboUbicacion.Name = "cboUbicacion";
            this.cboUbicacion.Size = new System.Drawing.Size(121, 21);
            this.cboUbicacion.TabIndex = 46;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(51, 495);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(155, 18);
            this.label11.TabIndex = 47;
            this.label11.Text = "NOMENCLATURA: ";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(51, 517);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(678, 17);
            this.label12.TabIndex = 48;
            this.label12.Text = "SOPORTES:  CONSIDERAR LA NOMENCLATURA CON DOS DÍGITOS   S01, S02… S10, S11…";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(51, 534);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(679, 17);
            this.label13.TabIndex = 49;
            this.label13.Text = "ROSCADOS:  CONSIDERAR LA NOMENCLATURA CON DOS DÍGITOS   T01, T02… T10, T11…";
            // 
            // txtDiametro
            // 
            this.txtDiametro.Location = new System.Drawing.Point(807, 350);
            this.txtDiametro.MaxLength = 5;
            this.txtDiametro.Name = "txtDiametro";
            this.txtDiametro.Size = new System.Drawing.Size(72, 20);
            this.txtDiametro.TabIndex = 51;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(730, 353);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(67, 13);
            this.label14.TabIndex = 50;
            this.label14.Text = "DIAMETRO:";
            // 
            // frmRegistroNuevaJunta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1249, 613);
            this.Controls.Add(this.txtDiametro);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cboUbicacion);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cboTipoJunta);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.dgJuntaNueva);
            this.Controls.Add(this.txtNuevaJunta);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtNroJunta);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtServicio);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTrain);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtLine);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtUnit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.dgJunta);
            this.Controls.Add(this.btnBuscar);
            this.Name = "frmRegistroNuevaJunta";
            this.Text = "frmRegistroNuevaJunta";
            this.Load += new System.EventHandler(this.frmRegistroNuevaJunta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgJunta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgJuntaNueva)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtServicio;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTrain;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLine;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUnit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtNroJunta;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgJunta;
        private System.Windows.Forms.TextBox txtNuevaJunta;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dgJuntaNueva;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboTipoJunta;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboUbicacion;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtDiametro;
        private System.Windows.Forms.Label label14;
    }
}