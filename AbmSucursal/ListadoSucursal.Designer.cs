namespace PagoAgilFrba.AbmSucursal
{
    partial class ListadoSucursal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListadoSucursal));
            this.sucursalesDataGridView = new System.Windows.Forms.DataGridView();
            this.filtroGroupBox = new System.Windows.Forms.GroupBox();
            this.codPostalTextBox = new System.Windows.Forms.TextBox();
            this.limpiarButton = new System.Windows.Forms.Button();
            this.buscarButton = new System.Windows.Forms.Button();
            this.volverButton = new System.Windows.Forms.Button();
            this.direccionTextBox = new System.Windows.Forms.TextBox();
            this.nombreTextBox = new System.Windows.Forms.TextBox();
            this.codPostalLabel = new System.Windows.Forms.Label();
            this.direccionLabel = new System.Windows.Forms.Label();
            this.nombreLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.sucursalesDataGridView)).BeginInit();
            this.filtroGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // sucursalesDataGridView
            // 
            this.sucursalesDataGridView.AllowUserToAddRows = false;
            this.sucursalesDataGridView.AllowUserToDeleteRows = false;
            this.sucursalesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sucursalesDataGridView.Location = new System.Drawing.Point(12, 202);
            this.sucursalesDataGridView.Name = "sucursalesDataGridView";
            this.sucursalesDataGridView.ReadOnly = true;
            this.sucursalesDataGridView.Size = new System.Drawing.Size(638, 288);
            this.sucursalesDataGridView.TabIndex = 5;
            this.sucursalesDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.sucursalesDataGridView_CellContentClick );
            // 
            // filtroGroupBox
            // 
            this.filtroGroupBox.Controls.Add(this.codPostalTextBox);
            this.filtroGroupBox.Controls.Add(this.limpiarButton);
            this.filtroGroupBox.Controls.Add(this.buscarButton);
            this.filtroGroupBox.Controls.Add(this.volverButton);
            this.filtroGroupBox.Controls.Add(this.direccionTextBox);
            this.filtroGroupBox.Controls.Add(this.nombreTextBox);
            this.filtroGroupBox.Controls.Add(this.codPostalLabel);
            this.filtroGroupBox.Controls.Add(this.direccionLabel);
            this.filtroGroupBox.Controls.Add(this.nombreLabel);
            this.filtroGroupBox.Location = new System.Drawing.Point(12, 12);
            this.filtroGroupBox.Name = "filtroGroupBox";
            this.filtroGroupBox.Size = new System.Drawing.Size(638, 184);
            this.filtroGroupBox.TabIndex = 4;
            this.filtroGroupBox.TabStop = false;
            this.filtroGroupBox.Text = "Filtro de búsqueda";
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
            this.buscarButton.Click += new System.EventHandler(this.buscarButton_Click);
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
            // codPostalTextBox
            // 
            this.codPostalTextBox.Location = new System.Drawing.Point(242, 91);
            this.codPostalTextBox.Name = "codPostalTextBox";
            this.codPostalTextBox.Size = new System.Drawing.Size(184, 20);
            this.codPostalTextBox.TabIndex = 5;
            // 
            // direccionTextBox
            // 
            this.direccionTextBox.Location = new System.Drawing.Point(242, 57);
            this.direccionTextBox.Name = "direccionTextBox";
            this.direccionTextBox.Size = new System.Drawing.Size(184, 20);
            this.direccionTextBox.TabIndex = 4;
            // 
            // nombreTextBox
            // 
            this.nombreTextBox.Location = new System.Drawing.Point(242, 24);
            this.nombreTextBox.Name = "nombreTextBox";
            this.nombreTextBox.Size = new System.Drawing.Size(184, 20);
            this.nombreTextBox.TabIndex = 3;
            // 
            // codPostalLabel
            // 
            this.codPostalLabel.AutoSize = true;
            this.codPostalLabel.Location = new System.Drawing.Point(172, 94);
            this.codPostalLabel.Name = "codPostalLabel";
            this.codPostalLabel.Size = new System.Drawing.Size(36, 13);
            this.codPostalLabel.TabIndex = 2;
            this.codPostalLabel.Text = "Codigo Postal";
            // 
            // direccionLabel
            // 
            this.direccionLabel.AutoSize = true;
            this.direccionLabel.Location = new System.Drawing.Point(172, 60);
            this.direccionLabel.Name = "direccionLabel";
            this.direccionLabel.Size = new System.Drawing.Size(52, 13);
            this.direccionLabel.TabIndex = 1;
            this.direccionLabel.Text = "Dirección";
            // 
            // nombreLabel
            // 
            this.nombreLabel.AutoSize = true;
            this.nombreLabel.Location = new System.Drawing.Point(172, 27);
            this.nombreLabel.Name = "nombreLabel";
            this.nombreLabel.Size = new System.Drawing.Size(44, 13);
            this.nombreLabel.TabIndex = 0;
            this.nombreLabel.Text = "Nombre";
            // 
            // ListadoSucursal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 497);
            this.Controls.Add(this.sucursalesDataGridView);
            this.Controls.Add(this.filtroGroupBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ListadoSucursal";
            this.Text = "Listado de Sucursales";
            this.Load += new System.EventHandler(this.ListadoSucursal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sucursalesDataGridView)).EndInit();
            this.filtroGroupBox.ResumeLayout(false);
            this.filtroGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView sucursalesDataGridView;
        private System.Windows.Forms.GroupBox filtroGroupBox;
        private System.Windows.Forms.Button limpiarButton;
        private System.Windows.Forms.Button buscarButton;
        private System.Windows.Forms.Button volverButton;
        private System.Windows.Forms.TextBox direccionTextBox;
        private System.Windows.Forms.TextBox nombreTextBox;
        private System.Windows.Forms.Label codPostalLabel;
        private System.Windows.Forms.Label direccionLabel;
        private System.Windows.Forms.Label nombreLabel;
        private System.Windows.Forms.TextBox codPostalTextBox;
    }
}