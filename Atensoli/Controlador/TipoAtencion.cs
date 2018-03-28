using Database.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Atensoli
{
    public partial class TipoAtencion
    {
        public static int InsertarTipoAtencion(CTIpoAtencion objetoTipoAtencion)
        {
            try
            {
                SqlParameter[] dbParams = new SqlParameter[]
{
                    DBHelper.MakeParam("@TipoAtencionBrindadaID", SqlDbType.Int, 0, objetoTipoAtencion.TipoAtencionBrindadaID),
                    DBHelper.MakeParam("@NombreTipoAtencionBrindada", SqlDbType.VarChar, 0, objetoTipoAtencion.NombreTipoAtencionBrindada)
};
                return Convert.ToInt32(DBHelper.ExecuteScalar("usp_TipoAtencion_Insertar", dbParams));
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}