using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Atensoli
{
    public partial class CorrespondenciaSeleccionGerencia : Seguridad.SeguridadAuditoria
    {
        protected new void Page_Load(object sender, EventArgs e)
        {
            Session.Remove("CodigoCorrespondenciaSeleccionada");
            Session.Remove("CodigoGerenciaEnSeleccion");
        }
        private void CargarCorrespondencia()
        {
            int codigoCorrespondencia =0;
            if (txtNumeroCorespondencia.Text != "")
            {
                codigoCorrespondencia = Convert.ToInt32(txtNumeroCorespondencia.Text);
            }
            try
            {
                DataSet ds = CorrespondenciaRecepcionGerencia.ObtenerCorrespondenciaExterna(codigoCorrespondencia, codigoGerenciaSegunObjeto());
                gridDetalle.DataSource = ds.Tables[0];
                gridDetalle.DataBind();
            }
            catch (Exception ex)
            {

                messageBox.ShowMessage(ex.Message + ex.StackTrace);
            }
        }
        private int codigoGerenciaSegunObjeto()
        {
            int codigoGerencia = 0;
            switch (Request.QueryString["CodigoObjetoCorrespondencia"])
            {
                case "1034":
                    codigoGerencia = 1;
                    break;
                case "1035":
                    codigoGerencia = 2;
                    break;
                case "1036":
                    codigoGerencia = 3;
                    break;
                case "1037":
                    codigoGerencia = 4;
                    break;
                case "1038":
                    codigoGerencia = 5;
                    break;
                case "1039":
                    codigoGerencia = 6;
                    break;
                case "1040":
                    codigoGerencia = 7;
                    break;
                case "1041":
                    codigoGerencia = 8;
                    break;
                case "1042":
                    codigoGerencia = 9;
                    break;
                case "1043":
                    codigoGerencia = 10;
                    break;
                case "1044":
                    codigoGerencia = 11;
                    break;
                case "1045":
                    codigoGerencia = 12;
                    break;
                case "1046":
                    codigoGerencia = 13;
                    break;
                case "1047":
                    codigoGerencia = 14;
                    break;

            }
            return codigoGerencia;
        }
        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            CargarCorrespondencia();
        }

        protected void gridDetalle_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                Session["CodigoCorrespondenciaSeleccionada"] = Convert.ToInt32(e.CommandArgument.ToString());
                Session["CodigoGerenciaEnSeleccion"] = codigoGerenciaSegunObjeto();
                AuditarMovimiento(HttpContext.Current.Request.Url.AbsolutePath, "Seleccionó la correspondencia número: " + e.CommandArgument.ToString(), System.Net.Dns.GetHostEntry(Request.ServerVariables["REMOTE_HOST"]).HostName, Convert.ToInt32(this.Session["UserId"].ToString()));
                if (e.CommandName == "SeleccionarCorrespondencia")
                {
                    Response.Redirect("CorrespondenciaRecepcionGerencia.aspx");
                }
            }
            catch (Exception ex)
            {
                messageBox.ShowMessage(ex.Message + ex.StackTrace);
            }
        }
    }
}