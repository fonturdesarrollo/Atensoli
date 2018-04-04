using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Atensoli
{
    public partial class ConsultarSolicitudesCargadas : Seguridad.SeguridadAuditoria
    {
        protected new void Page_Load(object sender, EventArgs e)
        {

        }
        private void CargarSolicitudes()
        {
            try
            {
                string fechaSolicitud = "";
                if(chkDelDia.Checked == true)
                {
                    fechaSolicitud = DateTime.Now.ToString("dd/MM/yyyy");
                }
                DataSet ds = ConsultarSolicitud.ObtenerSolicitudesCargadas(fechaSolicitud);
                this.gridDetalle.DataSource = ds.Tables[0];
                this.gridDetalle.DataBind();
            }
            catch (Exception ex)
            {

                messageBox.ShowMessage(ex.Message + ex.StackTrace);
            }
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            CargarSolicitudes();
            AuditarMovimiento(HttpContext.Current.Request.Url.AbsolutePath, "Consultó movimientos de solictudes", System.Net.Dns.GetHostEntry(Request.ServerVariables["REMOTE_HOST"]).HostName, Convert.ToInt32(this.Session["UserId"].ToString()));
        }
    }
}