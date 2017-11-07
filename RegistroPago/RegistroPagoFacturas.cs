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

namespace PagoAgilFrba.RegistroPago
{
    public partial class RegistroPagoFacturas : Form
    {
        private List<TextBox> campos = new List<TextBox>();
        private DBMapper mapper = new DBMapper();
        private List<RadioButton> mediosPago = new List<RadioButton>();

        public RegistroPagoFacturas()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void limpiarButton_Click(object sender, EventArgs e)
        {
            numFacturaTextBox.Clear();
            sucursalComboBox.SelectedIndex = -1;
            empresaComboBox.SelectedIndex = -1;
            clienteComboBox.SelectedIndex = -1;
            fechaCobroDateTimePicker.Text = "";
            fechaVencFactDateTimePicker.Text = "";
        }

        private void volverButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MenuPrincipal().ShowDialog();
            this.Close();
        }

        private void registrarFacturaButton_Click(object sender, EventArgs e)
        {
            //Region validaciones
            #region
            if (!Util.CamposEstanLlenos(campos))
            {
                Util.ShowMessage("Todos los campos son obligatorios.", MessageBoxIcon.Exclamation);
                return;
            }

            if (empresaComboBox.SelectedIndex.Equals(-1) || clienteComboBox.SelectedIndex.Equals(-1) || sucursalComboBox.SelectedIndex.Equals(-1))
            {
                Util.ShowMessage("Debe completar los campos empresa, cliente y sucursal antes de continuar.", MessageBoxIcon.Exclamation);
                return;
            }

            if (!mapper.empresaEstaActiva((int)empresaComboBox.SelectedValue))
            {
                Util.ShowMessage("No se pueden registrar pagos a empresas que no estén activas.", MessageBoxIcon.Exclamation);
                return;
            }
            if (!Util.EsNumero(numFacturaTextBox.Text))
            {
                Util.ShowMessage("El número de factura debe tener formato numérico y sin espacios.", MessageBoxIcon.Exclamation);
                return;
            }

            if (mapper.SeEncuentraPagaFactura(numFacturaTextBox.Text, (int)empresaComboBox.SelectedValue))
            {
                Util.ShowMessage("La factura que quiere registrar ya se encuentra paga.", MessageBoxIcon.Exclamation);
                return;
            }

            DateTime fechaVenc;
            DateTime.TryParse(fechaVencFactDateTimePicker.Text, out fechaVenc);

            if (!Util.FechaPrimeraMayorOIgualAFechaSegunda(fechaVenc, DateConfig.getInstance().getCurrentDate()))
            {
                Util.ShowMessage("La fecha de vencimiento de la factura debe ser mayor o igual a la fecha del sistema.", MessageBoxIcon.Exclamation);
                return;
            }
            #endregion
            //Validaciones terminadas

            String nroFactura = numFacturaTextBox.Text;
            int idEmpresa = (int)empresaComboBox.SelectedValue;
            int idCliente = (int)clienteComboBox.SelectedValue;
            if (mapper.ExisteFacturaParaEmpresaYCliente(nroFactura, idEmpresa, idCliente))
                if (mapper.FacturaEstaActiva(nroFactura, idEmpresa))
                    agregarFacturaAListado();
                else
                    Util.ShowMessage("La factura que quiere registrar no se encuentra activa por lo que no se la puede pagar.", MessageBoxIcon.Exclamation);
            else
                Util.ShowMessage("No existe el número de factura " + nroFactura + " para la empresa " + mapper.getNombreEmpresa(idEmpresa) + " y el cliente " + mapper.getMailCliente(idCliente), MessageBoxIcon.Error);
        }

        private void RegistroPagoFacturas_Load(object sender, EventArgs e)
        {
            campos.Add(numFacturaTextBox);

            mediosPago.Add(tarjetaCreditoRadioButton);
            mediosPago.Add(efectivoRadioButton);
            mediosPago.Add(chequeRadioButton);
            mediosPago.Add(tarjetaDebitoRadioButton);

            CargarEmpresas();
            CargarClientes();
            CargarSucursales();
            DeshabilitarSortHeaders();

            fechaCobroDateTimePicker.Text = DateConfig.getInstance().getCurrentDate().ToString();
        }

        private void agregarFacturaAListado()
        {
            facturasDataGridView.Rows.Add();
            int indexLastRow = facturasDataGridView.Rows.Count - 1;
            facturasDataGridView.Rows[indexLastRow].Cells["NumeroDeFactura"].Value = numFacturaTextBox.Text;
            facturasDataGridView.Rows[indexLastRow].Cells["id_empresa"].Value = empresaComboBox.SelectedValue;
            facturasDataGridView.Rows[indexLastRow].Cells["Empresa"].Value = empresaComboBox.Text;
            facturasDataGridView.Rows[indexLastRow].Cells["Sucursal"].Value = sucursalComboBox.Text;
            facturasDataGridView.Rows[indexLastRow].Cells["Importe"].Value = mapper.getImporteFactura(numFacturaTextBox.Text, (int)empresaComboBox.SelectedValue);
        }

        private void DeshabilitarSortHeaders()
        {
            foreach (DataGridViewColumn column in facturasDataGridView.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
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
            empresaComboBox.SelectedIndex = 0;
        }
        private void CargarClientes()
        {
            string query = "SELECT id_cliente, mail from GAME_OF_CODE.Cliente";

            SqlCommand cmd = new SqlCommand(query, ConnectionManager.Instance.getConnection());

            SqlDataAdapter data_adapter = new SqlDataAdapter(cmd);
            DataTable clientes = new DataTable();
            data_adapter.Fill(clientes);

            clienteComboBox.ValueMember = "id_cliente";
            clienteComboBox.DisplayMember = "mail";
            clienteComboBox.DataSource = clientes;
            clienteComboBox.SelectedIndex = 0;
        }
        private void CargarSucursales()
        {
            string query = "SELECT id_sucursal, nombre from GAME_OF_CODE.Sucursal";

            SqlCommand cmd = new SqlCommand(query, ConnectionManager.Instance.getConnection());

            SqlDataAdapter data_adapter = new SqlDataAdapter(cmd);
            DataTable clientes = new DataTable();
            data_adapter.Fill(clientes);

            sucursalComboBox.ValueMember = "id_sucursal";
            sucursalComboBox.DisplayMember = "nombre";
            sucursalComboBox.DataSource = clientes;
            sucursalComboBox.SelectedIndex = 0;
        }

        private void limpiarTodoButton_Click(object sender, EventArgs e)
        {
            limpiarButton_Click(this, null);
            facturasDataGridView.Rows.Clear();
            facturasDataGridView.Refresh();

            mediosPago.ForEach(unMedioPago => unMedioPago.Checked = false);
        }

        private void pagarFacturasButton_Click(object sender, EventArgs e)
        {
            if (mediosPago.All(medioPago => medioPago.Checked == false))
            {
                Util.ShowMessage("Debe seleccionar un método de pago.", MessageBoxIcon.Exclamation);
                return;
            }

            //Creacion pago factura
            PagoFactura pagoFactura = new PagoFactura();
            pagoFactura.setFechaCobro(DateConfig.getInstance().getCurrentDate());
            pagoFactura.setImporte(getImporteTotalAPagar());
            pagoFactura.setIDSucursal((int)sucursalComboBox.SelectedValue);
            pagoFactura.setIDMedioPago(mapper.getIDMedioPago(mediosPago.Find(mPago => mPago.Checked == true).Text));

            foreach (DataGridViewRow row in facturasDataGridView.Rows)
            {
                Factura factura = new Factura();
                factura.setNumeroFactura(row.Cells["NumeroDeFactura"].Value.ToString());
                factura.setIDEmpresa((int)row.Cells["id_empresa"].Value);
                pagoFactura.agregarFactura(factura);
            }

            int idPago = mapper.CrearPagoFactura(pagoFactura);
            mapper.AgregarACadaFacturaElIDDelPago(pagoFactura, idPago);

            Util.ShowMessage("Todas las facturas se han pagado correctamente.", MessageBoxIcon.Information);
            facturasDataGridView.Rows.Clear();
            facturasDataGridView.Refresh();
        }

        private void borrarFacturaSeleccionadaButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in facturasDataGridView.SelectedRows)
            {
                facturasDataGridView.Rows.Remove(row);
            }
        }

        private int getImporteTotalAPagar()
        {
            int importeTotal = 0;
            foreach (DataGridViewRow row in facturasDataGridView.Rows)
            {
                importeTotal += (int)row.Cells["Importe"].Value;
            }
            return importeTotal;
        }
    }
}
