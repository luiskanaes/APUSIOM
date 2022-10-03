namespace WinForms
{
    partial class frmHHDiario
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dateFecha = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.cboEmpresa = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboCentroCosto = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ReportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.sPRPTTAREOPARTEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsTareo = new WinForms.DataSet.DsTareo();
            this.sPRPTTAREOACTIVIDADESDIABindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sPRPTTAREOACTIVIDADESDIABindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.sP_RPT_TAREO_PARTETableAdapter = new WinForms.DataSet.DsTareoTableAdapters.SP_RPT_TAREO_PARTETableAdapter();
            this.sP_RPT_TAREO_ACTIVIDADES_DIATableAdapter = new WinForms.DataSet.DsTareoTableAdapters.SP_RPT_TAREO_ACTIVIDADES_DIATableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.sPRPTTAREOPARTEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsTareo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPRPTTAREOACTIVIDADESDIABindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPRPTTAREOACTIVIDADESDIABindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(582, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 44;
            this.label1.Text = "FECHA TAREO";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = global::WinForms.Properties.Resources.boton_buscar;
            this.btnBuscar.Location = new System.Drawing.Point(871, 30);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(110, 30);
            this.btnBuscar.TabIndex = 43;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // dateFecha
            // 
            this.dateFecha.Location = new System.Drawing.Point(664, 35);
            this.dateFecha.Name = "dateFecha";
            this.dateFecha.Size = new System.Drawing.Size(202, 20);
            this.dateFecha.TabIndex = 42;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(8, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 38;
            this.label7.Text = "EMPRESA";
            // 
            // cboEmpresa
            // 
            this.cboEmpresa.FormattingEnabled = true;
            this.cboEmpresa.Location = new System.Drawing.Point(73, 35);
            this.cboEmpresa.Name = "cboEmpresa";
            this.cboEmpresa.Size = new System.Drawing.Size(66, 21);
            this.cboEmpresa.TabIndex = 39;
            this.cboEmpresa.SelectedIndexChanged += new System.EventHandler(this.cboEmpresa_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(142, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 40;
            this.label3.Text = "C. COSTO";
            // 
            // cboCentroCosto
            // 
            this.cboCentroCosto.FormattingEnabled = true;
            this.cboCentroCosto.Location = new System.Drawing.Point(200, 35);
            this.cboCentroCosto.Name = "cboCentroCosto";
            this.cboCentroCosto.Size = new System.Drawing.Size(372, 21);
            this.cboCentroCosto.TabIndex = 41;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(5, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1087, 23);
            this.label2.TabIndex = 37;
            this.label2.Text = "Parte Diario";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ReportViewer1
            // 
            this.ReportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.sPRPTTAREOPARTEBindingSource;
            reportDataSource2.Name = "DataSet2";
            reportDataSource2.Value = this.sPRPTTAREOACTIVIDADESDIABindingSource;
            reportDataSource3.Name = "DataSet3";
            reportDataSource3.Value = this.sPRPTTAREOACTIVIDADESDIABindingSource1;
            this.ReportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.ReportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.ReportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.ReportViewer1.LocalReport.ReportEmbeddedResource = "WinForms.Reportes.RptParteDiario.rdlc";
            this.ReportViewer1.Location = new System.Drawing.Point(11, 74);
            this.ReportViewer1.Name = "ReportViewer1";
            this.ReportViewer1.Size = new System.Drawing.Size(1081, 316);
            this.ReportViewer1.TabIndex = 45;
            // 
            // sPRPTTAREOPARTEBindingSource
            // 
            this.sPRPTTAREOPARTEBindingSource.DataMember = "SP_RPT_TAREO_PARTE";
            this.sPRPTTAREOPARTEBindingSource.DataSource = this.dsTareo;
            // 
            // dsTareo
            // 
            this.dsTareo.DataSetName = "DsTareo";
            this.dsTareo.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sPRPTTAREOACTIVIDADESDIABindingSource
            // 
            this.sPRPTTAREOACTIVIDADESDIABindingSource.DataMember = "SP_RPT_TAREO_ACTIVIDADES_DIA";
            this.sPRPTTAREOACTIVIDADESDIABindingSource.DataSource = this.dsTareo;
            // 
            // sPRPTTAREOACTIVIDADESDIABindingSource1
            // 
            this.sPRPTTAREOACTIVIDADESDIABindingSource1.DataMember = "SP_RPT_TAREO_ACTIVIDADES_DIA";
            this.sPRPTTAREOACTIVIDADESDIABindingSource1.DataSource = this.dsTareo;
            // 
            // sP_RPT_TAREO_PARTETableAdapter
            // 
            this.sP_RPT_TAREO_PARTETableAdapter.ClearBeforeFill = true;
            // 
            // sP_RPT_TAREO_ACTIVIDADES_DIATableAdapter
            // 
            this.sP_RPT_TAREO_ACTIVIDADES_DIATableAdapter.ClearBeforeFill = true;
            // 
            // frmHHDiario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1104, 402);
            this.Controls.Add(this.ReportViewer1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.dateFecha);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cboEmpresa);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboCentroCosto);
            this.Controls.Add(this.label2);
            this.Name = "frmHHDiario";
            this.Text = "frmHHDiario";
            this.Load += new System.EventHandler(this.frmHHDiario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sPRPTTAREOPARTEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsTareo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPRPTTAREOACTIVIDADESDIABindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPRPTTAREOACTIVIDADESDIABindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DateTimePicker dateFecha;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboEmpresa;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboCentroCosto;
        private System.Windows.Forms.Label label2;
        private Microsoft.Reporting.WinForms.ReportViewer ReportViewer1;
        private System.Windows.Forms.BindingSource sPRPTTAREOPARTEBindingSource;
        private DataSet.DsTareo dsTareo;
        private System.Windows.Forms.BindingSource sPRPTTAREOACTIVIDADESDIABindingSource;
        private System.Windows.Forms.BindingSource sPRPTTAREOACTIVIDADESDIABindingSource1;
        private DataSet.DsTareoTableAdapters.SP_RPT_TAREO_PARTETableAdapter sP_RPT_TAREO_PARTETableAdapter;
        private DataSet.DsTareoTableAdapters.SP_RPT_TAREO_ACTIVIDADES_DIATableAdapter sP_RPT_TAREO_ACTIVIDADES_DIATableAdapter;
    }
}