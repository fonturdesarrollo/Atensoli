using System;
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
    public partial class Organizacion : System.Web.UI.Page
    {
        private object ddlTipoOrganizacion;

        protected void Page_Load(object sender, EventArgs e)
        {
            CargarTipoOrganizacion();
        }
        private void CargarTipoOrganizacion()
        {
            String strConnString = ConfigurationManager
            .ConnectionStrings["CallCenterConnectionString"].ConnectionString;
            String strQuery = "select * from TipoOrganizacion order by NombreTipoOrganizacion";
            SqlConnection con = new SqlConnection(strConnString);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strQuery;
            cmd.Connection = con;

            try
            {
             
                con.Open();
                
                ddTipoOrganizacion.DataSource = cmd.ExecuteReader();
                ddTipoOrganizacion.DataTextField = "NombreTipoSolicitud";
                ddTipoOrganizacion.DataValueField = "TipoSolicitudID";
                ddTipoOrganizacion.DataBind();
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
            Response.Redirect("~/Vista/Organizacion.aspx");
        }

    }
}