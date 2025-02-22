namespace FarmaciaPilas
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnIngresarLote = new System.Windows.Forms.Button();
            this.cmbTipoMedicina1 = new System.Windows.Forms.ComboBox();
            this.txtTotalUnidades = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSolicitar = new System.Windows.Forms.Button();
            this.cmbTipoMedicina2 = new System.Windows.Forms.ComboBox();
            this.txtCantidadRetirar = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lstPilaBodega = new System.Windows.Forms.ListBox();
            this.lstPilaCajasVacias = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnIngresarLote);
            this.groupBox1.Controls.Add(this.cmbTipoMedicina1);
            this.groupBox1.Controls.Add(this.txtTotalUnidades);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(300, 150);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Registro de Caja de Medicamentos";
            // 
            // btnIngresarLote
            // 
            this.btnIngresarLote.Location = new System.Drawing.Point(21, 111);
            this.btnIngresarLote.Name = "btnIngresarLote";
            this.btnIngresarLote.Size = new System.Drawing.Size(273, 23);
            this.btnIngresarLote.TabIndex = 4;
            this.btnIngresarLote.Text = "Ingresar Lote";
            this.btnIngresarLote.Click += new System.EventHandler(this.btnIngresarLote_Click);
            // 
            // cmbTipoMedicina1
            // 
            this.cmbTipoMedicina1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoMedicina1.FormattingEnabled = true;
            this.cmbTipoMedicina1.Items.AddRange(new object[] {
            "A",
            "B",
            "C"});
            this.cmbTipoMedicina1.Location = new System.Drawing.Point(113, 54);
            this.cmbTipoMedicina1.Name = "cmbTipoMedicina1";
            this.cmbTipoMedicina1.Size = new System.Drawing.Size(181, 21);
            this.cmbTipoMedicina1.TabIndex = 3;
            // 
            // txtTotalUnidades
            // 
            this.txtTotalUnidades.Location = new System.Drawing.Point(113, 23);
            this.txtTotalUnidades.Name = "txtTotalUnidades";
            this.txtTotalUnidades.Size = new System.Drawing.Size(181, 20);
            this.txtTotalUnidades.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tipo Medicina:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Total de unidades:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSolicitar);
            this.groupBox2.Controls.Add(this.cmbTipoMedicina2);
            this.groupBox2.Controls.Add(this.txtCantidadRetirar);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(12, 168);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(300, 150);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Solicitud de Medicinas";
            // 
            // btnSolicitar
            // 
            this.btnSolicitar.Location = new System.Drawing.Point(15, 112);
            this.btnSolicitar.Name = "btnSolicitar";
            this.btnSolicitar.Size = new System.Drawing.Size(279, 23);
            this.btnSolicitar.TabIndex = 4;
            this.btnSolicitar.Text = "Solicitar";
            this.btnSolicitar.Click += new System.EventHandler(this.btnSolicitar_Click);
            // 
            // cmbTipoMedicina2
            // 
            this.cmbTipoMedicina2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoMedicina2.FormattingEnabled = true;
            this.cmbTipoMedicina2.Items.AddRange(new object[] {
            "A",
            "B",
            "C"});
            this.cmbTipoMedicina2.Location = new System.Drawing.Point(136, 49);
            this.cmbTipoMedicina2.Name = "cmbTipoMedicina2";
            this.cmbTipoMedicina2.Size = new System.Drawing.Size(158, 21);
            this.cmbTipoMedicina2.TabIndex = 3;
            // 
            // txtCantidadRetirar
            // 
            this.txtCantidadRetirar.Location = new System.Drawing.Point(182, 19);
            this.txtCantidadRetirar.Name = "txtCantidadRetirar";
            this.txtCantidadRetirar.Size = new System.Drawing.Size(112, 20);
            this.txtCantidadRetirar.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(53, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Tipo Medicina:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(164, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "¿Cantidad de medicinas a retirar?";
            // 
            // lstPilaBodega
            // 
            this.lstPilaBodega.FormattingEnabled = true;
            this.lstPilaBodega.Location = new System.Drawing.Point(318, 28);
            this.lstPilaBodega.Name = "lstPilaBodega";
            this.lstPilaBodega.Size = new System.Drawing.Size(250, 134);
            this.lstPilaBodega.TabIndex = 2;
            // 
            // lstPilaCajasVacias
            // 
            this.lstPilaCajasVacias.FormattingEnabled = true;
            this.lstPilaCajasVacias.Location = new System.Drawing.Point(318, 184);
            this.lstPilaCajasVacias.Name = "lstPilaCajasVacias";
            this.lstPilaCajasVacias.Size = new System.Drawing.Size(250, 134);
            this.lstPilaCajasVacias.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(315, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Pila de Bodega";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(315, 168);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Pila de Cajas Vacias";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 331);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lstPilaCajasVacias);
            this.Controls.Add(this.lstPilaBodega);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Aplicacion de TAD Pilas";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnIngresarLote;
        private System.Windows.Forms.ComboBox cmbTipoMedicina1;
        private System.Windows.Forms.TextBox txtTotalUnidades;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSolicitar;
        private System.Windows.Forms.ComboBox cmbTipoMedicina2;
        private System.Windows.Forms.TextBox txtCantidadRetirar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lstPilaBodega;
        private System.Windows.Forms.ListBox lstPilaCajasVacias;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}