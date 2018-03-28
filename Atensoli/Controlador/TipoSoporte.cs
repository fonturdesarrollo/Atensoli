using Database.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Atensoli
{
    public partial class TipoSoporte
    {
        public static int InsertarTipoSoporte(CTipoSoporte objetoTipoSoporte)
        {
            try
            {
                SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@TipoSoporteID", SqlDbType.Int, 0, objetoTipoSoporte.TipoSoporteID),
                    DBHelper.MakeParam("@NombreTipoSoporte", SqlDbType.VarChar, 0, objetoTipoSoporte.NombreTipoSoporte)
                };
                return Convert.ToInt32(DBHelper.ExecuteScalar("usp_TipoSoporte_Insertar", dbParams));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}