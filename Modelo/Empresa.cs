using PagoAgilFrba.DataProvider;
using PagoAgilFrba.Excepciones;
using PagoAgilFrba.Utils;
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
        private double porcentajeComision;

        private IList<SqlParameter> parametros = new List<SqlParameter>();
        private DBMapper mapper = new DBMapper();

        //------------------------------------------------------------------
        public void setID(int id)
        { this.id = id; }
        public void setNombre(String nombre)
        { this.nombre = nombre; }
        public void setCuit(String cuit)
        {
            if (Util.EsCuitValido(cuit))
                this.cuit = cuit;
            else
                throw new FormatoInvalidoException("CUIT. El formato válido para CUIT es numérico y con guiones: xx-xxxxxxxx-x ó x-xxxxxxxx-x.");
        }
        public void setDireccion(String direccion)
        { this.direccion = direccion; }
        public void setIDRubro(int idRubro)
        { this.idRubro = idRubro; }
        public void setPorcentajeComision(double porcentajeComision)
        {
            if (Util.EstaEntre0y100(porcentajeComision))
                this.porcentajeComision = porcentajeComision;
            else
                throw new PorcentajeNoValidoException();
        }

        public int getID()                  { return this.id; }
        public String getNombre()           { return this.nombre; }
        public String getCuit()             { return this.cuit; }
        public String getDireccion()        { return this.direccion; }
        public int getIDRubro()             { return this.idRubro; }
        public double getPorcentajeComision()  { return this.porcentajeComision; }



        #region Miembros de Comunicable

        string Mapeable.GetQueryCrear()
        {
            return "GAME_OF_CODE.pr_crear_empresa";
        }

        string Mapeable.GetQueryModificar()
        {
            return "GAME_OF_CODE.pr_modificar_empresa";
        }

        public string GetQueryObtener()
        {
            return "SELECT * FROM GAME_OF_CODE.Empresa WHERE id_empresa = @id";
        }

        IList<System.Data.SqlClient.SqlParameter> Mapeable.GetParametros()
        {
            IList<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@nombre", this.nombre));
            parametros.Add(new SqlParameter("@emp_cuit", this.cuit));
            parametros.Add(new SqlParameter("@emp_direccion", this.direccion));
            parametros.Add(new SqlParameter("@id_rubro", this.idRubro));
            parametros.Add(new SqlParameter("@porcentaje_comision", this.porcentajeComision));
            return parametros;
        }

        public void CargarInformacion(SqlDataReader reader)
        {
            this.nombre = Convert.ToString(reader["nombre"]);
            this.cuit = Convert.ToString(reader["emp_cuit"]);
            this.direccion = Convert.ToString(reader["emp_direccion"]);
            this.idRubro = Convert.ToInt32(reader["id_rubro"]);
            this.activo = Convert.ToBoolean(reader["estado_habilitacion"]);
            this.porcentajeComision = Convert.ToDouble(reader["porcentaje_comision"]);
        }

        #endregion
    }
}
