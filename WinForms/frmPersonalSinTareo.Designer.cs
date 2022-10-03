namespace WinForms
{
    partial class frmPersonalSinTareo
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblCabecera = new System.Windows.Forms.Label();
            this.checkTodos = new System.Windows.Forms.CheckBox();
            this.btnFaltos = new System.Windows.Forms.Button();
            this.btnBajada = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnSuspendio = new System.Windows.Forms.Button();
            this.btnPermiso = new System.Windows.Forms.Button();
            this.btnObservado = new System.Windows.Forms.Button();
            this.btnLSGH = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 72);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(771, 302);
            this.dataGridView1.TabIndex = 0;
            // 
            // lblCabecera
            // 
            this.lblCabecera.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCabecera.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblCabecera.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCabecera.ForeColor = System.Drawing.Color.White;
            this.lblCabecera.Location = new System.Drawing.Point(9, 9);
            this.lblCabecera.Name = "lblCabecera";
            this.lblCabecera.Size = new System.Drawing.Size(774, 23);
            this.lblCabecera.TabIndex = 21;
            this.lblCabecera.Text = "Personal sin Tareo";
            this.lblCabecera.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // checkTodos
            // 
            this.checkTodos.AutoSize = true;
            this.checkTodos.Location = new System.Drawing.Point(11, 42);
            this.checkTodos.Name = "checkTodos";
            this.checkTodos.Size = new System.Drawing.Size(64, 17);
            this.checkTodos.TabIndex = 48;
            this.checkTodos.Text = "TODOS";
            this.checkTodos.UseVisualStyleBackColor = true;
            this.checkTodos.CheckedChanged += new System.EventHandler(this.checkTodos_CheckedChanged);
            // 
            // btnFaltos
            // 
            this.btnFaltos.Location = new System.Drawing.Point(67, 36);
            this.btnFaltos.Name = "btnFaltos";
            this.btnFaltos.Size = new System.Drawing.Size(100, 30);
            this.btnFaltos.TabIndex = 49;
            this.btnFaltos.Text = "FALTA";
            this.btnFaltos.UseVisualStyleBackColor = true;
            this.btnFaltos.Click += new System.EventHandler(this.btnFaltos_Click);
            // 
            // btnBajada
            // 
            this.btnBajada.Location = new System.Drawing.Point(170, 36);
            this.btnBajada.Name = "btnBajada";
            this.btnBajada.Size = new System.Drawing.Size(100, 30);
            this.btnBajada.TabIndex = 50;
            this.btnBajada.Text = "BAJADA";
            this.btnBajada.UseVisualStyleBackColor = true;
            this.btnBajada.Click += new System.EventHandler(this.btnBajada_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(272, 36);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 30);
            this.button1.TabIndex = 51;
            this.button1.Text = "ENFERMO";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnSuspendio
            // 
            this.btnSuspendio.Location = new System.Drawing.Point(373, 36);
            this.btnSuspendio.Name = "btnSuspendio";
            this.btnSuspendio.Size = new System.Drawing.Size(100, 30);
            this.btnSuspendio.TabIndex = 52;
            this.btnSuspendio.Text = "SUSPENDIDO";
            this.btnSuspendio.UseVisualStyleBackColor = true;
            this.btnSuspendio.Click += new System.EventHandler(this.btnSuspendio_Click);
            // 
            // btnPermiso
            // 
            this.btnPermiso.Location = new System.Drawing.Point(475, 36);
            this.btnPermiso.Name = "btnPermiso";
            this.btnPermiso.Size = new System.Drawing.Size(100, 30);
            this.btnPermiso.TabIndex = 53;
            this.btnPermiso.Text = "PERMISOS";
            this.btnPermiso.UseVisualStyleBackColor = true;
            this.btnPermiso.Click += new System.EventHandler(this.btnPermiso_Click);
            // 
            // btnObservado
            // 
            this.btnObservado.Location = new System.Drawing.Point(577, 36);
            this.btnObservado.Name = "btnObservado";
            this.btnObservado.Size = new System.Drawing.Size(100, 30);
            this.btnObservado.TabIndex = 54;
            this.btnObservado.Text = "OBSERVADO";
            this.btnObservado.UseVisualStyleBackColor = true;
            this.btnObservado.Click += new System.EventHandler(this.btnObservado_Click);
            // 
            // btnLSGH
            // 
            this.btnLSGH.Location = new System.Drawing.Point(680, 36);
            this.btnLSGH.Name = "btnLSGH";
            this.btnLSGH.Size = new System.Drawing.Size(100, 30);
            this.btnLSGH.TabIndex = 55;
            this.btnLSGH.Text = "LSGH";
            this.btnLSGH.UseVisualStyleBackColor = true;
            this.btnLSGH.Click += new System.EventHandler(this.btnLSGH_Click);
            // 
            // frmPersonalSinTareo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 386);
            this.Controls.Add(this.btnLSGH);
            this.Controls.Add(this.btnObservado);
            this.Controls.Add(this.btnPermiso);
            this.Controls.Add(this.btnSuspendio);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnBajada);
            this.Controls.Add(this.btnFaltos);
            this.Controls.Add(this.checkTodos);
            this.Controls.Add(this.lblCabecera);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPersonalSinTareo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Personal";
            this.Load += new System.EventHandler(this.frmPersonalSinTareo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblCabecera;
        private System.Windows.Forms.CheckBox checkTodos;
        private System.Windows.Forms.Button btnFaltos;
        private System.Windows.Forms.Button btnBajada;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnSuspendio;
        private System.Windows.Forms.Button btnPermiso;
        private System.Windows.Forms.Button btnObservado;
        private System.Windows.Forms.Button btnLSGH;
    }
}