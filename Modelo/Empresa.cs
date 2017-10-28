using PagoAgilFrba.DataProvider;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.Modelo
{
    public class Empresa : Mapeable
    {
        private int id;
        private String nombre;
        private String cuit;
        private String direccion;
        private int idRubro;
        private Boolean activo;

        private IList<SqlParameter> parametros = new List<SqlParameter>();
        private DBMapper mapper = new DBMapper();

        //------------------------------------------------------------------
        public void setID(int id)
        { this.id = id; }
        public void setNombre(String nombre)
        { this.nombre = nombre; }
        public void setCuit(String cuit)
        { this.cuit = cuit; }
        public void setDireccion(String direccion)
        { this.direccion = direccion; }
        public void setIDRubro(int idRubro)
        { this.idRubro = idRubro; }

        public int getID()              { return this.id; }
        public String getNombre()       { return this.nombre; }
        public String getCuit()         { return this.cuit; }
        public String getDireccion()    { return this.direccion; }
        public int getIDRubro()         { return this.idRubro; }



        #region Miembros de Comunicable

        string Mapeable.GetQueryCrear()
        {
            return "GAME_OF_CODE.pr_crear_empresa";
        }

        string Mapeable.GetQueryModificar()
        {
            return "UPDATE GAME_OF_CODE.Empresas SET nombre = @nombre, emp_cuit = @emp_cuit, emp_direccion = @emp_direccion, id_rubro = @id_rubro WHERE id_empresa = @id";
        }

        public string GetQueryObtener()
        {
            return "SELECT * FROM GAME_OF_CODE.Empresas WHERE id_empresa = @id";
        }

        IList<System.Data.SqlClient.SqlParameter> Mapeable.GetParametros()
        {
            IList<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@nombre", this.nombre));
            parametros.Add(new SqlParameter("@emp_cuit", this.cuit));
            parametros.Add(new SqlParameter("@emp_direccion", this.direccion));
            parametros.Add(new SqlParameter("@id_rubro", this.idRubro));
            return parametros;
        }

        public void CargarInformacion(SqlDataReader reader)
        {
            this.nombre = Convert.ToString(reader["nombre"]);
            this.cuit = Convert.ToString(reader["emp_cuit"]);
            this.direccion = Convert.ToString(reader["emp_direccion"]);
            this.idRubro = Convert.ToInt32(reader["id_rubro"]);
            this.activo = Convert.ToBoolean(reader["estado_habilitacion"]);
        }

        #endregion
    }
}
