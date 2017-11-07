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

        private void volverButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MenuPrincipal().ShowDialog();
            this.Close();
        }

        private void habilitarUsuariosButton_Click(object sender, EventArgs e)
        {
            if (usuariosDataGridView.SelectedRows.Count >= 1)
            {
                foreach (DataGridViewRow row in usuariosDataGridView.SelectedRows)
                {
                    String idUsuarioAHabilitar = row.Cells["id_usuario"].Value.ToString();
                    mapper.CambiarHabilitacionUsuario(Util.getNumeroFromString(idUsuarioAHabilitar), "Usuario", 1);
                    mapper.ResetearIntentosFallidosUsuario(Util.getNumeroFromString(idUsuarioAHabilitar));
                    usuariosDataGridView.Rows.Remove(row);
                    usuariosDataGridView.Refresh();
                }
                Util.ShowMessage("Los usuarios seleccionados fueron habilitados correctamente.", MessageBoxIcon.Information);
            }
            else
                Util.ShowMessage("Primero tiene que seleccionar al menos un usuario.", MessageBoxIcon.Exclamation);
        }
    }
}
