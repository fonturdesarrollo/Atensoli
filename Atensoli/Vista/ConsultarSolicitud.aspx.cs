using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Atensoli
{
    public partial class ConsultarSolicitud : Seguridad.SeguridadAuditoria
    {
        protected new void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
               
            }
        }
        private void CargarConsulta()
        {
            try
            {
                int indicaSoloPendientes;
                if(chkPendientes.Checked == true)
                {
                    indicaSoloPendientes = 0;
                }
                else
                {
                    indicaSoloPendientes = 6;
                }
                DataSet ds = ConsultarSolicitud.ObtenerConsultaSolicitud(txtCedula.Text.Trim(), indicaSoloPendientes);
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

        protected void gridDetalle_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

                Solicitud.ActualizarConsultaSolicitud(Convert.ToInt32(e.CommandArgument.ToString()), Convert.ToInt32(Session["UserID"]));
                CargarConsulta();
                messageBox.ShowMessage("Consulta actualizada");

            }
            catch (Exception ex)
            {
                messageBox.ShowMessage(ex.Message + ex.StackTrace);
            }

        }
    }
}