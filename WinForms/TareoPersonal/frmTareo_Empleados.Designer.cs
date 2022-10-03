namespace WinForms.TareoPersonal
{
    partial class frmTareo_Empleados
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnMp = new System.Windows.Forms.Button();
            this.dgReporte = new System.Windows.Forms.DataGridView();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnMPO = new System.Windows.Forms.Button();
            this.btnCerrarTareo = new System.Windows.Forms.Button();
            this.btnMPL = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnImportar = new System.Windows.Forms.Button();
            this.btn_Excel = new System.Windows.Forms.Button();
            this.cboEmpresa = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.lblEstado = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboUbicacion = new System.Windows.Forms.ComboBox();
            this.cboAnio = new System.Windows.Forms.ComboBox();
            this.cboMes = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgTareo = new System.Windows.Forms.DataGridView();
            this.btnExcelDetalle = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgReporte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgTareo)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnExcelDetalle);
            this.groupBox1.Controls.Add(this.btnMp);
            this.groupBox1.Controls.Add(this.dgReporte);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Controls.Add(this.btnMPO);
            this.groupBox1.Controls.Add(this.btnCerrarTareo);
            this.groupBox1.Controls.Add(this.btnMPL);
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.btnImportar);
            this.groupBox1.Controls.Add(this.btn_Excel);
            this.groupBox1.Controls.Add(this.cboEmpresa);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.btnGrabar);
            this.groupBox1.Controls.Add(this.lblEstado);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cboUbicacion);
            this.groupBox1.Controls.Add(this.cboAnio);
            this.groupBox1.Controls.Add(this.cboMes);
            this.groupBox1.Location = new System.Drawing.Point(7, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1346, 123);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnMp
            // 
            this.btnMp.Location = new System.Drawing.Point(1067, 72);
            this.btnMp.Name = "btnMp";
            this.btnMp.Size = new System.Drawing.Size(115, 36);
            this.btnMp.TabIndex = 19;
            this.btnMp.Text = "MPASISTENCIA";
            this.btnMp.UseVisualStyleBackColor = true;
            this.btnMp.Visible = false;
            this.btnMp.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgReporte
            // 
            this.dgReporte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgReporte.Location = new System.Drawing.Point(675, 80);
            this.dgReporte.Name = "dgReporte";
            this.dgReporte.Size = new System.Drawing.Size(34, 13);
            this.dgReporte.TabIndex = 18;
            this.dgReporte.Visible = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(911, 173);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(33, 42);
            this.dataGridView1.TabIndex = 17;
            // 
            // btnMPO
            // 
            this.btnMPO.Location = new System.Drawing.Point(910, 72);
            this.btnMPO.Name = "btnMPO";
            this.btnMPO.Size = new System.Drawing.Size(79, 36);
            this.btnMPO.TabIndex = 16;
            this.btnMPO.Text = "MPDSO-O";
            this.btnMPO.UseVisualStyleBackColor = true;
            this.btnMPO.Visible = false;
            this.btnMPO.Click += new System.EventHandler(this.btnMPO_Click);
            // 
            // btnCerrarTareo
            // 
            this.btnCerrarTareo.Location = new System.Drawing.Point(1046, 29);
            this.btnCerrarTareo.Name = "btnCerrarTareo";
            this.btnCerrarTareo.Size = new System.Drawing.Size(136, 37);
            this.btnCerrarTareo.TabIndex = 11;
            this.btnCerrarTareo.Text = "CERRAR TAREO";
            this.btnCerrarTareo.UseVisualStyleBackColor = true;
            this.btnCerrarTareo.Click += new System.EventHandler(this.btnCerrarTareo_Click);
            // 
            // btnMPL
            // 
            this.btnMPL.Location = new System.Drawing.Point(995, 72);
            this.btnMPL.Name = "btnMPL";
            this.btnMPL.Size = new System.Drawing.Size(66, 36);
            this.btnMPL.TabIndex = 15;
            this.btnMPL.Text = "MPDSO-L";
            this.btnMPL.UseVisualStyleBackColor = true;
            this.btnMPL.Visible = false;
            this.btnMPL.Click += new System.EventHandler(this.btnMPL_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(735, 29);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(101, 37);
            this.btnBuscar.TabIndex = 7;
            this.btnBuscar.Text = "BUSCAR";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnImportar
            // 
            this.btnImportar.Location = new System.Drawing.Point(735, 72);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(169, 36);
            this.btnImportar.TabIndex = 9;
            this.btnImportar.Text = "IMPORTAR EMPLEADOS";
            this.btnImportar.UseVisualStyleBackColor = true;
            this.btnImportar.Click += new System.EventHandler(this.btnImportar_Click);
            // 
            // btn_Excel
            // 
            this.btn_Excel.Location = new System.Drawing.Point(938, 29);
            this.btn_Excel.Name = "btn_Excel";
            this.btn_Excel.Size = new System.Drawing.Size(102, 37);
            this.btn_Excel.TabIndex = 14;
            this.btn_Excel.Text = "DESCARGAR EXCEL";
            this.btn_Excel.UseVisualStyleBackColor = true;
            this.btn_Excel.Visible = false;
            this.btn_Excel.Click += new System.EventHandler(this.btn_Excel_Click);
            // 
            // cboEmpresa
            // 
            this.cboEmpresa.FormattingEnabled = true;
            this.cboEmpresa.Location = new System.Drawing.Point(80, 37);
            this.cboEmpresa.Name = "cboEmpresa";
            this.cboEmpresa.Size = new System.Drawing.Size(353, 21);
            this.cboEmpresa.TabIndex = 13;
            this.cboEmpresa.SelectedIndexChanged += new System.EventHandler(this.cboEmpresa_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(15, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "EMPRESA";
            // 
            // btnGrabar
            // 
            this.btnGrabar.Location = new System.Drawing.Point(842, 29);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(90, 37);
            this.btnGrabar.TabIndex = 10;
            this.btnGrabar.Text = "GRABAR";
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.Location = new System.Drawing.Point(582, 73);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(49, 20);
            this.lblEstado.TabIndex = 6;
            this.lblEstado.Text = "........";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(464, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "ESTADO DE TAREO:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(461, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "AÑO:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(564, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "MES:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "UBICACION:";
            // 
            // cboUbicacion
            // 
            this.cboUbicacion.FormattingEnabled = true;
            this.cboUbicacion.Location = new System.Drawing.Point(80, 72);
            this.cboUbicacion.Name = "cboUbicacion";
            this.cboUbicacion.Size = new System.Drawing.Size(353, 21);
            this.cboUbicacion.TabIndex = 0;
            this.cboUbicacion.SelectedIndexChanged += new System.EventHandler(this.cboUbicacion_SelectedIndexChanged);
            // 
            // cboAnio
            // 
            this.cboAnio.FormattingEnabled = true;
            this.cboAnio.Location = new System.Drawing.Point(500, 37);
            this.cboAnio.Name = "cboAnio";
            this.cboAnio.Size = new System.Drawing.Size(57, 21);
            this.cboAnio.TabIndex = 2;
            // 
            // cboMes
            // 
            this.cboMes.FormattingEnabled = true;
            this.cboMes.Items.AddRange(new object[] {
            "2018",
            "2019",
            "2020",
            "2021"});
            this.cboMes.Location = new System.Drawing.Point(603, 38);
            this.cboMes.Name = "cboMes";
            this.cboMes.Size = new System.Drawing.Size(117, 21);
            this.cboMes.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dgTareo);
            this.groupBox2.Location = new System.Drawing.Point(7, 133);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1352, 423);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            // 
            // dgTareo
            // 
            this.dgTareo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgTareo.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgTareo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgTareo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTareo.Location = new System.Drawing.Point(18, 19);
            this.dgTareo.Name = "dgTareo";
            this.dgTareo.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgTareo.RowTemplate.Height = 20;
            this.dgTareo.Size = new System.Drawing.Size(1336, 386);
            this.dgTareo.TabIndex = 0;
            this.dgTareo.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgTareo_CellBeginEdit);
            this.dgTareo.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgTareo_CellDoubleClick);
            this.dgTareo.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgTareo_CellEndEdit);
            this.dgTareo.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgTareo_CellFormatting);
            this.dgTareo.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgTareo_CellLeave_1);
            this.dgTareo.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgTareo_CellMouseLeave);
            this.dgTareo.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgTareo_CellMouseUp);
            this.dgTareo.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgTareo_ColumnHeaderMouseClick);
            this.dgTareo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgTareo_MouseClick);
            // 
            // btnExcelDetalle
            // 
            this.btnExcelDetalle.Location = new System.Drawing.Point(1188, 30);
            this.btnExcelDetalle.Name = "btnExcelDetalle";
            this.btnExcelDetalle.Size = new System.Drawing.Size(102, 37);
            this.btnExcelDetalle.TabIndex = 20;
            this.btnExcelDetalle.Text = "MOSTRAR DETALLE";
            this.btnExcelDetalle.UseVisualStyleBackColor = true;
            this.btnExcelDetalle.Visible = false;
            this.btnExcelDetalle.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // frmTareo_Empleados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 573);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmTareo_Empleados";
            this.Text = "frmTareo_Empleados";
            this.Load += new System.EventHandler(this.frmTareo_Empleados_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgReporte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgTareo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCerrarTareo;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.Button btnImportar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboUbicacion;
        private System.Windows.Forms.ComboBox cboAnio;
        private System.Windows.Forms.ComboBox cboMes;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgTareo;
        private System.Windows.Forms.ComboBox cboEmpresa;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btn_Excel;
        private System.Windows.Forms.Button btnMPO;
        private System.Windows.Forms.Button btnMPL;
        private System.Windows.Forms.DataGridView dgReporte;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnMp;
        private System.Windows.Forms.Button btnExcelDetalle;
    }
}