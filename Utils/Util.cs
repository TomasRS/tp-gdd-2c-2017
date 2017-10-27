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

        public static Boolean EsFechaPasada(DateTime dateTime)
        {
            DateTime dateNow = DateConfig.getInstance().getCurrentDate();
            int comparacion = dateTime.CompareTo(dateNow);
            return !(comparacion >= 0);
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
    }
}
