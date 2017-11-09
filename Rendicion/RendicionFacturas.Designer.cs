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
            this.buscarFacturaButton = new System.Windows.Forms.Button();
            this.empresaComboBox = new System.Windows.Forms.ComboBox();
            this.numFacturaTextBox = new System.Windows.Forms.TextBox();
            this.empresaLabel = new System.Windows.Forms.Label();
            this.numFacturaLabel = new System.Windows.Forms.Label();
            this.facturasDataGridView = new System.Windows.Forms.DataGridView();
            this.volverButton = new System.Windows.Forms.Button();
            this.limpiarButton = new System.Windows.Forms.Button();
            this.rendirFacturasButton = new System.Windows.Forms.Button();
            this.datosFacturaGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.facturasDataGridView)).BeginInit();
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
            this.datosFacturaGroupBox.Size = new System.Drawing.Size(677, 97);
            this.datosFacturaGroupBox.TabIndex = 1;
            this.datosFacturaGroupBox.TabStop = false;
            this.datosFacturaGroupBox.Text = "Datos para buscar facturas pagas para rendir";
            // 
            // buscarFacturaButton
            // 
            this.buscarFacturaButton.Location = new System.Drawing.Point(449, 37);
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
            this.numFacturaLabel.Size = new System.Drawing.Size(27, 13);
            this.numFacturaLabel.TabIndex = 0;
            this.numFacturaLabel.Text = "Mes";
            // 
            // facturasDataGridView
            // 
            this.facturasDataGridView.AllowUserToAddRows = false;
            this.facturasDataGridView.AllowUserToDeleteRows = false;
            this.facturasDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.facturasDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.facturasDataGridView.Location = new System.Drawing.Point(12, 125);
            this.facturasDataGridView.Name = "facturasDataGridView";
            this.facturasDataGridView.ReadOnly = true;
            this.facturasDataGridView.Size = new System.Drawing.Size(677, 239);
            this.facturasDataGridView.TabIndex = 36;
            // 
            // volverButton
            // 
            this.volverButton.Location = new System.Drawing.Point(589, 416);
            this.volverButton.Name = "volverButton";
            this.volverButton.Size = new System.Drawing.Size(100, 30);
            this.volverButton.TabIndex = 42;
            this.volverButton.Text = "Volver";
            this.volverButton.UseVisualStyleBackColor = true;
            this.volverButton.Click += new System.EventHandler(this.volverButton_Click);
            // 
            // limpiarButton
            // 
            this.limpiarButton.Location = new System.Drawing.Point(12, 416);
            this.limpiarButton.Name = "limpiarButton";
            this.limpiarButton.Size = new System.Drawing.Size(100, 30);
            this.limpiarButton.TabIndex = 41;
            this.limpiarButton.Text = "Limpiar";
            this.limpiarButton.UseVisualStyleBackColor = true;
            this.limpiarButton.Click += new System.EventHandler(this.limpiarButton_Click);
            // 
            // rendirFacturasButton
            // 
            this.rendirFacturasButton.Location = new System.Drawing.Point(300, 416);
            this.rendirFacturasButton.Name = "rendirFacturasButton";
            this.rendirFacturasButton.Size = new System.Drawing.Size(100, 30);
            this.rendirFacturasButton.TabIndex = 43;
            this.rendirFacturasButton.Text = "Rendir facturas";
            this.rendirFacturasButton.UseVisualStyleBackColor = true;
            this.rendirFacturasButton.Click += new System.EventHandler(this.rendirFacturasButton_Click);
            // 
            // RendicionFacturas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 458);
            this.Controls.Add(this.rendirFacturasButton);
            this.Controls.Add(this.volverButton);
            this.Controls.Add(this.limpiarButton);
            this.Controls.Add(this.facturasDataGridView);
            this.Controls.Add(this.datosFacturaGroupBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RendicionFacturas";
            this.Text = "Rendición de facturas cobradas";
            this.datosFacturaGroupBox.ResumeLayout(false);
            this.datosFacturaGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.facturasDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox datosFacturaGroupBox;
        private System.Windows.Forms.Button buscarFacturaButton;
        private System.Windows.Forms.ComboBox empresaComboBox;
        private System.Windows.Forms.TextBox numFacturaTextBox;
        private System.Windows.Forms.Label empresaLabel;
        private System.Windows.Forms.Label numFacturaLabel;
        private System.Windows.Forms.DataGridView facturasDataGridView;
        private System.Windows.Forms.Button volverButton;
        private System.Windows.Forms.Button limpiarButton;
        private System.Windows.Forms.Button rendirFacturasButton;
    }
}