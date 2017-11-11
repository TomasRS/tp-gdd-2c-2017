using PagoAgilFrba.AbmCliente;
using PagoAgilFrba.AbmFactura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.Modelo
{
    public interface TipoDeAccion
    {
        void accion(AbstractForm form);
        void cargarDatosSiCorresponde(AbstractForm form);
        void trigger(AbstractForm form);
        void setearTituloVentana(AbstractForm form);
        void agregarItem(AltaModifFactura form);
        void borrarSeleccionados(AltaModifFactura form);
        int calcularMontoTotalFactura(AltaModifFactura form);
    }
}
