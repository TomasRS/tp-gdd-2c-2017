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
            public virtual void darDeAlta()
            {
                throw new NotImplementedException();
            }
            public virtual void guardarModificacion()
            {
                throw new NotImplementedException();
            }
            public virtual void CargarDatos()
            {
                throw new NotImplementedException();
            }
        #else
            public abstract void darDeAlta();
            public abstract void guardarModificacion();
            public abstract void CargarDatos();
        #endif

        }
}
