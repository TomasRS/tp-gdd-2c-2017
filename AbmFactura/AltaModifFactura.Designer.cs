namespace PagoAgilFrba.AbmFactura
{
    partial class AltaModifFactura
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AltaModifFactura));
            this.limpiarButton = new System.Windows.Forms.Button();
            this.guardarButton = new System.Windows.Forms.Button();
            this.volverButton = new System.Windows.Forms.Button();
            this.camposObligatoriosLabel = new System.Windows.Forms.Label();
            this.datosPersonalesGroupBox = new System.Windows.Forms.GroupBox();
            this.fechaVencDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.fechaVencLabel = new System.Windows.Forms.Label();
            this.empresaComboBox = new System.Windows.Forms.ComboBox();
            this.fechaAltaFactDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.nroFacturaTextBox = new System.Windows.Forms.TextBox();
            this.clienteTextBox = new System.Windows.Forms.TextBox();
            this.fechaAltaFactLabel = new System.Windows.Forms.Label();
            this.numeroFacturaLabel = new System.Windows.Forms.Label();
            this.empresaLabel = new System.Windows.Forms.Label();
            this.clienteLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.itemsDataGridView = new System.Windows.Forms.DataGridView();
            this.datosPersonalesGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.itemsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // limpiarButton
            // 
            this.limpiarButton.Location = new System.Drawing.Point(25, 377);
            this.limpiarButton.Name = "limpiarButton";
            this.limpiarButton.Size = new System.Drawing.Size(100, 30);
            this.limpiarButton.TabIndex = 30;
            this.limpiarButton.Text = "Limpiar";
            this.limpiarButton.UseVisualStyleBackColor = true;
            this.limpiarButton.Click += new System.EventHandler(this.limpiarButton_Click);
            // 
            // guardarButton
            // 
            this.guardarButton.Location = new System.Drawing.Point(151, 377);
            this.guardarButton.Name = "guardarButton";
            this.guardarButton.Size = new System.Drawing.Size(100, 30);
            this.guardarButton.TabIndex = 29;
            this.guardarButton.Text = "Guardar";
            this.guardarButton.UseVisualStyleBackColor = true;
            this.guardarButton.Click += new System.EventHandler(this.guardarButton_Click);
            // 
            // volverButton
            // 
            this.volverButton.Location = new System.Drawing.Point(278, 377);
            this.volverButton.Name = "volverButton";
            this.volverButton.Size = new System.Drawing.Size(100, 30);
            this.volverButton.TabIndex = 28;
            this.volverButton.Text = "Volver";
            this.volverButton.UseVisualStyleBackColor = true;
            this.volverButton.Click += new System.EventHandler(this.volverButton_Click);
            // 
            // camposObligatoriosLabel
            // 
            this.camposObligatoriosLabel.AutoSize = true;
            this.camposObligatoriosLabel.ForeColor = System.Drawing.Color.Red;
            this.camposObligatoriosLabel.Location = new System.Drawing.Point(25, 351);
            this.camposObligatoriosLabel.Name = "camposObligatoriosLabel";
            this.camposObligatoriosLabel.Size = new System.Drawing.Size(169, 13);
            this.camposObligatoriosLabel.TabIndex = 27;
            this.camposObligatoriosLabel.Text = "Todos los campos son obligatorios";
            // 
            // datosPersonalesGroupBox
            // 
            this.datosPersonalesGroupBox.Controls.Add(this.fechaVencDateTimePicker);
            this.datosPersonalesGroupBox.Controls.Add(this.fechaVencLabel);
            this.datosPersonalesGroupBox.Controls.Add(this.empresaComboBox);
            this.datosPersonalesGroupBox.Controls.Add(this.fechaAltaFactDateTimePicker);
            this.datosPersonalesGroupBox.Controls.Add(this.nroFacturaTextBox);
            this.datosPersonalesGroupBox.Controls.Add(this.clienteTextBox);
            this.datosPersonalesGroupBox.Controls.Add(this.fechaAltaFactLabel);
            this.datosPersonalesGroupBox.Controls.Add(this.numeroFacturaLabel);
            this.datosPersonalesGroupBox.Controls.Add(this.empresaLabel);
            this.datosPersonalesGroupBox.Controls.Add(this.clienteLabel);
            this.datosPersonalesGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datosPersonalesGroupBox.Location = new System.Drawing.Point(12, 12);
            this.datosPersonalesGroupBox.Name = "datosPersonalesGroupBox";
            this.datosPersonalesGroupBox.Size = new System.Drawing.Size(386, 172);
            this.datosPersonalesGroupBox.TabIndex = 25;
            this.datosPersonalesGroupBox.TabStop = false;
            this.datosPersonalesGroupBox.Text = "Datos de la factura";
            // 
            // fechaVencDateTimePicker
            // 
            this.fechaVencDateTimePicker.Location = new System.Drawing.Point(158, 139);
            this.fechaVencDateTimePicker.Name = "fechaVencDateTimePicker";
            this.fechaVencDateTimePicker.Size = new System.Drawing.Size(217, 20);
            this.fechaVencDateTimePicker.TabIndex = 7;
            // 
            // fechaVencLabel
            // 
            this.fechaVencLabel.AutoSize = true;
            this.fechaVencLabel.Location = new System.Drawing.Point(6, 145);
            this.fechaVencLabel.Name = "fechaVencLabel";
            this.fechaVencLabel.Size = new System.Drawing.Size(112, 13);
            this.fechaVencLabel.TabIndex = 6;
            this.fechaVencLabel.Text = "Fecha de vencimiento";
            // 
            // empresaComboBox
            // 
            this.empresaComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.empresaComboBox.FormattingEnabled = true;
            this.empresaComboBox.Location = new System.Drawing.Point(158, 55);
            this.empresaComboBox.Name = "empresaComboBox";
            this.empresaComboBox.Size = new System.Drawing.Size(217, 21);
            this.empresaComboBox.TabIndex = 5;
            // 
            // fechaAltaFactDateTimePicker
            // 
            this.fechaAltaFactDateTimePicker.Location = new System.Drawing.Point(158, 111);
            this.fechaAltaFactDateTimePicker.Name = "fechaAltaFactDateTimePicker";
            this.fechaAltaFactDateTimePicker.Size = new System.Drawing.Size(217, 20);
            this.fechaAltaFactDateTimePicker.TabIndex = 4;
            // 
            // nroFacturaTextBox
            // 
            this.nroFacturaTextBox.Location = new System.Drawing.Point(158, 83);
            this.nroFacturaTextBox.Name = "nroFacturaTextBox";
            this.nroFacturaTextBox.Size = new System.Drawing.Size(217, 20);
            this.nroFacturaTextBox.TabIndex = 3;
            // 
            // clienteTextBox
            // 
            this.clienteTextBox.Location = new System.Drawing.Point(158, 27);
            this.clienteTextBox.Name = "clienteTextBox";
            this.clienteTextBox.Size = new System.Drawing.Size(217, 20);
            this.clienteTextBox.TabIndex = 1;
            // 
            // fechaAltaFactLabel
            // 
            this.fechaAltaFactLabel.AutoSize = true;
            this.fechaAltaFactLabel.Location = new System.Drawing.Point(6, 115);
            this.fechaAltaFactLabel.Name = "fechaAltaFactLabel";
            this.fechaAltaFactLabel.Size = new System.Drawing.Size(134, 13);
            this.fechaAltaFactLabel.TabIndex = 3;
            this.fechaAltaFactLabel.Text = "Fecha de alta de la factura";
            // 
            // numeroFacturaLabel
            // 
            this.numeroFacturaLabel.AutoSize = true;
            this.numeroFacturaLabel.Location = new System.Drawing.Point(6, 86);
            this.numeroFacturaLabel.Name = "numeroFacturaLabel";
            this.numeroFacturaLabel.Size = new System.Drawing.Size(70, 13);
            this.numeroFacturaLabel.TabIndex = 2;
            this.numeroFacturaLabel.Text = "Nº de factura";
            // 
            // empresaLabel
            // 
            this.empresaLabel.AutoSize = true;
            this.empresaLabel.Location = new System.Drawing.Point(6, 58);
            this.empresaLabel.Name = "empresaLabel";
            this.empresaLabel.Size = new System.Drawing.Size(48, 13);
            this.empresaLabel.TabIndex = 1;
            this.empresaLabel.Text = "Empresa";
            // 
            // clienteLabel
            // 
            this.clienteLabel.AutoSize = true;
            this.clienteLabel.Location = new System.Drawing.Point(6, 27);
            this.clienteLabel.Name = "clienteLabel";
            this.clienteLabel.Size = new System.Drawing.Size(77, 13);
            this.clienteLabel.TabIndex = 0;
            this.clienteLabel.Text = "Mail del cliente";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.itemsDataGridView);
            this.groupBox1.Location = new System.Drawing.Point(12, 190);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(385, 149);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Total";
            // 
            // itemsDataGridView
            // 
            this.itemsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.itemsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.itemsDataGridView.Location = new System.Drawing.Point(6, 22);
            this.itemsDataGridView.Name = "itemsDataGridView";
            this.itemsDataGridView.Size = new System.Drawing.Size(373, 119);
            this.itemsDataGridView.TabIndex = 0;
            // 
            // AltaModifFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 417);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.limpiarButton);
            this.Controls.Add(this.guardarButton);
            this.Controls.Add(this.volverButton);
            this.Controls.Add(this.camposObligatoriosLabel);
            this.Controls.Add(this.datosPersonalesGroupBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AltaModifFactura";
            this.Text = "Alta y modificación de factura";
            this.Load += new System.EventHandler(this.AltaModifFactura_Load);
            this.datosPersonalesGroupBox.ResumeLayout(false);
            this.datosPersonalesGroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.itemsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button limpiarButton;
        private System.Windows.Forms.Button guardarButton;
        private System.Windows.Forms.Button volverButton;
        private System.Windows.Forms.Label camposObligatoriosLabel;
        private System.Windows.Forms.GroupBox datosPersonalesGroupBox;
        private System.Windows.Forms.DateTimePicker fechaVencDateTimePicker;
        private System.Windows.Forms.Label fechaVencLabel;
        private System.Windows.Forms.ComboBox empresaComboBox;
        private System.Windows.Forms.DateTimePicker fechaAltaFactDateTimePicker;
        private System.Windows.Forms.TextBox nroFacturaTextBox;
        private System.Windows.Forms.TextBox clienteTextBox;
        private System.Windows.Forms.Label fechaAltaFactLabel;
        private System.Windows.Forms.Label numeroFacturaLabel;
        private System.Windows.Forms.Label empresaLabel;
        private System.Windows.Forms.Label clienteLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView itemsDataGridView;
    }
}