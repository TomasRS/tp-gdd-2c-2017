using PagoAgilFrba.AbmCliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.Modelo
{
    public class Modificacion : TipoDeAccion
    {
        public void accion(AltaModifCliente form)
        {
            form.guardarModificacion();
        }

        public void cargarDatosSiCorresponde(AltaModifCliente form)
        {
            form.CargarDatos();
        }
    }
}
