namespace PagoAgilFrba.AbmEmpresa
{
    partial class AltaModifEmpresa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AltaModifEmpresa));
            this.limpiarButton = new System.Windows.Forms.Button();
            this.guardarButton = new System.Windows.Forms.Button();
            this.volverButton = new System.Windows.Forms.Button();
            this.camposObligatoriosLabel = new System.Windows.Forms.Label();
            this.datosPersonalesGroupBox = new System.Windows.Forms.GroupBox();
            this.rubroComboBox = new System.Windows.Forms.ComboBox();
            this.rubroLabel = new System.Windows.Forms.Label();
            this.direccionTextBox = new System.Windows.Forms.TextBox();
            this.cuitTextBox = new System.Windows.Forms.TextBox();
            this.nombreTextBox = new System.Windows.Forms.TextBox();
            this.direccionLabel = new System.Windows.Forms.Label();
            this.cuitLabel = new System.Windows.Forms.Label();
            this.nombreLabel = new System.Windows.Forms.Label();
            this.datosPersonalesGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // limpiarButton
            // 
            this.limpiarButton.Location = new System.Drawing.Point(12, 200);
            this.limpiarButton.Name = "limpiarButton";
            this.limpiarButton.Size = new System.Drawing.Size(100, 30);
            this.limpiarButton.TabIndex = 30;
            this.limpiarButton.Text = "Limpiar";
            this.limpiarButton.UseVisualStyleBackColor = true;
            this.limpiarButton.Click += new System.EventHandler(this.limpiarButton_Click);
            // 
            // guardarButton
            // 
            this.guardarButton.Location = new System.Drawing.Point(138, 200);
            this.guardarButton.Name = "guardarButton";
            this.guardarButton.Size = new System.Drawing.Size(100, 30);
            this.guardarButton.TabIndex = 29;
            this.guardarButton.Text = "Guardar";
            this.guardarButton.UseVisualStyleBackColor = true;
            // 
            // volverButton
            // 
            this.volverButton.Location = new System.Drawing.Point(265, 200);
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
            this.camposObligatoriosLabel.Location = new System.Drawing.Point(12, 171);
            this.camposObligatoriosLabel.Name = "camposObligatoriosLabel";
            this.camposObligatoriosLabel.Size = new System.Drawing.Size(169, 13);
            this.camposObligatoriosLabel.TabIndex = 27;
            this.camposObligatoriosLabel.Text = "Todos los campos son obligatorios";
            // 
            // datosPersonalesGroupBox
            // 
            this.datosPersonalesGroupBox.Controls.Add(this.rubroComboBox);
            this.datosPersonalesGroupBox.Controls.Add(this.rubroLabel);
            this.datosPersonalesGroupBox.Controls.Add(this.direccionTextBox);
            this.datosPersonalesGroupBox.Controls.Add(this.cuitTextBox);
            this.datosPersonalesGroupBox.Controls.Add(this.nombreTextBox);
            this.datosPersonalesGroupBox.Controls.Add(this.direccionLabel);
            this.datosPersonalesGroupBox.Controls.Add(this.cuitLabel);
            this.datosPersonalesGroupBox.Controls.Add(this.nombreLabel);
            this.datosPersonalesGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datosPersonalesGroupBox.Location = new System.Drawing.Point(12, 12);
            this.datosPersonalesGroupBox.Name = "datosPersonalesGroupBox";
            this.datosPersonalesGroupBox.Size = new System.Drawing.Size(351, 149);
            this.datosPersonalesGroupBox.TabIndex = 25;
            this.datosPersonalesGroupBox.TabStop = false;
            this.datosPersonalesGroupBox.Text = "Datos de la empresa";
            // 
            // rubroComboBox
            // 
            this.rubroComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.rubroComboBox.FormattingEnabled = true;
            this.rubroComboBox.Location = new System.Drawing.Point(117, 113);
            this.rubroComboBox.Name = "rubroComboBox";
            this.rubroComboBox.Size = new System.Drawing.Size(217, 21);
            this.rubroComboBox.TabIndex = 6;
            // 
            // rubroLabel
            // 
            this.rubroLabel.AutoSize = true;
            this.rubroLabel.Location = new System.Drawing.Point(6, 116);
            this.rubroLabel.Name = "rubroLabel";
            this.rubroLabel.Size = new System.Drawing.Size(36, 13);
            this.rubroLabel.TabIndex = 5;
            this.rubroLabel.Text = "Rubro";
            // 
            // direccionTextBox
            // 
            this.direccionTextBox.Location = new System.Drawing.Point(117, 83);
            this.direccionTextBox.Name = "direccionTextBox";
            this.direccionTextBox.Size = new System.Drawing.Size(217, 20);
            this.direccionTextBox.TabIndex = 3;
            // 
            // cuitTextBox
            // 
            this.cuitTextBox.Location = new System.Drawing.Point(117, 55);
            this.cuitTextBox.Name = "cuitTextBox";
            this.cuitTextBox.Size = new System.Drawing.Size(217, 20);
            this.cuitTextBox.TabIndex = 2;
            // 
            // nombreTextBox
            // 
            this.nombreTextBox.Location = new System.Drawing.Point(117, 27);
            this.nombreTextBox.Name = "nombreTextBox";
            this.nombreTextBox.Size = new System.Drawing.Size(217, 20);
            this.nombreTextBox.TabIndex = 1;
            // 
            // direccionLabel
            // 
            this.direccionLabel.AutoSize = true;
            this.direccionLabel.Location = new System.Drawing.Point(6, 86);
            this.direccionLabel.Name = "direccionLabel";
            this.direccionLabel.Size = new System.Drawing.Size(52, 13);
            this.direccionLabel.TabIndex = 2;
            this.direccionLabel.Text = "Dirección";
            // 
            // cuitLabel
            // 
            this.cuitLabel.AutoSize = true;
            this.cuitLabel.Location = new System.Drawing.Point(6, 58);
            this.cuitLabel.Name = "cuitLabel";
            this.cuitLabel.Size = new System.Drawing.Size(32, 13);
            this.cuitLabel.TabIndex = 1;
            this.cuitLabel.Text = "CUIT";
            // 
            // nombreLabel
            // 
            this.nombreLabel.AutoSize = true;
            this.nombreLabel.Location = new System.Drawing.Point(6, 27);
            this.nombreLabel.Name = "nombreLabel";
            this.nombreLabel.Size = new System.Drawing.Size(44, 13);
            this.nombreLabel.TabIndex = 0;
            this.nombreLabel.Text = "Nombre";
            // 
            // AltaModifEmpresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 241);
            this.Controls.Add(this.limpiarButton);
            this.Controls.Add(this.guardarButton);
            this.Controls.Add(this.volverButton);
            this.Controls.Add(this.camposObligatoriosLabel);
            this.Controls.Add(this.datosPersonalesGroupBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AltaModifEmpresa";
            this.Text = "Alta y modificación de empresa";
            this.datosPersonalesGroupBox.ResumeLayout(false);
            this.datosPersonalesGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button limpiarButton;
        private System.Windows.Forms.Button guardarButton;
        private System.Windows.Forms.Button volverButton;
        private System.Windows.Forms.Label camposObligatoriosLabel;
        private System.Windows.Forms.GroupBox datosPersonalesGroupBox;
        private System.Windows.Forms.TextBox direccionTextBox;
        private System.Windows.Forms.TextBox cuitTextBox;
        private System.Windows.Forms.TextBox nombreTextBox;
        private System.Windows.Forms.Label direccionLabel;
        private System.Windows.Forms.Label cuitLabel;
        private System.Windows.Forms.Label nombreLabel;
        private System.Windows.Forms.ComboBox rubroComboBox;
        private System.Windows.Forms.Label rubroLabel;
    }
}