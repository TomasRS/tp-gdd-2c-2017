using PagoAgilFrba.DataProvider;
using PagoAgilFrba.Menu_Principal;
using PagoAgilFrba.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.AbmCliente
{
    public partial class ListadoCliente : Form
    {
        private DBMapper mapper = new DBMapper();

        public ListadoCliente()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void CargarClientes()
        {
            clientesDataGridView.DataSource = mapper.SelectClientesParaFiltro();
            CargarColumnaModificacion();
            CargarColumnaEliminar();
        }

        private void CargarColumnaModificacion()
        {
            if (clientesDataGridView.Columns.Contains("Modificar"))
                clientesDataGridView.Columns.Remove("Modificar");
            DataGridViewButtonColumn botonColumnaModificar = new DataGridViewButtonColumn();
            botonColumnaModificar.Text = "Modificar";
            botonColumnaModificar.Name = "Modificar";
            botonColumnaModificar.UseColumnTextForButtonValue = true;
            clientesDataGridView.Columns.Add(botonColumnaModificar);
        }

        private void CargarColumnaEliminar()
        {
            if (clientesDataGridView.Columns.Contains("Eliminar"))
                clientesDataGridView.Columns.Remove("Eliminar");
            DataGridViewButtonColumn botonColumnaEliminar = new DataGridViewButtonColumn();
            botonColumnaEliminar.Text = "Eliminar";
            botonColumnaEliminar.Name = "Eliminar";
            botonColumnaEliminar.UseColumnTextForButtonValue = true;
            clientesDataGridView.Columns.Add(botonColumnaEliminar);
        }

        private void limpiarButton_Click(object sender, EventArgs e)
        {
            nombreTextBox.Clear();
            apellidoTextBox.Clear();
            dniTextBox.Clear();
            CargarClientes();
        }

        private void volverButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MenuPrincipal().ShowDialog();
            this.Close();
        }

        private void buscarButton_Click(object sender, EventArgs e)
        {
            String filtro = CalcularFiltro();
            clientesDataGridView.DataSource = mapper.SelectClientesParaFiltroConFiltro(filtro);
        }

        private String CalcularFiltro()
        {
            String filtro = "";
            if (nombreTextBox.Text != "") filtro += "AND " + "cli.nombre LIKE '" + nombreTextBox.Text + "%'";
            if (apellidoTextBox.Text != "") filtro += "AND " + "cli.apellido LIKE '" + apellidoTextBox.Text + "%'";
            if (dniTextBox.Text != "") filtro += "AND " + "cli.dni LIKE '" + dniTextBox.Text + "%'";
            return filtro;
        }

        private void ListadoCliente_Load(object sender, EventArgs e)
        {
            CargarClientes();
            OcultarColumnasQueNoDebenVerse();
        }

        private void OcultarColumnasQueNoDebenVerse()
        {
            clientesDataGridView.Columns["id_cliente"].Visible = false;
        }

        private void clientesDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Controla que la celda que se clickeo fue la de modificar
            if (e.ColumnIndex == clientesDataGridView.Columns["Modificar"].Index && e.RowIndex >= 0)
            {
                String idClienteAModificar = clientesDataGridView.Rows[e.RowIndex].Cells["id_cliente"].Value.ToString();
                new AltaModifCliente().ShowDialog(idClienteAModificar);
                CargarClientes();
                return;
            }
            if (e.ColumnIndex == clientesDataGridView.Columns["Eliminar"].Index && e.RowIndex >= 0)
            {
                String idClienteAEliminar = clientesDataGridView.Rows[e.RowIndex].Cells["id_cliente"].Value.ToString();
                Boolean resultado = mapper.EliminarCliente(Convert.ToInt32(idClienteAEliminar), "Cliente");
                if (resultado)
                    Util.ShowMessage("Se eliminó el cliente correctamente.", MessageBoxIcon.Information);
                
                CargarClientes();
                return;
            }
        }
    }
}
