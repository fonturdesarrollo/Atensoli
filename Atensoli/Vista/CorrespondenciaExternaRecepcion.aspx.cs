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
    public partial class CorrespondenciaExternaRecepcion : Seguridad.SeguridadAuditoria
    {
        private static int codigoCorrespondencia = 0;
        protected new void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                codigoCorrespondencia = 0;
                CargarTipoCorrespondencia();
                CargarEstado();
                CargarGerencia();
                CargarPrioridad();
            }
        }

        private void CargarPrioridad()
        {
            ddlPrioridad.Items.Clear();
            ddlPrioridad.Items.Add(new ListItem("--Seleccione la prioridad--", ""));
            String strConnString = ConfigurationManager
            .ConnectionStrings["CallCenterConnectionString"].ConnectionString;
            String strQuery = "";

            strQuery = "Select * From CorrespondenciaPrioridad ORDER BY CorrespondenciaPrioridadID";

            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strQuery;
                    cmd.Connection = con;
                    con.Open();
                    ddlPrioridad.DataSource = cmd.ExecuteReader();
                    ddlPrioridad.DataTextField = "NombreCorrespondenciaPrioridad";
                    ddlPrioridad.DataValueField = "CorrespondenciaPrioridadID";
                    ddlPrioridad.DataBind();
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

        private void CargarEstado()
        {
            ddlEstado.Items.Clear();
            ddlEstado.Items.Add(new ListItem("--Seleccione el estado--", ""));
            String strConnString = ConfigurationManager
            .ConnectionStrings["CallCenterConnectionString"].ConnectionString;
            String strQuery = "";

            strQuery = "Select * From Estado ORDER BY NombreEstado";

            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strQuery;
                    cmd.Connection = con;
                    con.Open();
                    ddlEstado.DataSource = cmd.ExecuteReader();
                    ddlEstado.DataTextField = "NombreEstado";
                    ddlEstado.DataValueField = "EstadoID";
                    ddlEstado.DataBind();
                    con.Close();
                }
            }
        }

        private void CargarTipoCorrespondencia()
        {
            ddlTipoCorrespondencia.Items.Clear();
            ddlTipoCorrespondencia.Items.Add(new ListItem("--Seleccione el tipo de correspondencia--", ""));
            String strConnString = ConfigurationManager
            .ConnectionStrings["CallCenterConnectionString"].ConnectionString;
            String strQuery = "";

            strQuery = "select * From TipoCorrespondencia ORDER BY TipoCorrespondenciaID";

            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strQuery;
                    cmd.Connection = con;
                    con.Open();
                    ddlTipoCorrespondencia.DataSource = cmd.ExecuteReader();
                    ddlTipoCorrespondencia.DataTextField = "NombreTipoCorrespondencia";
                    ddlTipoCorrespondencia.DataValueField = "TipoCorrespondenciaID";
                    ddlTipoCorrespondencia.DataBind();
                    con.Close();
                }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            ProcesoInsertar();
        }

        private void ProcesoInsertar()
        {
            try
            {
                CCorrespondenciaExternaRecepcion objetoCorrespondencia = new CCorrespondenciaExternaRecepcion();
                objetoCorrespondencia.CorrespondenciaID = codigoCorrespondencia;
                objetoCorrespondencia.TipoCorrespondenciaID = Convert.ToInt32(ddlTipoCorrespondencia.SelectedValue);
                objetoCorrespondencia.CorrespondenciaRemitenteID = Convert.ToInt32(hdnRemitenteID.Value);
                objetoCorrespondencia.NombreCorrespondenciaRemitente = txtNombreRemitente.Text.ToUpper().Trim();
                objetoCorrespondencia.EstadoID = Convert.ToInt32(ddlEstado.SelectedValue);
                objetoCorrespondencia.FechaCorrespondencia = txtFechaCorrespondencia.Text.Trim();
                objetoCorrespondencia.ContenidoCorrespondencia = txtContenido.Text.ToUpper().Trim();
                objetoCorrespondencia.CorrespondenciaPrioridadID = Convert.ToInt32(ddlPrioridad.SelectedValue);
                objetoCorrespondencia.GerenciaID = Convert.ToInt32(ddlGerencia.SelectedValue);
                objetoCorrespondencia.SeguridadUsuarioDatosID = Convert.ToInt32(Session["UserId"].ToString());

                codigoCorrespondencia = CorrespondenciaExternaRecepcion.InsertarRecepcionCorrespondenciaExterna(objetoCorrespondencia);
                if (codigoCorrespondencia > 0)
                    {
                        AuditarMovimiento(HttpContext.Current.Request.Url.AbsolutePath, "Agregó correspondencia externa número: " + codigoCorrespondencia, System.Net.Dns.GetHostEntry(Request.ServerVariables["REMOTE_HOST"]).HostName, Convert.ToInt32(this.Session["UserId"].ToString()));
                        messageBox.ShowMessage("Correspondencia registrada exitosamente.");
                        txtNombreRemitente.Text = string.Empty;
                        CargarCorrespondencia(codigoCorrespondencia);
                    }
                }
            catch (Exception ex)
            {

                messageBox.ShowMessage(ex.Message + ex.StackTrace);
            }

        }

        private void CargarCorrespondencia(int codCorrespondencia)
        {
            try
            {
                DataSet ds = CorrespondenciaExternaRecepcion.ObtenerCorrespondenciaExterna(codCorrespondencia);
                this.gridDetalle.DataSource = ds.Tables[0];
                this.gridDetalle.DataBind();
            }
            catch (Exception ex)
            {

                messageBox.ShowMessage(ex.Message + ex.StackTrace);
            }
        }

        private void LimpiarTodo()
        {
            hdnRemitenteID.Value = "0";
            codigoCorrespondencia = 0;
            CargarTipoCorrespondencia();
            CargarEstado();
            CargarGerencia();
            CargarPrioridad();
            txtNombreRemitente.Text = string.Empty;
            txtFechaCorrespondencia.Text = string.Empty;
            txtContenido.Text = string.Empty;
            gridDetalle.DataSource = null;
            gridDetalle.DataBind();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarTodo();
        }

        protected void gridDetalle_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                
                if (e.CommandName == "EliminarCorrespondencia")
                {
                    ProcesoEliminar(Convert.ToInt32(e.CommandArgument.ToString()));
                }
            }
            catch (Exception ex)
            {
                messageBox.ShowMessage(ex.Message + ex.StackTrace);
            }
        }

        private void ProcesoEliminar(int idCorrespondencia)
        {
            CorrespondenciaExternaRecepcion.EliminarCorrespondenciaExterna(idCorrespondencia);
            codigoCorrespondencia = 0;
            gridDetalle.DataSource = null;
            gridDetalle.DataBind();
            txtNombreRemitente.Text = string.Empty;
            AuditarMovimiento(HttpContext.Current.Request.Url.AbsolutePath, "Eliminó la correspondencia externa número: " + idCorrespondencia, System.Net.Dns.GetHostEntry(Request.ServerVariables["REMOTE_HOST"]).HostName, Convert.ToInt32(this.Session["UserId"].ToString()));
        }
    }
}