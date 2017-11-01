using PagoAgilFrba.DataProvider;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.Modelo
{
    public class Rol : Mapeable
    {
        private String nombre;
        private IList<SqlParameter> parametros = new List<SqlParameter>();
        private DBMapper mapper = new DBMapper();
        private Boolean activo;

        public void setNombre(String nombre)  { this.nombre = nombre; }
        public String getNombre()               { return this.nombre; }

        #region Miembros de Comunicable

        string Mapeable.GetQueryCrear()
        {
            //No lo usamos
            return null;
        }

        string Mapeable.GetQueryModificar()
        {
            //No lo usamos
            return null;
        }

        public string GetQueryObtener()
        {
            return "SELECT * FROM GAME_OF_CODE.Rol WHERE id_rol = @id";
        }

        IList<System.Data.SqlClient.SqlParameter> Mapeable.GetParametros()
        {
            IList<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@nombre", this.nombre));
            return parametros;
        }

        public void CargarInformacion(SqlDataReader reader)
        {
            this.nombre = Convert.ToString(reader["nombre"]);
            this.activo = Convert.ToBoolean(reader["estado_habilitacion"]);
        }

        #endregion
    }
}
