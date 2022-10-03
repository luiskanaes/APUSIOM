namespace WinForms
{
    partial class frmReporteSoldaduras
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
            this.txtTrain = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLine = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUnit = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExportar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.dgMarcas = new System.Windows.Forms.DataGridView();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.dtpFin = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkSinFechaSoldadura = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkSinFechaIV = new System.Windows.Forms.CheckBox();
            this.dtpFecFinIV = new System.Windows.Forms.DateTimePicker();
            this.dtpFecIniIV = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtServicio = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkSinFechaReporte = new System.Windows.Forms.CheckBox();
            this.dtpFecFinReporte = new System.Windows.Forms.DateTimePicker();
            this.dtpFecIniReporte = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btnGrabar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgMarcas)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTrain
            // 
            this.txtTrain.Location = new System.Drawing.Point(310, 75);
            this.txtTrain.Name = "txtTrain";
            this.txtTrain.Size = new System.Drawing.Size(69, 20);
            this.txtTrain.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(245, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "TRAIN:";
            // 
            // txtLine
            // 
            this.txtLine.Location = new System.Drawing.Point(169, 75);
            this.txtLine.Name = "txtLine";
            this.txtLine.Size = new System.Drawing.Size(69, 20);
            this.txtLine.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(135, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "LINE:";
            // 
            // txtUnit
            // 
            this.txtUnit.Location = new System.Drawing.Point(169, 47);
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.Size = new System.Drawing.Size(69, 20);
            this.txtUnit.TabIndex = 13;
            this.txtUnit.Tag = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(133, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "UNIT:";
            // 
            // btnExportar
            // 
            this.btnExportar.Location = new System.Drawing.Point(1198, 56);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(110, 33);
            this.btnExportar.TabIndex = 11;
            this.btnExportar.Text = "EXPORTAR";
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(39, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(350, 25);
            this.label4.TabIndex = 18;
            this.label4.Text = "REPORTE DE SOLDADURAS TRT";
            // 
            // dgMarcas
            // 
            this.dgMarcas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgMarcas.Location = new System.Drawing.Point(13, 104);
            this.dgMarcas.Name = "dgMarcas";
            this.dgMarcas.Size = new System.Drawing.Size(1321, 480);
            this.dgMarcas.TabIndex = 19;
            this.dgMarcas.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgMarcas_CellValidating);
            this.dgMarcas.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgMarcas_CellValueChanged);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(1068, 29);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(110, 49);
            this.btnBuscar.TabIndex = 20;
            this.btnBuscar.Text = "BUSCAR";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "INICIO:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(113, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = "FIN:";
            // 
            // dtpInicio
            // 
            this.dtpInicio.CustomFormat = "dd/MM/yyyy";
            this.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpInicio.Location = new System.Drawing.Point(6, 59);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.Size = new System.Drawing.Size(93, 20);
            this.dtpInicio.TabIndex = 24;
            // 
            // dtpFin
            // 
            this.dtpFin.CustomFormat = "dd/MM/yyyy";
            this.dtpFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFin.Location = new System.Drawing.Point(116, 59);
            this.dtpFin.Name = "dtpFin";
            this.dtpFin.Size = new System.Drawing.Size(80, 20);
            this.dtpFin.TabIndex = 25;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkSinFechaSoldadura);
            this.groupBox1.Controls.Add(this.dtpFin);
            this.groupBox1.Controls.Add(this.dtpInicio);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Location = new System.Drawing.Point(402, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(208, 94);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "FECHA SOLDADURA";
            // 
            // chkSinFechaSoldadura
            // 
            this.chkSinFechaSoldadura.AutoSize = true;
            this.chkSinFechaSoldadura.Location = new System.Drawing.Point(11, 19);
            this.chkSinFechaSoldadura.Name = "chkSinFechaSoldadura";
            this.chkSinFechaSoldadura.Size = new System.Drawing.Size(156, 17);
            this.chkSinFechaSoldadura.TabIndex = 26;
            this.chkSinFechaSoldadura.Text = "SIN CONSIDERAR FECHA";
            this.chkSinFechaSoldadura.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkSinFechaIV);
            this.groupBox2.Controls.Add(this.dtpFecFinIV);
            this.groupBox2.Controls.Add(this.dtpFecIniIV);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(627, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(204, 94);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "FECHA IV";
            // 
            // chkSinFechaIV
            // 
            this.chkSinFechaIV.AutoSize = true;
            this.chkSinFechaIV.Location = new System.Drawing.Point(6, 17);
            this.chkSinFechaIV.Name = "chkSinFechaIV";
            this.chkSinFechaIV.Size = new System.Drawing.Size(156, 17);
            this.chkSinFechaIV.TabIndex = 26;
            this.chkSinFechaIV.Text = "SIN CONSIDERAR FECHA";
            this.chkSinFechaIV.UseVisualStyleBackColor = true;
            // 
            // dtpFecFinIV
            // 
            this.dtpFecFinIV.CustomFormat = "dd/MM/yyyy";
            this.dtpFecFinIV.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecFinIV.Location = new System.Drawing.Point(109, 59);
            this.dtpFecFinIV.Name = "dtpFecFinIV";
            this.dtpFecFinIV.Size = new System.Drawing.Size(80, 20);
            this.dtpFecFinIV.TabIndex = 25;
            // 
            // dtpFecIniIV
            // 
            this.dtpFecIniIV.CustomFormat = "dd/MM/yyyy";
            this.dtpFecIniIV.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecIniIV.Location = new System.Drawing.Point(6, 59);
            this.dtpFecIniIV.Name = "dtpFecIniIV";
            this.dtpFecIniIV.Size = new System.Drawing.Size(93, 20);
            this.dtpFecIniIV.TabIndex = 24;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "INICIO:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(108, 42);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(27, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "FIN:";
            // 
            // txtServicio
            // 
            this.txtServicio.Location = new System.Drawing.Point(309, 47);
            this.txtServicio.Name = "txtServicio";
            this.txtServicio.Size = new System.Drawing.Size(69, 20);
            this.txtServicio.TabIndex = 14;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(247, 51);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 13);
            this.label9.TabIndex = 28;
            this.label9.Text = "SERVICIO:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkSinFechaReporte);
            this.groupBox3.Controls.Add(this.dtpFecFinReporte);
            this.groupBox3.Controls.Add(this.dtpFecIniReporte);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Location = new System.Drawing.Point(849, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(204, 94);
            this.groupBox3.TabIndex = 28;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "FECHA REPORTE";
            // 
            // chkSinFechaReporte
            // 
            this.chkSinFechaReporte.AutoSize = true;
            this.chkSinFechaReporte.Location = new System.Drawing.Point(6, 17);
            this.chkSinFechaReporte.Name = "chkSinFechaReporte";
            this.chkSinFechaReporte.Size = new System.Drawing.Size(156, 17);
            this.chkSinFechaReporte.TabIndex = 26;
            this.chkSinFechaReporte.Text = "SIN CONSIDERAR FECHA";
            this.chkSinFechaReporte.UseVisualStyleBackColor = true;
            // 
            // dtpFecFinReporte
            // 
            this.dtpFecFinReporte.CustomFormat = "dd/MM/yyyy";
            this.dtpFecFinReporte.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecFinReporte.Location = new System.Drawing.Point(109, 59);
            this.dtpFecFinReporte.Name = "dtpFecFinReporte";
            this.dtpFecFinReporte.Size = new System.Drawing.Size(80, 20);
            this.dtpFecFinReporte.TabIndex = 25;
            // 
            // dtpFecIniReporte
            // 
            this.dtpFecIniReporte.CustomFormat = "dd/MM/yyyy";
            this.dtpFecIniReporte.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecIniReporte.Location = new System.Drawing.Point(6, 59);
            this.dtpFecIniReporte.Name = "dtpFecIniReporte";
            this.dtpFecIniReporte.Size = new System.Drawing.Size(93, 20);
            this.dtpFecIniReporte.TabIndex = 24;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(4, 42);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "INICIO:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(108, 42);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(27, 13);
            this.label11.TabIndex = 23;
            this.label11.Text = "FIN:";
            // 
            // btnGrabar
            // 
            this.btnGrabar.Location = new System.Drawing.Point(1197, 18);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(110, 33);
            this.btnGrabar.TabIndex = 29;
            this.btnGrabar.Text = "GRABAR";
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // frmReporteSoldaduras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1354, 723);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.txtServicio);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
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
            this.Name = "frmReporteSoldaduras";
            this.Text = "frmReporteSoldaduras";
            ((System.ComponentModel.ISupportInitialize)(this.dgMarcas)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTrain;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLine;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUnit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgMarcas;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.DateTimePicker dtpFin;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkSinFechaSoldadura;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkSinFechaIV;
        private System.Windows.Forms.DateTimePicker dtpFecFinIV;
        private System.Windows.Forms.DateTimePicker dtpFecIniIV;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtServicio;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chkSinFechaReporte;
        private System.Windows.Forms.DateTimePicker dtpFecFinReporte;
        private System.Windows.Forms.DateTimePicker dtpFecIniReporte;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnGrabar;
    }
}