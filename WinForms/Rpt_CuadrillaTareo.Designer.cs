namespace WinForms
{
    partial class Rpt_CuadrillaTareo
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dsTareoReporte = new WinForms.DataSet.DsTareoReporte();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTareo = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.cboCentroCosto = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboEmpresa = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cboIngeniero = new System.Windows.Forms.ComboBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.ReportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.uspRPT_ASIGNACION_TAREAS_POR_FECHATableAdapter = new WinForms.DataSet.DsTareoReporteTableAdapters.uspRPT_ASIGNACION_TAREAS_POR_FECHATableAdapter();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoHH = new System.Windows.Forms.RadioButton();
            this.rdoNuevo = new System.Windows.Forms.RadioButton();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btnTotal = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsTareoReporte)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataMember = "uspRPT_ASIGNACION_TAREAS_POR_FECHA";
            this.bindingSource1.DataSource = this.dsTareoReporte;
            // 
            // dsTareoReporte
            // 
            this.dsTareoReporte.DataSetName = "DsTareoReporte";
            this.dsTareoReporte.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1037, 23);
            this.label2.TabIndex = 46;
            this.label2.Text = "Tareo diario obreros";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dateTareo
            // 
            this.dateTareo.Location = new System.Drawing.Point(721, 30);
            this.dateTareo.Name = "dateTareo";
            this.dateTareo.Size = new System.Drawing.Size(203, 20);
            this.dateTareo.TabIndex = 49;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(673, 35);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 13);
            this.label9.TabIndex = 51;
            this.label9.Text = "FECHA";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = global::WinForms.Properties.Resources.boton_buscar;
            this.btnBuscar.Location = new System.Drawing.Point(930, 28);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(110, 30);
            this.btnBuscar.TabIndex = 53;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // cboCentroCosto
            // 
            this.cboCentroCosto.FormattingEnabled = true;
            this.cboCentroCosto.Location = new System.Drawing.Point(198, 32);
            this.cboCentroCosto.Name = "cboCentroCosto";
            this.cboCentroCosto.Size = new System.Drawing.Size(459, 21);
            this.cboCentroCosto.TabIndex = 52;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(141, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 50;
            this.label3.Text = "C. COSTO";
            // 
            // cboEmpresa
            // 
            this.cboEmpresa.FormattingEnabled = true;
            this.cboEmpresa.Location = new System.Drawing.Point(72, 32);
            this.cboEmpresa.Name = "cboEmpresa";
            this.cboEmpresa.Size = new System.Drawing.Size(66, 21);
            this.cboEmpresa.TabIndex = 48;
            this.cboEmpresa.SelectedIndexChanged += new System.EventHandler(this.cboEmpresa_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(7, 37);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 47;
            this.label7.Text = "EMPRESA";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(31, 96);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(167, 13);
            this.label14.TabIndex = 57;
            this.label14.Text = "RESPONSABLE DE CUADRILLA";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(72, 62);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(126, 13);
            this.label13.TabIndex = 56;
            this.label13.Text = "INGENIERO DE CAMPO";
            // 
            // cboIngeniero
            // 
            this.cboIngeniero.FormattingEnabled = true;
            this.cboIngeniero.Location = new System.Drawing.Point(198, 56);
            this.cboIngeniero.Name = "cboIngeniero";
            this.cboIngeniero.Size = new System.Drawing.Size(459, 21);
            this.cboIngeniero.TabIndex = 54;
            this.cboIngeniero.SelectedIndexChanged += new System.EventHandler(this.cboIngeniero_SelectedIndexChanged);
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblEstado.Location = new System.Drawing.Point(974, 59);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(29, 13);
            this.lblEstado.TabIndex = 58;
            this.lblEstado.Text = "label";
            this.lblEstado.Visible = false;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(198, 96);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(339, 64);
            this.checkedListBox1.TabIndex = 59;
            // 
            // button1
            // 
            this.button1.Image = global::WinForms.Properties.Resources.boton_Excel;
            this.button1.Location = new System.Drawing.Point(547, 96);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 30);
            this.button1.TabIndex = 60;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ReportViewer1
            // 
            this.ReportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.bindingSource1;
            this.ReportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.ReportViewer1.LocalReport.ReportEmbeddedResource = "WinForms.Reportes.Rpt_TareoCuadrilla.rdlc";
            this.ReportViewer1.Location = new System.Drawing.Point(6, 166);
            this.ReportViewer1.Name = "ReportViewer1";
            this.ReportViewer1.Size = new System.Drawing.Size(1034, 298);
            this.ReportViewer1.TabIndex = 61;
            // 
            // uspRPT_ASIGNACION_TAREAS_POR_FECHATableAdapter
            // 
            this.uspRPT_ASIGNACION_TAREAS_POR_FECHATableAdapter.ClearBeforeFill = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoHH);
            this.groupBox1.Controls.Add(this.rdoNuevo);
            this.groupBox1.Location = new System.Drawing.Point(724, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 57);
            this.groupBox1.TabIndex = 62;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Reporte";
            // 
            // rdoHH
            // 
            this.rdoHH.AutoSize = true;
            this.rdoHH.Location = new System.Drawing.Point(104, 20);
            this.rdoHH.Name = "rdoHH";
            this.rdoHH.Size = new System.Drawing.Size(91, 17);
            this.rdoHH.TabIndex = 1;
            this.rdoHH.Text = "HH realizadas";
            this.rdoHH.UseVisualStyleBackColor = true;
            // 
            // rdoNuevo
            // 
            this.rdoNuevo.AutoSize = true;
            this.rdoNuevo.Checked = true;
            this.rdoNuevo.Location = new System.Drawing.Point(6, 19);
            this.rdoNuevo.Name = "rdoNuevo";
            this.rdoNuevo.Size = new System.Drawing.Size(89, 17);
            this.rdoNuevo.TabIndex = 0;
            this.rdoNuevo.TabStop = true;
            this.rdoNuevo.Text = "Solo personal";
            this.rdoNuevo.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(201, 78);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(106, 17);
            this.checkBox1.TabIndex = 63;
            this.checkBox1.Text = "Seleccionar todo";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // btnTotal
            // 
            this.btnTotal.Location = new System.Drawing.Point(547, 129);
            this.btnTotal.Name = "btnTotal";
            this.btnTotal.Size = new System.Drawing.Size(110, 30);
            this.btnTotal.TabIndex = 64;
            this.btnTotal.Text = "Descarga total";
            this.btnTotal.UseVisualStyleBackColor = true;
            this.btnTotal.Visible = false;
            this.btnTotal.Click += new System.EventHandler(this.btnTotal_Click);
            // 
            // Rpt_CuadrillaTareo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1052, 476);
            this.Controls.Add(this.btnTotal);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ReportViewer1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.cboIngeniero);
            this.Controls.Add(this.dateTareo);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.cboCentroCosto);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboEmpresa);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Name = "Rpt_CuadrillaTareo";
            this.Text = "Rpt_CuadrillaTareo";
            this.Load += new System.EventHandler(this.Rpt_CuadrillaTareo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsTareoReporte)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTareo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.ComboBox cboCentroCosto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboEmpresa;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cboIngeniero;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.BindingSource uspRPTASIGNACIONTAREASPORFECHABindingSource;
        private System.Windows.Forms.BindingSource dsTareoBindingSource;
        private Microsoft.Reporting.WinForms.ReportViewer ReportViewer1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private DataSet.DsTareoReporte dsTareoReporte;
        private DataSet.DsTareoReporteTableAdapters.uspRPT_ASIGNACION_TAREAS_POR_FECHATableAdapter uspRPT_ASIGNACION_TAREAS_POR_FECHATableAdapter;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoHH;
        private System.Windows.Forms.RadioButton rdoNuevo;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button btnTotal;
    }
}