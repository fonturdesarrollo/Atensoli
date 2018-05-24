using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Atensoli
{
    [System.Runtime.InteropServices.Guid("41556A1F-56A6-41B7-9509-F6F5153F4487")]
    public partial class EstadisticasGenerales : Seguridad.SeguridadAuditoria
    {
        protected new void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                txtFechaRegistro.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
                txtFechaHasta.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
                CargarPorTransportista();
                CargarPorEstado();
                CargarPorTipoSolicitud();
                CargarPorTipoRemitido();
                CargarTotales();
            }
        }

        private void CargarPorTransportista()
        {
            try
            {

                DataSet ds = Estadisticas.ObtenerDetalleEstadisticaPorTransportistasAtendidos(FechaDesdeHasta(false), FechaDesdeHasta(true));
                gridDetalle4.DataSource = ds.Tables[0];
                gridDetalle4.DataBind();
            }
            catch (Exception ex)
            {

                messageBox.ShowMessage(ex.Message + ex.StackTrace);
            }
        }

        private void CargarTotales()
        {
            try
            {

                SqlDataReader dr = Estadisticas.ObtenerTotalSolicitudes(FechaDesdeHasta(false), FechaDesdeHasta(true));
                if(dr.HasRows)
                {
                    while(dr.Read())
                    {
                        lblTitulo.Text = "Total solicitudes registradas en la fecha seleccionada: ["  + dr["Cantidad"] +"]";
                    }
                }

            }
            catch (Exception ex)
            {

                messageBox.ShowMessage(ex.Message);
            }
        }
        private void CargarPorEstado()
        {
            try
            {

                DataSet ds = Estadisticas.ObtenerDetalleEstadisticaPorEstado(FechaDesdeHasta(false), FechaDesdeHasta(true));
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

                DataSet ds = Estadisticas.ObtenerDetalleEstadisticaPorTipoSolicitud(FechaDesdeHasta(false), FechaDesdeHasta(true));
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
                DataSet ds = Estadisticas.ObtenerDetalleEstadisticaPorTipoRemitido(FechaDesdeHasta(false), FechaDesdeHasta(true));
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
            CargarPorTransportista();
            CargarPorEstado();
            CargarPorTipoSolicitud();
            CargarPorTipoRemitido();
            CargarTotales();
        }

        protected void gridDetalle_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType == DataControlRowType.Footer)
            {

                SqlDataReader dr;
                dr = Estadisticas.TotalSolicitudesPorEstado(FechaDesdeHasta(false), FechaDesdeHasta(true));
                if(dr.HasRows)
                {
                    while(dr.Read())
                    {
                        e.Row.Cells[0].Text = "Total por estado: ";
                        e.Row.Cells[1].Text =  dr["Cantidad"].ToString();
                    }
                }
                dr.Close();
 
            }
            
        }
        private string FechaDesdeHasta(bool EsFechaHasta)
        {
            string fechaSolicitud = "";
            string fechaSolicitudHasta = "";
            DateTime fechaDesde = Convert.ToDateTime(txtFechaRegistro.Text.ToString());
            DateTime fechaHasta = Convert.ToDateTime(txtFechaHasta.Text.ToString());

            fechaSolicitud = fechaDesde.ToString("yyyy-dd-MM");
            fechaSolicitudHasta = fechaHasta.ToString("yyyy-dd-MM") + "  23:59:59.999";
            if(EsFechaHasta != true)
            {
                return fechaSolicitud;
            }
            {
                return fechaSolicitudHasta;
            }
        }

        protected void gridDetalle2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Footer)
            {

                SqlDataReader dr;
                dr = Estadisticas.TotalPorTipoSolicitud(FechaDesdeHasta(false), FechaDesdeHasta(true));
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        e.Row.Cells[0].Text = "Total por tipo solicitud: ";
                        e.Row.Cells[1].Text = dr["Total"].ToString();
                    }
                }
                dr.Close();
            }
        }

        protected void gridDetalle3_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                SqlDataReader dr;
                dr = Estadisticas.TotalPorTipoRemitido(FechaDesdeHasta(false), FechaDesdeHasta(true));
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        e.Row.Cells[0].Text = "Total por tipo remitido: ";
                        e.Row.Cells[1].Text = dr["Total"].ToString();
                    }
                }
                dr.Close();
            }
        }

        protected void gridDetalle4_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                SqlDataReader dr;
                dr = Estadisticas.TotalPorTransportistas(FechaDesdeHasta(false), FechaDesdeHasta(true));
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        e.Row.Cells[0].Text = "Total transportistas atendidos: ";
                        e.Row.Cells[1].Text = dr["Total"].ToString();
                    }
                }
                dr.Close();
            }
        }
    }
}