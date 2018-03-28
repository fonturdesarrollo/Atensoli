using Database.Classes;
using System.Data;
using System.Data.SqlClient;


namespace Admin
{
    public partial class Autocomplete
    {


        public static DataSet ObtenerCedulaSolicitante(string sQuery, int codigoSucursal)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@Query", SqlDbType.VarChar, 0, sQuery),
                    DBHelper.MakeParam("@EmpresaSucursalID", SqlDbType.Int, 0, codigoSucursal)
                };
            return DBHelper.ExecuteDataSet("usp_Autocomplete_ObtenerCedulaSolicitante", dbParams);
        }
        public static DataSet ObtenerRifOrganizacion(string sQuery, int codigoSucursal)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@Query", SqlDbType.VarChar, 0, sQuery),
                    DBHelper.MakeParam("@EmpresaSucursalID", SqlDbType.Int, 0, codigoSucursal)
                };
            return DBHelper.ExecuteDataSet("usp_Autocomplete_ObtenerRifOrganizacion", dbParams);
        }
        public static DataSet ObtenerNombreInsumo(string sQuery)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@Query", SqlDbType.VarChar, 0, sQuery)
                };
            return DBHelper.ExecuteDataSet("usp_Autocomplete_ObtenerNombreInsumo", dbParams);
        }
        public static DataSet ObtenerNombreReferencia(string sQuery)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@Query", SqlDbType.VarChar, 0, sQuery)
                };
            return DBHelper.ExecuteDataSet("usp_Autocomplete_ObtenerNombreReferencia", dbParams);
        }
        public static DataSet ObtenerEmpresas(string sQuery)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@Query", SqlDbType.VarChar, 0, sQuery),
                };
            return DBHelper.ExecuteDataSet("usp_Autocomplete_ObtenerEmpresas", dbParams);
        }

        //SEGURIDAD ***************************************************
        public static DataSet ObtenerUsuarios(string sQuery, int codigoSucursal)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@Query", SqlDbType.VarChar, 0, sQuery),
                    DBHelper.MakeParam("@EmpresaSucursalID", SqlDbType.Int, 0, codigoSucursal)
                };
            return DBHelper.ExecuteDataSet("usp_Autocomplete_ObtenerUsuarios", dbParams);
        }
        public static DataSet ObtenerGrupos(string sQuery)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@Query", SqlDbType.VarChar, 0, sQuery),
                };
            return DBHelper.ExecuteDataSet("usp_Autocomplete_ObtenerGrupos", dbParams);
        }
        public static DataSet ObtenerObjetos(string sQuery)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@Query", SqlDbType.VarChar, 0, sQuery),
                };
            return DBHelper.ExecuteDataSet("usp_Autocomplete_ObtenerObjetos", dbParams);
        }
        // *****************************************************************
    }
}