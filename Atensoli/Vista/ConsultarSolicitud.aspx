<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsultarSolicitud.aspx.cs" Inherits="Atensoli.ConsultarSolicitud" %>

<%@ Register TagPrefix="uc2" TagName="UCNavegacion" Src="~/Vista/UCNavegacion.ascx" %>
<%@ Register TagPrefix="MsgBox" Src="~/Vista/UCMessageBox.ascx" TagName="UCMessageBox" %>

<!DOCTYPE HTML>

<html>
	<head>
		<title>Atensoli | Consultar Solicitud</title>
		<meta charset="utf-8" />
		<meta name="viewport" content="width=device-width, initial-scale=1, user-scalable=no" />

<%--        SCRIPTS--%>
		<link rel="stylesheet"  href="../Styles/jquery-ui-1.8rc3.custom.css"  />
		<script src="../assets/js/jquery.min.js"></script>
		<link rel="stylesheet" href="../assets/css/main.css" />
		<link rel="stylesheet" href="../Styles/simpleAutoComplete.css"  />
		<script src="../js/Util.js" type="text/javascript"></script>
<%--        <script src="../js/jquery.js"></script>--%>      
		<script  src="../js/jquery-ui-1.8rc3.custom.min.js"></script>
		<script src="../assets/js/jquery.min.js"></script>
		<script src="../assets/js/skel.min.js"></script>
		<script src="../assets/js/util.js"></script>
		<script src="../assets/js/main.js"></script>      

<%--------------------------%>

	<script type="text/javascript">
			$(function () {
			$('#txtCedula').keydown(function (e) {
			if (e.shiftKey || e.ctrlKey || e.altKey) {
			e.preventDefault();
			} else {
			var key = e.keyCode;
			if (!((key == 8) || (key == 46) || (key >= 35 && key <= 40) || (key >= 48 && key <= 57) || (key >= 96 && key <= 105))) {
			e.preventDefault();
			}
			}
			});
		});
	</script>
	</head>
	<body>
		<MsgBox:UCMessageBox ID="messageBox" runat="server" ></MsgBox:UCMessageBox>
		<!-- Wrapper -->
			<div id="wrapper">

				<!-- Main -->
					<div id="main">
						<div class="inner">

							<!-- Header -->
								<header id="header">
									<a class="logo"><strong>Consultar Solicitud</strong></a>
									<ul class="icons">

									</ul>
								</header>

							<!-- Content -->
							<form runat ="server" id ="principal">	
								<section>
										<p></p>
										<div class="row uniform">
											<div class="6u 12u$(xsmall)">
												<asp:TextBox runat="server" ID="txtCedula" MaxLength="9" placeholder ="Indique el número de cedula del solicitante"/>  
												<ASP:RequiredFieldValidator id="rqrValidaCedula" runat="server" errormessage="Debe colocar el número de cedula del solicitante"  controltovalidate="txtCedula" display="Dynamic" ForeColor ="Red"></ASP:RequiredFieldValidator>
											</div>

											<div class="12u$">
												<ul class="actions">
													<asp:Button Text="Consultar" runat="server" ID ="btnConsultar"  CssClass ="special" OnClick="btnConsultar_Click" />
												</ul>
											</div>
											<div class="table-wrapper">
												  <asp:GridView ID="gridDetalle" runat="server" 
													  CssClass="subtitulo" 
													  EmptyDataText="No existen Registros" 
													  GridLines="Horizontal" 
													  AutoGenerateColumns="False">
														<HeaderStyle  Font-Size="10px" />
														<AlternatingRowStyle Font-Size="10px" />
														  <RowStyle  Font-Size="10px" />
													  <Columns>
														  <asp:TemplateField HeaderText="N°" HeaderStyle-Width="50">
															  <ItemTemplate>
																  <asp:Label runat="server" ID="lblNumero" Text='<%# Eval("SolicitudID") %>'  ></asp:Label>
															  </ItemTemplate>
														  </asp:TemplateField>
														  <asp:TemplateField HeaderText="Fecha Solicitud" >
															  <ItemTemplate>
																  <asp:Label runat="server" ID="lblFechaSolicitud" Text='<%# Eval("FechaRegistroSolicitud") %>'  ></asp:Label>
															  </ItemTemplate>
														  </asp:TemplateField>
														  <asp:TemplateField HeaderText="Tipo Solicitud" >
															  <ItemTemplate>
																  <asp:Label runat="server" ID="lblTipoSolicitud" Text='<%# Eval("NombreTipoSolicitud") %>'  ></asp:Label>
															  </ItemTemplate>
														  </asp:TemplateField>
														  <asp:TemplateField HeaderText="Tipo Solicitante">
															  <ItemTemplate>
																  <asp:Label runat="server" ID="lblTipoSolicitante" Text='<%# Eval("NombreTipoSolicitante") %>'  ></asp:Label>
															  </ItemTemplate>
														  </asp:TemplateField>
														  <asp:TemplateField HeaderText="Nombre Solicitante">
															  <ItemTemplate>
																  <asp:Label runat="server" ID="lblNombreSolicitante" Text='<%# Eval("SolicitanteNombre") %>'  ></asp:Label>
															  </ItemTemplate>
														  </asp:TemplateField>
														  <asp:TemplateField HeaderText="Nombre Organización">
															  <ItemTemplate>
																  <asp:Label runat="server" ID="lblNombreOrganizacion" Text='<%# Eval("NombreOrganizacion") %>'  ></asp:Label>
															  </ItemTemplate>
														  </asp:TemplateField>
														  <asp:TemplateField HeaderText="Tipo Atención">
															  <ItemTemplate>
																  <asp:Label runat="server" ID="lblTipoAtencion" Text='<%# Eval("NombreTipoAtencionBrindada") %>'  ></asp:Label>
															  </ItemTemplate>
														  </asp:TemplateField>
														  <asp:TemplateField HeaderText="Tipo Referencia">
															  <ItemTemplate>
																  <asp:Label runat="server" ID="lblTipoReferencia" Text='<%# Eval("NombreTipoReferenciaSolicitud") %>'  ></asp:Label>
															  </ItemTemplate>
														  </asp:TemplateField>
														  <asp:TemplateField HeaderText="Tipo Unidad">
															  <ItemTemplate>
																  <asp:Label runat="server" ID="lblTipoUnidad" Text='<%# Eval("NombreTipoUnidad") %>'  ></asp:Label>
															  </ItemTemplate>
														  </asp:TemplateField>
														  <asp:TemplateField HeaderText="Tipo Insumo">
															  <ItemTemplate>
																  <asp:Label runat="server" ID="lblTipoInsumo" Text='<%# Eval("NombreTipoInsumo") %>'  ></asp:Label>
															  </ItemTemplate>
														  </asp:TemplateField>
														  <asp:TemplateField HeaderText="Detalle Tipo Insumo">
															  <ItemTemplate>
																  <asp:Label runat="server" ID="lblTipoInsumoDetalle" Text='<%# Eval("NombreTipoInsumoDetalle") %>'  ></asp:Label>
															  </ItemTemplate>
														  </asp:TemplateField>
														  <asp:TemplateField HeaderText="Remitido">
															  <ItemTemplate>
																  <asp:Label runat="server" ID="lblRemitido" Text='<%# Eval("NombreTipoRemitido") %>'  ></asp:Label>
															  </ItemTemplate>
														  </asp:TemplateField>
														  <asp:TemplateField HeaderText="Forma Atención">
															  <ItemTemplate>
																  <asp:Label runat="server" ID="lblTipoAten" Text='<%# Eval("NombreTipoFormaAtencion") %>'  ></asp:Label>
															  </ItemTemplate>
														  </asp:TemplateField>
														  <asp:TemplateField HeaderText="Observaciones Solicitante">
															  <ItemTemplate>
																  <asp:Label runat="server" ID="lblObsSol" Text='<%# Eval("ObservacionesSolicitante") %>'  ></asp:Label>
															  </ItemTemplate>
														  </asp:TemplateField>
														  <asp:TemplateField HeaderText="Observaciones Analista">
															  <ItemTemplate>
																  <asp:Label runat="server" ID="lblObsAnalis" Text='<%# Eval("ObservacionesAnalista") %>'  ></asp:Label>
															  </ItemTemplate>
														  </asp:TemplateField>
														  <asp:TemplateField HeaderText="Atendido por">
															  <ItemTemplate>
																  <asp:Label runat="server" ID="lblAtencion" Text='<%# Eval("NombreCompleto") %>'  ></asp:Label>
															  </ItemTemplate>
														  </asp:TemplateField>
													  </Columns>
												  </asp:GridView>


											</div>
										</div>
								</section>
							</form>
						</div>
					</div>
				<!-- Sidebar -->
<%--					<div id="sidebar">
						<div class="inner">--%>
							<!-- Menu -->
								<uc2:UCNavegacion  runat ="server" ID ="ControlMenu"/>
<%--						</div>
					</div>--%>
			</div>
		<!-- Scripts -->

<%--        SE COLOCARON EN EL HEADER --%>

	</body>
</html>