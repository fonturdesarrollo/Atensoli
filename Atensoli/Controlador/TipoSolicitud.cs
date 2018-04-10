using Database.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Atensoli
{
    public partial class TipoSolicitud
    {
        public static int InsertarTipoSolicitud(CTipoSolicitud objetoTipoSolicitud)
        {
            SqlParameter[] dbParams = new SqlParameter[]
            {
                    DBHelper.MakeParam("@TipoSolicitudID", SqlDbType.Int, 0, objetoTipoSolicitud.TipoSolicitudID),
                    DBHelper.MakeParam("@NombreTipoSolicitud", SqlDbType.VarChar, 0, objetoTipoSolicitud.NombreTipoSolicitud),
                    DBHelper.MakeParam("@DescripcionTipoSolicitud", SqlDbType.VarChar, 0, objetoTipoSolicitud.DescripcionTipoSolicitud)
            };

            return Convert.ToInt32(DBHelper.ExecuteScalar("usp_TipoSolicitud_Insertar", dbParams));
        }
        public static SqlDataReader ObtenerTipoSolicitud(int TipoSolicitudID)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@TipoSolicitudID", SqlDbType.Int, 0, TipoSolicitudID)
                };
            return DBHelper.ExecuteDataReader("usp_TipoSolicitud_ObtenerTipoSolicitud", dbParams);
        }
    }
}