using PagoAgilFrba.Menu_Principal;
using PagoAgilFrba.DataProvider;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PagoAgilFrba.Utils;
using PagoAgilFrba.Modelo;
using System.Data.SqlClient;

namespace PagoAgilFrba.AbmEmpresa
{
    public partial class ListadoEmpresa : Form
    {
        private DBMapper mapper = new DBMapper();

        //-------------------------------------------------------------------
        public ListadoEmpresa()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void DeshabilitarSortHeaders()
        {
            foreach (DataGridViewColumn column in empresasDataGridView.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void limpiarButton_Click(object sender, EventArgs e)
        {
            nombreTextBox.Clear();
            cuitTextBox.Clear();
            rubroComboBox.SelectedIndex = 0;
            CargarEmpresas();
        }

        private void volverButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MenuPrincipal().ShowDialog();
            this.Close();
        }

        private void ListadoEmpresa_Load(object sender, EventArgs e)
        {
            CargarRubros();
            CargarEmpresas();
        }

        private void CargarRubros()
        {
            string query = "SELECT id_rubro, descripcion from GAME_OF_CODE.Rubro";

            SqlCommand cmd = new SqlCommand(query, ConnectionManager.Instance.getConnection());

            SqlDataAdapter data_adapter = new SqlDataAdapter(cmd);
            DataTable rubros = new DataTable();
            data_adapter.Fill(rubros);

            rubros.Columns.Add("Ninguno");

            rubroComboBox.ValueMember = "id_rubro";
            rubroComboBox.DisplayMember = "descripcion";
            rubroComboBox.DataSource = rubros;

            DataRow dr = rubros.NewRow();
            dr["descripcion"] = "Ninguno";

            rubros.Rows.InsertAt(dr, 0);

            rubroComboBox.SelectedIndex = 0;
        }

        private void CargarEmpresas()
        {
            empresasDataGridView.DataSource = mapper.SelectEmpresasParaFiltro();
            CargarColumnaModificacion();
            CargarColumnaEliminar();
            DeshabilitarSortHeaders();
            OcultarColumnasQueNoDebenVerse();
        }

        private void CargarColumnaModificacion()
        {
            if (empresasDataGridView.Columns.Contains("Modificar"))
                empresasDataGridView.Columns.Remove("Modificar");

            DataGridViewButtonColumn botonColumnaModificar = new DataGridViewButtonColumn();
            botonColumnaModificar.Text = "Modificar";
            botonColumnaModificar.Name = "Modificar";
            botonColumnaModificar.UseColumnTextForButtonValue = true;
            empresasDataGridView.Columns.Add(botonColumnaModificar);
        }

        private void CargarColumnaEliminar()
        {
            if (empresasDataGridView.Columns.Contains("Eliminar"))
                empresasDataGridView.Columns.Remove("Eliminar");

            empresasDataGridView.Columns.Add("Eliminar", "Eliminar/Habilitar");
            agregarBotonesEliminar();
        }

        private void agregarBotonesEliminar()
        {
            foreach (DataGridViewRow row in empresasDataGridView.Rows)
            {
                DataGridViewButtonCell boton = new DataGridViewButtonCell();
                Boolean valorHabilitacion = (Boolean)row.Cells["Habilitado"].Value;
                if (valorHabilitacion)
                    boton.Value = "Eliminar";
                else
                    boton.Value = "Habilitar";

                row.Cells["Eliminar"] = boton;
            }
        }

        private void OcultarColumnasQueNoDebenVerse()
        {
            empresasDataGridView.Columns["id_empresa"].Visible = false;
        }

        private void empresasDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Controla que la celda que se clickeo fue la de modificar
            if (e.ColumnIndex == empresasDataGridView.Columns["Modificar"].Index && e.RowIndex >= 0)
            {
                String idEmpresaAModificar = empresasDataGridView.Rows[e.RowIndex].Cells["id_empresa"].Value.ToString();
                new AltaModifEmpresa(new Modificacion()).ShowDialog(idEmpresaAModificar);
                CargarEmpresas();
                return;
            }
            if (e.ColumnIndex == empresasDataGridView.Columns["Eliminar"].Index && e.RowIndex >= 0)
            {
                String idEmpresaAModificar = empresasDataGridView.Rows[e.RowIndex].Cells["id_empresa"].Value.ToString();
                Boolean valorHabilitacion = (Boolean)empresasDataGridView.Rows[e.RowIndex].Cells["Habilitado"].Value;
                if (valorHabilitacion)
                {
                    if (mapper.EmpresaTieneTodasSusFacturasRendidas(Util.getNumeroFromString(idEmpresaAModificar)))
                    {
                        Boolean resultado = mapper.CambiarHabilitacionEmpresa(Convert.ToInt32(idEmpresaAModificar), "Empresa", 0);
                        Util.ShowMessage("Se eliminó la empresa correctamente.", MessageBoxIcon.Information);
                    }
                    else
                    {
                        Util.ShowMessage("No se puede eliminar la empresa porque tiene facturas pendientes de rendición.", MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    Boolean resultado = mapper.CambiarHabilitacionEmpresa(Convert.ToInt32(idEmpresaAModificar), "Empresa", 1);
                    Util.ShowMessage("Se habilitó la empresa correctamente.", MessageBoxIcon.Information);
                }

                CargarEmpresas();
                return;
            }
        }

        private void buscarButton_Click(object sender, EventArgs e)
        {
            String filtro = CalcularFiltro();
            empresasDataGridView.DataSource = mapper.SelectEmpresasParaFiltroConFiltro(filtro);
            CargarColumnaModificacion();
            CargarColumnaEliminar();
        }

        private String CalcularFiltro()
        {
            String filtro = "";
            if (nombreTextBox.Text != "") filtro += "AND " + "emp.nombre LIKE '" + nombreTextBox.Text + "%'";
            if (cuitTextBox.Text != "") filtro += "AND " + "emp.emp_cuit LIKE '" + cuitTextBox.Text + "%'";

            if (rubroComboBox.Text != "Ninguno")
                filtro += "AND emp.id_rubro = " + rubroComboBox.SelectedValue.ToString();

            return filtro;
        }
    }
}
