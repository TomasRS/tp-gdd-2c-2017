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

namespace PagoAgilFrba.AbmRol
{
    public partial class AsignacionRolesAUsuario : Form
    {
        private DBMapper mapper = new DBMapper();
        private IList<SqlParameter> parametros = new List<SqlParameter>();

        public AsignacionRolesAUsuario()
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

        private void limpiarButton_Click(object sender, EventArgs e)
        {
            usuariosComboBox.SelectedIndex = -1;
            limpiarRoles();
        }

        private void limpiarRoles()
        {
            for (int i = 0; i < rolesCheckedListBox.Items.Count; i++)
            {
                rolesCheckedListBox.SetItemChecked(i, false);
            }
        }

        private void AsignacionRolesAUsuario_Load(object sender, EventArgs e)
        {
            CargarUsuarios();
            CargarRoles();
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
            usuariosComboBox.SelectedIndex = 0;
        }

        private void actualizarButton_Click(object sender, EventArgs e)
        {
            if (!Util.HayAlMenosAlgoSeleccionadoEnListBox(rolesCheckedListBox))
            {
                Util.ShowMessage("Debe seleccionar al menos un rol.", MessageBoxIcon.Exclamation);
                return;
            }

            guardarInformacion();
        }

        private void guardarInformacion()
        {
            agregarRolesSiCorresponde();
            quitarRolesSiCorresponde();
        }

        private bool verificarSiLaTiene(String rol)
        {
            parametros.Clear();
            parametros.Add(new SqlParameter("@username", UsuarioSesion.Usuario.id));
            parametros.Add(new SqlParameter("@nombre", rol));

            String queryCantidadRolXFuncionalidad = "SELECT COUNT(*) FROM GAME_OF_CODE.Rol_por_Usuario rxu WHERE rxu.id_rol = (SELECT r.id_rol FROM GAME_OF_CODE.Rol r WHERE r.nombre = @nombre) AND rxu.id_usuario = (SELECT u.id_usuario FROM GAME_OF_CODE.Usuario u WHERE u.username = @username)";
            int tieneLaFuncionalidad = (int)QueryBuilder.Instance.build(queryCantidadRolXFuncionalidad, parametros).ExecuteScalar();
            return tieneLaFuncionalidad.Equals(1);
        }

        private void agregarRolesSiCorresponde()
        {
            foreach (DataRowView rol in this.rolesCheckedListBox.CheckedItems)
            {
                if (verificarSiLaTiene(rol.Row["nombre"] as String))
                {

                }
                else
                {
                    parametros.Clear();
                    parametros.Add(new SqlParameter("@username", UsuarioSesion.Usuario.id));
                    parametros.Add(new SqlParameter("@nombre", rol.Row["nombre"] as String));

                    String queryRolXUsuario = "INSERT INTO GAME_OF_CODE.Rol_por_Usuario(id_rol, id_usuario) VALUES ((SELECT r.id_rol FROM GAME_OF_CODE.Rol r WHERE r.nombre = @nombre), (SELECT u.id_usuario FROM GAME_OF_CODE.Usuario u WHERE u.username = @username))";

                    QueryBuilder.Instance.build(queryRolXUsuario, parametros).ExecuteNonQuery();
                }
            }
        }
        private void quitarRolesSiCorresponde()
        {
            foreach (DataRowView rol in this.rolesCheckedListBox.Items)
            {
                int index = rolesCheckedListBox.Items.IndexOf(rol);
                String estado = this.rolesCheckedListBox.GetItemCheckState(index).ToString();

                if (estado == "Unchecked")
                {
                    parametros.Clear();
                    parametros.Add(new SqlParameter("@username", UsuarioSesion.Usuario.id));
                    parametros.Add(new SqlParameter("@nombre", rol.Row["nombre"] as String));

                    String queryBorrarRolXFuncionalidad = "DELETE GAME_OF_CODE.Rol_por_Usuario WHERE id_rol = (SELECT r.id_rol FROM GAME_OF_CODE.Rol r WHERE r.nombre = @nombre) AND id_usuario = (SELECT u.id_usuario FROM GAME_OF_CODE.Usuario u WHERE u.username = @username)";

                    QueryBuilder.Instance.build(queryBorrarRolXFuncionalidad, parametros).ExecuteNonQuery();
                }
            }
        }

        private void CargarRoles()
        {
            
        }
    }
}
