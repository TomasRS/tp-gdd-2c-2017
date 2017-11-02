using PagoAgilFrba.DataProvider;
using PagoAgilFrba.Menu_Principal;
using PagoAgilFrba.Modelo;
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
    public partial class AltaModifFactura : AbstractForm
    {
        private DBMapper mapper = new DBMapper();
        private int idFactura;
        private IList<TextBox> campos = new List<TextBox>();
        private TipoDeAccion tipoAccion;
        private Factura factura;

        public AltaModifFactura(TipoDeAccion tipoAccion)
        {
            this.tipoAccion = tipoAccion;
            InitializeComponent();
            CenterToScreen();
        }
        private void limpiarButton_Click(object sender, EventArgs e)
        {
            clienteTextBox.Clear();
            nroFacturaTextBox.Clear();
            fechaAltaFactDateTimePicker.Text = "";
            fechaVencDateTimePicker.Text = "";
            empresaComboBox.SelectedIndex = -1;
        }
        private void volverButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MenuPrincipal().ShowDialog();
            this.Close();
        }
        public override void setearTituloCreacion()
        {
            this.Text = "Alta de factura";
        }
        public override void setearTituloModificacion()
        {
            this.Text = "Modificación de factura";
        }

        public override void CargarDatos()
        {
            throw new NotImplementedException();
        }

        public override void guardarInformacion()
        {
            throw new NotImplementedException();
        }

        public override void Crear()
        {
            throw new NotImplementedException();
        }

        public override void Modificar()
        {
            throw new NotImplementedException();
        }

        private void AltaModifFactura_Load(object sender, EventArgs e)
        {
            campos.Add(clienteTextBox);
            campos.Add(nroFacturaTextBox);

            CargarEmpresas();
            tipoAccion.cargarDatosSiCorresponde(this);
            tipoAccion.setearTituloVentana(this);
        }

        private void CargarEmpresas()
        {
            string query = "SELECT id_empresa, nombre from GAME_OF_CODE.Empresa";

            SqlCommand cmd = new SqlCommand(query, ConnectionManager.Instance.getConnection());

            SqlDataAdapter data_adapter = new SqlDataAdapter(cmd);
            DataTable rubros = new DataTable();
            data_adapter.Fill(rubros);

            empresaComboBox.ValueMember = "id_empresa";
            empresaComboBox.DisplayMember = "nombre";
            empresaComboBox.DataSource = rubros;
            empresaComboBox.SelectedIndex = 0;
        }
    }
}
