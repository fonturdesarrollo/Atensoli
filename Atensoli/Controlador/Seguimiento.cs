using Database.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Atensoli
{
    public class Seguimiento
    {
        public static int ActualizarEstatusSolicitud(int solicitudID)
        {
            SqlParameter[] dbParams = new SqlParameter[]
            {
                    DBHelper.MakeParam("@SolicitudID", SqlDbType.Int, 0, solicitudID)
            };
            return Convert.ToInt32(DBHelper.ExecuteScalar("usp_SeguimientoSeleccion_ActualizarEstatus", dbParams));
        }
    }
}