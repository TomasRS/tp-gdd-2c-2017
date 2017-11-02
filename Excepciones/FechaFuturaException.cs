using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.Excepciones
{
    class FechaFuturaException : Exception
    {
        public FechaFuturaException(String mensaje)
            : base(mensaje)
        {

        }
    }
}
