namespace PagoAgilFrba.AbmRol
{
    partial class ListadoRol
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListadoRol));
            this.elegirRolLabel = new System.Windows.Forms.Label();
            this.volverButton = new System.Windows.Forms.Button();
            this.RolesDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.RolesDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // elegirRolLabel
            // 
            this.elegirRolLabel.AutoSize = true;
            this.elegirRolLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.elegirRolLabel.Location = new System.Drawing.Point(9, 9);
            this.elegirRolLabel.Name = "elegirRolLabel";
            this.elegirRolLabel.Size = new System.Drawing.Size(240, 13);
            this.elegirRolLabel.TabIndex = 0;
            this.elegirRolLabel.Text = "Elija el rol que quiere modificar o eliminar";
            // 
            // volverButton
            // 
            this.volverButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.volverButton.Location = new System.Drawing.Point(175, 262);
            this.volverButton.Name = "volverButton";
            this.volverButton.Size = new System.Drawing.Size(118, 29);
            this.volverButton.TabIndex = 9;
            this.volverButton.Text = "Volver";
            this.volverButton.UseVisualStyleBackColor = true;
            this.volverButton.Click += new System.EventHandler(this.volverButton_Click);
            // 
            // RolesDataGridView
            // 
            this.RolesDataGridView.AllowUserToAddRows = false;
            this.RolesDataGridView.AllowUserToDeleteRows = false;
            this.RolesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RolesDataGridView.Location = new System.Drawing.Point(12, 38);
            this.RolesDataGridView.Name = "RolesDataGridView";
            this.RolesDataGridView.ReadOnly = true;
            this.RolesDataGridView.Size = new System.Drawing.Size(445, 213);
            this.RolesDataGridView.TabIndex = 10;
            this.RolesDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.clientesDataGridView_CellContentClick);
            // 
            // ListadoRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 303);
            this.Controls.Add(this.RolesDataGridView);
            this.Controls.Add(this.volverButton);
            this.Controls.Add(this.elegirRolLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ListadoRol";
            this.Text = "Listado de roles";
            this.Load += new System.EventHandler(this.ListadoRol_Load);
            ((System.ComponentModel.ISupportInitialize)(this.RolesDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label elegirRolLabel;
        private System.Windows.Forms.Button volverButton;
        private System.Windows.Forms.DataGridView RolesDataGridView;

    }
}