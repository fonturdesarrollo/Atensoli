<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCNavegacion.ascx.cs" Inherits="Atensoli.Vista.UCNavegacion" %>

<!DOCTYPE HTML>

<html>

	<body>
		<!-- Wrapper -->
			<div id="wrapper">

				<!-- Main -->
				<!-- Sidebar -->
					<div id="sidebar">
						<div class="inner">

							<!-- Search -->


							<!-- Menu -->
								<nav id="menu">
									<header class="major">
										<h2>Menu</h2>
									</header>
									<ul>
										<li><a href="Principal.aspx">Inicio</a></li>
										<li>
											<span class="opener">Atención al Ciudadano</span>
											<ul>
												<li><ASP:HyperLink runat="server" ID ="lnkSolicitudes"  navigateurl ="~/Vista/SeleccionarTipoSolicitud.aspx"  Text ="Registrar solicitud"></ASP:HyperLink></li>
												<li><ASP:HyperLink runat="server" ID ="lnkConsultarSolicitud"  navigateurl ="~/Vista/ConsultarSolicitud.aspx"  Text ="Consultar solicitud"></ASP:HyperLink></li>
											</ul>
										</li>

										<li>
											<span class="opener">Opciones especiales</span>
											<ul>
												<li><ASP:HyperLink runat="server" ID ="lnkTipoSolicitante"  navigateurl ="~/Vista/TipoSolicitante.aspx" Text ="Tipo de solicitante"></ASP:HyperLink></li>
												<li><ASP:HyperLink runat="server" ID ="lnkTipoSolicitud"  navigateurl ="~/Vista/TipoSolicitud.aspx" Text ="Tipo de solicitud"></ASP:HyperLink></li>
												<li><ASP:HyperLink runat="server" ID ="lnkTipoOrganizacion"  navigateurl ="~/Vista/TipoOrganizacion.aspx" Text ="Tipo de organización"></ASP:HyperLink></li>
												<li><ASP:HyperLink runat="server" ID ="lnkTipoAtencion"  navigateurl ="~/Vista/TipoAtencion.aspx" Text ="Tipo de atención"></ASP:HyperLink></li>
												<li><ASP:HyperLink runat="server" ID ="lnkReferido"  navigateurl ="~/Vista/TipoReferencia.aspx" Text ="Tipo de referencia"></ASP:HyperLink></li>
												<li><ASP:HyperLink runat="server" ID ="lnkTipoUnidad"  navigateurl ="~/Vista/EnConstruccion.aspx" Text ="Tipo de unidad transporte"></ASP:HyperLink></li>
												<li><ASP:HyperLink runat="server" ID ="lnkTipoInsumo"  navigateurl ="~/Vista/TipoInsumo.aspx" Text ="Tipo de insumo"></ASP:HyperLink></li>
												<li><ASP:HyperLink runat="server" ID ="lnkTipoSoporteFIsico"  navigateurl ="~/Vista/TipoSoporte.aspx" Text ="Tipo de soporte fisico"></ASP:HyperLink></li>
											</ul>
										</li>
										<li>
											<span class="opener">Seguridad</span>
											<ul>
												<li><ASP:HyperLink runat="server" ID ="lnkSeguridad"  navigateurl="~/Vista/Seguridad.aspx" Text ="Agregar / Modificar Usuario"></ASP:HyperLink></li>
												<li><ASP:HyperLink runat="server" ID ="lnkCambiarClave"  navigateurl="~/Vista/SeguridadCambiarClave.aspx" Text ="Cambiar Clave"></ASP:HyperLink></li>
											</ul>
										</li>
										<li><a href="Logout.aspx">Salir</a></li>
									</ul>
								</nav>

							<!-- Section -->


							<!-- Section -->
							<!-- Footer -->
								<footer id="footer">
									<p><%:Session["NombreCompletoUsuario"]%> <%:Session["NombreEmpresa"]%></p>
									<p class="copyright">&copy; <%= DateTime.Now.ToString("yyy") %> Desarrollado por la Gerencia de Tecnología de la Información, División de Desarrollo. Todos los derechos reservados.</p>
								</footer>
						</div>
					</div>
			</div>
		<!-- Scripts -->
	</body>
</html>