using Database.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Atensoli
{
    public partial class SeguimientoOAC
    {
        public static int InsertarSeguimiento(CSeguimientoOAC objetoSeguimientoOAC)
        {
            int codigoSeguimientoNuevo = 0;
            SqlParameter[] dbParams = new SqlParameter[]
            {
                    DBHelper.MakeParam("@SolicitudSeguimientoID", SqlDbType.Int, 0, objetoSeguimientoOAC.SolicitudSeguimientoID),
                    DBHelper.MakeParam("@SolicitudID", SqlDbType.Int, 0, objetoSeguimientoOAC.SolicitudID),
                    DBHelper.MakeParam("@TipoAccionID", SqlDbType.Int, 0, objetoSeguimientoOAC.TipoAccionID),
                    DBHelper.MakeParam("@GerenciaID", SqlDbType.Int, 0,objetoSeguimientoOAC.GerenciaID),
                    DBHelper.MakeParam("@ObservacionSeguimiento", SqlDbType.VarChar, 0,objetoSeguimientoOAC.ObservacionSeguimiento),
                    DBHelper.MakeParam("@SeguridadUsuarioDatosID", SqlDbType.Int, 0,objetoSeguimientoOAC.SeguridadUsuarioDatosID)
            };
            codigoSeguimientoNuevo = Convert.ToInt32(DBHelper.ExecuteScalar("usp_SeguimientoOAC_Insertar", dbParams));

            //Proceso para agregar el postulado
            //Paso 1 Elimina cualquier postulado asignado al seguimiento
            SqlParameter[] dbParams2 = new SqlParameter[]
            {
                    DBHelper.MakeParam("@SolicitudID", SqlDbType.Int, 0, objetoSeguimientoOAC.SolicitudID)
            };
            DBHelper.ExecuteScalar("usp_SeguimientoOAC_BorrarPostulado", dbParams2);
            if (dtGrid != null)
            {



                //Inserta en la tabla [SolicitudSeguimientoPostulado] los datos del postulado
                for (int i = 0; i < dtGrid.Rows.Count; i++)
                {
                    DataRow dr = dtGrid.Rows[i];
                    SqlParameter[] dbParams3 = new SqlParameter[]
                    {
                        DBHelper.MakeParam("@SolicitudID", SqlDbType.Int, 0, objetoSeguimientoOAC.SolicitudID),
                        DBHelper.MakeParam("@CedulaPostulado", SqlDbType.Int, 0, dr["CedulaPostulante"].ToString()),
                        DBHelper.MakeParam("@NombrePostulado", SqlDbType.VarChar, 0, dr["NombrePostulante"].ToString()),
                        DBHelper.MakeParam("@TelefonoPostulado", SqlDbType.VarChar, 0, dr["Telefono"].ToString()),
                    };
                    DBHelper.ExecuteScalar("usp_SeguimientoOAC_InsertarPostulado", dbParams3);
                }
            }
            return codigoSeguimientoNuevo;
        }
    }
}