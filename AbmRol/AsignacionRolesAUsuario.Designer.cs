namespace PagoAgilFrba.AbmRol
{
    partial class AsignacionRolesAUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AsignacionRolesAUsuario));
            this.rolesCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.limpiarButton = new System.Windows.Forms.Button();
            this.actualizarButton = new System.Windows.Forms.Button();
            this.volverButton = new System.Windows.Forms.Button();
            this.funcionalidadesLabel = new System.Windows.Forms.Label();
            this.nombreLabel = new System.Windows.Forms.Label();
            this.tituloLabel = new System.Windows.Forms.Label();
            this.usuariosComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // rolesCheckedListBox
            // 
            this.rolesCheckedListBox.CheckOnClick = true;
            this.rolesCheckedListBox.FormattingEnabled = true;
            this.rolesCheckedListBox.Location = new System.Drawing.Point(103, 89);
            this.rolesCheckedListBox.Name = "rolesCheckedListBox";
            this.rolesCheckedListBox.Size = new System.Drawing.Size(193, 199);
            this.rolesCheckedListBox.TabIndex = 19;
            // 
            // limpiarButton
            // 
            this.limpiarButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.limpiarButton.Location = new System.Drawing.Point(10, 308);
            this.limpiarButton.Name = "limpiarButton";
            this.limpiarButton.Size = new System.Drawing.Size(76, 29);
            this.limpiarButton.TabIndex = 18;
            this.limpiarButton.Text = "Limpiar";
            this.limpiarButton.UseVisualStyleBackColor = true;
            this.limpiarButton.Click += new System.EventHandler(this.limpiarButton_Click);
            // 
            // actualizarButton
            // 
            this.actualizarButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.actualizarButton.Location = new System.Drawing.Point(112, 308);
            this.actualizarButton.Name = "actualizarButton";
            this.actualizarButton.Size = new System.Drawing.Size(86, 29);
            this.actualizarButton.TabIndex = 17;
            this.actualizarButton.Text = "Guardar";
            this.actualizarButton.UseVisualStyleBackColor = true;
            this.actualizarButton.Click += new System.EventHandler(this.actualizarButton_Click);
            // 
            // volverButton
            // 
            this.volverButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.volverButton.Location = new System.Drawing.Point(220, 308);
            this.volverButton.Name = "volverButton";
            this.volverButton.Size = new System.Drawing.Size(76, 29);
            this.volverButton.TabIndex = 16;
            this.volverButton.Text = "Volver";
            this.volverButton.UseVisualStyleBackColor = true;
            this.volverButton.Click += new System.EventHandler(this.volverButton_Click);
            // 
            // funcionalidadesLabel
            // 
            this.funcionalidadesLabel.AutoSize = true;
            this.funcionalidadesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.funcionalidadesLabel.Location = new System.Drawing.Point(10, 89);
            this.funcionalidadesLabel.Name = "funcionalidadesLabel";
            this.funcionalidadesLabel.Size = new System.Drawing.Size(34, 13);
            this.funcionalidadesLabel.TabIndex = 15;
            this.funcionalidadesLabel.Text = "Roles";
            // 
            // nombreLabel
            // 
            this.nombreLabel.AutoSize = true;
            this.nombreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nombreLabel.Location = new System.Drawing.Point(11, 48);
            this.nombreLabel.Name = "nombreLabel";
            this.nombreLabel.Size = new System.Drawing.Size(55, 13);
            this.nombreLabel.TabIndex = 13;
            this.nombreLabel.Text = "Username";
            // 
            // tituloLabel
            // 
            this.tituloLabel.AutoSize = true;
            this.tituloLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tituloLabel.Location = new System.Drawing.Point(10, 10);
            this.tituloLabel.Name = "tituloLabel";
            this.tituloLabel.Size = new System.Drawing.Size(172, 13);
            this.tituloLabel.TabIndex = 12;
            this.tituloLabel.Text = "Complete los siguentes datos";
            // 
            // usuariosComboBox
            // 
            this.usuariosComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.usuariosComboBox.FormattingEnabled = true;
            this.usuariosComboBox.Location = new System.Drawing.Point(103, 45);
            this.usuariosComboBox.Name = "usuariosComboBox";
            this.usuariosComboBox.Size = new System.Drawing.Size(193, 21);
            this.usuariosComboBox.TabIndex = 20;
            this.usuariosComboBox.SelectedIndexChanged += new System.EventHandler(this.usuariosComboBox_SelectedIndexChanged);
            // 
            // AsignacionRolesAUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 354);
            this.Controls.Add(this.usuariosComboBox);
            this.Controls.Add(this.rolesCheckedListBox);
            this.Controls.Add(this.limpiarButton);
            this.Controls.Add(this.actualizarButton);
            this.Controls.Add(this.volverButton);
            this.Controls.Add(this.funcionalidadesLabel);
            this.Controls.Add(this.nombreLabel);
            this.Controls.Add(this.tituloLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AsignacionRolesAUsuario";
            this.Text = "Asignación de roles al usuario";
            this.Load += new System.EventHandler(this.AsignacionRolesAUsuario_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox rolesCheckedListBox;
        private System.Windows.Forms.Button limpiarButton;
        private System.Windows.Forms.Button actualizarButton;
        private System.Windows.Forms.Button volverButton;
        private System.Windows.Forms.Label funcionalidadesLabel;
        private System.Windows.Forms.Label nombreLabel;
        private System.Windows.Forms.Label tituloLabel;
        private System.Windows.Forms.ComboBox usuariosComboBox;
    }
}