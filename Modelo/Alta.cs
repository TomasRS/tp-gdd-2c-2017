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
        public void accion(AltaModifCliente form)
        {
            form.darDeAltaCliente();
        }

        public void cargarDatosSiCorresponde(AltaModifCliente form)
        {

        }
    }
}
