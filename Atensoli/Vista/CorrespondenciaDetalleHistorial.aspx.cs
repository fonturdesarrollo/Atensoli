using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Cache;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static Atensoli.CorrespondenciaRecepcionGerencia;

namespace Atensoli.Vista
{
	public partial class CorrespondenciaDetalleHistorial : System.Web.UI.Page
	{
		string codigoCorrespondencia = string.Empty;
		private string ftpServerUrl = ConfigurationManager.AppSettings.Get("ftpServer");
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
				CargarArchivosAdjuntos();
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
		private void CargarArchivosAdjuntos()
		{
			string ftpDirectory = "";
			if (Request.QueryString["codigoCorrespondencia"] != null)
			{
				try
				{
					ftpDirectory = codigoCorrespondencia;

					FtpWebRequest ftpRequest = (FtpWebRequest)WebRequest.Create(ftpServerUrl + "/" + ftpDirectory);
					ftpRequest.Method = WebRequestMethods.Ftp.ListDirectory;
					ftpRequest.Credentials = new NetworkCredential(string.Empty, string.Empty);

					using (FtpWebResponse ftpResponse = (FtpWebResponse)ftpRequest.GetResponse())
					using (StreamReader reader = new StreamReader(ftpResponse.GetResponseStream()))
					{
						string directoryListing = reader.ReadToEnd();
						var ftpFiles = directoryListing.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
						List<DetalleDelArchivo> files = new List<DetalleDelArchivo>();
						foreach (var item in ftpFiles)
						{
							files.Add(new DetalleDelArchivo { Name = item });
						}

						rptFiles.DataSource = files;
						rptFiles.DataBind();
						reader.Close();
					}
				}
				catch (Exception)
				{
					//
				}
			}
		}

		protected void DescargarArchivo(object sender, EventArgs e)
		{
			string fileName = ((Button)sender).CommandArgument;
			string ftpServer = ftpServerUrl;
			string ftpUsername = string.Empty;
			string ftpPassword = string.Empty;

			if (Request.QueryString["codigoCorrespondencia"] != null)
			{
				string ftpDirectory = Request.QueryString["codigoCorrespondencia"].ToString();

				string fileUrl = $"{ftpServer}/{ftpDirectory}/{fileName}";

				FtpWebRequest request = (FtpWebRequest)WebRequest.Create(fileUrl);
				request.Method = WebRequestMethods.Ftp.DownloadFile;
				request.Credentials = new NetworkCredential(ftpUsername, ftpPassword);

				using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
				{
					Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);

					using (Stream ftpStream = response.GetResponseStream())
					{
						byte[] buffer = new byte[4096];
						int bytesRead;
						while ((bytesRead = ftpStream.Read(buffer, 0, buffer.Length)) > 0)
						{
							Response.OutputStream.Write(buffer, 0, bytesRead);
						}
					}
				}

				Response.End();
			}
		}
	}
}