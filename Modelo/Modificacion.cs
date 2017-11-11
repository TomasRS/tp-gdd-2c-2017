using PagoAgilFrba.AbmCliente;
using PagoAgilFrba.AbmFactura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.Modelo
{
    public class Modificacion : TipoDeAccion
    {
        public void accion(AbstractForm form)
        {
            form.guardarInformacion();
        }

        public void cargarDatosSiCorresponde(AbstractForm form)
        {
            form.CargarDatos();
        }

        public void trigger(AbstractForm form)
        {
            form.Modificar();
        }

        public void setearTituloVentana(AbstractForm form)
        {
            form.setearTituloModificacion();
        }

        public void agregarItem(AltaModifFactura form)
        {
            form.agregarItemEnModificacion();
        }

        public void borrarSeleccionados(AltaModifFactura form)
        {
            form.borrarItemsEnModificacion();
        }
    }
}
