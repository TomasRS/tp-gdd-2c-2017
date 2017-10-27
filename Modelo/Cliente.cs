﻿using PagoAgilFrba.Excepciones;
using PagoAgilFrba.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.Modelo
{
    class Cliente : Mapeable
    {
        private int id;
        private String nombre;
        private String apellido;
        private String dni;
        private DateTime fechaNacimiento;
        private String mail;
        private String telefono;
        private String direccionCompleta;
        private String calle;
        private String numero;
        private String nroPiso;
        private String departamento;
        private String localidad;
        private String codigoPostal;
        private Boolean activo;

        public void setNombre(string nombre)
        { this.nombre = nombre; }
        public void setApellido(string apellido)
        { this.apellido = apellido; }
        public void setDNI(string dni)
        {
            if (Util.EsNumero(dni))
                this.dni = dni;
            else
                throw new FormatoInvalidoException("DNI. El formato debe ser numérico y sin espacios.");
        }
        public void setFechaNacimiento(DateTime fechaNac)
        {
            if (Util.EsFechaPasada(fechaNac))
                this.fechaNacimiento = fechaNac;
            else
                throw new FechaPasadaException();
        }
        public void setMail(string mail)
        { this.mail = mail; }
        public void setTelefono(string telefono)
        {
            if (Util.EsNumero(telefono))
                this.telefono = telefono;
            else
                throw new FormatoInvalidoException("teléfono. El formato debe ser numérico y sin espacios.");
        
        }
        public void setDireccion(string direccion)
        {
             this.direccionCompleta = direccion;
        }
        public void setCodigoPostal(string codPostal)
        {
            if(Util.EsNumero(codPostal))
                this.codigoPostal = codPostal;
            else
                throw new FormatoInvalidoException("código postal. El formato debe ser numérico y sin espacios.");
        }

        public String getNombre()                           { return this.nombre; }
        public String getApellido()                         { return this.apellido; }
        public String getDNI()                              { return this.dni; }
        public DateTime getFechaNacimiento()                { return this.fechaNacimiento; }
        public String getMail()                             { return this.mail; }
        public String getTelefono()                         { return this.telefono; }
        public String getDireccion()                        { return this.direccionCompleta; }
        public String getCalle()                            { return this.calle; }
        public String getNumero()                           { return this.numero; }
        public String getNumeroPiso()                       { return this.nroPiso; }
        public String getDepartamento()                     { return this.departamento; }
        public String getLocalidad()                        { return this.localidad; }
        public String getCodigoPostal()                     { return this.codigoPostal; }

        public void splitearDireccion()
        {
            String direccion = getDireccion();
            List<string> valores = direccion.Split(',').ToList();

            //Asigno primero la calle y numero, que siempre van a estar, y las elimino de la lista
            this.calle = valores.First().Split(' ').First();
            this.numero = valores.First().Split(' ').Last();
            valores.RemoveAt(0);

            valores.ForEach(valor => setearAtributoCorrespondiente(valor));
        }

        public void setearAtributoCorrespondiente(string valor)
        {
            if (valor.StartsWith(" Piso"))
                this.nroPiso = valor.Split(' ').Last();
            else if (valor.StartsWith(" Dpto"))
                this.departamento = valor.Split(' ').Last();
            else
                this.localidad = valor.Replace(" ", "");
        }


        #region Miembros de Comunicable

        string Mapeable.GetQueryCrear()
        {
            return "GAME_OF_CODE.pr_crear_cliente";
        }

        //Falta terminar el modificar
        string Mapeable.GetQueryModificar()
        {
            if (activo)
                return "UPDATE GAME_OF_CODE.Cliente SET nombre = @nombre, apellido = @apellido, dni = @dni, cli_fecha_nac = @fecha_nacimiento, cli_activo = @activo WHERE cli_id = @id ";
            else
                return "UPDATE GAME_OF_CODE.Clientes SET nombre = @nombre, apellido = @apellido, dni = @dni, cli_fecha_nac = @fecha_nacimiento, cli_activo = @activo WHERE cli_id = @id";


        }

        //Falta terminar el obtener
        string Mapeable.GetQueryObtener()
        {
            return "SELECT * FROM GAME_OF_CODE.Cliente WHERE id_cliente = @id";
        }

        IList<System.Data.SqlClient.SqlParameter> Mapeable.GetParametros()
        {
            IList<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Clear();
            parametros.Add(new SqlParameter("@nombre", this.nombre));
            parametros.Add(new SqlParameter("@apellido", this.apellido));
            parametros.Add(new SqlParameter("@dni", this.dni));
            parametros.Add(new SqlParameter("@mail", this.mail));
            parametros.Add(new SqlParameter("@telefono", this.telefono));
            parametros.Add(new SqlParameter("@direccion", this.direccionCompleta));
            parametros.Add(new SqlParameter("@codigo_postal", this.codigoPostal));
            parametros.Add(new SqlParameter("@cli_fecha_nac", this.fechaNacimiento));
            return parametros;
        }

        void Mapeable.CargarInformacion(SqlDataReader reader)
        {
            this.id = Convert.ToInt32(reader["id_cliente"]);
            this.nombre = Convert.ToString(reader["nombre"]);
            this.apellido = Convert.ToString(reader["apellido"]);
            this.dni = Convert.ToString(reader["dni"]);
            this.fechaNacimiento = Convert.ToDateTime(reader["cli_fecha_nac"]);
            this.mail = Convert.ToString(reader["mail"]);
            this.telefono = Convert.ToString(reader["telefono"]);
            this.direccionCompleta = Convert.ToString(reader["direccion"]);
            this.codigoPostal = Convert.ToString(reader["codigo_postal"]);
        }

        #endregion
    }
}
