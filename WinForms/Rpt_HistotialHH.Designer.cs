namespace WinForms
{
    partial class Rpt_HistotialHH
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateFechaTermino = new System.Windows.Forms.DateTimePicker();
            this.dateFecha = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.cboEmpresa = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboCentroCosto = new System.Windows.Forms.ComboBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.ReportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dsTareo = new WinForms.DataSet.DsTareo();
            this.sPRPTTAREOHISTORICOPERSONALBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sP_RPT_TAREO_HISTORICO_PERSONALTableAdapter = new WinForms.DataSet.DsTareoTableAdapters.SP_RPT_TAREO_HISTORICO_PERSONALTableAdapter();
            this.sPRPTTAREOTOTALPERSONALBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sP_RPT_TAREO_TOTAL_PERSONALTableAdapter = new WinForms.DataSet.DsTareoTableAdapters.SP_RPT_TAREO_TOTAL_PERSONALTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dsTareo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPRPTTAREOHISTORICOPERSONALBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPRPTTAREOTOTALPERSONALBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(7, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1315, 23);
            this.label2.TabIndex = 46;
            this.label2.Text = "Historial de personal  HH";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(785, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 70;
            this.label4.Text = "TERMINO";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(539, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 69;
            this.label1.Text = "INICIO";
            // 
            // dateFechaTermino
            // 
            this.dateFechaTermino.Location = new System.Drawing.Point(849, 36);
            this.dateFechaTermino.Name = "dateFechaTermino";
            this.dateFechaTermino.Size = new System.Drawing.Size(200, 20);
            this.dateFechaTermino.TabIndex = 68;
            // 
            // dateFecha
            // 
            this.dateFecha.Location = new System.Drawing.Point(578, 37);
            this.dateFecha.Name = "dateFecha";
            this.dateFecha.Size = new System.Drawing.Size(202, 20);
            this.dateFecha.TabIndex = 67;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(9, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 63;
            this.label7.Text = "EMPRESA";
            // 
            // cboEmpresa
            // 
            this.cboEmpresa.FormattingEnabled = true;
            this.cboEmpresa.Location = new System.Drawing.Point(74, 38);
            this.cboEmpresa.Name = "cboEmpresa";
            this.cboEmpresa.Size = new System.Drawing.Size(66, 21);
            this.cboEmpresa.TabIndex = 64;
            this.cboEmpresa.SelectedIndexChanged += new System.EventHandler(this.cboEmpresa_SelectedIndexChanged_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(143, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 65;
            this.label3.Text = "C. COSTO";
            // 
            // cboCentroCosto
            // 
            this.cboCentroCosto.FormattingEnabled = true;
            this.cboCentroCosto.Location = new System.Drawing.Point(201, 37);
            this.cboCentroCosto.Name = "cboCentroCosto";
            this.cboCentroCosto.Size = new System.Drawing.Size(330, 21);
            this.cboCentroCosto.TabIndex = 66;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = global::WinForms.Properties.Resources.boton_buscar;
            this.btnBuscar.Location = new System.Drawing.Point(1203, 29);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(110, 30);
            this.btnBuscar.TabIndex = 71;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // ReportViewer1
            // 
            this.ReportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.sPRPTTAREOHISTORICOPERSONALBindingSource;
            reportDataSource2.Name = "DataSet2";
            reportDataSource2.Value = this.sPRPTTAREOTOTALPERSONALBindingSource;
            this.ReportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.ReportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.ReportViewer1.LocalReport.ReportEmbeddedResource = "WinForms.Reportes.RptHistorialHHPersonal.rdlc";
            this.ReportViewer1.Location = new System.Drawing.Point(10, 65);
            this.ReportViewer1.Name = "ReportViewer1";
            this.ReportViewer1.Size = new System.Drawing.Size(1312, 389);
            this.ReportViewer1.TabIndex = 72;
            // 
            // txtDni
            // 
            this.txtDni.Location = new System.Drawing.Point(1096, 35);
            this.txtDni.MaxLength = 10;
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(100, 20);
            this.txtDni.TabIndex = 73;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1064, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 74;
            this.label5.Text = "DNI";
            // 
            // dsTareo
            // 
            this.dsTareo.DataSetName = "DsTareo";
            this.dsTareo.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sPRPTTAREOHISTORICOPERSONALBindingSource
            // 
            this.sPRPTTAREOHISTORICOPERSONALBindingSource.DataMember = "SP_RPT_TAREO_HISTORICO_PERSONAL";
            this.sPRPTTAREOHISTORICOPERSONALBindingSource.DataSource = this.dsTareo;
            // 
            // sP_RPT_TAREO_HISTORICO_PERSONALTableAdapter
            // 
            this.sP_RPT_TAREO_HISTORICO_PERSONALTableAdapter.ClearBeforeFill = true;
            // 
            // sPRPTTAREOTOTALPERSONALBindingSource
            // 
            this.sPRPTTAREOTOTALPERSONALBindingSource.DataMember = "SP_RPT_TAREO_TOTAL_PERSONAL";
            this.sPRPTTAREOTOTALPERSONALBindingSource.DataSource = this.dsTareo;
            // 
            // sP_RPT_TAREO_TOTAL_PERSONALTableAdapter
            // 
            this.sP_RPT_TAREO_TOTAL_PERSONALTableAdapter.ClearBeforeFill = true;
            // 
            // Rpt_HistotialHH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1334, 466);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDni);
            this.Controls.Add(this.ReportViewer1);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateFechaTermino);
            this.Controls.Add(this.dateFecha);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cboEmpresa);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboCentroCosto);
            this.Controls.Add(this.label2);
            this.Name = "Rpt_HistotialHH";
            this.Text = "Rpt_HistotialHH";
            this.Load += new System.EventHandler(this.Rpt_HistotialHH_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsTareo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPRPTTAREOHISTORICOPERSONALBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPRPTTAREOTOTALPERSONALBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateFechaTermino;
        private System.Windows.Forms.DateTimePicker dateFecha;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboEmpresa;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboCentroCosto;
        private System.Windows.Forms.Button btnBuscar;
        private Microsoft.Reporting.WinForms.ReportViewer ReportViewer1;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.BindingSource sPRPTTAREOHISTORICOPERSONALBindingSource;
        private DataSet.DsTareo dsTareo;
        private System.Windows.Forms.BindingSource sPRPTTAREOTOTALPERSONALBindingSource;
        private DataSet.DsTareoTableAdapters.SP_RPT_TAREO_HISTORICO_PERSONALTableAdapter sP_RPT_TAREO_HISTORICO_PERSONALTableAdapter;
        private DataSet.DsTareoTableAdapters.SP_RPT_TAREO_TOTAL_PERSONALTableAdapter sP_RPT_TAREO_TOTAL_PERSONALTableAdapter;
    }
}