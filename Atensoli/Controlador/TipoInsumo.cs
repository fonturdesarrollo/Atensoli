using Database.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Atensoli
{
    public partial class TipoInsumo
    {
        public static int InsertarTipoInsumo(CTipoInsumo objetoTipoInsumo)
        {
            SqlParameter[] dbParams = new SqlParameter[]
            {
                    DBHelper.MakeParam("@TipoInsumoID", SqlDbType.Int, 0, objetoTipoInsumo.TipoInsumoID),
                    DBHelper.MakeParam("@NombreTipoInsumo", SqlDbType.VarChar, 0, objetoTipoInsumo.NombreTipoInsumo)
            };

            return Convert.ToInt32(DBHelper.ExecuteScalar("usp_TipoInsumo_Insertar", dbParams));
        }
        public static int InsertarDetalleTipoInsumo(CTipoInsumo objetoTipoInsumo)
        {
            SqlParameter[] dbParams = new SqlParameter[]
            {
                    DBHelper.MakeParam("@TipoInsumoDetalleID", SqlDbType.Int, 0, objetoTipoInsumo.TipoInsumoDetalleID),
                    DBHelper.MakeParam("@TipoInsumoID", SqlDbType.Int, 0, objetoTipoInsumo.TipoInsumoID),
                    DBHelper.MakeParam("@NombreTipoInsumoDetalle", SqlDbType.VarChar, 0, objetoTipoInsumo.NombreTipoInsumoDetalle)
            };

            return Convert.ToInt32(DBHelper.ExecuteScalar("usp_TipoInsumoDetalle_Insertar", dbParams));
        }
        public static DataSet ObtenerDetalleTipoInsumo(int codigoTipoInsumo)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@TipoInsumoID", SqlDbType.Int, 0, codigoTipoInsumo)
                };

            return DBHelper.ExecuteDataSet("usp_TipoInsumo_ObtenerDetalleTipoInsumo", dbParams);
        }
    }
}