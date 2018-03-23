using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Atensoli
{
    public partial class Organizacion : System.Web.UI.Page
    {
        public static int codigoOrganizacion = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                CargarPadre();
                CargarTipoOrganizacion();
                EstablecerOrganizacion();

            }
        }
        //***********************************************************************************
        //PROCESO PARA COMBOS ANIDADOS:

        //COMBO ANIDADO NUMERO 1 (SE CARGA DESDE EL SERVIDOR)
        private void CargarPadre()
        {
            ddlPadre.Items.Clear();
            ddlPadre.Items.Add(new ListItem("--Seleccione el estado--", ""));
            String strConnString = ConfigurationManager
            .ConnectionStrings["CallCenterConnectionString"].ConnectionString;
            String strQuery = "";

            strQuery = "select * From Estado ORDER BY NombreEstado";

            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strQuery;
                    cmd.Connection = con;
                    con.Open();
                    ddlPadre.DataSource = cmd.ExecuteReader();
                    ddlPadre.DataTextField = "NombreEstado";
                    ddlPadre.DataValueField = "EstadoID";
                    ddlPadre.DataBind();
                    con.Close();
                }
            }
        }
        //*********************************************************************************

        //COMBO ANIDADO NUMERO 2 (SE CARGA EN EL CLIENTE CON JSON MEDIANTE LA FUNCION CargarHijo())
        [System.Web.Services.WebMethod]
        public static ArrayList CargarHijo(int padreID)
        {
            ArrayList list = new ArrayList();
            String strConnString = ConfigurationManager
            .ConnectionStrings["CallCenterConnectionString"].ConnectionString;
            String strQuery = "";

            if (padreID != 0)
            {
                strQuery = "select * From Municipio  WHERE EstadoID   = @padreID  ORDER BY NombreMunicipio";
            }
            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@padreID", padreID);
                    cmd.CommandText = strQuery;
                    cmd.Connection = con;
                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        list.Add(new ListItem(
                       sdr["NombreMunicipio"].ToString(),
                       sdr["MunicipioID"].ToString()
                        ));
                    }
                    con.Close();
                    return list;
                }
            }
        }
        //*********************************************************************************

        //COMBO ANIDADO NUMERO 3 (SE CARGA EN EL CLIENTE CON JSON MEDIANTE LA FUNCION CargarNieto())
        [System.Web.Services.WebMethod]
        public static ArrayList CargarNieto(int nietoID)
        {
            ArrayList list = new ArrayList();
            String strConnString = ConfigurationManager
            .ConnectionStrings["CallCenterConnectionString"].ConnectionString;
            String strQuery = "";

            strQuery = "select * From Parroquia Where MunicipioID  = @nietoID  ORDER BY NombreParroquia";
            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@nietoID", nietoID);
                    cmd.CommandText = strQuery;
                    cmd.Connection = con;
                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        list.Add(new ListItem(
                       sdr["NombreParroquia"].ToString(),
                       sdr["ParroquiaID"].ToString()
                        ));
                    }
                    con.Close();
                    return list;
                }
            }
        }
        //*********************************************************************************

        //COMBOS ANIDADOS (FUNCIONES ADICIONALES)
        private void CargarCombosAlEnviarFormulario()
        {
            //ESTA FUNCION SE DEBE COLOCAR EN EL BOTON O EVENTO QUE ENVIA EL FORMULARIO
            // YA SEA PARA GUARDAR O PARA VALIDAR ALGUN CONTROL PORQUE DEBIDO A QUE EL TERCER COMBO SE CARGA EN CLIENTE SE PIERDE SU ID AL ENVIAR
            string padre = Request.Form[ddlPadre.UniqueID];
            string hijo = Request.Form[ddlHijo.UniqueID];
            string nieto = Request.Form[ddlNieto.UniqueID];

            // Repopulate Countries and Cities
            PopulateDropDownList(CargarHijo(int.Parse(padre)), ddlHijo);
            PopulateDropDownList(CargarNieto(int.Parse(hijo)), ddlNieto);
            ddlHijo.Items.FindByValue(hijo).Selected = true;
            ddlNieto.Items.FindByValue(nieto).Selected = true;
        }
        private void PopulateDropDownList(ArrayList list, DropDownList ddl)
        {
            ddl.DataSource = list;
            ddl.DataTextField = "Text";
            ddl.DataValueField = "Value";
            ddl.DataBind();
        }
        //FIN DE COMBOS ANIDADOS
        //*********************************************************************************

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
                ddTipoOrganizacion.DataTextField = "NombreTipoOrganizacion";
                ddTipoOrganizacion.DataValueField = "TipoOrganizacionID";
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
        private void EstablecerOrganizacion()
        {
            if (Convert.ToInt32(Session["OrganizacionID"]) > 0)
            {
                SqlDataReader dr = Organizacion.ObtenerDatosOrganizacion(Convert.ToInt32(Session["OrganizacionID"]));
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        txtRifOrganizacion.Text = dr["RifOrganizacion"].ToString();
                        txtNombreOrganizacion.Text = dr["NombreOrganizacion"].ToString();
                        ddTipoOrganizacion.SelectedValue = dr["TipoOrganizacionID"].ToString();
                        txtTelefonoOrganizacion.Text = dr["TelefonoOrganizacion"].ToString();
                    }
                }
                dr.Close();
            }

        }

        private void ProcesoOrganizacion()
        {
            try
            {
                COrganizacion objetoOrganizaicon = new COrganizacion();
                CargarCombosAlEnviarFormulario();
                objetoOrganizaicon.OrganizacionID = codigoOrganizacion;
                objetoOrganizaicon.RifOrganizacion = txtRifOrganizacion.Text.ToUpper();
                objetoOrganizaicon.NombreOrganizacion = txtNombreOrganizacion.Text.ToUpper();
                objetoOrganizaicon.TipoOrganizacionID = Convert.ToInt32(ddTipoOrganizacion.SelectedValue);
                objetoOrganizaicon.ParroquiaID = Convert.ToInt32(ddlNieto.SelectedValue);
                objetoOrganizaicon.TelefonoOrganizacion = txtTelefonoOrganizacion.Text;
                objetoOrganizaicon.SeguridadUsuarioDatosID = Convert.ToInt32(Session["UserId"]);
                objetoOrganizaicon.EmpresaSucursalID = Convert.ToInt32(Session["CodigoSucursalEmpresa"]);
                codigoOrganizacion = Organizacion.InsertarOrganizacion(objetoOrganizaicon);
                if (codigoOrganizacion > 0)
                {
                    messageBox.ShowMessage("Registro actualizado.");
                }
            }
            catch (Exception ex)
            {
                messageBox.ShowMessage(ex.Message);
            }
        }
        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Solicitud.aspx");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            ProcesoOrganizacion();
        }

        protected void btnLimpiar_Click1(object sender, EventArgs e)
        {
            Response.Redirect("~/Vista/Solicitud.aspx");
        }
    }
}