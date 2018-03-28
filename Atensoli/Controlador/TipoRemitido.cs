using Database.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Atensoli
{
    public partial class TipoRemitido
    {
        public static int InsertarTipoRemitido(CTipoRemitido objetoTipoRemitido)
        {
            try
            {
                SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@TipoRemitidoID", SqlDbType.Int, 0, objetoTipoRemitido.TipoRemitidoID),
                    DBHelper.MakeParam("@NombreTipoRemitido", SqlDbType.VarChar, 0, objetoTipoRemitido.NombreTipoRemitido)
                };
                return Convert.ToInt32(DBHelper.ExecuteScalar("usp_TipoRemitido_Insertar", dbParams));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}