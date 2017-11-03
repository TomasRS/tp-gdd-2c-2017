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

namespace PagoAgilFrba.AbmSucursal
{
    public partial class ListadoSucursal : Form
    {
        private DBMapper mapper = new DBMapper();

        //-------------------------------------------------------------------
        public ListadoSucursal()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void DeshabilitarSortHeaders()
        {
            foreach (DataGridViewColumn column in sucursalesDataGridView.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void limpiarButton_Click(object sender, EventArgs e)
        {
            nombreTextBox.Clear();
            direccionTextBox.Clear();
            codPostalTextBox.Clear();
            CargarSucursales();
        }

        private void volverButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MenuPrincipal().ShowDialog();
            this.Close();
        }

        private void ListadoSucursal_Load(object sender, EventArgs e)
        {
            CargarSucursales();
        }

        private void CargarSucursales()
        {
            sucursalesDataGridView.DataSource = mapper.SelectSucursalesParaFiltro();
            CargarColumnaModificacion();
            CargarColumnaEliminar();
            DeshabilitarSortHeaders();
            OcultarColumnasQueNoDebenVerse();
        }

        private void CargarColumnaModificacion()
        {
            if (sucursalesDataGridView.Columns.Contains("Modificar"))
                sucursalesDataGridView.Columns.Remove("Modificar");

            //sucursalesDataGridView.Columns.Add("Modificar", "Modificación");
            //agregarBotonesModificar();
            DataGridViewButtonColumn botonColumnaModificar = new DataGridViewButtonColumn();
            botonColumnaModificar.Text = "Modificar";
            botonColumnaModificar.Name = "Modificar";
            botonColumnaModificar.UseColumnTextForButtonValue = true;
            sucursalesDataGridView.Columns.Add(botonColumnaModificar);
        }

        private void CargarColumnaEliminar()
        {
            if (sucursalesDataGridView.Columns.Contains("Eliminar"))
                sucursalesDataGridView.Columns.Remove("Eliminar");

            sucursalesDataGridView.Columns.Add("Eliminar", "Eliminar/Habilitar");
            agregarBotonesEliminar();
        }

        private void agregarBotonesEliminar()
        {
            foreach (DataGridViewRow row in sucursalesDataGridView.Rows)
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
            sucursalesDataGridView.Columns["id_sucursal"].Visible = false;
        }

        private void sucursalesDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Controla que la celda que se clickeo fue la de modificar
            if (e.ColumnIndex == sucursalesDataGridView.Columns["Modificar"].Index && e.RowIndex >= 0)
            {
                String idSucursalAModificar = sucursalesDataGridView.Rows[e.RowIndex].Cells["id_sucursal"].Value.ToString();
                new AltaModifSucursal(new Modificacion()).ShowDialog(idSucursalAModificar);
                CargarSucursales();
                return;
            }
            if (e.ColumnIndex == sucursalesDataGridView.Columns["Eliminar"].Index && e.RowIndex >= 0)
            {
                String idSucursalAModificar = sucursalesDataGridView.Rows[e.RowIndex].Cells["id_sucursal"].Value.ToString();
                Boolean valorHabilitacion = (Boolean)sucursalesDataGridView.Rows[e.RowIndex].Cells["Habilitado"].Value;
                if (valorHabilitacion)
                {
                    Boolean resultado = mapper.CambiarHabilitacionSucursal(Convert.ToInt32(idSucursalAModificar), "Sucursal", 0);
                    Util.ShowMessage("Se eliminó la sucursal correctamente.", MessageBoxIcon.Information);
                }
                else
                {
                    Boolean resultado = mapper.CambiarHabilitacionSucursal(Convert.ToInt32(idSucursalAModificar), "Sucursal", 1);
                    Util.ShowMessage("Se habilitó la sucursal correctamente.", MessageBoxIcon.Information);
                }

                CargarSucursales();
                return;
            }
        }

        private void buscarButton_Click(object sender, EventArgs e)
        {
            String filtro = CalcularFiltro();
            sucursalesDataGridView.DataSource = mapper.SelectSucursalesParaFiltroConFiltro(filtro);
            CargarColumnaModificacion();
            CargarColumnaEliminar();
        }

        private String CalcularFiltro()
        {
            String filtro = "";
            if (nombreTextBox.Text != "") filtro += "AND " + "S.nombre LIKE '" + nombreTextBox.Text + "%'";
            if (direccionTextBox.Text != "") filtro += "AND " + "S.direccion LIKE '" + direccionTextBox.Text + "%'";
            if (codPostalTextBox.Text != "") filtro += "AND " + "S.codigo_postal LIKE '" + codPostalTextBox.Text + "%'";

            return filtro;
        }
    }
}
