﻿namespace PagoAgilFrba.AbmEmpresa
{
    partial class ListadoEmpresa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListadoEmpresa));
            this.empresasDataGridView = new System.Windows.Forms.DataGridView();
            this.filtroGroupBox = new System.Windows.Forms.GroupBox();
            this.limpiarButton = new System.Windows.Forms.Button();
            this.buscarButton = new System.Windows.Forms.Button();
            this.volverButton = new System.Windows.Forms.Button();
            this.cuitTextBox = new System.Windows.Forms.TextBox();
            this.nombreTextBox = new System.Windows.Forms.TextBox();
            this.rubroLabel = new System.Windows.Forms.Label();
            this.cuitLabel = new System.Windows.Forms.Label();
            this.nombreLabel = new System.Windows.Forms.Label();
            this.rubroComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.empresasDataGridView)).BeginInit();
            this.filtroGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // empresasDataGridView
            // 
            this.empresasDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.empresasDataGridView.Location = new System.Drawing.Point(12, 202);
            this.empresasDataGridView.Name = "empresasDataGridView";
            this.empresasDataGridView.Size = new System.Drawing.Size(638, 288);
            this.empresasDataGridView.TabIndex = 3;
            // 
            // filtroGroupBox
            // 
            this.filtroGroupBox.Controls.Add(this.rubroComboBox);
            this.filtroGroupBox.Controls.Add(this.limpiarButton);
            this.filtroGroupBox.Controls.Add(this.buscarButton);
            this.filtroGroupBox.Controls.Add(this.volverButton);
            this.filtroGroupBox.Controls.Add(this.cuitTextBox);
            this.filtroGroupBox.Controls.Add(this.nombreTextBox);
            this.filtroGroupBox.Controls.Add(this.rubroLabel);
            this.filtroGroupBox.Controls.Add(this.cuitLabel);
            this.filtroGroupBox.Controls.Add(this.nombreLabel);
            this.filtroGroupBox.Location = new System.Drawing.Point(12, 12);
            this.filtroGroupBox.Name = "filtroGroupBox";
            this.filtroGroupBox.Size = new System.Drawing.Size(638, 184);
            this.filtroGroupBox.TabIndex = 2;
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
            // 
            // volverButton
            // 
            this.volverButton.Location = new System.Drawing.Point(521, 137);
            this.volverButton.Name = "volverButton";
            this.volverButton.Size = new System.Drawing.Size(100, 30);
            this.volverButton.TabIndex = 6;
            this.volverButton.Text = "Volver";
            this.volverButton.UseVisualStyleBackColor = true;
            // 
            // cuitTextBox
            // 
            this.cuitTextBox.Location = new System.Drawing.Point(242, 57);
            this.cuitTextBox.Name = "cuitTextBox";
            this.cuitTextBox.Size = new System.Drawing.Size(184, 20);
            this.cuitTextBox.TabIndex = 4;
            // 
            // nombreTextBox
            // 
            this.nombreTextBox.Location = new System.Drawing.Point(242, 24);
            this.nombreTextBox.Name = "nombreTextBox";
            this.nombreTextBox.Size = new System.Drawing.Size(184, 20);
            this.nombreTextBox.TabIndex = 3;
            // 
            // rubroLabel
            // 
            this.rubroLabel.AutoSize = true;
            this.rubroLabel.Location = new System.Drawing.Point(172, 94);
            this.rubroLabel.Name = "rubroLabel";
            this.rubroLabel.Size = new System.Drawing.Size(36, 13);
            this.rubroLabel.TabIndex = 2;
            this.rubroLabel.Text = "Rubro";
            // 
            // cuitLabel
            // 
            this.cuitLabel.AutoSize = true;
            this.cuitLabel.Location = new System.Drawing.Point(172, 60);
            this.cuitLabel.Name = "cuitLabel";
            this.cuitLabel.Size = new System.Drawing.Size(32, 13);
            this.cuitLabel.TabIndex = 1;
            this.cuitLabel.Text = "CUIT";
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
            // rubroComboBox
            // 
            this.rubroComboBox.FormattingEnabled = true;
            this.rubroComboBox.Location = new System.Drawing.Point(242, 91);
            this.rubroComboBox.Name = "rubroComboBox";
            this.rubroComboBox.Size = new System.Drawing.Size(184, 21);
            this.rubroComboBox.TabIndex = 9;
            // 
            // ListadoEmpresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 501);
            this.Controls.Add(this.empresasDataGridView);
            this.Controls.Add(this.filtroGroupBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ListadoEmpresa";
            this.Text = "Listado de Empresas";
            ((System.ComponentModel.ISupportInitialize)(this.empresasDataGridView)).EndInit();
            this.filtroGroupBox.ResumeLayout(false);
            this.filtroGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView empresasDataGridView;
        private System.Windows.Forms.GroupBox filtroGroupBox;
        private System.Windows.Forms.ComboBox rubroComboBox;
        private System.Windows.Forms.Button limpiarButton;
        private System.Windows.Forms.Button buscarButton;
        private System.Windows.Forms.Button volverButton;
        private System.Windows.Forms.TextBox cuitTextBox;
        private System.Windows.Forms.TextBox nombreTextBox;
        private System.Windows.Forms.Label rubroLabel;
        private System.Windows.Forms.Label cuitLabel;
        private System.Windows.Forms.Label nombreLabel;
    }
}