namespace WinForms
{
    partial class frmReporteIV
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
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dgMarcas = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTrain = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLine = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUnit = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExportar = new System.Windows.Forms.Button();
            this.dtpFin = new System.Windows.Forms.DateTimePicker();
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkSinFecha = new System.Windows.Forms.CheckBox();
            this.txtServicio = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.chkPendientes = new System.Windows.Forms.CheckBox();
            this.dgMarcas_Export = new System.Windows.Forms.DataGridView();
            this.dtp = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dgMarcas)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgMarcas_Export)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(1066, 35);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(85, 33);
            this.btnBuscar.TabIndex = 36;
            this.btnBuscar.Text = "BUSCAR";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // dgMarcas
            // 
            this.dgMarcas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgMarcas.Location = new System.Drawing.Point(23, 99);
            this.dgMarcas.Name = "dgMarcas";
            this.dgMarcas.Size = new System.Drawing.Size(1321, 497);
            this.dgMarcas.TabIndex = 35;
            this.dgMarcas.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgMarcas_CellLeave);
            this.dgMarcas.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgMarcas_CellValidating);
            this.dgMarcas.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgMarcas_CellValueChanged);
            this.dgMarcas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgMarcas_MouseDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(50, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(343, 25);
            this.label4.TabIndex = 34;
            this.label4.Text = "REPORTE INSPECCION VISUAL ";
            // 
            // txtTrain
            // 
            this.txtTrain.Location = new System.Drawing.Point(600, 61);
            this.txtTrain.Name = "txtTrain";
            this.txtTrain.Size = new System.Drawing.Size(100, 20);
            this.txtTrain.TabIndex = 32;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(551, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 32;
            this.label3.Text = "TRAIN:";
            // 
            // txtLine
            // 
            this.txtLine.Location = new System.Drawing.Point(445, 61);
            this.txtLine.Name = "txtLine";
            this.txtLine.Size = new System.Drawing.Size(100, 20);
            this.txtLine.TabIndex = 31;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(404, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "LINE:";
            // 
            // txtUnit
            // 
            this.txtUnit.Location = new System.Drawing.Point(96, 60);
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.Size = new System.Drawing.Size(100, 20);
            this.txtUnit.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "UNIT:";
            // 
            // btnExportar
            // 
            this.btnExportar.Location = new System.Drawing.Point(1248, 35);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(86, 33);
            this.btnExportar.TabIndex = 27;
            this.btnExportar.Text = "EXPORTAR";
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // dtpFin
            // 
            this.dtpFin.CustomFormat = "dd/MM/yyyy";
            this.dtpFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFin.Location = new System.Drawing.Point(228, 45);
            this.dtpFin.Name = "dtpFin";
            this.dtpFin.Size = new System.Drawing.Size(80, 20);
            this.dtpFin.TabIndex = 35;
            // 
            // dtpInicio
            // 
            this.dtpInicio.CustomFormat = "dd/MM/yyyy";
            this.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpInicio.Location = new System.Drawing.Point(77, 45);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.Size = new System.Drawing.Size(93, 20);
            this.dtpInicio.TabIndex = 34;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "INICIO:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(195, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = "FIN:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkSinFecha);
            this.groupBox1.Controls.Add(this.dtpFin);
            this.groupBox1.Controls.Add(this.dtpInicio);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Location = new System.Drawing.Point(719, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(327, 81);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "FECHA SOLDADURA";
            // 
            // chkSinFecha
            // 
            this.chkSinFecha.AutoSize = true;
            this.chkSinFecha.Location = new System.Drawing.Point(14, 22);
            this.chkSinFecha.Name = "chkSinFecha";
            this.chkSinFecha.Size = new System.Drawing.Size(156, 17);
            this.chkSinFecha.TabIndex = 44;
            this.chkSinFecha.Text = "SIN CONSIDERAR FECHA";
            this.chkSinFecha.UseVisualStyleBackColor = true;
            // 
            // txtServicio
            // 
            this.txtServicio.Location = new System.Drawing.Point(277, 61);
            this.txtServicio.Name = "txtServicio";
            this.txtServicio.Size = new System.Drawing.Size(100, 20);
            this.txtServicio.TabIndex = 30;
            this.txtServicio.TextChanged += new System.EventHandler(this.txtServicio_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(211, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 39;
            this.label5.Text = "SERVICIO:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.Location = new System.Drawing.Point(1157, 35);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(85, 33);
            this.btnGrabar.TabIndex = 40;
            this.btnGrabar.Text = "GRABAR";
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // chkPendientes
            // 
            this.chkPendientes.AutoSize = true;
            this.chkPendientes.Location = new System.Drawing.Point(600, 29);
            this.chkPendientes.Name = "chkPendientes";
            this.chkPendientes.Size = new System.Drawing.Size(95, 17);
            this.chkPendientes.TabIndex = 41;
            this.chkPendientes.Text = "PENDIENTES";
            this.chkPendientes.UseVisualStyleBackColor = true;
            // 
            // dgMarcas_Export
            // 
            this.dgMarcas_Export.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgMarcas_Export.Location = new System.Drawing.Point(12, 12);
            this.dgMarcas_Export.Name = "dgMarcas_Export";
            this.dgMarcas_Export.Size = new System.Drawing.Size(36, 22);
            this.dgMarcas_Export.TabIndex = 42;
            this.dgMarcas_Export.Visible = false;
            // 
            // dtp
            // 
            this.dtp.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp.Location = new System.Drawing.Point(116, 252);
            this.dtp.Name = "dtp";
            this.dtp.Size = new System.Drawing.Size(113, 20);
            this.dtp.TabIndex = 43;
            this.dtp.Visible = false;
            // 
            // frmReporteIV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1354, 561);
            this.Controls.Add(this.dtp);
            this.Controls.Add(this.dgMarcas_Export);
            this.Controls.Add(this.chkPendientes);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.txtServicio);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.dgMarcas);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTrain);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtLine);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtUnit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmReporteIV";
            this.Text = "frmReporteIV";
            ((System.ComponentModel.ISupportInitialize)(this.dgMarcas)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgMarcas_Export)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView dgMarcas;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTrain;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLine;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUnit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.DateTimePicker dtpFin;
        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtServicio;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.CheckBox chkPendientes;
        private System.Windows.Forms.DataGridView dgMarcas_Export;
        private System.Windows.Forms.DateTimePicker dtp;
        private System.Windows.Forms.CheckBox chkSinFecha;
    }
}