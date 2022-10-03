namespace WinForms
{
    partial class FotoReportId
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
            this.uSPPERSONALFOTOCHECKIDBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsRRHH = new WinForms.DataSet.DsRRHH();
            this.ReportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.uSP_PERSONAL_FOTOCHECK_IDTableAdapter = new WinForms.DataSet.DsRRHHTableAdapters.USP_PERSONAL_FOTOCHECK_IDTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.uSPPERSONALFOTOCHECKIDBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsRRHH)).BeginInit();
            this.SuspendLayout();
            // 
            // uSPPERSONALFOTOCHECKIDBindingSource
            // 
            this.uSPPERSONALFOTOCHECKIDBindingSource.DataMember = "USP_PERSONAL_FOTOCHECK_ID";
            this.uSPPERSONALFOTOCHECKIDBindingSource.DataSource = this.dsRRHH;
            // 
            // dsRRHH
            // 
            this.dsRRHH.DataSetName = "DsRRHH";
            this.dsRRHH.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ReportViewer1
            // 
            this.ReportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.uSPPERSONALFOTOCHECKIDBindingSource;
            this.ReportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.ReportViewer1.LocalReport.ReportEmbeddedResource = "WinForms.Reportes.RptFotocheckId.rdlc";
            this.ReportViewer1.Location = new System.Drawing.Point(12, 12);
            this.ReportViewer1.Name = "ReportViewer1";
            this.ReportViewer1.Size = new System.Drawing.Size(409, 493);
            this.ReportViewer1.TabIndex = 0;
            // 
            // uSP_PERSONAL_FOTOCHECK_IDTableAdapter
            // 
            this.uSP_PERSONAL_FOTOCHECK_IDTableAdapter.ClearBeforeFill = true;
            // 
            // FotoReportId
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 517);
            this.Controls.Add(this.ReportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FotoReportId";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FotoReportId";
            this.Load += new System.EventHandler(this.FotoReportId_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uSPPERSONALFOTOCHECKIDBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsRRHH)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer ReportViewer1;
        private System.Windows.Forms.BindingSource uSPPERSONALFOTOCHECKIDBindingSource;
        private DataSet.DsRRHH dsRRHH;
        private DataSet.DsRRHHTableAdapters.USP_PERSONAL_FOTOCHECK_IDTableAdapter uSP_PERSONAL_FOTOCHECK_IDTableAdapter;
    }
}