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

namespace PagoAgilFrba.AbmSucursal
{
    public partial class AsignacionSucursalesAUsuario : Form
    {
        private DBMapper mapper = new DBMapper();
        private IList<SqlParameter> parametros = new List<SqlParameter>();
        private SqlCommand command { get; set; }

        public AsignacionSucursalesAUsuario()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void limpiarButton_Click(object sender, EventArgs e)
        {
            usuariosComboBox.SelectedIndex = -1;
            limpiarSucursales();
        }

        private void limpiarSucursales()
        {
            for (int i = 0; i < sucursalesCheckedListBox.Items.Count; i++)
            {
                sucursalesCheckedListBox.SetItemChecked(i, false);
            }
        }

        private void volverButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MenuPrincipal().ShowDialog();
            this.Close();
        }

        private void AsignacionSucursalesAUsuario_Load(object sender, EventArgs e)
        {
            CargarUsuarios();
            CargarSucursales();
        }

        private void CargarUsuarios()
        {
            string query = "SELECT id_usuario, username from GAME_OF_CODE.Usuario";

            SqlCommand cmd = new SqlCommand(query, ConnectionManager.Instance.getConnection());

            SqlDataAdapter data_adapter = new SqlDataAdapter(cmd);
            DataTable usuarios = new DataTable();
            data_adapter.Fill(usuarios);

            usuariosComboBox.ValueMember = "id_usuario";
            usuariosComboBox.DisplayMember = "username";
            usuariosComboBox.DataSource = usuarios;
            usuariosComboBox.SelectedIndex = -1;
        }
        private void CargarSucursales()
        {
            DataSet sucursales = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            parametros = new List<SqlParameter>();
            command = QueryBuilder.Instance.build("SELECT DISTINCT nombre FROM GAME_OF_CODE.Sucursal", parametros);
            adapter.SelectCommand = command;
            adapter.Fill(sucursales);
            sucursalesCheckedListBox.DataSource = sucursales.Tables[0].DefaultView;
            sucursalesCheckedListBox.ValueMember = "nombre";
        }

        private void usuariosComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            limpiarSucursales();
            if (usuariosComboBox.Text != "")
                tildarSucursalesQueTiene(mapper.getSucursalesDelUsuario(mapper.getIDUsuario(usuariosComboBox.Text)));
            else
                limpiarSucursales();
        }

        private void tildarSucursalesQueTiene(DataSet sucursalesDelUsuario)
        {
            List<String> rolesACheckear = sucursalesDelUsuario.Tables[0].AsEnumerable().Select(r => r.Field<string>("nombre")).ToList();

            for (int i = 0; i < sucursalesCheckedListBox.Items.Count; i++)
            {
                if (rolesACheckear.Contains(((System.Data.DataRowView)(sucursalesCheckedListBox.Items[i])).Row.ItemArray[0].ToString()))
                    sucursalesCheckedListBox.SetItemCheckState(i, CheckState.Checked);
            }
        }

        private void actualizarButton_Click(object sender, EventArgs e)
        {
            if (usuariosComboBox.SelectedIndex.Equals(-1))
            {
                Util.ShowMessage("Debe seleccionar un usuario.", MessageBoxIcon.Exclamation);
                return;
            }
            if (!Util.HayAlMenosAlgoSeleccionadoEnListBox(sucursalesCheckedListBox))
            {
                Util.ShowMessage("Debe seleccionar al menos una sucursal.", MessageBoxIcon.Exclamation);
                return;
            }

            guardarInformacion();
            Util.ShowMessage("Modificación de sucursales del usuario guardada correctamente.", MessageBoxIcon.Information);
            limpiarButton_Click(this, null);
        }

        private void guardarInformacion()
        {
            agregarSucursalesSiCorresponde();
            quitarRolesSiCorresponde();
        }

        private bool verificarSiLaTiene(String sucursal, String username)
        {
            parametros.Clear();
            parametros.Add(new SqlParameter("@username", username));
            parametros.Add(new SqlParameter("@nombre", sucursal));

            String queryCantidadRolXUsuario = "SELECT COUNT(*) FROM GAME_OF_CODE.Usuario_por_Sucursal rxs WHERE rxs.id_sucursal = (SELECT s.id_sucursal FROM GAME_OF_CODE.Sucursal s WHERE s.nombre = @nombre) AND rxs.id_usuario = (SELECT u.id_usuario FROM GAME_OF_CODE.Usuario u WHERE u.username = @username)";
            int tieneLaFuncionalidad = (int)QueryBuilder.Instance.build(queryCantidadRolXUsuario, parametros).ExecuteScalar();
            return tieneLaFuncionalidad.Equals(1);
        }

        private void agregarSucursalesSiCorresponde()
        {
            foreach (DataRowView sucursal in this.sucursalesCheckedListBox.CheckedItems)
            {
                if (verificarSiLaTiene(sucursal.Row["nombre"] as String, usuariosComboBox.Text))
                {

                }
                else
                {
                    parametros.Clear();
                    parametros.Add(new SqlParameter("@username", usuariosComboBox.Text));
                    parametros.Add(new SqlParameter("@nombre", sucursal.Row["nombre"] as String));

                    String queryRolXUsuario = "INSERT INTO GAME_OF_CODE.Usuario_por_Sucursal(id_sucursal, id_usuario) VALUES ((SELECT s.id_sucursal FROM GAME_OF_CODE.Sucursal s WHERE s.nombre = @nombre), (SELECT u.id_usuario FROM GAME_OF_CODE.Usuario u WHERE u.username = @username))";

                    QueryBuilder.Instance.build(queryRolXUsuario, parametros).ExecuteNonQuery();
                }
            }
        }

        private void quitarRolesSiCorresponde()
        {
            foreach (DataRowView sucursal in this.sucursalesCheckedListBox.Items)
            {
                int index = sucursalesCheckedListBox.Items.IndexOf(sucursal);
                String estado = this.sucursalesCheckedListBox.GetItemCheckState(index).ToString();

                if (estado == "Unchecked")
                {
                    parametros.Clear();
                    parametros.Add(new SqlParameter("@username", usuariosComboBox.Text));
                    parametros.Add(new SqlParameter("@nombre", sucursal.Row["nombre"] as String));

                    String queryBorrarRolXFuncionalidad = "DELETE GAME_OF_CODE.Usuario_por_Sucursal WHERE id_sucursal = (SELECT s.id_sucursal FROM GAME_OF_CODE.Sucursal s WHERE s.nombre = @nombre) AND id_usuario = (SELECT u.id_usuario FROM GAME_OF_CODE.Usuario u WHERE u.username = @username)";

                    QueryBuilder.Instance.build(queryBorrarRolXFuncionalidad, parametros).ExecuteNonQuery();
                }
            }
        }
    }
}
