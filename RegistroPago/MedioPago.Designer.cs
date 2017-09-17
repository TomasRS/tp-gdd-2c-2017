namespace PagoAgilFrba.RegistroPago
{
    partial class MedioPago
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MedioPago));
            this.label1 = new System.Windows.Forms.Label();
            this.medioDePagoGroupBox = new System.Windows.Forms.GroupBox();
            this.efectivoRadioButton = new System.Windows.Forms.RadioButton();
            this.pagarButton = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.volverButton = new System.Windows.Forms.Button();
            this.medioDePagoGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Seleccione el medio de pago";
            // 
            // medioDePagoGroupBox
            // 
            this.medioDePagoGroupBox.Controls.Add(this.radioButton1);
            this.medioDePagoGroupBox.Controls.Add(this.efectivoRadioButton);
            this.medioDePagoGroupBox.Location = new System.Drawing.Point(15, 38);
            this.medioDePagoGroupBox.Name = "medioDePagoGroupBox";
            this.medioDePagoGroupBox.Size = new System.Drawing.Size(331, 120);
            this.medioDePagoGroupBox.TabIndex = 2;
            this.medioDePagoGroupBox.TabStop = false;
            this.medioDePagoGroupBox.Text = "Medios de pago disponibles";
            // 
            // efectivoRadioButton
            // 
            this.efectivoRadioButton.AutoSize = true;
            this.efectivoRadioButton.Location = new System.Drawing.Point(122, 30);
            this.efectivoRadioButton.Name = "efectivoRadioButton";
            this.efectivoRadioButton.Size = new System.Drawing.Size(64, 17);
            this.efectivoRadioButton.TabIndex = 2;
            this.efectivoRadioButton.TabStop = true;
            this.efectivoRadioButton.Text = "Efectivo";
            this.efectivoRadioButton.UseVisualStyleBackColor = true;
            // 
            // pagarButton
            // 
            this.pagarButton.Location = new System.Drawing.Point(90, 164);
            this.pagarButton.Name = "pagarButton";
            this.pagarButton.Size = new System.Drawing.Size(93, 32);
            this.pagarButton.TabIndex = 3;
            this.pagarButton.Text = "Pagar y finalizar";
            this.pagarButton.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(122, 60);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(83, 17);
            this.radioButton1.TabIndex = 3;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Otra forma...";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // volverButton
            // 
            this.volverButton.Location = new System.Drawing.Point(189, 164);
            this.volverButton.Name = "volverButton";
            this.volverButton.Size = new System.Drawing.Size(93, 32);
            this.volverButton.TabIndex = 4;
            this.volverButton.Text = "Volver";
            this.volverButton.UseVisualStyleBackColor = true;
            // 
            // MedioPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 212);
            this.Controls.Add(this.volverButton);
            this.Controls.Add(this.pagarButton);
            this.Controls.Add(this.medioDePagoGroupBox);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MedioPago";
            this.Text = "Medio de Pago";
            this.Load += new System.EventHandler(this.MedioPago_Load);
            this.medioDePagoGroupBox.ResumeLayout(false);
            this.medioDePagoGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox medioDePagoGroupBox;
        private System.Windows.Forms.RadioButton efectivoRadioButton;
        private System.Windows.Forms.Button pagarButton;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Button volverButton;
    }
}