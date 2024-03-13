using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Cache;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Atensoli.Vista
{
	public partial class CorrespondenciaDetalleHistorial : System.Web.UI.Page
	{
		string codigoCorrespondencia = string.Empty;
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				if (Request.QueryString["codigoCorrespondencia"] != null)
				{
					codigoCorrespondencia = Request.QueryString["codigoCorrespondencia"];
				}

				lblTitulo.Text = "Historial de la correspondencia número [" + codigoCorrespondencia + "]";
				CargarSeguimientoHistorial();
			}
		}

		private void CargarSeguimientoHistorial()
		{
			try
			{
				DataSet ds = Atensoli.Controlador.CorrespondenciaDetalleHistorial.ObtenerHistorialCorrespondenciaGerencia(Convert.ToInt32(codigoCorrespondencia));
				this.gridDetalle.DataSource = ds.Tables[0];
				this.gridDetalle.DataBind();
			}
			catch (Exception ex)
			{

				messageBox.ShowMessage(ex.Message + ex.StackTrace);
			}
		}
	}
}