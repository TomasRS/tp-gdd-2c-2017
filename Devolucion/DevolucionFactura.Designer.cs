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
            this.clienteComboBox = new System.Windows.Forms.ComboBox();
            this.clienteLabel = new System.Windows.Forms.Label();
            this.buscarFacturaButton = new System.Windows.Forms.Button();
            this.empresaComboBox = new System.Windows.Forms.ComboBox();
            this.numFacturaTextBox = new System.Windows.Forms.TextBox();
            this.empresaLabel = new System.Windows.Forms.Label();
            this.numFacturaLabel = new System.Windows.Forms.Label();
            this.facturaDataGridView = new System.Windows.Forms.DataGridView();
            this.devolverFacturaButton = new System.Windows.Forms.Button();
            this.limpiarButton = new System.Windows.Forms.Button();
            this.volverButton = new System.Windows.Forms.Button();
            this.datosFacturaGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.facturaDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // datosFacturaGroupBox
            // 
            this.datosFacturaGroupBox.Controls.Add(this.clienteComboBox);
            this.datosFacturaGroupBox.Controls.Add(this.clienteLabel);
            this.datosFacturaGroupBox.Controls.Add(this.buscarFacturaButton);
            this.datosFacturaGroupBox.Controls.Add(this.empresaComboBox);
            this.datosFacturaGroupBox.Controls.Add(this.numFacturaTextBox);
            this.datosFacturaGroupBox.Controls.Add(this.empresaLabel);
            this.datosFacturaGroupBox.Controls.Add(this.numFacturaLabel);
            this.datosFacturaGroupBox.Location = new System.Drawing.Point(12, 12);
            this.datosFacturaGroupBox.Name = "datosFacturaGroupBox";
            this.datosFacturaGroupBox.Size = new System.Drawing.Size(653, 128);
            this.datosFacturaGroupBox.TabIndex = 0;
            this.datosFacturaGroupBox.TabStop = false;
            this.datosFacturaGroupBox.Text = "Datos de factura paga para devolución";
            // 
            // clienteComboBox
            // 
            this.clienteComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.clienteComboBox.FormattingEnabled = true;
            this.clienteComboBox.Location = new System.Drawing.Point(125, 93);
            this.clienteComboBox.Name = "clienteComboBox";
            this.clienteComboBox.Size = new System.Drawing.Size(184, 21);
            this.clienteComboBox.TabIndex = 37;
            // 
            // clienteLabel
            // 
            this.clienteLabel.AutoSize = true;
            this.clienteLabel.Location = new System.Drawing.Point(6, 96);
            this.clienteLabel.Name = "clienteLabel";
            this.clienteLabel.Size = new System.Drawing.Size(39, 13);
            this.clienteLabel.TabIndex = 36;
            this.clienteLabel.Text = "Cliente";
            // 
            // buscarFacturaButton
            // 
            this.buscarFacturaButton.Location = new System.Drawing.Point(436, 54);
            this.buscarFacturaButton.Name = "buscarFacturaButton";
            this.buscarFacturaButton.Size = new System.Drawing.Size(100, 30);
            this.buscarFacturaButton.TabIndex = 35;
            this.buscarFacturaButton.Text = "Buscar factura";
            this.buscarFacturaButton.UseVisualStyleBackColor = true;
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
            this.facturaDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.facturaDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.facturaDataGridView.Location = new System.Drawing.Point(12, 146);
            this.facturaDataGridView.Name = "facturaDataGridView";
            this.facturaDataGridView.Size = new System.Drawing.Size(653, 64);
            this.facturaDataGridView.TabIndex = 1;
            // 
            // devolverFacturaButton
            // 
            this.devolverFacturaButton.Location = new System.Drawing.Point(288, 220);
            this.devolverFacturaButton.Name = "devolverFacturaButton";
            this.devolverFacturaButton.Size = new System.Drawing.Size(100, 30);
            this.devolverFacturaButton.TabIndex = 38;
            this.devolverFacturaButton.Text = "Devolver factura";
            this.devolverFacturaButton.UseVisualStyleBackColor = true;
            // 
            // limpiarButton
            // 
            this.limpiarButton.Location = new System.Drawing.Point(13, 220);
            this.limpiarButton.Name = "limpiarButton";
            this.limpiarButton.Size = new System.Drawing.Size(100, 30);
            this.limpiarButton.TabIndex = 39;
            this.limpiarButton.Text = "Limpiar";
            this.limpiarButton.UseVisualStyleBackColor = true;
            // 
            // volverButton
            // 
            this.volverButton.Location = new System.Drawing.Point(565, 220);
            this.volverButton.Name = "volverButton";
            this.volverButton.Size = new System.Drawing.Size(100, 30);
            this.volverButton.TabIndex = 40;
            this.volverButton.Text = "Volver";
            this.volverButton.UseVisualStyleBackColor = true;
            this.volverButton.Click += new System.EventHandler(this.volverButton_Click);
            // 
            // DevolucionFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 262);
            this.Controls.Add(this.volverButton);
            this.Controls.Add(this.limpiarButton);
            this.Controls.Add(this.devolverFacturaButton);
            this.Controls.Add(this.facturaDataGridView);
            this.Controls.Add(this.datosFacturaGroupBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DevolucionFactura";
            this.Text = "Devolución de facturas";
            this.datosFacturaGroupBox.ResumeLayout(false);
            this.datosFacturaGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.facturaDataGridView)).EndInit();
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
        private System.Windows.Forms.ComboBox clienteComboBox;
        private System.Windows.Forms.Label clienteLabel;
        private System.Windows.Forms.Button devolverFacturaButton;
        private System.Windows.Forms.Button limpiarButton;
        private System.Windows.Forms.Button volverButton;
    }
}