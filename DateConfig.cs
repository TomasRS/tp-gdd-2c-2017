using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba
{
    class DateConfig
    {
        private static DateConfig instance;

        public static DateConfig getInstance()
        {
            if (instance == null)
            {
                instance = new DateConfig();
            }

            return instance;
        }

        public DateTime getCurrentDate()
        {
            return DateTime.Now;
        }
    }
}
