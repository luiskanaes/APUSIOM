namespace WinForms
{
    partial class Rpt_ManoObra
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
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cboEmpresa = new System.Windows.Forms.ComboBox();
            this.cboCentroCosto = new System.Windows.Forms.ComboBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtCodSisplan = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPlanilla = new System.Windows.Forms.TextBox();
            this.cboAnio = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.ReportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.sPPLARPTCMODETALLEVARIOSMANOOBRABindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsSISPLAN = new WinForms.DataSet.DsSISPLAN();
            this.sP_PLA_RPT_CMO_DETALLE_VARIOS_MANO_OBRATableAdapter = new WinForms.DataSet.DsSISPLANTableAdapters.SP_PLA_RPT_CMO_DETALLE_VARIOS_MANO_OBRATableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.sPPLARPTCMODETALLEVARIOSMANOOBRABindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsSISPLAN)).BeginInit();
            this.SuspendLayout();
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
            this.label2.Size = new System.Drawing.Size(975, 23);
            this.label2.TabIndex = 39;
            this.label2.Text = "Costo mano de obra";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(9, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 42;
            this.label7.Text = "EMPRESA";
            // 
            // cboEmpresa
            // 
            this.cboEmpresa.FormattingEnabled = true;
            this.cboEmpresa.Location = new System.Drawing.Point(74, 32);
            this.cboEmpresa.Name = "cboEmpresa";
            this.cboEmpresa.Size = new System.Drawing.Size(252, 21);
            this.cboEmpresa.TabIndex = 43;
            this.cboEmpresa.SelectedIndexChanged += new System.EventHandler(this.cboEmpresa_SelectedIndexChanged);
            // 
            // cboCentroCosto
            // 
            this.cboCentroCosto.FormattingEnabled = true;
            this.cboCentroCosto.Location = new System.Drawing.Point(332, 31);
            this.cboCentroCosto.Name = "cboCentroCosto";
            this.cboCentroCosto.Size = new System.Drawing.Size(503, 21);
            this.cboCentroCosto.TabIndex = 44;
            this.cboCentroCosto.SelectedIndexChanged += new System.EventHandler(this.cboCentroCosto_SelectedIndexChanged);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = global::WinForms.Properties.Resources.boton_buscar;
            this.btnBuscar.Location = new System.Drawing.Point(668, 55);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(110, 30);
            this.btnBuscar.TabIndex = 45;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(162, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 46;
            this.label1.Text = "COD SISPLAN";
            // 
            // TxtCodSisplan
            // 
            this.TxtCodSisplan.Enabled = false;
            this.TxtCodSisplan.Location = new System.Drawing.Point(246, 58);
            this.TxtCodSisplan.Name = "TxtCodSisplan";
            this.TxtCodSisplan.Size = new System.Drawing.Size(80, 20);
            this.TxtCodSisplan.TabIndex = 47;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(162, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 48;
            this.label3.Text = "COD PLANILLA";
            // 
            // txtPlanilla
            // 
            this.txtPlanilla.Enabled = false;
            this.txtPlanilla.Location = new System.Drawing.Point(247, 80);
            this.txtPlanilla.Name = "txtPlanilla";
            this.txtPlanilla.Size = new System.Drawing.Size(78, 20);
            this.txtPlanilla.TabIndex = 49;
            // 
            // cboAnio
            // 
            this.cboAnio.FormattingEnabled = true;
            this.cboAnio.Location = new System.Drawing.Point(74, 56);
            this.cboAnio.Name = "cboAnio";
            this.cboAnio.Size = new System.Drawing.Size(82, 21);
            this.cboAnio.TabIndex = 50;
            this.cboAnio.SelectedIndexChanged += new System.EventHandler(this.cboAnio_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 51;
            this.label4.Text = "AÑO";
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(332, 56);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(330, 64);
            this.checkedListBox1.TabIndex = 60;
            // 
            // ReportViewer1
            // 
            this.ReportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.sPPLARPTCMODETALLEVARIOSMANOOBRABindingSource;
            this.ReportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.ReportViewer1.LocalReport.ReportEmbeddedResource = "WinForms.Reportes.RptCostoManoObra.rdlc";
            this.ReportViewer1.Location = new System.Drawing.Point(6, 137);
            this.ReportViewer1.Name = "ReportViewer1";
            this.ReportViewer1.Size = new System.Drawing.Size(983, 246);
            this.ReportViewer1.TabIndex = 61;
            // 
            // sPPLARPTCMODETALLEVARIOSMANOOBRABindingSource
            // 
            this.sPPLARPTCMODETALLEVARIOSMANOOBRABindingSource.DataMember = "SP_PLA_RPT_CMO_DETALLE_VARIOS_MANO_OBRA";
            this.sPPLARPTCMODETALLEVARIOSMANOOBRABindingSource.DataSource = this.dsSISPLAN;
            // 
            // dsSISPLAN
            // 
            this.dsSISPLAN.DataSetName = "DsSISPLAN";
            this.dsSISPLAN.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sP_PLA_RPT_CMO_DETALLE_VARIOS_MANO_OBRATableAdapter
            // 
            this.sP_PLA_RPT_CMO_DETALLE_VARIOS_MANO_OBRATableAdapter.ClearBeforeFill = true;
            // 
            // Rpt_ManoObra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 433);
            this.Controls.Add(this.ReportViewer1);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboAnio);
            this.Controls.Add(this.txtPlanilla);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TxtCodSisplan);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cboEmpresa);
            this.Controls.Add(this.cboCentroCosto);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Rpt_ManoObra";
            this.Text = "Rpt_ManoObra";
            this.Load += new System.EventHandler(this.Rpt_ManoObra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sPPLARPTCMODETALLEVARIOSMANOOBRABindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsSISPLAN)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboEmpresa;
        private System.Windows.Forms.ComboBox cboCentroCosto;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtCodSisplan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPlanilla;
        private System.Windows.Forms.ComboBox cboAnio;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private Microsoft.Reporting.WinForms.ReportViewer ReportViewer1;
        private System.Windows.Forms.BindingSource sPPLARPTCMODETALLEVARIOSMANOOBRABindingSource;
        private DataSet.DsSISPLAN dsSISPLAN;
        private DataSet.DsSISPLANTableAdapters.SP_PLA_RPT_CMO_DETALLE_VARIOS_MANO_OBRATableAdapter sP_PLA_RPT_CMO_DETALLE_VARIOS_MANO_OBRATableAdapter;
    }
}