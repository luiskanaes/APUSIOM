namespace WinForms.TareoPersonal
{
    partial class frmMigrar_Empleados
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
            this.label1 = new System.Windows.Forms.Label();
            this.cboUbicacion = new System.Windows.Forms.ComboBox();
            this.btnlistarPersonal = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.checkPersona = new System.Windows.Forms.CheckBox();
            this.dgvPersonal = new System.Windows.Forms.DataGridView();
            this.btnAgregar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonal)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(73, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "UBICACION:";
            // 
            // cboUbicacion
            // 
            this.cboUbicacion.FormattingEnabled = true;
            this.cboUbicacion.Location = new System.Drawing.Point(152, 6);
            this.cboUbicacion.Name = "cboUbicacion";
            this.cboUbicacion.Size = new System.Drawing.Size(422, 21);
            this.cboUbicacion.TabIndex = 4;
            // 
            // btnlistarPersonal
            // 
            this.btnlistarPersonal.Image = global::WinForms.Properties.Resources.botonEmpleados;
            this.btnlistarPersonal.Location = new System.Drawing.Point(580, 25);
            this.btnlistarPersonal.Name = "btnlistarPersonal";
            this.btnlistarPersonal.Size = new System.Drawing.Size(125, 30);
            this.btnlistarPersonal.TabIndex = 6;
            this.btnlistarPersonal.UseVisualStyleBackColor = true;
            this.btnlistarPersonal.Click += new System.EventHandler(this.btnlistarPersonal_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(153, 31);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(422, 23);
            this.progressBar1.TabIndex = 53;
            // 
            // txtDni
            // 
            this.txtDni.Location = new System.Drawing.Point(155, 58);
            this.txtDni.Name = "txtDni";
            this.txtDni.ReadOnly = true;
            this.txtDni.Size = new System.Drawing.Size(260, 20);
            this.txtDni.TabIndex = 55;
            // 
            // checkPersona
            // 
            this.checkPersona.AutoSize = true;
            this.checkPersona.Location = new System.Drawing.Point(7, 59);
            this.checkPersona.Name = "checkPersona";
            this.checkPersona.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkPersona.Size = new System.Drawing.Size(147, 17);
            this.checkPersona.TabIndex = 54;
            this.checkPersona.Text = "BUSCAR DNI PERSONA";
            this.checkPersona.UseVisualStyleBackColor = true;
            this.checkPersona.CheckedChanged += new System.EventHandler(this.checkPersona_CheckedChanged);
            // 
            // dgvPersonal
            // 
            this.dgvPersonal.AllowUserToAddRows = false;
            this.dgvPersonal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPersonal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPersonal.Location = new System.Drawing.Point(7, 84);
            this.dgvPersonal.Name = "dgvPersonal";
            this.dgvPersonal.Size = new System.Drawing.Size(957, 409);
            this.dgvPersonal.TabIndex = 56;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Image = global::WinForms.Properties.Resources.boton_AgregarPersonal;
            this.btnAgregar.Location = new System.Drawing.Point(711, 25);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(139, 30);
            this.btnAgregar.TabIndex = 57;
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // frmMigrar_Empleados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 505);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.dgvPersonal);
            this.Controls.Add(this.txtDni);
            this.Controls.Add(this.checkPersona);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnlistarPersonal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboUbicacion);
            this.Name = "frmMigrar_Empleados";
            this.Text = "frmMigrar_Empleados";
            this.Load += new System.EventHandler(this.frmMigrar_Empleados_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboUbicacion;
        private System.Windows.Forms.Button btnlistarPersonal;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.CheckBox checkPersona;
        private System.Windows.Forms.DataGridView dgvPersonal;
        private System.Windows.Forms.Button btnAgregar;
    }
}