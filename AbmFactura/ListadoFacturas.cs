using PagoAgilFrba.DataProvider;
using PagoAgilFrba.Menu_Principal;
using PagoAgilFrba.Modelo;
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

namespace PagoAgilFrba.AbmFactura
{
    public partial class ListadoFacturas : Form
    {
        private DBMapper mapper = new DBMapper();

        public ListadoFacturas()
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

        private void ListadoFacturas_Load(object sender, EventArgs e)
        {
            CargarFacturas();
        }

        private void CargarFacturas()
        {
            facturasDataGridView.DataSource = mapper.SelectFacturasParaFiltro();
            CargarColumnaModificacion();
            CargarColumnaEliminar();
            DeshabilitarSortHeaders();
            OcultarColumnasQueNoDebenVerse();
        }

        private void CargarColumnaModificacion()
        {
            if (facturasDataGridView.Columns.Contains("Modificar"))
                facturasDataGridView.Columns.Remove("Modificar");

            DataGridViewButtonColumn botonColumnaModificar = new DataGridViewButtonColumn();
            botonColumnaModificar.Text = "Modificar";
            botonColumnaModificar.Name = "Modificar";
            botonColumnaModificar.UseColumnTextForButtonValue = true;
            facturasDataGridView.Columns.Add(botonColumnaModificar);
        }

        private void CargarColumnaEliminar()
        {
            if (facturasDataGridView.Columns.Contains("Eliminar"))
                facturasDataGridView.Columns.Remove("Eliminar");

            facturasDataGridView.Columns.Add("Eliminar", "Eliminar/Habilitar");
            agregarBotonesEliminar();
        }

        private void agregarBotonesEliminar()
        {
            foreach (DataGridViewRow row in facturasDataGridView.Rows)
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

        private void facturasDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Controla que la celda que se clickeo fue la de modificar
            if (e.ColumnIndex == facturasDataGridView.Columns["Modificar"].Index && e.RowIndex >= 0)
            {
                String idFacturaAModificar = facturasDataGridView.Rows[e.RowIndex].Cells["id_factura"].Value.ToString();
                new AltaModifFactura(new Modificacion()).ShowDialog(idFacturaAModificar);
                CargarFacturas();
                return;
            }
            if (e.ColumnIndex == facturasDataGridView.Columns["Eliminar"].Index && e.RowIndex >= 0)
            {
                String idFacturaAModificar = facturasDataGridView.Rows[e.RowIndex].Cells["id_factura"].Value.ToString();
                Boolean valorHabilitacion = (Boolean)facturasDataGridView.Rows[e.RowIndex].Cells["Habilitado"].Value;
                if (valorHabilitacion)
                {
                    Boolean resultado = mapper.CambiarHabilitacionFactura(Convert.ToInt32(idFacturaAModificar), "Factura", 0);
                    Util.ShowMessage("Se eliminó la factura correctamente.", MessageBoxIcon.Information);
                }
                else
                {
                    Boolean resultado = mapper.CambiarHabilitacionFactura(Convert.ToInt32(idFacturaAModificar), "Factura", 1);
                    Util.ShowMessage("Se habilitó la factura correctamente.", MessageBoxIcon.Information);
                }

                CargarFacturas();
                return;
            }
        }
        //-------------------------------------------------------------------------
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
    }
}
