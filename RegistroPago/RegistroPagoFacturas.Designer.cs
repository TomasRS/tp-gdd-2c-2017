namespace PagoAgilFrba.RegistroPago
{
    partial class RegistroPagoFacturas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistroPagoFacturas));
            this.datosFacturaGroupBox = new System.Windows.Forms.GroupBox();
            this.limpiarButton = new System.Windows.Forms.Button();
            this.registrarFacturaButton = new System.Windows.Forms.Button();
            this.sucursalTextBox = new System.Windows.Forms.TextBox();
            this.importeTextBox = new System.Windows.Forms.TextBox();
            this.fechaVencFactDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.clienteComboBox = new System.Windows.Forms.ComboBox();
            this.empresaComboBox = new System.Windows.Forms.ComboBox();
            this.fechaCobroDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.numFacturaTextBox = new System.Windows.Forms.TextBox();
            this.sucursalLabel = new System.Windows.Forms.Label();
            this.importeLabel = new System.Windows.Forms.Label();
            this.fechaVencFacturaLabel = new System.Windows.Forms.Label();
            this.clienteLabel = new System.Windows.Forms.Label();
            this.empresaLabel = new System.Windows.Forms.Label();
            this.fechaCobroLabel = new System.Windows.Forms.Label();
            this.numFacturaLabel = new System.Windows.Forms.Label();
            this.facturasRegistradasGroupBox = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.volverButton = new System.Windows.Forms.Button();
            this.pagarFacturasButton = new System.Windows.Forms.Button();
            this.facturasDataGridView = new System.Windows.Forms.DataGridView();
            this.NumeroDeFactura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Empresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sucursal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Importe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.medioDePagoGroupBox = new System.Windows.Forms.GroupBox();
            this.tarjetaCreditoRadioButton = new System.Windows.Forms.RadioButton();
            this.efectivoRadioButton = new System.Windows.Forms.RadioButton();
            this.chequeRadioButton = new System.Windows.Forms.RadioButton();
            this.tarjetaDebitoRadioButton = new System.Windows.Forms.RadioButton();
            this.limpiarTodoButton = new System.Windows.Forms.Button();
            this.datosFacturaGroupBox.SuspendLayout();
            this.facturasRegistradasGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.facturasDataGridView)).BeginInit();
            this.medioDePagoGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // datosFacturaGroupBox
            // 
            this.datosFacturaGroupBox.Controls.Add(this.limpiarButton);
            this.datosFacturaGroupBox.Controls.Add(this.registrarFacturaButton);
            this.datosFacturaGroupBox.Controls.Add(this.sucursalTextBox);
            this.datosFacturaGroupBox.Controls.Add(this.importeTextBox);
            this.datosFacturaGroupBox.Controls.Add(this.fechaVencFactDateTimePicker);
            this.datosFacturaGroupBox.Controls.Add(this.clienteComboBox);
            this.datosFacturaGroupBox.Controls.Add(this.empresaComboBox);
            this.datosFacturaGroupBox.Controls.Add(this.fechaCobroDateTimePicker);
            this.datosFacturaGroupBox.Controls.Add(this.numFacturaTextBox);
            this.datosFacturaGroupBox.Controls.Add(this.sucursalLabel);
            this.datosFacturaGroupBox.Controls.Add(this.importeLabel);
            this.datosFacturaGroupBox.Controls.Add(this.fechaVencFacturaLabel);
            this.datosFacturaGroupBox.Controls.Add(this.clienteLabel);
            this.datosFacturaGroupBox.Controls.Add(this.empresaLabel);
            this.datosFacturaGroupBox.Controls.Add(this.fechaCobroLabel);
            this.datosFacturaGroupBox.Controls.Add(this.numFacturaLabel);
            this.datosFacturaGroupBox.Location = new System.Drawing.Point(12, 12);
            this.datosFacturaGroupBox.Name = "datosFacturaGroupBox";
            this.datosFacturaGroupBox.Size = new System.Drawing.Size(550, 279);
            this.datosFacturaGroupBox.TabIndex = 0;
            this.datosFacturaGroupBox.TabStop = false;
            this.datosFacturaGroupBox.Text = "Datos de la factura";
            // 
            // limpiarButton
            // 
            this.limpiarButton.Location = new System.Drawing.Point(83, 237);
            this.limpiarButton.Name = "limpiarButton";
            this.limpiarButton.Size = new System.Drawing.Size(117, 32);
            this.limpiarButton.TabIndex = 15;
            this.limpiarButton.Text = "Limpiar";
            this.limpiarButton.UseVisualStyleBackColor = true;
            this.limpiarButton.Click += new System.EventHandler(this.limpiarButton_Click);
            // 
            // registrarFacturaButton
            // 
            this.registrarFacturaButton.Location = new System.Drawing.Point(327, 237);
            this.registrarFacturaButton.Name = "registrarFacturaButton";
            this.registrarFacturaButton.Size = new System.Drawing.Size(117, 32);
            this.registrarFacturaButton.TabIndex = 14;
            this.registrarFacturaButton.Text = "Registrar factura";
            this.registrarFacturaButton.UseVisualStyleBackColor = true;
            this.registrarFacturaButton.Click += new System.EventHandler(this.registrarFacturaButton_Click);
            // 
            // sucursalTextBox
            // 
            this.sucursalTextBox.Location = new System.Drawing.Point(248, 209);
            this.sucursalTextBox.Name = "sucursalTextBox";
            this.sucursalTextBox.Size = new System.Drawing.Size(270, 20);
            this.sucursalTextBox.TabIndex = 13;
            // 
            // importeTextBox
            // 
            this.importeTextBox.Location = new System.Drawing.Point(248, 179);
            this.importeTextBox.Name = "importeTextBox";
            this.importeTextBox.Size = new System.Drawing.Size(270, 20);
            this.importeTextBox.TabIndex = 12;
            // 
            // fechaVencFactDateTimePicker
            // 
            this.fechaVencFactDateTimePicker.Location = new System.Drawing.Point(248, 149);
            this.fechaVencFactDateTimePicker.Name = "fechaVencFactDateTimePicker";
            this.fechaVencFactDateTimePicker.Size = new System.Drawing.Size(270, 20);
            this.fechaVencFactDateTimePicker.TabIndex = 11;
            // 
            // clienteComboBox
            // 
            this.clienteComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.clienteComboBox.FormattingEnabled = true;
            this.clienteComboBox.Location = new System.Drawing.Point(248, 119);
            this.clienteComboBox.Name = "clienteComboBox";
            this.clienteComboBox.Size = new System.Drawing.Size(270, 21);
            this.clienteComboBox.TabIndex = 10;
            // 
            // empresaComboBox
            // 
            this.empresaComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.empresaComboBox.FormattingEnabled = true;
            this.empresaComboBox.Location = new System.Drawing.Point(248, 88);
            this.empresaComboBox.Name = "empresaComboBox";
            this.empresaComboBox.Size = new System.Drawing.Size(270, 21);
            this.empresaComboBox.TabIndex = 9;
            // 
            // fechaCobroDateTimePicker
            // 
            this.fechaCobroDateTimePicker.Enabled = false;
            this.fechaCobroDateTimePicker.Location = new System.Drawing.Point(248, 58);
            this.fechaCobroDateTimePicker.Name = "fechaCobroDateTimePicker";
            this.fechaCobroDateTimePicker.Size = new System.Drawing.Size(270, 20);
            this.fechaCobroDateTimePicker.TabIndex = 8;
            // 
            // numFacturaTextBox
            // 
            this.numFacturaTextBox.Location = new System.Drawing.Point(248, 29);
            this.numFacturaTextBox.Name = "numFacturaTextBox";
            this.numFacturaTextBox.Size = new System.Drawing.Size(270, 20);
            this.numFacturaTextBox.TabIndex = 7;
            // 
            // sucursalLabel
            // 
            this.sucursalLabel.AutoSize = true;
            this.sucursalLabel.Location = new System.Drawing.Point(6, 212);
            this.sucursalLabel.Name = "sucursalLabel";
            this.sucursalLabel.Size = new System.Drawing.Size(48, 13);
            this.sucursalLabel.TabIndex = 6;
            this.sucursalLabel.Text = "Sucursal";
            // 
            // importeLabel
            // 
            this.importeLabel.AutoSize = true;
            this.importeLabel.Location = new System.Drawing.Point(6, 182);
            this.importeLabel.Name = "importeLabel";
            this.importeLabel.Size = new System.Drawing.Size(42, 13);
            this.importeLabel.TabIndex = 5;
            this.importeLabel.Text = "Importe";
            // 
            // fechaVencFacturaLabel
            // 
            this.fechaVencFacturaLabel.AutoSize = true;
            this.fechaVencFacturaLabel.Location = new System.Drawing.Point(6, 153);
            this.fechaVencFacturaLabel.Name = "fechaVencFacturaLabel";
            this.fechaVencFacturaLabel.Size = new System.Drawing.Size(174, 13);
            this.fechaVencFacturaLabel.TabIndex = 4;
            this.fechaVencFacturaLabel.Text = "Fecha de vencimiento de la factura";
            // 
            // clienteLabel
            // 
            this.clienteLabel.AutoSize = true;
            this.clienteLabel.Location = new System.Drawing.Point(6, 122);
            this.clienteLabel.Name = "clienteLabel";
            this.clienteLabel.Size = new System.Drawing.Size(39, 13);
            this.clienteLabel.TabIndex = 3;
            this.clienteLabel.Text = "Cliente";
            // 
            // empresaLabel
            // 
            this.empresaLabel.AutoSize = true;
            this.empresaLabel.Location = new System.Drawing.Point(6, 91);
            this.empresaLabel.Name = "empresaLabel";
            this.empresaLabel.Size = new System.Drawing.Size(48, 13);
            this.empresaLabel.TabIndex = 2;
            this.empresaLabel.Text = "Empresa";
            // 
            // fechaCobroLabel
            // 
            this.fechaCobroLabel.AutoSize = true;
            this.fechaCobroLabel.Location = new System.Drawing.Point(6, 62);
            this.fechaCobroLabel.Name = "fechaCobroLabel";
            this.fechaCobroLabel.Size = new System.Drawing.Size(82, 13);
            this.fechaCobroLabel.TabIndex = 1;
            this.fechaCobroLabel.Text = "Fecha de cobro";
            // 
            // numFacturaLabel
            // 
            this.numFacturaLabel.AutoSize = true;
            this.numFacturaLabel.Location = new System.Drawing.Point(6, 32);
            this.numFacturaLabel.Name = "numFacturaLabel";
            this.numFacturaLabel.Size = new System.Drawing.Size(95, 13);
            this.numFacturaLabel.TabIndex = 0;
            this.numFacturaLabel.Text = "Número de factura";
            // 
            // facturasRegistradasGroupBox
            // 
            this.facturasRegistradasGroupBox.Controls.Add(this.button1);
            this.facturasRegistradasGroupBox.Controls.Add(this.facturasDataGridView);
            this.facturasRegistradasGroupBox.Location = new System.Drawing.Point(12, 297);
            this.facturasRegistradasGroupBox.Name = "facturasRegistradasGroupBox";
            this.facturasRegistradasGroupBox.Size = new System.Drawing.Size(550, 327);
            this.facturasRegistradasGroupBox.TabIndex = 16;
            this.facturasRegistradasGroupBox.TabStop = false;
            this.facturasRegistradasGroupBox.Text = "Facturas registradas";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(216, 286);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 32);
            this.button1.TabIndex = 21;
            this.button1.Text = "Limpiar facturas";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // volverButton
            // 
            this.volverButton.Location = new System.Drawing.Point(445, 699);
            this.volverButton.Name = "volverButton";
            this.volverButton.Size = new System.Drawing.Size(117, 32);
            this.volverButton.TabIndex = 20;
            this.volverButton.Text = "Volver al menú";
            this.volverButton.UseVisualStyleBackColor = true;
            this.volverButton.Click += new System.EventHandler(this.volverButton_Click);
            // 
            // pagarFacturasButton
            // 
            this.pagarFacturasButton.Location = new System.Drawing.Point(228, 699);
            this.pagarFacturasButton.Name = "pagarFacturasButton";
            this.pagarFacturasButton.Size = new System.Drawing.Size(117, 32);
            this.pagarFacturasButton.TabIndex = 19;
            this.pagarFacturasButton.Text = "Pagar facturas";
            this.pagarFacturasButton.UseVisualStyleBackColor = true;
            this.pagarFacturasButton.Click += new System.EventHandler(this.pagarFacturasButton_Click);
            // 
            // facturasDataGridView
            // 
            this.facturasDataGridView.AllowUserToAddRows = false;
            this.facturasDataGridView.AllowUserToResizeRows = false;
            this.facturasDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.facturasDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.facturasDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NumeroDeFactura,
            this.Empresa,
            this.Sucursal,
            this.Importe});
            this.facturasDataGridView.Location = new System.Drawing.Point(20, 19);
            this.facturasDataGridView.Name = "facturasDataGridView";
            this.facturasDataGridView.Size = new System.Drawing.Size(518, 262);
            this.facturasDataGridView.TabIndex = 18;
            // 
            // NumeroDeFactura
            // 
            this.NumeroDeFactura.HeaderText = "Número de factura";
            this.NumeroDeFactura.Name = "NumeroDeFactura";
            this.NumeroDeFactura.ReadOnly = true;
            // 
            // Empresa
            // 
            this.Empresa.HeaderText = "Empresa";
            this.Empresa.Name = "Empresa";
            this.Empresa.ReadOnly = true;
            // 
            // Sucursal
            // 
            this.Sucursal.HeaderText = "Sucursal";
            this.Sucursal.Name = "Sucursal";
            // 
            // Importe
            // 
            this.Importe.HeaderText = "Importe";
            this.Importe.Name = "Importe";
            // 
            // medioDePagoGroupBox
            // 
            this.medioDePagoGroupBox.Controls.Add(this.tarjetaDebitoRadioButton);
            this.medioDePagoGroupBox.Controls.Add(this.chequeRadioButton);
            this.medioDePagoGroupBox.Controls.Add(this.efectivoRadioButton);
            this.medioDePagoGroupBox.Controls.Add(this.tarjetaCreditoRadioButton);
            this.medioDePagoGroupBox.Location = new System.Drawing.Point(12, 630);
            this.medioDePagoGroupBox.Name = "medioDePagoGroupBox";
            this.medioDePagoGroupBox.Size = new System.Drawing.Size(550, 63);
            this.medioDePagoGroupBox.TabIndex = 17;
            this.medioDePagoGroupBox.TabStop = false;
            this.medioDePagoGroupBox.Text = "Medio de pago";
            // 
            // tarjetaCreditoRadioButton
            // 
            this.tarjetaCreditoRadioButton.AutoSize = true;
            this.tarjetaCreditoRadioButton.Location = new System.Drawing.Point(9, 29);
            this.tarjetaCreditoRadioButton.Name = "tarjetaCreditoRadioButton";
            this.tarjetaCreditoRadioButton.Size = new System.Drawing.Size(108, 17);
            this.tarjetaCreditoRadioButton.TabIndex = 0;
            this.tarjetaCreditoRadioButton.TabStop = true;
            this.tarjetaCreditoRadioButton.Text = "Tarjeta de crédito";
            this.tarjetaCreditoRadioButton.UseVisualStyleBackColor = true;
            // 
            // efectivoRadioButton
            // 
            this.efectivoRadioButton.AutoSize = true;
            this.efectivoRadioButton.Location = new System.Drawing.Point(166, 29);
            this.efectivoRadioButton.Name = "efectivoRadioButton";
            this.efectivoRadioButton.Size = new System.Drawing.Size(64, 17);
            this.efectivoRadioButton.TabIndex = 1;
            this.efectivoRadioButton.TabStop = true;
            this.efectivoRadioButton.Text = "Efectivo";
            this.efectivoRadioButton.UseVisualStyleBackColor = true;
            // 
            // chequeRadioButton
            // 
            this.chequeRadioButton.AutoSize = true;
            this.chequeRadioButton.Location = new System.Drawing.Point(294, 29);
            this.chequeRadioButton.Name = "chequeRadioButton";
            this.chequeRadioButton.Size = new System.Drawing.Size(62, 17);
            this.chequeRadioButton.TabIndex = 2;
            this.chequeRadioButton.TabStop = true;
            this.chequeRadioButton.Text = "Cheque";
            this.chequeRadioButton.UseVisualStyleBackColor = true;
            // 
            // tarjetaDebitoRadioButton
            // 
            this.tarjetaDebitoRadioButton.AutoSize = true;
            this.tarjetaDebitoRadioButton.Location = new System.Drawing.Point(421, 29);
            this.tarjetaDebitoRadioButton.Name = "tarjetaDebitoRadioButton";
            this.tarjetaDebitoRadioButton.Size = new System.Drawing.Size(105, 17);
            this.tarjetaDebitoRadioButton.TabIndex = 3;
            this.tarjetaDebitoRadioButton.TabStop = true;
            this.tarjetaDebitoRadioButton.Text = "Tarjeta de débito";
            this.tarjetaDebitoRadioButton.UseVisualStyleBackColor = true;
            // 
            // limpiarTodoButton
            // 
            this.limpiarTodoButton.Location = new System.Drawing.Point(12, 699);
            this.limpiarTodoButton.Name = "limpiarTodoButton";
            this.limpiarTodoButton.Size = new System.Drawing.Size(117, 32);
            this.limpiarTodoButton.TabIndex = 16;
            this.limpiarTodoButton.Text = "Limpiar todo";
            this.limpiarTodoButton.UseVisualStyleBackColor = true;
            this.limpiarTodoButton.Click += new System.EventHandler(this.limpiarTodoButton_Click);
            // 
            // RegistroPagoFacturas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 741);
            this.Controls.Add(this.limpiarTodoButton);
            this.Controls.Add(this.medioDePagoGroupBox);
            this.Controls.Add(this.volverButton);
            this.Controls.Add(this.facturasRegistradasGroupBox);
            this.Controls.Add(this.pagarFacturasButton);
            this.Controls.Add(this.datosFacturaGroupBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RegistroPagoFacturas";
            this.Text = "Registro de Pago de Facturas";
            this.Load += new System.EventHandler(this.RegistroPagoFacturas_Load);
            this.datosFacturaGroupBox.ResumeLayout(false);
            this.datosFacturaGroupBox.PerformLayout();
            this.facturasRegistradasGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.facturasDataGridView)).EndInit();
            this.medioDePagoGroupBox.ResumeLayout(false);
            this.medioDePagoGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox datosFacturaGroupBox;
        private System.Windows.Forms.Button registrarFacturaButton;
        private System.Windows.Forms.TextBox sucursalTextBox;
        private System.Windows.Forms.TextBox importeTextBox;
        private System.Windows.Forms.DateTimePicker fechaVencFactDateTimePicker;
        private System.Windows.Forms.ComboBox clienteComboBox;
        private System.Windows.Forms.ComboBox empresaComboBox;
        private System.Windows.Forms.DateTimePicker fechaCobroDateTimePicker;
        private System.Windows.Forms.TextBox numFacturaTextBox;
        private System.Windows.Forms.Label sucursalLabel;
        private System.Windows.Forms.Label importeLabel;
        private System.Windows.Forms.Label fechaVencFacturaLabel;
        private System.Windows.Forms.Label clienteLabel;
        private System.Windows.Forms.Label empresaLabel;
        private System.Windows.Forms.Label fechaCobroLabel;
        private System.Windows.Forms.Label numFacturaLabel;
        private System.Windows.Forms.GroupBox facturasRegistradasGroupBox;
        private System.Windows.Forms.Button pagarFacturasButton;
        private System.Windows.Forms.DataGridView facturasDataGridView;
        private System.Windows.Forms.Button volverButton;
        private System.Windows.Forms.Button limpiarButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumeroDeFactura;
        private System.Windows.Forms.DataGridViewTextBoxColumn Empresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sucursal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Importe;
        private System.Windows.Forms.GroupBox medioDePagoGroupBox;
        private System.Windows.Forms.RadioButton tarjetaDebitoRadioButton;
        private System.Windows.Forms.RadioButton chequeRadioButton;
        private System.Windows.Forms.RadioButton efectivoRadioButton;
        private System.Windows.Forms.RadioButton tarjetaCreditoRadioButton;
        private System.Windows.Forms.Button limpiarTodoButton;
    }
}