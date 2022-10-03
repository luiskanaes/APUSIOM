namespace WinForms
{
    partial class frmAsignarNuevoResponsable
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
            this.txtDni1 = new System.Windows.Forms.TextBox();
            this.txtpersonal1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn1 = new System.Windows.Forms.Button();
            this.date1 = new System.Windows.Forms.DateTimePicker();
            this.txtcargo1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtcargo2 = new System.Windows.Forms.TextBox();
            this.date2 = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDni2 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btn2 = new System.Windows.Forms.Button();
            this.btnProcesar = new System.Windows.Forms.Button();
            this.txtpersonal2 = new System.Windows.Forms.TextBox();
            this.lblCodigo1 = new System.Windows.Forms.Label();
            this.lblCodigo2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "PERSONA  A RETIRAR";
            // 
            // txtDni1
            // 
            this.txtDni1.Location = new System.Drawing.Point(12, 45);
            this.txtDni1.Name = "txtDni1";
            this.txtDni1.Size = new System.Drawing.Size(79, 20);
            this.txtDni1.TabIndex = 1;
            // 
            // txtpersonal1
            // 
            this.txtpersonal1.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtpersonal1.Enabled = false;
            this.txtpersonal1.Location = new System.Drawing.Point(317, 42);
            this.txtpersonal1.Name = "txtpersonal1";
            this.txtpersonal1.Size = new System.Drawing.Size(224, 20);
            this.txtpersonal1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Dni";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(314, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Personal";
            // 
            // btn1
            // 
            this.btn1.Image = global::WinForms.Properties.Resources.boton_buscar;
            this.btn1.Location = new System.Drawing.Point(770, 36);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(100, 30);
            this.btn1.TabIndex = 5;
            this.btn1.UseVisualStyleBackColor = true;
            this.btn1.Click += new System.EventHandler(this.btn1_Click);
            // 
            // date1
            // 
            this.date1.Location = new System.Drawing.Point(108, 42);
            this.date1.Name = "date1";
            this.date1.Size = new System.Drawing.Size(200, 20);
            this.date1.TabIndex = 6;
            // 
            // txtcargo1
            // 
            this.txtcargo1.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtcargo1.Enabled = false;
            this.txtcargo1.Location = new System.Drawing.Point(547, 42);
            this.txtcargo1.Name = "txtcargo1";
            this.txtcargo1.Size = new System.Drawing.Size(198, 20);
            this.txtcargo1.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(108, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Fecha último día de trabajo";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(546, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Cargo";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(544, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Cargo";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(108, 88);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(133, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Fecha inicio día de trabajo";
            // 
            // txtcargo2
            // 
            this.txtcargo2.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtcargo2.Enabled = false;
            this.txtcargo2.Location = new System.Drawing.Point(547, 104);
            this.txtcargo2.Name = "txtcargo2";
            this.txtcargo2.Size = new System.Drawing.Size(198, 20);
            this.txtcargo2.TabIndex = 16;
            // 
            // date2
            // 
            this.date2.Location = new System.Drawing.Point(108, 104);
            this.date2.Name = "date2";
            this.date2.Size = new System.Drawing.Size(200, 20);
            this.date2.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(314, 91);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Personal";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 91);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(23, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "Dni";
            // 
            // txtDni2
            // 
            this.txtDni2.Location = new System.Drawing.Point(12, 107);
            this.txtDni2.Name = "txtDni2";
            this.txtDni2.Size = new System.Drawing.Size(79, 20);
            this.txtDni2.TabIndex = 11;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 71);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(127, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "NUEVO RESPONSABLE";
            // 
            // btn2
            // 
            this.btn2.Image = global::WinForms.Properties.Resources.boton_buscar;
            this.btn2.Location = new System.Drawing.Point(770, 91);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(100, 30);
            this.btn2.TabIndex = 19;
            this.btn2.UseVisualStyleBackColor = true;
            this.btn2.Click += new System.EventHandler(this.btn2_Click);
            // 
            // btnProcesar
            // 
            this.btnProcesar.Location = new System.Drawing.Point(324, 150);
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(204, 53);
            this.btnProcesar.TabIndex = 20;
            this.btnProcesar.Text = "PROCESAR ASIGNACIÓN";
            this.btnProcesar.UseVisualStyleBackColor = true;
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
            // 
            // txtpersonal2
            // 
            this.txtpersonal2.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtpersonal2.Enabled = false;
            this.txtpersonal2.Location = new System.Drawing.Point(317, 104);
            this.txtpersonal2.Name = "txtpersonal2";
            this.txtpersonal2.Size = new System.Drawing.Size(224, 20);
            this.txtpersonal2.TabIndex = 21;
            // 
            // lblCodigo1
            // 
            this.lblCodigo1.AutoSize = true;
            this.lblCodigo1.Location = new System.Drawing.Point(549, 70);
            this.lblCodigo1.Name = "lblCodigo1";
            this.lblCodigo1.Size = new System.Drawing.Size(41, 13);
            this.lblCodigo1.TabIndex = 22;
            this.lblCodigo1.Text = "label11";
            this.lblCodigo1.Visible = false;
            // 
            // lblCodigo2
            // 
            this.lblCodigo2.AutoSize = true;
            this.lblCodigo2.Location = new System.Drawing.Point(549, 127);
            this.lblCodigo2.Name = "lblCodigo2";
            this.lblCodigo2.Size = new System.Drawing.Size(41, 13);
            this.lblCodigo2.TabIndex = 23;
            this.lblCodigo2.Text = "label11";
            this.lblCodigo2.Visible = false;
            // 
            // frmAsignarNuevoResponsable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 229);
            this.Controls.Add(this.lblCodigo2);
            this.Controls.Add(this.lblCodigo1);
            this.Controls.Add(this.txtpersonal2);
            this.Controls.Add(this.btnProcesar);
            this.Controls.Add(this.btn2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtcargo2);
            this.Controls.Add(this.date2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtDni2);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtcargo1);
            this.Controls.Add(this.date1);
            this.Controls.Add(this.btn1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtpersonal1);
            this.Controls.Add(this.txtDni1);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAsignarNuevoResponsable";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAsignarNuevoResponsable";
            this.Load += new System.EventHandler(this.frmAsignarNuevoResponsable_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDni1;
        private System.Windows.Forms.TextBox txtpersonal1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.DateTimePicker date1;
        private System.Windows.Forms.TextBox txtcargo1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtcargo2;
        private System.Windows.Forms.DateTimePicker date2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtDni2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btn2;
        private System.Windows.Forms.Button btnProcesar;
        private System.Windows.Forms.TextBox txtpersonal2;
        private System.Windows.Forms.Label lblCodigo1;
        private System.Windows.Forms.Label lblCodigo2;
    }
}