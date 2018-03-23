using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace Atensoli.Vista
{
    public partial class SeleccionarSolicitante : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.Now.AddDays(-1));
            Response.Cache.SetNoStore();
            if (!IsPostBack)
            {
                hdnSolicitanteID.Value = "0";
            }
        }
        
        protected void btnSiguiente_Click(object sender, EventArgs e)
        {

            if(Convert.ToInt32(hdnSolicitanteID.Value) == 0)
            {
                if (EsSolicitanteValido())
                {
                    Session["SolicitanteID"] = null;
                    Response.Redirect("Solicitante.aspx");
                }
                else 
                {
                    Session["SolicitanteID"] = null;
                    messageBox.ShowMessage("El número de cedula no corresponde a alguien valido.");
                }
            }
            else
            {
                Session["SolicitanteID"] = Convert.ToInt32(hdnSolicitanteID.Value);
                Response.Redirect("Solicitante.aspx");
            }
             //Response.Redirect("EnConstruccion.aspx?" + "Cedula=" + hdnCedulaSolicitante.Value + "&Nombre="+ hdnNombreSolicitante.Value + "&ID=" + hdnSolicitanteID.Value, true);
        }
        private bool EsSolicitanteValido()
        {

            int contador = 0;
            bool resultado = false;
            foreach (var saime in Saime.ObtenerDatosSaime(txtCedula.Text))
            {
                switch (contador)
                {
                    case 0:
                        this.Session["CedulaSaime"] = saime;
                        contador = 1;
                        resultado = true;
                        break;
                    case 1:
                        this.Session["NombreSaime"] = saime;
                        contador = 2;
                        resultado = true;
                        break;
                    case 2:
                        this.Session["ApellidoSaime"] = saime;
                        contador = 3;
                        resultado = true;
                        break;
                }
                

            }
            return resultado;
        }
       
    }
}