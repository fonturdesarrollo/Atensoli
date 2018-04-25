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
        public static DataSet ObtenerConsultaSolicitud(string cedulaSolicitante, int IndicaSoloPendientes)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@CedulaSolicitante", SqlDbType.VarChar, 0, cedulaSolicitante),
                    DBHelper.MakeParam("@IndicaSoloPendientes", SqlDbType.Int, 0, IndicaSoloPendientes)
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
        public static DataSet ObtenerSolicitudPorID(int solicitudID)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@SolicituID", SqlDbType.VarChar, 0, solicitudID),
                };
            return DBHelper.ExecuteDataSet("usp_ConsultaSolicitud_ObtenerSolicitudPorID", dbParams);
        }
    }
}