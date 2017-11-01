//using PagoAgilFrba.DataProvider;
//using PagoAgilFrba.Excepciones;
//using PagoAgilFrba.Utils;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace PagoAgilFrba.Modelo
//{
//    class Sucursal : Mapeable
//    {
//        private int id;
//        private String nombre;
//        private String direccion;
//        private String codPostal;
//        private Boolean activo;


//        //--------------------------------------------------------
//        public void setID(int id)
//        { this.id = id; }
//        public void setNombre(String nombre)
//        { this.nombre = nombre; }
//        public void setDireccion(String direccion)
//        { this.direccion = direccion; }
//        public void setCodPostal(String codPostal)
//        {
//            if (Util.EsNumero(codPostal))
//                this.codPostal = codPostal;
//            else
//                throw new FormatoInvalidoException("Código Postal. El formato debe ser númerico y sin espacios.");
//        }

//        public int getID() { return this.id; }
//        public String getNombre() { return this.nombre; }
//        public String getDireccion() { return this.direccion; }
//        public String getCodPostal() { return this.codPostal; }
//    }
//}
