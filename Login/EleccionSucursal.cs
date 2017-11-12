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

namespace PagoAgilFrba.Login
{
    public partial class EleccionSucursal : Form
    {
        private SqlCommand command { get; set; }
        private IList<SqlParameter> parametros = new List<SqlParameter>();
        private DBMapper mapper = new DBMapper();

        public EleccionSucursal()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void cerrarSesionButton_Click(object sender, EventArgs e)
        {
            // Relleno la sesion con datos inexistentes para que no queden datos cacheados de un usuario del sistema
            UsuarioSesion.Usuario.id = 0;
            UsuarioSesion.Usuario.nombre = null;
            UsuarioSesion.Usuario.rol = null;
            UsuarioSesion.Usuario.idSucursal = -1;

            // Redirect al Login
            this.Hide();
            new LoginForm().ShowDialog();
            this.Close();
        }

        private void EleccionSucursal_Load(object sender, EventArgs e)
        {
            CargarSucursalesUsuario();
        }

        private void CargarSucursalesUsuario()
        {
            DataSet sucursalesUsuario = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@username", UsuarioSesion.usuario.nombre));
            command = QueryBuilder.Instance.build("SELECT s.nombre from GAME_OF_CODE.Sucursal s, GAME_OF_CODE.Usuario_por_Sucursal su WHERE s.estado_habilitacion = 1 AND (SELECT id_usuario FROM GAME_OF_CODE.Usuario WHERE username = @username) = su.id_usuario AND s.id_sucursal = su.id_sucursal ", parametros);
            adapter.SelectCommand = command;
            adapter.Fill(sucursalesUsuario, "Sucursal");
            sucursalComboBox.DataSource = sucursalesUsuario.Tables[0].DefaultView;
            sucursalComboBox.ValueMember = "nombre";
        }

        private void aceptarButton_Click(object sender, EventArgs e)
        {
            int idSucursal = mapper.getIDSucursalByNombre(sucursalComboBox.Text);
            UsuarioSesion.Usuario.idSucursal = idSucursal;

            parametros.Clear();
            String consultaRoles = "EXEC GAME_OF_CODE.get_cantidad_roles_de_usuario " + UsuarioSesion.Usuario.nombre;
            int cantidadDeRoles = (int)QueryBuilder.Instance.build(consultaRoles, parametros).ExecuteScalar();

            //Si hay mas de un rol para ese usuario muestra la pantalla de eleccion de roles, sino la principal
            if (cantidadDeRoles > 1)
            {
                this.Hide();
                new EleccionRol().ShowDialog();
                this.Close();
            }
            else
            {
                parametros.Clear();
                parametros.Add(new SqlParameter("@username", UsuarioSesion.Usuario.nombre));
                String rolDeUsuario = "SELECT r.nombre FROM GAME_OF_CODE.Rol r, GAME_OF_CODE.Rol_por_Usuario ru, GAME_OF_CODE.Usuario u WHERE r.id_rol = ru.id_rol AND ru.id_usuario = u.id_usuario AND u.username = @username";
                String rolUser = (String)QueryBuilder.Instance.build(rolDeUsuario, parametros).ExecuteScalar();

                UsuarioSesion.Usuario.rol = rolUser;
                if (UsuarioSesion.Usuario.rol == null)
                {
                    Util.ShowMessage("No existen roles para iniciar sesión.", MessageBoxIcon.Exclamation);
                    return;
                }

                this.Hide();
                new MenuPrincipal().ShowDialog();
                this.Close();
            }
        }
    }
}
