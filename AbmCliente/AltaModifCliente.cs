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
    public partial class AltaModifCliente : Form
    {
        private IList<SqlParameter> parametros = new List<SqlParameter>();
        private String username;
        private String password;
        private DBMapper mapper = new DBMapper();
        private int idUsuario;
        private int idCliente;
        private IList<TextBox> campos = new List<TextBox>();



        public AltaModifCliente()
        {
            InitializeComponent();
            CenterToScreen();
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
            if (!Util.CamposEstanLlenos(campos))
            {
                Util.ShowMessage("Todos los campos son obligatorios.", MessageBoxIcon.Exclamation);
                return;
            }

            guardarInformacion();
        }

        private void guardarInformacion()
        {
            // Asigno en variables los campos de entrada
            String nombre = nombreTextBox.Text;
            String apellido = apellidoTextBox.Text;
            String dni = dniTextBox.Text;
            DateTime fechaNacimiento;
            DateTime.TryParse(fechaNacDateTimePicker.Text, out fechaNacimiento);
            String mail = mailTextBox.Text;
            String telefono = telefonoTextBox.Text;
            String calle = calleTextBox.Text;
            String numeroCalle = numeroTextBox.Text;
            String numeroPiso = pisoTextBox.Text;
            String departamento = departamentoTextBox.Text;
            String localidad = localidadTextBox.Text;
            String codigoPostal = codPostalTextBox.Text;

            // Crear Cliente
            try
            {
                Cliente cliente = new Cliente();
                cliente.setNombre(nombre);
                cliente.setApellido(apellido);
                cliente.setDNI(dni);
                cliente.setMail(mail);
                cliente.setTelefono(telefono);
                cliente.setDireccion(calle + " " + numeroCalle);
                cliente.setNumeroPiso(numeroPiso);
                cliente.setDepartamento(departamento);
                cliente.setLocalidad(localidad);
                cliente.setCodigoPostal(codigoPostal);
                cliente.setFechaNacimiento(fechaNacimiento);

                idCliente = mapper.CrearCliente(cliente);
                if (idCliente > 0)
                    Util.ShowMessage("Se dio de alta el cliente correctamente.", MessageBoxIcon.Information);
            }
            catch (FormatoInvalidoException exception)
            {
                Util.ShowMessage("Datos mal ingresados en: " + exception.Message, MessageBoxIcon.Error);
                return;
            }
            catch (ClienteYaExisteException)
            {
                Util.ShowMessage("No se puede crear el cliente porque ya existe un cliente con ese mail.", MessageBoxIcon.Error);
                return;
            }
            catch (FechaPasadaException)
            {
                Util.ShowMessage("Fecha no válida. Ingrese una fecha pasada.", MessageBoxIcon.Error);
                return;
            }
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
        }
    }
}
