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
            int codigoSolicitudNueva = 0;
            SqlParameter[] dbParams = new SqlParameter[]
            {
                    DBHelper.MakeParam("@SolicitudID", SqlDbType.Int, 0, objetoSolicitud.SolicitudID),
                    DBHelper.MakeParam("@TipoSolicitudID", SqlDbType.Int, 0, objetoSolicitud.TipoSolicitudID),
                    DBHelper.MakeParam("@TipoSolicitanteID", SqlDbType.Int, 0, objetoSolicitud.TipoSolicitanteID),
                    DBHelper.MakeParam("@SolicitanteID", SqlDbType.Int, 0, objetoSolicitud.SolicitanteID),
                    DBHelper.MakeParam("@NombreCargoSolicitante", SqlDbType.VarChar, 0, objetoSolicitud.NombreCargoSolicitante),
                    DBHelper.MakeParam("@OrganizacionID", SqlDbType.Int, 0, objetoSolicitud.OrganizacionID),
                    DBHelper.MakeParam("@TipoAtencionBrindadaID", SqlDbType.Int, 0, objetoSolicitud.TipoAtencionBrindadaID),
                    DBHelper.MakeParam("@TipoReferenciaSolicitudID", SqlDbType.Int, 0,objetoSolicitud.TipoReferenciaSolicitud),
                    DBHelper.MakeParam("@TipoUnidadID", SqlDbType.Int, 0,objetoSolicitud.TipoUnidadID),
                    DBHelper.MakeParam("@TipoInsumoDetalleID", SqlDbType.Int, 0,objetoSolicitud.TipoInsumoDetalleID),
                    DBHelper.MakeParam("@TipoRemitidoID", SqlDbType.Int, 0,objetoSolicitud.TipoRemitidoID),
                    DBHelper.MakeParam("@TipoFormaAtencionID", SqlDbType.VarChar, 0,objetoSolicitud.TipoFormaAtencionID),
                    DBHelper.MakeParam("@ObservacionesSolicitante", SqlDbType.VarChar, 0,objetoSolicitud.ObservacionesSolicitante),
                    DBHelper.MakeParam("@ObservacionesAnalista", SqlDbType.VarChar, 0,objetoSolicitud.ObservacionesAnalista),
                    DBHelper.MakeParam("@SeguridadUsuarioDatosID", SqlDbType.Int, 0,objetoSolicitud.SeguridadUsuarioDatosID),
                    DBHelper.MakeParam("@EmpresaSucursalID", SqlDbType.Int, 0,objetoSolicitud.EmpresaSucursalID)

            };
            codigoSolicitudNueva = Convert.ToInt32(DBHelper.ExecuteScalar("usp_Solicitud_Insertar", dbParams));

            //Proceso para agregar el tipo de soporte fisico

            //Paso 1 Elimina cualquier soporte fisico asignado a la solicitud
            SqlParameter[] dbParams2 = new SqlParameter[]
            {
                    DBHelper.MakeParam("@SolicitudID", SqlDbType.Int, 0, codigoSolicitudNueva)
            };
            DBHelper.ExecuteScalar("usp_Solicitud_BorrarTipoSoporte", dbParams2);
            if (dtGrid != null)
            {
                //Paso 2 Inserta en la tabla [SolicitudTipoSoporte] los datos del soporte fisico
                for (int i = 0; i < dtGrid.Rows.Count; i++)
                {
                    DataRow dr = dtGrid.Rows[i];
                    SqlParameter[] dbParams3 = new SqlParameter[]
                    {
                    DBHelper.MakeParam("@SolicitudID", SqlDbType.Int, 0, codigoSolicitudNueva),
                    DBHelper.MakeParam("@TipoSoporteID", SqlDbType.Int, 0, dr["TipoSoporteID"].ToString()),
                    DBHelper.MakeParam("@ArchivoDigital", SqlDbType.VarChar, 0, "N/D"),
                    };
                    DBHelper.ExecuteScalar("usp_Solicitud_InsertarTipoSoporte", dbParams3);
                }
            }
            return codigoSolicitudNueva;
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