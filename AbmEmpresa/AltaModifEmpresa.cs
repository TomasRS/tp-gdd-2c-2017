using PagoAgilFrba.DataProvider;
using PagoAgilFrba.Excepciones;
using PagoAgilFrba.Menu_Principal;
using PagoAgilFrba.Modelo;
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

namespace PagoAgilFrba.AbmEmpresa
{
    public partial class AltaModifEmpresa : AbstractForm
    {
        private DBMapper mapper = new DBMapper();
        private int idEmpresa;
        private IList<TextBox> campos = new List<TextBox>();
        private TipoDeAccion tipoAccion;
        private Empresa empresa;

        public AltaModifEmpresa(TipoDeAccion tipoAccion)
        {
            this.tipoAccion = tipoAccion;
            InitializeComponent();
            CenterToScreen();
        }

        public void ShowDialog(String idEmpresaAModificar)
        {
            this.idEmpresa = Convert.ToInt32(idEmpresaAModificar);
            this.ShowDialog();
        }

        private void limpiarButton_Click(object sender, EventArgs e)
        {
            nombreTextBox.Clear();
            cuitTextBox.Clear();
            direccionTextBox.Clear();
        }

        private void volverButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MenuPrincipal().ShowDialog();
            this.Close();
        }

        public override void guardarInformacion()
        {
            //Completar logica
            String nombre = nombreTextBox.Text;
            String cuit = cuitTextBox.Text;
            String direccion = direccionTextBox.Text;
            String rubro = rubroComboBox.Text;

            //Crear empresa
            #region
            try
            {
                empresa = new Empresa();
                empresa.setNombre(nombre);
                empresa.setCuit(cuit);
                empresa.setDireccion(direccion);
                empresa.setIDRubro(mapper.getIDRubro(rubro));

                tipoAccion.trigger(this);
            }
            catch (CuitYaExisteException)
            {
                Util.ShowMessage("Ya existe una empresa con ese cuit.", MessageBoxIcon.Error);
                return;
            }
            catch (FormatoInvalidoException exception)
            {
                Util.ShowMessage("Datos mal ingresados en: " + exception.Message, MessageBoxIcon.Error);
                return;
            }
            #endregion
        }

        public override void Crear()
        {
            idEmpresa = mapper.CrearEmpresa(empresa);
            if (idEmpresa > 0)
                Util.ShowMessage("Empresa guardada correctamente.", MessageBoxIcon.Information);
        }
        public override void Modificar()
        {
            idEmpresa = mapper.ModificarEmpresa(empresa, idEmpresa);
            if (idEmpresa > 0)
            {
                Util.ShowMessage("Empresa guardada correctamente.", MessageBoxIcon.Information);
                this.Close();
            }
        }
        private void CargarRubros()
        {
            string query = "SELECT id_rubro, descripcion from GAME_OF_CODE.Rubro";

            SqlCommand cmd = new SqlCommand(query, ConnectionManager.Instance.getConnection());

            SqlDataAdapter data_adapter = new SqlDataAdapter(cmd);
            DataTable rubros = new DataTable();
            data_adapter.Fill(rubros);

            rubroComboBox.ValueMember = "id_rubro";
            rubroComboBox.DisplayMember = "descripcion";
            rubroComboBox.DataSource = rubros;
            rubroComboBox.SelectedIndex = 0;
        }
        
        public override void CargarDatos()
        {
            Empresa empresa = mapper.ObtenerEmpresa(idEmpresa);

            nombreTextBox.Text = empresa.getNombre();
            cuitTextBox.Text = empresa.getCuit();
            direccionTextBox.Text = empresa.getDireccion();
            rubroComboBox.Text = mapper.getDescripcionRubro(empresa.getIDRubro());
        }

        private void guardarButton_Click(object sender, EventArgs e)
        {
            if (!Util.CamposEstanLlenos(campos))
            {
                Util.ShowMessage("Todos los campos son obligatorios", MessageBoxIcon.Exclamation);
                return;
            }

            tipoAccion.accion(this);
        }

        private void AltaModifEmpresa_Load(object sender, EventArgs e)
        {
            campos.Add(nombreTextBox);
            campos.Add(cuitTextBox);
            campos.Add(direccionTextBox);

            CargarRubros();
            tipoAccion.cargarDatosSiCorresponde(this);
            tipoAccion.setearTituloVentana(this);
        }

        public override void setearTituloCreacion()
        {
            this.Text = "Alta de empresa";
        }

        public override void setearTituloModificacion()
        {
            this.Text = "Modificación de empresa";
        }
    }
}
