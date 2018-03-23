using Database.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Atensoli
{
    public partial class Solicitud
    {
        public static int InsertarSolicitud( CSolicitud objetoSolicitud)
        {
            SqlParameter[] dbParams = new SqlParameter[]
            {
                    DBHelper.MakeParam("@SolucitudID", SqlDbType.Int, 0, objetoSolicitud.SolicitudID),
                    DBHelper.MakeParam("@TipoSolicitudID", SqlDbType.Int, 0, objetoSolicitud.TipoSolicitudID),
                    DBHelper.MakeParam("@TipoSolicitanteID", SqlDbType.Int, 0, objetoSolicitud.TipoSolicitanteID),
                    DBHelper.MakeParam("@SolicitanteID", SqlDbType.Int, 0, objetoSolicitud.SolicitanteID),
                    DBHelper.MakeParam("@NombreCargoSolicitante", SqlDbType.VarChar, 0, objetoSolicitud.NombreCargoSolicitante),
                    DBHelper.MakeParam("@OrganizacionID", SqlDbType.Int, 0, objetoSolicitud.OrganizacionID),
                    DBHelper.MakeParam("@TipoAtencionBrindadaID", SqlDbType.Int, 0, objetoSolicitud.TipoAtencionBrindadaID),
                    DBHelper.MakeParam("@TipoReferenciaSolicitud", SqlDbType.Int, 0,objetoSolicitud.TipoReferenciaSolicitud),
                    DBHelper.MakeParam("@TipoUnidadID", SqlDbType.Int, 0,objetoSolicitud.TipoUnidadID),
                    DBHelper.MakeParam("@TipoInsumoDetalleID", SqlDbType.Int, 0,objetoSolicitud.TipoInsumoDetalleID),
                    DBHelper.MakeParam("@TipoEstatusID", SqlDbType.Int, 0,objetoSolicitud.TipoEstatusID),
                    DBHelper.MakeParam("@TipoFormaAtencionID", SqlDbType.VarChar, 0,objetoSolicitud.TipoFormaAtencionID),
                    DBHelper.MakeParam("@ObservacionesSolicitante", SqlDbType.VarChar, 0,objetoSolicitud.ObservacionesSolicitante),
                    DBHelper.MakeParam("@ObservacionesAnalista", SqlDbType.VarChar, 0,objetoSolicitud.ObservacionesAnalista),
                    DBHelper.MakeParam("@SeguridadUsuarioDatosID", SqlDbType.Int, 0,objetoSolicitud.SeguridadUsuarioDatosID),
                    DBHelper.MakeParam("@EmpresaSucursalID", SqlDbType.Int, 0,objetoSolicitud.EmpresaSucursalID)

            };

            return Convert.ToInt32(DBHelper.ExecuteScalar("[usp_Solicitud_Insertar]", dbParams));

        }
        public static SqlDataReader ObtenerDatosSolicitud(int solicitudID)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@SolicitudID", SqlDbType.Int, 0, solicitudID)
                };
            return DBHelper.ExecuteDataReader("usp_Solicitante_ObtenerSolicitante", dbParams);
        }
    }
}