namespace PagoAgilFrba.HabilitacionUsuarios
{
    partial class HabilitacionUsuarios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HabilitacionUsuarios));
            this.volverButton = new System.Windows.Forms.Button();
            this.usuariosDataGridView = new System.Windows.Forms.DataGridView();
            this.habilitarUsuariosButton = new System.Windows.Forms.Button();
            this.sucursalLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.usuariosDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // volverButton
            // 
            this.volverButton.Location = new System.Drawing.Point(131, 239);
            this.volverButton.Name = "volverButton";
            this.volverButton.Size = new System.Drawing.Size(100, 30);
            this.volverButton.TabIndex = 7;
            this.volverButton.Text = "Volver al menú";
            this.volverButton.UseVisualStyleBackColor = true;
            this.volverButton.Click += new System.EventHandler(this.volverButton_Click);
            // 
            // usuariosDataGridView
            // 
            this.usuariosDataGridView.AllowUserToAddRows = false;
            this.usuariosDataGridView.AllowUserToDeleteRows = false;
            this.usuariosDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.usuariosDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.usuariosDataGridView.Location = new System.Drawing.Point(12, 43);
            this.usuariosDataGridView.Name = "usuariosDataGridView";
            this.usuariosDataGridView.ReadOnly = true;
            this.usuariosDataGridView.Size = new System.Drawing.Size(219, 182);
            this.usuariosDataGridView.TabIndex = 8;
            // 
            // habilitarUsuariosButton
            // 
            this.habilitarUsuariosButton.Location = new System.Drawing.Point(12, 239);
            this.habilitarUsuariosButton.Name = "habilitarUsuariosButton";
            this.habilitarUsuariosButton.Size = new System.Drawing.Size(96, 30);
            this.habilitarUsuariosButton.TabIndex = 9;
            this.habilitarUsuariosButton.Text = "Habilitar usuarios";
            this.habilitarUsuariosButton.UseVisualStyleBackColor = true;
            this.habilitarUsuariosButton.Click += new System.EventHandler(this.habilitarUsuariosButton_Click);
            // 
            // sucursalLabel
            // 
            this.sucursalLabel.AutoSize = true;
            this.sucursalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sucursalLabel.Location = new System.Drawing.Point(12, 13);
            this.sucursalLabel.Name = "sucursalLabel";
            this.sucursalLabel.Size = new System.Drawing.Size(219, 13);
            this.sucursalLabel.TabIndex = 10;
            this.sucursalLabel.Text = "Seleccione los usuarios para habilitar";
            // 
            // HabilitacionUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(245, 281);
            this.Controls.Add(this.sucursalLabel);
            this.Controls.Add(this.habilitarUsuariosButton);
            this.Controls.Add(this.usuariosDataGridView);
            this.Controls.Add(this.volverButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HabilitacionUsuarios";
            this.Text = "Habilitación de usuarios";
            this.Load += new System.EventHandler(this.HabilitacionUsuarios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.usuariosDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button volverButton;
        private System.Windows.Forms.DataGridView usuariosDataGridView;
        private System.Windows.Forms.Button habilitarUsuariosButton;
        private System.Windows.Forms.Label sucursalLabel;
    }
}