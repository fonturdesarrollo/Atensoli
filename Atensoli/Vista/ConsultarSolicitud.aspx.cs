using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Atensoli
{
    public partial class ConsultarSolicitud : Seguridad.SeguridadAuditoria
    {
        protected new void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
               
            }
        }
        private void CargarConsulta()
        {
            try
            {
                DataSet ds = ConsultarSolicitud.ObtenerConsultaSolicitud(txtCedula.Text.Trim());
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
            CargarConsulta();
        }
    }
}