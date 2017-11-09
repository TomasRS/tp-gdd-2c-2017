using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.Modelo
{
    public class Devolucion : Mapeable
    {
        private String motivo;
        private int id_factura;
        private int id_pago_factura;

        public void setMotivo(String motivo)                { this.motivo = motivo; }
        public void setIDFactura(int idFactura)             { this.id_factura = idFactura; }
        public void setIDPagoFactura(int idPagoFactura)     { this.id_pago_factura = idPagoFactura; }

        public String getMotivo()       { return this.motivo; }
        public int getIDFactura()       { return this.id_factura; }
        public int getIDPagoFactura()   { return this.id_pago_factura; }


        #region Miembros de Comunicable

        string Mapeable.GetQueryCrear()
        {
            return "GAME_OF_CODE.pr_crear_devolucion";
        }

        string Mapeable.GetQueryModificar()
        {
            //No se modifican
            return null;
        }

        public string GetQueryObtener()
        {
            //No se obtienen
            return null;
        }

        IList<System.Data.SqlClient.SqlParameter> Mapeable.GetParametros()
        {
            IList<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@motivo", this.motivo));
            parametros.Add(new SqlParameter("@id_factura", this.id_factura));
            parametros.Add(new SqlParameter("@id_pago_facturas", this.id_pago_factura));
            return parametros;
        }

        public void CargarInformacion(SqlDataReader reader)
        {
            this.motivo = Convert.ToString(reader["motivo"]);
            this.id_factura = Convert.ToInt32(reader["id_factura"]);
            this.id_pago_factura = Convert.ToInt32(reader["id_pago_facturas"]);
        }

        #endregion
    }
}
