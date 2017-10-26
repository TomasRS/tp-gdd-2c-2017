using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    }
}
