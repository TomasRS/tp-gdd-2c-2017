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
using PagoAgilFrba.DataProvider;
using PagoAgilFrba.Menu_Principal;

namespace PagoAgilFrba.Login
{
    public partial class EleccionRol : Form
    {
        private SqlCommand command { get; set; }
        private IList<SqlParameter> parametros = new List<SqlParameter>();

        public Object SelectedItem { get; set; }

        public EleccionRol()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void volverButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            new LoginForm().ShowDialog();
            this.Close();
        }

        private void EleccionRol_Load(object sender, EventArgs e)
        {
            CargarRoles();
        }

        private void aceptarButton_Click(object sender, EventArgs e)
        {
            String rolElegido = rolComboBox.SelectedValue.ToString();
            UsuarioSesion.Usuario.rol = rolElegido;

            this.Hide();
            new MenuPrincipal().ShowDialog();
            this.Close();
        }

        private void CargarRoles()
        {
            DataSet rolesUsuario = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@username", UsuarioSesion.usuario.nombre));
            command = QueryBuilder.Instance.build("SELECT r.nombre from GAME_OF_CODE.Rol r, GAME_OF_CODE.Rol_por_Usuario ru WHERE r.estado_habilitacion = 1 AND (SELECT id_usuario FROM GAME_OF_CODE.Usuario WHERE username = @username) = ru.id_usuario AND r.id_rol = ru.id_rol ", parametros);
            adapter.SelectCommand = command;
            adapter.Fill(rolesUsuario, "Rol");
            rolComboBox.DataSource = rolesUsuario.Tables[0].DefaultView;
            rolComboBox.ValueMember = "nombre";
        }
    }
}
