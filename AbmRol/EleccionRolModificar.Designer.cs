namespace PagoAgilFrba.AbmRol
{
    partial class EleccionRolModificar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EleccionRolModificar));
            this.elegirRolLabel = new System.Windows.Forms.Label();
            this.modificarButton = new System.Windows.Forms.Button();
            this.volverButton = new System.Windows.Forms.Button();
            this.resultadoBusquedaDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.resultadoBusquedaDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // elegirRolLabel
            // 
            this.elegirRolLabel.AutoSize = true;
            this.elegirRolLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.elegirRolLabel.Location = new System.Drawing.Point(9, 9);
            this.elegirRolLabel.Name = "elegirRolLabel";
            this.elegirRolLabel.Size = new System.Drawing.Size(224, 16);
            this.elegirRolLabel.TabIndex = 0;
            this.elegirRolLabel.Text = "Elija el rol que quiere modificar";
            // 
            // modificarButton
            // 
            this.modificarButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modificarButton.Location = new System.Drawing.Point(12, 267);
            this.modificarButton.Name = "modificarButton";
            this.modificarButton.Size = new System.Drawing.Size(118, 29);
            this.modificarButton.TabIndex = 8;
            this.modificarButton.Text = "Modificar";
            this.modificarButton.UseVisualStyleBackColor = true;
            // 
            // volverButton
            // 
            this.volverButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.volverButton.Location = new System.Drawing.Point(273, 267);
            this.volverButton.Name = "volverButton";
            this.volverButton.Size = new System.Drawing.Size(118, 29);
            this.volverButton.TabIndex = 9;
            this.volverButton.Text = "Volver";
            this.volverButton.UseVisualStyleBackColor = true;
            this.volverButton.Click += new System.EventHandler(this.volverButton_Click);
            // 
            // resultadoBusquedaDataGridView
            // 
            this.resultadoBusquedaDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultadoBusquedaDataGridView.Location = new System.Drawing.Point(12, 38);
            this.resultadoBusquedaDataGridView.Name = "resultadoBusquedaDataGridView";
            this.resultadoBusquedaDataGridView.Size = new System.Drawing.Size(379, 213);
            this.resultadoBusquedaDataGridView.TabIndex = 10;
            // 
            // EleccionRolModificar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 313);
            this.Controls.Add(this.resultadoBusquedaDataGridView);
            this.Controls.Add(this.volverButton);
            this.Controls.Add(this.modificarButton);
            this.Controls.Add(this.elegirRolLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EleccionRolModificar";
            this.Text = "Listado de roles a modificar";
            ((System.ComponentModel.ISupportInitialize)(this.resultadoBusquedaDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label elegirRolLabel;
        private System.Windows.Forms.Button modificarButton;
        private System.Windows.Forms.Button volverButton;
        private System.Windows.Forms.DataGridView resultadoBusquedaDataGridView;

    }
}