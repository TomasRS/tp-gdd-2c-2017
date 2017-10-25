using PagoAgilFrba.Menu_Principal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.RegistroPago
{
    public partial class RegistroPagoFacturas : Form
    {
        public RegistroPagoFacturas()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void limpiarButton_Click(object sender, EventArgs e)
        {
            numFacturaTextBox.Clear();
            importeTextBox.Clear();
            sucursalTextBox.Clear();
            fechaCobroDateTimePicker.Text = "";
            fechaVencFactDateTimePicker.Text = "";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            facturasDataGridView.DataSource = null;
        }

        private void volverButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MenuPrincipal().ShowDialog();
            this.Close();
        }
    }
}
