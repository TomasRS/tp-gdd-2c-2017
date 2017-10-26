using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.Modelo
{
    interface Mapeable
    {
        String GetQueryCrear();
        String GetQueryModificar();
        String GetQueryObtener();
        void CargarInformacion(SqlDataReader reader);
        IList<SqlParameter> GetParametros();
    }
}
