namespace PagoAgilFrba.AbmRol
{
    partial class AltaModifRol
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AltaModifRol));
            this.tituloLabel = new System.Windows.Forms.Label();
            this.nombreLabel = new System.Windows.Forms.Label();
            this.nombreTextBox = new System.Windows.Forms.TextBox();
            this.funcionalidadesLabel = new System.Windows.Forms.Label();
            this.funcionalidadesListBox = new System.Windows.Forms.CheckedListBox();
            this.volverButton = new System.Windows.Forms.Button();
            this.actualizarButton = new System.Windows.Forms.Button();
            this.limpiarButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tituloLabel
            // 
            this.tituloLabel.AutoSize = true;
            this.tituloLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tituloLabel.Location = new System.Drawing.Point(12, 9);
            this.tituloLabel.Name = "tituloLabel";
            this.tituloLabel.Size = new System.Drawing.Size(172, 13);
            this.tituloLabel.TabIndex = 0;
            this.tituloLabel.Text = "Complete los siguentes datos";
            // 
            // nombreLabel
            // 
            this.nombreLabel.AutoSize = true;
            this.nombreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nombreLabel.Location = new System.Drawing.Point(13, 47);
            this.nombreLabel.Name = "nombreLabel";
            this.nombreLabel.Size = new System.Drawing.Size(44, 13);
            this.nombreLabel.TabIndex = 1;
            this.nombreLabel.Text = "Nombre";
            // 
            // nombreTextBox
            // 
            this.nombreTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nombreTextBox.Location = new System.Drawing.Point(105, 42);
            this.nombreTextBox.Name = "nombreTextBox";
            this.nombreTextBox.Size = new System.Drawing.Size(193, 20);
            this.nombreTextBox.TabIndex = 2;
            // 
            // funcionalidadesLabel
            // 
            this.funcionalidadesLabel.AutoSize = true;
            this.funcionalidadesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.funcionalidadesLabel.Location = new System.Drawing.Point(12, 88);
            this.funcionalidadesLabel.Name = "funcionalidadesLabel";
            this.funcionalidadesLabel.Size = new System.Drawing.Size(84, 13);
            this.funcionalidadesLabel.TabIndex = 3;
            this.funcionalidadesLabel.Text = "Funcionalidades";
            // 
            // funcionalidadesListBox
            // 
            this.funcionalidadesListBox.CheckOnClick = true;
            this.funcionalidadesListBox.FormattingEnabled = true;
            this.funcionalidadesListBox.Location = new System.Drawing.Point(105, 88);
            this.funcionalidadesListBox.Name = "funcionalidadesListBox";
            this.funcionalidadesListBox.Size = new System.Drawing.Size(193, 184);
            this.funcionalidadesListBox.TabIndex = 4;
            // 
            // volverButton
            // 
            this.volverButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.volverButton.Location = new System.Drawing.Point(222, 307);
            this.volverButton.Name = "volverButton";
            this.volverButton.Size = new System.Drawing.Size(76, 29);
            this.volverButton.TabIndex = 8;
            this.volverButton.Text = "Volver";
            this.volverButton.UseVisualStyleBackColor = true;
            this.volverButton.Click += new System.EventHandler(this.volverButton_Click);
            // 
            // actualizarButton
            // 
            this.actualizarButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.actualizarButton.Location = new System.Drawing.Point(114, 307);
            this.actualizarButton.Name = "actualizarButton";
            this.actualizarButton.Size = new System.Drawing.Size(86, 29);
            this.actualizarButton.TabIndex = 9;
            this.actualizarButton.Text = "Guardar";
            this.actualizarButton.UseVisualStyleBackColor = true;
            this.actualizarButton.Click += new System.EventHandler(this.actualizarButton_Click);
            // 
            // limpiarButton
            // 
            this.limpiarButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.limpiarButton.Location = new System.Drawing.Point(12, 307);
            this.limpiarButton.Name = "limpiarButton";
            this.limpiarButton.Size = new System.Drawing.Size(76, 29);
            this.limpiarButton.TabIndex = 10;
            this.limpiarButton.Text = "Limpiar";
            this.limpiarButton.UseVisualStyleBackColor = true;
            this.limpiarButton.Click += new System.EventHandler(this.limpiarButton_Click);
            // 
            // AltaModifRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 348);
            this.Controls.Add(this.limpiarButton);
            this.Controls.Add(this.actualizarButton);
            this.Controls.Add(this.volverButton);
            this.Controls.Add(this.funcionalidadesListBox);
            this.Controls.Add(this.funcionalidadesLabel);
            this.Controls.Add(this.nombreTextBox);
            this.Controls.Add(this.nombreLabel);
            this.Controls.Add(this.tituloLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AltaModifRol";
            this.Text = "Alta y modificación de Rol";
            this.Load += new System.EventHandler(this.AltaModifRol_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label tituloLabel;
        private System.Windows.Forms.Label nombreLabel;
        private System.Windows.Forms.TextBox nombreTextBox;
        private System.Windows.Forms.Label funcionalidadesLabel;
        private System.Windows.Forms.CheckedListBox funcionalidadesListBox;
        private System.Windows.Forms.Button volverButton;
        private System.Windows.Forms.Button actualizarButton;
        private System.Windows.Forms.Button limpiarButton;

    }
}