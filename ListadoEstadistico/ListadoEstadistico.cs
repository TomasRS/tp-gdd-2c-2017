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

namespace PagoAgilFrba.ListadoEstadistico
{
    public partial class ListadoEstadistico : Form
    {
        private DBMapper mapper = new DBMapper();

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

        //Metodo buscar
        private void buscarButton_Click(object sender, EventArgs e)
        {
            estadisticasDataGridView.DataSource = null;

            #region validaciones
            if (!Util.EsNumero(anioTextBox.Text))
            {
                Util.ShowMessage("El formato del año debe ser numérico.", MessageBoxIcon.Exclamation);
                return;
            }

            if (!Util.EsAnioValidoEnBaseAFechaSistema(anioTextBox.Text))
            {
                Util.ShowMessage("El año no puede ser un año futuro.", MessageBoxIcon.Exclamation);
                return;
            }

            if (trimestreComboBox.SelectedIndex.Equals(-1))
            {
                Util.ShowMessage("Debe seleccionar un trimestre.", MessageBoxIcon.Exclamation);
                return;
            }

            if (tipoListadoComboBox.SelectedIndex.Equals(-1))
            {
                Util.ShowMessage("Debe seleccionar un tipo de listado.", MessageBoxIcon.Exclamation);
                return;
            }
            #endregion

            String anio = anioTextBox.Text;
            String trimestre = (trimestreComboBox.SelectedIndex + 1).ToString();
            String tipoDeListado = tipoListadoComboBox.Text;

            String fechaInicio = getFechaInicio(anio, trimestre);
            String fechaFin = getFechaFin(anio, trimestre);

            switch (tipoListadoComboBox.SelectedIndex)
            {
                case 0: mostrarPorcentajeFacturasCobradasPorEmpresa(fechaInicio, fechaFin);
                        break;
                case 1: mostrarEmpresasConMayorMontoRendido(fechaInicio, fechaFin);
                        break;
                case 2: mostrarClientesConMasPagos(fechaInicio, fechaFin);
                        break;
                case 3: mostrarClientesConMayorPorcentajeDeFacturasPagas(fechaInicio, fechaFin);
                        break;
                default: break;
            }

            DeshabilitarSortHeaders();
        }

        private void mostrarPorcentajeFacturasCobradasPorEmpresa(String fechaInicio, String fechaFin)
        {
            DataTable DT = mapper.SelectPorcentajeFacturasCobradasPorEmpresa(fechaInicio, fechaFin);
            estadisticasDataGridView.DataSource = DT;
        }

        private void mostrarEmpresasConMayorMontoRendido(String fechaInicio, String fechaFin)
        {
            DataTable DT = mapper.SelectEmpresasConMayorMontoRendido(fechaInicio, fechaFin);
            estadisticasDataGridView.DataSource = DT;
        }

        private void mostrarClientesConMasPagos(String fechaInicio, String fechaFin)
        {
            DataTable DT = mapper.SelectClientesConMasPagos(fechaInicio, fechaFin);
            estadisticasDataGridView.DataSource = DT;
        }

        private void mostrarClientesConMayorPorcentajeDeFacturasPagas(String fechaInicio, String fechaFin)
        {
            DataTable DT = mapper.SelectClientesConMayorPorcentajeDeFacturasPagadas(fechaInicio, fechaFin);
            estadisticasDataGridView.DataSource = DT;
        }


        //Obtencion de fechas
        //Fecha inicio
        private String getFechaInicio(String anio, String trimestre)
        {
            return "'" + anio + "-" + getMesInicioTrimestre(trimestre) + "-01'";
        }
        private String getMesInicioTrimestre(String trimestre)
        {
            switch (trimestre)
            {
                case "1": return "01";
                case "2": return "04";
                case "3": return "07";
                case "4": return "10";
                default: return null;
            }
        }

        //Fecha fin
        private String getFechaFin(String anio, String trimestre)
        {
            return "'" + anio + "-" + getMesFinTrimestre(trimestre) + "-" + getDiaFinUltimoMesTrimestre(trimestre) + "'";
        }

        private String getMesFinTrimestre(String trimestre)
        {
            switch (trimestre)
            {
                case "1": return "03";
                case "2": return "06";
                case "3": return "09";
                case "4": return "12";
                default: return null;
            }
        }
        private String getDiaFinUltimoMesTrimestre(String trimestre)
        {
            switch (trimestre)
            {
                case "1": return "31";
                case "2": return "30";
                case "3": return "30";
                case "4": return "31";
                default: return null;
            }
        }

        private void DeshabilitarSortHeaders()
        {
            foreach (DataGridViewColumn column in estadisticasDataGridView.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
    }
}
