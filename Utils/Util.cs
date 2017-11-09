using PagoAgilFrba.DataProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.Utils
{
    class Util
    {

        //Metodo para mostrar mensajes por pantalla
        public static void ShowMessage(string content, MessageBoxIcon icon)
        {
            MessageBox.Show(content, "Información", MessageBoxButtons.OK, icon);
        }

        //Metodo para validar que una lista de textbox tengan datos
        public static Boolean CamposEstanLlenos(IList<TextBox> campos) {
            return campos.All(unCampo => !unCampo.Text.Equals(""));
        }

        public static Boolean EsNumero(String unNumero)
        {
            long number1 = 0;
            return long.TryParse(unNumero, out number1);
        }

        public static int getNumeroFromString(String numero)
        {
            int number = 0;
            int.TryParse(numero, out number);
            return number;
        }

        public static Boolean EsFechaPasada(DateTime dateTime)
        {
            DateTime dateNow = DateConfig.getInstance().getCurrentDate();
            int comparacion = dateTime.CompareTo(dateNow);
            return !(comparacion >= 0);
        }

        public static Boolean EsFechaVencimientoValida(DateTime dateTime, DateTime fechaAlta)
        {
            DateTime dateNow = DateConfig.getInstance().getCurrentDate();
            int comparacion = dateTime.CompareTo(fechaAlta);
            return comparacion >= 0;
        }

        public static Boolean FechaPrimeraMayorOIgualAFechaSegunda(DateTime fechaPrimera, DateTime fechaSegunda)
        {
            int comparacion = fechaPrimera.CompareTo(fechaSegunda);
            return comparacion >= 0;
        }

        public static Boolean EsEmailValido(string email)
        {
            try {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch {
                return false;
            }
        }

        public static Boolean EsNombreValido(string nombre)
        {
            return Regex.IsMatch(nombre, @"^[a-zA-Zá-úÁ-Ú\s]+$");
        }

        public static Boolean EsCuitValido(String cuit)
        {
            List<string> partesCuit = cuit.Split('-').ToList();
            return partesCuit.Count().Equals(3) && partesCuit.All(unaParte => EsNumero(unaParte)) && ValidarLongitudPartesCuit(partesCuit);
        }

        private static Boolean ValidarLongitudPartesCuit(List<string> partesCuit)
        {
            int longitudPrimeraParte = partesCuit.First().Length;
            int longitudMedia = partesCuit.ElementAt(1).Length;
            int longitudUltimaParte = partesCuit.Last().Length;
            return (longitudPrimeraParte.Equals(1) || longitudPrimeraParte.Equals(2)) && longitudMedia.Equals(8) && longitudUltimaParte.Equals(1);
        }

        public static Boolean HayAlMenosAlgoSeleccionadoEnListBox(CheckedListBox listBox)
        {
            return listBox.CheckedItems.Count >= 1;
        }

        public static Boolean EstaEntre0y100(int numero)
        {
            return numero >= 0 && numero <= 100;
        }
    }
}
