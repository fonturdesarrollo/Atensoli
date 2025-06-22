using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Atensoli.Controlador;
using Newtonsoft.Json;

namespace Atensoli.Vista
{
	public partial class CorrespondenciaInterna : System.Web.UI.Page
	{
		private int codigoGerenciaSeleccionada = 0;
		protected void Page_Load(object sender, EventArgs e)
		{
			Session.Remove("CodigoCorrespondenciaSeleccionada");
			Session.Remove("CodigoGerenciaEnSeleccion");
			if (!string.IsNullOrEmpty(ddlGerencia.SelectedValue))
			{
				codigoGerenciaSeleccionada = Convert.ToInt32(ddlGerencia.SelectedValue);
			}
			if (!IsPostBack)
			{
				CargarGerencia();
				CargarCorrespondenciasRemitidas();
				CargarCorrespondenciasRecibidas();
			}				
		}
		private void CargarCorrespondenciasRemitidas()
		{
			try
			{
				string historialUrl = "~/Vista/CorrespondenciaInternaRecepcionGerencia.aspx";

				if(!string.IsNullOrEmpty(ddlGerencia.SelectedValue))
				{
					codigoGerenciaSeleccionada = Convert.ToInt32(ddlGerencia.SelectedValue);
				}

				SqlDataReader reader = Atensoli.Controlador.CorrespondenciaInterna.ObtenerCorrespondenciasInternasRemitidas(0, codigoGerenciaSeleccionada);
				while (reader.Read())
				{
					HtmlTableRow row = new HtmlTableRow();
					row = new HtmlTableRow();
					HtmlTableCell cell = new HtmlTableCell();

					HyperLink link = new HyperLink();
					link.Text = reader[0].ToString();
					link.NavigateUrl = $"{historialUrl}?codigoCorrespondencia={reader[0].ToString()}&codigoGerencia={reader[17].ToString()}";
					cell.Controls.Add(link);
					row.Cells.Add(cell);

					cell = new HtmlTableCell();
					cell.InnerText = reader[1].ToString();
					row.Cells.Add(cell);
					cell = new HtmlTableCell();
					cell.InnerText = reader[2].ToString();
					row.Cells.Add(cell);
					cell = new HtmlTableCell();
					cell.InnerText = reader[3].ToString();
					row.Cells.Add(cell);
					cell = new HtmlTableCell();
					cell.InnerText = reader[18].ToString();
					row.Cells.Add(cell);
					cell = new HtmlTableCell();
					cell.InnerText = reader[5].ToString();
					row.Cells.Add(cell);
					cell = new HtmlTableCell();
					cell.InnerText = reader[6].ToString();
					row.Cells.Add(cell);
					cell = new HtmlTableCell();
					cell.InnerText = reader[16].ToString();
					row.Cells.Add(cell);
					cell = new HtmlTableCell();
					cell.InnerText = reader[8].ToString();
					row.Cells.Add(cell);

					dataTableRemitidas.Rows.Add(row);
				}

			}
			catch (Exception ex)
			{
				messageBox.ShowMessage(ex.Message + ex.StackTrace);
			}
		}

		private void CargarCorrespondenciasRecibidas()
		{
			try
			{
				string historialUrl = "~/Vista/CorrespondenciaInternaRecepcionGerencia.aspx";

				if (!string.IsNullOrEmpty(ddlGerencia.SelectedValue))
				{
					codigoGerenciaSeleccionada = Convert.ToInt32(ddlGerencia.SelectedValue);
				}

				SqlDataReader reader = Atensoli.Controlador.CorrespondenciaInterna.ObtenerCorrespondenciasInternasRecibidas(0, codigoGerenciaSeleccionada);
				
				while (reader.Read())
				{
					HtmlTableRow row = new HtmlTableRow();
					row = new HtmlTableRow();
					HtmlTableCell cell = new HtmlTableCell();

					HyperLink link = new HyperLink();
					link.Text = reader[0].ToString();
					link.NavigateUrl = $"{historialUrl}?codigoCorrespondencia={reader[0].ToString()}&codigoGerencia={reader[17].ToString()}";
					cell.Controls.Add(link);
					row.Cells.Add(cell);
					cell = new HtmlTableCell();
					cell.InnerText = reader[1].ToString();
					row.Cells.Add(cell);
					cell = new HtmlTableCell();
					cell.InnerText = reader[2].ToString();
					row.Cells.Add(cell);
					cell = new HtmlTableCell();
					cell.InnerText = reader[3].ToString();
					row.Cells.Add(cell);
					cell = new HtmlTableCell();
					cell.InnerText = reader[18].ToString();
					row.Cells.Add(cell);
					cell = new HtmlTableCell();
					cell.InnerText = reader[5].ToString();
					row.Cells.Add(cell);
					cell = new HtmlTableCell();
					cell.InnerText = reader[6].ToString();
					row.Cells.Add(cell);
					cell = new HtmlTableCell();
					cell.InnerText = reader[16].ToString();
					row.Cells.Add(cell);
					cell = new HtmlTableCell();
					cell.InnerText = reader[8].ToString();
					row.Cells.Add(cell);

					dataTableRecibidas.Rows.Add(row);
				}
			}
			catch (Exception ex)
			{
				messageBox.ShowMessage(ex.Message + ex.StackTrace);
			}
		}

		private void CargarGerencia()
		{
			ddlGerencia.Items.Clear();
			String strConnString = ConfigurationManager
			.ConnectionStrings["CallCenterConnectionString"].ConnectionString;
			String strQuery = "";

			if (Seguridad.SeguridadUsuario.GrupoIDUsuarioLogin(Convert.ToInt32(this.Session["UserId"].ToString())) == 10)
			{
				ddlGerencia.Items.Add(new ListItem("--Todas las Gerencias--", ""));
				strQuery = "Select * From Gerencia ORDER BY GerenciaID";
			}
			else
			{
				if(Request.QueryString["CodigoGerencia"] != null)
				{
					strQuery = "Select * From Gerencia WHERE GerenciaID = " + int.Parse(Request.QueryString["CodigoGerencia"]);
				}
			}

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
		protected void btnConsultar_Click(object sender, EventArgs e)
		{
			Response.Redirect("~/Vista/CorrespondenciaInternaCreacion.aspx?CodigoGerencia="+ ddlGerencia.SelectedValue, false);
		}
	}
}