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

        //Metodo buscar
        private void buscarButton_Click(object sender, EventArgs e)
        {
            if (!Util.EsNumero(anioTextBox.Text))
            {
                Util.ShowMessage("El formato del año debe ser numérico.", MessageBoxIcon.Exclamation);
                return;
            }
                
            String anio = anioTextBox.Text;
            String trimestre = trimestreComboBox.Text;
            String tipoDeListado = tipoListadoComboBox.Text;

            String fechaDeInicio = ObtenerFechaDeInicio(anio, trimestre);
            String fechaDeFin = ObtenerFechaDeFin(anio, trimestre);
            String fechaMedia = ObtenerFechaMedia(anio, trimestre);
        }


        //Metodos extras
        private String ObtenerFechaDeInicio(string anio, string trimestre)
        {
            String dia = "01";
            String mes = ObtenerMesInicio(trimestre);
            return dia + "/" + mes + "/" + anio;
        }

        private string ObtenerMesInicio(string trimestre)
        {
            switch (trimestre[0])
            {
                case '1':
                    return "01"; //Enero
                case '2':
                    return "04"; //Abril
                case '3':
                    return "07"; //Julio
                case '4':
                    return "10"; //Octubre
            }
            throw new Exception("No se pudo obtener el mes");
        }

        private String ObtenerFechaDeFin(string anio, string trimestre)
        {
            String dia = "01";
            String mes = ObtenerMesFin(trimestre);
            return dia + "/" + mes + "/" + anio;
        }

        private string ObtenerMesFin(string trimestre)
        {
            switch (trimestre[0])
            {
                case '1':
                    return "03"; //Marzo
                case '2':
                    return "06"; //Junio
                case '3':
                    return "09"; //Septiembre
                case '4':
                    return "12"; //Diciembre
            }
            throw new Exception("No se pudo obtener el mes");
        }

        private String ObtenerFechaMedia(string anio, string trimestre)
        {
            String dia = "01";
            String mes = ObtenerMesMedio(trimestre);
            return dia + "/" + mes + "/" + anio;
        }

        private string ObtenerMesMedio(string trimestre)
        {
            switch (trimestre[0])
            {
                case '1':
                    return "02";
                case '2':
                    return "05";
                case '3':
                    return "08";
                case '4':
                    return "11";
            }
            throw new Exception("No se pudo obtener el mes");
        }
    }
}
