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
    public partial class SeguimientoOAC : Seguridad.SeguridadAuditoria
    {
        private static DataTable dtGrid;
        private static string nombreValidoPostulante ="";
        protected new void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (dtGrid != null)
                {
                    dtGrid.Clear();
                }
                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[3] { new DataColumn("CedulaPostulante"), new DataColumn("NombrePostulante"), new DataColumn("Telefono") });
                ViewState["Soporte"] = dt;
                this.BindGrid();
                lblTitulo.Text = "Inicio del seguimiento por parte de la OAC a la solicitud " + Session["SolicitudParaSeguimientoID"].ToString();
                CargarConsulta();
                CargarTipoAccion();
                CargarTipoRemitido();
            }
        }
        private void CargarTipoAccion()
        {
            ddlAccionTramite.Items.Clear();
            ddlAccionTramite.Items.Add(new ListItem("--Seleccione el tipo de acción a tomar--", ""));
            String strConnString = ConfigurationManager
            .ConnectionStrings["CallCenterConnectionString"].ConnectionString;
            String strQuery = "";

            strQuery = "select * From TipoAccion ORDER BY TipoAccionID";

            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strQuery;
                    cmd.Connection = con;
                    con.Open();
                    ddlAccionTramite.DataSource = cmd.ExecuteReader();
                    ddlAccionTramite.DataTextField = "NombreTipoAccion";
                    ddlAccionTramite.DataValueField = "TipoAccionID";
                    ddlAccionTramite.DataBind();
                    con.Close();
                }
            }
        }
        private void CargarTipoRemitido()
        {
            ddlTipoRemitido.Items.Clear();
            ddlTipoRemitido.Items.Add(new ListItem("--Seleccione a quien será remitido--", ""));
            String strConnString = ConfigurationManager
            .ConnectionStrings["CallCenterConnectionString"].ConnectionString;
            String strQuery = "";

            strQuery = "SELECT * FROM Gerencia ORDER BY GerenciaID";

            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strQuery;
                    cmd.Connection = con;
                    con.Open();
                    ddlTipoRemitido.DataSource = cmd.ExecuteReader();
                    ddlTipoRemitido.DataTextField = "NombreGerencia";
                    ddlTipoRemitido.DataValueField = "GerenciaID";
                    ddlTipoRemitido.DataBind();
                    con.Close();
                }
            }
        }
        private void CargarConsulta()
        {
            try
            {
                DataSet ds = ConsultarSolicitud.ObtenerSolicitudPorID(Convert.ToInt32(Session["SolicitudParaSeguimientoID"].ToString()));
                this.gridDetalle.DataSource = ds.Tables[0];
                this.gridDetalle.DataBind();
            }
            catch (Exception ex)
            {

                messageBox.ShowMessage(ex.Message + ex.StackTrace);
            }
        }
        protected void BindGrid()
        {
            grdSoporte.DataSource = (DataTable)ViewState["Soporte"];
            grdSoporte.DataBind();
        }
        private bool EsSoporteFisicoAgregado()
        {
            bool resultado = false;
            if (dtGrid != null)
            {
                for (int i = 0; i < dtGrid.Rows.Count; i++)
                {
                    DataRow dr = dtGrid.Rows[i];
                    if (dr["CedulaPostulante"].ToString() == txtCedulaPostulante.Text)
                    {
                        resultado = true;
                    }
                }
            }

            return resultado;
        }
        private void AgregarPostulante()
        {
            if(EsTodoCorrectoPostulante())
            {
                if (EsSoporteFisicoAgregado() == false)
                {
                    if (txtCedulaPostulante.Text != "")
                    {
                        if (EsSolicitanteEnsaime())
                        {
                            dtGrid = (DataTable)ViewState["Soporte"];
                            dtGrid.Rows.Add(txtCedulaPostulante.Text, nombreValidoPostulante, txtTelefonoPostulante.Text);
                            ViewState["Soporte"] = dtGrid;
                            this.BindGrid();
                            grdSoporte.DataBind();
                            nombreValidoPostulante = string.Empty;
                        }
                        else
                        {
                            messageBox.ShowMessage("Cedula no registrada en el SAIME");
                            nombreValidoPostulante = string.Empty;
                        }

                    }
                    else
                    {
                        messageBox.ShowMessage("Debe colocar la cedula del postulante");
                    }
                }
                else
                {
                    messageBox.ShowMessage("Ya agregó a la lista este postulante [" + txtCedulaPostulante.Text + "]");
                }
            }
        }
        private bool EsTodoCorrectoPostulante()
        {
            bool resultado = true;
            if(txtCedulaPostulante.Text == "")
            {
                resultado = false;
                messageBox.ShowMessage("Debe indicar el numero de cedula del postulante");
            }
            if (txtTelefonoPostulante.Text == "")
            {
                resultado = false;
                messageBox.ShowMessage("Debe indicar el numero de telefono del postulante");
            }
            return resultado;
        }

        private bool EsSolicitanteEnsaime()
        {
            bool resultado = false;
            int contador = 0;
            try
            {
                foreach (var saime in Saime.ObtenerDatosSaime(txtCedulaPostulante.Text))
                {
                    //Si ocurre algún error de conexión en la BD SAIME se sale de la busqueda
                    if (saime.Contains("ERROR "))
                    {
                        break;
                    }
                    switch (contador)
                    {
                        case 0:
                            contador = 1;
                            resultado = true;
                            break;
                        case 1:
                            nombreValidoPostulante = saime;
                            contador = 2;
                            resultado = true;
                            break;
                        case 2:
                            nombreValidoPostulante = nombreValidoPostulante + " " +  saime;
                            contador = 3;
                            resultado = true;
                            break;
                        case 3:
                            resultado = true;
                            break;
                        case 4:
                            resultado = true;
                            break;
                    }

                }
            }
            catch (Exception)
            {
                resultado = false;
            }
            return resultado;
        }
        protected void btnAgregarPostulante_Click(object sender, EventArgs e)
        {
            AgregarPostulante();
        }

        protected void grdSoporte_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            for (int i = dtGrid.Rows.Count - 1; i >= 0; i--)
            {
                DataRow dr = dtGrid.Rows[i];
                if (dr["CedulaPostulante"].ToString() == e.CommandArgument.ToString())
                {
                    dr.Delete();
                    ViewState["Soporte"] = dtGrid;
                    this.BindGrid();
                    grdSoporte.DataBind();
                }
            }
        }
    private void ProcesoSeguimientoOAC()
    {
            try
            {
                CSeguimientoOAC objetoSeguimientoOAC = new CSeguimientoOAC();
                objetoSeguimientoOAC.SolicitudID = Convert.ToInt32(Session["SolicitudParaSeguimientoID"]);
                objetoSeguimientoOAC.TipoAccionID = Convert.ToInt32(ddlAccionTramite.SelectedValue);
                objetoSeguimientoOAC.GerenciaID = Convert.ToInt32(ddlTipoRemitido.SelectedValue);
                objetoSeguimientoOAC.ObservacionSeguimiento = txtObservaciones.Text.ToUpper().Trim();
                objetoSeguimientoOAC.SeguridadUsuarioDatosID = Convert.ToInt32(Session["UserID"]);

                if (SeguimientoOAC.InsertarSeguimiento(objetoSeguimientoOAC) > 0)
                {
                    messageBox.ShowMessage("Registro actualizado");
                }
            }
            catch (Exception ex)
            {

                messageBox.ShowMessage(ex.Message + ex.StackTrace);
            }


    }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            ProcesoSeguimientoOAC();
        }
    }
}