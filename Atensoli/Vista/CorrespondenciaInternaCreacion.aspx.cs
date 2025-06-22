using Atensoli.Controlador;
using Seguridad;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Atensoli
{
    public partial class CorrespondenciaInternaCreacion : System.Web.UI.Page
	{

		private string ftpServerUrl = ConfigurationManager.AppSettings.Get("ftpServer");
        private string nombreGerenciaRemitente = string.Empty;
		protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Session["codigoCorrespondenciaAgregada"] = "0";
                CargarTipoCorrespondencia();
                CargarGerencia();
                CargarPrioridad();
				UploadButton.Visible = false;
                FileUploadControl.Visible = false;
			}
        }

        private void CargarPrioridad()
        {
            ddlPrioridad.Items.Clear();
            ddlPrioridad.Items.Add(new ListItem("--Seleccione la prioridad--", ""));
            String strConnString = ConfigurationManager
            .ConnectionStrings["CallCenterConnectionString"].ConnectionString;
            String strQuery = "";

            strQuery = "Select * From CorrespondenciaPrioridad ORDER BY CorrespondenciaPrioridadID";

            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strQuery;
                    cmd.Connection = con;
                    con.Open();
                    ddlPrioridad.DataSource = cmd.ExecuteReader();
                    ddlPrioridad.DataTextField = "NombreCorrespondenciaPrioridad";
                    ddlPrioridad.DataValueField = "CorrespondenciaPrioridadID";
                    ddlPrioridad.DataBind();
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

            if (Seguridad.SeguridadUsuario.GrupoIDUsuarioLogin(Convert.ToInt32(this.Session["UserId"].ToString())) ==34)
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

        private void CargarTipoCorrespondencia()
        {
            ddlTipoCorrespondencia.Items.Clear();
            ddlTipoCorrespondencia.Items.Add(new ListItem("--Seleccione el tipo de correspondencia--", ""));
            String strConnString = ConfigurationManager
            .ConnectionStrings["CallCenterConnectionString"].ConnectionString;
            String strQuery = "";

            strQuery = "select * From TipoCorrespondencia ORDER BY TipoCorrespondenciaID";

            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strQuery;
                    cmd.Connection = con;
                    con.Open();
                    ddlTipoCorrespondencia.DataSource = cmd.ExecuteReader();
                    ddlTipoCorrespondencia.DataTextField = "NombreTipoCorrespondencia";
                    ddlTipoCorrespondencia.DataValueField = "TipoCorrespondenciaID";
                    ddlTipoCorrespondencia.DataBind();
                    con.Close();
                }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            ProcesoInsertar();
        }

        private void ProcesoInsertar()
        {
            try
            {
                CCorrespondenciaInterna objetoCorrespondencia = new CCorrespondenciaInterna();
                objetoCorrespondencia.CorrespondenciaID = Convert.ToInt32(Session["codigoCorrespondenciaAgregada"]);
                objetoCorrespondencia.TipoCorrespondenciaID = Convert.ToInt32(ddlTipoCorrespondencia.SelectedValue);
                objetoCorrespondencia.CorrespondenciaRemitenteID = ObtenerCodigoGerenciaPorRemitente();
                objetoCorrespondencia.NombreCorrespondenciaRemitente = nombreGerenciaRemitente;
                objetoCorrespondencia.EstadoID = 24;
                objetoCorrespondencia.FechaCorrespondencia = txtFechaCorrespondencia.Text.Trim();
                objetoCorrespondencia.ContenidoCorrespondencia = txtContenido.Text.ToUpper().Trim();
                objetoCorrespondencia.CorrespondenciaPrioridadID = Convert.ToInt32(ddlPrioridad.SelectedValue);
                objetoCorrespondencia.GerenciaID = Convert.ToInt32(ddlGerencia.SelectedValue);
                objetoCorrespondencia.SeguridadUsuarioDatosID = Convert.ToInt32(Session["UserId"].ToString());


                Session["codigoCorrespondenciaAgregada"]  = CorrespondenciaInterna.InsertarCorrespondenciaInterna(objetoCorrespondencia);
                if (Convert.ToInt32(Session["codigoCorrespondenciaAgregada"].ToString()) > 0)
                    {
                       SeguridadAuditoria.AuditarMovimiento(HttpContext.Current.Request.Url.AbsolutePath, "Agregó correspondencia externa número: " + Session["codigoCorrespondenciaAgregada"].ToString(), string.Empty, Convert.ToInt32(this.Session["UserId"].ToString()));
                        messageBox.ShowMessage("Correspondencia registrada exitosamente.");
                        CargarCorrespondencia(Convert.ToInt32(Session["codigoCorrespondenciaAgregada"].ToString()));
					    btnGuardar.Visible = false;
						UploadButton.Visible = true;    
                        FileUploadControl.Visible = true;
					    StatusLabel.Visible = true;
				}
            }
            catch (Exception ex)
            {

                messageBox.ShowMessage(ex.Message + ex.StackTrace);
            }

        }

        private void CargarCorrespondencia(int codCorrespondencia)
        {
            try
            {
                DataSet ds = CorrespondenciaInterna.ObtenerCorrespondenciaInterna(codCorrespondencia);
                this.gridDetalle.DataSource = ds.Tables[0];
                this.gridDetalle.DataBind();
            }
            catch (Exception ex)
            {

                messageBox.ShowMessage(ex.Message + ex.StackTrace);
            }
        }

        private void LimpiarTodo()
        {
            Session["codigoCorrespondenciaAgregada"] = 0;
            CargarTipoCorrespondencia();
            CargarGerencia();
            CargarPrioridad();
            txtFechaCorrespondencia.Text = string.Empty;
            txtContenido.Text = string.Empty;
            gridDetalle.DataSource = null;
			UploadButton.Visible = false;
			FileUploadControl.Visible = false;
            StatusLabel.Text = string.Empty;
			StatusLabel.Visible = false;
			gridDetalle.DataBind();
			btnGuardar.Visible = true;
		}

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarTodo();
        }

        protected void gridDetalle_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                
                if (e.CommandName == "EliminarCorrespondencia")
                {
                    ProcesoEliminar(Convert.ToInt32(e.CommandArgument.ToString()));
                }
            }
            catch (Exception ex)
            {
                messageBox.ShowMessage(ex.Message + ex.StackTrace);
            }
        }

        private void ProcesoEliminar(int idCorrespondencia)
        {
            CorrespondenciaExternaRecepcion.EliminarCorrespondenciaExterna(idCorrespondencia);
			
            EliminarArchivosEnCarpeta(Session["codigoCorrespondenciaAgregada"].ToString());

			Session["codigoCorrespondenciaAgregada"] = "0";
            gridDetalle.DataSource = null;
            gridDetalle.DataBind();
			UploadButton.Visible = false;
			FileUploadControl.Visible = false;
			StatusLabel.Text = string.Empty;
			StatusLabel.Visible = false;
			btnGuardar.Visible = true;
			SeguridadAuditoria.AuditarMovimiento(HttpContext.Current.Request.Url.AbsolutePath, "Eliminó la correspondencia externa número: " + idCorrespondencia, string.Empty, Convert.ToInt32(this.Session["UserId"].ToString()));
        }
		protected void UploadButton_Click(object sender, EventArgs e)
		{
			if (FileUploadControl.HasFiles)
			{
				try
				{
					string folderName = "";

					if (Session["codigoCorrespondenciaAgregada"] != null)
                    {
                        folderName = Session["codigoCorrespondenciaAgregada"].ToString();
					}

					string folderPath = ftpServerUrl + "/" + folderName;

					if (!ExisteCarpeta(folderPath))
                    {

						FtpWebRequest createFolderRequest = (FtpWebRequest)WebRequest.Create(folderPath);
						createFolderRequest.Method = WebRequestMethods.Ftp.MakeDirectory;
						createFolderRequest.Credentials = new NetworkCredential(string.Empty, string.Empty);
						createFolderRequest.GetResponse();
					}

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

						StatusLabel.Text += $"Archivo '{fileName}' adjuntado correctamente<br />";
					}
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

    private bool EliminarArchivosEnCarpeta(string folderName)
		{
			bool archivosEliminados = false;
			try
			{
				string folderPath = ftpServerUrl + "/" + folderName;

				string[] files = ObtenerAchivosEnCarpeta(folderPath, string.Empty, string.Empty);

				foreach (string file in files)
				{
					string filePath = folderPath + "/" + file;
					FtpWebRequest ftpRequest = (FtpWebRequest)WebRequest.Create(filePath);
					ftpRequest.Method = WebRequestMethods.Ftp.DeleteFile;
					ftpRequest.Credentials = new NetworkCredential(string.Empty, string.Empty);

					using (FtpWebResponse ftpResponse = (FtpWebResponse)ftpRequest.GetResponse())
					{
						archivosEliminados = true;
					}
				}
			}
			catch (Exception)
			{
                //
			}

			return archivosEliminados;
		}

		private string[] ObtenerAchivosEnCarpeta(string folderPath, string username, string password)
		{
			try
			{
				FtpWebRequest ftpRequest = (FtpWebRequest)WebRequest.Create(folderPath);
				ftpRequest.Method = WebRequestMethods.Ftp.ListDirectory;
				ftpRequest.Credentials = new NetworkCredential(username, password);

				using (FtpWebResponse ftpResponse = (FtpWebResponse)ftpRequest.GetResponse())
				using (StreamReader reader = new StreamReader(ftpResponse.GetResponseStream()))
				{
					string directoryListing = reader.ReadToEnd();
					return directoryListing.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
				}
			}
			catch (Exception ex)
			{
				return new string[0];
			}
		}

        private int ObtenerCodigoGerenciaPorRemitente()
        {
            if (Request.QueryString["CodigoGerencia"] != null)
            {
                switch (Request.QueryString["CodigoGerencia"].ToString())
                {
                    case "1":
                        nombreGerenciaRemitente = "Presidencia";
						return 1;
					case "2":
						nombreGerenciaRemitente = "Auditoria Interna";
						return 2;
                    case "3":
						nombreGerenciaRemitente = "Gestion Comunicacional";
						return 3;
                    case "4":
						nombreGerenciaRemitente = "Planifiacion y Presupuesto";
						return 4;
                    case "5":
						nombreGerenciaRemitente = "Tecnologia de la Informacion";
						return 5;
                    case "6":
						nombreGerenciaRemitente = "Atencion al Ciudadano";
						return 6;
                    case "7":
						nombreGerenciaRemitente = "Gestion Administrativa";
						return 7;
                    case "8":
						nombreGerenciaRemitente = "Gestion Humana";
						return 8;
                    case "9":
						nombreGerenciaRemitente = "Seguridad";
						return 9;
                    case "10":
						nombreGerenciaRemitente = "Comercializacion";
						return 10;
                    case "11":
						nombreGerenciaRemitente = "Financiamiento";
						return 11;
                    case "12":
						nombreGerenciaRemitente = "Tecnica Automotriz";
						return 12;
                    case "13":
						nombreGerenciaRemitente = "Movilidad Estudiantil";
						return 13;
					case "14":
						nombreGerenciaRemitente = "Consultoría Jurídica";
						return 13;
					default:
                        return 0;
                }
            }
            else
            {
                return 0;
			}
        }
	}
}