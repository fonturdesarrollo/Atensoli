using Database.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Atensoli
{
    public partial class CorrespondenciaRecepcionGerencia
    {
        public static int InsertarSeguimientoCorrespondencia(CCorrespondenciaRecepcionGerencia objetoCorrespondencia)
        {
            SqlParameter[] dbParams = new SqlParameter[]
            {
                    DBHelper.MakeParam("@CorrespondenciaID", SqlDbType.Int, 0, objetoCorrespondencia.CorrespondenciaID),
                    DBHelper.MakeParam("@TipoInstruccionCorrespondenciaID", SqlDbType.Int, 0, objetoCorrespondencia.TipoInstruccionCorrespondenciaID),
                    DBHelper.MakeParam("@ObservacionesSeguimientoCorrespondencia", SqlDbType.VarChar, 0, objetoCorrespondencia.ObservacionesSeguimientoCorrespondencia),
                    DBHelper.MakeParam("@CorrespondenciaEstatusID", SqlDbType.Int, 0, objetoCorrespondencia.CorrespondenciaEstatusID),
                    DBHelper.MakeParam("@GerenciaID", SqlDbType.Int, 0, objetoCorrespondencia.GerenciaID),
                    DBHelper.MakeParam("@SeguridadUsuarioDatosID", SqlDbType.Int, 0,objetoCorrespondencia.SeguridadUsuarioDatosID),
                    DBHelper.MakeParam("@GerenciaRemitenteID", SqlDbType.Int, 0,objetoCorrespondencia.GerenciaRemitenteID)
            };

            return Convert.ToInt32(DBHelper.ExecuteScalar("[usp_CorrespondenciaGerencia_Insertar]", dbParams));

        }
        public static DataSet ObtenerCorrespondenciaExterna(int correspondenciaID, int gerenciaID)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@CorrespondenciaID", SqlDbType.Int, 0, correspondenciaID),
                    DBHelper.MakeParam("@GerenciaID", SqlDbType.Int, 0, gerenciaID)
                };
            return DBHelper.ExecuteDataSet("usp_CorrespondenciaExterna_ObtenerCorrespondenciaGerencia", dbParams);
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