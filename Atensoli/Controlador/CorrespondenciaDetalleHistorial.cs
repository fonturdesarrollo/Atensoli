using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using Database.Classes;

namespace Atensoli.Controlador
{
	public partial class CorrespondenciaDetalleHistorial
	{
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