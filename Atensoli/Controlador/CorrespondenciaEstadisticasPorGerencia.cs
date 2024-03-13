using Database.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Atensoli.Controlador
{
    public partial class CorrespondenciaEstadisticasPorGerencia
    {
        public static SqlDataReader ObtenerCorrespondenciasExternas(int correspondenciaID, int gerenciaID)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@CorrespondenciaID", SqlDbType.Int, 0, correspondenciaID),
                    DBHelper.MakeParam("@GerenciaID", SqlDbType.Int, 0, gerenciaID)
                };
            return DBHelper.ExecuteDataReader("usp_CorrespondenciaExterna_ObtenerCorrespondenciaGerencia", dbParams);
        }

        public static DataSet ObtenerHistorialCorrespondenciaGerencia(int correspondenciaID)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@CorrespondenciaID", SqlDbType.Int, 0, correspondenciaID)
                };
            return DBHelper.ExecuteDataSet("usp_CorrespondenciaGerencia_HistorialCorrespondencia", dbParams);
        }
    }
}