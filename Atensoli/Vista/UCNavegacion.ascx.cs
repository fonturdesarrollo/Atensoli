using Admin;
using Seguridad.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cellper.Vista
{
    public partial class UCNavegacion : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            EstablecerSeguridad();
        }
        private void EstablecerSeguridad()
        {
            CSeguridad objetoSeguridad = new CSeguridad();
            objetoSeguridad.SeguridadUsuarioDatosID = Convert.ToInt32(this.Session["UserId"].ToString());
            if (objetoSeguridad.EsUsuarioAdministrador() == false)
            {
                ColocarEnlacesInvisibles();
                if (objetoSeguridad.EsAccesoPermitido(9) == true)
                {
                    lnkRecepcionEquipo.Visible = true;
                }
                if (objetoSeguridad.EsAccesoPermitido(10) == true)
                {
                    lnkColaDeEquipos.Visible = true;
                }
                if (objetoSeguridad.EsAccesoPermitido(11) == true)
                {
                    lnkColaReparacionEquipos.Visible = true;
                }
                if (objetoSeguridad.EsAccesoPermitido(12) == true)
                {
                    lnkColaEquiposEntregados.Visible = true;
                }
                if (objetoSeguridad.EsAccesoPermitido(13) == true)
                {
                    lnkInventario.Visible = true;
                }
                if (objetoSeguridad.EsAccesoPermitido(14) == true)
                {
                    lnkMarcaEquipo.Visible = true;
                }
                if (objetoSeguridad.EsAccesoPermitido(15) == true)
                {
                    lnkModeloEquipo.Visible = true;
                }
                if (objetoSeguridad.EsAccesoPermitido(16) == true)
                {
                    lnkFallasEquipo.Visible = true;
                }
                if (objetoSeguridad.EsAccesoPermitido(17) == true)
                {
                    lnkSeguridad.Visible = true;
                }
            }
        }
        private void ColocarEnlacesInvisibles()
        {
            lnkRecepcionEquipo.Visible = false;
            lnkColaDeEquipos.Visible = false;
            lnkColaReparacionEquipos.Visible = false;
            lnkColaEquiposEntregados.Visible = false;
            lnkInventario.Visible = false;
            lnkMarcaEquipo.Visible = false;
            lnkModeloEquipo.Visible = false;
            lnkFallasEquipo.Visible = false;
            lnkSeguridad.Visible = false;
        }
    }
}