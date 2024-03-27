using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

namespace Atensoli
{
    public partial class CorrespondenciaRecepcionGerencia : System.Web.UI.Page
    {
        private string ftpServerUrl = ConfigurationManager.AppSettings.Get("ftpServer");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCorrespondencia();
                CargarInstruccion();
                CargarGerencia();
                CargarEstatus();
                CargarArchivosAdjuntos();
            }
        }

        private void CargarInstruccion()
        {
            ddlInstruccion.Items.Clear();
            ddlInstruccion.Items.Add(new ListItem("--Seleccione la instrucción--", ""));
            String strConnString = ConfigurationManager
            .ConnectionStrings["CallCenterConnectionString"].ConnectionString;
            String strQuery = "";

            strQuery = "Select * From TipoInstruccionCorrespondencia ORDER BY NombreTipoInstruccionCorrespondencia";

            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strQuery;
                    cmd.Connection = con;
                    con.Open();
                    ddlInstruccion.DataSource = cmd.ExecuteReader();
                    ddlInstruccion.DataTextField = "NombreTipoInstruccionCorrespondencia";
                    ddlInstruccion.DataValueField = "TipoInstruccionCorrespondenciaID";
                    ddlInstruccion.DataBind();
                    con.Close();
                }
            }
        }
        private void CargarEstatus()
        {
            ddlEstatus.Items.Clear();
            ddlEstatus.Items.Add(new ListItem("--Seleccione el estatus--", ""));
            String strConnString = ConfigurationManager
            .ConnectionStrings["CallCenterConnectionString"].ConnectionString;
            String strQuery = "";

            strQuery = "Select * From CorrespondenciaEstatus ORDER BY CorrespondenciaEstatusID";

            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strQuery;
                    cmd.Connection = con;
                    con.Open();
                    ddlEstatus.DataSource = cmd.ExecuteReader();
                    ddlEstatus.DataTextField = "NombreCorrespondenciaEstatus";
                    ddlEstatus.DataValueField = "CorrespondenciaEstatusID";
                    ddlEstatus.DataBind();
                    con.Close();
                }
            }
        }
        private void CargarGerencia()
        {
            ddlGerencia.Items.Clear();
            ddlGerencia.Items.Add(new ListItem("--Seleccione la gerencia a remitir--", ""));
            String strConnString = ConfigurationManager
            .ConnectionStrings["CallCenterConnectionString"].ConnectionString;
            String strQuery = "";

            strQuery = "Select * From Gerencia ORDER BY GerenciaID";

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
        private void CargarCorrespondencia()
        {
            try
            {
                DataSet ds = CorrespondenciaRecepcionGerencia.ObtenerCorrespondenciaExterna(Convert.ToInt32(Session["CodigoCorrespondenciaSeleccionada"].ToString()), Convert.ToInt32(Session["CodigoGerenciaEnSeleccion"].ToString()));
                this.gridDetalle.DataSource = ds.Tables[0];
                this.gridDetalle.DataBind();
            }
            catch (Exception ex)
            {

                messageBox.ShowMessage(ex.Message + ex.StackTrace);
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            ProcesoCorrespondencia();
        }

        private void ProcesoCorrespondencia()
        {
            int codigoSeguimientoCorrespondencia = 0;
            try
            {
                if (EsTodoCorrecto() == true)
                {
                    CCorrespondenciaRecepcionGerencia objetoCorrespondencia = new CCorrespondenciaRecepcionGerencia();

                    objetoCorrespondencia.CorrespondenciaID = Convert.ToInt32(Session["CodigoCorrespondenciaSeleccionada"].ToString());
                    objetoCorrespondencia.TipoInstruccionCorrespondenciaID = Convert.ToInt32(ddlInstruccion.SelectedValue);
                    objetoCorrespondencia.ObservacionesSeguimientoCorrespondencia = txtObservaciones.Text.ToUpper().Trim();
                    objetoCorrespondencia.CorrespondenciaEstatusID = Convert.ToInt32(ddlEstatus.SelectedValue);
                    objetoCorrespondencia.SeguridadUsuarioDatosID = Convert.ToInt32(Session["UserId"].ToString());
                    objetoCorrespondencia.GerenciaID = Convert.ToInt32(ddlGerencia.SelectedValue);
                    objetoCorrespondencia.GerenciaRemitenteID = Convert.ToInt32(Session["CodigoGerenciaEnSeleccion"].ToString());

                    codigoSeguimientoCorrespondencia = CorrespondenciaRecepcionGerencia.InsertarSeguimientoCorrespondencia(objetoCorrespondencia);
                    if (codigoSeguimientoCorrespondencia > 0)
                    {
                        //AuditarMovimiento(HttpContext.Current.Request.Url.AbsolutePath, "Agregó seguimiento a la correspondencia número: " + codigoSeguimientoCorrespondencia, System.Net.Dns.GetHostEntry(Request.ServerVariables["REMOTE_HOST"]).HostName, Convert.ToInt32(this.Session["UserId"].ToString()));
                        messageBox.ShowMessage("Recepción de correspondencia agregada");
                        CargarCorrespondencia();
                        LimpiarTodo();
                    }
                }

            }
            catch (Exception ex)
            {

                messageBox.ShowMessage(ex.Message + ex.StackTrace);
            }

        }
        private void LimpiarTodo()
        {
            txtObservaciones.Text = string.Empty;
            CargarInstruccion();
            CargarGerencia();
            CargarEstatus();
        }
        private bool EsTodoCorrecto()
        {
            bool resultado = true;
            if (gridDetalle.Rows.Count < 1)
            {
                resultado = false;
                messageBox.ShowMessage("No puede registrar correspondencia que no esté asignada a su gerencia.");
            }
            return resultado;
        }

        protected void btnHistorial_Click(object sender, EventArgs e)
        {
            Response.Redirect("CorrespondenciaHistorial.aspx", false);
        }

        protected void UploadButton_Click(object sender, EventArgs e)
        {
            if (FileUploadControl.HasFiles)
            {
                try
                {
                    string folderName = "";

                    if (Session["CodigoCorrespondenciaSeleccionada"] != null)
                    {
                        folderName = Session["CodigoCorrespondenciaSeleccionada"].ToString();
                    }

                    string folderPath = ftpServerUrl + "/" + folderName;

                    if (!ExisteCarpeta(folderPath))
                    {

                        FtpWebRequest createFolderRequest = (FtpWebRequest)WebRequest.Create(folderPath);
                        createFolderRequest.Method = WebRequestMethods.Ftp.MakeDirectory;
                        createFolderRequest.Credentials = new NetworkCredential(string.Empty, string.Empty);
                        createFolderRequest.GetResponse();
                    }

                    StatusLabel.Text = string.Empty;

                    foreach (var file in FileUploadControl.PostedFiles)
                    {
                        string fileName = Path.GetFileName(file.FileName);
                        string ftpFilePath = folderPath + "/" + fileName;

                        FtpWebRequest ftpRequest = (FtpWebRequest)WebRequest.Create(ftpFilePath);
                        ftpRequest.Method = WebRequestMethods.Ftp.UploadFile;
                        ftpRequest.Credentials = new NetworkCredential(string.Empty, string.Empty);
                        ftpRequest.ReadWriteTimeout = 360000;

                        using (Stream ftpStream = ftpRequest.GetRequestStream())
                        {
                            file.InputStream.CopyTo(ftpStream);
                        }

                        StatusLabel.Text += $"Archivo '{fileName}' adjuntado correctamente a la correspondencia<br />";
                    }

                    CargarArchivosAdjuntos();
                }
                catch (Exception ex)
                {
                    StatusLabel.Text = "Error adjuntando archivos: " + ex.Message;
                }
            }
            else
            {
                StatusLabel.Text = "Por favor seleccione un archivo para adjuntar.";
            }
        }

        bool ExisteCarpeta(string folderPath)
        {
            try
            {
                FtpWebRequest ftpRequest = (FtpWebRequest)WebRequest.Create(folderPath);
                ftpRequest.Method = WebRequestMethods.Ftp.ListDirectory;
                ftpRequest.Credentials = new NetworkCredential(string.Empty, string.Empty);

                using (FtpWebResponse ftpResponse = (FtpWebResponse)ftpRequest.GetResponse())
                {
                    return true;
                }
            }
            catch (WebException ex)
            {
                FtpWebResponse response = (FtpWebResponse)ex.Response;
                if (response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable)
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }

        private void CargarArchivosAdjuntos()
        {
            string ftpDirectory = "";
            if (Session["CodigoCorrespondenciaSeleccionada"] != null)
            {
                try
                {
					ftpDirectory = Session["CodigoCorrespondenciaSeleccionada"].ToString();

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

            if (Session["CodigoCorrespondenciaSeleccionada"] != null)
            {
				string ftpDirectory = Session["CodigoCorrespondenciaSeleccionada"].ToString();

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

		protected void EliminarArchivo(object sender, EventArgs e)
		{
			string fileName = ((Button)sender).CommandArgument;
			string ftpServer = ftpServerUrl;
			string ftpUsername = string.Empty;
			string ftpPassword = string.Empty;

            if (Session["CodigoCorrespondenciaSeleccionada"] != null)
            {
				string ftpDirectory = Session["CodigoCorrespondenciaSeleccionada"].ToString();
				string fileUrl = $"{ftpServer}/{ftpDirectory}/{fileName}";

				try
				{
					FtpWebRequest request = (FtpWebRequest)WebRequest.Create(fileUrl);
					request.Method = WebRequestMethods.Ftp.DeleteFile;
					request.Credentials = new NetworkCredential(ftpUsername, ftpPassword);

					using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
					{
						CargarArchivosAdjuntos();
					}
				}
				catch (WebException ex)
				{
					// 
				}
			}
		}

		public class DetalleDelArchivo
	    {
		    public string Name { get; set; }

		}
	}
}