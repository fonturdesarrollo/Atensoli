using Seguridad.Clases;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Atensoli.Vista
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
                lnkCambiarClave.Visible = true;
                if (objetoSeguridad.EsAccesoPermitido(9) == true)
                {
                    lnkSolicitudes.Visible = true;
                }
                if (objetoSeguridad.EsAccesoPermitido(12) == true)
                {
                    lnkTipoSolicitante.Visible = true;
                }
                if (objetoSeguridad.EsAccesoPermitido(13) == true)
                {
                    lnkTipoSolicitud.Visible = true;
                }
                if (objetoSeguridad.EsAccesoPermitido(14) == true)
                {
                    lnkTipoOrganizacion.Visible = true;
                }
                if (objetoSeguridad.EsAccesoPermitido(15) == true)
                {
                    lnkTipoAtencion.Visible = true;

                }

                if (objetoSeguridad.EsAccesoPermitido(16) == true)
                {
                    lnkReferido.Visible = true;

                }

                if (objetoSeguridad.EsAccesoPermitido(17) == true)
                {
                    lnkTipoRemitido.Visible = true;

                }
                if (objetoSeguridad.EsAccesoPermitido(18) == true)
                {
                    lnkTipoInsumo.Visible = true;
                }
                if (objetoSeguridad.EsAccesoPermitido(22) == true)
                {
                    lnkConsultarSolicitud.Visible = true;
                }
                if (objetoSeguridad.EsAccesoPermitido(23) == true)
                {
                    lnkTipoSoporteFIsico.Visible = true;
                }
                if (objetoSeguridad.EsAccesoPermitido(1023) == true)
                {
                    lnkSeguimientoSolicitudes.Visible = true;
                }
                if (objetoSeguridad.EsAccesoPermitido(1024) == true)
                {
                    lnkSolicitudesCargadas.Visible = true;
                }
                if (objetoSeguridad.EsAccesoPermitido(1025) == true)
                {
                    lnkEstadisticasGenerales.Visible = true;
                }
            }
        }
        private void ColocarEnlacesInvisibles()
        {
            foreach (Control ctrl in Controls)
            {
                if (ctrl.GetType().Name == "HyperLink")
                {
                    HyperLink hl = (HyperLink)ctrl;
                    hl.Visible = false;
                }
            }
        }
    }
}