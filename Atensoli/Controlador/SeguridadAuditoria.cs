using Database.Classes;
using Seguridad.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace Seguridad
{
    public class SeguridadAuditoria : Page
    {
        public SeguridadAuditoria()
        {
            this.Load += new EventHandler(Page_Load);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            EstablecerSeguridad();
        }
        private void EstablecerSeguridad()
        {

            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.Now.AddDays(-1));
            Response.Cache.SetNoStore();

            if (this.Session["UserID"] == null)
            {
                AuditarMovimiento(HttpContext.Current.Request.Url.AbsolutePath, "Intento de entrar en pantalla sin iniciar sesión", System.Net.Dns.GetHostEntry(Request.ServerVariables["REMOTE_HOST"]).HostName, 0);
                Server.Transfer("Logout.aspx");
            }
            else
            {
                CSeguridad objetoSeguridad = new CSeguridad();
                objetoSeguridad.SeguridadUsuarioDatosID = Convert.ToInt32(this.Session["UserId"].ToString());
                if (objetoSeguridad.EsUsuarioAdministrador() == false)
                {
                    if(EsCambioClave(HttpContext.Current.Request.Url.AbsolutePath) == false)
                    {
                        if (objetoSeguridad.EsAccesoPermitido(CodigoObjetoSegunUrl(HttpContext.Current.Request.Url.AbsolutePath)) == false)
                        {
                            AuditarMovimiento(HttpContext.Current.Request.Url.AbsolutePath, "Intento de entrar en pantalla sin tener permiso", System.Net.Dns.GetHostEntry(Request.ServerVariables["REMOTE_HOST"]).HostName, Convert.ToInt32(this.Session["UserId"].ToString()));
                            Server.Transfer("Logout.aspx");
                        }
                    }
                }

            }
        }
        private int CodigoObjetoSegunUrl(string urlSeleccionado)
        {
            int codigoObjeto = 0;
            switch (urlSeleccionado)
            {
                case "/Vista/SeleccionarTipoSolicitud.aspx":
                    codigoObjeto = 9;
                    break;
                case "/Vista/SeleccionarSolicitante.aspx":
                    codigoObjeto = 9;
                     break;
                case "/Vista/Solicitante.aspx":
                    codigoObjeto = 9;
                    break;
                case "/Vista/SeleccionarTipoSolicitante.aspx":
                    codigoObjeto = 9;
                    break;
                case "/Vista/SeleccionarOrganizacion.aspx":
                    codigoObjeto = 9;
                    break;
                case "/Vista/Organizacion.aspx":
                    codigoObjeto = 9;
                    break;
                case "/Vista/Solicitud.aspx":
                    codigoObjeto = 9;
                    break;
                case "/Vista/ConsultarSolicitud.aspx":
                    codigoObjeto = 22;
                    break;
                case "/Vista/TipoInsumo.aspx":
                    codigoObjeto = 18;
                    break;
                case "/Vista/TipoReferencia.aspx":
                    codigoObjeto = 16;
                    break;
                case "/Vista/TipoSolicitante.aspx":
                    codigoObjeto = 12;
                    break;
                case "/Vista/TipoSolicitud.aspx":
                    codigoObjeto = 13;
                    break;
                case "/Vista/TipoOrganizacion.aspx":
                    codigoObjeto = 14;
                    break;
                case "/Vista/TipoSoporte.aspx":
                    codigoObjeto = 23;
                    break;
                case "/Vista/TipoRemitido.aspx":
                    codigoObjeto = 17;
                    break;
                default:
                    break;
            }
            return codigoObjeto;
        }
        private bool EsCambioClave(string urlSeleccionado)
        {
            bool resultado = false;
            if(urlSeleccionado == "/Vista/SeguridadCambiarClave.aspx")
            {
                resultado = true;
            }
            return resultado;
        }
        public static void AuditarMovimiento(string nombreFormulario, string descripcionProceso, string nombreEquipoCliente, int codigoUsuario)
        {
            try
            {
                string nombreServidor = System.Net.Dns.GetHostName();
                System.Net.IPHostEntry ipServidor = System.Net.Dns.GetHostEntry(nombreServidor);
                System.Net.IPAddress[] addr = ipServidor.AddressList;
                string ipEquipoCliente = addr[1].ToString();
                SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@SeguridadUsuarioDatosID", SqlDbType.Int, 0, codigoUsuario),
                    DBHelper.MakeParam("@NombreFormulario", SqlDbType.VarChar, 0, nombreFormulario),
                    DBHelper.MakeParam("@DescripcionProceso", SqlDbType.VarChar, 0, descripcionProceso),
                    DBHelper.MakeParam("@NombreEquipoCliente", SqlDbType.VarChar, 0, nombreEquipoCliente),
                    DBHelper.MakeParam("@IPEquipoCliente", SqlDbType.VarChar, 0, ipEquipoCliente)
                };

                DBHelper.ExecuteScalar("usp_SeguridadAuditoria_AuditarMovimiento", dbParams);
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
    }