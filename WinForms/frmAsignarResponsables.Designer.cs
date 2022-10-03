namespace WinForms
{
    partial class frmAsignarResponsables
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
            this.btnGuardar = new System.Windows.Forms.Button();
            this.gridDetalle = new System.Windows.Forms.DataGridView();
            this.label13 = new System.Windows.Forms.Label();
            this.cboIngeniero = new System.Windows.Forms.ComboBox();
            this.cboCapataces = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetalle)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGuardar
            // 
            this.btnGuardar.Image = global::WinForms.Properties.Resources.boton_guardar;
            this.btnGuardar.Location = new System.Drawing.Point(12, 219);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(110, 30);
            this.btnGuardar.TabIndex = 3;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // gridDetalle
            // 
            this.gridDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridDetalle.Location = new System.Drawing.Point(12, 70);
            this.gridDetalle.Name = "gridDetalle";
            this.gridDetalle.Size = new System.Drawing.Size(522, 143);
            this.gridDetalle.TabIndex = 4;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(52, 9);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(126, 13);
            this.label13.TabIndex = 16;
            this.label13.Text = "INGENIERO DE CAMPO";
            // 
            // cboIngeniero
            // 
            this.cboIngeniero.FormattingEnabled = true;
            this.cboIngeniero.Location = new System.Drawing.Point(184, 6);
            this.cboIngeniero.Name = "cboIngeniero";
            this.cboIngeniero.Size = new System.Drawing.Size(350, 21);
            this.cboIngeniero.TabIndex = 15;
            this.cboIngeniero.SelectedIndexChanged += new System.EventHandler(this.cboIngeniero_SelectedIndexChanged);
            // 
            // cboCapataces
            // 
            this.cboCapataces.FormattingEnabled = true;
            this.cboCapataces.Location = new System.Drawing.Point(184, 30);
            this.cboCapataces.Name = "cboCapataces";
            this.cboCapataces.Size = new System.Drawing.Size(350, 21);
            this.cboCapataces.TabIndex = 47;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(9, 33);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(167, 13);
            this.label14.TabIndex = 46;
            this.label14.Text = "RESPONSABLE DE CUADRILLA";
            // 
            // frmAsignarResponsables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 261);
            this.Controls.Add(this.cboCapataces);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.cboIngeniero);
            this.Controls.Add(this.gridDetalle);
            this.Controls.Add(this.btnGuardar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAsignarResponsables";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAsignarResponsables";
            this.Load += new System.EventHandler(this.frmAsignarResponsables_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridDetalle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.DataGridView gridDetalle;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cboIngeniero;
        private System.Windows.Forms.ComboBox cboCapataces;
        private System.Windows.Forms.Label label14;
    }
}