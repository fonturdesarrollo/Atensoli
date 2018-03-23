using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Atensoli
{
    public partial class SeleccionarOrganizacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            Session["OrganizacionID"] = Convert.ToInt32(hdnOrganizacionID.Value);
            Response.Redirect("Organizacion.aspx");
        }
    }
}