namespace PagoAgilFrba.Devolucion
{
    partial class DevolucionFactura
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DevolucionFactura));
            this.datosFacturaGroupBox = new System.Windows.Forms.GroupBox();
            this.buscarFacturaButton = new System.Windows.Forms.Button();
            this.empresaComboBox = new System.Windows.Forms.ComboBox();
            this.numFacturaTextBox = new System.Windows.Forms.TextBox();
            this.empresaLabel = new System.Windows.Forms.Label();
            this.numFacturaLabel = new System.Windows.Forms.Label();
            this.facturaDataGridView = new System.Windows.Forms.DataGridView();
            this.limpiarButton = new System.Windows.Forms.Button();
            this.volverButton = new System.Windows.Forms.Button();
            this.devolverFacturaButton = new System.Windows.Forms.Button();
            this.motivoGroupBox = new System.Windows.Forms.GroupBox();
            this.retrotraerPagoRadioButton = new System.Windows.Forms.RadioButton();
            this.errorDeCobroRadioButton = new System.Windows.Forms.RadioButton();
            this.datosFacturaGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.facturaDataGridView)).BeginInit();
            this.motivoGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // datosFacturaGroupBox
            // 
            this.datosFacturaGroupBox.Controls.Add(this.buscarFacturaButton);
            this.datosFacturaGroupBox.Controls.Add(this.empresaComboBox);
            this.datosFacturaGroupBox.Controls.Add(this.numFacturaTextBox);
            this.datosFacturaGroupBox.Controls.Add(this.empresaLabel);
            this.datosFacturaGroupBox.Controls.Add(this.numFacturaLabel);
            this.datosFacturaGroupBox.Location = new System.Drawing.Point(12, 12);
            this.datosFacturaGroupBox.Name = "datosFacturaGroupBox";
            this.datosFacturaGroupBox.Size = new System.Drawing.Size(624, 97);
            this.datosFacturaGroupBox.TabIndex = 0;
            this.datosFacturaGroupBox.TabStop = false;
            this.datosFacturaGroupBox.Text = "Datos de factura paga para devolución";
            // 
            // buscarFacturaButton
            // 
            this.buscarFacturaButton.Location = new System.Drawing.Point(424, 38);
            this.buscarFacturaButton.Name = "buscarFacturaButton";
            this.buscarFacturaButton.Size = new System.Drawing.Size(100, 30);
            this.buscarFacturaButton.TabIndex = 35;
            this.buscarFacturaButton.Text = "Buscar factura";
            this.buscarFacturaButton.UseVisualStyleBackColor = true;
            this.buscarFacturaButton.Click += new System.EventHandler(this.buscarFacturaButton_Click);
            // 
            // empresaComboBox
            // 
            this.empresaComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.empresaComboBox.FormattingEnabled = true;
            this.empresaComboBox.Location = new System.Drawing.Point(125, 60);
            this.empresaComboBox.Name = "empresaComboBox";
            this.empresaComboBox.Size = new System.Drawing.Size(184, 21);
            this.empresaComboBox.TabIndex = 3;
            // 
            // numFacturaTextBox
            // 
            this.numFacturaTextBox.Location = new System.Drawing.Point(125, 28);
            this.numFacturaTextBox.Name = "numFacturaTextBox";
            this.numFacturaTextBox.Size = new System.Drawing.Size(184, 20);
            this.numFacturaTextBox.TabIndex = 2;
            // 
            // empresaLabel
            // 
            this.empresaLabel.AutoSize = true;
            this.empresaLabel.Location = new System.Drawing.Point(6, 63);
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
            this.numFacturaLabel.Size = new System.Drawing.Size(95, 13);
            this.numFacturaLabel.TabIndex = 0;
            this.numFacturaLabel.Text = "Número de factura";
            // 
            // facturaDataGridView
            // 
            this.facturaDataGridView.AllowUserToAddRows = false;
            this.facturaDataGridView.AllowUserToDeleteRows = false;
            this.facturaDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.facturaDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.facturaDataGridView.Location = new System.Drawing.Point(11, 115);
            this.facturaDataGridView.Name = "facturaDataGridView";
            this.facturaDataGridView.ReadOnly = true;
            this.facturaDataGridView.Size = new System.Drawing.Size(624, 56);
            this.facturaDataGridView.TabIndex = 1;
            // 
            // limpiarButton
            // 
            this.limpiarButton.Location = new System.Drawing.Point(11, 248);
            this.limpiarButton.Name = "limpiarButton";
            this.limpiarButton.Size = new System.Drawing.Size(100, 30);
            this.limpiarButton.TabIndex = 39;
            this.limpiarButton.Text = "Limpiar";
            this.limpiarButton.UseVisualStyleBackColor = true;
            this.limpiarButton.Click += new System.EventHandler(this.limpiarButton_Click);
            // 
            // volverButton
            // 
            this.volverButton.Location = new System.Drawing.Point(536, 248);
            this.volverButton.Name = "volverButton";
            this.volverButton.Size = new System.Drawing.Size(100, 30);
            this.volverButton.TabIndex = 40;
            this.volverButton.Text = "Volver";
            this.volverButton.UseVisualStyleBackColor = true;
            this.volverButton.Click += new System.EventHandler(this.volverButton_Click);
            // 
            // devolverFacturaButton
            // 
            this.devolverFacturaButton.Location = new System.Drawing.Point(272, 248);
            this.devolverFacturaButton.Name = "devolverFacturaButton";
            this.devolverFacturaButton.Size = new System.Drawing.Size(100, 30);
            this.devolverFacturaButton.TabIndex = 38;
            this.devolverFacturaButton.Text = "Devolver factura";
            this.devolverFacturaButton.UseVisualStyleBackColor = true;
            this.devolverFacturaButton.Click += new System.EventHandler(this.devolverFacturaButton_Click);
            // 
            // motivoGroupBox
            // 
            this.motivoGroupBox.Controls.Add(this.retrotraerPagoRadioButton);
            this.motivoGroupBox.Controls.Add(this.errorDeCobroRadioButton);
            this.motivoGroupBox.Location = new System.Drawing.Point(11, 177);
            this.motivoGroupBox.Name = "motivoGroupBox";
            this.motivoGroupBox.Size = new System.Drawing.Size(624, 63);
            this.motivoGroupBox.TabIndex = 41;
            this.motivoGroupBox.TabStop = false;
            this.motivoGroupBox.Text = "Motivo de la devolución";
            // 
            // retrotraerPagoRadioButton
            // 
            this.retrotraerPagoRadioButton.AutoSize = true;
            this.retrotraerPagoRadioButton.Location = new System.Drawing.Point(270, 28);
            this.retrotraerPagoRadioButton.Name = "retrotraerPagoRadioButton";
            this.retrotraerPagoRadioButton.Size = new System.Drawing.Size(217, 17);
            this.retrotraerPagoRadioButton.TabIndex = 1;
            this.retrotraerPagoRadioButton.TabStop = true;
            this.retrotraerPagoRadioButton.Text = "Cliente decidió retrotraer pago efectuado";
            this.retrotraerPagoRadioButton.UseVisualStyleBackColor = true;
            // 
            // errorDeCobroRadioButton
            // 
            this.errorDeCobroRadioButton.AutoSize = true;
            this.errorDeCobroRadioButton.Location = new System.Drawing.Point(144, 28);
            this.errorDeCobroRadioButton.Name = "errorDeCobroRadioButton";
            this.errorDeCobroRadioButton.Size = new System.Drawing.Size(92, 17);
            this.errorDeCobroRadioButton.TabIndex = 0;
            this.errorDeCobroRadioButton.TabStop = true;
            this.errorDeCobroRadioButton.Text = "Error de cobro";
            this.errorDeCobroRadioButton.UseVisualStyleBackColor = true;
            // 
            // DevolucionFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 289);
            this.Controls.Add(this.motivoGroupBox);
            this.Controls.Add(this.volverButton);
            this.Controls.Add(this.limpiarButton);
            this.Controls.Add(this.devolverFacturaButton);
            this.Controls.Add(this.facturaDataGridView);
            this.Controls.Add(this.datosFacturaGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DevolucionFactura";
            this.Text = "Devolución de facturas";
            this.Load += new System.EventHandler(this.DevolucionFactura_Load);
            this.datosFacturaGroupBox.ResumeLayout(false);
            this.datosFacturaGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.facturaDataGridView)).EndInit();
            this.motivoGroupBox.ResumeLayout(false);
            this.motivoGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox datosFacturaGroupBox;
        private System.Windows.Forms.ComboBox empresaComboBox;
        private System.Windows.Forms.TextBox numFacturaTextBox;
        private System.Windows.Forms.Label empresaLabel;
        private System.Windows.Forms.Label numFacturaLabel;
        private System.Windows.Forms.Button buscarFacturaButton;
        private System.Windows.Forms.DataGridView facturaDataGridView;
        private System.Windows.Forms.Button limpiarButton;
        private System.Windows.Forms.Button volverButton;
        private System.Windows.Forms.Button devolverFacturaButton;
        private System.Windows.Forms.GroupBox motivoGroupBox;
        private System.Windows.Forms.RadioButton retrotraerPagoRadioButton;
        private System.Windows.Forms.RadioButton errorDeCobroRadioButton;
    }
}