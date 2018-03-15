<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCNavegacion.ascx.cs" Inherits="Cellper.Vista.UCNavegacion" %>

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
											<span class="opener">Servicio Técnico</span>
											<ul>
                                                <li><ASP:HyperLink runat="server" ID ="lnkRecepcionEquipo"  navigateurl ="~/Vista/RecepcionEquipo.aspx"  Text ="Recepción de equipos"></ASP:HyperLink></li>
                                                <li><ASP:HyperLink runat="server" ID ="lnkColaDeEquipos"  navigateurl ="~/Vista/ColaDeEquipos.aspx"  Text ="Cola de equipos Pendientes"></ASP:HyperLink></li>
											</ul>
										</li>

										<li>
											<span class="opener">Consultas</span>
											<ul>
                                                <li><ASP:HyperLink runat="server" ID ="lnkColaReparacionEquipos"  navigateurl ="~/Vista/ColaReparacionEquipo.aspx" Text ="Equipos por Facturar"></ASP:HyperLink></li>
                                                <li><ASP:HyperLink runat="server" ID ="lnkColaEquiposEntregados"  navigateurl ="~/Vista/EquiposEntregados.aspx" Text ="Equipos Entregados"></ASP:HyperLink></li>
											</ul>
										</li>
										<li>
											<span class="opener">Opciones especiales</span>
											<ul>
                                                <li><ASP:HyperLink runat="server" ID ="lnkInventario"  navigateurl ="~/Vista/Inventario.aspx" Text ="Inventario de piezas, partes y servicios"></ASP:HyperLink></li>
												<li><ASP:HyperLink runat="server" ID ="lnkMarcaEquipo"  navigateurl ="~/Vista/MarcaEquipo.aspx" Text ="Registrar Marca de Equipos"></ASP:HyperLink></li>
                                                <li><ASP:HyperLink runat="server" ID ="lnkModeloEquipo"  navigateurl ="~/Vista/ModeloEquipo.aspx" Text ="Registrar Modelo de Equipos"></ASP:HyperLink></li>
                                                <li><ASP:HyperLink runat="server" ID ="lnkFallasEquipo"  navigateurl ="~/Vista/FallaEquipo.aspx" Text ="Registrar Tipo de Fallas"></ASP:HyperLink></li>
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