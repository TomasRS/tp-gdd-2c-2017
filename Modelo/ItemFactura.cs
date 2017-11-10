using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.Modelo
{
    public class ItemFactura : Mapeable
    {
        private String descripcion;
        private String importe;
        private String cantidad;
        private int idFactura;
        private int idItem;

        public void setDescripcion(String descripcion)  { this.descripcion = descripcion; }
        public void setImporte(String monto)      { this.importe = monto; }
        public void setCantidad(String cantidad)        { this.cantidad = cantidad; }
        public void setIDFactura(int idFactura)         { this.idFactura = idFactura; }

        public String getDescripcion()      { return this.descripcion; }
        public String getMontoUnitario()    { return this.importe; }
        public String getCantidad()         { return this.cantidad; }
        public int getIDFactura()           { return this.idFactura; }
        public int getIDItem()              { return this.idItem; }


        #region Miembros de Comunicable

        string Mapeable.GetQueryCrear()
        {
            return "GAME_OF_CODE.pr_crear_item_factura";
        }

        string Mapeable.GetQueryModificar()
        {
            return "GAME_OF_CODE.pr_modificar_item_factura";
        }

        public string GetQueryObtener()
        {
            return "SELECT * FROM GAME_OF_CODE.Detalle_Factura WHERE id_factura = @id";
        }

        IList<System.Data.SqlClient.SqlParameter> Mapeable.GetParametros()
        {
            IList<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@item_factura", this.descripcion));
            parametros.Add(new SqlParameter("@item_monto", this.importe));
            parametros.Add(new SqlParameter("@cantidad", this.cantidad));
            parametros.Add(new SqlParameter("@id_factura", this.idFactura));
            parametros.Add(new SqlParameter("@id_detalle_factura", this.idItem));
            return parametros;
        }

        public void CargarInformacion(SqlDataReader reader)
        {
            this.descripcion = Convert.ToString(reader["item_factura"]);
            this.importe = Convert.ToString(reader["item_monto"]);
            this.cantidad = Convert.ToString(reader["cantidad"]);
            this.idFactura = Convert.ToInt32(reader["id_factura"]);
            this.idItem = Convert.ToInt32(reader["id_detalle_factura"]);
        }

        #endregion
    }
}
