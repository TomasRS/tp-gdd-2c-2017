﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.AbmRol
{
    public partial class EleccionRolModificar : Form
    {
        public EleccionRolModificar()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void volverButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AbmRol().Show();
            this.Close();
        }
    }
}
