﻿namespace PagoAgilFrba.Login
{
    partial class EleccionRol
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EleccionRol));
            this.rolLabel = new System.Windows.Forms.Label();
            this.rolComboBox = new System.Windows.Forms.ComboBox();
            this.aceptarButton = new System.Windows.Forms.Button();
            this.cerrarSesionButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rolLabel
            // 
            this.rolLabel.AutoSize = true;
            this.rolLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rolLabel.Location = new System.Drawing.Point(33, 45);
            this.rolLabel.Name = "rolLabel";
            this.rolLabel.Size = new System.Drawing.Size(229, 13);
            this.rolLabel.TabIndex = 0;
            this.rolLabel.Text = "Elija el rol con el que se quiere loguear";
            // 
            // rolComboBox
            // 
            this.rolComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.rolComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rolComboBox.FormattingEnabled = true;
            this.rolComboBox.Location = new System.Drawing.Point(28, 76);
            this.rolComboBox.Name = "rolComboBox";
            this.rolComboBox.Size = new System.Drawing.Size(243, 21);
            this.rolComboBox.TabIndex = 1;
            // 
            // aceptarButton
            // 
            this.aceptarButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aceptarButton.Location = new System.Drawing.Point(92, 113);
            this.aceptarButton.Name = "aceptarButton";
            this.aceptarButton.Size = new System.Drawing.Size(118, 29);
            this.aceptarButton.TabIndex = 2;
            this.aceptarButton.Text = "Aceptar";
            this.aceptarButton.UseVisualStyleBackColor = true;
            this.aceptarButton.Click += new System.EventHandler(this.aceptarButton_Click);
            // 
            // cerrarSesionButton
            // 
            this.cerrarSesionButton.ForeColor = System.Drawing.Color.Red;
            this.cerrarSesionButton.Location = new System.Drawing.Point(216, 12);
            this.cerrarSesionButton.Name = "cerrarSesionButton";
            this.cerrarSesionButton.Size = new System.Drawing.Size(85, 23);
            this.cerrarSesionButton.TabIndex = 8;
            this.cerrarSesionButton.Text = "Cerrar sesión";
            this.cerrarSesionButton.UseVisualStyleBackColor = true;
            this.cerrarSesionButton.Click += new System.EventHandler(this.cerrarSesionButton_Click);
            // 
            // EleccionRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 158);
            this.Controls.Add(this.cerrarSesionButton);
            this.Controls.Add(this.aceptarButton);
            this.Controls.Add(this.rolComboBox);
            this.Controls.Add(this.rolLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EleccionRol";
            this.Text = "Elección de Rol";
            this.Load += new System.EventHandler(this.EleccionRol_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label rolLabel;
        private System.Windows.Forms.ComboBox rolComboBox;
        private System.Windows.Forms.Button aceptarButton;
        private System.Windows.Forms.Button cerrarSesionButton;
    }
}