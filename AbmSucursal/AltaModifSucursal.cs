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

namespace PagoAgilFrba.AbmSucursal
{
    public partial class AltaModifSucursal : AbstractForm
    {
        private DBMapper mapper = new DBMapper();
        private int idSucursal;
        private IList<TextBox> campos = new List<TextBox>();
        private TipoDeAccion tipoAccion;
        private Sucursal sucursal;

         public AltaModifSucursal(TipoDeAccion tipoAccion)
        {
            this.tipoAccion = tipoAccion;
            InitializeComponent();
            CenterToScreen();
        }

         public void ShowDialog(String idSucursalAModificar)
         {
             this.idSucursal = Convert.ToInt32(idSucursalAModificar);
             this.ShowDialog();
         }
         
        private void limpiarButton_Click(object sender, EventArgs e)
        {
            nombreTextBox.Clear();
            direccionTextBox.Clear();
            codPostalTextBox.Clear();
        }

        private void volverButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MenuPrincipal().ShowDialog();
            this.Close();
        }

        public override void guardarInformacion()
        {
            String nombre = nombreTextBox.Text;
            String direccion = direccionTextBox.Text;
            String codPostal = codPostalTextBox.Text;

            //Crear Sucursal
            #region
            try
            {
                sucursal = new Sucursal();
                sucursal.setNombre(nombre);
                sucursal.setDireccion(direccion);
                sucursal.setCodPostal(codPostal);

                tipoAccion.trigger(this);
            }
            catch (CodigoPostalYaExisteException)
            {
                Util.ShowMessage("Ya existe una sucursal con ese código postal.", MessageBoxIcon.Error);
                return;
            }
            catch (FormatoInvalidoException exception)
            {
                Util.ShowMessage("Dato mal ingresado en:" + exception.Message, MessageBoxIcon.Error);
                return;
            }
            #endregion
        }

        public override void Crear()
        {
            idSucursal = mapper.CrearSucursal(sucursal);
            if (idSucursal > 0)
                Util.ShowMessage("Sucursal guardada correctamente.", MessageBoxIcon.Information);
        }

        public override void Modificar()
        {
            idSucursal = mapper.ModificarSucursal(sucursal, idSucursal);
            if (idSucursal > 0)
            {
                Util.ShowMessage("Sucursal guardada correctamente.", MessageBoxIcon.Information);
            }
        }

        public override void CargarDatos()
        {
            Sucursal sucursal = mapper.ObtenerSucursal(idSucursal);

            nombreTextBox.Text = sucursal.getNombre();
            direccionTextBox.Text = sucursal.getDireccion();
            codPostalTextBox.Text = sucursal.getCodPostal(); 
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

        private void AltaModifSucursal_Load(object sender, EventArgs e)
        {
            campos.Add(nombreTextBox);
            campos.Add(direccionTextBox);
            campos.Add(codPostalTextBox);

            tipoAccion.cargarDatosSiCorresponde(this);
            tipoAccion.setearTituloVentana(this);
        }

        public override void setearTituloCreacion()
        {
            this.Text = "Alta de sucursales";
        }

        public override void setearTituloModificacion()
        {
            this.Text = "Modificación de sucursales";
        }

    }
}
