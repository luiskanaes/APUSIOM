namespace WinForms.RRHH
{
    partial class frmRegistroDescansoMedicoDni
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboUbicacion = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblDiasSub = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblDiasDm = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtUbi = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCat = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFecIng = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFecNac = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.LBL_PERSONAL = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblDias = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cboTipoIncidencia = new System.Windows.Forms.ComboBox();
            this.cboTipoDescanso = new System.Windows.Forms.ComboBox();
            this.dtpFin = new System.Windows.Forms.DateTimePicker();
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.btnSustento = new System.Windows.Forms.Button();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.txtObs = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.gbLista = new System.Windows.Forms.GroupBox();
            this.dgDescansos = new System.Windows.Forms.DataGridView();
            this.txtFileToImport = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.gbLista.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDescansos)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cboUbicacion);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtDni);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(57, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1162, 227);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DATOS DEL COLABORADOR";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(392, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "UBICACION:";
            // 
            // cboUbicacion
            // 
            this.cboUbicacion.FormattingEnabled = true;
            this.cboUbicacion.Location = new System.Drawing.Point(476, 33);
            this.cboUbicacion.Name = "cboUbicacion";
            this.cboUbicacion.Size = new System.Drawing.Size(359, 21);
            this.cboUbicacion.TabIndex = 15;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.txtUbi);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtCat);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtFecIng);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtFecNac);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.LBL_PERSONAL);
            this.groupBox2.Location = new System.Drawing.Point(31, 73);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1125, 137);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "RESULTADO";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lblDiasSub);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.lblDiasDm);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Location = new System.Drawing.Point(752, 19);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(265, 112);
            this.groupBox4.TabIndex = 25;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "HISTORICO DESCANSO MEDICO";
            // 
            // lblDiasSub
            // 
            this.lblDiasSub.AutoSize = true;
            this.lblDiasSub.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiasSub.Location = new System.Drawing.Point(168, 74);
            this.lblDiasSub.Name = "lblDiasSub";
            this.lblDiasSub.Size = new System.Drawing.Size(50, 15);
            this.lblDiasSub.TabIndex = 27;
            this.lblDiasSub.Text = "0 DIAS";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(35, 74);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(127, 15);
            this.label16.TabIndex = 26;
            this.label16.Text = "NRO DIAS SUBCIDIO:";
            // 
            // lblDiasDm
            // 
            this.lblDiasDm.AutoSize = true;
            this.lblDiasDm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiasDm.Location = new System.Drawing.Point(168, 32);
            this.lblDiasDm.Name = "lblDiasDm";
            this.lblDiasDm.Size = new System.Drawing.Size(50, 15);
            this.lblDiasDm.TabIndex = 25;
            this.lblDiasDm.Text = "0 DIAS";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(35, 32);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(90, 15);
            this.label14.TabIndex = 24;
            this.label14.Text = "NRO DIAS DM:";
            // 
            // txtUbi
            // 
            this.txtUbi.Location = new System.Drawing.Point(535, 88);
            this.txtUbi.Name = "txtUbi";
            this.txtUbi.Size = new System.Drawing.Size(165, 20);
            this.txtUbi.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(403, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "CENTRO DE COSTO:";
            // 
            // txtCat
            // 
            this.txtCat.Location = new System.Drawing.Point(149, 85);
            this.txtCat.Name = "txtCat";
            this.txtCat.Size = new System.Drawing.Size(165, 20);
            this.txtCat.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(61, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "CATEGORIA:";
            // 
            // txtFecIng
            // 
            this.txtFecIng.Location = new System.Drawing.Point(533, 55);
            this.txtFecIng.Name = "txtFecIng";
            this.txtFecIng.Size = new System.Drawing.Size(165, 20);
            this.txtFecIng.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(420, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "FECHA INGRESO:";
            // 
            // txtFecNac
            // 
            this.txtFecNac.Location = new System.Drawing.Point(149, 51);
            this.txtFecNac.Name = "txtFecNac";
            this.txtFecNac.Size = new System.Drawing.Size(165, 20);
            this.txtFecNac.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(61, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "FECHA NAC:";
            // 
            // LBL_PERSONAL
            // 
            this.LBL_PERSONAL.AutoSize = true;
            this.LBL_PERSONAL.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_PERSONAL.Location = new System.Drawing.Point(61, 19);
            this.LBL_PERSONAL.Name = "LBL_PERSONAL";
            this.LBL_PERSONAL.Size = new System.Drawing.Size(52, 17);
            this.LBL_PERSONAL.TabIndex = 0;
            this.LBL_PERSONAL.Text = "label2";
            this.LBL_PERSONAL.Visible = false;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(897, 19);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(151, 40);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "BUSCAR";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "DOCUMENTO IDENTIDAD:";
            // 
            // txtDni
            // 
            this.txtDni.Location = new System.Drawing.Point(196, 33);
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(165, 20);
            this.txtDni.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblDias);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.cboTipoIncidencia);
            this.groupBox3.Controls.Add(this.cboTipoDescanso);
            this.groupBox3.Controls.Add(this.dtpFin);
            this.groupBox3.Controls.Add(this.dtpInicio);
            this.groupBox3.Controls.Add(this.btnSustento);
            this.groupBox3.Controls.Add(this.btnGrabar);
            this.groupBox3.Controls.Add(this.txtObs);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(57, 245);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1162, 194);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "REGISTRO DE DESCANSO MEDICO";
            // 
            // lblDias
            // 
            this.lblDias.AutoSize = true;
            this.lblDias.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDias.Location = new System.Drawing.Point(364, 46);
            this.lblDias.Name = "lblDias";
            this.lblDias.Size = new System.Drawing.Size(19, 20);
            this.lblDias.TabIndex = 24;
            this.lblDias.Text = "1";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(284, 48);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(78, 17);
            this.label13.TabIndex = 23;
            this.label13.Text = "NRO DIAS:";
            // 
            // cboTipoIncidencia
            // 
            this.cboTipoIncidencia.FormattingEnabled = true;
            this.cboTipoIncidencia.Location = new System.Drawing.Point(602, 67);
            this.cboTipoIncidencia.Name = "cboTipoIncidencia";
            this.cboTipoIncidencia.Size = new System.Drawing.Size(281, 21);
            this.cboTipoIncidencia.TabIndex = 22;
            // 
            // cboTipoDescanso
            // 
            this.cboTipoDescanso.FormattingEnabled = true;
            this.cboTipoDescanso.Location = new System.Drawing.Point(602, 25);
            this.cboTipoDescanso.Name = "cboTipoDescanso";
            this.cboTipoDescanso.Size = new System.Drawing.Size(281, 21);
            this.cboTipoDescanso.TabIndex = 21;
            // 
            // dtpFin
            // 
            this.dtpFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFin.Location = new System.Drawing.Point(160, 64);
            this.dtpFin.Name = "dtpFin";
            this.dtpFin.Size = new System.Drawing.Size(102, 20);
            this.dtpFin.TabIndex = 20;
            this.dtpFin.ValueChanged += new System.EventHandler(this.dtpFin_ValueChanged);
            this.dtpFin.Leave += new System.EventHandler(this.dtpFin_Leave);
            // 
            // dtpInicio
            // 
            this.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInicio.Location = new System.Drawing.Point(160, 27);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.Size = new System.Drawing.Size(102, 20);
            this.dtpInicio.TabIndex = 19;
            this.dtpInicio.ValueChanged += new System.EventHandler(this.dtpInicio_ValueChanged);
            this.dtpInicio.Leave += new System.EventHandler(this.dateTimePicker1_Leave);
            // 
            // btnSustento
            // 
            this.btnSustento.Location = new System.Drawing.Point(160, 144);
            this.btnSustento.Name = "btnSustento";
            this.btnSustento.Size = new System.Drawing.Size(320, 31);
            this.btnSustento.TabIndex = 18;
            this.btnSustento.Text = "SUSTENTO .....";
            this.btnSustento.UseVisualStyleBackColor = true;
            this.btnSustento.Click += new System.EventHandler(this.btnSustento_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.Location = new System.Drawing.Point(937, 45);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(164, 61);
            this.btnGrabar.TabIndex = 17;
            this.btnGrabar.Text = "GRABAR";
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Visible = false;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // txtObs
            // 
            this.txtObs.Location = new System.Drawing.Point(163, 111);
            this.txtObs.Name = "txtObs";
            this.txtObs.Size = new System.Drawing.Size(720, 20);
            this.txtObs.TabIndex = 17;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(28, 151);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(75, 15);
            this.label12.TabIndex = 16;
            this.label12.Text = "SUSTENTO:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(31, 111);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(111, 15);
            this.label11.TabIndex = 15;
            this.label11.Text = "OBSERVACIONES:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(473, 67);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(107, 15);
            this.label10.TabIndex = 14;
            this.label10.Text = "TIPO INCIDENCIA:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(473, 26);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(106, 15);
            this.label9.TabIndex = 13;
            this.label9.Text = "TIPO DESCANSO:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(31, 68);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 15);
            this.label8.TabIndex = 12;
            this.label8.Text = "FECHA FIN:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(28, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 15);
            this.label7.TabIndex = 11;
            this.label7.Text = "FECHA INICIO:";
            // 
            // gbLista
            // 
            this.gbLista.Controls.Add(this.dgDescansos);
            this.gbLista.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbLista.Location = new System.Drawing.Point(57, 445);
            this.gbLista.Name = "gbLista";
            this.gbLista.Size = new System.Drawing.Size(1162, 213);
            this.gbLista.TabIndex = 2;
            this.gbLista.TabStop = false;
            this.gbLista.Text = "DESCANSOS MEDICOS HISTORICOS ";
            this.gbLista.Visible = false;
            // 
            // dgDescansos
            // 
            this.dgDescansos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDescansos.Location = new System.Drawing.Point(26, 19);
            this.dgDescansos.Name = "dgDescansos";
            this.dgDescansos.Size = new System.Drawing.Size(1116, 169);
            this.dgDescansos.TabIndex = 0;
            // 
            // txtFileToImport
            // 
            this.txtFileToImport.Location = new System.Drawing.Point(1237, 245);
            this.txtFileToImport.Name = "txtFileToImport";
            this.txtFileToImport.Size = new System.Drawing.Size(33, 20);
            this.txtFileToImport.TabIndex = 3;
            this.txtFileToImport.Visible = false;
            // 
            // frmRegistroDescansoMedicoDni
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1282, 753);
            this.Controls.Add(this.txtFileToImport);
            this.Controls.Add(this.gbLista);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmRegistroDescansoMedicoDni";
            this.Text = "frmRegistroDescansoMedicoDni";
            this.Load += new System.EventHandler(this.frmRegistroDescansoMedicoDni_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.gbLista.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgDescansos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtUbi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCat;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFecIng;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFecNac;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LBL_PERSONAL;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboUbicacion;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lblDiasSub;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblDiasDm;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblDias;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cboTipoIncidencia;
        private System.Windows.Forms.ComboBox cboTipoDescanso;
        private System.Windows.Forms.DateTimePicker dtpFin;
        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.Button btnSustento;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.TextBox txtObs;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox gbLista;
        private System.Windows.Forms.DataGridView dgDescansos;
        private System.Windows.Forms.TextBox txtFileToImport;
    }
}