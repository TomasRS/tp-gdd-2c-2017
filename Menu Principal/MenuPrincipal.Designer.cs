namespace PagoAgilFrba.Menu_Principal
{
    partial class MenuPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuPrincipal));
            this.accionLabel = new System.Windows.Forms.Label();
            this.accionesComboBox = new System.Windows.Forms.ComboBox();
            this.aceptarButton = new System.Windows.Forms.Button();
            this.cerrarSesionButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // accionLabel
            // 
            this.accionLabel.AutoSize = true;
            this.accionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accionLabel.Location = new System.Drawing.Point(45, 51);
            this.accionLabel.Name = "accionLabel";
            this.accionLabel.Size = new System.Drawing.Size(222, 16);
            this.accionLabel.TabIndex = 0;
            this.accionLabel.Text = "Seleccione la acción a realizar";
            // 
            // accionesComboBox
            // 
            this.accionesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.accionesComboBox.FormattingEnabled = true;
            this.accionesComboBox.Location = new System.Drawing.Point(42, 87);
            this.accionesComboBox.Name = "accionesComboBox";
            this.accionesComboBox.Size = new System.Drawing.Size(230, 21);
            this.accionesComboBox.TabIndex = 1;
            // 
            // aceptarButton
            // 
            this.aceptarButton.Location = new System.Drawing.Point(118, 124);
            this.aceptarButton.Name = "aceptarButton";
            this.aceptarButton.Size = new System.Drawing.Size(75, 23);
            this.aceptarButton.TabIndex = 2;
            this.aceptarButton.Text = "Aceptar";
            this.aceptarButton.UseVisualStyleBackColor = true;
            this.aceptarButton.Click += new System.EventHandler(this.aceptarButton_Click);
            // 
            // cerrarSesionButton
            // 
            this.cerrarSesionButton.ForeColor = System.Drawing.Color.Red;
            this.cerrarSesionButton.Location = new System.Drawing.Point(224, 12);
            this.cerrarSesionButton.Name = "cerrarSesionButton";
            this.cerrarSesionButton.Size = new System.Drawing.Size(85, 23);
            this.cerrarSesionButton.TabIndex = 3;
            this.cerrarSesionButton.Text = "Cerrar sesión";
            this.cerrarSesionButton.UseVisualStyleBackColor = true;
            this.cerrarSesionButton.Click += new System.EventHandler(this.cerrarSesionButton_Click);
            // 
            // MenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 174);
            this.Controls.Add(this.cerrarSesionButton);
            this.Controls.Add(this.aceptarButton);
            this.Controls.Add(this.accionesComboBox);
            this.Controls.Add(this.accionLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MenuPrincipal";
            this.Text = "Menú Principal";
            this.Load += new System.EventHandler(this.MenuPrincipal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label accionLabel;
        private System.Windows.Forms.ComboBox accionesComboBox;
        private System.Windows.Forms.Button aceptarButton;
        private System.Windows.Forms.Button cerrarSesionButton;
    }
}