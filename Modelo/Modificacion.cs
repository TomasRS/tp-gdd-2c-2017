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
        public void accion(AbstractForm form)
        {
            form.guardarModificacion();
        }

        public void cargarDatosSiCorresponde(AbstractForm form)
        {
            form.CargarDatos();
        }
    }
}
