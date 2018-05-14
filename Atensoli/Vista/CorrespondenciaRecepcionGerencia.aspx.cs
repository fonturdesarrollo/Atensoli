using System;
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
    public partial class CorrespondenciaRecepcionGerencia : Seguridad.SeguridadAuditoria
    {
        protected new void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                CargarCorrespondencia();
                CargarInstruccion();
                CargarGerencia();
                CargarEstatus();
            }
        }

        private void CargarInstruccion()
        {
            ddlInstruccion.Items.Clear();
            ddlInstruccion.Items.Add(new ListItem("--Seleccione la instrucción--", ""));
            String strConnString = ConfigurationManager
            .ConnectionStrings["CallCenterConnectionString"].ConnectionString;
            String strQuery = "";

            strQuery = "Select * From TipoInstruccionCorrespondencia ORDER BY NombreTipoInstruccionCorrespondencia";

            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strQuery;
                    cmd.Connection = con;
                    con.Open();
                    ddlInstruccion.DataSource = cmd.ExecuteReader();
                    ddlInstruccion.DataTextField = "NombreTipoInstruccionCorrespondencia";
                    ddlInstruccion.DataValueField = "TipoInstruccionCorrespondenciaID";
                    ddlInstruccion.DataBind();
                    con.Close();
                }
            }
        }
        private void CargarEstatus()
        {
            ddlEstatus.Items.Clear();
            ddlEstatus.Items.Add(new ListItem("--Seleccione el estatus--", ""));
            String strConnString = ConfigurationManager
            .ConnectionStrings["CallCenterConnectionString"].ConnectionString;
            String strQuery = "";

            strQuery = "Select * From CorrespondenciaEstatus ORDER BY CorrespondenciaEstatusID";

            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strQuery;
                    cmd.Connection = con;
                    con.Open();
                    ddlEstatus.DataSource = cmd.ExecuteReader();
                    ddlEstatus.DataTextField = "NombreCorrespondenciaEstatus";
                    ddlEstatus.DataValueField = "CorrespondenciaEstatusID";
                    ddlEstatus.DataBind();
                    con.Close();
                }
            }
        }
        private void CargarGerencia()
        {
            ddlGerencia.Items.Clear();
            ddlGerencia.Items.Add(new ListItem("--Seleccione la gerencia a remitir--", ""));
            String strConnString = ConfigurationManager
            .ConnectionStrings["CallCenterConnectionString"].ConnectionString;
            String strQuery = "";

            strQuery = "Select * From Gerencia ORDER BY GerenciaID";

            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strQuery;
                    cmd.Connection = con;
                    con.Open();
                    ddlGerencia.DataSource = cmd.ExecuteReader();
                    ddlGerencia.DataTextField = "NombreGerencia";
                    ddlGerencia.DataValueField = "GerenciaID";
                    ddlGerencia.DataBind();
                    con.Close();
                }
            }
        }
        private void CargarCorrespondencia()
        {
            try
            {
                DataSet ds = CorrespondenciaRecepcionGerencia.ObtenerCorrespondenciaExterna(Convert.ToInt32(Session["CodigoCorrespondenciaSeleccionada"].ToString()), Convert.ToInt32(Session["CodigoGerenciaEnSeleccion"].ToString()));
                this.gridDetalle.DataSource = ds.Tables[0];
                this.gridDetalle.DataBind();
            }
            catch (Exception ex)
            {

                messageBox.ShowMessage(ex.Message + ex.StackTrace);
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            ProcesoCorrespondencia();
        }

        private void ProcesoCorrespondencia()
        {
            int codigoSeguimientoCorrespondencia = 0;
            try
            {
                if(EsTodoCorrecto() == true)
                {
                    CCorrespondenciaRecepcionGerencia objetoCorrespondencia = new CCorrespondenciaRecepcionGerencia();

                    objetoCorrespondencia.CorrespondenciaID = Convert.ToInt32(Session["CodigoCorrespondenciaSeleccionada"].ToString());
                    objetoCorrespondencia.TipoInstruccionCorrespondenciaID = Convert.ToInt32(ddlInstruccion.SelectedValue);
                    objetoCorrespondencia.ObservacionesSeguimientoCorrespondencia = txtObservaciones.Text.ToUpper().Trim();
                    objetoCorrespondencia.CorrespondenciaEstatusID = Convert.ToInt32(ddlEstatus.SelectedValue);
                    objetoCorrespondencia.SeguridadUsuarioDatosID = Convert.ToInt32(Session["UserId"].ToString());
                    objetoCorrespondencia.GerenciaID = Convert.ToInt32(ddlGerencia.SelectedValue);
                    objetoCorrespondencia.GerenciaRemitenteID = Convert.ToInt32(Session["CodigoGerenciaEnSeleccion"].ToString());

                    codigoSeguimientoCorrespondencia = CorrespondenciaRecepcionGerencia.InsertarSeguimientoCorrespondencia(objetoCorrespondencia);
                    if (codigoSeguimientoCorrespondencia > 0)
                    {
                        AuditarMovimiento(HttpContext.Current.Request.Url.AbsolutePath, "Agregó seguimiento a la correspondencia número: " + codigoSeguimientoCorrespondencia, System.Net.Dns.GetHostEntry(Request.ServerVariables["REMOTE_HOST"]).HostName, Convert.ToInt32(this.Session["UserId"].ToString()));
                        messageBox.ShowMessage("Recepción de correspondencia agregada");
                        CargarCorrespondencia();
                        LimpiarTodo();
                    }
                }

            }
            catch (Exception ex)
            {

                messageBox.ShowMessage(ex.Message + ex.StackTrace);
            }

        }
        private void LimpiarTodo()
        {
            txtObservaciones.Text = string.Empty;
            CargarInstruccion();
            CargarGerencia();
            CargarEstatus();
        }
        private bool EsTodoCorrecto()
        {
            bool resultado = true;
            if (gridDetalle.Rows.Count < 1)
            {
                resultado = false;
                messageBox.ShowMessage("No puede registrar correspondencia que no esté asignada a su gerencia.");
            }
            return resultado;
        }

        protected void btnHistorial_Click(object sender, EventArgs e)
        {
            Response.Redirect("CorrespondenciaHistorial.aspx");
        }
    }
}