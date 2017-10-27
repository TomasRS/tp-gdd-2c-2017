﻿using PagoAgilFrba.Excepciones;
using PagoAgilFrba.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.DataProvider
{
    class DBMapper
    {
        private String query;
        private IList<SqlParameter> parametros = new List<SqlParameter>();
        private SqlParameter parametroOutput;
        private SqlCommand command;

        //GENERICOS
        public int Crear(Mapeable objeto)
        {
            query = objeto.GetQueryCrear();
            parametros.Clear();
            parametros = objeto.GetParametros();
            parametroOutput = new SqlParameter("@id", SqlDbType.Int);
            parametroOutput.Direction = ParameterDirection.Output;
            parametros.Add(parametroOutput);
            command = QueryBuilder.Instance.build(query, parametros);
            command.CommandType = CommandType.StoredProcedure;
            command.ExecuteNonQuery();
            return (int)parametroOutput.Value;
        }

        public DataTable SelectDataTable(String que, String deDonde, String condiciones)
        {
            return this.SelectDataTableConUsuario(que, deDonde, condiciones);
        }

        public DataTable SelectDataTableConUsuario(String que, String deDonde, String condiciones)
        {
            parametros.Clear();
            parametros.Add(new SqlParameter("@idUsuario", UsuarioSesion.Usuario.id));
            command = QueryBuilder.Instance.build("SELECT " + que + " FROM " + deDonde + " WHERE " + condiciones, parametros);
            command.CommandTimeout = 0;
            DataSet datos = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            adapter.Fill(datos);
            return datos.Tables[0];
        }

        public Mapeable Obtener(Decimal id, Type clase)
        {
            Mapeable objeto = (Mapeable)Activator.CreateInstance(clase);
            query = objeto.GetQueryObtener();
            parametros.Clear();
            parametros.Add(new SqlParameter("@id", id));
            SqlDataReader reader = QueryBuilder.Instance.build(query, parametros).ExecuteReader();
            if (reader.Read())
            {
                objeto.CargarInformacion(reader);
                return objeto;
            }
            return objeto;
        }


        /*
         * 
         *  GET TABLE QUERIES 
         * 
         */
        public Cliente ObtenerCliente(int idCliente)
        {
            Cliente objeto = new Cliente();
            Type clase = objeto.GetType();
            return (Cliente)this.Obtener(idCliente, clase);
        }

        /*
         * 
         *  DELETE QUERIES (deshabilitar)
         *
         */
        public Boolean EliminarCliente(int id, String enDonde)
        {
            query = "UPDATE GAME_OF_CODE." + enDonde + " SET estado_habilitacion = 0 WHERE id_cliente = @id";
            parametros.Clear();
            parametros.Add(new SqlParameter("@id", id));
            int filasAfectadas = QueryBuilder.Instance.build(query, parametros).ExecuteNonQuery();
            return filasAfectadas.Equals(1);
        }
         
        /*
         * 
         *  SELECT TABLE QUERIES 
         *
         */
        public DataTable SelectClientesParaFiltro()
        {
            return this.SelectClientesParaFiltroConFiltro("");
        }

        public DataTable SelectClientesParaFiltroConFiltro(String filtro)
        {
            return this.SelectDataTable("cli.id_cliente, cli.nombre Nombre, cli.apellido Apellido, cli.dni Documento, cli.mail Mail, cli.telefono Teléfono, cli.direccion Dirección, cli.codigo_postal 'Código Postal', cli.cli_fecha_nac 'Fecha de Nacimiento'"
                , "GAME_OF_CODE.Cliente cli"
                , "cli.estado_habilitacion = 1 " + filtro);
        }
        //-------------------------------------------------------------
        /** Clientes **/

        public int CrearCliente(Cliente cliente)
        {

            if (existeCliente(cliente.getMail()))
                throw new ClienteYaExisteException();

            return this.Crear(cliente);
        }

        private Boolean existeCliente(string mail)
        {
            query = "SELECT COUNT(*) FROM GAME_OF_CODE.Cliente WHERE mail = @mail";
            parametros.Clear();
            parametros.Add(new SqlParameter("@mail", mail));
            return ControlDeUnicidad(query, parametros);
        }



        /*
        *
        *   TABLE UNIQUE CONTROL 
        *
        */

        private bool ControlDeUnicidad(String query, IList<SqlParameter> parametros)
        {
            int cantidad = (int)QueryBuilder.Instance.build(query, parametros).ExecuteScalar();
            return cantidad > 0;
        }
    }
}
