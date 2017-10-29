using PagoAgilFrba.AbmCliente;
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
    }
}
