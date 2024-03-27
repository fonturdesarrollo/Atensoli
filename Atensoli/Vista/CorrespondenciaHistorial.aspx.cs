using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Atensoli
{
    public partial class CorrespondenciaHistorial : System.Web.UI.Page
	{
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblTitulo.Text = "Historial de la correspondencia número [" + Convert.ToInt32(Session["CodigoCorrespondenciaSeleccionada"].ToString()) + "]";
                CargarSeguimientoHistorial();
                //AuditarMovimiento(HttpContext.Current.Request.Url.AbsolutePath, "Consultó historial de correspondencia: " + Convert.ToInt32(Session["CodigoCorrespondenciaSeleccionada"]), System.Net.Dns.GetHostEntry(Request.ServerVariables["REMOTE_HOST"]).HostName, Convert.ToInt32(this.Session["UserId"].ToString()));
            }
        }
        private void CargarSeguimientoHistorial()
        {
            try
            {
                DataSet ds = CorrespondenciaRecepcionGerencia.ObtenerHistorialCorrespondenciaGerencia(Convert.ToInt32(Session["CodigoCorrespondenciaSeleccionada"].ToString()));
                this.gridDetalle.DataSource = ds.Tables[0];
                this.gridDetalle.DataBind();
            }
            catch (Exception ex)
            {

                messageBox.ShowMessage(ex.Message + ex.StackTrace);
            }
        }
    }
}