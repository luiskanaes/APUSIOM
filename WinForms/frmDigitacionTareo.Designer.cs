namespace WinForms
{
    partial class frmDigitacionTareo
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
            this.lblIDE_TAREO_ASIGNACION = new System.Windows.Forms.Label();
            this.cboCapataces = new System.Windows.Forms.ComboBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cboFile = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.dateTareo = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.cboCentroCosto = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblidTareas = new System.Windows.Forms.Label();
            this.cboEmpresa = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cboIngeniero = new System.Windows.Forms.ComboBox();
            this.lblIdTareo = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnGuardarTareo = new System.Windows.Forms.Button();
            this.gridDetalle = new System.Windows.Forms.DataGridView();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btnAsignar = new System.Windows.Forms.Button();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetalle)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lblIDE_TAREO_ASIGNACION);
            this.groupBox1.Controls.Add(this.cboCapataces);
            this.groupBox1.Controls.Add(this.lblEstado);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cboFile);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.dateTareo);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.cboCentroCosto);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lblidTareas);
            this.groupBox1.Controls.Add(this.cboEmpresa);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.cboIngeniero);
            this.groupBox1.Controls.Add(this.lblIdTareo);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Location = new System.Drawing.Point(4, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1190, 64);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            // 
            // lblIDE_TAREO_ASIGNACION
            // 
            this.lblIDE_TAREO_ASIGNACION.AutoSize = true;
            this.lblIDE_TAREO_ASIGNACION.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblIDE_TAREO_ASIGNACION.Location = new System.Drawing.Point(1113, 43);
            this.lblIDE_TAREO_ASIGNACION.Name = "lblIDE_TAREO_ASIGNACION";
            this.lblIDE_TAREO_ASIGNACION.Size = new System.Drawing.Size(29, 13);
            this.lblIDE_TAREO_ASIGNACION.TabIndex = 46;
            this.lblIDE_TAREO_ASIGNACION.Text = "label";
            this.lblIDE_TAREO_ASIGNACION.Visible = false;
            // 
            // cboCapataces
            // 
            this.cboCapataces.FormattingEnabled = true;
            this.cboCapataces.Location = new System.Drawing.Point(492, 36);
            this.cboCapataces.Name = "cboCapataces";
            this.cboCapataces.Size = new System.Drawing.Size(165, 21);
            this.cboCapataces.TabIndex = 45;
            this.cboCapataces.Visible = false;
            this.cboCapataces.SelectedIndexChanged += new System.EventHandler(this.cboCapataces_SelectedIndexChanged);
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblEstado.Location = new System.Drawing.Point(1113, 23);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(29, 13);
            this.lblEstado.TabIndex = 25;
            this.lblEstado.Text = "label";
            this.lblEstado.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(691, 39);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 44;
            this.label8.Text = "TAREO";
            // 
            // cboFile
            // 
            this.cboFile.FormattingEnabled = true;
            this.cboFile.Location = new System.Drawing.Point(741, 35);
            this.cboFile.Name = "cboFile";
            this.cboFile.Size = new System.Drawing.Size(203, 21);
            this.cboFile.TabIndex = 28;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1065, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "(F4)";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(326, 43);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(167, 13);
            this.label14.TabIndex = 15;
            this.label14.Text = "RESPONSABLE DE CUADRILLA";
            this.label14.Visible = false;
            // 
            // dateTareo
            // 
            this.dateTareo.Location = new System.Drawing.Point(741, 14);
            this.dateTareo.Name = "dateTareo";
            this.dateTareo.Size = new System.Drawing.Size(203, 20);
            this.dateTareo.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(695, 18);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "FECHA";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = global::WinForms.Properties.Resources.boton_buscar;
            this.btnBuscar.Location = new System.Drawing.Point(949, 24);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(110, 30);
            this.btnBuscar.TabIndex = 16;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // cboCentroCosto
            // 
            this.cboCentroCosto.FormattingEnabled = true;
            this.cboCentroCosto.Location = new System.Drawing.Point(257, 14);
            this.cboCentroCosto.Name = "cboCentroCosto";
            this.cboCentroCosto.Size = new System.Drawing.Size(400, 21);
            this.cboCentroCosto.TabIndex = 5;
            this.cboCentroCosto.SelectedIndexChanged += new System.EventHandler(this.cboCentroCosto_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(200, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "C. COSTO";
            // 
            // lblidTareas
            // 
            this.lblidTareas.AutoSize = true;
            this.lblidTareas.Location = new System.Drawing.Point(679, 19);
            this.lblidTareas.Name = "lblidTareas";
            this.lblidTareas.Size = new System.Drawing.Size(13, 13);
            this.lblidTareas.TabIndex = 15;
            this.lblidTareas.Text = "0";
            this.lblidTareas.Visible = false;
            // 
            // cboEmpresa
            // 
            this.cboEmpresa.FormattingEnabled = true;
            this.cboEmpresa.Location = new System.Drawing.Point(71, 15);
            this.cboEmpresa.Name = "cboEmpresa";
            this.cboEmpresa.Size = new System.Drawing.Size(126, 21);
            this.cboEmpresa.TabIndex = 1;
            this.cboEmpresa.SelectedIndexChanged += new System.EventHandler(this.cboEmpresa_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(8, 43);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(126, 13);
            this.label13.TabIndex = 14;
            this.label13.Text = "INGENIERO DE CAMPO";
            this.label13.Visible = false;
            // 
            // cboIngeniero
            // 
            this.cboIngeniero.FormattingEnabled = true;
            this.cboIngeniero.Location = new System.Drawing.Point(140, 40);
            this.cboIngeniero.Name = "cboIngeniero";
            this.cboIngeniero.Size = new System.Drawing.Size(180, 21);
            this.cboIngeniero.TabIndex = 12;
            this.cboIngeniero.Visible = false;
            this.cboIngeniero.SelectedIndexChanged += new System.EventHandler(this.cboIngeniero_SelectedIndexChanged);
            // 
            // lblIdTareo
            // 
            this.lblIdTareo.AutoSize = true;
            this.lblIdTareo.Location = new System.Drawing.Point(660, 19);
            this.lblIdTareo.Name = "lblIdTareo";
            this.lblIdTareo.Size = new System.Drawing.Size(13, 13);
            this.lblIdTareo.TabIndex = 14;
            this.lblIdTareo.Text = "0";
            this.lblIdTareo.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "EMPRESA";
            // 
            // btnGuardarTareo
            // 
            this.btnGuardarTareo.Location = new System.Drawing.Point(173, 71);
            this.btnGuardarTareo.Name = "btnGuardarTareo";
            this.btnGuardarTareo.Size = new System.Drawing.Size(110, 30);
            this.btnGuardarTareo.TabIndex = 36;
            this.btnGuardarTareo.Text = "GUARDAR";
            this.btnGuardarTareo.UseVisualStyleBackColor = true;
            this.btnGuardarTareo.Visible = false;
            this.btnGuardarTareo.Click += new System.EventHandler(this.btnGuardarTareo_Click);
            // 
            // gridDetalle
            // 
            this.gridDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridDetalle.Location = new System.Drawing.Point(4, 102);
            this.gridDetalle.Name = "gridDetalle";
            this.gridDetalle.Size = new System.Drawing.Size(1190, 345);
            this.gridDetalle.TabIndex = 37;
            this.gridDetalle.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridDetalle_CellClick);
            this.gridDetalle.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.gridDetalle_EditingControlShowing);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Enabled = false;
            this.checkBox1.Location = new System.Drawing.Point(953, 79);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(174, 17);
            this.checkBox1.TabIndex = 38;
            this.checkBox1.Text = "VER PLANILLA REGISTRADA";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.Visible = false;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // btnAsignar
            // 
            this.btnAsignar.Location = new System.Drawing.Point(289, 71);
            this.btnAsignar.Name = "btnAsignar";
            this.btnAsignar.Size = new System.Drawing.Size(169, 30);
            this.btnAsignar.TabIndex = 39;
            this.btnAsignar.Text = "ASIGNAR RESPONSABLES";
            this.btnAsignar.UseVisualStyleBackColor = true;
            this.btnAsignar.Visible = false;
            this.btnAsignar.Click += new System.EventHandler(this.btnAsignar_Click);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(32, 80);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(135, 17);
            this.checkBox2.TabIndex = 64;
            this.checkBox2.Text = "SELECCIONAR TODO";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.Visible = false;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // frmDigitacionTareo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1206, 454);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.btnAsignar);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.gridDetalle);
            this.Controls.Add(this.btnGuardarTareo);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmDigitacionTareo";
            this.Text = "frmDigitacionTareo";
            this.Load += new System.EventHandler(this.frmDigitacionTareo_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetalle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DateTimePicker dateTareo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.ComboBox cboCentroCosto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblidTareas;
        private System.Windows.Forms.ComboBox cboEmpresa;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cboIngeniero;
        private System.Windows.Forms.Label lblIdTareo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Button btnGuardarTareo;
        private System.Windows.Forms.DataGridView gridDetalle;
        private System.Windows.Forms.ComboBox cboCapataces;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label lblIDE_TAREO_ASIGNACION;
        private System.Windows.Forms.Button btnAsignar;
        private System.Windows.Forms.CheckBox checkBox2;
    }
}