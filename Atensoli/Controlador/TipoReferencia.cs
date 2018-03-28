using Database.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Atensoli
{
    public partial class TipoReferencia
    {
        public static int InsertarTipoReferencia(CTipoReferencia objetoTipoReferencia)
        {
            SqlParameter[] dbParams = new SqlParameter[]
            {
                    DBHelper.MakeParam("@TipoReferenciaSolicitudID", SqlDbType.Int, 0, objetoTipoReferencia.TipoReferenciaSolicitudID),
                    DBHelper.MakeParam("@NombreTipoReferenciaSolicitud", SqlDbType.VarChar, 0, objetoTipoReferencia.NombreTipoReferenciaSolicitud)
            };

            return Convert.ToInt32(DBHelper.ExecuteScalar("usp_TipoReferencia_Insertar", dbParams));
        }
    }
}