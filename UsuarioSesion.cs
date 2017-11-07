using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba
{
    class UsuarioSesion
    {
        public static UsuarioSesion usuario;
        public int id { get; set; }
        public String rol { get; set; }
        public String nombre { get; set; }
        private UsuarioSesion() { }
        public int idSucursalElegida { get; set; }

        public static UsuarioSesion Usuario
        {
            get
            {
                if (usuario == null)
                {
                    usuario = new UsuarioSesion();
                }
                return usuario;
            }
        }
    }
}
