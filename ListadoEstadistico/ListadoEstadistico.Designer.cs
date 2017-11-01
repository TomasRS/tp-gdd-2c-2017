namespace PagoAgilFrba.ListadoEstadistico
{
    partial class ListadoEstadistico
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListadoEstadistico));
            this.estadisticasDataGridView = new System.Windows.Forms.DataGridView();
            this.filtroGroupBox = new System.Windows.Forms.GroupBox();
            this.tipoListadoComboBox = new System.Windows.Forms.ComboBox();
            this.trimestreComboBox = new System.Windows.Forms.ComboBox();
            this.limpiarButton = new System.Windows.Forms.Button();
            this.buscarButton = new System.Windows.Forms.Button();
            this.volverButton = new System.Windows.Forms.Button();
            this.anioTextBox = new System.Windows.Forms.TextBox();
            this.tipoListadoLabel = new System.Windows.Forms.Label();
            this.trimestreLabel = new System.Windows.Forms.Label();
            this.anioLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.estadisticasDataGridView)).BeginInit();
            this.filtroGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // estadisticasDataGridView
            // 
            this.estadisticasDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.estadisticasDataGridView.Location = new System.Drawing.Point(3, 195);
            this.estadisticasDataGridView.Name = "estadisticasDataGridView";
            this.estadisticasDataGridView.Size = new System.Drawing.Size(638, 233);
            this.estadisticasDataGridView.TabIndex = 7;
            // 
            // filtroGroupBox
            // 
            this.filtroGroupBox.Controls.Add(this.tipoListadoComboBox);
            this.filtroGroupBox.Controls.Add(this.trimestreComboBox);
            this.filtroGroupBox.Controls.Add(this.limpiarButton);
            this.filtroGroupBox.Controls.Add(this.buscarButton);
            this.filtroGroupBox.Controls.Add(this.volverButton);
            this.filtroGroupBox.Controls.Add(this.anioTextBox);
            this.filtroGroupBox.Controls.Add(this.tipoListadoLabel);
            this.filtroGroupBox.Controls.Add(this.trimestreLabel);
            this.filtroGroupBox.Controls.Add(this.anioLabel);
            this.filtroGroupBox.Location = new System.Drawing.Point(3, 5);
            this.filtroGroupBox.Name = "filtroGroupBox";
            this.filtroGroupBox.Size = new System.Drawing.Size(638, 184);
            this.filtroGroupBox.TabIndex = 6;
            this.filtroGroupBox.TabStop = false;
            this.filtroGroupBox.Text = "Filtro de búsqueda";
            // 
            // tipoListadoComboBox
            // 
            this.tipoListadoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tipoListadoComboBox.FormattingEnabled = true;
            this.tipoListadoComboBox.Location = new System.Drawing.Point(208, 92);
            this.tipoListadoComboBox.Name = "tipoListadoComboBox";
            this.tipoListadoComboBox.Size = new System.Drawing.Size(248, 21);
            this.tipoListadoComboBox.TabIndex = 11;
            // 
            // trimestreComboBox
            // 
            this.trimestreComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.trimestreComboBox.FormattingEnabled = true;
            this.trimestreComboBox.Location = new System.Drawing.Point(208, 58);
            this.trimestreComboBox.Name = "trimestreComboBox";
            this.trimestreComboBox.Size = new System.Drawing.Size(248, 21);
            this.trimestreComboBox.TabIndex = 10;
            // 
            // limpiarButton
            // 
            this.limpiarButton.Location = new System.Drawing.Point(17, 137);
            this.limpiarButton.Name = "limpiarButton";
            this.limpiarButton.Size = new System.Drawing.Size(100, 30);
            this.limpiarButton.TabIndex = 8;
            this.limpiarButton.Text = "Limpiar";
            this.limpiarButton.UseVisualStyleBackColor = true;
            this.limpiarButton.Click += new System.EventHandler(this.limpiarButton_Click);
            // 
            // buscarButton
            // 
            this.buscarButton.Location = new System.Drawing.Point(269, 137);
            this.buscarButton.Name = "buscarButton";
            this.buscarButton.Size = new System.Drawing.Size(100, 30);
            this.buscarButton.TabIndex = 7;
            this.buscarButton.Text = "Buscar";
            this.buscarButton.UseVisualStyleBackColor = true;
            // 
            // volverButton
            // 
            this.volverButton.Location = new System.Drawing.Point(521, 137);
            this.volverButton.Name = "volverButton";
            this.volverButton.Size = new System.Drawing.Size(100, 30);
            this.volverButton.TabIndex = 6;
            this.volverButton.Text = "Volver";
            this.volverButton.UseVisualStyleBackColor = true;
            this.volverButton.Click += new System.EventHandler(this.volverButton_Click);
            // 
            // anioTextBox
            // 
            this.anioTextBox.Location = new System.Drawing.Point(208, 25);
            this.anioTextBox.Name = "anioTextBox";
            this.anioTextBox.Size = new System.Drawing.Size(248, 20);
            this.anioTextBox.TabIndex = 3;
            // 
            // tipoListadoLabel
            // 
            this.tipoListadoLabel.AutoSize = true;
            this.tipoListadoLabel.Location = new System.Drawing.Point(122, 95);
            this.tipoListadoLabel.Name = "tipoListadoLabel";
            this.tipoListadoLabel.Size = new System.Drawing.Size(76, 13);
            this.tipoListadoLabel.TabIndex = 2;
            this.tipoListadoLabel.Text = "Tipo de listado";
            // 
            // trimestreLabel
            // 
            this.trimestreLabel.AutoSize = true;
            this.trimestreLabel.Location = new System.Drawing.Point(122, 61);
            this.trimestreLabel.Name = "trimestreLabel";
            this.trimestreLabel.Size = new System.Drawing.Size(50, 13);
            this.trimestreLabel.TabIndex = 1;
            this.trimestreLabel.Text = "Trimestre";
            // 
            // anioLabel
            // 
            this.anioLabel.AutoSize = true;
            this.anioLabel.Location = new System.Drawing.Point(122, 28);
            this.anioLabel.Name = "anioLabel";
            this.anioLabel.Size = new System.Drawing.Size(26, 13);
            this.anioLabel.TabIndex = 0;
            this.anioLabel.Text = "Año";
            // 
            // ListadoEstadistico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 436);
            this.Controls.Add(this.estadisticasDataGridView);
            this.Controls.Add(this.filtroGroupBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ListadoEstadistico";
            this.Text = "Listado estadístico";
            this.Load += new System.EventHandler(this.ListadoEstadistico_Load);
            ((System.ComponentModel.ISupportInitialize)(this.estadisticasDataGridView)).EndInit();
            this.filtroGroupBox.ResumeLayout(false);
            this.filtroGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView estadisticasDataGridView;
        private System.Windows.Forms.GroupBox filtroGroupBox;
        private System.Windows.Forms.ComboBox tipoListadoComboBox;
        private System.Windows.Forms.ComboBox trimestreComboBox;
        private System.Windows.Forms.Button limpiarButton;
        private System.Windows.Forms.Button buscarButton;
        private System.Windows.Forms.Button volverButton;
        private System.Windows.Forms.TextBox anioTextBox;
        private System.Windows.Forms.Label tipoListadoLabel;
        private System.Windows.Forms.Label trimestreLabel;
        private System.Windows.Forms.Label anioLabel;
    }
}