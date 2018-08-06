using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Atensoli
{
    public partial class EstadisticaSeguimiento : Seguridad.SeguridadAuditoria
    {
        protected new void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                
            }
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            CargarConsulta();
        }
        private void CargarConsulta()
        {
            try
            {
                int cedulaConsulta = 0;
                if (txtCedula.Text != "")
                {
                    AuditarMovimiento(HttpContext.Current.Request.Url.AbsolutePath, "Consultó la solicitud en seguimiento a la cedula numero: " + txtCedula.Text, System.Net.Dns.GetHostEntry(Request.ServerVariables["REMOTE_HOST"]).HostName, Convert.ToInt32(this.Session["UserId"].ToString()));
                    cedulaConsulta = Convert.ToInt32(txtCedula.Text.Trim());
                }
                else
                {
                    AuditarMovimiento(HttpContext.Current.Request.Url.AbsolutePath, "Consultó todas las solicitudes en seguimiento", System.Net.Dns.GetHostEntry(Request.ServerVariables["REMOTE_HOST"]).HostName, Convert.ToInt32(this.Session["UserId"].ToString()));
                }

                Label2.Text = "Solictudes en seguimiento";
                DataSet ds = ConsultarSolicitud.ObtenerConsultaSolicitudSeguimientoAbierto(cedulaConsulta);
                gridDetalle.DataSource = ds.Tables[0];
                gridDetalle.DataBind();

            }
            catch (Exception ex)
            {

                messageBox.ShowMessage(ex.Message + ex.StackTrace);
            }
        }

        protected void btnExportar_Click(object sender, EventArgs e)
        {
            string nombreArchivo =  "EstadisticaSolicitudesConSeguimiento" + ".xls";
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=" + nombreArchivo);
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                //To Export all pages
                this.gridDetalle.AllowPaging = false;
                CargarConsulta();

                gridDetalle.HeaderRow.BackColor = Color.White;
                foreach (TableCell cell in gridDetalle.HeaderRow.Cells)
                {
                    cell.BackColor = gridDetalle.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in gridDetalle.Rows)
                {
                    row.BackColor = Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = gridDetalle.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = gridDetalle.RowStyle.BackColor;
                        }
                        cell.CssClass = "textmode";
                    }
                }

                gridDetalle.RenderControl(hw);

                //style to format numbers to string
                string style = @"<style> .textmode { } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
                AuditarMovimiento(HttpContext.Current.Request.Url.AbsolutePath, "Exportó a excel movimientos de solictudes con seguimiento", System.Net.Dns.GetHostEntry(Request.ServerVariables["REMOTE_HOST"]).HostName, Convert.ToInt32(this.Session["UserId"].ToString()));
            }
        }
    }
}