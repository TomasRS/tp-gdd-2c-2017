using PagoAgilFrba.DataProvider;
using PagoAgilFrba.Menu_Principal;
using PagoAgilFrba.Modelo;
using PagoAgilFrba.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.Devolucion
{
    public partial class DevolucionFactura : Form
    {
        DBMapper mapper = new DBMapper();
        String nroFactura;

        public DevolucionFactura()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void volverButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MenuPrincipal().ShowDialog();
            this.Close();
        }

        private void limpiarButton_Click(object sender, EventArgs e)
        {
            numFacturaTextBox.Text = "";
            empresaComboBox.SelectedIndex = -1;
            facturaDataGridView.DataSource = null;
            errorDeCobroRadioButton.Checked = false;
            retrotraerPagoRadioButton.Checked = false;
        }

        public void DevolucionFactura_Load(object sender, EventArgs e)
        {
            CargarEmpresas();
        }

        private void CargarEmpresas()
        {
            string query = "SELECT id_empresa, nombre from GAME_OF_CODE.Empresa";

            SqlCommand cmd = new SqlCommand(query, ConnectionManager.Instance.getConnection());

            SqlDataAdapter data_adapter = new SqlDataAdapter(cmd);
            DataTable empresas = new DataTable();
            data_adapter.Fill(empresas);

            empresaComboBox.ValueMember = "id_empresa";
            empresaComboBox.DisplayMember = "nombre";
            empresaComboBox.DataSource = empresas;
            empresaComboBox.SelectedIndex = -1;
        }

        private void DeshabilitarSortHeaders()
        {
            foreach (DataGridViewColumn column in facturaDataGridView.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        private void OcultarColumnasQueNoDebenVerse()
        {
            facturaDataGridView.Columns["id_factura"].Visible = false;
            facturaDataGridView.Columns["id_pago"].Visible = false;
        }

        private void buscarFacturaButton_Click(object sender, EventArgs e)
        {
            nroFactura = numFacturaTextBox.Text;
            int idEmpresa = (int)empresaComboBox.SelectedValue;
            int idCliente = mapper.getIDClienteEnBaseA(nroFactura, idEmpresa);

            if (nroFactura.Equals("") || empresaComboBox.SelectedIndex.Equals(-1))
            {
                Util.ShowMessage("Todos los campos son obligatorios.", MessageBoxIcon.Exclamation);
                return;
            }

            if (!Util.EsNumero(nroFactura))
            {
                Util.ShowMessage("El número de factura debe ser numérico y sin espacios.", MessageBoxIcon.Exclamation);
                return;
            }

            if (!mapper.ExisteFacturaParaEmpresaYCliente(nroFactura, idEmpresa, idCliente))
            {
                Util.ShowMessage("No existe la factura con número " + nroFactura + " para la empresa " + empresaComboBox.Text + ".", MessageBoxIcon.Exclamation);
                return;
            }

            if (!mapper.SeEncuentraPagaFactura(nroFactura, idEmpresa))
            {
                Util.ShowMessage("La factura ingresada no se encuentra paga.", MessageBoxIcon.Exclamation);
                return;
            }

            if (!mapper.FacturaEstaActiva(nroFactura, idEmpresa))
            {
                Util.ShowMessage("La factura se encuentra deshabilitada.", MessageBoxIcon.Exclamation);
                return;
            }

            if (mapper.FacturaEstaRendida(mapper.getIDFacturaParaEmpresa(nroFactura, idEmpresa)))
            {
                Util.ShowMessage("No se puede devolver la factura porque se encuentra rendida.", MessageBoxIcon.Exclamation);
                return;
            }

            DataTable factura = mapper.getFactura(nroFactura, idEmpresa, idCliente);
            facturaDataGridView.DataSource = factura;

            DeshabilitarSortHeaders();
            OcultarColumnasQueNoDebenVerse();
        }

        private void devolverFacturaButton_Click(object sender, EventArgs e)
        {
            if (facturaDataGridView.Rows.Count.Equals(0))
            {
                Util.ShowMessage("Primero debe buscar una factura.", MessageBoxIcon.Exclamation);
                return;
            }
            if (errorDeCobroRadioButton.Checked.Equals(false) && retrotraerPagoRadioButton.Checked.Equals(false))
            {
                Util.ShowMessage("Debe escoger un motivo para la devolución", MessageBoxIcon.Exclamation);
                return;
            }
            
            PagoAgilFrba.Modelo.Devolucion devolucion = new PagoAgilFrba.Modelo.Devolucion();
            if (errorDeCobroRadioButton.Checked)
                devolucion.setMotivo("Error de cobro");
            else if (retrotraerPagoRadioButton.Checked)
                devolucion.setMotivo("Cliente decidió retrotraer el pago");

            devolucion.setIDFactura((int)facturaDataGridView.Rows[0].Cells["id_factura"].Value);
            devolucion.setIDPagoFactura((int)facturaDataGridView.Rows[0].Cells["id_pago"].Value);

            int idDevolucion = mapper.CrearDevolucion(devolucion);
            if (idDevolucion > 0)
            {
                mapper.BorrarIDPagoDeLaFactura(devolucion.getIDFactura());
                Util.ShowMessage("Se ha devuelto la factura correctamente.", MessageBoxIcon.Information);
                limpiarButton_Click(this, null);
            }
        }
    }
}
