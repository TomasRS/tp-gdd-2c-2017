using PagoAgilFrba.DataProvider;
using PagoAgilFrba.Menu_Principal;
using PagoAgilFrba.Modelo;
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

namespace PagoAgilFrba.AbmRol
{
    public partial class ListadoRol : Form
    {
        private DBMapper mapper = new DBMapper();

        public ListadoRol()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void volverButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MenuPrincipal().ShowDialog();
            this.Close();
        }

        private void ListadoRol_Load(object sender, EventArgs e)
        {
            CargarRoles();
        }

        private void CargarRoles()
        {
            RolesDataGridView.DataSource = mapper.SelectRolesParaFiltro();
            RolesDataGridView.Rows.RemoveAt(0);
            CargarColumnaModificacion();
            CargarColumnaEliminar();
            DeshabilitarSortHeaders();
            OcultarColumnasQueNoDebenVerse();
        }

        private void CargarColumnaModificacion()
        {
            if (RolesDataGridView.Columns.Contains("Modificar"))
                RolesDataGridView.Columns.Remove("Modificar");

            DataGridViewButtonColumn botonColumnaModificar = new DataGridViewButtonColumn();
            botonColumnaModificar.Text = "Modificar";
            botonColumnaModificar.Name = "Modificar";
            botonColumnaModificar.UseColumnTextForButtonValue = true;
            RolesDataGridView.Columns.Add(botonColumnaModificar);
        }
        private void CargarColumnaEliminar()
        {
            if (RolesDataGridView.Columns.Contains("Eliminar"))
                RolesDataGridView.Columns.Remove("Eliminar");

            RolesDataGridView.Columns.Add("Eliminar", "Eliminar/Habilitar");
            agregarBotonesEliminar();
        }
        private void agregarBotonesEliminar()
        {
            foreach (DataGridViewRow row in RolesDataGridView.Rows)
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
            RolesDataGridView.Columns["id_rol"].Visible = false;
        }
        private void DeshabilitarSortHeaders()
        {
            foreach (DataGridViewColumn column in RolesDataGridView.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void clientesDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Controla que la celda que se clickeo fue la de modificar
            if (e.ColumnIndex == RolesDataGridView.Columns["Modificar"].Index && e.RowIndex >= 0)
            {
                String idRolAModificar = RolesDataGridView.Rows[e.RowIndex].Cells["id_rol"].Value.ToString();
                new AltaModifRol(new Modificacion()).ShowDialog(idRolAModificar);
                CargarRoles();
                return;
            }
            if (e.ColumnIndex == RolesDataGridView.Columns["Eliminar"].Index && e.RowIndex >= 0)
            {
                String idRolAModificar = RolesDataGridView.Rows[e.RowIndex].Cells["id_rol"].Value.ToString();
                if (idRolAModificar.Equals("1"))
                {
                    Util.ShowMessage("El rol maestro de Administrador no se puede deshabilitar.", MessageBoxIcon.Exclamation);
                    return;
                }

                Boolean valorHabilitacion = (Boolean)RolesDataGridView.Rows[e.RowIndex].Cells["Habilitado"].Value;
                if (valorHabilitacion)
                {
                    Boolean resultado = mapper.CambiarHabilitacionRol(Convert.ToInt32(idRolAModificar), "Rol", 0);
                    Util.ShowMessage("Se eliminó el rol correctamente.", MessageBoxIcon.Information);
                }
                else
                {
                    Boolean resultado = mapper.CambiarHabilitacionRol(Convert.ToInt32(idRolAModificar), "Rol", 1);
                    Util.ShowMessage("Se habilitó el rol correctamente.", MessageBoxIcon.Information);
                }

                CargarRoles();
                return;
            }
        }
    }
}
