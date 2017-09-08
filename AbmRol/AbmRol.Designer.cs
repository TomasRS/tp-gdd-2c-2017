namespace PagoAgilFrba.AbmRol
{
    partial class AbmRol
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AbmRol));
            this.altaRolButton = new System.Windows.Forms.Button();
            this.volverButton = new System.Windows.Forms.Button();
            this.modificarRolButton = new System.Windows.Forms.Button();
            this.bajaRolButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // altaRolButton
            // 
            this.altaRolButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.altaRolButton.Location = new System.Drawing.Point(73, 21);
            this.altaRolButton.Name = "altaRolButton";
            this.altaRolButton.Size = new System.Drawing.Size(118, 43);
            this.altaRolButton.TabIndex = 8;
            this.altaRolButton.Text = "Alta de Rol";
            this.altaRolButton.UseVisualStyleBackColor = true;
            // 
            // volverButton
            // 
            this.volverButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.volverButton.Location = new System.Drawing.Point(73, 251);
            this.volverButton.Name = "volverButton";
            this.volverButton.Size = new System.Drawing.Size(118, 29);
            this.volverButton.TabIndex = 7;
            this.volverButton.Text = "Volver";
            this.volverButton.UseVisualStyleBackColor = true;
            // 
            // modificarRolButton
            // 
            this.modificarRolButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modificarRolButton.Location = new System.Drawing.Point(73, 90);
            this.modificarRolButton.Name = "modificarRolButton";
            this.modificarRolButton.Size = new System.Drawing.Size(118, 43);
            this.modificarRolButton.TabIndex = 9;
            this.modificarRolButton.Text = "Modificación de Rol";
            this.modificarRolButton.UseVisualStyleBackColor = true;
            // 
            // bajaRolButton
            // 
            this.bajaRolButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bajaRolButton.Location = new System.Drawing.Point(73, 160);
            this.bajaRolButton.Name = "bajaRolButton";
            this.bajaRolButton.Size = new System.Drawing.Size(118, 43);
            this.bajaRolButton.TabIndex = 10;
            this.bajaRolButton.Text = "Baja de Rol";
            this.bajaRolButton.UseVisualStyleBackColor = true;
            // 
            // AbmRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(271, 292);
            this.Controls.Add(this.bajaRolButton);
            this.Controls.Add(this.modificarRolButton);
            this.Controls.Add(this.altaRolButton);
            this.Controls.Add(this.volverButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AbmRol";
            this.Text = "ABM Rol";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button altaRolButton;
        private System.Windows.Forms.Button volverButton;
        private System.Windows.Forms.Button modificarRolButton;
        private System.Windows.Forms.Button bajaRolButton;

    }
}