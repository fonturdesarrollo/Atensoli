<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CorrespondenciaHistorial.aspx.cs" Inherits="Atensoli.CorrespondenciaHistorial" %>

<%@ Register TagPrefix="uc2" TagName="UCNavegacion" Src="~/Vista/UCNavegacion.ascx" %>
<%@ Register TagPrefix="MsgBox" Src="~/Vista/UCMessageBox.ascx" TagName="UCMessageBox" %>

<!DOCTYPE HTML>

<html>
	<head>
		<title>Atensoli | Correspondencia Historial</title>
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
		<script src="../assets/js/skel.min.js"></script>
		<script src="../assets/js/util.js"></script>
		<script src="../assets/js/main.js"></script>       

<%--------------------------%>

	<script type="text/javascript">

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
									<a class="logo">
										<strong><asp:Label runat ="server" ID ="lblTitulo" Text="Correspondencia Historial"></asp:Label></strong>
									</a>
									<ul class="icons">
										<asp:HyperLink runat ="server" ID="lnkAtras" NavigateUrl="~/Vista/CorrespondenciaRecepcionGerencia.aspx" Text="Volver"></asp:HyperLink>
									</ul>
								</header>

							<!-- Content -->
							<form runat ="server" id ="principal">	
								<section>
										<p></p>
											<p></p>
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
														  <asp:TemplateField HeaderText="Fecha Correspondencia">
															  <ItemTemplate>
																  <asp:Label runat="server" ID="lblFechaCorrespondencia" Text='<%# Eval("FechaCortaCorrespondencia") %>'  ></asp:Label>
															  </ItemTemplate>
														  </asp:TemplateField>
														  <asp:TemplateField HeaderText="Fecha Carga Correspondencia">
															  <ItemTemplate>
																  <asp:Label runat="server" ID="lblFechaCargaCorrespondencia" Text='<%# Eval("FechaCargaCorrespondencia") %>'  ></asp:Label>
															  </ItemTemplate>
														  </asp:TemplateField>
														  <asp:TemplateField HeaderText="Fecha Seguimiento Correspondencia">
															  <ItemTemplate>
																  <asp:Label runat="server" ID="lblFecha" Text='<%# Eval("FechaSeguimientoCorrespondencia") %>'  ></asp:Label>
															  </ItemTemplate>
														  </asp:TemplateField>

														  <asp:TemplateField HeaderText="N° Correspondencia" >
															  <ItemTemplate>
																  <asp:Label runat="server" ID="lblNumeroCorr" Text='<%# Eval("CorrespondenciaID") %>'  ></asp:Label>
															  </ItemTemplate>
														  </asp:TemplateField>
														  <asp:TemplateField HeaderText="Instrucciones">
															  <ItemTemplate>
																  <asp:Label runat="server" ID="lblInstrucciones" Text='<%# Eval("NombreTipoInstruccionCorrespondencia") %>'  ></asp:Label>
															  </ItemTemplate>
														  </asp:TemplateField>
														  <asp:TemplateField HeaderText="Observaciones">
															  <ItemTemplate>
																  <asp:Label runat="server" ID="lblObservaciones" Text='<%# Eval("ObservacionesSeguimientoCorrespondencia") %>'  ></asp:Label>
															  </ItemTemplate>
														  </asp:TemplateField>
														  <asp:TemplateField HeaderText="Gerencia Remitente">
															  <ItemTemplate>    
																  <asp:Label runat="server" ID="lblRemitente" Text='<%# Eval("NombreGerenciaRemitente") %>'  ></asp:Label>
															  </ItemTemplate>
														  </asp:TemplateField>
														  <asp:TemplateField HeaderText="Gerencia Remitida">
															  <ItemTemplate>    
																  <asp:Label runat="server" ID="lblRemitida" Text='<%# Eval("NombreGerenciaRemitida") %>'  ></asp:Label>
															  </ItemTemplate>
														  </asp:TemplateField>
														  <asp:TemplateField HeaderText="Estatus">
															  <ItemTemplate>    
																  <asp:Label runat="server" ID="lblEstatus" Text='<%# Eval("NombreCorrespondenciaEstatus") %>'  ></asp:Label>
															  </ItemTemplate>
														  </asp:TemplateField>
														  <asp:TemplateField HeaderText="Usuario">
															  <ItemTemplate>
																  <asp:Label runat="server" ID="lblUsuario" Text='<%# Eval("NombreCompleto") %>'  ></asp:Label>
															  </ItemTemplate>
														  </asp:TemplateField>
													  </Columns>
												  </asp:GridView>
											</div>
								</section>
							</form>
						</div>
					</div>
					<uc2:UCNavegacion  runat ="server" ID ="ControlMenu"/>
				</div>
	</body>
</html>
