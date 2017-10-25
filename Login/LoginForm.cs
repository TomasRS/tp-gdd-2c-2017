using PagoAgilFrba.DataProvider;
using PagoAgilFrba.Utils;
using PagoAgilFrba.Login;
using PagoAgilFrba.Menu_Principal;
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

namespace PagoAgilFrba
{
    public partial class LoginForm : Form
    {

        public LoginForm()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (usernameTextBox.Text == "")
            {
                PopupMessage.ShowMessage("Debe ingresar un usuario.", MessageBoxIcon.Warning);
                return;
            }

            if (passwordTextBox.Text == "")
            {
                PopupMessage.ShowMessage("Debe ingresar una contraseña.", MessageBoxIcon.Warning);
                return;
            }

            validar(usernameTextBox.Text, passwordTextBox.Text);
        }

        private void validar(string username, string password)
        {
            String query = "SELECT * FROM GAME_OF_CODE.Usuario WHERE username = @username AND password = @password AND estado_habilitacion = 1";
            String contraseña = HashSHA256.getHash(password);

            IList<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@username", username));
            parametros.Add(new SqlParameter("@password", contraseña));

            SqlDataReader reader = QueryHelper.Instance.exec(query, parametros);

            if (QueryHelper.Instance.readFrom(reader))
            {
                PopupMessage.ShowMessage("Bienvenido " + reader["username"] + ".", MessageBoxIcon.Information);

                UsuarioSesion.Usuario.nombre = (String)reader["username"];
                UsuarioSesion.Usuario.id = (Int32)reader["id_usuario"];

                //Usuario logueado correctamente (intentos fallidos = 0)
                parametros.Clear();
                parametros.Add(new SqlParameter("@username", username));
                String clearIntentosFallidos = "UPDATE GAME_OF_CODE.Usuario SET intentos_fallidos = 0 WHERE username = @username";
                QueryBuilder.Instance.build(clearIntentosFallidos, parametros).ExecuteNonQuery();

                //Consulta roles
                // ESTO ES LO QUE FALLA!
                String consultaRoles = "SELECT COUNT(id_rol) FROM GAME_OF_CODE.Rol_por_Usuario WHERE (SELECT id_usuario FROM GAME_OF_CODE.Usuario WHERE username = @username) = id_usuario";
                int cantidadDeRoles = (int)QueryBuilder.Instance.build(consultaRoles, parametros).ExecuteScalar();

                //Si es mas de un rol muestra la pantalla de eleccion de roles, sino no
                if (cantidadDeRoles > 1)
                {
                    this.Hide();
                    new EleccionRol().Show();
                    this.Close();
                }
                else
                {
                    parametros.Clear();
                    parametros.Add(new SqlParameter("@username", username));
                    String rolDeUsuario = "SELECT r.nombre FROM GAME_OF_CODE.Rol r, GAME_OF_CODE.Rol_por_Usuario ru, GAME_OF_CODE.Usuario u WHERE r.id_rol = ru.id_rol AND ru.id_usuario = u.id_usuario AND u.username = @username";
                    String rolUser = (String)QueryBuilder.Instance.build(rolDeUsuario, parametros).ExecuteScalar();

                    UsuarioSesion.Usuario.rol = rolUser;
                    if (UsuarioSesion.Usuario.rol == null)
                    {
                        PopupMessage.ShowMessage("No existen roles para iniciar sesión.", MessageBoxIcon.Exclamation);
                        return;
                    }

                    this.Hide();
                    new MenuPrincipal().Show();
                    this.Close();
                }
            }
            else
            {
                //Chequea si el usuario era correcto
                parametros.Clear();
                parametros.Add(new SqlParameter("@username", username));
                String buscaUsuario = "SELECT * FROM GAME_OF_CODE.Usuario WHERE username = @username";
                SqlDataReader lector = QueryBuilder.Instance.build(buscaUsuario, parametros).ExecuteReader();

                if (lector.Read())
                {
                    // Se fija si el usuario esta inhabilitado
                    parametros.Clear();
                    parametros.Add(new SqlParameter("@username", username));
                    parametros.Add(new SqlParameter("@password", contraseña));
                    String estaDeshabilitado = "SELECT * FROM GAME_OF_CODE.Usuario WHERE username = @username AND estado_habilitacion = 0";

                    SqlDataReader userDeshabilitado = QueryBuilder.Instance.build(estaDeshabilitado, parametros).ExecuteReader();

                    if (userDeshabilitado.Read())
                    {
                        PopupMessage.ShowMessage("El usuario está deshabilitado.", MessageBoxIcon.Information);
                        return;
                    }

                    // Suma un fallido
                    parametros.Clear();
                    parametros.Add(new SqlParameter("@username", username));
                    String sumaFallido = "UPDATE GAME_OF_CODE.Usuario SET intentos_fallidos = intentos_fallidos + 1 WHERE username = @username";
                    QueryBuilder.Instance.build(sumaFallido, parametros).ExecuteNonQuery();

                    // Si es el tercer fallido se deshabilita al usuario
                    parametros.Clear();
                    parametros.Add(new SqlParameter("@username", username));
                    String cantidadFallidos = "SELECT intentos_fallidos FROM GAME_OF_CODE.Usuario WHERE username = @username";
                    int intentosFallidos = Convert.ToInt32(QueryBuilder.Instance.build(cantidadFallidos, parametros).ExecuteScalar());

                    if (intentosFallidos == 3)
                    {
                        parametros.Clear();
                        parametros.Add(new SqlParameter("@username", username));
                        String deshabilitar = "UPDATE GAME_OF_CODE.Usuario SET estado_habilitacion = 0 WHERE username = @username";
                        QueryBuilder.Instance.build(deshabilitar, parametros).ExecuteNonQuery();
                    }
                    PopupMessage.ShowMessage("Contraseña incorrecta." + '\n' + "Intentos fallidos: " + intentosFallidos + ".", MessageBoxIcon.Exclamation);
                }
                else
                {
                    PopupMessage.ShowMessage("El usuario no existe.", MessageBoxIcon.Exclamation);
                }
            }
        }

    }
}
