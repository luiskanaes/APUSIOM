namespace WinForms
{
    partial class frmReporteEnsayosPendientes
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
            this.chkValidoProgramar = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chkSinFecha = new System.Windows.Forms.CheckBox();
            this.chkSoloValidos = new System.Windows.Forms.CheckBox();
            this.dtpFin = new System.Windows.Forms.DateTimePicker();
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtGrupo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUnidadMedida = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCodigoSiom = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExportar = new System.Windows.Forms.Button();
            this.dtp = new System.Windows.Forms.DateTimePicker();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.dgMarcas = new System.Windows.Forms.DataGridView();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgMarcas)).BeginInit();
            this.SuspendLayout();
            // 
            // chkValidoProgramar
            // 
            this.chkValidoProgramar.AutoSize = true;
            this.chkValidoProgramar.Location = new System.Drawing.Point(1134, 70);
            this.chkValidoProgramar.Name = "chkValidoProgramar";
            this.chkValidoProgramar.Size = new System.Drawing.Size(195, 17);
            this.chkValidoProgramar.TabIndex = 63;
            this.chkValidoProgramar.Text = "VALIDO PARA PROGRAMAR HTP";
            this.chkValidoProgramar.UseVisualStyleBackColor = true;
            this.chkValidoProgramar.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(32, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(337, 25);
            this.label5.TabIndex = 61;
            this.label5.Text = "HISTORICO DE COTIZACIONES";
            // 
            // chkSinFecha
            // 
            this.chkSinFecha.AutoSize = true;
            this.chkSinFecha.Checked = true;
            this.chkSinFecha.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSinFecha.Location = new System.Drawing.Point(14, 22);
            this.chkSinFecha.Name = "chkSinFecha";
            this.chkSinFecha.Size = new System.Drawing.Size(156, 17);
            this.chkSinFecha.TabIndex = 44;
            this.chkSinFecha.Text = "SIN CONSIDERAR FECHA";
            this.chkSinFecha.UseVisualStyleBackColor = true;
            // 
            // chkSoloValidos
            // 
            this.chkSoloValidos.AutoSize = true;
            this.chkSoloValidos.Checked = true;
            this.chkSoloValidos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSoloValidos.Location = new System.Drawing.Point(186, 15);
            this.chkSoloValidos.Name = "chkSoloValidos";
            this.chkSoloValidos.Size = new System.Drawing.Size(104, 17);
            this.chkSoloValidos.TabIndex = 45;
            this.chkSoloValidos.Text = "SOLO VALIDOS";
            this.chkSoloValidos.UseVisualStyleBackColor = true;
            this.chkSoloValidos.Visible = false;
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
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(12, 636);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(99, 25);
            this.lblTotal.TabIndex = 62;
            this.lblTotal.Text = "TOTAL: ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkSinFecha);
            this.groupBox1.Controls.Add(this.chkSoloValidos);
            this.groupBox1.Controls.Add(this.dtpFin);
            this.groupBox1.Controls.Add(this.dtpInicio);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Location = new System.Drawing.Point(1023, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(327, 81);
            this.groupBox1.TabIndex = 60;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "FECHA SOLDADURA";
            this.groupBox1.Visible = false;
            // 
            // txtGrupo
            // 
            this.txtGrupo.Location = new System.Drawing.Point(248, 61);
            this.txtGrupo.Name = "txtGrupo";
            this.txtGrupo.Size = new System.Drawing.Size(71, 20);
            this.txtGrupo.TabIndex = 56;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(193, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 55;
            this.label4.Text = "GRUPO:";
            // 
            // txtUnidadMedida
            // 
            this.txtUnidadMedida.Location = new System.Drawing.Point(580, 61);
            this.txtUnidadMedida.Name = "txtUnidadMedida";
            this.txtUnidadMedida.Size = new System.Drawing.Size(74, 20);
            this.txtUnidadMedida.TabIndex = 58;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(486, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 13);
            this.label3.TabIndex = 54;
            this.label3.Text = "UNIDAD MEDIDA:";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(405, 61);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(75, 20);
            this.txtDescripcion.TabIndex = 57;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(325, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 53;
            this.label2.Text = "DESCRIPCION:";
            // 
            // txtCodigoSiom
            // 
            this.txtCodigoSiom.Location = new System.Drawing.Point(99, 61);
            this.txtCodigoSiom.Name = "txtCodigoSiom";
            this.txtCodigoSiom.Size = new System.Drawing.Size(88, 20);
            this.txtCodigoSiom.TabIndex = 52;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 51;
            this.label1.Text = "CODIGO SIOM:";
            // 
            // btnExportar
            // 
            this.btnExportar.Location = new System.Drawing.Point(892, 54);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(110, 33);
            this.btnExportar.TabIndex = 50;
            this.btnExportar.Text = "EXPORTAR";
            this.btnExportar.UseVisualStyleBackColor = true;
            // 
            // dtp
            // 
            this.dtp.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp.Location = new System.Drawing.Point(12, 147);
            this.dtp.Name = "dtp";
            this.dtp.Size = new System.Drawing.Size(113, 20);
            this.dtp.TabIndex = 49;
            this.dtp.Visible = false;
            // 
            // btnGrabar
            // 
            this.btnGrabar.Location = new System.Drawing.Point(776, 54);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(110, 33);
            this.btnGrabar.TabIndex = 48;
            this.btnGrabar.Text = "GRABAR";
            this.btnGrabar.UseVisualStyleBackColor = true;
            // 
            // dgMarcas
            // 
            this.dgMarcas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgMarcas.Location = new System.Drawing.Point(12, 108);
            this.dgMarcas.Name = "dgMarcas";
            this.dgMarcas.Size = new System.Drawing.Size(1338, 519);
            this.dgMarcas.TabIndex = 47;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(660, 54);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(110, 33);
            this.btnBuscar.TabIndex = 59;
            this.btnBuscar.Text = "BUSCAR";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click_1);
            // 
            // frmReporteEnsayosPendientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1406, 717);
            this.Controls.Add(this.chkValidoProgramar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtGrupo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtUnidadMedida);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCodigoSiom);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.dtp);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.dgMarcas);
            this.Controls.Add(this.btnBuscar);
            this.Name = "frmReporteEnsayosPendientes";
            this.Text = "frmReporteEnsayosPendientes";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgMarcas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cboTipoEnsayo;
        private System.Windows.Forms.CheckBox chkValidoProgramar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkSinFecha;
        private System.Windows.Forms.CheckBox chkSoloValidos;
        private System.Windows.Forms.DateTimePicker dtpFin;
        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtGrupo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUnidadMedida;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCodigoSiom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.DateTimePicker dtp;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.DataGridView dgMarcas;
        private System.Windows.Forms.Button btnBuscar;
    }
}