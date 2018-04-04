using Database.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Atensoli
{
    public partial class ConsultarSolicitud
    {
        public static DataSet ObtenerConsultaSolicitud(string cedulaSolicitnate)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                DBHelper.MakeParam("@CedulaSolicitante", SqlDbType.VarChar, 0, cedulaSolicitnate)
                };

            return DBHelper.ExecuteDataSet("usp_ConsultaSolicitud_ObtenerSolicitud", dbParams);

        }
        public static DataSet ObtenerSolicitudesCargadas(string fechaSolicitud)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                   DBHelper.MakeParam("@FechaSolicitud", SqlDbType.VarChar, 0, fechaSolicitud)
                };

            return DBHelper.ExecuteDataSet("usp_ConsultaSolicitud_ObtenerSolicitudesCargadas", dbParams);

        }
    }
}