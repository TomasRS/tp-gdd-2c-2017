﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.AbmEmpresa
{
    public partial class AltaModifEmpresa : Form
    {
        public AltaModifEmpresa()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void limpiarButton_Click(object sender, EventArgs e)
        {
            nombreTextBox.Clear();
            cuitTextBox.Clear();
            direccionTextBox.Clear();
        }
    }
}