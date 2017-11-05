using PagoAgilFrba.DataProvider;
using PagoAgilFrba.Menu_Principal;
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
            importeTextBox.Clear();
            sucursalTextBox.Clear();
            empresaComboBox.SelectedIndex = -1;
            clienteComboBox.SelectedIndex = -1;
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

        private void registrarFacturaButton_Click(object sender, EventArgs e)
        {
            //Region validaciones
            #region
            if (!Util.CamposEstanLlenos(campos))
            {
                Util.ShowMessage("Todos los campos son obligatorios.", MessageBoxIcon.Exclamation);
                return;
            }

            if (empresaComboBox.SelectedIndex.Equals(-1) || clienteComboBox.SelectedIndex.Equals(-1))
            {
                Util.ShowMessage("Debe completar los campos empresa y cliente antes de continuar.", MessageBoxIcon.Exclamation);
                return;
            }

            if (Util.getNumeroFromString(importeTextBox.Text) <= 0)
            {
                Util.ShowMessage("El importe de la factura no puede ser menor o igual a cero.", MessageBoxIcon.Exclamation);
                return;
            }

            if (!mapper.empresaEstaActiva((int)empresaComboBox.SelectedValue))
            {
                Util.ShowMessage("No se pueden registrar pagos a empresas que no estén activas.", MessageBoxIcon.Exclamation);
                return;
            }

            DateTime fechaVenc;
            DateTime.TryParse(fechaVencFactDateTimePicker.Text, out fechaVenc);

            if (!Util.EsFechaVencimientoValida(fechaVenc, DateConfig.getInstance().getCurrentDate()))
            {
                Util.ShowMessage("La fecha de vencimiento de la factura debe ser menor o igual a la fecha del sistema.", MessageBoxIcon.Exclamation);
                return;
            }
            #endregion
            //Validaciones terminadas

            String nroFactura = numFacturaTextBox.Text;
            int idEmpresa = (int)empresaComboBox.SelectedValue;
            int idCliente = (int)clienteComboBox.SelectedValue;
            if (mapper.ExisteFacturaParaEmpresaYCliente(nroFactura, idEmpresa, idCliente))
                agregarFacturaAListado();
            else
                Util.ShowMessage("No existe el número de factura " + nroFactura + " para la empresa " + mapper.getNombreEmpresa(idEmpresa) + " y el cliente " + mapper.getMailCliente(idCliente), MessageBoxIcon.Error);
        }

        private void RegistroPagoFacturas_Load(object sender, EventArgs e)
        {
            campos.Add(numFacturaTextBox);
            campos.Add(importeTextBox);
            campos.Add(sucursalTextBox);

            mediosPago.Add(tarjetaCreditoRadioButton);
            mediosPago.Add(efectivoRadioButton);
            mediosPago.Add(chequeRadioButton);
            mediosPago.Add(tarjetaDebitoRadioButton);

            CargarEmpresas();
            CargarClientes();

            fechaCobroDateTimePicker.Text = DateConfig.getInstance().getCurrentDate().ToString();
        }

        private void agregarFacturaAListado()
        {
            facturasDataGridView.Rows.Add();
            int indexLastRow = facturasDataGridView.Rows.Count - 1;
            facturasDataGridView.Rows[indexLastRow].Cells["NumeroDeFactura"].Value = numFacturaTextBox.Text;
            facturasDataGridView.Rows[indexLastRow].Cells["Empresa"].Value = empresaComboBox.Text;
            facturasDataGridView.Rows[indexLastRow].Cells["Sucursal"].Value = sucursalTextBox.Text;
            facturasDataGridView.Rows[indexLastRow].Cells["Importe"].Value = importeTextBox.Text;
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

        private void limpiarTodoButton_Click(object sender, EventArgs e)
        {
            limpiarButton_Click(this, null);
            button1_Click(this, null);

            mediosPago.ForEach(unMedioPago => unMedioPago.Checked = false);
        }

        private void pagarFacturasButton_Click(object sender, EventArgs e)
        {
            if (mediosPago.All(medioPago => medioPago.Checked == false))
            {
                Util.ShowMessage("Debe seleccionar un método de pago.", MessageBoxIcon.Exclamation);
                return;
            }
        }
    }
}
