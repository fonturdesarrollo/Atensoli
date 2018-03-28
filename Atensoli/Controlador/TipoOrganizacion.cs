using Database.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Atensoli
{
    public partial class TipoOrganizacion
    {
        public static int InsertarTipoOrganizacion(CTipoOrganizacion objetoTipoOrganizacion)
        {
            SqlParameter[] dbParams = new SqlParameter[]
            {
                    DBHelper.MakeParam("@TipoOrganizacionID", SqlDbType.Int, 0, objetoTipoOrganizacion.TipoOrganizacionID),
                    DBHelper.MakeParam("@NombreTipoOrganizacion", SqlDbType.VarChar, 0, objetoTipoOrganizacion.NombreTipoOrganizacion)
            };

            return Convert.ToInt32(DBHelper.ExecuteScalar("usp_TipoOrganizacion_Insertar", dbParams));
        }
    }
}