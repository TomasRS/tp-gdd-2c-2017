using PagoAgilFrba.DataProvider;
using PagoAgilFrba.Excepciones;
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
        private String query;
        private IList<SqlParameter> parametros = new List<SqlParameter>();
        private SqlParameter parametroOutput;
        private SqlCommand command;


        public RendicionFacturas()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void limpiarButton_Click(object sender, EventArgs e)
        {
            empresaComboBox.SelectedIndex = -1;
            fechaInicioDateTimePicker.Value = DateConfig.getInstance().getCurrentDate();
            fechaFinDateTimePicker.Value = DateConfig.getInstance().getCurrentDate();
            facturasDataGridView.DataSource = null;
            porcentajeComisionTextBox.Text = "";
            importeComisionTextBox.Text = "";
            importeTotalRendicionTextBox.Text = "";
        }

        private void volverButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MenuPrincipal().ShowDialog();
            this.Close();
        }

        private void rendirFacturasButton_Click(object sender, EventArgs e)
        {
            if (facturasDataGridView.Rows.Count.Equals(0))
            {
                Util.ShowMessage("Primero debe buscar las facturas para una empresa y período.", MessageBoxIcon.Exclamation);
                return;
            }

            int idRendicion = crearRendicion();
            if (idRendicion > 0)
            {
                try
                {
                    crearDetallesRendicion(idRendicion);
                    Util.ShowMessage("Se ha realizado la rendición correctamente.", MessageBoxIcon.Information);
                    limpiarButton_Click(this, null);
                }
                catch (NoSePudoCrearDetalleRendicionException)
                {
                    Util.ShowMessage("Hubo un error al crear los detalles de rendición, vuelva a intentarlo.", MessageBoxIcon.Error);
                }
            }
            else
                Util.ShowMessage("No se pudo crear la rendición.", MessageBoxIcon.Error);
        }

        private int crearRendicion()
        {
            PagoAgilFrba.Modelo.Rendicion rendicion = new PagoAgilFrba.Modelo.Rendicion();
            rendicion.setFechaRendicion(DateConfig.getInstance().getCurrentDate());
            rendicion.setPorcentajeComision(Util.getNumeroFromString(porcentajeComisionTextBox.Text));
            rendicion.setImporteComision(Util.getNumeroFloatFromString(importeComisionTextBox.Text));
            rendicion.setTotalRendicion(Util.getNumeroFromString(importeTotalRendicionTextBox.Text));
            rendicion.setCantFacturasRendidas(facturasDataGridView.Rows.Count);

            return mapper.CrearRendicion(rendicion);
        }

        private void crearDetallesRendicion(int idRendicion)
        {
            DataTable DTforDB = new DataTable();
            DTforDB.Columns.Add("id_detalle_rendicion");
            DTforDB.Columns.Add("id_rendicion");
            DTforDB.Columns.Add("id_factura");
            foreach (DataGridViewRow row in facturasDataGridView.Rows)
            {
                DataRow dRow = DTforDB.NewRow();
                dRow["id_rendicion"] = idRendicion;
                dRow["id_factura"] = row.Cells[0].Value;

                DTforDB.Rows.Add(dRow);
            }

            using (SqlConnection connection = new SqlConnection(mapper.getConnectionString())){
                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(mapper.getConnectionString())){
                    connection.Open();
                    bulkCopy.DestinationTableName = "GAME_OF_CODE.Detalle_Rendicion";
                    try
                    {
                        bulkCopy.WriteToServer(DTforDB);
                    }
                    catch (Exception)
                    {
                        Util.ShowMessage("No se pudieron crear los detalles de rendición.", MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void buscarFacturaButton_Click(object sender, EventArgs e)
        {
            facturasDataGridView.DataSource = null;

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
                Util.ShowMessage("El período de fechas debe tener al menos un mes entero de diferencia.", MessageBoxIcon.Exclamation);
                return;
            }

            DataTable facturasParaRendir = mapper.SelectFacturasParaRendir(fechaInicio, fechaFin, idEmpresa);
            if (facturasParaRendir.Rows.Count.Equals(0))
            {
                Util.ShowMessage("No hay facturas pendientes de rendición para el período y empresa seleccionados.", MessageBoxIcon.Information);
                return;
            }

            facturasDataGridView.DataSource = facturasParaRendir;
            DeshabilitarSortHeaders();
            OcultarColumnasQueNoDebenVerse();

            popularImporteComisionEImporteTotalRendicion();
        }

        private void popularImporteComisionEImporteTotalRendicion()
        {
            int importeTotalRendicion = getImporteTotalDeLaRendicion();
            importeTotalRendicionTextBox.Text = importeTotalRendicion.ToString();

            int porcentajeComision = Util.getNumeroFromString(porcentajeComisionTextBox.Text);
            float importeComision = importeTotalRendicion * ((float)porcentajeComision / 100);
            importeComisionTextBox.Text = importeComision.ToString();
        }

        private int getImporteTotalDeLaRendicion()
        {
            int importeTotalRendicion = 0;
            foreach (DataGridViewRow factura in facturasDataGridView.Rows)
            {
                importeTotalRendicion += (int)factura.Cells[2].Value;
            }
            return importeTotalRendicion;
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
            int diaSeleccionadoDelMesInicio = lValue.Day;

            if (diaSeleccionadoDelMesInicio >= 1 && diaSeleccionadoDelMesInicio <= 28)
                return Math.Abs((lValue.Month - rValue.Month) + 12 * (lValue.Year - rValue.Year)) > 0 && ((lValue.Day.Equals(rValue.Day)) || (DateTime.DaysInMonth(lValue.Year, lValue.Month).Equals(lValue.Day) && DateTime.DaysInMonth(rValue.Year, rValue.Month).Equals(rValue.Day)));
            else
            {
                //El dia en fechaInicio es 29,30,31
                //Si los dias en ambas fechas son iguales
                if (lValue.Day.Equals(rValue.Day))
                {
                    return Math.Abs((lValue.Month - rValue.Month) + 12 * (lValue.Year - rValue.Year)) > 0;
                }
                else
                {
                    //El dia de inicio es menor al de fin
                    if (lValue.Day < rValue.Day)
                        return false;
                    else
                    {
                        //Pregunto si el dia inicio es el ultimo dia del mes
                        if (DateTime.DaysInMonth(lValue.Year, lValue.Month).Equals(lValue.Day))
                        {
                            //Si el dia de fin tambien es ultimo dia del mes
                            if (DateTime.DaysInMonth(rValue.Year, rValue.Month).Equals(rValue.Day))
                                return true;
                            else
                                return false;
                        }
                        else
                            return false;
                    }
                }
            }

            //return Math.Abs((lValue.Month - rValue.Month) + 12 * (lValue.Year - rValue.Year)) > 0 && (lValue.Day.Equals(rValue.Day));
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
