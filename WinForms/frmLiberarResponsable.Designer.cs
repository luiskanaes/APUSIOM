namespace WinForms
{
    partial class frmLiberarResponsable
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
            this.label2 = new System.Windows.Forms.Label();
            this.cboCategoria = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboPersonal = new System.Windows.Forms.ComboBox();
            this.rdoObreros = new System.Windows.Forms.RadioButton();
            this.rdoEmpleado = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.cboNuevoEncargado = new System.Windows.Forms.ComboBox();
            this.dateTareo = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvCuadrilla = new System.Windows.Forms.DataGridView();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dateFechaAsigna = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnListar = new System.Windows.Forms.Button();
            this.dgvNuevo = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.btnSeleccionar = new System.Windows.Forms.Button();
            this.lblmsj1 = new System.Windows.Forms.Label();
            this.lblmsj2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuadrilla)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNuevo)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(2, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(885, 23);
            this.label2.TabIndex = 23;
            this.label2.Text = "Liberar personal (Asignación)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboCategoria
            // 
            this.cboCategoria.FormattingEnabled = true;
            this.cboCategoria.Location = new System.Drawing.Point(140, 13);
            this.cboCategoria.Name = "cboCategoria";
            this.cboCategoria.Size = new System.Drawing.Size(261, 21);
            this.cboCategoria.TabIndex = 49;
            this.cboCategoria.SelectedIndexChanged += new System.EventHandler(this.cboCategoria_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(65, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 48;
            this.label6.Text = "CATEGORIA";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 13);
            this.label1.TabIndex = 50;
            this.label1.Text = "PERSONAL A RETIRAR";
            // 
            // cboPersonal
            // 
            this.cboPersonal.FormattingEnabled = true;
            this.cboPersonal.Location = new System.Drawing.Point(140, 35);
            this.cboPersonal.Name = "cboPersonal";
            this.cboPersonal.Size = new System.Drawing.Size(261, 21);
            this.cboPersonal.TabIndex = 51;
            this.cboPersonal.SelectedIndexChanged += new System.EventHandler(this.cboPersonal_SelectedIndexChanged);
            // 
            // rdoObreros
            // 
            this.rdoObreros.AutoSize = true;
            this.rdoObreros.Location = new System.Drawing.Point(234, 13);
            this.rdoObreros.Name = "rdoObreros";
            this.rdoObreros.Size = new System.Drawing.Size(78, 17);
            this.rdoObreros.TabIndex = 57;
            this.rdoObreros.Text = "OBREROS";
            this.rdoObreros.UseVisualStyleBackColor = true;
            this.rdoObreros.CheckedChanged += new System.EventHandler(this.rdoObreros_CheckedChanged);
            // 
            // rdoEmpleado
            // 
            this.rdoEmpleado.AutoSize = true;
            this.rdoEmpleado.Checked = true;
            this.rdoEmpleado.Location = new System.Drawing.Point(133, 13);
            this.rdoEmpleado.Name = "rdoEmpleado";
            this.rdoEmpleado.Size = new System.Drawing.Size(91, 17);
            this.rdoEmpleado.TabIndex = 56;
            this.rdoEmpleado.TabStop = true;
            this.rdoEmpleado.Text = "EMPLEADOS";
            this.rdoEmpleado.UseVisualStyleBackColor = true;
            this.rdoEmpleado.CheckedChanged += new System.EventHandler(this.rdoEmpleado_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 13);
            this.label3.TabIndex = 58;
            this.label3.Text = "ASIGNAR CARGO A :";
            // 
            // cboNuevoEncargado
            // 
            this.cboNuevoEncargado.FormattingEnabled = true;
            this.cboNuevoEncargado.Location = new System.Drawing.Point(134, 33);
            this.cboNuevoEncargado.Name = "cboNuevoEncargado";
            this.cboNuevoEncargado.Size = new System.Drawing.Size(266, 21);
            this.cboNuevoEncargado.TabIndex = 59;
            this.cboNuevoEncargado.SelectedIndexChanged += new System.EventHandler(this.cboNuevoEncargado_SelectedIndexChanged);
            // 
            // dateTareo
            // 
            this.dateTareo.Location = new System.Drawing.Point(140, 59);
            this.dateTareo.Name = "dateTareo";
            this.dateTareo.Size = new System.Drawing.Size(261, 20);
            this.dateTareo.TabIndex = 61;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 13);
            this.label4.TabIndex = 62;
            this.label4.Text = "FECHA DE TAREO";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblmsj1);
            this.groupBox1.Controls.Add(this.dgvCuadrilla);
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.cboCategoria);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.dateTareo);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cboPersonal);
            this.groupBox1.Location = new System.Drawing.Point(4, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(414, 465);
            this.groupBox1.TabIndex = 63;
            this.groupBox1.TabStop = false;
            // 
            // dgvCuadrilla
            // 
            this.dgvCuadrilla.AllowUserToAddRows = false;
            this.dgvCuadrilla.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvCuadrilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCuadrilla.Location = new System.Drawing.Point(8, 131);
            this.dgvCuadrilla.Name = "dgvCuadrilla";
            this.dgvCuadrilla.Size = new System.Drawing.Size(400, 324);
            this.dgvCuadrilla.TabIndex = 64;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = global::WinForms.Properties.Resources.boton_buscar;
            this.btnBuscar.Location = new System.Drawing.Point(140, 85);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(110, 30);
            this.btnBuscar.TabIndex = 63;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // dateFechaAsigna
            // 
            this.dateFechaAsigna.Location = new System.Drawing.Point(134, 55);
            this.dateFechaAsigna.Name = "dateFechaAsigna";
            this.dateFechaAsigna.Size = new System.Drawing.Size(266, 20);
            this.dateFechaAsigna.TabIndex = 52;
            this.dateFechaAsigna.ValueChanged += new System.EventHandler(this.dateFechaAsigna_ValueChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblmsj2);
            this.groupBox2.Controls.Add(this.btnListar);
            this.groupBox2.Controls.Add(this.dgvNuevo);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.dateFechaAsigna);
            this.groupBox2.Controls.Add(this.rdoEmpleado);
            this.groupBox2.Controls.Add(this.rdoObreros);
            this.groupBox2.Controls.Add(this.cboNuevoEncargado);
            this.groupBox2.Location = new System.Drawing.Point(468, 28);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(410, 464);
            this.groupBox2.TabIndex = 64;
            this.groupBox2.TabStop = false;
            // 
            // btnListar
            // 
            this.btnListar.Image = global::WinForms.Properties.Resources.boton_buscar;
            this.btnListar.Location = new System.Drawing.Point(133, 79);
            this.btnListar.Name = "btnListar";
            this.btnListar.Size = new System.Drawing.Size(100, 30);
            this.btnListar.TabIndex = 66;
            this.btnListar.UseVisualStyleBackColor = true;
            this.btnListar.Click += new System.EventHandler(this.btnListar_Click);
            // 
            // dgvNuevo
            // 
            this.dgvNuevo.AllowUserToAddRows = false;
            this.dgvNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvNuevo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNuevo.Location = new System.Drawing.Point(6, 130);
            this.dgvNuevo.Name = "dgvNuevo";
            this.dgvNuevo.Size = new System.Drawing.Size(400, 328);
            this.dgvNuevo.TabIndex = 65;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 13);
            this.label5.TabIndex = 61;
            this.label5.Text = "FECHA DE ASIGNACIÓN";
            // 
            // btnQuitar
            // 
            this.btnQuitar.Location = new System.Drawing.Point(425, 251);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(36, 35);
            this.btnQuitar.TabIndex = 66;
            this.btnQuitar.Text = "<<";
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.Location = new System.Drawing.Point(425, 195);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(36, 35);
            this.btnSeleccionar.TabIndex = 65;
            this.btnSeleccionar.Text = ">>";
            this.btnSeleccionar.UseVisualStyleBackColor = true;
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
            // 
            // lblmsj1
            // 
            this.lblmsj1.AutoSize = true;
            this.lblmsj1.Location = new System.Drawing.Point(13, 112);
            this.lblmsj1.Name = "lblmsj1";
            this.lblmsj1.Size = new System.Drawing.Size(10, 13);
            this.lblmsj1.TabIndex = 65;
            this.lblmsj1.Text = ".";
            // 
            // lblmsj2
            // 
            this.lblmsj2.AutoSize = true;
            this.lblmsj2.Location = new System.Drawing.Point(8, 107);
            this.lblmsj2.Name = "lblmsj2";
            this.lblmsj2.Size = new System.Drawing.Size(10, 13);
            this.lblmsj2.TabIndex = 67;
            this.lblmsj2.Text = ".";
            // 
            // frmLiberarResponsable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 494);
            this.Controls.Add(this.btnQuitar);
            this.Controls.Add(this.btnSeleccionar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLiberarResponsable";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmLiberarResponsable";
            this.Load += new System.EventHandler(this.frmLiberarResponsable_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuadrilla)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNuevo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboCategoria;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboPersonal;
        private System.Windows.Forms.RadioButton rdoObreros;
        private System.Windows.Forms.RadioButton rdoEmpleado;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboNuevoEncargado;
        private System.Windows.Forms.DateTimePicker dateTareo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dateFechaAsigna;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView dgvCuadrilla;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvNuevo;
        private System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.Button btnSeleccionar;
        private System.Windows.Forms.Button btnListar;
        private System.Windows.Forms.Label lblmsj1;
        private System.Windows.Forms.Label lblmsj2;
    }
}