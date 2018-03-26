﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Atensoli.Vista
{
    public partial class BuscarTipoSolicitud : Seguridad.SeguridadAuditoria
    {
        protected new void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Session.Remove("TipoSolicitudID");
                Session.Remove("SolicitanteID");
                Session.Remove("OrganizacionID");
                Session.Remove("TipoSolicitudID");
                Session.Remove("TipoSolicitanteID");
                Session.Remove("CedulaSaime");
                Session.Remove("NombreSaime");
                Session.Remove("ApellidoSaime");
                CargarTipoSolicitud();
            }
        }
        private void CargarTipoSolicitud()
        {
            String strConnString = ConfigurationManager
            .ConnectionStrings["CallCenterConnectionString"].ConnectionString;
            String strQuery = "select * from TipoSolicitud order by NombreTipoSolicitud";
            SqlConnection con = new SqlConnection(strConnString);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strQuery;
            cmd.Connection = con;

            try
            {
                con.Open();
                ddTipoSolicitud.DataSource = cmd.ExecuteReader();
                ddTipoSolicitud.DataTextField = "NombreTipoSolicitud";
                ddTipoSolicitud.DataValueField = "TipoSolicitudID";
                ddTipoSolicitud.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            Session["TipoSolicitudID"] = ddTipoSolicitud.SelectedValue;
            Response.Redirect("~/Vista/SeleccionarSolicitante.aspx");
        }
    }
}
