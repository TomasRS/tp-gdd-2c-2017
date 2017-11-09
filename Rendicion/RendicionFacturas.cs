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
            int idEmpresa = (int)empresaComboBox.SelectedValue;

            if (!Util.FechaPrimeraMayorAFechaSegunda(fechaFin, fechaInicio))
            {
                Util.ShowMessage("La fecha de fin tiene que ser mayor a la fecha de inicio.", MessageBoxIcon.Exclamation);
                return;
            }

            if (!HayMesesEnterosDeDiferencia(fechaInicio, fechaFin))
            {
                Util.ShowMessage("La fechas ingresadas son incorrectas, no hay meses enteros de diferencia.", MessageBoxIcon.Exclamation);
                return;
            }

            DataTable facturasParaRendir = mapper.SelectFacturasParaRendir(fechaInicio, fechaFin, idEmpresa);
            facturasDataGridView.DataSource = facturasParaRendir;
            DeshabilitarSortHeaders();
            OcultarColumnasQueNoDebenVerse();
        }

        private void DeshabilitarSortHeaders()
        {
            foreach (DataGridViewColumn column in facturasDataGridView.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        private void OcultarColumnasQueNoDebenVerse()
        {
            facturasDataGridView.Columns["id_factura"].Visible = false;
        }

        private void RendicionFacturas_Load(object sender, EventArgs e)
        {
            CargarEmpresas();
            empresaComboBox.SelectedIndex = 0;
        }

        private void empresaComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((int)empresaComboBox.SelectedIndex >= 0)
            {
                porcentajeComisionTextBox.Text = mapper.ObtenerEmpresa((int)empresaComboBox.SelectedValue).getPorcentajeComision().ToString();
            }
        }

        public Boolean HayMesesEnterosDeDiferencia(DateTime lValue, DateTime rValue)
        {
            //Falta calcular que coincidan los dias para meses distintos..
            return Math.Abs((lValue.Month - rValue.Month) + 12 * (lValue.Year - rValue.Year)) > 0 && (lValue.Day.Equals(rValue.Day));
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
    }
}
