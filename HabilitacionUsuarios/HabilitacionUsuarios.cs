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

namespace PagoAgilFrba.HabilitacionUsuarios
{
    public partial class HabilitacionUsuarios : Form
    {
        private DBMapper mapper = new DBMapper();

        public HabilitacionUsuarios()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void HabilitacionUsuarios_Load(object sender, EventArgs e)
        {
            CargarUsuariosDeshabilitados();
            if (!mapper.HayUsuariosDeshabilitados())
                Util.ShowMessage("No hay usuarios deshabilitados en el sistema.", MessageBoxIcon.Information);
        }

        private void CargarUsuariosDeshabilitados()
        {
            usuariosDataGridView.DataSource = mapper.SelectUsuariosParaFiltro();
            CargarColumnaHabilitar();
            DeshabilitarSortHeaders();
            OcultarColumnasQueNoDebenVerse();
        }

        private void DeshabilitarSortHeaders()
        {
            foreach (DataGridViewColumn column in usuariosDataGridView.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void OcultarColumnasQueNoDebenVerse()
        {
            usuariosDataGridView.Columns["id_usuario"].Visible = false;
        }

        private void CargarColumnaHabilitar()
        {
            if (usuariosDataGridView.Columns.Contains("Habilitar"))
                usuariosDataGridView.Columns.Remove("Habilitar");

            DataGridViewButtonColumn botonColumnaHabilitar = new DataGridViewButtonColumn();
            botonColumnaHabilitar.Text = "Habilitar";
            botonColumnaHabilitar.Name = "Habilitar";
            botonColumnaHabilitar.UseColumnTextForButtonValue = true;
            usuariosDataGridView.Columns.Add(botonColumnaHabilitar);
        }

        private void usuariosDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String idUsuarioAHabilitar = usuariosDataGridView.Rows[e.RowIndex].Cells["id_usuario"].Value.ToString();
            mapper.CambiarHabilitacionUsuario(Util.getNumeroFromString(idUsuarioAHabilitar), "Usuario", 1);
            mapper.ResetearIntentosFallidosUsuario(Util.getNumeroFromString(idUsuarioAHabilitar));
            Util.ShowMessage("El usuario fue habilitado correctamente.", MessageBoxIcon.Information);
            usuariosDataGridView.Rows.RemoveAt(e.RowIndex);
            usuariosDataGridView.Refresh();
        }

        private void volverButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MenuPrincipal().ShowDialog();
            this.Close();
        }
    }
}
