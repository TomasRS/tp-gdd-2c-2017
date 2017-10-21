using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.Utils
{
    class PopupMessage
    {
        public static void ShowMessage(string content, MessageBoxIcon icon)
        {
            MessageBox.Show(content, "Información", MessageBoxButtons.OK, icon);
        }
    }
}
