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
    public class Sucursal : Mapeable
    {
        private int id;
        private String nombre;
        private String direccion;
        private String codPostal;
        private Boolean activo;

        private IList<SqlParameter> parametros = new List<SqlParameter>();
        private DBMapper mapper = new DBMapper();

        //----------------------------------------------------------------
        public void setID(int id)
        { this.id = id; }
        public void setNombre(String nombre)
        { this.nombre = nombre; }
        public void setDireccion(String direccion)
        { this.direccion = direccion; }
        public void setCodPostal(String codPostal)
        {
            if (Util.EsNumero(codPostal))
                this.codPostal = codPostal;
            else
                throw new FormatoInvalidoException("Código Postal. El formato debe ser númerico y sin espacios.");
        }

        public int getID() { return this.id; }
        public String getNombre() { return this.nombre; }
        public String getDireccion() { return this.direccion; }
        public String getCodPostal() { return this.codPostal; }



        #region Miembros de Comunicable

        string Mapeable.GetQueryCrear()
        {
            return "GAME_OF_CODE.pr_crear_sucursal";
        }

        string Mapeable.GetQueryModificar()
        {
            return "GAME_OF_CODE.pr_modificar_sucursal";
        }

        public string GetQueryObtener()
        {
            return "SELECT * FROM GAME_OF_CODE.Sucursal WHERE id_sucursal = @id";
        }

        IList<System.Data.SqlClient.SqlParameter> Mapeable.GetParametros()
        {
            IList<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@nombre", this.nombre));
            parametros.Add(new SqlParameter("@direccion", this.direccion));
            parametros.Add(new SqlParameter("@codigo_postal", this.codPostal));
            return parametros;
        }

        public void CargarInformacion(SqlDataReader reader)
        {
            this.nombre = Convert.ToString(reader["nombre"]);
            this.direccion = Convert.ToString(reader["direccion"]);
            this.codPostal = Convert.ToString(reader["codigo_postal"]);
        }

        #endregion
    }
}
