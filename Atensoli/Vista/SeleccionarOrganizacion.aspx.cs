using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Atensoli
{
    public partial class SeleccionarOrganizacion : Seguridad.SeguridadAuditoria
    {
        protected new void Page_Load(object sender, EventArgs e)
        {
            Session.Remove("OrganizacionID");
            Session.Remove("RifOrganizacion");
        }

        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            SiguientePaso();
        }
        private void SiguientePaso()
        {
            if (EsOrganizacionValida())
            {
                Response.Redirect("Organizacion.aspx");
            }
            else
            {
                messageBox.ShowMessage("Debe colocar el RIF de una organización válida");
            }
        }
        private bool EsOrganizacionValida()
        {
            int codigoOrganizacionRegistrada;
            bool resultado = false;

            //Paso 1
            //Verificar que la cedula este registrada en el sistema
            codigoOrganizacionRegistrada = Organizacion.CodigoOrganizacionRegistrada(txtRifOrganzacion.Text);
            if (codigoOrganizacionRegistrada > 0)
            {
                Session["OrganizacionID"] = codigoOrganizacionRegistrada;
                resultado = true;
            }
            else
            {
                Session["OrganizacionID"] = "0";
                Session["RifOrganizacion"] = txtRifOrganzacion.Text.ToUpper();
                resultado = true;
            }
            return resultado;
        }
    }
}