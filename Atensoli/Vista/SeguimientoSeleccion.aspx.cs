using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Atensoli
{
    public partial class SeguimientoSeleccion : Seguridad.SeguridadAuditoria
    {
        protected new void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                EstablecerTitulo();
            }
        }
        private void EstablecerTitulo()
        {
            string codigoObjeto = Request.QueryString["CodigoObjeto"];
            switch (codigoObjeto)
            {
                case "1023":
                    lblTitulo.Text = "Consulta de Seguimiento Especialista de Cobranzas";
                    break;
                case "1026":
                    lblTitulo.Text = "Consulta de Seguimiento Especialista de Financiamiento";
                    break;
                case "1027":
                    lblTitulo.Text = "Consulta de Seguimiento Especialista de Movilidad Estudiantil";
                    break;
                case "1028":
                    lblTitulo.Text = "Consulta de Seguimiento Especialista de Asesoria Legal";
                    break;
                case "1029":
                    lblTitulo.Text = "Consulta de Seguimiento Especialista de Tecnica Automotriz";
                    break;
                case "1030":
                    lblTitulo.Text = "Consulta de Seguimiento Especialista de Control y Seguimiento OAC";
                    break;
                default:
                    break;
            }
        }
        private void CargarConsulta()
        {
            try
            {
                DataSet ds = ConsultarSolicitud.ObtenerConsultaSolicitud(txtCedula.Text.Trim(), 0);
                this.gridDetalle.DataSource = ds.Tables[0];
                this.gridDetalle.DataBind();
            }
            catch (Exception ex)
            {

                messageBox.ShowMessage(ex.Message + ex.StackTrace);
            }
        }
        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            CargarConsulta();
        }
    }
}