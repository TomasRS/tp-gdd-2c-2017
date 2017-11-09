namespace PagoAgilFrba.Rendicion
{
    partial class RendicionFacturas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RendicionFacturas));
            this.datosFacturaGroupBox = new System.Windows.Forms.GroupBox();
            this.fechaFinDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.fechaInicioDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.porcentajeComisionTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buscarFacturaButton = new System.Windows.Forms.Button();
            this.empresaComboBox = new System.Windows.Forms.ComboBox();
            this.empresaLabel = new System.Windows.Forms.Label();
            this.numFacturaLabel = new System.Windows.Forms.Label();
            this.facturasDataGridView = new System.Windows.Forms.DataGridView();
            this.volverButton = new System.Windows.Forms.Button();
            this.limpiarButton = new System.Windows.Forms.Button();
            this.rendirFacturasButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.importeComisionTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.datosFacturaGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.facturasDataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // datosFacturaGroupBox
            // 
            this.datosFacturaGroupBox.Controls.Add(this.fechaFinDateTimePicker);
            this.datosFacturaGroupBox.Controls.Add(this.fechaInicioDateTimePicker);
            this.datosFacturaGroupBox.Controls.Add(this.porcentajeComisionTextBox);
            this.datosFacturaGroupBox.Controls.Add(this.label2);
            this.datosFacturaGroupBox.Controls.Add(this.label1);
            this.datosFacturaGroupBox.Controls.Add(this.buscarFacturaButton);
            this.datosFacturaGroupBox.Controls.Add(this.empresaComboBox);
            this.datosFacturaGroupBox.Controls.Add(this.empresaLabel);
            this.datosFacturaGroupBox.Controls.Add(this.numFacturaLabel);
            this.datosFacturaGroupBox.Location = new System.Drawing.Point(12, 12);
            this.datosFacturaGroupBox.Name = "datosFacturaGroupBox";
            this.datosFacturaGroupBox.Size = new System.Drawing.Size(677, 151);
            this.datosFacturaGroupBox.TabIndex = 1;
            this.datosFacturaGroupBox.TabStop = false;
            this.datosFacturaGroupBox.Text = "Datos para buscar facturas pagas para rendir";
            // 
            // fechaFinDateTimePicker
            // 
            this.fechaFinDateTimePicker.Location = new System.Drawing.Point(457, 25);
            this.fechaFinDateTimePicker.Name = "fechaFinDateTimePicker";
            this.fechaFinDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.fechaFinDateTimePicker.TabIndex = 42;
            // 
            // fechaInicioDateTimePicker
            // 
            this.fechaInicioDateTimePicker.Location = new System.Drawing.Point(106, 25);
            this.fechaInicioDateTimePicker.Name = "fechaInicioDateTimePicker";
            this.fechaInicioDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.fechaInicioDateTimePicker.TabIndex = 41;
            // 
            // porcentajeComisionTextBox
            // 
            this.porcentajeComisionTextBox.Enabled = false;
            this.porcentajeComisionTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.porcentajeComisionTextBox.Location = new System.Drawing.Point(457, 66);
            this.porcentajeComisionTextBox.Name = "porcentajeComisionTextBox";
            this.porcentajeComisionTextBox.ReadOnly = true;
            this.porcentajeComisionTextBox.Size = new System.Drawing.Size(200, 20);
            this.porcentajeComisionTextBox.TabIndex = 40;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(338, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 39;
            this.label2.Text = "Porcentaje comisión";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(338, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 37;
            this.label1.Text = "Fecha de fin";
            // 
            // buscarFacturaButton
            // 
            this.buscarFacturaButton.Location = new System.Drawing.Point(287, 104);
            this.buscarFacturaButton.Name = "buscarFacturaButton";
            this.buscarFacturaButton.Size = new System.Drawing.Size(100, 30);
            this.buscarFacturaButton.TabIndex = 35;
            this.buscarFacturaButton.Text = "Buscar facturas";
            this.buscarFacturaButton.UseVisualStyleBackColor = true;
            this.buscarFacturaButton.Click += new System.EventHandler(this.buscarFacturaButton_Click);
            // 
            // empresaComboBox
            // 
            this.empresaComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.empresaComboBox.FormattingEnabled = true;
            this.empresaComboBox.Location = new System.Drawing.Point(106, 66);
            this.empresaComboBox.Name = "empresaComboBox";
            this.empresaComboBox.Size = new System.Drawing.Size(200, 21);
            this.empresaComboBox.TabIndex = 3;
            this.empresaComboBox.SelectedIndexChanged += new System.EventHandler(this.empresaComboBox_SelectedIndexChanged);
            // 
            // empresaLabel
            // 
            this.empresaLabel.AutoSize = true;
            this.empresaLabel.Location = new System.Drawing.Point(6, 69);
            this.empresaLabel.Name = "empresaLabel";
            this.empresaLabel.Size = new System.Drawing.Size(48, 13);
            this.empresaLabel.TabIndex = 1;
            this.empresaLabel.Text = "Empresa";
            // 
            // numFacturaLabel
            // 
            this.numFacturaLabel.AutoSize = true;
            this.numFacturaLabel.Location = new System.Drawing.Point(6, 31);
            this.numFacturaLabel.Name = "numFacturaLabel";
            this.numFacturaLabel.Size = new System.Drawing.Size(79, 13);
            this.numFacturaLabel.TabIndex = 0;
            this.numFacturaLabel.Text = "Fecha de inicio";
            // 
            // facturasDataGridView
            // 
            this.facturasDataGridView.AllowUserToAddRows = false;
            this.facturasDataGridView.AllowUserToDeleteRows = false;
            this.facturasDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.facturasDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.facturasDataGridView.Location = new System.Drawing.Point(12, 169);
            this.facturasDataGridView.Name = "facturasDataGridView";
            this.facturasDataGridView.ReadOnly = true;
            this.facturasDataGridView.Size = new System.Drawing.Size(677, 228);
            this.facturasDataGridView.TabIndex = 36;
            // 
            // volverButton
            // 
            this.volverButton.Location = new System.Drawing.Point(588, 481);
            this.volverButton.Name = "volverButton";
            this.volverButton.Size = new System.Drawing.Size(100, 30);
            this.volverButton.TabIndex = 42;
            this.volverButton.Text = "Volver";
            this.volverButton.UseVisualStyleBackColor = true;
            this.volverButton.Click += new System.EventHandler(this.volverButton_Click);
            // 
            // limpiarButton
            // 
            this.limpiarButton.Location = new System.Drawing.Point(12, 481);
            this.limpiarButton.Name = "limpiarButton";
            this.limpiarButton.Size = new System.Drawing.Size(100, 30);
            this.limpiarButton.TabIndex = 41;
            this.limpiarButton.Text = "Limpiar";
            this.limpiarButton.UseVisualStyleBackColor = true;
            this.limpiarButton.Click += new System.EventHandler(this.limpiarButton_Click);
            // 
            // rendirFacturasButton
            // 
            this.rendirFacturasButton.Location = new System.Drawing.Point(299, 481);
            this.rendirFacturasButton.Name = "rendirFacturasButton";
            this.rendirFacturasButton.Size = new System.Drawing.Size(100, 30);
            this.rendirFacturasButton.TabIndex = 43;
            this.rendirFacturasButton.Text = "Rendir facturas";
            this.rendirFacturasButton.UseVisualStyleBackColor = true;
            this.rendirFacturasButton.Click += new System.EventHandler(this.rendirFacturasButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.importeComisionTextBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 403);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(676, 66);
            this.groupBox1.TabIndex = 44;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos sobre la rendición";
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(490, 28);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(141, 20);
            this.textBox1.TabIndex = 44;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(338, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 13);
            this.label4.TabIndex = 43;
            this.label4.Text = "Importe total de la rendición";
            // 
            // importeComisionTextBox
            // 
            this.importeComisionTextBox.Enabled = false;
            this.importeComisionTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.importeComisionTextBox.Location = new System.Drawing.Point(144, 28);
            this.importeComisionTextBox.Name = "importeComisionTextBox";
            this.importeComisionTextBox.ReadOnly = true;
            this.importeComisionTextBox.Size = new System.Drawing.Size(141, 20);
            this.importeComisionTextBox.TabIndex = 42;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 13);
            this.label3.TabIndex = 41;
            this.label3.Text = "Importe de la comisión";
            // 
            // RendicionFacturas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 522);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.rendirFacturasButton);
            this.Controls.Add(this.volverButton);
            this.Controls.Add(this.limpiarButton);
            this.Controls.Add(this.facturasDataGridView);
            this.Controls.Add(this.datosFacturaGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RendicionFacturas";
            this.Text = "Rendición de facturas cobradas";
            this.Load += new System.EventHandler(this.RendicionFacturas_Load);
            this.datosFacturaGroupBox.ResumeLayout(false);
            this.datosFacturaGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.facturasDataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox datosFacturaGroupBox;
        private System.Windows.Forms.Button buscarFacturaButton;
        private System.Windows.Forms.ComboBox empresaComboBox;
        private System.Windows.Forms.Label empresaLabel;
        private System.Windows.Forms.Label numFacturaLabel;
        private System.Windows.Forms.DataGridView facturasDataGridView;
        private System.Windows.Forms.Button volverButton;
        private System.Windows.Forms.Button limpiarButton;
        private System.Windows.Forms.Button rendirFacturasButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox porcentajeComisionTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox importeComisionTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker fechaFinDateTimePicker;
        private System.Windows.Forms.DateTimePicker fechaInicioDateTimePicker;
    }
}