using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.Modelo
{
    public class PagoFactura : Mapeable
    {
        private DateTime fechaCobro;
        private double importe;
        private int idSucursal;
        private int idMedioPago;
        private List<Factura> facturasAPagar = new List<Factura>();


        public void setFechaCobro(DateTime fechaCobro)      { this.fechaCobro = fechaCobro; }
        public void setImporte(double importe) { this.importe = importe; }
        public void setIDSucursal(int idSucursal)           { this.idSucursal = idSucursal; }
        public void setIDMedioPago(int idMedioPago)         { this.idMedioPago = idMedioPago; }
        public void agregarFactura(Factura unaFactura)
        {
            facturasAPagar.Add(unaFactura);
        }

        public DateTime getFechaCobro()                     { return this.fechaCobro; }
        public double getImporte() { return this.importe; }
        public int getIDSucursal()                          { return this.idSucursal; }
        public int getIDMedioPago()                         { return this.idMedioPago; }
        public List<Factura> getFacturasAPagar()            { return this.facturasAPagar; }



        #region Miembros de Comunicable

        string Mapeable.GetQueryCrear()
        {
            return "GAME_OF_CODE.pr_crear_pago_factura";
        }

        string Mapeable.GetQueryModificar()
        {
            //No se va a usar esta
            return null;
        }

        public string GetQueryObtener()
        {
            //No se va a usar esta
            return null;
        }

        IList<System.Data.SqlClient.SqlParameter> Mapeable.GetParametros()
        {
            IList<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@fecha_cobro", this.fechaCobro));
            parametros.Add(new SqlParameter("@importe", this.importe));
            parametros.Add(new SqlParameter("@id_sucursal", this.idSucursal));
            parametros.Add(new SqlParameter("@id_medio_pago", this.idMedioPago));
            return parametros;
        }

        public void CargarInformacion(SqlDataReader reader)
        {
            //Por ahora no lo usamos
            this.fechaCobro = Convert.ToDateTime(reader["fecha_cobro"]);
            this.importe = Convert.ToDouble(reader["importe"]);
            this.idSucursal = Convert.ToInt32(reader["id_sucursal"]);
            this.idMedioPago = Convert.ToInt32(reader["id_medio_pago"]);
        }
        #endregion
        
    }
}
