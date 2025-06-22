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
    public partial class CorrespondenciaInterna
	{
		public static SqlDataReader ObtenerCorrespondenciasInternasRemitidas(int correspondenciaID, int gerenciaID)
		{
			SqlParameter[] dbParams = new SqlParameter[]
				{
					DBHelper.MakeParam("@CorrespondenciaID", SqlDbType.Int, 0, correspondenciaID),
					DBHelper.MakeParam("@GerenciaID", SqlDbType.Int, 0, gerenciaID)
				};
			return DBHelper.ExecuteDataReader("usp_CorrespondenciaInterna_ObtenerCorrespondenciaRemitidasGerencia", dbParams);
		}
		public static SqlDataReader ObtenerCorrespondenciasInternasRecibidas(int correspondenciaID, int gerenciaID)
		{
			SqlParameter[] dbParams = new SqlParameter[]
				{
					DBHelper.MakeParam("@CorrespondenciaID", SqlDbType.Int, 0, correspondenciaID),
					DBHelper.MakeParam("@GerenciaID", SqlDbType.Int, 0, gerenciaID)
				};
			return DBHelper.ExecuteDataReader("usp_CorrespondenciaInterna_ObtenerCorrespondenciaRecibidasGerencia", dbParams);
		}

		public static int InsertarCorrespondenciaInterna(CCorrespondenciaInterna objetoCorrespondenciaInterna)
		{
			SqlParameter[] dbParams = new SqlParameter[]
			{
					DBHelper.MakeParam("@CorrespondenciaID", SqlDbType.Int, 0, objetoCorrespondenciaInterna.CorrespondenciaID),
					DBHelper.MakeParam("@TipoCorrespondenciaID", SqlDbType.Int, 0, objetoCorrespondenciaInterna.TipoCorrespondenciaID),
					DBHelper.MakeParam("@CorrespondenciaRemitenteID", SqlDbType.Int, 0, objetoCorrespondenciaInterna.CorrespondenciaRemitenteID),
					DBHelper.MakeParam("@NombreCorrespondenciaRemitente", SqlDbType.VarChar, 0, objetoCorrespondenciaInterna.NombreCorrespondenciaRemitente),
					DBHelper.MakeParam("@EstadoID", SqlDbType.Int, 0, objetoCorrespondenciaInterna.EstadoID),
					DBHelper.MakeParam("@FechaCorrespondencia", SqlDbType.SmallDateTime, 0, objetoCorrespondenciaInterna.FechaCorrespondencia),
					DBHelper.MakeParam("@ContenidoCorrespondencia", SqlDbType.VarChar, 0, objetoCorrespondenciaInterna.ContenidoCorrespondencia),
					DBHelper.MakeParam("@CorrespondenciaPrioridadID", SqlDbType.Int, 0,objetoCorrespondenciaInterna.CorrespondenciaPrioridadID),
					DBHelper.MakeParam("@GerenciaID", SqlDbType.Int, 0,objetoCorrespondenciaInterna.GerenciaID),
					DBHelper.MakeParam("@SeguridadUsuarioDatosID", SqlDbType.Int, 0,objetoCorrespondenciaInterna.SeguridadUsuarioDatosID)
			};

			return Convert.ToInt32(DBHelper.ExecuteScalar("[usp_CorrespondenciaInterna_Insertar]", dbParams));
		}

		public static DataSet ObtenerCorrespondenciaInterna(int correspondenciaID)
		{
			SqlParameter[] dbParams = new SqlParameter[]
				{
					DBHelper.MakeParam("@CorrespondenciaID", SqlDbType.Int, 0, correspondenciaID)
				};
			return DBHelper.ExecuteDataSet("usp_CorrespondenciaInterna_ObtenerCorrespondencia", dbParams);
		}
	}
}