using System;
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
    public partial class ModificarRol : Form
    {
        public ModificarRol()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void volverAlMenuDeRolButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AbmRol().Show();
            this.Close();
        }

        private void editarOtroRolButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            new EleccionRolModificar().Show();
            this.Close();
        }

        private void limpiarButton_Click(object sender, EventArgs e)
        {
            rolTextBox.Clear();
            //cargarFuncionalidades();
        }
    }
}
