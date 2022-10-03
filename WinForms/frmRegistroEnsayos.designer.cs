namespace WinForms
{
    partial class frmRegistroEnsayos
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
            this.btnExportar = new System.Windows.Forms.Button();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.dgMarcas = new System.Windows.Forms.DataGridView();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.cboFiltro = new System.Windows.Forms.ComboBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbRadiografias = new System.Windows.Forms.RadioButton();
            this.rbDureza = new System.Windows.Forms.RadioButton();
            this.rbOtros = new System.Windows.Forms.RadioButton();
            this.lblTitulo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgMarcas)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtServicio
            // 
            this.txtServicio.Location = new System.Drawing.Point(219, 50);
            this.txtServicio.Name = "txtServicio";
            this.txtServicio.Size = new System.Drawing.Size(49, 20);
            this.txtServicio.TabIndex = 31;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(153, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 37;
            this.label5.Text = "SERVICIO:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(46, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(268, 25);
            this.label4.TabIndex = 36;
            this.label4.Text = "REGISTRO DE ENSAYOS";
            // 
            // txtTrain
            // 
            this.txtTrain.Location = new System.Drawing.Point(415, 50);
            this.txtTrain.Name = "txtTrain";
            this.txtTrain.Size = new System.Drawing.Size(49, 20);
            this.txtTrain.TabIndex = 35;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(369, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 34;
            this.label3.Text = "TRAIN:";
            // 
            // txtLine
            // 
            this.txtLine.Location = new System.Drawing.Point(314, 50);
            this.txtLine.Name = "txtLine";
            this.txtLine.Size = new System.Drawing.Size(49, 20);
            this.txtLine.TabIndex = 33;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(274, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 32;
            this.label2.Text = "LINE:";
            // 
            // txtUnit
            // 
            this.txtUnit.Location = new System.Drawing.Point(98, 50);
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.Size = new System.Drawing.Size(49, 20);
            this.txtUnit.TabIndex = 30;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "UNIT:";
            // 
            // btnExportar
            // 
            this.btnExportar.Location = new System.Drawing.Point(1077, 58);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(110, 33);
            this.btnExportar.TabIndex = 28;
            this.btnExportar.Text = "EXPORTAR";
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.Location = new System.Drawing.Point(961, 58);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(110, 33);
            this.btnGrabar.TabIndex = 26;
            this.btnGrabar.Text = "GRABAR";
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // dgMarcas
            // 
            this.dgMarcas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgMarcas.Location = new System.Drawing.Point(12, 120);
            this.dgMarcas.Name = "dgMarcas";
            this.dgMarcas.Size = new System.Drawing.Size(1338, 467);
            this.dgMarcas.TabIndex = 25;
            this.dgMarcas.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgMarcas_CellValidating);
            this.dgMarcas.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgMarcas_CellValueChanged);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(845, 58);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(110, 33);
            this.btnBuscar.TabIndex = 24;
            this.btnBuscar.Text = "BUSCAR";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtFiltro
            // 
            this.txtFiltro.Location = new System.Drawing.Point(251, 82);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(213, 20);
            this.txtFiltro.TabIndex = 46;
            // 
            // cboFiltro
            // 
            this.cboFiltro.FormattingEnabled = true;
            this.cboFiltro.Location = new System.Drawing.Point(51, 81);
            this.cboFiltro.Name = "cboFiltro";
            this.cboFiltro.Size = new System.Drawing.Size(182, 21);
            this.cboFiltro.TabIndex = 45;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(12, 602);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(99, 25);
            this.lblTotal.TabIndex = 47;
            this.lblTotal.Text = "TOTAL: ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbOtros);
            this.groupBox1.Controls.Add(this.rbDureza);
            this.groupBox1.Controls.Add(this.rbRadiografias);
            this.groupBox1.Location = new System.Drawing.Point(488, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(328, 52);
            this.groupBox1.TabIndex = 48;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "TIPO DE ENSAYO A DIGITAR";
            // 
            // rbRadiografias
            // 
            this.rbRadiografias.AutoSize = true;
            this.rbRadiografias.Checked = true;
            this.rbRadiografias.Location = new System.Drawing.Point(15, 24);
            this.rbRadiografias.Name = "rbRadiografias";
            this.rbRadiografias.Size = new System.Drawing.Size(105, 17);
            this.rbRadiografias.TabIndex = 0;
            this.rbRadiografias.TabStop = true;
            this.rbRadiografias.Text = "RADIOGRAFIAS";
            this.rbRadiografias.UseVisualStyleBackColor = true;
            this.rbRadiografias.Click += new System.EventHandler(this.rbRadiografias_Click);
            // 
            // rbDureza
            // 
            this.rbDureza.AutoSize = true;
            this.rbDureza.Location = new System.Drawing.Point(133, 24);
            this.rbDureza.Name = "rbDureza";
            this.rbDureza.Size = new System.Drawing.Size(97, 17);
            this.rbDureza.TabIndex = 1;
            this.rbDureza.Text = "DUREZA Y TT";
            this.rbDureza.UseVisualStyleBackColor = true;
            this.rbDureza.Click += new System.EventHandler(this.rbDureza_Click);
            // 
            // rbOtros
            // 
            this.rbOtros.AutoSize = true;
            this.rbOtros.Location = new System.Drawing.Point(236, 24);
            this.rbOtros.Name = "rbOtros";
            this.rbOtros.Size = new System.Drawing.Size(63, 17);
            this.rbOtros.TabIndex = 2;
            this.rbOtros.Text = "OTROS";
            this.rbOtros.UseVisualStyleBackColor = true;
            this.rbOtros.Click += new System.EventHandler(this.rbOtros_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(309, 12);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(173, 25);
            this.lblTitulo.TabIndex = 49;
            this.lblTitulo.Text = "RADIOGRAFIAS";
            // 
            // frmRegistroEnsayos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1359, 716);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.txtFiltro);
            this.Controls.Add(this.cboFiltro);
            this.Controls.Add(this.txtServicio);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTrain);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtLine);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtUnit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.dgMarcas);
            this.Controls.Add(this.btnBuscar);
            this.Name = "frmRegistroEnsayos";
            this.Text = "frmRegistroEnsayos";
            ((System.ComponentModel.ISupportInitialize)(this.dgMarcas)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.DataGridView dgMarcas;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtFiltro;
        private System.Windows.Forms.ComboBox cboFiltro;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbOtros;
        private System.Windows.Forms.RadioButton rbDureza;
        private System.Windows.Forms.RadioButton rbRadiografias;
        private System.Windows.Forms.Label lblTitulo;
    }
}