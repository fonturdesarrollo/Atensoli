using Database.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Atensoli
{
    public partial class TipoSolicitante
    {
        public static int InsertarTipoSolicitante(CTipoSolicitante objetoTipoSolicitante)
        {
            SqlParameter[] dbParams = new SqlParameter[]
            {
                    DBHelper.MakeParam("@TipoSolicitanteID", SqlDbType.Int, 0, objetoTipoSolicitante.TipoSolicitanteID),
                    DBHelper.MakeParam("@NombreTipoSolicitante", SqlDbType.VarChar, 0, objetoTipoSolicitante.NombreTipoSolicitante)
            };

            return Convert.ToInt32(DBHelper.ExecuteScalar("usp_TipoSolicitante_Insertar", dbParams));
        }
    }
}