using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.Modelo
{
    public class Rendicion : Mapeable
    {
        private DateTime fechaRendicion;
        private int totalRendicion;
        private int porcentajeComision;
        private double importeComision;
        private int cantFacturasRendidas;

        public void setFechaRendicion(DateTime unaFecha)    { this.fechaRendicion = unaFecha; }
        public void setTotalRendicion(int unTotal)          { this.totalRendicion = unTotal; }
        public void setPorcentajeComision(int porc)         { this.porcentajeComision = porc; }
        public void setImporteComision(double importe)      { this.importeComision = importe; }
        public void setCantFacturasRendidas(int cant)       { this.cantFacturasRendidas = cant; }

        public DateTime getFechaRendicion()     { return this.fechaRendicion; }
        public int getTotalRendicion()          { return this.totalRendicion; }
        public int getPorcentajeComision()      { return this.porcentajeComision; }
        public double getImporteComision()      { return this.importeComision; }
        public int getCantFactRendidas()        { return this.cantFacturasRendidas; }



        #region Miembros de Comunicable

        string Mapeable.GetQueryCrear()
        {
            return "GAME_OF_CODE.pr_crear_rendicion";
        }

        string Mapeable.GetQueryModificar()
        {
            //No se usa
            return null;
        }

        public string GetQueryObtener()
        {
            //No se usa
            return null;
        }

        IList<System.Data.SqlClient.SqlParameter> Mapeable.GetParametros()
        {
            IList<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@fecha_rendicion", this.fechaRendicion));
            parametros.Add(new SqlParameter("@total_rendicion", this.totalRendicion));
            parametros.Add(new SqlParameter("@porcentaje_comision", this.porcentajeComision));
            parametros.Add(new SqlParameter("@importe_comision", this.importeComision));
            parametros.Add(new SqlParameter("@cant_facturas_rendidas", this.cantFacturasRendidas));
            return parametros;
        }

        public void CargarInformacion(SqlDataReader reader)
        {
            this.fechaRendicion = Convert.ToDateTime(reader["fecha_rendicion"]);
            this.totalRendicion = Convert.ToInt32(reader["total_rendicion"]);
            this.porcentajeComision = Convert.ToInt32(reader["porcentaje_comision"]);
            this.importeComision = Convert.ToInt32(reader["importe_comision"]);
            this.cantFacturasRendidas = Convert.ToInt32(reader["cant_facturas_rendidas"]);
        }

        #endregion
    }
}
