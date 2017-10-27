using PagoAgilFrba.AbmCliente;
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
        void accion(AltaModifCliente form);
        void cargarDatosSiCorresponde(AltaModifCliente form);
    }
}
