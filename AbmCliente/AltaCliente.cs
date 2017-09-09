using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.AbmCliente
{
    public partial class AltaCliente : Form
    {
        public AltaCliente()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void limpiarButton_Click(object sender, EventArgs e)
        {
            nombreTextBox.Clear();
            apellidoTextBox.Clear();
            dniTextBox.Clear();
            fechaNacDateTimePicker.Text = "";
            mailTextBox.Clear();
            telefonoTextBox.Clear();
            calleTextBox.Clear();
            numeroTextBox.Clear();
            pisoTextBox.Clear();
            departamentoTextBox.Clear();
            localidadTextBox.Clear();
            codPostalTextBox.Clear();

        }
    }
}
