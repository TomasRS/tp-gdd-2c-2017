using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.Modelo
{
    #if DEBUG
        public class AbstractForm : Form
        {
    #else
        public abstract class AbstractForm : Form
        {
    #endif

        #if DEBUG
            public virtual void guardarInformacion()
            {
                throw new NotImplementedException();
            }
            public virtual void Crear()
            {
                throw new NotImplementedException();
            }
            public virtual void Modificar()
            {
                throw new NotImplementedException();
            }
            public virtual void CargarDatos()
            {
                throw new NotImplementedException();
            }
            public virtual void setearTituloCreacion()
            { throw new NotImplementedException(); }
            public virtual void setearTituloModificacion()
            { throw new NotImplementedException(); }
        #else
            public abstract void guardarInformacion();
            public abstract void Crear();
            public abstract void Modificar();
            public abstract void CargarDatos();
            public abstract void setearTituloCreacion();
            public abstract void setearTituloModificacion();
        #endif

        }
}
