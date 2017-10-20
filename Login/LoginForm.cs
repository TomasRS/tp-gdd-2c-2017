using PagoAgilFrba.DataProvider;
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
                PopupMessage.ShowMessage("Debe ingresar un usuario.", "Información", MessageBoxIcon.Warning);
                return;
            }

            if (passwordTextBox.Text == "")
            {
                PopupMessage.ShowMessage("Debe ingresar una contraseña.", "Información", MessageBoxIcon.Warning);
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

            //continuar
        }

    }
}
