namespace ProyectoFinalBaseDeDatos
{
    partial class FormReportes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReportes));
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtMesR1 = new System.Windows.Forms.TextBox();
            this.txtAnioR1 = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtpFinalR2 = new System.Windows.Forms.DateTimePicker();
            this.dtpInicialR2 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvReportes = new System.Windows.Forms.DataGridView();
            this.btnMostrarR1 = new System.Windows.Forms.Button();
            this.btnMostrarR2 = new System.Windows.Forms.Button();
            this.btnTerminar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReportes)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "1. Reporte de ventas por empleado";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Año";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 20);
            this.label6.TabIndex = 13;
            this.label6.Text = "Mes";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel1.Controls.Add(this.txtMesR1);
            this.panel1.Controls.Add(this.txtAnioR1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(225, 100);
            this.panel1.TabIndex = 14;
            // 
            // txtMesR1
            // 
            this.txtMesR1.AccessibleName = "txtMesR1";
            this.txtMesR1.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMesR1.Location = new System.Drawing.Point(42, 73);
            this.txtMesR1.Name = "txtMesR1";
            this.txtMesR1.Size = new System.Drawing.Size(150, 22);
            this.txtMesR1.TabIndex = 15;
            // 
            // txtAnioR1
            // 
            this.txtAnioR1.AccessibleName = "txtAnioR1";
            this.txtAnioR1.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAnioR1.Location = new System.Drawing.Point(42, 41);
            this.txtAnioR1.Name = "txtAnioR1";
            this.txtAnioR1.Size = new System.Drawing.Size(150, 22);
            this.txtAnioR1.TabIndex = 14;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel2.Controls.Add(this.dtpFinalR2);
            this.panel2.Controls.Add(this.dtpInicialR2);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(260, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(317, 100);
            this.panel2.TabIndex = 15;
            // 
            // dtpFinalR2
            // 
            this.dtpFinalR2.AccessibleName = "dtpFinalR2";
            this.dtpFinalR2.Location = new System.Drawing.Point(101, 73);
            this.dtpFinalR2.Name = "dtpFinalR2";
            this.dtpFinalR2.Size = new System.Drawing.Size(200, 20);
            this.dtpFinalR2.TabIndex = 15;
            // 
            // dtpInicialR2
            // 
            this.dtpInicialR2.AccessibleName = "dtpInicialR2";
            this.dtpInicialR2.Location = new System.Drawing.Point(101, 41);
            this.dtpInicialR2.Name = "dtpInicialR2";
            this.dtpInicialR2.Size = new System.Drawing.Size(200, 20);
            this.dtpInicialR2.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(206, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "2. Reporte de ventas por periodo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 20);
            this.label4.TabIndex = 13;
            this.label4.Text = "Fecha final";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Fecha inicial";
            // 
            // dgvReportes
            // 
            this.dgvReportes.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvReportes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReportes.Location = new System.Drawing.Point(12, 176);
            this.dgvReportes.Name = "dgvReportes";
            this.dgvReportes.Size = new System.Drawing.Size(678, 256);
            this.dgvReportes.TabIndex = 16;
            // 
            // btnMostrarR1
            // 
            this.btnMostrarR1.AccessibleName = "btnMostrarR1";
            this.btnMostrarR1.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMostrarR1.Location = new System.Drawing.Point(19, 130);
            this.btnMostrarR1.Name = "btnMostrarR1";
            this.btnMostrarR1.Size = new System.Drawing.Size(117, 23);
            this.btnMostrarR1.TabIndex = 17;
            this.btnMostrarR1.Text = "Mostrar Reporte 1";
            this.btnMostrarR1.UseVisualStyleBackColor = true;
            this.btnMostrarR1.Click += new System.EventHandler(this.BtnMostrarR1_Click);
            // 
            // btnMostrarR2
            // 
            this.btnMostrarR2.AccessibleName = "btnMostrarR2";
            this.btnMostrarR2.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMostrarR2.Location = new System.Drawing.Point(259, 130);
            this.btnMostrarR2.Name = "btnMostrarR2";
            this.btnMostrarR2.Size = new System.Drawing.Size(122, 23);
            this.btnMostrarR2.TabIndex = 18;
            this.btnMostrarR2.Text = "Mostrar Reporte 2";
            this.btnMostrarR2.UseVisualStyleBackColor = true;
            this.btnMostrarR2.Click += new System.EventHandler(this.BtnMostrarR2_Click);
            // 
            // btnTerminar
            // 
            this.btnTerminar.AccessibleName = "btnTerminar";
            this.btnTerminar.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTerminar.Location = new System.Drawing.Point(615, 50);
            this.btnTerminar.Name = "btnTerminar";
            this.btnTerminar.Size = new System.Drawing.Size(75, 36);
            this.btnTerminar.TabIndex = 19;
            this.btnTerminar.Text = "Terminar";
            this.btnTerminar.UseVisualStyleBackColor = true;
            this.btnTerminar.Click += new System.EventHandler(this.BtnTerminar_Click);
            // 
            // FormReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(704, 453);
            this.Controls.Add(this.btnTerminar);
            this.Controls.Add(this.btnMostrarR2);
            this.Controls.Add(this.btnMostrarR1);
            this.Controls.Add(this.dgvReportes);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormReportes";
            this.Text = "Reportes";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReportes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtMesR1;
        private System.Windows.Forms.TextBox txtAnioR1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DateTimePicker dtpFinalR2;
        private System.Windows.Forms.DateTimePicker dtpInicialR2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvReportes;
        private System.Windows.Forms.Button btnMostrarR1;
        private System.Windows.Forms.Button btnMostrarR2;
        private System.Windows.Forms.Button btnTerminar;
    }
}