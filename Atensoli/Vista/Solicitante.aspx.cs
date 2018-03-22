using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Atensoli
{
    public partial class Solicitante : System.Web.UI.Page
    {
        public static int codigoSolicitante=0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                CargarPadre();
                EstablecerSolicitante();
                SoloLectura();
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

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            ProcesoSolicitante();
        }
        private void EstablecerSolicitante()
        {
            if(Convert.ToInt32(Session["SolicitanteID"] ) > 0)
            {
                SqlDataReader dr = Solicitante.ObtenerDatosSolicitante(Convert.ToInt32(Session["SolicitanteID"]));
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        txtCedula.Text = dr["CedulaSolicitante"].ToString();
                        txtNombre.Text = dr["NombreSolicitante"].ToString();
                        txtApellido.Text = dr["ApellidoSolicitante"].ToString();
                        ddlSexo.SelectedValue= dr["Sexo"].ToString();
                        txtCelular.Text = dr["CelularSolicitante"].ToString();
                        txtTelefonoLocal.Text = dr["TelefonoLocalSolicitante"].ToString();
                        txtTelefonoOficina.Text = dr["TelefonoOficinalSolicitante"].ToString();
                        txtCorreo.Text = dr["CorreoElectronicoSolicitante"].ToString();
                        txtSerialCarnetPatria.Text = dr["SerialCarnetPatria"].ToString();
                        txtCodigoCarnetPatria.Text = dr["CodigoCarnetPatria"].ToString();
                    }
                }
                dr.Close();
            }

        }
        private void SoloLectura()
        {
            if (Convert.ToInt32(Session["SolicitanteID"]) > 0)
            {
                txtCedula.Enabled = false;
                txtNombre.Enabled = false;
                txtApellido.Enabled = false;
                ddlSexo.Enabled = false;
                txtCelular.Enabled = false;
                txtTelefonoLocal.Enabled = false;
                txtTelefonoOficina.Enabled = false;
                txtCorreo.Enabled = false;
                ddlPadre.Enabled = false;
                ddlHijo.Enabled = false;
                ddlNieto.Enabled = false;
                txtSerialCarnetPatria.Enabled = false;
                txtCodigoCarnetPatria.Enabled = false;
            }

        }
        private void ProcesoSolicitante()
        {
            try
            {
                CSolicitante objetoSolicitante = new CSolicitante();
                CargarCombosAlEnviarFormulario();
                objetoSolicitante.SolicitanteID = codigoSolicitante;
                objetoSolicitante.CedulaSolicitante = txtCedula.Text;
                objetoSolicitante.Nombresolicitante = txtNombre.Text.ToUpper();
                objetoSolicitante.ApellidoSolicitante = txtApellido.Text.ToUpper();
                objetoSolicitante.Sexo = ddlSexo.SelectedValue;
                objetoSolicitante.CelularSolicitante = txtCelular.Text;
                objetoSolicitante.TelefonoLocalSolicitante = txtTelefonoLocal.Text;
                objetoSolicitante.TelefonoOficinalSolicitante = txtTelefonoOficina.Text;
                objetoSolicitante.CorreoElectronicoSolicitante = txtCorreo.Text.ToUpper();
                objetoSolicitante.ParroquiaID = Convert.ToInt32(ddlNieto.SelectedValue);
                objetoSolicitante.IndicaCarnetPatria = chkPatria.Checked ? 1 : 0;
                objetoSolicitante.SeguridadUsuarioDatosID = Convert.ToInt32(Session["UserId"]);
                objetoSolicitante.EmpresaSucursalID = Convert.ToInt32(Session["CodigoSucursalEmpresa"]);
                if (chkPatria.Checked == true)
                {
                    objetoSolicitante.SerialCarnetPatria = txtSerialCarnetPatria.Text.ToUpper();
                    objetoSolicitante.CodigoCarnetPatria = txtCodigoCarnetPatria.Text.ToUpper();
                }
                else
                {
                    objetoSolicitante.SerialCarnetPatria = "";
                    objetoSolicitante.CodigoCarnetPatria = "";
                }

                codigoSolicitante = Solicitante.InsertarSolicitante(objetoSolicitante);
                if (codigoSolicitante > 0)
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
            Response.Redirect("SeleccionarTipoSolicitante.aspx");
        }
    }
}