namespace WinForms
{
    partial class Personal
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
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboEstado = new System.Windows.Forms.ComboBox();
            this.btnListarObreros = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cboEmpresa = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboCentroCosto = new System.Windows.Forms.ComboBox();
            this.btnlistarPersonal = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtApellidos = new System.Windows.Forms.TextBox();
            this.dgvCuadrilla = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.lblAsignado = new System.Windows.Forms.Label();
            this.lblDisponible = new System.Windows.Forms.Label();
            this.btnEstados = new System.Windows.Forms.Button();
            this.checkTodos = new System.Windows.Forms.CheckBox();
            this.dateLiquidado = new System.Windows.Forms.DateTimePicker();
            this.lblFechaLiquidado = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuadrilla)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(1, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1006, 23);
            this.label2.TabIndex = 23;
            this.label2.Text = "Modulo de Personal";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.cboEstado);
            this.groupBox1.Controls.Add(this.btnListarObreros);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cboEmpresa);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cboCentroCosto);
            this.groupBox1.Controls.Add(this.btnlistarPersonal);
            this.groupBox1.Location = new System.Drawing.Point(4, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1003, 91);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            // 
            // cboEstado
            // 
            this.cboEstado.FormattingEnabled = true;
            this.cboEstado.Location = new System.Drawing.Point(197, 33);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(273, 21);
            this.cboEstado.TabIndex = 34;
            this.cboEstado.SelectedIndexChanged += new System.EventHandler(this.cboEstado_SelectedIndexChanged);
            // 
            // btnListarObreros
            // 
            this.btnListarObreros.Image = global::WinForms.Properties.Resources.botonObreros;
            this.btnListarObreros.Location = new System.Drawing.Point(345, 55);
            this.btnListarObreros.Name = "btnListarObreros";
            this.btnListarObreros.Size = new System.Drawing.Size(125, 30);
            this.btnListarObreros.TabIndex = 19;
            this.btnListarObreros.UseVisualStyleBackColor = true;
            this.btnListarObreros.Click += new System.EventHandler(this.btnListarObreros_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "EMPRESA";
            // 
            // cboEmpresa
            // 
            this.cboEmpresa.FormattingEnabled = true;
            this.cboEmpresa.Location = new System.Drawing.Point(71, 13);
            this.cboEmpresa.Name = "cboEmpresa";
            this.cboEmpresa.Size = new System.Drawing.Size(66, 21);
            this.cboEmpresa.TabIndex = 11;
            this.cboEmpresa.SelectedIndexChanged += new System.EventHandler(this.cboEmpresa_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(140, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "C. COSTO";
            // 
            // cboCentroCosto
            // 
            this.cboCentroCosto.FormattingEnabled = true;
            this.cboCentroCosto.Location = new System.Drawing.Point(197, 11);
            this.cboCentroCosto.Name = "cboCentroCosto";
            this.cboCentroCosto.Size = new System.Drawing.Size(780, 21);
            this.cboCentroCosto.TabIndex = 13;
            // 
            // btnlistarPersonal
            // 
            this.btnlistarPersonal.Image = global::WinForms.Properties.Resources.botonEmpleados;
            this.btnlistarPersonal.Location = new System.Drawing.Point(197, 55);
            this.btnlistarPersonal.Name = "btnlistarPersonal";
            this.btnlistarPersonal.Size = new System.Drawing.Size(125, 30);
            this.btnlistarPersonal.TabIndex = 1;
            this.btnlistarPersonal.UseVisualStyleBackColor = true;
            this.btnlistarPersonal.Click += new System.EventHandler(this.btnlistarPersonal_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(198, 123);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(128, 13);
            this.label9.TabIndex = 31;
            this.label9.Text = "BUSQUEDA PERSONAL";
            // 
            // txtApellidos
            // 
            this.txtApellidos.Location = new System.Drawing.Point(201, 140);
            this.txtApellidos.Name = "txtApellidos";
            this.txtApellidos.Size = new System.Drawing.Size(363, 20);
            this.txtApellidos.TabIndex = 26;
            this.txtApellidos.TextChanged += new System.EventHandler(this.txtApellidos_TextChanged);
            // 
            // dgvCuadrilla
            // 
            this.dgvCuadrilla.AllowUserToAddRows = false;
            this.dgvCuadrilla.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCuadrilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCuadrilla.Location = new System.Drawing.Point(13, 166);
            this.dgvCuadrilla.Name = "dgvCuadrilla";
            this.dgvCuadrilla.Size = new System.Drawing.Size(985, 253);
            this.dgvCuadrilla.TabIndex = 42;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 426);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(98, 13);
            this.label8.TabIndex = 45;
            this.label8.Text = "Leyenda Personal :";
            // 
            // lblAsignado
            // 
            this.lblAsignado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAsignado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(247)))), ((int)(((byte)(166)))));
            this.lblAsignado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAsignado.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAsignado.ForeColor = System.Drawing.Color.Black;
            this.lblAsignado.Location = new System.Drawing.Point(240, 422);
            this.lblAsignado.Name = "lblAsignado";
            this.lblAsignado.Size = new System.Drawing.Size(141, 23);
            this.lblAsignado.TabIndex = 44;
            this.lblAsignado.Text = "Asignado";
            this.lblAsignado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDisponible
            // 
            this.lblDisponible.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDisponible.BackColor = System.Drawing.Color.White;
            this.lblDisponible.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDisponible.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisponible.ForeColor = System.Drawing.Color.Black;
            this.lblDisponible.Location = new System.Drawing.Point(108, 422);
            this.lblDisponible.Name = "lblDisponible";
            this.lblDisponible.Size = new System.Drawing.Size(126, 23);
            this.lblDisponible.TabIndex = 43;
            this.lblDisponible.Text = "Disponible";
            this.lblDisponible.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnEstados
            // 
            this.btnEstados.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnEstados.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEstados.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnEstados.Location = new System.Drawing.Point(776, 130);
            this.btnEstados.Name = "btnEstados";
            this.btnEstados.Size = new System.Drawing.Size(222, 30);
            this.btnEstados.TabIndex = 46;
            this.btnEstados.Text = "button1";
            this.btnEstados.UseVisualStyleBackColor = false;
            this.btnEstados.Click += new System.EventHandler(this.btnEstados_Click);
            // 
            // checkTodos
            // 
            this.checkTodos.AutoSize = true;
            this.checkTodos.Location = new System.Drawing.Point(13, 143);
            this.checkTodos.Name = "checkTodos";
            this.checkTodos.Size = new System.Drawing.Size(142, 17);
            this.checkTodos.TabIndex = 47;
            this.checkTodos.Text = "SELECCIONAR TODOS";
            this.checkTodos.UseVisualStyleBackColor = true;
            this.checkTodos.CheckedChanged += new System.EventHandler(this.checkTodos_CheckedChanged);
            // 
            // dateLiquidado
            // 
            this.dateLiquidado.Location = new System.Drawing.Point(570, 138);
            this.dateLiquidado.Name = "dateLiquidado";
            this.dateLiquidado.Size = new System.Drawing.Size(200, 20);
            this.dateLiquidado.TabIndex = 48;
            // 
            // lblFechaLiquidado
            // 
            this.lblFechaLiquidado.AutoSize = true;
            this.lblFechaLiquidado.Location = new System.Drawing.Point(570, 122);
            this.lblFechaLiquidado.Name = "lblFechaLiquidado";
            this.lblFechaLiquidado.Size = new System.Drawing.Size(45, 13);
            this.lblFechaLiquidado.TabIndex = 49;
            this.lblFechaLiquidado.Text = "FECHA ";
            // 
            // Personal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1010, 451);
            this.Controls.Add(this.lblFechaLiquidado);
            this.Controls.Add(this.dateLiquidado);
            this.Controls.Add(this.checkTodos);
            this.Controls.Add(this.btnEstados);
            this.Controls.Add(this.txtApellidos);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblAsignado);
            this.Controls.Add(this.lblDisponible);
            this.Controls.Add(this.dgvCuadrilla);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "Personal";
            this.Text = "Personal ";
            this.Load += new System.EventHandler(this.Personal_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuadrilla)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnListarObreros;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboEmpresa;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboCentroCosto;
        private System.Windows.Forms.Button btnlistarPersonal;
        private System.Windows.Forms.TextBox txtApellidos;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dgvCuadrilla;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblAsignado;
        private System.Windows.Forms.Label lblDisponible;
        private System.Windows.Forms.Button btnEstados;
        private System.Windows.Forms.CheckBox checkTodos;
        private System.Windows.Forms.DateTimePicker dateLiquidado;
        private System.Windows.Forms.Label lblFechaLiquidado;
        private System.Windows.Forms.ComboBox cboEstado;
    }
}