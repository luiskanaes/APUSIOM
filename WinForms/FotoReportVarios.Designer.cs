namespace WinForms
{
    partial class FotoReportVarios
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
            this.ReportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dsRRHH = new WinForms.DataSet.DsRRHH();
            this.dsRRHHBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.uSPPERSONALFOTOCHECKBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.uSP_PERSONAL_FOTOCHECKTableAdapter = new WinForms.DataSet.DsRRHHTableAdapters.USP_PERSONAL_FOTOCHECKTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dsRRHH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsRRHHBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uSPPERSONALFOTOCHECKBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ReportViewer1
            // 
            this.ReportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.uSPPERSONALFOTOCHECKBindingSource;
            this.ReportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.ReportViewer1.LocalReport.ReportEmbeddedResource = "WinForms.Reportes.RptFotocheckVarios.rdlc";
            this.ReportViewer1.Location = new System.Drawing.Point(13, 3);
            this.ReportViewer1.Name = "ReportViewer1";
            this.ReportViewer1.Size = new System.Drawing.Size(441, 427);
            this.ReportViewer1.TabIndex = 0;
            // 
            // dsRRHH
            // 
            this.dsRRHH.DataSetName = "DsRRHH";
            this.dsRRHH.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dsRRHHBindingSource
            // 
            this.dsRRHHBindingSource.DataSource = this.dsRRHH;
            this.dsRRHHBindingSource.Position = 0;
            // 
            // uSPPERSONALFOTOCHECKBindingSource
            // 
            this.uSPPERSONALFOTOCHECKBindingSource.DataMember = "USP_PERSONAL_FOTOCHECK";
            this.uSPPERSONALFOTOCHECKBindingSource.DataSource = this.dsRRHHBindingSource;
            // 
            // uSP_PERSONAL_FOTOCHECKTableAdapter
            // 
            this.uSP_PERSONAL_FOTOCHECKTableAdapter.ClearBeforeFill = true;
            // 
            // FotoReportVarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 438);
            this.Controls.Add(this.ReportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FotoReportVarios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FotoReportVarios";
            this.Load += new System.EventHandler(this.FotoReportVarios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsRRHH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsRRHHBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uSPPERSONALFOTOCHECKBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer ReportViewer1;
        private System.Windows.Forms.BindingSource uSPPERSONALFOTOCHECKBindingSource;
        private System.Windows.Forms.BindingSource dsRRHHBindingSource;
        private DataSet.DsRRHH dsRRHH;
        private DataSet.DsRRHHTableAdapters.USP_PERSONAL_FOTOCHECKTableAdapter uSP_PERSONAL_FOTOCHECKTableAdapter;
    }
}