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

namespace PagoAgilFrba.Rendicion
{
    public partial class RendicionFacturas : Form
    {
        public RendicionFacturas()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void limpiarButton_Click(object sender, EventArgs e)
        {
            empresaComboBox.SelectedIndex = -1;
            facturasDataGridView.DataSource = null;
        }

        private void volverButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MenuPrincipal().ShowDialog();
            this.Close();
        }

        private void rendirFacturasButton_Click(object sender, EventArgs e)
        {

        }

        private void buscarFacturaButton_Click(object sender, EventArgs e)
        {

        }

        private void RendicionFacturas_Load(object sender, EventArgs e)
        {

        }
    }
}
