namespace WinForms.Logistica
{
    partial class Solped
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
            this.ddlImputacion = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ddlObra = new System.Windows.Forms.ComboBox();
            this.ddlMoneda = new System.Windows.Forms.ComboBox();
            this.ddlCentro = new System.Windows.Forms.ComboBox();
            this.ddlGpoCompra = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dateFecha = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ddlCoste = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.ddlSociedad = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ddlCodigo = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.lblId = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.PanelPedidos = new System.Windows.Forms.GroupBox();
            this.btnAgregarAll = new System.Windows.Forms.Button();
            this.btnBuscarMaterial = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.PanelPedidos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ddlImputacion
            // 
            this.ddlImputacion.FormattingEnabled = true;
            this.ddlImputacion.Location = new System.Drawing.Point(6, 35);
            this.ddlImputacion.Name = "ddlImputacion";
            this.ddlImputacion.Size = new System.Drawing.Size(115, 21);
            this.ddlImputacion.TabIndex = 0;
            this.ddlImputacion.SelectedIndexChanged += new System.EventHandler(this.ddlImputacion_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "IMPUTACION";
            // 
            // ddlObra
            // 
            this.ddlObra.FormattingEnabled = true;
            this.ddlObra.Location = new System.Drawing.Point(251, 34);
            this.ddlObra.Name = "ddlObra";
            this.ddlObra.Size = new System.Drawing.Size(196, 21);
            this.ddlObra.TabIndex = 3;
            this.ddlObra.SelectedIndexChanged += new System.EventHandler(this.ddlObra_SelectedIndexChanged);
            // 
            // ddlMoneda
            // 
            this.ddlMoneda.FormattingEnabled = true;
            this.ddlMoneda.Location = new System.Drawing.Point(784, 33);
            this.ddlMoneda.Name = "ddlMoneda";
            this.ddlMoneda.Size = new System.Drawing.Size(115, 21);
            this.ddlMoneda.TabIndex = 4;
            // 
            // ddlCentro
            // 
            this.ddlCentro.FormattingEnabled = true;
            this.ddlCentro.Location = new System.Drawing.Point(5, 74);
            this.ddlCentro.Name = "ddlCentro";
            this.ddlCentro.Size = new System.Drawing.Size(238, 21);
            this.ddlCentro.TabIndex = 5;
            // 
            // ddlGpoCompra
            // 
            this.ddlGpoCompra.FormattingEnabled = true;
            this.ddlGpoCompra.Location = new System.Drawing.Point(249, 74);
            this.ddlGpoCompra.Name = "ddlGpoCompra";
            this.ddlGpoCompra.Size = new System.Drawing.Size(198, 21);
            this.ddlGpoCompra.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(128, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "SOCIEDAD";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(251, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "OBRA";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(662, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "VALOR";
            // 
            // dateFecha
            // 
            this.dateFecha.Location = new System.Drawing.Point(456, 34);
            this.dateFecha.Name = "dateFecha";
            this.dateFecha.Size = new System.Drawing.Size(200, 20);
            this.dateFecha.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(455, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "FECHA";
            // 
            // txtValor
            // 
            this.txtValor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtValor.Location = new System.Drawing.Point(662, 34);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(115, 20);
            this.txtValor.TabIndex = 12;
            this.txtValor.Text = "1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(786, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "MONEDA";
            // 
            // ddlCoste
            // 
            this.ddlCoste.FormattingEnabled = true;
            this.ddlCoste.Location = new System.Drawing.Point(456, 73);
            this.ddlCoste.Name = "ddlCoste";
            this.ddlCoste.Size = new System.Drawing.Size(443, 21);
            this.ddlCoste.TabIndex = 14;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ddlImputacion);
            this.groupBox1.Controls.Add(this.ddlCoste);
            this.groupBox1.Controls.Add(this.ddlSociedad);
            this.groupBox1.Controls.Add(this.ddlGpoCompra);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.ddlCentro);
            this.groupBox1.Controls.Add(this.ddlObra);
            this.groupBox1.Controls.Add(this.txtValor);
            this.groupBox1.Controls.Add(this.ddlMoneda);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dateFecha);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(10, 77);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1162, 104);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(455, 57);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(91, 13);
            this.label10.TabIndex = 17;
            this.label10.Text = "CENTRO COSTE";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(248, 58);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(95, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "GRUPO COMPRA";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 59);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "CENTRO";
            // 
            // ddlSociedad
            // 
            this.ddlSociedad.FormattingEnabled = true;
            this.ddlSociedad.Location = new System.Drawing.Point(128, 34);
            this.ddlSociedad.Name = "ddlSociedad";
            this.ddlSociedad.Size = new System.Drawing.Size(115, 21);
            this.ddlSociedad.TabIndex = 2;
            this.ddlSociedad.SelectedIndexChanged += new System.EventHandler(this.ddlSociedad_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(7, 1);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(1165, 23);
            this.label7.TabIndex = 21;
            this.label7.Text = "Solicitud de Solped";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ddlCodigo
            // 
            this.ddlCodigo.FormattingEnabled = true;
            this.ddlCodigo.Location = new System.Drawing.Point(8, 19);
            this.ddlCodigo.Name = "ddlCodigo";
            this.ddlCodigo.Size = new System.Drawing.Size(200, 21);
            this.ddlCodigo.TabIndex = 22;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.btnExcel);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.btnNuevo);
            this.groupBox2.Controls.Add(this.btnEliminar);
            this.groupBox2.Controls.Add(this.lblId);
            this.groupBox2.Controls.Add(this.btnGuardar);
            this.groupBox2.Controls.Add(this.btnBuscar);
            this.groupBox2.Controls.Add(this.ddlCodigo);
            this.groupBox2.Location = new System.Drawing.Point(10, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1162, 51);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "BUSCAR SOLICITUD";
            // 
            // btnExcel
            // 
            this.btnExcel.Image = global::WinForms.Properties.Resources.boton_Excel;
            this.btnExcel.Location = new System.Drawing.Point(686, 15);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(110, 30);
            this.btnExcel.TabIndex = 26;
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Image = global::WinForms.Properties.Resources.boton_Nuevo;
            this.btnNuevo.Location = new System.Drawing.Point(456, 17);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(110, 30);
            this.btnNuevo.TabIndex = 27;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Image = global::WinForms.Properties.Resources.boton_eliminar;
            this.btnEliminar.Location = new System.Drawing.Point(800, 15);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(110, 30);
            this.btnEliminar.TabIndex = 25;
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(364, 22);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(26, 13);
            this.lblId.TabIndex = 24;
            this.lblId.Text = "lblId";
            this.lblId.Visible = false;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Image = global::WinForms.Properties.Resources.boton_guardar;
            this.btnGuardar.Location = new System.Drawing.Point(570, 16);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(110, 30);
            this.btnGuardar.TabIndex = 18;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = global::WinForms.Properties.Resources.boton_buscar;
            this.btnBuscar.Location = new System.Drawing.Point(248, 14);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(110, 30);
            this.btnBuscar.TabIndex = 23;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // PanelPedidos
            // 
            this.PanelPedidos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelPedidos.Controls.Add(this.label17);
            this.PanelPedidos.Controls.Add(this.label16);
            this.PanelPedidos.Controls.Add(this.btnAgregarAll);
            this.PanelPedidos.Controls.Add(this.btnBuscarMaterial);
            this.PanelPedidos.Controls.Add(this.dataGridView2);
            this.PanelPedidos.Controls.Add(this.txtDescripcion);
            this.PanelPedidos.Location = new System.Drawing.Point(10, 371);
            this.PanelPedidos.Name = "PanelPedidos";
            this.PanelPedidos.Size = new System.Drawing.Size(1162, 171);
            this.PanelPedidos.TabIndex = 24;
            this.PanelPedidos.TabStop = false;
            this.PanelPedidos.Text = "BUSCAR MATERIALES";
            this.PanelPedidos.Visible = false;
            // 
            // btnAgregarAll
            // 
            this.btnAgregarAll.Image = global::WinForms.Properties.Resources.boton_agregar;
            this.btnAgregarAll.Location = new System.Drawing.Point(546, 10);
            this.btnAgregarAll.Name = "btnAgregarAll";
            this.btnAgregarAll.Size = new System.Drawing.Size(110, 30);
            this.btnAgregarAll.TabIndex = 3;
            this.btnAgregarAll.UseVisualStyleBackColor = true;
            this.btnAgregarAll.Click += new System.EventHandler(this.btnAgregarAll_Click);
            // 
            // btnBuscarMaterial
            // 
            this.btnBuscarMaterial.Image = global::WinForms.Properties.Resources.boton_buscar;
            this.btnBuscarMaterial.Location = new System.Drawing.Point(399, 10);
            this.btnBuscarMaterial.Name = "btnBuscarMaterial";
            this.btnBuscarMaterial.Size = new System.Drawing.Size(110, 30);
            this.btnBuscarMaterial.TabIndex = 2;
            this.btnBuscarMaterial.UseVisualStyleBackColor = true;
            this.btnBuscarMaterial.Click += new System.EventHandler(this.btnBuscarMaterial_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(8, 46);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(1148, 90);
            this.dataGridView2.TabIndex = 1;
            this.dataGridView2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellClick);
            this.dataGridView2.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridView2_EditingControlShowing);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(8, 16);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(350, 20);
            this.txtDescripcion.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(13, 191);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1159, 174);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(213, 23);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 13);
            this.label11.TabIndex = 4;
            this.label11.Text = "(F1)";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(490, 1);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 13);
            this.label12.TabIndex = 5;
            this.label12.Text = "(F2)";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(601, 1);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 13);
            this.label13.TabIndex = 5;
            this.label13.Text = "(F3)";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(712, 1);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(29, 13);
            this.label14.TabIndex = 6;
            this.label14.Text = "(F4)";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(828, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(29, 13);
            this.label15.TabIndex = 18;
            this.label15.Text = "(F5)";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(364, 19);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(29, 13);
            this.label16.TabIndex = 19;
            this.label16.Text = "(F6)";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(515, 19);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(29, 13);
            this.label17.TabIndex = 20;
            this.label17.Text = "(F7)";
            // 
            // Solped
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 514);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.PanelPedidos);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox1);
            this.Name = "Solped";
            this.Text = "Solped";
            this.Load += new System.EventHandler(this.Solped_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.PanelPedidos.ResumeLayout(false);
            this.PanelPedidos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox ddlImputacion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ddlObra;
        private System.Windows.Forms.ComboBox ddlMoneda;
        private System.Windows.Forms.ComboBox ddlCentro;
        private System.Windows.Forms.ComboBox ddlGpoCompra;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateFecha;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox ddlCoste;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox ddlSociedad;
        private System.Windows.Forms.ComboBox ddlCodigo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.GroupBox PanelPedidos;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Button btnBuscarMaterial;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnAgregarAll;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label17;
    }
}