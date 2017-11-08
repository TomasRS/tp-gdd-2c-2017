namespace PagoAgilFrba.AbmSucursal
{
    partial class AsignacionSucursalesAUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AsignacionSucursalesAUsuario));
            this.usuariosComboBox = new System.Windows.Forms.ComboBox();
            this.sucursalesCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.limpiarButton = new System.Windows.Forms.Button();
            this.actualizarButton = new System.Windows.Forms.Button();
            this.volverButton = new System.Windows.Forms.Button();
            this.funcionalidadesLabel = new System.Windows.Forms.Label();
            this.nombreLabel = new System.Windows.Forms.Label();
            this.tituloLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // usuariosComboBox
            // 
            this.usuariosComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.usuariosComboBox.FormattingEnabled = true;
            this.usuariosComboBox.Location = new System.Drawing.Point(105, 44);
            this.usuariosComboBox.Name = "usuariosComboBox";
            this.usuariosComboBox.Size = new System.Drawing.Size(193, 21);
            this.usuariosComboBox.TabIndex = 28;
            this.usuariosComboBox.SelectedIndexChanged += new System.EventHandler(this.usuariosComboBox_SelectedIndexChanged);
            // 
            // sucursalesCheckedListBox
            // 
            this.sucursalesCheckedListBox.CheckOnClick = true;
            this.sucursalesCheckedListBox.FormattingEnabled = true;
            this.sucursalesCheckedListBox.Location = new System.Drawing.Point(105, 88);
            this.sucursalesCheckedListBox.Name = "sucursalesCheckedListBox";
            this.sucursalesCheckedListBox.Size = new System.Drawing.Size(193, 199);
            this.sucursalesCheckedListBox.TabIndex = 27;
            // 
            // limpiarButton
            // 
            this.limpiarButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.limpiarButton.Location = new System.Drawing.Point(12, 307);
            this.limpiarButton.Name = "limpiarButton";
            this.limpiarButton.Size = new System.Drawing.Size(76, 29);
            this.limpiarButton.TabIndex = 26;
            this.limpiarButton.Text = "Limpiar";
            this.limpiarButton.UseVisualStyleBackColor = true;
            this.limpiarButton.Click += new System.EventHandler(this.limpiarButton_Click);
            // 
            // actualizarButton
            // 
            this.actualizarButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.actualizarButton.Location = new System.Drawing.Point(114, 307);
            this.actualizarButton.Name = "actualizarButton";
            this.actualizarButton.Size = new System.Drawing.Size(86, 29);
            this.actualizarButton.TabIndex = 25;
            this.actualizarButton.Text = "Guardar";
            this.actualizarButton.UseVisualStyleBackColor = true;
            this.actualizarButton.Click += new System.EventHandler(this.actualizarButton_Click);
            // 
            // volverButton
            // 
            this.volverButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.volverButton.Location = new System.Drawing.Point(222, 307);
            this.volverButton.Name = "volverButton";
            this.volverButton.Size = new System.Drawing.Size(76, 29);
            this.volverButton.TabIndex = 24;
            this.volverButton.Text = "Volver";
            this.volverButton.UseVisualStyleBackColor = true;
            this.volverButton.Click += new System.EventHandler(this.volverButton_Click);
            // 
            // funcionalidadesLabel
            // 
            this.funcionalidadesLabel.AutoSize = true;
            this.funcionalidadesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.funcionalidadesLabel.Location = new System.Drawing.Point(12, 88);
            this.funcionalidadesLabel.Name = "funcionalidadesLabel";
            this.funcionalidadesLabel.Size = new System.Drawing.Size(34, 13);
            this.funcionalidadesLabel.TabIndex = 23;
            this.funcionalidadesLabel.Text = "Roles";
            // 
            // nombreLabel
            // 
            this.nombreLabel.AutoSize = true;
            this.nombreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nombreLabel.Location = new System.Drawing.Point(13, 47);
            this.nombreLabel.Name = "nombreLabel";
            this.nombreLabel.Size = new System.Drawing.Size(55, 13);
            this.nombreLabel.TabIndex = 22;
            this.nombreLabel.Text = "Username";
            // 
            // tituloLabel
            // 
            this.tituloLabel.AutoSize = true;
            this.tituloLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tituloLabel.Location = new System.Drawing.Point(12, 9);
            this.tituloLabel.Name = "tituloLabel";
            this.tituloLabel.Size = new System.Drawing.Size(172, 13);
            this.tituloLabel.TabIndex = 21;
            this.tituloLabel.Text = "Complete los siguentes datos";
            // 
            // AsignacionSucursalesAUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 348);
            this.Controls.Add(this.usuariosComboBox);
            this.Controls.Add(this.sucursalesCheckedListBox);
            this.Controls.Add(this.limpiarButton);
            this.Controls.Add(this.actualizarButton);
            this.Controls.Add(this.volverButton);
            this.Controls.Add(this.funcionalidadesLabel);
            this.Controls.Add(this.nombreLabel);
            this.Controls.Add(this.tituloLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AsignacionSucursalesAUsuario";
            this.Text = "Asignación de sucursales al usuario";
            this.Load += new System.EventHandler(this.AsignacionSucursalesAUsuario_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox usuariosComboBox;
        private System.Windows.Forms.CheckedListBox sucursalesCheckedListBox;
        private System.Windows.Forms.Button limpiarButton;
        private System.Windows.Forms.Button actualizarButton;
        private System.Windows.Forms.Button volverButton;
        private System.Windows.Forms.Label funcionalidadesLabel;
        private System.Windows.Forms.Label nombreLabel;
        private System.Windows.Forms.Label tituloLabel;
    }
}