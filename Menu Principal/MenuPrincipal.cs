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
using PagoAgilFrba.Modelo;

namespace PagoAgilFrba.Menu_Principal
{
    public partial class MenuPrincipal : Form
    {
        private SqlCommand command { get; set; }
        private Dictionary<String, Form> funcionalidades = new Dictionary<String, Form>();

        public MenuPrincipal()
        {
            InitializeComponent();
            CenterToScreen();

            funcionalidades.Add("Alta de clientes", new AbmCliente.AltaModifCliente(new Alta()));
            funcionalidades.Add("Modificación y baja de clientes", new AbmCliente.ListadoCliente());
            funcionalidades.Add("Alta de empresas", new AbmEmpresa.AltaModifEmpresa(new Alta()));
            funcionalidades.Add("Modificación y baja de empresas", new AbmEmpresa.ListadoEmpresa());
            funcionalidades.Add("Alta de facturas", new AbmFactura.AltaModifFactura());
            funcionalidades.Add("Modificación y baja de facturas", new AbmFactura.ListadoFacturas());
            funcionalidades.Add("Alta de roles", new AbmRol.AltaModifRol());
            funcionalidades.Add("Modificación y baja de roles", new AbmRol.ListadoRol());
            funcionalidades.Add("Alta de sucursales", new AbmSucursal.AltaModifSucursal());
            funcionalidades.Add("Modificación y baja de sucursales", new AbmSucursal.ListadoSucursal());
            funcionalidades.Add("Devolución de facturas pagas", new Devolucion.DevolucionFactura());
            funcionalidades.Add("Listado estadístico", new ListadoEstadistico.ListadoEstadistico());
            funcionalidades.Add("Pagar facturas", new RegistroPago.RegistroPagoFacturas());
            funcionalidades.Add("Realizar rendicion de facturas", new Rendicion.RendicionFacturas());
        }

        private void cerrarSesionButton_Click(object sender, EventArgs e)
        {
            // Relleno la sesion con datos inexistentes para que no queden datos cacheados de un usuario del sistema
            UsuarioSesion.Usuario.id = 0;
            UsuarioSesion.Usuario.nombre = null;
            UsuarioSesion.Usuario.rol = null;

            // Redirect al Login
            this.Hide();
            new LoginForm().ShowDialog();
            this.Close();
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            DataSet actions = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();

            String funcionalidadesUsuario = "SELECT f.descripcion from GAME_OF_CODE.Rol r, GAME_OF_CODE.Funcionalidad_por_Rol fr, GAME_OF_CODE.Funcionalidad f WHERE r.id_rol = fr.id_rol AND f.id_funcionalidad = fr.id_funcionalidad AND r.nombre = @rol";
            IList<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@rol", UsuarioSesion.Usuario.rol));
            command = QueryBuilder.Instance.build(funcionalidadesUsuario, parametros);

            adapter.SelectCommand = command;
            adapter.Fill(actions, "Funcionalidad");
            accionesComboBox.DataSource = actions.Tables[0].DefaultView;
            accionesComboBox.ValueMember = "descripcion";
        }

        private void aceptarButton_Click(object sender, EventArgs e)
        {
            String accionElegida = accionesComboBox.SelectedValue.ToString();

            this.Hide();
            funcionalidades[accionElegida].ShowDialog();
            this.Close();
        }
    }
}
