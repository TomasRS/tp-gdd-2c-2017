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
    public class Factura : Mapeable
    {
        private int id;
        private int idCliente;
        private int idEmpresa;
        private String numeroFactura;
        private DateTime fechaAltaFactura;
        private DateTime fechaVencimientoFactura;
        private Boolean activo;
        private int montoTotal;
        //private List<ItemFactura> itemsFactura;

        private IList<SqlParameter> parametros = new List<SqlParameter>();
        private DBMapper mapper = new DBMapper();

        //--------------------Setters---------------------
        public void setID(int id) { this.id = id; }
        public void setCliente(int idCliente) { this.idCliente = idCliente; }
        public void setEmpresa(int idEmpresa) { this.idEmpresa = idEmpresa; }
        public void setNumeroFactura(String numeroFactura)
        {
            if (Util.EsNumero(numeroFactura))
                this.numeroFactura = numeroFactura;
            else
                throw new FormatoInvalidoException("número de factura. Debe ser numérico.");
        }
        public void setFechaAltaFactura(DateTime fechaAlta)
        {
            if (Util.EsFechaPasada(fechaAlta))
                this.fechaAltaFactura = fechaAlta;
            else
                throw new FechaPasadaException();
        }
        public void setFechaVencimientoFactura(DateTime fechaVenc)
        {
            if (Util.EsFechaVencimientoValida(fechaVenc))
                this.fechaVencimientoFactura = fechaVenc;
            else
                throw new FechaFuturaException("La fecha de vencimiento debe ser una fecha futura.");
        }
        public void setActivo(Boolean activo) { this.activo = activo; }

        //--------------------Getters---------------------
        public int getID() { return this.id; }
        public int getIDCliente() { return this.idCliente; }
        public int getIDEmpresa() { return this.idEmpresa; }
        public String getNumFactura() { return this.numeroFactura; }
        public DateTime getFechaAlta() { return this.fechaAltaFactura; }
        public DateTime getFechaVenc() { return this.fechaVencimientoFactura; }
        public Boolean getActivo() { return this.activo; }




        //------------------------------------------------
        #region Miembros de Comunicable

        string Mapeable.GetQueryCrear()
        {
            return "GAME_OF_CODE.pr_crear_factura";
        }

        string Mapeable.GetQueryModificar()
        {
            return "GAME_OF_CODE.pr_modificar_factura";
        }

        public string GetQueryObtener()
        {
            return "SELECT * FROM GAME_OF_CODE.Factura WHERE id_factura = @id";
        }

        IList<System.Data.SqlClient.SqlParameter> Mapeable.GetParametros()
        {
            IList<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@numero_factura", this.numeroFactura));
            parametros.Add(new SqlParameter("@fecha_alta", this.fechaAltaFactura));
            parametros.Add(new SqlParameter("@monto_total", this.montoTotal));
            parametros.Add(new SqlParameter("@fecha_vencimiento", this.fechaVencimientoFactura));
            parametros.Add(new SqlParameter("@id_cliente", this.idCliente));
            parametros.Add(new SqlParameter("@id_empresa", this.idEmpresa));
            return parametros;
        }

        public void CargarInformacion(SqlDataReader reader)
        {
            this.numeroFactura = Convert.ToString(reader["numero_factura"]);
            this.fechaAltaFactura = Convert.ToDateTime(reader["fecha_alta"]);
            this.montoTotal = Convert.ToInt32(reader["monto_total"]);
            this.fechaVencimientoFactura = Convert.ToDateTime(reader["fecha_vencimiento"]);
            this.idCliente = Convert.ToInt32(reader["id_cliente"]);
            this.idEmpresa = Convert.ToInt32(reader["id_empresa"]);
            this.activo = Convert.ToBoolean(reader["estado_habilitacion"]);
        }

        #endregion
    }
}
