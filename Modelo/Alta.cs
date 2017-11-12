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
    public class Alta : TipoDeAccion
    {
        public void accion(AbstractForm form)
        {
            form.guardarInformacion();
        }

        public void cargarDatosSiCorresponde(AbstractForm form)
        {
            //No se implementa
        }

        public void trigger(AbstractForm form)
        {
            form.Crear();
        }

        public void setearTituloVentana(AbstractForm form)
        {
            form.setearTituloCreacion();
        }

        public void agregarItem(AltaModifFactura form)
        {
            form.agregarItemEnCreacion();
        }

        public void borrarSeleccionados(AltaModifFactura form)
        {
            form.borrarItemsEnCreacion();
        }

        public double calcularMontoTotalFactura(AltaModifFactura form)
        {
            return form.calcularMontoTotalEnCreacion();
        }

        public List<ItemFactura> armarListaDeItems(AltaModifFactura form)
        {
            return form.armarListaItemsFacturaEnCreacion();
        }

        public void mostrarMensajeDNI(AltaModifCliente form)
        {
            form.mostrarMensajeDNIExistente();
        }
    }
}
