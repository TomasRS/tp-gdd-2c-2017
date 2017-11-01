using PagoAgilFrba.DataProvider;
using PagoAgilFrba.Menu_Principal;
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

namespace PagoAgilFrba.ListadoEstadistico
{
    public partial class ListadoEstadistico : Form
    {
        private DBMapper mapper = new DBMapper();
        private IList<SqlParameter> parametros = new List<SqlParameter>();
        private SqlCommand command;


        public ListadoEstadistico()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void limpiarButton_Click(object sender, EventArgs e)
        {
            anioTextBox.Clear();
            trimestreComboBox.SelectedIndex = -1;
            tipoListadoComboBox.SelectedIndex = -1;
            estadisticasDataGridView.DataSource = null;
        }

        private void volverButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MenuPrincipal().ShowDialog();
            this.Close();
        }

        private void ListadoEstadistico_Load(object sender, EventArgs e)
        {
            CargarTrimestres();
            CargarTiposDeListados();
        }

        private void CargarTrimestres()
        {
            DataTable trimestres = new DataTable();
            trimestres.Columns.Add("trimestres");
            trimestres.Rows.Add("1º trimestre (Enero - Marzo)");
            trimestres.Rows.Add("2º trimestre (Abril - Junio)");
            trimestres.Rows.Add("3º trimestre (Julio - Septiembre)");
            trimestres.Rows.Add("4º trimestre (Octubre - Diciembre)");
            trimestreComboBox.DataSource = trimestres;
            trimestreComboBox.ValueMember = "trimestres";
            trimestreComboBox.SelectedIndex = -1;
        }

        private void CargarTiposDeListados()
        {
            DataTable tiposDeListados = new DataTable();
            tiposDeListados.Columns.Add("tiposDeListados");
            tiposDeListados.Rows.Add("Porcentaje de facturas cobradas por empresa");
            tiposDeListados.Rows.Add("Empresas con mayor monto rendido");
            tiposDeListados.Rows.Add("Clientes con más pagos");
            tiposDeListados.Rows.Add("Clientes con mayor porcentaje de facturas pagadas");

            tipoListadoComboBox.DataSource = tiposDeListados;
            tipoListadoComboBox.ValueMember = "tiposDeListados";
            tipoListadoComboBox.SelectedIndex = -1;
        }
    }
}
