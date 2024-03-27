using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Atensoli.Vista
{
	public partial class CorrespondenciaEstadisticasPorGerencia : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			Session.Remove("CodigoCorrespondenciaSeleccionada");
			Session.Remove("CodigoGerenciaEnSeleccion");
			if (!IsPostBack)
			{
				CargarGerencia();
			}				
		}
		private void CargarCorrespondencia()
		{
			try
			{
				string historialUrl = "~/Vista/CorrespondenciaDetalleHistorial.aspx";
				int codigoGerenciaSeleccionada = 0;

				if(!string.IsNullOrEmpty(ddlGerencia.SelectedValue))
				{
					codigoGerenciaSeleccionada = Convert.ToInt32(ddlGerencia.SelectedValue);
				}

				SqlDataReader reader = Atensoli.Controlador.CorrespondenciaEstadisticasPorGerencia.ObtenerCorrespondenciasExternas(0, codigoGerenciaSeleccionada);
				HtmlTableRow row = new HtmlTableRow();
				while (reader.Read())
				{
					row = new HtmlTableRow();
					HtmlTableCell cell = new HtmlTableCell();

					HyperLink link = new HyperLink();
					link.Text = reader[0].ToString();
					link.NavigateUrl =  $"{historialUrl}?codigoCorrespondencia={reader[0].ToString()}"; 
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

					dataTable.Rows.Add(row);
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
			ddlGerencia.Items.Add(new ListItem("--Todas las Gerencias--", ""));
			String strConnString = ConfigurationManager
			.ConnectionStrings["CallCenterConnectionString"].ConnectionString;
			String strQuery = "";

			if (Seguridad.SeguridadUsuario.GrupoIDUsuarioLogin(Convert.ToInt32(this.Session["UserId"].ToString())) == 34)
			{
				strQuery = "Select * From Gerencia WHERE GerenciaID = 1 ORDER BY GerenciaID";
			}
			else
			{
				if (Seguridad.SeguridadUsuario.ObjetoIDUsuarioLogin(Convert.ToInt32(this.Session["UserId"].ToString())) == 1033)
				{
					strQuery = "Select * From Gerencia WHERE GerenciaID = 1 ORDER BY GerenciaID";
				}
				else
				{
					strQuery = "Select * From Gerencia ORDER BY GerenciaID";
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
			CargarCorrespondencia();
		}
	}
}