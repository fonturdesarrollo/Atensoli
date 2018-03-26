using Database.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Atensoli
{
    public partial class Organizacion
    {
        public static int InsertarOrganizacion( COrganizacion objetoOrganizacion)
        {
            SqlParameter[] dbParams = new SqlParameter[]
            {
                    DBHelper.MakeParam("@OrganizacionID", SqlDbType.Int, 0, objetoOrganizacion.OrganizacionID),
                    DBHelper.MakeParam("@RifOrganizacion", SqlDbType.VarChar, 0, objetoOrganizacion.RifOrganizacion),
                    DBHelper.MakeParam("@NombreOrganizacion", SqlDbType.VarChar, 0, objetoOrganizacion.NombreOrganizacion),
                    DBHelper.MakeParam("@TipoOrganizacionID", SqlDbType.Int, 0, objetoOrganizacion.TipoOrganizacionID),
                    DBHelper.MakeParam("@ParroquiaID", SqlDbType.Int, 0,objetoOrganizacion.ParroquiaID),
                    DBHelper.MakeParam("@TelefonoOrganizacion", SqlDbType.VarChar, 0, objetoOrganizacion.TelefonoOrganizacion),
                    DBHelper.MakeParam("@SeguridadUsuarioDatosID", SqlDbType.Int, 0,objetoOrganizacion.SeguridadUsuarioDatosID),
                    DBHelper.MakeParam("@EmpresaSucursalID", SqlDbType.Int, 0,objetoOrganizacion.EmpresaSucursalID)

            };

            return Convert.ToInt32(DBHelper.ExecuteScalar("[usp_Organizacion_Insertar]", dbParams));

        }
        public static SqlDataReader ObtenerDatosOrganizacion(int OrganizacionID)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@OrganizacionID", SqlDbType.Int, 0, @OrganizacionID)
                };
            return DBHelper.ExecuteDataReader("usp_Organizacion_ObtenerOrganizacion", dbParams);
        }
        public static int CodigoOrganizacionRegistrada(string rifOrganizacion)
        {
            int resultado = 0;
            SqlDataReader dr;
            try
            {
                SqlParameter[] dbParams = new SqlParameter[]
                    {
                    DBHelper.MakeParam("@RifOrganizacion", SqlDbType.VarChar, 0, rifOrganizacion)
                    };

                dr = DBHelper.ExecuteDataReader("usp_Solicitante_ObtenerCodigoOrganizacionRegistrada", dbParams);
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        resultado = Convert.ToInt32(dr["OrganizacionID"]);
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