using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Atensoli
{
    public partial class EstadisticasGenerales : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                txtFechaRegistro.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
                CargarPorEstado();
                CargarPorTipoSolicitud();
                CargarPorTipoRemitido();
            }
        }
        private void CargarPorEstado()
        {
            try
            {
                string fechaSolicitud = "";

                fechaSolicitud = txtFechaRegistro.Text;
                DataSet ds = Estadisticas.ObtenerDetalleEstadisticaPorEstado(fechaSolicitud);
                this.gridDetalle.DataSource = ds.Tables[0];
                this.gridDetalle.DataBind();
            }
            catch (Exception ex)
            {

                messageBox.ShowMessage(ex.Message + ex.StackTrace);
            }  
        }
        private void CargarPorTipoSolicitud()
        {
            try
            {
                string fechaSolicitud = "";

                fechaSolicitud = txtFechaRegistro.Text;
                DataSet ds = Estadisticas.ObtenerDetalleEstadisticaPorTipoSolicitud(fechaSolicitud);
                this.gridDetalle2.DataSource = ds.Tables[0];
                this.gridDetalle2.DataBind();
            }
            catch (Exception ex)
            {

                messageBox.ShowMessage(ex.Message + ex.StackTrace);
            }
        }
        private void CargarPorTipoRemitido()
        {
            try
            {
                string fechaSolicitud = "";

                fechaSolicitud = txtFechaRegistro.Text;
                DataSet ds = Estadisticas.ObtenerDetalleEstadisticaPorTipoRemitido(fechaSolicitud);
                this.gridDetalle3.DataSource = ds.Tables[0];
                this.gridDetalle3.DataBind();
            }
            catch (Exception ex)
            {

                messageBox.ShowMessage(ex.Message + ex.StackTrace);
            }
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            CargarPorEstado();
            CargarPorTipoSolicitud();
            CargarPorTipoRemitido();
        }
    }
}