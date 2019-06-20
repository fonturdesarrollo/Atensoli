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
        public static DataSet ObtenerSolicitudesCargadas(DateTime fechaDesde, DateTime fechaHasta)
        {
            string desde = fechaDesde.ToString("yyyy") + '-' + fechaDesde.ToString("MM") + '-' + fechaDesde.ToString("dd");
            string hasta = fechaDesde.ToString("yyyy") + '-' + fechaHasta.ToString("MM") + '-' + fechaHasta.ToString("dd");

            SqlParameter[] dbParams = new SqlParameter[]
                {
                   DBHelper.MakeParam("@FechaDesde", SqlDbType.VarChar, 0, desde),
                   DBHelper.MakeParam("@FechaHasta", SqlDbType.VarChar, 0, hasta)
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
        public static DataSet ObtenerConsultaSolicitudSeguimientoAbierto(int cedulaSolicitante)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@CedulaSolicitante", SqlDbType.Int, 0, cedulaSolicitante)
                };
            return DBHelper.ExecuteDataSet("usp_ConsultaSolicitud_ObtenerSolicitudSeguimiento", dbParams);

        }
    }
}