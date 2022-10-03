namespace WinForms.Logistica
{
    partial class RptSolped
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.ReportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dsLogistica = new WinForms.DataSet.DsLogistica();
            this.uspINSSOLPEDLISTAIDBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.uspINS_SOLPED_LISTA_IDTableAdapter = new WinForms.DataSet.DsLogisticaTableAdapters.uspINS_SOLPED_LISTA_IDTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dsLogistica)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uspINSSOLPEDLISTAIDBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ReportViewer1
            // 
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.uspINSSOLPEDLISTAIDBindingSource;
            this.ReportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.ReportViewer1.LocalReport.ReportEmbeddedResource = "WinForms.Reportes.RptSolped.rdlc";
            this.ReportViewer1.Location = new System.Drawing.Point(2, 12);
            this.ReportViewer1.Name = "ReportViewer1";
            this.ReportViewer1.Size = new System.Drawing.Size(713, 305);
            this.ReportViewer1.TabIndex = 0;
            // 
            // dsLogistica
            // 
            this.dsLogistica.DataSetName = "DsLogistica";
            this.dsLogistica.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // uspINSSOLPEDLISTAIDBindingSource
            // 
            this.uspINSSOLPEDLISTAIDBindingSource.DataMember = "uspINS_SOLPED_LISTA_ID";
            this.uspINSSOLPEDLISTAIDBindingSource.DataSource = this.dsLogistica;
            // 
            // uspINS_SOLPED_LISTA_IDTableAdapter
            // 
            this.uspINS_SOLPED_LISTA_IDTableAdapter.ClearBeforeFill = true;
            // 
            // RptSolped
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 353);
            this.Controls.Add(this.ReportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RptSolped";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RptSolped";
            this.Load += new System.EventHandler(this.RptSolped_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsLogistica)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uspINSSOLPEDLISTAIDBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer ReportViewer1;
        private System.Windows.Forms.BindingSource uspINSSOLPEDLISTAIDBindingSource;
        private DataSet.DsLogistica dsLogistica;
        private DataSet.DsLogisticaTableAdapters.uspINS_SOLPED_LISTA_IDTableAdapter uspINS_SOLPED_LISTA_IDTableAdapter;
    }
}