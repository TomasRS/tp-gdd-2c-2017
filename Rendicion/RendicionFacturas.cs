using PagoAgilFrba.DataProvider;
using PagoAgilFrba.Menu_Principal;
using PagoAgilFrba.Utils;
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
        DBMapper mapper = new DBMapper();

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
            DateTime fechaInicio;
            DateTime.TryParse(fechaInicioDateTimePicker.Text, out fechaInicio);
            DateTime fechaFin;
            DateTime.TryParse(fechaFinDateTimePicker.Text, out fechaFin);

            if (!HayMesesEnterosDeDiferencia(fechaInicio, fechaFin))
            {
                Util.ShowMessage("La fechas ingresadas son incorrectas, no hay meses enteros de diferencia.", MessageBoxIcon.Exclamation);
                return;
            }
        }

        private void RendicionFacturas_Load(object sender, EventArgs e)
        {

        }

        public Boolean HayMesesEnterosDeDiferencia(DateTime lValue, DateTime rValue)
        {
            return Math.Abs((lValue.Month - rValue.Month) + 12 * (lValue.Year - rValue.Year)) > 0 && (lValue.Day.Equals(rValue.Day));
        }
    }
}
