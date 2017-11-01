using PagoAgilFrba.Menu_Principal;
using PagoAgilFrba.Modelo;
using PagoAgilFrba.DataProvider;
using PagoAgilFrba.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PagoAgilFrba.AbmSucursal
{
    public partial class AltaModifSucursal : AbstractForm
    {
        //private DBMapper mapper = new DBMapper();
        //private int idSucursal;
        //private IList<TextBox> campos = new List<TextBox>();
        //private TipoDeAccion tipoAccion;
        //private Sucursal sucursal;

        //public AltaModifSucursal(TipoDeAccion tipoAccion)
        //{
        //    this.tipoAccion = tipoAccion;
        //    InitializeComponent();
        //    CenterToScreen();
        //}

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
            //String nombre = nombreTextBox.Text;
            //String direccion = direccionTextBox.Text;
            //String codPostal = codPostalTextBox.Text;
        }

        public override void Crear()
        {
            //idSucursal = mapper.CrearSucursal(sucursal);
            //if (idSucursal > 0)
            //    Util.ShowMessage("Sucursal guardada correctamente.", MessageBoxIcon.Information);
        }

        public override void Modificar()
        {
            throw new NotImplementedException();
        }

        public override void setearTituloCreacion()
        {
            this.Text = "Alta de sucursales";
        }

        public override void setearTituloModificacion()
        {
            this.Text = "Modificación de sucursales";
        }

        public override void CargarDatos()
        {
            //Este metodo es para cuando le das click en modificar en el listado, que te cargue los datos en la pantalla (ver el CargarDatos de otros ABM)
            throw new NotImplementedException();
        }


    }
}
