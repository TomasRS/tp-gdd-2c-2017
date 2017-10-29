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

            rubroComboBox.ValueMember = "id_rubro";
            rubroComboBox.DisplayMember = "descripcion";
            rubroComboBox.DataSource = rubros;
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

            //clientesDataGridView.Columns.Add("Modificar", "Modificación");
            //agregarBotonesModificar();
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

        private void clientesDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
                    //Chequear que no tenga facturas pendientes de rendicion
                    Boolean resultado = mapper.CambiarHabilitacionEmpresa(Convert.ToInt32(idEmpresaAModificar), "Empresa", 0);
                    Util.ShowMessage("Se eliminó la empresa correctamente.", MessageBoxIcon.Information);
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
            //if (rubroComboBox.Text != "") filtro += "AND cli.rubro" + " LIKE '" + rubroComboBox.Text + "%'";
            return filtro;
        }
    }
}
