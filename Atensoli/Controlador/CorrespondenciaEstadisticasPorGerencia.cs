using Database.Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;

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
    }
}