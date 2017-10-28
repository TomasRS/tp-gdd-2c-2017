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

namespace PagoAgilFrba.AbmCliente
{
    public partial class AltaModifCliente : AbstractForm
    {
        private IList<SqlParameter> parametros = new List<SqlParameter>();
        private String username;
        private String password;
        private DBMapper mapper = new DBMapper();
        private int idUsuario;
        private int idCliente;
        private IList<TextBox> campos = new List<TextBox>();
        private TipoDeAccion tipoAccion;


        public AltaModifCliente(TipoDeAccion tipoAccion)
        {
            this.tipoAccion = tipoAccion;
            InitializeComponent();
            CenterToScreen();
        }

        public void ShowDialog(String idClienteAModificar)
        {
            this.idCliente = Convert.ToInt32(idClienteAModificar);
            this.ShowDialog();
        }

        private void limpiarButton_Click(object sender, EventArgs e)
        {
            nombreTextBox.Clear();
            apellidoTextBox.Clear();
            dniTextBox.Clear();
            fechaNacDateTimePicker.Text = "";
            mailTextBox.Clear();
            telefonoTextBox.Clear();
            calleTextBox.Clear();
            numeroTextBox.Clear();
            pisoTextBox.Clear();
            departamentoTextBox.Clear();
            localidadTextBox.Clear();
            codPostalTextBox.Clear();
        }

        private void volverButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MenuPrincipal().ShowDialog();
            this.Close();
        }

        private void guardarButton_Click(object sender, EventArgs e)
        {
            tipoAccion.accion(this);
        }

        public override void darDeAlta()
        {
            if (!Util.CamposEstanLlenos(campos))
            {
                Util.ShowMessage("Todos los campos son obligatorios.", MessageBoxIcon.Exclamation);
                return;
            }

            guardarInformacion("crear");
        }
        public override void guardarModificacion()
        {
            if (!Util.CamposEstanLlenos(campos))
            {
                Util.ShowMessage("Todos los campos son obligatorios.", MessageBoxIcon.Exclamation);
                return;
            }

            guardarInformacion("modificar");
        }

        private void guardarInformacion(string accion)
        {
            // Asigno en variables los campos de entrada
            String nombre = nombreTextBox.Text;
            String apellido = apellidoTextBox.Text;
            String dni = dniTextBox.Text;
            DateTime fechaNacimiento;
            DateTime.TryParse(fechaNacDateTimePicker.Text, out fechaNacimiento);
            String mail = mailTextBox.Text;
            String telefono = telefonoTextBox.Text;
            String direccionCompleta;
            String calle = calleTextBox.Text;
            String numeroCalle = numeroTextBox.Text;
            String numeroPiso = pisoTextBox.Text;
            String departamento = departamentoTextBox.Text;
            String localidad = localidadTextBox.Text;
            String codigoPostal = codPostalTextBox.Text;

            if (!Util.EsNombreValido(nombre) || !Util.EsNombreValido(apellido))
            {
                Util.ShowMessage("Los campos nombre y apellido deben ser alfabéticos.", MessageBoxIcon.Exclamation);
                return;
            }
            if (calle.Equals("-") || numeroCalle.Equals("-"))
            {
                Util.ShowMessage("Los campos calle y número de calle tienen que tener valores", MessageBoxIcon.Exclamation);
                return;
            }
            if (localidad.Equals("-"))
            {
                Util.ShowMessage("La localidad no puede estar vacía.", MessageBoxIcon.Exclamation);
                return;
            }
            if (!Util.EsEmailValido(mail))
            {
                Util.ShowMessage("El email tiene un formato no válido.", MessageBoxIcon.Exclamation);
                return;
            }

            // Crear Cliente
            #region
            try
            {
                Cliente cliente = new Cliente();
                cliente.setNombre(nombre);
                cliente.setApellido(apellido);
                cliente.setDNI(dni);
                cliente.setMail(mail);
                cliente.setTelefono(telefono);
                direccionCompleta = generarDireccionCompleta(calle, numeroCalle, numeroPiso, departamento, localidad);
                cliente.setDireccion(direccionCompleta);
                cliente.setCodigoPostal(codigoPostal);
                cliente.setFechaNacimiento(fechaNacimiento);

                if (accion.Equals("crear"))
                    idCliente = mapper.CrearCliente(cliente);
                else if (accion.Equals("modificar"))
                    idCliente = mapper.ModificarCliente(cliente, idCliente);

                if (idCliente > 0)
                    Util.ShowMessage("Cliente guardado correctamente.", MessageBoxIcon.Information);

                if (accion.Equals("modificar"))
                    this.Close();
            }
            catch (FormatoInvalidoException exception)
            {
                Util.ShowMessage("Datos mal ingresados en: " + exception.Message, MessageBoxIcon.Error);
                return;
            }
            catch (ClienteYaExisteException)
            {
                Util.ShowMessage("No se puede guardar el cliente porque ya existe un cliente con ese mail.", MessageBoxIcon.Error);
                return;
            }
            catch (FechaPasadaException)
            {
                Util.ShowMessage("Fecha no válida. Ingrese una fecha pasada.", MessageBoxIcon.Error);
                return;
            }
            #endregion
        }

        private String generarDireccionCompleta(string calle, string nroCalle, string nroPiso, string departamento, string localidad)
        {
            validarTiposDeDatos(calle, nroCalle, nroPiso, localidad);
            if (!esGuion(nroPiso))
                nroPiso = ", Piso " + nroPiso;
            else
                nroPiso = "";

            if (!esGuion(departamento))
                departamento = ", Dpto " + departamento;
            else
                departamento = "";

            return calle + " " + nroCalle + nroPiso + departamento + ", " + localidad;
        }

        private void validarTiposDeDatos(string calle, string nroCalle, string nroPiso, string localidad)
        {
            if(Util.EsNumero(calle))
                throw new FormatoInvalidoException("calle. Deben ser solo letras.");
            if (!Util.EsNumero(nroCalle))
                throw new FormatoInvalidoException("número de calle. Debe ser numérico y sin espacios.");
            if(!Util.EsNumero(nroPiso) && !esGuion(nroPiso))
                throw new FormatoInvalidoException("número de piso. Debe ser numérico y sin espacios.");
            if (Util.EsNumero(localidad))
                throw new FormatoInvalidoException("localidad. No pueden ser únicamente números.");
        }

        private Boolean esGuion(string valor)
        {
            return valor.Equals("-");
        }

        private void AltaModifCliente_Load(object sender, EventArgs e)
        {
            campos.Add(nombreTextBox);
            campos.Add(apellidoTextBox);
            campos.Add(dniTextBox);
            campos.Add(mailTextBox);
            campos.Add(telefonoTextBox);
            campos.Add(calleTextBox);
            campos.Add(numeroTextBox);
            campos.Add(pisoTextBox);
            campos.Add(departamentoTextBox);
            campos.Add(localidadTextBox);
            campos.Add(codPostalTextBox);

            tipoAccion.cargarDatosSiCorresponde(this);
        }

        public override void CargarDatos()
        {
            Cliente cliente = mapper.ObtenerCliente(idCliente);

            nombreTextBox.Text = cliente.getNombre();
            apellidoTextBox.Text = cliente.getApellido();
            dniTextBox.Text = cliente.getDNI();
            fechaNacDateTimePicker.Text = Convert.ToString(cliente.getFechaNacimiento());
            mailTextBox.Text = cliente.getMail();
            telefonoTextBox.Text = cliente.getTelefono();
            cliente.splitearDireccion();
            calleTextBox.Text = cliente.getCalle();
            numeroTextBox.Text = cliente.getNumero();
            pisoTextBox.Text = cliente.getNumeroPiso();
            departamentoTextBox.Text = cliente.getDepartamento();
            localidadTextBox.Text = cliente.getLocalidad();
            codPostalTextBox.Text = cliente.getCodigoPostal();
        }
    }
}
