using System;
using System.Data;



namespace Admin
{
    public partial class Autocomplete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["query"] != "")
            {


                if (Request.QueryString["identifier"] == "Solicitante")
                {
                    DataSet ds = Autocomplete.ObtenerCedulaSolicitante(Request.QueryString["query"],  Convert.ToInt32(Session["CodigoSucursalEmpresa"]));
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Response.Write("<ul>" + "\n");
                        paginaBase.AutoCompleteResult item;
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            item = new paginaBase.AutoCompleteResult();
                            item.value = dr["DescripcionSolicitante"].ToString();
                            item.id = dr["SolicitanteID"].ToString();
                            item.value = item.value.Replace(Request.QueryString["query"].ToString(), "<span style='font-weight:bold;'>" + Request.QueryString["query"].ToString() + "</span>");
                            Response.Write("\t" + "<li id=autocomplete_" + item.id + " rel='" + item.id + "_" + dr["CedulaSolicitante"].ToString() + "_" + dr["SolicitanteID"].ToString() + "_" + dr["NombreSolicitante"].ToString() + "_" + dr["ApellidoSolicitante"].ToString() + "_" + dr["Sexo"].ToString() + "'>" + item.value + "</li>" + "\n");
                        }
                        Response.Write("</ul>");
                        Response.End();
                    }
                }
                if (Request.QueryString["identifier"] == "Empresas")
                {
                    DataSet ds = Autocomplete.ObtenerEmpresas(Request.QueryString["query"]);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Response.Write("<ul>" + "\n");
                        paginaBase.AutoCompleteResult item;
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            item = new paginaBase.AutoCompleteResult();
                            item.value = dr["NombreEmpresa"].ToString();
                            item.id = dr["EmpresaID"].ToString();
                            item.value = item.value.Replace(Request.QueryString["query"].ToString(), "<span style='font-weight:bold;'>" + Request.QueryString["query"].ToString() + "</span>");
                            Response.Write("\t" + "<li id=autocomplete_" + item.id + " rel='" + item.id + "_" + dr["NombreEmpresa"].ToString() + "_" + dr["EmpresaID"].ToString() + "_" + dr["RIFEmpresa"].ToString() + "_" + dr["DireccionEmpresa"].ToString() + "_" + dr["TelefonoEmpresa"].ToString() + "_" + dr["EMailEmpresa"].ToString() + "_" + dr["TwitterEmpresa"].ToString() + "_" + dr["InstagramEmpresa"].ToString() + "_" + dr["FacebookEmpresa"].ToString() + "_" + dr["LogoEmpresa"].ToString() + "_" + dr["WebEmpresa"].ToString() + "_" + dr["EstatusEmpresaID"].ToString() + "'>" + item.value + "</li>" + "\n");
                        }
                        Response.Write("</ul>");
                        Response.End();
                    }
                }
                if (Request.QueryString["identifier"] == "Usuarios")
                {
                    DataSet ds = Autocomplete.ObtenerUsuarios(Request.QueryString["query"], Convert.ToInt32(Session["CodigoSucursalEmpresa"]));
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Response.Write("<ul>" + "\n");
                        paginaBase.AutoCompleteResult item;
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            item = new paginaBase.AutoCompleteResult();
                            item.value = dr["NombreCompleto"].ToString();
                            item.id = dr["SeguridadUsuarioDatosID"].ToString();
                            item.value = item.value.Replace(Request.QueryString["query"].ToString(), "<span style='font-weight:bold;'>" + Request.QueryString["query"].ToString() + "</span>");
                            Response.Write("\t" + "<li id=autocomplete_" + item.id + " rel='" + item.id + "_" + dr["NombreCompleto"].ToString() + "_" + dr["LoginUsuario"].ToString() + "_" + dr["ClaveUsuario"].ToString() + "_" + dr["DescripcionUsuario"].ToString() + "_" + dr["SeguridadGrupoID"].ToString() + "_" + dr["UsuarioTecnico"].ToString() + "_" + dr["EstatusUsuario"].ToString() + "'>" + item.value + "</li>" + "\n");
                        }
                        Response.Write("</ul>");
                        Response.End();
                    }
                }
                if (Request.QueryString["identifier"] == "Grupos")
                {
                    DataSet ds = Autocomplete.ObtenerGrupos(Request.QueryString["query"]);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Response.Write("<ul>" + "\n");
                        paginaBase.AutoCompleteResult item;
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            item = new paginaBase.AutoCompleteResult();
                            item.value = dr["NombreGrupo"].ToString();
                            item.id = dr["SeguridadGrupoID"].ToString();
                            item.value = item.value.Replace(Request.QueryString["query"].ToString(), "<span style='font-weight:bold;'>" + Request.QueryString["query"].ToString() + "</span>");
                            Response.Write("\t" + "<li id=autocomplete_" + item.id + " rel='" + item.id + "_" + dr["NombreGrupo"].ToString() + "_" + dr["DescripcionGrupo"].ToString() + "_" + dr["SeguridadGrupoID"].ToString() + "'>" + item.value + "</li>" + "\n");
                        }
                        Response.Write("</ul>");
                        Response.End();
                    }
                }
                if (Request.QueryString["identifier"] == "Objetos")
                {
                    DataSet ds = Autocomplete.ObtenerObjetos(Request.QueryString["query"]);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Response.Write("<ul>" + "\n");
                        paginaBase.AutoCompleteResult item;
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            item = new paginaBase.AutoCompleteResult();
                            item.value = dr["NombreObjeto"].ToString();
                            item.id = dr["SeguridadObjetoID"].ToString();
                            item.value = item.value.Replace(Request.QueryString["query"].ToString(), "<span style='font-weight:bold;'>" + Request.QueryString["query"].ToString() + "</span>");
                            Response.Write("\t" + "<li id=autocomplete_" + item.id + " rel='" + item.id + "_" + dr["NombreObjeto"].ToString() + "_" + dr["SeguridadObjetoID"].ToString() + "'>" + item.value + "</li>" + "\n");
                        }
                        Response.Write("</ul>");
                        Response.End();
                    }
                }
            }
        }
    }
}