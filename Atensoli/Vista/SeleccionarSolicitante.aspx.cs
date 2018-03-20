using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Atensoli.Vista
{
    public partial class SeleccionarSolicitante : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSiguiente_Click(object sender, EventArgs e)
        {

            Response.Redirect("Solicitante.aspx");
            //Response.Redirect("EnConstruccion.aspx?" + "Cedula=" + hdnCedulaSolicitante.Value + "&Nombre="+ hdnNombreSolicitante.Value + "&ID=" + hdnSolicitanteID.Value, true);
        }
    }
}