namespace PagoAgilFrba.AbmSucursal
{
    partial class AltaModifSucursal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AltaModifSucursal));
            this.habilitadoCheckBox = new System.Windows.Forms.CheckBox();
            this.limpiarButton = new System.Windows.Forms.Button();
            this.guardarButton = new System.Windows.Forms.Button();
            this.volverButton = new System.Windows.Forms.Button();
            this.camposObligatoriosLabel = new System.Windows.Forms.Label();
            this.datosPersonalesGroupBox = new System.Windows.Forms.GroupBox();
            this.codPostalTextBox = new System.Windows.Forms.TextBox();
            this.direccionTextBox = new System.Windows.Forms.TextBox();
            this.nombreTextBox = new System.Windows.Forms.TextBox();
            this.codPostalLabel = new System.Windows.Forms.Label();
            this.direccionLabel = new System.Windows.Forms.Label();
            this.nombreLabel = new System.Windows.Forms.Label();
            this.datosPersonalesGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // habilitadoCheckBox
            // 
            this.habilitadoCheckBox.AutoSize = true;
            this.habilitadoCheckBox.Location = new System.Drawing.Point(273, 133);
            this.habilitadoCheckBox.Name = "habilitadoCheckBox";
            this.habilitadoCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.habilitadoCheckBox.Size = new System.Drawing.Size(73, 17);
            this.habilitadoCheckBox.TabIndex = 37;
            this.habilitadoCheckBox.Text = "Habilitado";
            this.habilitadoCheckBox.UseVisualStyleBackColor = true;
            // 
            // limpiarButton
            // 
            this.limpiarButton.Location = new System.Drawing.Point(12, 163);
            this.limpiarButton.Name = "limpiarButton";
            this.limpiarButton.Size = new System.Drawing.Size(100, 30);
            this.limpiarButton.TabIndex = 36;
            this.limpiarButton.Text = "Limpiar";
            this.limpiarButton.UseVisualStyleBackColor = true;
            this.limpiarButton.Click += new System.EventHandler(this.limpiarButton_Click);
            // 
            // guardarButton
            // 
            this.guardarButton.Location = new System.Drawing.Point(138, 163);
            this.guardarButton.Name = "guardarButton";
            this.guardarButton.Size = new System.Drawing.Size(100, 30);
            this.guardarButton.TabIndex = 35;
            this.guardarButton.Text = "Guardar";
            this.guardarButton.UseVisualStyleBackColor = true;
            // 
            // volverButton
            // 
            this.volverButton.Location = new System.Drawing.Point(265, 163);
            this.volverButton.Name = "volverButton";
            this.volverButton.Size = new System.Drawing.Size(100, 30);
            this.volverButton.TabIndex = 34;
            this.volverButton.Text = "Volver";
            this.volverButton.UseVisualStyleBackColor = true;
            this.volverButton.Click += new System.EventHandler(this.volverButton_Click);
            // 
            // camposObligatoriosLabel
            // 
            this.camposObligatoriosLabel.AutoSize = true;
            this.camposObligatoriosLabel.ForeColor = System.Drawing.Color.Red;
            this.camposObligatoriosLabel.Location = new System.Drawing.Point(12, 134);
            this.camposObligatoriosLabel.Name = "camposObligatoriosLabel";
            this.camposObligatoriosLabel.Size = new System.Drawing.Size(169, 13);
            this.camposObligatoriosLabel.TabIndex = 33;
            this.camposObligatoriosLabel.Text = "Todos los campos son obligatorios";
            // 
            // datosPersonalesGroupBox
            // 
            this.datosPersonalesGroupBox.Controls.Add(this.codPostalTextBox);
            this.datosPersonalesGroupBox.Controls.Add(this.direccionTextBox);
            this.datosPersonalesGroupBox.Controls.Add(this.nombreTextBox);
            this.datosPersonalesGroupBox.Controls.Add(this.codPostalLabel);
            this.datosPersonalesGroupBox.Controls.Add(this.direccionLabel);
            this.datosPersonalesGroupBox.Controls.Add(this.nombreLabel);
            this.datosPersonalesGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datosPersonalesGroupBox.Location = new System.Drawing.Point(12, 12);
            this.datosPersonalesGroupBox.Name = "datosPersonalesGroupBox";
            this.datosPersonalesGroupBox.Size = new System.Drawing.Size(351, 114);
            this.datosPersonalesGroupBox.TabIndex = 32;
            this.datosPersonalesGroupBox.TabStop = false;
            this.datosPersonalesGroupBox.Text = "Datos de la sucursal";
            // 
            // codPostalTextBox
            // 
            this.codPostalTextBox.Location = new System.Drawing.Point(117, 83);
            this.codPostalTextBox.Name = "codPostalTextBox";
            this.codPostalTextBox.Size = new System.Drawing.Size(217, 20);
            this.codPostalTextBox.TabIndex = 3;
            // 
            // direccionTextBox
            // 
            this.direccionTextBox.Location = new System.Drawing.Point(117, 55);
            this.direccionTextBox.Name = "direccionTextBox";
            this.direccionTextBox.Size = new System.Drawing.Size(217, 20);
            this.direccionTextBox.TabIndex = 2;
            // 
            // nombreTextBox
            // 
            this.nombreTextBox.Location = new System.Drawing.Point(117, 27);
            this.nombreTextBox.Name = "nombreTextBox";
            this.nombreTextBox.Size = new System.Drawing.Size(217, 20);
            this.nombreTextBox.TabIndex = 1;
            // 
            // codPostalLabel
            // 
            this.codPostalLabel.AutoSize = true;
            this.codPostalLabel.Location = new System.Drawing.Point(6, 86);
            this.codPostalLabel.Name = "codPostalLabel";
            this.codPostalLabel.Size = new System.Drawing.Size(72, 13);
            this.codPostalLabel.TabIndex = 2;
            this.codPostalLabel.Text = "Código Postal";
            // 
            // direccionLabel
            // 
            this.direccionLabel.AutoSize = true;
            this.direccionLabel.Location = new System.Drawing.Point(6, 58);
            this.direccionLabel.Name = "direccionLabel";
            this.direccionLabel.Size = new System.Drawing.Size(52, 13);
            this.direccionLabel.TabIndex = 1;
            this.direccionLabel.Text = "Dirección";
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
            // AltaModifSucursal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 205);
            this.Controls.Add(this.habilitadoCheckBox);
            this.Controls.Add(this.limpiarButton);
            this.Controls.Add(this.guardarButton);
            this.Controls.Add(this.volverButton);
            this.Controls.Add(this.camposObligatoriosLabel);
            this.Controls.Add(this.datosPersonalesGroupBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AltaModifSucursal";
            this.Text = "Alta y modificación de sucursal";
            this.datosPersonalesGroupBox.ResumeLayout(false);
            this.datosPersonalesGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox habilitadoCheckBox;
        private System.Windows.Forms.Button limpiarButton;
        private System.Windows.Forms.Button guardarButton;
        private System.Windows.Forms.Button volverButton;
        private System.Windows.Forms.Label camposObligatoriosLabel;
        private System.Windows.Forms.GroupBox datosPersonalesGroupBox;
        private System.Windows.Forms.TextBox codPostalTextBox;
        private System.Windows.Forms.TextBox direccionTextBox;
        private System.Windows.Forms.TextBox nombreTextBox;
        private System.Windows.Forms.Label direccionLabel;
        private System.Windows.Forms.Label nombreLabel;
        private System.Windows.Forms.Label codPostalLabel;
    }
}