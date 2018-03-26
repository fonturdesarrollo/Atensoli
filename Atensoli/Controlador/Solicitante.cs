using System;
using System.Web;
using System.Data.SqlClient;
using Database.Classes;
using System.Data;

namespace Atensoli
{
    public partial class Solicitante
    {
        public static int InsertarSolicitante( CSolicitante objetoSolicitante)
        {
            SqlParameter[] dbParams = new SqlParameter[]
            {
                    DBHelper.MakeParam("@SolicitanteID", SqlDbType.Int, 0, objetoSolicitante.SolicitanteID),
                    DBHelper.MakeParam("@CedulaSolicitante", SqlDbType.VarChar, 0, objetoSolicitante.CedulaSolicitante),
                    DBHelper.MakeParam("@NombreSolicitante", SqlDbType.VarChar, 0, objetoSolicitante.Nombresolicitante),
                    DBHelper.MakeParam("@ApellidoSolicitante", SqlDbType.VarChar, 0, objetoSolicitante.ApellidoSolicitante),
                    DBHelper.MakeParam("@Sexo", SqlDbType.VarChar, 0, objetoSolicitante.Sexo),
                    DBHelper.MakeParam("@CelularSolicitante", SqlDbType.VarChar, 0, objetoSolicitante.CelularSolicitante),
                    DBHelper.MakeParam("@TelefonoLocalSolicitante", SqlDbType.VarChar, 0, objetoSolicitante.TelefonoLocalSolicitante),
                    DBHelper.MakeParam("@TelefonoOficinalSolicitante", SqlDbType.VarChar, 0,objetoSolicitante.TelefonoOficinalSolicitante),
                    DBHelper.MakeParam("@CorreoElectronicoSolicitante", SqlDbType.VarChar, 0,objetoSolicitante.CorreoElectronicoSolicitante),
                    DBHelper.MakeParam("@ParroquiaID", SqlDbType.Int, 0,objetoSolicitante.ParroquiaID),
                    DBHelper.MakeParam("@IndicaCarnetPatria", SqlDbType.Int, 0,objetoSolicitante.IndicaCarnetPatria),
                    DBHelper.MakeParam("@SerialCarnetPatria", SqlDbType.VarChar, 0,objetoSolicitante.SerialCarnetPatria),
                    DBHelper.MakeParam("@CodigoCarnetPatria", SqlDbType.VarChar, 0,objetoSolicitante.CodigoCarnetPatria),
                    DBHelper.MakeParam("@SeguridadUsuarioDatosID", SqlDbType.Int, 0,objetoSolicitante.SeguridadUsuarioDatosID),
                    DBHelper.MakeParam("@EmpresaSucursalID", SqlDbType.Int, 0,objetoSolicitante.EmpresaSucursalID)

            };

           return Convert.ToInt32(DBHelper.ExecuteScalar("[usp_Solicitante_Insertar]", dbParams));

       }
        public static SqlDataReader ObtenerDatosSolicitante(int solicitanteID)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@SolicitanteID", SqlDbType.Int, 0, solicitanteID)
                };
            return DBHelper.ExecuteDataReader("usp_Solicitante_ObtenerSolicitante", dbParams);
        }
        public static int CodigoSolicitanteRegistrado(string cedulaSolicitante)
        {
            int resultado = 0;
            SqlDataReader dr;
            try
            {
                SqlParameter[] dbParams = new SqlParameter[]
                    {
                    DBHelper.MakeParam("@CedulaSolicitante", SqlDbType.VarChar, 0, cedulaSolicitante)
                    };

                dr = DBHelper.ExecuteDataReader("usp_Solicitante_ObtenerCodigoSolicitanteRegistrado", dbParams);
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        resultado = Convert.ToInt32(dr["SolicitanteID"]);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return resultado;
        }
    }
}