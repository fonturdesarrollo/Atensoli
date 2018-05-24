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
        public static DataSet ObtenerDetalleEstadisticaPorEstado(string fechaSolicitud, string fechaHasta)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                   DBHelper.MakeParam("@FechaDeRegistro", SqlDbType.VarChar, 0, fechaSolicitud),
                   DBHelper.MakeParam("@FechaRegistroHasta", SqlDbType.VarChar, 0, fechaHasta)
                };

            return DBHelper.ExecuteDataSet("usp_EstadisticasGenerales_ObtenerEstadisticaPorEstado", dbParams);

        }
        public static DataSet ObtenerDetalleEstadisticaPorTipoSolicitud(string fechaSolicitud, string fechaHasta)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                   DBHelper.MakeParam("@FechaDeRegistro", SqlDbType.VarChar, 0, fechaSolicitud),
                   DBHelper.MakeParam("@FechaRegistroHasta", SqlDbType.VarChar, 0, fechaHasta)
                };

            return DBHelper.ExecuteDataSet("usp_EstadisticasGenerales_ObtenerEstadisticaPorTipoSolicitud", dbParams);
        }
        public static DataSet ObtenerDetalleEstadisticaPorTipoRemitido(string fechaSolicitud, string fechaHasta)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                   DBHelper.MakeParam("@FechaDeRegistro", SqlDbType.VarChar, 0, fechaSolicitud),
                   DBHelper.MakeParam("@FechaRegistroHasta", SqlDbType.VarChar, 0, fechaHasta)
                };

            return DBHelper.ExecuteDataSet("usp_EstadisticasGenerales_ObtenerEstadisticaPorTipoRemitido", dbParams);

        }
        public static DataSet ObtenerDetalleEstadisticaPorTransportistasAtendidos(string fechaSolicitud, string fechaHasta)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                   DBHelper.MakeParam("@FechaDeRegistro", SqlDbType.VarChar, 0, fechaSolicitud),
                   DBHelper.MakeParam("@FechaRegistroHasta", SqlDbType.VarChar, 0, fechaHasta)
                };

            return DBHelper.ExecuteDataSet("usp_EstadisticasGenerales_ObtenerTransportistasAtendidos", dbParams);

        }

        public static SqlDataReader ObtenerTotalSolicitudes(string fechaSolicitud, string fechaHasta)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                   DBHelper.MakeParam("@FechaDeRegistro", SqlDbType.VarChar, 0, fechaSolicitud),
                   DBHelper.MakeParam("@FechaRegistroHasta", SqlDbType.VarChar, 0, fechaHasta)
                };

            return DBHelper.ExecuteDataReader("usp_EstadisticasGenerales_ObtenerTotalSolicitudes", dbParams);

        }
        public static SqlDataReader TotalSolicitudesPorEstado(string fechaSolicitud, string fechaHasta)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                   DBHelper.MakeParam("@FechaDeRegistro", SqlDbType.VarChar, 0, fechaSolicitud),
                   DBHelper.MakeParam("@FechaRegistroHasta", SqlDbType.VarChar, 0, fechaHasta)
                };
            return DBHelper.ExecuteDataReader("usp_EstadisticasGenerales_TotalSolicitudesPorEstado", dbParams);
        }
        public static SqlDataReader TotalPorTipoSolicitud(string fechaSolicitud, string fechaHasta)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                   DBHelper.MakeParam("@FechaDeRegistro", SqlDbType.VarChar, 0, fechaSolicitud),
                   DBHelper.MakeParam("@FechaRegistroHasta", SqlDbType.VarChar, 0, fechaHasta)
                };
            return DBHelper.ExecuteDataReader("usp_EstadisticasGenerales_TotalPorTipoSolicitud", dbParams);
        }
        public static SqlDataReader TotalPorTipoRemitido(string fechaSolicitud, string fechaHasta)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                   DBHelper.MakeParam("@FechaDeRegistro", SqlDbType.VarChar, 0, fechaSolicitud),
                   DBHelper.MakeParam("@FechaRegistroHasta", SqlDbType.VarChar, 0, fechaHasta)
                };
            return DBHelper.ExecuteDataReader("usp_EstadisticasGenerales_TotalPorTipoRemitido", dbParams);
        }
        public static SqlDataReader TotalPorTransportistas(string fechaSolicitud, string fechaHasta)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                   DBHelper.MakeParam("@FechaDeRegistro", SqlDbType.VarChar, 0, fechaSolicitud),
                   DBHelper.MakeParam("@FechaRegistroHasta", SqlDbType.VarChar, 0, fechaHasta)
                };
            return DBHelper.ExecuteDataReader("usp_EstadisticasGenerales_TotalTransportistasAtendidos", dbParams);
        }
    }
}