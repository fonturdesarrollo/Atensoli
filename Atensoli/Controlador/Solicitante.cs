using System;
using System.Web;
using System.Data.SqlClient;
using Database.Classes;
using System.Data;

namespace Atensoli
{
    public partial class Solicitante
    {
        public static int InsertarSolicitante( CSolicitante objetoSolicitante, int codigoUsuario, int codigoEmpresaSucursal)
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
                    DBHelper.MakeParam("@SeguridadUsuarioDatosID", SqlDbType.Int, 0,codigoUsuario),
                    DBHelper.MakeParam("@EmpresaSucursalID", SqlDbType.Int, 0,codigoEmpresaSucursal)

            };

           return Convert.ToInt32(DBHelper.ExecuteScalar("[usp_Solicitante_Insertar]", dbParams));

       }
    }
}