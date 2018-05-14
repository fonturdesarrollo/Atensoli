using Database.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Atensoli
{
    public partial class CorrespondenciaExternaRecepcion
    {
        public static int InsertarRecepcionCorrespondenciaExterna(CCorrespondenciaExternaRecepcion objetoCorrespondenciaExterna)
        {
            SqlParameter[] dbParams = new SqlParameter[]
            {
                    DBHelper.MakeParam("@CorrespondenciaID", SqlDbType.Int, 0, objetoCorrespondenciaExterna.CorrespondenciaID),
                    DBHelper.MakeParam("@TipoCorrespondenciaID", SqlDbType.Int, 0, objetoCorrespondenciaExterna.TipoCorrespondenciaID),
                    DBHelper.MakeParam("@CorrespondenciaRemitenteID", SqlDbType.Int, 0, objetoCorrespondenciaExterna.CorrespondenciaRemitenteID),
                    DBHelper.MakeParam("@NombreCorrespondenciaRemitente", SqlDbType.VarChar, 0, objetoCorrespondenciaExterna.NombreCorrespondenciaRemitente),
                    DBHelper.MakeParam("@EstadoID", SqlDbType.Int, 0, objetoCorrespondenciaExterna.EstadoID),
                    DBHelper.MakeParam("@FechaCorrespondencia", SqlDbType.SmallDateTime, 0, objetoCorrespondenciaExterna.FechaCorrespondencia),
                    DBHelper.MakeParam("@ContenidoCorrespondencia", SqlDbType.VarChar, 0, objetoCorrespondenciaExterna.ContenidoCorrespondencia),
                    DBHelper.MakeParam("@CorrespondenciaPrioridadID", SqlDbType.Int, 0,objetoCorrespondenciaExterna.CorrespondenciaPrioridadID),
                    DBHelper.MakeParam("@GerenciaID", SqlDbType.Int, 0,objetoCorrespondenciaExterna.GerenciaID),
                    DBHelper.MakeParam("@SeguridadUsuarioDatosID", SqlDbType.Int, 0,objetoCorrespondenciaExterna.SeguridadUsuarioDatosID)
            };

            return Convert.ToInt32(DBHelper.ExecuteScalar("[usp_CorrespondenciaExterna_Insertar]", dbParams));

        }
        public static DataSet ObtenerCorrespondenciaExterna(int correspondenciaID)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@CorrespondenciaID", SqlDbType.Int, 0, correspondenciaID)
                };
            return DBHelper.ExecuteDataSet("usp_CorrespondenciaExterna_ObtenerCorrespondencia", dbParams);
        }
        public static DataSet EliminarCorrespondenciaExterna(int correspondenciaID)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@CorrespondenciaID", SqlDbType.Int, 0, correspondenciaID)
                };

            return DBHelper.ExecuteDataSet("usp_CorrespondenciaExterna_Eliminar", dbParams);
        }
    }
}