using Database.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Atensoli
{
    public class Estadisticas
    {
        public static DataSet ObtenerDetalleEstadisticaPorEstado(string fechaSolicitud)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                   DBHelper.MakeParam("@FechaDeRegistro", SqlDbType.VarChar, 0, fechaSolicitud)
                };

            return DBHelper.ExecuteDataSet("usp_EstadisticasGenerales_ObtenerEstadisticaPorEstado", dbParams);

        }
        public static DataSet ObtenerDetalleEstadisticaPorTipoSolicitud(string fechaSolicitud)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                   DBHelper.MakeParam("@FechaDeRegistro", SqlDbType.VarChar, 0, fechaSolicitud)
                };

            return DBHelper.ExecuteDataSet("usp_EstadisticasGenerales_ObtenerEstadisticaPorTipoSolicitud", dbParams);

        }
        public static DataSet ObtenerDetalleEstadisticaPorTipoRemitido(string fechaSolicitud)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                   DBHelper.MakeParam("@FechaDeRegistro", SqlDbType.VarChar, 0, fechaSolicitud)
                };

            return DBHelper.ExecuteDataSet("usp_EstadisticasGenerales_ObtenerEstadisticaPorTipoRemitido", dbParams);

        }
        public static SqlDataReader ObtenerTotalSolicitudes(string fechaSolicitud)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                   DBHelper.MakeParam("@FechaSolicitud", SqlDbType.VarChar, 0, fechaSolicitud)
                };

            return DBHelper.ExecuteDataReader("usp_ConsultaSolicitud_ObtenerTotalSolicitudesPorFecha", dbParams);

        }
    }
}