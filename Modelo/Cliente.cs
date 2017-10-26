using PagoAgilFrba.Excepciones;
using PagoAgilFrba.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.Modelo
{
    class Cliente
    {
        private int id;
        private String nombre;
        private String apellido;
        private String dni;
        private DateTime fechaNacimiento;
        private String mail;
        private String telefono;
        private String calle;
        private String numero;
        private String nroPiso;
        private String departamento;
        private String localidad;
        private String codigoPostal;

        public void setNombre(string nombre)
        { this.nombre = nombre; }
        public void setApellido(string apellido)
        { this.apellido = apellido; }
        public void setDNI(string dni)
        {
            if (Util.EsNumero(dni))
                this.dni = dni;
            else
                throw new FormatoInvalidoException("DNI. Ingrese todos los números seguidos.");
        }
        public void setFechaNacimiento(DateTime fechaNac)
        {
            if (!Util.EsFechaPasada(fechaNac))
                this.fechaNacimiento = fechaNac;
            else
                throw new FechaPasadaException();
        }
        public void setMail(string mail)
        { this.mail = mail; }
        public void setTelefono(string telefono)
        { this.telefono = telefono; }
        public void setCalle(string calle)
        { this.calle = calle; }
        public void setNumero(string numero)
        { this.numero = numero; }
        public void setNumeroPiso(string nroPiso)
        { this.nroPiso = nroPiso; }
        public void setDepartamento(string departamento)
        { this.departamento = departamento; }
        public void setLocalidad(string localidad)
        { this.localidad = localidad; }
        public void setCodigoPostal(string codPostal)
        { this.codigoPostal = codPostal; }

        public String getNombre()                           { return this.nombre; }
        public String getApellido()                         { return this.apellido; }
        public String getDNI()                              { return this.dni; }
        public DateTime getFechaNacimiento()                { return this.fechaNacimiento; }
        public String getMail()                             { return this.mail; }
        public String getTelefono()                         { return this.telefono; }
        public String getCalle()                            { return this.calle; }
        public String getNumero()                           { return this.numero; }
        public String getNumeroPiso()                       { return this.nroPiso; }
        public String getDepartamento()                     { return this.departamento; }
        public String getLocalidad()                        { return this.localidad; }
        public String getCodigoPostal()                     { return this.codigoPostal; }


        //Agregar miembros de Comunicable (las queries para crear, modificar, obtener, etc)
    }
}
