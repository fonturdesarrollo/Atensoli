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

                if (Request.QueryString["identifier"] == "Clientes")
                {
                    DataSet ds = Autocomplete.ObtenerClientes(Request.QueryString["query"]);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Response.Write("<ul>" + "\n");
                        paginaBase.AutoCompleteResult item;
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            item = new paginaBase.AutoCompleteResult();
                            item.value = dr["DatosCliente"].ToString();
                            item.id = dr["CedulaCliente"].ToString();
                            item.value = item.value.Replace(Request.QueryString["query"].ToString(), "<span style='font-weight:bold;'>" + Request.QueryString["query"].ToString() + "</span>");
                            Response.Write("\t" + "<li id=autocomplete_" + item.id + " rel='" + item.id + "_" + dr["NombreCliente"].ToString() + "_" + dr["CedulaCliente"].ToString() + "_" + dr["TelefonoCliente"].ToString() + "_" + dr["DireccionCliente"].ToString() + "_" + dr["EMailCliente"].ToString() + "_" + dr["ClienteID"].ToString() + "'>" + item.value + "</li>" + "\n");
                        }
                        Response.Write("</ul>");
                        Response.End();
                    }
                }
                if (Request.QueryString["identifier"] == "Marcas")
                {
                    DataSet ds = Autocomplete.ObtenerTipoCelular(Request.QueryString["query"]);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Response.Write("<ul>" + "\n");
                        paginaBase.AutoCompleteResult item;
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            item = new paginaBase.AutoCompleteResult();
                            item.value = dr["NombreTipoCelular"].ToString();
                            item.id = dr["TipoCelularID"].ToString();
                            item.value = item.value.Replace(Request.QueryString["query"].ToString(), "<span style='font-weight:bold;'>" + Request.QueryString["query"].ToString() + "</span>");
                            Response.Write("\t" + "<li id=autocomplete_" + item.id + " rel='" + item.id + "_" + dr["NombreTipoCelular"].ToString() + "_" + dr["TipoCelularID"].ToString() + "_" + dr["TipoEquipoID"].ToString()  + "'>" + item.value + "</li>" + "\n");
                        }
                        Response.Write("</ul>");
                        Response.End();
                    }
                }
                if (Request.QueryString["identifier"] == "Modelos")
                {
                    DataSet ds = Autocomplete.ObtenerModeloCelular(Request.QueryString["query"],Convert.ToInt32(Session["CodigoTipoEquipo"]), Convert.ToInt32(Session["CodigoMarcaEquipo"]));
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Response.Write("<ul>" + "\n");
                        paginaBase.AutoCompleteResult item;
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            item = new paginaBase.AutoCompleteResult();
                            item.value = dr["NombreModeloCelular"].ToString();
                            item.id = dr["ModeloCelularID"].ToString();
                            item.value = item.value.Replace(Request.QueryString["query"].ToString(), "<span style='font-weight:bold;'>" + Request.QueryString["query"].ToString() + "</span>");
                            Response.Write("\t" + "<li id=autocomplete_" + item.id + " rel='" + item.id + "_" + dr["NombreModeloCelular"].ToString() + "_" + dr["ModeloCelularID"].ToString() + "_" + dr["TipoCelularID"].ToString() + "_" + dr["TipoEquipoID"].ToString() + "'>" + item.value + "</li>" + "\n");
                        }
                        Response.Write("</ul>");
                        Response.End();
                    }
                }
                if (Request.QueryString["identifier"] == "Fallas")
                {
                    DataSet ds = Autocomplete.ObtenerFallaCelular(Request.QueryString["query"]);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Response.Write("<ul>" + "\n");
                        paginaBase.AutoCompleteResult item;
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            item = new paginaBase.AutoCompleteResult();
                            item.value = dr["NombreFallaCelular"].ToString();
                            item.id = dr["FallaCelularID"].ToString();
                            item.value = item.value.Replace(Request.QueryString["query"].ToString(), "<span style='font-weight:bold;'>" + Request.QueryString["query"].ToString() + "</span>");
                            Response.Write("\t" + "<li id=autocomplete_" + item.id + " rel='" + item.id + "_" + dr["NombreFallaCelular"].ToString() + "_" + dr["FallaCelularID"].ToString()  + "'>" + item.value + "</li>" + "\n");
                        }
                        Response.Write("</ul>");
                        Response.End();
                    }
                }
                if (Request.QueryString["identifier"] == "Tecnicos")
                {
                    DataSet ds = Autocomplete.ObtenerTecnicos(Request.QueryString["query"]);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Response.Write("<ul>" + "\n");
                        paginaBase.AutoCompleteResult item;
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            item = new paginaBase.AutoCompleteResult();
                            item.value = dr["NombreTecnico"].ToString();
                            item.id = dr["TecnicoID"].ToString();
                            item.value = item.value.Replace(Request.QueryString["query"].ToString(), "<span style='font-weight:bold;'>" + Request.QueryString["query"].ToString() + "</span>");
                            Response.Write("\t" + "<li id=autocomplete_" + item.id + " rel='" + item.id + "_" + dr["NombreTecnico"].ToString() + "_" + dr["TecnicoID"].ToString() + "_" + dr["CedulaTecnico"].ToString() + "'>" + item.value + "</li>" + "\n");
                        }
                        Response.Write("</ul>");
                        Response.End();
                    }
                }
                if (Request.QueryString["identifier"] == "Inventario")
                {
                    DataSet ds = Autocomplete.ObtenerInventarioItem(Request.QueryString["query"],  Convert.ToInt32(Session["CodigoSucursalEmpresa"]));
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Response.Write("<ul>" + "\n");
                        paginaBase.AutoCompleteResult item;
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            item = new paginaBase.AutoCompleteResult();
                            item.value = dr["NombreItem"].ToString();
                            item.id = dr["InventarioID"].ToString();
                            item.value = item.value.Replace(Request.QueryString["query"].ToString(), "<span style='font-weight:bold;'>" + Request.QueryString["query"].ToString() + "</span>");
                            Response.Write("\t" + "<li id=autocomplete_" + item.id + " rel='" + item.id + "_" + dr["NombreItem"].ToString() + "_" + dr["InventarioID"].ToString() + "_" + dr["CantidadItem"].ToString() + "_" + dr["CostoItem"].ToString() + "_" + dr["SerialItem"].ToString() + "'>" + item.value + "</li>" + "\n");
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