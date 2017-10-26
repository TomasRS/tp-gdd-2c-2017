using PagoAgilFrba.Excepciones;
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
