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
											<span class="opener">Solicitudes</span>
											<ul>
												<li><ASP:HyperLink runat="server" ID ="lnkSolicitudes"  navigateurl ="~/Vista/BuscarTipoSolicitud.aspx"  Text ="Registrar solicitud"></ASP:HyperLink></li>
											</ul>
										</li>

										<li>
											<span class="opener">Opciones especiales</span>
											<ul>
												<li><ASP:HyperLink runat="server" ID ="lnkSolicitante"  navigateurl ="~/Vista/EnConstruccion.aspx" Text ="Solicitante"></ASP:HyperLink></li>
												<li><ASP:HyperLink runat="server" ID ="lnkOrganismo"  navigateurl ="~/Vista/EnConstruccion.aspx" Text ="Organismo"></ASP:HyperLink></li>
												<li><ASP:HyperLink runat="server" ID ="lnkTipoSolicitante"  navigateurl ="~/Vista/EnConstruccion.aspx" Text ="Tipo de solicitante"></ASP:HyperLink></li>
												<li><ASP:HyperLink runat="server" ID ="lnkTipoSolicitud"  navigateurl ="~/Vista/EnConstruccion.aspx" Text ="Tipo de solicitud"></ASP:HyperLink></li>
												<li><ASP:HyperLink runat="server" ID ="lnkTipoOrganismo"  navigateurl ="~/Vista/EnConstruccion.aspx" Text ="Tipo de organismo"></ASP:HyperLink></li>
												<li><ASP:HyperLink runat="server" ID ="lnkTipoAtencion"  navigateurl ="~/Vista/EnConstruccion.aspx" Text ="Tipo de atención"></ASP:HyperLink></li>
												<li><ASP:HyperLink runat="server" ID ="lnkReferido"  navigateurl ="~/Vista/EnConstruccion.aspx" Text ="Tipo de referencia"></ASP:HyperLink></li>
												<li><ASP:HyperLink runat="server" ID ="lnkTipoUnidad"  navigateurl ="~/Vista/EnConstruccion.aspx" Text ="Tipo de unidad transporte"></ASP:HyperLink></li>
												<li><ASP:HyperLink runat="server" ID ="lnkTipoInsumo"  navigateurl ="~/Vista/EnConstruccion.aspx" Text ="Tipo de insumo"></ASP:HyperLink></li>
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
									<p class="copyright">&copy; Cellper. Todos los derechos reservados.</p>
								</footer>

						</div>
					</div>

			</div>

		<!-- Scripts -->
 

	</body>
</html>