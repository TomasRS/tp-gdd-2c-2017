namespace PagoAgilFrba.Login
{
    partial class EleccionSucursal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EleccionSucursal));
            this.aceptarButton = new System.Windows.Forms.Button();
            this.sucursalComboBox = new System.Windows.Forms.ComboBox();
            this.sucursalLabel = new System.Windows.Forms.Label();
            this.cerrarSesionButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // aceptarButton
            // 
            this.aceptarButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aceptarButton.Location = new System.Drawing.Point(100, 117);
            this.aceptarButton.Name = "aceptarButton";
            this.aceptarButton.Size = new System.Drawing.Size(118, 29);
            this.aceptarButton.TabIndex = 6;
            this.aceptarButton.Text = "Aceptar";
            this.aceptarButton.UseVisualStyleBackColor = true;
            this.aceptarButton.Click += new System.EventHandler(this.aceptarButton_Click);
            // 
            // sucursalComboBox
            // 
            this.sucursalComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sucursalComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sucursalComboBox.FormattingEnabled = true;
            this.sucursalComboBox.Location = new System.Drawing.Point(38, 77);
            this.sucursalComboBox.Name = "sucursalComboBox";
            this.sucursalComboBox.Size = new System.Drawing.Size(243, 21);
            this.sucursalComboBox.TabIndex = 5;
            // 
            // sucursalLabel
            // 
            this.sucursalLabel.AutoSize = true;
            this.sucursalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sucursalLabel.Location = new System.Drawing.Point(25, 46);
            this.sucursalLabel.Name = "sucursalLabel";
            this.sucursalLabel.Size = new System.Drawing.Size(262, 13);
            this.sucursalLabel.TabIndex = 4;
            this.sucursalLabel.Text = "Elija la sucursal con la que se quiere loguear";
            // 
            // cerrarSesionButton
            // 
            this.cerrarSesionButton.ForeColor = System.Drawing.Color.Red;
            this.cerrarSesionButton.Location = new System.Drawing.Point(221, 12);
            this.cerrarSesionButton.Name = "cerrarSesionButton";
            this.cerrarSesionButton.Size = new System.Drawing.Size(85, 23);
            this.cerrarSesionButton.TabIndex = 7;
            this.cerrarSesionButton.Text = "Cerrar sesión";
            this.cerrarSesionButton.UseVisualStyleBackColor = true;
            this.cerrarSesionButton.Click += new System.EventHandler(this.cerrarSesionButton_Click);
            // 
            // EleccionSucursal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 164);
            this.Controls.Add(this.cerrarSesionButton);
            this.Controls.Add(this.aceptarButton);
            this.Controls.Add(this.sucursalComboBox);
            this.Controls.Add(this.sucursalLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EleccionSucursal";
            this.Text = "Elección de sucursal";
            this.Load += new System.EventHandler(this.EleccionSucursal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button aceptarButton;
        private System.Windows.Forms.ComboBox sucursalComboBox;
        private System.Windows.Forms.Label sucursalLabel;
        private System.Windows.Forms.Button cerrarSesionButton;
    }
}