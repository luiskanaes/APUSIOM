namespace WinForms
{
    partial class frmCambiarResponsables
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
            this.cboCapataces = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cboIngeniero = new System.Windows.Forms.ComboBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.date2 = new System.Windows.Forms.DateTimePicker();
            this.txtDni2 = new System.Windows.Forms.TextBox();
            this.txtpersonal2 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btn2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCodigo2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cboCapataces
            // 
            this.cboCapataces.FormattingEnabled = true;
            this.cboCapataces.Location = new System.Drawing.Point(250, 63);
            this.cboCapataces.Name = "cboCapataces";
            this.cboCapataces.Size = new System.Drawing.Size(350, 21);
            this.cboCapataces.TabIndex = 51;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(8, 66);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(228, 13);
            this.label14.TabIndex = 50;
            this.label14.Text = "RESPONSABLE DE CUADRILLA A RETIRAR";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(110, 42);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(126, 13);
            this.label13.TabIndex = 49;
            this.label13.Text = "INGENIERO DE CAMPO";
            // 
            // cboIngeniero
            // 
            this.cboIngeniero.FormattingEnabled = true;
            this.cboIngeniero.Location = new System.Drawing.Point(250, 39);
            this.cboIngeniero.Name = "cboIngeniero";
            this.cboIngeniero.Size = new System.Drawing.Size(350, 21);
            this.cboIngeniero.TabIndex = 48;
            this.cboIngeniero.SelectedIndexChanged += new System.EventHandler(this.cboIngeniero_SelectedIndexChanged);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Image = global::WinForms.Properties.Resources.boton_guardar;
            this.btnGuardar.Location = new System.Drawing.Point(249, 168);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(110, 30);
            this.btnGuardar.TabIndex = 52;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // date2
            // 
            this.date2.Location = new System.Drawing.Point(250, 142);
            this.date2.Name = "date2";
            this.date2.Size = new System.Drawing.Size(224, 20);
            this.date2.TabIndex = 54;
            // 
            // txtDni2
            // 
            this.txtDni2.Location = new System.Drawing.Point(250, 92);
            this.txtDni2.Name = "txtDni2";
            this.txtDni2.Size = new System.Drawing.Size(79, 20);
            this.txtDni2.TabIndex = 53;
            // 
            // txtpersonal2
            // 
            this.txtpersonal2.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtpersonal2.Enabled = false;
            this.txtpersonal2.Location = new System.Drawing.Point(250, 117);
            this.txtpersonal2.Name = "txtpersonal2";
            this.txtpersonal2.Size = new System.Drawing.Size(350, 20);
            this.txtpersonal2.TabIndex = 55;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(40, 96);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(198, 13);
            this.label9.TabIndex = 56;
            this.label9.Text = "BUSCAR DNI NUEVO ING. DE CAMPO";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(89, 149);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(147, 13);
            this.label7.TabIndex = 57;
            this.label7.Text = "FECHA INICIO DE TRABAJO";
            // 
            // btn2
            // 
            this.btn2.Image = global::WinForms.Properties.Resources.boton_buscar;
            this.btn2.Location = new System.Drawing.Point(334, 85);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(100, 30);
            this.btn2.TabIndex = 58;
            this.btn2.UseVisualStyleBackColor = true;
            this.btn2.Click += new System.EventHandler(this.btn2_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(4, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(595, 23);
            this.label2.TabIndex = 59;
            this.label2.Text = "Cambiar responsable de cuadrilla";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCodigo2
            // 
            this.lblCodigo2.AutoSize = true;
            this.lblCodigo2.Location = new System.Drawing.Point(440, 93);
            this.lblCodigo2.Name = "lblCodigo2";
            this.lblCodigo2.Size = new System.Drawing.Size(41, 13);
            this.lblCodigo2.TabIndex = 60;
            this.lblCodigo2.Text = "label11";
            this.lblCodigo2.Visible = false;
            // 
            // frmCambiarResponsables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 261);
            this.Controls.Add(this.lblCodigo2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtpersonal2);
            this.Controls.Add(this.date2);
            this.Controls.Add(this.txtDni2);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.cboCapataces);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.cboIngeniero);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCambiarResponsables";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmCambiarResponsables";
            this.Load += new System.EventHandler(this.frmCambiarResponsables_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboCapataces;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cboIngeniero;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.DateTimePicker date2;
        private System.Windows.Forms.TextBox txtDni2;
        private System.Windows.Forms.TextBox txtpersonal2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btn2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCodigo2;
    }
}