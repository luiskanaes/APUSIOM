namespace WinForms
{
    partial class frmDesmovilizacionTareo
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
            this.lblNombres = new System.Windows.Forms.Label();
            this.dtpFechaDesmovilizacion = new System.Windows.Forms.DateTimePicker();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblNombres
            // 
            this.lblNombres.AutoSize = true;
            this.lblNombres.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombres.Location = new System.Drawing.Point(23, 40);
            this.lblNombres.Name = "lblNombres";
            this.lblNombres.Size = new System.Drawing.Size(52, 17);
            this.lblNombres.TabIndex = 0;
            this.lblNombres.Text = "label1";
            // 
            // dtpFechaDesmovilizacion
            // 
            this.dtpFechaDesmovilizacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaDesmovilizacion.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaDesmovilizacion.Location = new System.Drawing.Point(248, 73);
            this.dtpFechaDesmovilizacion.Name = "dtpFechaDesmovilizacion";
            this.dtpFechaDesmovilizacion.Size = new System.Drawing.Size(95, 23);
            this.dtpFechaDesmovilizacion.TabIndex = 1;
            this.dtpFechaDesmovilizacion.ValueChanged += new System.EventHandler(this.dtpFechaDesmovilizacion_ValueChanged);
            // 
            // btnGrabar
            // 
            this.btnGrabar.Location = new System.Drawing.Point(355, 69);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(107, 29);
            this.btnGrabar.TabIndex = 2;
            this.btnGrabar.Text = "DESMOVILIZAR";
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(224, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "DESMOVILIZAR EMPLEADO";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "ULTIMO DIA EN UBICACION :";
            // 
            // frmDesmovilizacionTareo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 121);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.dtpFechaDesmovilizacion);
            this.Controls.Add(this.lblNombres);
            this.Name = "frmDesmovilizacionTareo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmDesmovilizacionTareo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNombres;
        private System.Windows.Forms.DateTimePicker dtpFechaDesmovilizacion;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}