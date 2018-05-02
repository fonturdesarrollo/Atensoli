using Database.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

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
                    DBHelper.MakeParam("@SeguridadUsuarioDatosID", SqlDbType.Int, 0,objetoSeguimientoOAC.SeguridadUsuarioDatosID),
                    DBHelper.MakeParam("@TipoRemitidoID", SqlDbType.Int, 0,objetoSeguimientoOAC.TipoRemitidoID),
                    DBHelper.MakeParam("@TipoInstruccionSeguimientoID", SqlDbType.Int, 0,objetoSeguimientoOAC.TipoInstruccionSeguimientoID)
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
                        DBHelper.MakeParam("@EstatusFichaSocialID", SqlDbType.Int, 0, dr["EstatusFichaSocialID"].ToString())
                    };
                    DBHelper.ExecuteScalar("usp_SeguimientoOAC_InsertarPostulado", dbParams3);
                }
            }


            //Proceso para agregar el tipo de soporte fisico

            //Paso 1 Elimina cualquier soporte fisico asignado a la solicitud
            SqlParameter[] dbParams4 = new SqlParameter[]
            {
                    DBHelper.MakeParam("@SolicitudID", SqlDbType.Int, 0, objetoSeguimientoOAC.SolicitudID)
            };
            DBHelper.ExecuteScalar("usp_Solicitud_BorrarTipoSoporte", dbParams4);
            if (dtGridDocumentos != null)
            {
                //Paso 2 Inserta en la tabla [SolicitudTipoSoporte] los datos del soporte fisico
                for (int i = 0; i < dtGridDocumentos.Rows.Count; i++)
                {
                    DataRow dr = dtGridDocumentos.Rows[i];
                    SqlParameter[] dbParams5 = new SqlParameter[]
                    {
                    DBHelper.MakeParam("@SolicitudID", SqlDbType.Int, 0, objetoSeguimientoOAC.SolicitudID),
                    DBHelper.MakeParam("@TipoSoporteID", SqlDbType.Int, 0, dr["TipoSoporteID"].ToString()),
                    DBHelper.MakeParam("@ArchivoDigital", SqlDbType.VarChar, 0, "N/D"),
                    };
                    DBHelper.ExecuteScalar("usp_Solicitud_InsertarTipoSoporte", dbParams5);
                }
            }
            return codigoSeguimientoNuevo;
        }
        public static SqlDataReader ObtenerPostulados(int solicitudID)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@SolicituID", SqlDbType.Int, 0, solicitudID),
                };
            return DBHelper.ExecuteDataReader("usp_SeguimientoOAC_ObtenerPostulados", dbParams);
        }
        public static SqlDataReader ObtenerDocumentosSolicitud(int solicitudID)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@SolicituID", SqlDbType.VarChar, 0, solicitudID),
                };
            return DBHelper.ExecuteDataReader("usp_ConsultaSolicitud_ObtenerDocumentosSolicitud", dbParams);
        }
        public static bool EsPostuladoEnOtraSolicitud(int solicitudID, int cedulaPostulado)
        {
            SqlDataReader dr;
            bool resultado = false;
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@SolicituID", SqlDbType.Int, 0, solicitudID),
                    DBHelper.MakeParam("@CedulaPostulado", SqlDbType.Float, 0, cedulaPostulado)
                };
            dr= DBHelper.ExecuteDataReader("usp_SeguimientoOAC_PostuladoEnSolicitud", dbParams);
            if(dr.HasRows)
            {
                while(dr.Read())
                {
                    var solicitudEncontrada = dr["SolicitudID"];
                    if(Convert.ToInt32(dr["SolicitudID"].ToString()) != solicitudID)
                    {
                        resultado = true;
                        break;
                    }
                   
                }
            }
            dr.Close();
            return resultado;
        }
    }
}