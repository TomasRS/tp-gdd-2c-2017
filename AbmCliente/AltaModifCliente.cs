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
    /*Ya que la funcionalidad para alta y modificacion de cliente es practicamente la misma,
     (lo unico que cambia es el check de "Modificado") podemos reusar la misma UI y en base
     a si se llego a esta pantalla con la intencion de modificar o dar de alta se muestra o
     se esconde el checkbox*/
    public partial class AltaModifCliente : Form
    {
        public AltaModifCliente()
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
            habilitadoCheckBox.Checked = false;
        }

        private void volverButton_Click(object sender, EventArgs e)
        {

        }
    }
}
